using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using iCareData;
using com.digitalwave.Utility.Controls;
using System.Data;
using HRP;
using PrivilegeData;
using com.digitalwave.clsCardiovascularTend_GXService;
using com.digitalwave.clsRecordsService;
using com.digitalwave.Emr.Signature_gui;

namespace iCare
{
	/// <summary>
	/// 心血管外科特护记录(广西)
	/// </summary>
	public class frmCardiovascularTendMain_GX : iCare.frmRecordsBase
	{
		#region 控件
     
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtWeight;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboAfterOpDays;
		protected com.digitalwave.Utility.Controls.ctlTimePicker m_dtpRecordDate;
		private PinkieControls.ButtonXP m_cmdSmallNightClassSign;
		private TextBox m_txtSmallNightClassSign;
		private PinkieControls.ButtonXP m_cmdBigNightClassSign;
		private TextBox m_txtBigNightClassSign;
		private TextBox m_txtLongClassSign;
		private PinkieControls.ButtonXP m_cmdLongClassSign;
		private PinkieControls.ButtonXP m_cmdOfficeSign;
		private TextBox m_txtOfficeSign;
		private System.Windows.Forms.DataGridTextBoxColumn m_clmRecordTime;
		private cltDataGridDSTRichTextBox m_dtcINFACT1;
		private cltDataGridDSTRichTextBox m_dtcINFACT2;
		private cltDataGridDSTRichTextBox m_dtcINFACT3;
		private cltDataGridDSTRichTextBox m_dtcINFACT4;
		private cltDataGridDSTRichTextBox m_dtcINFACT5;
		private cltDataGridDSTRichTextBox m_dtcINBLOOD;
		private cltDataGridDSTRichTextBox m_dtcINPERHOUR;
		private cltDataGridDSTRichTextBox m_dtcINSUM;
		private cltDataGridDSTRichTextBox m_dtcOUTSUM;
		private cltDataGridDSTRichTextBox m_dtcOUTPERHOUR;
		private cltDataGridDSTRichTextBox m_dtcOUTFACTPISSSUM;
		private cltDataGridDSTRichTextBox m_dtcOUTFACTPISS;
		private cltDataGridDSTRichTextBox m_dtcOUTFACTCHESTJUICE;
		private cltDataGridDSTRichTextBox m_dtcOUTFACTCHESTJUICESUM;
		private cltDataGridDSTRichTextBox m_dtcOUTFACTGASTRICJUICE;
		private cltDataGridDSTRichTextBox m_dtcEXPANDVASMEDICINE;
		private cltDataGridDSTRichTextBox m_dtcCARDIACDIURESIS;
		private cltDataGridDSTRichTextBox m_dtcOTHERMEDICINE;
		private cltDataGridDSTRichTextBox m_dtcCONSCIOUSNESS_PUPIL;
		private cltDataGridDSTRichTextBox m_dtcTEMPERATURE_TWIGTEMP;
		private cltDataGridDSTRichTextBox m_dtcHEARTRATE_RHYTHM;
		private cltDataGridDSTRichTextBox m_dtcBP_AVGBP;
		private cltDataGridDSTRichTextBox m_dtcCVP_LAP;
        private cltDataGridDSTRichTextBox m_dtcCVP_SPO;
		private cltDataGridDSTRichTextBox m_dtcBREATHMACHINE_DEPTH;
		private cltDataGridDSTRichTextBox m_dtcASSISTANT;
		private cltDataGridDSTRichTextBox m_dtcFio2_IE;
		private cltDataGridDSTRichTextBox m_dtcINSPIRATION_PEEP;
		private cltDataGridDSTRichTextBox m_dtcTV_VF;
		private cltDataGridDSTRichTextBox m_dtcBREATHTIMES;
		private cltDataGridDSTRichTextBox m_dtcBREATHVOICE;
		private cltDataGridDSTRichTextBox m_dtcGESTICULATION_PHYSICAL;
		private cltDataGridDSTRichTextBox m_dtcREMARK;
		private cltDataGridDSTRichTextBox m_dtcPHLEGM;
		private cltDataGridDSTRichTextBox m_dtcWBC;
		private cltDataGridDSTRichTextBox m_dtcHb;
		private cltDataGridDSTRichTextBox m_dtcRBC;
		private cltDataGridDSTRichTextBox m_dtcHCT;
		private cltDataGridDSTRichTextBox m_dtcPLT;
		private cltDataGridDSTRichTextBox m_dtcPH;
		private cltDataGridDSTRichTextBox m_dtcPCO2;
		private cltDataGridDSTRichTextBox m_dtcPAO2;
		private cltDataGridDSTRichTextBox m_dtcHCO3;
		private cltDataGridDSTRichTextBox m_dtcBE;
		private cltDataGridDSTRichTextBox m_dtcKPLUS;
		private cltDataGridDSTRichTextBox m_dtcNAPLUS;
		private cltDataGridDSTRichTextBox m_dtcCISUB;
		private cltDataGridDSTRichTextBox m_dtcCAPLUSPLUS;
		private cltDataGridDSTRichTextBox m_dtcGLU;
		private cltDataGridDSTRichTextBox m_dtcBUN;
		private cltDataGridDSTRichTextBox m_dtcUA;
		private cltDataGridDSTRichTextBox m_dtcANHYDRIDE;
		private cltDataGridDSTRichTextBox m_dtcCO2CP;
		private cltDataGridDSTRichTextBox m_dtcPT;
		private cltDataGridDSTRichTextBox m_dtcXRAYCHECK;
		private cltDataGridDSTRichTextBox m_dtcACT;
		private cltDataGridDSTRichTextBox m_dtcPROPORTION;
		private cltDataGridDSTRichTextBox m_dtcALBUMEN;
		private cltDataGridDSTRichTextBox m_dtcHIDDENBLOOD;
		private cltDataGridDSTRichTextBox m_dtcSKIN;
		private cltDataGridDSTRichTextBox m_dtcWASHPERINEUM;
		private cltDataGridDSTRichTextBox m_dtcBRUSHBATH;
		private cltDataGridDSTRichTextBox m_dtcMOUTHTEND;
		#endregion

        private com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
        private clsEmrSignToolCollection m_objSign;
		private DataTable dtTempTable;
		private string m_strCurrentOpenDate = DateTime.MinValue.ToString("yyyy-MM-dd HH:mm:ss");
		private string m_strCreateUserID = "";
        //private clsCardiovascularTend_GXService m_objServ;
		private clsCardiovascularBaseInfo_GX m_objCurrentContent;
        //private clsCardiovascularTend_GXMainService m_objMainServ;
        //private PinkieControls.ButtonXP m_cmdLoadAll;
		private bool m_blnIsInitDataTable = false;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboOpName;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboOpMedicine1;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboOpMedicine2;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboOpMedicine3;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboOpMedicine4;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboOpMedicine5;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmCardiovascularTendMain_GX()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			dtTempTable = new DataTable("RecordDetail");

            m_objSign = new clsEmrSignToolCollection();
            m_objSign.m_mthBindEmployeeSign(m_cmdLongClassSign, m_txtLongClassSign, 2, true, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdOfficeSign, m_txtOfficeSign, 2, true, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdSmallNightClassSign, m_txtSmallNightClassSign, 2, true, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdBigNightClassSign, m_txtBigNightClassSign, 2, true, clsEMRLogin.LoginInfo.m_strEmpID);
//			frmOutlookBar.s_OutlookBar.QuietMode = false;
            //m_objServ = new clsCardiovascularTend_GXService();
            //m_objMainServ = new clsCardiovascularTend_GXMainService();
			m_objCurrentContent = new clsCardiovascularBaseInfo_GX();

