//#define FunctionPrivilege
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using iCareData;
using com.digitalwave.Utility;
using com.digitalwave.Utility.Controls;
using PrivilegeData;
 
namespace iCare
{
	/// <summary>
    /// 检验项目管理(已作废)
	/// </summary>
	public class frmLabCheckItemAdmin : System.Windows.Forms.Form
	{
		#region Control Define
		private System.Windows.Forms.ListView lsvItemGroup;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.TreeView trvGroup;
		private System.Windows.Forms.Panel pnlTree;
		private System.Windows.Forms.Panel pnlListView;
		private System.Windows.Forms.ContextMenu ctmGroup;
		private System.Windows.Forms.MenuItem mniAddGroup;
		private System.Windows.Forms.MenuItem mniRename;
		private System.Windows.Forms.MenuItem mniDeleteGroup;
		private System.Windows.Forms.ContextMenu ctmItem;
		private System.Windows.Forms.MenuItem mniAddToGroup;
		private System.Windows.Forms.ContextMenu ctmItemGroup;
		private System.Windows.Forms.ColumnHeader clmItemID;
		private System.Windows.Forms.ColumnHeader clmItemName;
		private System.Windows.Forms.ListView lsvCheckItem;
		private System.Windows.Forms.Button cmdApply;
		private System.Windows.Forms.MenuItem mniDeleteFromGroup;
		private System.Windows.Forms.TabControl tabTree;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel pnlGroupItem;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lblTip;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.GroupBox groupBox2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region Constructor
		public frmLabCheckItemAdmin()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

            //m_objBorderTool = new clsBorderTool(Color.White);

            //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{trvGroup,lsvItemGroup,lsvCheckItem});

			m_mthInitializeItemList();

			m_mthInitializeTreeView();

            m_objHighLight = new ctlHighLightFocus(clsHRPColor.s_ClrHightLight);

		}
		#endregion

        private ctlHighLightFocus m_objHighLight;

		
		#region Member
        //private clsBorderTool  m_objBorderTool;
		
		private clsLabCheckItem[] m_objLabCheckItemArr;

		private clsLabCheckGroup[] m_objLabCheckGroupArr;

		private clsLabCheckItemAdminDomain m_objLabCheckItemAdminDomain = new clsLabCheckItemAdminDomain();


		private string m_strGroupName = "";
		#endregion

