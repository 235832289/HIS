
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using iCareData;
using com.digitalwave.controls;
using System.Data;
using HRP;
using System.Xml;
using com.digitalwave.Emr.Signature_gui;
namespace iCare
{
	/// <summary>
	/// 静脉特殊化疗用药观察记录表(广西)(增加，修改窗体)
	/// </summary>
	public class frmVeinSpecialUseDrugCon : frmDiseaseTrackBase
	{
		#region define
		private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
		private PinkieControls.ButtonXP m_cmdOK;
        private PinkieControls.ButtonXP m_cmdCancel;
		private clsEmployeeSignTool m_objSignTool;
		private clsCommonUseToolCollection m_objCUTC;
		private PinkieControls.ButtonXP m_cmdSign;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label18;


		public System.DateTime m_dtmBEFOREHAND_CHR = System.DateTime.Now;
		public string m_strLAYCOUNT_CHR = "";
		private System.Windows.Forms.Label label32;//产次
		public string m_strFlag = "0";//是否新增
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton m_rdbNormal;
		private System.Windows.Forms.RadioButton m_rdbNotNorMal;
		private com.digitalwave.controls.ctlRichTextBox m_txtSOLVE_CHR;
		private com.digitalwave.controls.ctlRichTextBox m_txtREMARK_CHR;
		private com.digitalwave.controls.ctlRichTextBox m_txtDROP_CHR;
		private com.digitalwave.controls.ctlRichTextBox m_txtINGEAR_CHR;
		private com.digitalwave.controls.ctlRichTextBox m_txtABNORMITY_CHR;
		private System.Windows.Forms.DateTimePicker m_dtmDate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker m_dtmTime;
		private System.Windows.Forms.Label label2;  

		private  string m_ID_CHR = "";
		private DateTime m_dtmBegin;
		private DateTime m_dtmEnd;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboMEDICINENAME_CHR;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboSOLVE_CHR;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboREMARK_CHR;
		private com.digitalwave.controls.ctlRichTextBox m_txtMEDICINENAME_CHR;
        private TextBox txtSign;
		private string m_strInpatientDate = "";
        //定义签名类
        private clsEmrSignToolCollection m_objSign;
		/// <summary>
		/// 
		/// </summary>
		/// <param name="p_ID_CHR">如果为-3,则为新建开始时间</param>
		public frmVeinSpecialUseDrugCon(string p_ID_CHR,DateTime p_dtmBegin,DateTime p_dtmEnd,string p_strInpatientDate)
		{
			
			m_strInpatientDate = p_strInpatientDate;
			m_dtmBegin = p_dtmBegin;
			m_dtmEnd = p_dtmEnd;
			if(p_ID_CHR ==null)
				p_ID_CHR = "";

			m_ID_CHR = p_ID_CHR;
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			m_mthSetRichTextBoxAttribInControl(this);

            //签名常用值
            m_objSign = new clsEmrSignToolCollection();
            m_objSign.m_mthBindEmployeeSign(m_cmdSign, txtSign, 2, true, clsEMRLogin.LoginInfo.m_strEmpID);

			this.Size = new System.Drawing.Size(486, 312);
		}

