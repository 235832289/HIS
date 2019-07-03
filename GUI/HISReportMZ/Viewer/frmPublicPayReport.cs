using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
	/// <summary>
	/// frmReckoningReport 的摘要说明。
	/// </summary>
	public class frmPublicPayReport: com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		internal CrystalDecisions.Windows.Forms.CrystalReportViewer cryReportViewer;
		internal PinkieControls.ButtonXP m_btnQulReg;
		internal System.Windows.Forms.DateTimePicker m_daFinDate;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		internal System.Windows.Forms.CheckBox m_chbPatienName;
		internal System.Windows.Forms.CheckBox m_chbDate;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtName;
		internal PinkieControls.ButtonXP m_btnExit;
		internal System.Windows.Forms.TextBox txtCardID;
		private System.Windows.Forms.Label label1;
		internal System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		internal System.Windows.Forms.DateTimePicker m_toDate;
		private System.Windows.Forms.Label label2;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmPublicPayReport()
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
			this.cryReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.m_btnQulReg = new PinkieControls.ButtonXP();
			this.m_daFinDate = new System.Windows.Forms.DateTimePicker();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.m_toDate = new System.Windows.Forms.DateTimePicker();
			this.txtCardID = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.m_txtName = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.m_chbDate = new System.Windows.Forms.CheckBox();
			this.m_chbPatienName = new System.Windows.Forms.CheckBox();
			this.m_btnExit = new PinkieControls.ButtonXP();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// cryReportViewer
			// 
			this.cryReportViewer.ActiveViewIndex = -1;
			this.cryReportViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.cryReportViewer.DisplayGroupTree = false;
			this.cryReportViewer.DockPadding.Bottom = 5;
			this.cryReportViewer.Location = new System.Drawing.Point(8, 18);
			this.cryReportViewer.Name = "cryReportViewer";
			this.cryReportViewer.ReportSource = null;
			this.cryReportViewer.Size = new System.Drawing.Size(984, 430);
			this.cryReportViewer.TabIndex = 59;
			// 
			// m_btnQulReg
			// 
			this.m_btnQulReg.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnQulReg.DefaultScheme = true;
			this.m_btnQulReg.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnQulReg.Hint = "";
			this.m_btnQulReg.Location = new System.Drawing.Point(816, 24);
			this.m_btnQulReg.Name = "m_btnQulReg";
			this.m_btnQulReg.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnQulReg.Size = new System.Drawing.Size(88, 24);
			this.m_btnQulReg.TabIndex = 5;
			this.m_btnQulReg.Text = "确定(F5)";
			this.m_btnQulReg.Click += new System.EventHandler(this.m_btnQulReg_Click);
			// 
			// m_daFinDate
			// 
			this.m_daFinDate.Location = new System.Drawing.Point(512, 25);
			this.m_daFinDate.Name = "m_daFinDate";
			this.m_daFinDate.Size = new System.Drawing.Size(128, 23);
			this.m_daFinDate.TabIndex = 3;
			this.m_daFinDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_daFinDate_KeyDown);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.m_toDate);
			this.groupBox1.Controls.Add(this.txtCardID);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.m_txtName);
			this.groupBox1.Controls.Add(this.m_chbDate);
			this.groupBox1.Controls.Add(this.m_chbPatienName);
			this.groupBox1.Controls.Add(this.m_btnQulReg);
			this.groupBox1.Controls.Add(this.m_daFinDate);
			this.groupBox1.Controls.Add(this.m_btnExit);
			this.groupBox1.Location = new System.Drawing.Point(8, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(1000, 56);
			this.groupBox1.TabIndex = 61;
			this.groupBox1.TabStop = false;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(648, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(20, 19);
			this.label2.TabIndex = 69;
			this.label2.Text = "至";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_toDate
			// 
			this.m_toDate.Location = new System.Drawing.Point(680, 24);
			this.m_toDate.Name = "m_toDate";
			this.m_toDate.Size = new System.Drawing.Size(128, 23);
			this.m_toDate.TabIndex = 4;
			// 
			// txtCardID
			// 
			this.txtCardID.Location = new System.Drawing.Point(64, 24);
			this.txtCardID.MaxLength = 10;
			this.txtCardID.Name = "txtCardID";
			this.txtCardID.Size = new System.Drawing.Size(104, 23);
			this.txtCardID.TabIndex = 1;
			this.txtCardID.Text = "";
			this.txtCardID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCardID_KeyDown);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 19);
			this.label1.TabIndex = 67;
			this.label1.Text = "卡 号:";
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
			this.m_txtName.Location = new System.Drawing.Point(288, 25);
			this.m_txtName.MaxLength = 20;
			this.m_txtName.Name = "m_txtName";
			this.m_txtName.Size = new System.Drawing.Size(104, 23);
			this.m_txtName.TabIndex = 2;
			this.m_txtName.Text = "";
			this.m_txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtName_KeyDown);
			// 
			// m_chbDate
			// 
			this.m_chbDate.Checked = true;
			this.m_chbDate.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_chbDate.Location = new System.Drawing.Point(408, 24);
			this.m_chbDate.Name = "m_chbDate";
			this.m_chbDate.Size = new System.Drawing.Size(96, 24);
			this.m_chbDate.TabIndex = 66;
			this.m_chbDate.Text = "查询日期:";
			this.m_chbDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.m_chbDate.CheckedChanged += new System.EventHandler(this.m_chbDate_CheckedChanged);
			// 
			// m_chbPatienName
			// 
			this.m_chbPatienName.Checked = true;
			this.m_chbPatienName.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_chbPatienName.Location = new System.Drawing.Point(192, 24);
			this.m_chbPatienName.Name = "m_chbPatienName";
			this.m_chbPatienName.Size = new System.Drawing.Size(96, 24);
			this.m_chbPatienName.TabIndex = 65;
			this.m_chbPatienName.Text = " 病人姓名:";
			this.m_chbPatienName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.m_chbPatienName.CheckedChanged += new System.EventHandler(this.m_chbPatienName_CheckedChanged);
			// 
			// m_btnExit
			// 
			this.m_btnExit.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnExit.DefaultScheme = true;
			this.m_btnExit.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnExit.Hint = "";
			this.m_btnExit.Location = new System.Drawing.Point(904, 24);
			this.m_btnExit.Name = "m_btnExit";
			this.m_btnExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnExit.Size = new System.Drawing.Size(88, 24);
			this.m_btnExit.TabIndex = 6;
			this.m_btnExit.Text = "退出(Esc)";
			this.m_btnExit.Click += new System.EventHandler(this.m_btnExit_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.cryReportViewer);
			this.groupBox2.Location = new System.Drawing.Point(8, 56);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(1000, 456);
			this.groupBox2.TabIndex = 62;
			this.groupBox2.TabStop = false;
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader1,
																						this.columnHeader2,
																						this.columnHeader3,
																						this.columnHeader4,
																						this.columnHeader5});
			this.listView1.FullRowSelect = true;
			this.listView1.GridLines = true;
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(72, 48);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(296, 88);
			this.listView1.TabIndex = 56;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.Visible = false;
			this.listView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyDown);
			this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "卡号";
			this.columnHeader1.Width = 101;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "姓名";
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "性别";
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "年龄";
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "id";
			this.columnHeader5.Width = 0;
			// 
			// frmPublicPayReport
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(1016, 517);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.KeyPreview = true;
			this.Name = "frmPublicPayReport";
			this.Text = "公费费用报表";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPublicPayReport_KeyDown);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override void CreateController()
		{
            this.objController = new com.digitalwave.iCare.gui.HIS.Reports.clsControlPublicPayReport();
			objController.Set_GUI_Apperance(this);
		}

		private void m_btnQulReg_Click(object sender, System.EventArgs e)
		{
			((clsControlPublicPayReport)this.objController).m_mthFindByDateReport();
			this.txtCardID.Focus();
		}

		private void m_chbDate_CheckedChanged(object sender, System.EventArgs e)
		{
			if (m_chbDate.Checked==true)
			{
				m_daFinDate.Enabled=true;
				m_toDate.Enabled = true;
			}
			else
			{
				m_daFinDate.Enabled=false;
				m_toDate.Enabled = false;
			}
		}

		private void m_chbPatienName_CheckedChanged(object sender, System.EventArgs e)
		{
			if (m_chbPatienName.Checked==true)
			{
				m_txtName.Enabled=true;
			}
			else
				m_txtName.Enabled=false;
		}
		
		#region 快捷键
		private void frmPublicPayReport_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.F5)
			{
				((clsControlPublicPayReport)this.objController).m_mthFindByDateReport();
				m_txtName.Focus();
			}
			if(e.KeyCode == Keys.Escape)
			{
				if(MessageBox.Show("确认退出吗?","iCare",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
					return;
				this.Close();
			}
		}

		private void m_txtName_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.F5)
			{
				((clsControlPublicPayReport)this.objController).m_mthFindByDateReport();
				m_txtName.Focus();
			}

			if(e.KeyCode == Keys.Enter)
			{
				SendKeys.SendWait("{Tab}");
			}
		}
		
		int keyTime=0;
		private void m_daFinDate_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.F5)
			{
				((clsControlPublicPayReport)this.objController).m_mthFindByDateReport();
				m_txtName.Focus();
			}

			if(e.KeyCode == Keys.Enter && keyTime != 3)
			{
				keyTime++;
				SendKeys.SendWait("{Right}");
			}

			
			if(e.KeyCode == Keys.Enter && keyTime == 3)
			{
				keyTime = 0;
				SendKeys.SendWait("{Tab}");
			}
		}
		#endregion	

		private void m_btnExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void listView1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				((clsControlPublicPayReport)this.objController).m_mthListViewDoubleClick();
			}
		}

		private void txtCardID_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				((clsControlPublicPayReport)this.objController).m_mthFindPatientInfo(1,txtCardID.Text);
			}
		}

		private void listView1_DoubleClick(object sender, System.EventArgs e)
		{
			((clsControlPublicPayReport)this.objController).m_mthListViewDoubleClick();
		}
	}
}
