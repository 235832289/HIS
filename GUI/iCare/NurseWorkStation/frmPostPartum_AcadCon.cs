using com.digitalwave.Emr.StaticObject;
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
using System.Reflection;
using System.Xml;
using com.digitalwave.Emr.Signature_gui;

namespace iCare
{
	/// <summary>
	/// 产后记录(增加，修改窗体)
	/// </summary>
	public class frmPostPartum_AcadCon : frmDiseaseTrackBase
	{
		#region define

        private PinkieControls.ButtonXP m_cmdOK;
        private PinkieControls.ButtonXP m_cmdCancel;
        private PinkieControls.ButtonXP m_cmdSign;
        private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;


		public System.DateTime m_dtmBEFOREHAND_CHR = System.DateTime.Now;
        public string m_strLAYCOUNT_CHR = "";
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label33;
		private com.digitalwave.controls.ctlRichTextBox m_txtUTERUSPINCH_CHR;
        private com.digitalwave.controls.ctlRichTextBox m_txtUTERUSBOTTOM_CHR;
		private com.digitalwave.controls.ctlRichTextBox m_txtNIPPLE_CHR;
		private com.digitalwave.controls.ctlRichTextBox m_txtBREASTBULGE_CHR;
		private com.digitalwave.controls.ctlRichTextBox m_txtMILKNUM_CHR;
		private com.digitalwave.controls.ctlRichTextBox m_txtDEWFUCK_CHR;
		private com.digitalwave.controls.ctlRichTextBox m_txtDEWCOLOR_CHR;
		private com.digitalwave.controls.ctlRichTextBox m_txtDEWNUM_CHR;//产次
        protected ListView lsvSign;
        private ColumnHeader clmEmployeeName;
        private Label label15;
        private ctlRichTextBox m_txtANNOTATIONS_CHR;
        private Label label16;
        private Label label5;
        private ctlRichTextBox m_txtPERINEUM_CHR;
        private Label label6;
        private ctlRichTextBox m_txtBP_CHR;
        private ctlRichTextBox m_txtURINE_CHR;
        private Label label8;
        private com.digitalwave.Utility.Controls.ctlComboBox m_cboInSeeNum;
		public string m_strFlag = "0";//是否新增
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		#endregion

        private com.digitalwave.Utility.Controls.ctlComboBox m_cmbGongDiLongCs;
        private com.digitalwave.Utility.Controls.ctlComboBox m_cmbHuiYingCs;
        private com.digitalwave.Utility.Controls.ctlComboBox m_cmbRuLiangCs;
        private com.digitalwave.Utility.Controls.ctlComboBox m_cmbRuZhangCs;
        private com.digitalwave.Utility.Controls.ctlComboBox m_cmbRuHeadCs;
        private com.digitalwave.Utility.Controls.ctlComboBox m_cmbBPMmHgCs;
        private com.digitalwave.Utility.Controls.ctlComboBox m_cmbELuLiangCs;
        private com.digitalwave.Utility.Controls.ctlComboBox m_cmbELuColorCs;
        private com.digitalwave.Utility.Controls.ctlComboBox m_cmbChouWeiCs;
        private com.digitalwave.Utility.Controls.ctlComboBox m_cmbNiaoCs;

        clsEmrSignToolCollection m_objSign;

		public frmPostPartum_AcadCon()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			m_mthSetRichTextBoxAttribInControl(this);
			
            m_objSign = new clsEmrSignToolCollection();
            //m_mthBindEmployeeSign(按钮,签名框,医生1or护士2,身份验证trueorfalse);
            m_objSign.m_mthBindEmployeeSign(m_cmdSign, lsvSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
		}

