using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
namespace com.digitalwave.iCare.gui.LIS
{
	/// <summary>
	/// 用户申请单元信息维护界面
	/// </summary>
	public class frmApplUserGroup : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{

		#region 控件申明

		internal System.Windows.Forms.TreeView trvCheckGroup;
		private System.Windows.Forms.GroupBox groupBox2;
		internal System.Windows.Forms.TextBox txtAssist02;
		private System.Windows.Forms.Label lbAssist02;
		internal System.Windows.Forms.TextBox txtAssist01;
		private System.Windows.Forms.Label lbAssist01;
		internal System.Windows.Forms.TextBox txtCheckGroupNo;
		private System.Windows.Forms.Label label1;
		internal System.Windows.Forms.TextBox txtPyCode;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label18;
		internal System.Windows.Forms.TextBox txtWbCode;
		internal System.Windows.Forms.TextBox txtCheckGroupName;
		private System.Windows.Forms.Label label2;
		internal System.Windows.Forms.RadioButton rdbApplUnit;
		internal System.Windows.Forms.RadioButton rdbSelfDefine;
		private System.Windows.Forms.TabControl tbcCheckGroupDetail;
		private System.Windows.Forms.TabPage tpCheckItem;
		private System.Windows.Forms.Label lbAddCheckItem;
		private System.Windows.Forms.Label lbAllCheckItem;
		internal System.Windows.Forms.ListView lsvAddCheckItem;
		internal System.Windows.Forms.ListView lsvCheckItem;
		private System.Windows.Forms.Label label3;
		internal System.Windows.Forms.ComboBox cboCheckCategory;
		internal System.Windows.Forms.Button btnDelCheckItem;
		private System.Windows.Forms.Button btnNewCheck;
		private System.Windows.Forms.TabPage tpSubGroup;
		internal System.Windows.Forms.TreeView trvAddSubGroup;
		internal System.Windows.Forms.TreeView trvSubCheckGroup;
		internal System.Windows.Forms.Button btnDelSubGroup;
		private System.Windows.Forms.Button btnNewSubGroup;
		internal System.Windows.Forms.ListView lsvSubGroupCheckItem;
		private System.Windows.Forms.ColumnHeader chAddCheckItemID;
		private System.Windows.Forms.ColumnHeader chAddCheckItemEN;
		private System.Windows.Forms.ColumnHeader chAddCheckItemName;
		private System.Windows.Forms.ColumnHeader chCheckItemID;
		private System.Windows.Forms.ColumnHeader chCheckItemEn;
		private System.Windows.Forms.ColumnHeader chCheckItemName;
		private System.Windows.Forms.ColumnHeader chGroupCheckItemID;
		private System.Windows.Forms.ColumnHeader chGroupEN;
		private System.Windows.Forms.ColumnHeader chGroupCheckItemName;
		private System.Windows.Forms.Button btnDelCheckGroup;
		internal System.Windows.Forms.Button btnSaveCheckGroup;
		private System.Windows.Forms.Button btnNewCheckGroup;
		private System.Windows.Forms.GroupBox gbBaseInfo;
		private System.Windows.Forms.Label lbRequire;
		internal System.Windows.Forms.CheckBox chkReservation;
		internal System.Windows.Forms.CheckBox chkBodyCheck;
		internal System.Windows.Forms.CheckBox chkNoFood;
		private System.Windows.Forms.Label lbApplUnitOtherName;
		internal System.Windows.Forms.TextBox txtApplUnitOtherName;
		private System.Windows.Forms.Label m_lbPrice;
		private System.Windows.Forms.Label m_lbCost;
		internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric m_txtPrice;
		internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric m_txtCost;
		private System.Windows.Forms.Label m_lbCostUnit;
		private System.Windows.Forms.Label m_lbPriceUnit;

        private System.Windows.Forms.Label lbAddSubGroup;
        internal com.digitalwave.iCare.gui.LIS.ctlLISSampleTypeComboBox m_cboSampleType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblSummary;
        internal System.Windows.Forms.TextBox txtSummary;
        internal System.Windows.Forms.CheckBox chkOutCheckFlag;
        private System.Windows.Forms.Panel m_pnlProperty;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage m_tabCommon;
        private System.Windows.Forms.TabPage m_tabProperty;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel m_pnlList;
        private System.Windows.Forms.Button m_btnSave;
        private System.Windows.Forms.Button m_btnPaste;
        private System.Windows.Forms.Button m_btnCopy;
        private System.Windows.Forms.Button m_btnClear;
        private Button btnExit0;
        private Label label5;
        internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric txtReportHour;
        private Label label4;
        internal TextBox txtSamplingInstr;
        private Label label7;


        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

		#endregion

        #region 构造函数

