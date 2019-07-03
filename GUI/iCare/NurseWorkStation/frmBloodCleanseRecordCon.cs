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
	/// 血液净化记录表(增加，修改窗体)
	/// </summary>
	public class frmBloodCleanseRecordCon : frmDiseaseTrackBase
	{
		#region define

        private PinkieControls.ButtonXP m_cmdOK;
        private PinkieControls.ButtonXP m_cmdCancel;
        private PinkieControls.ButtonXP m_cmdSign;
        private System.Windows.Forms.Label label4;


		public System.DateTime m_dtmBEFOREHAND_CHR = System.DateTime.Now;
        public string m_strLAYCOUNT_CHR = "";//产次
        private Label label15;
        private ctlRichTextBox m_txtChuLi;
        private Label label16;
        private Label label5;
        private com.digitalwave.Utility.Controls.ctlComboBox m_cboTouXiYa;
		public string m_strFlag = "0";//是否新增
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		#endregion

        private com.digitalwave.Utility.Controls.ctlComboBox m_cboXueLiuLiang;
        private Label label1;
        private com.digitalwave.Utility.Controls.ctlComboBox m_cboJingMaiYa;
        private Label label2;
        private com.digitalwave.Utility.Controls.ctlComboBox m_cboGanSuLiang;
        private Label label3;
        private com.digitalwave.Utility.Controls.ctlComboBox m_cboTiWen;
        private Label label7;
        private com.digitalwave.Utility.Controls.ctlComboBox m_cboMaiBo;
        private Label label9;
        private Label label10;
        private Label label11;
        private com.digitalwave.Utility.Controls.ctlComboBox m_cboHuXi;
        private com.digitalwave.Utility.Controls.ctlComboBox m_cboFaLeng;
        private com.digitalwave.Utility.Controls.ctlComboBox m_cboXueYa;
        private Label label6;
        private com.digitalwave.Utility.Controls.ctlComboBox m_cboFaRe;
        private Label label8;
        private com.digitalwave.Utility.Controls.ctlComboBox m_cboTouTong;
        private Label label12;
        private com.digitalwave.Utility.Controls.ctlComboBox m_cboTuoShuiLiang;
        private Label label13;
        private com.digitalwave.Utility.Controls.ctlComboBox m_cboOuTu;
        private Label label14;
        private com.digitalwave.Utility.Controls.ctlComboBox m_cboChouChu;
        private Label label17;
        private com.digitalwave.Utility.Controls.ctlComboBox m_cboXinYi;
        private Label label18;
        private com.digitalwave.Utility.Controls.ctlComboBox m_cboNaNongDu;
        private TextBox txtSign;

        clsEmrSignToolCollection m_objSign;

		public frmBloodCleanseRecordCon()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			m_mthSetRichTextBoxAttribInControl(this);
			
            m_objSign = new clsEmrSignToolCollection();
            //m_mthBindEmployeeSign(按钮,签名框,医生1or护士2,身份验证trueorfalse);
            m_objSign.m_mthBindEmployeeSign(m_cmdSign, txtSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
            
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
            this.label4 = new System.Windows.Forms.Label();
            this.m_cmdOK = new PinkieControls.ButtonXP();
            this.m_cmdCancel = new PinkieControls.ButtonXP();
            this.m_cmdSign = new PinkieControls.ButtonXP();
            this.label15 = new System.Windows.Forms.Label();
            this.m_txtChuLi = new com.digitalwave.controls.ctlRichTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_cboTouXiYa = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboXueLiuLiang = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_cboJingMaiYa = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_cboGanSuLiang = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_cboTiWen = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.m_cboMaiBo = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.m_cboHuXi = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboFaLeng = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboXueYa = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_cboFaRe = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.m_cboTouTong = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.m_cboTuoShuiLiang = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.m_cboOuTu = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.m_cboChouChu = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.m_cboXinYi = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.m_cboNaNongDu = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.txtSign = new System.Windows.Forms.TextBox();
            this.m_pnlNewBase.SuspendLayout();
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
            this.lblCreateDateTitle.Location = new System.Drawing.Point(28, 14);
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.Location = new System.Drawing.Point(108, 10);
            this.m_dtpCreateDate.TabIndex = 0;
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
            this.m_lsvPatientName.Location = new System.Drawing.Point(465, 2);
            this.m_lsvPatientName.Size = new System.Drawing.Size(71, 35);
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
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(465, -7);
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
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(351, 8);
            this.chkModifyWithoutMatk.Size = new System.Drawing.Size(88, 29);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(542, 3);
            this.m_cmdModifyPatientInfo.Size = new System.Drawing.Size(72, 29);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Size = new System.Drawing.Size(12, 17);
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(10, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 14);
            this.label4.TabIndex = 1111;
            this.label4.Text = "透析压(mmHg)：";
            // 
            // m_cmdOK
            // 
            this.m_cmdOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdOK.DefaultScheme = true;
            this.m_cmdOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdOK.Hint = "";
            this.m_cmdOK.Location = new System.Drawing.Point(491, 291);
            this.m_cmdOK.Name = "m_cmdOK";
            this.m_cmdOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdOK.Size = new System.Drawing.Size(64, 32);
            this.m_cmdOK.TabIndex = 20;
            this.m_cmdOK.Text = "保存";
            this.m_cmdOK.Click += new System.EventHandler(this.m_cmdOK_Click);
            // 
            // m_cmdCancel
            // 
            this.m_cmdCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdCancel.DefaultScheme = true;
            this.m_cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdCancel.Hint = "";
            this.m_cmdCancel.Location = new System.Drawing.Point(571, 291);
            this.m_cmdCancel.Name = "m_cmdCancel";
            this.m_cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCancel.Size = new System.Drawing.Size(64, 32);
            this.m_cmdCancel.TabIndex = 21;
            this.m_cmdCancel.Text = "关闭";
            this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdCancel_Click);
            // 
            // m_cmdSign
            // 
            this.m_cmdSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdSign.DefaultScheme = true;
            this.m_cmdSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSign.Hint = "";
            this.m_cmdSign.Location = new System.Drawing.Point(252, 291);
            this.m_cmdSign.Name = "m_cmdSign";
            this.m_cmdSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSign.Size = new System.Drawing.Size(64, 32);
            this.m_cmdSign.TabIndex = 18;
            this.m_cmdSign.Text = "签  名";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(276, 244);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 14);
            this.label15.TabIndex = 10000052;
            this.label15.Text = "处    理：";
            // 
            // m_txtChuLi
            // 
            this.m_txtChuLi.AccessibleDescription = "处理";
            this.m_txtChuLi.BackColor = System.Drawing.Color.White;
            this.m_txtChuLi.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtChuLi.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtChuLi.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtChuLi.Location = new System.Drawing.Point(359, 240);
            this.m_txtChuLi.m_BlnIgnoreUserInfo = false;
            this.m_txtChuLi.m_BlnPartControl = false;
            this.m_txtChuLi.m_BlnReadOnly = false;
            this.m_txtChuLi.m_BlnUnderLineDST = false;
            this.m_txtChuLi.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtChuLi.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtChuLi.m_IntCanModifyTime = 6;
            this.m_txtChuLi.m_IntPartControlLength = 0;
            this.m_txtChuLi.m_IntPartControlStartIndex = 0;
            this.m_txtChuLi.m_StrUserID = "";
            this.m_txtChuLi.m_StrUserName = "";
            this.m_txtChuLi.MaxLength = 1000;
            this.m_txtChuLi.Multiline = false;
            this.m_txtChuLi.Name = "m_txtChuLi";
            this.m_txtChuLi.Size = new System.Drawing.Size(313, 22);
            this.m_txtChuLi.TabIndex = 17;
            this.m_txtChuLi.Text = "";
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(327, 291);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(24, 19);
            this.label16.TabIndex = 10000053;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 14);
            this.label5.TabIndex = 10000045;
            this.label5.Text = "血流量(ml/min)：";
            // 
            // m_cboTouXiYa
            // 
            this.m_cboTouXiYa.AccessibleDescription = "透析压";
            this.m_cboTouXiYa.BorderColor = System.Drawing.Color.Black;
            this.m_cboTouXiYa.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboTouXiYa.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboTouXiYa.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboTouXiYa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboTouXiYa.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboTouXiYa.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboTouXiYa.ListBackColor = System.Drawing.Color.White;
            this.m_cboTouXiYa.ListForeColor = System.Drawing.Color.Black;
            this.m_cboTouXiYa.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboTouXiYa.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboTouXiYa.Location = new System.Drawing.Point(147, 54);
            this.m_cboTouXiYa.m_BlnEnableItemEventMenu = true;
            this.m_cboTouXiYa.MaxLength = 32767;
            this.m_cboTouXiYa.Name = "m_cboTouXiYa";
            this.m_cboTouXiYa.SelectedIndex = -1;
            this.m_cboTouXiYa.SelectedItem = null;
            this.m_cboTouXiYa.SelectionStart = 0;
            this.m_cboTouXiYa.Size = new System.Drawing.Size(102, 23);
            this.m_cboTouXiYa.TabIndex = 1;
            this.m_cboTouXiYa.TextBackColor = System.Drawing.Color.White;
            this.m_cboTouXiYa.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboXueLiuLiang
            // 
            this.m_cboXueLiuLiang.AccessibleDescription = "血流量";
            this.m_cboXueLiuLiang.BackColor = System.Drawing.SystemColors.Window;
            this.m_cboXueLiuLiang.BorderColor = System.Drawing.Color.Black;
            this.m_cboXueLiuLiang.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboXueLiuLiang.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboXueLiuLiang.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboXueLiuLiang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboXueLiuLiang.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboXueLiuLiang.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboXueLiuLiang.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cboXueLiuLiang.ListBackColor = System.Drawing.Color.White;
            this.m_cboXueLiuLiang.ListForeColor = System.Drawing.Color.Black;
            this.m_cboXueLiuLiang.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboXueLiuLiang.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboXueLiuLiang.Location = new System.Drawing.Point(147, 89);
            this.m_cboXueLiuLiang.m_BlnEnableItemEventMenu = true;
            this.m_cboXueLiuLiang.MaxLength = 32767;
            this.m_cboXueLiuLiang.Name = "m_cboXueLiuLiang";
            this.m_cboXueLiuLiang.SelectedIndex = -1;
            this.m_cboXueLiuLiang.SelectedItem = null;
            this.m_cboXueLiuLiang.SelectionStart = 0;
            this.m_cboXueLiuLiang.Size = new System.Drawing.Size(102, 23);
            this.m_cboXueLiuLiang.TabIndex = 4;
            this.m_cboXueLiuLiang.TextBackColor = System.Drawing.Color.White;
            this.m_cboXueLiuLiang.TextForeColor = System.Drawing.Color.Black;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(265, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 14);
            this.label1.TabIndex = 1111;
            this.label1.Text = "静脉压(mmHg)：";
            // 
            // m_cboJingMaiYa
            // 
            this.m_cboJingMaiYa.AccessibleDescription = "静脉压";
            this.m_cboJingMaiYa.BorderColor = System.Drawing.Color.Black;
            this.m_cboJingMaiYa.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboJingMaiYa.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboJingMaiYa.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboJingMaiYa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboJingMaiYa.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboJingMaiYa.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboJingMaiYa.ListBackColor = System.Drawing.Color.White;
            this.m_cboJingMaiYa.ListForeColor = System.Drawing.Color.Black;
            this.m_cboJingMaiYa.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboJingMaiYa.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboJingMaiYa.Location = new System.Drawing.Point(360, 54);
            this.m_cboJingMaiYa.m_BlnEnableItemEventMenu = true;
            this.m_cboJingMaiYa.MaxLength = 32767;
            this.m_cboJingMaiYa.Name = "m_cboJingMaiYa";
            this.m_cboJingMaiYa.SelectedIndex = -1;
            this.m_cboJingMaiYa.SelectedItem = null;
            this.m_cboJingMaiYa.SelectionStart = 0;
            this.m_cboJingMaiYa.Size = new System.Drawing.Size(102, 23);
            this.m_cboJingMaiYa.TabIndex = 2;
            this.m_cboJingMaiYa.TextBackColor = System.Drawing.Color.White;
            this.m_cboJingMaiYa.TextForeColor = System.Drawing.Color.Black;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(487, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 14);
            this.label2.TabIndex = 1111;
            this.label2.Text = "肝素量(mg)：";
            // 
            // m_cboGanSuLiang
            // 
            this.m_cboGanSuLiang.AccessibleDescription = "肝素量";
            this.m_cboGanSuLiang.BorderColor = System.Drawing.Color.Black;
            this.m_cboGanSuLiang.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboGanSuLiang.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboGanSuLiang.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboGanSuLiang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboGanSuLiang.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboGanSuLiang.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboGanSuLiang.ListBackColor = System.Drawing.Color.White;
            this.m_cboGanSuLiang.ListForeColor = System.Drawing.Color.Black;
            this.m_cboGanSuLiang.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboGanSuLiang.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboGanSuLiang.Location = new System.Drawing.Point(570, 54);
            this.m_cboGanSuLiang.m_BlnEnableItemEventMenu = true;
            this.m_cboGanSuLiang.MaxLength = 32767;
            this.m_cboGanSuLiang.Name = "m_cboGanSuLiang";
            this.m_cboGanSuLiang.SelectedIndex = -1;
            this.m_cboGanSuLiang.SelectedItem = null;
            this.m_cboGanSuLiang.SelectionStart = 0;
            this.m_cboGanSuLiang.Size = new System.Drawing.Size(102, 23);
            this.m_cboGanSuLiang.TabIndex = 3;
            this.m_cboGanSuLiang.TextBackColor = System.Drawing.Color.White;
            this.m_cboGanSuLiang.TextForeColor = System.Drawing.Color.Black;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(274, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 14);
            this.label3.TabIndex = 1111;
            this.label3.Text = "体  温(℃)：";
            // 
            // m_cboTiWen
            // 
            this.m_cboTiWen.AccessibleDescription = "体温";
            this.m_cboTiWen.BorderColor = System.Drawing.Color.Black;
            this.m_cboTiWen.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboTiWen.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboTiWen.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboTiWen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboTiWen.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboTiWen.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboTiWen.ListBackColor = System.Drawing.Color.White;
            this.m_cboTiWen.ListForeColor = System.Drawing.Color.Black;
            this.m_cboTiWen.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboTiWen.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboTiWen.Location = new System.Drawing.Point(360, 89);
            this.m_cboTiWen.m_BlnEnableItemEventMenu = true;
            this.m_cboTiWen.MaxLength = 32767;
            this.m_cboTiWen.Name = "m_cboTiWen";
            this.m_cboTiWen.SelectedIndex = -1;
            this.m_cboTiWen.SelectedItem = null;
            this.m_cboTiWen.SelectionStart = 0;
            this.m_cboTiWen.Size = new System.Drawing.Size(102, 23);
            this.m_cboTiWen.TabIndex = 5;
            this.m_cboTiWen.TextBackColor = System.Drawing.Color.White;
            this.m_cboTiWen.TextForeColor = System.Drawing.Color.Black;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(480, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 14);
            this.label7.TabIndex = 1111;
            this.label7.Text = "脉搏(次/分)：";
            // 
            // m_cboMaiBo
            // 
            this.m_cboMaiBo.AccessibleDescription = "脉搏";
            this.m_cboMaiBo.BorderColor = System.Drawing.Color.Black;
            this.m_cboMaiBo.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboMaiBo.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboMaiBo.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboMaiBo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboMaiBo.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboMaiBo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboMaiBo.ListBackColor = System.Drawing.Color.White;
            this.m_cboMaiBo.ListForeColor = System.Drawing.Color.Black;
            this.m_cboMaiBo.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboMaiBo.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboMaiBo.Location = new System.Drawing.Point(570, 89);
            this.m_cboMaiBo.m_BlnEnableItemEventMenu = true;
            this.m_cboMaiBo.MaxLength = 32767;
            this.m_cboMaiBo.Name = "m_cboMaiBo";
            this.m_cboMaiBo.SelectedIndex = -1;
            this.m_cboMaiBo.SelectedItem = null;
            this.m_cboMaiBo.SelectionStart = 0;
            this.m_cboMaiBo.Size = new System.Drawing.Size(102, 23);
            this.m_cboMaiBo.TabIndex = 6;
            this.m_cboMaiBo.TextBackColor = System.Drawing.Color.White;
            this.m_cboMaiBo.TextForeColor = System.Drawing.Color.Black;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(271, 130);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 14);
            this.label9.TabIndex = 1111;
            this.label9.Text = "呼吸(次/分)：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(491, 130);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 14);
            this.label10.TabIndex = 1111;
            this.label10.Text = "发    冷：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(49, 130);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 14);
            this.label11.TabIndex = 10000045;
            this.label11.Text = "血  压(kpa)：";
            // 
            // m_cboHuXi
            // 
            this.m_cboHuXi.AccessibleDescription = "呼吸";
            this.m_cboHuXi.BorderColor = System.Drawing.Color.Black;
            this.m_cboHuXi.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboHuXi.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboHuXi.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboHuXi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboHuXi.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboHuXi.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboHuXi.ListBackColor = System.Drawing.Color.White;
            this.m_cboHuXi.ListForeColor = System.Drawing.Color.Black;
            this.m_cboHuXi.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboHuXi.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboHuXi.Location = new System.Drawing.Point(360, 126);
            this.m_cboHuXi.m_BlnEnableItemEventMenu = true;
            this.m_cboHuXi.MaxLength = 32767;
            this.m_cboHuXi.Name = "m_cboHuXi";
            this.m_cboHuXi.SelectedIndex = -1;
            this.m_cboHuXi.SelectedItem = null;
            this.m_cboHuXi.SelectionStart = 0;
            this.m_cboHuXi.Size = new System.Drawing.Size(102, 23);
            this.m_cboHuXi.TabIndex = 8;
            this.m_cboHuXi.TextBackColor = System.Drawing.Color.White;
            this.m_cboHuXi.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboFaLeng
            // 
            this.m_cboFaLeng.AccessibleDescription = "发冷";
            this.m_cboFaLeng.BorderColor = System.Drawing.Color.Black;
            this.m_cboFaLeng.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboFaLeng.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboFaLeng.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboFaLeng.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboFaLeng.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboFaLeng.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboFaLeng.ListBackColor = System.Drawing.Color.White;
            this.m_cboFaLeng.ListForeColor = System.Drawing.Color.Black;
            this.m_cboFaLeng.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboFaLeng.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboFaLeng.Location = new System.Drawing.Point(570, 126);
            this.m_cboFaLeng.m_BlnEnableItemEventMenu = true;
            this.m_cboFaLeng.MaxLength = 32767;
            this.m_cboFaLeng.Name = "m_cboFaLeng";
            this.m_cboFaLeng.SelectedIndex = -1;
            this.m_cboFaLeng.SelectedItem = null;
            this.m_cboFaLeng.SelectionStart = 0;
            this.m_cboFaLeng.Size = new System.Drawing.Size(102, 23);
            this.m_cboFaLeng.TabIndex = 9;
            this.m_cboFaLeng.TextBackColor = System.Drawing.Color.White;
            this.m_cboFaLeng.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboXueYa
            // 
            this.m_cboXueYa.AccessibleDescription = "血压";
            this.m_cboXueYa.BackColor = System.Drawing.SystemColors.Window;
            this.m_cboXueYa.BorderColor = System.Drawing.Color.Black;
            this.m_cboXueYa.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboXueYa.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboXueYa.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboXueYa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboXueYa.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboXueYa.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboXueYa.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cboXueYa.ListBackColor = System.Drawing.Color.White;
            this.m_cboXueYa.ListForeColor = System.Drawing.Color.Black;
            this.m_cboXueYa.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboXueYa.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboXueYa.Location = new System.Drawing.Point(147, 126);
            this.m_cboXueYa.m_BlnEnableItemEventMenu = true;
            this.m_cboXueYa.MaxLength = 32767;
            this.m_cboXueYa.Name = "m_cboXueYa";
            this.m_cboXueYa.SelectedIndex = -1;
            this.m_cboXueYa.SelectedItem = null;
            this.m_cboXueYa.SelectionStart = 0;
            this.m_cboXueYa.Size = new System.Drawing.Size(102, 23);
            this.m_cboXueYa.TabIndex = 7;
            this.m_cboXueYa.TextBackColor = System.Drawing.Color.White;
            this.m_cboXueYa.TextForeColor = System.Drawing.Color.Black;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 14);
            this.label6.TabIndex = 10000045;
            this.label6.Text = "发    热：";
            // 
            // m_cboFaRe
            // 
            this.m_cboFaRe.AccessibleDescription = "发热";
            this.m_cboFaRe.BackColor = System.Drawing.SystemColors.Window;
            this.m_cboFaRe.BorderColor = System.Drawing.Color.Black;
            this.m_cboFaRe.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboFaRe.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboFaRe.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboFaRe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboFaRe.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboFaRe.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboFaRe.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cboFaRe.ListBackColor = System.Drawing.Color.White;
            this.m_cboFaRe.ListForeColor = System.Drawing.Color.Black;
            this.m_cboFaRe.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboFaRe.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboFaRe.Location = new System.Drawing.Point(147, 164);
            this.m_cboFaRe.m_BlnEnableItemEventMenu = true;
            this.m_cboFaRe.MaxLength = 32767;
            this.m_cboFaRe.Name = "m_cboFaRe";
            this.m_cboFaRe.SelectedIndex = -1;
            this.m_cboFaRe.SelectedItem = null;
            this.m_cboFaRe.SelectionStart = 0;
            this.m_cboFaRe.Size = new System.Drawing.Size(102, 23);
            this.m_cboFaRe.TabIndex = 10;
            this.m_cboFaRe.TextBackColor = System.Drawing.Color.White;
            this.m_cboFaRe.TextForeColor = System.Drawing.Color.Black;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(276, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 14);
            this.label8.TabIndex = 10000045;
            this.label8.Text = "头    痛：";
            // 
            // m_cboTouTong
            // 
            this.m_cboTouTong.AccessibleDescription = "头痛";
            this.m_cboTouTong.BackColor = System.Drawing.SystemColors.Window;
            this.m_cboTouTong.BorderColor = System.Drawing.Color.Black;
            this.m_cboTouTong.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboTouTong.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboTouTong.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboTouTong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboTouTong.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboTouTong.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboTouTong.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cboTouTong.ListBackColor = System.Drawing.Color.White;
            this.m_cboTouTong.ListForeColor = System.Drawing.Color.Black;
            this.m_cboTouTong.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboTouTong.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboTouTong.Location = new System.Drawing.Point(361, 164);
            this.m_cboTouTong.m_BlnEnableItemEventMenu = true;
            this.m_cboTouTong.MaxLength = 32767;
            this.m_cboTouTong.Name = "m_cboTouTong";
            this.m_cboTouTong.SelectedIndex = -1;
            this.m_cboTouTong.SelectedItem = null;
            this.m_cboTouTong.SelectionStart = 0;
            this.m_cboTouTong.Size = new System.Drawing.Size(102, 23);
            this.m_cboTouTong.TabIndex = 11;
            this.m_cboTouTong.TextBackColor = System.Drawing.Color.White;
            this.m_cboTouTong.TextForeColor = System.Drawing.Color.Black;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(497, 168);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 14);
            this.label12.TabIndex = 1111;
            this.label12.Text = "脱水量：";
            // 
            // m_cboTuoShuiLiang
            // 
            this.m_cboTuoShuiLiang.AccessibleDescription = "脱水量";
            this.m_cboTuoShuiLiang.BorderColor = System.Drawing.Color.Black;
            this.m_cboTuoShuiLiang.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboTuoShuiLiang.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboTuoShuiLiang.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboTuoShuiLiang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboTuoShuiLiang.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboTuoShuiLiang.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboTuoShuiLiang.ListBackColor = System.Drawing.Color.White;
            this.m_cboTuoShuiLiang.ListForeColor = System.Drawing.Color.Black;
            this.m_cboTuoShuiLiang.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboTuoShuiLiang.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboTuoShuiLiang.Location = new System.Drawing.Point(570, 164);
            this.m_cboTuoShuiLiang.m_BlnEnableItemEventMenu = true;
            this.m_cboTuoShuiLiang.MaxLength = 32767;
            this.m_cboTuoShuiLiang.Name = "m_cboTuoShuiLiang";
            this.m_cboTuoShuiLiang.SelectedIndex = -1;
            this.m_cboTuoShuiLiang.SelectedItem = null;
            this.m_cboTuoShuiLiang.SelectionStart = 0;
            this.m_cboTuoShuiLiang.Size = new System.Drawing.Size(102, 23);
            this.m_cboTuoShuiLiang.TabIndex = 12;
            this.m_cboTuoShuiLiang.TextBackColor = System.Drawing.Color.White;
            this.m_cboTuoShuiLiang.TextForeColor = System.Drawing.Color.Black;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(60, 206);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 14);
            this.label13.TabIndex = 10000045;
            this.label13.Text = "呕    吐：";
            // 
            // m_cboOuTu
            // 
            this.m_cboOuTu.AccessibleDescription = "呕吐";
            this.m_cboOuTu.BackColor = System.Drawing.SystemColors.Window;
            this.m_cboOuTu.BorderColor = System.Drawing.Color.Black;
            this.m_cboOuTu.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboOuTu.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboOuTu.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboOuTu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboOuTu.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboOuTu.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboOuTu.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cboOuTu.ListBackColor = System.Drawing.Color.White;
            this.m_cboOuTu.ListForeColor = System.Drawing.Color.Black;
            this.m_cboOuTu.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboOuTu.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboOuTu.Location = new System.Drawing.Point(147, 202);
            this.m_cboOuTu.m_BlnEnableItemEventMenu = true;
            this.m_cboOuTu.MaxLength = 32767;
            this.m_cboOuTu.Name = "m_cboOuTu";
            this.m_cboOuTu.SelectedIndex = -1;
            this.m_cboOuTu.SelectedItem = null;
            this.m_cboOuTu.SelectionStart = 0;
            this.m_cboOuTu.Size = new System.Drawing.Size(102, 23);
            this.m_cboOuTu.TabIndex = 13;
            this.m_cboOuTu.TextBackColor = System.Drawing.Color.White;
            this.m_cboOuTu.TextForeColor = System.Drawing.Color.Black;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(276, 206);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 14);
            this.label14.TabIndex = 10000045;
            this.label14.Text = "抽    搐：";
            // 
            // m_cboChouChu
            // 
            this.m_cboChouChu.AccessibleDescription = "抽搐";
            this.m_cboChouChu.BackColor = System.Drawing.SystemColors.Window;
            this.m_cboChouChu.BorderColor = System.Drawing.Color.Black;
            this.m_cboChouChu.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboChouChu.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboChouChu.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboChouChu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboChouChu.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboChouChu.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboChouChu.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cboChouChu.ListBackColor = System.Drawing.Color.White;
            this.m_cboChouChu.ListForeColor = System.Drawing.Color.Black;
            this.m_cboChouChu.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboChouChu.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboChouChu.Location = new System.Drawing.Point(361, 202);
            this.m_cboChouChu.m_BlnEnableItemEventMenu = true;
            this.m_cboChouChu.MaxLength = 32767;
            this.m_cboChouChu.Name = "m_cboChouChu";
            this.m_cboChouChu.SelectedIndex = -1;
            this.m_cboChouChu.SelectedItem = null;
            this.m_cboChouChu.SelectionStart = 0;
            this.m_cboChouChu.Size = new System.Drawing.Size(102, 23);
            this.m_cboChouChu.TabIndex = 14;
            this.m_cboChouChu.TextBackColor = System.Drawing.Color.White;
            this.m_cboChouChu.TextForeColor = System.Drawing.Color.Black;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(492, 206);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 14);
            this.label17.TabIndex = 10000045;
            this.label17.Text = "心    翳：";
            // 
            // m_cboXinYi
            // 
            this.m_cboXinYi.AccessibleDescription = "心翳";
            this.m_cboXinYi.BackColor = System.Drawing.SystemColors.Window;
            this.m_cboXinYi.BorderColor = System.Drawing.Color.Black;
            this.m_cboXinYi.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboXinYi.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboXinYi.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboXinYi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboXinYi.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboXinYi.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboXinYi.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cboXinYi.ListBackColor = System.Drawing.Color.White;
            this.m_cboXinYi.ListForeColor = System.Drawing.Color.Black;
            this.m_cboXinYi.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboXinYi.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboXinYi.Location = new System.Drawing.Point(570, 202);
            this.m_cboXinYi.m_BlnEnableItemEventMenu = true;
            this.m_cboXinYi.MaxLength = 32767;
            this.m_cboXinYi.Name = "m_cboXinYi";
            this.m_cboXinYi.SelectedIndex = -1;
            this.m_cboXinYi.SelectedItem = null;
            this.m_cboXinYi.SelectionStart = 0;
            this.m_cboXinYi.Size = new System.Drawing.Size(102, 23);
            this.m_cboXinYi.TabIndex = 15;
            this.m_cboXinYi.TextBackColor = System.Drawing.Color.White;
            this.m_cboXinYi.TextForeColor = System.Drawing.Color.Black;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(68, 244);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(63, 14);
            this.label18.TabIndex = 10000045;
            this.label18.Text = "钠浓度：";
            // 
            // m_cboNaNongDu
            // 
            this.m_cboNaNongDu.AccessibleDescription = "钠浓度";
            this.m_cboNaNongDu.BackColor = System.Drawing.SystemColors.Window;
            this.m_cboNaNongDu.BorderColor = System.Drawing.Color.Black;
            this.m_cboNaNongDu.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboNaNongDu.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboNaNongDu.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboNaNongDu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboNaNongDu.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboNaNongDu.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboNaNongDu.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cboNaNongDu.ListBackColor = System.Drawing.Color.White;
            this.m_cboNaNongDu.ListForeColor = System.Drawing.Color.Black;
            this.m_cboNaNongDu.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboNaNongDu.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboNaNongDu.Location = new System.Drawing.Point(147, 240);
            this.m_cboNaNongDu.m_BlnEnableItemEventMenu = true;
            this.m_cboNaNongDu.MaxLength = 32767;
            this.m_cboNaNongDu.Name = "m_cboNaNongDu";
            this.m_cboNaNongDu.SelectedIndex = -1;
            this.m_cboNaNongDu.SelectedItem = null;
            this.m_cboNaNongDu.SelectionStart = 0;
            this.m_cboNaNongDu.Size = new System.Drawing.Size(102, 23);
            this.m_cboNaNongDu.TabIndex = 16;
            this.m_cboNaNongDu.TextBackColor = System.Drawing.Color.White;
            this.m_cboNaNongDu.TextForeColor = System.Drawing.Color.Black;
            // 
            // txtSign
            // 
            this.txtSign.Location = new System.Drawing.Point(322, 296);
            this.txtSign.Name = "txtSign";
            this.txtSign.Size = new System.Drawing.Size(145, 23);
            this.txtSign.TabIndex = 19;
            // 
            // frmBloodCleanseRecordCon
            // 
            this.AccessibleDescription = "透析过程病情记录";
            this.ClientSize = new System.Drawing.Size(705, 345);
            this.Controls.Add(this.txtSign);
            this.Controls.Add(this.m_cboTouTong);
            this.Controls.Add(this.m_cboXinYi);
            this.Controls.Add(this.m_cboChouChu);
            this.Controls.Add(this.m_cboNaNongDu);
            this.Controls.Add(this.m_cboOuTu);
            this.Controls.Add(this.m_cboFaRe);
            this.Controls.Add(this.m_cboXueYa);
            this.Controls.Add(this.m_cboXueLiuLiang);
            this.Controls.Add(this.m_cboTuoShuiLiang);
            this.Controls.Add(this.m_cboFaLeng);
            this.Controls.Add(this.m_cboMaiBo);
            this.Controls.Add(this.m_cboGanSuLiang);
            this.Controls.Add(this.m_cboHuXi);
            this.Controls.Add(this.m_cboTiWen);
            this.Controls.Add(this.m_cboJingMaiYa);
            this.Controls.Add(this.m_cboTouXiYa);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.m_txtChuLi);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.m_cmdOK);
            this.Controls.Add(this.m_cmdCancel);
            this.Controls.Add(this.m_cmdSign);
            this.MaximizeBox = false;
            this.Name = "frmBloodCleanseRecordCon";
            this.Text = "透析过程病情记录表";
            this.Load += new System.EventHandler(this.frmBloodCleanseRecordCon_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmBloodCleanseRecordCon_KeyPress);
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
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.label18, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.label17, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label16, 0);
            this.Controls.SetChildIndex(this.m_txtChuLi, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.m_cboTouXiYa, 0);
            this.Controls.SetChildIndex(this.m_cboJingMaiYa, 0);
            this.Controls.SetChildIndex(this.m_cboTiWen, 0);
            this.Controls.SetChildIndex(this.m_cboHuXi, 0);
            this.Controls.SetChildIndex(this.m_cboGanSuLiang, 0);
            this.Controls.SetChildIndex(this.m_cboMaiBo, 0);
            this.Controls.SetChildIndex(this.m_cboFaLeng, 0);
            this.Controls.SetChildIndex(this.m_cboTuoShuiLiang, 0);
            this.Controls.SetChildIndex(this.m_cboXueLiuLiang, 0);
            this.Controls.SetChildIndex(this.m_cboXueYa, 0);
            this.Controls.SetChildIndex(this.m_cboFaRe, 0);
            this.Controls.SetChildIndex(this.m_cboOuTu, 0);
            this.Controls.SetChildIndex(this.m_cboNaNongDu, 0);
            this.Controls.SetChildIndex(this.m_cboChouChu, 0);
            this.Controls.SetChildIndex(this.m_cboXinYi, 0);
            this.Controls.SetChildIndex(this.m_cboTouTong, 0);
            this.Controls.SetChildIndex(this.txtSign, 0);
            this.m_pnlNewBase.ResumeLayout(false);
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
            this.m_cboTouXiYa.Text = string.Empty;
            this.m_cboJingMaiYa.Text = string.Empty;
            this.m_cboGanSuLiang.Text = string.Empty;
            this.m_cboXueLiuLiang.Text = string.Empty;
            this.m_cboTiWen.Text = string.Empty;
            this.m_cboMaiBo.Text = string.Empty;
            this.m_cboXueYa.Text = string.Empty;
            this.m_cboHuXi.Text = string.Empty;
            this.m_cboFaLeng.Text = string.Empty;
            this.m_cboFaRe.Text = string.Empty;
            this.m_cboTouTong.Text = string.Empty;
            this.m_cboTuoShuiLiang.Text = string.Empty;
            this.m_cboOuTu.Text = string.Empty;
            this.m_cboChouChu.Text = string.Empty;
            this.m_cboXinYi.Text = string.Empty;
            this.m_cboNaNongDu.Text = string.Empty;
            this.txtSign.Text = string.Empty;
            this.m_txtChuLi.m_mthClearText();
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
            clsDialyseRecord_Value objContent = (clsDialyseRecord_Value)p_objContent;
			//把表单值赋值到界面，由子窗体重载实现			
			this.m_mthClearRecordInfo();
            this.m_cboTouXiYa.Text = objContent.m_strTOUXIYA_CHR;
			this.m_cboJingMaiYa.Text=objContent.m_strJINGMAI_CHR;
			this.m_cboGanSuLiang.Text=objContent.m_strGANSULIANG_CHR;
            this.m_cboXueLiuLiang.Text = objContent.m_strXUELIULIANG_CHR;
			this.m_cboXueLiuLiang.Text=objContent.m_strXUELIULIANG_CHR;
			this.m_cboTiWen.Text=objContent.m_strTIWEN_CHR;
			this.m_cboMaiBo.Text=objContent.m_strMAIBO_CHR;
			this.m_cboXueYa.Text=objContent.m_strXUEYA_CHR;
			this.m_cboHuXi.Text=objContent.m_strHUXI_CHR;
			this.m_cboFaLeng.Text=objContent.m_strFALENG_CHR;
			this.m_cboFaRe.Text=objContent.m_strFARE_CHR;
            this.m_cboTouTong.Text = objContent.m_strTOUTONG_CHR;
            this.m_cboTuoShuiLiang.Text = objContent.m_strTUOSHUILIANG_CHR;
            this.m_cboOuTu.Text = objContent.m_strOUTU_CHR;
            this.m_cboChouChu.Text = objContent.m_strCHOUCHU_CHR;
            this.m_cboXinYi.Text = objContent.m_strXINYI_CHR;
            this.m_cboNaNongDu.Text = objContent.m_strNANONGDU_CHR;
            this.m_txtChuLi.m_mthSetNewText(objContent.m_strCHULI_CHR, objContent.m_strCHULI_CHRXML);
            this.m_dtpCreateDate.Value = objContent.m_dtmRecordDate;
            this.txtSign.Text = objContent.m_strRECORDUSERNAME_CHR;	
		}

		protected override void m_mthSetDeletedGUIFromContent(iCareData.clsTrackRecordContent p_objContent)
		{
            clsDialyseRecord_Value objContent = (clsDialyseRecord_Value)p_objContent;
			//把表单值赋值到界面，由子窗体重载实现			
            this.m_mthClearRecordInfo();
            this.m_cboTouXiYa.Text = objContent.m_strTOUXIYA_CHR;
            this.m_cboJingMaiYa.Text = objContent.m_strJINGMAI_CHR;
            this.m_cboGanSuLiang.Text = objContent.m_strGANSULIANG_CHR;
            this.m_cboXueLiuLiang.Text = objContent.m_strXUELIULIANG_CHR;
            this.m_cboXueLiuLiang.Text = objContent.m_strXUELIULIANG_CHR;
            this.m_cboTiWen.Text = objContent.m_strTIWEN_CHR;
            this.m_cboMaiBo.Text = objContent.m_strMAIBO_CHR;
            this.m_cboXueYa.Text = objContent.m_strXUEYA_CHR;
            this.m_cboHuXi.Text = objContent.m_strHUXI_CHR;
            this.m_cboFaLeng.Text = objContent.m_strFALENG_CHR;
            this.m_cboFaRe.Text = objContent.m_strFARE_CHR;
            this.m_cboTouTong.Text = objContent.m_strTOUTONG_CHR;
            this.m_cboTuoShuiLiang.Text = objContent.m_strTUOSHUILIANG_CHR;
            this.m_cboOuTu.Text = objContent.m_strOUTU_CHR;
            this.m_cboChouChu.Text = objContent.m_strCHOUCHU_CHR;
            this.m_cboXinYi.Text = objContent.m_strXINYI_CHR;
            this.m_cboNaNongDu.Text = objContent.m_strNANONGDU_CHR;
            this.m_txtChuLi.m_mthSetNewText(objContent.m_strCHULI_CHR, objContent.m_strCHULI_CHRXML);
            this.m_dtpCreateDate.Value = objContent.m_dtmRecordDate;
            this.txtSign.Text = objContent.m_strRECORDUSERNAME_CHR;
		
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
            clsDialyseRecord_Value objContent = new clsDialyseRecord_Value();
			try
			{
                objContent.m_dtmCreateDate = new clsPublicDomain().m_dtmGetServerTime() ;

                objContent.m_strTOUXIYA_CHR = this.m_cboTouXiYa.Text;
                objContent.m_strJINGMAI_CHR = this.m_cboJingMaiYa.Text;
                objContent.m_strGANSULIANG_CHR = this.m_cboGanSuLiang.Text;
                objContent.m_strXUELIULIANG_CHR = this.m_cboXueLiuLiang.Text;
                objContent.m_strTIWEN_CHR = this.m_cboTiWen.Text;
                objContent.m_strMAIBO_CHR = this.m_cboMaiBo.Text;
                objContent.m_strXUEYA_CHR = this.m_cboXueYa.Text;
                objContent.m_strHUXI_CHR = this.m_cboHuXi.Text;
                objContent.m_strFALENG_CHR = this.m_cboFaLeng.Text;
                objContent.m_strFARE_CHR = this.m_cboFaRe.Text;
                objContent.m_strTOUTONG_CHR = this.m_cboTouTong.Text;
                objContent.m_strTUOSHUILIANG_CHR = this.m_cboTuoShuiLiang.Text;
                objContent.m_strOUTU_CHR = this.m_cboOuTu.Text;
                objContent.m_strCHOUCHU_CHR = this.m_cboChouChu.Text;
                objContent.m_strXINYI_CHR = this.m_cboXinYi.Text;
                objContent.m_strNANONGDU_CHR = this.m_cboNaNongDu.Text;
                objContent.m_strCHULI_CHR = this.m_txtChuLi.Text;
                objContent.m_strCHULI_CHR_RIGHT = this.m_txtChuLi.m_strGetRightText();
                objContent.m_strCHULI_CHRXML = this.m_txtChuLi.m_strGetXmlText();
                objContent.m_strRECORDUSERNAME_CHR = txtSign.Text;
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
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.frmBloodCleanseRecord);	
			//(需要改动)				
		}

		/// <summary>
		/// 把选择时间记录内容重新整理为完全正确的内容。
		/// </summary>
		/// <param name="p_objRecordContent"></param>
		protected override void m_mthReAddNewRecord(clsTrackRecordContent p_objRecordContent)
		{
			//把选择时间记录内容重新整理为完全正确的内容，由子窗体重载实现。
            clsDialyseRecord_Value objContent = (clsDialyseRecord_Value)p_objRecordContent; //(需要改动)
		}

		public override string m_strReloadFormTitle()
		{
			//由子窗体重载实现
			//(需要改动)	
			return	"血液净化记录表";
		}

		
		#region Jump Control
		protected override void m_mthInitJump(clsJumpControl p_objJump)
		{
			p_objJump=new clsJumpControl(this,
                new Control[]{}, Keys.Enter);
		}
		#endregion

        private void frmBloodCleanseRecordCon_Load(object sender, System.EventArgs e)
		{
            this.m_cboTouXiYa.Focus();
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

        private void frmBloodCleanseRecordCon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }
       
	}
}

