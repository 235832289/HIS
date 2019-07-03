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
using com.digitalwave.clsGeneralNurseRecord_GXService;
namespace iCare
{
	/// <summary>
	/// frmSurgeryICUWardship 的摘要说明。
	/// </summary>
	public class frmSurgeryICUWardship  : iCare.frmRecordsBase
	{

		#region
		private DataTable dtTempTable;
		private string m_strCurrentOpenDate = "";
		private string m_strCreateUserID = "";
		
		private System.Windows.Forms.DataGridTextBoxColumn clmRecordDateofDay;
		private System.Windows.Forms.DataGridTextBoxColumn clmCreateTime;
		private cltDataGridDSTRichTextBox m_dtcPBODYPART;
		private cltDataGridDSTRichTextBox m_dtcPCONSCIOUSNESS;
		private cltDataGridDSTRichTextBox m_dtcPPUPIL;
		private cltDataGridDSTRichTextBox m_dtcPREFLECT;
		private cltDataGridDSTRichTextBox m_dtcCTEMPERATURE;
		private System.Windows.Forms.DataGridTextBoxColumn clmSign;
		private cltDataGridDSTRichTextBox m_dtcCSMALLTEMPERATURE;
		private cltDataGridDSTRichTextBox m_dtcCHEARTRATE ;
		private cltDataGridDSTRichTextBox m_dtcCHEARTRHYTHM;
		private cltDataGridDSTRichTextBox m_dtcCSD;
		private cltDataGridDSTRichTextBox m_dtcCCVP;
		private cltDataGridDSTRichTextBox m_dtmRECORDDATE;

		private cltDataGridDSTRichTextBox m_dtcDPHYSIC1;
		private cltDataGridDSTRichTextBox m_dtcDPHYSIC2;
		private cltDataGridDSTRichTextBox m_dtcDPHYSIC3;
		private cltDataGridDSTRichTextBox m_dtcDPHYSIC4;
		private cltDataGridDSTRichTextBox m_dtcDPHYSIC5;
		private cltDataGridDSTRichTextBox m_dtcDPHYSIC6;
		private cltDataGridDSTRichTextBox m_dtcDPHYSIC7;
		private cltDataGridDSTRichTextBox m_dtcDPHYSIC8;

		private cltDataGridDSTRichTextBox m_dtcIBLOODPRODUCE;
		
		private cltDataGridDSTRichTextBox m_dtcIGS;
		
		private cltDataGridDSTRichTextBox m_dtcINS;
		private cltDataGridDSTRichTextBox m_dtcINNAME1;
		private cltDataGridDSTRichTextBox m_dtcINNAME2;
		private cltDataGridDSTRichTextBox m_dtcINNAME3;
		private cltDataGridDSTRichTextBox m_dtcINNAME4;
	
		private cltDataGridDSTRichTextBox m_dtcINTATAL ;
		private cltDataGridDSTRichTextBox m_dtcOTATAL;
		private cltDataGridDSTRichTextBox m_dtcOEMIEMCTION;
		private cltDataGridDSTRichTextBox m_dtcOGASTRICJUICE;
		private cltDataGridDSTRichTextBox m_dtcOUTNAME1;
		private cltDataGridDSTRichTextBox m_dtcOUTNAME2;
		private cltDataGridDSTRichTextBox m_dtcOUTNAME3;
		private cltDataGridDSTRichTextBox m_dtcOUTNAME4;

		private cltDataGridDSTRichTextBox m_dtcSESPECIALLYNOTE;
		private cltDataGridDSTRichTextBox m_dtcBBLUSETIME;
		private cltDataGridDSTRichTextBox m_dtcBBLUSEMACHINETYPE ;
		private cltDataGridDSTRichTextBox m_dtcBBLUSEMODE;
		private cltDataGridDSTRichTextBox m_dtcBVT;
		private cltDataGridDSTRichTextBox m_dtcBEXPIREDMV;
		private cltDataGridDSTRichTextBox m_dtcBBLUESPRESSURE;

		private cltDataGridDSTRichTextBox m_dtcBBLUSENUM;
		private cltDataGridDSTRichTextBox m_dtcBFIO2PEEP ;
		
		private cltDataGridDSTRichTextBox m_dtcBMAXIP;
		private cltDataGridDSTRichTextBox m_dtcBBLUSESOUND;
		private cltDataGridDSTRichTextBox m_dtcBPHLEGMCOLOR;
		
		private cltDataGridDSTRichTextBox m_dtcBSQ2;
		private cltDataGridDSTRichTextBox m_dtcTCOLLECTBLOODPOINT;
		private cltDataGridDSTRichTextBox m_dtcTPH ;
		private cltDataGridDSTRichTextBox m_dtcTPCO2;
		private cltDataGridDSTRichTextBox m_dtcTP02;
		private cltDataGridDSTRichTextBox m_dtcTHCO3;
		private cltDataGridDSTRichTextBox m_dtcTTCO2;

		private cltDataGridDSTRichTextBox m_dtcTBE;
		private cltDataGridDSTRichTextBox m_dtcTSAT ;
		private cltDataGridDSTRichTextBox m_dtcTO2CT;
		private cltDataGridDSTRichTextBox m_dtcSCMH2O;
		private cltDataGridDSTRichTextBox m_dtcSSD;
		private cltDataGridDSTRichTextBox m_dtcSMEAN;
		private cltDataGridDSTRichTextBox m_dtcSWEDGE;
		private cltDataGridDSTRichTextBox m_dtcSCOCI ;
	

