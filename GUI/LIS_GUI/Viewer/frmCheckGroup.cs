using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using com.digitalwave.GUI_Base;//GUI_Base.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll

namespace com.digitalwave.iCare.gui.LIS
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmCheckGroup : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		#region 控件声名
		private System.Windows.Forms.GroupBox groupBox2;
		internal System.Windows.Forms.TextBox txtCheckGroupNo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		internal System.Windows.Forms.TextBox txtCheckGroupName;
		internal System.Windows.Forms.TextBox txtPyCode;
		private System.Windows.Forms.Label label9;
		internal System.Windows.Forms.TextBox txtWbCode;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Button btnDelCheckGroup;
		internal System.Windows.Forms.Button btnSaveCheckGroup;
		private System.Windows.Forms.Button btnNewCheckGroup;
		internal System.Windows.Forms.ComboBox cboPrintCategory;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.GroupBox gbBaseInfo;
		internal System.Windows.Forms.RadioButton rdbBseGroup;
		internal System.Windows.Forms.RadioButton rdbCheckGroup;
		internal System.Windows.Forms.TreeView trvCheckGroup;
		internal System.Windows.Forms.RadioButton rdbDeviceSample;
		internal System.Windows.Forms.RadioButton rdbManualSample;
		private System.Windows.Forms.Label lbSampleRemark;
		private System.Windows.Forms.Label lbDeviceModle;
		internal System.Windows.Forms.ComboBox cboDeviceModle;
		internal System.Windows.Forms.TextBox txtSampleRemark;
		private System.Windows.Forms.Label lbAssist01;
		internal System.Windows.Forms.TextBox txtAssist01;
		private System.Windows.Forms.Label lbAssist02;
		internal System.Windows.Forms.TextBox txtAssist02;
		private System.Windows.Forms.Label lbPrintTitle;
		internal System.Windows.Forms.TextBox txtPrintTitle;
		internal System.Windows.Forms.ListView m_lsvDeviceModel;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.TabPage tpCheckItem;
		private System.Windows.Forms.Label lbPrintOrder;
		private System.Windows.Forms.Button btnDown;
		private System.Windows.Forms.Button btnUP;
		internal System.Windows.Forms.ComboBox cboSampleType;
		private System.Windows.Forms.Label lbSampleType;
		private System.Windows.Forms.Label lbAddCheckItem;
		private System.Windows.Forms.Label lbAllCheckItem;
		internal System.Windows.Forms.ListView lsvAddCheckItem;
		private System.Windows.Forms.ColumnHeader chAddCheckItemID;
		private System.Windows.Forms.ColumnHeader chAddCheckItemEN;
		private System.Windows.Forms.ColumnHeader chAddCheckItemName;
		private System.Windows.Forms.ColumnHeader m_chmRptOrder;
		internal System.Windows.Forms.ListView lsvCheckItem;
		private System.Windows.Forms.ColumnHeader chCheckItemID;
		private System.Windows.Forms.ColumnHeader chCheckItemEn;
		private System.Windows.Forms.ColumnHeader chCheckItemName;
		internal System.Windows.Forms.Button btnDelCheckItem;
		private System.Windows.Forms.Button btnNewCheck;
		private System.Windows.Forms.TabPage tpSubGroup;
		private System.Windows.Forms.Button btnGroupDown;
		private System.Windows.Forms.Button btnGroupUp;
		private System.Windows.Forms.Label label4;
		internal System.Windows.Forms.TreeView trvAddSubGroup;
		private System.Windows.Forms.Label lbAddSubGroup;
		internal System.Windows.Forms.TreeView trvSubCheckGroup;
		internal System.Windows.Forms.Button btnDelSubGroup;
		private System.Windows.Forms.Button btnNewSubGroup;
		internal System.Windows.Forms.ListView lsvSubGroupCheckItem;
		private System.Windows.Forms.ColumnHeader chGroupCheckItemID;
		private System.Windows.Forms.ColumnHeader chGroupEN;
		private System.Windows.Forms.ColumnHeader chGroupCheckItemName;
		private System.Windows.Forms.TabControl tbcCheckGroupDetail;
		private System.Windows.Forms.Button m_btnAddModel;
		private System.Windows.Forms.Button m_btnRemoveModel;
		internal com.digitalwave.iCare.gui.LIS.ctlLISSampleTypeComboBox m_cboGroupSampleType;
		private System.Windows.Forms.Label m_lbSampleType;
		internal System.Windows.Forms.ListView m_lsvGroupSampleType;
		private System.Windows.Forms.ColumnHeader m_chSampleType;
		private System.Windows.Forms.Button m_btnGroupSampleAdd;
		private System.Windows.Forms.Button m_btnGroupSampleRemove;
		private System.Windows.Forms.TabPage m_tpSampleGroup;
		internal System.Windows.Forms.TreeView m_trvAddSampleGroup;
		private System.Windows.Forms.Label m_lbSampleGroup;
		internal System.Windows.Forms.TreeView m_trvApplUnit;
		internal System.Windows.Forms.ListView m_lsvApplUnitItem;
		internal System.Windows.Forms.Button m_btnRemoveApplUnit;
		private System.Windows.Forms.Button m_btnAddApplUnit;
		private System.Windows.Forms.ColumnHeader m_chCheckNo;
		private System.Windows.Forms.ColumnHeader m_chEnglishName;
		private System.Windows.Forms.ColumnHeader m_chCheckName;
		private System.Windows.Forms.ColumnHeader m_chPrintOrder;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button m_btnDownApplItem;
		private System.Windows.Forms.Button m_btnUpApplItem;
		private System.Windows.Forms.Label label3;
		internal System.Windows.Forms.ComboBox cboCheckCategory;
        private Button btnExit;
