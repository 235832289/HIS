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
    /// 住院科室工作日志
    /// </summary>
    public partial class frmRptDeptWorkLog : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 构造
        /// </summary>
        public frmRptDeptWorkLog()
        {
            InitializeComponent();
            objReport = new clsCtl_Report();
        }           

        #region 变量       
        /// <summary>
        /// 报表业务类
        /// </summary>
        private clsCtl_Report objReport;
        /// <summary>
        /// 医保身份ID数组
        /// </summary>
        private ArrayList YBPayTypeIDArr = new ArrayList();
        #endregion           
             
        private void frmRptDeptWorkLog_Load(object sender, EventArgs e)
        {       
            this.dwRep.LibraryList = clsPublic.PBLPath;
            this.dwRep.DataWindowObject = "d_bih_deptworklog";
            this.dwRep.Modify("t_title.text = '" + this.objReport.HospitalName + this.dwRep.Describe("t_title.text") + "'");
            this.dwRep.InsertRow(0);

            YBPayTypeIDArr = clsPublic.m_ArrGettoken(clsPublic.m_strGetSysparm("0008"), ";");
        }                   

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string CurrDate = this.dteRq1.Value.ToString("yyyy-MM-dd");          

            try
            {
                this.dwRep.PrintProperties.Preview = false; 
                clsPublic.PlayAvi("findFILE.avi", "正在统计日志信息，请稍候...");
                this.objReport.m_mthRptDeptWorkLog(CurrDate, YBPayTypeIDArr, this.dwRep);
            }
            finally
            {
                clsPublic.CloseAvi();
            }
            this.dwRep.Refresh();  
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
     
    }
}