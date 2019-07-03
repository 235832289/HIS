
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

namespace iCare
{
	/// <summary>
	/// 胎动监护表(增加，修改窗体)
	/// </summary>
	public class frmQuickeningTutelar_AcadCon : frmDiseaseTrackBase
	{
		#region define

		private PinkieControls.ButtonXP m_cmdOK;
		private PinkieControls.ButtonXP m_cmdCancel;
		private clsEmployeeSignTool m_objSignTool;
		private clsCommonUseToolCollection m_objCUTC;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		#endregion

		public System.DateTime m_dtmBEFOREHAND_CHR = System.DateTime.Now;
		public string m_strLAYCOUNT_CHR = "";
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private com.digitalwave.controls.ctlRichTextBox m_txtPREGNANTTEAM_CHR;
		private com.digitalwave.controls.ctlRichTextBox m_txtMORNING_CHR;
		private com.digitalwave.controls.ctlRichTextBox m_txtMIDDAY_CHR;
		private com.digitalwave.controls.ctlRichTextBox m_txtEVENING_CHR;
		private com.digitalwave.controls.ctlRichTextBox m_txtQUICKENINGNUM_CHR;//12小时胎动数
		public string m_strFlag = "0";//是否新增

		public frmQuickeningTutelar_AcadCon()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			m_mthSetRichTextBoxAttribInControl(this);
//			m_objSignTool = new clsEmployeeSignTool(m_lsvEmployee);
//			m_objSignTool.m_mthAddControl(new Control[]{m_txtSign},false);
			m_objCUTC = new clsCommonUseToolCollection(this);
		//	m_objCUTC.m_mthBindEmployeeSign(new Control[]{m_cmdSign},new Control[]{m_txtSign},new int[]{1});

			
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
				return 96;
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
            this.m_txtPREGNANTTEAM_CHR = new com.digitalwave.controls.ctlRichTextBox();
            this.m_cmdOK = new PinkieControls.ButtonXP();
            this.m_cmdCancel = new PinkieControls.ButtonXP();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtMORNING_CHR = new com.digitalwave.controls.ctlRichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtMIDDAY_CHR = new com.digitalwave.controls.ctlRichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_txtQUICKENINGNUM_CHR = new com.digitalwave.controls.ctlRichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_txtEVENING_CHR = new com.digitalwave.controls.ctlRichTextBox();
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
            this.lblCreateDateTitle.Location = new System.Drawing.Point(16, 16);
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.Location = new System.Drawing.Point(96, 16);
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
            this.lblSex.Size = new System.Drawing.Size(48, 35);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(736, -120);
            this.lblAge.Size = new System.Drawing.Size(52, 35);
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
            this.m_lsvInPatientID.Size = new System.Drawing.Size(116, 120);
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
            this.m_cmdNewTemplate.Size = new System.Drawing.Size(84, 48);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.Location = new System.Drawing.Point(196, -120);
            this.m_cmdNext.Size = new System.Drawing.Size(24, 37);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(156, -120);
            this.m_cmdPre.Size = new System.Drawing.Size(24, 37);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(272, -112);
            this.m_lblForTitle.Size = new System.Drawing.Size(16, 39);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(59, 109);
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            // 
            // m_txtPREGNANTTEAM_CHR
            // 
            this.m_txtPREGNANTTEAM_CHR.AccessibleDescription = "预产期";
            this.m_txtPREGNANTTEAM_CHR.BackColor = System.Drawing.Color.White;
            this.m_txtPREGNANTTEAM_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPREGNANTTEAM_CHR.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtPREGNANTTEAM_CHR.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPREGNANTTEAM_CHR.Location = new System.Drawing.Point(400, 16);
            this.m_txtPREGNANTTEAM_CHR.m_BlnIgnoreUserInfo = false;
            this.m_txtPREGNANTTEAM_CHR.m_BlnPartControl = false;
            this.m_txtPREGNANTTEAM_CHR.m_BlnReadOnly = false;
            this.m_txtPREGNANTTEAM_CHR.m_BlnUnderLineDST = false;
            this.m_txtPREGNANTTEAM_CHR.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPREGNANTTEAM_CHR.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPREGNANTTEAM_CHR.m_IntCanModifyTime = 6;
            this.m_txtPREGNANTTEAM_CHR.m_IntPartControlLength = 0;
            this.m_txtPREGNANTTEAM_CHR.m_IntPartControlStartIndex = 0;
            this.m_txtPREGNANTTEAM_CHR.m_StrUserID = "";
            this.m_txtPREGNANTTEAM_CHR.m_StrUserName = "";
            this.m_txtPREGNANTTEAM_CHR.MaxLength = 8000;
            this.m_txtPREGNANTTEAM_CHR.Multiline = false;
            this.m_txtPREGNANTTEAM_CHR.Name = "m_txtPREGNANTTEAM_CHR";
            this.m_txtPREGNANTTEAM_CHR.Size = new System.Drawing.Size(104, 22);
            this.m_txtPREGNANTTEAM_CHR.TabIndex = 1113;
            this.m_txtPREGNANTTEAM_CHR.Text = "";
            // 
            // m_cmdOK
            // 
            this.m_cmdOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdOK.DefaultScheme = true;
            this.m_cmdOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdOK.Hint = "";
            this.m_cmdOK.Location = new System.Drawing.Point(600, 152);
            this.m_cmdOK.Name = "m_cmdOK";
            this.m_cmdOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdOK.Size = new System.Drawing.Size(64, 32);
            this.m_cmdOK.TabIndex = 10000022;
            this.m_cmdOK.Text = "保存";
            this.m_cmdOK.Click += new System.EventHandler(this.m_cmdOK_Click);
            // 
            // m_cmdCancel
            // 
            this.m_cmdCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdCancel.DefaultScheme = true;
            this.m_cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdCancel.Hint = "";
            this.m_cmdCancel.Location = new System.Drawing.Point(720, 152);
            this.m_cmdCancel.Name = "m_cmdCancel";
            this.m_cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCancel.Size = new System.Drawing.Size(64, 32);
            this.m_cmdCancel.TabIndex = 10000023;
            this.m_cmdCancel.Text = "关闭";
            this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(360, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 10000026;
            this.label1.Text = "孕周:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 10000028;
            this.label2.Text = "早：";
            // 
            // m_txtMORNING_CHR
            // 
            this.m_txtMORNING_CHR.AccessibleDescription = "早";
            this.m_txtMORNING_CHR.BackColor = System.Drawing.Color.White;
            this.m_txtMORNING_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtMORNING_CHR.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtMORNING_CHR.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtMORNING_CHR.Location = new System.Drawing.Point(96, 72);
            this.m_txtMORNING_CHR.m_BlnIgnoreUserInfo = false;
            this.m_txtMORNING_CHR.m_BlnPartControl = false;
            this.m_txtMORNING_CHR.m_BlnReadOnly = false;
            this.m_txtMORNING_CHR.m_BlnUnderLineDST = false;
            this.m_txtMORNING_CHR.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtMORNING_CHR.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtMORNING_CHR.m_IntCanModifyTime = 6;
            this.m_txtMORNING_CHR.m_IntPartControlLength = 0;
            this.m_txtMORNING_CHR.m_IntPartControlStartIndex = 0;
            this.m_txtMORNING_CHR.m_StrUserID = "";
            this.m_txtMORNING_CHR.m_StrUserName = "";
            this.m_txtMORNING_CHR.MaxLength = 8000;
            this.m_txtMORNING_CHR.Multiline = false;
            this.m_txtMORNING_CHR.Name = "m_txtMORNING_CHR";
            this.m_txtMORNING_CHR.Size = new System.Drawing.Size(104, 22);
            this.m_txtMORNING_CHR.TabIndex = 10000027;
            this.m_txtMORNING_CHR.Text = "";
            this.m_txtMORNING_CHR.Leave += new System.EventHandler(this.m_txtMORNING_CHR_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(216, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 14);
            this.label3.TabIndex = 10000030;
            this.label3.Text = "中:";
            // 
            // m_txtMIDDAY_CHR
            // 
            this.m_txtMIDDAY_CHR.AccessibleDescription = "中";
            this.m_txtMIDDAY_CHR.BackColor = System.Drawing.Color.White;
            this.m_txtMIDDAY_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtMIDDAY_CHR.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtMIDDAY_CHR.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtMIDDAY_CHR.Location = new System.Drawing.Point(248, 72);
            this.m_txtMIDDAY_CHR.m_BlnIgnoreUserInfo = false;
            this.m_txtMIDDAY_CHR.m_BlnPartControl = false;
            this.m_txtMIDDAY_CHR.m_BlnReadOnly = false;
            this.m_txtMIDDAY_CHR.m_BlnUnderLineDST = false;
            this.m_txtMIDDAY_CHR.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtMIDDAY_CHR.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtMIDDAY_CHR.m_IntCanModifyTime = 6;
            this.m_txtMIDDAY_CHR.m_IntPartControlLength = 0;
            this.m_txtMIDDAY_CHR.m_IntPartControlStartIndex = 0;
            this.m_txtMIDDAY_CHR.m_StrUserID = "";
            this.m_txtMIDDAY_CHR.m_StrUserName = "";
            this.m_txtMIDDAY_CHR.MaxLength = 8000;
            this.m_txtMIDDAY_CHR.Multiline = false;
            this.m_txtMIDDAY_CHR.Name = "m_txtMIDDAY_CHR";
            this.m_txtMIDDAY_CHR.Size = new System.Drawing.Size(104, 22);
            this.m_txtMIDDAY_CHR.TabIndex = 10000029;
            this.m_txtMIDDAY_CHR.Text = "";
            this.m_txtMIDDAY_CHR.Leave += new System.EventHandler(this.m_txtMIDDAY_CHR_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(512, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 14);
            this.label4.TabIndex = 10000032;
            this.label4.Text = "12小时胎动数:";
            // 
            // m_txtQUICKENINGNUM_CHR
            // 
            this.m_txtQUICKENINGNUM_CHR.AccessibleDescription = "孕周";
            this.m_txtQUICKENINGNUM_CHR.BackColor = System.Drawing.Color.White;
            this.m_txtQUICKENINGNUM_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtQUICKENINGNUM_CHR.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtQUICKENINGNUM_CHR.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtQUICKENINGNUM_CHR.Location = new System.Drawing.Point(616, 72);
            this.m_txtQUICKENINGNUM_CHR.m_BlnIgnoreUserInfo = false;
            this.m_txtQUICKENINGNUM_CHR.m_BlnPartControl = false;
            this.m_txtQUICKENINGNUM_CHR.m_BlnReadOnly = false;
            this.m_txtQUICKENINGNUM_CHR.m_BlnUnderLineDST = false;
            this.m_txtQUICKENINGNUM_CHR.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtQUICKENINGNUM_CHR.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtQUICKENINGNUM_CHR.m_IntCanModifyTime = 6;
            this.m_txtQUICKENINGNUM_CHR.m_IntPartControlLength = 0;
            this.m_txtQUICKENINGNUM_CHR.m_IntPartControlStartIndex = 0;
            this.m_txtQUICKENINGNUM_CHR.m_StrUserID = "";
            this.m_txtQUICKENINGNUM_CHR.m_StrUserName = "";
            this.m_txtQUICKENINGNUM_CHR.MaxLength = 8000;
            this.m_txtQUICKENINGNUM_CHR.Multiline = false;
            this.m_txtQUICKENINGNUM_CHR.Name = "m_txtQUICKENINGNUM_CHR";
            this.m_txtQUICKENINGNUM_CHR.Size = new System.Drawing.Size(104, 22);
            this.m_txtQUICKENINGNUM_CHR.TabIndex = 10000031;
            this.m_txtQUICKENINGNUM_CHR.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(368, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 14);
            this.label5.TabIndex = 10000034;
            this.label5.Text = "晚:";
            // 
            // m_txtEVENING_CHR
            // 
            this.m_txtEVENING_CHR.AccessibleDescription = "晚";
            this.m_txtEVENING_CHR.BackColor = System.Drawing.Color.White;
            this.m_txtEVENING_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtEVENING_CHR.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtEVENING_CHR.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtEVENING_CHR.Location = new System.Drawing.Point(400, 72);
            this.m_txtEVENING_CHR.m_BlnIgnoreUserInfo = false;
            this.m_txtEVENING_CHR.m_BlnPartControl = false;
            this.m_txtEVENING_CHR.m_BlnReadOnly = false;
            this.m_txtEVENING_CHR.m_BlnUnderLineDST = false;
            this.m_txtEVENING_CHR.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtEVENING_CHR.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtEVENING_CHR.m_IntCanModifyTime = 6;
            this.m_txtEVENING_CHR.m_IntPartControlLength = 0;
            this.m_txtEVENING_CHR.m_IntPartControlStartIndex = 0;
            this.m_txtEVENING_CHR.m_StrUserID = "";
            this.m_txtEVENING_CHR.m_StrUserName = "";
            this.m_txtEVENING_CHR.MaxLength = 8000;
            this.m_txtEVENING_CHR.Multiline = false;
            this.m_txtEVENING_CHR.Name = "m_txtEVENING_CHR";
            this.m_txtEVENING_CHR.Size = new System.Drawing.Size(104, 22);
            this.m_txtEVENING_CHR.TabIndex = 10000033;
            this.m_txtEVENING_CHR.Text = "";
            this.m_txtEVENING_CHR.Leave += new System.EventHandler(this.m_txtEVENING_CHR_Leave);
            // 
            // frmQuickeningTutelar_AcadCon
            // 
            this.AccessibleDescription = "12小时胎动数";
            this.ClientSize = new System.Drawing.Size(808, 205);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.m_txtEVENING_CHR);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.m_txtQUICKENINGNUM_CHR);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_txtMIDDAY_CHR);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_txtMORNING_CHR);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_cmdOK);
            this.Controls.Add(this.m_cmdCancel);
            this.Controls.Add(this.m_txtPREGNANTTEAM_CHR);
            this.Name = "frmQuickeningTutelar_AcadCon";
            this.Text = "胎动监护表";
            this.Load += new System.EventHandler(this.frmICUNurseRecord_GXCon_Load);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_txtPREGNANTTEAM_CHR, 0);
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
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.m_txtMORNING_CHR, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.m_txtMIDDAY_CHR, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.m_txtQUICKENINGNUM_CHR, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.m_txtEVENING_CHR, 0);
            this.Controls.SetChildIndex(this.label5, 0);
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
	
			//	this.m_txtLayCount_chr.m_mthClearText();
			//this.m_txtEmbryoLocation_chr.m_mthClearText();
			//this.m_txtEmbryoHeart_chr.m_mthClearText();
			//this.m_txtBloodPressure_chr1.m_mthClearText();
			//this.m_txtBloodPressure_chr2.m_mthClearText();
			//	this.m_txtBeforehand_chr.m_mthClearText();
			//this.m_txtPalaceMouth_chr.m_mthClearText();
			//this.m_txtShow_chr.m_mthClearText();
			//this.m_txtCaul_chr.m_mthClearText();
			//this.m_txtAnusCheck_chr.m_mthClearText();
