using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.Utility.Controls;
using System.Data ;
namespace iCare
{
	/// <summary>
	/// 产程进展 的摘要说明。
	/// </summary>
	public class frmBornScheduleRecord : frmHRPBaseForm,PublicFunction
	{
		#region system variable
		private System.Windows.Forms.GroupBox groupbox1;
		private PinkieControls.ButtonXP m_cmdSave;
		private PinkieControls.ButtonXP m_cmdDelete;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel1;
		private com.digitalwave.Utility.Controls.ctlTimePicker m_dtpRecordDateTime;
		private System.Windows.Forms.NumericUpDown m_nmuEventHour;
		private System.Windows.Forms.Label lblEventMinute;
		private System.Windows.Forms.NumericUpDown m_nmuEventMinute;
		private System.Windows.Forms.Label lblEventHour;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtPressureSystolicValue;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label lblPressureSystolicUnit;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		protected System.Windows.Forms.ListView m_lsvEmployee;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private PinkieControls.ButtonXP m_cmdSign;
		private com.digitalwave.controls.ctlRichTextBox m_txtSign;

		#endregion user-defined variable

		#region  
		private  com.digitalwave.Utility.Controls.ctlBornScheduleRecord m_ctlRecord;
		private clsBornRecordManager m_objBornRecordManager;
		private clsBornScheduleEveryDay m_objCurrentBornScheduleEveryDay;
		private int m_intPageIndex=0; //产程天数索引
		clsBornScheduleDomain m_objBornScheduleDomain;
		private string  m_strModifyItem=null;
		private int m_intCurrentHour=0;

		private	clsCommonUseToolCollection m_objCUTC;//签名类
		#endregion
        #region control
        private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Button button1;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtVenterScaleLeft;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtEMBRYOHEART;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtExtendPressure;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtScalePressure;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtFourPointRight;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtFourPointLeft;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtThreePointRight;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtThreePointLeft;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtSecondPointRight;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtSecondPointLeft;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtFirstPointRight;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtFirstPointLeft;
		private System.Windows.Forms.RichTextBox m_txtDealNote;
		private System.Windows.Forms.RichTextBox m_txtEXCEPTIONNOTE;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtVenterScaleRight;
		private com.digitalwave.Utility.Controls.ctlTimePicker m_dtpFORECASTDATE;
		private System.Windows.Forms.Label label26;
		private com.digitalwave.Utility.Controls.ctlTimePicker m_dtmCHILDBIRTHDATE;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.TreeView m_lsvRecordDate;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label29;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtHour;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtVENTERPOINT;
		private System.ComponentModel.IContainer components;

        #endregion 


        public frmBornScheduleRecord()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
            //指明医生工作站表单
            intFormType = 1;
			//初始化数据类
			m_objBornRecordManager=new clsBornRecordManager();
			m_objBornScheduleDomain=new clsBornScheduleDomain();

			m_txtSign.LostFocus += new EventHandler(m_lsvEmployee_LostFocus);

