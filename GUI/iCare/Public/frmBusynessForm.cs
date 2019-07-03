using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace iCare
{
	/// <summary>
	/// 表示忙碌状态的窗体
	/// </summary>
	public class frmBusynessForm : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;
	
		private enum EnmClosingStatus
		{
			正常 = 0,
			成功,
			失败
		}
		private bool m_blnClosing;
		private EnmClosingStatus enmClosingStatus = EnmClosingStatus.正常;
		private string m_strEndMessage,m_strMessages;
		private BusynessEventArgs args;
		private bool m_blnIsExecute = false;

		private System.Windows.Forms.Label m_lblMessage;
		private PinkieControls.ButtonXP m_cmdYes;
		private System.Windows.Forms.PictureBox picClock;
		private System.Windows.Forms.Timer timer1;
	
		/// <summary>
		/// 在表示忙碌状态时要处理的事件
		/// </summary>
		public delegate void BusynessHandler (object Sender,BusynessEventArgs e);

		[Description("在表示忙碌状态时要处理的事件")  ]
		public event BusynessHandler BusynessEvent;

		public frmBusynessForm(string p_strMessage)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			enmClosingStatus = EnmClosingStatus.正常;
			m_lblMessage.Text = p_strMessage;
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmBusynessForm));
			this.m_lblMessage = new System.Windows.Forms.Label();
			this.m_cmdYes = new PinkieControls.ButtonXP();
			this.picClock = new System.Windows.Forms.PictureBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// m_lblMessage
			// 
			this.m_lblMessage.Font = new System.Drawing.Font("宋体", 10.5F);
			this.m_lblMessage.Location = new System.Drawing.Point(92, 16);
			this.m_lblMessage.Name = "m_lblMessage";
			this.m_lblMessage.Size = new System.Drawing.Size(204, 68);
			this.m_lblMessage.TabIndex = 0;
			this.m_lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_cmdYes
			// 
			this.m_cmdYes.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(255)), ((System.Byte)(240)), ((System.Byte)(202)));
			this.m_cmdYes.DefaultScheme = true;
			this.m_cmdYes.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_cmdYes.Hint = "";
			this.m_cmdYes.Location = new System.Drawing.Point(300, 56);
			this.m_cmdYes.Name = "m_cmdYes";
			this.m_cmdYes.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdYes.Size = new System.Drawing.Size(56, 28);
			this.m_cmdYes.TabIndex = 1;
			this.m_cmdYes.Text = "确 定";
			this.m_cmdYes.Visible = false;
			this.m_cmdYes.Click += new System.EventHandler(this.m_cmdYes_Click);
			// 
			// picClock
			// 
			this.picClock.Image = ((System.Drawing.Image)(resources.GetObject("picClock.Image")));
			this.picClock.Location = new System.Drawing.Point(12, 14);
			this.picClock.Name = "picClock";
			this.picClock.Size = new System.Drawing.Size(68, 68);
			this.picClock.TabIndex = 2;
			this.picClock.TabStop = false;
			// 
			// timer1
			// 
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// frmBusynessForm
			// 
			this.AcceptButton = this.m_cmdYes;
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.BackColor = System.Drawing.SystemColors.Desktop;
			this.CancelButton = this.m_cmdYes;
			this.ClientSize = new System.Drawing.Size(360, 96);
			this.Controls.Add(this.picClock);
			this.Controls.Add(this.m_cmdYes);
			this.Controls.Add(this.m_lblMessage);
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmBusynessForm";
			this.Opacity = 0.8;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.TopMost = true;
			this.Activated += new System.EventHandler(this.frmBusynessForm_Activated);
			this.ResumeLayout(false);

		}
		#endregion


		private void timer1_Tick(object sender, System.EventArgs e)
		{
			if(enmClosingStatus == EnmClosingStatus.成功)
			{
				timer1.Stop();
				this.Close();
			}
			else if(enmClosingStatus == EnmClosingStatus.失败)
			{
				timer1.Stop();
				this.Opacity = 1;
				m_lblMessage.Text = m_strEndMessage;
				this.Cursor = Cursors.Default;
				m_cmdYes.Visible = true;
			}
			else
			{
				if(args.Messages != null && args.Messages != string.Empty)
					m_lblMessage.Text += "\n"+args.Messages;
			}
			this.Validate();
		}

		private void m_cmdYes_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void frmBusynessForm_Activated(object sender, System.EventArgs e)
		{
			if(BusynessEvent != null && m_blnIsExecute == false)
			{
				timer1.Start();
				args = new BusynessEventArgs(ref m_strMessages,ref m_strEndMessage,ref m_blnClosing);
				BusynessEvent(this,args);
				m_strEndMessage = args.EndMessage;
				enmClosingStatus = (args.Closing?EnmClosingStatus.成功:EnmClosingStatus.失败);
				m_blnIsExecute = true;
			}
		}
	}

	#region 时间参数类
	public class BusynessEventArgs:System.EventArgs
	{
		private string m_strMessages,m_strEndMessage;

		private bool m_blnClosing;

		public  BusynessEventArgs(ref string Messages ,ref string EndMessage, ref bool Closeing):base()
		{
			m_strMessages=Messages;
			m_strEndMessage=EndMessage;
			m_blnClosing = Closeing;
		}
		public string Messages
		{
			get    {  return m_strMessages;    }
			set    {  m_strMessages = value;    }
		}
		public string EndMessage
		{
			get    {  return m_strEndMessage;    }
			set    {  m_strEndMessage = value;    }
		}
		public bool Closing
		{
			get  
			{
				return m_blnClosing;
			}
			set  
			{
				m_blnClosing = value;
			}
		}

	}
	#endregion
}
