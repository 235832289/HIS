using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.LIS_Data_Acquisition_Controller
{
	/// <summary>
	/// frmMessageNotify 的摘要说明。
	/// </summary>
	public class frmMessageNotify : System.Windows.Forms.Form
	{
		private readonly int m_intMessageNotifyWindowLifeTime = 2000;
		public frmRealtimeMessage m_frmRealWindow;
		public clsDeviceSampleDataKey m_objKey;
		public System.Windows.Forms.LinkLabel m_lnkDeviceSample;
		public System.Windows.Forms.Label m_lblDevice;

		private static System.Collections.ArrayList s_arlForms = new ArrayList();
		private static int s_intInstance = 0;

		private System.Timers.Timer m_timClose;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button m_btnClose;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmMessageNotify()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			m_timClose = new System.Timers.Timer();
			m_timClose.Interval = m_intMessageNotifyWindowLifeTime;
			m_timClose.AutoReset = false;
			m_timClose.Elapsed += new System.Timers.ElapsedEventHandler(m_timClose_Elapsed);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMessageNotify));
			this.label1 = new System.Windows.Forms.Label();
			this.m_lnkDeviceSample = new System.Windows.Forms.LinkLabel();
			this.label2 = new System.Windows.Forms.Label();
			this.m_lblDevice = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.m_btnClose = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label3 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(130, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 19);
			this.label1.TabIndex = 0;
			this.label1.Text = "编号:";
			// 
			// m_lnkDeviceSample
			// 
			this.m_lnkDeviceSample.AutoSize = true;
			this.m_lnkDeviceSample.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.m_lnkDeviceSample.Location = new System.Drawing.Point(168, 8);
			this.m_lnkDeviceSample.Name = "m_lnkDeviceSample";
			this.m_lnkDeviceSample.Size = new System.Drawing.Size(56, 19);
			this.m_lnkDeviceSample.TabIndex = 1;
			this.m_lnkDeviceSample.TabStop = true;
			this.m_lnkDeviceSample.Text = "1234567";
			this.m_lnkDeviceSample.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkDeviceSample_LinkClicked);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(26, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 19);
			this.label2.TabIndex = 2;
			this.label2.Text = "仪器:";
			// 
			// m_lblDevice
			// 
			this.m_lblDevice.Location = new System.Drawing.Point(66, 8);
			this.m_lblDevice.Name = "m_lblDevice";
			this.m_lblDevice.Size = new System.Drawing.Size(64, 20);
			this.m_lblDevice.TabIndex = 4;
			this.m_lblDevice.Tag = "";
			this.m_lblDevice.Text = "CD1700-1";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Lavender;
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.m_lblDevice);
			this.panel1.Controls.Add(this.m_lnkDeviceSample);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Controls.Add(this.m_btnClose);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(252, 32);
			this.panel1.TabIndex = 6;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.LightSteelBlue;
			this.panel2.Controls.Add(this.label3);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(252, 4);
			this.panel2.TabIndex = 5;
			// 
			// m_btnClose
			// 
			this.m_btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.m_btnClose.Image = ((System.Drawing.Image)(resources.GetObject("m_btnClose.Image")));
			this.m_btnClose.Location = new System.Drawing.Point(224, 6);
			this.m_btnClose.Name = "m_btnClose";
			this.m_btnClose.Size = new System.Drawing.Size(24, 20);
			this.m_btnClose.TabIndex = 8;
			this.m_btnClose.Click += new System.EventHandler(this.m_btnClose_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(6, 8);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(20, 16);
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(36, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(120, 19);
			this.label3.TabIndex = 7;
			this.label3.Text = "实时数据采集消息";
			// 
			// frmMessageNotify
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(252, 32);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("宋体", 10.5F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmMessageNotify";
			this.ShowInTaskbar = false;
			this.Text = "实时数据采集消息";
			this.Closed += new System.EventHandler(this.frmMessageNotify_Closed);
			this.VisibleChanged += new System.EventHandler(this.frmMessageNotify_VisibleChanged);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void m_lnkDeviceSample_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			if(this.m_frmRealWindow.WindowState == FormWindowState.Minimized)
				this.m_frmRealWindow.WindowState = FormWindowState.Normal;
			this.m_frmRealWindow.Show();
			this.m_frmRealWindow.Activate();
			this.m_frmRealWindow.m_mthShowWithSample(this.m_objKey);
			this.Close();
		}

		private void frmMessageNotify_Closed(object sender, System.EventArgs e)
		{
			if(this.Visible)
			{
				System.Threading.Interlocked.Decrement(ref s_intInstance);
				int intIndex = s_arlForms.IndexOf(this);
				s_arlForms.Remove(this);
				for(int i=intIndex;i<s_arlForms.Count;i++)
				{
					frmMessageNotify frmTemp = ((frmMessageNotify)s_arlForms[i]);
					frmTemp.Location = new Point(frmTemp.Location.X,frmTemp.Location.Y + this.Height);
				};
			}
		}

		private void frmMessageNotify_VisibleChanged(object sender, System.EventArgs e)
		{
			if(this.Visible)
			{
				System.Threading.Interlocked.Increment(ref s_intInstance);
				s_arlForms.Add(this);
				this.Location = new Point(System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width-this.Width,
					System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height - this.Height * s_intInstance);
				m_timClose.Enabled = true;
			}
			else
			{
				System.Threading.Interlocked.Decrement(ref s_intInstance);
				int intIndex = s_arlForms.IndexOf(this);
				s_arlForms.Remove(this);
				for(int i=intIndex;i<s_arlForms.Count;i++)
				{
					frmMessageNotify frmTemp = ((frmMessageNotify)s_arlForms[i]);
					frmTemp.Location = new Point(frmTemp.Location.X,frmTemp.Location.Y + this.Height);
				}
			}
		}

		private void m_timClose_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			this.Close();
		}

		private void m_btnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

	}
}
