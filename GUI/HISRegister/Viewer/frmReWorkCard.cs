using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmReWordCard 的摘要说明。
	/// </summary>
	public class frmReWorkCard :com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		internal System.Windows.Forms.DateTimePicker dtend;
		internal System.Windows.Forms.DateTimePicker DtStart;
		internal PinkieControls.ButtonXP m_btnfind;
		private System.Windows.Forms.Label label1;
		internal PinkieControls.ButtonXP btnEsc;
		internal com.digitalwave.controls.datagrid.ctlDataGrid ctlDgList;
		internal PinkieControls.ButtonXP btnReword;
		private System.Windows.Forms.Panel panel1;
		internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric m_txtNewCard;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label3;
		internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric txt_CarID2;
		internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric txt_CarID;
		internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric m_txtOldCard;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		internal System.Windows.Forms.TextBox m_txtName;
		internal System.Windows.Forms.CheckBox checkBox1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmReWorkCard()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
            txt_CarID.Text = "";
            m_txtOldCard.Text = "";
            m_txtNewCard.Text = "";
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
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo1 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo2 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo3 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo4 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReWorkCard));
            this.btnReword = new PinkieControls.ButtonXP();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtStart = new System.Windows.Forms.DateTimePicker();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.m_txtName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtend = new System.Windows.Forms.DateTimePicker();
            this.m_btnfind = new PinkieControls.ButtonXP();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_CarID = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
            this.btnEsc = new PinkieControls.ButtonXP();
            this.txt_CarID2 = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
            this.ctlDgList = new com.digitalwave.controls.datagrid.ctlDataGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_txtNewCard = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_txtOldCard = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDgList)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReword
            // 
            this.btnReword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnReword.DefaultScheme = true;
            this.btnReword.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnReword.Hint = "";
            this.btnReword.Location = new System.Drawing.Point(56, 80);
            this.btnReword.Name = "btnReword";
            this.btnReword.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnReword.Size = new System.Drawing.Size(122, 32);
            this.btnReword.TabIndex = 12;
            this.btnReword.Text = "保存(&S)";
            this.btnReword.Click += new System.EventHandler(this.btnReword_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtStart);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.m_txtName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtend);
            this.groupBox1.Controls.Add(this.m_btnfind);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_CarID);
            this.groupBox1.Location = new System.Drawing.Point(288, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 280);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // DtStart
            // 
            this.DtStart.Enabled = false;
            this.DtStart.Location = new System.Drawing.Point(56, 16);
            this.DtStart.Name = "DtStart";
            this.DtStart.Size = new System.Drawing.Size(120, 23);
            this.DtStart.TabIndex = 5;
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(8, 16);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(56, 24);
            this.checkBox1.TabIndex = 17;
            this.checkBox1.Text = "日期";
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // m_txtName
            // 
            this.m_txtName.Location = new System.Drawing.Point(56, 160);
            this.m_txtName.Name = "m_txtName";
            this.m_txtName.Size = new System.Drawing.Size(120, 23);
            this.m_txtName.TabIndex = 16;
            this.m_txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtName_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 23);
            this.label5.TabIndex = 15;
            this.label5.Text = "名称";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(104, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "至";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtend
            // 
            this.dtend.Enabled = false;
            this.dtend.Location = new System.Drawing.Point(56, 80);
            this.dtend.Name = "dtend";
            this.dtend.Size = new System.Drawing.Size(120, 23);
            this.dtend.TabIndex = 6;
            // 
            // m_btnfind
            // 
            this.m_btnfind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnfind.DefaultScheme = true;
            this.m_btnfind.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnfind.Hint = "";
            this.m_btnfind.Location = new System.Drawing.Point(56, 216);
            this.m_btnfind.Name = "m_btnfind";
            this.m_btnfind.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnfind.Size = new System.Drawing.Size(122, 32);
            this.m_btnfind.TabIndex = 4;
            this.m_btnfind.Text = "查找(&F)";
            this.m_btnfind.Click += new System.EventHandler(this.m_btnfind_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "卡号";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_CarID
            // 
            this.txt_CarID.EnableAutoValidation = false;
            this.txt_CarID.EnableEnterKeyValidate = false;
            this.txt_CarID.EnableEscapeKeyUndo = true;
            this.txt_CarID.EnableLastValidValue = true;
            this.txt_CarID.ErrorProvider = null;
            this.txt_CarID.ErrorProviderMessage = "Invalid value";
            this.txt_CarID.ForceFormatText = true;
            this.txt_CarID.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txt_CarID.Location = new System.Drawing.Point(56, 120);
            this.txt_CarID.MaxLength = 10;
            this.txt_CarID.Name = "txt_CarID";
            this.txt_CarID.NumericCharStyle = SourceLibrary.Windows.Forms.NumericCharStyle.None;
            this.txt_CarID.Size = new System.Drawing.Size(120, 23);
            this.txt_CarID.TabIndex = 0;
            this.txt_CarID.Text = "0";
            this.txt_CarID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_CarID.TextChanged += new System.EventHandler(this.txt_CarID_TextChanged);
            this.txt_CarID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_CarID_KeyDown);
            // 
            // btnEsc
            // 
            this.btnEsc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnEsc.DefaultScheme = true;
            this.btnEsc.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnEsc.Hint = "";
            this.btnEsc.Location = new System.Drawing.Point(56, 120);
            this.btnEsc.Name = "btnEsc";
            this.btnEsc.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnEsc.Size = new System.Drawing.Size(122, 32);
            this.btnEsc.TabIndex = 13;
            this.btnEsc.Text = "退出(ESC)";
            this.btnEsc.Click += new System.EventHandler(this.btnEsc_Click);
            // 
            // txt_CarID2
            // 
            this.txt_CarID2.EnableAutoValidation = false;
            this.txt_CarID2.EnableEnterKeyValidate = false;
            this.txt_CarID2.EnableEscapeKeyUndo = true;
            this.txt_CarID2.EnableLastValidValue = true;
            this.txt_CarID2.ErrorProvider = null;
            this.txt_CarID2.ErrorProviderMessage = "Invalid value";
            this.txt_CarID2.ForceFormatText = true;
            this.txt_CarID2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txt_CarID2.Location = new System.Drawing.Point(344, 120);
            this.txt_CarID2.MaxLength = 10;
            this.txt_CarID2.Name = "txt_CarID2";
            this.txt_CarID2.NumericCharStyle = SourceLibrary.Windows.Forms.NumericCharStyle.None;
            this.txt_CarID2.Size = new System.Drawing.Size(120, 23);
            this.txt_CarID2.TabIndex = 10;
            this.txt_CarID2.Text = "0";
            this.txt_CarID2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ctlDgList
            // 
            this.ctlDgList.AllowAddNew = false;
            this.ctlDgList.AllowDelete = false;
            this.ctlDgList.AutoAppendRow = false;
            this.ctlDgList.AutoScroll = true;
            this.ctlDgList.BackgroundColor = System.Drawing.SystemColors.Window;
            this.ctlDgList.CaptionText = "";
            this.ctlDgList.CaptionVisible = false;
            this.ctlDgList.ColumnHeadersVisible = true;
            clsColumnInfo1.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo1.BackColor = System.Drawing.Color.White;
            clsColumnInfo1.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo1.ColumnIndex = 0;
            clsColumnInfo1.ColumnName = "PATIENTCARDID_CHR";
            clsColumnInfo1.ColumnWidth = 120;
            clsColumnInfo1.Enabled = false;
            clsColumnInfo1.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo1.HeadText = "卡号";
            clsColumnInfo1.ReadOnly = true;
            clsColumnInfo1.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo2.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo2.BackColor = System.Drawing.Color.White;
            clsColumnInfo2.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo2.ColumnIndex = 1;
            clsColumnInfo2.ColumnName = "LASTNAME_VCHR";
            clsColumnInfo2.ColumnWidth = 100;
            clsColumnInfo2.Enabled = false;
            clsColumnInfo2.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo2.HeadText = "病人名称";
            clsColumnInfo2.ReadOnly = true;
            clsColumnInfo2.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo3.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo3.BackColor = System.Drawing.Color.White;
            clsColumnInfo3.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo3.ColumnIndex = 2;
            clsColumnInfo3.ColumnName = "status";
            clsColumnInfo3.ColumnWidth = 0;
            clsColumnInfo3.Enabled = true;
            clsColumnInfo3.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo3.HeadText = "status";
            clsColumnInfo3.ReadOnly = false;
            clsColumnInfo3.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo4.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo4.BackColor = System.Drawing.Color.White;
            clsColumnInfo4.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo4.ColumnIndex = 3;
            clsColumnInfo4.ColumnName = "PATIENTID_CHR";
            clsColumnInfo4.ColumnWidth = 0;
            clsColumnInfo4.Enabled = true;
            clsColumnInfo4.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo4.HeadText = "PATIENTID_CHR";
            clsColumnInfo4.ReadOnly = false;
            clsColumnInfo4.TextFont = new System.Drawing.Font("宋体", 10F);
            this.ctlDgList.Columns.Add(clsColumnInfo1);
            this.ctlDgList.Columns.Add(clsColumnInfo2);
            this.ctlDgList.Columns.Add(clsColumnInfo3);
            this.ctlDgList.Columns.Add(clsColumnInfo4);
            this.ctlDgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlDgList.FullRowSelect = true;
            this.ctlDgList.Location = new System.Drawing.Point(0, 0);
            this.ctlDgList.MultiSelect = false;
            this.ctlDgList.Name = "ctlDgList";
            this.ctlDgList.ReadOnly = true;
            this.ctlDgList.RowHeadersVisible = true;
            this.ctlDgList.RowHeaderWidth = 35;
            this.ctlDgList.SelectedRowBackColor = System.Drawing.Color.Purple;
            this.ctlDgList.SelectedRowForeColor = System.Drawing.Color.White;
            this.ctlDgList.Size = new System.Drawing.Size(278, 451);
            this.ctlDgList.TabIndex = 14;
            this.ctlDgList.m_evtCurrentCellChanged += new System.EventHandler(this.ctlDgList_m_evtCurrentCellChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ctlDgList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 453);
            this.panel1.TabIndex = 15;
            // 
            // m_txtNewCard
            // 
            this.m_txtNewCard.EnableAutoValidation = false;
            this.m_txtNewCard.EnableEnterKeyValidate = false;
            this.m_txtNewCard.EnableEscapeKeyUndo = true;
            this.m_txtNewCard.EnableLastValidValue = true;
            this.m_txtNewCard.ErrorProvider = null;
            this.m_txtNewCard.ErrorProviderMessage = "Invalid value";
            this.m_txtNewCard.ForceFormatText = true;
            this.m_txtNewCard.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtNewCard.Location = new System.Drawing.Point(56, 40);
            this.m_txtNewCard.MaxLength = 10;
            this.m_txtNewCard.Name = "m_txtNewCard";
            this.m_txtNewCard.NumericCharStyle = SourceLibrary.Windows.Forms.NumericCharStyle.None;
            this.m_txtNewCard.Size = new System.Drawing.Size(120, 23);
            this.m_txtNewCard.TabIndex = 0;
            this.m_txtNewCard.Text = "0";
            this.m_txtNewCard.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtNewCard.TextChanged += new System.EventHandler(this.m_txtNewCard_TextChanged);
            this.m_txtNewCard.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtNewCard_KeyDown);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.m_txtOldCard);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.btnReword);
            this.panel2.Controls.Add(this.m_txtNewCard);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.btnEsc);
            this.panel2.Location = new System.Drawing.Point(288, 288);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(216, 160);
            this.panel2.TabIndex = 2;
            // 
            // m_txtOldCard
            // 
            this.m_txtOldCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtOldCard.EnableAutoValidation = false;
            this.m_txtOldCard.Enabled = false;
            this.m_txtOldCard.EnableEnterKeyValidate = false;
            this.m_txtOldCard.EnableEscapeKeyUndo = true;
            this.m_txtOldCard.EnableLastValidValue = true;
            this.m_txtOldCard.ErrorProvider = null;
            this.m_txtOldCard.ErrorProviderMessage = "Invalid value";
            this.m_txtOldCard.ForceFormatText = true;
            this.m_txtOldCard.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOldCard.Location = new System.Drawing.Point(56, 8);
            this.m_txtOldCard.MaxLength = 10;
            this.m_txtOldCard.Name = "m_txtOldCard";
            this.m_txtOldCard.NumericCharStyle = SourceLibrary.Windows.Forms.NumericCharStyle.None;
            this.m_txtOldCard.Size = new System.Drawing.Size(120, 23);
            this.m_txtOldCard.TabIndex = 15;
            this.m_txtOldCard.Text = "0";
            this.m_txtOldCard.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtOldCard.TextChanged += new System.EventHandler(this.m_txtOldCard_TextChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(0, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 23);
            this.label4.TabIndex = 14;
            this.label4.Text = "旧卡号";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 10;
            this.label3.Text = "新卡号";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmReWorkCard
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(512, 453);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt_CarID2);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmReWorkCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改卡号";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmReWorkCard_KeyDown);
            this.Load += new System.EventHandler(this.frmReWordCard_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDgList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public override void CreateController()
		{
			this.objController=new com.digitalwave.iCare.gui.HIS.clsControlReWork();
			objController.Set_GUI_Apperance(this);
		}

		private void frmReWordCard_Load(object sender, System.EventArgs e)
		{
		}

		private void DtStart_ValueChanged(object sender, System.EventArgs e)
		{
			((clsControlReWork)this.objController).m_lngfrmload();
		}

		private void dtend_ValueChanged(object sender, System.EventArgs e)
		{
			((clsControlReWork)this.objController).m_lngfrmload();
		}

		private void m_txtOldCard_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
		}

		private void m_btnfind_Click(object sender, System.EventArgs e)
		{
			((clsControlReWork)this.objController).m_findData("");
		}
        public void m_FindPatien(string strPatienCar)
        {
            if (strPatienCar != "")
            {
                ((clsControlReWork)this.objController).m_findData(strPatienCar);
                m_txtNewCard.Focus();
                groupBox1.TabIndex = 10;
                panel2.TabIndex = 0;
            }
        }

		private void btnRe_Click(object sender, System.EventArgs e)
		{
			((clsControlReWork)this.objController).m_lngReturnClick();
		}

		private void btnEsc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void txt_CarID_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				if(this.txt_CarID.Text.Length<10 && this.txt_CarID.Text.Length>0)
				{
					string strCardID = "";
					strCardID = "0000000000"+this.txt_CarID.Text;
					this.txt_CarID.Text = strCardID.Substring(strCardID.Length-10); 
				}
			}
		}

		private void ctlDgList_m_evtCurrentCellChanged(object sender, System.EventArgs e)
		{
			((clsControlReWork)this.objController).m_mthSeleCardID();
		}

		private void btnReword_Click(object sender, System.EventArgs e)
		{
            m_mthSaveNewMethod();
		}
        public string strNewCard = "";
        private void m_mthSaveNewMethod()
        {
            if (m_txtNewCard.Text.Length == 10)
            {
                strNewCard = m_txtNewCard.Text;
                long lngRes = ((clsControlReWork)this.objController).m_mthUpdateCardID();
                if (lngRes == 1)
                {
                    txt_CarID.Text = "";
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    this.DialogResult = DialogResult.No;
                }
            }
            else
            {
                MessageBox.Show("卡号的长度不够！", "Icare", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

		private void m_txtName_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				((clsControlReWork)this.objController).m_findData("");
			}
		}

		private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			if(checkBox1.Checked==true)
			{
				DtStart.Enabled=true;
				dtend.Enabled=true;
			}
			else
			{
				DtStart.Enabled=false;
				dtend.Enabled=false;
			}
		}

        private void txt_CarID_TextChanged(object sender, EventArgs e)
        {
            if (this.txt_CarID.Text.Length ==10)
            {
                ((clsControlReWork)this.objController).m_findData("");
            }
            
        }

        private void m_txtNewCard_TextChanged(object sender, EventArgs e)
        {
        }

        private void m_txtNewCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.m_txtNewCard.Text.Length <= 10 && this.m_txtNewCard.Text.Length > 0)
                {
                    string strCardID = "";
                    strCardID = "0000000000" + this.m_txtNewCard.Text.Trim();
                    this.m_txtNewCard.Text = strCardID.Substring(strCardID.Length - 10);
                    m_mthSaveNewMethod();
                }
            }
        }

        private void frmReWorkCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void m_txtOldCard_TextChanged(object sender, EventArgs e)
        {
           
        }
	}
}
