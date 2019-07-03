using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.GLS_WS.VO;
using com.digitalwave.GLS_WS.Logic;
using com.digitalwave.iCare.ValueObject;
using DigitalWave;
using com.digitalwave.iCare.middletier.HIS;
using com.digitalwave.GLS_WS.ApplyReportServer;

namespace com.digitalwave.GLS_WS.UI
{
	/// <summary>
	///摘要说明：选择多个申请单类型，并保存
	/// </summary>
	public class frmSelectType : BaseForm
	{
		private DataProcess dataProc;// = new com.digitalwave.GLS_WS.Data.DataProcess();
		private bool enterListView = false;
		private DataTable dtPart;
		private DataTable dtAim;
		private bool IsActivateChecked = true;
		internal FormPrinter printer = null;
		private ProjectEditor objProEdit;
		private clsApplyRecord objAR_VO;
        private clsChargeItemSvc objChargeItem;	
		private string strApplyID = "";

		#region Control Declarations

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.ComboBox cbPart;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private PinkieControls.ButtonXP btnOK;
		private System.Windows.Forms.ComboBox cbAim;
		private System.Windows.Forms.ListView lvApplies;
		private System.Windows.Forms.ColumnHeader ID;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.ContextMenu contextMenu2;
		private System.Windows.Forms.ContextMenu contextMenu3;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private PinkieControls.ButtonXP btnCancel;
		private PinkieControls.ButtonXP m_cmdDirctPrint;
		private PinkieControls.ButtonXP m_cmdPrintReview;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtChargeDetail;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ComboBox cmdTerm;
		protected System.Windows.Forms.ListView lsvChargeDetail;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.Button button1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		public frmSelectType()
		{
			InitializeComponent();
			//objChargeItem = new clsChargeItemSvc();
            objChargeItem = (clsChargeItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsChargeItemSvc));
            dataProc = (DataProcess)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(DataProcess));
		}

		public frmSelectType(clsApplyRecord vo)
		{
			InitializeComponent();
			printer = new FormPrinter ();			
			objProEdit = new ProjectEditor(this);
			objAR_VO = vo;
            objChargeItem = (clsChargeItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsChargeItemSvc));
                //new clsChargeItemSvc();

			this.cmdTerm.Text = "编号";
            dataProc = (DataProcess)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(DataProcess));
		}
		
		#region Windows 窗体设计器生成的代码

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

		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.lvApplies = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.ID = new System.Windows.Forms.ColumnHeader();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cmdTerm = new System.Windows.Forms.ComboBox();
			this.txtChargeDetail = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cbPart = new System.Windows.Forms.ComboBox();
			this.cbAim = new System.Windows.Forms.ComboBox();
			this.label35 = new System.Windows.Forms.Label();
			this.label34 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.contextMenu2 = new System.Windows.Forms.ContextMenu();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.contextMenu3 = new System.Windows.Forms.ContextMenu();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.btnOK = new PinkieControls.ButtonXP();
			this.btnCancel = new PinkieControls.ButtonXP();
			this.m_cmdDirctPrint = new PinkieControls.ButtonXP();
			this.m_cmdPrintReview = new PinkieControls.ButtonXP();
			this.lsvChargeDetail = new System.Windows.Forms.ListView();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lvApplies
			// 
			this.lvApplies.CheckBoxes = true;
			this.lvApplies.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader1,
																						this.columnHeader2,
																						this.columnHeader3,
																						this.columnHeader4,
																						this.ID});
			this.lvApplies.FullRowSelect = true;
			this.lvApplies.HideSelection = false;
			this.lvApplies.Location = new System.Drawing.Point(8, 8);
			this.lvApplies.MultiSelect = false;
			this.lvApplies.Name = "lvApplies";
			this.lvApplies.Size = new System.Drawing.Size(632, 256);
			this.lvApplies.TabIndex = 0;
			this.lvApplies.View = System.Windows.Forms.View.Details;
			this.lvApplies.Leave += new System.EventHandler(this.lvApplies_Leave);
			this.lvApplies.SelectedIndexChanged += new System.EventHandler(this.lvApplies_SelectedIndexChanged);
			this.lvApplies.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lvApplies_ItemCheck);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "检查类型";
			this.columnHeader1.Width = 120;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "部位或组织";
			this.columnHeader2.Width = 100;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "目的或要求";
			this.columnHeader3.Width = 100;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "收费信息";
			this.columnHeader4.Width = 300;
			// 
			// ID
			// 
			this.ID.Text = "ID";
			this.ID.Width = 0;
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItem1,
																						 this.menuItem2});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.Text = "新增检查类型";
			this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.Text = "删除检查类型";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cmdTerm);
			this.groupBox1.Controls.Add(this.txtChargeDetail);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.cbPart);
			this.groupBox1.Controls.Add(this.cbAim);
			this.groupBox1.Controls.Add(this.label35);
			this.groupBox1.Controls.Add(this.label34);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Location = new System.Drawing.Point(8, 272);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(632, 112);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			// 
			// cmdTerm
			// 
			this.cmdTerm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmdTerm.Items.AddRange(new object[] {
														 "编号",
														 "项目名称",
														 "拼音码",
														 "五笔码",
														 "英文名"});
			this.cmdTerm.Location = new System.Drawing.Point(104, 80);
			this.cmdTerm.Name = "cmdTerm";
			this.cmdTerm.Size = new System.Drawing.Size(80, 22);
			this.cmdTerm.TabIndex = 7;
			// 
			// txtChargeDetail
			// 
			this.txtChargeDetail.BackColor = System.Drawing.SystemColors.Window;
			this.txtChargeDetail.Location = new System.Drawing.Point(192, 80);
			this.txtChargeDetail.Name = "txtChargeDetail";
			this.txtChargeDetail.Size = new System.Drawing.Size(400, 23);
			this.txtChargeDetail.TabIndex = 6;
			this.txtChargeDetail.Text = "";
			this.txtChargeDetail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChargeDetail_KeyDown);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 80);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(92, 19);
			this.label1.TabIndex = 5;
			this.label1.Text = "收费信息查询";
			// 
			// cbPart
			// 
			this.cbPart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbPart.Location = new System.Drawing.Point(168, 16);
			this.cbPart.Name = "cbPart";
			this.cbPart.Size = new System.Drawing.Size(456, 22);
			this.cbPart.TabIndex = 0;
			this.cbPart.TextChanged += new System.EventHandler(this.ComboChanged);
			this.cbPart.SelectedIndexChanged += new System.EventHandler(this.ComboChanged);
			// 
			// cbAim
			// 
			this.cbAim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbAim.Location = new System.Drawing.Point(168, 48);
			this.cbAim.Name = "cbAim";
			this.cbAim.Size = new System.Drawing.Size(456, 22);
			this.cbAim.TabIndex = 1;
			this.cbAim.TextChanged += new System.EventHandler(this.ComboChanged);
			this.cbAim.SelectedIndexChanged += new System.EventHandler(this.ComboChanged);
			// 
			// label35
			// 
			this.label35.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label35.Location = new System.Drawing.Point(7, 50);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(177, 17);
			this.label35.TabIndex = 4;
			this.label35.Text = "申请检查目的或其它要求";
			this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label34
			// 
			this.label34.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label34.Location = new System.Drawing.Point(7, 18);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(185, 17);
			this.label34.TabIndex = 3;
			this.label34.Text = "申请检查部位或送检组织";
			this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(600, 80);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(24, 23);
			this.button1.TabIndex = 8;
			this.button1.Text = "↑";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// contextMenu2
			// 
			this.contextMenu2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItem3,
																						 this.menuItem4});
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 0;
			this.menuItem3.Text = "保存";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 1;
			this.menuItem4.Text = "删除";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// contextMenu3
			// 
			this.contextMenu3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItem5,
																						 this.menuItem6});
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 0;
			this.menuItem5.Text = "保存";
			this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 1;
			this.menuItem6.Text = "删除";
			this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
			// 
			// btnOK
			// 
			this.btnOK.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btnOK.DefaultScheme = true;
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btnOK.Hint = "";
			this.btnOK.Location = new System.Drawing.Point(354, 392);
			this.btnOK.Name = "btnOK";
			this.btnOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btnOK.Size = new System.Drawing.Size(96, 32);
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "确定(&O)";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btnCancel.DefaultScheme = true;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Hint = "";
			this.btnCancel.Location = new System.Drawing.Point(519, 392);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btnCancel.Size = new System.Drawing.Size(96, 32);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "取消(&C)";
			// 
			// m_cmdDirctPrint
			// 
			this.m_cmdDirctPrint.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdDirctPrint.DefaultScheme = true;
			this.m_cmdDirctPrint.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdDirctPrint.Hint = "";
			this.m_cmdDirctPrint.Location = new System.Drawing.Point(24, 392);
			this.m_cmdDirctPrint.Name = "m_cmdDirctPrint";
			this.m_cmdDirctPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdDirctPrint.Size = new System.Drawing.Size(96, 32);
			this.m_cmdDirctPrint.TabIndex = 5;
			this.m_cmdDirctPrint.Text = "直接打印";
			this.m_cmdDirctPrint.Click += new System.EventHandler(this.m_cmdDirctPrint_Click);
			// 
			// m_cmdPrintReview
			// 
			this.m_cmdPrintReview.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdPrintReview.DefaultScheme = true;
			this.m_cmdPrintReview.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdPrintReview.Hint = "";
			this.m_cmdPrintReview.Location = new System.Drawing.Point(189, 392);
			this.m_cmdPrintReview.Name = "m_cmdPrintReview";
			this.m_cmdPrintReview.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdPrintReview.Size = new System.Drawing.Size(96, 32);
			this.m_cmdPrintReview.TabIndex = 6;
			this.m_cmdPrintReview.Text = "打印预览";
			this.m_cmdPrintReview.Click += new System.EventHandler(this.m_cmdPrintReview_Click);
			// 
			// lsvChargeDetail
			// 
			this.lsvChargeDetail.BackColor = System.Drawing.Color.White;
			this.lsvChargeDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lsvChargeDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							  this.columnHeader6,
																							  this.columnHeader5,
																							  this.columnHeader7,
																							  this.columnHeader8,
																							  this.columnHeader9});
			this.lsvChargeDetail.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lsvChargeDetail.ForeColor = System.Drawing.Color.Black;
			this.lsvChargeDetail.FullRowSelect = true;
			this.lsvChargeDetail.GridLines = true;
			this.lsvChargeDetail.Location = new System.Drawing.Point(200, 192);
			this.lsvChargeDetail.Name = "lsvChargeDetail";
			this.lsvChargeDetail.Size = new System.Drawing.Size(432, 160);
			this.lsvChargeDetail.TabIndex = 5611;
			this.lsvChargeDetail.View = System.Windows.Forms.View.Details;
			this.lsvChargeDetail.Visible = false;
			this.lsvChargeDetail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsvChargeDetail_KeyDown);
			this.lsvChargeDetail.DoubleClick += new System.EventHandler(this.lsvChargeDetail_DoubleClick);
			this.lsvChargeDetail.Leave += new System.EventHandler(this.lsvChargeDetail_Leave);
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "项目名称";
			this.columnHeader6.Width = 140;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "规格";
			this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader5.Width = 70;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "数量";
			this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "总价";
			this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "自付比例";
			this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader9.Width = 80;
			// 
			// frmSelectType
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(650, 431);
			this.Controls.Add(this.lsvChargeDetail);
			this.Controls.Add(this.m_cmdDirctPrint);
			this.Controls.Add(this.m_cmdPrintReview);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.lvApplies);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmSelectType";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "选择检查类型";
			this.Load += new System.EventHandler(this.frmSelectType_Load);
			this.MaximumSizeChanged += new System.EventHandler(this.frmSelectType_MaximumSizeChanged);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmSelectType_MaximumSizeChanged(object sender, System.EventArgs e)
		{
			this.WindowState = FormWindowState.Normal;
		}

		private void frmSelectType_Load(object sender, System.EventArgs e)
		{
			//绑定部位和目的			
			string sqlPart = "select * from AR_APPLY_PARTLIST where Deleted <> 1";
			string sqlAim  = "select * from AR_APPLY_AIMLIST where Deleted <> 1";
			DataTable dsPart = dataProc.SqlSelect(sqlPart);
			DataTable dsAim  = dataProc.SqlSelect(sqlAim);
			this.dtPart = dsPart;
			this.dtAim  = dsAim;

			//读取检查类型
			DataTable dsApplies = dataProc.GetApplyList();
			foreach(DataRow dr in dsApplies.Rows)
			{
				ListViewItem i = lvApplies.Items.Add(dr["TypeText"].ToString().Trim());
				i.SubItems.AddRange(new string[]{"", "", "",dr["TypeID"].ToString().Trim()});
			}
			if (this.lvApplies.Items.Count >0)
			{
				this.lvApplies.Items[0].Selected = true;
				ShowSubText(this.lvApplies.SelectedItems[0]);
			}

			
		}

		private void lvApplies_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
		{
			enterListView = true;

			if (!this.IsActivateChecked)
			{
				return;
			}
			
			ListViewItem item = lvApplies.Items[e.Index];	
			item.Selected = true;
			if (e.NewValue == CheckState.Checked)
			{	
				this.groupBox1.Enabled = true;
				ShowSubText(item);
			}
			else
			{
				cbAim.Text = "";
				cbPart.Text = "";
				txtChargeDetail.Text = "";
				this.groupBox1.Enabled = false;
			}
		}

		private void ComboChanged(object sender, System.EventArgs e)
		{
			if (enterListView)
				return;			

			if (this.lvApplies.SelectedItems.Count == 0)
				return;			

			ListViewItem item = this.lvApplies.SelectedItems[0];

			if (!item.Checked)
				return;

			if (!enterListView )
			{
				item.SubItems[1].Text = this.cbPart.Text;
				item.SubItems[2].Text = this.cbAim.Text;
			}
		}

		private void ShowSubText(ListViewItem item)
		{
			if (enterListView)
			{
				//显示相应的部位和目的 
				cbPart.Items.Clear();
				cbAim.Items.Clear();
				txtChargeDetail.Clear();
				string id = item.SubItems[4].Text;
				DataRow[] rows = dtPart.Select("TypeID = " + id);

				foreach(DataRow dr in rows)
				{
					cbPart.Items.Add(dr["PartName"].ToString());
				}

				rows = dtAim.Select("TypeID = " + id);
				foreach(DataRow dr in rows)
				{
					cbAim.Items.Add(dr["AimText"].ToString());
				}	
			
				this.cbPart.Text = item.SubItems[1].Text;
				this.cbAim.Text  = item.SubItems[2].Text;

				strApplyID = id;
			}			
		}

		private void lvApplies_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			enterListView = true;

			if (this.lvApplies.SelectedItems == null) return;
			if (this.lvApplies.SelectedItems.Count == 0)
				return;
			
			ListViewItem item = this.lvApplies.SelectedItems[0];					

			if (lvApplies.CheckBoxes == false)
			{
				this.IsActivateChecked = false;
				foreach(ListViewItem i in this.lvApplies.Items)
				{
					if ( (i!= item) && (i.Checked == true))
					{
						i.SubItems[1].Text = "";
						i.SubItems[2].Text = "";
						i.SubItems[3].Text = "";
						i.Checked = false;
					}
				}
				item.Checked = true;
			}			

			
			ShowSubText(item);
			this.groupBox1.Enabled = item.Checked;			
		}

		private void lvApplies_Leave(object sender, System.EventArgs e)
		{
			enterListView = false;
		}

		/// <summary>
		/// 显示多选检查类型对话框
		/// </summary>
		/// <returns></returns>
		public static clsCheckType[] ShowSelect()
		{
			frmSelectType fm = new frmSelectType();

			if (fm.ShowDialog() == DialogResult.Cancel)
			{
				return null;
			}

            int count = fm.lvApplies.CheckedItems.Count;
			int i = 0;
			clsCheckType[] checkTypes = new clsCheckType[count];
			
			foreach(ListViewItem item in fm.lvApplies.CheckedItems)
			{
				checkTypes[i] = new clsCheckType();
                checkTypes[i].m_strTypeName  = item.Text.Trim();
				checkTypes[i].m_strCheckPart = item.SubItems[1].Text.Trim();
				checkTypes[i].m_strCheckAim  = item.SubItems[2].Text.Trim();
				checkTypes[i].m_strChargeDetail = item.SubItems[3].Text.Trim();
				checkTypes[i].m_strTypeID    = item.SubItems[4].Text.Trim();
				checkTypes[i].objItem_VO = item.Tag as clsChargeItem_VO;
				i++;
			}		
            
			return checkTypes;
		}

		/// <summary>
		/// 显示单选检查类型框
		/// </summary>		
		/// <returns></returns>
		public static clsCheckType[] ShowSingleSelect()
		{
			frmSelectType fm = new frmSelectType();
			fm.lvApplies.CheckBoxes = false;
			fm.lvApplies.MultiSelect = false;
            //fm.lblChargeInfo.Text = chargeInfo;

			if (fm.ShowDialog() == DialogResult.Cancel)
			{
				return null;
			}
	
			if (fm.lvApplies.SelectedItems.Count < 1)
			{
				return null;
			}

			ListViewItem item = fm.lvApplies.SelectedItems[0];
			clsCheckType checkType = new clsCheckType();
			checkType.m_strTypeName  = item.Text.Trim();
			checkType.m_strCheckPart = item.SubItems[1].Text.Trim();
			checkType.m_strCheckAim  = item.SubItems[2].Text.Trim();
			checkType.m_strChargeDetail = item.SubItems[3].Text.Trim();
			checkType.m_strTypeID    = item.SubItems[4].Text.Trim();
			checkType.objItem_VO = item.Tag as clsChargeItem_VO;

			clsCheckType[] c = new clsCheckType[1];
			c[0] = checkType;

			return c;
		}


		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if (this.lvApplies.SelectedItems.Count < 1)
			{
				this.ShowAlert("您尚未选择任何检查类型！");
				return;
			}

			if (DialogResult.Yes == this.ShowPrompt("你确认要发送检查单吗?"))
			{
				this.DialogResult = DialogResult.OK;	
			}	

		}


		#region 右键菜单
		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			string newType = this.ShowInput("请输入新的检查类型:");
			if (newType != "")
			{
				string nextID = dataProc.GetNextID("AR_APPLY_TYPELIST","TYPEID");
                string sql = "insert into AR_APPLY_TYPELIST (TypeID,TYPETEXT) values({0},'{1}')";
				if (dataProc.SqlExecute( string.Format(sql, nextID,newType) ) )
				{
					ListViewItem item = new ListViewItem(newType);
					item.SubItems.AddRange(new string[]{"","",nextID});
					this.lvApplies.Items.Add(item);
				}
			}		

		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			if (this.lvApplies.SelectedItems.Count < 1)
			{
				return;
			}

			string id = this.lvApplies.SelectedItems[0].SubItems[3].Text;
			string sql = "delete from AR_APPLY_TYPELIST where TypeID = " + id;
			if (dataProc.SqlExecute(sql))
			{
				this.lvApplies.SelectedItems[0].Remove();	
			}
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			//增加检查组织
			string newPart = this.cbPart.Text;	

			if (newPart == "")
			{
				this.ShowAlert("新值不能为空！");	
				return;
			}

			if ( !cbPart.Items.Contains(newPart) )
			{
				string nextID = dataProc.GetNextID("AR_APPLY_PARTLIST","PARTID");
				string sql = "insert into AR_APPLY_PARTLIST (PARTID,PARTNAME) values({0},'{1}')";
				if (dataProc.SqlExecute( string.Format(sql, nextID,newPart)) )
				{
					cbPart.Items.Add(newPart);
				}
			}		

		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			//删除部位
			string part = this.cbPart.Text;
			string sql  = "delete from AR_APPLY_PARTLIST where PartName = '" + part + "' ";
			if (this.cbPart.Items.IndexOf(part) >=0)
			{
				if (dataProc.SqlExecute(sql))
				{
					this.cbPart.Items.Remove(part);
					this.cbPart.Text = "";
				}
			}
		}

		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			//增加新目的
			string newAim = this.cbAim.Text;	
			
			if (newAim == "")
			{
				this.ShowAlert("新值不能为空！");	
				return;
			}

			if ( !cbAim.Items.Contains(newAim) )
			{
				string nextID = dataProc.GetNextID("AR_APPLY_AIMLIST","AIMID");
				string sql = "insert into AR_APPLY_AIMLIST (AIMID,AIMTEXT) values({0},'{1}')";
				if (dataProc.SqlExecute( string.Format(sql, nextID,newAim) ))
				{
					this.cbAim.Items.Add(newAim);
				}
			}		

		}

		private void menuItem6_Click(object sender, System.EventArgs e)
		{
			//删除目的
			string aim = this.cbAim.Text;
			string sql  = "delete from AR_APPLY_AIMLIST where AIMTEXT = '" + aim + "' ";
			if (this.cbAim.Items.IndexOf(aim) >=0)
			{
				if (dataProc.SqlExecute(sql))
				{
					this.cbAim.Items.Remove(aim);
					this.cbAim.Text = "";
				}
			}

		}



		#endregion

		/// <summary>
		/// 显示多选检查类型对话框(带VO)
		/// </summary>
		/// <returns></returns>
		public static clsCheckType[] ShowSelect(clsApplyRecord vo)
		{
			frmSelectType fm = new frmSelectType(vo); 
			if (fm.ShowDialog() == DialogResult.Cancel)
			{
				return null;
			}

			int count = fm.lvApplies.CheckedItems.Count;
			int i = 0;
			clsCheckType[] checkTypes = new clsCheckType[count];
			
			foreach(ListViewItem item in fm.lvApplies.CheckedItems)
			{
				checkTypes[i] = new clsCheckType();
				checkTypes[i].m_strTypeName  = item.Text.Trim();
				checkTypes[i].m_strCheckPart = item.SubItems[1].Text.Trim();
				checkTypes[i].m_strCheckAim  = item.SubItems[2].Text.Trim();
				checkTypes[i].m_strChargeDetail = item.SubItems[3].Text.Trim();
				checkTypes[i].m_strTypeID    = item.SubItems[4].Text.Trim();
				checkTypes[i].objItem_VO = item.Tag as clsChargeItem_VO;
				i++;
			}		
            
			return checkTypes;
		}

		public clsCheckType[] SelectType()
		{
			int count = this.lvApplies.CheckedItems.Count;
			if(count == 0)
			{
				MessageBox.Show("请选择检查类型！");
				return null;
			}
			int i = 0;
			clsCheckType[] checkTypes = new clsCheckType[count];
			
			foreach(ListViewItem item in this.lvApplies.CheckedItems)
			{
				checkTypes[i] = new clsCheckType();
				checkTypes[i].m_strTypeName  = item.Text.Trim();
				checkTypes[i].m_strCheckPart = item.SubItems[1].Text.Trim();
				checkTypes[i].m_strCheckAim  = item.SubItems[2].Text.Trim();
				checkTypes[i].m_strChargeDetail = item.SubItems[3].Text.Trim();
				checkTypes[i].m_strTypeID    = item.SubItems[4].Text.Trim();
				checkTypes[i].objItem_VO = item.Tag as clsChargeItem_VO;
				i++;
			}
           
			return checkTypes;
		}

		private void m_cmdPrintReview_Click(object sender, System.EventArgs e)
		{
			printer.SelectTypePrintPreview(objProEdit.dsPrintVO(objAR_VO));
		}

		private void m_cmdDirctPrint_Click(object sender, System.EventArgs e)
		{
			printer.SelectTypePrint(objProEdit.dsPrintVO(objAR_VO));
		}

		private void txtChargeDetail_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyValue == 13)
			{
				string strFindType = "";  
				string strItem = txtChargeDetail.Text.Trim();
				switch(cmdTerm.Text.Trim())
				{
					case "编号":
						strFindType = "ITEMCODE_VCHR";
						break;
					case "项目名称":
						strFindType = "ITEMNAME_VCHR";
						break;
					case "拼音码":
						strFindType = "ITEMPYCODE_CHR";
						strItem = strItem.ToUpper();
						break;
					case "五笔码":
						strFindType = "ITEMWBCODE_CHR";
						break;
					case "英文名":
						strFindType = "ITEMENGNAME_VCHR";
						break;
				}
				m_mthGetChargeItem(strApplyID,strItem,strFindType);
			}
		} 

		private void m_mthGetChargeItem(string strApplyID, string strItem, string strFindType)
		{
			clsChargeItem_VO[] objResult;
			long lngres = objChargeItem.m_mthGetChargeItemByApplyTypeID(strApplyID,strItem,strFindType,out objResult);
			if(objResult != null)
			{
				lsvChargeDetail.Items.Clear();
				lsvChargeDetail.BeginUpdate();

				for(int j=0; j<objResult.Length; j++)
				{
					ListViewItem i = lsvChargeDetail.Items.Add(objResult[j].m_strItemName);
					i.SubItems.AddRange(new string[]{objResult[j].m_strItemSpec, "1"+objResult[j].m_ItemUnit.m_strUnitID, objResult[j].m_fltItemPrice.ToString(),"100%"});
					i.Tag = objResult[j];
				}

				lsvChargeDetail.EndUpdate();
				lsvChargeDetail.Visible = true;
				lsvChargeDetail.Focus();
				txtChargeDetail.Text = "";
			}
		}
		/// <summary>
		/// 格式化查询到的收费信息为文本
		/// </summary>
		/// <param name="objResult"></param>
		/// <returns></returns>
		private string GetChargeInfo(clsChargeItem_VO objResult)
		{
			string fee = "{0}  {1}  {2}{3}  {4}  {5}";
			
			return String.Format(fee, 
				objResult.m_strItemName,
				objResult.m_strItemSpec,
				"1",
				objResult.m_ItemUnit.m_strUnitID,				
				objResult.m_fltItemPrice,
				"100%");
		}

		private void m_mthSetChargeItem()
		{
			ListViewItem item = this.lvApplies.SelectedItems[0];
			foreach(ListViewItem chargeItem in this.lsvChargeDetail.SelectedItems)
			{
				item.SubItems[3].Text = chargeItem.Text + " " +chargeItem.SubItems[1].Text +"  "+chargeItem.SubItems[2].Text+"  "+chargeItem.SubItems[3].Text+"元  "+chargeItem.SubItems[4].Text;
				
				item.Tag = chargeItem.Tag;
			}
			lsvChargeDetail.Visible = false;
		}

		private void lsvChargeDetail_DoubleClick(object sender, System.EventArgs e)
		{ 
			m_mthSetChargeItem();
		}

		private void lsvChargeDetail_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyValue == 13)
			{
				m_mthSetChargeItem();
			}
		}

		private void lsvChargeDetail_Leave(object sender, System.EventArgs e)
		{
			lsvChargeDetail.Visible = false;
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
		   m_mthGetChargeItem(strApplyID,"","");
		}

	}
}
