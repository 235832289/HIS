using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.Utility;
using com.digitalwave.Utility.Controls;

namespace iCare
{
	/// <summary>
	/// Summary description for frmLogin.
	/// </summary>
	public class frmUpdateLogin : iCare.iCareBaseForm.frmBaseForm
	{
		private PinkieControls.ButtonXP m_cmdOK;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtLoginName;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtPSW;
		protected System.Windows.Forms.Label lblLoginName;
		protected System.Windows.Forms.Label lblPSW;
		private PinkieControls.ButtonXP cmdCancel;
		protected System.Windows.Forms.Label m_lblEmployeeInfo;
		protected System.Windows.Forms.Label lblPSWConfirm;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtPSWConfirm;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmUpdateLogin()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			m_lblEmployeeInfo.Text = "姓名："+clsSystemContext.s_ObjCurrentContext.m_ObjEmployee.m_StrFirstName;
			m_txtLoginName.Text = clsLoginContext.s_ObjLoginContext.m_StrLoginName;
			m_objHighLight = new ctlHighLightFocus(clsHRPColor.s_ClrHightLight);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmUpdateLogin));
			this.m_cmdOK = new PinkieControls.ButtonXP();
			this.m_txtLoginName = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_txtPSW = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.lblLoginName = new System.Windows.Forms.Label();
			this.lblPSW = new System.Windows.Forms.Label();
			this.cmdCancel = new PinkieControls.ButtonXP();
			this.m_lblEmployeeInfo = new System.Windows.Forms.Label();
			this.lblPSWConfirm = new System.Windows.Forms.Label();
			this.m_txtPSWConfirm = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.SuspendLayout();
			// 
			// m_cmdOK
			// 
			this.m_cmdOK.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdOK.DefaultScheme = true;
			this.m_cmdOK.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdOK.ForeColor = System.Drawing.Color.Black;
			this.m_cmdOK.Hint = "";
			this.m_cmdOK.Location = new System.Drawing.Point(244, 44);
			this.m_cmdOK.Name = "m_cmdOK";
			this.m_cmdOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdOK.Size = new System.Drawing.Size(64, 32);
			this.m_cmdOK.TabIndex = 4;
			this.m_cmdOK.Text = "确定";
			this.m_cmdOK.Click += new System.EventHandler(this.m_cmdOK_Click);
			// 
			// m_txtLoginName
			// 
			this.m_txtLoginName.BackColor = System.Drawing.Color.White;
			this.m_txtLoginName.BorderColor = System.Drawing.Color.White;
			this.m_txtLoginName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtLoginName.ForeColor = System.Drawing.Color.Black;
			this.m_txtLoginName.Location = new System.Drawing.Point(120, 44);
			this.m_txtLoginName.MaxLength = 25;
			this.m_txtLoginName.Name = "m_txtLoginName";
			this.m_txtLoginName.Size = new System.Drawing.Size(112, 23);
			this.m_txtLoginName.TabIndex = 1;
			this.m_txtLoginName.Text = "";
			// 
			// m_txtPSW
			// 
			this.m_txtPSW.BackColor = System.Drawing.Color.White;
			this.m_txtPSW.BorderColor = System.Drawing.Color.White;
			this.m_txtPSW.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtPSW.ForeColor = System.Drawing.Color.Black;
			this.m_txtPSW.Location = new System.Drawing.Point(120, 77);
			this.m_txtPSW.Name = "m_txtPSW";
			this.m_txtPSW.PasswordChar = '*';
			this.m_txtPSW.Size = new System.Drawing.Size(112, 23);
			this.m_txtPSW.TabIndex = 2;
			this.m_txtPSW.Text = "";
			// 
			// lblLoginName
			// 
			this.lblLoginName.AutoSize = true;
			this.lblLoginName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblLoginName.ForeColor = System.Drawing.Color.Black;
			this.lblLoginName.Location = new System.Drawing.Point(36, 48);
			this.lblLoginName.Name = "lblLoginName";
			this.lblLoginName.Size = new System.Drawing.Size(77, 19);
			this.lblLoginName.TabIndex = 499;
			this.lblLoginName.Text = "用户账号：";
			this.lblLoginName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblPSW
			// 
			this.lblPSW.AutoSize = true;
			this.lblPSW.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblPSW.ForeColor = System.Drawing.Color.Black;
			this.lblPSW.Location = new System.Drawing.Point(20, 80);
			this.lblPSW.Name = "lblPSW";
			this.lblPSW.Size = new System.Drawing.Size(92, 19);
			this.lblPSW.TabIndex = 498;
			this.lblPSW.Text = "用户新密码：";
			this.lblPSW.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmdCancel
			// 
			this.cmdCancel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.cmdCancel.DefaultScheme = true;
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.ForeColor = System.Drawing.Color.Black;
			this.cmdCancel.Hint = "";
			this.cmdCancel.Location = new System.Drawing.Point(244, 84);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.cmdCancel.Size = new System.Drawing.Size(64, 32);
			this.cmdCancel.TabIndex = 5;
			this.cmdCancel.Text = "取消";
			// 
			// m_lblEmployeeInfo
			// 
			this.m_lblEmployeeInfo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lblEmployeeInfo.ForeColor = System.Drawing.Color.Black;
			this.m_lblEmployeeInfo.Location = new System.Drawing.Point(16, 12);
			this.m_lblEmployeeInfo.Name = "m_lblEmployeeInfo";
			this.m_lblEmployeeInfo.Size = new System.Drawing.Size(288, 24);
			this.m_lblEmployeeInfo.TabIndex = 499;
			// 
			// lblPSWConfirm
			// 
			this.lblPSWConfirm.AutoSize = true;
			this.lblPSWConfirm.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblPSWConfirm.ForeColor = System.Drawing.Color.Black;
			this.lblPSWConfirm.Location = new System.Drawing.Point(20, 116);
			this.lblPSWConfirm.Name = "lblPSWConfirm";
			this.lblPSWConfirm.Size = new System.Drawing.Size(92, 19);
			this.lblPSWConfirm.TabIndex = 498;
			this.lblPSWConfirm.Text = "新密码确认：";
			this.lblPSWConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_txtPSWConfirm
			// 
			this.m_txtPSWConfirm.BackColor = System.Drawing.Color.White;
			this.m_txtPSWConfirm.BorderColor = System.Drawing.Color.White;
			this.m_txtPSWConfirm.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtPSWConfirm.ForeColor = System.Drawing.Color.Black;
			this.m_txtPSWConfirm.Location = new System.Drawing.Point(120, 112);
			this.m_txtPSWConfirm.Name = "m_txtPSWConfirm";
			this.m_txtPSWConfirm.PasswordChar = '*';
			this.m_txtPSWConfirm.Size = new System.Drawing.Size(112, 23);
			this.m_txtPSWConfirm.TabIndex = 3;
			this.m_txtPSWConfirm.Text = "";
			// 
			// frmUpdateLogin
			// 
			this.AcceptButton = this.m_cmdOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(324, 149);
			this.Controls.Add(this.m_txtPSWConfirm);
			this.Controls.Add(this.m_txtLoginName);
			this.Controls.Add(this.m_txtPSW);
			this.Controls.Add(this.lblLoginName);
			this.Controls.Add(this.lblPSW);
			this.Controls.Add(this.lblPSWConfirm);
			this.Controls.Add(this.m_cmdOK);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.m_lblEmployeeInfo);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.ForeColor = System.Drawing.Color.White;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmUpdateLogin";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "修改登录信息";
			this.Load += new System.EventHandler(this.frmUpdateLogin_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void m_cmdOK_Click(object sender, System.EventArgs e)
		{
			if(m_txtLoginName.Text == "")
			{
				clsPublicFunction.ShowInformationMessageBox("用户账号不能为空。");
				m_txtLoginName.Focus();
				return;
			}

			if(m_txtPSW.Text != m_txtPSWConfirm.Text)
			{
				clsPublicFunction.ShowInformationMessageBox("新密码的确认与新密码不一致。");
				m_txtPSW.Focus();
				return;
			}


			this.Cursor = Cursors.WaitCursor;
			
			long lngRes = clsLoginContext.s_ObjLoginContext.m_lngUpdateLoginInfo(m_txtLoginName.Text,m_txtPSW.Text);

			if(lngRes > 0)
			{
				this.Close();
			}
			else
			{
				if((iCareData.enmOperationResult)lngRes == iCareData.enmOperationResult.Record_Already_Exist)
				{
					clsPublicFunction.ShowInformationMessageBox("用户名已经被使用。");
					m_txtLoginName.SelectAll();
					m_txtLoginName.Focus();
				}
				else
				{
					clsPublicFunction.ShowInformationMessageBox("不能修改登录信息。");
				}
			}

			this.Cursor = Cursors.Default;
		}

		private void frmUpdateLogin_Load(object sender, System.EventArgs e)
		{
			m_objHighLight.m_mthAddControlInContainer(this);
		}		
	}
}
