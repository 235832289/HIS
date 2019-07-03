using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace iCare
{
	/// <summary>
	/// Summary description for frmEmail.
	/// </summary>
	public class frmEmail : iCare.iCareBaseForm.frmBaseForm
	{
		private System.Windows.Forms.Label lblTel;
		private System.Windows.Forms.Label lblEmailTitle;
		private System.Windows.Forms.LinkLabel m_lblEmail;
		private System.Windows.Forms.LinkLabel m_lblNetAddr;
		private System.Windows.Forms.Label lblNetAddrTitle;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmEmail()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmEmail));
			this.lblTel = new System.Windows.Forms.Label();
			this.lblEmailTitle = new System.Windows.Forms.Label();
			this.m_lblEmail = new System.Windows.Forms.LinkLabel();
			this.m_lblNetAddr = new System.Windows.Forms.LinkLabel();
			this.lblNetAddrTitle = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblTel
			// 
			this.lblTel.AutoSize = true;
			this.lblTel.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblTel.Location = new System.Drawing.Point(80, 32);
			this.lblTel.Name = "lblTel";
			this.lblTel.Size = new System.Drawing.Size(320, 22);
			this.lblTel.TabIndex = 0;
			this.lblTel.Text = "联系电话: 020-81615433、81615423";
			// 
			// lblEmailTitle
			// 
			this.lblEmailTitle.AutoSize = true;
			this.lblEmailTitle.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblEmailTitle.Location = new System.Drawing.Point(80, 72);
			this.lblEmailTitle.Name = "lblEmailTitle";
			this.lblEmailTitle.Size = new System.Drawing.Size(66, 22);
			this.lblEmailTitle.TabIndex = 0;
			this.lblEmailTitle.Text = "EMail:";
			// 
			// m_lblEmail
			// 
			this.m_lblEmail.AutoSize = true;
			this.m_lblEmail.DisabledLinkColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.m_lblEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_lblEmail.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lblEmail.Location = new System.Drawing.Point(152, 72);
			this.m_lblEmail.Name = "m_lblEmail";
			this.m_lblEmail.Size = new System.Drawing.Size(222, 22);
			this.m_lblEmail.TabIndex = 1;
			this.m_lblEmail.TabStop = true;
			this.m_lblEmail.Text = "liyi@e-digitalwave.com";
			this.m_lblEmail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lblEmail_LinkClicked);
			// 
			// m_lblNetAddr
			// 
			this.m_lblNetAddr.AutoSize = true;
			this.m_lblNetAddr.DisabledLinkColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.m_lblNetAddr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_lblNetAddr.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lblNetAddr.Location = new System.Drawing.Point(140, 116);
			this.m_lblNetAddr.Name = "m_lblNetAddr";
			this.m_lblNetAddr.Size = new System.Drawing.Size(213, 22);
			this.m_lblNetAddr.TabIndex = 1;
			this.m_lblNetAddr.TabStop = true;
			this.m_lblNetAddr.Text = "www.e-digitalwave.com";
			this.m_lblNetAddr.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lblNetAddr_LinkClicked);
			// 
			// lblNetAddrTitle
			// 
			this.lblNetAddrTitle.AutoSize = true;
			this.lblNetAddrTitle.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblNetAddrTitle.Location = new System.Drawing.Point(80, 116);
			this.lblNetAddrTitle.Name = "lblNetAddrTitle";
			this.lblNetAddrTitle.Size = new System.Drawing.Size(56, 22);
			this.lblNetAddrTitle.TabIndex = 0;
			this.lblNetAddrTitle.Text = "网址:";
			// 
			// frmEmail
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.ClientSize = new System.Drawing.Size(480, 165);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.m_lblEmail,
																		  this.lblTel,
																		  this.lblEmailTitle,
																		  this.m_lblNetAddr,
																		  this.lblNetAddrTitle});
			this.ForeColor = System.Drawing.SystemColors.Window;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmEmail";
			this.Text = "联系我们";
			this.ResumeLayout(false);

		}
		#endregion

		private void m_lblEmail_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			//m_lblEmail.Links.Add(0,m_lblEmail.Text.Length);				
		}

		private void m_lblNetAddr_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				VisitLink();
			}
			catch
			{
				MessageBox.Show("Unable to open link that was clicked.");
			}	
		}

		private void VisitLink()
		{
			// Change the color of the link text by setting LinkVisited to true.
			m_lblEmail.LinkVisited = true;
			//Call the Process.Start method to open the default browser with a URL:
			System.Diagnostics.Process.Start("www.e-digitalwave.com");
		}
		
	}
}
