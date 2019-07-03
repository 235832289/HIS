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
using com.digitalwave.PatientManagerService;
using com.digitalwave.Emr.Signature_gui;
using com.digitalwave.emr.AssistModuleVO;



namespace iCare
{
	/// <summary>
	/// 24小时内入出院记录
	/// </summary>
	public class frmEMR_OutHospitalIn24Hours : iCare.frmDiseaseTrackBase
	{
		#region 控件
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label m_lblNation;
		private System.Windows.Forms.Label m_lblBirthPlace;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label m_lblIsMarried;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label m_lblOccupation;
		private System.Windows.Forms.Label m_lblOfficeName;
		private System.Windows.Forms.Label m_lblOfficePhone;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label m_lblHomeAddress;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label m_lblHomePhone;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label6;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboRepresentor;
        private System.Windows.Forms.Label m_lblID;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label m_lblInHospitalDate;
        private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label25;
		private TextBox m_txtDoctorSign;
		private PinkieControls.ButtonXP m_cmdDoctorSign;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private com.digitalwave.controls.ctlRichTextBox m_txtMainDes;
		private com.digitalwave.controls.ctlRichTextBox m_txtInInstance;
        private com.digitalwave.controls.ctlRichTextBox m_txtInDiagnose1;
        private com.digitalwave.controls.ctlRichTextBox m_txtDiagnosisProcess;
		private com.digitalwave.controls.ctlRichTextBox m_txtOutDiagnose1;
        private com.digitalwave.controls.ctlRichTextBox m_txtOutInstance;
		private com.digitalwave.controls.ctlRichTextBox m_txtOutAdvice1;
		#endregion

