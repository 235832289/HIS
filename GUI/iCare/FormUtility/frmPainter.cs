using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace iCare.FormUtility
{
	/// <summary>
	/// frmPainter 的摘要说明。
	/// </summary>
	public class frmPainter : System.Windows.Forms.Form
	{
        public com.digitalwave.Utility.Controls.ctlPainter m_ctlPainter;
		private PinkieControls.ButtonXP m_cmdSave;
		private PinkieControls.ButtonXP m_cmdCancel;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmPainter(Image p_imgMain)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			
			m_ctlPainter.m_BmpCurImage = p_imgMain;
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(m_ctlPainter != null)
				{
					m_ctlPainter.m_mthClear();
				}
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
			this.m_ctlPainter = new com.digitalwave.Utility.Controls.ctlPainter();
			this.m_cmdSave = new PinkieControls.ButtonXP();
			this.m_cmdCancel = new PinkieControls.ButtonXP();
			this.SuspendLayout();
			// 
			// m_ctlPainter
			// 
			this.m_ctlPainter.AutoScroll = true;
			this.m_ctlPainter.BackColor = System.Drawing.SystemColors.Control;
			this.m_ctlPainter.ForeColor = System.Drawing.Color.Black;
			this.m_ctlPainter.Location = new System.Drawing.Point(0, 0);
			this.m_ctlPainter.m_BlnScaleSize = true;
			this.m_ctlPainter.m_ClrcmdRubber = System.Drawing.Color.Silver;
			this.m_ctlPainter.m_ClrcmdSelected = System.Drawing.Color.White;
			this.m_ctlPainter.m_ClrgpbTools = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_ctlPainter.m_ClrppgPicSize = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_ctlPainter.m_ClrrdbDash = System.Drawing.Color.Silver;
			this.m_ctlPainter.m_ClrrdbLine = System.Drawing.Color.Silver;
			this.m_ctlPainter.m_ClrrdbPen = System.Drawing.Color.Silver;
			this.m_ctlPainter.m_ClrrdbText = System.Drawing.Color.Silver;
			this.m_ctlPainter.m_IntDefaultHeight = 253;
			this.m_ctlPainter.m_IntDefaultWidth = 320;
			this.m_ctlPainter.Name = "m_ctlPainter";
			this.m_ctlPainter.Size = new System.Drawing.Size(592, 496);
			this.m_ctlPainter.TabIndex = 3;
			// 
			// m_cmdSave
			// 
			this.m_cmdSave.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdSave.DefaultScheme = true;
			this.m_cmdSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.m_cmdSave.Hint = "";
			this.m_cmdSave.Location = new System.Drawing.Point(372, 500);
			this.m_cmdSave.Name = "m_cmdSave";
			this.m_cmdSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdSave.Size = new System.Drawing.Size(68, 28);
			this.m_cmdSave.TabIndex = 2;
			this.m_cmdSave.Text = "保 存";
			this.m_cmdSave.Click += new System.EventHandler(this.m_cmdSave_Click);
			// 
			// m_cmdCancel
			// 
			this.m_cmdCancel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdCancel.DefaultScheme = true;
			this.m_cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_cmdCancel.Hint = "";
			this.m_cmdCancel.Location = new System.Drawing.Point(488, 500);
			this.m_cmdCancel.Name = "m_cmdCancel";
			this.m_cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdCancel.Size = new System.Drawing.Size(68, 28);
			this.m_cmdCancel.TabIndex = 2;
			this.m_cmdCancel.Text = "取 消";
			this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdCancel_Click);
			// 
			// frmPainter
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(592, 533);
			this.Controls.Add(this.m_cmdSave);
			this.Controls.Add(this.m_cmdCancel);
			this.Controls.Add(this.m_ctlPainter);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "frmPainter";
			this.Text = "图片编辑";
			this.ResumeLayout(false);

		}
		#endregion

		private void m_cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void m_cmdSave_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
