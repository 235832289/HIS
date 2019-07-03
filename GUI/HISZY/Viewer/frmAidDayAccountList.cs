using System;
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
    /// 期帐列表UI
    /// </summary>
    public partial class frmAidDayAccountList : Form
    {
        #region 变量
        /// <summary>
        /// 入院登记ID
        /// </summary>
        private string RegID = "";
        /// <summary>
        /// 期帐ID
        /// </summary>
        private string dayaccountid = "";
        /// <summary>
        /// 期帐ID
        /// </summary>
        public string DayAccountID
        {
            get
            {
                return dayaccountid;
            }
        }
        /// <summary>
        /// 生效时间
        /// </summary>
        private string activedat = "";
        /// <summary>
        /// 生效时间
        /// </summary>
        public string ActiveDat
        {
            get
            {
                return activedat;
            }
        }
        #endregion

        /// <summary>
        /// 构造
        /// </summary>
        public frmAidDayAccountList(string regid)
        {
            InitializeComponent();

            RegID = regid;
        }

        #region 获取期帐数据
        /// <summary>
        /// 获取期帐数据
        /// </summary>
        public void m_mthLoadData()
        {
            this.lv.BeginUpdate();

            clsDcl_Charge objSvc = new clsDcl_Charge();

            DataTable dt;
            long l = objSvc.m_lngGetPatientDayaccountsByRegID(RegID, out dt);
            if (l > 0 && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {                  
                    decimal val = clsPublic.ConvertObjToDecimal(dt.Rows[i]["charge_dec"]) - clsPublic.ConvertObjToDecimal(dt.Rows[i]["clearchg_dec"]);

                    ListViewItem lvitem = new ListViewItem("  ");
                    lvitem.SubItems.Add("第" + dt.Rows[i]["orderno_int"].ToString() + "期");
                    lvitem.SubItems.Add(Convert.ToDateTime(dt.Rows[i]["square_dat"].ToString()).ToString("yyyy/MM/dd HH:mm"));
                    lvitem.SubItems.Add(clsPublic.ConvertObjToDecimal(dt.Rows[i]["charge_dec"]).ToString("###,##0.00"));
                    lvitem.SubItems.Add(clsPublic.ConvertObjToDecimal(dt.Rows[i]["clearchg_dec"]).ToString("###,##0.00"));
                    lvitem.SubItems.Add(val.ToString("###,##0.00"));

                    if (val == 0)
                    {
                        lvitem.ForeColor = Color.RoyalBlue;                        
                    }

                    lvitem.ImageIndex = 3;
                    lvitem.Tag = dt.Rows[i];
                    this.lv.Items.Add(lvitem);
                }
            }

            this.lv.EndUpdate();
        }
        #endregion

        private void lv_DoubleClick(object sender, EventArgs e)
        {
            if (lv.SelectedItems.Count > 0)
            {
                DataRow dr = this.lv.SelectedItems[0].Tag as DataRow;

                if (clsPublic.ConvertObjToDecimal(dr["charge_dec"]) == clsPublic.ConvertObjToDecimal(dr["clearchg_dec"]))
                {
                    MessageBox.Show("该期帐已全部清帐，请重新选择。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                                
                dayaccountid = dr["dayaccountid_chr"].ToString();
                activedat = Convert.ToDateTime(dr["square_dat"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");

                this.DialogResult = DialogResult.OK;
            }
        }

        private void frmAidDayAccountList_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            this.m_mthLoadData();

            this.Cursor = Cursors.Default;
        }                

        private void frmAidDayAccountList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}