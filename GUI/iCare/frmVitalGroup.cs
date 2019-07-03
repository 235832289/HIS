using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using iCareData;

using com.digitalwave.Utility.Controls;

namespace iCare
{
	/// <summary>
	/// Summary description for frmVitalGroup.
	/// </summary>
	public class frmVitalGroup : iCare.iCareBaseForm.frmBaseForm
	{
		#region Control Defination

		private System.Windows.Forms.CheckedListBox chklstGroup;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdApply;
		private System.Windows.Forms.TabControl tabOptions;
		private System.Windows.Forms.TabPage tbpGroup;
		private System.Windows.Forms.TabPage tbpOption;
		private System.Windows.Forms.ListView lsvParamSet;
		private System.Windows.Forms.ColumnHeader ParameterName;
		private System.Windows.Forms.ColumnHeader Marker;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button cmdColor;
		private com.digitalwave.Utility.Controls.ctlComboBox cboMarker;
		private System.Windows.Forms.ColumnHeader cmnColor;
		private System.Windows.Forms.GroupBox gpbAlarmRange;
		private System.Windows.Forms.ColumnHeader clmMaxAlarm;
		private System.Windows.Forms.ColumnHeader clmMinAlarm;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown NUDMinAlarm;
		private System.Windows.Forms.NumericUpDown NUDMaxAlarm;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox chkRefesh;
		private com.digitalwave.Utility.Controls.ctlComboBox cboRefreshRate;
		private System.Windows.Forms.Label lblRefreshRate;
		private System.Windows.Forms.CheckedListBox lstGroupItem;
		private System.Windows.Forms.ContextMenu m_ctmItemSelect;
		private System.Windows.Forms.MenuItem mniSelectAll;
		private System.Windows.Forms.MenuItem mniUnselectAll;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region Constructor
		public frmVitalGroup()
		{
			InitializeComponent();

            //m_objBorderTool = new clsBorderTool(Color.White);
            //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{this.chklstGroup
            //                                                              ,this.lstGroupItem,this.lsvParamSet,this.NUDMaxAlarm,this.NUDMinAlarm});	
            

			cboMarker.AddItem("空心正方形");
			cboMarker.AddItem("实心正方形");
			cboMarker.AddItem("空心圆形");
			cboMarker.AddItem("星号");
			cboMarker.AddItem("加号");
			cboMarker.AddItem("上箭头");
			cboMarker.AddItem("下箭头");

			cboRefreshRate.AddItem("1分钟");
			cboRefreshRate.AddItem("5分钟");
			cboRefreshRate.AddItem("10分钟");
			cboRefreshRate.AddItem("15分钟");
			cboRefreshRate.AddItem("30分钟");

			cboRefreshRate.SelectedIndex = 1;

			m_objHighLight = new ctlHighLightFocus(clsHRPColor.s_ClrHightLight);
			m_objHighLight.m_mthAddControlInContainer(this);	
		}
		#endregion

		#region Member
		private ctlHighLightFocus m_objHighLight;

		private int[] m_intMarkerIndexArr;

        //private com.digitalwave.Utility.Controls.clsBorderTool m_objBorderTool;

		/// <summary>
		/// 
		/// </summary>
		private clsVitalGroup[] m_objVitalGroupArr;

		/// <summary>
		/// 
		/// </summary>
		private clsVitalSet[] m_objVitalSetArr;

		/// <summary>
		/// 
		/// </summary>
		private frmICUTrend m_objParent;

		/// <summary>
		/// 
		/// </summary>
		private ArrayList m_arlCheckParam = new ArrayList();

		/// <summary>
		/// 标记是否处理参数选择改变的事件
		/// </summary>
		private bool m_blnCanGroupItemCheckChanged = true;

