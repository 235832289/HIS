using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.BIHOrder
{
	/// <summary>
	/// 查看医嘱	界面表示层
	/// 作者： 徐斌辉
	/// 创建时间： 2005-02-22 
	/// </summary>
	public class frmSearchOrderInfo : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		#region 控件申明
		private System.Windows.Forms.Panel panel1;
		internal System.Windows.Forms.TextBox m_txtInHospitalDate;
		internal System.Windows.Forms.TextBox m_txtInDays;
		internal System.Windows.Forms.TextBox m_txtPayType;
		internal System.Windows.Forms.TextBox m_txtName;
		internal System.Windows.Forms.TextBox m_txtSex;
		internal com.digitalwave.iCare.BIHOrder.Control.ctlFindTextBox m_txtInHospitalNo;
		internal com.digitalwave.iCare.BIHOrder.Control.ctlFindTextBox m_txtArea;
		internal System.Windows.Forms.TextBox m_txtDiagnose;
		internal System.Windows.Forms.TextBox m_txtPrePayMoney;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Label label19;
		internal System.Windows.Forms.CheckBox m_chkStatus0;
		internal System.Windows.Forms.CheckBox m_chkStatus2;
		internal System.Windows.Forms.CheckBox m_chkStatus3;
		internal System.Windows.Forms.CheckBox m_chkStatus1;
		internal System.Windows.Forms.CheckBox m_chkNeedFeel;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Panel panel10;
		private System.Windows.Forms.Label label28;
		internal PinkieControls.ButtonXP cmdFindOrder;
		internal System.Windows.Forms.ComboBox m_cobFindTpye;
		internal System.Windows.Forms.Label m_lblFindMessage1;
		internal System.Windows.Forms.TextBox m_txbFindText;
		internal System.Windows.Forms.ComboBox m_cobFindComboBox;
		internal System.Windows.Forms.Label m_lblFindMessage2;
		internal System.Windows.Forms.DateTimePicker m_dtStartTime;
		internal System.Windows.Forms.DateTimePicker m_dtEndTime;
		internal System.Windows.Forms.CheckBox m_chkLongOrder;
		internal System.Windows.Forms.CheckBox m_chkTempOrder;
		internal com.digitalwave.iCare.BIHOrder.Control.ctlFindTextBox m_txtBedNo;
		internal System.Windows.Forms.ListView m_lsvOrder;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private PinkieControls.ButtonXP cmdPrintOrder;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.ColumnHeader columnHeader12;
		private System.Windows.Forms.ColumnHeader columnHeader13;
		private System.Windows.Forms.ColumnHeader columnHeader14;
		private System.Windows.Forms.ColumnHeader columnHeader15;
		private System.Windows.Forms.ColumnHeader columnHeader16;
		private System.Windows.Forms.ColumnHeader columnHeader17;
		private System.Windows.Forms.ColumnHeader columnHeader18;
		private System.Windows.Forms.ColumnHeader columnHeader19;
		private System.Windows.Forms.ColumnHeader columnHeader20;
		private System.Windows.Forms.ColumnHeader columnHeader22;
		private System.Windows.Forms.ColumnHeader columnHeader23;
		private System.Windows.Forms.ColumnHeader columnHeader25;
		private System.Windows.Forms.ColumnHeader columnHeader26;
		internal System.Windows.Forms.ListView m_lsvExecOrderInfo;
		internal System.Windows.Forms.ListView m_lsvChargeInfo;
		private System.Windows.Forms.ColumnHeader columnHeader29;
		internal System.Windows.Forms.ListView m_lsvPutMedicineInfo;
		private System.Windows.Forms.ColumnHeader columnHeader43;
		private System.Windows.Forms.ColumnHeader columnHeader57;
		private System.Windows.Forms.ColumnHeader columnHeader58;
		private System.Windows.Forms.ColumnHeader columnHeader59;
		private System.Windows.Forms.ColumnHeader columnHeader30;
		private System.Windows.Forms.ColumnHeader columnHeader31;
		private System.Windows.Forms.ColumnHeader columnHeader32;
		private System.Windows.Forms.ColumnHeader columnHeader33;
		private System.Windows.Forms.ColumnHeader columnHeader34;
		private System.Windows.Forms.ColumnHeader columnHeader35;
		private System.Windows.Forms.ColumnHeader columnHeader36;
		private System.Windows.Forms.ColumnHeader columnHeader37;
		private System.Windows.Forms.ColumnHeader columnHeader24;
		private System.Windows.Forms.ColumnHeader columnHeader27;
		private System.Windows.Forms.ColumnHeader columnHeader28;
		private System.Windows.Forms.ColumnHeader columnHeader38;
		private System.Windows.Forms.ColumnHeader columnHeader39;
		private System.Windows.Forms.ColumnHeader columnHeader40;
		private System.Windows.Forms.ColumnHeader columnHeader42;
		private System.Windows.Forms.ColumnHeader columnHeader44;
		private System.Windows.Forms.ColumnHeader columnHeader45;
		private System.Windows.Forms.ColumnHeader columnHeader46;
		private System.Windows.Forms.ColumnHeader columnHeader47;
		private System.Windows.Forms.ColumnHeader columnHeader48;
		private System.Windows.Forms.ColumnHeader columnHeader49;
		private System.Windows.Forms.ColumnHeader columnHeader21;
		private System.Windows.Forms.ColumnHeader columnHeader41;
		private System.Windows.Forms.ColumnHeader columnHeader50;
		private System.Windows.Forms.ColumnHeader columnHeader51;
		private System.Windows.Forms.ColumnHeader columnHeader52;
		private System.Windows.Forms.ColumnHeader columnHeader53;
		private System.Windows.Forms.ColumnHeader columnHeader54;
		private System.Windows.Forms.ColumnHeader columnHeader55;
		private System.Windows.Forms.ColumnHeader columnHeader56;
		private System.Windows.Forms.ColumnHeader columnHeader60;
		private System.Windows.Forms.ColumnHeader columnHeader61;
		private System.Windows.Forms.ColumnHeader columnHeader62;
		internal System.Windows.Forms.CheckBox m_chkStatus4;
		private System.Windows.Forms.ColumnHeader columnHeader63;
		internal System.Windows.Forms.Label m_lblRecordCharge;
		internal System.Windows.Forms.Label m_lblRecordExecOrder;
		internal System.Windows.Forms.Label m_lblRecordPutMedicine;
		internal System.Windows.Forms.Label m_lblReordAddOrder;
		internal System.Windows.Forms.CheckBox m_chkStatus5;
		internal System.Windows.Forms.ComboBox cbo_bihHistory;
		internal System.Windows.Forms.ListView m_lsvApplyInfo;
		#endregion 
		private System.Windows.Forms.ImageList imgAddBills;
		internal System.Windows.Forms.ToolTip toolTip1;
        private PinkieControls.ButtonXP cmdClose;

		private System.ComponentModel.IContainer components;

		#region 构造函数
		public frmSearchOrderInfo()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
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
		#endregion 

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchOrderInfo));
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_txtBedNo = new com.digitalwave.iCare.BIHOrder.Control.ctlFindTextBox();
            this.m_txtInHospitalDate = new System.Windows.Forms.TextBox();
            this.m_txtInDays = new System.Windows.Forms.TextBox();
            this.m_txtPayType = new System.Windows.Forms.TextBox();
            this.m_txtName = new System.Windows.Forms.TextBox();
            this.m_txtSex = new System.Windows.Forms.TextBox();
            this.m_txtInHospitalNo = new com.digitalwave.iCare.BIHOrder.Control.ctlFindTextBox();
            this.m_txtArea = new com.digitalwave.iCare.BIHOrder.Control.ctlFindTextBox();
            this.m_txtDiagnose = new System.Windows.Forms.TextBox();
            this.m_txtPrePayMoney = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_lsvOrder = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader21 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader41 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader50 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader51 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader52 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader53 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader54 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader55 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader56 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader60 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader61 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader62 = new System.Windows.Forms.ColumnHeader();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cmdClose = new PinkieControls.ButtonXP();
            this.cbo_bihHistory = new System.Windows.Forms.ComboBox();
            this.cmdPrintOrder = new PinkieControls.ButtonXP();
            this.m_chkTempOrder = new System.Windows.Forms.CheckBox();
            this.m_chkNeedFeel = new System.Windows.Forms.CheckBox();
            this.m_chkStatus3 = new System.Windows.Forms.CheckBox();
            this.m_chkStatus2 = new System.Windows.Forms.CheckBox();
            this.m_chkStatus1 = new System.Windows.Forms.CheckBox();
            this.m_chkStatus0 = new System.Windows.Forms.CheckBox();
            this.m_chkLongOrder = new System.Windows.Forms.CheckBox();
            this.m_lblFindMessage2 = new System.Windows.Forms.Label();
            this.m_chkStatus4 = new System.Windows.Forms.CheckBox();
            this.m_chkStatus5 = new System.Windows.Forms.CheckBox();
            this.m_cobFindComboBox = new System.Windows.Forms.ComboBox();
            this.m_txbFindText = new System.Windows.Forms.TextBox();
            this.m_dtEndTime = new System.Windows.Forms.DateTimePicker();
            this.m_cobFindTpye = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cmdFindOrder = new PinkieControls.ButtonXP();
            this.m_dtStartTime = new System.Windows.Forms.DateTimePicker();
            this.m_lblFindMessage1 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.m_lsvExecOrderInfo = new System.Windows.Forms.ListView();
            this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader63 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader17 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader20 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader18 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader19 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader22 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader23 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader25 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader26 = new System.Windows.Forms.ColumnHeader();
            this.panel7 = new System.Windows.Forms.Panel();
            this.m_lblRecordExecOrder = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.m_lsvChargeInfo = new System.Windows.Forms.ListView();
            this.columnHeader29 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader57 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader58 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader59 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader38 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader39 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader40 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader42 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader44 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader45 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader46 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader47 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader48 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader49 = new System.Windows.Forms.ColumnHeader();
            this.panel8 = new System.Windows.Forms.Panel();
            this.m_lblRecordCharge = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.m_lsvPutMedicineInfo = new System.Windows.Forms.ListView();
            this.columnHeader43 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader36 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader34 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader30 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader31 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader32 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader33 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader35 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader37 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader24 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader27 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader28 = new System.Windows.Forms.ColumnHeader();
            this.panel9 = new System.Windows.Forms.Panel();
            this.m_lblRecordPutMedicine = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.m_lsvApplyInfo = new System.Windows.Forms.ListView();
            this.imgAddBills = new System.Windows.Forms.ImageList(this.components);
            this.panel10 = new System.Windows.Forms.Panel();
            this.m_lblReordAddOrder = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel8.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel9.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.m_txtBedNo);
            this.panel1.Controls.Add(this.m_txtInHospitalDate);
            this.panel1.Controls.Add(this.m_txtInDays);
            this.panel1.Controls.Add(this.m_txtPayType);
            this.panel1.Controls.Add(this.m_txtName);
            this.panel1.Controls.Add(this.m_txtSex);
            this.panel1.Controls.Add(this.m_txtInHospitalNo);
            this.panel1.Controls.Add(this.m_txtArea);
            this.panel1.Controls.Add(this.m_txtDiagnose);
            this.panel1.Controls.Add(this.m_txtPrePayMoney);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(968, 72);
            this.panel1.TabIndex = 0;
            // 
            // m_txtBedNo
            // 
            this.m_txtBedNo.Location = new System.Drawing.Point(208, 40);
            this.m_txtBedNo.Name = "m_txtBedNo";
            this.m_txtBedNo.Size = new System.Drawing.Size(88, 23);
            this.m_txtBedNo.TabIndex = 52;
            this.m_txtBedNo.m_evtFindItem += new com.digitalwave.iCare.BIHOrder.Control.EventHandler_OnFindItem(this.m_txtBedNo_m_evtFindItem);
            this.m_txtBedNo.m_evtInitListView += new com.digitalwave.iCare.BIHOrder.Control.EventHandler_InitListView(this.m_txtBedNo_m_evtInitListView);
            this.m_txtBedNo.m_evtSelectItem += new com.digitalwave.iCare.BIHOrder.Control.EventHandler_OnSelectItem(this.m_txtBedNo_m_evtSelectItem);
            this.m_txtBedNo.TextChanged += new System.EventHandler(this.m_txtBedNo_TextChanged);
            // 
            // m_txtInHospitalDate
            // 
            this.m_txtInHospitalDate.Location = new System.Drawing.Point(728, 8);
            this.m_txtInHospitalDate.Name = "m_txtInHospitalDate";
            this.m_txtInHospitalDate.ReadOnly = true;
            this.m_txtInHospitalDate.Size = new System.Drawing.Size(112, 23);
            this.m_txtInHospitalDate.TabIndex = 52;
            this.m_txtInHospitalDate.TabStop = false;
            // 
            // m_txtInDays
            // 
            this.m_txtInDays.Location = new System.Drawing.Point(909, 8);
            this.m_txtInDays.Name = "m_txtInDays";
            this.m_txtInDays.ReadOnly = true;
            this.m_txtInDays.Size = new System.Drawing.Size(51, 23);
            this.m_txtInDays.TabIndex = 50;
            this.m_txtInDays.TabStop = false;
            // 
            // m_txtPayType
            // 
            this.m_txtPayType.Location = new System.Drawing.Point(416, 8);
            this.m_txtPayType.Name = "m_txtPayType";
            this.m_txtPayType.ReadOnly = true;
            this.m_txtPayType.Size = new System.Drawing.Size(80, 23);
            this.m_txtPayType.TabIndex = 48;
            this.m_txtPayType.TabStop = false;
            // 
            // m_txtName
            // 
            this.m_txtName.Location = new System.Drawing.Point(209, 8);
            this.m_txtName.Name = "m_txtName";
            this.m_txtName.ReadOnly = true;
            this.m_txtName.Size = new System.Drawing.Size(84, 23);
            this.m_txtName.TabIndex = 47;
            this.m_txtName.TabStop = false;
            // 
            // m_txtSex
            // 
            this.m_txtSex.Location = new System.Drawing.Point(336, 8);
            this.m_txtSex.Name = "m_txtSex";
            this.m_txtSex.ReadOnly = true;
            this.m_txtSex.Size = new System.Drawing.Size(40, 23);
            this.m_txtSex.TabIndex = 46;
            this.m_txtSex.TabStop = false;
            // 
            // m_txtInHospitalNo
            // 
            this.m_txtInHospitalNo.Location = new System.Drawing.Point(64, 8);
            this.m_txtInHospitalNo.MaxLength = 9;
            this.m_txtInHospitalNo.Name = "m_txtInHospitalNo";
            this.m_txtInHospitalNo.Size = new System.Drawing.Size(104, 23);
            this.m_txtInHospitalNo.TabIndex = 43;
            this.m_txtInHospitalNo.m_evtFindItem += new com.digitalwave.iCare.BIHOrder.Control.EventHandler_OnFindItem(this.m_txtInHospitalNo_m_evtFindItem);
            this.m_txtInHospitalNo.m_evtInitListView += new com.digitalwave.iCare.BIHOrder.Control.EventHandler_InitListView(this.m_txtInHospitalNo_m_evtInitListView);
            this.m_txtInHospitalNo.m_evtSelectItem += new com.digitalwave.iCare.BIHOrder.Control.EventHandler_OnSelectItem(this.m_txtInHospitalNo_m_evtSelectItem);
            // 
            // m_txtArea
            // 
            this.m_txtArea.Location = new System.Drawing.Point(64, 40);
            this.m_txtArea.Name = "m_txtArea";
            this.m_txtArea.Size = new System.Drawing.Size(104, 23);
            this.m_txtArea.TabIndex = 51;
            this.m_txtArea.m_evtFindItem += new com.digitalwave.iCare.BIHOrder.Control.EventHandler_OnFindItem(this.m_txtArea_m_evtFindItem);
            this.m_txtArea.m_evtInitListView += new com.digitalwave.iCare.BIHOrder.Control.EventHandler_InitListView(this.m_txtArea_m_evtInitListView);
            this.m_txtArea.m_evtSelectItem += new com.digitalwave.iCare.BIHOrder.Control.EventHandler_OnSelectItem(this.m_txtArea_m_evtSelectItem);
            // 
            // m_txtDiagnose
            // 
            this.m_txtDiagnose.Location = new System.Drawing.Point(336, 40);
            this.m_txtDiagnose.Name = "m_txtDiagnose";
            this.m_txtDiagnose.ReadOnly = true;
            this.m_txtDiagnose.Size = new System.Drawing.Size(624, 23);
            this.m_txtDiagnose.TabIndex = 49;
            this.m_txtDiagnose.TabStop = false;
            // 
            // m_txtPrePayMoney
            // 
            this.m_txtPrePayMoney.BackColor = System.Drawing.SystemColors.Control;
            this.m_txtPrePayMoney.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPrePayMoney.ForeColor = System.Drawing.Color.Red;
            this.m_txtPrePayMoney.Location = new System.Drawing.Point(577, 8);
            this.m_txtPrePayMoney.Name = "m_txtPrePayMoney";
            this.m_txtPrePayMoney.Size = new System.Drawing.Size(80, 23);
            this.m_txtPrePayMoney.TabIndex = 44;
            this.m_txtPrePayMoney.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 14);
            this.label11.TabIndex = 42;
            this.label11.Text = "病  区:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(656, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 14);
            this.label10.TabIndex = 41;
            this.label10.Text = "入院日期:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(494, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 14);
            this.label9.TabIndex = 40;
            this.label9.Text = "预缴金余额:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(376, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 14);
            this.label8.TabIndex = 39;
            this.label8.Text = "身份:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 14);
            this.label7.TabIndex = 38;
            this.label7.Text = "住院号:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(169, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 14);
            this.label6.TabIndex = 37;
            this.label6.Text = "姓名:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(296, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 14);
            this.label5.TabIndex = 36;
            this.label5.Text = "性别:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(169, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 14);
            this.label4.TabIndex = 35;
            this.label4.Text = "床号:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(840, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 34;
            this.label3.Text = "住院天数:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(296, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 33;
            this.label1.Text = "诊断:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.m_lsvOrder);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.m_cobFindComboBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 72);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(968, 312);
            this.panel2.TabIndex = 1;
            // 
            // m_lsvOrder
            // 
            this.m_lsvOrder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader21,
            this.columnHeader41,
            this.columnHeader50,
            this.columnHeader51,
            this.columnHeader52,
            this.columnHeader53,
            this.columnHeader54,
            this.columnHeader55,
            this.columnHeader56,
            this.columnHeader60,
            this.columnHeader61,
            this.columnHeader62});
            this.m_lsvOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvOrder.FullRowSelect = true;
            this.m_lsvOrder.GridLines = true;
            this.m_lsvOrder.HideSelection = false;
            this.m_lsvOrder.Location = new System.Drawing.Point(0, 56);
            this.m_lsvOrder.Name = "m_lsvOrder";
            this.m_lsvOrder.Size = new System.Drawing.Size(964, 252);
            this.m_lsvOrder.TabIndex = 58;
            this.m_lsvOrder.UseCompatibleStateImageBehavior = false;
            this.m_lsvOrder.View = System.Windows.Forms.View.Details;
            this.m_lsvOrder.SelectedIndexChanged += new System.EventHandler(this.m_lsvOrder_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "序号";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "方号";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 40;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "    医嘱名称";
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "长|临";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 50;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "执行状态";
            this.columnHeader5.Width = 80;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "剂  量";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader6.Width = 70;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "用  量";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader7.Width = 70;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "领  量";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader8.Width = 70;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = " 单  价 ";
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader9.Width = 70;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "执行频率";
            this.columnHeader10.Width = 80;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "  用法";
            this.columnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader11.Width = 80;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "     父医嘱";
            this.columnHeader12.Width = 120;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "起始时间";
            this.columnHeader13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader13.Width = 130;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "结束时间";
            this.columnHeader14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader14.Width = 130;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "创建者";
            this.columnHeader21.Width = 70;
            // 
            // columnHeader41
            // 
            this.columnHeader41.Text = "创建时间";
            this.columnHeader41.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader41.Width = 130;
            // 
            // columnHeader50
            // 
            this.columnHeader50.Text = "提交者";
            this.columnHeader50.Width = 70;
            // 
            // columnHeader51
            // 
            this.columnHeader51.Text = "提交时间";
            this.columnHeader51.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader51.Width = 130;
            // 
            // columnHeader52
            // 
            this.columnHeader52.Text = "审核提交者";
            this.columnHeader52.Width = 90;
            // 
            // columnHeader53
            // 
            this.columnHeader53.Text = "审核提交时间";
            this.columnHeader53.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader53.Width = 130;
            // 
            // columnHeader54
            // 
            this.columnHeader54.Text = "执行者";
            this.columnHeader54.Width = 70;
            // 
            // columnHeader55
            // 
            this.columnHeader55.Text = "执行时间";
            this.columnHeader55.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader55.Width = 130;
            // 
            // columnHeader56
            // 
            this.columnHeader56.Text = "停止者";
            this.columnHeader56.Width = 70;
            // 
            // columnHeader60
            // 
            this.columnHeader60.Text = "停止时间";
            this.columnHeader60.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader60.Width = 130;
            // 
            // columnHeader61
            // 
            this.columnHeader61.Text = "审核停止者";
            this.columnHeader61.Width = 90;
            // 
            // columnHeader62
            // 
            this.columnHeader62.Text = "审核停止时间";
            this.columnHeader62.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader62.Width = 130;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.cmdClose);
            this.panel6.Controls.Add(this.cbo_bihHistory);
            this.panel6.Controls.Add(this.cmdPrintOrder);
            this.panel6.Controls.Add(this.m_chkTempOrder);
            this.panel6.Controls.Add(this.m_chkNeedFeel);
            this.panel6.Controls.Add(this.m_chkStatus3);
            this.panel6.Controls.Add(this.m_chkStatus2);
            this.panel6.Controls.Add(this.m_chkStatus1);
            this.panel6.Controls.Add(this.m_chkStatus0);
            this.panel6.Controls.Add(this.m_chkLongOrder);
            this.panel6.Controls.Add(this.m_lblFindMessage2);
            this.panel6.Controls.Add(this.m_chkStatus4);
            this.panel6.Controls.Add(this.m_chkStatus5);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(964, 56);
            this.panel6.TabIndex = 57;
            // 
            // cmdClose
            // 
            this.cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdClose.DefaultScheme = true;
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdClose.Hint = "";
            this.cmdClose.Location = new System.Drawing.Point(860, 11);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdClose.Size = new System.Drawing.Size(95, 32);
            this.cmdClose.TabIndex = 72;
            this.cmdClose.Text = "关闭(&Esc)";
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cbo_bihHistory
            // 
            this.cbo_bihHistory.Location = new System.Drawing.Point(619, 18);
            this.cbo_bihHistory.Name = "cbo_bihHistory";
            this.cbo_bihHistory.Size = new System.Drawing.Size(123, 22);
            this.cbo_bihHistory.TabIndex = 71;
            this.cbo_bihHistory.Text = "历次住院记录";
            this.cbo_bihHistory.Visible = false;
            this.cbo_bihHistory.SelectedIndexChanged += new System.EventHandler(this.cbo_bihHistory_SelectedIndexChanged);
            // 
            // cmdPrintOrder
            // 
            this.cmdPrintOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdPrintOrder.DefaultScheme = true;
            this.cmdPrintOrder.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdPrintOrder.Hint = "";
            this.cmdPrintOrder.Location = new System.Drawing.Point(753, 11);
            this.cmdPrintOrder.Name = "cmdPrintOrder";
            this.cmdPrintOrder.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdPrintOrder.Size = new System.Drawing.Size(95, 32);
            this.cmdPrintOrder.TabIndex = 70;
            this.cmdPrintOrder.Text = "打印(F4)";
            this.cmdPrintOrder.Click += new System.EventHandler(this.cmdPrintOrder_Click);
            // 
            // m_chkTempOrder
            // 
            this.m_chkTempOrder.Location = new System.Drawing.Point(72, 21);
            this.m_chkTempOrder.Name = "m_chkTempOrder";
            this.m_chkTempOrder.Size = new System.Drawing.Size(56, 24);
            this.m_chkTempOrder.TabIndex = 60;
            this.m_chkTempOrder.Text = "临嘱";
            this.m_chkTempOrder.CheckedChanged += new System.EventHandler(this.cmdFindOrder_Click);
            // 
            // m_chkNeedFeel
            // 
            this.m_chkNeedFeel.Location = new System.Drawing.Point(132, 21);
            this.m_chkNeedFeel.Name = "m_chkNeedFeel";
            this.m_chkNeedFeel.Size = new System.Drawing.Size(68, 24);
            this.m_chkNeedFeel.TabIndex = 61;
            this.m_chkNeedFeel.Text = "仅皮试";
            this.m_chkNeedFeel.CheckedChanged += new System.EventHandler(this.cmdFindOrder_Click);
            // 
            // m_chkStatus3
            // 
            this.m_chkStatus3.Checked = true;
            this.m_chkStatus3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkStatus3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkStatus3.Location = new System.Drawing.Point(496, 21);
            this.m_chkStatus3.Name = "m_chkStatus3";
            this.m_chkStatus3.Size = new System.Drawing.Size(68, 24);
            this.m_chkStatus3.TabIndex = 66;
            this.m_chkStatus3.Text = "已停止";
            this.m_chkStatus3.CheckedChanged += new System.EventHandler(this.cmdFindOrder_Click);
            // 
            // m_chkStatus2
            // 
            this.m_chkStatus2.Checked = true;
            this.m_chkStatus2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkStatus2.Location = new System.Drawing.Point(428, 21);
            this.m_chkStatus2.Name = "m_chkStatus2";
            this.m_chkStatus2.Size = new System.Drawing.Size(68, 24);
            this.m_chkStatus2.TabIndex = 65;
            this.m_chkStatus2.Text = "已执行";
            this.m_chkStatus2.CheckedChanged += new System.EventHandler(this.cmdFindOrder_Click);
            // 
            // m_chkStatus1
            // 
            this.m_chkStatus1.Checked = true;
            this.m_chkStatus1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkStatus1.Location = new System.Drawing.Point(304, 21);
            this.m_chkStatus1.Name = "m_chkStatus1";
            this.m_chkStatus1.Size = new System.Drawing.Size(68, 24);
            this.m_chkStatus1.TabIndex = 64;
            this.m_chkStatus1.Text = "已提交";
            this.m_chkStatus1.CheckedChanged += new System.EventHandler(this.cmdFindOrder_Click);
            // 
            // m_chkStatus0
            // 
            this.m_chkStatus0.Checked = true;
            this.m_chkStatus0.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkStatus0.Location = new System.Drawing.Point(236, 21);
            this.m_chkStatus0.Name = "m_chkStatus0";
            this.m_chkStatus0.Size = new System.Drawing.Size(68, 24);
            this.m_chkStatus0.TabIndex = 63;
            this.m_chkStatus0.Text = "未提交";
            this.m_chkStatus0.CheckedChanged += new System.EventHandler(this.cmdFindOrder_Click);
            // 
            // m_chkLongOrder
            // 
            this.m_chkLongOrder.Location = new System.Drawing.Point(16, 21);
            this.m_chkLongOrder.Name = "m_chkLongOrder";
            this.m_chkLongOrder.Size = new System.Drawing.Size(56, 24);
            this.m_chkLongOrder.TabIndex = 59;
            this.m_chkLongOrder.Text = "长嘱";
            this.m_chkLongOrder.CheckedChanged += new System.EventHandler(this.cmdFindOrder_Click);
            // 
            // m_lblFindMessage2
            // 
            this.m_lblFindMessage2.AutoSize = true;
            this.m_lblFindMessage2.Location = new System.Drawing.Point(436, -16);
            this.m_lblFindMessage2.Name = "m_lblFindMessage2";
            this.m_lblFindMessage2.Size = new System.Drawing.Size(14, 14);
            this.m_lblFindMessage2.TabIndex = 67;
            this.m_lblFindMessage2.Text = "-";
            this.m_lblFindMessage2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.m_lblFindMessage2.Visible = false;
            // 
            // m_chkStatus4
            // 
            this.m_chkStatus4.Checked = true;
            this.m_chkStatus4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkStatus4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkStatus4.Location = new System.Drawing.Point(564, 21);
            this.m_chkStatus4.Name = "m_chkStatus4";
            this.m_chkStatus4.Size = new System.Drawing.Size(68, 24);
            this.m_chkStatus4.TabIndex = 62;
            this.m_chkStatus4.Text = "重整";
            this.m_chkStatus4.CheckedChanged += new System.EventHandler(this.cmdFindOrder_Click);
            // 
            // m_chkStatus5
            // 
            this.m_chkStatus5.Checked = true;
            this.m_chkStatus5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkStatus5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkStatus5.Location = new System.Drawing.Point(372, 21);
            this.m_chkStatus5.Name = "m_chkStatus5";
            this.m_chkStatus5.Size = new System.Drawing.Size(68, 24);
            this.m_chkStatus5.TabIndex = 62;
            this.m_chkStatus5.Text = "退回";
            this.m_chkStatus5.CheckedChanged += new System.EventHandler(this.cmdFindOrder_Click);
            // 
            // m_cobFindComboBox
            // 
            this.m_cobFindComboBox.Location = new System.Drawing.Point(744, -12);
            this.m_cobFindComboBox.Name = "m_cobFindComboBox";
            this.m_cobFindComboBox.Size = new System.Drawing.Size(200, 22);
            this.m_cobFindComboBox.TabIndex = 58;
            this.m_cobFindComboBox.Visible = false;
            // 
            // m_txbFindText
            // 
            this.m_txbFindText.Location = new System.Drawing.Point(96, 8);
            this.m_txbFindText.Name = "m_txbFindText";
            this.m_txbFindText.Size = new System.Drawing.Size(200, 23);
            this.m_txbFindText.TabIndex = 58;
            this.m_txbFindText.Visible = false;
            // 
            // m_dtEndTime
            // 
            this.m_dtEndTime.Location = new System.Drawing.Point(304, 8);
            this.m_dtEndTime.Name = "m_dtEndTime";
            this.m_dtEndTime.Size = new System.Drawing.Size(118, 23);
            this.m_dtEndTime.TabIndex = 59;
            this.m_dtEndTime.Visible = false;
            // 
            // m_cobFindTpye
            // 
            this.m_cobFindTpye.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cobFindTpye.Location = new System.Drawing.Point(512, 8);
            this.m_cobFindTpye.Name = "m_cobFindTpye";
            this.m_cobFindTpye.Size = new System.Drawing.Size(200, 22);
            this.m_cobFindTpye.TabIndex = 57;
            this.m_cobFindTpye.Visible = false;
            this.m_cobFindTpye.SelectedIndexChanged += new System.EventHandler(this.m_cobFindTpye_SelectedIndexChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(432, 8);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(77, 14);
            this.label19.TabIndex = 58;
            this.label19.Text = "查询类型：";
            this.label19.Visible = false;
            // 
            // cmdFindOrder
            // 
            this.cmdFindOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdFindOrder.DefaultScheme = true;
            this.cmdFindOrder.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdFindOrder.Hint = "";
            this.cmdFindOrder.Location = new System.Drawing.Point(856, 0);
            this.cmdFindOrder.Name = "cmdFindOrder";
            this.cmdFindOrder.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdFindOrder.Size = new System.Drawing.Size(120, 28);
            this.cmdFindOrder.TabIndex = 68;
            this.cmdFindOrder.Text = "查询(F3)";
            this.cmdFindOrder.Visible = false;
            this.cmdFindOrder.Click += new System.EventHandler(this.cmdFindOrder_Click);
            // 
            // m_dtStartTime
            // 
            this.m_dtStartTime.Location = new System.Drawing.Point(792, 8);
            this.m_dtStartTime.Name = "m_dtStartTime";
            this.m_dtStartTime.Size = new System.Drawing.Size(118, 23);
            this.m_dtStartTime.TabIndex = 58;
            this.m_dtStartTime.Visible = false;
            // 
            // m_lblFindMessage1
            // 
            this.m_lblFindMessage1.AutoSize = true;
            this.m_lblFindMessage1.Location = new System.Drawing.Point(720, 8);
            this.m_lblFindMessage1.Name = "m_lblFindMessage1";
            this.m_lblFindMessage1.Size = new System.Drawing.Size(77, 14);
            this.m_lblFindMessage1.TabIndex = 58;
            this.m_lblFindMessage1.Text = "查询内容：";
            this.m_lblFindMessage1.Visible = false;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.GrayText;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 384);
            this.splitter1.MinExtra = 30;
            this.splitter1.MinSize = 270;
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(968, 4);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            this.splitter1.DoubleClick += new System.EventHandler(this.splitter1_DoubleClick);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.tabControl1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 388);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(968, 257);
            this.panel3.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(964, 253);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.m_lsvExecOrderInfo);
            this.tabPage1.Controls.Add(this.panel7);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(956, 226);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "执行单信息(1)";
            // 
            // m_lsvExecOrderInfo
            // 
            this.m_lsvExecOrderInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader15,
            this.columnHeader63,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader20,
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader22,
            this.columnHeader23,
            this.columnHeader25,
            this.columnHeader26});
            this.m_lsvExecOrderInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvExecOrderInfo.FullRowSelect = true;
            this.m_lsvExecOrderInfo.GridLines = true;
            this.m_lsvExecOrderInfo.HideSelection = false;
            this.m_lsvExecOrderInfo.Location = new System.Drawing.Point(0, 32);
            this.m_lsvExecOrderInfo.Name = "m_lsvExecOrderInfo";
            this.m_lsvExecOrderInfo.Size = new System.Drawing.Size(956, 194);
            this.m_lsvExecOrderInfo.TabIndex = 59;
            this.m_lsvExecOrderInfo.UseCompatibleStateImageBehavior = false;
            this.m_lsvExecOrderInfo.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "序号";
            this.columnHeader15.Width = 40;
            // 
            // columnHeader63
            // 
            this.columnHeader63.Text = "执行单ID";
            this.columnHeader63.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader63.Width = 140;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "  生成人";
            this.columnHeader16.Width = 80;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "生成时间";
            this.columnHeader17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader17.Width = 130;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "执行天数";
            this.columnHeader20.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader20.Width = 70;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "执行次数";
            this.columnHeader18.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader18.Width = 80;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "执行时间";
            this.columnHeader19.Width = 150;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "接收状态";
            this.columnHeader22.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader22.Width = 70;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "首次执行";
            this.columnHeader23.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader23.Width = 70;
            // 
            // columnHeader25
            // 
            this.columnHeader25.Text = "类型";
            this.columnHeader25.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader25.Width = 70;
            // 
            // columnHeader26
            // 
            this.columnHeader26.Text = "  修改人";
            this.columnHeader26.Width = 70;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.m_lblRecordExecOrder);
            this.panel7.Controls.Add(this.label22);
            this.panel7.Controls.Add(this.m_txbFindText);
            this.panel7.Controls.Add(this.m_dtEndTime);
            this.panel7.Controls.Add(this.m_cobFindTpye);
            this.panel7.Controls.Add(this.label19);
            this.panel7.Controls.Add(this.m_lblFindMessage1);
            this.panel7.Controls.Add(this.cmdFindOrder);
            this.panel7.Controls.Add(this.m_dtStartTime);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(956, 32);
            this.panel7.TabIndex = 0;
            // 
            // m_lblRecordExecOrder
            // 
            this.m_lblRecordExecOrder.AutoSize = true;
            this.m_lblRecordExecOrder.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.m_lblRecordExecOrder.ForeColor = System.Drawing.Color.Maroon;
            this.m_lblRecordExecOrder.Location = new System.Drawing.Point(70, 13);
            this.m_lblRecordExecOrder.Name = "m_lblRecordExecOrder";
            this.m_lblRecordExecOrder.Size = new System.Drawing.Size(15, 14);
            this.m_lblRecordExecOrder.TabIndex = 1;
            this.m_lblRecordExecOrder.Text = "0";
            this.m_lblRecordExecOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(6, 13);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(77, 14);
            this.label22.TabIndex = 0;
            this.label22.Text = "记录条数：";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.m_lsvChargeInfo);
            this.tabPage2.Controls.Add(this.panel8);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(956, 228);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "收费信息(2)";
            // 
            // m_lsvChargeInfo
            // 
            this.m_lsvChargeInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader29,
            this.columnHeader57,
            this.columnHeader58,
            this.columnHeader59,
            this.columnHeader38,
            this.columnHeader39,
            this.columnHeader40,
            this.columnHeader42,
            this.columnHeader44,
            this.columnHeader45,
            this.columnHeader46,
            this.columnHeader47,
            this.columnHeader48,
            this.columnHeader49});
            this.m_lsvChargeInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvChargeInfo.FullRowSelect = true;
            this.m_lsvChargeInfo.GridLines = true;
            this.m_lsvChargeInfo.HideSelection = false;
            this.m_lsvChargeInfo.Location = new System.Drawing.Point(0, 32);
            this.m_lsvChargeInfo.Name = "m_lsvChargeInfo";
            this.m_lsvChargeInfo.Size = new System.Drawing.Size(956, 196);
            this.m_lsvChargeInfo.TabIndex = 59;
            this.m_lsvChargeInfo.UseCompatibleStateImageBehavior = false;
            this.m_lsvChargeInfo.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader29
            // 
            this.columnHeader29.Text = "序号";
            this.columnHeader29.Width = 40;
            // 
            // columnHeader57
            // 
            this.columnHeader57.Text = "生效日期";
            this.columnHeader57.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader57.Width = 130;
            // 
            // columnHeader58
            // 
            this.columnHeader58.Text = "核算病区";
            this.columnHeader58.Width = 80;
            // 
            // columnHeader59
            // 
            this.columnHeader59.Text = "开单地点";
            this.columnHeader59.Width = 80;
            // 
            // columnHeader38
            // 
            this.columnHeader38.Text = "费用核算类别";
            this.columnHeader38.Width = 100;
            // 
            // columnHeader39
            // 
            this.columnHeader39.Text = "费用发票类别";
            this.columnHeader39.Width = 100;
            // 
            // columnHeader40
            // 
            this.columnHeader40.Text = "收费项目名称";
            this.columnHeader40.Width = 150;
            // 
            // columnHeader42
            // 
            this.columnHeader42.Text = "住院单价";
            this.columnHeader42.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader42.Width = 80;
            // 
            // columnHeader44
            // 
            this.columnHeader44.Text = "领量";
            this.columnHeader44.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader45
            // 
            this.columnHeader45.Text = "折扣比例";
            this.columnHeader45.Width = 80;
            // 
            // columnHeader46
            // 
            this.columnHeader46.Text = "自费项目";
            this.columnHeader46.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader46.Width = 70;
            // 
            // columnHeader47
            // 
            this.columnHeader47.Text = "录入类型";
            this.columnHeader47.Width = 80;
            // 
            // columnHeader48
            // 
            this.columnHeader48.Text = "录入人";
            this.columnHeader48.Width = 80;
            // 
            // columnHeader49
            // 
            this.columnHeader49.Text = "录入时间";
            this.columnHeader49.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader49.Width = 100;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.m_lblRecordCharge);
            this.panel8.Controls.Add(this.label24);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(956, 32);
            this.panel8.TabIndex = 1;
            // 
            // m_lblRecordCharge
            // 
            this.m_lblRecordCharge.AutoSize = true;
            this.m_lblRecordCharge.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.m_lblRecordCharge.ForeColor = System.Drawing.Color.Maroon;
            this.m_lblRecordCharge.Location = new System.Drawing.Point(70, 13);
            this.m_lblRecordCharge.Name = "m_lblRecordCharge";
            this.m_lblRecordCharge.Size = new System.Drawing.Size(15, 14);
            this.m_lblRecordCharge.TabIndex = 1;
            this.m_lblRecordCharge.Text = "0";
            this.m_lblRecordCharge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(6, 13);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(77, 14);
            this.label24.TabIndex = 0;
            this.label24.Text = "记录条数：";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.m_lsvPutMedicineInfo);
            this.tabPage3.Controls.Add(this.panel9);
            this.tabPage3.Location = new System.Drawing.Point(4, 21);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(956, 228);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "摆药信息(3)";
            // 
            // m_lsvPutMedicineInfo
            // 
            this.m_lsvPutMedicineInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader43,
            this.columnHeader36,
            this.columnHeader34,
            this.columnHeader30,
            this.columnHeader31,
            this.columnHeader32,
            this.columnHeader33,
            this.columnHeader35,
            this.columnHeader37,
            this.columnHeader24,
            this.columnHeader27,
            this.columnHeader28});
            this.m_lsvPutMedicineInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvPutMedicineInfo.FullRowSelect = true;
            this.m_lsvPutMedicineInfo.GridLines = true;
            this.m_lsvPutMedicineInfo.HideSelection = false;
            this.m_lsvPutMedicineInfo.Location = new System.Drawing.Point(0, 32);
            this.m_lsvPutMedicineInfo.Name = "m_lsvPutMedicineInfo";
            this.m_lsvPutMedicineInfo.Size = new System.Drawing.Size(956, 196);
            this.m_lsvPutMedicineInfo.TabIndex = 59;
            this.m_lsvPutMedicineInfo.UseCompatibleStateImageBehavior = false;
            this.m_lsvPutMedicineInfo.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader43
            // 
            this.columnHeader43.Text = "序号";
            this.columnHeader43.Width = 40;
            // 
            // columnHeader36
            // 
            this.columnHeader36.Text = "摆药";
            this.columnHeader36.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader36.Width = 40;
            // 
            // columnHeader34
            // 
            this.columnHeader34.Text = "执行类型";
            this.columnHeader34.Width = 80;
            // 
            // columnHeader30
            // 
            this.columnHeader30.Text = "药品编号";
            this.columnHeader30.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader30.Width = 80;
            // 
            // columnHeader31
            // 
            this.columnHeader31.Text = "药品名称";
            this.columnHeader31.Width = 120;
            // 
            // columnHeader32
            // 
            this.columnHeader32.Text = " 药品规格";
            this.columnHeader32.Width = 80;
            // 
            // columnHeader33
            // 
            this.columnHeader33.Text = "执行频率";
            this.columnHeader33.Width = 70;
            // 
            // columnHeader35
            // 
            this.columnHeader35.Text = "用   法";
            this.columnHeader35.Width = 70;
            // 
            // columnHeader37
            // 
            this.columnHeader37.Text = "领量";
            this.columnHeader37.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader37.Width = 50;
            // 
            // columnHeader24
            // 
            this.columnHeader24.Text = "单价 ";
            this.columnHeader24.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader24.Width = 50;
            // 
            // columnHeader27
            // 
            this.columnHeader27.Text = "贵重";
            this.columnHeader27.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader27.Width = 40;
            // 
            // columnHeader28
            // 
            this.columnHeader28.Text = "摆药类型";
            this.columnHeader28.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader28.Width = 70;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.m_lblRecordPutMedicine);
            this.panel9.Controls.Add(this.label26);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(956, 32);
            this.panel9.TabIndex = 2;
            // 
            // m_lblRecordPutMedicine
            // 
            this.m_lblRecordPutMedicine.AutoSize = true;
            this.m_lblRecordPutMedicine.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.m_lblRecordPutMedicine.ForeColor = System.Drawing.Color.Maroon;
            this.m_lblRecordPutMedicine.Location = new System.Drawing.Point(70, 13);
            this.m_lblRecordPutMedicine.Name = "m_lblRecordPutMedicine";
            this.m_lblRecordPutMedicine.Size = new System.Drawing.Size(15, 14);
            this.m_lblRecordPutMedicine.TabIndex = 1;
            this.m_lblRecordPutMedicine.Text = "0";
            this.m_lblRecordPutMedicine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(6, 13);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(77, 14);
            this.label26.TabIndex = 0;
            this.label26.Text = "记录条数：";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.m_lsvApplyInfo);
            this.tabPage4.Controls.Add(this.panel10);
            this.tabPage4.Location = new System.Drawing.Point(4, 21);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(956, 228);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "附加单据信息(4)";
            // 
            // m_lsvApplyInfo
            // 
            this.m_lsvApplyInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvApplyInfo.LargeImageList = this.imgAddBills;
            this.m_lsvApplyInfo.Location = new System.Drawing.Point(0, 32);
            this.m_lsvApplyInfo.Name = "m_lsvApplyInfo";
            this.m_lsvApplyInfo.Size = new System.Drawing.Size(956, 196);
            this.m_lsvApplyInfo.TabIndex = 4;
            this.m_lsvApplyInfo.UseCompatibleStateImageBehavior = false;
            this.m_lsvApplyInfo.DoubleClick += new System.EventHandler(this.m_lsvApplyInfo_DoubleClick);
            // 
            // imgAddBills
            // 
            this.imgAddBills.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgAddBills.ImageStream")));
            this.imgAddBills.TransparentColor = System.Drawing.Color.Transparent;
            this.imgAddBills.Images.SetKeyName(0, "");
            this.imgAddBills.Images.SetKeyName(1, "");
            this.imgAddBills.Images.SetKeyName(2, "");
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.m_lblReordAddOrder);
            this.panel10.Controls.Add(this.label28);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(956, 32);
            this.panel10.TabIndex = 3;
            // 
            // m_lblReordAddOrder
            // 
            this.m_lblReordAddOrder.AutoSize = true;
            this.m_lblReordAddOrder.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.m_lblReordAddOrder.ForeColor = System.Drawing.Color.Maroon;
            this.m_lblReordAddOrder.Location = new System.Drawing.Point(70, 13);
            this.m_lblReordAddOrder.Name = "m_lblReordAddOrder";
            this.m_lblReordAddOrder.Size = new System.Drawing.Size(15, 14);
            this.m_lblReordAddOrder.TabIndex = 1;
            this.m_lblReordAddOrder.Text = "0";
            this.m_lblReordAddOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(6, 13);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(77, 14);
            this.label28.TabIndex = 0;
            this.label28.Text = "记录条数：";
            // 
            // frmSearchOrderInfo
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(968, 645);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.KeyPreview = true;
            this.Name = "frmSearchOrderInfo";
            this.Text = "查看医嘱";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSearchOrderInfo_KeyDown);
            this.Load += new System.EventHandler(this.frmSearchOrderInfo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
		public override void CreateController()
		{
			this.objController = new com.digitalwave.iCare.BIHOrder.clsCtl_SearchOrderInfo();
			objController.Set_GUI_Apperance(this);
		}
		#region	窗体事件
		private void frmSearchOrderInfo_Load(object sender, System.EventArgs e)
		{
			m_mthSetEnter2Tab(new System.Windows.Forms.Control[]{});
			((clsCtl_SearchOrderInfo)this.objController).m_InitializtionFindOrderCondition();
		}
		private void frmSearchOrderInfo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			m_mthSetKeyTab(e);
			switch (e.KeyCode)
			{
				case Keys.Escape:
					if(MessageBox.Show("是否确定退出","提示",MessageBoxButtons.YesNo,MessageBoxIcon.None)==DialogResult.Yes)
					{
						this.Close();
					}
					break;
				case Keys.F3://查询
					cmdFindOrder_Click(sender,e);
					break;
				case Keys.F4://提交
					cmdPrintOrder_Click(sender,e);
					break;
				case Keys.ShiftKey://SHIT键切换TAB列
					tabControl1.SelectedIndex =(tabControl1.SelectedIndex>=tabControl1.TabCount-1)?0:tabControl1.SelectedIndex+1;
					break;
			}
			//CTRL + 数字	选中对应的TAB列
			if(e.Modifiers == Keys.Control)
			{
				if(e.KeyCode==Keys.D1 || e.KeyCode==Keys.NumPad1) tabControl1.SelectedIndex =0;
				if(e.KeyCode==Keys.D2 || e.KeyCode==Keys.NumPad2) tabControl1.SelectedIndex =1;
				if(e.KeyCode==Keys.D3 || e.KeyCode==Keys.NumPad3) tabControl1.SelectedIndex =2;
				if(e.KeyCode==Keys.D4 || e.KeyCode==Keys.NumPad4) tabControl1.SelectedIndex =3;
				if(e.KeyCode==Keys.Tab) tabControl1.SelectedIndex =(tabControl1.SelectedIndex>=tabControl1.TabCount-1)?0:tabControl1.SelectedIndex+1;
			}
		}
		#endregion
		#region 病人信息
		private void m_txtInHospitalNo_m_evtInitListView(System.Windows.Forms.ListView lvwList)
		{
			((clsCtl_SearchOrderInfo)this.objController).m_InitListViewInHospitalNo(lvwList);
		}

		private void m_txtInHospitalNo_m_evtFindItem(object sender, string strFindCode, System.Windows.Forms.ListView lvwList)
		{
			if(m_txtInHospitalNo.Text.Trim().Length<12 && m_txtInHospitalNo.Text.Length!=0)
			{
				//m_txtInHospitalNo.Text=m_txtInHospitalNo.Text.PadLeft(12,'0').Trim();
				strFindCode=m_txtInHospitalNo.Text.Trim();
			}
			((clsCtl_SearchOrderInfo)this.objController).m_FindItemInHospitalNo(strFindCode,lvwList);
		}
		public void AutoActicate(string InpatientID)
		{
			((clsCtl_SearchOrderInfo)this.objController).SetpatientInfo(InpatientID);
		}

		private void m_txtInHospitalNo_m_evtSelectItem(object sender, System.Windows.Forms.ListViewItem lviSelected)
		{
			((clsCtl_SearchOrderInfo)this.objController).m_SelectItemInHospitalNo(lviSelected);
			//@cmdFindOrder.Focus();
			/** @update by xzf (05-09-30) */
			this.cmdFindOrder_Click(sender,null);
			/* <<===================================== */
		}

		private void m_txtArea_m_evtInitListView(System.Windows.Forms.ListView lvwList)
		{
			((clsCtl_SearchOrderInfo)this.objController).m_InitListViewArea(lvwList);
		}

		private void m_txtArea_m_evtFindItem(object sender, string strFindCode, System.Windows.Forms.ListView lvwList)
		{
			((clsCtl_SearchOrderInfo)this.objController).m_FindItemArea(strFindCode,lvwList);		
		}

		private void m_txtArea_m_evtSelectItem(object sender, System.Windows.Forms.ListViewItem lviSelected)
		{
			((clsCtl_SearchOrderInfo)this.objController).m_SelectItemArea(lviSelected);		
		}

		private void m_txtBedNo_m_evtInitListView(System.Windows.Forms.ListView lvwList)
		{
			((clsCtl_SearchOrderInfo)this.objController).m_InitListViewInHospitalNo(lvwList);		
		}

		private void m_txtBedNo_m_evtFindItem(object sender, string strFindCode, System.Windows.Forms.ListView lvwList)
		{
			((clsCtl_SearchOrderInfo)this.objController).m_FindItemBed(strFindCode,lvwList);				
		}

		private void m_txtBedNo_m_evtSelectItem(object sender, System.Windows.Forms.ListViewItem lviSelected)
		{
			((clsCtl_SearchOrderInfo)this.objController).m_SelectItemBed(lviSelected);	
			//@cmdFindOrder.Focus();
			/** @update by xzf (05-09-30) */
			this.cmdFindOrder_Click(sender,null);
			/* <<===================================== */
		}
		private void splitter1_DoubleClick(object sender, System.EventArgs e)
		{
			if(splitter1.SplitPosition<500)
				splitter1.SplitPosition =1300;
			else
				splitter1.SplitPosition =splitter1.MinSize;
		}
		#endregion
		#region 查询医嘱
		private void m_cobFindTpye_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			((clsCtl_SearchOrderInfo)this.objController).m_SetFindOrderCondition();
		}
		public void cmdFindOrder_Click(object sender, System.EventArgs e)
		{
			bool blnIsCheckBox =(sender is System.Windows.Forms.CheckBox);
			this.Cursor =Cursors.WaitCursor;
			((clsCtl_SearchOrderInfo)this.objController).m_FindOrder(!blnIsCheckBox);
			this.Cursor =Cursors.Default;
		}
		private void m_lsvOrder_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			((clsCtl_SearchOrderInfo)this.objController).m_SelectedIndexChangedOrder();
		}
		#endregion

		#region 打印
		private void cmdPrintOrder_Click(object sender, System.EventArgs e)
		{
			((clsCtl_SearchOrderInfo)this.objController).m_PrintOrder();
		}
		#endregion
		
		/** @add by xzf (05-09-29) */
		private void m_txtBedNo_TextChanged(object sender, System.EventArgs e)
		{
			if (this.m_txtBedNo.Text.Trim() == "") 
			{
				//this.m_txtBedNo.Tag = null;
			}
		}
		
		/** @add by xzf )05-09-30) */
		private void cbo_bihHistory_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			((clsCtl_SearchOrderInfo)this.objController).cbo_bihHistorySelectedIndexChanged();
		}

		private void m_lsvApplyInfo_DoubleClick(object sender, System.EventArgs e)
		{
		((clsCtl_SearchOrderInfo)this.objController).m_mthShowApplyInfo();
		}

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

	}
}
