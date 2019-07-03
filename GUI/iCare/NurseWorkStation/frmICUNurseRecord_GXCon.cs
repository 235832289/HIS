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
using com.digitalwave.clsICUNurseRecord_GXService;
using com.digitalwave.Emr.Signature_gui;
namespace iCare
{
	/// <summary>
	/// ICU护理记录(广西)
	/// </summary>
	public class frmICUNurseRecord_GXCon : frmDiseaseTrackBase
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label m_lblCustom3Name;
        private System.Windows.Forms.Label m_lblCustom4Name;
		private com.digitalwave.controls.ctlRichTextBox m_txtOutEmiction;
        private com.digitalwave.controls.ctlRichTextBox m_txtspo2;
		private PinkieControls.ButtonXP m_cmdOK;
        private PinkieControls.ButtonXP m_cmdCancel;
		private com.digitalwave.controls.ctlRichTextBox m_txtBloodPressureA;
		private com.digitalwave.controls.ctlRichTextBox m_txtBloodPressureS;
		private com.digitalwave.controls.ctlRichTextBox m_txtA;
		private com.digitalwave.controls.ctlRichTextBox m_txtInAmountFact;
		private com.digitalwave.controls.ctlRichTextBox m_txtT;
		private com.digitalwave.controls.ctlRichTextBox m_txtHR;
		private com.digitalwave.controls.ctlRichTextBox m_txtR;
		private com.digitalwave.controls.ctlRichTextBox m_txtItem;
		private com.digitalwave.controls.ctlRichTextBox m_txtInAmountStandby;
		private clsEmployeeSignTool m_objSignTool;
        private clsCommonUseToolCollection m_objCUTC;
        private com.digitalwave.controls.ctlRichTextBox m_txtCustom1;
        private System.Windows.Forms.Label m_lblCustom1Name;
        private System.Windows.Forms.Label m_lblCustom2Name;
        private com.digitalwave.controls.ctlRichTextBox m_txtCustom2;
		private com.digitalwave.controls.ctlRichTextBox m_txtGeneralInstance;
		private System.Windows.Forms.Label label14;
		private com.digitalwave.controls.ctlRichTextBox m_txtSummary;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.CheckBox m_chkIfSum;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox m_txtSumInTime;
		private System.Windows.Forms.TextBox m_txtSumOutTime;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.TextBox m_txtSumIn;
		private System.Windows.Forms.TextBox m_txtSumOut;
		private com.digitalwave.Utility.Controls.ctlTimePicker m_dtpLastStatTime;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label m_lblThisStatTime;
		private System.Windows.Forms.Label m_lblHasStatTips;
        #region 统计所需全局变量
        /// <summary>
        /// 初始的当前记录总入量
        /// </summary>
        private double m_dblOriSumInFromDB = 0;
        /// <summary>
        /// 初始的当前记录的总出量
        /// </summary>
        private double m_dblOriSumOutFromDB = 0;
        /// <summary>
        /// 初始的当前记录的备用量总入量
        /// </summary>
        private double m_dblOriStandBySumFromDB = 0;
        /// <summary>
        /// 初始的当前记录的实入量总入量
        /// </summary>
        private double m_dblOriFactSumFromDB = 0;
        /// <summary>
        /// 初始的当前记录的尿量总出量
        /// </summary>
        private double m_dblOriPissSumFromDB = 0;
        /// <summary>
        /// 初始的当前记录的自定义列1总出量
        /// </summary>
        private double m_dblOriCustom1SumFromDB = 0;
        /// <summary>
        /// 初始的当前记录的自定义列2总出量
        /// </summary>
        private double m_dblOriCustom2SumFromDB = 0;
        /// <summary>
        /// 初始的自动累加的总入量
        /// </summary>
        private double m_dblOriAutoSumIn = 0;
        /// <summary>
        /// 初始的自动累加的总出量
        /// </summary>
        private double m_dblOriAutoSumOut = 0;
        /// <summary>
        /// 初始的自动累加的备用量总入量
        /// </summary>
        private double m_dblOriAutoStandBySum = 0;
        /// <summary>
        /// 初始的自动累加的实入量总入量
        /// </summary>
        private double m_dblOriAutoFactSum = 0;
        /// <summary>
        /// 初始的自动累加的尿量总出量
        /// </summary>
        private double m_dblOriAutoPissSum = 0;
        /// <summary>
        /// 初始的自动累加的自定义列1总出量
        /// </summary>
        private double m_dblOriAutoCustom1Sum = 0;
        /// <summary>
        /// 初始的自动累加的自定义列2总出量
        /// </summary>
        private double m_dblOriAutoCustom2Sum = 0; 
        /// <summary>
        /// 初始的界面上的总入量
        /// </summary>
        private double m_dblSumInGUI = 0;
        /// <summary>
        /// 初始的界面上的总出量
        /// </summary>
        private double m_dblSumOutGUI = 0;
        /// <summary>
        /// 初始的界面上的备用量总入量
        /// </summary>
        private double m_dblStandBySumGUI = 0;
        /// <summary>
        /// 初始的界面上的实入量总入量
        /// </summary>
        private double m_dblFactSumGUI = 0;
        /// <summary>
        /// 初始的界面上的尿量总出量
        /// </summary>
        private double m_dblPissSumGUI = 0;
        /// <summary>
        /// 初始的界面上的自定义列1总出量
        /// </summary>
        private double m_dblCustom1SumGUI = 0;
        /// <summary>
        /// 初始的界面上的自定义列2总出量
        /// </summary>
        private double m_dblCustom2SumGUI = 0; 
        private string m_strAutoSumIn = "";
        private string m_strAutoSumOut = "";
        private string m_strAutoStandBySum = "";
        private string m_strAutoFactSum = "";
        private string m_strAutoPissSum = "";
        private string m_strAutoCustom1Sum = "";
        private string m_strAutoCustom2Sum = "";
        #endregion
		private clsICUNurseRecordContentGX[] m_objRecordArr = null;
        //private clsICUNurseRecord_GXService m_objServ;
        private Label label20;
        private Label label17;
        private TextBox m_txtFactSumIn;
        private TextBox m_txtStandBySumIn;
        private Label m_lblCustom2NameSum;
        private Label m_lblCustom1NameSum;
        private TextBox m_txtCustom2SumOut;
        private Label label22;
        private TextBox m_txtCustom1SumOut;
        private TextBox m_txtEmictionSumOut;
        private TextBox txtSign;
        private PinkieControls.ButtonXP m_cmbsign;
        private string[] m_strCustomNameArr = new string[4];
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
        //定义签名类
        private clsEmrSignToolCollection m_objSign;
        public frmICUNurseRecord_GXCon(string[] p_strCustomNameArr)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

            //m_mthSetRichTextBoxAttribInControl(this);
            //m_objSignTool = new clsEmployeeSignTool(m_lsvEmployee);
            //m_objSignTool.m_mthAddControl(new Control[]{m_txtEmpSign},false);
			m_objCUTC = new clsCommonUseToolCollection(this);
            //m_objCUTC.m_mthBindEmployeeSign(m_cmdSign,m_lsvEmployee,2);

            //m_objServ = new clsICUNurseRecord_GXService();
            //签名常用值
            m_objSign = new clsEmrSignToolCollection();

            //可以指定员工ID如
            m_objSign.m_mthBindEmployeeSign(m_cmbsign, txtSign, 2, true, clsEMRLogin.LoginInfo.m_strEmpID);