		public void m_setLaycout()
		{
			if(m_strFlag == "0")
			{
//				dateTimePicker1.Value =  System.DateTime.Now;
//				dateTimePicker1.Value =  m_dtmBEFOREHAND_CHR;
//				this.m_txtLayCount_chr.Text =  m_strLAYCOUNT_CHR;
//				this.m_txtBeforehand_chr.Text = m_dtmBEFOREHAND_CHR.ToString();
			}
		}
		public override int m_IntFormID
		{
			get
			{
				return 91;
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.m_cmbChouWeiCs = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cmbELuColorCs = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cmbELuLiangCs = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.m_txtDEWFUCK_CHR = new com.digitalwave.controls.ctlRichTextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.m_txtDEWCOLOR_CHR = new com.digitalwave.controls.ctlRichTextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.m_txtDEWNUM_CHR = new com.digitalwave.controls.ctlRichTextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_cmbRuHeadCs = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cmbRuZhangCs = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cmbRuLiangCs = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtNIPPLE_CHR = new com.digitalwave.controls.ctlRichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.m_txtBREASTBULGE_CHR = new com.digitalwave.controls.ctlRichTextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.m_txtMILKNUM_CHR = new com.digitalwave.controls.ctlRichTextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_cmbGongDiLongCs = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.m_txtUTERUSPINCH_CHR = new com.digitalwave.controls.ctlRichTextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.m_txtUTERUSBOTTOM_CHR = new com.digitalwave.controls.ctlRichTextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_cmdOK = new PinkieControls.ButtonXP();
            this.m_cmdCancel = new PinkieControls.ButtonXP();
            this.m_cmdSign = new PinkieControls.ButtonXP();
            this.lsvSign = new System.Windows.Forms.ListView();
            this.clmEmployeeName = new System.Windows.Forms.ColumnHeader();
            this.label15 = new System.Windows.Forms.Label();
            this.m_txtANNOTATIONS_CHR = new com.digitalwave.controls.ctlRichTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_txtPERINEUM_CHR = new com.digitalwave.controls.ctlRichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_txtBP_CHR = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtURINE_CHR = new com.digitalwave.controls.ctlRichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.m_cboInSeeNum = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cmbHuiYingCs = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cmbBPMmHgCs = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cmbNiaoCs = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_pnlNewBase.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_trvCreateDate
            // 
            this.m_trvCreateDate.LineColor = System.Drawing.Color.Black;
            this.m_trvCreateDate.Location = new System.Drawing.Point(32, -96);
            this.m_trvCreateDate.Size = new System.Drawing.Size(212, 96);
            this.m_trvCreateDate.Visible = false;
            // 
            // lblCreateDateTitle
            // 
            this.lblCreateDateTitle.Location = new System.Drawing.Point(28, 10);
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.Location = new System.Drawing.Point(108, 6);
            // 
            // m_dtpGetDataTime
            // 
            this.m_dtpGetDataTime.Location = new System.Drawing.Point(352, -56);
            // 
            // m_lblGetDataTime
            // 
            this.m_lblGetDataTime.Location = new System.Drawing.Point(248, -56);
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(628, -120);
            this.lblSex.Size = new System.Drawing.Size(48, 31);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(400, -120);
            this.lblAge.Size = new System.Drawing.Size(52, 31);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(236, -112);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(224, -80);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(408, -112);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(580, -120);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(688, -120);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(32, -48);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(280, -144);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(116, 116);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(280, -88);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(452, -120);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(280, -120);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(80, -56);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(452, -96);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(280, -96);
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
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(704, -80);
            this.m_cmdNewTemplate.Size = new System.Drawing.Size(84, 44);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.Location = new System.Drawing.Point(196, -120);
            this.m_cmdNext.Size = new System.Drawing.Size(24, 33);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(156, -120);
            this.m_cmdPre.Size = new System.Drawing.Size(24, 33);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(272, -112);
            this.m_lblForTitle.Size = new System.Drawing.Size(16, 35);
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(10, 234);
            this.chkModifyWithoutMatk.Size = new System.Drawing.Size(88, 29);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(611, -34);
            this.m_cmdModifyPatientInfo.Size = new System.Drawing.Size(72, 29);
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.m_cmbChouWeiCs);
            this.groupBox4.Controls.Add(this.m_cmbELuColorCs);
            this.groupBox4.Controls.Add(this.m_cmbELuLiangCs);
            this.groupBox4.Controls.Add(this.label28);
            this.groupBox4.Controls.Add(this.m_txtDEWFUCK_CHR);
            this.groupBox4.Controls.Add(this.label29);
            this.groupBox4.Controls.Add(this.label30);
            this.groupBox4.Controls.Add(this.m_txtDEWCOLOR_CHR);
            this.groupBox4.Controls.Add(this.label31);
            this.groupBox4.Controls.Add(this.label32);
            this.groupBox4.Controls.Add(this.m_txtDEWNUM_CHR);
            this.groupBox4.Controls.Add(this.label33);
            this.groupBox4.Location = new System.Drawing.Point(512, 38);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(228, 120);
            this.groupBox4.TabIndex = 130;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "恶露";
            // 
            // m_cmbChouWeiCs
            // 
            this.m_cmbChouWeiCs.AccessibleDescription = "恶露>>嗅味";
            this.m_cmbChouWeiCs.BackColor = System.Drawing.SystemColors.Window;
            this.m_cmbChouWeiCs.BorderColor = System.Drawing.Color.Black;
            this.m_cmbChouWeiCs.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cmbChouWeiCs.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cmbChouWeiCs.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cmbChouWeiCs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cmbChouWeiCs.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmbChouWeiCs.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmbChouWeiCs.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cmbChouWeiCs.ListBackColor = System.Drawing.Color.White;
            this.m_cmbChouWeiCs.ListForeColor = System.Drawing.Color.Black;
            this.m_cmbChouWeiCs.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cmbChouWeiCs.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cmbChouWeiCs.Location = new System.Drawing.Point(64, 84);
            this.m_cmbChouWeiCs.m_BlnEnableItemEventMenu = true;
            this.m_cmbChouWeiCs.Name = "m_cmbChouWeiCs";
            this.m_cmbChouWeiCs.SelectedIndex = -1;
            this.m_cmbChouWeiCs.SelectedItem = null;
            this.m_cmbChouWeiCs.SelectionStart = 0;
            this.m_cmbChouWeiCs.Size = new System.Drawing.Size(164, 23);
            this.m_cmbChouWeiCs.TabIndex = 10001402;
            this.m_cmbChouWeiCs.TextBackColor = System.Drawing.Color.White;
            this.m_cmbChouWeiCs.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cmbELuColorCs
            // 
            this.m_cmbELuColorCs.AccessibleDescription = "恶露>>色";
            this.m_cmbELuColorCs.BackColor = System.Drawing.SystemColors.Window;
            this.m_cmbELuColorCs.BorderColor = System.Drawing.Color.Black;
            this.m_cmbELuColorCs.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cmbELuColorCs.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cmbELuColorCs.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cmbELuColorCs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cmbELuColorCs.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmbELuColorCs.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmbELuColorCs.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cmbELuColorCs.ListBackColor = System.Drawing.Color.White;
            this.m_cmbELuColorCs.ListForeColor = System.Drawing.Color.Black;
            this.m_cmbELuColorCs.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cmbELuColorCs.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cmbELuColorCs.Location = new System.Drawing.Point(64, 55);
            this.m_cmbELuColorCs.m_BlnEnableItemEventMenu = true;
            this.m_cmbELuColorCs.Name = "m_cmbELuColorCs";
            this.m_cmbELuColorCs.SelectedIndex = -1;
            this.m_cmbELuColorCs.SelectedItem = null;
            this.m_cmbELuColorCs.SelectionStart = 0;
            this.m_cmbELuColorCs.Size = new System.Drawing.Size(164, 23);
            this.m_cmbELuColorCs.TabIndex = 10001402;
            this.m_cmbELuColorCs.TextBackColor = System.Drawing.Color.White;
            this.m_cmbELuColorCs.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cmbELuLiangCs
            // 
            this.m_cmbELuLiangCs.AccessibleDescription = "恶露>>量";
            this.m_cmbELuLiangCs.BackColor = System.Drawing.SystemColors.Window;
            this.m_cmbELuLiangCs.BorderColor = System.Drawing.Color.Black;
            this.m_cmbELuLiangCs.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cmbELuLiangCs.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cmbELuLiangCs.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cmbELuLiangCs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cmbELuLiangCs.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmbELuLiangCs.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmbELuLiangCs.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cmbELuLiangCs.ListBackColor = System.Drawing.Color.White;
            this.m_cmbELuLiangCs.ListForeColor = System.Drawing.Color.Black;
            this.m_cmbELuLiangCs.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cmbELuLiangCs.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cmbELuLiangCs.Location = new System.Drawing.Point(64, 24);
            this.m_cmbELuLiangCs.m_BlnEnableItemEventMenu = true;
            this.m_cmbELuLiangCs.Name = "m_cmbELuLiangCs";
            this.m_cmbELuLiangCs.SelectedIndex = -1;
            this.m_cmbELuLiangCs.SelectedItem = null;
            this.m_cmbELuLiangCs.SelectionStart = 0;
            this.m_cmbELuLiangCs.Size = new System.Drawing.Size(164, 23);
            this.m_cmbELuLiangCs.TabIndex = 10001402;
            this.m_cmbELuLiangCs.TextBackColor = System.Drawing.Color.White;
            this.m_cmbELuLiangCs.TextForeColor = System.Drawing.Color.Black;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(16, 88);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(42, 14);
            this.label28.TabIndex = 908;
            this.label28.Text = "嗅味:";
            // 
            // m_txtDEWFUCK_CHR
            // 
            this.m_txtDEWFUCK_CHR.AccessibleDescription = "";
            this.m_txtDEWFUCK_CHR.BackColor = System.Drawing.Color.White;
            this.m_txtDEWFUCK_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDEWFUCK_CHR.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtDEWFUCK_CHR.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDEWFUCK_CHR.Location = new System.Drawing.Point(64, 88);
            this.m_txtDEWFUCK_CHR.m_BlnIgnoreUserInfo = false;
            this.m_txtDEWFUCK_CHR.m_BlnPartControl = false;
            this.m_txtDEWFUCK_CHR.m_BlnReadOnly = false;
            this.m_txtDEWFUCK_CHR.m_BlnUnderLineDST = false;
            this.m_txtDEWFUCK_CHR.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDEWFUCK_CHR.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDEWFUCK_CHR.m_IntCanModifyTime = 6;
            this.m_txtDEWFUCK_CHR.m_IntPartControlLength = 0;
            this.m_txtDEWFUCK_CHR.m_IntPartControlStartIndex = 0;
            this.m_txtDEWFUCK_CHR.m_StrUserID = "";
            this.m_txtDEWFUCK_CHR.m_StrUserName = "";
            this.m_txtDEWFUCK_CHR.MaxLength = 1000;
            this.m_txtDEWFUCK_CHR.Multiline = false;
            this.m_txtDEWFUCK_CHR.Name = "m_txtDEWFUCK_CHR";
            this.m_txtDEWFUCK_CHR.Size = new System.Drawing.Size(148, 22);
            this.m_txtDEWFUCK_CHR.TabIndex = 160;
            this.m_txtDEWFUCK_CHR.Text = "";
            this.m_txtDEWFUCK_CHR.Visible = false;
            // 
            // label29
            // 
            this.label29.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(16, 80);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(24, 19);
            this.label29.TabIndex = 907;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(16, 56);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(42, 14);
            this.label30.TabIndex = 905;
            this.label30.Text = "色  :";
            // 
            // m_txtDEWCOLOR_CHR
            // 
            this.m_txtDEWCOLOR_CHR.AccessibleDescription = "";
            this.m_txtDEWCOLOR_CHR.BackColor = System.Drawing.Color.White;
            this.m_txtDEWCOLOR_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDEWCOLOR_CHR.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtDEWCOLOR_CHR.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDEWCOLOR_CHR.Location = new System.Drawing.Point(64, 56);
            this.m_txtDEWCOLOR_CHR.m_BlnIgnoreUserInfo = false;
            this.m_txtDEWCOLOR_CHR.m_BlnPartControl = false;
            this.m_txtDEWCOLOR_CHR.m_BlnReadOnly = false;
            this.m_txtDEWCOLOR_CHR.m_BlnUnderLineDST = false;
            this.m_txtDEWCOLOR_CHR.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDEWCOLOR_CHR.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDEWCOLOR_CHR.m_IntCanModifyTime = 6;
            this.m_txtDEWCOLOR_CHR.m_IntPartControlLength = 0;
            this.m_txtDEWCOLOR_CHR.m_IntPartControlStartIndex = 0;
            this.m_txtDEWCOLOR_CHR.m_StrUserID = "";
            this.m_txtDEWCOLOR_CHR.m_StrUserName = "";
            this.m_txtDEWCOLOR_CHR.MaxLength = 1000;
            this.m_txtDEWCOLOR_CHR.Multiline = false;
            this.m_txtDEWCOLOR_CHR.Name = "m_txtDEWCOLOR_CHR";
            this.m_txtDEWCOLOR_CHR.Size = new System.Drawing.Size(148, 22);
            this.m_txtDEWCOLOR_CHR.TabIndex = 150;
            this.m_txtDEWCOLOR_CHR.Text = "";
            this.m_txtDEWCOLOR_CHR.Visible = false;
            // 
            // label31
            // 
            this.label31.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(16, 48);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(24, 19);
            this.label31.TabIndex = 904;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(16, 24);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(42, 14);
            this.label32.TabIndex = 902;
            this.label32.Text = "量  :";
            // 
            // m_txtDEWNUM_CHR
            // 
            this.m_txtDEWNUM_CHR.AccessibleDescription = "";
            this.m_txtDEWNUM_CHR.BackColor = System.Drawing.Color.White;
            this.m_txtDEWNUM_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDEWNUM_CHR.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtDEWNUM_CHR.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDEWNUM_CHR.Location = new System.Drawing.Point(64, 24);
            this.m_txtDEWNUM_CHR.m_BlnIgnoreUserInfo = false;
            this.m_txtDEWNUM_CHR.m_BlnPartControl = false;
            this.m_txtDEWNUM_CHR.m_BlnReadOnly = false;
            this.m_txtDEWNUM_CHR.m_BlnUnderLineDST = false;
            this.m_txtDEWNUM_CHR.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDEWNUM_CHR.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDEWNUM_CHR.m_IntCanModifyTime = 6;
            this.m_txtDEWNUM_CHR.m_IntPartControlLength = 0;
            this.m_txtDEWNUM_CHR.m_IntPartControlStartIndex = 0;
            this.m_txtDEWNUM_CHR.m_StrUserID = "";
            this.m_txtDEWNUM_CHR.m_StrUserName = "";
            this.m_txtDEWNUM_CHR.MaxLength = 1000;
            this.m_txtDEWNUM_CHR.Multiline = false;
            this.m_txtDEWNUM_CHR.Name = "m_txtDEWNUM_CHR";
            this.m_txtDEWNUM_CHR.Size = new System.Drawing.Size(148, 22);
            this.m_txtDEWNUM_CHR.TabIndex = 140;
            this.m_txtDEWNUM_CHR.Text = "";
            this.m_txtDEWNUM_CHR.Visible = false;
            // 
            // label33
            // 
            this.label33.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(16, 16);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(24, 19);
            this.label33.TabIndex = 901;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_cmbRuHeadCs);
            this.groupBox2.Controls.Add(this.m_cmbRuZhangCs);
            this.groupBox2.Controls.Add(this.m_cmbRuLiangCs);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.m_txtNIPPLE_CHR);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.m_txtBREASTBULGE_CHR);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.m_txtMILKNUM_CHR);
            this.groupBox2.Controls.Add(this.label27);
            this.groupBox2.Location = new System.Drawing.Point(257, 38);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(238, 120);
            this.groupBox2.TabIndex = 90;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "乳腺";
            // 
            // m_cmbRuHeadCs
            // 
            this.m_cmbRuHeadCs.AccessibleDescription = "乳腺>>乳头";
            this.m_cmbRuHeadCs.BackColor = System.Drawing.SystemColors.Window;
            this.m_cmbRuHeadCs.BorderColor = System.Drawing.Color.Black;
            this.m_cmbRuHeadCs.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cmbRuHeadCs.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cmbRuHeadCs.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cmbRuHeadCs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cmbRuHeadCs.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmbRuHeadCs.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmbRuHeadCs.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cmbRuHeadCs.ListBackColor = System.Drawing.Color.White;
            this.m_cmbRuHeadCs.ListForeColor = System.Drawing.Color.Black;
            this.m_cmbRuHeadCs.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cmbRuHeadCs.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cmbRuHeadCs.Location = new System.Drawing.Point(64, 88);
            this.m_cmbRuHeadCs.m_BlnEnableItemEventMenu = true;
            this.m_cmbRuHeadCs.Name = "m_cmbRuHeadCs";
            this.m_cmbRuHeadCs.SelectedIndex = -1;
            this.m_cmbRuHeadCs.SelectedItem = null;
            this.m_cmbRuHeadCs.SelectionStart = 0;
            this.m_cmbRuHeadCs.Size = new System.Drawing.Size(174, 23);
            this.m_cmbRuHeadCs.TabIndex = 10001402;
            this.m_cmbRuHeadCs.TextBackColor = System.Drawing.Color.White;
            this.m_cmbRuHeadCs.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cmbRuZhangCs
            // 
            this.m_cmbRuZhangCs.AccessibleDescription = "乳腺>>乳胀";
            this.m_cmbRuZhangCs.BackColor = System.Drawing.SystemColors.Window;
            this.m_cmbRuZhangCs.BorderColor = System.Drawing.Color.Black;
            this.m_cmbRuZhangCs.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cmbRuZhangCs.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cmbRuZhangCs.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cmbRuZhangCs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cmbRuZhangCs.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmbRuZhangCs.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmbRuZhangCs.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cmbRuZhangCs.ListBackColor = System.Drawing.Color.White;
            this.m_cmbRuZhangCs.ListForeColor = System.Drawing.Color.Black;
            this.m_cmbRuZhangCs.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cmbRuZhangCs.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cmbRuZhangCs.Location = new System.Drawing.Point(64, 55);
            this.m_cmbRuZhangCs.m_BlnEnableItemEventMenu = true;
            this.m_cmbRuZhangCs.Name = "m_cmbRuZhangCs";
            this.m_cmbRuZhangCs.SelectedIndex = -1;
            this.m_cmbRuZhangCs.SelectedItem = null;
            this.m_cmbRuZhangCs.SelectionStart = 0;
            this.m_cmbRuZhangCs.Size = new System.Drawing.Size(174, 23);
            this.m_cmbRuZhangCs.TabIndex = 10001402;
            this.m_cmbRuZhangCs.TextBackColor = System.Drawing.Color.White;
            this.m_cmbRuZhangCs.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cmbRuLiangCs
            // 
            this.m_cmbRuLiangCs.AccessibleDescription = "乳腺>>乳量";
            this.m_cmbRuLiangCs.BackColor = System.Drawing.SystemColors.Window;
            this.m_cmbRuLiangCs.BorderColor = System.Drawing.Color.Black;
            this.m_cmbRuLiangCs.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cmbRuLiangCs.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cmbRuLiangCs.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cmbRuLiangCs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cmbRuLiangCs.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmbRuLiangCs.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmbRuLiangCs.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cmbRuLiangCs.ListBackColor = System.Drawing.Color.White;
            this.m_cmbRuLiangCs.ListForeColor = System.Drawing.Color.Black;
            this.m_cmbRuLiangCs.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cmbRuLiangCs.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cmbRuLiangCs.Location = new System.Drawing.Point(64, 24);
            this.m_cmbRuLiangCs.m_BlnEnableItemEventMenu = true;
            this.m_cmbRuLiangCs.Name = "m_cmbRuLiangCs";
            this.m_cmbRuLiangCs.SelectedIndex = -1;
            this.m_cmbRuLiangCs.SelectedItem = null;
            this.m_cmbRuLiangCs.SelectionStart = 0;
            this.m_cmbRuLiangCs.Size = new System.Drawing.Size(174, 23);
            this.m_cmbRuLiangCs.TabIndex = 10001402;
            this.m_cmbRuLiangCs.TextBackColor = System.Drawing.Color.White;
            this.m_cmbRuLiangCs.TextForeColor = System.Drawing.Color.Black;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 908;
            this.label1.Text = "乳头:";
            // 
            // m_txtNIPPLE_CHR
            // 
            this.m_txtNIPPLE_CHR.AccessibleDescription = "";
            this.m_txtNIPPLE_CHR.BackColor = System.Drawing.Color.White;
            this.m_txtNIPPLE_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtNIPPLE_CHR.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtNIPPLE_CHR.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtNIPPLE_CHR.Location = new System.Drawing.Point(64, 88);
            this.m_txtNIPPLE_CHR.m_BlnIgnoreUserInfo = false;
            this.m_txtNIPPLE_CHR.m_BlnPartControl = false;
            this.m_txtNIPPLE_CHR.m_BlnReadOnly = false;
            this.m_txtNIPPLE_CHR.m_BlnUnderLineDST = false;
            this.m_txtNIPPLE_CHR.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtNIPPLE_CHR.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtNIPPLE_CHR.m_IntCanModifyTime = 6;
            this.m_txtNIPPLE_CHR.m_IntPartControlLength = 0;
            this.m_txtNIPPLE_CHR.m_IntPartControlStartIndex = 0;
            this.m_txtNIPPLE_CHR.m_StrUserID = "";
            this.m_txtNIPPLE_CHR.m_StrUserName = "";
            this.m_txtNIPPLE_CHR.MaxLength = 3000;
            this.m_txtNIPPLE_CHR.Multiline = false;
            this.m_txtNIPPLE_CHR.Name = "m_txtNIPPLE_CHR";
            this.m_txtNIPPLE_CHR.Size = new System.Drawing.Size(160, 22);
            this.m_txtNIPPLE_CHR.TabIndex = 120;
            this.m_txtNIPPLE_CHR.Text = "";
            this.m_txtNIPPLE_CHR.Visible = false;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 19);
            this.label7.TabIndex = 907;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 14);
            this.label9.TabIndex = 905;
            this.label9.Text = "乳胀:";
            // 
            // m_txtBREASTBULGE_CHR
            // 
            this.m_txtBREASTBULGE_CHR.AccessibleDescription = "";
            this.m_txtBREASTBULGE_CHR.BackColor = System.Drawing.Color.White;
            this.m_txtBREASTBULGE_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBREASTBULGE_CHR.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBREASTBULGE_CHR.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBREASTBULGE_CHR.Location = new System.Drawing.Point(64, 56);
            this.m_txtBREASTBULGE_CHR.m_BlnIgnoreUserInfo = false;
            this.m_txtBREASTBULGE_CHR.m_BlnPartControl = false;
            this.m_txtBREASTBULGE_CHR.m_BlnReadOnly = false;
            this.m_txtBREASTBULGE_CHR.m_BlnUnderLineDST = false;
            this.m_txtBREASTBULGE_CHR.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBREASTBULGE_CHR.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBREASTBULGE_CHR.m_IntCanModifyTime = 6;
            this.m_txtBREASTBULGE_CHR.m_IntPartControlLength = 0;
            this.m_txtBREASTBULGE_CHR.m_IntPartControlStartIndex = 0;
            this.m_txtBREASTBULGE_CHR.m_StrUserID = "";
            this.m_txtBREASTBULGE_CHR.m_StrUserName = "";
            this.m_txtBREASTBULGE_CHR.MaxLength = 3000;
            this.m_txtBREASTBULGE_CHR.Multiline = false;
            this.m_txtBREASTBULGE_CHR.Name = "m_txtBREASTBULGE_CHR";
            this.m_txtBREASTBULGE_CHR.Size = new System.Drawing.Size(160, 22);
            this.m_txtBREASTBULGE_CHR.TabIndex = 110;
            this.m_txtBREASTBULGE_CHR.Text = "";
            this.m_txtBREASTBULGE_CHR.Visible = false;
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(16, 48);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(24, 19);
            this.label25.TabIndex = 904;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(16, 24);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(42, 14);
            this.label26.TabIndex = 902;
            this.label26.Text = "乳量:";
            // 
            // m_txtMILKNUM_CHR
            // 
            this.m_txtMILKNUM_CHR.AccessibleDescription = "";
            this.m_txtMILKNUM_CHR.BackColor = System.Drawing.Color.White;
            this.m_txtMILKNUM_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtMILKNUM_CHR.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtMILKNUM_CHR.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtMILKNUM_CHR.Location = new System.Drawing.Point(64, 24);
            this.m_txtMILKNUM_CHR.m_BlnIgnoreUserInfo = false;
            this.m_txtMILKNUM_CHR.m_BlnPartControl = false;
            this.m_txtMILKNUM_CHR.m_BlnReadOnly = false;
            this.m_txtMILKNUM_CHR.m_BlnUnderLineDST = false;
            this.m_txtMILKNUM_CHR.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtMILKNUM_CHR.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtMILKNUM_CHR.m_IntCanModifyTime = 6;
            this.m_txtMILKNUM_CHR.m_IntPartControlLength = 0;
            this.m_txtMILKNUM_CHR.m_IntPartControlStartIndex = 0;
            this.m_txtMILKNUM_CHR.m_StrUserID = "";
            this.m_txtMILKNUM_CHR.m_StrUserName = "";
            this.m_txtMILKNUM_CHR.MaxLength = 10;
            this.m_txtMILKNUM_CHR.Multiline = false;
            this.m_txtMILKNUM_CHR.Name = "m_txtMILKNUM_CHR";
            this.m_txtMILKNUM_CHR.Size = new System.Drawing.Size(160, 22);
            this.m_txtMILKNUM_CHR.TabIndex = 100;
            this.m_txtMILKNUM_CHR.Text = "";
            this.m_txtMILKNUM_CHR.Visible = false;
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(16, 16);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(24, 19);
            this.label27.TabIndex = 901;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_cmbGongDiLongCs);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.m_txtUTERUSPINCH_CHR);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.m_txtUTERUSBOTTOM_CHR);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Location = new System.Drawing.Point(12, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 120);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "子宫";
            // 
            // m_cmbGongDiLongCs
            // 
            this.m_cmbGongDiLongCs.AccessibleDescription = "子宫>>宫底";
            this.m_cmbGongDiLongCs.BackColor = System.Drawing.SystemColors.Window;
            this.m_cmbGongDiLongCs.BorderColor = System.Drawing.Color.Black;
            this.m_cmbGongDiLongCs.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cmbGongDiLongCs.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cmbGongDiLongCs.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cmbGongDiLongCs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cmbGongDiLongCs.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmbGongDiLongCs.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmbGongDiLongCs.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cmbGongDiLongCs.ListBackColor = System.Drawing.Color.White;
            this.m_cmbGongDiLongCs.ListForeColor = System.Drawing.Color.Black;
            this.m_cmbGongDiLongCs.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cmbGongDiLongCs.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cmbGongDiLongCs.Location = new System.Drawing.Point(87, 23);
            this.m_cmbGongDiLongCs.m_BlnEnableItemEventMenu = true;
            this.m_cmbGongDiLongCs.Name = "m_cmbGongDiLongCs";
            this.m_cmbGongDiLongCs.SelectedIndex = -1;
            this.m_cmbGongDiLongCs.SelectedItem = null;
            this.m_cmbGongDiLongCs.SelectionStart = 0;
            this.m_cmbGongDiLongCs.Size = new System.Drawing.Size(139, 23);
            this.m_cmbGongDiLongCs.TabIndex = 10001402;
            this.m_cmbGongDiLongCs.TextBackColor = System.Drawing.Color.White;
            this.m_cmbGongDiLongCs.TextForeColor = System.Drawing.Color.Black;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(16, 55);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(70, 14);
            this.label21.TabIndex = 905;
            this.label21.Text = "收缩情况:";
            // 
            // m_txtUTERUSPINCH_CHR
            // 
            this.m_txtUTERUSPINCH_CHR.AccessibleDescription = "子宫>>收缩情况";
            this.m_txtUTERUSPINCH_CHR.BackColor = System.Drawing.Color.White;
            this.m_txtUTERUSPINCH_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtUTERUSPINCH_CHR.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtUTERUSPINCH_CHR.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtUTERUSPINCH_CHR.Location = new System.Drawing.Point(88, 56);
            this.m_txtUTERUSPINCH_CHR.m_BlnIgnoreUserInfo = false;
            this.m_txtUTERUSPINCH_CHR.m_BlnPartControl = false;
            this.m_txtUTERUSPINCH_CHR.m_BlnReadOnly = false;
            this.m_txtUTERUSPINCH_CHR.m_BlnUnderLineDST = false;
            this.m_txtUTERUSPINCH_CHR.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtUTERUSPINCH_CHR.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtUTERUSPINCH_CHR.m_IntCanModifyTime = 6;
            this.m_txtUTERUSPINCH_CHR.m_IntPartControlLength = 0;
            this.m_txtUTERUSPINCH_CHR.m_IntPartControlStartIndex = 0;
            this.m_txtUTERUSPINCH_CHR.m_StrUserID = "";
            this.m_txtUTERUSPINCH_CHR.m_StrUserName = "";
            this.m_txtUTERUSPINCH_CHR.MaxLength = 1000;
            this.m_txtUTERUSPINCH_CHR.Name = "m_txtUTERUSPINCH_CHR";
            this.m_txtUTERUSPINCH_CHR.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtUTERUSPINCH_CHR.Size = new System.Drawing.Size(136, 53);
            this.m_txtUTERUSPINCH_CHR.TabIndex = 80;
            this.m_txtUTERUSPINCH_CHR.Text = "";
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(16, 48);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(24, 19);
            this.label22.TabIndex = 904;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(16, 24);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(70, 14);
            this.label19.TabIndex = 902;
            this.label19.Text = "宫底(cm):";
            // 
            // m_txtUTERUSBOTTOM_CHR
            // 
            this.m_txtUTERUSBOTTOM_CHR.AccessibleDescription = "";
            this.m_txtUTERUSBOTTOM_CHR.BackColor = System.Drawing.Color.White;
            this.m_txtUTERUSBOTTOM_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtUTERUSBOTTOM_CHR.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtUTERUSBOTTOM_CHR.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtUTERUSBOTTOM_CHR.Location = new System.Drawing.Point(88, 24);
            this.m_txtUTERUSBOTTOM_CHR.m_BlnIgnoreUserInfo = false;
            this.m_txtUTERUSBOTTOM_CHR.m_BlnPartControl = false;
            this.m_txtUTERUSBOTTOM_CHR.m_BlnReadOnly = false;
            this.m_txtUTERUSBOTTOM_CHR.m_BlnUnderLineDST = false;
            this.m_txtUTERUSBOTTOM_CHR.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtUTERUSBOTTOM_CHR.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtUTERUSBOTTOM_CHR.m_IntCanModifyTime = 6;
            this.m_txtUTERUSBOTTOM_CHR.m_IntPartControlLength = 0;
            this.m_txtUTERUSBOTTOM_CHR.m_IntPartControlStartIndex = 0;
            this.m_txtUTERUSBOTTOM_CHR.m_StrUserID = "";
            this.m_txtUTERUSBOTTOM_CHR.m_StrUserName = "";
            this.m_txtUTERUSBOTTOM_CHR.MaxLength = 3;
            this.m_txtUTERUSBOTTOM_CHR.Multiline = false;
            this.m_txtUTERUSBOTTOM_CHR.Name = "m_txtUTERUSBOTTOM_CHR";
            this.m_txtUTERUSBOTTOM_CHR.Size = new System.Drawing.Size(136, 22);
            this.m_txtUTERUSBOTTOM_CHR.TabIndex = 70;
            this.m_txtUTERUSBOTTOM_CHR.Text = "";
            this.m_txtUTERUSBOTTOM_CHR.Visible = false;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(16, 16);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(24, 19);
            this.label20.TabIndex = 901;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(364, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 14);
            this.label4.TabIndex = 1111;
            this.label4.Text = "产后日数:";
            // 
            // m_cmdOK
            // 
            this.m_cmdOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdOK.DefaultScheme = true;
            this.m_cmdOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdOK.Hint = "";
            this.m_cmdOK.Location = new System.Drawing.Point(596, 232);
            this.m_cmdOK.Name = "m_cmdOK";
            this.m_cmdOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdOK.Size = new System.Drawing.Size(64, 32);
            this.m_cmdOK.TabIndex = 10000022;
            this.m_cmdOK.Text = "确定";
            this.m_cmdOK.Click += new System.EventHandler(this.m_cmdOK_Click);
            // 
            // m_cmdCancel
            // 
            this.m_cmdCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdCancel.DefaultScheme = true;
            this.m_cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdCancel.Hint = "";
            this.m_cmdCancel.Location = new System.Drawing.Point(676, 232);
            this.m_cmdCancel.Name = "m_cmdCancel";
            this.m_cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCancel.Size = new System.Drawing.Size(64, 32);
            this.m_cmdCancel.TabIndex = 10000023;
            this.m_cmdCancel.Text = "取消";
            this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdCancel_Click);
            // 
            // m_cmdSign
            // 
            this.m_cmdSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdSign.DefaultScheme = true;
            this.m_cmdSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSign.Hint = "";
            this.m_cmdSign.Location = new System.Drawing.Point(104, 232);
            this.m_cmdSign.Name = "m_cmdSign";
            this.m_cmdSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSign.Size = new System.Drawing.Size(64, 32);
            this.m_cmdSign.TabIndex = 10000022;
            this.m_cmdSign.Text = "检查者:";
            // 
            // lsvSign
            // 
            this.lsvSign.BackColor = System.Drawing.Color.White;
            this.lsvSign.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmEmployeeName});
            this.lsvSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvSign.ForeColor = System.Drawing.Color.Black;
            this.lsvSign.FullRowSelect = true;
            this.lsvSign.GridLines = true;
            this.lsvSign.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lsvSign.Location = new System.Drawing.Point(169, 234);
            this.lsvSign.Name = "lsvSign";
            this.lsvSign.Size = new System.Drawing.Size(421, 28);
            this.lsvSign.TabIndex = 10000044;
            this.lsvSign.UseCompatibleStateImageBehavior = false;
            this.lsvSign.View = System.Windows.Forms.View.SmallIcon;
            // 
            // clmEmployeeName
            // 
            this.clmEmployeeName.Width = 55;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 200);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 14);
            this.label15.TabIndex = 10000052;
            this.label15.Text = "附注:";
            // 
            // m_txtANNOTATIONS_CHR
            // 
            this.m_txtANNOTATIONS_CHR.AccessibleDescription = "附注";
            this.m_txtANNOTATIONS_CHR.BackColor = System.Drawing.Color.White;
            this.m_txtANNOTATIONS_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtANNOTATIONS_CHR.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtANNOTATIONS_CHR.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtANNOTATIONS_CHR.Location = new System.Drawing.Point(70, 200);
            this.m_txtANNOTATIONS_CHR.m_BlnIgnoreUserInfo = false;
            this.m_txtANNOTATIONS_CHR.m_BlnPartControl = false;
            this.m_txtANNOTATIONS_CHR.m_BlnReadOnly = false;
            this.m_txtANNOTATIONS_CHR.m_BlnUnderLineDST = false;
            this.m_txtANNOTATIONS_CHR.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtANNOTATIONS_CHR.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtANNOTATIONS_CHR.m_IntCanModifyTime = 6;
            this.m_txtANNOTATIONS_CHR.m_IntPartControlLength = 0;
            this.m_txtANNOTATIONS_CHR.m_IntPartControlStartIndex = 0;
            this.m_txtANNOTATIONS_CHR.m_StrUserID = "";
            this.m_txtANNOTATIONS_CHR.m_StrUserName = "";
            this.m_txtANNOTATIONS_CHR.MaxLength = 1000;
            this.m_txtANNOTATIONS_CHR.Multiline = false;
            this.m_txtANNOTATIONS_CHR.Name = "m_txtANNOTATIONS_CHR";
            this.m_txtANNOTATIONS_CHR.Size = new System.Drawing.Size(670, 22);
            this.m_txtANNOTATIONS_CHR.TabIndex = 10000051;
            this.m_txtANNOTATIONS_CHR.Text = "";
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(340, 214);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(24, 19);
            this.label16.TabIndex = 10000053;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 14);
            this.label5.TabIndex = 10000045;
            this.label5.Text = "会阴情形:";
            // 
            // m_txtPERINEUM_CHR
            // 
            this.m_txtPERINEUM_CHR.AccessibleDescription = "";
            this.m_txtPERINEUM_CHR.BackColor = System.Drawing.Color.White;
            this.m_txtPERINEUM_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPERINEUM_CHR.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtPERINEUM_CHR.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPERINEUM_CHR.Location = new System.Drawing.Point(82, 168);
            this.m_txtPERINEUM_CHR.m_BlnIgnoreUserInfo = false;
            this.m_txtPERINEUM_CHR.m_BlnPartControl = false;
            this.m_txtPERINEUM_CHR.m_BlnReadOnly = false;
            this.m_txtPERINEUM_CHR.m_BlnUnderLineDST = false;
            this.m_txtPERINEUM_CHR.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPERINEUM_CHR.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPERINEUM_CHR.m_IntCanModifyTime = 6;
            this.m_txtPERINEUM_CHR.m_IntPartControlLength = 0;
            this.m_txtPERINEUM_CHR.m_IntPartControlStartIndex = 0;
            this.m_txtPERINEUM_CHR.m_StrUserID = "";
            this.m_txtPERINEUM_CHR.m_StrUserName = "";
            this.m_txtPERINEUM_CHR.MaxLength = 8000;
            this.m_txtPERINEUM_CHR.Multiline = false;
            this.m_txtPERINEUM_CHR.Name = "m_txtPERINEUM_CHR";
            this.m_txtPERINEUM_CHR.Size = new System.Drawing.Size(156, 22);
            this.m_txtPERINEUM_CHR.TabIndex = 10000048;
            this.m_txtPERINEUM_CHR.Text = "";
            this.m_txtPERINEUM_CHR.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(254, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 14);
            this.label6.TabIndex = 10000046;
            this.label6.Text = "BP(mmHg):";
            // 
            // m_txtBP_CHR
            // 
            this.m_txtBP_CHR.AccessibleDescription = "";
            this.m_txtBP_CHR.BackColor = System.Drawing.Color.White;
            this.m_txtBP_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBP_CHR.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBP_CHR.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBP_CHR.Location = new System.Drawing.Point(330, 164);
            this.m_txtBP_CHR.m_BlnIgnoreUserInfo = false;
            this.m_txtBP_CHR.m_BlnPartControl = false;
            this.m_txtBP_CHR.m_BlnReadOnly = false;
            this.m_txtBP_CHR.m_BlnUnderLineDST = false;
            this.m_txtBP_CHR.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBP_CHR.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBP_CHR.m_IntCanModifyTime = 6;
            this.m_txtBP_CHR.m_IntPartControlLength = 0;
            this.m_txtBP_CHR.m_IntPartControlStartIndex = 0;
            this.m_txtBP_CHR.m_StrUserID = "";
            this.m_txtBP_CHR.m_StrUserName = "";
            this.m_txtBP_CHR.MaxLength = 50;
            this.m_txtBP_CHR.Multiline = false;
            this.m_txtBP_CHR.Name = "m_txtBP_CHR";
            this.m_txtBP_CHR.Size = new System.Drawing.Size(165, 22);
            this.m_txtBP_CHR.TabIndex = 10000049;
            this.m_txtBP_CHR.Text = "";
            this.m_txtBP_CHR.Visible = false;
            // 
            // m_txtURINE_CHR
            // 
            this.m_txtURINE_CHR.AccessibleDescription = "";
            this.m_txtURINE_CHR.BackColor = System.Drawing.Color.White;
            this.m_txtURINE_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtURINE_CHR.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtURINE_CHR.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtURINE_CHR.Location = new System.Drawing.Point(543, 164);
            this.m_txtURINE_CHR.m_BlnIgnoreUserInfo = false;
            this.m_txtURINE_CHR.m_BlnPartControl = false;
            this.m_txtURINE_CHR.m_BlnReadOnly = false;
            this.m_txtURINE_CHR.m_BlnUnderLineDST = false;
            this.m_txtURINE_CHR.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtURINE_CHR.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtURINE_CHR.m_IntCanModifyTime = 6;
            this.m_txtURINE_CHR.m_IntPartControlLength = 0;
            this.m_txtURINE_CHR.m_IntPartControlStartIndex = 0;
            this.m_txtURINE_CHR.m_StrUserID = "";
            this.m_txtURINE_CHR.m_StrUserName = "";
            this.m_txtURINE_CHR.MaxLength = 8000;
            this.m_txtURINE_CHR.Multiline = false;
            this.m_txtURINE_CHR.Name = "m_txtURINE_CHR";
            this.m_txtURINE_CHR.Size = new System.Drawing.Size(197, 22);
            this.m_txtURINE_CHR.TabIndex = 10000050;
            this.m_txtURINE_CHR.Text = "";
            this.m_txtURINE_CHR.Visible = false;
            // 
            // label8
            // 
            this.label8.AccessibleDescription = "尿";
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(509, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 14);
            this.label8.TabIndex = 10000047;
            this.label8.Text = "尿:";
            // 
            // m_cboInSeeNum
            // 
            this.m_cboInSeeNum.AccessibleDescription = "产后日数";
            this.m_cboInSeeNum.BorderColor = System.Drawing.Color.Black;
            this.m_cboInSeeNum.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboInSeeNum.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboInSeeNum.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboInSeeNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboInSeeNum.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboInSeeNum.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboInSeeNum.ListBackColor = System.Drawing.Color.White;
            this.m_cboInSeeNum.ListForeColor = System.Drawing.Color.Black;
            this.m_cboInSeeNum.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboInSeeNum.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboInSeeNum.Location = new System.Drawing.Point(440, 6);
            this.m_cboInSeeNum.m_BlnEnableItemEventMenu = true;
            this.m_cboInSeeNum.Name = "m_cboInSeeNum";
            this.m_cboInSeeNum.SelectedIndex = -1;
            this.m_cboInSeeNum.SelectedItem = null;
            this.m_cboInSeeNum.SelectionStart = 0;
            this.m_cboInSeeNum.Size = new System.Drawing.Size(136, 23);
            this.m_cboInSeeNum.TabIndex = 10000054;
            this.m_cboInSeeNum.TextBackColor = System.Drawing.Color.White;
            this.m_cboInSeeNum.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cmbHuiYingCs
            // 
            this.m_cmbHuiYingCs.AccessibleDescription = "会阴情形";
            this.m_cmbHuiYingCs.BackColor = System.Drawing.SystemColors.Window;
            this.m_cmbHuiYingCs.BorderColor = System.Drawing.Color.Black;
            this.m_cmbHuiYingCs.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cmbHuiYingCs.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cmbHuiYingCs.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cmbHuiYingCs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cmbHuiYingCs.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmbHuiYingCs.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmbHuiYingCs.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cmbHuiYingCs.ListBackColor = System.Drawing.Color.White;
            this.m_cmbHuiYingCs.ListForeColor = System.Drawing.Color.Black;
            this.m_cmbHuiYingCs.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cmbHuiYingCs.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cmbHuiYingCs.Location = new System.Drawing.Point(82, 168);
            this.m_cmbHuiYingCs.m_BlnEnableItemEventMenu = true;
            this.m_cmbHuiYingCs.Name = "m_cmbHuiYingCs";
            this.m_cmbHuiYingCs.SelectedIndex = -1;
            this.m_cmbHuiYingCs.SelectedItem = null;
            this.m_cmbHuiYingCs.SelectionStart = 0;
            this.m_cmbHuiYingCs.Size = new System.Drawing.Size(162, 23);
            this.m_cmbHuiYingCs.TabIndex = 10001402;
            this.m_cmbHuiYingCs.TextBackColor = System.Drawing.Color.White;
            this.m_cmbHuiYingCs.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cmbBPMmHgCs
            // 
            this.m_cmbBPMmHgCs.AccessibleDescription = "BP(mmHg)";
            this.m_cmbBPMmHgCs.BackColor = System.Drawing.SystemColors.Window;
            this.m_cmbBPMmHgCs.BorderColor = System.Drawing.Color.Black;
            this.m_cmbBPMmHgCs.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cmbBPMmHgCs.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cmbBPMmHgCs.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cmbBPMmHgCs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cmbBPMmHgCs.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmbBPMmHgCs.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmbBPMmHgCs.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cmbBPMmHgCs.ListBackColor = System.Drawing.Color.White;
            this.m_cmbBPMmHgCs.ListForeColor = System.Drawing.Color.Black;
            this.m_cmbBPMmHgCs.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cmbBPMmHgCs.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cmbBPMmHgCs.Location = new System.Drawing.Point(330, 163);
            this.m_cmbBPMmHgCs.m_BlnEnableItemEventMenu = true;
            this.m_cmbBPMmHgCs.Name = "m_cmbBPMmHgCs";
            this.m_cmbBPMmHgCs.SelectedIndex = -1;
            this.m_cmbBPMmHgCs.SelectedItem = null;
            this.m_cmbBPMmHgCs.SelectionStart = 0;
            this.m_cmbBPMmHgCs.Size = new System.Drawing.Size(165, 23);
            this.m_cmbBPMmHgCs.TabIndex = 10001402;
            this.m_cmbBPMmHgCs.TextBackColor = System.Drawing.Color.White;
            this.m_cmbBPMmHgCs.TextForeColor = System.Drawing.Color.Black;
            this.m_cmbBPMmHgCs.Load += new System.EventHandler(this.m_cmbBPMmHgCs_Load);
            // 
            // m_cmbNiaoCs
            // 
            this.m_cmbNiaoCs.AccessibleDescription = "血压";
            this.m_cmbNiaoCs.BackColor = System.Drawing.SystemColors.Window;
            this.m_cmbNiaoCs.BorderColor = System.Drawing.Color.Black;
            this.m_cmbNiaoCs.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cmbNiaoCs.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cmbNiaoCs.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cmbNiaoCs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cmbNiaoCs.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmbNiaoCs.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmbNiaoCs.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cmbNiaoCs.ListBackColor = System.Drawing.Color.White;
            this.m_cmbNiaoCs.ListForeColor = System.Drawing.Color.Black;
            this.m_cmbNiaoCs.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cmbNiaoCs.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cmbNiaoCs.Location = new System.Drawing.Point(543, 164);
            this.m_cmbNiaoCs.m_BlnEnableItemEventMenu = true;
            this.m_cmbNiaoCs.Name = "m_cmbNiaoCs";
            this.m_cmbNiaoCs.SelectedIndex = -1;
            this.m_cmbNiaoCs.SelectedItem = null;
            this.m_cmbNiaoCs.SelectionStart = 0;
            this.m_cmbNiaoCs.Size = new System.Drawing.Size(197, 23);
            this.m_cmbNiaoCs.TabIndex = 10001402;
            this.m_cmbNiaoCs.TextBackColor = System.Drawing.Color.White;
            this.m_cmbNiaoCs.TextForeColor = System.Drawing.Color.Black;
            // 
            // frmPostPartum_AcadCon
            // 
            this.AccessibleDescription = "产后记录";
            this.ClientSize = new System.Drawing.Size(767, 435);
            this.Controls.Add(this.m_cmbNiaoCs);
            this.Controls.Add(this.m_cmbBPMmHgCs);
            this.Controls.Add(this.m_cmbHuiYingCs);
            this.Controls.Add(this.m_cboInSeeNum);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.m_txtANNOTATIONS_CHR);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.m_txtPERINEUM_CHR);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.m_txtBP_CHR);
            this.Controls.Add(this.m_txtURINE_CHR);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.lsvSign);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.m_cmdOK);
            this.Controls.Add(this.m_cmdCancel);
            this.Controls.Add(this.m_cmdSign);
            this.MaximizeBox = false;
            this.Name = "frmPostPartum_AcadCon";
            this.Text = "产后记录";
            this.Load += new System.EventHandler(this.frmICUNurseRecord_GXCon_Load);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.m_cmdSign, 0);
            this.Controls.SetChildIndex(this.m_cmdCancel, 0);
            this.Controls.SetChildIndex(this.m_cmdOK, 0);
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
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.lsvSign, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.m_txtURINE_CHR, 0);
            this.Controls.SetChildIndex(this.m_txtBP_CHR, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.m_txtPERINEUM_CHR, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label16, 0);
            this.Controls.SetChildIndex(this.m_txtANNOTATIONS_CHR, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.m_cboInSeeNum, 0);
            this.Controls.SetChildIndex(this.m_cmbHuiYingCs, 0);
            this.Controls.SetChildIndex(this.m_cmbBPMmHgCs, 0);
            this.Controls.SetChildIndex(this.m_cmbNiaoCs, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
				m_dtpCreateDate.Value=objTrackInfo.m_ObjRecordContent.m_dtmRecordDate;
			}
			return objTrackInfo;	
		}

		/// <summary>
		/// 清空特殊记录信息，并重置记录控制状态为不控制。
		/// </summary>
		protected override void m_mthClearRecordInfo()
		{
			//清空具体记录内容				

            this.m_cmbHuiYingCs.Text = string.Empty;
            this.m_cmbBPMmHgCs.Text = string.Empty;
            this.m_cmbNiaoCs.Text = string.Empty;
			this.m_txtANNOTATIONS_CHR.m_mthClearText();
			this.m_txtUTERUSBOTTOM_CHR.m_mthClearText();
			this.m_txtUTERUSPINCH_CHR.m_mthClearText();
            this.m_cmbRuLiangCs.Text = string.Empty;
            this.m_cmbRuZhangCs.Text = string.Empty;
            this.m_cmbRuHeadCs.Text = string.Empty;
            this.m_cmbELuLiangCs.Text = string.Empty;
            this.m_cmbELuColorCs.Text = string.Empty;
            this.m_cmbChouWeiCs.Text = string.Empty;
            this.lsvSign.Items.Clear();
            m_cboInSeeNum.Text = string.Empty;

            MDIParent.m_mthSetDefaulEmployee(lsvSign);
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
            m_dtpCreateDate.Enabled = true;
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
			clsIcuAcad_PostPartumRecord_Value objContent=(clsIcuAcad_PostPartumRecord_Value)p_objContent;
			//把表单值赋值到界面，由子窗体重载实现			
			this.m_mthClearRecordInfo();


            this.m_cboInSeeNum.Text = objContent.m_strPOSTPORTUM_NUM_CHR_RIGHT;
			this.m_cmbHuiYingCs.Text=objContent.m_strPERINEUM_CHR_RIGHT;
			this.m_cmbBPMmHgCs.Text=objContent.m_strBP_CHR_RIGHT;
			this.m_cmbNiaoCs.Text=objContent.m_strURINE_CHR_RIGHT;
			this.m_txtANNOTATIONS_CHR.m_mthSetNewText(objContent.m_strANNOTATIONS_CHR,objContent.m_strANNOTATIONS_CHRXML);
			this.m_cmbGongDiLongCs.Text=objContent.m_strUTERUSBOTTOM_CHR_RIGHT;
			this.m_txtUTERUSPINCH_CHR.m_mthSetNewText(objContent.m_strUTERUSPINCH_CHR,objContent.m_strUTERUSPINCH_CHRXML);
			this.m_cmbRuLiangCs.Text=objContent.m_strMILKNUM_CHR_RIGHT;
			this.m_cmbRuZhangCs.Text=objContent.m_strBREASTBULGE_CHR_RIGHT;
			this.m_cmbRuHeadCs.Text=objContent.m_strNIPPLE_CHR_RIGHT;
			this.m_cmbELuLiangCs.Text=objContent.m_strDEWNUM_CHR_RIGHT;
			this.m_cmbELuColorCs.Text=objContent.m_strDEWCOLOR_CHR_RIGHT;
			this.m_cmbChouWeiCs.Text=objContent.m_strDEWFUCK_CHR_RIGHT;

            this.m_dtpCreateDate.Value = objContent.m_dtmRecordDate;
           
			
            #region 签名集合
            m_mthAddSignToListView(lsvSign, objContent.objSignerArr);
            #endregion 签名		
		}

		protected override void m_mthSetDeletedGUIFromContent(iCareData.clsTrackRecordContent p_objContent)
		{
			clsIcuAcad_PostPartumRecord_Value objContent=(clsIcuAcad_PostPartumRecord_Value )p_objContent;
			//把表单值赋值到界面，由子窗体重载实现			

			this.m_mthClearRecordInfo();
//
            this.m_cboInSeeNum.Text = objContent.m_strPOSTPORTUM_NUM_CHR_RIGHT;
			this.m_cmbHuiYingCs.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strPERINEUM_CHR,objContent.m_strPERINEUM_CHRXML);
			this.m_cmbBPMmHgCs.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strBP_CHR,objContent.m_strBP_CHRXML);
			this.m_cmbNiaoCs.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strURINE_CHR,objContent.m_strURINE_CHRXML);
			this.m_txtANNOTATIONS_CHR.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strANNOTATIONS_CHR,objContent.m_strANNOTATIONS_CHRXML);
			this.m_cmbGongDiLongCs.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strUTERUSBOTTOM_CHR,objContent.m_strUTERUSBOTTOM_CHRXML);
			this.m_txtUTERUSPINCH_CHR.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strUTERUSPINCH_CHR,objContent.m_strUTERUSPINCH_CHRXML);
			this.m_cmbRuLiangCs.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strMILKNUM_CHR,objContent.m_strMILKNUM_CHRXML);
			this.m_cmbRuZhangCs.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strBREASTBULGE_CHR,objContent.m_strBREASTBULGE_CHRXML);
			this.m_cmbRuHeadCs.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strNIPPLE_CHR,objContent.m_strNIPPLE_CHRXML);
			this.m_cmbELuLiangCs.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strDEWNUM_CHR,objContent.m_strDEWNUM_CHRXML);
			this.m_cmbELuColorCs.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strDEWCOLOR_CHR,objContent.m_strDEWCOLOR_CHRXML);
			this.m_cmbChouWeiCs.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strDEWFUCK_CHR,objContent.m_strDEWFUCK_CHRXML);
           
            #region 签名集合
            m_mthAddSignToListView(lsvSign, objContent.objSignerArr);
            #endregion 签名	
		
		}
        /// <summary>
        /// 设置子窗体的创建时间基类时间等，为了适合用RegisterId与新业务要求用
        /// </summary>
        /// <param name="p_objContent"></param>
        protected override void m_mthSetSubCreatedDateInfo(ref clsTrackRecordContent p_objContent, bool p_blnIsAddNew)
        {
            if (p_objContent != null)
            {
                p_objContent.m_strRegisterID = m_objCurrentPatient.m_StrRegisterId;
                p_objContent.m_bytIfConfirm = 0;
                p_objContent.m_bytStatus = 1;
                if (p_blnIsAddNew)
                {
                    p_objContent.m_dtmCreateDate = new clsPublicDomain().m_dtmGetServerTime();
                    p_objContent.m_strCreateUserID = clsEMRLogin.LoginInfo.m_strEmpID;
                }
                p_objContent.m_dtmModifyDate = p_objContent.m_dtmCreateDate;
                p_objContent.m_strConfirmReason = "";
                p_objContent.m_strConfirmReasonXML = "";
                p_objContent.m_strInPatientID = m_objCurrentPatient.m_StrInPatientID;
                p_objContent.m_strModifyUserID = clsEMRLogin.LoginInfo.m_strEmpID;
                p_objContent.m_dtmRecordDate = DateTime.Parse(m_dtpCreateDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            }
        }
		protected override iCareData.clsTrackRecordContent m_objGetContentFromGUI()
		{
			
			//界面参数校验
			if(m_objCurrentPatient==null)// || this.txtInPatientID.Text!=this.m_objCurrentPatient.m_StrHISInPatientID || txtInPatientID.Text=="")				
				return null;

			//从界面获取表单值		
			clsIcuAcad_PostPartumRecord_Value objContent=new clsIcuAcad_PostPartumRecord_Value ();
			try
			{
                objContent.m_dtmCreateDate = new clsPublicDomain().m_dtmGetServerTime() ;

                objContent.m_strPOSTPORTUM_NUM_CHR = this.m_cboInSeeNum.Text;
                objContent.m_strPOSTPORTUM_NUM_CHR_RIGHT = this.m_cboInSeeNum.Text;
                objContent.m_strPOSTPORTUM_NUM_CHRXML = "";

				objContent.m_strPERINEUM_CHR=this.m_cmbHuiYingCs.Text;
                objContent.m_strPERINEUM_CHR_RIGHT = this.m_cmbHuiYingCs.Text;
				objContent.m_strPERINEUM_CHRXML="";

				objContent.m_strBP_CHR=this.m_cmbBPMmHgCs.Text;
                objContent.m_strBP_CHR_RIGHT = this.m_cmbBPMmHgCs.Text;
                objContent.m_strBP_CHRXML = "";

				objContent.m_strURINE_CHR=this.m_cmbNiaoCs.Text;
                objContent.m_strURINE_CHR_RIGHT = this.m_cmbNiaoCs.Text;
                objContent.m_strURINE_CHRXML = "";

				objContent.m_strANNOTATIONS_CHR=this.m_txtANNOTATIONS_CHR.Text;
				objContent.m_strANNOTATIONS_CHR_RIGHT=this.m_txtANNOTATIONS_CHR.m_strGetRightText();
				objContent.m_strANNOTATIONS_CHRXML=this.m_txtANNOTATIONS_CHR.m_strGetXmlText();


				objContent.m_strUTERUSBOTTOM_CHR=this.m_cmbGongDiLongCs.Text;
                objContent.m_strUTERUSBOTTOM_CHR_RIGHT = this.m_cmbGongDiLongCs.Text;
                objContent.m_strUTERUSBOTTOM_CHRXML = "";

				objContent.m_strUTERUSPINCH_CHR=this.m_txtUTERUSPINCH_CHR.Text;
				objContent.m_strUTERUSPINCH_CHR_RIGHT=this.m_txtUTERUSPINCH_CHR.m_strGetRightText();
				objContent.m_strUTERUSPINCH_CHRXML=this.m_txtUTERUSPINCH_CHR.m_strGetXmlText();

				objContent.m_strMILKNUM_CHR=this.m_cmbRuLiangCs.Text;
                objContent.m_strMILKNUM_CHR_RIGHT = this.m_cmbRuLiangCs.Text;
                objContent.m_strMILKNUM_CHRXML = "";

				objContent.m_strBREASTBULGE_CHR=this.m_cmbRuZhangCs.Text;
                objContent.m_strBREASTBULGE_CHR_RIGHT = this.m_cmbRuZhangCs.Text;
                objContent.m_strBREASTBULGE_CHRXML = "";

				objContent.m_strNIPPLE_CHR = this.m_cmbRuHeadCs.Text;
                objContent.m_strNIPPLE_CHR_RIGHT = this.m_cmbRuHeadCs.Text;
                objContent.m_strNIPPLE_CHRXML = "";

				objContent.m_strDEWNUM_CHR_RIGHT=this.m_cmbELuLiangCs.Text;
                objContent.m_strDEWNUM_CHR = this.m_cmbELuLiangCs.Text;
                objContent.m_strDEWNUM_CHRXML = "";

				objContent.m_strDEWCOLOR_CHR=this.m_cmbELuColorCs.Text;
                objContent.m_strDEWCOLOR_CHR_RIGHT = this.m_cmbELuColorCs.Text;
                objContent.m_strDEWCOLOR_CHRXML = "";

				objContent.m_strDEWFUCK_CHR=this.m_cmbChouWeiCs.Text;
                objContent.m_strDEWFUCK_CHR_RIGHT = this.m_cmbChouWeiCs.Text;
                objContent.m_strDEWFUCK_CHRXML = "";

                string strRecordUserIdArr = string.Empty;
                string strRecordUserMame = string.Empty;
                m_mthGetSignArr(new Control[] { lsvSign }, ref objContent.objSignerArr, ref strRecordUserIdArr, ref strRecordUserMame);
                objContent.m_strRecordUserID = strRecordUserIdArr;

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
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.PostPartum_Acad);	
			//(需要改动)				
		}

		/// <summary>
		/// 把选择时间记录内容重新整理为完全正确的内容。
		/// </summary>
		/// <param name="p_objRecordContent"></param>
		protected override void m_mthReAddNewRecord(clsTrackRecordContent p_objRecordContent)
		{
			//把选择时间记录内容重新整理为完全正确的内容，由子窗体重载实现。
			clsIcuAcad_PostPartumRecord_Value objContent=(clsIcuAcad_PostPartumRecord_Value)p_objRecordContent; //(需要改动)
		}

		public override string m_strReloadFormTitle()
		{
			//由子窗体重载实现
			//(需要改动)	
			return	"产后记录";
		}

		
		#region Jump Control
		protected override void m_mthInitJump(clsJumpControl p_objJump)
		{
			p_objJump=new clsJumpControl(this,
                new Control[]{m_cboInSeeNum,this.m_cmbGongDiLongCs,m_txtUTERUSPINCH_CHR,this.m_cmbRuLiangCs,this.m_cmbRuZhangCs,this.m_cmbRuHeadCs,this.m_cmbELuLiangCs,
                this.m_cmbELuColorCs,this.m_cmbChouWeiCs,this.m_cmbHuiYingCs,this.m_cmbBPMmHgCs,this.m_cmbNiaoCs,m_txtANNOTATIONS_CHR,m_cmdSign,m_cmdOK}, Keys.Enter);
		}
		#endregion

		private void frmICUNurseRecord_GXCon_Load(object sender, System.EventArgs e)
		{
            this.m_cboInSeeNum.Focus();
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
        public override clsTrackRecordContent m_objGetRecordContent(clsPatient p_objSelectedPatient, string p_strOpenDate)
        {
            clsTrackRecordContent objContent;
            //获取记录
            m_objDiseaseTrackDomain.m_lngGetRecordContent(p_objSelectedPatient.m_StrRegisterId, p_strOpenDate, out objContent);
            return objContent;
        }

        private void m_cmbBPMmHgCs_Load(object sender, EventArgs e)
        {

        }
       
	}
}