		/// <summary>
		/// 标记是否处理分组选择改变的事件
		/// </summary>
		private bool m_blnCanGroupCheckChanged = true;		
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmVitalGroup));
			this.chklstGroup = new System.Windows.Forms.CheckedListBox();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdOK = new System.Windows.Forms.Button();
			this.cmdApply = new System.Windows.Forms.Button();
			this.tabOptions = new System.Windows.Forms.TabControl();
			this.tbpGroup = new System.Windows.Forms.TabPage();
			this.lstGroupItem = new System.Windows.Forms.CheckedListBox();
			this.m_ctmItemSelect = new System.Windows.Forms.ContextMenu();
			this.mniSelectAll = new System.Windows.Forms.MenuItem();
			this.mniUnselectAll = new System.Windows.Forms.MenuItem();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cboRefreshRate = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.chkRefesh = new System.Windows.Forms.CheckBox();
			this.lblRefreshRate = new System.Windows.Forms.Label();
			this.tbpOption = new System.Windows.Forms.TabPage();
			this.cmdColor = new System.Windows.Forms.Button();
			this.cboMarker = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.gpbAlarmRange = new System.Windows.Forms.GroupBox();
			this.NUDMinAlarm = new System.Windows.Forms.NumericUpDown();
			this.NUDMaxAlarm = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lsvParamSet = new System.Windows.Forms.ListView();
			this.ParameterName = new System.Windows.Forms.ColumnHeader();
			this.Marker = new System.Windows.Forms.ColumnHeader();
			this.cmnColor = new System.Windows.Forms.ColumnHeader();
			this.clmMaxAlarm = new System.Windows.Forms.ColumnHeader();
			this.clmMinAlarm = new System.Windows.Forms.ColumnHeader();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tabOptions.SuspendLayout();
			this.tbpGroup.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tbpOption.SuspendLayout();
			this.gpbAlarmRange.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.NUDMinAlarm)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NUDMaxAlarm)).BeginInit();
			this.SuspendLayout();
			// 
			// chklstGroup
			// 
			this.chklstGroup.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.chklstGroup.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.chklstGroup.Font = new System.Drawing.Font("SimSun", 12F);
			this.chklstGroup.ForeColor = System.Drawing.Color.White;
			this.chklstGroup.Location = new System.Drawing.Point(8, 8);
			this.chklstGroup.Name = "chklstGroup";
			this.chklstGroup.Size = new System.Drawing.Size(192, 231);
			this.chklstGroup.TabIndex = 1;
			this.chklstGroup.SelectedIndexChanged += new System.EventHandler(this.chklstGroup_SelectedIndexChanged);
			this.chklstGroup.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chklstGroup_ItemCheck);
			// 
			// cmdCancel
			// 
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmdCancel.Font = new System.Drawing.Font("SimSun", 12F);
			this.cmdCancel.ForeColor = System.Drawing.Color.White;
			this.cmdCancel.Location = new System.Drawing.Point(612, 292);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(64, 32);
			this.cmdCancel.TabIndex = 12;
			this.cmdCancel.Text = "取消";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// cmdOK
			// 
			this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmdOK.Font = new System.Drawing.Font("SimSun", 12F);
			this.cmdOK.ForeColor = System.Drawing.Color.White;
			this.cmdOK.Location = new System.Drawing.Point(452, 292);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.Size = new System.Drawing.Size(64, 32);
			this.cmdOK.TabIndex = 10;
			this.cmdOK.Text = "确定";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// cmdApply
			// 
			this.cmdApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmdApply.Font = new System.Drawing.Font("SimSun", 12F);
			this.cmdApply.ForeColor = System.Drawing.Color.White;
			this.cmdApply.Location = new System.Drawing.Point(532, 292);
			this.cmdApply.Name = "cmdApply";
			this.cmdApply.Size = new System.Drawing.Size(64, 32);
			this.cmdApply.TabIndex = 11;
			this.cmdApply.Text = "应用";
			this.cmdApply.Click += new System.EventHandler(this.cmdApply_Click);
			// 
			// tabOptions
			// 
			this.tabOptions.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.tbpGroup,
																					 this.tbpOption});
			this.tabOptions.Dock = System.Windows.Forms.DockStyle.Top;
			this.tabOptions.Name = "tabOptions";
			this.tabOptions.SelectedIndex = 0;
			this.tabOptions.Size = new System.Drawing.Size(694, 280);
			this.tabOptions.TabIndex = 5;
			// 
			// tbpGroup
			// 
			this.tbpGroup.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.tbpGroup.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.lstGroupItem,
																				   this.groupBox1,
																				   this.chklstGroup});
			this.tbpGroup.Location = new System.Drawing.Point(4, 25);
			this.tbpGroup.Name = "tbpGroup";
			this.tbpGroup.Size = new System.Drawing.Size(686, 251);
			this.tbpGroup.TabIndex = 0;
			this.tbpGroup.Text = "分组";
			// 
			// lstGroupItem
			// 
			this.lstGroupItem.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.lstGroupItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lstGroupItem.CheckOnClick = true;
			this.lstGroupItem.ContextMenu = this.m_ctmItemSelect;
			this.lstGroupItem.Font = new System.Drawing.Font("SimSun", 12F);
			this.lstGroupItem.ForeColor = System.Drawing.Color.White;
			this.lstGroupItem.Location = new System.Drawing.Point(216, 8);
			this.lstGroupItem.Name = "lstGroupItem";
			this.lstGroupItem.Size = new System.Drawing.Size(288, 231);
			this.lstGroupItem.TabIndex = 2;
			this.lstGroupItem.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstGroupItem_ItemCheck);
			// 
			// m_ctmItemSelect
			// 
			this.m_ctmItemSelect.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							this.mniSelectAll,
																							this.mniUnselectAll});
			this.m_ctmItemSelect.Popup += new System.EventHandler(this.m_ctmItemSelect_Popup);
			// 
			// mniSelectAll
			// 
			this.mniSelectAll.Index = 0;
			this.mniSelectAll.Text = "选择全部";
			this.mniSelectAll.Click += new System.EventHandler(this.mniSelectAll_Click);
			// 
			// mniUnselectAll
			// 
			this.mniUnselectAll.Index = 1;
			this.mniUnselectAll.Text = "撤销全部";
			this.mniUnselectAll.Click += new System.EventHandler(this.mniUnselectAll_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.cboRefreshRate,
																					this.chkRefesh,
																					this.lblRefreshRate});
			this.groupBox1.Font = new System.Drawing.Font("SimSun", 12F);
			this.groupBox1.ForeColor = System.Drawing.Color.White;
			this.groupBox1.Location = new System.Drawing.Point(520, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(152, 228);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Tag = "";
			this.groupBox1.Text = "趋势图刷新";
			// 
			// cboRefreshRate
			// 
			this.cboRefreshRate.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.cboRefreshRate.BorderColor = System.Drawing.Color.White;
			this.cboRefreshRate.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.cboRefreshRate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.cboRefreshRate.DropButtonForeColor = System.Drawing.Color.White;
			this.cboRefreshRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboRefreshRate.Enabled = false;
			this.cboRefreshRate.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.cboRefreshRate.Font = new System.Drawing.Font("SimSun", 12F);
			this.cboRefreshRate.ForeColor = System.Drawing.Color.White;
			this.cboRefreshRate.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.cboRefreshRate.ListForeColor = System.Drawing.Color.White;
			this.cboRefreshRate.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.cboRefreshRate.ListSelectedForeColor = System.Drawing.Color.White;
			this.cboRefreshRate.Location = new System.Drawing.Point(8, 100);
			this.cboRefreshRate.Name = "cboRefreshRate";
			this.cboRefreshRate.SelectedIndex = -1;
			this.cboRefreshRate.SelectedItem = null;
			this.cboRefreshRate.Size = new System.Drawing.Size(136, 26);
			this.cboRefreshRate.TabIndex = 4;
			this.cboRefreshRate.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.cboRefreshRate.TextForeColor = System.Drawing.Color.White;
			this.cboRefreshRate.SelectedIndexChanged += new System.EventHandler(this.cboRefreshRate_SelectedIndexChanged);
			// 
			// chkRefesh
			// 
			this.chkRefesh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkRefesh.Location = new System.Drawing.Point(12, 36);
			this.chkRefesh.Name = "chkRefesh";
			this.chkRefesh.TabIndex = 3;
			this.chkRefesh.Text = "自动刷新";
			this.chkRefesh.CheckedChanged += new System.EventHandler(this.chkRefesh_CheckedChanged);
			// 
			// lblRefreshRate
			// 
			this.lblRefreshRate.AutoSize = true;
			this.lblRefreshRate.Enabled = false;
			this.lblRefreshRate.Font = new System.Drawing.Font("SimSun", 12F);
			this.lblRefreshRate.Location = new System.Drawing.Point(8, 76);
			this.lblRefreshRate.Name = "lblRefreshRate";
			this.lblRefreshRate.Size = new System.Drawing.Size(88, 19);
			this.lblRefreshRate.TabIndex = 417;
			this.lblRefreshRate.Text = "刷新速率：";
			// 
			// tbpOption
			// 
			this.tbpOption.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.tbpOption.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.cmdColor,
																					this.cboMarker,
																					this.gpbAlarmRange,
																					this.lsvParamSet,
																					this.label1,
																					this.label2});
			this.tbpOption.ForeColor = System.Drawing.Color.White;
			this.tbpOption.Location = new System.Drawing.Point(4, 21);
			this.tbpOption.Name = "tbpOption";
			this.tbpOption.Size = new System.Drawing.Size(686, 255);
			this.tbpOption.TabIndex = 1;
			this.tbpOption.Text = "设置";
			// 
			// cmdColor
			// 
			this.cmdColor.BackColor = System.Drawing.Color.Green;
			this.cmdColor.Enabled = false;
			this.cmdColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmdColor.Location = new System.Drawing.Point(544, 68);
			this.cmdColor.Name = "cmdColor";
			this.cmdColor.Size = new System.Drawing.Size(112, 24);
			this.cmdColor.TabIndex = 3;
			this.cmdColor.Click += new System.EventHandler(this.cmdColor_Click);
			// 
			// cboMarker
			// 
			this.cboMarker.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.cboMarker.BorderColor = System.Drawing.Color.White;
			this.cboMarker.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.cboMarker.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.cboMarker.DropButtonForeColor = System.Drawing.Color.White;
			this.cboMarker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboMarker.Enabled = false;
			this.cboMarker.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.cboMarker.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.cboMarker.ForeColor = System.Drawing.Color.White;
			this.cboMarker.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.cboMarker.ListForeColor = System.Drawing.Color.White;
			this.cboMarker.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.cboMarker.ListSelectedForeColor = System.Drawing.Color.White;
			this.cboMarker.Location = new System.Drawing.Point(544, 28);
			this.cboMarker.Name = "cboMarker";
			this.cboMarker.SelectedIndex = -1;
			this.cboMarker.SelectedItem = null;
			this.cboMarker.Size = new System.Drawing.Size(112, 26);
			this.cboMarker.TabIndex = 2;
			this.cboMarker.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.cboMarker.TextForeColor = System.Drawing.Color.White;
			this.cboMarker.SelectedIndexChanged += new System.EventHandler(this.cboMarker_SelectedIndexChanged);
			// 
			// gpbAlarmRange
			// 
			this.gpbAlarmRange.Controls.AddRange(new System.Windows.Forms.Control[] {
																						this.NUDMinAlarm,
																						this.NUDMaxAlarm,
																						this.label4,
																						this.label3});
			this.gpbAlarmRange.Font = new System.Drawing.Font("SimSun", 12F);
			this.gpbAlarmRange.Location = new System.Drawing.Point(488, 104);
			this.gpbAlarmRange.Name = "gpbAlarmRange";
			this.gpbAlarmRange.Size = new System.Drawing.Size(168, 116);
			this.gpbAlarmRange.TabIndex = 419;
			this.gpbAlarmRange.TabStop = false;
			this.gpbAlarmRange.Text = "报警范围";
			// 
			// NUDMinAlarm
			// 
			this.NUDMinAlarm.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.NUDMinAlarm.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.NUDMinAlarm.Enabled = false;
			this.NUDMinAlarm.ForeColor = System.Drawing.Color.White;
			this.NUDMinAlarm.Location = new System.Drawing.Point(68, 76);
			this.NUDMinAlarm.Maximum = new System.Decimal(new int[] {
																		1000,
																		0,
																		0,
																		0});
			this.NUDMinAlarm.Minimum = new System.Decimal(new int[] {
																		1000,
																		0,
																		0,
																		-2147483648});
			this.NUDMinAlarm.Name = "NUDMinAlarm";
			this.NUDMinAlarm.Size = new System.Drawing.Size(88, 19);
			this.NUDMinAlarm.TabIndex = 5;
			this.NUDMinAlarm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.NUDMinAlarm.TextChanged += new System.EventHandler(this.NUDMinAlarm_TextChanged);
			this.NUDMinAlarm.ValueChanged += new System.EventHandler(this.NUDMinAlarm_ValueChanged);
			// 
			// NUDMaxAlarm
			// 
			this.NUDMaxAlarm.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.NUDMaxAlarm.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.NUDMaxAlarm.Enabled = false;
			this.NUDMaxAlarm.ForeColor = System.Drawing.Color.White;
			this.NUDMaxAlarm.Location = new System.Drawing.Point(68, 32);
			this.NUDMaxAlarm.Maximum = new System.Decimal(new int[] {
																		1000,
																		0,
																		0,
																		0});
			this.NUDMaxAlarm.Minimum = new System.Decimal(new int[] {
																		1000,
																		0,
																		0,
																		-2147483648});
			this.NUDMaxAlarm.Name = "NUDMaxAlarm";
			this.NUDMaxAlarm.Size = new System.Drawing.Size(88, 19);
			this.NUDMaxAlarm.TabIndex = 4;
			this.NUDMaxAlarm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.NUDMaxAlarm.Value = new System.Decimal(new int[] {
																	  100,
																	  0,
																	  0,
																	  0});
			this.NUDMaxAlarm.TextChanged += new System.EventHandler(this.NUDMaxAlarm_TextChanged);
			this.NUDMaxAlarm.ValueChanged += new System.EventHandler(this.NUDMaxAlarm_ValueChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("SimSun", 12F);
			this.label4.Location = new System.Drawing.Point(8, 76);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(55, 19);
			this.label4.TabIndex = 417;
			this.label4.Text = "下限：";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("SimSun", 12F);
			this.label3.Location = new System.Drawing.Point(8, 32);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(55, 19);
			this.label3.TabIndex = 416;
			this.label3.Text = "上限：";
			// 
			// lsvParamSet
			// 
			this.lsvParamSet.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.lsvParamSet.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lsvParamSet.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						  this.ParameterName,
																						  this.Marker,
																						  this.cmnColor,
																						  this.clmMaxAlarm,
																						  this.clmMinAlarm});
			this.lsvParamSet.Font = new System.Drawing.Font("SimSun", 12F);
			this.lsvParamSet.ForeColor = System.Drawing.Color.White;
			this.lsvParamSet.FullRowSelect = true;
			this.lsvParamSet.HideSelection = false;
			this.lsvParamSet.Location = new System.Drawing.Point(8, 8);
			this.lsvParamSet.Name = "lsvParamSet";
			this.lsvParamSet.Size = new System.Drawing.Size(460, 232);
			this.lsvParamSet.TabIndex = 1;
			this.lsvParamSet.View = System.Windows.Forms.View.Details;
			this.lsvParamSet.SelectedIndexChanged += new System.EventHandler(this.lsvParamSet_SelectedIndexChanged);
			// 
			// ParameterName
			// 
			this.ParameterName.Text = "参  数";
			this.ParameterName.Width = 200;
			// 
			// Marker
			// 
			this.Marker.Text = "标 记";
			this.Marker.Width = 80;
			// 
			// cmnColor
			// 
			this.cmnColor.Text = "颜色";
			this.cmnColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// clmMaxAlarm
			// 
			this.clmMaxAlarm.Text = "上限";
			// 
			// clmMinAlarm
			// 
			this.clmMinAlarm.Text = "下限";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("SimSun", 12F);
			this.label1.Location = new System.Drawing.Point(488, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 19);
			this.label1.TabIndex = 415;
			this.label1.Text = "标记：";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("SimSun", 12F);
			this.label2.Location = new System.Drawing.Point(488, 70);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 19);
			this.label2.TabIndex = 416;
			this.label2.Text = "颜色：";
			// 
			// frmVitalGroup
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(694, 339);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.tabOptions,
																		  this.cmdApply,
																		  this.cmdOK,
																		  this.cmdCancel});
			this.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmVitalGroup";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "生命特征分组信息";
			this.Load += new System.EventHandler(this.frmVitalGroup_Load);
			this.tabOptions.ResumeLayout(false);
			this.tbpGroup.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.tbpOption.ResumeLayout(false);
			this.gpbAlarmRange.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.NUDMinAlarm)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NUDMaxAlarm)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void cmdApply_Click(object sender, System.EventArgs e)
		{
			if(chklstGroup.CheckedItems.Count == 0 && m_arlCheckParam.Count == 0)
			{
				clsPublicFunction.ShowInformationMessageBox("必须选择参数。");
				return;
			}
			int intGroupID = ((clsVitalGroup)chklstGroup.CheckedItems[0]).m_intGroupID;

			int [] intEMFCIDArr = new int[m_arlCheckParam.Count];
			for(int i=0;i<m_arlCheckParam.Count;i++)
			{
				intEMFCIDArr[i] = ((clsVitalSet)m_arlCheckParam[i]).m_intEMFC_ID;
			}
			Array.Sort(intEMFCIDArr,0,intEMFCIDArr.Length);

			m_objParent.m_IntCurrentGroupID = intGroupID;

			for(int i = 0 ; i < lsvParamSet.Items.Count; i++)
			{
				((clsVitalSet)lsvParamSet.Items[i].Tag).m_intMarkerIndex = m_intMarkerIndexArr[i];
			
				((clsVitalSet)lsvParamSet.Items[i].Tag).m_clrParamColor = lsvParamSet.Items[i].SubItems[2].ForeColor;

				((clsVitalSet)lsvParamSet.Items[i].Tag).m_intMaxAlarm = int.Parse(lsvParamSet.Items[i].SubItems[3].Text);

				((clsVitalSet)lsvParamSet.Items[i].Tag).m_intMinAlarm = int.Parse(lsvParamSet.Items[i].SubItems[4].Text);
			}

			m_objParent.m_IntEMFC_IDArr = intEMFCIDArr;

			m_objParent.m_ObjVitalSetArr = m_objVitalSetArr;

			m_objParent.m_IntRefreshRate = m_intRefreshRate;
			m_objParent.m_BlnAutoRefresh = m_blnAutoRefresh;
		}

		
		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			cmdApply_Click(null, null);

			this.Close();
		}

		private void chklstGroup_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_blnCanGroupItemCheckChanged = false;
			lstGroupItem.Items.Clear();
			bool blnOk = false;
			
			if(m_objVitalSetArr != null)
			{
				for(int i = 0; i < m_objVitalSetArr.Length; i++)
				{
					if(m_objVitalSetArr[i].m_intGroupID == ((clsVitalGroup)chklstGroup.SelectedItem).m_intGroupID)
					{						
						lstGroupItem.Items.Add(m_objVitalSetArr[i],m_arlCheckParam.Contains(m_objVitalSetArr[i]));																																
						blnOk = true;
					}
					else if(blnOk)
					{
						break;
					}
				}
			}

			m_blnCanGroupItemCheckChanged = true;
		}

		#region Properties
		/// <summary>
		/// 
		/// </summary>
		public frmICUTrend m_ObjParent
		{
			set
			{
				m_objParent = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public clsVitalGroup[] m_ObjVitalGroupArr
		{
			get
			{
				return m_objVitalGroupArr;
			}
			set
			{
				m_objVitalGroupArr = value;

				if(m_objVitalGroupArr != null)
				{
					chklstGroup.Items.AddRange(m_objVitalGroupArr);
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public clsVitalSet[] m_ObjVitalSetArr
		{
			get
			{
				return m_objVitalSetArr;
			}
			set
			{
				m_objVitalSetArr = value;
				
//				if(m_objVitalSetArr != null)
//				{
//					m_intMarkerIndexArr = new int[m_objVitalSetArr.Length];
//
//					for(int i = 0; i < m_objVitalSetArr.Length; i++)
//					{
//						if(m_objVitalSetArr[i] != null)
//						{
//							ListViewItem lsvItem = new ListViewItem(new string[]{m_objVitalSetArr[i].m_strDescription,cboMarker.GetItem(m_objVitalSetArr[i].m_intMarkerIndex).ToString(),"■",m_objVitalSetArr[i].m_intMaxAlarm.ToString(),m_objVitalSetArr[i].m_intMinAlarm.ToString()});
//							lsvItem.UseItemStyleForSubItems = false;
//							lsvItem.SubItems[2].ForeColor = m_objVitalSetArr[i].m_clrParamColor;
//							lsvItem.Tag = m_objVitalSetArr[i];
//							lsvParamSet.Items.Add(lsvItem);
//						}
//					}//end for
//				}//end if

			}
		}

		private void m_mthDisplayGroupItem(int p_intCheckGroupID)
		{
			lsvParamSet.Items.Clear();

			if(m_objVitalSetArr != null)
			{
				int intParamCount = 0;

				for(int i=0;i<m_objVitalSetArr.Length;i++)
				{
					if(m_objVitalSetArr[i] != null && m_objVitalSetArr[i].m_intGroupID == p_intCheckGroupID)
					{
						ListViewItem lsvItem = new ListViewItem(new string[]{m_objVitalSetArr[i].m_strDescription,cboMarker.GetItem(m_objVitalSetArr[i].m_intMarkerIndex).ToString(),"■",m_objVitalSetArr[i].m_intMaxAlarm.ToString(),m_objVitalSetArr[i].m_intMinAlarm.ToString()});
						lsvItem.UseItemStyleForSubItems = false;
						lsvItem.SubItems[2].ForeColor = m_objVitalSetArr[i].m_clrParamColor;
						lsvItem.Tag = m_objVitalSetArr[i];
						lsvParamSet.Items.Add(lsvItem);

						intParamCount++;
					}
					else if(intParamCount > 0)
					{
						break;
					}
				}

				m_intMarkerIndexArr = new int[intParamCount];
				for(int i=0;i<m_intMarkerIndexArr.Length;i++)
				{
					m_intMarkerIndexArr[i] = ((clsVitalSet)lsvParamSet.Items[i].Tag).m_intMarkerIndex;
				}
			}
		}

		public bool m_BlnAutoRefresh
		{
			get
			{
				return m_blnAutoRefresh;
			}
			set
			{
				m_blnAutoRefresh = value;

				if(m_blnAutoRefresh)
				{
					cboRefreshRate.Enabled = true;
					lblRefreshRate.Enabled = true;
					chkRefesh.Checked = true;

					cboRefreshRate.SelectedIndex = m_intSetSelectIndex(m_intRefreshRate);
				}
				else
				{
					cboRefreshRate.Enabled = false;
					lblRefreshRate.Enabled = false;
					chkRefesh.Checked = false;
				}
			}
		}

		public int m_IntRefreshRate
		{
			get
			{
				return m_intRefreshRate;
			}
			set
			{
				m_intRefreshRate = value;
			}
		}
		#endregion

		private int m_intSetSelectIndex(int p_intMinute)
		{
			switch(p_intMinute)
			{
				case 1:
					return 0;

				case 5:
					return 1;

				case 10:
					return 2;

				case 15:
					return 3;

				case 30:
					return 4;

				default :
					return -1;
			}
		}

		public void m_mthSetSelectedGroup(int p_intGroupID)
		{
			for(int i = 0; i < chklstGroup.Items.Count; i++)
			{
				if(((clsVitalGroup)chklstGroup.Items[i]).m_intGroupID == p_intGroupID)
				{
					chklstGroup.SetItemChecked(i,true);
					chklstGroup.SetSelected(i,true);

					chklstGroup_SelectedIndexChanged(null,null);
                    
					break;		
				}
			}

			m_mthDisplayGroupItem(p_intGroupID);
		}

		public void m_mthSetSelectedEMFC(int [] p_intEMFCID_Arr)
		{
			m_blnCanGroupItemCheckChanged = false;

			for(int i1=0;i1<p_intEMFCID_Arr.Length;i1++)
			{
				for(int j2=0;j2<lstGroupItem.Items.Count;j2++)
				{
					if(((clsVitalSet)lstGroupItem.Items[j2]).m_intEMFC_ID == p_intEMFCID_Arr[i1])
					{
						lstGroupItem.SetItemChecked(j2,true);
						m_arlCheckParam.Add(lstGroupItem.Items[j2]);
						break;
					}
				}
			}

			m_blnCanGroupItemCheckChanged = true;
		}

		private void cmdColor_Click(object sender, System.EventArgs e)
		{
			ColorDialog objDialog = new ColorDialog();

			if(objDialog.ShowDialog() == DialogResult.OK)
			{
				this.cmdColor.BackColor = objDialog.Color;
//				((clsVitalSet)lsvParamSet.SelectedItems[0].Tag).m_clrParamColor = objDialog.Color;
				this.lsvParamSet.SelectedItems[0].SubItems[2].ForeColor = objDialog.Color;
			}

			
		}

		private void cboMarker_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.lsvParamSet.SelectedItems[0].SubItems[1].Text = cboMarker.SelectedItem.ToString();
			m_intMarkerIndexArr[lsvParamSet.SelectedIndices[0]] = cboMarker.SelectedIndex;
//			((clsVitalSet)lsvParamSet.SelectedItems[0].Tag).m_intMarkerIndex = cboMarker.SelectedIndex;
		}

		private bool m_blnCanTextChange = false;

		private void lsvParamSet_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(lsvParamSet.SelectedItems.Count > 0)
			{
				cmdColor.Enabled = true;
				cboMarker.Enabled = true;
				NUDMaxAlarm.Enabled = true;
				NUDMinAlarm.Enabled = true;
				m_blnCanTextChange = true;

				cboMarker.SelectedIndex = ((clsVitalSet)lsvParamSet.SelectedItems[0].Tag).m_intMarkerIndex;
				cmdColor.BackColor =  lsvParamSet.SelectedItems[0].SubItems[2].ForeColor;
				NUDMaxAlarm.Value = ((clsVitalSet)lsvParamSet.SelectedItems[0].Tag).m_intMaxAlarm;
				NUDMinAlarm.Value = ((clsVitalSet)lsvParamSet.SelectedItems[0].Tag).m_intMinAlarm;
			}
			else
			{
				cmdColor.Enabled = false;
				cboMarker.Enabled = false;
				NUDMaxAlarm.Enabled = false;
				NUDMinAlarm.Enabled = false;
				m_blnCanTextChange = false;
			}
		}

		private void chkRefesh_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chkRefesh.Checked)
			{
				lblRefreshRate.Enabled = true;
				cboRefreshRate.Enabled = true;
				m_blnAutoRefresh = true;
			}
			else
			{
				lblRefreshRate.Enabled = false;
				cboRefreshRate.Enabled = false;
				m_blnAutoRefresh = false;
			}
		}

		private int m_intRefreshRate = 0;

		private bool m_blnAutoRefresh = false;

		private void cboRefreshRate_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			switch(cboRefreshRate.SelectedIndex)
			{
				case 0:
					m_intRefreshRate = 1;
					break;

				case 1:
					m_intRefreshRate = 5;
					break;

				case 2:
					m_intRefreshRate = 10;
					break;

				case 3:
					m_intRefreshRate = 15;
					break;

				case 4:
					m_intRefreshRate = 30;
					break;
			}
		}

		private void NUDMaxAlarm_ValueChanged(object sender, System.EventArgs e)
		{
			this.lsvParamSet.SelectedItems[0].SubItems[3].Text = NUDMaxAlarm.Value.ToString();
//			((clsVitalSet)lsvParamSet.SelectedItems[0].Tag).m_intMaxAlarm = (int)NUDMaxAlarm.Value;
		}

		private void NUDMinAlarm_ValueChanged(object sender, System.EventArgs e)
		{
			this.lsvParamSet.SelectedItems[0].SubItems[4].Text = NUDMinAlarm.Value.ToString();
//			((clsVitalSet)lsvParamSet.SelectedItems[0].Tag).m_intMinAlarm = (int)NUDMinAlarm.Value;
		}

		private void NUDMaxAlarm_TextChanged(object sender, System.EventArgs e)
		{
			if(m_blnCanTextChange)
			{
				this.lsvParamSet.SelectedItems[0].SubItems[3].Text = NUDMaxAlarm.Value.ToString();
//				((clsVitalSet)lsvParamSet.SelectedItems[0].Tag).m_intMaxAlarm = (int)NUDMaxAlarm.Value;
			}
		}

		private void NUDMinAlarm_TextChanged(object sender, System.EventArgs e)
		{
			if(m_blnCanTextChange)
			{
				this.lsvParamSet.SelectedItems[0].SubItems[3].Text = NUDMaxAlarm.Value.ToString();
//				((clsVitalSet)lsvParamSet.SelectedItems[0].Tag).m_intMaxAlarm = (int)NUDMaxAlarm.Value;
			}
		}

		private void lstGroupItem_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
		{
			if(!m_blnCanGroupItemCheckChanged)
				return;

			//判断参数是否在已经选择的组里面
			if(chklstGroup.CheckedIndices.Count > 0 && chklstGroup.CheckedIndices[0] == chklstGroup.SelectedIndex)
			{
				if(e.NewValue == CheckState.Checked)
				{
					m_arlCheckParam.Add(lstGroupItem.Items[e.Index]);
				}
				else if(e.NewValue == CheckState.Unchecked)
				{
					m_arlCheckParam.Remove(lstGroupItem.Items[e.Index]);
				}
			}
			else
			{
				m_blnCanGroupItemCheckChanged = false;
				e.NewValue = CheckState.Unchecked;
				m_blnCanGroupItemCheckChanged = true;
			}
		}

		private void chklstGroup_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
		{
			if(!m_blnCanGroupCheckChanged)
				return;

			if(e.NewValue == CheckState.Checked && chklstGroup.CheckedIndices.Count > 0)
			{
				m_blnCanGroupCheckChanged = false;
				e.NewValue = CheckState.Unchecked;
				m_blnCanGroupCheckChanged = true;
			}
			else
			{
				//改变选择子项
				m_arlCheckParam.Clear();
				m_blnCanGroupItemCheckChanged = false;
				if(e.NewValue == CheckState.Unchecked)
				{
					for(int i=0;i<lstGroupItem.CheckedIndices.Count;i++)
					{
						lstGroupItem.SetItemChecked(lstGroupItem.CheckedIndices[i],false);
					}
					lsvParamSet.Items.Clear();
					m_intMarkerIndexArr = null;
				}
				else if(e.NewValue == CheckState.Checked)
				{
					for(int i=0;i<lstGroupItem.Items.Count;i++)
					{
						lstGroupItem.SetItemChecked(i,true);
						m_arlCheckParam.Add(lstGroupItem.Items[i]);
					}

					m_mthDisplayGroupItem(((clsVitalGroup)chklstGroup.Items[e.Index]).m_intGroupID);
				}
				m_blnCanGroupItemCheckChanged = true;
			}
		}

		private void m_ctmItemSelect_Popup(object sender, System.EventArgs e)
		{
			bool blnEnable = chklstGroup.CheckedIndices.Count > 0 && chklstGroup.CheckedIndices[0] == chklstGroup.SelectedIndex;
			m_ctmItemSelect.MenuItems[0].Enabled = blnEnable;
			m_ctmItemSelect.MenuItems[1].Enabled = blnEnable;
		}

		private void mniSelectAll_Click(object sender, System.EventArgs e)
		{
			m_arlCheckParam.Clear();
			m_blnCanGroupItemCheckChanged = false;
			for(int i=0;i<lstGroupItem.Items.Count;i++)
			{
				lstGroupItem.SetItemChecked(i,true);
				m_arlCheckParam.Add(lstGroupItem.Items[i]);
			}
			m_blnCanGroupItemCheckChanged = true;
		}

		private void mniUnselectAll_Click(object sender, System.EventArgs e)
		{
			m_arlCheckParam.Clear();
			m_blnCanGroupItemCheckChanged = false;
			for(int i=0;i<lstGroupItem.Items.Count;i++)
			{
				lstGroupItem.SetItemChecked(i,false);
			}
			m_blnCanGroupItemCheckChanged = true;
		}

		private void frmVitalGroup_Load(object sender, System.EventArgs e)
		{
			chklstGroup.Focus();
		}
	}
}
