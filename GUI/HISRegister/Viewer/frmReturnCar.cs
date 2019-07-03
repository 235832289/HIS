using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmReturnCheck 的摘要说明。
	/// </summary>
	public class frmReturnCar:com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		internal com.digitalwave.controls.datagrid.ctlDataGrid ctlDgList;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		internal PinkieControls.ButtonXP m_btnfind;
		internal PinkieControls.ButtonXP btnReturn;
		internal System.Windows.Forms.DateTimePicker dtend;
		private System.Windows.Forms.Label label2;
		internal System.Windows.Forms.DateTimePicker DtStart;
        internal PinkieControls.ButtonXP btnEsc;
        internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric txt_CarID;
        internal CheckBox checkBox1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmReturnCar()
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
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo1 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo2 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo3 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo4 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            this.ctlDgList = new com.digitalwave.controls.datagrid.ctlDataGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtend = new System.Windows.Forms.DateTimePicker();
            this.DtStart = new System.Windows.Forms.DateTimePicker();
            this.m_btnfind = new PinkieControls.ButtonXP();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReturn = new PinkieControls.ButtonXP();
            this.btnEsc = new PinkieControls.ButtonXP();
            this.txt_CarID = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDgList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            clsColumnInfo3.ColumnWidth = 75;
            clsColumnInfo3.Enabled = false;
            clsColumnInfo3.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo3.HeadText = "状态";
            clsColumnInfo3.ReadOnly = true;
            clsColumnInfo3.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo4.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo4.BackColor = System.Drawing.Color.White;
            clsColumnInfo4.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo4.ColumnIndex = 0;
            clsColumnInfo4.ColumnName = "PATIENTID_CHR";
            clsColumnInfo4.ColumnWidth = 0;
            clsColumnInfo4.Enabled = false;
            clsColumnInfo4.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo4.HeadText = "PATIENTID_CHR";
            clsColumnInfo4.ReadOnly = true;
            clsColumnInfo4.TextFont = new System.Drawing.Font("宋体", 10F);
            this.ctlDgList.Columns.Add(clsColumnInfo1);
            this.ctlDgList.Columns.Add(clsColumnInfo2);
            this.ctlDgList.Columns.Add(clsColumnInfo3);
            this.ctlDgList.Columns.Add(clsColumnInfo4);
            this.ctlDgList.FullRowSelect = true;
            this.ctlDgList.Location = new System.Drawing.Point(0, 0);
            this.ctlDgList.MultiSelect = false;
            this.ctlDgList.Name = "ctlDgList";
            this.ctlDgList.ReadOnly = true;
            this.ctlDgList.RowHeadersVisible = true;
            this.ctlDgList.RowHeaderWidth = 35;
            this.ctlDgList.SelectedRowBackColor = System.Drawing.Color.Purple;
            this.ctlDgList.SelectedRowForeColor = System.Drawing.Color.White;
            this.ctlDgList.Size = new System.Drawing.Size(368, 448);
            this.ctlDgList.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_CarID);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtend);
            this.groupBox1.Controls.Add(this.DtStart);
            this.groupBox1.Controls.Add(this.m_btnfind);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(376, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 256);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
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
            // DtStart
            // 
            this.DtStart.Enabled = false;
            this.DtStart.Location = new System.Drawing.Point(56, 16);
            this.DtStart.Name = "DtStart";
            this.DtStart.Size = new System.Drawing.Size(120, 23);
            this.DtStart.TabIndex = 5;
            this.DtStart.ValueChanged += new System.EventHandler(this.DtStart_ValueChanged);
            // 
            // m_btnfind
            // 
            this.m_btnfind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnfind.DefaultScheme = true;
            this.m_btnfind.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnfind.Hint = "";
            this.m_btnfind.Location = new System.Drawing.Point(56, 201);
            this.m_btnfind.Name = "m_btnfind";
            this.m_btnfind.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnfind.Size = new System.Drawing.Size(122, 32);
            this.m_btnfind.TabIndex = 4;
            this.m_btnfind.Text = "查找F5";
            this.m_btnfind.Click += new System.EventHandler(this.m_btnfind_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "卡号";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnReturn.DefaultScheme = true;
            this.btnReturn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnReturn.Hint = "";
            this.btnReturn.Location = new System.Drawing.Point(432, 336);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnReturn.Size = new System.Drawing.Size(122, 32);
            this.btnReturn.TabIndex = 5;
            this.btnReturn.Text = "退卡F2";
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnEsc
            // 
            this.btnEsc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnEsc.DefaultScheme = true;
            this.btnEsc.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnEsc.Hint = "";
            this.btnEsc.Location = new System.Drawing.Point(432, 400);
            this.btnEsc.Name = "btnEsc";
            this.btnEsc.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnEsc.Size = new System.Drawing.Size(122, 32);
            this.btnEsc.TabIndex = 6;
            this.btnEsc.Text = "退出ESC";
            this.btnEsc.Click += new System.EventHandler(this.btnEsc_Click);
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
            this.txt_CarID.Location = new System.Drawing.Point(56, 135);
            this.txt_CarID.MaxLength = 10;
            this.txt_CarID.Name = "txt_CarID";
            this.txt_CarID.NumericCharStyle = SourceLibrary.Windows.Forms.NumericCharStyle.None;
            this.txt_CarID.Size = new System.Drawing.Size(120, 23);
            this.txt_CarID.TabIndex = 0;
            this.txt_CarID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_CarID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_CarID_KeyDown);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(2, 16);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(54, 18);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "日期";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // frmReturnCar
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(592, 453);
            this.Controls.Add(this.btnEsc);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ctlDgList);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmReturnCar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "退卡系统";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmReturnCar_KeyDown);
            this.Load += new System.EventHandler(this.frmReturnCar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ctlDgList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
		public override void CreateController()
		{
			this.objController=new com.digitalwave.iCare.gui.HIS.clsControlReturnCar();
			objController.Set_GUI_Apperance(this);
		}

		private void frmReturnCar_Load(object sender, System.EventArgs e)
		{
            txt_CarID.Text = "";
		}


		private void btnEsc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void m_btnfind_Click(object sender, System.EventArgs e)
		{

            ((clsControlReturnCar)this.objController).m_lngfrmload();
		}

		private void DtStart_ValueChanged(object sender, System.EventArgs e)
		{
		    
		}

		private void dtend_ValueChanged(object sender, System.EventArgs e)
		{
			((clsControlReturnCar)this.objController).m_lngfrmload();
		}

		private void btnReturn_Click(object sender, System.EventArgs e)
		{
			((clsControlReturnCar)this.objController).m_lngReturnCar();
		}

		private void btnRe_Click(object sender, System.EventArgs e)
		{
			((clsControlReturnCar)this.objController).m_lngReturnClick();
		}

		private void frmReturnCar_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.F5)
			{
				((clsControlReturnCar)this.objController).m_lngReturnCarFind();
			}
			if(e.KeyCode==Keys.F6)
			{
				((clsControlReturnCar)this.objController).m_lngReturnClick();
			}
			if(e.KeyCode==Keys.F2)
			{
				((clsControlReturnCar)this.objController).m_lngReturnCar();
			}
			if(e.KeyCode==Keys.Escape)
			{
				this.Close();
			}
		}


		private void txt_CarID_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.F5)
			{
				((clsControlReturnCar)this.objController).m_lngReturnCarFind();
			}
			if(e.KeyCode==Keys.F6)
			{
				((clsControlReturnCar)this.objController).m_lngReturnClick();
			}
			if(e.KeyCode==Keys.F2)
			{
				((clsControlReturnCar)this.objController).m_lngReturnCar();
			}
			if(e.KeyCode==Keys.Escape)
			{
				this.Close();
			}
			if(e.KeyCode==Keys.Enter)
			{
				if(this.txt_CarID.Text.Length<10 && this.txt_CarID.Text.Length>0)
				{
					string strCardID = "";
					strCardID = "0000000000"+this.txt_CarID.Text;
					this.txt_CarID.Text = strCardID.Substring(strCardID.Length-10);
				}
                ((clsControlReturnCar)this.objController).m_lngfrmload();
			}
		}

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                DtStart.Enabled = true;
                dtend.Enabled = true;
            }
            else
            {
                DtStart.Enabled = false;
                dtend.Enabled = false;
            }
        }
	}
}
