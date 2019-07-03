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

namespace iCare
{
	/// <summary>
	/// frmFirstIllnessNote 的摘要说明。
	/// </summary>
	public class frmFirstIllnessNote_ZY : iCare.frmDiseaseTrackBase
	{
		private System.Windows.Forms.Label lblSignTitle;
		private System.Windows.Forms.Label lblReferralTitle;
		private System.Windows.Forms.Label lblCaseHistoryTitle;
		private System.Windows.Forms.Label label8;
		protected System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtSign;
		private System.Windows.Forms.Label m_lblSign;
		private com.digitalwave.controls.ctlRichTextBox m_txtCurePlan;
		private com.digitalwave.controls.ctlRichTextBox m_txtDiagnoseDiffe;
		private com.digitalwave.controls.ctlRichTextBox m_txtDiagnoseThe;
		private com.digitalwave.controls.ctlRichTextBox m_txtOriginalDiagnose;
		private com.digitalwave.controls.ctlRichTextBox m_txtMostlyContent;
		private PinkieControls.ButtonXP m_cmdClose;
		private PinkieControls.ButtonXP cmdConfirm;
		private PinkieControls.ButtonXP m_cmdEmployeeSign;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblInHospitalCaseTitle;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		/// 
		private clsEmployeeSignTool m_objSignTool;
		private clsCommonUseToolCollection m_objCUTC;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private com.digitalwave.controls.ctlRichTextBox m_txtIdentifyDiagnos;
		private com.digitalwave.controls.ctlRichTextBox m_txtIdentifyReston;
		private System.ComponentModel.Container components = null;

		public frmFirstIllnessNote_ZY()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
            //指明医生工作站表单
            intFormType = 1;
			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			m_objSignTool = new clsEmployeeSignTool(listView1);
			m_objSignTool.m_mthAddControl(m_txtSign);
			cmdConfirm.Visible=false;
			
			m_mthSetRichTextBoxAttribInControl(this);

			m_lblSign.Text=MDIParent.OperatorName;

