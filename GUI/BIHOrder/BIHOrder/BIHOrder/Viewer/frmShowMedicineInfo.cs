using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.BIHOrder
{
	/// <summary>
	/// frmShowMedicineInfo 的摘要说明。
	/// </summary>
	public class frmShowMedicineInfo : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.TextBox m_txtMedicineInfo;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmShowMedicineInfo(string p_strMedicineInfo)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			m_txtMedicineInfo.Text = p_strMedicineInfo;
			try
			{
				m_txtMedicineInfo.Select(m_txtMedicineInfo.Text.Length,m_txtMedicineInfo.Text.Length);
			}
			catch{}
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
			this.m_txtMedicineInfo = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// m_txtMedicineInfo
			// 
			this.m_txtMedicineInfo.BackColor = System.Drawing.SystemColors.Info;
			this.m_txtMedicineInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_txtMedicineInfo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtMedicineInfo.Location = new System.Drawing.Point(0, 0);
			this.m_txtMedicineInfo.Multiline = true;
			this.m_txtMedicineInfo.Name = "m_txtMedicineInfo";
			this.m_txtMedicineInfo.ReadOnly = true;
			this.m_txtMedicineInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.m_txtMedicineInfo.Size = new System.Drawing.Size(544, 320);
			this.m_txtMedicineInfo.TabIndex = 0;
			this.m_txtMedicineInfo.Text = "";
			this.m_txtMedicineInfo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtMedicineInfo_KeyDown);
			// 
			// frmShowMedicineInfo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(544, 320);
			this.Controls.Add(this.m_txtMedicineInfo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmShowMedicineInfo";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "药品信息";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmShowMedicineInfo_KeyDown);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmShowMedicineInfo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch(e.KeyCode)
			{
				case Keys.Enter:
					this.Close();
					break;
				case Keys.F9:
					this.Close();
					break;
				case Keys.Escape:
					this.Close();
					break;
				default:
					break;
			}
		}

		private void m_txtMedicineInfo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch(e.KeyCode)
			{
				case Keys.Enter:
					this.Close();
					break;
				case Keys.F9:
					this.Close();
					break;
				case Keys.Escape:
					this.Close();
					break;
				default:
					break;
			}
		}
	}
}
