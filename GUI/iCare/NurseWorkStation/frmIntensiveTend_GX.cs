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
using System.Xml;
using com.digitalwave.clsIntensiveTendRecord_GXService;
using System.Threading;
using com.digitalwave.Emr.Signature_gui;
namespace iCare
{
	/// <summary>
	/// 危重患者护理记录(广西)
	/// </summary>
	public class frmIntensiveTend_GX : frmDiseaseTrackBase
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
		private PinkieControls.ButtonXP m_cmdOK;
		private PinkieControls.ButtonXP m_cmdCancel;
		private clsEmployeeSignTool m_objSignTool;
		private com.digitalwave.controls.ctlRichTextBox m_txtInItem;
		private com.digitalwave.controls.ctlRichTextBox m_txtInFact;
		private com.digitalwave.controls.ctlRichTextBox m_txtOutPiss;
		private com.digitalwave.controls.ctlRichTextBox m_txtOutStool;
		private com.digitalwave.controls.ctlRichTextBox m_txtCheckT;
		private com.digitalwave.controls.ctlRichTextBox m_txtCheckP;
		private com.digitalwave.controls.ctlRichTextBox m_txtCheckR;
		private com.digitalwave.controls.ctlRichTextBox m_txtBPA;
		private com.digitalwave.controls.ctlRichTextBox m_txtBPS;
		private string m_strDiagnose;
        //private clsIntensiveTendRecord_GXService objServ;
		private clsCommonUseToolCollection m_objCUTC;
		private com.digitalwave.controls.ctlRichTextBox m_txtCustom1;
		private System.Windows.Forms.Label m_lblCustom1;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label25;
		private com.digitalwave.controls.ctlRichTextBox m_txtCustom2;
		private System.Windows.Forms.Label m_lblCustom2;
		private com.digitalwave.controls.ctlRichTextBox m_txtCustom3;
		private System.Windows.Forms.Label m_lblCustom3;
		private com.digitalwave.controls.ctlRichTextBox m_txtCustom4;
		private System.Windows.Forms.Label m_lblCustom4;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox m_txtSumIn;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label m_lblThisStatTime;
		private System.Windows.Forms.TextBox m_txtSumInTime;
		private System.Windows.Forms.TextBox m_txtSumOutTime;
		private System.Windows.Forms.TextBox m_txtSumOut;
        private clsIntensiveTendRecord_GX[] m_objRecordArr = null;
		private System.Windows.Forms.CheckBox m_chkIfSum;
		private System.Windows.Forms.Label m_lblHasStatTips;
		private com.digitalwave.Utility.Controls.ctlTimePicker m_dtpLastStatTime;
		/// <summary>
		/// 初始的当前记录总入量
		/// </summary>
		private double m_dblOriSumInFromDB = 0;
		/// <summary>
		/// 初始的当前记录的总出量
		/// </summary>
		private double m_dblOriSumOutFromDB = 0;
		/// <summary>
		/// 初始的自动累加的总入量
		/// </summary>
		private double m_dblOriAutoSumIn = 0;
		/// <summary>
		/// 初始的自动累加的总出量
		/// </summary>
		private double m_dblOriAutoSumOut = 0;
		/// <summary>
		/// 初始的界面上的总入量
		/// </summary>
		private double m_dblSumInGUI = 0;
		/// <summary>
		/// 初始的界面上的总出量
		/// </summary>
		private double m_dblSumOutGUI = 0;
        private TextBox txtSign;
        private PinkieControls.ButtonXP m_cmbsign;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
        //定义签名类
        private clsEmrSignToolCollection m_objSign;
		public frmIntensiveTend_GX()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
            //签名常用值
            m_objSign = new clsEmrSignToolCollection();

            //可以指定员工ID如
            m_objSign.m_mthBindEmployeeSign(m_cmbsign, txtSign, 2, true, clsEMRLogin.LoginInfo.m_strEmpID);

            //m_objSignTool = new clsEmployeeSignTool(m_lsvEmployee);
            //m_objSignTool.m_mthAddControl(m_txtNurseSign);
            //m_objCUTC = new clsCommonUseToolCollection(this);
            //m_objCUTC.m_mthBindEmployeeSign(m_cmdSign,m_txtNurseSign,2); 

