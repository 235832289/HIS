using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 价类管理  
	/// </summary>
	public class frmChargeIns : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private System.Windows.Forms.TabControl m_tabChargeIns;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.ColumnHeader columnHeader12;
		private System.Windows.Forms.ColumnHeader columnHeader13;
		private System.Windows.Forms.ColumnHeader columnHeader14;
		private System.Windows.Forms.ColumnHeader columnHeader15;
		private System.Windows.Forms.Label labelFreqName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ColumnHeader columnHeader16;
		private PinkieControls.ButtonXP m_btnINSCOMPANYDel;
		private PinkieControls.ButtonXP m_btnINSCOMPANYExit;
		private PinkieControls.ButtonXP m_btnINSCOMPANYSave;
		private PinkieControls.ButtonXP m_btnINSCOMPANYNew;
		private System.Windows.Forms.ColumnHeader columnHeader17;
		private System.Windows.Forms.Label m_lblCOMPANYNAME_CHR;
		private System.Windows.Forms.Label m_lblUSERCODE_CHR;
		private System.Windows.Forms.Label m_lblREMARK_VCHR;
		internal System.Windows.Forms.ListView m_lsvINSCOMPANY;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txINSCOMPANYUSERCODE;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtCOMPANYNAME;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtINSCOMPANYREMARK;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		internal exComboBox m_cboCOMPANYID_CHR;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtREMARK_VCHR_INSPLAN;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtUSERCODE_CHR_INSPLAN;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtPLANNAME_CHR_INSPLAN;
		private PinkieControls.ButtonXP m_btnINSPLANDel;
		private PinkieControls.ButtonXP m_btnINSPLANExit;
		private PinkieControls.ButtonXP m_btnINSPLANSave;
		private PinkieControls.ButtonXP m_btnINSPLANNew;
		private System.Windows.Forms.ColumnHeader columnHeader18;
		internal System.Windows.Forms.ListView m_lsvINSPLAN;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtCOPAYNAME_CHR_INSCOPAY;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtUSERCODE_CHR_INSCOPAY;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtREMARK_VCHR_INSCOPAY;
		private PinkieControls.ButtonXP m_btnDel_INSCOPAY;
		private PinkieControls.ButtonXP m_btnSave_INSCOPAY;
		private PinkieControls.ButtonXP m_btnNew_INSCOPAY;
		internal System.Windows.Forms.ComboBox m_cboPLANID_CHR;
		private PinkieControls.ButtonXP m_btnExit_INSCOPAY;
		internal System.Windows.Forms.ListView m_lsv_INSCOPAY;
		internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric m_txtPRECENT_DEC_INSCOPAY;
		private System.Windows.Forms.ColumnHeader columnHeader19;
		private System.Windows.Forms.ColumnHeader columnHeader20;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmChargeIns()
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
			this.m_tabChargeIns = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.m_txtINSCOMPANYREMARK = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.m_lblREMARK_VCHR = new System.Windows.Forms.Label();
			this.m_txINSCOMPANYUSERCODE = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.m_lblUSERCODE_CHR = new System.Windows.Forms.Label();
			this.m_txtCOMPANYNAME = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.m_lblCOMPANYNAME_CHR = new System.Windows.Forms.Label();
			this.m_btnINSCOMPANYDel = new PinkieControls.ButtonXP();
			this.m_btnINSCOMPANYExit = new PinkieControls.ButtonXP();
			this.m_btnINSCOMPANYSave = new PinkieControls.ButtonXP();
			this.m_btnINSCOMPANYNew = new PinkieControls.ButtonXP();
			this.m_lsvINSCOMPANY = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader17 = new System.Windows.Forms.ColumnHeader();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.m_cboCOMPANYID_CHR = new com.digitalwave.iCare.gui.HIS.exComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.m_txtREMARK_VCHR_INSPLAN = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.label5 = new System.Windows.Forms.Label();
			this.m_txtUSERCODE_CHR_INSPLAN = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.label6 = new System.Windows.Forms.Label();
			this.m_txtPLANNAME_CHR_INSPLAN = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.label7 = new System.Windows.Forms.Label();
			this.m_btnINSPLANDel = new PinkieControls.ButtonXP();
			this.m_btnINSPLANExit = new PinkieControls.ButtonXP();
			this.m_btnINSPLANSave = new PinkieControls.ButtonXP();
			this.m_btnINSPLANNew = new PinkieControls.ButtonXP();
			this.m_lsvINSPLAN = new System.Windows.Forms.ListView();
			this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader18 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader19 = new System.Windows.Forms.ColumnHeader();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.m_txtPRECENT_DEC_INSCOPAY = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
			this.m_btnDel_INSCOPAY = new PinkieControls.ButtonXP();
			this.m_btnExit_INSCOPAY = new PinkieControls.ButtonXP();
			this.m_btnSave_INSCOPAY = new PinkieControls.ButtonXP();
			this.m_btnNew_INSCOPAY = new PinkieControls.ButtonXP();
			this.m_cboPLANID_CHR = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.m_txtCOPAYNAME_CHR_INSCOPAY = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.labelFreqName = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.m_txtUSERCODE_CHR_INSCOPAY = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.m_lsv_INSCOPAY = new System.Windows.Forms.ListView();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader20 = new System.Windows.Forms.ColumnHeader();
			this.m_txtREMARK_VCHR_INSCOPAY = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.m_tabChargeIns.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_tabChargeIns
			// 
			this.m_tabChargeIns.Controls.Add(this.tabPage1);
			this.m_tabChargeIns.Controls.Add(this.tabPage2);
			this.m_tabChargeIns.Controls.Add(this.tabPage3);
			this.m_tabChargeIns.Location = new System.Drawing.Point(-8, 8);
			this.m_tabChargeIns.Name = "m_tabChargeIns";
			this.m_tabChargeIns.SelectedIndex = 0;
			this.m_tabChargeIns.Size = new System.Drawing.Size(888, 512);
			this.m_tabChargeIns.TabIndex = 0;
			this.m_tabChargeIns.SelectedIndexChanged += new System.EventHandler(this.m_tabChargeIns_SelectedIndexChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.m_txtINSCOMPANYREMARK);
			this.tabPage1.Controls.Add(this.m_lblREMARK_VCHR);
			this.tabPage1.Controls.Add(this.m_txINSCOMPANYUSERCODE);
			this.tabPage1.Controls.Add(this.m_lblUSERCODE_CHR);
			this.tabPage1.Controls.Add(this.m_txtCOMPANYNAME);
			this.tabPage1.Controls.Add(this.m_lblCOMPANYNAME_CHR);
			this.tabPage1.Controls.Add(this.m_btnINSCOMPANYDel);
			this.tabPage1.Controls.Add(this.m_btnINSCOMPANYExit);
			this.tabPage1.Controls.Add(this.m_btnINSCOMPANYSave);
			this.tabPage1.Controls.Add(this.m_btnINSCOMPANYNew);
			this.tabPage1.Controls.Add(this.m_lsvINSCOMPANY);
			this.tabPage1.Location = new System.Drawing.Point(4, 23);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(880, 485);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "保险公司";
			// 
			// m_txtINSCOMPANYREMARK
			// 
			this.m_txtINSCOMPANYREMARK.EnableAutoValidation = true;
			this.m_txtINSCOMPANYREMARK.EnableEnterKeyValidate = true;
			this.m_txtINSCOMPANYREMARK.EnableEscapeKeyUndo = true;
			this.m_txtINSCOMPANYREMARK.EnableLastValidValue = true;
			this.m_txtINSCOMPANYREMARK.ErrorProvider = null;
			this.m_txtINSCOMPANYREMARK.ErrorProviderMessage = "Invalid value";
			this.m_txtINSCOMPANYREMARK.ForceFormatText = true;
			this.m_txtINSCOMPANYREMARK.Location = new System.Drawing.Point(672, 120);
			this.m_txtINSCOMPANYREMARK.MaxLength = 50;
			this.m_txtINSCOMPANYREMARK.Name = "m_txtINSCOMPANYREMARK";
			this.m_txtINSCOMPANYREMARK.Size = new System.Drawing.Size(128, 23);
			this.m_txtINSCOMPANYREMARK.TabIndex = 47;
			this.m_txtINSCOMPANYREMARK.Text = "";
			// 
			// m_lblREMARK_VCHR
			// 
			this.m_lblREMARK_VCHR.AutoSize = true;
			this.m_lblREMARK_VCHR.Location = new System.Drawing.Point(616, 128);
			this.m_lblREMARK_VCHR.Name = "m_lblREMARK_VCHR";
			this.m_lblREMARK_VCHR.Size = new System.Drawing.Size(48, 19);
			this.m_lblREMARK_VCHR.TabIndex = 48;
			this.m_lblREMARK_VCHR.Text = "备  注";
			this.m_lblREMARK_VCHR.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_txINSCOMPANYUSERCODE
			// 
			this.m_txINSCOMPANYUSERCODE.EnableAutoValidation = true;
			this.m_txINSCOMPANYUSERCODE.EnableEnterKeyValidate = true;
			this.m_txINSCOMPANYUSERCODE.EnableEscapeKeyUndo = true;
			this.m_txINSCOMPANYUSERCODE.EnableLastValidValue = true;
			this.m_txINSCOMPANYUSERCODE.ErrorProvider = null;
			this.m_txINSCOMPANYUSERCODE.ErrorProviderMessage = "Invalid value";
			this.m_txINSCOMPANYUSERCODE.ForceFormatText = true;
			this.m_txINSCOMPANYUSERCODE.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.m_txINSCOMPANYUSERCODE.Location = new System.Drawing.Point(672, 80);
			this.m_txINSCOMPANYUSERCODE.MaxLength = 4;
			this.m_txINSCOMPANYUSERCODE.Name = "m_txINSCOMPANYUSERCODE";
			this.m_txINSCOMPANYUSERCODE.Size = new System.Drawing.Size(128, 23);
			this.m_txINSCOMPANYUSERCODE.TabIndex = 45;
			this.m_txINSCOMPANYUSERCODE.Text = "";
			// 
			// m_lblUSERCODE_CHR
			// 
			this.m_lblUSERCODE_CHR.AutoSize = true;
			this.m_lblUSERCODE_CHR.Location = new System.Drawing.Point(616, 88);
			this.m_lblUSERCODE_CHR.Name = "m_lblUSERCODE_CHR";
			this.m_lblUSERCODE_CHR.Size = new System.Drawing.Size(48, 19);
			this.m_lblUSERCODE_CHR.TabIndex = 46;
			this.m_lblUSERCODE_CHR.Text = "助记码";
			this.m_lblUSERCODE_CHR.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_txtCOMPANYNAME
			// 
			this.m_txtCOMPANYNAME.EnableAutoValidation = true;
			this.m_txtCOMPANYNAME.EnableEnterKeyValidate = true;
			this.m_txtCOMPANYNAME.EnableEscapeKeyUndo = true;
			this.m_txtCOMPANYNAME.EnableLastValidValue = true;
			this.m_txtCOMPANYNAME.ErrorProvider = null;
			this.m_txtCOMPANYNAME.ErrorProviderMessage = "Invalid value";
			this.m_txtCOMPANYNAME.ForceFormatText = true;
			this.m_txtCOMPANYNAME.Location = new System.Drawing.Point(672, 40);
			this.m_txtCOMPANYNAME.MaxLength = 20;
			this.m_txtCOMPANYNAME.Name = "m_txtCOMPANYNAME";
			this.m_txtCOMPANYNAME.Size = new System.Drawing.Size(128, 23);
			this.m_txtCOMPANYNAME.TabIndex = 43;
			this.m_txtCOMPANYNAME.Text = "";
			// 
			// m_lblCOMPANYNAME_CHR
			// 
			this.m_lblCOMPANYNAME_CHR.AutoSize = true;
			this.m_lblCOMPANYNAME_CHR.Location = new System.Drawing.Point(616, 48);
			this.m_lblCOMPANYNAME_CHR.Name = "m_lblCOMPANYNAME_CHR";
			this.m_lblCOMPANYNAME_CHR.Size = new System.Drawing.Size(48, 19);
			this.m_lblCOMPANYNAME_CHR.TabIndex = 44;
			this.m_lblCOMPANYNAME_CHR.Text = "名  称";
			this.m_lblCOMPANYNAME_CHR.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_btnINSCOMPANYDel
			// 
			this.m_btnINSCOMPANYDel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnINSCOMPANYDel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btnINSCOMPANYDel.DefaultScheme = true;
			this.m_btnINSCOMPANYDel.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnINSCOMPANYDel.Hint = "";
			this.m_btnINSCOMPANYDel.Location = new System.Drawing.Point(672, 328);
			this.m_btnINSCOMPANYDel.Name = "m_btnINSCOMPANYDel";
			this.m_btnINSCOMPANYDel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnINSCOMPANYDel.Size = new System.Drawing.Size(112, 32);
			this.m_btnINSCOMPANYDel.TabIndex = 50;
			this.m_btnINSCOMPANYDel.Text = "删除(&D)";
			this.m_btnINSCOMPANYDel.Click += new System.EventHandler(this.m_btnINSCOMPANYDel_Click);
			// 
			// m_btnINSCOMPANYExit
			// 
			this.m_btnINSCOMPANYExit.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnINSCOMPANYExit.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btnINSCOMPANYExit.DefaultScheme = true;
			this.m_btnINSCOMPANYExit.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnINSCOMPANYExit.Hint = "";
			this.m_btnINSCOMPANYExit.Location = new System.Drawing.Point(672, 376);
			this.m_btnINSCOMPANYExit.Name = "m_btnINSCOMPANYExit";
			this.m_btnINSCOMPANYExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnINSCOMPANYExit.Size = new System.Drawing.Size(112, 32);
			this.m_btnINSCOMPANYExit.TabIndex = 51;
			this.m_btnINSCOMPANYExit.Text = "退出(Esc)";
			this.m_btnINSCOMPANYExit.Click += new System.EventHandler(this.m_btnINSCOMPANYExit_Click);
			// 
			// m_btnINSCOMPANYSave
			// 
			this.m_btnINSCOMPANYSave.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnINSCOMPANYSave.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btnINSCOMPANYSave.DefaultScheme = true;
			this.m_btnINSCOMPANYSave.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnINSCOMPANYSave.Hint = "";
			this.m_btnINSCOMPANYSave.Location = new System.Drawing.Point(672, 280);
			this.m_btnINSCOMPANYSave.Name = "m_btnINSCOMPANYSave";
			this.m_btnINSCOMPANYSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnINSCOMPANYSave.Size = new System.Drawing.Size(112, 32);
			this.m_btnINSCOMPANYSave.TabIndex = 49;
			this.m_btnINSCOMPANYSave.Text = "保存(&S)";
			this.m_btnINSCOMPANYSave.Click += new System.EventHandler(this.m_btnINSCOMPANYSave_Click);
			// 
			// m_btnINSCOMPANYNew
			// 
			this.m_btnINSCOMPANYNew.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnINSCOMPANYNew.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btnINSCOMPANYNew.DefaultScheme = true;
			this.m_btnINSCOMPANYNew.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnINSCOMPANYNew.Hint = "";
			this.m_btnINSCOMPANYNew.Location = new System.Drawing.Point(672, 232);
			this.m_btnINSCOMPANYNew.Name = "m_btnINSCOMPANYNew";
			this.m_btnINSCOMPANYNew.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnINSCOMPANYNew.Size = new System.Drawing.Size(112, 32);
			this.m_btnINSCOMPANYNew.TabIndex = 48;
			this.m_btnINSCOMPANYNew.Text = "新增(&A)";
			this.m_btnINSCOMPANYNew.Click += new System.EventHandler(this.m_btnINSCOMPANYNew_Click);
			// 
			// m_lsvINSCOMPANY
			// 
			this.m_lsvINSCOMPANY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.m_lsvINSCOMPANY.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							  this.columnHeader1,
																							  this.columnHeader2,
																							  this.columnHeader3,
																							  this.columnHeader4,
																							  this.columnHeader17});
			this.m_lsvINSCOMPANY.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_lsvINSCOMPANY.FullRowSelect = true;
			this.m_lsvINSCOMPANY.GridLines = true;
			this.m_lsvINSCOMPANY.HideSelection = false;
			this.m_lsvINSCOMPANY.Location = new System.Drawing.Point(8, 8);
			this.m_lsvINSCOMPANY.MultiSelect = false;
			this.m_lsvINSCOMPANY.Name = "m_lsvINSCOMPANY";
			this.m_lsvINSCOMPANY.Size = new System.Drawing.Size(584, 472);
			this.m_lsvINSCOMPANY.TabIndex = 13;
			this.m_lsvINSCOMPANY.View = System.Windows.Forms.View.Details;
			this.m_lsvINSCOMPANY.Click += new System.EventHandler(this.m_lsvINSCOMPANY_SelectedIndexChanged);
			this.m_lsvINSCOMPANY.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_lsvINSCOMPANY_MouseUp);
			this.m_lsvINSCOMPANY.SelectedIndexChanged += new System.EventHandler(this.m_lsvINSCOMPANY_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "";
			this.columnHeader1.Width = 0;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "保险公司编号";
			this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader2.Width = 0;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "助记码";
			this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader3.Width = 98;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "保险公司名称";
			this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader4.Width = 158;
			// 
			// columnHeader17
			// 
			this.columnHeader17.Text = "备注";
			this.columnHeader17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader17.Width = 323;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.m_cboCOMPANYID_CHR);
			this.tabPage2.Controls.Add(this.label8);
			this.tabPage2.Controls.Add(this.m_txtREMARK_VCHR_INSPLAN);
			this.tabPage2.Controls.Add(this.label5);
			this.tabPage2.Controls.Add(this.m_txtUSERCODE_CHR_INSPLAN);
			this.tabPage2.Controls.Add(this.label6);
			this.tabPage2.Controls.Add(this.m_txtPLANNAME_CHR_INSPLAN);
			this.tabPage2.Controls.Add(this.label7);
			this.tabPage2.Controls.Add(this.m_btnINSPLANDel);
			this.tabPage2.Controls.Add(this.m_btnINSPLANExit);
			this.tabPage2.Controls.Add(this.m_btnINSPLANSave);
			this.tabPage2.Controls.Add(this.m_btnINSPLANNew);
			this.tabPage2.Controls.Add(this.m_lsvINSPLAN);
			this.tabPage2.Location = new System.Drawing.Point(4, 23);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(880, 485);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "保险计划";
			// 
			// m_cboCOMPANYID_CHR
			// 
			this.m_cboCOMPANYID_CHR.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboCOMPANYID_CHR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboCOMPANYID_CHR.Location = new System.Drawing.Point(672, 168);
			this.m_cboCOMPANYID_CHR.Name = "m_cboCOMPANYID_CHR";
			this.m_cboCOMPANYID_CHR.Size = new System.Drawing.Size(128, 22);
			this.m_cboCOMPANYID_CHR.TabIndex = 52;
			this.m_cboCOMPANYID_CHR.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_cboCOMPANYID_CHR_MouseDown);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(600, 168);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(70, 19);
			this.label8.TabIndex = 62;
			this.label8.Text = "保险公司:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_txtREMARK_VCHR_INSPLAN
			// 
			this.m_txtREMARK_VCHR_INSPLAN.EnableAutoValidation = true;
			this.m_txtREMARK_VCHR_INSPLAN.EnableEnterKeyValidate = true;
			this.m_txtREMARK_VCHR_INSPLAN.EnableEscapeKeyUndo = true;
			this.m_txtREMARK_VCHR_INSPLAN.EnableLastValidValue = true;
			this.m_txtREMARK_VCHR_INSPLAN.ErrorProvider = null;
			this.m_txtREMARK_VCHR_INSPLAN.ErrorProviderMessage = "Invalid value";
			this.m_txtREMARK_VCHR_INSPLAN.ForceFormatText = true;
			this.m_txtREMARK_VCHR_INSPLAN.Location = new System.Drawing.Point(672, 120);
			this.m_txtREMARK_VCHR_INSPLAN.MaxLength = 50;
			this.m_txtREMARK_VCHR_INSPLAN.Name = "m_txtREMARK_VCHR_INSPLAN";
			this.m_txtREMARK_VCHR_INSPLAN.Size = new System.Drawing.Size(128, 23);
			this.m_txtREMARK_VCHR_INSPLAN.TabIndex = 51;
			this.m_txtREMARK_VCHR_INSPLAN.Text = "";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(616, 128);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 19);
			this.label5.TabIndex = 54;
			this.label5.Text = "备  注:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_txtUSERCODE_CHR_INSPLAN
			// 
			this.m_txtUSERCODE_CHR_INSPLAN.EnableAutoValidation = true;
			this.m_txtUSERCODE_CHR_INSPLAN.EnableEnterKeyValidate = true;
			this.m_txtUSERCODE_CHR_INSPLAN.EnableEscapeKeyUndo = true;
			this.m_txtUSERCODE_CHR_INSPLAN.EnableLastValidValue = true;
			this.m_txtUSERCODE_CHR_INSPLAN.ErrorProvider = null;
			this.m_txtUSERCODE_CHR_INSPLAN.ErrorProviderMessage = "Invalid value";
			this.m_txtUSERCODE_CHR_INSPLAN.ForceFormatText = true;
			this.m_txtUSERCODE_CHR_INSPLAN.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.m_txtUSERCODE_CHR_INSPLAN.Location = new System.Drawing.Point(672, 80);
			this.m_txtUSERCODE_CHR_INSPLAN.MaxLength = 4;
			this.m_txtUSERCODE_CHR_INSPLAN.Name = "m_txtUSERCODE_CHR_INSPLAN";
			this.m_txtUSERCODE_CHR_INSPLAN.Size = new System.Drawing.Size(128, 23);
			this.m_txtUSERCODE_CHR_INSPLAN.TabIndex = 50;
			this.m_txtUSERCODE_CHR_INSPLAN.Text = "";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(616, 88);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(56, 19);
			this.label6.TabIndex = 52;
			this.label6.Text = "助记码:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_txtPLANNAME_CHR_INSPLAN
			// 
			this.m_txtPLANNAME_CHR_INSPLAN.EnableAutoValidation = true;
			this.m_txtPLANNAME_CHR_INSPLAN.EnableEnterKeyValidate = true;
			this.m_txtPLANNAME_CHR_INSPLAN.EnableEscapeKeyUndo = true;
			this.m_txtPLANNAME_CHR_INSPLAN.EnableLastValidValue = true;
			this.m_txtPLANNAME_CHR_INSPLAN.ErrorProvider = null;
			this.m_txtPLANNAME_CHR_INSPLAN.ErrorProviderMessage = "Invalid value";
			this.m_txtPLANNAME_CHR_INSPLAN.ForceFormatText = true;
			this.m_txtPLANNAME_CHR_INSPLAN.Location = new System.Drawing.Point(672, 40);
			this.m_txtPLANNAME_CHR_INSPLAN.MaxLength = 20;
			this.m_txtPLANNAME_CHR_INSPLAN.Name = "m_txtPLANNAME_CHR_INSPLAN";
			this.m_txtPLANNAME_CHR_INSPLAN.Size = new System.Drawing.Size(128, 23);
			this.m_txtPLANNAME_CHR_INSPLAN.TabIndex = 49;
			this.m_txtPLANNAME_CHR_INSPLAN.Text = "";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(616, 48);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(56, 19);
			this.label7.TabIndex = 50;
			this.label7.Text = "名  称:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_btnINSPLANDel
			// 
			this.m_btnINSPLANDel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnINSPLANDel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btnINSPLANDel.DefaultScheme = true;
			this.m_btnINSPLANDel.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnINSPLANDel.Hint = "";
			this.m_btnINSPLANDel.Location = new System.Drawing.Point(672, 328);
			this.m_btnINSPLANDel.Name = "m_btnINSPLANDel";
			this.m_btnINSPLANDel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnINSPLANDel.Size = new System.Drawing.Size(112, 32);
			this.m_btnINSPLANDel.TabIndex = 55;
			this.m_btnINSPLANDel.Text = "删除(&D)";
			this.m_btnINSPLANDel.Click += new System.EventHandler(this.m_btnINSPLANDel_Click);
			// 
			// m_btnINSPLANExit
			// 
			this.m_btnINSPLANExit.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnINSPLANExit.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btnINSPLANExit.DefaultScheme = true;
			this.m_btnINSPLANExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btnINSPLANExit.Hint = "";
			this.m_btnINSPLANExit.Location = new System.Drawing.Point(672, 376);
			this.m_btnINSPLANExit.Name = "m_btnINSPLANExit";
			this.m_btnINSPLANExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnINSPLANExit.Size = new System.Drawing.Size(112, 32);
			this.m_btnINSPLANExit.TabIndex = 56;
			this.m_btnINSPLANExit.Text = "退出(Esc)";
			// 
			// m_btnINSPLANSave
			// 
			this.m_btnINSPLANSave.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnINSPLANSave.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btnINSPLANSave.DefaultScheme = true;
			this.m_btnINSPLANSave.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnINSPLANSave.Hint = "";
			this.m_btnINSPLANSave.Location = new System.Drawing.Point(672, 280);
			this.m_btnINSPLANSave.Name = "m_btnINSPLANSave";
			this.m_btnINSPLANSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnINSPLANSave.Size = new System.Drawing.Size(112, 32);
			this.m_btnINSPLANSave.TabIndex = 54;
			this.m_btnINSPLANSave.Text = "保存(&S)";
			this.m_btnINSPLANSave.Click += new System.EventHandler(this.m_btnINSPLANSave_Click);
			// 
			// m_btnINSPLANNew
			// 
			this.m_btnINSPLANNew.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnINSPLANNew.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btnINSPLANNew.DefaultScheme = true;
			this.m_btnINSPLANNew.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnINSPLANNew.Hint = "";
			this.m_btnINSPLANNew.Location = new System.Drawing.Point(672, 232);
			this.m_btnINSPLANNew.Name = "m_btnINSPLANNew";
			this.m_btnINSPLANNew.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnINSPLANNew.Size = new System.Drawing.Size(112, 32);
			this.m_btnINSPLANNew.TabIndex = 53;
			this.m_btnINSPLANNew.Text = "新增(&A)";
			this.m_btnINSPLANNew.Click += new System.EventHandler(this.m_btnINSPLANNew_Click);
			// 
			// m_lsvINSPLAN
			// 
			this.m_lsvINSPLAN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.m_lsvINSPLAN.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						   this.columnHeader9,
																						   this.columnHeader10,
																						   this.columnHeader11,
																						   this.columnHeader12,
																						   this.columnHeader16,
																						   this.columnHeader18,
																						   this.columnHeader19});
			this.m_lsvINSPLAN.FullRowSelect = true;
			this.m_lsvINSPLAN.GridLines = true;
			this.m_lsvINSPLAN.HideSelection = false;
			this.m_lsvINSPLAN.Location = new System.Drawing.Point(8, 8);
			this.m_lsvINSPLAN.MultiSelect = false;
			this.m_lsvINSPLAN.Name = "m_lsvINSPLAN";
			this.m_lsvINSPLAN.Size = new System.Drawing.Size(584, 472);
			this.m_lsvINSPLAN.TabIndex = 14;
			this.m_lsvINSPLAN.View = System.Windows.Forms.View.Details;
			this.m_lsvINSPLAN.Click += new System.EventHandler(this.m_lsvINSPLAN_SelectedIndexChanged);
			this.m_lsvINSPLAN.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_lsvINSPLAN_MouseUp);
			this.m_lsvINSPLAN.SelectedIndexChanged += new System.EventHandler(this.m_lsvINSPLAN_SelectedIndexChanged);
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "";
			this.columnHeader9.Width = 0;
			// 
			// columnHeader10
			// 
			this.columnHeader10.Text = "保险计划编号";
			this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader10.Width = 0;
			// 
			// columnHeader11
			// 
			this.columnHeader11.Text = "助记码";
			this.columnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader11.Width = 94;
			// 
			// columnHeader12
			// 
			this.columnHeader12.Text = "保险计划名称";
			this.columnHeader12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader12.Width = 162;
			// 
			// columnHeader16
			// 
			this.columnHeader16.Text = "备注";
			this.columnHeader16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader16.Width = 182;
			// 
			// columnHeader18
			// 
			this.columnHeader18.Text = "保险公司编号";
			this.columnHeader18.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader18.Width = 0;
			// 
			// columnHeader19
			// 
			this.columnHeader19.Text = "保险公司";
			this.columnHeader19.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader19.Width = 140;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.m_txtPRECENT_DEC_INSCOPAY);
			this.tabPage3.Controls.Add(this.m_btnDel_INSCOPAY);
			this.tabPage3.Controls.Add(this.m_btnExit_INSCOPAY);
			this.tabPage3.Controls.Add(this.m_btnSave_INSCOPAY);
			this.tabPage3.Controls.Add(this.m_btnNew_INSCOPAY);
			this.tabPage3.Controls.Add(this.m_cboPLANID_CHR);
			this.tabPage3.Controls.Add(this.label2);
			this.tabPage3.Controls.Add(this.m_txtCOPAYNAME_CHR_INSCOPAY);
			this.tabPage3.Controls.Add(this.labelFreqName);
			this.tabPage3.Controls.Add(this.label1);
			this.tabPage3.Controls.Add(this.m_txtUSERCODE_CHR_INSCOPAY);
			this.tabPage3.Controls.Add(this.m_lsv_INSCOPAY);
			this.tabPage3.Controls.Add(this.m_txtREMARK_VCHR_INSCOPAY);
			this.tabPage3.Controls.Add(this.label3);
			this.tabPage3.Controls.Add(this.label4);
			this.tabPage3.Location = new System.Drawing.Point(4, 23);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(880, 485);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "保险种类";
			// 
			// m_txtPRECENT_DEC_INSCOPAY
			// 
			this.m_txtPRECENT_DEC_INSCOPAY.CausesValidation = false;
			this.m_txtPRECENT_DEC_INSCOPAY.EnableAutoValidation = true;
			this.m_txtPRECENT_DEC_INSCOPAY.EnableEnterKeyValidate = true;
			this.m_txtPRECENT_DEC_INSCOPAY.EnableEscapeKeyUndo = true;
			this.m_txtPRECENT_DEC_INSCOPAY.EnableLastValidValue = true;
			this.m_txtPRECENT_DEC_INSCOPAY.ErrorProvider = null;
			this.m_txtPRECENT_DEC_INSCOPAY.ErrorProviderMessage = "Invalid value";
			this.m_txtPRECENT_DEC_INSCOPAY.ForceFormatText = true;
			this.m_txtPRECENT_DEC_INSCOPAY.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.m_txtPRECENT_DEC_INSCOPAY.Location = new System.Drawing.Point(672, 72);
			this.m_txtPRECENT_DEC_INSCOPAY.MaxLength = 8;
			this.m_txtPRECENT_DEC_INSCOPAY.Name = "m_txtPRECENT_DEC_INSCOPAY";
			this.m_txtPRECENT_DEC_INSCOPAY.NumericCharStyle = SourceLibrary.Windows.Forms.NumericCharStyle.DecimalSeparator;
			this.m_txtPRECENT_DEC_INSCOPAY.Size = new System.Drawing.Size(128, 23);
			this.m_txtPRECENT_DEC_INSCOPAY.TabIndex = 28;
			this.m_txtPRECENT_DEC_INSCOPAY.Text = "";
			this.m_txtPRECENT_DEC_INSCOPAY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_btnDel_INSCOPAY
			// 
			this.m_btnDel_INSCOPAY.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnDel_INSCOPAY.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btnDel_INSCOPAY.DefaultScheme = true;
			this.m_btnDel_INSCOPAY.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnDel_INSCOPAY.Hint = "";
			this.m_btnDel_INSCOPAY.Location = new System.Drawing.Point(672, 328);
			this.m_btnDel_INSCOPAY.Name = "m_btnDel_INSCOPAY";
			this.m_btnDel_INSCOPAY.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnDel_INSCOPAY.Size = new System.Drawing.Size(112, 32);
			this.m_btnDel_INSCOPAY.TabIndex = 34;
			this.m_btnDel_INSCOPAY.Text = "删除(&D)";
			this.m_btnDel_INSCOPAY.Click += new System.EventHandler(this.m_btnDel_INSCOPAY_Click);
			// 
			// m_btnExit_INSCOPAY
			// 
			this.m_btnExit_INSCOPAY.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnExit_INSCOPAY.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btnExit_INSCOPAY.DefaultScheme = true;
			this.m_btnExit_INSCOPAY.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btnExit_INSCOPAY.Hint = "";
			this.m_btnExit_INSCOPAY.Location = new System.Drawing.Point(672, 376);
			this.m_btnExit_INSCOPAY.Name = "m_btnExit_INSCOPAY";
			this.m_btnExit_INSCOPAY.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnExit_INSCOPAY.Size = new System.Drawing.Size(112, 32);
			this.m_btnExit_INSCOPAY.TabIndex = 35;
			this.m_btnExit_INSCOPAY.Text = "退出(Esc)";
			// 
			// m_btnSave_INSCOPAY
			// 
			this.m_btnSave_INSCOPAY.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnSave_INSCOPAY.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btnSave_INSCOPAY.DefaultScheme = true;
			this.m_btnSave_INSCOPAY.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnSave_INSCOPAY.Hint = "";
			this.m_btnSave_INSCOPAY.Location = new System.Drawing.Point(672, 280);
			this.m_btnSave_INSCOPAY.Name = "m_btnSave_INSCOPAY";
			this.m_btnSave_INSCOPAY.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnSave_INSCOPAY.Size = new System.Drawing.Size(112, 32);
			this.m_btnSave_INSCOPAY.TabIndex = 33;
			this.m_btnSave_INSCOPAY.Text = "保存(&S)";
			this.m_btnSave_INSCOPAY.Click += new System.EventHandler(this.m_btnSave_INSCOPAY_Click);
			// 
			// m_btnNew_INSCOPAY
			// 
			this.m_btnNew_INSCOPAY.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnNew_INSCOPAY.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btnNew_INSCOPAY.DefaultScheme = true;
			this.m_btnNew_INSCOPAY.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnNew_INSCOPAY.Hint = "";
			this.m_btnNew_INSCOPAY.Location = new System.Drawing.Point(672, 232);
			this.m_btnNew_INSCOPAY.Name = "m_btnNew_INSCOPAY";
			this.m_btnNew_INSCOPAY.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnNew_INSCOPAY.Size = new System.Drawing.Size(112, 32);
			this.m_btnNew_INSCOPAY.TabIndex = 32;
			this.m_btnNew_INSCOPAY.Text = "新增(&A)";
			this.m_btnNew_INSCOPAY.Click += new System.EventHandler(this.m_btnNew_INSCOPAY_Click);
			// 
			// m_cboPLANID_CHR
			// 
			this.m_cboPLANID_CHR.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboPLANID_CHR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboPLANID_CHR.Location = new System.Drawing.Point(672, 176);
			this.m_cboPLANID_CHR.Name = "m_cboPLANID_CHR";
			this.m_cboPLANID_CHR.Size = new System.Drawing.Size(128, 22);
			this.m_cboPLANID_CHR.TabIndex = 31;
			this.m_cboPLANID_CHR.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_cboPLANID_CHR_MouseDown);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(616, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 19);
			this.label2.TabIndex = 32;
			this.label2.Text = "比  例:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_txtCOPAYNAME_CHR_INSCOPAY
			// 
			this.m_txtCOPAYNAME_CHR_INSCOPAY.EnableAutoValidation = true;
			this.m_txtCOPAYNAME_CHR_INSCOPAY.EnableEnterKeyValidate = true;
			this.m_txtCOPAYNAME_CHR_INSCOPAY.EnableEscapeKeyUndo = true;
			this.m_txtCOPAYNAME_CHR_INSCOPAY.EnableLastValidValue = true;
			this.m_txtCOPAYNAME_CHR_INSCOPAY.ErrorProvider = null;
			this.m_txtCOPAYNAME_CHR_INSCOPAY.ErrorProviderMessage = "Invalid value";
			this.m_txtCOPAYNAME_CHR_INSCOPAY.ForceFormatText = true;
			this.m_txtCOPAYNAME_CHR_INSCOPAY.Location = new System.Drawing.Point(672, 40);
			this.m_txtCOPAYNAME_CHR_INSCOPAY.MaxLength = 20;
			this.m_txtCOPAYNAME_CHR_INSCOPAY.Name = "m_txtCOPAYNAME_CHR_INSCOPAY";
			this.m_txtCOPAYNAME_CHR_INSCOPAY.Size = new System.Drawing.Size(128, 23);
			this.m_txtCOPAYNAME_CHR_INSCOPAY.TabIndex = 27;
			this.m_txtCOPAYNAME_CHR_INSCOPAY.Text = "";
			// 
			// labelFreqName
			// 
			this.labelFreqName.AutoSize = true;
			this.labelFreqName.Location = new System.Drawing.Point(616, 48);
			this.labelFreqName.Name = "labelFreqName";
			this.labelFreqName.Size = new System.Drawing.Size(56, 19);
			this.labelFreqName.TabIndex = 30;
			this.labelFreqName.Text = "名  称:";
			this.labelFreqName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(616, 112);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 19);
			this.label1.TabIndex = 29;
			this.label1.Text = "助记码:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_txtUSERCODE_CHR_INSCOPAY
			// 
			this.m_txtUSERCODE_CHR_INSCOPAY.EnableAutoValidation = true;
			this.m_txtUSERCODE_CHR_INSCOPAY.EnableEnterKeyValidate = true;
			this.m_txtUSERCODE_CHR_INSCOPAY.EnableEscapeKeyUndo = true;
			this.m_txtUSERCODE_CHR_INSCOPAY.EnableLastValidValue = true;
			this.m_txtUSERCODE_CHR_INSCOPAY.ErrorProvider = null;
			this.m_txtUSERCODE_CHR_INSCOPAY.ErrorProviderMessage = "Invalid value";
			this.m_txtUSERCODE_CHR_INSCOPAY.ForceFormatText = true;
			this.m_txtUSERCODE_CHR_INSCOPAY.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.m_txtUSERCODE_CHR_INSCOPAY.Location = new System.Drawing.Point(672, 104);
			this.m_txtUSERCODE_CHR_INSCOPAY.MaxLength = 4;
			this.m_txtUSERCODE_CHR_INSCOPAY.Name = "m_txtUSERCODE_CHR_INSCOPAY";
			this.m_txtUSERCODE_CHR_INSCOPAY.Size = new System.Drawing.Size(128, 23);
			this.m_txtUSERCODE_CHR_INSCOPAY.TabIndex = 29;
			this.m_txtUSERCODE_CHR_INSCOPAY.Text = "";
			// 
			// m_lsv_INSCOPAY
			// 
			this.m_lsv_INSCOPAY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.m_lsv_INSCOPAY.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							 this.columnHeader5,
																							 this.columnHeader6,
																							 this.columnHeader7,
																							 this.columnHeader8,
																							 this.columnHeader13,
																							 this.columnHeader14,
																							 this.columnHeader15,
																							 this.columnHeader20});
			this.m_lsv_INSCOPAY.FullRowSelect = true;
			this.m_lsv_INSCOPAY.GridLines = true;
			this.m_lsv_INSCOPAY.HideSelection = false;
			this.m_lsv_INSCOPAY.Location = new System.Drawing.Point(8, 8);
			this.m_lsv_INSCOPAY.MultiSelect = false;
			this.m_lsv_INSCOPAY.Name = "m_lsv_INSCOPAY";
			this.m_lsv_INSCOPAY.Size = new System.Drawing.Size(584, 472);
			this.m_lsv_INSCOPAY.TabIndex = 14;
			this.m_lsv_INSCOPAY.View = System.Windows.Forms.View.Details;
			this.m_lsv_INSCOPAY.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_lsv_INSCOPAY_MouseDown);
			this.m_lsv_INSCOPAY.Click += new System.EventHandler(this.m_lsv_INSCOPAY_SelectedIndexChanged);
			this.m_lsv_INSCOPAY.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_lsv_INSCOPAY_MouseUp);
			this.m_lsv_INSCOPAY.SelectedIndexChanged += new System.EventHandler(this.m_lsv_INSCOPAY_SelectedIndexChanged);
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "";
			this.columnHeader5.Width = 0;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "保险种类编号";
			this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader6.Width = 0;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "助记码";
			this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader7.Width = 99;
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "保险种类名称";
			this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader8.Width = 106;
			// 
			// columnHeader13
			// 
			this.columnHeader13.Text = "额定自付比例";
			this.columnHeader13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader13.Width = 116;
			// 
			// columnHeader14
			// 
			this.columnHeader14.Text = "备注";
			this.columnHeader14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader14.Width = 128;
			// 
			// columnHeader15
			// 
			this.columnHeader15.Text = "保险计划编号";
			this.columnHeader15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader15.Width = 0;
			// 
			// columnHeader20
			// 
			this.columnHeader20.Text = "保险计划";
			this.columnHeader20.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader20.Width = 130;
			// 
			// m_txtREMARK_VCHR_INSCOPAY
			// 
			this.m_txtREMARK_VCHR_INSCOPAY.EnableAutoValidation = true;
			this.m_txtREMARK_VCHR_INSCOPAY.EnableEnterKeyValidate = true;
			this.m_txtREMARK_VCHR_INSCOPAY.EnableEscapeKeyUndo = true;
			this.m_txtREMARK_VCHR_INSCOPAY.EnableLastValidValue = true;
			this.m_txtREMARK_VCHR_INSCOPAY.ErrorProvider = null;
			this.m_txtREMARK_VCHR_INSCOPAY.ErrorProviderMessage = "Invalid value";
			this.m_txtREMARK_VCHR_INSCOPAY.ForceFormatText = true;
			this.m_txtREMARK_VCHR_INSCOPAY.Location = new System.Drawing.Point(672, 136);
			this.m_txtREMARK_VCHR_INSCOPAY.MaxLength = 50;
			this.m_txtREMARK_VCHR_INSCOPAY.Name = "m_txtREMARK_VCHR_INSCOPAY";
			this.m_txtREMARK_VCHR_INSCOPAY.Size = new System.Drawing.Size(128, 23);
			this.m_txtREMARK_VCHR_INSCOPAY.TabIndex = 30;
			this.m_txtREMARK_VCHR_INSCOPAY.Text = "";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(616, 144);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 19);
			this.label3.TabIndex = 30;
			this.label3.Text = "备  注:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(600, 176);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(70, 19);
			this.label4.TabIndex = 30;
			this.label4.Text = "保险计划:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// frmChargeIns
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(826, 517);
			this.Controls.Add(this.m_tabChargeIns);
			this.Font = new System.Drawing.Font("宋体", 10.5F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.Name = "frmChargeIns";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "保险维护管理";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChargeIns_KeyDown);
			this.Load += new System.EventHandler(this.frmChargeIns_Load);
			this.m_tabChargeIns.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override void CreateController()
		{
			this.objController=new com.digitalwave.iCare.gui.HIS.clsCtl_ChargeIns();
			objController.Set_GUI_Apperance(this);
		}

