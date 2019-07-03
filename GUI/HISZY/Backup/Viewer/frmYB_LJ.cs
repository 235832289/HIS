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
    /// 顺德(伦教)普通门诊、住院医保费用明细上传UI
    /// </summary>
    public partial class frmYB_LJ : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 变量
        /// <summary>
        /// 报表业务类
        /// </summary>
        private clsCtl_Report objReport;
        /// <summary>
        /// 数据源
        /// </summary>
        private DataTable dtSource;
        /// <summary>
        /// 查找号
        /// </summary>
        private string NO = "";        
        #endregion

        /// <summary>
        /// 构造
        /// </summary>
        public frmYB_LJ()
        {
            InitializeComponent();
            objReport = new clsCtl_Report();
        }

        private void frmYB_LJ_Load(object sender, EventArgs e)
        {           
            this.dwRep.LibraryList = clsPublic.PBLPath;
            this.dwRep.DataWindowObject = "d_bih_sdyb";            
            this.dwRep.Modify("t_title.text = '" + this.objReport.HospitalName + this.dwRep.Describe("t_title.text") + "'");
            this.dwRep.InsertRow(0);         

            this.rdoMz.Checked = true;
            this.txtZyh.Enabled = false;
            this.txtInvoNo.Focus();
        }

        private void rdoMz_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoMz.Checked)
            {
                this.txtZyh.Text = "";
                this.txtZyh.Enabled = false;

                this.txtInvoNo.Enabled = true;
                this.txtInvoNo.Focus();
            }            
        }

        private void rdoZy_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoZy.Checked)
            {
                this.txtInvoNo.Text = "";
                this.txtInvoNo.Enabled = false;

                this.txtZyh.Enabled = true;
                this.txtZyh.Focus();
            } 
        }               

        private void btnStat_Click(object sender, EventArgs e)
        {
            int Type = 0;            

            if (this.rdoMz.Checked)
            {
                NO = this.txtInvoNo.Text.Trim();

                if (NO == "")
                {
                    MessageBox.Show("请输入发票号码。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Type = 1;
            }
            else if (this.rdoZy.Checked)
            {
                NO = this.txtZyh.Text.Trim();

                if (NO == "")
                {
                    MessageBox.Show("请输入住院号。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Type = 2;
            }           

            clsPublic.PlayAvi("findFILE.avi", "正在生成医保费用清单，请稍候...");
            this.dwRep.Reset();
            this.objReport.m_mthRptSDYB(Type, NO, this.dwRep, out dtSource);                        
            clsPublic.CloseAvi(); 
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (NO == "" || this.dwRep.RowCount==0)
            {
                return;
            }

            this.objReport.m_mthUpLoad_SDYB(NO, dtSource);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            clsPublic.ChoosePrintDialog(this.dwRep, true);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            clsPublic.ExportDataWindow(this.dwRep, null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}