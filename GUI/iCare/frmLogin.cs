using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.Utility.Controls;
using iCareData;

namespace iCare
{
	/// <summary>
	/// Summary description for frmLogin.
	/// </summary>
	public class frmLogin : iCare.iCareBaseForm.frmBaseForm
	{
		private System.Windows.Forms.Button m_cmdOK;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtLoginName;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtPSW;
		protected System.Windows.Forms.Label lblLoginName;
		protected System.Windows.Forms.Label lblPSW;
		private System.Windows.Forms.Button cmdCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmLogin()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
//			clsHRPColor.s_ClrInputBack = Color.White;
//			clsHRPColor.s_ClrInputFore = Color.Black;
//			clsHRPColor.s_ClrTitleLabel = Color.Yellow;

			m_objHighLight = new ctlHighLightFocus(clsHRPColor.s_ClrHightLight);

			m_objHighLight.m_mthAddControlInContainer(this);
		}

		private ctlHighLightFocus m_objHighLight;

		private long m_lngRes = 0;

		public long m_LngRes
		{
			get
			{
				return m_lngRes;
			}
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmLogin));
			this.m_cmdOK = new System.Windows.Forms.Button();
			this.m_txtLoginName = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtPSW = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.lblLoginName = new System.Windows.Forms.Label();
			this.lblPSW = new System.Windows.Forms.Label();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// m_cmdOK
			// 
			this.m_cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_cmdOK.Location = new System.Drawing.Point(228, 12);
			this.m_cmdOK.Name = "m_cmdOK";
			this.m_cmdOK.Size = new System.Drawing.Size(75, 28);
			this.m_cmdOK.TabIndex = 3;
			this.m_cmdOK.Text = "确定";
			this.m_cmdOK.Click += new System.EventHandler(this.m_cmdOK_Click);
			// 
			// m_txtLoginName
			// 
			this.m_txtLoginName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtLoginName.BorderColor = System.Drawing.Color.White;
			this.m_txtLoginName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtLoginName.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtLoginName.ForeColor = System.Drawing.Color.White;
			this.m_txtLoginName.Location = new System.Drawing.Point(96, 12);
			this.m_txtLoginName.MaxLength = 25;
			this.m_txtLoginName.Name = "m_txtLoginName";
			this.m_txtLoginName.Size = new System.Drawing.Size(112, 26);
			this.m_txtLoginName.TabIndex = 1;
			this.m_txtLoginName.Text = "";
			this.m_txtLoginName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthSendTab);
			// 
			// m_txtPSW
			// 
			this.m_txtPSW.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtPSW.BorderColor = System.Drawing.Color.White;
			this.m_txtPSW.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtPSW.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtPSW.ForeColor = System.Drawing.Color.White;
			this.m_txtPSW.Location = new System.Drawing.Point(96, 44);
			this.m_txtPSW.Name = "m_txtPSW";
			this.m_txtPSW.PasswordChar = '*';
			this.m_txtPSW.Size = new System.Drawing.Size(112, 26);
			this.m_txtPSW.TabIndex = 2;
			this.m_txtPSW.Text = "";
			this.m_txtPSW.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthSendTab);
			// 
			// lblLoginName
			// 
			this.lblLoginName.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblLoginName.Location = new System.Drawing.Point(16, 16);
			this.lblLoginName.Name = "lblLoginName";
			this.lblLoginName.Size = new System.Drawing.Size(88, 20);
			this.lblLoginName.TabIndex = 499;
			this.lblLoginName.Text = "用户账号：";
			// 
			// lblPSW
			// 
			this.lblPSW.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblPSW.Location = new System.Drawing.Point(16, 48);
			this.lblPSW.Name = "lblPSW";
			this.lblPSW.Size = new System.Drawing.Size(88, 19);
			this.lblPSW.TabIndex = 498;
			this.lblPSW.Text = "用户密码：";
			// 
			// cmdCancel
			// 
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmdCancel.Location = new System.Drawing.Point(228, 44);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(75, 28);
			this.cmdCancel.TabIndex = 4;
			this.cmdCancel.Text = "取消";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// frmLogin
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(324, 97);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.m_txtLoginName,
																		  this.m_txtPSW,
																		  this.lblLoginName,
																		  this.lblPSW,
																		  this.m_cmdOK,
																		  this.cmdCancel});
			this.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.ForeColor = System.Drawing.Color.White;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmLogin";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "用户登录";
			this.ResumeLayout(false);

		}
		#endregion

		private void m_cmdOK_Click(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			clsLoginContext objLogin = clsLoginContext.s_ObjLoginContext;

			m_lngRes = objLogin.m_lngLogin(m_txtLoginName.Text,m_txtPSW.Text);

			if(m_lngRes > 0)
			{
				//初始化信息失败
				if(clsLoginContext.s_ObjLoginContext.m_ObjPrincial == null
					|| clsLoginContext.s_ObjLoginContext.m_ObjRoleArr == null
					|| clsLoginContext.s_ObjLoginContext.m_StrEmployeeID == null)
				{
					clsPublicFunction.ShowInformationMessageBox("初始化信息失败，请重新启动系统。");
					clsLoginContext.s_ObjLoginContext.m_mthClear();
					m_lngRes = -100;

					clsLoginContext.s_ObjLoginContext.m_mthClear();

					this.Close();
					return;
				}

				//非住院医生登录
				if(clsSystemContext.s_ObjCurrentContext.m_ObjDepartment == null)
				{
					clsPublicFunction.ShowInformationMessageBox("没有权限使用本系统，请退出。");
					clsLoginContext.s_ObjLoginContext.m_lngLogout();
					clsLoginContext.s_ObjLoginContext.m_lngLogout();
					
					m_lngRes = -110;

					clsLoginContext.s_ObjLoginContext.m_mthClear();

					this.Close();
					return;
				}

				//登录成功
				this.Close();
			}
			else
			{
				switch((enmOperationResult)m_lngRes)
				{
					case enmOperationResult.DB_Fail:
						clsPublicFunction.ShowInformationMessageBox("不能连接服务器。");
						break;
					case enmOperationResult.Not_permission:
						clsPublicFunction.ShowInformationMessageBox("用户信息不正确。");
						break;
				}

				m_txtPSW.Text = "";
				m_txtLoginName.Focus();
			}
			this.Cursor = Cursors.Default;
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			clsLoginContext.s_ObjLoginContext.m_mthClear();

			this.Close();
		}

		private void m_mthSendTab(object sender,KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
				SendKeys.Send("{tab}");
		}


	}
}
