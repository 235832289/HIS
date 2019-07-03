using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;
using com.digitalwave.iCare.ValueObject;
namespace com.digitalwave.iCare.gui.LIS
{
	/// <summary>
	/// frmApplyUnitProperty 的摘要说明。
	/// </summary>
	public class frmApplyUnitProperty :com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
	{
		private clsController_ApplyUnitProperty m_objController;
		private static string c_strMessageBoxTitle = "iCare-申请单元属性维护";
		private static string c_strMessageDBFail = "数据库操作失败,请与管理员联系!";

		private clsApplyUnitPropertyDoc m_objDoc;
		private clsDomainController_ApplyUnitProperty m_objDomain = new clsDomainController_ApplyUnitProperty();

		#region FormControls
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel m_pnlBody;
		private System.Windows.Forms.Panel m_pnlBottom;
		private System.Windows.Forms.ListView m_lsvProperty;
		private System.Windows.Forms.ColumnHeader m_chPropertyName;
		private System.Windows.Forms.ColumnHeader m_chPropertySummary;
		private System.Windows.Forms.ListView m_lsvValue;
		private System.Windows.Forms.ColumnHeader m_chValue;
		private System.Windows.Forms.Button m_btnPriorityUp;
		private System.Windows.Forms.Button m_btnPriorityDown;
		private System.Windows.Forms.TextBox m_txtPropertyName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox m_txtPropertySummary;
		private System.Windows.Forms.TextBox m_txtValue;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel m_pnlProperty;
		private System.Windows.Forms.Panel m_pnlValue;
		private System.Windows.Forms.Button m_btnEditProperty;
		private System.Windows.Forms.Button m_btnEditValue;
		private System.Windows.Forms.Button m_btnNewValue;
		private System.Windows.Forms.Button m_btnDeleteProperty;
		private System.Windows.Forms.Button m_btnDeleteValue;
		private System.Windows.Forms.CheckBox m_chkShowPropertyDelete;
        private System.Windows.Forms.CheckBox m_chkShowDeleteValue;
		private System.Windows.Forms.Button m_btnNewProperty;
        private PinkieControls.ButtonXP m_btnSave;
        private PinkieControls.ButtonXP btnExit;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region Construct
		public frmApplyUnitProperty()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		#endregion

		#region override
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
		public override void CreateController()
		{
			this.objController= new com.digitalwave.iCare.gui.LIS.clsController_ApplyUnitProperty();
			m_objController = (clsController_ApplyUnitProperty)objController;
			this.objController.Set_GUI_Apperance(this);
		}

