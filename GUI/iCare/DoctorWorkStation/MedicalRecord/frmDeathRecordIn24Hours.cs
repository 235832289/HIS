using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using com.digitalwave.emr.BEDExplorer;
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
	/// frmDeathRecordIn24Hours 的摘要说明。
	/// Description:入院24小时内死亡记录
	/// Author:Jock
	/// Date:05-12-27
	/// </summary>
	public class frmDeathRecordIn24Hours : iCare.frmDiseaseTrackBase
	{
		#region Control 
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label lblFolk;
		private System.Windows.Forms.Label lblNative;
		private System.Windows.Forms.Label lblOccupation;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label lblIsMarry;
		private com.digitalwave.controls.ctlRichTextBox m_txtInHospitalDiagnose;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblEnterprise;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblCorpTel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lblFamilyTel;
		private System.Windows.Forms.Label lblFamilyAddress;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label lblIDCard;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label12;
		private com.digitalwave.controls.ctlRichTextBox m_txtInHospitalInstance;
		private com.digitalwave.controls.ctlRichTextBox m_txtMainDescription;
		private System.Windows.Forms.Label label21;
		private com.digitalwave.controls.ctlRichTextBox m_txtSalvageInstance;
		private System.Windows.Forms.Label label22;
		private com.digitalwave.controls.ctlRichTextBox m_txtDeathCausation;
		private System.Windows.Forms.Label label23;
		private com.digitalwave.controls.ctlRichTextBox m_txtDeathDiagonse;
		private TextBox m_txtDoctorSign;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private PinkieControls.ButtonXP m_cmdDoctorSign;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion
		private clsTrackRecordContent p_objContent;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboRepresentor;
		protected com.digitalwave.Utility.Controls.ctlTimePicker m_dtpInPatientTime1;
        private System.Windows.Forms.Label m_lblInPatientTime;
		protected com.digitalwave.Utility.Controls.ctlTimePicker m_dtpOutHospitalDate1;
		private System.Windows.Forms.Label m_lblOutHospitalDate;
        private com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
        private clsEmrSignToolCollection m_objSign;
	
		public frmDeathRecordIn24Hours()
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
			m_mthSetRichTextBoxAttribInControl(this);

			this.Text="入院24小时内死亡记录";			
			this.m_lblForTitle.Text=this.Text;	

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
            this.label9 = new System.Windows.Forms.Label();
            this.lblFolk = new System.Windows.Forms.Label();
            this.lblNative = new System.Windows.Forms.Label();
            this.lblOccupation = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblIsMarry = new System.Windows.Forms.Label();
            this.m_txtInHospitalDiagnose = new com.digitalwave.controls.ctlRichTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEnterprise = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCorpTel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblFamilyTel = new System.Windows.Forms.Label();
            this.lblFamilyAddress = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblIDCard = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_txtInHospitalInstance = new com.digitalwave.controls.ctlRichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.m_txtMainDescription = new com.digitalwave.controls.ctlRichTextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.m_txtSalvageInstance = new com.digitalwave.controls.ctlRichTextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.m_txtDeathCausation = new com.digitalwave.controls.ctlRichTextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.m_txtDeathDiagonse = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtDoctorSign = new System.Windows.Forms.TextBox();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.m_cmdDoctorSign = new PinkieControls.ButtonXP();
            this.m_dtpOutHospitalDate1 = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.m_cboRepresentor = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_dtpInPatientTime1 = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.m_lblInPatientTime = new System.Windows.Forms.Label();
            this.m_lblOutHospitalDate = new System.Windows.Forms.Label();
            this.m_pnlNewBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_trvCreateDate
            // 
            this.m_trvCreateDate.LineColor = System.Drawing.Color.Black;
            this.m_trvCreateDate.Location = new System.Drawing.Point(7, 35);
            this.m_trvCreateDate.Size = new System.Drawing.Size(190, 107);
            // 
            // lblCreateDateTitle
            // 
            this.lblCreateDateTitle.Location = new System.Drawing.Point(8, 151);
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.Enabled = false;
            this.m_dtpCreateDate.Location = new System.Drawing.Point(81, 147);
            // 
            // m_dtpGetDataTime
            // 
            this.m_dtpGetDataTime.Location = new System.Drawing.Point(265, 579);
            // 
            // m_lblGetDataTime
            // 
            this.m_lblGetDataTime.Enabled = false;
            this.m_lblGetDataTime.Location = new System.Drawing.Point(141, 583);
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(295, 211);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(284, 216);
            this.lblAge.Size = new System.Drawing.Size(84, 19);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(264, 213);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(235, 217);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(264, 213);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(268, 216);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(306, 216);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(249, 210);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(254, 217);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(10, 24);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(267, 207);
            this.txtInPatientID.Size = new System.Drawing.Size(43, 23);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(254, 213);
            this.m_txtPatientName.ReadOnly = true;
            this.m_txtPatientName.Size = new System.Drawing.Size(10, 23);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(261, 210);
            this.m_txtBedNO.Size = new System.Drawing.Size(15, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(248, 208);
            this.m_cboArea.Size = new System.Drawing.Size(10, 23);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Enabled = false;
            this.m_lsvPatientName.Location = new System.Drawing.Point(248, 213);
            this.m_lsvPatientName.Size = new System.Drawing.Size(41, 28);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(251, 213);
            this.m_lsvBedNO.Size = new System.Drawing.Size(11, 33);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(252, 208);
            this.m_cboDept.Size = new System.Drawing.Size(10, 23);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(248, 213);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Enabled = false;
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(264, 207);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.m_cmdNext.Location = new System.Drawing.Point(254, 213);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(252, 210);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(263, 204);
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(15, 581);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(728, 61);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Controls.Add(this.label2);
            this.m_pnlNewBase.Controls.Add(this.lblCorpTel);
            this.m_pnlNewBase.Controls.Add(this.label8);
            this.m_pnlNewBase.Controls.Add(this.lblIDCard);
            this.m_pnlNewBase.Controls.Add(this.label3);
            this.m_pnlNewBase.Controls.Add(this.lblFamilyTel);
            this.m_pnlNewBase.Location = new System.Drawing.Point(6, 7);
            this.m_pnlNewBase.Size = new System.Drawing.Size(794, 137);
            this.m_pnlNewBase.Visible = true;
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_ctlPatientInfo, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.lblFamilyTel, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.label3, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.lblIDCard, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.label8, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.lblCorpTel, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.label2, 0);
            // 
            // m_ctlPatientInfo
            // 
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
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(599, 107);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(264, 213);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 14);
            this.label9.TabIndex = 10000031;
            this.label9.Text = "民族:";
            this.label9.Visible = false;
            // 
            // lblFolk
            // 
            this.lblFolk.AccessibleDescription = "民族";
            this.lblFolk.Location = new System.Drawing.Point(264, 217);
            this.lblFolk.Name = "lblFolk";
            this.lblFolk.Size = new System.Drawing.Size(14, 20);
            this.lblFolk.TabIndex = 10000028;
            this.lblFolk.Visible = false;
            // 
            // lblNative
            // 
            this.lblNative.AccessibleDescription = "籍贯";
            this.lblNative.Location = new System.Drawing.Point(248, 213);
            this.lblNative.Name = "lblNative";
            this.lblNative.Size = new System.Drawing.Size(14, 20);
            this.lblNative.TabIndex = 10000029;
            this.lblNative.Visible = false;
            // 
            // lblOccupation
            // 
            this.lblOccupation.AccessibleDescription = "职业";
            this.lblOccupation.Location = new System.Drawing.Point(249, 210);
            this.lblOccupation.Name = "lblOccupation";
            this.lblOccupation.Size = new System.Drawing.Size(108, 20);
            this.lblOccupation.TabIndex = 10000026;
            this.lblOccupation.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(259, 210);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 14);
            this.label13.TabIndex = 10000025;
            this.label13.Text = "职业:";
            this.label13.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(258, 210);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 14);
            this.label14.TabIndex = 10000030;
            this.label14.Text = "籍贯:";
            this.label14.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(258, 213);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 14);
            this.label11.TabIndex = 10000032;
            this.label11.Text = "婚否:";
            this.label11.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(248, 211);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 14);
            this.label7.TabIndex = 10000024;
            this.label7.Text = "入院时间:";
            this.label7.Visible = false;
            // 
            // lblIsMarry
            // 
            this.lblIsMarry.AccessibleDescription = "婚否";
            this.lblIsMarry.Location = new System.Drawing.Point(262, 210);
            this.lblIsMarry.Name = "lblIsMarry";
            this.lblIsMarry.Size = new System.Drawing.Size(48, 20);
            this.lblIsMarry.TabIndex = 10000027;
            this.lblIsMarry.Visible = false;
            // 
            // m_txtInHospitalDiagnose
            // 
            this.m_txtInHospitalDiagnose.AccessibleDescription = "入院诊断";
            this.m_txtInHospitalDiagnose.BackColor = System.Drawing.Color.White;
            this.m_txtInHospitalDiagnose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtInHospitalDiagnose.ForeColor = System.Drawing.Color.Black;
            this.m_txtInHospitalDiagnose.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtInHospitalDiagnose.Location = new System.Drawing.Point(88, 273);
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
            this.m_txtInHospitalDiagnose.MaxLength = 4000;
            this.m_txtInHospitalDiagnose.Name = "m_txtInHospitalDiagnose";
            this.m_txtInHospitalDiagnose.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtInHospitalDiagnose.Size = new System.Drawing.Size(709, 48);
            this.m_txtInHospitalDiagnose.TabIndex = 10000034;
            this.m_txtInHospitalDiagnose.Text = "";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(8, 271);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(70, 14);
            this.label18.TabIndex = 10000035;
            this.label18.Text = "入院诊断:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(282, 210);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 10000025;
            this.label1.Text = "单位:";
            this.label1.Visible = false;
            // 
            // lblEnterprise
            // 
            this.lblEnterprise.AccessibleDescription = "单位 ";
            this.lblEnterprise.Location = new System.Drawing.Point(245, 208);
            this.lblEnterprise.Name = "lblEnterprise";
            this.lblEnterprise.Size = new System.Drawing.Size(103, 20);
            this.lblEnterprise.TabIndex = 10000026;
            this.lblEnterprise.Visible = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(538, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 10000025;
            this.label2.Text = "单位电话:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCorpTel
            // 
            this.lblCorpTel.AccessibleDescription = "单位电话";
            this.lblCorpTel.Location = new System.Drawing.Point(609, 112);
            this.lblCorpTel.Name = "lblCorpTel";
            this.lblCorpTel.Size = new System.Drawing.Size(116, 20);
            this.lblCorpTel.TabIndex = 10000026;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(538, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 10000025;
            this.label3.Text = "家庭电话:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(258, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 14);
            this.label4.TabIndex = 10000025;
            this.label4.Text = "住址:";
            this.label4.Visible = false;
            // 
            // lblFamilyTel
            // 
            this.lblFamilyTel.AccessibleDescription = "住址电话";
            this.lblFamilyTel.Location = new System.Drawing.Point(609, 86);
            this.lblFamilyTel.Name = "lblFamilyTel";
            this.lblFamilyTel.Size = new System.Drawing.Size(115, 20);
            this.lblFamilyTel.TabIndex = 10000026;
            // 
            // lblFamilyAddress
            // 
            this.lblFamilyAddress.AccessibleDescription = "住址";
            this.lblFamilyAddress.Location = new System.Drawing.Point(255, 214);
            this.lblFamilyAddress.Name = "lblFamilyAddress";
            this.lblFamilyAddress.Size = new System.Drawing.Size(34, 20);
            this.lblFamilyAddress.TabIndex = 10000026;
            this.lblFamilyAddress.Visible = false;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(189, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 20);
            this.label8.TabIndex = 10000025;
            this.label8.Text = "身份证号码:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AccessibleDescription = "";
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(591, 151);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 14);
            this.label10.TabIndex = 10000025;
            this.label10.Text = "病史陈述者:";
            // 
            // lblIDCard
            // 
            this.lblIDCard.AccessibleDescription = "身份证号码";
            this.lblIDCard.Location = new System.Drawing.Point(274, 111);
            this.lblIDCard.Name = "lblIDCard";
            this.lblIDCard.Size = new System.Drawing.Size(263, 20);
            this.lblIDCard.TabIndex = 10000026;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(295, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 14);
            this.label5.TabIndex = 10000024;
            this.label5.Text = "出院时间:";
            // 
            // m_txtInHospitalInstance
            // 
            this.m_txtInHospitalInstance.AccessibleDescription = "入院情况:";
            this.m_txtInHospitalInstance.BackColor = System.Drawing.Color.White;
            this.m_txtInHospitalInstance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtInHospitalInstance.ForeColor = System.Drawing.Color.Black;
            this.m_txtInHospitalInstance.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtInHospitalInstance.Location = new System.Drawing.Point(88, 202);
            this.m_txtInHospitalInstance.m_BlnIgnoreUserInfo = false;
            this.m_txtInHospitalInstance.m_BlnPartControl = false;
            this.m_txtInHospitalInstance.m_BlnReadOnly = false;
            this.m_txtInHospitalInstance.m_BlnUnderLineDST = false;
            this.m_txtInHospitalInstance.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtInHospitalInstance.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtInHospitalInstance.m_IntCanModifyTime = 6;
            this.m_txtInHospitalInstance.m_IntPartControlLength = 0;
            this.m_txtInHospitalInstance.m_IntPartControlStartIndex = 0;
            this.m_txtInHospitalInstance.m_StrUserID = "";
            this.m_txtInHospitalInstance.m_StrUserName = "";
            this.m_txtInHospitalInstance.MaxLength = 4000;
            this.m_txtInHospitalInstance.Name = "m_txtInHospitalInstance";
            this.m_txtInHospitalInstance.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtInHospitalInstance.Size = new System.Drawing.Size(709, 65);
            this.m_txtInHospitalInstance.TabIndex = 10000034;
            this.m_txtInHospitalInstance.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 14);
            this.label6.TabIndex = 10000035;
            this.label6.Text = "入院情况:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(36, 176);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 14);
            this.label12.TabIndex = 10000035;
            this.label12.Text = "主诉:";
            // 
            // m_txtMainDescription
            // 
            this.m_txtMainDescription.AccessibleDescription = "主诉";
            this.m_txtMainDescription.BackColor = System.Drawing.Color.White;
            this.m_txtMainDescription.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtMainDescription.ForeColor = System.Drawing.Color.Black;
            this.m_txtMainDescription.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtMainDescription.Location = new System.Drawing.Point(88, 174);
            this.m_txtMainDescription.m_BlnIgnoreUserInfo = false;
            this.m_txtMainDescription.m_BlnPartControl = false;
            this.m_txtMainDescription.m_BlnReadOnly = false;
            this.m_txtMainDescription.m_BlnUnderLineDST = false;
            this.m_txtMainDescription.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtMainDescription.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtMainDescription.m_IntCanModifyTime = 6;
            this.m_txtMainDescription.m_IntPartControlLength = 0;
            this.m_txtMainDescription.m_IntPartControlStartIndex = 0;
            this.m_txtMainDescription.m_StrUserID = "";
            this.m_txtMainDescription.m_StrUserName = "";
            this.m_txtMainDescription.MaxLength = 4000;
            this.m_txtMainDescription.Multiline = false;
            this.m_txtMainDescription.Name = "m_txtMainDescription";
            this.m_txtMainDescription.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtMainDescription.Size = new System.Drawing.Size(709, 24);
            this.m_txtMainDescription.TabIndex = 10000034;
            this.m_txtMainDescription.Text = "";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(12, 331);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(70, 14);
            this.label21.TabIndex = 10000045;
            this.label21.Text = "抢救经过:";
            // 
            // m_txtSalvageInstance
            // 
            this.m_txtSalvageInstance.AccessibleDescription = "抢救经过";
            this.m_txtSalvageInstance.BackColor = System.Drawing.Color.White;
            this.m_txtSalvageInstance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSalvageInstance.ForeColor = System.Drawing.Color.Black;
            this.m_txtSalvageInstance.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSalvageInstance.Location = new System.Drawing.Point(88, 327);
            this.m_txtSalvageInstance.m_BlnIgnoreUserInfo = false;
            this.m_txtSalvageInstance.m_BlnPartControl = false;
            this.m_txtSalvageInstance.m_BlnReadOnly = false;
            this.m_txtSalvageInstance.m_BlnUnderLineDST = false;
            this.m_txtSalvageInstance.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtSalvageInstance.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtSalvageInstance.m_IntCanModifyTime = 6;
            this.m_txtSalvageInstance.m_IntPartControlLength = 0;
            this.m_txtSalvageInstance.m_IntPartControlStartIndex = 0;
            this.m_txtSalvageInstance.m_StrUserID = "";
            this.m_txtSalvageInstance.m_StrUserName = "";
            this.m_txtSalvageInstance.MaxLength = 4000;
            this.m_txtSalvageInstance.Name = "m_txtSalvageInstance";
            this.m_txtSalvageInstance.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtSalvageInstance.Size = new System.Drawing.Size(709, 78);
            this.m_txtSalvageInstance.TabIndex = 10000041;
            this.m_txtSalvageInstance.Text = "";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(12, 411);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(77, 14);
            this.label22.TabIndex = 10000046;
            this.label22.Text = "死亡原因：";
            // 
            // m_txtDeathCausation
            // 
            this.m_txtDeathCausation.AccessibleDescription = "死后原因";
            this.m_txtDeathCausation.BackColor = System.Drawing.Color.White;
            this.m_txtDeathCausation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDeathCausation.ForeColor = System.Drawing.Color.Black;
            this.m_txtDeathCausation.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDeathCausation.Location = new System.Drawing.Point(88, 411);
            this.m_txtDeathCausation.m_BlnIgnoreUserInfo = false;
            this.m_txtDeathCausation.m_BlnPartControl = false;
            this.m_txtDeathCausation.m_BlnReadOnly = false;
            this.m_txtDeathCausation.m_BlnUnderLineDST = false;
            this.m_txtDeathCausation.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDeathCausation.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDeathCausation.m_IntCanModifyTime = 6;
            this.m_txtDeathCausation.m_IntPartControlLength = 0;
            this.m_txtDeathCausation.m_IntPartControlStartIndex = 0;
            this.m_txtDeathCausation.m_StrUserID = "";
            this.m_txtDeathCausation.m_StrUserName = "";
            this.m_txtDeathCausation.MaxLength = 4000;
            this.m_txtDeathCausation.Name = "m_txtDeathCausation";
            this.m_txtDeathCausation.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtDeathCausation.Size = new System.Drawing.Size(709, 72);
            this.m_txtDeathCausation.TabIndex = 10000042;
            this.m_txtDeathCausation.Text = "";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(12, 494);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(70, 14);
            this.label23.TabIndex = 10000044;
            this.label23.Text = "死亡诊断:";
            // 
            // m_txtDeathDiagonse
            // 
            this.m_txtDeathDiagonse.AccessibleDescription = "死后诊断";
            this.m_txtDeathDiagonse.BackColor = System.Drawing.Color.White;
            this.m_txtDeathDiagonse.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDeathDiagonse.ForeColor = System.Drawing.Color.Black;
            this.m_txtDeathDiagonse.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDeathDiagonse.Location = new System.Drawing.Point(88, 490);
            this.m_txtDeathDiagonse.m_BlnIgnoreUserInfo = false;
            this.m_txtDeathDiagonse.m_BlnPartControl = false;
            this.m_txtDeathDiagonse.m_BlnReadOnly = false;
            this.m_txtDeathDiagonse.m_BlnUnderLineDST = false;
            this.m_txtDeathDiagonse.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDeathDiagonse.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDeathDiagonse.m_IntCanModifyTime = 6;
            this.m_txtDeathDiagonse.m_IntPartControlLength = 0;
            this.m_txtDeathDiagonse.m_IntPartControlStartIndex = 0;
            this.m_txtDeathDiagonse.m_StrUserID = "";
            this.m_txtDeathDiagonse.m_StrUserName = "";
            this.m_txtDeathDiagonse.MaxLength = 4000;
            this.m_txtDeathDiagonse.Name = "m_txtDeathDiagonse";
            this.m_txtDeathDiagonse.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtDeathDiagonse.Size = new System.Drawing.Size(709, 70);
            this.m_txtDeathDiagonse.TabIndex = 10000043;
            this.m_txtDeathDiagonse.Text = "";
            // 
            // m_txtDoctorSign
            // 
            this.m_txtDoctorSign.AccessibleName = "NoDefault";
            this.m_txtDoctorSign.BackColor = System.Drawing.Color.White;
            this.m_txtDoctorSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDoctorSign.ForeColor = System.Drawing.Color.Black;
            this.m_txtDoctorSign.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.m_txtDoctorSign.Location = new System.Drawing.Point(597, 574);
            this.m_txtDoctorSign.Name = "m_txtDoctorSign";
            this.m_txtDoctorSign.ReadOnly = true;
            this.m_txtDoctorSign.Size = new System.Drawing.Size(200, 23);
            this.m_txtDoctorSign.TabIndex = 10000047;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 0;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Width = 100;
            // 
            // m_cmdDoctorSign
            // 
            this.m_cmdDoctorSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdDoctorSign.DefaultScheme = true;
            this.m_cmdDoctorSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdDoctorSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdDoctorSign.Hint = "";
            this.m_cmdDoctorSign.Location = new System.Drawing.Point(529, 573);
            this.m_cmdDoctorSign.Name = "m_cmdDoctorSign";
            this.m_cmdDoctorSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdDoctorSign.Size = new System.Drawing.Size(64, 28);
            this.m_cmdDoctorSign.TabIndex = 10000048;
            this.m_cmdDoctorSign.Tag = "1";
            this.m_cmdDoctorSign.Text = "医师:";
            // 
            // m_dtpOutHospitalDate1
            // 
            this.m_dtpOutHospitalDate1.BorderColor = System.Drawing.Color.Black;
            this.m_dtpOutHospitalDate1.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpOutHospitalDate1.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_dtpOutHospitalDate1.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpOutHospitalDate1.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpOutHospitalDate1.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpOutHospitalDate1.Font = new System.Drawing.Font("宋体", 12F);
            this.m_dtpOutHospitalDate1.ForeColor = System.Drawing.Color.Black;
            this.m_dtpOutHospitalDate1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpOutHospitalDate1.Location = new System.Drawing.Point(365, 147);
            this.m_dtpOutHospitalDate1.m_BlnOnlyTime = false;
            this.m_dtpOutHospitalDate1.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpOutHospitalDate1.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpOutHospitalDate1.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpOutHospitalDate1.Name = "m_dtpOutHospitalDate1";
            this.m_dtpOutHospitalDate1.ReadOnly = false;
            this.m_dtpOutHospitalDate1.Size = new System.Drawing.Size(192, 22);
            this.m_dtpOutHospitalDate1.TabIndex = 10000050;
            this.m_dtpOutHospitalDate1.TextBackColor = System.Drawing.Color.White;
            this.m_dtpOutHospitalDate1.TextForeColor = System.Drawing.Color.Black;
            this.m_dtpOutHospitalDate1.Visible = false;
            // 
            // m_cboRepresentor
            // 
            this.m_cboRepresentor.BackColor = System.Drawing.Color.White;
            this.m_cboRepresentor.BorderColor = System.Drawing.Color.Black;
            this.m_cboRepresentor.DropButtonBackColor = System.Drawing.Color.Gainsboro;
            this.m_cboRepresentor.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboRepresentor.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboRepresentor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboRepresentor.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboRepresentor.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboRepresentor.ForeColor = System.Drawing.Color.White;
            this.m_cboRepresentor.ListBackColor = System.Drawing.Color.White;
            this.m_cboRepresentor.ListForeColor = System.Drawing.Color.Black;
            this.m_cboRepresentor.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboRepresentor.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboRepresentor.Location = new System.Drawing.Point(681, 147);
            this.m_cboRepresentor.m_BlnEnableItemEventMenu = true;
            this.m_cboRepresentor.Name = "m_cboRepresentor";
            this.m_cboRepresentor.SelectedIndex = -1;
            this.m_cboRepresentor.SelectedItem = null;
            this.m_cboRepresentor.SelectionStart = 0;
            this.m_cboRepresentor.Size = new System.Drawing.Size(116, 23);
            this.m_cboRepresentor.TabIndex = 10000083;
            this.m_cboRepresentor.TextBackColor = System.Drawing.Color.White;
            this.m_cboRepresentor.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_dtpInPatientTime1
            // 
            this.m_dtpInPatientTime1.AccessibleDescription = "入院时间";
            this.m_dtpInPatientTime1.BorderColor = System.Drawing.Color.Black;
            this.m_dtpInPatientTime1.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpInPatientTime1.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_dtpInPatientTime1.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpInPatientTime1.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpInPatientTime1.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpInPatientTime1.Font = new System.Drawing.Font("宋体", 12F);
            this.m_dtpInPatientTime1.ForeColor = System.Drawing.Color.Black;
            this.m_dtpInPatientTime1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpInPatientTime1.Location = new System.Drawing.Point(285, 211);
            this.m_dtpInPatientTime1.m_BlnOnlyTime = false;
            this.m_dtpInPatientTime1.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpInPatientTime1.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpInPatientTime1.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpInPatientTime1.Name = "m_dtpInPatientTime1";
            this.m_dtpInPatientTime1.ReadOnly = false;
            this.m_dtpInPatientTime1.Size = new System.Drawing.Size(192, 22);
            this.m_dtpInPatientTime1.TabIndex = 10000050;
            this.m_dtpInPatientTime1.TextBackColor = System.Drawing.Color.White;
            this.m_dtpInPatientTime1.TextForeColor = System.Drawing.Color.Black;
            this.m_dtpInPatientTime1.Visible = false;
            // 
            // m_lblInPatientTime
            // 
            this.m_lblInPatientTime.AccessibleDescription = "入院时间";
            this.m_lblInPatientTime.Location = new System.Drawing.Point(268, 205);
            this.m_lblInPatientTime.Name = "m_lblInPatientTime";
            this.m_lblInPatientTime.Size = new System.Drawing.Size(75, 22);
            this.m_lblInPatientTime.TabIndex = 10000084;
            this.m_lblInPatientTime.Visible = false;
            // 
            // m_lblOutHospitalDate
            // 
            this.m_lblOutHospitalDate.AccessibleDescription = "出院时间";
            this.m_lblOutHospitalDate.Location = new System.Drawing.Point(364, 147);
            this.m_lblOutHospitalDate.Name = "m_lblOutHospitalDate";
            this.m_lblOutHospitalDate.Size = new System.Drawing.Size(204, 22);
            this.m_lblOutHospitalDate.TabIndex = 10000085;
            // 
            // frmDeathRecordIn24Hours
            // 
            this.ClientSize = new System.Drawing.Size(812, 686);
            this.Controls.Add(this.lblOccupation);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblEnterprise);
            this.Controls.Add(this.m_lblOutHospitalDate);
            this.Controls.Add(this.m_cboRepresentor);
            this.Controls.Add(this.m_lblInPatientTime);
            this.Controls.Add(this.m_dtpOutHospitalDate1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblFolk);
            this.Controls.Add(this.lblNative);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblIsMarry);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblFamilyAddress);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.m_txtMainDescription);
            this.Controls.Add(this.m_dtpInPatientTime1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.m_txtInHospitalInstance);
            this.Controls.Add(this.m_txtInHospitalDiagnose);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.m_txtSalvageInstance);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.m_txtDeathCausation);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.m_txtDeathDiagonse);
            this.Controls.Add(this.m_cmdDoctorSign);
            this.Controls.Add(this.m_txtDoctorSign);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Name = "frmDeathRecordIn24Hours";
            this.Text = "入院24小时内死亡记录";
            this.Load += new System.EventHandler(this.frmDeathRecordIn24Hours_Load);
            this.Controls.SetChildIndex(this.m_txtDoctorSign, 0);
            this.Controls.SetChildIndex(this.m_cmdDoctorSign, 0);
            this.Controls.SetChildIndex(this.m_txtDeathDiagonse, 0);
            this.Controls.SetChildIndex(this.label23, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_dtpGetDataTime, 0);
            this.Controls.SetChildIndex(this.m_lblGetDataTime, 0);
            this.Controls.SetChildIndex(this.label22, 0);
            this.Controls.SetChildIndex(this.m_txtDeathCausation, 0);
            this.Controls.SetChildIndex(this.label21, 0);
            this.Controls.SetChildIndex(this.m_txtSalvageInstance, 0);
            this.Controls.SetChildIndex(this.label18, 0);
            this.Controls.SetChildIndex(this.m_txtInHospitalDiagnose, 0);
            this.Controls.SetChildIndex(this.m_txtInHospitalInstance, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.m_dtpInPatientTime1, 0);
            this.Controls.SetChildIndex(this.m_txtMainDescription, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.lblFamilyAddress, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.lblIsMarry, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.lblNative, 0);
            this.Controls.SetChildIndex(this.lblFolk, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.m_dtpOutHospitalDate1, 0);
            this.Controls.SetChildIndex(this.m_lblInPatientTime, 0);
            this.Controls.SetChildIndex(this.m_cboRepresentor, 0);
            this.Controls.SetChildIndex(this.m_lblOutHospitalDate, 0);
            this.Controls.SetChildIndex(this.lblEnterprise, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.lblOccupation, 0);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.m_dtpCreateDate, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.lblCreateDateTitle, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.m_trvCreateDate, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public override clsDiseaseTrackInfo m_objGetDiseaseTrackInfo()
		{
			clsDeathRecordInfo objTrackInfo = new clsDeathRecordInfo();

			objTrackInfo.m_ObjRecordContent = m_objCurrentRecordContent;//m_objGetContentFromGUI();
			//设置m_strTitle和m_dtmRecordTime
			objTrackInfo.m_DtmRecordTime = m_dtpCreateDate.Value;
			objTrackInfo.m_StrTitle = "入院24小时内死亡记录";			
			
			return objTrackInfo;		
		
		}

		protected override void m_mthClearRecordInfo()
		{
			//清空具体记录内容	
			//		
			m_txtDeathCausation.m_mthClearText();
			m_txtDeathDiagonse.m_mthClearText();
			m_txtInHospitalDiagnose.m_mthClearText();
			m_txtInHospitalInstance.m_mthClearText();
			m_txtSalvageInstance.m_mthClearText();
			m_txtMainDescription.m_mthClearText();
            m_txtDoctorSign.Clear();
            m_txtDoctorSign.Tag = null;
			//clsEmployeeSignTool.s_mthSetDefaulEmployee(m_txtDoctorSign);	
		}

		/// <summary>
		/// 提示没有该病人
		/// </summary>
		protected override void m_mthShowNoPatient()
		{
			clsPublicFunction.ShowInformationMessageBox("对不起，没有此病人！");
		}

		protected override void m_mthSetPatientBaseInfo(clsPatient p_objSelectedPatient)
		{
			if(p_objSelectedPatient.m_ObjPeopleInfo == null)
			{
				m_mthShowNoPatient();
				return;
			}  

			//这个开关的作用是以防对m_cboArea赋值后触发其SelectedIndexChanged事件
			m_blnCanTextChanged = false;

			if(p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastSessionInfo != null)
			{			

				//清空
				m_cboDept.ClearItem();
				 
				//获取科室
				string str1=p_objSelectedPatient.m_strDeptNewID;
				string str2;
				clsHospitalManagerDomain objDomain =new clsHospitalManagerDomain();
				clsEmrDept_VO objDeptNew;

				objDomain.m_lngGetSpecialDeptInfo(str1,out objDeptNew);

				str1=objDeptNew.m_strSHORTNO_CHR.Trim();
				str2=objDeptNew.m_strDEPTNAME_VCHR.Trim();
				string str11=objDeptNew.m_strDEPTID_CHR.Trim();
				clsDepartment objDeptTemp= new clsDepartment(str1,str2);
				//转换使用，新表的shortno＝旧表的ID，所以新加一个字段保存新表ID
				objDeptTemp.m_strDeptNewID=str11;
				m_cboDept.AddItem(objDeptTemp);
				m_cboDept.SelectedIndex=0;

				//获取病区
				m_cboArea.ClearItem();
				string str3=p_objSelectedPatient.m_strAreaNewID;
				if (str3.Trim().Length!=0)//病区不为空
				{
					string str4;
					clsEmrDept_VO objAreNew;
					objDomain.m_lngGetSpecialAreaInfo(str3,out objAreNew);
					str3=objAreNew.m_strSHORTNO_CHR;
					str4=objAreNew.m_strDEPTNAME_VCHR;
					clsInPatientArea objInPatientArea =new clsInPatientArea(str3,str4,objAreNew.m_strDEPTID_CHR);
					//转换使用，新表的shortno＝旧表的ID，所以新加一个字段保存新表ID
					objInPatientArea.m_strAreaNewID=objAreNew.m_strDEPTID_CHR;
					m_cboArea.AddItem(objInPatientArea);
					m_cboArea.SelectedIndex=0;
				}
							
				m_txtBedNO.Text =p_objSelectedPatient.m_strBedCode;
			}
			else
			{				
				m_txtBedNO.Text = "";
			}

			this.m_objCurrentPatient = p_objSelectedPatient;

			txtInPatientID.Text = m_objCurrentPatient.m_StrHISInPatientID;
			m_txtPatientName.Text = m_objCurrentPatient.m_ObjPeopleInfo.m_StrLastName;

            this.m_lblInPatientTime.Text = m_objCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmHISInDate.ToString("yyyy年MM月dd日 HH:mm");
            m_mthGetSetlectedOutDate();
            if (m_dtmOutHospitalDate == new DateTime(1900, 1, 1) || m_dtmOutHospitalDate == DateTime.MinValue)
                m_lblOutHospitalDate.Visible = false;
            else
            {
                m_lblOutHospitalDate.Visible = true;
                m_lblOutHospitalDate.Text = m_dtmOutHospitalDate.ToString("yyyy年MM月dd日 HH:mm");
            } 
 	

			//	this.m_txtPatientName.Text = m_objCurrentPatient.m_ObjPeopleInfo.m_StrFirstName;//.m_StrName;//

            //lblSex.Text = m_objCurrentPatient.m_ObjPeopleInfo.m_StrSex;
            //lblAge.Text = m_objCurrentPatient.m_ObjPeopleInfo.m_StrAge;
            //lblOccupation.Text = m_objCurrentPatient.m_ObjPeopleInfo.m_StrOccupation;
            //lblNative.Text = m_objCurrentPatient.m_ObjPeopleInfo.m_StrHomeplace;
            //lblFolk.Text = m_objCurrentPatient.m_ObjPeopleInfo.m_StrNation;
            //lblIsMarry.Text = m_objCurrentPatient.m_ObjPeopleInfo.m_StrMarried;
            //lblIDCard.Text = m_objCurrentPatient.m_ObjPeopleInfo.m_StrIDCard;
            //lblFamilyTel.Text = m_objCurrentPatient.m_ObjPeopleInfo.m_StrHomePhone;
            //lblFamilyAddress.Text = m_objCurrentPatient.m_ObjPeopleInfo.m_StrHomeAddress;
            //lblEnterprise.Text = m_objCurrentPatient.m_ObjPeopleInfo.m_StrOffice_name;
            //lblCorpTel.Text = m_objCurrentPatient.m_ObjPeopleInfo.m_StrOfficePhone;

			m_blnCanTextChanged = true;
		}
        /// <summary>
        /// 仅设置病人的基本信息
        /// </summary>
        /// <param name="p_objSelectedPatient"></param>
        protected override void m_mthOnlySetPatientInfo(clsPatient p_objSelectedPatient)
        {
            lblSex.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrSex;
            lblAge.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrAge;
            lblOccupation.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrOccupation;
            lblNative.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrHomeplace;
            lblFolk.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrNation;
            lblIsMarry.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrMarried;
            lblIDCard.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrIDCard;
            lblFamilyTel.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrHomePhone;
            lblFamilyAddress.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrHomeAddress;
            lblEnterprise.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrOffice_name;
            lblCorpTel.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrOfficePhone;

            m_mthGetSetlectedOutDate();
            if (m_dtmOutHospitalDate == new DateTime(1900, 1, 1) || m_dtmOutHospitalDate == DateTime.MinValue)
                m_lblOutHospitalDate.Visible = false;
            else
            {
                m_lblOutHospitalDate.Visible = true;
                m_lblOutHospitalDate.Text = m_dtmOutHospitalDate.ToString("yyyy年MM月dd日 HH:mm");
            } 
        }
		/// <summary>
		/// 从界面获取特殊记录的值。如果界面值出错，返回null。
		/// </summary>
		/// <returns></returns>
		protected override clsTrackRecordContent m_objGetContentFromGUI()
		{
			//界面参数校验
			if(m_objCurrentPatient==null || m_ObjCurrentEmrPatientSession == null)		
				return null;
			
			//从界面获取表单值
         
			clsEMR_DeathRecordIn24HoursValue objContent=new clsEMR_DeathRecordIn24HoursValue();
//			objContent.m_dtmCreateDate=m_dtpCreateDate.Value;
			objContent.m_strModifyUserID=clsEMRLogin.LoginInfo.m_strEmpNo;
			#region 是否可以无痕迹修改
            if (chkModifyWithoutMatk.Checked)
                objContent.m_intMarkStatus = 0;
            else
                objContent.m_intMarkStatus = 1;
            #endregion		
//			objContent.m_dtmInPatientDate = Convert.ToDateTime(m_dtpInPatientTime.Text);
//			objContent.m_dtmRECORDDATE = Convert.ToDateTime(m_lblOutHospitalDate.Text) ;
			objContent.m_dtmRECORDDATE = Convert.ToDateTime(m_dtpCreateDate.Text);
			
			objContent.m_strREPRESENTOR = this.m_cboRepresentor.Text;
			objContent.m_strMAINDESCRIPTION = m_txtMainDescription.Text;
			objContent.m_strMAINDESCRIPTIONXML = m_txtMainDescription.m_strGetXmlText();
			objContent.m_strINHOSPITALINSTANCE = m_txtInHospitalInstance.Text;
			objContent.m_strINHOSPITALINSTANCEXML = m_txtInHospitalInstance.m_strGetXmlText();

			objContent.m_strINHOSPITALDIAGNOSE1 = m_txtInHospitalDiagnose.Text;
			objContent.m_strINHOSPITALDIAGNOSE1XML  = m_txtInHospitalDiagnose.m_strGetXmlText();
			//			objContent.m_strINHOSPITALDIAGNOSE2 = this.m_txtInHospitalInstance.Text;
			//			objContent.m_strINHOSPITALDIAGNOSE2XML  = this.m_txtInHospitalDiagnose.m_strGetXmlText();

			objContent.m_strSALVAGEINSTANCE = m_txtSalvageInstance.Text;
			objContent.m_strSALVAGEINSTANCEXML = m_txtSalvageInstance.m_strGetXmlText();

			objContent.m_strDEATHCAUSATION1 = m_txtDeathCausation.Text;
			objContent.m_strDEATHCAUSATION1XML = m_txtDeathCausation.m_strGetXmlText();
			//			objContent.m_strDEATHCAUSATION2 = this.m_txtDeathCausation.Text;
			//			objContent.m_strDEATHCAUSATION2XML = this.m_txtDeathCausation.m_strGetXmlText();

			objContent.m_strDEATHDIAGNOSE1 = this.m_txtDeathDiagonse.Text;
			objContent.m_strDEATHDIAGNOSE1XML = this.m_txtDeathDiagonse.m_strGetXmlText();
			//			objContent.m_strDEATHDIAGNOSE2 = this.m_txtDeathDiagonse.Text;
			//			objContent.m_strDEATHDIAGNOSE2XML = this.m_txtDeathDiagonse.m_strGetXmlText();
			
			if(m_txtDoctorSign.Tag!=null && m_txtDoctorSign.Text.Trim()!="")
			{
				objContent.m_strDOCTORSIGN = ((clsEmrEmployeeBase_VO)m_txtDoctorSign.Tag).m_strEMPNO_CHR;
	
				objContent.m_strDOCTORSIGNNAME = m_txtDoctorSign.Text;
			}
			else 
			{
				clsPublicFunction.ShowInformationMessageBox("必须医师签名!");
				return null;
			}			

			return objContent;	
		}


		protected override void m_mthSetDeletedGUIFromContent(clsTrackRecordContent p_objContent)
		{
			if(p_objContent ==null)
				return;
			clsEMR_DeathRecordIn24HoursValue objContent=(clsEMR_DeathRecordIn24HoursValue)p_objContent;
			//把表单值赋值到界面，由子窗体重载实现
//			this.m_lblOutHospitalDate.Text  = Convert.ToString(objContent.m_dtmRECORDDATE);

			m_txtMainDescription.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strMAINDESCRIPTION,objContent.m_strMAINDESCRIPTIONXML);		
			m_txtInHospitalInstance.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strINHOSPITALINSTANCE,objContent.m_strINHOSPITALINSTANCEXML);
			m_txtSalvageInstance.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strSALVAGEINSTANCE,objContent.m_strSALVAGEINSTANCEXML);
			m_txtDeathCausation.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDEATHCAUSATION1,objContent.m_strDEATHCAUSATION1XML);
			
			m_txtDeathDiagonse.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDEATHDIAGNOSE1,objContent.m_strDEATHDIAGNOSE1XML );
			
			m_txtInHospitalDiagnose.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strINHOSPITALDIAGNOSE1,objContent.m_strINHOSPITALDIAGNOSE1XML) ;	
			m_dtpCreateDate.Value = objContent.m_dtmRECORDDATE;

            clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
            objEmployeeSign.m_lngGetEmpByNO(objContent.m_strDOCTORSIGN, out objEmpVO);
            if (objEmpVO != null)
            {
                m_txtDoctorSign.Tag = objEmpVO;
                m_txtDoctorSign.Text = objContent.m_strDOCTORSIGNNAME;
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

			clsEMR_DeathRecordIn24HoursValue objContent=(clsEMR_DeathRecordIn24HoursValue)p_objContent;
			//把表单值赋值到界面，由子窗体重载实现
			this.m_dtpCreateDate.Value  =objContent.m_dtmCreateDate;
			m_strCurrentOpenDate = objContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss");

			if(m_dtmOutHospitalDate != new DateTime(1900,1,1) && m_dtmOutHospitalDate != DateTime.MinValue)
				this.m_lblOutHospitalDate.Text  = m_dtmOutHospitalDate.ToString("yyyy年MM月dd日 HH:mm:ss");
			this.m_cboRepresentor.Text = objContent.m_strREPRESENTOR;
			m_txtMainDescription.m_mthSetNewText(objContent.m_strMAINDESCRIPTION,objContent.m_strMAINDESCRIPTIONXML);
			m_txtInHospitalInstance.m_mthSetNewText(objContent.m_strINHOSPITALINSTANCE,objContent.m_strINHOSPITALINSTANCEXML);
			m_txtSalvageInstance.m_mthSetNewText(objContent.m_strSALVAGEINSTANCE,objContent.m_strSALVAGEINSTANCEXML);


			m_txtDeathCausation.m_mthSetNewText(objContent.m_strDEATHCAUSATION1,objContent.m_strDEATHCAUSATION1XML);
			
			m_txtDeathDiagonse.m_mthSetNewText(objContent.m_strDEATHDIAGNOSE1,objContent.m_strDEATHDIAGNOSE1XML );
			
			m_txtInHospitalDiagnose.m_mthSetNewText(objContent.m_strINHOSPITALDIAGNOSE1,objContent.m_strINHOSPITALDIAGNOSE1XML) ;	
			m_dtpCreateDate.Value = objContent.m_dtmRECORDDATE;

			#region 签名			
            clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
            objEmployeeSign.m_lngGetEmpByNO(objContent.m_strDOCTORSIGN, out objEmpVO);
            if (objEmpVO != null)
            {
                m_txtDoctorSign.Tag = objEmpVO;
                m_txtDoctorSign.Text = objContent.m_strDOCTORSIGNNAME;
            }
			#endregion 签名
		}
		/// <summary>
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

		public override int m_IntFormID
		{
			get
			{
				return 115;
			}
		}

		private void frmDeathRecordIn24Hours_Load(object sender, System.EventArgs e)
		{
			m_mthfrmLoad();

			if(m_objCurrentPatient !=null)
			{
				this.m_lblInPatientTime.Text =m_objCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmHISInDate.ToString("yyyy年MM月dd日 HH时mm分");
				m_mthGetSetlectedOutDate();
				if( m_dtmOutHospitalDate == new DateTime(1900,1,1) || m_dtmOutHospitalDate == DateTime.MinValue)
				{m_lblOutHospitalDate.Visible = false;label5.Visible = false;}
				else
				{
					m_lblOutHospitalDate.Visible = true;
					label5.Visible = true;
					m_lblOutHospitalDate.Text = m_dtmOutHospitalDate.ToString("yyyy年MM月dd日 HH时mm分");
				}
			}		

			this.m_dtpCreateDate.m_EnmVisibleFlag=MDIParent.s_ObjRecordDateTimeInfo.m_enmGetRecordTimeFlag(this.Name);
			this.m_dtpCreateDate.m_mthResetSize();

			m_trvCreateDate.Focus();
			
		}

		/// <summary>
		/// 获取病程记录的领域层实例
		/// </summary>
		/// <returns></returns>
		protected override clsDiseaseTrackDomain m_objGetDiseaseTrackDomain()
		{
			//获取病程记录的领域层实例
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.DeathHospitalIn24Hours);
		}

		/// <summary>
		/// 把选择时间记录内容重新整理为完全正确的内容。
		/// </summary>
		/// <param name="p_objRecordContent"></param>
		protected override void m_mthReAddNewRecord(clsTrackRecordContent p_objRecordContent)
		{
			//把选择时间记录内容重新整理为完全正确的内容，由子窗体重载实现。
			clsEMR_DeathRecordIn24HoursValue objContent = (clsEMR_DeathRecordIn24HoursValue)p_objRecordContent;
			
			//把表单值赋值到界面，由子窗体重载实现
			this.m_cboRepresentor.Text = objContent.m_strREPRESENTOR;
			

			this.txtInPatientID.Text = m_objCurrentPatient.m_StrHISInPatientID;

			m_lblInPatientTime.Text = Convert.ToString(objContent.m_dtmInPatientDate);
			
			m_txtMainDescription.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strMAINDESCRIPTION,objContent.m_strMAINDESCRIPTIONXML);		
			m_txtInHospitalInstance.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strINHOSPITALINSTANCE,objContent.m_strINHOSPITALINSTANCEXML);
			
			m_txtSalvageInstance.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strSALVAGEINSTANCE,objContent.m_strSALVAGEINSTANCEXML);
			
			m_txtDeathCausation.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDEATHCAUSATION1,objContent.m_strDEATHCAUSATION1XML);
			
			m_txtDeathDiagonse.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDEATHDIAGNOSE1,objContent.m_strDEATHDIAGNOSE1XML );
			
			m_txtInHospitalDiagnose.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strINHOSPITALDIAGNOSE1,objContent.m_strINHOSPITALDIAGNOSE1XML) ;	
			m_dtpCreateDate.Value = objContent.m_dtmRECORDDATE;
			
		}		

		// 获取选择已经删除记录的窗体标题
		public override string m_strReloadFormTitle()
		{
			//由子窗体重载实现
			return	"入院24小时内死亡记录";
		}	

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
					m_txtInHospitalDiagnose.Text=objInPatientCaseHisoryDefaultValueArr[0].m_strPrimaryDiagnose;
				}
			}
			#endregion 初步诊断默认值
		}
		#region 医师签名		
		private void m_mthEvent_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch(e.KeyValue)
			{
				case 13:// enter
				case 38:
				case 40:
					break;
				case 113://save
					this.Save(); 
					break;
				case 114://del
					this.Delete(); 
					break;
				case 115://print
					this.Print();
					break;
				case 116://refresh
					m_mthClearUp();
					break;
				case 117://Search					
					break;
			}	
		}


		#endregion 医师签名
		#region 清空窗体内容
		/// <summary>
		/// 清空除当前控件以外的所有窗体内容,(可覆盖提供新的实现)
		/// </summary>
		/// <param name="p_ctlControl"></param>
		/// <param name="p_blnReadOnly"></param>
		protected override void m_mthClearAllInfo(Control p_ctlControl)
        {
            if (p_ctlControl == null) return;
			string strTypeName = p_ctlControl.GetType().Name;			
			if(strTypeName=="ctlRichTextBox")
			{
				//				if(p_ctlControl is iCare.CustomForm.ctlRichTextBox)//自定义表单中的cltRichTextBox
				//					((iCare.CustomForm.ctlRichTextBox)p_ctlControl).Text = "";
				//				else
				//					((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_mthClearText();	
			}
			else if(strTypeName=="ctlBorderTextBox" && p_ctlControl.Name != "txtInPatientID" && p_ctlControl.Name != "m_txtPatientName" && p_ctlControl.Name != "m_txtBedNO")
				((ctlBorderTextBox)p_ctlControl).Text="";	
			else if(strTypeName=="TreeView")
			{
				if( ((TreeView)p_ctlControl).Nodes.Count>0 )
					((TreeView)p_ctlControl).Nodes[0].Nodes.Clear();
			}
			else if(strTypeName=="ListView")
				((ListView)p_ctlControl).Items.Clear();	
			else if(strTypeName=="DateTimePicker")
				((DateTimePicker)p_ctlControl).Value=DateTime.Now;
			//m_lblInHospitalDate.Text = "";
			if(p_ctlControl.HasChildren && strTypeName !="DataGrid" && strTypeName !="DateTimePicker" )
			{									
				foreach(Control subcontrol in p_ctlControl.Controls)
				{										
					m_mthClearAllInfo(subcontrol);						
				} 	
			}		
		}


		private void m_mthClearUpInControl(Control p_ctlControl)
		{
			string strTypeName = p_ctlControl.GetType().Name;			
			if(strTypeName=="ctlRichTextBox")
				((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_mthClearText();	
			else if(strTypeName=="ctlBorderTextBox" )
				((ctlBorderTextBox)p_ctlControl).Text="";	
			else if(strTypeName=="TreeView")
			{
				if( ((TreeView)p_ctlControl).Nodes.Count>0 )
					((TreeView)p_ctlControl).Nodes[0].Nodes.Clear();
			}
			else if(strTypeName=="ListView")
				((ListView)p_ctlControl).Items.Clear();	
			else if(strTypeName=="DateTimePicker")
				((DateTimePicker)p_ctlControl).Value=DateTime.Now;	
			
			if(p_ctlControl.HasChildren && strTypeName !="DataGrid" && strTypeName !="DateTimePicker" )
			{									
				foreach(Control subcontrol in p_ctlControl.Controls)
				{										
					m_mthClearUpInControl(subcontrol);						
				} 	
			}	
		}

		private void m_mthClearUp()
		{
			m_mthClearUpInControl(this);
            this.m_lblInPatientTime.Text = "";

			m_mthClearPatientBaseInfo();
		}
		#endregion
		
		private void cmdConfirm_Click(object sender, System.EventArgs e)
		{
			if(m_lngSave() > 0)
			{
				this.DialogResult = DialogResult.Yes;
				this.Close();
			}
		}
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
        clsDeathRecordIn24HoursCSPrintTool objPrintTool;
        private void m_mthDemoPrint_FromDataSource()
        {
            if (m_blnHasInitPrintTool == false)
            {
                objPrintTool = new　clsDeathRecordIn24HoursCSPrintTool();
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
        /*
		private void m_mthfrmLoad()
		{	
			if(m_pdcPrintDocument==null)
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
		clsDeathRecordIn24HoursCSPrintTool objPrintTool;//temp

		private void m_mthDemoPrint_FromDataSource()
		{	
			//			if(m_blnHasInitPrintTool==false)
			//			{
			objPrintTool=new clsDeathRecordIn24HoursCSPrintTool();
			objPrintTool.m_mthInitPrintTool(null);	
			//				m_blnHasInitPrintTool=true;
			//			}
			if(m_objBaseCurrentPatient==null)
				objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient,DateTime.MinValue,DateTime.MinValue);
			else if(this.m_lblInPatientTime.Text.Trim() !="")//m_lblInHospitalDate
			{				
				if(this.m_trvCreateDate.SelectedNode==null||this.m_trvCreateDate.SelectedNode.Tag ==null)
					objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient,m_objBaseCurrentPatient.m_DtmLastInDate,DateTime.MinValue);
				else 
					objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient,m_objBaseCurrentPatient.m_DtmLastInDate,DateTime.Parse(this.m_trvCreateDate.SelectedNode.Tag.ToString()));
			}
			objPrintTool.m_mthInitPrintContent();						
						
			m_mthStartPrint_this();
		}
		private void m_mthStartPrint_this()
		{			
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
				
		protected override long m_lngSubPrint()//代替原窗体中的同名打印函数
		{				
			m_mthDemoPrint_FromDataSource();				
			return 1;
		}
        */
        // 获取选择已经删除记录的窗体标题


		#region 添加键盘快捷方式
		private void m_mthSetQuickKeys()
		{			
			m_mthSetControlEvent(this);			
		}
		
		private void m_mthSetControlEvent(Control p_ctlControl)
		{
			
			string strTypeName = p_ctlControl.GetType().Name;
			if(strTypeName != "Lable" && strTypeName != "Button")
			{
				p_ctlControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthEvent_KeyDown);
				if(p_ctlControl.HasChildren && strTypeName !="DataGrid" && strTypeName !="DateTimePicker" && strTypeName !="ctlComboBox")
				{									
					foreach(Control subcontrol in p_ctlControl.Controls)
					{										
						m_mthSetControlEvent(subcontrol);						
					} 	
				}				
			}	
		}
		#endregion

		protected override void m_mthSetPatientInHospitalDate(clsPatient p_objSelectedPatient)
		{
			//判断病人信息是否为null，如果是，直接返回。
			if(p_objSelectedPatient == null)
				return;   

			//记录病人信息
			m_objCurrentPatient = p_objSelectedPatient;
            this.m_lblInPatientTime.Text = m_objCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmHISInDate.ToString("yyyy年MM月dd日 HH:mm");// 	m_lblInHospitalDate.Text

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
				this.m_txtInHospitalDiagnose.Text=objInPatientCaseDefaultValue[0].m_strPrimaryDiagnose;
			}
		}

		#region 审核
		private string m_strCurrentOpenDate = "";
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

		protected override void m_mthInitJump(clsJumpControl p_objJump)
		{
			p_objJump = new clsJumpControl(this,
				new Control[]{m_cboDept,m_cboArea,m_txtBedNO,txtInPatientID,this.m_cboRepresentor,
								this.m_txtMainDescription,
								 this.m_txtInHospitalInstance,this.m_txtInHospitalDiagnose,this.m_txtSalvageInstance,
								 this.m_txtDeathDiagonse,this.m_txtDoctorSign},Keys.Enter);// this.m_lblInPatientTime,this.m_lblOutHospitalDate,
			p_objJump.m_BlnCanCycle = false;
		}

		#region  获取病人出院时间，暂时先在各个窗体查询
		private DateTime m_dtmOutHospitalDate;
		/// <summary>
		/// 获取病人出院时间，暂时先在各个窗体查询
		/// </summary>
		/// <returns></returns>
		private long m_mthGetSetlectedOutDate()
		{
			m_dtmOutHospitalDate = new DateTime(1900,1,1);
			string strRegisterID = "";
			long lngRes = 0;
            clsPatientManagerService objServ =
                (clsPatientManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPatientManagerService));


			lngRes = objServ.m_lngGetRegisterIDByPatient(m_objCurrentPatient.m_StrPatientID, m_objCurrentPatient.m_DtmSelectedHISInDate.ToString("yyyy-MM-dd HH:mm:ss"), out strRegisterID);
			
			lngRes = objServ.m_lngGetOutHospitalDate(strRegisterID, out m_dtmOutHospitalDate);
			objServ = null;
			return lngRes;
			return 0;
		}
		#endregion

        #region 作废重做

        protected override bool m_blnSubReuse(clsInactiveRecordInfo_VO p_objSelectedValue)
        {
            bool blnIsOK = false;
            if (p_objSelectedValue != null)
            {
                clsTrackRecordContent m_objContent = new clsEMR_DeathRecordIn24HoursValue();

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
                clsEMR_DeathRecordIn24HoursValue p_objContent = (clsEMR_DeathRecordIn24HoursValue)m_objContent;
                this.m_dtpCreateDate.Text = p_objContent.m_dtmCreateDate.ToString("yyyy-MM-dd hh:mm");
                //this.m_lblOutHospitalDate.Text=p_objContent
                this.m_cboRepresentor.Text = p_objContent.m_strREPRESENTOR;
                this.m_txtMainDescription.Text = p_objContent.m_strMAINDESCRIPTION;
                this.m_txtInHospitalInstance.Text = p_objContent.m_strINHOSPITALINSTANCE;
                this.m_txtInHospitalDiagnose.Text = p_objContent.m_strINHOSPITALDIAGNOSE1;
                this.m_txtSalvageInstance.Text = p_objContent.m_strSALVAGEINSTANCE;
                this.m_txtDeathCausation.Text = p_objContent.m_strDEATHCAUSATION1;
                this.m_txtDeathDiagonse.Text = p_objContent.m_strDEATHDIAGNOSE1;
                this.m_txtDoctorSign.Text = p_objContent.m_strDOCTORSIGNNAME;
                

                this.m_dtpCreateDate.Text = p_objContent.m_dtmCreateDate.ToString("yyyy-MM-dd hh:mm");


                //clsEmrSignToolCollection m_objSign = new clsEmrSignToolCollection();


                blnIsOK = true;
            }
            return blnIsOK;
        }

        //infPrintRecord objPrintTool;
        protected override void m_mthSubPreviewInactiveRecord(IWin32Window p_infOwner, clsInactiveRecordInfo_VO p_objSelectedValue)
        {
            if (p_objSelectedValue == null) return;
            objPrintTool = new clsDeathRecordIn24HoursCSPrintTool();

            if (m_objBaseCurrentPatient != null)
            {
                objPrintTool.m_mthInitPrintTool(null);
                objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient,
                    p_objSelectedValue.m_DtmInpatientDate,
                    p_objSelectedValue.m_DtmOpenDate);
                clsPrintInfo_DeathRecordIn24Hours objPrintInfo = new clsPrintInfo_DeathRecordIn24Hours();


                //objPrintInfo.m_dtmHISInDate = p_objSelectedValue.m_DtmInpatientDate;  //???
                objPrintInfo.m_dtmInPatientDate = p_objSelectedValue.m_DtmInpatientDate;
                objPrintInfo.m_dtmOpenDate = p_objSelectedValue.m_DtmOpenDate;
                //objPrintInfo.m_strAge = p_objSelectedValue;           
                //objPrintInfo.m_strAreaName
                //objPrintInfo.m_strBedName
                //objPrintInfo.m_strDeptName=
                //objPrintInfo.m_strHISInPatientID=
                objPrintInfo.m_strInPatentID = p_objSelectedValue.m_StrInpatientId;
                //objPrintInfo.m_strPatientName =
                //objPrintInfo.m_strSex=
                

                clsTrackRecordContent p_objContent = new clsEMR_DeathRecordIn24HoursValue();
                long lngRes = m_objGetDiseaseTrackDomain().m_lngGetDeleteRecordContent(p_objSelectedValue.m_StrInpatientId, p_objSelectedValue.m_DtmInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"), p_objSelectedValue.m_DtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"), out p_objContent);
                clsEMR_DeathRecordIn24HoursValue objContent = (clsEMR_DeathRecordIn24HoursValue)p_objContent;
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

            new clsInPatientCaseHistoryDomain().m_lngGetAllInactiveInfo(p_objSelectedValue.m_StrInpatientId, p_objSelectedValue.m_DtmInpatientDate, out objArr);
            return objArr;
        }
        public override bool m_blnIsNewSetInactiveForm
        {
            get { return true; }
        }
        #endregion 作废重做

    }
}
