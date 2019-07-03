using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using com.digitalwave.Utility .Controls ;
using System.Xml;
using System.IO;
using System.Text;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using iCareData;
using com.digitalwave.emr.BEDExplorer;
using com.digitalwave.Emr.Signature_gui;

namespace iCare
{
	public class frmSPECT : iCare.frmHRPBaseForm,PublicFunction//System.Windows.Forms.Form //
	{
		#region Define
		private System.Windows.Forms.CheckBox chkHypothyroidDisply;
		private System.Windows.Forms.CheckBox chkHypothyroidKnubDisply;
		private System.Windows.Forms.CheckBox chkKidneyDisply;
		private System.Windows.Forms.CheckBox chkHypothyroidCancer;
		private System.Windows.Forms.CheckBox chkhypothyroidside;
		private System.Windows.Forms.CheckBox chkPneumonicdAerate;
		private System.Windows.Forms.CheckBox chkPneumonicdBlood;
		private System.Windows.Forms.CheckBox chkPneumonicdknub;
		private System.Windows.Forms.CheckBox chkCourage;
		private System.Windows.Forms.CheckBox chkCouragePool;
		private System.Windows.Forms.CheckBox chkCourageFaultage;
		private System.Windows.Forms.CheckBox chkPulse;
		private System.Windows.Forms.CheckBox chkMeikl;
		private System.Windows.Forms.CheckBox chkEsophagus;
		private System.Windows.Forms.CheckBox chkEnteron;
		private System.Windows.Forms.CheckBox chkBody;
		private System.Windows.Forms.CheckBox chkBone;
		private System.Windows.Forms.CheckBox chkBoneTr;
		private System.Windows.Forms.CheckBox chkKidneyDin;
		private System.Windows.Forms.CheckBox chkKidneyStr;
		private System.Windows.Forms.CheckBox chkKidneyBall;
		private System.Windows.Forms.CheckBox chkKidneyBlood;
		private System.Windows.Forms.CheckBox chkBladder;
		private System.Windows.Forms.CheckBox chkBloodPool;
		private System.Windows.Forms.CheckBox chkHeartBlood;
		private System.Windows.Forms.CheckBox chkOverbody;
		private System.Windows.Forms.CheckBox chkOvum;
		private System.Windows.Forms.CheckBox chkBreastCancer;
		private System.Windows.Forms.CheckBox chkBrainBlood;
		private System.Windows.Forms.CheckBox chkBrainCancer;
		private System.Windows.Forms.CheckBox chkSpleen;
		private System.Windows.Forms.CheckBox chkLymph;
		private System.Windows.Forms.CheckBox chkDepCancer;
		private System.Windows.Forms.CheckBox chkOverCancer;
		private System.Windows.Forms.CheckBox chkMetabolize;
		private System.Windows.Forms.CheckBox chkBrainMetabolize;
		private System.Windows.Forms.Label lblNerve;
		private System.Windows.Forms.Label lblHistory;
		private System.Windows.Forms.Label lblCheckLab;
		private System.Windows.Forms.Label lblDisgonse;
		private System.Windows.Forms.Label lblAddress;
		private System.Windows.Forms.Label lblAddressContent;
		private System.Windows.Forms.Label lblTel;
		private System.Windows.Forms.Label lblTelContent;
		private System.Windows.Forms.Label lblPayment;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtCheckNO;
		private System.Windows.Forms.Label lblIncretionSystem;
		private System.Windows.Forms.Label lblBreathSystem;
		private System.Windows.Forms.Label lblDigest;
		private System.Windows.Forms.Label lblCallousSystem;
		private System.Windows.Forms.Label lblBone;
		private System.Windows.Forms.CheckBox chkDBody;
		private System.Windows.Forms.Label lblBlood;
		private System.Windows.Forms.Label lblProcreate;
		private System.Windows.Forms.Label lblPET;
		private System.Windows.Forms.CheckBox chkPaymentSelf;
		private System.Windows.Forms.CheckBox chkPaymentPulbic;
		private System.Windows.Forms.CheckBox chkPaymentCompany;
		private System.Windows.Forms.Label lblRecordTimeTitle;
		private com.digitalwave.Utility.Controls.ctlTimePicker dtpApplyTime;
		private System.Windows.Forms.TreeView trvTime;
		private System.Windows.Forms.Label lblCreateUser;
		protected System.Windows.Forms.RichTextBox txtHistory;
		protected System.Windows.Forms.RichTextBox txtCheckLab;
		protected System.Windows.Forms.RichTextBox txtDisgonse;
		protected System.Windows.Forms.RichTextBox txtTell;
        private System.Windows.Forms.Label lblEmployeeSign;
		private System.ComponentModel.IContainer components = null;
		#endregion
		private PinkieControls.ButtonXP m_cmdSign;

		private clsEmployeeSignTool m_objSignTool;
		private System.Windows.Forms.Label lblOther;
		private System.Windows.Forms.CheckBox chkTear;
		private System.Windows.Forms.CheckBox chkNose;
		private System.Windows.Forms.CheckBox chkTell;
        private System.Windows.Forms.CheckBox chkHeart;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private Crownwood.Magic.Controls.TabControl tabControl2;
		private System.Windows.Forms.ImageList imageList1;
		private Crownwood.Magic.Controls.TabPage tabPage3;
		private Crownwood.Magic.Controls.TabPage tabPage4;
        private Panel panel3;
        private TextBox m_txtSign;
        //定义签名类
        private clsEmrSignToolCollection m_objSign;
        private com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();

