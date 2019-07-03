using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sybase.DataWindow;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 预出院未结算病人统计报表
    /// </summary>
    public partial class frmRptOutNoCharge : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 构造

        /// </summary>
        public frmRptOutNoCharge()
        {
            InitializeComponent();

            objReport = new clsCtl_Report();
        }

        #region 变量
        /// <summary>
        /// 报表业务类

        /// </summary>
        private clsCtl_Report objReport;
        
        #endregion             
        #region 设置窗体属性
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_GetSections();
            this.objController.Set_GUI_Apperance(this);
        }
        #endregion       
        private void frmRptOutNoCharge_Load(object sender, EventArgs e)
        {           
            this.dwRep.LibraryList = clsPublic.PBLPath;
            this.dwRep.DataWindowObject = "d_bih_outnocharge";
            this.dwRep.Modify("t_title.text = '" + this.objReport.HospitalName + this.dwRep.Describe("t_title.text") + "'");
         
            this.dteRq1.Value = Convert.ToDateTime(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-01");
            ((clsCtl_GetSections)this.objController).m_mthGetSections();
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
            
            string BeginDate = this.dteRq1.Value.ToString("yyyy-MM-dd");
            string EndDate = this.dteRq2.Value.ToString("yyyy-MM-dd");

            if (Convert.ToDateTime(BeginDate + " 00:00:01") > Convert.ToDateTime(EndDate + " 00:00:01"))
            {
                MessageBox.Show("开始日期不能大于结束日期。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (m_txtSections.Text.Length == 0)
            {
                MessageBox.Show("请选择要查询的科室!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_txtSections.SelectionStart = 0;
                m_txtSections.SelectionLength = m_txtSections.Text.Length;
                m_txtSections.Focus();
                return;
            }
            try
            {
                //MessageBox.Show(m_txtSections.Value.ToString());
                if (m_txtSections.Value.ToString() == null)
                {

                }
            }
            catch
            {
                MessageBox.Show("选择的科室错误!请重新选择", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_txtSections.SelectionStart = 0;
                m_txtSections.SelectionLength = m_txtSections.Text.Length;
                m_txtSections.Focus();
                return;
            }       

            try
            {
                //clsPublic.PlayAvi("findFILE.avi", "统计预出院未结算病人信息，请稍候...");
                this.objReport.m_mthRptOutNoCharge(BeginDate + " 00:00:00", EndDate + " 23:59:59",m_txtSections.Value.ToString(), this.dwRep);                
            }
            finally
            {
                //clsPublic.CloseAvi();
            }
            this.dwRep.Refresh();          
        }              

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.dwRep.RowCount > 0)
            {
                clsPublic.ExportDataWindow(this.dwRep, null);
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            this.dwRep.PrintProperties.Preview = !this.dwRep.PrintProperties.Preview;
            this.dwRep.PrintProperties.ShowPreviewRulers = this.dwRep.PrintProperties.Preview;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            clsPublic.ChoosePrintDialog(this.dwRep, true);
        }       

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            frmAidChoosePayType f = new frmAidChoosePayType();
            if (f.ShowDialog() == DialogResult.OK)
            {
                string PayTypeID = f.PayTypeIDArr;

                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    this.dwRep.SetRedrawOff();
                    this.dwRep.SetFilter("1=1");
                    this.dwRep.Filter();
                    this.dwRep.SetFilter("fbcode in (" + PayTypeID + ")");
                    this.dwRep.Filter();
                    this.dwRep.SetRedrawOn();
                    this.dwRep.Refresh();
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }           
    }
}