            //objServ = new clsIntensiveTendRecord_GXService();
            m_mthSetRichTextBoxAttribInControl(this);
		}

		public frmIntensiveTend_GX(string p_strDiagnose) : this()
		{
            m_strDiagnose = p_strDiagnose;
            m_mthThisAddRichTextInfo(this);
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
				return 82;
			}
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.m_txtInItem = new com.digitalwave.controls.ctlRichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtInFact = new com.digitalwave.controls.ctlRichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_txtOutPiss = new com.digitalwave.controls.ctlRichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_txtOutStool = new com.digitalwave.controls.ctlRichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.m_txtCustom1 = new com.digitalwave.controls.ctlRichTextBox();
            this.m_lblCustom1 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.m_txtCustom2 = new com.digitalwave.controls.ctlRichTextBox();
            this.m_lblCustom2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_txtCustom3 = new com.digitalwave.controls.ctlRichTextBox();
            this.m_lblCustom3 = new System.Windows.Forms.Label();
            this.m_txtCustom4 = new com.digitalwave.controls.ctlRichTextBox();
            this.m_lblCustom4 = new System.Windows.Forms.Label();
            this.m_txtCheckT = new com.digitalwave.controls.ctlRichTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.m_txtCheckP = new com.digitalwave.controls.ctlRichTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.m_txtCheckR = new com.digitalwave.controls.ctlRichTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.m_txtBPA = new com.digitalwave.controls.ctlRichTextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.m_txtBPS = new com.digitalwave.controls.ctlRichTextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.m_cmdOK = new PinkieControls.ButtonXP();
            this.m_cmdCancel = new PinkieControls.ButtonXP();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.m_txtSumInTime = new System.Windows.Forms.TextBox();
            this.m_txtSumOutTime = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.m_txtSumIn = new System.Windows.Forms.TextBox();
            this.m_txtSumOut = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.m_lblThisStatTime = new System.Windows.Forms.Label();
            this.m_chkIfSum = new System.Windows.Forms.CheckBox();
            this.m_lblHasStatTips = new System.Windows.Forms.Label();
            this.m_dtpLastStatTime = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.txtSign = new System.Windows.Forms.TextBox();
            this.m_cmbsign = new PinkieControls.ButtonXP();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_trvCreateDate
            // 
            this.m_trvCreateDate.LineColor = System.Drawing.Color.Black;
            this.m_trvCreateDate.Location = new System.Drawing.Point(40, -144);
            this.m_trvCreateDate.Size = new System.Drawing.Size(212, 116);
            this.m_trvCreateDate.Visible = false;
            // 
            // lblCreateDateTitle
            // 
            this.lblCreateDateTitle.Location = new System.Drawing.Point(6, 6);
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.Location = new System.Drawing.Point(78, 4);
            this.m_dtpCreateDate.TabIndex = 170;
            this.m_dtpCreateDate.evtValueChanged += new System.EventHandler(this.m_dtpCreateDate_evtValueChanged);
            // 
            // m_dtpGetDataTime
            // 
            this.m_dtpGetDataTime.Location = new System.Drawing.Point(336, -112);
            // 
            // m_lblGetDataTime
            // 
            this.m_lblGetDataTime.Location = new System.Drawing.Point(256, -96);
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(336, -88);
            this.lblSex.Size = new System.Drawing.Size(48, 47);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(448, -88);
            this.lblAge.Size = new System.Drawing.Size(52, 47);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(236, -136);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(224, -104);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(408, -136);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(288, -88);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(400, -88);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(32, -72);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(262, -98);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(280, -112);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(452, -144);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(280, -144);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(80, -80);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(452, -120);
            this.m_lsvPatientName.Size = new System.Drawing.Size(116, 120);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(280, -120);
            this.m_lsvBedNO.Size = new System.Drawing.Size(116, 120);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(80, -112);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(32, -104);
            this.lblDept.Visible = false;
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.Location = new System.Drawing.Point(196, -144);
            this.m_cmdNext.Size = new System.Drawing.Size(24, 49);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(156, -144);
            this.m_cmdPre.Size = new System.Drawing.Size(24, 49);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(272, -136);
            this.m_lblForTitle.Size = new System.Drawing.Size(16, 51);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(357, -34);
            // 
            // m_txtInItem
            // 
            this.m_txtInItem.AccessibleDescription = "入量>>项目";
            this.m_txtInItem.BackColor = System.Drawing.Color.White;
            this.m_txtInItem.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtInItem.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtInItem.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtInItem.Location = new System.Drawing.Point(64, 20);
            this.m_txtInItem.m_BlnIgnoreUserInfo = false;
            this.m_txtInItem.m_BlnPartControl = false;
            this.m_txtInItem.m_BlnReadOnly = false;
            this.m_txtInItem.m_BlnUnderLineDST = false;
            this.m_txtInItem.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtInItem.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtInItem.m_IntCanModifyTime = 6;
            this.m_txtInItem.m_IntPartControlLength = 0;
            this.m_txtInItem.m_IntPartControlStartIndex = 0;
            this.m_txtInItem.m_StrUserID = "";
            this.m_txtInItem.m_StrUserName = "";
            this.m_txtInItem.MaxLength = 8000;
            this.m_txtInItem.Multiline = false;
            this.m_txtInItem.Name = "m_txtInItem";
            this.m_txtInItem.Size = new System.Drawing.Size(144, 22);
            this.m_txtInItem.TabIndex = 10;
            this.m_txtInItem.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.m_txtInItem);
            this.groupBox1.Controls.Add(this.m_txtInFact);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(6, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 76);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "入量";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "项  目:";
            // 
            // m_txtInFact
            // 
            this.m_txtInFact.AccessibleDescription = "入量>>实入量";
            this.m_txtInFact.BackColor = System.Drawing.Color.White;
            this.m_txtInFact.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtInFact.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtInFact.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtInFact.Location = new System.Drawing.Point(64, 46);
            this.m_txtInFact.m_BlnIgnoreUserInfo = false;
            this.m_txtInFact.m_BlnPartControl = false;
            this.m_txtInFact.m_BlnReadOnly = false;
            this.m_txtInFact.m_BlnUnderLineDST = false;
            this.m_txtInFact.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtInFact.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtInFact.m_IntCanModifyTime = 6;
            this.m_txtInFact.m_IntPartControlLength = 0;
            this.m_txtInFact.m_IntPartControlStartIndex = 0;
            this.m_txtInFact.m_StrUserID = "";
            this.m_txtInFact.m_StrUserName = "";
            this.m_txtInFact.MaxLength = 8000;
            this.m_txtInFact.Multiline = false;
            this.m_txtInFact.Name = "m_txtInFact";
            this.m_txtInFact.Size = new System.Drawing.Size(120, 22);
            this.m_txtInFact.TabIndex = 20;
            this.m_txtInFact.Text = "";
            this.m_txtInFact.Leave += new System.EventHandler(this.m_txtNum_Leave);
            this.m_txtInFact.MouseLeave += new System.EventHandler(this.m_evtNum_MouseLeave);
            this.m_txtInFact.TextChanged += new System.EventHandler(this.m_txtInFact_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "实入量:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(186, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "ml";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_txtOutPiss);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.m_txtOutStool);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.m_txtCustom1);
            this.groupBox2.Controls.Add(this.m_lblCustom1);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.m_txtCustom2);
            this.groupBox2.Controls.Add(this.m_lblCustom2);
            this.groupBox2.Location = new System.Drawing.Point(238, 38);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(330, 76);
            this.groupBox2.TabIndex = 10000007;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "出量";
            // 
            // m_txtOutPiss
            // 
            this.m_txtOutPiss.AccessibleDescription = "出量>>小便";
            this.m_txtOutPiss.BackColor = System.Drawing.Color.White;
            this.m_txtOutPiss.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOutPiss.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtOutPiss.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOutPiss.Location = new System.Drawing.Point(64, 20);
            this.m_txtOutPiss.m_BlnIgnoreUserInfo = false;
            this.m_txtOutPiss.m_BlnPartControl = false;
            this.m_txtOutPiss.m_BlnReadOnly = false;
            this.m_txtOutPiss.m_BlnUnderLineDST = false;
            this.m_txtOutPiss.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOutPiss.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOutPiss.m_IntCanModifyTime = 6;
            this.m_txtOutPiss.m_IntPartControlLength = 0;
            this.m_txtOutPiss.m_IntPartControlStartIndex = 0;
            this.m_txtOutPiss.m_StrUserID = "";
            this.m_txtOutPiss.m_StrUserName = "";
            this.m_txtOutPiss.MaxLength = 8000;
            this.m_txtOutPiss.Multiline = false;
            this.m_txtOutPiss.Name = "m_txtOutPiss";
            this.m_txtOutPiss.Size = new System.Drawing.Size(52, 22);
            this.m_txtOutPiss.TabIndex = 30;
            this.m_txtOutPiss.Text = "";
            this.m_txtOutPiss.Leave += new System.EventHandler(this.m_txtNum_Leave);
            this.m_txtOutPiss.MouseLeave += new System.EventHandler(this.m_evtNum_MouseLeave);
            this.m_txtOutPiss.TextChanged += new System.EventHandler(this.m_txtOut_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "小  便:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(120, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 14);
            this.label5.TabIndex = 0;
            this.label5.Text = "ml";
            // 
            // m_txtOutStool
            // 
            this.m_txtOutStool.AccessibleDescription = "出量>>大便";
            this.m_txtOutStool.BackColor = System.Drawing.Color.White;
            this.m_txtOutStool.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOutStool.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtOutStool.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOutStool.Location = new System.Drawing.Point(64, 46);
            this.m_txtOutStool.m_BlnIgnoreUserInfo = false;
            this.m_txtOutStool.m_BlnPartControl = false;
            this.m_txtOutStool.m_BlnReadOnly = false;
            this.m_txtOutStool.m_BlnUnderLineDST = false;
            this.m_txtOutStool.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOutStool.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOutStool.m_IntCanModifyTime = 6;
            this.m_txtOutStool.m_IntPartControlLength = 0;
            this.m_txtOutStool.m_IntPartControlStartIndex = 0;
            this.m_txtOutStool.m_StrUserID = "";
            this.m_txtOutStool.m_StrUserName = "";
            this.m_txtOutStool.MaxLength = 8000;
            this.m_txtOutStool.Multiline = false;
            this.m_txtOutStool.Name = "m_txtOutStool";
            this.m_txtOutStool.Size = new System.Drawing.Size(52, 22);
            this.m_txtOutStool.TabIndex = 40;
            this.m_txtOutStool.Text = "";
            this.m_txtOutStool.Leave += new System.EventHandler(this.m_txtNum_Leave);
            this.m_txtOutStool.MouseLeave += new System.EventHandler(this.m_evtNum_MouseLeave);
            this.m_txtOutStool.TextChanged += new System.EventHandler(this.m_txtOut_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 14);
            this.label6.TabIndex = 0;
            this.label6.Text = "大  便:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(120, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 14);
            this.label7.TabIndex = 0;
            this.label7.Text = "ml";
            // 
            // m_txtCustom1
            // 
            this.m_txtCustom1.AccessibleDescription = "出量>>自定义1";
            this.m_txtCustom1.BackColor = System.Drawing.Color.White;
            this.m_txtCustom1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCustom1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtCustom1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCustom1.Location = new System.Drawing.Point(248, 20);
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
            this.m_txtCustom1.Size = new System.Drawing.Size(52, 22);
            this.m_txtCustom1.TabIndex = 50;
            this.m_txtCustom1.Text = "";
            this.m_txtCustom1.Leave += new System.EventHandler(this.m_txtNum_Leave);
            this.m_txtCustom1.MouseLeave += new System.EventHandler(this.m_evtNum_MouseLeave);
            this.m_txtCustom1.TextChanged += new System.EventHandler(this.m_txtOut_TextChanged);
            // 
            // m_lblCustom1
            // 
            this.m_lblCustom1.Location = new System.Drawing.Point(168, 22);
            this.m_lblCustom1.Name = "m_lblCustom1";
            this.m_lblCustom1.Size = new System.Drawing.Size(80, 24);
            this.m_lblCustom1.TabIndex = 0;
            this.m_lblCustom1.Text = "自定义列1:";
            this.m_lblCustom1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(306, 24);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(21, 14);
            this.label24.TabIndex = 0;
            this.label24.Text = "ml";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(306, 50);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(21, 14);
            this.label25.TabIndex = 0;
            this.label25.Text = "ml";
            // 
            // m_txtCustom2
            // 
            this.m_txtCustom2.AccessibleDescription = "出量>>自定义2";
            this.m_txtCustom2.BackColor = System.Drawing.Color.White;
            this.m_txtCustom2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCustom2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtCustom2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCustom2.Location = new System.Drawing.Point(248, 46);
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
            this.m_txtCustom2.Size = new System.Drawing.Size(52, 22);
            this.m_txtCustom2.TabIndex = 50;
            this.m_txtCustom2.Text = "";
            this.m_txtCustom2.Leave += new System.EventHandler(this.m_txtNum_Leave);
            this.m_txtCustom2.MouseLeave += new System.EventHandler(this.m_evtNum_MouseLeave);
            this.m_txtCustom2.TextChanged += new System.EventHandler(this.m_txtOut_TextChanged);
            // 
            // m_lblCustom2
            // 
            this.m_lblCustom2.Location = new System.Drawing.Point(168, 48);
            this.m_lblCustom2.Name = "m_lblCustom2";
            this.m_lblCustom2.Size = new System.Drawing.Size(80, 24);
            this.m_lblCustom2.TabIndex = 0;
            this.m_lblCustom2.Text = "自定义列2:";
            this.m_lblCustom2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.m_txtCustom3);
            this.groupBox3.Controls.Add(this.m_lblCustom3);
            this.groupBox3.Controls.Add(this.m_txtCustom4);
            this.groupBox3.Controls.Add(this.m_lblCustom4);
            this.groupBox3.Controls.Add(this.m_txtCheckT);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.m_txtCheckP);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.m_txtCheckR);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.m_txtBPA);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.m_txtBPS);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Location = new System.Drawing.Point(6, 116);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(562, 74);
            this.groupBox3.TabIndex = 10000009;
            this.groupBox3.TabStop = false;
            // 
            // m_txtCustom3
            // 
            this.m_txtCustom3.AccessibleDescription = "自定义3";
            this.m_txtCustom3.BackColor = System.Drawing.Color.White;
            this.m_txtCustom3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCustom3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtCustom3.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCustom3.Location = new System.Drawing.Point(480, 20);
            this.m_txtCustom3.m_BlnIgnoreUserInfo = false;
            this.m_txtCustom3.m_BlnPartControl = false;
            this.m_txtCustom3.m_BlnReadOnly = false;
            this.m_txtCustom3.m_BlnUnderLineDST = false;
            this.m_txtCustom3.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtCustom3.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtCustom3.m_IntCanModifyTime = 6;
            this.m_txtCustom3.m_IntPartControlLength = 0;
            this.m_txtCustom3.m_IntPartControlStartIndex = 0;
            this.m_txtCustom3.m_StrUserID = "";
            this.m_txtCustom3.m_StrUserName = "";
            this.m_txtCustom3.MaxLength = 8000;
            this.m_txtCustom3.Multiline = false;
            this.m_txtCustom3.Name = "m_txtCustom3";
            this.m_txtCustom3.Size = new System.Drawing.Size(52, 22);
            this.m_txtCustom3.TabIndex = 105;
            this.m_txtCustom3.Text = "";
            // 
            // m_lblCustom3
            // 
            this.m_lblCustom3.Location = new System.Drawing.Point(400, 20);
            this.m_lblCustom3.Name = "m_lblCustom3";
            this.m_lblCustom3.Size = new System.Drawing.Size(80, 24);
            this.m_lblCustom3.TabIndex = 104;
            this.m_lblCustom3.Text = "自定义列3:";
            this.m_lblCustom3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtCustom4
            // 
            this.m_txtCustom4.AccessibleDescription = "自定义4";
            this.m_txtCustom4.BackColor = System.Drawing.Color.White;
            this.m_txtCustom4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCustom4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtCustom4.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCustom4.Location = new System.Drawing.Point(480, 46);
            this.m_txtCustom4.m_BlnIgnoreUserInfo = false;
            this.m_txtCustom4.m_BlnPartControl = false;
            this.m_txtCustom4.m_BlnReadOnly = false;
            this.m_txtCustom4.m_BlnUnderLineDST = false;
            this.m_txtCustom4.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtCustom4.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtCustom4.m_IntCanModifyTime = 6;
            this.m_txtCustom4.m_IntPartControlLength = 0;
            this.m_txtCustom4.m_IntPartControlStartIndex = 0;
            this.m_txtCustom4.m_StrUserID = "";
            this.m_txtCustom4.m_StrUserName = "";
            this.m_txtCustom4.MaxLength = 8000;
            this.m_txtCustom4.Multiline = false;
            this.m_txtCustom4.Name = "m_txtCustom4";
            this.m_txtCustom4.Size = new System.Drawing.Size(52, 22);
            this.m_txtCustom4.TabIndex = 106;
            this.m_txtCustom4.Text = "";
            // 
            // m_lblCustom4
            // 
            this.m_lblCustom4.Location = new System.Drawing.Point(400, 46);
            this.m_lblCustom4.Name = "m_lblCustom4";
            this.m_lblCustom4.Size = new System.Drawing.Size(80, 24);
            this.m_lblCustom4.TabIndex = 102;
            this.m_lblCustom4.Text = "自定义列4:";
            this.m_lblCustom4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtCheckT
            // 
            this.m_txtCheckT.AccessibleDescription = "体温";
            this.m_txtCheckT.BackColor = System.Drawing.Color.White;
            this.m_txtCheckT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCheckT.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtCheckT.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCheckT.Location = new System.Drawing.Point(64, 20);
            this.m_txtCheckT.m_BlnIgnoreUserInfo = false;
            this.m_txtCheckT.m_BlnPartControl = false;
            this.m_txtCheckT.m_BlnReadOnly = false;
            this.m_txtCheckT.m_BlnUnderLineDST = false;
            this.m_txtCheckT.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtCheckT.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtCheckT.m_IntCanModifyTime = 6;
            this.m_txtCheckT.m_IntPartControlLength = 0;
            this.m_txtCheckT.m_IntPartControlStartIndex = 0;
            this.m_txtCheckT.m_StrUserID = "";
            this.m_txtCheckT.m_StrUserName = "";
            this.m_txtCheckT.MaxLength = 8000;
            this.m_txtCheckT.Multiline = false;
            this.m_txtCheckT.Name = "m_txtCheckT";
            this.m_txtCheckT.Size = new System.Drawing.Size(118, 22);
            this.m_txtCheckT.TabIndex = 60;
            this.m_txtCheckT.Text = "";
            this.m_txtCheckT.Leave += new System.EventHandler(this.m_txtNum_Leave);
            this.m_txtCheckT.MouseLeave += new System.EventHandler(this.m_evtNum_MouseLeave);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(14, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 14);
            this.label14.TabIndex = 0;
            this.label14.Text = "体温T:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(188, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 14);
            this.label15.TabIndex = 0;
            this.label15.Text = "℃";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(348, 48);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(42, 14);
            this.label16.TabIndex = 0;
            this.label16.Text = "次/分";
            // 
            // m_txtCheckP
            // 
            this.m_txtCheckP.AccessibleDescription = "脉搏";
            this.m_txtCheckP.BackColor = System.Drawing.Color.White;
            this.m_txtCheckP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCheckP.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtCheckP.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCheckP.Location = new System.Drawing.Point(294, 44);
            this.m_txtCheckP.m_BlnIgnoreUserInfo = false;
            this.m_txtCheckP.m_BlnPartControl = false;
            this.m_txtCheckP.m_BlnReadOnly = false;
            this.m_txtCheckP.m_BlnUnderLineDST = false;
            this.m_txtCheckP.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtCheckP.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtCheckP.m_IntCanModifyTime = 6;
            this.m_txtCheckP.m_IntPartControlLength = 0;
            this.m_txtCheckP.m_IntPartControlStartIndex = 0;
            this.m_txtCheckP.m_StrUserID = "";
            this.m_txtCheckP.m_StrUserName = "";
            this.m_txtCheckP.MaxLength = 8000;
            this.m_txtCheckP.Multiline = false;
            this.m_txtCheckP.Name = "m_txtCheckP";
            this.m_txtCheckP.Size = new System.Drawing.Size(52, 22);
            this.m_txtCheckP.TabIndex = 70;
            this.m_txtCheckP.Text = "";
            this.m_txtCheckP.Leave += new System.EventHandler(this.m_txtNum_Leave);
            this.m_txtCheckP.MouseLeave += new System.EventHandler(this.m_evtNum_MouseLeave);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(252, 46);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(42, 14);
            this.label17.TabIndex = 0;
            this.label17.Text = "HR/P:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(244, 22);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(49, 14);
            this.label18.TabIndex = 0;
            this.label18.Text = "呼吸R:";
            // 
            // m_txtCheckR
            // 
            this.m_txtCheckR.AccessibleDescription = "呼吸";
            this.m_txtCheckR.BackColor = System.Drawing.Color.White;
            this.m_txtCheckR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCheckR.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtCheckR.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCheckR.Location = new System.Drawing.Point(294, 20);
            this.m_txtCheckR.m_BlnIgnoreUserInfo = false;
            this.m_txtCheckR.m_BlnPartControl = false;
            this.m_txtCheckR.m_BlnReadOnly = false;
            this.m_txtCheckR.m_BlnUnderLineDST = false;
            this.m_txtCheckR.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtCheckR.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtCheckR.m_IntCanModifyTime = 6;
            this.m_txtCheckR.m_IntPartControlLength = 0;
            this.m_txtCheckR.m_IntPartControlStartIndex = 0;
            this.m_txtCheckR.m_StrUserID = "";
            this.m_txtCheckR.m_StrUserName = "";
            this.m_txtCheckR.MaxLength = 8000;
            this.m_txtCheckR.Multiline = false;
            this.m_txtCheckR.Name = "m_txtCheckR";
            this.m_txtCheckR.Size = new System.Drawing.Size(52, 22);
            this.m_txtCheckR.TabIndex = 80;
            this.m_txtCheckR.Text = "";
            this.m_txtCheckR.Leave += new System.EventHandler(this.m_txtNum_Leave);
            this.m_txtCheckR.MouseLeave += new System.EventHandler(this.m_evtNum_MouseLeave);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(348, 24);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(42, 14);
            this.label19.TabIndex = 0;
            this.label19.Text = "次/分";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 48);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(56, 14);
            this.label20.TabIndex = 0;
            this.label20.Text = "血压BP:";
            // 
            // m_txtBPA
            // 
            this.m_txtBPA.AccessibleDescription = "血压>>收缩压";
            this.m_txtBPA.BackColor = System.Drawing.Color.White;
            this.m_txtBPA.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBPA.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBPA.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBPA.Location = new System.Drawing.Point(64, 44);
            this.m_txtBPA.m_BlnIgnoreUserInfo = false;
            this.m_txtBPA.m_BlnPartControl = false;
            this.m_txtBPA.m_BlnReadOnly = false;
            this.m_txtBPA.m_BlnUnderLineDST = false;
            this.m_txtBPA.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBPA.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBPA.m_IntCanModifyTime = 6;
            this.m_txtBPA.m_IntPartControlLength = 0;
            this.m_txtBPA.m_IntPartControlStartIndex = 0;
            this.m_txtBPA.m_StrUserID = "";
            this.m_txtBPA.m_StrUserName = "";
            this.m_txtBPA.MaxLength = 8000;
            this.m_txtBPA.Multiline = false;
            this.m_txtBPA.Name = "m_txtBPA";
            this.m_txtBPA.Size = new System.Drawing.Size(46, 22);
            this.m_txtBPA.TabIndex = 90;
            this.m_txtBPA.Text = "";
            this.m_txtBPA.Leave += new System.EventHandler(this.m_txtNum_Leave);
            this.m_txtBPA.MouseLeave += new System.EventHandler(this.m_evtNum_MouseLeave);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("宋体", 15F);
            this.label21.Location = new System.Drawing.Point(112, 46);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(19, 20);
            this.label21.TabIndex = 0;
            this.label21.Text = "/";
            // 
            // m_txtBPS
            // 
            this.m_txtBPS.AccessibleDescription = "血压>>舒张压";
            this.m_txtBPS.BackColor = System.Drawing.Color.White;
            this.m_txtBPS.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBPS.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBPS.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBPS.Location = new System.Drawing.Point(134, 44);
            this.m_txtBPS.m_BlnIgnoreUserInfo = false;
            this.m_txtBPS.m_BlnPartControl = false;
            this.m_txtBPS.m_BlnReadOnly = false;
            this.m_txtBPS.m_BlnUnderLineDST = false;
            this.m_txtBPS.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBPS.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBPS.m_IntCanModifyTime = 6;
            this.m_txtBPS.m_IntPartControlLength = 0;
            this.m_txtBPS.m_IntPartControlStartIndex = 0;
            this.m_txtBPS.m_StrUserID = "";
            this.m_txtBPS.m_StrUserName = "";
            this.m_txtBPS.MaxLength = 8000;
            this.m_txtBPS.Multiline = false;
            this.m_txtBPS.Name = "m_txtBPS";
            this.m_txtBPS.Size = new System.Drawing.Size(48, 22);
            this.m_txtBPS.TabIndex = 100;
            this.m_txtBPS.Text = "";
            this.m_txtBPS.Leave += new System.EventHandler(this.m_txtNum_Leave);
            this.m_txtBPS.MouseLeave += new System.EventHandler(this.m_evtNum_MouseLeave);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label22.Location = new System.Drawing.Point(188, 50);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(35, 14);
            this.label22.TabIndex = 0;
            this.label22.Text = "mmHg";
            // 
            // m_cmdOK
            // 
            this.m_cmdOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdOK.DefaultScheme = true;
            this.m_cmdOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdOK.Hint = "";
            this.m_cmdOK.Location = new System.Drawing.Point(424, 244);
            this.m_cmdOK.Name = "m_cmdOK";
            this.m_cmdOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdOK.Size = new System.Drawing.Size(64, 32);
            this.m_cmdOK.TabIndex = 10000028;
            this.m_cmdOK.Text = "确定";
            this.m_cmdOK.Click += new System.EventHandler(this.m_cmdOK_Click);
            // 
            // m_cmdCancel
            // 
            this.m_cmdCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdCancel.DefaultScheme = true;
            this.m_cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdCancel.Hint = "";
            this.m_cmdCancel.Location = new System.Drawing.Point(498, 244);
            this.m_cmdCancel.Name = "m_cmdCancel";
            this.m_cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCancel.Size = new System.Drawing.Size(64, 32);
            this.m_cmdCancel.TabIndex = 10000029;
            this.m_cmdCancel.Text = "取消";
            this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdCancel_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.m_txtSumInTime);
            this.groupBox4.Controls.Add(this.m_txtSumOutTime);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.m_txtSumIn);
            this.groupBox4.Controls.Add(this.m_txtSumOut);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Enabled = false;
            this.groupBox4.Location = new System.Drawing.Point(6, 194);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(224, 82);
            this.groupBox4.TabIndex = 10000031;
            this.groupBox4.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(188, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 14);
            this.label10.TabIndex = 113;
            this.label10.Text = "ml";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(64, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 14);
            this.label8.TabIndex = 112;
            this.label8.Text = "H总入量";
            // 
            // m_txtSumInTime
            // 
            this.m_txtSumInTime.AccessibleDescription = "入量统计时间";
            this.m_txtSumInTime.Location = new System.Drawing.Point(10, 24);
            this.m_txtSumInTime.Name = "m_txtSumInTime";
            this.m_txtSumInTime.Size = new System.Drawing.Size(52, 23);
            this.m_txtSumInTime.TabIndex = 111;
            this.m_txtSumInTime.MouseLeave += new System.EventHandler(this.m_evtSum_MouseLeave);
            this.m_txtSumInTime.Leave += new System.EventHandler(this.m_txtSum_Leave);
            // 
            // m_txtSumOutTime
            // 
            this.m_txtSumOutTime.AccessibleDescription = "出量统计时间";
            this.m_txtSumOutTime.Location = new System.Drawing.Point(10, 54);
            this.m_txtSumOutTime.Name = "m_txtSumOutTime";
            this.m_txtSumOutTime.Size = new System.Drawing.Size(52, 23);
            this.m_txtSumOutTime.TabIndex = 111;
            this.m_txtSumOutTime.MouseLeave += new System.EventHandler(this.m_evtSum_MouseLeave);
            this.m_txtSumOutTime.Leave += new System.EventHandler(this.m_txtSum_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(64, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 14);
            this.label9.TabIndex = 112;
            this.label9.Text = "H总出量";
            // 
            // m_txtSumIn
            // 
            this.m_txtSumIn.AccessibleDescription = "总入量";
            this.m_txtSumIn.Location = new System.Drawing.Point(120, 24);
            this.m_txtSumIn.Name = "m_txtSumIn";
            this.m_txtSumIn.Size = new System.Drawing.Size(62, 23);
            this.m_txtSumIn.TabIndex = 111;
            this.m_txtSumIn.MouseLeave += new System.EventHandler(this.m_evtSum_MouseLeave);
            this.m_txtSumIn.Leave += new System.EventHandler(this.m_txtSum_Leave);
            // 
            // m_txtSumOut
            // 
            this.m_txtSumOut.AccessibleDescription = "总出量";
            this.m_txtSumOut.Location = new System.Drawing.Point(120, 54);
            this.m_txtSumOut.Name = "m_txtSumOut";
            this.m_txtSumOut.Size = new System.Drawing.Size(62, 23);
            this.m_txtSumOut.TabIndex = 111;
            this.m_txtSumOut.MouseLeave += new System.EventHandler(this.m_evtSum_MouseLeave);
            this.m_txtSumOut.Leave += new System.EventHandler(this.m_txtSum_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(188, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 14);
            this.label11.TabIndex = 113;
            this.label11.Text = "ml";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(236, 202);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 14);
            this.label12.TabIndex = 10000032;
            this.label12.Text = "统计起始时间:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(236, 224);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(98, 14);
            this.label13.TabIndex = 10000032;
            this.label13.Text = "统计结束时间:";
            this.label13.Visible = false;
            // 
            // m_lblThisStatTime
            // 
            this.m_lblThisStatTime.AccessibleDescription = "本次统计时间";
            this.m_lblThisStatTime.Location = new System.Drawing.Point(336, 222);
            this.m_lblThisStatTime.Name = "m_lblThisStatTime";
            this.m_lblThisStatTime.Size = new System.Drawing.Size(230, 23);
            this.m_lblThisStatTime.TabIndex = 10000033;
            this.m_lblThisStatTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lblThisStatTime.Visible = false;
            // 
            // m_chkIfSum
            // 
            this.m_chkIfSum.Location = new System.Drawing.Point(16, 192);
            this.m_chkIfSum.Name = "m_chkIfSum";
            this.m_chkIfSum.Size = new System.Drawing.Size(96, 24);
            this.m_chkIfSum.TabIndex = 10000036;
            this.m_chkIfSum.Text = "出入量统计";
            this.m_chkIfSum.CheckedChanged += new System.EventHandler(this.m_chkIfSum_CheckedChanged);
            // 
            // m_lblHasStatTips
            // 
            this.m_lblHasStatTips.ForeColor = System.Drawing.Color.Blue;
            this.m_lblHasStatTips.Location = new System.Drawing.Point(372, 4);
            this.m_lblHasStatTips.Name = "m_lblHasStatTips";
            this.m_lblHasStatTips.Size = new System.Drawing.Size(196, 32);
            this.m_lblHasStatTips.TabIndex = 10000037;
            // 
            // m_dtpLastStatTime
            // 
            this.m_dtpLastStatTime.AccessibleDescription = "";
            this.m_dtpLastStatTime.BorderColor = System.Drawing.Color.Black;
            this.m_dtpLastStatTime.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpLastStatTime.DropButtonBackColor = System.Drawing.Color.Gainsboro;
            this.m_dtpLastStatTime.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpLastStatTime.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpLastStatTime.Enabled = false;
            this.m_dtpLastStatTime.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpLastStatTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpLastStatTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpLastStatTime.Location = new System.Drawing.Point(336, 200);
            this.m_dtpLastStatTime.m_BlnOnlyTime = false;
            this.m_dtpLastStatTime.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpLastStatTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpLastStatTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpLastStatTime.Name = "m_dtpLastStatTime";
            this.m_dtpLastStatTime.ReadOnly = false;
            this.m_dtpLastStatTime.Size = new System.Drawing.Size(212, 22);
            this.m_dtpLastStatTime.TabIndex = 10000038;
            this.m_dtpLastStatTime.TextBackColor = System.Drawing.Color.White;
            this.m_dtpLastStatTime.TextForeColor = System.Drawing.Color.Black;
            this.m_dtpLastStatTime.evtValueChanged += new System.EventHandler(this.m_dtpLastStatTime_evtValueChanged);
            // 
            // txtSign
            // 
            this.txtSign.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSign.Enabled = false;
            this.txtSign.Location = new System.Drawing.Point(302, 256);
            this.txtSign.Name = "txtSign";
            this.txtSign.Size = new System.Drawing.Size(106, 23);
            this.txtSign.TabIndex = 10000040;
            // 
            // m_cmbsign
            // 
            this.m_cmbsign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmbsign.DefaultScheme = true;
            this.m_cmbsign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmbsign.Hint = "";
            this.m_cmbsign.Location = new System.Drawing.Point(234, 247);
            this.m_cmbsign.Name = "m_cmbsign";
            this.m_cmbsign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmbsign.Size = new System.Drawing.Size(64, 32);
            this.m_cmbsign.TabIndex = 10000039;
            this.m_cmbsign.Text = "签名";
            // 
            // frmIntensiveTend_GX
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(582, 291);
            this.Controls.Add(this.txtSign);
            this.Controls.Add(this.m_cmbsign);
            this.Controls.Add(this.m_dtpLastStatTime);
            this.Controls.Add(this.m_lblHasStatTips);
            this.Controls.Add(this.m_chkIfSum);
            this.Controls.Add(this.m_cmdOK);
            this.Controls.Add(this.m_cmdCancel);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.m_lblThisStatTime);
            this.Name = "frmIntensiveTend_GX";
            this.Text = "危重患者护理记录";
            this.Load += new System.EventHandler(this.frmIntensiveTend_GX_Load);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_lblThisStatTime, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
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
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.m_cmdCancel, 0);
            this.Controls.SetChildIndex(this.m_cmdOK, 0);
            this.Controls.SetChildIndex(this.m_chkIfSum, 0);
            this.Controls.SetChildIndex(this.m_lblHasStatTips, 0);
            this.Controls.SetChildIndex(this.m_dtpLastStatTime, 0);
            this.Controls.SetChildIndex(this.m_cmbsign, 0);
            this.Controls.SetChildIndex(this.txtSign, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void m_cmdOK_Click(object sender, System.EventArgs e)
		{
			if(m_chkIfSum.Checked)
			{
				if(m_txtSumInTime.Text.Trim() == "" || m_txtSumOutTime.Text.Trim() == "")
				{
					clsPublicFunction.ShowInformationMessageBox("出入量统计时间不能为空");
					return;
				}
				if(m_strAutoSumIn != null && m_strAutoSumIn != "" && m_strAutoSumIn.Trim() != m_txtSumIn.Text.Trim())
				{
					if(clsPublicFunction.ShowQuestionMessageBox(m_txtSumIn.AccessibleDescription + "与实际累加数值("+m_strAutoSumIn.Trim()+")不等，是否继续保存？")
						== DialogResult.No)
					{
						return;
					}
				}
				if(m_strAutoSumOut != null && m_strAutoSumOut != "" && m_strAutoSumOut.Trim() != m_txtSumOut.Text.Trim())
				{
					if(clsPublicFunction.ShowQuestionMessageBox(m_txtSumOut.AccessibleDescription + "与实际累加数值("+m_strAutoSumOut.Trim()+")不等，是否继续保存？")
						== DialogResult.No)
					{
						return;
					}
				}
			}
			if (m_lngSave()>0)
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

		public override string m_strReloadFormTitle()
		{
			//由子窗体重载实现

			return	"危重患者护理记录";
		}

		protected override iCare.clsDiseaseTrackDomain m_objGetDiseaseTrackDomain()
		{
			//获取护理记录的领域层实例，由子窗体重载实现
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.IntensiveTendRecord_GX);					
		}

		/// <summary>
		/// 把选择时间记录内容重新整理为完全正确的内容。
		/// </summary>
		/// <param name="p_objRecordContent"></param>
		protected override void m_mthReAddNewRecord(clsTrackRecordContent p_objRecordContent)
		{
			//把选择时间记录内容重新整理为完全正确的内容，由子窗体重载实现。
			clsIntensiveTendRecord_GX objContent=(clsIntensiveTendRecord_GX)p_objRecordContent;
		}

		protected override iCareData.clsTrackRecordContent m_objGetContentFromGUI()
		{
			
			//界面参数校验
			if(m_objCurrentPatient==null ||m_ObjCurrentEmrPatientSession == null)				
				return null;

			//从界面获取表单值		
			clsIntensiveTendRecord_GX objContent=new clsIntensiveTendRecord_GX ();
			try
			{
				string strNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
				objContent.m_dtmCreateDate = DateTime.Parse(strNow) ;
				objContent.m_dtmOpenDate = DateTime.Parse(strNow);
				objContent.m_strDIAGNOSE = m_strDiagnose;

				objContent.m_strINITEM_RIGHT=this.m_txtInItem.m_strGetRightText();
				objContent.m_strINITEM=this.m_txtInItem.Text;
				objContent.m_strINITEMXML=this.m_txtInItem.m_strGetXmlText();
		
				objContent.m_strINFACT_RIGHT=this.m_txtInFact.m_strGetRightText();
				objContent.m_strINFACT=this.m_txtInFact.Text;
				objContent.m_strINFACTXML=this.m_txtInFact.m_strGetXmlText();

				objContent.m_strOUTPISS_RIGHT=this.m_txtOutPiss.m_strGetRightText();
				objContent.m_strOUTPISS=this.m_txtOutPiss.Text;
				objContent.m_strOUTPISSXML=this.m_txtOutPiss.m_strGetXmlText();
            			
				objContent.m_strOUTSTOOL_RIGHT=this.m_txtOutStool.m_strGetRightText();
				objContent.m_strOUTSTOOL=this.m_txtOutStool.Text;
				objContent.m_strOUTSTOOLXML=this.m_txtOutStool.m_strGetXmlText();

				objContent.m_strCHECKT_RIGHT=this.m_txtCheckT.m_strGetRightText();
				objContent.m_strCHECKT=this.m_txtCheckT.Text;
				objContent.m_strCHECKTXML=this.m_txtCheckT.m_strGetXmlText();

				objContent.m_strCHECKP_RIGHT=this.m_txtCheckP.m_strGetRightText();
				objContent.m_strCHECKP=this.m_txtCheckP.Text;
				objContent.m_strCHECKPXML=this.m_txtCheckP.m_strGetXmlText();

				objContent.m_strCHECKR_RIGHT=this.m_txtCheckR.m_strGetRightText();
				objContent.m_strCHECKR=this.m_txtCheckR.Text;
				objContent.m_strCHECKRXML=this.m_txtCheckR.m_strGetXmlText();

				objContent.m_strCHECKBPS_RIGHT=this.m_txtBPS.m_strGetRightText();
				objContent.m_strCHECKBPS=this.m_txtBPS.Text;
				objContent.m_strCHECKBPSXML=this.m_txtBPS.m_strGetXmlText();

				objContent.m_strCHECKBPA_RIGHT=this.m_txtBPA.m_strGetRightText();
				objContent.m_strCHECKBPA=this.m_txtBPA.Text;
				objContent.m_strCHECKBPAXML=this.m_txtBPA.m_strGetXmlText();

				objContent.m_strCUSTOM1_RIGHT=this.m_txtCustom1.m_strGetRightText();
				objContent.m_strCUSTOM1=this.m_txtCustom1.Text;
				objContent.m_strCUSTOM1XML=this.m_txtCustom1.m_strGetXmlText();

				objContent.m_strCUSTOM2_RIGHT=this.m_txtCustom2.m_strGetRightText();
				objContent.m_strCUSTOM2=this.m_txtCustom2.Text;
				objContent.m_strCUSTOM2XML=this.m_txtCustom2.m_strGetXmlText();

				objContent.m_strCUSTOM3_RIGHT=this.m_txtCustom3.m_strGetRightText();
				objContent.m_strCUSTOM3=this.m_txtCustom3.Text;
				objContent.m_strCUSTOM3XML=this.m_txtCustom3.m_strGetXmlText();

				objContent.m_strCUSTOM4_RIGHT=this.m_txtCustom4.m_strGetRightText();
				objContent.m_strCUSTOM4=this.m_txtCustom4.Text;
				objContent.m_strCUSTOM4XML=this.m_txtCustom4.m_strGetXmlText();

				if(m_chkIfSum.Checked)
				{
					objContent.m_intISSTAT = 1;
					objContent.m_strSUMIN = m_txtSumIn.Text;
					objContent.m_strSUMOUT = m_txtSumOut.Text;
					objContent.m_intSUMINTIME = (int)(double.Parse(m_txtSumInTime.Text));
                    objContent.m_intSUMOUTTIME = (int)(double.Parse(m_txtSumOutTime.Text));
					objContent.m_dtmSTARTSTATTIME = m_dtpLastStatTime.Value;
					if(m_strAutoSumIn != null && m_strAutoSumIn != "" && m_strAutoSumIn.Trim() != m_txtSumIn.Text.Trim())
					{
						objContent.m_strAUTOSUMIN = m_strAutoSumIn;
					}
					if(m_strAutoSumOut != null && m_strAutoSumOut != "" && m_strAutoSumOut.Trim() != m_txtSumOut.Text.Trim())
					{
						objContent.m_strAUTOSUMOUT = m_strAutoSumOut;
					}
				}
				else
				{
					objContent.m_intISSTAT = 0;
				}

//                if(this.m_txtNurseSign.Text.Trim()!="" && this.m_txtNurseSign.Tag!=null)
//                {
//                    objContent.m_strNURSESIGNID=((clsEmployee)this.m_txtNurseSign.Tag).m_StrEmployeeID;
//                    objContent.m_strNURSESIGNNAME=this.m_txtNurseSign.Text;
//                }

////				objContent.m_intSTAT_STATUS = this.m_chkIfSum.Checked ? 1:0;
//                objContent.m_intSTAT_STATUS = m_intGetClass(m_dtpCreateDate.Value);

//                objContent.m_strCreateUserID = MDIParent.OperatorID;
//                objContent.m_dtmModifyDate = DateTime.Parse(strNow);
//                objContent.m_strModifyUserID = MDIParent.OperatorID;
//                objContent.m_dtmRECORDDATE = m_dtpCreateDate.Value;

                objContent.m_strNURSESIGNID = ((clsEmrEmployeeBase_VO)txtSign.Tag).m_strEMPNO_CHR;
                objContent.m_strNURSESIGNNAME = ((clsEmrEmployeeBase_VO)txtSign.Tag).m_strLASTNAME_VCHR;
                objContent.m_strCreateUserID = ((clsEmrEmployeeBase_VO)txtSign.Tag).m_strEMPNO_CHR;
                objContent.m_dtmModifyDate = DateTime.Parse(strNow);
                objContent.m_strModifyUserID = ((clsEmrEmployeeBase_VO)txtSign.Tag).m_strEMPNO_CHR;
                objContent.m_dtmRECORDDATE = m_dtpCreateDate.Value;
                //获取签名
                strUserIDList="";
                strUserNameList = "";
                m_mthGetSignArr(new Control[] { txtSign }, ref objContent.objSignerArr, ref strUserIDList, ref strUserNameList);
                //objContent.objSignerArr = new clsEmrSigns_VO[1];
                //objContent.objSignerArr[0] = new clsEmrSigns_VO();
                //objContent.objSignerArr[0].objEmployee = new clsEmrEmployeeBase_VO();
                //objContent.objSignerArr[0].objEmployee = (clsEmrEmployeeBase_VO)(txtSign.Tag);
                //objContent.objSignerArr[0].controlName = "txtSign";
                //objContent.objSignerArr[0].m_strFORMID_VCHR = "frmIntensiveTend_GX";//注意大小写
                //objContent.objSignerArr[0].m_strREGISTERID_CHR = com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;
			}
		
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
                return null;
			}

			return(objContent );		
		}

		protected override void m_mthSetDeletedGUIFromContent(iCareData.clsTrackRecordContent p_objContent)
		{
			clsIntensiveTendRecord_GX objContent=(clsIntensiveTendRecord_GX )p_objContent;
			//把表单值赋值到界面，由子窗体重载实现			

			this.m_mthClearRecordInfo();		
			this.m_txtInItem.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strINITEM ,objContent.m_strINITEMXML);
			this.m_txtInFact.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strINFACT,objContent.m_strINFACTXML);
			this.m_txtOutPiss.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strOUTPISS,objContent.m_strOUTPISSXML);
			this.m_txtOutStool.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strOUTSTOOL,objContent.m_strOUTSTOOLXML);
			this.m_txtCheckT.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strCHECKT,objContent.m_strCHECKTXML);
			this.m_txtCheckP.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strCHECKP,objContent.m_strCHECKPXML);
			this.m_txtCheckR.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strCHECKR,objContent.m_strCHECKRXML);
			this.m_txtBPA.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strCHECKBPA,objContent.m_strCHECKBPAXML);
			this.m_txtBPS.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strCHECKBPS,objContent.m_strCHECKBPSXML);
			this.m_txtCustom1.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strCUSTOM1,objContent.m_strCUSTOM1XML);
			this.m_txtCustom2.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strCUSTOM2,objContent.m_strCUSTOM2XML);
			this.m_txtCustom3.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strCUSTOM3,objContent.m_strCUSTOM3XML);
			this.m_txtCustom4.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strCUSTOM4,objContent.m_strCUSTOM4XML);
			this.m_dtpCreateDate.Value = objContent.m_dtmRECORDDATE;
			if(objContent.m_intISSTAT == 0)
				m_chkIfSum.Checked = false;
			else if(objContent.m_intISSTAT == 1)
			{
				m_chkIfSum.Checked = true;
				if(objContent.m_dtmSTARTSTATTIME == DateTime.MinValue)
				{
					if(m_dtpCreateDate.Value.Hour <= 8)
					{
						this.m_dtpLastStatTime.Value = DateTime.Parse(m_dtpCreateDate.Value.AddDays(-1).ToString("yyyy-MM-dd 08:00:00"));
					}
					else
					{
						this.m_dtpLastStatTime.Value = DateTime.Parse(m_dtpCreateDate.Value.ToString("yyyy-MM-dd 08:00:00"));
					}
				}
				else
					this.m_dtpLastStatTime.Value = objContent.m_dtmSTARTSTATTIME;
				this.m_txtSumInTime.Text = objContent.m_intSUMINTIME.ToString();
				this.m_txtSumOutTime.Text = objContent.m_intSUMOUTTIME.ToString();
				this.m_txtSumIn.Text = objContent.m_strSUMIN;
				this.m_txtSumOut.Text = objContent.m_strSUMOUT;
				if(objContent.m_strSUMIN != null && objContent.m_strSUMIN != "")
					m_dblOriSumInFromDB = double.Parse(objContent.m_strSUMIN);
				if(objContent.m_strSUMOUT != null && objContent.m_strSUMOUT != "")
					m_dblOriSumOutFromDB = double.Parse(objContent.m_strSUMOUT);
				m_dblSumInGUI = 0;
				m_dblSumOutGUI = 0;
				m_mthGetInOutFromGUI(ref m_dblSumInGUI, ref m_dblSumOutGUI);
			}
            m_mthAddSignToTextBoxByEmpNo(new TextBoxBase[] { txtSign, }, new string[] { objContent.m_strNURSESIGNID }, new bool[] { false });
