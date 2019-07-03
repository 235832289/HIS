using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 帐务查询诊疗项目UI类
    /// </summary>
    public partial class frmQueryCharge_DiagItem : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {        
        /// <summary>
        /// 构造函数
        /// </summary>        
        public frmQueryCharge_DiagItem(DataTable dtDiagSource, DataTable dtItemSource, clsCtl_QueryCharge objQueryCharge)
        {
            InitializeComponent();
            dvDiagSource = new DataView(dtDiagSource);
            dvItemSource = new DataView(dtItemSource);
            objCtlQueryCharge = objQueryCharge;
        }

        #region 变量
        /// <summary>
        /// 诊疗项目分类哈希表
        /// </summary>
        private Hashtable hasOrderCate = new Hashtable();        
        /// <summary>
        /// 数据视图(诊疗项目)
        /// </summary>
        private DataView dvDiagSource;        
        /// <summary>
        /// 数据视图(收费明细)
        /// </summary>
        private DataView dvItemSource;
        /// <summary>
        /// 帐务查询逻辑类
        /// </summary>
        private clsCtl_QueryCharge objCtlQueryCharge;
        /// <summary>
        /// 是否允许冲负数(药品类)
        /// </summary>
        internal bool IsAllowPatchNegativeMed = false;
        /// <summary>
        /// 是否允许冲负数(非药品类)
        /// </summary>
        internal bool IsAllowPatchNegativeNoMed = false;
        /// <summary>
        /// 退款项目数组
        /// </summary>
        internal ArrayList RefDiagArr;
        #endregion

        #region 添加诊疗项目类型
        /// <summary>
        /// 添加诊疗项目类型
        /// </summary>
        private void m_mthAddOrderCate()
        {
            DataTable dt;
            clsDcl_CommonFind objFind = new clsDcl_CommonFind();
            long l = objFind.m_lngGetOrderCate(out dt);
            if (l > 0)
            {
                this.cboClass.Items.Clear();

                this.cboClass.Items.Add("全部");
                hasOrderCate.Add("全部", "%");                
                this.cboClass.Items.Add("非诊疗项目");
                hasOrderCate.Add("非诊疗项目", "&");  

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (!hasOrderCate.ContainsKey(dt.Rows[i]["name_chr"].ToString().Trim()))
                    {
                        this.cboClass.Items.Add(dt.Rows[i]["name_chr"].ToString().Trim());
                        hasOrderCate.Add(dt.Rows[i]["name_chr"].ToString().Trim(), dt.Rows[i]["ordercateid_chr"].ToString());
                    }
                }

                //this.cboClass.SelectedIndex = 0;
            }
        }
        #endregion

        #region 填充诊疗项目
        /// <summary>
        /// 填充诊疗项目
        /// </summary>
        /// <param name="FilterExp">诊疗项目按分类过滤表达式</param>
        private void m_mthFillDiagItem(string FilterExp)
        {
            dvDiagSource.RowFilter = FilterExp;
            dvDiagSource.Sort = "orderdate asc, ordertype asc, ordername asc";

            this.dtDiagItem.Rows.Clear();
            this.dtItem.Rows.Clear();

            for (int i = 0; i < dvDiagSource.Count; i++)
            {
                DataRow dr = dvDiagSource[i].Row;

                string ordertype = dr["ordertype"].ToString().Trim();               
                if (ordertype == "0")
                {
                    ordertype = "加收";
                }
                else if (ordertype == "1")
                {
                    ordertype = "长嘱";
                }
                else if (ordertype == "2")
                {
                    ordertype = "临嘱";
                }
                else if (ordertype == "3")
                {
                    ordertype = "补次";
                }
                else if (ordertype == "4")
                {
                    ordertype = "出院带药";
                }
                else if (ordertype == "8")
                {
                    ordertype = "直收";
                }
                else if (ordertype == "9")
                {
                    ordertype = "补记帐";
                }
                else if (ordertype == "7")
                {
                    ordertype = "补期帐";
                }

                string[] sarr = new string[6];
                sarr[0] = "F";
                sarr[1] = Convert.ToString(i + 1);
                sarr[2] = dr["orderdate"].ToString().Trim();
                sarr[3] = ordertype;
                sarr[4] = dr["ordername"].ToString().Trim();
                sarr[5] = dr["orderpycode"].ToString().Trim();

                this.dtDiagItem.Rows.Add(sarr);
                this.dtDiagItem.Rows[i].Tag = dr;              

                if (Math.IEEERemainder(Convert.ToDouble(i + 1), 2) == 0)
                {
                    this.dtDiagItem.Rows[i].DefaultCellStyle.BackColor = clsPublic.CustomBackColor;
                }
            }

            if (this.dtDiagItem.Rows.Count > 0)
            {
                this.m_mthShowChargeItem(((DataRow)this.dtDiagItem.Rows[0].Tag), 1);
            }
        }
        #endregion

        #region 浏览费用明细
        /// <summary>
        /// 浏览费用明细
        /// </summary>
        /// <param name="p_dr"></param>
        /// <param name="p_flag">1 预览 2 返回DATAVIEW</param>
        private DataView m_mthShowChargeItem(DataRow p_dr, int p_flag)
        {
            string filterexp = "";
            string orderid = p_dr["orderid"].ToString();
            string orderexecid = p_dr["orderexecid"].ToString();
            string orderflag = p_dr["orderflag"].ToString();

            if (orderflag == "#1")
            {
                filterexp = "orderexecid_chr = '" + orderexecid + "'";
            }
            else if (orderflag == "#2")
            {
                filterexp = "orderid_chr = '" + orderid + "' and attachorderid_vchr = '" + orderexecid + "'";
            }
            else if (orderflag == "#3")
            {
                filterexp = "pchargeid_chr = '" + orderexecid + "'";
            }
  
            this.dvItemSource.RowFilter = filterexp;

            this.dtItem.Rows.Clear();

            if (this.dvItemSource.Count == 0)
            {
                return this.dvItemSource;
            }

            if (p_flag == 1)
            {
                decimal decTotal = 0;

                for (int i = 0; i < this.dvItemSource.Count + 1; i++)
                {
                    int row = -1;
                    string[] sarr = new string[15];

                    if (i == this.dvItemSource.Count)
                    {
                        sarr[2] = "===合计===";
                        sarr[4] = decTotal.ToString("0.00");

                        row = this.dtItem.Rows.Add(sarr);
                        this.dtItem.Rows[row].Tag = "";
                        this.dtItem.Rows[row].DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        DataRow dr = this.dvItemSource[i].Row;

                        sarr[0] = Convert.ToString(i + 1);
                        sarr[1] = dr["itemcode_vchr"].ToString();
                        sarr[2] = dr["chargeitemname_chr"].ToString().Trim();
                        sarr[3] = dr["amount_dec"].ToString();

                        decimal d = clsPublic.Round(clsPublic.ConvertObjToDecimal(dr["totalmony"]), 2);
                        decTotal += d;

                        sarr[4] = d.ToString("0.00");
                        sarr[5] = dr["unitprice_dec"].ToString();
                        sarr[6] = dr["spec_vchr"].ToString().Trim();
                        sarr[7] = dr["unit_vchr"].ToString();
                        sarr[8] = objCtlQueryCharge.GetDeptName(dr["curareaid_chr"].ToString().Trim());
                        sarr[8] = dr["chargedoctor_vchr"].ToString().Trim();
                        sarr[10] = objCtlQueryCharge.GetEmpName(dr["creator_chr"].ToString().Trim());

                        if (dr["chearaccount_dat"].ToString().Trim() != "")
                        {
                            sarr[11] = Convert.ToDateTime(dr["chearaccount_dat"].ToString()).ToString("yyyyMMdd");
                        }
                        else
                        {
                            sarr[11] = "";
                        }
                        sarr[12] = objCtlQueryCharge.GetDeptName(dr["createarea_chr"].ToString().Trim());
                        sarr[13] = dr["execarea"].ToString();

                        string Status = dr["pstatus_int"].ToString();
                        if (Status == "0")
                        {
                            Status = "待确认";
                        }
                        else if (Status == "1")
                        {
                            Status = "待结";
                        }
                        else if (Status == "2")
                        {
                            Status = "待清";
                        }
                        else if (Status == "3")
                        {
                            Status = "已清";
                        }
                        else if (Status == "4")
                        {
                            Status = "直收";
                        }
                        sarr[14] = Status;                        

                        row = this.dtItem.Rows.Add(sarr);
                        this.dtItem.Rows[row].Tag = dr;
                    }

                    if (Math.IEEERemainder(Convert.ToDouble(i + 1), 2) == 0)
                    {
                        this.dtItem.Rows[row].DefaultCellStyle.BackColor = clsPublic.CustomBackColor;
                    }
                }
            }
            return this.dvItemSource;
        }      
        #endregion

        #region 查找
        /// <summary>
        /// 查找
        /// </summary>
        private void m_mthFind()
        {
            frmAidFindItem fItem = new frmAidFindItem(this.dtDiagItem, 2);
            if (fItem.ShowDialog() == DialogResult.OK)
            {
                foreach (DataGridViewRow dr in this.dtDiagItem.SelectedRows)
                {
                    dr.Selected = false;
                }

                this.dtDiagItem.CurrentCell = this.dtDiagItem.Rows[fItem.Row].Cells[0];
                this.m_mthShowChargeItem(((DataRow)this.dtDiagItem.Rows[fItem.Row].Tag), 1);
            }
        }
        #endregion

        #region 退款
        /// <summary>
        /// 退款
        /// </summary>
        private void m_mthRefundment()
        {
            if (IsAllowPatchNegativeMed == false && IsAllowPatchNegativeNoMed == false)
            {
                MessageBox.Show("对不起，您没有权限对收费项目退费(负数冲帐)。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }          

            this.Cursor = Cursors.WaitCursor;

            bool IsSelected = false;
            RefDiagArr = new ArrayList();

            for (int i = 0; i < this.dtDiagItem.Rows.Count; i++)
            {
                if(this.dtDiagItem.Rows[i].Cells[0].Value.ToString().ToUpper() == "T")
                {
                    DataView dv = this.m_mthShowChargeItem(((DataRow)this.dtDiagItem.Rows[i].Tag), 2);

                    for (int j = 0; j < dv.Count; j++)
                    {
                        DataRow dr = dv[j].Row as DataRow;

                        #region 检查
                        string Status = dr["pstatus_int"].ToString();
                        if (Status == "0")
                        {
                            continue;
                        }
                        else if (Status == "3")
                        {
                            continue;
                        }
                        else if (Status == "4")
                        {
                            continue;
                        }

                        if (clsPublic.ConvertObjToDecimal(dr["amount_dec"]) <= 0)
                        {
                            continue;
                        }

                        string InvoCat = objCtlQueryCharge.GetCatName(dr["invcateid_chr"].ToString().Trim());
                        if (InvoCat.IndexOf("药") >= 0)
                        {
                            if (!this.IsAllowPatchNegativeMed)
                            {
                                continue;
                            }
                        }
                        else
                        {
                            if (!this.IsAllowPatchNegativeNoMed)
                            {
                                continue;
                            }
                        }
                        #endregion

                        #region 检查
                        //string Status = dr["pstatus_int"].ToString();
                        //if (Status == "0")
                        //{
                        //    this.Cursor = Cursors.Default;
                        //    MessageBox.Show("对不起，" + this.dtDiagItem.Rows[i].Cells["colzlxmmc"].Value.ToString().Trim() + "->" + dr["chargeitemname_chr"].ToString().Trim() + "为待确认项目，不能退费。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    return;
                        //}
                        //else if (Status == "3")
                        //{
                        //    this.Cursor = Cursors.Default;
                        //    MessageBox.Show("对不起，" + this.dtDiagItem.Rows[i].Cells["colzlxmmc"].Value.ToString().Trim() + "->" + dr["chargeitemname_chr"].ToString().Trim() + "为已清项目，不能退费。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    return;
                        //}
                        //else if (Status == "4")
                        //{
                        //    this.Cursor = Cursors.Default;
                        //    MessageBox.Show("对不起，" + this.dtDiagItem.Rows[i].Cells["colzlxmmc"].Value.ToString().Trim() + "->" + dr["chargeitemname_chr"].ToString().Trim() + "为直收项目，不能退费。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    return;
                        //}

                        //if (clsPublic.ConvertObjToDecimal(dr["amount_dec"]) <= 0)
                        //{
                        //    this.Cursor = Cursors.Default;
                        //    MessageBox.Show("对不起，" + this.dtDiagItem.Rows[i].Cells["colzlxmmc"].Value.ToString().Trim() + "->" + dr["chargeitemname_chr"].ToString().Trim() + "已经退费。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    return;
                        //}

                        //string InvoCat = objCtlQueryCharge.GetCatName(dr["invcateid_chr"].ToString().Trim());
                        //if (InvoCat.IndexOf("药") >= 0)
                        //{
                        //    if (!this.IsAllowPatchNegativeMed)
                        //    {
                        //        this.Cursor = Cursors.Default;
                        //        MessageBox.Show("对不起，" + this.dtDiagItem.Rows[i].Cells["colzlxmmc"].Value.ToString().Trim() + "->" + dr["chargeitemname_chr"].ToString().Trim() + "为药品，你没有权限对药品退费。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //        return;
                        //    }
                        //}
                        //else
                        //{
                        //    if (!this.IsAllowPatchNegativeNoMed)
                        //    {
                        //        this.Cursor = Cursors.Default;
                        //        MessageBox.Show("对不起，" + this.dtDiagItem.Rows[i].Cells["colzlxmmc"].Value.ToString().Trim() + "->" + dr["chargeitemname_chr"].ToString().Trim() + "为非药品，你没有权限对非药品退费。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //        return;
                        //    }
                        //}
                        #endregion

                        clsParmDiagItem_VO DiagItem_VO = new clsParmDiagItem_VO();
                        DiagItem_VO.PchargeID = dr["pchargeid_chr"].ToString();
                        DiagItem_VO.DiagName = this.dtDiagItem.Rows[i].Cells["colzlxmmc"].Value.ToString().Trim() + "->" + dr["chargeitemname_chr"].ToString().Trim();

                        RefDiagArr.Add(DiagItem_VO);
                    }

                    IsSelected = true;
                }
            }

            this.Cursor = Cursors.Default;

            if (IsSelected)
            {
                if (RefDiagArr.Count > 0)
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
            else
            {
                MessageBox.Show("请在左侧诊疗项目列表中选择需要退款的诊疗项目。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        #endregion

        private void frmQueryCharge_DiagItem_KeyDown(object sender, KeyEventArgs e)
        {           
            if (e.Control)
            {
                if (e.KeyCode == Keys.F)
                {
                    this.m_mthFind();
                }
            }
            else
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            }            
        }

        private void frmQueryCharge_DiagItem_Load(object sender, EventArgs e)
        {
            this.m_mthAddOrderCate();
            this.rdoAll.Checked = true;
            this.m_mthShowChargeItem(((DataRow)this.dtDiagItem.Rows[0].Tag), 1);
        }      

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            string CatID = "";
            string FilterExp = "1 = 1";

            if (hasOrderCate.ContainsKey(this.cboClass.Text))
            {
                CatID = hasOrderCate[this.cboClass.Text].ToString();
                if (CatID != "%")
                {
                    FilterExp = "ordercateid = '" + CatID + "'";
                }                
            }
            
            this.m_mthFillDiagItem(FilterExp);
        }

        private void dtDiagItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            this.m_mthShowChargeItem(((DataRow)this.dtDiagItem.Rows[e.RowIndex].Tag), 1);

            if (e.ColumnIndex == 0)
            {
                SendKeys.Send("{RIGHT}");
            }
        }            

        private void chkAllSelect_CheckedChanged(object sender, EventArgs e)
        {
            string Status = "F";
            if (this.chkAllSelect.Checked)
            {
                Status = "T";    
            }
            
            for (int i = 0; i < this.dtDiagItem.Rows.Count; i++)
            {
                this.dtDiagItem.Rows[i].Cells[0].Value = Status;
            }
        }

        private void rdoAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoAll.Checked)
            {
                this.rdoAll.ForeColor = Color.Blue;
                this.rdoClass.ForeColor = Color.Black;
                this.rdoDate.ForeColor = Color.Black;

                this.cboClass.Enabled = false;
                this.dtRq.Enabled = false;

                this.m_mthFillDiagItem("1=1");
            }
        }

        private void rdoClass_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoClass.Checked)
            {
                this.rdoAll.ForeColor = Color.Black;
                this.rdoClass.ForeColor = Color.Blue;
                this.rdoDate.ForeColor = Color.Black;

                this.cboClass.Enabled = true;
                this.dtRq.Enabled = false;

                this.cboClass.SelectedIndex = 0;
            }
        }

        private void rdoDate_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoDate.Checked)
            {
                this.rdoAll.ForeColor = Color.Black;
                this.rdoClass.ForeColor = Color.Black;
                this.rdoDate.ForeColor = Color.Blue;

                this.cboClass.Enabled = false;
                this.dtRq.Enabled = true;
            }
        }

        private void dtRq_ValueChanged(object sender, EventArgs e)
        {            
            this.m_mthFillDiagItem("orderdate = '" + this.dtRq.Value.ToString("yyyyMMdd") + "'");
        }

        private void ToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            this.m_mthRefundment();
        }

        private void ToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            this.m_mthFind();
        }

        private void btnRef_Click(object sender, EventArgs e)
        {
            this.m_mthRefundment();
        }

        private void dtDiagItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dtDiagItem.Rows[e.RowIndex].Cells[0].Value.ToString().ToUpper() == "T")
            {
                this.dtDiagItem.Rows[e.RowIndex].Cells[0].Value = "F";
            }
            else
            {
                this.dtDiagItem.Rows[e.RowIndex].Cells[0].Value = "T";
            }
        }
       
    }
}