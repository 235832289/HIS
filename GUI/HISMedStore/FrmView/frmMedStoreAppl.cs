using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmMedStoreAppl 的摘要说明。
	/// </summary>
	public class frmMedStoreAppl : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		internal System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader ROWNO_CHR;
		private System.Windows.Forms.ColumnHeader MEDICINEID_CHR;
		private System.Windows.Forms.ColumnHeader MEDICINENAME_CHR;
		private System.Windows.Forms.ColumnHeader space;
		private System.Windows.Forms.ColumnHeader UNITID_CHR;
		private System.Windows.Forms.ColumnHeader QTY_DEC;
		internal System.Windows.Forms.Panel panel6;
		internal PinkieControls.ButtonXP btnColes;
		internal PinkieControls.ButtonXP btnFinddata;
		protected internal System.Windows.Forms.Panel panel3;
		internal System.Windows.Forms.Label label3;
		internal PinkieControls.ButtonXP btnClear;
		internal PinkieControls.ButtonXP btnAdd;
		private System.Windows.Forms.Label label27;
		internal SourceLibrary.Windows.Forms.TextBoxTyped txtmedicine;
		private System.Windows.Forms.Label label30;
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
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label18;
		internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric txttQyt;
		internal System.Windows.Forms.ListView LSVApplDe;
		internal System.Windows.Forms.ListView LSVAppl;
		internal System.Windows.Forms.Panel panelord;
		private System.Windows.Forms.GroupBox ikuy;
		internal PinkieControls.ButtonXP btnOrd;
		internal PinkieControls.ButtonXP btnclose;
		internal PinkieControls.ButtonXP btnOrdAll;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label txtname;
		internal System.Windows.Forms.ListView lsvlimi;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.ColumnHeader columnHeader12;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		internal PinkieControls.ButtonXP btnAutoFind;
		internal PinkieControls.ButtonXP btnRetureAuto;
		internal System.Windows.Forms.ErrorProvider errorProvider1;
		internal System.Windows.Forms.Label txtSpace;
		private System.Windows.Forms.Label label6;
		internal System.Windows.Forms.Label lableUnit;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label8;
		internal System.Windows.Forms.Label lableNowStorage;
		internal System.Windows.Forms.Label lableUnit1;
		internal com.digitalwave.controls.ControlMedicineFind ctlShowMed;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		internal System.Windows.Forms.ComboBox cbosele;
		internal SourceLibrary.Windows.Forms.TextBoxTyped txt_Find;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		internal SourceLibrary.Windows.Forms.TextBoxTyped txtFind;
		internal System.Windows.Forms.ComboBox cboFind;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label10;
		internal System.Windows.Forms.Label blebostore;
		private System.Windows.Forms.Label label9;
		internal System.Windows.Forms.Label txtGrearMan;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label12;
		internal System.Windows.Forms.TextBox m_txtMemo;
		private System.Windows.Forms.Label label4;
		internal System.Windows.Forms.Panel panel4;
		internal NullableDateControls.MaskDateEdit dateTime;
        internal com.digitalwave.iCare.gui.HIS.exComboBox comboStroage;
        internal PinkieControls.ButtonXP buttonXP1;
        private IContainer components;

		public frmMedStoreAppl()
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
            this.components = new System.ComponentModel.Container();
            this.panel5 = new System.Windows.Forms.Panel();
            this.LSVAppl = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.LSVApplDe = new System.Windows.Forms.ListView();
            this.ROWNO_CHR = new System.Windows.Forms.ColumnHeader();
            this.MEDICINEID_CHR = new System.Windows.Forms.ColumnHeader();
            this.MEDICINENAME_CHR = new System.Windows.Forms.ColumnHeader();
            this.space = new System.Windows.Forms.ColumnHeader();
            this.QTY_DEC = new System.Windows.Forms.ColumnHeader();
            this.UNITID_CHR = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.cboFind = new System.Windows.Forms.ComboBox();
            this.txtFind = new SourceLibrary.Windows.Forms.TextBoxTyped();
            this.btnColes = new PinkieControls.ButtonXP();
            this.btnFinddata = new PinkieControls.ButtonXP();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lableUnit1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lableNowStorage = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lableUnit = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSpace = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClear = new PinkieControls.ButtonXP();
            this.btnAdd = new PinkieControls.ButtonXP();
            this.label27 = new System.Windows.Forms.Label();
            this.txttQyt = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panelord = new System.Windows.Forms.Panel();
            this.ikuy = new System.Windows.Forms.GroupBox();
            this.btnOrd = new PinkieControls.ButtonXP();
            this.btnclose = new PinkieControls.ButtonXP();
            this.btnOrdAll = new PinkieControls.ButtonXP();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbosele = new System.Windows.Forms.ComboBox();
            this.btnRetureAuto = new PinkieControls.ButtonXP();
            this.btnAutoFind = new PinkieControls.ButtonXP();
            this.txt_Find = new SourceLibrary.Windows.Forms.TextBoxTyped();
            this.txtname = new System.Windows.Forms.Label();
            this.lsvlimi = new System.Windows.Forms.ListView();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctlShowMed = new com.digitalwave.controls.ControlMedicineFind();
            this.label10 = new System.Windows.Forms.Label();
            this.blebostore = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtGrearMan = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.m_txtMemo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.comboStroage = new com.digitalwave.iCare.gui.HIS.exComboBox();
            this.dateTime = new NullableDateControls.MaskDateEdit();
            this.buttonXP1 = new PinkieControls.ButtonXP();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelord.SuspendLayout();
            this.ikuy.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.LSVAppl);
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(408, 672);
            this.panel5.TabIndex = 149;
            // 
            // LSVAppl
            // 
            this.LSVAppl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.LSVAppl.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader7});
            this.LSVAppl.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LSVAppl.FullRowSelect = true;
            this.LSVAppl.GridLines = true;
            this.LSVAppl.HideSelection = false;
            this.LSVAppl.Location = new System.Drawing.Point(2, 0);
            this.LSVAppl.Name = "LSVAppl";
            this.LSVAppl.Size = new System.Drawing.Size(398, 664);
            this.LSVAppl.TabIndex = 25;
            this.LSVAppl.UseCompatibleStateImageBehavior = false;
            this.LSVAppl.View = System.Windows.Forms.View.Details;
            this.LSVAppl.Click += new System.EventHandler(this.LSVAppl_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "单据号";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "申请药房";
            this.columnHeader2.Width = 102;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "申请人";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "申请时间";
            this.columnHeader4.Width = 150;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "领药药库";
            this.columnHeader7.Width = 80;
            // 
            // LSVApplDe
            // 
            this.LSVApplDe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.LSVApplDe.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ROWNO_CHR,
            this.MEDICINEID_CHR,
            this.MEDICINENAME_CHR,
            this.space,
            this.QTY_DEC,
            this.UNITID_CHR,
            this.columnHeader6});
            this.LSVApplDe.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LSVApplDe.FullRowSelect = true;
            this.LSVApplDe.GridLines = true;
            this.LSVApplDe.HideSelection = false;
            this.LSVApplDe.Location = new System.Drawing.Point(408, 0);
            this.LSVApplDe.Name = "LSVApplDe";
            this.LSVApplDe.Size = new System.Drawing.Size(616, 424);
            this.LSVApplDe.TabIndex = 150;
            this.LSVApplDe.UseCompatibleStateImageBehavior = false;
            this.LSVApplDe.View = System.Windows.Forms.View.Details;
            this.LSVApplDe.Click += new System.EventHandler(this.LSVApplDe_Click);
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
            // MEDICINENAME_CHR
            // 
            this.MEDICINENAME_CHR.Text = "药品名称";
            this.MEDICINENAME_CHR.Width = 160;
            // 
            // space
            // 
            this.space.Text = "规格";
            this.space.Width = 160;
            // 
            // QTY_DEC
            // 
            this.QTY_DEC.Text = "申请数量";
            this.QTY_DEC.Width = 70;
            // 
            // UNITID_CHR
            // 
            this.UNITID_CHR.Text = "单位";
            this.UNITID_CHR.Width = 50;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "当前库存";
            this.columnHeader6.Width = 70;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.label5);
            this.panel6.Controls.Add(this.cboFind);
            this.panel6.Controls.Add(this.txtFind);
            this.panel6.Controls.Add(this.btnColes);
            this.panel6.Controls.Add(this.btnFinddata);
            this.panel6.Location = new System.Drawing.Point(408, 384);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(616, 40);
            this.panel6.TabIndex = 151;
            this.panel6.Visible = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(8, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 152;
            this.label5.Text = "查找方式";
            // 
            // cboFind
            // 
            this.cboFind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFind.Items.AddRange(new object[] {
            "领药药库",
            "申领人",
            "申请日期"});
            this.cboFind.Location = new System.Drawing.Point(72, 8);
            this.cboFind.Name = "cboFind";
            this.cboFind.Size = new System.Drawing.Size(121, 22);
            this.cboFind.TabIndex = 151;
            // 
            // txtFind
            // 
            this.txtFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFind.EnableAutoValidation = true;
            this.txtFind.EnableEnterKeyValidate = true;
            this.txtFind.EnableEscapeKeyUndo = true;
            this.txtFind.EnableLastValidValue = true;
            this.txtFind.ErrorProvider = null;
            this.txtFind.ErrorProviderMessage = "Invalid value";
            this.txtFind.ForceFormatText = true;
            this.txtFind.Location = new System.Drawing.Point(216, 8);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(128, 23);
            this.txtFind.TabIndex = 14;
            this.txtFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFindStorage_KeyDown);
            // 
            // btnColes
            // 
            this.btnColes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnColes.DefaultScheme = true;
            this.btnColes.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnColes.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnColes.Hint = "";
            this.btnColes.Location = new System.Drawing.Point(528, 8);
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
            this.btnFinddata.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnFinddata.DefaultScheme = true;
            this.btnFinddata.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnFinddata.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFinddata.Hint = "";
            this.btnFinddata.Location = new System.Drawing.Point(432, 8);
            this.btnFinddata.Name = "btnFinddata";
            this.btnFinddata.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnFinddata.Size = new System.Drawing.Size(72, 24);
            this.btnFinddata.TabIndex = 15;
            this.btnFinddata.TabStop = false;
            this.btnFinddata.Text = "查找(&F)";
            this.btnFinddata.Click += new System.EventHandler(this.btnFinddata_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.lableUnit1);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.lableNowStorage);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.lableUnit);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.txtSpace);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.btnClear);
            this.panel3.Controls.Add(this.btnAdd);
            this.panel3.Controls.Add(this.label27);
            this.panel3.Controls.Add(this.txttQyt);
            this.panel3.Controls.Add(this.txtmedicine);
            this.panel3.Controls.Add(this.label30);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.m_txtUNIT);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(408, 528);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(616, 88);
            this.panel3.TabIndex = 1;
            // 
            // lableUnit1
            // 
            this.lableUnit1.Location = new System.Drawing.Point(152, 53);
            this.lableUnit1.Name = "lableUnit1";
            this.lableUnit1.Size = new System.Drawing.Size(32, 23);
            this.lableUnit1.TabIndex = 171;
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Location = new System.Drawing.Point(72, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 1);
            this.label8.TabIndex = 170;
            // 
            // lableNowStorage
            // 
            this.lableNowStorage.Location = new System.Drawing.Point(72, 53);
            this.lableNowStorage.Name = "lableNowStorage";
            this.lableNowStorage.Size = new System.Drawing.Size(72, 23);
            this.lableNowStorage.TabIndex = 169;
            this.lableNowStorage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(8, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 168;
            this.label2.Text = "现 库 存";
            // 
            // lableUnit
            // 
            this.lableUnit.Location = new System.Drawing.Point(368, 53);
            this.lableUnit.Name = "lableUnit";
            this.lableUnit.Size = new System.Drawing.Size(32, 23);
            this.lableUnit.TabIndex = 167;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(264, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(336, 1);
            this.label6.TabIndex = 166;
            // 
            // txtSpace
            // 
            this.txtSpace.Location = new System.Drawing.Point(264, 13);
            this.txtSpace.Name = "txtSpace";
            this.txtSpace.Size = new System.Drawing.Size(336, 23);
            this.txtSpace.TabIndex = 165;
            this.txtSpace.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(200, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 164;
            this.label3.Text = "规    格";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnClear.DefaultScheme = true;
            this.btnClear.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClear.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClear.Hint = "";
            this.btnClear.Location = new System.Drawing.Point(528, 56);
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
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnAdd.DefaultScheme = true;
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAdd.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.Hint = "";
            this.btnAdd.Location = new System.Drawing.Point(432, 56);
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
            this.label27.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label27.Location = new System.Drawing.Point(200, 56);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(64, 16);
            this.label27.TabIndex = 156;
            this.label27.Text = "数    量";
            // 
            // txttQyt
            // 
            this.txttQyt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txttQyt.EnableAutoValidation = false;
            this.txttQyt.EnableEnterKeyValidate = true;
            this.txttQyt.EnableEscapeKeyUndo = true;
            this.txttQyt.EnableLastValidValue = true;
            this.txttQyt.ErrorProvider = null;
            this.txttQyt.ErrorProviderMessage = "Invalid value";
            this.txttQyt.ForceFormatText = true;
            this.txttQyt.Location = new System.Drawing.Point(264, 53);
            this.txttQyt.MaxLength = 10;
            this.txttQyt.Name = "txttQyt";
            this.txttQyt.NumericCharStyle = ((SourceLibrary.Windows.Forms.NumericCharStyle)((SourceLibrary.Windows.Forms.NumericCharStyle.DecimalSeparator | SourceLibrary.Windows.Forms.NumericCharStyle.NegativeSymbol)));
            this.txttQyt.Size = new System.Drawing.Size(96, 23);
            this.txttQyt.TabIndex = 2;
            this.txttQyt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txttQyt.Leave += new System.EventHandler(this.txttQyt_Leave);
            this.txttQyt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txttQyt_KeyDown);
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
            this.txtmedicine.ForceFormatText = true;
            this.txtmedicine.Location = new System.Drawing.Point(72, 13);
            this.txtmedicine.MaxLength = 100;
            this.txtmedicine.Name = "txtmedicine";
            this.txtmedicine.Size = new System.Drawing.Size(112, 23);
            this.txtmedicine.TabIndex = 1;
            this.txtmedicine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmedicine_KeyDown);
            // 
            // label30
            // 
            this.label30.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label30.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label30.Location = new System.Drawing.Point(8, 16);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(64, 16);
            this.label30.TabIndex = 148;
            this.label30.Text = "药品名称";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.Location = new System.Drawing.Point(232, 88);
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
            this.m_txtUNIT.Location = new System.Drawing.Point(80, 128);
            this.m_txtUNIT.Name = "m_txtUNIT";
            this.m_txtUNIT.Size = new System.Drawing.Size(104, 23);
            this.m_txtUNIT.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(16, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 116;
            this.label1.Text = "单    位";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.buttonXP1);
            this.groupBox3.Controls.Add(this.dntEmp);
            this.groupBox3.Controls.Add(this.btnesc);
            this.groupBox3.Controls.Add(this.btnDelect);
            this.groupBox3.Controls.Add(this.btnFind);
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Controls.Add(this.m_btnNew);
            this.groupBox3.Location = new System.Drawing.Point(408, 624);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(616, 48);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // dntEmp
            // 
            this.dntEmp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.dntEmp.DefaultScheme = true;
            this.dntEmp.DialogResult = System.Windows.Forms.DialogResult.None;
            this.dntEmp.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dntEmp.Hint = "";
            this.dntEmp.Location = new System.Drawing.Point(271, 16);
            this.dntEmp.Name = "dntEmp";
            this.dntEmp.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.dntEmp.Size = new System.Drawing.Size(72, 24);
            this.dntEmp.TabIndex = 54;
            this.dntEmp.TabStop = false;
            this.dntEmp.Text = "生成(&O)";
            this.dntEmp.Click += new System.EventHandler(this.dntEmp_Click);
            // 
            // btnesc
            // 
            this.btnesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnesc.DefaultScheme = true;
            this.btnesc.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnesc.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnesc.Hint = "";
            this.btnesc.Location = new System.Drawing.Point(526, 16);
            this.btnesc.Name = "btnesc";
            this.btnesc.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnesc.Size = new System.Drawing.Size(72, 24);
            this.btnesc.TabIndex = 53;
            this.btnesc.TabStop = false;
            this.btnesc.Text = "退出(ESC)";
            this.btnesc.Click += new System.EventHandler(this.btnesc_Click);
            // 
            // btnDelect
            // 
            this.btnDelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnDelect.DefaultScheme = true;
            this.btnDelect.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDelect.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelect.Hint = "";
            this.btnDelect.Location = new System.Drawing.Point(441, 16);
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
            this.btnFind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnFind.DefaultScheme = true;
            this.btnFind.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnFind.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFind.Hint = "";
            this.btnFind.Location = new System.Drawing.Point(356, 16);
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
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnSave.DefaultScheme = true;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSave.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Hint = "";
            this.btnSave.Location = new System.Drawing.Point(101, 16);
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
            this.m_btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnNew.DefaultScheme = true;
            this.m_btnNew.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnNew.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnNew.Hint = "";
            this.m_btnNew.Location = new System.Drawing.Point(16, 16);
            this.m_btnNew.Name = "m_btnNew";
            this.m_btnNew.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnNew.Size = new System.Drawing.Size(72, 24);
            this.m_btnNew.TabIndex = 49;
            this.m_btnNew.TabStop = false;
            this.m_btnNew.Text = "新建(&N)";
            this.m_btnNew.Click += new System.EventHandler(this.m_btnNew_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label22);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Location = new System.Drawing.Point(0, 680);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1028, 48);
            this.panel2.TabIndex = 155;
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label22.Location = new System.Drawing.Point(550, 8);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(216, 23);
            this.label22.TabIndex = 4;
            this.label22.Text = "Alt+R使药品查找输入框具有焦点";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label21.Location = new System.Drawing.Point(320, 8);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(192, 23);
            this.label21.TabIndex = 3;
            this.label21.Text = "Alt+Q选中申请明细数据";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label19.Location = new System.Drawing.Point(146, 8);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(158, 23);
            this.label19.TabIndex = 1;
            this.label19.Text = "Alt+T选中领药申请单";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label18.Location = new System.Drawing.Point(8, 8);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(100, 23);
            this.label18.TabIndex = 0;
            this.label18.Text = "快捷键提示:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelord
            // 
            this.panelord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panelord.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelord.Controls.Add(this.ikuy);
            this.panelord.Controls.Add(this.panel1);
            this.panelord.Controls.Add(this.lsvlimi);
            this.panelord.Location = new System.Drawing.Point(0, 712);
            this.panelord.Name = "panelord";
            this.panelord.Size = new System.Drawing.Size(408, 672);
            this.panelord.TabIndex = 411;
            this.panelord.Visible = false;
            // 
            // ikuy
            // 
            this.ikuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ikuy.Controls.Add(this.btnOrd);
            this.ikuy.Controls.Add(this.btnclose);
            this.ikuy.Controls.Add(this.btnOrdAll);
            this.ikuy.Location = new System.Drawing.Point(4, 624);
            this.ikuy.Name = "ikuy";
            this.ikuy.Size = new System.Drawing.Size(396, 44);
            this.ikuy.TabIndex = 12;
            this.ikuy.TabStop = false;
            // 
            // btnOrd
            // 
            this.btnOrd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnOrd.DefaultScheme = true;
            this.btnOrd.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnOrd.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOrd.Hint = "";
            this.btnOrd.Location = new System.Drawing.Point(148, 14);
            this.btnOrd.Name = "btnOrd";
            this.btnOrd.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnOrd.Size = new System.Drawing.Size(96, 24);
            this.btnOrd.TabIndex = 57;
            this.btnOrd.TabStop = false;
            this.btnOrd.Text = "生成(&M)";
            this.btnOrd.Click += new System.EventHandler(this.btnOrd_Click);
            // 
            // btnclose
            // 
            this.btnclose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnclose.DefaultScheme = true;
            this.btnclose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnclose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnclose.Hint = "";
            this.btnclose.Location = new System.Drawing.Point(256, 14);
            this.btnclose.Name = "btnclose";
            this.btnclose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnclose.Size = new System.Drawing.Size(96, 24);
            this.btnclose.TabIndex = 56;
            this.btnclose.TabStop = false;
            this.btnclose.Text = "关闭(ESC)";
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnOrdAll
            // 
            this.btnOrdAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnOrdAll.DefaultScheme = true;
            this.btnOrdAll.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnOrdAll.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOrdAll.Hint = "";
            this.btnOrdAll.Location = new System.Drawing.Point(40, 14);
            this.btnOrdAll.Name = "btnOrdAll";
            this.btnOrdAll.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnOrdAll.Size = new System.Drawing.Size(96, 24);
            this.btnOrdAll.TabIndex = 55;
            this.btnOrdAll.TabStop = false;
            this.btnOrdAll.Text = "全部生成(&L)";
            this.btnOrdAll.Click += new System.EventHandler(this.btnOrdAll_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.cbosele);
            this.panel1.Controls.Add(this.btnRetureAuto);
            this.panel1.Controls.Add(this.btnAutoFind);
            this.panel1.Controls.Add(this.txt_Find);
            this.panel1.Controls.Add(this.txtname);
            this.panel1.Location = new System.Drawing.Point(4, 544);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(396, 80);
            this.panel1.TabIndex = 11;
            // 
            // cbosele
            // 
            this.cbosele.Items.AddRange(new object[] {
            "药品助记码",
            "药品名称",
            "拼音码",
            "五笔码"});
            this.cbosele.Location = new System.Drawing.Point(72, 8);
            this.cbosele.Name = "cbosele";
            this.cbosele.Size = new System.Drawing.Size(121, 22);
            this.cbosele.TabIndex = 144;
            // 
            // btnRetureAuto
            // 
            this.btnRetureAuto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRetureAuto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnRetureAuto.DefaultScheme = true;
            this.btnRetureAuto.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnRetureAuto.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRetureAuto.Hint = "";
            this.btnRetureAuto.Location = new System.Drawing.Point(256, 48);
            this.btnRetureAuto.Name = "btnRetureAuto";
            this.btnRetureAuto.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnRetureAuto.Size = new System.Drawing.Size(96, 24);
            this.btnRetureAuto.TabIndex = 143;
            this.btnRetureAuto.Text = "返回(&B)";
            this.btnRetureAuto.Click += new System.EventHandler(this.btnRetureAuto_Click);
            // 
            // btnAutoFind
            // 
            this.btnAutoFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAutoFind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnAutoFind.DefaultScheme = true;
            this.btnAutoFind.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAutoFind.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAutoFind.Hint = "";
            this.btnAutoFind.Location = new System.Drawing.Point(48, 48);
            this.btnAutoFind.Name = "btnAutoFind";
            this.btnAutoFind.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnAutoFind.Size = new System.Drawing.Size(96, 24);
            this.btnAutoFind.TabIndex = 142;
            this.btnAutoFind.Text = "查找(&K)";
            this.btnAutoFind.Click += new System.EventHandler(this.btnAutoFind_Click);
            // 
            // txt_Find
            // 
            this.txt_Find.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_Find.EnableAutoValidation = true;
            this.txt_Find.EnableEnterKeyValidate = true;
            this.txt_Find.EnableEscapeKeyUndo = true;
            this.txt_Find.EnableLastValidValue = true;
            this.txt_Find.ErrorProvider = null;
            this.txt_Find.ErrorProviderMessage = "Invalid value";
            this.txt_Find.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Find.ForceFormatText = true;
            this.txt_Find.Location = new System.Drawing.Point(240, 9);
            this.txt_Find.Name = "txt_Find";
            this.txt_Find.Size = new System.Drawing.Size(112, 23);
            this.txt_Find.TabIndex = 140;
            this.txt_Find.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtmedNameAuto_KeyDown);
            // 
            // txtname
            // 
            this.txtname.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtname.Location = new System.Drawing.Point(8, 8);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(64, 23);
            this.txtname.TabIndex = 138;
            this.txtname.Text = "查找方式";
            this.txtname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lsvlimi
            // 
            this.lsvlimi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lsvlimi.CheckBoxes = true;
            this.lsvlimi.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader5,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12});
            this.lsvlimi.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvlimi.FullRowSelect = true;
            this.lsvlimi.GridLines = true;
            this.lsvlimi.HideSelection = false;
            this.lsvlimi.Location = new System.Drawing.Point(4, 0);
            this.lsvlimi.Name = "lsvlimi";
            this.lsvlimi.Size = new System.Drawing.Size(396, 536);
            this.lsvlimi.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lsvlimi.TabIndex = 300;
            this.lsvlimi.TabStop = false;
            this.lsvlimi.UseCompatibleStateImageBehavior = false;
            this.lsvlimi.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "生成";
            this.columnHeader8.Width = 40;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "药品名称";
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader9.Width = 150;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "单位";
            this.columnHeader5.Width = 40;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "现库存";
            this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "下限";
            this.columnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader11.Width = 40;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "领药数量";
            this.columnHeader12.Width = 71;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctlShowMed
            // 
            this.ctlShowMed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlShowMed.blIsMedStorage = false;
            this.ctlShowMed.blISOutStorage = false;
            this.ctlShowMed.blRepertory = true;
            this.ctlShowMed.FindMedmode = 0;
            this.ctlShowMed.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ctlShowMed.intIsReData = 0;
            this.ctlShowMed.isApplMebMod = null;
            this.ctlShowMed.isApplModel = false;
            this.ctlShowMed.isShowFindType = true;
            this.ctlShowMed.IsShowZero = false;
            this.ctlShowMed.Location = new System.Drawing.Point(408, -408);
            this.ctlShowMed.Name = "ctlShowMed";
            this.ctlShowMed.Size = new System.Drawing.Size(608, 432);
            this.ctlShowMed.strMedstorage = null;
            this.ctlShowMed.strSTORAGEID = "-1";
            this.ctlShowMed.TabIndex = 412;
            this.ctlShowMed.Visible = false;
            this.ctlShowMed.m_evtReturnVal += new com.digitalwave.controls.dlgReturnVal(this.ctlShowMed_m_evtReturnVal);
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(72, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(120, 1);
            this.label10.TabIndex = 174;
            // 
            // blebostore
            // 
            this.blebostore.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.blebostore.Location = new System.Drawing.Point(72, 8);
            this.blebostore.Name = "blebostore";
            this.blebostore.Size = new System.Drawing.Size(120, 23);
            this.blebostore.TabIndex = 173;
            this.blebostore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(488, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(112, 1);
            this.label9.TabIndex = 172;
            // 
            // txtGrearMan
            // 
            this.txtGrearMan.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtGrearMan.Location = new System.Drawing.Point(488, 8);
            this.txtGrearMan.Name = "txtGrearMan";
            this.txtGrearMan.Size = new System.Drawing.Size(112, 23);
            this.txtGrearMan.TabIndex = 171;
            this.txtGrearMan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label25.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.Location = new System.Drawing.Point(424, 11);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(72, 16);
            this.label25.TabIndex = 136;
            this.label25.Text = "创 建 人";
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label24.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.Location = new System.Drawing.Point(200, 11);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(64, 16);
            this.label24.TabIndex = 134;
            this.label24.Text = "领药药库";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(8, 11);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 16);
            this.label14.TabIndex = 132;
            this.label14.Text = "申请药房";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(8, 51);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 16);
            this.label12.TabIndex = 118;
            this.label12.Text = "日    期";
            // 
            // m_txtMemo
            // 
            this.m_txtMemo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_txtMemo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtMemo.Location = new System.Drawing.Point(264, 48);
            this.m_txtMemo.Name = "m_txtMemo";
            this.m_txtMemo.Size = new System.Drawing.Size(336, 23);
            this.m_txtMemo.TabIndex = 3;
            this.m_txtMemo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtMemo_KeyDown);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(200, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 117;
            this.label4.Text = "备    注";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.comboStroage);
            this.panel4.Controls.Add(this.dateTime);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.blebostore);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.txtGrearMan);
            this.panel4.Controls.Add(this.label25);
            this.panel4.Controls.Add(this.label24);
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.m_txtMemo);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel4.Location = new System.Drawing.Point(408, 432);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(616, 88);
            this.panel4.TabIndex = 0;
            // 
            // comboStroage
            // 
            this.comboStroage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboStroage.Location = new System.Drawing.Point(264, 8);
            this.comboStroage.Name = "comboStroage";
            this.comboStroage.Size = new System.Drawing.Size(136, 22);
            this.comboStroage.TabIndex = 0;
            this.comboStroage.SelectedIndexChanged += new System.EventHandler(this.comboStroage_SelectedIndexChanged_1);
            this.comboStroage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboStroage_KeyDown_1);
            // 
            // dateTime
            // 
            this.dateTime.Location = new System.Drawing.Point(72, 48);
            this.dateTime.Mask = "yyyy年MM月dd日";
            this.dateTime.Name = "dateTime";
            this.dateTime.Size = new System.Drawing.Size(120, 23);
            this.dateTime.TabIndex = 2;
            this.dateTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dateTime_KeyDown);
            // 
            // buttonXP1
            // 
            this.buttonXP1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP1.DefaultScheme = true;
            this.buttonXP1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonXP1.Hint = "";
            this.buttonXP1.Location = new System.Drawing.Point(186, 16);
            this.buttonXP1.Name = "buttonXP1";
            this.buttonXP1.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP1.Size = new System.Drawing.Size(72, 24);
            this.buttonXP1.TabIndex = 55;
            this.buttonXP1.TabStop = false;
            this.buttonXP1.Text = "提交(&T)";
            this.buttonXP1.Click += new System.EventHandler(this.buttonXP1_Click);
            // 
            // frmMedStoreAppl
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(1028, 725);
            this.Controls.Add(this.ctlShowMed);
            this.Controls.Add(this.panelord);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.LSVApplDe);
            this.Controls.Add(this.panel5);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.KeyPreview = true;
            this.Name = "frmMedStoreAppl";
            this.Text = "药房申请领药";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMedStoreAppl_KeyDown);
            this.Load += new System.EventHandler(this.frmMedStoreAppl_Load);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelord.ResumeLayout(false);
            this.ikuy.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 
		/// </summary>
		public override void CreateController()
		{
			this.objController = new clsControlMedStoreAppl();
			this.objController.Set_GUI_Apperance(this);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="StorageID"></param>
		public void m_GetStorageID(string StorageID)
		{
			string storageName=null;
			clsDomainControlMedStore Domain=new clsDomainControlMedStore();
			long lngRes=Domain.m_lngGetMedStoreName(StorageID,out storageName);
			if(lngRes>0&&storageName==null)
			{
				MessageBox.Show("传入的药房ID不正确！","Icare",MessageBoxButtons.OK,MessageBoxIcon.Stop);
				this.Dispose();
				return;
			}
			blebostore.Text=storageName;
			blebostore.Tag=StorageID;
			ctlShowMed.strMedstorage=StorageID;
			this.Show();
		}
		private void frmMedStoreAppl_Load(object sender, System.EventArgs e)
		{
			((clsControlMedStoreAppl)this.objController).m_lngSetupFrm();
			this.m_mthSetEnter2Tab(new System.Windows.Forms.Control[] {this.ctlShowMed});
		}
		private void comboStroage_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
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
			if(txttQyt.Text.Trim()=="0")
			{
				publicClass.m_mthShowWarning(txttQyt,"申请数量不能为空!");
				txttQyt.Focus();
				return;
			}
			((clsControlMedStoreAppl)this.objController).m_lngAddClick();
			txtmedicine.Focus();
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			if(comboStroage.Text=="")
			{
				publicClass.m_mthShowWarning(comboStroage,"领药的药库不能为空!");
				comboStroage.Focus();
				return;
			}
			((clsControlMedStoreAppl)this.objController).m_lngSaveClick();
			comboStroage.Focus();
		}

		private void m_btnNew_Click(object sender, System.EventArgs e)
		{
			((clsControlMedStoreAppl)this.objController).m_lngClear(2);
		}

		private void btnClear_Click(object sender, System.EventArgs e)
		{

			((clsControlMedStoreAppl)this.objController).m_lngClear(1);
		}

		private void LSVAppl_Click(object sender, System.EventArgs e)
		{
			((clsControlMedStoreAppl)this.objController).m_lngShowDeBySelete();
		}

		private void LSVApplDe_Click(object sender, System.EventArgs e)
		{
			((clsControlMedStoreAppl)this.objController).m_lngFillTxtboxOrdDe();
		}

		private void btnDelect_Click(object sender, System.EventArgs e)
		{
			((clsControlMedStoreAppl)this.objController).m_lngDeleClick();
		}

		private void btnesc_Click(object sender, System.EventArgs e)
		{
			if(panelord.Visible==true)
			{
				panelord.Visible=false;
			}
			else
			{
				this.Close();
			}
		}

		private void btnFind_Click(object sender, System.EventArgs e)
		{
			this.panel6.Top=this.panel4.Top-this.panel6.Height-10;
			this.panel6.Left=this.panel4.Left+2;
			LSVApplDe.Height=LSVApplDe.Height-this.panel6.Height-10;
			this.panel6.Visible=true;
			this.cboFind.Focus();
		}

		private void btnColes_Click(object sender, System.EventArgs e)
		{
			LSVApplDe.Height=LSVApplDe.Height+panel6.Height+10;
			((clsControlMedStoreAppl)this.objController).m_lngGetAndFill();
		}

		private void btnFinddata_Click(object sender, System.EventArgs e)
		{
			((clsControlMedStoreAppl)this.objController).m_lngFindClick();
		}

		private void txttQyt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
				btnAdd.Focus();
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

		private void txtfindstore_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			this.m_mthSetKeyTab(e);
		}

		private void txtFindStorage_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
				btnFinddata.Focus();
		}

		private void dntEmp_Click(object sender, System.EventArgs e)
		{
			((clsControlMedStoreAppl)this.objController).m_lngAutoClick();
			this.cbosele.Focus();
		}

		private void btnclose_Click(object sender, System.EventArgs e)
		{
		    panelord.Visible=false;
		}

		private void btnRetureAuto_Click(object sender, System.EventArgs e)
		{
			((clsControlMedStoreAppl)this.objController).m_lngRetureAuto();
		}

		private void btnAutoFind_Click(object sender, System.EventArgs e)
		{
			((clsControlMedStoreAppl)this.objController).m_lngAutoFindClick();
		}

		private void txtStoreAuto_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
		    this.m_mthSetKeyTab(e);
		}

		private void TxtmedNameAuto_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
				this.btnAutoFind.Focus();
		}

		private void btnOrdAll_Click(object sender, System.EventArgs e)
		{
			((clsControlMedStoreAppl)this.objController).m_lngAutomatismAll();
		}

		private void btnOrd_Click(object sender, System.EventArgs e)
		{
			((clsControlMedStoreAppl)this.objController).m_lngAutomatism();
		}

		private void frmMedStoreAppl_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Escape)
			{
				if(ctlShowMed.Visible==true)
				{
					ctlShowMed.Visible=false;
					txttQyt.Focus();
					return;
				}
				else
				{
					this.Close();
				}
			}
			if(e.Alt)
			{
				if(e.KeyCode==Keys.T)
				{
					if(this.LSVAppl.Items.Count>0)
					{
						this.LSVAppl.Items[0].Selected=true;
						this.LSVAppl.Focus();
					}

				}
				if(e.KeyCode==Keys.Q)
				{
					if(this.LSVApplDe.Items.Count>0)
					{
						this.LSVApplDe.Items[0].Selected=true;
						this.LSVApplDe.Focus();
					}

				}
				if(e.KeyCode==Keys.R)
				{
					txtmedicine.Focus();

				}
			}
	

		}

		private void m_txtMemo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			this.m_mthSetKeyTab(e);

		}

		private void txttQyt_Leave(object sender, System.EventArgs e)
		{
			if(txttQyt.Tag!=null&&(string)txttQyt.Tag!=""&&(string)txttQyt.Tag!="0")
			{
				int PACKQTY=Convert.ToInt32((string)txttQyt.Tag);
				int couQty=Convert.ToInt32(txttQyt.Text.Trim());
				if(couQty%PACKQTY!=0)
				{
					MessageBox.Show("你必需输入药品包装量'"+PACKQTY.ToString()+"'的倍数！","配药提示");
					txttQyt.Focus();
				}
			}
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
				if(comboStroage.Text=="")
				{
					MessageBox.Show("请先选择一个领药的药库！","Icare",MessageBoxButtons.OK,MessageBoxIcon.Stop);
					comboStroage.Focus();
					return;
				}
				ctlShowMed.strSTORAGEID=comboStroage.SelectItemValue.ToString();
				Point  p=this.panel3.Parent.PointToScreen(this.panel3.Location);
				p=this.FindForm().PointToClient(p);
				p.Y-=this.ctlShowMed.Height;
				this.ctlShowMed.Location=p;
				this.ctlShowMed.Visible=true;
				this.ctlShowMed.Focus();
				this.ctlShowMed.intIsReData=0;
			}
		}

		private void ctlShowMed_m_evtReturnVal(object sender, com.digitalwave.controls.clsEvtReturnVal e)
		{
			txtmedicine.Text=e.objVO.strMEDICINENAME_VCHR;
			txtmedicine.Tag=e.objVO.strMEDICINEID_CHR;
			txtSpace.Tag=e.objVO.strASSISTCODE_CHR;
			txtSpace.Text=e.objVO.strMEDSPEC_VCHR;
			lableNowStorage.Text=e.objVO.dlAMOUNT_DEC.ToString();
			lableUnit1.Text=lableUnit.Text=e.objVO.strIPUNIT_CHR;
			this.ctlShowMed.Visible = false;
			txttQyt.Focus();

		}

		private void dateTime_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			this.m_mthSetKeyTab(e);
		}

		private void comboStroage_KeyDown_1(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			this.m_mthSetKeyTab(e);
		}

		private void comboStroage_SelectedIndexChanged_1(object sender, System.EventArgs e)
		{
			ctlShowMed.intIsReData=1;
		}

        private void buttonXP1_Click(object sender, EventArgs e)
        {
            ((clsControlMedStoreAppl)this.objController).m_mthPutAppl();
        }
	}
}