//			this.m_txtIntermission_chr.m_mthClearText();
//			this.m_txtPersist_chr.m_mthClearText();
//			this.m_txtIntensity_chr.m_mthClearText();
//			this.m_txtOther_chr.m_mthClearText();
//			this.m_txtSign.m_mthClearText();
			this.m_txtEVENING_CHR.m_mthClearText();
			this.m_txtPREGNANTTEAM_CHR.m_mthClearText();
			this.m_txtMORNING_CHR.m_mthClearText();
			this.m_txtMIDDAY_CHR.m_mthClearText();
			this.m_txtQUICKENINGNUM_CHR.m_mthClearText();
			
//			m_objSignTool.m_mthSetDefaulEmployee();
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
			clsQuickeningTutelarValue objContent=(clsQuickeningTutelarValue )p_objContent;
			//把表单值赋值到界面，由子窗体重载实现			
			this.m_mthClearRecordInfo();


			this.m_txtPREGNANTTEAM_CHR.m_mthSetNewText(objContent.m_strPREGNANTTEAM_CHR,objContent.m_strPREGNANTTEAM_CHRXML);
			this.m_txtMORNING_CHR.m_mthSetNewText(objContent.m_strMORNING_CHR,objContent.m_strMORNING_CHRXML);
			this.m_txtMIDDAY_CHR.m_mthSetNewText(objContent.m_strMIDDAY_CHR,objContent.m_strMIDDAY_CHRXML);
			this.m_txtEVENING_CHR.m_mthSetNewText(objContent.m_strEVENING_CHR,objContent.m_strEVENING_CHRXML);
			this.m_txtQUICKENINGNUM_CHR.m_mthSetNewText(objContent.m_strQUICKENINGNUM_CHR,objContent.m_strQUICKENINGNUM_CHRXML);
			
			
