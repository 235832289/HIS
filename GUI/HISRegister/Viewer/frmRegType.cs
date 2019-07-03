using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmRegType 的摘要说明。
	/// </summary>
	public class frmRegType : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private System.Windows.Forms.Panel m_pnlList;
		private System.Windows.Forms.Panel m_pnlButton;
		private System.Windows.Forms.Label m_lblName;
		private PinkieControls.ButtonXP m_btnNew;
		private PinkieControls.ButtonXP m_btnSave;
		private PinkieControls.ButtonXP m_btnDelete;
		private PinkieControls.ButtonXP m_btnExit;
		internal System.Windows.Forms.ListView m_lvw;
		private System.Windows.Forms.ColumnHeader colRegType;
		private System.Windows.Forms.ColumnHeader colReg;
		private System.Windows.Forms.ColumnHeader colRegTYPEID;
		private System.Windows.Forms.ColumnHeader colUrgency;

		private System.Windows.Forms.ColumnHeader colRegMemo;
		private System.Windows.Forms.Label m_lblMemo;
		internal System.Windows.Forms.TextBox m_txtMemo;
		internal PinkieControls.ButtonXP m_btnStopUse;
		internal System.Windows.Forms.Label m_lblIsStopUse;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		internal System.Windows.Forms.RadioButton ra3;
		internal System.Windows.Forms.RadioButton ra2;
		internal System.Windows.Forms.RadioButton ra1;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtName;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtREGISTERTYPENO_VCHR;
		internal System.Windows.Forms.CheckBox m_chkEmergency;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmRegType()
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
			this.m_pnlList = new System.Windows.Forms.Panel();
			this.m_lvw = new System.Windows.Forms.ListView();
			this.colReg = new System.Windows.Forms.ColumnHeader();
			this.colRegTYPEID = new System.Windows.Forms.ColumnHeader();
			this.colRegType = new System.Windows.Forms.ColumnHeader();
			this.colRegMemo = new System.Windows.Forms.ColumnHeader();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.colUrgency = new System.Windows.Forms.ColumnHeader();
			this.m_pnlButton = new System.Windows.Forms.Panel();
			this.m_chkEmergency = new System.Windows.Forms.CheckBox();
			this.m_txtREGISTERTYPENO_VCHR = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.m_txtName = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.ra3 = new System.Windows.Forms.RadioButton();
			this.ra2 = new System.Windows.Forms.RadioButton();
			this.ra1 = new System.Windows.Forms.RadioButton();
			this.m_lblIsStopUse = new System.Windows.Forms.Label();
			this.m_btnStopUse = new PinkieControls.ButtonXP();
			this.m_txtMemo = new System.Windows.Forms.TextBox();
			this.m_lblMemo = new System.Windows.Forms.Label();
			this.m_btnExit = new PinkieControls.ButtonXP();
			this.m_btnDelete = new PinkieControls.ButtonXP();
			this.m_btnSave = new PinkieControls.ButtonXP();
			this.m_btnNew = new PinkieControls.ButtonXP();
			this.m_lblName = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.m_pnlList.SuspendLayout();
			this.m_pnlButton.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_pnlList
			// 
			this.m_pnlList.Controls.Add(this.m_lvw);
			this.m_pnlList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_pnlList.Location = new System.Drawing.Point(0, 0);
			this.m_pnlList.Name = "m_pnlList";
			this.m_pnlList.Size = new System.Drawing.Size(754, 463);
			this.m_pnlList.TabIndex = 0;
			// 
			// m_lvw
			// 
			this.m_lvw.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					this.colReg,
																					this.colRegTYPEID,
																					this.colRegType,
																					this.colRegMemo,
																					this.columnHeader1,
																					this.columnHeader2,
																					this.columnHeader3,
																					this.colUrgency});
			this.m_lvw.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_lvw.FullRowSelect = true;
			this.m_lvw.GridLines = true;
			this.m_lvw.HideSelection = false;
			this.m_lvw.Location = new System.Drawing.Point(0, 0);
			this.m_lvw.MultiSelect = false;
			this.m_lvw.Name = "m_lvw";
			this.m_lvw.Size = new System.Drawing.Size(754, 463);
			this.m_lvw.TabIndex = 63;
			this.m_lvw.View = System.Windows.Forms.View.Details;
			this.m_lvw.Click += new System.EventHandler(this.m_lvw_SelectedIndexChanged);
			this.m_lvw.SelectedIndexChanged += new System.EventHandler(this.m_lvw_SelectedIndexChanged);
			// 
			// colReg
			// 
			this.colReg.Text = "";
			this.colReg.Width = 0;
			// 
			// colRegTYPEID
			// 
			this.colRegTYPEID.Text = "编号";
			this.colRegTYPEID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.colRegTYPEID.Width = 91;
			// 
			// colRegType
			// 
			this.colRegType.Text = "挂号种类";
			this.colRegType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.colRegType.Width = 102;
			// 
			// colRegMemo
			// 
			this.colRegMemo.Text = "备注";
			this.colRegMemo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.colRegMemo.Width = 121;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "挂号类型编号";
			this.columnHeader1.Width = 126;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "状态";
			this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader2.Width = 0;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "医生";
			this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader3.Width = 0;
			// 
			// colUrgency
			// 
			this.colUrgency.Text = "是否急诊";
			this.colUrgency.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.colUrgency.Width = 80;
			// 
			// m_pnlButton
			// 
			this.m_pnlButton.Controls.Add(this.m_chkEmergency);
			this.m_pnlButton.Controls.Add(this.m_txtREGISTERTYPENO_VCHR);
			this.m_pnlButton.Controls.Add(this.m_txtName);
			this.m_pnlButton.Controls.Add(this.groupBox1);
			this.m_pnlButton.Controls.Add(this.m_lblIsStopUse);
			this.m_pnlButton.Controls.Add(this.m_btnStopUse);
			this.m_pnlButton.Controls.Add(this.m_txtMemo);
			this.m_pnlButton.Controls.Add(this.m_lblMemo);
			this.m_pnlButton.Controls.Add(this.m_btnExit);
			this.m_pnlButton.Controls.Add(this.m_btnDelete);
			this.m_pnlButton.Controls.Add(this.m_btnSave);
			this.m_pnlButton.Controls.Add(this.m_btnNew);
			this.m_pnlButton.Controls.Add(this.m_lblName);
			this.m_pnlButton.Controls.Add(this.label1);
			this.m_pnlButton.Dock = System.Windows.Forms.DockStyle.Right;
			this.m_pnlButton.Location = new System.Drawing.Point(530, 0);
			this.m_pnlButton.Name = "m_pnlButton";
			this.m_pnlButton.Size = new System.Drawing.Size(224, 463);
			this.m_pnlButton.TabIndex = 1;
			// 
			// m_chkEmergency
			// 
			this.m_chkEmergency.Location = new System.Drawing.Point(116, 216);
			this.m_chkEmergency.Name = "m_chkEmergency";
			this.m_chkEmergency.Size = new System.Drawing.Size(56, 24);
			this.m_chkEmergency.TabIndex = 18;
			this.m_chkEmergency.Text = "急诊";
			this.m_chkEmergency.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_chkEmergency_KeyDown);
			// 
			// m_txtREGISTERTYPENO_VCHR
			// 
			this.m_txtREGISTERTYPENO_VCHR.EnableAutoValidation = true;
			this.m_txtREGISTERTYPENO_VCHR.EnableEnterKeyValidate = true;
			this.m_txtREGISTERTYPENO_VCHR.EnableEscapeKeyUndo = true;
			this.m_txtREGISTERTYPENO_VCHR.EnableLastValidValue = true;
			this.m_txtREGISTERTYPENO_VCHR.ErrorProvider = null;
			this.m_txtREGISTERTYPENO_VCHR.ErrorProviderMessage = "Invalid value";
			this.m_txtREGISTERTYPENO_VCHR.ForceFormatText = true;
			this.m_txtREGISTERTYPENO_VCHR.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.m_txtREGISTERTYPENO_VCHR.Location = new System.Drawing.Point(80, 124);
			this.m_txtREGISTERTYPENO_VCHR.MaxLength = 4;
			this.m_txtREGISTERTYPENO_VCHR.Name = "m_txtREGISTERTYPENO_VCHR";
			this.m_txtREGISTERTYPENO_VCHR.Size = new System.Drawing.Size(128, 23);
			this.m_txtREGISTERTYPENO_VCHR.TabIndex = 17;
			this.m_txtREGISTERTYPENO_VCHR.Text = "";
			this.m_txtREGISTERTYPENO_VCHR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtREGISTERTYPENO_VCHR_KeyDown);
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
			this.m_txtName.Location = new System.Drawing.Point(80, 44);
			this.m_txtName.MaxLength = 20;
			this.m_txtName.Name = "m_txtName";
			this.m_txtName.Size = new System.Drawing.Size(128, 23);
			this.m_txtName.TabIndex = 0;
			this.m_txtName.Text = "";
			this.m_txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtName_KeyDown);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.ra3);
			this.groupBox1.Controls.Add(this.ra2);
			this.groupBox1.Controls.Add(this.ra1);
			this.groupBox1.Location = new System.Drawing.Point(24, 164);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(192, 48);
			this.groupBox1.TabIndex = 15;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "医生:";
			// 
			// ra3
			// 
			this.ra3.Location = new System.Drawing.Point(132, 20);
			this.ra3.Name = "ra3";
			this.ra3.Size = new System.Drawing.Size(56, 24);
			this.ra3.TabIndex = 2;
			this.ra3.Text = "必需";
			this.ra3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.ra3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ra3_KeyDown);
			// 
			// ra2
			// 
			this.ra2.Location = new System.Drawing.Point(72, 20);
			this.ra2.Name = "ra2";
			this.ra2.Size = new System.Drawing.Size(52, 24);
			this.ra2.TabIndex = 1;
			this.ra2.Text = "不需";
			this.ra2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.ra2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ra2_KeyDown);
			// 
			// ra1
			// 
			this.ra1.Location = new System.Drawing.Point(16, 20);
			this.ra1.Name = "ra1";
			this.ra1.Size = new System.Drawing.Size(52, 24);
			this.ra1.TabIndex = 0;
			this.ra1.Text = "可有";
			this.ra1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.ra1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ra1_KeyDown);
			// 
			// m_lblIsStopUse
			// 
			this.m_lblIsStopUse.Location = new System.Drawing.Point(80, 12);
			this.m_lblIsStopUse.Name = "m_lblIsStopUse";
			this.m_lblIsStopUse.Size = new System.Drawing.Size(128, 23);
			this.m_lblIsStopUse.TabIndex = 14;
			this.m_lblIsStopUse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_btnStopUse
			// 
			this.m_btnStopUse.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnStopUse.DefaultScheme = true;
			this.m_btnStopUse.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnStopUse.Hint = "";
			this.m_btnStopUse.Location = new System.Drawing.Point(84, 328);
			this.m_btnStopUse.Name = "m_btnStopUse";
			this.m_btnStopUse.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnStopUse.Size = new System.Drawing.Size(128, 32);
			this.m_btnStopUse.TabIndex = 13;
			this.m_btnStopUse.Text = "停用";
			this.m_btnStopUse.Click += new System.EventHandler(this.m_btnStopUse_Click);
			// 
			// m_txtMemo
			// 
			this.m_txtMemo.Location = new System.Drawing.Point(80, 84);
			this.m_txtMemo.MaxLength = 100;
			this.m_txtMemo.Name = "m_txtMemo";
			this.m_txtMemo.Size = new System.Drawing.Size(128, 23);
			this.m_txtMemo.TabIndex = 2;
			this.m_txtMemo.Text = "";
			this.m_txtMemo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtMemo_KeyDown);
			// 
			// m_lblMemo
			// 
			this.m_lblMemo.Location = new System.Drawing.Point(32, 92);
			this.m_lblMemo.Name = "m_lblMemo";
			this.m_lblMemo.Size = new System.Drawing.Size(48, 16);
			this.m_lblMemo.TabIndex = 12;
			this.m_lblMemo.Text = "备注：";
			// 
			// m_btnExit
			// 
			this.m_btnExit.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnExit.DefaultScheme = true;
			this.m_btnExit.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnExit.Hint = "";
			this.m_btnExit.Location = new System.Drawing.Point(84, 408);
			this.m_btnExit.Name = "m_btnExit";
			this.m_btnExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnExit.Size = new System.Drawing.Size(128, 32);
			this.m_btnExit.TabIndex = 9;
			this.m_btnExit.Text = "退出(Esc)";
			this.m_btnExit.Click += new System.EventHandler(this.m_btnExit_Click);
			// 
			// m_btnDelete
			// 
			this.m_btnDelete.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnDelete.DefaultScheme = true;
			this.m_btnDelete.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnDelete.Hint = "";
			this.m_btnDelete.Location = new System.Drawing.Point(84, 368);
			this.m_btnDelete.Name = "m_btnDelete";
			this.m_btnDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnDelete.Size = new System.Drawing.Size(128, 32);
			this.m_btnDelete.TabIndex = 8;
			this.m_btnDelete.Text = "删除(&D)";
			this.m_btnDelete.Click += new System.EventHandler(this.m_btnDelete_Click);
			// 
			// m_btnSave
			// 
			this.m_btnSave.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnSave.DefaultScheme = true;
			this.m_btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnSave.Hint = "";
			this.m_btnSave.Location = new System.Drawing.Point(84, 288);
			this.m_btnSave.Name = "m_btnSave";
			this.m_btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnSave.Size = new System.Drawing.Size(128, 32);
			this.m_btnSave.TabIndex = 7;
			this.m_btnSave.Text = "保存(&S)";
			this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
			// 
			// m_btnNew
			// 
			this.m_btnNew.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnNew.DefaultScheme = true;
			this.m_btnNew.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnNew.Hint = "";
			this.m_btnNew.Location = new System.Drawing.Point(84, 248);
			this.m_btnNew.Name = "m_btnNew";
			this.m_btnNew.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnNew.Size = new System.Drawing.Size(128, 32);
			this.m_btnNew.TabIndex = 6;
			this.m_btnNew.Text = "新增(&A)";
			this.m_btnNew.Click += new System.EventHandler(this.m_btnNew_Click);
			// 
			// m_lblName
			// 
			this.m_lblName.Location = new System.Drawing.Point(32, 52);
			this.m_lblName.Name = "m_lblName";
			this.m_lblName.Size = new System.Drawing.Size(48, 16);
			this.m_lblName.TabIndex = 0;
			this.m_lblName.Text = "名称：";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 132);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 16);
			this.label1.TabIndex = 12;
			this.label1.Text = "编号：";
			// 
			// frmRegType
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(754, 463);
			this.Controls.Add(this.m_pnlButton);
			this.Controls.Add(this.m_pnlList);
			this.Font = new System.Drawing.Font("宋体", 10.5F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(500, 360);
			this.Name = "frmRegType";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "挂号种类";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRegType_KeyDown);
			this.Load += new System.EventHandler(this.frmRegType_Load);
			this.m_pnlList.ResumeLayout(false);
			this.m_pnlButton.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override void CreateController()
		{
			this.objController=new com.digitalwave.iCare.gui.HIS.clsControlRegType();
			this.objController.Set_GUI_Apperance(this);
		}

		public override void Show_MDI_Child(Form frmMDI_Parent)
		{
			this.ShowDialog();
		}

		private void frmRegType_Load(object sender, System.EventArgs e)
		{
				((clsControlRegType)this.objController).m_GetRegType();		
		}

		private void m_btnExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void m_btnSave_Click(object sender, System.EventArgs e)
		{
			((clsControlRegType)this.objController).m_lngSave();
		}

		private void m_btnNew_Click(object sender, System.EventArgs e)
		{
			m_txtName.Text = "";
			m_txtMemo.Text = "";
			m_txtREGISTERTYPENO_VCHR.Text = "";
			m_lblIsStopUse.Text="正常";
			ra1.Checked = true;
			m_txtName.Tag = null;
			m_txtName.Focus();
			
		}

		private void m_btnCancel_Click(object sender, System.EventArgs e)
		{
			this.frmRegType_Load(this, null);
		}

		private void m_btnDelete_Click(object sender, System.EventArgs e)
		{
			((clsControlRegType)this.objController).m_Delete();

		}

		private void m_lvw_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (m_lvw.SelectedIndices.Count > 0)
			{
				m_txtName.Text = m_lvw.SelectedItems[0].SubItems[2].Text;
				m_txtMemo.Text = m_lvw.SelectedItems[0].SubItems[3].Text;
				m_txtREGISTERTYPENO_VCHR.Text = m_lvw.SelectedItems[0].SubItems[4].Text;
				
				m_txtName.Tag = m_lvw.SelectedItems[0].Tag;

				if(m_lvw.SelectedItems[0].SubItems[5].Text.Trim()=="0")	
				{
					m_lblIsStopUse.Text="已停用";
					m_btnStopUse.Text ="恢复";
					m_btnStopUse.Tag = "1";

				}
				else if(m_lvw.SelectedItems[0].SubItems[5].Text.Trim()=="1")
				{
					m_lblIsStopUse.Text="正常";
					m_btnStopUse.Text ="停用";
					m_btnStopUse.Tag = "0";
				}
					
				if(m_lvw.SelectedItems[0].SubItems[6].Text.Trim()=="0")
					ra1.Checked = true;
				else if (m_lvw.SelectedItems[0].SubItems[6].Text.Trim()=="1")
					ra2.Checked = true;
				else if(m_lvw.SelectedItems[0].SubItems[6].Text.Trim()=="2")
					ra3.Checked = true;
				if(m_lvw.SelectedItems[0].SubItems[7].Text.Trim()=="否")//xigui.peng添加
					m_chkEmergency.Checked = false;               
				else
					m_chkEmergency.Checked=true;


			}
		}

		private void m_btnStopUse_Click(object sender, System.EventArgs e)
		{
			((clsControlRegType)this.objController).m_mthIsUseing();
		}

		private void frmRegType_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Escape)
			{
				if(MessageBox.Show("确认退出吗?","iCare",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
					return;
				m_btnExit_Click(sender,e);

			}
		}

		private void m_txtName_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
				m_txtMemo.Focus();
		}

		private void m_txtMemo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
				m_txtREGISTERTYPENO_VCHR.Focus();
		}

		private void m_txtREGISTERTYPENO_VCHR_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
				ra1.Focus();
		}

		private void ra2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
				ra3.Focus();
		}

		private void ra1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
				ra2.Focus();
		}

		private void ra3_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
				m_chkEmergency.Focus();
		}

		private void m_chkEmergency_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				if(this.m_chkEmergency.Checked==true)
					this.m_chkEmergency.Checked=false;
				else 
					this.m_chkEmergency.Checked=true;
				m_btnNew.Focus();
			}
		}



	}
}