		#endregion
        //private PinkieControls.ButtonXP m_cmdLoadAll;
		private bool m_blnIsInitDataTable = false;
        /*------------bill-------------------------*/
        private DataTable printTable = new DataTable();
        private ArrayList personMessageArr = new ArrayList();
        /*-********************************************-*/

		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmSurgeryICUWardship()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			dtTempTable = new DataTable("RecordDetail");
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
            this.clmRecordDateofDay = new System.Windows.Forms.DataGridTextBoxColumn();
            this.clmCreateTime = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_dtcPBODYPART = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcPCONSCIOUSNESS = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcPPUPIL = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcPREFLECT = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcCTEMPERATURE = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.clmSign = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_dtcCSMALLTEMPERATURE = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcCHEARTRATE = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcCHEARTRHYTHM = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcCSD = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcCCVP = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtmRECORDDATE = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcDPHYSIC1 = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcDPHYSIC2 = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcDPHYSIC3 = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcDPHYSIC4 = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcDPHYSIC5 = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcDPHYSIC6 = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcDPHYSIC7 = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcDPHYSIC8 = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcIGS = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcINS = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcINTATAL = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcOTATAL = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcOEMIEMCTION = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcOGASTRICJUICE = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcSESPECIALLYNOTE = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcBBLUSETIME = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcBBLUSEMACHINETYPE = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcBBLUSEMODE = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcBVT = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcBEXPIREDMV = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcBBLUESPRESSURE = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcBBLUSENUM = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcBFIO2PEEP = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcBMAXIP = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcBBLUSESOUND = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcBPHLEGMCOLOR = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcBSQ2 = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcTCOLLECTBLOODPOINT = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcTPH = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcTPCO2 = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcTP02 = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcTHCO3 = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcTTCO2 = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcTBE = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcTSAT = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcTO2CT = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcSCMH2O = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcSSD = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcSMEAN = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcSWEDGE = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcSCOCI = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcIBLOODPRODUCE = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcINNAME1 = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcINNAME2 = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcINNAME3 = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcINNAME4 = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcOUTNAME1 = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcOUTNAME2 = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcOUTNAME3 = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcOUTNAME4 = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgRecordDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtbRecords)).BeginInit();
            this.m_pnlNewBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgtsStyles
            // 
            this.dgtsStyles.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																										 this.clmRecordDateofDay,
																										 this.clmCreateTime,
																										 this.m_dtcPBODYPART,
																										 this.m_dtcPCONSCIOUSNESS,
																										 this.m_dtcPPUPIL,
																										 this.m_dtcPREFLECT,
																										 this.m_dtcCTEMPERATURE,
																										 this.clmSign,
																										 this.m_dtcCSMALLTEMPERATURE,
																										 this.m_dtcCHEARTRATE,
																										 this.m_dtcCHEARTRHYTHM,
																										 this.m_dtcCSD,
																										 this.m_dtcCCVP,
																										 this.m_dtcDPHYSIC1,
																										 this.m_dtcDPHYSIC2,
																										 this.m_dtcDPHYSIC3,
																										 this.m_dtcDPHYSIC4,
																										 this.m_dtcDPHYSIC5,
																										 this.m_dtcDPHYSIC6,
																										 this.m_dtcDPHYSIC7,
																										 this.m_dtcDPHYSIC8,
																										 this.m_dtcIBLOODPRODUCE,
																										 this.m_dtcIGS,
																										 this.m_dtcINS,
																										 this.m_dtcINNAME1,
																										 this.m_dtcINNAME2,
																										 this.m_dtcINNAME3,
																										 this.m_dtcINNAME4,
																										 this.m_dtcINTATAL,
																										 this.m_dtcOTATAL,
																										 this.m_dtcOEMIEMCTION,
																										 this.m_dtcOGASTRICJUICE,
																										 this.m_dtcOUTNAME1,
																										 this.m_dtcOUTNAME2,
																										 this.m_dtcOUTNAME3,
																										 this.m_dtcOUTNAME4,
																										 this.m_dtcSESPECIALLYNOTE,
																										 this.m_dtcBBLUSETIME,
																										 this.m_dtcBBLUSEMACHINETYPE,
																										 this.m_dtcBBLUSEMODE,
																										 this.m_dtcBVT,
																										 this.m_dtcBEXPIREDMV,
																										 this.m_dtcBBLUESPRESSURE,
																										 this.m_dtcBBLUSENUM,
																										 this.m_dtcBFIO2PEEP,
																										 this.m_dtcBMAXIP,
																										 this.m_dtcBBLUSESOUND,
																										 this.m_dtcBPHLEGMCOLOR,
																										 this.m_dtcBSQ2,
																										 this.m_dtcTCOLLECTBLOODPOINT,
																										 this.m_dtcTPH,
																										 this.m_dtcTPCO2,
																										 this.m_dtcTP02,
																										 this.m_dtcTHCO3,
																										 this.m_dtcTTCO2,
																										 this.m_dtcTBE,
																										 this.m_dtcTSAT,
																										 this.m_dtcTO2CT,
																										 this.m_dtcSCMH2O,
																										 this.m_dtcSSD,
																										 this.m_dtcSMEAN,
																										 this.m_dtcSWEDGE,
																										 this.m_dtcSCOCI});
            this.dgtsStyles.RowHeaderWidth = 15;
            // 
            // m_dtgRecordDetail
            // 
            this.m_dtgRecordDetail.BackgroundColor = System.Drawing.SystemColors.Control;
            this.m_dtgRecordDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_dtgRecordDetail.DataSource = this.m_dtbRecords;
            this.m_dtgRecordDetail.Location = new System.Drawing.Point(8, 77);
            this.m_dtgRecordDetail.RowHeaderWidth = 15;
            this.m_dtgRecordDetail.Size = new System.Drawing.Size(808, 536);
            // 
            // mniAppend
            // 
            this.mniAppend.Click += new System.EventHandler(this.mniAppend_Click);
            // 
            // m_trvInPatientDate
            // 
            this.m_trvInPatientDate.BackColor = System.Drawing.Color.White;
            this.m_trvInPatientDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_trvInPatientDate.ForeColor = System.Drawing.Color.Black;
            this.m_trvInPatientDate.LineColor = System.Drawing.Color.Black;
            this.m_trvInPatientDate.Location = new System.Drawing.Point(8, 76);
            this.m_trvInPatientDate.Visible = false;
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(768, 80);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(616, 112);
            this.lblAge.Size = new System.Drawing.Size(88, 19);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(436, 80);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(572, 80);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(436, 112);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(728, 80);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(576, 112);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(240, 112);
            this.lblAreaTitle.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(628, 78);
            this.txtInPatientID.Size = new System.Drawing.Size(96, 23);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(476, 110);
            this.m_txtPatientName.Size = new System.Drawing.Size(96, 23);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(476, 78);
            this.m_txtBedNO.Size = new System.Drawing.Size(72, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(288, 108);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(288, 147);
            this.m_lsvBedNO.Size = new System.Drawing.Size(92, 104);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(288, 76);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(240, 80);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(704, 103);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.Location = new System.Drawing.Point(548, 78);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(156, 80);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Visible = false;
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(666, 37);
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
            // clmRecordDateofDay
            // 
            this.clmRecordDateofDay.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.clmRecordDateofDay.Format = "";
            this.clmRecordDateofDay.FormatInfo = null;
            this.clmRecordDateofDay.MappingName = "RecordDateofDay";
            this.clmRecordDateofDay.Width = 80;
            // 
            // clmCreateTime
            // 
            this.clmCreateTime.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.clmCreateTime.Format = "";
            this.clmCreateTime.FormatInfo = null;
            this.clmCreateTime.MappingName = "RecordTime";
            this.clmCreateTime.Width = 50;
            // 
            // m_dtcPBODYPART
            // 
            this.m_dtcPBODYPART.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcPBODYPART.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcPBODYPART.m_BlnGobleSet = true;
            this.m_dtcPBODYPART.m_BlnUnderLineDST = false;
            this.m_dtcPBODYPART.MappingName = "PBODYPART";
            this.m_dtcPBODYPART.Width = 50;
            // 
            // m_dtcPCONSCIOUSNESS
            // 
            this.m_dtcPCONSCIOUSNESS.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcPCONSCIOUSNESS.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcPCONSCIOUSNESS.m_BlnGobleSet = true;
            this.m_dtcPCONSCIOUSNESS.m_BlnUnderLineDST = false;
            this.m_dtcPCONSCIOUSNESS.MappingName = "PCONSCIOUSNESS";
            this.m_dtcPCONSCIOUSNESS.Width = 50;
            // 
            // m_dtcPPUPIL
            // 
            this.m_dtcPPUPIL.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcPPUPIL.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcPPUPIL.m_BlnGobleSet = true;
            this.m_dtcPPUPIL.m_BlnUnderLineDST = false;
            this.m_dtcPPUPIL.MappingName = "PPUPIL";
            this.m_dtcPPUPIL.Width = 65;
            // 
            // m_dtcPREFLECT
            // 
            this.m_dtcPREFLECT.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcPREFLECT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcPREFLECT.m_BlnGobleSet = true;
            this.m_dtcPREFLECT.m_BlnUnderLineDST = false;
            this.m_dtcPREFLECT.MappingName = "PREFLECT";
            this.m_dtcPREFLECT.Width = 65;
            // 
            // m_dtcCTEMPERATURE
            // 
            this.m_dtcCTEMPERATURE.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcCTEMPERATURE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcCTEMPERATURE.m_BlnGobleSet = true;
            this.m_dtcCTEMPERATURE.m_BlnUnderLineDST = false;
            this.m_dtcCTEMPERATURE.MappingName = "CTEMPERATURE";
            this.m_dtcCTEMPERATURE.Width = 50;
            // 
            // clmSign
            // 
            this.clmSign.Format = "";
            this.clmSign.FormatInfo = null;
            this.clmSign.MappingName = "Sign";
            this.clmSign.Width = 0;
            // 
            // m_dtcCSMALLTEMPERATURE
            // 
            this.m_dtcCSMALLTEMPERATURE.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcCSMALLTEMPERATURE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcCSMALLTEMPERATURE.m_BlnGobleSet = true;
            this.m_dtcCSMALLTEMPERATURE.m_BlnUnderLineDST = false;
            this.m_dtcCSMALLTEMPERATURE.MappingName = "CSMALLTEMPERATURE";
            this.m_dtcCSMALLTEMPERATURE.Width = 50;
            // 
            // m_dtcCHEARTRATE
            // 
            this.m_dtcCHEARTRATE.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcCHEARTRATE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcCHEARTRATE.m_BlnGobleSet = true;
            this.m_dtcCHEARTRATE.m_BlnUnderLineDST = false;
            this.m_dtcCHEARTRATE.MappingName = "CHEARTRATE";
            this.m_dtcCHEARTRATE.Width = 50;
            // 
            // m_dtcCHEARTRHYTHM
            // 
            this.m_dtcCHEARTRHYTHM.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcCHEARTRHYTHM.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcCHEARTRHYTHM.m_BlnGobleSet = true;
            this.m_dtcCHEARTRHYTHM.m_BlnUnderLineDST = false;
            this.m_dtcCHEARTRHYTHM.MappingName = "CHEARTRHYTHM";
            this.m_dtcCHEARTRHYTHM.Width = 50;
            // 
            // m_dtcCSD
            // 
            this.m_dtcCSD.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcCSD.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcCSD.m_BlnGobleSet = true;
            this.m_dtcCSD.m_BlnUnderLineDST = false;
            this.m_dtcCSD.MappingName = "CSD";
            this.m_dtcCSD.Width = 50;
            // 
            // m_dtcCCVP
            // 
            this.m_dtcCCVP.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcCCVP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcCCVP.m_BlnGobleSet = true;
            this.m_dtcCCVP.m_BlnUnderLineDST = false;
            this.m_dtcCCVP.MappingName = "CCVP";
            this.m_dtcCCVP.Width = 50;
            // 
            // m_dtmRECORDDATE
            // 
            this.m_dtmRECORDDATE.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtmRECORDDATE.m_BlnGobleSet = true;
            this.m_dtmRECORDDATE.m_BlnUnderLineDST = false;
            this.m_dtmRECORDDATE.Width = -1;
            // 
            // m_dtcDPHYSIC1
            // 
            this.m_dtcDPHYSIC1.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcDPHYSIC1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcDPHYSIC1.m_BlnGobleSet = true;
            this.m_dtcDPHYSIC1.m_BlnUnderLineDST = false;
            this.m_dtcDPHYSIC1.MappingName = "DPHYSIC1";
            this.m_dtcDPHYSIC1.Width = 300;
            // 
            // m_dtcDPHYSIC2
            // 
            this.m_dtcDPHYSIC2.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcDPHYSIC2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcDPHYSIC2.m_BlnGobleSet = true;
            this.m_dtcDPHYSIC2.m_BlnUnderLineDST = false;
            this.m_dtcDPHYSIC2.MappingName = "DPHYSIC2";
            this.m_dtcDPHYSIC2.Width = 300;
            // 
            // m_dtcDPHYSIC3
            // 
            this.m_dtcDPHYSIC3.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcDPHYSIC3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcDPHYSIC3.m_BlnGobleSet = true;
            this.m_dtcDPHYSIC3.m_BlnUnderLineDST = false;
            this.m_dtcDPHYSIC3.MappingName = "DPHYSIC3";
            this.m_dtcDPHYSIC3.Width = 300;
            // 
            // m_dtcDPHYSIC4
            // 
            this.m_dtcDPHYSIC4.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcDPHYSIC4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcDPHYSIC4.m_BlnGobleSet = true;
            this.m_dtcDPHYSIC4.m_BlnUnderLineDST = false;
            this.m_dtcDPHYSIC4.MappingName = "DPHYSIC4";
            this.m_dtcDPHYSIC4.Width = 300;
            // 
            // m_dtcDPHYSIC5
            // 
            this.m_dtcDPHYSIC5.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcDPHYSIC5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcDPHYSIC5.m_BlnGobleSet = true;
            this.m_dtcDPHYSIC5.m_BlnUnderLineDST = false;
            this.m_dtcDPHYSIC5.MappingName = "DPHYSIC5";
            this.m_dtcDPHYSIC5.Width = 300;
            // 
            // m_dtcDPHYSIC6
            // 
            this.m_dtcDPHYSIC6.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcDPHYSIC6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcDPHYSIC6.m_BlnGobleSet = true;
            this.m_dtcDPHYSIC6.m_BlnUnderLineDST = false;
            this.m_dtcDPHYSIC6.MappingName = "DPHYSIC6";
            this.m_dtcDPHYSIC6.Width = 300;
            // 
            // m_dtcDPHYSIC7
            // 
            this.m_dtcDPHYSIC7.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcDPHYSIC7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcDPHYSIC7.m_BlnGobleSet = true;
            this.m_dtcDPHYSIC7.m_BlnUnderLineDST = false;
            this.m_dtcDPHYSIC7.MappingName = "DPHYSIC7";
            this.m_dtcDPHYSIC7.Width = 300;
            // 
            // m_dtcDPHYSIC8
            // 
            this.m_dtcDPHYSIC8.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcDPHYSIC8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcDPHYSIC8.m_BlnGobleSet = true;
            this.m_dtcDPHYSIC8.m_BlnUnderLineDST = false;
            this.m_dtcDPHYSIC8.MappingName = "DPHYSIC8";
            this.m_dtcDPHYSIC8.Width = 300;
            // 
            // m_dtcIGS
            // 
            this.m_dtcIGS.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcIGS.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcIGS.m_BlnGobleSet = true;
            this.m_dtcIGS.m_BlnUnderLineDST = false;
            this.m_dtcIGS.MappingName = "IGS";
            this.m_dtcIGS.Width = 50;
            // 
            // m_dtcINS
            // 
            this.m_dtcINS.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcINS.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcINS.m_BlnGobleSet = true;
            this.m_dtcINS.m_BlnUnderLineDST = false;
            this.m_dtcINS.MappingName = "INS";
            this.m_dtcINS.Width = 50;
            // 
            // m_dtcINTATAL
            // 
            this.m_dtcINTATAL.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcINTATAL.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcINTATAL.m_BlnGobleSet = true;
            this.m_dtcINTATAL.m_BlnUnderLineDST = false;
            this.m_dtcINTATAL.MappingName = "INTATAL";
            this.m_dtcINTATAL.Width = 50;
            // 
            // m_dtcOTATAL
            // 
            this.m_dtcOTATAL.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcOTATAL.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcOTATAL.m_BlnGobleSet = true;
            this.m_dtcOTATAL.m_BlnUnderLineDST = false;
            this.m_dtcOTATAL.MappingName = "OTATAL";
            this.m_dtcOTATAL.Width = 50;
            // 
            // m_dtcOEMIEMCTION
            // 
            this.m_dtcOEMIEMCTION.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcOEMIEMCTION.m_BlnGobleSet = true;
            this.m_dtcOEMIEMCTION.m_BlnUnderLineDST = false;
            this.m_dtcOEMIEMCTION.Width = 75;
            // 
            // m_dtcOGASTRICJUICE
            // 
            this.m_dtcOGASTRICJUICE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcOGASTRICJUICE.m_BlnGobleSet = true;
            this.m_dtcOGASTRICJUICE.m_BlnUnderLineDST = false;
            this.m_dtcOGASTRICJUICE.Width = 75;
            // 
            // m_dtcSESPECIALLYNOTE
            // 
            this.m_dtcSESPECIALLYNOTE.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcSESPECIALLYNOTE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcSESPECIALLYNOTE.m_BlnGobleSet = true;
            this.m_dtcSESPECIALLYNOTE.m_BlnUnderLineDST = false;
            this.m_dtcSESPECIALLYNOTE.MappingName = "SESPECIALLYNOTE";
            this.m_dtcSESPECIALLYNOTE.Width = 300;
            // 
            // m_dtcBBLUSETIME
            // 
            this.m_dtcBBLUSETIME.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcBBLUSETIME.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcBBLUSETIME.m_BlnGobleSet = true;
            this.m_dtcBBLUSETIME.m_BlnUnderLineDST = false;
            this.m_dtcBBLUSETIME.MappingName = "BBLUSETIME";
            this.m_dtcBBLUSETIME.Width = 50;
            // 
            // m_dtcBBLUSEMACHINETYPE
            // 
            this.m_dtcBBLUSEMACHINETYPE.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcBBLUSEMACHINETYPE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcBBLUSEMACHINETYPE.m_BlnGobleSet = true;
            this.m_dtcBBLUSEMACHINETYPE.m_BlnUnderLineDST = false;
            this.m_dtcBBLUSEMACHINETYPE.MappingName = "BBLUSEMACHINETYPE";
            this.m_dtcBBLUSEMACHINETYPE.Width = 50;
            // 
            // m_dtcBBLUSEMODE
            // 
            this.m_dtcBBLUSEMODE.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcBBLUSEMODE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcBBLUSEMODE.m_BlnGobleSet = true;
            this.m_dtcBBLUSEMODE.m_BlnUnderLineDST = false;
            this.m_dtcBBLUSEMODE.MappingName = "BBLUSEMODE";
            this.m_dtcBBLUSEMODE.Width = 50;
            // 
            // m_dtcBVT
            // 
            this.m_dtcBVT.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcBVT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcBVT.m_BlnGobleSet = true;
            this.m_dtcBVT.m_BlnUnderLineDST = false;
            this.m_dtcBVT.MappingName = "BVT";
            this.m_dtcBVT.Width = 50;
            // 
            // m_dtcBEXPIREDMV
            // 
            this.m_dtcBEXPIREDMV.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcBEXPIREDMV.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcBEXPIREDMV.m_BlnGobleSet = true;
            this.m_dtcBEXPIREDMV.m_BlnUnderLineDST = false;
            this.m_dtcBEXPIREDMV.MappingName = "BEXPIREDMV";
            this.m_dtcBEXPIREDMV.Width = 65;
            // 
            // m_dtcBBLUESPRESSURE
            // 
            this.m_dtcBBLUESPRESSURE.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcBBLUESPRESSURE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcBBLUESPRESSURE.m_BlnGobleSet = true;
            this.m_dtcBBLUESPRESSURE.m_BlnUnderLineDST = false;
            this.m_dtcBBLUESPRESSURE.MappingName = "BBLUESPRESSURE";
            this.m_dtcBBLUESPRESSURE.Width = 50;
            // 
            // m_dtcBBLUSENUM
            // 
            this.m_dtcBBLUSENUM.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcBBLUSENUM.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcBBLUSENUM.m_BlnGobleSet = true;
            this.m_dtcBBLUSENUM.m_BlnUnderLineDST = false;
            this.m_dtcBBLUSENUM.MappingName = "BBLUSENUM";
            this.m_dtcBBLUSENUM.Width = 50;
            // 
            // m_dtcBFIO2PEEP
            // 
            this.m_dtcBFIO2PEEP.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcBFIO2PEEP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcBFIO2PEEP.m_BlnGobleSet = true;
            this.m_dtcBFIO2PEEP.m_BlnUnderLineDST = false;
            this.m_dtcBFIO2PEEP.MappingName = "BFIO2PEEP";
            this.m_dtcBFIO2PEEP.Width = 65;
            // 
            // m_dtcBMAXIP
            // 
            this.m_dtcBMAXIP.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcBMAXIP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcBMAXIP.m_BlnGobleSet = true;
            this.m_dtcBMAXIP.m_BlnUnderLineDST = false;
            this.m_dtcBMAXIP.MappingName = "BMAXIP";
            this.m_dtcBMAXIP.Width = 50;
            // 
            // m_dtcBBLUSESOUND
            // 
            this.m_dtcBBLUSESOUND.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcBBLUSESOUND.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcBBLUSESOUND.m_BlnGobleSet = true;
            this.m_dtcBBLUSESOUND.m_BlnUnderLineDST = false;
            this.m_dtcBBLUSESOUND.MappingName = "BBLUSESOUND";
            this.m_dtcBBLUSESOUND.Width = 50;
            // 
            // m_dtcBPHLEGMCOLOR
            // 
            this.m_dtcBPHLEGMCOLOR.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcBPHLEGMCOLOR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcBPHLEGMCOLOR.m_BlnGobleSet = true;
            this.m_dtcBPHLEGMCOLOR.m_BlnUnderLineDST = false;
            this.m_dtcBPHLEGMCOLOR.MappingName = "BPHLEGMCOLOR";
            this.m_dtcBPHLEGMCOLOR.Width = 50;
            // 
            // m_dtcBSQ2
            // 
            this.m_dtcBSQ2.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcBSQ2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcBSQ2.m_BlnGobleSet = true;
            this.m_dtcBSQ2.m_BlnUnderLineDST = false;
            this.m_dtcBSQ2.MappingName = "BSQ2";
            this.m_dtcBSQ2.Width = 50;
            // 
            // m_dtcTCOLLECTBLOODPOINT
            // 
            this.m_dtcTCOLLECTBLOODPOINT.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcTCOLLECTBLOODPOINT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcTCOLLECTBLOODPOINT.m_BlnGobleSet = true;
            this.m_dtcTCOLLECTBLOODPOINT.m_BlnUnderLineDST = false;
            this.m_dtcTCOLLECTBLOODPOINT.MappingName = "TCOLLECTBLOODPOINT";
            this.m_dtcTCOLLECTBLOODPOINT.Width = 75;
            // 
            // m_dtcTPH
            // 
            this.m_dtcTPH.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcTPH.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcTPH.m_BlnGobleSet = true;
            this.m_dtcTPH.m_BlnUnderLineDST = false;
            this.m_dtcTPH.MappingName = "TPH";
            this.m_dtcTPH.Width = 50;
            // 
            // m_dtcTPCO2
            // 
            this.m_dtcTPCO2.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcTPCO2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcTPCO2.m_BlnGobleSet = true;
            this.m_dtcTPCO2.m_BlnUnderLineDST = false;
            this.m_dtcTPCO2.MappingName = "TPCO2";
            this.m_dtcTPCO2.Width = 50;
            // 
            // m_dtcTP02
            // 
            this.m_dtcTP02.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcTP02.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcTP02.m_BlnGobleSet = true;
            this.m_dtcTP02.m_BlnUnderLineDST = false;
            this.m_dtcTP02.MappingName = "TP02";
            this.m_dtcTP02.Width = 50;
            // 
            // m_dtcTHCO3
            // 
            this.m_dtcTHCO3.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcTHCO3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcTHCO3.m_BlnGobleSet = true;
            this.m_dtcTHCO3.m_BlnUnderLineDST = false;
            this.m_dtcTHCO3.MappingName = "THCO3";
            this.m_dtcTHCO3.Width = 50;
            // 
            // m_dtcTTCO2
            // 
            this.m_dtcTTCO2.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcTTCO2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcTTCO2.m_BlnGobleSet = true;
            this.m_dtcTTCO2.m_BlnUnderLineDST = false;
            this.m_dtcTTCO2.MappingName = "TTCO2";
            this.m_dtcTTCO2.Width = 50;
            // 
            // m_dtcTBE
            // 
            this.m_dtcTBE.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcTBE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcTBE.m_BlnGobleSet = true;
            this.m_dtcTBE.m_BlnUnderLineDST = false;
            this.m_dtcTBE.MappingName = "TBE";
            this.m_dtcTBE.Width = 50;
            // 
            // m_dtcTSAT
            // 
            this.m_dtcTSAT.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcTSAT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcTSAT.m_BlnGobleSet = true;
            this.m_dtcTSAT.m_BlnUnderLineDST = false;
            this.m_dtcTSAT.MappingName = "TSAT";
            this.m_dtcTSAT.Width = 50;
            // 
            // m_dtcTO2CT
            // 
            this.m_dtcTO2CT.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcTO2CT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcTO2CT.m_BlnGobleSet = true;
            this.m_dtcTO2CT.m_BlnUnderLineDST = false;
            this.m_dtcTO2CT.MappingName = "TO2CT";
            this.m_dtcTO2CT.Width = 50;
            // 
            // m_dtcSCMH2O
            // 
            this.m_dtcSCMH2O.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcSCMH2O.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcSCMH2O.m_BlnGobleSet = true;
            this.m_dtcSCMH2O.m_BlnUnderLineDST = false;
            this.m_dtcSCMH2O.MappingName = "SCMH2O";
            this.m_dtcSCMH2O.Width = 50;
            // 
            // m_dtcSSD
            // 
            this.m_dtcSSD.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcSSD.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcSSD.m_BlnGobleSet = true;
            this.m_dtcSSD.m_BlnUnderLineDST = false;
            this.m_dtcSSD.MappingName = "SSD";
            this.m_dtcSSD.Width = 50;
            // 
            // m_dtcSMEAN
            // 
            this.m_dtcSMEAN.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcSMEAN.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcSMEAN.m_BlnGobleSet = true;
            this.m_dtcSMEAN.m_BlnUnderLineDST = false;
            this.m_dtcSMEAN.MappingName = "SMEAN";
            this.m_dtcSMEAN.Width = 50;
            // 
            // m_dtcSWEDGE
            // 
            this.m_dtcSWEDGE.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcSWEDGE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcSWEDGE.m_BlnGobleSet = true;
            this.m_dtcSWEDGE.m_BlnUnderLineDST = false;
            this.m_dtcSWEDGE.MappingName = "SWEDGE";
            this.m_dtcSWEDGE.Width = 50;
            // 
            // m_dtcSCOCI
            // 
            this.m_dtcSCOCI.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcSCOCI.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcSCOCI.m_BlnGobleSet = true;
            this.m_dtcSCOCI.m_BlnUnderLineDST = false;
            this.m_dtcSCOCI.MappingName = "SCOCI";
            this.m_dtcSCOCI.Width = 50;
            // 
            // m_dtcIBLOODPRODUCE
            // 
            this.m_dtcIBLOODPRODUCE.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcIBLOODPRODUCE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcIBLOODPRODUCE.m_BlnGobleSet = true;
            this.m_dtcIBLOODPRODUCE.m_BlnUnderLineDST = false;
            this.m_dtcIBLOODPRODUCE.MappingName = "IBLOODPRODUCE";
            this.m_dtcIBLOODPRODUCE.Width = 50;
            // 
            // m_dtcINNAME1
            // 
            this.m_dtcINNAME1.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcINNAME1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcINNAME1.m_BlnGobleSet = true;
            this.m_dtcINNAME1.m_BlnUnderLineDST = false;
            this.m_dtcINNAME1.MappingName = "INNAME1";
            this.m_dtcINNAME1.Width = 75;
            // 
            // m_dtcINNAME2
            // 
            this.m_dtcINNAME2.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcINNAME2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcINNAME2.m_BlnGobleSet = true;
            this.m_dtcINNAME2.m_BlnUnderLineDST = false;
            this.m_dtcINNAME2.MappingName = "INNAME2";
            this.m_dtcINNAME2.Width = 75;
            // 
            // m_dtcINNAME3
            // 
            this.m_dtcINNAME3.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcINNAME3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcINNAME3.m_BlnGobleSet = true;
            this.m_dtcINNAME3.m_BlnUnderLineDST = false;
            this.m_dtcINNAME3.MappingName = "INNAME3";
            this.m_dtcINNAME3.Width = 75;
            // 
            // m_dtcINNAME4
            // 
            this.m_dtcINNAME4.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcINNAME4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcINNAME4.m_BlnGobleSet = true;
            this.m_dtcINNAME4.m_BlnUnderLineDST = false;
            this.m_dtcINNAME4.MappingName = "INNAME4";
            this.m_dtcINNAME4.Width = 75;
            // 
            // m_dtcOUTNAME1
            // 
            this.m_dtcOUTNAME1.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcOUTNAME1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcOUTNAME1.m_BlnGobleSet = true;
            this.m_dtcOUTNAME1.m_BlnUnderLineDST = false;
            this.m_dtcOUTNAME1.MappingName = "OUTNAME1";
            this.m_dtcOUTNAME1.Width = 75;
            // 
            // m_dtcOUTNAME2
            // 
            this.m_dtcOUTNAME2.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcOUTNAME2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcOUTNAME2.m_BlnGobleSet = true;
            this.m_dtcOUTNAME2.m_BlnUnderLineDST = false;
            this.m_dtcOUTNAME2.MappingName = "OUTNAME2";
            this.m_dtcOUTNAME2.Width = 75;
            // 
            // m_dtcOUTNAME3
            // 
            this.m_dtcOUTNAME3.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcOUTNAME3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcOUTNAME3.m_BlnGobleSet = true;
            this.m_dtcOUTNAME3.m_BlnUnderLineDST = false;
            this.m_dtcOUTNAME3.MappingName = "OUTNAME3";
            this.m_dtcOUTNAME3.Width = 75;
            // 
            // m_dtcOUTNAME4
            // 
            this.m_dtcOUTNAME4.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcOUTNAME4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcOUTNAME4.m_BlnGobleSet = true;
            this.m_dtcOUTNAME4.m_BlnUnderLineDST = false;
            this.m_dtcOUTNAME4.MappingName = "OUTNAME4";
            this.m_dtcOUTNAME4.Width = 75;
            // 
            // frmSurgeryICUWardship
            // 
            this.ClientSize = new System.Drawing.Size(816, 597);
            this.Name = "frmSurgeryICUWardship";
            this.Text = "外科ICU监护记录";
            this.Load += new System.EventHandler(this.frmSurgeryICUWardship_Load);
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

			try
			{

				
				//存放记录时间的字符串
				p_dtbRecordTable.Columns.Add("RecordDate");//0
				//存放记录类型的int值
				DataColumn dcRecordType = new DataColumn("RecordType",typeof(int));
				p_dtbRecordTable.Columns.Add(dcRecordType);//1
				//存放记录的OpenDate字符串
				p_dtbRecordTable.Columns.Add("OpenDate");  //2
				//存放记录的ModifyDate字符串
				p_dtbRecordTable.Columns.Add("ModifyDate"); //3
				DataColumn dc1 = p_dtbRecordTable.Columns.Add("RecordDateofDay");//4
				dc1.DefaultValue = "";
				DataColumn dc2 = p_dtbRecordTable.Columns.Add("RecordTime");//5
				dc2.DefaultValue = "";



				p_dtbRecordTable.Columns.Add("PBODYPART",typeof(clsDSTRichTextBoxValue));//6
				p_dtbRecordTable.Columns.Add("PCONSCIOUSNESS",typeof(clsDSTRichTextBoxValue));//7
				p_dtbRecordTable.Columns.Add("PPUPIL",typeof(clsDSTRichTextBoxValue));//8
				//p_dtbRecordTable.Columns.Add("PPUPLRIGHT",typeof(clsDSTRichTextBoxValue));//8
				p_dtbRecordTable.Columns.Add("PREFLECT",typeof(clsDSTRichTextBoxValue));//9
				//p_dtbRecordTable.Columns.Add("PREFLECTRIGHT",typeof(clsDSTRichTextBoxValue));//9
				DataColumn dc3 = p_dtbRecordTable.Columns.Add("Sign");//10
				dc3.DefaultValue = "";
				p_dtbRecordTable.Columns.Add("CTEMPERATURE",typeof(clsDSTRichTextBoxValue));//11
				p_dtbRecordTable.Columns.Add("CSMALLTEMPERATURE",typeof(clsDSTRichTextBoxValue));//12
			
				p_dtbRecordTable.Columns.Add("CHEARTRATE",typeof(clsDSTRichTextBoxValue));//13
				p_dtbRecordTable.Columns.Add("CHEARTRHYTHM",typeof(clsDSTRichTextBoxValue));//14
				p_dtbRecordTable.Columns.Add("CSD",typeof(clsDSTRichTextBoxValue));//15
				p_dtbRecordTable.Columns.Add("CCVP",typeof(clsDSTRichTextBoxValue));//16

                p_dtbRecordTable.Columns.Add("DPHYSIC1", typeof(clsDSTRichTextBoxValue));//17
                p_dtbRecordTable.Columns.Add("DPHYSIC2", typeof(clsDSTRichTextBoxValue));//18
                p_dtbRecordTable.Columns.Add("DPHYSIC3", typeof(clsDSTRichTextBoxValue));//19
                p_dtbRecordTable.Columns.Add("DPHYSIC4", typeof(clsDSTRichTextBoxValue));//20
                p_dtbRecordTable.Columns.Add("DPHYSIC5", typeof(clsDSTRichTextBoxValue));//21
                p_dtbRecordTable.Columns.Add("DPHYSIC6", typeof(clsDSTRichTextBoxValue));//22
                p_dtbRecordTable.Columns.Add("DPHYSIC7", typeof(clsDSTRichTextBoxValue));//23
                p_dtbRecordTable.Columns.Add("DPHYSIC8", typeof(clsDSTRichTextBoxValue));//24

                p_dtbRecordTable.Columns.Add("IBLOODPRODUCE", typeof(clsDSTRichTextBoxValue));//25
                //p_dtbRecordTable.Columns.Add("IBLOODPRODUCEADD",typeof(clsDSTRichTextBoxValue));//26
                p_dtbRecordTable.Columns.Add("IGS", typeof(clsDSTRichTextBoxValue));//27
                p_dtbRecordTable.Columns.Add("INS", typeof(clsDSTRichTextBoxValue));//28
                p_dtbRecordTable.Columns.Add("INNAME1", typeof(clsDSTRichTextBoxValue));//29
                p_dtbRecordTable.Columns.Add("INNAME2", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("INNAME3", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("INNAME4", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("INTATAL", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("OTATAL", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("OEMIEMCTION", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("OGASTRICJUICE", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("OUTNAME1", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("OUTNAME2", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("OUTNAME3", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("OUTNAME4", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("SESPECIALLYNOTE", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("BBLUSETIME", typeof(clsDSTRichTextBoxValue));//9

                p_dtbRecordTable.Columns.Add("BBLUSEMACHINETYPE", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("BBLUSEMODE", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("BVT", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("BEXPIREDMV", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("BBLUESPRESSURE", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("BBLUSENUM", typeof(clsDSTRichTextBoxValue));//9

                p_dtbRecordTable.Columns.Add("BFIO2PEEP", typeof(clsDSTRichTextBoxValue));//9
                //p_dtbRecordTable.Columns.Add("BFI02PEEPRIGHT",typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("BMAXIP", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("BBLUSESOUND", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("BPHLEGMCOLOR", typeof(clsDSTRichTextBoxValue));//9
                //p_dtbRecordTable.Columns.Add("BPHLEGMAMOUNT",typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("BSQ2", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("TCOLLECTBLOODPOINT", typeof(clsDSTRichTextBoxValue));//9

                p_dtbRecordTable.Columns.Add("TPH", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("TPCO2", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("TP02", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("THCO3", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("TTCO2", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("TBE", typeof(clsDSTRichTextBoxValue));//9

                p_dtbRecordTable.Columns.Add("TSAT", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("TO2CT", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("SCMH2O", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("SSD", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("SMEAN", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("SWEDGE", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("SCOCI", typeof(clsDSTRichTextBoxValue));//9
                p_dtbRecordTable.Columns.Add("CreateUserID");//9
			
			
				m_mthSetControl(clmRecordDateofDay);
				m_mthSetControl(clmCreateTime);
				m_mthSetControl(m_dtcPBODYPART);
				m_mthSetControl(m_dtcPCONSCIOUSNESS);
				m_mthSetControl(m_dtcPPUPIL);
				//m_mthSetControl(m_dtcPPUPLRIGHT);
				m_mthSetControl(m_dtcPREFLECT);
				//m_mthSetControl(m_dtcPREFLECTRIGHT);
			
				m_mthSetControl(clmSign);
				m_mthSetControl(m_dtcCTEMPERATURE);
				m_mthSetControl(m_dtcCSMALLTEMPERATURE);
				m_mthSetControl(m_dtcCHEARTRATE);
				m_mthSetControl(m_dtcCHEARTRHYTHM);
				m_mthSetControl(m_dtcCSD);
				m_mthSetControl(m_dtcCCVP);

                m_mthSetControl(m_dtcDPHYSIC1);
                m_mthSetControl(m_dtcDPHYSIC2);
                m_mthSetControl(m_dtcDPHYSIC3);
                m_mthSetControl(m_dtcDPHYSIC4);
                m_mthSetControl(m_dtcDPHYSIC5);
                m_mthSetControl(m_dtcDPHYSIC6);
                m_mthSetControl(m_dtcDPHYSIC7);
                m_mthSetControl(m_dtcDPHYSIC8);

                m_mthSetControl(m_dtcIBLOODPRODUCE);
                //m_mthSetControl(m_dtcIBLOODPRODUCEADD);
                m_mthSetControl(m_dtcIGS);
                m_mthSetControl(m_dtcINS);
                m_mthSetControl(m_dtcINNAME1);
                m_mthSetControl(m_dtcINNAME2);
                m_mthSetControl(m_dtcINNAME3);
                m_mthSetControl(m_dtcINNAME4);
                m_mthSetControl(m_dtcINTATAL);
                m_mthSetControl(m_dtcOTATAL);
                m_mthSetControl(m_dtcOEMIEMCTION);
                m_mthSetControl(m_dtcOGASTRICJUICE);
                m_mthSetControl(m_dtcOUTNAME1);
                m_mthSetControl(m_dtcOUTNAME2);
                m_mthSetControl(m_dtcOUTNAME3);
                m_mthSetControl(m_dtcOUTNAME4);


                m_mthSetControl(m_dtcSESPECIALLYNOTE);
                m_mthSetControl(m_dtcBBLUSETIME);
                m_mthSetControl(m_dtcBBLUSEMACHINETYPE);
                m_mthSetControl(m_dtcBBLUSEMODE);
                m_mthSetControl(m_dtcBVT);
                m_mthSetControl(m_dtcBEXPIREDMV);
                m_mthSetControl(m_dtcBBLUESPRESSURE);
                m_mthSetControl(m_dtcBBLUSENUM);
                m_mthSetControl(m_dtcBFIO2PEEP);
                //m_mthSetControl(m_dtcBFI02PEEPRIGHT);
                m_mthSetControl(m_dtcBMAXIP);

                m_mthSetControl(m_dtcBBLUSESOUND);
                m_mthSetControl(m_dtcBPHLEGMCOLOR);
                //m_mthSetControl(m_dtcBPHLEGMAMOUNT);
                m_mthSetControl(m_dtcBSQ2);
                m_mthSetControl(m_dtcTCOLLECTBLOODPOINT);
                m_mthSetControl(m_dtcTPH);
                m_mthSetControl(m_dtcTPCO2);
                m_mthSetControl(m_dtcTP02);
                m_mthSetControl(m_dtcTHCO3);
                m_mthSetControl(m_dtcTTCO2);
                m_mthSetControl(m_dtcTBE);

                m_mthSetControl(m_dtcTSAT);
                m_mthSetControl(m_dtcTO2CT);
                m_mthSetControl(m_dtcSCMH2O);
                m_mthSetControl(m_dtcSSD);
                m_mthSetControl(m_dtcSMEAN);
                m_mthSetControl(m_dtcSWEDGE);
                m_mthSetControl(m_dtcSCOCI);

				//设置文字栏
				this.clmRecordDateofDay.HeaderText = "\r\n 日期";
				this.clmCreateTime.HeaderText = "\r\n 时间";
				this.m_dtcPBODYPART.HeaderText = " 体\r\n\r\n 位\r\n\r\n";
				this.m_dtcPCONSCIOUSNESS.HeaderText = " 意\r\n\r\n 识\r\n\r\n";
				this.m_dtcPPUPIL.HeaderText = " 瞳\r\n\r\n 孔\r\n\r\n(左/右)";
				this.m_dtcPREFLECT.HeaderText = " 对\r\n 光\r\n 反\r\n 射\r\n(左/右)";
				//this.clmSign.HeaderText = "签\r\n  名r\n ";
				this.m_dtcCTEMPERATURE.HeaderText = " 体\r\n 温\r\n ";
				this.m_dtcCSMALLTEMPERATURE.HeaderText =" 未\r\n 稍\r\n 温\r\n ";
				this.m_dtcCHEARTRATE.HeaderText = " 心\r\n 率\r\n  ";
				this.m_dtcCHEARTRHYTHM.HeaderText = " 心\r\n 律\r\n  ";
				this.m_dtcCSD.HeaderText = " S\r\n D\r\n  ";
				this.m_dtcCCVP.HeaderText = " C\r\n V\r\n P\r\n ";

                this.m_dtcDPHYSIC1.HeaderText = "  用\r\n  药\r\n  治\r\n  疗1\r\n";
                this.m_dtcDPHYSIC2.HeaderText = "  用\r\n  药\r\n  治\r\n  疗2\r\n";
                this.m_dtcDPHYSIC3.HeaderText = "  用\r\n  药\r\n  治\r\n  疗3\r\n";
                this.m_dtcDPHYSIC4.HeaderText = "  用\r\n  药\r\n  治\r\n  疗4\r\n";
                this.m_dtcDPHYSIC5.HeaderText = "  用\r\n  药\r\n  治\r\n  疗5\r\n";
                this.m_dtcDPHYSIC6.HeaderText = "  用\r\n  药\r\n  治\r\n  疗6\r\n";
                this.m_dtcDPHYSIC7.HeaderText = "  用\r\n  药\r\n  治\r\n  疗7\r\n";
                this.m_dtcDPHYSIC8.HeaderText = "  用\r\n  药\r\n  治\r\n  疗8\r\n";
                this.m_dtcIBLOODPRODUCE.HeaderText = " 血\r\n 制\r\n 品\r\n &累\r\n 计\r\n 量\r\n";
                //this.m_dtcIBLOODPRODUCEADD.HeaderText =   " 累\r\n 计\r\n 量\r\n  ";
                this.m_dtcIGS.HeaderText = " G\r\n S\r\n ";
                this.m_dtcINS.HeaderText = " N\r\n S\r\n ";
                this.m_dtcINNAME1.HeaderText = " 入\r\n 量1\r\n ";
                this.m_dtcINNAME2.HeaderText = " 入\r\n 量2\r\n ";
                this.m_dtcINNAME3.HeaderText = " 入\r\n 量3\r\n ";
                this.m_dtcINNAME4.HeaderText = " 入\r\n 量4\r\n ";
                this.m_dtcINTATAL.HeaderText = "  入\r\n  量\r\n  累\r\n  计\r\n  ";
                this.m_dtcOTATAL.HeaderText = "  出\r\n  量\r\n  累\r\n  计\r\n  ";
                this.m_dtcOEMIEMCTION.HeaderText = " 尿\r\n 量\r\n ";
                this.m_dtcOGASTRICJUICE.HeaderText = " 胃\r\n 液\r\n ";
                this.m_dtcOUTNAME1.HeaderText = " 出\r\n 量1\r\n ";
                this.m_dtcOUTNAME2.HeaderText = " 出\r\n 量2\r\n ";
                this.m_dtcOUTNAME3.HeaderText = " 出\r\n 量3\r\n ";
                this.m_dtcOUTNAME4.HeaderText = " 出\r\n 量4\r\n ";
                this.m_dtcSESPECIALLYNOTE.HeaderText = " 特\r\n 殊\r\n 记\r\n 录\r\n";
                this.m_dtcBBLUSETIME.HeaderText = " 插\r\n 管\r\n 时\r\n 间\r\n";
                this.m_dtcBBLUSEMACHINETYPE.HeaderText = " 呼\r\n 吸\r\n 机\r\n 型\r\n 号\r\n";
                this.m_dtcBBLUSEMODE.HeaderText = " 呼\r\n 吸\r\n 方\r\n 式\r\n";
                this.m_dtcBVT.HeaderText = "Vt\r\n";
                this.m_dtcBEXPIREDMV.HeaderText = " Expired\r\n MV\r\n ";
                this.m_dtcBBLUESPRESSURE.HeaderText = " 气\r\n 道\r\n 压\r\n 力\r\n  ";
                this.m_dtcBBLUSENUM.HeaderText = " 呼\r\n 吸\r\n 次\r\n 数\r\n  ";

                this.m_dtcBFIO2PEEP.HeaderText = " FIO2(%)\r\n PEEP\r\n ";

                this.m_dtcBMAXIP.HeaderText = " Max\r\n I.P\r\n ";
                this.m_dtcBBLUSESOUND.HeaderText = " 呼\r\n 吸\r\n 音\r\n";
                this.m_dtcBPHLEGMCOLOR.HeaderText = " 痰色\r\n 痰量\r\n  ";
                this.m_dtcBSQ2.HeaderText = " SQ2\r\n ";
                this.m_dtcTCOLLECTBLOODPOINT.HeaderText = " 采\r\n 血\r\n 点\r\n ";
                this.m_dtcTPH.HeaderText = " PH\r\n";
                this.m_dtcTPCO2.HeaderText = " PCQ2\r\n (K+)\r\n ";
                this.m_dtcTP02.HeaderText = " PQ2\r\n (Na+)\r\n ";
                this.m_dtcTHCO3.HeaderText = " HCO3\r\n (CL-)\r\n ";
                this.m_dtcTTCO2.HeaderText = " TCO2\r\n(Ca++)\r\n  ";
                this.m_dtcTBE.HeaderText = " BE\r\n (Bun)\r\n ";
                this.m_dtcTSAT.HeaderText = " SAT\r\n (Cr)\r\n   ";
                this.m_dtcTO2CT.HeaderText = " O2CT\r\n";

                this.m_dtcSCMH2O.HeaderText = " CmH2O\r\n mmHg\r\n ";
                this.m_dtcSSD.HeaderText = " S\r\n D\r\n  ";
                this.m_dtcSMEAN.HeaderText = " Mean\r\n";
                this.m_dtcSWEDGE.HeaderText = " Wedge\r\n";
                this.m_dtcSCOCI.HeaderText = "CO/CI\r\n    ";

		

			}
			catch(Exception ex)
			{
			MessageBox.Show(ex.ToString());
			}

		
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
            return new clsRecordsDomain(enmRecordsType.SURGERYICUWARDSHIP);
		}

		
		// 获取记录的主要信息（必须获取的是CreateDate,OpenDate,LastModifyDate）
		protected override clsTrackRecordContent m_objGetRecordMainContent(int p_intRecordType,
			object[] p_objDataArr)
		{
			//根据 p_intRecordType 获取对应的 clsTrackRecordContent
			clsTrackRecordContent objContent = null;
			switch((enmDiseaseTrackType)p_intRecordType)
			{ 
				case enmDiseaseTrackType.SURGERYICUWARDSHIP:
					objContent = new clsISURGERYICUWARDSHIP();
					break;
			}

			if(objContent == null)
				objContent=new clsISURGERYICUWARDSHIP();	
		
			if(m_objCurrentPatient !=null)
				objContent.m_strInPatientID=m_objCurrentPatient.m_StrInPatientID;
			else 
			{
				clsPublicFunction.ShowInformationMessageBox("当前病人为空!");
				return null;
			}
			objContent.m_dtmInPatientDate=m_objCurrentPatient.m_DtmSelectedInDate;
			objContent.m_dtmCreateDate = DateTime.Parse((string)p_objDataArr[0]);
			objContent.m_dtmOpenDate = DateTime.Parse((string)p_objDataArr[2]);
			objContent.m_dtmModifyDate = DateTime.Parse((string)p_objDataArr[3]);
            objContent.m_strCreateUserID = (string)p_objDataArr[67]; 
		
			return objContent;
		}

		private void frmSurgeryICUWardship_Load(object sender, System.EventArgs e)
		{
			#region 添加右键菜单 old
//			System.Windows.Forms.MenuItem mniContentAdd=new System.Windows.Forms.MenuItem();
//			mniContentAdd.Index = 10;
//			mniContentAdd.Text = "添加病程记录内容";
//			mniContentAdd.Click += new System.EventHandler(mniContentAdd_Click);
//			System.Windows.Forms.MenuItem mniContentModify=new System.Windows.Forms.MenuItem();
//			mniContentModify.Index = 11;
//			mniContentModify.Text = "修改病程记录内容";
//			mniContentModify.Click += new System.EventHandler(mniContentModify_Click);
//			System.Windows.Forms.MenuItem mniContentDelete=new System.Windows.Forms.MenuItem();
//			mniContentDelete.Index = 12;
//			mniContentDelete.Text = "删除病程记录内容";
//			mniContentDelete.Click += new System.EventHandler(mniContentDelete_Click);
//			this.ctmRecordControl.MenuItems.Add(mniContentAdd);
//			this.ctmRecordControl.MenuItems.Add(mniContentModify);
//			this.ctmRecordControl.MenuItems.Add(mniContentDelete);
//			
			#endregion ;
			m_dtmPreRecordDate = DateTime.MinValue;
			m_mniAddBlank.Visible=false;
			m_mniDeleteBlank.Visible=false;
			m_dtgRecordDetail.Focus();
		}

		// 获取处理（添加和修改）记录的窗体。
		protected override frmDiseaseTrackBase m_frmGetRecordForm(int p_intRecordType)
		{
			switch((enmDiseaseTrackType)p_intRecordType)
			{
				case enmDiseaseTrackType.SURGERYICUWARDSHIP:
					return new frmSurgeryICUWardshipEdit();
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
		}
		protected override object[][] m_objGetRecordsValueArr(clsTransDataInfo p_objTransDataInfo)
		{
			try
			{
			#region 显示记录到DataGrid
				object[] objData;
				ArrayList objReturnData=new ArrayList();
				ArrayList arlDetail = new ArrayList();//存放病情记录
				int intCurrentDetail = 0;//当前病情记录在ArrayList中的索引

				clsISURGERYICUWARDSHIPDataInfo objGNRCInfo=new clsISURGERYICUWARDSHIPDataInfo();			
				clsDSTRichTextBoxValue objclsDSTRichTextBoxValue;
				string strText,strXml;

				objGNRCInfo = (clsISURGERYICUWARDSHIPDataInfo)p_objTransDataInfo;
                if(objGNRCInfo.m_objRecordArr == null)
					return null;

				#region 对icu监护进行处理
//				if(objGNRCInfo.m_objDetailArr != null)
//				{
//					string strDetail = "";
//					string strDetailXML = "";
//					for(int n=0; n<objGNRCInfo.m_objDetailArr.Length; n++)
//					{
//						clsISURGERYICUWARDSHIPDataInfo objDetail = objGNRCInfo.m_objDetailArr[n];
//						object[] objTemp = new object[6];
//						strDetail = objDetail.m_strRECORDCONTENT_RIGHT;
//						strDetailXML = objDetail.m_strRECORDCONTENTXML;
//						string[] strDetailArrTemp;
//						string[] strDetailXMLArrTemp;
//						//将病情记录分为20个字符一行。因第一行要空两格，故添加空字符串
//						com.digitalwave.controls.ctlRichTextBox.m_mthSplitXml("    "+strDetail,strDetailXML,16,out strDetailArrTemp,out strDetailXMLArrTemp);
//						string[] strDetailArr ,strDetailXMLArr;
//						if(strDetail != string.Empty)
//						{
//							strDetailArr = new string[strDetailArrTemp.Length+2];//存放添加日期和签名后病情记录
//							strDetailXMLArr = new string[strDetailXMLArrTemp.Length+2];//存放添加日期和签名后病情记录XML
//
//							//将日期和签名添加进病情记录
//							strDetailArr[0] = objDetail.m_dtmRECORDDATE.ToString("yyyy-MM-dd HH:mm");
//							strDetailArr[1] = strDetailArrTemp[0];
//							for(int i=2; i<strDetailArr.Length-1; i++)
//							{
//								strDetailArr[i] = strDetailArrTemp[i-1];
//							}
//							strDetailArr[strDetailArr.Length-1] = "                           "+objDetail.m_strDetailCreateUserName;
//							
//							strDetailXMLArr[0]=strDetailXMLArr[strDetailXMLArr.Length-1]="";
//							for(int i=1; i<strDetailXMLArr.Length-1; i++)
//							{
//								strDetailXMLArr[i] = strDetailXMLArrTemp[i-1];
//							}
//							
//							objTemp[0] = strDetailArr;
//							objTemp[1] = strDetailXMLArr;
//							objTemp[2] = strDetailArr.Length;
//							objTemp[3] = objDetail.m_dtmRECORDDATE;
//							objTemp[4] = objDetail.m_dtmCREATERECORDDATE;
//							objTemp[5] = objDetail.m_strDetailCreateUserName;
//							arlDetail.Add(objTemp);
//						}
//					}
//				}
				#endregion

				int intRecordCount = objGNRCInfo.m_objRecordArr.Length;
				int intRowOfCurrentDetail = 0;

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

				for(int i=0; i<intRecordCount; i++)
				{
                    /*--------------------------add by wjqin(06-2-23)-----------------------------------------*/
                    //为病人加上"体重","ID号","手术名称","手术日期","入ICU天数"
                    personMessageArr.Add(objGNRCInfo.m_objRecordArr[0].m_strWEIGHT);
                    personMessageArr.Add(objGNRCInfo.m_objRecordArr[0].m_strIDCODE);
                    personMessageArr.Add(objGNRCInfo.m_objRecordArr[0].m_strOPERATIONNAME.ToString().Trim());
                    personMessageArr.Add(objGNRCInfo.m_objRecordArr[0].m_strOPERATIONDATE.ToString().Trim());
                    personMessageArr.Add(objGNRCInfo.m_objRecordArr[0].m_strDATEAFTEROPERATION.ToString().Trim());

                    /*---------------------------------------------------------------------*/
				
					objData = new object[68];   //58
					clsISURGERYICUWARDSHIP objCurrent = objGNRCInfo.m_objRecordArr[i];

					clsISURGERYICUWARDSHIP objNext = new clsISURGERYICUWARDSHIP();//下一条护理记录
					if(i < intRecordCount-1)
						objNext = objGNRCInfo.m_objRecordArr[i+1];

					//如果该护理记录是修改前的记录且是在指定时间内修改的，则不显示
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate)
					{
						TimeSpan tsModify =  objNext.m_dtmModifyDate-objCurrent.m_dtmModifyDate;
						if((int)tsModify.TotalHours < intCanModifyTime)
							continue;
					}

					#region 存放关键字段
					if(objCurrent.m_dtmCreateDate!=DateTime.MinValue)
					{
						objData[0] = objCurrent.m_dtmCreateDate;//存放记录时间的字符串
						objData[1] = (int)enmRecordsType.SURGERYICUWARDSHIP;//存放记录类型的int值
						objData[2] = objCurrent.m_dtmOpenDate;//存放记录的OpenDate字符串
						objData[3] = objGNRCInfo.m_objRecordArr[objGNRCInfo.m_objRecordArr.Length-1].m_dtmModifyDate;//存放记录的ModifyDate字符串   
						
						//同一个则只在第一行显示日期
						if(objCurrent.m_dtmCreateDate.Date.ToString() != m_dtmPreRecordDate.Date.ToString())//m_dtmRECORDDATE
						{
							objData[4] = objCurrent.m_dtmCreateDate.Date.ToString("yyyy-MM-dd") ;//日期字符串
						}
						//修改后带有痕迹的记录不再显示时间
						if(m_dtmPreRecordDate != objCurrent.m_dtmCreateDate)
							objData[5] = objCurrent.m_dtmCreateDate.ToString("HH:mm");//时间字符串
	
					}
					m_dtmPreRecordDate = objCurrent.m_dtmCreateDate;	
					#endregion ;

					#region 存放单项信息
					//体位
					strText = objCurrent.m_strPBODYPART_Right;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strPBODYPART_Right != objCurrent.m_strPBODYPART_Right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strPBODYPART_Right ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[6] = objclsDSTRichTextBoxValue;//T
			
					//意识
					strText = objCurrent.m_strPCONSCIOUSNESS_Right ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate  && objNext.m_strPCONSCIOUSNESS_Right != objCurrent.m_strPCONSCIOUSNESS_Right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strPCONSCIOUSNESS_Right,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[7] = objclsDSTRichTextBoxValue;//HR

					//瞳孔(左/右)
					strText="";
					if(objCurrent.m_strPPUPIL_Right.Trim().Length!=0)
						strText =objCurrent.m_strPPUPIL_Right;
					if(objCurrent.m_strPPUPLRIGH_RightT.Trim().Length!=0)
						strText +="/"+ objCurrent.m_strPPUPLRIGH_RightT;
					
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && (objNext.m_strPPUPIL_Right != objCurrent.m_strPPUPIL_Right  || objNext.m_strPPUPLRIGH_RightT != objCurrent.m_strPPUPLRIGH_RightT))/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(strText,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[8] = objclsDSTRichTextBoxValue;//P

			
					//对光反射(左/右)
					strText="";
					if(objCurrent.m_strPREFLECT_Right.Trim().Length!=0)
						strText =objCurrent.m_strPREFLECT_Right;
					if(objCurrent.m_strPREFLECTRIGHT_Right.Trim().Length!=0)
						strText +="/"+ objCurrent.m_strPREFLECTRIGHT_Right;
					
					
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && (objNext.m_strPREFLECT_Right != objCurrent.m_strPREFLECT_Right || objNext.m_strPREFLECTRIGHT_Right != objCurrent.m_strPREFLECTRIGHT_Right))/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(strText,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[9] = objclsDSTRichTextBoxValue;//

						//签名
					strText = "";//objCurrent.m_strContentCreateUserName;
					objData[10] = strText;
					//体温
					strText = objCurrent.m_strCTEMPERATURE_Right ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strCTEMPERATURE_Right != objCurrent.m_strCTEMPERATURE_Right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strCTEMPERATURE_Right,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[11] = objclsDSTRichTextBoxValue;//

					//未稍温
					strText = objCurrent.m_strCSMALLTEMPERATURE_Right ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strCSMALLTEMPERATURE_Right != objCurrent.m_strCSMALLTEMPERATURE_Right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strCSMALLTEMPERATURE_Right,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[12] = objclsDSTRichTextBoxValue;//

					//心率
					strText = objCurrent.m_strCHEARTRATE_Right ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strCHEARTRATE_Right != objCurrent.m_strCHEARTRATE_Right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strCHEARTRATE_Right,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[13] = objclsDSTRichTextBoxValue;//

					//心律
					strText = objCurrent.m_strCHEARTRHYTHM_Right ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strCHEARTRHYTHM_Right != objCurrent.m_strCHEARTRHYTHM_Right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strCHEARTRHYTHM_Right,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[14] = objclsDSTRichTextBoxValue;//

					//s/d
					strText = objCurrent.m_strCSD_Right ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strCSD_Right != objCurrent.m_strCSD_Right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strCSD_Right,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[15] = objclsDSTRichTextBoxValue;//

					//CCVP
					strText = objCurrent.m_strCCVP_Right ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strCCVP_Right != objCurrent.m_strCCVP_Right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strCCVP_Right,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[16] = objclsDSTRichTextBoxValue;//

					//用药有治疗1
					strText="";
					if(objCurrent.m_strDPHYSIC1_Right.Trim().Length!=0)
						strText ="用药:"+ objCurrent.m_strDPHYSIC1_Right;
					if(objCurrent.m_strDCURE1_Right.Trim().Length!=0)
						strText +="治疗:"+ objCurrent.m_strDCURE1_Right;
					//strText ="用药:"+ objCurrent.m_strDPHYSIC1_Right +"治疗:"+objCurrent.m_strDCURE1_Right;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && (objNext.m_strDPHYSIC1_Right != objCurrent.m_strDPHYSIC1_Right || objNext.m_strDCURE1_Right != objCurrent.m_strDCURE1_Right))/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(strText,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[17] = objclsDSTRichTextBoxValue;//

					//用药有治疗2
					strText="";
					if(objCurrent.m_strDPHYSIC2_Right.Trim().Length!=0)
						strText ="用药:"+ objCurrent.m_strDPHYSIC2_Right;
					if(objCurrent.m_strDCURE2_Right.Trim().Length!=0)
						strText +="治疗:"+ objCurrent.m_strDCURE2_Right;
					//strText = "用药:"+ objCurrent.m_strDPHYSIC2_Right +"治疗:"+objCurrent.m_strDCURE2_Right;
					strXml = "<root />";
//					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strDPHYSIC2_Right != objCurrent.m_strDPHYSIC2_Right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
//					{
//						strXml = m_strGetDSTTextXML(objCurrent.m_strDPHYSIC2_Right,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
//					}
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && (objNext.m_strDPHYSIC2_Right != objCurrent.m_strDPHYSIC2_Right || objNext.m_strDCURE2_Right != objCurrent.m_strDCURE2_Right))/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(strText,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[18] = objclsDSTRichTextBoxValue;//

					//用药有治疗3
					strText="";
					if(objCurrent.m_strDPHYSIC3_Right.Trim().Length!=0)
						strText ="用药:"+ objCurrent.m_strDPHYSIC3_Right;
					if(objCurrent.m_strDCURE3_Right.Trim().Length!=0)
						strText +="治疗:"+ objCurrent.m_strDCURE3_Right;
					//strText = "用药:"+ objCurrent.m_strDPHYSIC3_Right +"治疗:"+objCurrent.m_strDCURE3_Right;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && (objNext.m_strDPHYSIC3_Right != objCurrent.m_strDPHYSIC3_Right || objNext.m_strDCURE3_Right != objCurrent.m_strDCURE3_Right))/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(strText,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[19] = objclsDSTRichTextBoxValue;//

					//用药有治疗4
					strText="";
					if(objCurrent.m_strDPHYSIC4_Right.Trim().Length!=0)
						strText ="用药:"+ objCurrent.m_strDPHYSIC4_Right;
					if(objCurrent.m_strDCURE4_Right.Trim().Length!=0)
						strText +="治疗:"+ objCurrent.m_strDCURE4_Right;
					//strText = "用药:"+ objCurrent.m_strDPHYSIC4_Right +"治疗:"+objCurrent.m_strDCURE4_Right;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && (objNext.m_strDPHYSIC4_Right != objCurrent.m_strDPHYSIC4_Right || objNext.m_strDCURE4_Right != objCurrent.m_strDCURE4_Right))/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(strText,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[20] = objclsDSTRichTextBoxValue;//

					//用药有治疗5
					strText="";
					if(objCurrent.m_strDPHYSIC5_Right.Trim().Length!=0)
						strText ="用药:"+ objCurrent.m_strDPHYSIC5_Right;
					if(objCurrent.m_strDCURE5_Right.Trim().Length!=0)
						strText +="治疗:"+ objCurrent.m_strDCURE5_Right;
					//strText = "用药:"+ objCurrent.m_strDPHYSIC5_Right +"治疗:"+objCurrent.m_strDCURE5_Right;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && (objNext.m_strDPHYSIC5_Right != objCurrent.m_strDPHYSIC5_Right || objNext.m_strDCURE5_Right != objCurrent.m_strDCURE5_Right))/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(strText,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[21] = objclsDSTRichTextBoxValue;//

					//用药有治疗6
					strText="";
					if(objCurrent.m_strDPHYSIC6_Right.Trim().Length!=0)
						strText ="用药:"+ objCurrent.m_strDPHYSIC6_Right;
					if(objCurrent.m_strDCURE6_Right.Trim().Length!=0)
						strText +="治疗:"+ objCurrent.m_strDCURE6_Right;
					//strText ="用药:"+ objCurrent.m_strDPHYSIC6_Right +"治疗:"+objCurrent.m_strDCURE6_Right;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && (objNext.m_strDPHYSIC6_Right != objCurrent.m_strDPHYSIC6_Right || objNext.m_strDCURE6_Right != objCurrent.m_strDCURE6_Right))/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(strText,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[22] = objclsDSTRichTextBoxValue;//

					//用药有治疗7
					strText="";
					if(objCurrent.m_strDPHYSIC7_Right.Trim().Length!=0)
						strText ="用药:"+ objCurrent.m_strDPHYSIC7_Right;
					if(objCurrent.m_strDCURE7_Right.Trim().Length!=0)
						strText +="治疗:"+ objCurrent.m_strDCURE7_Right;
					//strText = "用药:"+ objCurrent.m_strDPHYSIC7_Right +"治疗:"+objCurrent.m_strDCURE7_Right;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && (objNext.m_strDPHYSIC7_Right != objCurrent.m_strDPHYSIC7_Right || objNext.m_strDCURE7_Right != objCurrent.m_strDCURE7_Right))/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(strText,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[23] = objclsDSTRichTextBoxValue;//

					//用药有治疗8
					strText="";
					if(objCurrent.m_strDPHYSIC8_Right.Trim().Length!=0)
						strText ="用药:"+ objCurrent.m_strDPHYSIC8_Right;
					if(objCurrent.m_strDCURE8_Right.Trim().Length!=0)
						strText +="治疗:"+ objCurrent.m_strDCURE8_Right;
					//strText = "用药:"+ objCurrent.m_strDPHYSIC8_Right +"治疗:"+objCurrent.m_strDCURE8_Right;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && (objNext.m_strDPHYSIC8_Right != objCurrent.m_strDPHYSIC8_Right || objNext.m_strDCURE8_Right != objCurrent.m_strDCURE8_Right))/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(strText,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[24] = objclsDSTRichTextBoxValue;//

					//血制品/累计量
					strText="";
					if(objCurrent.m_strIBLOODPRODUCE_Right.Trim().Length!=0)
						strText =objCurrent.m_strIBLOODPRODUCE_Right;
					if(objCurrent.m_strIBLOODPRODUCEAD_Right.Trim().Length!=0)
						strText +=" /"+ objCurrent.m_strIBLOODPRODUCEAD_Right;
					
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && (objNext.m_strIBLOODPRODUCE_Right != objCurrent.m_strIBLOODPRODUCE_Right || objNext.m_strIBLOODPRODUCEAD_Right != objCurrent.m_strIBLOODPRODUCEAD_Right))/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(strText,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[25] = objclsDSTRichTextBoxValue;//

					//IGS
					strText = objCurrent.m_strIGS_Right ;
					if(strText=="0")
						strText="";
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strIGS_Right != objCurrent.m_strIGS_Right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(strText,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[26] = objclsDSTRichTextBoxValue;//


					//INS
					strText = objCurrent.m_strINS_Right ;
					if(strText=="0")
						strText="";
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strINS_Right != objCurrent.m_strINS_Right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(strText,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[27] = objclsDSTRichTextBoxValue;//

					//入量1
					strText="";
					if(objCurrent.m_strINNAME1_Right.Trim().Length!=0)
						strText =objCurrent.m_strINNAME1_Right;
					if(objCurrent.m_strINAMOUNT1_Right.Trim().Length!=0 && objCurrent.m_strINAMOUNT1_Right!="0")
						strText +=" :"+ objCurrent.m_strINAMOUNT1_Right;
					
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && (objNext.m_strINNAME1_Right != objCurrent.m_strINNAME1_Right || objNext.m_strINAMOUNT1_Right != objCurrent.m_strINAMOUNT1_Right))/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(strText,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[28] = objclsDSTRichTextBoxValue;//

					//入量2
					strText="";
					if(objCurrent.m_strINNAME2_Right.Trim().Length!=0)
						strText =objCurrent.m_strINNAME2_Right;
					if(objCurrent.m_strINAMOUNT2_Right.Trim().Length!=0  && objCurrent.m_strINAMOUNT2_Right!="0")
						strText +=" :"+ objCurrent.m_strINAMOUNT2_Right;
					
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && (objNext.m_strINNAME2_Right != objCurrent.m_strINNAME2_Right || objNext.m_strINAMOUNT2_Right != objCurrent.m_strINAMOUNT2_Right))/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(strText,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[29] = objclsDSTRichTextBoxValue;//

					//入量3
					strText="";
					if(objCurrent.m_strINNAME3_Right.Trim().Length!=0)
						strText =objCurrent.m_strINNAME3_Right;
					if(objCurrent.m_strINAMOUNT3_Right.Trim().Length!=0  && objCurrent.m_strINAMOUNT3_Right!="0")
						strText +=" :"+ objCurrent.m_strINAMOUNT3_Right;
					
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && (objNext.m_strINNAME3_Right != objCurrent.m_strINNAME3_Right || objNext.m_strINAMOUNT3_Right != objCurrent.m_strINAMOUNT3_Right))/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(strText,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[30] = objclsDSTRichTextBoxValue;//

					//入量4
					strText="";
					if(objCurrent.m_strINNAME4_Right.Trim().Length!=0)
						strText =objCurrent.m_strINNAME4_Right;
					if(objCurrent.m_strINAMOUNT4_Right.Trim().Length!=0  && objCurrent.m_strINAMOUNT4_Right!="0")
						strText +=" :"+ objCurrent.m_strINAMOUNT4_Right;
					
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && (objNext.m_strINNAME4_Right != objCurrent.m_strINNAME4_Right || objNext.m_strINAMOUNT4_Right != objCurrent.m_strINAMOUNT4_Right))/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(strText,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[31] = objclsDSTRichTextBoxValue;//


					//入量累计
					strText = objCurrent.m_strINTATAL_Right ;
					if(strText=="0")
						strText="";
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strINTATAL_Right != objCurrent.m_strINTATAL_Right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(strText,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[32] = objclsDSTRichTextBoxValue;//

					//出量累计

					strText = objCurrent.m_strOTATAL_Right ;
					if(strText=="0")
						strText="";
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strOTATAL_Right != objCurrent.m_strOTATAL_Right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(strText,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[33] = objclsDSTRichTextBoxValue;//


					//尿量
					strText = objCurrent.m_strOEMIEMCTION_Right ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strOEMIEMCTION_Right != objCurrent.m_strOEMIEMCTION_Right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strOEMIEMCTION_Right,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[34] = objclsDSTRichTextBoxValue;//

					//胃液
					strText = objCurrent.m_strOGASTRICJUICE_Right ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strOGASTRICJUICE_Right != objCurrent.m_strOGASTRICJUICE_Right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strOGASTRICJUICE_Right,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[35] = objclsDSTRichTextBoxValue;//

					//出量1
					strText="";
					if(objCurrent.m_strOUTNAME1_Right.Trim().Length!=0)
						strText =objCurrent.m_strOUTNAME1_Right;
					if(objCurrent.m_strOUTAMOUNT1_Right.Trim().Length!=0  && objCurrent.m_strOUTAMOUNT1_Right!="0")
						strText +=" :"+ objCurrent.m_strOUTAMOUNT1_Right;
					
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && (objNext.m_strOUTNAME1_Right != objCurrent.m_strOUTNAME1_Right || objNext.m_strOUTAMOUNT1_Right != objCurrent.m_strOUTAMOUNT1_Right))/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(strText,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[36] = objclsDSTRichTextBoxValue;//

					//出量2
					strText="";
					if(objCurrent.m_strOUTNAME2_Right.Trim().Length!=0)
						strText =objCurrent.m_strOUTNAME2_Right;
					if(objCurrent.m_strOUTAMOUNT2_Right.Trim().Length!=0   && objCurrent.m_strOUTAMOUNT2_Right!="0")
						strText +=" :"+ objCurrent.m_strOUTAMOUNT2_Right;
					
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && (objNext.m_strOUTNAME2_Right != objCurrent.m_strOUTNAME2_Right || objNext.m_strOUTAMOUNT2_Right != objCurrent.m_strOUTAMOUNT2_Right))/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(strText,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[37] = objclsDSTRichTextBoxValue;//

					//出量3
					strText="";
					if(objCurrent.m_strOUTNAME3_Right.Trim().Length!=0)
						strText =objCurrent.m_strOUTNAME3_Right;
					if(objCurrent.m_strOUTAMOUNT3_Right.Trim().Length!=0   && objCurrent.m_strOUTAMOUNT3_Right!="0")
						strText +=" :"+ objCurrent.m_strOUTAMOUNT3_Right;
					
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && (objNext.m_strOUTNAME3_Right != objCurrent.m_strOUTNAME3_Right || objNext.m_strOUTAMOUNT3_Right != objCurrent.m_strOUTAMOUNT3_Right))/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(strText,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[38] = objclsDSTRichTextBoxValue;//

					//出量4
					strText="";
					if(objCurrent.m_strOUTNAME4_Right.Trim().Length!=0)
						strText =objCurrent.m_strOUTNAME4_Right;
					if(objCurrent.m_strOUTAMOUNT4_Right.Trim().Length!=0   && objCurrent.m_strOUTAMOUNT4_Right!="0")
						strText +=" :"+ objCurrent.m_strOUTAMOUNT4_Right;
					
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && (objNext.m_strOUTNAME4_Right != objCurrent.m_strOUTNAME4_Right || objNext.m_strOUTAMOUNT4_Right != objCurrent.m_strOUTAMOUNT4_Right))/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(strText,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[39] = objclsDSTRichTextBoxValue;//


					//特殊记录
					strText = objCurrent.m_strSESPECIALLYNOTE_Right ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strSESPECIALLYNOTE_Right != objCurrent.m_strSESPECIALLYNOTE_Right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strSESPECIALLYNOTE_Right,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[40] = objclsDSTRichTextBoxValue;//

					//插管时间
					strText = objCurrent.m_strBBLUSETIME_Right ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strBBLUSETIME_Right != objCurrent.m_strBBLUSETIME_Right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strBBLUSETIME_Right,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[41] = objclsDSTRichTextBoxValue;//


					//呼吸机型号
					strText = objCurrent.m_strBBLUSEMACHINETYPE_Right ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strBBLUSEMACHINETYPE_Right != objCurrent.m_strBBLUSEMACHINETYPE_Right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strBBLUSEMACHINETYPE_Right,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[42] = objclsDSTRichTextBoxValue;//

					//呼吸方式
					strText = objCurrent.m_strBBLUSEMODE_Right ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strBBLUSEMODE_Right != objCurrent.m_strBBLUSEMODE_Right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strBBLUSEMODE_Right,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[43] = objclsDSTRichTextBoxValue;//

					//vt
					strText = objCurrent.m_strBVT_Right ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strBVT_Right != objCurrent.m_strBVT_Right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strBVT_Right,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[44] = objclsDSTRichTextBoxValue;//

					//expiredmv
					strText = objCurrent.m_strBEXPIREDMV_Right ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strBEXPIREDMV_Right != objCurrent.m_strBEXPIREDMV_Right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strBEXPIREDMV_Right,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[45] = objclsDSTRichTextBoxValue;//

					//气道压力
					strText = objCurrent.m_strBBLUESPRESSURE_Right ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strBBLUESPRESSURE_Right != objCurrent.m_strBBLUESPRESSURE_Right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strBBLUESPRESSURE_Right,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[46] = objclsDSTRichTextBoxValue;//

					//呼吸次数
					strText = objCurrent.m_strBBLUSENUM_Right ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strBBLUSENUM_Right != objCurrent.m_strBBLUSENUM_Right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strBBLUSENUM_Right,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[47] = objclsDSTRichTextBoxValue;//

					//BFIO2PEEP
					strText="";
					if(objCurrent.m_strBFIO2PEEP_Right.Trim().Length!=0)
						strText =objCurrent.m_strBFIO2PEEP_Right;
					if(objCurrent.m_strBFI02PEEPRIGHT_Right.Trim().Length!=0)
						strText +=" /"+ objCurrent.m_strBFI02PEEPRIGHT_Right;
				
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && (objNext.m_strBFIO2PEEP_Right != objCurrent.m_strBFIO2PEEP_Right ||objNext.m_strBFI02PEEPRIGHT_Right != objCurrent.m_strBFI02PEEPRIGHT_Right))/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(strText,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[48] = objclsDSTRichTextBoxValue;//

					//BMAXIP
					strText = objCurrent.m_strBMAXIP_Right ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strBMAXIP_Right != objCurrent.m_strBMAXIP_Right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strBMAXIP_Right,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[49] = objclsDSTRichTextBoxValue;//

					//呼吸音
					strText = objCurrent.m_strBBLUSESOUND_Right ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strBBLUSESOUND_Right != objCurrent.m_strBBLUSESOUND_Right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strBBLUSESOUND_Right,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[50] = objclsDSTRichTextBoxValue;//

					//痰色/痰量
					strText="";
					if(objCurrent.m_strBPHLEGMCOLOR_Right.Trim().Length!=0)
						strText =objCurrent.m_strBPHLEGMCOLOR_Right;
					if(objCurrent.m_strBPHLEGMAMOUNT_Right.Trim().Length!=0)
						strText +=" /"+ objCurrent.m_strBPHLEGMAMOUNT_Right;
				
					
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && (objNext.m_strBPHLEGMCOLOR_Right != objCurrent.m_strBPHLEGMCOLOR_Right || objNext.m_strBPHLEGMAMOUNT_Right != objCurrent.m_strBPHLEGMAMOUNT_Right))/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(strText,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[51] = objclsDSTRichTextBoxValue;//

					//BSQ2
					strText = objCurrent.m_strBSQ2_Right ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strBSQ2_Right != objCurrent.m_strBSQ2_Right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strBSQ2_Right,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[52] = objclsDSTRichTextBoxValue;//

					//采血点
					strText = objCurrent.m_strTCOLLECTBLOODPOINT_Right ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strTCOLLECTBLOODPOINT_Right != objCurrent.m_strTCOLLECTBLOODPOINT_Right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strTCOLLECTBLOODPOINT_Right,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[53] = objclsDSTRichTextBoxValue;//

					//m_strTPH
					strText = objCurrent.m_strTPH_Right  ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strTPH_Right != objCurrent.m_strTPH_Right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strTPH_Right,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[54] = objclsDSTRichTextBoxValue;//

					//TPCO2
					strText = objCurrent.m_strTPCO2_Right ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strTPCO2_Right != objCurrent.m_strTPCO2_Right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strTPCO2_Right,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[55] = objclsDSTRichTextBoxValue;//

					
					//TP02
					strText = objCurrent.m_strTP02_Right ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strTP02_Right != objCurrent.m_strTP02_Right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strTP02_Right,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[56] = objclsDSTRichTextBoxValue;//

					
					//THCO3
					strText = objCurrent.m_strTHCO3_Right ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strTHCO3_Right != objCurrent.m_strTHCO3_Right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strTHCO3_Right,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[57] = objclsDSTRichTextBoxValue;//

					
					//TTCO2
					strText = objCurrent.m_strTTCO2_Right ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strTTCO2_Right != objCurrent.m_strTTCO2_Right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strTTCO2_Right,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[58] = objclsDSTRichTextBoxValue;//

					
					//TBE
					strText = objCurrent.m_strTBE_Right ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strTBE_Right != objCurrent.m_strTBE_Right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strTBE_Right,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[59] = objclsDSTRichTextBoxValue;//

					
					//TSAT
					strText = objCurrent.m_strTSAT_Right ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strTSAT_Right != objCurrent.m_strTSAT_Right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strTSAT_Right,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[60] = objclsDSTRichTextBoxValue;//

					//TO2CT
					strText = objCurrent.m_strTO2CT_Right ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strTO2CT_Right != objCurrent.m_strTO2CT_Right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strTO2CT_Right,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[61] = objclsDSTRichTextBoxValue;//

					//SCMH2O
					strText = objCurrent.m_strSCMH2O_Right ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strSCMH2O_Right != objCurrent.m_strSCMH2O_Right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strSCMH2O_Right,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[62] = objclsDSTRichTextBoxValue;//

					//SSD
					strText = objCurrent.m_strSSD_Right ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strSSD_Right != objCurrent.m_strSSD_Right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strSSD_Right,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[63] = objclsDSTRichTextBoxValue;//

					//SMEAN
					strText = objCurrent.m_strSMEAN_Right ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strSMEAN_Right != objCurrent.m_strSMEAN_Right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strSMEAN_Right,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[64] = objclsDSTRichTextBoxValue;//

					//SWEDGE 
					strText = objCurrent.m_strSWEDGE_Right  ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strSWEDGE_Right != objCurrent.m_strSWEDGE_Right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strSWEDGE_Right,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[65] = objclsDSTRichTextBoxValue;//

					//SCOCI
					strText = objCurrent.m_strSCOCI_Right  ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strSCOCI_Right != objCurrent.m_strSCOCI_Right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strSCOCI_Right,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[66] = objclsDSTRichTextBoxValue;//
                    objData[67] = objCurrent.m_strCreateUserID;//


					#endregion
				
					#region  old
//					//病情记录
//					if(objGNRCInfo.m_objDetailArr != null && intCurrentDetail < objGNRCInfo.m_objDetailArr.Length)
//					{
//						DateTime dtDetailCreateTime = (DateTime)(((object[])arlDetail[intCurrentDetail])[4]);
//						//如果下一条护理记录的创建时间在目前的病情记录之后，则写完剩余病情记录后再写下一条护理记录
//						//或者如果目前是最后一条护理记录，则之后将剩余病情记录写完
//						if((dtDetailCreateTime < objCurrent.m_dtmCreateDate 
//							&& intRowOfCurrentDetail < ((string[])(((object[])arlDetail[intCurrentDetail])[0])).Length) ||
//							(i==intRecordCount-1 && intRowOfCurrentDetail <= ((string[])(((object[])arlDetail[intCurrentDetail])[0])).Length-1))
//						{
//							for(int m=intRowOfCurrentDetail; m<((string[])(((object[])arlDetail[intCurrentDetail])[0])).Length; m++)
//							{
//								object[] objOtherDetail = new object[14];
//								m_mthSetOtherDetail(((object[])arlDetail[intCurrentDetail]),  intCurrentDetail, m, out objOtherDetail);
//								objReturnData.Add(objOtherDetail);
//							}
//						
//							intCurrentDetail ++;
//							intRowOfCurrentDetail = 0;
//						}	
//						//如果目前病情记录跟护理记录的创建时间是同一天，直接填充
//						if(intCurrentDetail < objGNRCInfo.m_objDetailArr.Length && ((DateTime)(((object[])arlDetail[intCurrentDetail])[4])).Date == objCurrent.m_dtmCreateDate.Date)
//						{	
//							strText = ((string[])(((object[])arlDetail[intCurrentDetail])[0]))[intRowOfCurrentDetail];
//							strXml = ((string[])(((object[])arlDetail[intCurrentDetail])[1]))[intRowOfCurrentDetail];;
//							objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
//							objclsDSTRichTextBoxValue.m_strText=strText;						
//							objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
//							objData[12] = objclsDSTRichTextBoxValue;
//							objData[13] = (DateTime)(((object[])arlDetail[intCurrentDetail])[3]);
//
//							if(intRowOfCurrentDetail == ((string[])(((object[])arlDetail[intCurrentDetail])[0])).Length-1)
//							{
//								intRowOfCurrentDetail = 0;
//								intCurrentDetail ++;
//							}
//							else
//								intRowOfCurrentDetail ++;
//						}						
//					}
					//					if(i==intRecordCount-1 &&((DateTime)(((object[])arlDetail[intCurrentDetail])[4])) > objCurrent.m_dtmCreateDate)
					//						objReturnData.Add(objData);
					//
					//					if(i!=intRecordCount-1 || (i==intRecordCount-1 && ((DateTime)(((object[])arlDetail[intCurrentDetail])[4])) < objCurrent.m_dtmCreateDate))
					#endregion
					objReturnData.Add(objData);
				}
				object[][] m_objRe=new object[objReturnData.Count][];

				for(int m=0;m<objReturnData.Count ;m++)
				{
					m_objRe[m] = (object[])objReturnData[m];
                    //if(!m_blnIsInitDataTable && m_objRe[m].Length > 17)
                    //{
                    //    object[] obj = new object[17];
                    //    for(int e3=0;e3<obj.Length;e3++)
                    //        obj[e3]=m_objRe[m][e3];
                    //    m_objRe[m] = obj;
                    //}
				}
				return m_objRe;
					#endregion
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message );
				return null;
			}
			
		}

		private void mniAppend_Click(object sender, System.EventArgs e)
		{
			//调用编辑界面
//			PrivilegeData.enmPrivilegeSF enmSF = (PrivilegeData.enmPrivilegeSF)Enum.Parse(typeof(PrivilegeData.enmPrivilegeSF),this.GetType().Name);
#if FunctionPrivilege
			if(!clsPublicFunction.s_blnCheckCurrentPrivilege(enmSF,PrivilegeData.enmPrivilegeOperation.AddOrModify))
			{
				clsPublicFunction.s_mthShowNotPermitMessage();
				return;
			}			
#endif
			m_mthAddNewRecord((int)enmDiseaseTrackType.SURGERYICUWARDSHIP);
		}
		private void m_mthSetOtherDetail(object[] objDetail, int intCurrentDetail,int intRowOfCurrentDetail, out object[] objOtherDetail)
		{
			objOtherDetail = new object[14];
			string strText = ((string[])(objDetail[0]))[intRowOfCurrentDetail];
			string strXml = ((string[])(objDetail[1]))[intRowOfCurrentDetail];;
			clsDSTRichTextBoxValue objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
			objclsDSTRichTextBoxValue.m_strText=strText;						
			objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
			objOtherDetail[12] = objclsDSTRichTextBoxValue;
			objOtherDetail[13] = (DateTime)objDetail[3];
		}

//        private void m_cmdLoadAll_Click(object sender, System.EventArgs e)
//        {
//            this.Cursor = Cursors.WaitCursor;
////			m_dtbRecords.Rows.Clear();

//            m_dtbRecords.Columns.Add("DPHYSIC1",typeof(clsDSTRichTextBoxValue));//17
//            m_dtbRecords.Columns.Add("DPHYSIC2",typeof(clsDSTRichTextBoxValue));//18
//            m_dtbRecords.Columns.Add("DPHYSIC3",typeof(clsDSTRichTextBoxValue));//19
//            m_dtbRecords.Columns.Add("DPHYSIC4",typeof(clsDSTRichTextBoxValue));//20
//            m_dtbRecords.Columns.Add("DPHYSIC5",typeof(clsDSTRichTextBoxValue));//21
//            m_dtbRecords.Columns.Add("DPHYSIC6",typeof(clsDSTRichTextBoxValue));//22
//            m_dtbRecords.Columns.Add("DPHYSIC7",typeof(clsDSTRichTextBoxValue));//23
//            m_dtbRecords.Columns.Add("DPHYSIC8",typeof(clsDSTRichTextBoxValue));//24
		
//            m_dtbRecords.Columns.Add("IBLOODPRODUCE",typeof(clsDSTRichTextBoxValue));//25
//            //m_dtbRecords.Columns.Add("IBLOODPRODUCEADD",typeof(clsDSTRichTextBoxValue));//26
//            m_dtbRecords.Columns.Add("IGS",typeof(clsDSTRichTextBoxValue));//27
//            m_dtbRecords.Columns.Add("INS",typeof(clsDSTRichTextBoxValue));//28
//            m_dtbRecords.Columns.Add("INNAME1",typeof(clsDSTRichTextBoxValue));//29
//            m_dtbRecords.Columns.Add("INNAME2",typeof(clsDSTRichTextBoxValue));//9
//            m_dtbRecords.Columns.Add("INNAME3",typeof(clsDSTRichTextBoxValue));//9
//            m_dtbRecords.Columns.Add("INNAME4",typeof(clsDSTRichTextBoxValue));//9
//            m_dtbRecords.Columns.Add("INTATAL",typeof(clsDSTRichTextBoxValue));//9
//            m_dtbRecords.Columns.Add("OTATAL",typeof(clsDSTRichTextBoxValue));//9
//            m_dtbRecords.Columns.Add("OEMIEMCTION",typeof(clsDSTRichTextBoxValue));//9
//            m_dtbRecords.Columns.Add("OGASTRICJUICE",typeof(clsDSTRichTextBoxValue));//9
//            m_dtbRecords.Columns.Add("OUTNAME1",typeof(clsDSTRichTextBoxValue));//9
//            m_dtbRecords.Columns.Add("OUTNAME2",typeof(clsDSTRichTextBoxValue));//9
//            m_dtbRecords.Columns.Add("OUTNAME3",typeof(clsDSTRichTextBoxValue));//9
//            m_dtbRecords.Columns.Add("OUTNAME4",typeof(clsDSTRichTextBoxValue));//9
//            m_dtbRecords.Columns.Add("SESPECIALLYNOTE",typeof(clsDSTRichTextBoxValue));//9
//            m_dtbRecords.Columns.Add("BBLUSETIME",typeof(clsDSTRichTextBoxValue));//9

//            m_dtbRecords.Columns.Add("BBLUSEMACHINETYPE",typeof(clsDSTRichTextBoxValue));//9
//            m_dtbRecords.Columns.Add("BBLUSEMODE",typeof(clsDSTRichTextBoxValue));//9
//            m_dtbRecords.Columns.Add("BVT",typeof(clsDSTRichTextBoxValue));//9
//            m_dtbRecords.Columns.Add("BEXPIREDMV",typeof(clsDSTRichTextBoxValue));//9
//            m_dtbRecords.Columns.Add("BBLUESPRESSURE",typeof(clsDSTRichTextBoxValue));//9
//            m_dtbRecords.Columns.Add("BBLUSENUM",typeof(clsDSTRichTextBoxValue));//9

//            m_dtbRecords.Columns.Add("BFIO2PEEP",typeof(clsDSTRichTextBoxValue));//9
//            //m_dtbRecords.Columns.Add("BFI02PEEPRIGHT",typeof(clsDSTRichTextBoxValue));//9
//            m_dtbRecords.Columns.Add("BMAXIP",typeof(clsDSTRichTextBoxValue));//9
//            m_dtbRecords.Columns.Add("BBLUSESOUND",typeof(clsDSTRichTextBoxValue));//9
//            m_dtbRecords.Columns.Add("BPHLEGMCOLOR",typeof(clsDSTRichTextBoxValue));//9
//            //m_dtbRecords.Columns.Add("BPHLEGMAMOUNT",typeof(clsDSTRichTextBoxValue));//9
//            m_dtbRecords.Columns.Add("BSQ2",typeof(clsDSTRichTextBoxValue));//9
//            m_dtbRecords.Columns.Add("TCOLLECTBLOODPOINT",typeof(clsDSTRichTextBoxValue));//9

//            m_dtbRecords.Columns.Add("TPH",typeof(clsDSTRichTextBoxValue));//9
//            m_dtbRecords.Columns.Add("TPCO2",typeof(clsDSTRichTextBoxValue));//9
//            m_dtbRecords.Columns.Add("TP02",typeof(clsDSTRichTextBoxValue));//9
//            m_dtbRecords.Columns.Add("THCO3",typeof(clsDSTRichTextBoxValue));//9
//            m_dtbRecords.Columns.Add("TTCO2",typeof(clsDSTRichTextBoxValue));//9
//            m_dtbRecords.Columns.Add("TBE",typeof(clsDSTRichTextBoxValue));//9

//            m_dtbRecords.Columns.Add("TSAT",typeof(clsDSTRichTextBoxValue));//9
//            m_dtbRecords.Columns.Add("TO2CT",typeof(clsDSTRichTextBoxValue));//9
//            m_dtbRecords.Columns.Add("SCMH2O",typeof(clsDSTRichTextBoxValue));//9
//            m_dtbRecords.Columns.Add("SSD",typeof(clsDSTRichTextBoxValue));//9
//            m_dtbRecords.Columns.Add("SMEAN",typeof(clsDSTRichTextBoxValue));//9
//            m_dtbRecords.Columns.Add("SWEDGE",typeof(clsDSTRichTextBoxValue));//9
//            m_dtbRecords.Columns.Add("SCOCI",typeof(clsDSTRichTextBoxValue));//9
			
			
//            m_mthSetControl(clmRecordDateofDay);
//            m_mthSetControl(clmCreateTime);
//            m_mthSetControl(m_dtcPBODYPART);
//            m_mthSetControl(m_dtcPCONSCIOUSNESS);
//            m_mthSetControl(m_dtcPPUPIL);
//            //m_mthSetControl(m_dtcPPUPLRIGHT);
//            m_mthSetControl(m_dtcPREFLECT);
//            //m_mthSetControl(m_dtcPREFLECTRIGHT);
			
//            m_mthSetControl(clmSign);
//            m_mthSetControl(m_dtcCTEMPERATURE);
//            m_mthSetControl(m_dtcCSMALLTEMPERATURE);
//            m_mthSetControl(m_dtcCHEARTRATE);
//            m_mthSetControl(m_dtcCHEARTRHYTHM);
//            m_mthSetControl(m_dtcCSD);
//            m_mthSetControl(m_dtcCCVP);

//            m_mthSetControl(m_dtcDPHYSIC1);
//            m_mthSetControl(m_dtcDPHYSIC2);
//            m_mthSetControl(m_dtcDPHYSIC3);
//            m_mthSetControl(m_dtcDPHYSIC4);
//            m_mthSetControl(m_dtcDPHYSIC5);
//            m_mthSetControl(m_dtcDPHYSIC6);
//            m_mthSetControl(m_dtcDPHYSIC7);
//            m_mthSetControl(m_dtcDPHYSIC8);

//            m_mthSetControl(m_dtcIBLOODPRODUCE);
//            //m_mthSetControl(m_dtcIBLOODPRODUCEADD);
//            m_mthSetControl(m_dtcIGS);
//            m_mthSetControl(m_dtcINS);
//            m_mthSetControl(m_dtcINNAME1);
//            m_mthSetControl(m_dtcINNAME2);
//            m_mthSetControl(m_dtcINNAME3);
//            m_mthSetControl(m_dtcINNAME4);
//            m_mthSetControl(m_dtcINTATAL);
//            m_mthSetControl(m_dtcOTATAL);
//            m_mthSetControl(m_dtcOEMIEMCTION);
//            m_mthSetControl(m_dtcOGASTRICJUICE);
//            m_mthSetControl(m_dtcOUTNAME1);
//            m_mthSetControl(m_dtcOUTNAME2);
//            m_mthSetControl(m_dtcOUTNAME3);
//            m_mthSetControl(m_dtcOUTNAME4);
			

//            m_mthSetControl(m_dtcSESPECIALLYNOTE);
//            m_mthSetControl(m_dtcBBLUSETIME);
//            m_mthSetControl(m_dtcBBLUSEMACHINETYPE);
//            m_mthSetControl(m_dtcBBLUSEMODE);
//            m_mthSetControl(m_dtcBVT);
//            m_mthSetControl(m_dtcBEXPIREDMV);
//            m_mthSetControl(m_dtcBBLUESPRESSURE);
//            m_mthSetControl(m_dtcBBLUSENUM);
//            m_mthSetControl(m_dtcBFIO2PEEP);
//            //m_mthSetControl(m_dtcBFI02PEEPRIGHT);
//            m_mthSetControl(m_dtcBMAXIP);

//            m_mthSetControl(m_dtcBBLUSESOUND);
//            m_mthSetControl(m_dtcBPHLEGMCOLOR);
//            //m_mthSetControl(m_dtcBPHLEGMAMOUNT);
//            m_mthSetControl(m_dtcBSQ2);
//            m_mthSetControl(m_dtcTCOLLECTBLOODPOINT);
//            m_mthSetControl(m_dtcTPH);
//            m_mthSetControl(m_dtcTPCO2);
//            m_mthSetControl(m_dtcTP02);
//            m_mthSetControl(m_dtcTHCO3);
//            m_mthSetControl(m_dtcTTCO2);
//            m_mthSetControl(m_dtcTBE);

//            m_mthSetControl(m_dtcTSAT);
//            m_mthSetControl(m_dtcTO2CT);
//            m_mthSetControl(m_dtcSCMH2O);
//            m_mthSetControl(m_dtcSSD);
//            m_mthSetControl(m_dtcSMEAN);
//            m_mthSetControl(m_dtcSWEDGE);
//            m_mthSetControl(m_dtcSCOCI);

//            //设置文字栏
//            this.clmRecordDateofDay.HeaderText = "\r\n 日期";
//            this.clmCreateTime.HeaderText = "\r\n 时间";
//            this.m_dtcPBODYPART.HeaderText = " 体\r\n\r\n 位\r\n\r\n";
//            this.m_dtcPCONSCIOUSNESS.HeaderText = " 意\r\n\r\n 识\r\n\r\n";
//            this.m_dtcPPUPIL.HeaderText = " 瞳\r\n\r\n 孔\r\n\r\n(左/右)";
//            this.m_dtcPREFLECT.HeaderText = " 对\r\n 光\r\n 反\r\n 射\r\n(左/右)";
//            //this.clmSign.HeaderText = "签\r\n  名r\n ";
//            this.m_dtcCTEMPERATURE.HeaderText = " 体\r\n 温\r\n ";
//            this.m_dtcCSMALLTEMPERATURE.HeaderText =" 未\r\n 稍\r\n 温\r\n ";
//            this.m_dtcCHEARTRATE.HeaderText = " 心\r\n 率\r\n  ";
//            this.m_dtcCHEARTRHYTHM.HeaderText = " 心\r\n 律\r\n  ";
//            this.m_dtcCSD.HeaderText = " S\r\n D\r\n  ";
//            this.m_dtcCCVP.HeaderText = " C\r\n V\r\n P\r\n ";

//            this.m_dtcDPHYSIC1.HeaderText =  "  用\r\n  药\r\n  治\r\n  疗1\r\n";
//            this.m_dtcDPHYSIC2.HeaderText =  "  用\r\n  药\r\n  治\r\n  疗2\r\n";
//            this.m_dtcDPHYSIC3.HeaderText =  "  用\r\n  药\r\n  治\r\n  疗3\r\n";
//            this.m_dtcDPHYSIC4.HeaderText =  "  用\r\n  药\r\n  治\r\n  疗4\r\n";
//            this.m_dtcDPHYSIC5.HeaderText =  "  用\r\n  药\r\n  治\r\n  疗5\r\n";
//            this.m_dtcDPHYSIC6.HeaderText =  "  用\r\n  药\r\n  治\r\n  疗6\r\n";
//            this.m_dtcDPHYSIC7.HeaderText =  "  用\r\n  药\r\n  治\r\n  疗7\r\n";
//            this.m_dtcDPHYSIC8.HeaderText =  "  用\r\n  药\r\n  治\r\n  疗8\r\n";
//            this.m_dtcIBLOODPRODUCE.HeaderText =   " 血\r\n 制\r\n 品\r\n &累\r\n 计\r\n 量\r\n";
//            //this.m_dtcIBLOODPRODUCEADD.HeaderText =   " 累\r\n 计\r\n 量\r\n  ";
//            this.m_dtcIGS.HeaderText =   " G\r\n S\r\n ";
//            this.m_dtcINS.HeaderText =   " N\r\n S\r\n ";
//            this.m_dtcINNAME1.HeaderText =   " 入\r\n 量1\r\n ";
//            this.m_dtcINNAME2.HeaderText =   " 入\r\n 量2\r\n ";
//            this.m_dtcINNAME3.HeaderText =   " 入\r\n 量3\r\n ";
//            this.m_dtcINNAME4.HeaderText =   " 入\r\n 量4\r\n ";
//            this.m_dtcINTATAL.HeaderText =   "  入\r\n  量\r\n  累\r\n  计\r\n  ";
//            this.m_dtcOTATAL.HeaderText =   "  出\r\n  量\r\n  累\r\n  计\r\n  ";
//            this.m_dtcOEMIEMCTION.HeaderText =   " 尿\r\n 量\r\n ";
//            this.m_dtcOGASTRICJUICE.HeaderText =   " 胃\r\n 液\r\n ";
//            this.m_dtcOUTNAME1.HeaderText =    " 出\r\n 量1\r\n ";
//            this.m_dtcOUTNAME2.HeaderText =    " 出\r\n 量2\r\n ";
//            this.m_dtcOUTNAME3.HeaderText =    " 出\r\n 量3\r\n ";
//            this.m_dtcOUTNAME4.HeaderText =    " 出\r\n 量4\r\n ";
//            this.m_dtcSESPECIALLYNOTE.HeaderText =   " 特\r\n 殊\r\n 记\r\n 录\r\n";
//            this.m_dtcBBLUSETIME.HeaderText =   " 插\r\n 管\r\n 时\r\n 间\r\n";
//            this.m_dtcBBLUSEMACHINETYPE.HeaderText =   " 呼\r\n 吸\r\n 机\r\n 型\r\n 号\r\n";
//            this.m_dtcBBLUSEMODE.HeaderText =   " 呼\r\n 吸\r\n 方\r\n 式\r\n";
//            this.m_dtcBVT.HeaderText =   "Vt\r\n";
//            this.m_dtcBEXPIREDMV.HeaderText =   " Expired\r\n MV\r\n ";
//            this.m_dtcBBLUESPRESSURE.HeaderText =  " 气\r\n 道\r\n 压\r\n 力\r\n  ";
//            this.m_dtcBBLUSENUM.HeaderText =   " 呼\r\n 吸\r\n 次\r\n 数\r\n  ";

//            this.m_dtcBFIO2PEEP.HeaderText =   " FIO2(%)\r\n PEEP\r\n ";
			
//            this.m_dtcBMAXIP.HeaderText =   " Max\r\n I.P\r\n ";
//            this.m_dtcBBLUSESOUND.HeaderText =   " 呼\r\n 吸\r\n 音\r\n";
//            this.m_dtcBPHLEGMCOLOR.HeaderText =   " 痰色\r\n 痰量\r\n  ";
//            this.m_dtcBSQ2.HeaderText =   " SQ2\r\n ";
//            this.m_dtcTCOLLECTBLOODPOINT.HeaderText =   " 采\r\n 血\r\n 点\r\n ";
//            this.m_dtcTPH.HeaderText =   " PH\r\n";
//            this.m_dtcTPCO2.HeaderText =   " PCQ2\r\n (K+)\r\n ";
//            this.m_dtcTP02.HeaderText =   " PQ2\r\n (Na+)\r\n ";
//            this.m_dtcTHCO3.HeaderText =   " HCO3\r\n (CL-)\r\n ";
//            this.m_dtcTTCO2.HeaderText =   " TCO2\r\n(Ca++)\r\n  ";
//            this.m_dtcTBE.HeaderText =   " BE\r\n (Bun)\r\n ";
//            this.m_dtcTSAT.HeaderText =  " SAT\r\n (Cr)\r\n   ";
//            this.m_dtcTO2CT.HeaderText =   " O2CT\r\n";

//            this.m_dtcSCMH2O.HeaderText =   " CmH2O\r\n mmHg\r\n ";
//            this.m_dtcSSD.HeaderText =   " S\r\n D\r\n  ";
//            this.m_dtcSMEAN.HeaderText =   " Mean\r\n";
//            this.m_dtcSWEDGE.HeaderText =  " Wedge\r\n";
//            this.m_dtcSCOCI.HeaderText =   "CO/CI\r\n    ";

//            m_blnIsInitDataTable = true;
//            m_cmdLoadAll.Enabled = false;
////			m_dtmPreRecordDate = DateTime.MinValue;
//            if(m_objCurrentPatient != null)
//                m_trvInPatientDate_AfterSelect(m_trvInPatientDate, null);
			
//            this.Cursor = Cursors.Default;
//        }

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

        #region 打印
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
               //   m_pdcPrintDocument.DefaultPageSettings.Landscape = false;
               // m_pdcPrintDocument.DefaultPageSettings.PaperSize = new PaperSize("A4", 1024, 768);
                m_pdcPrintDocument.DefaultPageSettings.Landscape = true;
                m_pdcPrintDocument.DefaultPageSettings.PaperSize=new PaperSize("A3",1620,1150);

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

                if (m_blnDirectPrint)
                {
                    //clsContinuousPrintTool objConinuePrintTool = objPrintTool as clsContinuousPrintTool;
                    //if (objConinuePrintTool != null)
                    //{
                    //    objConinuePrintTool.m_mthSetContinuePrint(m_objBaseCurrentPatient.m_StrInPatientID, m_trvInPatientDate.SelectedNode.Text);
                    //    if (objConinuePrintTool.m_blnHavePrintAllRecords())
                    //    {
                    //        clsPublicFunction.ShowInformationMessageBox("上一次打印已打印完全部记录，如需重新打印，请按打印预览！");
                    //        return;
                    //    }
                    //}
                    ((clsSurgeryICUWardship_PrintTool)objPrintTool).printView = false;
                    m_pdcPrintDocument.Print();
                }
                else
                {
                    ((clsSurgeryICUWardship_PrintTool)objPrintTool).printView = true;
                    PrintTool.frmPrintPreviewDialog ppdPrintPreview = new PrintTool.frmPrintPreviewDialog();
                    ppdPrintPreview.Document = m_pdcPrintDocument;
                    ppdPrintPreview.ShowDialog();
                }

               
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("No Printers installed") >= 0)
                    clsPublicFunction.ShowInformationMessageBox("找不到打印机！");
                else MessageBox.Show(ex.Message);
            }

        		//base.m_mthStartPrint();


        }
        protected override infPrintRecord m_objGetPrintTool()
        {
            /***add by wjqin(06-2-30)***/

            //System.IO.StreamWriter st = new System.IO.StreamWriter(@"d:\bill.txt", false);
            //string str = "";
            //for (int i = 0; i < m_dtgRecordDetail.TableStyles.Count; i++)
            //{
            //    str = m_dtgRecordDetail.TableStyles[0].GridColumnStyles[i].HeaderText.ToString().Trim() + "    " + m_dtgRecordDetail.TableStyles[0].GridColumnStyles[i].MappingName.ToString().Trim() + "\r\n";

            //}


            printTable = new DataTable();
            for (int i = 0; i < m_dtbRecords.Columns.Count; i++)
            {

                printTable.Columns.Add(m_dtbRecords.Columns[i].ColumnName);
            }
            //str += " ****************datatable*****************" + "\r\n";
            m_dtbRecords.DefaultView.Sort = "RecordDate asc,RecordTime asc";
            //    str += " ****************value*****************" + "\r\n";
            for (int i = 0; i < m_dtbRecords.Rows.Count; i++)
            {
                System.Data.DataRow row1 = printTable.NewRow();
                //         str += " ****************row" + i + "*****************" + "\r\n";
                for (int j = 0; j < m_dtbRecords.Columns.Count; j++)
                {


                    System.Type type1 = m_dtbRecords.Rows[i][j].GetType();
                    if (m_dtbRecords.Rows[i][j] is clsDSTRichTextBoxValue)
                    {
                        //       str += m_dtbRecords.Columns[j].ColumnName.ToString().Trim() + "  ---  " + ((clsDSTRichTextBoxValue)m_dtbRecords.Rows[i][j]).m_strText.ToString().Trim() + "\r\n";
                        row1[m_dtbRecords.Columns[j].ColumnName.ToString().Trim()] = ((clsDSTRichTextBoxValue)m_dtbRecords.Rows[i][j]).m_strText.ToString().Trim();
                    }
                    else
                    {
                        //       str += m_dtbRecords.Columns[j].ColumnName.ToString().Trim() + "  ---  " + m_dtbRecords.Rows[i][j] + "\r\n";
                        row1[m_dtbRecords.Columns[j].ColumnName.ToString().Trim()] = m_dtbRecords.Rows[i][j].ToString().Trim();

                    }

                }
                printTable.Rows.Add(row1);


            }

            //str = "";
            //for (int i = 0; i < printTable.Rows.Count; i++)
            //{
            //    str += "************************row" + i + "*********************";
            //    for (int j = 0; j < printTable.Columns.Count; j++)
            //    {
            //        str += printTable.Columns[j].ColumnName.ToString().Trim() + " --- " + printTable.Rows[i][j].ToString().Trim() + "\r\n";
            //    }
            //}

            //st.WriteLine(str);
            //st.Flush();
            //st.Close();

            /*------------------------------------------------*/
            //if (m_blnDirectPrint)
            //{
            //    m_pdcPrintDocument.Print();
            //}
            //else
            //{

             //  ((clsSurgeryICUWardship_PrintTool)objPrintTool).m_mthPrintPage(m_pdcPrintDocument.DefaultPageSettings, printTable, m_objCurrentPatient, this.personMessageArr);

            //}
            return new clsSurgeryICUWardship_PrintTool(printTable, m_objCurrentPatient, this.personMessageArr);
        }

        private  void m_mthGetRecord(clsPatient p_objPatient)
        {
            if (p_objPatient == null) return;
            //获取病人记录列表
            clsTransDataInfo[] objTansDataInfoArr;
            m_objRecordsDomain.m_lngGetTransDataInfoArr(p_objPatient.m_StrEMRInPatientID, p_objPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"), out objTansDataInfoArr);

            if (objTansDataInfoArr == null)
            {
                return;
            }

            //按记录时间(CreateDate)排序
            //modified by  thfzhang 2005-11-12 危重护理不需要排序
            if (this.Name != "frmIntensiveTendMain_FC")
                m_mthSortTransData(ref objTansDataInfoArr);

            DataTable dtbAddBlank;
            clsDiseaseTrackAddBlankDomain objAddBlankDomain = new clsDiseaseTrackAddBlankDomain();
            objAddBlankDomain.m_lngGetBlankRecordContent(p_objPatient.m_StrInPatientID, p_objPatient.m_DtmSelectedInDate, out dtbAddBlank);

            //添加记录到的DataTable
            object[][] objDataArr;
            for (int i1 = 0; i1 < objTansDataInfoArr.Length; i1++)
            {
                if (dtbAddBlank != null && dtbAddBlank.Rows.Count > 0)
                {
                    //查找记录之前有否空行记录,有插入空行
                    foreach (DataRow drtAdd in dtbAddBlank.Rows)
                    {
                        if (objTansDataInfoArr[i1].m_objRecordContent != null)
                        {
                            if (objTansDataInfoArr[i1].m_objRecordContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss") == DateTime.Parse(drtAdd["opendate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss"))
                            {
                                object[] objBlank = new object[5];
                                objBlank[1] = 100;
                                objBlank[2] = drtAdd[2].ToString();
                                m_dtbRecords.Rows.Add(objBlank);
                                for (int k3 = 0; k3 < (Int32.Parse(drtAdd[3].ToString()) - 1); k3++)
                                {
                                    m_dtbRecords.Rows.Add(new object[] { });
                                }
                                break;
                            }
                        }
                    }
                }

                objDataArr = m_objGetRecordsValueArr(objTansDataInfoArr[i1]);

                if (objDataArr == null)
                    continue;

                m_dtbRecords.BeginLoadData();
                for (int j2 = 0; j2 < objDataArr.Length; j2++)
                {
                    m_dtbRecords.LoadDataRow(objDataArr[j2], true);
                }
                m_dtbRecords.EndLoadData();
                m_dtgRecordDetail.EnsureVisible(m_dtbRecords.Rows.Count - 1);
                Application.DoEvents();
            }

            if (m_dtbRecords.Rows.Count == 0 && !m_blnIfNewDeletedRecord)
            {
                m_mthAutoAddNewRecord();
            }
        }

        protected virtual DataTable m_objGetPrintTable(clsPatient p_objPatient)
        {
            m_mthInitDataTable(m_dtbRecords);
            m_mthGetRecord(p_objPatient);
            printTable = new DataTable();
            for (int i = 0; i < m_dtbRecords.Columns.Count; i++)
            {
                printTable.Columns.Add(m_dtbRecords.Columns[i].ColumnName);
            }
            //str += " ****************datatable*****************" + "\r\n";
            m_dtbRecords.DefaultView.Sort = "RecordDate asc,RecordTime asc";
            //    str += " ****************value*****************" + "\r\n";
            for (int i = 0; i < m_dtbRecords.Rows.Count; i++)
            {
                System.Data.DataRow row1 = printTable.NewRow();
                //         str += " ****************row" + i + "*****************" + "\r\n";
                for (int j = 0; j < m_dtbRecords.Columns.Count; j++)
                {
                    System.Type type1 = m_dtbRecords.Rows[i][j].GetType();
                    if (m_dtbRecords.Rows[i][j] is clsDSTRichTextBoxValue)
                    {
                        //       str += m_dtbRecords.Columns[j].ColumnName.ToString().Trim() + "  ---  " + ((clsDSTRichTextBoxValue)m_dtbRecords.Rows[i][j]).m_strText.ToString().Trim() + "\r\n";
                        row1[m_dtbRecords.Columns[j].ColumnName.ToString().Trim()] = ((clsDSTRichTextBoxValue)m_dtbRecords.Rows[i][j]).m_strText.ToString().Trim();
                    }
                    else
                    {
                        //       str += m_dtbRecords.Columns[j].ColumnName.ToString().Trim() + "  ---  " + m_dtbRecords.Rows[i][j] + "\r\n";
                        row1[m_dtbRecords.Columns[j].ColumnName.ToString().Trim()] = m_dtbRecords.Rows[i][j].ToString().Trim();
                    }

                }
                printTable.Rows.Add(row1);
            }
            return printTable;
        }


        #endregion

	}
}