        public frmApplUserGroup()
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("申请单元");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("自定义申请组");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("申请单元");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("自定义申请组");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("申请单元");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("自定义申请组");
            this.trvCheckGroup = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblSummary = new System.Windows.Forms.Label();
            this.txtAssist02 = new System.Windows.Forms.TextBox();
            this.lbAssist02 = new System.Windows.Forms.Label();
            this.txtAssist01 = new System.Windows.Forms.TextBox();
            this.lbAssist01 = new System.Windows.Forms.Label();
            this.txtCheckGroupNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPyCode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtWbCode = new System.Windows.Forms.TextBox();
            this.txtCheckGroupName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rdbApplUnit = new System.Windows.Forms.RadioButton();
            this.rdbSelfDefine = new System.Windows.Forms.RadioButton();
            this.txtSummary = new System.Windows.Forms.TextBox();
            this.tbcCheckGroupDetail = new System.Windows.Forms.TabControl();
            this.tpCheckItem = new System.Windows.Forms.TabPage();
            this.lbAddCheckItem = new System.Windows.Forms.Label();
            this.lbAllCheckItem = new System.Windows.Forms.Label();
            this.lsvAddCheckItem = new System.Windows.Forms.ListView();
            this.chAddCheckItemID = new System.Windows.Forms.ColumnHeader();
            this.chAddCheckItemEN = new System.Windows.Forms.ColumnHeader();
            this.chAddCheckItemName = new System.Windows.Forms.ColumnHeader();
            this.lsvCheckItem = new System.Windows.Forms.ListView();
            this.chCheckItemID = new System.Windows.Forms.ColumnHeader();
            this.chCheckItemEn = new System.Windows.Forms.ColumnHeader();
            this.chCheckItemName = new System.Windows.Forms.ColumnHeader();
            this.label3 = new System.Windows.Forms.Label();
            this.cboCheckCategory = new System.Windows.Forms.ComboBox();
            this.btnDelCheckItem = new System.Windows.Forms.Button();
            this.btnNewCheck = new System.Windows.Forms.Button();
            this.tpSubGroup = new System.Windows.Forms.TabPage();
            this.trvAddSubGroup = new System.Windows.Forms.TreeView();
            this.lbAddSubGroup = new System.Windows.Forms.Label();
            this.trvSubCheckGroup = new System.Windows.Forms.TreeView();
            this.btnDelSubGroup = new System.Windows.Forms.Button();
            this.btnNewSubGroup = new System.Windows.Forms.Button();
            this.lsvSubGroupCheckItem = new System.Windows.Forms.ListView();
            this.chGroupCheckItemID = new System.Windows.Forms.ColumnHeader();
            this.chGroupEN = new System.Windows.Forms.ColumnHeader();
            this.chGroupCheckItemName = new System.Windows.Forms.ColumnHeader();
            this.btnDelCheckGroup = new System.Windows.Forms.Button();
            this.btnSaveCheckGroup = new System.Windows.Forms.Button();
            this.btnNewCheckGroup = new System.Windows.Forms.Button();
            this.gbBaseInfo = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtReportHour = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
            this.label4 = new System.Windows.Forms.Label();
            this.m_lbCostUnit = new System.Windows.Forms.Label();
            this.m_txtCost = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
            this.m_txtPrice = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
            this.m_lbCost = new System.Windows.Forms.Label();
            this.m_lbPrice = new System.Windows.Forms.Label();
            this.txtApplUnitOtherName = new System.Windows.Forms.TextBox();
            this.lbApplUnitOtherName = new System.Windows.Forms.Label();
            this.lbRequire = new System.Windows.Forms.Label();
            this.chkReservation = new System.Windows.Forms.CheckBox();
            this.chkBodyCheck = new System.Windows.Forms.CheckBox();
            this.chkNoFood = new System.Windows.Forms.CheckBox();
            this.m_lbPriceUnit = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chkOutCheckFlag = new System.Windows.Forms.CheckBox();
            this.m_pnlProperty = new System.Windows.Forms.Panel();
            this.m_pnlList = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_btnClear = new System.Windows.Forms.Button();
            this.m_btnCopy = new System.Windows.Forms.Button();
            this.m_btnSave = new System.Windows.Forms.Button();
            this.m_btnPaste = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.m_tabCommon = new System.Windows.Forms.TabPage();
            this.m_tabProperty = new System.Windows.Forms.TabPage();
            this.btnExit0 = new System.Windows.Forms.Button();
            this.txtSamplingInstr = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.m_cboSampleType = new com.digitalwave.iCare.gui.LIS.ctlLISSampleTypeComboBox();
            this.groupBox2.SuspendLayout();
            this.tbcCheckGroupDetail.SuspendLayout();
            this.tpCheckItem.SuspendLayout();
            this.tpSubGroup.SuspendLayout();
            this.gbBaseInfo.SuspendLayout();
            this.m_pnlProperty.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // trvCheckGroup
            // 
            this.trvCheckGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.trvCheckGroup.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.trvCheckGroup.HideSelection = false;
            this.trvCheckGroup.Location = new System.Drawing.Point(4, 8);
            this.trvCheckGroup.Name = "trvCheckGroup";
            treeNode1.Name = "";
            treeNode1.Text = "申请单元";
            treeNode2.Name = "";
            treeNode2.Text = "自定义申请组";
            this.trvCheckGroup.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.trvCheckGroup.Size = new System.Drawing.Size(228, 496);
            this.trvCheckGroup.TabIndex = 45;
            this.trvCheckGroup.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvCheckGroup_AfterSelect);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lblSummary);
            this.groupBox2.Controls.Add(this.txtAssist02);
            this.groupBox2.Controls.Add(this.lbAssist02);
            this.groupBox2.Controls.Add(this.txtAssist01);
            this.groupBox2.Controls.Add(this.lbAssist01);
            this.groupBox2.Controls.Add(this.txtCheckGroupNo);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtPyCode);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.txtWbCode);
            this.groupBox2.Controls.Add(this.txtCheckGroupName);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.rdbApplUnit);
            this.groupBox2.Controls.Add(this.rdbSelfDefine);
            this.groupBox2.Controls.Add(this.txtSummary);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(240, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(400, 136);
            this.groupBox2.TabIndex = 46;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "检验组信息";
            // 
            // lblSummary
            // 
            this.lblSummary.AutoSize = true;
            this.lblSummary.Location = new System.Drawing.Point(240, 104);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(35, 14);
            this.lblSummary.TabIndex = 37;
            this.lblSummary.Text = "备注";
            // 
            // txtAssist02
            // 
            this.txtAssist02.Location = new System.Drawing.Point(280, 72);
            this.txtAssist02.Name = "txtAssist02";
            this.txtAssist02.Size = new System.Drawing.Size(112, 23);
            this.txtAssist02.TabIndex = 36;
            // 
            // lbAssist02
            // 
            this.lbAssist02.Location = new System.Drawing.Point(200, 80);
            this.lbAssist02.Name = "lbAssist02";
            this.lbAssist02.Size = new System.Drawing.Size(80, 16);
            this.lbAssist02.TabIndex = 35;
            this.lbAssist02.Text = "第二助记码";
            // 
            // txtAssist01
            // 
            this.txtAssist01.Location = new System.Drawing.Point(88, 72);
            this.txtAssist01.Name = "txtAssist01";
            this.txtAssist01.Size = new System.Drawing.Size(104, 23);
            this.txtAssist01.TabIndex = 34;
            // 
            // lbAssist01
            // 
            this.lbAssist01.Location = new System.Drawing.Point(8, 80);
            this.lbAssist01.Name = "lbAssist01";
            this.lbAssist01.Size = new System.Drawing.Size(80, 16);
            this.lbAssist01.TabIndex = 33;
            this.lbAssist01.Text = "第一助记码";
            // 
            // txtCheckGroupNo
            // 
            this.txtCheckGroupNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCheckGroupNo.Location = new System.Drawing.Point(88, 24);
            this.txtCheckGroupNo.Name = "txtCheckGroupNo";
            this.txtCheckGroupNo.ReadOnly = true;
            this.txtCheckGroupNo.Size = new System.Drawing.Size(104, 23);
            this.txtCheckGroupNo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "检验组号";
            // 
            // txtPyCode
            // 
            this.txtPyCode.Location = new System.Drawing.Point(88, 48);
            this.txtPyCode.MaxLength = 10;
            this.txtPyCode.Name = "txtPyCode";
            this.txtPyCode.Size = new System.Drawing.Size(104, 23);
            this.txtPyCode.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(8, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 16);
            this.label9.TabIndex = 27;
            this.label9.Text = "拼音助记符";
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(200, 56);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(80, 16);
            this.label18.TabIndex = 28;
            this.label18.Text = "五笔助记符";
            // 
            // txtWbCode
            // 
            this.txtWbCode.Location = new System.Drawing.Point(280, 48);
            this.txtWbCode.MaxLength = 10;
            this.txtWbCode.Name = "txtWbCode";
            this.txtWbCode.Size = new System.Drawing.Size(112, 23);
            this.txtWbCode.TabIndex = 29;
            // 
            // txtCheckGroupName
            // 
            this.txtCheckGroupName.Location = new System.Drawing.Point(280, 24);
            this.txtCheckGroupName.MaxLength = 30;
            this.txtCheckGroupName.Name = "txtCheckGroupName";
            this.txtCheckGroupName.Size = new System.Drawing.Size(112, 23);
            this.txtCheckGroupName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(200, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "检验组名称";
            // 
            // rdbApplUnit
            // 
            this.rdbApplUnit.Location = new System.Drawing.Point(8, 104);
            this.rdbApplUnit.Name = "rdbApplUnit";
            this.rdbApplUnit.Size = new System.Drawing.Size(88, 24);
            this.rdbApplUnit.TabIndex = 30;
            this.rdbApplUnit.Text = "申请单元";
            this.rdbApplUnit.CheckedChanged += new System.EventHandler(this.rdbApplUnit_CheckedChanged);
            // 
            // rdbSelfDefine
            // 
            this.rdbSelfDefine.Location = new System.Drawing.Point(96, 104);
            this.rdbSelfDefine.Name = "rdbSelfDefine";
            this.rdbSelfDefine.Size = new System.Drawing.Size(112, 24);
            this.rdbSelfDefine.TabIndex = 31;
            this.rdbSelfDefine.Text = "自定义申请组";
            this.rdbSelfDefine.CheckedChanged += new System.EventHandler(this.rdbSelfDefine_CheckedChanged);
            // 
            // txtSummary
            // 
            this.txtSummary.Location = new System.Drawing.Point(280, 96);
            this.txtSummary.Name = "txtSummary";
            this.txtSummary.Size = new System.Drawing.Size(112, 23);
            this.txtSummary.TabIndex = 38;
            this.txtSummary.Leave += new System.EventHandler(this.txtSummary_Leave);
            this.txtSummary.Enter += new System.EventHandler(this.txtSummary_Enter);
            // 
            // tbcCheckGroupDetail
            // 
            this.tbcCheckGroupDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcCheckGroupDetail.Controls.Add(this.tpCheckItem);
            this.tbcCheckGroupDetail.Controls.Add(this.tpSubGroup);
            this.tbcCheckGroupDetail.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbcCheckGroupDetail.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbcCheckGroupDetail.Location = new System.Drawing.Point(240, 180);
            this.tbcCheckGroupDetail.Name = "tbcCheckGroupDetail";
            this.tbcCheckGroupDetail.SelectedIndex = 0;
            this.tbcCheckGroupDetail.Size = new System.Drawing.Size(764, 328);
            this.tbcCheckGroupDetail.TabIndex = 47;
            // 
            // tpCheckItem
            // 
            this.tpCheckItem.Controls.Add(this.lbAddCheckItem);
            this.tpCheckItem.Controls.Add(this.lbAllCheckItem);
            this.tpCheckItem.Controls.Add(this.lsvAddCheckItem);
            this.tpCheckItem.Controls.Add(this.lsvCheckItem);
            this.tpCheckItem.Controls.Add(this.label3);
            this.tpCheckItem.Controls.Add(this.cboCheckCategory);
            this.tpCheckItem.Controls.Add(this.btnDelCheckItem);
            this.tpCheckItem.Controls.Add(this.btnNewCheck);
            this.tpCheckItem.Location = new System.Drawing.Point(4, 24);
            this.tpCheckItem.Name = "tpCheckItem";
            this.tpCheckItem.Size = new System.Drawing.Size(756, 300);
            this.tpCheckItem.TabIndex = 0;
            this.tpCheckItem.Text = "检验项目";
            // 
            // lbAddCheckItem
            // 
            this.lbAddCheckItem.Location = new System.Drawing.Point(344, 40);
            this.lbAddCheckItem.Name = "lbAddCheckItem";
            this.lbAddCheckItem.Size = new System.Drawing.Size(64, 16);
            this.lbAddCheckItem.TabIndex = 33;
            this.lbAddCheckItem.Text = "检验项目";
            // 
            // lbAllCheckItem
            // 
            this.lbAllCheckItem.Location = new System.Drawing.Point(8, 40);
            this.lbAllCheckItem.Name = "lbAllCheckItem";
            this.lbAllCheckItem.Size = new System.Drawing.Size(100, 16);
            this.lbAllCheckItem.TabIndex = 32;
            this.lbAllCheckItem.Text = "所有检验项目";
            // 
            // lsvAddCheckItem
            // 
            this.lsvAddCheckItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvAddCheckItem.CheckBoxes = true;
            this.lsvAddCheckItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chAddCheckItemID,
            this.chAddCheckItemEN,
            this.chAddCheckItemName});
            this.lsvAddCheckItem.FullRowSelect = true;
            this.lsvAddCheckItem.HideSelection = false;
            this.lsvAddCheckItem.Location = new System.Drawing.Point(344, 56);
            this.lsvAddCheckItem.MultiSelect = false;
            this.lsvAddCheckItem.Name = "lsvAddCheckItem";
            this.lsvAddCheckItem.Size = new System.Drawing.Size(388, 199);
            this.lsvAddCheckItem.TabIndex = 3;
            this.lsvAddCheckItem.UseCompatibleStateImageBehavior = false;
            this.lsvAddCheckItem.View = System.Windows.Forms.View.Details;
            // 
            // chAddCheckItemID
            // 
            this.chAddCheckItemID.Text = "检验编号";
            this.chAddCheckItemID.Width = 80;
            // 
            // chAddCheckItemEN
            // 
            this.chAddCheckItemEN.Text = "英文名称";
            this.chAddCheckItemEN.Width = 80;
            // 
            // chAddCheckItemName
            // 
            this.chAddCheckItemName.Text = "检验名称";
            this.chAddCheckItemName.Width = 100;
            // 
            // lsvCheckItem
            // 
            this.lsvCheckItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lsvCheckItem.CheckBoxes = true;
            this.lsvCheckItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chCheckItemID,
            this.chCheckItemEn,
            this.chCheckItemName});
            this.lsvCheckItem.FullRowSelect = true;
            this.lsvCheckItem.HideSelection = false;
            this.lsvCheckItem.Location = new System.Drawing.Point(8, 56);
            this.lsvCheckItem.MultiSelect = false;
            this.lsvCheckItem.Name = "lsvCheckItem";
            this.lsvCheckItem.Size = new System.Drawing.Size(320, 199);
            this.lsvCheckItem.TabIndex = 2;
            this.lsvCheckItem.UseCompatibleStateImageBehavior = false;
            this.lsvCheckItem.View = System.Windows.Forms.View.Details;
            // 
            // chCheckItemID
            // 
            this.chCheckItemID.Text = "检验编号";
            this.chCheckItemID.Width = 80;
            // 
            // chCheckItemEn
            // 
            this.chCheckItemEn.Text = "英文名称";
            this.chCheckItemEn.Width = 80;
            // 
            // chCheckItemName
            // 
            this.chCheckItemName.Text = "检验名称";
            this.chCheckItemName.Width = 100;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "检验类别";
            // 
            // cboCheckCategory
            // 
            this.cboCheckCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCheckCategory.Location = new System.Drawing.Point(80, 8);
            this.cboCheckCategory.Name = "cboCheckCategory";
            this.cboCheckCategory.Size = new System.Drawing.Size(112, 22);
            this.cboCheckCategory.TabIndex = 0;
            this.cboCheckCategory.SelectedIndexChanged += new System.EventHandler(this.cboCheckCategory_SelectedIndexChanged);
            // 
            // btnDelCheckItem
            // 
            this.btnDelCheckItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelCheckItem.Enabled = false;
            this.btnDelCheckItem.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelCheckItem.Location = new System.Drawing.Point(668, 263);
            this.btnDelCheckItem.Name = "btnDelCheckItem";
            this.btnDelCheckItem.Size = new System.Drawing.Size(75, 23);
            this.btnDelCheckItem.TabIndex = 31;
            this.btnDelCheckItem.Text = "删除";
            this.btnDelCheckItem.Click += new System.EventHandler(this.btnDelCheckItem_Click);
            // 
            // btnNewCheck
            // 
            this.btnNewCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewCheck.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNewCheck.Location = new System.Drawing.Point(572, 263);
            this.btnNewCheck.Name = "btnNewCheck";
            this.btnNewCheck.Size = new System.Drawing.Size(75, 23);
            this.btnNewCheck.TabIndex = 30;
            this.btnNewCheck.Text = "添加";
            this.btnNewCheck.Click += new System.EventHandler(this.btnNewCheck_Click);
            // 
            // tpSubGroup
            // 
            this.tpSubGroup.Controls.Add(this.trvAddSubGroup);
            this.tpSubGroup.Controls.Add(this.lbAddSubGroup);
            this.tpSubGroup.Controls.Add(this.trvSubCheckGroup);
            this.tpSubGroup.Controls.Add(this.btnDelSubGroup);
            this.tpSubGroup.Controls.Add(this.btnNewSubGroup);
            this.tpSubGroup.Controls.Add(this.lsvSubGroupCheckItem);
            this.tpSubGroup.Location = new System.Drawing.Point(4, 24);
            this.tpSubGroup.Name = "tpSubGroup";
            this.tpSubGroup.Size = new System.Drawing.Size(756, 300);
            this.tpSubGroup.TabIndex = 1;
            this.tpSubGroup.Text = "检组子组";
            this.tpSubGroup.Visible = false;
            // 
            // trvAddSubGroup
            // 
            this.trvAddSubGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trvAddSubGroup.CheckBoxes = true;
            this.trvAddSubGroup.HideSelection = false;
            this.trvAddSubGroup.Location = new System.Drawing.Point(388, 16);
            this.trvAddSubGroup.Name = "trvAddSubGroup";
            treeNode3.Name = "";
            treeNode3.Text = "申请单元";
            treeNode4.Name = "";
            treeNode4.Text = "自定义申请组";
            this.trvAddSubGroup.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4});
            this.trvAddSubGroup.Size = new System.Drawing.Size(360, 239);
            this.trvAddSubGroup.TabIndex = 39;
            this.trvAddSubGroup.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.trvAddSubGroup_AfterCheck);
            // 
            // lbAddSubGroup
            // 
            this.lbAddSubGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAddSubGroup.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbAddSubGroup.Location = new System.Drawing.Point(428, -1);
            this.lbAddSubGroup.Name = "lbAddSubGroup";
            this.lbAddSubGroup.Size = new System.Drawing.Size(64, 16);
            this.lbAddSubGroup.TabIndex = 38;
            this.lbAddSubGroup.Text = "检验子组";
            // 
            // trvSubCheckGroup
            // 
            this.trvSubCheckGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trvSubCheckGroup.CheckBoxes = true;
            this.trvSubCheckGroup.HideSelection = false;
            this.trvSubCheckGroup.Location = new System.Drawing.Point(16, 16);
            this.trvSubCheckGroup.Name = "trvSubCheckGroup";
            treeNode5.Name = "";
            treeNode5.Text = "申请单元";
            treeNode6.Name = "";
            treeNode6.Text = "自定义申请组";
            this.trvSubCheckGroup.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6});
            this.trvSubCheckGroup.Size = new System.Drawing.Size(348, 239);
            this.trvSubCheckGroup.TabIndex = 35;
            this.trvSubCheckGroup.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.trvSubCheckGroup_AfterCheck);
            this.trvSubCheckGroup.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvSubCheckGroup_AfterSelect);
            // 
            // btnDelSubGroup
            // 
            this.btnDelSubGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelSubGroup.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelSubGroup.Location = new System.Drawing.Point(668, 263);
            this.btnDelSubGroup.Name = "btnDelSubGroup";
            this.btnDelSubGroup.Size = new System.Drawing.Size(75, 23);
            this.btnDelSubGroup.TabIndex = 33;
            this.btnDelSubGroup.Text = "删除";
            this.btnDelSubGroup.Click += new System.EventHandler(this.btnDelSubGroup_Click);
            // 
            // btnNewSubGroup
            // 
            this.btnNewSubGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewSubGroup.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNewSubGroup.Location = new System.Drawing.Point(572, 263);
            this.btnNewSubGroup.Name = "btnNewSubGroup";
            this.btnNewSubGroup.Size = new System.Drawing.Size(75, 23);
            this.btnNewSubGroup.TabIndex = 32;
            this.btnNewSubGroup.Text = "添加";
            this.btnNewSubGroup.Click += new System.EventHandler(this.btnNewSubGroup_Click);
            // 
            // lsvSubGroupCheckItem
            // 
            this.lsvSubGroupCheckItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvSubGroupCheckItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chGroupCheckItemID,
            this.chGroupEN,
            this.chGroupCheckItemName});
            this.lsvSubGroupCheckItem.FullRowSelect = true;
            this.lsvSubGroupCheckItem.HideSelection = false;
            this.lsvSubGroupCheckItem.Location = new System.Drawing.Point(388, 16);
            this.lsvSubGroupCheckItem.Name = "lsvSubGroupCheckItem";
            this.lsvSubGroupCheckItem.Size = new System.Drawing.Size(360, 55);
            this.lsvSubGroupCheckItem.TabIndex = 1;
            this.lsvSubGroupCheckItem.UseCompatibleStateImageBehavior = false;
            this.lsvSubGroupCheckItem.View = System.Windows.Forms.View.Details;
            // 
            // chGroupCheckItemID
            // 
            this.chGroupCheckItemID.Text = "检验编号";
            this.chGroupCheckItemID.Width = 80;
            // 
            // chGroupEN
            // 
            this.chGroupEN.Text = "英文名称";
            this.chGroupEN.Width = 80;
            // 
            // chGroupCheckItemName
            // 
            this.chGroupCheckItemName.Text = "检验名称";
            this.chGroupCheckItemName.Width = 100;
            // 
            // btnDelCheckGroup
            // 
            this.btnDelCheckGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelCheckGroup.Location = new System.Drawing.Point(822, 528);
            this.btnDelCheckGroup.Name = "btnDelCheckGroup";
            this.btnDelCheckGroup.Size = new System.Drawing.Size(75, 23);
            this.btnDelCheckGroup.TabIndex = 50;
            this.btnDelCheckGroup.Text = "删除";
            this.btnDelCheckGroup.Click += new System.EventHandler(this.btnDelCheckGroup_Click);
            // 
            // btnSaveCheckGroup
            // 
            this.btnSaveCheckGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveCheckGroup.Location = new System.Drawing.Point(726, 528);
            this.btnSaveCheckGroup.Name = "btnSaveCheckGroup";
            this.btnSaveCheckGroup.Size = new System.Drawing.Size(75, 23);
            this.btnSaveCheckGroup.TabIndex = 49;
            this.btnSaveCheckGroup.Text = "保存";
            this.btnSaveCheckGroup.Click += new System.EventHandler(this.btnSaveCheckGroup_Click);
            // 
            // btnNewCheckGroup
            // 
            this.btnNewCheckGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewCheckGroup.Location = new System.Drawing.Point(630, 528);
            this.btnNewCheckGroup.Name = "btnNewCheckGroup";
            this.btnNewCheckGroup.Size = new System.Drawing.Size(75, 23);
            this.btnNewCheckGroup.TabIndex = 48;
            this.btnNewCheckGroup.Text = "新增";
            this.btnNewCheckGroup.Click += new System.EventHandler(this.btnNewCheckGroup_Click);
            // 
            // gbBaseInfo
            // 
            this.gbBaseInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbBaseInfo.Controls.Add(this.txtSamplingInstr);
            this.gbBaseInfo.Controls.Add(this.label7);
            this.gbBaseInfo.Controls.Add(this.txtReportHour);
            this.gbBaseInfo.Controls.Add(this.label5);
            this.gbBaseInfo.Controls.Add(this.label4);
            this.gbBaseInfo.Controls.Add(this.m_lbCostUnit);
            this.gbBaseInfo.Controls.Add(this.m_txtCost);
            this.gbBaseInfo.Controls.Add(this.m_txtPrice);
            this.gbBaseInfo.Controls.Add(this.m_lbCost);
            this.gbBaseInfo.Controls.Add(this.m_lbPrice);
            this.gbBaseInfo.Controls.Add(this.txtApplUnitOtherName);
            this.gbBaseInfo.Controls.Add(this.lbApplUnitOtherName);
            this.gbBaseInfo.Controls.Add(this.lbRequire);
            this.gbBaseInfo.Controls.Add(this.chkReservation);
            this.gbBaseInfo.Controls.Add(this.chkBodyCheck);
            this.gbBaseInfo.Controls.Add(this.chkNoFood);
            this.gbBaseInfo.Controls.Add(this.m_lbPriceUnit);
            this.gbBaseInfo.Controls.Add(this.label6);
            this.gbBaseInfo.Controls.Add(this.m_cboSampleType);
            this.gbBaseInfo.Controls.Add(this.chkOutCheckFlag);
            this.gbBaseInfo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbBaseInfo.Location = new System.Drawing.Point(648, 40);
            this.gbBaseInfo.Name = "gbBaseInfo";
            this.gbBaseInfo.Size = new System.Drawing.Size(356, 152);
            this.gbBaseInfo.TabIndex = 51;
            this.gbBaseInfo.TabStop = false;
            this.gbBaseInfo.Text = "其他信息";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(321, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 14);
            this.label5.TabIndex = 204;
            this.label5.Text = "小时";
            // 
            // txtReportHour
            // 
            this.txtReportHour.EnableAutoValidation = true;
            this.txtReportHour.EnableEnterKeyValidate = true;
            this.txtReportHour.EnableEscapeKeyUndo = true;
            this.txtReportHour.EnableLastValidValue = true;
            this.txtReportHour.ErrorProvider = null;
            this.txtReportHour.ErrorProviderMessage = "Invalid value";
            this.txtReportHour.ForceFormatText = true;
            this.txtReportHour.Location = new System.Drawing.Point(264, 100);
            this.txtReportHour.Name = "txtReportHour";
            this.txtReportHour.NumericCharStyle = ((SourceLibrary.Windows.Forms.NumericCharStyle)((SourceLibrary.Windows.Forms.NumericCharStyle.DecimalSeparator | SourceLibrary.Windows.Forms.NumericCharStyle.NegativeSymbol)));
            this.txtReportHour.Size = new System.Drawing.Size(60, 23);
            this.txtReportHour.TabIndex = 203;
            this.txtReportHour.Text = "0";
            this.txtReportHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(184, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 202;
            this.label4.Text = "出报告时间";
            // 
            // m_lbCostUnit
            // 
            this.m_lbCostUnit.AutoSize = true;
            this.m_lbCostUnit.Location = new System.Drawing.Point(324, 76);
            this.m_lbCostUnit.Name = "m_lbCostUnit";
            this.m_lbCostUnit.Size = new System.Drawing.Size(21, 14);
            this.m_lbCostUnit.TabIndex = 42;
            this.m_lbCostUnit.Text = "元";
            // 
            // m_txtCost
            // 
            this.m_txtCost.EnableAutoValidation = true;
            this.m_txtCost.EnableEnterKeyValidate = true;
            this.m_txtCost.EnableEscapeKeyUndo = true;
            this.m_txtCost.EnableLastValidValue = true;
            this.m_txtCost.ErrorProvider = null;
            this.m_txtCost.ErrorProviderMessage = "Invalid value";
            this.m_txtCost.ForceFormatText = true;
            this.m_txtCost.Location = new System.Drawing.Point(264, 76);
            this.m_txtCost.Name = "m_txtCost";
            this.m_txtCost.NumericCharStyle = ((SourceLibrary.Windows.Forms.NumericCharStyle)((SourceLibrary.Windows.Forms.NumericCharStyle.DecimalSeparator | SourceLibrary.Windows.Forms.NumericCharStyle.NegativeSymbol)));
            this.m_txtCost.Size = new System.Drawing.Size(60, 23);
            this.m_txtCost.TabIndex = 200;
            this.m_txtCost.Text = "0";
            this.m_txtCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // m_txtPrice
            // 
            this.m_txtPrice.EnableAutoValidation = true;
            this.m_txtPrice.EnableEnterKeyValidate = true;
            this.m_txtPrice.EnableEscapeKeyUndo = true;
            this.m_txtPrice.EnableLastValidValue = true;
            this.m_txtPrice.ErrorProvider = null;
            this.m_txtPrice.ErrorProviderMessage = "Invalid value";
            this.m_txtPrice.ForceFormatText = true;
            this.m_txtPrice.Location = new System.Drawing.Point(264, 52);
            this.m_txtPrice.MaxLength = 5;
            this.m_txtPrice.Name = "m_txtPrice";
            this.m_txtPrice.NumericCharStyle = ((SourceLibrary.Windows.Forms.NumericCharStyle)((SourceLibrary.Windows.Forms.NumericCharStyle.DecimalSeparator | SourceLibrary.Windows.Forms.NumericCharStyle.NegativeSymbol)));
            this.m_txtPrice.Size = new System.Drawing.Size(60, 23);
            this.m_txtPrice.TabIndex = 40;
            this.m_txtPrice.Text = "0";
            this.m_txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // m_lbCost
            // 
            this.m_lbCost.AutoSize = true;
            this.m_lbCost.Location = new System.Drawing.Point(200, 80);
            this.m_lbCost.Name = "m_lbCost";
            this.m_lbCost.Size = new System.Drawing.Size(63, 14);
            this.m_lbCost.TabIndex = 38;
            this.m_lbCost.Text = "成本价格";
            // 
            // m_lbPrice
            // 
            this.m_lbPrice.AutoSize = true;
            this.m_lbPrice.Location = new System.Drawing.Point(200, 56);
            this.m_lbPrice.Name = "m_lbPrice";
            this.m_lbPrice.Size = new System.Drawing.Size(63, 14);
            this.m_lbPrice.TabIndex = 36;
            this.m_lbPrice.Text = "计费价格";
            // 
            // txtApplUnitOtherName
            // 
            this.txtApplUnitOtherName.Location = new System.Drawing.Point(72, 52);
            this.txtApplUnitOtherName.Name = "txtApplUnitOtherName";
            this.txtApplUnitOtherName.Size = new System.Drawing.Size(116, 23);
            this.txtApplUnitOtherName.TabIndex = 35;
            // 
            // lbApplUnitOtherName
            // 
            this.lbApplUnitOtherName.AutoSize = true;
            this.lbApplUnitOtherName.Location = new System.Drawing.Point(8, 56);
            this.lbApplUnitOtherName.Name = "lbApplUnitOtherName";
            this.lbApplUnitOtherName.Size = new System.Drawing.Size(63, 14);
            this.lbApplUnitOtherName.TabIndex = 34;
            this.lbApplUnitOtherName.Text = "单元别名";
            // 
            // lbRequire
            // 
            this.lbRequire.AutoSize = true;
            this.lbRequire.Location = new System.Drawing.Point(8, 28);
            this.lbRequire.Name = "lbRequire";
            this.lbRequire.Size = new System.Drawing.Size(63, 14);
            this.lbRequire.TabIndex = 33;
            this.lbRequire.Text = "是否需要";
            // 
            // chkReservation
            // 
            this.chkReservation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkReservation.Location = new System.Drawing.Point(204, 24);
            this.chkReservation.Name = "chkReservation";
            this.chkReservation.Size = new System.Drawing.Size(56, 24);
            this.chkReservation.TabIndex = 10;
            this.chkReservation.Text = "预约";
            // 
            // chkBodyCheck
            // 
            this.chkBodyCheck.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkBodyCheck.Location = new System.Drawing.Point(140, 24);
            this.chkBodyCheck.Name = "chkBodyCheck";
            this.chkBodyCheck.Size = new System.Drawing.Size(56, 24);
            this.chkBodyCheck.TabIndex = 9;
            this.chkBodyCheck.Text = "体检";
            // 
            // chkNoFood
            // 
            this.chkNoFood.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkNoFood.Location = new System.Drawing.Point(76, 24);
            this.chkNoFood.Name = "chkNoFood";
            this.chkNoFood.Size = new System.Drawing.Size(56, 24);
            this.chkNoFood.TabIndex = 8;
            this.chkNoFood.Text = "空腹";
            // 
            // m_lbPriceUnit
            // 
            this.m_lbPriceUnit.AutoSize = true;
            this.m_lbPriceUnit.Location = new System.Drawing.Point(324, 52);
            this.m_lbPriceUnit.Name = "m_lbPriceUnit";
            this.m_lbPriceUnit.Size = new System.Drawing.Size(21, 14);
            this.m_lbPriceUnit.TabIndex = 43;
            this.m_lbPriceUnit.Text = "元";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 123;
            this.label6.Text = "样本类型";
            // 
            // chkOutCheckFlag
            // 
            this.chkOutCheckFlag.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkOutCheckFlag.Location = new System.Drawing.Point(1, 103);
            this.chkOutCheckFlag.Name = "chkOutCheckFlag";
            this.chkOutCheckFlag.Size = new System.Drawing.Size(84, 24);
            this.chkOutCheckFlag.TabIndex = 201;
            this.chkOutCheckFlag.Text = "是否外院";
            this.chkOutCheckFlag.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_pnlProperty
            // 
            this.m_pnlProperty.AutoScroll = true;
            this.m_pnlProperty.Controls.Add(this.m_pnlList);
            this.m_pnlProperty.Controls.Add(this.panel1);
            this.m_pnlProperty.Location = new System.Drawing.Point(236, 32);
            this.m_pnlProperty.Name = "m_pnlProperty";
            this.m_pnlProperty.Size = new System.Drawing.Size(772, 528);
            this.m_pnlProperty.TabIndex = 52;
            this.m_pnlProperty.Visible = false;
            // 
            // m_pnlList
            // 
            this.m_pnlList.AutoScroll = true;
            this.m_pnlList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_pnlList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_pnlList.Location = new System.Drawing.Point(0, 0);
            this.m_pnlList.Name = "m_pnlList";
            this.m_pnlList.Size = new System.Drawing.Size(772, 472);
            this.m_pnlList.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_btnClear);
            this.panel1.Controls.Add(this.m_btnCopy);
            this.panel1.Controls.Add(this.m_btnSave);
            this.panel1.Controls.Add(this.m_btnPaste);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 472);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(772, 56);
            this.panel1.TabIndex = 0;
            // 
            // m_btnClear
            // 
            this.m_btnClear.Location = new System.Drawing.Point(292, 16);
            this.m_btnClear.Name = "m_btnClear";
            this.m_btnClear.Size = new System.Drawing.Size(92, 28);
            this.m_btnClear.TabIndex = 3;
            this.m_btnClear.Text = "清空(&R)";
            this.m_btnClear.Click += new System.EventHandler(this.m_btnClear_Click);
            // 
            // m_btnCopy
            // 
            this.m_btnCopy.Location = new System.Drawing.Point(408, 16);
            this.m_btnCopy.Name = "m_btnCopy";
            this.m_btnCopy.Size = new System.Drawing.Size(92, 28);
            this.m_btnCopy.TabIndex = 2;
            this.m_btnCopy.Text = "复制(&C)";
            this.m_btnCopy.Click += new System.EventHandler(this.m_btnCopy_Click);
            // 
            // m_btnSave
            // 
            this.m_btnSave.Location = new System.Drawing.Point(640, 16);
            this.m_btnSave.Name = "m_btnSave";
            this.m_btnSave.Size = new System.Drawing.Size(92, 28);
            this.m_btnSave.TabIndex = 1;
            this.m_btnSave.Text = "保存(&S)";
            this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
            // 
            // m_btnPaste
            // 
            this.m_btnPaste.Location = new System.Drawing.Point(524, 16);
            this.m_btnPaste.Name = "m_btnPaste";
            this.m_btnPaste.Size = new System.Drawing.Size(92, 28);
            this.m_btnPaste.TabIndex = 0;
            this.m_btnPaste.Text = "粘贴(&V)";
            this.m_btnPaste.Click += new System.EventHandler(this.m_btnPaste_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.m_tabCommon);
            this.tabControl1.Controls.Add(this.m_tabProperty);
            this.tabControl1.Location = new System.Drawing.Point(244, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(152, 24);
            this.tabControl1.TabIndex = 55;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // m_tabCommon
            // 
            this.m_tabCommon.Location = new System.Drawing.Point(4, 25);
            this.m_tabCommon.Name = "m_tabCommon";
            this.m_tabCommon.Size = new System.Drawing.Size(144, 0);
            this.m_tabCommon.TabIndex = 0;
            this.m_tabCommon.Text = "一般维护";
            // 
            // m_tabProperty
            // 
            this.m_tabProperty.Location = new System.Drawing.Point(4, 25);
            this.m_tabProperty.Name = "m_tabProperty";
            this.m_tabProperty.Size = new System.Drawing.Size(144, 0);
            this.m_tabProperty.TabIndex = 1;
            this.m_tabProperty.Text = "分单维护";
            this.m_tabProperty.Visible = false;
            // 
            // btnExit0
            // 
            this.btnExit0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit0.Location = new System.Drawing.Point(917, 528);
            this.btnExit0.Name = "btnExit0";
            this.btnExit0.Size = new System.Drawing.Size(75, 23);
            this.btnExit0.TabIndex = 56;
            this.btnExit0.Text = "关闭(&C)";
            this.btnExit0.UseVisualStyleBackColor = true;
            this.btnExit0.Click += new System.EventHandler(this.btnExit0_Click);
            // 
            // txtSamplingInstr
            // 
            this.txtSamplingInstr.Location = new System.Drawing.Point(72, 124);
            this.txtSamplingInstr.Name = "txtSamplingInstr";
            this.txtSamplingInstr.Size = new System.Drawing.Size(252, 23);
            this.txtSamplingInstr.TabIndex = 206;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 205;
            this.label7.Text = "采样说明";
            // 
            // m_cboSampleType
            // 
            this.m_cboSampleType.DisplayMember = "SAMPLE_TYPE_DESC_VCHR";
            this.m_cboSampleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboSampleType.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cboSampleType.Location = new System.Drawing.Point(72, 76);
            this.m_cboSampleType.Name = "m_cboSampleType";
            this.m_cboSampleType.Size = new System.Drawing.Size(116, 22);
            this.m_cboSampleType.TabIndex = 36;
            this.m_cboSampleType.ValueMember = "SAMPLE_TYPE_ID_CHR";
            // 
            // frmApplUserGroup
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1012, 565);
            this.Controls.Add(this.gbBaseInfo);
            this.Controls.Add(this.m_pnlProperty);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnDelCheckGroup);
            this.Controls.Add(this.btnSaveCheckGroup);
            this.Controls.Add(this.btnNewCheckGroup);
            this.Controls.Add(this.tbcCheckGroupDetail);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.trvCheckGroup);
            this.Controls.Add(this.btnExit0);
            this.Name = "frmApplUserGroup";
            this.Text = "用户申请单元信息";
            this.Load += new System.EventHandler(this.frmApplUserGroup_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tbcCheckGroupDetail.ResumeLayout(false);
            this.tpCheckItem.ResumeLayout(false);
            this.tpSubGroup.ResumeLayout(false);
            this.gbBaseInfo.ResumeLayout(false);
            this.gbBaseInfo.PerformLayout();
            this.m_pnlProperty.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

        #region 辅助方法

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.LIS.clsController_AppUserGroup();
        } 
        #endregion

        #region 事件实现

        private void frmApplUserGroup_Load(object sender, System.EventArgs e)
        {
            m_mthSetFormControlCanBeNull(this);
            ((clsController_AppUserGroup)this.objController).GetInitInfo(this);
            cboCheckCategory_SelectedIndexChanged(null, null);

            m_mthInitProperty();
        }

        private void ResetAll()
        {
            this.txtCheckGroupName.Text = "";
            this.txtCheckGroupNo.Text = "";
            this.txtPyCode.Text = "";
            this.txtWbCode.Text = "";
            this.txtAssist01.Text = "";
            this.txtAssist02.Text = "";
            this.txtApplUnitOtherName.Text = "";
            this.m_txtPrice.Text = "";
            this.m_txtCost.Text = "";
            this.trvAddSubGroup.Nodes[0].Nodes.Clear();
            this.trvAddSubGroup.Nodes[1].Nodes.Clear();
            this.chkBodyCheck.Checked = false;
            this.chkNoFood.Checked = false;
            this.chkReservation.Checked = false;
            this.lsvAddCheckItem.Items.Clear();
            this.btnSaveCheckGroup.Text = "保存";
            this.m_cboSampleType.SelectedItem = null;
        }

        private void cboCheckCategory_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //根据检验类别查询所有属于该类别的检验项目
            ((clsController_AppUserGroup)this.objController).getAllCheckItemByCheckCategory(this);
        }

        private void rdbApplUnit_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.rdbApplUnit.Checked)
            {
                this.gbBaseInfo.Enabled = true;
                this.tbcCheckGroupDetail.Controls.Clear();
                this.tbcCheckGroupDetail.Controls.Add(this.tpCheckItem);
            }
        }

        private void rdbSelfDefine_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.rdbSelfDefine.Checked)
            {
                this.gbBaseInfo.Enabled = false;
                this.tbcCheckGroupDetail.Controls.Clear();
                this.tbcCheckGroupDetail.Controls.Add(this.tpSubGroup);
            }
        }

        private void trvCheckGroup_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            //选中某个节点时显示该节点的相关信息
            if (this.trvCheckGroup.SelectedNode != this.trvCheckGroup.Nodes[0] && this.trvCheckGroup.SelectedNode != this.trvCheckGroup.Nodes[1])
            {
                ResetAll();
                btnSaveCheckGroup.Text = "修改";
                this.btnDelCheckItem.Enabled = true;
                ((clsController_AppUserGroup)this.objController).lsvCheckGroupSelectIndexChanged(this, e.Node);
            }
        }

        private void trvSubCheckGroup_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            //选中父节点时其子节点也全部选中
            ((clsController_AppUserGroup)this.objController).checkAllByParentChecked(this, e.Node);
        }

        private void trvAddSubGroup_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            //选中父节点时其子节点也全部选中
            ((clsController_AppUserGroup)this.objController).checkAllByParentChecked(this, e.Node);
        }

        private void btnNewCheck_Click(object sender, System.EventArgs e)
        {
            //添加检验项目
            ((clsController_AppUserGroup)this.objController).m_mthAddCheckItem(this);
        }

        private void btnDelCheckItem_Click(object sender, System.EventArgs e)
        {
            //删除检验项目
            ((clsController_AppUserGroup)this.objController).m_mthDelCheckItem(this);
        }

        private void btnNewSubGroup_Click(object sender, System.EventArgs e)
        {
            //添加子组信息
            ((clsController_AppUserGroup)this.objController).m_lngAddSubGroup(this);
        }

        private void btnDelSubGroup_Click(object sender, System.EventArgs e)
        {
            //删除子组信息
            ((clsController_AppUserGroup)this.objController).m_lngDelSubGroup(this);
        }

        private void btnSaveCheckGroup_Click(object sender, System.EventArgs e)
        {
            long lngRes = 0;
            //保存记录
            if (this.btnSaveCheckGroup.Text == "保存")
            {
                lngRes = ((clsController_AppUserGroup)this.objController).AddNewApplUserGroup(this);
                if (lngRes > 0)
                {
                    MessageBox.Show("记录添加成功！", "", MessageBoxButtons.OK);
                }
                //				((clsController_AppUserGroup)this.objController).refreshAllCheckGroupANDTrvCheckGroup(this);
            }
            else
            {
                //修改记录
                lngRes = ((clsController_AppUserGroup)this.objController).m_lngUpdApplUnitAndApplUserGroup(this);
                if (lngRes > 0)
                {
                    MessageBox.Show("记录修改成功！", "", MessageBoxButtons.OK);
                }
                //				((clsController_AppUserGroup)this.objController).refreshAllCheckGroupANDTrvCheckGroup(this);
            }
            //			if(lngRes > 0)
            //			{
            //				ResetAll();
            //			}
        }

        private void btnNewCheckGroup_Click(object sender, System.EventArgs e)
        {
            //			if(this.rdbApplUnit.Checked)
            //			{
            //				this.trvCheckGroup.SelectedNode = this.trvCheckGroup.Nodes[0];
            //			}
            //			else
            //			{
            //				this.trvCheckGroup.SelectedNode = this.trvCheckGroup.Nodes[1];
            //			}
            //复位
            ResetAll();
        }

        private void trvSubCheckGroup_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            //查询所有的申请单元下的检验项目信息
            ((clsController_AppUserGroup)this.objController).m_lngGetCheckItemByTreeNode(this, e.Node);
        }

        private void txtSummary_Enter(object sender, System.EventArgs e)
        {
            //当备注框获得焦点时，变大以方便输入  xing.chen add
            Point p = this.txtSummary.Parent.PointToScreen(this.txtSummary.Location);
            this.txtSummary.Parent = this;
            this.txtSummary.Location = this.PointToClient(p);

            this.txtSummary.Width = 400;
            this.txtSummary.WordWrap = true;
            this.txtSummary.Multiline = true;
            this.txtSummary.Height = 70;

            this.txtSummary.BringToFront();
            this.txtSummary.Focus();
        }

        private void txtSummary_Leave(object sender, System.EventArgs e)
        {
            //当备注框失去焦点时，恢复原样  xing.chen add
            this.txtSummary.Width = 112;
            this.txtSummary.WordWrap = true;
            this.txtSummary.Multiline = true;
            this.txtSummary.Height = 23;

            Point p = this.PointToScreen(this.txtSummary.Location);
            this.txtSummary.Parent = this.groupBox2;
            this.txtSummary.Location = this.groupBox2.PointToClient(p);
        }

        #endregion

		#region 删除申请单元和用户自定义组

		private void btnDelCheckGroup_Click(object sender, System.EventArgs e)
		{
			((clsController_AppUserGroup)this.objController).m_lngDelApplUnitAndUserGroup(this);
		}

		#endregion

		#region 分单维护
		private clsUnitPropertyRelate_VO[] m_objRelateVOCopyArr;
		private System.Collections.Hashtable m_hasProperty = new Hashtable();
		private clsDomainController_ApplyUnitProperty m_objPropertyDomain = new clsDomainController_ApplyUnitProperty();

		private void m_mthInitProperty()
		{
			clsApplyUnitPropertyDoc objDoc = null;
			long lngRes = new clsDomainController_ApplyUnitProperty().m_lngConstructDoc(out objDoc);
			if(lngRes <=0)
			{
				MessageBox.Show(this,"数据库操作失败,请与管理员联系!");
				return;
			}
			int intCount = 0;

			int intRowSpacing = 10;
			int intXstart = 20;
			int intYstart = 20;
			int intWidth = 508;
			int intHeight = 88;

			foreach(clsApplyUnitProperty objProperty in objDoc.Properties)
			{
				if(objProperty.PropertyVO.m_intINUSE_FLAG_NUM == 1)
				{
					ctlLISApplyUnitProperty ctlProperty = new ctlLISApplyUnitProperty();
					ctlProperty.Width = intWidth;
					ctlProperty.Height = intHeight;
					int intY = intYstart + (intHeight + intRowSpacing)* intCount;
					ctlProperty.Location = new Point(intXstart,intY);
					this.m_pnlList.Controls.Add(ctlProperty);
					this.m_hasProperty.Add(objProperty.PropertyVO.m_strPROPERTY_ID_CHR,ctlProperty);
					intCount++;

					ArrayList arl = new ArrayList();
					foreach(clsPropertyValue objValue in objProperty.Values)
					{
						if(objValue.ValueVO.m_intINUSE_FLAG_NUM == 1)
							arl.Add(objValue.ValueVO);
					}
					ctlProperty.m_mthInitProperty(objProperty.PropertyVO,(clsUnitPropertyValue_VO[])arl.ToArray(typeof(clsUnitPropertyValue_VO)));
				}					
			}

			this.trvCheckGroup.AfterSelect += new TreeViewEventHandler(trvCheckGroup_AfterSelect_Property);
			this.KeyPreview = true;
			this.KeyDown += new KeyEventHandler(m_ContainerForm_KeyDown);
		}

		private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.tabControl1.SelectedTab == this.m_tabCommon)
			{
				this.m_pnlProperty.Visible = false;
			}
			else if(this.tabControl1.SelectedTab == this.m_tabProperty)
			{
				this.m_pnlProperty.Visible = true;
			}
		}
		private void trvCheckGroup_AfterSelect_Property(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			this.m_mthClearProperty();
			if(this.trvCheckGroup.SelectedNode.Tag is clsApplUnit_VO)
			{
				this.m_pnlProperty.Enabled = true;

				clsApplUnit_VO objUnitVO = (clsApplUnit_VO)this.trvCheckGroup.SelectedNode.Tag;
				clsUnitPropertyRelate_VO[] objRelateVOArr = null;
				long lngRes = this.m_objPropertyDomain.m_lngGetRelatesByUnitID(objUnitVO.strApplUnitID,out objRelateVOArr);
				if(lngRes > 0 && objRelateVOArr != null)
				{
					foreach(clsUnitPropertyRelate_VO objRelateVO in objRelateVOArr)
					{
						if(m_hasProperty.ContainsKey(objRelateVO.m_strUNIT_PROPERTY_ID_CHR))
						{
							((ctlLISApplyUnitProperty)m_hasProperty[objRelateVO.m_strUNIT_PROPERTY_ID_CHR]).m_mthAddValue(objRelateVO);
						}
					}
				}
				else if( lngRes <= 0)
				{
					MessageBox.Show(this,"数据库操作失败，请与管理员联系！");
				}
			}
			else
			{
				this.m_pnlProperty.Enabled = false;
			}
		}
		
		
		private void m_btnSave_Click(object sender, System.EventArgs e)
		{
			if(this.trvCheckGroup.SelectedNode.Tag is clsApplUnit_VO)
			{
				clsApplUnit_VO objUnitVO = (clsApplUnit_VO)this.trvCheckGroup.SelectedNode.Tag;
				clsUnitPropertyRelate_VO[] objRelateVOArr = null;
				ArrayList arl = new ArrayList();
				
				foreach(ctlLISApplyUnitProperty ctlProperty in this.m_pnlList.Controls)
				{
					arl.AddRange(ctlProperty.m_objValues);
				}
				foreach(clsUnitPropertyRelate_VO objRelateVO in arl)
				{
					objRelateVO.m_strAPPLY_UNIT_ID_CHR = objUnitVO.strApplUnitID;
				}
				objRelateVOArr = (clsUnitPropertyRelate_VO[])arl.ToArray(typeof(clsUnitPropertyRelate_VO));

				long lngRes = this.m_objPropertyDomain.m_lngSaveRelate(objUnitVO.strApplUnitID,objRelateVOArr);
				if( lngRes <= 0)
				{
					MessageBox.Show(this,"数据保存失败，请与管理员联系！");
				}
			}
		}

		private void m_btnCopy_Click(object sender, System.EventArgs e)
		{
			m_mthCopyRelate();
		}

		private void m_btnPaste_Click(object sender, System.EventArgs e)
		{
			m_mthPasteProperty();
		}

		private void m_btnClear_Click(object sender, System.EventArgs e)
		{
			m_mthClearProperty();
		}
		
		private void m_mthClearProperty()
		{
			foreach(ctlLISApplyUnitProperty ctlProperty in this.m_pnlList.Controls)
			{
				ctlProperty.m_mthClearValues();
			}
		}

		private void m_mthCopyRelate()
		{
			ArrayList arl = new ArrayList();				
			foreach(ctlLISApplyUnitProperty ctlProperty in this.m_pnlList.Controls)
			{
				arl.AddRange(ctlProperty.m_objValues);
			}
			this.m_objRelateVOCopyArr = (clsUnitPropertyRelate_VO[])arl.ToArray(typeof(clsUnitPropertyRelate_VO));
		}
		private void m_mthPasteProperty()
		{
			if(this.m_objRelateVOCopyArr != null)
			{
				m_mthClearProperty();
				foreach(clsUnitPropertyRelate_VO objRelateVO in m_objRelateVOCopyArr)
				{
					if(m_hasProperty.ContainsKey(objRelateVO.m_strUNIT_PROPERTY_ID_CHR))
					{
						((ctlLISApplyUnitProperty)m_hasProperty[objRelateVO.m_strUNIT_PROPERTY_ID_CHR]).m_mthAddValue(objRelateVO);
					}
				}
			}
		}

		private void m_ContainerForm_KeyDown(object sender, KeyEventArgs e)
		{
			if(!this.m_pnlProperty.Visible || !this.m_pnlProperty.Enabled)
				return;

			if(e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
			{
				m_btnSave_Click(null,null);
			}
			if(e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
			{
				m_mthCopyRelate();
			}
			if(e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
			{
				m_mthPasteProperty();
			}
			if(e.KeyCode == Keys.D && e.Modifiers == Keys.Control)
			{
				m_mthClearProperty();
			}
		}
		#endregion

        private void btnExit0_Click(object sender, EventArgs e)
        {
            this.Close();
        }

	}
}
