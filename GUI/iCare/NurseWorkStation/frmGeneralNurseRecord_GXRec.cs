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
using com.digitalwave.clsGeneralNurseRecord_GXService;
using com.digitalwave.Emr.Signature_gui;

namespace iCare
{
	/// <summary>
    /// 一般患者护理记录
	/// </summary>
	public class frmGeneralNurseRecord_GXRec : frmDiseaseTrackBase
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private com.digitalwave.controls.ctlRichTextBox m_txtTemperature;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
		private PinkieControls.ButtonXP m_cmdOK;
		private PinkieControls.ButtonXP m_cmdCancel;
		private com.digitalwave.controls.ctlRichTextBox m_txtPulse;
		private com.digitalwave.controls.ctlRichTextBox m_txtRespiration;
		private com.digitalwave.controls.ctlRichTextBox m_txtBloodPressureS;
        private com.digitalwave.controls.ctlRichTextBox m_txtBloodPressureA;
		private clsEmployeeSignTool m_objSignTool;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private com.digitalwave.controls.ctlRichTextBox m_txtHeartRate;
        private PinkieControls.ButtonXP m_cmbsign;
//		private clsGeneralNurseRecordContent_GXDetail objCurrentDetail;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;
        private TextBox txtSign;
        private ctlRichTextBox m_txtCustom1;
        private Label m_lblCustomName1;
        private Label label11;
        private Label label12;
        private Label m_lblCustomName2;
        private ctlRichTextBox m_txtCustom2;
        //定义签名类
        private clsEmrSignToolCollection m_objSign;

		public frmGeneralNurseRecord_GXRec()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			
			this.Size = new System.Drawing.Size(516,216);
            m_dtpCreateDate.Value = DateTime.Parse(new clsPublicDomain().m_strGetServerTime());
			m_mthSetRichTextBoxAttribInControl(this);
            //m_objSignTool = new clsEmployeeSignTool(m_lsvEmployee);
            //m_objSignTool.m_mthAddControl(new Control[]{txtSign},false);
//			objCurrentDetail = null;
            //签名常用值
            m_objSign = new clsEmrSignToolCollection();

            //可以指定员工ID如
            m_objSign.m_mthBindEmployeeSign(m_cmbsign, txtSign, 2, true, clsEMRLogin.LoginInfo.m_strEmpID);

            
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

