using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmStoreInOrdMed 的摘要说明。
	/// </summary>
	public class frmStoreInOrdMed : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private System.Windows.Forms.ColumnHeader MEDICINENAME_CHR;
		private System.Windows.Forms.ColumnHeader UNITID_CHR;
		private System.Windows.Forms.ColumnHeader ROWNO_CHR;
		private System.Windows.Forms.ColumnHeader MEDICINEID_CHR;
		private System.Windows.Forms.ColumnHeader QTY_DEC;
		internal System.Windows.Forms.Panel panel6;
		internal PinkieControls.ButtonXP btnColes;
		internal PinkieControls.ButtonXP btnFinddata;
		private System.Windows.Forms.ColumnHeader col7;
		private System.Windows.Forms.ColumnHeader CURPRICE_MNY;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel5;
		internal System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label12;
		internal System.Windows.Forms.TextBox m_txtMemo;
		private System.Windows.Forms.Label label4;
		internal System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label7;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtUNIT;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox3;
		internal PinkieControls.ButtonXP dntEmp;
		internal PinkieControls.ButtonXP btnesc;
		internal PinkieControls.ButtonXP btnDelect;
		internal PinkieControls.ButtonXP btnFind;
		internal PinkieControls.ButtonXP btnSave;
		internal PinkieControls.ButtonXP m_btnNew;
		internal System.Windows.Forms.ListView LSVInOrdDe;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TabPage tab1;
		private System.Windows.Forms.TabPage tab2;
		internal System.Windows.Forms.ListView LSVInOrdEmp;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		internal System.Windows.Forms.TabControl tabInOrd;
		internal System.Windows.Forms.ListView LSVInord;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.Label label14;
		internal System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label5;
		internal PinkieControls.ButtonXP btnClear;
		internal PinkieControls.ButtonXP btnAdd;
		private System.Windows.Forms.ColumnHeader space;
		internal SourceLibrary.Windows.Forms.TextBoxTyped txtmedicine;
		internal System.Windows.Forms.Label label3;
		internal System.Windows.Forms.ComboBox m_cboSelPeriod;
		internal System.Windows.Forms.ErrorProvider errorProvider1;
		internal System.Windows.Forms.Label comboType;
		private System.Windows.Forms.Label label2;
		internal System.Windows.Forms.Label m_lbStroage;
		private System.Windows.Forms.Label label6;
		internal System.Windows.Forms.Label m_lblCreage;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		internal System.Windows.Forms.Label txtTolmoney;
		internal NullableDateControls.MaskDateEdit dateTime;
		private System.Windows.Forms.Label label29;
		internal System.Windows.Forms.Label m_lblSpace;
		private System.Windows.Forms.Label label31;
		internal System.Windows.Forms.Label lblWorkShop;
		internal System.Windows.Forms.Label label33;
		internal System.Windows.Forms.Label lblUnit;
		internal System.Windows.Forms.Label txtbuyprice;
		internal System.Windows.Forms.Label lblUnit1;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label34;
		internal System.Windows.Forms.ComboBox m_cboFind;
		private System.Windows.Forms.Label label36;
		internal SourceLibrary.Windows.Forms.TextBoxTyped textBoxTyped1;
		internal System.Windows.Forms.TextBox m_txtSrcNO;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label15;
		internal com.digitalwave.iCare.gui.HIS.exComboBox m_cboIPCal;
		internal System.Windows.Forms.Label label16;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		internal System.Windows.Forms.Label label17;
		internal NullableDateControls.MaskDateEdit ctlValidityDate;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.ColumnHeader columnHeader12;
		private System.Windows.Forms.ColumnHeader columnHeader13;
		internal System.Windows.Forms.Label DetotalMoney;
		internal com.digitalwave.controls.ControlMedicineFind ctlShowMed;
		internal System.Windows.Forms.TextBox m_txtMedNo;
		internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric txttol;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label22;
		internal System.Windows.Forms.Label totailCoun;
		private System.Windows.Forms.Label label37;
		internal System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label35;
		internal System.Windows.Forms.Label label38;
		internal System.Windows.Forms.Label label39;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		/// <summary>
		/// 构做函数
		/// </summary>
		public frmStoreInOrdMed()
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

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.MEDICINENAME_CHR = new System.Windows.Forms.ColumnHeader();
			this.UNITID_CHR = new System.Windows.Forms.ColumnHeader();
			this.ROWNO_CHR = new System.Windows.Forms.ColumnHeader();
			this.MEDICINEID_CHR = new System.Windows.Forms.ColumnHeader();
			this.QTY_DEC = new System.Windows.Forms.ColumnHeader();
			this.panel6 = new System.Windows.Forms.Panel();
			this.textBoxTyped1 = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.label36 = new System.Windows.Forms.Label();
			this.m_cboFind = new System.Windows.Forms.ComboBox();
			this.btnColes = new PinkieControls.ButtonXP();
			this.btnFinddata = new PinkieControls.ButtonXP();
			this.col7 = new System.Windows.Forms.ColumnHeader();
			this.CURPRICE_MNY = new System.Windows.Forms.ColumnHeader();
			this.panel1 = new System.Windows.Forms.Panel();
			this.ctlShowMed = new com.digitalwave.controls.ControlMedicineFind();
			this.panel5 = new System.Windows.Forms.Panel();
			this.m_cboSelPeriod = new System.Windows.Forms.ComboBox();
			this.tabInOrd = new System.Windows.Forms.TabControl();
			this.tab1 = new System.Windows.Forms.TabPage();
			this.LSVInord = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.tab2 = new System.Windows.Forms.TabPage();
			this.LSVInOrdEmp = new System.Windows.Forms.ListView();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.panel4 = new System.Windows.Forms.Panel();
			this.label16 = new System.Windows.Forms.Label();
			this.m_cboIPCal = new com.digitalwave.iCare.gui.HIS.exComboBox();
			this.label15 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.m_txtSrcNO = new System.Windows.Forms.TextBox();
			this.dateTime = new NullableDateControls.MaskDateEdit();
			this.label10 = new System.Windows.Forms.Label();
			this.txtTolmoney = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.m_lblCreage = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.m_lbStroage = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.comboType = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.m_txtMemo = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label35 = new System.Windows.Forms.Label();
			this.label38 = new System.Windows.Forms.Label();
			this.label39 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.totailCoun = new System.Windows.Forms.Label();
			this.label37 = new System.Windows.Forms.Label();
			this.txttol = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
			this.m_txtMedNo = new System.Windows.Forms.TextBox();
			this.ctlValidityDate = new NullableDateControls.MaskDateEdit();
			this.label17 = new System.Windows.Forms.Label();
			this.label34 = new System.Windows.Forms.Label();
			this.DetotalMoney = new System.Windows.Forms.Label();
			this.label32 = new System.Windows.Forms.Label();
			this.lblUnit1 = new System.Windows.Forms.Label();
			this.txtbuyprice = new System.Windows.Forms.Label();
			this.lblUnit = new System.Windows.Forms.Label();
			this.label31 = new System.Windows.Forms.Label();
			this.lblWorkShop = new System.Windows.Forms.Label();
			this.label33 = new System.Windows.Forms.Label();
			this.label29 = new System.Windows.Forms.Label();
			this.m_lblSpace = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.btnClear = new PinkieControls.ButtonXP();
			this.btnAdd = new PinkieControls.ButtonXP();
			this.label27 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.label28 = new System.Windows.Forms.Label();
			this.txtmedicine = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.label30 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.m_txtUNIT = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.dntEmp = new PinkieControls.ButtonXP();
			this.btnesc = new PinkieControls.ButtonXP();
			this.btnDelect = new PinkieControls.ButtonXP();
			this.btnFind = new PinkieControls.ButtonXP();
			this.btnSave = new PinkieControls.ButtonXP();
			this.m_btnNew = new PinkieControls.ButtonXP();
			this.LSVInOrdDe = new System.Windows.Forms.ListView();
			this.space = new System.Windows.Forms.ColumnHeader();
			this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label11 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider();
			this.panel6.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel5.SuspendLayout();
			this.tabInOrd.SuspendLayout();
			this.tab1.SuspendLayout();
			this.tab2.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// MEDICINENAME_CHR
			// 
			this.MEDICINENAME_CHR.Text = "药品名称";
			this.MEDICINENAME_CHR.Width = 170;
			// 
			// UNITID_CHR
			// 
			this.UNITID_CHR.Text = "单位";
			this.UNITID_CHR.Width = 50;
			// 
			// ROWNO_CHR
			// 
			this.ROWNO_CHR.Text = "行号";
			this.ROWNO_CHR.Width = 0;
			// 
			// MEDICINEID_CHR
			// 
			this.MEDICINEID_CHR.Text = "药品助记码";
			this.MEDICINEID_CHR.Width = 90;
			// 
			// QTY_DEC
			// 
			this.QTY_DEC.Text = "药品数量";
			this.QTY_DEC.Width = 81;
			// 
			// panel6
			// 
			this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel6.Controls.Add(this.textBoxTyped1);
			this.panel6.Controls.Add(this.label36);
			this.panel6.Controls.Add(this.m_cboFind);
			this.panel6.Controls.Add(this.btnColes);
			this.panel6.Controls.Add(this.btnFinddata);
			this.panel6.Location = new System.Drawing.Point(338, 336);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(684, 32);
			this.panel6.TabIndex = 150;
			this.panel6.Visible = false;
			// 
			// textBoxTyped1
			// 
			this.textBoxTyped1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.textBoxTyped1.EnableAutoValidation = true;
			this.textBoxTyped1.EnableEnterKeyValidate = true;
			this.textBoxTyped1.EnableEscapeKeyUndo = true;
			this.textBoxTyped1.EnableLastValidValue = true;
			this.textBoxTyped1.ErrorProvider = null;
			this.textBoxTyped1.ErrorProviderMessage = "Invalid value";
			this.textBoxTyped1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.textBoxTyped1.ForceFormatText = true;
			this.textBoxTyped1.Location = new System.Drawing.Point(240, 5);
			this.textBoxTyped1.Name = "textBoxTyped1";
			this.textBoxTyped1.Size = new System.Drawing.Size(192, 23);
			this.textBoxTyped1.TabIndex = 153;
			this.textBoxTyped1.Text = "";
			// 
			// label36
			// 
			this.label36.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label36.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label36.Location = new System.Drawing.Point(16, 8);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(64, 16);
			this.label36.TabIndex = 152;
			this.label36.Text = "查找方式";
			// 
			// m_cboFind
			// 
			this.m_cboFind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboFind.Items.AddRange(new object[] {
														   "源单据号",
														   "源药库",
														   "创建人",
														   "单据日期"});
			this.m_cboFind.Location = new System.Drawing.Point(80, 5);
			this.m_cboFind.Name = "m_cboFind";
			this.m_cboFind.Size = new System.Drawing.Size(152, 22);
			this.m_cboFind.TabIndex = 151;
			// 
			// btnColes
			// 
			this.btnColes.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btnColes.DefaultScheme = true;
			this.btnColes.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btnColes.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btnColes.Hint = "";
			this.btnColes.Location = new System.Drawing.Point(584, 4);
			this.btnColes.Name = "btnColes";
			this.btnColes.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btnColes.Size = new System.Drawing.Size(72, 24);
			this.btnColes.TabIndex = 16;
			this.btnColes.TabStop = false;
			this.btnColes.Text = "返回(&R)";
			this.btnColes.Click += new System.EventHandler(this.btnColes_Click);
			// 
			// btnFinddata
			// 
			this.btnFinddata.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btnFinddata.DefaultScheme = true;
			this.btnFinddata.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btnFinddata.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btnFinddata.Hint = "";
			this.btnFinddata.Location = new System.Drawing.Point(488, 4);
			this.btnFinddata.Name = "btnFinddata";
			this.btnFinddata.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btnFinddata.Size = new System.Drawing.Size(72, 24);
			this.btnFinddata.TabIndex = 15;
			this.btnFinddata.TabStop = false;
			this.btnFinddata.Text = "查找(&K)";
			this.btnFinddata.Click += new System.EventHandler(this.btnFinddata_Click);
			// 
			// col7
			// 
			this.col7.Text = "零售总额";
			this.col7.Width = 91;
			// 
			// CURPRICE_MNY
			// 
			this.CURPRICE_MNY.Text = "零售价格";
			this.CURPRICE_MNY.Width = 79;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.ctlShowMed);
			this.panel1.Controls.Add(this.panel5);
			this.panel1.Controls.Add(this.panel4);
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Controls.Add(this.groupBox3);
			this.panel1.Controls.Add(this.LSVInOrdDe);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Location = new System.Drawing.Point(0, -10);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1028, 744);
			this.panel1.TabIndex = 149;
			// 
			// ctlShowMed
			// 
			this.ctlShowMed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.ctlShowMed.blIsMedStorage = false;
			this.ctlShowMed.blISOutStorage = false;
			this.ctlShowMed.blRepertory = false;
			this.ctlShowMed.FindMedmode = 0;
			this.ctlShowMed.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.ctlShowMed.intIsReData = 0;
			this.ctlShowMed.isApplMebMod = null;
			this.ctlShowMed.isApplModel = false;
			this.ctlShowMed.isShowFindType = true;
			this.ctlShowMed.IsShowZero = false;
			this.ctlShowMed.Location = new System.Drawing.Point(336, -320);
			this.ctlShowMed.Name = "ctlShowMed";
			this.ctlShowMed.Size = new System.Drawing.Size(688, 352);
			this.ctlShowMed.strMedstorage = null;
			this.ctlShowMed.strSTORAGEID = "-1";
			this.ctlShowMed.TabIndex = 413;
			this.ctlShowMed.Visible = false;
			this.ctlShowMed.m_evtReturnVal += new com.digitalwave.controls.dlgReturnVal(this.ctlShowMed_m_evtReturnVal);
			this.ctlShowMed.e_evtReturnMedStoreOutVal += new com.digitalwave.controls.dlgReturnMedStoreOutVal(this.ctlShowMed_e_evtReturnMedStoreOutVal);
			// 
			// panel5
			// 
			this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel5.Controls.Add(this.m_cboSelPeriod);
			this.panel5.Controls.Add(this.tabInOrd);
			this.panel5.Location = new System.Drawing.Point(0, 8);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(336, 680);
			this.panel5.TabIndex = 148;
			// 
			// m_cboSelPeriod
			// 
			this.m_cboSelPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_cboSelPeriod.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboSelPeriod.Location = new System.Drawing.Point(144, 654);
			this.m_cboSelPeriod.Name = "m_cboSelPeriod";
			this.m_cboSelPeriod.Size = new System.Drawing.Size(184, 22);
			this.m_cboSelPeriod.TabIndex = 62;
			this.m_cboSelPeriod.SelectedIndexChanged += new System.EventHandler(this.m_cboSelPeriod_SelectedIndexChanged);
			// 
			// tabInOrd
			// 
			this.tabInOrd.Alignment = System.Windows.Forms.TabAlignment.Bottom;
			this.tabInOrd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.tabInOrd.Controls.Add(this.tab1);
			this.tabInOrd.Controls.Add(this.tab2);
			this.tabInOrd.ItemSize = new System.Drawing.Size(48, 17);
			this.tabInOrd.Location = new System.Drawing.Point(0, -6);
			this.tabInOrd.Name = "tabInOrd";
			this.tabInOrd.SelectedIndex = 0;
			this.tabInOrd.Size = new System.Drawing.Size(328, 680);
			this.tabInOrd.TabIndex = 20;
			this.tabInOrd.TabStop = false;
			this.tabInOrd.SelectedIndexChanged += new System.EventHandler(this.tabInOrd_SelectedIndexChanged);
			// 
			// tab1
			// 
			this.tab1.Controls.Add(this.LSVInord);
			this.tab1.Location = new System.Drawing.Point(4, 4);
			this.tab1.Name = "tab1";
			this.tab1.Size = new System.Drawing.Size(320, 655);
			this.tab1.TabIndex = 0;
			this.tab1.Text = "未审核";
			// 
			// LSVInord
			// 
			this.LSVInord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.LSVInord.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					   this.columnHeader1,
																					   this.columnHeader9,
																					   this.columnHeader2,
																					   this.columnHeader3,
																					   this.columnHeader4});
			this.LSVInord.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.LSVInord.FullRowSelect = true;
			this.LSVInord.GridLines = true;
			this.LSVInord.HideSelection = false;
			this.LSVInord.Location = new System.Drawing.Point(0, 0);
			this.LSVInord.Name = "LSVInord";
			this.LSVInord.Size = new System.Drawing.Size(328, 656);
			this.LSVInord.Sorting = System.Windows.Forms.SortOrder.Descending;
			this.LSVInord.TabIndex = 24;
			this.LSVInord.View = System.Windows.Forms.View.Details;
			this.LSVInord.Click += new System.EventHandler(this.LSVInord_Click);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "源单据号";
			this.columnHeader1.Width = 100;
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "源药库";
			this.columnHeader9.Width = 80;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "创建人";
			this.columnHeader2.Width = 90;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "单据日期";
			this.columnHeader3.Width = 90;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "总金额";
			this.columnHeader4.Width = 70;
			// 
			// tab2
			// 
			this.tab2.Controls.Add(this.LSVInOrdEmp);
			this.tab2.Location = new System.Drawing.Point(4, 4);
			this.tab2.Name = "tab2";
			this.tab2.Size = new System.Drawing.Size(320, 655);
			this.tab2.TabIndex = 1;
			this.tab2.Text = "已审核";
			this.tab2.Visible = false;
			// 
			// LSVInOrdEmp
			// 
			this.LSVInOrdEmp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.LSVInOrdEmp.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						  this.columnHeader5,
																						  this.columnHeader10,
																						  this.columnHeader7,
																						  this.columnHeader8,
																						  this.columnHeader6});
			this.LSVInOrdEmp.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.LSVInOrdEmp.FullRowSelect = true;
			this.LSVInOrdEmp.GridLines = true;
			this.LSVInOrdEmp.HideSelection = false;
			this.LSVInOrdEmp.Location = new System.Drawing.Point(0, 0);
			this.LSVInOrdEmp.Name = "LSVInOrdEmp";
			this.LSVInOrdEmp.Size = new System.Drawing.Size(328, 656);
			this.LSVInOrdEmp.Sorting = System.Windows.Forms.SortOrder.Descending;
			this.LSVInOrdEmp.TabIndex = 23;
			this.LSVInOrdEmp.View = System.Windows.Forms.View.Details;
			this.LSVInOrdEmp.Click += new System.EventHandler(this.LSVInOrdEmp_Click);
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "源单据号";
			this.columnHeader5.Width = 100;
			// 
			// columnHeader10
			// 
			this.columnHeader10.Text = "源药库";
			this.columnHeader10.Width = 80;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "审核人";
			this.columnHeader7.Width = 90;
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "审核日期";
			this.columnHeader8.Width = 150;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "总金额";
			this.columnHeader6.Width = 70;
			// 
			// panel4
			// 
			this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel4.Controls.Add(this.label16);
			this.panel4.Controls.Add(this.m_cboIPCal);
			this.panel4.Controls.Add(this.label15);
			this.panel4.Controls.Add(this.label13);
			this.panel4.Controls.Add(this.m_txtSrcNO);
			this.panel4.Controls.Add(this.dateTime);
			this.panel4.Controls.Add(this.label10);
			this.panel4.Controls.Add(this.txtTolmoney);
			this.panel4.Controls.Add(this.label9);
			this.panel4.Controls.Add(this.m_lblCreage);
			this.panel4.Controls.Add(this.label6);
			this.panel4.Controls.Add(this.m_lbStroage);
			this.panel4.Controls.Add(this.label2);
			this.panel4.Controls.Add(this.comboType);
			this.panel4.Controls.Add(this.label25);
			this.panel4.Controls.Add(this.label24);
			this.panel4.Controls.Add(this.label14);
			this.panel4.Controls.Add(this.label8);
			this.panel4.Controls.Add(this.label12);
			this.panel4.Controls.Add(this.m_txtMemo);
			this.panel4.Controls.Add(this.label4);
			this.panel4.Location = new System.Drawing.Point(336, 376);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(684, 104);
			this.panel4.TabIndex = 0;
			// 
			// label16
			// 
			this.label16.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label16.Location = new System.Drawing.Point(200, 72);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(32, 23);
			this.label16.TabIndex = 173;
			this.label16.Text = "元";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_cboIPCal
			// 
			this.m_cboIPCal.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_cboIPCal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboIPCal.Location = new System.Drawing.Point(304, 40);
			this.m_cboIPCal.Name = "m_cboIPCal";
			this.m_cboIPCal.Size = new System.Drawing.Size(152, 22);
			this.m_cboIPCal.TabIndex = 1;
			this.m_cboIPCal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cboIPCal_KeyDown);
			this.m_cboIPCal.SelectedIndexChanged += new System.EventHandler(this.m_cboIPCal_SelectedIndexChanged);
			// 
			// label15
			// 
			this.label15.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label15.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label15.Location = new System.Drawing.Point(240, 40);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(64, 16);
			this.label15.TabIndex = 150;
			this.label15.Text = "源 药 库";
			// 
			// label13
			// 
			this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label13.Location = new System.Drawing.Point(16, 40);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(64, 16);
			this.label13.TabIndex = 149;
			this.label13.Text = "源 单 号";
			// 
			// m_txtSrcNO
			// 
			this.m_txtSrcNO.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_txtSrcNO.Location = new System.Drawing.Point(80, 40);
			this.m_txtSrcNO.MaxLength = 20;
			this.m_txtSrcNO.Name = "m_txtSrcNO";
			this.m_txtSrcNO.Size = new System.Drawing.Size(152, 23);
			this.m_txtSrcNO.TabIndex = 0;
			this.m_txtSrcNO.Text = "";
			this.m_txtSrcNO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtSrcNO_KeyDown);
			// 
			// dateTime
			// 
			this.dateTime.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.dateTime.Location = new System.Drawing.Point(544, 40);
			this.dateTime.Mask = "yyyy年MM月dd日";
			this.dateTime.Name = "dateTime";
			this.dateTime.Size = new System.Drawing.Size(128, 23);
			this.dateTime.TabIndex = 3;
			this.dateTime.Text = "";
			this.dateTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dateTime_KeyDown_1);
			this.dateTime.Leave += new System.EventHandler(this.dateTime_Leave);
			this.dateTime.Enter += new System.EventHandler(this.dateTime_Enter);
			// 
			// label10
			// 
			this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label10.Location = new System.Drawing.Point(80, 88);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(120, 1);
			this.label10.TabIndex = 146;
			this.label10.Text = "label10";
			// 
			// txtTolmoney
			// 
			this.txtTolmoney.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtTolmoney.Location = new System.Drawing.Point(80, 72);
			this.txtTolmoney.Name = "txtTolmoney";
			this.txtTolmoney.Size = new System.Drawing.Size(120, 16);
			this.txtTolmoney.TabIndex = 145;
			this.txtTolmoney.Text = "0.00";
			this.txtTolmoney.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label9
			// 
			this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label9.Location = new System.Drawing.Point(544, 24);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(128, 1);
			this.label9.TabIndex = 144;
			this.label9.Text = "label9";
			// 
			// m_lblCreage
			// 
			this.m_lblCreage.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_lblCreage.Location = new System.Drawing.Point(544, 8);
			this.m_lblCreage.Name = "m_lblCreage";
			this.m_lblCreage.Size = new System.Drawing.Size(128, 23);
			this.m_lblCreage.TabIndex = 143;
			// 
			// label6
			// 
			this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label6.Location = new System.Drawing.Point(80, 24);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(152, 1);
			this.label6.TabIndex = 142;
			this.label6.Text = "label6";
			// 
			// m_lbStroage
			// 
			this.m_lbStroage.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_lbStroage.Location = new System.Drawing.Point(80, 8);
			this.m_lbStroage.Name = "m_lbStroage";
			this.m_lbStroage.Size = new System.Drawing.Size(152, 23);
			this.m_lbStroage.TabIndex = 141;
			this.m_lbStroage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label2.Location = new System.Drawing.Point(304, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(152, 1);
			this.label2.TabIndex = 140;
			this.label2.Text = "label2";
			// 
			// comboType
			// 
			this.comboType.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.comboType.Location = new System.Drawing.Point(304, 8);
			this.comboType.Name = "comboType";
			this.comboType.Size = new System.Drawing.Size(152, 23);
			this.comboType.TabIndex = 139;
			this.comboType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label25
			// 
			this.label25.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label25.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label25.Location = new System.Drawing.Point(472, 8);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(64, 16);
			this.label25.TabIndex = 136;
			this.label25.Text = "创 建 人";
			// 
			// label24
			// 
			this.label24.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label24.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label24.Location = new System.Drawing.Point(240, 8);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(64, 16);
			this.label24.TabIndex = 134;
			this.label24.Text = "入库类型";
			// 
			// label14
			// 
			this.label14.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label14.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label14.Location = new System.Drawing.Point(16, 8);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(64, 16);
			this.label14.TabIndex = 132;
			this.label14.Text = "药    房";
			// 
			// label8
			// 
			this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label8.Location = new System.Drawing.Point(16, 72);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(64, 16);
			this.label8.TabIndex = 130;
			this.label8.Text = "总 金 额";
			// 
			// label12
			// 
			this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label12.Location = new System.Drawing.Point(472, 40);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(64, 16);
			this.label12.TabIndex = 118;
			this.label12.Text = "日    期";
			// 
			// m_txtMemo
			// 
			this.m_txtMemo.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_txtMemo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtMemo.Location = new System.Drawing.Point(304, 72);
			this.m_txtMemo.MaxLength = 200;
			this.m_txtMemo.Name = "m_txtMemo";
			this.m_txtMemo.Size = new System.Drawing.Size(368, 23);
			this.m_txtMemo.TabIndex = 5;
			this.m_txtMemo.Text = "";
			this.m_txtMemo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtMemo_KeyDown);
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label4.Location = new System.Drawing.Point(240, 72);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 16);
			this.label4.TabIndex = 117;
			this.label4.Text = "备    注";
			// 
			// panel3
			// 
			this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel3.Controls.Add(this.label35);
			this.panel3.Controls.Add(this.label38);
			this.panel3.Controls.Add(this.label39);
			this.panel3.Controls.Add(this.label22);
			this.panel3.Controls.Add(this.label23);
			this.panel3.Controls.Add(this.totailCoun);
			this.panel3.Controls.Add(this.label37);
			this.panel3.Controls.Add(this.txttol);
			this.panel3.Controls.Add(this.m_txtMedNo);
			this.panel3.Controls.Add(this.ctlValidityDate);
			this.panel3.Controls.Add(this.label17);
			this.panel3.Controls.Add(this.label34);
			this.panel3.Controls.Add(this.DetotalMoney);
			this.panel3.Controls.Add(this.label32);
			this.panel3.Controls.Add(this.lblUnit1);
			this.panel3.Controls.Add(this.txtbuyprice);
			this.panel3.Controls.Add(this.lblUnit);
			this.panel3.Controls.Add(this.label31);
			this.panel3.Controls.Add(this.lblWorkShop);
			this.panel3.Controls.Add(this.label33);
			this.panel3.Controls.Add(this.label29);
			this.panel3.Controls.Add(this.m_lblSpace);
			this.panel3.Controls.Add(this.label3);
			this.panel3.Controls.Add(this.label5);
			this.panel3.Controls.Add(this.btnClear);
			this.panel3.Controls.Add(this.btnAdd);
			this.panel3.Controls.Add(this.label27);
			this.panel3.Controls.Add(this.label26);
			this.panel3.Controls.Add(this.label28);
			this.panel3.Controls.Add(this.txtmedicine);
			this.panel3.Controls.Add(this.label30);
			this.panel3.Controls.Add(this.label7);
			this.panel3.Controls.Add(this.m_txtUNIT);
			this.panel3.Controls.Add(this.label1);
			this.panel3.Location = new System.Drawing.Point(336, 480);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(684, 160);
			this.panel3.TabIndex = 1;
			// 
			// label35
			// 
			this.label35.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label35.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label35.Location = new System.Drawing.Point(392, 72);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(96, 1);
			this.label35.TabIndex = 185;
			this.label35.Text = "label35";
			// 
			// label38
			// 
			this.label38.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label38.Location = new System.Drawing.Point(392, 49);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(96, 24);
			this.label38.TabIndex = 184;
			this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label39
			// 
			this.label39.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label39.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label39.Location = new System.Drawing.Point(328, 53);
			this.label39.Name = "label39";
			this.label39.Size = new System.Drawing.Size(64, 16);
			this.label39.TabIndex = 183;
			this.label39.Text = "系统批号";
			// 
			// label22
			// 
			this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label22.Location = new System.Drawing.Point(568, 72);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(64, 1);
			this.label22.TabIndex = 182;
			this.label22.Text = "label22";
			// 
			// label23
			// 
			this.label23.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label23.Location = new System.Drawing.Point(640, 50);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(32, 23);
			this.label23.TabIndex = 181;
			this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// totailCoun
			// 
			this.totailCoun.Location = new System.Drawing.Point(568, 50);
			this.totailCoun.Name = "totailCoun";
			this.totailCoun.Size = new System.Drawing.Size(64, 23);
			this.totailCoun.TabIndex = 180;
			this.totailCoun.Text = "0";
			this.totailCoun.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label37
			// 
			this.label37.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label37.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label37.Location = new System.Drawing.Point(496, 53);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(64, 16);
			this.label37.TabIndex = 179;
			this.label37.Text = "现 库 存";
			// 
			// txttol
			// 
			this.txttol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txttol.EnableAutoValidation = false;
			this.txttol.EnableEnterKeyValidate = true;
			this.txttol.EnableEscapeKeyUndo = true;
			this.txttol.EnableLastValidValue = true;
			this.txttol.ErrorProvider = null;
			this.txttol.ErrorProviderMessage = "Invalid value";
			this.txttol.ForceFormatText = true;
			this.txttol.Location = new System.Drawing.Point(392, 87);
			this.txttol.MaxLength = 5;
			this.txttol.Name = "txttol";
			this.txttol.NumericCharStyle = ((SourceLibrary.Windows.Forms.NumericCharStyle)((SourceLibrary.Windows.Forms.NumericCharStyle.DecimalSeparator | SourceLibrary.Windows.Forms.NumericCharStyle.NegativeSymbol)));
			this.txttol.Size = new System.Drawing.Size(240, 23);
			this.txttol.TabIndex = 3;
			this.txttol.Text = "";
			this.txttol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txttol.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txttol_KeyDown_1);
			this.txttol.Leave += new System.EventHandler(this.txttol_Leave_1);
			// 
			// m_txtMedNo
			// 
			this.m_txtMedNo.Location = new System.Drawing.Point(80, 87);
			this.m_txtMedNo.MaxLength = 20;
			this.m_txtMedNo.Name = "m_txtMedNo";
			this.m_txtMedNo.Size = new System.Drawing.Size(240, 23);
			this.m_txtMedNo.TabIndex = 1;
			this.m_txtMedNo.Text = "";
			this.m_txtMedNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtMedNo_KeyDown);
			// 
			// ctlValidityDate
			// 
			this.ctlValidityDate.Location = new System.Drawing.Point(80, 124);
			this.ctlValidityDate.Mask = "yyyy年MM月dd日";
			this.ctlValidityDate.Name = "ctlValidityDate";
			this.ctlValidityDate.Size = new System.Drawing.Size(120, 23);
			this.ctlValidityDate.TabIndex = 5;
			this.ctlValidityDate.Text = "";
			this.ctlValidityDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ctlValidityDate_KeyDown);
			this.ctlValidityDate.Leave += new System.EventHandler(this.ctlValidityDate_Leave);
			this.ctlValidityDate.Enter += new System.EventHandler(this.ctlValidityDate_Enter);
			// 
			// label17
			// 
			this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label17.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label17.Location = new System.Drawing.Point(16, 127);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(64, 16);
			this.label17.TabIndex = 178;
			this.label17.Text = "失 效 期";
			// 
			// label34
			// 
			this.label34.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label34.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label34.Location = new System.Drawing.Point(392, 144);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(80, 1);
			this.label34.TabIndex = 175;
			this.label34.Text = "label34";
			// 
			// DetotalMoney
			// 
			this.DetotalMoney.Location = new System.Drawing.Point(392, 124);
			this.DetotalMoney.Name = "DetotalMoney";
			this.DetotalMoney.Size = new System.Drawing.Size(80, 23);
			this.DetotalMoney.TabIndex = 174;
			this.DetotalMoney.Text = "0.00";
			this.DetotalMoney.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label32
			// 
			this.label32.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label32.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label32.Location = new System.Drawing.Point(256, 144);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(48, 1);
			this.label32.TabIndex = 173;
			this.label32.Text = "label32";
			// 
			// lblUnit1
			// 
			this.lblUnit1.Location = new System.Drawing.Point(296, 124);
			this.lblUnit1.Name = "lblUnit1";
			this.lblUnit1.Size = new System.Drawing.Size(32, 23);
			this.lblUnit1.TabIndex = 172;
			this.lblUnit1.Text = "元";
			this.lblUnit1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtbuyprice
			// 
			this.txtbuyprice.Location = new System.Drawing.Point(256, 124);
			this.txtbuyprice.Name = "txtbuyprice";
			this.txtbuyprice.Size = new System.Drawing.Size(48, 23);
			this.txtbuyprice.TabIndex = 171;
			this.txtbuyprice.Text = "0.00";
			this.txtbuyprice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblUnit
			// 
			this.lblUnit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblUnit.Location = new System.Drawing.Point(640, 87);
			this.lblUnit.Name = "lblUnit";
			this.lblUnit.Size = new System.Drawing.Size(32, 23);
			this.lblUnit.TabIndex = 170;
			this.lblUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label31
			// 
			this.label31.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label31.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label31.Location = new System.Drawing.Point(80, 72);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(240, 1);
			this.label31.TabIndex = 169;
			this.label31.Text = "label31";
			// 
			// lblWorkShop
			// 
			this.lblWorkShop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblWorkShop.Location = new System.Drawing.Point(80, 49);
			this.lblWorkShop.Name = "lblWorkShop";
			this.lblWorkShop.Size = new System.Drawing.Size(240, 24);
			this.lblWorkShop.TabIndex = 168;
			this.lblWorkShop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label33
			// 
			this.label33.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label33.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label33.Location = new System.Drawing.Point(16, 53);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(64, 16);
			this.label33.TabIndex = 167;
			this.label33.Text = "生产厂家";
			// 
			// label29
			// 
			this.label29.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label29.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label29.Location = new System.Drawing.Point(392, 32);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(280, 1);
			this.label29.TabIndex = 166;
			this.label29.Text = "label29";
			// 
			// m_lblSpace
			// 
			this.m_lblSpace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_lblSpace.Location = new System.Drawing.Point(392, 12);
			this.m_lblSpace.Name = "m_lblSpace";
			this.m_lblSpace.Size = new System.Drawing.Size(280, 24);
			this.m_lblSpace.TabIndex = 165;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label3.Location = new System.Drawing.Point(328, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 164;
			this.label3.Text = "规    格";
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label5.Location = new System.Drawing.Point(328, 127);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 16);
			this.label5.TabIndex = 162;
			this.label5.Text = "零售总额";
			// 
			// btnClear
			// 
			this.btnClear.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btnClear.DefaultScheme = true;
			this.btnClear.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btnClear.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btnClear.Hint = "";
			this.btnClear.Location = new System.Drawing.Point(584, 123);
			this.btnClear.Name = "btnClear";
			this.btnClear.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btnClear.Size = new System.Drawing.Size(72, 24);
			this.btnClear.TabIndex = 160;
			this.btnClear.TabStop = false;
			this.btnClear.Text = "清空(&C)";
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btnAdd.DefaultScheme = true;
			this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btnAdd.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btnAdd.Hint = "";
			this.btnAdd.Location = new System.Drawing.Point(488, 123);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btnAdd.Size = new System.Drawing.Size(72, 24);
			this.btnAdd.TabIndex = 7;
			this.btnAdd.TabStop = false;
			this.btnAdd.Text = "增加(&A)";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// label27
			// 
			this.label27.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label27.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label27.Location = new System.Drawing.Point(328, 90);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(75, 16);
			this.label27.TabIndex = 156;
			this.label27.Text = "数    量";
			// 
			// label26
			// 
			this.label26.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label26.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label26.Location = new System.Drawing.Point(200, 127);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(64, 16);
			this.label26.TabIndex = 154;
			this.label26.Text = "零售价格";
			// 
			// label28
			// 
			this.label28.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label28.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label28.Location = new System.Drawing.Point(16, 90);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(64, 16);
			this.label28.TabIndex = 152;
			this.label28.Text = "药品批号";
			// 
			// txtmedicine
			// 
			this.txtmedicine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txtmedicine.EnableAutoValidation = true;
			this.txtmedicine.EnableEnterKeyValidate = true;
			this.txtmedicine.EnableEscapeKeyUndo = true;
			this.txtmedicine.EnableLastValidValue = true;
			this.txtmedicine.ErrorProvider = null;
			this.txtmedicine.ErrorProviderMessage = "Invalid value";
			this.txtmedicine.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtmedicine.ForceFormatText = true;
			this.txtmedicine.Location = new System.Drawing.Point(80, 13);
			this.txtmedicine.MaxLength = 1;
			this.txtmedicine.Name = "txtmedicine";
			this.txtmedicine.Size = new System.Drawing.Size(240, 23);
			this.txtmedicine.TabIndex = 0;
			this.txtmedicine.Text = "";
			this.txtmedicine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmedicine_KeyDown);
			// 
			// label30
			// 
			this.label30.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label30.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label30.Location = new System.Drawing.Point(16, 16);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(64, 16);
			this.label30.TabIndex = 148;
			this.label30.Text = "药品名称";
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label7.Location = new System.Drawing.Point(232, 160);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(56, 16);
			this.label7.TabIndex = 123;
			this.label7.Text = "药品名称";
			// 
			// m_txtUNIT
			// 
			this.m_txtUNIT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_txtUNIT.EnableAutoValidation = true;
			this.m_txtUNIT.Enabled = false;
			this.m_txtUNIT.EnableEnterKeyValidate = true;
			this.m_txtUNIT.EnableEscapeKeyUndo = true;
			this.m_txtUNIT.EnableLastValidValue = true;
			this.m_txtUNIT.ErrorProvider = null;
			this.m_txtUNIT.ErrorProviderMessage = "Invalid value";
			this.m_txtUNIT.ForceFormatText = true;
			this.m_txtUNIT.Location = new System.Drawing.Point(80, 200);
			this.m_txtUNIT.Name = "m_txtUNIT";
			this.m_txtUNIT.Size = new System.Drawing.Size(104, 23);
			this.m_txtUNIT.TabIndex = 5;
			this.m_txtUNIT.Text = "";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.Location = new System.Drawing.Point(16, 200);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 16);
			this.label1.TabIndex = 116;
			this.label1.Text = "单    位";
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.dntEmp);
			this.groupBox3.Controls.Add(this.btnesc);
			this.groupBox3.Controls.Add(this.btnDelect);
			this.groupBox3.Controls.Add(this.btnFind);
			this.groupBox3.Controls.Add(this.btnSave);
			this.groupBox3.Controls.Add(this.m_btnNew);
			this.groupBox3.Location = new System.Drawing.Point(336, 640);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(684, 48);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			// 
			// dntEmp
			// 
			this.dntEmp.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.dntEmp.DefaultScheme = true;
			this.dntEmp.DialogResult = System.Windows.Forms.DialogResult.None;
			this.dntEmp.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.dntEmp.Hint = "";
			this.dntEmp.Location = new System.Drawing.Point(272, 16);
			this.dntEmp.Name = "dntEmp";
			this.dntEmp.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.dntEmp.Size = new System.Drawing.Size(72, 24);
			this.dntEmp.TabIndex = 54;
			this.dntEmp.TabStop = false;
			this.dntEmp.Text = "审核(&P)";
			this.dntEmp.Click += new System.EventHandler(this.dntEmp_Click);
			// 
			// btnesc
			// 
			this.btnesc.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btnesc.DefaultScheme = true;
			this.btnesc.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnesc.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btnesc.Hint = "";
			this.btnesc.Location = new System.Drawing.Point(584, 16);
			this.btnesc.Name = "btnesc";
			this.btnesc.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btnesc.Size = new System.Drawing.Size(72, 24);
			this.btnesc.TabIndex = 53;
			this.btnesc.TabStop = false;
			this.btnesc.Text = "退出(ESE)";
			this.btnesc.Click += new System.EventHandler(this.btnesc_Click);
			// 
			// btnDelect
			// 
			this.btnDelect.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btnDelect.DefaultScheme = true;
			this.btnDelect.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btnDelect.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btnDelect.Hint = "";
			this.btnDelect.Location = new System.Drawing.Point(488, 16);
			this.btnDelect.Name = "btnDelect";
			this.btnDelect.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btnDelect.Size = new System.Drawing.Size(72, 24);
			this.btnDelect.TabIndex = 52;
			this.btnDelect.TabStop = false;
			this.btnDelect.Text = "删除(&D)";
			this.btnDelect.Click += new System.EventHandler(this.btnDelect_Click);
			// 
			// btnFind
			// 
			this.btnFind.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btnFind.DefaultScheme = true;
			this.btnFind.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btnFind.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btnFind.Hint = "";
			this.btnFind.Location = new System.Drawing.Point(384, 16);
			this.btnFind.Name = "btnFind";
			this.btnFind.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btnFind.Size = new System.Drawing.Size(72, 24);
			this.btnFind.TabIndex = 51;
			this.btnFind.TabStop = false;
			this.btnFind.Text = "查找(&F)";
			this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
			// 
			// btnSave
			// 
			this.btnSave.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btnSave.DefaultScheme = true;
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btnSave.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btnSave.Hint = "";
			this.btnSave.Location = new System.Drawing.Point(168, 16);
			this.btnSave.Name = "btnSave";
			this.btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btnSave.Size = new System.Drawing.Size(72, 24);
			this.btnSave.TabIndex = 17;
			this.btnSave.TabStop = false;
			this.btnSave.Text = "保存(&S)";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// m_btnNew
			// 
			this.m_btnNew.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnNew.DefaultScheme = true;
			this.m_btnNew.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnNew.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_btnNew.Hint = "";
			this.m_btnNew.Location = new System.Drawing.Point(64, 16);
			this.m_btnNew.Name = "m_btnNew";
			this.m_btnNew.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnNew.Size = new System.Drawing.Size(72, 24);
			this.m_btnNew.TabIndex = 49;
			this.m_btnNew.TabStop = false;
			this.m_btnNew.Text = "新建(&N)";
			this.m_btnNew.Click += new System.EventHandler(this.m_btnNew_Click);
			// 
			// LSVInOrdDe
			// 
			this.LSVInOrdDe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.LSVInOrdDe.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						 this.ROWNO_CHR,
																						 this.MEDICINEID_CHR,
																						 this.MEDICINENAME_CHR,
																						 this.space,
																						 this.columnHeader11,
																						 this.UNITID_CHR,
																						 this.QTY_DEC,
																						 this.CURPRICE_MNY,
																						 this.col7,
																						 this.columnHeader12,
																						 this.columnHeader13});
			this.LSVInOrdDe.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.LSVInOrdDe.FullRowSelect = true;
			this.LSVInOrdDe.GridLines = true;
			this.LSVInOrdDe.HideSelection = false;
			this.LSVInOrdDe.Location = new System.Drawing.Point(336, 8);
			this.LSVInOrdDe.Name = "LSVInOrdDe";
			this.LSVInOrdDe.Size = new System.Drawing.Size(684, 368);
			this.LSVInOrdDe.TabIndex = 21;
			this.LSVInOrdDe.View = System.Windows.Forms.View.Details;
			this.LSVInOrdDe.Click += new System.EventHandler(this.LSVInOrdDe_Click);
			// 
			// space
			// 
			this.space.Text = "规格";
			this.space.Width = 130;
			// 
			// columnHeader11
			// 
			this.columnHeader11.Text = "生产厂家";
			this.columnHeader11.Width = 120;
			// 
			// columnHeader12
			// 
			this.columnHeader12.Text = "失效日期";
			this.columnHeader12.Width = 100;
			// 
			// columnHeader13
			// 
			this.columnHeader13.Text = "药品批号";
			this.columnHeader13.Width = 100;
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel2.Controls.Add(this.label11);
			this.panel2.Controls.Add(this.label21);
			this.panel2.Controls.Add(this.label20);
			this.panel2.Controls.Add(this.label19);
			this.panel2.Controls.Add(this.label18);
			this.panel2.Location = new System.Drawing.Point(0, 696);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1028, 32);
			this.panel2.TabIndex = 1;
			// 
			// label11
			// 
			this.label11.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label11.ForeColor = System.Drawing.SystemColors.Desktop;
			this.label11.Location = new System.Drawing.Point(696, 0);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(152, 23);
			this.label11.TabIndex = 4;
			this.label11.Text = "Alt+T选择财务期";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label21
			// 
			this.label21.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label21.ForeColor = System.Drawing.SystemColors.Desktop;
			this.label21.Location = new System.Drawing.Point(112, 0);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(136, 23);
			this.label21.TabIndex = 3;
			this.label21.Text = "Alt+L选中明细窗体";
			this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label20
			// 
			this.label20.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label20.ForeColor = System.Drawing.SystemColors.Desktop;
			this.label20.Location = new System.Drawing.Point(496, 0);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(152, 23);
			this.label20.TabIndex = 2;
			this.label20.Text = "Alt+O选中己审核窗体";
			this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label19
			// 
			this.label19.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label19.ForeColor = System.Drawing.SystemColors.Desktop;
			this.label19.Location = new System.Drawing.Point(296, 0);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(152, 23);
			this.label19.TabIndex = 1;
			this.label19.Text = "Alt+V选中未审核窗体";
			this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label18
			// 
			this.label18.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label18.ForeColor = System.Drawing.SystemColors.Desktop;
			this.label18.Location = new System.Drawing.Point(8, 0);
			this.label18.Name = "label18";
			this.label18.TabIndex = 0;
			this.label18.Text = "快捷键提示:";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			// 
			// frmStoreInOrdMed
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(1028, 725);
			this.Controls.Add(this.panel6);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.Name = "frmStoreInOrdMed";
			this.Text = "";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmStoreInOrdMed_KeyDown);
			this.Load += new System.EventHandler(this.frmStoreInOrdMed_Load);
			this.panel6.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.tabInOrd.ResumeLayout(false);
			this.tab1.ResumeLayout(false);
			this.tab2.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		/// <summary>
		/// 
		/// </summary>
		public override void CreateController()
		{
			this.objController = new clsContorlStoreInOrdMed();
			this.objController.Set_GUI_Apperance(this);
		}
		/// <summary>
		/// 出入标志，2-出库,1-入库,3-调拔入库，4调拔出库
		/// </summary>
		public int intSIGN_INT;
		public void SendOrdType(string ordType,string storageID)
		{
			clsDomainControlMedStore Domain=new clsDomainControlMedStore();
			DataTable dtbStorage=new DataTable();
			string strTypeName="";
			string strStorageName="";
			
			Domain.m_lngGetTypeAndStorage(ordType,storageID,out strTypeName,out intSIGN_INT,out strStorageName);
			if(strTypeName!=""||strStorageName!="")
			{
				label24.Tag=intSIGN_INT;
				comboType.Tag=ordType;
				comboType.Text=strTypeName;
				this.m_lbStroage.Text=strStorageName;
				this.m_lbStroage.Tag=storageID;
				this.Text+="-"+strStorageName;
			}
			else
			{
				MessageBox.Show("传入的‘进药类型ID’或‘药房ID’不正确！","icare",MessageBoxButtons.OK,MessageBoxIcon.Stop);
				return;
			}
			this.Show();
		}

		private void frmStoreInOrdMed_Load(object sender, System.EventArgs e)
		{
			switch(intSIGN_INT)
			{
				case 1:
					this.Text="药房入库模块-"+comboType.Text;
					ctlShowMed.blISOutStorage=true;
					ctlShowMed.blIsMedStorage=true;
					ctlShowMed.blRepertory=true;
					break;
				case 2:
					this.Text="药房出库模块-"+comboType.Text;
					label24.Text="出库类型";
					label15.Text="收货药库";
					label13.Text="出库单号";
					LSVInord.Columns[0].Text="出库单号";
					LSVInord.Columns[1].Text="收货药库";
					LSVInOrdEmp.Columns[0].Text="出库单号";
					LSVInOrdEmp.Columns[1].Text="收货药库";
					ctlShowMed.blISOutStorage=true;
					break;
				case 3:
					this.Text="药房调拔入库模块-"+comboType.Text;
					label24.Text="调拔类型";
					label15.Text="源药房";
					label13.Text="调拔单号";
					LSVInord.Columns[0].Text="调拔单号";
					LSVInord.Columns[1].Text="源药房";
					LSVInOrdEmp.Columns[0].Text="调拔单号";
					LSVInOrdEmp.Columns[1].Text="源药房";
					ctlShowMed.blISOutStorage=true;
					break;
				case 4:
					this.Text="药房调拔出库模块-"+comboType.Text;
					label24.Text="调拔类型";
					label15.Text="收货药房";
					label13.Text="调拔单号";
					LSVInord.Columns[0].Text="调拔单号";
					LSVInord.Columns[1].Text="收货药房";
					LSVInOrdEmp.Columns[0].Text="调拔单号";
					LSVInOrdEmp.Columns[1].Text="收货药房";
					ctlShowMed.blISOutStorage=true;
					break;
			}
			((clsContorlStoreInOrdMed)this.objController).m_lngFrmLoad();
			this.m_mthSetEnter2Tab(new System.Windows.Forms.Control[] {});
			ctlShowMed.intIsReData=0;
			ctlShowMed.strSTORAGEID=(string)m_lbStroage.Tag;
			clsDomainControlMedStore domain=new clsDomainControlMedStore();
			string ScrNO="";
			domain.m_lngGetScrNO(out ScrNO);
			m_txtSrcNO.Text=clsMedStorePublic.m_mthGetNewDocument(ScrNO);
			DataTable dtStore=new DataTable();
			if((int)label24.Tag==1||(int)label24.Tag==2)
			{
				domain.m_lngGetStore(out dtStore);
				if(dtStore.Rows.Count>0)
				{
					for(int i1=0;i1<dtStore.Rows.Count;i1++)
					{
						m_cboIPCal.Item.Add(dtStore.Rows[i1]["STORAGENAME_VCHR"].ToString(),dtStore.Rows[i1]["STORAGEID_CHR"].ToString());
					}
					m_cboIPCal.Item.Add("","");
				}
			}
			else
			{
				domain.m_lngGetMedStore(out dtStore);
				if(dtStore.Rows.Count>0)
				{
					for(int i1=0;i1<dtStore.Rows.Count;i1++)
					{
						m_cboIPCal.Item.Add(dtStore.Rows[i1]["MEDSTORENAME_VCHR"].ToString(),dtStore.Rows[i1]["MEDSTOREID_CHR"].ToString());
					}
					m_cboIPCal.Item.Add("","");
				}
			}
		}

		clsMedStorePublic publicClass=new clsMedStorePublic();
		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			if(txtmedicine.Text==""||(string)txtmedicine.Tag=="")
			{
				publicClass.m_mthShowWarning(txtmedicine,"请先选择药品!");
				txtmedicine.Focus();
				return;
			}
			if(m_txtMedNo.Text=="")
			{
				publicClass.m_mthShowWarning(m_txtMedNo,"药品数量不能为空或'0'!");
				m_txtMedNo.Focus();
				return;
			}
			if(txttol.Text.Trim()=="0"||txttol.Text=="")
			{
				publicClass.m_mthShowWarning(txtmedicine,"药品数量不能为空或'0'!");
				txttol.Focus();
				return;
			}
			((clsContorlStoreInOrdMed)this.objController).m_lngAddClick();
		}

		private void txtSysNo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
				this.txttol.Focus();
		}

		private void txttol_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				ctlValidityDate.Focus();
			}
		}

		private void btnClear_Click(object sender, System.EventArgs e)
		{
		       ((clsContorlStoreInOrdMed)this.objController).m_lngClear(1);
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{

			  ((clsContorlStoreInOrdMed)this.objController).m_lngSaveClick();
		}

		private void comboType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			((clsContorlStoreInOrdMed)this.objController).m_lngSeleChang(1);
		}

		private void comboStroage_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			((clsContorlStoreInOrdMed)this.objController).m_lngSeleChang(2);
		}

		private void LSVInOrdDe_Click(object sender, System.EventArgs e)
		{
			((clsContorlStoreInOrdMed)this.objController).m_lngFillTxtboxOrdDe();
			txtmedicine.Focus();
		}

		private void btnesc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void m_btnNew_Click(object sender, System.EventArgs e)
		{
			 ((clsContorlStoreInOrdMed)this.objController).m_lngClear(2);
		}

		private void btnDelect_Click(object sender, System.EventArgs e)
		{

			((clsContorlStoreInOrdMed)this.objController).m_lngDeleClick();
		}

		private void tabInOrd_SelectedIndexChanged(object sender, System.EventArgs e)
		{

			if(tabInOrd.SelectedIndex==1)
			{
				this.panel4.Enabled=false;
				this.panel3.Enabled=false;
				this.m_btnNew.Enabled=false;
				this.btnSave.Enabled=false;
				this.dntEmp.Enabled=false;
				this.btnDelect.Enabled=false;
				((clsContorlStoreInOrdMed)this.objController).m_lngClear(2);

			}
			else
			{
				this.panel4.Enabled=true;
				this.panel3.Enabled=true;
				this.m_btnNew.Enabled=true;
				this.btnSave.Enabled=true;
				this.dntEmp.Enabled=true;
				this.btnDelect.Enabled=true;
				if(LSVInord.SelectedItems.Count>0)
				{
					((clsContorlStoreInOrdMed)this.objController).m_lngShowDeBySelete();
					m_txtSrcNO.Focus();
				}
				else
				{
					LSVInOrdDe.Items.Clear();
					((clsContorlStoreInOrdMed)this.objController).m_lngClear(2);
				}
			}
		}

		private void btnFind_Click(object sender, System.EventArgs e)
		{
			if(this.panel6.Visible==false)
			{
				this.panel6.Top=this.panel4.Top-this.panel6.Height-8;
				LSVInOrdDe.Height=LSVInOrdDe.Height-this.panel6.Height;
				this.panel6.Left=this.panel4.Left+2;
				this.panel6.Visible=true;
			}
			this.m_cboFind.Focus();
		}

		private void txtSysNo_Enter(object sender, System.EventArgs e)
		{

		}

		private void btnFinddata_Click(object sender, System.EventArgs e)
		{
			((clsContorlStoreInOrdMed)this.objController).m_lngFindClick();
		}

		private void btnColes_Click(object sender, System.EventArgs e)
		{
			LSVInOrdDe.Height=LSVInOrdDe.Height+this.panel6.Height;
			((clsContorlStoreInOrdMed)this.objController).m_lngReturnClick();
		}

		private void dntEmp_Click(object sender, System.EventArgs e)
		{
			((clsContorlStoreInOrdMed)this.objController).m_lngAduiClick();
			ctlShowMed.intIsReData=1;
		}

		private void comboType_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.F1)
			{

				((clsContorlStoreInOrdMed)this.objController).m_lngClear(2);
			}
			if(e.KeyCode==Keys.F2)
			{
				((clsContorlStoreInOrdMed)this.objController).m_lngSaveClick();
			}
			if(e.KeyCode==Keys.F3)
			{
				((clsContorlStoreInOrdMed)this.objController).m_lngAduiClick();
			}
			if(e.KeyCode==Keys.F4)
			{
				this.panel6.Top=this.panel4.Top-this.panel6.Height-13;
				this.panel6.Left=this.panel4.Left+2;
				this.panel6.Visible=true;
			}

			if(e.KeyCode==Keys.F5)
			{

				((clsContorlStoreInOrdMed)this.objController).m_lngDeleClick();
			}
			if(e.KeyCode==Keys.Escape)
			{
				this.Close();
			}

			if(e.KeyCode==Keys.F6)
			{
				this.tabInOrd.SelectedIndex=0;
				if(this.LSVInord.Items.Count>0)
				{
					this.LSVInord.Items[0].Selected=true;
				}
			}
			if(e.KeyCode==Keys.F7)
			{
				this.tabInOrd.SelectedIndex=1;
				if(this.LSVInOrdEmp.Items.Count>0)
				{
					this.LSVInOrdEmp.Items[0].Selected=true;
				}
			}

			if(e.KeyCode==Keys.F8)
			{
				if(this.LSVInOrdDe.Items.Count>0)
				{
					this.LSVInOrdDe.Items[0].Selected=true;
				}
			}
			if(e.KeyCode==Keys.F9)
			{
//				txtfind.Focus();
			}
			if(e.KeyCode==Keys.F10)
			{
//				TextID.Focus();
			}
			this.m_mthSetKeyTab(e);
		}

		private void comboStroage_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.F1)
			{

				((clsContorlStoreInOrdMed)this.objController).m_lngClear(2);
			}
			if(e.KeyCode==Keys.F2)
			{
				((clsContorlStoreInOrdMed)this.objController).m_lngSaveClick();
			}
			if(e.KeyCode==Keys.F3)
			{
				((clsContorlStoreInOrdMed)this.objController).m_lngAduiClick();
			}
			if(e.KeyCode==Keys.F4)
			{
				this.panel6.Top=this.panel4.Top-this.panel6.Height-13;
				this.panel6.Left=this.panel4.Left+2;
				this.panel6.Visible=true;
			}

			if(e.KeyCode==Keys.F5)
			{
				((clsContorlStoreInOrdMed)this.objController).m_lngDeleClick();
			}
			if(e.KeyCode==Keys.Escape)
			{
				this.Close();
			}

			if(e.KeyCode==Keys.F6)
			{
				this.tabInOrd.SelectedIndex=0;
				if(this.LSVInord.Items.Count>0)
				{
					this.LSVInord.Items[0].Selected=true;
				}
			}
			if(e.KeyCode==Keys.F7)
			{
				this.tabInOrd.SelectedIndex=1;
				if(this.LSVInOrdEmp.Items.Count>0)
				{
					this.LSVInOrdEmp.Items[0].Selected=true;
				}
			}

			if(e.KeyCode==Keys.F8)
			{
				if(this.LSVInOrdDe.Items.Count>0)
				{
					this.LSVInOrdDe.Items[0].Selected=true;
				}
			}
			if(e.KeyCode==Keys.F9)
			{
//				txtfind.Focus();
			}
			if(e.KeyCode==Keys.F10)
			{
//				TextID.Focus();
			}
			this.m_mthSetKeyTab(e);
		}

		private void dateTime_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			this.m_mthSetKeyTab(e);
		}

		private void m_txtMemo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			this.m_mthSetKeyTab(e);
		}

		private void TextID_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			this.m_mthSetKeyTab(e);
		}

		private void GrearNAME_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			this.m_mthSetKeyTab(e);
		}

		private void APPLDATE_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			this.m_mthSetKeyTab(e);
		}

		private void txtfindstroage_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			this.m_mthSetKeyTab(e);
		}

		private void txtType_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
				btnFinddata.Focus();
		}

		private void m_cboSelPeriod_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			((clsContorlStoreInOrdMed)this.objController).m_lngPriodchang();
		}
		int count=0;
		private void dateTime_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar == (char)13)
			{
				SendKeys.Send("{Right}");
				count++;
				if(count>2)
				{
					SendKeys.Send("{TAB}");
					count=0;
				}
			}
		}

		private void txtmedicine_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				if(m_cboIPCal.SelectItemValue=="")
				{
					publicClass.m_mthShowWarning(m_cboIPCal,"请先选择源药库!");
					m_cboIPCal.Focus();
					return;
				}
				ctlShowMed.strSTORAGEID=m_cboIPCal.SelectItemValue.ToString();
				ctlShowMed.strMedstorage=(string)m_lbStroage.Tag;
				Point  p=this.panel3.Parent.PointToScreen(this.panel3.Location);
				p=this.FindForm().PointToClient(p);
				p.Y-=this.ctlShowMed.Height;
				this.ctlShowMed.Location=p;
				this.ctlShowMed.Visible=true;
				this.ctlShowMed.Focus();
				ctlShowMed.intIsReData=0;
			}
		}

		private void m_txtSrcNO_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			this.m_mthSetKeyTab(e);
		}

		private void m_cboIPCal_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			this.m_mthSetKeyTab(e);
		}

		private void dateTime_KeyDown_1(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			this.m_mthSetKeyTab(e);
		}

		private void ctlValidityDate_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				if(btnAdd.Enabled==true)
					btnAdd.Focus();
				else
					btnSave.Focus();
			}
		}

		private void ctlShowMed_m_evtReturnVal(object sender, com.digitalwave.controls.clsEvtReturnVal e)
		{
			label23.Text=lblUnit.Text=e.objVO.strIPUNIT_CHR;
			txtmedicine.Text=e.objVO.strMEDICINENAME_VCHR;
			txtmedicine.Tag=e.objVO.strMEDICINEID_CHR;
			m_lblSpace.Tag=e.objVO.strASSISTCODE_CHR;
			m_lblSpace.Text=e.objVO.strMEDSPEC_VCHR;
			lblWorkShop.Text=e.objVO.strPRODUCTORID_CHR;
			m_txtMedNo.Text="";
			txtbuyprice.Text=e.objVO.dlUNITPRICE_MNY.ToString();
			ctlShowMed.Visible=false;
			m_txtMedNo.Focus();

		}

		private void m_txtMedNo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			this.m_mthSetKeyTab(e);
		}

		private void txttol_KeyDown_1(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				ctlValidityDate.Focus();
			}
		}

		private void txttol_Leave_1(object sender, System.EventArgs e)
		{
			if(this.txttol.Text.Trim()=="")
				return;
			double tolmoney=Convert.ToDouble(this.txtbuyprice.Text.Trim())*Convert.ToDouble(this.txttol.Text.Trim());
			this.DetotalMoney.Text=tolmoney.ToString();
		}

		private void LSVInord_Click(object sender, System.EventArgs e)
		{
			((clsContorlStoreInOrdMed)this.objController).m_lngShowDeBySelete();
			m_txtSrcNO.Focus();
		}

		private void frmStoreInOrdMed_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.Alt)
			{
				if(e.KeyCode==Keys.L)
				{
					if(LSVInOrdDe.Items.Count>0)
					{
						LSVInOrdDe.Items[0].Selected=true;
						LSVInOrdDe.Items[0].Focused=true;
					}
				}
				if(e.KeyCode==Keys.V)
				{
					tabInOrd.SelectedIndex=0;
					if(LSVInord.Items.Count>0)
					{
						LSVInord.Items[0].Selected=true;
						LSVInord.Items[0].Focused=true;
					}
					
				}
				if(e.KeyCode==Keys.O)
				{
					tabInOrd.SelectedIndex=1;
					if(LSVInOrdEmp.Items.Count>0)
					{
						LSVInOrdEmp.Items[0].Selected=true;
						LSVInOrdEmp.Items[0].Focused=true;
					}
					
				}
				if(e.KeyCode==Keys.T)
				{
						m_cboSelPeriod.Focus();
				}
			}
			if(e.KeyCode==Keys.Escape)
			{
				if(ctlShowMed.Visible==true)
				{
					ctlShowMed.Visible=false;
				}
				else
				{
					if(MessageBox.Show("是否要退出入库系统？","Icare",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
						return;
					else
						this.Close();
				}
			}
		}

		private void LSVInOrdEmp_Click(object sender, System.EventArgs e)
		{
			((clsContorlStoreInOrdMed)this.objController).m_lngShowDeBySelete();
		}

		private void ctlShowMed_e_evtReturnMedStoreOutVal(object sender, com.digitalwave.controls.clsEvtReturnOutStoreVal e)
		{
			label38.Text=e.objOutStoreVO.strSYSLOTNO_CHR;
			label23.Text=lblUnit.Text=e.objOutStoreVO.UNITID_CHR;
			txtmedicine.Text=e.objOutStoreVO.strMEDICINENAME_VCHR;
			txtmedicine.Tag=e.objOutStoreVO.strMEDICINEID_CHR;
			m_lblSpace.Tag=e.objOutStoreVO.strASSISTCODE_CHR;
			m_lblSpace.Text=e.objOutStoreVO.strSpec_VCHR;
			lblWorkShop.Text=e.objOutStoreVO.strPRODUCTORID_CHR;
			m_txtMedNo.Text=e.objOutStoreVO.strMedNo_CHR;
			txtbuyprice.Text=e.objOutStoreVO.dlSALEUNITPRICE_MNY.ToString();
			totailCoun.Text=e.objOutStoreVO.strCURQTY_DEC;
			if(e.objOutStoreVO.USEFULLIFE_DAT!=null&&e.objOutStoreVO.USEFULLIFE_DAT!="")
				ctlValidityDate.Text=DateTime.Parse(e.objOutStoreVO.USEFULLIFE_DAT).ToString("yyyy年MM月dd日");
			else
				ctlValidityDate.Text="";
			ctlShowMed.Visible=false;
			m_txtMedNo.Focus();
		}
		InputLanguage oldLanguage=null;
		private void ctlValidityDate_Enter(object sender, System.EventArgs e)
		{
			
			oldLanguage=InputLanguage.CurrentInputLanguage;
			InputLanguage.CurrentInputLanguage=InputLanguage.DefaultInputLanguage;
		}

		private void dateTime_Enter(object sender, System.EventArgs e)
		{
			oldLanguage=InputLanguage.CurrentInputLanguage;
			InputLanguage.CurrentInputLanguage=InputLanguage.DefaultInputLanguage;
		}

		private void ctlValidityDate_Leave(object sender, System.EventArgs e)
		{
			InputLanguage.CurrentInputLanguage=oldLanguage;
		}

		private void dateTime_Leave(object sender, System.EventArgs e)
		{
			InputLanguage.CurrentInputLanguage=oldLanguage;
		}

		private void m_cboIPCal_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ctlShowMed.intIsReData=1;
		}

	}
}
