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
	/// （死亡病例讨论记录）病程记录子窗体的实现,Jacky-2003-5-19
	/// </summary>
	public class frmDeadCaseDiscuss : iCare.frmDiseaseTrackBase
	{
		private PinkieControls.ButtonXP cmdConfirm;
		private System.Windows.Forms.Label lblDiscussContentTitle;
		private com.digitalwave.controls.ctlRichTextBox m_txtDiscussContent;
		private System.Windows.Forms.Label lblAddressTitle;
		private com.digitalwave.controls.ctlRichTextBox m_txtAddress;
		private System.Windows.Forms.Label lblDeadDiagnoseTitle;
		private com.digitalwave.controls.ctlRichTextBox m_txtDeadDiagnose;
		private System.Windows.Forms.Label lblDeadReasonTitle;
		private com.digitalwave.controls.ctlRichTextBox m_txtDeadReason;
		private System.Windows.Forms.Label lblUseForReferenceTitle;
		private com.digitalwave.controls.ctlRichTextBox m_txtUseForReference;
		private PinkieControls.ButtonXP m_cmdClose;
		private System.ComponentModel.IContainer components = null;
		private PinkieControls.ButtonXP m_cmdCompere;
		private PinkieControls.ButtonXP m_cmdAttendee;
		private PinkieControls.ButtonXP m_cmdReadOuter;

		private PinkieControls.ButtonXP m_cmdAddress;
		protected System.Windows.Forms.ListView lsvAttend;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		protected System.Windows.Forms.ListView lsvCompere;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		protected System.Windows.Forms.ListView lsvSign;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private PinkieControls.ButtonXP m_cmdEmployeeSign;
		protected System.Windows.Forms.ListView lsvRead;
		//定义签名类
		private clsEmrSignToolCollection m_objSign;
		public frmDeadCaseDiscuss()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
            //指明医生工作站表单
            intFormType = 1;
			// TODO: Add any initialization after the InitializeComponent call

			cmdConfirm.Visible=false;
			
			m_mthSetRichTextBoxAttribInControl(this);

			this.Text="死亡病例讨论记录";			
			this.m_lblForTitle.Text=this.Text;			
			
			//签名常用值
			m_objSign = new clsEmrSignToolCollection();
			//m_mthBindEmployeeSign(按钮,签名框,医生1or护士2,身份验证trueorfalse);
			//记录者
            m_objSign.m_mthBindEmployeeSign(m_cmdEmployeeSign, lsvSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
			//主持
            m_objSign.m_mthBindEmployeeSign(m_cmdCompere, lsvCompere, 1, false, clsEMRLogin.LoginInfo.m_strEmpID);
			//参加人员
            m_objSign.m_mthBindEmployeeSign(m_cmdAttendee, lsvAttend, 0, false, clsEMRLogin.LoginInfo.m_strEmpID);
			//宣读人员
            m_objSign.m_mthBindEmployeeSign(m_cmdReadOuter, lsvRead, 1, false, clsEMRLogin.LoginInfo.m_strEmpID);


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
            this.lblDiscussContentTitle = new System.Windows.Forms.Label();
            this.m_txtDiscussContent = new com.digitalwave.controls.ctlRichTextBox();
            this.lblAddressTitle = new System.Windows.Forms.Label();
            this.m_txtAddress = new com.digitalwave.controls.ctlRichTextBox();
            this.lblDeadDiagnoseTitle = new System.Windows.Forms.Label();
            this.m_txtDeadDiagnose = new com.digitalwave.controls.ctlRichTextBox();
            this.lblDeadReasonTitle = new System.Windows.Forms.Label();
            this.m_txtDeadReason = new com.digitalwave.controls.ctlRichTextBox();
            this.lblUseForReferenceTitle = new System.Windows.Forms.Label();
            this.m_txtUseForReference = new com.digitalwave.controls.ctlRichTextBox();
            this.m_cmdClose = new PinkieControls.ButtonXP();
            this.m_cmdCompere = new PinkieControls.ButtonXP();
            this.m_cmdAttendee = new PinkieControls.ButtonXP();
            this.m_cmdReadOuter = new PinkieControls.ButtonXP();
            this.m_cmdEmployeeSign = new PinkieControls.ButtonXP();
            this.m_cmdAddress = new PinkieControls.ButtonXP();
            this.lsvAttend = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.lsvCompere = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.lsvSign = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.lsvRead = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.m_pnlNewBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_trvCreateDate
            // 
            this.m_trvCreateDate.ForeColor = System.Drawing.Color.Black;
            this.m_trvCreateDate.LineColor = System.Drawing.Color.Black;
            this.m_trvCreateDate.Location = new System.Drawing.Point(31, -47);
            this.m_trvCreateDate.Size = new System.Drawing.Size(212, 52);
            this.m_trvCreateDate.Visible = false;
            // 
            // lblCreateDateTitle
            // 
            this.lblCreateDateTitle.Location = new System.Drawing.Point(32, 35);
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.Location = new System.Drawing.Point(112, 31);
            // 
            // m_dtpGetDataTime
            // 
            this.m_dtpGetDataTime.Location = new System.Drawing.Point(352, 59);
            // 
            // m_lblGetDataTime
            // 
            this.m_lblGetDataTime.Location = new System.Drawing.Point(248, 59);
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(635, -63);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(327, -21);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(264, -21);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(383, -21);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(368, -21);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(587, -63);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(275, -21);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(399, -21);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(132, -99);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(447, -25);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(416, -25);
            this.m_txtPatientName.Size = new System.Drawing.Size(80, 23);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(312, -25);
            this.m_txtBedNO.Size = new System.Drawing.Size(52, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(447, -25);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(21, -99);
            this.m_lsvPatientName.Size = new System.Drawing.Size(80, 104);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(74, -99);
            this.m_lsvBedNO.Size = new System.Drawing.Size(52, 104);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(87, -35);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(39, -27);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(12, 552);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.Location = new System.Drawing.Point(203, -63);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(163, -63);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(279, -59);
            this.m_lblForTitle.Text = "死亡病例讨论记录";
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(16, 556);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(631, -32);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Location = new System.Drawing.Point(17, -68);
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
            this.cmdConfirm.ForeColor = System.Drawing.Color.Black;
            this.cmdConfirm.Hint = "";
            this.cmdConfirm.Location = new System.Drawing.Point(716, 588);
            this.cmdConfirm.Name = "cmdConfirm";
            this.cmdConfirm.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdConfirm.Size = new System.Drawing.Size(80, 30);
            this.cmdConfirm.TabIndex = 200;
            this.cmdConfirm.Text = "确定";
            this.cmdConfirm.Click += new System.EventHandler(this.cmdConfirm_Click);
            // 
            // lblDiscussContentTitle
            // 
            this.lblDiscussContentTitle.AutoSize = true;
            this.lblDiscussContentTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblDiscussContentTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDiscussContentTitle.ForeColor = System.Drawing.Color.Black;
            this.lblDiscussContentTitle.Location = new System.Drawing.Point(28, 189);
            this.lblDiscussContentTitle.Name = "lblDiscussContentTitle";
            this.lblDiscussContentTitle.Size = new System.Drawing.Size(70, 14);
            this.lblDiscussContentTitle.TabIndex = 6091;
            this.lblDiscussContentTitle.Text = "讨论内容:";
            // 
            // m_txtDiscussContent
            // 
            this.m_txtDiscussContent.AccessibleDescription = "讨论内容";
            this.m_txtDiscussContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtDiscussContent.BackColor = System.Drawing.Color.White;
            this.m_txtDiscussContent.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDiscussContent.ForeColor = System.Drawing.Color.Black;
            this.m_txtDiscussContent.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDiscussContent.Location = new System.Drawing.Point(112, 189);
            this.m_txtDiscussContent.m_BlnIgnoreUserInfo = false;
            this.m_txtDiscussContent.m_BlnPartControl = false;
            this.m_txtDiscussContent.m_BlnReadOnly = false;
            this.m_txtDiscussContent.m_BlnUnderLineDST = false;
            this.m_txtDiscussContent.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDiscussContent.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDiscussContent.m_IntCanModifyTime = 6;
            this.m_txtDiscussContent.m_IntPartControlLength = 0;
            this.m_txtDiscussContent.m_IntPartControlStartIndex = 0;
            this.m_txtDiscussContent.m_StrUserID = "";
            this.m_txtDiscussContent.m_StrUserName = "";
            this.m_txtDiscussContent.Name = "m_txtDiscussContent";
            this.m_txtDiscussContent.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtDiscussContent.Size = new System.Drawing.Size(772, 207);
            this.m_txtDiscussContent.TabIndex = 140;
            this.m_txtDiscussContent.Text = "";
            // 
            // lblAddressTitle
            // 
            this.lblAddressTitle.AutoSize = true;
            this.lblAddressTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblAddressTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAddressTitle.ForeColor = System.Drawing.Color.Black;
            this.lblAddressTitle.Location = new System.Drawing.Point(363, -55);
            this.lblAddressTitle.Name = "lblAddressTitle";
            this.lblAddressTitle.Size = new System.Drawing.Size(42, 14);
            this.lblAddressTitle.TabIndex = 6089;
            this.lblAddressTitle.Text = "地点:";
            this.lblAddressTitle.Visible = false;
            // 
            // m_txtAddress
            // 
            this.m_txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtAddress.BackColor = System.Drawing.Color.White;
            this.m_txtAddress.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtAddress.ForeColor = System.Drawing.Color.Black;
            this.m_txtAddress.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtAddress.Location = new System.Drawing.Point(112, 59);
            this.m_txtAddress.m_BlnIgnoreUserInfo = false;
            this.m_txtAddress.m_BlnPartControl = false;
            this.m_txtAddress.m_BlnReadOnly = false;
            this.m_txtAddress.m_BlnUnderLineDST = false;
            this.m_txtAddress.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtAddress.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtAddress.m_IntCanModifyTime = 6;
            this.m_txtAddress.m_IntPartControlLength = 0;
            this.m_txtAddress.m_IntPartControlStartIndex = 0;
            this.m_txtAddress.m_StrUserID = "";
            this.m_txtAddress.m_StrUserName = "";
            this.m_txtAddress.Multiline = false;
            this.m_txtAddress.Name = "m_txtAddress";
            this.m_txtAddress.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtAddress.Size = new System.Drawing.Size(772, 28);
            this.m_txtAddress.TabIndex = 100;
            this.m_txtAddress.Text = "";
            // 
            // lblDeadDiagnoseTitle
            // 
            this.lblDeadDiagnoseTitle.AutoSize = true;
            this.lblDeadDiagnoseTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblDeadDiagnoseTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDeadDiagnoseTitle.ForeColor = System.Drawing.Color.Black;
            this.lblDeadDiagnoseTitle.Location = new System.Drawing.Point(28, 405);
            this.lblDeadDiagnoseTitle.Name = "lblDeadDiagnoseTitle";
            this.lblDeadDiagnoseTitle.Size = new System.Drawing.Size(70, 14);
            this.lblDeadDiagnoseTitle.TabIndex = 6091;
            this.lblDeadDiagnoseTitle.Text = "死亡诊断:";
            // 
            // m_txtDeadDiagnose
            // 
            this.m_txtDeadDiagnose.AccessibleDescription = "死亡诊断";
            this.m_txtDeadDiagnose.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtDeadDiagnose.BackColor = System.Drawing.Color.White;
            this.m_txtDeadDiagnose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDeadDiagnose.ForeColor = System.Drawing.Color.Black;
            this.m_txtDeadDiagnose.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDeadDiagnose.Location = new System.Drawing.Point(112, 402);
            this.m_txtDeadDiagnose.m_BlnIgnoreUserInfo = false;
            this.m_txtDeadDiagnose.m_BlnPartControl = false;
            this.m_txtDeadDiagnose.m_BlnReadOnly = false;
            this.m_txtDeadDiagnose.m_BlnUnderLineDST = false;
            this.m_txtDeadDiagnose.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDeadDiagnose.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDeadDiagnose.m_IntCanModifyTime = 6;
            this.m_txtDeadDiagnose.m_IntPartControlLength = 0;
            this.m_txtDeadDiagnose.m_IntPartControlStartIndex = 0;
            this.m_txtDeadDiagnose.m_StrUserID = "";
            this.m_txtDeadDiagnose.m_StrUserName = "";
            this.m_txtDeadDiagnose.Name = "m_txtDeadDiagnose";
            this.m_txtDeadDiagnose.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtDeadDiagnose.Size = new System.Drawing.Size(772, 36);
            this.m_txtDeadDiagnose.TabIndex = 150;
            this.m_txtDeadDiagnose.Text = "";
            // 
            // lblDeadReasonTitle
            // 
            this.lblDeadReasonTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDeadReasonTitle.AutoSize = true;
            this.lblDeadReasonTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblDeadReasonTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDeadReasonTitle.ForeColor = System.Drawing.Color.Black;
            this.lblDeadReasonTitle.Location = new System.Drawing.Point(28, 447);
            this.lblDeadReasonTitle.Name = "lblDeadReasonTitle";
            this.lblDeadReasonTitle.Size = new System.Drawing.Size(70, 14);
            this.lblDeadReasonTitle.TabIndex = 6091;
            this.lblDeadReasonTitle.Text = "死亡原因:";
            // 
            // m_txtDeadReason
            // 
            this.m_txtDeadReason.AccessibleDescription = "死亡原因";
            this.m_txtDeadReason.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtDeadReason.BackColor = System.Drawing.Color.White;
            this.m_txtDeadReason.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDeadReason.ForeColor = System.Drawing.Color.Black;
            this.m_txtDeadReason.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDeadReason.Location = new System.Drawing.Point(112, 444);
            this.m_txtDeadReason.m_BlnIgnoreUserInfo = false;
            this.m_txtDeadReason.m_BlnPartControl = false;
            this.m_txtDeadReason.m_BlnReadOnly = false;
            this.m_txtDeadReason.m_BlnUnderLineDST = false;
            this.m_txtDeadReason.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDeadReason.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDeadReason.m_IntCanModifyTime = 6;
            this.m_txtDeadReason.m_IntPartControlLength = 0;
            this.m_txtDeadReason.m_IntPartControlStartIndex = 0;
            this.m_txtDeadReason.m_StrUserID = "";
            this.m_txtDeadReason.m_StrUserName = "";
            this.m_txtDeadReason.Name = "m_txtDeadReason";
            this.m_txtDeadReason.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtDeadReason.Size = new System.Drawing.Size(772, 60);
            this.m_txtDeadReason.TabIndex = 160;
            this.m_txtDeadReason.Text = "";
            // 
            // lblUseForReferenceTitle
            // 
            this.lblUseForReferenceTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblUseForReferenceTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblUseForReferenceTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUseForReferenceTitle.ForeColor = System.Drawing.Color.Black;
            this.lblUseForReferenceTitle.Location = new System.Drawing.Point(12, 510);
            this.lblUseForReferenceTitle.Name = "lblUseForReferenceTitle";
            this.lblUseForReferenceTitle.Size = new System.Drawing.Size(96, 36);
            this.lblUseForReferenceTitle.TabIndex = 6091;
            this.lblUseForReferenceTitle.Text = "参照本例应借鉴的问题:";
            // 
            // m_txtUseForReference
            // 
            this.m_txtUseForReference.AccessibleDescription = "借鉴";
            this.m_txtUseForReference.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtUseForReference.BackColor = System.Drawing.Color.White;
            this.m_txtUseForReference.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtUseForReference.ForeColor = System.Drawing.Color.Black;
            this.m_txtUseForReference.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtUseForReference.Location = new System.Drawing.Point(112, 510);
            this.m_txtUseForReference.m_BlnIgnoreUserInfo = false;
            this.m_txtUseForReference.m_BlnPartControl = false;
            this.m_txtUseForReference.m_BlnReadOnly = false;
            this.m_txtUseForReference.m_BlnUnderLineDST = false;
            this.m_txtUseForReference.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtUseForReference.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtUseForReference.m_IntCanModifyTime = 6;
            this.m_txtUseForReference.m_IntPartControlLength = 0;
            this.m_txtUseForReference.m_IntPartControlStartIndex = 0;
            this.m_txtUseForReference.m_StrUserID = "";
            this.m_txtUseForReference.m_StrUserName = "";
            this.m_txtUseForReference.Name = "m_txtUseForReference";
            this.m_txtUseForReference.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtUseForReference.Size = new System.Drawing.Size(772, 36);
            this.m_txtUseForReference.TabIndex = 170;
            this.m_txtUseForReference.Text = "";
            // 
            // m_cmdClose
            // 
            this.m_cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdClose.DefaultScheme = true;
            this.m_cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdClose.ForeColor = System.Drawing.Color.Black;
            this.m_cmdClose.Hint = "";
            this.m_cmdClose.Location = new System.Drawing.Point(804, 588);
            this.m_cmdClose.Name = "m_cmdClose";
            this.m_cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdClose.Size = new System.Drawing.Size(80, 30);
            this.m_cmdClose.TabIndex = 201;
            this.m_cmdClose.Text = "取消";
            this.m_cmdClose.Click += new System.EventHandler(this.m_cmdClose_Click);
            // 
            // m_cmdCompere
            // 
            this.m_cmdCompere.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdCompere.DefaultScheme = true;
            this.m_cmdCompere.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdCompere.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdCompere.ForeColor = System.Drawing.Color.Black;
            this.m_cmdCompere.Hint = "";
            this.m_cmdCompere.Location = new System.Drawing.Point(24, 155);
            this.m_cmdCompere.Name = "m_cmdCompere";
            this.m_cmdCompere.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCompere.Size = new System.Drawing.Size(84, 30);
            this.m_cmdCompere.TabIndex = 10000079;
            this.m_cmdCompere.Text = "主 持 人:";
            // 
            // m_cmdAttendee
            // 
            this.m_cmdAttendee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdAttendee.DefaultScheme = true;
            this.m_cmdAttendee.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdAttendee.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdAttendee.ForeColor = System.Drawing.Color.Black;
            this.m_cmdAttendee.Hint = "";
            this.m_cmdAttendee.Location = new System.Drawing.Point(24, 95);
            this.m_cmdAttendee.Name = "m_cmdAttendee";
            this.m_cmdAttendee.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdAttendee.Size = new System.Drawing.Size(84, 30);
            this.m_cmdAttendee.TabIndex = 10000078;
            this.m_cmdAttendee.Text = "参加人员:";
            // 
            // m_cmdReadOuter
            // 
            this.m_cmdReadOuter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdReadOuter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdReadOuter.DefaultScheme = true;
            this.m_cmdReadOuter.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdReadOuter.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdReadOuter.ForeColor = System.Drawing.Color.Black;
            this.m_cmdReadOuter.Hint = "";
            this.m_cmdReadOuter.Location = new System.Drawing.Point(523, 155);
            this.m_cmdReadOuter.Name = "m_cmdReadOuter";
            this.m_cmdReadOuter.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdReadOuter.Size = new System.Drawing.Size(100, 28);
            this.m_cmdReadOuter.TabIndex = 10000080;
            this.m_cmdReadOuter.Text = "病例宣读人:";
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
            this.m_cmdEmployeeSign.Location = new System.Drawing.Point(112, 552);
            this.m_cmdEmployeeSign.Name = "m_cmdEmployeeSign";
            this.m_cmdEmployeeSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdEmployeeSign.Size = new System.Drawing.Size(80, 30);
            this.m_cmdEmployeeSign.TabIndex = 10000081;
            this.m_cmdEmployeeSign.Text = "记录者:";
            // 
            // m_cmdAddress
            // 
            this.m_cmdAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdAddress.DefaultScheme = true;
            this.m_cmdAddress.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdAddress.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdAddress.ForeColor = System.Drawing.Color.Black;
            this.m_cmdAddress.Hint = "";
            this.m_cmdAddress.Location = new System.Drawing.Point(24, 56);
            this.m_cmdAddress.Name = "m_cmdAddress";
            this.m_cmdAddress.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdAddress.Size = new System.Drawing.Size(84, 30);
            this.m_cmdAddress.TabIndex = 90;
            this.m_cmdAddress.Text = "地点:";
            // 
            // lsvAttend
            // 
            this.lsvAttend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvAttend.BackColor = System.Drawing.Color.White;
            this.lsvAttend.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.lsvAttend.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvAttend.ForeColor = System.Drawing.Color.Black;
            this.lsvAttend.FullRowSelect = true;
            this.lsvAttend.GridLines = true;
            this.lsvAttend.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lsvAttend.Location = new System.Drawing.Point(112, 95);
            this.lsvAttend.Name = "lsvAttend";
            this.lsvAttend.Size = new System.Drawing.Size(772, 48);
            this.lsvAttend.TabIndex = 10000083;
            this.lsvAttend.UseCompatibleStateImageBehavior = false;
            this.lsvAttend.View = System.Windows.Forms.View.SmallIcon;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 55;
            // 
            // lsvCompere
            // 
            this.lsvCompere.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvCompere.BackColor = System.Drawing.Color.White;
            this.lsvCompere.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.lsvCompere.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvCompere.ForeColor = System.Drawing.Color.Black;
            this.lsvCompere.FullRowSelect = true;
            this.lsvCompere.GridLines = true;
            this.lsvCompere.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lsvCompere.Location = new System.Drawing.Point(112, 155);
            this.lsvCompere.Name = "lsvCompere";
            this.lsvCompere.Size = new System.Drawing.Size(405, 28);
            this.lsvCompere.TabIndex = 10000084;
            this.lsvCompere.UseCompatibleStateImageBehavior = false;
            this.lsvCompere.View = System.Windows.Forms.View.SmallIcon;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 55;
            // 
            // lsvSign
            // 
            this.lsvSign.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvSign.BackColor = System.Drawing.Color.White;
            this.lsvSign.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lsvSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvSign.ForeColor = System.Drawing.Color.Black;
            this.lsvSign.FullRowSelect = true;
            this.lsvSign.GridLines = true;
            this.lsvSign.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lsvSign.Location = new System.Drawing.Point(196, 552);
            this.lsvSign.Name = "lsvSign";
            this.lsvSign.Size = new System.Drawing.Size(688, 28);
            this.lsvSign.TabIndex = 10000085;
            this.lsvSign.UseCompatibleStateImageBehavior = false;
            this.lsvSign.View = System.Windows.Forms.View.SmallIcon;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 55;
            // 
            // lsvRead
            // 
            this.lsvRead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvRead.BackColor = System.Drawing.Color.White;
            this.lsvRead.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4});
            this.lsvRead.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvRead.ForeColor = System.Drawing.Color.Black;
            this.lsvRead.FullRowSelect = true;
            this.lsvRead.GridLines = true;
            this.lsvRead.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lsvRead.Location = new System.Drawing.Point(629, 155);
            this.lsvRead.Name = "lsvRead";
            this.lsvRead.Size = new System.Drawing.Size(255, 28);
            this.lsvRead.TabIndex = 10000086;
            this.lsvRead.UseCompatibleStateImageBehavior = false;
            this.lsvRead.View = System.Windows.Forms.View.SmallIcon;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Width = 55;
            // 
            // frmDeadCaseDiscuss
            // 
            this.AccessibleDescription = "死亡病例讨论记录";
            this.CancelButton = this.m_cmdClose;
            this.ClientSize = new System.Drawing.Size(916, 637);
            this.Controls.Add(this.lsvRead);
            this.Controls.Add(this.lsvSign);
            this.Controls.Add(this.lsvCompere);
            this.Controls.Add(this.lsvAttend);
            this.Controls.Add(this.lblDiscussContentTitle);
            this.Controls.Add(this.lblAddressTitle);
            this.Controls.Add(this.lblDeadDiagnoseTitle);
            this.Controls.Add(this.lblDeadReasonTitle);
            this.Controls.Add(this.m_cmdAddress);
            this.Controls.Add(this.m_cmdEmployeeSign);
            this.Controls.Add(this.m_cmdReadOuter);
            this.Controls.Add(this.m_cmdCompere);
            this.Controls.Add(this.m_cmdAttendee);
            this.Controls.Add(this.m_cmdClose);
            this.Controls.Add(this.m_txtDiscussContent);
            this.Controls.Add(this.m_txtAddress);
            this.Controls.Add(this.cmdConfirm);
            this.Controls.Add(this.m_txtDeadDiagnose);
            this.Controls.Add(this.m_txtDeadReason);
            this.Controls.Add(this.lblUseForReferenceTitle);
            this.Controls.Add(this.m_txtUseForReference);
            this.Name = "frmDeadCaseDiscuss";
            this.Text = "死亡病例讨论记录";
            this.Load += new System.EventHandler(this.frmDeadCaseDiscuss_Load);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_lblGetDataTime, 0);
            this.Controls.SetChildIndex(this.m_dtpGetDataTime, 0);
            this.Controls.SetChildIndex(this.m_txtUseForReference, 0);
            this.Controls.SetChildIndex(this.lblUseForReferenceTitle, 0);
            this.Controls.SetChildIndex(this.m_txtDeadReason, 0);
            this.Controls.SetChildIndex(this.m_txtDeadDiagnose, 0);
            this.Controls.SetChildIndex(this.cmdConfirm, 0);
            this.Controls.SetChildIndex(this.m_txtAddress, 0);
            this.Controls.SetChildIndex(this.m_txtDiscussContent, 0);
            this.Controls.SetChildIndex(this.m_cmdClose, 0);
            this.Controls.SetChildIndex(this.m_cmdAttendee, 0);
            this.Controls.SetChildIndex(this.m_cmdCompere, 0);
            this.Controls.SetChildIndex(this.m_cmdReadOuter, 0);
            this.Controls.SetChildIndex(this.m_cmdEmployeeSign, 0);
            this.Controls.SetChildIndex(this.m_cmdAddress, 0);
            this.Controls.SetChildIndex(this.lblDeadReasonTitle, 0);
            this.Controls.SetChildIndex(this.lblDeadDiagnoseTitle, 0);
            this.Controls.SetChildIndex(this.m_dtpCreateDate, 0);
            this.Controls.SetChildIndex(this.lblCreateDateTitle, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.lblAddressTitle, 0);
            this.Controls.SetChildIndex(this.lblDiscussContentTitle, 0);
            this.Controls.SetChildIndex(this.m_trvCreateDate, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.lsvAttend, 0);
            this.Controls.SetChildIndex(this.lsvCompere, 0);
            this.Controls.SetChildIndex(this.lsvSign, 0);
            this.Controls.SetChildIndex(this.lsvRead, 0);
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
			clsDeadCaseDiscussInfo objTrackInfo = new clsDeadCaseDiscussInfo();

			objTrackInfo.m_ObjRecordContent = m_objCurrentRecordContent;//m_objGetContentFromGUI();
			//设置m_strTitle和m_dtmRecordTime
			objTrackInfo.m_DtmRecordTime = m_dtpCreateDate.Value;
			objTrackInfo.m_StrTitle = "死亡病例讨论记录";			
			
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
			m_txtAddress.m_mthClearText();			
			m_txtDiscussContent.m_mthClearText();
			m_txtDeadDiagnose.m_mthClearText();
			m_txtDeadReason.m_mthClearText();
			m_txtUseForReference.m_mthClearText();
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
			int intCompere=lsvCompere.Items.Count;
			int intAttend=lsvAttend.Items.Count;
			int intRead=lsvRead.Items.Count;
            if (m_objCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)				
				return null;
			if (intSignCount==0)
			{
				clsPublicFunction.ShowInformationMessageBox("请至少一个记录员签名!");
				return null;
			}

			if (intCompere==0)
			{
				clsPublicFunction.ShowInformationMessageBox("请主持人签名!");
				return null;
			}
			if (intAttend==0)
			{
				clsPublicFunction.ShowInformationMessageBox("请至少一个参加人员签名!");
				return null;
			}
			//从界面获取表单值
			clsDeadCaseDiscussRecordContent objContent=new clsDeadCaseDiscussRecordContent();

			//获取lsvsign签名
			objContent.objSignerArr=new clsEmrSigns_VO[intSignCount+intCompere+intAttend+intRead];
			strUserIDList="";
			strUserNameList="";
            m_mthGetSignArr(new Control[] { lsvSign, lsvCompere, lsvAttend, lsvRead }, ref objContent.objSignerArr, ref strUserIDList, ref strUserNameList);
            //for (int i = 0; i < intSignCount; i++)
            //{
            //    objContent.objSignerArr[i]=new clsEmrSigns_VO();
            //    objContent.objSignerArr[i].objEmployee=new clsEmrEmployeeBase_VO();
            //    objContent.objSignerArr[i].objEmployee=(clsEmrEmployeeBase_VO)( lsvSign.Items[i].Tag);
            //    objContent.objSignerArr[i].controlName="lsvSign";
            //    objContent.objSignerArr[i].m_strFORMID_VCHR="frmDeadCaseDiscuss";//注意大小写
            //    objContent.objSignerArr[i].m_strREGISTERID_CHR=com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;
            //    //痕迹格式 0972,0324,

            //    strUserIDList=strUserIDList+objContent.objSignerArr[i].objEmployee.m_strEMPID_CHR.Trim()+",";
            //    strUserNameList=strUserNameList+objContent.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR.Trim()+",";
            //}
			objContent.m_strModifyUserID=strUserIDList;
            ////获取主持人签名
            //for (int i = 0; i < intCompere; i++)
            //{
            //    objContent.objSignerArr[intSignCount+i]=new clsEmrSigns_VO();
            //    objContent.objSignerArr[intSignCount+i].objEmployee=new clsEmrEmployeeBase_VO();
            //    objContent.objSignerArr[intSignCount+i].objEmployee=(clsEmrEmployeeBase_VO)( lsvCompere.Items[i].Tag);
            //    objContent.objSignerArr[intSignCount+i].controlName="lsvCompere";
            //    objContent.objSignerArr[intSignCount+i].m_strFORMID_VCHR="frmDeadCaseDiscuss";//注意大小写
            //    objContent.objSignerArr[intSignCount+i].m_strREGISTERID_CHR=com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;
            //}
            ////获取参加人员签名
            //for (int i = 0; i < intAttend; i++)
            //{
            //    objContent.objSignerArr[intSignCount+intCompere+i]=new clsEmrSigns_VO();
            //    objContent.objSignerArr[intSignCount+intCompere+i].objEmployee=new clsEmrEmployeeBase_VO();
            //    objContent.objSignerArr[intSignCount+intCompere+i].objEmployee=(clsEmrEmployeeBase_VO)( lsvAttend.Items[i].Tag);
            //    objContent.objSignerArr[intSignCount+intCompere+i].controlName="lsvAttend";
            //    objContent.objSignerArr[intSignCount+intCompere+i].m_strFORMID_VCHR="frmDeadCaseDiscuss";//注意大小写
            //    objContent.objSignerArr[intSignCount+intCompere+i].m_strREGISTERID_CHR=com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;
            //}
            ////获取宣读者签名
            //for (int i = 0; i < intRead; i++)
            //{
            //    objContent.objSignerArr[intSignCount+intCompere+intAttend+i]=new clsEmrSigns_VO();
            //    objContent.objSignerArr[intSignCount+intCompere+intAttend+i].objEmployee=new clsEmrEmployeeBase_VO();
            //    objContent.objSignerArr[intSignCount+intCompere+intAttend+i].objEmployee=(clsEmrEmployeeBase_VO)( lsvRead.Items[i].Tag);
            //    objContent.objSignerArr[intSignCount+intCompere+intAttend+i].controlName="lsvRead";
            //    objContent.objSignerArr[intSignCount+intCompere+intAttend+i].m_strFORMID_VCHR="frmDeadCaseDiscuss";//注意大小写
            //    objContent.objSignerArr[intSignCount+intCompere+intAttend+i].m_strREGISTERID_CHR=com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;
            //}

			
			//设置Richtextbox的modifyuserID 和modifyuserName
			m_mthSetRichTextBoxAttribInControlWithIDandName(this);
			#region 是否可以无痕迹修改
			if (chkModifyWithoutMatk.Checked)
				objContent.m_intMarkStatus=0;
			else
				objContent.m_intMarkStatus=1;
			#endregion
			objContent.m_dtmCreateDate=m_dtpCreateDate.Value;					
				
			objContent.m_strAddress_Right=m_txtAddress.m_strGetRightText();	
			objContent.m_strAddress=m_txtAddress.Text;
			objContent.m_strAddressXML=m_txtAddress.m_strGetXmlText();					
			
			objContent.m_strDiscussContent_Right=m_txtDiscussContent.m_strGetRightText();	
			objContent.m_strDiscussContent=m_txtDiscussContent.Text;
			objContent.m_strDiscussContentXML=m_txtDiscussContent.m_strGetXmlText();			
			
			objContent.m_strDeadDiagnose_Right=m_txtDeadDiagnose.m_strGetRightText();	
			objContent.m_strDeadDiagnose=m_txtDeadDiagnose.Text;
			objContent.m_strDeadDiagnoseXML=m_txtDeadDiagnose.m_strGetXmlText();			
			
			objContent.m_strDeadReason_Right=m_txtDeadReason.m_strGetRightText();	
			objContent.m_strDeadReason=m_txtDeadReason.Text;
			objContent.m_strDeadReasonXML=m_txtDeadReason.m_strGetXmlText();			
			
			objContent.m_strUseForReference_Right=m_txtUseForReference.m_strGetRightText();	
			objContent.m_strUseForReference=m_txtUseForReference.Text;
			objContent.m_strUseForReferenceXML=m_txtUseForReference.m_strGetXmlText();			
			


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
			clsDeadCaseDiscussRecordContent objContent=(clsDeadCaseDiscussRecordContent)p_objContent;
			//把表单值赋值到界面，由子窗体重载实现
			m_txtAddress.m_mthSetNewText(objContent.m_strAddress,objContent.m_strAddressXML);		
			m_txtDiscussContent.m_mthSetNewText(objContent.m_strDiscussContent,objContent.m_strDiscussContentXML);		
			m_txtDeadDiagnose.m_mthSetNewText(objContent.m_strDeadDiagnose,objContent.m_strDeadDiagnoseXML);		
			m_txtDeadReason.m_mthSetNewText(objContent.m_strDeadReason,objContent.m_strDeadReasonXML);		
			m_txtUseForReference.m_mthSetNewText(objContent.m_strUseForReference,objContent.m_strUseForReferenceXML);		
			
			#region 签名集合
			//记录签名
			if (objContent.objSignerArr!=null)
            {
                m_mthAddSignToListView(lsvSign, objContent.objSignerArr);
                m_mthAddSignToListView(lsvCompere, objContent.objSignerArr);
                m_mthAddSignToListView(lsvAttend, objContent.objSignerArr);
                m_mthAddSignToListView(lsvRead, objContent.objSignerArr);
               
			}
			#endregion 签名		
		}

		public override int m_IntFormID
		{
			get
			{
				return 16;
			}
		}

		protected override void m_mthSetDeletedGUIFromContent(clsTrackRecordContent p_objContent)
		{
			if(p_objContent ==null)
				return;
			clsDeadCaseDiscussRecordContent objContent=(clsDeadCaseDiscussRecordContent)p_objContent;
			//把表单值赋值到界面，由子窗体重载实现
			m_txtAddress.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strAddress,objContent.m_strAddressXML);		
			m_txtDiscussContent.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDiscussContent,objContent.m_strDiscussContentXML);		
			m_txtDeadDiagnose.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDeadDiagnose,objContent.m_strDeadDiagnoseXML);		
			m_txtDeadReason.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDeadReason,objContent.m_strDeadReasonXML);		
			m_txtUseForReference.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strUseForReference,objContent.m_strUseForReferenceXML);

            //记录签名
            if (objContent.objSignerArr != null)
            {
                m_mthAddSignToListView(lsvSign, objContent.objSignerArr);
                m_mthAddSignToListView(lsvCompere, objContent.objSignerArr);
                m_mthAddSignToListView(lsvAttend, objContent.objSignerArr);
                m_mthAddSignToListView(lsvRead, objContent.objSignerArr);

            }
		}

		/// <summary>
		/// 获取病程记录的领域层实例
		/// </summary>
		/// <returns></returns>
		protected override clsDiseaseTrackDomain m_objGetDiseaseTrackDomain()
		{
			//获取病程记录的领域层实例
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.DeadCaseDiscuss);					
		}

		/// <summary>
		/// 把选择时间记录内容重新整理为完全正确的内容。
		/// </summary>
		/// <param name="p_objRecordContent"></param>
		protected override void m_mthReAddNewRecord(clsTrackRecordContent p_objRecordContent)
		{
			//把选择时间记录内容重新整理为完全正确的内容，由子窗体重载实现。
			clsDeadCaseDiscussRecordContent objContent=(clsDeadCaseDiscussRecordContent)p_objRecordContent;
			//把表单值赋值到界面，由子窗体重载实现
			m_txtAddress.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strAddress,objContent.m_strAddressXML);		
			m_txtDiscussContent.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDiscussContent,objContent.m_strDiscussContentXML);		
			m_txtDeadDiagnose.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDeadDiagnose,objContent.m_strDeadDiagnoseXML);		
			m_txtDeadReason.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDeadReason,objContent.m_strDeadReasonXML);		
			m_txtUseForReference.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strUseForReference,objContent.m_strUseForReferenceXML);		

			#region 签名集合
            strUserIDList = "";
            strUserNameList = "";
            m_mthGetSignArr(new Control[] { lsvSign, lsvCompere, lsvAttend, lsvRead }, ref objContent.objSignerArr, ref strUserIDList, ref strUserNameList);
			//记录签名
            //if (objContent.objSignerArr!=null)
            //{
            //    lsvSign.Items.Clear();
            //    for (int i = 0; i < objContent.objSignerArr.Length; i++)
            //    {
            //        if (objContent.objSignerArr[i].controlName=="lsvSign")
            //        {
            //            ListViewItem lviNewItem=new ListViewItem(objContent.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR);
            //            //ID 检查重复用
            //            lviNewItem.SubItems.Add(objContent.objSignerArr[i].objEmployee.m_strEMPID_CHR);
            //            //级别 排序用
            //            lviNewItem.SubItems.Add(objContent.objSignerArr[i].objEmployee.m_strLEVEL_CHR);
            //            //tag均为对象
            //            lviNewItem.Tag=objContent.objSignerArr[i].objEmployee;
            //            //是按顺序保存故获取顺序也一样
            //            lsvSign.Items.Add(lviNewItem);
            //        }
            //    }
            //}
            ////主持签名
            //if (objContent.objSignerArr!=null)
            //{
            //    lsvCompere.Items.Clear();
            //    for (int i = 0; i < objContent.objSignerArr.Length; i++)
            //    {
            //        if (objContent.objSignerArr[i].controlName=="lsvCompere")
            //        {
            //            ListViewItem lviNewItem=new ListViewItem(objContent.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR);
            //            //ID 检查重复用
            //            lviNewItem.SubItems.Add(objContent.objSignerArr[i].objEmployee.m_strEMPID_CHR);
            //            //级别 排序用
            //            lviNewItem.SubItems.Add(objContent.objSignerArr[i].objEmployee.m_strLEVEL_CHR);
            //            //tag均为对象
            //            lviNewItem.Tag=objContent.objSignerArr[i].objEmployee;
            //            //是按顺序保存故获取顺序也一样
            //            lsvCompere.Items.Add(lviNewItem);
            //        }
            //    }
            //}
            ////参加者签名
            //if (objContent.objSignerArr!=null)
            //{
            //    lsvAttend.Items.Clear();
            //    for (int i = 0; i < objContent.objSignerArr.Length; i++)
            //    {
            //        if (objContent.objSignerArr[i].controlName=="lsvAttend")
            //        {
            //            ListViewItem lviNewItem=new 						 ListViewItem(objContent.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR);
            //            //ID 检查重复用
            //            lviNewItem.SubItems.Add(objContent.objSignerArr[i].objEmployee.m_strEMPID_CHR);
            //            //级别 排序用
            //            lviNewItem.SubItems.Add(objContent.objSignerArr[i].objEmployee.m_strLEVEL_CHR);
            //            //tag均为对象
            //            lviNewItem.Tag=objContent.objSignerArr[i].objEmployee;
            //            //是按顺序保存故获取顺序也一样
            //            lsvAttend.Items.Add(lviNewItem);
            //        }
            //    }
            //}
            ////宣读者签名
            //if (objContent.objSignerArr!=null)
            //{
            //    lsvRead.Items.Clear();
            //    for (int i = 0; i < objContent.objSignerArr.Length; i++)
            //    {
            //        if (objContent.objSignerArr[i].controlName=="lsvRead")
            //        {
            //            ListViewItem lviNewItem=new 						 ListViewItem(objContent.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR);
            //            //ID 检查重复用
            //            lviNewItem.SubItems.Add(objContent.objSignerArr[i].objEmployee.m_strEMPID_CHR);
            //            //级别 排序用
            //            lviNewItem.SubItems.Add(objContent.objSignerArr[i].objEmployee.m_strLEVEL_CHR);
            //            //tag均为对象
            //            lviNewItem.Tag=objContent.objSignerArr[i].objEmployee;
            //            //是按顺序保存故获取顺序也一样
            //            lsvRead.Items.Add(lviNewItem);
            //        }
            //    }
            //}
			#endregion 签名		
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
			return	"死亡病例讨论记录";
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

		private void frmDeadCaseDiscuss_Load(object sender, System.EventArgs e)
		{
//			m_cmdNewTemplate.Left=cmdConfirm.Left-m_cmdNewTemplate.Width+(cmdConfirm.Right-m_cmdClose.Left);
//			m_cmdNewTemplate.Top=cmdConfirm.Top;
//			m_cmdNewTemplate.Visible=true;
			this.m_dtpCreateDate.m_EnmVisibleFlag=MDIParent.s_ObjRecordDateTimeInfo.m_enmGetRecordTimeFlag(this.Name);
			this.m_dtpCreateDate.m_mthResetSize();

			m_txtAddress.Focus();
		}

		private void m_cmdClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void m_lsvNoter_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch(e.KeyCode)
			{
				case Keys.Delete:
					clsEmployeeSignTool.s_mthDeleteListViewItem((ListView)sender);
					break;
			}
		}
		
		/// <summary>
		/// 数据复用
		/// </summary>
		/// <param name="p_objSelectedPatient"></param>
		protected override void m_mthDataShare(clsPatient p_objSelectedPatient)
		{
//			clsInPatientCaseHisoryDefaultValue [] objInPatientCaseDefaultValue = new clsInPatientCaseHisoryDefaultDomain().lngGetAllInPatientCaseHisoryDefault(p_objSelectedPatient.m_StrInPatientID,p_objSelectedPatient.m_DtmLastInDate.ToString());
//			if(objInPatientCaseDefaultValue !=null && objInPatientCaseDefaultValue.Length >0)
//			{
//				this.m_txtDeadDiagnose.Text=objInPatientCaseDefaultValue[0].m_strPrimaryDiagnose;
//			}
		}

	}
}