//		private System.Data.DataTable dtbAllCheckGroup = null;
//		private System.Data.DataTable dtbAllCheckCategory = null;
//		private System.Data.DataTable dtbCheckItemByCategory = null;
		#endregion

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmCheckGroup()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("标本组");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("报告组");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("申请单元");
            this.groupBox2 = new System.Windows.Forms.GroupBox();
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
            this.rdbBseGroup = new System.Windows.Forms.RadioButton();
            this.rdbCheckGroup = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.cboPrintCategory = new System.Windows.Forms.ComboBox();
            this.lbPrintTitle = new System.Windows.Forms.Label();
            this.txtPrintTitle = new System.Windows.Forms.TextBox();
            this.lbSampleRemark = new System.Windows.Forms.Label();
            this.txtSampleRemark = new System.Windows.Forms.TextBox();
            this.btnDelCheckGroup = new System.Windows.Forms.Button();
            this.btnSaveCheckGroup = new System.Windows.Forms.Button();
            this.btnNewCheckGroup = new System.Windows.Forms.Button();
            this.gbBaseInfo = new System.Windows.Forms.GroupBox();
            this.m_btnGroupSampleAdd = new System.Windows.Forms.Button();
            this.m_btnGroupSampleRemove = new System.Windows.Forms.Button();
            this.m_lsvGroupSampleType = new System.Windows.Forms.ListView();
            this.m_chSampleType = new System.Windows.Forms.ColumnHeader();
            this.m_cboGroupSampleType = new com.digitalwave.iCare.gui.LIS.ctlLISSampleTypeComboBox();
            this.m_lbSampleType = new System.Windows.Forms.Label();
            this.m_btnRemoveModel = new System.Windows.Forms.Button();
            this.m_btnAddModel = new System.Windows.Forms.Button();
            this.cboDeviceModle = new System.Windows.Forms.ComboBox();
            this.lbDeviceModle = new System.Windows.Forms.Label();
            this.m_lsvDeviceModel = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.rdbDeviceSample = new System.Windows.Forms.RadioButton();
            this.rdbManualSample = new System.Windows.Forms.RadioButton();
            this.trvCheckGroup = new System.Windows.Forms.TreeView();
            this.tpCheckItem = new System.Windows.Forms.TabPage();
            this.lbPrintOrder = new System.Windows.Forms.Label();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUP = new System.Windows.Forms.Button();
            this.cboSampleType = new System.Windows.Forms.ComboBox();
            this.lbSampleType = new System.Windows.Forms.Label();
            this.lbAddCheckItem = new System.Windows.Forms.Label();
            this.lbAllCheckItem = new System.Windows.Forms.Label();
            this.lsvAddCheckItem = new System.Windows.Forms.ListView();
            this.chAddCheckItemID = new System.Windows.Forms.ColumnHeader();
            this.chAddCheckItemEN = new System.Windows.Forms.ColumnHeader();
            this.chAddCheckItemName = new System.Windows.Forms.ColumnHeader();
            this.m_chmRptOrder = new System.Windows.Forms.ColumnHeader();
            this.lsvCheckItem = new System.Windows.Forms.ListView();
            this.chCheckItemID = new System.Windows.Forms.ColumnHeader();
            this.chCheckItemEn = new System.Windows.Forms.ColumnHeader();
            this.chCheckItemName = new System.Windows.Forms.ColumnHeader();
            this.btnDelCheckItem = new System.Windows.Forms.Button();
            this.btnNewCheck = new System.Windows.Forms.Button();
            this.tpSubGroup = new System.Windows.Forms.TabPage();
            this.btnGroupDown = new System.Windows.Forms.Button();
            this.btnGroupUp = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.trvAddSubGroup = new System.Windows.Forms.TreeView();
            this.lbAddSubGroup = new System.Windows.Forms.Label();
            this.trvSubCheckGroup = new System.Windows.Forms.TreeView();
            this.btnDelSubGroup = new System.Windows.Forms.Button();
            this.btnNewSubGroup = new System.Windows.Forms.Button();
            this.lsvSubGroupCheckItem = new System.Windows.Forms.ListView();
            this.chGroupCheckItemID = new System.Windows.Forms.ColumnHeader();
            this.chGroupEN = new System.Windows.Forms.ColumnHeader();
            this.chGroupCheckItemName = new System.Windows.Forms.ColumnHeader();
            this.tbcCheckGroupDetail = new System.Windows.Forms.TabControl();
            this.m_tpSampleGroup = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.cboCheckCategory = new System.Windows.Forms.ComboBox();
            this.m_btnDownApplItem = new System.Windows.Forms.Button();
            this.m_btnUpApplItem = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.m_btnRemoveApplUnit = new System.Windows.Forms.Button();
            this.m_btnAddApplUnit = new System.Windows.Forms.Button();
            this.m_trvAddSampleGroup = new System.Windows.Forms.TreeView();
            this.m_lbSampleGroup = new System.Windows.Forms.Label();
            this.m_trvApplUnit = new System.Windows.Forms.TreeView();
            this.m_lsvApplUnitItem = new System.Windows.Forms.ListView();
            this.m_chCheckNo = new System.Windows.Forms.ColumnHeader();
            this.m_chEnglishName = new System.Windows.Forms.ColumnHeader();
            this.m_chCheckName = new System.Windows.Forms.ColumnHeader();
            this.m_chPrintOrder = new System.Windows.Forms.ColumnHeader();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.gbBaseInfo.SuspendLayout();
            this.tpCheckItem.SuspendLayout();
            this.tpSubGroup.SuspendLayout();
            this.tbcCheckGroupDetail.SuspendLayout();
            this.m_tpSampleGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
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
            this.groupBox2.Controls.Add(this.rdbBseGroup);
            this.groupBox2.Controls.Add(this.rdbCheckGroup);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cboPrintCategory);
            this.groupBox2.Controls.Add(this.lbPrintTitle);
            this.groupBox2.Controls.Add(this.txtPrintTitle);
            this.groupBox2.Controls.Add(this.lbSampleRemark);
            this.groupBox2.Controls.Add(this.txtSampleRemark);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(212, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(400, 184);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "检验组信息";
            // 
            // txtAssist02
            // 
            this.txtAssist02.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAssist02.Location = new System.Drawing.Point(272, 72);
            this.txtAssist02.Name = "txtAssist02";
            this.txtAssist02.Size = new System.Drawing.Size(120, 23);
            this.txtAssist02.TabIndex = 36;
            // 
            // lbAssist02
            // 
            this.lbAssist02.Location = new System.Drawing.Point(192, 80);
            this.lbAssist02.Name = "lbAssist02";
            this.lbAssist02.Size = new System.Drawing.Size(80, 16);
            this.lbAssist02.TabIndex = 35;
            this.lbAssist02.Text = "第二助记码";
            // 
            // txtAssist01
            // 
            this.txtAssist01.Location = new System.Drawing.Point(88, 72);
            this.txtAssist01.Name = "txtAssist01";
            this.txtAssist01.Size = new System.Drawing.Size(96, 23);
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
            this.txtCheckGroupNo.Size = new System.Drawing.Size(96, 23);
            this.txtCheckGroupNo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "检验组号";
            // 
            // txtPyCode
            // 
            this.txtPyCode.Location = new System.Drawing.Point(88, 48);
            this.txtPyCode.MaxLength = 10;
            this.txtPyCode.Name = "txtPyCode";
            this.txtPyCode.Size = new System.Drawing.Size(96, 23);
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
            this.label18.Location = new System.Drawing.Point(192, 56);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(80, 16);
            this.label18.TabIndex = 28;
            this.label18.Text = "五笔助记符";
            // 
            // txtWbCode
            // 
            this.txtWbCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWbCode.Location = new System.Drawing.Point(272, 48);
            this.txtWbCode.MaxLength = 10;
            this.txtWbCode.Name = "txtWbCode";
            this.txtWbCode.Size = new System.Drawing.Size(120, 23);
            this.txtWbCode.TabIndex = 29;
            // 
            // txtCheckGroupName
            // 
            this.txtCheckGroupName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCheckGroupName.Location = new System.Drawing.Point(272, 24);
            this.txtCheckGroupName.MaxLength = 30;
            this.txtCheckGroupName.Name = "txtCheckGroupName";
            this.txtCheckGroupName.Size = new System.Drawing.Size(120, 23);
            this.txtCheckGroupName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(192, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "检验组名称";
            // 
            // rdbBseGroup
            // 
            this.rdbBseGroup.Location = new System.Drawing.Point(8, 152);
            this.rdbBseGroup.Name = "rdbBseGroup";
            this.rdbBseGroup.Size = new System.Drawing.Size(72, 24);
            this.rdbBseGroup.TabIndex = 30;
            this.rdbBseGroup.Text = "标本组";
            this.rdbBseGroup.CheckedChanged += new System.EventHandler(this.rdbBseGroup_CheckedChanged);
            // 
            // rdbCheckGroup
            // 
            this.rdbCheckGroup.Location = new System.Drawing.Point(104, 152);
            this.rdbCheckGroup.Name = "rdbCheckGroup";
            this.rdbCheckGroup.Size = new System.Drawing.Size(72, 24);
            this.rdbCheckGroup.TabIndex = 31;
            this.rdbCheckGroup.Text = "报告组";
            this.rdbCheckGroup.CheckedChanged += new System.EventHandler(this.rdbCheckGroup_CheckedChanged);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(8, 104);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 16);
            this.label10.TabIndex = 30;
            this.label10.Text = "打印类别";
            // 
            // cboPrintCategory
            // 
            this.cboPrintCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrintCategory.Enabled = false;
            this.cboPrintCategory.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboPrintCategory.ItemHeight = 14;
            this.cboPrintCategory.Location = new System.Drawing.Point(88, 96);
            this.cboPrintCategory.Name = "cboPrintCategory";
            this.cboPrintCategory.Size = new System.Drawing.Size(96, 22);
            this.cboPrintCategory.TabIndex = 31;
            // 
            // lbPrintTitle
            // 
            this.lbPrintTitle.Location = new System.Drawing.Point(192, 104);
            this.lbPrintTitle.Name = "lbPrintTitle";
            this.lbPrintTitle.Size = new System.Drawing.Size(64, 16);
            this.lbPrintTitle.TabIndex = 40;
            this.lbPrintTitle.Text = "打印标题";
            // 
            // txtPrintTitle
            // 
            this.txtPrintTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrintTitle.Location = new System.Drawing.Point(272, 96);
            this.txtPrintTitle.Name = "txtPrintTitle";
            this.txtPrintTitle.Size = new System.Drawing.Size(120, 23);
            this.txtPrintTitle.TabIndex = 41;
            // 
            // lbSampleRemark
            // 
            this.lbSampleRemark.Location = new System.Drawing.Point(8, 128);
            this.lbSampleRemark.Name = "lbSampleRemark";
            this.lbSampleRemark.Size = new System.Drawing.Size(64, 16);
            this.lbSampleRemark.TabIndex = 36;
            this.lbSampleRemark.Text = "采样备注";
            // 
            // txtSampleRemark
            // 
            this.txtSampleRemark.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSampleRemark.Location = new System.Drawing.Point(88, 120);
            this.txtSampleRemark.Name = "txtSampleRemark";
            this.txtSampleRemark.Size = new System.Drawing.Size(304, 23);
            this.txtSampleRemark.TabIndex = 39;
            // 
            // btnDelCheckGroup
            // 
            this.btnDelCheckGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelCheckGroup.Location = new System.Drawing.Point(791, 544);
            this.btnDelCheckGroup.Name = "btnDelCheckGroup";
            this.btnDelCheckGroup.Size = new System.Drawing.Size(75, 23);
            this.btnDelCheckGroup.TabIndex = 42;
            this.btnDelCheckGroup.Text = "删除";
            this.btnDelCheckGroup.Click += new System.EventHandler(this.btnDelCheckGroup_Click);
            // 
            // btnSaveCheckGroup
            // 
            this.btnSaveCheckGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveCheckGroup.Location = new System.Drawing.Point(694, 544);
            this.btnSaveCheckGroup.Name = "btnSaveCheckGroup";
            this.btnSaveCheckGroup.Size = new System.Drawing.Size(75, 23);
            this.btnSaveCheckGroup.TabIndex = 41;
            this.btnSaveCheckGroup.Text = "保存";
            this.btnSaveCheckGroup.Click += new System.EventHandler(this.btnSaveCheckGroup_Click);
            // 
            // btnNewCheckGroup
            // 
            this.btnNewCheckGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewCheckGroup.Location = new System.Drawing.Point(597, 544);
            this.btnNewCheckGroup.Name = "btnNewCheckGroup";
            this.btnNewCheckGroup.Size = new System.Drawing.Size(75, 23);
            this.btnNewCheckGroup.TabIndex = 40;
            this.btnNewCheckGroup.Text = "新增";
            this.btnNewCheckGroup.Click += new System.EventHandler(this.btnNewCheckGroup_Click);
            // 
            // gbBaseInfo
            // 
            this.gbBaseInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbBaseInfo.Controls.Add(this.m_btnGroupSampleAdd);
            this.gbBaseInfo.Controls.Add(this.m_btnGroupSampleRemove);
            this.gbBaseInfo.Controls.Add(this.m_lsvGroupSampleType);
            this.gbBaseInfo.Controls.Add(this.m_cboGroupSampleType);
            this.gbBaseInfo.Controls.Add(this.m_lbSampleType);
            this.gbBaseInfo.Controls.Add(this.m_btnRemoveModel);
            this.gbBaseInfo.Controls.Add(this.m_btnAddModel);
            this.gbBaseInfo.Controls.Add(this.cboDeviceModle);
            this.gbBaseInfo.Controls.Add(this.lbDeviceModle);
            this.gbBaseInfo.Controls.Add(this.m_lsvDeviceModel);
            this.gbBaseInfo.Controls.Add(this.rdbDeviceSample);
            this.gbBaseInfo.Controls.Add(this.rdbManualSample);
            this.gbBaseInfo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbBaseInfo.Location = new System.Drawing.Point(616, 8);
            this.gbBaseInfo.Name = "gbBaseInfo";
            this.gbBaseInfo.Size = new System.Drawing.Size(368, 184);
            this.gbBaseInfo.TabIndex = 43;
            this.gbBaseInfo.TabStop = false;
            this.gbBaseInfo.Text = "其他信息";
            // 
            // m_btnGroupSampleAdd
            // 
            this.m_btnGroupSampleAdd.Location = new System.Drawing.Point(188, 44);
            this.m_btnGroupSampleAdd.Name = "m_btnGroupSampleAdd";
            this.m_btnGroupSampleAdd.Size = new System.Drawing.Size(28, 20);
            this.m_btnGroupSampleAdd.TabIndex = 49;
            this.m_btnGroupSampleAdd.Text = "︾";
            this.m_btnGroupSampleAdd.Click += new System.EventHandler(this.m_btnGroupSampleAdd_Click);
            // 
            // m_btnGroupSampleRemove
            // 
            this.m_btnGroupSampleRemove.Location = new System.Drawing.Point(224, 44);
            this.m_btnGroupSampleRemove.Name = "m_btnGroupSampleRemove";
            this.m_btnGroupSampleRemove.Size = new System.Drawing.Size(28, 20);
            this.m_btnGroupSampleRemove.TabIndex = 48;
            this.m_btnGroupSampleRemove.Text = "︽";
            this.m_btnGroupSampleRemove.Click += new System.EventHandler(this.m_btnGroupSampleRemove_Click);
            // 
            // m_lsvGroupSampleType
            // 
            this.m_lsvGroupSampleType.CheckBoxes = true;
            this.m_lsvGroupSampleType.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_chSampleType});
            this.m_lsvGroupSampleType.FullRowSelect = true;
            this.m_lsvGroupSampleType.HideSelection = false;
            this.m_lsvGroupSampleType.Location = new System.Drawing.Point(188, 68);
            this.m_lsvGroupSampleType.MultiSelect = false;
            this.m_lsvGroupSampleType.Name = "m_lsvGroupSampleType";
            this.m_lsvGroupSampleType.Size = new System.Drawing.Size(168, 76);
            this.m_lsvGroupSampleType.TabIndex = 47;
            this.m_lsvGroupSampleType.UseCompatibleStateImageBehavior = false;
            this.m_lsvGroupSampleType.View = System.Windows.Forms.View.Details;
            // 
            // m_chSampleType
            // 
            this.m_chSampleType.Text = "标本类别";
            this.m_chSampleType.Width = 161;
            // 
            // m_cboGroupSampleType
            // 
            this.m_cboGroupSampleType.DisplayMember = "SAMPLE_TYPE_DESC_VCHR";
            this.m_cboGroupSampleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboGroupSampleType.ItemHeight = 14;
            this.m_cboGroupSampleType.Location = new System.Drawing.Point(248, 20);
            this.m_cboGroupSampleType.Name = "m_cboGroupSampleType";
            this.m_cboGroupSampleType.Size = new System.Drawing.Size(104, 22);
            this.m_cboGroupSampleType.TabIndex = 46;
            this.m_cboGroupSampleType.ValueMember = "SAMPLE_TYPE_ID_CHR";
            // 
            // m_lbSampleType
            // 
            this.m_lbSampleType.Location = new System.Drawing.Point(184, 24);
            this.m_lbSampleType.Name = "m_lbSampleType";
            this.m_lbSampleType.Size = new System.Drawing.Size(64, 16);
            this.m_lbSampleType.TabIndex = 45;
            this.m_lbSampleType.Text = "标本类别";
            // 
            // m_btnRemoveModel
            // 
            this.m_btnRemoveModel.Location = new System.Drawing.Point(44, 44);
            this.m_btnRemoveModel.Name = "m_btnRemoveModel";
            this.m_btnRemoveModel.Size = new System.Drawing.Size(28, 20);
            this.m_btnRemoveModel.TabIndex = 44;
            this.m_btnRemoveModel.Text = "︽";
            this.m_btnRemoveModel.Click += new System.EventHandler(this.m_btnRemoveModel_Click);
            // 
            // m_btnAddModel
            // 
            this.m_btnAddModel.Location = new System.Drawing.Point(8, 44);
            this.m_btnAddModel.Name = "m_btnAddModel";
            this.m_btnAddModel.Size = new System.Drawing.Size(28, 20);
            this.m_btnAddModel.TabIndex = 43;
            this.m_btnAddModel.Text = "︾";
            this.m_btnAddModel.Click += new System.EventHandler(this.m_btnAddModel_Click);
            // 
            // cboDeviceModle
            // 
            this.cboDeviceModle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDeviceModle.Location = new System.Drawing.Point(68, 20);
            this.cboDeviceModle.Name = "cboDeviceModle";
            this.cboDeviceModle.Size = new System.Drawing.Size(104, 22);
            this.cboDeviceModle.TabIndex = 38;
            // 
            // lbDeviceModle
            // 
            this.lbDeviceModle.Location = new System.Drawing.Point(4, 24);
            this.lbDeviceModle.Name = "lbDeviceModle";
            this.lbDeviceModle.Size = new System.Drawing.Size(64, 16);
            this.lbDeviceModle.TabIndex = 37;
            this.lbDeviceModle.Text = "仪器类型";
            // 
            // m_lsvDeviceModel
            // 
            this.m_lsvDeviceModel.CheckBoxes = true;
            this.m_lsvDeviceModel.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.m_lsvDeviceModel.FullRowSelect = true;
            this.m_lsvDeviceModel.HideSelection = false;
            this.m_lsvDeviceModel.Location = new System.Drawing.Point(8, 68);
            this.m_lsvDeviceModel.MultiSelect = false;
            this.m_lsvDeviceModel.Name = "m_lsvDeviceModel";
            this.m_lsvDeviceModel.Size = new System.Drawing.Size(168, 76);
            this.m_lsvDeviceModel.TabIndex = 42;
            this.m_lsvDeviceModel.UseCompatibleStateImageBehavior = false;
            this.m_lsvDeviceModel.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "仪器型号";
            this.columnHeader1.Width = 161;
            // 
            // rdbDeviceSample
            // 
            this.rdbDeviceSample.Location = new System.Drawing.Point(8, 152);
            this.rdbDeviceSample.Name = "rdbDeviceSample";
            this.rdbDeviceSample.Size = new System.Drawing.Size(88, 24);
            this.rdbDeviceSample.TabIndex = 34;
            this.rdbDeviceSample.Text = "仪器标本";
            this.rdbDeviceSample.CheckedChanged += new System.EventHandler(this.rdbDeviceSample_CheckedChanged);
            // 
            // rdbManualSample
            // 
            this.rdbManualSample.Location = new System.Drawing.Point(116, 152);
            this.rdbManualSample.Name = "rdbManualSample";
            this.rdbManualSample.Size = new System.Drawing.Size(88, 24);
            this.rdbManualSample.TabIndex = 35;
            this.rdbManualSample.Text = "手工标本";
            this.rdbManualSample.CheckedChanged += new System.EventHandler(this.rdbManualSample_CheckedChanged);
            // 
            // trvCheckGroup
            // 
            this.trvCheckGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.trvCheckGroup.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.trvCheckGroup.HideSelection = false;
            this.trvCheckGroup.Location = new System.Drawing.Point(8, 16);
            this.trvCheckGroup.Name = "trvCheckGroup";
            treeNode1.Name = "";
            treeNode1.Text = "标本组";
            treeNode2.Name = "";
            treeNode2.Text = "报告组";
            this.trvCheckGroup.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.trvCheckGroup.Size = new System.Drawing.Size(196, 512);
            this.trvCheckGroup.TabIndex = 44;
            this.trvCheckGroup.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvCheckGroup_AfterSelect_1);
            // 
            // tpCheckItem
            // 
            this.tpCheckItem.Controls.Add(this.lbPrintOrder);
            this.tpCheckItem.Controls.Add(this.btnDown);
            this.tpCheckItem.Controls.Add(this.btnUP);
            this.tpCheckItem.Controls.Add(this.cboSampleType);
            this.tpCheckItem.Controls.Add(this.lbSampleType);
            this.tpCheckItem.Controls.Add(this.lbAddCheckItem);
            this.tpCheckItem.Controls.Add(this.lbAllCheckItem);
            this.tpCheckItem.Controls.Add(this.lsvAddCheckItem);
            this.tpCheckItem.Controls.Add(this.lsvCheckItem);
            this.tpCheckItem.Controls.Add(this.btnDelCheckItem);
            this.tpCheckItem.Controls.Add(this.btnNewCheck);
            this.tpCheckItem.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tpCheckItem.Location = new System.Drawing.Point(4, 23);
            this.tpCheckItem.Name = "tpCheckItem";
            this.tpCheckItem.Size = new System.Drawing.Size(768, 309);
            this.tpCheckItem.TabIndex = 0;
            this.tpCheckItem.Text = "标本组";
            // 
            // lbPrintOrder
            // 
            this.lbPrintOrder.Location = new System.Drawing.Point(376, 16);
            this.lbPrintOrder.Name = "lbPrintOrder";
            this.lbPrintOrder.Size = new System.Drawing.Size(96, 16);
            this.lbPrintOrder.TabIndex = 40;
            this.lbPrintOrder.Text = "打印顺序调整";
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(520, 8);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(32, 24);
            this.btnDown.TabIndex = 39;
            this.btnDown.Text = "↓";
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUP
            // 
            this.btnUP.Location = new System.Drawing.Point(480, 8);
            this.btnUP.Name = "btnUP";
            this.btnUP.Size = new System.Drawing.Size(32, 24);
            this.btnUP.TabIndex = 38;
            this.btnUP.Text = "↑";
            this.btnUP.Click += new System.EventHandler(this.btnUP_Click);
            // 
            // cboSampleType
            // 
            this.cboSampleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSampleType.ItemHeight = 14;
            this.cboSampleType.Location = new System.Drawing.Point(264, 8);
            this.cboSampleType.Name = "cboSampleType";
            this.cboSampleType.Size = new System.Drawing.Size(104, 22);
            this.cboSampleType.TabIndex = 35;
            // 
            // lbSampleType
            // 
            this.lbSampleType.Location = new System.Drawing.Point(200, 16);
            this.lbSampleType.Name = "lbSampleType";
            this.lbSampleType.Size = new System.Drawing.Size(64, 16);
            this.lbSampleType.TabIndex = 34;
            this.lbSampleType.Text = "标本类别";
            // 
            // lbAddCheckItem
            // 
            this.lbAddCheckItem.Location = new System.Drawing.Point(376, 40);
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
            this.chAddCheckItemName,
            this.m_chmRptOrder});
            this.lsvAddCheckItem.FullRowSelect = true;
            this.lsvAddCheckItem.HideSelection = false;
            this.lsvAddCheckItem.Location = new System.Drawing.Point(376, 56);
            this.lsvAddCheckItem.MultiSelect = false;
            this.lsvAddCheckItem.Name = "lsvAddCheckItem";
            this.lsvAddCheckItem.Size = new System.Drawing.Size(376, 212);
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
            // m_chmRptOrder
            // 
            this.m_chmRptOrder.Text = "打印顺序";
            this.m_chmRptOrder.Width = 80;
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
            this.lsvCheckItem.Size = new System.Drawing.Size(328, 212);
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
            // btnDelCheckItem
            // 
            this.btnDelCheckItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelCheckItem.Enabled = false;
            this.btnDelCheckItem.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelCheckItem.Location = new System.Drawing.Point(672, 276);
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
            this.btnNewCheck.Location = new System.Drawing.Point(576, 276);
            this.btnNewCheck.Name = "btnNewCheck";
            this.btnNewCheck.Size = new System.Drawing.Size(75, 23);
            this.btnNewCheck.TabIndex = 30;
            this.btnNewCheck.Text = "添加";
            this.btnNewCheck.Click += new System.EventHandler(this.btnNewCheck_Click);
            // 
            // tpSubGroup
            // 
            this.tpSubGroup.Controls.Add(this.btnGroupDown);
            this.tpSubGroup.Controls.Add(this.btnGroupUp);
            this.tpSubGroup.Controls.Add(this.label4);
            this.tpSubGroup.Controls.Add(this.trvAddSubGroup);
            this.tpSubGroup.Controls.Add(this.lbAddSubGroup);
            this.tpSubGroup.Controls.Add(this.trvSubCheckGroup);
            this.tpSubGroup.Controls.Add(this.btnDelSubGroup);
            this.tpSubGroup.Controls.Add(this.btnNewSubGroup);
            this.tpSubGroup.Controls.Add(this.lsvSubGroupCheckItem);
            this.tpSubGroup.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tpSubGroup.Location = new System.Drawing.Point(4, 23);
            this.tpSubGroup.Name = "tpSubGroup";
            this.tpSubGroup.Size = new System.Drawing.Size(768, 309);
            this.tpSubGroup.TabIndex = 1;
            this.tpSubGroup.Text = "报告组";
            this.tpSubGroup.Visible = false;
            // 
            // btnGroupDown
            // 
            this.btnGroupDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGroupDown.Location = new System.Drawing.Point(528, 8);
            this.btnGroupDown.Name = "btnGroupDown";
            this.btnGroupDown.Size = new System.Drawing.Size(32, 24);
            this.btnGroupDown.TabIndex = 42;
            this.btnGroupDown.Text = "↓";
            this.btnGroupDown.Click += new System.EventHandler(this.btnGroupDown_Click);
            // 
            // btnGroupUp
            // 
            this.btnGroupUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGroupUp.Location = new System.Drawing.Point(488, 8);
            this.btnGroupUp.Name = "btnGroupUp";
            this.btnGroupUp.Size = new System.Drawing.Size(32, 24);
            this.btnGroupUp.TabIndex = 41;
            this.btnGroupUp.Text = "↑";
            this.btnGroupUp.Click += new System.EventHandler(this.btnGroupUp_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(360, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.label4.TabIndex = 40;
            this.label4.Text = "打印顺序调整";
            // 
            // trvAddSubGroup
            // 
            this.trvAddSubGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trvAddSubGroup.CheckBoxes = true;
            this.trvAddSubGroup.HideSelection = false;
            this.trvAddSubGroup.ItemHeight = 16;
            this.trvAddSubGroup.Location = new System.Drawing.Point(360, 40);
            this.trvAddSubGroup.Name = "trvAddSubGroup";
            this.trvAddSubGroup.Size = new System.Drawing.Size(392, 224);
            this.trvAddSubGroup.TabIndex = 39;
            this.trvAddSubGroup.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.trvAddSubGroup_AfterCheck);
            this.trvAddSubGroup.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.trvAddSubGroup_AfterExpand);
            // 
            // lbAddSubGroup
            // 
            this.lbAddSubGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAddSubGroup.Location = new System.Drawing.Point(360, 124);
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
            this.trvSubCheckGroup.ItemHeight = 16;
            this.trvSubCheckGroup.Location = new System.Drawing.Point(16, 40);
            this.trvSubCheckGroup.Name = "trvSubCheckGroup";
            this.trvSubCheckGroup.Size = new System.Drawing.Size(320, 228);
            this.trvSubCheckGroup.TabIndex = 35;
            this.trvSubCheckGroup.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.trvCheckGroup_AfterCheck);
            this.trvSubCheckGroup.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvCheckGroup_AfterSelect);
            // 
            // btnDelSubGroup
            // 
            this.btnDelSubGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelSubGroup.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelSubGroup.Location = new System.Drawing.Point(672, 280);
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
            this.btnNewSubGroup.Location = new System.Drawing.Point(576, 280);
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
            this.lsvSubGroupCheckItem.Location = new System.Drawing.Point(360, 40);
            this.lsvSubGroupCheckItem.Name = "lsvSubGroupCheckItem";
            this.lsvSubGroupCheckItem.Size = new System.Drawing.Size(392, 76);
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
            // tbcCheckGroupDetail
            // 
            this.tbcCheckGroupDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcCheckGroupDetail.Controls.Add(this.m_tpSampleGroup);
            this.tbcCheckGroupDetail.Controls.Add(this.tpCheckItem);
            this.tbcCheckGroupDetail.Controls.Add(this.tpSubGroup);
            this.tbcCheckGroupDetail.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbcCheckGroupDetail.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbcCheckGroupDetail.ItemSize = new System.Drawing.Size(68, 19);
            this.tbcCheckGroupDetail.Location = new System.Drawing.Point(212, 192);
            this.tbcCheckGroupDetail.Name = "tbcCheckGroupDetail";
            this.tbcCheckGroupDetail.SelectedIndex = 0;
            this.tbcCheckGroupDetail.Size = new System.Drawing.Size(776, 336);
            this.tbcCheckGroupDetail.TabIndex = 39;
            // 
            // m_tpSampleGroup
            // 
            this.m_tpSampleGroup.Controls.Add(this.label3);
            this.m_tpSampleGroup.Controls.Add(this.cboCheckCategory);
            this.m_tpSampleGroup.Controls.Add(this.m_btnDownApplItem);
            this.m_tpSampleGroup.Controls.Add(this.m_btnUpApplItem);
            this.m_tpSampleGroup.Controls.Add(this.label5);
            this.m_tpSampleGroup.Controls.Add(this.m_btnRemoveApplUnit);
            this.m_tpSampleGroup.Controls.Add(this.m_btnAddApplUnit);
            this.m_tpSampleGroup.Controls.Add(this.m_trvAddSampleGroup);
            this.m_tpSampleGroup.Controls.Add(this.m_lbSampleGroup);
            this.m_tpSampleGroup.Controls.Add(this.m_trvApplUnit);
            this.m_tpSampleGroup.Controls.Add(this.m_lsvApplUnitItem);
            this.m_tpSampleGroup.Location = new System.Drawing.Point(4, 23);
            this.m_tpSampleGroup.Name = "m_tpSampleGroup";
            this.m_tpSampleGroup.Size = new System.Drawing.Size(768, 309);
            this.m_tpSampleGroup.TabIndex = 2;
            this.m_tpSampleGroup.Text = "标本组";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 60;
            this.label3.Text = "检验类别";
            // 
            // cboCheckCategory
            // 
            this.cboCheckCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCheckCategory.ItemHeight = 14;
            this.cboCheckCategory.Location = new System.Drawing.Point(84, 8);
            this.cboCheckCategory.Name = "cboCheckCategory";
            this.cboCheckCategory.Size = new System.Drawing.Size(112, 22);
            this.cboCheckCategory.TabIndex = 59;
            this.cboCheckCategory.SelectedIndexChanged += new System.EventHandler(this.cboCheckCategory_SelectedIndexChanged);
            // 
            // m_btnDownApplItem
            // 
            this.m_btnDownApplItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnDownApplItem.Location = new System.Drawing.Point(528, 8);
            this.m_btnDownApplItem.Name = "m_btnDownApplItem";
            this.m_btnDownApplItem.Size = new System.Drawing.Size(32, 24);
            this.m_btnDownApplItem.TabIndex = 54;
            this.m_btnDownApplItem.Text = "↓";
            this.m_btnDownApplItem.Click += new System.EventHandler(this.m_btnDownApplItem_Click);
            // 
            // m_btnUpApplItem
            // 
            this.m_btnUpApplItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnUpApplItem.Location = new System.Drawing.Point(488, 8);
            this.m_btnUpApplItem.Name = "m_btnUpApplItem";
            this.m_btnUpApplItem.Size = new System.Drawing.Size(32, 24);
            this.m_btnUpApplItem.TabIndex = 53;
            this.m_btnUpApplItem.Text = "↑";
            this.m_btnUpApplItem.Click += new System.EventHandler(this.m_btnUpApplItem_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Location = new System.Drawing.Point(360, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 16);
            this.label5.TabIndex = 52;
            this.label5.Text = "打印顺序调整";
            // 
            // m_btnRemoveApplUnit
            // 
            this.m_btnRemoveApplUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnRemoveApplUnit.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnRemoveApplUnit.Location = new System.Drawing.Point(672, 280);
            this.m_btnRemoveApplUnit.Name = "m_btnRemoveApplUnit";
            this.m_btnRemoveApplUnit.Size = new System.Drawing.Size(75, 23);
            this.m_btnRemoveApplUnit.TabIndex = 51;
            this.m_btnRemoveApplUnit.Text = "删除";
            this.m_btnRemoveApplUnit.Click += new System.EventHandler(this.m_btnRemoveApplUnit_Click);
            // 
            // m_btnAddApplUnit
            // 
            this.m_btnAddApplUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnAddApplUnit.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_btnAddApplUnit.Location = new System.Drawing.Point(576, 280);
            this.m_btnAddApplUnit.Name = "m_btnAddApplUnit";
            this.m_btnAddApplUnit.Size = new System.Drawing.Size(75, 23);
            this.m_btnAddApplUnit.TabIndex = 50;
            this.m_btnAddApplUnit.Text = "添加";
            this.m_btnAddApplUnit.Click += new System.EventHandler(this.m_btnAddApplUnit_Click);
            // 
            // m_trvAddSampleGroup
            // 
            this.m_trvAddSampleGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_trvAddSampleGroup.CheckBoxes = true;
            this.m_trvAddSampleGroup.HideSelection = false;
            this.m_trvAddSampleGroup.ItemHeight = 16;
            this.m_trvAddSampleGroup.Location = new System.Drawing.Point(360, 140);
            this.m_trvAddSampleGroup.Name = "m_trvAddSampleGroup";
            this.m_trvAddSampleGroup.Size = new System.Drawing.Size(392, 128);
            this.m_trvAddSampleGroup.TabIndex = 46;
            // 
            // m_lbSampleGroup
            // 
            this.m_lbSampleGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lbSampleGroup.Location = new System.Drawing.Point(360, 124);
            this.m_lbSampleGroup.Name = "m_lbSampleGroup";
            this.m_lbSampleGroup.Size = new System.Drawing.Size(64, 16);
            this.m_lbSampleGroup.TabIndex = 45;
            this.m_lbSampleGroup.Text = "检验子组";
            // 
            // m_trvApplUnit
            // 
            this.m_trvApplUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_trvApplUnit.CheckBoxes = true;
            this.m_trvApplUnit.HideSelection = false;
            this.m_trvApplUnit.ItemHeight = 16;
            this.m_trvApplUnit.Location = new System.Drawing.Point(12, 40);
            this.m_trvApplUnit.Name = "m_trvApplUnit";
            treeNode3.Name = "";
            treeNode3.Text = "申请单元";
            this.m_trvApplUnit.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.m_trvApplUnit.Size = new System.Drawing.Size(328, 228);
            this.m_trvApplUnit.TabIndex = 44;
            this.m_trvApplUnit.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.m_trvApplUnit_AfterCheck);
            // 
            // m_lsvApplUnitItem
            // 
            this.m_lsvApplUnitItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lsvApplUnitItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_chCheckNo,
            this.m_chEnglishName,
            this.m_chCheckName,
            this.m_chPrintOrder});
            this.m_lsvApplUnitItem.FullRowSelect = true;
            this.m_lsvApplUnitItem.HideSelection = false;
            this.m_lsvApplUnitItem.Location = new System.Drawing.Point(360, 40);
            this.m_lsvApplUnitItem.MultiSelect = false;
            this.m_lsvApplUnitItem.Name = "m_lsvApplUnitItem";
            this.m_lsvApplUnitItem.Size = new System.Drawing.Size(392, 76);
            this.m_lsvApplUnitItem.TabIndex = 43;
            this.m_lsvApplUnitItem.UseCompatibleStateImageBehavior = false;
            this.m_lsvApplUnitItem.View = System.Windows.Forms.View.Details;
            // 
            // m_chCheckNo
            // 
            this.m_chCheckNo.Text = "检验编号";
            this.m_chCheckNo.Width = 80;
            // 
            // m_chEnglishName
            // 
            this.m_chEnglishName.Text = "英文名称";
            this.m_chEnglishName.Width = 80;
            // 
            // m_chCheckName
            // 
            this.m_chCheckName.Text = "检验名称";
            this.m_chCheckName.Width = 100;
            // 
            // m_chPrintOrder
            // 
            this.m_chPrintOrder.Text = "打印顺序";
            this.m_chPrintOrder.Width = 80;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(888, 544);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 45;
            this.btnExit.Text = "关闭(&C)";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmCheckGroup
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(992, 581);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.trvCheckGroup);
            this.Controls.Add(this.gbBaseInfo);
            this.Controls.Add(this.btnDelCheckGroup);
            this.Controls.Add(this.btnSaveCheckGroup);
            this.Controls.Add(this.btnNewCheckGroup);
            this.Controls.Add(this.tbcCheckGroupDetail);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmCheckGroup";
            this.Text = "检验组合信息";
            this.Load += new System.EventHandler(this.frmCheckGroup_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbBaseInfo.ResumeLayout(false);
            this.tpCheckItem.ResumeLayout(false);
            this.tpSubGroup.ResumeLayout(false);
            this.tbcCheckGroupDetail.ResumeLayout(false);
            this.m_tpSampleGroup.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
//		[STAThread]
//		static void Main() 
//		{
//			Application.Run(new frmCheckGroup());
//		}

		public override void CreateController()
		{
			this.objController = new com.digitalwave.iCare.gui.LIS.clsController_CheckGroup();
			((clsController_CheckGroup)this.objController).Set_GUI_Apperance(this);
		}

		private void frmCheckGroup_Load(object sender, System.EventArgs e)
		{
			((clsController_CheckGroup)this.objController).GetInitInfo(this);
		}

//		private void cboCheckCategory_SelectedIndexChanged(object sender, System.EventArgs e)
//		{
//			if(this.cboCheckCategory.Items.Count > 0 && this.cboSampleType.Items.Count > 0)
//			{
//				((clsController_CheckGroup)this.objController).getAllCheckItemByCheckCategory(this);
//			}
//		}

		private void btnNewCheck_Click(object sender, System.EventArgs e)
		{
			((clsController_CheckGroup)this.objController).NewCheckItemBybtnNewCheckClick(this);
		}

		private void btnDelCheckItem_Click(object sender, System.EventArgs e)
		{
			((clsController_CheckGroup)this.objController).DelCheckItemBybtnDelCheckClick(this);
		}

		private void lsvAllCheckGroup_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ResetAll();
			btnSaveCheckGroup.Text = "修改";
		}

		private void ResetAll()
		{
			this.txtCheckGroupName.Text = "";
			this.txtCheckGroupNo.Text = "";
			this.txtPyCode.Text = "";
			this.txtWbCode.Text = "";
//			this.txtSampleNum.Text = "";
//			this.txtSampleValidatTime.Text = "";
			this.txtSampleRemark.Text = "";
			this.txtAssist01.Text = "";
			this.txtAssist02.Text = "";
			this.txtPrintTitle.Text = "";
//			this.chkBodyCheck.Checked = false;
//			this.chkNoFood.Checked = false;
//			this.chkReservation.Checked = false;
//			this.lsvAddCheckItem.Items.Clear();
//			this.lsvAddSubGroup.Items.Clear();
//			this.lsvSampleInfo.Items.Clear();
//			this.lsvAllCheckItemDetail.Items.Clear();
			this.trvAddSubGroup.Nodes.Clear();
			this.btnSaveCheckGroup.Text = "保存";
			this.lsvAddCheckItem.Items.Clear();
			this.m_lsvGroupSampleType.Items.Clear();
			this.trvAddSubGroup.Nodes.Clear();
			this.m_lsvDeviceModel.Items.Clear();
			((clsController_CheckGroup)this.objController).arlSampleModelAdd.Clear();
			((clsController_CheckGroup)this.objController).arlSampleModelRemove.Clear();
			((clsController_CheckGroup)this.objController).m_arlGroupSampleAdd.Clear();
			((clsController_CheckGroup)this.objController).m_arlGroupSampleRemove.Clear();
			((clsController_CheckGroup)this.objController).m_arlSampleModelRaw.Clear();
			((clsController_CheckGroup)this.objController).m_arlSameApplyUnitItem.Clear();
			this.m_trvAddSampleGroup.Nodes.Clear();
			this.m_lsvApplUnitItem.Items.Clear();
		}

		private void trvCheckGroup_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			//
