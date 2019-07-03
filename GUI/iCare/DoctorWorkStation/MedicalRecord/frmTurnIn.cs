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


namespace iCare
{
	/// <summary>
    /// （转入记录）病程记录子窗体的实现,Jacky-2003-5-19
	/// </summary>
	public class frmTurnIn : iCare.frmDiseaseTrackBase
	{
		private PinkieControls.ButtonXP cmdConfirm;
		private System.Windows.Forms.Label m_lblInHospitalDate;
		private System.Windows.Forms.Label lblInHospitalDateTitle;
		private System.Windows.Forms.Label lblSignTitle;
		private System.Windows.Forms.Label m_lblSign;
		private System.Windows.Forms.Label lblInHospitalReasonTitle;
		private System.Windows.Forms.Label m_lblInHospitalReason;
		private System.Windows.Forms.Label lblCaseBeforeTurnInTitle;
		private com.digitalwave.controls.ctlRichTextBox m_txtCaseBeforeTurnIn;
		private System.Windows.Forms.Label lblTurnInDiagnoseTitle;
		private com.digitalwave.controls.ctlRichTextBox m_txtTurnInDiagnose;
		private System.Windows.Forms.Label lblCaseAfterTurnInTitle;
		private com.digitalwave.controls.ctlRichTextBox m_txtCaseAfterTurnIn;
		private System.Windows.Forms.Label lblTurnInReasonTitle;
		private com.digitalwave.controls.ctlRichTextBox m_txtTurnInReason;
		private System.Windows.Forms.Label lblReferralTitle;
		private com.digitalwave.controls.ctlRichTextBox m_txtReferral;
		private PinkieControls.ButtonXP m_cmdClose;
		private System.ComponentModel.IContainer components = null;
		private PinkieControls.ButtonXP m_cmdEmployeeSign;
		private clsCommonUseToolCollection m_objCUTC;

		private clsEmployeeSignTool m_objSignTool;
		protected System.Windows.Forms.ListView lsvSign;
		private System.Windows.Forms.ColumnHeader clmEmployeeName;
		//定义签名类
		private clsEmrSignToolCollection m_objSign;

		public frmTurnIn()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
            //指明医生工作站表单
            intFormType = 1;
			// TODO: Add any initialization after the InitializeComponent call

//			m_objSignTool = new clsEmployeeSignTool(m_lsvEmployee_New);
//			m_objSignTool.m_mthAddControl(m_txtSign);

			cmdConfirm.Visible=false;
			
			m_mthSetRichTextBoxAttribInControl(this);

			this.Text="转入记录";			
			this.m_lblForTitle.Text=this.Text;			
			
//			m_lblSign.Text=MDIParent.OperatorName;	
//		
//			//签名常用值
//			m_objCUTC = new clsCommonUseToolCollection(this);
//			m_objCUTC.m_mthBindEmployeeSign(new Control[]{m_cmdEmployeeSign  },
//				new Control[]{this.m_txtSign },new int[]{1});

			//签名常用值
			m_objSign = new clsEmrSignToolCollection();
			//m_mthBindEmployeeSign(按钮,签名框,医生1or护士2,身份验证trueorfalse);
            m_objSign.m_mthBindEmployeeSign(m_cmdEmployeeSign, lsvSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);


		}

