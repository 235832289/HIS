using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmMedicineInfo 的摘要说明。
	/// </summary>
	public class frmMedicineInfo : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textBox2;
		public System.Windows.Forms.RichTextBox textBox1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmMedicineInfo()
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
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(32, 472);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(8, 26);
			this.textBox2.TabIndex = 0;
			this.textBox2.Text = "";
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox1.Location = new System.Drawing.Point(3, 3);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.textBox1.Size = new System.Drawing.Size(745, 504);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "";
			// 
			// frmMedicineInfo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(751, 510);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.textBox2);
			this.Font = new System.Drawing.Font("宋体", 12F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.KeyPreview = true;
			this.Name = "frmMedicineInfo";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmMedicineInfo";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMedicineInfo_KeyDown);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmMedicineInfo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Escape)
			{
				this.Close();
			}
		}
		private string text="";
		public string SetText
		{
			set
			{
			text=value;
			this.textBox1.Text=text;
			}
		}
	}
}
