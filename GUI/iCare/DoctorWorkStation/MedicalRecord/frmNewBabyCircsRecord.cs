using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using iCareData;
using com.digitalwave.clsGeneralNurseRecord_GXService;
using com.digitalwave.Utility.Controls;
using iCare.iCareBaseForm;
using com.digitalwave.Emr.Signature_gui;

namespace iCare
{
	/// <summary>
	/// 新生儿情况记录
	/// </summary>
	public class frmNewBabyCircsRecord : frmHRPBaseForm
	{
		#region 控件
		private bool m_blnIsNew;
		private string m_strMotherID;
		private string m_strBirthTime;
		private string m_strOpenTime;
        private string m_strInPatientDate;
		private PinkieControls.ButtonXP m_cmdDoctorSign;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		public com.digitalwave.Utility.Controls.ctlTimePicker m_dtpRecordTime;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboBirthDays;
		protected com.digitalwave.controls.ctlRichTextBox m_txtRemark;
		#endregion
		private PinkieControls.ButtonXP m_cmdOK;
		private PinkieControls.ButtonXP m_cmdCancle;
		protected com.digitalwave.controls.ctlRichTextBox m_txtBIRTHBURL;
		protected com.digitalwave.controls.ctlRichTextBox m_txtHAEMATOMA;
		protected com.digitalwave.controls.ctlRichTextBox m_txtFONTANEL;
		protected com.digitalwave.controls.ctlRichTextBox m_txtCONJUNCTIVA;
		protected com.digitalwave.controls.ctlRichTextBox m_txtSECRETION;
		protected com.digitalwave.controls.ctlRichTextBox m_txtPHARYNX;
		protected com.digitalwave.controls.ctlRichTextBox m_txtWHITEPOINT;
		protected com.digitalwave.controls.ctlRichTextBox m_txtICTERUS;
		protected com.digitalwave.controls.ctlRichTextBox m_txtFESTER;
		protected com.digitalwave.controls.ctlRichTextBox m_txtBLEEDING;
		protected com.digitalwave.controls.ctlRichTextBox m_txtAGNAIL;
		protected com.digitalwave.controls.ctlRichTextBox m_txtREDSTERN;
		protected com.digitalwave.controls.ctlRichTextBox m_txtSTERNSKIN;
		protected com.digitalwave.controls.ctlRichTextBox m_txtHEARTLUNG;
		protected com.digitalwave.controls.ctlRichTextBox m_txtABDOMEN;
        private clsEmployeeSignTool m_objSignTool;
		private clsNewBabyInRoomRecordDomain m_objDomain;
		private clsNewBabyCircsRecord m_objCurrentRecord;
        private TextBox m_txtDoctorSign;
        //定义签名类
        private clsEmrSignToolCollection m_objSign;
     // private com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();

        private com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmNewBabyCircsRecord(bool blnIsNew, string strMotherID, string strInPatientDate, string strBirthTime, ref string strOpenDate)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			this.Size = new System.Drawing.Size(760,472);
			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
            //指明医生工作站表单
            intFormType = 1;
			m_blnIsNew = blnIsNew;
			m_strMotherID = strMotherID;
			m_strBirthTime = strBirthTime;
			m_strOpenTime = strOpenDate;
			m_strInPatientDate = strInPatientDate;

            //m_objSignTool = new clsEmployeeSignTool(m_lsvEmployee);
            //m_objSignTool.m_mthAddControl(m_txtDoctorSign);

            //new clsCommonUseToolCollection(this).m_mthBindEmployeeSign(new Control[]{this.m_cmdDoctorSign },
            //    new Control[]{this.m_txtDoctorSign},new int[]{1});
            //签名常用值
            m_objSign = new clsEmrSignToolCollection();
            //m_mthBindEmployeeSign(按钮,签名框,医生1or护士2,身份验证trueorfalse);
            m_objSign.m_mthBindEmployeeSign(m_cmdDoctorSign, m_txtDoctorSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);

