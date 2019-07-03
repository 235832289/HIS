using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Sybase.DataWindow;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    /// <summary>
    /// 项目统计发生明细报表
    /// </summary>
    public partial class frmRptItemDetailStat : Form
    {
        public frmRptItemDetailStat()
        {
            InitializeComponent();
            objReport = new clsCtl_ReportZY();
            objSvc = new clsDcl_Charge();
        }

        private clsDcl_Charge objSvc;


        #region 变量
        /// <summary>
        /// 科室ID数组
        /// </summary>
        private ArrayList DeptIDArr = new ArrayList();
        /// <summary>
        /// 报表业务类
        /// </summary>
        private clsCtl_ReportZY objReport;
        /// <summary>
        /// PB事务
        /// </summary>
        private Transaction pbTrans;
        #endregion

        private void btnDept_Click(object sender, EventArgs e)
        {
            frmAidDeptList fDept = new frmAidDeptList();
            if (fDept.ShowDialog() == DialogResult.OK)
            {
                DeptIDArr = fDept.DeptIDArr;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.dwRep.RowCount > 0)
            {
                clsPublic.ExportDataWindow(this.dwRep, null);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            clsPublic.ChoosePrintDialog(this.dwRep, true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region 显示窗体
        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="ParmVal"></param>
        internal string str_parmval = "";
        public void m_mthShow(string ParmVal)
        {
            str_parmval = ParmVal;
            this.Show();
        }
        #endregion

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (!clsPublic.m_blnCheckDateRange(str_parmval, this.dteRq1.Value.ToString("yyyy-MM-dd"), this.dteRq2.Value.ToString("yyyy-MM-dd")))
            {
                return;
            }
  
            string CodeNo = this.txtCodeNo.Text.Trim();
            if (CodeNo == "")
            {
                MessageBox.Show("请输入项目编码。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtCodeNo.Focus();
                return;
            }

            string BeginDate = this.dteRq1.Value.ToString("yyyy-MM-dd");
            string EndDate = this.dteRq2.Value.ToString("yyyy-MM-dd");

            if (Convert.ToDateTime(BeginDate + " 00:00:01") > Convert.ToDateTime(EndDate + " 00:00:01"))
            {
                MessageBox.Show("开始日期不能大于结束日期。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            clsPublic.PlayAvi("findFILE.avi", "正在统计项目发生明细，请稍候...");
            this.objReport.m_lngRptItemDetailStat(CodeNo, BeginDate, EndDate, DeptIDArr, this.dwRep);
            clsPublic.CloseAvi();

            this.dwRep.Refresh();
        }

        private void frmRptItemDetailStat_Load(object sender, EventArgs e)
        {          
            this.m_pnlItem.Height = 0;

            string rpttitle = "";
            rpttitle = this.objReport.HospitalName + "项目统计发生明细报表(按发生)";
            this.Text = rpttitle;

            this.dwRep.LibraryList = clsPublic.PBLPath;
            this.dwRep.DataWindowObject = "d_bih_item_detail_stat";
            this.dwRep.Modify("t_title.text = '" + rpttitle + "'");
            this.dwRep.PrintProperties.Preview = false;    
            this.dwRep.Refresh();
        }

        private void txtCodeNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                m_mthFindChargeItem(this.txtCodeNo.Text);
            }
        }

        #region 查找收费项目
        /// <summary>
        /// 查找收费项目
        /// </summary>
        /// <param name="FindStr"></param>
        public void m_mthFindChargeItem(string FindStr)
        {
            if (FindStr.Trim() == "")
            {
                return;
            }


            this.lsvItem.BeginUpdate();
            this.lsvItem.Items.Clear();

            DataTable dt;
            long l = this.objSvc.m_lngFindChargeItem(FindStr, "0001", out dt);
            if (l > 0 && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string invocat = m_strConvertToChType(dt.Rows[i]["itemipinvtype_chr"].ToString().Trim());   //发票分类 flag_int = 4
                    ListViewItem lv = new ListViewItem(FindStr);
                    lv.SubItems.Add(dt.Rows[i]["itemcode_vchr"].ToString().Trim());
                    lv.SubItems.Add(dt.Rows[i]["itemname_vchr"].ToString().Trim());
                    lv.SubItems.Add(dt.Rows[i]["itemcommname_vchr"].ToString().Trim());
                    lv.SubItems.Add(invocat);
                    lv.SubItems.Add(dt.Rows[i]["itemspec_vchr"].ToString().Trim());
                    //如果已用的是最小单位,就用小单价和最小单位                      
                    if (dt.Rows[i]["ipchargeflg_int"].ToString().Trim() == "1")
                    {
                        lv.SubItems.Add(dt.Rows[i]["itemipunit_chr"].ToString().Trim());
                        lv.SubItems.Add(dt.Rows[i]["submoney"].ToString().Trim());
                    }
                    else
                    {
                        lv.SubItems.Add(dt.Rows[i]["itemunit_chr"].ToString().Trim());
                        lv.SubItems.Add(dt.Rows[i]["itemprice_mny"].ToString().Trim());
                    }

                    string PRECENT_DEC = "100";
                    if (dt.Rows[i]["precent_dec"].ToString().Trim() != "")
                    {
                        PRECENT_DEC = dt.Rows[i]["precent_dec"].ToString().Trim();
                    }
                    lv.SubItems.Add(PRECENT_DEC + "%"); //收费比例  
                    lv.SubItems.Add(dt.Rows[i]["ybtypename"].ToString().Trim());

                    if (invocat.IndexOf("中") >= 0 || invocat.IndexOf("西") >= 0)
                    {
                        if (dt.Rows[i]["ipnoqtyflag_int"].ToString().Trim() != "0")
                        {
                            lv.SubItems.Add("缺药");
                            lv.ForeColor = Color.Red;
                        }
                        else
                        {
                            lv.SubItems.Add("");
                        }
                    }
                    else
                    {
                        lv.SubItems.Add("");
                    }

                    lv.Tag = dt.Rows[i];
                    this.lsvItem.Items.Add(lv);
                }
                this.m_pnlItem.Height = 200;
                this.lsvItem.Items[0].Selected = true;
                this.lsvItem.Focus();
            }

            this.lsvItem.EndUpdate();
        }
        #endregion

        private void lsvItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                SelectedItem();
            }
        }

        private void lsvItem_DoubleClick(object sender, EventArgs e)
        {
            SelectedItem();
        }

        private void SelectedItem()
        {
            if (this.lsvItem.Items.Count == 0 || this.lsvItem.SelectedItems.Count == 0)
            {
                return;
            }

            DataRow dr = this.lsvItem.SelectedItems[0].Tag as DataRow;

            this.txtCodeNo.Text = dr["itemcode_vchr"].ToString();

            this.txtCodeNo.Focus();
        }

        #region 根据ID转换成中文类别

        /// <summary>
        /// 根据ID转换成中文类别

        /// </summary>
        /// <param name="TypeNo"></param>
        /// <returns></returns>
        private string m_strConvertToChType(string TypeNo)
        {
            string Ret = "";

            //for (int i = 0; i < dtChargeItemCat.Rows.Count; i++)
            //{
            //    if (TypeNo == dtChargeItemCat.Rows[i]["typeid_chr"].ToString())
            //    {
            //        Ret = dtChargeItemCat.Rows[i]["typename_vchr"].ToString();
            //        break;
            //    }
            //}

            return Ret;
        }
        #endregion

        private void lsvItem_Leave(object sender, EventArgs e)
        {
            this.m_pnlItem.Height = 0;
        }

    }
}