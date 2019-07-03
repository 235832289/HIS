using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.LIS
{
    public class frmStatBaseInfo : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        clsController_StatBaseInfo m_objController;
        #region 控件
        private System.Windows.Forms.TabControl m_tabStatBaseInfo;
        private System.Windows.Forms.TabPage m_tbpWorkGroup;
        private System.Windows.Forms.TabPage m_tbpStatGroup;
        private System.Windows.Forms.Label m_lbWorkGroupName;
        internal System.Windows.Forms.TextBox m_txtWorkGroupName;
        private System.Windows.Forms.Label m_lbPYCode;
        private System.Windows.Forms.Label m_lbWBCode;
        private System.Windows.Forms.Label m_lbAssist02;
        private System.Windows.Forms.Label m_lbAssist01;
        private System.Windows.Forms.Label m_lbRemark;
        internal System.Windows.Forms.ListView m_lsvWorkGroup;
        private System.Windows.Forms.ColumnHeader m_chWrokGroupName;
        private System.Windows.Forms.ColumnHeader m_chPrintTitle;
        private System.Windows.Forms.ColumnHeader m_chPYCode;
        private System.Windows.Forms.ColumnHeader m_chWBCode;
        private System.Windows.Forms.ColumnHeader m_chAssist01;
        private System.Windows.Forms.ColumnHeader m_chAssist02;
        private System.Windows.Forms.ColumnHeader m_chRemark;
        private System.Windows.Forms.GroupBox m_gpbWorkGroup;
        internal PinkieControls.ButtonXP m_btnNewWorkGroup;
        internal PinkieControls.ButtonXP m_btnDelWorkGroup;
        internal PinkieControls.ButtonXP m_btnSaveWorkGroup;
        internal System.Windows.Forms.TextBox m_txtWrokGroupPrintTitle;
        private System.Windows.Forms.Label m_lbWorkGroupPrintTitle;
        private System.Windows.Forms.Label m_lbStatGroupName;
        internal System.Windows.Forms.TextBox m_txtStatGroupName;
        internal System.Windows.Forms.TextBox m_txtStatGroupPrintTitle;
        private System.Windows.Forms.Label m_lbStatGroupPrintTitle;
        private System.Windows.Forms.Label m_lbWorkCoefficient;
        internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric m_txtWorkCoefficient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label m_lbWorkGroup;
        internal System.Windows.Forms.ComboBox m_cboWorkGroup;
        private System.Windows.Forms.GroupBox m_gpbStatGroup;
        internal System.Windows.Forms.ListView m_lsvApplUnitList;
        internal System.Windows.Forms.ListView m_lsvStatApplUnitList;
        private System.Windows.Forms.Label m_lbApplUnitCategory;
        internal System.Windows.Forms.ComboBox m_cboCheckCategory;
        private System.Windows.Forms.ColumnHeader m_chApplUnitName;
        private System.Windows.Forms.ColumnHeader m_chApplUnitNo;
        private System.Windows.Forms.ColumnHeader m_chStatApplUnitNO;
        private System.Windows.Forms.ColumnHeader m_chStatApplUnitName;
        private System.Windows.Forms.Button m_btnAdd;
        private System.Windows.Forms.Button m_btnRemove;
        internal System.Windows.Forms.TextBox m_txtWorkGroupNO;
        private System.Windows.Forms.Label m_lbWorkGroupNO;
        private System.Windows.Forms.ColumnHeader m_chWorkGroupNO;
        internal System.Windows.Forms.TextBox m_txtWorkGroupWbCode;
        internal System.Windows.Forms.TextBox m_txtWorkGroupPyCode;
        internal System.Windows.Forms.TextBox m_txtWorkGroupAssist01;
        internal System.Windows.Forms.TextBox m_txtWorkGroupAssist02;
        internal System.Windows.Forms.TextBox m_txtWorkGroupSummary;
        internal System.Windows.Forms.TextBox m_txtWorKGroupID;
        internal System.Windows.Forms.TreeView m_trvStatGroup;
        internal System.Windows.Forms.TextBox m_txtStatGroupPyCode;
        internal System.Windows.Forms.TextBox m_txtStatGroupAssist01;
        internal System.Windows.Forms.TextBox m_txtStatGroupAssist02;
        internal System.Windows.Forms.TextBox m_txtStatGroupWbCode;
        internal System.Windows.Forms.TextBox m_txtStatGroupSummary;
        internal PinkieControls.ButtonXP m_btnNewStatGroup;
        internal PinkieControls.ButtonXP m_btnSaveStatGroup;
        internal PinkieControls.ButtonXP m_btnDelStatGroup;
        private PinkieControls.ButtonXP btnExit0;
        private PinkieControls.ButtonXP btnExit1;
        private System.ComponentModel.IContainer components = null;

        public frmStatBaseInfo()
        {
            // 该调用是 Windows 窗体设计器所必需的。
            InitializeComponent();

            // TODO: 在 InitializeComponent 调用后添加任何初始化
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

        #region 设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.m_tabStatBaseInfo = new System.Windows.Forms.TabControl();
            this.m_tbpWorkGroup = new System.Windows.Forms.TabPage();
            this.btnExit0 = new PinkieControls.ButtonXP();
            this.m_btnSaveWorkGroup = new PinkieControls.ButtonXP();
            this.m_btnDelWorkGroup = new PinkieControls.ButtonXP();
            this.m_btnNewWorkGroup = new PinkieControls.ButtonXP();
            this.m_gpbWorkGroup = new System.Windows.Forms.GroupBox();
            this.m_txtWorKGroupID = new System.Windows.Forms.TextBox();
            this.m_txtWorkGroupNO = new System.Windows.Forms.TextBox();
            this.m_lbWorkGroupNO = new System.Windows.Forms.Label();
            this.m_txtWorkGroupName = new System.Windows.Forms.TextBox();
            this.m_lbWorkGroupName = new System.Windows.Forms.Label();
            this.m_txtWorkGroupWbCode = new System.Windows.Forms.TextBox();
            this.m_lbWBCode = new System.Windows.Forms.Label();
            this.m_lbPYCode = new System.Windows.Forms.Label();
            this.m_txtWorkGroupPyCode = new System.Windows.Forms.TextBox();
            this.m_txtWrokGroupPrintTitle = new System.Windows.Forms.TextBox();
            this.m_lbWorkGroupPrintTitle = new System.Windows.Forms.Label();
            this.m_lbAssist01 = new System.Windows.Forms.Label();
            this.m_txtWorkGroupAssist01 = new System.Windows.Forms.TextBox();
            this.m_lbAssist02 = new System.Windows.Forms.Label();
            this.m_txtWorkGroupAssist02 = new System.Windows.Forms.TextBox();
            this.m_lbRemark = new System.Windows.Forms.Label();
            this.m_txtWorkGroupSummary = new System.Windows.Forms.TextBox();
            this.m_lsvWorkGroup = new System.Windows.Forms.ListView();
            this.m_chWorkGroupNO = new System.Windows.Forms.ColumnHeader();
            this.m_chWrokGroupName = new System.Windows.Forms.ColumnHeader();
            this.m_chPrintTitle = new System.Windows.Forms.ColumnHeader();
            this.m_chPYCode = new System.Windows.Forms.ColumnHeader();
            this.m_chWBCode = new System.Windows.Forms.ColumnHeader();
            this.m_chAssist01 = new System.Windows.Forms.ColumnHeader();
            this.m_chAssist02 = new System.Windows.Forms.ColumnHeader();
            this.m_chRemark = new System.Windows.Forms.ColumnHeader();
            this.m_tbpStatGroup = new System.Windows.Forms.TabPage();
            this.btnExit1 = new PinkieControls.ButtonXP();
            this.m_trvStatGroup = new System.Windows.Forms.TreeView();
            this.m_btnSaveStatGroup = new PinkieControls.ButtonXP();
            this.m_btnDelStatGroup = new PinkieControls.ButtonXP();
            this.m_btnNewStatGroup = new PinkieControls.ButtonXP();
            this.m_btnRemove = new System.Windows.Forms.Button();
            this.m_btnAdd = new System.Windows.Forms.Button();
            this.m_cboCheckCategory = new System.Windows.Forms.ComboBox();
            this.m_lbApplUnitCategory = new System.Windows.Forms.Label();
            this.m_lsvStatApplUnitList = new System.Windows.Forms.ListView();
            this.m_chStatApplUnitNO = new System.Windows.Forms.ColumnHeader();
            this.m_chStatApplUnitName = new System.Windows.Forms.ColumnHeader();
            this.m_gpbStatGroup = new System.Windows.Forms.GroupBox();
            this.m_lbWorkCoefficient = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtStatGroupPyCode = new System.Windows.Forms.TextBox();
            this.m_cboWorkGroup = new System.Windows.Forms.ComboBox();
            this.m_txtStatGroupAssist01 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_txtStatGroupAssist02 = new System.Windows.Forms.TextBox();
            this.m_txtStatGroupPrintTitle = new System.Windows.Forms.TextBox();
            this.m_lbStatGroupPrintTitle = new System.Windows.Forms.Label();
            this.m_txtWorkCoefficient = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
            this.m_lbStatGroupName = new System.Windows.Forms.Label();
            this.m_txtStatGroupWbCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtStatGroupName = new System.Windows.Forms.TextBox();
            this.m_txtStatGroupSummary = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_lbWorkGroup = new System.Windows.Forms.Label();
            this.m_lsvApplUnitList = new System.Windows.Forms.ListView();
            this.m_chApplUnitNo = new System.Windows.Forms.ColumnHeader();
            this.m_chApplUnitName = new System.Windows.Forms.ColumnHeader();
            this.m_tabStatBaseInfo.SuspendLayout();
            this.m_tbpWorkGroup.SuspendLayout();
            this.m_gpbWorkGroup.SuspendLayout();
            this.m_tbpStatGroup.SuspendLayout();
            this.m_gpbStatGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_tabStatBaseInfo
            // 
            this.m_tabStatBaseInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_tabStatBaseInfo.Controls.Add(this.m_tbpWorkGroup);
            this.m_tabStatBaseInfo.Controls.Add(this.m_tbpStatGroup);
            this.m_tabStatBaseInfo.Location = new System.Drawing.Point(12, 8);
            this.m_tabStatBaseInfo.Name = "m_tabStatBaseInfo";
            this.m_tabStatBaseInfo.SelectedIndex = 0;
            this.m_tabStatBaseInfo.Size = new System.Drawing.Size(996, 604);
            this.m_tabStatBaseInfo.TabIndex = 0;
            this.m_tabStatBaseInfo.SelectedIndexChanged += new System.EventHandler(this.m_tabStatBaseInfo_SelectedIndexChanged);
            // 
            // m_tbpWorkGroup
            // 
            this.m_tbpWorkGroup.Controls.Add(this.btnExit0);
            this.m_tbpWorkGroup.Controls.Add(this.m_btnSaveWorkGroup);
            this.m_tbpWorkGroup.Controls.Add(this.m_btnDelWorkGroup);
            this.m_tbpWorkGroup.Controls.Add(this.m_btnNewWorkGroup);
            this.m_tbpWorkGroup.Controls.Add(this.m_gpbWorkGroup);
            this.m_tbpWorkGroup.Controls.Add(this.m_lsvWorkGroup);
            this.m_tbpWorkGroup.Location = new System.Drawing.Point(4, 23);
            this.m_tbpWorkGroup.Name = "m_tbpWorkGroup";
            this.m_tbpWorkGroup.Size = new System.Drawing.Size(988, 577);
            this.m_tbpWorkGroup.TabIndex = 0;
            this.m_tbpWorkGroup.Text = "工作组维护";
            // 
            // btnExit0
            // 
            this.btnExit0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnExit0.DefaultScheme = true;
            this.btnExit0.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExit0.Hint = "";
            this.btnExit0.Location = new System.Drawing.Point(884, 524);
            this.btnExit0.Name = "btnExit0";
            this.btnExit0.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnExit0.Size = new System.Drawing.Size(92, 32);
            this.btnExit0.TabIndex = 48;
            this.btnExit0.Text = "关闭(&C)";
            this.btnExit0.Click += new System.EventHandler(this.btnExit0_Click);
            // 
            // m_btnSaveWorkGroup
            // 
            this.m_btnSaveWorkGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnSaveWorkGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_btnSaveWorkGroup.DefaultScheme = true;
            this.m_btnSaveWorkGroup.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnSaveWorkGroup.Hint = "";
            this.m_btnSaveWorkGroup.Location = new System.Drawing.Point(676, 524);
            this.m_btnSaveWorkGroup.Name = "m_btnSaveWorkGroup";
            this.m_btnSaveWorkGroup.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnSaveWorkGroup.Size = new System.Drawing.Size(92, 32);
            this.m_btnSaveWorkGroup.TabIndex = 47;
            this.m_btnSaveWorkGroup.Text = "保存";
            this.m_btnSaveWorkGroup.Click += new System.EventHandler(this.m_btnSaveWorkGroup_Click);
            // 
            // m_btnDelWorkGroup
            // 
            this.m_btnDelWorkGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnDelWorkGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_btnDelWorkGroup.DefaultScheme = true;
            this.m_btnDelWorkGroup.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnDelWorkGroup.Hint = "";
            this.m_btnDelWorkGroup.Location = new System.Drawing.Point(780, 524);
            this.m_btnDelWorkGroup.Name = "m_btnDelWorkGroup";
            this.m_btnDelWorkGroup.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnDelWorkGroup.Size = new System.Drawing.Size(92, 32);
            this.m_btnDelWorkGroup.TabIndex = 46;
            this.m_btnDelWorkGroup.Text = "删除";
            this.m_btnDelWorkGroup.Click += new System.EventHandler(this.m_btnDelWorkGroup_Click);
            // 
            // m_btnNewWorkGroup
            // 
            this.m_btnNewWorkGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnNewWorkGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_btnNewWorkGroup.DefaultScheme = true;
            this.m_btnNewWorkGroup.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnNewWorkGroup.Hint = "";
            this.m_btnNewWorkGroup.Location = new System.Drawing.Point(572, 524);
            this.m_btnNewWorkGroup.Name = "m_btnNewWorkGroup";
            this.m_btnNewWorkGroup.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnNewWorkGroup.Size = new System.Drawing.Size(92, 32);
            this.m_btnNewWorkGroup.TabIndex = 45;
            this.m_btnNewWorkGroup.Text = "新增";
            this.m_btnNewWorkGroup.Click += new System.EventHandler(this.m_btnNewWorkGroup_Click);
            // 
            // m_gpbWorkGroup
            // 
            this.m_gpbWorkGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_gpbWorkGroup.Controls.Add(this.m_txtWorKGroupID);
            this.m_gpbWorkGroup.Controls.Add(this.m_txtWorkGroupNO);
            this.m_gpbWorkGroup.Controls.Add(this.m_lbWorkGroupNO);
            this.m_gpbWorkGroup.Controls.Add(this.m_txtWorkGroupName);
            this.m_gpbWorkGroup.Controls.Add(this.m_lbWorkGroupName);
            this.m_gpbWorkGroup.Controls.Add(this.m_txtWorkGroupWbCode);
            this.m_gpbWorkGroup.Controls.Add(this.m_lbWBCode);
            this.m_gpbWorkGroup.Controls.Add(this.m_lbPYCode);
            this.m_gpbWorkGroup.Controls.Add(this.m_txtWorkGroupPyCode);
            this.m_gpbWorkGroup.Controls.Add(this.m_txtWrokGroupPrintTitle);
            this.m_gpbWorkGroup.Controls.Add(this.m_lbWorkGroupPrintTitle);
            this.m_gpbWorkGroup.Controls.Add(this.m_lbAssist01);
            this.m_gpbWorkGroup.Controls.Add(this.m_txtWorkGroupAssist01);
            this.m_gpbWorkGroup.Controls.Add(this.m_lbAssist02);
            this.m_gpbWorkGroup.Controls.Add(this.m_txtWorkGroupAssist02);
            this.m_gpbWorkGroup.Controls.Add(this.m_lbRemark);
            this.m_gpbWorkGroup.Controls.Add(this.m_txtWorkGroupSummary);
            this.m_gpbWorkGroup.Location = new System.Drawing.Point(12, 4);
            this.m_gpbWorkGroup.Name = "m_gpbWorkGroup";
            this.m_gpbWorkGroup.Size = new System.Drawing.Size(960, 100);
            this.m_gpbWorkGroup.TabIndex = 44;
            this.m_gpbWorkGroup.TabStop = false;
            // 
            // m_txtWorKGroupID
            // 
            this.m_txtWorKGroupID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtWorKGroupID.Location = new System.Drawing.Point(708, 16);
            this.m_txtWorKGroupID.Name = "m_txtWorKGroupID";
            this.m_txtWorKGroupID.ReadOnly = true;
            this.m_txtWorKGroupID.Size = new System.Drawing.Size(100, 23);
            this.m_txtWorKGroupID.TabIndex = 45;
            this.m_txtWorKGroupID.Visible = false;
            // 
            // m_txtWorkGroupNO
            // 
            this.m_txtWorkGroupNO.Location = new System.Drawing.Point(96, 40);
            this.m_txtWorkGroupNO.Name = "m_txtWorkGroupNO";
            this.m_txtWorkGroupNO.Size = new System.Drawing.Size(140, 23);
            this.m_txtWorkGroupNO.TabIndex = 44;
            // 
            // m_lbWorkGroupNO
            // 
            this.m_lbWorkGroupNO.AutoSize = true;
            this.m_lbWorkGroupNO.Location = new System.Drawing.Point(16, 44);
            this.m_lbWorkGroupNO.Name = "m_lbWorkGroupNO";
            this.m_lbWorkGroupNO.Size = new System.Drawing.Size(77, 14);
            this.m_lbWorkGroupNO.TabIndex = 43;
            this.m_lbWorkGroupNO.Text = "工作组编号";
            // 
            // m_txtWorkGroupName
            // 
            this.m_txtWorkGroupName.Location = new System.Drawing.Point(96, 16);
            this.m_txtWorkGroupName.Name = "m_txtWorkGroupName";
            this.m_txtWorkGroupName.Size = new System.Drawing.Size(140, 23);
            this.m_txtWorkGroupName.TabIndex = 1;
            // 
            // m_lbWorkGroupName
            // 
            this.m_lbWorkGroupName.AutoSize = true;
            this.m_lbWorkGroupName.Location = new System.Drawing.Point(16, 20);
            this.m_lbWorkGroupName.Name = "m_lbWorkGroupName";
            this.m_lbWorkGroupName.Size = new System.Drawing.Size(77, 14);
            this.m_lbWorkGroupName.TabIndex = 0;
            this.m_lbWorkGroupName.Text = "工作组名称";
            // 
            // m_txtWorkGroupWbCode
            // 
            this.m_txtWorkGroupWbCode.Location = new System.Drawing.Point(560, 16);
            this.m_txtWorkGroupWbCode.MaxLength = 10;
            this.m_txtWorkGroupWbCode.Name = "m_txtWorkGroupWbCode";
            this.m_txtWorkGroupWbCode.Size = new System.Drawing.Size(140, 23);
            this.m_txtWorkGroupWbCode.TabIndex = 33;
            // 
            // m_lbWBCode
            // 
            this.m_lbWBCode.AutoSize = true;
            this.m_lbWBCode.Location = new System.Drawing.Point(480, 20);
            this.m_lbWBCode.Name = "m_lbWBCode";
            this.m_lbWBCode.Size = new System.Drawing.Size(77, 14);
            this.m_lbWBCode.TabIndex = 32;
            this.m_lbWBCode.Text = "五笔助记符";
            // 
            // m_lbPYCode
            // 
            this.m_lbPYCode.AutoSize = true;
            this.m_lbPYCode.Location = new System.Drawing.Point(248, 20);
            this.m_lbPYCode.Name = "m_lbPYCode";
            this.m_lbPYCode.Size = new System.Drawing.Size(77, 14);
            this.m_lbPYCode.TabIndex = 31;
            this.m_lbPYCode.Text = "拼音助记符";
            // 
            // m_txtWorkGroupPyCode
            // 
            this.m_txtWorkGroupPyCode.Location = new System.Drawing.Point(328, 16);
            this.m_txtWorkGroupPyCode.MaxLength = 10;
            this.m_txtWorkGroupPyCode.Name = "m_txtWorkGroupPyCode";
            this.m_txtWorkGroupPyCode.Size = new System.Drawing.Size(140, 23);
            this.m_txtWorkGroupPyCode.TabIndex = 30;
            // 
            // m_txtWrokGroupPrintTitle
            // 
            this.m_txtWrokGroupPrintTitle.Location = new System.Drawing.Point(96, 64);
            this.m_txtWrokGroupPrintTitle.Name = "m_txtWrokGroupPrintTitle";
            this.m_txtWrokGroupPrintTitle.Size = new System.Drawing.Size(140, 23);
            this.m_txtWrokGroupPrintTitle.TabIndex = 3;
            // 
            // m_lbWorkGroupPrintTitle
            // 
            this.m_lbWorkGroupPrintTitle.AutoSize = true;
            this.m_lbWorkGroupPrintTitle.Location = new System.Drawing.Point(16, 68);
            this.m_lbWorkGroupPrintTitle.Name = "m_lbWorkGroupPrintTitle";
            this.m_lbWorkGroupPrintTitle.Size = new System.Drawing.Size(63, 14);
            this.m_lbWorkGroupPrintTitle.TabIndex = 2;
            this.m_lbWorkGroupPrintTitle.Text = "打印标题";
            // 
            // m_lbAssist01
            // 
            this.m_lbAssist01.AutoSize = true;
            this.m_lbAssist01.Location = new System.Drawing.Point(248, 44);
            this.m_lbAssist01.Name = "m_lbAssist01";
            this.m_lbAssist01.Size = new System.Drawing.Size(77, 14);
            this.m_lbAssist01.TabIndex = 37;
            this.m_lbAssist01.Text = "第一助记码";
            // 
            // m_txtWorkGroupAssist01
            // 
            this.m_txtWorkGroupAssist01.Location = new System.Drawing.Point(328, 40);
            this.m_txtWorkGroupAssist01.Name = "m_txtWorkGroupAssist01";
            this.m_txtWorkGroupAssist01.Size = new System.Drawing.Size(140, 23);
            this.m_txtWorkGroupAssist01.TabIndex = 38;
            // 
            // m_lbAssist02
            // 
            this.m_lbAssist02.AutoSize = true;
            this.m_lbAssist02.Location = new System.Drawing.Point(480, 44);
            this.m_lbAssist02.Name = "m_lbAssist02";
            this.m_lbAssist02.Size = new System.Drawing.Size(77, 14);
            this.m_lbAssist02.TabIndex = 39;
            this.m_lbAssist02.Text = "第二助记码";
            // 
            // m_txtWorkGroupAssist02
            // 
            this.m_txtWorkGroupAssist02.Location = new System.Drawing.Point(560, 40);
            this.m_txtWorkGroupAssist02.Name = "m_txtWorkGroupAssist02";
            this.m_txtWorkGroupAssist02.Size = new System.Drawing.Size(140, 23);
            this.m_txtWorkGroupAssist02.TabIndex = 40;
            // 
            // m_lbRemark
            // 
            this.m_lbRemark.AutoSize = true;
            this.m_lbRemark.Location = new System.Drawing.Point(248, 68);
            this.m_lbRemark.Name = "m_lbRemark";
            this.m_lbRemark.Size = new System.Drawing.Size(35, 14);
            this.m_lbRemark.TabIndex = 41;
            this.m_lbRemark.Text = "备注";
            // 
            // m_txtWorkGroupSummary
            // 
            this.m_txtWorkGroupSummary.Location = new System.Drawing.Point(328, 64);
            this.m_txtWorkGroupSummary.Name = "m_txtWorkGroupSummary";
            this.m_txtWorkGroupSummary.Size = new System.Drawing.Size(372, 23);
            this.m_txtWorkGroupSummary.TabIndex = 42;
            // 
            // m_lsvWorkGroup
            // 
            this.m_lsvWorkGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lsvWorkGroup.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_chWorkGroupNO,
            this.m_chWrokGroupName,
            this.m_chPrintTitle,
            this.m_chPYCode,
            this.m_chWBCode,
            this.m_chAssist01,
            this.m_chAssist02,
            this.m_chRemark});
            this.m_lsvWorkGroup.FullRowSelect = true;
            this.m_lsvWorkGroup.GridLines = true;
            this.m_lsvWorkGroup.HideSelection = false;
            this.m_lsvWorkGroup.Location = new System.Drawing.Point(12, 108);
            this.m_lsvWorkGroup.MultiSelect = false;
            this.m_lsvWorkGroup.Name = "m_lsvWorkGroup";
            this.m_lsvWorkGroup.Size = new System.Drawing.Size(960, 400);
            this.m_lsvWorkGroup.TabIndex = 43;
            this.m_lsvWorkGroup.UseCompatibleStateImageBehavior = false;
            this.m_lsvWorkGroup.View = System.Windows.Forms.View.Details;
            this.m_lsvWorkGroup.SelectedIndexChanged += new System.EventHandler(this.m_lsvWorkGroup_SelectedIndexChanged);
            // 
            // m_chWorkGroupNO
            // 
            this.m_chWorkGroupNO.Text = "工作组编号";
            this.m_chWorkGroupNO.Width = 100;
            // 
            // m_chWrokGroupName
            // 
            this.m_chWrokGroupName.Text = "工作组名称";
            this.m_chWrokGroupName.Width = 120;
            // 
            // m_chPrintTitle
            // 
            this.m_chPrintTitle.Text = "打印标题";
            this.m_chPrintTitle.Width = 100;
            // 
            // m_chPYCode
            // 
            this.m_chPYCode.Text = "拼音助记符";
            this.m_chPYCode.Width = 100;
            // 
            // m_chWBCode
            // 
            this.m_chWBCode.Text = "五笔助记符";
            this.m_chWBCode.Width = 100;
            // 
            // m_chAssist01
            // 
            this.m_chAssist01.Text = "第一助记码";
            this.m_chAssist01.Width = 100;
            // 
            // m_chAssist02
            // 
            this.m_chAssist02.Text = "第二助记码";
            this.m_chAssist02.Width = 100;
            // 
            // m_chRemark
            // 
            this.m_chRemark.Text = "备注";
            this.m_chRemark.Width = 220;
            // 
            // m_tbpStatGroup
            // 
            this.m_tbpStatGroup.Controls.Add(this.btnExit1);
            this.m_tbpStatGroup.Controls.Add(this.m_trvStatGroup);
            this.m_tbpStatGroup.Controls.Add(this.m_btnSaveStatGroup);
            this.m_tbpStatGroup.Controls.Add(this.m_btnDelStatGroup);
            this.m_tbpStatGroup.Controls.Add(this.m_btnNewStatGroup);
            this.m_tbpStatGroup.Controls.Add(this.m_btnRemove);
            this.m_tbpStatGroup.Controls.Add(this.m_btnAdd);
            this.m_tbpStatGroup.Controls.Add(this.m_cboCheckCategory);
            this.m_tbpStatGroup.Controls.Add(this.m_lbApplUnitCategory);
            this.m_tbpStatGroup.Controls.Add(this.m_lsvStatApplUnitList);
            this.m_tbpStatGroup.Controls.Add(this.m_gpbStatGroup);
            this.m_tbpStatGroup.Controls.Add(this.m_lsvApplUnitList);
            this.m_tbpStatGroup.Location = new System.Drawing.Point(4, 23);
            this.m_tbpStatGroup.Name = "m_tbpStatGroup";
            this.m_tbpStatGroup.Size = new System.Drawing.Size(988, 577);
            this.m_tbpStatGroup.TabIndex = 1;
            this.m_tbpStatGroup.Text = "项目统计组";
            // 
            // btnExit1
            // 
            this.btnExit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnExit1.DefaultScheme = true;
            this.btnExit1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExit1.Hint = "";
            this.btnExit1.Location = new System.Drawing.Point(884, 524);
            this.btnExit1.Name = "btnExit1";
            this.btnExit1.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnExit1.Size = new System.Drawing.Size(92, 32);
            this.btnExit1.TabIndex = 64;
            this.btnExit1.Text = "关闭(&C)";
            this.btnExit1.Click += new System.EventHandler(this.btnExit1_Click);
            // 
            // m_trvStatGroup
            // 
            this.m_trvStatGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_trvStatGroup.FullRowSelect = true;
            this.m_trvStatGroup.HideSelection = false;
            this.m_trvStatGroup.Location = new System.Drawing.Point(8, 12);
            this.m_trvStatGroup.Name = "m_trvStatGroup";
            this.m_trvStatGroup.Size = new System.Drawing.Size(216, 500);
            this.m_trvStatGroup.TabIndex = 63;
            this.m_trvStatGroup.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_trvStatGroup_AfterSelect);
            // 
            // m_btnSaveStatGroup
            // 
            this.m_btnSaveStatGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnSaveStatGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_btnSaveStatGroup.DefaultScheme = true;
            this.m_btnSaveStatGroup.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnSaveStatGroup.Hint = "";
            this.m_btnSaveStatGroup.Location = new System.Drawing.Point(677, 524);
            this.m_btnSaveStatGroup.Name = "m_btnSaveStatGroup";
            this.m_btnSaveStatGroup.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnSaveStatGroup.Size = new System.Drawing.Size(92, 32);
            this.m_btnSaveStatGroup.TabIndex = 62;
            this.m_btnSaveStatGroup.Text = "保存";
            this.m_btnSaveStatGroup.Click += new System.EventHandler(this.m_btnSaveStatGroup_Click);
            // 
            // m_btnDelStatGroup
            // 
            this.m_btnDelStatGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnDelStatGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_btnDelStatGroup.DefaultScheme = true;
            this.m_btnDelStatGroup.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnDelStatGroup.Hint = "";
            this.m_btnDelStatGroup.Location = new System.Drawing.Point(781, 524);
            this.m_btnDelStatGroup.Name = "m_btnDelStatGroup";
            this.m_btnDelStatGroup.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnDelStatGroup.Size = new System.Drawing.Size(92, 32);
            this.m_btnDelStatGroup.TabIndex = 61;
            this.m_btnDelStatGroup.Text = "删除";
            this.m_btnDelStatGroup.Click += new System.EventHandler(this.m_btnDelStatGroup_Click);
            // 
            // m_btnNewStatGroup
            // 
            this.m_btnNewStatGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnNewStatGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_btnNewStatGroup.DefaultScheme = true;
            this.m_btnNewStatGroup.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnNewStatGroup.Hint = "";
            this.m_btnNewStatGroup.Location = new System.Drawing.Point(573, 524);
            this.m_btnNewStatGroup.Name = "m_btnNewStatGroup";
            this.m_btnNewStatGroup.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnNewStatGroup.Size = new System.Drawing.Size(92, 32);
            this.m_btnNewStatGroup.TabIndex = 60;
            this.m_btnNewStatGroup.Text = "新增";
            this.m_btnNewStatGroup.Click += new System.EventHandler(this.m_btnNewStatGroup_Click);
            // 
            // m_btnRemove
            // 
            this.m_btnRemove.Location = new System.Drawing.Point(584, 336);
            this.m_btnRemove.Name = "m_btnRemove";
            this.m_btnRemove.Size = new System.Drawing.Size(40, 23);
            this.m_btnRemove.TabIndex = 59;
            this.m_btnRemove.Text = "<<";
            this.m_btnRemove.Click += new System.EventHandler(this.m_btnRemove_Click);
            // 
            // m_btnAdd
            // 
            this.m_btnAdd.Location = new System.Drawing.Point(584, 304);
            this.m_btnAdd.Name = "m_btnAdd";
            this.m_btnAdd.Size = new System.Drawing.Size(40, 23);
            this.m_btnAdd.TabIndex = 58;
            this.m_btnAdd.Text = ">>";
            this.m_btnAdd.Click += new System.EventHandler(this.m_btnAdd_Click);
            // 
            // m_cboCheckCategory
            // 
            this.m_cboCheckCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboCheckCategory.Location = new System.Drawing.Point(328, 116);
            this.m_cboCheckCategory.Name = "m_cboCheckCategory";
            this.m_cboCheckCategory.Size = new System.Drawing.Size(116, 22);
            this.m_cboCheckCategory.TabIndex = 57;
            this.m_cboCheckCategory.SelectedIndexChanged += new System.EventHandler(this.m_cboCheckCategory_SelectedIndexChanged);
            // 
            // m_lbApplUnitCategory
            // 
            this.m_lbApplUnitCategory.AutoSize = true;
            this.m_lbApplUnitCategory.Location = new System.Drawing.Point(236, 120);
            this.m_lbApplUnitCategory.Name = "m_lbApplUnitCategory";
            this.m_lbApplUnitCategory.Size = new System.Drawing.Size(91, 14);
            this.m_lbApplUnitCategory.TabIndex = 56;
            this.m_lbApplUnitCategory.Text = "申请单元类别";
            // 
            // m_lsvStatApplUnitList
            // 
            this.m_lsvStatApplUnitList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lsvStatApplUnitList.CheckBoxes = true;
            this.m_lsvStatApplUnitList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_chStatApplUnitNO,
            this.m_chStatApplUnitName});
            this.m_lsvStatApplUnitList.FullRowSelect = true;
            this.m_lsvStatApplUnitList.GridLines = true;
            this.m_lsvStatApplUnitList.HideSelection = false;
            this.m_lsvStatApplUnitList.Location = new System.Drawing.Point(636, 144);
            this.m_lsvStatApplUnitList.Name = "m_lsvStatApplUnitList";
            this.m_lsvStatApplUnitList.Size = new System.Drawing.Size(336, 368);
            this.m_lsvStatApplUnitList.TabIndex = 55;
            this.m_lsvStatApplUnitList.UseCompatibleStateImageBehavior = false;
            this.m_lsvStatApplUnitList.View = System.Windows.Forms.View.Details;
            // 
            // m_chStatApplUnitNO
            // 
            this.m_chStatApplUnitNO.Text = "申请单元编号";
            this.m_chStatApplUnitNO.Width = 100;
            // 
            // m_chStatApplUnitName
            // 
            this.m_chStatApplUnitName.Text = "申请单元";
            this.m_chStatApplUnitName.Width = 212;
            // 
            // m_gpbStatGroup
            // 
            this.m_gpbStatGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_gpbStatGroup.Controls.Add(this.m_lbWorkCoefficient);
            this.m_gpbStatGroup.Controls.Add(this.label2);
            this.m_gpbStatGroup.Controls.Add(this.m_txtStatGroupPyCode);
            this.m_gpbStatGroup.Controls.Add(this.m_cboWorkGroup);
            this.m_gpbStatGroup.Controls.Add(this.m_txtStatGroupAssist01);
            this.m_gpbStatGroup.Controls.Add(this.label4);
            this.m_gpbStatGroup.Controls.Add(this.m_txtStatGroupAssist02);
            this.m_gpbStatGroup.Controls.Add(this.m_txtStatGroupPrintTitle);
            this.m_gpbStatGroup.Controls.Add(this.m_lbStatGroupPrintTitle);
            this.m_gpbStatGroup.Controls.Add(this.m_txtWorkCoefficient);
            this.m_gpbStatGroup.Controls.Add(this.m_lbStatGroupName);
            this.m_gpbStatGroup.Controls.Add(this.m_txtStatGroupWbCode);
            this.m_gpbStatGroup.Controls.Add(this.label1);
            this.m_gpbStatGroup.Controls.Add(this.label3);
            this.m_gpbStatGroup.Controls.Add(this.m_txtStatGroupName);
            this.m_gpbStatGroup.Controls.Add(this.m_txtStatGroupSummary);
            this.m_gpbStatGroup.Controls.Add(this.label5);
            this.m_gpbStatGroup.Controls.Add(this.m_lbWorkGroup);
            this.m_gpbStatGroup.Location = new System.Drawing.Point(236, 4);
            this.m_gpbStatGroup.Name = "m_gpbStatGroup";
            this.m_gpbStatGroup.Size = new System.Drawing.Size(740, 104);
            this.m_gpbStatGroup.TabIndex = 54;
            this.m_gpbStatGroup.TabStop = false;
            // 
            // m_lbWorkCoefficient
            // 
            this.m_lbWorkCoefficient.AutoSize = true;
            this.m_lbWorkCoefficient.Location = new System.Drawing.Point(212, 48);
            this.m_lbWorkCoefficient.Name = "m_lbWorkCoefficient";
            this.m_lbWorkCoefficient.Size = new System.Drawing.Size(77, 14);
            this.m_lbWorkCoefficient.TabIndex = 6;
            this.m_lbWorkCoefficient.Text = "工作量系数";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(384, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 42;
            this.label2.Text = "拼音助记符";
            // 
            // m_txtStatGroupPyCode
            // 
            this.m_txtStatGroupPyCode.Location = new System.Drawing.Point(464, 20);
            this.m_txtStatGroupPyCode.MaxLength = 10;
            this.m_txtStatGroupPyCode.Name = "m_txtStatGroupPyCode";
            this.m_txtStatGroupPyCode.Size = new System.Drawing.Size(92, 23);
            this.m_txtStatGroupPyCode.TabIndex = 41;
            // 
            // m_cboWorkGroup
            // 
            this.m_cboWorkGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboWorkGroup.Location = new System.Drawing.Point(92, 44);
            this.m_cboWorkGroup.Name = "m_cboWorkGroup";
            this.m_cboWorkGroup.Size = new System.Drawing.Size(112, 22);
            this.m_cboWorkGroup.TabIndex = 53;
            // 
            // m_txtStatGroupAssist01
            // 
            this.m_txtStatGroupAssist01.Location = new System.Drawing.Point(464, 44);
            this.m_txtStatGroupAssist01.Name = "m_txtStatGroupAssist01";
            this.m_txtStatGroupAssist01.Size = new System.Drawing.Size(92, 23);
            this.m_txtStatGroupAssist01.TabIndex = 46;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(560, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 47;
            this.label4.Text = "第二助记码";
            // 
            // m_txtStatGroupAssist02
            // 
            this.m_txtStatGroupAssist02.Location = new System.Drawing.Point(640, 44);
            this.m_txtStatGroupAssist02.Name = "m_txtStatGroupAssist02";
            this.m_txtStatGroupAssist02.Size = new System.Drawing.Size(92, 23);
            this.m_txtStatGroupAssist02.TabIndex = 48;
            // 
            // m_txtStatGroupPrintTitle
            // 
            this.m_txtStatGroupPrintTitle.Location = new System.Drawing.Point(288, 20);
            this.m_txtStatGroupPrintTitle.Name = "m_txtStatGroupPrintTitle";
            this.m_txtStatGroupPrintTitle.Size = new System.Drawing.Size(92, 23);
            this.m_txtStatGroupPrintTitle.TabIndex = 5;
            // 
            // m_lbStatGroupPrintTitle
            // 
            this.m_lbStatGroupPrintTitle.AutoSize = true;
            this.m_lbStatGroupPrintTitle.Location = new System.Drawing.Point(212, 24);
            this.m_lbStatGroupPrintTitle.Name = "m_lbStatGroupPrintTitle";
            this.m_lbStatGroupPrintTitle.Size = new System.Drawing.Size(63, 14);
            this.m_lbStatGroupPrintTitle.TabIndex = 4;
            this.m_lbStatGroupPrintTitle.Text = "打印标题";
            // 
            // m_txtWorkCoefficient
            // 
            this.m_txtWorkCoefficient.EnableAutoValidation = true;
            this.m_txtWorkCoefficient.EnableEnterKeyValidate = true;
            this.m_txtWorkCoefficient.EnableEscapeKeyUndo = true;
            this.m_txtWorkCoefficient.EnableLastValidValue = true;
            this.m_txtWorkCoefficient.ErrorProvider = null;
            this.m_txtWorkCoefficient.ErrorProviderMessage = "Invalid value";
            this.m_txtWorkCoefficient.ForceFormatText = true;
            this.m_txtWorkCoefficient.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.m_txtWorkCoefficient.Location = new System.Drawing.Point(288, 44);
            this.m_txtWorkCoefficient.Name = "m_txtWorkCoefficient";
            this.m_txtWorkCoefficient.NumericCharStyle = ((SourceLibrary.Windows.Forms.NumericCharStyle)((SourceLibrary.Windows.Forms.NumericCharStyle.DecimalSeparator | SourceLibrary.Windows.Forms.NumericCharStyle.NegativeSymbol)));
            this.m_txtWorkCoefficient.Size = new System.Drawing.Size(92, 23);
            this.m_txtWorkCoefficient.TabIndex = 7;
            this.m_txtWorkCoefficient.Text = "0";
            this.m_txtWorkCoefficient.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // m_lbStatGroupName
            // 
            this.m_lbStatGroupName.AutoSize = true;
            this.m_lbStatGroupName.Location = new System.Drawing.Point(12, 24);
            this.m_lbStatGroupName.Name = "m_lbStatGroupName";
            this.m_lbStatGroupName.Size = new System.Drawing.Size(77, 14);
            this.m_lbStatGroupName.TabIndex = 0;
            this.m_lbStatGroupName.Text = "统计组名称";
            // 
            // m_txtStatGroupWbCode
            // 
            this.m_txtStatGroupWbCode.Location = new System.Drawing.Point(640, 20);
            this.m_txtStatGroupWbCode.MaxLength = 10;
            this.m_txtStatGroupWbCode.Name = "m_txtStatGroupWbCode";
            this.m_txtStatGroupWbCode.Size = new System.Drawing.Size(92, 23);
            this.m_txtStatGroupWbCode.TabIndex = 44;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(560, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 43;
            this.label1.Text = "五笔助记符";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(384, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 45;
            this.label3.Text = "第一助记码";
            // 
            // m_txtStatGroupName
            // 
            this.m_txtStatGroupName.Location = new System.Drawing.Point(92, 20);
            this.m_txtStatGroupName.Name = "m_txtStatGroupName";
            this.m_txtStatGroupName.Size = new System.Drawing.Size(112, 23);
            this.m_txtStatGroupName.TabIndex = 1;
            // 
            // m_txtStatGroupSummary
            // 
            this.m_txtStatGroupSummary.Location = new System.Drawing.Point(92, 68);
            this.m_txtStatGroupSummary.Name = "m_txtStatGroupSummary";
            this.m_txtStatGroupSummary.Size = new System.Drawing.Size(640, 23);
            this.m_txtStatGroupSummary.TabIndex = 50;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 14);
            this.label5.TabIndex = 49;
            this.label5.Text = "备注";
            // 
            // m_lbWorkGroup
            // 
            this.m_lbWorkGroup.AutoSize = true;
            this.m_lbWorkGroup.Location = new System.Drawing.Point(12, 48);
            this.m_lbWorkGroup.Name = "m_lbWorkGroup";
            this.m_lbWorkGroup.Size = new System.Drawing.Size(49, 14);
            this.m_lbWorkGroup.TabIndex = 52;
            this.m_lbWorkGroup.Text = "工作组";
            // 
            // m_lsvApplUnitList
            // 
            this.m_lsvApplUnitList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lsvApplUnitList.CheckBoxes = true;
            this.m_lsvApplUnitList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_chApplUnitNo,
            this.m_chApplUnitName});
            this.m_lsvApplUnitList.FullRowSelect = true;
            this.m_lsvApplUnitList.GridLines = true;
            this.m_lsvApplUnitList.HideSelection = false;
            this.m_lsvApplUnitList.Location = new System.Drawing.Point(236, 144);
            this.m_lsvApplUnitList.Name = "m_lsvApplUnitList";
            this.m_lsvApplUnitList.Size = new System.Drawing.Size(336, 368);
            this.m_lsvApplUnitList.TabIndex = 51;
            this.m_lsvApplUnitList.UseCompatibleStateImageBehavior = false;
            this.m_lsvApplUnitList.View = System.Windows.Forms.View.Details;
            // 
            // m_chApplUnitNo
            // 
            this.m_chApplUnitNo.Text = "申请单元编号";
            this.m_chApplUnitNo.Width = 100;
            // 
            // m_chApplUnitName
            // 
            this.m_chApplUnitName.Text = "申请单元";
            this.m_chApplUnitName.Width = 212;
            // 
            // frmStatBaseInfo
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(1016, 625);
            this.Controls.Add(this.m_tabStatBaseInfo);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmStatBaseInfo";
            this.Text = "统计基础资料维护";
            this.Load += new System.EventHandler(this.frmStatBaseInfo_Load);
            this.m_tabStatBaseInfo.ResumeLayout(false);
            this.m_tbpWorkGroup.ResumeLayout(false);
            this.m_gpbWorkGroup.ResumeLayout(false);
            this.m_gpbWorkGroup.PerformLayout();
            this.m_tbpStatGroup.ResumeLayout(false);
            this.m_tbpStatGroup.PerformLayout();
            this.m_gpbStatGroup.ResumeLayout(false);
            this.m_gpbStatGroup.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region CreateController
        public override void CreateController()
        {
            m_objController = new clsController_StatBaseInfo();
            m_objController.Set_GUI_Apperance(this);
        }
        #endregion

        #region 初始化界面信息
        private void frmStatBaseInfo_Load(object sender, System.EventArgs e)
        {
            m_objController.m_mthInitViewer();
        }
        #endregion

        #region 工作组维护

        #region 保存工作组信息
        private void m_btnSaveWorkGroup_Click(object sender, System.EventArgs e)
        {
            m_objController.m_mthSaveWorkGroup();
        }
        #endregion

        #region 删除工作组信息
        private void m_btnDelWorkGroup_Click(object sender, System.EventArgs e)
        {
            m_objController.m_mthDelWorkGroup();
        }
        #endregion

        #region 新增工作组信息
        private void m_btnNewWorkGroup_Click(object sender, System.EventArgs e)
        {
            m_objController.m_mthNewWorkGroup();
        }
        #endregion

        #region 显示选中的工作组信息
        private void m_lsvWorkGroup_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            m_objController.m_mthShowWorkGroupInfo();
        }
        #endregion

        #region 刷新工作组信息
        private void m_tabStatBaseInfo_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (this.m_tabStatBaseInfo.SelectedIndex == 1)
            {
                m_objController.m_mthRefreshStatGroup();
            }
        }
        #endregion

        #endregion

        #region 根据检验类别获取申请单元
        private void m_cboCheckCategory_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            m_objController.m_mthGetApplUnitByCheckCategory();
        }
        #endregion

        #region 新增统计组
        private void m_btnNewStatGroup_Click(object sender, System.EventArgs e)
        {
            m_objController.m_mthNewStatGroup();
        }
        #endregion

        #region 添加申请单元
        private void m_btnAdd_Click(object sender, System.EventArgs e)
        {
            m_objController.m_mthAddApplUnit();
        }
        #endregion

        #region 删除申请单元
        private void m_btnRemove_Click(object sender, System.EventArgs e)
        {
            m_objController.m_mthDelApplUnit();
        }
        #endregion

        #region 保存统计组
        private void m_btnSaveStatGroup_Click(object sender, System.EventArgs e)
        {
            m_objController.m_mthSaveStatGroup();
        }
        #endregion

        #region 显示选中的节点的信息
        private void m_trvStatGroup_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            m_objController.m_mthShowStatGroup();
        }
        #endregion

        #region 删除统计组
        private void m_btnDelStatGroup_Click(object sender, System.EventArgs e)
        {
            m_objController.m_mthDelStatGroup();
        }
        #endregion

        #region 关闭
        private void btnExit0_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion        

    }
}