		public frmSPECT()
		{
			InitializeComponent();

            //m_objSignTool = new clsEmployeeSignTool(m_lsvEmployee);
            //m_objSignTool.m_mthAddControl(m_txtSign);

            //m_objBorderTool = new clsBorderTool(Color.White);
            //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{	this.trvTime
            //                                                                 ,this.txtHistory
            //                                                                 ,txtCheckLab
            //                                                                 ,txtDisgonse
            //                                                                 ,txtTell,this.txtCheckNO});	
        
			m_objDomain=new clsSPECTCheckOrderDomain(); 

			m_dtsRept = m_dtsInitdtsSPECTCheckDataSet();
			//			m_rpdOrderRept = new ReportDocument();
			//			m_rpdOrderRept.Load(m_strTemplatePath+"rptSPECTCheckReport.rpt");


            //签名常用值
            m_objSign = new clsEmrSignToolCollection();
            m_objSign.m_mthBindEmployeeSign(m_cmdSign, m_txtSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
		}

		private clsInPatientCaseHisoryDefaultDomain m_objInPaitentCaseDefault=new clsInPatientCaseHisoryDefaultDomain();
				
        //private com.digitalwave.Utility.Controls.clsBorderTool  m_objBorderTool;
		private clsSPECTCheckOrderDomain m_objDomain;

		private DataSet m_dtsRept;

		private bool blnCanSearch=true; 

		private bool blnCanDelete=true;              //是否可以执行删除操作

		/* 当手动清空时两个全部设为null
		 * 删除时m_objSpect设为null
		 * 点树的根结点时m_objSpect设为null
		 * 选择病人时m_objCurrentPatient赋值，选择树叶子时和新添加纪录时m_objSpect赋值
		 * */
		private clsSPECTCheckContent m_objSPECT=null; //保存当前的申请单
		private clsPatient m_objCurrentPatient=null;  //保存当前的病人

		/// <summary>
		/// 报告单的报表类
		/// </summary>
		private ReportDocument m_rpdOrderRept;
		/// <summary>
		/// 释放资源
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSPECT));
            this.lblIncretionSystem = new System.Windows.Forms.Label();
            this.lblBreathSystem = new System.Windows.Forms.Label();
            this.chkHypothyroidDisply = new System.Windows.Forms.CheckBox();
            this.chkHypothyroidKnubDisply = new System.Windows.Forms.CheckBox();
            this.chkKidneyDisply = new System.Windows.Forms.CheckBox();
            this.chkHypothyroidCancer = new System.Windows.Forms.CheckBox();
            this.chkhypothyroidside = new System.Windows.Forms.CheckBox();
            this.chkPneumonicdAerate = new System.Windows.Forms.CheckBox();
            this.chkPneumonicdBlood = new System.Windows.Forms.CheckBox();
            this.chkPneumonicdknub = new System.Windows.Forms.CheckBox();
            this.lblDigest = new System.Windows.Forms.Label();
            this.chkCourage = new System.Windows.Forms.CheckBox();
            this.chkCouragePool = new System.Windows.Forms.CheckBox();
            this.chkCourageFaultage = new System.Windows.Forms.CheckBox();
            this.chkPulse = new System.Windows.Forms.CheckBox();
            this.chkMeikl = new System.Windows.Forms.CheckBox();
            this.chkEsophagus = new System.Windows.Forms.CheckBox();
            this.chkEnteron = new System.Windows.Forms.CheckBox();
            this.lblCallousSystem = new System.Windows.Forms.Label();
            this.lblBone = new System.Windows.Forms.Label();
            this.chkBody = new System.Windows.Forms.CheckBox();
            this.chkBone = new System.Windows.Forms.CheckBox();
            this.chkBoneTr = new System.Windows.Forms.CheckBox();
            this.chkHeartBlood = new System.Windows.Forms.CheckBox();
            this.chkDBody = new System.Windows.Forms.CheckBox();
            this.lblBlood = new System.Windows.Forms.Label();
            this.chkOverbody = new System.Windows.Forms.CheckBox();
            this.chkSpleen = new System.Windows.Forms.CheckBox();
            this.chkLymph = new System.Windows.Forms.CheckBox();
            this.lblProcreate = new System.Windows.Forms.Label();
            this.chkKidneyDin = new System.Windows.Forms.CheckBox();
            this.chkKidneyStr = new System.Windows.Forms.CheckBox();
            this.chkKidneyBall = new System.Windows.Forms.CheckBox();
            this.chkKidneyBlood = new System.Windows.Forms.CheckBox();
            this.chkBladder = new System.Windows.Forms.CheckBox();
            this.chkBloodPool = new System.Windows.Forms.CheckBox();
            this.chkOvum = new System.Windows.Forms.CheckBox();
            this.chkBreastCancer = new System.Windows.Forms.CheckBox();
            this.lblNerve = new System.Windows.Forms.Label();
            this.chkBrainBlood = new System.Windows.Forms.CheckBox();
            this.chkBrainCancer = new System.Windows.Forms.CheckBox();
            this.lblPET = new System.Windows.Forms.Label();
            this.chkDepCancer = new System.Windows.Forms.CheckBox();
            this.chkOverCancer = new System.Windows.Forms.CheckBox();
            this.chkMetabolize = new System.Windows.Forms.CheckBox();
            this.chkBrainMetabolize = new System.Windows.Forms.CheckBox();
            this.lblHistory = new System.Windows.Forms.Label();
            this.lblCheckLab = new System.Windows.Forms.Label();
            this.lblDisgonse = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblAddressContent = new System.Windows.Forms.Label();
            this.lblTel = new System.Windows.Forms.Label();
            this.lblTelContent = new System.Windows.Forms.Label();
            this.lblPayment = new System.Windows.Forms.Label();
            this.chkPaymentSelf = new System.Windows.Forms.CheckBox();
            this.chkPaymentPulbic = new System.Windows.Forms.CheckBox();
            this.chkPaymentCompany = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCheckNO = new System.Windows.Forms.TextBox();
            this.lblRecordTimeTitle = new System.Windows.Forms.Label();
            this.dtpApplyTime = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.trvTime = new System.Windows.Forms.TreeView();
            this.lblCreateUser = new System.Windows.Forms.Label();
            this.txtHistory = new System.Windows.Forms.RichTextBox();
            this.txtCheckLab = new System.Windows.Forms.RichTextBox();
            this.txtDisgonse = new System.Windows.Forms.RichTextBox();
            this.txtTell = new System.Windows.Forms.RichTextBox();
            this.lblEmployeeSign = new System.Windows.Forms.Label();
            this.m_cmdSign = new PinkieControls.ButtonXP();
            this.lblOther = new System.Windows.Forms.Label();
            this.chkTear = new System.Windows.Forms.CheckBox();
            this.chkNose = new System.Windows.Forms.CheckBox();
            this.chkTell = new System.Windows.Forms.CheckBox();
            this.chkHeart = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl2 = new Crownwood.Magic.Controls.TabControl();
            this.tabPage3 = new Crownwood.Magic.Controls.TabPage();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabPage4 = new Crownwood.Magic.Controls.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_txtSign = new System.Windows.Forms.TextBox();
            this.m_pnlNewBase.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(187, 192);
            this.lblSex.Size = new System.Drawing.Size(24, 19);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(193, 223);
            this.lblAge.Size = new System.Drawing.Size(28, 19);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(176, 197);
            this.lblBedNoTitle.Size = new System.Drawing.Size(56, 14);
            this.lblBedNoTitle.Text = "床  号:";
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(157, 198);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(157, 198);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(176, 192);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(190, 201);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(157, 215);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(160, 185);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(76, 104);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(176, 200);
            this.txtInPatientID.Size = new System.Drawing.Size(68, 23);
            this.txtInPatientID.TabIndex = 3;
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(152, 194);
            this.m_txtPatientName.Size = new System.Drawing.Size(84, 23);
            this.m_txtPatientName.TabIndex = 2;
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(143, 221);
            this.m_txtBedNO.Size = new System.Drawing.Size(44, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(138, 215);
            this.m_cboArea.Size = new System.Drawing.Size(124, 23);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(156, 185);
            this.m_lsvPatientName.Size = new System.Drawing.Size(88, 104);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(160, 185);
            this.m_lsvBedNO.Size = new System.Drawing.Size(72, 104);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(138, 215);
            this.m_cboDept.Size = new System.Drawing.Size(124, 23);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(157, 233);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(152, 228);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.m_cmdNext.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdNext.Location = new System.Drawing.Point(171, 194);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdPre.Location = new System.Drawing.Point(138, 246);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(504, -151);
            this.m_lblForTitle.Size = new System.Drawing.Size(16, 34);
            this.m_lblForTitle.Text = "SPECT 检查申请单";
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(291, 197);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(723, 37);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Controls.Add(this.lblTelContent);
            this.m_pnlNewBase.Controls.Add(this.lblTel);
            this.m_pnlNewBase.Location = new System.Drawing.Point(5, 6);
            this.m_pnlNewBase.Size = new System.Drawing.Size(790, 85);
            this.m_pnlNewBase.Visible = true;
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_ctlPatientInfo, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.lblTel, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.lblTelContent, 0);
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ctlPatientInfo.Dock = System.Windows.Forms.DockStyle.None;
            this.m_ctlPatientInfo.Location = new System.Drawing.Point(193, 29);
            this.m_ctlPatientInfo.m_BlnIsShowAddres = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(596, 53);
            // 
            // lblIncretionSystem
            // 
            this.lblIncretionSystem.AllowDrop = true;
            this.lblIncretionSystem.AutoSize = true;
            this.lblIncretionSystem.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblIncretionSystem.ForeColor = System.Drawing.Color.Black;
            this.lblIncretionSystem.Location = new System.Drawing.Point(12, 20);
            this.lblIncretionSystem.Name = "lblIncretionSystem";
            this.lblIncretionSystem.Size = new System.Drawing.Size(98, 14);
            this.lblIncretionSystem.TabIndex = 501;
            this.lblIncretionSystem.Text = "[内分泌系统]";
            // 
            // lblBreathSystem
            // 
            this.lblBreathSystem.AutoSize = true;
            this.lblBreathSystem.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBreathSystem.ForeColor = System.Drawing.Color.Black;
            this.lblBreathSystem.Location = new System.Drawing.Point(256, 20);
            this.lblBreathSystem.Name = "lblBreathSystem";
            this.lblBreathSystem.Size = new System.Drawing.Size(83, 14);
            this.lblBreathSystem.TabIndex = 502;
            this.lblBreathSystem.Text = "[呼吸系统]";
            // 
            // chkHypothyroidDisply
            // 
            this.chkHypothyroidDisply.AllowDrop = true;
            this.chkHypothyroidDisply.ForeColor = System.Drawing.Color.Black;
            this.chkHypothyroidDisply.Location = new System.Drawing.Point(12, 40);
            this.chkHypothyroidDisply.Name = "chkHypothyroidDisply";
            this.chkHypothyroidDisply.Size = new System.Drawing.Size(96, 24);
            this.chkHypothyroidDisply.TabIndex = 9;
            this.chkHypothyroidDisply.Text = "甲状腺显像";
            // 
            // chkHypothyroidKnubDisply
            // 
            this.chkHypothyroidKnubDisply.AllowDrop = true;
            this.chkHypothyroidKnubDisply.Location = new System.Drawing.Point(12, 64);
            this.chkHypothyroidKnubDisply.Name = "chkHypothyroidKnubDisply";
            this.chkHypothyroidKnubDisply.Size = new System.Drawing.Size(140, 24);
            this.chkHypothyroidKnubDisply.TabIndex = 10;
            this.chkHypothyroidKnubDisply.Text = "甲状腺亲肿瘤显像";
            // 
            // chkKidneyDisply
            // 
            this.chkKidneyDisply.AllowDrop = true;
            this.chkKidneyDisply.Location = new System.Drawing.Point(12, 88);
            this.chkKidneyDisply.Name = "chkKidneyDisply";
            this.chkKidneyDisply.Size = new System.Drawing.Size(188, 24);
            this.chkKidneyDisply.TabIndex = 11;
            this.chkKidneyDisply.Text = "肾上腺髓质嗜铬细胞显像";
            // 
            // chkHypothyroidCancer
            // 
            this.chkHypothyroidCancer.AllowDrop = true;
            this.chkHypothyroidCancer.Location = new System.Drawing.Point(12, 112);
            this.chkHypothyroidCancer.Name = "chkHypothyroidCancer";
            this.chkHypothyroidCancer.Size = new System.Drawing.Size(156, 24);
            this.chkHypothyroidCancer.TabIndex = 12;
            this.chkHypothyroidCancer.Text = "甲状腺癌转移灶显像";
            // 
            // chkhypothyroidside
            // 
            this.chkhypothyroidside.AllowDrop = true;
            this.chkhypothyroidside.BackColor = System.Drawing.Color.Transparent;
            this.chkhypothyroidside.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkhypothyroidside.ForeColor = System.Drawing.Color.Black;
            this.chkhypothyroidside.Location = new System.Drawing.Point(12, 136);
            this.chkhypothyroidside.Name = "chkhypothyroidside";
            this.chkhypothyroidside.Size = new System.Drawing.Size(112, 24);
            this.chkhypothyroidside.TabIndex = 13;
            this.chkhypothyroidside.Text = "甲状旁腺显像";
            this.chkhypothyroidside.UseVisualStyleBackColor = false;
            // 
            // chkPneumonicdAerate
            // 
            this.chkPneumonicdAerate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkPneumonicdAerate.Location = new System.Drawing.Point(256, 40);
            this.chkPneumonicdAerate.Name = "chkPneumonicdAerate";
            this.chkPneumonicdAerate.Size = new System.Drawing.Size(156, 24);
            this.chkPneumonicdAerate.TabIndex = 25;
            this.chkPneumonicdAerate.Text = "肺通气显像";
            // 
            // chkPneumonicdBlood
            // 
            this.chkPneumonicdBlood.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkPneumonicdBlood.Location = new System.Drawing.Point(256, 64);
            this.chkPneumonicdBlood.Name = "chkPneumonicdBlood";
            this.chkPneumonicdBlood.Size = new System.Drawing.Size(140, 24);
            this.chkPneumonicdBlood.TabIndex = 26;
            this.chkPneumonicdBlood.Text = "肺血流灌注显像";
            // 
            // chkPneumonicdknub
            // 
            this.chkPneumonicdknub.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkPneumonicdknub.Location = new System.Drawing.Point(256, 88);
            this.chkPneumonicdknub.Name = "chkPneumonicdknub";
            this.chkPneumonicdknub.Size = new System.Drawing.Size(156, 24);
            this.chkPneumonicdknub.TabIndex = 27;
            this.chkPneumonicdknub.Text = "肺亲肿瘤显像";
            // 
            // lblDigest
            // 
            this.lblDigest.AutoSize = true;
            this.lblDigest.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDigest.ForeColor = System.Drawing.Color.Black;
            this.lblDigest.Location = new System.Drawing.Point(256, 112);
            this.lblDigest.Name = "lblDigest";
            this.lblDigest.Size = new System.Drawing.Size(83, 14);
            this.lblDigest.TabIndex = 511;
            this.lblDigest.Text = "[消化系统]";
            // 
            // chkCourage
            // 
            this.chkCourage.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkCourage.Location = new System.Drawing.Point(256, 132);
            this.chkCourage.Name = "chkCourage";
            this.chkCourage.Size = new System.Drawing.Size(120, 24);
            this.chkCourage.TabIndex = 28;
            this.chkCourage.Text = "肝胆动态显像";
            // 
            // chkCouragePool
            // 
            this.chkCouragePool.Location = new System.Drawing.Point(256, 180);
            this.chkCouragePool.Name = "chkCouragePool";
            this.chkCouragePool.Size = new System.Drawing.Size(136, 24);
            this.chkCouragePool.TabIndex = 30;
            this.chkCouragePool.Text = "肝血池断层显像";
            // 
            // chkCourageFaultage
            // 
            this.chkCourageFaultage.Location = new System.Drawing.Point(256, 156);
            this.chkCourageFaultage.Name = "chkCourageFaultage";
            this.chkCourageFaultage.Size = new System.Drawing.Size(132, 24);
            this.chkCourageFaultage.TabIndex = 29;
            this.chkCourageFaultage.Text = "肝胶体断层显像";
            // 
            // chkPulse
            // 
            this.chkPulse.Location = new System.Drawing.Point(256, 204);
            this.chkPulse.Name = "chkPulse";
            this.chkPulse.Size = new System.Drawing.Size(152, 24);
            this.chkPulse.TabIndex = 31;
            this.chkPulse.Text = "门脉循环动态显像";
            // 
            // chkMeikl
            // 
            this.chkMeikl.Location = new System.Drawing.Point(256, 228);
            this.chkMeikl.Name = "chkMeikl";
            this.chkMeikl.Size = new System.Drawing.Size(144, 24);
            this.chkMeikl.TabIndex = 32;
            this.chkMeikl.Text = "美克尔氏憩室显像";
            // 
            // chkEsophagus
            // 
            this.chkEsophagus.Location = new System.Drawing.Point(256, 252);
            this.chkEsophagus.Name = "chkEsophagus";
            this.chkEsophagus.Size = new System.Drawing.Size(184, 24);
            this.chkEsophagus.TabIndex = 33;
            this.chkEsophagus.Text = "食道通过及排空时间显像";
            // 
            // chkEnteron
            // 
            this.chkEnteron.Location = new System.Drawing.Point(256, 276);
            this.chkEnteron.Name = "chkEnteron";
            this.chkEnteron.Size = new System.Drawing.Size(168, 24);
            this.chkEnteron.TabIndex = 34;
            this.chkEnteron.Text = "下消化道出血定位显像";
            // 
            // lblCallousSystem
            // 
            this.lblCallousSystem.AutoSize = true;
            this.lblCallousSystem.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCallousSystem.ForeColor = System.Drawing.Color.Black;
            this.lblCallousSystem.Location = new System.Drawing.Point(476, 20);
            this.lblCallousSystem.Name = "lblCallousSystem";
            this.lblCallousSystem.Size = new System.Drawing.Size(98, 14);
            this.lblCallousSystem.TabIndex = 519;
            this.lblCallousSystem.Text = "[心血管系统]";
            // 
            // lblBone
            // 
            this.lblBone.AllowDrop = true;
            this.lblBone.AutoSize = true;
            this.lblBone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblBone.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBone.Location = new System.Drawing.Point(12, 160);
            this.lblBone.Name = "lblBone";
            this.lblBone.Size = new System.Drawing.Size(98, 14);
            this.lblBone.TabIndex = 520;
            this.lblBone.Text = "[骨关节系统]";
            // 
            // chkBody
            // 
            this.chkBody.AllowDrop = true;
            this.chkBody.BackColor = System.Drawing.Color.Transparent;
            this.chkBody.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkBody.ForeColor = System.Drawing.Color.Black;
            this.chkBody.Location = new System.Drawing.Point(12, 180);
            this.chkBody.Name = "chkBody";
            this.chkBody.Size = new System.Drawing.Size(104, 24);
            this.chkBody.TabIndex = 14;
            this.chkBody.Text = "全身骨显像";
            this.chkBody.UseVisualStyleBackColor = false;
            // 
            // chkBone
            // 
            this.chkBone.AllowDrop = true;
            this.chkBone.BackColor = System.Drawing.Color.Transparent;
            this.chkBone.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkBone.ForeColor = System.Drawing.Color.Black;
            this.chkBone.Location = new System.Drawing.Point(12, 204);
            this.chkBone.Name = "chkBone";
            this.chkBone.Size = new System.Drawing.Size(124, 24);
            this.chkBone.TabIndex = 15;
            this.chkBone.Text = "骨亲肿瘤显像";
            this.chkBone.UseVisualStyleBackColor = false;
            // 
            // chkBoneTr
            // 
            this.chkBoneTr.AllowDrop = true;
            this.chkBoneTr.BackColor = System.Drawing.Color.Transparent;
            this.chkBoneTr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkBoneTr.ForeColor = System.Drawing.Color.Black;
            this.chkBoneTr.Location = new System.Drawing.Point(12, 228);
            this.chkBoneTr.Name = "chkBoneTr";
            this.chkBoneTr.Size = new System.Drawing.Size(256, 24);
            this.chkBoneTr.TabIndex = 16;
            this.chkBoneTr.Text = "骨转移癌治疗(89Sr、153Sm、188Re)";
            this.chkBoneTr.UseVisualStyleBackColor = false;
            // 
            // chkHeartBlood
            // 
            this.chkHeartBlood.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkHeartBlood.Location = new System.Drawing.Point(476, 64);
            this.chkHeartBlood.Name = "chkHeartBlood";
            this.chkHeartBlood.Size = new System.Drawing.Size(192, 24);
            this.chkHeartBlood.TabIndex = 42;
            this.chkHeartBlood.Text = "门控心血池显像";
            // 
            // chkDBody
            // 
            this.chkDBody.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkDBody.Location = new System.Drawing.Point(476, 88);
            this.chkDBody.Name = "chkDBody";
            this.chkDBody.Size = new System.Drawing.Size(184, 24);
            this.chkDBody.TabIndex = 43;
            this.chkDBody.Text = "下肢深静脉造影";
            // 
            // lblBlood
            // 
            this.lblBlood.AutoSize = true;
            this.lblBlood.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblBlood.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBlood.ForeColor = System.Drawing.Color.Black;
            this.lblBlood.Location = new System.Drawing.Point(476, 112);
            this.lblBlood.Name = "lblBlood";
            this.lblBlood.Size = new System.Drawing.Size(113, 14);
            this.lblBlood.TabIndex = 527;
            this.lblBlood.Text = "[血液淋巴系统]";
            // 
            // chkOverbody
            // 
            this.chkOverbody.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkOverbody.Location = new System.Drawing.Point(476, 132);
            this.chkOverbody.Name = "chkOverbody";
            this.chkOverbody.Size = new System.Drawing.Size(184, 24);
            this.chkOverbody.TabIndex = 44;
            this.chkOverbody.Text = "全身骨髓显像";
            // 
            // chkSpleen
            // 
            this.chkSpleen.Location = new System.Drawing.Point(476, 156);
            this.chkSpleen.Name = "chkSpleen";
            this.chkSpleen.Size = new System.Drawing.Size(104, 24);
            this.chkSpleen.TabIndex = 45;
            this.chkSpleen.Text = "脾显像";
            // 
            // chkLymph
            // 
            this.chkLymph.Location = new System.Drawing.Point(476, 180);
            this.chkLymph.Name = "chkLymph";
            this.chkLymph.Size = new System.Drawing.Size(184, 24);
            this.chkLymph.TabIndex = 46;
            this.chkLymph.Text = "淋巴显像";
            // 
            // lblProcreate
            // 
            this.lblProcreate.AllowDrop = true;
            this.lblProcreate.AutoSize = true;
            this.lblProcreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblProcreate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblProcreate.ForeColor = System.Drawing.Color.Black;
            this.lblProcreate.Location = new System.Drawing.Point(12, 252);
            this.lblProcreate.Name = "lblProcreate";
            this.lblProcreate.Size = new System.Drawing.Size(113, 14);
            this.lblProcreate.TabIndex = 531;
            this.lblProcreate.Text = "[泌尿生殖系统]";
            // 
            // chkKidneyDin
            // 
            this.chkKidneyDin.AllowDrop = true;
            this.chkKidneyDin.Location = new System.Drawing.Point(12, 268);
            this.chkKidneyDin.Name = "chkKidneyDin";
            this.chkKidneyDin.Size = new System.Drawing.Size(100, 24);
            this.chkKidneyDin.TabIndex = 17;
            this.chkKidneyDin.Text = "肾动态显像";
            // 
            // chkKidneyStr
            // 
            this.chkKidneyStr.AllowDrop = true;
            this.chkKidneyStr.Location = new System.Drawing.Point(12, 292);
            this.chkKidneyStr.Name = "chkKidneyStr";
            this.chkKidneyStr.Size = new System.Drawing.Size(104, 24);
            this.chkKidneyStr.TabIndex = 18;
            this.chkKidneyStr.Text = "肾静态显像";
            // 
            // chkKidneyBall
            // 
            this.chkKidneyBall.AllowDrop = true;
            this.chkKidneyBall.Location = new System.Drawing.Point(12, 316);
            this.chkKidneyBall.Name = "chkKidneyBall";
            this.chkKidneyBall.Size = new System.Drawing.Size(172, 24);
            this.chkKidneyBall.TabIndex = 19;
            this.chkKidneyBall.Text = "肾小球滤过率（GFR）";
            // 
            // chkKidneyBlood
            // 
            this.chkKidneyBlood.AllowDrop = true;
            this.chkKidneyBlood.Location = new System.Drawing.Point(12, 340);
            this.chkKidneyBlood.Name = "chkKidneyBlood";
            this.chkKidneyBlood.Size = new System.Drawing.Size(204, 24);
            this.chkKidneyBlood.TabIndex = 20;
            this.chkKidneyBlood.Text = "肾有效血球浆流量（ERPF）";
            // 
            // chkBladder
            // 
            this.chkBladder.Location = new System.Drawing.Point(12, 364);
            this.chkBladder.Name = "chkBladder";
            this.chkBladder.Size = new System.Drawing.Size(160, 24);
            this.chkBladder.TabIndex = 21;
            this.chkBladder.Text = "膀胱—输尿管返流";
            // 
            // chkBloodPool
            // 
            this.chkBloodPool.Location = new System.Drawing.Point(12, 388);
            this.chkBloodPool.Name = "chkBloodPool";
            this.chkBloodPool.Size = new System.Drawing.Size(172, 24);
            this.chkBloodPool.TabIndex = 22;
            this.chkBloodPool.Text = "阴囊血池显像";
            // 
            // chkOvum
            // 
            this.chkOvum.Location = new System.Drawing.Point(12, 412);
            this.chkOvum.Name = "chkOvum";
            this.chkOvum.Size = new System.Drawing.Size(108, 24);
            this.chkOvum.TabIndex = 23;
            this.chkOvum.Text = "输卵管造影";
            // 
            // chkBreastCancer
            // 
            this.chkBreastCancer.Location = new System.Drawing.Point(12, 432);
            this.chkBreastCancer.Name = "chkBreastCancer";
            this.chkBreastCancer.Size = new System.Drawing.Size(164, 24);
            this.chkBreastCancer.TabIndex = 24;
            this.chkBreastCancer.Text = "乳腺亲肿瘤显像";
            // 
            // lblNerve
            // 
            this.lblNerve.AutoSize = true;
            this.lblNerve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNerve.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNerve.ForeColor = System.Drawing.Color.Black;
            this.lblNerve.Location = new System.Drawing.Point(256, 300);
            this.lblNerve.Name = "lblNerve";
            this.lblNerve.Size = new System.Drawing.Size(83, 14);
            this.lblNerve.TabIndex = 540;
            this.lblNerve.Text = "[神经系统]";
            // 
            // chkBrainBlood
            // 
            this.chkBrainBlood.Location = new System.Drawing.Point(256, 316);
            this.chkBrainBlood.Name = "chkBrainBlood";
            this.chkBrainBlood.Size = new System.Drawing.Size(188, 24);
            this.chkBrainBlood.TabIndex = 35;
            this.chkBrainBlood.Text = "脑血流灌注断层显像";
            // 
            // chkBrainCancer
            // 
            this.chkBrainCancer.Location = new System.Drawing.Point(256, 340);
            this.chkBrainCancer.Name = "chkBrainCancer";
            this.chkBrainCancer.Size = new System.Drawing.Size(180, 24);
            this.chkBrainCancer.TabIndex = 36;
            this.chkBrainCancer.Text = "脑亲肿瘤断层显像";
            // 
            // lblPET
            // 
            this.lblPET.AutoSize = true;
            this.lblPET.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPET.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPET.ForeColor = System.Drawing.Color.Black;
            this.lblPET.Location = new System.Drawing.Point(476, 204);
            this.lblPET.Name = "lblPET";
            this.lblPET.Size = new System.Drawing.Size(182, 14);
            this.lblPET.TabIndex = 543;
            this.lblPET.Text = "[正电子断层系统（PET）]";
            // 
            // chkDepCancer
            // 
            this.chkDepCancer.Location = new System.Drawing.Point(476, 224);
            this.chkDepCancer.Name = "chkDepCancer";
            this.chkDepCancer.Size = new System.Drawing.Size(232, 24);
            this.chkDepCancer.TabIndex = 47;
            this.chkDepCancer.Text = "18F-FDG局部肿瘤显像";
            // 
            // chkOverCancer
            // 
            this.chkOverCancer.Location = new System.Drawing.Point(476, 248);
            this.chkOverCancer.Name = "chkOverCancer";
            this.chkOverCancer.Size = new System.Drawing.Size(208, 24);
            this.chkOverCancer.TabIndex = 48;
            this.chkOverCancer.Text = "18F-FDG全身肿瘤显像";
            // 
            // chkMetabolize
            // 
            this.chkMetabolize.Location = new System.Drawing.Point(476, 272);
            this.chkMetabolize.Name = "chkMetabolize";
            this.chkMetabolize.Size = new System.Drawing.Size(224, 24);
            this.chkMetabolize.TabIndex = 49;
            this.chkMetabolize.Text = "18F-FDG心肌代谢显像";
            // 
            // chkBrainMetabolize
            // 
            this.chkBrainMetabolize.Location = new System.Drawing.Point(476, 296);
            this.chkBrainMetabolize.Name = "chkBrainMetabolize";
            this.chkBrainMetabolize.Size = new System.Drawing.Size(200, 24);
            this.chkBrainMetabolize.TabIndex = 50;
            this.chkBrainMetabolize.Text = "18F-FDG脑代谢显像";
            // 
            // lblHistory
            // 
            this.lblHistory.AutoSize = true;
            this.lblHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblHistory.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHistory.ForeColor = System.Drawing.Color.Black;
            this.lblHistory.Location = new System.Drawing.Point(8, 28);
            this.lblHistory.Name = "lblHistory";
            this.lblHistory.Size = new System.Drawing.Size(56, 14);
            this.lblHistory.TabIndex = 548;
            this.lblHistory.Text = "病  史:";
            // 
            // lblCheckLab
            // 
            this.lblCheckLab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCheckLab.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCheckLab.ForeColor = System.Drawing.Color.Black;
            this.lblCheckLab.Location = new System.Drawing.Point(8, 238);
            this.lblCheckLab.Name = "lblCheckLab";
            this.lblCheckLab.Size = new System.Drawing.Size(132, 20);
            this.lblCheckLab.TabIndex = 548;
            this.lblCheckLab.Text = "检验及其他检查:";
            // 
            // lblDisgonse
            // 
            this.lblDisgonse.AutoSize = true;
            this.lblDisgonse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDisgonse.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDisgonse.ForeColor = System.Drawing.Color.Black;
            this.lblDisgonse.Location = new System.Drawing.Point(8, 350);
            this.lblDisgonse.Name = "lblDisgonse";
            this.lblDisgonse.Size = new System.Drawing.Size(70, 14);
            this.lblDisgonse.TabIndex = 548;
            this.lblDisgonse.Text = "临床诊断:";
            // 
            // lblAddress
            // 
            this.lblAddress.AllowDrop = true;
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAddress.ForeColor = System.Drawing.Color.Black;
            this.lblAddress.Location = new System.Drawing.Point(71, 224);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(56, 14);
            this.lblAddress.TabIndex = 501;
            this.lblAddress.Text = "地  址:";
            this.lblAddress.Visible = false;
            // 
            // lblAddressContent
            // 
            this.lblAddressContent.AllowDrop = true;
            this.lblAddressContent.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAddressContent.ForeColor = System.Drawing.Color.Black;
            this.lblAddressContent.Location = new System.Drawing.Point(127, 224);
            this.lblAddressContent.Name = "lblAddressContent";
            this.lblAddressContent.Size = new System.Drawing.Size(252, 19);
            this.lblAddressContent.TabIndex = 501;
            this.lblAddressContent.Visible = false;
            // 
            // lblTel
            // 
            this.lblTel.AllowDrop = true;
            this.lblTel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTel.ForeColor = System.Drawing.Color.Black;
            this.lblTel.Location = new System.Drawing.Point(516, 29);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(42, 26);
            this.lblTel.TabIndex = 501;
            this.lblTel.Text = "电话:";
            this.lblTel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTelContent
            // 
            this.lblTelContent.AllowDrop = true;
            this.lblTelContent.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTelContent.ForeColor = System.Drawing.Color.Black;
            this.lblTelContent.Location = new System.Drawing.Point(558, 29);
            this.lblTelContent.Name = "lblTelContent";
            this.lblTelContent.Size = new System.Drawing.Size(131, 26);
            this.lblTelContent.TabIndex = 501;
            this.lblTelContent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPayment
            // 
            this.lblPayment.AllowDrop = true;
            this.lblPayment.AutoSize = true;
            this.lblPayment.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPayment.ForeColor = System.Drawing.Color.Black;
            this.lblPayment.Location = new System.Drawing.Point(446, 8);
            this.lblPayment.Name = "lblPayment";
            this.lblPayment.Size = new System.Drawing.Size(70, 14);
            this.lblPayment.TabIndex = 501;
            this.lblPayment.Text = "交费方式:";
            // 
            // chkPaymentSelf
            // 
            this.chkPaymentSelf.AllowDrop = true;
            this.chkPaymentSelf.Location = new System.Drawing.Point(686, 3);
            this.chkPaymentSelf.Name = "chkPaymentSelf";
            this.chkPaymentSelf.Size = new System.Drawing.Size(64, 24);
            this.chkPaymentSelf.TabIndex = 8;
            this.chkPaymentSelf.Text = "自 费";
            // 
            // chkPaymentPulbic
            // 
            this.chkPaymentPulbic.AllowDrop = true;
            this.chkPaymentPulbic.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkPaymentPulbic.Location = new System.Drawing.Point(516, 3);
            this.chkPaymentPulbic.Name = "chkPaymentPulbic";
            this.chkPaymentPulbic.Size = new System.Drawing.Size(76, 24);
            this.chkPaymentPulbic.TabIndex = 6;
            this.chkPaymentPulbic.Tag = "";
            this.chkPaymentPulbic.Text = "市公费";
            // 
            // chkPaymentCompany
            // 
            this.chkPaymentCompany.AllowDrop = true;
            this.chkPaymentCompany.Location = new System.Drawing.Point(598, 3);
            this.chkPaymentCompany.Name = "chkPaymentCompany";
            this.chkPaymentCompany.Size = new System.Drawing.Size(88, 24);
            this.chkPaymentCompany.TabIndex = 7;
            this.chkPaymentCompany.Text = "单位记账";
            // 
            // label8
            // 
            this.label8.AllowDrop = true;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(296, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 14);
            this.label8.TabIndex = 501;
            this.label8.Text = "检查号:";
            // 
            // txtCheckNO
            // 
            this.txtCheckNO.BackColor = System.Drawing.Color.White;
            this.txtCheckNO.ForeColor = System.Drawing.Color.Black;
            this.txtCheckNO.Location = new System.Drawing.Point(349, 4);
            this.txtCheckNO.Name = "txtCheckNO";
            this.txtCheckNO.Size = new System.Drawing.Size(80, 23);
            this.txtCheckNO.TabIndex = 553;
            // 
            // lblRecordTimeTitle
            // 
            this.lblRecordTimeTitle.AutoSize = true;
            this.lblRecordTimeTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRecordTimeTitle.Location = new System.Drawing.Point(3, 8);
            this.lblRecordTimeTitle.Name = "lblRecordTimeTitle";
            this.lblRecordTimeTitle.Size = new System.Drawing.Size(70, 14);
            this.lblRecordTimeTitle.TabIndex = 6047;
            this.lblRecordTimeTitle.Text = "申请时间:";
            // 
            // dtpApplyTime
            // 
            this.dtpApplyTime.BorderColor = System.Drawing.Color.Black;
            this.dtpApplyTime.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpApplyTime.DropButtonBackColor = System.Drawing.Color.Gainsboro;
            this.dtpApplyTime.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpApplyTime.DropButtonForeColor = System.Drawing.Color.Black;
            this.dtpApplyTime.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpApplyTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpApplyTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpApplyTime.Location = new System.Drawing.Point(75, 4);
            this.dtpApplyTime.m_BlnOnlyTime = false;
            this.dtpApplyTime.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpApplyTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpApplyTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpApplyTime.Name = "dtpApplyTime";
            this.dtpApplyTime.ReadOnly = false;
            this.dtpApplyTime.Size = new System.Drawing.Size(212, 22);
            this.dtpApplyTime.TabIndex = 5;
            this.dtpApplyTime.TextBackColor = System.Drawing.Color.White;
            this.dtpApplyTime.TextForeColor = System.Drawing.Color.Black;
            // 
            // trvTime
            // 
            this.trvTime.BackColor = System.Drawing.Color.White;
            this.trvTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.trvTime.ForeColor = System.Drawing.Color.Black;
            this.trvTime.HideSelection = false;
            this.trvTime.ItemHeight = 18;
            this.trvTime.Location = new System.Drawing.Point(6, 37);
            this.trvTime.Name = "trvTime";
            this.trvTime.ShowRootLines = false;
            this.trvTime.Size = new System.Drawing.Size(193, 52);
            this.trvTime.TabIndex = 4;
            this.trvTime.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvTime_AfterSelect);
            // 
            // lblCreateUser
            // 
            this.lblCreateUser.AllowDrop = true;
            this.lblCreateUser.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCreateUser.ForeColor = System.Drawing.Color.White;
            this.lblCreateUser.Location = new System.Drawing.Point(628, 634);
            this.lblCreateUser.Name = "lblCreateUser";
            this.lblCreateUser.Size = new System.Drawing.Size(124, 24);
            this.lblCreateUser.TabIndex = 6049;
            this.lblCreateUser.Visible = false;
            // 
            // txtHistory
            // 
            this.txtHistory.AccessibleDescription = "病史";
            this.txtHistory.BackColor = System.Drawing.Color.White;
            this.txtHistory.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtHistory.ForeColor = System.Drawing.Color.Black;
            this.txtHistory.Location = new System.Drawing.Point(4, 52);
            this.txtHistory.Name = "txtHistory";
            this.txtHistory.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtHistory.Size = new System.Drawing.Size(768, 183);
            this.txtHistory.TabIndex = 51;
            this.txtHistory.Text = "";
            // 
            // txtCheckLab
            // 
            this.txtCheckLab.AccessibleDescription = "检查及其他检查";
            this.txtCheckLab.BackColor = System.Drawing.Color.White;
            this.txtCheckLab.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCheckLab.ForeColor = System.Drawing.Color.Black;
            this.txtCheckLab.Location = new System.Drawing.Point(4, 262);
            this.txtCheckLab.Name = "txtCheckLab";
            this.txtCheckLab.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtCheckLab.Size = new System.Drawing.Size(768, 88);
            this.txtCheckLab.TabIndex = 52;
            this.txtCheckLab.Text = "";
            // 
            // txtDisgonse
            // 
            this.txtDisgonse.AccessibleDescription = "临床诊断";
            this.txtDisgonse.BackColor = System.Drawing.Color.White;
            this.txtDisgonse.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDisgonse.ForeColor = System.Drawing.Color.Black;
            this.txtDisgonse.Location = new System.Drawing.Point(4, 374);
            this.txtDisgonse.Name = "txtDisgonse";
            this.txtDisgonse.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtDisgonse.Size = new System.Drawing.Size(768, 88);
            this.txtDisgonse.TabIndex = 53;
            this.txtDisgonse.Text = "";
            // 
            // txtTell
            // 
            this.txtTell.BackColor = System.Drawing.Color.White;
            this.txtTell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTell.ForeColor = System.Drawing.Color.Black;
            this.txtTell.Location = new System.Drawing.Point(384, 432);
            this.txtTell.Name = "txtTell";
            this.txtTell.ReadOnly = true;
            this.txtTell.Size = new System.Drawing.Size(368, 24);
            this.txtTell.TabIndex = 40;
            this.txtTell.Text = "";
            // 
            // lblEmployeeSign
            // 
            this.lblEmployeeSign.AutoSize = true;
            this.lblEmployeeSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblEmployeeSign.Location = new System.Drawing.Point(584, 634);
            this.lblEmployeeSign.Name = "lblEmployeeSign";
            this.lblEmployeeSign.Size = new System.Drawing.Size(42, 14);
            this.lblEmployeeSign.TabIndex = 10000082;
            this.lblEmployeeSign.Text = "签名:";
            this.lblEmployeeSign.Visible = false;
            // 
            // m_cmdSign
            // 
            this.m_cmdSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdSign.DefaultScheme = true;
            this.m_cmdSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdSign.ForeColor = System.Drawing.Color.Black;
            this.m_cmdSign.Hint = "";
            this.m_cmdSign.Location = new System.Drawing.Point(64, 636);
            this.m_cmdSign.Name = "m_cmdSign";
            this.m_cmdSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSign.Size = new System.Drawing.Size(92, 24);
            this.m_cmdSign.TabIndex = 10000083;
            this.m_cmdSign.Tag = "1";
            this.m_cmdSign.Text = "申请医师:";
            // 
            // lblOther
            // 
            this.lblOther.AutoSize = true;
            this.lblOther.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblOther.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOther.ForeColor = System.Drawing.Color.Black;
            this.lblOther.Location = new System.Drawing.Point(256, 364);
            this.lblOther.Name = "lblOther";
            this.lblOther.Size = new System.Drawing.Size(53, 14);
            this.lblOther.TabIndex = 548;
            this.lblOther.Text = "[其它]";
            // 
            // chkTear
            // 
            this.chkTear.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkTear.ForeColor = System.Drawing.SystemColors.WindowText;
            this.chkTear.Location = new System.Drawing.Point(256, 384);
            this.chkTear.Name = "chkTear";
            this.chkTear.Size = new System.Drawing.Size(148, 24);
            this.chkTear.TabIndex = 37;
            this.chkTear.Text = "泪道动态显像";
            // 
            // chkNose
            // 
            this.chkNose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkNose.ForeColor = System.Drawing.SystemColors.WindowText;
            this.chkNose.Location = new System.Drawing.Point(256, 408);
            this.chkNose.Name = "chkNose";
            this.chkNose.Size = new System.Drawing.Size(164, 24);
            this.chkNose.TabIndex = 38;
            this.chkNose.Text = "鼻咽部亲肿瘤显像";
            // 
            // chkTell
            // 
            this.chkTell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkTell.ForeColor = System.Drawing.SystemColors.WindowText;
            this.chkTell.Location = new System.Drawing.Point(256, 432);
            this.chkTell.Name = "chkTell";
            this.chkTell.Size = new System.Drawing.Size(148, 24);
            this.chkTell.TabIndex = 39;
            this.chkTell.Text = "请临床具体写出:";
            this.chkTell.CheckedChanged += new System.EventHandler(this.chkTell_CheckedChanged);
            // 
            // chkHeart
            // 
            this.chkHeart.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkHeart.ForeColor = System.Drawing.SystemColors.WindowText;
            this.chkHeart.Location = new System.Drawing.Point(476, 40);
            this.chkHeart.Name = "chkHeart";
            this.chkHeart.Size = new System.Drawing.Size(264, 24);
            this.chkHeart.TabIndex = 41;
            this.chkHeart.Text = "心肌灌注断层显像（动态+静态）";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.chkPneumonicdknub);
            this.panel1.Controls.Add(this.lblDigest);
            this.panel1.Controls.Add(this.lblBlood);
            this.panel1.Controls.Add(this.chkCourage);
            this.panel1.Controls.Add(this.chkCouragePool);
            this.panel1.Controls.Add(this.chkCourageFaultage);
            this.panel1.Controls.Add(this.chkPulse);
            this.panel1.Controls.Add(this.chkMeikl);
            this.panel1.Controls.Add(this.chkEsophagus);
            this.panel1.Controls.Add(this.chkEnteron);
            this.panel1.Controls.Add(this.lblCallousSystem);
            this.panel1.Controls.Add(this.lblProcreate);
            this.panel1.Controls.Add(this.chkKidneyStr);
            this.panel1.Controls.Add(this.chkKidneyBall);
            this.panel1.Controls.Add(this.chkKidneyBlood);
            this.panel1.Controls.Add(this.chkBody);
            this.panel1.Controls.Add(this.chkKidneyDisply);
            this.panel1.Controls.Add(this.chkDepCancer);
            this.panel1.Controls.Add(this.chkLymph);
            this.panel1.Controls.Add(this.chkPneumonicdBlood);
            this.panel1.Controls.Add(this.chkOverbody);
            this.panel1.Controls.Add(this.txtTell);
            this.panel1.Controls.Add(this.chkBone);
            this.panel1.Controls.Add(this.chkBladder);
            this.panel1.Controls.Add(this.chkBloodPool);
            this.panel1.Controls.Add(this.chkOvum);
            this.panel1.Controls.Add(this.chkBreastCancer);
            this.panel1.Controls.Add(this.chkBrainMetabolize);
            this.panel1.Controls.Add(this.chkSpleen);
            this.panel1.Controls.Add(this.lblNerve);
            this.panel1.Controls.Add(this.chkHeartBlood);
            this.panel1.Controls.Add(this.chkBrainBlood);
            this.panel1.Controls.Add(this.chkBrainCancer);
            this.panel1.Controls.Add(this.lblPET);
            this.panel1.Controls.Add(this.chkKidneyDin);
            this.panel1.Controls.Add(this.lblOther);
            this.panel1.Controls.Add(this.chkTear);
            this.panel1.Controls.Add(this.chkNose);
            this.panel1.Controls.Add(this.chkMetabolize);
            this.panel1.Controls.Add(this.chkTell);
            this.panel1.Controls.Add(this.lblBone);
            this.panel1.Controls.Add(this.chkDBody);
            this.panel1.Controls.Add(this.chkOverCancer);
            this.panel1.Controls.Add(this.lblIncretionSystem);
            this.panel1.Controls.Add(this.chkHeart);
            this.panel1.Controls.Add(this.lblBreathSystem);
            this.panel1.Controls.Add(this.chkHypothyroidDisply);
            this.panel1.Controls.Add(this.chkHypothyroidKnubDisply);
            this.panel1.Controls.Add(this.chkHypothyroidCancer);
            this.panel1.Controls.Add(this.chkhypothyroidside);
            this.panel1.Controls.Add(this.chkPneumonicdAerate);
            this.panel1.Controls.Add(this.chkBoneTr);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(790, 476);
            this.panel1.TabIndex = 549;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.txtHistory);
            this.panel2.Controls.Add(this.txtCheckLab);
            this.panel2.Controls.Add(this.txtDisgonse);
            this.panel2.Controls.Add(this.lblHistory);
            this.panel2.Controls.Add(this.lblCheckLab);
            this.panel2.Controls.Add(this.lblDisgonse);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(790, 476);
            this.panel2.TabIndex = 549;
            // 
            // tabControl2
            // 
            this.tabControl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabControl2.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl2.IDEPixelArea = true;
            this.tabControl2.Location = new System.Drawing.Point(5, 128);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.PositionTop = true;
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.SelectedTab = this.tabPage3;
            this.tabControl2.Size = new System.Drawing.Size(790, 502);
            this.tabControl2.TabIndex = 10000085;
            this.tabControl2.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage3,
            this.tabPage4});
            this.tabControl2.SelectionChanged += new System.EventHandler(this.tabControl2_SelectionChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel1);
            this.tabPage3.ImageIndex = 0;
            this.tabPage3.ImageList = this.imageList1;
            this.tabPage3.Location = new System.Drawing.Point(0, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(790, 476);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Title = "检查项目";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.panel2);
            this.tabPage4.ImageIndex = 1;
            this.tabPage4.ImageList = this.imageList1;
            this.tabPage4.Location = new System.Drawing.Point(0, 26);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Selected = false;
            this.tabPage4.Size = new System.Drawing.Size(790, 476);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Title = "病史、检验检查和临床诊断";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txtCheckNO);
            this.panel3.Controls.Add(this.dtpApplyTime);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.chkPaymentPulbic);
            this.panel3.Controls.Add(this.chkPaymentCompany);
            this.panel3.Controls.Add(this.chkPaymentSelf);
            this.panel3.Controls.Add(this.lblPayment);
            this.panel3.Controls.Add(this.lblRecordTimeTitle);
            this.panel3.Location = new System.Drawing.Point(5, 94);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(790, 31);
            this.panel3.TabIndex = 10000086;
            // 
            // m_txtSign
            // 
            this.m_txtSign.Location = new System.Drawing.Point(159, 636);
            this.m_txtSign.Name = "m_txtSign";
            this.m_txtSign.ReadOnly = true;
            this.m_txtSign.Size = new System.Drawing.Size(100, 23);
            this.m_txtSign.TabIndex = 10000087;
            // 
            // frmSPECT
            // 
            this.AccessibleDescription = "SPECT检查申请单";
            this.ClientSize = new System.Drawing.Size(807, 673);
            this.Controls.Add(this.m_txtSign);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.lblEmployeeSign);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.m_cmdSign);
            this.Controls.Add(this.lblCreateUser);
            this.Controls.Add(this.trvTime);
            this.Controls.Add(this.lblAddressContent);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSPECT";
            this.Text = "SPECT检查申请单";
            this.Load += new System.EventHandler(this.frmSPECT_Load);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.lblAddressContent, 0);
            this.Controls.SetChildIndex(this.trvTime, 0);
            this.Controls.SetChildIndex(this.lblCreateUser, 0);
            this.Controls.SetChildIndex(this.m_cmdSign, 0);
            this.Controls.SetChildIndex(this.lblAddress, 0);
            this.Controls.SetChildIndex(this.lblEmployeeSign, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.tabControl2, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.m_txtSign, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region 重载基类窗体
		protected override enmFormState m_EnmCurrentFormState
		{
			get
			{
				return enmFormState.NowUser ;
			}
		}
		protected override bool m_BlnCanTextChanged
		{
			get
			{
				return blnCanSearch;
			}
		}

		protected override void m_mthSetPatientFormInfo(clsPatient p_objSelectedPatient)
		{
			if(p_objSelectedPatient == null)
				return;
			
			this.trvTime.Nodes[0].Nodes.Clear ();
			m_mthClearUpSheet();
			m_objSPECT=null;

            //txtInPatientID.Tag = p_objSelectedPatient.m_DtmSelectedInDate.ToString();
            //txtInPatientID.Text=p_objSelectedPatient.m_StrInPatientID;
			lblTelContent.Text  = p_objSelectedPatient.m_ObjPeopleInfo.m_StrHomePhone;

            //lblAddressContent.Text=p_objSelectedPatient.m_ObjPeopleInfo.m_StrHomeAddress ;
						
			m_objCurrentPatient=p_objSelectedPatient ;
            //m_mthLoadAllTimeOfAPatient(txtInPatientID.Text.Trim(),txtInPatientID.Tag.ToString());			
		}		

		protected override bool m_BlnIsAddNew
		{
			get
			{
				
				if(dtpApplyTime.Enabled ==true)////Add New
					return true;
				else 
					return false;
		
			}
		}
		protected override long m_lngSubModify()
		{
			if(m_objSPECT==null) return -1;
			//			if(!m_bolShowIfModify()) return -1;
            if (clsEMRLogin.LoginEmployee.m_strEMPID_CHR.Trim() != m_objSPECT.strCreateUserID.Trim())
			{	//非申请医生无法更改记录,崔汉瑜,2003-5-27
				clsPublicFunction.ShowInformationMessageBox("无法修改他人的申请单!");
				return -1;
			}
            clsSPECTCheckContent objContent = objSPECTCheckContent(false);
            if (objContent == null)
            {
                return -1;
            }

            long lngSave = m_objDomain.lngSave(objContent); 
			if(lngSave>0)
			{
                clsPublicFunction.ShowInformationMessageBox("修改成功！");
				return 1;
			}
			else 
			{

				clsPublicFunction.ShowInformationMessageBox("修改失败！");

				return -5;
			}

			
		}

		protected override long m_lngSubAddNew()
		{

			m_objSPECT=new clsSPECTCheckContent();

            clsSPECTCheckContent objContent = objSPECTCheckContent(true);
            if (objContent == null)
            {
                return -1;
            }

            long lngSave = m_objDomain.lngSave(objContent); 
			if(lngSave>0)
			{
                clsPublicFunction.ShowInformationMessageBox("保存成功！");
				m_mthAddNodeToTrv(this.dtpApplyTime.Value);
				return 1;
			}
			else 
			{
				clsPublicFunction.ShowInformationMessageBox("保存失败！");
				return -5;
			}
			
		}
		
		protected override long m_lngSubPrint()
		{
			if(m_rpdOrderRept == null)
			{
				m_rpdOrderRept = new ReportDocument();
				m_rpdOrderRept.Load(m_strTemplatePath+"rptSPECTCheckReport.rpt");
			}

			m_mthAddNewDataFordtsSPECTCheckDataSet(m_dtsRept);
			
			if(m_blnDirectPrint)
			{
				m_rpdOrderRept.PrintToPrinter(1,true,1,100);
			}
			else
			{
				frmCryReptView objView = new frmCryReptView(m_rpdOrderRept);
//				objView.MdiParent = this.MdiParent;
				objView.ShowDialog();
			}

			return 1;


		}
		protected override long m_lngSubDelete()
		{
			if(blnCanDelete==false )
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,无权删除他人的记录!");
				return 1;
			}
            if (m_objSPECT == null || m_objCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
				return 0;
            //权限判断
            string strDeptIDTemp = m_ObjCurrentEmrPatientSession.m_strAreaId;
            bool blnIsAllow = clsPublicFunction.IsAllowDelete(strDeptIDTemp, m_objSPECT.strCreateUserID.Trim(), clsEMRLogin.LoginEmployee, 1);
            if (!blnIsAllow)
                return -1;
			long lngRes=m_objDomain.m_lngDeactive(MDIParent.OperatorID,m_objSPECT.strInPatientID,m_objSPECT.strInPatientDate,m_objSPECT.strCreateDate);
			if(lngRes>0)
			{
				foreach(TreeNode trnNode in trvTime.Nodes[0].Nodes)
				{
					if(trnNode.Tag.ToString()==m_objSPECT.strCreateDate)
					{
						trnNode.Remove();
						break;
					}
				}
				m_mthClearUpSheet();
				m_mthReadOnly(false);
			}
			return lngRes ;
		}
		#endregion 

		# region PublicFuction
		public void Save()
		{
			if(m_objCurrentPatient==null)
			{
				clsPublicFunction.ShowInformationMessageBox("请先选择病人！");
				return ;
			}
			m_lngSave();

		}

		public void Display()
		{
					

		}
		public void Display(string strInPatientID,string strInPatientDate,string strCreateDate)
		{ 
			m_objSPECT=m_objDomain.objDisplay( strInPatientID,strInPatientDate,strCreateDate);
			if(m_objSPECT==null) 
				return ;

			if(m_objSPECT.strCreateUserID.Trim()!=clsEMRLogin.LoginEmployee.m_strEMPID_CHR)
			{
				m_mthReadOnly(true);
			}
			else
			{
				m_mthReadOnly(false);
			}
		
			this.chkBladder.Checked=(m_objSPECT.strBladder=="True" || m_objSPECT.strBladder=="1"? true:false );
			this.chkBloodPool.Checked=(m_objSPECT.strBloodPool=="True" || m_objSPECT.strBloodPool=="1"? true:false );  
			this.chkBody.Checked=(m_objSPECT.strBody=="True" || m_objSPECT.strBody=="1"? true:false );  
			
			this.chkBone.Checked=(m_objSPECT.strBone=="True" || m_objSPECT.strBone=="1"? true:false ); 
			this.chkBoneTr.Checked=(m_objSPECT.strBoneTr=="True" || m_objSPECT.strBoneTr=="1"? true:false );  
			this.chkBrainBlood.Checked=(m_objSPECT.strBrainBlood=="True" || m_objSPECT.strBrainBlood=="1"? true:false );  
			
			this.chkBrainCancer.Checked=(m_objSPECT.strBrainCancer=="True" || m_objSPECT.strBrainCancer=="1"? true:false );  
			this.chkBrainMetabolize.Checked=(m_objSPECT.strBrainMetabolize=="True" || m_objSPECT.strBrainMetabolize=="1"? true:false );  
			this.chkBreastCancer.Checked=(m_objSPECT.strBreastCancer=="True" || m_objSPECT.strBreastCancer=="1"? true:false ); 
			
			
			this.chkCourage.Checked=(m_objSPECT.strCourage=="True" || m_objSPECT.strCourage=="1"? true:false ); 
			
			this.chkCourageFaultage.Checked=(m_objSPECT.strCourageFaultage=="True" || m_objSPECT.strCourageFaultage=="1"? true:false ); 
			this.chkCouragePool.Checked=(m_objSPECT.strCouragePool=="True" || m_objSPECT.strCouragePool=="1"? true:false ); 
			this.chkDBody.Checked=(m_objSPECT.strDBody=="True" || m_objSPECT.strDBody=="1"? true:false ); 
			this.chkDepCancer.Checked=(m_objSPECT.strDepCancer=="True" || m_objSPECT.strDepCancer =="1"? true:false ); 
			
			 
			this.chkEnteron.Checked=(m_objSPECT.strEnteron=="True" || m_objSPECT.strEnteron=="1"? true:false ); 
			this.chkEsophagus.Checked=(m_objSPECT.strEsophagus=="True" || m_objSPECT.strEsophagus=="1"? true:false ); 
			
			this.chkHeart.Checked=(m_objSPECT.strHeart=="True" || m_objSPECT.strHeart=="1"? true:false ); 
			this.chkHeartBlood .Checked=(m_objSPECT.strHeartBlood=="True" || m_objSPECT.strHeartBlood=="1"? true:false );  
			
			
			this.chkHypothyroidCancer.Checked=(m_objSPECT.strHypothyroidCancer=="True" || m_objSPECT.strHypothyroidCancer=="1"? true:false ); 
			this.chkHypothyroidDisply.Checked=(m_objSPECT.strHypothyroidDisply=="True" || m_objSPECT.strHypothyroidDisply=="1"? true:false ); 
			this.chkHypothyroidKnubDisply.Checked=(m_objSPECT.strHypothyroidKnubDisply=="True" || m_objSPECT.strHypothyroidKnubDisply=="1"? true:false ); 
			
			this.chkhypothyroidside.Checked=(m_objSPECT.strhypothyroidside=="True" || m_objSPECT.strhypothyroidside=="1"? true:false ); 
			this.chkKidneyBall.Checked=(m_objSPECT.strKidneyBall=="True" || m_objSPECT.strKidneyBall=="1"? true:false ); 
			this.chkKidneyBlood.Checked=(m_objSPECT.strKidneyBlood=="True" || m_objSPECT.strKidneyBlood=="1"? true:false ); 
			
			this.chkKidneyDin.Checked=(m_objSPECT.strKidneyDin=="True" || m_objSPECT.strKidneyDin=="1"? true:false );  
			this.chkKidneyDisply.Checked=(m_objSPECT.strKidneyDisply=="True" || m_objSPECT.strKidneyDisply=="1"? true:false );  
			this.chkKidneyStr.Checked=(m_objSPECT.strKidneyStr=="True" || m_objSPECT.strKidneyStr=="1"? true:false ); 
			
			this.chkLymph.Checked=(m_objSPECT.strLymph=="True" || m_objSPECT.strLymph=="1"? true:false );  
			this.chkMeikl.Checked=(m_objSPECT.strMeikl=="True" || m_objSPECT.strMeikl=="1"? true:false );  
			this.chkMetabolize.Checked=(m_objSPECT.strMetabolize=="True" || m_objSPECT.strMetabolize=="1"? true:false );  
			
			this.chkNose.Checked=(m_objSPECT.strNose=="True" || m_objSPECT.strNose=="1"? true:false );  
			this.chkOverbody.Checked=(m_objSPECT.strOverbody=="True" || m_objSPECT.strOverbody=="1"? true:false );  
			this.chkOverCancer.Checked=(m_objSPECT.strOverCancer=="True" || m_objSPECT.strOverCancer=="1"? true:false ); 
			
			this.chkOvum.Checked=(m_objSPECT.strOvum=="True" || m_objSPECT.strOvum=="1"? true:false );   
			this.chkPaymentCompany.Checked=(m_objSPECT.strPaymentCompany=="True" || m_objSPECT.strPaymentCompany=="1"? true:false );   
			this.chkPaymentPulbic.Checked=(m_objSPECT.strPaymentPulbic=="True" || m_objSPECT.strPaymentPulbic=="1"? true:false ); 
			
			this.chkPaymentSelf.Checked=(m_objSPECT.strPaymentSelf=="True" || m_objSPECT.strPaymentSelf=="1"? true:false );   
			this.chkPneumonicdAerate.Checked=(m_objSPECT.strPneumonicdAerate=="True" || m_objSPECT.strPneumonicdAerate =="1"? true:false );   
			this.chkPneumonicdknub.Checked=(m_objSPECT.strPneumonicdknub=="True" || m_objSPECT.strPneumonicdknub=="1"? true:false );  
			this.chkPneumonicdBlood.Checked=(m_objSPECT.strPneumonicdBlood=="True" || m_objSPECT.strPneumonicdBlood=="1"? true:false );  
			
			this.chkPulse.Checked=(m_objSPECT.strPulse=="True" || m_objSPECT.strPulse=="1"? true:false );
			this.chkSpleen.Checked=(m_objSPECT.strSpleen=="True" || m_objSPECT.strSpleen=="1"? true:false );
			this.chkTear.Checked=(m_objSPECT.strTear=="True" || m_objSPECT.strTear=="1"? true:false );
			this.chkTell.Checked=(m_objSPECT.strTell=="True" || m_objSPECT.strTell=="1"? true:false );

			this.dtpApplyTime.Text=m_objSPECT.strCreateDate; 

			
			this.txtCheckNO.Text=m_objSPECT.strCheckNO;
			this.txtDisgonse.Text= m_objSPECT.strDisgonse;
			this.txtHistory.Text =m_objSPECT.strHistory;
			this.txtCheckLab.Text =m_objSPECT.strCheckLab;
			this.txtTell.Text=m_objSPECT.strTellContent;
			
            //this.lblCreateUser.Text=new clsEmployee(m_objSPECT.strCreateUserID).m_StrFirstName;
            clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
            objEmployeeSign.m_lngGetEmpByID(m_objSPECT.strCreateUserID, out objEmpVO);
            if (objEmpVO != null)
            {
                m_txtSign.Text = objEmpVO.m_strLASTNAME_VCHR;
                m_txtSign.Tag = objEmpVO;
            }
		}

		public void Delete()
		{
			m_lngDelete();
		}
		public void Display(string cardno,string sendcheckdate){}
		public void Copy(){m_lngCopy();}
		public void Cut(){m_lngCut();}
		public void Paste(){m_lngPaste();}
		public void Redo(){}
		public void Undo(){}
		public void Verify()
		{
			//long lngRes=m_lngSignVerify(p_strFormID,p_strRecordID);
		}
		public void Print()
		{
			m_lngPrint();
		}
		
	
		#endregion

		private void frmSPECT_Load(object sender, System.EventArgs e)
		{
			m_mthSetQuickKeys();

			this.m_lsvInPatientID.Visible=false;
			TreeNode trnNode=new TreeNode("申请日期");
			trnNode.Tag ="0";
			this.trvTime.Nodes.Add(trnNode);

			//			txtTell.Enabled=false;
			txtTell.Text="";
			trvTime.Focus();
 
		}
		

		private void trvTime_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			m_mthRecordChangedToSave();

			m_mthClearUpSheet();
			m_objSPECT =null;
			if(this.trvTime.SelectedNode.Tag ==null) return ;
			this.dtpApplyTime.Enabled =true;
			if(this.trvTime.SelectedNode.Tag.ToString()!="0" && m_ObjCurrentEmrPatientSession != null)
			{
                Display(m_ObjCurrentEmrPatientSession.m_strEMRInpatientId, m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"), trvTime.SelectedNode.Tag.ToString());
				this.dtpApplyTime.Text =this.trvTime.SelectedNode.Tag.ToString();
				this.dtpApplyTime.Enabled =false;

					//当前处于修改记录状态
				MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.Modify );
			}
			else
			{
				m_mthReadOnly(false);
				this.dtpApplyTime.Value=DateTime.Now;
				this.lblCreateUser.Text=MDIParent.OperatorName;
				this.dtpApplyTime.Enabled =true;

				if(m_objCurrentPatient != null && txtInPatientID.Tag != null)
				{
					m_mthSetDefaultValue(m_objCurrentPatient);
				}

				//当前处于新增记录状态
				MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.AddNew);
			
			}

			m_mthAddFormStatusForClosingSave();
		
		}
		
		
		private void m_mthLoadAllTimeOfAPatient(string p_strInPatientID,string p_strInPatientDate)
		{
			
			if(p_strInPatientID ==null || p_strInPatientDate =="") return ;
			

			DateTime [] m_dtmArr = m_objDomain .m_dtmGetTimeInfoOfAPatientArr(p_strInPatientID ,p_strInPatientDate);
				
			if(m_dtmArr==null)
			{
				m_mthSetDefaultValue(m_objCurrentPatient);
				return ;
			}
			this.trvTime.Nodes[0].Nodes .Clear();
			for(int i=m_dtmArr.Length-1;i>=0 ;i--)
			{
		
				string strDate=m_dtmArr[i].ToString("yyyy年MM月dd日 HH:mm:ss");
				TreeNode trnDate=new TreeNode(strDate);
				trnDate.Tag =m_dtmArr[i];
				this.trvTime.Nodes[0].Nodes.Add(trnDate );
				
			}
			
			this.trvTime.ExpandAll();
			this.trvTime.SelectedNode = this.trvTime.Nodes[0].Nodes[0];
		}

		/// <summary>
		/// 设置各种类型的默认值
		/// </summary>
		/// <param name="p_objPatient"></param>
		private void m_mthSetDefaultValue(clsPatient p_objPatient)
		{
			new clsDefaultValueTool(this,p_objPatient).m_mthSetDefaultValue();

			//自动模板
			m_mthSetSpecialPatientTemplateSet(p_objPatient);

			//数据复用
//			iCareData.clsInPatientCaseHisoryDefaultValue [] objInPatientCaseDefaultValue = new clsInPatientCaseHisoryDefaultDomain().lngGetAllInPatientCaseHisoryDefault(p_objPatient.m_StrInPatientID,p_objPatient.m_DtmLastInDate.ToString());
//			if(objInPatientCaseDefaultValue !=null && objInPatientCaseDefaultValue.Length >0)
//			{
//				this.txtDisgonse.Text = objInPatientCaseDefaultValue[0].m_strPrimaryDiagnose;
//				this.txtHistory.Text = "患者因" + objInPatientCaseDefaultValue[0].m_strMainDescription + "于" + DateTime.Parse(objInPatientCaseDefaultValue[0].m_strInPatientDate).ToString("yyyy年M月d日")  + "入院。";
//				this.txtCheckLab.Text = objInPatientCaseDefaultValue[0].m_strMedical + objInPatientCaseDefaultValue[0].m_strLabCheck;
//			}
		}
		
		/// <summary>
		/// 清空除了基本资料和"树"外的全部界面内容
		/// </summary>
		private void m_mthClearUpSheet()
		{

			foreach(Control ctlRichText in this.Controls )
			{
				string typeName = ctlRichText.GetType().Name;
				if(typeName =="CheckBox")
					((CheckBox)ctlRichText).Checked=false;
				if((typeName == "RichTextBox" || typeName =="ctlBorderTextBox") && ctlRichText.Name!="txtInPatientID" && ctlRichText.Name!="m_txtPatientName" && ctlRichText.Name!="m_txtBedNO")
					ctlRichText.Text="";				
			}
            //this.lblCreateUser.Text=MDIParent.OperatorName;
			this.txtCheckNO.Text="";

            MDIParent.m_mthSetDefaulEmployee(m_txtSign);
			m_mthClear_Recursive(this.tabControl2,null);
		}
		
		
		private void m_mthAddNodeToTrv(DateTime p_dtmAdd)
		{
			string strDate=p_dtmAdd.ToString("yyyy年MM月dd日 HH:mm:ss");
			TreeNode trnDate=new TreeNode(strDate);
			trnDate.Tag =p_dtmAdd;
			if(trvTime.Nodes[0].Nodes.Count==0)
				trvTime.Nodes[0].Nodes.Add(trnDate);
			else 
			{
				for(int i=0;i<trvTime.Nodes[0].Nodes.Count;i++)
				{
					if(trnDate.Text.CompareTo (trvTime.Nodes[0].Nodes[i].Text)>0)
					{
						trvTime.Nodes[0].Nodes.Insert(i,trnDate);
						break;
					}
				}
			}
			trvTime.SelectedNode=trnDate ;
			this.trvTime.ExpandAll();

		}
				
		private clsSPECTCheckContent objSPECTCheckContent(bool blnIsAddNew)
		{
            if (m_objCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
            {
                clsPublicFunction.ShowInformationMessageBox("请先选择病人");
                return null;
            }

            if (m_txtSign.Tag == null)
            {
                clsPublicFunction.ShowInformationMessageBox("请申请医师签名");
                return null;
            }

			m_objSPECT.strBladder =(this.chkBladder.Checked==true? "1":"0");
			m_objSPECT.strBloodPool  =(this.chkBloodPool.Checked ==true? "1":"0");
			m_objSPECT.strBody  =(this.chkBody.Checked ==true? "1":"0");
			
			m_objSPECT.strBone  =(this.chkBone.Checked ==true? "1":"0");
			m_objSPECT.strBoneTr  =(this.chkBoneTr.Checked ==true? "1":"0");
			m_objSPECT.strBrainBlood  =(this.chkBrainBlood.Checked ==true? "1":"0");
			
			m_objSPECT.strBrainCancer  =(this.chkBrainCancer.Checked ==true? "1":"0");
			m_objSPECT.strBrainMetabolize  =(this.chkBrainMetabolize.Checked ==true? "1":"0");
			m_objSPECT.strBreastCancer =(this.chkBreastCancer.Checked ==true? "1":"0");
			m_objSPECT.strCourage =(this.chkCourage.Checked ==true? "1":"0");
			
			m_objSPECT.strCourageFaultage =(this.chkCourageFaultage.Checked ==true? "1":"0");
			m_objSPECT.strCouragePool =(this.chkCouragePool.Checked ==true? "1":"0");
			m_objSPECT.strDBody =(this.chkDBody.Checked ==true? "1":"0");
			m_objSPECT.strDepCancer  =(this.chkDepCancer.Checked ==true? "1":"0");
			
			m_objSPECT.strEnteron =(this.chkEnteron.Checked ==true? "1":"0");
			m_objSPECT.strEsophagus =(this.chkEsophagus.Checked ==true? "1":"0");
			
			m_objSPECT.strHeart =(this.chkHeart.Checked ==true? "1":"0");
			m_objSPECT.strHeartBlood  =(this.chkHeartBlood .Checked ==true? "1":"0");
			
			m_objSPECT.strHypothyroidCancer =(this.chkHypothyroidCancer.Checked ==true? "1":"0");
			m_objSPECT.strHypothyroidDisply =(this.chkHypothyroidDisply.Checked ==true? "1":"0");
			m_objSPECT.strHypothyroidKnubDisply =(this.chkHypothyroidKnubDisply.Checked ==true? "1":"0");
			
			m_objSPECT.strhypothyroidside =(this.chkhypothyroidside.Checked ==true? "1":"0");
			m_objSPECT.strKidneyBall =(this.chkKidneyBall.Checked ==true? "1":"0");
			m_objSPECT.strKidneyBlood =(this.chkKidneyBlood.Checked ==true? "1":"0");
			
			m_objSPECT.strKidneyDin  =(this.chkKidneyDin.Checked ==true? "1":"0");
			m_objSPECT.strKidneyDisply  =(this.chkKidneyDisply.Checked ==true? "1":"0");
			m_objSPECT.strKidneyStr =(this.chkKidneyStr.Checked ==true? "1":"0");
			
			m_objSPECT.strLymph  =(this.chkLymph.Checked ==true? "1":"0");
			m_objSPECT.strMeikl  =(this.chkMeikl.Checked ==true? "1":"0");
			m_objSPECT.strMetabolize  =(this.chkMetabolize.Checked ==true? "1":"0");
			
			m_objSPECT.strNose  =(this.chkNose.Checked ==true? "1":"0");
			m_objSPECT.strOverbody  =(this.chkOverbody.Checked ==true? "1":"0");
			m_objSPECT.strOverCancer =(this.chkOverCancer.Checked ==true? "1":"0");
			
			m_objSPECT.strOvum   =(this.chkOvum.Checked ==true? "1":"0");
			m_objSPECT.strPaymentCompany   =(this.chkPaymentCompany.Checked ==true? "1":"0");
			m_objSPECT.strPaymentPulbic =(this.chkPaymentPulbic.Checked ==true? "1":"0");
			
			m_objSPECT.strPaymentSelf   =(this.chkPaymentSelf.Checked ==true? "1":"0");
			m_objSPECT.strPneumonicdAerate    =(this.chkPneumonicdAerate.Checked ==true? "1":"0");
			m_objSPECT.strPneumonicdknub  =(this.chkPneumonicdknub.Checked ==true? "1":"0");
			m_objSPECT.strPneumonicdBlood  =(this.chkPneumonicdBlood.Checked ==true? "1":"0");
			
			m_objSPECT.strPulse=(this.chkPulse.Checked ==true? "1":"0");
			m_objSPECT.strSpleen=(this.chkSpleen.Checked ==true? "1":"0");
			m_objSPECT.strTear=(this.chkTear.Checked ==true? "1":"0");
			m_objSPECT.strTell=(this.chkTell.Checked ==true? "1":"0");

			m_objSPECT.strCheckLab=this.txtCheckLab.Text;
			m_objSPECT.strCheckNO=this.txtCheckNO.Text.Trim() ;
			m_objSPECT.strDisgonse=this.txtDisgonse.Text;
			
			
			m_objSPECT.strHistory =this.txtHistory.Text;
			m_objSPECT.strTellContent=this.txtTell.Text;

			m_objSPECT.strStatus ="0";
			m_objSPECT.strIfConfirm  ="0";


            m_objSPECT.strCreateUserID = ((clsEmrEmployeeBase_VO)m_txtSign.Tag).m_strEMPID_CHR;
			if(blnIsAddNew==true)
			{	
				//				m_objSPECT.strCreateUserID =MDIParent.OperatorID;
                m_objSPECT.strInPatientDate = m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate.ToString("yyyy-MM-dd HH:mm:ss");
                m_objSPECT.strInPatientID = m_ObjCurrentEmrPatientSession.m_strEMRInpatientId;
				m_objSPECT.strCreateDate =this.dtpApplyTime.Value.ToString("yyyy-MM-dd HH:mm:ss"); 
			}

			return m_objSPECT;
		}

     
		private void chkTell_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chkTell.Checked)
				txtTell.ReadOnly=false;
			else 
			{
				txtTell.ReadOnly=true;
				txtTell.Text="";
			}
		
		}
		

		private void m_mthReadOnly(bool blnIsReadOnly)
		{
			if(blnIsReadOnly)
			{
				foreach(Control ctlRichText in this.Controls )
				{
					string typeName = ctlRichText.GetType().Name;
					if(typeName =="CheckBox")
					{
						((CheckBox)ctlRichText).Enabled=false;
						//						((CheckBox)ctlRichText).ForeColor=Color.White;

					}
					if(typeName == "RichTextBox") ((RichTextBox)ctlRichText).ReadOnly=true;
					if(typeName =="ctlBorderTextBox" && ctlRichText.Name!="txtInPatientID" && ctlRichText.Name != "m_txtBedNO" && ctlRichText.Name != "m_txtPatientName")
						ctlRichText.Enabled=false;
					this.txtCheckNO.Enabled =false;
					blnCanDelete=false;
				}
			}
			else
			{
				foreach(Control ctlRichText in this.Controls )
				{
					string typeName = ctlRichText.GetType().Name;
					if(typeName =="CheckBox")
						((CheckBox)ctlRichText).Enabled=true;
					if(typeName == "RichTextBox") ((RichTextBox)ctlRichText).ReadOnly=false;
					if(typeName =="ctlBorderTextBox" && ctlRichText.Name!="txtInPatientID")
						ctlRichText.Enabled=true;
					this.txtCheckNO.Enabled =true;
					blnCanDelete=true;
				}

			}
		}
       
		
		#region 添加键盘快捷键
		private void m_mthSetQuickKeys()
		{			
			m_mthSetControlEvent(this);			
		}
		
		private void m_mthSetControlEvent(Control p_ctlControl)
		{
			#region 利用递归调用，读取并设置所有界面事件	
			string strTypeName = p_ctlControl.GetType().Name;
			if(strTypeName != "Lable" && strTypeName != "Button")
			{
				p_ctlControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthEvent_KeyDown);
				if(p_ctlControl.HasChildren && strTypeName !="DataGrid" && strTypeName !="DateTimePicker" && strTypeName !="ctlComboBox")
				{									
					foreach(Control subcontrol in p_ctlControl.Controls)
					{				
						string strSubTypeName = subcontrol.GetType().Name;
						if(strSubTypeName != "Lable" && strSubTypeName != "Button")												
							m_mthSetControlEvent(subcontrol);						
					} 	
				}				
			}			
			#endregion
		}
		
		private void m_mthEvent_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch(e.KeyValue)
			{//F1 112  帮助, F2 113 Save，F3  114 Del，F4 115 Print，F5 116 Refresh，F6 117 Search
				case 13:// enter
					//					if(((Control)sender).Name!="txtHistory" &&
					//						((Control)sender).Name!="txtCheckLab" &&
					//						((Control)sender).Name!="m_txtPatientName" &&
					//						((Control)sender).Name!="txtInPatientID" )
					//						SendKeys.Send(  "{tab}"); 
					
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
					blnCanSearch =false;
					this.txtInPatientID.Text ="";
					blnCanSearch =true;
					this.lblAddressContent.Text="";
					this.lblTelContent.Text="";
					m_mthClearPatientBaseInfo();
					m_mthClearUpSheet();
					m_mthReadOnly(false);
					m_objSPECT=null;
					m_objCurrentPatient=null;
                
					this.trvTime.Nodes[0].Nodes .Clear ();
					break;
				case 117://Search					
					break;
			}	
		}

		#endregion
	
		#region 打印
		/*
* DataSet : dtsSPECTCheck
* DataTable : dtbSPECT
* 	DataColumn : CreateDate(string)
* 	DataColumn : CheckNO(string)
* 	DataColumn : PaymentPulbic(string)
* 	DataColumn : PaymentCompany(string)
* 	DataColumn : PaymentSelf(string)
* 	DataColumn : InPatientID(string)
* 	DataColumn : PatientName(string)
* 	DataColumn : PatientSex(string)
* 	DataColumn : PatientAge(string)
* 	DataColumn : PatientDepartment(string)
* 	DataColumn : PatientBed(string)
* 	DataColumn : PatientAdress(string)
* 	DataColumn : PatientContactPhone(string)
* 	DataColumn : HypothyroidDisply(string)
* 	DataColumn : HypothyroidKnubDisply(string)
* 	DataColumn : KidneyDisply(string)
* 	DataColumn : HypothyroidCancer(string)
* 	DataColumn : hypothyroidside(string)
* 	DataColumn : PneumonicdAerate(string)
* 	DataColumn : PneumonicdBlood(string)
* 	DataColumn : Pneumonicdknub(string)
* 	DataColumn : Heart(string)
* 	DataColumn : HeartBlood(string)
* 	DataColumn : DBody(string)
* 	DataColumn : Body(string)
* 	DataColumn : Bone(string)
* 	DataColumn : BoneTr(string)
* 	DataColumn : Courage(string)
* 	DataColumn : CourageFaultage(string)
* 	DataColumn : CouragePool(string)
* 	DataColumn : Pulse(string)
* 	DataColumn : Meikl(string)
* 	DataColumn : Esophagus(string)
* 	DataColumn : Enteron(string)
* 	DataColumn : Overbody(string)
* 	DataColumn : Spleen(string)
* 	DataColumn : Lymph(string)
* 	DataColumn : DepCancer(string)
* 	DataColumn : OverCancer(string)
* 	DataColumn : Metabolize(string)
* 	DataColumn : BrainMetabolize(string)
* 	DataColumn : KidneyDin(string)
* 	DataColumn : KidneyStr(string)
* 	DataColumn : KidneyBall(string)
* 	DataColumn : KidneyBlood(string)
* 	DataColumn : Bladder(string)
* 	DataColumn : BloodPool(string)
* 	DataColumn : Ovum(string)
* 	DataColumn : BreastCancer(string)
* 	DataColumn : BrainCancer(string)
* 	DataColumn : BrainBlood(string)
* 	DataColumn : Tear(string)
* 	DataColumn : Nose(string)
* 	DataColumn : Tell(string)
* 	DataColumn : History(string)
* 	DataColumn : CheckLab(string)
* 	DataColumn : Disgonse(string)
* 	DataColumn : CreateUser(string)
*/ 
		private DataSet m_dtsInitdtsSPECTCheckDataSet()
		{
			DataSet dsdtsSPECTCheck = new DataSet("dtsSPECTCheck");

			DataTable dtdtbSPECT = new DataTable("dtbSPECT");

			DataColumn dcdtbSPECTCreateDate = new DataColumn("CreateDate",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTCreateDate);

			DataColumn dcdtbSPECTCheckNO = new DataColumn("CheckNO",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTCheckNO);

			DataColumn dcdtbSPECTPaymentPulbic = new DataColumn("PaymentPulbic",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTPaymentPulbic);

			DataColumn dcdtbSPECTPaymentCompany = new DataColumn("PaymentCompany",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTPaymentCompany);

			DataColumn dcdtbSPECTPaymentSelf = new DataColumn("PaymentSelf",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTPaymentSelf);

			DataColumn dcdtbSPECTInPatientID = new DataColumn("InPatientID",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTInPatientID);

			DataColumn dcdtbSPECTPatientName = new DataColumn("PatientName",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTPatientName);

			DataColumn dcdtbSPECTPatientSex = new DataColumn("PatientSex",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTPatientSex);

			DataColumn dcdtbSPECTPatientAge = new DataColumn("PatientAge",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTPatientAge);

			DataColumn dcdtbSPECTPatientDepartment = new DataColumn("PatientDepartment",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTPatientDepartment);

			DataColumn dcdtbSPECTPatientBed = new DataColumn("PatientBed",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTPatientBed);

			DataColumn dcdtbSPECTPatientAdress = new DataColumn("PatientAdress",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTPatientAdress);

			DataColumn dcdtbSPECTPatientContactPhone = new DataColumn("PatientContactPhone",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTPatientContactPhone);

			DataColumn dcdtbSPECTHypothyroidDisply = new DataColumn("HypothyroidDisply",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTHypothyroidDisply);

			DataColumn dcdtbSPECTHypothyroidKnubDisply = new DataColumn("HypothyroidKnubDisply",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTHypothyroidKnubDisply);

			DataColumn dcdtbSPECTKidneyDisply = new DataColumn("KidneyDisply",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTKidneyDisply);

			DataColumn dcdtbSPECTHypothyroidCancer = new DataColumn("HypothyroidCancer",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTHypothyroidCancer);

			DataColumn dcdtbSPECThypothyroidside = new DataColumn("hypothyroidside",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECThypothyroidside);

			DataColumn dcdtbSPECTPneumonicdAerate = new DataColumn("PneumonicdAerate",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTPneumonicdAerate);

			DataColumn dcdtbSPECTPneumonicdBlood = new DataColumn("PneumonicdBlood",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTPneumonicdBlood);

			DataColumn dcdtbSPECTPneumonicdknub = new DataColumn("Pneumonicdknub",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTPneumonicdknub);

			DataColumn dcdtbSPECTHeart = new DataColumn("Heart",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTHeart);

			DataColumn dcdtbSPECTHeartBlood = new DataColumn("HeartBlood",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTHeartBlood);

			DataColumn dcdtbSPECTDBody = new DataColumn("DBody",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTDBody);

			DataColumn dcdtbSPECTBody = new DataColumn("Body",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTBody);

			DataColumn dcdtbSPECTBone = new DataColumn("Bone",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTBone);

			DataColumn dcdtbSPECTBoneTr = new DataColumn("BoneTr",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTBoneTr);

			DataColumn dcdtbSPECTCourage = new DataColumn("Courage",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTCourage);

			DataColumn dcdtbSPECTCourageFaultage = new DataColumn("CourageFaultage",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTCourageFaultage);

			DataColumn dcdtbSPECTCouragePool = new DataColumn("CouragePool",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTCouragePool);

			DataColumn dcdtbSPECTPulse = new DataColumn("Pulse",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTPulse);

			DataColumn dcdtbSPECTMeikl = new DataColumn("Meikl",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTMeikl);

			DataColumn dcdtbSPECTEsophagus = new DataColumn("Esophagus",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTEsophagus);

			DataColumn dcdtbSPECTEnteron = new DataColumn("Enteron",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTEnteron);

			DataColumn dcdtbSPECTOverbody = new DataColumn("Overbody",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTOverbody);

			DataColumn dcdtbSPECTSpleen = new DataColumn("Spleen",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTSpleen);

			DataColumn dcdtbSPECTLymph = new DataColumn("Lymph",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTLymph);

			DataColumn dcdtbSPECTDepCancer = new DataColumn("DepCancer",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTDepCancer);

			DataColumn dcdtbSPECTOverCancer = new DataColumn("OverCancer",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTOverCancer);

			DataColumn dcdtbSPECTMetabolize = new DataColumn("Metabolize",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTMetabolize);

			DataColumn dcdtbSPECTBrainMetabolize = new DataColumn("BrainMetabolize",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTBrainMetabolize);

			DataColumn dcdtbSPECTKidneyDin = new DataColumn("KidneyDin",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTKidneyDin);

			DataColumn dcdtbSPECTKidneyStr = new DataColumn("KidneyStr",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTKidneyStr);

			DataColumn dcdtbSPECTKidneyBall = new DataColumn("KidneyBall",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTKidneyBall);

			DataColumn dcdtbSPECTKidneyBlood = new DataColumn("KidneyBlood",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTKidneyBlood);

			DataColumn dcdtbSPECTBladder = new DataColumn("Bladder",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTBladder);

			DataColumn dcdtbSPECTBloodPool = new DataColumn("BloodPool",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTBloodPool);

			DataColumn dcdtbSPECTOvum = new DataColumn("Ovum",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTOvum);

			DataColumn dcdtbSPECTBreastCancer = new DataColumn("BreastCancer",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTBreastCancer);

			DataColumn dcdtbSPECTBrainCancer = new DataColumn("BrainCancer",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTBrainCancer);

			DataColumn dcdtbSPECTBrainBlood = new DataColumn("BrainBlood",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTBrainBlood);

			DataColumn dcdtbSPECTTear = new DataColumn("Tear",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTTear);

			DataColumn dcdtbSPECTNose = new DataColumn("Nose",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTNose);

			DataColumn dcdtbSPECTTell = new DataColumn("Tell",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTTell);

			DataColumn dcdtbSPECTHistory = new DataColumn("History",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTHistory);

			DataColumn dcdtbSPECTCheckLab = new DataColumn("CheckLab",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTCheckLab);

			DataColumn dcdtbSPECTDisgonse = new DataColumn("Disgonse",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTDisgonse);

			DataColumn dcdtbSPECTCreateUser = new DataColumn("CreateUser",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTCreateUser);
			DataColumn dcdtbSPECTTellContent = new DataColumn("TellContent",typeof(string));

			dtdtbSPECT.Columns.Add(dcdtbSPECTTellContent);

			dsdtsSPECTCheck.Tables.Add(dtdtbSPECT);

			return dsdtsSPECTCheck;
		}

		/*
		* DataSet : dtsSPECTCheck
		* DataTable : dtbSPECT
		* 	DataColumn 0: CreateDate(string)
		* 	DataColumn 1: CheckNO(string)
		* 	DataColumn 2: PaymentPulbic(string)
		* 	DataColumn 3: PaymentCompany(string)
		* 	DataColumn 4: PaymentSelf(string)
		* 	DataColumn 5: InPatientID(string)
		* 	DataColumn 6: PatientName(string)
		* 	DataColumn 7: PatientSex(string)
		* 	DataColumn 8: PatientAge(string)
		* 	DataColumn 9: PatientDepartment(string)
		* 	DataColumn 10: PatientBed(string)
		* 	DataColumn 11: PatientAdress(string)
		* 	DataColumn 12: PatientContactPhone(string)
		* 	DataColumn 13: HypothyroidDisply(string)
		* 	DataColumn 14: HypothyroidKnubDisply(string)
		* 	DataColumn 15: KidneyDisply(string)
		* 	DataColumn 16: HypothyroidCancer(string)
		* 	DataColumn 17: hypothyroidside(string)
		* 	DataColumn 18: PneumonicdAerate(string)
		* 	DataColumn 19: PneumonicdBlood(string)
		* 	DataColumn 20: Pneumonicdknub(string)
		* 	DataColumn 21: Heart(string)
		* 	DataColumn 22: HeartBlood(string)
		* 	DataColumn 23: DBody(string)
		* 	DataColumn 24: Body(string)
		* 	DataColumn 25: Bone(string)
		* 	DataColumn 26: BoneTr(string)
		* 	DataColumn 27: Courage(string)
		* 	DataColumn 28: CourageFaultage(string)
		* 	DataColumn 29: CouragePool(string)
		* 	DataColumn 30: Pulse(string)
		* 	DataColumn 31: Meikl(string)
		* 	DataColumn 32: Esophagus(string)
		* 	DataColumn 33: Enteron(string)
		* 	DataColumn 34: Overbody(string)
		* 	DataColumn 35: Spleen(string)
		* 	DataColumn 36: Lymph(string)
		* 	DataColumn 37: DepCancer(string)
		* 	DataColumn 38: OverCancer(string)
		* 	DataColumn 39: Metabolize(string)
		* 	DataColumn 40: BrainMetabolize(string)
		* 	DataColumn 41: KidneyDin(string)
		* 	DataColumn 42: KidneyStr(string)
		* 	DataColumn 43: KidneyBall(string)
		* 	DataColumn 44: KidneyBlood(string)
		* 	DataColumn 45: Bladder(string)
		* 	DataColumn 46: BloodPool(string)
		* 	DataColumn 47: Ovum(string)
		* 	DataColumn 48: BreastCancer(string)
		* 	DataColumn 49: BrainCancer(string)
		* 	DataColumn 50: BrainBlood(string)
		* 	DataColumn 51: Tear(string)
		* 	DataColumn 52: Nose(string)
		* 	DataColumn 53: Tell(string)
		* 	DataColumn 54: History(string)
		* 	DataColumn 55: CheckLab(string)
		* 	DataColumn 56: Disgonse(string)
		* 	DataColumn 57: CreateUser(string)
		*/ 
		private void m_mthAddNewDataFordtsSPECTCheckDataSet(DataSet dsdtsSPECTCheck)
		{
			DataTable dtdtbSPECT = dsdtsSPECTCheck.Tables["DTBSPECT"];
			dtdtbSPECT.Rows.Clear();

			

			object [] objdtbSPECTDatas = new object[59];
		
			if(m_objSPECT!=null)
			{
				objdtbSPECTDatas[0] =DateTime.Parse(m_objSPECT.strCreateDate).ToString("yyyy年MM月dd日");
				objdtbSPECTDatas[1] =m_objSPECT.strCheckNO;
				objdtbSPECTDatas[2] =(m_objSPECT.strPaymentPulbic=="True"||m_objSPECT.strPaymentPulbic=="1"? "√":"") ;
				objdtbSPECTDatas[3] =(m_objSPECT.strPaymentCompany=="True"||m_objSPECT.strPaymentCompany=="1"? "√":"") ;
				objdtbSPECTDatas[4] =(m_objSPECT.strPaymentSelf=="True"||m_objSPECT.strPaymentSelf=="1"? "√":"") ;
                objdtbSPECTDatas[5] = m_ObjCurrentEmrPatientSession.m_strHISInpatientId;
				objdtbSPECTDatas[6] =m_objCurrentPatient.m_ObjPeopleInfo.m_StrFirstName ;
				objdtbSPECTDatas[7] =m_objCurrentPatient.m_ObjPeopleInfo.m_StrSex;
				objdtbSPECTDatas[8] =m_objCurrentPatient.m_ObjPeopleInfo.m_StrAge;
                if (m_ObjCurrentEmrPatientSession != null)
                {
                    objdtbSPECTDatas[9] = m_ObjCurrentEmrPatientSession.m_strAreaName;
                }
                else
                {
                    objdtbSPECTDatas[9] = string.Empty; 
                }
                if (m_ObjCurrentBed != null)
                {
                    objdtbSPECTDatas[10] = m_ObjCurrentBed.m_strCODE_CHR;
                }
                else
                {
                    objdtbSPECTDatas[10] = string.Empty;
                }
				objdtbSPECTDatas[11] =m_objCurrentPatient.m_ObjPeopleInfo.m_StrHomeAddress;
				objdtbSPECTDatas[12] =m_objCurrentPatient.m_ObjPeopleInfo.m_StrHomePhone;
				objdtbSPECTDatas[13] =(m_objSPECT.strHypothyroidDisply=="True"||m_objSPECT.strHypothyroidDisply=="1"? "√":"") ;
				objdtbSPECTDatas[14] =(m_objSPECT.strHypothyroidKnubDisply=="True"||m_objSPECT.strHypothyroidKnubDisply=="1"? "√":"") ;
				objdtbSPECTDatas[15] =(m_objSPECT.strKidneyDisply=="True"||m_objSPECT.strKidneyDisply=="1"? "√":"") ;
				objdtbSPECTDatas[16] =(m_objSPECT.strHypothyroidCancer=="True"||m_objSPECT.strHypothyroidCancer=="1"? "√":"") ;
				objdtbSPECTDatas[17] =(m_objSPECT.strhypothyroidside=="True"||m_objSPECT.strhypothyroidside=="1"? "√":"") ;
				objdtbSPECTDatas[18] =(m_objSPECT.strPneumonicdAerate=="True"||m_objSPECT.strPneumonicdAerate=="1"? "√":"") ;
				objdtbSPECTDatas[19] =(m_objSPECT.strPneumonicdBlood=="True"||m_objSPECT.strPneumonicdBlood=="1"? "√":"") ;
				objdtbSPECTDatas[20] =(m_objSPECT.strPneumonicdknub=="True"||m_objSPECT.strPneumonicdknub=="1"? "√":"") ;
				objdtbSPECTDatas[21] =(m_objSPECT.strHeart=="True"||m_objSPECT.strHeart=="1"? "√":"") ;
				objdtbSPECTDatas[22] =(m_objSPECT.strHeartBlood=="True"||m_objSPECT.strHeartBlood=="1"? "√":"") ;
				objdtbSPECTDatas[23] =(m_objSPECT.strDBody=="True"||m_objSPECT.strDBody=="1"? "√":"") ;
				objdtbSPECTDatas[24] =(m_objSPECT.strBody=="True"||m_objSPECT.strBody=="1"? "√":"") ;
				objdtbSPECTDatas[25] =(m_objSPECT.strBone=="True"||m_objSPECT.strBone=="1"? "√":"") ;
				objdtbSPECTDatas[26] =(m_objSPECT.strBoneTr=="True"||m_objSPECT.strBoneTr=="1"? "√":"") ;
				objdtbSPECTDatas[27] =(m_objSPECT.strCourage=="True"||m_objSPECT.strCourage=="1"? "√":"") ;
				objdtbSPECTDatas[28] =(m_objSPECT.strCourageFaultage=="True"||m_objSPECT.strCourageFaultage=="1"? "√":"") ;
				objdtbSPECTDatas[29] =(m_objSPECT.strCouragePool=="True"||m_objSPECT.strCouragePool=="1"? "√":"") ;
				objdtbSPECTDatas[30] =(m_objSPECT.strPulse=="True"||m_objSPECT.strPulse=="1"? "√":"") ;
				objdtbSPECTDatas[31] =(m_objSPECT.strMeikl=="True"||m_objSPECT.strMeikl=="1"? "√":"") ;
				objdtbSPECTDatas[32] =(m_objSPECT.strEsophagus=="True"||m_objSPECT.strEsophagus=="1"? "√":"") ;
				objdtbSPECTDatas[33] =(m_objSPECT.strEnteron=="True"||m_objSPECT.strEnteron=="1"? "√":"") ;
				objdtbSPECTDatas[34] =(m_objSPECT.strOverbody=="True"||m_objSPECT.strOverbody=="1"? "√":"") ;
				objdtbSPECTDatas[35] =(m_objSPECT.strSpleen=="True"||m_objSPECT.strSpleen=="1"? "√":"") ;
				objdtbSPECTDatas[36] =(m_objSPECT.strLymph=="True"||m_objSPECT.strLymph=="1"? "√":"") ;
				objdtbSPECTDatas[37] =(m_objSPECT.strDepCancer=="True"||m_objSPECT.strDepCancer=="1"? "√":"") ;
				objdtbSPECTDatas[38] =(m_objSPECT.strOverCancer=="True"||m_objSPECT.strOverCancer=="1"? "√":"") ;
				objdtbSPECTDatas[39] =(m_objSPECT.strMetabolize=="True"||m_objSPECT.strMetabolize=="1"? "√":"") ;
				objdtbSPECTDatas[40] =(m_objSPECT.strBrainMetabolize=="True"||m_objSPECT.strBrainMetabolize=="1"? "√":"") ;
				objdtbSPECTDatas[41] =(m_objSPECT.strKidneyDin=="True"||m_objSPECT.strKidneyDin=="1"? "√":"") ;
				objdtbSPECTDatas[42] =(m_objSPECT.strKidneyStr=="True"||m_objSPECT.strKidneyStr=="1"? "√":"") ;
				objdtbSPECTDatas[43] =(m_objSPECT.strKidneyBall=="True"||m_objSPECT.strKidneyBall=="1"? "√":"") ;
				objdtbSPECTDatas[44] =(m_objSPECT.strKidneyBlood=="True"||m_objSPECT.strKidneyBlood=="1"? "√":"") ;
				objdtbSPECTDatas[45] =(m_objSPECT.strBladder=="True"||m_objSPECT.strBladder=="1"? "√":"") ;
				objdtbSPECTDatas[46] =(m_objSPECT.strBloodPool=="True"||m_objSPECT.strBloodPool=="1"? "√":"") ;
				objdtbSPECTDatas[47] =(m_objSPECT.strOvum=="True"||m_objSPECT.strOvum=="1"? "√":"") ;
				objdtbSPECTDatas[48] =(m_objSPECT.strBreastCancer=="True"||m_objSPECT.strBreastCancer=="1"? "√":"") ;
				objdtbSPECTDatas[49] =(m_objSPECT.strBrainCancer=="True"||m_objSPECT.strBrainCancer=="1"? "√":"") ;
				objdtbSPECTDatas[50] =(m_objSPECT.strBrainBlood=="True"||m_objSPECT.strBrainBlood=="1"? "√":"") ;
		
				objdtbSPECTDatas[51] =(m_objSPECT.strTear=="True"||m_objSPECT.strTear=="1"? "√":"") ;
				objdtbSPECTDatas[52] =(m_objSPECT.strNose=="True"||m_objSPECT.strNose=="1"? "√":"") ;
				objdtbSPECTDatas[53] =(m_objSPECT.strTell=="True"||m_objSPECT.strTell=="1"? "√":"") ;
				objdtbSPECTDatas[54] =m_objSPECT.strHistory ;
				objdtbSPECTDatas[55] =m_objSPECT.strCheckLab;
				objdtbSPECTDatas[56] =m_objSPECT.strDisgonse ;
				objdtbSPECTDatas[57] = m_txtSign.Text;
				objdtbSPECTDatas[58] =m_objSPECT.strTellContent ;
			}
			else 
			{
				for(int i=0;i<objdtbSPECTDatas.Length-1;i++)
					objdtbSPECTDatas[i]="";
			}

			dtdtbSPECT.Rows.Add(objdtbSPECTDatas);
			m_rpdOrderRept.Database.Tables["DTBSPECT"].SetDataSource(dtdtbSPECT);

			m_rpdOrderRept.Refresh();
		
						
		}
		#endregion 

		private void tabControl2_SelectionChanged(object sender, System.EventArgs e)
		{
		
		}

        protected override void m_mthPerformSessionChanged(clsEmrPatientSessionInfo_VO p_objSelectedSession, int p_intIndex)
        {
            m_mthClearUpSheet();

            if (p_objSelectedSession == null)
            {
                return;
            }

            m_objCurrentPatient = m_objBaseCurrentPatient;

            m_objCurrentPatient.m_DtmSelectedInDate = p_objSelectedSession.m_dtmEMRInpatientDate;
            m_objCurrentPatient.m_StrHISInPatientID = p_objSelectedSession.m_strHISInpatientId;
            m_objCurrentPatient.m_DtmSelectedHISInDate = p_objSelectedSession.m_dtmHISInpatientDate;
            m_objCurrentPatient.m_StrRegisterId = p_objSelectedSession.m_strRegisterId;

            m_mthIsReadOnly();

            if (!m_blnCanShowRecordContent())
            {
                clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                return;
            }

            m_mthLoadAllTimeOfAPatient(p_objSelectedSession.m_strEMRInpatientId, p_objSelectedSession.m_dtmEMRInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"));
        }

	}
}

