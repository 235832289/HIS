using System;
using System.Data ;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using com.digitalwave.Utility.Controls ;
using System.Windows.Forms;
using iCareData;
using CrystalDecisions.CrystalReports.Engine;
using com.digitalwave.emr.BEDExplorer;
using com.digitalwave.Emr.Signature_gui;

namespace iCare
{
    /// <summary>
    /// 核医学检查申请单
    /// </summary>
	public class frmPSGOrder : iCare.frmHRPBaseForm,PublicFunction
	{

#region Define
		private System.Windows.Forms.TreeView trvTime;
		protected System.Windows.Forms.Label lblOperationBeginTimeTitle;
		protected System.Windows.Forms.Label lblAddress;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox txtAddress;
		protected System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.CheckBox checkBox3;
		private System.Windows.Forms.CheckBox checkBox4;
		private System.Windows.Forms.CheckBox checkBox5;
		private System.Windows.Forms.CheckBox checkBox6;
		private System.Windows.Forms.CheckBox checkBox7;
		private System.Windows.Forms.CheckBox checkBox8;
		private System.Windows.Forms.CheckBox checkBox9;
		private System.Windows.Forms.CheckBox checkBox10;
		private System.Windows.Forms.CheckBox checkBox11;
		private System.Windows.Forms.CheckBox checkBox12;
		private System.Windows.Forms.CheckBox checkBox13;
		private System.Windows.Forms.CheckBox checkBox14;
		private System.Windows.Forms.CheckBox checkBox15;
		private System.Windows.Forms.CheckBox checkBox16;
		protected System.Windows.Forms.Label label2;
		protected System.Windows.Forms.Label label3;
		protected System.Windows.Forms.Label label4;
		private com.digitalwave.controls.ctlRichTextBox txtClinicalImpression;
		protected System.Windows.Forms.Label label5;
		protected System.Windows.Forms.Label label6;
        private PinkieControls.ButtonXP cmdRequesterSign;
		protected System.Windows.Forms.Label label7;
		protected System.Windows.Forms.Label lblPayType;
		private System.Windows.Forms.RadioButton rdbPublic;
		private System.Windows.Forms.RadioButton rdbCompany;
		private System.Windows.Forms.RadioButton rdbPrivate;
		private System.Windows.Forms.Panel pnlCheckItem;
		private System.Windows.Forms.Panel pnlPayType;
		private com.digitalwave.controls.ctlRichTextBox txtClinicalDiagnose;
		private com.digitalwave.controls.ctlRichTextBox txtAssay;
		private System.ComponentModel.IContainer components = null;

#endregion Define

		private clsInPatientCaseHisoryDefaultDomain m_objInPaitentCaseDefault=new clsInPatientCaseHisoryDefaultDomain();

        private iCare.clsPSGOrderDomain m_objDomain;
        //private com.digitalwave.Utility.Controls.clsBorderTool m_objBorderTool;

		private bool blnCanDelete=true;              //是否可以执行删除操作
		private clsCommonUseToolCollection m_objCUTC;
		private clsPSGOrder m_objPSG=null;
		private clsPSGOrder[] m_objPSGArr;
//		private com.digitalwave.controls.ctlRichTextBox txtResult;
//		private com.digitalwave.Utility.Controls.ctlBorderTextBox txtRequesterSign;
		private clsPatient m_objCurrentPatient=null;

		private clsEmployeeSignTool m_objSignTool;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox txtPSGNumber;
		protected System.Windows.Forms.Label lblPSGNumber;
		private com.digitalwave.Utility.Controls.ctlTimePicker dtpApplicationDate;

		private bool blnCanSearch=true; 

		private ReportDocument m_rpdOrderRept;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private Crownwood.Magic.Controls.TabControl tabControl2;
		private System.Windows.Forms.ImageList imageList1;
		private Crownwood.Magic.Controls.TabPage tabPage3;
		private Crownwood.Magic.Controls.TabPage tabPage4;
        private TextBox m_txtRequesterSign;
        private DataSet m_dtsRept;
        //定义签名类
        private clsEmrSignToolCollection m_objSign;
        private com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();

        /// <summary>
        /// 核医学检查申请单
        /// </summary>
		public frmPSGOrder()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

            //m_objSignTool = new clsEmployeeSignTool(m_lsvEmployee);
            //m_objSignTool.m_mthAddControl(this.m_txtRequesterSign);

            m_objDomain = new iCare.clsPSGOrderDomain(); 
            //m_objBorderTool = new clsBorderTool(Color.White);
            //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{this.trvTime
            //                                                             ,this.txtClinicalImpression 
            //                                                             ,this.txtAssay 
            //                                                             ,this.txtClinicalDiagnose 
            //                                                             });	
			// TODO: Add any initialization after the InitializeComponent call

			//			m_mthAddNewDataForEKGOrderDataSet(m_dtsRept);

			m_dtsRept = m_dtsInitdsPSGOrderDataSet();

			trvTime.HideSelection=false;

			//签名常用值
            //m_objCUTC = new clsCommonUseToolCollection(this);
            //m_objCUTC.m_mthBindEmployeeSign(new Control[]{this.cmdRequesterSign },
            //    new Control[] { this.m_txtRequesterSign }, new int[] { 1 });
            //签名常用值
            m_objSign = new clsEmrSignToolCollection();
            m_objSign.m_mthBindEmployeeSign(cmdRequesterSign, m_txtRequesterSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);

		}