			//签名常用值
			m_objCUTC = new clsCommonUseToolCollection(this);
			m_objCUTC.m_mthBindEmployeeSign(new Control[]{this.m_cmdSign },
				new Control[]{this.m_txtSign },new int[]{1});
			
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
            com.digitalwave.Utility.Controls.clsBornRecordManager clsBornRecordManager2 = new com.digitalwave.Utility.Controls.clsBornRecordManager();
            this.m_ctlRecord = new com.digitalwave.Utility.Controls.ctlBornScheduleRecord();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupbox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label28 = new System.Windows.Forms.Label();
            this.m_txtVENTERPOINT = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.m_dtmCHILDBIRTHDATE = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.m_txtFourPointRight = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.m_txtFourPointLeft = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.m_txtThreePointRight = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.m_txtThreePointLeft = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.m_txtSecondPointRight = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.m_txtSecondPointLeft = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.m_txtFirstPointRight = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.m_txtFirstPointLeft = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.m_dtpRecordDateTime = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.m_lsvEmployee = new System.Windows.Forms.ListView();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.m_cmdSign = new PinkieControls.ButtonXP();
            this.m_txtSign = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtDealNote = new System.Windows.Forms.RichTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.m_txtEXCEPTIONNOTE = new System.Windows.Forms.RichTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.m_txtVenterScaleRight = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.m_txtVenterScaleLeft = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.m_txtEMBRYOHEART = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblPressureSystolicUnit = new System.Windows.Forms.Label();
            this.m_txtExtendPressure = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.m_txtScalePressure = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_txtHour = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_txtPressureSystolicValue = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_dtpFORECASTDATE = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.m_nmuEventHour = new System.Windows.Forms.NumericUpDown();
            this.lblEventMinute = new System.Windows.Forms.Label();
            this.m_nmuEventMinute = new System.Windows.Forms.NumericUpDown();
            this.lblEventHour = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.m_cmdSave = new PinkieControls.ButtonXP();
            this.m_cmdDelete = new PinkieControls.ButtonXP();
            this.m_lsvRecordDate = new System.Windows.Forms.TreeView();
            this.label27 = new System.Windows.Forms.Label();
            this.m_pnlNewBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_ctlRecord)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupbox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nmuEventHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nmuEventMinute)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(122, 273);
            this.lblSex.Size = new System.Drawing.Size(40, 21);
            this.lblSex.DoubleClick += new System.EventHandler(this.lblAgeTitle_DoubleClick);
            this.lblSex.Click += new System.EventHandler(this.lblSex_Click);
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(138, 227);
            this.lblAge.Size = new System.Drawing.Size(40, 21);
            this.lblAge.DoubleClick += new System.EventHandler(this.lblAgeTitle_DoubleClick);
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(136, 16);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(106, 257);
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(85, 227);
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(110, 197);
            this.lblSexTitle.DoubleClick += new System.EventHandler(this.lblAgeTitle_DoubleClick);
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(116, 210);
            this.lblAgeTitle.DoubleClick += new System.EventHandler(this.lblAgeTitle_DoubleClick);
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(79, 258);
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(94, 182);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(16, 112);
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(88, 231);
            this.txtInPatientID.Size = new System.Drawing.Size(64, 23);
            this.txtInPatientID.TabStop = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(75, 227);
            this.m_txtPatientName.Size = new System.Drawing.Size(64, 23);
            this.m_txtPatientName.TabStop = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(96, 235);
            this.m_txtBedNO.Size = new System.Drawing.Size(56, 23);
            this.m_txtBedNO.TabStop = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(50, 232);
            this.m_cboArea.Size = new System.Drawing.Size(96, 23);
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(119, 214);
            this.m_lsvPatientName.Size = new System.Drawing.Size(32, 16);
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(88, 214);
            this.m_lsvBedNO.Size = new System.Drawing.Size(72, 80);
            this.m_lsvBedNO.DoubleClick += new System.EventHandler(this.lblAgeTitle_DoubleClick);
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(56, 244);
            this.m_cboDept.Size = new System.Drawing.Size(96, 23);
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(72, 244);
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(72, 222);
            this.m_cmdNewTemplate.Size = new System.Drawing.Size(98, 36);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.Location = new System.Drawing.Point(119, 231);
            this.m_cmdNext.Size = new System.Drawing.Size(24, 24);
            this.m_cmdNext.Visible = true;
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(136, 246);
            this.m_cmdPre.Size = new System.Drawing.Size(16, 24);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(304, 0);
            this.m_lblForTitle.Size = new System.Drawing.Size(18, 26);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(722, 33);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Location = new System.Drawing.Point(5, 6);
            this.m_pnlNewBase.Size = new System.Drawing.Size(825, 60);
            this.m_pnlNewBase.Visible = true;
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(823, 29);
            // 
            // m_ctlRecord
            // 
            this.m_ctlRecord.BackColor = System.Drawing.Color.White;
            this.m_ctlRecord.Location = new System.Drawing.Point(5, 8);
            this.m_ctlRecord.m_ClrBorder = System.Drawing.Color.Black;
            this.m_ctlRecord.m_ClrContinueLine = System.Drawing.Color.Black;
            this.m_ctlRecord.m_ClrDrawText = System.Drawing.Color.Black;
            this.m_ctlRecord.m_ClrGridLine = System.Drawing.Color.Black;
            this.m_ctlRecord.m_ClrSpecialLine = System.Drawing.Color.Red;
            this.m_ctlRecord.m_ClrVenterSymbol = System.Drawing.Color.Red;
            this.m_ctlRecord.m_clsBornRecordManager = clsBornRecordManager2;
            this.m_ctlRecord.m_StrUserID = null;
            this.m_ctlRecord.m_StrUserName = null;
            this.m_ctlRecord.Name = "m_ctlRecord";
            this.m_ctlRecord.Size = new System.Drawing.Size(568, 552);
            this.m_ctlRecord.TabIndex = 0;
            this.m_ctlRecord.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.m_ctlRecord);
            this.panel2.Location = new System.Drawing.Point(251, 69);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(579, 568);
            this.panel2.TabIndex = 10000007;
            // 
            // groupbox1
            // 
            this.groupbox1.Controls.Add(this.panel1);
            this.groupbox1.Controls.Add(this.m_cmdSave);
            this.groupbox1.Controls.Add(this.m_cmdDelete);
            this.groupbox1.Location = new System.Drawing.Point(5, 107);
            this.groupbox1.Name = "groupbox1";
            this.groupbox1.Size = new System.Drawing.Size(243, 530);
            this.groupbox1.TabIndex = 0;
            this.groupbox1.TabStop = false;
            this.groupbox1.Text = "具体操作";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label28);
            this.panel1.Controls.Add(this.m_txtVENTERPOINT);
            this.panel1.Controls.Add(this.label29);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.m_dtmCHILDBIRTHDATE);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.m_txtFourPointRight);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.m_txtFourPointLeft);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(this.m_txtThreePointRight);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Controls.Add(this.m_txtThreePointLeft);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.m_txtSecondPointRight);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.m_txtSecondPointLeft);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.m_txtFirstPointRight);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.m_txtFirstPointLeft);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.m_dtpRecordDateTime);
            this.panel1.Controls.Add(this.m_lsvEmployee);
            this.panel1.Controls.Add(this.m_cmdSign);
            this.panel1.Controls.Add(this.m_txtSign);
            this.panel1.Controls.Add(this.m_txtDealNote);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.m_txtEXCEPTIONNOTE);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.m_txtVenterScaleRight);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.m_txtVenterScaleLeft);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.m_txtEMBRYOHEART);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.lblPressureSystolicUnit);
            this.panel1.Controls.Add(this.m_txtExtendPressure);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.m_txtScalePressure);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.m_txtHour);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.m_txtPressureSystolicValue);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.m_dtpFORECASTDATE);
            this.panel1.Controls.Add(this.m_nmuEventHour);
            this.panel1.Controls.Add(this.lblEventMinute);
            this.panel1.Controls.Add(this.m_nmuEventMinute);
            this.panel1.Controls.Add(this.lblEventHour);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label26);
            this.panel1.Location = new System.Drawing.Point(8, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(224, 464);
            this.panel1.TabIndex = 10000007;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.SystemColors.Control;
            this.label28.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label28.ForeColor = System.Drawing.Color.Black;
            this.label28.Location = new System.Drawing.Point(120, 56);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(49, 14);
            this.label28.TabIndex = 0;
            this.label28.Text = "大厘米";
            this.label28.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // m_txtVENTERPOINT
            // 
            this.m_txtVENTERPOINT.BackColor = System.Drawing.Color.White;
            this.m_txtVENTERPOINT.BorderColor = System.Drawing.Color.White;
            this.m_txtVENTERPOINT.ForeColor = System.Drawing.Color.Black;
            this.m_txtVENTERPOINT.Location = new System.Drawing.Point(64, 56);
            this.m_txtVENTERPOINT.Name = "m_txtVENTERPOINT";
            this.m_txtVENTERPOINT.Size = new System.Drawing.Size(56, 23);
            this.m_txtVENTERPOINT.TabIndex = 2;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.SystemColors.Control;
            this.label29.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label29.ForeColor = System.Drawing.Color.Black;
            this.label29.Location = new System.Drawing.Point(8, 56);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(56, 14);
            this.label29.TabIndex = 0;
            this.label29.Text = "宫口开:";
            this.label29.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(144, 136);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(104, 24);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.TabStop = false;
            this.checkBox1.Text = "胎儿娩出";
            this.checkBox1.Visible = false;
            // 
            // m_dtmCHILDBIRTHDATE
            // 
            this.m_dtmCHILDBIRTHDATE.BackColor = System.Drawing.Color.White;
            this.m_dtmCHILDBIRTHDATE.BorderColor = System.Drawing.Color.Black;
            this.m_dtmCHILDBIRTHDATE.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtmCHILDBIRTHDATE.DropButtonBackColor = System.Drawing.Color.White;
            this.m_dtmCHILDBIRTHDATE.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtmCHILDBIRTHDATE.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtmCHILDBIRTHDATE.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtmCHILDBIRTHDATE.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtmCHILDBIRTHDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtmCHILDBIRTHDATE.Location = new System.Drawing.Point(200, 336);
            this.m_dtmCHILDBIRTHDATE.m_BlnOnlyTime = false;
            this.m_dtmCHILDBIRTHDATE.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtmCHILDBIRTHDATE.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtmCHILDBIRTHDATE.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtmCHILDBIRTHDATE.Name = "m_dtmCHILDBIRTHDATE";
            this.m_dtmCHILDBIRTHDATE.ReadOnly = false;
            this.m_dtmCHILDBIRTHDATE.Size = new System.Drawing.Size(16, 22);
            this.m_dtmCHILDBIRTHDATE.TabIndex = 0;
            this.m_dtmCHILDBIRTHDATE.TabStop = false;
            this.m_dtmCHILDBIRTHDATE.TextBackColor = System.Drawing.Color.White;
            this.m_dtmCHILDBIRTHDATE.TextForeColor = System.Drawing.Color.Black;
            this.m_dtmCHILDBIRTHDATE.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 280);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 25);
            this.button1.TabIndex = 10000048;
            this.button1.TabStop = false;
            this.button1.Text = "应用默认值";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(208, 440);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(8, 23);
            this.label20.TabIndex = 10000047;
            this.label20.Text = ")";
            // 
            // m_txtFourPointRight
            // 
            this.m_txtFourPointRight.BackColor = System.Drawing.Color.White;
            this.m_txtFourPointRight.BorderColor = System.Drawing.Color.White;
            this.m_txtFourPointRight.ForeColor = System.Drawing.Color.Black;
            this.m_txtFourPointRight.Location = new System.Drawing.Point(184, 440);
            this.m_txtFourPointRight.Name = "m_txtFourPointRight";
            this.m_txtFourPointRight.Size = new System.Drawing.Size(24, 23);
            this.m_txtFourPointRight.TabIndex = 21;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(176, 440);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(8, 23);
            this.label21.TabIndex = 10000045;
            this.label21.Text = ",";
            // 
            // m_txtFourPointLeft
            // 
            this.m_txtFourPointLeft.BackColor = System.Drawing.Color.White;
            this.m_txtFourPointLeft.BorderColor = System.Drawing.Color.White;
            this.m_txtFourPointLeft.ForeColor = System.Drawing.Color.Black;
            this.m_txtFourPointLeft.Location = new System.Drawing.Point(152, 440);
            this.m_txtFourPointLeft.Name = "m_txtFourPointLeft";
            this.m_txtFourPointLeft.Size = new System.Drawing.Size(24, 23);
            this.m_txtFourPointLeft.TabIndex = 20;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.SystemColors.Control;
            this.label22.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(8, 440);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(147, 14);
            this.label22.TabIndex = 0;
            this.label22.Text = "默认第二条线第二点:(";
            this.label22.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(208, 416);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(8, 23);
            this.label23.TabIndex = 10000042;
            this.label23.Text = ")";
            // 
            // m_txtThreePointRight
            // 
            this.m_txtThreePointRight.BackColor = System.Drawing.Color.White;
            this.m_txtThreePointRight.BorderColor = System.Drawing.Color.White;
            this.m_txtThreePointRight.ForeColor = System.Drawing.Color.Black;
            this.m_txtThreePointRight.Location = new System.Drawing.Point(184, 416);
            this.m_txtThreePointRight.Name = "m_txtThreePointRight";
            this.m_txtThreePointRight.Size = new System.Drawing.Size(24, 23);
            this.m_txtThreePointRight.TabIndex = 19;
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(176, 416);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(8, 23);
            this.label24.TabIndex = 10000040;
            this.label24.Text = ",";
            // 
            // m_txtThreePointLeft
            // 
            this.m_txtThreePointLeft.BackColor = System.Drawing.Color.White;
            this.m_txtThreePointLeft.BorderColor = System.Drawing.Color.White;
            this.m_txtThreePointLeft.ForeColor = System.Drawing.Color.Black;
            this.m_txtThreePointLeft.Location = new System.Drawing.Point(152, 416);
            this.m_txtThreePointLeft.Name = "m_txtThreePointLeft";
            this.m_txtThreePointLeft.Size = new System.Drawing.Size(24, 23);
            this.m_txtThreePointLeft.TabIndex = 18;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.SystemColors.Control;
            this.label25.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(8, 416);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(147, 14);
            this.label25.TabIndex = 0;
            this.label25.Text = "默认第二条线第一点:(";
            this.label25.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(208, 392);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(8, 23);
            this.label17.TabIndex = 10000037;
            this.label17.Text = ")";
            // 
            // m_txtSecondPointRight
            // 
            this.m_txtSecondPointRight.BackColor = System.Drawing.Color.White;
            this.m_txtSecondPointRight.BorderColor = System.Drawing.Color.White;
            this.m_txtSecondPointRight.ForeColor = System.Drawing.Color.Black;
            this.m_txtSecondPointRight.Location = new System.Drawing.Point(184, 392);
            this.m_txtSecondPointRight.Name = "m_txtSecondPointRight";
            this.m_txtSecondPointRight.Size = new System.Drawing.Size(24, 23);
            this.m_txtSecondPointRight.TabIndex = 17;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(176, 392);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(8, 23);
            this.label18.TabIndex = 10000035;
            this.label18.Text = ",";
            // 
            // m_txtSecondPointLeft
            // 
            this.m_txtSecondPointLeft.BackColor = System.Drawing.Color.White;
            this.m_txtSecondPointLeft.BorderColor = System.Drawing.Color.White;
            this.m_txtSecondPointLeft.ForeColor = System.Drawing.Color.Black;
            this.m_txtSecondPointLeft.Location = new System.Drawing.Point(152, 392);
            this.m_txtSecondPointLeft.Name = "m_txtSecondPointLeft";
            this.m_txtSecondPointLeft.Size = new System.Drawing.Size(24, 23);
            this.m_txtSecondPointLeft.TabIndex = 16;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.SystemColors.Control;
            this.label19.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(8, 392);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(147, 14);
            this.label19.TabIndex = 0;
            this.label19.Text = "默认第一条线第二点:(";
            this.label19.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(208, 368);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(8, 23);
            this.label16.TabIndex = 10000032;
            this.label16.Text = ")";
            // 
            // m_txtFirstPointRight
            // 
            this.m_txtFirstPointRight.BackColor = System.Drawing.Color.White;
            this.m_txtFirstPointRight.BorderColor = System.Drawing.Color.White;
            this.m_txtFirstPointRight.ForeColor = System.Drawing.Color.Black;
            this.m_txtFirstPointRight.Location = new System.Drawing.Point(184, 368);
            this.m_txtFirstPointRight.Name = "m_txtFirstPointRight";
            this.m_txtFirstPointRight.Size = new System.Drawing.Size(24, 23);
            this.m_txtFirstPointRight.TabIndex = 15;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(176, 368);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(8, 23);
            this.label15.TabIndex = 10000030;
            this.label15.Text = ",";
            // 
            // m_txtFirstPointLeft
            // 
            this.m_txtFirstPointLeft.BackColor = System.Drawing.Color.White;
            this.m_txtFirstPointLeft.BorderColor = System.Drawing.Color.White;
            this.m_txtFirstPointLeft.ForeColor = System.Drawing.Color.Black;
            this.m_txtFirstPointLeft.Location = new System.Drawing.Point(152, 368);
            this.m_txtFirstPointLeft.Name = "m_txtFirstPointLeft";
            this.m_txtFirstPointLeft.Size = new System.Drawing.Size(24, 23);
            this.m_txtFirstPointLeft.TabIndex = 14;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.SystemColors.Control;
            this.label14.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(8, 368);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(147, 14);
            this.label14.TabIndex = 0;
            this.label14.Text = "默认第一条线第一点:(";
            this.label14.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // m_dtpRecordDateTime
            // 
            this.m_dtpRecordDateTime.BackColor = System.Drawing.Color.White;
            this.m_dtpRecordDateTime.BorderColor = System.Drawing.Color.Black;
            this.m_dtpRecordDateTime.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpRecordDateTime.DropButtonBackColor = System.Drawing.Color.White;
            this.m_dtpRecordDateTime.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpRecordDateTime.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpRecordDateTime.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpRecordDateTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpRecordDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpRecordDateTime.Location = new System.Drawing.Point(64, 8);
            this.m_dtpRecordDateTime.m_BlnOnlyTime = false;
            this.m_dtpRecordDateTime.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpRecordDateTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpRecordDateTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpRecordDateTime.Name = "m_dtpRecordDateTime";
            this.m_dtpRecordDateTime.ReadOnly = false;
            this.m_dtpRecordDateTime.Size = new System.Drawing.Size(137, 22);
            this.m_dtpRecordDateTime.TabIndex = 504;
            this.m_dtpRecordDateTime.TabStop = false;
            this.m_dtpRecordDateTime.TextBackColor = System.Drawing.Color.White;
            this.m_dtpRecordDateTime.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_lsvEmployee
            // 
            this.m_lsvEmployee.BackColor = System.Drawing.Color.White;
            this.m_lsvEmployee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lsvEmployee.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7});
            this.m_lsvEmployee.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvEmployee.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_lsvEmployee.FullRowSelect = true;
            this.m_lsvEmployee.GridLines = true;
            this.m_lsvEmployee.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_lsvEmployee.Location = new System.Drawing.Point(107, 263);
            this.m_lsvEmployee.Name = "m_lsvEmployee";
            this.m_lsvEmployee.Size = new System.Drawing.Size(102, 13);
            this.m_lsvEmployee.TabIndex = 10000027;
            this.m_lsvEmployee.UseCompatibleStateImageBehavior = false;
            this.m_lsvEmployee.View = System.Windows.Forms.View.Details;
            this.m_lsvEmployee.Visible = false;
            this.m_lsvEmployee.DoubleClick += new System.EventHandler(this.m_lsvEmployee_DoubleClick);
            this.m_lsvEmployee.LostFocus += new System.EventHandler(this.m_lsvEmployee_LostFocus);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Width = 0;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Width = 100;
            // 
            // m_cmdSign
            // 
            this.m_cmdSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.m_cmdSign.DefaultScheme = true;
            this.m_cmdSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSign.Hint = "";
            this.m_cmdSign.Location = new System.Drawing.Point(96, 280);
            this.m_cmdSign.Name = "m_cmdSign";
            this.m_cmdSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSign.Size = new System.Drawing.Size(40, 25);
            this.m_cmdSign.TabIndex = 12;
            this.m_cmdSign.Text = "签名:";
            // 
            // m_txtSign
            // 
            this.m_txtSign.AccessibleDescription = "签名";
            this.m_txtSign.BackColor = System.Drawing.Color.White;
            this.m_txtSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSign.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtSign.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSign.Location = new System.Drawing.Point(144, 280);
            this.m_txtSign.m_BlnIgnoreUserInfo = false;
            this.m_txtSign.m_BlnPartControl = false;
            this.m_txtSign.m_BlnReadOnly = false;
            this.m_txtSign.m_BlnUnderLineDST = false;
            this.m_txtSign.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtSign.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtSign.m_IntCanModifyTime = 6;
            this.m_txtSign.m_IntPartControlLength = 0;
            this.m_txtSign.m_IntPartControlStartIndex = 0;
            this.m_txtSign.m_StrUserID = "";
            this.m_txtSign.m_StrUserName = "";
            this.m_txtSign.MaxLength = 8000;
            this.m_txtSign.Multiline = false;
            this.m_txtSign.Name = "m_txtSign";
            this.m_txtSign.Size = new System.Drawing.Size(72, 22);
            this.m_txtSign.TabIndex = 10000025;
            this.m_txtSign.TabStop = false;
            this.m_txtSign.Text = "";
            this.m_txtSign.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthEvent_KeyDown);
            // 
            // m_txtDealNote
            // 
            this.m_txtDealNote.Location = new System.Drawing.Point(64, 232);
            this.m_txtDealNote.Name = "m_txtDealNote";
            this.m_txtDealNote.Size = new System.Drawing.Size(152, 40);
            this.m_txtDealNote.TabIndex = 11;
            this.m_txtDealNote.Text = "";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.Control;
            this.label13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(0, 224);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 14);
            this.label13.TabIndex = 0;
            this.label13.Text = "处理记录:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // m_txtEXCEPTIONNOTE
            // 
            this.m_txtEXCEPTIONNOTE.Location = new System.Drawing.Point(64, 184);
            this.m_txtEXCEPTIONNOTE.Name = "m_txtEXCEPTIONNOTE";
            this.m_txtEXCEPTIONNOTE.Size = new System.Drawing.Size(152, 40);
            this.m_txtEXCEPTIONNOTE.TabIndex = 10;
            this.m_txtEXCEPTIONNOTE.Text = "";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(0, 184);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 14);
            this.label12.TabIndex = 0;
            this.label12.Text = "异常情况:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // m_txtVenterScaleRight
            // 
            this.m_txtVenterScaleRight.BackColor = System.Drawing.Color.White;
            this.m_txtVenterScaleRight.BorderColor = System.Drawing.Color.White;
            this.m_txtVenterScaleRight.ForeColor = System.Drawing.Color.Black;
            this.m_txtVenterScaleRight.Location = new System.Drawing.Point(144, 160);
            this.m_txtVenterScaleRight.Name = "m_txtVenterScaleRight";
            this.m_txtVenterScaleRight.Size = new System.Drawing.Size(56, 23);
            this.m_txtVenterScaleRight.TabIndex = 9;
            this.m_txtVenterScaleRight.TextChanged += new System.EventHandler(this.ctlBorderTextBox6_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.Control;
            this.label11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(128, 160);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 14);
            this.label11.TabIndex = 0;
            this.label11.Text = "/";
            this.label11.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // m_txtVenterScaleLeft
            // 
            this.m_txtVenterScaleLeft.BackColor = System.Drawing.Color.White;
            this.m_txtVenterScaleLeft.BorderColor = System.Drawing.Color.White;
            this.m_txtVenterScaleLeft.ForeColor = System.Drawing.Color.Black;
            this.m_txtVenterScaleLeft.Location = new System.Drawing.Point(64, 160);
            this.m_txtVenterScaleLeft.Name = "m_txtVenterScaleLeft";
            this.m_txtVenterScaleLeft.Size = new System.Drawing.Size(56, 23);
            this.m_txtVenterScaleLeft.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(8, 160);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 14);
            this.label10.TabIndex = 0;
            this.label10.Text = "宫缩:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // m_txtEMBRYOHEART
            // 
            this.m_txtEMBRYOHEART.BackColor = System.Drawing.Color.White;
            this.m_txtEMBRYOHEART.BorderColor = System.Drawing.Color.White;
            this.m_txtEMBRYOHEART.ForeColor = System.Drawing.Color.Black;
            this.m_txtEMBRYOHEART.Location = new System.Drawing.Point(64, 136);
            this.m_txtEMBRYOHEART.Name = "m_txtEMBRYOHEART";
            this.m_txtEMBRYOHEART.Size = new System.Drawing.Size(56, 23);
            this.m_txtEMBRYOHEART.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(8, 136);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 14);
            this.label9.TabIndex = 0;
            this.label9.Text = "胎心:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblPressureSystolicUnit
            // 
            this.lblPressureSystolicUnit.AutoSize = true;
            this.lblPressureSystolicUnit.BackColor = System.Drawing.SystemColors.Control;
            this.lblPressureSystolicUnit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPressureSystolicUnit.ForeColor = System.Drawing.Color.Black;
            this.lblPressureSystolicUnit.Location = new System.Drawing.Point(184, 112);
            this.lblPressureSystolicUnit.Name = "lblPressureSystolicUnit";
            this.lblPressureSystolicUnit.Size = new System.Drawing.Size(35, 14);
            this.lblPressureSystolicUnit.TabIndex = 0;
            this.lblPressureSystolicUnit.Text = "mmHg";
            this.lblPressureSystolicUnit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // m_txtExtendPressure
            // 
            this.m_txtExtendPressure.BackColor = System.Drawing.Color.White;
            this.m_txtExtendPressure.BorderColor = System.Drawing.Color.White;
            this.m_txtExtendPressure.ForeColor = System.Drawing.Color.Black;
            this.m_txtExtendPressure.Location = new System.Drawing.Point(136, 112);
            this.m_txtExtendPressure.Name = "m_txtExtendPressure";
            this.m_txtExtendPressure.Size = new System.Drawing.Size(48, 23);
            this.m_txtExtendPressure.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(120, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 14);
            this.label8.TabIndex = 0;
            this.label8.Text = "/";
            this.label8.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // m_txtScalePressure
            // 
            this.m_txtScalePressure.BackColor = System.Drawing.Color.White;
            this.m_txtScalePressure.BorderColor = System.Drawing.Color.White;
            this.m_txtScalePressure.ForeColor = System.Drawing.Color.Black;
            this.m_txtScalePressure.Location = new System.Drawing.Point(64, 112);
            this.m_txtScalePressure.Name = "m_txtScalePressure";
            this.m_txtScalePressure.Size = new System.Drawing.Size(56, 23);
            this.m_txtScalePressure.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(8, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 14);
            this.label7.TabIndex = 0;
            this.label7.Text = "血压:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(120, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 14);
            this.label6.TabIndex = 0;
            this.label6.Text = "小时";
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // m_txtHour
            // 
            this.m_txtHour.BackColor = System.Drawing.Color.White;
            this.m_txtHour.BorderColor = System.Drawing.Color.White;
            this.m_txtHour.ForeColor = System.Drawing.Color.Black;
            this.m_txtHour.Location = new System.Drawing.Point(64, 32);
            this.m_txtHour.Name = "m_txtHour";
            this.m_txtHour.Size = new System.Drawing.Size(56, 23);
            this.m_txtHour.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(8, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 14);
            this.label5.TabIndex = 0;
            this.label5.Text = "分娩第:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(-16, 312);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(344, 1);
            this.label4.TabIndex = 1002;
            this.label4.Text = "label4";
            // 
            // m_txtPressureSystolicValue
            // 
            this.m_txtPressureSystolicValue.BackColor = System.Drawing.Color.White;
            this.m_txtPressureSystolicValue.BorderColor = System.Drawing.Color.White;
            this.m_txtPressureSystolicValue.ForeColor = System.Drawing.Color.Black;
            this.m_txtPressureSystolicValue.Location = new System.Drawing.Point(64, 344);
            this.m_txtPressureSystolicValue.Name = "m_txtPressureSystolicValue";
            this.m_txtPressureSystolicValue.Size = new System.Drawing.Size(136, 23);
            this.m_txtPressureSystolicValue.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(8, 344);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "孕产次:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(8, 320);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "预产期:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // m_dtpFORECASTDATE
            // 
            this.m_dtpFORECASTDATE.BackColor = System.Drawing.Color.White;
            this.m_dtpFORECASTDATE.BorderColor = System.Drawing.Color.Black;
            this.m_dtpFORECASTDATE.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpFORECASTDATE.DropButtonBackColor = System.Drawing.Color.White;
            this.m_dtpFORECASTDATE.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpFORECASTDATE.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpFORECASTDATE.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpFORECASTDATE.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpFORECASTDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpFORECASTDATE.Location = new System.Drawing.Point(64, 320);
            this.m_dtpFORECASTDATE.m_BlnOnlyTime = false;
            this.m_dtpFORECASTDATE.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpFORECASTDATE.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpFORECASTDATE.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpFORECASTDATE.Name = "m_dtpFORECASTDATE";
            this.m_dtpFORECASTDATE.ReadOnly = false;
            this.m_dtpFORECASTDATE.Size = new System.Drawing.Size(137, 22);
            this.m_dtpFORECASTDATE.TabIndex = 814;
            this.m_dtpFORECASTDATE.TabStop = false;
            this.m_dtpFORECASTDATE.TextBackColor = System.Drawing.Color.White;
            this.m_dtpFORECASTDATE.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_nmuEventHour
            // 
            this.m_nmuEventHour.BackColor = System.Drawing.Color.White;
            this.m_nmuEventHour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_nmuEventHour.ForeColor = System.Drawing.Color.Black;
            this.m_nmuEventHour.Location = new System.Drawing.Point(64, 80);
            this.m_nmuEventHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.m_nmuEventHour.Name = "m_nmuEventHour";
            this.m_nmuEventHour.Size = new System.Drawing.Size(36, 23);
            this.m_nmuEventHour.TabIndex = 3;
            // 
            // lblEventMinute
            // 
            this.lblEventMinute.AutoSize = true;
            this.lblEventMinute.Location = new System.Drawing.Point(168, 80);
            this.lblEventMinute.Name = "lblEventMinute";
            this.lblEventMinute.Size = new System.Drawing.Size(21, 14);
            this.lblEventMinute.TabIndex = 0;
            this.lblEventMinute.Text = "分";
            // 
            // m_nmuEventMinute
            // 
            this.m_nmuEventMinute.AccessibleName = "save";
            this.m_nmuEventMinute.BackColor = System.Drawing.Color.White;
            this.m_nmuEventMinute.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_nmuEventMinute.ForeColor = System.Drawing.Color.Black;
            this.m_nmuEventMinute.Location = new System.Drawing.Point(128, 80);
            this.m_nmuEventMinute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.m_nmuEventMinute.Name = "m_nmuEventMinute";
            this.m_nmuEventMinute.Size = new System.Drawing.Size(36, 23);
            this.m_nmuEventMinute.TabIndex = 4;
            // 
            // lblEventHour
            // 
            this.lblEventHour.AutoSize = true;
            this.lblEventHour.Location = new System.Drawing.Point(104, 80);
            this.lblEventHour.Name = "lblEventHour";
            this.lblEventHour.Size = new System.Drawing.Size(21, 14);
            this.lblEventHour.TabIndex = 0;
            this.lblEventHour.Text = "时";
            this.lblEventHour.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "检查时间:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.SystemColors.Control;
            this.label26.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(0, 8);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(70, 14);
            this.label26.TabIndex = 0;
            this.label26.Text = "分娩日期:";
            this.label26.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // m_cmdSave
            // 
            this.m_cmdSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.m_cmdSave.DefaultScheme = true;
            this.m_cmdSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSave.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdSave.ForeColor = System.Drawing.Color.Black;
            this.m_cmdSave.Hint = "";
            this.m_cmdSave.Location = new System.Drawing.Point(7, 489);
            this.m_cmdSave.Name = "m_cmdSave";
            this.m_cmdSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSave.Size = new System.Drawing.Size(64, 28);
            this.m_cmdSave.TabIndex = 22;
            this.m_cmdSave.Text = "保存";
            this.m_cmdSave.Click += new System.EventHandler(this.m_cmdSave_Click);
            // 
            // m_cmdDelete
            // 
            this.m_cmdDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.m_cmdDelete.DefaultScheme = true;
            this.m_cmdDelete.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdDelete.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdDelete.ForeColor = System.Drawing.Color.Black;
            this.m_cmdDelete.Hint = "";
            this.m_cmdDelete.Location = new System.Drawing.Point(80, 489);
            this.m_cmdDelete.Name = "m_cmdDelete";
            this.m_cmdDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdDelete.Size = new System.Drawing.Size(64, 28);
            this.m_cmdDelete.TabIndex = 23;
            this.m_cmdDelete.Text = "删除";
            this.m_cmdDelete.Click += new System.EventHandler(this.m_cmdDelete_Click);
            // 
            // m_lsvRecordDate
            // 
            this.m_lsvRecordDate.Location = new System.Drawing.Point(75, 69);
            this.m_lsvRecordDate.Name = "m_lsvRecordDate";
            this.m_lsvRecordDate.Size = new System.Drawing.Size(173, 32);
            this.m_lsvRecordDate.TabIndex = 10000009;
            this.m_lsvRecordDate.TabStop = false;
            this.m_lsvRecordDate.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_lsvRecordDate_AfterSelect);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.SystemColors.Control;
            this.label27.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(3, 69);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(70, 14);
            this.label27.TabIndex = 10000051;
            this.label27.Text = "分娩日期:";
            this.label27.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // frmBornScheduleRecord
            // 
            this.ClientSize = new System.Drawing.Size(856, 653);
            this.Controls.Add(this.groupbox1);
            this.Controls.Add(this.m_lsvRecordDate);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.panel2);
            this.Name = "frmBornScheduleRecord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "产程进展图";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBornScheduleRecord_Load);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.label27, 0);
            this.Controls.SetChildIndex(this.m_lsvRecordDate, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.groupbox1, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_ctlRecord)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupbox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nmuEventHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nmuEventMinute)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		
		#region  事件处理

		//事件绑定
		private void AddControlEventBind()
		{
			m_ctlRecord.m_evnEveryHourMouseDown +=new EventHandler(m_thEveryHour_Click);
			m_ctlRecord.m_evnCheckTimeMouseDown +=new EventHandler(m_thCheckTime_Click);
			m_ctlRecord.m_evnBloodPressureMouseDown +=new EventHandler(m_thBloodPressure_Click);
			m_ctlRecord.m_evnEmbryoHeartMouseDown +=new EventHandler(m_thEmbryoHeart_Click);
			m_ctlRecord.m_evnVenterScaleExtendMouseDown +=new EventHandler(m_thVenterScaleExtend_Click);
			m_ctlRecord.m_evnExceptionNoteMouseDown +=new EventHandler(m_thExceptionNote_Click);
			m_ctlRecord.m_evnDealNoteMouseDown +=new EventHandler(m_thDealNote_Click);
			m_ctlRecord.m_evnSignNameMouseDown +=new EventHandler(m_thSignName_Click);
		}

			//处理宫口开事件
		private void m_thSetFormControl()
		{
			m_dtpFORECASTDATE.Enabled=false;
			m_txtPressureSystolicValue.Enabled=false;
			//m_dtmCHILDBIRTHDATE.Enabled=false;
			m_dtpRecordDateTime.Enabled=false;
			m_nmuEventHour.Enabled=false;
			m_nmuEventMinute.Enabled=false;
			m_txtVENTERPOINT.Enabled=false;
			m_txtScalePressure.Enabled=false;
			m_txtExtendPressure.Enabled=false;
			m_txtEMBRYOHEART.Enabled=false;
			m_txtVenterScaleLeft.Enabled=false;
			m_txtVenterScaleRight.Enabled=false;
			m_txtEXCEPTIONNOTE.Enabled=false;;
			m_txtDealNote.Enabled=false;
			m_txtSign.Enabled=false;
			m_txtHour.Enabled=false;
			
		}

		//处理宫口开事件
		private void m_thSetFormControlEnabled()
		{
			m_dtpFORECASTDATE.Enabled=true;
			m_txtPressureSystolicValue.Enabled=true;
			//m_dtmCHILDBIRTHDATE.Enabled=true;
			m_dtpRecordDateTime.Enabled=true;
			m_nmuEventHour.Enabled=true;
			m_nmuEventMinute.Enabled=true;
			m_txtVENTERPOINT.Enabled=true;
			m_txtScalePressure.Enabled=true;
			m_txtExtendPressure.Enabled=true;
			m_txtEMBRYOHEART.Enabled=true;
			m_txtVenterScaleLeft.Enabled=true;
			m_txtVenterScaleRight.Enabled=true;
			m_txtEXCEPTIONNOTE.Enabled=true;;
			m_txtDealNote.Enabled=true;
			m_txtSign.Enabled=true;
			m_txtHour.Enabled=true;
		}
		//界面清空
		private void m_thClearFormData()
		{
			m_txtPressureSystolicValue.Clear();
			m_nmuEventHour.Value=0;
			m_nmuEventMinute.Value=0;
			m_txtVENTERPOINT.Clear();
			m_txtScalePressure.Clear();
			m_txtExtendPressure.Clear();
			m_txtEMBRYOHEART.Clear();
			m_txtVenterScaleLeft.Clear();
			m_txtVenterScaleRight.Clear();
			m_txtEXCEPTIONNOTE.Clear();
			m_txtDealNote.Clear();
			m_txtHour.Clear();


			clsEmployeeSignTool.s_mthSetDefaulEmployee(m_txtSign);		

		}
		private string m_thSplitString(string p_strOriginal,out string p_strLast)
		{
			if(p_strOriginal==null || p_strOriginal=="")
			{
				p_strLast=null;
				return null;
			}

			//strTemp的文本的格式如:"A3|3" 如"3|3"系统会转换为2005-03-03 00:00:00状态在clsXML_SQL_Converter 
			string strTemp=p_strOriginal;
			bool bnlIsString=false;
			bnlIsString=strTemp.StartsWith("$");
			if(bnlIsString)
			{
				strTemp=strTemp.Substring(2,strTemp.Length -2);
			}

			strTemp=strTemp.Substring(1,strTemp.Length-1);
			string strPre=null;
			int intIndex=strTemp.IndexOf("|",0);
			if(intIndex>0)
			{
				strPre=strTemp.Substring(0,intIndex);
				p_strLast=strTemp.Substring(intIndex+1,strTemp.Length-intIndex-1);
				return strPre;
			}
			p_strLast=null;
			return null;
		}

		private void m_thSetDefalutValue()
		{
			//孕产次,预产期,默认四点等赋值,
			m_dtpFORECASTDATE.Value = m_objBornRecordManager.m_dtmFORECASTDATE.Date;//预产期
			m_txtPressureSystolicValue.Text = m_objBornRecordManager.m_strPREGNANCYNUM;//孕产次
			string strLast=null;
			m_txtFirstPointLeft.Text =m_thSplitString(m_objBornRecordManager.m_strFIRSTPOINT.Trim(),out strLast);//第一点
			m_txtFirstPointRight.Text =strLast;//第一点

			m_txtSecondPointLeft.Text = m_thSplitString(m_objBornRecordManager.m_strSECONDPOINT.Trim(),out strLast);//第二点
			m_txtSecondPointRight.Text =strLast;

			m_txtThreePointLeft.Text = m_thSplitString(m_objBornRecordManager.m_strTHREEPOINT.Trim(),out strLast);//第三点
			m_txtThreePointRight.Text  =strLast;

			m_txtFourPointLeft.Text =  m_thSplitString(m_objBornRecordManager.m_strFOUTPOINT.Trim(),out strLast);//第四点
			m_txtFourPointRight.Text = strLast;

			m_txtSign.Text= clsEMRLogin.LoginInfo.m_strEmpName;
			m_txtSign.Tag = clsEMRLogin.LoginInfo.m_strEmpNo;

			
		}


		//画点
		private void m_thEveryHour_Click(object sender,System.EventArgs e)
		{
			if(e !=null)
			{
					clsBornScheduleEveryHourEventArgs objArgs=(clsBornScheduleEveryHourEventArgs)e;
				clsBornScheduleEveryHourCol objEventValue= (clsBornScheduleEveryHourCol)objArgs.objArgsValue;
				
				string strTemp = "\r\n 分娩第:"+objEventValue.m_intHourValue.ToString()+"个小时\r\n是否修改或删除该值？ \r\n 值:"+objEventValue.m_intVenterValue.ToString()+"";

				if(DialogResult.Yes == clsPublicFunction.ShowQuestionMessageBox(strTemp))
				{
					m_thSetFormControl();
					groupbox1.Enabled=true;
					panel1.Enabled =true;
					m_txtVENTERPOINT.Enabled =true;
					m_txtHour.Enabled =false;
					//m_nmuEventHour.Enabled =false;

					m_txtVENTERPOINT.Text = objEventValue.m_intVenterValue.ToString();
					m_txtHour.Text = objEventValue.m_intHourValue.ToString();
					//m_nmuEventHour.Value = objEventValue.m_intHourValue;;  //分钟要不要处理
					m_dtpRecordDateTime.Value=m_objCurrentBornScheduleEveryDay.m_dtmRecordDate.Date; //记录日期
					m_thSetDefalutValue();

					m_intCurrentHour=objEventValue.m_intHourValue;
					m_strModifyItem="EveryHour"; //修改状态

				}

			}
		}

		//检查时间
		private void m_thCheckTime_Click(object sender,System.EventArgs e)
		{
			if(e !=null)
			{

				clsBornScheduleCheckTimeEventArgs objArgs=(clsBornScheduleCheckTimeEventArgs)e;
				clsCheckTimeCol objEventValue= (clsCheckTimeCol)objArgs.objArgsValue;
				
				string strTemp = "\r\n 分娩第:"+objEventValue.m_intHourValue.ToString()+"个小时\r\n是否修改或删除该值？ 值:"+objEventValue.m_strCheckTime.ToString()+"";

				if(DialogResult.Yes == clsPublicFunction.ShowQuestionMessageBox(strTemp))
				{
					
					
					//分割如11:23
					string strSlip=objEventValue.m_strCheckTime;
					int intIndex = strSlip.IndexOf(":",0,strSlip.Length);

					m_nmuEventHour.Value = Convert.ToInt32(strSlip.Substring(0,intIndex));
					m_nmuEventMinute.Value =  Convert.ToInt32(strSlip.Substring(intIndex+1,strSlip.Length-intIndex-1));

					m_thSetFormControl();
					groupbox1.Enabled=true;
					panel1.Enabled =true;
					m_nmuEventHour.Enabled =true;
					m_nmuEventMinute.Enabled =true;
					m_txtHour.Enabled =false;

					//m_nmuEventHour.Value = objEventValue.m_strCheckTime;
					m_intCurrentHour=objEventValue.m_intHourValue;
					m_txtHour.Text = objEventValue.m_intHourValue.ToString();
					//m_nmuEventMinute.Value = objEventValue.m_strCheckTime;
					m_dtpRecordDateTime.Value=m_objCurrentBornScheduleEveryDay.m_dtmRecordDate.Date; //记录日期
					m_thSetDefalutValue();

					m_strModifyItem="CheckTime"; //修改状态
				}

			}
		}

		//血压
		private void m_thBloodPressure_Click(object sender,System.EventArgs e)
		{
			if(e !=null)
			{
				clsBornScheduleBloodPressureEventArgs objArgs=(clsBornScheduleBloodPressureEventArgs)e;
				clsBloodPressureCol objEventValue= (clsBloodPressureCol)objArgs.objArgsValue;
				
				string strTemp = "\r\n 分娩第:"+objEventValue.m_intHourValue.ToString()+"个小时\r\n是否修改或删除该值？ 值:"+objEventValue.m_strScaleBloodPressureValue.ToString()+"/"+objEventValue.m_strExtendBloodPressureValue.ToString()+"";

				if(DialogResult.Yes == clsPublicFunction.ShowQuestionMessageBox(strTemp))
				{
					
					m_txtScalePressure.Text = objEventValue.m_strScaleBloodPressureValue;
					m_txtExtendPressure.Text =  objEventValue.m_strExtendBloodPressureValue; 
					m_thSetFormControl();
					groupbox1.Enabled=true;
					panel1.Enabled =true;
					m_txtScalePressure.Enabled =true;
					m_txtExtendPressure.Enabled =true;

					m_txtHour.Enabled =false;
					m_txtHour.Text = objEventValue.m_intHourValue.ToString();

					m_intCurrentHour=objEventValue.m_intHourValue;
					m_dtpRecordDateTime.Value=m_objCurrentBornScheduleEveryDay.m_dtmRecordDate.Date; //记录日期
					m_thSetDefalutValue();

					m_strModifyItem="BloodPressure"; //修改状态
				}

			}
		}


		//胎心
		private void m_thEmbryoHeart_Click(object sender,System.EventArgs e)
		{
			if(e !=null)
			{
				clsBornScheduleEmbryoHeartEventArgs objArgs=(clsBornScheduleEmbryoHeartEventArgs)e;
				clsEmbryoHeartCol objEventValue= (clsEmbryoHeartCol)objArgs.objArgsValue;
				
				string strTemp = "\r\n 分娩第:"+objEventValue.m_intHourValue.ToString()+"个小时\r\n是否修改或删除该值？ 值:"+objEventValue.m_strEmbryoHeartValue.ToString()+"";

				if(DialogResult.Yes == clsPublicFunction.ShowQuestionMessageBox(strTemp))
				{
					
					m_txtEMBRYOHEART.Text = objEventValue.m_strEmbryoHeartValue;

					m_thSetFormControl();
					groupbox1.Enabled=true;
					panel1.Enabled =true;
					m_txtEMBRYOHEART.Enabled =true;


					m_txtHour.Enabled =false;
					m_txtHour.Text = objEventValue.m_intHourValue.ToString();
					m_intCurrentHour=objEventValue.m_intHourValue;
					m_dtpRecordDateTime.Value=m_objCurrentBornScheduleEveryDay.m_dtmRecordDate.Date; //记录日期
					m_thSetDefalutValue();

					m_strModifyItem="EmbryoHeart"; //修改状态
				}

			}
		}


		//宫缩
		private void m_thVenterScaleExtend_Click(object sender,System.EventArgs e)
		{
			if(e !=null)
			{
				clsBornVenterScaleExtendEventArgs objArgs=(clsBornVenterScaleExtendEventArgs)e;
				clsVenterScaleExtendCol objEventValue= (clsVenterScaleExtendCol)objArgs.objArgsValue;
				
				string strTemp = "\r\n 分娩第:"+objEventValue.m_intHourValue.ToString()+"个小时\r\n是否修改或删除该值？ 值:"+objEventValue.m_strScaleVenterValue.ToString()+"/"+objEventValue.m_strExtendVenterValue.ToString()+"";

				if(DialogResult.Yes == clsPublicFunction.ShowQuestionMessageBox(strTemp))
				{
					
					m_txtVenterScaleLeft.Text = objEventValue.m_strScaleVenterValue;
					m_txtVenterScaleRight.Text = objEventValue.m_strExtendVenterValue;
					
					m_thSetFormControl();

					groupbox1.Enabled=true;
					panel1.Enabled =true;
					m_txtVenterScaleLeft.Enabled =true;
					m_txtVenterScaleRight.Enabled =true;

					m_txtHour.Enabled =false;
					m_txtHour.Text = objEventValue.m_intHourValue.ToString();

					m_intCurrentHour=objEventValue.m_intHourValue;
					m_dtpRecordDateTime.Value=m_objCurrentBornScheduleEveryDay.m_dtmRecordDate.Date; //记录日期
					m_thSetDefalutValue();

					m_strModifyItem="VenterScaleExtend"; //修改状态
				}

			}
		}

		//异常
		private void m_thExceptionNote_Click(object sender,System.EventArgs e)
		{
			if(e !=null)
			{
				clsBornScheduleExceptionNoteEventArgs objArgs=(clsBornScheduleExceptionNoteEventArgs)e;
				clsExceptionNoteCol objEventValue= (clsExceptionNoteCol)objArgs.objArgsValue;
				
				string strTemp = "\r\n 分娩第:"+objEventValue.m_intHourValue.ToString()+"个小时\r\n是否修改或删除该异常情况？";
				//string strTemp = ""+objEventValue.m_dtmModifyTime.ToString()+"\r\n是否修改或删除该值？ 值:"+objEventValue.m_strExceptionNoteValue.ToString()+"";

				if(DialogResult.Yes == clsPublicFunction.ShowQuestionMessageBox(strTemp))
				{
					
					m_txtEXCEPTIONNOTE.Text = objEventValue.m_strExceptionNoteValue;
					
					m_thSetFormControl();
					
					groupbox1.Enabled=true;
					panel1.Enabled =true;
					m_txtEXCEPTIONNOTE.Enabled =true;

					m_txtHour.Enabled =false;
					m_txtHour.Text = objEventValue.m_intHourValue.ToString();

					m_intCurrentHour=objEventValue.m_intHourValue;
					m_dtpRecordDateTime.Value=m_objCurrentBornScheduleEveryDay.m_dtmRecordDate.Date; //记录日期
					m_thSetDefalutValue();

					m_strModifyItem="ExceptionNote"; //修改状态
				}

			}
		}

		//处理记录
		private void m_thDealNote_Click(object sender,System.EventArgs e)
		{
			if(e !=null)
			{
				clsBornScheduleDealNoteEventArgs objArgs=(clsBornScheduleDealNoteEventArgs)e;
				
				clsDealNoteCol objEventValue= (clsDealNoteCol)objArgs.objArgsValue;
				string strTemp =  "\r\n 分娩第:"+objEventValue.m_intHourValue.ToString()+"个小时\r\n是否修改或删除该处理记录？";
				//string strTemp = ""+objEventValue.m_dtmModifyTime.ToString()+"\r\n是否修改或删除该值？ 值:"+objEventValue.m_strDealNoteValue.ToString()+"";

				if(DialogResult.Yes == clsPublicFunction.ShowQuestionMessageBox(strTemp))
				{
					
					m_txtDealNote.Text = objEventValue.m_strDealNoteValue;
					
					m_thSetFormControl();
					
					groupbox1.Enabled=true;
					panel1.Enabled =true;
					m_txtDealNote.Enabled =true;

					m_txtHour.Enabled =false;
					m_txtHour.Text = objEventValue.m_intHourValue.ToString();

					m_intCurrentHour=objEventValue.m_intHourValue;
					m_dtpRecordDateTime.Value=m_objCurrentBornScheduleEveryDay.m_dtmRecordDate.Date; //记录日期
					m_thSetDefalutValue();

					m_strModifyItem="DealNote"; //修改状态
				}

			}
		}


		//签名
		private void m_thSignName_Click(object sender,System.EventArgs e)
		{
			if(e !=null)
			{
				clsBornScheduleSignNameEventArgs objArgs=(clsBornScheduleSignNameEventArgs)e;
				clsSignNameCol objEventValue= (clsSignNameCol)objArgs.objArgsValue;
				string strLast=null;
				string strTemp = "\r\n 分娩第:"+objEventValue.m_intHourValue.ToString()+"个小时\r\n是否修改或删除该值？ 值:"+m_thSplitName(objEventValue.m_strSignNameID.Trim(),out strLast)+"";

				if(DialogResult.Yes == clsPublicFunction.ShowQuestionMessageBox(strTemp))
				{
					
					//m_txtSign.Text = objEventValue.m_strSignNameID;  //m_txtSign签名还需要处理
					
					m_txtSign.Text = m_thSplitName(objEventValue.m_strSignNameID.Trim(),out strLast);//第四点;  //m_txtSign签名还需要处理
					m_thSetFormControl();
					
					groupbox1.Enabled=true;
					panel1.Enabled =true;
					m_txtSign.Enabled =true;

					m_txtHour.Enabled =false;
					m_txtHour.Text = objEventValue.m_intHourValue.ToString();

					m_intCurrentHour=objEventValue.m_intHourValue;
					m_dtpRecordDateTime.Value=m_objCurrentBornScheduleEveryDay.m_dtmRecordDate.Date; //记录日期
					m_thSetDefalutValue();

					m_strModifyItem="SignName"; //修改状态
				}

			}
		}

	
			
		#endregion

		private string m_thSplitName(string p_strOriginal,out string p_strLast)
		{
			if(p_strOriginal==null || p_strOriginal=="")
			{
				p_strLast=null;
				return null;
			}

			//strTemp的文本的格式如:"A3|3" 如"3|3"系统会转换为2005-03-03 00:00:00状态在clsXML_SQL_Converter 
			string strTemp=p_strOriginal;
			strTemp=strTemp.Substring(0,strTemp.Length-1);
			string strPre=null;
			int intIndex=strTemp.IndexOf("|",0);
			if(intIndex>0)
			{
				strPre=strTemp.Substring(0,intIndex);
				p_strLast=strTemp.Substring(intIndex+1,strTemp.Length-intIndex-1);
				return strPre;
			}
			p_strLast=null;
			return null;
		}

		private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}

		#region   method
		public void Save()
		{
		
		}

		public void Print()
		{
			try
			{
				clsPatient objPatient = m_objGetCurrentPatient();
				if(objPatient==null)
				{
					MessageBox.Show("请先选择产妇","提示");
					return;
				}
				if(m_objCurrentBornScheduleEveryDay.m_arlBornScheduleEveryHourCol.Count<0)
				{
					MessageBox.Show("没有打印数据","提示");
					return;
				}
			}
			catch
			{
				MessageBox.Show("没有打印数据","提示");
				return;
			}
			m_lngPrint();
		}

		public void Copy()
		{
		
		}

		public void Display()
		{
		
		}

		private void lblSex_Click(object sender, System.EventArgs e)
		{
		
		}

		private void ctlBorderTextBox6_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		public void Cut()
		{
		
		}

		public void Paste()
		{
		
		}

		public void Undo()
		{
		
		}

		public void Redo()
		{
		
		}

		public void Verify()
		{
			
		}

		public void Delete()
		{
			m_lngDelete();
		}

		public void Display(string cardno, string sendcheckdate)
		{
		
		}

		protected override long m_lngSubAddNew()
		{	
			//m_strModifyItem=null; //修改状态
			//先判断这个产妇是否已有这一天记录
			if(m_objBornRecordManager ==null)
				return 0;
			bool bnlIsExistCurrentRecord=false;
			bool bnlIsNew=false;
			clsPatient objPatient = m_objGetCurrentPatient();
			//先用ListView中这一病人的记录日期与当前要记录的日期作判断
//			if(m_lsvRecordDate.Nodes.Count>0)
			bool bnlIsExitDate=false;
			for(int i=0;i<m_lsvRecordDate.Nodes.Count;i++)
			{
				if(DateTime.Parse(m_lsvRecordDate.Nodes[i].Text.Trim()).Date ==m_dtpRecordDateTime.Value.Date)
				{
					bnlIsExitDate=true;
					bnlIsNew=false;
					break;
				}
			}
			//new record
			if(!bnlIsExitDate)
			{
				bnlIsNew=true;
				bool bnlAddCol=false;
				m_intPageIndex=0;
				//先清空内存中的数据再添加新数据
				m_objBornRecordManager=new clsBornRecordManager();
				m_objCurrentBornScheduleEveryDay=(clsBornScheduleEveryDay)m_objBornRecordManager.m_objAddDayRecord(m_dtpRecordDateTime.Value.Date,out bnlAddCol); //NEW 当前为记录日期
				m_ctlRecord.m_clsBornRecordManager=m_objBornRecordManager;
				m_ctlRecord.m_clsCurrentDay=m_objCurrentBornScheduleEveryDay;
				
			}
			else
			{
				//先取数据库中的记录日期的数据
				

				clsBornRecordManager[] objBornRecordManagerArr;
				objBornRecordManagerArr=(clsBornRecordManager[])m_objBornScheduleDomain.m_GetPatientBornScheduleRecord(objPatient.m_StrInPatientID,objPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate,m_dtpRecordDateTime.Value.Date);//,out dtResult);

				//重新赋值
				if(objBornRecordManagerArr !=null && objBornRecordManagerArr.Length>0)
				{
					m_objBornRecordManager=objBornRecordManagerArr[0];

					//当前天记录
					//m_objCurrentBornScheduleEveryDay=(clsBornScheduleEveryDay)m_objBornRecordManager[DateTime.Parse(strTemp).Date];
				

					for(int i=0;i<m_objBornRecordManager.m_arlBornScheduleEveryDay.Count;i++)
					{
						clsBornScheduleEveryDay objBornScheduleEveryDay=(clsBornScheduleEveryDay)m_objBornRecordManager.m_arlBornScheduleEveryDay[i];
						if(objBornScheduleEveryDay.m_dtmRecordDate.ToString("yyyy-MM-dd")==m_dtpRecordDateTime.Value.ToString("yyyy-MM-dd"))
						{
					
							m_objCurrentBornScheduleEveryDay=objBornScheduleEveryDay;
							bnlIsExistCurrentRecord=true;
							m_intPageIndex=i;
							bnlIsNew=false;
							break;
						}
					}
				}
				
	
			}


			
			#region  界面取值
			
			//记录默认值及产期.
			DateTime dtCurrentTime= System.DateTime.Now;
			m_objBornRecordManager.m_dtmFORECASTDATE=m_dtpFORECASTDATE.Value ;//预产期
			if(bnlIsNew) //新增调clsXML_SQL_Converter转换数据库中存A3|3
			{
				m_objBornRecordManager.m_strPREGNANCYNUM=m_txtPressureSystolicValue.Text.Trim().Length>0 ? m_txtPressureSystolicValue.Text.Trim():null ;//孕产次
				m_objBornRecordManager.m_strFIRSTPOINT="$$A"+m_txtFirstPointLeft.Text.Trim()+"|"+m_txtFirstPointRight.Text.Trim();//第一点
				m_objBornRecordManager.m_strSECONDPOINT="$$A"+m_txtSecondPointLeft.Text.Trim()+"|"+m_txtSecondPointRight.Text.Trim();//第二点
				m_objBornRecordManager.m_strTHREEPOINT="$$A"+m_txtThreePointLeft.Text.Trim()+"|"+m_txtThreePointRight.Text.Trim();//第三点
				m_objBornRecordManager.m_strFOUTPOINT="$$A"+m_txtFourPointLeft.Text.Trim()+"|"+m_txtFourPointRight.Text.Trim();//第四点

			}
			else  //修改调XML2Update转换数据库中存A3|3
			{
				m_objBornRecordManager.m_strPREGNANCYNUM=m_txtPressureSystolicValue.Text.Trim().Length>0 ? m_txtPressureSystolicValue.Text.Trim():null ;//孕产次
				m_objBornRecordManager.m_strFIRSTPOINT="A"+m_txtFirstPointLeft.Text.Trim()+"|"+m_txtFirstPointRight.Text.Trim();//第一点
				m_objBornRecordManager.m_strSECONDPOINT="A"+m_txtSecondPointLeft.Text.Trim()+"|"+m_txtSecondPointRight.Text.Trim();//第二点
				m_objBornRecordManager.m_strTHREEPOINT="A"+m_txtThreePointLeft.Text.Trim()+"|"+m_txtThreePointRight.Text.Trim();//第三点
				m_objBornRecordManager.m_strFOUTPOINT="A"+m_txtFourPointLeft.Text.Trim()+"|"+m_txtFourPointRight.Text.Trim();//第四点

			}
			int intTimePoint=Convert.ToInt32(m_txtHour.Text.Trim());
			//新增状态
			if(m_strModifyItem==null)
			{
				
				//赋值,记录各时间点数据

				
				
				////每小时画点值集
				clsBornScheduleEveryHourCol objCurrentBornScheduleEveryHourCol=new clsBornScheduleEveryHourCol();
				objCurrentBornScheduleEveryHourCol.m_intHourValue =intTimePoint;
				objCurrentBornScheduleEveryHourCol.m_intVenterValue = int.Parse(m_txtVENTERPOINT.Text.Trim());
				objCurrentBornScheduleEveryHourCol.m_bnlIsHavePreValue =true;
				objCurrentBornScheduleEveryHourCol.m_strModifyUserID = clsEMRLogin.LoginInfo.m_strEmpNo;
				objCurrentBornScheduleEveryHourCol.m_dtmModifyTime =dtCurrentTime;
				objCurrentBornScheduleEveryHourCol.m_bnlIsDelete = false;

				//如果不存此值则插入,有则修改
				m_objCurrentBornScheduleEveryDay.m_thAddBornScheduleEveryHour(intTimePoint,objCurrentBornScheduleEveryHourCol);

				//检查时间
				clsCheckTimeCol objCheckTimeCol=new clsCheckTimeCol();
				objCheckTimeCol.m_intHourValue = intTimePoint;
				string strTime=null;
				strTime=m_nmuEventHour.Value.ToString()+":"+m_nmuEventMinute.Value.ToString();
				objCheckTimeCol.m_strCheckTime = strTime=="0:0"?null:strTime;
				objCheckTimeCol.m_dtmModifyTime = dtCurrentTime ;
				m_objCurrentBornScheduleEveryDay.m_thAddCheckTime(intTimePoint,objCheckTimeCol);
			
				//血压
				clsBloodPressureCol objBloodPressureCol=new clsBloodPressureCol();
				objBloodPressureCol.m_intHourValue = intTimePoint;
				objBloodPressureCol.m_strScaleBloodPressureValue = m_txtScalePressure.Text.Trim()==""? null:m_txtScalePressure.Text.Trim();
				objBloodPressureCol.m_strExtendBloodPressureValue = m_txtExtendPressure.Text.Trim()==""? null:m_txtExtendPressure.Text.Trim();
				objBloodPressureCol.m_dtmModifyTime = dtCurrentTime;
				m_objCurrentBornScheduleEveryDay.m_thAddBloodPressure(intTimePoint,objBloodPressureCol);

				//胎心集
				clsEmbryoHeartCol objEmbryoHeartCol=new clsEmbryoHeartCol();
				objEmbryoHeartCol.m_intHourValue = intTimePoint;
				objEmbryoHeartCol.m_strEmbryoHeartValue = m_txtEMBRYOHEART.Text.Trim()==""? null:m_txtEMBRYOHEART.Text.Trim();
				objEmbryoHeartCol.m_dtmModifyTime = dtCurrentTime;
				m_objCurrentBornScheduleEveryDay.m_thAddEmbryoHeart(intTimePoint,objEmbryoHeartCol);

				//宫缩集
				clsVenterScaleExtendCol objVenterScaleExtendCol=new clsVenterScaleExtendCol();
				objVenterScaleExtendCol.m_intHourValue = intTimePoint;
				objVenterScaleExtendCol.m_strScaleVenterValue = m_txtVenterScaleLeft.Text.Trim()==""? null:m_txtVenterScaleLeft.Text.Trim();
				objVenterScaleExtendCol.m_strExtendVenterValue = m_txtVenterScaleRight.Text.Trim()==""? null:m_txtVenterScaleRight.Text.Trim();
				objVenterScaleExtendCol.m_dtmModifyTime = dtCurrentTime;
				m_objCurrentBornScheduleEveryDay.m_thAddVenterScaleExtend(intTimePoint,objVenterScaleExtendCol);

				//异常情况集
				clsExceptionNoteCol objExceptionNoteCol=new clsExceptionNoteCol();
				objExceptionNoteCol.m_intHourValue = intTimePoint;
				objExceptionNoteCol.m_strExceptionNoteValue = m_txtEXCEPTIONNOTE.Text.Trim()==""? null:m_txtEXCEPTIONNOTE.Text.Trim();
				objExceptionNoteCol.m_dtmModifyTime = dtCurrentTime;
				m_objCurrentBornScheduleEveryDay.m_thAddExceptionNote(intTimePoint,objExceptionNoteCol);

				//处理记录集
				clsDealNoteCol objDealNoteCol=new clsDealNoteCol();
				objDealNoteCol.m_intHourValue = intTimePoint;
				objDealNoteCol.m_strDealNoteValue = m_txtDealNote.Text.Trim()==""? null:m_txtDealNote.Text.Trim();
				objDealNoteCol.m_dtmModifyTime = dtCurrentTime;
				m_objCurrentBornScheduleEveryDay.m_thAddDealNote(intTimePoint,objDealNoteCol);

				//签名集
				clsSignNameCol objSignNameCol=new clsSignNameCol();
				objSignNameCol.m_intHourValue = intTimePoint;
				if(m_txtSign.Tag!=null && m_txtSign.Text.Trim()!="")
				{
					objSignNameCol.m_strSignNameID=m_txtSign.Text.Trim()+"|"+m_txtSign.Tag.ToString();
					
				}
				//objSignNameCol.m_strSignNameID = "0972";// ((clsEmployee)m_txtSign.Tag).m_StrEmployeeID; //签名
				objSignNameCol.m_dtmModifyTime = dtCurrentTime;
				m_objCurrentBornScheduleEveryDay.m_thAddSignName(intTimePoint,objSignNameCol);

			}
				//修改状态
			else
			{
				if(m_strModifyItem=="EveryHour")
				{
					clsBornScheduleEveryHourCol objCurrentBornScheduleEveryHourCol=new clsBornScheduleEveryHourCol();
					objCurrentBornScheduleEveryHourCol.m_intHourValue =intTimePoint;//m_intCurrentHour;
					objCurrentBornScheduleEveryHourCol.m_intVenterValue = int.Parse(m_txtVENTERPOINT.Text.Trim());
					objCurrentBornScheduleEveryHourCol.m_bnlIsHavePreValue =true;
					objCurrentBornScheduleEveryHourCol.m_strModifyUserID = clsEMRLogin.LoginInfo.m_strEmpNo;
					objCurrentBornScheduleEveryHourCol.m_dtmModifyTime =dtCurrentTime;
					objCurrentBornScheduleEveryHourCol.m_bnlIsDelete = false;
					m_objCurrentBornScheduleEveryDay.m_thAddBornScheduleEveryHour(m_intCurrentHour,objCurrentBornScheduleEveryHourCol);
				}
				else if(m_strModifyItem=="CheckTime")
				{
					clsCheckTimeCol objCheckTimeCol=new clsCheckTimeCol();
					string strTime=null;
					strTime=m_nmuEventHour.Value.ToString()+":"+m_nmuEventMinute.Value.ToString();
					objCheckTimeCol.m_strCheckTime = strTime=="0:0"?null:strTime;

					objCheckTimeCol.m_intHourValue = m_intCurrentHour;
					
					objCheckTimeCol.m_dtmModifyTime = dtCurrentTime ;
					m_objCurrentBornScheduleEveryDay.m_thAddCheckTime(m_intCurrentHour,objCheckTimeCol);
				}
				else if(m_strModifyItem=="BloodPressure")
				{
					clsBloodPressureCol objBloodPressureCol=new clsBloodPressureCol();
					objBloodPressureCol.m_intHourValue = m_intCurrentHour;
					objBloodPressureCol.m_strScaleBloodPressureValue = m_txtScalePressure.Text.Trim()==""? null:m_txtScalePressure.Text.Trim();
					objBloodPressureCol.m_strExtendBloodPressureValue = m_txtExtendPressure.Text.Trim()==""? null:m_txtExtendPressure.Text.Trim();
					objBloodPressureCol.m_dtmModifyTime = dtCurrentTime;
					m_objCurrentBornScheduleEveryDay.m_thAddBloodPressure(m_intCurrentHour,objBloodPressureCol);
				}
				else if(m_strModifyItem=="EmbryoHeart")
				{
					clsEmbryoHeartCol objEmbryoHeartCol=new clsEmbryoHeartCol();
					objEmbryoHeartCol.m_intHourValue = m_intCurrentHour;
					objEmbryoHeartCol.m_strEmbryoHeartValue = m_txtEMBRYOHEART.Text.Trim()==""? null:m_txtEMBRYOHEART.Text.Trim();
					objEmbryoHeartCol.m_dtmModifyTime = dtCurrentTime;
					m_objCurrentBornScheduleEveryDay.m_thAddEmbryoHeart(m_intCurrentHour,objEmbryoHeartCol);
				}
				else if(m_strModifyItem=="VenterScaleExtend")
				{
					clsVenterScaleExtendCol objVenterScaleExtendCol=new clsVenterScaleExtendCol();
					objVenterScaleExtendCol.m_intHourValue = m_intCurrentHour;
					objVenterScaleExtendCol.m_strScaleVenterValue = m_txtVenterScaleLeft.Text.Trim()==""? null:m_txtVenterScaleLeft.Text.Trim();
					objVenterScaleExtendCol.m_strExtendVenterValue = m_txtVenterScaleRight.Text.Trim()==""? null:m_txtVenterScaleRight.Text.Trim();
					objVenterScaleExtendCol.m_dtmModifyTime = dtCurrentTime;
					m_objCurrentBornScheduleEveryDay.m_thAddVenterScaleExtend(m_intCurrentHour,objVenterScaleExtendCol);
				}
				else if(m_strModifyItem=="ExceptionNote")
				{

					clsExceptionNoteCol objExceptionNoteCol=new clsExceptionNoteCol();
					objExceptionNoteCol.m_intHourValue = m_intCurrentHour;
					objExceptionNoteCol.m_strExceptionNoteValue = m_txtEXCEPTIONNOTE.Text.Trim()==""? null:m_txtEXCEPTIONNOTE.Text.Trim();
					objExceptionNoteCol.m_dtmModifyTime = dtCurrentTime;
					m_objCurrentBornScheduleEveryDay.m_thAddExceptionNote(m_intCurrentHour,objExceptionNoteCol);
				}
				else if(m_strModifyItem=="DealNote")
				{
					clsDealNoteCol objDealNoteCol=new clsDealNoteCol();
					objDealNoteCol.m_intHourValue = m_intCurrentHour;
					objDealNoteCol.m_strDealNoteValue = m_txtDealNote.Text.Trim()==""? null:m_txtDealNote.Text.Trim();
					objDealNoteCol.m_dtmModifyTime = dtCurrentTime;
					m_objCurrentBornScheduleEveryDay.m_thAddDealNote(m_intCurrentHour,objDealNoteCol);
				}
				else if(m_strModifyItem=="SignName")
				{
					clsSignNameCol objSignNameCol=new clsSignNameCol();
					objSignNameCol.m_intHourValue = m_intCurrentHour;
					objSignNameCol.m_strSignNameID = m_txtSign.Text.Trim()+"|"+m_txtSign.Tag.ToString();// ((clsEmployee)m_txtSign.Tag).m_StrEmployeeID; //签名
					objSignNameCol.m_dtmModifyTime = dtCurrentTime;
					m_objCurrentBornScheduleEveryDay.m_thAddSignName(m_intCurrentHour,objSignNameCol);
				}
			}

			#endregion

			
			//clsBornRecordManager生成XML格式,及保存到clsBornScheduleRecordInfo类中
			//clsPatient objPatient =  m_objGetCurrentPatient();
			DateTime dtmOpenTime=m_dtpRecordDateTime.Value.Date;
			long lngResult=m_objBornScheduleDomain.m_bnlMainXml(m_objBornRecordManager,m_intPageIndex,objPatient.m_StrInPatientID,objPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate,dtmOpenTime,clsEMRLogin.LoginInfo.m_strEmpNo,m_dtpRecordDateTime.Value,m_dtpFORECASTDATE.Value,m_txtPressureSystolicValue.Text.Trim(),bnlIsNew);
			if(lngResult<=0)
			{
				MessageBox.Show("保存失败!,提示");
				return 0;
				
			}
			m_strModifyItem=null;//更改状态

			//重置控件状态
			m_thClearFormData();

			m_thSetFormControlEnabled();//控件可用

			//更新成功更改时间树的显示
			if(bnlIsNew)
			m_lsvRecordDate.Nodes.Add(m_dtpRecordDateTime.Value.ToString());

			//更新显示
			RefreshControl(m_objBornRecordManager,m_objCurrentBornScheduleEveryDay);
			//保存成功更新图形界面显示.

			return 1;

			
		}


		#endregion

		//保存按钮
		private void m_cmdSave_Click(object sender, System.EventArgs e)
		{
			//校验
			if(m_bnlFormCheck())
			m_lngSave();
		}

		#region  界面有效值校验
		
		private bool m_bnlFormCheck()
		{
			int intValue=0;
			clsPatient objPatient =  m_objGetCurrentPatient();
			bool bnlIsPass=false;
			if(objPatient == null)
			{
				m_bnlPopInformation("请先选择病人",m_lsvBedNO);
				return bnlIsPass;
			}
			if(m_txtHour.Text.Trim().Length <=0)
			{
				m_bnlPopInformation("请输入分娩第几小时值",m_txtHour);
				return bnlIsPass;
			}
			try
				{
					intValue=Convert.ToInt32(m_txtHour.Text.Trim());
					if(intValue>24 || intValue <0)
					{
						m_bnlPopInformation("分娩第几小时值,不在0与24之间",m_txtHour);
						return bnlIsPass;
					}
				}
				catch
				{
					m_bnlPopInformation("分娩第几小时值,不在0与24之间",m_txtHour);
					return bnlIsPass;
				}

			int intTemp=0;
			
			Control conTemp=new Control();
			
			try
			{
				if(m_nmuEventHour.Value>0)
				{
					intTemp=Convert.ToInt32(m_nmuEventHour.Value);
					if(intTemp>24 || intTemp <0)
					{
						m_bnlPopInformation("检查时间不在0与24小时之间",m_nmuEventHour);
						return bnlIsPass;
					}
				}
			}
			catch
			{
				m_bnlPopInformation("检查时间不在0与24小时之间",m_nmuEventHour);
				return bnlIsPass;
			}

			try
			{
				if(m_nmuEventMinute.Value>0)
				{
					intTemp=Convert.ToInt32(m_nmuEventMinute.Value);
					if(intTemp>60 || intTemp <0)
					{
						m_bnlPopInformation("检查分钟不在0与60小时之间",m_nmuEventMinute);
						return bnlIsPass;
					}
				}
			}
			catch
			{
				m_bnlPopInformation("检查分钟不在0与60小时之间",m_nmuEventMinute);
				return bnlIsPass;
			}
			
			if(m_strModifyItem=="EveryHour")
			{
				try
				{
					intValue=Convert.ToInt32(m_txtHour.Text.Trim());
					if(intValue>24 || intValue <0)
					{
						m_bnlPopInformation("分娩第几小时值,不在0与24之间",m_txtHour);
						return bnlIsPass;
					}
				}
				catch
				{
					m_bnlPopInformation("分娩第几小时值,不在0与24之间",m_txtHour);
					return bnlIsPass;
				}
			}
			if(m_strModifyItem==null) //修改不用校验
			{
				

				try
				{
					intTemp=Convert.ToInt32(m_txtVENTERPOINT.Text.Trim());
					if(intTemp>10 || intTemp <0)
					{
						m_bnlPopInformation("宫口开厘米值不在0与10之间",m_txtVENTERPOINT);
						return bnlIsPass;
					}
				}
				catch
				{
					m_bnlPopInformation("请输入有效宫口开厘米值",m_txtVENTERPOINT);
					return bnlIsPass;
				}
			}
				
			if(m_txtVENTERPOINT.Text.Trim().Length<=0)
				m_txtVENTERPOINT.Text="";


			try
			{
				//first
				if(m_txtFirstPointLeft.Text.Trim().Length<=0)
					m_txtFirstPointLeft.Text="0";
				else
				{
					conTemp=(Control)m_txtFirstPointLeft;
					intTemp=Convert.ToInt32(m_txtFirstPointLeft.Text.Trim());
					if(intTemp>24 || intTemp <0)
					{
						m_bnlPopInformation("默认第一条线的第一点值不在0与24之间",conTemp);
						return bnlIsPass;
					}
				}

				if(m_txtFirstPointRight.Text.Trim().Length<=0)
					m_txtFirstPointRight.Text="0";
				else
				{
					conTemp=(Control)m_txtFirstPointRight;
					intTemp=Convert.ToInt32(m_txtFirstPointRight.Text.Trim());
					if(intTemp>10 || intTemp <0)
					{
						m_bnlPopInformation("默认第一条线的第一点值不在0与10之间",conTemp);
						return bnlIsPass;
					}
				}
				//second
				if(m_txtSecondPointLeft.Text.Trim().Length<=0)
					m_txtSecondPointLeft.Text="0";
				else
				{
					conTemp=(Control)m_txtSecondPointLeft;
					intTemp=Convert.ToInt32(m_txtSecondPointLeft.Text.Trim());
					if(intTemp>24 || intTemp <0)
					{
						m_bnlPopInformation("默认第一条线的第一点值不在0与24之间",conTemp);
						return bnlIsPass;
					}
				}


				if(m_txtSecondPointRight.Text.Trim().Length<=0)
					m_txtSecondPointRight.Text="0";
				else
				{
					conTemp=(Control)m_txtSecondPointRight;
					intTemp=Convert.ToInt32(m_txtSecondPointRight.Text.Trim());
					if(intTemp>10 || intTemp <0)
					{
						m_bnlPopInformation("默认第一条线的第一点值不在0与10之间",conTemp);
						return bnlIsPass;
					}
				}

				//three
				if(m_txtThreePointLeft.Text.Trim().Length<=0)
					m_txtThreePointLeft.Text="0";
				else
				{
					conTemp=(Control)m_txtThreePointLeft;
					intTemp=Convert.ToInt32(m_txtThreePointLeft.Text.Trim());
					if(intTemp>24 || intTemp <0)
					{
						m_bnlPopInformation("默认第一条线的第一点值不在0与24之间",conTemp);
						return bnlIsPass;
					}
				}

				if(m_txtThreePointRight.Text.Trim().Length<=0)
					m_txtThreePointRight.Text="0";
				else
				{
					conTemp=(Control)m_txtThreePointRight;
					intTemp=Convert.ToInt32(m_txtThreePointRight.Text.Trim());
					if(intTemp>10 || intTemp <0)
					{
						m_bnlPopInformation("默认第一条线的第二点值不在0与10之间",conTemp);
						return bnlIsPass;
					}
				}

				//four
				if(m_txtFourPointLeft.Text.Trim().Length<=0)
					m_txtFourPointLeft.Text="0";
				else
				{
					conTemp=(Control)m_txtFourPointLeft;
					intTemp=Convert.ToInt32(m_txtFourPointLeft.Text.Trim());
					if(intTemp>24 || intTemp <0)
					{
						m_bnlPopInformation("默认第二条线的第一点值不在0与24之间",conTemp);
						return bnlIsPass;
					}
				}

				if(m_txtFourPointRight.Text.Trim().Length<=0)
					m_txtFourPointRight.Text="0";
				else
				{
					conTemp=(Control)m_txtFourPointRight;
					intTemp=Convert.ToInt32(m_txtFourPointRight.Text.Trim());
					if(intTemp>10 || intTemp <0)
					{
						m_bnlPopInformation("默认第二条线的第二点值不在0与10之间",conTemp);
						return bnlIsPass;
					}
				}
			}
			catch(Exception ex)
			{
				ex.ToString();
				m_bnlPopInformation("请输入有效数据值",conTemp);
			}

				return true;
		}

		#endregion

		//提示出错信息并返回
		private void m_bnlPopInformation(string p_strTitle,System.Windows.Forms.Control p_objControl)
		{
			MessageBox.Show(p_strTitle,"提示");
			p_objControl.Focus();
			

		}

		private void frmBornScheduleRecord_Load(object sender, System.EventArgs e)
		{
			//添加事件
			AddControlEventBind();

			clsPatient objPatient =m_objGetCurrentPatient();
			if(objPatient!=null)
			m_mthSetPatientFormInfo(objPatient);
			

		}

		//不再提示保存
		protected override void m_mthAddFormStatusForClosingSave()
		{
		}
		/// <summary>
		/// 屏蔽打印前提示保存
		/// </summary>
		protected override DialogResult m_dlgHandleSaveBeforePrint()
		{
			return DialogResult.None;
		}

        protected bool m_blnCanShowDiseaseTrack = true;
		//获取记录
		private void m_lsvRecordDate_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			string strTemp=e.Node.Text.Trim();

			if(strTemp ==null)
				return;
			
			DataTable dtResult=new DataTable();
			clsPatient objPatient = m_objGetCurrentPatient();

            if (!m_blnCanShowDiseaseTrack)
            {
                clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                return;
            }

