using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Order.Viewer
{
	/// <summary>
	/// frmSearchForSendBack 的摘要说明。
	/// </summary>
	public class frmSearchForSendBack : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.DateTimePicker dateTimePicker2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		internal PinkieControls.ButtonXP cmdFind;
		internal PinkieControls.ButtonXP cmdRef;
		internal PinkieControls.ButtonXP cmdClose;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.ListView listView1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmSearchForSendBack()
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.cmdFind = new PinkieControls.ButtonXP();
			this.cmdRef = new PinkieControls.ButtonXP();
			this.cmdClose = new PinkieControls.ButtonXP();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.listView1 = new System.Windows.Forms.ListView();
			this.panel1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.cmdFind);
			this.panel1.Controls.Add(this.dateTimePicker1);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.textBox1);
			this.panel1.Controls.Add(this.dateTimePicker2);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.cmdRef);
			this.panel1.Controls.Add(this.cmdClose);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(992, 48);
			this.panel1.TabIndex = 0;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(50, 11);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(142, 23);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(2, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 19);
			this.label1.TabIndex = 2;
			this.label1.Text = "发票号";
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(264, 11);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(120, 23);
			this.dateTimePicker1.TabIndex = 3;
			// 
			// dateTimePicker2
			// 
			this.dateTimePicker2.Location = new System.Drawing.Point(392, 11);
			this.dateTimePicker2.Name = "dateTimePicker2";
			this.dateTimePicker2.Size = new System.Drawing.Size(120, 23);
			this.dateTimePicker2.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(200, 15);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 19);
			this.label2.TabIndex = 2;
			this.label2.Text = "退费时间";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(376, 18);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(12, 19);
			this.label3.TabIndex = 2;
			this.label3.Text = "-";
			// 
			// cmdFind
			// 
			this.cmdFind.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.cmdFind.DefaultScheme = true;
			this.cmdFind.DialogResult = System.Windows.Forms.DialogResult.None;
			this.cmdFind.Hint = "";
			this.cmdFind.Location = new System.Drawing.Point(672, 8);
			this.cmdFind.Name = "cmdFind";
			this.cmdFind.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.cmdFind.Size = new System.Drawing.Size(104, 32);
			this.cmdFind.TabIndex = 69;
			this.cmdFind.Text = "查询(F3)";
			// 
			// cmdRef
			// 
			this.cmdRef.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.cmdRef.DefaultScheme = true;
			this.cmdRef.DialogResult = System.Windows.Forms.DialogResult.None;
			this.cmdRef.Hint = "";
			this.cmdRef.Location = new System.Drawing.Point(776, 8);
			this.cmdRef.Name = "cmdRef";
			this.cmdRef.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.cmdRef.Size = new System.Drawing.Size(104, 32);
			this.cmdRef.TabIndex = 69;
			this.cmdRef.Text = "刷新(F5)";
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.cmdClose.DefaultScheme = true;
			this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.None;
			this.cmdClose.Hint = "";
			this.cmdClose.Location = new System.Drawing.Point(880, 8);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.cmdClose.Size = new System.Drawing.Size(104, 32);
			this.cmdClose.TabIndex = 69;
			this.cmdClose.Text = "关闭(Esc)";
			// 
			// tabControl1
			// 
			this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.tabControl1.Location = new System.Drawing.Point(0, 377);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(992, 296);
			this.tabControl1.TabIndex = 1;
			// 
			// tabPage1
			// 
			this.tabPage1.Location = new System.Drawing.Point(4, 26);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(984, 266);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "明细";
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new System.Drawing.Point(4, 26);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(984, 266);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "发票";
			// 
			// listView1
			// 
			this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.FullRowSelect = true;
			this.listView1.GridLines = true;
			this.listView1.Location = new System.Drawing.Point(0, 48);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(992, 329);
			this.listView1.TabIndex = 2;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// frmSearchForSendBack
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(992, 673);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("宋体", 10.5F);
			this.Name = "frmSearchForSendBack";
			this.Text = "退费发票查询";
			this.panel1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
