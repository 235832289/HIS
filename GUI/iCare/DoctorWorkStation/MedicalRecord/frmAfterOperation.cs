#define FunctionPrivilege
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using com.digitalwave.Emr.Signature_gui;
using System.Windows.Forms;
using iCareData;
using com.digitalwave.Utility.Controls;
using System.Data;
using HRP;
using PrivilegeData;


namespace iCare
{
	/// <summary>
	/// （手术后病程记录）病程记录子窗体的实现,Jacky-2003-5-19
	/// </summary>
	public class frmAfterOperation : iCare.frmDiseaseTrackBase
	{
		private PinkieControls.ButtonXP cmdConfirm;
		private System.Windows.Forms.Label lblAnaesthesiaModeTitle;
		private com.digitalwave.controls.ctlRichTextBox m_txtAnaesthesiaMode;
		private System.Windows.Forms.Label lblInOperationSeeingTitle;
		private com.digitalwave.controls.ctlRichTextBox m_txtInOperationSeeing;
		private System.Windows.Forms.Label lblOperationDiagnoseTitle;
		private com.digitalwave.controls.ctlRichTextBox m_txtOperationDiagnose;
		private System.Windows.Forms.Label lblOperationNameTitle;
		private com.digitalwave.controls.ctlRichTextBox m_txtOperationName;
		private System.Windows.Forms.Label lblAfterOperationDealTitle;
		private com.digitalwave.controls.ctlRichTextBox m_txtAfterOperationDeal;
		private System.Windows.Forms.Label lblAfterOperationNoticeTitle;
		private com.digitalwave.controls.ctlRichTextBox m_txtAfterOperationNotice;
		private System.Windows.Forms.Label lblCutHealUpStatusTitle;
		private com.digitalwave.controls.ctlRichTextBox m_txtCutHealUpStatus;
		protected System.Windows.Forms.Label lblTakeOutStitchesDateTitle;
		protected com.digitalwave.Utility.Controls.ctlTimePicker m_dtpTakeOutStitchesDate;
		private PinkieControls.ButtonXP m_cmdClose;
		private System.ComponentModel.IContainer components = null;
	 
		private PinkieControls.ButtonXP m_cmdEmployeeSign;
		protected System.Windows.Forms.ListView lsvSign;
		private System.Windows.Forms.ColumnHeader clmEmployeeName;
		//定义签名类
		private clsEmrSignToolCollection m_objSign;

		public frmAfterOperation()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

            //指明医生工作站表单
            intFormType = 1;
			cmdConfirm.Visible=false;
			
			m_mthSetRichTextBoxAttribInControl(this);

			this.Text="手术后病程记录";			
			this.m_lblForTitle.Text=this.Text;			
			
		 

			//签名常用值
			m_objSign = new clsEmrSignToolCollection();
			//m_mthBindEmployeeSign(按钮,签名框,医生1or护士2,身份验证trueorfalse);
            m_objSign.m_mthBindEmployeeSign(m_cmdEmployeeSign, lsvSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);

