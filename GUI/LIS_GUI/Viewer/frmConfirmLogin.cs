using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.GUI_Base;

namespace com.digitalwave.iCare.gui.LIS
{
	/// <summary>
	/// 审核者登录界面
	/// </summary>
	public class frmConfirmLogin : frmMDI_Child_Base
	{

        #region 控件申明

        private System.Windows.Forms.Panel panel1;
        private PinkieControls.ButtonXP btnCancel;
        private PinkieControls.ButtonXP btnLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLoginPwd;
        private System.Windows.Forms.TextBox txtLoginName;

        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

        #endregion

        #region 私有成员

        private string strEmpID = "";
        private string strDefaultEmpNo = "";
        private string strEmpName = "";

        #endregion

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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new PinkieControls.ButtonXP();
            this.btnLogin = new PinkieControls.ButtonXP();
            this.txtLoginPwd = new System.Windows.Forms.TextBox();
            this.txtLoginName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.txtLoginPwd);
            this.panel1.Controls.Add(this.txtLoginName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(219, 104);
            this.panel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnCancel.DefaultScheme = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Hint = "";
            this.btnCancel.Location = new System.Drawing.Point(130, 64);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnCancel.Size = new System.Drawing.Size(62, 28);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "取  消";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnLogin.DefaultScheme = true;
            this.btnLogin.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnLogin.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLogin.Hint = "";
            this.btnLogin.Location = new System.Drawing.Point(56, 64);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnLogin.Size = new System.Drawing.Size(60, 28);
            this.btnLogin.TabIndex = 8;
            this.btnLogin.Text = "确  认";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtLoginPwd
            // 
            this.txtLoginPwd.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLoginPwd.Location = new System.Drawing.Point(56, 35);
            this.txtLoginPwd.Name = "txtLoginPwd";
            this.txtLoginPwd.Size = new System.Drawing.Size(136, 23);
            this.txtLoginPwd.TabIndex = 7;
            this.txtLoginPwd.UseSystemPasswordChar = true;
            this.txtLoginPwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLoginPwd_KeyDown);
            // 
            // txtLoginName
            // 
            this.txtLoginName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLoginName.Location = new System.Drawing.Point(56, 9);
            this.txtLoginName.Name = "txtLoginName";
            this.txtLoginName.Size = new System.Drawing.Size(136, 23);
            this.txtLoginName.TabIndex = 4;
            this.txtLoginName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLoginName_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(8, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "密 码";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "帐 号";
            // 
            // frmConfirmLogin
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(237, 123);
            this.Controls.Add(this.panel1);
            this.Name = "frmConfirmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "检验审核身份登录";
            this.Load += new System.EventHandler(this.frmConfirmLogin_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		public override void CreateController()
		{
			this.objController = new clsController_ConfirmLogin();
			this.objController.Set_GUI_Apperance(this);
		}

        public frmConfirmLogin()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
        }

        public frmConfirmLogin(string p_strEmpNo)
        {
            InitializeComponent();
            this.strDefaultEmpNo = p_strEmpNo;
        }

        /// <summary>
        /// 审核者Id
        /// </summary>
        public string SubmitId
        {
            get
            {
                return this.strEmpID;
            }
        } 

        #region 事件实现

        private void frmConfirmLogin_Load(object sender, System.EventArgs e)
        {
            m_mthSetEnter2Tab(new System.Windows.Forms.Control[] { this.txtLoginName, this.txtLoginPwd });

            this.txtLoginName.Text = this.strDefaultEmpNo;
            this.txtLoginName.SelectAll();
        }

        private void btnLogin_Click(object sender, System.EventArgs e)
        {
            string strLoginName = this.txtLoginName.Text.Trim();
            string strLoginPwd = this.txtLoginPwd.Text.Trim();
            long lngRes = 0;
            bool blnLogin = false;
            string strLoginMsg = "";
            lngRes = ((clsController_ConfirmLogin)this.objController).m_lngCheckComfirLogin(strLoginName, strLoginPwd, out blnLogin, out strLoginMsg, out strEmpID);
            if (lngRes < 0)
            {
                MessageBox.Show(this, "确认时获取信息失败", "检验信息提示");
                return;
            }

            if (!blnLogin)
            {
                MessageBox.Show(this, strLoginMsg, "检验信息提示");
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void txtLoginName_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtLoginPwd.Focus();
                this.txtLoginPwd.SelectAll();
            }
        }

        private void txtLoginPwd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnLogin.Focus();
            }
        }
        
        #endregion

        private static frmConfirmLogin m_submitLogin;
        public static frmConfirmLogin SubmitLogin 
        {
            get 
            {
                if (m_submitLogin==null)
                {
                    m_submitLogin = new frmConfirmLogin();
                }

                m_submitLogin.txtLoginName.Text = string.Empty;
                m_submitLogin.txtLoginPwd.Text = string.Empty;
                return m_submitLogin;
            }
        }

	}
}
