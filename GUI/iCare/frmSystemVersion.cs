using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace iCare
{
	/// <summary>
	/// Summary description for frmSystemVersion.
	/// </summary>
	public class frmSystemVersion : iCare.iCareBaseForm.frmBaseForm
	{
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Label lblTitle0;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmSystemVersion()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmSystemVersion));
			this.lblTitle = new System.Windows.Forms.Label();
			this.lblTitle0 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblTitle.Location = new System.Drawing.Point(72, 36);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(242, 22);
			this.lblTitle.TabIndex = 2;
			this.lblTitle.Text = "iCare-医疗信息平台 1.0版";
			// 
			// lblTitle0
			// 
			this.lblTitle0.AutoSize = true;
			this.lblTitle0.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblTitle0.Location = new System.Drawing.Point(72, 80);
			this.lblTitle0.Name = "lblTitle0";
			this.lblTitle0.Size = new System.Drawing.Size(252, 22);
			this.lblTitle0.TabIndex = 1;
			this.lblTitle0.Text = "CopyRight Reserved 2003.8";
			// 
			// frmSystemVersion
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(10, 22);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.ClientSize = new System.Drawing.Size(412, 137);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.lblTitle,
																		  this.lblTitle0});
			this.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.ForeColor = System.Drawing.SystemColors.Window;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmSystemVersion";
			this.Text = "版本";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