		public override int m_IntFormID
		{
			get
			{
				return 8;
			}
		}

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
            this.m_lblInHospitalDate = new System.Windows.Forms.Label();
            this.lblInHospitalDateTitle = new System.Windows.Forms.Label();
            this.lblSignTitle = new System.Windows.Forms.Label();
            this.m_lblSign = new System.Windows.Forms.Label();
            this.lblTurnInDiagnoseTitle = new System.Windows.Forms.Label();
            this.m_txtTurnInDiagnose = new com.digitalwave.controls.ctlRichTextBox();
            this.lblCaseAfterTurnInTitle = new System.Windows.Forms.Label();
            this.m_txtCaseAfterTurnIn = new com.digitalwave.controls.ctlRichTextBox();
            this.lblTurnInReasonTitle = new System.Windows.Forms.Label();
            this.m_txtTurnInReason = new com.digitalwave.controls.ctlRichTextBox();
            this.lblCaseBeforeTurnInTitle = new System.Windows.Forms.Label();
            this.m_txtCaseBeforeTurnIn = new com.digitalwave.controls.ctlRichTextBox();
            this.lblInHospitalReasonTitle = new System.Windows.Forms.Label();
            this.m_lblInHospitalReason = new System.Windows.Forms.Label();
            this.lblReferralTitle = new System.Windows.Forms.Label();
            this.m_txtReferral = new com.digitalwave.controls.ctlRichTextBox();
            this.m_cmdClose = new PinkieControls.ButtonXP();
            this.m_cmdEmployeeSign = new PinkieControls.ButtonXP();
            this.lsvSign = new System.Windows.Forms.ListView();
            this.clmEmployeeName = new System.Windows.Forms.ColumnHeader();
            this.m_pnlNewBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_trvCreateDate
            // 
            this.m_trvCreateDate.ForeColor = System.Drawing.Color.Black;
            this.m_trvCreateDate.LineColor = System.Drawing.Color.Black;
            this.m_trvCreateDate.Location = new System.Drawing.Point(17, -90);
            this.m_trvCreateDate.Size = new System.Drawing.Size(192, 60);
            this.m_trvCreateDate.Visible = false;
            // 
            // lblCreateDateTitle
            // 
            this.lblCreateDateTitle.Location = new System.Drawing.Point(19, 30);
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.Location = new System.Drawing.Point(96, 30);
            // 
            // m_dtpGetDataTime
            // 
            this.m_dtpGetDataTime.Location = new System.Drawing.Point(347, -39);
            // 
            // m_lblGetDataTime
            // 
            this.m_lblGetDataTime.Location = new System.Drawing.Point(243, -39);
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(673, -82);
            this.lblSex.Size = new System.Drawing.Size(36, 19);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(753, -82);
            this.lblAge.Size = new System.Drawing.Size(36, 19);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(389, -82);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(377, -54);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(501, -82);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(629, -82);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(709, -82);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(213, -50);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(104, -118);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(64, 104);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(429, -54);
            this.txtInPatientID.Size = new System.Drawing.Size(69, 23);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(541, -86);
            this.m_txtPatientName.Size = new System.Drawing.Size(88, 23);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(429, -86);
            this.m_txtBedNO.Size = new System.Drawing.Size(69, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(257, -54);
            this.m_cboArea.Size = new System.Drawing.Size(120, 23);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(104, -118);
            this.m_lsvPatientName.Size = new System.Drawing.Size(80, 104);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(40, -118);
            this.m_lsvBedNO.Size = new System.Drawing.Size(69, 104);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(257, -86);
            this.m_cboDept.Size = new System.Drawing.Size(120, 23);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(213, -82);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(2, 599);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.Location = new System.Drawing.Point(565, -54);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(529, -54);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(593, -58);
            this.m_lblForTitle.Size = new System.Drawing.Size(12, 20);
            this.m_lblForTitle.Text = "转入记录";
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(413, -43);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(630, -44);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Location = new System.Drawing.Point(11, -87);
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
            this.cmdConfirm.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdConfirm.Hint = "";
            this.cmdConfirm.Location = new System.Drawing.Point(604, 598);
            this.cmdConfirm.Name = "cmdConfirm";
            this.cmdConfirm.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdConfirm.Size = new System.Drawing.Size(80, 30);
            this.cmdConfirm.TabIndex = 200;
            this.cmdConfirm.Text = "确定";
            this.cmdConfirm.Click += new System.EventHandler(this.cmdConfirm_Click);
            // 
            // m_lblInHospitalDate
            // 
            this.m_lblInHospitalDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblInHospitalDate.Location = new System.Drawing.Point(421, -14);
            this.m_lblInHospitalDate.Name = "m_lblInHospitalDate";
            this.m_lblInHospitalDate.Size = new System.Drawing.Size(212, 19);
            this.m_lblInHospitalDate.TabIndex = 6087;
            this.m_lblInHospitalDate.Visible = false;
            // 
            // lblInHospitalDateTitle
            // 
            this.lblInHospitalDateTitle.AutoSize = true;
            this.lblInHospitalDateTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInHospitalDateTitle.Location = new System.Drawing.Point(337, -36);
            this.lblInHospitalDateTitle.Name = "lblInHospitalDateTitle";
            this.lblInHospitalDateTitle.Size = new System.Drawing.Size(70, 14);
            this.lblInHospitalDateTitle.TabIndex = 6086;
            this.lblInHospitalDateTitle.Text = "入院时间:";
            this.lblInHospitalDateTitle.Visible = false;
            // 
            // lblSignTitle
            // 
            this.lblSignTitle.AutoSize = true;
            this.lblSignTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSignTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSignTitle.ForeColor = System.Drawing.Color.Black;
            this.lblSignTitle.Location = new System.Drawing.Point(550, -14);
            this.lblSignTitle.Name = "lblSignTitle";
            this.lblSignTitle.Size = new System.Drawing.Size(42, 14);
            this.lblSignTitle.TabIndex = 6097;
            this.lblSignTitle.Text = "签名:";
            this.lblSignTitle.Visible = false;
            // 
            // m_lblSign
            // 
            this.m_lblSign.BackColor = System.Drawing.Color.Transparent;
            this.m_lblSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblSign.ForeColor = System.Drawing.Color.Black;
            this.m_lblSign.Location = new System.Drawing.Point(141, 81);
            this.m_lblSign.Name = "m_lblSign";
            this.m_lblSign.Size = new System.Drawing.Size(132, 19);
            this.m_lblSign.TabIndex = 6096;
            this.m_lblSign.Visible = false;
            // 
            // lblTurnInDiagnoseTitle
            // 
            this.lblTurnInDiagnoseTitle.AutoSize = true;
            this.lblTurnInDiagnoseTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTurnInDiagnoseTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTurnInDiagnoseTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTurnInDiagnoseTitle.Location = new System.Drawing.Point(5, 422);
            this.lblTurnInDiagnoseTitle.Name = "lblTurnInDiagnoseTitle";
            this.lblTurnInDiagnoseTitle.Size = new System.Drawing.Size(84, 14);
            this.lblTurnInDiagnoseTitle.TabIndex = 6095;
            this.lblTurnInDiagnoseTitle.Text = "转入后诊断:";
            // 
            // m_txtTurnInDiagnose
            // 
            this.m_txtTurnInDiagnose.AccessibleDescription = "转入后诊断";
            this.m_txtTurnInDiagnose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtTurnInDiagnose.BackColor = System.Drawing.Color.White;
            this.m_txtTurnInDiagnose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtTurnInDiagnose.ForeColor = System.Drawing.Color.Black;
            this.m_txtTurnInDiagnose.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtTurnInDiagnose.Location = new System.Drawing.Point(96, 419);
            this.m_txtTurnInDiagnose.m_BlnIgnoreUserInfo = false;
            this.m_txtTurnInDiagnose.m_BlnPartControl = false;
            this.m_txtTurnInDiagnose.m_BlnReadOnly = false;
            this.m_txtTurnInDiagnose.m_BlnUnderLineDST = false;
            this.m_txtTurnInDiagnose.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtTurnInDiagnose.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtTurnInDiagnose.m_IntCanModifyTime = 6;
            this.m_txtTurnInDiagnose.m_IntPartControlLength = 0;
            this.m_txtTurnInDiagnose.m_IntPartControlStartIndex = 0;
            this.m_txtTurnInDiagnose.m_StrUserID = "";
            this.m_txtTurnInDiagnose.m_StrUserName = "";
            this.m_txtTurnInDiagnose.Name = "m_txtTurnInDiagnose";
            this.m_txtTurnInDiagnose.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtTurnInDiagnose.Size = new System.Drawing.Size(692, 89);
            this.m_txtTurnInDiagnose.TabIndex = 140;
            this.m_txtTurnInDiagnose.Text = "";
            // 
            // lblCaseAfterTurnInTitle
            // 
            this.lblCaseAfterTurnInTitle.AutoSize = true;
            this.lblCaseAfterTurnInTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblCaseAfterTurnInTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCaseAfterTurnInTitle.ForeColor = System.Drawing.Color.Black;
            this.lblCaseAfterTurnInTitle.Location = new System.Drawing.Point(5, 336);
            this.lblCaseAfterTurnInTitle.Name = "lblCaseAfterTurnInTitle";
            this.lblCaseAfterTurnInTitle.Size = new System.Drawing.Size(84, 14);
            this.lblCaseAfterTurnInTitle.TabIndex = 6093;
            this.lblCaseAfterTurnInTitle.Text = "转入后情况:";
            // 
            // m_txtCaseAfterTurnIn
            // 
            this.m_txtCaseAfterTurnIn.AccessibleDescription = "转入后情况";
            this.m_txtCaseAfterTurnIn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtCaseAfterTurnIn.BackColor = System.Drawing.Color.White;
            this.m_txtCaseAfterTurnIn.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCaseAfterTurnIn.ForeColor = System.Drawing.Color.Black;
            this.m_txtCaseAfterTurnIn.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCaseAfterTurnIn.Location = new System.Drawing.Point(96, 333);
            this.m_txtCaseAfterTurnIn.m_BlnIgnoreUserInfo = false;
            this.m_txtCaseAfterTurnIn.m_BlnPartControl = false;
            this.m_txtCaseAfterTurnIn.m_BlnReadOnly = false;
            this.m_txtCaseAfterTurnIn.m_BlnUnderLineDST = false;
            this.m_txtCaseAfterTurnIn.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtCaseAfterTurnIn.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtCaseAfterTurnIn.m_IntCanModifyTime = 6;
            this.m_txtCaseAfterTurnIn.m_IntPartControlLength = 0;
            this.m_txtCaseAfterTurnIn.m_IntPartControlStartIndex = 0;
            this.m_txtCaseAfterTurnIn.m_StrUserID = "";
            this.m_txtCaseAfterTurnIn.m_StrUserName = "";
            this.m_txtCaseAfterTurnIn.Name = "m_txtCaseAfterTurnIn";
            this.m_txtCaseAfterTurnIn.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtCaseAfterTurnIn.Size = new System.Drawing.Size(692, 80);
            this.m_txtCaseAfterTurnIn.TabIndex = 130;
            this.m_txtCaseAfterTurnIn.Text = "";
            // 
            // lblTurnInReasonTitle
            // 
            this.lblTurnInReasonTitle.AutoSize = true;
            this.lblTurnInReasonTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTurnInReasonTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTurnInReasonTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTurnInReasonTitle.Location = new System.Drawing.Point(19, 244);
            this.lblTurnInReasonTitle.Name = "lblTurnInReasonTitle";
            this.lblTurnInReasonTitle.Size = new System.Drawing.Size(70, 14);
            this.lblTurnInReasonTitle.TabIndex = 6091;
            this.lblTurnInReasonTitle.Text = "转入原因:";
            // 
            // m_txtTurnInReason
            // 
            this.m_txtTurnInReason.AccessibleDescription = "转入原因";
            this.m_txtTurnInReason.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtTurnInReason.BackColor = System.Drawing.Color.White;
            this.m_txtTurnInReason.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtTurnInReason.ForeColor = System.Drawing.Color.Black;
            this.m_txtTurnInReason.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtTurnInReason.Location = new System.Drawing.Point(96, 241);
            this.m_txtTurnInReason.m_BlnIgnoreUserInfo = false;
            this.m_txtTurnInReason.m_BlnPartControl = false;
            this.m_txtTurnInReason.m_BlnReadOnly = false;
            this.m_txtTurnInReason.m_BlnUnderLineDST = false;
            this.m_txtTurnInReason.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtTurnInReason.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtTurnInReason.m_IntCanModifyTime = 6;
            this.m_txtTurnInReason.m_IntPartControlLength = 0;
            this.m_txtTurnInReason.m_IntPartControlStartIndex = 0;
            this.m_txtTurnInReason.m_StrUserID = "";
            this.m_txtTurnInReason.m_StrUserName = "";
            this.m_txtTurnInReason.Name = "m_txtTurnInReason";
            this.m_txtTurnInReason.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtTurnInReason.Size = new System.Drawing.Size(692, 86);
            this.m_txtTurnInReason.TabIndex = 120;
            this.m_txtTurnInReason.Text = "";
            // 
            // lblCaseBeforeTurnInTitle
            // 
            this.lblCaseBeforeTurnInTitle.AutoSize = true;
            this.lblCaseBeforeTurnInTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblCaseBeforeTurnInTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCaseBeforeTurnInTitle.ForeColor = System.Drawing.Color.Black;
            this.lblCaseBeforeTurnInTitle.Location = new System.Drawing.Point(6, 106);
            this.lblCaseBeforeTurnInTitle.Name = "lblCaseBeforeTurnInTitle";
            this.lblCaseBeforeTurnInTitle.Size = new System.Drawing.Size(84, 14);
            this.lblCaseBeforeTurnInTitle.TabIndex = 6089;
            this.lblCaseBeforeTurnInTitle.Text = "转入前病情:";
            // 
            // m_txtCaseBeforeTurnIn
            // 
            this.m_txtCaseBeforeTurnIn.AccessibleDescription = "转入前病情";
            this.m_txtCaseBeforeTurnIn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtCaseBeforeTurnIn.BackColor = System.Drawing.Color.White;
            this.m_txtCaseBeforeTurnIn.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCaseBeforeTurnIn.ForeColor = System.Drawing.Color.Black;
            this.m_txtCaseBeforeTurnIn.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCaseBeforeTurnIn.Location = new System.Drawing.Point(96, 103);
            this.m_txtCaseBeforeTurnIn.m_BlnIgnoreUserInfo = false;
            this.m_txtCaseBeforeTurnIn.m_BlnPartControl = false;
            this.m_txtCaseBeforeTurnIn.m_BlnReadOnly = false;
            this.m_txtCaseBeforeTurnIn.m_BlnUnderLineDST = false;
            this.m_txtCaseBeforeTurnIn.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtCaseBeforeTurnIn.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtCaseBeforeTurnIn.m_IntCanModifyTime = 6;
            this.m_txtCaseBeforeTurnIn.m_IntPartControlLength = 0;
            this.m_txtCaseBeforeTurnIn.m_IntPartControlStartIndex = 0;
            this.m_txtCaseBeforeTurnIn.m_StrUserID = "";
            this.m_txtCaseBeforeTurnIn.m_StrUserName = "";
            this.m_txtCaseBeforeTurnIn.Name = "m_txtCaseBeforeTurnIn";
            this.m_txtCaseBeforeTurnIn.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtCaseBeforeTurnIn.Size = new System.Drawing.Size(692, 132);
            this.m_txtCaseBeforeTurnIn.TabIndex = 110;
            this.m_txtCaseBeforeTurnIn.Text = "";
            // 
            // lblInHospitalReasonTitle
            // 
            this.lblInHospitalReasonTitle.AutoSize = true;
            this.lblInHospitalReasonTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInHospitalReasonTitle.Location = new System.Drawing.Point(19, 64);
            this.lblInHospitalReasonTitle.Name = "lblInHospitalReasonTitle";
            this.lblInHospitalReasonTitle.Size = new System.Drawing.Size(70, 14);
            this.lblInHospitalReasonTitle.TabIndex = 6098;
            this.lblInHospitalReasonTitle.Text = "入院原因:";
            // 
            // m_lblInHospitalReason
            // 
            this.m_lblInHospitalReason.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblInHospitalReason.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblInHospitalReason.Location = new System.Drawing.Point(96, 64);
            this.m_lblInHospitalReason.Name = "m_lblInHospitalReason";
            this.m_lblInHospitalReason.Size = new System.Drawing.Size(688, 36);
            this.m_lblInHospitalReason.TabIndex = 6099;
            // 
            // lblReferralTitle
            // 
            this.lblReferralTitle.AutoSize = true;
            this.lblReferralTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblReferralTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblReferralTitle.ForeColor = System.Drawing.Color.Black;
            this.lblReferralTitle.Location = new System.Drawing.Point(16, 522);
            this.lblReferralTitle.Name = "lblReferralTitle";
            this.lblReferralTitle.Size = new System.Drawing.Size(70, 14);
            this.lblReferralTitle.TabIndex = 6095;
            this.lblReferralTitle.Text = "治疗计划:";
            // 
            // m_txtReferral
            // 
            this.m_txtReferral.AccessibleDescription = "治疗计划";
            this.m_txtReferral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtReferral.BackColor = System.Drawing.Color.White;
            this.m_txtReferral.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtReferral.ForeColor = System.Drawing.Color.Black;
            this.m_txtReferral.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtReferral.Location = new System.Drawing.Point(96, 514);
            this.m_txtReferral.m_BlnIgnoreUserInfo = false;
            this.m_txtReferral.m_BlnPartControl = false;
            this.m_txtReferral.m_BlnReadOnly = false;
            this.m_txtReferral.m_BlnUnderLineDST = false;
            this.m_txtReferral.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtReferral.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtReferral.m_IntCanModifyTime = 6;
            this.m_txtReferral.m_IntPartControlLength = 0;
            this.m_txtReferral.m_IntPartControlStartIndex = 0;
            this.m_txtReferral.m_StrUserID = "";
            this.m_txtReferral.m_StrUserName = "";
            this.m_txtReferral.Name = "m_txtReferral";
            this.m_txtReferral.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtReferral.Size = new System.Drawing.Size(692, 73);
            this.m_txtReferral.TabIndex = 150;
            this.m_txtReferral.Text = "";
            // 
            // m_cmdClose
            // 
            this.m_cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdClose.DefaultScheme = true;
            this.m_cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdClose.Hint = "";
            this.m_cmdClose.Location = new System.Drawing.Point(704, 598);
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
            this.m_cmdEmployeeSign.Hint = "";
            this.m_cmdEmployeeSign.Location = new System.Drawing.Point(92, 598);
            this.m_cmdEmployeeSign.Name = "m_cmdEmployeeSign";
            this.m_cmdEmployeeSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdEmployeeSign.Size = new System.Drawing.Size(80, 30);
            this.m_cmdEmployeeSign.TabIndex = 10000037;
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
            this.lsvSign.Location = new System.Drawing.Point(176, 600);
            this.lsvSign.Name = "lsvSign";
            this.lsvSign.Size = new System.Drawing.Size(416, 28);
            this.lsvSign.TabIndex = 10000038;
            this.lsvSign.UseCompatibleStateImageBehavior = false;
            this.lsvSign.View = System.Windows.Forms.View.SmallIcon;
            // 
            // clmEmployeeName
            // 
            this.clmEmployeeName.Width = 55;
            // 
            // frmTurnIn
            // 
            this.AccessibleDescription = "转入记录";
            this.AutoScroll = false;
            this.ClientSize = new System.Drawing.Size(794, 643);
            this.Controls.Add(this.lsvSign);
            this.Controls.Add(this.lblTurnInDiagnoseTitle);
            this.Controls.Add(this.lblInHospitalReasonTitle);
            this.Controls.Add(this.lblReferralTitle);
            this.Controls.Add(this.m_cmdEmployeeSign);
            this.Controls.Add(this.lblCaseAfterTurnInTitle);
            this.Controls.Add(this.m_cmdClose);
            this.Controls.Add(this.m_txtTurnInDiagnose);
            this.Controls.Add(this.m_lblInHospitalReason);
            this.Controls.Add(this.cmdConfirm);
            this.Controls.Add(this.lblSignTitle);
            this.Controls.Add(this.m_txtCaseAfterTurnIn);
            this.Controls.Add(this.m_txtReferral);
            this.Controls.Add(this.m_lblSign);
            this.Controls.Add(this.lblTurnInReasonTitle);
            this.Controls.Add(this.lblCaseBeforeTurnInTitle);
            this.Controls.Add(this.m_lblInHospitalDate);
            this.Controls.Add(this.lblInHospitalDateTitle);
            this.Controls.Add(this.m_txtTurnInReason);
            this.Controls.Add(this.m_txtCaseBeforeTurnIn);
            this.Name = "frmTurnIn";
            this.Text = "转入记录";
            this.Load += new System.EventHandler(this.frmTurnIn_Load);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.m_trvCreateDate, 0);
            this.Controls.SetChildIndex(this.m_txtCaseBeforeTurnIn, 0);
            this.Controls.SetChildIndex(this.m_txtTurnInReason, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.lblInHospitalDateTitle, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_dtpGetDataTime, 0);
            this.Controls.SetChildIndex(this.m_lblGetDataTime, 0);
            this.Controls.SetChildIndex(this.m_lblInHospitalDate, 0);
            this.Controls.SetChildIndex(this.lblCaseBeforeTurnInTitle, 0);
            this.Controls.SetChildIndex(this.lblTurnInReasonTitle, 0);
            this.Controls.SetChildIndex(this.m_lblSign, 0);
            this.Controls.SetChildIndex(this.m_txtReferral, 0);
            this.Controls.SetChildIndex(this.m_txtCaseAfterTurnIn, 0);
            this.Controls.SetChildIndex(this.lblSignTitle, 0);
            this.Controls.SetChildIndex(this.cmdConfirm, 0);
            this.Controls.SetChildIndex(this.m_lblInHospitalReason, 0);
            this.Controls.SetChildIndex(this.m_txtTurnInDiagnose, 0);
            this.Controls.SetChildIndex(this.m_cmdClose, 0);
            this.Controls.SetChildIndex(this.lblCaseAfterTurnInTitle, 0);
            this.Controls.SetChildIndex(this.m_cmdEmployeeSign, 0);
            this.Controls.SetChildIndex(this.lblReferralTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalReasonTitle, 0);
            this.Controls.SetChildIndex(this.lblTurnInDiagnoseTitle, 0);
            this.Controls.SetChildIndex(this.lblCreateDateTitle, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.lsvSign, 0);
            this.Controls.SetChildIndex(this.m_dtpCreateDate, 0);
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
            clsTurnInInfo objTrackInfo = new clsTurnInInfo(m_objCurrentPatient);