		public void m_setLaycout()
		{
			if(m_strFlag == "0")
			{
			}
		}
		public override int m_IntFormID
		{
			get
			{
				return 120;
			}
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_cboMEDICINENAME_CHR = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_txtABNORMITY_CHR = new com.digitalwave.controls.ctlRichTextBox();
            this.m_rdbNotNorMal = new System.Windows.Forms.RadioButton();
            this.m_rdbNormal = new System.Windows.Forms.RadioButton();
            this.m_txtINGEAR_CHR = new com.digitalwave.controls.ctlRichTextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.m_cboSOLVE_CHR = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_txtDROP_CHR = new com.digitalwave.controls.ctlRichTextBox();
            this.m_cboREMARK_CHR = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_txtSOLVE_CHR = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtREMARK_CHR = new com.digitalwave.controls.ctlRichTextBox();
            this.m_cmdOK = new PinkieControls.ButtonXP();
            this.m_cmdCancel = new PinkieControls.ButtonXP();
            this.m_cmdSign = new PinkieControls.ButtonXP();
            this.m_dtmDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.m_dtmTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtMEDICINENAME_CHR = new com.digitalwave.controls.ctlRichTextBox();
            this.txtSign = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_trvCreateDate
            // 
            this.m_trvCreateDate.LineColor = System.Drawing.Color.Black;
            this.m_trvCreateDate.Location = new System.Drawing.Point(0, -88);
            this.m_trvCreateDate.Size = new System.Drawing.Size(212, 96);
            // 
            // lblCreateDateTitle
            // 
            this.lblCreateDateTitle.Location = new System.Drawing.Point(16, -8);
            this.lblCreateDateTitle.Visible = false;
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.Location = new System.Drawing.Point(80, -8);
            this.m_dtpCreateDate.TabIndex = 10000;
            this.m_dtpCreateDate.Visible = false;
            // 
            // m_dtpGetDataTime
            // 
            this.m_dtpGetDataTime.Location = new System.Drawing.Point(0, -56);
            // 
            // m_lblGetDataTime
            // 
            this.m_lblGetDataTime.Location = new System.Drawing.Point(0, -56);
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(0, -120);
            this.lblSex.Size = new System.Drawing.Size(48, 56);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(0, -120);
            this.lblAge.Size = new System.Drawing.Size(52, 56);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(0, -112);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(0, -80);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(0, -112);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(0, -120);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(0, -120);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(32, -48);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(0, -144);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(116, 141);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(0, -88);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(0, -120);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(0, -120);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(80, -56);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(328, 40);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(280, 24);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(80, -88);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(32, -80);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(0, -80);
            this.m_cmdNewTemplate.Size = new System.Drawing.Size(84, 69);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.Location = new System.Drawing.Point(0, -120);
            this.m_cmdNext.Size = new System.Drawing.Size(24, 58);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(0, -120);
            this.m_cmdPre.Size = new System.Drawing.Size(24, 58);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(0, -112);
            this.m_lblForTitle.Size = new System.Drawing.Size(16, 60);
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(248, 63);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(0, -32);
            // 
            // groupBox3
            // 
            this.groupBox3.AccessibleDescription = "ctlRichTextBox9_TextChanged";
            this.groupBox3.Controls.Add(this.m_cboMEDICINENAME_CHR);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.m_txtDROP_CHR);
            this.groupBox3.Controls.Add(this.m_cboREMARK_CHR);
            this.groupBox3.Location = new System.Drawing.Point(32, 40);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(432, 184);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // m_cboMEDICINENAME_CHR
            // 
            this.m_cboMEDICINENAME_CHR.AccessibleDescription = "";
            this.m_cboMEDICINENAME_CHR.BorderColor = System.Drawing.Color.Black;
            this.m_cboMEDICINENAME_CHR.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboMEDICINENAME_CHR.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboMEDICINENAME_CHR.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboMEDICINENAME_CHR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboMEDICINENAME_CHR.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboMEDICINENAME_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboMEDICINENAME_CHR.ListBackColor = System.Drawing.Color.White;
            this.m_cboMEDICINENAME_CHR.ListForeColor = System.Drawing.Color.Black;
            this.m_cboMEDICINENAME_CHR.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboMEDICINENAME_CHR.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboMEDICINENAME_CHR.Location = new System.Drawing.Point(96, 24);
            this.m_cboMEDICINENAME_CHR.m_BlnEnableItemEventMenu = true;
            this.m_cboMEDICINENAME_CHR.Name = "m_cboMEDICINENAME_CHR";
            this.m_cboMEDICINENAME_CHR.SelectedIndex = -1;
            this.m_cboMEDICINENAME_CHR.SelectedItem = null;
            this.m_cboMEDICINENAME_CHR.SelectionStart = 0;
            this.m_cboMEDICINENAME_CHR.Size = new System.Drawing.Size(112, 23);
            this.m_cboMEDICINENAME_CHR.TabIndex = 1112;
            this.m_cboMEDICINENAME_CHR.TextBackColor = System.Drawing.Color.White;
            this.m_cboMEDICINENAME_CHR.TextForeColor = System.Drawing.Color.Black;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_txtABNORMITY_CHR);
            this.groupBox1.Controls.Add(this.m_rdbNotNorMal);
            this.groupBox1.Controls.Add(this.m_rdbNormal);
            this.groupBox1.Controls.Add(this.m_txtINGEAR_CHR);
            this.groupBox1.Controls.Add(this.label32);
            this.groupBox1.Controls.Add(this.m_cboSOLVE_CHR);
            this.groupBox1.Location = new System.Drawing.Point(8, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 80);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "穿刺点";
            // 
            // m_txtABNORMITY_CHR
            // 
            this.m_txtABNORMITY_CHR.AccessibleDescription = "";
            this.m_txtABNORMITY_CHR.BackColor = System.Drawing.Color.White;
            this.m_txtABNORMITY_CHR.Enabled = false;
            this.m_txtABNORMITY_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtABNORMITY_CHR.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtABNORMITY_CHR.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtABNORMITY_CHR.Location = new System.Drawing.Point(256, 16);
            this.m_txtABNORMITY_CHR.m_BlnIgnoreUserInfo = false;
            this.m_txtABNORMITY_CHR.m_BlnPartControl = false;
            this.m_txtABNORMITY_CHR.m_BlnReadOnly = false;
            this.m_txtABNORMITY_CHR.m_BlnUnderLineDST = false;
            this.m_txtABNORMITY_CHR.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtABNORMITY_CHR.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtABNORMITY_CHR.m_IntCanModifyTime = 6;
            this.m_txtABNORMITY_CHR.m_IntPartControlLength = 0;
            this.m_txtABNORMITY_CHR.m_IntPartControlStartIndex = 0;
            this.m_txtABNORMITY_CHR.m_StrUserID = "";
            this.m_txtABNORMITY_CHR.m_StrUserName = "";
            this.m_txtABNORMITY_CHR.MaxLength = 3000;
            this.m_txtABNORMITY_CHR.Multiline = false;
            this.m_txtABNORMITY_CHR.Name = "m_txtABNORMITY_CHR";
            this.m_txtABNORMITY_CHR.Size = new System.Drawing.Size(120, 22);
            this.m_txtABNORMITY_CHR.TabIndex = 60;
            this.m_txtABNORMITY_CHR.Text = "";
            // 
            // m_rdbNotNorMal
            // 
            this.m_rdbNotNorMal.Location = new System.Drawing.Point(208, 16);
            this.m_rdbNotNorMal.Name = "m_rdbNotNorMal";
            this.m_rdbNotNorMal.Size = new System.Drawing.Size(56, 24);
            this.m_rdbNotNorMal.TabIndex = 50;
            this.m_rdbNotNorMal.Text = "异常";
            this.m_rdbNotNorMal.CheckedChanged += new System.EventHandler(this.m_rdbNotNorMal_CheckedChanged);
            // 
            // m_rdbNormal
            // 
            this.m_rdbNormal.Checked = true;
            this.m_rdbNormal.Location = new System.Drawing.Point(32, 16);
            this.m_rdbNormal.Name = "m_rdbNormal";
            this.m_rdbNormal.Size = new System.Drawing.Size(56, 24);
            this.m_rdbNormal.TabIndex = 30;
            this.m_rdbNormal.TabStop = true;
            this.m_rdbNormal.Text = "正常";
            this.m_rdbNormal.CheckedChanged += new System.EventHandler(this.m_rdbNormal_CheckedChanged);
            // 
            // m_txtINGEAR_CHR
            // 
            this.m_txtINGEAR_CHR.AccessibleDescription = "";
            this.m_txtINGEAR_CHR.BackColor = System.Drawing.Color.White;
            this.m_txtINGEAR_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtINGEAR_CHR.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtINGEAR_CHR.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtINGEAR_CHR.Location = new System.Drawing.Point(88, 16);
            this.m_txtINGEAR_CHR.m_BlnIgnoreUserInfo = false;
            this.m_txtINGEAR_CHR.m_BlnPartControl = false;
            this.m_txtINGEAR_CHR.m_BlnReadOnly = false;
            this.m_txtINGEAR_CHR.m_BlnUnderLineDST = false;
            this.m_txtINGEAR_CHR.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtINGEAR_CHR.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtINGEAR_CHR.m_IntCanModifyTime = 6;
            this.m_txtINGEAR_CHR.m_IntPartControlLength = 0;
            this.m_txtINGEAR_CHR.m_IntPartControlStartIndex = 0;
            this.m_txtINGEAR_CHR.m_StrUserID = "";
            this.m_txtINGEAR_CHR.m_StrUserName = "";
            this.m_txtINGEAR_CHR.MaxLength = 3000;
            this.m_txtINGEAR_CHR.Multiline = false;
            this.m_txtINGEAR_CHR.Name = "m_txtINGEAR_CHR";
            this.m_txtINGEAR_CHR.Size = new System.Drawing.Size(112, 22);
            this.m_txtINGEAR_CHR.TabIndex = 40;
            this.m_txtINGEAR_CHR.Text = "";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(16, 48);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(70, 14);
            this.label32.TabIndex = 902;
            this.label32.Text = "处理解决:";
            // 
            // m_cboSOLVE_CHR
            // 
            this.m_cboSOLVE_CHR.AccessibleDescription = "";
            this.m_cboSOLVE_CHR.BorderColor = System.Drawing.Color.Black;
            this.m_cboSOLVE_CHR.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboSOLVE_CHR.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboSOLVE_CHR.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboSOLVE_CHR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboSOLVE_CHR.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboSOLVE_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboSOLVE_CHR.ListBackColor = System.Drawing.Color.White;
            this.m_cboSOLVE_CHR.ListForeColor = System.Drawing.Color.Black;
            this.m_cboSOLVE_CHR.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboSOLVE_CHR.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboSOLVE_CHR.Location = new System.Drawing.Point(88, 48);
            this.m_cboSOLVE_CHR.m_BlnEnableItemEventMenu = true;
            this.m_cboSOLVE_CHR.Name = "m_cboSOLVE_CHR";
            this.m_cboSOLVE_CHR.SelectedIndex = -1;
            this.m_cboSOLVE_CHR.SelectedItem = null;
            this.m_cboSOLVE_CHR.SelectionStart = 0;
            this.m_cboSOLVE_CHR.Size = new System.Drawing.Size(296, 23);
            this.m_cboSOLVE_CHR.TabIndex = 1112;
            this.m_cboSOLVE_CHR.TextBackColor = System.Drawing.Color.White;
            this.m_cboSOLVE_CHR.TextForeColor = System.Drawing.Color.Black;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 14);
            this.label4.TabIndex = 1111;
            this.label4.Text = "药名:";
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(16, 32);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(24, 19);
            this.label18.TabIndex = 1110;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(48, 136);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 14);
            this.label15.TabIndex = 1104;
            this.label15.Text = "备注:";
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(368, 56);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(24, 19);
            this.label16.TabIndex = 1105;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(384, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 14);
            this.label5.TabIndex = 0;
            this.label5.Text = "滴/分";
            // 
            // m_txtDROP_CHR
            // 
            this.m_txtDROP_CHR.AccessibleDescription = "";
            this.m_txtDROP_CHR.BackColor = System.Drawing.Color.White;
            this.m_txtDROP_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDROP_CHR.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtDROP_CHR.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDROP_CHR.Location = new System.Drawing.Point(264, 24);
            this.m_txtDROP_CHR.m_BlnIgnoreUserInfo = false;
            this.m_txtDROP_CHR.m_BlnPartControl = false;
            this.m_txtDROP_CHR.m_BlnReadOnly = false;
            this.m_txtDROP_CHR.m_BlnUnderLineDST = false;
            this.m_txtDROP_CHR.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDROP_CHR.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDROP_CHR.m_IntCanModifyTime = 6;
            this.m_txtDROP_CHR.m_IntPartControlLength = 0;
            this.m_txtDROP_CHR.m_IntPartControlStartIndex = 0;
            this.m_txtDROP_CHR.m_StrUserID = "";
            this.m_txtDROP_CHR.m_StrUserName = "";
            this.m_txtDROP_CHR.MaxLength = 3000;
            this.m_txtDROP_CHR.Multiline = false;
            this.m_txtDROP_CHR.Name = "m_txtDROP_CHR";
            this.m_txtDROP_CHR.Size = new System.Drawing.Size(120, 22);
            this.m_txtDROP_CHR.TabIndex = 20;
            this.m_txtDROP_CHR.Text = "";
            // 
            // m_cboREMARK_CHR
            // 
            this.m_cboREMARK_CHR.AccessibleDescription = "";
            this.m_cboREMARK_CHR.BorderColor = System.Drawing.Color.Black;
            this.m_cboREMARK_CHR.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboREMARK_CHR.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboREMARK_CHR.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboREMARK_CHR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboREMARK_CHR.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboREMARK_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboREMARK_CHR.ListBackColor = System.Drawing.Color.White;
            this.m_cboREMARK_CHR.ListForeColor = System.Drawing.Color.Black;
            this.m_cboREMARK_CHR.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboREMARK_CHR.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboREMARK_CHR.Location = new System.Drawing.Point(96, 136);
            this.m_cboREMARK_CHR.m_BlnEnableItemEventMenu = true;
            this.m_cboREMARK_CHR.Name = "m_cboREMARK_CHR";
            this.m_cboREMARK_CHR.SelectedIndex = -1;
            this.m_cboREMARK_CHR.SelectedItem = null;
            this.m_cboREMARK_CHR.SelectionStart = 0;
            this.m_cboREMARK_CHR.Size = new System.Drawing.Size(296, 23);
            this.m_cboREMARK_CHR.TabIndex = 1112;
            this.m_cboREMARK_CHR.TextBackColor = System.Drawing.Color.White;
            this.m_cboREMARK_CHR.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_txtSOLVE_CHR
            // 
            this.m_txtSOLVE_CHR.AccessibleDescription = "";
            this.m_txtSOLVE_CHR.BackColor = System.Drawing.Color.White;
            this.m_txtSOLVE_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSOLVE_CHR.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtSOLVE_CHR.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSOLVE_CHR.Location = new System.Drawing.Point(8, 176);
            this.m_txtSOLVE_CHR.m_BlnIgnoreUserInfo = false;
            this.m_txtSOLVE_CHR.m_BlnPartControl = false;
            this.m_txtSOLVE_CHR.m_BlnReadOnly = false;
            this.m_txtSOLVE_CHR.m_BlnUnderLineDST = false;
            this.m_txtSOLVE_CHR.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtSOLVE_CHR.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtSOLVE_CHR.m_IntCanModifyTime = 6;
            this.m_txtSOLVE_CHR.m_IntPartControlLength = 0;
            this.m_txtSOLVE_CHR.m_IntPartControlStartIndex = 0;
            this.m_txtSOLVE_CHR.m_StrUserID = "";
            this.m_txtSOLVE_CHR.m_StrUserName = "";
            this.m_txtSOLVE_CHR.MaxLength = 3000;
            this.m_txtSOLVE_CHR.Multiline = false;
            this.m_txtSOLVE_CHR.Name = "m_txtSOLVE_CHR";
            this.m_txtSOLVE_CHR.Size = new System.Drawing.Size(40, 22);
            this.m_txtSOLVE_CHR.TabIndex = 70;
            this.m_txtSOLVE_CHR.Text = "";
            this.m_txtSOLVE_CHR.Visible = false;
            // 
            // m_txtREMARK_CHR
            // 
            this.m_txtREMARK_CHR.AccessibleDescription = "";
            this.m_txtREMARK_CHR.BackColor = System.Drawing.Color.White;
            this.m_txtREMARK_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtREMARK_CHR.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtREMARK_CHR.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtREMARK_CHR.Location = new System.Drawing.Point(8, 208);
            this.m_txtREMARK_CHR.m_BlnIgnoreUserInfo = false;
            this.m_txtREMARK_CHR.m_BlnPartControl = false;
            this.m_txtREMARK_CHR.m_BlnReadOnly = false;
            this.m_txtREMARK_CHR.m_BlnUnderLineDST = false;
            this.m_txtREMARK_CHR.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtREMARK_CHR.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtREMARK_CHR.m_IntCanModifyTime = 6;
            this.m_txtREMARK_CHR.m_IntPartControlLength = 0;
            this.m_txtREMARK_CHR.m_IntPartControlStartIndex = 0;
            this.m_txtREMARK_CHR.m_StrUserID = "";
            this.m_txtREMARK_CHR.m_StrUserName = "";
            this.m_txtREMARK_CHR.MaxLength = 3000;
            this.m_txtREMARK_CHR.Name = "m_txtREMARK_CHR";
            this.m_txtREMARK_CHR.Size = new System.Drawing.Size(48, 24);
            this.m_txtREMARK_CHR.TabIndex = 80;
            this.m_txtREMARK_CHR.Text = "";
            this.m_txtREMARK_CHR.Visible = false;
            // 
            // m_cmdOK
            // 
            this.m_cmdOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdOK.DefaultScheme = true;
            this.m_cmdOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdOK.Hint = "";
            this.m_cmdOK.Location = new System.Drawing.Point(256, 224);
            this.m_cmdOK.Name = "m_cmdOK";
            this.m_cmdOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdOK.Size = new System.Drawing.Size(64, 32);
            this.m_cmdOK.TabIndex = 120;
            this.m_cmdOK.Text = "确定";
            this.m_cmdOK.Click += new System.EventHandler(this.m_cmdOK_Click);
            // 
            // m_cmdCancel
            // 
            this.m_cmdCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdCancel.DefaultScheme = true;
            this.m_cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdCancel.Hint = "";
            this.m_cmdCancel.Location = new System.Drawing.Point(352, 224);
            this.m_cmdCancel.Name = "m_cmdCancel";
            this.m_cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCancel.Size = new System.Drawing.Size(64, 32);
            this.m_cmdCancel.TabIndex = 130;
            this.m_cmdCancel.Text = "取消";
            this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdCancel_Click);
            // 
            // m_cmdSign
            // 
            this.m_cmdSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdSign.DefaultScheme = true;
            this.m_cmdSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSign.Hint = "";
            this.m_cmdSign.Location = new System.Drawing.Point(56, 224);
            this.m_cmdSign.Name = "m_cmdSign";
            this.m_cmdSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSign.Size = new System.Drawing.Size(64, 32);
            this.m_cmdSign.TabIndex = 100;
            this.m_cmdSign.Text = "签名:";
            // 
            // m_dtmDate
            // 
            this.m_dtmDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtmDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtmDate.Location = new System.Drawing.Point(104, 22);
            this.m_dtmDate.Name = "m_dtmDate";
            this.m_dtmDate.Size = new System.Drawing.Size(120, 23);
            this.m_dtmDate.TabIndex = 10000047;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 10000046;
            this.label1.Text = "巡视日期:";
            // 
            // m_dtmTime
            // 
            this.m_dtmTime.CustomFormat = "HH:mm:ss";
            this.m_dtmTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtmTime.Location = new System.Drawing.Point(320, 22);
            this.m_dtmTime.Name = "m_dtmTime";
            this.m_dtmTime.Size = new System.Drawing.Size(120, 23);
            this.m_dtmTime.TabIndex = 10000047;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(248, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 10000046;
            this.label2.Text = "巡视时间:";
            // 
            // m_txtMEDICINENAME_CHR
            // 
            this.m_txtMEDICINENAME_CHR.AccessibleDescription = "";
            this.m_txtMEDICINENAME_CHR.BackColor = System.Drawing.Color.White;
            this.m_txtMEDICINENAME_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtMEDICINENAME_CHR.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtMEDICINENAME_CHR.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtMEDICINENAME_CHR.Location = new System.Drawing.Point(8, 152);
            this.m_txtMEDICINENAME_CHR.m_BlnIgnoreUserInfo = false;
            this.m_txtMEDICINENAME_CHR.m_BlnPartControl = false;
            this.m_txtMEDICINENAME_CHR.m_BlnReadOnly = false;
            this.m_txtMEDICINENAME_CHR.m_BlnUnderLineDST = false;
            this.m_txtMEDICINENAME_CHR.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtMEDICINENAME_CHR.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtMEDICINENAME_CHR.m_IntCanModifyTime = 6;
            this.m_txtMEDICINENAME_CHR.m_IntPartControlLength = 0;
            this.m_txtMEDICINENAME_CHR.m_IntPartControlStartIndex = 0;
            this.m_txtMEDICINENAME_CHR.m_StrUserID = "";
            this.m_txtMEDICINENAME_CHR.m_StrUserName = "";
            this.m_txtMEDICINENAME_CHR.MaxLength = 3000;
            this.m_txtMEDICINENAME_CHR.Multiline = false;
            this.m_txtMEDICINENAME_CHR.Name = "m_txtMEDICINENAME_CHR";
            this.m_txtMEDICINENAME_CHR.Size = new System.Drawing.Size(40, 22);
            this.m_txtMEDICINENAME_CHR.TabIndex = 70;
            this.m_txtMEDICINENAME_CHR.Text = "";
            this.m_txtMEDICINENAME_CHR.Visible = false;
            // 
            // txtSign
            // 
            this.txtSign.Location = new System.Drawing.Point(124, 230);
            this.txtSign.Name = "txtSign";
            this.txtSign.Size = new System.Drawing.Size(100, 23);
            this.txtSign.TabIndex = 10000048;
            // 
            // frmVeinSpecialUseDrugCon
            // 
            this.ClientSize = new System.Drawing.Size(488, 291);
            this.Controls.Add(this.m_dtmTime);
            this.Controls.Add(this.m_dtmDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.m_cmdOK);
            this.Controls.Add(this.m_cmdCancel);
            this.Controls.Add(this.m_cmdSign);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_txtREMARK_CHR);
            this.Controls.Add(this.m_txtMEDICINENAME_CHR);
            this.Controls.Add(this.m_txtSOLVE_CHR);
            this.Controls.Add(this.txtSign);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmVeinSpecialUseDrugCon";
            this.Text = "静脉特殊化疗用药观察";
            this.Load += new System.EventHandler(this.frmICUNurseRecord_GXCon_Load);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.txtSign, 0);
            this.Controls.SetChildIndex(this.m_txtSOLVE_CHR, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_txtMEDICINENAME_CHR, 0);
            this.Controls.SetChildIndex(this.m_txtREMARK_CHR, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.m_cmdSign, 0);
            this.Controls.SetChildIndex(this.m_cmdCancel, 0);
            this.Controls.SetChildIndex(this.m_cmdOK, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.m_dtmDate, 0);
            this.Controls.SetChildIndex(this.m_dtmTime, 0);
            this.Controls.SetChildIndex(this.m_lblGetDataTime, 0);
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
            this.Controls.SetChildIndex(this.m_dtpGetDataTime, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public override iCare.clsDiseaseTrackInfo m_objGetDiseaseTrackInfo()
		{
			clsIntensiveRecordInfo objTrackInfo = new clsIntensiveRecordInfo();

			objTrackInfo.m_ObjRecordContent = m_objCurrentRecordContent;
			objTrackInfo.m_DtmRecordTime = m_dtpCreateDate.Value;
			objTrackInfo.m_StrTitle =this.m_lblForTitle.Text;

			//设置m_dtmRecordTime
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
			//清空具体记录内容		
			m_cboMEDICINENAME_CHR.Text = "";
			this.m_txtMEDICINENAME_CHR.m_mthClearText();
			this.m_txtDROP_CHR.m_mthClearText();
			this.m_txtINGEAR_CHR.m_mthClearText();
			this.m_txtABNORMITY_CHR.m_mthClearText();
			m_cboSOLVE_CHR.Text = "";
			m_cboREMARK_CHR.Text = "";
			this.m_txtSOLVE_CHR.m_mthClearText();
			this.m_txtREMARK_CHR.m_mthClearText();
	

            //this.txtSign.m_mthClearText();

            //默认签名
            MDIParent.m_mthSetDefaulEmployee(txtSign);
        }

		/// <summary>
		/// 控制是否可以选择病人和记录时间列表。
		/// </summary>
		/// <param name="p_blnEnable"></param>
		protected override void m_mthEnablePatientSelectSub(bool p_blnEnable)
		{
			if(p_blnEnable==false)
			{
			
				m_cmdOK.Visible=true;
				
				this.CenterToParent();	
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
		/// 把特殊记录的值显示到界面上。
		/// </summary>
		/// <param name="p_objContent"></param>
		protected override void m_mthSetGUIFromContent(iCareData.clsTrackRecordContent p_objContent)
		{
			clsVeinSpecialUseDrugValue objContent=(clsVeinSpecialUseDrugValue)p_objContent;
			//把表单值赋值到界面，由子窗体重载实现			
			this.m_mthClearRecordInfo();

			this.m_txtMEDICINENAME_CHR.m_mthSetNewText(objContent.m_strMEDICINENAME_CHR,objContent.m_strMEDICINENAME_CHRXML);
			m_cboMEDICINENAME_CHR.Text =m_txtMEDICINENAME_CHR.Text;

			this.m_txtDROP_CHR.m_mthSetNewText(objContent.m_strDROP_CHR,objContent.m_strDROP_CHRXML);
			this.m_txtINGEAR_CHR.m_mthSetNewText(objContent.m_strINGEAR_CHR,objContent.m_strINGEAR_CHRXML);
			this.m_txtABNORMITY_CHR.m_mthSetNewText(objContent.m_strABNORMITY_CHR,objContent.m_strABNORMITY_CHRXML);
			
			this.m_txtSOLVE_CHR.m_mthSetNewText(objContent.m_strSOLVE_CHR,objContent.m_strSOLVE_CHRXML);
			m_cboSOLVE_CHR.Text = m_txtSOLVE_CHR.Text;

			this.m_txtREMARK_CHR.m_mthSetNewText(objContent.m_strREMARK_CHR,objContent.m_strREMARK_CHRXML);
			m_cboREMARK_CHR.Text = this.m_txtREMARK_CHR.Text;
            //this.txtSign.m_mthSetNewText(objContent.m_strUNDERWRITE_CHR,objContent.m_strUNDERWRITE_CHRXML);
            m_mthAddSignToTextBoxByEmpNo(new TextBoxBase[] { txtSign, }, new string[] { objContent.m_strCreateUserID }, new bool[] { false });
            //if(objContent.m_strUNDERWRITE_CHR !=null &&objContent.m_strUNDERWRITE_CHR != "")
            //    txtSign.Text=objContent.m_strUNDERWRITE_CHR;
            //this.txtSign.Enabled = false;
            //根据工号获取签名信息
            //出于兼容考虑，过渡使用 tfzhang 2006-03-12
            //com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
            //clsEmrEmployeeBase_VO objSign = new clsEmrEmployeeBase_VO();
            //objEmployeeSign.m_lngGetEmpByNO(objContent.m_strCreateUserID.Trim(), out objSign);
            //if (objSign != null)
            //{
            //    txtSign.Text = objSign.m_strLASTNAME_VCHR;
            //    txtSign.Tag = objSign;
            //}
            //this.txtSign.Enabled = false;
			this.m_dtpCreateDate.Enabled = false;

			if(objContent.m_strBEGINTIME_DATE !="")
			{
				m_dtmDate.Value = Convert.ToDateTime(objContent.m_strBEGINTIME_DATE) ;
				m_dtmTime.Value = Convert.ToDateTime(objContent.m_strBEGINTIME_DATE);			
			}
			else
			{
				m_dtmDate.Value = m_dtmBegin ;
				m_dtmTime.Value = m_dtmEnd;
			}
		}

		protected override void m_mthSetDeletedGUIFromContent(iCareData.clsTrackRecordContent p_objContent)
		{
			clsVeinSpecialUseDrugValue objContent=(clsVeinSpecialUseDrugValue )p_objContent;
			//把表单值赋值到界面，由子窗体重载实现			

			this.m_mthClearRecordInfo();
		
			this.m_cboMEDICINENAME_CHR.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strMEDICINENAME_CHR,objContent.m_strMEDICINENAME_CHRXML);
			
			this.m_txtDROP_CHR.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strDROP_CHR,objContent.m_strDROP_CHRXML);
			this.m_txtINGEAR_CHR.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strINGEAR_CHR,objContent.m_strINGEAR_CHRXML);
			this.m_txtABNORMITY_CHR.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strABNORMITY_CHR,objContent.m_strABNORMITY_CHRXML);
			
			this.m_cboSOLVE_CHR.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strSOLVE_CHR,objContent.m_strSOLVE_CHRXML);
			
			this.m_cboREMARK_CHR.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strREMARK_CHR,objContent.m_strREMARK_CHRXML);
            //this.txtSign.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strUNDERWRITE_CHR,objContent.m_strUNDERWRITE_CHRXML);
            m_mthAddSignToTextBoxByEmpNo(new TextBoxBase[] { txtSign, }, new string[] { objContent.m_strCreateUserID }, new bool[] { false });
            //if(objContent.m_strUNDERWRITE_CHR !=null &&objContent.m_strUNDERWRITE_CHR != "")
            //    txtSign.Text=objContent.m_strUNDERWRITE_CHR;
            //this.txtSign.Enabled = false;
            //根据工号获取签名信息
            //出于兼容考虑，过渡使用 tfzhang 2006-03-12
            //com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
            //clsEmrEmployeeBase_VO objSign = new clsEmrEmployeeBase_VO();
            //objEmployeeSign.m_lngGetEmpByNO(objContent.m_strCreateUserID.Trim(), out objSign);
            //if (objSign != null)
            //{
            //    txtSign.Text = objSign.m_strLASTNAME_VCHR;
            //    txtSign.Tag = objSign;
            //}
            //this.txtSign.Enabled = false;
			this.m_dtpCreateDate.Enabled = false;
		
			m_dtmDate.Value = m_dtmBegin ;
			m_dtmTime.Value = m_dtmEnd;
		}

		protected override iCareData.clsTrackRecordContent m_objGetContentFromGUI()
		{
			
			//界面参数校验
			if(m_objCurrentPatient==null || m_ObjCurrentEmrPatientSession == null)				
				return null;

			//从界面获取表单值		
			clsVeinSpecialUseDrugValue objContent=new clsVeinSpecialUseDrugValue ();
			try
			{
				objContent.m_strID_CHR = this.m_ID_CHR;
				objContent.m_dtmFluidBEGINTIME_DATE = this.m_dtmBegin;
				objContent.m_dtmfluidEndTIME_DATE = this.m_dtmEnd;
				
				objContent.m_dtmCreateDate =DateTime.Now ;

				this.m_txtMEDICINENAME_CHR.Text = this.m_cboMEDICINENAME_CHR.Text;
				objContent.m_strMEDICINENAME_CHR=this.m_txtMEDICINENAME_CHR.Text;
				objContent.m_strMEDICINENAME_CHR_RIGHT=this.m_txtMEDICINENAME_CHR.m_strGetRightText();
				objContent.m_strMEDICINENAME_CHRXML=this.m_txtMEDICINENAME_CHR.m_strGetXmlText();

				objContent.m_strDROP_CHR=this.m_txtDROP_CHR.Text;
				objContent.m_strDROP_CHR_RIGHT=this.m_txtDROP_CHR.m_strGetRightText();
				objContent.m_strDROP_CHRXML=this.m_txtDROP_CHR.m_strGetXmlText();

				objContent.m_strINGEAR_CHR=this.m_txtINGEAR_CHR.Text;
				objContent.m_strINGEAR_CHR_RIGHT=this.m_txtINGEAR_CHR.m_strGetRightText();
				objContent.m_strINGEAR_CHRXML=this.m_txtINGEAR_CHR.m_strGetXmlText();

				objContent.m_strABNORMITY_CHR=this.m_txtABNORMITY_CHR.Text;
				objContent.m_strABNORMITY_CHR_RIGHT=this.m_txtABNORMITY_CHR.m_strGetRightText();
				objContent.m_strABNORMITY_CHRXML=this.m_txtABNORMITY_CHR.m_strGetXmlText();

				this.m_txtSOLVE_CHR.Text = m_cboSOLVE_CHR.Text;
				objContent.m_strSOLVE_CHR=this.m_txtSOLVE_CHR.Text;
				objContent.m_strSOLVE_CHR_RIGHT=this.m_txtSOLVE_CHR.m_strGetRightText();
				objContent.m_strSOLVE_CHRXML=this.m_txtSOLVE_CHR.m_strGetXmlText();

				this.m_txtREMARK_CHR.Text = m_cboREMARK_CHR.Text;
				objContent.m_strREMARK_CHR=this.m_txtREMARK_CHR.Text;
				objContent.m_strREMARK_CHR_RIGHT=this.m_txtREMARK_CHR.m_strGetRightText();
				objContent.m_strREMARK_CHRXML=this.m_txtREMARK_CHR.m_strGetXmlText();
				
				string strTime = m_dtmDate.Value.ToString("yyyy-MM-dd")+" "+m_dtmTime.Value.ToString("HH:mm:ss");//m_dtpCreateDate.Value;
				
				objContent.m_strCHECKDATE_DATE  = strTime;
				objContent.m_strUNDERWRITE_CHR  = txtSign.Text.Trim();

				com.digitalwave.controls.ctlRichTextBox objtxtTemp = new ctlRichTextBox();
				objtxtTemp.Text = strTime;
				objContent.m_strBEGINTIME_DATE  = strTime;
				objContent.m_strBEGINTIME_DATE_RIGHT  = objtxtTemp.m_strGetRightText();
				objContent.m_strBEGINTIME_DATEXML  = objtxtTemp.m_strGetXmlText();
                objContent.m_dtmModifyDate = objContent.m_dtmCreateDate;

                //objContent.m_strCreateUserID = ((clsEmployee)txtSign.Tag).m_StrEmployeeID;
                //objContent.m_strModifyUserID = MDIParent.OperatorID;
                //获取签名
                objContent.m_strModifyUserID = ((clsEmrEmployeeBase_VO)txtSign.Tag).m_strEMPNO_CHR;
                objContent.m_strCreateUserID = ((clsEmrEmployeeBase_VO)txtSign.Tag).m_strEMPNO_CHR;
                strUserIDList = "";
                strUserNameList = "";
                m_mthGetSignArr(new Control[] { txtSign }, ref objContent.objSignerArr, ref strUserIDList, ref strUserNameList);
                //objContent.objSignerArr = new clsEmrSigns_VO[1];
                //objContent.objSignerArr[0] = new clsEmrSigns_VO();
                //objContent.objSignerArr[0].objEmployee = new clsEmrEmployeeBase_VO();
                //objContent.objSignerArr[0].objEmployee = (clsEmrEmployeeBase_VO)(txtSign.Tag);
                //objContent.objSignerArr[0].controlName = "txtSign";
                //objContent.objSignerArr[0].m_strFORMID_VCHR = "frmVeinSpecialUseDrugCon";//注意大小写
                //objContent.objSignerArr[0].m_strREGISTERID_CHR = com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;

				if(m_strInpatientDate.Trim() != "入院时间")
				objContent.m_strTemp =m_strInpatientDate;

			}
		
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			return(objContent );		
		}

		protected override iCare.clsDiseaseTrackDomain m_objGetDiseaseTrackDomain()
		{
			//获取护理记录的领域层实例，由子窗体重载实现
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.VeinSpecialUseDrug);	
			//(需要改动)				
		}

		/// <summary>
		/// 把选择时间记录内容重新整理为完全正确的内容。
		/// </summary>
		/// <param name="p_objRecordContent"></param>
		protected override void m_mthReAddNewRecord(clsTrackRecordContent p_objRecordContent)
		{
			//把选择时间记录内容重新整理为完全正确的内容，由子窗体重载实现。
			clsVeinSpecialUseDrugValue objContent=(clsVeinSpecialUseDrugValue)p_objRecordContent; //(需要改动)
		}

		public override string m_strReloadFormTitle()
		{
			//由子窗体重载实现
			//(需要改动)	
			return	"静脉特殊化疗用药观察";
		}

		
		#region Jump Control
		protected override void m_mthInitJump(clsJumpControl p_objJump)
		{	//(需要改动)	

			p_objJump=new clsJumpControl(this,
				new Control[]{m_cboMEDICINENAME_CHR,m_txtDROP_CHR,this.m_rdbNormal,m_txtINGEAR_CHR,m_txtABNORMITY_CHR,
								 m_cboSOLVE_CHR,m_cboREMARK_CHR,txtSign,m_cmdOK},Keys.Enter);
		}
		#endregion

		private void frmICUNurseRecord_GXCon_Load(object sender, System.EventArgs e)
		{
			this.m_cboMEDICINENAME_CHR.Focus();
			if(m_txtINGEAR_CHR.Text == ""&&m_txtABNORMITY_CHR.Text ==""&&m_rdbNormal.Checked==true)
			{
				m_txtINGEAR_CHR.Text = "√";
			}
		}

		private void m_cmdOK_Click(object sender, System.EventArgs e)
		{
			if(m_lngSave() > 0)
			{
				this.DialogResult = DialogResult.Yes;
				this.Close();
			}
		}

		private void m_cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.None;
			this.Close();
		}

		private void m_lsvEmployee_DoubleClick(object sender, System.EventArgs e)
		{
            //if(m_lsvEmployee.Items.Count!=0)
            //    if(m_lsvEmployee.SelectedItems.Count>0)
            //        txtSign.Text = 	m_lsvEmployee.SelectedItems[0].Text;
			
		}

		private void m_rdbNormal_CheckedChanged(object sender, System.EventArgs e)
		{
			RadioButton rdb = (RadioButton)sender;
			if(rdb.Checked)
			{
											  
				m_txtINGEAR_CHR.Enabled = true;
				if(m_txtINGEAR_CHR.Text != "")
				{
					if(m_txtINGEAR_CHR.Text.Substring(0,1)!="√")
						m_txtINGEAR_CHR.Text = "√"+m_txtINGEAR_CHR.Text.Trim();
				}
				else
				{
					m_txtINGEAR_CHR.Text = "√";
				}
				m_txtABNORMITY_CHR.Enabled  = false;
				//m_txtABNORMITY_CHR.Text   = "";
			}
			else
			{
				m_txtINGEAR_CHR.Enabled = false;
				m_txtINGEAR_CHR.Text   = "";
				m_txtABNORMITY_CHR.Enabled  = true;
			}
		}

		private void m_rdbNotNorMal_CheckedChanged(object sender, System.EventArgs e)
		{
			RadioButton rdb = (RadioButton)sender;
			if(rdb.Checked)
			{
				m_txtABNORMITY_CHR.Enabled = true;
				if(m_txtABNORMITY_CHR.Text !="")
				{
					if(m_txtABNORMITY_CHR.Text.Substring(0,1)!="√")
						m_txtABNORMITY_CHR.Text = "√"+m_txtABNORMITY_CHR.Text.Trim();
				}
				else
				{
					m_txtABNORMITY_CHR.Text = "√";
				}
				m_txtINGEAR_CHR.Enabled  = false;
				//m_txtABNORMITY_CHR.Text   = "";
			}
			else
			{
				m_txtABNORMITY_CHR.Enabled = false;
				m_txtABNORMITY_CHR.Text   = "";
				m_txtINGEAR_CHR.Enabled  = true;
			}
		}
	}
}

