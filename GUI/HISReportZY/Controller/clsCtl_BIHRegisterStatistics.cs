using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;
using com.digitalwave.iCare.middletier.PatientSvc;
using CrystalDecisions;
using CrystalDecisions.CrystalReports.Engine;

using ControlLibrary;

namespace com.digitalwave.iCare.gui.HIS.Reports
{   
   /// <summary>
   /// 病人入院单统计表--界面控制层 liuyingrui 2006-05-08
   /// </summary>
    class clsCtl_BIHRegisterStatistics:com.digitalwave.GUI_Base.clsController_Base
    {
        com.digitalwave.iCare.gui.HIS.Reports.clsDcl_StatQuery objSvc;
        private CrystalDecisions.CrystalReports.Engine.ReportDocument rptBIHRegisterStatistics;
        com.digitalwave.iCare.gui.HIS.Reports.frmBIHRegisterStatistics m_objViewer;
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmBIHRegisterStatistics)frmMDI_Child_Base_in;
		}
		public clsCtl_BIHRegisterStatistics()
		{
            objSvc = new clsDcl_StatQuery();
		}
        
        /// <summary>
        ///病人入院单统计表
        /// </summary>
        public void m_mthShowBIHStatistics()
        {
          
            this.m_objViewer.Cursor = Cursors.WaitCursor;
            DataTable dtbResult = new DataTable();
            rptBIHRegisterStatistics = new ReportDocument();
            rptBIHRegisterStatistics.Load(@"Report\rptBeInHospital.rpt");
            rptBIHRegisterStatistics.DataDefinition.FormulaFields["dtStartTime"].Text = "'" + this.m_objViewer.m_dtpStatDate.Text + "'";
            rptBIHRegisterStatistics.DataDefinition.FormulaFields["dtEndTime"].Text = "'" + this.m_objViewer.m_dtpEnd.Text + "'";


            //change 2007-4-17
            //long lngRes = objSvc.GetPatientBihStatistics(DateTime.Parse(m_objViewer.m_dtpStatDate.Text + " 00:00:00"), DateTime.Parse(m_objViewer.m_dtpEnd.Text + " 23:59:59"), out dtbResult);
            //----------------------------------->
            long lngRes = objSvc.GetPatientBihStatistics(DateTime.Parse(m_objViewer.m_dtpStatDate.Text + " 00:00:00"), DateTime.Parse(m_objViewer.m_dtpEnd.Text + " 23:59:59"),m_objViewer.m_txtProtectType.Value, out dtbResult);
            //<--------------------------------------

            if (lngRes > 0)
            {
                this.rptBIHRegisterStatistics.SetDataSource(dtbResult);
                this.m_objViewer.crvBIHRegisterStat.ReportSource = rptBIHRegisterStatistics;
                this.m_objViewer.btnPrintRpt.Enabled = true;
            }
            this.m_objViewer.Cursor = Cursors.Default;
        }

        /// <summary>
        ///病人出院单统计表
        /// </summary>
        public void m_mthShowBIHLeftStatistics()
        {

            this.m_objViewer.Cursor = Cursors.WaitCursor;
            DataTable dtbResult = new DataTable();
            rptBIHRegisterStatistics = new ReportDocument();
            rptBIHRegisterStatistics.Load(@"Report\rptLeaveHospital.rpt");
            rptBIHRegisterStatistics.DataDefinition.FormulaFields["dtStartTime"].Text = "'" + this.m_objViewer.m_dtpStatDate.Text + "'";
            rptBIHRegisterStatistics.DataDefinition.FormulaFields["dtEndTime"].Text = "'" + this.m_objViewer.m_dtpEnd.Text + "'";


            //change 2007-4-18
            //long lngRes = objSvc.GetPatientLeftStatistics(DateTime.Parse(m_objViewer.m_dtpStatDate.Text + " 00:00:00"), DateTime.Parse(m_objViewer.m_dtpEnd.Text + " 23:59:59"),  out dtbResult);
            // ---------------------------->
            long lngRes = objSvc.GetPatientLeftStatistics(DateTime.Parse(m_objViewer.m_dtpStatDate.Text + " 00:00:00"), DateTime.Parse(m_objViewer.m_dtpEnd.Text + " 23:59:59"),m_objViewer.m_txtProtectType.Value,  out dtbResult);
            // <------------------------------

            if (lngRes > 0)
            {
                this.rptBIHRegisterStatistics.SetDataSource(dtbResult);
                this.m_objViewer.crvBIHRegisterStat.ReportSource = rptBIHRegisterStatistics;
                this.m_objViewer.btnPrintRpt.Enabled = true;
            }
            this.m_objViewer.Cursor = Cursors.Default;
        }


        public void m_mthPrintReportDoc()
        {
            this.m_objViewer.crvBIHRegisterStat.PrintReport();
        }

        internal void m_FillCboPatientType()
        {
            clsColumns_VO[] columArr = new clsColumns_VO[]{
                new clsColumns_VO("编号","PAYTYPENO_VCHR",HorizontalAlignment.Left,50),
                new clsColumns_VO("名称","PAYTYPENAME_VCHR",HorizontalAlignment.Left,130)
            };

            this.m_objViewer.m_txtProtectType.m_strSQL = @"
                                            select '0000'　PAYTYPEID_CHR,'00'　PAYTYPENO_VCHR,'全部'　PAYTYPENAME_VCHR from dual
                                            union all
                                            select t.PAYTYPEID_CHR, t.PAYTYPENO_VCHR, t.PAYTYPENAME_VCHR 
                                              from t_bse_patientpaytype t
                                              where t.ISUSING_NUM = 1 and
                                                    (t.PAYFLAG_DEC = 0 or t.PAYFLAG_DEC = 2)
                                             ORDER BY PAYTYPENO_VCHR";
            this.m_objViewer.m_txtProtectType.m_mthInitListView(columArr);
        }
    }
}
