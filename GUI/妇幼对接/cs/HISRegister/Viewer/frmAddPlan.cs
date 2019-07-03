using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using System.Data;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmAddPlan 的摘要说明。
	/// </summary>
	public class frmAddPlan :com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private System.Windows.Forms.Splitter splitter1;
		protected internal System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		internal System.Windows.Forms.TreeView m_TVDep;
		internal System.Windows.Forms.ListView m_lvwDoc;
		internal System.Windows.Forms.Panel m_Panel;
		internal System.Windows.Forms.DateTimePicker m_DtpStart;
		internal System.Windows.Forms.DateTimePicker m_DtpEnd;
		internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric m_txtNum;
		internal System.Windows.Forms.TextBox m_txtRoom;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		internal System.Windows.Forms.ErrorProvider errorProvider1;
		internal System.Windows.Forms.ComboBox m_cboRegType;
		internal System.Windows.Forms.ComboBox m_cboPerio;
		private PinkieControls.ButtonXP m_btnClear;
		private PinkieControls.ButtonXP m_btnSave;
		private PinkieControls.ButtonXP m_btnSR;
		internal System.Windows.Forms.Label label8;
		internal System.Windows.Forms.TextBox m_txtDoc;
		internal System.Windows.Forms.TextBox txtOpdt;
		internal System.Windows.Forms.TreeView m_treelisv;
		internal System.Windows.Forms.ListView LisDep;
		private System.Windows.Forms.ColumnHeader DEPTNAME_VCHR;
		internal System.Windows.Forms.ListView ListDor;
		private System.Windows.Forms.ColumnHeader SHORTNO_CHR;
		private System.Windows.Forms.ColumnHeader EMPNO_CHR;
		private System.Windows.Forms.ColumnHeader LASTNAME_VCHR;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmAddPlan()
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
			this.m_lvwDoc = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.m_TVDep = new System.Windows.Forms.TreeView();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.m_DtpStart = new System.Windows.Forms.DateTimePicker();
			this.m_DtpEnd = new System.Windows.Forms.DateTimePicker();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.m_txtRoom = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.m_txtNum = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
			this.m_btnClear = new PinkieControls.ButtonXP();
			this.m_btnSave = new PinkieControls.ButtonXP();
			this.m_btnSR = new PinkieControls.ButtonXP();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider();
			this.m_cboRegType = new System.Windows.Forms.ComboBox();
			this.m_cboPerio = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.m_txtDoc = new System.Windows.Forms.TextBox();
			this.txtOpdt = new System.Windows.Forms.TextBox();
			this.m_treelisv = new System.Windows.Forms.TreeView();
			this.LisDep = new System.Windows.Forms.ListView();
			this.SHORTNO_CHR = new System.Windows.Forms.ColumnHeader();
			this.DEPTNAME_VCHR = new System.Windows.Forms.ColumnHeader();
			this.ListDor = new System.Windows.Forms.ListView();
			this.EMPNO_CHR = new System.Windows.Forms.ColumnHeader();
			this.LASTNAME_VCHR = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// m_lvwDoc
			// 
			this.m_lvwDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_lvwDoc.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					   this.columnHeader1,
																					   this.columnHeader2});
			this.m_lvwDoc.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_lvwDoc.FullRowSelect = true;
			this.m_lvwDoc.GridLines = true;
			this.m_lvwDoc.Location = new System.Drawing.Point(139, 0);
			this.m_lvwDoc.MultiSelect = false;
			this.m_lvwDoc.Name = "m_lvwDoc";
			this.m_lvwDoc.Size = new System.Drawing.Size(189, 176);
			this.m_lvwDoc.TabIndex = 23;
			this.m_lvwDoc.View = System.Windows.Forms.View.Details;
			this.m_lvwDoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_lvwDoc_KeyDown);
			this.m_lvwDoc.Click += new System.EventHandler(this.m_lvwDoc_Click);
			this.m_lvwDoc.Leave += new System.EventHandler(this.m_lvwDoc_Leave);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "医生编号";
			this.columnHeader1.Width = 82;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "医生姓名";
			this.columnHeader2.Width = 101;
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(136, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 176);
			this.splitter1.TabIndex = 1;
			this.splitter1.TabStop = false;
			// 
			// m_TVDep
			// 
			this.m_TVDep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_TVDep.Dock = System.Windows.Forms.DockStyle.Left;
			this.m_TVDep.ImageIndex = -1;
			this.m_TVDep.Location = new System.Drawing.Point(0, 0);
			this.m_TVDep.Name = "m_TVDep";
			this.m_TVDep.SelectedImageIndex = -1;
			this.m_TVDep.Size = new System.Drawing.Size(136, 176);
			this.m_TVDep.TabIndex = 20;
			this.m_TVDep.TabStop = false;
			this.m_TVDep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_TVDep_KeyDown);
			this.m_TVDep.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_TVDep_AfterSelect);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(224, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(63, 19);
			this.label1.TabIndex = 1;
			this.label1.Text = "医    生";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(24, 49);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 19);
			this.label2.TabIndex = 3;
			this.label2.Text = "门诊类型";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(224, 49);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(63, 19);
			this.label3.TabIndex = 5;
			this.label3.Text = "时 间 段";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(24, 87);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(63, 19);
			this.label4.TabIndex = 7;
			this.label4.Text = "开诊时间";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_DtpStart
			// 
			this.m_DtpStart.CustomFormat = "HH:mm";
			this.m_DtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.m_DtpStart.Location = new System.Drawing.Point(88, 85);
			this.m_DtpStart.Name = "m_DtpStart";
			this.m_DtpStart.ShowUpDown = true;
			this.m_DtpStart.Size = new System.Drawing.Size(104, 23);
			this.m_DtpStart.TabIndex = 33;
			this.m_DtpStart.TabStop = false;
			this.m_DtpStart.ValueChanged += new System.EventHandler(this.m_DtpStart_ValueChanged);
			// 
			// m_DtpEnd
			// 
			this.m_DtpEnd.CustomFormat = "HH:mm";
			this.m_DtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.m_DtpEnd.Location = new System.Drawing.Point(288, 85);
			this.m_DtpEnd.Name = "m_DtpEnd";
			this.m_DtpEnd.ShowUpDown = true;
			this.m_DtpEnd.Size = new System.Drawing.Size(104, 23);
			this.m_DtpEnd.TabIndex = 38;
			this.m_DtpEnd.TabStop = false;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(224, 87);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(63, 19);
			this.label5.TabIndex = 9;
			this.label5.Text = "结束时间";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(224, 126);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(63, 19);
			this.label6.TabIndex = 11;
			this.label6.Text = "坐诊诊间";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_txtRoom
			// 
			this.m_txtRoom.Location = new System.Drawing.Point(288, 124);
			this.m_txtRoom.Name = "m_txtRoom";
			this.m_txtRoom.Size = new System.Drawing.Size(104, 23);
			this.m_txtRoom.TabIndex = 16;
			this.m_txtRoom.Text = "";
			this.m_txtRoom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtRoom_KeyDown);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(24, 126);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(63, 19);
			this.label7.TabIndex = 13;
			this.label7.Text = "限    号";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_txtNum
			// 
			this.m_txtNum.EnableAutoValidation = true;
			this.m_txtNum.EnableEnterKeyValidate = true;
			this.m_txtNum.EnableEscapeKeyUndo = true;
			this.m_txtNum.EnableLastValidValue = true;
			this.m_txtNum.ErrorProvider = null;
			this.m_txtNum.ErrorProviderMessage = "Invalid value";
			this.m_txtNum.ForceFormatText = true;
			this.m_txtNum.Location = new System.Drawing.Point(88, 124);
			this.m_txtNum.Name = "m_txtNum";
			this.m_txtNum.NumericCharStyle = SourceLibrary.Windows.Forms.NumericCharStyle.PositiveSymbol;
			this.m_txtNum.Size = new System.Drawing.Size(104, 23);
			this.m_txtNum.TabIndex = 15;
			this.m_txtNum.Text = "";
			this.m_txtNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.m_txtNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtNum_KeyDown);
			// 
			// m_btnClear
			// 
			this.m_btnClear.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnClear.DefaultScheme = true;
			this.m_btnClear.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnClear.Hint = "";
			this.m_btnClear.Location = new System.Drawing.Point(72, 160);
			this.m_btnClear.Name = "m_btnClear";
			this.m_btnClear.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnClear.Size = new System.Drawing.Size(76, 32);
			this.m_btnClear.TabIndex = 19;
			this.m_btnClear.Text = "清空(&C)";
			this.m_btnClear.Click += new System.EventHandler(this.m_btnClear_Click);
			// 
			// m_btnSave
			// 
			this.m_btnSave.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnSave.DefaultScheme = true;
			this.m_btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnSave.Hint = "";
			this.m_btnSave.Location = new System.Drawing.Point(164, 160);
			this.m_btnSave.Name = "m_btnSave";
			this.m_btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnSave.Size = new System.Drawing.Size(76, 32);
			this.m_btnSave.TabIndex = 17;
			this.m_btnSave.Text = "保存(&S)";
			this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
			// 
			// m_btnSR
			// 
			this.m_btnSR.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnSR.DefaultScheme = true;
			this.m_btnSR.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnSR.Hint = "";
			this.m_btnSR.Location = new System.Drawing.Point(264, 160);
			this.m_btnSR.Name = "m_btnSR";
			this.m_btnSR.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnSR.Size = new System.Drawing.Size(112, 32);
			this.m_btnSR.TabIndex = 18;
			this.m_btnSR.Text = "保存并返回(&R)";
			this.m_btnSR.Click += new System.EventHandler(this.m_btnSR_Click);
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			// 
			// m_cboRegType
			// 
			this.m_cboRegType.ItemHeight = 14;
			this.m_cboRegType.Location = new System.Drawing.Point(88, 47);
			this.m_cboRegType.Name = "m_cboRegType";
			this.m_cboRegType.Size = new System.Drawing.Size(104, 22);
			this.m_cboRegType.TabIndex = 13;
			this.m_cboRegType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cboRegType_KeyDown);
			this.m_cboRegType.SelectedIndexChanged += new System.EventHandler(this.m_cboRegType_SelectedIndexChanged);
			// 
			// m_cboPerio
			// 
			this.m_cboPerio.ItemHeight = 14;
			this.m_cboPerio.Location = new System.Drawing.Point(288, 47);
			this.m_cboPerio.Name = "m_cboPerio";
			this.m_cboPerio.Size = new System.Drawing.Size(104, 22);
			this.m_cboPerio.TabIndex = 14;
			this.m_cboPerio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cboPerio_KeyDown);
			this.m_cboPerio.SelectedIndexChanged += new System.EventHandler(this.m_cboPerio_SelectedIndexChanged);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label8.Location = new System.Drawing.Point(24, 10);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(63, 19);
			this.label8.TabIndex = 27;
			this.label8.Text = "门诊科室";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_txtDoc
			// 
			this.m_txtDoc.Location = new System.Drawing.Point(288, 8);
			this.m_txtDoc.Name = "m_txtDoc";
			this.m_txtDoc.Size = new System.Drawing.Size(104, 23);
			this.m_txtDoc.TabIndex = 11;
			this.m_txtDoc.Text = "";
			this.m_txtDoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtDoc_KeyDown_1);
			this.m_txtDoc.TextChanged += new System.EventHandler(this.m_txtDoc_TextChanged);
			this.m_txtDoc.Leave += new System.EventHandler(this.m_txtDoc_Leave_1);
			this.m_txtDoc.Enter += new System.EventHandler(this.m_txtDoc_Enter_1);
			// 
			// txtOpdt
			// 
			this.txtOpdt.Location = new System.Drawing.Point(88, 8);
			this.txtOpdt.Name = "txtOpdt";
			this.txtOpdt.Size = new System.Drawing.Size(104, 23);
			this.txtOpdt.TabIndex = 10;
			this.txtOpdt.Text = "";
			this.txtOpdt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOpdt_KeyDown_1);
			this.txtOpdt.TextChanged += new System.EventHandler(this.txtOpdt_TextChanged);
			this.txtOpdt.Leave += new System.EventHandler(this.txtOpdt_Leave);
			this.txtOpdt.Enter += new System.EventHandler(this.txtOpdt_Enter);
			// 
			// m_treelisv
			// 
			this.m_treelisv.ImageIndex = -1;
			this.m_treelisv.Location = new System.Drawing.Point(288, 200);
			this.m_treelisv.Name = "m_treelisv";
			this.m_treelisv.SelectedImageIndex = -1;
			this.m_treelisv.Size = new System.Drawing.Size(128, 176);
			this.m_treelisv.TabIndex = 30;
			this.m_treelisv.Visible = false;
			this.m_treelisv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_treelisv_KeyDown);
			this.m_treelisv.DoubleClick += new System.EventHandler(this.m_treelisv_DoubleClick);
			this.m_treelisv.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_treelisv_AfterSelect);
			this.m_treelisv.Leave += new System.EventHandler(this.m_treelisv_Leave);
			// 
			// LisDep
			// 
			this.LisDep.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					 this.SHORTNO_CHR,
																					 this.DEPTNAME_VCHR});
			this.LisDep.FullRowSelect = true;
			this.LisDep.GridLines = true;
			this.LisDep.HideSelection = false;
			this.LisDep.Location = new System.Drawing.Point(8, 200);
			this.LisDep.MultiSelect = false;
			this.LisDep.Name = "LisDep";
			this.LisDep.Size = new System.Drawing.Size(192, 176);
			this.LisDep.TabIndex = 39;
			this.LisDep.View = System.Windows.Forms.View.Details;
			this.LisDep.Visible = false;
			this.LisDep.Click += new System.EventHandler(this.LisDep_Click);
			// 
			// SHORTNO_CHR
			// 
			this.SHORTNO_CHR.Text = "简码";
			this.SHORTNO_CHR.Width = 59;
			// 
			// DEPTNAME_VCHR
			// 
			this.DEPTNAME_VCHR.Text = "部门名称";
			this.DEPTNAME_VCHR.Width = 111;
			// 
			// ListDor
			// 
			this.ListDor.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					  this.EMPNO_CHR,
																					  this.LASTNAME_VCHR});
			this.ListDor.FullRowSelect = true;
			this.ListDor.GridLines = true;
			this.ListDor.HideSelection = false;
			this.ListDor.Location = new System.Drawing.Point(224, 200);
			this.ListDor.MultiSelect = false;
			this.ListDor.Name = "ListDor";
			this.ListDor.Size = new System.Drawing.Size(184, 176);
			this.ListDor.TabIndex = 39;
			this.ListDor.View = System.Windows.Forms.View.Details;
			this.ListDor.Visible = false;
			this.ListDor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ListDor_MouseDown);
			this.ListDor.Click += new System.EventHandler(this.ListDor_Click);
			// 
			// EMPNO_CHR
			// 
			this.EMPNO_CHR.Text = "员工工号";
			this.EMPNO_CHR.Width = 77;
			// 
			// LASTNAME_VCHR
			// 
			this.LASTNAME_VCHR.Text = "姓名";
			this.LASTNAME_VCHR.Width = 86;
			// 
			// frmAddPlan
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(416, 213);
			this.Controls.Add(this.ListDor);
			this.Controls.Add(this.LisDep);
			this.Controls.Add(this.m_treelisv);
			this.Controls.Add(this.txtOpdt);
			this.Controls.Add(this.m_txtDoc);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.m_btnSR);
			this.Controls.Add(this.m_btnSave);
			this.Controls.Add(this.m_btnClear);
			this.Controls.Add(this.m_txtNum);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.m_txtRoom);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.m_cboPerio);
			this.Controls.Add(this.m_cboRegType);
			this.Controls.Add(this.m_DtpEnd);
			this.Controls.Add(this.m_DtpStart);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.Name = "frmAddPlan";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "医生排班维护";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAddPlan_KeyDown);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmAddPlan_KeyPress);
			this.Load += new System.EventHandler(this.frmAddPlan_Load);
			this.ResumeLayout(false);

		}
		#endregion

		public override void CreateController()
		{
			this.objController=new com.digitalwave.iCare.gui.HIS.clsControlAddPlan();
			//this.objController = new com.digitalwave.iCare.gui.HIS.clsControlAddPlan(
			objController.Set_GUI_Apperance(this);

		}
		private void m_txtDoc_Enter(object sender, System.EventArgs e)
		{

		}

		private void frmAddPlan_Load(object sender, System.EventArgs e)
		{
		  m_mthSetFormControlCanBeNull(this);
		  this.m_cboPerio.DropDownStyle=ComboBoxStyle.DropDownList;
			this.m_mthSetEnter2Tab(new System.Windows.Forms.Control[] {});
			if(txtOpdt.Text!="")
			{
				m_txtDoc.Focus();
			}
		}

		private void m_TVDep_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
		  ((clsControlAddPlan)this.objController).m_GetDocByDepID();
		}

		private void m_lvwDoc_Click(object sender, System.EventArgs e)
		{
			this.m_txtDoc.Clear();
			if(m_lvwDoc.Items.Count==0)
				return;
			if(m_lvwDoc.SelectedItems.Count==0)
				return;
			this.m_txtDoc.Tag=m_lvwDoc.SelectedItems[0].Text;
			this.m_txtDoc.Text=m_lvwDoc.SelectedItems[0].SubItems[1].Text;
			this.m_Panel.Visible=false;
			if(this.txtOpdt.Enabled==true)
			    this.txtOpdt.Focus();
			else
				this.m_cboRegType.Focus();
		}

		private void m_btnSave_Click(object sender, System.EventArgs e)
		{
		   long lngRes=((clsControlAddPlan)this.objController).m_lngSave();
		}
		
		public void ShowDayPlan(bool IsNew,clsControlDayPlan clsObject)
		{
//			((clsControlAddPlan)this.objController).GetDepTV();
			((clsControlAddPlan)this.objController).m_FillRegType();
           ((clsControlAddPlan)this.objController).ShowDayPlan(IsNew,clsObject);
		}
		public void ShowWeekPlan(bool IsNew,clsControlWeekPlan clsObject)
		{
//			((clsControlAddPlan)this.objController).GetDepTV();
			((clsControlAddPlan)this.objController).m_FillRegType();
			((clsControlAddPlan)this.objController).ShowWeekPlan(IsNew,clsObject);
		}

		private void m_btnSR_Click(object sender, System.EventArgs e)
		{
			long lngRes=((clsControlAddPlan)this.objController).m_lngSave();
			if(lngRes>0)
			{
				this.Close();
			}
		}
		private void frmAddPlan_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
		   e.Handled=(e.KeyChar==(char)32 || e.KeyChar=="'".ToCharArray()[0]);
		   if(e.KeyChar==(char)27)
			   this.Close();
		}

		private void m_txtDoc_Leave(object sender, System.EventArgs e)
		{
			if(this.ActiveControl.Name!="m_lvwDoc" && this.ActiveControl.Name!="m_TVDep")
				m_Panel.Visible=false;
		}

		private void m_lvwDoc_Leave(object sender, System.EventArgs e)
		{
//			if(this.ActiveControl.Name!="m_txtDoc")
//				m_Panel.Visible=false;
		}

		private void m_lvwDoc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				this.m_lvwDoc_Click(sender,e);
