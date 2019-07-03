using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmPatientPayType 的摘要说明。
	/// </summary>
	public class frmPatientPayType : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private PinkieControls.ButtonXP m_btnDel;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtName;
		private PinkieControls.ButtonXP m_btnExit;
		private PinkieControls.ButtonXP m_btnSave;
		private PinkieControls.ButtonXP m_btnNew;
		private System.Windows.Forms.Label label1;
		internal System.Windows.Forms.ListView m_lvw;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtMemo;
		private System.Windows.Forms.Label labelMemo;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.Label label2;
		internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric m_txtPayMilite;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.Label label3;
		internal System.Windows.Forms.ComboBox m_cboPAYFLAG_DEC;
		private System.Windows.Forms.Label label4;
		internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric m_txtPAYPERCENT_DEC;
		private System.Windows.Forms.Label label5;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtPAYTYPENO_VCHR;
		private System.Windows.Forms.Label label6;
		internal System.Windows.Forms.Label m_lblIsStopUse;
		internal PinkieControls.ButtonXP m_btnStopUse;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric m_txtCHARGEPERCENT_DEC;
		internal com.digitalwave.controls.ctlQComboBox m_cboCOPAYID_CHR;
		internal System.Windows.Forms.ComboBox m_cobType;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.GroupBox groupBox1;
		internal System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.ColumnHeader columnHeader12;
        internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric textBoxTypedNumeric1;
        private Label label10;
        private ColumnHeader columnHeader13;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmPatientPayType()
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxTypedNumeric1 = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_txtName = new SourceLibrary.Windows.Forms.TextBoxTyped();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtPayMilite = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
            this.m_cboCOPAYID_CHR = new com.digitalwave.controls.ctlQComboBox();
            this.m_cobType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.m_txtCHARGEPERCENT_DEC = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
            this.m_cboPAYFLAG_DEC = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelMemo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.m_txtPAYPERCENT_DEC = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
            this.m_txtMemo = new SourceLibrary.Windows.Forms.TextBoxTyped();
            this.label5 = new System.Windows.Forms.Label();
            this.m_txtPAYTYPENO_VCHR = new SourceLibrary.Windows.Forms.TextBoxTyped();
            this.m_lblIsStopUse = new System.Windows.Forms.Label();
            this.m_btnStopUse = new PinkieControls.ButtonXP();
            this.m_btnDel = new PinkieControls.ButtonXP();
            this.m_btnExit = new PinkieControls.ButtonXP();
            this.m_btnSave = new PinkieControls.ButtonXP();
            this.m_btnNew = new PinkieControls.ButtonXP();
            this.label3 = new System.Windows.Forms.Label();
            this.m_lvw = new System.Windows.Forms.ListView();
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
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(24, 472);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(208, 24);
            this.checkBox1.TabIndex = 71;
            this.checkBox1.Text = "需要合并同医生处方收费";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxTypedNumeric1);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.m_txtName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.m_txtPayMilite);
            this.groupBox1.Controls.Add(this.m_cboCOPAYID_CHR);
            this.groupBox1.Controls.Add(this.m_cobType);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.m_txtCHARGEPERCENT_DEC);
            this.groupBox1.Controls.Add(this.m_cboPAYFLAG_DEC);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.labelMemo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.m_txtPAYPERCENT_DEC);
            this.groupBox1.Controls.Add(this.m_txtMemo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.m_txtPAYTYPENO_VCHR);
            this.groupBox1.Location = new System.Drawing.Point(0, 320);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(872, 136);
            this.groupBox1.TabIndex = 70;
            this.groupBox1.TabStop = false;
            // 
            // textBoxTypedNumeric1
            // 
            this.textBoxTypedNumeric1.CausesValidation = false;
            this.textBoxTypedNumeric1.EnableAutoValidation = true;
            this.textBoxTypedNumeric1.EnableEnterKeyValidate = true;
            this.textBoxTypedNumeric1.EnableEscapeKeyUndo = true;
            this.textBoxTypedNumeric1.EnableLastValidValue = true;
            this.textBoxTypedNumeric1.ErrorProvider = null;
            this.textBoxTypedNumeric1.ErrorProviderMessage = "Invalid value";
            this.textBoxTypedNumeric1.ForceFormatText = true;
            this.textBoxTypedNumeric1.Location = new System.Drawing.Point(728, 99);
            this.textBoxTypedNumeric1.MaxLength = 10;
            this.textBoxTypedNumeric1.Name = "textBoxTypedNumeric1";
            this.textBoxTypedNumeric1.NumericCharStyle = SourceLibrary.Windows.Forms.NumericCharStyle.DecimalSeparator;
            this.textBoxTypedNumeric1.Size = new System.Drawing.Size(120, 23);
            this.textBoxTypedNumeric1.TabIndex = 9;
            this.textBoxTypedNumeric1.Text = "0";
            this.textBoxTypedNumeric1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxTypedNumeric1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxTypedNumeric1_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(600, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 14);
            this.label10.TabIndex = 71;
            this.label10.Text = "住院费用下限:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 14);
            this.label6.TabIndex = 65;
            this.label6.Text = "身份编号:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtName
            // 
            this.m_txtName.EnableAutoValidation = true;
            this.m_txtName.EnableEnterKeyValidate = true;
            this.m_txtName.EnableEscapeKeyUndo = true;
            this.m_txtName.EnableLastValidValue = true;
            this.m_txtName.ErrorProvider = null;
            this.m_txtName.ErrorProviderMessage = "Invalid value";
            this.m_txtName.ForceFormatText = true;
            this.m_txtName.Location = new System.Drawing.Point(104, 16);
            this.m_txtName.MaxLength = 20;
            this.m_txtName.Name = "m_txtName";
            this.m_txtName.Size = new System.Drawing.Size(120, 23);
            this.m_txtName.TabIndex = 0;
            this.m_txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtName_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(280, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 14);
            this.label2.TabIndex = 30;
            this.label2.Text = "公 费 上 限:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtPayMilite
            // 
            this.m_txtPayMilite.CausesValidation = false;
            this.m_txtPayMilite.EnableAutoValidation = true;
            this.m_txtPayMilite.EnableEnterKeyValidate = true;
            this.m_txtPayMilite.EnableEscapeKeyUndo = true;
            this.m_txtPayMilite.EnableLastValidValue = true;
            this.m_txtPayMilite.ErrorProvider = null;
            this.m_txtPayMilite.ErrorProviderMessage = "Invalid value";
            this.m_txtPayMilite.ForceFormatText = true;
            this.m_txtPayMilite.Location = new System.Drawing.Point(392, 56);
            this.m_txtPayMilite.MaxLength = 8;
            this.m_txtPayMilite.Name = "m_txtPayMilite";
            this.m_txtPayMilite.NumericCharStyle = SourceLibrary.Windows.Forms.NumericCharStyle.DecimalSeparator;
            this.m_txtPayMilite.Size = new System.Drawing.Size(120, 23);
            this.m_txtPayMilite.TabIndex = 4;
            this.m_txtPayMilite.Text = "0";
            this.m_txtPayMilite.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtPayMilite.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtPayMilite_KeyDown);
            // 
            // m_cboCOPAYID_CHR
            // 
            this.m_cboCOPAYID_CHR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboCOPAYID_CHR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboCOPAYID_CHR.Location = new System.Drawing.Point(728, 70);
            this.m_cboCOPAYID_CHR.Name = "m_cboCOPAYID_CHR";
            this.m_cboCOPAYID_CHR.Size = new System.Drawing.Size(121, 22);
            this.m_cboCOPAYID_CHR.TabIndex = 8;
            this.m_cboCOPAYID_CHR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cboCOPAYID_CHR_KeyDown);
            // 
            // m_cobType
            // 
            this.m_cobType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_cobType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cobType.Items.AddRange(new object[] {
            "普通",
            "公费",
            "医保",
            "特困",
            "离休",
            "本院"});
            this.m_cobType.Location = new System.Drawing.Point(104, 96);
            this.m_cobType.Name = "m_cobType";
            this.m_cobType.Size = new System.Drawing.Size(120, 22);
            this.m_cobType.TabIndex = 2;
            this.m_cobType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cobType_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 14);
            this.label9.TabIndex = 69;
            this.label9.Text = "身份标识:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtCHARGEPERCENT_DEC
            // 
            this.m_txtCHARGEPERCENT_DEC.CausesValidation = false;
            this.m_txtCHARGEPERCENT_DEC.EnableAutoValidation = true;
            this.m_txtCHARGEPERCENT_DEC.EnableEnterKeyValidate = true;
            this.m_txtCHARGEPERCENT_DEC.EnableEscapeKeyUndo = true;
            this.m_txtCHARGEPERCENT_DEC.EnableLastValidValue = true;
            this.m_txtCHARGEPERCENT_DEC.ErrorProvider = null;
            this.m_txtCHARGEPERCENT_DEC.ErrorProviderMessage = "Invalid value";
            this.m_txtCHARGEPERCENT_DEC.ForceFormatText = true;
            this.m_txtCHARGEPERCENT_DEC.Location = new System.Drawing.Point(728, 41);
            this.m_txtCHARGEPERCENT_DEC.MaxLength = 5;
            this.m_txtCHARGEPERCENT_DEC.Name = "m_txtCHARGEPERCENT_DEC";
            this.m_txtCHARGEPERCENT_DEC.NumericCharStyle = SourceLibrary.Windows.Forms.NumericCharStyle.DecimalSeparator;
            this.m_txtCHARGEPERCENT_DEC.Size = new System.Drawing.Size(120, 23);
            this.m_txtCHARGEPERCENT_DEC.TabIndex = 7;
            this.m_txtCHARGEPERCENT_DEC.Text = "0";
            this.m_txtCHARGEPERCENT_DEC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtCHARGEPERCENT_DEC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtCHARGEPERCENT_DEC_KeyDown);
            // 
            // m_cboPAYFLAG_DEC
            // 
            this.m_cboPAYFLAG_DEC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboPAYFLAG_DEC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboPAYFLAG_DEC.Items.AddRange(new object[] {
            "公共",
            "门诊 ",
            "住院"});
            this.m_cboPAYFLAG_DEC.Location = new System.Drawing.Point(392, 96);
            this.m_cboPAYFLAG_DEC.Name = "m_cboPAYFLAG_DEC";
            this.m_cboPAYFLAG_DEC.Size = new System.Drawing.Size(120, 22);
            this.m_cboPAYFLAG_DEC.TabIndex = 5;
            this.m_cboPAYFLAG_DEC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cboPAYFLAG_DEC_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(600, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 14);
            this.label7.TabIndex = 62;
            this.label7.Text = "收费自付比例:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 18;
            this.label1.Text = "名    称:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMemo
            // 
            this.labelMemo.AutoSize = true;
            this.labelMemo.Location = new System.Drawing.Point(280, 16);
            this.labelMemo.Name = "labelMemo";
            this.labelMemo.Size = new System.Drawing.Size(98, 14);
            this.labelMemo.TabIndex = 18;
            this.labelMemo.Text = "备        注:";
            this.labelMemo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(280, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 14);
            this.label4.TabIndex = 30;
            this.label4.Text = "收 费 类 型:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(600, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 14);
            this.label8.TabIndex = 30;
            this.label8.Text = "保  险 计 划:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtPAYPERCENT_DEC
            // 
            this.m_txtPAYPERCENT_DEC.AcceptsTab = true;
            this.m_txtPAYPERCENT_DEC.CausesValidation = false;
            this.m_txtPAYPERCENT_DEC.EnableAutoValidation = true;
            this.m_txtPAYPERCENT_DEC.EnableEnterKeyValidate = true;
            this.m_txtPAYPERCENT_DEC.EnableEscapeKeyUndo = true;
            this.m_txtPAYPERCENT_DEC.EnableLastValidValue = true;
            this.m_txtPAYPERCENT_DEC.ErrorProvider = null;
            this.m_txtPAYPERCENT_DEC.ErrorProviderMessage = "Invalid value";
            this.m_txtPAYPERCENT_DEC.ForceFormatText = true;
            this.m_txtPAYPERCENT_DEC.Location = new System.Drawing.Point(728, 12);
            this.m_txtPAYPERCENT_DEC.MaxLength = 5;
            this.m_txtPAYPERCENT_DEC.Name = "m_txtPAYPERCENT_DEC";
            this.m_txtPAYPERCENT_DEC.NumericCharStyle = SourceLibrary.Windows.Forms.NumericCharStyle.DecimalSeparator;
            this.m_txtPAYPERCENT_DEC.Size = new System.Drawing.Size(120, 23);
            this.m_txtPAYPERCENT_DEC.TabIndex = 6;
            this.m_txtPAYPERCENT_DEC.Text = "0";
            this.m_txtPAYPERCENT_DEC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtPAYPERCENT_DEC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtPAYPERCENT_DEC_KeyDown);
            // 
            // m_txtMemo
            // 
            this.m_txtMemo.EnableAutoValidation = true;
            this.m_txtMemo.EnableEnterKeyValidate = true;
            this.m_txtMemo.EnableEscapeKeyUndo = true;
            this.m_txtMemo.EnableLastValidValue = true;
            this.m_txtMemo.ErrorProvider = null;
            this.m_txtMemo.ErrorProviderMessage = "Invalid value";
            this.m_txtMemo.ForceFormatText = true;
            this.m_txtMemo.Location = new System.Drawing.Point(392, 16);
            this.m_txtMemo.MaxLength = 100;
            this.m_txtMemo.Name = "m_txtMemo";
            this.m_txtMemo.Size = new System.Drawing.Size(120, 23);
            this.m_txtMemo.TabIndex = 3;
            this.m_txtMemo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtMemo_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(600, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 14);
            this.label5.TabIndex = 62;
            this.label5.Text = "挂号自付比例:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtPAYTYPENO_VCHR
            // 
            this.m_txtPAYTYPENO_VCHR.EnableAutoValidation = true;
            this.m_txtPAYTYPENO_VCHR.EnableEnterKeyValidate = true;
            this.m_txtPAYTYPENO_VCHR.EnableEscapeKeyUndo = true;
            this.m_txtPAYTYPENO_VCHR.EnableLastValidValue = true;
            this.m_txtPAYTYPENO_VCHR.ErrorProvider = null;
            this.m_txtPAYTYPENO_VCHR.ErrorProviderMessage = "Invalid value";
            this.m_txtPAYTYPENO_VCHR.ForceFormatText = true;
            this.m_txtPAYTYPENO_VCHR.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.m_txtPAYTYPENO_VCHR.Location = new System.Drawing.Point(104, 56);
            this.m_txtPAYTYPENO_VCHR.MaxLength = 4;
            this.m_txtPAYTYPENO_VCHR.Name = "m_txtPAYTYPENO_VCHR";
            this.m_txtPAYTYPENO_VCHR.Size = new System.Drawing.Size(120, 23);
            this.m_txtPAYTYPENO_VCHR.TabIndex = 1;
            this.m_txtPAYTYPENO_VCHR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtPAYTYPENO_VCHR_KeyDown);
            // 
            // m_lblIsStopUse
            // 
            this.m_lblIsStopUse.BackColor = System.Drawing.SystemColors.Control;
            this.m_lblIsStopUse.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblIsStopUse.ForeColor = System.Drawing.Color.Coral;
            this.m_lblIsStopUse.Location = new System.Drawing.Point(40, 304);
            this.m_lblIsStopUse.Name = "m_lblIsStopUse";
            this.m_lblIsStopUse.Size = new System.Drawing.Size(72, 24);
            this.m_lblIsStopUse.TabIndex = 67;
            this.m_lblIsStopUse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_btnStopUse
            // 
            this.m_btnStopUse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnStopUse.DefaultScheme = true;
            this.m_btnStopUse.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnStopUse.Hint = "";
            this.m_btnStopUse.Location = new System.Drawing.Point(568, 472);
            this.m_btnStopUse.Name = "m_btnStopUse";
            this.m_btnStopUse.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnStopUse.Size = new System.Drawing.Size(96, 32);
            this.m_btnStopUse.TabIndex = 66;
            this.m_btnStopUse.Text = "停用";
            this.m_btnStopUse.Click += new System.EventHandler(this.m_btnStopUse_Click);
            // 
            // m_btnDel
            // 
            this.m_btnDel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnDel.DefaultScheme = true;
            this.m_btnDel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnDel.Hint = "";
            this.m_btnDel.Location = new System.Drawing.Point(672, 472);
            this.m_btnDel.Name = "m_btnDel";
            this.m_btnDel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnDel.Size = new System.Drawing.Size(96, 32);
            this.m_btnDel.TabIndex = 20;
            this.m_btnDel.Text = "删除(&D)";
            this.m_btnDel.Click += new System.EventHandler(this.m_btnDel_Click);
            // 
            // m_btnExit
            // 
            this.m_btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnExit.DefaultScheme = true;
            this.m_btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnExit.Hint = "";
            this.m_btnExit.Location = new System.Drawing.Point(776, 472);
            this.m_btnExit.Name = "m_btnExit";
            this.m_btnExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnExit.Size = new System.Drawing.Size(96, 32);
            this.m_btnExit.TabIndex = 19;
            this.m_btnExit.Text = "退出(Esc)";
            this.m_btnExit.Click += new System.EventHandler(this.m_btnExit_Click);
            // 
            // m_btnSave
            // 
            this.m_btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnSave.DefaultScheme = true;
            this.m_btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnSave.Hint = "";
            this.m_btnSave.Location = new System.Drawing.Point(464, 472);
            this.m_btnSave.Name = "m_btnSave";
            this.m_btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnSave.Size = new System.Drawing.Size(96, 32);
            this.m_btnSave.TabIndex = 16;
            this.m_btnSave.Text = "保存(&S)";
            this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
            // 
            // m_btnNew
            // 
            this.m_btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnNew.DefaultScheme = true;
            this.m_btnNew.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnNew.Hint = "";
            this.m_btnNew.Location = new System.Drawing.Point(360, 472);
            this.m_btnNew.Name = "m_btnNew";
            this.m_btnNew.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnNew.Size = new System.Drawing.Size(96, 32);
            this.m_btnNew.TabIndex = 10;
            this.m_btnNew.Text = "新增(&A)";
            this.m_btnNew.Click += new System.EventHandler(this.m_btnNew_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 304);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 18;
            this.label3.Text = "状态";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lvw
            // 
            this.m_lvw.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
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
            this.columnHeader13});
            this.m_lvw.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_lvw.FullRowSelect = true;
            this.m_lvw.GridLines = true;
            this.m_lvw.HideSelection = false;
            this.m_lvw.Location = new System.Drawing.Point(0, 0);
            this.m_lvw.MultiSelect = false;
            this.m_lvw.Name = "m_lvw";
            this.m_lvw.Size = new System.Drawing.Size(882, 304);
            this.m_lvw.TabIndex = 14;
            this.m_lvw.UseCompatibleStateImageBehavior = false;
            this.m_lvw.View = System.Windows.Forms.View.Details;
            this.m_lvw.SelectedIndexChanged += new System.EventHandler(this.m_lvw_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "columnHeader1";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "身份编号";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 87;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "身份名称";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "备注";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 95;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "公费上限";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 96;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "收费类型";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 85;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "挂号自付比例";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 122;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "状态";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader8.Width = 0;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "收费自付比例";
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader9.Width = 107;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "保险计划";
            this.columnHeader10.Width = 109;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "类型身份";
            this.columnHeader11.Width = 80;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Width = 0;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "住院费下限";
            this.columnHeader13.Width = 100;
            // 
            // frmPatientPayType
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(882, 511);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_lblIsStopUse);
            this.Controls.Add(this.m_btnStopUse);
            this.Controls.Add(this.m_btnDel);
            this.Controls.Add(this.m_btnExit);
            this.Controls.Add(this.m_btnSave);
            this.Controls.Add(this.m_btnNew);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_lvw);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmPatientPayType";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "挂号身份";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPatientPayType_KeyDown);
            this.Load += new System.EventHandler(this.frmPatientPayType_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public override void CreateController()
		{
			this.objController=new com.digitalwave.iCare.gui.HIS.clsControlPatientPayType();
			objController.Set_GUI_Apperance(this);
		}


		public new void Show_MDI_Child(Form frmMDI_Parent)
		{
			this.ShowDialog();
		}


		private void m_btnNew_Click(object sender, System.EventArgs e)
		{
			m_txtName.Text="";
			m_txtMemo.Text="";
			m_cboPAYFLAG_DEC.Text = "自费";
            m_txtPAYPERCENT_DEC.Text = "0";
			m_txtPAYTYPENO_VCHR.Text="";
            m_txtPayMilite.Text = "0";
			m_txtName.Tag=null;
            m_txtCHARGEPERCENT_DEC.Text = "0";
			m_cobType.Text="";
			this.checkBox1.Checked =false;
			this.m_txtName.Focus();
            textBoxTypedNumeric1.Text = "0";
		}

		private void m_btnSave_Click(object sender, System.EventArgs e)
		{
			((clsControlPatientPayType)this.objController).m_lngSavePatientPayType();
			
		}

		private void m_btnDel_Click(object sender, System.EventArgs e)
		{
			((clsControlPatientPayType)this.objController).m_DelPatientPayType();
		}

		private void m_btnExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void m_lvw_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
			if(m_lvw.SelectedIndices.Count>0)
			{
				m_txtName.Text=m_lvw.SelectedItems[0].SubItems[2].Text;
				this.m_txtMemo.Text = m_lvw.SelectedItems[0].SubItems[3].Text;
				this.m_txtPayMilite.Text = m_lvw.SelectedItems[0].SubItems[4].Text;
				m_txtPAYPERCENT_DEC.Text=m_lvw.SelectedItems[0].SubItems[6].Text;
				m_txtPAYTYPENO_VCHR.Text=m_lvw.SelectedItems[0].SubItems[1].Text;
				m_txtCHARGEPERCENT_DEC.Text = m_lvw.SelectedItems[0].SubItems[8].Text;
				m_cboCOPAYID_CHR.Text = m_lvw.SelectedItems[0].SubItems[9].Text;
				m_txtName.Tag=m_lvw.SelectedItems[0].Tag;

				if(m_lvw.SelectedItems[0].SubItems[7].Text.Trim()=="0")	
				{
					m_lblIsStopUse.Text="已停用";
					m_btnStopUse.Text ="恢复";
					m_btnStopUse.Tag = "1";

				}
				else if(m_lvw.SelectedItems[0].SubItems[7].Text.Trim()=="1")
				{
					m_lblIsStopUse.Text="正常";
					m_btnStopUse.Text ="停用";
					m_btnStopUse.Tag = "0";
				}
				if(m_lvw.SelectedItems[0].SubItems[11].Text.Trim()=="0")	
				{
					this.checkBox1.Checked =false;
				}
				else
				{
					this.checkBox1.Checked =true;
				}
				m_cboPAYFLAG_DEC.Text = m_lvw.SelectedItems[0].SubItems[5].Text.Trim();
				m_cobType.Text = m_lvw.SelectedItems[0].SubItems[10].Text.Trim();
                textBoxTypedNumeric1.Text = m_lvw.SelectedItems[0].SubItems[12].Text.Trim();
			}

			
		}

		private void frmPatientPayType_Load(object sender, System.EventArgs e)
		{
			((clsControlPatientPayType)this.objController).m_GetItemPatientPayType();
		}

		private void frmRegChargeType_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			base.m_mthSetKeyTab(e);
		}

		private void m_btnStopUse_Click(object sender, System.EventArgs e)
		{
			((clsControlPatientPayType)this.objController).m_mthIsUseing();
		}

		private void frmPatientPayType_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Escape)
			{
				if(MessageBox.Show("确认退出吗?","iCare",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
					return;		
				m_btnExit_Click(sender,e);
					
			}
			this.m_mthSetEnter2Tab(new System.Windows.Forms.Control[] {});
		}

		private void m_txtName_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			this.m_mthSetKeyTab(e);
		}

		private void m_txtPAYTYPENO_VCHR_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
				this.m_mthSetKeyTab(e);
		}

		private void m_txtMemo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			this.m_mthSetKeyTab(e);
		}

		private void m_txtPayMilite_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
				this.m_mthSetKeyTab(e);
		}

		private void m_cboPAYFLAG_DEC_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
				this.m_mthSetKeyTab(e);
		}

		private void m_txtPAYPERCENT_DEC_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
				this.m_mthSetKeyTab(e);
		}

		private void m_txtCHARGEPERCENT_DEC_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
				this.m_mthSetKeyTab(e);
		}

		private void m_cboCOPAYID_CHR_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
				this.m_mthSetKeyTab(e);
		}

		private void m_cobType_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			this.m_mthSetKeyTab(e);
		}

        private void textBoxTypedNumeric1_KeyDown(object sender, KeyEventArgs e)
        {
            this.m_mthSetKeyTab(e);
        }


	}
}