		#endregion

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmApplyUnitProperty));
            this.m_pnlBody = new System.Windows.Forms.Panel();
            this.m_pnlValue = new System.Windows.Forms.Panel();
            this.m_btnDeleteValue = new System.Windows.Forms.Button();
            this.m_btnEditValue = new System.Windows.Forms.Button();
            this.m_btnNewValue = new System.Windows.Forms.Button();
            this.m_lsvValue = new System.Windows.Forms.ListView();
            this.m_chValue = new System.Windows.Forms.ColumnHeader();
            this.m_txtValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_chkShowDeleteValue = new System.Windows.Forms.CheckBox();
            this.m_pnlProperty = new System.Windows.Forms.Panel();
            this.m_chkShowPropertyDelete = new System.Windows.Forms.CheckBox();
            this.m_btnDeleteProperty = new System.Windows.Forms.Button();
            this.m_btnPriorityDown = new System.Windows.Forms.Button();
            this.m_lsvProperty = new System.Windows.Forms.ListView();
            this.m_chPropertyName = new System.Windows.Forms.ColumnHeader();
            this.m_chPropertySummary = new System.Windows.Forms.ColumnHeader();
            this.m_txtPropertySummary = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_btnPriorityUp = new System.Windows.Forms.Button();
            this.m_txtPropertyName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_btnEditProperty = new System.Windows.Forms.Button();
            this.m_btnNewProperty = new System.Windows.Forms.Button();
            this.m_pnlBottom = new System.Windows.Forms.Panel();
            this.btnExit = new PinkieControls.ButtonXP();
            this.m_btnSave = new PinkieControls.ButtonXP();
            this.m_pnlBody.SuspendLayout();
            this.m_pnlValue.SuspendLayout();
            this.m_pnlProperty.SuspendLayout();
            this.m_pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_pnlBody
            // 
            this.m_pnlBody.Controls.Add(this.m_pnlValue);
            this.m_pnlBody.Controls.Add(this.m_pnlProperty);
            this.m_pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_pnlBody.Location = new System.Drawing.Point(0, 0);
            this.m_pnlBody.Name = "m_pnlBody";
            this.m_pnlBody.Size = new System.Drawing.Size(976, 421);
            this.m_pnlBody.TabIndex = 0;
            // 
            // m_pnlValue
            // 
            this.m_pnlValue.Controls.Add(this.m_btnDeleteValue);
            this.m_pnlValue.Controls.Add(this.m_btnEditValue);
            this.m_pnlValue.Controls.Add(this.m_btnNewValue);
            this.m_pnlValue.Controls.Add(this.m_lsvValue);
            this.m_pnlValue.Controls.Add(this.m_txtValue);
            this.m_pnlValue.Controls.Add(this.label4);
            this.m_pnlValue.Controls.Add(this.m_chkShowDeleteValue);
            this.m_pnlValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_pnlValue.Location = new System.Drawing.Point(560, 0);
            this.m_pnlValue.Name = "m_pnlValue";
            this.m_pnlValue.Size = new System.Drawing.Size(416, 421);
            this.m_pnlValue.TabIndex = 12;
            // 
            // m_btnDeleteValue
            // 
            this.m_btnDeleteValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnDeleteValue.Location = new System.Drawing.Point(256, 380);
            this.m_btnDeleteValue.Name = "m_btnDeleteValue";
            this.m_btnDeleteValue.Size = new System.Drawing.Size(64, 28);
            this.m_btnDeleteValue.TabIndex = 2;
            this.m_btnDeleteValue.Text = "删除";
            this.m_btnDeleteValue.Click += new System.EventHandler(this.m_btnDeleteValue_Click);
            // 
            // m_btnEditValue
            // 
            this.m_btnEditValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnEditValue.Location = new System.Drawing.Point(328, 380);
            this.m_btnEditValue.Name = "m_btnEditValue";
            this.m_btnEditValue.Size = new System.Drawing.Size(64, 28);
            this.m_btnEditValue.TabIndex = 3;
            this.m_btnEditValue.Text = "编辑";
            this.m_btnEditValue.Click += new System.EventHandler(this.m_btnEditValue_Click);
            // 
            // m_btnNewValue
            // 
            this.m_btnNewValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnNewValue.Location = new System.Drawing.Point(184, 380);
            this.m_btnNewValue.Name = "m_btnNewValue";
            this.m_btnNewValue.Size = new System.Drawing.Size(64, 28);
            this.m_btnNewValue.TabIndex = 1;
            this.m_btnNewValue.Text = "新增";
            this.m_btnNewValue.Click += new System.EventHandler(this.m_btnNewValue_Click);
            // 
            // m_lsvValue
            // 
            this.m_lsvValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lsvValue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_chValue});
            this.m_lsvValue.FullRowSelect = true;
            this.m_lsvValue.GridLines = true;
            this.m_lsvValue.HideSelection = false;
            this.m_lsvValue.Location = new System.Drawing.Point(16, 68);
            this.m_lsvValue.MultiSelect = false;
            this.m_lsvValue.Name = "m_lsvValue";
            this.m_lsvValue.Size = new System.Drawing.Size(388, 300);
            this.m_lsvValue.TabIndex = 0;
            this.m_lsvValue.UseCompatibleStateImageBehavior = false;
            this.m_lsvValue.View = System.Windows.Forms.View.Details;
            this.m_lsvValue.SelectedIndexChanged += new System.EventHandler(this.m_lsvValue_SelectedIndexChanged);
            this.m_lsvValue.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_lsvValue_MouseUp);
            // 
            // m_chValue
            // 
            this.m_chValue.Text = "属性值";
            this.m_chValue.Width = 272;
            // 
            // m_txtValue
            // 
            this.m_txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtValue.Location = new System.Drawing.Point(52, 36);
            this.m_txtValue.Name = "m_txtValue";
            this.m_txtValue.ReadOnly = true;
            this.m_txtValue.Size = new System.Drawing.Size(352, 23);
            this.m_txtValue.TabIndex = 4;
            this.m_txtValue.TextChanged += new System.EventHandler(this.m_txtValue_TextChanged);
            this.m_txtValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtValue_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 10;
            this.label4.Text = "值：";
            // 
            // m_chkShowDeleteValue
            // 
            this.m_chkShowDeleteValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_chkShowDeleteValue.Location = new System.Drawing.Point(104, 384);
            this.m_chkShowDeleteValue.Name = "m_chkShowDeleteValue";
            this.m_chkShowDeleteValue.Size = new System.Drawing.Size(88, 24);
            this.m_chkShowDeleteValue.TabIndex = 5;
            this.m_chkShowDeleteValue.Text = "显示禁用";
            this.m_chkShowDeleteValue.CheckedChanged += new System.EventHandler(this.m_chkShowDeleteValue_CheckedChanged);
            // 
            // m_pnlProperty
            // 
            this.m_pnlProperty.Controls.Add(this.m_chkShowPropertyDelete);
            this.m_pnlProperty.Controls.Add(this.m_btnDeleteProperty);
            this.m_pnlProperty.Controls.Add(this.m_btnPriorityDown);
            this.m_pnlProperty.Controls.Add(this.m_lsvProperty);
            this.m_pnlProperty.Controls.Add(this.m_txtPropertySummary);
            this.m_pnlProperty.Controls.Add(this.label3);
            this.m_pnlProperty.Controls.Add(this.m_btnPriorityUp);
            this.m_pnlProperty.Controls.Add(this.m_txtPropertyName);
            this.m_pnlProperty.Controls.Add(this.label1);
            this.m_pnlProperty.Controls.Add(this.label2);
            this.m_pnlProperty.Controls.Add(this.m_btnEditProperty);
            this.m_pnlProperty.Controls.Add(this.m_btnNewProperty);
            this.m_pnlProperty.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_pnlProperty.Location = new System.Drawing.Point(0, 0);
            this.m_pnlProperty.Name = "m_pnlProperty";
            this.m_pnlProperty.Size = new System.Drawing.Size(560, 421);
            this.m_pnlProperty.TabIndex = 11;
            // 
            // m_chkShowPropertyDelete
            // 
            this.m_chkShowPropertyDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_chkShowPropertyDelete.Location = new System.Drawing.Point(236, 384);
            this.m_chkShowPropertyDelete.Name = "m_chkShowPropertyDelete";
            this.m_chkShowPropertyDelete.Size = new System.Drawing.Size(84, 24);
            this.m_chkShowPropertyDelete.TabIndex = 4;
            this.m_chkShowPropertyDelete.Text = "显示禁用";
            this.m_chkShowPropertyDelete.CheckedChanged += new System.EventHandler(this.m_chkShowPropertyDelete_CheckedChanged);
            // 
            // m_btnDeleteProperty
            // 
            this.m_btnDeleteProperty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_btnDeleteProperty.Location = new System.Drawing.Point(404, 380);
            this.m_btnDeleteProperty.Name = "m_btnDeleteProperty";
            this.m_btnDeleteProperty.Size = new System.Drawing.Size(64, 28);
            this.m_btnDeleteProperty.TabIndex = 2;
            this.m_btnDeleteProperty.Text = "删除";
            this.m_btnDeleteProperty.Click += new System.EventHandler(this.m_btnDeleteProperty_Click);
            // 
            // m_btnPriorityDown
            // 
            this.m_btnPriorityDown.Location = new System.Drawing.Point(28, 216);
            this.m_btnPriorityDown.Name = "m_btnPriorityDown";
            this.m_btnPriorityDown.Size = new System.Drawing.Size(24, 48);
            this.m_btnPriorityDown.TabIndex = 3;
            this.m_btnPriorityDown.Text = "↓";
            this.m_btnPriorityDown.Click += new System.EventHandler(this.m_btnPriorityDown_Click);
            // 
            // m_lsvProperty
            // 
            this.m_lsvProperty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lsvProperty.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_chPropertyName,
            this.m_chPropertySummary});
            this.m_lsvProperty.FullRowSelect = true;
            this.m_lsvProperty.GridLines = true;
            this.m_lsvProperty.HideSelection = false;
            this.m_lsvProperty.Location = new System.Drawing.Point(64, 68);
            this.m_lsvProperty.Name = "m_lsvProperty";
            this.m_lsvProperty.Size = new System.Drawing.Size(480, 300);
            this.m_lsvProperty.TabIndex = 0;
            this.m_lsvProperty.UseCompatibleStateImageBehavior = false;
            this.m_lsvProperty.View = System.Windows.Forms.View.Details;
            this.m_lsvProperty.SelectedIndexChanged += new System.EventHandler(this.m_lsvProperty_SelectedIndexChanged);
            this.m_lsvProperty.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_lsvProperty_MouseUp);
            // 
            // m_chPropertyName
            // 
            this.m_chPropertyName.Text = "属性名";
            this.m_chPropertyName.Width = 132;
            // 
            // m_chPropertySummary
            // 
            this.m_chPropertySummary.Text = "备注";
            this.m_chPropertySummary.Width = 236;
            // 
            // m_txtPropertySummary
            // 
            this.m_txtPropertySummary.Location = new System.Drawing.Point(64, 36);
            this.m_txtPropertySummary.Name = "m_txtPropertySummary";
            this.m_txtPropertySummary.ReadOnly = true;
            this.m_txtPropertySummary.Size = new System.Drawing.Size(480, 23);
            this.m_txtPropertySummary.TabIndex = 6;
            this.m_txtPropertySummary.TextChanged += new System.EventHandler(this.m_txtPropertySummary_TextChanged);
            this.m_txtPropertySummary.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtPropertySummary_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "备注：";
            // 
            // m_btnPriorityUp
            // 
            this.m_btnPriorityUp.Location = new System.Drawing.Point(28, 100);
            this.m_btnPriorityUp.Name = "m_btnPriorityUp";
            this.m_btnPriorityUp.Size = new System.Drawing.Size(24, 48);
            this.m_btnPriorityUp.TabIndex = 2;
            this.m_btnPriorityUp.Text = "↑";
            this.m_btnPriorityUp.Click += new System.EventHandler(this.m_btnPriorityUp_Click);
            // 
            // m_txtPropertyName
            // 
            this.m_txtPropertyName.Location = new System.Drawing.Point(64, 12);
            this.m_txtPropertyName.Name = "m_txtPropertyName";
            this.m_txtPropertyName.ReadOnly = true;
            this.m_txtPropertyName.Size = new System.Drawing.Size(480, 23);
            this.m_txtPropertyName.TabIndex = 5;
            this.m_txtPropertyName.TextChanged += new System.EventHandler(this.m_txtPropertyName_TextChanged);
            this.m_txtPropertyName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtPropertyName_KeyDown);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(32, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 44);
            this.label1.TabIndex = 4;
            this.label1.Text = "优先级";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "名称：";
            // 
            // m_btnEditProperty
            // 
            this.m_btnEditProperty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_btnEditProperty.Location = new System.Drawing.Point(476, 380);
            this.m_btnEditProperty.Name = "m_btnEditProperty";
            this.m_btnEditProperty.Size = new System.Drawing.Size(64, 28);
            this.m_btnEditProperty.TabIndex = 3;
            this.m_btnEditProperty.Text = "编辑";
            this.m_btnEditProperty.Click += new System.EventHandler(this.m_btnEditProperty_Click);
            // 
            // m_btnNewProperty
            // 
            this.m_btnNewProperty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_btnNewProperty.Location = new System.Drawing.Point(332, 380);
            this.m_btnNewProperty.Name = "m_btnNewProperty";
            this.m_btnNewProperty.Size = new System.Drawing.Size(64, 28);
            this.m_btnNewProperty.TabIndex = 1;
            this.m_btnNewProperty.Text = "新增";
            this.m_btnNewProperty.Click += new System.EventHandler(this.m_btnAddProperty_Click);
            // 
            // m_pnlBottom
            // 
            this.m_pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_pnlBottom.Controls.Add(this.btnExit);
            this.m_pnlBottom.Controls.Add(this.m_btnSave);
            this.m_pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_pnlBottom.Location = new System.Drawing.Point(0, 421);
            this.m_pnlBottom.Name = "m_pnlBottom";
            this.m_pnlBottom.Size = new System.Drawing.Size(976, 56);
            this.m_pnlBottom.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnExit.DefaultScheme = true;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExit.Hint = "";
            this.btnExit.Location = new System.Drawing.Point(857, 13);
            this.btnExit.Name = "btnExit";
            this.btnExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnExit.Size = new System.Drawing.Size(95, 30);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "关闭(&C)";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // m_btnSave
            // 
            this.m_btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnSave.DefaultScheme = true;
            this.m_btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnSave.Hint = "";
            this.m_btnSave.Location = new System.Drawing.Point(742, 13);
            this.m_btnSave.Name = "m_btnSave";
            this.m_btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnSave.Size = new System.Drawing.Size(95, 30);
            this.m_btnSave.TabIndex = 11;
            this.m_btnSave.Text = "保存";
            this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
            // 
            // frmApplyUnitProperty
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(976, 477);
            this.Controls.Add(this.m_pnlBody);
            this.Controls.Add(this.m_pnlBottom);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmApplyUnitProperty";
            this.Text = "申请单元属性维护";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthEnterHandler);
            this.Load += new System.EventHandler(this.frmApplyUnitProperty_Load);
            this.m_pnlBody.ResumeLayout(false);
            this.m_pnlValue.ResumeLayout(false);
            this.m_pnlValue.PerformLayout();
            this.m_pnlProperty.ResumeLayout(false);
            this.m_pnlProperty.PerformLayout();
            this.m_pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region 一般设置
		#region 快捷键设置		
		private void m_mthShortCutKey(Keys p_eumKeyCode)
		{
			//			if(p_eumKeyCode==Keys.F3 && this.m_btnPreference.Enabled && m_btnPreference.Visible)//保存
			//			{
			//				this.m_btnPreference_Click(null,null);
			//			}
			//			else if(p_eumKeyCode==Keys.F5 && this.m_btnPrintReport.Enabled && m_btnPrintReport.Visible)//读卡
			//			{
			//				this.m_btnPrintReport_Click(null,null);
			//			}
			//			else if(p_eumKeyCode==Keys.F6 && this.m_btnPreviewReport.Enabled && m_btnPreviewReport.Visible)		//退出
			//			{
			//				this.m_btnPreviewReport_Click(null,null);
			//			}
			//			else if(p_eumKeyCode==Keys.F9 && this.m_btnConfirmReport.Enabled && m_btnConfirmReport.Visible)		//清除
			//			{
			//				this.m_btnConfirmReport_Click(null,null);
			//			}
		}
		#endregion
		#region Enter 键选择下一个
		private void m_mthEnterHandler(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			m_mthShortCutKey(e.KeyCode);
			this.m_mthSetKeyTab(e);
		}

		#endregion
				
		#endregion

		#region 初始化
		private void frmApplyUnitProperty_Load(object sender, System.EventArgs e)
		{
			this.m_mthSetFormControlCanBeNull(this);
			this.m_mthSetEnter2Tab(new Control[]{});

			m_mthResetAll();
			m_mthConstructDoc();
			m_mthShowPropertyList();
		}
		private void m_mthConstructDoc()
		{
			long lngRes = m_objDomain.m_lngConstructDoc(out this.m_objDoc);
			if(lngRes <=0)
			{
				MessageBox.Show(this,c_strMessageDBFail,c_strMessageBoxTitle);
				this.m_pnlBody.Enabled = false;
				this.m_pnlBottom.Enabled = false;
				return;
			}
		}
		#endregion

		#region 重置
		private void m_mthResetAll()
		{
			this.m_lsvProperty.Items.Clear();
			this.m_lsvValue.Items.Clear();

			this.m_txtPropertyName.Clear();
			this.m_txtPropertySummary.Clear();
			this.m_txtValue.Clear();

			this.m_btnDeleteProperty.Text = "删除";
			this.m_btnDeleteValue.Text = "删除";

			this.m_txtPropertyName.ReadOnly = true;
			this.m_txtPropertySummary.ReadOnly = true;
			this.m_txtValue.ReadOnly = true;

			this.m_btnNewProperty.Enabled = true;
			this.m_btnDeleteProperty.Enabled = false;
			this.m_btnEditProperty.Enabled = false;
			this.m_btnPriorityUp.Enabled = true;
			this.m_btnPriorityDown.Enabled = true;

			this.m_btnNewValue.Enabled = false;
			this.m_btnDeleteValue.Enabled = false;
			this.m_btnEditValue.Enabled = false;
			
			this.m_btnSave.Enabled = true;
		}
		private void m_mthResetProperty()
		{
			this.m_lsvValue.Items.Clear();
			this.m_txtValue.Clear();

			this.m_txtPropertyName.ReadOnly = true;
			this.m_txtPropertySummary.ReadOnly = true;
			this.m_txtValue.ReadOnly = true;

			this.m_btnNewProperty.Enabled = true;
			this.m_btnDeleteProperty.Enabled = true;
			this.m_btnEditProperty.Enabled = true;
			this.m_btnPriorityUp.Enabled = true;
			this.m_btnPriorityDown.Enabled = true;

			this.m_btnNewValue.Enabled = true;
			this.m_btnDeleteValue.Enabled = false;
			this.m_btnEditValue.Enabled = false;
		}
		private void m_mthResetValue()
		{
			this.m_txtValue.ReadOnly = true;
			this.m_btnNewValue.Enabled = true;
			this.m_btnDeleteValue.Enabled = true;
			this.m_btnEditValue.Enabled = true;

		}
		#endregion

		private void m_mthShowPropertyList()
		{
			this.m_lsvProperty.Items.Clear();
			if(m_objDoc == null)
			{
				return;
			}
			this.m_lsvProperty.BeginUpdate();
			foreach(clsApplyUnitProperty objProperty in m_objDoc.Properties)
			{
				if(objProperty.PropertyVO.m_intINUSE_FLAG_NUM == 0 && !this.m_chkShowPropertyDelete.Checked)
				{
					continue;
				}

				ListViewItem lvi = new ListViewItem();

				if(objProperty.PropertyVO.m_intINUSE_FLAG_NUM == 0)
					lvi.ForeColor = Color.Red;

				lvi.Text = objProperty.PropertyVO.m_strPROPERTY_NAME_VCHR;
				lvi.SubItems.Add(objProperty.PropertyVO.m_strSUMMARY_VCHR);
				lvi.Tag = objProperty;
				int intIdx = 0;
				if(objProperty.PropertyVO.m_intINUSE_FLAG_NUM == 0)
				{
					intIdx = this.m_lsvProperty.Items.Count;
				}
				else
				{
					for(int i=0;i<this.m_lsvProperty.Items.Count;i++)
					{
						clsApplyUnitProperty objP= (clsApplyUnitProperty)this.m_lsvProperty.Items[i].Tag;
						if(objP.PropertyVO.m_intINUSE_FLAG_NUM == 0)
						{
							intIdx = i;
							break;
						}
						if(objP.PropertyVO.m_intPROPERTY_PRIORITY_NUM > objProperty.PropertyVO.m_intPROPERTY_PRIORITY_NUM)
						{
							intIdx = i;
							break;
						}
						if(i+1 == this.m_lsvProperty.Items.Count)
						{
							intIdx = this.m_lsvProperty.Items.Count;
							break;
						}
					}
				}
				this.m_lsvProperty.Items.Insert(intIdx,lvi);
			}
			this.m_lsvProperty.EndUpdate();
		}

		private void m_mthShowValueList()
		{
			this.m_lsvValue.Items.Clear();
			if(this.m_lsvProperty.SelectedItems.Count == 0)
				return;

			clsApplyUnitProperty objProperty = (clsApplyUnitProperty)this.m_lsvProperty.SelectedItems[0].Tag;
			this.m_lsvValue.BeginUpdate();
			foreach(clsPropertyValue objValue in objProperty.Values)
			{
				if(objValue.ValueVO.m_intINUSE_FLAG_NUM == 0 && !this.m_chkShowDeleteValue.Checked)
				{
					continue;
				}

				ListViewItem lvi = new ListViewItem();

				if(objValue.ValueVO.m_intINUSE_FLAG_NUM == 0)
					lvi.ForeColor = Color.Red;

				lvi.Text = objValue.ValueVO.m_strVLAUE_VCHR;
				lvi.Tag = objValue;
				this.m_lsvValue.Items.Add(lvi);
			}
			this.m_lsvValue.EndUpdate();
		}


		private void m_lsvProperty_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.m_lsvProperty.SelectedItems.Count == 0)
				return;
			clsApplyUnitProperty objProperty = (clsApplyUnitProperty)this.m_lsvProperty.SelectedItems[0].Tag;
			this.m_txtPropertyName.Text = objProperty.PropertyVO.m_strPROPERTY_NAME_VCHR;
			this.m_txtPropertySummary.Text = objProperty.PropertyVO.m_strSUMMARY_VCHR;

			m_mthResetProperty();
			if(objProperty.PropertyVO.m_intINUSE_FLAG_NUM == 0)
			{
				this.m_btnDeleteProperty.Text = "起用";
				this.m_btnPriorityDown.Enabled = false;
				this.m_btnPriorityUp.Enabled = false;
			}
			else
			{
				this.m_btnDeleteProperty.Text = "删除";
				this.m_btnPriorityDown.Enabled = true;
				this.m_btnPriorityUp.Enabled = true;
			}
			m_mthShowValueList();
		}

		private void m_lsvValue_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.m_lsvValue.SelectedItems.Count == 0)
				return;
			clsPropertyValue objValue = (clsPropertyValue)this.m_lsvValue.SelectedItems[0].Tag;
			this.m_txtValue.Text = objValue.ValueVO.m_strVLAUE_VCHR;
			if(objValue.ValueVO.m_intINUSE_FLAG_NUM == 0)
				this.m_btnDeleteValue.Text = "起用";
			else
				this.m_btnDeleteValue.Text = "删除";
			m_mthResetValue();
		}

		private void m_lsvProperty_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(this.m_lsvProperty.FocusedItem != null)
				this.m_lsvProperty.FocusedItem.Selected = true;
		}

		private void m_lsvValue_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(this.m_lsvValue.FocusedItem != null)
				this.m_lsvValue.FocusedItem.Selected = true;
		}


		private void m_chkShowPropertyDelete_CheckedChanged(object sender, System.EventArgs e)
		{
			this.m_mthResetAll();
			this.m_mthShowPropertyList();
		}

		private void m_chkShowDeleteValue_CheckedChanged(object sender, System.EventArgs e)
		{
			this.m_mthResetProperty();
			this.m_mthShowValueList();
		}


		private void m_txtPropertyName_TextChanged(object sender, System.EventArgs e)
		{
			if(this.m_lsvProperty.SelectedItems.Count == 0)
				return;
			this.m_lsvProperty.SelectedItems[0].Text = this.m_txtPropertyName.Text;
			((clsApplyUnitProperty)this.m_lsvProperty.SelectedItems[0].Tag).PropertyVO.m_strPROPERTY_NAME_VCHR = this.m_txtPropertyName.Text;
		}

		private void m_txtPropertySummary_TextChanged(object sender, System.EventArgs e)
		{
			if(this.m_lsvProperty.SelectedItems.Count == 0)
				return;
			this.m_lsvProperty.SelectedItems[0].SubItems[1].Text = this.m_txtPropertySummary.Text;
			((clsApplyUnitProperty)this.m_lsvProperty.SelectedItems[0].Tag).PropertyVO.m_strSUMMARY_VCHR = this.m_txtPropertySummary.Text;

		}

		private void m_txtValue_TextChanged(object sender, System.EventArgs e)
		{
			if(this.m_lsvValue.SelectedItems.Count == 0)
				return;
			this.m_lsvValue.SelectedItems[0].Text = this.m_txtValue.Text;
			((clsPropertyValue)this.m_lsvValue.SelectedItems[0].Tag).ValueVO.m_strVLAUE_VCHR = this.m_txtValue.Text;

		}

		
		private void m_btnAddProperty_Click(object sender, System.EventArgs e)
		{
			clsApplyUnitProperty objPorperty = new clsApplyUnitProperty();
			objPorperty.PropertyVO = new clsUnitProperty_VO();
			objPorperty.State = enmRecordState.New;
			objPorperty.PropertyVO.m_intINUSE_FLAG_NUM = 1;

			int intIdx = this.m_intGetTheLastUsingIndex() + 1;
			ListViewItem lvi = new ListViewItem();
			lvi.Text = null;
			lvi.SubItems.Add("");
			lvi.Tag = objPorperty;
			this.m_lsvProperty.Items.Insert(intIdx,lvi);
			this.m_objDoc.Properties.Add(objPorperty);
			this.m_lsvProperty.SelectedItems.Clear();
			lvi.Selected = true;
			lvi.Focused = true;

			this.m_mthResetProperty();
			this.m_txtPropertyName.Clear();
			this.m_txtPropertySummary.Clear();
			this.m_txtPropertyName.ReadOnly = false;
			this.m_txtPropertySummary.ReadOnly = false;
			this.m_btnEditProperty.Enabled = false;
			this.m_txtPropertyName.Focus();
			this.m_btnDeleteProperty.Text = "删除";
			this.m_btnPriorityUp.Enabled = true;
			this.m_btnPriorityDown.Enabled = true;

			this.m_mthSortPriority();
		}

		private void m_btnDeleteProperty_Click(object sender, System.EventArgs e)
		{
			if(this.m_lsvProperty.SelectedItems.Count == 0)
				return;
			clsApplyUnitProperty objProperty = (clsApplyUnitProperty)this.m_lsvProperty.SelectedItems[0].Tag;

			if(this.m_btnDeleteProperty.Text == "删除")
			{
				if(objProperty.State == enmRecordState.New)
				{
					this.m_objDoc.Properties.Remove(objProperty);
					this.m_lsvProperty.SelectedItems[0].Remove();
					this.m_mthResetProperty();
				}
				else
				{
					objProperty.PropertyVO.m_intINUSE_FLAG_NUM = 0;
					objProperty.State = enmRecordState.Modify;
					if(this.m_chkShowPropertyDelete.Checked)
					{
						ListViewItem lvi = this.m_lsvProperty.SelectedItems[0];
						lvi.ForeColor = Color.Red;
						lvi.Remove();
						this.m_lsvProperty.Items.Add(lvi);
						lvi.Focused = true;

						this.m_btnDeleteProperty.Text = "起用";
						this.m_btnPriorityUp.Enabled = false;
						this.m_btnPriorityDown.Enabled = false;
						
					}
					else
					{
						this.m_lsvProperty.SelectedItems[0].Remove();
						this.m_mthResetProperty();
					}
				}
			}
			else
			{
				int intIdx = this.m_intGetTheLastUsingIndex() + 1;
				objProperty.PropertyVO.m_intINUSE_FLAG_NUM = 1;
				objProperty.State = enmRecordState.Modify;
				ListViewItem lvi = this.m_lsvProperty.SelectedItems[0];
				lvi.ForeColor = SystemColors.ControlText;
				lvi.Remove();
				this.m_lsvProperty.Items.Insert(intIdx,lvi);
				lvi.Focused = true;

				this.m_btnDeleteProperty.Text = "删除";
				this.m_btnPriorityUp.Enabled = true;
				this.m_btnPriorityDown.Enabled = true;
			}
			this.m_mthSortPriority();
		}

		private void m_btnEditProperty_Click(object sender, System.EventArgs e)
		{
			if(this.m_lsvProperty.SelectedItems.Count == 0)
				return;
			clsApplyUnitProperty objProperty = (clsApplyUnitProperty)this.m_lsvProperty.SelectedItems[0].Tag;

			if(objProperty.State == enmRecordState.Original)
			{
				objProperty.State = enmRecordState.Modify;
			}
			this.m_txtPropertyName.ReadOnly = false;
			this.m_txtPropertySummary.ReadOnly = false;
			this.m_btnEditProperty.Enabled = false;
			this.m_txtPropertyName.Focus();
		}


		private void m_btnNewValue_Click(object sender, System.EventArgs e)
		{
			if(this.m_lsvProperty.SelectedItems.Count == 0)
				return;
			clsPropertyValue objValue = new clsPropertyValue();
			objValue.ValueVO = new clsUnitPropertyValue_VO();
			objValue.State = enmRecordState.New;
			objValue.ValueVO.m_intINUSE_FLAG_NUM = 1;
			objValue.ValueVO.m_strPROPERTY_ID_CHR = ((clsApplyUnitProperty)this.m_lsvProperty.SelectedItems[0].Tag).PropertyVO.m_strPROPERTY_ID_CHR;
			((clsApplyUnitProperty)this.m_lsvProperty.SelectedItems[0].Tag).Values.Add(objValue);

			ListViewItem lvi = new ListViewItem();
			lvi.Text = null;
			lvi.Tag = objValue;
			this.m_lsvValue.Items.Add(lvi);
			this.m_lsvValue.SelectedItems.Clear();
			lvi.Selected = true;

			this.m_mthResetValue();
			this.m_txtValue.Clear();
			this.m_txtValue.ReadOnly = false;
			this.m_btnEditValue.Enabled = false;
			this.m_txtValue.Focus();

			this.m_btnDeleteValue.Text = "删除";
		}

		private void m_btnDeleteValue_Click(object sender, System.EventArgs e)
		{
			if(this.m_lsvValue.SelectedItems.Count == 0 
				||this.m_lsvProperty.SelectedItems.Count == 0)
				return;
			clsPropertyValue objValue = (clsPropertyValue)this.m_lsvValue.SelectedItems[0].Tag;
			clsApplyUnitProperty objProperty = (clsApplyUnitProperty)this.m_lsvProperty.SelectedItems[0].Tag;

			if(this.m_btnDeleteValue.Text == "删除")
			{
				if(objValue.State == enmRecordState.New)
				{
					objProperty.Values.Remove(objProperty);
					this.m_lsvValue.SelectedItems[0].Remove();
					this.m_mthResetValue();
				}
				else
				{
					objValue.ValueVO.m_intINUSE_FLAG_NUM = 0;
					objValue.State = enmRecordState.Modify;
					if(this.m_chkShowDeleteValue.Checked)
					{
						this.m_lsvValue.SelectedItems[0].ForeColor = Color.Red;
						this.m_btnDeleteValue.Text = "起用";
					}
					else
					{
						this.m_lsvValue.SelectedItems[0].Remove();
						this.m_mthResetValue();
					}
				}
			}
			else
			{
				objValue.ValueVO.m_intINUSE_FLAG_NUM = 1;
				objValue.State = enmRecordState.Modify;
				this.m_btnDeleteValue.Text = "删除";
				this.m_lsvValue.SelectedItems[0].ForeColor = SystemColors.ControlText;
			}
		}

		private void m_btnEditValue_Click(object sender, System.EventArgs e)
		{
			if(this.m_lsvValue.SelectedItems.Count == 0)
				return;
			clsPropertyValue objValue = (clsPropertyValue)this.m_lsvValue.SelectedItems[0].Tag;

			if(objValue.State == enmRecordState.Original)
			{
				objValue.State = enmRecordState.Modify;
			}
			this.m_txtValue.ReadOnly = false;
			this.m_btnEditValue.Enabled = false;
			this.m_txtValue.Focus();
		}


		private void m_btnPriorityUp_Click(object sender, System.EventArgs e)
		{
			if(this.m_lsvProperty.SelectedItems.Count == 0)
				return;
			if(this.m_lsvProperty.SelectedItems[0].Index == 0)
				return;
			ListViewItem lvi = this.m_lsvProperty.SelectedItems[0];
			int intIdx = lvi.Index -1;
			lvi.Remove();
			this.m_lsvProperty.Items.Insert(intIdx,lvi);
			lvi.Focused = true;
			this.m_mthSortPriority();
		}

		private void m_btnPriorityDown_Click(object sender, System.EventArgs e)
		{
			if(this.m_lsvProperty.SelectedItems.Count == 0)
				return;

			ListViewItem lvi = this.m_lsvProperty.SelectedItems[0];
			int intIdx = lvi.Index + 1;
			if(intIdx  == this.m_lsvProperty.Items.Count)
				return;
			clsApplyUnitProperty objNext = (clsApplyUnitProperty)this.m_lsvProperty.Items[intIdx].Tag;
			if(objNext.PropertyVO.m_intINUSE_FLAG_NUM == 0)
				return;

			lvi.Remove();
			this.m_lsvProperty.Items.Insert(intIdx,lvi);
			lvi.Focused = true;
			this.m_mthSortPriority();
		}


		private void m_btnSave_Click(object sender, System.EventArgs e)
		{
			m_mthSortPriority();
			long lngRes = m_objDomain.m_lngSave(this.m_objDoc);
			if(lngRes <= 0)
			{
				MessageBox.Show(this,c_strMessageDBFail,c_strMessageBoxTitle);
			}
			else
			{
				foreach(clsApplyUnitProperty objProperty in this.m_objDoc.Properties)
				{
					objProperty.State = enmRecordState.Original;
					foreach(clsPropertyValue objValue in objProperty.Values)
					{
						objValue.State = enmRecordState.Original;
					}
				}
				this.m_mthResetProperty();
				this.m_lsvProperty_SelectedIndexChanged(null,null);
			}
		}



		private void m_txtValue_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				this.m_btnNewValue_Click(null,null);
			}
		}

		private void m_txtPropertySummary_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				this.m_btnAddProperty_Click(null,null);
			}
		}
		private void m_txtPropertyName_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				this.m_txtPropertySummary.Focus();
			}
		}



		private void m_mthSortPriority()
		{
			foreach(ListViewItem lvt in this.m_lsvProperty.Items)
			{
				clsApplyUnitProperty objProperty = (clsApplyUnitProperty)lvt.Tag;
				if(objProperty.PropertyVO.m_intINUSE_FLAG_NUM == 0)
					break;
				int intIdx = lvt.Index;
				if(objProperty.PropertyVO.m_intPROPERTY_PRIORITY_NUM != intIdx)
				{
					objProperty.PropertyVO.m_intPROPERTY_PRIORITY_NUM = intIdx;
					if(objProperty.State == enmRecordState.Original)
					{
						objProperty.State = enmRecordState.Modify;
					}
				}
			}
		}

		private int m_intGetTheLastUsingIndex()
		{
			for(int i=0;i<this.m_lsvProperty.Items.Count;i++)
			{
				clsApplyUnitProperty objProperty = (clsApplyUnitProperty)this.m_lsvProperty.Items[i].Tag;
				if(objProperty.PropertyVO.m_intINUSE_FLAG_NUM == 0)
					return i-1;
			}
			return this.m_lsvProperty.Items.Count -1;
		}

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


	}	
}
