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
	/// （查房）病程记录子窗体的实现,Muzhong-2003-5-23
	/// </summary>
	public class frmCheckRoom : frmDiseaseTrackBase
	{
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblReferralTitle;
		private System.Windows.Forms.Label lblCaseHistoryTitle;
		private System.Windows.Forms.Label lblCurrentDiagnoseTitle;
		private System.Windows.Forms.Label lblInHospitalCaseTitle;
		private PinkieControls.ButtonXP cmdConfirm;
		private com.digitalwave.controls.ctlRichTextBox m_txtNextCure;
		private com.digitalwave.controls.ctlRichTextBox m_txtCurrentCure;
		private com.digitalwave.controls.ctlRichTextBox m_txtDifferentiateDiagnose;
		private com.digitalwave.controls.ctlRichTextBox m_txtDiagnose;
		private PinkieControls.ButtonXP m_cmdClose;
		private com.digitalwave.controls.ctlRichTextBox m_txtPatientState;
		private System.ComponentModel.IContainer components = null;
		private PinkieControls.ButtonXP m_cmdCheckDoctors;

		private clsEmployeeSignTool m_objSignTool;
		private clsCommonUseToolCollection m_objCUTC;
		private PinkieControls.ButtonXP m_cmdEmployeeSign;
		protected System.Windows.Forms.ListView lsvSign;
		private System.Windows.Forms.ColumnHeader clmEmployeeName;
		protected System.Windows.Forms.ListView lsvCheckRoomSign;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		//定义签名类
		private clsEmrSignToolCollection m_objSign;

		public frmCheckRoom()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
            //指明医生工作站表单
            intFormType = 1;
 
			cmdConfirm.Visible=false;
			
			
			m_mthSetRichTextBoxAttribInControl(this);

			this.Text="查房记录";			
			this.m_lblForTitle.Text=this.Text;

            if (com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_StrCurrentHospitalNO == "450101001")
            {
                lblReferralTitle.Text = "    治疗：";
                m_txtCurrentCure.Size = new Size(804, 160);

                m_txtNextCure.Visible = false;
                label2.Visible = false;
            }
		
//			m_txtDoctorSign.LostFocus += new EventHandler(m_lsvDoctorList_LostFocus);
//			m_lsvDoctorList.LostFocus += new EventHandler(m_lsvDoctorList_LostFocus);
			//签名常用值
			m_objSign = new clsEmrSignToolCollection();
			//m_mthBindEmployeeSign(按钮,签名框,医生1or护士2,身份验证trueorfalse);
            m_objSign.m_mthBindEmployeeSign(m_cmdEmployeeSign, lsvSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdCheckDoctors, lsvCheckRoomSign, 1, false, clsEMRLogin.LoginInfo.m_strEmpID);


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
            this.label2 = new System.Windows.Forms.Label();
            this.lblReferralTitle = new System.Windows.Forms.Label();
            this.lblCaseHistoryTitle = new System.Windows.Forms.Label();
            this.lblCurrentDiagnoseTitle = new System.Windows.Forms.Label();
            this.lblInHospitalCaseTitle = new System.Windows.Forms.Label();
            this.m_txtNextCure = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtCurrentCure = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtDifferentiateDiagnose = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtDiagnose = new com.digitalwave.controls.ctlRichTextBox();
            this.cmdConfirm = new PinkieControls.ButtonXP();
            this.m_cmdClose = new PinkieControls.ButtonXP();
            this.m_txtPatientState = new com.digitalwave.controls.ctlRichTextBox();
            this.m_cmdCheckDoctors = new PinkieControls.ButtonXP();
            this.m_cmdEmployeeSign = new PinkieControls.ButtonXP();
            this.lsvSign = new System.Windows.Forms.ListView();
            this.clmEmployeeName = new System.Windows.Forms.ColumnHeader();
            this.lsvCheckRoomSign = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.m_pnlNewBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_trvCreateDate
            // 
            this.m_trvCreateDate.ForeColor = System.Drawing.Color.Black;
            this.m_trvCreateDate.LineColor = System.Drawing.Color.Black;
            this.m_trvCreateDate.Location = new System.Drawing.Point(521, -66);
            this.m_trvCreateDate.Size = new System.Drawing.Size(212, 72);
            this.m_trvCreateDate.Visible = false;
            // 
            // lblCreateDateTitle
            // 
            this.lblCreateDateTitle.Location = new System.Drawing.Point(24, 36);
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.Location = new System.Drawing.Point(112, 32);
            // 
            // m_dtpGetDataTime
            // 
            this.m_dtpGetDataTime.Location = new System.Drawing.Point(279, -17);
            // 
            // m_lblGetDataTime
            // 
            this.m_lblGetDataTime.Location = new System.Drawing.Point(155, -12);
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(493, -17);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(463, -13);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(185, -17);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(519, -13);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(297, -17);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(445, -17);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(411, -13);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(311, -17);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(48, -102);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(591, -17);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(345, -21);
            this.m_txtPatientName.Size = new System.Drawing.Size(88, 23);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(233, -21);
            this.m_txtBedNO.Size = new System.Drawing.Size(40, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(359, -21);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(28, -102);
            this.m_lsvPatientName.Size = new System.Drawing.Size(88, 104);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(11, -102);
            this.m_lsvBedNO.Size = new System.Drawing.Size(60, 104);
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(73, -38);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(25, -30);
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(8, 516);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.m_cmdNext.Location = new System.Drawing.Point(273, -21);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(157, -66);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(457, -62);
            this.m_lblForTitle.Text = "查 房 记 录";
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(16, 520);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(420, -43);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Location = new System.Drawing.Point(11, -71);
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(10, 447);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 14);
            this.label2.TabIndex = 6120;
            this.label2.Text = "下一步治疗:";
            // 
            // lblReferralTitle
            // 
            this.lblReferralTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblReferralTitle.AutoSize = true;
            this.lblReferralTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblReferralTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblReferralTitle.ForeColor = System.Drawing.Color.Black;
            this.lblReferralTitle.Location = new System.Drawing.Point(24, 348);
            this.lblReferralTitle.Name = "lblReferralTitle";
            this.lblReferralTitle.Size = new System.Drawing.Size(70, 14);
            this.lblReferralTitle.TabIndex = 6118;
            this.lblReferralTitle.Text = "当前治疗:";
            // 
            // lblCaseHistoryTitle
            // 
            this.lblCaseHistoryTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCaseHistoryTitle.AutoSize = true;
            this.lblCaseHistoryTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblCaseHistoryTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCaseHistoryTitle.ForeColor = System.Drawing.Color.Black;
            this.lblCaseHistoryTitle.Location = new System.Drawing.Point(24, 240);
            this.lblCaseHistoryTitle.Name = "lblCaseHistoryTitle";
            this.lblCaseHistoryTitle.Size = new System.Drawing.Size(70, 14);
            this.lblCaseHistoryTitle.TabIndex = 6116;
            this.lblCaseHistoryTitle.Text = "鉴别诊断:";
            // 
            // lblCurrentDiagnoseTitle
            // 
            this.lblCurrentDiagnoseTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCurrentDiagnoseTitle.AutoSize = true;
            this.lblCurrentDiagnoseTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentDiagnoseTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCurrentDiagnoseTitle.ForeColor = System.Drawing.Color.Black;
            this.lblCurrentDiagnoseTitle.Location = new System.Drawing.Point(50, 139);
            this.lblCurrentDiagnoseTitle.Name = "lblCurrentDiagnoseTitle";
            this.lblCurrentDiagnoseTitle.Size = new System.Drawing.Size(42, 14);
            this.lblCurrentDiagnoseTitle.TabIndex = 6114;
            this.lblCurrentDiagnoseTitle.Text = "诊断:";
            // 
            // lblInHospitalCaseTitle
            // 
            this.lblInHospitalCaseTitle.AutoSize = true;
            this.lblInHospitalCaseTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblInHospitalCaseTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInHospitalCaseTitle.ForeColor = System.Drawing.Color.Black;
            this.lblInHospitalCaseTitle.Location = new System.Drawing.Point(24, 69);
            this.lblInHospitalCaseTitle.Name = "lblInHospitalCaseTitle";
            this.lblInHospitalCaseTitle.Size = new System.Drawing.Size(70, 14);
            this.lblInHospitalCaseTitle.TabIndex = 6112;
            this.lblInHospitalCaseTitle.Text = "患者病情:";
            // 
            // m_txtNextCure
            // 
            this.m_txtNextCure.AccessibleDescription = "下一步治疗";
            this.m_txtNextCure.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtNextCure.BackColor = System.Drawing.Color.White;
            this.m_txtNextCure.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtNextCure.ForeColor = System.Drawing.Color.Black;
            this.m_txtNextCure.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtNextCure.Location = new System.Drawing.Point(112, 444);
            this.m_txtNextCure.m_BlnIgnoreUserInfo = false;
            this.m_txtNextCure.m_BlnPartControl = false;
            this.m_txtNextCure.m_BlnReadOnly = false;
            this.m_txtNextCure.m_BlnUnderLineDST = false;
            this.m_txtNextCure.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtNextCure.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtNextCure.m_IntCanModifyTime = 500;
            this.m_txtNextCure.m_IntPartControlLength = 0;
            this.m_txtNextCure.m_IntPartControlStartIndex = 0;
            this.m_txtNextCure.m_StrUserID = "";
            this.m_txtNextCure.m_StrUserName = "";
            this.m_txtNextCure.Name = "m_txtNextCure";
            this.m_txtNextCure.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtNextCure.Size = new System.Drawing.Size(804, 64);
            this.m_txtNextCure.TabIndex = 140;
            this.m_txtNextCure.Text = "";
            // 
            // m_txtCurrentCure
            // 
            this.m_txtCurrentCure.AccessibleDescription = "当前治疗";
            this.m_txtCurrentCure.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtCurrentCure.BackColor = System.Drawing.Color.White;
            this.m_txtCurrentCure.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCurrentCure.ForeColor = System.Drawing.Color.Black;
            this.m_txtCurrentCure.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCurrentCure.Location = new System.Drawing.Point(112, 345);
            this.m_txtCurrentCure.m_BlnIgnoreUserInfo = false;
            this.m_txtCurrentCure.m_BlnPartControl = false;
            this.m_txtCurrentCure.m_BlnReadOnly = false;
            this.m_txtCurrentCure.m_BlnUnderLineDST = false;
            this.m_txtCurrentCure.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtCurrentCure.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtCurrentCure.m_IntCanModifyTime = 500;
            this.m_txtCurrentCure.m_IntPartControlLength = 0;
            this.m_txtCurrentCure.m_IntPartControlStartIndex = 0;
            this.m_txtCurrentCure.m_StrUserID = "";
            this.m_txtCurrentCure.m_StrUserName = "";
            this.m_txtCurrentCure.Name = "m_txtCurrentCure";
            this.m_txtCurrentCure.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtCurrentCure.Size = new System.Drawing.Size(804, 93);
            this.m_txtCurrentCure.TabIndex = 130;
            this.m_txtCurrentCure.Text = "";
            // 
            // m_txtDifferentiateDiagnose
            // 
            this.m_txtDifferentiateDiagnose.AccessibleDescription = "鉴别诊断";
            this.m_txtDifferentiateDiagnose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtDifferentiateDiagnose.BackColor = System.Drawing.Color.White;
            this.m_txtDifferentiateDiagnose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDifferentiateDiagnose.ForeColor = System.Drawing.Color.Black;
            this.m_txtDifferentiateDiagnose.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDifferentiateDiagnose.Location = new System.Drawing.Point(112, 240);
            this.m_txtDifferentiateDiagnose.m_BlnIgnoreUserInfo = false;
            this.m_txtDifferentiateDiagnose.m_BlnPartControl = false;
            this.m_txtDifferentiateDiagnose.m_BlnReadOnly = false;
            this.m_txtDifferentiateDiagnose.m_BlnUnderLineDST = false;
            this.m_txtDifferentiateDiagnose.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDifferentiateDiagnose.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDifferentiateDiagnose.m_IntCanModifyTime = 500;
            this.m_txtDifferentiateDiagnose.m_IntPartControlLength = 0;
            this.m_txtDifferentiateDiagnose.m_IntPartControlStartIndex = 0;
            this.m_txtDifferentiateDiagnose.m_StrUserID = "";
            this.m_txtDifferentiateDiagnose.m_StrUserName = "";
            this.m_txtDifferentiateDiagnose.Name = "m_txtDifferentiateDiagnose";
            this.m_txtDifferentiateDiagnose.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtDifferentiateDiagnose.Size = new System.Drawing.Size(804, 99);
            this.m_txtDifferentiateDiagnose.TabIndex = 120;
            this.m_txtDifferentiateDiagnose.Text = "";
            // 
            // m_txtDiagnose
            // 
            this.m_txtDiagnose.AccessibleDescription = "诊断";
            this.m_txtDiagnose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtDiagnose.BackColor = System.Drawing.Color.White;
            this.m_txtDiagnose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDiagnose.ForeColor = System.Drawing.Color.Black;
            this.m_txtDiagnose.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDiagnose.Location = new System.Drawing.Point(112, 136);
            this.m_txtDiagnose.m_BlnIgnoreUserInfo = false;
            this.m_txtDiagnose.m_BlnPartControl = false;
            this.m_txtDiagnose.m_BlnReadOnly = false;
            this.m_txtDiagnose.m_BlnUnderLineDST = false;
            this.m_txtDiagnose.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDiagnose.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDiagnose.m_IntCanModifyTime = 500;
            this.m_txtDiagnose.m_IntPartControlLength = 0;
            this.m_txtDiagnose.m_IntPartControlStartIndex = 0;
            this.m_txtDiagnose.m_StrUserID = "";
            this.m_txtDiagnose.m_StrUserName = "";
            this.m_txtDiagnose.Name = "m_txtDiagnose";
            this.m_txtDiagnose.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtDiagnose.Size = new System.Drawing.Size(804, 98);
            this.m_txtDiagnose.TabIndex = 110;
            this.m_txtDiagnose.Text = "";
            // 
            // cmdConfirm
            // 
            this.cmdConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.cmdConfirm.DefaultScheme = true;
            this.cmdConfirm.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdConfirm.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdConfirm.Hint = "";
            this.cmdConfirm.Location = new System.Drawing.Point(748, 516);
            this.cmdConfirm.Name = "cmdConfirm";
            this.cmdConfirm.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdConfirm.Size = new System.Drawing.Size(80, 30);
            this.cmdConfirm.TabIndex = 160;
            this.cmdConfirm.Text = "确定";
            this.cmdConfirm.Click += new System.EventHandler(this.cmdConfirm_Click);
            // 
            // m_cmdClose
            // 
            this.m_cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdClose.DefaultScheme = true;
            this.m_cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdClose.Hint = "";
            this.m_cmdClose.Location = new System.Drawing.Point(836, 516);
            this.m_cmdClose.Name = "m_cmdClose";
            this.m_cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdClose.Size = new System.Drawing.Size(80, 30);
            this.m_cmdClose.TabIndex = 161;
            this.m_cmdClose.Text = "取消";
            this.m_cmdClose.Click += new System.EventHandler(this.m_cmdClose_Click);
            // 
            // m_txtPatientState
            // 
            this.m_txtPatientState.AccessibleDescription = "患者病情";
            this.m_txtPatientState.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtPatientState.BackColor = System.Drawing.Color.White;
            this.m_txtPatientState.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPatientState.ForeColor = System.Drawing.Color.Black;
            this.m_txtPatientState.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPatientState.Location = new System.Drawing.Point(112, 66);
            this.m_txtPatientState.m_BlnIgnoreUserInfo = false;
            this.m_txtPatientState.m_BlnPartControl = false;
            this.m_txtPatientState.m_BlnReadOnly = false;
            this.m_txtPatientState.m_BlnUnderLineDST = false;
            this.m_txtPatientState.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPatientState.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPatientState.m_IntCanModifyTime = 500;
            this.m_txtPatientState.m_IntPartControlLength = 0;
            this.m_txtPatientState.m_IntPartControlStartIndex = 0;
            this.m_txtPatientState.m_StrUserID = "";
            this.m_txtPatientState.m_StrUserName = "";
            this.m_txtPatientState.Name = "m_txtPatientState";
            this.m_txtPatientState.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtPatientState.Size = new System.Drawing.Size(804, 64);
            this.m_txtPatientState.TabIndex = 109;
            this.m_txtPatientState.Text = "";
            // 
            // m_cmdCheckDoctors
            // 
            this.m_cmdCheckDoctors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdCheckDoctors.DefaultScheme = true;
            this.m_cmdCheckDoctors.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdCheckDoctors.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdCheckDoctors.Hint = "";
            this.m_cmdCheckDoctors.Location = new System.Drawing.Point(332, 32);
            this.m_cmdCheckDoctors.Name = "m_cmdCheckDoctors";
            this.m_cmdCheckDoctors.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCheckDoctors.Size = new System.Drawing.Size(92, 28);
            this.m_cmdCheckDoctors.TabIndex = 10000077;
            this.m_cmdCheckDoctors.Text = "查房医师:";
            // 
            // m_cmdEmployeeSign
            // 
            this.m_cmdEmployeeSign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_cmdEmployeeSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdEmployeeSign.DefaultScheme = true;
            this.m_cmdEmployeeSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdEmployeeSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdEmployeeSign.Hint = "";
            this.m_cmdEmployeeSign.Location = new System.Drawing.Point(112, 520);
            this.m_cmdEmployeeSign.Name = "m_cmdEmployeeSign";
            this.m_cmdEmployeeSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdEmployeeSign.Size = new System.Drawing.Size(64, 30);
            this.m_cmdEmployeeSign.TabIndex = 10000082;
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
            this.lsvSign.Location = new System.Drawing.Point(180, 520);
            this.lsvSign.Name = "lsvSign";
            this.lsvSign.Size = new System.Drawing.Size(512, 28);
            this.lsvSign.TabIndex = 10000083;
            this.lsvSign.UseCompatibleStateImageBehavior = false;
            this.lsvSign.View = System.Windows.Forms.View.SmallIcon;
            // 
            // clmEmployeeName
            // 
            this.clmEmployeeName.Width = 55;
            // 
            // lsvCheckRoomSign
            // 
            this.lsvCheckRoomSign.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvCheckRoomSign.BackColor = System.Drawing.Color.White;
            this.lsvCheckRoomSign.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lsvCheckRoomSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvCheckRoomSign.ForeColor = System.Drawing.Color.Black;
            this.lsvCheckRoomSign.FullRowSelect = true;
            this.lsvCheckRoomSign.GridLines = true;
            this.lsvCheckRoomSign.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lsvCheckRoomSign.Location = new System.Drawing.Point(432, 32);
            this.lsvCheckRoomSign.Name = "lsvCheckRoomSign";
            this.lsvCheckRoomSign.Size = new System.Drawing.Size(484, 28);
            this.lsvCheckRoomSign.TabIndex = 10000084;
            this.lsvCheckRoomSign.UseCompatibleStateImageBehavior = false;
            this.lsvCheckRoomSign.View = System.Windows.Forms.View.SmallIcon;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 55;
            // 
            // frmCheckRoom
            // 
            this.AccessibleDescription = "查房记录";
            this.CancelButton = this.m_cmdClose;
            this.ClientSize = new System.Drawing.Size(936, 565);
            this.Controls.Add(this.lsvCheckRoomSign);
            this.Controls.Add(this.lsvSign);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblReferralTitle);
            this.Controls.Add(this.lblCaseHistoryTitle);
            this.Controls.Add(this.lblCurrentDiagnoseTitle);
            this.Controls.Add(this.lblInHospitalCaseTitle);
            this.Controls.Add(this.m_cmdEmployeeSign);
            this.Controls.Add(this.m_cmdCheckDoctors);
            this.Controls.Add(this.m_txtPatientState);
            this.Controls.Add(this.cmdConfirm);
            this.Controls.Add(this.m_cmdClose);
            this.Controls.Add(this.m_txtNextCure);
            this.Controls.Add(this.m_txtCurrentCure);
            this.Controls.Add(this.m_txtDifferentiateDiagnose);
            this.Controls.Add(this.m_txtDiagnose);
            this.Name = "frmCheckRoom";
            this.Text = "查房记录";
            this.Load += new System.EventHandler(this.frmCheckRoom_Load);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_lblGetDataTime, 0);
            this.Controls.SetChildIndex(this.m_dtpGetDataTime, 0);
            this.Controls.SetChildIndex(this.m_txtDiagnose, 0);
            this.Controls.SetChildIndex(this.m_txtDifferentiateDiagnose, 0);
            this.Controls.SetChildIndex(this.m_txtCurrentCure, 0);
            this.Controls.SetChildIndex(this.m_txtNextCure, 0);
            this.Controls.SetChildIndex(this.m_cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdConfirm, 0);
            this.Controls.SetChildIndex(this.m_txtPatientState, 0);
            this.Controls.SetChildIndex(this.m_cmdCheckDoctors, 0);
            this.Controls.SetChildIndex(this.m_cmdEmployeeSign, 0);
            this.Controls.SetChildIndex(this.m_trvCreateDate, 0);
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
            this.Controls.SetChildIndex(this.lblInHospitalCaseTitle, 0);
            this.Controls.SetChildIndex(this.lblCurrentDiagnoseTitle, 0);
            this.Controls.SetChildIndex(this.lblCaseHistoryTitle, 0);
            this.Controls.SetChildIndex(this.lblReferralTitle, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.lsvSign, 0);
            this.Controls.SetChildIndex(this.lsvCheckRoomSign, 0);
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
			clsCheckRoomInfo objTrackInfo = new clsCheckRoomInfo();

			objTrackInfo.m_ObjRecordContent = m_objCurrentRecordContent;//m_objGetContentFromGUI();
			//设置m_strTitle和m_dtmRecordTime
			objTrackInfo.m_DtmRecordTime = m_dtpCreateDate.Value;
			objTrackInfo.m_StrTitle = "查房记录";			
			
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
			m_txtPatientState.m_mthClearText();
			m_txtDiagnose.m_mthClearText();
			m_txtDifferentiateDiagnose.m_mthClearText();
			m_txtCurrentCure.m_mthClearText();	
			m_txtNextCure.m_mthClearText();				
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
			int intCheckRoomDoctor=lsvCheckRoomSign.Items.Count;
            if (m_objCurrentPatient == null || m_ObjCurrentEmrPatientSession == null || intSignCount == 0)				
				return null;
			if (intCheckRoomDoctor==0)
			{
				clsPublicFunction.ShowInformationMessageBox("必须有查房医师");
				return null;

			}
			//从界面获取表单值
			clsCheckRoomRecordContent objContent=new clsCheckRoomRecordContent();

			//获取lsvsign签名
			objContent.objSignerArr=new clsEmrSigns_VO[intSignCount+intCheckRoomDoctor];
			strUserIDList="";
			strUserNameList="";
            m_mthGetSignArr(new Control[] { lsvSign, lsvCheckRoomSign }, ref objContent.objSignerArr, ref strUserIDList, ref strUserNameList);
			//获取正式签名
            //for (int i = 0; i < intSignCount; i++)
            //{
            //    objContent.objSignerArr[i]=new clsEmrSigns_VO();
            //    objContent.objSignerArr[i].objEmployee=new clsEmrEmployeeBase_VO();
            //    objContent.objSignerArr[i].objEmployee=(clsEmrEmployeeBase_VO)( lsvSign.Items[i].Tag);
            //    objContent.objSignerArr[i].controlName="lsvSign";
            //    objContent.objSignerArr[i].m_strFORMID_VCHR="frmCheckRoom";//注意大小写
            //    objContent.objSignerArr[i].m_strREGISTERID_CHR=com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;
            //    //痕迹格式 0972,0324,
            //    strUserIDList=strUserIDList+objContent.objSignerArr[i].objEmployee.m_strEMPID_CHR.Trim()+",";
            //    strUserNameList=strUserNameList+objContent.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR.Trim()+",";
			
            //}
            ////获取查房医师签名
            //for (int i = 0; i < intCheckRoomDoctor; i++)
            //{
            //    objContent.objSignerArr[intSignCount+i]=new clsEmrSigns_VO();
            //    objContent.objSignerArr[intSignCount+i].objEmployee=new clsEmrEmployeeBase_VO();
            //    objContent.objSignerArr[intSignCount+i].objEmployee=(clsEmrEmployeeBase_VO)( lsvCheckRoomSign.Items[i].Tag);
            //    objContent.objSignerArr[intSignCount+i].controlName="lsvCheckRoomSign";
            //    objContent.objSignerArr[intSignCount+i].m_strFORMID_VCHR="frmCheckRoom";//注意大小写
            //    objContent.objSignerArr[intSignCount+i].m_strREGISTERID_CHR=com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;
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
				
			objContent.m_strPatientState_Right=m_txtPatientState.m_strGetRightText();	
			objContent.m_strPatientState=m_txtPatientState.Text;
			objContent.m_strPatientStateXML=m_txtPatientState.m_strGetXmlText();					
			
			objContent.m_strDiagnose_Right=m_txtDiagnose.m_strGetRightText();	
			objContent.m_strDiagnose=m_txtDiagnose.Text;
			objContent.m_strDiagnoseXML=m_txtDiagnose.m_strGetXmlText();					
			
			objContent.m_strDifferentiateDiagnose_Right=m_txtDifferentiateDiagnose.m_strGetRightText();	
			objContent.m_strDifferentiateDiagnose=m_txtDifferentiateDiagnose.Text;
			objContent.m_strDifferentiateDiagnoseXML=m_txtDifferentiateDiagnose.m_strGetXmlText();					
			
			objContent.m_strCurrentCure_Right=m_txtCurrentCure.m_strGetRightText();	
			objContent.m_strCurrentCure=m_txtCurrentCure.Text;
			objContent.m_strCurrentCureXML=m_txtCurrentCure.m_strGetXmlText();

            //if (com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_StrCurrentHospitalNO == "450101001")
            //{
            //    objContent.m_strNextCure_Right = "";
            //    objContent.m_strNextCure = "";
            //    objContent.m_strNextCureXML = "";
            //}
            //else
            //{
                objContent.m_strNextCure_Right = m_txtNextCure.m_strGetRightText();
                objContent.m_strNextCure = m_txtNextCure.Text;
                objContent.m_strNextCureXML = m_txtNextCure.m_strGetXmlText();
            //}
 

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
			clsCheckRoomRecordContent objContent=(clsCheckRoomRecordContent)p_objContent;
			//把表单值赋值到界面，由子窗体重载实现
			m_txtPatientState.m_mthSetNewText(objContent.m_strPatientState,objContent.m_strPatientStateXML);		
			m_txtDiagnose.m_mthSetNewText(objContent.m_strDiagnose,objContent.m_strDiagnoseXML);		
			m_txtDifferentiateDiagnose.m_mthSetNewText(objContent.m_strDifferentiateDiagnose,objContent.m_strDifferentiateDiagnoseXML);		
			m_txtCurrentCure.m_mthSetNewText(objContent.m_strCurrentCure,objContent.m_strCurrentCureXML);		
			m_txtNextCure.m_mthSetNewText(objContent.m_strNextCure,objContent.m_strNextCureXML);

            //对于广西已填写下一步治疗的记录仍继续显示
            if (!string.IsNullOrEmpty(objContent.m_strNextCure) && !string.IsNullOrEmpty(objContent.m_strNextCureXML) && com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_StrCurrentHospitalNO == "450101001")
            {
                lblReferralTitle.Text = "当前治疗：";
                m_txtCurrentCure.Size = new Size(804, 93);

                m_txtNextCure.Visible = true;
                label2.Visible = true;
            }

			#region 签名集合
			if (objContent.objSignerArr!=null)
            {
                m_mthAddSignToListView(lsvSign, objContent.objSignerArr);
                m_mthAddSignToListView(lsvCheckRoomSign, objContent.objSignerArr);
				//正式签名
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
                ////查房医师
                //lsvCheckRoomSign.Items.Clear();
                //for (int i = 0; i < objContent.objSignerArr.Length; i++)
                //{
                //    if (objContent.objSignerArr[i].controlName=="lsvCheckRoomSign")
                //    {
                //        ListViewItem lviNewItem=new 						 ListViewItem(objContent.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR);
                //        //ID 检查重复用
                //        lviNewItem.SubItems.Add(objContent.objSignerArr[i].objEmployee.m_strEMPID_CHR);
                //        //级别 排序用
                //        lviNewItem.SubItems.Add(objContent.objSignerArr[i].objEmployee.m_strLEVEL_CHR);
                //        //tag均为对象
                //        lviNewItem.Tag=objContent.objSignerArr[i].objEmployee;
                //        //是按顺序保存故获取顺序也一样
                //        lsvCheckRoomSign.Items.Add(lviNewItem);
                //    }
                //}
			}
			
			#endregion 签名	

		}

		public override int m_IntFormID
		{
			get
			{
				return 11;
			}
		}

		protected override void m_mthSetDeletedGUIFromContent(clsTrackRecordContent p_objContent)
		{
			if(p_objContent ==null)
				return;
			clsCheckRoomRecordContent objContent=(clsCheckRoomRecordContent)p_objContent;
			//把表单值赋值到界面，由子窗体重载实现
			m_txtPatientState.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strPatientState,objContent.m_strPatientStateXML);		
			m_txtDiagnose.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDiagnose,objContent.m_strDiagnoseXML);		
			m_txtDifferentiateDiagnose.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDifferentiateDiagnose,objContent.m_strDifferentiateDiagnoseXML);		
			m_txtCurrentCure.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strCurrentCure,objContent.m_strCurrentCureXML);		
			m_txtNextCure.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strNextCure,objContent.m_strNextCureXML);			
