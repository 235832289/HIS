//#define FunctionPrivilege
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text;
using com.digitalwave.Utility;
using com.digitalwave.Utility.Controls;
using PrivilegeData;
using com.digitalwave.PrivilegeSystemService;
using iCareData;

namespace iCare
{
	/// <summary>
	/// Summary description for frmRoleManage.
	/// </summary>
	public class frmRoleManage : iCare.iCareBaseForm.frmBaseForm
	{
		private System.Windows.Forms.TreeView trvExplorer;
		private System.Windows.Forms.ListView lsvEmployeeInfo;
		private System.Windows.Forms.ColumnHeader clmEmployeeID;
		private System.Windows.Forms.ColumnHeader clmEmployeeName;
		protected System.Windows.Forms.Label lblEmployeeTitle;
		private System.Windows.Forms.Label m_lblEmployeeInfo;
		protected System.Windows.Forms.Label label1;
		protected System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListView lsvRoleInfo;
		private System.Windows.Forms.ColumnHeader clmRoleName;
		private System.Windows.Forms.ColumnHeader clmCategory;
		private System.Windows.Forms.ColumnHeader clmDescription;
		private PinkieControls.ButtonXP cmdConfirm;
		private System.Windows.Forms.Panel pnlEmployee;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ImageList imgTreeView;
		protected System.Windows.Forms.Label lblDeptTitle;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboRoleCategory;
		private System.Windows.Forms.ListView lsvRoleCategory;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.TreeView trvRoleSF;
		private System.Windows.Forms.ContextMenu ctmAddRole;
		private System.Windows.Forms.MenuItem mniAddRole;
		private System.Windows.Forms.ContextMenu ctmDelRole;
		private System.Windows.Forms.MenuItem mniDelRole;
		private System.Windows.Forms.Panel pnlRole;
		private System.Windows.Forms.ListView lsvEmployeeInDept;
		private System.Windows.Forms.ColumnHeader clmName;
		protected System.Windows.Forms.Label lblDept;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboDept;
		private PinkieControls.ButtonXP cmdOK;
		private System.Windows.Forms.ListView lsvEmployeeInRole;
		private System.Windows.Forms.ColumnHeader clmEmployee_ID;
		private System.Windows.Forms.ColumnHeader clmEmployee_Name;
		protected System.Windows.Forms.Label lblRoles;
		protected System.Windows.Forms.Label lblEmployees;
		protected System.Windows.Forms.Label lblEmployyInfo;
		private System.Windows.Forms.ColumnHeader clmRole_Name;
		private System.Windows.Forms.ColumnHeader clmRole_Desc;
		private System.Windows.Forms.TreeView trvSFandOperation;
		private System.Windows.Forms.ListView lsvRoles;
		private System.Windows.Forms.ColumnHeader clmID;
		private System.Windows.Forms.ContextMenu ctmAddEmployee;
		private System.Windows.Forms.ContextMenu ctmDelEmployee;
		private System.Windows.Forms.MenuItem mniAddEmployee;
		private System.Windows.Forms.MenuItem mniDelEmployee;
		private System.Windows.Forms.Label m_lblEmployeeInfo_P2;
		private PinkieControls.ButtonXP cmdReset_P2;
		private PinkieControls.ButtonXP cmdCancel;

		public frmRoleManage()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
            //m_objBorderTool = new clsBorderTool(Color.White);
            //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[] {trvExplorer,lsvEmployeeInfo,lsvRoleInfo,lsvRoleCategory,
                                                            //lsvRoles,lsvEmployeeInRole,lsvEmployeeInDept});
			m_objHighLight = new ctlHighLightFocus(clsHRPColor.s_ClrHightLight);
		}

		private ctlHighLightFocus m_objHighLight;

		//在这里声明其它方法里面都可以用
        //private clsBorderTool m_objBorderTool;

		/// <summary>
		/// 部门中间层对象
		/// </summary>
		private clsDepartmentManager m_objDepartmentManager=new clsDepartmentManager();

		/// <summary>
		/// 权限系统中间层对象
		/// </summary>
		private clsRoleManager m_objPServ=new clsRoleManager();

