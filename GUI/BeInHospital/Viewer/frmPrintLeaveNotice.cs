using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using com.digitalwave.Utility.Controls;
using com.digitalwave.iCare.BIHOrder;
using com.digitalwave.iCare.ValueObject;//iCareData.dll

using CrystalDecisions;
using CrystalDecisions.CrystalReports.Engine;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmPrintLeaveNotice : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
    {
        private clsBedManageVO m_bedManageVO;
        private clsT_Opr_Bih_Leave_VO m_leaveVO;
        //private string m_patName;
        
        public frmPrintLeaveNotice()
        {
            InitializeComponent();
        }

        public frmPrintLeaveNotice(clsBedManageVO p_bedManageVO, clsT_Opr_Bih_Leave_VO p_leaveVO)
        {
            InitializeComponent();

            this.m_bedManageVO = p_bedManageVO;
            this.m_leaveVO = p_leaveVO;
        }

        private void frmPrintLeaveNotice_Load(object sender, EventArgs e)
        {
            try
            {               
                //ReportDocument rptDocument = new ReportDocument();
                //rptDocument.Load(@".\report\LeaveNotice.rpt");
                //((TextObject)rptDocument.ReportDefinition.ReportObjects["strName"]).Text = this.m_bedManageVO.m_strNAME_VCHR ;
                //((TextObject)rptDocument.ReportDefinition.ReportObjects["strSex"]).Text = this.m_bedManageVO.m_strSEX_CHR ;
                //((TextObject)rptDocument.ReportDefinition.ReportObjects["strChargeType"]).Text = this.m_bedManageVO.m_strPAYTYPENAME_VCHR;
                //((TextObject)rptDocument.ReportDefinition.ReportObjects["strInpatientId"]).Text = this.m_bedManageVO.m_strINPATIENTID_CHR;
                //((TextObject)rptDocument.ReportDefinition.ReportObjects["strAreaName"]).Text = this.m_leaveVO.m_strOutAreaName;
                //((TextObject)rptDocument.ReportDefinition.ReportObjects["strBed"]).Text = this.m_bedManageVO.m_strCODE_CHR;

                //string outDate = this.m_leaveVO.m_strOUTHOSPITAL_DAT;
                //if (outDate != null)
                //{
                //    outDate = outDate.Substring(0, outDate.Length - 3);
                //}
                //((TextObject)rptDocument.ReportDefinition.ReportObjects["strOutDate"]).Text = outDate + " 出院";

                //((TextObject)rptDocument.ReportDefinition.ReportObjects["strDiagnose"]).Text = this.m_leaveVO.m_strDIAGNOSE_VCHR;
                //((TextObject)rptDocument.ReportDefinition.ReportObjects["strInsDiagnose"]).Text = this.m_leaveVO.m_strINS_DIAGNOSE_VCHR;
                //((TextObject)rptDocument.ReportDefinition.ReportObjects["strDoctorName"]).Text = this.m_bedManageVO.m_strMAINDOC;
                //((TextObject)rptDocument.ReportDefinition.ReportObjects["strOperator"]).Text = this.m_leaveVO.m_strOperatorName;
                //((TextObject)rptDocument.ReportDefinition.ReportObjects["strDES"]).Text = this.m_leaveVO.m_strDES_VCHR;

                //this.m_crReport.ReportSource = rptDocument;

                this.m_dw.InsertRow(0);
                this.m_dw.Modify("t_name.text = '" + this.m_bedManageVO.m_strNAME_VCHR + "'");
                this.m_dw.Modify("t_sex.text = '" + this.m_bedManageVO.m_strSEX_CHR + "'");
                this.m_dw.Modify("t_chargetype.text = '" + this.m_bedManageVO.m_strPAYTYPENAME_VCHR + "'");
                this.m_dw.Modify("t_inpatientid.text = '" + this.m_bedManageVO.m_strINPATIENTID_CHR + "'");
                this.m_dw.Modify("t_area.text = '" + this.m_leaveVO.m_strOutAreaName + "'");
                this.m_dw.Modify("t_bedno.text = '" + this.m_bedManageVO.m_strCODE_CHR + "'");
                
                string outDate = this.m_leaveVO.m_strOUTHOSPITAL_DAT;
                if (outDate != null)
                {
                    outDate = outDate.Substring(0, outDate.Length - 3);
                }
                this.m_dw.Modify("t_outdate.text = '" + outDate + " 出院" + "'");
                
                this.m_dw.Modify("t_diagnose.text = '" + this.m_leaveVO.m_strINS_DIAGNOSE_VCHR + "'");
                this.m_dw.Modify("t_doctor.text = '" + this.m_bedManageVO.m_strMAINDOC + "'");
                this.m_dw.Modify("t_operator.text = '" + this.m_leaveVO.m_strOperatorName + "'");
               // m_rptDocument.PrintToPrinter(1, true, 0, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "打印出院通知单失败");
                
            }
           
        }

        internal void m_cmdPrint_Click(object sender, EventArgs e)
        {
            //this.m_crReport.PrintReport();
            System.Windows.Forms.PrintDialog pDialog = new PrintDialog();

            //选择打印机
            if (pDialog.ShowDialog() == DialogResult.OK)
            {
                this.m_dw.PrintProperties.PrinterName = pDialog.PrinterSettings.PrinterName;
                this.m_dw.Print(false, false);

            }
        }

        private void m_cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_crReport_Load(object sender, EventArgs e)
        {

        }
    }
}