			//签名常用值
			m_objCUTC = new clsCommonUseToolCollection(this);
			m_objCUTC.m_mthBindEmployeeSign(new Control[]{m_cmdEmployeeSign  },
				new Control[]{this.m_txtSign },new int[]{1});

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
            this.lblSignTitle = new System.Windows.Forms.Label();
            this.lblReferralTitle = new System.Windows.Forms.Label();
            this.lblCaseHistoryTitle = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.m_txtSign = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_lblSign = new System.Windows.Forms.Label();
            this.m_txtCurePlan = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtDiagnoseDiffe = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtDiagnoseThe = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtOriginalDiagnose = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtMostlyContent = new com.digitalwave.controls.ctlRichTextBox();
            this.m_cmdClose = new PinkieControls.ButtonXP();
            this.cmdConfirm = new PinkieControls.ButtonXP();
            this.m_cmdEmployeeSign = new PinkieControls.ButtonXP();
            this.label1 = new System.Windows.Forms.Label();
            this.lblInHospitalCaseTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtIdentifyDiagnos = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtIdentifyReston = new com.digitalwave.controls.ctlRichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_pnlNewBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_trvCreateDate
            // 
            this.m_trvCreateDate.LineColor = System.Drawing.Color.Black;
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(528, 56);
            this.lblSex.Size = new System.Drawing.Size(56, 21);
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(648, 56);
            this.lblAge.Size = new System.Drawing.Size(60, 21);
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(275, 18);
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(261, 55);
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(476, 18);
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(472, 56);
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(592, 56);
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(8, 48);
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(327, 78);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(135, 119);
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(327, 50);
            this.txtInPatientID.Size = new System.Drawing.Size(135, 23);
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(527, 14);
            this.m_txtPatientName.Size = new System.Drawing.Size(136, 23);
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(327, 14);
            this.m_txtBedNO.Size = new System.Drawing.Size(135, 23);
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(64, 48);
            this.m_cboArea.Size = new System.Drawing.Size(168, 23);
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(527, 41);
            this.m_lsvPatientName.Size = new System.Drawing.Size(136, 119);
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(327, 38);
            this.m_lsvBedNO.Size = new System.Drawing.Size(135, 119);
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(64, 8);
            this.m_cboDept.Size = new System.Drawing.Size(168, 23);
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(8, 16);
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(821, 55);
            this.m_cmdNewTemplate.Size = new System.Drawing.Size(98, 36);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.Location = new System.Drawing.Point(229, 14);
            this.m_cmdNext.Size = new System.Drawing.Size(28, 24);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(182, 14);
            this.m_cmdPre.Size = new System.Drawing.Size(28, 24);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(317, 18);
            this.m_lblForTitle.Size = new System.Drawing.Size(19, 27);
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            // 
            // lblSignTitle
            // 
            this.lblSignTitle.AutoSize = true;
            this.lblSignTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblSignTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSignTitle.ForeColor = System.Drawing.Color.Black;
            this.lblSignTitle.Location = new System.Drawing.Point(208, 716);
            this.lblSignTitle.Name = "lblSignTitle";
            this.lblSignTitle.Size = new System.Drawing.Size(42, 14);
            this.lblSignTitle.TabIndex = 10000061;
            this.lblSignTitle.Text = "签名:";
            this.lblSignTitle.Visible = false;
            // 
            // lblReferralTitle
            // 
            this.lblReferralTitle.AutoSize = true;
            this.lblReferralTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblReferralTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblReferralTitle.ForeColor = System.Drawing.Color.Black;
            this.lblReferralTitle.Location = new System.Drawing.Point(4, 600);
            this.lblReferralTitle.Name = "lblReferralTitle";
            this.lblReferralTitle.Size = new System.Drawing.Size(98, 14);
            this.lblReferralTitle.TabIndex = 10000056;
            this.lblReferralTitle.Text = "西医鉴别诊断:";
            // 
            // lblCaseHistoryTitle
            // 
            this.lblCaseHistoryTitle.AutoSize = true;
            this.lblCaseHistoryTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblCaseHistoryTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCaseHistoryTitle.ForeColor = System.Drawing.Color.Black;
            this.lblCaseHistoryTitle.Location = new System.Drawing.Point(4, 496);
            this.lblCaseHistoryTitle.Name = "lblCaseHistoryTitle";
            this.lblCaseHistoryTitle.Size = new System.Drawing.Size(98, 14);
            this.lblCaseHistoryTitle.TabIndex = 10000055;
            this.lblCaseHistoryTitle.Text = "西医诊断依据:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(8, 368);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 14);
            this.label8.TabIndex = 10000054;
            this.label8.Text = "初步诊断:";
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.White;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader7});
            this.listView1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView1.ForeColor = System.Drawing.Color.Black;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView1.Location = new System.Drawing.Point(512, 612);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(104, 105);
            this.listView1.TabIndex = 10000063;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 0;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Width = 100;
            // 
            // m_txtSign
            // 
            this.m_txtSign.AccessibleName = "NoDefault";
            this.m_txtSign.BackColor = System.Drawing.Color.White;
            this.m_txtSign.BorderColor = System.Drawing.Color.White;
            this.m_txtSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSign.ForeColor = System.Drawing.Color.Black;
            this.m_txtSign.Location = new System.Drawing.Point(512, 716);
            this.m_txtSign.Name = "m_txtSign";
            this.m_txtSign.Size = new System.Drawing.Size(104, 21);
            this.m_txtSign.TabIndex = 10000062;
            // 
            // m_lblSign
            // 
            this.m_lblSign.BackColor = System.Drawing.SystemColors.Control;
            this.m_lblSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblSign.ForeColor = System.Drawing.Color.Black;
            this.m_lblSign.Location = new System.Drawing.Point(272, 716);
            this.m_lblSign.Name = "m_lblSign";
            this.m_lblSign.Size = new System.Drawing.Size(112, 19);
            this.m_lblSign.TabIndex = 10000060;
            this.m_lblSign.Visible = false;
            // 
            // m_txtCurePlan
            // 
            this.m_txtCurePlan.AccessibleDescription = "诊疗计划";
            this.m_txtCurePlan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtCurePlan.BackColor = System.Drawing.Color.White;
            this.m_txtCurePlan.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCurePlan.ForeColor = System.Drawing.Color.Black;
            this.m_txtCurePlan.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCurePlan.Location = new System.Drawing.Point(76, 648);
            this.m_txtCurePlan.m_BlnIgnoreUserInfo = false;
            this.m_txtCurePlan.m_BlnPartControl = false;
            this.m_txtCurePlan.m_BlnReadOnly = false;
            this.m_txtCurePlan.m_BlnUnderLineDST = false;
            this.m_txtCurePlan.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtCurePlan.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtCurePlan.m_IntCanModifyTime = 6;
            this.m_txtCurePlan.m_IntPartControlLength = 0;
            this.m_txtCurePlan.m_IntPartControlStartIndex = 0;
            this.m_txtCurePlan.m_StrUserID = "";
            this.m_txtCurePlan.m_StrUserName = "";
            this.m_txtCurePlan.Name = "m_txtCurePlan";
            this.m_txtCurePlan.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtCurePlan.Size = new System.Drawing.Size(812, 52);
            this.m_txtCurePlan.TabIndex = 10000052;
            this.m_txtCurePlan.Text = "";
            // 
            // m_txtDiagnoseDiffe
            // 
            this.m_txtDiagnoseDiffe.AccessibleDescription = "鉴别诊断";
            this.m_txtDiagnoseDiffe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtDiagnoseDiffe.BackColor = System.Drawing.Color.White;
            this.m_txtDiagnoseDiffe.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDiagnoseDiffe.ForeColor = System.Drawing.Color.Black;
            this.m_txtDiagnoseDiffe.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDiagnoseDiffe.Location = new System.Drawing.Point(100, 596);
            this.m_txtDiagnoseDiffe.m_BlnIgnoreUserInfo = false;
            this.m_txtDiagnoseDiffe.m_BlnPartControl = false;
            this.m_txtDiagnoseDiffe.m_BlnReadOnly = false;
            this.m_txtDiagnoseDiffe.m_BlnUnderLineDST = false;
            this.m_txtDiagnoseDiffe.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDiagnoseDiffe.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDiagnoseDiffe.m_IntCanModifyTime = 6;
            this.m_txtDiagnoseDiffe.m_IntPartControlLength = 0;
            this.m_txtDiagnoseDiffe.m_IntPartControlStartIndex = 0;
            this.m_txtDiagnoseDiffe.m_StrUserID = "";
            this.m_txtDiagnoseDiffe.m_StrUserName = "";
            this.m_txtDiagnoseDiffe.Name = "m_txtDiagnoseDiffe";
            this.m_txtDiagnoseDiffe.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtDiagnoseDiffe.Size = new System.Drawing.Size(788, 44);
            this.m_txtDiagnoseDiffe.TabIndex = 10000051;
            this.m_txtDiagnoseDiffe.Text = "";
            // 
            // m_txtDiagnoseThe
            // 
            this.m_txtDiagnoseThe.AccessibleDescription = "诊断依据";
            this.m_txtDiagnoseThe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtDiagnoseThe.BackColor = System.Drawing.Color.White;
            this.m_txtDiagnoseThe.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDiagnoseThe.ForeColor = System.Drawing.Color.Black;
            this.m_txtDiagnoseThe.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDiagnoseThe.Location = new System.Drawing.Point(100, 496);
            this.m_txtDiagnoseThe.m_BlnIgnoreUserInfo = false;
            this.m_txtDiagnoseThe.m_BlnPartControl = false;
            this.m_txtDiagnoseThe.m_BlnReadOnly = false;
            this.m_txtDiagnoseThe.m_BlnUnderLineDST = false;
            this.m_txtDiagnoseThe.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDiagnoseThe.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDiagnoseThe.m_IntCanModifyTime = 6;
            this.m_txtDiagnoseThe.m_IntPartControlLength = 0;
            this.m_txtDiagnoseThe.m_IntPartControlStartIndex = 0;
            this.m_txtDiagnoseThe.m_StrUserID = "";
            this.m_txtDiagnoseThe.m_StrUserName = "";
            this.m_txtDiagnoseThe.Name = "m_txtDiagnoseThe";
            this.m_txtDiagnoseThe.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtDiagnoseThe.Size = new System.Drawing.Size(788, 40);
            this.m_txtDiagnoseThe.TabIndex = 10000050;
            this.m_txtDiagnoseThe.Text = "";
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
            this.m_txtOriginalDiagnose.Location = new System.Drawing.Point(83, 368);
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
            this.m_txtOriginalDiagnose.Size = new System.Drawing.Size(805, 64);
            this.m_txtOriginalDiagnose.TabIndex = 10000049;
            this.m_txtOriginalDiagnose.Text = "";
            // 
            // m_txtMostlyContent
            // 
            this.m_txtMostlyContent.AccessibleDescription = "主要内容";
            this.m_txtMostlyContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtMostlyContent.BackColor = System.Drawing.Color.White;
            this.m_txtMostlyContent.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtMostlyContent.ForeColor = System.Drawing.Color.Black;
            this.m_txtMostlyContent.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtMostlyContent.Location = new System.Drawing.Point(83, 151);
            this.m_txtMostlyContent.m_BlnIgnoreUserInfo = false;
            this.m_txtMostlyContent.m_BlnPartControl = false;
            this.m_txtMostlyContent.m_BlnReadOnly = false;
            this.m_txtMostlyContent.m_BlnUnderLineDST = false;
            this.m_txtMostlyContent.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtMostlyContent.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtMostlyContent.m_IntCanModifyTime = 6;
            this.m_txtMostlyContent.m_IntPartControlLength = 0;
            this.m_txtMostlyContent.m_IntPartControlStartIndex = 0;
            this.m_txtMostlyContent.m_StrUserID = "";
            this.m_txtMostlyContent.m_StrUserName = "";
            this.m_txtMostlyContent.Name = "m_txtMostlyContent";
            this.m_txtMostlyContent.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtMostlyContent.Size = new System.Drawing.Size(805, 208);
            this.m_txtMostlyContent.TabIndex = 10000048;
            this.m_txtMostlyContent.Text = "";
            // 
            // m_cmdClose
            // 
            this.m_cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdClose.DefaultScheme = true;
            this.m_cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdClose.Hint = "";
            this.m_cmdClose.Location = new System.Drawing.Point(808, 712);
            this.m_cmdClose.Name = "m_cmdClose";
            this.m_cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdClose.Size = new System.Drawing.Size(80, 30);
            this.m_cmdClose.TabIndex = 10000066;
            this.m_cmdClose.Text = "取消";
            this.m_cmdClose.Click += new System.EventHandler(this.m_cmdClose_Click);
            // 
            // cmdConfirm
            // 
            this.cmdConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.cmdConfirm.DefaultScheme = true;
            this.cmdConfirm.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdConfirm.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdConfirm.Hint = "";
            this.cmdConfirm.Location = new System.Drawing.Point(712, 712);
            this.cmdConfirm.Name = "cmdConfirm";
            this.cmdConfirm.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdConfirm.Size = new System.Drawing.Size(80, 30);
            this.cmdConfirm.TabIndex = 10000065;
            this.cmdConfirm.Text = "确定";
            this.cmdConfirm.Click += new System.EventHandler(this.cmdConfirm_Click);
            // 
            // m_cmdEmployeeSign
            // 
            this.m_cmdEmployeeSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdEmployeeSign.DefaultScheme = true;
            this.m_cmdEmployeeSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdEmployeeSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdEmployeeSign.Hint = "";
            this.m_cmdEmployeeSign.Location = new System.Drawing.Point(432, 712);
            this.m_cmdEmployeeSign.Name = "m_cmdEmployeeSign";
            this.m_cmdEmployeeSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdEmployeeSign.Size = new System.Drawing.Size(76, 30);
            this.m_cmdEmployeeSign.TabIndex = 10000067;
            this.m_cmdEmployeeSign.Tag = "1";
            this.m_cmdEmployeeSign.Text = "签名:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(4, 652);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 10000057;
            this.label1.Text = "诊疗计划:";
            // 
            // lblInHospitalCaseTitle
            // 
            this.lblInHospitalCaseTitle.AccessibleDescription = "";
            this.lblInHospitalCaseTitle.AutoSize = true;
            this.lblInHospitalCaseTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblInHospitalCaseTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInHospitalCaseTitle.ForeColor = System.Drawing.Color.Black;
            this.lblInHospitalCaseTitle.Location = new System.Drawing.Point(8, 151);
            this.lblInHospitalCaseTitle.Name = "lblInHospitalCaseTitle";
            this.lblInHospitalCaseTitle.Size = new System.Drawing.Size(70, 14);
            this.lblInHospitalCaseTitle.TabIndex = 10000053;
            this.lblInHospitalCaseTitle.Text = "主要内容:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(4, 548);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 14);
            this.label2.TabIndex = 10000056;
            this.label2.Text = "中医鉴别诊断:";
            // 
            // m_txtIdentifyDiagnos
            // 
            this.m_txtIdentifyDiagnos.AccessibleDescription = "中医鉴别诊断";
            this.m_txtIdentifyDiagnos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtIdentifyDiagnos.BackColor = System.Drawing.Color.White;
            this.m_txtIdentifyDiagnos.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtIdentifyDiagnos.ForeColor = System.Drawing.Color.Black;
            this.m_txtIdentifyDiagnos.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtIdentifyDiagnos.Location = new System.Drawing.Point(100, 544);
            this.m_txtIdentifyDiagnos.m_BlnIgnoreUserInfo = false;
            this.m_txtIdentifyDiagnos.m_BlnPartControl = false;
            this.m_txtIdentifyDiagnos.m_BlnReadOnly = false;
            this.m_txtIdentifyDiagnos.m_BlnUnderLineDST = false;
            this.m_txtIdentifyDiagnos.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtIdentifyDiagnos.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtIdentifyDiagnos.m_IntCanModifyTime = 6;
            this.m_txtIdentifyDiagnos.m_IntPartControlLength = 0;
            this.m_txtIdentifyDiagnos.m_IntPartControlStartIndex = 0;
            this.m_txtIdentifyDiagnos.m_StrUserID = "";
            this.m_txtIdentifyDiagnos.m_StrUserName = "";
            this.m_txtIdentifyDiagnos.Name = "m_txtIdentifyDiagnos";
            this.m_txtIdentifyDiagnos.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtIdentifyDiagnos.Size = new System.Drawing.Size(788, 44);
            this.m_txtIdentifyDiagnos.TabIndex = 10000051;
            this.m_txtIdentifyDiagnos.Text = "";
            // 
            // m_txtIdentifyReston
            // 
            this.m_txtIdentifyReston.AccessibleDescription = "中医诊断依据";
            this.m_txtIdentifyReston.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtIdentifyReston.BackColor = System.Drawing.Color.White;
            this.m_txtIdentifyReston.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtIdentifyReston.ForeColor = System.Drawing.Color.Black;
            this.m_txtIdentifyReston.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtIdentifyReston.Location = new System.Drawing.Point(128, 440);
            this.m_txtIdentifyReston.m_BlnIgnoreUserInfo = false;
            this.m_txtIdentifyReston.m_BlnPartControl = false;
            this.m_txtIdentifyReston.m_BlnReadOnly = false;
            this.m_txtIdentifyReston.m_BlnUnderLineDST = false;
            this.m_txtIdentifyReston.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtIdentifyReston.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtIdentifyReston.m_IntCanModifyTime = 6;
            this.m_txtIdentifyReston.m_IntPartControlLength = 0;
            this.m_txtIdentifyReston.m_IntPartControlStartIndex = 0;
            this.m_txtIdentifyReston.m_StrUserID = "";
            this.m_txtIdentifyReston.m_StrUserName = "";
            this.m_txtIdentifyReston.Name = "m_txtIdentifyReston";
            this.m_txtIdentifyReston.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtIdentifyReston.Size = new System.Drawing.Size(760, 48);
            this.m_txtIdentifyReston.TabIndex = 10000050;
            this.m_txtIdentifyReston.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(4, 440);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 14);
            this.label3.TabIndex = 10000055;
            this.label3.Text = "中医辨病辨证依据:";
            // 
            // frmFirstIllnessNote_ZY
            // 
            this.ClientSize = new System.Drawing.Size(900, 745);
            this.Controls.Add(this.lblInHospitalCaseTitle);
            this.Controls.Add(this.m_txtDiagnoseThe);
            this.Controls.Add(this.m_txtIdentifyDiagnos);
            this.Controls.Add(this.m_txtDiagnoseDiffe);
            this.Controls.Add(this.m_cmdEmployeeSign);
            this.Controls.Add(this.m_cmdClose);
            this.Controls.Add(this.cmdConfirm);
            this.Controls.Add(this.lblSignTitle);
            this.Controls.Add(this.lblReferralTitle);
            this.Controls.Add(this.lblCaseHistoryTitle);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.m_txtSign);
            this.Controls.Add(this.m_lblSign);
            this.Controls.Add(this.m_txtCurePlan);
            this.Controls.Add(this.m_txtOriginalDiagnose);
            this.Controls.Add(this.m_txtMostlyContent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_txtIdentifyReston);
            this.Controls.Add(this.label3);
            this.Name = "frmFirstIllnessNote_ZY";
            this.Text = "首次病程记录";
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.m_txtIdentifyReston, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.m_lblGetDataTime, 0);
            this.Controls.SetChildIndex(this.m_dtpGetDataTime, 0);
            this.Controls.SetChildIndex(this.label1, 0);
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
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.m_txtMostlyContent, 0);
            this.Controls.SetChildIndex(this.m_txtOriginalDiagnose, 0);
            this.Controls.SetChildIndex(this.m_txtCurePlan, 0);
            this.Controls.SetChildIndex(this.m_lblSign, 0);
            this.Controls.SetChildIndex(this.m_txtSign, 0);
            this.Controls.SetChildIndex(this.listView1, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.lblCaseHistoryTitle, 0);
            this.Controls.SetChildIndex(this.lblReferralTitle, 0);
            this.Controls.SetChildIndex(this.lblSignTitle, 0);
            this.Controls.SetChildIndex(this.cmdConfirm, 0);
            this.Controls.SetChildIndex(this.m_cmdClose, 0);
            this.Controls.SetChildIndex(this.m_cmdEmployeeSign, 0);
            this.Controls.SetChildIndex(this.m_txtDiagnoseDiffe, 0);
            this.Controls.SetChildIndex(this.m_txtIdentifyDiagnos, 0);
            this.Controls.SetChildIndex(this.m_txtDiagnoseThe, 0);
            this.Controls.SetChildIndex(this.lblInHospitalCaseTitle, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public override clsDiseaseTrackInfo m_objGetDiseaseTrackInfo()
		{
			clsDiseaseSummaryInfo objTrackInfo = new clsDiseaseSummaryInfo();

			objTrackInfo.m_ObjRecordContent = m_objCurrentRecordContent;//m_objGetContentFromGUI();
			objTrackInfo.m_DtmRecordTime = m_dtpCreateDate.Value;
			objTrackInfo.m_StrTitle = "首次病程记录";			

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
			m_objSignTool.m_mthSetDefaulEmployee();

			//清空具体记录内容			
			m_txtMostlyContent.m_mthClearText();
			m_txtOriginalDiagnose.m_mthClearText();
			m_txtDiagnoseThe.m_mthClearText();
			m_txtDiagnoseDiffe.m_mthClearText();		
			m_txtCurePlan.m_mthClearText();		
		}

		/// <summary>
		/// 控制是否可以选择病人和记录时间列表。在从病程记录窗体调用时需要使用。
		/// </summary>
		/// <param name="p_blnEnable"></param>
		protected override void m_mthEnablePatientSelectSub(bool p_blnEnable)
		{
			if(p_blnEnable==false)
			{
				foreach(Control control in this.Controls)
				{					
					if(control.Name!="m_dtpCreateDate")
						control.Top=control.Top-105;				
				}
			
				cmdConfirm.Visible=true;
				
				this.Size=new Size(this.Size.Width, this.Size.Height-105);
				this.CenterToParent();	
		
				lblCreateDateTitle.Left=lblInHospitalCaseTitle.Left;//=16;
				lblCreateDateTitle.Top=15;	
				m_dtpCreateDate.Left=lblCreateDateTitle.Right+5;
				m_dtpCreateDate.Top=lblCreateDateTitle.Top;				
			}
			this.MaximizeBox=false;
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
            if (m_objCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)				
				return null;
            
			//从界面获取表单值
			clsFirstIllnessNote_ZYRecordContent objContent=new clsFirstIllnessNote_ZYRecordContent();
			objContent.m_dtmCreateDate=m_dtpCreateDate.Value;					
			#region 是否可以无痕迹修改
            if (chkModifyWithoutMatk.Checked)
                objContent.m_intMarkStatus = 0;
            else
                objContent.m_intMarkStatus = 1;
            #endregion	
			objContent.m_strMostlyContent_Right=m_txtMostlyContent.m_strGetRightText();	
			objContent.m_strMostlyContent=m_txtMostlyContent.Text;
			objContent.m_strMostlyContentXML=m_txtMostlyContent.m_strGetXmlText();					
			
			objContent.m_strOriginalDiagnose_Right=m_txtOriginalDiagnose.m_strGetRightText();	
			objContent.m_strOriginalDiagnose=m_txtOriginalDiagnose.Text;
			objContent.m_strOriginalDiagnoseXML=m_txtOriginalDiagnose.m_strGetXmlText();					
			
			objContent.m_strThereunderDiagnose_Right=m_txtDiagnoseThe.m_strGetRightText();	
			objContent.m_strThereunderDiagnose=m_txtDiagnoseThe.Text;
			objContent.m_strThereunderDiagnoseXML=m_txtDiagnoseThe.m_strGetXmlText();					
			
			objContent.m_strDiagnoseDiffe_Right=m_txtDiagnoseDiffe.m_strGetRightText();	
			objContent.m_strDiagnoseDiffe=m_txtDiagnoseDiffe.Text;
			objContent.m_strDiagnoseDiffeXML=m_txtDiagnoseDiffe.m_strGetXmlText();	
		
			objContent.m_strCurePlan_Right=m_txtCurePlan.m_strGetRightText();	
			objContent.m_strCurePlan=m_txtCurePlan.Text;
			objContent.m_strCurePlanXML=m_txtCurePlan.m_strGetXmlText();
			
			objContent.m_strIdentifyReston_Right = m_txtIdentifyReston.m_strGetRightText();
			objContent.m_strIdentifyReston = m_txtIdentifyReston.Text;
			objContent.m_strIdentifyRestonXML = m_txtIdentifyReston.m_strGetXmlText();

			objContent.m_strIdentifyDiagnose_Right = m_txtIdentifyDiagnos.m_strGetRightText();
			objContent.m_strIdentifyDiagnos = m_txtIdentifyDiagnos.Text;
			objContent.m_strIdentifyDiagnoseXML = m_txtIdentifyDiagnos.m_strGetXmlText();
			
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
			clsFirstIllnessNote_ZYRecordContent objContent=(clsFirstIllnessNote_ZYRecordContent)p_objContent;
			//把表单值赋值到界面，由子窗体重载实现

			m_txtMostlyContent.m_mthSetNewText(objContent.m_strMostlyContent,objContent.m_strMostlyContentXML);		
			m_txtOriginalDiagnose.m_mthSetNewText(objContent.m_strOriginalDiagnose,objContent.m_strOriginalDiagnoseXML);		
			m_txtDiagnoseThe.m_mthSetNewText(objContent.m_strThereunderDiagnose,objContent.m_strThereunderDiagnoseXML);		
			m_txtDiagnoseDiffe.m_mthSetNewText(objContent.m_strDiagnoseDiffe,objContent.m_strDiagnoseDiffeXML);	
			m_txtCurePlan.m_mthSetNewText(objContent.m_strCurePlan,objContent.m_strCurePlanXML);	
			m_txtIdentifyReston.m_mthSetNewText(objContent.m_strIdentifyReston,objContent.m_strIdentifyRestonXML);
			m_txtIdentifyDiagnos.m_mthSetNewText(objContent.m_strIdentifyDiagnos,objContent.m_strIdentifyDiagnoseXML);
			
			#region 签名
			m_objSignTool.m_mtSetSpecialEmployee(objContent.m_strModifyUserID,m_txtSign);
		 
			clsEmployee objEmployee=new clsEmployee(objContent.m_strCreateUserID);
			if(objEmployee !=null)
				m_lblSign.Text= objEmployee.m_StrLastName;	
			else 
			{
				MDIParent.ShowInformationMessageBox("数据库有误,员工编号无效!");
			}
			 
			#endregion 签名			
		}

		public override int m_IntFormID
		{
			get
			{
				return 48;
			}
		}

		protected override void m_mthSetDeletedGUIFromContent(clsTrackRecordContent p_objContent)
		{
			if(p_objContent ==null)
				return;
			clsFirstIllnessNote_ZYRecordContent objContent=(clsFirstIllnessNote_ZYRecordContent)p_objContent;
			//把表单值赋值到界面，由子窗体重载实现

			m_txtMostlyContent.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strMostlyContent,objContent.m_strMostlyContentXML);		
			m_txtOriginalDiagnose.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOriginalDiagnose,objContent.m_strOriginalDiagnoseXML);		
			m_txtDiagnoseThe.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strThereunderDiagnose,objContent.m_strThereunderDiagnoseXML);		
			m_txtDiagnoseDiffe.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDiagnoseDiffe,objContent.m_strDiagnoseDiffeXML);	
			m_txtCurePlan.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strCurePlan,objContent.m_strCurePlanXML);	
			m_txtIdentifyReston.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strIdentifyReston,objContent.m_strIdentifyRestonXML);
			m_txtIdentifyDiagnos.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strIdentifyDiagnos,objContent.m_strIdentifyDiagnoseXML);
			
		}

		/// <summary>
		/// 获取病程记录的领域层实例
		/// </summary>
		/// <returns></returns>
		protected override clsDiseaseTrackDomain m_objGetDiseaseTrackDomain()
		{
			//获取病程记录的领域层实例
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.FirstIllnessNote_ZY);					
		}

		/// <summary>
		/// 把选择时间记录内容重新整理为完全正确的内容。
		/// </summary>
		/// <param name="p_objRecordContent"></param>
		protected override void m_mthReAddNewRecord(clsTrackRecordContent p_objRecordContent)
		{
			//把选择时间记录内容重新整理为完全正确的内容，由子窗体重载实现。
			clsFirstIllnessNote_ZYRecordContent objContent=(clsFirstIllnessNote_ZYRecordContent)p_objRecordContent;
			//把表单值赋值到界面，由子窗体重载实现
			m_txtMostlyContent.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strMostlyContent,objContent.m_strMostlyContentXML);		
			m_txtOriginalDiagnose.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOriginalDiagnose,objContent.m_strOriginalDiagnoseXML);		
			m_txtDiagnoseThe.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strThereunderDiagnose,objContent.m_strThereunderDiagnoseXML);		
			m_txtDiagnoseDiffe.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDiagnoseDiffe,objContent.m_strDiagnoseDiffeXML);	
			m_txtCurePlan.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strCurePlan,objContent.m_strCurePlanXML);	
			m_txtIdentifyReston.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strIdentifyReston,objContent.m_strIdentifyRestonXML);
			m_txtIdentifyDiagnos.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strIdentifyDiagnos,objContent.m_strIdentifyDiagnoseXML);
			
		}
		

		// 获取选择已经删除记录的窗体标题
		public override string m_strReloadFormTitle()
		{
			//由子窗体重载实现
			return	"首次病程记录";
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

			m_txtMostlyContent.Focus();
		}

		


		/// <summary>
		/// 数据复用
		/// </summary>
		/// <param name="p_objSelectedPatient"></param>
		protected override void m_mthDataShare(clsPatient p_objSelectedPatient)
		{			
		}

		protected override void m_mthSetDefaultValue(clsPatient p_objPatient)
		{
			//记录时间跟住院病历
			clsInPatientCaseHisoryDefaultValue [] objInPatientCaseDefaultValue = new clsInPatientCaseHisoryDefaultDomain().lngGetAllInPatientCaseHisoryDefault(m_objCurrentPatient.m_StrInPatientID,m_objCurrentPatient.m_DtmSelectedInDate.ToString());
			if(objInPatientCaseDefaultValue !=null && objInPatientCaseDefaultValue.Length >0)
			{
				m_dtpCreateDate.Value = DateTime.Parse(objInPatientCaseDefaultValue[0].m_strCreateDate);
			}

			//默认值
			new clsDefaultValueTool(this,p_objPatient).m_mthSetDefaultValue();
			//左上端空几格
			m_txtMostlyContent.m_mthInsertText("    ",0);
			
			//自动调用模板
			m_mthSetSpecialPatientTemplateSet(p_objPatient);

			if(m_blnHaveAssociateTemplate)
			{
				//				int intIndex1 = m_txtRecordContent.Text.IndexOf("鉴别诊断");
				//				int intIndex2 = m_txtRecordContent.Text.LastIndexOf("鉴别诊断");
				//				if(intIndex1 != -1 && intIndex2 > intIndex1)
				//					m_txtRecordContent.Text = m_txtRecordContent.Text.Remove(intIndex1,intIndex2 - intIndex1);
			}
						

			//			//记住关联了哪个手术名称
			//			string strTemplateSetID = m_objTemplateDomain.m_strGetPatientHaveDisease_TemplateSetID(m_objCurrentPatient.m_StrInPatientID,m_objCurrentPatient.m_DtmLastInDate.ToString(),this.Name,(int)enmAssociate.Disease);
			//			m_txtRecordContent.Tag = m_objTemplateDomain.m_strGetAssociateIDBySetID(strTemplateSetID,(int)enmAssociate.Operation);
		}

	}
}
