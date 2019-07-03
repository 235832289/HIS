using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 多次住院病人选择窗口UI
    /// </summary>
    public partial class frmAidChooseZyh : Form
    {
        #region 构造
        public frmAidChooseZyh(DataTable dt)
        {
            InitializeComponent();
            DT = dt;
        }
        #endregion

        #region 变量
        /// <summary>
        /// DataTable
        /// </summary>
        private DataTable DT;
        /// <summary>
        /// 选择行
        /// </summary>
        private DataRow dr;
        /// <summary>
        /// 选择行
        /// </summary>
        public DataRow DR
        {
            get
            {
                return dr;
            }
        }        
        #endregion

        private void frmAidChooseZyh_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                string[] sarr = new string[3];

                DataRow dr = DT.Rows[i];

                sarr[0] = dr["inpatientid_chr"].ToString().Trim();
                sarr[1] = dr["inpatientcount_int"].ToString().Trim();
                sarr[2] = dr["lastname_vchr"].ToString().Trim();               

                int row = this.dtPat.Rows.Add(sarr);
                this.dtPat.Rows[row].Tag = dr;
            }
        }

        private void dtPat_MouseDoubleClick(object sender, MouseEventArgs e)
        {            
            dr = (DataRow)this.dtPat.SelectedRows[0].Tag;

            this.DialogResult = DialogResult.OK;
        }

        private void frmAidChooseZyh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void dtPat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.dtPat.SelectedRows.Count > 0)
                {
                    dr = (DataRow)this.dtPat.SelectedRows[0].Tag;
                    this.DialogResult = DialogResult.OK;
                }
            }
        }
    }
}