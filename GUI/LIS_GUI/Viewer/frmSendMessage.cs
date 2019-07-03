using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.LIS
{
	/// <summary>
	/// frmSendMessage 的摘要说明。
	/// </summary>
	public class frmSendMessage : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox m_txtMobile;
		private System.Windows.Forms.TextBox m_txtSendDesc;
		private System.Windows.Forms.Button m_cmdTest;
		private System.Windows.Forms.ComboBox m_cboPost;
		private System.Windows.Forms.ComboBox m_cboBTL;
		private AxSMS_control.AxSMScontrol smsc;
		private System.Windows.Forms.Button m_cmdSend;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmSendMessage(string p_strSendMessage)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			m_strSendMessage=p_strSendMessage;
			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		#region 定义的变量
		private string strCOMPort="COM1";
		private int intCOMPortIndex=1;
		private int iRate=19200;
		private int iType=0;
		private string m_strSendMessage;
//		private string strShortMessage="";
//		private string strPhoneNumber="";
		#endregion 定义的变量

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
			smsc.Commclose();
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmSendMessage));
			this.smsc = new AxSMS_control.AxSMScontrol();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.m_txtSendDesc = new System.Windows.Forms.TextBox();
			this.m_txtMobile = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.m_cmdSend = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.m_cboBTL = new System.Windows.Forms.ComboBox();
			this.m_cboPost = new System.Windows.Forms.ComboBox();
			this.m_cmdTest = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.smsc)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// smsc
			// 
			this.smsc.ContainingControl = this;
			this.smsc.Enabled = true;
			this.smsc.Location = new System.Drawing.Point(408, 16);
			this.smsc.Name = "smsc";
			this.smsc.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("smsc.OcxState")));
			this.smsc.Size = new System.Drawing.Size(33, 33);
			this.smsc.TabIndex = 0;
			this.smsc.Visible = false;
			this.smsc.Msgreceived += new AxSMS_control.__SMScontrol_MsgreceivedEventHandler(this.smsc_Msgreceived);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.m_txtSendDesc);
			this.groupBox1.Controls.Add(this.m_txtMobile);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.smsc);
			this.groupBox1.Controls.Add(this.m_cmdSend);
			this.groupBox1.Location = new System.Drawing.Point(8, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(524, 236);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "发 送";
			// 
			// m_txtSendDesc
			// 
			this.m_txtSendDesc.Location = new System.Drawing.Point(80, 56);
			this.m_txtSendDesc.Multiline = true;
			this.m_txtSendDesc.Name = "m_txtSendDesc";
			this.m_txtSendDesc.Size = new System.Drawing.Size(436, 136);
			this.m_txtSendDesc.TabIndex = 200;
			this.m_txtSendDesc.Text = "";
			// 
			// m_txtMobile
			// 
			this.m_txtMobile.Location = new System.Drawing.Point(80, 28);
			this.m_txtMobile.Name = "m_txtMobile";
			this.m_txtMobile.Size = new System.Drawing.Size(156, 23);
			this.m_txtMobile.TabIndex = 100;
			this.m_txtMobile.Tag = "";
			this.m_txtMobile.Text = "13318751711";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(63, 19);
			this.label1.TabIndex = 0;
			this.label1.Text = "手机号码";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 60);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 36);
			this.label2.TabIndex = 0;
			this.label2.Text = "发送的短信内容";
			// 
			// m_cmdSend
			// 
			this.m_cmdSend.Location = new System.Drawing.Point(384, 200);
			this.m_cmdSend.Name = "m_cmdSend";
			this.m_cmdSend.Size = new System.Drawing.Size(104, 28);
			this.m_cmdSend.TabIndex = 400;
			this.m_cmdSend.Text = "发送信息(&S)";
			this.m_cmdSend.Click += new System.EventHandler(this.m_cmdSend_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.m_cboBTL);
			this.groupBox2.Controls.Add(this.m_cboPost);
			this.groupBox2.Controls.Add(this.m_cmdTest);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Location = new System.Drawing.Point(8, 252);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(524, 88);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "设备配置信息";
			// 
			// m_cboBTL
			// 
			this.m_cboBTL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboBTL.Items.AddRange(new object[] {
														  "9600",
														  "19200",
														  "38400",
														  "57600",
														  "115200"});
			this.m_cboBTL.Location = new System.Drawing.Point(344, 28);
			this.m_cboBTL.Name = "m_cboBTL";
			this.m_cboBTL.Size = new System.Drawing.Size(144, 22);
			this.m_cboBTL.TabIndex = 600;
			this.m_cboBTL.SelectedIndexChanged += new System.EventHandler(this.m_cboBTL_SelectedIndexChanged);
			// 
			// m_cboPost
			// 
			this.m_cboPost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboPost.Items.AddRange(new object[] {
														   "COM1",
														   "COM2",
														   "COM3",
														   "COM4",
														   "COM5",
														   "COM6",
														   "COM7",
														   "COM8",
														   "COM9"});
			this.m_cboPost.Location = new System.Drawing.Point(84, 28);
			this.m_cboPost.Name = "m_cboPost";
			this.m_cboPost.Size = new System.Drawing.Size(140, 22);
			this.m_cboPost.TabIndex = 500;
			this.m_cboPost.SelectedIndexChanged += new System.EventHandler(this.m_cboPost_SelectedIndexChanged);
			// 
			// m_cmdTest
			// 
			this.m_cmdTest.Location = new System.Drawing.Point(384, 56);
			this.m_cmdTest.Name = "m_cmdTest";
			this.m_cmdTest.Size = new System.Drawing.Size(104, 28);
			this.m_cmdTest.TabIndex = 700;
			this.m_cmdTest.Text = "测试设备(&T)";
			this.m_cmdTest.Click += new System.EventHandler(this.m_cmdTest_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(36, 28);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 19);
			this.label4.TabIndex = 0;
			this.label4.Text = "端口：";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(280, 28);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(63, 19);
			this.label5.TabIndex = 0;
			this.label5.Text = "波特率：";
			// 
			// frmSendMessage
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(536, 341);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmSendMessage";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "发送短消息";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmSendMessage_Closing);
			this.Load += new System.EventHandler(this.frmSendMessage_Load);
			((System.ComponentModel.ISupportInitialize)(this.smsc)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmSendMessage_Load(object sender, System.EventArgs e)
		{
			m_cboPost.SelectedIndex=0;
			m_cboBTL.SelectedIndex=1;
			smsc.Autoreceive=true;
			m_txtSendDesc.Text=m_strSendMessage;
		}

		private void m_cboPost_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			strCOMPort=m_cboPost.Text;
			intCOMPortIndex=m_cboPost.SelectedIndex+1;
//			intCOMPortIndex=int.Parse(textBox1.Text);
		}

		private void m_cboBTL_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			iRate=int.Parse(m_cboBTL.Text);
		}

		/// <summary>
		/// 测试连接
		/// </summary>
		/// <returns>成功:0,失败:1</returns>
		public long Test()
		{
			//smsc.Commport=Convert.ToInt16(intCOMPortIndex);
			smsc.Commport=1;
			smsc.Setting=iRate.ToString().Trim()+"N,8,1";
			if(smsc.Commopen()==1)
			{
				return 0;
			}
			else
			{
				return -1;
			}
			smsc.Commclose();
		}

		private void m_cmdTest_Click(object sender, System.EventArgs e)
		{
			if (Test()==0)
				MessageBox.Show("设备连接成功!");
			else
				MessageBox.Show("设备连接失败!");
		}

		/// <summary>
		/// 发送短信
		/// </summary>
		/// <returns>0:发送失败或超时,1:发送成功,2:串口忙</returns>
		public long SendMessage()
		{
			long ret;
			smsc.Sendmode="1";
			ret=smsc.Sendmsg(m_txtMobile.Text,m_txtSendDesc.Text,"1");
			if (ret!=1)
				MessageBox.Show("发送失败!");
			else
				MessageBox.Show("发送成功!");
			return ret;

		}

		private void m_cmdSend_Click(object sender, System.EventArgs e)
		{
			smsc.Commport=1;
			smsc.Setting=iRate.ToString().Trim()+"N,8,1";
//			if(smsc.Commopen()==1)
//			{
//				clsPublicFunction.ShowInformationMessageBox("设备连接成功!");
//			}
//			else
//			{
//				clsPublicFunction.ShowInformationMessageBox("设备连接失败!");
//			}
			smsc.Commopen();
			SendMessage();
		}

		private void smsc_Msgreceived(object sender, AxSMS_control.__SMScontrol_MsgreceivedEvent e)
		{
			//clsPublicFunction.ShowInformationMessageBox(smsc.LastReadMsg);
			//clsPublicFunction.ShowInformationMessageBox(e.msg);
			string strMessage;
			strMessage=smsc.LastReadMsg;
			MessageBox.Show(smsc.LastReadMsg);
		}

		private void frmSendMessage_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
//			e.Cancel=true;

		}

	}
}