//		public new void Show_MDI_Child(Form frmMDI_Parent)
//		{
//
//			this.ShowDialog();
//			
//		}

		private void frmChargeIns_Load(object sender, System.EventArgs e)
		{	
			((clsCtl_ChargeIns)this.objController).m_mthGetINSCOMPANYDataArr();
			((clsCtl_ChargeIns)this.objController).m_mthGetINSPLANataArr();
			((clsCtl_ChargeIns)this.objController).m_mthGetINSCOPAYataArr();
			((clsCtl_ChargeIns)this.objController).mthfillm_cboCOMPANYID_CHR();
			((clsCtl_ChargeIns)this.objController).mthfillm_cboPLANID_CHR();
			
		}

		private void m_lsvINSCOMPANY_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
				if(m_lsvINSCOMPANY.SelectedIndices.Count>0)
			{
				m_txtCOMPANYNAME.Text=m_lsvINSCOMPANY.SelectedItems[0].SubItems[3].Text;
				m_txINSCOMPANYUSERCODE.Text = m_lsvINSCOMPANY.SelectedItems[0].SubItems[2].Text;
				m_txtINSCOMPANYREMARK.Text = m_lsvINSCOMPANY.SelectedItems[0].SubItems[4].Text;
				m_txtCOMPANYNAME.Tag=m_lsvINSCOMPANY.SelectedItems[0].Tag;
			}
		}

		private void m_lsvINSCOMPANY_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			m_txtCOMPANYNAME.Focus();
			m_txtCOMPANYNAME.SelectAll();
		}

		private void m_btnINSCOMPANYNew_Click(object sender, System.EventArgs e)
		{
			m_txtCOMPANYNAME.Text="";
			m_txINSCOMPANYUSERCODE.Text="";
			m_txtINSCOMPANYREMARK.Text ="";
			m_txtCOMPANYNAME.Tag=null;
			this.m_txtCOMPANYNAME.Focus();
		}

		private void m_btnINSCOMPANYSave_Click(object sender, System.EventArgs e)
		{
			((clsCtl_ChargeIns)this.objController).m_mthSave();
		}

		private void m_btnINSCOMPANYDel_Click(object sender, System.EventArgs e)
		{
			((clsCtl_ChargeIns)this.objController).m_mthINSCOMPANYDel();
		}

		private void m_btnINSPLANSave_Click(object sender, System.EventArgs e)
		{
			((clsCtl_ChargeIns)this.objController).m_mthSaveINSPLAN();
		}

		private void m_btnINSPLANDel_Click(object sender, System.EventArgs e)
		{
			((clsCtl_ChargeIns)this.objController).m_mthDelINSPLAN();
		}

		private void m_btnINSPLANNew_Click(object sender, System.EventArgs e)
		{
			m_txtPLANNAME_CHR_INSPLAN.Text="";
			m_txtUSERCODE_CHR_INSPLAN.Text="";
			m_txtREMARK_VCHR_INSPLAN.Text = "";
			m_txtPLANNAME_CHR_INSPLAN.Tag=null;
			m_txtPLANNAME_CHR_INSPLAN.Focus();
		}

		private void m_lsvINSPLAN_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
			if(m_lsvINSPLAN.SelectedIndices.Count>0)
			{
				m_txtPLANNAME_CHR_INSPLAN.Text=m_lsvINSPLAN.SelectedItems[0].SubItems[3].Text.Trim();
				m_txtUSERCODE_CHR_INSPLAN.Text = m_lsvINSPLAN.SelectedItems[0].SubItems[2].Text.Trim();
				m_txtREMARK_VCHR_INSPLAN.Text = m_lsvINSPLAN.SelectedItems[0].SubItems[4].Text.Trim();
				m_cboCOMPANYID_CHR.Text =  m_lsvINSPLAN.SelectedItems[0].SubItems[6].Text.Trim();
				m_txtPLANNAME_CHR_INSPLAN.Tag=m_lsvINSPLAN.SelectedItems[0].Tag;
			}
		}

		private void m_btnNew_INSCOPAY_Click(object sender, System.EventArgs e)
		{
			m_txtCOPAYNAME_CHR_INSCOPAY.Text="";
			m_txtPRECENT_DEC_INSCOPAY.Text="";
			m_txtUSERCODE_CHR_INSCOPAY.Text = "";
			m_txtREMARK_VCHR_INSCOPAY.Text = "";
			m_txtCOPAYNAME_CHR_INSCOPAY.Tag=null;
			m_txtCOPAYNAME_CHR_INSCOPAY.Focus();
		}

		private void m_btnSave_INSCOPAY_Click(object sender, System.EventArgs e)
		{
			((clsCtl_ChargeIns)this.objController).m_mthSaveINSCOPAY();
		}

		private void m_btnDel_INSCOPAY_Click(object sender, System.EventArgs e)
		{
			((clsCtl_ChargeIns)this.objController).m_mthDelINSCOPAY();
		}

		private void m_lsv_INSCOPAY_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_lsv_INSCOPAY.SelectedIndices.Count>0)
			{
				m_txtCOPAYNAME_CHR_INSCOPAY.Text=m_lsv_INSCOPAY.SelectedItems[0].SubItems[3].Text;
				m_txtPRECENT_DEC_INSCOPAY.Text = m_lsv_INSCOPAY.SelectedItems[0].SubItems[4].Text;
				m_txtUSERCODE_CHR_INSCOPAY.Text = m_lsv_INSCOPAY.SelectedItems[0].SubItems[2].Text;
				m_txtREMARK_VCHR_INSCOPAY.Text = m_lsv_INSCOPAY.SelectedItems[0].SubItems[5].Text;
				m_cboPLANID_CHR.Text =  m_lsv_INSCOPAY.SelectedItems[0].SubItems[7].Text;
				
				m_txtCOPAYNAME_CHR_INSCOPAY.Tag=m_lsv_INSCOPAY.SelectedItems[0].Tag;
			}
		}

		private void m_lsvINSPLAN_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			m_txtPLANNAME_CHR_INSPLAN.Focus();
			m_txtPLANNAME_CHR_INSPLAN.SelectAll();
		}

		private void m_lsv_INSCOPAY_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			m_txtCOPAYNAME_CHR_INSCOPAY.Focus();
			m_txtCOPAYNAME_CHR_INSCOPAY.SelectAll();
		}

		private void m_cboCOMPANYID_CHR_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			((clsCtl_ChargeIns)this.objController).mthfillm_cboCOMPANYID_CHR();
		}

		private void m_lsv_INSCOPAY_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			((clsCtl_ChargeIns)this.objController).mthfillm_cboPLANID_CHR();
		}

		private void m_cboPLANID_CHR_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			((clsCtl_ChargeIns)this.objController).mthfillm_cboPLANID_CHR();
		}

		

		private void m_tabChargeIns_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			((clsCtl_ChargeIns)this.objController).m_mthGetINSCOMPANYDataArr();
			((clsCtl_ChargeIns)this.objController).m_mthGetINSPLANataArr();
			((clsCtl_ChargeIns)this.objController).m_mthGetINSCOPAYataArr();
		}

		private void frmChargeIns_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Escape)
			{
				if(MessageBox.Show("确认退出吗?","iCare",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
					return;
					m_btnINSCOMPANYExit_Click(sender,e);
			}
		}

		private void m_btnINSCOMPANYExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	
	}
}