//			if(objContent.m_strScrutator_chr !=null &&objContent.m_strScrutator_chr != "")
//				m_txtSign.Text=objContent.m_strScrutator_chr;
//			this.m_txtSign.Enabled = false;
			this.m_dtpCreateDate.Enabled = false;
		}

		protected override void m_mthSetDeletedGUIFromContent(iCareData.clsTrackRecordContent p_objContent)
		{
			clsQuickeningTutelarValue objContent=(clsQuickeningTutelarValue )p_objContent;
			//把表单值赋值到界面，由子窗体重载实现			

			this.m_mthClearRecordInfo();
		

			this.m_txtPREGNANTTEAM_CHR.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strPREGNANTTEAM_CHR,objContent.m_strPREGNANTTEAM_CHRXML);
			this.m_txtMORNING_CHR.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strMORNING_CHR,objContent.m_strMORNING_CHRXML);
			this.m_txtMIDDAY_CHR.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strMIDDAY_CHR,objContent.m_strMIDDAY_CHRXML);
			
			this.m_txtEVENING_CHR.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strEVENING_CHR,objContent.m_strEVENING_CHRXML);
			
			this.m_txtQUICKENINGNUM_CHR.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strQUICKENINGNUM_CHR,objContent.m_strQUICKENINGNUM_CHRXML);
			
			
			