			m_mthAddCboDefaultItems();
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.m_txtWeight = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_cboAfterOpDays = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.m_dtpRecordDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.m_txtLongClassSign = new System.Windows.Forms.TextBox();
            this.m_cmdLongClassSign = new PinkieControls.ButtonXP();
            this.m_cmdOfficeSign = new PinkieControls.ButtonXP();
            this.m_txtOfficeSign = new System.Windows.Forms.TextBox();
            this.m_cmdSmallNightClassSign = new PinkieControls.ButtonXP();
            this.m_txtSmallNightClassSign = new System.Windows.Forms.TextBox();
            this.m_cmdBigNightClassSign = new PinkieControls.ButtonXP();
            this.m_txtBigNightClassSign = new System.Windows.Forms.TextBox();
            this.m_clmRecordTime = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_dtcINFACT1 = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcINFACT2 = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcINFACT3 = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcINFACT4 = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcINFACT5 = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcINBLOOD = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcINPERHOUR = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcINSUM = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcOUTSUM = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcOUTPERHOUR = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcOUTFACTPISSSUM = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcOUTFACTPISS = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcOUTFACTCHESTJUICE = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcOUTFACTCHESTJUICESUM = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcOUTFACTGASTRICJUICE = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcEXPANDVASMEDICINE = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcCARDIACDIURESIS = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcOTHERMEDICINE = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcCONSCIOUSNESS_PUPIL = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcTEMPERATURE_TWIGTEMP = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcHEARTRATE_RHYTHM = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcBP_AVGBP = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcCVP_LAP = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcCVP_SPO = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcBREATHMACHINE_DEPTH = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcASSISTANT = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcFio2_IE = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcINSPIRATION_PEEP = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcTV_VF = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcBREATHTIMES = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcBREATHVOICE = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcGESTICULATION_PHYSICAL = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcREMARK = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcPHLEGM = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcWBC = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcHb = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcRBC = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcHCT = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcPLT = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcPH = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcPCO2 = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcPAO2 = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcHCO3 = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcBE = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcKPLUS = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcNAPLUS = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcCISUB = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcCAPLUSPLUS = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcGLU = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcBUN = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcUA = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcANHYDRIDE = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcCO2CP = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcPT = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcXRAYCHECK = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcACT = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcPROPORTION = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcALBUMEN = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcHIDDENBLOOD = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcSKIN = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcWASHPERINEUM = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcBRUSHBATH = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcMOUTHTEND = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_cboOpName = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboOpMedicine1 = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboOpMedicine2 = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboOpMedicine3 = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboOpMedicine4 = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboOpMedicine5 = new com.digitalwave.Utility.Controls.ctlComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgRecordDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtbRecords)).BeginInit();
            this.m_pnlNewBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgtsStyles
            // 
            this.dgtsStyles.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																										 this.m_clmRecordTime,
																										 this.m_dtcINFACT1,
																										 this.m_dtcINFACT2,
																										 this.m_dtcINFACT3,
																										 this.m_dtcINFACT4,
																										 this.m_dtcINFACT5,
																										 this.m_dtcINBLOOD,
																										 this.m_dtcINPERHOUR,
																										 this.m_dtcINSUM,
																										 this.m_dtcOUTSUM,
																										 this.m_dtcOUTPERHOUR,
																										 this.m_dtcOUTFACTPISSSUM,
																										 this.m_dtcOUTFACTPISS,
																										 this.m_dtcOUTFACTCHESTJUICE,
																										 this.m_dtcOUTFACTCHESTJUICESUM,
																										 this.m_dtcOUTFACTGASTRICJUICE,
																										 this.m_dtcEXPANDVASMEDICINE,
																										 this.m_dtcCARDIACDIURESIS,
																										 this.m_dtcOTHERMEDICINE,
																										 this.m_dtcCONSCIOUSNESS_PUPIL,
																										 this.m_dtcTEMPERATURE_TWIGTEMP,
																										 this.m_dtcHEARTRATE_RHYTHM,
																										 this.m_dtcBP_AVGBP,
																										 this.m_dtcCVP_LAP,
                                                                                                         this.m_dtcCVP_SPO,
																										 this.m_dtcBREATHMACHINE_DEPTH,
																										 this.m_dtcASSISTANT,
																										 this.m_dtcFio2_IE,
																										 this.m_dtcINSPIRATION_PEEP,
																										 this.m_dtcTV_VF,
																										 this.m_dtcBREATHTIMES,
																										 this.m_dtcBREATHVOICE,
																										 this.m_dtcPHLEGM,
																										 this.m_dtcGESTICULATION_PHYSICAL,
																										 this.m_dtcREMARK,
																										 this.m_dtcWBC,
																										 this.m_dtcHb,
																										 this.m_dtcRBC,
																										 this.m_dtcHCT,
																										 this.m_dtcPLT,
																										 this.m_dtcPH,
																										 this.m_dtcPCO2,
																										 this.m_dtcPAO2,
																										 this.m_dtcHCO3,
																										 this.m_dtcBE,
																										 this.m_dtcKPLUS,
																										 this.m_dtcNAPLUS,
																										 this.m_dtcCISUB,
																										 this.m_dtcCAPLUSPLUS,
																										 this.m_dtcGLU,
																										 this.m_dtcBUN,
																										 this.m_dtcUA,
																										 this.m_dtcANHYDRIDE,
																										 this.m_dtcCO2CP,
																										 this.m_dtcPT,
																										 this.m_dtcXRAYCHECK,
																										 this.m_dtcACT,
																										 this.m_dtcPROPORTION,
																										 this.m_dtcALBUMEN,
																										 this.m_dtcHIDDENBLOOD,
																										 this.m_dtcSKIN,
																										 this.m_dtcWASHPERINEUM,
																										 this.m_dtcBRUSHBATH,
																										 this.m_dtcMOUTHTEND});
            this.dgtsStyles.PreferredRowHeight = 34;
            this.dgtsStyles.RowHeaderWidth = 15;
            // 
            // m_dtgRecordDetail
            // 
            this.m_dtgRecordDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_dtgRecordDetail.BackgroundColor = System.Drawing.SystemColors.AppWorkspace;
            this.m_dtgRecordDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_dtgRecordDetail.CaptionBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.m_dtgRecordDetail.DataSource = this.m_dtbRecords;
            this.m_dtgRecordDetail.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_dtgRecordDetail.HeaderForeColor = System.Drawing.SystemColors.Window;
            this.m_dtgRecordDetail.Location = new System.Drawing.Point(8, 117);
            this.m_dtgRecordDetail.Size = new System.Drawing.Size(968, 440);
            // 
            // mniAppend
            // 
            this.mniAppend.Click += new System.EventHandler(this.mniAppend_Click);
            // 
            // m_trvInPatientDate
            // 
            this.m_trvInPatientDate.BackColor = System.Drawing.Color.White;
            this.m_trvInPatientDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_trvInPatientDate.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_trvInPatientDate.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_trvInPatientDate.LineColor = System.Drawing.Color.Black;
            this.m_trvInPatientDate.Location = new System.Drawing.Point(8, 183);
            this.m_trvInPatientDate.Size = new System.Drawing.Size(192, 68);
            this.m_trvInPatientDate.Visible = false;
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(600, 211);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(688, 211);
            this.lblAge.Size = new System.Drawing.Size(80, 19);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(396, 183);
            this.lblBedNoTitle.Size = new System.Drawing.Size(63, 14);
            this.lblBedNoTitle.Text = "床  号：";
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(396, 211);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(560, 183);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(560, 211);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(648, 211);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(208, 211);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(414, 182);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(104, 104);
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(448, 209);
            this.txtInPatientID.Size = new System.Drawing.Size(108, 23);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(608, 181);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(448, 181);
            this.m_txtBedNO.Size = new System.Drawing.Size(80, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(248, 207);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(574, 150);
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(414, 154);
            this.m_lsvBedNO.Size = new System.Drawing.Size(100, 104);
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(248, 179);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(208, 183);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(664, 120);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.m_cmdNext.Location = new System.Drawing.Point(532, 181);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(156, 187);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(428, 13);
            this.m_lblForTitle.Visible = false;
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(662, 37);
            this.m_cmdModifyPatientInfo.Size = new System.Drawing.Size(69, 28);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Visible = true;
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            // 
            // m_txtWeight
            // 
            this.m_txtWeight.AccessibleDescription = "体重";
            this.m_txtWeight.BackColor = System.Drawing.Color.White;
            this.m_txtWeight.BorderColor = System.Drawing.Color.Transparent;
            this.m_txtWeight.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtWeight.ForeColor = System.Drawing.Color.Black;
            this.m_txtWeight.Location = new System.Drawing.Point(376, 39);
            this.m_txtWeight.Name = "m_txtWeight";
            this.m_txtWeight.Size = new System.Drawing.Size(48, 23);
            this.m_txtWeight.TabIndex = 10000007;
            this.m_txtWeight.Leave += new System.EventHandler(this.m_txtWeight_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(336, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 10000006;
            this.label1.Text = "体重:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(430, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 10000006;
            this.label2.Text = "Kg";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(459, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 10000006;
            this.label3.Text = "手术后";
            // 
            // m_cboAfterOpDays
            // 
            this.m_cboAfterOpDays.AccessibleDescription = "手术后天数";
            this.m_cboAfterOpDays.BorderColor = System.Drawing.Color.Black;
            this.m_cboAfterOpDays.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboAfterOpDays.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboAfterOpDays.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboAfterOpDays.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboAfterOpDays.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboAfterOpDays.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboAfterOpDays.ListBackColor = System.Drawing.Color.White;
            this.m_cboAfterOpDays.ListForeColor = System.Drawing.Color.Black;
            this.m_cboAfterOpDays.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
            this.m_cboAfterOpDays.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
            this.m_cboAfterOpDays.Location = new System.Drawing.Point(509, 40);
            this.m_cboAfterOpDays.m_BlnEnableItemEventMenu = false;
            this.m_cboAfterOpDays.Name = "m_cboAfterOpDays";
            this.m_cboAfterOpDays.SelectedIndex = -1;
            this.m_cboAfterOpDays.SelectedItem = null;
            this.m_cboAfterOpDays.SelectionStart = 0;
            this.m_cboAfterOpDays.Size = new System.Drawing.Size(88, 23);
            this.m_cboAfterOpDays.TabIndex = 10000202;
            this.m_cboAfterOpDays.Tag = "";
            this.m_cboAfterOpDays.TextBackColor = System.Drawing.Color.White;
            this.m_cboAfterOpDays.TextForeColor = System.Drawing.Color.Black;
            this.m_cboAfterOpDays.SelectedIndexChanged += new System.EventHandler(this.m_cboAfterOpDays_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(598, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 14);
            this.label4.TabIndex = 10000006;
            this.label4.Text = "天";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 14);
            this.label5.TabIndex = 10000006;
            this.label5.Text = "手术名称:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 14);
            this.label6.TabIndex = 10000006;
            this.label6.Text = "1.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(152, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 14);
            this.label7.TabIndex = 10000006;
            this.label7.Text = "2.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(296, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 14);
            this.label8.TabIndex = 10000006;
            this.label8.Text = "3.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(440, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 14);
            this.label9.TabIndex = 10000006;
            this.label9.Text = "4.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(584, 96);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 14);
            this.label10.TabIndex = 10000006;
            this.label10.Text = "5.";
            // 
            // m_dtpRecordDate
            // 
            this.m_dtpRecordDate.AccessibleDescription = "记录日期";
            this.m_dtpRecordDate.BackColor = System.Drawing.SystemColors.Control;
            this.m_dtpRecordDate.BorderColor = System.Drawing.Color.Black;
            this.m_dtpRecordDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpRecordDate.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_dtpRecordDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpRecordDate.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpRecordDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpRecordDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpRecordDate.ForeColor = System.Drawing.Color.Black;
            this.m_dtpRecordDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpRecordDate.Location = new System.Drawing.Point(780, 92);
            this.m_dtpRecordDate.m_BlnOnlyTime = false;
            this.m_dtpRecordDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpRecordDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpRecordDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpRecordDate.Name = "m_dtpRecordDate";
            this.m_dtpRecordDate.ReadOnly = false;
            this.m_dtpRecordDate.Size = new System.Drawing.Size(144, 22);
            this.m_dtpRecordDate.TabIndex = 10000256;
            this.m_dtpRecordDate.Tag = "1";
            this.m_dtpRecordDate.TextBackColor = System.Drawing.Color.White;
            this.m_dtpRecordDate.TextForeColor = System.Drawing.Color.Black;
            this.m_dtpRecordDate.evtValueChanged += new System.EventHandler(this.m_dtpRecordDate_evtValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(732, 95);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 14);
            this.label11.TabIndex = 10000006;
            this.label11.Text = "日期:";
            // 
            // m_txtLongClassSign
            // 
            this.m_txtLongClassSign.AccessibleDescription = "长班签名";
            this.m_txtLongClassSign.AccessibleName = "NoDefault";
            this.m_txtLongClassSign.BackColor = System.Drawing.Color.White;
            this.m_txtLongClassSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtLongClassSign.ForeColor = System.Drawing.Color.Black;
            this.m_txtLongClassSign.Location = new System.Drawing.Point(256, 563);
            this.m_txtLongClassSign.Name = "m_txtLongClassSign";
            this.m_txtLongClassSign.ReadOnly = true;
            this.m_txtLongClassSign.Size = new System.Drawing.Size(92, 23);
            this.m_txtLongClassSign.TabIndex = 10000385;
            this.m_txtLongClassSign.Tag = "";
            // 
            // m_cmdLongClassSign
            // 
            this.m_cmdLongClassSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdLongClassSign.DefaultScheme = true;
            this.m_cmdLongClassSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdLongClassSign.ForeColor = System.Drawing.Color.Black;
            this.m_cmdLongClassSign.Hint = "";
            this.m_cmdLongClassSign.Location = new System.Drawing.Point(176, 560);
            this.m_cmdLongClassSign.Name = "m_cmdLongClassSign";
            this.m_cmdLongClassSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdLongClassSign.Size = new System.Drawing.Size(76, 28);
            this.m_cmdLongClassSign.TabIndex = 10000386;
            this.m_cmdLongClassSign.Text = "长班签名:";
            // 
            // m_cmdOfficeSign
            // 
            this.m_cmdOfficeSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdOfficeSign.DefaultScheme = true;
            this.m_cmdOfficeSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdOfficeSign.ForeColor = System.Drawing.Color.Black;
            this.m_cmdOfficeSign.Hint = "";
            this.m_cmdOfficeSign.Location = new System.Drawing.Point(368, 560);
            this.m_cmdOfficeSign.Name = "m_cmdOfficeSign";
            this.m_cmdOfficeSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdOfficeSign.Size = new System.Drawing.Size(84, 28);
            this.m_cmdOfficeSign.TabIndex = 10000386;
            this.m_cmdOfficeSign.Text = "办公室签名:";
            // 
            // m_txtOfficeSign
            // 
            this.m_txtOfficeSign.AccessibleDescription = "办公室签名";
            this.m_txtOfficeSign.AccessibleName = "NoDefault";
            this.m_txtOfficeSign.BackColor = System.Drawing.Color.White;
            this.m_txtOfficeSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOfficeSign.ForeColor = System.Drawing.Color.Black;
            this.m_txtOfficeSign.Location = new System.Drawing.Point(456, 563);
            this.m_txtOfficeSign.Name = "m_txtOfficeSign";
            this.m_txtOfficeSign.ReadOnly = true;
            this.m_txtOfficeSign.Size = new System.Drawing.Size(92, 23);
            this.m_txtOfficeSign.TabIndex = 10000385;
            this.m_txtOfficeSign.Tag = "";
            // 
            // m_cmdSmallNightClassSign
            // 
            this.m_cmdSmallNightClassSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdSmallNightClassSign.DefaultScheme = true;
            this.m_cmdSmallNightClassSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSmallNightClassSign.ForeColor = System.Drawing.Color.Black;
            this.m_cmdSmallNightClassSign.Hint = "";
            this.m_cmdSmallNightClassSign.Location = new System.Drawing.Point(624, 560);
            this.m_cmdSmallNightClassSign.Name = "m_cmdSmallNightClassSign";
            this.m_cmdSmallNightClassSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSmallNightClassSign.Size = new System.Drawing.Size(100, 28);
            this.m_cmdSmallNightClassSign.TabIndex = 10000386;
            this.m_cmdSmallNightClassSign.Text = "夜班签名(小):";
            // 
            // m_txtSmallNightClassSign
            // 
            this.m_txtSmallNightClassSign.AccessibleDescription = "夜班签名(小)";
            this.m_txtSmallNightClassSign.AccessibleName = "NoDefault";
            this.m_txtSmallNightClassSign.BackColor = System.Drawing.Color.White;
            this.m_txtSmallNightClassSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSmallNightClassSign.ForeColor = System.Drawing.Color.Black;
            this.m_txtSmallNightClassSign.Location = new System.Drawing.Point(724, 563);
            this.m_txtSmallNightClassSign.Name = "m_txtSmallNightClassSign";
            this.m_txtSmallNightClassSign.ReadOnly = true;
            this.m_txtSmallNightClassSign.Size = new System.Drawing.Size(92, 23);
            this.m_txtSmallNightClassSign.TabIndex = 10000385;
            this.m_txtSmallNightClassSign.Tag = "";
            // 
            // m_cmdBigNightClassSign
            // 
            this.m_cmdBigNightClassSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdBigNightClassSign.DefaultScheme = true;
            this.m_cmdBigNightClassSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdBigNightClassSign.ForeColor = System.Drawing.Color.Black;
            this.m_cmdBigNightClassSign.Hint = "";
            this.m_cmdBigNightClassSign.Location = new System.Drawing.Point(832, 560);
            this.m_cmdBigNightClassSign.Name = "m_cmdBigNightClassSign";
            this.m_cmdBigNightClassSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdBigNightClassSign.Size = new System.Drawing.Size(44, 28);
            this.m_cmdBigNightClassSign.TabIndex = 10000386;
            this.m_cmdBigNightClassSign.Text = "(大):";
            // 
            // m_txtBigNightClassSign
            // 
            this.m_txtBigNightClassSign.AccessibleDescription = "夜班签名(大)";
            this.m_txtBigNightClassSign.AccessibleName = "NoDefault";
            this.m_txtBigNightClassSign.BackColor = System.Drawing.Color.White;
            this.m_txtBigNightClassSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBigNightClassSign.ForeColor = System.Drawing.Color.Black;
            this.m_txtBigNightClassSign.Location = new System.Drawing.Point(876, 563);
            this.m_txtBigNightClassSign.Name = "m_txtBigNightClassSign";
            this.m_txtBigNightClassSign.ReadOnly = true;
            this.m_txtBigNightClassSign.Size = new System.Drawing.Size(92, 23);
            this.m_txtBigNightClassSign.TabIndex = 10000385;
            this.m_txtBigNightClassSign.Tag = "";
            // 
            // m_clmRecordTime
            // 
            this.m_clmRecordTime.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_clmRecordTime.Format = "";
            this.m_clmRecordTime.FormatInfo = null;
            this.m_clmRecordTime.MappingName = "RecordTime";
            this.m_clmRecordTime.Width = 60;
            // 
            // m_dtcINFACT1
            // 
            this.m_dtcINFACT1.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcINFACT1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcINFACT1.m_BlnGobleSet = true;
            this.m_dtcINFACT1.m_BlnUnderLineDST = false;
            this.m_dtcINFACT1.MappingName = "INFACT1";
            this.m_dtcINFACT1.Width = 60;
            // 
            // m_dtcINFACT2
            // 
            this.m_dtcINFACT2.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcINFACT2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcINFACT2.m_BlnGobleSet = true;
            this.m_dtcINFACT2.m_BlnUnderLineDST = false;
            this.m_dtcINFACT2.MappingName = "INFACT2";
            this.m_dtcINFACT2.Width = 60;
            // 
            // m_dtcINFACT3
            // 
            this.m_dtcINFACT3.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcINFACT3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcINFACT3.m_BlnGobleSet = true;
            this.m_dtcINFACT3.m_BlnUnderLineDST = false;
            this.m_dtcINFACT3.MappingName = "INFACT3";
            this.m_dtcINFACT3.Width = 60;
            // 
            // m_dtcINFACT4
            // 
            this.m_dtcINFACT4.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcINFACT4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcINFACT4.m_BlnGobleSet = true;
            this.m_dtcINFACT4.m_BlnUnderLineDST = false;
            this.m_dtcINFACT4.MappingName = "INFACT4";
            this.m_dtcINFACT4.Width = 60;
            // 
            // m_dtcINFACT5
            // 
            this.m_dtcINFACT5.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcINFACT5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcINFACT5.m_BlnGobleSet = true;
            this.m_dtcINFACT5.m_BlnUnderLineDST = false;
            this.m_dtcINFACT5.MappingName = "INFACT5";
            this.m_dtcINFACT5.Width = 60;
            // 
            // m_dtcINBLOOD
            // 
            this.m_dtcINBLOOD.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcINBLOOD.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcINBLOOD.m_BlnGobleSet = true;
            this.m_dtcINBLOOD.m_BlnUnderLineDST = false;
            this.m_dtcINBLOOD.MappingName = "INBLOOD";
            this.m_dtcINBLOOD.Width = 60;
            // 
            // m_dtcINPERHOUR
            // 
            this.m_dtcINPERHOUR.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcINPERHOUR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcINPERHOUR.m_BlnGobleSet = true;
            this.m_dtcINPERHOUR.m_BlnUnderLineDST = false;
            this.m_dtcINPERHOUR.MappingName = "INPERHOUR";
            this.m_dtcINPERHOUR.Width = 60;
            // 
            // m_dtcINSUM
            // 
            this.m_dtcINSUM.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcINSUM.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcINSUM.m_BlnGobleSet = true;
            this.m_dtcINSUM.m_BlnUnderLineDST = false;
            this.m_dtcINSUM.MappingName = "INSUM";
            this.m_dtcINSUM.Width = 60;
            // 
            // m_dtcOUTSUM
            // 
            this.m_dtcOUTSUM.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcOUTSUM.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcOUTSUM.m_BlnGobleSet = true;
            this.m_dtcOUTSUM.m_BlnUnderLineDST = false;
            this.m_dtcOUTSUM.MappingName = "OUTSUM";
            this.m_dtcOUTSUM.Width = 60;
            // 
            // m_dtcOUTPERHOUR
            // 
            this.m_dtcOUTPERHOUR.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcOUTPERHOUR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcOUTPERHOUR.m_BlnGobleSet = true;
            this.m_dtcOUTPERHOUR.m_BlnUnderLineDST = false;
            this.m_dtcOUTPERHOUR.MappingName = "OUTPERHOUR";
            this.m_dtcOUTPERHOUR.Width = 60;
            // 
            // m_dtcOUTFACTPISSSUM
            // 
            this.m_dtcOUTFACTPISSSUM.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcOUTFACTPISSSUM.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcOUTFACTPISSSUM.m_BlnGobleSet = true;
            this.m_dtcOUTFACTPISSSUM.m_BlnUnderLineDST = false;
            this.m_dtcOUTFACTPISSSUM.MappingName = "OUTFACTPISSSUM";
            this.m_dtcOUTFACTPISSSUM.Width = 60;
            // 
            // m_dtcOUTFACTPISS
            // 
            this.m_dtcOUTFACTPISS.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcOUTFACTPISS.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcOUTFACTPISS.m_BlnGobleSet = true;
            this.m_dtcOUTFACTPISS.m_BlnUnderLineDST = false;
            this.m_dtcOUTFACTPISS.MappingName = "OUTFACTPISS";
            this.m_dtcOUTFACTPISS.Width = 60;
            // 
            // m_dtcOUTFACTCHESTJUICE
            // 
            this.m_dtcOUTFACTCHESTJUICE.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcOUTFACTCHESTJUICE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcOUTFACTCHESTJUICE.m_BlnGobleSet = true;
            this.m_dtcOUTFACTCHESTJUICE.m_BlnUnderLineDST = false;
            this.m_dtcOUTFACTCHESTJUICE.MappingName = "OUTFACTCHESTJUICE";
            this.m_dtcOUTFACTCHESTJUICE.Width = 60;
            // 
            // m_dtcOUTFACTCHESTJUICESUM
            // 
            this.m_dtcOUTFACTCHESTJUICESUM.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcOUTFACTCHESTJUICESUM.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcOUTFACTCHESTJUICESUM.m_BlnGobleSet = true;
            this.m_dtcOUTFACTCHESTJUICESUM.m_BlnUnderLineDST = false;
            this.m_dtcOUTFACTCHESTJUICESUM.MappingName = "OUTFACTCHESTJUICESUM";
            this.m_dtcOUTFACTCHESTJUICESUM.Width = 60;
            // 
            // m_dtcOUTFACTGASTRICJUICE
            // 
            this.m_dtcOUTFACTGASTRICJUICE.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcOUTFACTGASTRICJUICE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcOUTFACTGASTRICJUICE.m_BlnGobleSet = true;
            this.m_dtcOUTFACTGASTRICJUICE.m_BlnUnderLineDST = false;
            this.m_dtcOUTFACTGASTRICJUICE.MappingName = "OUTFACTGASTRICJUICE";
            this.m_dtcOUTFACTGASTRICJUICE.Width = 60;
            // 
            // m_dtcEXPANDVASMEDICINE
            // 
            this.m_dtcEXPANDVASMEDICINE.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcEXPANDVASMEDICINE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcEXPANDVASMEDICINE.m_BlnGobleSet = true;
            this.m_dtcEXPANDVASMEDICINE.m_BlnUnderLineDST = false;
            this.m_dtcEXPANDVASMEDICINE.MappingName = "EXPANDVASMEDICINE";
            this.m_dtcEXPANDVASMEDICINE.Width = 80;
            // 
            // m_dtcCARDIACDIURESIS
            // 
            this.m_dtcCARDIACDIURESIS.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcCARDIACDIURESIS.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcCARDIACDIURESIS.m_BlnGobleSet = true;
            this.m_dtcCARDIACDIURESIS.m_BlnUnderLineDST = false;
            this.m_dtcCARDIACDIURESIS.MappingName = "CARDIACDIURESIS";
            this.m_dtcCARDIACDIURESIS.Width = 80;
            // 
            // m_dtcOTHERMEDICINE
            // 
            this.m_dtcOTHERMEDICINE.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcOTHERMEDICINE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcOTHERMEDICINE.m_BlnGobleSet = true;
            this.m_dtcOTHERMEDICINE.m_BlnUnderLineDST = false;
            this.m_dtcOTHERMEDICINE.MappingName = "OTHERMEDICINE";
            this.m_dtcOTHERMEDICINE.Width = 80;
            // 
            // m_dtcCONSCIOUSNESS_PUPIL
            // 
            this.m_dtcCONSCIOUSNESS_PUPIL.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcCONSCIOUSNESS_PUPIL.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcCONSCIOUSNESS_PUPIL.m_BlnGobleSet = true;
            this.m_dtcCONSCIOUSNESS_PUPIL.m_BlnUnderLineDST = false;
            this.m_dtcCONSCIOUSNESS_PUPIL.MappingName = "CONSCIOUSNESS_PUPIL";
            this.m_dtcCONSCIOUSNESS_PUPIL.Width = 80;
            // 
            // m_dtcTEMPERATURE_TWIGTEMP
            // 
            this.m_dtcTEMPERATURE_TWIGTEMP.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcTEMPERATURE_TWIGTEMP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcTEMPERATURE_TWIGTEMP.m_BlnGobleSet = true;
            this.m_dtcTEMPERATURE_TWIGTEMP.m_BlnUnderLineDST = false;
            this.m_dtcTEMPERATURE_TWIGTEMP.MappingName = "TEMPERATURE_TWIGTEMP";
            this.m_dtcTEMPERATURE_TWIGTEMP.Width = 60;
            // 
            // m_dtcHEARTRATE_RHYTHM
            // 
            this.m_dtcHEARTRATE_RHYTHM.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcHEARTRATE_RHYTHM.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcHEARTRATE_RHYTHM.m_BlnGobleSet = true;
            this.m_dtcHEARTRATE_RHYTHM.m_BlnUnderLineDST = false;
            this.m_dtcHEARTRATE_RHYTHM.MappingName = "HEARTRATE_RHYTHM";
            this.m_dtcHEARTRATE_RHYTHM.Width = 60;
            // 
            // m_dtcBP_AVGBP
            // 
            this.m_dtcBP_AVGBP.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcBP_AVGBP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcBP_AVGBP.m_BlnGobleSet = true;
            this.m_dtcBP_AVGBP.m_BlnUnderLineDST = false;
            this.m_dtcBP_AVGBP.MappingName = "BP_AVGBP";
            this.m_dtcBP_AVGBP.Width = 60;
            // 
            // m_dtcCVP_LAP
            // 
            this.m_dtcCVP_LAP.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcCVP_LAP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcCVP_LAP.m_BlnGobleSet = true;
            this.m_dtcCVP_LAP.m_BlnUnderLineDST = false;
            this.m_dtcCVP_LAP.MappingName = "CVP_LAP";
            this.m_dtcCVP_LAP.Width = 60;
            // 
            // m_dtcCVP_SPO
            // 
            this.m_dtcCVP_SPO.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcCVP_SPO.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcCVP_SPO.m_BlnGobleSet = true;
            this.m_dtcCVP_SPO.m_BlnUnderLineDST = false;
            this.m_dtcCVP_SPO.MappingName = "CVP_SPO";
            this.m_dtcCVP_SPO.Width = 60;
            // 
            // m_dtcBREATHMACHINE_DEPTH
            // 
            this.m_dtcBREATHMACHINE_DEPTH.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcBREATHMACHINE_DEPTH.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcBREATHMACHINE_DEPTH.m_BlnGobleSet = true;
            this.m_dtcBREATHMACHINE_DEPTH.m_BlnUnderLineDST = false;
            this.m_dtcBREATHMACHINE_DEPTH.MappingName = "BREATHMACHINE_DEPTH";
            this.m_dtcBREATHMACHINE_DEPTH.Width = 60;
            // 
            // m_dtcASSISTANT
            // 
            this.m_dtcASSISTANT.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcASSISTANT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcASSISTANT.m_BlnGobleSet = true;
            this.m_dtcASSISTANT.m_BlnUnderLineDST = false;
            this.m_dtcASSISTANT.MappingName = "ASSISTANT";
            this.m_dtcASSISTANT.Width = 60;
            // 
            // m_dtcFio2_IE
            // 
            this.m_dtcFio2_IE.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcFio2_IE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcFio2_IE.m_BlnGobleSet = true;
            this.m_dtcFio2_IE.m_BlnUnderLineDST = false;
            this.m_dtcFio2_IE.MappingName = "Fio2_IE";
            this.m_dtcFio2_IE.Width = 60;
            // 
            // m_dtcINSPIRATION_PEEP
            // 
            this.m_dtcINSPIRATION_PEEP.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcINSPIRATION_PEEP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcINSPIRATION_PEEP.m_BlnGobleSet = true;
            this.m_dtcINSPIRATION_PEEP.m_BlnUnderLineDST = false;
            this.m_dtcINSPIRATION_PEEP.MappingName = "INSPIRATION_PEEP";
            this.m_dtcINSPIRATION_PEEP.Width = 60;
            // 
            // m_dtcTV_VF
            // 
            this.m_dtcTV_VF.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcTV_VF.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcTV_VF.m_BlnGobleSet = true;
            this.m_dtcTV_VF.m_BlnUnderLineDST = false;
            this.m_dtcTV_VF.MappingName = "TV_VF";
            this.m_dtcTV_VF.Width = 60;
            // 
            // m_dtcBREATHTIMES
            // 
            this.m_dtcBREATHTIMES.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcBREATHTIMES.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcBREATHTIMES.m_BlnGobleSet = true;
            this.m_dtcBREATHTIMES.m_BlnUnderLineDST = false;
            this.m_dtcBREATHTIMES.MappingName = "BREATHTIMES";
            this.m_dtcBREATHTIMES.Width = 60;
            // 
            // m_dtcBREATHVOICE
            // 
            this.m_dtcBREATHVOICE.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcBREATHVOICE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcBREATHVOICE.m_BlnGobleSet = true;
            this.m_dtcBREATHVOICE.m_BlnUnderLineDST = false;
            this.m_dtcBREATHVOICE.MappingName = "BREATHVOICE";
            this.m_dtcBREATHVOICE.Width = 60;
            // 
            // m_dtcGESTICULATION_PHYSICAL
            // 
            this.m_dtcGESTICULATION_PHYSICAL.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcGESTICULATION_PHYSICAL.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcGESTICULATION_PHYSICAL.m_BlnGobleSet = true;
            this.m_dtcGESTICULATION_PHYSICAL.m_BlnUnderLineDST = false;
            this.m_dtcGESTICULATION_PHYSICAL.MappingName = "GESTICULATION_PHYSICAL";
            this.m_dtcGESTICULATION_PHYSICAL.Width = 60;
            // 
            // m_dtcREMARK
            // 
            this.m_dtcREMARK.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcREMARK.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcREMARK.m_BlnGobleSet = true;
            this.m_dtcREMARK.m_BlnUnderLineDST = false;
            this.m_dtcREMARK.MappingName = "REMARK";
            this.m_dtcREMARK.Width = 250;
            // 
            // m_dtcPHLEGM
            // 
            this.m_dtcPHLEGM.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcPHLEGM.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcPHLEGM.m_BlnGobleSet = true;
            this.m_dtcPHLEGM.m_BlnUnderLineDST = false;
            this.m_dtcPHLEGM.MappingName = "PHLEGM";
            this.m_dtcPHLEGM.Width = 60;
            // 
            // m_dtcWBC
            // 
            this.m_dtcWBC.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcWBC.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcWBC.m_BlnGobleSet = true;
            this.m_dtcWBC.m_BlnUnderLineDST = false;
            this.m_dtcWBC.MappingName = "WBC";
            this.m_dtcWBC.Width = 60;
            // 
            // m_dtcHb
            // 
            this.m_dtcHb.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcHb.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcHb.m_BlnGobleSet = true;
            this.m_dtcHb.m_BlnUnderLineDST = false;
            this.m_dtcHb.MappingName = "Hb";
            this.m_dtcHb.Width = 60;
            // 
            // m_dtcRBC
            // 
            this.m_dtcRBC.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcRBC.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcRBC.m_BlnGobleSet = true;
            this.m_dtcRBC.m_BlnUnderLineDST = false;
            this.m_dtcRBC.MappingName = "RBC";
            this.m_dtcRBC.Width = 60;
            // 
            // m_dtcHCT
            // 
            this.m_dtcHCT.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcHCT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcHCT.m_BlnGobleSet = true;
            this.m_dtcHCT.m_BlnUnderLineDST = false;
            this.m_dtcHCT.MappingName = "HCT";
            this.m_dtcHCT.Width = 60;
            // 
            // m_dtcPLT
            // 
            this.m_dtcPLT.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcPLT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcPLT.m_BlnGobleSet = true;
            this.m_dtcPLT.m_BlnUnderLineDST = false;
            this.m_dtcPLT.MappingName = "PLT";
            this.m_dtcPLT.Width = 60;
            // 
            // m_dtcPH
            // 
            this.m_dtcPH.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcPH.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcPH.m_BlnGobleSet = true;
            this.m_dtcPH.m_BlnUnderLineDST = false;
            this.m_dtcPH.MappingName = "PH";
            this.m_dtcPH.Width = 60;
            // 
            // m_dtcPCO2
            // 
            this.m_dtcPCO2.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcPCO2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcPCO2.m_BlnGobleSet = true;
            this.m_dtcPCO2.m_BlnUnderLineDST = false;
            this.m_dtcPCO2.MappingName = "PCO2";
            this.m_dtcPCO2.Width = 60;
            // 
            // m_dtcPAO2
            // 
            this.m_dtcPAO2.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcPAO2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcPAO2.m_BlnGobleSet = true;
            this.m_dtcPAO2.m_BlnUnderLineDST = false;
            this.m_dtcPAO2.MappingName = "PAO2";
            this.m_dtcPAO2.Width = 60;
            // 
            // m_dtcHCO3
            // 
            this.m_dtcHCO3.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcHCO3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcHCO3.m_BlnGobleSet = true;
            this.m_dtcHCO3.m_BlnUnderLineDST = false;
            this.m_dtcHCO3.MappingName = "HCO3";
            this.m_dtcHCO3.Width = 60;
            // 
            // m_dtcBE
            // 
            this.m_dtcBE.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcBE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcBE.m_BlnGobleSet = true;
            this.m_dtcBE.m_BlnUnderLineDST = false;
            this.m_dtcBE.MappingName = "BE";
            this.m_dtcBE.Width = 60;
            // 
            // m_dtcKPLUS
            // 
            this.m_dtcKPLUS.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcKPLUS.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcKPLUS.m_BlnGobleSet = true;
            this.m_dtcKPLUS.m_BlnUnderLineDST = false;
            this.m_dtcKPLUS.MappingName = "KPLUS";
            this.m_dtcKPLUS.Width = 60;
            // 
            // m_dtcNAPLUS
            // 
            this.m_dtcNAPLUS.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcNAPLUS.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcNAPLUS.m_BlnGobleSet = true;
            this.m_dtcNAPLUS.m_BlnUnderLineDST = false;
            this.m_dtcNAPLUS.MappingName = "NAPLUS";
            this.m_dtcNAPLUS.Width = 60;
            // 
            // m_dtcCISUB
            // 
            this.m_dtcCISUB.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcCISUB.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcCISUB.m_BlnGobleSet = true;
            this.m_dtcCISUB.m_BlnUnderLineDST = false;
            this.m_dtcCISUB.MappingName = "CISUB";
            this.m_dtcCISUB.Width = 60;
            // 
            // m_dtcCAPLUSPLUS
            // 
            this.m_dtcCAPLUSPLUS.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcCAPLUSPLUS.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcCAPLUSPLUS.m_BlnGobleSet = true;
            this.m_dtcCAPLUSPLUS.m_BlnUnderLineDST = false;
            this.m_dtcCAPLUSPLUS.MappingName = "CAPLUSPLUS";
            this.m_dtcCAPLUSPLUS.Width = 60;
            // 
            // m_dtcGLU
            // 
            this.m_dtcGLU.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcGLU.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcGLU.m_BlnGobleSet = true;
            this.m_dtcGLU.m_BlnUnderLineDST = false;
            this.m_dtcGLU.MappingName = "GLU";
            this.m_dtcGLU.Width = 60;
            // 
            // m_dtcBUN
            // 
            this.m_dtcBUN.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcBUN.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcBUN.m_BlnGobleSet = true;
            this.m_dtcBUN.m_BlnUnderLineDST = false;
            this.m_dtcBUN.MappingName = "BUN";
            this.m_dtcBUN.Width = 60;
            // 
            // m_dtcUA
            // 
            this.m_dtcUA.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcUA.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcUA.m_BlnGobleSet = true;
            this.m_dtcUA.m_BlnUnderLineDST = false;
            this.m_dtcUA.MappingName = "UA";
            this.m_dtcUA.Width = 60;
            // 
            // m_dtcANHYDRIDE
            // 
            this.m_dtcANHYDRIDE.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcANHYDRIDE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcANHYDRIDE.m_BlnGobleSet = true;
            this.m_dtcANHYDRIDE.m_BlnUnderLineDST = false;
            this.m_dtcANHYDRIDE.MappingName = "ANHYDRIDE";
            this.m_dtcANHYDRIDE.Width = 60;
            // 
            // m_dtcCO2CP
            // 
            this.m_dtcCO2CP.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcCO2CP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcCO2CP.m_BlnGobleSet = true;
            this.m_dtcCO2CP.m_BlnUnderLineDST = false;
            this.m_dtcCO2CP.MappingName = "CO2CP";
            this.m_dtcCO2CP.Width = 60;
            // 
            // m_dtcPT
            // 
            this.m_dtcPT.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcPT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcPT.m_BlnGobleSet = true;
            this.m_dtcPT.m_BlnUnderLineDST = false;
            this.m_dtcPT.MappingName = "PT";
            this.m_dtcPT.Width = 60;
            // 
            // m_dtcXRAYCHECK
            // 
            this.m_dtcXRAYCHECK.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcXRAYCHECK.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcXRAYCHECK.m_BlnGobleSet = true;
            this.m_dtcXRAYCHECK.m_BlnUnderLineDST = false;
            this.m_dtcXRAYCHECK.MappingName = "XRAYCHECK";
            this.m_dtcXRAYCHECK.Width = 80;
            // 
            // m_dtcACT
            // 
            this.m_dtcACT.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcACT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcACT.m_BlnGobleSet = true;
            this.m_dtcACT.m_BlnUnderLineDST = false;
            this.m_dtcACT.MappingName = "ACT";
            this.m_dtcACT.Width = 60;
            // 
            // m_dtcPROPORTION
            // 
            this.m_dtcPROPORTION.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcPROPORTION.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcPROPORTION.m_BlnGobleSet = true;
            this.m_dtcPROPORTION.m_BlnUnderLineDST = false;
            this.m_dtcPROPORTION.MappingName = "PROPORTION";
            this.m_dtcPROPORTION.Width = 60;
            // 
            // m_dtcALBUMEN
            // 
            this.m_dtcALBUMEN.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcALBUMEN.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcALBUMEN.m_BlnGobleSet = true;
            this.m_dtcALBUMEN.m_BlnUnderLineDST = false;
            this.m_dtcALBUMEN.MappingName = "ALBUMEN";
            this.m_dtcALBUMEN.Width = 60;
            // 
            // m_dtcHIDDENBLOOD
            // 
            this.m_dtcHIDDENBLOOD.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcHIDDENBLOOD.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcHIDDENBLOOD.m_BlnGobleSet = true;
            this.m_dtcHIDDENBLOOD.m_BlnUnderLineDST = false;
            this.m_dtcHIDDENBLOOD.MappingName = "HIDDENBLOOD";
            this.m_dtcHIDDENBLOOD.Width = 60;
            // 
            // m_dtcSKIN
            // 
            this.m_dtcSKIN.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcSKIN.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcSKIN.m_BlnGobleSet = true;
            this.m_dtcSKIN.m_BlnUnderLineDST = false;
            this.m_dtcSKIN.MappingName = "SKIN";
            this.m_dtcSKIN.Width = 60;
            // 
            // m_dtcWASHPERINEUM
            // 
            this.m_dtcWASHPERINEUM.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcWASHPERINEUM.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcWASHPERINEUM.m_BlnGobleSet = true;
            this.m_dtcWASHPERINEUM.m_BlnUnderLineDST = false;
            this.m_dtcWASHPERINEUM.MappingName = "WASHPERINEUM";
            this.m_dtcWASHPERINEUM.Width = 60;
            // 
            // m_dtcBRUSHBATH
            // 
            this.m_dtcBRUSHBATH.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcBRUSHBATH.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcBRUSHBATH.m_BlnGobleSet = true;
            this.m_dtcBRUSHBATH.m_BlnUnderLineDST = false;
            this.m_dtcBRUSHBATH.MappingName = "BRUSHBATH";
            this.m_dtcBRUSHBATH.Width = 60;
            // 
            // m_dtcMOUTHTEND
            // 
            this.m_dtcMOUTHTEND.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcMOUTHTEND.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcMOUTHTEND.m_BlnGobleSet = true;
            this.m_dtcMOUTHTEND.m_BlnUnderLineDST = false;
            this.m_dtcMOUTHTEND.MappingName = "MOUTHTEND";
            this.m_dtcMOUTHTEND.Width = 60;
            // 
            // m_cboOpName
            // 
            this.m_cboOpName.AccessibleDescription = "手术名称";
            this.m_cboOpName.BackColor = System.Drawing.Color.White;
            this.m_cboOpName.BorderColor = System.Drawing.Color.Black;
            this.m_cboOpName.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboOpName.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboOpName.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboOpName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboOpName.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboOpName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboOpName.ForeColor = System.Drawing.Color.Black;
            this.m_cboOpName.ListBackColor = System.Drawing.Color.White;
            this.m_cboOpName.ListForeColor = System.Drawing.Color.Black;
            this.m_cboOpName.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboOpName.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboOpName.Location = new System.Drawing.Point(78, 68);
            this.m_cboOpName.m_BlnEnableItemEventMenu = true;
            this.m_cboOpName.Name = "m_cboOpName";
            this.m_cboOpName.SelectedIndex = -1;
            this.m_cboOpName.SelectedItem = null;
            this.m_cboOpName.SelectionStart = 0;
            this.m_cboOpName.Size = new System.Drawing.Size(717, 23);
            this.m_cboOpName.TabIndex = 10000202;
            this.m_cboOpName.Tag = "";
            this.m_cboOpName.TextBackColor = System.Drawing.Color.White;
            this.m_cboOpName.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboOpMedicine1
            // 
            this.m_cboOpMedicine1.AccessibleDescription = "手术用药1";
            this.m_cboOpMedicine1.BackColor = System.Drawing.Color.White;
            this.m_cboOpMedicine1.BorderColor = System.Drawing.Color.Black;
            this.m_cboOpMedicine1.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboOpMedicine1.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboOpMedicine1.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboOpMedicine1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboOpMedicine1.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboOpMedicine1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboOpMedicine1.ForeColor = System.Drawing.Color.Black;
            this.m_cboOpMedicine1.ListBackColor = System.Drawing.Color.White;
            this.m_cboOpMedicine1.ListForeColor = System.Drawing.Color.Black;
            this.m_cboOpMedicine1.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboOpMedicine1.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboOpMedicine1.Location = new System.Drawing.Point(24, 92);
            this.m_cboOpMedicine1.m_BlnEnableItemEventMenu = true;
            this.m_cboOpMedicine1.Name = "m_cboOpMedicine1";
            this.m_cboOpMedicine1.SelectedIndex = -1;
            this.m_cboOpMedicine1.SelectedItem = null;
            this.m_cboOpMedicine1.SelectionStart = 0;
            this.m_cboOpMedicine1.Size = new System.Drawing.Size(128, 23);
            this.m_cboOpMedicine1.TabIndex = 10000202;
            this.m_cboOpMedicine1.Tag = "";
            this.m_cboOpMedicine1.TextBackColor = System.Drawing.Color.White;
            this.m_cboOpMedicine1.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboOpMedicine2
            // 
            this.m_cboOpMedicine2.AccessibleDescription = "手术用药2";
            this.m_cboOpMedicine2.BackColor = System.Drawing.Color.White;
            this.m_cboOpMedicine2.BorderColor = System.Drawing.Color.Black;
            this.m_cboOpMedicine2.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboOpMedicine2.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboOpMedicine2.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboOpMedicine2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboOpMedicine2.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboOpMedicine2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboOpMedicine2.ForeColor = System.Drawing.Color.Black;
            this.m_cboOpMedicine2.ListBackColor = System.Drawing.Color.White;
            this.m_cboOpMedicine2.ListForeColor = System.Drawing.Color.Black;
            this.m_cboOpMedicine2.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboOpMedicine2.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboOpMedicine2.Location = new System.Drawing.Point(168, 92);
            this.m_cboOpMedicine2.m_BlnEnableItemEventMenu = true;
            this.m_cboOpMedicine2.Name = "m_cboOpMedicine2";
            this.m_cboOpMedicine2.SelectedIndex = -1;
            this.m_cboOpMedicine2.SelectedItem = null;
            this.m_cboOpMedicine2.SelectionStart = 0;
            this.m_cboOpMedicine2.Size = new System.Drawing.Size(128, 23);
            this.m_cboOpMedicine2.TabIndex = 10000202;
            this.m_cboOpMedicine2.Tag = "";
            this.m_cboOpMedicine2.TextBackColor = System.Drawing.Color.White;
            this.m_cboOpMedicine2.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboOpMedicine3
            // 
            this.m_cboOpMedicine3.AccessibleDescription = "手术用药3";
            this.m_cboOpMedicine3.BackColor = System.Drawing.Color.White;
            this.m_cboOpMedicine3.BorderColor = System.Drawing.Color.Black;
            this.m_cboOpMedicine3.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboOpMedicine3.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboOpMedicine3.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboOpMedicine3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboOpMedicine3.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboOpMedicine3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboOpMedicine3.ForeColor = System.Drawing.Color.Black;
            this.m_cboOpMedicine3.ListBackColor = System.Drawing.Color.White;
            this.m_cboOpMedicine3.ListForeColor = System.Drawing.Color.Black;
            this.m_cboOpMedicine3.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboOpMedicine3.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboOpMedicine3.Location = new System.Drawing.Point(312, 92);
            this.m_cboOpMedicine3.m_BlnEnableItemEventMenu = true;
            this.m_cboOpMedicine3.Name = "m_cboOpMedicine3";
            this.m_cboOpMedicine3.SelectedIndex = -1;
            this.m_cboOpMedicine3.SelectedItem = null;
            this.m_cboOpMedicine3.SelectionStart = 0;
            this.m_cboOpMedicine3.Size = new System.Drawing.Size(128, 23);
            this.m_cboOpMedicine3.TabIndex = 10000202;
            this.m_cboOpMedicine3.Tag = "";
            this.m_cboOpMedicine3.TextBackColor = System.Drawing.Color.White;
            this.m_cboOpMedicine3.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboOpMedicine4
            // 
            this.m_cboOpMedicine4.AccessibleDescription = "手术用药4";
            this.m_cboOpMedicine4.BackColor = System.Drawing.Color.White;
            this.m_cboOpMedicine4.BorderColor = System.Drawing.Color.Black;
            this.m_cboOpMedicine4.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboOpMedicine4.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboOpMedicine4.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboOpMedicine4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboOpMedicine4.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboOpMedicine4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboOpMedicine4.ForeColor = System.Drawing.Color.Black;
            this.m_cboOpMedicine4.ListBackColor = System.Drawing.Color.White;
            this.m_cboOpMedicine4.ListForeColor = System.Drawing.Color.Black;
            this.m_cboOpMedicine4.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboOpMedicine4.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboOpMedicine4.Location = new System.Drawing.Point(456, 92);
            this.m_cboOpMedicine4.m_BlnEnableItemEventMenu = true;
            this.m_cboOpMedicine4.Name = "m_cboOpMedicine4";
            this.m_cboOpMedicine4.SelectedIndex = -1;
            this.m_cboOpMedicine4.SelectedItem = null;
            this.m_cboOpMedicine4.SelectionStart = 0;
            this.m_cboOpMedicine4.Size = new System.Drawing.Size(128, 23);
            this.m_cboOpMedicine4.TabIndex = 10000202;
            this.m_cboOpMedicine4.Tag = "";
            this.m_cboOpMedicine4.TextBackColor = System.Drawing.Color.White;
            this.m_cboOpMedicine4.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboOpMedicine5
            // 
            this.m_cboOpMedicine5.AccessibleDescription = "手术用药5";
            this.m_cboOpMedicine5.BackColor = System.Drawing.Color.White;
            this.m_cboOpMedicine5.BorderColor = System.Drawing.Color.Black;
            this.m_cboOpMedicine5.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboOpMedicine5.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboOpMedicine5.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboOpMedicine5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboOpMedicine5.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboOpMedicine5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboOpMedicine5.ForeColor = System.Drawing.Color.Black;
            this.m_cboOpMedicine5.ListBackColor = System.Drawing.Color.White;
            this.m_cboOpMedicine5.ListForeColor = System.Drawing.Color.Black;
            this.m_cboOpMedicine5.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboOpMedicine5.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboOpMedicine5.Location = new System.Drawing.Point(600, 92);
            this.m_cboOpMedicine5.m_BlnEnableItemEventMenu = true;
            this.m_cboOpMedicine5.Name = "m_cboOpMedicine5";
            this.m_cboOpMedicine5.SelectedIndex = -1;
            this.m_cboOpMedicine5.SelectedItem = null;
            this.m_cboOpMedicine5.SelectionStart = 0;
            this.m_cboOpMedicine5.Size = new System.Drawing.Size(128, 23);
            this.m_cboOpMedicine5.TabIndex = 10000202;
            this.m_cboOpMedicine5.Tag = "";
            this.m_cboOpMedicine5.TextBackColor = System.Drawing.Color.White;
            this.m_cboOpMedicine5.TextForeColor = System.Drawing.Color.Black;
            // 
            // frmCardiovascularTendMain_GX
            // 
            this.ClientSize = new System.Drawing.Size(992, 609);
            this.Controls.Add(this.m_cboOpMedicine5);
            this.Controls.Add(this.m_cboOpMedicine4);
            this.Controls.Add(this.m_cboOpMedicine3);
            this.Controls.Add(this.m_cboOpMedicine2);
            this.Controls.Add(this.m_cboOpMedicine1);
            this.Controls.Add(this.m_cboOpName);
            this.Controls.Add(this.m_txtLongClassSign);
            this.Controls.Add(this.m_cmdLongClassSign);
            this.Controls.Add(this.m_dtpRecordDate);
            this.Controls.Add(this.m_cboAfterOpDays);
            this.Controls.Add(this.m_txtWeight);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.m_cmdOfficeSign);
            this.Controls.Add(this.m_txtOfficeSign);
            this.Controls.Add(this.m_cmdSmallNightClassSign);
            this.Controls.Add(this.m_txtSmallNightClassSign);
            this.Controls.Add(this.m_cmdBigNightClassSign);
            this.Controls.Add(this.m_txtBigNightClassSign);
            this.Name = "frmCardiovascularTendMain_GX";
            this.Text = "心血管外科特护记录";
            this.Load += new System.EventHandler(this.frmCardiovascularTendMain_GX_Load);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.m_txtBigNightClassSign, 0);
            this.Controls.SetChildIndex(this.m_cmdBigNightClassSign, 0);
            this.Controls.SetChildIndex(this.m_txtSmallNightClassSign, 0);
            this.Controls.SetChildIndex(this.m_cmdSmallNightClassSign, 0);
            this.Controls.SetChildIndex(this.m_txtOfficeSign, 0);
            this.Controls.SetChildIndex(this.m_cmdOfficeSign, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.m_dtgRecordDetail, 0);
            this.Controls.SetChildIndex(this.m_trvInPatientDate, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.m_txtWeight, 0);
            this.Controls.SetChildIndex(this.m_cboAfterOpDays, 0);
            this.Controls.SetChildIndex(this.m_dtpRecordDate, 0);
            this.Controls.SetChildIndex(this.m_cmdLongClassSign, 0);
            this.Controls.SetChildIndex(this.m_txtLongClassSign, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.m_cboOpName, 0);
            this.Controls.SetChildIndex(this.m_cboOpMedicine1, 0);
            this.Controls.SetChildIndex(this.m_cboOpMedicine2, 0);
            this.Controls.SetChildIndex(this.m_cboOpMedicine3, 0);
            this.Controls.SetChildIndex(this.m_cboOpMedicine4, 0);
            this.Controls.SetChildIndex(this.m_cboOpMedicine5, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgRecordDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtbRecords)).EndInit();
            this.m_pnlNewBase.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		protected override Font m_FntHeaderFont
		{
			get
			{
				return new System.Drawing.Font("SimSun", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			}
		}

		// 初始化具体表单的DataTable。
		// 注意，DataTable的第一个Column必须是存放记录时间的字符串，第二个Column必须是存放记录类型的int值，第三个Column必须是存放记录的OpenDate
		protected override void m_mthInitDataTable(DataTable p_dtbRecordTable)
		{
			#region 初始化具体表单的DataTable
			//存放记录时间的字符串
			p_dtbRecordTable.Columns.Add("RecordDate");//0
			//存放记录类型的int值
			DataColumn dcRecordType = new DataColumn("RecordType",typeof(int));
			p_dtbRecordTable.Columns.Add(dcRecordType);//1
			//存放记录的OpenDate字符串
			p_dtbRecordTable.Columns.Add("OpenDate");  //2
			//存放记录的ModifyDate字符串
			p_dtbRecordTable.Columns.Add("ModifyDate"); //3

			DataColumn dc2 = p_dtbRecordTable.Columns.Add("RecordTime");//4
			dc2.DefaultValue = "";
			p_dtbRecordTable.Columns.Add("INFACT1",typeof(clsDSTRichTextBoxValue));//5
			p_dtbRecordTable.Columns.Add("INFACT2",typeof(clsDSTRichTextBoxValue));//6
			p_dtbRecordTable.Columns.Add("INFACT3",typeof(clsDSTRichTextBoxValue));//7
			p_dtbRecordTable.Columns.Add("INFACT4",typeof(clsDSTRichTextBoxValue));//8
			p_dtbRecordTable.Columns.Add("INFACT5",typeof(clsDSTRichTextBoxValue));//9
			p_dtbRecordTable.Columns.Add("INBLOOD",typeof(clsDSTRichTextBoxValue));//10
			p_dtbRecordTable.Columns.Add("INPERHOUR",typeof(clsDSTRichTextBoxValue));//11
			p_dtbRecordTable.Columns.Add("INSUM",typeof(clsDSTRichTextBoxValue));//12
			p_dtbRecordTable.Columns.Add("OUTSUM",typeof(clsDSTRichTextBoxValue));//13
			p_dtbRecordTable.Columns.Add("OUTPERHOUR",typeof(clsDSTRichTextBoxValue));//14
			p_dtbRecordTable.Columns.Add("OUTFACTPISSSUM",typeof(clsDSTRichTextBoxValue));//15
			p_dtbRecordTable.Columns.Add("OUTFACTPISS",typeof(clsDSTRichTextBoxValue));//16
			p_dtbRecordTable.Columns.Add("OUTFACTCHESTJUICE",typeof(clsDSTRichTextBoxValue));//17
			p_dtbRecordTable.Columns.Add("OUTFACTCHESTJUICESUM",typeof(clsDSTRichTextBoxValue));//18
            p_dtbRecordTable.Columns.Add("OUTFACTGASTRICJUICE", typeof(clsDSTRichTextBoxValue));//19
            p_dtbRecordTable.Columns.Add("EXPANDVASMEDICINE", typeof(clsDSTRichTextBoxValue));//20
            p_dtbRecordTable.Columns.Add("CARDIACDIURESIS", typeof(clsDSTRichTextBoxValue));//21
            p_dtbRecordTable.Columns.Add("OTHERMEDICINE", typeof(clsDSTRichTextBoxValue));//22
            p_dtbRecordTable.Columns.Add("CONSCIOUSNESS_PUPIL", typeof(clsDSTRichTextBoxValue));//23
            p_dtbRecordTable.Columns.Add("TEMPERATURE_TWIGTEMP", typeof(clsDSTRichTextBoxValue));//24
            p_dtbRecordTable.Columns.Add("HEARTRATE_RHYTHM", typeof(clsDSTRichTextBoxValue));//25
            p_dtbRecordTable.Columns.Add("BP_AVGBP", typeof(clsDSTRichTextBoxValue));//26
            p_dtbRecordTable.Columns.Add("CVP_LAP", typeof(clsDSTRichTextBoxValue));//27
            p_dtbRecordTable.Columns.Add("CVP_SPO", typeof(clsDSTRichTextBoxValue));//27

            p_dtbRecordTable.Columns.Add("BREATHMACHINE_DEPTH", typeof(clsDSTRichTextBoxValue));//28
            p_dtbRecordTable.Columns.Add("ASSISTANT", typeof(clsDSTRichTextBoxValue));//29
            p_dtbRecordTable.Columns.Add("Fio2_IE", typeof(clsDSTRichTextBoxValue));//30
            p_dtbRecordTable.Columns.Add("INSPIRATION_PEEP", typeof(clsDSTRichTextBoxValue));//31
            p_dtbRecordTable.Columns.Add("TV_VF", typeof(clsDSTRichTextBoxValue));//32
            p_dtbRecordTable.Columns.Add("BREATHTIMES", typeof(clsDSTRichTextBoxValue));//33
            p_dtbRecordTable.Columns.Add("BREATHVOICE", typeof(clsDSTRichTextBoxValue));//34
            p_dtbRecordTable.Columns.Add("PHLEGM", typeof(clsDSTRichTextBoxValue));//35
            p_dtbRecordTable.Columns.Add("GESTICULATION_PHYSICAL", typeof(clsDSTRichTextBoxValue));//36
            p_dtbRecordTable.Columns.Add("REMARK", typeof(clsDSTRichTextBoxValue));//37
            p_dtbRecordTable.Columns.Add("WBC", typeof(clsDSTRichTextBoxValue));//38
            p_dtbRecordTable.Columns.Add("Hb", typeof(clsDSTRichTextBoxValue));//39
            p_dtbRecordTable.Columns.Add("RBC", typeof(clsDSTRichTextBoxValue));//40
            p_dtbRecordTable.Columns.Add("HCT", typeof(clsDSTRichTextBoxValue));//41
            p_dtbRecordTable.Columns.Add("PLT", typeof(clsDSTRichTextBoxValue));//42
            p_dtbRecordTable.Columns.Add("PH", typeof(clsDSTRichTextBoxValue));//43
            p_dtbRecordTable.Columns.Add("PCO2", typeof(clsDSTRichTextBoxValue));//44
            p_dtbRecordTable.Columns.Add("PAO2", typeof(clsDSTRichTextBoxValue));//45
            p_dtbRecordTable.Columns.Add("HCO3", typeof(clsDSTRichTextBoxValue));//46
            p_dtbRecordTable.Columns.Add("BE", typeof(clsDSTRichTextBoxValue));//47
            p_dtbRecordTable.Columns.Add("KPLUS", typeof(clsDSTRichTextBoxValue));//48
            p_dtbRecordTable.Columns.Add("NAPLUS", typeof(clsDSTRichTextBoxValue));//49
            p_dtbRecordTable.Columns.Add("CISUB", typeof(clsDSTRichTextBoxValue));//50
            p_dtbRecordTable.Columns.Add("CAPLUSPLUS", typeof(clsDSTRichTextBoxValue));//51
            p_dtbRecordTable.Columns.Add("GLU", typeof(clsDSTRichTextBoxValue));//52
            p_dtbRecordTable.Columns.Add("BUN", typeof(clsDSTRichTextBoxValue));//53
            p_dtbRecordTable.Columns.Add("UA", typeof(clsDSTRichTextBoxValue));//54
            p_dtbRecordTable.Columns.Add("ANHYDRIDE", typeof(clsDSTRichTextBoxValue));//55
            p_dtbRecordTable.Columns.Add("CO2CP", typeof(clsDSTRichTextBoxValue));//56
            p_dtbRecordTable.Columns.Add("PT", typeof(clsDSTRichTextBoxValue));//57
            p_dtbRecordTable.Columns.Add("XRAYCHECK", typeof(clsDSTRichTextBoxValue));//58
            p_dtbRecordTable.Columns.Add("ACT", typeof(clsDSTRichTextBoxValue));//59
            p_dtbRecordTable.Columns.Add("PROPORTION", typeof(clsDSTRichTextBoxValue));//60
            p_dtbRecordTable.Columns.Add("ALBUMEN", typeof(clsDSTRichTextBoxValue));//61
            p_dtbRecordTable.Columns.Add("HIDDENBLOOD", typeof(clsDSTRichTextBoxValue));//62
            p_dtbRecordTable.Columns.Add("SKIN", typeof(clsDSTRichTextBoxValue));//63
            p_dtbRecordTable.Columns.Add("WASHPERINEUM", typeof(clsDSTRichTextBoxValue));//64
            p_dtbRecordTable.Columns.Add("BRUSHBATH", typeof(clsDSTRichTextBoxValue));//65
            p_dtbRecordTable.Columns.Add("MOUTHTEND", typeof(clsDSTRichTextBoxValue));//66
            p_dtbRecordTable.Columns.Add("RecordSign");

			m_mthSetControl(m_clmRecordTime);
			m_mthSetControl(m_dtcINFACT1);
			m_mthSetControl(m_dtcINFACT2);
			m_mthSetControl(m_dtcINFACT3);
			m_mthSetControl(m_dtcINFACT4);
			m_mthSetControl(m_dtcINFACT5);
			m_mthSetControl(m_dtcINBLOOD);
			m_mthSetControl(m_dtcINPERHOUR);
			m_mthSetControl(m_dtcINSUM);
			m_mthSetControl(m_dtcOUTSUM);
			m_mthSetControl(m_dtcOUTPERHOUR);
			m_mthSetControl(m_dtcOUTFACTPISSSUM);
			m_mthSetControl(m_dtcOUTFACTPISS);
			m_mthSetControl(m_dtcOUTFACTCHESTJUICE);
			m_mthSetControl(m_dtcOUTFACTCHESTJUICESUM);
            m_mthSetControl(m_dtcOUTFACTGASTRICJUICE);
            m_mthSetControl(m_dtcEXPANDVASMEDICINE);
            m_mthSetControl(m_dtcCARDIACDIURESIS);
            m_mthSetControl(m_dtcOTHERMEDICINE);
            m_mthSetControl(m_dtcCONSCIOUSNESS_PUPIL);
            m_mthSetControl(m_dtcTEMPERATURE_TWIGTEMP);
            m_mthSetControl(m_dtcHEARTRATE_RHYTHM);
            m_mthSetControl(m_dtcBP_AVGBP);
            m_mthSetControl(m_dtcCVP_LAP);
            m_mthSetControl(m_dtcCVP_SPO);
            m_mthSetControl(m_dtcBREATHMACHINE_DEPTH);
            m_mthSetControl(m_dtcASSISTANT);
            m_mthSetControl(m_dtcFio2_IE);
            m_mthSetControl(m_dtcINSPIRATION_PEEP);
            m_mthSetControl(m_dtcTV_VF);
            m_mthSetControl(m_dtcBREATHTIMES);
            m_mthSetControl(m_dtcBREATHVOICE);
            m_mthSetControl(m_dtcPHLEGM);
            m_mthSetControl(m_dtcGESTICULATION_PHYSICAL);
            m_mthSetControl(m_dtcREMARK);
            m_mthSetControl(m_dtcWBC);
            m_mthSetControl(m_dtcHb);
            m_mthSetControl(m_dtcRBC);
            m_mthSetControl(m_dtcHCT);
            m_mthSetControl(m_dtcPLT);
            m_mthSetControl(m_dtcPH);
            m_mthSetControl(m_dtcPCO2);
            m_mthSetControl(m_dtcPAO2);
            m_mthSetControl(m_dtcHCO3);
            m_mthSetControl(m_dtcBE);
            m_mthSetControl(m_dtcKPLUS);
            m_mthSetControl(m_dtcNAPLUS);
            m_mthSetControl(m_dtcCISUB);
            m_mthSetControl(m_dtcCAPLUSPLUS);
            m_mthSetControl(m_dtcGLU);
            m_mthSetControl(m_dtcBUN);
            m_mthSetControl(m_dtcUA);
            m_mthSetControl(m_dtcANHYDRIDE);
            m_mthSetControl(m_dtcCO2CP);
            m_mthSetControl(m_dtcPT);
            m_mthSetControl(m_dtcXRAYCHECK);
            m_mthSetControl(m_dtcACT);
            m_mthSetControl(m_dtcPROPORTION);
            m_mthSetControl(m_dtcALBUMEN);
            m_mthSetControl(m_dtcHIDDENBLOOD);
            m_mthSetControl(m_dtcSKIN);
            m_mthSetControl(m_dtcWASHPERINEUM);
            m_mthSetControl(m_dtcBRUSHBATH);
            m_mthSetControl(m_dtcMOUTHTEND);

			//设置文字栏
			this.m_clmRecordTime.HeaderText = "\r\n时\r\n\r\n间";
			this.m_dtcINFACT1.HeaderText = "\r\n实\r\n入\r\n量\r\n\r\n1";
			this.m_dtcINFACT2.HeaderText = "\r\n实\r\n入\r\n量\r\n\r\n2";
			this.m_dtcINFACT3.HeaderText = "\r\n实\r\n入\r\n量\r\n\r\n3";
			this.m_dtcINFACT4.HeaderText = "\r\n实\r\n入\r\n量\r\n\r\n4";
			this.m_dtcINFACT5.HeaderText = "\r\n实\r\n入\r\n量\r\n\r\n5";
			this.m_dtcINBLOOD.HeaderText = "\r\n实\r\n入\r\n量\r\n全血\r\n/血浆";
			this.m_dtcINPERHOUR.HeaderText = "\r\n入量\r\n\r\n每\r\n\r\n时";
			this.m_dtcINSUM.HeaderText = "\r\n入量\r\n\r\n总\r\n\r\n量";
			this.m_dtcOUTSUM.HeaderText = "\r\n出量\r\n\r\n总\r\n\r\n量";
			this.m_dtcOUTPERHOUR.HeaderText = "\r\n出量\r\n\r\n每\r\n\r\n时";
			this.m_dtcOUTFACTPISSSUM.HeaderText = "\r\n实\r\n出\r\n量\r\n累积\r\n尿量";
			this.m_dtcOUTFACTPISS.HeaderText = "\r\n实\r\n出\r\n量\r\n\r\n尿量";
			this.m_dtcOUTFACTCHESTJUICE.HeaderText = "\r\n实\r\n出\r\n量\r\n\r\n胸液";
			this.m_dtcOUTFACTCHESTJUICESUM.HeaderText = "\r\n实\r\n出\r\n量\r\n积累\r\n胸液";
            this.m_dtcOUTFACTGASTRICJUICE.HeaderText = "\r\n实\r\n出\r\n量\r\n\r\n胃液";
            this.m_dtcEXPANDVASMEDICINE.HeaderText = "\r\n升压扩张\r\n血管药物\r\nug/kg/min";
            this.m_dtcCARDIACDIURESIS.HeaderText = "\r\n\r\n强心利尿";
            this.m_dtcOTHERMEDICINE.HeaderText = "\r\n\r\n其他药物";
            this.m_dtcCONSCIOUSNESS_PUPIL.HeaderText = "\r\n神\r\n智\r\n意识\r\n/瞳孔";
            this.m_dtcTEMPERATURE_TWIGTEMP.HeaderText = "\r\n循\r\n环\r\n体温\r\n/末梢温";
            this.m_dtcHEARTRATE_RHYTHM.HeaderText = "\r\n循\r\n环\r\n心率\r\n/心律";
            this.m_dtcBP_AVGBP.HeaderText = "\r\n循\r\n环\r\n血压\r\n/平均压";
            this.m_dtcCVP_LAP.HeaderText = "\r\n循\r\n环\r\nCVP\r\n/LAP";
            this.m_dtcCVP_SPO.HeaderText = "\r\n循\r\n环\r\nSPO\r\n/2";
            this.m_dtcBREATHMACHINE_DEPTH.HeaderText = "\r\n呼\r\n吸\r\n呼吸机\r\n型号\r\n/插管\r\n/  深度";
            this.m_dtcASSISTANT.HeaderText = "\r\n呼\r\n吸\r\n辅助\r\n\r\n方式";
            this.m_dtcFio2_IE.HeaderText = "\r\n呼\r\n吸\r\nFiO2\r\n(%)\r\n  /I:E";
            this.m_dtcINSPIRATION_PEEP.HeaderText = "\r\n呼\r\n吸\r\n吸气\r\n压\r\n/PEEP\r\n/(CmH2O)";
            this.m_dtcTV_VF.HeaderText = "\r\n呼\r\n吸\r\nTV  \r\nml/  \r\n/VF";
            this.m_dtcBREATHTIMES.HeaderText = "\r\n呼\r\n吸\r\n次\r\n数";
            this.m_dtcBREATHVOICE.HeaderText = "\r\n呼\r\n吸\r\n次\r\n左/右";
            this.m_dtcPHLEGM.HeaderText = "\r\n痰色\r\n/痰量";
            this.m_dtcGESTICULATION_PHYSICAL.HeaderText = "\r\n体位\r\n/理疗";
            this.m_dtcREMARK.HeaderText = "\r\n\r\n备    注";
            this.m_dtcWBC.HeaderText = "\r\n血\r\n常\r\n规\r\nWBC";
            this.m_dtcHb.HeaderText = "\r\n血\r\n常\r\n规\r\nHb";
            this.m_dtcRBC.HeaderText = "\r\n血\r\n常\r\n规\r\nRBC";
            this.m_dtcHCT.HeaderText = "\r\n血\r\n常\r\n规\r\nHCT";
            this.m_dtcPLT.HeaderText = "\r\n血\r\n常\r\n规\r\nPLT";
            this.m_dtcPH.HeaderText = "\r\n血\r\n\r\n气\r\nPH";
            this.m_dtcPCO2.HeaderText = "\r\n血\r\n\r\n气\r\nPCO2";
            this.m_dtcPAO2.HeaderText = "\r\n血\r\n\r\n气\r\nPaO2";
            this.m_dtcHCO3.HeaderText = "\r\n血\r\n\r\n气\r\nHCO3";
            this.m_dtcBE.HeaderText = "\r\n血\r\n\r\n气\r\nBE";
            this.m_dtcKPLUS.HeaderText = "\r\n血\r\n电\r\n解\r\n质\r\nK+";
            this.m_dtcNAPLUS.HeaderText = "\r\n血\r\n电\r\n解\r\n质\r\nNa+";
            this.m_dtcCISUB.HeaderText = "\r\n血\r\n电\r\n解\r\n质\r\nCI-";
            this.m_dtcCAPLUSPLUS.HeaderText = "\r\n血\r\n电\r\n解\r\n质\r\nCa++";
            this.m_dtcGLU.HeaderText = "\r\n血\r\n电\r\n解\r\n质\r\nGLU";
            this.m_dtcBUN.HeaderText = "\r\n血\r\n液\r\n生\r\n化\r\nBUN";
            this.m_dtcUA.HeaderText = "\r\n血\r\n液\r\n生\r\n化\r\nUA";
            this.m_dtcANHYDRIDE.HeaderText = "\r\n血\r\n液\r\n生\r\n化\r\n肌酐";
            this.m_dtcCO2CP.HeaderText = "\r\n血\r\n液\r\n生\r\n化\r\nCO2CP";
            this.m_dtcPT.HeaderText = "\r\n\r\nPT";
            this.m_dtcXRAYCHECK.HeaderText = "\r\n\r\nX  线\r\n检  查";
            this.m_dtcACT.HeaderText = "\r\n\r\nACT";
            this.m_dtcPROPORTION.HeaderText = "\r\n尿\r\n常\r\n规\r\n比重";
            this.m_dtcALBUMEN.HeaderText = "\r\n尿\r\n常\r\n规\r\n蛋白";
            this.m_dtcHIDDENBLOOD.HeaderText = "\r\n尿\r\n常\r\n规\r\n潜血";
            this.m_dtcSKIN.HeaderText = "\r\n皮\r\n\r\n\r\n肤";
            this.m_dtcWASHPERINEUM.HeaderText = "\r\n会\r\n阴\r\n冲\r\n洗";
            this.m_dtcBRUSHBATH.HeaderText = "\r\n擦\r\n\r\n\r\n浴";
            this.m_dtcMOUTHTEND.HeaderText = "\r\n口\r\n腔\r\n护\r\n理";
			#endregion
		}

		#region 属性
		/// <summary>
		/// 当前入院时间
		/// </summary>
		protected override string m_StrCurrentOpenDate
		{
			get
			{
				if(m_strCurrentOpenDate=="")
				{
					clsPublicFunction.ShowInformationMessageBox("请先选择记录");
					return "";
				}
				return m_strCurrentOpenDate;
			}
		}

		protected override enmApproveType m_EnmAppType
		{
			get{return enmApproveType.Nurses;}
		}
		/// <summary>
		/// 记录者ID?
		/// </summary>
		protected override string m_StrRecorder_ID
		{
			get
			{
				return m_strCreateUserID;
			}
		}
		#endregion 属性

		//设置初始的比较日期
		private DateTime m_dtmPreRecordDate;
		// 清空特殊记录信息，并重置记录控制状态为不控制。
		protected override void m_mthClearRecordInfo()
		{			
			m_dtmPreRecordDate=DateTime.MinValue;
			m_dtgRecordDetail.CurrentRowIndex=0;
			m_dtbRecords.Rows.Clear();
			m_cboOpName.Text = "";
			m_cboOpMedicine1.Text = "";
			m_cboOpMedicine1.SelectedIndex = -1;
			m_cboOpMedicine2.Text = "";
			m_cboOpMedicine2.SelectedIndex = -1;
			m_cboOpMedicine3.Text = "";
			m_cboOpMedicine3.SelectedIndex = -1;
			m_cboOpMedicine4.Text = "";
			m_cboOpMedicine4.SelectedIndex = -1;
			m_cboOpMedicine5.Text = "";
			m_cboOpMedicine5.SelectedIndex = -1;
			m_txtWeight.Clear();

			m_txtLongClassSign.Clear();
			m_txtLongClassSign.Tag = null;
			m_txtOfficeSign.Clear();
			m_txtOfficeSign.Tag = null;
			m_txtSmallNightClassSign.Clear();
			m_txtSmallNightClassSign.Tag = null;
			m_txtBigNightClassSign.Clear();
			m_txtBigNightClassSign.Tag = null;

		}

		/// <summary>
		/// 获取痕迹保留
		/// </summary>
		/// <param name="p_strText"></param>
		/// <param name="p_strModifyUserID"></param>
		/// <param name="p_strModifyUserName"></param>
		/// <returns></returns>
		private string m_strGetDSTTextXML(string p_strText,string p_strModifyUserID,string p_strModifyUserName)
		{
			return com.digitalwave.controls.ctlRichTextBox.clsXmlTool.s_strMakeDSTXml(p_strText,p_strModifyUserID,p_strModifyUserName,Color.Black,Color.White);
		}

		// 获取病程记录的领域层实例
		protected override clsRecordsDomain m_objGetRecordsDomain()
		{
            return new clsRecordsDomain(enmRecordsType.CardiovascularTend_GX);
		}

		// 获取记录的主要信息（必须获取的是CreateDate,OpenDate,LastModifyDate）
		protected override clsTrackRecordContent m_objGetRecordMainContent(int p_intRecordType,
			object[] p_objDataArr)
		{
			//根据 p_intRecordType 获取对应的 clsTrackRecordContent
			clsTrackRecordContent objContent = null;
			switch((enmDiseaseTrackType)p_intRecordType)
			{ 
				case enmDiseaseTrackType.CardiovascularTend_GX:
					objContent = new clsCardiovascularTend_GX();
					break;
			}

			if(objContent == null)
				objContent=new clsCardiovascularTend_GX();	
		
			if(m_objCurrentPatient !=null)
				objContent.m_strInPatientID=m_objCurrentPatient.m_StrInPatientID;
			else 
			{
				clsPublicFunction.ShowInformationMessageBox("当前病人为空!");
				return null;
			}
			int intSelectedRecordStartRow =m_dtgRecordDetail.CurrentCell.RowNumber;
			objContent.m_strCreateUserID = (m_dtbRecords.Rows[intSelectedRecordStartRow][68]).ToString();
			objContent.m_dtmInPatientDate=m_objCurrentPatient.m_DtmSelectedInDate;
			objContent.m_dtmCreateDate = DateTime.Parse((string)p_objDataArr[0]);
			objContent.m_dtmOpenDate = DateTime.Parse((string)p_objDataArr[2]);
			objContent.m_dtmModifyDate = DateTime.Parse((string)p_objDataArr[3]);     
		
			return objContent;
		}

		private void frmCardiovascularTendMain_GX_Load(object sender, System.EventArgs e)
		{
			m_dtmPreRecordDate = DateTime.MinValue;
//			m_dtgRecordDetail.Focus();
			m_mniAddBlank.Visible=false;
			m_mniDeleteBlank.Visible=false;
			m_objCurrentContent = null;

			m_mthSetComboBoxItem();
			m_cboOpName.Focus();
		}

		// 获取处理（添加和修改）记录的窗体。
		protected override frmDiseaseTrackBase m_frmGetRecordForm(int p_intRecordType)
		{
			switch((enmDiseaseTrackType)p_intRecordType)
			{
				case enmDiseaseTrackType.CardiovascularTend_GX:
					return new frmCardiovascularTend_GX(m_dtpRecordDate.Value);
			}  
		
			return null;
		}

		/// <summary>
		/// 处理子窗体
		/// </summary>
		/// <param name="p_frmSubForm"></param>
		protected override void m_mthHandleSubFormClosedWithYes(frmDiseaseTrackBase p_frmSubForm)
		{
            m_mthPerformSessionChanged(m_ObjCurrentEmrPatientSession, 0);
		}
		/// <summary>
		/// 从Table删除数据
		/// </summary>
		/// <param name="p_intRecordType"></param>
		/// <param name="p_dtmCreateRecordTime"></param>
		protected override void m_mthRemoveDataFromDataTable(int p_intRecordType,
			DateTime p_dtmCreateRecordTime)
		{
            m_mthPerformSessionChanged(m_ObjCurrentEmrPatientSession, 0);
		}

		/// <summary>
		/// 获取当前病人的作废内容
		/// </summary>
		/// <param name="p_dtmRecordDate">记录日期</param>
		/// <param name="p_intFormID">窗体ID</param>
		protected override void m_mthGetDeactiveContent(DateTime p_dtmRecordDate,int p_intFormID)
		{			
			m_mthGetDeletedRecord(p_intFormID,p_dtmRecordDate);
		}

		protected override void m_mthModifyRecord(int p_intRecordType,
			DateTime p_dtmCreateRecordTime)
		{
			PrivilegeData.enmPrivilegeSF enmSF = (PrivilegeData.enmPrivilegeSF)Enum.Parse(typeof(PrivilegeData.enmPrivilegeSF),this.GetType().Name);
#if FunctionPrivilege
			if(!clsPublicFunction.s_blnCheckCurrentPrivilege(enmSF,PrivilegeData.enmPrivilegeOperation.AddOrModify))
			{
				clsPublicFunction.s_mthShowNotPermitMessage();
				return;
			}			
#endif
			//获取添加记录的窗体
			frmDiseaseTrackBase frmAddNewForm = m_frmGetRecordForm(p_intRecordType); 
			frmAddNewForm.m_mthSetDiseaseTrackInfo(m_objCurrentPatient,p_dtmCreateRecordTime);
		
			m_mthShowSubForm(frmAddNewForm,p_intRecordType,true);
		}

		protected override void m_mthClearPatientRecordInfo()
		{
			m_mthSetDataGridFirstRowFocus();
			m_dtgRecordDetail.CurrentRowIndex = 0;
			m_dtbRecords.Rows.Clear();
			//清空记录内容                       
			m_mthClearRecordInfo();
			dtTempTable.Rows.Clear();
			m_objCurrentContent = null;
		}

		private void mniAppend_Click(object sender, System.EventArgs e)
		{
			if(m_objCurrentContent == null)
			{
				MDIParent.ShowInformationMessageBox("请先填写并保存手术基本资料！");
				return;
			}
			PrivilegeData.enmPrivilegeSF enmSF = (PrivilegeData.enmPrivilegeSF)Enum.Parse(typeof(PrivilegeData.enmPrivilegeSF),this.GetType().Name);
#if FunctionPrivilege
			if(!clsPublicFunction.s_blnCheckCurrentPrivilege(enmSF,PrivilegeData.enmPrivilegeOperation.AddOrModify))
			{
				clsPublicFunction.s_mthShowNotPermitMessage();
				return;
			}			
#endif
			m_mthAddNewRecord((int)enmDiseaseTrackType.CardiovascularTend_GX);
		}

		protected override object[][] m_objGetRecordsValueArr(clsTransDataInfo p_objTransDataInfo)
		{
			#region 显示记录到DataGrid
			try
			{
				object[] objData;
				ArrayList objReturnData=new ArrayList();
				clsCardiovascularTend_GXDataInfo objCTInfo = new clsCardiovascularTend_GXDataInfo();
				clsDSTRichTextBoxValue objclsDSTRichTextBoxValue;
				string strText,strXml;
                int intMedicine_PupilRows = 0;//存储药物和瞳孔中最大的行数
				string[] strEXPANDVASMEDICINE = null;//升压扩张血管药物
				string[] strCARDIACDIURESIS = null;//强心利尿
				string[] strOTHERMEDICINE = null;//其他药物
				string[] strConArr = null;
				string strNext = "";

				objCTInfo = (clsCardiovascularTend_GXDataInfo)p_objTransDataInfo;
				if(objCTInfo.m_objRecordArr == null)
					return null;

				#region 获取修改限定时间
				int intCanModifyTime = 0;
				try
				{
					intCanModifyTime = int.Parse(m_strCanModifyTime);
				}
				catch
				{
					intCanModifyTime = 6;
				}
				#endregion

				int intRecordCount = objCTInfo.m_objRecordArr.Length;

				for(int i=0; i<intRecordCount; i++)
				{
					objData = new object[69];   
					clsCardiovascularTend_GX objCurrent = objCTInfo.m_objRecordArr[i];
					clsCardiovascularTend_GX objNext = new clsCardiovascularTend_GX();//下一条特护记录
					if(i < intRecordCount-1)
						objNext = objCTInfo.m_objRecordArr[i+1];

					//如果该护理记录是修改前的记录且是在指定时间内修改的，修改者与创建者为同一人，则不显示
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strModifyUserID.Trim()==objCurrent.m_strCreateUserID.Trim())
					{
						TimeSpan tsModify =  objNext.m_dtmModifyDate-objCurrent.m_dtmModifyDate;
						if((int)tsModify.TotalHours < intCanModifyTime)
							continue;
					}

					#region 存放关键字段
					if(objCurrent.m_dtmCreateDate!=DateTime.MinValue)
					{
						objData[0] = objCurrent.m_dtmRECORDDATE;//存放记录时间的字符串
						objData[1] = (int)enmRecordsType.CardiovascularTend_GX;//存放记录类型的int值
						objData[2] = objCurrent.m_dtmOpenDate;//存放记录的OpenDate字符串
						objData[3] = objCurrent.m_dtmModifyDate;//存放记录的ModifyDate字符串   
						
						//修改后带有痕迹的记录不再显示时间
						if(m_dtmPreRecordDate != objCurrent.m_dtmRECORDDATE)
							objData[4] = objCurrent.m_dtmRECORDDATE.ToString("HH:mm");//时间字符串
	
					}	
					m_dtmPreRecordDate = objCurrent.m_dtmRECORDDATE;
					#endregion ;

					#region 存放单项信息
					//实入量>>1
					strText = objCurrent.m_strINFACT1_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strINFACT1_RIGHT != objCurrent.m_strINFACT1_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strINFACT1_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[5] = objclsDSTRichTextBoxValue;

					//实入量>>2
					strText = objCurrent.m_strINFACT2_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strINFACT2_RIGHT != objCurrent.m_strINFACT2_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strINFACT2_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[6] = objclsDSTRichTextBoxValue;

					//实入量>>3
					strText = objCurrent.m_strINFACT3_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strINFACT3_RIGHT != objCurrent.m_strINFACT3_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strINFACT3_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[7] = objclsDSTRichTextBoxValue;

					//实入量>>4
					strText = objCurrent.m_strINFACT4_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strINFACT4_RIGHT != objCurrent.m_strINFACT4_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strINFACT4_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[8] = objclsDSTRichTextBoxValue;

					//实入量>>5
					strText = objCurrent.m_strINFACT5_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strINFACT5_RIGHT != objCurrent.m_strINFACT5_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strINFACT5_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[9] = objclsDSTRichTextBoxValue;

					//实入量>>全血/血浆
					strText = objCurrent.m_strINBLOOD_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strINBLOOD_RIGHT != objCurrent.m_strINBLOOD_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strINBLOOD_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[10] = objclsDSTRichTextBoxValue;

					//入量>>每时
					strText = objCurrent.m_strINPERHOUR_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strINPERHOUR_RIGHT != objCurrent.m_strINPERHOUR_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strINPERHOUR_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[11] = objclsDSTRichTextBoxValue;

					//入量>>总量
					strText = objCurrent.m_strINSUM_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strINSUM_RIGHT != objCurrent.m_strINSUM_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strINSUM_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[12] = objclsDSTRichTextBoxValue;

					//出量>>总量
					strText = objCurrent.m_strOUTSUM_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strOUTSUM_RIGHT != objCurrent.m_strOUTSUM_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strOUTSUM_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[13] = objclsDSTRichTextBoxValue;

					//出量>>每时
					strText = objCurrent.m_strOUTPERHOUR_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strOUTPERHOUR_RIGHT != objCurrent.m_strOUTPERHOUR_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strOUTPERHOUR_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[14] = objclsDSTRichTextBoxValue;

					//实出量>>累积尿量
					strText = objCurrent.m_strOUTFACTPISSSUM_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strOUTFACTPISSSUM_RIGHT != objCurrent.m_strOUTFACTPISSSUM_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strOUTFACTPISSSUM_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[15] = objclsDSTRichTextBoxValue;

					//实出量>>尿量
					strText = objCurrent.m_strOUTFACTPISS_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strOUTFACTPISS_RIGHT != objCurrent.m_strOUTFACTPISS_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strOUTFACTPISS_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[16] = objclsDSTRichTextBoxValue;

					//实出量>>胸液
					strText = objCurrent.m_strOUTFACTCHESTJUICE_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strOUTFACTCHESTJUICE_RIGHT != objCurrent.m_strOUTFACTCHESTJUICE_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strOUTFACTCHESTJUICE_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[17] = objclsDSTRichTextBoxValue;

					//实出量>>积累胸液
					strText = objCurrent.m_strOUTFACTCHESTJUICESUM_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strOUTFACTCHESTJUICESUM_RIGHT != objCurrent.m_strOUTFACTCHESTJUICESUM_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strOUTFACTCHESTJUICESUM_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[18] = objclsDSTRichTextBoxValue;

					//实出量>>胃液
					strText = objCurrent.m_strOUTFACTGASTRICJUICE_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strOUTFACTGASTRICJUICE_RIGHT != objCurrent.m_strOUTFACTGASTRICJUICE_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strOUTFACTGASTRICJUICE_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[19] = objclsDSTRichTextBoxValue;

					//升压扩张血管药物
					if(objCurrent.m_strEXPANDVASMEDICINE_RIGHT != null && objCurrent.m_strEXPANDVASMEDICINE_RIGHT != "")
					{
						strEXPANDVASMEDICINE = objCurrent.m_strEXPANDVASMEDICINE_RIGHT.Split('√');
						intMedicine_PupilRows = strEXPANDVASMEDICINE.Length;
						strConArr = strEXPANDVASMEDICINE[0].Split('×');
						//strText = strConArr[0] + " " + strConArr[1];
                        if (strConArr.Length == 2)
                        {
                            strText = strConArr[0] + " " + strConArr[1];
                        }
                        else
                        {
                            strText = strConArr[0] + " " + strConArr[1] + " " + strConArr[2];
                        }

                        //if(objNext != null && objNext.m_strEXPANDVASMEDICINE_RIGHT != null && objNext.m_strEXPANDVASMEDICINE_RIGHT != "")
                        //{
                        //    strConArr = objNext.m_strEXPANDVASMEDICINE_RIGHT.Split('√')[0].Split('×');
                        //    if (strConArr.Length == 2)
                        //    {
                        //        strText = strConArr[0] + " " + strConArr[1];
                        //    }
                        //    else
                        //    {
                        //        strText = strConArr[0] + " " + strConArr[1] + " " + strConArr[2];
                        //    }
							
                        //}
						strXml = "<root />";
						if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && strText != strText)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
						{
							strXml = m_strGetDSTTextXML(strText ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
						}
						objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
						objclsDSTRichTextBoxValue.m_strText=strText;						
						objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
						objData[20] = objclsDSTRichTextBoxValue;
					}

					//强心利尿
					if(objCurrent.m_strCARDIACDIURESIS_RIGHT != null && objCurrent.m_strCARDIACDIURESIS_RIGHT != "")
					{
						strCARDIACDIURESIS = objCurrent.m_strCARDIACDIURESIS_RIGHT.Split('√');
						if(strCARDIACDIURESIS.Length > intMedicine_PupilRows)
							intMedicine_PupilRows = strCARDIACDIURESIS.Length;
						strConArr = strCARDIACDIURESIS[0].Split('×');
						//strText = strConArr[0] + " " + strConArr[1];
                        if (strConArr.Length == 2)
                        {
                            strText = strConArr[0] + " " + strConArr[1];
                        }
                        else
                        {
                            strText = strConArr[0] + " " + strConArr[1] + " " + strConArr[2];
                        }

                        //if(objNext != null && objNext.m_strCARDIACDIURESIS_RIGHT != null && objNext.m_strCARDIACDIURESIS_RIGHT != "")
                        //{
                        //    strConArr = objNext.m_strCARDIACDIURESIS_RIGHT.Split('√')[0].Split('×');
                        //    //strText = strConArr[0] + " " + strConArr[1];
                        //    if (strConArr.Length == 2)
                        //    {
                        //        strText = strConArr[0] + " " + strConArr[1];
                        //    }
                        //    else
                        //    {
                        //        strText = strConArr[0] + " " + strConArr[1] + " " + strConArr[2];
                        //    }
                        //}
						strXml = "<root />";
						if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && strText != strText)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
						{
							strXml = m_strGetDSTTextXML(strText ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
						}
						objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
						objclsDSTRichTextBoxValue.m_strText=strText;						
						objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
						objData[21] = objclsDSTRichTextBoxValue;
					}

					//其他药物
					if(objCurrent.m_strOTHERMEDICINE_RIGHT != null && objCurrent.m_strOTHERMEDICINE_RIGHT != "")
					{
						strOTHERMEDICINE = objCurrent.m_strOTHERMEDICINE_RIGHT.Split('√');
						if(strOTHERMEDICINE.Length > intMedicine_PupilRows)
							intMedicine_PupilRows = strOTHERMEDICINE.Length;
						strConArr = strOTHERMEDICINE[0].Split('×');
						//strText = strConArr[0] + " " + strConArr[1];
                        if (strConArr.Length == 2)
                        {
                            strText = strConArr[0] + " " + strConArr[1];
                        }
                        else
                        {
                            strText = strConArr[0] + " " + strConArr[1] + " " + strConArr[2];
                        }
                        //if(objNext != null && objNext.m_strOTHERMEDICINE_RIGHT != null && objNext.m_strOTHERMEDICINE_RIGHT != "")
                        //{
                        //    strConArr = objNext.m_strOTHERMEDICINE_RIGHT.Split('√')[0].Split('×');
                        //    //strText = strConArr[0] + " " + strConArr[1];
                        //    if (strConArr.Length == 2)
                        //    {
                        //        strText = strConArr[0] + " " + strConArr[1];
                        //    }
                        //    else
                        //    {
                        //        strText = strConArr[0] + " " + strConArr[1] + " " + strConArr[2];
                        //    }
                        //}
						strXml = "<root />";
						if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && strText != strText)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
						{
							strXml = m_strGetDSTTextXML(strText ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
						}
						objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
						objclsDSTRichTextBoxValue.m_strText=strText;						
						objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
						objData[22] = objclsDSTRichTextBoxValue;
					}

					//神智>>意识/瞳孔
					strText = objCurrent.m_strCONSCIOUSNESS_RIGHT + "/" + objCurrent.m_strPUPIL_RIGHT;
					if(objNext != null)
						strNext = objNext.m_strCONSCIOUSNESS_RIGHT + "/" + objNext.m_strPUPIL_RIGHT;
					if(objCurrent.m_strLEFTPUPIL_RIGHT!=null && objCurrent.m_strLEFTPUPIL_RIGHT!="" &&
						objCurrent.m_strRIGHTPUPIL_RIGHT!=null && objCurrent.m_strRIGHTPUPIL_RIGHT!="" &&
						intMedicine_PupilRows < 3)
						intMedicine_PupilRows = 3;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && strText != strNext)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(strText ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[23] = objclsDSTRichTextBoxValue;

					//循环>>体温/末梢温
					strText = objCurrent.m_strTEMPERATURE_RIGHT + "/" + objCurrent.m_strTWIGTEMPERATURE_RIGHT;
					if(objNext != null)
						strNext = objNext.m_strTEMPERATURE_RIGHT + "/" + objNext.m_strTWIGTEMPERATURE_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && strText != strNext)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(strText ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[24] = objclsDSTRichTextBoxValue;

					//循环>>心率/心律
					strText = objCurrent.m_strHEARTRATE_RIGHT + "/" + objCurrent.m_strHEARTRHYTHM_RIGHT;
					if(objNext != null)
						strNext = objNext.m_strHEARTRATE_RIGHT + "/" + objNext.m_strHEARTRHYTHM_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && strText != strNext)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(strText ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[25] = objclsDSTRichTextBoxValue;

					//循环>>血压/平均压
					strText = objCurrent.m_strBPA_RIGHT + "/" + objCurrent.m_strBPS_RIGHT + "/" + objCurrent.m_strAVGBP_RIGHT;
					if(objNext != null)
						strNext = objNext.m_strBPA_RIGHT + "/" + objNext.m_strBPS_RIGHT + "/" + objNext.m_strAVGBP_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && strText != strNext)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(strText ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[26] = objclsDSTRichTextBoxValue;

					//循环>>CVP/LAP
					strText = objCurrent.m_strCVP_RIGHT + "/" + objCurrent.m_strLAP_RIGHT;
					if(objNext != null)
						strNext = objNext.m_strCVP_RIGHT + "/" + objNext.m_strLAP_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && strText != strNext)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(strText ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[27] = objclsDSTRichTextBoxValue;

                    //循环>>SPO
                    strText = objCurrent.m_strSPO_RIGHT;
                    if (objNext != null)
                        strNext = objNext.m_strSPO_RIGHT;
                    strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && strText != strNext)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    {
                        strXml = m_strGetDSTTextXML(strText, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
                    }
                    objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                    objclsDSTRichTextBoxValue.m_strText = strText;
                    objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                    objData[28] = objclsDSTRichTextBoxValue;

					//呼吸>>呼吸机型号/插管深度
					strText = objCurrent.m_strBREATHMACHINE_RIGHT + "/" + objCurrent.m_strINSERTDEPTH_RIGHT;
					if(objNext != null)
						strNext = objNext.m_strBREATHMACHINE_RIGHT + "/" + objNext.m_strINSERTDEPTH_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && strText != strNext)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(strText ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[29] = objclsDSTRichTextBoxValue;

					//呼吸>>辅助方式
					strText = objCurrent.m_strASSISTANT_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objCurrent.m_strASSISTANT_RIGHT != objNext.m_strASSISTANT_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strASSISTANT_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[30] = objclsDSTRichTextBoxValue;

					//呼吸>>FiO2/I:E
					strText = objCurrent.m_strFIO2_RIGHT + "/" + objCurrent.m_strIE_RIGHT;
					if(objNext != null)
						strNext = objNext.m_strFIO2_RIGHT + "/" + objNext.m_strIE_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && strText != strNext)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(strText ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[31] = objclsDSTRichTextBoxValue;

					//呼吸>>吸气压/PEEP
					strText = objCurrent.m_strINSPIRATION_RIGHT + "/" + objCurrent.m_strPEEP_RIGHT;
					if(objNext != null)
						strNext = objNext.m_strINSPIRATION_RIGHT + "/" + objNext.m_strPEEP_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && strText != strNext)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(strText ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[32] = objclsDSTRichTextBoxValue;

					//呼吸>>TV/VF
					strText = objCurrent.m_strTV_RIGHT + "/" + objCurrent.m_strVF_RIGHT;
					if(objNext != null)
						strNext = objNext.m_strTV_RIGHT + "/" + objNext.m_strVF_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && strText != strNext)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(strText ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[33] = objclsDSTRichTextBoxValue;

					//呼吸>>呼吸次数
					strText = objCurrent.m_strBREATHTIMES_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objCurrent.m_strBREATHTIMES_RIGHT != objNext.m_strBREATHTIMES_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strBREATHTIMES_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[34] = objclsDSTRichTextBoxValue;

					//呼吸>>左呼吸音/右呼吸音
					strText = objCurrent.m_strLEFTBREATHVOICE_RIGHT + "/" + objCurrent.m_strRIGHTBREATHVOICE_RIGHT;
					if(objNext != null)
						strNext = objNext.m_strLEFTBREATHVOICE_RIGHT + "/" + objNext.m_strRIGHTBREATHVOICE_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && strText != strNext)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(strText ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[35] = objclsDSTRichTextBoxValue;

					//呼吸>>痰色/痰量
					strText = objCurrent.m_strPHLEGMCOLOR_RIGHT + "/" + objCurrent.m_strPHLEGMQUANTITY_RIGHT;
					if(objNext != null)
						strNext = objNext.m_strPHLEGMCOLOR_RIGHT + "/" + objNext.m_strPHLEGMQUANTITY_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && strText != strNext)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(strText ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[36] = objclsDSTRichTextBoxValue;

					//呼吸>>体位/理疗
					strText = objCurrent.m_strGESTICULATION_RIGHT + "/" + objCurrent.m_strPHYSICALTHERAPY_RIGHT;
					if(objNext != null)
						strNext = objNext.m_strGESTICULATION_RIGHT + "/" + objNext.m_strPHYSICALTHERAPY_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && strText != strNext)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(strText ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[37] = objclsDSTRichTextBoxValue;

					//备注
					strText = objCurrent.m_strREMARK_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objCurrent.m_strREMARK_RIGHT != objNext.m_strREMARK_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strREMARK_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[38] = objclsDSTRichTextBoxValue;

					//血常规>>WBC
					strText = objCurrent.m_strWBC_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objCurrent.m_strWBC_RIGHT != objNext.m_strWBC_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strWBC_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[39] = objclsDSTRichTextBoxValue;

					//血常规>>Hb
					strText = objCurrent.m_strHB_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objCurrent.m_strHB_RIGHT != objNext.m_strHB_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strHB_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[40] = objclsDSTRichTextBoxValue;

					//血常规>>RBC
					strText = objCurrent.m_strRBC_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objCurrent.m_strRBC_RIGHT != objNext.m_strRBC_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strRBC_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[41] = objclsDSTRichTextBoxValue;

					//血常规>>HCT
					strText = objCurrent.m_strHCT_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objCurrent.m_strHCT_RIGHT != objNext.m_strHCT_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strHCT_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[42] = objclsDSTRichTextBoxValue;

					//血常规>>PLT
					strText = objCurrent.m_strPLT_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objCurrent.m_strPLT_RIGHT != objNext.m_strPLT_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strPLT_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[43] = objclsDSTRichTextBoxValue;

					//血气>>PH
					strText = objCurrent.m_strPH_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objCurrent.m_strPH_RIGHT != objNext.m_strPH_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strPH_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[44] = objclsDSTRichTextBoxValue;

					//血气>>PCO2
					strText = objCurrent.m_strPCO2_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objCurrent.m_strPCO2_RIGHT != objNext.m_strPCO2_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strPCO2_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[45] = objclsDSTRichTextBoxValue;

					//血气>>PAO2
					strText = objCurrent.m_strPAO2_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objCurrent.m_strPAO2_RIGHT != objNext.m_strPAO2_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strPAO2_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[46] = objclsDSTRichTextBoxValue;

					//血气>>HCO3
					strText = objCurrent.m_strHCO3_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objCurrent.m_strHCO3_RIGHT != objNext.m_strHCO3_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strHCO3_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[47] = objclsDSTRichTextBoxValue;

					//血气>>BE
					strText = objCurrent.m_strBE_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objCurrent.m_strBE_RIGHT != objNext.m_strBE_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strBE_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[48] = objclsDSTRichTextBoxValue;

					//血电解质>>K+
					strText = objCurrent.m_strKPLUS_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objCurrent.m_strKPLUS_RIGHT != objNext.m_strKPLUS_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strKPLUS_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[49] = objclsDSTRichTextBoxValue;

					//血电解质>>Na+
					strText = objCurrent.m_strNAPLUS_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objCurrent.m_strNAPLUS_RIGHT != objNext.m_strNAPLUS_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strNAPLUS_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[50] = objclsDSTRichTextBoxValue;

					//血电解质>>CI-
					strText = objCurrent.m_strCISUB_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objCurrent.m_strCISUB_RIGHT != objNext.m_strCISUB_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strCISUB_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[51] = objclsDSTRichTextBoxValue;

					//血电解质>>Ca++
					strText = objCurrent.m_strCAPLUSPLUS_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objCurrent.m_strCAPLUSPLUS_RIGHT != objNext.m_strCAPLUSPLUS_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strCAPLUSPLUS_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[52] = objclsDSTRichTextBoxValue;

					//血电解质>>GLU
					strText = objCurrent.m_strGLU_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objCurrent.m_strGLU_RIGHT != objNext.m_strGLU_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strGLU_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[53] = objclsDSTRichTextBoxValue;

					//血液生化>>BUN
					strText = objCurrent.m_strBUN_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objCurrent.m_strBUN_RIGHT != objNext.m_strBUN_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strBUN_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[54] = objclsDSTRichTextBoxValue;

					//血液生化>>UA
					strText = objCurrent.m_strUA_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objCurrent.m_strUA_RIGHT != objNext.m_strUA_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strUA_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[55] = objclsDSTRichTextBoxValue;

					//血液生化>>肌酐
					strText = objCurrent.m_strANHYDRIDE_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objCurrent.m_strANHYDRIDE_RIGHT != objNext.m_strANHYDRIDE_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strANHYDRIDE_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[56] = objclsDSTRichTextBoxValue;

					//血液生化>>CO2CP
					strText = objCurrent.m_strCO2CP_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objCurrent.m_strCO2CP_RIGHT != objNext.m_strCO2CP_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strCO2CP_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[57] = objclsDSTRichTextBoxValue;

					//PT
					strText = objCurrent.m_strPT_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objCurrent.m_strPT_RIGHT != objNext.m_strPT_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strPT_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[58] = objclsDSTRichTextBoxValue;

					//X线检查
					strText = objCurrent.m_strXRAYCHECK_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objCurrent.m_strXRAYCHECK_RIGHT != objNext.m_strXRAYCHECK_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strXRAYCHECK_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[59] = objclsDSTRichTextBoxValue;

					//ACT
					strText = objCurrent.m_strACT_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objCurrent.m_strACT_RIGHT != objNext.m_strACT_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strACT_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[60] = objclsDSTRichTextBoxValue;

					//尿常规>>比重
					strText = objCurrent.m_strPROPORTION_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objCurrent.m_strPROPORTION_RIGHT != objNext.m_strPROPORTION_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strPROPORTION_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[61] = objclsDSTRichTextBoxValue;

					//尿常规>>蛋白
					strText = objCurrent.m_strALBUMEN_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objCurrent.m_strALBUMEN_RIGHT != objNext.m_strALBUMEN_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strALBUMEN_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[62] = objclsDSTRichTextBoxValue;

					//尿常规>>潜血
					strText = objCurrent.m_strHIDDENBLOOD_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objCurrent.m_strHIDDENBLOOD_RIGHT != objNext.m_strHIDDENBLOOD_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strHIDDENBLOOD_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[63] = objclsDSTRichTextBoxValue;

					//皮肤
					strText = objCurrent.m_strSKIN_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objCurrent.m_strSKIN_RIGHT != objNext.m_strSKIN_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strSKIN_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[64] = objclsDSTRichTextBoxValue;

					//会阴冲洗
					strText = objCurrent.m_strWASHPERINEUM_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objCurrent.m_strWASHPERINEUM_RIGHT != objNext.m_strWASHPERINEUM_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strWASHPERINEUM_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[65] = objclsDSTRichTextBoxValue;

					//擦浴
					strText = objCurrent.m_strBRUSHBATH_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objCurrent.m_strBRUSHBATH_RIGHT != objNext.m_strBRUSHBATH_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strBRUSHBATH_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[66] = objclsDSTRichTextBoxValue;

					//口腔护理
					strText = objCurrent.m_strMOUTHTEND_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objCurrent.m_strMOUTHTEND_RIGHT != objNext.m_strMOUTHTEND_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strMOUTHTEND_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[67] = objclsDSTRichTextBoxValue;
					
					objData[68] = objCurrent.m_strCreateUserID;
					objReturnData.Add(objData);

					object[] objMedicine = null;
					for(int j=1; j<intMedicine_PupilRows; j++)
					{
						objMedicine = new object[69];
						if(strEXPANDVASMEDICINE!=null && j<strEXPANDVASMEDICINE.Length && strEXPANDVASMEDICINE[j] != null && strEXPANDVASMEDICINE[j] != "")
						{
							strConArr = strEXPANDVASMEDICINE[j].Split('×');
                            if (strConArr.Length == 2)
                            {
                                strText = strConArr[0] + " " + strConArr[1];
                            }
                            else
                            {
                                strText = strConArr[0] + " " + strConArr[1] + " " + strConArr[2];
                            }
							
                            //if(objNext != null && objNext.m_strEXPANDVASMEDICINE_RIGHT != null && objNext.m_strEXPANDVASMEDICINE_RIGHT != "")
                            //{
                            //    strConArr = objNext.m_strEXPANDVASMEDICINE_RIGHT.Split('√')[j].Split('×');
                            //    if (strConArr.Length == 2)
                            //    {
                            //        strText = strConArr[0] + " " + strConArr[1];
                            //    }
                            //    else
                            //    {
                            //        strText = strConArr[0] + " " + strConArr[1] + " " + strConArr[2];
                            //    }
                            //}
							strXml = "<root />";
							if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && strText != strText)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
							{
								strXml = m_strGetDSTTextXML(strText ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
							}
							objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
							objclsDSTRichTextBoxValue.m_strText=strText;						
							objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
							objMedicine[20] = objclsDSTRichTextBoxValue;
						}
						if(strCARDIACDIURESIS!=null && j<strCARDIACDIURESIS.Length && strCARDIACDIURESIS[j] != null && strCARDIACDIURESIS[j] != "")
						{
							strConArr = strCARDIACDIURESIS[j].Split('×');

                            if (strConArr.Length == 2)
                            {
                                strText = strConArr[0] + " " + strConArr[1];
                            }
                            else
                            {
                                strText = strConArr[0] + " " + strConArr[1] + " " + strConArr[2];
                            }

                            //if(objNext != null && objNext.m_strCARDIACDIURESIS_RIGHT != null && objNext.m_strCARDIACDIURESIS_RIGHT != "")
                            //{
                            //    strConArr = objNext.m_strCARDIACDIURESIS_RIGHT.Split('√')[j].Split('×');
                            //    if (strConArr.Length == 2)
                            //    {
                            //        strText = strConArr[0] + " " + strConArr[1];
                            //    }
                            //    else
                            //    {
                            //        strText = strConArr[0] + " " + strConArr[1] + " " + strConArr[2];
                            //    }
                            //}
							strXml = "<root />";
							if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && strText != strText)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
							{
								strXml = m_strGetDSTTextXML(strText ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
							}
							objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
							objclsDSTRichTextBoxValue.m_strText=strText;						
							objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
							objMedicine[21] = objclsDSTRichTextBoxValue;
						}
						if(strOTHERMEDICINE!=null && j<strOTHERMEDICINE.Length && strOTHERMEDICINE[j] != null && strOTHERMEDICINE[j] != "")
						{
							strConArr = strOTHERMEDICINE[j].Split('×');
							//strText = strConArr[0] + " " + strConArr[1];
                            if (strConArr.Length == 2)
                            {
                                strText = strConArr[0] + " " + strConArr[1];
                            }
                            else
                            {
                                strText = strConArr[0] + " " + strConArr[1] + " " + strConArr[2];
                            }
                            //if(objNext != null && objNext.m_strOTHERMEDICINE_RIGHT != null && objNext.m_strOTHERMEDICINE_RIGHT != "")
                            //{
                            //    strConArr = objNext.m_strOTHERMEDICINE_RIGHT.Split('√')[j].Split('×');
                            //    if (strConArr.Length == 2)
                            //    {
                            //        strText = strConArr[0] + " " + strConArr[1];
                            //    }
                            //    else
                            //    {
                            //        strText = strConArr[0] + " " + strConArr[1] + " " + strConArr[2];
                            //    }
                            //}
							strXml = "<root />";
							if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && strText != strText)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
							{
								strXml = m_strGetDSTTextXML(strText ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
							}
							objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
							objclsDSTRichTextBoxValue.m_strText=strText;						
							objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
							objMedicine[22] = objclsDSTRichTextBoxValue;
						}
						if(j==1 && objCurrent.m_strLEFTPUPIL_RIGHT != null && objCurrent.m_strLEFTPUPIL_RIGHT != "")
						{
							//神智>>左瞳孔
							strText = objCurrent.m_strLEFTPUPIL_RIGHT;
                            //if(objNext != null)
                            //    strNext = objNext.m_strLEFTPUPIL_RIGHT;
							if(intMedicine_PupilRows < 3)
								intMedicine_PupilRows = 3;
							strXml = "<root />";
							if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && strText != strNext)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
							{
								strXml = m_strGetDSTTextXML(strText ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
							}
							objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
							objclsDSTRichTextBoxValue.m_strText=strText;						
							objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
							objMedicine[23] = objclsDSTRichTextBoxValue;
						}
						if(j==2 && objCurrent.m_strRIGHTPUPIL_RIGHT != null && objCurrent.m_strRIGHTPUPIL_RIGHT != "")
						{
							//神智>>右瞳孔
							strText = objCurrent.m_strRIGHTPUPIL_RIGHT;
                            //if(objNext != null)
                            //    strNext = objNext.m_strRIGHTPUPIL_RIGHT;
							if(intMedicine_PupilRows < 3)
								intMedicine_PupilRows = 3;
							strXml = "<root />";
							if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && strText != strNext)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
							{
								strXml = m_strGetDSTTextXML(strText ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
							}
							objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
							objclsDSTRichTextBoxValue.m_strText=strText;						
							objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
							objMedicine[23] = objclsDSTRichTextBoxValue;
						}
						objMedicine[68] = objCurrent.m_strCreateUserID;
						objReturnData.Add(objMedicine);
					}
					strEXPANDVASMEDICINE = null;//升压扩张血管药物
					strCARDIACDIURESIS = null;//强心利尿
					strOTHERMEDICINE = null;//其他药物
					#endregion
				}

				object[][] m_objRe=new object[objReturnData.Count][];

				for(int m=0;m<objReturnData.Count ;m++)
					m_objRe[m]=(object[])objReturnData[m];
				return m_objRe;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message );
				return null;
			}
			#endregion
		}

		protected override long m_lngSubAddNew()
		{
			clsCardiovascularBaseInfo_GX objNewInfo = m_objGetBaseInfoFromUI();
			long lngRes = 0;
			if(objNewInfo == null)
				return lngRes;

			DateTime dtmNow = DateTime.Now;
			objNewInfo.m_dtmOpenDate = dtmNow;
			objNewInfo.m_dtmCreateDate = dtmNow;
			objNewInfo.m_strCreateUserID = MDIParent.OperatorID;
			objNewInfo.m_strModifyUserID = MDIParent.OperatorID;
			objNewInfo.m_dtmModifyDate = dtmNow;
            objNewInfo.m_dtmInPatientDate = m_objCurrentPatient.m_DtmSelectedInDate;
			objNewInfo.m_strInPatientID = m_objCurrentPatient.m_StrInPatientID;

            clsCardiovascularTend_GXService m_objServ =
                (clsCardiovascularTend_GXService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsCardiovascularTend_GXService));
            
            lngRes = m_objServ.m_lngAddNewBaseInfo(objNewInfo);
            //m_objServ.Dispose();
			if(lngRes < 0)
				return (long)enmOperationResult.Parameter_Error;
			else
			{
				m_objCurrentContent = objNewInfo;
				m_mthGetAllInfo();
				m_cboAfterOpDays.SelectedItem = objNewInfo;
				return (long)enmOperationResult.DB_Succeed;
			}
		}

		protected override long m_lngSubModify()
		{
			clsCardiovascularBaseInfo_GX objNewInfo = m_objGetBaseInfoFromUI();
			long lngRes = 0;
			if(objNewInfo == null || m_objCurrentContent == null)
				return lngRes;

			DateTime dtmNow = DateTime.Now;
			objNewInfo.m_dtmOpenDate = m_objCurrentContent.m_dtmOpenDate;
			objNewInfo.m_dtmCreateDate = m_objCurrentContent.m_dtmCreateDate;
			objNewInfo.m_strCreateUserID = m_objCurrentContent.m_strCreateUserID;
			objNewInfo.m_strModifyUserID = MDIParent.OperatorID;
			objNewInfo.m_dtmModifyDate = dtmNow;
			objNewInfo.m_dtmInPatientDate = m_objCurrentContent.m_dtmInPatientDate;
			objNewInfo.m_strInPatientID = m_objCurrentContent.m_strInPatientID;

            clsCardiovascularTend_GXService m_objServ =
                (clsCardiovascularTend_GXService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsCardiovascularTend_GXService));

			lngRes = m_objServ.m_lngUpdateBaseInfo(objNewInfo);
            //m_objServ.Dispose();
			if(lngRes < 0)
				return (long)enmOperationResult.Parameter_Error;
			else
			{
				m_objCurrentContent = objNewInfo;
				m_mthGetAllInfo();
				m_cboAfterOpDays.SelectedItem = objNewInfo;
				return (long)enmOperationResult.DB_Succeed;
			}
		}

		protected override long m_lngSubDelete()
		{
			long lngRes = 0;
			if(m_objCurrentContent == null)
				return lngRes;
			string strInPatientID = m_objCurrentContent.m_strInPatientID;
			string strInPatientDate = m_objCurrentContent.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss");
			string strRecordDate = m_objCurrentContent.m_dtmRECORDDATE.ToString("yyyy-MM-dd HH:mm:ss");
			string strDeactiveDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			string strDeactiveOpID = MDIParent.strOperatorID;

            clsCardiovascularTend_GXService m_objServ =
                (clsCardiovascularTend_GXService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsCardiovascularTend_GXService));
            
			lngRes = m_objServ.m_lngDeleteBaseInfo(strInPatientID,strInPatientDate,strRecordDate,strDeactiveDate,strDeactiveOpID);
            
            if(lngRes > 0)
			{
				lngRes = m_objServ.m_lngDeleteDayTend(strInPatientID,strInPatientDate,strRecordDate,strDeactiveDate,strDeactiveOpID);
				m_mthGetAllInfo();
				m_cboAfterOpDays.SelectedIndex = 0;
			}
            //m_objServ.Dispose();
            return lngRes;
		}

		private void m_cboAfterOpDays_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_cboAfterOpDays.SelectedItem == null)
				return;
			try
			{
				m_objCurrentContent = (clsCardiovascularBaseInfo_GX)m_cboAfterOpDays.SelectedItem;
			}
			catch
			{
				m_objCurrentContent = null;
				if(m_intInsteadItems > 0)
					m_dtpRecordDate.Value = ((clsCardiovascularBaseInfo_GX)(m_cboAfterOpDays.GetItem(m_intSymbolIndex))).m_dtmRECORDDATE.AddDays(m_cboAfterOpDays.SelectedIndex - m_intSymbolIndex);
			}
			m_mthSetBaseInfoToUI();		

			m_mthShowData();
		}

		private void m_dtpRecordDate_evtValueChanged(object sender, System.EventArgs e)
		{
			clsCardiovascularBaseInfo_GX objBaseInfo = null;
			string m_strInPatientID = m_objCurrentPatient.m_StrInPatientID;
            string m_strInPatientDate = m_objCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss");

            clsCardiovascularTend_GXService m_objServ =
                (clsCardiovascularTend_GXService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsCardiovascularTend_GXService));
            
			long lngRes = m_objServ.m_lngGetBaseInfo(m_strInPatientID, m_strInPatientDate,
				m_dtpRecordDate.Value.ToString("yyyy-MM-dd 00:00:00"), out objBaseInfo);
            //m_objServ.Dispose();
			if(lngRes < 0 || objBaseInfo == null)
			{
				m_objCurrentContent = null;
				return;
			}
			m_objCurrentContent = objBaseInfo;
			m_cboAfterOpDays.SelectedItem = objBaseInfo;
            m_strCurrentOpenDate = objBaseInfo.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss");
		}

		protected override void m_trvInPatientDate_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			try
			{
				//清空病人记录信息				
				m_mthClearPatientRecordInfo();

				if(m_trvInPatientDate.SelectedNode==null || m_trvInPatientDate.SelectedNode==m_trvInPatientDate.Nodes[0] || m_objCurrentPatient==null)
				{						
					return;
				}
                //设置病人当次住院的基本信息
                m_mthOnlySetPatientInfo(m_objCurrentPatient);

                string m_strInPatientID = m_objCurrentPatient.m_ObjInBedInfo.m_objGetSessionByIndex(m_trvInPatientDate.Nodes[0].Nodes.Count - m_trvInPatientDate.SelectedNode.Index - 1).m_StrEMRInPatientID;
                string m_strInPatientDate = m_objCurrentPatient.m_ObjInBedInfo.m_objGetSessionByIndex(m_trvInPatientDate.Nodes[0].Nodes.Count - m_trvInPatientDate.SelectedNode.Index - 1).m_DtmEMRInDate.ToString("yyyy-MM-dd HH:mm:ss");

                txtInPatientID.Text = m_objCurrentPatient.m_ObjInBedInfo.m_objGetSessionByIndex(m_trvInPatientDate.Nodes[0].Nodes.Count - m_trvInPatientDate.SelectedNode.Index - 1).m_StrHISInPatientID;
                m_objCurrentPatient.m_DtmSelectedInDate = DateTime.Parse(m_strInPatientDate);
                m_objCurrentPatient.m_StrHISInPatientID = txtInPatientID.Text;
                m_objCurrentPatient.m_DtmSelectedHISInDate = Convert.ToDateTime(m_trvInPatientDate.SelectedNode.Text);

                #region 获取病人当次入院登记号
                string strRegisterID = "";

                com.digitalwave.PatientManagerService.clsPatientManagerService objServ =
                    (com.digitalwave.PatientManagerService.clsPatientManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.PatientManagerService.clsPatientManagerService));

                long lngRes = objServ.m_lngGetRegisterIDByPatient(m_objCurrentPatient.m_StrPatientID, m_objCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"), out strRegisterID);
                if (!string.IsNullOrEmpty(strRegisterID))
                {
                    com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR = strRegisterID;
                    m_objCurrentPatient.m_StrRegisterId = strRegisterID;
                    m_objBaseCurrentPatient.m_StrRegisterId = strRegisterID;
                }
                #endregion

                m_mthIsReadOnly();
                if (!m_blnCanShowRecordContent())
                {
                    clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                    return;
                }

				//获取病人记录列表
				m_mthGetAllInfo();
				if(m_cboAfterOpDays.GetItemsCount() > 0)
					m_cboAfterOpDays.SelectedIndex = 0;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
			}
		}

		private void m_mthSetBaseInfoToUI()
		{
			m_mthClearRecordInfo();
			if(m_objCurrentContent == null)
				return;

			m_txtWeight.Text = m_objCurrentContent.m_dblWEITHT.ToString();
			m_cboOpName.Text = m_objCurrentContent.m_strOPNAME;
			m_cboOpMedicine1.Text = m_objCurrentContent.m_strOPMEDICINE1;
			m_cboOpMedicine2.Text = m_objCurrentContent.m_strOPMEDICINE2;
			m_cboOpMedicine3.Text = m_objCurrentContent.m_strOPMEDICINE3;
			m_cboOpMedicine4.Text = m_objCurrentContent.m_strOPMEDICINE4;
			m_cboOpMedicine5.Text = m_objCurrentContent.m_strOPMEDICINE5;
//			m_cboAfterOpDays.Text = m_objCurrentContent.m_strAFTEROPDAYS;
			m_dtpRecordDate.Value = m_objCurrentContent.m_dtmRECORDDATE.Date;
            m_strCurrentOpenDate = m_objCurrentContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss");

            clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
            objEmployeeSign.m_lngGetEmpByNO(m_objCurrentContent.m_strLONGCLASSSIGNID, out objEmpVO);
            m_txtLongClassSign.Tag = objEmpVO;
            if (objEmpVO != null)
                m_txtLongClassSign.Text = objEmpVO.m_strLASTNAME_VCHR;

            objEmployeeSign.m_lngGetEmpByNO(m_objCurrentContent.m_strOFFICESIGNID, out objEmpVO);
            m_txtOfficeSign.Tag = objEmpVO;
            if (objEmpVO != null)
                m_txtOfficeSign.Text = objEmpVO.m_strLASTNAME_VCHR;

            objEmployeeSign.m_lngGetEmpByNO(m_objCurrentContent.m_strSMALLNIGHTCLASSSIGNID, out objEmpVO);
            m_txtSmallNightClassSign.Tag = objEmpVO;
            if (objEmpVO != null)
                m_txtSmallNightClassSign.Text = objEmpVO.m_strLASTNAME_VCHR;

            objEmployeeSign.m_lngGetEmpByNO(m_objCurrentContent.m_strBIGNIGHTCLASSSIGNID, out objEmpVO);
            m_txtBigNightClassSign.Tag = objEmpVO;
            if (objEmpVO != null)
                m_txtBigNightClassSign.Text = objEmpVO.m_strLASTNAME_VCHR;
		}

		private clsCardiovascularBaseInfo_GX m_objGetBaseInfoFromUI()
		{
			if(m_objCurrentPatient==null || m_ObjCurrentEmrPatientSession == null)				
				return null;

			clsCardiovascularBaseInfo_GX objInfo = new clsCardiovascularBaseInfo_GX();

			if(m_txtWeight.Text.Trim() != "")
				objInfo.m_dblWEITHT = double.Parse(m_txtWeight.Text.Trim());
			objInfo.m_strAFTEROPDAYS = m_cboAfterOpDays.Text;
			objInfo.m_strOPNAME = m_cboOpName.Text;
			objInfo.m_strOPMEDICINE1 = m_cboOpMedicine1.Text;
			objInfo.m_strOPMEDICINE2 = m_cboOpMedicine2.Text;
			objInfo.m_strOPMEDICINE3 = m_cboOpMedicine3.Text;
			objInfo.m_strOPMEDICINE4 = m_cboOpMedicine4.Text;
			objInfo.m_strOPMEDICINE5 = m_cboOpMedicine5.Text;
			if(m_txtLongClassSign.Tag != null)
				objInfo.m_strLONGCLASSSIGNID = ((clsEmrEmployeeBase_VO)m_txtLongClassSign.Tag).m_strEMPNO_CHR;
			if(m_txtOfficeSign.Tag != null)
                objInfo.m_strOFFICESIGNID = ((clsEmrEmployeeBase_VO)m_txtOfficeSign.Tag).m_strEMPNO_CHR;
			if(m_txtSmallNightClassSign.Tag != null)
                objInfo.m_strSMALLNIGHTCLASSSIGNID = ((clsEmrEmployeeBase_VO)m_txtSmallNightClassSign.Tag).m_strEMPNO_CHR;
			if(m_txtBigNightClassSign.Tag != null)
                objInfo.m_strBIGNIGHTCLASSSIGNID = ((clsEmrEmployeeBase_VO)m_txtBigNightClassSign.Tag).m_strEMPNO_CHR;

			objInfo.m_dtmRECORDDATE = DateTime.Parse( m_dtpRecordDate.Value.ToString("yyyy-MM-dd 00:00:00"));

			return objInfo;
		}

		private void m_txtWeight_Leave(object sender, System.EventArgs e)
		{
			if(m_txtWeight.Text.Trim() != "")
			{
				try
				{
					double.Parse(m_txtWeight.Text.Trim());
				}
				catch
				{
					MDIParent.ShowInformationMessageBox("体重须填写数字！");
					m_txtWeight.Clear();
				}
			}
		}

		protected override void m_mthSave()
		{
			if(m_cboAfterOpDays.Text.Trim() == "")
			{
				MDIParent.ShowInformationMessageBox("请填写手术后天数！");
				return;
			}
			int intSelected = m_cboAfterOpDays.SelectedIndex;
			if(m_BlnIsAddNew)
				m_lngSubAddNew();
			else
				m_lngSubModify();
			m_cboAfterOpDays.SelectedIndex = intSelected;
		}

		protected override void m_mthDelete()
		{
			m_lngSubDelete();
		}

		protected override bool m_BlnIsAddNew
		{
			get
			{
				clsCardiovascularBaseInfo_GX objBaseInfo = null;
				string m_strInPatientID = m_objCurrentPatient.m_StrInPatientID;
                string m_strInPatientDate = m_objCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss");

                clsCardiovascularTend_GXService m_objServ =
                    (clsCardiovascularTend_GXService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsCardiovascularTend_GXService));

				long lngRes = m_objServ.m_lngGetBaseInfo(m_strInPatientID, m_strInPatientDate,
					m_dtpRecordDate.Value.ToString("yyyy-MM-dd 00:00:00"), out objBaseInfo);
                //m_objServ.Dispose();
				if(lngRes < 0 || objBaseInfo == null)
					return true;
				else 
					return false;
			}
		}

		private bool m_blnIsFirst = true;
		private int m_intSymbolIndex = 0;//提供时间参照的索引
		private int m_intInsteadItems = 0;//默认ComboBox的Item被已有项目替换的数目
		private void m_mthGetAllInfo()
		{			
			clsCardiovascularBaseInfo_GX[] objBaseInfoArr;
			string m_strInPatientID = m_objCurrentPatient.m_StrInPatientID;
            string m_strInPatientDate = m_objCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss");
			m_intInsteadItems = 0;
			m_intSymbolIndex = 0;
            clsCardiovascularTend_GXService m_objServ =
                (clsCardiovascularTend_GXService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsCardiovascularTend_GXService));

			long lngRes = m_objServ.m_lngGetBaseInfo(m_strInPatientID,m_strInPatientDate,out objBaseInfoArr);
            //m_objServ.Dispose();
			if(lngRes <= 0 || objBaseInfoArr == null)
			{
				return;
			}
				
			m_cboAfterOpDays.ClearItem();
			m_mthAddCboDefaultItems();

			try
			{
				for(int i=0; i<objBaseInfoArr.Length; i++)
				{
					for(int j=0; j<10; j++)
					{
						if(objBaseInfoArr[i] != null && objBaseInfoArr[i].m_strAFTEROPDAYS.Trim() == m_cboAfterOpDays.GetItem(j).ToString().Trim())
						{
							m_cboAfterOpDays.InsertItem(j,objBaseInfoArr[i]);
							m_cboAfterOpDays.RemoveItemAt(j+1);
							objBaseInfoArr[i] = null;
							if(m_blnIsFirst)
							{
								m_intSymbolIndex = j;
								m_blnIsFirst = false;
							}
							m_intInsteadItems ++;
						}
					}
				}
				for(int i=0; i<objBaseInfoArr.Length; i++)
				{
					if(objBaseInfoArr[i] != null)
						m_cboAfterOpDays.AddItem(objBaseInfoArr[i]);
				}
			}
			catch
			{
			}
			finally
			{
				m_blnIsFirst = true;
			}
		}

		private void m_cboAfterOpDays_SelectedValueChanged(object sender, System.EventArgs e)
		{
			if(m_cboAfterOpDays.SelectedItem == null)
				return;
			try
			{
				m_objCurrentContent = (clsCardiovascularBaseInfo_GX)m_cboAfterOpDays.SelectedItem;
			}
			catch
			{
				m_objCurrentContent = null;
			}
			m_mthSetBaseInfoToUI();

			m_mthShowData();
		}

		private void m_mthShowData()
		{
			//获取病人记录列表
			if(m_objCurrentContent == null)
				return;
			m_dtbRecords.Rows.Clear();
			clsTransDataInfo[] objTansDataInfoArr = new clsTransDataInfo[1];
			clsCardiovascularTend_GXDataInfo objDataInfo = new clsCardiovascularTend_GXDataInfo();
			clsCardiovascularTend_GX [] objTend = null;
			string m_strInPatientID = m_objCurrentPatient.m_StrInPatientID;
            string m_strInPatientDate = m_objCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss");

            clsCardiovascularTend_GXMainService m_objMainServ =
                (clsCardiovascularTend_GXMainService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsCardiovascularTend_GXMainService));

			long lngRes = m_objMainServ.m_lngGetRecordContent(m_strInPatientID,m_strInPatientDate,
				m_objCurrentContent.m_dtmRECORDDATE.ToString("yyyy-MM-dd 00:00:00"), out objTend);
            //m_objMainServ.Dispose();
			objDataInfo.m_objRecordArr = objTend;
			objTansDataInfoArr[0] = objDataInfo;

			if(lngRes <= 0 || objTansDataInfoArr == null)
			{
				return;
			} 

			m_mthSortTransData(ref objTansDataInfoArr);

			DataTable dtbAddBlank;
			clsDiseaseTrackAddBlankDomain objAddBlankDomain = new clsDiseaseTrackAddBlankDomain();
			objAddBlankDomain.m_lngGetBlankRecordContent(m_objCurrentPatient.m_StrInPatientID,m_objCurrentPatient.m_DtmSelectedInDate,out dtbAddBlank);

			//添加记录到的DataTable
			object [][] objDataArr;
			for(int i1=0;i1<objTansDataInfoArr.Length;i1++)
			{ 
				if(dtbAddBlank !=null && dtbAddBlank.Rows.Count>0)
				{					
					//查找记录之前有否空行记录,有插入空行
					foreach(DataRow drtAdd in dtbAddBlank.Rows) 
					{
						if(objTansDataInfoArr[i1].m_objRecordContent !=null)
						{
							if(objTansDataInfoArr[i1].m_objRecordContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss") == DateTime.Parse(drtAdd["opendate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss"))
							{
								object[] objBlank = new object[5];
								objBlank[1] = 100;
								objBlank[2] = drtAdd[2].ToString();
								m_dtbRecords.Rows.Add(objBlank);
								for(int k3 = 0; k3 < (Int32.Parse( drtAdd[3].ToString())-1); k3++)
								{
									m_dtbRecords.Rows.Add(new object[]{});
								}
								break;
							}
						}
					}
				}
					
				objDataArr = m_objGetRecordsValueArr(objTansDataInfoArr[i1]);
					
				if(objDataArr==null)
					continue;
				//						return;
				for(int j2=0;j2<objDataArr.Length;j2++)
				{
					object[] obj = objDataArr[j2];
                    //if(!m_blnIsInitDataTable && objDataArr[j2].Length > 19)
                    //{
                    //    obj = new object[19];
                    //    for(int e3=0;e3<obj.Length;e3++)
                    //        obj[e3] = objDataArr[j2][e3];
                    //}
					m_dtbRecords.Rows.Add(obj);	
				}
                m_dtgRecordDetail.EnsureVisible(m_dtbRecords.Rows.Count - 1);
			}		

			if(m_dtbRecords.Rows.Count == 0 && !m_blnIfNewDeletedRecord)
			{
				m_mthAutoAddNewRecord();
			}
		}

		/// <summary>
		/// 默认添加至手术后第十天
		/// </summary>
		private void m_mthAddCboDefaultItems()
		{
			string [] strDefaultItemsArr = {"当","第一","第二","第三","第四","第五","第六","第七","第八","第九","第十",
											"第十一","第十二","第十三","第十四","第十五","第十六","第十七","第十八","第十九","第二十",
											"第二十一","第二十二","第二十三","第二十四","第二十五","第二十六","第二十七","第二十八","第二十九","第三十"};
			
			m_cboAfterOpDays.AddRangeItems(strDefaultItemsArr);
		}

		#region Jump Control
		protected override void m_mthInitJump(clsJumpControl p_objJump)
		{
			p_objJump=new clsJumpControl(this,
				new Control[]{m_txtWeight,m_cboOpName,m_cboOpMedicine1,m_cboOpMedicine2,m_cboOpMedicine3,m_cboOpMedicine4,m_cboOpMedicine5},Keys.Enter);
		}
		#endregion

        protected override void m_mthPerformSessionChanged(clsEmrPatientSessionInfo_VO p_objSelectedSession, int p_intIndex)
        {
            if (p_objSelectedSession == null) return;
            try
            {
                //清空病人记录信息	
                if (m_dtgRecordDetail != null)
                {
                    m_mthClearPatientRecordInfo();
                }

                if (p_objSelectedSession == null || m_objCurrentPatient == null)
                {
                    return;
                }

                m_objCurrentPatient.m_DtmSelectedInDate = p_objSelectedSession.m_dtmEMRInpatientDate;
                m_objCurrentPatient.m_StrHISInPatientID = p_objSelectedSession.m_strHISInpatientId;
                m_objCurrentPatient.m_DtmSelectedHISInDate = p_objSelectedSession.m_dtmHISInpatientDate;

                m_objCurrentPatient.m_StrRegisterId = p_objSelectedSession.m_strRegisterId;
                m_objBaseCurrentPatient.m_StrRegisterId = p_objSelectedSession.m_strRegisterId;

                //设置病人当次住院的基本信息
                m_mthOnlySetPatientInfo(m_objCurrentPatient);

                m_mthIsReadOnly();
                if (!m_blnCanShowRecordContent())
                {
                    clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                    return;
                }

                //获取病人记录列表
                m_mthGetAllInfo();
                if (m_cboAfterOpDays.GetItemsCount() > 0)
                    m_cboAfterOpDays.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }

//        private void m_cmdLoadAll_Click(object sender, System.EventArgs e)
//        {
//            this.Cursor = Cursors.WaitCursor;
////			m_dtbRecords.Rows.Clear();

//            m_dtbRecords.Columns.Add("OUTFACTGASTRICJUICE",typeof(clsDSTRichTextBoxValue));//19
//            m_dtbRecords.Columns.Add("EXPANDVASMEDICINE",typeof(clsDSTRichTextBoxValue));//20
//            m_dtbRecords.Columns.Add("CARDIACDIURESIS",typeof(clsDSTRichTextBoxValue));//21
//            m_dtbRecords.Columns.Add("OTHERMEDICINE",typeof(clsDSTRichTextBoxValue));//22
//            m_dtbRecords.Columns.Add("CONSCIOUSNESS_PUPIL",typeof(clsDSTRichTextBoxValue));//23
//            m_dtbRecords.Columns.Add("TEMPERATURE_TWIGTEMP",typeof(clsDSTRichTextBoxValue));//24
//            m_dtbRecords.Columns.Add("HEARTRATE_RHYTHM",typeof(clsDSTRichTextBoxValue));//25
//            m_dtbRecords.Columns.Add("BP_AVGBP",typeof(clsDSTRichTextBoxValue));//26
//            m_dtbRecords.Columns.Add("CVP_LAP",typeof(clsDSTRichTextBoxValue));//27
//            m_dtbRecords.Columns.Add("BREATHMACHINE_DEPTH",typeof(clsDSTRichTextBoxValue));//28
//            m_dtbRecords.Columns.Add("ASSISTANT",typeof(clsDSTRichTextBoxValue));//29
//            m_dtbRecords.Columns.Add("Fio2_IE",typeof(clsDSTRichTextBoxValue));//30
//            m_dtbRecords.Columns.Add("INSPIRATION_PEEP",typeof(clsDSTRichTextBoxValue));//31
//            m_dtbRecords.Columns.Add("TV_VF",typeof(clsDSTRichTextBoxValue));//32
//            m_dtbRecords.Columns.Add("BREATHTIMES",typeof(clsDSTRichTextBoxValue));//33
//            m_dtbRecords.Columns.Add("BREATHVOICE",typeof(clsDSTRichTextBoxValue));//34
//            m_dtbRecords.Columns.Add("PHLEGM",typeof(clsDSTRichTextBoxValue));//35
//            m_dtbRecords.Columns.Add("GESTICULATION_PHYSICAL",typeof(clsDSTRichTextBoxValue));//36
//            m_dtbRecords.Columns.Add("REMARK",typeof(clsDSTRichTextBoxValue));//37
//            m_dtbRecords.Columns.Add("WBC",typeof(clsDSTRichTextBoxValue));//38
//            m_dtbRecords.Columns.Add("Hb",typeof(clsDSTRichTextBoxValue));//39
//            m_dtbRecords.Columns.Add("RBC",typeof(clsDSTRichTextBoxValue));//40
//            m_dtbRecords.Columns.Add("HCT",typeof(clsDSTRichTextBoxValue));//41
//            m_dtbRecords.Columns.Add("PLT",typeof(clsDSTRichTextBoxValue));//42
//            m_dtbRecords.Columns.Add("PH",typeof(clsDSTRichTextBoxValue));//43
//            m_dtbRecords.Columns.Add("PCO2",typeof(clsDSTRichTextBoxValue));//44
//            m_dtbRecords.Columns.Add("PAO2",typeof(clsDSTRichTextBoxValue));//45
//            m_dtbRecords.Columns.Add("HCO3",typeof(clsDSTRichTextBoxValue));//46
//            m_dtbRecords.Columns.Add("BE",typeof(clsDSTRichTextBoxValue));//47
//            m_dtbRecords.Columns.Add("KPLUS",typeof(clsDSTRichTextBoxValue));//48
//            m_dtbRecords.Columns.Add("NAPLUS",typeof(clsDSTRichTextBoxValue));//49
//            m_dtbRecords.Columns.Add("CISUB",typeof(clsDSTRichTextBoxValue));//50
//            m_dtbRecords.Columns.Add("CAPLUSPLUS",typeof(clsDSTRichTextBoxValue));//51
//            m_dtbRecords.Columns.Add("GLU",typeof(clsDSTRichTextBoxValue));//52
//            m_dtbRecords.Columns.Add("BUN",typeof(clsDSTRichTextBoxValue));//53
//            m_dtbRecords.Columns.Add("UA",typeof(clsDSTRichTextBoxValue));//54
//            m_dtbRecords.Columns.Add("ANHYDRIDE",typeof(clsDSTRichTextBoxValue));//55
//            m_dtbRecords.Columns.Add("CO2CP",typeof(clsDSTRichTextBoxValue));//56
//            m_dtbRecords.Columns.Add("PT",typeof(clsDSTRichTextBoxValue));//57
//            m_dtbRecords.Columns.Add("XRAYCHECK",typeof(clsDSTRichTextBoxValue));//58
//            m_dtbRecords.Columns.Add("ACT",typeof(clsDSTRichTextBoxValue));//59
//            m_dtbRecords.Columns.Add("PROPORTION",typeof(clsDSTRichTextBoxValue));//60
//            m_dtbRecords.Columns.Add("ALBUMEN",typeof(clsDSTRichTextBoxValue));//61
//            m_dtbRecords.Columns.Add("HIDDENBLOOD",typeof(clsDSTRichTextBoxValue));//62
//            m_dtbRecords.Columns.Add("SKIN",typeof(clsDSTRichTextBoxValue));//63
//            m_dtbRecords.Columns.Add("WASHPERINEUM",typeof(clsDSTRichTextBoxValue));//64
//            m_dtbRecords.Columns.Add("BRUSHBATH",typeof(clsDSTRichTextBoxValue));//65
//            m_dtbRecords.Columns.Add("MOUTHTEND",typeof(clsDSTRichTextBoxValue));//66
//            m_dtbRecords.Columns.Add("RecordSign");

//            m_mthSetControl(m_clmRecordTime);
//            m_mthSetControl(m_dtcINFACT1);
//            m_mthSetControl(m_dtcINFACT2);
//            m_mthSetControl(m_dtcINFACT3);
//            m_mthSetControl(m_dtcINFACT4);
//            m_mthSetControl(m_dtcINFACT5);
//            m_mthSetControl(m_dtcINBLOOD);
//            m_mthSetControl(m_dtcINPERHOUR);
//            m_mthSetControl(m_dtcINSUM);
//            m_mthSetControl(m_dtcOUTSUM);
//            m_mthSetControl(m_dtcOUTPERHOUR);
//            m_mthSetControl(m_dtcOUTFACTPISSSUM);
//            m_mthSetControl(m_dtcOUTFACTPISS);
//            m_mthSetControl(m_dtcOUTFACTCHESTJUICE);
//            m_mthSetControl(m_dtcOUTFACTCHESTJUICESUM);
//            m_mthSetControl(m_dtcOUTFACTGASTRICJUICE);
//            m_mthSetControl(m_dtcEXPANDVASMEDICINE);
//            m_mthSetControl(m_dtcCARDIACDIURESIS);
//            m_mthSetControl(m_dtcOTHERMEDICINE);
//            m_mthSetControl(m_dtcCONSCIOUSNESS_PUPIL);
//            m_mthSetControl(m_dtcTEMPERATURE_TWIGTEMP);
//            m_mthSetControl(m_dtcHEARTRATE_RHYTHM);
//            m_mthSetControl(m_dtcBP_AVGBP);
//            m_mthSetControl(m_dtcCVP_LAP);
//            m_mthSetControl(m_dtcBREATHMACHINE_DEPTH);
//            m_mthSetControl(m_dtcASSISTANT);
//            m_mthSetControl(m_dtcFio2_IE);
//            m_mthSetControl(m_dtcINSPIRATION_PEEP);
//            m_mthSetControl(m_dtcTV_VF);
//            m_mthSetControl(m_dtcBREATHTIMES);
//            m_mthSetControl(m_dtcBREATHVOICE);
//            m_mthSetControl(m_dtcPHLEGM);
//            m_mthSetControl(m_dtcGESTICULATION_PHYSICAL);
//            m_mthSetControl(m_dtcREMARK);
//            m_mthSetControl(m_dtcWBC);
//            m_mthSetControl(m_dtcHb);
//            m_mthSetControl(m_dtcRBC);
//            m_mthSetControl(m_dtcHCT);
//            m_mthSetControl(m_dtcPLT);
//            m_mthSetControl(m_dtcPH);
//            m_mthSetControl(m_dtcPCO2);
//            m_mthSetControl(m_dtcPAO2);
//            m_mthSetControl(m_dtcHCO3);
//            m_mthSetControl(m_dtcBE);
//            m_mthSetControl(m_dtcKPLUS);
//            m_mthSetControl(m_dtcNAPLUS);
//            m_mthSetControl(m_dtcCISUB);
//            m_mthSetControl(m_dtcCAPLUSPLUS);
//            m_mthSetControl(m_dtcGLU);
//            m_mthSetControl(m_dtcBUN);
//            m_mthSetControl(m_dtcUA);
//            m_mthSetControl(m_dtcANHYDRIDE);
//            m_mthSetControl(m_dtcCO2CP);
//            m_mthSetControl(m_dtcPT);
//            m_mthSetControl(m_dtcXRAYCHECK);
//            m_mthSetControl(m_dtcACT);
//            m_mthSetControl(m_dtcPROPORTION);
//            m_mthSetControl(m_dtcALBUMEN);
//            m_mthSetControl(m_dtcHIDDENBLOOD);
//            m_mthSetControl(m_dtcSKIN);
//            m_mthSetControl(m_dtcWASHPERINEUM);
//            m_mthSetControl(m_dtcBRUSHBATH);
//            m_mthSetControl(m_dtcMOUTHTEND);

			
//            this.m_clmRecordTime.HeaderText = "\r\n时\r\n\r\n间";
//            this.m_dtcINFACT1.HeaderText = "\r\n实\r\n入\r\n量\r\n\r\n1";
//            this.m_dtcINFACT2.HeaderText = "\r\n实\r\n入\r\n量\r\n\r\n2";
//            this.m_dtcINFACT3.HeaderText = "\r\n实\r\n入\r\n量\r\n\r\n3";
//            this.m_dtcINFACT4.HeaderText = "\r\n实\r\n入\r\n量\r\n\r\n4";
//            this.m_dtcINFACT5.HeaderText = "\r\n实\r\n入\r\n量\r\n\r\n5";
//            this.m_dtcINBLOOD.HeaderText = "\r\n实\r\n入\r\n量\r\n全血\r\n/血浆";
//            this.m_dtcINPERHOUR.HeaderText = "\r\n入量\r\n\r\n每\r\n\r\n时";
//            this.m_dtcINSUM.HeaderText = "\r\n入量\r\n\r\n总\r\n\r\n量";
//            this.m_dtcOUTSUM.HeaderText = "\r\n出量\r\n\r\n总\r\n\r\n量";
//            this.m_dtcOUTPERHOUR.HeaderText = "\r\n出量\r\n\r\n每\r\n\r\n时";
//            this.m_dtcOUTFACTPISSSUM.HeaderText = "\r\n实\r\n出\r\n量\r\n累积\r\n尿量";
//            this.m_dtcOUTFACTPISS.HeaderText = "\r\n实\r\n出\r\n量\r\n\r\n尿量";
//            this.m_dtcOUTFACTCHESTJUICE.HeaderText = "\r\n实\r\n出\r\n量\r\n\r\n胸液";
//            this.m_dtcOUTFACTCHESTJUICESUM.HeaderText = "\r\n实\r\n出\r\n量\r\n积累\r\n胸液";
//            this.m_dtcOUTFACTGASTRICJUICE.HeaderText = "\r\n实\r\n出\r\n量\r\n\r\n胃液";
//            this.m_dtcEXPANDVASMEDICINE.HeaderText = "\r\n升压扩张\r\n血管药物\r\nug/kg/min";
//            this.m_dtcCARDIACDIURESIS.HeaderText = "\r\n\r\n强心利尿";
//            this.m_dtcOTHERMEDICINE.HeaderText = "\r\n\r\n其他药物";
//            this.m_dtcCONSCIOUSNESS_PUPIL.HeaderText = "\r\n神\r\n智\r\n意识\r\n/瞳孔";
//            this.m_dtcTEMPERATURE_TWIGTEMP.HeaderText = "\r\n循\r\n环\r\n体温\r\n/末梢温";
//            this.m_dtcHEARTRATE_RHYTHM.HeaderText = "\r\n循\r\n环\r\n心率\r\n/心律";
//            this.m_dtcBP_AVGBP.HeaderText = "\r\n循\r\n环\r\n血压\r\n/平均压";
//            this.m_dtcCVP_LAP.HeaderText = "\r\n循\r\n环\r\nCVP\r\n/LAP";
//            this.m_dtcBREATHMACHINE_DEPTH.HeaderText = "\r\n呼\r\n吸\r\n呼吸机\r\n型号\r\n/插管\r\n/  深度";
//            this.m_dtcASSISTANT.HeaderText = "\r\n呼\r\n吸\r\n辅助\r\n\r\n方式";
//            this.m_dtcFio2_IE.HeaderText = "\r\n呼\r\n吸\r\nFiO2\r\n(%)\r\n  /I:E";
//            this.m_dtcINSPIRATION_PEEP.HeaderText = "\r\n呼\r\n吸\r\n吸气\r\n压\r\n/PEEP\r\n/(CmH2O)";
//            this.m_dtcTV_VF.HeaderText = "\r\n呼\r\n吸\r\nTV  \r\nml/  \r\n/VF";
//            this.m_dtcBREATHTIMES.HeaderText = "\r\n呼\r\n吸\r\n次\r\n数";
//            this.m_dtcBREATHVOICE.HeaderText = "\r\n呼\r\n吸\r\n次\r\n左/右";
//            this.m_dtcPHLEGM.HeaderText = "\r\n痰色\r\n/痰量";
//            this.m_dtcGESTICULATION_PHYSICAL.HeaderText = "\r\n体位\r\n/理疗";
//            this.m_dtcREMARK.HeaderText = "\r\n\r\n备    注";
//            this.m_dtcWBC.HeaderText = "\r\n血\r\n常\r\n规\r\nWBC";
//            this.m_dtcHb.HeaderText = "\r\n血\r\n常\r\n规\r\nHb";
//            this.m_dtcRBC.HeaderText = "\r\n血\r\n常\r\n规\r\nRBC";
//            this.m_dtcHCT.HeaderText = "\r\n血\r\n常\r\n规\r\nHCT";
//            this.m_dtcPLT.HeaderText = "\r\n血\r\n常\r\n规\r\nPLT";
//            this.m_dtcPH.HeaderText = "\r\n血\r\n\r\n气\r\nPH";
//            this.m_dtcPCO2.HeaderText = "\r\n血\r\n\r\n气\r\nPCO2";
//            this.m_dtcPAO2.HeaderText = "\r\n血\r\n\r\n气\r\nPaO2";
//            this.m_dtcHCO3.HeaderText = "\r\n血\r\n\r\n气\r\nHCO3";
//            this.m_dtcBE.HeaderText = "\r\n血\r\n\r\n气\r\nBE";
//            this.m_dtcKPLUS.HeaderText = "\r\n血\r\n电\r\n解\r\n质\r\nK+";
//            this.m_dtcNAPLUS.HeaderText = "\r\n血\r\n电\r\n解\r\n质\r\nNa+";
//            this.m_dtcCISUB.HeaderText = "\r\n血\r\n电\r\n解\r\n质\r\nCI-";
//            this.m_dtcCAPLUSPLUS.HeaderText = "\r\n血\r\n电\r\n解\r\n质\r\nCa++";
//            this.m_dtcGLU.HeaderText = "\r\n血\r\n电\r\n解\r\n质\r\nGLU";
//            this.m_dtcBUN.HeaderText = "\r\n血\r\n液\r\n生\r\n化\r\nBUN";
//            this.m_dtcUA.HeaderText = "\r\n血\r\n液\r\n生\r\n化\r\nUA";
//            this.m_dtcANHYDRIDE.HeaderText = "\r\n血\r\n液\r\n生\r\n化\r\n肌酐";
//            this.m_dtcCO2CP.HeaderText = "\r\n血\r\n液\r\n生\r\n化\r\nCO2CP";
//            this.m_dtcPT.HeaderText = "\r\n\r\nPT";
//            this.m_dtcXRAYCHECK.HeaderText = "\r\n\r\nX  线\r\n检  查";
//            this.m_dtcACT.HeaderText = "\r\n\r\nACT";
//            this.m_dtcPROPORTION.HeaderText = "\r\n尿\r\n常\r\n规\r\n比重";
//            this.m_dtcALBUMEN.HeaderText = "\r\n尿\r\n常\r\n规\r\n蛋白";
//            this.m_dtcHIDDENBLOOD.HeaderText = "\r\n尿\r\n常\r\n规\r\n潜血";
//            this.m_dtcSKIN.HeaderText = "\r\n皮\r\n\r\n\r\n肤";
//            this.m_dtcWASHPERINEUM.HeaderText = "\r\n会\r\n阴\r\n冲\r\n洗";
//            this.m_dtcBRUSHBATH.HeaderText = "\r\n擦\r\n\r\n\r\n浴";
//            this.m_dtcMOUTHTEND.HeaderText = "\r\n口\r\n腔\r\n护\r\n理";

//            m_blnIsInitDataTable = true;
//            m_cmdLoadAll.Enabled = false;
//            m_dtmPreRecordDate = DateTime.MinValue;
//            if(m_objCurrentPatient != null)
//                m_mthShowData();
			
//            this.Cursor = Cursors.Default;
//        }

		/// <summary>
		/// 设置需要添加事件的ComboBox
		/// </summary>
		private void m_mthSetComboBoxItem()
		{
			m_mthAssociateComboBoxItemEvent(m_cboOpName);
			m_mthAssociateComboBoxItemEvent(m_cboOpMedicine1);
			m_mthAssociateComboBoxItemEvent(m_cboOpMedicine2);
			m_mthAssociateComboBoxItemEvent(m_cboOpMedicine3);
			m_mthAssociateComboBoxItemEvent(m_cboOpMedicine4);
			m_mthAssociateComboBoxItemEvent(m_cboOpMedicine5);
		}

		protected override void m_mthEvent_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch(e.KeyCode)
			{//F1 112  帮助, F2 113 Save，F3  114 Del，F4 115 Print，F5 116 Refresh，F6 117 Search
				case Keys.Enter:// enter				
					break;
				case Keys.Up:
					break;		
				case Keys.F2://save
					this.Save(); 
					break;
				case Keys.F3://del
					break;
				case Keys.F4://print
					this.m_lngSubPrint();
					break;
				case Keys.F5://refresh
					m_mthClearAll();
					break;
				case Keys.F6://Search
					break;
				case Keys.F7:
                    //if(m_cmdLoadAll.Enabled)
                    //{
                    //    m_cmdLoadAll_Click(null,null);
                    //}
					break;
			}
        }
        protected override  void m_mthDemoPrint_FromDataSource()
        {
            objPrintTool = m_objGetPrintTool();//new clsIntensiveTendMainPrintTool();
            if (objPrintTool == null)
            {
                //						clsPublicFunction.ShowInformationMessageBox("请重载m_objGetPrintTool()函数！");
                return;
            }
            objPrintTool.m_mthInitPrintTool(null);
            if (m_objBaseCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
            {
                //objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, DateTime.MinValue, DateTime.MinValue);
                clsPublicFunction.ShowInformationMessageBox("病人及其住院记录不能为空!");
                return;
            }
            else
                objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate, DateTime.Parse(m_strCurrentOpenDate));

            objPrintTool.m_mthInitPrintContent();

            m_mthStartPrint();
        }
        protected override infPrintRecord m_objGetPrintTool()
        {
            return new clsCardiovascularTendPrintTool();
        }

        protected override void m_mthStartPrint()
        {
            //缺省使用打印预览，子窗体重载提供新的实现
            PageSetupDialog psd = new PageSetupDialog();
            try
            {
                if (m_pdcPrintDocument.DefaultPageSettings == null)
                {
                    m_pdcPrintDocument.DefaultPageSettings = new PageSettings();
                }
                m_pdcPrintDocument.DefaultPageSettings.Landscape = true;
                m_pdcPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("A3", 1150, 1620);

                psd.PageSettings = m_pdcPrintDocument.DefaultPageSettings;

                if (psd.ShowDialog() != DialogResult.Cancel)
                {
                    m_pdcPrintDocument.DefaultPageSettings.Landscape = psd.PageSettings.Landscape;
                    m_pdcPrintDocument.DefaultPageSettings.PaperSize = psd.PageSettings.PaperSize;
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("No Printers installed") >= 0)
                    clsPublicFunction.ShowInformationMessageBox("找不到打印机！");
                else MessageBox.Show(ex.Message);
            }

            base.m_mthStartPrint();

        }

	}
}
