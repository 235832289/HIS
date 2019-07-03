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
using com.digitalwave.Emr.Signature_gui;


namespace iCare
{
	/// <summary>
	/// 阶段小结
	/// </summary>
	public class frmDiseaseSummary : iCare.frmDiseaseTrackBase
	{
		private System.Windows.Forms.Label lblReferralTitle;
		private System.Windows.Forms.Label lblCaseHistoryTitle;
		private System.Windows.Forms.Label lblInHospitalCaseTitle;
		private PinkieControls.ButtonXP cmdConfirm;
		private com.digitalwave.controls.ctlRichTextBox m_txtCurrentCase;
		private com.digitalwave.controls.ctlRichTextBox m_txtDiagnoseBy;
		private com.digitalwave.controls.ctlRichTextBox m_txtInHospitalDiagnose;
		private com.digitalwave.controls.ctlRichTextBox m_txtInHospitalCase;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private com.digitalwave.controls.ctlRichTextBox m_txtReferral;
		private com.digitalwave.controls.ctlRichTextBox m_txtCurrentDiagnose;
		private System.Windows.Forms.Label label8;
		private PinkieControls.ButtonXP m_cmdClose;
		private System.ComponentModel.IContainer components = null;
		private PinkieControls.ButtonXP m_cmdEmployeeSign;
		private clsCommonUseToolCollection m_objCUTC;
		private System.Windows.Forms.ListView lsvSign;
		private  clsEmployeeSignTool m_objSignTool;
		private System.Windows.Forms.ColumnHeader columnHeader1;

