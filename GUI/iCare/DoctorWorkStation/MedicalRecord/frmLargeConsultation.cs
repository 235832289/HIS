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
	/// 大会诊记录
	/// </summary>
	public class frmLargeConsultation : iCare.frmDiseaseTrackBase
    {
		private System.Windows.Forms.Label lblDiscussContentTitle;
        private com.digitalwave.controls.ctlRichTextBox m_txtDiscussContent;
        private com.digitalwave.controls.ctlRichTextBox m_txtAddress;
		private System.ComponentModel.IContainer components = null;
		private PinkieControls.ButtonXP m_cmdAttendee;
		private PinkieControls.ButtonXP m_cmdCompere;

		private clsEmployeeSignTool m_objSignTool;
		private PinkieControls.ButtonXP m_cmdAddress;
		protected System.Windows.Forms.ListView lsvSign;
		private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
		private PinkieControls.ButtonXP m_cmdEmployeeSign;
        protected System.Windows.Forms.ListView lsvCompere;
        private com.digitalwave.controls.ctlRichTextBox m_txtAttendee;

		//定义签名类
		private clsEmrSignToolCollection m_objSign;

        public frmLargeConsultation()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
            //指明医生工作站表单
            intFormType = 1;
			
			m_mthSetRichTextBoxAttribInControl(this);

			//签名常用值
			m_objSign = new clsEmrSignToolCollection();
			//m_mthBindEmployeeSign(按钮,签名框,医生1or护士2,身份验证trueorfalse);
			//记录者
			m_objSign.m_mthBindEmployeeSign(m_cmdEmployeeSign,lsvSign,1, true);
			//主持
			m_objSign.m_mthBindEmployeeSign(m_cmdCompere,lsvCompere,1, false);
			//参加人员
			m_objSign.m_mthBindEmployeeSign(m_cmdAttendee,m_txtAttendee,0, false,clsEMRLogin.LoginInfo.m_strEmpID,true);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLargeConsultation));
            this.lblDiscussContentTitle = new System.Windows.Forms.Label();
            this.m_txtDiscussContent = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtAddress = new com.digitalwave.controls.ctlRichTextBox();
            this.m_cmdAttendee = new PinkieControls.ButtonXP();
            this.m_cmdCompere = new PinkieControls.ButtonXP();
            this.m_cmdEmployeeSign = new PinkieControls.ButtonXP();
            this.m_cmdAddress = new PinkieControls.ButtonXP();
            this.lsvSign = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.lsvCompere = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.m_txtAttendee = new com.digitalwave.controls.ctlRichTextBox();
            this.m_pnlNewBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_trvCreateDate
            // 
            this.m_trvCreateDate.ForeColor = System.Drawing.Color.Black;
            this.m_trvCreateDate.LineColor = System.Drawing.Color.Black;
            this.m_trvCreateDate.Location = new System.Drawing.Point(11, 37);
            this.m_trvCreateDate.Size = new System.Drawing.Size(197, 61);
            // 
            // lblCreateDateTitle
            // 
            this.lblCreateDateTitle.Location = new System.Drawing.Point(211, 74);
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.Location = new System.Drawing.Point(287, 70);
            this.m_dtpCreateDate.Size = new System.Drawing.Size(215, 22);
            this.m_dtpCreateDate.TabIndex = 3333333;
            // 
            // m_dtpGetDataTime
            // 
            this.m_dtpGetDataTime.Location = new System.Drawing.Point(110, 66);
            this.m_dtpGetDataTime.Size = new System.Drawing.Size(10, 22);
            // 
            // m_lblGetDataTime
            // 
            this.m_lblGetDataTime.Location = new System.Drawing.Point(75, 79);
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(643, 292);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(643, 321);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(413, 265);
            this.lblBedNoTitle.Size = new System.Drawing.Size(56, 14);
            this.lblBedNoTitle.Text = "床  号:";
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(413, 294);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(591, 265);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(591, 294);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(591, 323);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(215, 272);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(675, 353);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(475, 290);
            this.txtInPatientID.Size = new System.Drawing.Size(110, 23);
            this.txtInPatientID.TabIndex = 33333333;
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(639, 261);
            this.m_txtPatientName.Size = new System.Drawing.Size(118, 23);
            this.m_txtPatientName.TabIndex = 33333333;
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(475, 261);
            this.m_txtBedNO.Size = new System.Drawing.Size(89, 23);
            this.m_txtBedNO.TabIndex = 0;
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(263, 268);
            this.m_cboArea.TabIndex = 9999999;
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(436, 357);
            this.m_lsvPatientName.Size = new System.Drawing.Size(64, 104);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(475, 343);
            this.m_lsvBedNO.Size = new System.Drawing.Size(110, 116);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(263, 239);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(215, 243);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(704, 107);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.m_cmdNext.Location = new System.Drawing.Point(561, 262);
            this.m_cmdNext.TabIndex = 1;
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(59, 290);
            this.m_cmdPre.Size = new System.Drawing.Size(10, 20);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(81, 71);
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(662, 70);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(661, 40);
            this.m_cmdModifyPatientInfo.Size = new System.Drawing.Size(69, 28);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Size = new System.Drawing.Size(793, 92);
            this.m_pnlNewBase.Visible = true;
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ctlPatientInfo.Dock = System.Windows.Forms.DockStyle.None;
            this.m_ctlPatientInfo.Location = new System.Drawing.Point(206, 29);
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(586, 62);
            // 
            // lblDiscussContentTitle
            // 
            this.lblDiscussContentTitle.AutoSize = true;
            this.lblDiscussContentTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblDiscussContentTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.lblDiscussContentTitle.ForeColor = System.Drawing.Color.Black;
            this.lblDiscussContentTitle.Location = new System.Drawing.Point(15, 268);
            this.lblDiscussContentTitle.Name = "lblDiscussContentTitle";
            this.lblDiscussContentTitle.Size = new System.Drawing.Size(85, 16);
            this.lblDiscussContentTitle.TabIndex = 6091;
            this.lblDiscussContentTitle.Text = "讨论内容:";
            // 
            // m_txtDiscussContent
            // 
            this.m_txtDiscussContent.AccessibleDescription = "讨论内容";
            this.m_txtDiscussContent.BackColor = System.Drawing.Color.White;
            this.m_txtDiscussContent.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDiscussContent.ForeColor = System.Drawing.Color.Black;
            this.m_txtDiscussContent.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDiscussContent.Location = new System.Drawing.Point(110, 267);
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
            this.m_txtDiscussContent.Size = new System.Drawing.Size(678, 250);
            this.m_txtDiscussContent.TabIndex = 500;
            this.m_txtDiscussContent.Text = "";
            // 
            // m_txtAddress
            // 
            this.m_txtAddress.BackColor = System.Drawing.Color.White;
            this.m_txtAddress.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtAddress.ForeColor = System.Drawing.Color.Black;
            this.m_txtAddress.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtAddress.Location = new System.Drawing.Point(110, 116);
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
            this.m_txtAddress.Size = new System.Drawing.Size(678, 28);
            this.m_txtAddress.TabIndex = 100;
            this.m_txtAddress.Text = "";
            // 
            // m_cmdAttendee
            // 
            this.m_cmdAttendee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdAttendee.DefaultScheme = true;
            this.m_cmdAttendee.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdAttendee.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdAttendee.Hint = "";
            this.m_cmdAttendee.Location = new System.Drawing.Point(12, 151);
            this.m_cmdAttendee.Name = "m_cmdAttendee";
            this.m_cmdAttendee.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdAttendee.Size = new System.Drawing.Size(92, 30);
            this.m_cmdAttendee.TabIndex = 10000076;
            this.m_cmdAttendee.Text = "参加人员:";
            // 
            // m_cmdCompere
            // 
            this.m_cmdCompere.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdCompere.DefaultScheme = true;
            this.m_cmdCompere.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdCompere.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdCompere.Hint = "";
            this.m_cmdCompere.Location = new System.Drawing.Point(12, 233);
            this.m_cmdCompere.Name = "m_cmdCompere";
            this.m_cmdCompere.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCompere.Size = new System.Drawing.Size(88, 30);
            this.m_cmdCompere.TabIndex = 300;
            this.m_cmdCompere.Text = "主持人:";
            // 
            // m_cmdEmployeeSign
            // 
            this.m_cmdEmployeeSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdEmployeeSign.DefaultScheme = true;
            this.m_cmdEmployeeSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdEmployeeSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdEmployeeSign.Hint = "";
            this.m_cmdEmployeeSign.Location = new System.Drawing.Point(12, 521);
            this.m_cmdEmployeeSign.Name = "m_cmdEmployeeSign";
            this.m_cmdEmployeeSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdEmployeeSign.Size = new System.Drawing.Size(88, 30);
            this.m_cmdEmployeeSign.TabIndex = 600;
            this.m_cmdEmployeeSign.Tag = "1";
            this.m_cmdEmployeeSign.Text = "记录者:";
            // 
            // m_cmdAddress
            // 
            this.m_cmdAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdAddress.DefaultScheme = true;
            this.m_cmdAddress.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdAddress.Enabled = false;
            this.m_cmdAddress.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdAddress.Hint = "";
            this.m_cmdAddress.Location = new System.Drawing.Point(12, 115);
            this.m_cmdAddress.Name = "m_cmdAddress";
            this.m_cmdAddress.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdAddress.Size = new System.Drawing.Size(92, 30);
            this.m_cmdAddress.TabIndex = 90;
            this.m_cmdAddress.Text = "地点:";
            // 
            // lsvSign
            // 
            this.lsvSign.BackColor = System.Drawing.Color.White;
            this.lsvSign.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lsvSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvSign.ForeColor = System.Drawing.Color.Black;
            this.lsvSign.FullRowSelect = true;
            this.lsvSign.GridLines = true;
            this.lsvSign.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lsvSign.Location = new System.Drawing.Point(110, 523);
            this.lsvSign.Name = "lsvSign";
            this.lsvSign.Size = new System.Drawing.Size(678, 28);
            this.lsvSign.TabIndex = 700;
            this.lsvSign.UseCompatibleStateImageBehavior = false;
            this.lsvSign.View = System.Windows.Forms.View.SmallIcon;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 55;
            // 
            // lsvCompere
            // 
            this.lsvCompere.BackColor = System.Drawing.Color.White;
            this.lsvCompere.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.lsvCompere.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvCompere.ForeColor = System.Drawing.Color.Black;
            this.lsvCompere.FullRowSelect = true;
            this.lsvCompere.GridLines = true;
            this.lsvCompere.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lsvCompere.Location = new System.Drawing.Point(110, 233);
            this.lsvCompere.Name = "lsvCompere";
            this.lsvCompere.Size = new System.Drawing.Size(678, 28);
            this.lsvCompere.TabIndex = 400;
            this.lsvCompere.UseCompatibleStateImageBehavior = false;
            this.lsvCompere.View = System.Windows.Forms.View.SmallIcon;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 55;
            // 
            // m_txtAttendee
            // 
            this.m_txtAttendee.AccessibleDescription = "参加人员";
            this.m_txtAttendee.BackColor = System.Drawing.Color.White;
            this.m_txtAttendee.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtAttendee.ForeColor = System.Drawing.Color.Black;
            this.m_txtAttendee.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtAttendee.Location = new System.Drawing.Point(110, 151);
            this.m_txtAttendee.m_BlnIgnoreUserInfo = false;
            this.m_txtAttendee.m_BlnPartControl = false;
            this.m_txtAttendee.m_BlnReadOnly = false;
            this.m_txtAttendee.m_BlnUnderLineDST = false;
            this.m_txtAttendee.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtAttendee.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtAttendee.m_IntCanModifyTime = 6;
            this.m_txtAttendee.m_IntPartControlLength = 0;
            this.m_txtAttendee.m_IntPartControlStartIndex = 0;
            this.m_txtAttendee.m_StrUserID = "";
            this.m_txtAttendee.m_StrUserName = "";
            this.m_txtAttendee.Name = "m_txtAttendee";
            this.m_txtAttendee.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtAttendee.Size = new System.Drawing.Size(678, 71);
            this.m_txtAttendee.TabIndex = 500;
            this.m_txtAttendee.Text = "";
            // 
            // frmLargeConsultation
            // 
            this.AccessibleDescription = "病例讨论记录";
            this.ClientSize = new System.Drawing.Size(815, 566);
            this.Controls.Add(this.lsvCompere);
            this.Controls.Add(this.lsvSign);
            this.Controls.Add(this.m_cmdAddress);
            this.Controls.Add(this.m_cmdEmployeeSign);
            this.Controls.Add(this.lblDiscussContentTitle);
            this.Controls.Add(this.m_cmdCompere);
            this.Controls.Add(this.m_cmdAttendee);
            this.Controls.Add(this.m_txtAttendee);
            this.Controls.Add(this.m_txtDiscussContent);
            this.Controls.Add(this.m_txtAddress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLargeConsultation";
            this.Text = "大会诊记录";
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
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
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_lblGetDataTime, 0);
            this.Controls.SetChildIndex(this.m_dtpGetDataTime, 0);
            this.Controls.SetChildIndex(this.m_txtAddress, 0);
            this.Controls.SetChildIndex(this.m_txtDiscussContent, 0);
            this.Controls.SetChildIndex(this.m_txtAttendee, 0);
            this.Controls.SetChildIndex(this.m_cmdAttendee, 0);
            this.Controls.SetChildIndex(this.m_cmdCompere, 0);
            this.Controls.SetChildIndex(this.lblDiscussContentTitle, 0);
            this.Controls.SetChildIndex(this.m_cmdEmployeeSign, 0);
            this.Controls.SetChildIndex(this.m_cmdAddress, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.lsvSign, 0);
            this.Controls.SetChildIndex(this.m_trvCreateDate, 0);
            this.Controls.SetChildIndex(this.lsvCompere, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.m_dtpCreateDate, 0);
            this.Controls.SetChildIndex(this.lblCreateDateTitle, 0);
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
			clsCaseDiscussInfo objTrackInfo = new clsCaseDiscussInfo();

			objTrackInfo.m_ObjRecordContent = m_objGetContentFromGUI();
			//设置m_strTitle和m_dtmRecordTime
			objTrackInfo.m_DtmRecordTime = m_dtpCreateDate.Value;
			objTrackInfo.m_StrTitle = "大会诊记录";			
			
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
            m_txtAttendee.m_mthClearText();
            lsvCompere.Items.Clear();
		}

		/// <summary>
		/// 控制是否可以选择病人和记录时间列表。在从病程记录窗体调用时需要使用。
		/// </summary>
		/// <param name="p_blnEnable"></param>
		protected override void m_mthEnablePatientSelectSub(bool p_blnEnable)
		{
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
            int intCompere = lsvCompere.Items.Count;
            //int intAttend=lsvAttend.Items.Count;
			if(m_objCurrentPatient==null)				
				return null;
			if (intSignCount==0)
			{
				clsPublicFunction.ShowInformationMessageBox("请至少一个记录员签名!");
                m_cmdEmployeeSign.Focus();
				return null;
			}

			if (intCompere==0)
			{
				clsPublicFunction.ShowInformationMessageBox("请主持人签名!");
                m_cmdCompere.Focus();
				return null;
			}
			if (m_txtAttendee.Text.Trim() == string.Empty)
			{
				clsPublicFunction.ShowInformationMessageBox("请至少一个参加人员签名!");
                m_txtAttendee.Focus();
				return null;
			}
			//从界面获取表单值
            clsLargeConsultationContent objContent = new clsLargeConsultationContent();

			//获取lsvsign签名
            //objContent.objSignerArr=new clsEmrSigns_VO[intSignCount+intCompere];
			strUserIDList="";
			strUserNameList="";
            m_mthGetSignArr(new Control[] { lsvSign, lsvCompere}, ref objContent.objSignerArr, ref strUserIDList, ref strUserNameList);
            objContent.m_strRecordUserID = strUserIDList;
			objContent.m_strModifyUserID=strUserIDList;
			
			//设置Richtextbox的modifyuserID 和modifyuserName
			m_mthSetRichTextBoxAttribInControlWithIDandName(this);

			#region 是否可以无痕迹修改
			if (chkModifyWithoutMatk.Checked)
				objContent.m_intMarkStatus=0;
			else
				objContent.m_intMarkStatus=1;
			#endregion			
				
			objContent.m_strAddress_Right=m_txtAddress.m_strGetRightText();	
			objContent.m_strAddress=m_txtAddress.Text;
			objContent.m_strAddressXML=m_txtAddress.m_strGetXmlText();					
			
			objContent.m_strDiscussContent_Right=m_txtDiscussContent.m_strGetRightText();	
			objContent.m_strDiscussContent=m_txtDiscussContent.Text;
			objContent.m_strDiscussContentXML=m_txtDiscussContent.m_strGetXmlText();	

			objContent.m_strAttendeeName_Right=m_txtAttendee.m_strGetRightText();	
			objContent.m_strAttendeeName=m_txtAttendee.Text;
			objContent.m_strAttendeeNameXml=m_txtAttendee.m_strGetXmlText();				
			
			return objContent;	
		}
        /// <summary>
        /// 设置子窗体的创建时间基类时间等，为了适合用RegisterId与新业务要求用
        /// </summary>
        /// <param name="p_objContent"></param>
        protected override void m_mthSetSubCreatedDateInfo(ref clsTrackRecordContent p_objContent, bool p_blnIsAddNew)
        {
            if (p_objContent != null)
            {
                DateTime dtm = new clsPublicDomain().m_dtmGetServerTime();
                p_objContent.m_dtmCreateDate = dtm;
                p_objContent.m_dtmRecordDate = m_dtpCreateDate.Value;
                p_objContent.m_strCreateUserID = clsEMRLogin.LoginInfo.m_strEmpID;
                p_objContent.m_dtmModifyDate = dtm;
                p_objContent.m_dtmInPatientDate = m_objCurrentPatient.m_DtmSelectedInDate;
                p_objContent.m_strInPatientID = m_objCurrentPatient.m_StrInPatientID;
                p_objContent.m_strRegisterID = m_objCurrentPatient.m_StrRegisterId;
            }
        }
		/// <summary>
		/// 把特殊记录的值显示到界面上。
		/// </summary>
		/// <param name="p_objContent"></param>
		protected override void m_mthSetGUIFromContent(clsTrackRecordContent p_objContent)
		{
			if(p_objContent ==null)
				return;
            clsLargeConsultationContent objContent = (clsLargeConsultationContent)p_objContent;
			//把表单值赋值到界面，由子窗体重载实现
            m_txtAddress.m_mthSetNewText(objContent.m_strAddress, objContent.m_strAddressXML);
            m_txtAttendee.m_mthSetNewText(objContent.m_strAttendeeName, objContent.m_strAttendeeNameXml);
			m_txtDiscussContent.m_mthSetNewText(objContent.m_strDiscussContent,objContent.m_strDiscussContentXML);
            m_dtmCreatedDate = objContent.m_dtmCreateDate;
            m_dtpCreateDate.Value = objContent.m_dtmRecordDate;
			#region 签名集合
			//记录签名
			if (objContent.objSignerArr!=null)
            {
                m_mthAddSignToListView(lsvSign, objContent.objSignerArr);
                m_mthAddSignToListView(lsvCompere, objContent.objSignerArr);
			}
			#endregion 签名			 
		}

		public override int m_IntFormID
		{
			get
			{
				return 163;
			}
		}

		protected override void m_mthSetDeletedGUIFromContent(clsTrackRecordContent p_objContent)
		{
			if(p_objContent ==null)
				return;
            clsLargeConsultationContent objContent = (clsLargeConsultationContent)p_objContent;
			//把表单值赋值到界面，由子窗体重载实现
            m_txtAddress.Text = objContent.m_strAddress_Right;
            m_txtAttendee.Text = objContent.m_strAttendeeName_Right;		
			m_txtDiscussContent.Text=objContent.m_strDiscussContent_Right;		
			
			//记录签名
            if (objContent.objSignerArr != null)
            {
                m_mthAddSignToListView(lsvSign, objContent.objSignerArr);
                m_mthAddSignToListView(lsvCompere, objContent.objSignerArr);

            }
		}
		

		/// <summary>
		/// 获取病程记录的领域层实例
		/// </summary>
		/// <returns></returns>
		protected override clsDiseaseTrackDomain m_objGetDiseaseTrackDomain()
		{
			//获取病程记录的领域层实例
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.LargeConsultation);					
		}

		/// <summary>
		/// 把选择时间记录内容重新整理为完全正确的内容。
		/// </summary>
		/// <param name="p_objRecordContent"></param>
		protected override void m_mthReAddNewRecord(clsTrackRecordContent p_objRecordContent)
		{
			//把选择时间记录内容重新整理为完全正确的内容，由子窗体重载实现。
            clsLargeConsultationContent objContent = (clsLargeConsultationContent)p_objRecordContent;
			//把表单值赋值到界面，由子窗体重载实现

            m_txtAddress.Text = objContent.m_strAddress_Right;
            m_txtAttendee.Text = objContent.m_strAttendeeName_Right;
            m_txtDiscussContent.Text = objContent.m_strDiscussContent_Right;

            //记录签名
            if (objContent.objSignerArr != null)
            {
                m_mthAddSignToListView(lsvSign, objContent.objSignerArr);
                m_mthAddSignToListView(lsvCompere, objContent.objSignerArr);

            }
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
			return	"大会诊记录";
		}	
	
		/// <summary>
		/// 当选择根节点时,设置特殊的默认值(若子窗体需要,则重载实现)
		/// </summary>
		protected override void m_mthSelectRootNode()
		{

        }

		private void m_cmdClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
        /// <summary>
        /// 获取指定病程记录内容
        /// </summary>
        /// <param name="p_objSelectedPatient"></param>
        /// <param name="p_strOpenDate"></param>
        /// <returns></returns>
        public override clsTrackRecordContent m_objGetRecordContent(clsPatient p_objSelectedPatient, string p_strOpenDate)
        {
            clsTrackRecordContent objContent;
            //获取记录
            m_objDiseaseTrackDomain.m_lngGetRecordContent(p_objSelectedPatient.m_StrRegisterId, p_strOpenDate, out objContent);
            return objContent;
        }
        /// <summary>
        /// 获取病人记录列表
        /// </summary>
        /// <param name="p_objSelectedPatient"></param>
        /// <param name="strCreateTimeListArr"></param>
        /// <param name="strOpenTimeListArr"></param>
        /// <returns></returns>
        protected override void m_mthGetTimeList(clsPatient p_objSelectedPatient, out string[] strCreateTimeListArr, out string[] strOpenTimeListArr)
        {
            strCreateTimeListArr = null;
            strOpenTimeListArr = null;
            if (p_objSelectedPatient == null || m_objDiseaseTrackDomain == null)
                return;

            long lngRes = m_objDiseaseTrackDomain.m_lngGetRecordTimeList(p_objSelectedPatient.m_StrRegisterId,  out strCreateTimeListArr, out strOpenTimeListArr);

            if (lngRes <= 0 || strCreateTimeListArr == null || strOpenTimeListArr == null || strOpenTimeListArr.Length != strCreateTimeListArr.Length)
            {
                m_mthSetNodeSelected();
                return;
            }

            //添加查询到的时间到时间树上 
            for (int i = strOpenTimeListArr.Length - 1; i >= 0; i--)
            {
                TreeNode trnRecordDate = new TreeNode(strOpenTimeListArr[i]);
                trnRecordDate.Tag = strCreateTimeListArr[i];
                m_trnRoot.Nodes.Add(trnRecordDate);
            }
        }
        /// <summary>
        /// 添加节点到时间列表树,并选中
        /// </summary>
        /// <param name="p_objContent"></param>
        protected override void m_mthAddNode(clsTrackRecordContent p_objContent)
        {
            if (p_objContent == null)
            {
                return;
            }
            string strCreateDate = p_objContent.m_dtmRecordDate.ToString("yyyy-MM-dd HH:mm:ss");
            TreeNode trnNode = new TreeNode(strCreateDate);
            trnNode.Tag = p_objContent.m_dtmCreateDate.ToString("yyyy-MM-dd HH:mm:ss");

            m_blnCanTreeNodeAfterSelectEventTakePlace = false;

            if (m_trnRoot.Nodes.Count == 0 || trnNode.Text.CompareTo(m_trnRoot.LastNode.Text) < 0)
            {
                m_trnRoot.Nodes.Add(trnNode);
                m_trvCreateDate.SelectedNode = m_trnRoot.LastNode;//
            }
            else
            {
                for (int i = 0; i < m_trnRoot.Nodes.Count; i++)
                {
                    if (trnNode.Text.CompareTo(m_trnRoot.Nodes[i].Text) > 0)
                    {
                        m_trnRoot.Nodes.Insert(i, trnNode);
                        m_trvCreateDate.SelectedNode = m_trnRoot.Nodes[i];//
                        break;
                    }
                }
            }
            m_dtmCreatedDate = p_objContent.m_dtmCreateDate;
            m_dtpCreateDate.Enabled = false;
            m_blnCanTreeNodeAfterSelectEventTakePlace = true;
        }
		
	}
}