			m_objDomain = new clsNewBabyInRoomRecordDomain();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewBabyCircsRecord));
            this.m_cmdDoctorSign = new PinkieControls.ButtonXP();
            this.m_dtpRecordTime = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.label32 = new System.Windows.Forms.Label();
            this.m_cboBirthDays = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label40 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtBIRTHBURL = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtHAEMATOMA = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtFONTANEL = new com.digitalwave.controls.ctlRichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.m_txtICTERUS = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtFESTER = new com.digitalwave.controls.ctlRichTextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.m_txtBLEEDING = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtAGNAIL = new com.digitalwave.controls.ctlRichTextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.m_txtREDSTERN = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtSTERNSKIN = new com.digitalwave.controls.ctlRichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_txtPHARYNX = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtWHITEPOINT = new com.digitalwave.controls.ctlRichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_txtCONJUNCTIVA = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtSECRETION = new com.digitalwave.controls.ctlRichTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.m_txtRemark = new com.digitalwave.controls.ctlRichTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.m_cmdOK = new PinkieControls.ButtonXP();
            this.m_cmdCancle = new PinkieControls.ButtonXP();
            this.m_txtHEARTLUNG = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtABDOMEN = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtDoctorSign = new System.Windows.Forms.TextBox();
            this.m_pnlNewBase.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(733, -24);
            this.lblSex.Size = new System.Drawing.Size(56, 23);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(859, -24);
            this.lblAge.Size = new System.Drawing.Size(60, 23);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(275, -24);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(280, -48);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(476, -24);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(677, -24);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(803, -24);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(19, -96);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(327, -122);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(135, 119);
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(327, -72);
            this.txtInPatientID.Size = new System.Drawing.Size(135, 23);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(527, -136);
            this.m_txtPatientName.Size = new System.Drawing.Size(136, 23);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(327, -88);
            this.m_txtBedNO.Size = new System.Drawing.Size(135, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(75, -104);
            this.m_cboArea.Size = new System.Drawing.Size(168, 23);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(527, -159);
            this.m_lsvPatientName.Size = new System.Drawing.Size(136, 119);
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(327, -159);
            this.m_lsvBedNO.Size = new System.Drawing.Size(135, 119);
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(75, -136);
            this.m_cboDept.Size = new System.Drawing.Size(168, 23);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(19, -136);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(616, 99);
            this.m_cmdNewTemplate.Size = new System.Drawing.Size(98, 36);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.Location = new System.Drawing.Point(229, -232);
            this.m_cmdNext.Size = new System.Drawing.Size(28, 26);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(182, -88);
            this.m_cmdPre.Size = new System.Drawing.Size(28, 26);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(523, -32);
            this.m_lblForTitle.Size = new System.Drawing.Size(18, 28);
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(564, 17);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(629, 57);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Location = new System.Drawing.Point(10, -54);
            this.m_pnlNewBase.Size = new System.Drawing.Size(652, 60);
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(650, 29);
            // 
            // m_cmdDoctorSign
            // 
            this.m_cmdDoctorSign.AccessibleDescription = "签名(cmd)";
            this.m_cmdDoctorSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.m_cmdDoctorSign.DefaultScheme = true;
            this.m_cmdDoctorSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdDoctorSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdDoctorSign.Hint = "";
            this.m_cmdDoctorSign.Location = new System.Drawing.Point(28, 375);
            this.m_cmdDoctorSign.Name = "m_cmdDoctorSign";
            this.m_cmdDoctorSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdDoctorSign.Size = new System.Drawing.Size(75, 37);
            this.m_cmdDoctorSign.TabIndex = 10000106;
            this.m_cmdDoctorSign.Tag = "1";
            this.m_cmdDoctorSign.Text = "签名:";
            // 
            // m_dtpRecordTime
            // 
            this.m_dtpRecordTime.AccessibleDescription = "记录日期";
            this.m_dtpRecordTime.BorderColor = System.Drawing.Color.Black;
            this.m_dtpRecordTime.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpRecordTime.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_dtpRecordTime.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpRecordTime.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpRecordTime.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpRecordTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpRecordTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpRecordTime.Location = new System.Drawing.Point(64, 16);
            this.m_dtpRecordTime.m_BlnOnlyTime = false;
            this.m_dtpRecordTime.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpRecordTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpRecordTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpRecordTime.Name = "m_dtpRecordTime";
            this.m_dtpRecordTime.ReadOnly = false;
            this.m_dtpRecordTime.Size = new System.Drawing.Size(193, 22);
            this.m_dtpRecordTime.TabIndex = 10000104;
            this.m_dtpRecordTime.TextBackColor = System.Drawing.Color.White;
            this.m_dtpRecordTime.TextForeColor = System.Drawing.Color.Black;
            this.m_dtpRecordTime.evtValueChanged += new System.EventHandler(this.m_dtpRecordTime_evtValueChanged);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label32.Location = new System.Drawing.Point(285, 18);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(63, 14);
            this.label32.TabIndex = 10000103;
            this.label32.Text = "出生天数";
            // 
            // m_cboBirthDays
            // 
            this.m_cboBirthDays.AccessibleDescription = "出生天数";
            this.m_cboBirthDays.BackColor = System.Drawing.Color.White;
            this.m_cboBirthDays.BorderColor = System.Drawing.Color.Black;
            this.m_cboBirthDays.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboBirthDays.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboBirthDays.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboBirthDays.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboBirthDays.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboBirthDays.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboBirthDays.ForeColor = System.Drawing.Color.Black;
            this.m_cboBirthDays.ListBackColor = System.Drawing.Color.White;
            this.m_cboBirthDays.ListForeColor = System.Drawing.Color.Black;
            this.m_cboBirthDays.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboBirthDays.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboBirthDays.Location = new System.Drawing.Point(353, 16);
            this.m_cboBirthDays.m_BlnEnableItemEventMenu = true;
            this.m_cboBirthDays.Name = "m_cboBirthDays";
            this.m_cboBirthDays.SelectedIndex = -1;
            this.m_cboBirthDays.SelectedItem = null;
            this.m_cboBirthDays.SelectionStart = 0;
            this.m_cboBirthDays.Size = new System.Drawing.Size(80, 23);
            this.m_cboBirthDays.TabIndex = 10000102;
            this.m_cboBirthDays.TextBackColor = System.Drawing.Color.White;
            this.m_cboBirthDays.TextForeColor = System.Drawing.Color.Black;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label40.Location = new System.Drawing.Point(19, 18);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(42, 14);
            this.label40.TabIndex = 10000101;
            this.label40.Text = "日期:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.m_txtBIRTHBURL);
            this.groupBox1.Controls.Add(this.m_txtHAEMATOMA);
            this.groupBox1.Controls.Add(this.m_txtFONTANEL);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.groupBox1.Location = new System.Drawing.Point(9, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 137);
            this.groupBox1.TabIndex = 10000107;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "头";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label1.Location = new System.Drawing.Point(19, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 10000105;
            this.label1.Text = "产瘤";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label2.Location = new System.Drawing.Point(19, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 10000105;
            this.label2.Text = "血肿";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label3.Location = new System.Drawing.Point(19, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 10000105;
            this.label3.Text = "前囟";
            // 
            // m_txtBIRTHBURL
            // 
            this.m_txtBIRTHBURL.AccessibleDescription = "产瘤";
            this.m_txtBIRTHBURL.BackColor = System.Drawing.Color.White;
            this.m_txtBIRTHBURL.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBIRTHBURL.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtBIRTHBURL.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBIRTHBURL.Location = new System.Drawing.Point(65, 27);
            this.m_txtBIRTHBURL.m_BlnIgnoreUserInfo = false;
            this.m_txtBIRTHBURL.m_BlnPartControl = false;
            this.m_txtBIRTHBURL.m_BlnReadOnly = false;
            this.m_txtBIRTHBURL.m_BlnUnderLineDST = false;
            this.m_txtBIRTHBURL.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBIRTHBURL.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBIRTHBURL.m_IntCanModifyTime = 6;
            this.m_txtBIRTHBURL.m_IntPartControlLength = 0;
            this.m_txtBIRTHBURL.m_IntPartControlStartIndex = 0;
            this.m_txtBIRTHBURL.m_StrUserID = "";
            this.m_txtBIRTHBURL.m_StrUserName = "";
            this.m_txtBIRTHBURL.Multiline = false;
            this.m_txtBIRTHBURL.Name = "m_txtBIRTHBURL";
            this.m_txtBIRTHBURL.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtBIRTHBURL.Size = new System.Drawing.Size(150, 28);
            this.m_txtBIRTHBURL.TabIndex = 10000111;
            this.m_txtBIRTHBURL.Tag = "8";
            this.m_txtBIRTHBURL.Text = "";
            // 
            // m_txtHAEMATOMA
            // 
            this.m_txtHAEMATOMA.AccessibleDescription = "血肿";
            this.m_txtHAEMATOMA.BackColor = System.Drawing.Color.White;
            this.m_txtHAEMATOMA.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtHAEMATOMA.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtHAEMATOMA.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtHAEMATOMA.Location = new System.Drawing.Point(65, 64);
            this.m_txtHAEMATOMA.m_BlnIgnoreUserInfo = false;
            this.m_txtHAEMATOMA.m_BlnPartControl = false;
            this.m_txtHAEMATOMA.m_BlnReadOnly = false;
            this.m_txtHAEMATOMA.m_BlnUnderLineDST = false;
            this.m_txtHAEMATOMA.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtHAEMATOMA.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtHAEMATOMA.m_IntCanModifyTime = 6;
            this.m_txtHAEMATOMA.m_IntPartControlLength = 0;
            this.m_txtHAEMATOMA.m_IntPartControlStartIndex = 0;
            this.m_txtHAEMATOMA.m_StrUserID = "";
            this.m_txtHAEMATOMA.m_StrUserName = "";
            this.m_txtHAEMATOMA.Multiline = false;
            this.m_txtHAEMATOMA.Name = "m_txtHAEMATOMA";
            this.m_txtHAEMATOMA.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtHAEMATOMA.Size = new System.Drawing.Size(150, 27);
            this.m_txtHAEMATOMA.TabIndex = 10000111;
            this.m_txtHAEMATOMA.Tag = "8";
            this.m_txtHAEMATOMA.Text = "";
            // 
            // m_txtFONTANEL
            // 
            this.m_txtFONTANEL.AccessibleDescription = "前囟";
            this.m_txtFONTANEL.BackColor = System.Drawing.Color.White;
            this.m_txtFONTANEL.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtFONTANEL.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtFONTANEL.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtFONTANEL.Location = new System.Drawing.Point(65, 101);
            this.m_txtFONTANEL.m_BlnIgnoreUserInfo = false;
            this.m_txtFONTANEL.m_BlnPartControl = false;
            this.m_txtFONTANEL.m_BlnReadOnly = false;
            this.m_txtFONTANEL.m_BlnUnderLineDST = false;
            this.m_txtFONTANEL.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtFONTANEL.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtFONTANEL.m_IntCanModifyTime = 6;
            this.m_txtFONTANEL.m_IntPartControlLength = 0;
            this.m_txtFONTANEL.m_IntPartControlStartIndex = 0;
            this.m_txtFONTANEL.m_StrUserID = "";
            this.m_txtFONTANEL.m_StrUserName = "";
            this.m_txtFONTANEL.Multiline = false;
            this.m_txtFONTANEL.Name = "m_txtFONTANEL";
            this.m_txtFONTANEL.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtFONTANEL.Size = new System.Drawing.Size(150, 27);
            this.m_txtFONTANEL.TabIndex = 10000111;
            this.m_txtFONTANEL.Tag = "8";
            this.m_txtFONTANEL.Text = "";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.m_txtICTERUS);
            this.groupBox4.Controls.Add(this.m_txtFESTER);
            this.groupBox4.Font = new System.Drawing.Font("宋体", 10.5F);
            this.groupBox4.Location = new System.Drawing.Point(9, 190);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(224, 101);
            this.groupBox4.TabIndex = 10000107;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "皮肤";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label10.Location = new System.Drawing.Point(19, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 14);
            this.label10.TabIndex = 10000105;
            this.label10.Text = "黄疸";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label11.Location = new System.Drawing.Point(19, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 14);
            this.label11.TabIndex = 10000105;
            this.label11.Text = "脓疮";
            // 
            // m_txtICTERUS
            // 
            this.m_txtICTERUS.AccessibleDescription = "黄疸";
            this.m_txtICTERUS.BackColor = System.Drawing.Color.White;
            this.m_txtICTERUS.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtICTERUS.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtICTERUS.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtICTERUS.Location = new System.Drawing.Point(65, 24);
            this.m_txtICTERUS.m_BlnIgnoreUserInfo = false;
            this.m_txtICTERUS.m_BlnPartControl = false;
            this.m_txtICTERUS.m_BlnReadOnly = false;
            this.m_txtICTERUS.m_BlnUnderLineDST = false;
            this.m_txtICTERUS.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtICTERUS.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtICTERUS.m_IntCanModifyTime = 6;
            this.m_txtICTERUS.m_IntPartControlLength = 0;
            this.m_txtICTERUS.m_IntPartControlStartIndex = 0;
            this.m_txtICTERUS.m_StrUserID = "";
            this.m_txtICTERUS.m_StrUserName = "";
            this.m_txtICTERUS.Multiline = false;
            this.m_txtICTERUS.Name = "m_txtICTERUS";
            this.m_txtICTERUS.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtICTERUS.Size = new System.Drawing.Size(150, 27);
            this.m_txtICTERUS.TabIndex = 10000111;
            this.m_txtICTERUS.Tag = "8";
            this.m_txtICTERUS.Text = "";
            // 
            // m_txtFESTER
            // 
            this.m_txtFESTER.AccessibleDescription = "脓疮";
            this.m_txtFESTER.BackColor = System.Drawing.Color.White;
            this.m_txtFESTER.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtFESTER.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtFESTER.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtFESTER.Location = new System.Drawing.Point(65, 64);
            this.m_txtFESTER.m_BlnIgnoreUserInfo = false;
            this.m_txtFESTER.m_BlnPartControl = false;
            this.m_txtFESTER.m_BlnReadOnly = false;
            this.m_txtFESTER.m_BlnUnderLineDST = false;
            this.m_txtFESTER.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtFESTER.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtFESTER.m_IntCanModifyTime = 6;
            this.m_txtFESTER.m_IntPartControlLength = 0;
            this.m_txtFESTER.m_IntPartControlStartIndex = 0;
            this.m_txtFESTER.m_StrUserID = "";
            this.m_txtFESTER.m_StrUserName = "";
            this.m_txtFESTER.Multiline = false;
            this.m_txtFESTER.Name = "m_txtFESTER";
            this.m_txtFESTER.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtFESTER.Size = new System.Drawing.Size(150, 27);
            this.m_txtFESTER.TabIndex = 10000111;
            this.m_txtFESTER.Tag = "8";
            this.m_txtFESTER.Text = "";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.m_txtBLEEDING);
            this.groupBox5.Controls.Add(this.m_txtAGNAIL);
            this.groupBox5.Font = new System.Drawing.Font("宋体", 10.5F);
            this.groupBox5.Location = new System.Drawing.Point(243, 190);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(252, 101);
            this.groupBox5.TabIndex = 10000107;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "脐";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label6.Location = new System.Drawing.Point(19, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 14);
            this.label6.TabIndex = 10000105;
            this.label6.Text = "出血";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label9.Location = new System.Drawing.Point(19, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 14);
            this.label9.TabIndex = 10000105;
            this.label9.Text = "发炎";
            // 
            // m_txtBLEEDING
            // 
            this.m_txtBLEEDING.AccessibleDescription = "出血";
            this.m_txtBLEEDING.BackColor = System.Drawing.Color.White;
            this.m_txtBLEEDING.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBLEEDING.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtBLEEDING.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBLEEDING.Location = new System.Drawing.Point(65, 24);
            this.m_txtBLEEDING.m_BlnIgnoreUserInfo = false;
            this.m_txtBLEEDING.m_BlnPartControl = false;
            this.m_txtBLEEDING.m_BlnReadOnly = false;
            this.m_txtBLEEDING.m_BlnUnderLineDST = false;
            this.m_txtBLEEDING.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBLEEDING.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBLEEDING.m_IntCanModifyTime = 6;
            this.m_txtBLEEDING.m_IntPartControlLength = 0;
            this.m_txtBLEEDING.m_IntPartControlStartIndex = 0;
            this.m_txtBLEEDING.m_StrUserID = "";
            this.m_txtBLEEDING.m_StrUserName = "";
            this.m_txtBLEEDING.Multiline = false;
            this.m_txtBLEEDING.Name = "m_txtBLEEDING";
            this.m_txtBLEEDING.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtBLEEDING.Size = new System.Drawing.Size(178, 27);
            this.m_txtBLEEDING.TabIndex = 10000111;
            this.m_txtBLEEDING.Tag = "8";
            this.m_txtBLEEDING.Text = "";
            // 
            // m_txtAGNAIL
            // 
            this.m_txtAGNAIL.AccessibleDescription = "发炎";
            this.m_txtAGNAIL.BackColor = System.Drawing.Color.White;
            this.m_txtAGNAIL.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtAGNAIL.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtAGNAIL.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtAGNAIL.Location = new System.Drawing.Point(65, 64);
            this.m_txtAGNAIL.m_BlnIgnoreUserInfo = false;
            this.m_txtAGNAIL.m_BlnPartControl = false;
            this.m_txtAGNAIL.m_BlnReadOnly = false;
            this.m_txtAGNAIL.m_BlnUnderLineDST = false;
            this.m_txtAGNAIL.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtAGNAIL.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtAGNAIL.m_IntCanModifyTime = 6;
            this.m_txtAGNAIL.m_IntPartControlLength = 0;
            this.m_txtAGNAIL.m_IntPartControlStartIndex = 0;
            this.m_txtAGNAIL.m_StrUserID = "";
            this.m_txtAGNAIL.m_StrUserName = "";
            this.m_txtAGNAIL.Multiline = false;
            this.m_txtAGNAIL.Name = "m_txtAGNAIL";
            this.m_txtAGNAIL.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtAGNAIL.Size = new System.Drawing.Size(178, 27);
            this.m_txtAGNAIL.TabIndex = 10000111;
            this.m_txtAGNAIL.Tag = "8";
            this.m_txtAGNAIL.Text = "";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.m_txtREDSTERN);
            this.groupBox6.Controls.Add(this.m_txtSTERNSKIN);
            this.groupBox6.Font = new System.Drawing.Font("宋体", 10.5F);
            this.groupBox6.Location = new System.Drawing.Point(504, 190);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(233, 101);
            this.groupBox6.TabIndex = 10000107;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "臀";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label12.Location = new System.Drawing.Point(19, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 14);
            this.label12.TabIndex = 10000105;
            this.label12.Text = "红";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label13.Location = new System.Drawing.Point(19, 64);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 14);
            this.label13.TabIndex = 10000105;
            this.label13.Text = "皮肤";
            // 
            // m_txtREDSTERN
            // 
            this.m_txtREDSTERN.AccessibleDescription = "红";
            this.m_txtREDSTERN.BackColor = System.Drawing.Color.White;
            this.m_txtREDSTERN.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtREDSTERN.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtREDSTERN.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtREDSTERN.Location = new System.Drawing.Point(65, 24);
            this.m_txtREDSTERN.m_BlnIgnoreUserInfo = false;
            this.m_txtREDSTERN.m_BlnPartControl = false;
            this.m_txtREDSTERN.m_BlnReadOnly = false;
            this.m_txtREDSTERN.m_BlnUnderLineDST = false;
            this.m_txtREDSTERN.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtREDSTERN.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtREDSTERN.m_IntCanModifyTime = 6;
            this.m_txtREDSTERN.m_IntPartControlLength = 0;
            this.m_txtREDSTERN.m_IntPartControlStartIndex = 0;
            this.m_txtREDSTERN.m_StrUserID = "";
            this.m_txtREDSTERN.m_StrUserName = "";
            this.m_txtREDSTERN.Multiline = false;
            this.m_txtREDSTERN.Name = "m_txtREDSTERN";
            this.m_txtREDSTERN.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtREDSTERN.Size = new System.Drawing.Size(159, 27);
            this.m_txtREDSTERN.TabIndex = 10000111;
            this.m_txtREDSTERN.Tag = "8";
            this.m_txtREDSTERN.Text = "";
            // 
            // m_txtSTERNSKIN
            // 
            this.m_txtSTERNSKIN.AccessibleDescription = "皮肤";
            this.m_txtSTERNSKIN.BackColor = System.Drawing.Color.White;
            this.m_txtSTERNSKIN.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSTERNSKIN.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtSTERNSKIN.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSTERNSKIN.Location = new System.Drawing.Point(65, 64);
            this.m_txtSTERNSKIN.m_BlnIgnoreUserInfo = false;
            this.m_txtSTERNSKIN.m_BlnPartControl = false;
            this.m_txtSTERNSKIN.m_BlnReadOnly = false;
            this.m_txtSTERNSKIN.m_BlnUnderLineDST = false;
            this.m_txtSTERNSKIN.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtSTERNSKIN.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtSTERNSKIN.m_IntCanModifyTime = 6;
            this.m_txtSTERNSKIN.m_IntPartControlLength = 0;
            this.m_txtSTERNSKIN.m_IntPartControlStartIndex = 0;
            this.m_txtSTERNSKIN.m_StrUserID = "";
            this.m_txtSTERNSKIN.m_StrUserName = "";
            this.m_txtSTERNSKIN.Multiline = false;
            this.m_txtSTERNSKIN.Name = "m_txtSTERNSKIN";
            this.m_txtSTERNSKIN.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtSTERNSKIN.Size = new System.Drawing.Size(159, 27);
            this.m_txtSTERNSKIN.TabIndex = 10000111;
            this.m_txtSTERNSKIN.Tag = "8";
            this.m_txtSTERNSKIN.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label7.Location = new System.Drawing.Point(19, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 14);
            this.label7.TabIndex = 10000105;
            this.label7.Text = "咽充血";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label8.Location = new System.Drawing.Point(19, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 14);
            this.label8.TabIndex = 10000105;
            this.label8.Text = "白点";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.m_txtPHARYNX);
            this.groupBox3.Controls.Add(this.m_txtWHITEPOINT);
            this.groupBox3.Font = new System.Drawing.Font("宋体", 10.5F);
            this.groupBox3.Location = new System.Drawing.Point(504, 44);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(233, 100);
            this.groupBox3.TabIndex = 10000109;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "口";
            // 
            // m_txtPHARYNX
            // 
            this.m_txtPHARYNX.AccessibleDescription = "咽充血";
            this.m_txtPHARYNX.BackColor = System.Drawing.Color.White;
            this.m_txtPHARYNX.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPHARYNX.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtPHARYNX.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPHARYNX.Location = new System.Drawing.Point(75, 27);
            this.m_txtPHARYNX.m_BlnIgnoreUserInfo = false;
            this.m_txtPHARYNX.m_BlnPartControl = false;
            this.m_txtPHARYNX.m_BlnReadOnly = false;
            this.m_txtPHARYNX.m_BlnUnderLineDST = false;
            this.m_txtPHARYNX.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPHARYNX.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPHARYNX.m_IntCanModifyTime = 6;
            this.m_txtPHARYNX.m_IntPartControlLength = 0;
            this.m_txtPHARYNX.m_IntPartControlStartIndex = 0;
            this.m_txtPHARYNX.m_StrUserID = "";
            this.m_txtPHARYNX.m_StrUserName = "";
            this.m_txtPHARYNX.Multiline = false;
            this.m_txtPHARYNX.Name = "m_txtPHARYNX";
            this.m_txtPHARYNX.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtPHARYNX.Size = new System.Drawing.Size(149, 28);
            this.m_txtPHARYNX.TabIndex = 10000111;
            this.m_txtPHARYNX.Tag = "8";
            this.m_txtPHARYNX.Text = "";
            // 
            // m_txtWHITEPOINT
            // 
            this.m_txtWHITEPOINT.AccessibleDescription = "白点";
            this.m_txtWHITEPOINT.BackColor = System.Drawing.Color.White;
            this.m_txtWHITEPOINT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtWHITEPOINT.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtWHITEPOINT.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtWHITEPOINT.Location = new System.Drawing.Point(75, 64);
            this.m_txtWHITEPOINT.m_BlnIgnoreUserInfo = false;
            this.m_txtWHITEPOINT.m_BlnPartControl = false;
            this.m_txtWHITEPOINT.m_BlnReadOnly = false;
            this.m_txtWHITEPOINT.m_BlnUnderLineDST = false;
            this.m_txtWHITEPOINT.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtWHITEPOINT.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtWHITEPOINT.m_IntCanModifyTime = 6;
            this.m_txtWHITEPOINT.m_IntPartControlLength = 0;
            this.m_txtWHITEPOINT.m_IntPartControlStartIndex = 0;
            this.m_txtWHITEPOINT.m_StrUserID = "";
            this.m_txtWHITEPOINT.m_StrUserName = "";
            this.m_txtWHITEPOINT.Multiline = false;
            this.m_txtWHITEPOINT.Name = "m_txtWHITEPOINT";
            this.m_txtWHITEPOINT.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtWHITEPOINT.Size = new System.Drawing.Size(149, 27);
            this.m_txtWHITEPOINT.TabIndex = 10000111;
            this.m_txtWHITEPOINT.Tag = "8";
            this.m_txtWHITEPOINT.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label4.Location = new System.Drawing.Point(19, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 10000105;
            this.label4.Text = "结膜充血";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label5.Location = new System.Drawing.Point(19, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 14);
            this.label5.TabIndex = 10000105;
            this.label5.Text = "分泌物";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.m_txtCONJUNCTIVA);
            this.groupBox2.Controls.Add(this.m_txtSECRETION);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 10.5F);
            this.groupBox2.Location = new System.Drawing.Point(243, 44);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(252, 100);
            this.groupBox2.TabIndex = 10000108;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "眼";
            // 
            // m_txtCONJUNCTIVA
            // 
            this.m_txtCONJUNCTIVA.AccessibleDescription = "结膜充血";
            this.m_txtCONJUNCTIVA.BackColor = System.Drawing.Color.White;
            this.m_txtCONJUNCTIVA.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCONJUNCTIVA.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtCONJUNCTIVA.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCONJUNCTIVA.Location = new System.Drawing.Point(93, 27);
            this.m_txtCONJUNCTIVA.m_BlnIgnoreUserInfo = false;
            this.m_txtCONJUNCTIVA.m_BlnPartControl = false;
            this.m_txtCONJUNCTIVA.m_BlnReadOnly = false;
            this.m_txtCONJUNCTIVA.m_BlnUnderLineDST = false;
            this.m_txtCONJUNCTIVA.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtCONJUNCTIVA.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtCONJUNCTIVA.m_IntCanModifyTime = 6;
            this.m_txtCONJUNCTIVA.m_IntPartControlLength = 0;
            this.m_txtCONJUNCTIVA.m_IntPartControlStartIndex = 0;
            this.m_txtCONJUNCTIVA.m_StrUserID = "";
            this.m_txtCONJUNCTIVA.m_StrUserName = "";
            this.m_txtCONJUNCTIVA.Multiline = false;
            this.m_txtCONJUNCTIVA.Name = "m_txtCONJUNCTIVA";
            this.m_txtCONJUNCTIVA.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtCONJUNCTIVA.Size = new System.Drawing.Size(150, 28);
            this.m_txtCONJUNCTIVA.TabIndex = 10000111;
            this.m_txtCONJUNCTIVA.Tag = "8";
            this.m_txtCONJUNCTIVA.Text = "";
            // 
            // m_txtSECRETION
            // 
            this.m_txtSECRETION.AccessibleDescription = "分泌物";
            this.m_txtSECRETION.BackColor = System.Drawing.Color.White;
            this.m_txtSECRETION.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSECRETION.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtSECRETION.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSECRETION.Location = new System.Drawing.Point(93, 64);
            this.m_txtSECRETION.m_BlnIgnoreUserInfo = false;
            this.m_txtSECRETION.m_BlnPartControl = false;
            this.m_txtSECRETION.m_BlnReadOnly = false;
            this.m_txtSECRETION.m_BlnUnderLineDST = false;
            this.m_txtSECRETION.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtSECRETION.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtSECRETION.m_IntCanModifyTime = 6;
            this.m_txtSECRETION.m_IntPartControlLength = 0;
            this.m_txtSECRETION.m_IntPartControlStartIndex = 0;
            this.m_txtSECRETION.m_StrUserID = "";
            this.m_txtSECRETION.m_StrUserName = "";
            this.m_txtSECRETION.Multiline = false;
            this.m_txtSECRETION.Name = "m_txtSECRETION";
            this.m_txtSECRETION.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtSECRETION.Size = new System.Drawing.Size(150, 27);
            this.m_txtSECRETION.TabIndex = 10000111;
            this.m_txtSECRETION.Tag = "8";
            this.m_txtSECRETION.Text = "";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label14.Location = new System.Drawing.Point(28, 302);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 14);
            this.label14.TabIndex = 10000105;
            this.label14.Text = "心肺";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label15.Location = new System.Drawing.Point(261, 302);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 14);
            this.label15.TabIndex = 10000105;
            this.label15.Text = "腹部";
            // 
            // m_txtRemark
            // 
            this.m_txtRemark.AccessibleDescription = "备注";
            this.m_txtRemark.BackColor = System.Drawing.Color.White;
            this.m_txtRemark.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtRemark.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtRemark.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtRemark.Location = new System.Drawing.Point(75, 339);
            this.m_txtRemark.m_BlnIgnoreUserInfo = false;
            this.m_txtRemark.m_BlnPartControl = false;
            this.m_txtRemark.m_BlnReadOnly = false;
            this.m_txtRemark.m_BlnUnderLineDST = false;
            this.m_txtRemark.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtRemark.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtRemark.m_IntCanModifyTime = 6;
            this.m_txtRemark.m_IntPartControlLength = 0;
            this.m_txtRemark.m_IntPartControlStartIndex = 0;
            this.m_txtRemark.m_StrUserID = "";
            this.m_txtRemark.m_StrUserName = "";
            this.m_txtRemark.Multiline = false;
            this.m_txtRemark.Name = "m_txtRemark";
            this.m_txtRemark.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtRemark.Size = new System.Drawing.Size(653, 27);
            this.m_txtRemark.TabIndex = 10000110;
            this.m_txtRemark.Tag = "8";
            this.m_txtRemark.Text = "";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label16.Location = new System.Drawing.Point(28, 339);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 14);
            this.label16.TabIndex = 10000111;
            this.label16.Text = "备注";
            // 
            // m_cmdOK
            // 
            this.m_cmdOK.AccessibleDescription = "确定";
            this.m_cmdOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.m_cmdOK.DefaultScheme = true;
            this.m_cmdOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdOK.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdOK.Hint = "";
            this.m_cmdOK.Location = new System.Drawing.Point(551, 375);
            this.m_cmdOK.Name = "m_cmdOK";
            this.m_cmdOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdOK.Size = new System.Drawing.Size(74, 37);
            this.m_cmdOK.TabIndex = 10000106;
            this.m_cmdOK.Tag = "1";
            this.m_cmdOK.Text = "确定";
            this.m_cmdOK.Click += new System.EventHandler(this.m_cmdOK_Click);
            // 
            // m_cmdCancle
            // 
            this.m_cmdCancle.AccessibleDescription = "取消";
            this.m_cmdCancle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.m_cmdCancle.DefaultScheme = true;
            this.m_cmdCancle.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdCancle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdCancle.Hint = "";
            this.m_cmdCancle.Location = new System.Drawing.Point(644, 375);
            this.m_cmdCancle.Name = "m_cmdCancle";
            this.m_cmdCancle.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCancle.Size = new System.Drawing.Size(75, 37);
            this.m_cmdCancle.TabIndex = 10000106;
            this.m_cmdCancle.Tag = "1";
            this.m_cmdCancle.Text = "取消";
            this.m_cmdCancle.Click += new System.EventHandler(this.m_cmdCancle_Click);
            // 
            // m_txtHEARTLUNG
            // 
            this.m_txtHEARTLUNG.AccessibleDescription = "心肺";
            this.m_txtHEARTLUNG.BackColor = System.Drawing.Color.White;
            this.m_txtHEARTLUNG.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtHEARTLUNG.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtHEARTLUNG.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtHEARTLUNG.Location = new System.Drawing.Point(75, 299);
            this.m_txtHEARTLUNG.m_BlnIgnoreUserInfo = false;
            this.m_txtHEARTLUNG.m_BlnPartControl = false;
            this.m_txtHEARTLUNG.m_BlnReadOnly = false;
            this.m_txtHEARTLUNG.m_BlnUnderLineDST = false;
            this.m_txtHEARTLUNG.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtHEARTLUNG.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtHEARTLUNG.m_IntCanModifyTime = 6;
            this.m_txtHEARTLUNG.m_IntPartControlLength = 0;
            this.m_txtHEARTLUNG.m_IntPartControlStartIndex = 0;
            this.m_txtHEARTLUNG.m_StrUserID = "";
            this.m_txtHEARTLUNG.m_StrUserName = "";
            this.m_txtHEARTLUNG.Multiline = false;
            this.m_txtHEARTLUNG.Name = "m_txtHEARTLUNG";
            this.m_txtHEARTLUNG.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtHEARTLUNG.Size = new System.Drawing.Size(149, 27);
            this.m_txtHEARTLUNG.TabIndex = 10000111;
            this.m_txtHEARTLUNG.Tag = "8";
            this.m_txtHEARTLUNG.Text = "";
            // 
            // m_txtABDOMEN
            // 
            this.m_txtABDOMEN.AccessibleDescription = "腹部";
            this.m_txtABDOMEN.BackColor = System.Drawing.Color.White;
            this.m_txtABDOMEN.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtABDOMEN.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtABDOMEN.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtABDOMEN.Location = new System.Drawing.Point(308, 299);
            this.m_txtABDOMEN.m_BlnIgnoreUserInfo = false;
            this.m_txtABDOMEN.m_BlnPartControl = false;
            this.m_txtABDOMEN.m_BlnReadOnly = false;
            this.m_txtABDOMEN.m_BlnUnderLineDST = false;
            this.m_txtABDOMEN.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtABDOMEN.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtABDOMEN.m_IntCanModifyTime = 6;
            this.m_txtABDOMEN.m_IntPartControlLength = 0;
            this.m_txtABDOMEN.m_IntPartControlStartIndex = 0;
            this.m_txtABDOMEN.m_StrUserID = "";
            this.m_txtABDOMEN.m_StrUserName = "";
            this.m_txtABDOMEN.Multiline = false;
            this.m_txtABDOMEN.Name = "m_txtABDOMEN";
            this.m_txtABDOMEN.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtABDOMEN.Size = new System.Drawing.Size(177, 27);
            this.m_txtABDOMEN.TabIndex = 10000111;
            this.m_txtABDOMEN.Tag = "8";
            this.m_txtABDOMEN.Text = "";
            // 
            // m_txtDoctorSign
            // 
            this.m_txtDoctorSign.AccessibleDescription = "签名(txt)";
            this.m_txtDoctorSign.Location = new System.Drawing.Point(110, 383);
            this.m_txtDoctorSign.Name = "m_txtDoctorSign";
            this.m_txtDoctorSign.ReadOnly = true;
            this.m_txtDoctorSign.Size = new System.Drawing.Size(100, 23);
            this.m_txtDoctorSign.TabIndex = 10000112;
            // 
            // frmNewBabyCircsRecord
            // 
            this.ClientSize = new System.Drawing.Size(760, 459);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.m_cmdDoctorSign);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.m_cmdOK);
            this.Controls.Add(this.m_cmdCancle);
            this.Controls.Add(this.m_txtRemark);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_dtpRecordTime);
            this.Controls.Add(this.m_cboBirthDays);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.m_txtHEARTLUNG);
            this.Controls.Add(this.m_txtABDOMEN);
            this.Controls.Add(this.m_txtDoctorSign);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmNewBabyCircsRecord";
            this.Text = "新生儿入室记录";
            this.Load += new System.EventHandler(this.frmNewBabyCircsRecord_Load);
            this.Controls.SetChildIndex(this.m_txtDoctorSign, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.m_txtABDOMEN, 0);
            this.Controls.SetChildIndex(this.m_txtHEARTLUNG, 0);
            this.Controls.SetChildIndex(this.groupBox6, 0);
            this.Controls.SetChildIndex(this.groupBox5, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.Controls.SetChildIndex(this.m_cboBirthDays, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_dtpRecordTime, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.m_txtRemark, 0);
            this.Controls.SetChildIndex(this.m_cmdCancle, 0);
            this.Controls.SetChildIndex(this.m_cmdOK, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.label40, 0);
            this.Controls.SetChildIndex(this.label32, 0);
            this.Controls.SetChildIndex(this.m_cmdDoctorSign, 0);
            this.Controls.SetChildIndex(this.label16, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void m_cmdCancle_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.None;
			this.Close();
		}

		private void m_cmdOK_Click(object sender, System.EventArgs e)
		{
			if(m_blnIsNew)
				m_mthAddNewRecord();
			else
				m_mthModifyRecord();
		}

		private void m_mthModifyRecord()
		{
			if(m_objCurrentRecord == null)
				return;
			clsNewBabyCircsRecord objNewRecord = m_objGetCircsRecordContentFromUI();
			
			string strNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			objNewRecord.m_strInPatientID = m_strMotherID;
			objNewRecord.m_dtmInPatientDate = DateTime.Parse(m_strInPatientDate);
			objNewRecord.m_dtmBIRTHTIME = DateTime.Parse(m_strBirthTime);
			objNewRecord.m_dtmOpenDate = m_objCurrentRecord.m_dtmOpenDate;
			objNewRecord.m_strCreateUserID = m_objCurrentRecord.m_strCreateUserID;
			objNewRecord.m_dtmCreateDate = m_objCurrentRecord.m_dtmCreateDate;
			objNewRecord.m_strModifyUserID = MDIParent.OperatorID;
			objNewRecord.m_dtmModifyDate = DateTime.Parse(strNow);

			clsPreModifyInfo p_objModifyInfo = new  clsPreModifyInfo();
			long lngRes = m_objDomain.m_lngModifyCircsRecord(m_objCurrentRecord,objNewRecord,out p_objModifyInfo);

			if(lngRes < 0)
				MDIParent.ShowInformationMessageBox("保存失败");
			else
			{		
				this.DialogResult = DialogResult.Yes;
				this.Close();
			}
		}

		private void m_mthAddNewRecord()
		{
			clsNewBabyCircsRecord objNewRecord = m_objGetCircsRecordContentFromUI();
			string strNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			objNewRecord.m_strInPatientID = m_strMotherID;
			objNewRecord.m_dtmInPatientDate = DateTime.Parse(m_strInPatientDate);
			objNewRecord.m_dtmBIRTHTIME = DateTime.Parse(m_strBirthTime);
			objNewRecord.m_dtmOpenDate = DateTime.Parse(strNow);
			objNewRecord.m_strCreateUserID = MDIParent.OperatorID;
			objNewRecord.m_dtmCreateDate = DateTime.Parse(strNow);
			objNewRecord.m_strModifyUserID = MDIParent.OperatorID;
			objNewRecord.m_dtmModifyDate = DateTime.Parse(strNow);

			clsPreModifyInfo p_objModifyInfo = new  clsPreModifyInfo();
			long lngRes = m_objDomain.m_lngAddNewCircsRecord(objNewRecord,out p_objModifyInfo);

			if(lngRes < 0)
				MDIParent.ShowInformationMessageBox("保存失败");
			else
			{
				this.DialogResult = DialogResult.Yes;
				this.Close();
			}
		}

		private void m_mthSetCircsRecordContentToUI(clsNewBabyCircsRecord objRecord)
		{
			if(objRecord != null)
			{
				m_dtpRecordTime.Value = objRecord.m_dtmRecordDate;
				m_cboBirthDays.Text = objRecord.m_strBIRTHDAYS == null ? "":objRecord.m_strBIRTHDAYS.Trim();
				m_txtBIRTHBURL.m_mthSetNewText(objRecord.m_strBIRTHBURL,objRecord.m_strBIRTHBURLXML);
				m_txtHAEMATOMA.m_mthSetNewText(objRecord.m_strHAEMATOMA,objRecord.m_strHAEMATOMAXML);
				m_txtFONTANEL.m_mthSetNewText(objRecord.m_strFONTANEL,objRecord.m_strFONTANELXML);
				m_txtCONJUNCTIVA.m_mthSetNewText(objRecord.m_strCONJUNCTIVA,objRecord.m_strCONJUNCTIVAXML);
				m_txtSECRETION.m_mthSetNewText(objRecord.m_strSECRETION,objRecord.m_strSECRETIONXML);
				m_txtPHARYNX.m_mthSetNewText(objRecord.m_strPHARYNX,objRecord.m_strPHARYNXXML);
				m_txtWHITEPOINT.m_mthSetNewText(objRecord.m_strWHITEPOINT,objRecord.m_strWHITEPOINTXML);
				m_txtICTERUS.m_mthSetNewText(objRecord.m_strICTERUS,objRecord.m_strICTERUSXML);
				m_txtFESTER.m_mthSetNewText(objRecord.m_strFESTER,objRecord.m_strREMARKXML);
				m_txtBLEEDING.m_mthSetNewText(objRecord.m_strBLEEDING,objRecord.m_strBLEEDINGXML);
				m_txtAGNAIL.m_mthSetNewText(objRecord.m_strAGNAIL,objRecord.m_strAGNAILXML);
				m_txtREDSTERN.m_mthSetNewText(objRecord.m_strREDSTERN,objRecord.m_strREDSTERNXML);
				m_txtSTERNSKIN.m_mthSetNewText(objRecord.m_strSTERNSKIN,objRecord.m_strSTERNSKINXML);
				m_txtHEARTLUNG.m_mthSetNewText(objRecord.m_strHEARTLUNG,objRecord.m_strHEARTLUNGXML);
				m_txtABDOMEN.m_mthSetNewText(objRecord.m_strABDOMEN,objRecord.m_strABDOMENXML);
				m_txtRemark.m_mthSetNewText(objRecord.m_strREMARK,objRecord.m_strREMARKXML);

                clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
                objEmployeeSign.m_lngGetEmpByID(objRecord.m_strSignUserID, out objEmpVO);
                if (objEmpVO != null)
                {
                    m_txtDoctorSign.Tag = objEmpVO;
                    m_txtDoctorSign.Text = objEmpVO.m_strLASTNAME_VCHR;
                }

                //if(objRecord.m_strSignUserName != "" && objRecord.m_strSignUserName != null && objRecord.m_strSignUserID != "" &&objRecord.m_strSignUserID != null)
                //{
                //    m_txtDoctorSign.Text = objRecord.m_strSignUserName;

                //    clsEmployee objEmp = new clsEmployee(objRecord.m_strSignUserID);
                //    m_txtDoctorSign.Tag = objEmp;
                //}
			}

			m_objCurrentRecord = objRecord;
		}

		private clsNewBabyCircsRecord m_objGetCircsRecordContentFromUI()
		{
			clsNewBabyCircsRecord objRecord = new clsNewBabyCircsRecord();

			objRecord.m_dtmRecordDate = m_dtpRecordTime.Value;
			objRecord.m_strBIRTHDAYS = m_cboBirthDays.Text;

			objRecord.m_strBIRTHBURL = m_txtBIRTHBURL.m_strGetRightText();
			objRecord.m_strBIRTHBURLXML = m_txtBIRTHBURL.m_strGetXmlText();

			objRecord.m_strHAEMATOMA = m_txtHAEMATOMA.m_strGetRightText();
			objRecord.m_strHAEMATOMAXML = m_txtHAEMATOMA.m_strGetXmlText();

			objRecord.m_strFONTANEL = m_txtFONTANEL.m_strGetRightText();
			objRecord.m_strFONTANELXML = m_txtFONTANEL.m_strGetXmlText();

			objRecord.m_strCONJUNCTIVA = m_txtCONJUNCTIVA.m_strGetRightText();
			objRecord.m_strCONJUNCTIVAXML = m_txtCONJUNCTIVA.m_strGetXmlText();

			objRecord.m_strSECRETION = m_txtSECRETION.m_strGetRightText();
			objRecord.m_strSECRETIONXML = m_txtSECRETION.m_strGetXmlText();

			objRecord.m_strPHARYNX = m_txtPHARYNX.m_strGetRightText();
			objRecord.m_strPHARYNXXML = m_txtPHARYNX.m_strGetXmlText();

			objRecord.m_strWHITEPOINT = m_txtWHITEPOINT.m_strGetRightText();
			objRecord.m_strWHITEPOINTXML = m_txtWHITEPOINT.m_strGetXmlText();

			objRecord.m_strICTERUS = m_txtICTERUS.m_strGetRightText();
			objRecord.m_strICTERUSXML = m_txtICTERUS.m_strGetXmlText();

			objRecord.m_strFESTER = m_txtFESTER.m_strGetRightText();
			objRecord.m_strFESTERXML = m_txtFESTER.m_strGetXmlText();

			objRecord.m_strBLEEDING = m_txtBLEEDING.m_strGetRightText();
			objRecord.m_strBLEEDINGXML = m_txtBLEEDING.m_strGetXmlText();

			objRecord.m_strAGNAIL = m_txtAGNAIL.m_strGetRightText();
			objRecord.m_strAGNAILXML = m_txtAGNAIL.m_strGetXmlText();

			objRecord.m_strREDSTERN = m_txtREDSTERN.m_strGetRightText();
			objRecord.m_strREDSTERNXML = m_txtREDSTERN.m_strGetXmlText();

			objRecord.m_strSTERNSKIN = m_txtSTERNSKIN.m_strGetRightText();
			objRecord.m_strSTERNSKINXML = m_txtSTERNSKIN.m_strGetXmlText();

			objRecord.m_strHEARTLUNG = m_txtHEARTLUNG.m_strGetRightText();
			objRecord.m_strHEARTLUNGXML = m_txtHEARTLUNG.m_strGetXmlText();

			objRecord.m_strABDOMEN = m_txtABDOMEN.m_strGetRightText();
			objRecord.m_strABDOMENXML = m_txtABDOMEN.m_strGetXmlText();

			objRecord.m_strREMARK = m_txtRemark.m_strGetRightText();
			objRecord.m_strREMARKXML = m_txtRemark.m_strGetXmlText();

            if (m_txtDoctorSign.Tag != null)
            {               
                objRecord.m_strSignUserID = ((clsEmrEmployeeBase_VO)m_txtDoctorSign.Tag).m_strEMPID_CHR;
                objRecord.m_strSignUserName = m_txtDoctorSign.Text;

                //clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
                //objEmployeeSign.m_lngGetEmpByID(objRecord.m_strSignUserID, out objEmpVO);
                //if (objEmpVO != null)
                //{
                //    m_txtDoctorSign.Tag = objEmpVO;
                //    m_txtDoctorSign.Text = objEmpVO.m_strLASTNAME_VCHR;
                //    objRecord.m_strSignUserName = objEmpVO.m_strGetTechnicalRankAndName;
                //}      
            }


                 

			return objRecord;
		}

		public clsNewBabyCircsRecord m_objGetSingleContent()
		{
			clsNewBabyCircsRecord objRecord = new clsNewBabyCircsRecord();
			long lngRes = m_objDomain.m_lngGetCircsRecordContent(m_strMotherID,m_strInPatientDate,m_strOpenTime,out objRecord);
			
			return objRecord;
		}

		private void frmNewBabyCircsRecord_Load(object sender, System.EventArgs e)
		{
            if (m_BlnNeedContextMenu)
                m_mthAddRichTemplateInContainer(this);
			if(!m_blnIsNew)
			{
				clsNewBabyCircsRecord objRecord = m_objGetSingleContent();

				m_mthSetCircsRecordContentToUI(objRecord);

				m_mthSetModifyControl(m_objCurrentRecord, false);
			}
			else
			{
				try
				{
					TimeSpan tsBirthDays = m_dtpRecordTime.Value - DateTime.Parse(m_strBirthTime);
					m_cboBirthDays.Text = (tsBirthDays.Days + 1).ToString();
                    m_mthSetDefaultValue();
					m_mthSetModifyControl(null,true);
				}
				catch{}
			}
		}

		public string m_StrCreateDate
		{
			get{return m_strOpenTime;}
		}

		
		/// <summary>
		/// 设置窗体中控件输入文本的颜色
		/// </summary>
		/// <param name="p_ctlControl"></param>
		/// <param name="p_clrColor"></param>
		private void m_mthSetRichTextModifyColor(Control p_ctlControl,System.Drawing.Color p_clrColor)
		{
			#region 设置控件输入文本的颜色,Jacky-2003-3-24	
			string strTypeName = p_ctlControl.GetType().FullName;			
			if(strTypeName=="com.digitalwave.Utility.Controls.ctlRichTextBox")			
				((com.digitalwave.Utility.Controls.ctlRichTextBox)p_ctlControl).m_ClrOldPartInsertText = p_clrColor;
			else if(strTypeName=="com.digitalwave.controls.ctlRichTextBox")
				((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_ClrOldPartInsertText = p_clrColor;
			
			if(p_ctlControl.HasChildren && strTypeName !="System.Windows.Forms.DataGrid" )
			{									
				foreach(Control subcontrol in p_ctlControl.Controls)
				{										
					m_mthSetRichTextModifyColor(subcontrol,p_clrColor);					
				} 	
			}						
			#endregion			
		}
		
		
		private void m_mthSetRichTextCanModifyLast(Control p_ctlControl,bool p_blnCanModifyLast )
		{
			#region 设置控件输入文本的是否最后修改,Jacky-2003-3-24	
			string strTypeName = p_ctlControl.GetType().FullName;			
			if(strTypeName=="com.digitalwave.Utility.Controls.ctlRichTextBox")
			{				
				((com.digitalwave.Utility.Controls.ctlRichTextBox)p_ctlControl).m_BlnCanModifyLast = p_blnCanModifyLast;
			}
			else if(strTypeName=="com.digitalwave.controls.ctlRichTextBox")
			{
				((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_BlnCanModifyLast = p_blnCanModifyLast;
			}
			
			if(p_ctlControl.HasChildren && strTypeName !="System.Windows.Forms.DataGrid" )
			{									
				foreach(Control subcontrol in p_ctlControl.Controls)
				{										
					m_mthSetRichTextCanModifyLast(subcontrol,p_blnCanModifyLast);					
				} 	
			}						
			#endregion			
		}

		/// <summary>
		/// 设置是否控制修改（修改留痕迹）。
		/// </summary>
		/// <param name="p_objRecordContent"></param>
		/// <param name="p_blnReset"></param>
		protected void m_mthSetModifyControl(clsNewBabyCircsRecord  p_objRecordContent,bool p_blnReset)
		{
			//根据书写规范设置具体窗体的书写控制，由子窗体重载实现
			if(p_blnReset==true)
			{
				m_mthSetRichTextModifyColor(this,clsHRPColor.s_ClrInputFore);
				m_mthSetRichTextCanModifyLast(this,true);
			}
			else if(p_objRecordContent!=null)
			{
				m_mthSetRichTextModifyColor(this,Color.Red);
				m_mthSetRichTextCanModifyLast(this,m_blnGetCanModifyLast(p_objRecordContent.m_strModifyUserID));
			}
		}

		/// <summary>
		/// 输入框内，内容颜色的设置方法
		/// 如果该记录的最后修改人就是当前的登陆人，可以修改该记录
		/// 否则，不可修改（其中6小时的控制，在liyi的richtextbox中已有控制）
		/// </summary>
		/// <returns></returns>
		private bool m_blnGetCanModifyLast(string p_strModifyUserID)
		{			
			if(p_strModifyUserID==null || p_strModifyUserID.Trim() == MDIParent.OperatorID.Trim())
				return true;
			else 
				return false;
		}

        private void m_dtpRecordTime_evtValueChanged(object sender, EventArgs e)
        {
            if (m_dtpRecordTime.Value < Convert.ToDateTime(m_strBirthTime))
            {
                MessageBox.Show("记录时间小于出生时间，请输入正确的时间！");
                return;
            }
            TimeSpan m_ts = m_dtpRecordTime.Value - Convert.ToDateTime(m_strBirthTime);
            m_cboBirthDays.Text = Convert.ToString(m_ts.Days + 1);
        }
        private void m_mthSetDefaultValue()
        {
           
            m_txtHAEMATOMA.Text = "无";
            m_txtFONTANEL.Text = "平";
            m_txtCONJUNCTIVA.Text = "无";
            m_txtSECRETION.Text = "无";
            m_txtPHARYNX.Text = "无";
            m_txtWHITEPOINT.Text = "无";
            m_txtICTERUS.Text = "无";
            m_txtFESTER.Text = "无";
            m_txtBLEEDING.Text = "无";
            m_txtAGNAIL.Text = "无";
            m_txtREDSTERN.Text = "无";
            m_txtSTERNSKIN.Text = "正常";
            m_txtHEARTLUNG.Text = "正常";
            m_txtABDOMEN.Text = "正常";
        }

	}
}
