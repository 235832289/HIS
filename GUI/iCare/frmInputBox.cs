using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace iCare
{
	/// <summary>
	/// Summary description for frmInputBox.
	/// </summary>
	public class frmInputBox : iCare.iCareBaseForm.frmBaseForm
	{
		private com.digitalwave.Utility.Controls.ctlBorderTextBox txtName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmInputBox()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		private frmLabCheckItemAdmin m_objParent;

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
			this.txtName = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cmdOK = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtName
			// 
			this.txtName.AccessibleDescription = "红细胞积压比";
			this.txtName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.txtName.BorderColor = System.Drawing.Color.White;
			this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtName.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtName.ForeColor = System.Drawing.Color.White;
			this.txtName.Location = new System.Drawing.Point(96, 40);
			this.txtName.MaxLength = 8;
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(276, 26);
			this.txtName.TabIndex = 101;
			this.txtName.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(36, 44);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(52, 23);
			this.label1.TabIndex = 102;
			this.label1.Text = "名称:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cmdOK
			// 
			this.cmdOK.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmdOK.Location = new System.Drawing.Point(136, 88);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.Size = new System.Drawing.Size(76, 28);
			this.cmdOK.TabIndex = 201;
			this.cmdOK.Text = "确  定";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// cmdCancel
			// 
			this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmdCancel.Location = new System.Drawing.Point(244, 88);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(76, 28);
			this.cmdCancel.TabIndex = 202;
			this.cmdCancel.Text = "取  消";
			// 
			// frmInputBox
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(464, 133);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.cmdCancel,
																		  this.cmdOK,
																		  this.label1,
																		  this.txtName});
			this.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.ForeColor = System.Drawing.Color.White;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmInputBox";
			this.Text = "输入";
			this.ResumeLayout(false);

		}
		#endregion

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			if(this.txtName.Text.Trim() == "")
			{
				clsPublicFunction.ShowInformationMessageBox("请输入名称！");
				return;
			}

			m_objParent.m_StrGroupName = this.txtName.Text.Trim();

			this.DialogResult = DialogResult.OK;

			this.Close();
		}

		public frmLabCheckItemAdmin m_ObjParent
		{
			get
			{
				return m_objParent;
			}
			set 
			{
				m_objParent = value;
			}
		}

	}
}