		public override int m_IntFormID
		{
			get
			{
				return 84;
			}
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_txtTemperature = new com.digitalwave.controls.ctlRichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.m_txtPulse = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtRespiration = new com.digitalwave.controls.ctlRichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.m_txtBloodPressureS = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtBloodPressureA = new com.digitalwave.controls.ctlRichTextBox();
            this.m_cmdOK = new PinkieControls.ButtonXP();
            this.m_cmdCancel = new PinkieControls.ButtonXP();
            this.m_txtHeartRate = new com.digitalwave.controls.ctlRichTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.m_cmbsign = new PinkieControls.ButtonXP();
            this.txtSign = new System.Windows.Forms.TextBox();
            this.m_txtCustom1 = new com.digitalwave.controls.ctlRichTextBox();
            this.m_lblCustomName1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.m_lblCustomName2 = new System.Windows.Forms.Label();
            this.m_txtCustom2 = new com.digitalwave.controls.ctlRichTextBox();
            this.m_pnlNewBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_trvCreateDate
            // 
            this.m_trvCreateDate.LineColor = System.Drawing.Color.Black;
            this.m_trvCreateDate.Location = new System.Drawing.Point(0, -136);
            this.m_trvCreateDate.Size = new System.Drawing.Size(212, 112);
            this.m_trvCreateDate.Visible = false;
            // 
            // lblCreateDateTitle
            // 
            this.lblCreateDateTitle.Location = new System.Drawing.Point(14, 16);
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.Location = new System.Drawing.Point(90, 14);
            this.m_dtpCreateDate.Size = new System.Drawing.Size(216, 22);
            this.m_dtpCreateDate.TabIndex = 80;
            // 
            // m_dtpGetDataTime
            // 
            this.m_dtpGetDataTime.Location = new System.Drawing.Point(0, -96);
            // 
            // m_lblGetDataTime
            // 
            this.m_lblGetDataTime.Location = new System.Drawing.Point(0, -96);
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(0, -240);
            this.lblSex.Size = new System.Drawing.Size(48, 43);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(0, -240);
            this.lblAge.Size = new System.Drawing.Size(52, 43);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(0, -232);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(0, -200);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(0, -232);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(0, -240);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(0, -240);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(32, -64);
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(0, -184);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(116, 128);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(0, -208);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(0, -240);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(0, -240);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(80, -176);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(0, -216);
            this.m_lsvPatientName.Size = new System.Drawing.Size(116, 128);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(0, -216);
            this.m_lsvBedNO.Size = new System.Drawing.Size(116, 128);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(80, -208);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(32, -96);
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(0, -200);
            this.m_cmdNewTemplate.Size = new System.Drawing.Size(84, 56);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.Location = new System.Drawing.Point(0, -240);
            this.m_cmdNext.Size = new System.Drawing.Size(24, 45);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(156, -240);
            this.m_cmdPre.Size = new System.Drawing.Size(24, 45);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(0, -232);
            this.m_lblForTitle.Size = new System.Drawing.Size(16, 47);
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(16, 33);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(0, -30);
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label1.Location = new System.Drawing.Point(16, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(478, 24);
            this.label1.TabIndex = 10000005;
            this.label1.Text = "T：℃、 P:次/分、 R:次/分、  HR:次/分、BP:mmHg";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label2.Location = new System.Drawing.Point(16, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 23);
            this.label2.TabIndex = 10000006;
            this.label2.Text = "体温";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label3.Location = new System.Drawing.Point(74, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 23);
            this.label3.TabIndex = 10000006;
            this.label3.Text = "脉搏";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label4.Location = new System.Drawing.Point(132, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 23);
            this.label4.TabIndex = 10000006;
            this.label4.Text = "呼吸";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label5.Location = new System.Drawing.Point(248, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 23);
            this.label5.TabIndex = 10000006;
            this.label5.Text = "血压";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtTemperature
            // 
            this.m_txtTemperature.AccessibleDescription = "体温";
            this.m_txtTemperature.BackColor = System.Drawing.Color.White;
            this.m_txtTemperature.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtTemperature.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtTemperature.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtTemperature.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtTemperature.Location = new System.Drawing.Point(18, 104);
            this.m_txtTemperature.m_BlnIgnoreUserInfo = false;
            this.m_txtTemperature.m_BlnPartControl = false;
            this.m_txtTemperature.m_BlnReadOnly = false;
            this.m_txtTemperature.m_BlnUnderLineDST = false;
            this.m_txtTemperature.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtTemperature.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtTemperature.m_IntCanModifyTime = 6;
            this.m_txtTemperature.m_IntPartControlLength = 0;
            this.m_txtTemperature.m_IntPartControlStartIndex = 0;
            this.m_txtTemperature.m_StrUserID = "";
            this.m_txtTemperature.m_StrUserName = "";
            this.m_txtTemperature.MaxLength = 8000;
            this.m_txtTemperature.Multiline = false;
            this.m_txtTemperature.Name = "m_txtTemperature";
            this.m_txtTemperature.Size = new System.Drawing.Size(56, 22);
            this.m_txtTemperature.TabIndex = 20;
            this.m_txtTemperature.Text = "";
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("宋体", 12F);
            this.label6.Location = new System.Drawing.Point(134, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 27);
            this.label6.TabIndex = 10000006;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("宋体", 12F);
            this.label7.Location = new System.Drawing.Point(16, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 27);
            this.label7.TabIndex = 10000006;
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("宋体", 12F);
            this.label8.Location = new System.Drawing.Point(74, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 27);
            this.label8.TabIndex = 10000006;
            // 
            // m_txtPulse
            // 
            this.m_txtPulse.AccessibleDescription = "脉搏";
            this.m_txtPulse.BackColor = System.Drawing.Color.White;
            this.m_txtPulse.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtPulse.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPulse.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtPulse.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPulse.Location = new System.Drawing.Point(76, 104);
            this.m_txtPulse.m_BlnIgnoreUserInfo = false;
            this.m_txtPulse.m_BlnPartControl = false;
            this.m_txtPulse.m_BlnReadOnly = false;
            this.m_txtPulse.m_BlnUnderLineDST = false;
            this.m_txtPulse.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPulse.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPulse.m_IntCanModifyTime = 6;
            this.m_txtPulse.m_IntPartControlLength = 0;
            this.m_txtPulse.m_IntPartControlStartIndex = 0;
            this.m_txtPulse.m_StrUserID = "";
            this.m_txtPulse.m_StrUserName = "";
            this.m_txtPulse.MaxLength = 8000;
            this.m_txtPulse.Multiline = false;
            this.m_txtPulse.Name = "m_txtPulse";
            this.m_txtPulse.Size = new System.Drawing.Size(56, 22);
            this.m_txtPulse.TabIndex = 30;
            this.m_txtPulse.Text = "";
            // 
            // m_txtRespiration
            // 
            this.m_txtRespiration.AccessibleDescription = "呼吸";
            this.m_txtRespiration.BackColor = System.Drawing.Color.White;
            this.m_txtRespiration.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtRespiration.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtRespiration.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtRespiration.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtRespiration.Location = new System.Drawing.Point(134, 104);
            this.m_txtRespiration.m_BlnIgnoreUserInfo = false;
            this.m_txtRespiration.m_BlnPartControl = false;
            this.m_txtRespiration.m_BlnReadOnly = false;
            this.m_txtRespiration.m_BlnUnderLineDST = false;
            this.m_txtRespiration.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtRespiration.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtRespiration.m_IntCanModifyTime = 6;
            this.m_txtRespiration.m_IntPartControlLength = 0;
            this.m_txtRespiration.m_IntPartControlStartIndex = 0;
            this.m_txtRespiration.m_StrUserID = "";
            this.m_txtRespiration.m_StrUserName = "";
            this.m_txtRespiration.MaxLength = 8000;
            this.m_txtRespiration.Multiline = false;
            this.m_txtRespiration.Name = "m_txtRespiration";
            this.m_txtRespiration.Size = new System.Drawing.Size(56, 22);
            this.m_txtRespiration.TabIndex = 40;
            this.m_txtRespiration.Text = "";
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("宋体", 16F);
            this.label9.Location = new System.Drawing.Point(248, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 27);
            this.label9.TabIndex = 10000006;
            this.label9.Text = "     /";
            // 
            // m_txtBloodPressureS
            // 
            this.m_txtBloodPressureS.AccessibleDescription = "舒张压";
            this.m_txtBloodPressureS.BackColor = System.Drawing.Color.White;
            this.m_txtBloodPressureS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtBloodPressureS.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBloodPressureS.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBloodPressureS.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBloodPressureS.Location = new System.Drawing.Point(250, 104);
            this.m_txtBloodPressureS.m_BlnIgnoreUserInfo = false;
            this.m_txtBloodPressureS.m_BlnPartControl = false;
            this.m_txtBloodPressureS.m_BlnReadOnly = false;
            this.m_txtBloodPressureS.m_BlnUnderLineDST = false;
            this.m_txtBloodPressureS.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBloodPressureS.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBloodPressureS.m_IntCanModifyTime = 6;
            this.m_txtBloodPressureS.m_IntPartControlLength = 0;
            this.m_txtBloodPressureS.m_IntPartControlStartIndex = 0;
            this.m_txtBloodPressureS.m_StrUserID = "";
            this.m_txtBloodPressureS.m_StrUserName = "";
            this.m_txtBloodPressureS.MaxLength = 8000;
            this.m_txtBloodPressureS.Multiline = false;
            this.m_txtBloodPressureS.Name = "m_txtBloodPressureS";
            this.m_txtBloodPressureS.Size = new System.Drawing.Size(56, 22);
            this.m_txtBloodPressureS.TabIndex = 50;
            this.m_txtBloodPressureS.Text = "";
            // 
            // m_txtBloodPressureA
            // 
            this.m_txtBloodPressureA.AccessibleDescription = "收缩压";
            this.m_txtBloodPressureA.BackColor = System.Drawing.Color.White;
            this.m_txtBloodPressureA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtBloodPressureA.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBloodPressureA.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBloodPressureA.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBloodPressureA.Location = new System.Drawing.Point(318, 104);
            this.m_txtBloodPressureA.m_BlnIgnoreUserInfo = false;
            this.m_txtBloodPressureA.m_BlnPartControl = false;
            this.m_txtBloodPressureA.m_BlnReadOnly = false;
            this.m_txtBloodPressureA.m_BlnUnderLineDST = false;
            this.m_txtBloodPressureA.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBloodPressureA.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBloodPressureA.m_IntCanModifyTime = 6;
            this.m_txtBloodPressureA.m_IntPartControlLength = 0;
            this.m_txtBloodPressureA.m_IntPartControlStartIndex = 0;
            this.m_txtBloodPressureA.m_StrUserID = "";
            this.m_txtBloodPressureA.m_StrUserName = "";
            this.m_txtBloodPressureA.MaxLength = 8000;
            this.m_txtBloodPressureA.Multiline = false;
            this.m_txtBloodPressureA.Name = "m_txtBloodPressureA";
            this.m_txtBloodPressureA.Size = new System.Drawing.Size(56, 22);
            this.m_txtBloodPressureA.TabIndex = 60;
            this.m_txtBloodPressureA.Text = "";
            // 
            // m_cmdOK
            // 
            this.m_cmdOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdOK.DefaultScheme = true;
            this.m_cmdOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdOK.Hint = "";
            this.m_cmdOK.Location = new System.Drawing.Point(343, 140);
            this.m_cmdOK.Name = "m_cmdOK";
            this.m_cmdOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdOK.Size = new System.Drawing.Size(64, 32);
            this.m_cmdOK.TabIndex = 80;
            this.m_cmdOK.Text = "确定";
            this.m_cmdOK.Click += new System.EventHandler(this.m_cmdOK_Click);
            // 
            // m_cmdCancel
            // 
            this.m_cmdCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdCancel.DefaultScheme = true;
            this.m_cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdCancel.Hint = "";
            this.m_cmdCancel.Location = new System.Drawing.Point(428, 140);
            this.m_cmdCancel.Name = "m_cmdCancel";
            this.m_cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCancel.Size = new System.Drawing.Size(64, 32);
            this.m_cmdCancel.TabIndex = 90;
            this.m_cmdCancel.Text = "取消";
            this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdCancel_Click);
            // 
            // m_txtHeartRate
            // 
            this.m_txtHeartRate.AccessibleDescription = "心率";
            this.m_txtHeartRate.BackColor = System.Drawing.Color.White;
            this.m_txtHeartRate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtHeartRate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtHeartRate.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtHeartRate.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtHeartRate.Location = new System.Drawing.Point(192, 104);
            this.m_txtHeartRate.m_BlnIgnoreUserInfo = false;
            this.m_txtHeartRate.m_BlnPartControl = false;
            this.m_txtHeartRate.m_BlnReadOnly = false;
            this.m_txtHeartRate.m_BlnUnderLineDST = false;
            this.m_txtHeartRate.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtHeartRate.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtHeartRate.m_IntCanModifyTime = 6;
            this.m_txtHeartRate.m_IntPartControlLength = 0;
            this.m_txtHeartRate.m_IntPartControlStartIndex = 0;
            this.m_txtHeartRate.m_StrUserID = "";
            this.m_txtHeartRate.m_StrUserName = "";
            this.m_txtHeartRate.MaxLength = 8000;
            this.m_txtHeartRate.Multiline = false;
            this.m_txtHeartRate.Name = "m_txtHeartRate";
            this.m_txtHeartRate.Size = new System.Drawing.Size(56, 22);
            this.m_txtHeartRate.TabIndex = 45;
            this.m_txtHeartRate.Text = "";
            // 
            // label13
            // 
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.label13.Location = new System.Drawing.Point(190, 79);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 23);
            this.label13.TabIndex = 10000024;
            this.label13.Text = "心率";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label14.Font = new System.Drawing.Font("宋体", 12F);
            this.label14.Location = new System.Drawing.Point(190, 100);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 27);
            this.label14.TabIndex = 10000023;
            // 
            // m_cmbsign
            // 
            this.m_cmbsign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmbsign.DefaultScheme = true;
            this.m_cmbsign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmbsign.Hint = "";
            this.m_cmbsign.Location = new System.Drawing.Point(16, 141);
            this.m_cmbsign.Name = "m_cmbsign";
            this.m_cmbsign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmbsign.Size = new System.Drawing.Size(64, 32);
            this.m_cmbsign.TabIndex = 10000025;
            this.m_cmbsign.Text = "签名";

            // 
            // txtSign
            // 
            this.txtSign.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSign.Enabled = false;
            this.txtSign.Location = new System.Drawing.Point(84, 150);
            this.txtSign.Name = "txtSign";
            this.txtSign.Size = new System.Drawing.Size(106, 23);
            this.txtSign.TabIndex = 10000026;
            // 
            // m_txtCustom1
            // 
            this.m_txtCustom1.AccessibleDescription = "自定义列1";
            this.m_txtCustom1.BackColor = System.Drawing.Color.White;
            this.m_txtCustom1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtCustom1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCustom1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtCustom1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCustom1.Location = new System.Drawing.Point(379, 104);
            this.m_txtCustom1.m_BlnIgnoreUserInfo = false;
            this.m_txtCustom1.m_BlnPartControl = false;
            this.m_txtCustom1.m_BlnReadOnly = false;
            this.m_txtCustom1.m_BlnUnderLineDST = false;
            this.m_txtCustom1.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtCustom1.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtCustom1.m_IntCanModifyTime = 6;
            this.m_txtCustom1.m_IntPartControlLength = 0;
            this.m_txtCustom1.m_IntPartControlStartIndex = 0;
            this.m_txtCustom1.m_StrUserID = "";
            this.m_txtCustom1.m_StrUserName = "";
            this.m_txtCustom1.MaxLength = 8000;
            this.m_txtCustom1.Multiline = false;
            this.m_txtCustom1.Name = "m_txtCustom1";
            this.m_txtCustom1.Size = new System.Drawing.Size(56, 22);
            this.m_txtCustom1.TabIndex = 63;
            this.m_txtCustom1.Text = "";
            // 
            // m_lblCustomName1
            // 
            this.m_lblCustomName1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lblCustomName1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_lblCustomName1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblCustomName1.Location = new System.Drawing.Point(375, 79);
            this.m_lblCustomName1.Name = "m_lblCustomName1";
            this.m_lblCustomName1.Size = new System.Drawing.Size(60, 23);
            this.m_lblCustomName1.TabIndex = 10000029;
            this.m_lblCustomName1.Text = "自定义列1";
            this.m_lblCustomName1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Font = new System.Drawing.Font("宋体", 12F);
            this.label11.Location = new System.Drawing.Point(375, 101);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 27);
            this.label11.TabIndex = 10000028;
            // 
            // label12
            // 
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label12.Font = new System.Drawing.Font("宋体", 12F);
            this.label12.Location = new System.Drawing.Point(434, 100);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 27);
            this.label12.TabIndex = 10000028;
            // 
            // m_lblCustomName2
            // 
            this.m_lblCustomName2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lblCustomName2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_lblCustomName2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblCustomName2.Location = new System.Drawing.Point(434, 79);
            this.m_lblCustomName2.Name = "m_lblCustomName2";
            this.m_lblCustomName2.Size = new System.Drawing.Size(60, 23);
            this.m_lblCustomName2.TabIndex = 10000029;
            this.m_lblCustomName2.Text = "自定义列2";
            this.m_lblCustomName2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtCustom2
            // 
            this.m_txtCustom2.AccessibleDescription = "自定义列2";
            this.m_txtCustom2.BackColor = System.Drawing.Color.White;
            this.m_txtCustom2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtCustom2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCustom2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtCustom2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCustom2.Location = new System.Drawing.Point(436, 104);
            this.m_txtCustom2.m_BlnIgnoreUserInfo = false;
            this.m_txtCustom2.m_BlnPartControl = false;
            this.m_txtCustom2.m_BlnReadOnly = false;
            this.m_txtCustom2.m_BlnUnderLineDST = false;
            this.m_txtCustom2.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtCustom2.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtCustom2.m_IntCanModifyTime = 6;
            this.m_txtCustom2.m_IntPartControlLength = 0;
            this.m_txtCustom2.m_IntPartControlStartIndex = 0;
            this.m_txtCustom2.m_StrUserID = "";
            this.m_txtCustom2.m_StrUserName = "";
            this.m_txtCustom2.MaxLength = 8000;
            this.m_txtCustom2.Multiline = false;
            this.m_txtCustom2.Name = "m_txtCustom2";
            this.m_txtCustom2.Size = new System.Drawing.Size(56, 22);
            this.m_txtCustom2.TabIndex = 65;
            this.m_txtCustom2.Text = "";
            // 
            // frmGeneralNurseRecord_GXRec
            // 
            this.ClientSize = new System.Drawing.Size(505, 201);
            this.Controls.Add(this.m_txtCustom2);
            this.Controls.Add(this.m_txtCustom1);
            this.Controls.Add(this.m_lblCustomName2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.m_lblCustomName1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtSign);
            this.Controls.Add(this.m_cmbsign);
            this.Controls.Add(this.m_txtHeartRate);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.m_cmdOK);
            this.Controls.Add(this.m_cmdCancel);
            this.Controls.Add(this.m_txtBloodPressureA);
            this.Controls.Add(this.m_txtBloodPressureS);
            this.Controls.Add(this.m_txtRespiration);
            this.Controls.Add(this.m_txtPulse);
            this.Controls.Add(this.m_txtTemperature);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Name = "frmGeneralNurseRecord_GXRec";
            this.Text = "一般患者护理记录";
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.m_lblGetDataTime, 0);
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
            this.Controls.SetChildIndex(this.m_txtTemperature, 0);
            this.Controls.SetChildIndex(this.m_txtPulse, 0);
            this.Controls.SetChildIndex(this.m_txtRespiration, 0);
            this.Controls.SetChildIndex(this.m_txtBloodPressureS, 0);
            this.Controls.SetChildIndex(this.m_txtBloodPressureA, 0);
            this.Controls.SetChildIndex(this.m_cmdCancel, 0);
            this.Controls.SetChildIndex(this.m_cmdOK, 0);
            this.Controls.SetChildIndex(this.m_dtpCreateDate, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.m_txtHeartRate, 0);
            this.Controls.SetChildIndex(this.m_cmbsign, 0);
            this.Controls.SetChildIndex(this.txtSign, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.m_lblCustomName1, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.m_lblCustomName2, 0);
            this.Controls.SetChildIndex(this.m_txtCustom1, 0);
            this.Controls.SetChildIndex(this.m_txtCustom2, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmGeneralNurseRecord_GXRec_Load(object sender, System.EventArgs e)
		{
			m_txtTemperature.Focus();
		}

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

			this.m_txtTemperature.m_mthClearText();
			this.m_txtPulse.m_mthClearText();
			this.m_txtRespiration.m_mthClearText();
			this.m_txtBloodPressureS.m_mthClearText();
			this.m_txtBloodPressureA.m_mthClearText();
			this.m_txtHeartRate.m_mthClearText();
            this.m_txtCustom1.m_mthClearText();
            this.m_txtCustom2.m_mthClearText();
            this.m_lblCustomName1.Text = "";
            this.m_lblCustomName2.Text = "";
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
			clsGeneralNurseRecordContent_GX objContent=(clsGeneralNurseRecordContent_GX )p_objContent;

			#region 处理同一窗体内的病情记录
//			clsGeneralNurseRecordContent_GXDetail objDetail = null;
//			clsGeneralNurseRecord_GXService objserv=new clsGeneralNurseRecord_GXService();
//			lngRes=objserv.m_lngGetRecordContent(objContent.m_strInPatientID,objContent.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"),
//				objContent.m_dtmRECORDDATE.ToString("yyyy-MM-dd HH:mm:ss"),out objDetail);
//
//			if(objDetail != null)
//			{
//				m_mthSetWholeFormSize(true);
//				m_txtDetailContent.m_mthSetNewText(objDetail.m_strRECORDCONTENTAll,objDetail.m_strRECORDCONTENTXML);
//	
//				clsEmployee objEmployee=new clsEmployee(objDetail.m_strCREATERECORDUSERID);
//				if(objEmployee !=null)
//				{
//					m_txtDetailSign.Text=objEmployee.m_StrLastName;
//					m_txtDetailSign.Tag=objEmployee;
//				}
//				this.m_txtDetailSign.Enabled = false;
//				objCurrentDetail = objDetail;
//			}
			#endregion

			//把表单值赋值到界面，由子窗体重载实现			
            //this.m_mthClearRecordInfo();

			this.m_txtTemperature.m_mthSetNewText(objContent.m_strTEMPERATUREAll,objContent.m_strTEMPERATUREXML);
			this.m_txtPulse.m_mthSetNewText(objContent.m_strPULSEAll,objContent.m_strPULSEXML);
			this.m_txtRespiration.m_mthSetNewText(objContent.m_strRESPIRATIONAll,objContent.m_strRESPIRATIONXML);
			this.m_txtBloodPressureA.m_mthSetNewText(objContent.m_strBLOODPRESSUREAAll,objContent.m_strBLOODPRESSUREAXML);
			this.m_txtBloodPressureS.m_mthSetNewText(objContent.m_strBLOODPRESSURESAll,objContent.m_strBLOODPRESSURESXML);
			this.m_txtHeartRate.m_mthSetNewText(objContent.m_strHEARTRATE,objContent.m_strHEARTRATEXML);
            this.m_txtCustom1.m_mthSetNewText(objContent.m_strCUSTOM1,objContent.m_strCUSTOM1XML);
            this.m_txtCustom2.m_mthSetNewText(objContent.m_strCUSTOM2,objContent.m_strCUSTOM2XML);

            if (objContent.m_strCUSTOM1NAME != null)
            {
                m_lblCustomName1.Text = objContent.m_strCUSTOM1NAME.Replace("\r\n", "");
            }
            if (objContent.m_strCUSTOM2NAME != null)
            {
                m_lblCustomName2.Text = objContent.m_strCUSTOM2NAME.Replace("\r\n", "");
            }
            m_mthAddSignToTextBoxByEmpNo(new TextBoxBase[] { txtSign, }, new string[] { objContent.m_strCreateUserID }, new bool[] { false });
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
		}

		protected override void m_mthSetDeletedGUIFromContent(iCareData.clsTrackRecordContent p_objContent)
		{
			clsGeneralNurseRecordContent_GX objContent=(clsGeneralNurseRecordContent_GX )p_objContent;

			#region 处理同一窗体内的病情记录
//			clsGeneralNurseRecordContent_GXDetail objDetail= null;
//			clsGeneralNurseRecord_GXService objserv=new clsGeneralNurseRecord_GXService();
//			lngRes=objserv.m_lngGetDelRecordContentWithInpatient(objContent.m_strInPatientID,objContent.m_dtmInPatientDate("yyyy-MM-dd HH:mm:ss"),
//				objContent.m_dtmRECORDDATE.ToString("yyyy-MM-dd HH:mm:ss"), out objDetail);
//
//			if(objDetail != null)
//			{
//				m_mthSetWholeFormSize(true);
//				m_txtDetailContent.m_mthSetNewText(objDetail.m_strRECORDCONTENTAll,objDetail.m_strRECORDCONTENTXML);	
//				clsEmployee objEmployee=new clsEmployee(objDetail.m_strCREATERECORDUSERID);
//				if(objEmployee !=null)
//				{
//					m_txtDetailSign.Text=objEmployee.m_StrLastName;
//					m_txtDetailSign.Tag=objEmployee;
//				}
//					
//				this.m_txtDetailSign.Enabled = false;
//				objCurrentDetail = objDetail;
//			}
			#endregion

			//把表单值赋值到界面，由子窗体重载实现			

			this.m_mthClearRecordInfo();		
			m_txtTemperature.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strTEMPERATUREAll ,objContent.m_strTEMPERATUREXML);

			this.m_txtPulse.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strPULSEAll,objContent.m_strPULSEXML );
			this.m_txtRespiration.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strRESPIRATIONAll ,objContent.m_strRESPIRATIONXML  );
			this.m_txtBloodPressureA.Text =ctlRichTextBox.s_strGetRightText(objContent.m_strBLOODPRESSUREAAll ,objContent.m_strBLOODPRESSUREAXML);
			this.m_txtBloodPressureS.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strBLOODPRESSURESAll ,objContent.m_strBLOODPRESSURESXML );
			this.m_txtHeartRate.Text = ctlRichTextBox.s_strGetRightText(objContent.m_strHEARTRATE, objContent.m_strHEARTRATEXML);

            this.m_txtCustom1.Text = ctlRichTextBox.s_strGetRightText(objContent.m_strCUSTOM1, objContent.m_strCUSTOM1XML);
            this.m_txtCustom2.Text = ctlRichTextBox.s_strGetRightText(objContent.m_strCUSTOM2, objContent.m_strCUSTOM2XML);

            if (objContent.m_strCUSTOM1NAME != null)
            {
                m_lblCustomName1.Text = objContent.m_strCUSTOM1NAME.Replace("\r\n", "");
            }
            if (objContent.m_strCUSTOM2NAME != null)
            {
                m_lblCustomName2.Text = objContent.m_strCUSTOM2NAME.Replace("\r\n", "");
            }
            m_mthAddSignToTextBoxByEmpNo(new TextBoxBase[] { txtSign, }, new string[] { objContent.m_strCreateUserID }, new bool[] { false });
            //根据工号获取签名信息
            //出于兼容考虑，过渡使用 tfzhang 2006-03-12
            //com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
            //clsEmrEmployeeBase_VO objSign = new clsEmrEmployeeBase_VO();
            //objEmployeeSign.m_lngGetEmpByNO(objContent.m_strCreateUserID.Trim(), out objSign);
            //if (objSign!=null)
            //{
            //    txtSign.Text = objSign.m_strLASTNAME_VCHR;
            //    txtSign.Tag = objSign;
            //}
            //this.txtSign.Enabled = false;
            //this.m_dtpCreateDate.Enabled = false;
		}

		protected override iCareData.clsTrackRecordContent m_objGetContentFromGUI()
		{
			
			//界面参数校验
			if(m_objCurrentPatient==null)// || this.txtInPatientID.Text!=this.m_objCurrentPatient.m_StrHISInPatientID || txtInPatientID.Text=="")				
				return null;

			#region 处理同一个窗体内的病情记录

			#endregion

			//从界面获取表单值		
			clsGeneralNurseRecordContent_GX objContent=new clsGeneralNurseRecordContent_GX ();
			try
			{
				objContent.m_dtmCreateDate =DateTime.Now ;

				objContent.m_strTEMPERATURE_RIGHT=this.m_txtTemperature.m_strGetRightText();
				objContent.m_strTEMPERATUREAll=this.m_txtTemperature.Text;
				objContent.m_strTEMPERATUREXML=this.m_txtTemperature.m_strGetXmlText();
		
				objContent.m_strPULSE_RIGHT=this.m_txtPulse.m_strGetRightText();
				objContent.m_strPULSEAll=this.m_txtPulse.Text;
				objContent.m_strPULSEXML=this.m_txtPulse.m_strGetXmlText();

				objContent.m_strRESPIRATION_RIGHT=this.m_txtRespiration.m_strGetRightText();
				objContent.m_strRESPIRATIONAll=this.m_txtRespiration.Text;
				objContent.m_strRESPIRATIONXML=this.m_txtRespiration.m_strGetXmlText();
            			
				objContent.m_strBLOODPRESSUREA_RIGHT=this.m_txtBloodPressureA.m_strGetRightText();
				objContent.m_strBLOODPRESSUREAAll=this.m_txtBloodPressureA.Text;
				objContent.m_strBLOODPRESSUREAXML=this.m_txtBloodPressureA.m_strGetXmlText();

				objContent.m_strBLOODPRESSURES_RIGHT=this.m_txtBloodPressureS.m_strGetRightText();
				objContent.m_strBLOODPRESSURESAll=this.m_txtBloodPressureS.Text ;
				objContent.m_strBLOODPRESSURESXML=this.m_txtBloodPressureS.m_strGetXmlText();

				objContent.m_strHEARTRATE_RIGHT = this.m_txtHeartRate.m_strGetRightText();
				objContent.m_strHEARTRATE = this.m_txtHeartRate.Text;
				objContent.m_strHEARTRATEXML = this.m_txtHeartRate.m_strGetXmlText();

				objContent.m_intClass = m_intGetClass(m_dtpCreateDate.Value);
                objContent.m_strCreateUserID = ((clsEmrEmployeeBase_VO)txtSign.Tag).m_strEMPNO_CHR;
				objContent.m_dtmModifyDate = DateTime.Now;
                objContent.m_strModifyUserID = ((clsEmrEmployeeBase_VO)txtSign.Tag).m_strEMPNO_CHR;
				objContent.m_dtmRECORDDATE = m_dtpCreateDate.Value;

                objContent.m_strCUSTOM1 = this.m_txtCustom1.Text;
                objContent.m_strCUSTOM1_RIGHT = this.m_txtCustom1.m_strGetRightText();
                objContent.m_strCUSTOM1XML = this.m_txtCustom1.m_strGetXmlText();
                objContent.m_strCUSTOM2 = this.m_txtCustom2.Text;
                objContent.m_strCUSTOM2_RIGHT = this.m_txtCustom2.m_strGetRightText();
                objContent.m_strCUSTOM2XML = this.m_txtCustom2.m_strGetXmlText();
                if (m_lblCustomName1.Text != "自定义列1")
                {
                    objContent.m_strCUSTOM1NAME = m_strFormatCustomName(m_lblCustomName1.Text);
                }
                else
                    objContent.m_strCUSTOM1NAME = "";
                if (m_lblCustomName2.Text != "自定义列2")
                {
                    objContent.m_strCUSTOM2NAME = m_strFormatCustomName(m_lblCustomName2.Text);
                }
                else
                {
                    objContent.m_strCUSTOM2NAME = "";
                }
                //获取签名
                strUserIDList = "";
                strUserNameList = "";
                m_mthGetSignArr(new Control[] { txtSign }, ref objContent.objSignerArr, ref strUserIDList, ref strUserNameList);
                //objContent.objSignerArr = new clsEmrSigns_VO[1];
                //objContent.objSignerArr[0] = new clsEmrSigns_VO();
                //objContent.objSignerArr[0].objEmployee = new clsEmrEmployeeBase_VO();
                //objContent.objSignerArr[0].objEmployee = (clsEmrEmployeeBase_VO)(txtSign.Tag);
                //objContent.objSignerArr[0].controlName = "txtSign";
                //objContent.objSignerArr[0].m_strFORMID_VCHR = "frmGeneralNurseRecord_GXRec";//注意大小写
                //objContent.objSignerArr[0].m_strREGISTERID_CHR = com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;

			}
		
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			return(objContent );		
		}

        private string m_strFormatCustomName(string p_strText)
        {
            if (p_strText == null)
                return "";

            string strRe = "";
            int intColumnNameLength = p_strText.Length;
            for (int i = 0; i < intColumnNameLength; i++)
            {
                if (intColumnNameLength > 5)//字数大于5个，则直接从最顶部开始显示
                {
                    if (i == 0)
                        strRe += p_strText[i].ToString();
                    else
                        strRe += "\r\n" + p_strText[i].ToString();
                }
                else
                    strRe += "\r\n" + p_strText[i].ToString();
            }
            return strRe;
        }

		protected override iCare.clsDiseaseTrackDomain m_objGetDiseaseTrackDomain()
		{
			//获取护理记录的领域层实例，由子窗体重载实现
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.GeneralNurseRecord_GX);					
		}

		/// <summary>
		/// 把选择时间记录内容重新整理为完全正确的内容。
		/// </summary>
		/// <param name="p_objRecordContent"></param>
		protected override void m_mthReAddNewRecord(clsTrackRecordContent p_objRecordContent)
		{
			//把选择时间记录内容重新整理为完全正确的内容，由子窗体重载实现。
			clsGeneralNurseRecordContent_GX objContent=(clsGeneralNurseRecordContent_GX)p_objRecordContent;
		}

		public override string m_strReloadFormTitle()
		{
			//由子窗体重载实现

			return	"一般患者护理记录";
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

		#region Jump Control
		protected override void m_mthInitJump(clsJumpControl p_objJump)
		{
			p_objJump=new clsJumpControl(this,
				new Control[]{m_txtTemperature,m_txtPulse,m_txtRespiration,m_txtHeartRate,m_txtBloodPressureS,
								 m_txtBloodPressureA,m_txtCustom1,m_txtCustom2,txtSign},Keys.Enter);
		}
		#endregion

		/// <summary>
		/// 获取班次
		/// 广西-交班时间8:00-14:30,14:31-18:00,18:01-次日2:00,次日2:01-7:59
		/// </summary>
		/// <param name="dtmRecordDate"></param>
		/// <returns></returns>
		private int m_intGetClass(DateTime dtmRecordDate)
		{
			string strDate = dtmRecordDate.Year.ToString("0000")+dtmRecordDate.Month.ToString("00")+dtmRecordDate.Day.ToString("00");
			string strYesterday = dtmRecordDate.Year.ToString()+dtmRecordDate.Month.ToString()+dtmRecordDate.AddDays(-1).Day.ToString();
			DateTime dtClass= DateTime.Parse(dtmRecordDate.ToString("yyyy-MM-dd HH:mm:00"));
			DateTime dtDt0 = dtmRecordDate.Date;
			DateTime dt1=dtDt0.AddHours(2).AddMinutes(1);
			DateTime dt2=dtDt0.AddHours(8);
			DateTime dt3=dtDt0.AddHours(14).AddMinutes(31);
			DateTime dt4=dtDt0.AddHours(18).AddMinutes(1);
			DateTime dt5=dtDt0.AddHours(26).AddMinutes(1);

			if(dtmRecordDate >= dt1 && dtmRecordDate < dt2)
				return Convert.ToInt32(strDate + "0");
			else if(dtmRecordDate >= dt2 && dtmRecordDate < dt3)
				return Convert.ToInt32(strDate + "1");
			else if(dtmRecordDate >= dt3 && dtmRecordDate < dt4)
				return Convert.ToInt32(strDate + "2");
			else if(dtmRecordDate >= dt4 && dtmRecordDate < dt5)
				return Convert.ToInt32(strDate + "3");
			else if(dtmRecordDate < dt1)
				return Convert.ToInt32(strYesterday + "3");
			return 0;
		}

        

//		private void m_cmdWriteDetail_Click(object sender, System.EventArgs e)
//		{
//			if(this.Size.Height > 216)
//			{
//				m_cmdWriteDetail.Text = "取消病情记录↑";
//				m_mthSetWholeFormSize(false);
//				m_txtDetailContent.m_mthClearText();
//			}
//			else
//			{
//				m_cmdWriteDetail.Text = "书写病情记录↓";
//				m_mthSetWholeFormSize(true);
//				m_txtDetailContent.m_mthInsertText("    ",0);
//			}
//		}
//
//		private void m_mthSetWholeFormSize(bool p_blnIsShowWhole)
//		{
//			if(p_blnIsShowWhole)
//			{
//				this.Size = new System.Drawing.Size(460,368);
//				this.m_cmdOK.Location = new System.Drawing.Point(280, 296);
//				this.m_cmdCancel.Location = new System.Drawing.Point(360, 296);
//				this.m_cmdWriteDetail.Location = new System.Drawing.Point(40, 296);
//				m_lblDetail.Visible = true;
//				m_txtDetailContent.Visible = true;
//				lblEmployeeSign.Visible = true;
//				m_txtDetailSign.Visible = true;
//			}
//			else
//			{
//				this.Size = new System.Drawing.Size(460,216);
//				this.m_cmdOK.Location = new System.Drawing.Point(280, 144);
//				this.m_cmdCancel.Location = new System.Drawing.Point(360, 144);
//				this.m_cmdWriteDetail.Location = new System.Drawing.Point(40, 144);
//				m_lblDetail.Visible = false;
//				m_txtDetailContent.Visible = false;
//				lblEmployeeSign.Visible = false;
//				m_txtDetailSign.Visible = false;
//			}
//		}
	}
}
