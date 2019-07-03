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
	public class frmCheckSign : iCare.iCareBaseForm.frmBaseForm
	{
		private PinkieControls.ButtonXP m_cmdOK;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtPSW;
		protected System.Windows.Forms.Label lblPSW;
		private PinkieControls.ButtonXP cmdCancel;
		protected System.Windows.Forms.Label m_lblEmployeeInfo;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="p_strEmployeeID">员工号</param>
		public frmCheckSign(string p_strEmployeeID):this(p_strEmployeeID,"")
		{
		}

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="p_strEmployeeID">员工号</param>
		/// <param name="p_strEmployeeName">员工姓名，可以为空</param>
		public frmCheckSign(string p_strEmployeeID,string p_strEmployeeName)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			m_objHighLight = new ctlHighLightFocus(clsHRPColor.s_ClrHightLight);

			m_objHighLight.m_mthAddControlInContainer(this);

			m_strEmployeeID = p_strEmployeeID;

//			m_lblEmployeeInfo.Text = "ID："+p_strEmployeeID;

			if(p_strEmployeeName != null && p_strEmployeeName.Trim().Length > 0)
			{
				m_lblEmployeeInfo.Text = " 姓名："+p_strEmployeeName;
			}
		}

		private string m_strEmployeeID;

		private ctlHighLightFocus m_objHighLight;

		/// <summary>
		/// -1，用户取消验证；0，数据库验证失败；1，数据库验证成功
		/// </summary>
		private long m_lngRes = -1;

		public long m_LngRes
		{
			get
			{
				return m_lngRes;
			}
		}

		/// <summary>
		/// 验证是否通过
		/// </summary>
		private bool m_blnIsPass = false;

		public bool m_BlnIsPass
		{
			get
			{
				return m_blnIsPass;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmCheckSign));
			this.m_cmdOK = new PinkieControls.ButtonXP();
			this.m_txtPSW = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_lblEmployeeInfo = new System.Windows.Forms.Label();
			this.lblPSW = new System.Windows.Forms.Label();
			this.cmdCancel = new PinkieControls.ButtonXP();
			this.SuspendLayout();
			// 
			// m_cmdOK
			// 
			this.m_cmdOK.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdOK.DefaultScheme = true;
			this.m_cmdOK.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdOK.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cmdOK.ForeColor = System.Drawing.Color.Black;
			this.m_cmdOK.Hint = "";
			this.m_cmdOK.Location = new System.Drawing.Point(196, 44);
			this.m_cmdOK.Name = "m_cmdOK";
			this.m_cmdOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdOK.Size = new System.Drawing.Size(75, 28);
			this.m_cmdOK.TabIndex = 3;
			this.m_cmdOK.Text = "确定";
			this.m_cmdOK.Click += new System.EventHandler(this.m_cmdOK_Click);
			// 
			// m_txtPSW
			// 
			this.m_txtPSW.BackColor = System.Drawing.Color.White;
			this.m_txtPSW.BorderColor = System.Drawing.Color.White;
			this.m_txtPSW.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtPSW.ForeColor = System.Drawing.Color.Black;
			this.m_txtPSW.Location = new System.Drawing.Point(68, 44);
			this.m_txtPSW.Name = "m_txtPSW";
			this.m_txtPSW.PasswordChar = '*';
			this.m_txtPSW.Size = new System.Drawing.Size(112, 23);
			this.m_txtPSW.TabIndex = 2;
			this.m_txtPSW.Text = "";
			// 
			// m_lblEmployeeInfo
			// 
			this.m_lblEmployeeInfo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lblEmployeeInfo.Location = new System.Drawing.Point(16, 16);
			this.m_lblEmployeeInfo.Name = "m_lblEmployeeInfo";
			this.m_lblEmployeeInfo.Size = new System.Drawing.Size(340, 20);
			this.m_lblEmployeeInfo.TabIndex = 499;
			// 
			// lblPSW
			// 
			this.lblPSW.AutoSize = true;
			this.lblPSW.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblPSW.ForeColor = System.Drawing.Color.Black;
			this.lblPSW.Location = new System.Drawing.Point(24, 48);
			this.lblPSW.Name = "lblPSW";
			this.lblPSW.Size = new System.Drawing.Size(48, 19);
			this.lblPSW.TabIndex = 498;
			this.lblPSW.Text = "密码：";
			// 
			// cmdCancel
			// 
			this.cmdCancel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.cmdCancel.DefaultScheme = true;
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.cmdCancel.ForeColor = System.Drawing.Color.Black;
			this.cmdCancel.Hint = "";
			this.cmdCancel.Location = new System.Drawing.Point(280, 44);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.cmdCancel.Size = new System.Drawing.Size(75, 28);
			this.cmdCancel.TabIndex = 4;
			this.cmdCancel.Text = "取消";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// frmCheckSign
			// 
			this.AcceptButton = this.m_cmdOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(370, 91);
			this.Controls.Add(this.m_txtPSW);
			this.Controls.Add(this.m_lblEmployeeInfo);
			this.Controls.Add(this.lblPSW);
			this.Controls.Add(this.m_cmdOK);
			this.Controls.Add(this.cmdCancel);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmCheckSign";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "员工签名验证";
			this.Load += new System.EventHandler(this.frmCheckSign_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void m_cmdOK_Click(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			clsLoginContext objLogin = clsLoginContext.s_ObjLoginContext;

			m_lngRes = objLogin.m_lngCheckEmployeeSign(m_strEmployeeID,m_txtPSW.Text,out m_blnIsPass);

			this.Close();

			this.Cursor = Cursors.Default;
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void frmCheckSign_Load(object sender, System.EventArgs e)
		{
			m_txtPSW.Focus();
		}
	}
}