            if (p_strCustomNameArr != null && p_strCustomNameArr.Length == 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    m_strCustomNameArr[i] = p_strCustomNameArr[i];
                }
            }
            m_mthSetCustomColumnName();
		}

        public override int m_IntFormID
		{
			get
			{
				return 85;
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_txtItem = new com.digitalwave.controls.ctlRichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtInAmountStandby = new com.digitalwave.controls.ctlRichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtInAmountFact = new com.digitalwave.controls.ctlRichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_txtCustom2 = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtOutEmiction = new com.digitalwave.controls.ctlRichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_txtCustom1 = new com.digitalwave.controls.ctlRichTextBox();
            this.m_lblCustom1Name = new System.Windows.Forms.Label();
            this.m_lblCustom2Name = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_txtBloodPressureS = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtspo2 = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtA = new com.digitalwave.controls.ctlRichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_txtT = new com.digitalwave.controls.ctlRichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_txtHR = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtR = new com.digitalwave.controls.ctlRichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.m_txtBloodPressureA = new com.digitalwave.controls.ctlRichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.m_lblCustom3Name = new System.Windows.Forms.Label();
            this.m_lblCustom4Name = new System.Windows.Forms.Label();
            this.m_cmdOK = new PinkieControls.ButtonXP();
            this.m_cmdCancel = new PinkieControls.ButtonXP();
            this.m_txtGeneralInstance = new com.digitalwave.controls.ctlRichTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.m_txtSummary = new com.digitalwave.controls.ctlRichTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.m_chkIfSum = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.m_lblThisStatTime = new System.Windows.Forms.Label();
            this.m_dtpLastStatTime = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.m_txtSumInTime = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.m_txtFactSumIn = new System.Windows.Forms.TextBox();
            this.m_txtSumOutTime = new System.Windows.Forms.TextBox();
            this.m_txtStandBySumIn = new System.Windows.Forms.TextBox();
            this.m_lblCustom2NameSum = new System.Windows.Forms.Label();
            this.m_lblCustom1NameSum = new System.Windows.Forms.Label();
            this.m_txtCustom2SumOut = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.m_txtCustom1SumOut = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.m_txtEmictionSumOut = new System.Windows.Forms.TextBox();
            this.m_txtSumIn = new System.Windows.Forms.TextBox();
            this.m_txtSumOut = new System.Windows.Forms.TextBox();
            this.m_lblHasStatTips = new System.Windows.Forms.Label();
            this.txtSign = new System.Windows.Forms.TextBox();
            this.m_cmbsign = new PinkieControls.ButtonXP();
            this.m_pnlNewBase.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
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
            this.lblCreateDateTitle.Location = new System.Drawing.Point(12, 8);
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.AccessibleDescription = "";
            this.m_dtpCreateDate.DropButtonBackColor = System.Drawing.Color.Gainsboro;
            this.m_dtpCreateDate.Enabled = false;
            this.m_dtpCreateDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpCreateDate.Location = new System.Drawing.Point(80, 6);
            this.m_dtpCreateDate.TabIndex = 10000048;
            this.m_dtpCreateDate.evtValueChanged += new System.EventHandler(this.m_dtpCreateDate_evtValueChanged);
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
            this.lblSex.Size = new System.Drawing.Size(48, 32);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(736, -120);
            this.lblAge.Size = new System.Drawing.Size(52, 32);
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
            this.m_lsvInPatientID.Size = new System.Drawing.Size(116, 117);
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
            this.m_cmdNewTemplate.Size = new System.Drawing.Size(84, 45);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.Location = new System.Drawing.Point(196, -120);
            this.m_cmdNext.Size = new System.Drawing.Size(24, 34);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(156, -120);
            this.m_cmdPre.Size = new System.Drawing.Size(24, 34);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(272, -112);
            this.m_lblForTitle.Size = new System.Drawing.Size(16, 36);
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_txtItem);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.m_txtInAmountStandby);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.m_txtInAmountFact);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(10, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 98);
            this.groupBox1.TabIndex = 10000005;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "入量";
            // 
            // m_txtItem
            // 
            this.m_txtItem.AccessibleDescription = "项目";
            this.m_txtItem.BackColor = System.Drawing.Color.White;
            this.m_txtItem.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtItem.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtItem.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtItem.Location = new System.Drawing.Point(64, 18);
            this.m_txtItem.m_BlnIgnoreUserInfo = false;
            this.m_txtItem.m_BlnPartControl = false;
            this.m_txtItem.m_BlnReadOnly = false;
            this.m_txtItem.m_BlnUnderLineDST = false;
            this.m_txtItem.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtItem.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtItem.m_IntCanModifyTime = 6;
            this.m_txtItem.m_IntPartControlLength = 0;
            this.m_txtItem.m_IntPartControlStartIndex = 0;
            this.m_txtItem.m_StrUserID = "";
            this.m_txtItem.m_StrUserName = "";
            this.m_txtItem.MaxLength = 8000;
            this.m_txtItem.Multiline = false;
            this.m_txtItem.Name = "m_txtItem";
            this.m_txtItem.Size = new System.Drawing.Size(122, 22);
            this.m_txtItem.TabIndex = 100;
            this.m_txtItem.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "项  目:";
            // 
            // m_txtInAmountStandby
            // 
            this.m_txtInAmountStandby.AccessibleDescription = "备用量";
            this.m_txtInAmountStandby.BackColor = System.Drawing.Color.White;
            this.m_txtInAmountStandby.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtInAmountStandby.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtInAmountStandby.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtInAmountStandby.Location = new System.Drawing.Point(64, 44);
            this.m_txtInAmountStandby.m_BlnIgnoreUserInfo = false;
            this.m_txtInAmountStandby.m_BlnPartControl = false;
            this.m_txtInAmountStandby.m_BlnReadOnly = false;
            this.m_txtInAmountStandby.m_BlnUnderLineDST = false;
            this.m_txtInAmountStandby.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtInAmountStandby.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtInAmountStandby.m_IntCanModifyTime = 6;
            this.m_txtInAmountStandby.m_IntPartControlLength = 0;
            this.m_txtInAmountStandby.m_IntPartControlStartIndex = 0;
            this.m_txtInAmountStandby.m_StrUserID = "";
            this.m_txtInAmountStandby.m_StrUserName = "";
            this.m_txtInAmountStandby.MaxLength = 8000;
            this.m_txtInAmountStandby.Multiline = false;
            this.m_txtInAmountStandby.Name = "m_txtInAmountStandby";
            this.m_txtInAmountStandby.Size = new System.Drawing.Size(122, 22);
            this.m_txtInAmountStandby.TabIndex = 200;
            this.m_txtInAmountStandby.Text = "";
            this.m_txtInAmountStandby.TextChanged += new System.EventHandler(this.m_txtInFact_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "备用量:";
            // 
            // m_txtInAmountFact
            // 
            this.m_txtInAmountFact.AccessibleDescription = "实入量";
            this.m_txtInAmountFact.BackColor = System.Drawing.Color.White;
            this.m_txtInAmountFact.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtInAmountFact.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtInAmountFact.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtInAmountFact.Location = new System.Drawing.Point(64, 70);
            this.m_txtInAmountFact.m_BlnIgnoreUserInfo = false;
            this.m_txtInAmountFact.m_BlnPartControl = false;
            this.m_txtInAmountFact.m_BlnReadOnly = false;
            this.m_txtInAmountFact.m_BlnUnderLineDST = false;
            this.m_txtInAmountFact.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtInAmountFact.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtInAmountFact.m_IntCanModifyTime = 6;
            this.m_txtInAmountFact.m_IntPartControlLength = 0;
            this.m_txtInAmountFact.m_IntPartControlStartIndex = 0;
            this.m_txtInAmountFact.m_StrUserID = "";
            this.m_txtInAmountFact.m_StrUserName = "";
            this.m_txtInAmountFact.MaxLength = 8000;
            this.m_txtInAmountFact.Multiline = false;
            this.m_txtInAmountFact.Name = "m_txtInAmountFact";
            this.m_txtInAmountFact.Size = new System.Drawing.Size(122, 22);
            this.m_txtInAmountFact.TabIndex = 300;
            this.m_txtInAmountFact.Text = "";
            this.m_txtInAmountFact.Leave += new System.EventHandler(this.m_txtNum_Leave);
            this.m_txtInAmountFact.TextChanged += new System.EventHandler(this.m_txtInFact_TextChanged);
            this.m_txtInAmountFact.MouseLeave += new System.EventHandler(this.m_evtNum_MouseLeave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "实入量:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_txtCustom2);
            this.groupBox2.Controls.Add(this.m_txtOutEmiction);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.m_txtCustom1);
            this.groupBox2.Controls.Add(this.m_lblCustom1Name);
            this.groupBox2.Controls.Add(this.m_lblCustom2Name);
            this.groupBox2.Location = new System.Drawing.Point(210, 32);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(206, 98);
            this.groupBox2.TabIndex = 10000006;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "出量";
            // 
            // m_txtCustom2
            // 
            this.m_txtCustom2.AccessibleDescription = "自定义列2";
            this.m_txtCustom2.BackColor = System.Drawing.Color.White;
            this.m_txtCustom2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCustom2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtCustom2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCustom2.Location = new System.Drawing.Point(78, 70);
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
            this.m_txtCustom2.Size = new System.Drawing.Size(122, 22);
            this.m_txtCustom2.TabIndex = 400;
            this.m_txtCustom2.Text = "";
            this.m_txtCustom2.Leave += new System.EventHandler(this.m_txtNum_Leave);
            this.m_txtCustom2.TextChanged += new System.EventHandler(this.m_txtOut_TextChanged);
            this.m_txtCustom2.MouseLeave += new System.EventHandler(this.m_evtNum_MouseLeave);
            // 
            // m_txtOutEmiction
            // 
            this.m_txtOutEmiction.AccessibleDescription = "尿";
            this.m_txtOutEmiction.BackColor = System.Drawing.Color.White;
            this.m_txtOutEmiction.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOutEmiction.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtOutEmiction.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOutEmiction.Location = new System.Drawing.Point(78, 18);
            this.m_txtOutEmiction.m_BlnIgnoreUserInfo = false;
            this.m_txtOutEmiction.m_BlnPartControl = false;
            this.m_txtOutEmiction.m_BlnReadOnly = false;
            this.m_txtOutEmiction.m_BlnUnderLineDST = false;
            this.m_txtOutEmiction.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOutEmiction.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOutEmiction.m_IntCanModifyTime = 6;
            this.m_txtOutEmiction.m_IntPartControlLength = 0;
            this.m_txtOutEmiction.m_IntPartControlStartIndex = 0;
            this.m_txtOutEmiction.m_StrUserID = "";
            this.m_txtOutEmiction.m_StrUserName = "";
            this.m_txtOutEmiction.MaxLength = 8000;
            this.m_txtOutEmiction.Multiline = false;
            this.m_txtOutEmiction.Name = "m_txtOutEmiction";
            this.m_txtOutEmiction.Size = new System.Drawing.Size(122, 22);
            this.m_txtOutEmiction.TabIndex = 400;
            this.m_txtOutEmiction.Text = "";
            this.m_txtOutEmiction.Leave += new System.EventHandler(this.m_txtNum_Leave);
            this.m_txtOutEmiction.TextChanged += new System.EventHandler(this.m_txtOut_TextChanged);
            this.m_txtOutEmiction.MouseLeave += new System.EventHandler(this.m_evtNum_MouseLeave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "尿:";
            // 
            // m_txtCustom1
            // 
            this.m_txtCustom1.AccessibleDescription = "自定义列1";
            this.m_txtCustom1.BackColor = System.Drawing.Color.White;
            this.m_txtCustom1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCustom1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtCustom1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCustom1.Location = new System.Drawing.Point(78, 44);
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
            this.m_txtCustom1.Size = new System.Drawing.Size(122, 22);
            this.m_txtCustom1.TabIndex = 400;
            this.m_txtCustom1.Text = "";
            this.m_txtCustom1.Leave += new System.EventHandler(this.m_txtNum_Leave);
            this.m_txtCustom1.TextChanged += new System.EventHandler(this.m_txtOut_TextChanged);
            this.m_txtCustom1.MouseLeave += new System.EventHandler(this.m_evtNum_MouseLeave);
            // 
            // m_lblCustom1Name
            // 
            this.m_lblCustom1Name.Location = new System.Drawing.Point(4, 46);
            this.m_lblCustom1Name.Name = "m_lblCustom1Name";
            this.m_lblCustom1Name.Size = new System.Drawing.Size(77, 14);
            this.m_lblCustom1Name.TabIndex = 0;
            this.m_lblCustom1Name.Text = "自定义列1:";
            this.m_lblCustom1Name.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_lblCustom2Name
            // 
            this.m_lblCustom2Name.Location = new System.Drawing.Point(4, 72);
            this.m_lblCustom2Name.Name = "m_lblCustom2Name";
            this.m_lblCustom2Name.Size = new System.Drawing.Size(77, 14);
            this.m_lblCustom2Name.TabIndex = 0;
            this.m_lblCustom2Name.Text = "自定义列2:";
            this.m_lblCustom2Name.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox3
            // 
            this.groupBox3.AccessibleDescription = "ctlRichTextBox9_TextChanged";
            this.groupBox3.Controls.Add(this.m_txtBloodPressureS);
            this.groupBox3.Controls.Add(this.m_txtspo2);
            this.groupBox3.Controls.Add(this.m_txtA);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.m_txtT);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.m_txtHR);
            this.groupBox3.Controls.Add(this.m_txtR);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.m_txtBloodPressureA);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.m_lblCustom3Name);
            this.groupBox3.Controls.Add(this.m_lblCustom4Name);
            this.groupBox3.Location = new System.Drawing.Point(422, 32);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(362, 98);
            this.groupBox3.TabIndex = 10000007;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "观察病情:";
            // 
            // m_txtBloodPressureS
            // 
            this.m_txtBloodPressureS.AccessibleDescription = "收缩压";
            this.m_txtBloodPressureS.BackColor = System.Drawing.Color.White;
            this.m_txtBloodPressureS.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBloodPressureS.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBloodPressureS.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBloodPressureS.Location = new System.Drawing.Point(302, 18);
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
            this.m_txtBloodPressureS.Size = new System.Drawing.Size(54, 22);
            this.m_txtBloodPressureS.TabIndex = 850;
            this.m_txtBloodPressureS.Text = "";
            // 
            // m_txtspo2
            // 
            this.m_txtspo2.AccessibleDescription = "自定义列4";
            this.m_txtspo2.BackColor = System.Drawing.Color.White;
            this.m_txtspo2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtspo2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtspo2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtspo2.Location = new System.Drawing.Point(234, 70);
            this.m_txtspo2.m_BlnIgnoreUserInfo = false;
            this.m_txtspo2.m_BlnPartControl = false;
            this.m_txtspo2.m_BlnReadOnly = false;
            this.m_txtspo2.m_BlnUnderLineDST = false;
            this.m_txtspo2.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtspo2.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtspo2.m_IntCanModifyTime = 6;
            this.m_txtspo2.m_IntPartControlLength = 0;
            this.m_txtspo2.m_IntPartControlStartIndex = 0;
            this.m_txtspo2.m_StrUserID = "";
            this.m_txtspo2.m_StrUserName = "";
            this.m_txtspo2.MaxLength = 8000;
            this.m_txtspo2.Multiline = false;
            this.m_txtspo2.Name = "m_txtspo2";
            this.m_txtspo2.Size = new System.Drawing.Size(122, 22);
            this.m_txtspo2.TabIndex = 1000;
            this.m_txtspo2.Text = "";
            // 
            // m_txtA
            // 
            this.m_txtA.AccessibleDescription = "自定义列3";
            this.m_txtA.BackColor = System.Drawing.Color.White;
            this.m_txtA.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtA.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtA.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtA.Location = new System.Drawing.Point(234, 44);
            this.m_txtA.m_BlnIgnoreUserInfo = false;
            this.m_txtA.m_BlnPartControl = false;
            this.m_txtA.m_BlnReadOnly = false;
            this.m_txtA.m_BlnUnderLineDST = false;
            this.m_txtA.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtA.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtA.m_IntCanModifyTime = 6;
            this.m_txtA.m_IntPartControlLength = 0;
            this.m_txtA.m_IntPartControlStartIndex = 0;
            this.m_txtA.m_StrUserID = "";
            this.m_txtA.m_StrUserName = "";
            this.m_txtA.MaxLength = 8000;
            this.m_txtA.Multiline = false;
            this.m_txtA.Name = "m_txtA";
            this.m_txtA.Size = new System.Drawing.Size(122, 22);
            this.m_txtA.TabIndex = 900;
            this.m_txtA.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 14);
            this.label5.TabIndex = 0;
            this.label5.Text = "T:";
            // 
            // m_txtT
            // 
            this.m_txtT.AccessibleDescription = "体温";
            this.m_txtT.BackColor = System.Drawing.Color.White;
            this.m_txtT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtT.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtT.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtT.Location = new System.Drawing.Point(34, 18);
            this.m_txtT.m_BlnIgnoreUserInfo = false;
            this.m_txtT.m_BlnPartControl = false;
            this.m_txtT.m_BlnReadOnly = false;
            this.m_txtT.m_BlnUnderLineDST = false;
            this.m_txtT.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtT.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtT.m_IntCanModifyTime = 6;
            this.m_txtT.m_IntPartControlLength = 0;
            this.m_txtT.m_IntPartControlStartIndex = 0;
            this.m_txtT.m_StrUserID = "";
            this.m_txtT.m_StrUserName = "";
            this.m_txtT.MaxLength = 8000;
            this.m_txtT.Multiline = false;
            this.m_txtT.Name = "m_txtT";
            this.m_txtT.Size = new System.Drawing.Size(122, 22);
            this.m_txtT.TabIndex = 500;
            this.m_txtT.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 14);
            this.label6.TabIndex = 0;
            this.label6.Text = "HR:";
            // 
            // m_txtHR
            // 
            this.m_txtHR.AccessibleDescription = "心率";
            this.m_txtHR.BackColor = System.Drawing.Color.White;
            this.m_txtHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtHR.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtHR.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtHR.Location = new System.Drawing.Point(34, 44);
            this.m_txtHR.m_BlnIgnoreUserInfo = false;
            this.m_txtHR.m_BlnPartControl = false;
            this.m_txtHR.m_BlnReadOnly = false;
            this.m_txtHR.m_BlnUnderLineDST = false;
            this.m_txtHR.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtHR.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtHR.m_IntCanModifyTime = 6;
            this.m_txtHR.m_IntPartControlLength = 0;
            this.m_txtHR.m_IntPartControlStartIndex = 0;
            this.m_txtHR.m_StrUserID = "";
            this.m_txtHR.m_StrUserName = "";
            this.m_txtHR.MaxLength = 8000;
            this.m_txtHR.Multiline = false;
            this.m_txtHR.Name = "m_txtHR";
            this.m_txtHR.Size = new System.Drawing.Size(122, 22);
            this.m_txtHR.TabIndex = 600;
            this.m_txtHR.Text = "";
            // 
            // m_txtR
            // 
            this.m_txtR.AccessibleDescription = "呼吸";
            this.m_txtR.BackColor = System.Drawing.Color.White;
            this.m_txtR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtR.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtR.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtR.Location = new System.Drawing.Point(34, 70);
            this.m_txtR.m_BlnIgnoreUserInfo = false;
            this.m_txtR.m_BlnPartControl = false;
            this.m_txtR.m_BlnReadOnly = false;
            this.m_txtR.m_BlnUnderLineDST = false;
            this.m_txtR.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtR.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtR.m_IntCanModifyTime = 6;
            this.m_txtR.m_IntPartControlLength = 0;
            this.m_txtR.m_IntPartControlStartIndex = 0;
            this.m_txtR.m_StrUserID = "";
            this.m_txtR.m_StrUserName = "";
            this.m_txtR.MaxLength = 8000;
            this.m_txtR.Multiline = false;
            this.m_txtR.Name = "m_txtR";
            this.m_txtR.Size = new System.Drawing.Size(122, 22);
            this.m_txtR.TabIndex = 700;
            this.m_txtR.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 14);
            this.label7.TabIndex = 0;
            this.label7.Text = "R:";
            // 
            // m_txtBloodPressureA
            // 
            this.m_txtBloodPressureA.AccessibleDescription = "舒张压";
            this.m_txtBloodPressureA.BackColor = System.Drawing.Color.White;
            this.m_txtBloodPressureA.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBloodPressureA.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtBloodPressureA.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBloodPressureA.Location = new System.Drawing.Point(234, 18);
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
            this.m_txtBloodPressureA.Size = new System.Drawing.Size(50, 22);
            this.m_txtBloodPressureA.TabIndex = 800;
            this.m_txtBloodPressureA.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(210, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 14);
            this.label8.TabIndex = 0;
            this.label8.Text = "BP:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(282, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 24);
            this.label9.TabIndex = 0;
            this.label9.Text = "/";
            // 
            // m_lblCustom3Name
            // 
            this.m_lblCustom3Name.Location = new System.Drawing.Point(160, 46);
            this.m_lblCustom3Name.Name = "m_lblCustom3Name";
            this.m_lblCustom3Name.Size = new System.Drawing.Size(77, 14);
            this.m_lblCustom3Name.TabIndex = 0;
            this.m_lblCustom3Name.Text = "自定义列3:";
            this.m_lblCustom3Name.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_lblCustom4Name
            // 
            this.m_lblCustom4Name.Location = new System.Drawing.Point(160, 72);
            this.m_lblCustom4Name.Name = "m_lblCustom4Name";
            this.m_lblCustom4Name.Size = new System.Drawing.Size(77, 14);
            this.m_lblCustom4Name.TabIndex = 0;
            this.m_lblCustom4Name.Text = "自定义列4:";
            this.m_lblCustom4Name.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_cmdOK
            // 
            this.m_cmdOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdOK.DefaultScheme = true;
            this.m_cmdOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdOK.Hint = "";
            this.m_cmdOK.Location = new System.Drawing.Point(620, 340);
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
            this.m_cmdCancel.Location = new System.Drawing.Point(713, 340);
            this.m_cmdCancel.Name = "m_cmdCancel";
            this.m_cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCancel.Size = new System.Drawing.Size(64, 32);
            this.m_cmdCancel.TabIndex = 10000023;
            this.m_cmdCancel.Text = "关闭";
            this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdCancel_Click);
            // 
            // m_txtGeneralInstance
            // 
            this.m_txtGeneralInstance.AccessibleDescription = "一般情况";
            this.m_txtGeneralInstance.BackColor = System.Drawing.Color.White;
            this.m_txtGeneralInstance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtGeneralInstance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtGeneralInstance.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtGeneralInstance.Location = new System.Drawing.Point(10, 152);
            this.m_txtGeneralInstance.m_BlnIgnoreUserInfo = false;
            this.m_txtGeneralInstance.m_BlnPartControl = false;
            this.m_txtGeneralInstance.m_BlnReadOnly = false;
            this.m_txtGeneralInstance.m_BlnUnderLineDST = false;
            this.m_txtGeneralInstance.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtGeneralInstance.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtGeneralInstance.m_IntCanModifyTime = 6;
            this.m_txtGeneralInstance.m_IntPartControlLength = 0;
            this.m_txtGeneralInstance.m_IntPartControlStartIndex = 0;
            this.m_txtGeneralInstance.m_StrUserID = "";
            this.m_txtGeneralInstance.m_StrUserName = "";
            this.m_txtGeneralInstance.MaxLength = 8000;
            this.m_txtGeneralInstance.Name = "m_txtGeneralInstance";
            this.m_txtGeneralInstance.Size = new System.Drawing.Size(382, 82);
            this.m_txtGeneralInstance.TabIndex = 10000026;
            this.m_txtGeneralInstance.Text = "";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 134);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 14);
            this.label14.TabIndex = 10000025;
            this.label14.Text = "一般情况:";
            // 
            // m_txtSummary
            // 
            this.m_txtSummary.AccessibleDescription = "小结";
            this.m_txtSummary.BackColor = System.Drawing.Color.White;
            this.m_txtSummary.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSummary.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtSummary.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSummary.Location = new System.Drawing.Point(398, 152);
            this.m_txtSummary.m_BlnIgnoreUserInfo = false;
            this.m_txtSummary.m_BlnPartControl = false;
            this.m_txtSummary.m_BlnReadOnly = false;
            this.m_txtSummary.m_BlnUnderLineDST = false;
            this.m_txtSummary.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtSummary.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtSummary.m_IntCanModifyTime = 6;
            this.m_txtSummary.m_IntPartControlLength = 0;
            this.m_txtSummary.m_IntPartControlStartIndex = 0;
            this.m_txtSummary.m_StrUserID = "";
            this.m_txtSummary.m_StrUserName = "";
            this.m_txtSummary.MaxLength = 8000;
            this.m_txtSummary.Name = "m_txtSummary";
            this.m_txtSummary.Size = new System.Drawing.Size(380, 82);
            this.m_txtSummary.TabIndex = 10000026;
            this.m_txtSummary.Text = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(400, 134);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 14);
            this.label11.TabIndex = 10000025;
            this.label11.Text = "小结:";
            // 
            // m_chkIfSum
            // 
            this.m_chkIfSum.Location = new System.Drawing.Point(20, 234);
            this.m_chkIfSum.Name = "m_chkIfSum";
            this.m_chkIfSum.Size = new System.Drawing.Size(96, 24);
            this.m_chkIfSum.TabIndex = 10000043;
            this.m_chkIfSum.Text = "出入量统计";
            this.m_chkIfSum.CheckedChanged += new System.EventHandler(this.m_chkIfSum_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox4.Controls.Add(this.m_lblThisStatTime);
            this.groupBox4.Controls.Add(this.m_dtpLastStatTime);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.m_txtSumInTime);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.m_txtFactSumIn);
            this.groupBox4.Controls.Add(this.m_txtSumOutTime);
            this.groupBox4.Controls.Add(this.m_txtStandBySumIn);
            this.groupBox4.Controls.Add(this.m_lblCustom2NameSum);
            this.groupBox4.Controls.Add(this.m_lblCustom1NameSum);
            this.groupBox4.Controls.Add(this.m_txtCustom2SumOut);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.m_txtCustom1SumOut);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.m_txtEmictionSumOut);
            this.groupBox4.Controls.Add(this.m_txtSumIn);
            this.groupBox4.Controls.Add(this.m_txtSumOut);
            this.groupBox4.Enabled = false;
            this.groupBox4.Location = new System.Drawing.Point(10, 236);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(589, 147);
            this.groupBox4.TabIndex = 10000039;
            this.groupBox4.TabStop = false;
            // 
            // m_lblThisStatTime
            // 
            this.m_lblThisStatTime.AccessibleDescription = "本次统计时间";
            this.m_lblThisStatTime.AutoSize = true;
            this.m_lblThisStatTime.Location = new System.Drawing.Point(419, 22);
            this.m_lblThisStatTime.Name = "m_lblThisStatTime";
            this.m_lblThisStatTime.Size = new System.Drawing.Size(0, 14);
            this.m_lblThisStatTime.TabIndex = 10000047;
            this.m_lblThisStatTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lblThisStatTime.Visible = false;
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
            this.m_dtpLastStatTime.Font = new System.Drawing.Font("宋体", 12F);
            this.m_dtpLastStatTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpLastStatTime.Location = new System.Drawing.Point(108, 20);
            this.m_dtpLastStatTime.m_BlnOnlyTime = false;
            this.m_dtpLastStatTime.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpLastStatTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpLastStatTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpLastStatTime.Name = "m_dtpLastStatTime";
            this.m_dtpLastStatTime.ReadOnly = false;
            this.m_dtpLastStatTime.Size = new System.Drawing.Size(212, 22);
            this.m_dtpLastStatTime.TabIndex = 10000048;
            this.m_dtpLastStatTime.TextBackColor = System.Drawing.Color.White;
            this.m_dtpLastStatTime.TextForeColor = System.Drawing.Color.Black;
            this.m_dtpLastStatTime.evtValueChanged += new System.EventHandler(this.m_dtpLastStatTime_evtValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(98, 14);
            this.label13.TabIndex = 10000046;
            this.label13.Text = "统计起始时间:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(326, 22);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(98, 14);
            this.label21.TabIndex = 10000045;
            this.label21.Text = "统计结束时间:";
            this.label21.Visible = false;
            // 
            // m_txtSumInTime
            // 
            this.m_txtSumInTime.AccessibleDescription = "入量统计时间";
            this.m_txtSumInTime.Location = new System.Drawing.Point(10, 47);
            this.m_txtSumInTime.Name = "m_txtSumInTime";
            this.m_txtSumInTime.Size = new System.Drawing.Size(62, 23);
            this.m_txtSumInTime.TabIndex = 111;
            this.m_txtSumInTime.MouseLeave += new System.EventHandler(this.m_evtSum_MouseLeave);
            this.m_txtSumInTime.Leave += new System.EventHandler(this.m_txtSum_Leave);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(41, 122);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(91, 14);
            this.label20.TabIndex = 112;
            this.label20.Text = "实用量总入量";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(41, 88);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(91, 14);
            this.label17.TabIndex = 112;
            this.label17.Text = "备用量总入量";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(76, 51);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(56, 14);
            this.label18.TabIndex = 112;
            this.label18.Text = "H总入量";
            // 
            // m_txtFactSumIn
            // 
            this.m_txtFactSumIn.AccessibleDescription = "实用量总入量";
            this.m_txtFactSumIn.Location = new System.Drawing.Point(134, 117);
            this.m_txtFactSumIn.Name = "m_txtFactSumIn";
            this.m_txtFactSumIn.Size = new System.Drawing.Size(124, 23);
            this.m_txtFactSumIn.TabIndex = 111;
            this.m_txtFactSumIn.MouseLeave += new System.EventHandler(this.m_evtSum_MouseLeave);
            this.m_txtFactSumIn.Leave += new System.EventHandler(this.m_txtSum_Leave);
            // 
            // m_txtSumOutTime
            // 
            this.m_txtSumOutTime.AccessibleDescription = "出量统计时间";
            this.m_txtSumOutTime.Location = new System.Drawing.Point(329, 47);
            this.m_txtSumOutTime.Name = "m_txtSumOutTime";
            this.m_txtSumOutTime.Size = new System.Drawing.Size(62, 23);
            this.m_txtSumOutTime.TabIndex = 111;
            this.m_txtSumOutTime.MouseLeave += new System.EventHandler(this.m_evtSum_MouseLeave);
            this.m_txtSumOutTime.Leave += new System.EventHandler(this.m_txtSum_Leave);
            // 
            // m_txtStandBySumIn
            // 
            this.m_txtStandBySumIn.AccessibleDescription = "备用量总入量";
            this.m_txtStandBySumIn.Location = new System.Drawing.Point(134, 82);
            this.m_txtStandBySumIn.Name = "m_txtStandBySumIn";
            this.m_txtStandBySumIn.Size = new System.Drawing.Size(124, 23);
            this.m_txtStandBySumIn.TabIndex = 111;
            this.m_txtStandBySumIn.MouseLeave += new System.EventHandler(this.m_evtSum_MouseLeave);
            this.m_txtStandBySumIn.Leave += new System.EventHandler(this.m_txtSum_Leave);
            // 
            // m_lblCustom2NameSum
            // 
            this.m_lblCustom2NameSum.Location = new System.Drawing.Point(339, 123);
            this.m_lblCustom2NameSum.Name = "m_lblCustom2NameSum";
            this.m_lblCustom2NameSum.Size = new System.Drawing.Size(112, 14);
            this.m_lblCustom2NameSum.TabIndex = 112;
            this.m_lblCustom2NameSum.Text = "自定义列2总出量";
            this.m_lblCustom2NameSum.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_lblCustom1NameSum
            // 
            this.m_lblCustom1NameSum.Location = new System.Drawing.Point(339, 101);
            this.m_lblCustom1NameSum.Name = "m_lblCustom1NameSum";
            this.m_lblCustom1NameSum.Size = new System.Drawing.Size(112, 14);
            this.m_lblCustom1NameSum.TabIndex = 112;
            this.m_lblCustom1NameSum.Text = "自定义列1总出量";
            this.m_lblCustom1NameSum.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_txtCustom2SumOut
            // 
            this.m_txtCustom2SumOut.AccessibleDescription = "自定义列2总出量";
            this.m_txtCustom2SumOut.Location = new System.Drawing.Point(453, 119);
            this.m_txtCustom2SumOut.Name = "m_txtCustom2SumOut";
            this.m_txtCustom2SumOut.Size = new System.Drawing.Size(124, 23);
            this.m_txtCustom2SumOut.TabIndex = 111;
            this.m_txtCustom2SumOut.MouseLeave += new System.EventHandler(this.m_evtSum_MouseLeave);
            this.m_txtCustom2SumOut.Leave += new System.EventHandler(this.m_txtSum_Leave);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(388, 79);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(63, 14);
            this.label22.TabIndex = 112;
            this.label22.Text = "尿总出量";
            // 
            // m_txtCustom1SumOut
            // 
            this.m_txtCustom1SumOut.AccessibleDescription = "自定义列1总出量";
            this.m_txtCustom1SumOut.Location = new System.Drawing.Point(453, 95);
            this.m_txtCustom1SumOut.Name = "m_txtCustom1SumOut";
            this.m_txtCustom1SumOut.Size = new System.Drawing.Size(124, 23);
            this.m_txtCustom1SumOut.TabIndex = 111;
            this.m_txtCustom1SumOut.MouseLeave += new System.EventHandler(this.m_evtSum_MouseLeave);
            this.m_txtCustom1SumOut.Leave += new System.EventHandler(this.m_txtSum_Leave);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(395, 52);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(56, 14);
            this.label19.TabIndex = 112;
            this.label19.Text = "H总出量";
            // 
            // m_txtEmictionSumOut
            // 
            this.m_txtEmictionSumOut.AccessibleDescription = "尿总出量";
            this.m_txtEmictionSumOut.Location = new System.Drawing.Point(453, 71);
            this.m_txtEmictionSumOut.Name = "m_txtEmictionSumOut";
            this.m_txtEmictionSumOut.Size = new System.Drawing.Size(124, 23);
            this.m_txtEmictionSumOut.TabIndex = 111;
            this.m_txtEmictionSumOut.MouseLeave += new System.EventHandler(this.m_evtSum_MouseLeave);
            this.m_txtEmictionSumOut.Leave += new System.EventHandler(this.m_txtSum_Leave);
            // 
            // m_txtSumIn
            // 
            this.m_txtSumIn.AccessibleDescription = "总入量";
            this.m_txtSumIn.Location = new System.Drawing.Point(134, 47);
            this.m_txtSumIn.Name = "m_txtSumIn";
            this.m_txtSumIn.Size = new System.Drawing.Size(124, 23);
            this.m_txtSumIn.TabIndex = 111;
            this.m_txtSumIn.MouseLeave += new System.EventHandler(this.m_evtSum_MouseLeave);
            this.m_txtSumIn.Leave += new System.EventHandler(this.m_txtSum_Leave);
            // 
            // m_txtSumOut
            // 
            this.m_txtSumOut.AccessibleDescription = "总出量";
            this.m_txtSumOut.Location = new System.Drawing.Point(453, 47);
            this.m_txtSumOut.Name = "m_txtSumOut";
            this.m_txtSumOut.Size = new System.Drawing.Size(124, 23);
            this.m_txtSumOut.TabIndex = 111;
            this.m_txtSumOut.MouseLeave += new System.EventHandler(this.m_evtSum_MouseLeave);
            this.m_txtSumOut.Leave += new System.EventHandler(this.m_txtSum_Leave);
            // 
            // m_lblHasStatTips
            // 
            this.m_lblHasStatTips.ForeColor = System.Drawing.Color.Blue;
            this.m_lblHasStatTips.Location = new System.Drawing.Point(588, 0);
            this.m_lblHasStatTips.Name = "m_lblHasStatTips";
            this.m_lblHasStatTips.Size = new System.Drawing.Size(196, 32);
            this.m_lblHasStatTips.TabIndex = 10000044;
            // 
            // txtSign
            // 
            this.txtSign.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSign.Enabled = false;
            this.txtSign.Location = new System.Drawing.Point(672, 258);
            this.txtSign.Name = "txtSign";
            this.txtSign.Size = new System.Drawing.Size(106, 23);
            this.txtSign.TabIndex = 10000050;
            // 
            // m_cmbsign
            // 
            this.m_cmbsign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmbsign.DefaultScheme = true;
            this.m_cmbsign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmbsign.Hint = "";
            this.m_cmbsign.Location = new System.Drawing.Point(604, 249);
            this.m_cmbsign.Name = "m_cmbsign";
            this.m_cmbsign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmbsign.Size = new System.Drawing.Size(64, 32);
            this.m_cmbsign.TabIndex = 10000049;
            this.m_cmbsign.Text = "签名";
            // 
            // frmICUNurseRecord_GXCon
            // 
            this.ClientSize = new System.Drawing.Size(798, 395);
            this.Controls.Add(this.txtSign);
            this.Controls.Add(this.m_cmbsign);
            this.Controls.Add(this.m_lblHasStatTips);
            this.Controls.Add(this.m_chkIfSum);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.m_txtGeneralInstance);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_cmdOK);
            this.Controls.Add(this.m_cmdCancel);
            this.Controls.Add(this.m_txtSummary);
            this.Controls.Add(this.label11);
            this.Name = "frmICUNurseRecord_GXCon";
            this.Text = "ICU护理记录";
            this.Load += new System.EventHandler(this.frmICUNurseRecord_GXCon_Load);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.m_txtSummary, 0);
            this.Controls.SetChildIndex(this.m_cmdCancel, 0);
            this.Controls.SetChildIndex(this.m_cmdOK, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
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
            this.Controls.SetChildIndex(this.m_dtpCreateDate, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.m_txtGeneralInstance, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.Controls.SetChildIndex(this.m_chkIfSum, 0);
            this.Controls.SetChildIndex(this.m_lblHasStatTips, 0);
            this.Controls.SetChildIndex(this.m_cmbsign, 0);
            this.Controls.SetChildIndex(this.txtSign, 0);
            this.m_pnlNewBase.ResumeLayout(false);
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

			this.m_txtItem.m_mthClearText();
			this.m_txtInAmountStandby.m_mthClearText();
			this.m_txtInAmountFact.m_mthClearText();
			this.m_txtOutEmiction.m_mthClearText();
			this.m_txtT.m_mthClearText();
			this.m_txtHR.m_mthClearText();
			this.m_txtR.m_mthClearText();
			this.m_txtBloodPressureA.m_mthClearText();
			this.m_txtBloodPressureS.m_mthClearText();
			this.m_txtA.m_mthClearText();
			this.m_txtspo2.m_mthClearText();
			this.m_txtGeneralInstance.m_mthClearText();
			this.m_txtCustom1.m_mthClearText();
			this.m_txtCustom2.m_mthClearText();
			this.m_txtSummary.m_mthClearText();
			this.m_chkIfSum.Checked = false;
			label21.Visible = false;
			m_lblThisStatTime.Visible = false;			
            //m_objSignTool.m_mthSetDefaulEmployee();
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
			clsICUNurseRecordContentGX objContent=(clsICUNurseRecordContentGX )p_objContent;
			//把表单值赋值到界面，由子窗体重载实现			
			this.m_mthClearRecordInfo();

			this.m_txtItem.m_mthSetNewText(objContent.m_strINAMOUNTITEM,objContent.m_strINAMOUNTITEMXML);
			this.m_txtInAmountStandby.m_mthSetNewText(objContent.m_strINAMOUNTSTANDBY,objContent.m_strINAMOUNTSTANDBYXML);
			this.m_txtInAmountFact.m_mthSetNewText(objContent.m_strINAMOUNTFACT,objContent.m_strINAMOUNTFACTXML);
			this.m_txtOutEmiction.m_mthSetNewText(objContent.m_strOUTEMICTION,objContent.m_strOUTEMICTIONXML);
			this.m_txtT.m_mthSetNewText(objContent.m_strTEMPERATURE,objContent.m_strTEMPERATUREXML);
			this.m_txtHR.m_mthSetNewText(objContent.m_strHR,objContent.m_strHRXML);
			this.m_txtR.m_mthSetNewText(objContent.m_strRESPIRATION,objContent.m_strRESPIRATIONXML);
			this.m_txtBloodPressureA.m_mthSetNewText(objContent.m_strBLOODPRESSUREA,objContent.m_strBLOODPRESSUREAXML);
			this.m_txtBloodPressureS.m_mthSetNewText(objContent.m_strBLOODPRESSURES,objContent.m_strBLOODPRESSURESXML);
			this.m_txtA.m_mthSetNewText(objContent.m_strA,objContent.m_strAXML);
			this.m_txtspo2.m_mthSetNewText(objContent.m_strSP02,objContent.m_strSP02XML);
			this.m_txtGeneralInstance.m_mthSetNewText(objContent.m_strGENERALINSTANCE,objContent.m_strGENERALINSTANCEXML);
			this.m_txtCustom1.m_mthSetNewText(objContent.m_strCustom1, objContent.m_strCustom1XML);
			this.m_txtCustom2.m_mthSetNewText(objContent.m_strCustom2, objContent.m_strCustom2XML);
			this.m_txtSummary.m_mthSetNewText(objContent.m_strSummary, objContent.m_strSummaryXML);

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
                m_dblStandBySumGUI = 0;
                m_dblFactSumGUI = 0;
                m_dblPissSumGUI = 0;
                m_dblCustom2SumGUI = 0;
                m_dblCustom1SumGUI = 0;
				m_mthGetInOutFromGUI(ref m_dblSumInGUI, ref m_dblSumOutGUI, ref m_dblStandBySumGUI, ref m_dblFactSumGUI,
                    ref m_dblPissSumGUI, ref m_dblCustom1SumGUI, ref m_dblCustom2SumGUI);
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
			clsICUNurseRecordContentGX objContent=(clsICUNurseRecordContentGX )p_objContent;
			//把表单值赋值到界面，由子窗体重载实现			

			this.m_mthClearRecordInfo();
		
			this.m_txtItem.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strINAMOUNTITEM,objContent.m_strINAMOUNTITEMXML);
			this.m_txtInAmountStandby.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strINAMOUNTSTANDBY,objContent.m_strINAMOUNTSTANDBYXML);
			this.m_txtInAmountFact.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strINAMOUNTFACT,objContent.m_strINAMOUNTFACTXML);
			this.m_txtOutEmiction.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strOUTEMICTION,objContent.m_strOUTEMICTIONXML);
			this.m_txtT.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strTEMPERATURE,objContent.m_strTEMPERATUREXML);
			this.m_txtHR.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strHR,objContent.m_strHRXML);
			this.m_txtR.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strRESPIRATION,objContent.m_strRESPIRATIONXML);
			this.m_txtBloodPressureA.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strBLOODPRESSUREA,objContent.m_strBLOODPRESSUREAXML);
			this.m_txtBloodPressureS.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strBLOODPRESSURES,objContent.m_strBLOODPRESSURESXML);
			this.m_txtA.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strA,objContent.m_strAXML);
			this.m_txtspo2.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strSP02,objContent.m_strSP02XML);
			this.m_txtGeneralInstance.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strGENERALINSTANCE,objContent.m_strGENERALINSTANCEXML);
			this.m_txtCustom1.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strCustom1, objContent.m_strCustom1XML);
			this.m_txtCustom2.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strCustom2, objContent.m_strCustom2XML);
			this.m_txtSummary.Text=ctlRichTextBox.s_strGetRightText(objContent.m_strSummary, objContent.m_strSummaryXML);

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
                m_dblStandBySumGUI = 0;
                m_dblFactSumGUI = 0;
                m_dblPissSumGUI = 0;
                m_dblCustom2SumGUI = 0;
                m_dblCustom1SumGUI = 0;
                m_mthGetInOutFromGUI(ref m_dblSumInGUI, ref m_dblSumOutGUI, ref m_dblStandBySumGUI, ref m_dblFactSumGUI,
                    ref m_dblPissSumGUI, ref m_dblCustom1SumGUI, ref m_dblCustom2SumGUI);
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

		protected override iCareData.clsTrackRecordContent m_objGetContentFromGUI()
		{
			
			//界面参数校验
			if(m_objCurrentPatient==null || m_ObjCurrentEmrPatientSession == null)				
				return null;

			//从界面获取表单值		
			clsICUNurseRecordContentGX objContent=new clsICUNurseRecordContentGX ();
			try
			{
				objContent.m_dtmCreateDate =DateTime.Now ;

				objContent.m_strINAMOUNTITEM_RIGHT=this.m_txtItem.m_strGetRightText();
				objContent.m_strINAMOUNTITEM=this.m_txtItem.Text;
				objContent.m_strINAMOUNTITEMXML=this.m_txtItem.m_strGetXmlText();

				objContent.m_strINAMOUNTSTANDBY_RIGHT=this.m_txtInAmountStandby.m_strGetRightText();
				objContent.m_strINAMOUNTSTANDBY=this.m_txtInAmountStandby.Text;
				objContent.m_strINAMOUNTSTANDBYXML=this.m_txtInAmountStandby.m_strGetXmlText();

				objContent.m_strINAMOUNTFACT_RIGHT=this.m_txtInAmountFact.m_strGetRightText();
				objContent.m_strINAMOUNTFACT=this.m_txtInAmountFact.Text;
				objContent.m_strINAMOUNTFACTXML=this.m_txtInAmountFact.m_strGetXmlText();

				objContent.m_strOUTEMICTION_RIGHT=this.m_txtOutEmiction.m_strGetRightText();
				objContent.m_strOUTEMICTION=this.m_txtOutEmiction.Text;
				objContent.m_strOUTEMICTIONXML=this.m_txtOutEmiction.m_strGetXmlText();

				objContent.m_strTEMPERATURE_RIGHT=this.m_txtT.m_strGetRightText();
				objContent.m_strTEMPERATURE=this.m_txtT.Text;
				objContent.m_strTEMPERATUREXML=this.m_txtT.m_strGetXmlText();

				objContent.m_strHR_RIGHT=this.m_txtHR.m_strGetRightText();
				objContent.m_strHR=this.m_txtHR.Text;
				objContent.m_strHRXML=this.m_txtHR.m_strGetXmlText();

				objContent.m_strRESPIRATION_RIGHT=this.m_txtR.m_strGetRightText();
				objContent.m_strRESPIRATION=this.m_txtR.Text;
				objContent.m_strRESPIRATIONXML=this.m_txtR.m_strGetXmlText();
            			
				objContent.m_strBLOODPRESSUREA_RIGHT=this.m_txtBloodPressureA.m_strGetRightText();
				objContent.m_strBLOODPRESSUREA=this.m_txtBloodPressureA.Text;
				objContent.m_strBLOODPRESSUREAXML=this.m_txtBloodPressureA.m_strGetXmlText();

				objContent.m_strBLOODPRESSURES_RIGHT=this.m_txtBloodPressureS.m_strGetRightText();
				objContent.m_strBLOODPRESSURES=this.m_txtBloodPressureS.Text ;
				objContent.m_strBLOODPRESSURESXML=this.m_txtBloodPressureS.m_strGetXmlText();

				objContent.m_strA_RIGHT=this.m_txtA.m_strGetRightText();
				objContent.m_strA=this.m_txtA.Text;
				objContent.m_strAXML=this.m_txtA.m_strGetXmlText();

				objContent.m_strSP02_RIGHT=this.m_txtspo2.m_strGetRightText();
				objContent.m_strSP02=this.m_txtspo2.Text;
				objContent.m_strSP02XML=this.m_txtspo2.m_strGetXmlText();

				objContent.m_strGENERALINSTANCE_RIGHT=this.m_txtGeneralInstance.m_strGetRightText();
				objContent.m_strGENERALINSTANCE=this.m_txtGeneralInstance.Text;
				objContent.m_strGENERALINSTANCEXML=this.m_txtGeneralInstance.m_strGetXmlText();

				objContent.m_strCustom1_Right = this.m_txtCustom1.m_strGetRightText();
				objContent.m_strCustom1 = this.m_txtCustom1.Text;
				objContent.m_strCustom1XML = this.m_txtCustom1.m_strGetXmlText();

				objContent.m_strCustom2_Right = this.m_txtCustom2.m_strGetRightText();
				objContent.m_strCustom2 = this.m_txtCustom2.Text;
				objContent.m_strCustom2XML = this.m_txtCustom2.m_strGetXmlText();

				objContent.m_strSummary_Right = this.m_txtSummary.m_strGetRightText();
				objContent.m_strSummary = this.m_txtSummary.Text;
				objContent.m_strSummaryXML = this.m_txtSummary.m_strGetXmlText();

                objContent.m_strCustom1Name = m_strCustomNameArr[0];
                objContent.m_strCustom2Name = m_strCustomNameArr[1];
                objContent.m_strCustom3Name = m_strCustomNameArr[2];
                objContent.m_strCustom4Name = m_strCustomNameArr[3];

				if(m_chkIfSum.Checked)
				{
					objContent.m_intISSTAT = 1;
					objContent.m_strSUMIN = m_txtSumIn.Text;
					objContent.m_strSUMOUT = m_txtSumOut.Text;
                    objContent.m_strINSTANDBYSUM = m_txtStandBySumIn.Text;
                    objContent.m_strINFACTSUM = m_txtFactSumIn.Text;
                    objContent.m_strOUTEMICTIONSUM = m_txtEmictionSumOut.Text;
                    objContent.m_strOUTCUSTOM1SUM = m_txtCustom1SumOut.Text;
                    objContent.m_strOUTCUSTOM2SUM = m_txtCustom2SumOut.Text;
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
                    if (m_strAutoStandBySum != null && m_strAutoStandBySum != "" && m_strAutoStandBySum.Trim() != m_txtStandBySumIn.Text.Trim())
                    {
                        objContent.m_strAUTOINSTANDBYSUM = m_strAutoStandBySum;
                    }
                    if (m_strAutoFactSum != null && m_strAutoFactSum != "" && m_strAutoFactSum.Trim() != m_txtFactSumIn.Text.Trim())
                    {
                        objContent.m_strAUTOINFACTSUM = m_strAutoFactSum;
                    }
                    if (m_strAutoPissSum != null && m_strAutoPissSum != "" && m_strAutoPissSum.Trim() != m_txtEmictionSumOut.Text.Trim())
                    {
                        objContent.m_strAUTOOUTEMICTIONSUM = m_strAutoPissSum;
                    }
                    if (m_strAutoCustom1Sum != null && m_strAutoCustom1Sum != "" && m_strAutoCustom1Sum.Trim() != m_txtCustom1SumOut.Text.Trim())
                    {
                        objContent.m_strAUTOOUTCUSTOM1SUM = m_strAutoCustom1Sum;
                    }
                    if (m_strAutoCustom2Sum != null && m_strAutoCustom2Sum != "" && m_strAutoCustom2Sum.Trim() != m_txtCustom2SumOut.Text.Trim())
                    {
                        objContent.m_strAUTOOUTCUSTOM2SUM = m_strAutoCustom2Sum;
                    }
				}
				else
				{
					objContent.m_intISSTAT = 0;
				}

                //objContent.m_strCreateUserName = m_txtEmpSign.Text.Trim();
                //objContent.m_strCreateUserID = ((clsEmployee)m_txtEmpSign.Tag).m_StrEmployeeID;
                //objContent.m_dtmModifyDate = DateTime.Now;
                //objContent.m_strModifyUserID = MDIParent.OperatorID;

                objContent.m_strCreateUserID = ((clsEmrEmployeeBase_VO)txtSign.Tag).m_strEMPNO_CHR;
                objContent.m_dtmModifyDate = DateTime.Now;
                objContent.m_strModifyUserID = ((clsEmrEmployeeBase_VO)txtSign.Tag).m_strEMPNO_CHR;
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
                return null;
			}

			return(objContent );		
		}

		protected override iCare.clsDiseaseTrackDomain m_objGetDiseaseTrackDomain()
		{
			//获取护理记录的领域层实例，由子窗体重载实现
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.ICUNurseRecord_GX);					
		}

		/// <summary>
		/// 把选择时间记录内容重新整理为完全正确的内容。
		/// </summary>
		/// <param name="p_objRecordContent"></param>
		protected override void m_mthReAddNewRecord(clsTrackRecordContent p_objRecordContent)
		{
			//把选择时间记录内容重新整理为完全正确的内容，由子窗体重载实现。
			clsICUNurseRecordContentGX objContent=(clsICUNurseRecordContentGX)p_objRecordContent;
		}

		public override string m_strReloadFormTitle()
		{
			//由子窗体重载实现

			return	"ICU护理记录";
		}

		
		#region Jump Control
		protected override void m_mthInitJump(clsJumpControl p_objJump)
		{
			p_objJump=new clsJumpControl(this,
				new Control[]{m_txtItem,m_txtInAmountStandby,m_txtInAmountFact,m_txtOutEmiction,m_txtCustom1,m_txtCustom2,m_txtT,m_txtHR,
								 m_txtR,m_txtBloodPressureA,m_txtBloodPressureS,m_txtA,m_txtspo2,m_txtGeneralInstance,m_txtSummary},Keys.Enter);
		}
		#endregion

		private void frmICUNurseRecord_GXCon_Load(object sender, System.EventArgs e)
		{
			m_txtItem.Focus();
			m_mthGetStatTimeArr();
			if(m_objCurrentRecordContent == null)
				m_mthSetStartStatTime();
		}

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

		private void m_chkIfSum_CheckedChanged(object sender, System.EventArgs e)
		{
			groupBox4.Enabled = m_chkIfSum.Checked;
			label21.Visible = m_chkIfSum.Checked;
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

		private void m_dtpCreateDate_evtValueChanged(object sender, System.EventArgs e)
		{			
			m_lblThisStatTime.Text = m_dtpCreateDate.Value.ToString("yyyy年MM月dd日 HH:mm");
			if(m_chkIfSum.Checked)
			{
				m_mthSetStartStatTime();
			}
		}

		#region 查询数据库，获取统计相关信息
		private void m_mthGetStatTimeArr()
		{
			clsICUNurseRecordContentGX[] objRecordArr = null;

            clsICUNurseRecord_GXService m_objServ =
                (clsICUNurseRecord_GXService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsICUNurseRecord_GXService));

			long lngRes = m_objServ.m_lngGetStatRecordTime(m_objCurrentPatient.m_StrInPatientID, m_objCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"), out objRecordArr);
			if(lngRes > 0 && objRecordArr != null)
			{
				m_objRecordArr = objRecordArr;
			}
            //m_objServ.Dispose();
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
            double dblStandbySum = 0;
            double dblFactSum = 0;
            double dblSumIn = m_dblGetInSum(dtStart, dtEnd, out dblStandbySum, out dblFactSum);
            double dblPissSum = 0;
            double dblCustom1Sum = 0;
            double dblCustom2Sum = 0;
            double dblSumOut = m_dblGetOutSum(dtStart, dtEnd, out dblPissSum, out dblCustom1Sum, out dblCustom2Sum);
			TimeSpan tsTime = dtEnd - dtStart;
			if(m_objCurrentRecordContent != null)
			{
				dblSumIn -= m_dblSumInGUI;
                dblStandbySum -= m_dblStandBySumGUI;
                dblFactSum -= m_dblFactSumGUI;
				dblSumOut -= m_dblSumOutGUI;
                dblPissSum -= m_dblPissSumGUI;
                dblCustom1Sum -= m_dblCustom1SumGUI;
                dblCustom2Sum -= m_dblCustom2SumGUI;
			}

			m_dblSumInGUI = 0;
			m_dblSumOutGUI = 0;
            m_dblStandBySumGUI = 0;
            m_dblFactSumGUI = 0;
            m_dblPissSumGUI = 0;
            m_dblCustom2SumGUI = 0;
            m_dblCustom1SumGUI = 0;
            m_mthGetInOutFromGUI(ref m_dblSumInGUI, ref m_dblSumOutGUI, ref m_dblStandBySumGUI, ref m_dblFactSumGUI,
                ref m_dblPissSumGUI, ref m_dblCustom1SumGUI, ref m_dblCustom2SumGUI);

			m_txtSumIn.Text = (m_dblSumInGUI + dblSumIn).ToString();
			m_txtSumOut.Text = (m_dblSumOutGUI + dblSumOut).ToString();
            m_txtStandBySumIn.Text = (m_dblStandBySumGUI + dblStandbySum).ToString();
            m_txtFactSumIn.Text = (m_dblFactSumGUI + dblFactSum).ToString();
            m_txtEmictionSumOut.Text = (m_dblPissSumGUI + dblPissSum).ToString();
            m_txtCustom1SumOut.Text = (m_dblCustom1SumGUI + dblCustom1Sum).ToString();
            m_txtCustom2SumOut.Text = (m_dblCustom2SumGUI + dblCustom2Sum).ToString();

			m_strAutoSumIn = (m_dblSumInGUI + dblSumIn).ToString();
			m_strAutoSumOut = (m_dblSumOutGUI + dblSumOut).ToString();
            m_strAutoStandBySum = (m_dblStandBySumGUI + dblStandbySum).ToString();
            m_strAutoFactSum = (m_dblFactSumGUI + dblFactSum).ToString();
            m_strAutoPissSum = (m_dblPissSumGUI + dblPissSum).ToString();
            m_strAutoCustom1Sum = (m_dblCustom1SumGUI + dblCustom1Sum).ToString();
            m_strAutoCustom2Sum = (m_dblCustom2SumGUI + dblCustom2Sum).ToString();

			m_dblOriAutoSumIn = m_dblSumInGUI + dblSumIn;
			m_dblOriAutoSumOut = m_dblSumOutGUI + dblSumOut;
            m_dblOriAutoStandBySum = m_dblStandBySumGUI + dblStandbySum;
            m_dblOriAutoFactSum = m_dblFactSumGUI + dblFactSum;
            m_dblOriAutoPissSum = m_dblPissSumGUI + dblPissSum;
            m_dblOriAutoCustom1Sum = m_dblCustom1SumGUI + dblCustom1Sum;
            m_dblOriAutoCustom2Sum = m_dblCustom2SumGUI + dblCustom2Sum;

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
					DateTime.Parse(m_objRecordArr[i].m_dtmCreateDate.ToString("yyyy-MM-dd HH:mm")) < DateTime.Parse(m_dtpCreateDate.Value.ToString("yyyy-MM-dd HH:mm")) &&
					DateTime.Parse(m_objRecordArr[i+1].m_dtmCreateDate.ToString("yyyy-MM-dd HH:mm")) > DateTime.Parse(m_dtpCreateDate.Value.ToString("yyyy-MM-dd HH:mm")))
				{
					if(m_objRecordArr[i+1].m_intSUMINTIME == 24 || m_objRecordArr[i+1].m_intSUMOUTTIME == 24)
					{
						m_lblHasStatTips.Text = "在"+m_objRecordArr[i+1].m_dtmCreateDate.ToString("yyyy年MM月dd日 HH:mm")+"已经进行了一次24小时出入量统计";
					}
				}
			}
		}

		#region 获取当前界面未保存的出入量
		/// <summary>
        /// 获取当前界面未保存的出入量
		/// </summary>
		/// <param name="p_dblSumIn">总入量</param>
		/// <param name="p_dblSumOut">总出量</param>
		/// <param name="p_dblStandBySum">备用量总入量</param>
		/// <param name="p_dblFactSum">实入量总入量</param>
		/// <param name="p_dblPissSum">尿量总出量</param>
		/// <param name="p_dblCustom1Sum">自定义列1总出量</param>
		/// <param name="p_dblCustom2Sum">自定义列2总出量</param>
		private void m_mthGetInOutFromGUI(ref double p_dblSumIn, ref double p_dblSumOut, ref double p_dblStandBySum, 
            ref double p_dblFactSum, ref double p_dblPissSum, ref double p_dblCustom1Sum, ref double p_dblCustom2Sum)
		{
			double dblTemp = 0;
			if(m_txtInAmountStandby.Text.Trim() != "")
			{
				try
				{
					dblTemp = double.Parse(m_txtInAmountStandby.Text);
                    p_dblStandBySum = dblTemp;
				}
				catch{}
                p_dblSumIn += p_dblStandBySum;
			}
			if(m_txtInAmountFact.Text.Trim() != "")
			{
				try
				{
					dblTemp = double.Parse(m_txtInAmountFact.Text);
                    p_dblFactSum = dblTemp;
				}
				catch{}
                p_dblSumIn += p_dblFactSum;
			}
			if(m_txtOutEmiction.Text.Trim() != "")
			{
				try
				{
					dblTemp = double.Parse(m_txtOutEmiction.Text);
                    p_dblPissSum = dblTemp;
				}
				catch{}
                p_dblSumOut += p_dblPissSum;
			}
			if(m_txtCustom1.Text.Trim() != "")
			{
				try
				{
					dblTemp = double.Parse(m_txtCustom1.Text);
                    p_dblCustom1Sum = dblTemp;
				}
				catch{}
                p_dblSumOut += p_dblCustom1Sum;
			}
			if(m_txtCustom2.Text.Trim() != "")
			{
				try
				{
					dblTemp = double.Parse(m_txtCustom2.Text);
                    p_dblCustom2Sum = dblTemp;
				}
				catch{}
                p_dblSumOut += p_dblCustom2Sum;
			}
		}
		#endregion

		/// <summary>
        /// 获取总入量
		/// </summary>
		/// <param name="dtStartTime"></param>
		/// <param name="dtEndTime"></param>
		/// <param name="p_dblStadbySum">备用量总量</param>
		/// <param name="p_dblFactSum">实入量总量</param>
		/// <returns></returns>
		private double m_dblGetInSum(DateTime dtStartTime, 
            DateTime dtEndTime,
            out double p_dblStadbySum, 
            out double p_dblFactSum)
		{
			double dblInSum = 0;
            p_dblStadbySum = 0;
            p_dblFactSum = 0;
			string[] strStandbyArr = null;
			double[] dblFactArr = null;
			if(MDIParent.s_ObjCurrentPatient == null)
				return 0;

            clsICUNurseRecord_GXService m_objServ =
                (clsICUNurseRecord_GXService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsICUNurseRecord_GXService));

			long lngRes = m_objServ.m_lngGetInSum(MDIParent.s_ObjCurrentPatient.m_StrInPatientID, MDIParent.s_ObjCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"),
				dtEndTime.ToString("yyyy-MM-dd HH:mm:ss"), dtStartTime.ToString("yyyy-MM-dd HH:mm:ss"),out strStandbyArr, out dblFactArr);
            //m_objServ.Dispose();
			if(lngRes > 0)
			{
				if(strStandbyArr != null)
				{
					double dblSA = 0;
					for(int i=0; i<strStandbyArr.Length; i++)
					{
						if(strStandbyArr[i] != "" || strStandbyArr[i] != null)
						{
							try
							{
								dblSA = double.Parse(strStandbyArr[i]);
                                p_dblStadbySum += dblSA;
							}
							catch{}
						}
					}
                    dblInSum += p_dblStadbySum;
				}
				if(dblFactArr != null)
				{
					for(int i=0; i<dblFactArr.Length; i++)
					{
                        p_dblFactSum += dblFactArr[i];
					}
                    dblInSum += p_dblFactSum;
				}
			}
			return dblInSum;
		}

		/// <summary>
        /// 获取总出量
		/// </summary>
		/// <param name="dtStartTime"></param>
		/// <param name="dtEndTime"></param>
		/// <param name="p_dblPissSum">尿量总出量</param>
		/// <param name="p_dblCustom1Sum">自定义列1总出量</param>
		/// <param name="p_dblCustom2Sum">自定义列2总出量</param>
		/// <returns></returns>
		private double m_dblGetOutSum(DateTime dtStartTime, DateTime dtEndTime,
            out double p_dblPissSum, out double p_dblCustom1Sum, out double p_dblCustom2Sum)
		{
            p_dblPissSum = 0;
            p_dblCustom1Sum = 0; 
            p_dblCustom2Sum = 0;
			if(MDIParent.s_ObjCurrentPatient == null)
				return 0;
			double dblOutSum = 0;
			double[] dblOutPissArr = null;
			double[] p_dblCustom1Arr = null;
			double[] p_dblCustom2Arr = null;

            clsICUNurseRecord_GXService m_objServ =
                (clsICUNurseRecord_GXService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsICUNurseRecord_GXService));

			long lngRes = m_objServ.m_lngGetOutSum(MDIParent.s_ObjCurrentPatient.m_StrInPatientID, MDIParent.s_ObjCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"),
				dtEndTime.ToString("yyyy-MM-dd HH:mm:ss"), dtStartTime.ToString("yyyy-MM-dd HH:mm:ss"), out dblOutPissArr, out p_dblCustom1Arr,out p_dblCustom2Arr);
            //m_objServ.Dispose();
			if(lngRes > 0 && dblOutPissArr != null && p_dblCustom1Arr!=null && p_dblCustom2Arr != null)
			{
				for(int i=0; i<dblOutPissArr.Length; i++)
				{
                    p_dblPissSum += dblOutPissArr[i];
				}
                dblOutSum += p_dblPissSum;
				for(int i=0; i<p_dblCustom1Arr.Length; i++)
				{
                    p_dblCustom1Sum += p_dblCustom1Arr[i];
				}
                dblOutSum += p_dblCustom1Sum;
				for(int i=0; i<p_dblCustom2Arr.Length; i++)
				{
                    p_dblCustom2Sum += p_dblCustom2Arr[i];
				}
                dblOutSum += p_dblCustom2Sum;
			}
			return dblOutSum;
		}
		#endregion

		#region 界面数据改变时进行统计
		private void m_txtInFact_TextChanged(object sender, System.EventArgs e)
		{				
			if(m_chkIfSum.Checked)
			{
				double dblText = 0;
				double dblIn = 0;
				double dblOut = 0;
                double dblStanyBy = 0;
                double dblFact = 0;
                double dblPiss = 0;
                double dblCustom1 = 0;
                double dblCustom2 = 0; 
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
                    m_mthGetInOutFromGUI(ref dblIn, ref dblOut, ref dblStanyBy, 
                        ref dblFact, ref dblPiss, ref dblCustom1,ref dblCustom2);
					m_txtSumIn.Text = (m_dblOriAutoSumIn - m_dblSumInGUI + dblIn).ToString();
					m_strAutoSumIn = (m_dblOriAutoSumIn - m_dblSumInGUI + dblIn).ToString();
                    if (((com.digitalwave.controls.ctlRichTextBox)sender).Name == "m_txtInAmountStandby")
                    {
                        m_txtStandBySumIn.Text = (m_dblOriAutoStandBySum - m_dblStandBySumGUI + dblStanyBy).ToString();
                        m_strAutoStandBySum = (m_dblOriAutoStandBySum - m_dblStandBySumGUI + dblStanyBy).ToString();
                    }
                    else if (((com.digitalwave.controls.ctlRichTextBox)sender).Name == "m_txtInAmountFact")
                    {
                        m_txtFactSumIn.Text = (m_dblOriAutoFactSum - m_dblFactSumGUI + dblFact).ToString();
                        m_strAutoFactSum = (m_dblOriAutoFactSum - m_dblFactSumGUI + dblFact).ToString();
                    }
				}
			}
		}

		private void m_txtOut_TextChanged(object sender, System.EventArgs e)
		{
			double dblText = 0;
			double dblIn = 0;
            double dblOut = 0;
            double dblStanyBy = 0;
            double dblFact = 0;
            double dblPiss = 0;
            double dblCustom1 = 0;
            double dblCustom2 = 0; 
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
                    m_mthGetInOutFromGUI(ref dblIn, ref dblOut, ref dblStanyBy,
                        ref dblFact, ref dblPiss, ref dblCustom1, ref dblCustom2);
					m_txtSumOut.Text = (m_dblOriAutoSumOut - m_dblSumOutGUI + dblOut).ToString();
					m_strAutoSumOut = (m_dblOriAutoSumOut - m_dblSumOutGUI + dblOut).ToString();
                    if (((com.digitalwave.controls.ctlRichTextBox)sender).Name == "m_txtOutEmiction")
                    {
                        m_txtEmictionSumOut.Text = (m_dblOriAutoPissSum - m_dblPissSumGUI + dblPiss).ToString();
                        m_strAutoPissSum = (m_dblOriAutoPissSum - m_dblPissSumGUI + dblPiss).ToString();
                    }
                    else if (((com.digitalwave.controls.ctlRichTextBox)sender).Name == "m_txtCustom1")
                    {
                        m_txtCustom1SumOut.Text = (m_dblOriAutoCustom1Sum - m_dblCustom1SumGUI + dblCustom1).ToString();
                        m_strAutoCustom1Sum = (m_dblOriAutoCustom1Sum - m_dblCustom1SumGUI + dblCustom1).ToString();
                    }
                    else if (((com.digitalwave.controls.ctlRichTextBox)sender).Name == "m_txtCustom2")
                    {
                        m_txtCustom2SumOut.Text = (m_dblOriAutoCustom2Sum - m_dblCustom2SumGUI + dblCustom2).ToString();
                        m_strAutoCustom2Sum = (m_dblOriAutoCustom2Sum - m_dblCustom2SumGUI + dblCustom2).ToString();
                    }
				}
			}
		}
		#endregion

        #region 显示自定义列名
        private void m_mthSetCustomColumnName()
        {
            if (m_strCustomNameArr == null || m_strCustomNameArr.Length != 4)
                return;
            if (!string.IsNullOrEmpty(m_strCustomNameArr[0]))
            {
                m_lblCustom1Name.Text = m_strFormatColumnName(m_strCustomNameArr[0]) + ":";
                m_lblCustom1NameSum.Text = m_strFormatColumnName(m_strCustomNameArr[0]) + "总出量";
            }

            if (!string.IsNullOrEmpty(m_strCustomNameArr[1]))
            {
                m_lblCustom2Name.Text = m_strFormatColumnName(m_strCustomNameArr[1]) + ":";
                m_lblCustom2NameSum.Text = m_strFormatColumnName(m_strCustomNameArr[1]) + "总出量";
            }

            if (!string.IsNullOrEmpty(m_strCustomNameArr[2]))
            {
                m_lblCustom3Name.Text = m_strFormatColumnName(m_strCustomNameArr[2]) + ":";
            }

            if (!string.IsNullOrEmpty(m_strCustomNameArr[3]))
            {
                m_lblCustom4Name.Text = m_strFormatColumnName(m_strCustomNameArr[3]) + ":";
            }
        } 
        #endregion

        #region 将自定义列名格式化成适合DataGrid标头的形式
        private string m_strFormatColumnName(string p_strTempColumnName)
        {
            string strColumnName = "";

            if (!string.IsNullOrEmpty(p_strTempColumnName))
            {
                strColumnName = p_strTempColumnName.Replace("\r\n", "");
            }
            return strColumnName;
        } 
        #endregion
	}
}