//			((clsController_CheckGroup)this.objController).getCheckItemByGroupID(this,e.Node);
		}

		private void trvCheckGroup_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			((clsController_CheckGroup)this.objController).checkAllByParentChecked(this,e.Node);
		}

		#region 添加子组信息
		//添加子组信息
		private void btnNewSubGroup_Click(object sender, System.EventArgs e)
		{
			((clsController_CheckGroup)this.objController).AddAllCheckSubGroup(this);
		}
		#endregion

		#region 删除报告组子组信息
		private void btnDelSubGroup_Click(object sender, System.EventArgs e)
		{
			((clsController_CheckGroup)this.objController).DelAllCheckedSubGroup(this);
		}
		#endregion

//		private void btnAddSampleInfo_Click(object sender, System.EventArgs e)
//		{
////			if(this.txtSampleNum.Text == "")
//			{
//				MessageBox.Show("样品数量不能为空","样本信息",MessageBoxButtons.OK);
//				return;
//			}
//			if(this.txtSampleValidatTime.Text == "")
//			{
//				MessageBox.Show("样品有效时间不能为空","样本信息",MessageBoxButtons.OK);
//				return;
//			}
//			((clsController_CheckGroup)this.objController).AddSampleTypeInfo(this);
//		}

//		private void tbcCheckGroupDetail_SelectedIndexChanged(object sender, System.EventArgs e)
//		{
//			//获取属于该检验组的所有检验项目
//			if(tbcCheckGroupDetail.SelectedIndex == 3)
//			{
//				((clsController_CheckGroup)this.objController).GetAllCheckItemByCheckGroup(this);
//			}
//		}

		#region 删除
		private void btnDelCheckGroup_Click(object sender, System.EventArgs e)
		{
			DialogResult objReslut = MessageBox.Show("确认要删除该记录吗？","",MessageBoxButtons.OKCancel);
			long lngRes = 0;
			if(objReslut == DialogResult.OK)
			{
				lngRes = ((clsController_CheckGroup)this.objController).DelCheckGroup(this);
				if(lngRes > 0)
				{
//					MessageBox.Show("检验组删除成功！","",MessageBoxButtons.OK);
					ResetAll();
				}
				else
				{
					MessageBox.Show("检验组删除失败！","",MessageBoxButtons.OK);
				}
			}
		}
		#endregion

		#region 保存
		private void btnSaveCheckGroup_Click(object sender, System.EventArgs e)
		{
			long lngRes = 0;
			if(btnSaveCheckGroup.Text == "保存")
			{
				lngRes = ((clsController_CheckGroup)this.objController).AddNewCheckGroup(this);
				if(lngRes > 0)
				{
					MessageBox.Show("组合添加成功！");
				}
			}
			else if(btnSaveCheckGroup.Text == "修改")
			{
				lngRes = ((clsController_CheckGroup)this.objController).UpdCheckGroup(this);
				if(lngRes > 0)
				{
					MessageBox.Show("检验组修改成功！","",MessageBoxButtons.OK);
//					this.btnSaveCheckGroup.Text = "保存";
				}
			}
		}
		#endregion

		private void btnNewCheckGroup_Click(object sender, System.EventArgs e)
		{
			ResetAll();
			if(this.rdbBseGroup.Checked)
			{
				this.trvCheckGroup.SelectedNode = this.trvCheckGroup.Nodes[0];
			}
			else
			{
				this.trvCheckGroup.SelectedNode = this.trvCheckGroup.Nodes[1];
			}
			this.btnSaveCheckGroup.Text = "保存";
		}

