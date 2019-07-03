using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class frmFindICD10 : System.Windows.Forms.Form
	{
		private textbox.FindTextBox findTextBox1;
		private PinkieControls.ButtonXP m_cmdICD10_OK;
		private PinkieControls.ButtonXP m_cmdICD10_cancel;
		private System.Windows.Forms.TextBox text;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmFindICD10(System.Windows.Forms.TextBox tb)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			text = tb;

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
				if (components != null) 
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
			this.findTextBox1 = new textbox.FindTextBox();
			this.m_cmdICD10_OK = new PinkieControls.ButtonXP();
			this.m_cmdICD10_cancel = new PinkieControls.ButtonXP();
			this.SuspendLayout();
			// 
			// findTextBox1
			// 
			this.findTextBox1.Additional = "";
			this.findTextBox1.ColumName = "ICDNAME_VCHR";
			this.findTextBox1.ColumnConditions = "ICDCODE_CHR,ICDNAME_VCHR,PYCODE_CHR,WBCODE_CHR";
			this.findTextBox1.GetKeyDown = false;
			this.findTextBox1.ID = null;
			this.findTextBox1.IdColumName = "ICDCODE_CHR";
			this.findTextBox1.Location = new System.Drawing.Point(0, 4);
			this.findTextBox1.MaxLength = 20;
			this.findTextBox1.Name = "findTextBox1";
			this.findTextBox1.Size = new System.Drawing.Size(432, 21);
			this.findTextBox1.SQL = null;
			this.findTextBox1.TabIndex = 0;
			this.findTextBox1.Table = "T_AID_ICD10";
			this.findTextBox1.Text = "";
			this.findTextBox1.ToUpper = false;
			this.findTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.findTextBox1_KeyDown);
			// 
			// m_cmdICD10_OK
			// 
			this.m_cmdICD10_OK.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdICD10_OK.DefaultScheme = true;
			this.m_cmdICD10_OK.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdICD10_OK.Hint = "";
			this.m_cmdICD10_OK.Location = new System.Drawing.Point(172, 224);
			this.m_cmdICD10_OK.Name = "m_cmdICD10_OK";
			this.m_cmdICD10_OK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdICD10_OK.Size = new System.Drawing.Size(96, 28);
			this.m_cmdICD10_OK.TabIndex = 1;
			this.m_cmdICD10_OK.Text = "确定(F2)";
			this.m_cmdICD10_OK.Click += new System.EventHandler(this.m_cmdICD10_OK_Click);
			// 
			// m_cmdICD10_cancel
			// 
			this.m_cmdICD10_cancel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdICD10_cancel.DefaultScheme = true;
			this.m_cmdICD10_cancel.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdICD10_cancel.Hint = "";
			this.m_cmdICD10_cancel.Location = new System.Drawing.Point(292, 224);
			this.m_cmdICD10_cancel.Name = "m_cmdICD10_cancel";
			this.m_cmdICD10_cancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdICD10_cancel.Size = new System.Drawing.Size(96, 28);
			this.m_cmdICD10_cancel.TabIndex = 2;
			this.m_cmdICD10_cancel.Text = "取消(Esc)";
			this.m_cmdICD10_cancel.Click += new System.EventHandler(this.m_cmdICD10_cancel_Click);
			// 
			// frmFindICD10
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(436, 265);
			this.Controls.Add(this.m_cmdICD10_cancel);
			this.Controls.Add(this.m_cmdICD10_OK);
			this.Controls.Add(this.findTextBox1);
			this.Name = "frmFindICD10";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "ICD10查找";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmFindICD10_KeyDown);
			this.Load += new System.EventHandler(this.frmFindICD10_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void m_cmdICD10_OK_Click(object sender, System.EventArgs e)
		{
			if(this.findTextBox1.ID!="")
			{
				if(this.findTextBox1.Text.Length>500)
				{
					this.findTextBox1.Text = this.findTextBox1.Text.Substring(0,500);
				}
				else
				{
					text.Text = this.findTextBox1.Text;
					text.Tag =  this.findTextBox1.ID;
				}
			}
			this.DialogResult = DialogResult.OK;
		}

		private void m_cmdICD10_cancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult=DialogResult.Cancel;
		}

		private void findTextBox1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				this.findTextBox1.Text=this.findTextBox1.Text.ToUpper();
				this.findTextBox1.UserControl1_KeyDown(sender,e);
			}
			switch(e.KeyCode)
			{
				case Keys.F2:
				{
					if(this.findTextBox1.ID!="")
					{
						if(this.findTextBox1.Text.Length>500)
						{
							this.findTextBox1.Text = this.findTextBox1.Text.Substring(0,500);
						}
						else
						{
							text.Text = this.findTextBox1.Text;
							text.Tag = this.findTextBox1.ID;
						}
					}
					this.DialogResult = DialogResult.OK;
				}
					break;
				case Keys.Escape:
				{
					this.DialogResult=DialogResult.Cancel;
				}
					break;
				default:
					break;
			}
		}

		private void frmFindICD10_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch(e.KeyCode)
			{
				case Keys.F2:
				{
					text.Text = this.findTextBox1.Text;
					this.DialogResult = DialogResult.OK;
				}
					break;
				case Keys.Escape:
				{
					this.DialogResult=DialogResult.Cancel;
				}
					break;
				default:
					break;
			}
		}

		private void frmFindICD10_Load(object sender, System.EventArgs e)
		{
			this.findTextBox1.GetKeyDown = true;
		}
	}
}