			objTrackInfo.m_ObjRecordContent = m_objCurrentRecordContent;//m_objGetContentFromGUI();
			//设置m_strTitle和m_dtmRecordTime
			objTrackInfo.m_DtmRecordTime = m_dtpCreateDate.Value;
			objTrackInfo.m_StrTitle = "转入记录";			
			
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
			m_txtCaseBeforeTurnIn.m_mthClearText();
			m_txtTurnInReason.m_mthClearText();
			m_txtCaseAfterTurnIn.m_mthClearText();
			m_txtTurnInDiagnose.m_mthClearText();
			m_txtReferral.m_mthClearText();						
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
			if(m_objCurrentPatient==null || m_ObjCurrentEmrPatientSession == null|| intSignCount==0)				
				return null;
			//从界面获取表单值
			clsTurnInRecordContent objContent=new clsTurnInRecordContent();

			//获取lsvsign签名
			objContent.objSignerArr=new clsEmrSigns_VO[intSignCount];
			strUserIDList="";
			strUserNameList="";
            m_mthGetSignArr(new Control[] { lsvSign }, ref objContent.objSignerArr, ref strUserIDList, ref strUserNameList);
            //for (int i = 0; i < intSignCount; i++)
            //{
            //    objContent.objSignerArr[i]=new clsEmrSigns_VO();
            //    objContent.objSignerArr[i].objEmployee=new clsEmrEmployeeBase_VO();
            //    objContent.objSignerArr[i].objEmployee=(clsEmrEmployeeBase_VO)( lsvSign.Items[i].Tag);
            //    objContent.objSignerArr[i].controlName="lsvSign";
            //    objContent.objSignerArr[i].m_strFORMID_VCHR="frmTurnIn";//注意大小写
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
				
