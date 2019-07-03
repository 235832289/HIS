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
	/// frmBreakInput 的摘要说明。
	/// </summary>
	public class frmBreakInput  : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		internal System.Windows.Forms.TextBox txtname;
		internal System.Windows.Forms.TextBox txtNo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
		private com.digitalwave.controls.ctlRichTextBox m_txtBreakReMark;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menu_Template;
		private System.Windows.Forms.MenuItem menu_CreatTemplate;
		private System.Windows.Forms.MenuItem menu_changeTemplate;
		private System.Windows.Forms.MenuItem menu_Cut;
		private System.Windows.Forms.MenuItem menu_Copy;
		private System.Windows.Forms.MenuItem menuI_Paste;
		private System.Windows.Forms.MenuItem menuI_Undo;
        internal PinkieControls.ButtonXP btnEsc;
        internal PinkieControls.ButtonXP btnBreak;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmBreakInput()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			string m_strDeptID = "";
			string m_strEmpID = this.LoginInfo.m_strEmpID;						

			com.digitalwave.GUI_Base.clsController_Base objCtlBase = new com.digitalwave.GUI_Base.clsController_Base();			
			com.digitalwave.iCare.ValueObject.clsDepartmentVO[] objDept = null;	
			objCtlBase.m_objComInfo.m_mthGetDepartmentByUserID(m_strEmpID, out objDept);					
			if(objDept != null)
			{ 
				for(int i=0; i<objDept.Length; i++)
				{
					if(objDept[i].intInPatientOrOutPatient == 0)
					{
						m_strDeptID = objDept[i].strDeptID;				
						break;
					}
				}
			}

			m_objTemplate=new com.digitalwave.iCare.Template.Client.clsTemplateClient(this,this.LoginInfo.m_strEmpID,m_strDeptID);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBreakInput));
            this.txtname = new System.Windows.Forms.TextBox();
            this.txtNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtBreakReMark = new com.digitalwave.controls.ctlRichTextBox();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menu_Template = new System.Windows.Forms.MenuItem();
            this.menu_CreatTemplate = new System.Windows.Forms.MenuItem();
            this.menu_changeTemplate = new System.Windows.Forms.MenuItem();
            this.menu_Cut = new System.Windows.Forms.MenuItem();
            this.menu_Copy = new System.Windows.Forms.MenuItem();
            this.menuI_Paste = new System.Windows.Forms.MenuItem();
            this.menuI_Undo = new System.Windows.Forms.MenuItem();
            this.btnEsc = new PinkieControls.ButtonXP();
            this.btnBreak = new PinkieControls.ButtonXP();
            this.SuspendLayout();
            // 
            // txtname
            // 
            this.txtname.Enabled = false;
            this.txtname.Location = new System.Drawing.Point(104, 62);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(192, 23);
            this.txtname.TabIndex = 4;
            // 
            // txtNo
            // 
            this.txtNo.Location = new System.Drawing.Point(104, 22);
            this.txtNo.Name = "txtNo";
            this.txtNo.Size = new System.Drawing.Size(192, 23);
            this.txtNo.TabIndex = 3;
            this.txtNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNo_KeyPress);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "员工工号：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "员工名称：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "退回原因：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // m_txtBreakReMark
            // 
            this.m_txtBreakReMark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtBreakReMark.ContextMenu = this.contextMenu1;
            this.m_txtBreakReMark.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBreakReMark.Location = new System.Drawing.Point(104, 102);
            this.m_txtBreakReMark.m_BlnIgnoreUserInfo = true;
            this.m_txtBreakReMark.m_BlnPartControl = false;
            this.m_txtBreakReMark.m_BlnReadOnly = false;
            this.m_txtBreakReMark.m_BlnUnderLineDST = false;
            this.m_txtBreakReMark.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBreakReMark.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBreakReMark.m_IntCanModifyTime = 500;
            this.m_txtBreakReMark.m_IntPartControlLength = 0;
            this.m_txtBreakReMark.m_IntPartControlStartIndex = 0;
            this.m_txtBreakReMark.m_StrUserID = "";
            this.m_txtBreakReMark.m_StrUserName = "";
            this.m_txtBreakReMark.Name = "m_txtBreakReMark";
            this.m_txtBreakReMark.Size = new System.Drawing.Size(192, 104);
            this.m_txtBreakReMark.TabIndex = 12;
            this.m_txtBreakReMark.Text = "";
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
            // btnEsc
            // 
            this.btnEsc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(240)))));
            this.btnEsc.DefaultScheme = true;
            this.btnEsc.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnEsc.Hint = "";
            this.btnEsc.Location = new System.Drawing.Point(184, 224);
            this.btnEsc.Name = "btnEsc";
            this.btnEsc.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnEsc.Size = new System.Drawing.Size(88, 29);
            this.btnEsc.TabIndex = 14;
            this.btnEsc.Text = "取消(&C)";
            this.btnEsc.Click += new System.EventHandler(this.btnEsc_Click);
            // 
            // btnBreak
            // 
            this.btnBreak.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(240)))));
            this.btnBreak.DefaultScheme = true;
            this.btnBreak.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnBreak.Hint = "";
            this.btnBreak.Location = new System.Drawing.Point(74, 224);
            this.btnBreak.Name = "btnBreak";
            this.btnBreak.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnBreak.Size = new System.Drawing.Size(88, 29);
            this.btnBreak.TabIndex = 13;
            this.btnBreak.Text = "确定(&O)";
            this.btnBreak.Click += new System.EventHandler(this.btnBreak_Click);
            // 
            // frmBreakInput
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(328, 277);
            this.Controls.Add(this.btnEsc);
            this.Controls.Add(this.btnBreak);
            this.Controls.Add(this.m_txtBreakReMark);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.txtNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBreakInput";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "退回处方";
            this.Load += new System.EventHandler(this.frmBreakInput_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
		private void txtNo_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar == (char)13)
			{
				if(this.txtNo.Text!="")
				{
					string p_strName="";
					string empID="";
					string p_strID=this.txtNo.Text.Trim();
					clsDomainControlMedStore objcontrol=new clsDomainControlMedStore();
					objcontrol.m_lngfinedata(p_strID,out p_strName,out empID);
					if(p_strName=="")
					{
						this.txtname.Text="错误的员工号";
					}
					else
					{
						this.txtNo.Tag=empID;
						this.txtname.Text=p_strName;
					}
					this.m_txtBreakReMark.Focus();
				}
				else
				{
					this.txtname.Text="工号不能为空";
					this.txtname.Focus();
				}
			}
		}
		private com.digitalwave.iCare.gui.HIS.clsControlOPMedStore ContorlInput;
		/// <summary>
		/// 
		/// </summary>
		public void m_GetcontrolMetStore(clsControlOPMedStore Input)
		{
			this.ContorlInput=Input;
			this.Show();
		}
		private void frmBreakInput_Load(object sender, System.EventArgs e)
		{
		}
		#region 模板 
		#region 初始化模板
		public void m_mthInitializeTemplate()
		{
			clsExteriorFunctionInterface.m_ObjUserInfo = this.LoginInfo;
			frmTextTemplate frm =new frmTextTemplate(m_txtBreakReMark);
			frm.m_mthInitilizeTemplateInfo(this.Name,m_txtBreakReMark.Name);
			frm.getEmpID=this.LoginInfo.m_strEmpID;
			frm.ShowDialog();
		}
		#endregion

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

		private void m_mnuRTDelete_Click(object sender, System.EventArgs e)
		{
			if(this.ActiveControl is com.digitalwave.controls.ctlRichTextBox)
			{
				((com.digitalwave.controls.ctlRichTextBox)(this.ActiveControl)).m_mthSelectionDoubleStrikeThough(true);
			}
		}

		private void meuUndoDel_Click(object sender, System.EventArgs e)
		{
			if(this.ActiveControl is com.digitalwave.controls.ctlRichTextBox)
			{
				((com.digitalwave.controls.ctlRichTextBox)(this.ActiveControl)).m_mthSelectionDoubleStrikeThough(false);
			}
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			if(this.ActiveControl is com.digitalwave.controls.ctlRichTextBox)
			{
				((com.digitalwave.controls.ctlRichTextBox)(this.ActiveControl)).m_mthSetSelectionScript(0);
			}
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			if(this.ActiveControl is com.digitalwave.controls.ctlRichTextBox)
			{
				((com.digitalwave.controls.ctlRichTextBox)(this.ActiveControl)).m_mthSetSelectionScript(1);
			}
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			if(this.ActiveControl is com.digitalwave.controls.ctlRichTextBox)
			{
				((com.digitalwave.controls.ctlRichTextBox)(this.ActiveControl)).m_mthUndoSuperSubScript();
			}
		}

		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			this.m_objTemplate.m_mthCreateTemplate();
		}

		private void menuItem6_Click(object sender, System.EventArgs e)
		{
			this.m_objTemplate.m_mthManageTemplate();
		}

		private void menu_CreatTemplate_Click(object sender, System.EventArgs e)
		{
			this.m_objTemplate.m_mthCreateTemplate();
		}

		private void menu_changeTemplate_Click(object sender, System.EventArgs e)
		{
			this.m_objTemplate.m_mthManageTemplate();
		}

		private void menu_Cut_Click(object sender, System.EventArgs e)
		{
			m_txtBreakReMark.Cut();
		}

		private void menu_Copy_Click(object sender, System.EventArgs e)
		{
			m_txtBreakReMark.Copy();
		}

		private void menuI_Paste_Click(object sender, System.EventArgs e)
		{
			m_txtBreakReMark.Paste();
		}

		private void menuI_Undo_Click(object sender, System.EventArgs e)
		{

			m_txtBreakReMark.m_mthUndo();
		}

		private void label3_Click(object sender, System.EventArgs e)
		{

		}

		private void btnEsc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnBreak_Click(object sender, System.EventArgs e)
		{
			if(this.txtNo.Text!=""&&this.txtname.Text!="")
			{
				string employee=(string)txtNo.Tag;
				string employName=txtname.Text.Trim();
				((clsControlOPMedStore)this.ContorlInput).m_getData(employee,employName,false,this.m_txtBreakReMark.Text);
				this.Close();
			}
		}
	}
}