//			m_thSetFormControlEnabled(); //重置控件状态
//			
//			m_thClearFormData();


			clsBornRecordManager[] objBornRecordManagerArr;
			objBornRecordManagerArr=(clsBornRecordManager[])m_objBornScheduleDomain.m_GetPatientBornScheduleRecord(objPatient.m_StrInPatientID,objPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate,DateTime.Parse(strTemp).Date);//,out dtResult);

			//控件重绘
			
			if(objBornRecordManagerArr !=null && objBornRecordManagerArr.Length>0)
			{
				m_objBornRecordManager=objBornRecordManagerArr[0];
				m_objCurrentBornScheduleEveryDay=(clsBornScheduleEveryDay)m_objBornRecordManager[DateTime.Parse(strTemp).Date];
				RefreshControl(m_objBornRecordManager,m_objCurrentBornScheduleEveryDay); //默认取第一天的记录

				//孕产次,预产期,默认四点等赋值,
				m_thSetDefalutValue();

			}
			else
			{
				m_objBornRecordManager=new clsBornRecordManager();
				m_objCurrentBornScheduleEveryDay=new clsBornScheduleEveryDay(m_dtpRecordDateTime.Value.Date);
				RefreshControl(m_objBornRecordManager,m_objCurrentBornScheduleEveryDay);
			}
			
		}

		//更新控件显示
		private void RefreshControl(clsBornRecordManager p_objRecord,clsBornScheduleEveryDay p_objCurrentDay)
		{
			m_ctlRecord.m_clsBornRecordManager=p_objRecord;
			m_ctlRecord.m_clsCurrentDay=p_objCurrentDay;
			m_ctlRecord.Invalidate();
			m_ctlRecord.Refresh();
		}


		protected override void m_mthSetPatientFormInfo(clsPatient p_objSelectedPatient)
		{
			//添加分娩记录日期到树
			//m_lsvRecordDate
			clsPatient objPatient =m_objGetCurrentPatient();// (clsPatient)m_lsvBedNO.SelectedItems[0].Tag;
			DataTable dtbResult=new DataTable();
			long  m_lngRes=m_objBornScheduleDomain.m_GetPatientRecordDate(objPatient.m_StrInPatientID,objPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate,out dtbResult);
		
			//clear node
			m_lsvRecordDate.Nodes.Clear();

			m_thSetFormControlEnabled(); //重置控件状态
			
			m_thClearFormData();

			if(m_lngRes>0)
			{
				if(dtbResult !=null)
				{
					if(dtbResult.Rows.Count>0)
					{
						for(int i=0;i<dtbResult.Rows.Count;i++)
						{
							m_lsvRecordDate.Nodes.Add(DateTime.Parse(dtbResult.Rows[i][0].ToString()).ToString("yyyy-MM-dd"));
                        }

                        m_mthIsReadOnly();

                        m_blnCanShowDiseaseTrack = m_blnCanShowRecordContent();
						//选择节点引发界面赋值
						m_lsvRecordDate.SelectedNode=m_lsvRecordDate.Nodes[0];

					}
						//另外一个产妇没有数据时,清空控件显示
					else
					{
						m_objBornRecordManager=new clsBornRecordManager();
						m_objCurrentBornScheduleEveryDay=new clsBornScheduleEveryDay(m_dtpRecordDateTime.Value.Date);
						RefreshControl(m_objBornRecordManager,m_objCurrentBornScheduleEveryDay);
						//没有数据时清空界面显示
						//孕产次,预产期,默认四点等赋值,
						m_dtpFORECASTDATE.Value =System.DateTime.Now ;//预产期
						m_txtPressureSystolicValue.Clear();//孕产次
						m_txtFirstPointLeft.Text="3";//第一点
						m_txtFirstPointRight.Text="3";//第一点

						m_txtSecondPointLeft.Text="9";//第二点
						m_txtSecondPointRight.Text="10";

						m_txtThreePointLeft.Text="7";//第三点
						m_txtThreePointRight.Text="3";

						m_txtFourPointLeft.Text="13";//第四点
						m_txtFourPointRight.Text="10";

						m_txtSign.Text= clsEMRLogin.LoginInfo.m_strEmpName;
						m_txtSign.Tag = clsEMRLogin.LoginInfo.m_strEmpNo;
                        m_mthIsReadOnly();
					}
				}
				
			}
				
			m_strModifyItem=null; //修改状态

			

		}

		private clsPatient m_objGetCurrentPatient()
		{
			clsPatient objPatient=null;
			try
			{
				objPatient= (clsPatient)MDIParent.s_ObjCurrentPatient;
			}
			catch
			{
			
				objPatient=null;
				
			}
//			if(objPatient==null)
//			{
//				try
//				{
//					objPatient = (clsPatient)m_lsvBedNO.SelectedItems[0].Tag;
//				}
//				catch
//				{
//					objPatient=null;
//				}
//			}
			
			try
			{
				objPatient = (clsPatient)m_lsvBedNO.SelectedItems[0].Tag;
			}
			catch
			{
				
			}

			return objPatient;
		}
		private void lblAgeTitle_DoubleClick(object sender, System.EventArgs e)
		{
			
		}

		private void m_cmdDelete_Click(object sender, System.EventArgs e)
		{
			//删除当前选中的记录
			if(m_strModifyItem=="EveryHour")
				m_objCurrentBornScheduleEveryDay.m_thRemoveBornScheduleEveryHour(m_intCurrentHour);
			else if(m_strModifyItem=="CheckTime")
				m_objCurrentBornScheduleEveryDay.m_thRemoveCheckTime(m_intCurrentHour);
			else if(m_strModifyItem=="BloodPressure")
				m_objCurrentBornScheduleEveryDay.m_thRemoveBloodPressure(m_intCurrentHour);
			else if(m_strModifyItem=="EmbryoHeart")
				m_objCurrentBornScheduleEveryDay.m_thRemoveEmbryoHeart(m_intCurrentHour);
			else if(m_strModifyItem=="VenterScaleExtend")
				m_objCurrentBornScheduleEveryDay.m_thRemoveVenterScaleExtend(m_intCurrentHour);
			else if(m_strModifyItem=="ExceptionNote")
				m_objCurrentBornScheduleEveryDay.m_thRemoveExceptionNote(m_intCurrentHour);
			else if(m_strModifyItem=="DealNote")
				m_objCurrentBornScheduleEveryDay.m_thRemovemDealNote(m_intCurrentHour);
			else if(m_strModifyItem=="SignName")
				m_objCurrentBornScheduleEveryDay.m_thRemoveSignName(m_intCurrentHour);

			//保存记录
			clsPatient objPatient =  m_objGetCurrentPatient();

			DateTime dtmOpenTime=m_dtpRecordDateTime.Value.Date;
			bool bnlIsNew=false;
			long lngResult=m_objBornScheduleDomain.m_bnlMainXml(m_objBornRecordManager,m_intPageIndex,objPatient.m_StrInPatientID,objPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate,dtmOpenTime,clsEMRLogin.LoginInfo.m_strEmpNo,m_dtpRecordDateTime.Value,m_dtpFORECASTDATE.Value,m_txtPressureSystolicValue.Text.Trim(),bnlIsNew);
			if(lngResult<=0)
			{
				MessageBox.Show("保存失败!,提示");
				return ;
				
			}

			//重置控件状态
			m_thClearFormData();

			m_thSetFormControlEnabled(); //重置控件状态
			
			//保存成功更新图形界面显示.
			RefreshControl(m_objBornRecordManager,m_objCurrentBornScheduleEveryDay);
			

		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			//平行线的默认值
			//first
			m_txtFirstPointLeft.Text="3";
			m_txtFirstPointRight.Text="3";

			//second
			m_txtSecondPointLeft.Text="9";
			m_txtSecondPointRight.Text="10";

			//three
			m_txtThreePointLeft.Text="7";
			m_txtThreePointRight.Text="3";

			//four
			m_txtFourPointLeft.Text="13";
			m_txtFourPointRight.Text="10";

		}

		#region 外部打印 续打.	
						
		//				System.Drawing.Printing.PrintDocument m_pdtPrintDocument;
		protected infPrintRecord objPrintTool;
				
		/// <summary>
		/// 打印记录
		/// </summary>
		/// <returns></returns>
		protected override long m_lngSubPrint()//代替原窗体中的同名打印函数
		{				
			m_mthDemoPrint_FromDataSource();				
			return 1;
					
		}
				
		//clsIntensiveTendMainPrintTool objPrintTool;
		private void m_mthDemoPrint_FromDataSource()
		{	
			objPrintTool=new iCare.clsBornSchedulePrintTool();
			if(objPrintTool==null)
			{
				clsPublicFunction.ShowInformationMessageBox("请重载m_objGetPrintTool()函数！");
				return;
			}
			//objPrintTool.m_mthInitPrintTool(null);	
			if(m_objBaseCurrentPatient==null )
				objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient,System.DateTime.Now ,System.DateTime.Now);
			else 
				objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient,System.DateTime.Now,System.DateTime.Now);
					
			ArrayList arlPrintContent= new ArrayList();
			arlPrintContent.Add(m_objBornRecordManager);
			arlPrintContent.Add(m_objCurrentBornScheduleEveryDay);
			objPrintTool.m_mthSetPrintContent((object)arlPrintContent);
			objPrintTool.m_mthInitPrintContent();						
						
			m_mthStartPrint();
		}
		
		private void m_mthStartPrint()
		{		
			
			if(m_blnDirectPrint)
			{
				m_pdcPrintDocument.Print();
			}
			else
			{
				((iCare.clsBornSchedulePrintTool)objPrintTool).m_mthPrintPage();
			}
		}

	
		#endregion 外部打印.

		#region 在外部测试本打印的演示实例.	
				
		System.Drawing.Printing.PrintDocument m_pdcPrintDocument;
		private void m_mthfrmLoad()
		{	
			this.m_pdcPrintDocument = new System.Drawing.Printing.PrintDocument();
			this.m_pdcPrintDocument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcPrintDocument_BeginPrint);
			this.m_pdcPrintDocument.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcPrintDocument_EndPrint);
			this.m_pdcPrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.m_pdcPrintDocument_PrintPage);		
		}
		private void m_pdcPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{			
			objPrintTool.m_mthPrintPage(e);

			//			if(ppdPrintPreview != null)
			//				while(!ppdPrintPreview.m_blnHandlePrint(e))
			//					objPrintTool.m_mthPrintPage(e);
		}
		
		private void m_pdcPrintDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			objPrintTool.m_mthBeginPrint(e);				
		}
		
		private void m_pdcPrintDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			objPrintTool.m_mthEndPrint(e);
		}
		
		#endregion 在外部测试本打印的演示实例.

		private void m_lsvEmployee_DoubleClick(object sender, System.EventArgs e)
		{
			/*
				 * 选择了医生后，在相应的输入框显示姓名，在输入框的Tag保存医生信息
				 */
			if(m_lsvEmployee.SelectedItems.Count <= 0)
				return;

			clsEmployee objEmp = (clsEmployee)m_lsvEmployee.SelectedItems[0].Tag;

			if(objEmp == null)
				return;	

//			if(!m_blnCheckEmployeeSign(objEmp.m_StrEmployeeID,objEmp.m_StrLastName))
//				return;

			m_lsvEmployee.Visible = false;
			m_lsvEmployee.Text=objEmp.m_StrLastName;
			m_lsvEmployee.Tag= objEmp.m_StrEmployeeID;
			m_lsvEmployee.Focus();
		}

		private void m_lsvEmployee_LostFocus(object sender, System.EventArgs e)
		{
			if(!m_txtSign.Focused && !m_lsvEmployee.Focused)
			{
				m_lsvEmployee.Visible=false;				
			}	
		}

		
		/// <summary>
		/// 显示医生列表
		/// </summary>
		/// <param name="p_strDoctorNameLike">医生号</param>
		private void m_mthGetDoctorList(string p_strDoctorNameLike)
		{
			
			/*
			 * 获取所有医生号和姓名，根据输入医生号的控件标志（m_bytListOnDoctor）,
			 * 在相应的位置显示ListView。
			 */			

			if(p_strDoctorNameLike.Length == 0)
			{
				m_lsvEmployee.Visible = false;
				return;
			}

			clsEmployee [] objDoctorArr = m_objCurrentContext.m_ObjEmployeeManager.m_objGetEmployeeIDLikeArr(p_strDoctorNameLike,m_objCurrentContext.m_ObjDepartment);

			if(objDoctorArr == null)
			{
				m_lsvEmployee.Visible = false;
				return;
			}

			m_lsvEmployee.Items.Clear();

			for(int i=0;i<objDoctorArr.Length;i++)
			{
				ListViewItem lviDoctor = new ListViewItem(
					new string[]{
									objDoctorArr[i].m_StrEmployeeID,
									objDoctorArr[i].m_StrFirstName
								});
				lviDoctor.Tag = objDoctorArr[i];

				m_lsvEmployee.Items.Add(lviDoctor);
			}

			m_mthChangeListViewLastColumnWidth(m_lsvEmployee);
			m_lsvEmployee.BringToFront();
			m_lsvEmployee.Visible = true;
		}

		#region 医师签名		
		private void m_mthEvent_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch(e.KeyValue)
			{
				case 13:// enter					
					if(((Control)sender).Name=="m_txtSign")
					{						
						m_mthGetDoctorList(m_txtSign.Text);

						if(m_lsvEmployee.Items.Count==1 && (m_txtSign.Text==m_lsvEmployee.Items[0].SubItems[0].Text|| m_txtSign.Text==m_lsvEmployee.Items[0].SubItems[1].Text))
						{
							m_lsvEmployee.Items[0].Selected=true;
							m_lsvEmployee_DoubleClick(null,null);
							break;
						}
					}					
					else if(((Control)sender).Name=="m_lsvEmployee")
					{
						m_lsvEmployee_DoubleClick(null,null);		
					}

					break;

				case 38:
				case 40:
					if(((Control)sender).Name=="m_txtSign")
					{
						if(m_txtSign.Text.Length>0)
						{	
							if(m_lsvEmployee.Visible==false || m_lsvEmployee.Items.Count==0)
							{								
								m_mthGetDoctorList(m_txtSign.Text);
							}

							m_lsvEmployee.BringToFront();
							m_lsvEmployee.Visible=true;
							m_lsvEmployee.Focus();
							if( m_lsvEmployee.Items.Count>0)
							{
								m_lsvEmployee.Items[0].Selected=true;
								m_lsvEmployee.Items[0].Focused=true;
							}	
						}
					}					
					break;				
			}	
		}
		#endregion

	
	}
}