        private com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
        private clsEmrSignToolCollection m_objSign;
		private string m_strCurrentOpenDate = "";
        private bool m_blnIsMainWindow = true;
        private ctlTimePicker m_dtOutHospital24;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmEMR_OutHospitalIn24Hours()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			m_mthSetRichTextBoxAttribInControl(this);
            //指明医生工作站表单
            intFormType = 1;
            m_objSign = new clsEmrSignToolCollection();
            m_objSign.m_mthBindEmployeeSign(m_cmdDoctorSign, m_txtDoctorSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEMR_OutHospitalIn24Hours));
            this.label1 = new System.Windows.Forms.Label();
            this.m_lblNation = new System.Windows.Forms.Label();
            this.m_lblBirthPlace = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_lblIsMarried = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_lblOccupation = new System.Windows.Forms.Label();
            this.m_lblOfficeName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.m_lblOfficePhone = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.m_lblHomeAddress = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.m_lblHomePhone = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_cboRepresentor = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_lblID = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.m_lblInHospitalDate = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.m_txtMainDes = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtInInstance = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtInDiagnose1 = new com.digitalwave.controls.ctlRichTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.m_txtDiagnosisProcess = new com.digitalwave.controls.ctlRichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.m_txtOutDiagnose1 = new com.digitalwave.controls.ctlRichTextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.m_txtOutInstance = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtOutAdvice1 = new com.digitalwave.controls.ctlRichTextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.m_txtDoctorSign = new System.Windows.Forms.TextBox();
            this.m_cmdDoctorSign = new PinkieControls.ButtonXP();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.m_dtOutHospital24 = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.m_pnlNewBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_trvCreateDate
            // 
            this.m_trvCreateDate.LineColor = System.Drawing.Color.Black;
            this.m_trvCreateDate.Location = new System.Drawing.Point(4, 38);
            this.m_trvCreateDate.Size = new System.Drawing.Size(192, 105);
            // 
            // lblCreateDateTitle
            // 
            this.lblCreateDateTitle.Location = new System.Drawing.Point(496, 583);
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.Location = new System.Drawing.Point(566, 581);
            // 
            // m_dtpGetDataTime
            // 
            this.m_dtpGetDataTime.Location = new System.Drawing.Point(338, 470);
            // 
            // m_lblGetDataTime
            // 
            this.m_lblGetDataTime.Location = new System.Drawing.Point(228, 460);
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(305, 211);
            this.lblSex.Size = new System.Drawing.Size(42, 19);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(281, 206);
            this.lblAge.Size = new System.Drawing.Size(94, 19);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(302, 209);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(302, 218);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(315, 216);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(300, 204);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(270, 212);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(254, 218);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(252, 226);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(116, 15);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(283, 207);
            this.txtInPatientID.Size = new System.Drawing.Size(94, 23);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(259, 216);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(292, 207);
            this.m_txtBedNO.Size = new System.Drawing.Size(66, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(231, 218);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(348, 226);
            this.m_lsvPatientName.Size = new System.Drawing.Size(24, 15);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(256, 226);
            this.m_lsvBedNO.Size = new System.Drawing.Size(116, 15);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(249, 218);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(228, 209);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(272, 207);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.m_cmdNext.Location = new System.Drawing.Point(318, 206);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(272, 209);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(283, 209);
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(459, 208);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(727, 61);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Controls.Add(this.label3);
            this.m_pnlNewBase.Controls.Add(this.m_cboRepresentor);
            this.m_pnlNewBase.Controls.Add(this.label6);
            this.m_pnlNewBase.Controls.Add(this.m_lblID);
            this.m_pnlNewBase.Controls.Add(this.m_lblHomePhone);
            this.m_pnlNewBase.Controls.Add(this.label12);
            this.m_pnlNewBase.Controls.Add(this.label8);
            this.m_pnlNewBase.Controls.Add(this.m_lblOfficePhone);
            this.m_pnlNewBase.Location = new System.Drawing.Point(3, 7);
            this.m_pnlNewBase.Size = new System.Drawing.Size(798, 138);
            this.m_pnlNewBase.Visible = true;
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_ctlPatientInfo, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_lblOfficePhone, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.label8, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.label12, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_lblHomePhone, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_lblID, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.label6, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_cboRepresentor, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.label3, 0);
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ctlPatientInfo.Dock = System.Windows.Forms.DockStyle.None;
            this.m_ctlPatientInfo.Location = new System.Drawing.Point(192, 29);
            this.m_ctlPatientInfo.m_BlnIsShowAddres = true;
            this.m_ctlPatientInfo.m_BlnIsShowHomePlace = true;
            this.m_ctlPatientInfo.m_BlnIsShowMarriage = true;
            this.m_ctlPatientInfo.m_BlnIsShowOccupy = true;
            this.m_ctlPatientInfo.m_BlnIsShowOffice = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowRace = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(606, 108);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(267, 207);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 10000005;
            this.label1.Text = "民族:";
            this.label1.Visible = false;
            // 
            // m_lblNation
            // 
            this.m_lblNation.AccessibleDescription = "民族";
            this.m_lblNation.Location = new System.Drawing.Point(254, 206);
            this.m_lblNation.Name = "m_lblNation";
            this.m_lblNation.Size = new System.Drawing.Size(16, 23);
            this.m_lblNation.TabIndex = 10000006;
            this.m_lblNation.Visible = false;
            // 
            // m_lblBirthPlace
            // 
            this.m_lblBirthPlace.AccessibleDescription = "籍贯";
            this.m_lblBirthPlace.Location = new System.Drawing.Point(246, 210);
            this.m_lblBirthPlace.Name = "m_lblBirthPlace";
            this.m_lblBirthPlace.Size = new System.Drawing.Size(53, 23);
            this.m_lblBirthPlace.TabIndex = 10000006;
            this.m_lblBirthPlace.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(270, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 14);
            this.label4.TabIndex = 10000005;
            this.label4.Text = "籍贯:";
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(289, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 14);
            this.label5.TabIndex = 10000007;
            this.label5.Text = "婚否:";
            this.label5.Visible = false;
            // 
            // m_lblIsMarried
            // 
            this.m_lblIsMarried.AccessibleDescription = "婚否";
            this.m_lblIsMarried.Location = new System.Drawing.Point(285, 206);
            this.m_lblIsMarried.Name = "m_lblIsMarried";
            this.m_lblIsMarried.Size = new System.Drawing.Size(90, 23);
            this.m_lblIsMarried.TabIndex = 10000006;
            this.m_lblIsMarried.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(237, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 14);
            this.label2.TabIndex = 10000008;
            this.label2.Text = "职业:";
            this.label2.Visible = false;
            // 
            // m_lblOccupation
            // 
            this.m_lblOccupation.AccessibleDescription = "职业";
            this.m_lblOccupation.Location = new System.Drawing.Point(249, 211);
            this.m_lblOccupation.Name = "m_lblOccupation";
            this.m_lblOccupation.Size = new System.Drawing.Size(142, 23);
            this.m_lblOccupation.TabIndex = 10000009;
            this.m_lblOccupation.Visible = false;
            // 
            // m_lblOfficeName
            // 
            this.m_lblOfficeName.AccessibleDescription = "单位";
            this.m_lblOfficeName.Location = new System.Drawing.Point(246, 208);
            this.m_lblOfficeName.Name = "m_lblOfficeName";
            this.m_lblOfficeName.Size = new System.Drawing.Size(170, 28);
            this.m_lblOfficeName.TabIndex = 10000009;
            this.m_lblOfficeName.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(237, 218);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 14);
            this.label7.TabIndex = 10000008;
            this.label7.Text = "单位:";
            this.label7.Visible = false;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(425, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 23);
            this.label8.TabIndex = 10000007;
            this.label8.Text = "单位电话:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblOfficePhone
            // 
            this.m_lblOfficePhone.AccessibleDescription = "单位电话";
            this.m_lblOfficePhone.Location = new System.Drawing.Point(495, 110);
            this.m_lblOfficePhone.Name = "m_lblOfficePhone";
            this.m_lblOfficePhone.Size = new System.Drawing.Size(96, 23);
            this.m_lblOfficePhone.TabIndex = 10000006;
            this.m_lblOfficePhone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(237, 213);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 14);
            this.label10.TabIndex = 10000010;
            this.label10.Text = "住址:";
            this.label10.Visible = false;
            // 
            // m_lblHomeAddress
            // 
            this.m_lblHomeAddress.AccessibleDescription = "住址";
            this.m_lblHomeAddress.Location = new System.Drawing.Point(164, 212);
            this.m_lblHomeAddress.Name = "m_lblHomeAddress";
            this.m_lblHomeAddress.Size = new System.Drawing.Size(350, 23);
            this.m_lblHomeAddress.TabIndex = 10000009;
            this.m_lblHomeAddress.Visible = false;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(540, 85);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 23);
            this.label12.TabIndex = 10000007;
            this.label12.Text = "家庭电话:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblHomePhone
            // 
            this.m_lblHomePhone.AccessibleDescription = "家庭电话";
            this.m_lblHomePhone.Location = new System.Drawing.Point(611, 84);
            this.m_lblHomePhone.Name = "m_lblHomePhone";
            this.m_lblHomePhone.Size = new System.Drawing.Size(96, 23);
            this.m_lblHomePhone.TabIndex = 10000006;
            this.m_lblHomePhone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(596, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 23);
            this.label3.TabIndex = 10000011;
            this.label3.Text = "病史陈述者:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_cboRepresentor
            // 
            this.m_cboRepresentor.AccessibleDescription = "病史陈述者";
            this.m_cboRepresentor.BackColor = System.Drawing.Color.White;
            this.m_cboRepresentor.BorderColor = System.Drawing.Color.Black;
            this.m_cboRepresentor.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboRepresentor.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboRepresentor.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboRepresentor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboRepresentor.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboRepresentor.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboRepresentor.ForeColor = System.Drawing.Color.Black;
            this.m_cboRepresentor.ListBackColor = System.Drawing.Color.White;
            this.m_cboRepresentor.ListForeColor = System.Drawing.Color.Black;
            this.m_cboRepresentor.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboRepresentor.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboRepresentor.Location = new System.Drawing.Point(681, 111);
            this.m_cboRepresentor.m_BlnEnableItemEventMenu = true;
            this.m_cboRepresentor.Name = "m_cboRepresentor";
            this.m_cboRepresentor.SelectedIndex = -1;
            this.m_cboRepresentor.SelectedItem = null;
            this.m_cboRepresentor.SelectionStart = 0;
            this.m_cboRepresentor.Size = new System.Drawing.Size(107, 23);
            this.m_cboRepresentor.TabIndex = 10000012;
            this.m_cboRepresentor.TextBackColor = System.Drawing.Color.White;
            this.m_cboRepresentor.TextForeColor = System.Drawing.Color.Black;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(195, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 23);
            this.label6.TabIndex = 10000013;
            this.label6.Text = "身份证号码:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblID
            // 
            this.m_lblID.AccessibleDescription = "身份证号码";
            this.m_lblID.Location = new System.Drawing.Point(277, 110);
            this.m_lblID.Name = "m_lblID";
            this.m_lblID.Size = new System.Drawing.Size(144, 23);
            this.m_lblID.TabIndex = 10000014;
            this.m_lblID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 150);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 14);
            this.label9.TabIndex = 10000016;
            this.label9.Text = "入院时间:";
            // 
            // m_lblInHospitalDate
            // 
            this.m_lblInHospitalDate.AccessibleDescription = "";
            this.m_lblInHospitalDate.Location = new System.Drawing.Point(90, 148);
            this.m_lblInHospitalDate.Name = "m_lblInHospitalDate";
            this.m_lblInHospitalDate.Size = new System.Drawing.Size(236, 23);
            this.m_lblInHospitalDate.TabIndex = 10000017;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(386, 150);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 14);
            this.label13.TabIndex = 10000016;
            this.label13.Text = "出院时间:";
            // 
            // m_txtMainDes
            // 
            this.m_txtMainDes.AccessibleDescription = "主诉";
            this.m_txtMainDes.BackColor = System.Drawing.Color.White;
            this.m_txtMainDes.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtMainDes.ForeColor = System.Drawing.Color.Black;
            this.m_txtMainDes.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtMainDes.Location = new System.Drawing.Point(90, 172);
            this.m_txtMainDes.m_BlnIgnoreUserInfo = false;
            this.m_txtMainDes.m_BlnPartControl = false;
            this.m_txtMainDes.m_BlnReadOnly = false;
            this.m_txtMainDes.m_BlnUnderLineDST = false;
            this.m_txtMainDes.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtMainDes.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtMainDes.m_IntCanModifyTime = 6;
            this.m_txtMainDes.m_IntPartControlLength = 0;
            this.m_txtMainDes.m_IntPartControlStartIndex = 0;
            this.m_txtMainDes.m_StrUserID = "";
            this.m_txtMainDes.m_StrUserName = "";
            this.m_txtMainDes.Multiline = false;
            this.m_txtMainDes.Name = "m_txtMainDes";
            this.m_txtMainDes.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtMainDes.Size = new System.Drawing.Size(692, 24);
            this.m_txtMainDes.TabIndex = 10000019;
            this.m_txtMainDes.Text = "";
            // 
            // m_txtInInstance
            // 
            this.m_txtInInstance.AccessibleDescription = "入院情况";
            this.m_txtInInstance.BackColor = System.Drawing.Color.White;
            this.m_txtInInstance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtInInstance.ForeColor = System.Drawing.Color.Black;
            this.m_txtInInstance.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtInInstance.Location = new System.Drawing.Point(90, 200);
            this.m_txtInInstance.m_BlnIgnoreUserInfo = false;
            this.m_txtInInstance.m_BlnPartControl = false;
            this.m_txtInInstance.m_BlnReadOnly = false;
            this.m_txtInInstance.m_BlnUnderLineDST = false;
            this.m_txtInInstance.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtInInstance.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtInInstance.m_IntCanModifyTime = 6;
            this.m_txtInInstance.m_IntPartControlLength = 0;
            this.m_txtInInstance.m_IntPartControlStartIndex = 0;
            this.m_txtInInstance.m_StrUserID = "";
            this.m_txtInInstance.m_StrUserName = "";
            this.m_txtInInstance.Name = "m_txtInInstance";
            this.m_txtInInstance.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtInInstance.Size = new System.Drawing.Size(692, 45);
            this.m_txtInInstance.TabIndex = 10000019;
            this.m_txtInInstance.Text = "";
            // 
            // m_txtInDiagnose1
            // 
            this.m_txtInDiagnose1.AccessibleDescription = "入院诊断1";
            this.m_txtInDiagnose1.BackColor = System.Drawing.Color.White;
            this.m_txtInDiagnose1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtInDiagnose1.ForeColor = System.Drawing.Color.Black;
            this.m_txtInDiagnose1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtInDiagnose1.Location = new System.Drawing.Point(90, 250);
            this.m_txtInDiagnose1.m_BlnIgnoreUserInfo = false;
            this.m_txtInDiagnose1.m_BlnPartControl = false;
            this.m_txtInDiagnose1.m_BlnReadOnly = false;
            this.m_txtInDiagnose1.m_BlnUnderLineDST = false;
            this.m_txtInDiagnose1.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtInDiagnose1.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtInDiagnose1.m_IntCanModifyTime = 6;
            this.m_txtInDiagnose1.m_IntPartControlLength = 0;
            this.m_txtInDiagnose1.m_IntPartControlStartIndex = 0;
            this.m_txtInDiagnose1.m_StrUserID = "";
            this.m_txtInDiagnose1.m_StrUserName = "";
            this.m_txtInDiagnose1.Name = "m_txtInDiagnose1";
            this.m_txtInDiagnose1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtInDiagnose1.Size = new System.Drawing.Size(692, 52);
            this.m_txtInDiagnose1.TabIndex = 10000020;
            this.m_txtInDiagnose1.Text = "";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(20, 175);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 14);
            this.label15.TabIndex = 10000022;
            this.label15.Text = "主    诉:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(20, 200);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(70, 14);
            this.label16.TabIndex = 10000023;
            this.label16.Text = "入院情况:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(20, 254);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(70, 14);
            this.label17.TabIndex = 10000023;
            this.label17.Text = "入院诊断:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(20, 316);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(70, 14);
            this.label18.TabIndex = 10000023;
            this.label18.Text = "诊疗经过:";
            // 
            // m_txtDiagnosisProcess
            // 
            this.m_txtDiagnosisProcess.AccessibleDescription = "诊疗经过";
            this.m_txtDiagnosisProcess.BackColor = System.Drawing.Color.White;
            this.m_txtDiagnosisProcess.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDiagnosisProcess.ForeColor = System.Drawing.Color.Black;
            this.m_txtDiagnosisProcess.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDiagnosisProcess.Location = new System.Drawing.Point(90, 316);
            this.m_txtDiagnosisProcess.m_BlnIgnoreUserInfo = false;
            this.m_txtDiagnosisProcess.m_BlnPartControl = false;
            this.m_txtDiagnosisProcess.m_BlnReadOnly = false;
            this.m_txtDiagnosisProcess.m_BlnUnderLineDST = false;
            this.m_txtDiagnosisProcess.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDiagnosisProcess.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDiagnosisProcess.m_IntCanModifyTime = 6;
            this.m_txtDiagnosisProcess.m_IntPartControlLength = 0;
            this.m_txtDiagnosisProcess.m_IntPartControlStartIndex = 0;
            this.m_txtDiagnosisProcess.m_StrUserID = "";
            this.m_txtDiagnosisProcess.m_StrUserName = "";
            this.m_txtDiagnosisProcess.Name = "m_txtDiagnosisProcess";
            this.m_txtDiagnosisProcess.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtDiagnosisProcess.Size = new System.Drawing.Size(692, 73);
            this.m_txtDiagnosisProcess.TabIndex = 10000019;
            this.m_txtDiagnosisProcess.Text = "";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(8, 308);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(774, 1);
            this.panel2.TabIndex = 10000015;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(8, 395);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(774, 1);
            this.panel3.TabIndex = 10000015;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(20, 405);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(70, 14);
            this.label19.TabIndex = 10000023;
            this.label19.Text = "出院情况:";
            // 
            // m_txtOutDiagnose1
            // 
            this.m_txtOutDiagnose1.AccessibleDescription = "出院诊断1";
            this.m_txtOutDiagnose1.BackColor = System.Drawing.Color.White;
            this.m_txtOutDiagnose1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOutDiagnose1.ForeColor = System.Drawing.Color.Black;
            this.m_txtOutDiagnose1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOutDiagnose1.Location = new System.Drawing.Point(90, 453);
            this.m_txtOutDiagnose1.m_BlnIgnoreUserInfo = false;
            this.m_txtOutDiagnose1.m_BlnPartControl = false;
            this.m_txtOutDiagnose1.m_BlnReadOnly = false;
            this.m_txtOutDiagnose1.m_BlnUnderLineDST = false;
            this.m_txtOutDiagnose1.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOutDiagnose1.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOutDiagnose1.m_IntCanModifyTime = 6;
            this.m_txtOutDiagnose1.m_IntPartControlLength = 0;
            this.m_txtOutDiagnose1.m_IntPartControlStartIndex = 0;
            this.m_txtOutDiagnose1.m_StrUserID = "";
            this.m_txtOutDiagnose1.m_StrUserName = "";
            this.m_txtOutDiagnose1.Name = "m_txtOutDiagnose1";
            this.m_txtOutDiagnose1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtOutDiagnose1.Size = new System.Drawing.Size(692, 54);
            this.m_txtOutDiagnose1.TabIndex = 10000020;
            this.m_txtOutDiagnose1.Text = "";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(20, 456);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(70, 14);
            this.label22.TabIndex = 10000023;
            this.label22.Text = "出院诊断:";
            // 
            // m_txtOutInstance
            // 
            this.m_txtOutInstance.AccessibleDescription = "出院情况";
            this.m_txtOutInstance.BackColor = System.Drawing.Color.White;
            this.m_txtOutInstance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOutInstance.ForeColor = System.Drawing.Color.Black;
            this.m_txtOutInstance.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOutInstance.Location = new System.Drawing.Point(90, 401);
            this.m_txtOutInstance.m_BlnIgnoreUserInfo = false;
            this.m_txtOutInstance.m_BlnPartControl = false;
            this.m_txtOutInstance.m_BlnReadOnly = false;
            this.m_txtOutInstance.m_BlnUnderLineDST = false;
            this.m_txtOutInstance.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOutInstance.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOutInstance.m_IntCanModifyTime = 6;
            this.m_txtOutInstance.m_IntPartControlLength = 0;
            this.m_txtOutInstance.m_IntPartControlStartIndex = 0;
            this.m_txtOutInstance.m_StrUserID = "";
            this.m_txtOutInstance.m_StrUserName = "";
            this.m_txtOutInstance.Name = "m_txtOutInstance";
            this.m_txtOutInstance.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtOutInstance.Size = new System.Drawing.Size(692, 45);
            this.m_txtOutInstance.TabIndex = 10000019;
            this.m_txtOutInstance.Text = "";
            // 
            // m_txtOutAdvice1
            // 
            this.m_txtOutAdvice1.AccessibleDescription = "出院医嘱1";
            this.m_txtOutAdvice1.BackColor = System.Drawing.Color.White;
            this.m_txtOutAdvice1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOutAdvice1.ForeColor = System.Drawing.Color.Black;
            this.m_txtOutAdvice1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOutAdvice1.Location = new System.Drawing.Point(90, 513);
            this.m_txtOutAdvice1.m_BlnIgnoreUserInfo = false;
            this.m_txtOutAdvice1.m_BlnPartControl = false;
            this.m_txtOutAdvice1.m_BlnReadOnly = false;
            this.m_txtOutAdvice1.m_BlnUnderLineDST = false;
            this.m_txtOutAdvice1.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOutAdvice1.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOutAdvice1.m_IntCanModifyTime = 6;
            this.m_txtOutAdvice1.m_IntPartControlLength = 0;
            this.m_txtOutAdvice1.m_IntPartControlStartIndex = 0;
            this.m_txtOutAdvice1.m_StrUserID = "";
            this.m_txtOutAdvice1.m_StrUserName = "";
            this.m_txtOutAdvice1.Name = "m_txtOutAdvice1";
            this.m_txtOutAdvice1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtOutAdvice1.Size = new System.Drawing.Size(692, 56);
            this.m_txtOutAdvice1.TabIndex = 10000020;
            this.m_txtOutAdvice1.Text = "";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(20, 516);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(70, 14);
            this.label25.TabIndex = 10000023;
            this.label25.Text = "出院医嘱:";
            // 
            // m_txtDoctorSign
            // 
            this.m_txtDoctorSign.AccessibleName = "NoDefault";
            this.m_txtDoctorSign.BackColor = System.Drawing.Color.White;
            this.m_txtDoctorSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDoctorSign.ForeColor = System.Drawing.Color.Black;
            this.m_txtDoctorSign.Location = new System.Drawing.Point(265, 579);
            this.m_txtDoctorSign.Name = "m_txtDoctorSign";
            this.m_txtDoctorSign.ReadOnly = true;
            this.m_txtDoctorSign.Size = new System.Drawing.Size(191, 23);
            this.m_txtDoctorSign.TabIndex = 10000025;
            // 
            // m_cmdDoctorSign
            // 
            this.m_cmdDoctorSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdDoctorSign.DefaultScheme = true;
            this.m_cmdDoctorSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdDoctorSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdDoctorSign.Hint = "";
            this.m_cmdDoctorSign.Location = new System.Drawing.Point(167, 578);
            this.m_cmdDoctorSign.Name = "m_cmdDoctorSign";
            this.m_cmdDoctorSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdDoctorSign.Size = new System.Drawing.Size(92, 24);
            this.m_cmdDoctorSign.TabIndex = 10000024;
            this.m_cmdDoctorSign.Tag = "1";
            this.m_cmdDoctorSign.Text = "医师签名:";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Width = 0;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Width = 100;
            // 
            // m_dtOutHospital24
            // 
            this.m_dtOutHospital24.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.m_dtOutHospital24.BorderColor = System.Drawing.Color.Black;
            this.m_dtOutHospital24.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtOutHospital24.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_dtOutHospital24.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtOutHospital24.DropButtonForeColor = System.Drawing.SystemColors.ControlText;
            this.m_dtOutHospital24.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtOutHospital24.Font = new System.Drawing.Font("宋体", 12F);
            this.m_dtOutHospital24.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtOutHospital24.Location = new System.Drawing.Point(459, 148);
            this.m_dtOutHospital24.m_BlnOnlyTime = false;
            this.m_dtOutHospital24.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtOutHospital24.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtOutHospital24.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtOutHospital24.Name = "m_dtOutHospital24";
            this.m_dtOutHospital24.ReadOnly = false;
            this.m_dtOutHospital24.Size = new System.Drawing.Size(192, 22);
            this.m_dtOutHospital24.TabIndex = 10000026;
            this.m_dtOutHospital24.TextBackColor = System.Drawing.Color.White;
            this.m_dtOutHospital24.TextForeColor = System.Drawing.Color.Black;
            this.m_dtOutHospital24.Visible = false;
            // 
            // frmEMR_OutHospitalIn24Hours
            // 
            this.ClientSize = new System.Drawing.Size(801, 689);
            this.Controls.Add(this.m_txtInInstance);
            this.Controls.Add(this.m_dtOutHospital24);
            this.Controls.Add(this.m_txtDoctorSign);
            this.Controls.Add(this.m_cmdDoctorSign);
            this.Controls.Add(this.m_txtOutAdvice1);
            this.Controls.Add(this.m_txtOutDiagnose1);
            this.Controls.Add(this.m_txtInDiagnose1);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.m_lblInHospitalDate);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.m_lblIsMarried);
            this.Controls.Add(this.m_lblOfficeName);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.m_lblOccupation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.m_lblNation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_lblBirthPlace);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.m_lblHomeAddress);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.m_txtMainDes);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.m_txtDiagnosisProcess);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.m_txtOutInstance);
            this.Controls.Add(this.label25);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEMR_OutHospitalIn24Hours";
            this.Text = "24小时内入出院记录";
            this.Load += new System.EventHandler(this.frmEMR_OutHospitalIn24Hours_Load);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.label25, 0);
            this.Controls.SetChildIndex(this.m_txtOutInstance, 0);
            this.Controls.SetChildIndex(this.label22, 0);
            this.Controls.SetChildIndex(this.label19, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.m_txtDiagnosisProcess, 0);
            this.Controls.SetChildIndex(this.label18, 0);
            this.Controls.SetChildIndex(this.label17, 0);
            this.Controls.SetChildIndex(this.m_txtMainDes, 0);
            this.Controls.SetChildIndex(this.m_lblGetDataTime, 0);
            this.Controls.SetChildIndex(this.m_dtpGetDataTime, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.m_lblHomeAddress, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.m_lblBirthPlace, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.m_dtpCreateDate, 0);
            this.Controls.SetChildIndex(this.m_trvCreateDate, 0);
            this.Controls.SetChildIndex(this.lblCreateDateTitle, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.m_lblNation, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.m_lblOccupation, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.m_lblOfficeName, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.m_lblIsMarried, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.m_lblInHospitalDate, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.label16, 0);
            this.Controls.SetChildIndex(this.m_txtInDiagnose1, 0);
            this.Controls.SetChildIndex(this.m_txtOutDiagnose1, 0);
            this.Controls.SetChildIndex(this.m_txtOutAdvice1, 0);
            this.Controls.SetChildIndex(this.m_cmdDoctorSign, 0);
            this.Controls.SetChildIndex(this.m_txtDoctorSign, 0);
            this.Controls.SetChildIndex(this.m_dtOutHospital24, 0);
            this.Controls.SetChildIndex(this.m_txtInInstance, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region 清空特殊记录信息
		/// <summary>
		/// 清空特殊记录信息，并重置记录控制状态为不控制。
		/// </summary>
		protected override void m_mthClearRecordInfo()
		{
			m_strCurrentOpenDate = "";

			m_txtMainDes.m_mthClearText();
			m_txtInInstance.m_mthClearText();
			m_txtInDiagnose1.m_mthClearText();
			m_txtDiagnosisProcess.m_mthClearText();
			m_txtOutInstance.m_mthClearText();
			m_txtOutDiagnose1.m_mthClearText();
			m_txtOutAdvice1.m_mthClearText();
			m_dtpCreateDate.Value = DateTime.Now;
            m_txtDoctorSign.Clear();
            m_txtDoctorSign.Tag = null;
		}
		#endregion

		#region 重写无需实现的方法

		#region 获取当前的特殊病程记录信息
		/// <summary>
		/// 获取当前的特殊病程记录信息
		/// </summary>
		/// <returns></returns>
		public override clsDiseaseTrackInfo m_objGetDiseaseTrackInfo()
		{
			return null;
		}
		#endregion

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
		#endregion

		#region 从界面获取特殊记录的值
		/// <summary>
		/// 从界面获取特殊记录的值。如果界面值出错，返回null。
		/// </summary>
		/// <returns></returns>
		protected override clsTrackRecordContent m_objGetContentFromGUI()
		{
			//界面参数校验
			if(m_objCurrentPatient==null || m_ObjCurrentEmrPatientSession == null)				
				return null;
            
			clsEMR_OutHospitalIn24HoursValue objContent = new clsEMR_OutHospitalIn24HoursValue();
			objContent.m_strREPRESENTOR = m_cboRepresentor.Text;
			objContent.m_dtmRECORDDATE=DateTime.Parse(m_dtpCreateDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));	
            #region 是否可以无痕迹修改
            if (chkModifyWithoutMatk.Checked)
                objContent.m_intMarkStatus = 0;
            else
                objContent.m_intMarkStatus = 1;
            #endregion
			objContent.m_strMAINDESCRIPTION = m_txtMainDes.Text;
			objContent.m_strMAINDESCRIPTIONXML = m_txtMainDes.m_strGetXmlText();

			objContent.m_strINHOSPITALINSTANCE = m_txtInInstance.Text;
			objContent.m_strINHOSPITALINSTANCEXML = m_txtInInstance.m_strGetXmlText();

			objContent.m_strINHOSPITALDIAGNOSE1 = m_txtInDiagnose1.Text;
			objContent.m_strINHOSPITALDIAGNOSE1XML = m_txtInDiagnose1.m_strGetXmlText();

            //objContent.m_strINHOSPITALDIAGNOSE2 = m_txtInDiagnose2.Text;
            //objContent.m_strINHOSPITALDIAGNOSE2XML = m_txtInDiagnose2.m_strGetXmlText();

			objContent.m_strDIAGNOSECORUSE = m_txtDiagnosisProcess.Text;
			objContent.m_strDIAGNOSECORUSEXML = m_txtDiagnosisProcess.m_strGetXmlText();

			objContent.m_strOUTHOSPITALINSTANCE = m_txtOutInstance.Text;
			objContent.m_strOUTHOSPITALINSTANCEXML = m_txtOutInstance.m_strGetXmlText();

			objContent.m_strOUTHOSPITALDIAGNOSE1 = m_txtOutDiagnose1.Text;
			objContent.m_strOUTHOSPITALDIAGNOSE1XML = m_txtOutDiagnose1.m_strGetXmlText();

            //objContent.m_strOUTHOSPITALDIAGNOSE2 = m_txtOutDiagnose2.Text;
            //objContent.m_strOUTHOSPITALDIAGNOSE2XML = m_txtOutDiagnose2.m_strGetXmlText();

			objContent.m_strOUTHOSPITALADVICE1 = m_txtOutAdvice1.Text;
			objContent.m_strOUTHOSPITALADVICE1XML = m_txtOutAdvice1.m_strGetXmlText();

            //objContent.m_strOUTHOSPITALADVICE2 = m_txtOutAdvice2.Text;
            //objContent.m_strOUTHOSPITALADVICE2XML = m_txtOutAdvice2.m_strGetXmlText();

            objContent.m_dtmOutHospital24Hours = DateTime.Parse(this.m_dtOutHospital24.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            


			if(m_txtDoctorSign.Tag!=null && !(string.IsNullOrEmpty(m_txtDoctorSign.Text.Trim())))
			{
				objContent.m_strDOCTORSIGN = ((clsEmrEmployeeBase_VO) m_txtDoctorSign.Tag).m_strEMPNO_CHR;
				objContent.m_strDOCTORSIGNNAME = m_txtDoctorSign.Text;
                objContent.m_strModifyUserID = ((clsEmrEmployeeBase_VO)m_txtDoctorSign.Tag).m_strEMPNO_CHR;
			}
			else 
			{
				clsPublicFunction.ShowInformationMessageBox("必须医师签名!");
				return null;
			}
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

			clsEMR_OutHospitalIn24HoursValue objContent = (clsEMR_OutHospitalIn24HoursValue)p_objContent;
			m_strCurrentOpenDate =objContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss");
			m_dtpCreateDate.Value = objContent.m_dtmRECORDDATE;
			m_cboRepresentor.Text = objContent.m_strREPRESENTOR;

			m_txtMainDes.m_mthSetNewText(objContent.m_strMAINDESCRIPTION, objContent.m_strMAINDESCRIPTIONXML);
			m_txtInInstance.m_mthSetNewText(objContent.m_strINHOSPITALINSTANCE, objContent.m_strINHOSPITALINSTANCEXML);
			m_txtInDiagnose1.m_mthSetNewText(objContent.m_strINHOSPITALDIAGNOSE1, objContent.m_strINHOSPITALDIAGNOSE1XML);
            //m_txtInDiagnose2.m_mthSetNewText(objContent.m_strINHOSPITALDIAGNOSE2, objContent.m_strINHOSPITALDIAGNOSE2XML);
			m_txtDiagnosisProcess.m_mthSetNewText(objContent.m_strDIAGNOSECORUSE, objContent.m_strDIAGNOSECORUSEXML);
			m_txtOutInstance.m_mthSetNewText(objContent.m_strOUTHOSPITALINSTANCE, objContent.m_strOUTHOSPITALINSTANCEXML);
			m_txtOutDiagnose1.m_mthSetNewText(objContent.m_strOUTHOSPITALDIAGNOSE1, objContent.m_strOUTHOSPITALDIAGNOSE1XML);
            //m_txtOutDiagnose2.m_mthSetNewText(objContent.m_strOUTHOSPITALDIAGNOSE2, objContent.m_strOUTHOSPITALDIAGNOSE2XML);
			m_txtOutAdvice1.m_mthSetNewText(objContent.m_strOUTHOSPITALADVICE1, objContent.m_strOUTHOSPITALADVICE1XML);
            //m_txtOutAdvice2.m_mthSetNewText(objContent.m_strOUTHOSPITALADVICE2, objContent.m_strOUTHOSPITALADVICE2XML);
            if (com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_StrCurrentHospitalNO != "450101001")
            {
                m_dtOutHospital24.Visible = true;
                m_dtOutHospital24.Enabled = true;
                if (objContent.m_dtmOutHospital24Hours == DateTime.MinValue || objContent.m_dtmOutHospital24Hours == new DateTime(1900,1,1))
                {
                    this.m_dtOutHospital24.Value = DateTime.Now;
                }
                else
                {
                    this.m_dtOutHospital24.Value = objContent.m_dtmOutHospital24Hours;
                }
            }

            clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
            objEmployeeSign.m_lngGetEmpByNO(objContent.m_strDOCTORSIGN, out objEmpVO);
            if (objEmpVO != null)
            {
                m_txtDoctorSign.Tag = objEmpVO;
                m_txtDoctorSign.Text = objEmpVO.m_strGetTechnicalRankAndName;
            }
		}
		#endregion

		#region 获取当前病人的作废内容
		// <summary>
		/// 获取当前病人的作废内容
		/// </summary>
		/// <param name="p_dtmRecordDate">记录日期，此处表示CreateDate</param>
		/// <param name="p_intFormID">窗体ID</param>
		protected override void m_mthGetDeactiveContent(DateTime p_dtmRecordDate,int p_intFormID)
		{
			if(m_objBaseCurrentPatient==null || m_objBaseCurrentPatient.m_StrInPatientID==null || m_objBaseCurrentPatient.m_DtmSelectedInDate==DateTime.MinValue|| p_dtmRecordDate==DateTime.MinValue )
			{
				clsPublicFunction.ShowInformationMessageBox("参数错误！");
				return ;
			}			
		
			clsTrackRecordContent objContent=null;
			long lngRes=m_objDiseaseTrackDomain.m_lngGetDeleteRecordContent(m_objBaseCurrentPatient.m_StrInPatientID,m_objBaseCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"),p_dtmRecordDate.ToString("yyyy-MM-dd HH:mm:ss"),out objContent);
			if(lngRes>0 && objContent!=null)
			{
				m_mthSetDeletedGUIFromContent(objContent);			
			}		
				
		}

		protected override void m_mthSetDeletedGUIFromContent(clsTrackRecordContent p_objContent)
		{
			if(p_objContent ==null)
				return;
			clsEMR_OutHospitalIn24HoursValue objContent=(clsEMR_OutHospitalIn24HoursValue)p_objContent;

			m_dtpCreateDate.Value = objContent.m_dtmRECORDDATE;
			m_cboRepresentor.Text = objContent.m_strREPRESENTOR;
			m_txtMainDes.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strMAINDESCRIPTION, objContent.m_strMAINDESCRIPTIONXML);
			m_txtInInstance.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strINHOSPITALINSTANCE, objContent.m_strINHOSPITALINSTANCEXML);
			m_txtInDiagnose1.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strINHOSPITALDIAGNOSE1, objContent.m_strINHOSPITALDIAGNOSE1XML);
            //m_txtInDiagnose2.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strINHOSPITALDIAGNOSE2, objContent.m_strINHOSPITALDIAGNOSE2XML);
			m_txtDiagnosisProcess.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDIAGNOSECORUSE, objContent.m_strDIAGNOSECORUSEXML);
			m_txtOutInstance.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOUTHOSPITALINSTANCE, objContent.m_strOUTHOSPITALINSTANCEXML);
			m_txtOutDiagnose1.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOUTHOSPITALDIAGNOSE1, objContent.m_strOUTHOSPITALDIAGNOSE1XML);
            //m_txtOutDiagnose2.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOUTHOSPITALDIAGNOSE2, objContent.m_strOUTHOSPITALDIAGNOSE2XML);
			m_txtOutAdvice1.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOUTHOSPITALADVICE1, objContent.m_strOUTHOSPITALADVICE1XML);
            //m_txtOutAdvice2.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOUTHOSPITALADVICE2, objContent.m_strOUTHOSPITALADVICE2XML);

            clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
            objEmployeeSign.m_lngGetEmpByNO(objContent.m_strDOCTORSIGN, out objEmpVO);
            if (objEmpVO != null)
            {
                m_txtDoctorSign.Tag = objEmpVO;
                m_txtDoctorSign.Text = objContent.m_strDOCTORSIGNNAME;
            }
		}
		#endregion

		private int m_intFormID=114;
		public override int m_IntFormID
		{
			get
			{
				return m_intFormID;
			}
		}

		/// <summary>
		/// 获取病程记录的领域层实例
		/// </summary>
		/// <returns></returns>
		protected override clsDiseaseTrackDomain m_objGetDiseaseTrackDomain()
		{
			//获取病程记录的领域层实例
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.OutHospitalIn24Hours);					
		}

		#region 把选择时间记录内容重新整理为完全正确的内容
		/// <summary>
		/// 把选择时间记录内容重新整理为完全正确的内容。
		/// </summary>
		/// <param name="p_objRecordContent"></param>
		protected override void m_mthReAddNewRecord(clsTrackRecordContent p_objRecordContent)
		{
			//把选择时间记录内容重新整理为完全正确的内容，由子窗体重载实现。
			clsEMR_OutHospitalIn24HoursValue objContent=(clsEMR_OutHospitalIn24HoursValue)p_objRecordContent;
			//把表单值赋值到界面，由子窗体重载实现

			m_dtpCreateDate.Value = objContent.m_dtmRECORDDATE;
			m_cboRepresentor.Text = objContent.m_strREPRESENTOR;
			m_txtMainDes.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strMAINDESCRIPTION, objContent.m_strMAINDESCRIPTIONXML);
			m_txtInInstance.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strINHOSPITALINSTANCE, objContent.m_strINHOSPITALINSTANCEXML);
			m_txtInDiagnose1.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strINHOSPITALDIAGNOSE1, objContent.m_strINHOSPITALDIAGNOSE1XML);
            //m_txtInDiagnose2.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strINHOSPITALDIAGNOSE2, objContent.m_strINHOSPITALDIAGNOSE2XML);
			m_txtDiagnosisProcess.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDIAGNOSECORUSE, objContent.m_strDIAGNOSECORUSEXML);
			m_txtOutInstance.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOUTHOSPITALINSTANCE, objContent.m_strOUTHOSPITALINSTANCEXML);
			m_txtOutDiagnose1.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOUTHOSPITALDIAGNOSE1, objContent.m_strOUTHOSPITALDIAGNOSE1XML);
            //m_txtOutDiagnose2.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOUTHOSPITALDIAGNOSE2, objContent.m_strOUTHOSPITALDIAGNOSE2XML);
			m_txtOutAdvice1.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOUTHOSPITALADVICE1, objContent.m_strOUTHOSPITALADVICE1XML);
            //m_txtOutAdvice2.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOUTHOSPITALADVICE2, objContent.m_strOUTHOSPITALADVICE2XML);

            clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
            objEmployeeSign.m_lngGetEmpByNO(objContent.m_strDOCTORSIGN, out objEmpVO);
            if (objEmpVO != null)
            {
                m_txtDoctorSign.Tag = objEmpVO;
                m_txtDoctorSign.Text = objContent.m_strDOCTORSIGNNAME;
            }
		}		
		#endregion

		// 获取选择已经删除记录的窗体标题
		public override string m_strReloadFormTitle()
		{
			//由子窗体重载实现
			return	"24小时内入出院记录";
		}

		#region 当选择根节点时,设置特殊的默认值
		/// <summary>
		/// 当选择根节点时,设置特殊的默认值(若子窗体需要,则重载实现)
		/// </summary>
		protected override void m_mthSelectRootNode()
		{
			#region 初步诊断默认值
            if (m_objCurrentPatient != null && m_ObjCurrentEmrPatientSession != null)
			{
                DateTime dtmInDate = m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate;
                if (m_ObjLastEmrPatientSession != null)
                {
                    dtmInDate = m_ObjLastEmrPatientSession.m_dtmEMRInpatientDate;
                }

                clsInPatientCaseHisoryDefaultValue[] objInPatientCaseHisoryDefaultValueArr = new clsInPatientCaseHisoryDefaultDomain().lngGetAllInPatientCaseHisoryDefault(m_objCurrentPatient.m_StrInPatientID, dtmInDate.ToString("yyyy-MM-dd HH:mm:ss"));
				if(objInPatientCaseHisoryDefaultValueArr !=null && objInPatientCaseHisoryDefaultValueArr.Length>0)
				{
					m_txtInDiagnose1.Text=objInPatientCaseHisoryDefaultValueArr[0].m_strPrimaryDiagnose;
				}
			}
			#endregion 初步诊断默认值
		}
		#endregion

		#region 窗体Load事件
		private void frmEMR_OutHospitalIn24Hours_Load(object sender, System.EventArgs e)
		{
			m_mthfrmLoad();

			if(m_objCurrentPatient !=null)
			{
                m_lblInHospitalDate.Text = m_ObjCurrentEmrPatientSession.m_dtmHISInpatientDate.ToString("yyyy年MM月dd日");
                m_mthSetOutHospitalDate();
			}			

			this.m_dtpCreateDate.m_EnmVisibleFlag=MDIParent.s_ObjRecordDateTimeInfo.m_enmGetRecordTimeFlag(this.Name);
			this.m_dtpCreateDate.m_mthResetSize();

			m_trvCreateDate.Focus();
        }
        private void m_mthSetOutHospitalDate()
        {
            m_mthGetSetlectedOutDate();
            if (m_dtmOutHospitalDate == new DateTime(1900, 1, 1) || m_dtmOutHospitalDate == DateTime.MinValue)
                m_dtOutHospital24.Visible = false;
            else
            {
                m_dtOutHospital24.Visible = true;
                m_dtOutHospital24.Enabled = false;
                m_dtOutHospital24.Value = m_dtmOutHospitalDate;
            }
            if (com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_StrCurrentHospitalNO != "450101001")//不是南宁
            {
                m_dtOutHospital24.Visible = true;
                m_dtOutHospital24.Enabled = true;
            }
        }
		#endregion

		#region 记录病人信息

        /// <summary>
        /// 仅设置病人的基本信息
        /// </summary>
        /// <param name="p_objSelectedPatient"></param>
        protected override void m_mthOnlySetPatientInfo(clsPatient p_objSelectedPatient)
        {
            m_lblNation.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrNation;
            m_lblBirthPlace.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrHomeplace;
            m_lblIsMarried.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrMarried;
            m_lblOccupation.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrOccupation;
            m_lblOfficeName.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrOffice_name;
            m_lblOfficePhone.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrOfficePhone;
            m_lblHomeAddress.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrHomeAddress;
            m_lblHomePhone.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrHomePhone;
            m_lblID.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrIDCard;
        }
		/// <summary>
		/// 设置病人表单信息
		/// </summary>
		/// <param name="p_objSelectedPatient"></param>
		protected override void m_mthSetPatientFormInfo(clsPatient p_objSelectedPatient)
		{
			//判断病人信息是否为null，如果是，直接返回。
			if(p_objSelectedPatient == null || m_objDiseaseTrackDomain==null)
				return;  
			base.m_mthSetPatientFormInfo(p_objSelectedPatient);

            m_lblInHospitalDate.Text = p_objSelectedPatient.m_DtmSelectedHISInDate.ToString("yyyy年MM月dd日 HH:mm");
            m_mthSetOutHospitalDate();
		}
		#endregion

        #region 外部打印.

        //System.Drawing.Printing.PrintDocument m_pdcPrintDocument;
        private void m_mthfrmLoad()
        {
            if (m_pdcPrintDocument == null)
                this.m_pdcPrintDocument = new System.Drawing.Printing.PrintDocument();
            this.m_pdcPrintDocument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcPrintDocument_BeginPrint);
            this.m_pdcPrintDocument.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcPrintDocument_EndPrint);
            this.m_pdcPrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.m_pdcPrintDocument_PrintPage);
        }
        private void m_pdcPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            objPrintTool.m_mthPrintPage(e);
        }

        private void m_pdcPrintDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            objPrintTool.m_mthBeginPrint(e);
        }

        private void m_pdcPrintDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            objPrintTool.m_mthEndPrint(e);
        }

        private bool m_blnHasInitPrintTool = false;
        clsEMR_OutHospitalIn24HoursPrintToolCS objPrintTool;
        private void m_mthDemoPrint_FromDataSource()
        {
            if (m_blnHasInitPrintTool == false)
            {
                objPrintTool = new clsEMR_OutHospitalIn24HoursPrintToolCS();
                objPrintTool.m_mthInitPrintTool(null);
                m_blnHasInitPrintTool = true;
            }
            if (m_objBaseCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
                objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, DateTime.MinValue, DateTime.MinValue);
            else
            {
                m_objBaseCurrentPatient.m_StrHISInPatientID = m_ObjCurrentEmrPatientSession.m_strHISInpatientId;
                m_objBaseCurrentPatient.m_DtmSelectedHISInDate = m_ObjCurrentEmrPatientSession.m_dtmHISInpatientDate;
                if (m_objCurrentRecordContent == null)
                    objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, m_objBaseCurrentPatient.m_DtmSelectedInDate, DateTime.MinValue);
                else
                    objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, m_objBaseCurrentPatient.m_DtmSelectedInDate, m_objCurrentRecordContent.m_dtmOpenDate);
            }
            objPrintTool.m_mthInitPrintContent();

            m_mthStartPrint_this();
        }

        private void m_mthStartPrint_this()
        {
            if (m_blnDirectPrint)
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

        protected override long m_lngSubPrint()//代替原窗体中的同名打印函数
        {
            m_mthDemoPrint_FromDataSource();
            return 1;
        }
        #endregion 外部打印.

		#region 审核
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

		protected override bool m_BlnCanApprove
		{
			get
			{
				return true;
			}
		}		
		#endregion 

		#region 数据复用
		/// <summary>
		/// 数据复用
		/// </summary>
		/// <param name="p_objSelectedPatient"></param>
		protected override void m_mthDataShare(clsPatient p_objSelectedPatient)
		{
			clsInPatientCaseHisoryDefaultValue [] objInPatientCaseDefaultValue = new clsInPatientCaseHisoryDefaultDomain().lngGetAllInPatientCaseHisoryDefault(p_objSelectedPatient.m_StrInPatientID,p_objSelectedPatient.m_DtmSelectedInDate.ToString());
			if(objInPatientCaseDefaultValue !=null && objInPatientCaseDefaultValue.Length >0)
			{
				this.m_txtInDiagnose1.Text = objInPatientCaseDefaultValue[0].m_strPrimaryDiagnose;
				this.m_txtOutDiagnose1.Text = objInPatientCaseDefaultValue[0].m_strFinallyDiagnose!= "" ? objInPatientCaseDefaultValue[0].m_strFinallyDiagnose : objInPatientCaseDefaultValue[0].m_strPrimaryDiagnose;
			}
		}
		#endregion

		#region 属性
		protected override enmApproveType m_EnmAppType
		{
			get{return enmApproveType.CaseHistory;}
		}
		protected override string m_StrRecorder_ID
		{
			get
			{
				if(m_txtDoctorSign.Tag != null)
					return ((clsEmrEmployeeBase_VO)m_txtDoctorSign.Tag).m_strEMPNO_CHR.Trim();
				return "";
			}
		}
		#endregion 属性

		#region  获取病人出院时间，暂时先在各个窗体查询
		private DateTime m_dtmOutHospitalDate;
		/// <summary>
		/// 获取病人出院时间，暂时先在各个窗体查询
		/// </summary>
		/// <returns></returns>
		private long m_mthGetSetlectedOutDate()
		{
			m_dtmOutHospitalDate = new DateTime(1900,1,1);
            string strRegisterID = m_objCurrentPatient.m_StrRegisterId;
			long lngRes = 0;

            clsPatientManagerService objServ =
                (clsPatientManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPatientManagerService));

            //lngRes = objServ.m_lngGetRegisterIDByPatient(m_objCurrentPatient.m_StrPatientID, m_objCurrentPatient.m_DtmSelectedHISInDate.ToString("yyyy-MM-dd HH:mm:ss"), out strRegisterID);
			
			lngRes = objServ.m_lngGetOutHospitalDate(strRegisterID, out m_dtmOutHospitalDate);
			objServ = null;
			return lngRes;
		}
		#endregion

        #region 作废重做

        protected override bool m_blnSubReuse(clsInactiveRecordInfo_VO p_objSelectedValue)
        {
            bool blnIsOK = false;
            if (p_objSelectedValue != null)
            {
                clsTrackRecordContent m_objContent = new clsEMR_OutHospitalIn24HoursValue();

                long lngRes = m_objGetDiseaseTrackDomain().m_lngGetDeleteRecordContent(p_objSelectedValue.m_StrInpatientId, p_objSelectedValue.m_DtmInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"), p_objSelectedValue.m_DtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"), out m_objContent);
                if (lngRes <= 0 || m_objContent == null)
                {
                    switch (lngRes)
                    {
                        case (long)(iCareData.enmOperationResult.Not_permission):
                            m_mthShowNotPermitted(); break;
                        case (long)(iCareData.enmOperationResult.DB_Fail):
                            m_mthShowDBError(); break;
                    }
                    return blnIsOK;
                }
                clsEMR_OutHospitalIn24HoursValue p_objContent = (clsEMR_OutHospitalIn24HoursValue)m_objContent;
                this.m_lblInHospitalDate.Text = p_objContent.m_dtmInPatientDate.ToString("yyyy-MM-dd hh:mm");
                this.m_dtOutHospital24.Text = p_objContent.m_dtmOutHospital24Hours.ToString("yyyy-MM-dd hh:mm");
                this.m_txtMainDes.Text = p_objContent.m_strMAINDESCRIPTION;
                this.m_txtInInstance.Text = p_objContent.m_strINHOSPITALINSTANCE;
                this.m_txtInDiagnose1.Text = p_objContent.m_strINHOSPITALDIAGNOSE1;
                this.m_txtDiagnosisProcess.Text=p_objContent.m_strDIAGNOSECORUSE;
                this.m_txtOutInstance.Text=p_objContent.m_strOUTHOSPITALINSTANCE;
                this.m_txtOutDiagnose1.Text=p_objContent.m_strOUTHOSPITALDIAGNOSE1;
                this.m_txtOutAdvice1.Text=p_objContent.m_strOUTHOSPITALADVICE1;
                this.m_txtDoctorSign.Text=p_objContent.m_strDOCTORSIGN;
                this.m_dtpCreateDate.Text=p_objContent.m_dtmCreateDate.ToString("yyyy-MM-dd hh:mm");


                //clsEmrSignToolCollection m_objSign = new clsEmrSignToolCollection();


                blnIsOK = true;
            }
            return blnIsOK;
        }

        //infPrintRecord objPrintTool;
        protected override void m_mthSubPreviewInactiveRecord(IWin32Window p_infOwner, clsInactiveRecordInfo_VO p_objSelectedValue)
        {
            if (p_objSelectedValue == null) return;
            objPrintTool = new clsEMR_OutHospitalIn24HoursPrintToolCS();

            if (m_objBaseCurrentPatient != null)
            {
                objPrintTool.m_mthInitPrintTool(null);
                objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient,
                    p_objSelectedValue.m_DtmInpatientDate,
                    p_objSelectedValue.m_DtmOpenDate);
                clsPrintInfo_OutHospitalIn24Hours objPrintInfo = new clsPrintInfo_OutHospitalIn24Hours();


                //objPrintInfo.m_dtmHISInDate = p_objSelectedValue.m_DtmInpatientDate;  //???
                objPrintInfo.m_dtmInPatientDate = p_objSelectedValue.m_DtmInpatientDate;
                objPrintInfo.m_dtmOpenDate = p_objSelectedValue.m_DtmOpenDate;
                //objPrintInfo.m_strAge = p_objSelectedValue;           
                //objPrintInfo.m_strAreaName
                //objPrintInfo.m_strBedName
                //objPrintInfo.m_strDeptName=
                //objPrintInfo.m_strHISInPatientID=
                //objPrintInfo.m_strInPatentID = p_objSelectedValue.m_StrInpatientId;
                //objPrintInfo.m_strPatientName =
                //objPrintInfo.m_strSex=
                
                clsTrackRecordContent p_objContent = new clsEMR_OutHospitalIn24HoursValue();
                long lngRes = m_objGetDiseaseTrackDomain().m_lngGetDeleteRecordContent(p_objSelectedValue.m_StrInpatientId, p_objSelectedValue.m_DtmInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"), p_objSelectedValue.m_DtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"), out p_objContent);
                clsEMR_OutHospitalIn24HoursValue objContent = (clsEMR_OutHospitalIn24HoursValue)p_objContent;
                //objPrintInfo.m_objContent = objContent;
                objPrintInfo.m_objRecordContent = objContent;
                //objPrintInfo.m_blnIsFirstPrint = false;
                
                objPrintTool.m_mthSetPrintContent(objPrintInfo);



                m_mthStartPrint();
                //ppdPrintPreview.Document = m_pdcPrintDocument;
                //ppdPrintPreview.ShowDialog(p_infOwner);
            }
        }

        protected override clsInactiveRecordInfo_VO[] m_objSubGetAllInactiveInfo(clsInactiveRecordInfo_VO p_objSelectedValue)
        {
            clsInactiveRecordInfo_VO[] objArr = null;

            new clsOutHospitalIn24HoursDomain().m_lngGetAllInactiveInfo(p_objSelectedValue.m_StrInpatientId, p_objSelectedValue.m_DtmInpatientDate, out objArr);
            return objArr;
        }
        public override bool m_blnIsNewSetInactiveForm
        {
            get { return true; }
        }
        #endregion 作废重做
	}
}
