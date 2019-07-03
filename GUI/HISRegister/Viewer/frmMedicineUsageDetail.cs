using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.iCare.gui.TemplateUtility; //TemplateUtility.dll or TemplateMaintenance.dll
using iCare.CustomForm;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmMedicineUsageDetail 的摘要说明。
	/// </summary>
    public class frmMedicineUsageDetail : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
        private System.Windows.Forms.CheckBox checkBox1;
		private PinkieControls.ButtonXP btOK;
		private PinkieControls.ButtonXP btCancel;
        private System.Windows.Forms.Label label1;
        internal Label lbeMedicine;
        private IContainer components;
        private ContextMenu contextMenu1;
        private MenuItem menu_Template;
        private MenuItem menu_CreatTemplate;
        private MenuItem menu_changeTemplate;
        private MenuItem menu_Cut;
        private MenuItem menu_Copy;
        private MenuItem menuI_Paste;
        private MenuItem menuI_Undo;
        private com.digitalwave.controls.ctlRichTextBox m_txtMedDetails;
        private ToolTip toolTip1;
		private bool m_blnPsFlag = false;

		public frmMedicineUsageDetail(bool p_PsFlag)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			m_blnPsFlag = p_PsFlag;
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMedicineUsageDetail));
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btOK = new PinkieControls.ButtonXP();
            this.btCancel = new PinkieControls.ButtonXP();
            this.label1 = new System.Windows.Forms.Label();
            this.lbeMedicine = new System.Windows.Forms.Label();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menu_Template = new System.Windows.Forms.MenuItem();
            this.menu_CreatTemplate = new System.Windows.Forms.MenuItem();
            this.menu_changeTemplate = new System.Windows.Forms.MenuItem();
            this.menu_Cut = new System.Windows.Forms.MenuItem();
            this.menu_Copy = new System.Windows.Forms.MenuItem();
            this.menuI_Paste = new System.Windows.Forms.MenuItem();
            this.menuI_Undo = new System.Windows.Forms.MenuItem();
            this.m_txtMedDetails = new com.digitalwave.controls.ctlRichTextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox1.Location = new System.Drawing.Point(7, 28);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(64, 24);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "皮 试";
            this.checkBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.checkBox1_KeyDown);
            // 
            // btOK
            // 
            this.btOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btOK.DefaultScheme = true;
            this.btOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btOK.Hint = "";
            this.btOK.Location = new System.Drawing.Point(315, 0);
            this.btOK.Name = "btOK";
            this.btOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btOK.Size = new System.Drawing.Size(73, 32);
            this.btOK.TabIndex = 1;
            this.btOK.Text = "确定(&S)";
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCancel
            // 
            this.btCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btCancel.DefaultScheme = true;
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Hint = "";
            this.btCancel.Location = new System.Drawing.Point(397, 1);
            this.btCancel.Name = "btCancel";
            this.btCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btCancel.Size = new System.Drawing.Size(74, 32);
            this.btCancel.TabIndex = 2;
            this.btCancel.Text = "取消(ESC)";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(72, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "回车跳转";
            // 
            // lbeMedicine
            // 
            this.lbeMedicine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbeMedicine.ForeColor = System.Drawing.Color.Red;
            this.lbeMedicine.Location = new System.Drawing.Point(7, 5);
            this.lbeMedicine.Name = "lbeMedicine";
            this.lbeMedicine.Size = new System.Drawing.Size(300, 24);
            this.lbeMedicine.TabIndex = 5;
            this.lbeMedicine.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menu_Template,
            this.menu_Cut,
            this.menu_Copy,
            this.menuI_Paste,
            this.menuI_Undo});
            // 
            // menu_Template
            // 
            this.menu_Template.Index = 0;
            this.menu_Template.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menu_CreatTemplate,
            this.menu_changeTemplate});
            this.menu_Template.Text = "模板维护";
            // 
            // menu_CreatTemplate
            // 
            this.menu_CreatTemplate.Index = 0;
            this.menu_CreatTemplate.Text = "生成模板";
            this.menu_CreatTemplate.Click += new System.EventHandler(this.menu_CreatTemplate_Click);
            // 
            // menu_changeTemplate
            // 
            this.menu_changeTemplate.Index = 1;
            this.menu_changeTemplate.Text = "修改模板";
            this.menu_changeTemplate.Click += new System.EventHandler(this.menu_changeTemplate_Click);
            // 
            // menu_Cut
            // 
            this.menu_Cut.Index = 1;
            this.menu_Cut.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
            this.menu_Cut.Text = "剪切";
            this.menu_Cut.Click += new System.EventHandler(this.menu_Cut_Click);
            // 
            // menu_Copy
            // 
            this.menu_Copy.Index = 2;
            this.menu_Copy.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
            this.menu_Copy.Text = "复制";
            this.menu_Copy.Click += new System.EventHandler(this.menu_Copy_Click);
            // 
            // menuI_Paste
            // 
            this.menuI_Paste.Index = 3;
            this.menuI_Paste.Shortcut = System.Windows.Forms.Shortcut.CtrlV;
            this.menuI_Paste.Text = "粘贴";
            this.menuI_Paste.Click += new System.EventHandler(this.menuI_Paste_Click);
            // 
            // menuI_Undo
            // 
            this.menuI_Undo.Index = 4;
            this.menuI_Undo.Shortcut = System.Windows.Forms.Shortcut.CtrlZ;
            this.menuI_Undo.Text = "撤消";
            this.menuI_Undo.Click += new System.EventHandler(this.menuI_Undo_Click);
            // 
            // m_txtMedDetails
            // 
            this.m_txtMedDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtMedDetails.ContextMenu = this.contextMenu1;
            this.m_txtMedDetails.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtMedDetails.Location = new System.Drawing.Point(4, 51);
            this.m_txtMedDetails.m_BlnIgnoreUserInfo = true;
            this.m_txtMedDetails.m_BlnPartControl = false;
            this.m_txtMedDetails.m_BlnReadOnly = false;
            this.m_txtMedDetails.m_BlnUnderLineDST = false;
            this.m_txtMedDetails.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtMedDetails.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtMedDetails.m_IntCanModifyTime = 500;
            this.m_txtMedDetails.m_IntPartControlLength = 0;
            this.m_txtMedDetails.m_IntPartControlStartIndex = 0;
            this.m_txtMedDetails.m_StrUserID = "";
            this.m_txtMedDetails.m_StrUserName = "";
            this.m_txtMedDetails.Name = "m_txtMedDetails";
            this.m_txtMedDetails.Size = new System.Drawing.Size(470, 168);
            this.m_txtMedDetails.TabIndex = 0;
            this.m_txtMedDetails.Text = "";
            this.toolTip1.SetToolTip(this.m_txtMedDetails, "请在这里录入详细用法");
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ShowAlways = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "提示";
            // 
            // frmMedicineUsageDetail
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(478, 222);
            this.Controls.Add(this.m_txtMedDetails);
            this.Controls.Add(this.lbeMedicine);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.checkBox1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMedicineUsageDetail";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "详细用法录入窗口";
            this.Load += new System.EventHandler(this.frmMedicineUsageDetail_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void checkBox1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			this.label1.Visible =false;
			if(e.KeyCode==Keys.Enter)
			{
			    this.m_txtMedDetails.Focus();
			}
		}

		private void textBox1_Enter(object sender, System.EventArgs e)
		{
			if(this.m_txtMedDetails.Text =="在这里输入详细用法")
			{
			    this.m_txtMedDetails.Text ="";
			}
		}

		private void btCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btOK_Click(object sender, System.EventArgs e)
		{
			this.DialogResult =DialogResult.OK;
		}

		private void frmMedicineUsageDetail_Load(object sender, System.EventArgs e)
		{
			if( m_blnPsFlag )
			{
				this.checkBox1.Enabled = true;
			}
			else
			{
				this.checkBox1.Enabled = false;
			}


            //if (lbeMedicine.Tag == null)
            //{
            //    MessageBox.Show("无传入项目ID");
            //    return;
            //}
            //this.Name = this.Name + lbeMedicine.Tag.ToString().Trim();
            //this.m_txtMedDetails.Name = this.m_txtMedDetails.Name + this.LoginInfo.m_strEmpID;

            clsDcl_DoctorWorkstation objSvc = new clsDcl_DoctorWorkstation();
//            long lngRes = objSvc.m_lngSetModeByItem(this.Name, "详细用法录入窗口", m_txtMedDetails.Name, "操作员(" + LoginInfo.m_strEmpName + ")详细用法模板");
            long lngRes = objSvc.m_lngSetModeByItem(this.Name, "详细用法录入窗口", m_txtMedDetails.Name, "详细用法模板");
            if (lngRes <0)
            {
                MessageBox.Show("数据访问出错");
                return;
            }
            objSvc = null;

            #region mod
            string m_strDeptID = "";
            string m_strEmpID = this.LoginInfo.m_strEmpID;

            com.digitalwave.GUI_Base.clsController_Base objCtlBase = new com.digitalwave.GUI_Base.clsController_Base();
            com.digitalwave.iCare.ValueObject.clsDepartmentVO[] objDept = null;
            objCtlBase.m_objComInfo.m_mthGetDepartmentByUserID(m_strEmpID, out objDept);
            if (objDept != null)
            {
                for (int i = 0; i < objDept.Length; i++)
                {
                    if (objDept[i].intInPatientOrOutPatient == 0)
                    {
                        m_strDeptID = objDept[i].strDeptID;
                        break;
                    }
                }
            }

            m_objTemplate = new com.digitalwave.iCare.Template.Client.clsTemplateClient(this, this.LoginInfo.m_strEmpID, m_strDeptID);
            #endregion
		}
        #region 模板

        #region 生成模板
        private com.digitalwave.iCare.gui.Security.clsController_Security objController_Security = null;
        private com.digitalwave.iCare.gui.TemplateUtility.clsHRPTemplateUtility m_objTemplateUtility;
        private com.digitalwave.iCare.Template.Client.clsTemplateClient m_objTemplate;
        public void m_mthCreateTemplate()
        {
            this.m_objTemplate.m_mthCreateTemplate();
        }
        #endregion

        private void btnCreateTemplate_Click(object sender, System.EventArgs e)
        {
            m_mthCreateTemplate();
        }
        #endregion

		/// <summary>
		/// 详细用法
		/// </summary>
		public string UsageDetail
		{
			get
			{
				if(this.m_txtMedDetails.Text =="在这里输入详细用法")
				{
					return "";
				}
				else
				{
					return this.m_txtMedDetails.Text;
				}
			}
			set
			{
				if(value.Trim()!="")
				{
					this.m_txtMedDetails.Text =value;
				}
			}
		}
		/// <summary>
		/// 是否皮试 0否，1是
		/// </summary>
		public string Check
		{
			get
			{
				if(this.checkBox1.Checked)
				{
					return "1";
				}
				else
				{
					return "0";
				}
			}
			set
			{
				if(value.Trim()=="1")
				{
					this.checkBox1.Checked =true;
				}
				else
				{
					this.checkBox1.Checked =false;
				}
			}
		}
		public string MedicineName
		{
			set
			{
			this.lbeMedicine.Text =value;
			}
		}

        private void menu_CreatTemplate_Click(object sender, EventArgs e)
        {
            m_mthCreateTemplate();
        }

        private void menu_changeTemplate_Click(object sender, EventArgs e)
        {
            this.m_objTemplate.m_mthManageTemplate();
        }

        private void menu_Cut_Click(object sender, EventArgs e)
        {
            m_txtMedDetails.Cut();
        }

        private void menu_Copy_Click(object sender, EventArgs e)
        {
            m_txtMedDetails.Copy();
        }

        private void menuI_Paste_Click(object sender, EventArgs e)
        {
            m_txtMedDetails.Paste();
        }

        private void menuI_Undo_Click(object sender, EventArgs e)
        {
            m_txtMedDetails.Undo();
        }

	}
}