		#region Dispose
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
		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmLabCheckItemAdmin));
			this.lsvItemGroup = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.ctmItemGroup = new System.Windows.Forms.ContextMenu();
			this.mniDeleteFromGroup = new System.Windows.Forms.MenuItem();
			this.pnlListView = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lsvCheckItem = new System.Windows.Forms.ListView();
			this.clmItemID = new System.Windows.Forms.ColumnHeader();
			this.clmItemName = new System.Windows.Forms.ColumnHeader();
			this.ctmItem = new System.Windows.Forms.ContextMenu();
			this.mniAddToGroup = new System.Windows.Forms.MenuItem();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lblTip = new System.Windows.Forms.Label();
			this.splitter2 = new System.Windows.Forms.Splitter();
			this.pnlGroupItem = new System.Windows.Forms.Panel();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.cmdApply = new System.Windows.Forms.Button();
			this.pnlTree = new System.Windows.Forms.Panel();
			this.tabTree = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.trvGroup = new System.Windows.Forms.TreeView();
			this.ctmGroup = new System.Windows.Forms.ContextMenu();
			this.mniAddGroup = new System.Windows.Forms.MenuItem();
			this.mniDeleteGroup = new System.Windows.Forms.MenuItem();
			this.mniRename = new System.Windows.Forms.MenuItem();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.pnlListView.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.pnlGroupItem.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.pnlTree.SuspendLayout();
			this.tabTree.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lsvItemGroup
			// 
			this.lsvItemGroup.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.lsvItemGroup.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						   this.columnHeader1,
																						   this.columnHeader2});
			this.lsvItemGroup.ContextMenu = this.ctmItemGroup;
			this.lsvItemGroup.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lsvItemGroup.ForeColor = System.Drawing.Color.White;
			this.lsvItemGroup.FullRowSelect = true;
			this.lsvItemGroup.GridLines = true;
			this.lsvItemGroup.Location = new System.Drawing.Point(3, 22);
			this.lsvItemGroup.Name = "lsvItemGroup";
			this.lsvItemGroup.Size = new System.Drawing.Size(580, 199);
			this.lsvItemGroup.TabIndex = 110;
			this.lsvItemGroup.View = System.Windows.Forms.View.Details;
			this.lsvItemGroup.DoubleClick += new System.EventHandler(this.lsvItemGroup_DoubleClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "编号";
			this.columnHeader1.Width = 100;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "名  称";
			this.columnHeader2.Width = 300;
			// 
			// ctmItemGroup
			// 
			this.ctmItemGroup.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.mniDeleteFromGroup});
			this.ctmItemGroup.Popup += new System.EventHandler(this.ctmItemGroup_Popup);
			// 
			// mniDeleteFromGroup
			// 
			this.mniDeleteFromGroup.Index = 0;
			this.mniDeleteFromGroup.Text = "从该组中删除";
			this.mniDeleteFromGroup.Click += new System.EventHandler(this.mniDeleteFromGroup_Click);
			// 
			// pnlListView
			// 
			this.pnlListView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlListView.Controls.AddRange(new System.Windows.Forms.Control[] {
																					  this.panel1,
																					  this.splitter2,
																					  this.pnlGroupItem,
																					  this.cmdApply});
			this.pnlListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlListView.Location = new System.Drawing.Point(304, 0);
			this.pnlListView.Name = "pnlListView";
			this.pnlListView.Size = new System.Drawing.Size(590, 591);
			this.pnlListView.TabIndex = 423;
			// 
			// panel1
			// 
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.panel3,
																				 this.panel2});
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 252);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(586, 284);
			this.panel1.TabIndex = 424;
			// 
			// panel3
			// 
			this.panel3.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.groupBox1});
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 44);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(586, 240);
			this.panel3.TabIndex = 408;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.lsvCheckItem});
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(586, 240);
			this.groupBox1.TabIndex = 406;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "检验项目列表";
			// 
			// lsvCheckItem
			// 
			this.lsvCheckItem.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.lsvCheckItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						   this.clmItemID,
																						   this.clmItemName});
			this.lsvCheckItem.ContextMenu = this.ctmItem;
			this.lsvCheckItem.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lsvCheckItem.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lsvCheckItem.ForeColor = System.Drawing.Color.White;
			this.lsvCheckItem.FullRowSelect = true;
			this.lsvCheckItem.GridLines = true;
			this.lsvCheckItem.Location = new System.Drawing.Point(3, 19);
			this.lsvCheckItem.Name = "lsvCheckItem";
			this.lsvCheckItem.Size = new System.Drawing.Size(580, 218);
			this.lsvCheckItem.TabIndex = 120;
			this.lsvCheckItem.View = System.Windows.Forms.View.Details;
			// 
			// clmItemID
			// 
			this.clmItemID.Text = "编号";
			this.clmItemID.Width = 100;
			// 
			// clmItemName
			// 
			this.clmItemName.Text = "名  称";
			this.clmItemName.Width = 300;
			// 
			// ctmItem
			// 
			this.ctmItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mniAddToGroup});
			this.ctmItem.Popup += new System.EventHandler(this.ctmItem_Popup);
			// 
			// mniAddToGroup
			// 
			this.mniAddToGroup.Index = 0;
			this.mniAddToGroup.Text = "加入到组";
			this.mniAddToGroup.Click += new System.EventHandler(this.mniAddToGroup_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.lblTip});
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(586, 44);
			this.panel2.TabIndex = 407;
			// 
			// lblTip
			// 
			this.lblTip.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblTip.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblTip.Name = "lblTip";
			this.lblTip.Size = new System.Drawing.Size(586, 36);
			this.lblTip.TabIndex = 0;
			this.lblTip.Text = "右健单击检验项目列表中的项目，在弹出的菜单中选择“添加到组”添加项目到指定的组。";
			// 
			// splitter2
			// 
			this.splitter2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter2.Location = new System.Drawing.Point(0, 224);
			this.splitter2.Name = "splitter2";
			this.splitter2.Size = new System.Drawing.Size(586, 28);
			this.splitter2.TabIndex = 423;
			this.splitter2.TabStop = false;
			// 
			// pnlGroupItem
			// 
			this.pnlGroupItem.Controls.AddRange(new System.Windows.Forms.Control[] {
																					   this.groupBox2});
			this.pnlGroupItem.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlGroupItem.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.pnlGroupItem.Name = "pnlGroupItem";
			this.pnlGroupItem.Size = new System.Drawing.Size(586, 224);
			this.pnlGroupItem.TabIndex = 422;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.lsvItemGroup});
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(586, 224);
			this.groupBox2.TabIndex = 421;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "组项目列表";
			// 
			// cmdApply
			// 
			this.cmdApply.Enabled = false;
			this.cmdApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmdApply.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.cmdApply.ForeColor = System.Drawing.Color.White;
			this.cmdApply.Location = new System.Drawing.Point(508, 552);
			this.cmdApply.Name = "cmdApply";
			this.cmdApply.Size = new System.Drawing.Size(64, 32);
			this.cmdApply.TabIndex = 130;
			this.cmdApply.Text = "应  用";
			this.cmdApply.Click += new System.EventHandler(this.cmdApply_Click);
			// 
			// pnlTree
			// 
			this.pnlTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlTree.Controls.AddRange(new System.Windows.Forms.Control[] {
																				  this.tabTree});
			this.pnlTree.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlTree.Name = "pnlTree";
			this.pnlTree.Size = new System.Drawing.Size(304, 591);
			this.pnlTree.TabIndex = 422;
			// 
			// tabTree
			// 
			this.tabTree.Controls.AddRange(new System.Windows.Forms.Control[] {
																				  this.tabPage1});
			this.tabTree.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabTree.ItemSize = new System.Drawing.Size(54, 19);
			this.tabTree.Name = "tabTree";
			this.tabTree.SelectedIndex = 0;
			this.tabTree.Size = new System.Drawing.Size(302, 589);
			this.tabTree.TabIndex = 422;
			// 
			// tabPage1
			// 
			this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.tabPage1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.trvGroup});
			this.tabPage1.Location = new System.Drawing.Point(4, 23);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(294, 562);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "组";
			// 
			// trvGroup
			// 
			this.trvGroup.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.trvGroup.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.trvGroup.ContextMenu = this.ctmGroup;
			this.trvGroup.Dock = System.Windows.Forms.DockStyle.Fill;
			this.trvGroup.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.trvGroup.ForeColor = System.Drawing.SystemColors.Window;
			this.trvGroup.FullRowSelect = true;
			this.trvGroup.HideSelection = false;
			this.trvGroup.ImageIndex = -1;
			this.trvGroup.Name = "trvGroup";
			this.trvGroup.SelectedImageIndex = -1;
			this.trvGroup.ShowRootLines = false;
			this.trvGroup.Size = new System.Drawing.Size(294, 562);
			this.trvGroup.TabIndex = 100;
			this.trvGroup.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvGroup_AfterSelect);
			// 
			// ctmGroup
			// 
			this.ctmGroup.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.mniAddGroup,
																					 this.mniDeleteGroup,
																					 this.mniRename});
			this.ctmGroup.Popup += new System.EventHandler(this.ctmGroup_Popup);
			// 
			// mniAddGroup
			// 
			this.mniAddGroup.Index = 0;
			this.mniAddGroup.Text = "添加组...";
			this.mniAddGroup.Click += new System.EventHandler(this.mniAddGroup_Click);
			// 
			// mniDeleteGroup
			// 
			this.mniDeleteGroup.Index = 1;
			this.mniDeleteGroup.Text = "删除组";
			this.mniDeleteGroup.Click += new System.EventHandler(this.mniDeleteGroup_Click);
			// 
			// mniRename
			// 
			this.mniRename.Index = 2;
			this.mniRename.Text = "重命名";
			this.mniRename.Click += new System.EventHandler(this.mniRename_Click);
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(304, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(1, 591);
			this.splitter1.TabIndex = 424;
			this.splitter1.TabStop = false;
			// 
			// frmLabCheckItemAdmin
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.ClientSize = new System.Drawing.Size(894, 591);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.splitter1,
																		  this.pnlListView,
																		  this.pnlTree});
			this.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.ForeColor = System.Drawing.Color.White;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmLabCheckItemAdmin";
			this.Text = "检验项目管理";
			this.Load += new System.EventHandler(this.frmLabCheckItemAdmin_Load);
			this.pnlListView.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.pnlGroupItem.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.pnlTree.ResumeLayout(false);
			this.tabTree.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Initialization
		/// <summary>
		/// 初始化Item
		/// </summary>
		private void m_mthInitializeItemList()
		{
			Cursor.Current = Cursors.WaitCursor;

			long lngRes = m_objLabCheckItemAdminDomain.m_lngGetLabCheckItems(out m_objLabCheckItemArr);

			if(lngRes <= 0 || m_objLabCheckItemArr == null || m_objLabCheckItemArr.Length == 0)
				return;

			for(int i = 0; i < m_objLabCheckItemArr.Length; i++)
			{
				if(m_objLabCheckItemArr[i] != null)
				{
					ListViewItem lsvItem = new ListViewItem(new string[]{m_objLabCheckItemArr[i].m_strLabItemID,m_objLabCheckItemArr[i].m_strLabItemDesc});

					lsvItem.Tag = m_objLabCheckItemArr[i];

					lsvCheckItem.Items.Add(lsvItem);
				}
			}//end for

			Cursor.Current = Cursors.Default;
		}

		/// <summary>
		/// 初始化分组
		/// </summary>
		private void m_mthInitializeGroupItem()
		{
			Cursor.Current = Cursors.WaitCursor;

			if(this.trvGroup.SelectedNode == trvGroup.Nodes[0])
				return;

			clsLabCheckItem[] objLabCheckItemArr;
			string strGroup_ID = ((clsLabCheckGroup)trvGroup.SelectedNode.Tag).m_strLabGroupID;

			long lngRes = m_objLabCheckItemAdminDomain.m_lngGetLabCheckGroupItem(strGroup_ID,out objLabCheckItemArr);

			if(lngRes <= 0 || objLabCheckItemArr == null || objLabCheckItemArr.Length == 0)
				return;

			clsLabCheckGroupItem[] objLabCheckGroupItemArr = new clsLabCheckGroupItem[objLabCheckItemArr.Length];

			for(int i = 0; i < objLabCheckItemArr.Length; i++)
			{
				objLabCheckGroupItemArr[i] = new clsLabCheckGroupItem();

				if(objLabCheckItemArr[i] != null)
				{
					objLabCheckGroupItemArr[i].m_objLabCheckItem = objLabCheckItemArr[i];
					objLabCheckGroupItemArr[i].m_objLabCheckGroup = (clsLabCheckGroup)trvGroup.SelectedNode.Tag;

					ListViewItem lsvItem = new ListViewItem(new string[]{objLabCheckItemArr[i].m_strLabItemID,objLabCheckItemArr[i].m_strLabItemDesc});

					lsvItem.Tag = objLabCheckGroupItemArr[i];

					lsvItemGroup.Items.Add(lsvItem);
				}
			}//end for
			
			Cursor.Current = Cursors.Default;
		}

		/// <summary>
		/// 初始化TreeView
		/// </summary>
		private void m_mthInitializeTreeView()
		{
			Cursor.Current = Cursors.WaitCursor;

			TreeNode trvNode = new TreeNode("检验项目组");
			trvNode.Tag = "0";
			trvGroup.Nodes.Add(trvNode);

			long lngRes = m_objLabCheckItemAdminDomain.m_lngGetLabCheckGroups(out m_objLabCheckGroupArr);

			if(lngRes <= 0 || m_objLabCheckGroupArr == null || m_objLabCheckGroupArr.Length == 0)
				return;

			for(int i = 0; i < m_objLabCheckGroupArr.Length; i++)
			{
				if(m_objLabCheckGroupArr[i] != null)
				{
					trvNode = new TreeNode(m_objLabCheckGroupArr[i].m_strLabGroupName);
					trvNode.Tag = m_objLabCheckGroupArr[i];

					trvGroup.Nodes[0].Nodes.Add(trvNode);
				}
			}

			trvGroup.ExpandAll();

			Cursor.Current = Cursors.Default;

		}
		#endregion

		#region 右键菜单

		#region ctmGroup
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ctmGroup_Popup(object sender, System.EventArgs e)
		{
			if(trvGroup.SelectedNode == trvGroup.Nodes[0])
			{
				mniDeleteGroup.Visible = false;
				mniRename.Visible = false;
				mniAddGroup.Visible = true;
			}
			else
			{
				mniDeleteGroup.Visible = true;
				mniRename.Visible = true;
				mniAddGroup.Visible = false;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mniAddGroup_Click(object sender, System.EventArgs e)
		{
#if FunctionPrivilege
			if(!clsPublicFunction.s_blnCheckCurrentPrivilege(PrivilegeData.enmPrivilegeSF.frmLabCheckItemAdmin,PrivilegeData.enmPrivilegeOperation.AddOrModify))
			{
				clsPublicFunction.s_mthShowNotPermitMessage();
				return;
			}			
#endif
			frmInputBox objInputBox = new frmInputBox();

			objInputBox.m_ObjParent = this;

			objInputBox.ShowDialog();

			if(objInputBox.DialogResult == DialogResult.Cancel)
				return;

			clsLabCheckGroup objLabCheckGroup = new clsLabCheckGroup();

			string strMaxGroupID;

			m_objLabCheckItemAdminDomain.m_lngGetMaxGroupID(out strMaxGroupID);

			objLabCheckGroup.m_strLabGroupID = (int.Parse(strMaxGroupID) + 1).ToString("00000");
			objLabCheckGroup.m_strLabGroupName = m_strGroupName;

			long lngRes = m_objLabCheckItemAdminDomain.m_lngAddNewGroup(objLabCheckGroup);
			if(lngRes<=0)
				return;

			TreeNode trvNode = new TreeNode(m_strGroupName);
			trvNode.Tag = objLabCheckGroup;

			this.trvGroup.Nodes[0].Nodes.Add(trvNode);

			this.trvGroup.ExpandAll();

			this.trvGroup.SelectedNode = trvNode;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mniDeleteGroup_Click(object sender, System.EventArgs e)
		{
#if FunctionPrivilege
			if(!clsPublicFunction.s_blnCheckCurrentPrivilege(PrivilegeData.enmPrivilegeSF.frmLabCheckItemAdmin,PrivilegeData.enmPrivilegeOperation.Delete))
			{
				clsPublicFunction.s_mthShowNotPermitMessage();
				return;
			}			
#endif
			long lngRes = m_objLabCheckItemAdminDomain.m_lngDeleteGroup(((clsLabCheckGroup)trvGroup.SelectedNode.Tag).m_strLabGroupID);

			if(lngRes > 0)
			{
				trvGroup.SelectedNode.Remove();
				trvGroup.SelectedNode = trvGroup.Nodes[0];
			}

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mniRename_Click(object sender, System.EventArgs e)
		{
#if FunctionPrivilege
			if(!clsPublicFunction.s_blnCheckCurrentPrivilege(PrivilegeData.enmPrivilegeSF.frmLabCheckItemAdmin,PrivilegeData.enmPrivilegeOperation.AddOrModify))
			{
				clsPublicFunction.s_mthShowNotPermitMessage();
				return;
			}			
#endif
			frmInputBox objInputBox = new frmInputBox();

			objInputBox.m_ObjParent = this;

			objInputBox.ShowDialog();

			if(objInputBox.DialogResult == DialogResult.Cancel)
				return;

			clsLabCheckGroup objLabCheckGroup = (clsLabCheckGroup)trvGroup.SelectedNode.Tag;
			objLabCheckGroup.m_strLabGroupName = m_strGroupName;

			long lngRes = m_objLabCheckItemAdminDomain.m_lngModifyGroupDesc(objLabCheckGroup.m_strLabGroupID,objLabCheckGroup);
			if(lngRes <= 0)
				return;
			
			trvGroup.SelectedNode.Text = m_StrGroupName;
		}


		#endregion

		#region ctmItem
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ctmItem_Popup(object sender, System.EventArgs e)
		{
			if(trvGroup.SelectedNode == trvGroup.Nodes[0])
			{
				mniAddToGroup.Enabled = false;
				return ;
			}

			if(lsvCheckItem.SelectedItems.Count != 0)
				mniAddToGroup.Enabled = true;
			else
				mniAddToGroup.Enabled = false;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mniAddToGroup_Click(object sender, System.EventArgs e)
		{
#if FunctionPrivilege
			if(!clsPublicFunction.s_blnCheckCurrentPrivilege(PrivilegeData.enmPrivilegeSF.frmLabCheckItemAdmin,PrivilegeData.enmPrivilegeOperation.AddOrModify))
			{
				clsPublicFunction.s_mthShowNotPermitMessage();
				return;
			}			
#endif
			if(lsvCheckItem.SelectedItems.Count == 0)
				return;

			for(int i = 0;i < lsvItemGroup.Items.Count; i++)
			{
				if(lsvItemGroup.Items[i].SubItems[0].Text.Trim() == lsvCheckItem.SelectedItems[0].SubItems[0].Text.Trim())
				{
					clsPublicFunction.ShowInformationMessageBox("该组中已经存在该项目！");
					return;
				}
			}

			clsLabCheckGroupItem objLabCheckGroupItem = new clsLabCheckGroupItem();
			objLabCheckGroupItem.m_objLabCheckGroup = (clsLabCheckGroup)trvGroup.SelectedNode.Tag;
			objLabCheckGroupItem.m_objLabCheckItem = (clsLabCheckItem)lsvCheckItem.SelectedItems[0].Tag;

			ListViewItem lsvItem = new ListViewItem(new string[]{objLabCheckGroupItem.m_objLabCheckItem.m_strLabItemID,objLabCheckGroupItem.m_objLabCheckItem.m_strLabItemDesc});
			lsvItem.Tag = objLabCheckGroupItem;
			lsvItemGroup.Items.Add(lsvItem);
		}
		#endregion

		#region ctmItemGroup
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ctmItemGroup_Popup(object sender, System.EventArgs e)
		{
			if(this.lsvItemGroup.SelectedItems.Count == 0)
			{
				mniDeleteFromGroup.Visible = false;
			}
			else
			{
				mniDeleteFromGroup.Visible = true;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mniDeleteFromGroup_Click(object sender, System.EventArgs e)
		{
#if FunctionPrivilege
			if(!clsPublicFunction.s_blnCheckCurrentPrivilege(PrivilegeData.enmPrivilegeSF.frmLabCheckItemAdmin,PrivilegeData.enmPrivilegeOperation.Delete))
			{
				clsPublicFunction.s_mthShowNotPermitMessage();
				return;
			}			
#endif
			lsvItemGroup.Items.Remove(lsvItemGroup.SelectedItems[0]);
		}
		#endregion

		#endregion

		/// <summary>
		/// 保存分组信息
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdApply_Click(object sender, System.EventArgs e)
		{
#if FunctionPrivilege
			if(!clsPublicFunction.s_blnCheckCurrentPrivilege(PrivilegeData.enmPrivilegeSF.frmLabCheckItemAdmin,PrivilegeData.enmPrivilegeOperation.AddOrModify))
			{
				clsPublicFunction.s_mthShowNotPermitMessage();
				return;
			}			
#endif
			if(lsvItemGroup.Items.Count == 0)
			{
				clsPublicFunction.ShowInformationMessageBox("组的项目不能为空！");
				return;
			}

			Cursor.Current = Cursors.WaitCursor;

			clsLabCheckGroupItem[] objLabCheckGroupItemArr = new clsLabCheckGroupItem[lsvItemGroup.Items.Count];

			for(int i = 0; i < lsvItemGroup.Items.Count; i++)
			{
				objLabCheckGroupItemArr[i] = new clsLabCheckGroupItem();
				objLabCheckGroupItemArr[i] = (clsLabCheckGroupItem)lsvItemGroup.Items[i].Tag;
			}

			m_objLabCheckItemAdminDomain.m_lngModifyGroupItem(((clsLabCheckGroup)trvGroup.SelectedNode.Tag).m_strLabGroupID);
			m_objLabCheckItemAdminDomain.m_lngAddNewGroupItem(objLabCheckGroupItemArr);

			Cursor.Current = Cursors.Default;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void trvGroup_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if(trvGroup.SelectedNode == trvGroup.Nodes[0])
			{
				cmdApply.Enabled = false;
				lsvItemGroup.Items.Clear();
				return;
			}

			cmdApply.Enabled = true;
			lsvItemGroup.Items.Clear();
			m_mthInitializeGroupItem();
		}

		private void frmLabCheckItemAdmin_Load(object sender, System.EventArgs e)
		{
			this.trvGroup.SelectedNode = trvGroup.Nodes[0];
			m_objHighLight.m_mthAddControlInContainer(this);	
		}

		private void lsvItemGroup_DoubleClick(object sender, System.EventArgs e)
		{
		
		}

		#region Properties
		/// <summary>
		/// 
		/// </summary>
		public string m_StrGroupName
		{
			get 
			{
				return m_strGroupName;
			}
			set
			{
				m_strGroupName = value;
			}
		}
		#endregion
	}
}