//			m_txtCheckDoctors.Text = objContent.m_strCheckRoomDoctorsList;
//			m_txtCheckDoctors.Tag = objContent.m_strCheckDoctor_ID;

            //对于广西已填写下一步治疗的记录仍继续显示
            if (!string.IsNullOrEmpty(objContent.m_strNextCure) && !string.IsNullOrEmpty(objContent.m_strNextCureXML) && com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_StrCurrentHospitalNO == "450101001")
            {
                lblReferralTitle.Text = "当前治疗：";
                m_txtCurrentCure.Size = new Size(804, 93);

                m_txtNextCure.Visible = true;
                label2.Visible = true;
            }

            if (objContent.objSignerArr != null)
            {
                m_mthAddSignToListView(lsvSign, objContent.objSignerArr);
                m_mthAddSignToListView(lsvCheckRoomSign, objContent.objSignerArr);
            }
			
		}

		/// <summary>
		/// 获取病程记录的领域层实例
		/// </summary>
		/// <returns></returns>
		protected override clsDiseaseTrackDomain m_objGetDiseaseTrackDomain()
		{
			//获取病程记录的领域层实例
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.CheckRoom);					
		}

		/// <summary>
		/// 把选择时间记录内容重新整理为完全正确的内容。
		/// </summary>
		/// <param name="p_objRecordContent"></param>
		protected override void m_mthReAddNewRecord(clsTrackRecordContent p_objRecordContent)
		{
			//把选择时间记录内容重新整理为完全正确的内容，由子窗体重载实现。
			clsCheckRoomRecordContent objContent=(clsCheckRoomRecordContent)p_objRecordContent;
			//把表单值赋值到界面，由子窗体重载实现
			m_txtPatientState.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strPatientState,objContent.m_strPatientStateXML);		
			m_txtDiagnose.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDiagnose,objContent.m_strDiagnoseXML);		
			m_txtDifferentiateDiagnose.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDifferentiateDiagnose,objContent.m_strDifferentiateDiagnoseXML);		
			m_txtCurrentCure.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strCurrentCure,objContent.m_strCurrentCureXML);		
			m_txtNextCure.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strNextCure,objContent.m_strNextCureXML);				
		}		

		// 获取选择已经删除记录的窗体标题
		public override string m_strReloadFormTitle()
		{
			//由子窗体重载实现
			return	"查房记录";
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

		private void frmCheckRoom_Load(object sender, System.EventArgs e)
		{

			this.m_dtpCreateDate.m_EnmVisibleFlag=MDIParent.s_ObjRecordDateTimeInfo.m_enmGetRecordTimeFlag(this.Name);
			this.m_dtpCreateDate.m_mthResetSize();

			m_txtPatientState.Focus();
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
//			clsInPatientCaseHisoryDefaultValue [] objInPatientCaseDefaultValue = new clsInPatientCaseHisoryDefaultDomain().lngGetAllInPatientCaseHisoryDefault(p_objSelectedPatient.m_StrInPatientID,p_objSelectedPatient.m_DtmLastInDate.ToString());
//			if(objInPatientCaseDefaultValue !=null && objInPatientCaseDefaultValue.Length >0)
//			{
//				this.m_txtDiagnose.Text=objInPatientCaseDefaultValue[0].m_strPrimaryDiagnose;
//			}
		}

	

	}
}