			objContent.m_strCaseBeforeTurnIn_Right=m_txtCaseBeforeTurnIn.m_strGetRightText();	
			objContent.m_strCaseBeforeTurnIn=m_txtCaseBeforeTurnIn.Text;
			objContent.m_strCaseBeforeTurnInXML=m_txtCaseBeforeTurnIn.m_strGetXmlText();					
			
			objContent.m_strTurnInReason_Right=m_txtTurnInReason.m_strGetRightText();	
			objContent.m_strTurnInReason=m_txtTurnInReason.Text;
			objContent.m_strTurnInReasonXML=m_txtTurnInReason.m_strGetXmlText();					
			
			objContent.m_strCaseAfterTurnIn_Right=m_txtCaseAfterTurnIn.m_strGetRightText();	
			objContent.m_strCaseAfterTurnIn=m_txtCaseAfterTurnIn.Text;
			objContent.m_strCaseAfterTurnInXML=m_txtCaseAfterTurnIn.m_strGetXmlText();					
			
			objContent.m_strTurnInDiagnose_Right=m_txtTurnInDiagnose.m_strGetRightText();	
			objContent.m_strTurnInDiagnose=m_txtTurnInDiagnose.Text;
			objContent.m_strTurnInDiagnoseXML=m_txtTurnInDiagnose.m_strGetXmlText();	

