using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using com.digitalwave.Emr.Signature_gui;//多签名
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
	public class frmFirstIllnessNote_F2 : iCare.frmDiseaseTrackBase
    {
		private PinkieControls.ButtonXP m_cmdClose;
		private PinkieControls.ButtonXP cmdConfirm;
        private PinkieControls.ButtonXP m_cmdEmployeeSign;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		/// 
 		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.ListView lsvSign;
		private System.Windows.Forms.ColumnHeader columnHeader1;
        private Label lblCaseHistoryTitle;
        private Label label8;
        private com.digitalwave.controls.ctlRichTextBox m_txtCurePlan;
        private com.digitalwave.controls.ctlRichTextBox m_txtDiagnoseThe;
        private com.digitalwave.controls.ctlRichTextBox m_txtOriginalDiagnose;
        private com.digitalwave.controls.ctlRichTextBox m_txtMostlyContent;
        private Label label1;
        private Label label2;
		//定义签名类
		private clsEmrSignToolCollection m_objSign;



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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFirstIllnessNote_F2));
            this.m_cmdClose = new PinkieControls.ButtonXP();
            this.cmdConfirm = new PinkieControls.ButtonXP();
            this.m_cmdEmployeeSign = new PinkieControls.ButtonXP();
            this.lsvSign = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.lblCaseHistoryTitle = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.m_txtCurePlan = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtDiagnoseThe = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtOriginalDiagnose = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtMostlyContent = new com.digitalwave.controls.ctlRichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_pnlNewBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_trvCreateDate
            // 
            this.m_trvCreateDate.LineColor = System.Drawing.Color.Black;
            this.m_trvCreateDate.Location = new System.Drawing.Point(58, -89);
            // 
            // lblCreateDateTitle
            // 
            this.lblCreateDateTitle.Location = new System.Drawing.Point(9, 9);
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.Location = new System.Drawing.Point(81, 4);
            // 
            // m_dtpGetDataTime
            // 
            this.m_dtpGetDataTime.Location = new System.Drawing.Point(378, -49);
            // 
            // m_lblGetDataTime
            // 
            this.m_lblGetDataTime.Location = new System.Drawing.Point(274, -49);
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(554, -145);
            this.lblSex.Size = new System.Drawing.Size(56, 21);
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(674, -145);
            this.lblAge.Size = new System.Drawing.Size(60, 21);
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(301, -183);
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(287, -146);
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(502, -183);
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(498, -145);
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(618, -145);
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(34, -153);
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(482, -118);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(135, 119);
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(353, -151);
            this.txtInPatientID.Size = new System.Drawing.Size(135, 23);
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(553, -187);
            this.m_txtPatientName.Size = new System.Drawing.Size(136, 23);
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(353, -187);
            this.m_txtBedNO.Size = new System.Drawing.Size(135, 23);
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(90, -153);
            this.m_cboArea.Size = new System.Drawing.Size(168, 23);
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(514, -116);
            this.m_lsvPatientName.Size = new System.Drawing.Size(136, 119);
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(437, -118);
            this.m_lsvBedNO.Size = new System.Drawing.Size(135, 119);
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(98, -193);
            this.m_cboDept.Size = new System.Drawing.Size(168, 23);
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(34, -185);
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(623, -76);
            this.m_cmdNewTemplate.Size = new System.Drawing.Size(98, 33);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.Location = new System.Drawing.Point(255, -187);
            this.m_cmdNext.Size = new System.Drawing.Size(28, 24);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(425, -28);
            this.m_cmdPre.Size = new System.Drawing.Size(28, 24);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(343, -183);
            this.m_lblForTitle.Size = new System.Drawing.Size(19, 27);
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(12, 577);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(655, -151);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Location = new System.Drawing.Point(10, -63);
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            // 
            // m_cmdClose
            // 
            this.m_cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdClose.DefaultScheme = true;
            this.m_cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdClose.Hint = "";
            this.m_cmdClose.Location = new System.Drawing.Point(737, 577);
            this.m_cmdClose.Name = "m_cmdClose";
            this.m_cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdClose.Size = new System.Drawing.Size(80, 30);
            this.m_cmdClose.TabIndex = 10000066;
            this.m_cmdClose.Text = "取消";
            this.m_cmdClose.Click += new System.EventHandler(this.m_cmdClose_Click);
            // 
            // cmdConfirm
            // 
            this.cmdConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.cmdConfirm.DefaultScheme = true;
            this.cmdConfirm.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdConfirm.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdConfirm.Hint = "";
            this.cmdConfirm.Location = new System.Drawing.Point(641, 577);
            this.cmdConfirm.Name = "cmdConfirm";
            this.cmdConfirm.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdConfirm.Size = new System.Drawing.Size(80, 30);
            this.cmdConfirm.TabIndex = 10000065;
            this.cmdConfirm.Text = "确定";
            this.cmdConfirm.Click += new System.EventHandler(this.cmdConfirm_Click);
            // 
            // m_cmdEmployeeSign
            // 
            this.m_cmdEmployeeSign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_cmdEmployeeSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdEmployeeSign.DefaultScheme = true;
            this.m_cmdEmployeeSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdEmployeeSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdEmployeeSign.Hint = "";
            this.m_cmdEmployeeSign.Location = new System.Drawing.Point(92, 577);
            this.m_cmdEmployeeSign.Name = "m_cmdEmployeeSign";
            this.m_cmdEmployeeSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdEmployeeSign.Size = new System.Drawing.Size(76, 30);
            this.m_cmdEmployeeSign.TabIndex = 10000067;
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
            this.lsvSign.Location = new System.Drawing.Point(172, 577);
            this.lsvSign.MultiSelect = false;
            this.lsvSign.Name = "lsvSign";
            this.lsvSign.Size = new System.Drawing.Size(463, 28);
            this.lsvSign.TabIndex = 10000068;
            this.lsvSign.UseCompatibleStateImageBehavior = false;
            this.lsvSign.View = System.Windows.Forms.View.SmallIcon;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 50;
            // 
            // lblCaseHistoryTitle
            // 
            this.lblCaseHistoryTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCaseHistoryTitle.AutoSize = true;
            this.lblCaseHistoryTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblCaseHistoryTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCaseHistoryTitle.ForeColor = System.Drawing.Color.Black;
            this.lblCaseHistoryTitle.Location = new System.Drawing.Point(10, 260);
            this.lblCaseHistoryTitle.Name = "lblCaseHistoryTitle";
            this.lblCaseHistoryTitle.Size = new System.Drawing.Size(112, 14);
            this.lblCaseHistoryTitle.TabIndex = 10000074;
            this.lblCaseHistoryTitle.Text = "诊断与鉴别诊断:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(10, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 14);
            this.label8.TabIndex = 10000073;
            this.label8.Text = "病例特点:";
            // 
            // m_txtCurePlan
            // 
            this.m_txtCurePlan.AccessibleDescription = "治疗计划";
            this.m_txtCurePlan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtCurePlan.BackColor = System.Drawing.Color.White;
            this.m_txtCurePlan.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCurePlan.ForeColor = System.Drawing.Color.Black;
            this.m_txtCurePlan.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCurePlan.Location = new System.Drawing.Point(11, 469);
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
            this.m_txtCurePlan.Size = new System.Drawing.Size(805, 102);
            this.m_txtCurePlan.TabIndex = 10000072;
            this.m_txtCurePlan.Text = "";
            // 
            // m_txtDiagnoseThe
            // 
            this.m_txtDiagnoseThe.AccessibleDescription = "诊断依据";
            this.m_txtDiagnoseThe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtDiagnoseThe.BackColor = System.Drawing.Color.White;
            this.m_txtDiagnoseThe.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDiagnoseThe.ForeColor = System.Drawing.Color.Black;
            this.m_txtDiagnoseThe.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDiagnoseThe.Location = new System.Drawing.Point(13, 277);
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
            this.m_txtDiagnoseThe.Size = new System.Drawing.Size(804, 172);
            this.m_txtDiagnoseThe.TabIndex = 10000071;
            this.m_txtDiagnoseThe.Text = "";
            // 
            // m_txtOriginalDiagnose
            // 
            this.m_txtOriginalDiagnose.AccessibleDescription = "初步诊断";
            this.m_txtOriginalDiagnose.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtOriginalDiagnose.BackColor = System.Drawing.Color.White;
            this.m_txtOriginalDiagnose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOriginalDiagnose.ForeColor = System.Drawing.Color.Black;
            this.m_txtOriginalDiagnose.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOriginalDiagnose.Location = new System.Drawing.Point(12, 145);
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
            this.m_txtOriginalDiagnose.Size = new System.Drawing.Size(805, 110);
            this.m_txtOriginalDiagnose.TabIndex = 10000070;
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
            this.m_txtMostlyContent.Location = new System.Drawing.Point(12, 58);
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
            this.m_txtMostlyContent.Size = new System.Drawing.Size(805, 61);
            this.m_txtMostlyContent.TabIndex = 10000069;
            this.m_txtMostlyContent.Text = "";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(9, 452);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 10000075;
            this.label1.Text = "治疗计划:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(10, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 10000076;
            this.label2.Text = "主要内容:";
            // 
            // frmFirstIllnessNote_F2
            // 
            this.AccessibleDescription = "首次病程记录";
            this.ClientSize = new System.Drawing.Size(832, 621);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_txtCurePlan);
            this.Controls.Add(this.m_txtDiagnoseThe);
            this.Controls.Add(this.m_txtOriginalDiagnose);
            this.Controls.Add(this.lblCaseHistoryTitle);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.m_txtMostlyContent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lsvSign);
            this.Controls.Add(this.m_cmdEmployeeSign);
            this.Controls.Add(this.m_cmdClose);
            this.Controls.Add(this.cmdConfirm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFirstIllnessNote_F2";
            this.Text = "首次病程记录";
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_lblGetDataTime, 0);
            this.Controls.SetChildIndex(this.m_dtpGetDataTime, 0);
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
            this.Controls.SetChildIndex(this.cmdConfirm, 0);
            this.Controls.SetChildIndex(this.m_cmdClose, 0);
            this.Controls.SetChildIndex(this.m_cmdEmployeeSign, 0);
            this.Controls.SetChildIndex(this.lsvSign, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.m_txtMostlyContent, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.lblCaseHistoryTitle, 0);
            this.Controls.SetChildIndex(this.m_txtOriginalDiagnose, 0);
            this.Controls.SetChildIndex(this.m_txtDiagnoseThe, 0);
            this.Controls.SetChildIndex(this.m_txtCurePlan, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region 构造函数
		/// <summary>
		/// 构造函数
		/// </summary>
        public frmFirstIllnessNote_F2()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
            //指明医生工作站表单
            intFormType = 1;
 			cmdConfirm.Visible=false;
            // 设置RichTextBox属性。（右键菜单、用户姓名、用户ID、输入字体颜色，双画线颜色）
			m_mthSetRichTextBoxAttribInControl(this);
 			//签名常用值
			m_objSign = new clsEmrSignToolCollection();
			//m_mthBindEmployeeSign(按钮,签名框,医生1or护士2,身份验证trueorfalse);
            m_objSign.m_mthBindEmployeeSign(m_cmdEmployeeSign, lsvSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);

            if (com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_StrCurrentHospitalNO != "440605001")
                lblCaseHistoryTitle.Text = "诊断依据与鉴别诊断:";

		}
		#endregion
		public override clsDiseaseTrackInfo m_objGetDiseaseTrackInfo()
		{
			clsDiseaseSummaryInfo objTrackInfo = new clsDiseaseSummaryInfo();

			objTrackInfo.m_ObjRecordContent = m_objCurrentRecordContent;//m_objGetContentFromGUI();
			objTrackInfo.m_DtmRecordTime = m_dtpCreateDate.Value;
			objTrackInfo.m_StrTitle = "首次病程记录";			

			//设置m_strTitle和m_dtmRecordTime
            if (objTrackInfo.m_ObjRecordContent != null)
            {
                m_dtpCreateDate.Value = objTrackInfo.m_ObjRecordContent.m_dtmCreateDate;
                m_dtpCreateDate.Refresh();
            }
			return objTrackInfo;		
		}

		/// <summary>
		/// 清空特殊记录信息，并重置记录控制状态为不控制。
		/// </summary>
		protected override void m_mthClearRecordInfo()
		{

			//清空具体记录内容			
			m_txtMostlyContent.m_mthClearText();
			m_txtOriginalDiagnose.m_mthClearText();
			m_txtDiagnoseThe.m_mthClearText();		
			m_txtCurePlan.m_mthClearText();

			//默认签名
			MDIParent.m_mthSetDefaulEmployee(lsvSign);
			
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
		
                //m_dtpCreateDate.Left=lblCreateDateTitle.Right+5;
                //m_dtpCreateDate.Top=lblCreateDateTitle.Top;
                //m_dtpCreateDate.Refresh();
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
			int intSignCount=lsvSign.Items.Count;
			 			
			if(m_objCurrentPatient==null || m_ObjCurrentEmrPatientSession == null ||intSignCount==0)				
				return null;
			//从界面获取表单值
			clsFirstIllnessNoteRecordContent objContent=new clsFirstIllnessNoteRecordContent();
            #region 是否可以无痕迹修改
            if (chkModifyWithoutMatk.Checked)
                objContent.m_intMarkStatus = 0;
            else
                objContent.m_intMarkStatus = 1;
            #endregion
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
            //    objContent.objSignerArr[i].m_strFORMID_VCHR="frmFirstIllnessNote";
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
			//其他
			objContent.m_strMostlyContent_Right=m_txtMostlyContent.m_strGetRightText();	
			objContent.m_strMostlyContent=m_txtMostlyContent.Text;
			objContent.m_strMostlyContentXML=m_txtMostlyContent.m_strGetXmlText();
            //(一)病例特点
			objContent.m_strOriginalDiagnose_Right=m_txtOriginalDiagnose.m_strGetRightText();	
			objContent.m_strOriginalDiagnose=m_txtOriginalDiagnose.Text;
			objContent.m_strOriginalDiagnoseXML=m_txtOriginalDiagnose.m_strGetXmlText();
            //(二)诊断与鉴别诊断
            objContent.m_strDiagnoseDiffe_Right = m_txtDiagnoseThe.m_strGetRightText();
            objContent.m_strDiagnoseDiffe = m_txtDiagnoseThe.Text;
            objContent.m_strDiagnoseDiffeXML = m_txtDiagnoseThe.m_strGetXmlText();
            //（三）诊疗计划
			objContent.m_strCurePlan_Right=m_txtCurePlan.m_strGetRightText();	
			objContent.m_strCurePlan=m_txtCurePlan.Text;
			objContent.m_strCurePlanXML=m_txtCurePlan.m_strGetXmlText();	
			
			
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
			clsFirstIllnessNoteRecordContent objContent=(clsFirstIllnessNoteRecordContent)p_objContent;
			//把表单值赋值到界面，由子窗体重载实现

			m_txtMostlyContent.m_mthSetNewText(objContent.m_strMostlyContent,objContent.m_strMostlyContentXML);		
			m_txtOriginalDiagnose.m_mthSetNewText(objContent.m_strOriginalDiagnose,objContent.m_strOriginalDiagnoseXML);		
			m_txtDiagnoseThe.m_mthSetNewText(objContent.m_strDiagnoseDiffe,objContent.m_strDiagnoseDiffeXML);		
			m_txtCurePlan.m_mthSetNewText(objContent.m_strCurePlan,objContent.m_strCurePlanXML);		
			
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
			clsFirstIllnessNoteRecordContent objContent=(clsFirstIllnessNoteRecordContent)p_objContent;
			//把表单值赋值到界面，由子窗体重载实现

			m_txtMostlyContent.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strMostlyContent,objContent.m_strMostlyContentXML);		
			m_txtOriginalDiagnose.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOriginalDiagnose,objContent.m_strOriginalDiagnoseXML);
            m_txtDiagnoseThe.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDiagnoseDiffe, objContent.m_strDiagnoseDiffeXML);		
			m_txtCurePlan.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strCurePlan,objContent.m_strCurePlanXML);

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
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.FirstIllnessNote);					
		}

		/// <summary>
		/// 把选择时间记录内容重新整理为完全正确的内容。
		/// </summary>
		/// <param name="p_objRecordContent"></param>
		protected override void m_mthReAddNewRecord(clsTrackRecordContent p_objRecordContent)
		{
			//把选择时间记录内容重新整理为完全正确的内容，由子窗体重载实现。
			clsFirstIllnessNoteRecordContent objContent=(clsFirstIllnessNoteRecordContent)p_objRecordContent;
			//把表单值赋值到界面，由子窗体重载实现
			m_txtMostlyContent.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strMostlyContent,objContent.m_strMostlyContentXML);		
			m_txtOriginalDiagnose.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOriginalDiagnose,objContent.m_strOriginalDiagnoseXML);		
			m_txtDiagnoseThe.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDiagnoseDiffe,objContent.m_strDiagnoseDiffeXML);		
			m_txtCurePlan.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strCurePlan,objContent.m_strCurePlanXML);		
			
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
            if (objInPatientCaseDefaultValue != null && objInPatientCaseDefaultValue.Length > 0)
            {
                m_dtpCreateDate.Value = DateTime.Parse(objInPatientCaseDefaultValue[0].m_strCreateDate);
                m_dtpCreateDate.Refresh();
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
