using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace HRP
{
	/// <summary>
	/// Summary description for frmInformation.
	/// </summary>
	public class frmInformation : iCare.iCareBaseForm.frmBaseForm
	{
		internal System.Windows.Forms.TabPage tabIAttributes;
		internal System.Windows.Forms.TabPage tabMessage;
		internal System.Windows.Forms.TabPage tabIReceived;
		internal System.Windows.Forms.TabPage tabLog;
		internal System.Windows.Forms.Button btnHide;
		internal System.Windows.Forms.TabControl tabInformation;
		internal System.Windows.Forms.TextBox txtImagesReceived;
//		internal AxDicomObjects.AxDicomLog axDicomLog1;
		internal System.Windows.Forms.RichTextBox rchAttributes;
		internal System.Windows.Forms.RichTextBox rthLog;
		internal System.Windows.Forms.TextBox txtErrorMessages;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmInformation()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmInformation));
			this.tabInformation = new System.Windows.Forms.TabControl();
			this.tabIAttributes = new System.Windows.Forms.TabPage();
			this.rchAttributes = new System.Windows.Forms.RichTextBox();
			this.tabMessage = new System.Windows.Forms.TabPage();
			this.txtErrorMessages = new System.Windows.Forms.TextBox();
			this.tabIReceived = new System.Windows.Forms.TabPage();
			this.txtImagesReceived = new System.Windows.Forms.TextBox();
			this.tabLog = new System.Windows.Forms.TabPage();
			this.rthLog = new System.Windows.Forms.RichTextBox();
			this.btnHide = new System.Windows.Forms.Button();
			this.tabInformation.SuspendLayout();
			this.tabIAttributes.SuspendLayout();
			this.tabMessage.SuspendLayout();
			this.tabIReceived.SuspendLayout();
			this.tabLog.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabInformation
			// 
			this.tabInformation.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.tabInformation.Controls.AddRange(new System.Windows.Forms.Control[] {
																						 this.tabIAttributes,
																						 this.tabMessage,
																						 this.tabIReceived,
																						 this.tabLog});
			this.tabInformation.Name = "tabInformation";
			this.tabInformation.SelectedIndex = 0;
			this.tabInformation.Size = new System.Drawing.Size(568, 280);
			this.tabInformation.TabIndex = 0;
			// 
			// tabIAttributes
			// 
			this.tabIAttributes.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.tabIAttributes.Controls.AddRange(new System.Windows.Forms.Control[] {
																						 this.rchAttributes});
			this.tabIAttributes.Location = new System.Drawing.Point(4, 23);
			this.tabIAttributes.Name = "tabIAttributes";
			this.tabIAttributes.Size = new System.Drawing.Size(560, 253);
			this.tabIAttributes.TabIndex = 0;
			this.tabIAttributes.Text = "图象属性";
			// 
			// rchAttributes
			// 
			this.rchAttributes.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.rchAttributes.ForeColor = System.Drawing.Color.White;
			this.rchAttributes.Name = "rchAttributes";
			this.rchAttributes.ReadOnly = true;
			this.rchAttributes.Size = new System.Drawing.Size(560, 248);
			this.rchAttributes.TabIndex = 0;
			this.rchAttributes.Text = "";
			// 
			// tabMessage
			// 
			this.tabMessage.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.tabMessage.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.txtErrorMessages});
			this.tabMessage.Location = new System.Drawing.Point(4, 23);
			this.tabMessage.Name = "tabMessage";
			this.tabMessage.Size = new System.Drawing.Size(560, 253);
			this.tabMessage.TabIndex = 3;
			this.tabMessage.Text = "出错信息";
			// 
			// txtErrorMessages
			// 
			this.txtErrorMessages.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.txtErrorMessages.ForeColor = System.Drawing.Color.White;
			this.txtErrorMessages.Multiline = true;
			this.txtErrorMessages.Name = "txtErrorMessages";
			this.txtErrorMessages.ReadOnly = true;
			this.txtErrorMessages.Size = new System.Drawing.Size(560, 248);
			this.txtErrorMessages.TabIndex = 0;
			this.txtErrorMessages.Text = "";
			// 
			// tabIReceived
			// 
			this.tabIReceived.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.tabIReceived.Controls.AddRange(new System.Windows.Forms.Control[] {
																					   this.txtImagesReceived});
			this.tabIReceived.Location = new System.Drawing.Point(4, 23);
			this.tabIReceived.Name = "tabIReceived";
			this.tabIReceived.Size = new System.Drawing.Size(560, 253);
			this.tabIReceived.TabIndex = 4;
			this.tabIReceived.Text = "接收到的图象";
			// 
			// txtImagesReceived
			// 
			this.txtImagesReceived.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.txtImagesReceived.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.txtImagesReceived.ForeColor = System.Drawing.Color.White;
			this.txtImagesReceived.Multiline = true;
			this.txtImagesReceived.Name = "txtImagesReceived";
			this.txtImagesReceived.ReadOnly = true;
			this.txtImagesReceived.Size = new System.Drawing.Size(560, 248);
			this.txtImagesReceived.TabIndex = 0;
			this.txtImagesReceived.Text = "";
			// 
			// tabLog
			// 
			this.tabLog.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.tabLog.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.rthLog});
			this.tabLog.Location = new System.Drawing.Point(4, 23);
			this.tabLog.Name = "tabLog";
			this.tabLog.Size = new System.Drawing.Size(560, 253);
			this.tabLog.TabIndex = 6;
			this.tabLog.Text = "日志";
			// 
			// rthLog
			// 
			this.rthLog.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.rthLog.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.rthLog.ForeColor = System.Drawing.Color.White;
			this.rthLog.Name = "rthLog";
			this.rthLog.ReadOnly = true;
			this.rthLog.Size = new System.Drawing.Size(560, 248);
			this.rthLog.TabIndex = 1;
			this.rthLog.Text = "";
			// 
			// btnHide
			// 
			this.btnHide.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.btnHide.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnHide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnHide.Location = new System.Drawing.Point(464, 280);
			this.btnHide.Name = "btnHide";
			this.btnHide.Size = new System.Drawing.Size(96, 32);
			this.btnHide.TabIndex = 1;
			this.btnHide.Text = "确定";
			this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
			// 
			// frmInformation
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.ClientSize = new System.Drawing.Size(568, 317);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnHide,
																		  this.tabInformation});
			this.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.ForeColor = System.Drawing.Color.White;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmInformation";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "信息";
			this.Load += new System.EventHandler(this.frmInformation_Load);
			this.tabInformation.ResumeLayout(false);
			this.tabIAttributes.ResumeLayout(false);
			this.tabMessage.ResumeLayout(false);
			this.tabIReceived.ResumeLayout(false);
			this.tabLog.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnHide_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.Hide();
			}
			catch{}
		}

		private void frmInformation_Load(object sender, System.EventArgs e)
		{
		
		}

	}
}