			objContent.m_strReferral_Right=m_txtReferral.m_strGetRightText();	
			objContent.m_strReferral=m_txtReferral.Text;
			objContent.m_strReferralXML=m_txtReferral.m_strGetXmlText();			
		

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
			clsTurnInRecordContent objContent=(clsTurnInRecordContent)p_objContent;
			//把表单值赋值到界面，由子窗体重载实现
			m_txtCaseBeforeTurnIn.m_mthSetNewText(objContent.m_strCaseBeforeTurnIn,objContent.m_strCaseBeforeTurnInXML);		
			m_txtTurnInReason.m_mthSetNewText(objContent.m_strTurnInReason,objContent.m_strTurnInReasonXML);		
			m_txtCaseAfterTurnIn.m_mthSetNewText(objContent.m_strCaseAfterTurnIn,objContent.m_strCaseAfterTurnInXML);
			m_txtTurnInDiagnose.m_mthSetNewText(objContent.m_strTurnInDiagnose,objContent.m_strTurnInDiagnoseXML);		
			m_txtReferral.m_mthSetNewText(objContent.m_strReferral,objContent.m_strReferralXML);		
			
			#region 签名集合
			if (objContent.objSignerArr!=null)
            {
                m_mthAddSignToListView(lsvSign, objContent.objSignerArr);
                //lsvSign.Items.Clear();
                //for (int i = 0; i < objContent.objSignerArr.Length; i++)
                //{
                //    if (objContent.objSignerArr[i].controlName=="lsvSign")
                //    {
                //        ListViewItem lviNewItem=new 						 ListViewItem(objContent.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR);
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


			#region 入院原因(主诉)
			clsInPatientCaseHisoryDefaultValue[] objInPatientCaseHisoryDefaultValueArr= new clsInPatientCaseHisoryDefaultDomain().lngGetAllInPatientCaseHisoryDefault(m_objCurrentPatient.m_StrInPatientID,m_ObjLastEmrPatientSession.m_dtmEMRInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"));
			if(objInPatientCaseHisoryDefaultValueArr !=null && objInPatientCaseHisoryDefaultValueArr.Length>0)
			{
				m_lblInHospitalReason.Text=objInPatientCaseHisoryDefaultValueArr[0].m_strMainDescription;
			}
			#endregion 入院原因(主诉)
		}

		protected override void m_mthSetDeletedGUIFromContent(clsTrackRecordContent p_objContent)
		{
			if(p_objContent ==null)
				return;
			clsTurnInRecordContent objContent=(clsTurnInRecordContent)p_objContent;
			//把表单值赋值到界面，由子窗体重载实现
			m_txtCaseBeforeTurnIn.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strCaseBeforeTurnIn,objContent.m_strCaseBeforeTurnInXML);		
			m_txtTurnInReason.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strTurnInReason,objContent.m_strTurnInReasonXML);		
			m_txtCaseAfterTurnIn.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strCaseAfterTurnIn,objContent.m_strCaseAfterTurnInXML);
			m_txtTurnInDiagnose.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strTurnInDiagnose,objContent.m_strTurnInDiagnoseXML);		
			m_txtReferral.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strReferral,objContent.m_strReferralXML);		
						
			#region 入院原因(主诉)
            clsInPatientCaseHisoryDefaultValue[] objInPatientCaseHisoryDefaultValueArr = new clsInPatientCaseHisoryDefaultDomain().lngGetAllInPatientCaseHisoryDefault(m_objCurrentPatient.m_StrInPatientID, m_ObjLastEmrPatientSession.m_dtmEMRInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"));
			if(objInPatientCaseHisoryDefaultValueArr !=null && objInPatientCaseHisoryDefaultValueArr.Length>0)
			{
				m_lblInHospitalReason.Text=objInPatientCaseHisoryDefaultValueArr[0].m_strMainDescription;
			}
			#endregion 入院原因(主诉)
		}


		/// <summary>
		/// 获取病程记录的领域层实例
		/// </summary>
		/// <returns></returns>
		protected override clsDiseaseTrackDomain m_objGetDiseaseTrackDomain()
		{
			//获取病程记录的领域层实例
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.TurnIn);					
		}

		/// <summary>
		/// 把选择时间记录内容重新整理为完全正确的内容。
		/// </summary>
		/// <param name="p_objRecordContent"></param>
		protected override void m_mthReAddNewRecord(clsTrackRecordContent p_objRecordContent)
		{
			//把选择时间记录内容重新整理为完全正确的内容，由子窗体重载实现。
			clsTurnInRecordContent objContent=(clsTurnInRecordContent)p_objRecordContent;
			//把表单值赋值到界面，由子窗体重载实现
			m_txtCaseBeforeTurnIn.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strCaseBeforeTurnIn,objContent.m_strCaseBeforeTurnInXML);		
			m_txtTurnInReason.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strTurnInReason,objContent.m_strTurnInReasonXML);		
			m_txtCaseAfterTurnIn.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strCaseAfterTurnIn,objContent.m_strCaseAfterTurnInXML);		
			m_txtTurnInDiagnose.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strTurnInDiagnose,objContent.m_strTurnInDiagnoseXML);
			m_txtReferral.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strReferral,objContent.m_strReferralXML);		
			
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
			return	"转入记录";
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

		private void frmTurnIn_Load(object sender, System.EventArgs e)
		{
            if (m_objCurrentPatient != null && m_ObjLastEmrPatientSession != null)
			{
                m_lblInHospitalDate.Text = m_ObjLastEmrPatientSession.m_dtmHISInpatientDate.ToString("yyyy年MM月dd日 HH:mm");
				#region 入院原因(主诉)
                clsInPatientCaseHisoryDefaultValue[] objInPatientCaseHisoryDefaultValueArr = new clsInPatientCaseHisoryDefaultDomain().lngGetAllInPatientCaseHisoryDefault(m_objCurrentPatient.m_StrInPatientID, m_ObjLastEmrPatientSession.m_dtmEMRInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"));
				if(objInPatientCaseHisoryDefaultValueArr !=null && objInPatientCaseHisoryDefaultValueArr.Length>0)
				{
					m_lblInHospitalReason.Text=objInPatientCaseHisoryDefaultValueArr[0].m_strMainDescription;
				}
				#endregion 入院原因(主诉)
			}

//			m_cmdNewTemplate.Visible = true;

			this.m_dtpCreateDate.m_EnmVisibleFlag=MDIParent.s_ObjRecordDateTimeInfo.m_enmGetRecordTimeFlag(this.Name);
			this.m_dtpCreateDate.m_mthResetSize();

			m_txtCaseBeforeTurnIn.Focus();
		}

		private void m_cmdClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
  		
	
		/// <summary>
		/// 数据复用
		/// </summary>
		/// <param name="p_objSelectedPatient"></param>
		protected override void m_mthDataShare(clsPatient p_objSelectedPatient)
		{
			clsInPatientCaseHisoryDefaultValue [] objInPatientCaseDefaultValue = new clsInPatientCaseHisoryDefaultDomain().lngGetAllInPatientCaseHisoryDefault(p_objSelectedPatient.m_StrInPatientID,p_objSelectedPatient.m_DtmSelectedInDate.ToString());
			if(objInPatientCaseDefaultValue !=null && objInPatientCaseDefaultValue.Length >0)
			{

				this.m_lblInHospitalReason.Text=objInPatientCaseDefaultValue[0].m_strMainDescription;
				this.m_txtCaseBeforeTurnIn.Text=objInPatientCaseDefaultValue[0].m_strCurrentStatus;
//				this.m_txtCaseAfterTurnIn.Text = "患者因" + objInPatientCaseDefaultValue[0].m_strMainDescription + "于" + DateTime.Parse(objInPatientCaseDefaultValue[0].m_strInPatientDate).ToString("yyyy年M月d日")  + "入院。";

			}
		}
		
	}
}