		/// <summary>
		/// Clean up any resources being used.
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPSGOrder));
            this.trvTime = new System.Windows.Forms.TreeView();
            this.lblOperationBeginTimeTitle = new System.Windows.Forms.Label();
            this.dtpApplicationDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.lblPSGNumber = new System.Windows.Forms.Label();
            this.txtPSGNumber = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.checkBox12 = new System.Windows.Forms.CheckBox();
            this.checkBox13 = new System.Windows.Forms.CheckBox();
            this.checkBox14 = new System.Windows.Forms.CheckBox();
            this.checkBox15 = new System.Windows.Forms.CheckBox();
            this.checkBox16 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtClinicalImpression = new com.digitalwave.controls.ctlRichTextBox();
            this.txtClinicalDiagnose = new com.digitalwave.controls.ctlRichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAssay = new com.digitalwave.controls.ctlRichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmdRequesterSign = new PinkieControls.ButtonXP();
            this.label7 = new System.Windows.Forms.Label();
            this.lblPayType = new System.Windows.Forms.Label();
            this.pnlPayType = new System.Windows.Forms.Panel();
            this.rdbPrivate = new System.Windows.Forms.RadioButton();
            this.rdbCompany = new System.Windows.Forms.RadioButton();
            this.rdbPublic = new System.Windows.Forms.RadioButton();
            this.pnlCheckItem = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl2 = new Crownwood.Magic.Controls.TabControl();
            this.tabPage3 = new Crownwood.Magic.Controls.TabPage();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabPage4 = new Crownwood.Magic.Controls.TabPage();
            this.m_txtRequesterSign = new System.Windows.Forms.TextBox();
            this.m_pnlNewBase.SuspendLayout();
            this.pnlPayType.SuspendLayout();
            this.pnlCheckItem.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(676, 154);
            this.lblSex.Size = new System.Drawing.Size(36, 19);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(760, 154);
            this.lblAge.Size = new System.Drawing.Size(24, 19);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(348, 150);
            this.lblBedNoTitle.Size = new System.Drawing.Size(56, 14);
            this.lblBedNoTitle.Text = "床  号:";
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(348, 178);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(500, 154);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(636, 154);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(712, 154);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(160, 178);
            this.lblAreaTitle.Size = new System.Drawing.Size(56, 14);
            this.lblAreaTitle.Text = "病  区:";
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(404, 175);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(96, 104);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(404, 178);
            this.txtInPatientID.Size = new System.Drawing.Size(96, 23);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(540, 150);
            this.m_txtPatientName.Size = new System.Drawing.Size(90, 23);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(404, 150);
            this.m_txtBedNO.Size = new System.Drawing.Size(68, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(212, 174);
            this.m_cboArea.Size = new System.Drawing.Size(132, 23);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(540, 147);
            this.m_lsvPatientName.Size = new System.Drawing.Size(90, 104);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(404, 199);
            this.m_lsvBedNO.Size = new System.Drawing.Size(92, 104);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(212, 146);
            this.m_cboDept.Size = new System.Drawing.Size(132, 23);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(160, 150);
            this.lblDept.Size = new System.Drawing.Size(56, 14);
            this.lblDept.Text = "科  室:";
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(682, 150);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.m_cmdNext.Location = new System.Drawing.Point(472, 150);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(168, 150);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(636, 37);
            this.m_lblForTitle.Text = "核医学检查申请单";
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(580, 119);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(705, 40);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Size = new System.Drawing.Size(774, 106);
            this.m_pnlNewBase.Visible = true;
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ctlPatientInfo.Dock = System.Windows.Forms.DockStyle.None;
            this.m_ctlPatientInfo.Location = new System.Drawing.Point(182, 29);
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(590, 76);
            // 
            // trvTime
            // 
            this.trvTime.BackColor = System.Drawing.Color.White;
            this.trvTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.trvTime.ForeColor = System.Drawing.Color.Black;
            this.trvTime.ItemHeight = 18;
            this.trvTime.Location = new System.Drawing.Point(11, 37);
            this.trvTime.Name = "trvTime";
            this.trvTime.ShowRootLines = false;
            this.trvTime.Size = new System.Drawing.Size(181, 75);
            this.trvTime.TabIndex = 10;
            this.trvTime.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvTime_AfterSelect_1);
            // 
            // lblOperationBeginTimeTitle
            // 
            this.lblOperationBeginTimeTitle.AutoSize = true;
            this.lblOperationBeginTimeTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOperationBeginTimeTitle.Location = new System.Drawing.Point(355, 68);
            this.lblOperationBeginTimeTitle.Name = "lblOperationBeginTimeTitle";
            this.lblOperationBeginTimeTitle.Size = new System.Drawing.Size(70, 14);
            this.lblOperationBeginTimeTitle.TabIndex = 1000000004;
            this.lblOperationBeginTimeTitle.Text = "申请日期:";
            // 
            // dtpApplicationDate
            // 
            this.dtpApplicationDate.BorderColor = System.Drawing.Color.Black;
            this.dtpApplicationDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpApplicationDate.DropButtonBackColor = System.Drawing.Color.Gainsboro;
            this.dtpApplicationDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpApplicationDate.DropButtonForeColor = System.Drawing.Color.Black;
            this.dtpApplicationDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpApplicationDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpApplicationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpApplicationDate.Location = new System.Drawing.Point(423, 64);
            this.dtpApplicationDate.m_BlnOnlyTime = false;
            this.dtpApplicationDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpApplicationDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpApplicationDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpApplicationDate.Name = "dtpApplicationDate";
            this.dtpApplicationDate.ReadOnly = false;
            this.dtpApplicationDate.Size = new System.Drawing.Size(214, 22);
            this.dtpApplicationDate.TabIndex = 30;
            this.dtpApplicationDate.TextBackColor = System.Drawing.Color.White;
            this.dtpApplicationDate.TextForeColor = System.Drawing.Color.Black;
            // 
            // lblPSGNumber
            // 
            this.lblPSGNumber.AutoSize = true;
            this.lblPSGNumber.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPSGNumber.Location = new System.Drawing.Point(194, 67);
            this.lblPSGNumber.Name = "lblPSGNumber";
            this.lblPSGNumber.Size = new System.Drawing.Size(56, 14);
            this.lblPSGNumber.TabIndex = 1000000006;
            this.lblPSGNumber.Text = "检查号:";
            // 
            // txtPSGNumber
            // 
            this.txtPSGNumber.BackColor = System.Drawing.Color.White;
            this.txtPSGNumber.BorderColor = System.Drawing.Color.White;
            this.txtPSGNumber.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPSGNumber.ForeColor = System.Drawing.Color.Black;
            this.txtPSGNumber.Location = new System.Drawing.Point(252, 63);
            this.txtPSGNumber.Name = "txtPSGNumber";
            this.txtPSGNumber.Size = new System.Drawing.Size(99, 23);
            this.txtPSGNumber.TabIndex = 20;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAddress.Location = new System.Drawing.Point(194, 91);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(42, 14);
            this.lblAddress.TabIndex = 1000000010;
            this.lblAddress.Text = "地址:";
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.White;
            this.txtAddress.BorderColor = System.Drawing.Color.White;
            this.txtAddress.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAddress.ForeColor = System.Drawing.Color.Black;
            this.txtAddress.Location = new System.Drawing.Point(252, 87);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(524, 23);
            this.txtAddress.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(8, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 14);
            this.label1.TabIndex = 1000000011;
            this.label1.Text = "检查项目及申请理由(请√):";
            // 
            // checkBox1
            // 
            this.checkBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox1.Location = new System.Drawing.Point(8, 4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(560, 22);
            this.checkBox1.TabIndex = 80;
            this.checkBox1.Tag = "1";
            this.checkBox1.Text = "1、甲状腺∨照相、肿瘤、结节、大小、异位、颈部肿块、上纵膈肿块";
            // 
            // checkBox2
            // 
            this.checkBox2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox2.Location = new System.Drawing.Point(8, 76);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(498, 22);
            this.checkBox2.TabIndex = 110;
            this.checkBox2.Tag = "4";
            this.checkBox2.Text = "4、肾∨照相：肿瘤、肾血流、分肾功能、高血压、阻塞性肾病、移植肾";
            // 
            // checkBox3
            // 
            this.checkBox3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox3.Location = new System.Drawing.Point(8, 52);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(774, 22);
            this.checkBox3.TabIndex = 100;
            this.checkBox3.Tag = "3";
            this.checkBox3.Text = "3、肝脾∨照相：肿瘤、脓疡、囊肿、黄疸、外伤、肝大小、肝硬化、肝血流、隔下脓肿、上腹包块";
            // 
            // checkBox4
            // 
            this.checkBox4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox4.Location = new System.Drawing.Point(8, 28);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(560, 22);
            this.checkBox4.TabIndex = 90;
            this.checkBox4.Tag = "2";
            this.checkBox4.Text = "2、骨∨照：肿瘤、骨折、骨坏死、骨髓炎、关节炎、梗塞、骨痛";
            // 
            // checkBox5
            // 
            this.checkBox5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox5.Location = new System.Drawing.Point(8, 124);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(498, 22);
            this.checkBox5.TabIndex = 130;
            this.checkBox5.Tag = "6";
            this.checkBox5.Text = "6、肾有效血浆流量(ERPF)";
            // 
            // checkBox6
            // 
            this.checkBox6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox6.Location = new System.Drawing.Point(8, 148);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(498, 22);
            this.checkBox6.TabIndex = 140;
            this.checkBox6.Tag = "7";
            this.checkBox6.Text = "7、膀胱输尿管反流";
            // 
            // checkBox7
            // 
            this.checkBox7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox7.Location = new System.Drawing.Point(8, 172);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(498, 22);
            this.checkBox7.TabIndex = 150;
            this.checkBox7.Tag = "8";
            this.checkBox7.Text = "8、门电路心血池：搏出分数(EF)";
            // 
            // checkBox8
            // 
            this.checkBox8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox8.Location = new System.Drawing.Point(8, 100);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(498, 22);
            this.checkBox8.TabIndex = 120;
            this.checkBox8.Tag = "5";
            this.checkBox8.Text = "5、肾小球滤过率(GFR)";
            // 
            // checkBox9
            // 
            this.checkBox9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox9.Location = new System.Drawing.Point(8, 312);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(498, 22);
            this.checkBox9.TabIndex = 210;
            this.checkBox9.Tag = "14";
            this.checkBox9.Text = "14、眼科：泪道显像";
            // 
            // checkBox10
            // 
            this.checkBox10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox10.Location = new System.Drawing.Point(8, 336);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(352, 22);
            this.checkBox10.TabIndex = 220;
            this.checkBox10.Tag = "15";
            this.checkBox10.Text = "15、冶疗：骨转移癌冶疗、甲亢、甲状腺癌、";
            // 
            // checkBox11
            // 
            this.checkBox11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox11.Location = new System.Drawing.Point(8, 360);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(498, 22);
            this.checkBox11.TabIndex = 230;
            this.checkBox11.Tag = "16";
            this.checkBox11.Text = "16、其他：(请临床具体写出)";
            // 
            // checkBox12
            // 
            this.checkBox12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox12.Location = new System.Drawing.Point(8, 288);
            this.checkBox12.Name = "checkBox12";
            this.checkBox12.Size = new System.Drawing.Size(644, 22);
            this.checkBox12.TabIndex = 200;
            this.checkBox12.Tag = "13";
            this.checkBox12.Text = "13、脑∨照相/局部脑血流：肿瘤、脑梗塞、脑脓疡、癫痫、偏头痛、晕厥、抽搐";
            // 
            // checkBox13
            // 
            this.checkBox13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox13.Location = new System.Drawing.Point(8, 216);
            this.checkBox13.Name = "checkBox13";
            this.checkBox13.Size = new System.Drawing.Size(498, 22);
            this.checkBox13.TabIndex = 170;
            this.checkBox13.Tag = "10";
            this.checkBox13.Text = "10、肺∨照相：肿瘤、肺栓塞";
            // 
            // checkBox14
            // 
            this.checkBox14.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox14.Location = new System.Drawing.Point(8, 240);
            this.checkBox14.Name = "checkBox14";
            this.checkBox14.Size = new System.Drawing.Size(498, 22);
            this.checkBox14.TabIndex = 180;
            this.checkBox14.Tag = "11";
            this.checkBox14.Text = "11、胃肠道：门静脉循环、下消化道出血、";
            // 
            // checkBox15
            // 
            this.checkBox15.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox15.Location = new System.Drawing.Point(8, 264);
            this.checkBox15.Name = "checkBox15";
            this.checkBox15.Size = new System.Drawing.Size(498, 22);
            this.checkBox15.TabIndex = 190;
            this.checkBox15.Tag = "12";
            this.checkBox15.Text = "12、淋巴∨照相：乳腺肿瘤，肢体淋巴性水肿";
            // 
            // checkBox16
            // 
            this.checkBox16.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox16.Location = new System.Drawing.Point(8, 192);
            this.checkBox16.Name = "checkBox16";
            this.checkBox16.Size = new System.Drawing.Size(498, 22);
            this.checkBox16.TabIndex = 160;
            this.checkBox16.Tag = "9";
            this.checkBox16.Text = "9、心肌MIBI∨照相：冠心病、心肌梗塞";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(360, 340);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 1000000028;
            this.label2.Text = "90";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(384, 340);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 1000000029;
            this.label3.Text = "Sr皮肤病";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(12, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 14);
            this.label4.TabIndex = 1000000030;
            this.label4.Text = "病史:";
            // 
            // txtClinicalImpression
            // 
            this.txtClinicalImpression.AccessibleDescription = "病历";
            this.txtClinicalImpression.BackColor = System.Drawing.Color.White;
            this.txtClinicalImpression.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtClinicalImpression.ForeColor = System.Drawing.Color.Black;
            this.txtClinicalImpression.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtClinicalImpression.Location = new System.Drawing.Point(12, 32);
            this.txtClinicalImpression.m_BlnIgnoreUserInfo = true;
            this.txtClinicalImpression.m_BlnPartControl = false;
            this.txtClinicalImpression.m_BlnReadOnly = false;
            this.txtClinicalImpression.m_BlnUnderLineDST = false;
            this.txtClinicalImpression.m_ClrDST = System.Drawing.Color.Red;
            this.txtClinicalImpression.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtClinicalImpression.m_IntCanModifyTime = 6;
            this.txtClinicalImpression.m_IntPartControlLength = 0;
            this.txtClinicalImpression.m_IntPartControlStartIndex = 0;
            this.txtClinicalImpression.m_StrUserID = "";
            this.txtClinicalImpression.m_StrUserName = "";
            this.txtClinicalImpression.Name = "txtClinicalImpression";
            this.txtClinicalImpression.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtClinicalImpression.Size = new System.Drawing.Size(744, 120);
            this.txtClinicalImpression.TabIndex = 240;
            this.txtClinicalImpression.Text = "";
            // 
            // txtClinicalDiagnose
            // 
            this.txtClinicalDiagnose.AccessibleDescription = "病历";
            this.txtClinicalDiagnose.BackColor = System.Drawing.Color.White;
            this.txtClinicalDiagnose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtClinicalDiagnose.ForeColor = System.Drawing.Color.Black;
            this.txtClinicalDiagnose.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtClinicalDiagnose.Location = new System.Drawing.Point(12, 268);
            this.txtClinicalDiagnose.m_BlnIgnoreUserInfo = true;
            this.txtClinicalDiagnose.m_BlnPartControl = false;
            this.txtClinicalDiagnose.m_BlnReadOnly = false;
            this.txtClinicalDiagnose.m_BlnUnderLineDST = false;
            this.txtClinicalDiagnose.m_ClrDST = System.Drawing.Color.Red;
            this.txtClinicalDiagnose.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtClinicalDiagnose.m_IntCanModifyTime = 6;
            this.txtClinicalDiagnose.m_IntPartControlLength = 0;
            this.txtClinicalDiagnose.m_IntPartControlStartIndex = 0;
            this.txtClinicalDiagnose.m_StrUserID = "";
            this.txtClinicalDiagnose.m_StrUserName = "";
            this.txtClinicalDiagnose.Name = "txtClinicalDiagnose";
            this.txtClinicalDiagnose.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtClinicalDiagnose.Size = new System.Drawing.Size(744, 68);
            this.txtClinicalDiagnose.TabIndex = 260;
            this.txtClinicalDiagnose.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(8, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 14);
            this.label5.TabIndex = 1000000032;
            this.label5.Text = "临床诊断:";
            // 
            // txtAssay
            // 
            this.txtAssay.AccessibleDescription = "病历";
            this.txtAssay.BackColor = System.Drawing.Color.White;
            this.txtAssay.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAssay.ForeColor = System.Drawing.Color.Black;
            this.txtAssay.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtAssay.Location = new System.Drawing.Point(12, 176);
            this.txtAssay.m_BlnIgnoreUserInfo = true;
            this.txtAssay.m_BlnPartControl = false;
            this.txtAssay.m_BlnReadOnly = false;
            this.txtAssay.m_BlnUnderLineDST = false;
            this.txtAssay.m_ClrDST = System.Drawing.Color.Red;
            this.txtAssay.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtAssay.m_IntCanModifyTime = 6;
            this.txtAssay.m_IntPartControlLength = 0;
            this.txtAssay.m_IntPartControlStartIndex = 0;
            this.txtAssay.m_StrUserID = "";
            this.txtAssay.m_StrUserName = "";
            this.txtAssay.Name = "txtAssay";
            this.txtAssay.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtAssay.Size = new System.Drawing.Size(744, 66);
            this.txtAssay.TabIndex = 250;
            this.txtAssay.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(12, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 14);
            this.label6.TabIndex = 1000000034;
            this.label6.Text = "化验及其他检查:";
            // 
            // cmdRequesterSign
            // 
            this.cmdRequesterSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.cmdRequesterSign.DefaultScheme = true;
            this.cmdRequesterSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdRequesterSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdRequesterSign.Hint = "";
            this.cmdRequesterSign.Location = new System.Drawing.Point(552, 590);
            this.cmdRequesterSign.Name = "cmdRequesterSign";
            this.cmdRequesterSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdRequesterSign.Size = new System.Drawing.Size(84, 24);
            this.cmdRequesterSign.TabIndex = 270;
            this.cmdRequesterSign.Tag = "1";
            this.cmdRequesterSign.Text = "申请医生:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(16, 594);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(308, 14);
            this.label7.TabIndex = 1000000086;
            this.label7.Text = "附注:如做甲状腺功能检查请使用该项专用申请单";
            // 
            // lblPayType
            // 
            this.lblPayType.AutoSize = true;
            this.lblPayType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPayType.Location = new System.Drawing.Point(4, 116);
            this.lblPayType.Name = "lblPayType";
            this.lblPayType.Size = new System.Drawing.Size(70, 14);
            this.lblPayType.TabIndex = 1000000087;
            this.lblPayType.Text = "交费方式:";
            // 
            // pnlPayType
            // 
            this.pnlPayType.Controls.Add(this.rdbPrivate);
            this.pnlPayType.Controls.Add(this.rdbCompany);
            this.pnlPayType.Controls.Add(this.rdbPublic);
            this.pnlPayType.Location = new System.Drawing.Point(76, 114);
            this.pnlPayType.Name = "pnlPayType";
            this.pnlPayType.Size = new System.Drawing.Size(266, 23);
            this.pnlPayType.TabIndex = 45;
            // 
            // rdbPrivate
            // 
            this.rdbPrivate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbPrivate.Location = new System.Drawing.Point(176, 0);
            this.rdbPrivate.Name = "rdbPrivate";
            this.rdbPrivate.Size = new System.Drawing.Size(76, 22);
            this.rdbPrivate.TabIndex = 70;
            this.rdbPrivate.Text = "自费";
            // 
            // rdbCompany
            // 
            this.rdbCompany.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbCompany.Location = new System.Drawing.Point(88, 0);
            this.rdbCompany.Name = "rdbCompany";
            this.rdbCompany.Size = new System.Drawing.Size(82, 22);
            this.rdbCompany.TabIndex = 60;
            this.rdbCompany.Text = "单位记帐";
            // 
            // rdbPublic
            // 
            this.rdbPublic.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbPublic.Location = new System.Drawing.Point(4, 0);
            this.rdbPublic.Name = "rdbPublic";
            this.rdbPublic.Size = new System.Drawing.Size(76, 22);
            this.rdbPublic.TabIndex = 50;
            this.rdbPublic.Text = "市公费";
            // 
            // pnlCheckItem
            // 
            this.pnlCheckItem.Controls.Add(this.checkBox1);
            this.pnlCheckItem.Controls.Add(this.checkBox4);
            this.pnlCheckItem.Controls.Add(this.checkBox3);
            this.pnlCheckItem.Controls.Add(this.checkBox2);
            this.pnlCheckItem.Controls.Add(this.checkBox8);
            this.pnlCheckItem.Controls.Add(this.checkBox5);
            this.pnlCheckItem.Controls.Add(this.checkBox6);
            this.pnlCheckItem.Controls.Add(this.checkBox7);
            this.pnlCheckItem.Controls.Add(this.checkBox16);
            this.pnlCheckItem.Controls.Add(this.checkBox13);
            this.pnlCheckItem.Controls.Add(this.checkBox14);
            this.pnlCheckItem.Controls.Add(this.checkBox15);
            this.pnlCheckItem.Controls.Add(this.checkBox12);
            this.pnlCheckItem.Controls.Add(this.checkBox9);
            this.pnlCheckItem.Controls.Add(this.checkBox10);
            this.pnlCheckItem.Controls.Add(this.checkBox11);
            this.pnlCheckItem.Controls.Add(this.label2);
            this.pnlCheckItem.Controls.Add(this.label3);
            this.pnlCheckItem.Location = new System.Drawing.Point(8, 23);
            this.pnlCheckItem.Name = "pnlCheckItem";
            this.pnlCheckItem.Size = new System.Drawing.Size(800, 392);
            this.pnlCheckItem.TabIndex = 79;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(352, 154);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(104, 20);
            this.tabControl1.TabIndex = 1000000088;
            this.tabControl1.Visible = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(96, 0);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "检查项目";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(96, -7);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "病历";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pnlCheckItem);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(764, 420);
            this.panel1.TabIndex = 1000000012;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtClinicalImpression);
            this.panel2.Controls.Add(this.txtAssay);
            this.panel2.Controls.Add(this.txtClinicalDiagnose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(764, 420);
            this.panel2.TabIndex = 1000000035;
            // 
            // tabControl2
            // 
            this.tabControl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabControl2.IDEPixelArea = true;
            this.tabControl2.Location = new System.Drawing.Point(4, 140);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.PositionTop = true;
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.SelectedTab = this.tabPage3;
            this.tabControl2.Size = new System.Drawing.Size(764, 445);
            this.tabControl2.TabIndex = 1000000089;
            this.tabControl2.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage3,
            this.tabPage4});
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel1);
            this.tabPage3.ImageIndex = 0;
            this.tabPage3.ImageList = this.imageList1;
            this.tabPage3.Location = new System.Drawing.Point(0, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(764, 420);
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
            this.tabPage4.Location = new System.Drawing.Point(0, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Selected = false;
            this.tabPage4.Size = new System.Drawing.Size(764, 420);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Title = "病史";
            // 
            // m_txtRequesterSign
            // 
            this.m_txtRequesterSign.Location = new System.Drawing.Point(639, 590);
            this.m_txtRequesterSign.Name = "m_txtRequesterSign";
            this.m_txtRequesterSign.ReadOnly = true;
            this.m_txtRequesterSign.Size = new System.Drawing.Size(100, 23);
            this.m_txtRequesterSign.TabIndex = 1000000090;
            // 
            // frmPSGOrder
            // 
            this.ClientSize = new System.Drawing.Size(820, 625);
            this.Controls.Add(this.m_txtRequesterSign);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblPayType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtPSGNumber);
            this.Controls.Add(this.pnlPayType);
            this.Controls.Add(this.cmdRequesterSign);
            this.Controls.Add(this.dtpApplicationDate);
            this.Controls.Add(this.trvTime);
            this.Controls.Add(this.lblPSGNumber);
            this.Controls.Add(this.lblOperationBeginTimeTitle);
            this.Name = "frmPSGOrder";
            this.Text = "核医学检查申请单";
            this.Load += new System.EventHandler(this.frmPSGOrder_Load);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.lblOperationBeginTimeTitle, 0);
            this.Controls.SetChildIndex(this.lblPSGNumber, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.trvTime, 0);
            this.Controls.SetChildIndex(this.dtpApplicationDate, 0);
            this.Controls.SetChildIndex(this.cmdRequesterSign, 0);
            this.Controls.SetChildIndex(this.pnlPayType, 0);
            this.Controls.SetChildIndex(this.txtPSGNumber, 0);
            this.Controls.SetChildIndex(this.txtAddress, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.lblAddress, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.lblPayType, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.tabControl2, 0);
            this.Controls.SetChildIndex(this.m_txtRequesterSign, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            this.pnlPayType.ResumeLayout(false);
            this.pnlCheckItem.ResumeLayout(false);
            this.pnlCheckItem.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmPSGOrder_Load(object sender, System.EventArgs e)
		{
            //m_lsvEmployee.Visible=false;
			m_mthSetQuickKeys();

			this.m_lsvInPatientID.Visible=false;
			TreeNode trnNode=new TreeNode("申请日期");
			trnNode.Tag ="0";
			this.trvTime.Nodes.Add(trnNode);

			this.trvTime.SelectedNode=this.trvTime.Nodes[0];

			this.dtpApplicationDate.m_EnmVisibleFlag=MDIParent.s_ObjRecordDateTimeInfo.m_enmGetRecordTimeFlag(this.Name);
			this.dtpApplicationDate.m_mthResetSize();

			this.txtPSGNumber.ReadOnly=false;
			this.txtAddress.ReadOnly=true;
		}

		private void m_mthSetQuickKeys()
		{			
			m_mthSetControlEvent(this);			
		}


		private void m_mthSetControlEvent(Control p_ctlControl)
		{
			//利用递归调用，读取并设置所有界面事件	
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
		
		}


		private void m_mthEvent_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch(e.KeyValue)
			{//F1 112  帮助, F2 113 Save，F3  114 Del，F4 115 Print，F5 116 Refresh，F6 117 Search
				case 13:// enter				
					
					//					if(((Control)sender).Name=="m_lsvEmployee")
					//					{
					//						
					//						m_lsvEmployee_DoubleClick(null,null);
					//					}

			
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
					m_mthClearPatientBaseInfo();
					m_mthClearUpSheet();
					m_mthReadOnly(false);
					m_objPSG=null;
					m_objCurrentPatient=null;
					this.trvTime.Nodes[0].Nodes .Clear ();
					break;
				case 117://Search					
					break;
			}	
		}

		
		#region PublicFunction 重载基类窗体
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
			m_objPSG=null;			

			txtAddress.Text=p_objSelectedPatient.m_ObjPeopleInfo.m_StrHomeAddress;
            //txtInPatientID.Tag = p_objSelectedPatient.m_DtmSelectedInDate.ToString();
            //txtInPatientID.Text=p_objSelectedPatient.m_StrInPatientID;

            //m_objCurrentPatient=p_objSelectedPatient ;
            //m_mthLoadAllTimeOfAPatient(txtInPatientID.Text.Trim(),txtInPatientID.Tag.ToString());
			
		}

		protected override bool m_BlnIsAddNew
		{
			get
			{
				
				if(dtpApplicationDate.Enabled==true)////Add New
					return true;
				else 
					return false;
		
			}
		}
		protected override long m_lngSubModify()
		{
			if(m_objPSG==null) return -1;
			//			if(!m_bolShowIfModify()) return -1;
			if(clsEMRLogin.LoginEmployee.m_strEMPID_CHR!=m_objPSG.strCreateUserID.Trim())
			{	//非申请医生无法更改记录
				clsPublicFunction.ShowInformationMessageBox("无法修改他人的申请单!");
				return -1;
			}

			m_objPSG=objPSGOrderContent(false);
            if (m_objPSG == null)
            {
                return -1;
            }
			long lngSave=m_objDomain.lngSave(false,m_objPSG);

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
			try
			{
				m_objPSG=new clsPSGOrder();

				m_objPSG=objPSGOrderContent(true);

                if (m_objPSG == null)
                {
                    return -1;
                }
				long lngSave=m_objDomain.lngSave(true,m_objPSG);

				if(lngSave>0)
				{

                    clsPublicFunction.ShowInformationMessageBox("保存成功！");
					m_mthAddNodeToTrv(this.dtpApplicationDate.Value);

					//				
					//				bool blnSendRes = PACS.clsPACSTool.s_blnSendBookingMSG(PACS.clsPACSTool.s_strGetStationName(1),strBookingInfo);	
					//			
					//				if(!blnSendRes)
					//					clsPublicFunction.ShowInformationMessageBox("不能发送预约信息。");

					return 1;
				}
				else 
				{
					clsPublicFunction.ShowInformationMessageBox("保存失败！");
					return -5;
				}
			}
			catch//(System.Exception ex)
			{
				clsPublicFunction.ShowInformationMessageBox("保存失败!");
				return 0;
			}
			
		}
		
		protected override long m_lngSubPrint()
		{
			if(m_rpdOrderRept == null)
			{
				m_rpdOrderRept = new ReportDocument();
				m_rpdOrderRept.Load(m_strTemplatePath+"rptNucleusMedicine.rpt");
			}

			m_mthAddNewDataFordsPSGOrderDataSet(m_dtsRept);
						

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
			if(m_objPSG==null || m_objCurrentPatient==null)
				return 0;

            //权限判断
            string strDeptIDTemp = ((clsDepartment)m_cboDept.SelectedItem).m_strDeptNewID;
            bool blnIsAllow = clsPublicFunction.IsAllowDelete(strDeptIDTemp, m_objPSG.strCreateUserID.Trim(), clsEMRLogin.LoginEmployee, 1);
            if (!blnIsAllow)
                return -1;

			//设置删除日期和删除者ID
			m_objPSG.m_dtmDeActivedDate=DateTime.Now;
			m_objPSG.m_strDeActivedOperatorID=MDIParent.OperatorID;

			long lngRes=m_objDomain.lngDelete(m_objPSG);

			if(lngRes>0)
			{
				foreach(TreeNode trnNode in trvTime.Nodes[0].Nodes)
				{
					if(DateTime.Parse(trnNode.Tag.ToString())==DateTime.Parse(m_objPSG.m_strApplicationDate))
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
		public void Delete()
		{
			m_lngDelete();
		}
		public void Display(string cardno,string sendcheckdate){}

		public void Display(string strInPatientID,string strInPatientDate,string strCreateDate)
		{
			long m_lngRe=m_objDomain.GetPSGOrder(strInPatientID,strInPatientDate,strCreateDate,out m_objPSG);
			if(m_lngRe<0) 
				return ;

			//申请者只应该填写属于申请的那部分内容。对申请作出回复的人也只应该填写报告的那部分内容
			if(m_objPSG.strCreateUserID.Trim()!=clsEMRLogin.LoginEmployee.m_strEMPID_CHR)
			{
				m_mthReadOnly(true);
			}
			else
			{
				m_mthReadOnly(false);
			}


            //m_objSignTool.m_mtSetSpecialEmployee(m_objPSG.m_strRequesterSign);

			//this.lblApplyDotorID.Tag=m_objPSG.strApplyDotorID;

			this.txtPSGNumber.Text=m_objPSG.m_strPSGNumber ;
            if (m_objCurrentPatient != null)
            {
                this.txtAddress.Text = m_objCurrentPatient.m_ObjPeopleInfo.m_StrHomeAddress;
            }
            else
            {
                this.txtAddress.Text = string.Empty;
            }

			this.dtpApplicationDate.Value=DateTime.Parse(m_objPSG.m_strApplicationDate);
			
			switch (m_objPSG.m_enmPayType)
			{
				case enmPayType.enmCompany:
					this.rdbCompany.Checked=true;
					break;

				case enmPayType.enmPrivate:
					this.rdbPrivate.Checked=true;
					break;
				case enmPayType.enmPublic:
					this.rdbPublic.Checked=true;
					break;
			}

			m_lngRe=m_lngSetControlValFromCheckPartSelectionStr(m_objPSG.m_strCheckItem,this.pnlCheckItem);
			this.txtClinicalDiagnose.Text=m_objPSG.m_strClinicalDiagnose;
			this.txtAssay.Text =m_objPSG.m_strAssay;
			this.txtClinicalImpression.Text =m_objPSG.m_strClinicalImpression;

            clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
            objEmployeeSign.m_lngGetEmpByID(m_objPSG.m_strRequesterSign, out objEmpVO);
            if (objEmpVO != null)
            {
                this.m_txtRequesterSign.Text = objEmpVO.m_strLASTNAME_VCHR;
                this.m_txtRequesterSign.Tag = objEmpVO;
            }
		}

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
		
		#endregion PublicFunction

	
		private clsPSGOrder objPSGOrderContent(bool blnIsAddNew)
		{
            if (m_objCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
            {
                return null;
            }

            if (m_txtRequesterSign.Tag == null)
            {
                clsPublicFunction.ShowInformationMessageBox("请申请医师签名");
                return null;
            }

			if(blnIsAddNew==true)
			{	
				m_objPSG.strCreateUserID =clsEMRLogin.LoginEmployee.m_strEMPID_CHR;
                m_objPSG.strInPatientDate = m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate.ToString("yyyy-MM-dd HH:mm:ss");
                m_objPSG.strInPatientID = m_ObjCurrentEmrPatientSession.m_strEMRInpatientId;
                m_objPSG.strCreateDate = this.dtpApplicationDate.Value.ToString("yyyy-MM-dd HH:mm:ss"); 		

			}

            m_objPSG.m_strRequesterSign = ((clsEmrEmployeeBase_VO)m_txtRequesterSign.Tag).m_strEMPID_CHR;
			m_objPSG.m_strPSGNumber=txtPSGNumber.Text;
			m_objPSG.m_strAddress=txtAddress.Text;
			m_objPSG.m_strApplicationDate=dtpApplicationDate.Value.ToString();
			
			if(rdbPublic.Checked==true)
			{
				m_objPSG.m_enmPayType=enmPayType.enmPublic ;
			}
			if(rdbCompany.Checked==true)
			{
				m_objPSG.m_enmPayType=enmPayType.enmCompany;
			}

			if(rdbPrivate.Checked==true)
			{
				m_objPSG.m_enmPayType=enmPayType.enmPrivate;
			}
			if(rdbCompany.Checked==false && rdbPrivate.Checked==false && rdbPublic.Checked==false)
				m_objPSG.m_enmPayType=enmPayType.enmUnknow;

			
			string[] strCheckItem;
			long m_lngRe=this.m_lngGetCheckPartSelectionStrFromControl(16,out strCheckItem,this.pnlCheckItem);
			m_objPSG.m_strCheckItem=string.Join("",strCheckItem);

			m_objPSG.m_strClinicalImpression=this.txtClinicalImpression.Text;
			m_objPSG.m_strAssay=this.txtAssay.Text;
			m_objPSG.m_strClinicalDiagnose=this.txtClinicalDiagnose.Text;

			return m_objPSG;
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
			
		private void m_mthClearUpSheet()
		{
			
			foreach(Control ctlTemp in this.Controls)
			{
				if(ctlTemp.GetType().Name=="Panel")
				{
					foreach(Control ctlSub in ctlTemp.Controls)
					{
						if(ctlSub.GetType().Name=="CheckBox")
						{
							((CheckBox)ctlSub).Checked=false;
						}
						if(ctlSub.GetType().Name=="RadioButton")
						{
							((RadioButton)ctlSub).Checked=false;
						}
					}
				}
				if((ctlTemp.GetType().Name =="ctlBorderTextBox" || ctlTemp.GetType().Name=="RichTextBox" )&& ctlTemp.Name!="txtInPatientID" && ctlTemp.Name!="m_txtPatientName" && ctlTemp.Name!="m_txtBedNO")
					ctlTemp.Text="";
				else if(ctlTemp.GetType().Name=="ctlRichTextBox")
                    ((com.digitalwave.controls.ctlRichTextBox)ctlTemp).m_mthClearText();				
			}
			m_mthClear_Recursive(this.tabControl2,null);
			this.dtpApplicationDate.Value=DateTime.Now;
            dtpApplicationDate.Enabled = true;

            MDIParent.m_mthSetDefaulEmployee(m_txtRequesterSign);
		}


		private void m_mthReadOnly(bool blnIsReadOnly)
		{
			if(blnIsReadOnly)
			{
				foreach(Control ctlText in this.Controls )
				{
					string typeName = ctlText.GetType().Name;
				
					if(typeName =="ctlBorderTextBox" && ctlText.Name!="txtInPatientID" && 
					   ctlText.Name!="m_txtBedNO" && ctlText.Name!="m_txtPatientName" && 
					   ctlText.Name != "m_txtApplicationID" && ctlText.Name!="txtAddress")
						ctlText.Enabled=false;
					if(typeName == "ctlTimePicker" && ((ctlTimePicker)ctlText).Name!="dtpApplicationDate") 
						((ctlTimePicker)ctlText).Enabled=false;
                    if (typeName == "ctlRichTextBox") ((com.digitalwave.controls.ctlRichTextBox)ctlText).m_BlnReadOnly = true;
					
					
				}
				blnCanDelete=false;
			}
			else
			{
				foreach(Control ctlText in this.Controls )
				{
					string typeName = ctlText.GetType().Name;
					
					if(typeName =="ctlBorderTextBox" && ctlText.Name!="txtInPatientID")
						ctlText.Enabled=true;
					if(typeName == "ctlTimePicker" && ((ctlTimePicker)ctlText).Name!="dtpApplicationDate") 
						((ctlTimePicker)ctlText).Enabled=true;
                    if (typeName == "ctlRichTextBox") ((com.digitalwave.controls.ctlRichTextBox)ctlText).m_BlnReadOnly = false;
										
				}
				blnCanDelete=true;

			}
		}

		private void m_mthLoadAllTimeOfAPatient(string p_strInPatientID,string p_strInPatientDate)
		{
			
			try
			{
				if(p_strInPatientID ==null || p_strInPatientDate =="") return ;
				string[] m_strAll;

				m_strAll=m_objDomain.lngGetPSGOrderArrByPatientID(p_strInPatientID ,p_strInPatientDate);
				if(m_strAll.Length >0)
				{

					this.trvTime.Nodes[0].Nodes.Clear();
					foreach(string m_strTemp in m_strAll)
					{
						string strDate=DateTime.Parse(m_strTemp).ToString("yyyy年MM月dd日 HH:mm:ss");
						TreeNode trnDate=new TreeNode(strDate);
						trnDate.Tag =m_strTemp;
						this.trvTime.Nodes[0].Nodes.Add(trnDate );
					}
				}
				else
				{
					m_mthSetDefaultValue(m_objCurrentPatient);
					return;
				}
			
				this.trvTime.ExpandAll();
				this.trvTime.SelectedNode = this.trvTime.Nodes[0].Nodes[0];
			}
			catch//(System.Exception ex)
			{
//				MessageBox.Show(ex.Message);
			}
		}


		private void m_mthSetDefaultValue(clsPatient p_objPatient)
		{
			new clsDefaultValueTool(this).m_mthSetDefaultValue();

			//自动模板
			m_mthSetSpecialPatientTemplateSet(p_objPatient);

			//数据复用
			iCareData.clsInPatientCaseHisoryDefaultValue [] objInPatientCaseDefaultValue = new clsInPatientCaseHisoryDefaultDomain().lngGetAllInPatientCaseHisoryDefault(p_objPatient.m_StrInPatientID,p_objPatient.m_DtmSelectedInDate.ToString());
			if(objInPatientCaseDefaultValue !=null && objInPatientCaseDefaultValue.Length >0)
			{
				//				this.m_txtParticular.Text = "患者因" + objInPatientCaseDefaultValue[0].m_strMainDescription + "于" + DateTime.Parse(objInPatientCaseDefaultValue[0].m_strInPatientDate).ToString("yyyy年M月d日")  + "入院。";
				//				this.m_txtClinic.Text = objInPatientCaseDefaultValue[0].m_strPrimaryDiagnose;
			}		
		}


		//将从数据库读取过来的由0，1组成的字符串赋给相应的CheckBox控件
		private long m_lngSetControlValFromCheckPartSelectionStr(string p_strCheckPartSelection,Panel pnlControl)
		{	
			try
			{	
				if (p_strCheckPartSelection!=null)
				{
					if (p_strCheckPartSelection.Length==0) 
						return 0;

					char[] m_CheckPartSelection=new char[p_strCheckPartSelection.Length ];

					m_CheckPartSelection=p_strCheckPartSelection.ToCharArray();

					//					Control objCheckBox;
					
					foreach(Control objCheckBox in pnlControl.Controls )
					{
						if (objCheckBox.GetType()==typeof(CheckBox))
						{
							bool mValue=false;
							if(m_CheckPartSelection[int.Parse((string)(objCheckBox.Tag))-1]=='1')
							{
								mValue=true;
								((CheckBox)objCheckBox).Checked=mValue;
							}
							
						}
						
					}

					return 1;
				}
				else
					return 0;
			}
			catch(System.Exception ex)
			{
				MessageBox.Show(ex.Message);
				return 0;
			}


		}


		//将界面中的各个CHECKBOX框的值转化为用0,1表示的字符串

		private long m_lngGetCheckPartSelectionStrFromControl(int p_lngLength,out string[] p_strCheckPartSelection,Panel m_ctlPnl)
		{
			try
			{

				string[] m_strCheckPartSelection=new string[p_lngLength];
				for(int i=0;i<p_lngLength;i++)
					m_strCheckPartSelection[i]="0";
				
				//				Control objCheckBox;
				foreach(Control objCheckBox in m_ctlPnl.Controls)
				{
					if(objCheckBox.GetType()==typeof(CheckBox))
					{
						string mValue="0";
						if(((CheckBox)(objCheckBox)).Checked)
						{
							mValue="1";			    
							m_strCheckPartSelection[int.Parse((string)(objCheckBox.Tag))-1]=mValue;
						}
						
												
					}
				}
				p_strCheckPartSelection=m_strCheckPartSelection;
				return 1;
			}
			catch(System.Exception ex)
			{
				MessageBox.Show(ex.Message);
				p_strCheckPartSelection=new string[10];
				return 0;
			}
			
		}

		private void trvTime_AfterSelect_1(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			m_mthRecordChangedToSave();

			m_mthClearUpSheet();
			m_objPSG  =null;
			if(this.trvTime.SelectedNode.Tag ==null) return ;
			this.dtpApplicationDate.Enabled =true;
            if (this.trvTime.SelectedNode.Tag.ToString() != "0" && m_ObjCurrentEmrPatientSession != null)
			{
                Display(m_ObjCurrentEmrPatientSession.m_strEMRInpatientId, m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"), trvTime.SelectedNode.Tag.ToString());
				this.dtpApplicationDate.Text =this.trvTime.SelectedNode.Tag.ToString();
				this.dtpApplicationDate.Enabled =false;
				
				//当前处于修改记录状态
				MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.Modify );
			}
			else
			{
				m_mthReadOnly(false);
				this.dtpApplicationDate.Value=DateTime.Now;
				//				this.lblApplyDotorID.Text=MDIParent.OperatorName;
				//				this.lblApplyDotorID.Tag=MDIParent.OperatorID;
				this.dtpApplicationDate.Enabled =true;

				if(m_objCurrentPatient != null && txtInPatientID.Tag != null)
				{
					m_mthSetDefaultValue(m_objCurrentPatient);
				}
				//当前处于新增记录状态
				MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.AddNew);
				
			}

			m_mthAddFormStatusForClosingSave();
		}

		
		#region 打印
		/*
		* DataSet : dsPSGOrder
		* DataTable : dtPSGOrder
		* 	DataColumn : BedNo(string)
		* 	DataColumn : PatientName(string)
		* 	DataColumn : PatientSex(string)
		* 	DataColumn : PatientAge(string)
		* 	DataColumn : InPatientID(string)
		* 	DataColumn : PSGNumber(string)
		* 	DataColumn : ApplicationDate(string)
		* 	DataColumn : Address(string)
		* 	DataColumn : PayType(string)
		* 	DataColumn : ClinicalImpression(string)
		* 	DataColumn : Assay(string)
		* 	DataColumn : ClinicalDiagnose(string)
		* 	DataColumn : RequesterSign(string)
		* 	DataColumn : CheckItem1(string)
		* 	DataColumn : CheckItem2(string)
		* 	DataColumn : CheckItem3(string)
		* 	DataColumn : CheckItem4(string)
		* 	DataColumn : CheckItem5(string)
		* 	DataColumn : CheckItem6(string)
		* 	DataColumn : CheckItem7(string)
		* 	DataColumn : CheckItem8(string)
		* 	DataColumn : CheckItem9(string)
		* 	DataColumn : CheckItem10(string)
		* 	DataColumn : CheckItem11(string)
		* 	DataColumn : CheckItem12(string)
		* 	DataColumn : CheckItem13(string)
		* 	DataColumn : CheckItem14(string)
		* 	DataColumn : CheckItem15(string)
		* 	DataColumn : CheckItem16(string)
		* 	DataColumn : Other1(string)
		* 	DataColumn : Other2(string)
		* 	DataColumn : Other3(string)
		* 	DataColumn : Other4(string)
		* 	DataColumn : Other5(string)
		* 	DataColumn : Other6(string)
		* 	DataColumn : Other7(string)
		* 	DataColumn : Other8(string)
		* 	DataColumn : Other9(string)
		* 	DataColumn : Other10(string)
		*/ 
		private DataSet m_dtsInitdsPSGOrderDataSet()
		{
			DataSet dsdsPSGOrder = new DataSet("dsPSGOrder");

			DataTable dtdtPSGOrder = new DataTable("dtPSGOrder");

			DataColumn dcdtPSGOrderBedNo = new DataColumn("BedNo",typeof(string));

			dtdtPSGOrder.Columns.Add(dcdtPSGOrderBedNo);

			DataColumn dcdtPSGOrderPatientName = new DataColumn("PatientName",typeof(string));

			dtdtPSGOrder.Columns.Add(dcdtPSGOrderPatientName);

			DataColumn dcdtPSGOrderPatientSex = new DataColumn("PatientSex",typeof(string));

			dtdtPSGOrder.Columns.Add(dcdtPSGOrderPatientSex);

			DataColumn dcdtPSGOrderPatientAge = new DataColumn("PatientAge",typeof(string));

			dtdtPSGOrder.Columns.Add(dcdtPSGOrderPatientAge);

			DataColumn dcdtPSGOrderInPatientID = new DataColumn("InPatientID",typeof(string));

			dtdtPSGOrder.Columns.Add(dcdtPSGOrderInPatientID);

			DataColumn dcdtPSGOrderPSGNumber = new DataColumn("PSGNumber",typeof(string));

			dtdtPSGOrder.Columns.Add(dcdtPSGOrderPSGNumber);

			DataColumn dcdtPSGOrderApplicationDate = new DataColumn("ApplicationDate",typeof(string));

			dtdtPSGOrder.Columns.Add(dcdtPSGOrderApplicationDate);

			DataColumn dcdtPSGOrderAddress = new DataColumn("Address",typeof(string));

			dtdtPSGOrder.Columns.Add(dcdtPSGOrderAddress);

			DataColumn dcdtPSGOrderPayType = new DataColumn("PayType",typeof(string));

			dtdtPSGOrder.Columns.Add(dcdtPSGOrderPayType);

			DataColumn dcdtPSGOrderClinicalImpression = new DataColumn("ClinicalImpression",typeof(string));

			dtdtPSGOrder.Columns.Add(dcdtPSGOrderClinicalImpression);

			DataColumn dcdtPSGOrderAssay = new DataColumn("Assay",typeof(string));

			dtdtPSGOrder.Columns.Add(dcdtPSGOrderAssay);

			DataColumn dcdtPSGOrderClinicalDiagnose = new DataColumn("ClinicalDiagnose",typeof(string));

			dtdtPSGOrder.Columns.Add(dcdtPSGOrderClinicalDiagnose);

			DataColumn dcdtPSGOrderRequesterSign = new DataColumn("RequesterSign",typeof(string));

			dtdtPSGOrder.Columns.Add(dcdtPSGOrderRequesterSign);

			DataColumn dcdtPSGOrderCheckItem1 = new DataColumn("CheckItem1",typeof(string));

			dtdtPSGOrder.Columns.Add(dcdtPSGOrderCheckItem1);

			DataColumn dcdtPSGOrderCheckItem2 = new DataColumn("CheckItem2",typeof(string));

			dtdtPSGOrder.Columns.Add(dcdtPSGOrderCheckItem2);

			DataColumn dcdtPSGOrderCheckItem3 = new DataColumn("CheckItem3",typeof(string));

			dtdtPSGOrder.Columns.Add(dcdtPSGOrderCheckItem3);

			DataColumn dcdtPSGOrderCheckItem4 = new DataColumn("CheckItem4",typeof(string));

			dtdtPSGOrder.Columns.Add(dcdtPSGOrderCheckItem4);

			DataColumn dcdtPSGOrderCheckItem5 = new DataColumn("CheckItem5",typeof(string));

			dtdtPSGOrder.Columns.Add(dcdtPSGOrderCheckItem5);

			DataColumn dcdtPSGOrderCheckItem6 = new DataColumn("CheckItem6",typeof(string));

			dtdtPSGOrder.Columns.Add(dcdtPSGOrderCheckItem6);

			DataColumn dcdtPSGOrderCheckItem7 = new DataColumn("CheckItem7",typeof(string));

			dtdtPSGOrder.Columns.Add(dcdtPSGOrderCheckItem7);

			DataColumn dcdtPSGOrderCheckItem8 = new DataColumn("CheckItem8",typeof(string));

			dtdtPSGOrder.Columns.Add(dcdtPSGOrderCheckItem8);

			DataColumn dcdtPSGOrderCheckItem9 = new DataColumn("CheckItem9",typeof(string));

			dtdtPSGOrder.Columns.Add(dcdtPSGOrderCheckItem9);

			DataColumn dcdtPSGOrderCheckItem10 = new DataColumn("CheckItem10",typeof(string));

			dtdtPSGOrder.Columns.Add(dcdtPSGOrderCheckItem10);

			DataColumn dcdtPSGOrderCheckItem11 = new DataColumn("CheckItem11",typeof(string));

			dtdtPSGOrder.Columns.Add(dcdtPSGOrderCheckItem11);

			DataColumn dcdtPSGOrderCheckItem12 = new DataColumn("CheckItem12",typeof(string));

			dtdtPSGOrder.Columns.Add(dcdtPSGOrderCheckItem12);

			DataColumn dcdtPSGOrderCheckItem13 = new DataColumn("CheckItem13",typeof(string));

			dtdtPSGOrder.Columns.Add(dcdtPSGOrderCheckItem13);

			DataColumn dcdtPSGOrderCheckItem14 = new DataColumn("CheckItem14",typeof(string));

			dtdtPSGOrder.Columns.Add(dcdtPSGOrderCheckItem14);

			DataColumn dcdtPSGOrderCheckItem15 = new DataColumn("CheckItem15",typeof(string));

			dtdtPSGOrder.Columns.Add(dcdtPSGOrderCheckItem15);

			DataColumn dcdtPSGOrderCheckItem16 = new DataColumn("CheckItem16",typeof(string));

			dtdtPSGOrder.Columns.Add(dcdtPSGOrderCheckItem16);

			DataColumn dcdtPSGOrderOther1 = new DataColumn("Other1",typeof(string));

			dtdtPSGOrder.Columns.Add(dcdtPSGOrderOther1);

			DataColumn dcdtPSGOrderOther2 = new DataColumn("Other2",typeof(string));

			dtdtPSGOrder.Columns.Add(dcdtPSGOrderOther2);

			DataColumn dcdtPSGOrderOther3 = new DataColumn("Other3",typeof(string));

			dtdtPSGOrder.Columns.Add(dcdtPSGOrderOther3);

			DataColumn dcdtPSGOrderOther4 = new DataColumn("Other4",typeof(string));

			dtdtPSGOrder.Columns.Add(dcdtPSGOrderOther4);

			DataColumn dcdtPSGOrderOther5 = new DataColumn("Other5",typeof(string));

			dtdtPSGOrder.Columns.Add(dcdtPSGOrderOther5);

			DataColumn dcdtPSGOrderOther6 = new DataColumn("Other6",typeof(string));

			dtdtPSGOrder.Columns.Add(dcdtPSGOrderOther6);

			DataColumn dcdtPSGOrderOther7 = new DataColumn("Other7",typeof(string));

			dtdtPSGOrder.Columns.Add(dcdtPSGOrderOther7);

			DataColumn dcdtPSGOrderOther8 = new DataColumn("Other8",typeof(string));

			dtdtPSGOrder.Columns.Add(dcdtPSGOrderOther8);

			DataColumn dcdtPSGOrderOther9 = new DataColumn("Other9",typeof(string));

			dtdtPSGOrder.Columns.Add(dcdtPSGOrderOther9);

			DataColumn dcdtPSGOrderOther10 = new DataColumn("Other10",typeof(string));

			dtdtPSGOrder.Columns.Add(dcdtPSGOrderOther10);

			dsdsPSGOrder.Tables.Add(dtdtPSGOrder);

			return dsdsPSGOrder;
		}

		/*
		* DataSet : dsPSGOrder
		* DataTable : dtPSGOrder
		* 	DataColumn : BedNo(string)
		* 	DataColumn : PatientName(string)
		* 	DataColumn : PatientSex(string)
		* 	DataColumn : PatientAge(string)
		* 	DataColumn : InPatientID(string)
		* 	DataColumn : PSGNumber(string)
		* 	DataColumn : ApplicationDate(string)
		* 	DataColumn : Address(string)
		* 	DataColumn : PayType(string)
		* 	DataColumn : ClinicalImpression(string)
		* 	DataColumn : Assay(string)
		* 	DataColumn : ClinicalDiagnose(string)
		* 	DataColumn : RequesterSign(string)
		* 	DataColumn : CheckItem1(string)
		* 	DataColumn : CheckItem2(string)
		* 	DataColumn : CheckItem3(string)
		* 	DataColumn : CheckItem4(string)
		* 	DataColumn : CheckItem5(string)
		* 	DataColumn : CheckItem6(string)
		* 	DataColumn : CheckItem7(string)
		* 	DataColumn : CheckItem8(string)
		* 	DataColumn : CheckItem9(string)
		* 	DataColumn : CheckItem10(string)
		* 	DataColumn : CheckItem11(string)
		* 	DataColumn : CheckItem12(string)
		* 	DataColumn : CheckItem13(string)
		* 	DataColumn : CheckItem14(string)
		* 	DataColumn : CheckItem15(string)
		* 	DataColumn : CheckItem16(string)
		* 	DataColumn : Other1(string)
		* 	DataColumn : Other2(string)
		* 	DataColumn : Other3(string)
		* 	DataColumn : Other4(string)
		* 	DataColumn : Other5(string)
		* 	DataColumn : Other6(string)
		* 	DataColumn : Other7(string)
		* 	DataColumn : Other8(string)
		* 	DataColumn : Other9(string)
		* 	DataColumn : Other10(string)
		*/ 
		private void m_mthAddNewDataFordsPSGOrderDataSet(DataSet dsdsPSGOrder)
		{
			try
			{
				DataTable dtdtPSGOrder = dsdsPSGOrder.Tables["DTPSGORDER"];
				//dtdtPSGOrder.Rows.Clear();

				object [] objdtPSGOrderDatas = new object[39];

			
				if(m_objPSG!=null && m_objCurrentPatient!=null)
				{
                    if (m_ObjCurrentBed != null)
                    {
                        objdtPSGOrderDatas[0] = m_ObjCurrentBed.m_strCODE_CHR;
                    }
                    else
                    {
                        objdtPSGOrderDatas[0] = string.Empty;
                    }
					objdtPSGOrderDatas[1] =m_objCurrentPatient.m_ObjPeopleInfo.m_StrLastName;;
					objdtPSGOrderDatas[2] = m_objCurrentPatient.m_ObjPeopleInfo.m_StrSex;
					objdtPSGOrderDatas[3] = m_objCurrentPatient.m_ObjPeopleInfo.m_StrAge;
                    if (m_ObjCurrentEmrPatientSession != null)
                    {
                        objdtPSGOrderDatas[4] = m_ObjCurrentEmrPatientSession.m_strHISInpatientId;
                    }
                    else
                    {
                        objdtPSGOrderDatas[4] = string.Empty;
                    }
					objdtPSGOrderDatas[5] = m_objPSG.m_strPSGNumber  ;
					objdtPSGOrderDatas[6] = DateTime.Parse(m_objPSG.m_strApplicationDate).ToString("yyyy年MM月dd日 HH:mm");
					objdtPSGOrderDatas[7] = m_objPSG.m_strAddress ;
			
					switch(m_objPSG.m_enmPayType )
					{
						case enmPayType.enmPublic  :
							objdtPSGOrderDatas[8] ="交费方式：市公费√、单位记帐、自费" ;
							break;
						case enmPayType.enmCompany :
							objdtPSGOrderDatas[8] ="交费方式：市公费、单位记帐√、自费" ;
							break;
						case enmPayType.enmPrivate :
							objdtPSGOrderDatas[8] ="交费方式：市公费、单位记帐、自费√" ;
							break;
						case enmPayType.enmUnknow :
							objdtPSGOrderDatas[8] ="交费方式：市公费、单位记帐、自费" ;
							break;
					}
			
					objdtPSGOrderDatas[9] = m_objPSG.m_strClinicalImpression;
					objdtPSGOrderDatas[10] = m_objPSG.m_strAssay ;
					objdtPSGOrderDatas[11] = m_objPSG.m_strClinicalDiagnose ;
					objdtPSGOrderDatas[12] = m_txtRequesterSign.Text ;
					objdtPSGOrderDatas[13] = (m_objPSG.m_strCheckItem[0]=='1' ? "√" : "");
					objdtPSGOrderDatas[14] = (m_objPSG.m_strCheckItem[1]=='1' ? "√" : "");
					objdtPSGOrderDatas[15] = (m_objPSG.m_strCheckItem[2]=='1' ? "√" : "");
					objdtPSGOrderDatas[16] = (m_objPSG.m_strCheckItem[3]=='1' ? "√" : "");
					objdtPSGOrderDatas[17] = (m_objPSG.m_strCheckItem[4]=='1' ? "√" : "");
					objdtPSGOrderDatas[18] = (m_objPSG.m_strCheckItem[5]=='1' ? "√" : "");
					objdtPSGOrderDatas[19] = (m_objPSG.m_strCheckItem[6]=='1' ? "√" : "");
					objdtPSGOrderDatas[20] = (m_objPSG.m_strCheckItem[7]=='1' ? "√" : "");
					objdtPSGOrderDatas[21] = (m_objPSG.m_strCheckItem[8]=='1' ? "√" : "");
					objdtPSGOrderDatas[22] = (m_objPSG.m_strCheckItem[9]=='1' ? "√" : "");
					objdtPSGOrderDatas[23] = (m_objPSG.m_strCheckItem[10]=='1' ? "√" : "");
					objdtPSGOrderDatas[24] = (m_objPSG.m_strCheckItem[11]=='1' ? "√" : "");
					objdtPSGOrderDatas[25] = (m_objPSG.m_strCheckItem[12]=='1' ? "√" : "");
					objdtPSGOrderDatas[26] = (m_objPSG.m_strCheckItem[13]=='1' ? "√" : "");
					objdtPSGOrderDatas[27] = (m_objPSG.m_strCheckItem[14]=='1' ? "√" : "");
					objdtPSGOrderDatas[28] = (m_objPSG.m_strCheckItem[15]=='1' ? "√" : "");
                    if (m_ObjCurrentEmrPatientSession != null)
                    {
                        objdtPSGOrderDatas[29] = m_ObjCurrentEmrPatientSession.m_strAreaName;
                    }
                    else
                    {
                        objdtPSGOrderDatas[29] = string.Empty;
                    }
					objdtPSGOrderDatas[30] = "";
					objdtPSGOrderDatas[31] = "";
					objdtPSGOrderDatas[32] = "";
					objdtPSGOrderDatas[33] = "";
					objdtPSGOrderDatas[34] = "";
					objdtPSGOrderDatas[35] = "";
					objdtPSGOrderDatas[36] = "";
					objdtPSGOrderDatas[37] = "";
					objdtPSGOrderDatas[38] = "";
				}
				else 
				{
					for(int i=0;i<objdtPSGOrderDatas.Length-1;i++)
						objdtPSGOrderDatas[i]="";
				}

				dtdtPSGOrder.Rows.Add(objdtPSGOrderDatas);
				m_rpdOrderRept.Database.Tables["DTPSGORDER"].SetDataSource(dtdtPSGOrder);

				m_rpdOrderRept.Refresh();
			}
			catch//(Exception ex )
			{
//				MessageBox.Show(ex.Message );

			}
			//MemoryStream objStream = new MemoryStream(300);
			//.Save(objStream,ImageFormat.Bmp);
			//object objImage = objStream.GetBuffer();
		}

		#endregion

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

