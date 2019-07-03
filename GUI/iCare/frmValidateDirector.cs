using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace iCare
{
	/// <summary>
	/// Summary description for frmValidateDirector.
	/// </summary>
	public class frmValidateDirector : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboUser;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtPW;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private PinkieControls.ButtonXP m_cmdOK;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboUser1;
		private PinkieControls.ButtonXP m_cmdCancel;

		private static bool m_blnValidateResult;

		public static bool BlnValidateResult
		{
			get{return m_blnValidateResult;}
		}
		public frmValidateDirector()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			m_blnValidateResult=false;
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
			this.m_cboUser = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.m_txtPW = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_cmdOK = new PinkieControls.ButtonXP();
			this.m_cmdCancel = new PinkieControls.ButtonXP();
			this.m_cboUser1 = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.SuspendLayout();
			// 
			// m_cboUser
			// 
			this.m_cboUser.AccessibleName = "NoDefault";
			this.m_cboUser.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboUser.BorderColor = System.Drawing.Color.Black;
			this.m_cboUser.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboUser.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboUser.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboUser.flatFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboUser.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboUser.ForeColor = System.Drawing.Color.Black;
			this.m_cboUser.ListBackColor = System.Drawing.Color.White;
			this.m_cboUser.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboUser.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboUser.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboUser.Location = new System.Drawing.Point(111, 26);
			this.m_cboUser.m_BlnEnableItemEventMenu = false;
			this.m_cboUser.Name = "m_cboUser";
			this.m_cboUser.SelectedIndex = -1;
			this.m_cboUser.SelectedItem = null;
			this.m_cboUser.SelectionStart = 0;
			this.m_cboUser.Size = new System.Drawing.Size(180, 26);
			this.m_cboUser.TabIndex = 10000000;
			this.m_cboUser.TabStop = false;
			this.m_cboUser.TextBackColor = System.Drawing.Color.White;
			this.m_cboUser.TextForeColor = System.Drawing.Color.Black;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(24, 30);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 22);
			this.label1.TabIndex = 10000001;
			this.label1.Text = "主任医师";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(24, 70);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(39, 22);
			this.label2.TabIndex = 10000001;
			this.label2.Text = "密码";
			// 
			// m_txtPW
			// 
			this.m_txtPW.AccessibleName = "NoDefault";
			this.m_txtPW.AutoSize = false;
			this.m_txtPW.BackColor = System.Drawing.SystemColors.Window;
			this.m_txtPW.BorderColor = System.Drawing.Color.White;
			this.m_txtPW.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtPW.ForeColor = System.Drawing.Color.Black;
			this.m_txtPW.Location = new System.Drawing.Point(111, 67);
			this.m_txtPW.Name = "m_txtPW";
			this.m_txtPW.PasswordChar = '*';
			this.m_txtPW.Size = new System.Drawing.Size(180, 21);
			this.m_txtPW.TabIndex = 10000002;
			this.m_txtPW.Text = "";
			// 
			// m_cmdOK
			// 
			this.m_cmdOK.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdOK.DefaultScheme = true;
			this.m_cmdOK.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdOK.ForeColor = System.Drawing.Color.Black;
			this.m_cmdOK.Hint = "";
			this.m_cmdOK.Location = new System.Drawing.Point(136, 104);
			this.m_cmdOK.Name = "m_cmdOK";
			this.m_cmdOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdOK.Size = new System.Drawing.Size(64, 32);
			this.m_cmdOK.TabIndex = 10000004;
			this.m_cmdOK.Text = "确定";
			this.m_cmdOK.Click += new System.EventHandler(this.m_cmdOK_Click);
			// 
			// m_cmdCancel
			// 
			this.m_cmdCancel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdCancel.DefaultScheme = true;
			this.m_cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_cmdCancel.ForeColor = System.Drawing.Color.Black;
			this.m_cmdCancel.Hint = "";
			this.m_cmdCancel.Location = new System.Drawing.Point(216, 104);
			this.m_cmdCancel.Name = "m_cmdCancel";
			this.m_cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdCancel.Size = new System.Drawing.Size(64, 32);
			this.m_cmdCancel.TabIndex = 10000005;
			this.m_cmdCancel.Text = "取消";
			this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdCancel_Click);
			// 
			// m_cboUser1
			// 
			this.m_cboUser1.AccessibleName = "NoDefault";
			this.m_cboUser1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboUser1.BorderColor = System.Drawing.Color.Black;
			this.m_cboUser1.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboUser1.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboUser1.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboUser1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboUser1.flatFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboUser1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboUser1.ForeColor = System.Drawing.Color.Black;
			this.m_cboUser1.ListBackColor = System.Drawing.Color.White;
			this.m_cboUser1.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboUser1.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboUser1.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboUser1.Location = new System.Drawing.Point(112, 0);
			this.m_cboUser1.m_BlnEnableItemEventMenu = false;
			this.m_cboUser1.Name = "m_cboUser1";
			this.m_cboUser1.SelectedIndex = -1;
			this.m_cboUser1.SelectedItem = null;
			this.m_cboUser1.SelectionStart = 0;
			this.m_cboUser1.Size = new System.Drawing.Size(180, 26);
			this.m_cboUser1.TabIndex = 10000000;
			this.m_cboUser1.TabStop = false;
			this.m_cboUser1.TextBackColor = System.Drawing.Color.White;
			this.m_cboUser1.TextForeColor = System.Drawing.Color.Black;
			this.m_cboUser1.Visible = false;
			// 
			// frmValidateDirector
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(314, 159);
			this.Controls.Add(this.m_cmdCancel);
			this.Controls.Add(this.m_cmdOK);
			this.Controls.Add(this.m_txtPW);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.m_cboUser);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.m_cboUser1);
			this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ForeColor = System.Drawing.SystemColors.WindowText;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmValidateDirector";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "主任医师验证";
			this.Load += new System.EventHandler(this.frmValidateDirector_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void m_mthGetAllInfo()
		{			
			System.Data.DataTable dtRecord=null;

            com.digitalwave.EMR_EmployeeManagerService.clsEMR_EmployeeManagerService objServ =
                (com.digitalwave.EMR_EmployeeManagerService.clsEMR_EmployeeManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.EMR_EmployeeManagerService.clsEMR_EmployeeManagerService));

			objServ.m_lngGetChargeDocByDeptID(null,MDIParent.s_ObjDepartment.m_StrDeptID.Trim(),out dtRecord);
			
			if(dtRecord != null || dtRecord.Rows.Count>0)
			{
				for(int i=0;i<dtRecord.Rows.Count;i++)
				{
					m_cboUser.AddItem(dtRecord.Rows[i]["FirstName"].ToString());
					m_cboUser1.AddItem(dtRecord.Rows[i]["EmployeeID"].ToString());
				}
				m_cboUser.SelectedIndex = 0;
			}
		}

		private void frmValidateDirector_Load(object sender, System.EventArgs e)
		{
			m_mthGetAllInfo();
		}

		private void m_cmdCancel_Click(object sender, System.EventArgs e)
		{
			m_blnValidateResult=false;
			this.Close();
		}

		private void m_cmdOK_Click(object sender, System.EventArgs e)
		{
			string strPsw = "";

            com.digitalwave.emr.HospitalManagerService.clsHospitalManagerService objServ =
                (com.digitalwave.emr.HospitalManagerService.clsHospitalManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.emr.HospitalManagerService.clsHospitalManagerService));

            objServ.m_lngGetEmpPSWByID(null, m_cboUser1.GetItem(m_cboUser.SelectedIndex).ToString(), out strPsw, true);
			
			if(strPsw == m_txtPW.Text.Trim() || (strPsw == null && m_txtPW.Text.Trim() == ""))
			{
				m_blnValidateResult = true;
				this.Close();
			}
			else if(strPsw != m_txtPW.Text.Trim())
			{
				MDIParent.ShowInformationMessageBox("验证错误，请重新输入！"); 
				return;
			}
		}

		
	}
}
