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
	/// （死亡）病程记录子窗体的实现,Muzhong-2003-5-23
	/// </summary>
	public class frmDeadRecord : iCare.frmDiseaseTrackBase
	{
		private System.Windows.Forms.Label lblInHospitalDateTitle;
		private System.Windows.Forms.Label m_lblInHospitalDate;
		private System.Windows.Forms.Label label6;
		protected com.digitalwave.Utility.Controls.ctlTimePicker m_dtpDeadDate;
		private System.Windows.Forms.Label lblCaseHistoryTitle;
		private System.Windows.Forms.Label lblDeadDiagnoseTitle;
		private System.Windows.Forms.Label lblOriginalDiagnoseTitle;
		private com.digitalwave.controls.ctlRichTextBox m_txtDeadDiagnose;
		private com.digitalwave.controls.ctlRichTextBox m_txtDiagnoseBy;
		private com.digitalwave.controls.ctlRichTextBox m_txtOriginalDiagnose;
		private com.digitalwave.controls.ctlRichTextBox m_txtInHospitalCase;
		private System.Windows.Forms.Label lblDeadReasonTitle;
		private System.Windows.Forms.Label lblNoticeTitle;
		private com.digitalwave.controls.ctlRichTextBox m_txtExperience;
		private com.digitalwave.controls.ctlRichTextBox m_txtDeadReason;
		private System.Windows.Forms.Label lblConsultationTitle;
		private PinkieControls.ButtonXP cmdConfirm;
		private System.Windows.Forms.Label lblInHospitalReasonTitle;
		private System.Windows.Forms.Label m_lblInHospitalReason;
		private PinkieControls.ButtonXP m_cmdClose;
		private System.ComponentModel.IContainer components = null;
		private	clsCommonUseToolCollection m_objCUTC;

		private clsEmployeeSignTool m_objSignTool;
		protected System.Windows.Forms.ListView lsvSign;
		private System.Windows.Forms.ColumnHeader clmEmployeeName;
		private PinkieControls.ButtonXP m_cmdEmployeeSign;

		//定义签名类
		private clsEmrSignToolCollection m_objSign;

		public frmDeadRecord()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call


            //指明医生工作站表单
            intFormType = 1;
			cmdConfirm.Visible=false;
			
			m_mthSetRichTextBoxAttribInControl(this);

			this.Text="死亡记录";			
			this.m_lblForTitle.Text=this.Text;			
		
//			m_txtDoctorSign.LostFocus += new EventHandler(m_lsvDoctorList_LostFocus);
//			m_lsvDoctorList.LostFocus += new EventHandler(m_lsvDoctorList_LostFocus);
//			m_lsvDoctorList.Visible=false;
			//签名常用值
			m_objSign = new clsEmrSignToolCollection();
			//m_mthBindEmployeeSign(按钮,签名框,医生1or护士2,身份验证trueorfalse);
            m_objSign.m_mthBindEmployeeSign(m_cmdEmployeeSign, lsvSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);

		
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
            this.lblInHospitalDateTitle = new System.Windows.Forms.Label();
            this.m_lblInHospitalDate = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_dtpDeadDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.lblCaseHistoryTitle = new System.Windows.Forms.Label();
            this.lblDeadDiagnoseTitle = new System.Windows.Forms.Label();
            this.lblOriginalDiagnoseTitle = new System.Windows.Forms.Label();
            this.m_txtDeadDiagnose = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtDiagnoseBy = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtOriginalDiagnose = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtInHospitalCase = new com.digitalwave.controls.ctlRichTextBox();
            this.lblDeadReasonTitle = new System.Windows.Forms.Label();
            this.lblNoticeTitle = new System.Windows.Forms.Label();
            this.m_txtExperience = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtDeadReason = new com.digitalwave.controls.ctlRichTextBox();
            this.lblConsultationTitle = new System.Windows.Forms.Label();
            this.cmdConfirm = new PinkieControls.ButtonXP();
            this.lblInHospitalReasonTitle = new System.Windows.Forms.Label();
            this.m_lblInHospitalReason = new System.Windows.Forms.Label();
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
            this.m_trvCreateDate.Location = new System.Drawing.Point(27, -68);
            this.m_trvCreateDate.Size = new System.Drawing.Size(212, 72);
            this.m_trvCreateDate.Visible = false;
            // 
            // lblCreateDateTitle
            // 
            this.lblCreateDateTitle.Location = new System.Drawing.Point(48, 36);
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.Location = new System.Drawing.Point(136, 36);
            // 
            // m_dtpGetDataTime
            // 
            this.m_dtpGetDataTime.Location = new System.Drawing.Point(420, -26);
            // 
            // m_lblGetDataTime
            // 
            this.m_lblGetDataTime.Location = new System.Drawing.Point(284, -22);
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(584, -18);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(692, -18);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(284, -18);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(578, -19);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(404, -18);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(532, -18);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(640, -18);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(376, -23);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(168, -125);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(570, -22);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(452, -22);
            this.m_txtPatientName.Size = new System.Drawing.Size(76, 23);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(332, -22);
            this.m_txtBedNO.Size = new System.Drawing.Size(68, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(432, -27);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(42, -103);
            this.m_lsvPatientName.Size = new System.Drawing.Size(76, 104);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(12, -103);
            this.m_lsvBedNO.Size = new System.Drawing.Size(68, 104);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(80, -39);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(24, -31);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(27, 600);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.Location = new System.Drawing.Point(196, -67);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(156, -67);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(272, -63);
            this.m_lblForTitle.Text = "死 亡 记 录";
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(23, 600);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(641, -48);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Location = new System.Drawing.Point(10, -72);
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            // 
            // lblInHospitalDateTitle
            // 
            this.lblInHospitalDateTitle.AutoSize = true;
            this.lblInHospitalDateTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInHospitalDateTitle.Location = new System.Drawing.Point(364, 36);
            this.lblInHospitalDateTitle.Name = "lblInHospitalDateTitle";
            this.lblInHospitalDateTitle.Size = new System.Drawing.Size(70, 14);
            this.lblInHospitalDateTitle.TabIndex = 6088;
            this.lblInHospitalDateTitle.Text = "入院时间:";
            // 
            // m_lblInHospitalDate
            // 
            this.m_lblInHospitalDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblInHospitalDate.Location = new System.Drawing.Point(452, 36);
            this.m_lblInHospitalDate.Name = "m_lblInHospitalDate";
            this.m_lblInHospitalDate.Size = new System.Drawing.Size(208, 19);
            this.m_lblInHospitalDate.TabIndex = 6089;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(48, 574);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 14);
            this.label6.TabIndex = 29161;
            this.label6.Text = "死亡时间:";
            // 
            // m_dtpDeadDate
            // 
            this.m_dtpDeadDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_dtpDeadDate.BorderColor = System.Drawing.Color.Black;
            this.m_dtpDeadDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpDeadDate.DropButtonBackColor = System.Drawing.Color.Gainsboro;
            this.m_dtpDeadDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpDeadDate.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpDeadDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpDeadDate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpDeadDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpDeadDate.Location = new System.Drawing.Point(136, 574);
            this.m_dtpDeadDate.m_BlnOnlyTime = false;
            this.m_dtpDeadDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpDeadDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpDeadDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpDeadDate.Name = "m_dtpDeadDate";
            this.m_dtpDeadDate.ReadOnly = false;
            this.m_dtpDeadDate.Size = new System.Drawing.Size(216, 22);
            this.m_dtpDeadDate.TabIndex = 160;
            this.m_dtpDeadDate.TextBackColor = System.Drawing.Color.White;
            this.m_dtpDeadDate.TextForeColor = System.Drawing.Color.Black;
            // 
            // lblCaseHistoryTitle
            // 
            this.lblCaseHistoryTitle.AutoSize = true;
            this.lblCaseHistoryTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblCaseHistoryTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCaseHistoryTitle.ForeColor = System.Drawing.Color.Black;
            this.lblCaseHistoryTitle.Location = new System.Drawing.Point(48, 283);
            this.lblCaseHistoryTitle.Name = "lblCaseHistoryTitle";
            this.lblCaseHistoryTitle.Size = new System.Drawing.Size(70, 14);
            this.lblCaseHistoryTitle.TabIndex = 29169;
            this.lblCaseHistoryTitle.Text = "诊治经过:";
            // 
            // lblDeadDiagnoseTitle
            // 
            this.lblDeadDiagnoseTitle.AutoSize = true;
            this.lblDeadDiagnoseTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblDeadDiagnoseTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDeadDiagnoseTitle.ForeColor = System.Drawing.Color.Black;
            this.lblDeadDiagnoseTitle.Location = new System.Drawing.Point(48, 196);
            this.lblDeadDiagnoseTitle.Name = "lblDeadDiagnoseTitle";
            this.lblDeadDiagnoseTitle.Size = new System.Drawing.Size(70, 14);
            this.lblDeadDiagnoseTitle.TabIndex = 29165;
            this.lblDeadDiagnoseTitle.Text = "初步诊断:";
            // 
            // lblOriginalDiagnoseTitle
            // 
            this.lblOriginalDiagnoseTitle.AutoSize = true;
            this.lblOriginalDiagnoseTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblOriginalDiagnoseTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOriginalDiagnoseTitle.ForeColor = System.Drawing.Color.Black;
            this.lblOriginalDiagnoseTitle.Location = new System.Drawing.Point(48, 132);
            this.lblOriginalDiagnoseTitle.Name = "lblOriginalDiagnoseTitle";
            this.lblOriginalDiagnoseTitle.Size = new System.Drawing.Size(70, 14);
            this.lblOriginalDiagnoseTitle.TabIndex = 29163;
            this.lblOriginalDiagnoseTitle.Text = "入院情况:";
            // 
            // m_txtDeadDiagnose
            // 
            this.m_txtDeadDiagnose.AccessibleDescription = "死亡疾病诊断";
            this.m_txtDeadDiagnose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtDeadDiagnose.BackColor = System.Drawing.Color.White;
            this.m_txtDeadDiagnose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDeadDiagnose.ForeColor = System.Drawing.Color.Black;
            this.m_txtDeadDiagnose.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDeadDiagnose.Location = new System.Drawing.Point(136, 352);
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
            this.m_txtDeadDiagnose.Size = new System.Drawing.Size(792, 59);
            this.m_txtDeadDiagnose.TabIndex = 130;
            this.m_txtDeadDiagnose.Text = "";
            // 
            // m_txtDiagnoseBy
            // 
            this.m_txtDiagnoseBy.AccessibleDescription = "诊治经过";
            this.m_txtDiagnoseBy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtDiagnoseBy.BackColor = System.Drawing.Color.White;
            this.m_txtDiagnoseBy.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDiagnoseBy.ForeColor = System.Drawing.Color.Black;
            this.m_txtDiagnoseBy.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDiagnoseBy.Location = new System.Drawing.Point(136, 280);
            this.m_txtDiagnoseBy.m_BlnIgnoreUserInfo = false;
            this.m_txtDiagnoseBy.m_BlnPartControl = false;
            this.m_txtDiagnoseBy.m_BlnReadOnly = false;
            this.m_txtDiagnoseBy.m_BlnUnderLineDST = false;
            this.m_txtDiagnoseBy.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDiagnoseBy.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDiagnoseBy.m_IntCanModifyTime = 6;
            this.m_txtDiagnoseBy.m_IntPartControlLength = 0;
            this.m_txtDiagnoseBy.m_IntPartControlStartIndex = 0;
            this.m_txtDiagnoseBy.m_StrUserID = "";
            this.m_txtDiagnoseBy.m_StrUserName = "";
            this.m_txtDiagnoseBy.Name = "m_txtDiagnoseBy";
            this.m_txtDiagnoseBy.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtDiagnoseBy.Size = new System.Drawing.Size(792, 66);
            this.m_txtDiagnoseBy.TabIndex = 120;
            this.m_txtDiagnoseBy.Text = "";
            // 
            // m_txtOriginalDiagnose
            // 
            this.m_txtOriginalDiagnose.AccessibleDescription = "初步诊断";
            this.m_txtOriginalDiagnose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtOriginalDiagnose.BackColor = System.Drawing.Color.White;
            this.m_txtOriginalDiagnose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOriginalDiagnose.ForeColor = System.Drawing.Color.Black;
            this.m_txtOriginalDiagnose.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOriginalDiagnose.Location = new System.Drawing.Point(136, 193);
            this.m_txtOriginalDiagnose.m_BlnIgnoreUserInfo = false;
            this.m_txtOriginalDiagnose.m_BlnPartControl = false;
            this.m_txtOriginalDiagnose.m_BlnReadOnly = false;
            this.m_txtOriginalDiagnose.m_BlnUnderLineDST = false;
            this.m_txtOriginalDiagnose.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOriginalDiagnose.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOriginalDiagnose.m_IntCanModifyTime = 6;
            this.m_txtOriginalDiagnose.m_IntPartControlLength = 0;
            this.m_txtOriginalDiagnose.m_IntPartControlStartIndex = 0;
            this.m_txtOriginalDiagnose.m_StrUserID = "";
            this.m_txtOriginalDiagnose.m_StrUserName = "";
            this.m_txtOriginalDiagnose.Name = "m_txtOriginalDiagnose";
            this.m_txtOriginalDiagnose.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtOriginalDiagnose.Size = new System.Drawing.Size(792, 81);
            this.m_txtOriginalDiagnose.TabIndex = 110;
            this.m_txtOriginalDiagnose.Text = "";
            // 
            // m_txtInHospitalCase
            // 
            this.m_txtInHospitalCase.AccessibleDescription = "入院情况";
            this.m_txtInHospitalCase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtInHospitalCase.BackColor = System.Drawing.Color.White;
            this.m_txtInHospitalCase.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtInHospitalCase.ForeColor = System.Drawing.Color.Black;
            this.m_txtInHospitalCase.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtInHospitalCase.Location = new System.Drawing.Point(136, 132);
            this.m_txtInHospitalCase.m_BlnIgnoreUserInfo = false;
            this.m_txtInHospitalCase.m_BlnPartControl = false;
            this.m_txtInHospitalCase.m_BlnReadOnly = false;
            this.m_txtInHospitalCase.m_BlnUnderLineDST = false;
            this.m_txtInHospitalCase.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtInHospitalCase.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtInHospitalCase.m_IntCanModifyTime = 6;
            this.m_txtInHospitalCase.m_IntPartControlLength = 0;
            this.m_txtInHospitalCase.m_IntPartControlStartIndex = 0;
            this.m_txtInHospitalCase.m_StrUserID = "";
            this.m_txtInHospitalCase.m_StrUserName = "";
            this.m_txtInHospitalCase.Name = "m_txtInHospitalCase";
            this.m_txtInHospitalCase.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtInHospitalCase.Size = new System.Drawing.Size(792, 55);
            this.m_txtInHospitalCase.TabIndex = 100;
            this.m_txtInHospitalCase.Text = "";
            // 
            // lblDeadReasonTitle
            // 
            this.lblDeadReasonTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDeadReasonTitle.AutoSize = true;
            this.lblDeadReasonTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblDeadReasonTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDeadReasonTitle.ForeColor = System.Drawing.Color.Black;
            this.lblDeadReasonTitle.Location = new System.Drawing.Point(48, 420);
            this.lblDeadReasonTitle.Name = "lblDeadReasonTitle";
            this.lblDeadReasonTitle.Size = new System.Drawing.Size(70, 14);
            this.lblDeadReasonTitle.TabIndex = 29168;
            this.lblDeadReasonTitle.Text = "死亡原因:";
            // 
            // lblNoticeTitle
            // 
            this.lblNoticeTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNoticeTitle.AutoSize = true;
            this.lblNoticeTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblNoticeTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNoticeTitle.ForeColor = System.Drawing.Color.Black;
            this.lblNoticeTitle.Location = new System.Drawing.Point(48, 502);
            this.lblNoticeTitle.Name = "lblNoticeTitle";
            this.lblNoticeTitle.Size = new System.Drawing.Size(70, 14);
            this.lblNoticeTitle.TabIndex = 29173;
            this.lblNoticeTitle.Text = "经验教训:";
            // 
            // m_txtExperience
            // 
            this.m_txtExperience.AccessibleDescription = "经验教训";
            this.m_txtExperience.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtExperience.BackColor = System.Drawing.Color.White;
            this.m_txtExperience.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtExperience.ForeColor = System.Drawing.Color.Black;
            this.m_txtExperience.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtExperience.Location = new System.Drawing.Point(136, 499);
            this.m_txtExperience.m_BlnIgnoreUserInfo = false;
            this.m_txtExperience.m_BlnPartControl = false;
            this.m_txtExperience.m_BlnReadOnly = false;
            this.m_txtExperience.m_BlnUnderLineDST = false;
            this.m_txtExperience.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtExperience.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtExperience.m_IntCanModifyTime = 6;
            this.m_txtExperience.m_IntPartControlLength = 0;
            this.m_txtExperience.m_IntPartControlStartIndex = 0;
            this.m_txtExperience.m_StrUserID = "";
            this.m_txtExperience.m_StrUserName = "";
            this.m_txtExperience.Name = "m_txtExperience";
            this.m_txtExperience.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtExperience.Size = new System.Drawing.Size(792, 66);
            this.m_txtExperience.TabIndex = 150;
            this.m_txtExperience.Text = "";
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
            this.m_txtDeadReason.Location = new System.Drawing.Point(136, 417);
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
            this.m_txtDeadReason.Size = new System.Drawing.Size(792, 76);
            this.m_txtDeadReason.TabIndex = 140;
            this.m_txtDeadReason.Text = "";
            // 
            // lblConsultationTitle
            // 
            this.lblConsultationTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblConsultationTitle.AutoSize = true;
            this.lblConsultationTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblConsultationTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblConsultationTitle.ForeColor = System.Drawing.Color.Black;
            this.lblConsultationTitle.Location = new System.Drawing.Point(24, 355);
            this.lblConsultationTitle.Name = "lblConsultationTitle";
            this.lblConsultationTitle.Size = new System.Drawing.Size(98, 14);
            this.lblConsultationTitle.TabIndex = 29172;
            this.lblConsultationTitle.Text = "死亡疾病诊断:";
            // 
            // cmdConfirm
            // 
            this.cmdConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.cmdConfirm.DefaultScheme = true;
            this.cmdConfirm.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdConfirm.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdConfirm.Hint = "";
            this.cmdConfirm.Location = new System.Drawing.Point(762, 602);
            this.cmdConfirm.Name = "cmdConfirm";
            this.cmdConfirm.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdConfirm.Size = new System.Drawing.Size(80, 30);
            this.cmdConfirm.TabIndex = 200;
            this.cmdConfirm.Text = "确定";
            this.cmdConfirm.Click += new System.EventHandler(this.cmdConfirm_Click);
            // 
            // lblInHospitalReasonTitle
            // 
            this.lblInHospitalReasonTitle.AutoSize = true;
            this.lblInHospitalReasonTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInHospitalReasonTitle.Location = new System.Drawing.Point(48, 80);
            this.lblInHospitalReasonTitle.Name = "lblInHospitalReasonTitle";
            this.lblInHospitalReasonTitle.Size = new System.Drawing.Size(70, 14);
            this.lblInHospitalReasonTitle.TabIndex = 29178;
            this.lblInHospitalReasonTitle.Text = "入院原因:";
            // 
            // m_lblInHospitalReason
            // 
            this.m_lblInHospitalReason.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblInHospitalReason.BackColor = System.Drawing.Color.Transparent;
            this.m_lblInHospitalReason.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblInHospitalReason.Location = new System.Drawing.Point(136, 76);
            this.m_lblInHospitalReason.Name = "m_lblInHospitalReason";
            this.m_lblInHospitalReason.Size = new System.Drawing.Size(792, 53);
            this.m_lblInHospitalReason.TabIndex = 29179;
            // 
            // m_cmdClose
            // 
            this.m_cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdClose.DefaultScheme = true;
            this.m_cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdClose.Hint = "";
            this.m_cmdClose.Location = new System.Drawing.Point(850, 602);
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
            this.m_cmdEmployeeSign.Location = new System.Drawing.Point(136, 602);
            this.m_cmdEmployeeSign.Name = "m_cmdEmployeeSign";
            this.m_cmdEmployeeSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdEmployeeSign.Size = new System.Drawing.Size(92, 28);
            this.m_cmdEmployeeSign.TabIndex = 10000034;
            this.m_cmdEmployeeSign.Tag = "1";
            this.m_cmdEmployeeSign.Text = "医师签名:";
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
            this.lsvSign.Location = new System.Drawing.Point(234, 602);
            this.lsvSign.Name = "lsvSign";
            this.lsvSign.Size = new System.Drawing.Size(522, 28);
            this.lsvSign.TabIndex = 10000035;
            this.lsvSign.UseCompatibleStateImageBehavior = false;
            this.lsvSign.View = System.Windows.Forms.View.SmallIcon;
            // 
            // clmEmployeeName
            // 
            this.clmEmployeeName.Width = 55;
            // 
            // frmDeadRecord
            // 
            this.AccessibleDescription = "死亡记录";
            this.CancelButton = this.m_cmdClose;
            this.ClientSize = new System.Drawing.Size(938, 642);
            this.Controls.Add(this.lsvSign);
            this.Controls.Add(this.lblInHospitalReasonTitle);
            this.Controls.Add(this.lblCaseHistoryTitle);
            this.Controls.Add(this.lblDeadDiagnoseTitle);
            this.Controls.Add(this.lblOriginalDiagnoseTitle);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblInHospitalDateTitle);
            this.Controls.Add(this.lblConsultationTitle);
            this.Controls.Add(this.lblDeadReasonTitle);
            this.Controls.Add(this.lblNoticeTitle);
            this.Controls.Add(this.m_cmdEmployeeSign);
            this.Controls.Add(this.m_cmdClose);
            this.Controls.Add(this.m_lblInHospitalReason);
            this.Controls.Add(this.cmdConfirm);
            this.Controls.Add(this.m_txtDeadDiagnose);
            this.Controls.Add(this.m_txtDiagnoseBy);
            this.Controls.Add(this.m_txtOriginalDiagnose);
            this.Controls.Add(this.m_txtInHospitalCase);
            this.Controls.Add(this.m_txtExperience);
            this.Controls.Add(this.m_txtDeadReason);
            this.Controls.Add(this.m_dtpDeadDate);
            this.Controls.Add(this.m_lblInHospitalDate);
            this.Name = "frmDeadRecord";
            this.Text = "死亡记录";
            this.Load += new System.EventHandler(this.frmDeadRecord_Load);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_lblGetDataTime, 0);
            this.Controls.SetChildIndex(this.m_dtpGetDataTime, 0);
            this.Controls.SetChildIndex(this.m_lblInHospitalDate, 0);
            this.Controls.SetChildIndex(this.m_dtpDeadDate, 0);
            this.Controls.SetChildIndex(this.m_txtDeadReason, 0);
            this.Controls.SetChildIndex(this.m_txtExperience, 0);
            this.Controls.SetChildIndex(this.m_txtInHospitalCase, 0);
            this.Controls.SetChildIndex(this.m_txtOriginalDiagnose, 0);
            this.Controls.SetChildIndex(this.m_txtDiagnoseBy, 0);
            this.Controls.SetChildIndex(this.m_txtDeadDiagnose, 0);
            this.Controls.SetChildIndex(this.cmdConfirm, 0);
            this.Controls.SetChildIndex(this.m_lblInHospitalReason, 0);
            this.Controls.SetChildIndex(this.m_cmdClose, 0);
            this.Controls.SetChildIndex(this.m_cmdEmployeeSign, 0);
            this.Controls.SetChildIndex(this.lblNoticeTitle, 0);
            this.Controls.SetChildIndex(this.lblDeadReasonTitle, 0);
            this.Controls.SetChildIndex(this.lblConsultationTitle, 0);
            this.Controls.SetChildIndex(this.m_dtpCreateDate, 0);
            this.Controls.SetChildIndex(this.m_trvCreateDate, 0);
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
            this.Controls.SetChildIndex(this.lblInHospitalDateTitle, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.lblOriginalDiagnoseTitle, 0);
            this.Controls.SetChildIndex(this.lblDeadDiagnoseTitle, 0);
            this.Controls.SetChildIndex(this.lblCaseHistoryTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalReasonTitle, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.lsvSign, 0);
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
            clsDeadRecordInfo objTrackInfo = new clsDeadRecordInfo(m_objCurrentPatient);

			objTrackInfo.m_ObjRecordContent = m_objCurrentRecordContent;//m_objGetContentFromGUI();
			//设置m_strTitle和m_dtmRecordTime
			objTrackInfo.m_DtmRecordTime = m_dtpCreateDate.Value;
			objTrackInfo.m_StrTitle = "死亡记录";			
			
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
			m_txtInHospitalCase.m_mthClearText();
			m_txtOriginalDiagnose.m_mthClearText();
			m_txtDiagnoseBy.m_mthClearText();
			m_txtDeadDiagnose.m_mthClearText();	
			m_txtDeadReason.m_mthClearText();
			m_txtExperience.m_mthClearText();	

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
				
                //this.Size=new Size(this.Size.Width, this.Size.Height-85);
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
			clsDeadRecordContent objContent=new clsDeadRecordContent();

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
            //    objContent.objSignerArr[i].m_strFORMID_VCHR="frmDeadRecord";//注意大小写
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
				
			objContent.m_dtmDeadDate = m_dtpDeadDate.Value;
			objContent.m_strInHospitalCase_Right=m_txtInHospitalCase.m_strGetRightText();	
			objContent.m_strInHospitalCase=m_txtInHospitalCase.Text;
			objContent.m_strInHospitalCaseXML=m_txtInHospitalCase.m_strGetXmlText();					
			
			objContent.m_strOriginalDiagnose_Right=m_txtOriginalDiagnose.m_strGetRightText();	
			objContent.m_strOriginalDiagnose=m_txtOriginalDiagnose.Text;
			objContent.m_strOriginalDiagnoseXML=m_txtOriginalDiagnose.m_strGetXmlText();					
			
			objContent.m_strDiagnoseBy_Right=m_txtDiagnoseBy.m_strGetRightText();	
			objContent.m_strDiagnoseBy=m_txtDiagnoseBy.Text;
			objContent.m_strDiagnoseByXML=m_txtDiagnoseBy.m_strGetXmlText();					
			
			objContent.m_strDeadDiagnose_Right=m_txtDeadDiagnose.m_strGetRightText();	
			objContent.m_strDeadDiagnose=m_txtDeadDiagnose.Text;
			objContent.m_strDeadDiagnoseXML=m_txtDeadDiagnose.m_strGetXmlText();			

			objContent.m_strDeadReason_Right=m_txtDeadReason.m_strGetRightText();	
			objContent.m_strDeadReason=m_txtDeadReason.Text;
			objContent.m_strDeadReasonXML=m_txtDeadReason.m_strGetXmlText();

			objContent.m_strExperience_Right=m_txtExperience.m_strGetRightText();	
			objContent.m_strExperience=m_txtExperience.Text;
			objContent.m_strExperienceXML=m_txtExperience.m_strGetXmlText();
			


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
			clsDeadRecordContent objContent=(clsDeadRecordContent)p_objContent;
			//把表单值赋值到界面，由子窗体重载实现
			m_dtpDeadDate.Value = objContent.m_dtmDeadDate;
			m_txtInHospitalCase.m_mthSetNewText(objContent.m_strInHospitalCase,objContent.m_strInHospitalCaseXML);		
			m_txtOriginalDiagnose.m_mthSetNewText(objContent.m_strOriginalDiagnose,objContent.m_strOriginalDiagnoseXML);		
			m_txtDiagnoseBy.m_mthSetNewText(objContent.m_strDiagnoseBy,objContent.m_strDiagnoseByXML);		
			m_txtDeadDiagnose.m_mthSetNewText(objContent.m_strDeadDiagnose,objContent.m_strDeadDiagnoseXML);		
			m_txtDeadReason.m_mthSetNewText(objContent.m_strDeadReason,objContent.m_strDeadReasonXML);		
			m_txtExperience.m_mthSetNewText(objContent.m_strExperience,objContent.m_strExperienceXML);		

			#region 签名集合
			if (objContent.objSignerArr!=null)
            {
                m_mthAddSignToListView(lsvSign, objContent.objSignerArr);
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


			#region 入院原因(主诉)
			clsInPatientCaseHisoryDefaultValue[] objInPatientCaseHisoryDefaultValueArr= new clsInPatientCaseHisoryDefaultDomain().lngGetAllInPatientCaseHisoryDefault(m_objCurrentPatient.m_StrInPatientID,m_ObjLastEmrPatientSession.m_dtmEMRInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"));
			if(objInPatientCaseHisoryDefaultValueArr !=null && objInPatientCaseHisoryDefaultValueArr.Length>0)
			{
				m_lblInHospitalReason.Text=objInPatientCaseHisoryDefaultValueArr[0].m_strMainDescription;
			}
			#endregion 入院原因(主诉)

		}

		public override int m_IntFormID
		{
			get
			{
				return 14;
			}
		}

		protected override void m_mthSetDeletedGUIFromContent(clsTrackRecordContent p_objContent)
		{
			if(p_objContent ==null)
				return;
			clsDeadRecordContent objContent=(clsDeadRecordContent)p_objContent;
			//把表单值赋值到界面，由子窗体重载实现
			m_dtpDeadDate.Value = objContent.m_dtmDeadDate;
			m_txtInHospitalCase.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strInHospitalCase,objContent.m_strInHospitalCaseXML);		
			m_txtOriginalDiagnose.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOriginalDiagnose,objContent.m_strOriginalDiagnoseXML);		
			m_txtDiagnoseBy.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDiagnoseBy,objContent.m_strDiagnoseByXML);		
			m_txtDeadDiagnose.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDeadDiagnose,objContent.m_strDeadDiagnoseXML);		
			m_txtDeadReason.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDeadReason,objContent.m_strDeadReasonXML);		
			m_txtExperience.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strExperience,objContent.m_strExperienceXML);


            if (objContent.objSignerArr != null)
            {
                m_mthAddSignToListView(lsvSign, objContent.objSignerArr);
            }
			#region 入院原因(主诉)
			clsInPatientCaseHisoryDefaultValue[] objInPatientCaseHisoryDefaultValueArr= new clsInPatientCaseHisoryDefaultDomain().lngGetAllInPatientCaseHisoryDefault(m_objCurrentPatient.m_StrInPatientID,m_ObjLastEmrPatientSession.m_dtmEMRInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"));
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
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.Dead);					
		}

		/// <summary>
		/// 把选择时间记录内容重新整理为完全正确的内容。
		/// </summary>
		/// <param name="p_objRecordContent"></param>
		protected override void m_mthReAddNewRecord(clsTrackRecordContent p_objRecordContent)
		{
			//把选择时间记录内容重新整理为完全正确的内容，由子窗体重载实现。
			clsDeadRecordContent objContent=(clsDeadRecordContent)p_objRecordContent;
			//把表单值赋值到界面，由子窗体重载实现

			m_txtInHospitalCase.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strInHospitalCase,objContent.m_strInHospitalCaseXML);		
			m_txtOriginalDiagnose.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOriginalDiagnose,objContent.m_strOriginalDiagnoseXML);		
			m_txtDiagnoseBy.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDiagnoseBy,objContent.m_strDiagnoseByXML);		
			m_txtDeadDiagnose.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDeadDiagnose,objContent.m_strDeadDiagnoseXML);		
			m_txtDeadReason.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDeadReason,objContent.m_strDeadReasonXML);		
			m_txtExperience.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strExperience,objContent.m_strExperienceXML);

		}		

		// 获取选择已经删除记录的窗体标题
		public override string m_strReloadFormTitle()
		{
			//由子窗体重载实现
			return	"死亡记录";
		}	
	
		/// <summary>
		/// 当选择根节点时,设置特殊的默认值(若子窗体需要,则重载实现)
		/// </summary>
		protected override void m_mthSelectRootNode()
		{
			#region 初步诊断默认值
			if(m_objCurrentPatient != null && m_ObjLastEmrPatientSession != null)
			{
				clsInPatientCaseHisoryDefaultValue[] objInPatientCaseHisoryDefaultValueArr= new clsInPatientCaseHisoryDefaultDomain().lngGetAllInPatientCaseHisoryDefault(m_objCurrentPatient.m_StrInPatientID,m_ObjLastEmrPatientSession.m_dtmEMRInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"));
				if(objInPatientCaseHisoryDefaultValueArr !=null && objInPatientCaseHisoryDefaultValueArr.Length>0)
				{
					m_txtOriginalDiagnose.Text=objInPatientCaseHisoryDefaultValueArr[0].m_strPrimaryDiagnose;
				}
			}
			#endregion 初步诊断默认值
		}

 

		private void cmdConfirm_Click(object sender, System.EventArgs e)
		{
			if(m_lngSave() > 0)
			{
				this.DialogResult = DialogResult.Yes;
				this.Close();
			}
		}

		private void frmDead_Load(object sender, System.EventArgs e)
		{
			if(m_objCurrentPatient !=null && m_ObjLastEmrPatientSession != null)
				m_lblInHospitalDate.Text=m_ObjLastEmrPatientSession.m_dtmHISInpatientDate.ToString("yyyy年MM月dd日 HH:mm");
		}

		private void frmDeadRecord_Load(object sender, System.EventArgs e)
		{
//			m_cmdNewTemplate.Left=cmdConfirm.Left-m_cmdNewTemplate.Width+(cmdConfirm.Right-m_cmdClose.Left);
//			m_cmdNewTemplate.Top=cmdConfirm.Top;
//			m_cmdNewTemplate.Visible=true;

            if (m_objCurrentPatient != null && m_ObjLastEmrPatientSession != null)
			{
                m_lblInHospitalDate.Text = m_ObjLastEmrPatientSession.m_dtmHISInpatientDate.ToString("yyyy年MM月dd日 HH:mm");
				#region 入院原因(主诉)
				clsInPatientCaseHisoryDefaultValue[] objInPatientCaseHisoryDefaultValueArr= new clsInPatientCaseHisoryDefaultDomain().lngGetAllInPatientCaseHisoryDefault(m_objCurrentPatient.m_StrInPatientID,m_ObjLastEmrPatientSession.m_dtmEMRInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"));
				if(objInPatientCaseHisoryDefaultValueArr !=null && objInPatientCaseHisoryDefaultValueArr.Length>0)
				{
					m_lblInHospitalReason.Text=objInPatientCaseHisoryDefaultValueArr[0].m_strMainDescription;
				}
				#endregion 入院原因(主诉)
			}

			this.m_dtpCreateDate.m_EnmVisibleFlag=MDIParent.s_ObjRecordDateTimeInfo.m_enmGetRecordTimeFlag(this.Name);
			this.m_dtpCreateDate.m_mthResetSize();

			m_lblInHospitalReason.Focus();
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
//				this.m_txtOriginalDiagnose.Text=objInPatientCaseDefaultValue[0].m_strPrimaryDiagnose;
//				this.m_txtDeadDiagnose.Text=objInPatientCaseDefaultValue[0].m_strPrimaryDiagnose;
			}
		}
	}
}

