using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmHISInfoDefine 的摘要说明。
	/// </summary>
	public class frmHISInfoDefine : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtName;
		private PinkieControls.ButtonXP m_btnExit;
		private PinkieControls.ButtonXP m_btnSave;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtAddress;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtPhone1;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtPhone2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtZIP;
		private System.Windows.Forms.Label label6;
		internal com.digitalwave.controls.ctlRichTextBox m_txtMemo;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmHISInfoDefine()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
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
			this.m_txtName = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.m_btnExit = new PinkieControls.ButtonXP();
			this.m_btnSave = new PinkieControls.ButtonXP();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.m_txtMemo = new com.digitalwave.controls.ctlRichTextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.m_txtAddress = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.label2 = new System.Windows.Forms.Label();
			this.m_txtPhone1 = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.label3 = new System.Windows.Forms.Label();
			this.m_txtPhone2 = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.label4 = new System.Windows.Forms.Label();
			this.m_txtZIP = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.label6 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_txtName
			// 
			this.m_txtName.EnableAutoValidation = true;
			this.m_txtName.EnableEnterKeyValidate = true;
			this.m_txtName.EnableEscapeKeyUndo = true;
			this.m_txtName.EnableLastValidValue = true;
			this.m_txtName.ErrorProvider = null;
			this.m_txtName.ErrorProviderMessage = "Invalid value";
			this.m_txtName.ForceFormatText = true;
			this.m_txtName.Location = new System.Drawing.Point(120, 32);
			this.m_txtName.Name = "m_txtName";
			this.m_txtName.Size = new System.Drawing.Size(328, 23);
			this.m_txtName.TabIndex = 20;
			this.m_txtName.Text = "";
			// 
			// m_btnExit
			// 
			this.m_btnExit.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnExit.DefaultScheme = true;
			this.m_btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btnExit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_btnExit.Hint = "";
			this.m_btnExit.Location = new System.Drawing.Point(312, 360);
			this.m_btnExit.Name = "m_btnExit";
			this.m_btnExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnExit.Size = new System.Drawing.Size(96, 32);
			this.m_btnExit.TabIndex = 23;
			this.m_btnExit.Text = "退出(Esc)";
			// 
			// m_btnSave
			// 
			this.m_btnSave.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnSave.DefaultScheme = true;
			this.m_btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnSave.Hint = "";
			this.m_btnSave.Location = new System.Drawing.Point(152, 360);
			this.m_btnSave.Name = "m_btnSave";
			this.m_btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnSave.Size = new System.Drawing.Size(96, 32);
			this.m_btnSave.TabIndex = 21;
			this.m_btnSave.Text = "保存(&S)";
			this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(32, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 19);
			this.label1.TabIndex = 22;
			this.label1.Text = "医院名称：";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.m_txtMemo);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.m_txtName);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.m_btnExit);
			this.groupBox1.Controls.Add(this.m_btnSave);
			this.groupBox1.Controls.Add(this.m_txtAddress);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.m_txtPhone1);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.m_txtPhone2);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.m_txtZIP);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.groupBox1.Location = new System.Drawing.Point(32, 24);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(496, 408);
			this.groupBox1.TabIndex = 24;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "医院基本信息";
			// 
			// m_txtMemo
			// 
			this.m_txtMemo.AccessibleDescription = "";
			this.m_txtMemo.Location = new System.Drawing.Point(120, 232);
			this.m_txtMemo.m_BlnIgnoreUserInfo = true;
			this.m_txtMemo.m_BlnPartControl = false;
			this.m_txtMemo.m_BlnReadOnly = false;
			this.m_txtMemo.m_BlnUnderLineDST = false;
			this.m_txtMemo.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtMemo.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtMemo.m_IntCanModifyTime = 6;
			this.m_txtMemo.m_IntPartControlLength = 0;
			this.m_txtMemo.m_IntPartControlStartIndex = 0;
			this.m_txtMemo.m_StrUserID = "";
			this.m_txtMemo.m_StrUserName = "";
			this.m_txtMemo.MaxLength = 1000;
			this.m_txtMemo.Name = "m_txtMemo";
			this.m_txtMemo.Size = new System.Drawing.Size(336, 96);
			this.m_txtMemo.TabIndex = 242;
			this.m_txtMemo.Text = "";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(40, 232);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(77, 19);
			this.label5.TabIndex = 24;
			this.label5.Text = "备    注：";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_txtAddress
			// 
			this.m_txtAddress.EnableAutoValidation = true;
			this.m_txtAddress.EnableEnterKeyValidate = true;
			this.m_txtAddress.EnableEscapeKeyUndo = true;
			this.m_txtAddress.EnableLastValidValue = true;
			this.m_txtAddress.ErrorProvider = null;
			this.m_txtAddress.ErrorProviderMessage = "Invalid value";
			this.m_txtAddress.ForceFormatText = true;
			this.m_txtAddress.Location = new System.Drawing.Point(120, 72);
			this.m_txtAddress.Name = "m_txtAddress";
			this.m_txtAddress.Size = new System.Drawing.Size(328, 23);
			this.m_txtAddress.TabIndex = 20;
			this.m_txtAddress.Text = "";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(32, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(77, 19);
			this.label2.TabIndex = 22;
			this.label2.Text = "医院地址：";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_txtPhone1
			// 
			this.m_txtPhone1.EnableAutoValidation = true;
			this.m_txtPhone1.EnableEnterKeyValidate = true;
			this.m_txtPhone1.EnableEscapeKeyUndo = true;
			this.m_txtPhone1.EnableLastValidValue = true;
			this.m_txtPhone1.ErrorProvider = null;
			this.m_txtPhone1.ErrorProviderMessage = "Invalid value";
			this.m_txtPhone1.ForceFormatText = true;
			this.m_txtPhone1.Location = new System.Drawing.Point(120, 112);
			this.m_txtPhone1.Name = "m_txtPhone1";
			this.m_txtPhone1.Size = new System.Drawing.Size(128, 23);
			this.m_txtPhone1.TabIndex = 20;
			this.m_txtPhone1.Text = "";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(32, 112);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(84, 19);
			this.label3.TabIndex = 22;
			this.label3.Text = "联系电话1：";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_txtPhone2
			// 
			this.m_txtPhone2.EnableAutoValidation = true;
			this.m_txtPhone2.EnableEnterKeyValidate = true;
			this.m_txtPhone2.EnableEscapeKeyUndo = true;
			this.m_txtPhone2.EnableLastValidValue = true;
			this.m_txtPhone2.ErrorProvider = null;
			this.m_txtPhone2.ErrorProviderMessage = "Invalid value";
			this.m_txtPhone2.ForceFormatText = true;
			this.m_txtPhone2.Location = new System.Drawing.Point(120, 152);
			this.m_txtPhone2.Name = "m_txtPhone2";
			this.m_txtPhone2.Size = new System.Drawing.Size(128, 23);
			this.m_txtPhone2.TabIndex = 20;
			this.m_txtPhone2.Text = "";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(32, 152);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(84, 19);
			this.label4.TabIndex = 22;
			this.label4.Text = "联系电话2：";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_txtZIP
			// 
			this.m_txtZIP.EnableAutoValidation = true;
			this.m_txtZIP.EnableEnterKeyValidate = true;
			this.m_txtZIP.EnableEscapeKeyUndo = true;
			this.m_txtZIP.EnableLastValidValue = true;
			this.m_txtZIP.ErrorProvider = null;
			this.m_txtZIP.ErrorProviderMessage = "Invalid value";
			this.m_txtZIP.ForceFormatText = true;
			this.m_txtZIP.Location = new System.Drawing.Point(120, 192);
			this.m_txtZIP.Name = "m_txtZIP";
			this.m_txtZIP.Size = new System.Drawing.Size(128, 23);
			this.m_txtZIP.TabIndex = 20;
			this.m_txtZIP.Text = "";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(32, 192);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(77, 19);
			this.label6.TabIndex = 22;
			this.label6.Text = "邮政编码：";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmHISInfoDefine
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(568, 461);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.Name = "frmHISInfoDefine";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "医院基本信息";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmHISInfoDefine_KeyDown);
			this.Load += new System.EventHandler(this.frmHISInfoDefine_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override void CreateController()
		{
			this.objController=new com.digitalwave.iCare.gui.HIS.clsCtl_HISInfoDefine();
			objController.Set_GUI_Apperance(this);
		}


		public new void Show_MDI_Child(Form frmMDI_Parent)
		{
			
			this.ShowDialog();
			
		}

		private void frmHISInfoDefine_Load(object sender, System.EventArgs e)
		{
			((clsCtl_HISInfoDefine)this.objController).m_GetHospitalinfo();
		}

		private void m_btnSave_Click(object sender, System.EventArgs e)
		{
			((clsCtl_HISInfoDefine)this.objController).m_lngSaveHospitalinfo();
		}

		private void frmHISInfoDefine_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Escape)
			{
				if(MessageBox.Show("确认退出吗?","iCare",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
					return;
				this.Close();

			}
		}


	
		

	
	}
}