//				this.txtOpdt.Focus();
			}
		}

		private void m_txtDoc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{

		}

		private void m_btnClear_Click(object sender, System.EventArgs e)
		{
			((clsControlAddPlan)this.objController).m_Clear();
		}

		private void m_cboRegType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_cboRegType.SelectedIndex>-1)
				this.errorProvider1.SetError(m_cboRegType,"");
		}

		private void m_cboPerio_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_cboPerio.SelectedIndex>-1)
				this.errorProvider1.SetError(m_cboPerio,"");
            ((clsControlAddPlan)this.objController).GetPerioTime();
		}

		private void m_DtpStart_ValueChanged(object sender, System.EventArgs e)
		{
			if(m_DtpStart.Value<=m_DtpEnd.Value)
				this.errorProvider1.SetError(m_DtpStart,"");
		}

		private void m_cboRegType_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			this.m_mthSetKeyTab(e);
		}

		private void m_cboPerio_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			this.m_mthSetKeyTab(e);
		}

		private void m_txtNum_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			this.m_mthSetKeyTab(e);
		}

		private void txtOpdt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			this.m_mthSetKeyTab(e);
		}

		private void m_txtDoc_KeyDown_1(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				if(this.ListDor.SelectedItems.Count>0)
				{
					clsEmployeeVO selectItem=new  clsEmployeeVO();
					selectItem=(clsEmployeeVO)this.ListDor.SelectedItems[0].Tag;
					this.m_txtDoc.Clear();
					this.m_txtDoc.Text=selectItem.strName.Trim();
					this.m_txtDoc.Tag=selectItem.strEmpID.Trim();
					this.m_txtNum.Tag=selectItem.strEmpNO.Trim();
					this.ListDor.Visible=false;
					m_cboRegType.Focus();
				}
			}
			if(e.KeyCode==Keys.Up)
			{
				if(this.ListDor.SelectedItems.Count>0&&this.ListDor.SelectedItems[0].Index!=0)
				{
					this.ListDor.Items[this.ListDor.SelectedItems[0].Index-1].Selected=true;
					this.ListDor.Items[this.ListDor.SelectedItems[0].Index].EnsureVisible();
					this.m_txtDoc.Focus();
				}
			}
			if(e.KeyCode==Keys.Down)
			{
				if(this.ListDor.SelectedItems.Count>0&&this.ListDor.SelectedItems[0].Index<this.ListDor.Items.Count-1)
				{
					this.ListDor.Items[this.ListDor.SelectedItems[0].Index+1].Selected=true;
					this.ListDor.Items[this.ListDor.SelectedItems[0].Index].EnsureVisible();
					this.m_txtDoc.Focus();
				}
			}
		}

		private void m_txtDoc_Enter_1(object sender, System.EventArgs e)
		{
           ((clsControlAddPlan)this.objController).m_ShowDept(m_txtDoc);
		}

		private void txtOpdt_Enter(object sender, System.EventArgs e)
		{
			((clsControlAddPlan)this.objController).m_ShowDept(txtOpdt);

		}

		private void txtOpdt_Leave(object sender, System.EventArgs e)
		{
			if(this.LisDep.Visible==true)
				this.LisDep.Visible=false;
		}

		private void m_treelisv_Leave(object sender, System.EventArgs e)
		{

		}

		private void m_txtDoc_Leave_1(object sender, System.EventArgs e)
		{
			if(this.ListDor.Visible==true)
				ListDor.Visible=false;
		}

		private void m_treelisv_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{

		}

		private void m_Panel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}

		private void m_TVDep_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				if(m_lvwDoc.Items.Count>0)
				{
					m_lvwDoc.Focus();
					m_lvwDoc.Items[0].Selected=true;
				}
			}
		}

		private void m_treelisv_DoubleClick(object sender, System.EventArgs e)
		{
			if(this.m_treelisv.SelectedNode.Nodes.Count==0)
			{
				this.txtOpdt.Text=m_treelisv.SelectedNode.Text.Trim();
				this.txtOpdt.Tag=(string)m_treelisv.SelectedNode.Tag;
			    m_treelisv.Visible=false;
			    m_cboRegType.Focus();
			}
			else
			{
			}
		}

		private void m_treelisv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				if(this.m_treelisv.SelectedNode.Nodes.Count==0)
				{
					this.txtOpdt.Text=m_treelisv.SelectedNode.Text.Trim();
					this.txtOpdt.Tag=(string)m_treelisv.SelectedNode.Tag;
					m_treelisv.Visible=false;
					m_cboRegType.Focus();
				}
				else
				{
					this.m_treelisv.SelectedNode.Expand();
				}
			}
		}

		private void txtOpdt_TextChanged(object sender, System.EventArgs e)
		{
			((clsControlAddPlan)this.objController).m_FindLisDep();
		}

		private void txtOpdt_KeyDown_1(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				if(this.LisDep.SelectedItems.Count>0)
				{
				    DataRow SelectRow=(DataRow)this.LisDep.SelectedItems[0].Tag;
					this.txtOpdt.Clear();
					this.txtOpdt.Text=SelectRow["DEPTNAME_VCHR"].ToString().Trim();
					this.txtOpdt.Tag=SelectRow["DEPTID_CHR"].ToString().Trim();
					this.LisDep.Visible=false;
					if(this.m_txtDoc.Enabled==true)
						this.m_txtDoc.Focus();
					else
						this.m_cboRegType.Focus();
				}
			}
			if(e.KeyCode==Keys.Up)
			{
				if(this.LisDep.SelectedItems[0].Index!=0)
				{
					this.LisDep.Items[this.LisDep.SelectedItems[0].Index-1].Selected=true;
					this.LisDep.Items[this.LisDep.SelectedItems[0].Index].EnsureVisible();
					this.txtOpdt.Focus();
				}
			}
			if(e.KeyCode==Keys.Down)
			{
				if(this.LisDep.SelectedItems[0].Index<this.LisDep.Items.Count-1)
				{
					this.LisDep.Items[this.LisDep.SelectedItems[0].Index+1].Selected=true;
					this.LisDep.Items[this.LisDep.SelectedItems[0].Index].EnsureVisible();
					this.txtOpdt.Focus();
				}
			}
		}

		private void LisDep_Click(object sender, System.EventArgs e)
		{
			DataRow SelectRow=(DataRow)this.LisDep.SelectedItems[0].Tag;
			this.txtOpdt.Clear();
			this.txtOpdt.Text=SelectRow["DEPTNAME_VCHR"].ToString().Trim();
			this.txtOpdt.Tag=SelectRow["DEPTID_CHR"].ToString().Trim();
			this.LisDep.Visible=false;
			if(this.m_txtDoc.Enabled==true)
			   this.m_txtDoc.Focus();
			else
			   m_cboRegType.Focus();
		}

		private void m_txtDoc_TextChanged(object sender, System.EventArgs e)
		{
			((clsControlAddPlan)this.objController).m_FindLisDor();
		}

		private void m_txtRoom_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
				this.m_btnSave.Focus();
		}

		private void ListDor_Click(object sender, System.EventArgs e)
		{
			if(this.ListDor.SelectedItems.Count>0)
			{
				clsEmployeeVO selectItem=new  clsEmployeeVO();
				selectItem=(clsEmployeeVO)this.ListDor.SelectedItems[0].Tag;
				this.m_txtDoc.Text=selectItem.strName.Trim();
				this.m_txtDoc.Tag=selectItem.strEmpID.Trim();
				this.m_txtNum.Tag=selectItem.strEmpNO.Trim();
				this.ListDor.Visible=false;
				m_cboRegType.Focus();
			}
			
		}

		private void frmAddPlan_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Left)
				m_btnClear.Focus();
			if(e.KeyCode==Keys.Right)
				m_btnSR.Focus();
		}

		private void ListDor_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
		
		}
	}
}
