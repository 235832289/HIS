using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.iCare.BIHOrder.Control;
using com.digitalwave.iCare.middletier.BIHOrderServer;
using System.Data;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.BIHOrder
{
    /// <summary>
    /// 护士工作站：	查看审核医嘱
    /// 修改人：		徐斌辉
    /// </summary>
    public class frmBIHChargeItemList : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 控件和变量申明
        private com.digitalwave.controls.datagrid.ctlDataGrid m_ctlExecOrderGrid;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private com.digitalwave.controls.datagrid.ctlDataGrid m_ctlAllCharge;
        private com.digitalwave.controls.datagrid.ctlDataGrid m_ctlOrderChargeItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private PinkieControls.ButtonXP m_cmdExit;
        private com.digitalwave.iCare.BIHOrder.Control.clsDoctorTextBox m_txtDoctor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private com.digitalwave.controls.ctlTimePicker m_dtpExecute;
        private System.Windows.Forms.Label label11;
        private PinkieControls.ButtonXP m_cmdDeleteChargeItem;
        private PinkieControls.ButtonXP m_cmdModifyChargeItem;
        private PinkieControls.ButtonXP m_cmdAddChargeItem;
        private PinkieControls.ButtonXP m_cmdRefresh;
        private System.Windows.Forms.CheckBox m_chkOnlyCurrent;
        private PinkieControls.ButtonXP cmdEmpty;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;
        private clsLoginInfo m_objLoginInfo = null;
        private clsBIHOrderExecuteService m_objService;
        private string[] m_arrExecOrderID;
        private clsBIHPatientCharge[] m_arrChargeItem;
        private clsBIHExecOrder[] m_arrExecOrder;
        private clsBIHPatientCharge m_objCurrentCharge = null;
        private System.Windows.Forms.Label label10;
        internal System.Windows.Forms.TextBox m_txbPatientName;
        internal System.Windows.Forms.TextBox m_txbBalanceMoney;
        internal System.Windows.Forms.TextBox m_txbSumMoney;
        internal System.Windows.Forms.TextBox m_txbItemName;
        internal com.digitalwave.controls.ctlFindTextBox m_txtArea;
        internal System.Windows.Forms.TextBox m_txtBed;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ListView m_lsvSelectBed;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private clsBIHExecOrder m_objCurrentOrder = null;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private clsDcl_InputOrder m_objInputOrder;
        #endregion
        #region 构造函数
        public frmBIHChargeItemList()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
            //m_objService = new clsBIHOrderExecuteService();
            m_objService = new clsDcl_GetSvcObject().m_GetBIHOrderExecuteSvc();
            m_objInputOrder = new clsDcl_InputOrder();

            m_arrExecOrderID = null;
            m_arrChargeItem = null;

            m_ctlExecOrderGrid.m_mthAppendNotVisibleColumn("ExecOrderID", typeof(string));
            m_ctlExecOrderGrid.m_mthAppendNotVisibleColumn("RegisterID", typeof(string));
            m_ctlOrderChargeItem.m_mthAppendNotVisibleColumn("Index", typeof(int));
        }

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion
        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo1 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo2 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo3 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo4 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo5 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo6 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo7 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo8 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo9 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo10 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo11 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo12 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo13 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo14 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo15 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo16 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo17 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo18 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo19 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo20 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo21 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo22 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo23 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo24 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo25 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo26 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo27 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo28 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo29 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo30 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo31 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo32 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            this.m_ctlExecOrderGrid = new com.digitalwave.controls.datagrid.ctlDataGrid();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.m_txbSumMoney = new System.Windows.Forms.TextBox();
            this.m_txbItemName = new System.Windows.Forms.TextBox();
            this.m_cmdAddChargeItem = new PinkieControls.ButtonXP();
            this.m_cmdModifyChargeItem = new PinkieControls.ButtonXP();
            this.m_cmdDeleteChargeItem = new PinkieControls.ButtonXP();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_ctlOrderChargeItem = new com.digitalwave.controls.datagrid.ctlDataGrid();
            this.label8 = new System.Windows.Forms.Label();
            this.m_txbBalanceMoney = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.m_txbPatientName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.m_ctlAllCharge = new com.digitalwave.controls.datagrid.ctlDataGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_txtArea = new com.digitalwave.controls.ctlFindTextBox();
            this.m_txtBed = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_dtpExecute = new com.digitalwave.controls.ctlTimePicker();
            this.cmdEmpty = new PinkieControls.ButtonXP();
            this.m_chkOnlyCurrent = new System.Windows.Forms.CheckBox();
            this.m_cmdExit = new PinkieControls.ButtonXP();
            this.m_txtDoctor = new com.digitalwave.iCare.BIHOrder.Control.clsDoctorTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_cmdRefresh = new PinkieControls.ButtonXP();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.m_lsvSelectBed = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            ((System.ComponentModel.ISupportInitialize)(this.m_ctlExecOrderGrid)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_ctlOrderChargeItem)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_ctlAllCharge)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_ctlExecOrderGrid
            // 
            this.m_ctlExecOrderGrid.AllowAddNew = false;
            this.m_ctlExecOrderGrid.AllowDelete = false;
            this.m_ctlExecOrderGrid.AutoAppendRow = false;
            this.m_ctlExecOrderGrid.AutoScroll = true;
            this.m_ctlExecOrderGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.m_ctlExecOrderGrid.CaptionText = "";
            this.m_ctlExecOrderGrid.CaptionVisible = false;
            this.m_ctlExecOrderGrid.ColumnHeadersVisible = true;
            clsColumnInfo1.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo1.BackColor = System.Drawing.Color.White;
            clsColumnInfo1.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Int;
            clsColumnInfo1.ColumnIndex = 0;
            clsColumnInfo1.ColumnName = "NO";
            clsColumnInfo1.ColumnWidth = 35;
            clsColumnInfo1.Enabled = false;
            clsColumnInfo1.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo1.HeadText = "序号";
            clsColumnInfo1.ReadOnly = true;
            clsColumnInfo1.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo2.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo2.BackColor = System.Drawing.Color.White;
            clsColumnInfo2.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo2.ColumnIndex = 1;
            clsColumnInfo2.ColumnName = "BedNo";
            clsColumnInfo2.ColumnWidth = 40;
            clsColumnInfo2.Enabled = false;
            clsColumnInfo2.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo2.HeadText = "床号";
            clsColumnInfo2.ReadOnly = true;
            clsColumnInfo2.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo3.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo3.BackColor = System.Drawing.Color.White;
            clsColumnInfo3.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo3.ColumnIndex = 2;
            clsColumnInfo3.ColumnName = "PatientName";
            clsColumnInfo3.ColumnWidth = 60;
            clsColumnInfo3.Enabled = false;
            clsColumnInfo3.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo3.HeadText = " 姓  名";
            clsColumnInfo3.ReadOnly = true;
            clsColumnInfo3.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo4.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo4.BackColor = System.Drawing.Color.White;
            clsColumnInfo4.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Int;
            clsColumnInfo4.ColumnIndex = 3;
            clsColumnInfo4.ColumnName = "RecipeNo";
            clsColumnInfo4.ColumnWidth = 35;
            clsColumnInfo4.Enabled = false;
            clsColumnInfo4.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo4.HeadText = "方号";
            clsColumnInfo4.ReadOnly = true;
            clsColumnInfo4.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo5.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo5.BackColor = System.Drawing.Color.White;
            clsColumnInfo5.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo5.ColumnIndex = 4;
            clsColumnInfo5.ColumnName = "OrderName";
            clsColumnInfo5.ColumnWidth = 200;
            clsColumnInfo5.Enabled = false;
            clsColumnInfo5.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo5.HeadText = "医嘱名称";
            clsColumnInfo5.ReadOnly = true;
            clsColumnInfo5.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo6.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo6.BackColor = System.Drawing.Color.White;
            clsColumnInfo6.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo6.ColumnIndex = 5;
            clsColumnInfo6.ColumnName = "Dosage";
            clsColumnInfo6.ColumnWidth = 70;
            clsColumnInfo6.Enabled = false;
            clsColumnInfo6.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo6.HeadText = "剂  量";
            clsColumnInfo6.ReadOnly = true;
            clsColumnInfo6.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo7.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo7.BackColor = System.Drawing.Color.White;
            clsColumnInfo7.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo7.ColumnIndex = 6;
            clsColumnInfo7.ColumnName = "Use";
            clsColumnInfo7.ColumnWidth = 70;
            clsColumnInfo7.Enabled = false;
            clsColumnInfo7.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo7.HeadText = "用  量";
            clsColumnInfo7.ReadOnly = true;
            clsColumnInfo7.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo8.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo8.BackColor = System.Drawing.Color.White;
            clsColumnInfo8.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo8.ColumnIndex = 7;
            clsColumnInfo8.ColumnName = "Get";
            clsColumnInfo8.ColumnWidth = 70;
            clsColumnInfo8.Enabled = false;
            clsColumnInfo8.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo8.HeadText = "领  量";
            clsColumnInfo8.ReadOnly = true;
            clsColumnInfo8.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo9.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo9.BackColor = System.Drawing.Color.White;
            clsColumnInfo9.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo9.ColumnIndex = 8;
            clsColumnInfo9.ColumnName = "DosageType";
            clsColumnInfo9.ColumnWidth = 70;
            clsColumnInfo9.Enabled = false;
            clsColumnInfo9.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo9.HeadText = "用药方式";
            clsColumnInfo9.ReadOnly = true;
            clsColumnInfo9.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo10.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo10.BackColor = System.Drawing.Color.White;
            clsColumnInfo10.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo10.ColumnIndex = 9;
            clsColumnInfo10.ColumnName = "ExecuteFreq";
            clsColumnInfo10.ColumnWidth = 70;
            clsColumnInfo10.Enabled = false;
            clsColumnInfo10.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo10.HeadText = "执行频率";
            clsColumnInfo10.ReadOnly = true;
            clsColumnInfo10.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo11.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo11.BackColor = System.Drawing.Color.White;
            clsColumnInfo11.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo11.ColumnIndex = 10;
            clsColumnInfo11.ColumnName = "InceptState";
            clsColumnInfo11.ColumnWidth = 75;
            clsColumnInfo11.Enabled = false;
            clsColumnInfo11.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo11.HeadText = "接收状态";
            clsColumnInfo11.ReadOnly = true;
            clsColumnInfo11.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo12.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo12.BackColor = System.Drawing.Color.White;
            clsColumnInfo12.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo12.ColumnIndex = 11;
            clsColumnInfo12.ColumnName = "IsFirst";
            clsColumnInfo12.ColumnWidth = 70;
            clsColumnInfo12.Enabled = false;
            clsColumnInfo12.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo12.HeadText = "类型";
            clsColumnInfo12.ReadOnly = true;
            clsColumnInfo12.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo13.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo13.BackColor = System.Drawing.Color.White;
            clsColumnInfo13.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo13.ColumnIndex = 12;
            clsColumnInfo13.ColumnName = "CreateDate";
            clsColumnInfo13.ColumnWidth = 120;
            clsColumnInfo13.Enabled = false;
            clsColumnInfo13.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo13.HeadText = "生成时间";
            clsColumnInfo13.ReadOnly = true;
            clsColumnInfo13.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo14.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo14.BackColor = System.Drawing.Color.White;
            clsColumnInfo14.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo14.ColumnIndex = 13;
            clsColumnInfo14.ColumnName = "ExecuteDate";
            clsColumnInfo14.ColumnWidth = 120;
            clsColumnInfo14.Enabled = false;
            clsColumnInfo14.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo14.HeadText = "执行时间";
            clsColumnInfo14.ReadOnly = true;
            clsColumnInfo14.TextFont = new System.Drawing.Font("宋体", 10F);
            this.m_ctlExecOrderGrid.Columns.Add(clsColumnInfo1);
            this.m_ctlExecOrderGrid.Columns.Add(clsColumnInfo2);
            this.m_ctlExecOrderGrid.Columns.Add(clsColumnInfo3);
            this.m_ctlExecOrderGrid.Columns.Add(clsColumnInfo4);
            this.m_ctlExecOrderGrid.Columns.Add(clsColumnInfo5);
            this.m_ctlExecOrderGrid.Columns.Add(clsColumnInfo6);
            this.m_ctlExecOrderGrid.Columns.Add(clsColumnInfo7);
            this.m_ctlExecOrderGrid.Columns.Add(clsColumnInfo8);
            this.m_ctlExecOrderGrid.Columns.Add(clsColumnInfo9);
            this.m_ctlExecOrderGrid.Columns.Add(clsColumnInfo10);
            this.m_ctlExecOrderGrid.Columns.Add(clsColumnInfo11);
            this.m_ctlExecOrderGrid.Columns.Add(clsColumnInfo12);
            this.m_ctlExecOrderGrid.Columns.Add(clsColumnInfo13);
            this.m_ctlExecOrderGrid.Columns.Add(clsColumnInfo14);
            this.m_ctlExecOrderGrid.FullRowSelect = true;
            this.m_ctlExecOrderGrid.Location = new System.Drawing.Point(0, 28);
            this.m_ctlExecOrderGrid.MultiSelect = false;
            this.m_ctlExecOrderGrid.Name = "m_ctlExecOrderGrid";
            this.m_ctlExecOrderGrid.ReadOnly = true;
            this.m_ctlExecOrderGrid.RowHeadersVisible = false;
            this.m_ctlExecOrderGrid.RowHeaderWidth = 15;
            this.m_ctlExecOrderGrid.SelectedRowBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.m_ctlExecOrderGrid.SelectedRowForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.m_ctlExecOrderGrid.Size = new System.Drawing.Size(996, 280);
            this.m_ctlExecOrderGrid.TabIndex = 1;
            this.m_ctlExecOrderGrid.m_evtCurrentCellChanged += new System.EventHandler(this.m_ctlExecOrderGrid_m_evtCurrentCellChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.HotTrack = true;
            this.tabControl1.ItemSize = new System.Drawing.Size(131, 25);
            this.tabControl1.Location = new System.Drawing.Point(0, 76);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1004, 572);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.m_txbSumMoney);
            this.tabPage1.Controls.Add(this.m_txbItemName);
            this.tabPage1.Controls.Add(this.m_cmdAddChargeItem);
            this.tabPage1.Controls.Add(this.m_cmdModifyChargeItem);
            this.tabPage1.Controls.Add(this.m_cmdDeleteChargeItem);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.m_ctlOrderChargeItem);
            this.tabPage1.Controls.Add(this.m_ctlExecOrderGrid);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.m_txbBalanceMoney);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.m_txbPatientName);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(996, 539);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "  医嘱执行单     ";
            // 
            // m_txbSumMoney
            // 
            this.m_txbSumMoney.ForeColor = System.Drawing.Color.Red;
            this.m_txbSumMoney.Location = new System.Drawing.Point(492, 317);
            this.m_txbSumMoney.Name = "m_txbSumMoney";
            this.m_txbSumMoney.ReadOnly = true;
            this.m_txbSumMoney.Size = new System.Drawing.Size(76, 23);
            this.m_txbSumMoney.TabIndex = 10;
            // 
            // m_txbItemName
            // 
            this.m_txbItemName.Location = new System.Drawing.Point(212, 317);
            this.m_txbItemName.Name = "m_txbItemName";
            this.m_txbItemName.ReadOnly = true;
            this.m_txbItemName.Size = new System.Drawing.Size(208, 23);
            this.m_txbItemName.TabIndex = 10;
            // 
            // m_cmdAddChargeItem
            // 
            this.m_cmdAddChargeItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdAddChargeItem.DefaultScheme = true;
            this.m_cmdAddChargeItem.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdAddChargeItem.Hint = "";
            this.m_cmdAddChargeItem.Location = new System.Drawing.Point(736, 312);
            this.m_cmdAddChargeItem.Name = "m_cmdAddChargeItem";
            this.m_cmdAddChargeItem.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdAddChargeItem.Size = new System.Drawing.Size(84, 28);
            this.m_cmdAddChargeItem.TabIndex = 9;
            this.m_cmdAddChargeItem.Text = "添加(F5)";
            this.m_cmdAddChargeItem.Visible = false;
            this.m_cmdAddChargeItem.Click += new System.EventHandler(this.m_cmdAddChargeItem_Click);
            // 
            // m_cmdModifyChargeItem
            // 
            this.m_cmdModifyChargeItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdModifyChargeItem.DefaultScheme = true;
            this.m_cmdModifyChargeItem.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdModifyChargeItem.Hint = "";
            this.m_cmdModifyChargeItem.Location = new System.Drawing.Point(824, 312);
            this.m_cmdModifyChargeItem.Name = "m_cmdModifyChargeItem";
            this.m_cmdModifyChargeItem.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdModifyChargeItem.Size = new System.Drawing.Size(84, 28);
            this.m_cmdModifyChargeItem.TabIndex = 8;
            this.m_cmdModifyChargeItem.Text = "修改(F6)";
            this.m_cmdModifyChargeItem.Visible = false;
            this.m_cmdModifyChargeItem.Click += new System.EventHandler(this.m_cmdModifyChargeItem_Click);
            // 
            // m_cmdDeleteChargeItem
            // 
            this.m_cmdDeleteChargeItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdDeleteChargeItem.DefaultScheme = true;
            this.m_cmdDeleteChargeItem.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdDeleteChargeItem.Hint = "";
            this.m_cmdDeleteChargeItem.Location = new System.Drawing.Point(912, 312);
            this.m_cmdDeleteChargeItem.Name = "m_cmdDeleteChargeItem";
            this.m_cmdDeleteChargeItem.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdDeleteChargeItem.Size = new System.Drawing.Size(84, 28);
            this.m_cmdDeleteChargeItem.TabIndex = 7;
            this.m_cmdDeleteChargeItem.Text = "删除(Del)";
            this.m_cmdDeleteChargeItem.Visible = false;
            this.m_cmdDeleteChargeItem.Click += new System.EventHandler(this.m_cmdDeleteChargeItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(148, 321);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "项目名称:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "执行单:";
            // 
            // m_ctlOrderChargeItem
            // 
            this.m_ctlOrderChargeItem.AllowAddNew = false;
            this.m_ctlOrderChargeItem.AllowDelete = false;
            this.m_ctlOrderChargeItem.AutoAppendRow = false;
            this.m_ctlOrderChargeItem.AutoScroll = true;
            this.m_ctlOrderChargeItem.BackgroundColor = System.Drawing.SystemColors.Window;
            this.m_ctlOrderChargeItem.CaptionText = "";
            this.m_ctlOrderChargeItem.CaptionVisible = false;
            this.m_ctlOrderChargeItem.ColumnHeadersVisible = true;
            clsColumnInfo15.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo15.BackColor = System.Drawing.Color.White;
            clsColumnInfo15.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Int;
            clsColumnInfo15.ColumnIndex = 0;
            clsColumnInfo15.ColumnName = "NO";
            clsColumnInfo15.ColumnWidth = 35;
            clsColumnInfo15.Enabled = false;
            clsColumnInfo15.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo15.HeadText = "序号";
            clsColumnInfo15.ReadOnly = true;
            clsColumnInfo15.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo16.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo16.BackColor = System.Drawing.Color.White;
            clsColumnInfo16.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo16.ColumnIndex = 1;
            clsColumnInfo16.ColumnName = "ChargeItemName";
            clsColumnInfo16.ColumnWidth = 200;
            clsColumnInfo16.Enabled = false;
            clsColumnInfo16.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo16.HeadText = "收费项目";
            clsColumnInfo16.ReadOnly = true;
            clsColumnInfo16.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo17.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo17.BackColor = System.Drawing.Color.White;
            clsColumnInfo17.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo17.ColumnIndex = 2;
            clsColumnInfo17.ColumnName = "Amount";
            clsColumnInfo17.ColumnWidth = 75;
            clsColumnInfo17.Enabled = false;
            clsColumnInfo17.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo17.HeadText = "数量  ";
            clsColumnInfo17.ReadOnly = true;
            clsColumnInfo17.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo18.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo18.BackColor = System.Drawing.Color.White;
            clsColumnInfo18.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo18.ColumnIndex = 3;
            clsColumnInfo18.ColumnName = "UnitPrice";
            clsColumnInfo18.ColumnWidth = 75;
            clsColumnInfo18.Enabled = false;
            clsColumnInfo18.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo18.HeadText = "单价  ";
            clsColumnInfo18.ReadOnly = true;
            clsColumnInfo18.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo19.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo19.BackColor = System.Drawing.Color.White;
            clsColumnInfo19.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo19.ColumnIndex = 4;
            clsColumnInfo19.ColumnName = "Money";
            clsColumnInfo19.ColumnWidth = 75;
            clsColumnInfo19.Enabled = false;
            clsColumnInfo19.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo19.HeadText = "金额   ";
            clsColumnInfo19.ReadOnly = true;
            clsColumnInfo19.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo20.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            clsColumnInfo20.BackColor = System.Drawing.Color.White;
            clsColumnInfo20.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo20.ColumnIndex = 5;
            clsColumnInfo20.ColumnName = "Discount";
            clsColumnInfo20.ColumnWidth = 70;
            clsColumnInfo20.Enabled = false;
            clsColumnInfo20.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo20.HeadText = "折扣比例";
            clsColumnInfo20.ReadOnly = true;
            clsColumnInfo20.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo21.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            clsColumnInfo21.BackColor = System.Drawing.Color.White;
            clsColumnInfo21.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo21.ColumnIndex = 6;
            clsColumnInfo21.ColumnName = "ChargeStatus";
            clsColumnInfo21.ColumnWidth = 70;
            clsColumnInfo21.Enabled = false;
            clsColumnInfo21.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo21.HeadText = "费用状态";
            clsColumnInfo21.ReadOnly = true;
            clsColumnInfo21.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo22.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo22.BackColor = System.Drawing.Color.White;
            clsColumnInfo22.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo22.ColumnIndex = 7;
            clsColumnInfo22.ColumnName = "execDept";
            clsColumnInfo22.ColumnWidth = 75;
            clsColumnInfo22.Enabled = false;
            clsColumnInfo22.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo22.HeadText = "执行科室";
            clsColumnInfo22.ReadOnly = true;
            clsColumnInfo22.TextFont = new System.Drawing.Font("宋体", 10F);
            this.m_ctlOrderChargeItem.Columns.Add(clsColumnInfo15);
            this.m_ctlOrderChargeItem.Columns.Add(clsColumnInfo16);
            this.m_ctlOrderChargeItem.Columns.Add(clsColumnInfo17);
            this.m_ctlOrderChargeItem.Columns.Add(clsColumnInfo18);
            this.m_ctlOrderChargeItem.Columns.Add(clsColumnInfo19);
            this.m_ctlOrderChargeItem.Columns.Add(clsColumnInfo20);
            this.m_ctlOrderChargeItem.Columns.Add(clsColumnInfo21);
            this.m_ctlOrderChargeItem.Columns.Add(clsColumnInfo22);
            this.m_ctlOrderChargeItem.FullRowSelect = true;
            this.m_ctlOrderChargeItem.Location = new System.Drawing.Point(0, 344);
            this.m_ctlOrderChargeItem.MultiSelect = false;
            this.m_ctlOrderChargeItem.Name = "m_ctlOrderChargeItem";
            this.m_ctlOrderChargeItem.ReadOnly = true;
            this.m_ctlOrderChargeItem.RowHeadersVisible = false;
            this.m_ctlOrderChargeItem.RowHeaderWidth = 15;
            this.m_ctlOrderChargeItem.SelectedRowBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.m_ctlOrderChargeItem.SelectedRowForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.m_ctlOrderChargeItem.Size = new System.Drawing.Size(996, 192);
            this.m_ctlOrderChargeItem.TabIndex = 3;
            this.m_ctlOrderChargeItem.m_evtCurrentCellChanged += new System.EventHandler(this.m_ctlOrderChargeItem_m_evtCurrentCellChanged);
            this.m_ctlOrderChargeItem.m_evtDoubleClickCell += new com.digitalwave.controls.datagrid.clsDGTextMouseClickEventHandler(this.m_ctlOrderChargeItem_m_evtDoubleClickCell);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(428, 321);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 14);
            this.label8.TabIndex = 5;
            this.label8.Text = "累计费用:";
            // 
            // m_txbBalanceMoney
            // 
            this.m_txbBalanceMoney.ForeColor = System.Drawing.Color.Red;
            this.m_txbBalanceMoney.Location = new System.Drawing.Point(652, 317);
            this.m_txbBalanceMoney.Name = "m_txbBalanceMoney";
            this.m_txbBalanceMoney.ReadOnly = true;
            this.m_txbBalanceMoney.Size = new System.Drawing.Size(76, 23);
            this.m_txbBalanceMoney.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(572, 321);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 14);
            this.label9.TabIndex = 5;
            this.label9.Text = "预交金余额:";
            // 
            // m_txbPatientName
            // 
            this.m_txbPatientName.Location = new System.Drawing.Point(68, 316);
            this.m_txbPatientName.Name = "m_txbPatientName";
            this.m_txbPatientName.ReadOnly = true;
            this.m_txbPatientName.Size = new System.Drawing.Size(76, 23);
            this.m_txbPatientName.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(4, 320);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 14);
            this.label10.TabIndex = 5;
            this.label10.Text = "病人姓名:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.m_ctlAllCharge);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(996, 539);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "  医嘱费用明细   ";
            // 
            // m_ctlAllCharge
            // 
            this.m_ctlAllCharge.AllowAddNew = false;
            this.m_ctlAllCharge.AllowDelete = false;
            this.m_ctlAllCharge.AutoAppendRow = false;
            this.m_ctlAllCharge.AutoScroll = true;
            this.m_ctlAllCharge.BackgroundColor = System.Drawing.SystemColors.Window;
            this.m_ctlAllCharge.CaptionText = "";
            this.m_ctlAllCharge.CaptionVisible = false;
            this.m_ctlAllCharge.ColumnHeadersVisible = true;
            clsColumnInfo23.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo23.BackColor = System.Drawing.Color.White;
            clsColumnInfo23.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Int;
            clsColumnInfo23.ColumnIndex = 0;
            clsColumnInfo23.ColumnName = "NO";
            clsColumnInfo23.ColumnWidth = 35;
            clsColumnInfo23.Enabled = false;
            clsColumnInfo23.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo23.HeadText = "序号";
            clsColumnInfo23.ReadOnly = true;
            clsColumnInfo23.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo24.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo24.BackColor = System.Drawing.Color.White;
            clsColumnInfo24.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo24.ColumnIndex = 1;
            clsColumnInfo24.ColumnName = "BedNo";
            clsColumnInfo24.ColumnWidth = 50;
            clsColumnInfo24.Enabled = false;
            clsColumnInfo24.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo24.HeadText = "床号";
            clsColumnInfo24.ReadOnly = true;
            clsColumnInfo24.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo25.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo25.BackColor = System.Drawing.Color.White;
            clsColumnInfo25.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo25.ColumnIndex = 2;
            clsColumnInfo25.ColumnName = "PatientName";
            clsColumnInfo25.ColumnWidth = 60;
            clsColumnInfo25.Enabled = false;
            clsColumnInfo25.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo25.HeadText = "姓名";
            clsColumnInfo25.ReadOnly = true;
            clsColumnInfo25.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo26.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo26.BackColor = System.Drawing.Color.White;
            clsColumnInfo26.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo26.ColumnIndex = 3;
            clsColumnInfo26.ColumnName = "ChargeItemName";
            clsColumnInfo26.ColumnWidth = 120;
            clsColumnInfo26.Enabled = false;
            clsColumnInfo26.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo26.HeadText = "收费项目";
            clsColumnInfo26.ReadOnly = true;
            clsColumnInfo26.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo27.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo27.BackColor = System.Drawing.Color.White;
            clsColumnInfo27.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo27.ColumnIndex = 4;
            clsColumnInfo27.ColumnName = "Amount";
            clsColumnInfo27.ColumnWidth = 75;
            clsColumnInfo27.Enabled = false;
            clsColumnInfo27.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo27.HeadText = "数量";
            clsColumnInfo27.ReadOnly = true;
            clsColumnInfo27.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo28.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo28.BackColor = System.Drawing.Color.White;
            clsColumnInfo28.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo28.ColumnIndex = 5;
            clsColumnInfo28.ColumnName = "UnitPrice";
            clsColumnInfo28.ColumnWidth = 75;
            clsColumnInfo28.Enabled = false;
            clsColumnInfo28.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo28.HeadText = "单价";
            clsColumnInfo28.ReadOnly = true;
            clsColumnInfo28.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo29.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo29.BackColor = System.Drawing.Color.White;
            clsColumnInfo29.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo29.ColumnIndex = 6;
            clsColumnInfo29.ColumnName = "Money";
            clsColumnInfo29.ColumnWidth = 75;
            clsColumnInfo29.Enabled = false;
            clsColumnInfo29.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo29.HeadText = "金额";
            clsColumnInfo29.ReadOnly = true;
            clsColumnInfo29.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo30.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            clsColumnInfo30.BackColor = System.Drawing.Color.White;
            clsColumnInfo30.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo30.ColumnIndex = 7;
            clsColumnInfo30.ColumnName = "Discount";
            clsColumnInfo30.ColumnWidth = 70;
            clsColumnInfo30.Enabled = false;
            clsColumnInfo30.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo30.HeadText = "折扣比例";
            clsColumnInfo30.ReadOnly = true;
            clsColumnInfo30.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo31.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo31.BackColor = System.Drawing.Color.White;
            clsColumnInfo31.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo31.ColumnIndex = 8;
            clsColumnInfo31.ColumnName = "ChargeStatus";
            clsColumnInfo31.ColumnWidth = 75;
            clsColumnInfo31.Enabled = false;
            clsColumnInfo31.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo31.HeadText = "费用状态";
            clsColumnInfo31.ReadOnly = true;
            clsColumnInfo31.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo32.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo32.BackColor = System.Drawing.Color.White;
            clsColumnInfo32.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo32.ColumnIndex = 9;
            clsColumnInfo32.ColumnName = "execDept";
            clsColumnInfo32.ColumnWidth = 75;
            clsColumnInfo32.Enabled = false;
            clsColumnInfo32.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo32.HeadText = "执行科室";
            clsColumnInfo32.ReadOnly = true;
            clsColumnInfo32.TextFont = new System.Drawing.Font("宋体", 10F);
            this.m_ctlAllCharge.Columns.Add(clsColumnInfo23);
            this.m_ctlAllCharge.Columns.Add(clsColumnInfo24);
            this.m_ctlAllCharge.Columns.Add(clsColumnInfo25);
            this.m_ctlAllCharge.Columns.Add(clsColumnInfo26);
            this.m_ctlAllCharge.Columns.Add(clsColumnInfo27);
            this.m_ctlAllCharge.Columns.Add(clsColumnInfo28);
            this.m_ctlAllCharge.Columns.Add(clsColumnInfo29);
            this.m_ctlAllCharge.Columns.Add(clsColumnInfo30);
            this.m_ctlAllCharge.Columns.Add(clsColumnInfo31);
            this.m_ctlAllCharge.Columns.Add(clsColumnInfo32);
            this.m_ctlAllCharge.FullRowSelect = true;
            this.m_ctlAllCharge.Location = new System.Drawing.Point(0, 8);
            this.m_ctlAllCharge.MultiSelect = false;
            this.m_ctlAllCharge.Name = "m_ctlAllCharge";
            this.m_ctlAllCharge.ReadOnly = true;
            this.m_ctlAllCharge.RowHeadersVisible = false;
            this.m_ctlAllCharge.RowHeaderWidth = 15;
            this.m_ctlAllCharge.SelectedRowBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.m_ctlAllCharge.SelectedRowForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.m_ctlAllCharge.Size = new System.Drawing.Size(1000, 528);
            this.m_ctlAllCharge.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_txtArea);
            this.panel1.Controls.Add(this.m_txtBed);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.m_dtpExecute);
            this.panel1.Controls.Add(this.cmdEmpty);
            this.panel1.Controls.Add(this.m_chkOnlyCurrent);
            this.panel1.Controls.Add(this.m_cmdExit);
            this.panel1.Controls.Add(this.m_txtDoctor);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.m_cmdRefresh);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Location = new System.Drawing.Point(4, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1004, 68);
            this.panel1.TabIndex = 0;
            // 
            // m_txtArea
            // 
            this.m_txtArea.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtArea.Location = new System.Drawing.Point(76, 8);
            this.m_txtArea.Name = "m_txtArea";
            this.m_txtArea.Size = new System.Drawing.Size(124, 23);
            this.m_txtArea.TabIndex = 2;
            this.m_txtArea.m_evtFindItem += new com.digitalwave.controls.EventHandler_OnFindItem(this.m_txtArea_m_evtFindItem);
            this.m_txtArea.m_evtInitListView += new com.digitalwave.controls.EventHandler_InitListView(this.m_txtArea_m_evtInitListView);
            this.m_txtArea.m_evtSelectItem += new com.digitalwave.controls.EventHandler_OnSelectItem(this.m_txtArea_m_evtSelectItem);
            // 
            // m_txtBed
            // 
            this.m_txtBed.BackColor = System.Drawing.Color.LightCyan;
            this.m_txtBed.Location = new System.Drawing.Point(272, 8);
            this.m_txtBed.Name = "m_txtBed";
            this.m_txtBed.ReadOnly = true;
            this.m_txtBed.Size = new System.Drawing.Size(272, 23);
            this.m_txtBed.TabIndex = 1;
            this.m_txtBed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtBed_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(233, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 14);
            this.label3.TabIndex = 54;
            this.label3.Text = "床号:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_dtpExecute
            // 
            this.m_dtpExecute.BorderColor = System.Drawing.Color.DimGray;
            this.m_dtpExecute.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpExecute.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_dtpExecute.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpExecute.DropButtonForeColor = System.Drawing.SystemColors.ControlText;
            this.m_dtpExecute.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpExecute.Font = new System.Drawing.Font("宋体", 12F);
            this.m_dtpExecute.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpExecute.Location = new System.Drawing.Point(272, 41);
            this.m_dtpExecute.m_BlnOnlyTime = false;
            this.m_dtpExecute.m_EnmVisibleFlag = com.digitalwave.controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpExecute.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpExecute.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpExecute.Name = "m_dtpExecute";
            this.m_dtpExecute.ReadOnly = false;
            this.m_dtpExecute.Size = new System.Drawing.Size(140, 22);
            this.m_dtpExecute.TabIndex = 4;
            this.m_dtpExecute.TextBackColor = System.Drawing.Color.White;
            this.m_dtpExecute.TextForeColor = System.Drawing.Color.Black;
            // 
            // cmdEmpty
            // 
            this.cmdEmpty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdEmpty.DefaultScheme = true;
            this.cmdEmpty.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdEmpty.Hint = "";
            this.cmdEmpty.Location = new System.Drawing.Point(824, 32);
            this.cmdEmpty.Name = "cmdEmpty";
            this.cmdEmpty.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdEmpty.Size = new System.Drawing.Size(84, 28);
            this.cmdEmpty.TabIndex = 25;
            this.cmdEmpty.Text = "清空(F4)";
            this.cmdEmpty.Click += new System.EventHandler(this.cmdEmpty_Click);
            // 
            // m_chkOnlyCurrent
            // 
            this.m_chkOnlyCurrent.Location = new System.Drawing.Point(484, 39);
            this.m_chkOnlyCurrent.Name = "m_chkOnlyCurrent";
            this.m_chkOnlyCurrent.Size = new System.Drawing.Size(104, 24);
            this.m_chkOnlyCurrent.TabIndex = 47;
            this.m_chkOnlyCurrent.Text = "当前执行";
            // 
            // m_cmdExit
            // 
            this.m_cmdExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdExit.DefaultScheme = true;
            this.m_cmdExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdExit.Hint = "";
            this.m_cmdExit.Location = new System.Drawing.Point(912, 33);
            this.m_cmdExit.Name = "m_cmdExit";
            this.m_cmdExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdExit.Size = new System.Drawing.Size(84, 28);
            this.m_cmdExit.TabIndex = 45;
            this.m_cmdExit.Text = "退出(Esc)";
            this.m_cmdExit.Click += new System.EventHandler(this.m_cmdExit_Click);
            // 
            // m_txtDoctor
            // 
            this.m_txtDoctor.DoctorID = "";
            this.m_txtDoctor.DoctorName = "";
            this.m_txtDoctor.Location = new System.Drawing.Point(76, 40);
            this.m_txtDoctor.Name = "m_txtDoctor";
            this.m_txtDoctor.Size = new System.Drawing.Size(124, 23);
            this.m_txtDoctor.TabIndex = 3;
            this.m_txtDoctor.Tag = "";
            this.m_txtDoctor.m_evtSelectItem += new com.digitalwave.iCare.BIHOrder.Control.EventHandler_OnSelectItem(this.m_txtDoctor_m_evtSelectItem);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "录入医生:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 14);
            this.label6.TabIndex = 4;
            this.label6.Text = "选择病区:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_cmdRefresh
            // 
            this.m_cmdRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdRefresh.DefaultScheme = true;
            this.m_cmdRefresh.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdRefresh.Hint = "";
            this.m_cmdRefresh.Location = new System.Drawing.Point(736, 33);
            this.m_cmdRefresh.Name = "m_cmdRefresh";
            this.m_cmdRefresh.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdRefresh.Size = new System.Drawing.Size(84, 28);
            this.m_cmdRefresh.TabIndex = 5;
            this.m_cmdRefresh.Text = "查询(F3)";
            this.m_cmdRefresh.Click += new System.EventHandler(this.m_cmdRefresh_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(204, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 14);
            this.label7.TabIndex = 17;
            this.label7.Text = "执行日期:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(1004, 68);
            this.label11.TabIndex = 23;
            // 
            // m_lsvSelectBed
            // 
            this.m_lsvSelectBed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lsvSelectBed.CheckBoxes = true;
            this.m_lsvSelectBed.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.m_lsvSelectBed.FullRowSelect = true;
            this.m_lsvSelectBed.GridLines = true;
            this.m_lsvSelectBed.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_lsvSelectBed.Location = new System.Drawing.Point(276, 33);
            this.m_lsvSelectBed.Name = "m_lsvSelectBed";
            this.m_lsvSelectBed.Size = new System.Drawing.Size(272, 209);
            this.m_lsvSelectBed.TabIndex = 89;
            this.m_lsvSelectBed.UseCompatibleStateImageBehavior = false;
            this.m_lsvSelectBed.View = System.Windows.Forms.View.Details;
            this.m_lsvSelectBed.Visible = false;
            this.m_lsvSelectBed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_lsvSelectBed_KeyDown);
            this.m_lsvSelectBed.Leave += new System.EventHandler(this.m_lsvSelectBed_Leave);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "床号";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "姓名";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "性别";
            // 
            // frmBIHChargeItemList
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(1012, 649);
            this.Controls.Add(this.m_lsvSelectBed);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.KeyPreview = true;
            this.Name = "frmBIHChargeItemList";
            this.Text = "医嘱执行单";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBIHChargeItemList_KeyDown);
            this.Load += new System.EventHandler(this.frmBIHChargeItemList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_ctlExecOrderGrid)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_ctlOrderChargeItem)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_ctlAllCharge)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region	清空
        /// <summary>
        /// 清空查询条件
        /// </summary>
        private void EmptyFindContext()
        {
            m_txtArea.Text = "";
            m_txtArea.Tag = "";
            m_txtDoctor.Text = "";
            m_txtDoctor.Tag = "";
            m_BedIDs = "";
            m_dtpExecute.Value = System.DateTime.Now;
        }
        /// <summary>
        /// 清空查询的内容和全局变量
        /// </summary>
        private void EmptyDataGrid()
        {
            m_ctlExecOrderGrid.m_mthDeleteAllRow();
            m_ctlOrderChargeItem.m_mthDeleteAllRow();
            m_ctlAllCharge.m_mthDeleteAllRow();
            m_arrExecOrderID = null;
            m_arrChargeItem = null;
            m_objCurrentCharge = null;
            m_objCurrentOrder = null;
            ClearChargeInfo();
        }
        /// <summary>
        /// 清空费用信息
        /// </summary>
        private void ClearChargeInfo()
        {
            m_txbPatientName.Text = "";
            m_txbItemName.Text = "";
            m_txbSumMoney.Text = "";
            m_txbBalanceMoney.Text = "";
        }
        /// <summary>
        /// 设置按钮
        /// </summary>
        private void ResetButton()
        {
            if (m_objCurrentCharge == null) return;
            if (m_objCurrentCharge.m_intPStatus == 0 || m_objCurrentCharge.m_intPStatus == 1)
            {
                this.m_cmdModifyChargeItem.Enabled = true;
                this.m_cmdDeleteChargeItem.Enabled = true;
            }
            else
            {
                this.m_cmdModifyChargeItem.Enabled = false;
                this.m_cmdDeleteChargeItem.Enabled = false;
            }
        }
        #endregion
        #region 窗体事件
        private void frmBIHChargeItemList_Load(object sender, System.EventArgs e)
        {
            m_objLoginInfo = this.LoginInfo;
            m_mthSetEnter2Tab(new System.Windows.Forms.Control[] { });
            new clsTextFocusHighlight().m_mthBindForm(this, true);
            if (m_objLoginInfo != null)
            {
                m_mthSetCurrentDoctor(m_objLoginInfo.m_strEmpID, m_objLoginInfo.m_strEmpName);
            }
            m_mthSetOrderList(null);
            //在导入时默认科室为当前员工所在科室 
            if (m_txtArea.Tag == null)
            {
                m_txtArea.Tag = this.LoginInfo.m_strInpatientAreaID;
                m_txtArea.Text = this.LoginInfo.m_strInpatientAreaName;
            }
            /*<---------------------------------------*/
        }
        private void frmBIHChargeItemList_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            m_mthSetKeyTab(e);
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    if (MessageBox.Show("是否确定退出", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.None) == DialogResult.Yes)
                    {
                        if (ActiveControl.ToString() != m_ctlExecOrderGrid.ToString())
                        {
                            this.Close();
                        }
                    }
                    break;
                case Keys.F3://查询
                    if (m_cmdRefresh.Enabled) m_cmdRefresh_Click(sender, e);
                    break;
                case Keys.F4://清空
                    if (cmdEmpty.Enabled) cmdEmpty_Click(sender, e);
                    break;
                case Keys.F5://添加
                    if (m_cmdAddChargeItem.Enabled) m_cmdAddChargeItem_Click(sender, e);
                    break;
                case Keys.F6://修改
                    if (m_cmdModifyChargeItem.Enabled) m_cmdModifyChargeItem_Click(sender, e);
                    break;
                case Keys.Delete://删除
                    if (m_cmdDeleteChargeItem.Enabled) m_cmdDeleteChargeItem_Click(sender, e);
                    break;
            }
        }
        #endregion
        #region 按钮事件
        /// <summary>
        /// 显示事件
        /// </summary>
        private void m_cmdRefresh_Click(object sender, System.EventArgs e)
        {
            if (m_chkOnlyCurrent.Checked)
            {
                #region 当前
                if ((m_arrExecOrderID == null) || (m_arrExecOrderID.Length <= 0)) return;

                //收费项目
                clsBIHPatientCharge[] arrCharge;
                long ret1 = m_lngGetChargeRecord(m_arrExecOrderID, out arrCharge);
                if ((ret1 > 0) && (arrCharge != null))
                    m_arrChargeItem = arrCharge;
                else
                    m_arrChargeItem = new clsBIHPatientCharge[0];
                m_mthShowChargeList(m_arrChargeItem);

                //执行单
                clsBIHExecOrder[] arrExecOrder;
                long ret2 = m_lngGetExecuteOrder(m_arrExecOrderID, out arrExecOrder);
                if ((ret2 > 0) && (arrExecOrder != null))
                {
                    m_mthShowExecOrderList(arrExecOrder);
                }
                #endregion
            }
            else
            {
                //清空
                EmptyDataGrid();
                #region 查询
                string strAreaID = "", strBedIDs = "", strDocID = "";
                if (m_txtArea.Tag != null && m_txtArea.Tag.ToString().Trim() != "" && m_txtArea.Text.Trim() != "")
                {
                    strAreaID = clsConverter.ToString(m_txtArea.Tag).Trim();
                    strBedIDs = m_BedIDs;
                }
                else
                {
                    m_txtArea.Text = "";
                    m_txtArea.Tag = "";
                    m_BedIDs = "";
                }
                if (strAreaID.Trim() == "")
                {
                    MessageBox.Show("病区必须选！", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_txtArea.Focus();
                    m_txtArea.SelectAll();
                    return;
                }
                if (m_txtDoctor.Tag != null && m_txtDoctor.Tag.ToString().Trim() != "" && m_txtDoctor.Text.Trim() != "")
                {
                    strDocID = m_txtDoctor.Tag.ToString().Trim();
                }
                DateTime dtExecute = m_dtpExecute.Value;
                clsBIHExecOrder[] arrExecOrder;
                long ret = m_objService.m_lngGetExecuteOrder(strAreaID, strBedIDs, dtExecute, strDocID, out arrExecOrder );
                if ((ret > 0) && (arrExecOrder != null))
                {
                    m_mthShowExecOrderList(arrExecOrder);
                }
                else
                {
                    arrExecOrder = new clsBIHExecOrder[0];
                    m_mthShowExecOrderList(arrExecOrder);
                    m_arrChargeItem = new clsBIHPatientCharge[0];
                    m_mthShowChargeList(m_arrChargeItem);
                    return;
                }
                string[] arrExecID = new string[arrExecOrder.Length];
                for (int i = 0; i < arrExecID.Length; i++) arrExecID[i] = arrExecOrder[i].m_strEOrderExecID;
                clsBIHPatientCharge[] arrCharge;
                long ret1 = m_lngGetChargeRecord(arrExecID, out arrCharge);
                if ((ret1 > 0) && (arrCharge != null))
                    m_arrChargeItem = arrCharge;
                else
                    m_arrChargeItem = new clsBIHPatientCharge[0];
                m_mthShowChargeList(m_arrChargeItem);
                #endregion
            }
        }
        private void cmdEmpty_Click(object sender, System.EventArgs e)
        {
            EmptyFindContext();
            EmptyDataGrid();
        }
        private void m_cmdExit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 添加事件
        /// </summary>
        private void m_cmdAddChargeItem_Click(object sender, System.EventArgs e)
        {
            if (m_objCurrentOrder != null)
            {
                if (m_objCurrentDoctor == null) return;
                //设置当前科室为申请科室  
                string strAreaID = m_txtArea.Tag.ToString().Trim();
                m_objCurrentOrder.m_strCREATEAREA_ID = strAreaID;
                frmChargeItem objForm = new frmChargeItem(m_objCurrentOrder, m_objCurrentDoctor.m_strDoctorID);
                clsBIHPatientCharge objCharge;
                bool ret = objForm.m_mthAddNew(out objCharge);
                if (ret)
                {
                    clsBIHPatientCharge[] arrCharge = new clsBIHPatientCharge[m_arrChargeItem.Length + 1];
                    Array.Copy(m_arrChargeItem, 0, arrCharge, 0, m_arrChargeItem.Length);
                    arrCharge[arrCharge.Length - 1] = objCharge;
                    m_arrChargeItem = arrCharge;
                    m_mthRefreshOrderChargeItem();
                    m_mthShowChargeList(m_arrChargeItem);
                }
            }
        }

        /// <summary>
        /// 修改事件
        /// </summary>
        private void m_cmdModifyChargeItem_Click(object sender, System.EventArgs e)
        {
            if ((m_objCurrentOrder != null) && (m_objCurrentCharge != null))
            {
                if (m_objCurrentDoctor == null) return;
                //string a=m_objCurrentCharge.m_strClacArea;
               // string b = m_objCurrentOrder.m_strExecDeptID;
                frmChargeItem objForm = new frmChargeItem(m_objCurrentCharge,m_objCurrentOrder, m_objCurrentDoctor.m_strDoctorID);
                //frmChargeItem objForm = new frmChargeItem(m_objCurrentOrder, m_objCurrentDoctor.m_strDoctorID);
                
                bool ret = objForm.m_mthModify(m_objCurrentCharge);
                if (ret)
                {
                    m_mthRefreshOrderChargeItem();
                    m_mthShowChargeList(m_arrChargeItem);
                }
            }
        }
        /// <summary>
        /// 删除事件
        /// </summary>
        private void m_cmdDeleteChargeItem_Click(object sender, System.EventArgs e)
        {
            if ((m_objCurrentOrder != null) && (m_objCurrentCharge != null))
            {
                if (MessageBox.Show(this, "是否删除收费项目:" + m_objCurrentCharge.m_strChargeItemName + "?", "删除收费项目", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string strChargeID = m_objCurrentCharge.m_strPChargeID.Trim();
                    bool ret = new frmChargeItem(m_objCurrentOrder, m_objCurrentDoctor.m_strDoctorID).m_blnDelete(strChargeID);
                    if (ret)
                    {
                        ArrayList arlCharge = new ArrayList();
                        for (int i = 0; i < m_arrChargeItem.Length; i++)
                        {
                            if (m_arrChargeItem[i].m_strPChargeID.Trim() == strChargeID)
                            { }
                            else
                            {
                                arlCharge.Add(m_arrChargeItem[i]);
                            }
                        }
                        m_arrChargeItem = (clsBIHPatientCharge[])(arlCharge.ToArray(typeof(clsBIHPatientCharge)));

                        m_mthRefreshOrderChargeItem();
                        m_mthShowChargeList(m_arrChargeItem);
                    }
                }
            }
        }

        /// <summary>
        /// 执行单ListView单元格改变事件
        /// </summary>
        private void m_ctlExecOrderGrid_m_evtCurrentCellChanged(object sender, System.EventArgs e)
        {
            m_mthRefreshOrderChargeItem();
        }
        /// <summary>
        /// 收费项目ListView单元格改变事件
        /// </summary>
        private void m_ctlOrderChargeItem_m_evtCurrentCellChanged(object sender, System.EventArgs e)
        {
            m_objCurrentCharge = null;
            int intRow = m_ctlOrderChargeItem.CurrentCell.RowNumber;
            if ((intRow >= 0) && (intRow < m_ctlOrderChargeItem.RowCount))
            {
                int intIndex = clsConverter.ToInt(m_ctlOrderChargeItem[intRow, "Index"]);
                if ((intIndex >= 0) && (intIndex < m_arrChargeItem.Length))
                {
                    m_objCurrentCharge = m_arrChargeItem[intIndex];
                }
            }
            ResetButton();
        }
        /// <summary>
        /// 收费项目ListView双击事件
        /// </summary>
        private void m_ctlOrderChargeItem_m_evtDoubleClickCell(object sender, com.digitalwave.controls.datagrid.clsDGTextMouseClickEventArgs e)
        {
            //m_cmdModifyChargeItem_Click(null, null);
        }
        #endregion
        #region 方法
        public void m_mthSetOrderList(string[] arrExecOrderID)
        {
            if (arrExecOrderID == null)
            {
                m_chkOnlyCurrent.Checked = false;
                m_chkOnlyCurrent.Enabled = false;
            }
            else
            {
                m_chkOnlyCurrent.Enabled = true;
                m_arrExecOrderID = arrExecOrderID;
                m_chkOnlyCurrent.Checked = true;
                m_cmdRefresh_Click(null, null);
            }

            if (LoginInfo != null)
            {
                m_mthSetCurrentDoctor(LoginInfo.m_strEmpID, LoginInfo.m_strEmpName);
            }
        }

        private string DateTimeToString(DateTime dtValue)
        {
            if (dtValue.Date == clsBIHOrder.m_dtNullDate.Date)
                return "";
            else
                return dtValue.ToString("yyyy-MM-dd HH:mm");
        }

        /// <summary>
        /// 显示执行单
        /// </summary>
        /// <param name="arrExecOrder">执行单Vo对象</param>
        private void m_mthShowExecOrderList(clsBIHExecOrder[] arrExecOrder)
        {
            m_arrExecOrder = arrExecOrder;
            if (m_arrExecOrder == null) m_arrExecOrder = new clsBIHExecOrder[0];

            m_ctlExecOrderGrid.m_mthDeleteAllRow();
            if ((arrExecOrder == null) || (arrExecOrder.Length <= 0)) return;

            m_ctlExecOrderGrid.BeginUpdate();
            for (int i = 0; i < arrExecOrder.Length; i++)
            {
                clsBIHExecOrder objOrder = arrExecOrder[i];
                DataRow objRow = m_ctlExecOrderGrid.NewRow();

                objRow["NO"] = i + 1;
                objRow["ExecOrderID"] = objOrder.m_strEOrderExecID;
                objRow["RegisterID"] = objOrder.m_strRegisterID;
                objRow["BedNo"] = objOrder.m_strBedName;
                objRow["PatientName"] = objOrder.m_strPatientName;
                objRow["RecipeNo"] = objOrder.m_intRecipenNo;
                objRow["OrderName"] = objOrder.m_strName;
                if (objOrder.m_dmlDosage > 0)
                    objRow["Dosage"] = objOrder.m_dmlDosage.ToString() + " " + objOrder.m_strDosageUnit;
                else
                    objRow["Dosage"] = "";
                if (objOrder.m_dmlUse > 0)
                    objRow["Use"] = objOrder.m_dmlUse.ToString() + " " + objOrder.m_strUseunit;
                else
                    objRow["Use"] = "";
                if (objOrder.m_dmlGet > 0)
                    objRow["Get"] = objOrder.m_dmlGet.ToString() + " " + objOrder.m_strGetunit;
                else
                    objRow["Get"] = "";
                //objRow["UnitPrice"]=objOrder.m_dmlPrice.ToString("0.0000");
                objRow["ExecuteFreq"] = objOrder.m_strExecFreqName;
                objRow["DosageType"] = objOrder.m_strDosetypeName;
                objRow["InceptState"] = (objOrder.m_intEIsIncept == 1) ? "已接收" : "未接收";
                objRow["CreateDate"] = DateTimeToString(objOrder.m_dtECreateDate);//
                objRow["ExecuteDate"] = DateTimeToString(objOrder.m_dtExecutedate);

                string strType = "";
                switch (objOrder.m_intEIsFirst)
                {
                    case 1:
                        strType = "长嘱";
                        break;
                    case 2:
                        strType = "临嘱";
                        break;
                    case 3:
                        strType = "长嘱新开加";
                        break;
                }
                objRow["IsFirst"] = strType;

                m_ctlExecOrderGrid.m_mthAppendRow(objRow);

            }
            m_ctlExecOrderGrid.EndUpdate();

            m_ctlOrderChargeItem.m_mthDeleteAllRow();
        }

        /// <summary>
        /// 显示费用明细
        /// </summary>
        /// <param name="arrCharge">费用明细Vo对象</param>
        private void m_mthShowChargeList(clsBIHPatientCharge[] arrCharge)
        {
            m_ctlAllCharge.m_mthDeleteAllRow();
            if ((arrCharge == null) || (arrCharge.Length <= 0)) return;

            m_ctlAllCharge.BeginUpdate();
            for (int i = 0; i < arrCharge.Length; i++)
            {
                clsBIHPatientCharge objCharge = arrCharge[i];
                DataRow objRow = m_ctlAllCharge.NewRow();
                objRow["BedNo"] = objCharge.m_strBedNo;
                objRow["PatientName"] = objCharge.m_strPatientName;
                objRow["ChargeItemName"] = objCharge.m_strChargeItemName;
                objRow["Amount"] = objCharge.m_dmlAmount.ToString() + objCharge.m_strUnit;
                objRow["UnitPrice"] = objCharge.m_dmlUnitPrice.ToString("0.0000");
                objRow["Money"] = (objCharge.m_dmlUnitPrice * objCharge.m_dmlAmount * objCharge.m_dmlDiscount).ToString("0.00");
                objRow["Discount"] = objCharge.m_dmlDiscount;
                //objRow["AcceptType"]="";
                //objRow["IsAccept"]="";
                //objRow["ChargeType"]="";
                objRow["ChargeStatus"] = clsOrderStatus.m_strGetChargeStatusMessage(objCharge.m_intPStatus);
                objRow["NO"] = i + 1;  
                objRow["execDept"] = objCharge.m_strExecDeptName; 
                m_ctlAllCharge.m_mthAppendRow(objRow);
            }
            m_ctlAllCharge.EndUpdate();
        }

        /// <summary>
        /// 刷新载入医嘱费用项
        /// </summary>
        private void m_mthRefreshOrderChargeItem()
        {
            m_ctlOrderChargeItem.m_mthDeleteAllRow();
            int intNo = 0;
            m_objCurrentOrder = null;
            int intRow = m_ctlExecOrderGrid.CurrentCell.RowNumber;
            if ((intRow < 0) && (intRow >= m_ctlExecOrderGrid.RowCount)) return;
            if (m_arrChargeItem == null) return;
            if ((intRow >= 0) && (intRow < m_arrExecOrder.Length))
                m_objCurrentOrder = m_arrExecOrder[intRow];
            string temp = m_objCurrentOrder.m_strExecDeptName;
            //病人姓名
            m_txbPatientName.Text = clsConverter.ToString(m_ctlExecOrderGrid[intRow, "PatientName"]).Trim();
            //项目名称
            m_txbItemName.Text = clsConverter.ToString(m_ctlExecOrderGrid[intRow, "OrderName"]).Trim();
            //累计费用	预交金余额	{余额超过病人费用下限的均突出显示}
            clsDcl_ExecuteOrder objTem = new clsDcl_ExecuteOrder();
            string strRegisterID = "";
            strRegisterID = clsConverter.ToString(m_ctlExecOrderGrid[intRow, "RegisterID"]).Trim();
            double dblSumMoney = 0;			//累计费用
            double dblBalanceMoney = 0;		//预交金余额
            double dblLowerLimitMoney = 0;	//费用下限
            try
            {
                dblSumMoney = objTem.m_dblGetSumMoneyByRegisterID(strRegisterID);
                dblBalanceMoney = objTem.m_dblGetBalanceMoneyByRegisterID(strRegisterID);
                dblLowerLimitMoney = objTem.m_dblGetLowerLimitMoneyByRegisterID(strRegisterID);
            }
            catch { }
            m_txbSumMoney.Text = dblSumMoney.ToString("0.00");
            m_txbBalanceMoney.Text = dblBalanceMoney.ToString("0.00");
            if (dblBalanceMoney <= dblLowerLimitMoney)
            {
                m_txbBalanceMoney.BackColor = System.Drawing.SystemColors.Highlight;
                m_txbBalanceMoney.ForeColor = System.Drawing.SystemColors.HighlightText;
            }
            else
            {
                m_txbBalanceMoney.BackColor = System.Drawing.SystemColors.Control;
                m_txbBalanceMoney.ForeColor = System.Drawing.Color.Red;
            }

            string strExecOrderID = m_ctlExecOrderGrid[intRow, "ExecOrderID"].ToString().Trim();
            for (int i = 0; i < m_arrChargeItem.Length; i++)
            {
                if (m_arrChargeItem[i].m_strOrderExecID.Trim() == strExecOrderID)
                {
                    DataRow objRow = m_ctlOrderChargeItem.NewRow();
                    clsBIHPatientCharge objCharge = m_arrChargeItem[i];

                    objRow["NO"] = ++intNo;
                    objRow["ChargeItemName"] = objCharge.m_strChargeItemName;
                    objRow["Amount"] = objCharge.m_dmlAmount.ToString();// + objCharge.m_strUnit;
                    objRow["UnitPrice"] = objCharge.m_dmlUnitPrice.ToString("0.0000");
                    objRow["Money"] = (objCharge.m_dmlUnitPrice * objCharge.m_dmlAmount * objCharge.m_dmlDiscount).ToString("0.00");
                    objRow["Discount"] = objCharge.m_dmlDiscount;
                    //objRow["AcceptType"]="";
                    //objRow["IsAccept"]="";
                    //objRow["ChargeType"]="";
                    objRow["ChargeStatus"] = clsOrderStatus.m_strGetChargeStatusMessage(objCharge.m_intPStatus);
                    objRow["Index"] = i;
                    // 增加执行地点
                    objRow["execDept"] = objCharge.m_strExecDeptName; 
                    m_ctlOrderChargeItem.m_mthAppendRow(objRow);
                }
            }
        }
        #endregion
        #region Convert
        private long m_lngGetChargeRecord(string[] arrExecOrderID, out clsBIHPatientCharge[] arrCharge)
        {
            if ((arrExecOrderID == null) || (arrExecOrderID.Length <= 0))
            {
                arrCharge = new clsBIHPatientCharge[0];
                return 1;
            }

            ArrayList arlCharge = new ArrayList();

            //
            int intStep = 40;
            int intLen = arrExecOrderID.Length / intStep;
            for (int i = 0; i <= intLen; i++)
            {
                int intStart = i * intStep;
                int intLength;
                if (i < intLen)
                    intLength = intStep;
                else
                    intLength = arrExecOrderID.Length - intStart;

                string[] arrID = new string[intLength];
                Array.Copy(arrExecOrderID, intStart, arrID, 0, intLength);

                clsBIHPatientCharge[] arrC;
                long ret = m_objService.m_lngGetChargeRecord(arrID, out arrC);
                if (ret > 0)
                {
                    if (arrC != null) arlCharge.AddRange(arrC);
                }
                else
                {
                    arrCharge = null;
                    return 0;
                }
            }

            //
            arrCharge = (clsBIHPatientCharge[])(arlCharge.ToArray(typeof(clsBIHPatientCharge)));
            return 1;
        }
        private long m_lngGetExecuteOrder(string[] arrExecOrderID, out clsBIHExecOrder[] arrExecOrder)
        {
            if ((arrExecOrderID == null) || (arrExecOrderID.Length <= 0))
            {
                arrExecOrder = new clsBIHExecOrder[0];
                return 1;
            }

            ArrayList arlOrder = new ArrayList();

            //
            int intStep = 40;
            int intLen = arrExecOrderID.Length / intStep;
            for (int i = 0; i <= intLen; i++)
            {
                int intStart = i * intStep;
                int intLength;
                if (i < intLen)
                    intLength = intStep;
                else
                    intLength = arrExecOrderID.Length - intStart;

                string[] arrID = new string[intLength];
                Array.Copy(arrExecOrderID, intStart, arrID, 0, intLength);

                clsBIHExecOrder[] arrC;

                long ret = m_objService.m_lngGetExecuteOrder(arrID, out arrC );
                if (ret > 0)
                {
                    if (arrC != null) arlOrder.AddRange(arrC);
                }
                else
                {
                    arrExecOrder = null;
                    return 0;
                }
            }

            //
            arrExecOrder = (clsBIHExecOrder[])(arlOrder.ToArray(typeof(clsBIHExecOrder)));
            return 1;
        }
        #endregion
        #region Focus
        private void m_txtDoctor_m_evtSelectItem(object sender, System.Windows.Forms.ListViewItem lviSelected)
        {
            m_dtpExecute.Focus();
        }

        #endregion
        #region INIT
        private clsBIHDoctor m_objCurrentDoctor;
        /// <summary>
        /// 设置当前操作员
        /// </summary>
        /// <param name="strDoctorID"></param>
        /// <param name="strDoctorName"></param>
        public void m_mthSetCurrentDoctor(string strDoctorID, string strDoctorName)
        {
            m_objCurrentDoctor = new clsBIHDoctor();
            m_objCurrentDoctor.m_strDoctorID = strDoctorID;
            m_objCurrentDoctor.m_strDoctorName = strDoctorName;
            //m_lblDoctor.Text="操作员:" + m_objCurrentDoctor.m_strDoctorName;
        }

        /// <summary>
        /// 设置过滤条件:医生
        /// </summary>
        /// <param name="strDocID"></param>
        /// <param name="strDocName"></param>
        public void m_mthSetDoctor(string strDocID, string strDocName)
        {
            m_txtDoctor.Tag = strDocID;
            m_txtDoctor.Text = strDocName;
        }
        public void m_mthSetExecuteDate(DateTime dtExecute)
        {
            m_dtpExecute.Value = dtExecute;
        }
        #endregion
        #region iLoginInfo 成员
        //		public clsLoginInfo LoginInfo
        //		{
        //			get
        //			{
        //				return m_objLoginInfo;
        //			}
        //			set
        //			{
        //				m_objLoginInfo=value;
        //			}
        //		}
        #endregion
        #region 床号相关
        private void m_txtArea_m_evtInitListView(System.Windows.Forms.ListView lvwList)
        {
            m_txtAreaInitListView(lvwList);
        }

        private void m_txtArea_m_evtFindItem(object sender, string strFindCode, System.Windows.Forms.ListView lvwList)
        {
            m_txtAreaFindItem(strFindCode, lvwList);
        }

        private void m_txtArea_m_evtSelectItem(object sender, System.Windows.Forms.ListViewItem lviSelected)
        {
            m_txtAreaSelectItem(lviSelected);
            m_txtBed.Focus();
        }
        private void m_lsvSelectBed_Leave(object sender, System.EventArgs e)
        {
            m_lsvSelectBedLeave();
        }
        private void m_lsvSelectBed_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
           
            if (e.KeyCode == Keys.Enter)
            {
                m_lsvSelectBedLeave();
                m_cmdRefresh.Focus();
            }
            else if (e.Modifiers ==Keys.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.A:
                        selectAll();
                        break;
                    case Keys.Z:
                        selectAllNo();
                        break;
                    case Keys.X:
                        ConvertSelect();
                        break;
                }
                
            }
        }

        #region 床位选择快捷键
        private void selectAllNo()
        {
            for (int i = 0; i < m_lsvSelectBed.Items.Count; i++)
            {
                m_lsvSelectBed.Items[i].Checked= false;
            }
        }

        private void ConvertSelect()
        {
            for (int i = 0; i < m_lsvSelectBed.Items.Count; i++)
            {
                m_lsvSelectBed.Items[i].Checked = !m_lsvSelectBed.Items[i].Checked;
            }
        }

        private void selectAll()
        {
            for (int i = 0; i < m_lsvSelectBed.Items.Count; i++)
            {
                m_lsvSelectBed.Items[i].Checked = true;
            }
        }
        #endregion

        private void m_txtBed_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_txtBedKeyDown();
            }
        }
        /// <summary>
        /// 设置病区
        /// </summary>
        /// <param name="p_strAreaID">病区ID</param>
        /// <param name="p_strAreaName">病区名称</param>
        public void m_mthSetCurrentArea(string p_strAreaID, string p_strAreaName)
        {
            m_txtArea.Text = p_strAreaName;
            m_txtArea.Tag = p_strAreaID;
            LoadBedListView();
        }
        /// <summary>
        /// 设置过滤条件:床号
        /// </summary>
        /// <param name="p_strBedIDs">用逗号分隔的病床ID</param>
        public void m_mthSetBed(string p_strBedIDs)
        {
            m_BedIDs = p_strBedIDs;
        }
        /// <summary>
        ///  获取或设置病床	根据ID
        /// </summary>
        public string m_BedIDs
        {
            get
            {
                if (this.m_txtBed.Tag == null) this.m_txtBed.Tag = "";
                return this.m_txtBed.Tag.ToString().Trim();
            }
            set
            {
                string strText = "";
                string strID = value;
                string[] strIDArr = strID.Split(new char[] { ',' });
                if (m_lsvSelectBed.Items.Count <= 0)
                {
                    if (this.m_txtArea.Tag != null && this.m_txtArea.Tag.ToString().Trim() != "")
                    {
                        LoadBedListView();
                    }
                    else
                    {
                        return;
                    }
                }
                clsT_Bse_Bed_VO objItem = new clsT_Bse_Bed_VO();
                for (int i1 = 0; i1 < m_lsvSelectBed.Items.Count; i1++)
                {
                    objItem = ((m_lsvSelectBed.Items[i1].Tag) as clsT_Bse_Bed_VO);
                    for (int i2 = 0; i2 < strIDArr.Length; i2++)
                    {
                        if (objItem.m_strBEDID_CHR.Trim() == strIDArr[i2].Trim())
                        {
                            if (strText.Trim() == "")
                                strText = objItem.m_strCODE_CHR.Trim();
                            else
                                strText += "," + objItem.m_strCODE_CHR.Trim();
                        }
                    }
                }
                m_txtBed.Text = strText;
                m_txtBed.Tag = strID;
            }
        }
        /// <summary>
        /// 载入病床信息
        /// </summary>
        public void LoadBedListView()
        {
            m_txtBed.Text = "";
            m_txtBed.Tag = "";
            m_lsvSelectBed.Items.Clear();
            if (m_txtArea.Tag == null) m_txtArea.Tag = "";
            string strAreaID = m_txtArea.Tag.ToString().Trim();
            if (strAreaID.Trim() == "") return;
            clsT_Bse_Bed_VO[] objItemArr;
            long lngRes = m_objInputOrder.m_lngGetBedInfoByAreaID(strAreaID, out objItemArr);
            if (lngRes > 0 && objItemArr != null && objItemArr.Length > 0)
            {
                #region 填充ListView
                ListViewItem lviTemp = null;
                for (int i1 = 0; i1 < objItemArr.Length; i1++)
                {
                    //序号
                    //lviTemp = new ListViewItem((i1+1).ToString());
                    //床号
                    //lviTemp.SubItems.Add(objItemArr[i1].m_strCODE_CHR);
                    //类别
                    //lviTemp.SubItems.Add(objItemArr[i1].m_strSexName);
                    //占床状态
                    //lviTemp.SubItems.Add(objItemArr[i1].m_strStatusName);		
                    lviTemp = new ListViewItem(objItemArr[i1].m_strCODE_CHR);
                    lviTemp.SubItems.Add(objItemArr[i1].m_strPatientName.Trim());
                    lviTemp.SubItems.Add(objItemArr[i1].m_strPatientSex.Trim());
		
                    lviTemp.Tag = objItemArr[i1];
                    m_lsvSelectBed.Items.Add(lviTemp);
                }
                #endregion
            }
        }
        /// <summary>
        /// 分隔符","号	Text保存床号	Tag保存ID
        /// </summary>
        public void m_lsvSelectBedLeave()
        {
            string strText = "";
            string strID = "";
            clsT_Bse_Bed_VO objItem = new clsT_Bse_Bed_VO();
            for (int i1 = 0; i1 < m_lsvSelectBed.Items.Count; i1++)
            {
                objItem = ((m_lsvSelectBed.Items[i1].Tag) as clsT_Bse_Bed_VO);
                if (m_lsvSelectBed.Items[i1].Checked)
                {
                    if (strText.Length > 0)
                    {
                        strText += ",";
                        strID += ",";
                    }
                    strText += objItem.m_strCODE_CHR.Trim();
                    strID += objItem.m_strBEDID_CHR.Trim();
                }
            }
            m_txtBed.Text = strText;
            m_txtBed.Tag = strID;
            m_lsvSelectBed.Visible = false;
        }
        public void m_txtBedKeyDown()
        {
            LoadBedListView();
            //载入数据	
            #region 载入数据
            if (m_txtBed.Tag == null) m_txtBed.Tag = "";
            string strID = m_txtBed.Tag.ToString().Trim();
            string[] strIDArr = strID.Split(new char[] { ',' });
            if (strIDArr != null && strIDArr.Length > 0)
            {
                for (int i = 0; i < m_lsvSelectBed.Items.Count; i++)
                {
                    clsT_Bse_Bed_VO objItem = (m_lsvSelectBed.Items[i].Tag as clsT_Bse_Bed_VO);
                    if (objItem == null) continue;
                    strID = objItem.m_strBEDID_CHR.Trim();
                    m_lsvSelectBed.Items[i].Checked = false;
                    for (int j = 0; j < strIDArr.Length; j++)
                    {
                        if (strID == strIDArr[j].Trim())
                        {
                            m_lsvSelectBed.Items[i].Checked = true;
                            break;
                        }
                    }
                }
            }
            #endregion
            m_lsvSelectBed.Visible = true;
            m_lsvSelectBed.Focus();
        }
        public void m_txtAreaInitListView(System.Windows.Forms.ListView lvwList)
        {
            lvwList.Columns.Add("", 100, HorizontalAlignment.Left);
            lvwList.Width = 120;
        }
        public void m_txtAreaFindItem(string strFindCode, System.Windows.Forms.ListView lvwList)
        {
            clsBIHArea[] objItemArr;
            long lngRes = m_objInputOrder.m_lngFindArea(strFindCode, out objItemArr);
            if (lngRes > 0 && objItemArr != null && objItemArr.Length > 0)
            {
                //获取有权限访问的病区ID集合
                if (this.LoginInfo != null)
                {
                    IList ilUsableAreaID = this.LoginInfo.m_ilUsableAreaID;
                    clsDcl_InputOrder objInputOrder = new clsDcl_InputOrder();
                    objItemArr = (clsBIHArea[])(objInputOrder.GetUsableAreaObject(objItemArr, ilUsableAreaID)).ToArray(typeof(clsBIHArea));
                }
                for (int i = 0; i < objItemArr.Length; i++)
                {
                    ListViewItem lvi = lvwList.Items.Add(objItemArr[i].m_strAreaName);
                    lvi.Tag = objItemArr[i].m_strAreaID;
                }
            }
        }
        public void m_txtAreaSelectItem(System.Windows.Forms.ListViewItem lviSelected)
        {
            if (lviSelected != null)
            {
                m_txtArea.Text = lviSelected.Text;
                m_txtArea.Tag = lviSelected.Tag;
                //LoadBedListView();
            }
        }
        #endregion
    }
}