//		private void btnDelOther_Click(object sender, System.EventArgs e)
//		{
////			((clsController_CheckGroup)this.objController).DelSampleTypeInfo(this);
//		}

		private void rdbBseGroup_CheckedChanged(object sender, System.EventArgs e)
		{
			if(rdbBseGroup.Checked)
			{
				this.gbBaseInfo.Enabled = true;
//				this.chkBodyCheck.Enabled = true;
//				this.chkNoFood.Enabled = true;
//				this.chkReservation.Enabled = true;
				this.rdbDeviceSample.Enabled = true;
				this.rdbManualSample.Enabled = true;
				this.txtSampleRemark.Enabled = true;
				this.cboDeviceModle.Enabled = true;
				this.cboPrintCategory.Enabled = false;
//				this.txtPrintTitle.Enabled = false;
				this.rdbDeviceSample.Checked = true;
				this.tbcCheckGroupDetail.Controls.Clear();
				this.tbcCheckGroupDetail.Controls.AddRange(new System.Windows.Forms.Control[] {
																								  this.m_tpSampleGroup});
//				cboCheckCategory_SelectedIndexChanged(null,null);
			}
		}

		private void rdbCheckGroup_CheckedChanged(object sender, System.EventArgs e)
		{
			if(rdbCheckGroup.Checked)
			{
//				this.gbBaseInfo.Enabled = false;
				this.gbBaseInfo.Enabled = false;
				this.cboPrintCategory.Enabled = true;
				this.txtPrintTitle.Enabled = true;
//				this.chkBodyCheck.Enabled = false;
//				this.chkNoFood.Enabled = false;
//				this.chkReservation.Enabled = false;
				this.rdbDeviceSample.Enabled = false;
				this.rdbManualSample.Enabled = false;
				this.txtSampleRemark.Enabled = false;
				this.cboDeviceModle.Enabled = false;
				this.tbcCheckGroupDetail.Controls.Clear();
				this.tbcCheckGroupDetail.Controls.AddRange(new System.Windows.Forms.Control[] {					
																								  this.tpSubGroup});
			}
		}