//			this.m_chkIfSum.Checked = objContent.m_intSTAT_STATUS == 0 ? false:true;

            //this.m_txtNurseSign.Enabled = false;
            //根据工号获取签名信息
            //出于兼容考虑，过渡使用 tfzhang 2006-03-12
            //com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
            //clsEmrEmployeeBase_VO objSign = new clsEmrEmployeeBase_VO();
            //objEmployeeSign.m_lngGetEmpByNO(objContent.m_strNURSESIGNID, out objSign);
            //if (objSign != null)
            //{
            //    txtSign.Text = objSign.m_strLASTNAME_VCHR;
            //    txtSign.Tag = objSign;
            //}
            //this.txtSign.Enabled = false;
			this.m_dtpCreateDate.Enabled = false;
		}

		/// <summary>
		/// 把特殊记录的值显示到界面上。
		/// </summary>
		/// <param name="p_objContent"></param>
		protected override void m_mthSetGUIFromContent(iCareData.clsTrackRecordContent p_objContent)
		{
			clsIntensiveTendRecord_GX objContent=(clsIntensiveTendRecord_GX )p_objContent;
			//把表单值赋值到界面，由子窗体重载实现			
			this.m_mthClearRecordInfo();

			this.m_txtInItem.m_mthSetNewText(objContent.m_strINITEM ,objContent.m_strINITEMXML);
			this.m_txtInFact.m_mthSetNewText(objContent.m_strINFACT,objContent.m_strINFACTXML);
			this.m_txtOutPiss.m_mthSetNewText(objContent.m_strOUTPISS,objContent.m_strOUTPISSXML);
			this.m_txtOutStool.m_mthSetNewText(objContent.m_strOUTSTOOL,objContent.m_strOUTSTOOLXML);
			this.m_txtCheckT.m_mthSetNewText(objContent.m_strCHECKT,objContent.m_strCHECKTXML);
			this.m_txtCheckP.m_mthSetNewText(objContent.m_strCHECKP,objContent.m_strCHECKPXML);
			this.m_txtCheckR.m_mthSetNewText(objContent.m_strCHECKR,objContent.m_strCHECKRXML);
			this.m_txtBPA.m_mthSetNewText(objContent.m_strCHECKBPA,objContent.m_strCHECKBPAXML);
			this.m_txtBPS.m_mthSetNewText(objContent.m_strCHECKBPS,objContent.m_strCHECKBPSXML);
			this.m_txtCustom1.m_mthSetNewText(objContent.m_strCUSTOM1,objContent.m_strCUSTOM1XML);
			this.m_txtCustom2.m_mthSetNewText(objContent.m_strCUSTOM2,objContent.m_strCUSTOM2XML);
			this.m_txtCustom3.m_mthSetNewText(objContent.m_strCUSTOM3,objContent.m_strCUSTOM3XML);
			this.m_txtCustom4.m_mthSetNewText(objContent.m_strCUSTOM4,objContent.m_strCUSTOM4XML);
//			this.m_chkIfSum.Checked = objContent.m_intSTAT_STATUS == 0 ? false:true;
			this.m_dtpCreateDate.Value = objContent.m_dtmRECORDDATE;
			if(objContent.m_intISSTAT == 0)
				m_chkIfSum.Checked = false;
			else if(objContent.m_intISSTAT == 1)
			{
				m_chkIfSum.Checked = true;
				if(objContent.m_dtmSTARTSTATTIME == DateTime.MinValue)
				{
					if(m_dtpCreateDate.Value.Hour <= 8)
					{
						this.m_dtpLastStatTime.Value = DateTime.Parse(m_dtpCreateDate.Value.AddDays(-1).ToString("yyyy-MM-dd 08:00:00"));
					}
					else
					{
						this.m_dtpLastStatTime.Value = DateTime.Parse(m_dtpCreateDate.Value.ToString("yyyy-MM-dd 08:00:00"));
					}
				}
				else
					this.m_dtpLastStatTime.Value = objContent.m_dtmSTARTSTATTIME;
				this.m_txtSumInTime.Text = objContent.m_intSUMINTIME.ToString();
				this.m_txtSumOutTime.Text = objContent.m_intSUMOUTTIME.ToString();
				this.m_txtSumIn.Text = objContent.m_strSUMIN;
				this.m_txtSumOut.Text = objContent.m_strSUMOUT;
				if(objContent.m_strSUMIN != null && objContent.m_strSUMIN != "")
					m_dblOriSumInFromDB = double.Parse(objContent.m_strSUMIN);
				if(objContent.m_strSUMOUT != null && objContent.m_strSUMOUT != "")
					m_dblOriSumOutFromDB = double.Parse(objContent.m_strSUMOUT);
				m_dblSumInGUI = 0;
				m_dblSumOutGUI = 0;
				m_mthGetInOutFromGUI(ref m_dblSumInGUI, ref m_dblSumOutGUI);
			}
            m_mthAddSignToTextBoxByEmpNo(new TextBoxBase[] { txtSign }, new string[] { objContent.m_strNURSESIGNID }, new bool[] { false });
            //if(objContent.m_strNURSESIGNID!=null &&objContent.m_strNURSESIGNID!="")
            //{
            //    clsEmployee objEmp = new clsEmployee(objContent.m_strNURSESIGNID);
            //    m_txtNurseSign.Tag = objEmp;
            //    m_txtNurseSign.Text = objEmp.m_StrLastName;
            //}
            //this.m_txtNurseSign.Enabled = false;
            //根据工号获取签名信息
            //出于兼容考虑，过渡使用 tfzhang 2006-03-12
            //com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
            //clsEmrEmployeeBase_VO objSign = new clsEmrEmployeeBase_VO();
            //objEmployeeSign.m_lngGetEmpByNO(objContent.m_strNURSESIGNID, out objSign);
            //if (objSign != null)
            //{
            //    txtSign.Text = objSign.m_strLASTNAME_VCHR;
            //    txtSign.Tag = objSign;
            //}
            //this.txtSign.Enabled = false;
			this.m_dtpCreateDate.Enabled = false;
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

			this.m_txtInItem.m_mthClearText();
			this.m_txtInFact.m_mthClearText();
			this.m_txtOutPiss.m_mthClearText();
			this.m_txtOutStool.m_mthClearText();
			this.m_txtCheckT.m_mthClearText();
			this.m_txtCheckP.m_mthClearText();
			this.m_txtCheckR.m_mthClearText();
			this.m_txtBPA.m_mthClearText();
			this.m_txtBPS.m_mthClearText();
			this.m_txtCustom1.m_mthClearText();
			this.m_txtCustom2.m_mthClearText();
			this.m_txtCustom3.m_mthClearText();
			this.m_txtCustom4.m_mthClearText();
			this.m_chkIfSum.Checked = false;
			label13.Visible = false;
			m_lblThisStatTime.Visible = false;
            //默认签名
            MDIParent.m_mthSetDefaulEmployee(txtSign);
            //m_objSignTool.m_mthSetDefaulEmployee();
		}

		#region Jump Control
		protected override void m_mthInitJump(clsJumpControl p_objJump)
		{
			p_objJump=new clsJumpControl(this,
				new Control[]{m_txtInItem,m_txtInFact,m_txtOutPiss,m_txtOutStool,m_txtCustom1,m_txtCustom2, m_txtCheckT,m_txtBPA,
								 m_txtBPS,m_txtCheckR,m_txtCheckP,m_txtCustom3,m_txtCustom4},Keys.Enter);
		}
		#endregion

		private void m_chkIfSum_CheckedChanged(object sender, System.EventArgs e)
		{
			groupBox4.Enabled = m_chkIfSum.Checked;
			label13.Visible = m_chkIfSum.Checked;
			m_lblThisStatTime.Visible = m_chkIfSum.Checked;
			m_lblThisStatTime.Text = m_dtpCreateDate.Value.ToString("yyyy年MM月dd日 HH:mm");
			m_dtpLastStatTime.Enabled = m_chkIfSum.Checked;
			m_lblHasStatTips.Visible = m_chkIfSum.Checked;

			if(m_chkIfSum.Checked)
			{
				try
				{
					this.Cursor = Cursors.WaitCursor;
					m_mthSetStartStatTime();
					m_mthSetStatInfo();
				}
				catch (Exception exp)
				{
					string strError=exp.Message;
				}
				finally
				{
					this.Cursor = Cursors.Default;
				}
			}
		}

		private void m_evtNum_MouseLeave(object sender, System.EventArgs e)
		{
			if(((com.digitalwave.controls.ctlRichTextBox)sender).Text != "")
			{
				try
				{
					double.Parse(((com.digitalwave.controls.ctlRichTextBox)sender).Text);
				}
				catch
				{
					MDIParent.ShowInformationMessageBox(((com.digitalwave.controls.ctlRichTextBox)sender).AccessibleDescription + "应输入数字");
					((com.digitalwave.controls.ctlRichTextBox)sender).Text = "";
					((com.digitalwave.controls.ctlRichTextBox)sender).Focus();
				}
			}
		}

		private void frmIntensiveTend_GX_Load(object sender, System.EventArgs e)
		{
			this.m_txtInItem.Focus();
			m_mthGetStatTimeArr();
			if(m_objCurrentRecordContent == null)
				m_mthSetStartStatTime();
		}


		private void m_txtNum_Leave(object sender, System.EventArgs e)
		{
			if(((com.digitalwave.controls.ctlRichTextBox)sender).Text != "")
			{
				try
				{
					double.Parse(((com.digitalwave.controls.ctlRichTextBox)sender).Text);
				}
				catch
				{
					((com.digitalwave.controls.ctlRichTextBox)sender).Text = "";
					((com.digitalwave.controls.ctlRichTextBox)sender).Focus();
					MDIParent.ShowInformationMessageBox(((com.digitalwave.controls.ctlRichTextBox)sender).AccessibleDescription + "应输入数字");
				}
			}
		}

		private void m_evtSum_MouseLeave(object sender, System.EventArgs e)
		{
			if(((TextBox)sender).Text != "")
			{
				try
				{
					double.Parse(((TextBox)sender).Text);
				}
				catch
				{
					MDIParent.ShowInformationMessageBox(((TextBox)sender).AccessibleDescription + "应输入数字");
					((TextBox)sender).Text = "";
					((TextBox)sender).Focus();
				}
			}
		}

		private void m_txtSum_Leave(object sender, System.EventArgs e)
		{
			if(((TextBox)sender).Text != "")
			{
				try
				{
					double.Parse(((TextBox)sender).Text);
				}
				catch
				{
					((TextBox)sender).Text = "";
					((TextBox)sender).Focus();
					MDIParent.ShowInformationMessageBox(((TextBox)sender).AccessibleDescription + "应输入数字");
				}
			}
		}

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

		private void m_dtpCreateDate_evtValueChanged(object sender, System.EventArgs e)
		{
			m_lblThisStatTime.Text = m_dtpCreateDate.Value.ToString("yyyy年MM月dd日 HH:mm");
			if(m_chkIfSum.Checked)
			{
				m_mthSetStartStatTime();
			}
		}

		#region 查询数据库，获取统计相关信息
		private string m_strAutoSumIn = "";
		private string m_strAutoSumOut = "";
		private void m_mthGetStatTimeArr()
		{
			clsIntensiveTendRecord_GX[] objRecordArr = null;

            clsIntensiveTendRecord_GXService objServ =
                (clsIntensiveTendRecord_GXService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsIntensiveTendRecord_GXService));

			long lngRes = objServ.m_lngGetStatRecordTime(m_objCurrentPatient.m_StrInPatientID, m_objCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"), out objRecordArr);
			if(lngRes > 0 && objRecordArr != null)
			{
				m_objRecordArr = objRecordArr;
			}
            //objServ.Dispose();
//			m_mthSetStatInfo();
		}

		/// <summary>
		/// 设置统计开始时间
		/// </summary>
		private void m_mthSetStartStatTime()
		{
			DateTime dtStart = DateTime.MinValue;
			if(m_dtpCreateDate.Value.Hour <= 8)
			{
				dtStart = DateTime.Parse(m_dtpCreateDate.Value.AddDays(-1).ToString("yyyy-MM-dd 08:00:00"));
			}
			else
			{
				dtStart = DateTime.Parse(m_dtpCreateDate.Value.ToString("yyyy-MM-dd 08:00:00"));
			}
			m_dtpLastStatTime.Value = dtStart;
		}

		/// <summary>
		///显示统计信息
		/// </summary>
		private void m_mthSetStatInfo()
		{
			DateTime dtEnd = m_dtpCreateDate.Value;
			DateTime dtStart = m_dtpLastStatTime.Value;
			if(dtEnd < dtStart)
			{
				MDIParent.ShowInformationMessageBox("统计起始时间不能大于统计结束时间！");
				return;
			}
			double dblSumIn = m_dblGetInSum(dtStart, dtEnd);
			double dblSumOut = m_dblGetOutSum(dtStart, dtEnd);
			TimeSpan tsTime = dtEnd - dtStart;
			if(m_objCurrentRecordContent != null)
			{
				dblSumIn -= m_dblSumInGUI;
				dblSumOut -= m_dblSumOutGUI;
			}
			m_dblSumInGUI = 0;
			m_dblSumOutGUI = 0;
			m_mthGetInOutFromGUI(ref m_dblSumInGUI, ref m_dblSumOutGUI);
			m_txtSumIn.Text = (m_dblSumInGUI + dblSumIn).ToString();
			m_txtSumOut.Text = (m_dblSumOutGUI + dblSumOut).ToString();
			m_strAutoSumIn = (m_dblSumInGUI + dblSumIn).ToString();
			m_strAutoSumOut = (m_dblSumOutGUI + dblSumOut).ToString();
			m_dblOriAutoSumIn = m_dblSumInGUI + dblSumIn;
			m_dblOriAutoSumOut = m_dblSumOutGUI + dblSumOut;
			if(m_dtpCreateDate.Value.Hour >= 7 && m_dtpCreateDate.Value.Hour <=8)
			{
				m_txtSumInTime.Text = "24";
				m_txtSumOutTime.Text = "24";
			}
			else
			{
				m_txtSumInTime.Text = ((int)tsTime.TotalHours).ToString();
				m_txtSumOutTime.Text = ((int)tsTime.TotalHours).ToString();
			}
			m_lblThisStatTime.Text = m_dtpCreateDate.Value.ToString("yyyy年MM月dd日 HH:mm");
			for(int i=0; i<m_objRecordArr.Length; i++)
			{
				if(i < m_objRecordArr.Length-1 &&
					DateTime.Parse(m_objRecordArr[i].m_dtmRECORDDATE.ToString("yyyy-MM-dd HH:mm")) < DateTime.Parse(m_dtpCreateDate.Value.ToString("yyyy-MM-dd HH:mm")) &&
					DateTime.Parse(m_objRecordArr[i+1].m_dtmRECORDDATE.ToString("yyyy-MM-dd HH:mm")) > DateTime.Parse(m_dtpCreateDate.Value.ToString("yyyy-MM-dd HH:mm")))
				{
					if(m_objRecordArr[i+1].m_intSUMINTIME == 24 || m_objRecordArr[i+1].m_intSUMOUTTIME == 24)
					{
						m_lblHasStatTips.Text = "在"+m_objRecordArr[i+1].m_dtmRECORDDATE.ToString("yyyy年MM月dd日 HH:mm")+"已经进行了一次24小时出入量统计";
					}
				}
			}
		}

		#region 获取当前界面未保存的出入量
		/// <summary>
		/// 获取当前界面未保存的出入量
		/// </summary>
		/// <param name="p_dblSumIn"></param>
		/// <param name="p_dblSumOut"></param>
		private void m_mthGetInOutFromGUI(ref double p_dblSumIn, ref double p_dblSumOut)
		{
			double dblTemp = 0;
			if(m_txtInFact.Text.Trim() != "")
			{
				try
				{
					dblTemp = double.Parse(m_txtInFact.Text);
					p_dblSumIn += dblTemp;
				}
				catch{}
			}
			if(m_txtOutPiss.Text.Trim() != "")
			{
				try
				{
					dblTemp = double.Parse(m_txtOutPiss.Text);
					p_dblSumOut += dblTemp;
				}
				catch{}
			}
			if(m_txtOutStool.Text.Trim() != "")
			{
				try
				{
					dblTemp = double.Parse(m_txtOutStool.Text);
					p_dblSumOut += dblTemp;
				}
				catch{}
			}
			if(m_txtCustom1.Text.Trim() != "")
			{
				try
				{
					dblTemp = double.Parse(m_txtCustom1.Text);
					p_dblSumOut += dblTemp;
				}
				catch{}
			}
			if(m_txtCustom2.Text.Trim() != "")
			{
				try
				{
					dblTemp = double.Parse(m_txtCustom2.Text);
					p_dblSumOut += dblTemp;
				}
				catch{}
			}
		}
		#endregion

		/// <summary>
		/// 获取总入量
		/// </summary>
		/// <param name="dtStartTime"></param>
		private double m_dblGetInSum(DateTime dtStartTime, DateTime dtEndTime)
		{
			double dblInSum = 0;
			double[] dblInSumArr = null;
			if(MDIParent.s_ObjCurrentPatient == null)
				return 0;

            clsIntensiveTendRecord_GXService objServ =
                (clsIntensiveTendRecord_GXService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsIntensiveTendRecord_GXService));

			long lngRes = objServ.m_lngGetInSum(MDIParent.s_ObjCurrentPatient.m_StrInPatientID, MDIParent.s_ObjCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"),
				dtEndTime.ToString("yyyy-MM-dd HH:mm:ss"), dtStartTime.ToString("yyyy-MM-dd HH:mm:ss"), out dblInSumArr);

			if(lngRes > 0 && dblInSumArr != null)
			{
				for(int i=0; i<dblInSumArr.Length; i++)
				{
					dblInSum += dblInSumArr[i];
				}
			}
            //objServ.Dispose();
			return dblInSum;
		}

		/// <summary>
		/// 获取总出量
		/// </summary>
		/// <param name="dtStartTime"></param>
		private double m_dblGetOutSum(DateTime dtStartTime, DateTime dtEndTime)
		{
			if(MDIParent.s_ObjCurrentPatient == null)
				return 0;
			double dblOutSum = 0;
			double[] dblOutPissArr = null;
			double[] dblOutStoolArr = null;
			double[] p_dblCustom1Arr = null;
			double[] p_dblCustom2Arr = null;

            clsIntensiveTendRecord_GXService objServ =
                (clsIntensiveTendRecord_GXService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsIntensiveTendRecord_GXService));

			long lngRes = objServ.m_lngGetOutSum(MDIParent.s_ObjCurrentPatient.m_StrInPatientID, MDIParent.s_ObjCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"),
				dtEndTime.ToString("yyyy-MM-dd HH:mm:ss"), dtStartTime.ToString("yyyy-MM-dd HH:mm:ss"), out dblOutPissArr, out dblOutStoolArr,out p_dblCustom1Arr,out p_dblCustom2Arr);
            //objServ.Dispose();
			if(lngRes > 0 && dblOutPissArr != null && dblOutStoolArr!=null && p_dblCustom1Arr!=null && p_dblCustom2Arr != null)
			{
				for(int i=0; i<dblOutPissArr.Length; i++)
				{
					dblOutSum += dblOutPissArr[i];
				}
				for(int i=0; i<dblOutStoolArr.Length; i++)
				{
					dblOutSum += dblOutStoolArr[i];
				}
				for(int i=0; i<p_dblCustom1Arr.Length; i++)
				{
					dblOutSum += p_dblCustom1Arr[i];
				}
				for(int i=0; i<p_dblCustom2Arr.Length; i++)
				{
					dblOutSum += p_dblCustom2Arr[i];
				}
			}
			return dblOutSum;
		}
		#endregion

		private void m_dtpLastStatTime_evtValueChanged(object sender, System.EventArgs e)
		{
			if(m_chkIfSum.Checked)
			{
				try
				{
					this.Cursor = Cursors.WaitCursor;
					m_mthSetStatInfo();
				}
				catch (Exception exp)
				{
					string strError=exp.Message;
				}
				finally
				{
					this.Cursor = Cursors.Default;
				}
			}
		}

		private void m_txtInFact_TextChanged(object sender, System.EventArgs e)
		{		
			double dblText = 0;	
			double dblIn = 0;
			double dblOut = 0;	
			if(m_chkIfSum.Checked)
			{
				try
				{
					if(m_txtInFact.Text.Trim() != "")
						dblText = double.Parse(m_txtInFact.Text);
				}
				catch
				{
				}
				finally
				{					
					m_mthGetInOutFromGUI(ref dblIn, ref dblOut);
					m_txtSumIn.Text = (m_dblOriAutoSumIn - m_dblSumInGUI + dblIn).ToString();
					m_strAutoSumIn = (m_dblOriAutoSumIn - m_dblSumInGUI + dblIn).ToString();
				}
			}
		}

		private void m_txtOut_TextChanged(object sender, System.EventArgs e)
		{
			double dblText = 0;
			double dblIn = 0;
			double dblOut = 0;
			if(m_chkIfSum.Checked)
			{
				try
				{
					if(((com.digitalwave.controls.ctlRichTextBox)sender).Text.Trim() != "")
						dblText = double.Parse(((com.digitalwave.controls.ctlRichTextBox)sender).Text);
				}
				catch
				{
				}
				finally
				{
					m_mthGetInOutFromGUI(ref dblIn, ref dblOut);
					m_txtSumOut.Text = (m_dblOriAutoSumOut - m_dblSumOutGUI + dblOut).ToString();
					m_strAutoSumOut = (m_dblOriAutoSumOut - m_dblSumOutGUI + dblOut).ToString();
				}
			}
		}
	}
}