//			if(objContent.m_strScrutator_chr !=null &&objContent.m_strScrutator_chr != "")
//				m_txtSign.Text=objContent.m_strScrutator_chr;
//			this.m_txtSign.Enabled = false;
			this.m_dtpCreateDate.Enabled = false;


		
		}

		protected override iCareData.clsTrackRecordContent m_objGetContentFromGUI()
		{
			
			//界面参数校验
			if(m_objCurrentPatient==null)// || this.txtInPatientID.Text!=this.m_objCurrentPatient.m_StrHISInPatientID || txtInPatientID.Text=="")				
				return null;

			//从界面获取表单值		
			clsQuickeningTutelarValue objContent=new clsQuickeningTutelarValue ();
			try
			{
				objContent.m_dtmCreateDate =DateTime.Now ;
 
			

							//objContent.m_strINAMOUNTITEM_RIGHT=this.m_txtItem.m_strGetRightText();
				objContent.m_strPREGNANTTEAM_CHR=this.m_txtPREGNANTTEAM_CHR.Text;
				objContent.m_strPREGNANTTEAM_CHR_RIGHT=this.m_txtPREGNANTTEAM_CHR.m_strGetRightText();
				objContent.m_strPREGNANTTEAM_CHRXML=this.m_txtPREGNANTTEAM_CHR.m_strGetXmlText();

				objContent.m_strMORNING_CHR_RIGHT=this.m_txtMORNING_CHR.m_strGetRightText();
				objContent.m_strMORNING_CHR=this.m_txtMORNING_CHR.Text;
				objContent.m_strMORNING_CHRXML=this.m_txtMORNING_CHR.m_strGetXmlText();

				objContent.m_strMIDDAY_CHR_RIGHT=this.m_txtMIDDAY_CHR.m_strGetRightText();
				objContent.m_strMIDDAY_CHR=this.m_txtMIDDAY_CHR.Text;
				objContent.m_strMIDDAY_CHRXML=this.m_txtMIDDAY_CHR.m_strGetXmlText();

				objContent.m_strEVENING_CHR_RIGHT=this.m_txtEVENING_CHR.m_strGetRightText();
				objContent.m_strEVENING_CHR=this.m_txtEVENING_CHR.Text;
				objContent.m_strEVENING_CHRXML=this.m_txtEVENING_CHR.m_strGetXmlText();

				objContent.m_strQUICKENINGNUM_CHR_RIGHT=this.m_txtQUICKENINGNUM_CHR.m_strGetRightText();
				objContent.m_strQUICKENINGNUM_CHR=this.m_txtQUICKENINGNUM_CHR.Text;
				objContent.m_strQUICKENINGNUM_CHRXML=this.m_txtQUICKENINGNUM_CHR.m_strGetXmlText();

//				objContent.m_strCreateUserID = ((clsEmployee)m_txtSign.Tag).m_StrEmployeeID;
				objContent.m_dtmModifyDate = DateTime.Now;
				objContent.m_strModifyUserID = MDIParent.OperatorID;
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
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.QuickeningTutelar_Acad);	
			//(需要改动)				
		}

		/// <summary>
		/// 把选择时间记录内容重新整理为完全正确的内容。
		/// </summary>
		/// <param name="p_objRecordContent"></param>
		protected override void m_mthReAddNewRecord(clsTrackRecordContent p_objRecordContent)
		{
			//把选择时间记录内容重新整理为完全正确的内容，由子窗体重载实现。
			clsQuickeningTutelarValue objContent=(clsQuickeningTutelarValue)p_objRecordContent; //(需要改动)
		}

		public override string m_strReloadFormTitle()
		{
			//由子窗体重载实现
			//(需要改动)	
			return	"胎动监护表";
		}

		
		#region Jump Control
		protected override void m_mthInitJump(clsJumpControl p_objJump)
		{	//(需要改动)	
			p_objJump=new clsJumpControl(this,
				new Control[]{m_txtPREGNANTTEAM_CHR,m_txtMORNING_CHR,m_txtMIDDAY_CHR,m_txtEVENING_CHR,m_txtQUICKENINGNUM_CHR,m_cmdOK},Keys.Enter);
		}
		#endregion

		private void frmICUNurseRecord_GXCon_Load(object sender, System.EventArgs e)
		{
			this.m_txtPREGNANTTEAM_CHR.Focus();
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

		private void m_txtAnusCheck_chr_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void m_txtIntermission_chr_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void m_txtEVENING_CHR_Leave(object sender, System.EventArgs e)
		{
			if(this.m_txtMORNING_CHR.Text.Trim()!=""&& this.m_txtMIDDAY_CHR.Text.Trim()!="")
				this.m_txtQUICKENINGNUM_CHR.Text=Convert.ToString((Convert.ToInt32(this.m_txtMORNING_CHR.Text.ToString())+Convert.ToInt32(this.m_txtMIDDAY_CHR.Text.ToString())+Convert.ToInt32(this.m_txtEVENING_CHR.Text.Trim()))*4);

		}

		private void m_txtMIDDAY_CHR_Leave(object sender, System.EventArgs e)
		{
			if(this.m_txtMORNING_CHR.Text.Trim()!=""&& this.m_txtEVENING_CHR.Text.Trim()!="")
				this.m_txtQUICKENINGNUM_CHR.Text=Convert.ToString((Convert.ToInt32(this.m_txtMORNING_CHR.Text.ToString())+Convert.ToInt32(this.m_txtMIDDAY_CHR.Text.Trim())+Convert.ToInt32(this.m_txtEVENING_CHR.Text))*4);

		}

		private void m_txtMORNING_CHR_Leave(object sender, System.EventArgs e)
		{
			if(this.m_txtMIDDAY_CHR.Text.Trim()!=""&& this.m_txtEVENING_CHR.Text.Trim()!="")
				this.m_txtQUICKENINGNUM_CHR.Text=Convert.ToString((Convert.ToInt32(this.m_txtMORNING_CHR.Text.Trim())+Convert.ToInt32(this.m_txtMIDDAY_CHR.Text.ToString())+Convert.ToInt32(this.m_txtEVENING_CHR.Text))*4);

		}

//		private void m_lsvEmployee_DoubleClick(object sender, System.EventArgs e)
//		{
//			if(m_lsvEmployee.Items.Count!=0)
//				if(m_lsvEmployee.SelectedItems.Count>0)
//					m_txtSign.Text = 	m_lsvEmployee.SelectedItems[0].Text;
//			
//		}

//		private void dateTimePicker1_ValueChanged(object sender, System.EventArgs e)
//		{
//			m_txtBeforehand_chr.Text = this.dateTimePicker1.Value.ToString();
//		}

	}
}