		/// <summary>
		/// 记录添加或者删除角色的操作
		/// </summary>
		private ArrayList arlAddRemove = new ArrayList();
		/// <summary>
		/// 记录对哪个角色进行操作
		/// </summary>
		private ArrayList arlRole = new ArrayList();
		/// <summary>
		/// 记录对哪个员工进行操作
		/// </summary>
		private ArrayList arlEmployee = new ArrayList();

		
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmRoleManage));
			this.trvExplorer = new System.Windows.Forms.TreeView();
			this.imgTreeView = new System.Windows.Forms.ImageList(this.components);
			this.pnlEmployee = new System.Windows.Forms.Panel();
			this.m_cboRoleCategory = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.cmdCancel = new PinkieControls.ButtonXP();
			this.trvRoleSF = new System.Windows.Forms.TreeView();
			this.lsvRoleCategory = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.ctmAddRole = new System.Windows.Forms.ContextMenu();
			this.mniAddRole = new System.Windows.Forms.MenuItem();
			this.lblDeptTitle = new System.Windows.Forms.Label();
			this.cmdConfirm = new PinkieControls.ButtonXP();
			this.lsvRoleInfo = new System.Windows.Forms.ListView();
			this.clmRoleName = new System.Windows.Forms.ColumnHeader();
			this.clmCategory = new System.Windows.Forms.ColumnHeader();
			this.clmDescription = new System.Windows.Forms.ColumnHeader();
			this.ctmDelRole = new System.Windows.Forms.ContextMenu();
			this.mniDelRole = new System.Windows.Forms.MenuItem();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.m_lblEmployeeInfo = new System.Windows.Forms.Label();
			this.lblEmployeeTitle = new System.Windows.Forms.Label();
			this.lsvEmployeeInfo = new System.Windows.Forms.ListView();
			this.clmEmployeeID = new System.Windows.Forms.ColumnHeader();
			this.clmEmployeeName = new System.Windows.Forms.ColumnHeader();
			this.pnlRole = new System.Windows.Forms.Panel();
			this.cmdReset_P2 = new PinkieControls.ButtonXP();
			this.trvSFandOperation = new System.Windows.Forms.TreeView();
			this.lsvEmployeeInDept = new System.Windows.Forms.ListView();
			this.clmID = new System.Windows.Forms.ColumnHeader();
			this.clmName = new System.Windows.Forms.ColumnHeader();
			this.ctmAddEmployee = new System.Windows.Forms.ContextMenu();
			this.mniAddEmployee = new System.Windows.Forms.MenuItem();
			this.lblDept = new System.Windows.Forms.Label();
			this.m_cboDept = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.cmdOK = new PinkieControls.ButtonXP();
			this.lsvEmployeeInRole = new System.Windows.Forms.ListView();
			this.clmEmployee_ID = new System.Windows.Forms.ColumnHeader();
			this.clmEmployee_Name = new System.Windows.Forms.ColumnHeader();
			this.ctmDelEmployee = new System.Windows.Forms.ContextMenu();
			this.mniDelEmployee = new System.Windows.Forms.MenuItem();
			this.lblRoles = new System.Windows.Forms.Label();
			this.lblEmployees = new System.Windows.Forms.Label();
			this.m_lblEmployeeInfo_P2 = new System.Windows.Forms.Label();
			this.lblEmployyInfo = new System.Windows.Forms.Label();
			this.lsvRoles = new System.Windows.Forms.ListView();
			this.clmRole_Name = new System.Windows.Forms.ColumnHeader();
			this.clmRole_Desc = new System.Windows.Forms.ColumnHeader();
			this.pnlEmployee.SuspendLayout();
			this.pnlRole.SuspendLayout();
			this.SuspendLayout();
			// 
			// trvExplorer
			// 
			this.trvExplorer.BackColor = System.Drawing.Color.White;
			this.trvExplorer.Cursor = System.Windows.Forms.Cursors.Default;
			this.trvExplorer.Dock = System.Windows.Forms.DockStyle.Left;
			this.trvExplorer.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.trvExplorer.ForeColor = System.Drawing.Color.Black;
			this.trvExplorer.HideSelection = false;
			this.trvExplorer.HotTracking = true;
			this.trvExplorer.ImageList = this.imgTreeView;
			this.trvExplorer.Indent = 22;
			this.trvExplorer.Location = new System.Drawing.Point(0, 0);
			this.trvExplorer.Name = "trvExplorer";
			this.trvExplorer.Size = new System.Drawing.Size(252, 673);
			this.trvExplorer.TabIndex = 1;
			this.trvExplorer.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvExplorer_AfterSelect);
			// 
			// imgTreeView
			// 
			this.imgTreeView.ImageSize = new System.Drawing.Size(17, 17);
			this.imgTreeView.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgTreeView.ImageStream")));
			this.imgTreeView.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// pnlEmployee
			// 
			this.pnlEmployee.BackColor = System.Drawing.SystemColors.Control;
			this.pnlEmployee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlEmployee.Controls.Add(this.m_cboRoleCategory);
			this.pnlEmployee.Controls.Add(this.cmdCancel);
			this.pnlEmployee.Controls.Add(this.trvRoleSF);
			this.pnlEmployee.Controls.Add(this.lsvRoleCategory);
			this.pnlEmployee.Controls.Add(this.lblDeptTitle);
			this.pnlEmployee.Controls.Add(this.cmdConfirm);
			this.pnlEmployee.Controls.Add(this.lsvRoleInfo);
			this.pnlEmployee.Controls.Add(this.label2);
			this.pnlEmployee.Controls.Add(this.label1);
			this.pnlEmployee.Controls.Add(this.m_lblEmployeeInfo);
			this.pnlEmployee.Controls.Add(this.lblEmployeeTitle);
			this.pnlEmployee.Controls.Add(this.lsvEmployeeInfo);
			this.pnlEmployee.Location = new System.Drawing.Point(244, 0);
			this.pnlEmployee.Name = "pnlEmployee";
			this.pnlEmployee.Size = new System.Drawing.Size(860, 736);
			this.pnlEmployee.TabIndex = 2;
			// 
			// m_cboRoleCategory
			// 
			this.m_cboRoleCategory.BackColor = System.Drawing.Color.White;
			this.m_cboRoleCategory.BorderColor = System.Drawing.Color.Black;
			this.m_cboRoleCategory.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboRoleCategory.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboRoleCategory.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboRoleCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboRoleCategory.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboRoleCategory.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboRoleCategory.ForeColor = System.Drawing.Color.White;
			this.m_cboRoleCategory.ListBackColor = System.Drawing.Color.White;
			this.m_cboRoleCategory.ListForeColor = System.Drawing.Color.Black;
			this.m_cboRoleCategory.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboRoleCategory.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboRoleCategory.Location = new System.Drawing.Point(276, 236);
			this.m_cboRoleCategory.m_BlnEnableItemEventMenu = true;
			this.m_cboRoleCategory.Name = "m_cboRoleCategory";
			this.m_cboRoleCategory.SelectedIndex = -1;
			this.m_cboRoleCategory.SelectedItem = null;
			this.m_cboRoleCategory.Size = new System.Drawing.Size(227, 23);
			this.m_cboRoleCategory.TabIndex = 120;
			this.m_cboRoleCategory.TextBackColor = System.Drawing.Color.White;
			this.m_cboRoleCategory.TextForeColor = System.Drawing.Color.Black;
			this.m_cboRoleCategory.SelectedIndexChanged += new System.EventHandler(this.m_cboRoleCategory_SelectedIndexChanged);
			// 
			// cmdCancel
			// 
			this.cmdCancel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.cmdCancel.DefaultScheme = true;
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.None;
			this.cmdCancel.Hint = "";
			this.cmdCancel.Location = new System.Drawing.Point(444, 580);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.cmdCancel.Size = new System.Drawing.Size(64, 32);
			this.cmdCancel.TabIndex = 29185;
			this.cmdCancel.Text = "重  置";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// trvRoleSF
			// 
			this.trvRoleSF.BackColor = System.Drawing.Color.White;
			this.trvRoleSF.Enabled = false;
			this.trvRoleSF.ForeColor = System.Drawing.Color.Black;
			this.trvRoleSF.ImageIndex = -1;
			this.trvRoleSF.Location = new System.Drawing.Point(220, 24);
			this.trvRoleSF.Name = "trvRoleSF";
			this.trvRoleSF.SelectedImageIndex = -1;
			this.trvRoleSF.Size = new System.Drawing.Size(256, 192);
			this.trvRoleSF.TabIndex = 29184;
			this.trvRoleSF.Visible = false;
			// 
			// lsvRoleCategory
			// 
			this.lsvRoleCategory.BackColor = System.Drawing.Color.White;
			this.lsvRoleCategory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							  this.columnHeader1});
			this.lsvRoleCategory.ContextMenu = this.ctmAddRole;
			this.lsvRoleCategory.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lsvRoleCategory.ForeColor = System.Drawing.Color.Black;
			this.lsvRoleCategory.FullRowSelect = true;
			this.lsvRoleCategory.GridLines = true;
			this.lsvRoleCategory.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lsvRoleCategory.HideSelection = false;
			this.lsvRoleCategory.Location = new System.Drawing.Point(348, 268);
			this.lsvRoleCategory.MultiSelect = false;
			this.lsvRoleCategory.Name = "lsvRoleCategory";
			this.lsvRoleCategory.Size = new System.Drawing.Size(156, 200);
			this.lsvRoleCategory.TabIndex = 130;
			this.lsvRoleCategory.View = System.Windows.Forms.View.Details;
			this.lsvRoleCategory.DoubleClick += new System.EventHandler(this.mniAddRole_Click);
			this.lsvRoleCategory.SelectedIndexChanged += new System.EventHandler(this.lsvRoleCategory_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "角色名称";
			this.columnHeader1.Width = 150;
			// 
			// ctmAddRole
			// 
			this.ctmAddRole.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.mniAddRole});
			// 
			// mniAddRole
			// 
			this.mniAddRole.Index = 0;
			this.mniAddRole.Text = "添加角色";
			this.mniAddRole.Click += new System.EventHandler(this.mniAddRole_Click);
			// 
			// lblDeptTitle
			// 
			this.lblDeptTitle.AutoSize = true;
			this.lblDeptTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblDeptTitle.Location = new System.Drawing.Point(204, 240);
			this.lblDeptTitle.Name = "lblDeptTitle";
			this.lblDeptTitle.Size = new System.Drawing.Size(70, 19);
			this.lblDeptTitle.TabIndex = 29182;
			this.lblDeptTitle.Text = "角色分类:";
			// 
			// cmdConfirm
			// 
			this.cmdConfirm.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.cmdConfirm.DefaultScheme = true;
			this.cmdConfirm.DialogResult = System.Windows.Forms.DialogResult.None;
			this.cmdConfirm.Hint = "";
			this.cmdConfirm.Location = new System.Drawing.Point(320, 580);
			this.cmdConfirm.Name = "cmdConfirm";
			this.cmdConfirm.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.cmdConfirm.Size = new System.Drawing.Size(64, 32);
			this.cmdConfirm.TabIndex = 29179;
			this.cmdConfirm.Text = "应  用";
			this.cmdConfirm.Click += new System.EventHandler(this.cmdConfirm_Click);
			// 
			// lsvRoleInfo
			// 
			this.lsvRoleInfo.BackColor = System.Drawing.Color.White;
			this.lsvRoleInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						  this.clmRoleName,
																						  this.clmCategory,
																						  this.clmDescription});
			this.lsvRoleInfo.ContextMenu = this.ctmDelRole;
			this.lsvRoleInfo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lsvRoleInfo.ForeColor = System.Drawing.Color.Black;
			this.lsvRoleInfo.FullRowSelect = true;
			this.lsvRoleInfo.GridLines = true;
			this.lsvRoleInfo.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lsvRoleInfo.Location = new System.Drawing.Point(40, 40);
			this.lsvRoleInfo.Name = "lsvRoleInfo";
			this.lsvRoleInfo.Size = new System.Drawing.Size(464, 188);
			this.lsvRoleInfo.TabIndex = 110;
			this.lsvRoleInfo.View = System.Windows.Forms.View.Details;
			this.lsvRoleInfo.DoubleClick += new System.EventHandler(this.mniDelRole_Click);
			// 
			// clmRoleName
			// 
			this.clmRoleName.Text = "角色名称";
			this.clmRoleName.Width = 120;
			// 
			// clmCategory
			// 
			this.clmCategory.Text = "角色分类";
			this.clmCategory.Width = 120;
			// 
			// clmDescription
			// 
			this.clmDescription.Text = "角色描述";
			this.clmDescription.Width = 220;
			// 
			// ctmDelRole
			// 
			this.ctmDelRole.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.mniDelRole});
			// 
			// mniDelRole
			// 
			this.mniDelRole.Index = 0;
			this.mniDelRole.Text = "删除角色";
			this.mniDelRole.Click += new System.EventHandler(this.mniDelRole_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.Location = new System.Drawing.Point(32, 240);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 19);
			this.label2.TabIndex = 6102;
			this.label2.Text = "员工:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(40, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(99, 19);
			this.label1.TabIndex = 6101;
			this.label1.Text = "员工所属角色:";
			// 
			// m_lblEmployeeInfo
			// 
			this.m_lblEmployeeInfo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lblEmployeeInfo.Location = new System.Drawing.Point(44, 500);
			this.m_lblEmployeeInfo.Name = "m_lblEmployeeInfo";
			this.m_lblEmployeeInfo.Size = new System.Drawing.Size(476, 60);
			this.m_lblEmployeeInfo.TabIndex = 6100;
			this.m_lblEmployeeInfo.Visible = false;
			// 
			// lblEmployeeTitle
			// 
			this.lblEmployeeTitle.AutoSize = true;
			this.lblEmployeeTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblEmployeeTitle.Location = new System.Drawing.Point(44, 476);
			this.lblEmployeeTitle.Name = "lblEmployeeTitle";
			this.lblEmployeeTitle.Size = new System.Drawing.Size(99, 19);
			this.lblEmployeeTitle.TabIndex = 494;
			this.lblEmployeeTitle.Text = "员工详细信息:";
			this.lblEmployeeTitle.Visible = false;
			// 
			// lsvEmployeeInfo
			// 
			this.lsvEmployeeInfo.BackColor = System.Drawing.Color.White;
			this.lsvEmployeeInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							  this.clmEmployeeID,
																							  this.clmEmployeeName});
			this.lsvEmployeeInfo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lsvEmployeeInfo.ForeColor = System.Drawing.Color.Black;
			this.lsvEmployeeInfo.FullRowSelect = true;
			this.lsvEmployeeInfo.GridLines = true;
			this.lsvEmployeeInfo.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lsvEmployeeInfo.HideSelection = false;
			this.lsvEmployeeInfo.Location = new System.Drawing.Point(44, 272);
			this.lsvEmployeeInfo.MultiSelect = false;
			this.lsvEmployeeInfo.Name = "lsvEmployeeInfo";
			this.lsvEmployeeInfo.Size = new System.Drawing.Size(176, 188);
			this.lsvEmployeeInfo.TabIndex = 100;
			this.lsvEmployeeInfo.View = System.Windows.Forms.View.Details;
			this.lsvEmployeeInfo.SelectedIndexChanged += new System.EventHandler(this.lsvEmployeeInfo_SelectedIndexChanged);
			// 
			// clmEmployeeID
			// 
			this.clmEmployeeID.Text = "员工ID";
			this.clmEmployeeID.Width = 0;
			// 
			// clmEmployeeName
			// 
			this.clmEmployeeName.Text = "员工姓名";
			this.clmEmployeeName.Width = 170;
			// 
			// pnlRole
			// 
			this.pnlRole.BackColor = System.Drawing.SystemColors.Control;
			this.pnlRole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlRole.Controls.Add(this.cmdReset_P2);
			this.pnlRole.Controls.Add(this.trvSFandOperation);
			this.pnlRole.Controls.Add(this.lsvEmployeeInDept);
			this.pnlRole.Controls.Add(this.lblDept);
			this.pnlRole.Controls.Add(this.m_cboDept);
			this.pnlRole.Controls.Add(this.cmdOK);
			this.pnlRole.Controls.Add(this.lsvEmployeeInRole);
			this.pnlRole.Controls.Add(this.lblRoles);
			this.pnlRole.Controls.Add(this.lblEmployees);
			this.pnlRole.Controls.Add(this.m_lblEmployeeInfo_P2);
			this.pnlRole.Controls.Add(this.lblEmployyInfo);
			this.pnlRole.Controls.Add(this.lsvRoles);
			this.pnlRole.ForeColor = System.Drawing.Color.Black;
			this.pnlRole.Location = new System.Drawing.Point(252, 0);
			this.pnlRole.Name = "pnlRole";
			this.pnlRole.Size = new System.Drawing.Size(764, 732);
			this.pnlRole.TabIndex = 3;
			this.pnlRole.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlRole_Paint);
			// 
			// cmdReset_P2
			// 
			this.cmdReset_P2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.cmdReset_P2.DefaultScheme = true;
			this.cmdReset_P2.DialogResult = System.Windows.Forms.DialogResult.None;
			this.cmdReset_P2.Hint = "";
			this.cmdReset_P2.Location = new System.Drawing.Point(444, 580);
			this.cmdReset_P2.Name = "cmdReset_P2";
			this.cmdReset_P2.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.cmdReset_P2.Size = new System.Drawing.Size(68, 32);
			this.cmdReset_P2.TabIndex = 150;
			this.cmdReset_P2.Text = "重  置";
			this.cmdReset_P2.Click += new System.EventHandler(this.cmdReset_P2_Click);
			// 
			// trvSFandOperation
			// 
			this.trvSFandOperation.BackColor = System.Drawing.Color.White;
			this.trvSFandOperation.Enabled = false;
			this.trvSFandOperation.ForeColor = System.Drawing.Color.Black;
			this.trvSFandOperation.ImageIndex = -1;
			this.trvSFandOperation.Location = new System.Drawing.Point(276, 28);
			this.trvSFandOperation.Name = "trvSFandOperation";
			this.trvSFandOperation.SelectedImageIndex = -1;
			this.trvSFandOperation.Size = new System.Drawing.Size(188, 184);
			this.trvSFandOperation.TabIndex = 29196;
			this.trvSFandOperation.Visible = false;
			// 
			// lsvEmployeeInDept
			// 
			this.lsvEmployeeInDept.BackColor = System.Drawing.Color.White;
			this.lsvEmployeeInDept.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																								this.clmID,
																								this.clmName});
			this.lsvEmployeeInDept.ContextMenu = this.ctmAddEmployee;
			this.lsvEmployeeInDept.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lsvEmployeeInDept.ForeColor = System.Drawing.Color.Black;
			this.lsvEmployeeInDept.FullRowSelect = true;
			this.lsvEmployeeInDept.GridLines = true;
			this.lsvEmployeeInDept.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lsvEmployeeInDept.HideSelection = false;
			this.lsvEmployeeInDept.Location = new System.Drawing.Point(316, 244);
			this.lsvEmployeeInDept.MultiSelect = false;
			this.lsvEmployeeInDept.Name = "lsvEmployeeInDept";
			this.lsvEmployeeInDept.Size = new System.Drawing.Size(216, 188);
			this.lsvEmployeeInDept.TabIndex = 130;
			this.lsvEmployeeInDept.View = System.Windows.Forms.View.Details;
			this.lsvEmployeeInDept.DoubleClick += new System.EventHandler(this.mniAddEmployee_Click);
			this.lsvEmployeeInDept.SelectedIndexChanged += new System.EventHandler(this.lsvEmployeeInDept_SelectedIndexChanged);
			// 
			// clmID
			// 
			this.clmID.Text = "员工ID";
			this.clmID.Width = 0;
			// 
			// clmName
			// 
			this.clmName.Text = "员工姓名";
			this.clmName.Width = 215;
			// 
			// ctmAddEmployee
			// 
			this.ctmAddEmployee.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						   this.mniAddEmployee});
			// 
			// mniAddEmployee
			// 
			this.mniAddEmployee.Index = 0;
			this.mniAddEmployee.Text = "添加员工";
			this.mniAddEmployee.Click += new System.EventHandler(this.mniAddEmployee_Click);
			// 
			// lblDept
			// 
			this.lblDept.AutoSize = true;
			this.lblDept.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblDept.ForeColor = System.Drawing.Color.Black;
			this.lblDept.Location = new System.Drawing.Point(268, 224);
			this.lblDept.Name = "lblDept";
			this.lblDept.Size = new System.Drawing.Size(48, 19);
			this.lblDept.TabIndex = 29194;
			this.lblDept.Text = "科室：";
			// 
			// m_cboDept
			// 
			this.m_cboDept.BackColor = System.Drawing.Color.White;
			this.m_cboDept.BorderColor = System.Drawing.Color.Black;
			this.m_cboDept.DropButtonBackColor = System.Drawing.Color.Gainsboro;
			this.m_cboDept.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboDept.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboDept.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboDept.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboDept.ForeColor = System.Drawing.Color.White;
			this.m_cboDept.ListBackColor = System.Drawing.Color.White;
			this.m_cboDept.ListForeColor = System.Drawing.Color.Black;
			this.m_cboDept.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboDept.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboDept.Location = new System.Drawing.Point(316, 220);
			this.m_cboDept.m_BlnEnableItemEventMenu = true;
			this.m_cboDept.Name = "m_cboDept";
			this.m_cboDept.SelectedIndex = -1;
			this.m_cboDept.SelectedItem = null;
			this.m_cboDept.Size = new System.Drawing.Size(216, 23);
			this.m_cboDept.TabIndex = 120;
			this.m_cboDept.TextBackColor = System.Drawing.Color.White;
			this.m_cboDept.TextForeColor = System.Drawing.Color.Black;
			this.m_cboDept.SelectedIndexChanged += new System.EventHandler(this.m_cboDept_SelectedIndexChanged);
			// 
			// cmdOK
			// 
			this.cmdOK.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.cmdOK.DefaultScheme = true;
			this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.None;
			this.cmdOK.Hint = "";
			this.cmdOK.Location = new System.Drawing.Point(320, 580);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.cmdOK.Size = new System.Drawing.Size(68, 32);
			this.cmdOK.TabIndex = 140;
			this.cmdOK.Text = "应  用";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// lsvEmployeeInRole
			// 
			this.lsvEmployeeInRole.BackColor = System.Drawing.Color.White;
			this.lsvEmployeeInRole.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																								this.clmEmployee_ID,
																								this.clmEmployee_Name});
			this.lsvEmployeeInRole.ContextMenu = this.ctmDelEmployee;
			this.lsvEmployeeInRole.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lsvEmployeeInRole.ForeColor = System.Drawing.Color.Black;
			this.lsvEmployeeInRole.FullRowSelect = true;
			this.lsvEmployeeInRole.GridLines = true;
			this.lsvEmployeeInRole.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lsvEmployeeInRole.Location = new System.Drawing.Point(12, 240);
			this.lsvEmployeeInRole.Name = "lsvEmployeeInRole";
			this.lsvEmployeeInRole.Size = new System.Drawing.Size(204, 188);
			this.lsvEmployeeInRole.TabIndex = 110;
			this.lsvEmployeeInRole.View = System.Windows.Forms.View.Details;
			this.lsvEmployeeInRole.DoubleClick += new System.EventHandler(this.mniDelEmployee_Click);
			// 
			// clmEmployee_ID
			// 
			this.clmEmployee_ID.Text = "员工ID";
			this.clmEmployee_ID.Width = 0;
			// 
			// clmEmployee_Name
			// 
			this.clmEmployee_Name.Text = "员工姓名";
			this.clmEmployee_Name.Width = 200;
			// 
			// ctmDelEmployee
			// 
			this.ctmDelEmployee.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						   this.mniDelEmployee});
			this.ctmDelEmployee.RightToLeft = System.Windows.Forms.RightToLeft.No;
			// 
			// mniDelEmployee
			// 
			this.mniDelEmployee.Index = 0;
			this.mniDelEmployee.Text = "删除员工";
			this.mniDelEmployee.Click += new System.EventHandler(this.mniDelEmployee_Click);
			// 
			// lblRoles
			// 
			this.lblRoles.AutoSize = true;
			this.lblRoles.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblRoles.Location = new System.Drawing.Point(16, 8);
			this.lblRoles.Name = "lblRoles";
			this.lblRoles.Size = new System.Drawing.Size(48, 19);
			this.lblRoles.TabIndex = 29190;
			this.lblRoles.Text = "角色：";
			// 
			// lblEmployees
			// 
			this.lblEmployees.AutoSize = true;
			this.lblEmployees.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblEmployees.ForeColor = System.Drawing.Color.Black;
			this.lblEmployees.Location = new System.Drawing.Point(16, 220);
			this.lblEmployees.Name = "lblEmployees";
			this.lblEmployees.Size = new System.Drawing.Size(106, 19);
			this.lblEmployees.TabIndex = 29189;
			this.lblEmployees.Text = "角色下的员工：";
			// 
			// m_lblEmployeeInfo_P2
			// 
			this.m_lblEmployeeInfo_P2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lblEmployeeInfo_P2.Location = new System.Drawing.Point(12, 452);
			this.m_lblEmployeeInfo_P2.Name = "m_lblEmployeeInfo_P2";
			this.m_lblEmployeeInfo_P2.Size = new System.Drawing.Size(520, 72);
			this.m_lblEmployeeInfo_P2.TabIndex = 29188;
			this.m_lblEmployeeInfo_P2.Visible = false;
			// 
			// lblEmployyInfo
			// 
			this.lblEmployyInfo.AutoSize = true;
			this.lblEmployyInfo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblEmployyInfo.Location = new System.Drawing.Point(12, 432);
			this.lblEmployyInfo.Name = "lblEmployyInfo";
			this.lblEmployyInfo.Size = new System.Drawing.Size(99, 19);
			this.lblEmployyInfo.TabIndex = 29187;
			this.lblEmployyInfo.Text = "员工详细信息:";
			this.lblEmployyInfo.Visible = false;
			// 
			// lsvRoles
			// 
			this.lsvRoles.BackColor = System.Drawing.Color.White;
			this.lsvRoles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					   this.clmRole_Name,
																					   this.clmRole_Desc});
			this.lsvRoles.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lsvRoles.ForeColor = System.Drawing.Color.Black;
			this.lsvRoles.FullRowSelect = true;
			this.lsvRoles.GridLines = true;
			this.lsvRoles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lsvRoles.HideSelection = false;
			this.lsvRoles.Location = new System.Drawing.Point(12, 28);
			this.lsvRoles.MultiSelect = false;
			this.lsvRoles.Name = "lsvRoles";
			this.lsvRoles.Size = new System.Drawing.Size(520, 188);
			this.lsvRoles.TabIndex = 100;
			this.lsvRoles.View = System.Windows.Forms.View.Details;
			this.lsvRoles.SelectedIndexChanged += new System.EventHandler(this.lsvRoles_SelectedIndexChanged);
			// 
			// clmRole_Name
			// 
			this.clmRole_Name.Text = "角色名称";
			this.clmRole_Name.Width = 150;
			// 
			// clmRole_Desc
			// 
			this.clmRole_Desc.Text = "角色描述";
			this.clmRole_Desc.Width = 370;
			// 
			// frmRoleManage
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(792, 673);
			this.Controls.Add(this.trvExplorer);
			this.Controls.Add(this.pnlEmployee);
			this.Controls.Add(this.pnlRole);
			this.Font = new System.Drawing.Font("宋体", 10.5F);
			this.ForeColor = System.Drawing.Color.Black;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmRoleManage";
			this.Text = "权限管理";
			this.Load += new System.EventHandler(this.frmRoleManage_Load);
			this.pnlEmployee.ResumeLayout(false);
			this.pnlRole.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Form_Load
		private void frmRoleManage_Load(object sender, System.EventArgs e)
		{
			try
			{		
				// 从用户角度考虑
				TreeNode  TopNodeUsers=new  TreeNode("用户",0,0);
				trvExplorer.Nodes.Add(TopNodeUsers) ;
				m_mthGetAllDept(TopNodeUsers);
				
				
				
				TreeNode  TopNodeRoles=new  TreeNode("角色",1,1);
				trvExplorer.Nodes.Add(TopNodeRoles) ;
				m_mthGetAllRoles(TopNodeRoles);
				
				clsRole[] objRoleArr;

				m_objPServ.m_lngGetAllRole_OrderByCategory(out objRoleArr);

				string strRoleCategory="";
				if(objRoleArr!=null)
				{
					ArrayList arlRoleCategory = new ArrayList();
					for(int i=0; i<objRoleArr.Length; i++)
					{
						if(strRoleCategory!=objRoleArr[i].m_strRoleCategory)
						{
							m_cboRoleCategory.AddItem(objRoleArr[i].m_strRoleCategory);	
						}
						strRoleCategory = objRoleArr[i].m_strRoleCategory;
					}
				}	
				
				clsDepartment[] objDeptArr=	m_objDepartmentManager.m_objGetAllInDeptArr();
				if(objDeptArr !=null)
				{
					for(int i=0;i<objDeptArr.Length;i++)
					{
						m_cboDept.AddItem(objDeptArr[i]);
//						m_cboDept.AddItem(objDeptArr[i].m_StrDeptName);	
//						m_cboDept.Tag = objDeptArr[i];			
					}
				}		
		
				m_objHighLight.m_mthAddControlInContainer(this);

			}

			catch(Exception ex)
			{
				MessageBox.Show(ex.Message+"\n"+ex.TargetSite.ReflectedType.Name+"\n"+ex.TargetSite.Name);
			}
		}
		#endregion

		#region （在树中）获取所有部门
		/// <summary>
		/// （在树中）获取所有部门
		/// </summary>
		/// <param name="p_objParentNode"></param>
		/// <param name="p_strDeptID"></param>
		private void m_mthGetAllDept(TreeNode p_objParentNode)
		{
			if(p_objParentNode ==null )
				return;
			
			clsDepartment[] objDeptArr=	m_objDepartmentManager.m_objGetAllInDeptArr();
			if(objDeptArr !=null)
			{
				for(int i=0;i<objDeptArr.Length;i++)
				{
					TreeNode trnNewNode=new TreeNode(objDeptArr[i].m_StrDeptName,23,23);
					trnNewNode.Tag=objDeptArr[i];
					p_objParentNode.Nodes.Add(trnNewNode);					
				}
//				trvExplorer.ExpandAll();
			}			
		}
		#endregion （在树中）获取所有部门

		#region （在树中）获取所有角色分类
		/// <summary>
		/// （在树中）获取所有部门
		/// </summary>
		/// <param name="p_objParentNode"></param>
		/// <param name="p_strDeptID"></param>
		private void m_mthGetAllRoles(TreeNode p_objParentNode)
		{
			if(p_objParentNode ==null )
				return;

			clsRole[] objRoleArr;

			m_objPServ.m_lngGetAllRole_OrderByCategory(out objRoleArr);

			string strCategory="";
			if(objRoleArr!=null)
			{
				for(int i=0;i<objRoleArr.Length;i++)
				{
					if(strCategory!=objRoleArr[i].m_strRoleCategory.ToString())
					{
						TreeNode trnNewNode=new TreeNode(objRoleArr[i].m_strRoleCategory,23,23);
						trnNewNode.Tag=objRoleArr[i];
						p_objParentNode.Nodes.Add(trnNewNode);	
					}
					strCategory = objRoleArr[i].m_strRoleCategory;
				}
			}				
			
		}
		#endregion （在树中）获取所有角色分类


		private void trvExplorer_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{

			pnlRole.BringToFront();
			//要看Dock的返回值是什么类型
			pnlRole.Dock = DockStyle.Fill;

			//从用户角度考虑
			if(this.trvExplorer.SelectedNode==this.trvExplorer.Nodes[0] || this.trvExplorer.SelectedNode.Parent==this.trvExplorer.Nodes[0])
			{
				pnlEmployee.BringToFront();
				//要看Dock的返回值是什么类型
				pnlEmployee.Dock = DockStyle.Fill;
			}
			else
			{
				pnlRole.BringToFront();
				//要看Dock的返回值是什么类型
				pnlRole.Dock = DockStyle.Fill;
			}
			

			if(this.trvExplorer.SelectedNode.Parent==null)
			{
				if(arlAddRemove.Count>0)
				{
					string strYesNo = MessageBox.Show("是否保存已做的修改？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question).ToString();
					if(strYesNo=="Yes")
					{
						m_mthSave();
					}
				}

				arlAddRemove.Clear();
				arlRole.Clear();
				arlEmployee.Clear();

				lsvEmployeeInfo.Items.Clear();
				m_lblEmployeeInfo.Text = "";
				lsvRoleInfo.Items.Clear();
				trvRoleSF.Nodes.Clear();
				lsvRoleCategory.Items.Clear();

				lsvRoles.Items.Clear();
				trvSFandOperation.Nodes.Clear();
				lsvEmployeeInRole.Items.Clear();
				m_lblEmployeeInfo_P2.Text  = "";
				lsvEmployeeInDept.Items.Clear();
				
			}
			
			#region 用户角度
			
			if(this.trvExplorer.SelectedNode!=null && this.trvExplorer.SelectedNode.Tag!=null && this.trvExplorer.SelectedNode.Parent==this.trvExplorer.Nodes[0]) 
			{
				if(arlAddRemove.Count>0)
				{
					string strYesNo = MessageBox.Show("是否保存已做的修改？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question).ToString();
					if(strYesNo=="Yes")
					{
						m_mthSave();							
					}
				}

				arlAddRemove.Clear();
				arlRole.Clear();
				arlEmployee.Clear();

				lsvEmployeeInfo.Items.Clear();
				m_lblEmployeeInfo.Text = "";
				lsvRoleInfo.Items.Clear();
				
				clsEmployee[] objEmpArr ;

//				objEmpArr = clsSystemContext.s_ObjCurrentContext.m_ObjEmployeeManager.m_objGetEmployeeIDLikeArr("%",(clsDepartment)this.trvExplorer.SelectedNode.Tag);
				objEmpArr = clsSystemContext.s_ObjCurrentContext.m_ObjEmployeeManager.m_objGetEmployeeByDeptID(((clsDepartment)this.trvExplorer.SelectedNode.Tag).m_StrDeptID);
				if(objEmpArr !=null)
				{
					for(int i=0;i<objEmpArr.Length;i++)
					{
						ListViewItem lviNewItem;
						lviNewItem = new ListViewItem(new string[]{objEmpArr[i].m_StrEmployeeID,objEmpArr[i].m_StrFirstName});
						
						lviNewItem.Tag = objEmpArr[i];
						lsvEmployeeInfo.Items.Add(lviNewItem);	
					}
					clsPublicFunction.s_mthChangeListViewLastColumnWidth(lsvEmployeeInfo,11);
				}
			}
			
			#endregion 

			#region 角色角度

			if(this.trvExplorer.SelectedNode!=null && this.trvExplorer.SelectedNode.Tag!=null && this.trvExplorer.SelectedNode.Parent==this.trvExplorer.Nodes[1]) 
			{
				if(arlAddRemove.Count>0)
				{
					string strYesNo = MessageBox.Show("是否保存已做的修改？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question).ToString();
					if(strYesNo=="Yes")
					{
						m_mthSave();							
					}
				}

				arlAddRemove.Clear();
				arlRole.Clear();
				arlEmployee.Clear();

				lsvRoles.Items.Clear();
				trvSFandOperation.Nodes.Clear();
				lsvEmployeeInRole.Items.Clear();

				clsRole[] objRoleArr;

				m_objPServ.m_lngGetRolsByCategory(((clsRole)this.trvExplorer.SelectedNode.Tag).m_strRoleCategory,out objRoleArr);
			
				if(objRoleArr!=null)
				{
					for(int i=0; i<objRoleArr.Length; i++)
					{
						ListViewItem lviNewItem;
						lviNewItem = new ListViewItem(new string[]{objRoleArr[i].m_strRoleName,objRoleArr[i].m_strRoleDesc});
						
						lviNewItem.Tag = objRoleArr[i];
						lsvRoles.Items.Add(lviNewItem);	
					}
					clsPublicFunction.s_mthChangeListViewLastColumnWidth(lsvRoles,11);
				}	
			}
			#endregion

		}


		private void m_cboRoleCategory_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lsvRoleCategory.Items.Clear();

			clsRole[] objRoleArr;

			m_objPServ.m_lngGetRolsByCategory(m_cboRoleCategory.SelectedItem.ToString(),out objRoleArr);
			
			if(objRoleArr!=null)
			{
				for(int i=0; i<objRoleArr.Length; i++)
				{
					ListViewItem lviNewItem;
					lviNewItem = new ListViewItem(new string[]{objRoleArr[i].m_strRoleName});
						
					lviNewItem.Tag = objRoleArr[i];
					lsvRoleCategory.Items.Add(lviNewItem);	
				}
			}	

		}
		
		#region Old

//		#region （在树中）获取角色的所有功能
//		/// <summary>
//		/// （在树中）获取所有功能与操作
//		/// </summary>
//		/// <param name="p_objParentNode"></param>
//		/// <param name="p_strDeptID"></param>
//		private void m_mthGetAllSF(TreeNode p_objParentNode)
//		{
//			if(p_objParentNode ==null)
//				return;
//
//			clsRole objRole;
//
//			if(lsvRoleCategory.SelectedItems.Count>0)
//			{
//				m_objPServ.m_lngGetAllInfoByRoleID(((clsRole)lsvRoleCategory.SelectedItems[0].Tag).m_strRoleID,out objRole);
//			
//		
//				if(objRole !=null)
//				{				
//					clsSystemFunction[] objSFArr = objRole.m_objPrivilegeInfo.m_objGetAllSF();
//					if(objSFArr!=null)
//					{		
//						string strSFDesc = "";
//						for(int i=0; i<objSFArr.Length; i++)
//						{	
//						
//							if(strSFDesc!=objSFArr[i].m_strSFDesc)
//							{
//								TreeNode trnNewNode=new TreeNode(objSFArr[i].m_strSFDesc,23,23);
//								trnNewNode.Tag=objSFArr[i];
//								p_objParentNode.Nodes.Add(trnNewNode);
//								strSFDesc = objSFArr[i].m_strSFDesc;
//							
//								m_mthGetAllOperation(trnNewNode);
//
//							}						
//												
//						}
//				
//						trvRoleSF.Nodes[0].Expand();
//					}
//				}	
//			}
//		}
//		#endregion （在树中）获取角色的所有功能
//
//		#region （在树中）获取角色的所有功能1
//		/// <summary>
//		/// （在树中）获取所有功能与操作
//		/// </summary>
//		/// <param name="p_objParentNode"></param>
//		/// <param name="p_strDeptID"></param>
//		private void m_mthGetAllSF1(TreeNode p_objParentNode)
//		{
//			if(p_objParentNode ==null )
//				return;
//
//			clsRole objRole;
//
//			m_objPServ.m_lngGetAllInfoByRoleID(((clsRole)lsvRoles.SelectedItems[0].Tag).m_strRoleID,out objRole);
//					
//			if(objRole !=null)
//			{				
//				clsSystemFunction[] objSFArr = objRole.m_objPrivilegeInfo.m_objGetAllSF();
//				if(objSFArr!=null)
//				{		
//					string strSFDesc = "";
//					for(int i=0; i<objSFArr.Length; i++)
//					{	
//						
//						if(strSFDesc!=objSFArr[i].m_strSFDesc)
//						{
//							TreeNode trnNewNode=new TreeNode(objSFArr[i].m_strSFDesc,23,23);
//							trnNewNode.Tag=objSFArr[i];
//							p_objParentNode.Nodes.Add(trnNewNode);
//							strSFDesc = objSFArr[i].m_strSFDesc;
//							
//							m_mthGetAllOperation1(trnNewNode);
//
//						}
//						
//												
//					}
//				
//					trvSFandOperation.Nodes[0].Expand();
//				}
//			}			
//		}
//		#endregion （在树中）获取角色的所有功能1
//
//		#region （在树中）获取功能的相应操作
//		/// <summary>
//		/// （在树中）获取所有部门
//		/// </summary>
//		/// <param name="p_objParentNode"></param>
//		/// <param name="p_strDeptID"></param>
//		private void m_mthGetAllOperation(TreeNode p_objParentNode)
//		{
//			if(p_objParentNode ==null )
//				return;
//
//			clsRole objRole;
//
//			m_objPServ.m_lngGetAllInfoByRoleID(((clsRole)lsvRoleCategory.SelectedItems[0].Tag).m_strRoleID,out objRole);
//					
//			if(objRole !=null)
//			{				
//				clsOperation[] objOperationArr = objRole.m_objPrivilegeInfo.m_objGetOperationListBySF(((clsSystemFunction)p_objParentNode.Tag).m_intSFID);
//				if(objOperationArr!=null)
//				{		
//					
//					for(int i=0; i<objOperationArr.Length; i++)
//					{						
//						
//						TreeNode trnOperationNode=new TreeNode(objOperationArr[i].m_strOperationDesc,24,24);
//						trnOperationNode.Tag=objOperationArr[i];
//						p_objParentNode.Nodes.Add(trnOperationNode);												
//					}
//							
//				}
//			}			
//		}
//		#endregion （在树中）获取功能的相应操作
//
//		#region （在树中）获取功能的相应操作1
//		/// <summary>
//		/// （在树中）获取所有部门
//		/// </summary>
//		/// <param name="p_objParentNode"></param>
//		/// <param name="p_strDeptID"></param>
//		private void m_mthGetAllOperation1(TreeNode p_objParentNode)
//		{
//			if(p_objParentNode ==null )
//				return;
//
////			clsRole objRole;
//			clsPrivilegeInfo objPI;
//
//			long lngRes = m_objPServ.m_lngGetAllInfoByRoleID(((clsRole)lsvRoles.SelectedItems[0].Tag).m_strRoleID,out objPI);
//					
//			if(lngRes > 0 && objPI !=null)
//			{			
//				string strSFID = ((clsSystemFunction)p_objParentNode.Tag).m_intSFID;
//				//循环搜索所有的OISF,如果OISF的SF与p_intSFID一致，记录在临时变量中
//				foreach(object objValue in objPI.m_hasOISF.Values)
//				{					
//					clsOISF objOISF = (clsOISF)objValue;
//					if(objOISF.m_objSF.m_intSFID==strSFID)
//					{
//						bool blnIfHaveOperation = m_blnHaveOperation(objOISF.m_objOperation.m_intOperationID);
//					
//						if(!blnIfHaveOperation)
//							m_arlOISF.Add(objOISF.m_objOperation);
//					}
//
//				}
//		
//				clsOperation [] objOperationArr = (clsOperation [])m_arlOISF.ToArray(typeof(clsOperation));
//
//				m_arlOISF.Clear(); 
//			
//				return objOperationArr;
//
////				clsOperation[] objOperationArr = objPI.m_objGetOperationListBySF(((clsSystemFunction)p_objParentNode.Tag).m_intSFID);
////				if(objOperationArr!=null)
////				{		
////					
////					for(int i=0; i<objOperationArr.Length; i++)
////					{						
////						
////						TreeNode trnOperationNode=new TreeNode(objOperationArr[i].m_strOperationDesc,24,24);
////						trnOperationNode.Tag=objOperationArr[i];
////						p_objParentNode.Nodes.Add(trnOperationNode);												
////					}
////							
////				}
//			}			
//		}
//		#endregion （在树中）获取功能的相应操作1

		#endregion

		private void mniAddRole_Click(object sender, System.EventArgs e)
		{
			if(lsvRoleCategory.SelectedItems.Count == 0 || lsvRoleCategory.SelectedItems[0].Tag==null)
				return;
						
			for(int i=0; i<lsvRoleInfo.Items.Count; i++)
			{
				if(((clsRole)lsvRoleCategory.SelectedItems[0].Tag).m_strRoleID==((clsRole)lsvRoleInfo.Items[i].Tag).m_strRoleID)
				{
					MessageBox.Show("不能添加重复的角色","提示",MessageBoxButtons.OK);
					return;
				}
			}

			clsRole objRole = null;

			m_objPServ.m_lngGetRoleInfoByRoleID(((clsRole)lsvRoleCategory.SelectedItems[0].Tag).m_strRoleID,out objRole);
					
			if(objRole !=null)
			{
				if(lsvEmployeeInfo.SelectedItems.Count>0 && lsvEmployeeInfo.SelectedItems[0].Tag!=null)
				{
					arlAddRemove.Add(true);
					arlEmployee.Add(((clsEmployee)lsvEmployeeInfo.SelectedItems[0].Tag).m_StrEmployeeID);
					arlRole.Add(objRole.m_strRoleID);
				}
				else
				{
					MessageBox.Show("请先选择员工","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}

				ListViewItem lviNewItem;
				lviNewItem = new ListViewItem(new string[]{objRole.m_strRoleName,objRole.m_strRoleCategory,objRole.m_strRoleDesc});
						
				lviNewItem.Tag = objRole;
				lsvRoleInfo.Items.Add(lviNewItem);	

				
			}

		}

		private void cmdConfirm_Click(object sender, System.EventArgs e)
		{	
			m_mthSave();

			arlAddRemove.Clear();
			arlRole.Clear();
			arlEmployee.Clear();
		}

		private void mniDelRole_Click(object sender, System.EventArgs e)
		{
			if(lsvRoleInfo.SelectedItems.Count == 0 || lsvRoleInfo.SelectedItems[0].Tag==null)
				return;
			for(int i=0; i<lsvRoleInfo.SelectedItems.Count; i++)
			{	
				arlAddRemove.Add(false);
				arlEmployee.Add(((clsEmployee)lsvEmployeeInfo.SelectedItems[0].Tag).m_StrEmployeeID);
				arlRole.Add(((clsRole)lsvRoleInfo.SelectedItems[0].Tag).m_strRoleID);
				
				lsvRoleInfo.SelectedItems[i].Remove();
			
			}
		}

		private void m_mthSave()
		{
#if FunctionPrivilege
			if(!clsPublicFunction.s_blnCheckCurrentPrivilege(PrivilegeData.enmPrivilegeSF.frmRoleManage,PrivilegeData.enmPrivilegeOperation.AddOrModify))
			{
				clsPublicFunction.s_mthShowNotPermitMessage();
				return;
			}			
#endif
			bool[] blnAddRemoveArr = (bool[])arlAddRemove.ToArray(typeof(bool));
			string[] strRoleArr = (string[])arlRole.ToArray(typeof(string));
			string[] strEmployeeArr = (string[])arlEmployee.ToArray(typeof(string));

			m_objPServ.m_lngBatchAddRemoveRoleEmployee(blnAddRemoveArr,strRoleArr,strEmployeeArr,MDIParent.strOperatorID.ToString());

			clsPublicFunction.ShowInformationMessageBox("修改成功！");
		}
		
		private void m_cboDept_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lsvEmployeeInDept.Items.Clear();

			clsEmployee[] objEmpArr ;

//			objEmpArr = clsSystemContext.s_ObjCurrentContext.m_ObjEmployeeManager.m_objGetEmployeeIDLikeArr("%",(clsDepartment)m_cboDept.Tag);
			//直接((clsDepartment)m_cboDept.SelectedItem).m_StrDeptID就可以了，不可以(((clsDepartment)m_cboDept.SelectedItem).Tag).m_StrDeptID
			objEmpArr = clsSystemContext.s_ObjCurrentContext.m_ObjEmployeeManager.m_objGetEmployeeByDeptID(((clsDepartment)m_cboDept.SelectedItem).m_StrDeptID);	
			if(objEmpArr !=null)
			{
				for(int i=0;i<objEmpArr.Length;i++)
				{
					ListViewItem lviNewItem;
					lviNewItem = new ListViewItem(new string[]{objEmpArr[i].m_StrEmployeeID,objEmpArr[i].m_StrFirstName});
						
					lviNewItem.Tag = objEmpArr[i];
					lsvEmployeeInDept.Items.Add(lviNewItem);	
				}
				clsPublicFunction.s_mthChangeListViewLastColumnWidth(lsvEmployeeInDept,11);
			}
		}

		private void mniAddEmployee_Click(object sender, System.EventArgs e)
		{
			if(lsvEmployeeInDept.SelectedItems.Count == 0 || lsvEmployeeInDept.SelectedItems[0].Tag==null)
				return;

			if(lsvEmployeeInDept.SelectedItems[0].Text.Trim()=="Admin")
			{
				MessageBox.Show("系统管理员不能添加到其它角色中！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}

			if(lsvRoles.SelectedItems.Count<=0)
			{
				MessageBox.Show("请先选择角色","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}
			else
			{
				arlAddRemove.Add(true);
				arlEmployee.Add(lsvEmployeeInDept.SelectedItems[0].SubItems[0].Text);
				arlRole.Add(((clsRole)lsvRoles.SelectedItems[0].Tag).m_strRoleID);
			}
						
			for(int i=0; i<lsvEmployeeInRole.Items.Count; i++)
			{
				if(lsvEmployeeInDept.SelectedItems[0].SubItems[0].Text.Trim()==lsvEmployeeInRole.Items[i].SubItems[0].Text)
				{
					MessageBox.Show("不能添加重复的员工","提示",MessageBoxButtons.OK);
					return;
				}
			}
			
			ListViewItem lviNewItem;
			lviNewItem = new ListViewItem(new string[]{lsvEmployeeInDept.SelectedItems[0].SubItems[0].Text,lsvEmployeeInDept.SelectedItems[0].SubItems[1].Text});
			lviNewItem.Tag =lsvEmployeeInDept.SelectedItems[0].Tag;
			lsvEmployeeInRole.Items.Add(lviNewItem);

			clsPublicFunction.s_mthChangeListViewLastColumnWidth(lsvEmployeeInRole,11);

		}

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			m_mthSave();

			arlAddRemove.Clear();
			arlRole.Clear();
			arlEmployee.Clear();
		}

		private void mniDelEmployee_Click(object sender, System.EventArgs e)
		{
			if(lsvEmployeeInRole.SelectedItems.Count == 0 || lsvEmployeeInRole.SelectedItems[0].Tag==null)
				return;
			for(int i=0; i<lsvEmployeeInRole.SelectedItems.Count; i++)
			{	
				if(lsvEmployeeInRole.SelectedItems[i].SubItems[0].Text.Trim()=="Admin")
				{
					MessageBox.Show("系统管理员不能删除！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
				arlAddRemove.Add(false);
				arlEmployee.Add(lsvEmployeeInRole.SelectedItems[i].SubItems[0].Text);
				arlRole.Add(((clsRole)lsvRoles.SelectedItems[i].Tag).m_strRoleID);				
				lsvEmployeeInRole.SelectedItems[i].Remove();
			}
		}
	

		private void cmdReset_P2_Click(object sender, System.EventArgs e)
		{
			if(lsvRoles.SelectedItems.Count>0)
			{
				arlAddRemove.Clear();
				arlRole.Clear();
				arlEmployee.Clear();

				lsvEmployeeInRole.Items.Clear();
				clsEmployee_BaseInfo[] objEmployeeArr;

				m_objPServ.m_lngGetEmployeesInRole(((clsRole)lsvRoles.SelectedItems[0].Tag).m_strRoleID,out objEmployeeArr);

				if(objEmployeeArr!=null)
				{				
					for(int i=0; i<objEmployeeArr.Length; i++)
					{					
						ListViewItem lviNewItem;
						lviNewItem = new ListViewItem(new string[]{objEmployeeArr[i].m_strEmployeeID,objEmployeeArr[i].m_strFirstName});						
						lviNewItem.Tag = objEmployeeArr[i];						
						lsvEmployeeInRole.Items.Add(lviNewItem);						
					}
				}	

				trvSFandOperation.Nodes.Clear ();	
				TreeNode  TopNode=new  TreeNode("功能与操作",0,0);
				trvSFandOperation.Nodes.Add(TopNode);
			
//				m_mthGetAllSF1(TopNode);
			}

		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			if(lsvEmployeeInfo.SelectedItems.Count>0)
			{
				arlAddRemove.Clear();
				arlRole.Clear();
				arlEmployee.Clear();

				lsvRoleInfo.Items.Clear();
				clsRole[] objRoleArr;

				m_objPServ.m_lngGetRolesByEmployee(lsvEmployeeInfo.SelectedItems[0].Text,out objRoleArr);

				if(objRoleArr!=null)
				{				
					for(int i=0; i<objRoleArr.Length; i++)
					{					
						ListViewItem lviNewItem;
						lviNewItem = new ListViewItem(new string[]{objRoleArr[i].m_strRoleName,objRoleArr[i].m_strRoleCategory,objRoleArr[i].m_strRoleDesc});						
						lviNewItem.Tag = objRoleArr[i];						
						lsvRoleInfo.Items.Add(lviNewItem);						
					}
				}	
			}
		}

		private void lsvRoles_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(lsvRoles.SelectedItems.Count<=0)
				return;

			if(arlAddRemove.Count>0)
			{
				string strYesNo = MessageBox.Show("是否保存已做的修改？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question).ToString();
				if(strYesNo=="Yes")
				{
					m_mthSave();							
				}
			}

			arlAddRemove.Clear();
			arlRole.Clear();
			arlEmployee.Clear();

			lsvEmployeeInRole.Items.Clear();
			clsEmployee_BaseInfo[] objEmployeeArr;

			m_objPServ.m_lngGetEmployeesInRole(((clsRole)lsvRoles.SelectedItems[0].Tag).m_strRoleID,out objEmployeeArr);

			if(objEmployeeArr!=null)
			{				
				for(int i=0; i<objEmployeeArr.Length; i++)
				{					
					ListViewItem lviNewItem;
					lviNewItem = new ListViewItem(new string[]{objEmployeeArr[i].m_strEmployeeID,objEmployeeArr[i].m_strFirstName});						
					lviNewItem.Tag = objEmployeeArr[i];						
					lsvEmployeeInRole.Items.Add(lviNewItem);						
				}
				clsPublicFunction.s_mthChangeListViewLastColumnWidth(lsvEmployeeInRole,11);
			}	

			trvSFandOperation.Nodes.Clear ();	
			TreeNode  TopNode=new  TreeNode("功能与操作",0,0);
			trvSFandOperation.Nodes.Add(TopNode);
			
//			m_mthGetAllSF1(TopNode);
		}

		//该事件会触发两次，首先将Index清空，然后再赋值
		private void lsvEmployeeInfo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(lsvEmployeeInfo.SelectedItems.Count <= 0)
				return;

			if(arlAddRemove.Count>0)
			{
				string strYesNo = MessageBox.Show("是否保存已做的修改？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question).ToString();
				if(strYesNo=="Yes")
				{
					m_mthSave();							
				}
			}

			arlAddRemove.Clear();
			arlRole.Clear();
			arlEmployee.Clear();

			//默认lsvEmployeeInfo.SelectedItems[0].Text=lsvEmployeeInfo.SelectedItems[0].SubItems[0].Text
			clsEmployee objEmp = new clsEmployee(lsvEmployeeInfo.SelectedItems[0].Text);
			m_lblEmployeeInfo.Text = objEmp.m_StrLastName+"  "+objEmp.m_StrSex+"  "+objEmp.m_StrOfficePhone+"  "+objEmp.m_StrEMail;	
	
			lsvRoleInfo.Items.Clear();
			clsRole[] objRoleArr;

			m_objPServ.m_lngGetRolesByEmployee(lsvEmployeeInfo.SelectedItems[0].Text,out objRoleArr);

			if(objRoleArr!=null)
			{				
				for(int i=0; i<objRoleArr.Length; i++)
				{					
					ListViewItem lviNewItem;
					lviNewItem = new ListViewItem(new string[]{objRoleArr[i].m_strRoleName,objRoleArr[i].m_strRoleCategory,objRoleArr[i].m_strRoleDesc});						
					lviNewItem.Tag = objRoleArr[i];						
					lsvRoleInfo.Items.Add(lviNewItem);						
				}
			}	
		}

		
		private void lsvRoleCategory_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			trvRoleSF.Nodes.Clear ();	
			TreeNode  TopNode=new  TreeNode("功能与操作",0,0);
			trvRoleSF.Nodes.Add(TopNode);
			
//			m_mthGetAllSF(TopNode);
		}

		private void lsvEmployeeInDept_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(lsvEmployeeInDept.SelectedItems.Count<=0)
				return;

			clsEmployee objEmp = new clsEmployee(lsvEmployeeInDept.SelectedItems[0].SubItems[0].Text);
			m_lblEmployeeInfo_P2.Text = objEmp.m_StrLastName+"  "+objEmp.m_StrSex+"  "+objEmp.m_StrOfficePhone+"  "+objEmp.m_StrEMail;
		}

		private void pnlRole_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			trvExplorer.Focus();
		}
	}
}