//		private void rdbSelfDefineGroup_CheckedChanged(object sender, System.EventArgs e)
//		{
//			if(rdbSelfDefineGroup.Checked)
//			{
//				gbBaseInfo.Enabled = false;
//				this.tbcCheckGroupDetail.Controls.Clear();
//				this.tbcCheckGroupDetail.Controls.AddRange(new System.Windows.Forms.Control[] {					
//																								  this.tpSubGroup});
//			}
//		}

		private void trvCheckGroup_AfterSelect_1(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			ResetAll();
			((clsController_CheckGroup)this.objController).m_mthTreeNodeSelectIndexChanged(this,e.Node);
		}

		private void trvAddSubGroup_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			((clsController_CheckGroup)this.objController).checkAllByParentChecked(this,e.Node);
		}

		private void trvAddSubGroup_AfterExpand(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			((clsController_CheckGroup)this.objController).getTrvAddSubGroupCheckItem(this,e.Node);
		}

//		private void cboSampleType_SelectedIndexChanged(object sender, System.EventArgs e)
//		{
//			if(this.cboCheckCategory.Items.Count > 0 && this.cboSampleType.Items.Count > 0)
//			{
//				((clsController_CheckGroup)this.objController).getAllCheckItemByCheckCategory(this);//,strCategoryID);//,out dtbCheckItemByCategory);
//			}
//		}

		private void btnUP_Click(object sender, System.EventArgs e)
		{
			if(this.lsvAddCheckItem.SelectedItems.Count > 0)
			{
				int index = this.lsvAddCheckItem.SelectedItems[0].Index;
				if(index > 0)
				{
					ListViewItem objTemplsvItem = new ListViewItem();
					objTemplsvItem.Text = this.lsvAddCheckItem.Items[index-1].SubItems[0].Text.ToString().Trim();
					objTemplsvItem.SubItems.Add(this.lsvAddCheckItem.Items[index-1].SubItems[1].Text.ToString().Trim());
					objTemplsvItem.SubItems.Add(this.lsvAddCheckItem.Items[index-1].SubItems[2].Text.ToString().Trim());
					objTemplsvItem.Tag = this.lsvAddCheckItem.Items[index-1].Tag;
					this.lsvAddCheckItem.Items[index-1].SubItems[0].Text = this.lsvAddCheckItem.Items[index].SubItems[0].Text;
					this.lsvAddCheckItem.Items[index-1].SubItems[1].Text = this.lsvAddCheckItem.Items[index].SubItems[1].Text;
					this.lsvAddCheckItem.Items[index-1].SubItems[2].Text = this.lsvAddCheckItem.Items[index].SubItems[2].Text;
					this.lsvAddCheckItem.Items[index-1].Tag = this.lsvAddCheckItem.Items[index].Tag;
					this.lsvAddCheckItem.Items[index].SubItems[0].Text = objTemplsvItem.SubItems[0].Text.ToString().Trim();
					this.lsvAddCheckItem.Items[index].SubItems[1].Text = objTemplsvItem.SubItems[1].Text.ToString().Trim();
					this.lsvAddCheckItem.Items[index].SubItems[2].Text = objTemplsvItem.SubItems[2].Text.ToString().Trim();
					this.lsvAddCheckItem.Items[index-1].Tag = objTemplsvItem.Tag;
					this.lsvAddCheckItem.Items[index-1].Selected = true;
				}
			}
		}

		private void btnDown_Click(object sender, System.EventArgs e)
		{
			if(this.lsvAddCheckItem.SelectedItems.Count > 0)
			{
				int index = this.lsvAddCheckItem.SelectedItems[0].Index;
				if(index < this.lsvAddCheckItem.Items.Count-1)
				{
					ListViewItem objTemplsvItem = new ListViewItem();
					objTemplsvItem.Text = this.lsvAddCheckItem.Items[index+1].SubItems[0].Text.ToString().Trim();
					objTemplsvItem.SubItems.Add(this.lsvAddCheckItem.Items[index+1].SubItems[1].Text.ToString().Trim());
					objTemplsvItem.SubItems.Add(this.lsvAddCheckItem.Items[index+1].SubItems[2].Text.ToString().Trim());
					objTemplsvItem.Tag = this.lsvAddCheckItem.Items[index+1].Tag;
					this.lsvAddCheckItem.Items[index+1].SubItems[0].Text = this.lsvAddCheckItem.Items[index].SubItems[0].Text;
					this.lsvAddCheckItem.Items[index+1].SubItems[1].Text = this.lsvAddCheckItem.Items[index].SubItems[1].Text;
					this.lsvAddCheckItem.Items[index+1].SubItems[2].Text = this.lsvAddCheckItem.Items[index].SubItems[2].Text;
					this.lsvAddCheckItem.Items[index+1].Tag = this.lsvAddCheckItem.Items[index].Tag;
					this.lsvAddCheckItem.Items[index].SubItems[0].Text = objTemplsvItem.SubItems[0].Text.ToString().Trim();
					this.lsvAddCheckItem.Items[index].SubItems[1].Text = objTemplsvItem.SubItems[1].Text.ToString().Trim();
					this.lsvAddCheckItem.Items[index].SubItems[2].Text = objTemplsvItem.SubItems[2].Text.ToString().Trim();
					this.lsvAddCheckItem.Items[index+1].Tag = objTemplsvItem.Tag;
					this.lsvAddCheckItem.Items[index+1].Selected = true;
				}
			}
		}

		private void rdbDeviceSample_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.rdbDeviceSample.Checked)
			{
				this.m_lsvDeviceModel.Enabled = true;
				this.cboDeviceModle.Enabled = true;
				this.m_lsvDeviceModel.Items.Clear();
				for(int i=0;i<((clsController_CheckGroup)this.objController).m_arlSampleModelRaw.Count;i++)
				{
					ListViewItem objlsvItem = new ListViewItem();
					objlsvItem.Text = 
						((clsLisSampleGroupModel_VO)((clsController_CheckGroup)this.objController).m_arlSampleModelRaw[i]).m_strDEVICE_MODEL_DESC_VCHR;
					objlsvItem.Tag = ((clsController_CheckGroup)this.objController).m_arlSampleModelRaw[i];
					this.m_lsvDeviceModel.Items.Add(objlsvItem);
				}
			}
		}

		private void rdbManualSample_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.rdbManualSample.Checked)
			{
				((clsController_CheckGroup)this.objController).arlSampleModelRemove.Clear();

				((clsController_CheckGroup)this.objController).arlSampleModelRemove = 
					(ArrayList)((clsController_CheckGroup)this.objController).m_arlSampleModelRaw.Clone();

				this.cboDeviceModle.Enabled = false;
				this.m_lsvDeviceModel.Items.Clear();
				this.m_lsvDeviceModel.Enabled = false;
			}
		}

		private void btnGroupUp_Click(object sender, System.EventArgs e)
		{
			if(this.trvAddSubGroup.SelectedNode != null && this.trvAddSubGroup.SelectedNode.Index > 0)
			{
				int index = this.trvAddSubGroup.SelectedNode.Index;
				TreeNode objTreeNode = new TreeNode();
				objTreeNode.Text = this.trvAddSubGroup.SelectedNode.Text;
				objTreeNode.Tag = this.trvAddSubGroup.SelectedNode.Tag;
				this.trvAddSubGroup.SelectedNode.Text = this.trvAddSubGroup.Nodes[index-1].Text;
				this.trvAddSubGroup.SelectedNode.Tag = this.trvAddSubGroup.Nodes[index-1].Tag;
				this.trvAddSubGroup.Nodes[index-1].Text = objTreeNode.Text;
				this.trvAddSubGroup.Nodes[index-1].Tag = objTreeNode.Tag;
				this.trvAddSubGroup.SelectedNode = this.trvAddSubGroup.Nodes[index-1];
			}
		}

		private void btnGroupDown_Click(object sender, System.EventArgs e)
		{
			if(this.trvAddSubGroup.SelectedNode != null && this.trvAddSubGroup.SelectedNode.Index<this.trvAddSubGroup.Nodes.Count-1)
			{
				int index = this.trvAddSubGroup.SelectedNode.Index;
				TreeNode objTreeNode = new TreeNode();
				objTreeNode.Text = this.trvAddSubGroup.SelectedNode.Text;
				objTreeNode.Tag = this.trvAddSubGroup.SelectedNode.Tag;
				this.trvAddSubGroup.SelectedNode.Text = this.trvAddSubGroup.Nodes[index+1].Text;
				this.trvAddSubGroup.SelectedNode.Tag = this.trvAddSubGroup.Nodes[index+1].Tag;
				this.trvAddSubGroup.Nodes[index+1].Text = objTreeNode.Text;
				this.trvAddSubGroup.Nodes[index+1].Tag = objTreeNode.Tag;
				this.trvAddSubGroup.SelectedNode = this.trvAddSubGroup.Nodes[index+1];
			}
		}

		#region 添加样本组仪器型号
		private void m_btnAddModel_Click(object sender, System.EventArgs e)
		{
			((clsController_CheckGroup)this.objController).m_mthAddSampleGroupModel();
		}
		#endregion

		#region 删除样本组仪器型号
		private void m_btnRemoveModel_Click(object sender, System.EventArgs e)
		{
			((clsController_CheckGroup)this.objController).m_mthDelSampleGroupModel();
		}
		#endregion

		#region 添加样本组样本类型
		private void m_btnGroupSampleAdd_Click(object sender, System.EventArgs e)
		{
			((clsController_CheckGroup)this.objController).m_mthAddGroupSampleType();
		}
		#endregion

		#region 删除样本组样本类型
		private void m_btnGroupSampleRemove_Click(object sender, System.EventArgs e)
		{
			((clsController_CheckGroup)this.objController).m_mthRemoveGroupSampleType();
		}
		#endregion

		#region 添加申请单元
		private void m_btnAddApplUnit_Click(object sender, System.EventArgs e)
		{
			((clsController_CheckGroup)this.objController).m_mthAddApplUnit();
		}
		#endregion

		#region 删除申请单元
		private void m_btnRemoveApplUnit_Click(object sender, System.EventArgs e)
		{
			((clsController_CheckGroup)this.objController).m_mthRemoveApplUnit();
		}
		#endregion

		#region 向上调整标本组检验项目的打印顺序
		private void m_btnUpApplItem_Click(object sender, System.EventArgs e)
		{
			if(this.m_lsvApplUnitItem.SelectedItems.Count > 0)
			{
				int index = this.m_lsvApplUnitItem.SelectedItems[0].Index;
				if(index > 0)
				{
					ListViewItem objTemplsvItem = new ListViewItem();
					objTemplsvItem.Text = this.m_lsvApplUnitItem.Items[index-1].SubItems[0].Text.ToString().Trim();
					objTemplsvItem.SubItems.Add(this.m_lsvApplUnitItem.Items[index-1].SubItems[1].Text.ToString().Trim());
					objTemplsvItem.SubItems.Add(this.m_lsvApplUnitItem.Items[index-1].SubItems[2].Text.ToString().Trim());
					objTemplsvItem.Tag = this.m_lsvApplUnitItem.Items[index-1].Tag;
					this.m_lsvApplUnitItem.Items[index-1].SubItems[0].Text = this.m_lsvApplUnitItem.Items[index].SubItems[0].Text;
					this.m_lsvApplUnitItem.Items[index-1].SubItems[1].Text = this.m_lsvApplUnitItem.Items[index].SubItems[1].Text;
					this.m_lsvApplUnitItem.Items[index-1].SubItems[2].Text = this.m_lsvApplUnitItem.Items[index].SubItems[2].Text;
					this.m_lsvApplUnitItem.Items[index-1].Tag = this.m_lsvApplUnitItem.Items[index].Tag;
					this.m_lsvApplUnitItem.Items[index].SubItems[0].Text = objTemplsvItem.SubItems[0].Text.ToString().Trim();
					this.m_lsvApplUnitItem.Items[index].SubItems[1].Text = objTemplsvItem.SubItems[1].Text.ToString().Trim();
					this.m_lsvApplUnitItem.Items[index].SubItems[2].Text = objTemplsvItem.SubItems[2].Text.ToString().Trim();
					this.m_lsvApplUnitItem.Items[index].Tag = objTemplsvItem.Tag;
					this.m_lsvApplUnitItem.Items[index-1].Selected = true;
					this.m_lsvApplUnitItem.SelectedItems[0].EnsureVisible();
				}
			}
		}
		#endregion

		#region 向下调整标本组检验项目的打印顺序
		private void m_btnDownApplItem_Click(object sender, System.EventArgs e)
		{
			if(this.m_lsvApplUnitItem.SelectedItems.Count > 0)
			{
				int index = this.m_lsvApplUnitItem.SelectedItems[0].Index;
				if(index < this.m_lsvApplUnitItem.Items.Count-1)
				{
					ListViewItem objTemplsvItem = new ListViewItem();
					objTemplsvItem.Text = this.m_lsvApplUnitItem.Items[index+1].SubItems[0].Text.ToString().Trim();
					objTemplsvItem.SubItems.Add(this.m_lsvApplUnitItem.Items[index+1].SubItems[1].Text.ToString().Trim());
					objTemplsvItem.SubItems.Add(this.m_lsvApplUnitItem.Items[index+1].SubItems[2].Text.ToString().Trim());
					objTemplsvItem.Tag = this.m_lsvApplUnitItem.Items[index+1].Tag;
					this.m_lsvApplUnitItem.Items[index+1].SubItems[0].Text = this.m_lsvApplUnitItem.Items[index].SubItems[0].Text;
					this.m_lsvApplUnitItem.Items[index+1].SubItems[1].Text = this.m_lsvApplUnitItem.Items[index].SubItems[1].Text;
					this.m_lsvApplUnitItem.Items[index+1].SubItems[2].Text = this.m_lsvApplUnitItem.Items[index].SubItems[2].Text;
					this.m_lsvApplUnitItem.Items[index+1].Tag = this.m_lsvApplUnitItem.Items[index].Tag;
					this.m_lsvApplUnitItem.Items[index].SubItems[0].Text = objTemplsvItem.SubItems[0].Text.ToString().Trim();
					this.m_lsvApplUnitItem.Items[index].SubItems[1].Text = objTemplsvItem.SubItems[1].Text.ToString().Trim();
					this.m_lsvApplUnitItem.Items[index].SubItems[2].Text = objTemplsvItem.SubItems[2].Text.ToString().Trim();
					this.m_lsvApplUnitItem.Items[index].Tag = objTemplsvItem.Tag;
					this.m_lsvApplUnitItem.Items[index+1].Selected = true;
					this.m_lsvApplUnitItem.SelectedItems[0].EnsureVisible();
				}
			}
		}
		#endregion

		#region 选中申请单元下的所有节点
		private void m_trvApplUnit_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			((clsController_CheckGroup)this.objController).checkAllByParentChecked(this,e.Node);
		}
		#endregion

		#region 根据检验类别获取相应的申请单元
		private void cboCheckCategory_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			((clsController_CheckGroup)this.objController).m_mthGetApplUnitByCheckCategory();
		}
		#endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

	}
}
