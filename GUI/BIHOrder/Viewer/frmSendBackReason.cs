using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.BIHOrder
{
	/// <summary>
	/// 功能：		填写退回原因
	/// 创建人：	徐斌辉
	/// 创建时间：	2005-06-04
	/// </summary>
	public class frmSendBackReason : System.Windows.Forms.Form
	{
		#region 自动生成
		internal System.Windows.Forms.TextBox m_txtReason;
		private System.Windows.Forms.Label label1;
		private PinkieControls.ButtonXP butOk;
		internal System.Windows.Forms.TextBox m_txbOrderName;
		private System.Windows.Forms.RadioButton rbutReason1;
		private System.Windows.Forms.RadioButton rbutReason2;
		private System.Windows.Forms.RadioButton rbutReason3;
		private PinkieControls.ButtonXP butEsc;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmSendBackReason()
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
			this.m_txtReason = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.m_txbOrderName = new System.Windows.Forms.TextBox();
			this.butOk = new PinkieControls.ButtonXP();
			this.rbutReason1 = new System.Windows.Forms.RadioButton();
			this.rbutReason2 = new System.Windows.Forms.RadioButton();
			this.rbutReason3 = new System.Windows.Forms.RadioButton();
			this.butEsc = new PinkieControls.ButtonXP();
			this.SuspendLayout();
			// 
			// m_txtReason
			// 
			this.m_txtReason.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.m_txtReason.Location = new System.Drawing.Point(0, 71);
			this.m_txtReason.MaxLength = 25;
			this.m_txtReason.Multiline = true;
			this.m_txtReason.Name = "m_txtReason";
			this.m_txtReason.Size = new System.Drawing.Size(410, 96);
			this.m_txtReason.TabIndex = 0;
			this.m_txtReason.Text = "";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(0, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 19);
			this.label1.TabIndex = 1;
			this.label1.Text = "医嘱：";
			// 
			// m_txbOrderName
			// 
			this.m_txbOrderName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txbOrderName.Location = new System.Drawing.Point(40, 11);
			this.m_txbOrderName.Name = "m_txbOrderName";
			this.m_txbOrderName.ReadOnly = true;
			this.m_txbOrderName.Size = new System.Drawing.Size(232, 23);
			this.m_txbOrderName.TabIndex = 2;
			this.m_txbOrderName.Text = "";
			// 
			// butOk
			// 
			this.butOk.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.butOk.DefaultScheme = true;
			this.butOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.butOk.Hint = "";
			this.butOk.Location = new System.Drawing.Point(304, 2);
			this.butOk.Name = "butOk";
			this.butOk.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.butOk.Size = new System.Drawing.Size(104, 32);
			this.butOk.TabIndex = 1;
			this.butOk.Text = "确定(&Enter)";
			this.butOk.Click += new System.EventHandler(this.butOk_Click);
			// 
			// rbutReason1
			// 
			this.rbutReason1.Checked = true;
			this.rbutReason1.Location = new System.Drawing.Point(1, 48);
			this.rbutReason1.Name = "rbutReason1";
			this.rbutReason1.Size = new System.Drawing.Size(63, 24);
			this.rbutReason1.TabIndex = 3;
			this.rbutReason1.TabStop = true;
			this.rbutReason1.Text = "缺药";
			this.rbutReason1.CheckedChanged += new System.EventHandler(this.rbutReason_CheckedChanged);
			// 
			// rbutReason2
			// 
			this.rbutReason2.Location = new System.Drawing.Point(72, 48);
			this.rbutReason2.Name = "rbutReason2";
			this.rbutReason2.Size = new System.Drawing.Size(127, 24);
			this.rbutReason2.TabIndex = 3;
			this.rbutReason2.Text = "剂量/用法不对";
			this.rbutReason2.CheckedChanged += new System.EventHandler(this.rbutReason_CheckedChanged);
			// 
			// rbutReason3
			// 
			this.rbutReason3.Location = new System.Drawing.Point(208, 48);
			this.rbutReason3.Name = "rbutReason3";
			this.rbutReason3.Size = new System.Drawing.Size(56, 24);
			this.rbutReason3.TabIndex = 3;
			this.rbutReason3.Text = "其它";
			this.rbutReason3.CheckedChanged += new System.EventHandler(this.rbutReason_CheckedChanged);
			// 
			// butEsc
			// 
			this.butEsc.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.butEsc.DefaultScheme = true;
			this.butEsc.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.butEsc.Hint = "";
			this.butEsc.Location = new System.Drawing.Point(304, 37);
			this.butEsc.Name = "butEsc";
			this.butEsc.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.butEsc.Size = new System.Drawing.Size(104, 32);
			this.butEsc.TabIndex = 1;
			this.butEsc.Text = "取消(&Esc)";
			this.butEsc.Click += new System.EventHandler(this.butEsc_Click);
			// 
			// frmSendBackReason
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(410, 167);
			this.Controls.Add(this.m_txtReason);
			this.Controls.Add(this.rbutReason3);
			this.Controls.Add(this.rbutReason2);
			this.Controls.Add(this.rbutReason1);
			this.Controls.Add(this.butOk);
			this.Controls.Add(this.m_txbOrderName);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.butEsc);
			this.Font = new System.Drawing.Font("宋体", 10.5F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmSendBackReason";
			this.Text = "提示：填写退回原因";
			this.Load += new System.EventHandler(this.frmSendBackReason_Load);
			this.ResumeLayout(false);

		}
		#endregion
		#endregion

		#region 窗体事件
		private void frmSendBackReason_Load(object sender, System.EventArgs e)
		{
			rbutReason_CheckedChanged(null,null);
			this.AcceptButton =this.butOk;
			this.CancelButton =this.butEsc;
		}
		#endregion

		#region 按钮事件
		private void butOk_Click(object sender, System.EventArgs e)
		{
			this.DialogResult =DialogResult.OK;
			this.Close();
		}

		private void butEsc_Click(object sender, System.EventArgs e)
		{
			this.DialogResult =DialogResult.Cancel;
			this.Close();
		}

		private void rbutReason_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rbutReason1.Checked)
			{
				this.m_txtReason.Text =this.rbutReason1.Text;
				this.m_txtReason.SelectAll();
				this.m_txtReason.Focus();
			}
			if (rbutReason2.Checked)
			{
				this.m_txtReason.Text =this.rbutReason2.Text;
				this.m_txtReason.SelectAll();
				this.m_txtReason.Focus();
			}
			if (rbutReason3.Checked)
			{
				this.m_txtReason.Text =this.rbutReason3.Text;
				this.m_txtReason.SelectAll();
				this.m_txtReason.Focus();
			}
		}
		#endregion
	}
}