			m_objShareDomain = new clsOperationRecordDoctorShareDomain();
		
		}
		private clsOperationRecordDoctorShareDomain m_objShareDomain;
		
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.cmdConfirm = new PinkieControls.ButtonXP();
            this.lblInOperationSeeingTitle = new System.Windows.Forms.Label();
            this.m_txtInOperationSeeing = new com.digitalwave.controls.ctlRichTextBox();
            this.lblOperationDiagnoseTitle = new System.Windows.Forms.Label();
            this.m_txtOperationDiagnose = new com.digitalwave.controls.ctlRichTextBox();
            this.lblOperationNameTitle = new System.Windows.Forms.Label();
            this.m_txtOperationName = new com.digitalwave.controls.ctlRichTextBox();
            this.lblAnaesthesiaModeTitle = new System.Windows.Forms.Label();
            this.m_txtAnaesthesiaMode = new com.digitalwave.controls.ctlRichTextBox();
            this.lblAfterOperationDealTitle = new System.Windows.Forms.Label();
            this.m_txtAfterOperationDeal = new com.digitalwave.controls.ctlRichTextBox();
            this.lblAfterOperationNoticeTitle = new System.Windows.Forms.Label();
            this.m_txtAfterOperationNotice = new com.digitalwave.controls.ctlRichTextBox();
            this.lblCutHealUpStatusTitle = new System.Windows.Forms.Label();
            this.m_txtCutHealUpStatus = new com.digitalwave.controls.ctlRichTextBox();
            this.lblTakeOutStitchesDateTitle = new System.Windows.Forms.Label();
            this.m_dtpTakeOutStitchesDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.m_cmdClose = new PinkieControls.ButtonXP();
            this.m_cmdEmployeeSign = new PinkieControls.ButtonXP();
            this.lsvSign = new System.Windows.Forms.ListView();
            this.clmEmployeeName = new System.Windows.Forms.ColumnHeader();
            this.m_pnlNewBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_trvCreateDate
            // 
            this.m_trvCreateDate.LineColor = System.Drawing.Color.Black;
            this.m_trvCreateDate.Location = new System.Drawing.Point(44, -82);
            this.m_trvCreateDate.Visible = false;
            // 
            // lblCreateDateTitle
            // 
            this.lblCreateDateTitle.Location = new System.Drawing.Point(56, 30);
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.Location = new System.Drawing.Point(140, 26);
            // 
            // m_dtpGetDataTime
            // 
            this.m_dtpGetDataTime.Location = new System.Drawing.Point(396, -13);
            // 
            // m_lblGetDataTime
            // 
            this.m_lblGetDataTime.Location = new System.Drawing.Point(412, -11);
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(549, -27);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(649, -27);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(237, -27);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(456, -16);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(361, -27);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(497, -27);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(601, -27);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(260, -16);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(15, -98);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(516, -16);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(409, -31);
            this.m_txtPatientName.Size = new System.Drawing.Size(80, 23);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(285, -31);
            this.m_txtBedNO.Size = new System.Drawing.Size(72, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(308, -20);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(64, -95);
            this.m_lsvPatientName.Size = new System.Drawing.Size(80, 104);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(11, -95);
            this.m_lsvBedNO.Size = new System.Drawing.Size(72, 104);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(89, -31);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(41, -23);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(605, -35);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.Location = new System.Drawing.Point(196, -52);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(156, -52);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(272, -48);
            this.m_lblForTitle.Text = "手术后病程记录";
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(31, 510);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(638, -30);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Location = new System.Drawing.Point(19, -64);
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            // 
            // cmdConfirm
            // 
            this.cmdConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.cmdConfirm.DefaultScheme = true;
            this.cmdConfirm.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdConfirm.Hint = "";
            this.cmdConfirm.Location = new System.Drawing.Point(692, 504);
            this.cmdConfirm.Name = "cmdConfirm";
            this.cmdConfirm.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdConfirm.Size = new System.Drawing.Size(80, 30);
            this.cmdConfirm.TabIndex = 200;
            this.cmdConfirm.Text = "确定";
            this.cmdConfirm.Click += new System.EventHandler(this.cmdConfirm_Click);
            // 
            // lblInOperationSeeingTitle
            // 
            this.lblInOperationSeeingTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblInOperationSeeingTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInOperationSeeingTitle.ForeColor = System.Drawing.Color.Black;
            this.lblInOperationSeeingTitle.Location = new System.Drawing.Point(12, 225);
            this.lblInOperationSeeingTitle.Name = "lblInOperationSeeingTitle";
            this.lblInOperationSeeingTitle.Size = new System.Drawing.Size(124, 76);
            this.lblInOperationSeeingTitle.TabIndex = 6095;
            this.lblInOperationSeeingTitle.Text = "手术中所见:  (手术简要经过,引流物,手术标本及其处理)";
            // 
            // m_txtInOperationSeeing
            // 
            this.m_txtInOperationSeeing.AccessibleDescription = "手术中所见";
            this.m_txtInOperationSeeing.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtInOperationSeeing.BackColor = System.Drawing.Color.White;
            this.m_txtInOperationSeeing.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtInOperationSeeing.ForeColor = System.Drawing.Color.Black;
            this.m_txtInOperationSeeing.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtInOperationSeeing.Location = new System.Drawing.Point(140, 222);
            this.m_txtInOperationSeeing.m_BlnIgnoreUserInfo = false;
            this.m_txtInOperationSeeing.m_BlnPartControl = false;
            this.m_txtInOperationSeeing.m_BlnReadOnly = false;
            this.m_txtInOperationSeeing.m_BlnUnderLineDST = false;
            this.m_txtInOperationSeeing.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtInOperationSeeing.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtInOperationSeeing.m_IntCanModifyTime = 6;
            this.m_txtInOperationSeeing.m_IntPartControlLength = 0;
            this.m_txtInOperationSeeing.m_IntPartControlStartIndex = 0;
            this.m_txtInOperationSeeing.m_StrUserID = "";
            this.m_txtInOperationSeeing.m_StrUserName = "";
            this.m_txtInOperationSeeing.Name = "m_txtInOperationSeeing";
            this.m_txtInOperationSeeing.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtInOperationSeeing.Size = new System.Drawing.Size(720, 93);
            this.m_txtInOperationSeeing.TabIndex = 130;
            this.m_txtInOperationSeeing.Text = "";
            // 
            // lblOperationDiagnoseTitle
            // 
            this.lblOperationDiagnoseTitle.AutoSize = true;
            this.lblOperationDiagnoseTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblOperationDiagnoseTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOperationDiagnoseTitle.ForeColor = System.Drawing.Color.Black;
            this.lblOperationDiagnoseTitle.Location = new System.Drawing.Point(56, 154);
            this.lblOperationDiagnoseTitle.Name = "lblOperationDiagnoseTitle";
            this.lblOperationDiagnoseTitle.Size = new System.Drawing.Size(70, 14);
            this.lblOperationDiagnoseTitle.TabIndex = 6093;
            this.lblOperationDiagnoseTitle.Text = "术中诊断:";
            // 
            // m_txtOperationDiagnose
            // 
            this.m_txtOperationDiagnose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtOperationDiagnose.BackColor = System.Drawing.Color.White;
            this.m_txtOperationDiagnose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOperationDiagnose.ForeColor = System.Drawing.Color.Black;
            this.m_txtOperationDiagnose.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOperationDiagnose.Location = new System.Drawing.Point(140, 151);
            this.m_txtOperationDiagnose.m_BlnIgnoreUserInfo = false;
            this.m_txtOperationDiagnose.m_BlnPartControl = false;
            this.m_txtOperationDiagnose.m_BlnReadOnly = false;
            this.m_txtOperationDiagnose.m_BlnUnderLineDST = false;
            this.m_txtOperationDiagnose.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOperationDiagnose.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOperationDiagnose.m_IntCanModifyTime = 6;
            this.m_txtOperationDiagnose.m_IntPartControlLength = 0;
            this.m_txtOperationDiagnose.m_IntPartControlStartIndex = 0;
            this.m_txtOperationDiagnose.m_StrUserID = "";
            this.m_txtOperationDiagnose.m_StrUserName = "";
            this.m_txtOperationDiagnose.Name = "m_txtOperationDiagnose";
            this.m_txtOperationDiagnose.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtOperationDiagnose.Size = new System.Drawing.Size(720, 65);
            this.m_txtOperationDiagnose.TabIndex = 120;
            this.m_txtOperationDiagnose.Text = "";
            // 
            // lblOperationNameTitle
            // 
            this.lblOperationNameTitle.AutoSize = true;
            this.lblOperationNameTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblOperationNameTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOperationNameTitle.ForeColor = System.Drawing.Color.Black;
            this.lblOperationNameTitle.Location = new System.Drawing.Point(56, 122);
            this.lblOperationNameTitle.Name = "lblOperationNameTitle";
            this.lblOperationNameTitle.Size = new System.Drawing.Size(70, 14);
            this.lblOperationNameTitle.TabIndex = 6091;
            this.lblOperationNameTitle.Text = "手术名称:";
            // 
            // m_txtOperationName
            // 
            this.m_txtOperationName.AccessibleDescription = "手术名称";
            this.m_txtOperationName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtOperationName.BackColor = System.Drawing.Color.White;
            this.m_txtOperationName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOperationName.ForeColor = System.Drawing.Color.Black;
            this.m_txtOperationName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOperationName.Location = new System.Drawing.Point(140, 119);
            this.m_txtOperationName.m_BlnIgnoreUserInfo = false;
            this.m_txtOperationName.m_BlnPartControl = false;
            this.m_txtOperationName.m_BlnReadOnly = false;
            this.m_txtOperationName.m_BlnUnderLineDST = false;
            this.m_txtOperationName.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOperationName.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOperationName.m_IntCanModifyTime = 6;
            this.m_txtOperationName.m_IntPartControlLength = 0;
            this.m_txtOperationName.m_IntPartControlStartIndex = 0;
            this.m_txtOperationName.m_StrUserID = "";
            this.m_txtOperationName.m_StrUserName = "";
            this.m_txtOperationName.Multiline = false;
            this.m_txtOperationName.Name = "m_txtOperationName";
            this.m_txtOperationName.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtOperationName.Size = new System.Drawing.Size(720, 26);
            this.m_txtOperationName.TabIndex = 110;
            this.m_txtOperationName.Text = "";
            // 
            // lblAnaesthesiaModeTitle
            // 
            this.lblAnaesthesiaModeTitle.AutoSize = true;
            this.lblAnaesthesiaModeTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblAnaesthesiaModeTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAnaesthesiaModeTitle.ForeColor = System.Drawing.Color.Black;
            this.lblAnaesthesiaModeTitle.Location = new System.Drawing.Point(56, 90);
            this.lblAnaesthesiaModeTitle.Name = "lblAnaesthesiaModeTitle";
            this.lblAnaesthesiaModeTitle.Size = new System.Drawing.Size(70, 14);
            this.lblAnaesthesiaModeTitle.TabIndex = 6089;
            this.lblAnaesthesiaModeTitle.Text = "麻醉方式:";
            // 
            // m_txtAnaesthesiaMode
            // 
            this.m_txtAnaesthesiaMode.AccessibleDescription = "麻醉方式";
            this.m_txtAnaesthesiaMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtAnaesthesiaMode.BackColor = System.Drawing.Color.White;
            this.m_txtAnaesthesiaMode.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtAnaesthesiaMode.ForeColor = System.Drawing.Color.Black;
            this.m_txtAnaesthesiaMode.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtAnaesthesiaMode.Location = new System.Drawing.Point(140, 87);
            this.m_txtAnaesthesiaMode.m_BlnIgnoreUserInfo = false;
            this.m_txtAnaesthesiaMode.m_BlnPartControl = false;
            this.m_txtAnaesthesiaMode.m_BlnReadOnly = false;
            this.m_txtAnaesthesiaMode.m_BlnUnderLineDST = false;
            this.m_txtAnaesthesiaMode.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtAnaesthesiaMode.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtAnaesthesiaMode.m_IntCanModifyTime = 6;
            this.m_txtAnaesthesiaMode.m_IntPartControlLength = 0;
            this.m_txtAnaesthesiaMode.m_IntPartControlStartIndex = 0;
            this.m_txtAnaesthesiaMode.m_StrUserID = "";
            this.m_txtAnaesthesiaMode.m_StrUserName = "";
            this.m_txtAnaesthesiaMode.Multiline = false;
            this.m_txtAnaesthesiaMode.Name = "m_txtAnaesthesiaMode";
            this.m_txtAnaesthesiaMode.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtAnaesthesiaMode.Size = new System.Drawing.Size(720, 26);
            this.m_txtAnaesthesiaMode.TabIndex = 100;
            this.m_txtAnaesthesiaMode.Text = "";
            // 
            // lblAfterOperationDealTitle
            // 
            this.lblAfterOperationDealTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAfterOperationDealTitle.AutoSize = true;
            this.lblAfterOperationDealTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblAfterOperationDealTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAfterOperationDealTitle.ForeColor = System.Drawing.Color.Black;
            this.lblAfterOperationDealTitle.Location = new System.Drawing.Point(56, 324);
            this.lblAfterOperationDealTitle.Name = "lblAfterOperationDealTitle";
            this.lblAfterOperationDealTitle.Size = new System.Drawing.Size(70, 14);
            this.lblAfterOperationDealTitle.TabIndex = 6095;
            this.lblAfterOperationDealTitle.Text = "术后处理:";
            // 
            // m_txtAfterOperationDeal
            // 
            this.m_txtAfterOperationDeal.AccessibleDescription = "术后处理";
            this.m_txtAfterOperationDeal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtAfterOperationDeal.BackColor = System.Drawing.Color.White;
            this.m_txtAfterOperationDeal.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtAfterOperationDeal.ForeColor = System.Drawing.Color.Black;
            this.m_txtAfterOperationDeal.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtAfterOperationDeal.Location = new System.Drawing.Point(140, 321);
            this.m_txtAfterOperationDeal.m_BlnIgnoreUserInfo = false;
            this.m_txtAfterOperationDeal.m_BlnPartControl = false;
            this.m_txtAfterOperationDeal.m_BlnReadOnly = false;
            this.m_txtAfterOperationDeal.m_BlnUnderLineDST = false;
            this.m_txtAfterOperationDeal.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtAfterOperationDeal.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtAfterOperationDeal.m_IntCanModifyTime = 6;
            this.m_txtAfterOperationDeal.m_IntPartControlLength = 0;
            this.m_txtAfterOperationDeal.m_IntPartControlStartIndex = 0;
            this.m_txtAfterOperationDeal.m_StrUserID = "";
            this.m_txtAfterOperationDeal.m_StrUserName = "";
            this.m_txtAfterOperationDeal.Name = "m_txtAfterOperationDeal";
            this.m_txtAfterOperationDeal.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtAfterOperationDeal.Size = new System.Drawing.Size(720, 65);
            this.m_txtAfterOperationDeal.TabIndex = 140;
            this.m_txtAfterOperationDeal.Text = "";
            this.m_txtAfterOperationDeal.TextChanged += new System.EventHandler(this.m_txtAfterOperationDeal_TextChanged);
            // 
            // lblAfterOperationNoticeTitle
            // 
            this.lblAfterOperationNoticeTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAfterOperationNoticeTitle.AutoSize = true;
            this.lblAfterOperationNoticeTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblAfterOperationNoticeTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAfterOperationNoticeTitle.ForeColor = System.Drawing.Color.Black;
            this.lblAfterOperationNoticeTitle.Location = new System.Drawing.Point(56, 395);
            this.lblAfterOperationNoticeTitle.Name = "lblAfterOperationNoticeTitle";
            this.lblAfterOperationNoticeTitle.Size = new System.Drawing.Size(70, 14);
            this.lblAfterOperationNoticeTitle.TabIndex = 6095;
            this.lblAfterOperationNoticeTitle.Text = "术后注意:";
            // 
            // m_txtAfterOperationNotice
            // 
            this.m_txtAfterOperationNotice.AccessibleDescription = "术后注意";
            this.m_txtAfterOperationNotice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtAfterOperationNotice.BackColor = System.Drawing.Color.White;
            this.m_txtAfterOperationNotice.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtAfterOperationNotice.ForeColor = System.Drawing.Color.Black;
            this.m_txtAfterOperationNotice.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtAfterOperationNotice.Location = new System.Drawing.Point(140, 392);
            this.m_txtAfterOperationNotice.m_BlnIgnoreUserInfo = false;
            this.m_txtAfterOperationNotice.m_BlnPartControl = false;
            this.m_txtAfterOperationNotice.m_BlnReadOnly = false;
            this.m_txtAfterOperationNotice.m_BlnUnderLineDST = false;
            this.m_txtAfterOperationNotice.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtAfterOperationNotice.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtAfterOperationNotice.m_IntCanModifyTime = 6;
            this.m_txtAfterOperationNotice.m_IntPartControlLength = 0;
            this.m_txtAfterOperationNotice.m_IntPartControlStartIndex = 0;
            this.m_txtAfterOperationNotice.m_StrUserID = "";
            this.m_txtAfterOperationNotice.m_StrUserName = "";
            this.m_txtAfterOperationNotice.Name = "m_txtAfterOperationNotice";
            this.m_txtAfterOperationNotice.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtAfterOperationNotice.Size = new System.Drawing.Size(720, 66);
            this.m_txtAfterOperationNotice.TabIndex = 150;
            this.m_txtAfterOperationNotice.Text = "";
            // 
            // lblCutHealUpStatusTitle
            // 
            this.lblCutHealUpStatusTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCutHealUpStatusTitle.AutoSize = true;
            this.lblCutHealUpStatusTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblCutHealUpStatusTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCutHealUpStatusTitle.ForeColor = System.Drawing.Color.Black;
            this.lblCutHealUpStatusTitle.Location = new System.Drawing.Point(28, 467);
            this.lblCutHealUpStatusTitle.Name = "lblCutHealUpStatusTitle";
            this.lblCutHealUpStatusTitle.Size = new System.Drawing.Size(98, 14);
            this.lblCutHealUpStatusTitle.TabIndex = 6095;
            this.lblCutHealUpStatusTitle.Text = "伤口愈合情况:";
            // 
            // m_txtCutHealUpStatus
            // 
            this.m_txtCutHealUpStatus.AccessibleDescription = "伤口愈合情况";
            this.m_txtCutHealUpStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtCutHealUpStatus.BackColor = System.Drawing.Color.White;
            this.m_txtCutHealUpStatus.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCutHealUpStatus.ForeColor = System.Drawing.Color.Black;
            this.m_txtCutHealUpStatus.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCutHealUpStatus.Location = new System.Drawing.Point(140, 464);
            this.m_txtCutHealUpStatus.m_BlnIgnoreUserInfo = false;
            this.m_txtCutHealUpStatus.m_BlnPartControl = false;
            this.m_txtCutHealUpStatus.m_BlnReadOnly = false;
            this.m_txtCutHealUpStatus.m_BlnUnderLineDST = false;
            this.m_txtCutHealUpStatus.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtCutHealUpStatus.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtCutHealUpStatus.m_IntCanModifyTime = 6;
            this.m_txtCutHealUpStatus.m_IntPartControlLength = 0;
            this.m_txtCutHealUpStatus.m_IntPartControlStartIndex = 0;
            this.m_txtCutHealUpStatus.m_StrUserID = "";
            this.m_txtCutHealUpStatus.m_StrUserName = "";
            this.m_txtCutHealUpStatus.Multiline = false;
            this.m_txtCutHealUpStatus.Name = "m_txtCutHealUpStatus";
            this.m_txtCutHealUpStatus.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtCutHealUpStatus.Size = new System.Drawing.Size(720, 26);
            this.m_txtCutHealUpStatus.TabIndex = 160;
            this.m_txtCutHealUpStatus.Text = "";
            // 
            // lblTakeOutStitchesDateTitle
            // 
            this.lblTakeOutStitchesDateTitle.AutoSize = true;
            this.lblTakeOutStitchesDateTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTakeOutStitchesDateTitle.Location = new System.Drawing.Point(56, 58);
            this.lblTakeOutStitchesDateTitle.Name = "lblTakeOutStitchesDateTitle";
            this.lblTakeOutStitchesDateTitle.Size = new System.Drawing.Size(70, 14);
            this.lblTakeOutStitchesDateTitle.TabIndex = 6099;
            this.lblTakeOutStitchesDateTitle.Text = "手术时间:";
            // 
            // m_dtpTakeOutStitchesDate
            // 
            this.m_dtpTakeOutStitchesDate.BorderColor = System.Drawing.Color.Black;
            this.m_dtpTakeOutStitchesDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpTakeOutStitchesDate.DropButtonBackColor = System.Drawing.Color.Gainsboro;
            this.m_dtpTakeOutStitchesDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpTakeOutStitchesDate.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpTakeOutStitchesDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpTakeOutStitchesDate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpTakeOutStitchesDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpTakeOutStitchesDate.Location = new System.Drawing.Point(140, 55);
            this.m_dtpTakeOutStitchesDate.m_BlnOnlyTime = false;
            this.m_dtpTakeOutStitchesDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpTakeOutStitchesDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpTakeOutStitchesDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpTakeOutStitchesDate.Name = "m_dtpTakeOutStitchesDate";
            this.m_dtpTakeOutStitchesDate.ReadOnly = false;
            this.m_dtpTakeOutStitchesDate.Size = new System.Drawing.Size(212, 22);
            this.m_dtpTakeOutStitchesDate.TabIndex = 90;
            this.m_dtpTakeOutStitchesDate.TextBackColor = System.Drawing.Color.White;
            this.m_dtpTakeOutStitchesDate.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cmdClose
            // 
            this.m_cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdClose.DefaultScheme = true;
            this.m_cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdClose.Hint = "";
            this.m_cmdClose.Location = new System.Drawing.Point(780, 504);
            this.m_cmdClose.Name = "m_cmdClose";
            this.m_cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdClose.Size = new System.Drawing.Size(80, 30);
            this.m_cmdClose.TabIndex = 201;
            this.m_cmdClose.Text = "取消";
            this.m_cmdClose.Click += new System.EventHandler(this.m_cmdClose_Click);
            // 
            // m_cmdEmployeeSign
            // 
            this.m_cmdEmployeeSign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_cmdEmployeeSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdEmployeeSign.DefaultScheme = true;
            this.m_cmdEmployeeSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdEmployeeSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdEmployeeSign.ForeColor = System.Drawing.Color.Black;
            this.m_cmdEmployeeSign.Hint = "";
            this.m_cmdEmployeeSign.Location = new System.Drawing.Point(140, 506);
            this.m_cmdEmployeeSign.Name = "m_cmdEmployeeSign";
            this.m_cmdEmployeeSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdEmployeeSign.Size = new System.Drawing.Size(60, 28);
            this.m_cmdEmployeeSign.TabIndex = 170;
            this.m_cmdEmployeeSign.Tag = "1";
            this.m_cmdEmployeeSign.Text = "签名:";
            // 
            // lsvSign
            // 
            this.lsvSign.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvSign.BackColor = System.Drawing.Color.White;
            this.lsvSign.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmEmployeeName});
            this.lsvSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvSign.ForeColor = System.Drawing.Color.Black;
            this.lsvSign.FullRowSelect = true;
            this.lsvSign.GridLines = true;
            this.lsvSign.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lsvSign.Location = new System.Drawing.Point(204, 506);
            this.lsvSign.Name = "lsvSign";
            this.lsvSign.Size = new System.Drawing.Size(468, 28);
            this.lsvSign.TabIndex = 6100;
            this.lsvSign.UseCompatibleStateImageBehavior = false;
            this.lsvSign.View = System.Windows.Forms.View.SmallIcon;
            // 
            // clmEmployeeName
            // 
            this.clmEmployeeName.Width = 55;
            // 
            // frmAfterOperation
            // 
            this.AccessibleDescription = "手术后病程记录";
            this.ClientSize = new System.Drawing.Size(886, 549);
            this.Controls.Add(this.lblOperationDiagnoseTitle);
            this.Controls.Add(this.lblAfterOperationDealTitle);
            this.Controls.Add(this.lblAfterOperationNoticeTitle);
            this.Controls.Add(this.m_cmdEmployeeSign);
            this.Controls.Add(this.lblCutHealUpStatusTitle);
            this.Controls.Add(this.m_cmdClose);
            this.Controls.Add(this.lblTakeOutStitchesDateTitle);
            this.Controls.Add(this.cmdConfirm);
            this.Controls.Add(this.lblOperationNameTitle);
            this.Controls.Add(this.lblAnaesthesiaModeTitle);
            this.Controls.Add(this.lsvSign);
            this.Controls.Add(this.lblInOperationSeeingTitle);
            this.Controls.Add(this.m_txtInOperationSeeing);
            this.Controls.Add(this.m_dtpTakeOutStitchesDate);
            this.Controls.Add(this.m_txtOperationDiagnose);
            this.Controls.Add(this.m_txtOperationName);
            this.Controls.Add(this.m_txtAfterOperationDeal);
            this.Controls.Add(this.m_txtAfterOperationNotice);
            this.Controls.Add(this.m_txtCutHealUpStatus);
            this.Controls.Add(this.m_txtAnaesthesiaMode);
            this.Name = "frmAfterOperation";
            this.Text = "手术后病程记录";
            this.Load += new System.EventHandler(this.frmAfterOperation_Load);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.m_lblGetDataTime, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.m_dtpGetDataTime, 0);
            this.Controls.SetChildIndex(this.m_txtAnaesthesiaMode, 0);
            this.Controls.SetChildIndex(this.m_trvCreateDate, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.m_txtCutHealUpStatus, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_txtAfterOperationNotice, 0);
            this.Controls.SetChildIndex(this.m_txtAfterOperationDeal, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.m_txtOperationName, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_txtOperationDiagnose, 0);
            this.Controls.SetChildIndex(this.m_dtpTakeOutStitchesDate, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_txtInOperationSeeing, 0);
            this.Controls.SetChildIndex(this.lblInOperationSeeingTitle, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.lsvSign, 0);
            this.Controls.SetChildIndex(this.lblAnaesthesiaModeTitle, 0);
            this.Controls.SetChildIndex(this.lblOperationNameTitle, 0);
            this.Controls.SetChildIndex(this.cmdConfirm, 0);
            this.Controls.SetChildIndex(this.lblTakeOutStitchesDateTitle, 0);
            this.Controls.SetChildIndex(this.m_cmdClose, 0);
            this.Controls.SetChildIndex(this.lblCutHealUpStatusTitle, 0);
            this.Controls.SetChildIndex(this.m_dtpCreateDate, 0);
            this.Controls.SetChildIndex(this.m_cmdEmployeeSign, 0);
            this.Controls.SetChildIndex(this.lblAfterOperationNoticeTitle, 0);
            this.Controls.SetChildIndex(this.lblCreateDateTitle, 0);
            this.Controls.SetChildIndex(this.lblAfterOperationDealTitle, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.lblOperationDiagnoseTitle, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
		/// <summary>
		/// 获取当前的特殊病程记录信息
		/// </summary>
		/// <returns></returns>
		public override clsDiseaseTrackInfo m_objGetDiseaseTrackInfo()
		{
			clsAfterOperationInfo objTrackInfo = new clsAfterOperationInfo();

			objTrackInfo.m_ObjRecordContent = m_objCurrentRecordContent;//m_objGetContentFromGUI();
			//设置m_strTitle和m_dtmRecordTime
			objTrackInfo.m_DtmRecordTime = m_dtpCreateDate.Value;
			objTrackInfo.m_StrTitle = "手术后病程记录";			
			
			return objTrackInfo;		
		}

		/// <summary>
		/// 清空特殊记录信息，并重置记录控制状态为不控制。
		/// </summary>
		protected override void m_mthClearRecordInfo()
		{
			//默认签名
			MDIParent.m_mthSetDefaulEmployee(lsvSign);

			//清空具体记录内容			
			m_txtAnaesthesiaMode.m_mthClearText();
			m_txtOperationName.m_mthClearText();
			m_txtOperationDiagnose.m_mthClearText();
			m_txtInOperationSeeing.m_mthClearText();
			m_txtAfterOperationDeal.m_mthClearText();
			m_txtAfterOperationNotice.m_mthClearText();
			m_txtCutHealUpStatus.m_mthClearText();
			m_dtpTakeOutStitchesDate.Value=DateTime.Now;
		}

		/// <summary>
		/// 控制是否可以选择病人和记录时间列表。在从病程记录窗体调用时需要使用。
		/// </summary>
		/// <param name="p_blnEnable"></param>
		protected override void m_mthEnablePatientSelectSub(bool p_blnEnable)
		{
			if(p_blnEnable==false)
			{
                //foreach(Control control in this.Controls)
                //{					
                //    control.Top=control.Top-105;				
                //}
			
				cmdConfirm.Visible=true;
				
                //this.Size=new Size(this.Size.Width, this.Size.Height-105);
				this.CenterToParent();						
			}
            //this.MaximizeBox=false;
		}

		/// <summary>
		/// 具体记录的特殊控制,根据子窗体的需要重载实现
		/// </summary>
		/// <param name="p_blnEnable">是否允许修改特殊记录的记录信息。</param>
		protected override void m_mthEnableModifySub(bool p_blnEnable)
		{
			
		}

		/// <summary>
		/// 设置是否控制修改（修改留痕迹）。
		/// </summary>
		/// <param name="p_objRecordContent"></param>
		/// <param name="p_blnReset">是否重置控制修改（修改留痕迹）。
		///如果为true，忽略记录内容，把界面控制设置为不控制；
		///否则根据记录内容进行设置。
		///</param>
		protected override void m_mthSetModifyControlSub(clsTrackRecordContent p_objRecordContent,
			bool p_blnReset)
		{
			//根据书写规范设置具体窗体的书写控制
			
		}

		/// <summary>
		/// 从界面获取特殊记录的值。如果界面值出错，返回null。
		/// </summary>
		/// <returns></returns>
		protected override clsTrackRecordContent m_objGetContentFromGUI()
		{
			//界面参数校验
			int intSignCount=lsvSign.Items.Count;
            if (m_objCurrentPatient == null || m_ObjCurrentEmrPatientSession == null || intSignCount == 0)				
				return null;
			//从界面获取表单值
			clsAfterOperationRecordContent objContent=new clsAfterOperationRecordContent();
			//获取lsvsign签名
			objContent.objSignerArr=new clsEmrSigns_VO[intSignCount];
			strUserIDList="";
			strUserNameList="";
            m_mthGetSignArr(new Control[] {lsvSign }, ref objContent.objSignerArr, ref strUserIDList, ref strUserNameList);
            //for (int i = 0; i < intSignCount; i++)
            //{
            //    objContent.objSignerArr[i]=new clsEmrSigns_VO();
            //    objContent.objSignerArr[i].objEmployee=new clsEmrEmployeeBase_VO();
            //    objContent.objSignerArr[i].objEmployee=(clsEmrEmployeeBase_VO)( lsvSign.Items[i].Tag);
            //    objContent.objSignerArr[i].controlName="lsvSign";
            //    objContent.objSignerArr[i].m_strFORMID_VCHR="frmdiseasesummary";//注意大小写
            //    objContent.objSignerArr[i].m_strREGISTERID_CHR=com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;
            //    //痕迹格式 0972,0324,

            //    strUserIDList=strUserIDList+objContent.objSignerArr[i].objEmployee.m_strEMPID_CHR.Trim()+",";
            //    strUserNameList=strUserNameList+objContent.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR.Trim()+",";
            //}
			objContent.m_strModifyUserID=strUserIDList;
			
			//设置Richtextbox的modifyuserID 和modifyuserName
			m_mthSetRichTextBoxAttribInControlWithIDandName(this);
			#region 是否可以无痕迹修改
			if (chkModifyWithoutMatk.Checked)
				objContent.m_intMarkStatus=0;
			else
				objContent.m_intMarkStatus=1;
			#endregion
			
			objContent.m_dtmCreateDate=m_dtpCreateDate.Value;					
				
			objContent.m_strAnaesthesiaMode_Right=m_txtAnaesthesiaMode.m_strGetRightText();	
			objContent.m_strAnaesthesiaMode=m_txtAnaesthesiaMode.Text;
			objContent.m_strAnaesthesiaModeXML=m_txtAnaesthesiaMode.m_strGetXmlText();					
			
			objContent.m_strOperationName_Right=m_txtOperationName.m_strGetRightText();	
			objContent.m_strOperationName=m_txtOperationName.Text;
			objContent.m_strOperationNameXML=m_txtOperationName.m_strGetXmlText();					
			
			objContent.m_strOperationDiagnose_Right=m_txtOperationDiagnose.m_strGetRightText();	
			objContent.m_strOperationDiagnose=m_txtOperationDiagnose.Text;
			objContent.m_strOperationDiagnoseXML=m_txtOperationDiagnose.m_strGetXmlText();					
			
			objContent.m_strInOperationSeeing_Right=m_txtInOperationSeeing.m_strGetRightText();	
			objContent.m_strInOperationSeeing=m_txtInOperationSeeing.Text;
			objContent.m_strInOperationSeeingXML=m_txtInOperationSeeing.m_strGetXmlText();	

			objContent.m_strAfterOperationDeal_Right=m_txtAfterOperationDeal.m_strGetRightText();	
			objContent.m_strAfterOperationDeal=m_txtAfterOperationDeal.Text;
			objContent.m_strAfterOperationDealXML=m_txtAfterOperationDeal.m_strGetXmlText();			

			objContent.m_strAfterOperationNotice_Right=m_txtAfterOperationNotice.m_strGetRightText();	
			objContent.m_strAfterOperationNotice=m_txtAfterOperationNotice.Text;
			objContent.m_strAfterOperationNoticeXML=m_txtAfterOperationNotice.m_strGetXmlText();			

			objContent.m_strCutHealUpStatus_Right=m_txtCutHealUpStatus.m_strGetRightText();	
			objContent.m_strCutHealUpStatus=m_txtCutHealUpStatus.Text;
			objContent.m_strCutHealUpStatusXML=m_txtCutHealUpStatus.m_strGetXmlText();			

			objContent.m_dtmTakeOutStitchesDate=m_dtpTakeOutStitchesDate.Value;
		


			return objContent;	
		}

		/// <summary>
		/// 把特殊记录的值显示到界面上。
		/// </summary>
		/// <param name="p_objContent"></param>
		protected override void m_mthSetGUIFromContent(clsTrackRecordContent p_objContent)
		{
			if(p_objContent ==null)
				return;
			clsAfterOperationRecordContent objContent=(clsAfterOperationRecordContent)p_objContent;
			//把表单值赋值到界面，由子窗体重载实现
			m_txtAnaesthesiaMode.m_mthSetNewText(objContent.m_strAnaesthesiaMode,objContent.m_strAnaesthesiaModeXML);		
			m_txtOperationName.m_mthSetNewText(objContent.m_strOperationName,objContent.m_strOperationNameXML);		
			m_txtOperationDiagnose.m_mthSetNewText(objContent.m_strOperationDiagnose,objContent.m_strOperationDiagnoseXML);
			m_txtInOperationSeeing.m_mthSetNewText(objContent.m_strInOperationSeeing,objContent.m_strInOperationSeeingXML);		
			m_txtAfterOperationDeal.m_mthSetNewText(objContent.m_strAfterOperationDeal,objContent.m_strAfterOperationDealXML);		
			m_txtAfterOperationNotice.m_mthSetNewText(objContent.m_strAfterOperationNotice,objContent.m_strAfterOperationNoticeXML);		
			m_txtCutHealUpStatus.m_mthSetNewText(objContent.m_strCutHealUpStatus,objContent.m_strCutHealUpStatusXML);								
			m_dtpTakeOutStitchesDate.Value=objContent.m_dtmTakeOutStitchesDate;

			#region 签名集合
			lsvSign.Clear();
			if (objContent.objSignerArr!=null)
			{
                m_mthAddSignToListView(lsvSign,objContent.objSignerArr);
                //lsvSign.Items.Clear();
                //for (int i = 0; i < objContent.objSignerArr.Length; i++)
                //{
                //    if (objContent.objSignerArr[i].controlName=="lsvSign")
                //    {
                //        ListViewItem lviNewItem = new ListViewItem(objContent.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR + "(" + objContent.objSignerArr[i].objEmployee.m_strTECHNICALRANK_CHR + ");");
                //        //ID 检查重复用
                //        lviNewItem.SubItems.Add(objContent.objSignerArr[i].objEmployee.m_strEMPID_CHR);
                //        //级别 排序用
                //        lviNewItem.SubItems.Add(objContent.objSignerArr[i].objEmployee.m_strLEVEL_CHR);
                //        //tag均为对象
                //        lviNewItem.Tag=objContent.objSignerArr[i].objEmployee;
                //        //是按顺序保存故获取顺序也一样
                //        lsvSign.Items.Add(lviNewItem);
                //    }
                //}
			}
			#endregion 签名		

		}
		public override int m_IntFormID
		{
			get
			{
				return 10;
			}
		}

		protected override void m_mthSetDeletedGUIFromContent(clsTrackRecordContent p_objContent)
		{
			if(p_objContent ==null)
				return;
			clsAfterOperationRecordContent objContent=(clsAfterOperationRecordContent)p_objContent;
			//把表单值赋值到界面，由子窗体重载实现
			m_txtAnaesthesiaMode.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strAnaesthesiaMode,objContent.m_strAnaesthesiaModeXML);		
			m_txtOperationName.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOperationName,objContent.m_strOperationNameXML);		
			m_txtOperationDiagnose.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOperationDiagnose,objContent.m_strOperationDiagnoseXML);
			m_txtInOperationSeeing.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strInOperationSeeing,objContent.m_strInOperationSeeingXML);		
			m_txtAfterOperationDeal.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strAfterOperationDeal,objContent.m_strAfterOperationDealXML);		
			m_txtAfterOperationNotice.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strAfterOperationNotice,objContent.m_strAfterOperationNoticeXML);		
			m_txtCutHealUpStatus.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strCutHealUpStatus,objContent.m_strCutHealUpStatusXML);								
			m_dtpTakeOutStitchesDate.Value=objContent.m_dtmTakeOutStitchesDate;

		}

		/// <summary>
		/// 获取病程记录的领域层实例
		/// </summary>
		/// <returns></returns>
		protected override clsDiseaseTrackDomain m_objGetDiseaseTrackDomain()
		{
			//获取病程记录的领域层实例
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.AfterOperation);					
		}

		/// <summary>
		/// 把选择时间记录内容重新整理为完全正确的内容。
		/// </summary>
		/// <param name="p_objRecordContent"></param>
		protected override void m_mthReAddNewRecord(clsTrackRecordContent p_objRecordContent)
		{
			//把选择时间记录内容重新整理为完全正确的内容，由子窗体重载实现。
			clsAfterOperationRecordContent objContent=(clsAfterOperationRecordContent)p_objRecordContent;
			//把表单值赋值到界面，由子窗体重载实现
			m_txtAnaesthesiaMode.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strAnaesthesiaMode,objContent.m_strAnaesthesiaModeXML);		
			m_txtOperationName.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOperationName,objContent.m_strOperationNameXML);		
			m_txtOperationDiagnose.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOperationDiagnose,objContent.m_strOperationDiagnoseXML);		
			m_txtInOperationSeeing.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strInOperationSeeing,objContent.m_strInOperationSeeingXML);
			m_txtAfterOperationDeal.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strAfterOperationDeal,objContent.m_strAfterOperationDealXML);		
			m_txtAfterOperationNotice.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strAfterOperationNotice,objContent.m_strAfterOperationNoticeXML);		
			m_txtCutHealUpStatus.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strCutHealUpStatus,objContent.m_strCutHealUpStatusXML);		
			m_dtpTakeOutStitchesDate.Value=objContent.m_dtmTakeOutStitchesDate;

		}

		#region 打印(在子弹出窗体中不需要提供实现)
		/// <summary>
		///  设置打印内容。
		/// </summary>
		/// <param name="p_objContent"></param>
		protected override void m_mthSetPrintContent(clsTrackRecordContent p_objContent,DateTime p_dtmFirstPrintDate)
		{
			//缺省不做任何动作，子窗体重载以提供操作。
		}

		/// <summary>
		/// 初始化打印变量
		/// </summary>
		protected override void m_mthInitPrintTool()
		{
			//缺省不做任何动作，子窗体重载以提供操作
			//初始化内容包括所有打印使用到的变量：字体、画笔、画刷、打印类等。
		}

		/// <summary>
		/// 释放打印变量
		/// </summary>
		protected override void m_mthDisposePrintTools()
		{
			//缺省不做任何动作，子窗体重载以提供操作
			//释放内容包括打印使用到的字体、画笔、画刷等使用系统资源的变量。
		}

		/// <summary>
		/// 开始打印。
		/// </summary>
		protected override void m_mthStartPrint()
		{
#if FunctionPrivilege
			if(!clsPublicFunction.s_blnCheckCurrentPrivilege(PrivilegeData.enmPrivilegeSF.frmAfterOperation,PrivilegeData.enmPrivilegeOperation.Print))
			{
				clsPublicFunction.s_mthShowNotPermitMessage();
				return;
			}			
#endif
			//缺省使用打印预览，子窗体重载提供新的实现
			if(m_blnDirectPrint)
			{
				m_pdcPrintDocument.Print();
			}
			else
			{
				PrintTool.frmPrintPreviewDialog ppdPrintPreview = new PrintTool.frmPrintPreviewDialog();
				ppdPrintPreview.Document = m_pdcPrintDocument;
				ppdPrintPreview.ShowDialog();
			}
		}

		/// <summary>
		/// 打印开始后，在打印页之前的操作
		/// </summary>
		/// <param name="p_objPrintArg"></param>
		protected override void m_mthBeginPrintSub(PrintEventArgs p_objPrintArg)
		{
			//缺省不做任何动作，子窗体重载以提供操作
		}

		/// <summary>
		/// 打印页
		/// </summary>
		/// <param name="p_objPrintPageArg"></param>
		protected override void m_mthPrintPageSub(PrintPageEventArgs p_objPrintPageArg)
		{
		
		}

		/// <summary>
		/// 打印结束时的操作
		/// </summary>
		/// <param name="p_objPrintArg"></param>
		protected override void m_mthEndPrintSub(PrintEventArgs p_objPrintArg)
		{
			//由子窗体重载以提供操作
		}
		#endregion 打印

		// 获取选择已经删除记录的窗体标题
		public override string m_strReloadFormTitle()
		{
			//由子窗体重载实现
			return	"手术后病程记录";
		}	
	
		/// <summary>
		/// 当选择根节点时,设置特殊的默认值(若子窗体需要,则重载实现)
		/// </summary>
		protected override void m_mthSelectRootNode()
		{
			
		}

		private void cmdConfirm_Click(object sender, System.EventArgs e)
		{
			if(m_lngSave() > 0)
			{
				this.DialogResult = DialogResult.Yes;
				this.Close();
			}
		}

		private void frmAfterOperation_Load(object sender, System.EventArgs e)
		{
//			m_cmdNewTemplate.Left=cmdConfirm.Left-m_cmdNewTemplate.Width+(cmdConfirm.Right-m_cmdClose.Left);
//			m_cmdNewTemplate.Top=cmdConfirm.Top;
//			m_cmdNewTemplate.Visible=true;

			
			this.m_dtpCreateDate.m_EnmVisibleFlag=MDIParent.s_ObjRecordDateTimeInfo.m_enmGetDefaultTimeFlag();
			m_dtpTakeOutStitchesDate.m_EnmVisibleFlag = MDIParent.s_ObjRecordDateTimeInfo.m_enmGetDefaultTimeFlag();
			m_dtpTakeOutStitchesDate.m_mthResetSize();
			this.m_dtpCreateDate.m_mthResetSize();

			m_txtAnaesthesiaMode.Focus();
		}

		private void m_cmdClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void m_txtAfterOperationDeal_TextChanged(object sender, System.EventArgs e)
		{
		
		}
		
		/// <summary>
		/// 数据复用
		/// </summary>
		/// <param name="p_objSelectedPatient"></param>
		protected override void m_mthDataShare(clsPatient p_objSelectedPatient)
		{
			if(p_objSelectedPatient != null)
			{
				clsOperationRecordDoctorShareDomain.stuLatestOperationValue stuValue;
				long lngRes = m_objShareDomain.m_lngGetLatestOperationInfo(p_objSelectedPatient.m_StrInPatientID,p_objSelectedPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"),DateTime.Now,out stuValue);

				if(lngRes > 0 && stuValue.m_strOperationName != null)
				{
					//手术日期
					m_dtpTakeOutStitchesDate.Value = DateTime.Parse(stuValue.m_strOperationBeginDate);
//					m_txtAnaesthesiaMode.Text = stuValue.m_strAnaesthesiaCategoryDosage;
//					m_txtOperationName.Text = stuValue.m_strOperationName;
//					m_txtOperationDiagnose.Text = stuValue.m_strDiagnoseAfterOperation;
//					m_txtInOperationSeeing.Text = stuValue.m_strOperationProcess;
				}
			}
		}

	}
}