		//定义签名类
		private clsEmrSignToolCollection m_objSign;


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
            this.lblReferralTitle = new System.Windows.Forms.Label();
            this.lblCaseHistoryTitle = new System.Windows.Forms.Label();
            this.lblInHospitalCaseTitle = new System.Windows.Forms.Label();
            this.m_txtCurrentCase = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtDiagnoseBy = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtInHospitalDiagnose = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtInHospitalCase = new com.digitalwave.controls.ctlRichTextBox();
            this.cmdConfirm = new PinkieControls.ButtonXP();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtReferral = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtCurrentDiagnose = new com.digitalwave.controls.ctlRichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.m_cmdClose = new PinkieControls.ButtonXP();
            this.m_cmdEmployeeSign = new PinkieControls.ButtonXP();
            this.lsvSign = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.m_pnlNewBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_trvCreateDate
            // 
            this.m_trvCreateDate.LineColor = System.Drawing.Color.Black;
            this.m_trvCreateDate.Location = new System.Drawing.Point(287, -104);
            this.m_trvCreateDate.Size = new System.Drawing.Size(212, 72);
            this.m_trvCreateDate.Visible = false;
            // 
            // lblCreateDateTitle
            // 
            this.lblCreateDateTitle.Location = new System.Drawing.Point(16, 30);
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.Location = new System.Drawing.Point(104, 30);
            // 
            // m_dtpGetDataTime
            // 
            this.m_dtpGetDataTime.Location = new System.Drawing.Point(421, -53);
            // 
            // m_lblGetDataTime
            // 
            this.m_lblGetDataTime.Location = new System.Drawing.Point(379, -74);
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(603, -35);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(639, -35);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(609, -70);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(603, -38);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(569, -41);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(609, -35);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(617, -38);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(544, -61);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(750, -102);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(470, -78);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(587, -41);
            this.m_txtPatientName.Size = new System.Drawing.Size(88, 23);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(559, -64);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(600, -65);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(603, -88);
            this.m_lsvPatientName.Size = new System.Drawing.Size(88, 104);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(620, -100);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(79, -60);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(31, -52);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(14, 497);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.Location = new System.Drawing.Point(195, -88);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(155, -88);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(271, -84);
            this.m_lblForTitle.Text = "阶 段 小 结";
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(12, 504);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(606, -100);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Location = new System.Drawing.Point(9, -93);
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            // 
            // lblReferralTitle
            // 
            this.lblReferralTitle.AutoSize = true;
            this.lblReferralTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblReferralTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblReferralTitle.ForeColor = System.Drawing.Color.Black;
            this.lblReferralTitle.Location = new System.Drawing.Point(16, 274);
            this.lblReferralTitle.Name = "lblReferralTitle";
            this.lblReferralTitle.Size = new System.Drawing.Size(70, 14);
            this.lblReferralTitle.TabIndex = 6106;
            this.lblReferralTitle.Text = "目前情况:";
            // 
            // lblCaseHistoryTitle
            // 
            this.lblCaseHistoryTitle.AutoSize = true;
            this.lblCaseHistoryTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblCaseHistoryTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCaseHistoryTitle.ForeColor = System.Drawing.Color.Black;
            this.lblCaseHistoryTitle.Location = new System.Drawing.Point(16, 202);
            this.lblCaseHistoryTitle.Name = "lblCaseHistoryTitle";
            this.lblCaseHistoryTitle.Size = new System.Drawing.Size(70, 14);
            this.lblCaseHistoryTitle.TabIndex = 6104;
            this.lblCaseHistoryTitle.Text = "诊疗经过:";
            // 
            // lblInHospitalCaseTitle
            // 
            this.lblInHospitalCaseTitle.AccessibleDescription = "";
            this.lblInHospitalCaseTitle.AutoSize = true;
            this.lblInHospitalCaseTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblInHospitalCaseTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInHospitalCaseTitle.ForeColor = System.Drawing.Color.Black;
            this.lblInHospitalCaseTitle.Location = new System.Drawing.Point(16, 58);
            this.lblInHospitalCaseTitle.Name = "lblInHospitalCaseTitle";
            this.lblInHospitalCaseTitle.Size = new System.Drawing.Size(70, 14);
            this.lblInHospitalCaseTitle.TabIndex = 6100;
            this.lblInHospitalCaseTitle.Text = "入院情况:";
            // 
            // m_txtCurrentCase
            // 
            this.m_txtCurrentCase.AccessibleDescription = "目前情况";
            this.m_txtCurrentCase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtCurrentCase.BackColor = System.Drawing.Color.White;
            this.m_txtCurrentCase.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCurrentCase.ForeColor = System.Drawing.Color.Black;
            this.m_txtCurrentCase.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCurrentCase.Location = new System.Drawing.Point(104, 274);
            this.m_txtCurrentCase.m_BlnIgnoreUserInfo = false;
            this.m_txtCurrentCase.m_BlnPartControl = false;
            this.m_txtCurrentCase.m_BlnReadOnly = false;
            this.m_txtCurrentCase.m_BlnUnderLineDST = false;
            this.m_txtCurrentCase.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtCurrentCase.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtCurrentCase.m_IntCanModifyTime = 6;
            this.m_txtCurrentCase.m_IntPartControlLength = 0;
            this.m_txtCurrentCase.m_IntPartControlStartIndex = 0;
            this.m_txtCurrentCase.m_StrUserID = "";
            this.m_txtCurrentCase.m_StrUserName = "";
            this.m_txtCurrentCase.Name = "m_txtCurrentCase";
            this.m_txtCurrentCase.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtCurrentCase.Size = new System.Drawing.Size(753, 64);
            this.m_txtCurrentCase.TabIndex = 130;
            this.m_txtCurrentCase.Text = "";
            // 
            // m_txtDiagnoseBy
            // 
            this.m_txtDiagnoseBy.AccessibleDescription = "诊疗经过";
            this.m_txtDiagnoseBy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtDiagnoseBy.BackColor = System.Drawing.Color.White;
            this.m_txtDiagnoseBy.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDiagnoseBy.ForeColor = System.Drawing.Color.Black;
            this.m_txtDiagnoseBy.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDiagnoseBy.Location = new System.Drawing.Point(104, 202);
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
            this.m_txtDiagnoseBy.Size = new System.Drawing.Size(753, 64);
            this.m_txtDiagnoseBy.TabIndex = 120;
            this.m_txtDiagnoseBy.Text = "";
            // 
            // m_txtInHospitalDiagnose
            // 
            this.m_txtInHospitalDiagnose.AccessibleDescription = "入院诊断";
            this.m_txtInHospitalDiagnose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtInHospitalDiagnose.BackColor = System.Drawing.Color.White;
            this.m_txtInHospitalDiagnose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtInHospitalDiagnose.ForeColor = System.Drawing.Color.Black;
            this.m_txtInHospitalDiagnose.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtInHospitalDiagnose.Location = new System.Drawing.Point(104, 130);
            this.m_txtInHospitalDiagnose.m_BlnIgnoreUserInfo = false;
            this.m_txtInHospitalDiagnose.m_BlnPartControl = false;
            this.m_txtInHospitalDiagnose.m_BlnReadOnly = false;
            this.m_txtInHospitalDiagnose.m_BlnUnderLineDST = false;
            this.m_txtInHospitalDiagnose.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtInHospitalDiagnose.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtInHospitalDiagnose.m_IntCanModifyTime = 6;
            this.m_txtInHospitalDiagnose.m_IntPartControlLength = 0;
            this.m_txtInHospitalDiagnose.m_IntPartControlStartIndex = 0;
            this.m_txtInHospitalDiagnose.m_StrUserID = "";
            this.m_txtInHospitalDiagnose.m_StrUserName = "";
            this.m_txtInHospitalDiagnose.Name = "m_txtInHospitalDiagnose";
            this.m_txtInHospitalDiagnose.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtInHospitalDiagnose.Size = new System.Drawing.Size(753, 64);
            this.m_txtInHospitalDiagnose.TabIndex = 110;
            this.m_txtInHospitalDiagnose.Text = "";
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
            this.m_txtInHospitalCase.Location = new System.Drawing.Point(104, 58);
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
            this.m_txtInHospitalCase.Size = new System.Drawing.Size(753, 64);
            this.m_txtInHospitalCase.TabIndex = 100;
            this.m_txtInHospitalCase.Text = "";
            // 
            // cmdConfirm
            // 
            this.cmdConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.cmdConfirm.DefaultScheme = true;
            this.cmdConfirm.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdConfirm.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdConfirm.Hint = "";
            this.cmdConfirm.Location = new System.Drawing.Point(685, 515);
            this.cmdConfirm.Name = "cmdConfirm";
            this.cmdConfirm.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdConfirm.Size = new System.Drawing.Size(80, 30);
            this.cmdConfirm.TabIndex = 200;
            this.cmdConfirm.Text = "确定";
            this.cmdConfirm.Click += new System.EventHandler(this.cmdConfirm_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(15, 418);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 6112;
            this.label1.Text = "诊疗计划:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(16, 354);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 6110;
            this.label2.Text = "目前诊断:";
            // 
            // m_txtReferral
            // 
            this.m_txtReferral.AccessibleDescription = "诊疗计划";
            this.m_txtReferral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtReferral.BackColor = System.Drawing.Color.White;
            this.m_txtReferral.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtReferral.ForeColor = System.Drawing.Color.Black;
            this.m_txtReferral.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtReferral.Location = new System.Drawing.Point(104, 418);
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
            this.m_txtReferral.Size = new System.Drawing.Size(753, 93);
            this.m_txtReferral.TabIndex = 150;
            this.m_txtReferral.Text = "";
            // 
            // m_txtCurrentDiagnose
            // 
            this.m_txtCurrentDiagnose.AccessibleDescription = "目前诊断";
            this.m_txtCurrentDiagnose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtCurrentDiagnose.BackColor = System.Drawing.Color.White;
            this.m_txtCurrentDiagnose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCurrentDiagnose.ForeColor = System.Drawing.Color.Black;
            this.m_txtCurrentDiagnose.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCurrentDiagnose.Location = new System.Drawing.Point(104, 346);
            this.m_txtCurrentDiagnose.m_BlnIgnoreUserInfo = false;
            this.m_txtCurrentDiagnose.m_BlnPartControl = false;
            this.m_txtCurrentDiagnose.m_BlnReadOnly = false;
            this.m_txtCurrentDiagnose.m_BlnUnderLineDST = false;
            this.m_txtCurrentDiagnose.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtCurrentDiagnose.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtCurrentDiagnose.m_IntCanModifyTime = 6;
            this.m_txtCurrentDiagnose.m_IntPartControlLength = 0;
            this.m_txtCurrentDiagnose.m_IntPartControlStartIndex = 0;
            this.m_txtCurrentDiagnose.m_StrUserID = "";
            this.m_txtCurrentDiagnose.m_StrUserName = "";
            this.m_txtCurrentDiagnose.Name = "m_txtCurrentDiagnose";
            this.m_txtCurrentDiagnose.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtCurrentDiagnose.Size = new System.Drawing.Size(753, 64);
            this.m_txtCurrentDiagnose.TabIndex = 140;
            this.m_txtCurrentDiagnose.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(16, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 14);
            this.label8.TabIndex = 6102;
            this.label8.Text = "入院诊断:";
            // 
            // m_cmdClose
            // 
            this.m_cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdClose.DefaultScheme = true;
            this.m_cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdClose.Hint = "";
            this.m_cmdClose.Location = new System.Drawing.Point(777, 515);
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
            this.m_cmdEmployeeSign.Location = new System.Drawing.Point(104, 517);
            this.m_cmdEmployeeSign.Name = "m_cmdEmployeeSign";
            this.m_cmdEmployeeSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdEmployeeSign.Size = new System.Drawing.Size(76, 30);
            this.m_cmdEmployeeSign.TabIndex = 10000040;
            this.m_cmdEmployeeSign.Tag = "1";
            this.m_cmdEmployeeSign.Text = "签名:";
            // 
            // lsvSign
            // 
            this.lsvSign.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.lsvSign.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvSign.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lsvSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvSign.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lsvSign.Location = new System.Drawing.Point(184, 517);
            this.lsvSign.MultiSelect = false;
            this.lsvSign.Name = "lsvSign";
            this.lsvSign.Size = new System.Drawing.Size(495, 28);
            this.lsvSign.TabIndex = 10000041;
            this.lsvSign.UseCompatibleStateImageBehavior = false;
            this.lsvSign.View = System.Windows.Forms.View.SmallIcon;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 50;
            // 
            // frmDiseaseSummary
            // 
            this.AccessibleDescription = "阶段小结";
            this.CancelButton = this.m_cmdClose;
            this.ClientSize = new System.Drawing.Size(876, 567);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblReferralTitle);
            this.Controls.Add(this.lblCaseHistoryTitle);
            this.Controls.Add(this.lblInHospitalCaseTitle);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.m_txtReferral);
            this.Controls.Add(this.m_txtCurrentDiagnose);
            this.Controls.Add(this.lsvSign);
            this.Controls.Add(this.m_cmdEmployeeSign);
            this.Controls.Add(this.m_txtCurrentCase);
            this.Controls.Add(this.m_txtDiagnoseBy);
            this.Controls.Add(this.m_txtInHospitalDiagnose);
            this.Controls.Add(this.m_txtInHospitalCase);
            this.Controls.Add(this.cmdConfirm);
            this.Controls.Add(this.m_cmdClose);
            this.Name = "frmDiseaseSummary";
            this.Text = "阶段小结";
            this.Load += new System.EventHandler(this.frmDiseaseSummary_Load);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_cmdClose, 0);
            this.Controls.SetChildIndex(this.cmdConfirm, 0);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.m_txtInHospitalCase, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.m_txtInHospitalDiagnose, 0);
            this.Controls.SetChildIndex(this.m_txtDiagnoseBy, 0);
            this.Controls.SetChildIndex(this.m_txtCurrentCase, 0);
            this.Controls.SetChildIndex(this.m_dtpGetDataTime, 0);
            this.Controls.SetChildIndex(this.m_cmdEmployeeSign, 0);
            this.Controls.SetChildIndex(this.m_lblGetDataTime, 0);
            this.Controls.SetChildIndex(this.m_dtpCreateDate, 0);
            this.Controls.SetChildIndex(this.lblCreateDateTitle, 0);
            this.Controls.SetChildIndex(this.m_trvCreateDate, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.lsvSign, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.m_txtCurrentDiagnose, 0);
            this.Controls.SetChildIndex(this.m_txtReferral, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.lblInHospitalCaseTitle, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.lblCaseHistoryTitle, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.lblReferralTitle, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region 构造函数
			/// <summary>
			/// 构造函数
			/// </summary>
			public frmDiseaseSummary()
			{
				// This call is required by the Windows Form Designer.
				InitializeComponent();

				// TODO: Add any initiaization after the InitializeComponent call
                //指明医生工作站表单
                intFormType = 1;
 
				cmdConfirm.Visible=false;
				
				m_mthSetRichTextBoxAttribInControl(this);

 
				//签名常用值
//				m_objCUTC = new clsCommonUseToolCollection(this);
//				m_objCUTC.m_mthBindEmployeeSign(new Control[]{m_cmdEmployeeSign  },
//					new Control[]{this.m_txtSign },new int[]{1});
				m_objSign = new clsEmrSignToolCollection();
				//m_mthBindEmployeeSign(按钮,签名框,医生1or护士2,身份验证trueorfalse);
                m_objSign.m_mthBindEmployeeSign(m_cmdEmployeeSign, lsvSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);


			}
			#endregion


		/// <summary>
		/// 获取当前的特殊病程记录信息
		/// </summary>
		/// <returns></returns>
		public override clsDiseaseTrackInfo m_objGetDiseaseTrackInfo()
		{
			clsDiseaseSummaryInfo objTrackInfo = new clsDiseaseSummaryInfo();

			objTrackInfo.m_ObjRecordContent = m_objCurrentRecordContent;//m_objGetContentFromGUI();
			objTrackInfo.m_DtmRecordTime = m_dtpCreateDate.Value;
			objTrackInfo.m_StrTitle = "阶段小结记录";			

			//设置m_strTitle和m_dtmRecordTime
			if(objTrackInfo.m_ObjRecordContent !=null)
			{
				m_dtpCreateDate.Value=objTrackInfo.m_ObjRecordContent.m_dtmCreateDate;
			}
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
			m_txtInHospitalDiagnose.m_mthClearText();
			m_txtDiagnoseBy.m_mthClearText();
			m_txtCurrentCase.m_mthClearText();		
			m_txtCurrentDiagnose.m_mthClearText();		
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
                //    if(control.Name!="m_dtpCreateDate")
                //        control.Top=control.Top-105;				
                //}
			
				cmdConfirm.Visible=true;
				
				//this.Size=new Size(this.Size.Width, this.Size.Height-105);
				this.CenterToParent();	
		
                //lblCreateDateTitle.Left=lblInHospitalCaseTitle.Left;//=16;
                //lblCreateDateTitle.Top=15;	
                //m_dtpCreateDate.Left=lblCreateDateTitle.Right+5;
                //m_dtpCreateDate.Top=lblCreateDateTitle.Top;				
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

		#region 从界面获取特殊记录的值。如果界面值出错，返回null。
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
			clsDiseaseSummaryRecordContent objContent=new clsDiseaseSummaryRecordContent();

			//获取lsvsign签名
			objContent.objSignerArr=new clsEmrSigns_VO[intSignCount];
			strUserIDList="";
			strUserNameList="";
            m_mthGetSignArr(new Control[] { lsvSign}, ref objContent.objSignerArr, ref strUserIDList, ref strUserNameList);
            //for (int i = 0; i < intSignCount; i++)
            //{
            //    objContent.objSignerArr[i]=new clsEmrSigns_VO();
            //    objContent.objSignerArr[i].objEmployee=new clsEmrEmployeeBase_VO();
            //    objContent.objSignerArr[i].objEmployee=(clsEmrEmployeeBase_VO)( lsvSign.Items[i].Tag);
            //    objContent.objSignerArr[i].controlName="lsvSign";
            //    objContent.objSignerArr[i].m_strFORMID_VCHR="frmdiseasesummary";
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
				
			objContent.m_strInHospitalCase_Right=m_txtInHospitalCase.m_strGetRightText();	
			objContent.m_strInHospitalCase=m_txtInHospitalCase.Text;
			objContent.m_strInHospitalCaseXML=m_txtInHospitalCase.m_strGetXmlText();					
			
			objContent.m_strInHospitalDiagnose_Right=m_txtInHospitalDiagnose.m_strGetRightText();	
			objContent.m_strInHospitalDiagnose=m_txtInHospitalDiagnose.Text;
			objContent.m_strInHospitalDiagnoseXML=m_txtInHospitalDiagnose.m_strGetXmlText();					
			
			objContent.m_strDiagnoseBy_Right=m_txtDiagnoseBy.m_strGetRightText();	
			objContent.m_strDiagnoseBy=m_txtDiagnoseBy.Text;
			objContent.m_strDiagnoseByXML=m_txtDiagnoseBy.m_strGetXmlText();					
			
			objContent.m_strCurrentCase_Right=m_txtCurrentCase.m_strGetRightText();	
			objContent.m_strCurrentCase=m_txtCurrentCase.Text;
			objContent.m_strCurrentCaseXML=m_txtCurrentCase.m_strGetXmlText();	
		
			objContent.m_strCurrentDiagnose_Right=m_txtCurrentDiagnose.m_strGetRightText();	
			objContent.m_strCurrentDiagnose=m_txtCurrentDiagnose.Text;
			objContent.m_strCurrentDiagnoseXML=m_txtCurrentDiagnose.m_strGetXmlText();					
			
			objContent.m_strReferral_Right=m_txtReferral.m_strGetRightText();	
			objContent.m_strReferral=m_txtReferral.Text;
			objContent.m_strReferralXML=m_txtReferral.m_strGetXmlText();
	
			
			return objContent;	
		}
		#endregion

		#region 把特殊记录的值显示到界面上
		/// <summary>
		/// 把特殊记录的值显示到界面上。
		/// </summary>
		/// <param name="p_objContent"></param>
		protected override void m_mthSetGUIFromContent(clsTrackRecordContent p_objContent)
		{
			if(p_objContent ==null)
				return;
			clsDiseaseSummaryRecordContent objContent=(clsDiseaseSummaryRecordContent)p_objContent;
			//把表单值赋值到界面，由子窗体重载实现

			m_txtInHospitalCase.m_mthSetNewText(objContent.m_strInHospitalCase,objContent.m_strInHospitalCaseXML);		
			m_txtInHospitalDiagnose.m_mthSetNewText(objContent.m_strInHospitalDiagnose,objContent.m_strInHospitalDiagnoseXML);		
			m_txtDiagnoseBy.m_mthSetNewText(objContent.m_strDiagnoseBy,objContent.m_strDiagnoseByXML);		
			m_txtCurrentCase.m_mthSetNewText(objContent.m_strCurrentCase,objContent.m_strCurrentCaseXML);	
			m_txtCurrentDiagnose.m_mthSetNewText(objContent.m_strCurrentDiagnose,objContent.m_strCurrentDiagnoseXML);		
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
                //        ListViewItem lviNewItem=new ListViewItem(objContent.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR);
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
		#endregion


		public override int m_IntFormID
		{
			get
			{
				return 9;
			}
		}

		protected override void m_mthSetDeletedGUIFromContent(clsTrackRecordContent p_objContent)
		{
			if(p_objContent ==null)
				return;
			clsDiseaseSummaryRecordContent objContent=(clsDiseaseSummaryRecordContent)p_objContent;
			//把表单值赋值到界面，由子窗体重载实现

			m_txtInHospitalCase.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strInHospitalCase,objContent.m_strInHospitalCaseXML);		
			m_txtInHospitalDiagnose.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strInHospitalDiagnose,objContent.m_strInHospitalDiagnoseXML);		
			m_txtDiagnoseBy.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDiagnoseBy,objContent.m_strDiagnoseByXML);		
			m_txtCurrentCase.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strCurrentCase,objContent.m_strCurrentCaseXML);	
			m_txtCurrentDiagnose.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strCurrentDiagnose,objContent.m_strCurrentDiagnoseXML);		
			m_txtReferral.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strReferral,objContent.m_strReferralXML);

            if (objContent.objSignerArr != null)
            {
                m_mthAddSignToListView(lsvSign, objContent.objSignerArr);
            }
		}

		/// <summary>
		/// 获取病程记录的领域层实例
		/// </summary>
		/// <returns></returns>
		protected override clsDiseaseTrackDomain m_objGetDiseaseTrackDomain()
		{
			//获取病程记录的领域层实例
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.DiseaseSummary);					
		}

		/// <summary>
		/// 把选择时间记录内容重新整理为完全正确的内容。
		/// </summary>
		/// <param name="p_objRecordContent"></param>
		protected override void m_mthReAddNewRecord(clsTrackRecordContent p_objRecordContent)
		{
			//把选择时间记录内容重新整理为完全正确的内容，由子窗体重载实现。
			clsDiseaseSummaryRecordContent objContent=(clsDiseaseSummaryRecordContent)p_objRecordContent;
			//把表单值赋值到界面，由子窗体重载实现
			m_txtInHospitalCase.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strInHospitalCase,objContent.m_strInHospitalCaseXML);		
			m_txtInHospitalDiagnose.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strInHospitalDiagnose,objContent.m_strInHospitalDiagnoseXML);		
			m_txtDiagnoseBy.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDiagnoseBy,objContent.m_strDiagnoseByXML);		
			m_txtCurrentCase.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strCurrentCase,objContent.m_strCurrentCaseXML);	
			m_txtCurrentDiagnose.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strCurrentDiagnose,objContent.m_strCurrentDiagnoseXML);		
			m_txtReferral.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strReferral,objContent.m_strReferralXML);	
			
		}
		

		// 获取选择已经删除记录的窗体标题
		public override string m_strReloadFormTitle()
		{
			//由子窗体重载实现
			return	"阶段小结";
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

		private void m_cmdClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void frmDiseaseSummary_Load(object sender, System.EventArgs e)
		{
//			m_cmdNewTemplate.Visible = true;
			this.m_dtpCreateDate.m_EnmVisibleFlag=MDIParent.s_ObjRecordDateTimeInfo.m_enmGetRecordTimeFlag(this.Name);
			this.m_dtpCreateDate.m_mthResetSize();

			m_txtInHospitalCase.Focus();
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
//				this.m_txtInHospitalDiagnose.Text=objInPatientCaseDefaultValue[0].m_strPrimaryDiagnose;
//				this.m_txtCurrentDiagnose.Text=objInPatientCaseDefaultValue[0].m_strPrimaryDiagnose;
//			}
		}


	}
}

