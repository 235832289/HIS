using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ControlLibrary;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 用法带出收费项目UI
    /// </summary>
    public partial class frmUsageAddItem : Form
    {
        /// <summary>
        /// 构造

        /// </summary>
        public frmUsageAddItem(string pattype, string applyareaid, bool _isChildPrice)
        {
            InitializeComponent();

            PatType = pattype;
            ApplyAreaID = applyareaid;
            this.IsChildPrice = _isChildPrice;
        }

        #region 变量
        /// <summary>
        /// 病人身份
        /// </summary>
        private string PatType = "";
        /// <summary>
        /// 申请病区ID
        /// </summary>
        private string ApplyAreaID = "";
        /// <summary>
        /// 数据集视图

        /// </summary>
        private DataView DV = null;
        /// <summary>
        /// 状态

        /// </summary>
        private bool blStatus = false;
        /// <summary>
        /// 返回DATAROW数组
        /// </summary>
        internal ArrayList DrArr = new ArrayList();
        /// <summary>
        /// 收费组合数量
        /// </summary>
        internal int Nums = 1;

        /// <summary>
        /// 儿童价格
        /// </summary>
        internal bool IsChildPrice { get; set; }

        #endregion

        #region 装载数据
        /// <summary>
        /// 装载数据
        /// </summary>
        private void m_mthLoad()
        {
            clsDcl_CommonFind objComm = new clsDcl_CommonFind();

            DataTable dt1, dt2;

            long l = objComm.m_lngGetUsageInfo(out dt1);
            if (l > 0)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    DataRow dr = dt1.Rows[i];

                    string[] sarr = new string[3];

                    sarr[0] = Convert.ToString(i + 1);
                    sarr[1] = dr["usercode_chr"].ToString().Trim();
                    sarr[2] = dr["usagename_vchr"].ToString().Trim();

                    this.dvLeft.Rows.Add(sarr);
                    this.dvLeft.Rows[i].Tag = dr;
                }
            }
            else
            {
                MessageBox.Show("获取用法信息列表失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            l = objComm.m_lngGetUsageAddItem(out dt2, PatType, ApplyAreaID );
            if (l > 0)
            {
                DV = new DataView(dt2);

                if (dt1.Rows.Count > 0)
                {
                    this.m_mthFilter(dt1.Rows[0]["usageid_chr"].ToString());
                    blStatus = true;
                }
            }
            else
            {
                MessageBox.Show("获取用法带出收费项目信息失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 过滤
        /// <summary>
        /// 过滤
        /// </summary>
        /// <param name="UsageID"></param>
        public void m_mthFilter(string UsageID)
        {
            this.dvRight.Rows.Clear();                     

            this.Cursor = Cursors.WaitCursor;

            DV.RowFilter = "usageid_chr = '" + UsageID + "'";

            for (int i = 0; i < DV.Count; i++)
            {
                DataRow dr = DV[i].Row;

                string[] sarr = new string[7];

                sarr[1] = dr["itemcode_vchr"].ToString().Trim();
                sarr[2] = dr["itemname_vchr"].ToString().Trim();
                sarr[3] = dr["itemspec_vchr"].ToString().Trim();
                sarr[4] = dr["itemprice_mny"].ToString().Trim();
                sarr[5] = dr["amount"].ToString().Trim();

                int flag = 0;

                //优先停用->缺药
                if (dr["ifstop_int"].ToString() == "1")
                {
                    sarr[0] = "F";
                    sarr[6] = "停用";
                    flag = 1;
                }
                else
                {
                    sarr[0] = "T";

                    if (dr["noqtyflag_int"].ToString() == "1")
                    {
                        sarr[0] = "F";
                        sarr[6] = "缺药";
                        flag = 2;
                    }
                }

                int row = this.dvRight.Rows.Add(sarr);
                this.dvRight.Rows[row].Tag = dr;

                if (flag == 1)
                {
                    this.dvRight.Rows[row].Cells[0].ReadOnly = true;
                    this.dvRight.Rows[row].DefaultCellStyle.ForeColor = Color.Red;
                }
                else if (flag == 2)
                {
                    this.dvRight.Rows[row].DefaultCellStyle.ForeColor = Color.Blue;
                }

                if (Math.IEEERemainder(row, 2) == 0)
                {
                    this.dvRight.Rows[row].DefaultCellStyle.BackColor = clsPublic.CustomBackColor;
                }
            }            

            this.Cursor = Cursors.Default;
        }
        #endregion

        #region 全选

        /// <summary>
        /// 全选

        /// </summary>
        private void m_mthAllSelect()
        {
            for (int i = 0; i < this.dvRight.Rows.Count; i++)
            {
                if (this.dvRight.Rows[i].Cells[0].ReadOnly)
                {
                    continue;
                }

                this.dvRight.Rows[i].Cells[0].Value = "T";
            }
        }
        #endregion

        #region 反选

        /// <summary>
        /// 反选

        /// </summary>
        private void m_mthDeSelect()
        {
            for (int i = 0; i < this.dvRight.Rows.Count; i++)
            {
                if (this.dvRight.Rows[i].Cells[0].ReadOnly)
                {
                    continue;
                }

                if (this.dvRight.Rows[i].Cells[0].Value.ToString() == "T")
                {
                    this.dvRight.Rows[i].Cells[0].Value = "F";
                }
                else
                {
                    this.dvRight.Rows[i].Cells[0].Value = "T";
                }
            }
        }
        #endregion

        #region 确定
        /// <summary>
        /// 确定
        /// </summary>
        private void m_mthOK()
        {
            if (this.dvRight.Rows.Count == 0)
            {
                return;
            }

            for (int i = 0; i < this.dvRight.Rows.Count; i++)
            {
                if (this.dvRight.Rows[i].Cells[0].Value.ToString() == "T")
                {
                    DataRow dr = this.dvRight.Rows[i].Tag as DataRow;
                    DrArr.Add(dr);
                }
            }

            if (DrArr.Count == 0)
            {
                MessageBox.Show("对不起，你没有选择什么收费项目。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                this.Nums = int.Parse(this.txtNums.Value.ToString());                
                this.DialogResult = DialogResult.OK;
            }
        }
        #endregion

        private void dvLeft_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            else
            {
                if (blStatus)
                {
                    this.m_mthFilter(((DataRow)this.dvLeft.Rows[e.RowIndex].Tag)["usageid_chr"].ToString());
                }
            }
        }   

        private void frmUsageAddItem_Load(object sender, EventArgs e)
        {
            this.m_mthLoad();            
        }

        private void frmUsageAddItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.F4)
            {
                this.m_mthDeSelect();
            }
            else if (e.KeyCode == Keys.F5)
            {
                this.m_mthAllSelect();
            }            
            else if (e.KeyCode == Keys.F8)
            {
                this.m_mthOK();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
               
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.m_mthOK();
        }            
    }
}