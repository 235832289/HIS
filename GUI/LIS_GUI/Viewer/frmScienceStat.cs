using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.LIS
{
	public class frmScienceStat : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		clsController_ScienceStat m_objController;
		#region Controls
		private System.Windows.Forms.Label m_lbCheckCategory;
		internal System.Windows.Forms.ComboBox m_cboCheckCategory;
		private System.Windows.Forms.Label m_lbCheckItem;
		internal System.Windows.Forms.ComboBox m_cboCheckItem;
		private System.Windows.Forms.Label m_lbDat;
		internal System.Windows.Forms.DateTimePicker m_dtpDatFrom;
		internal System.Windows.Forms.DateTimePicker m_dtpDatTo;
		private System.Windows.Forms.GroupBox m_gpbQueryCondition;
		internal System.Windows.Forms.ListView m_lsvItemDetail;
		private System.Windows.Forms.ColumnHeader m_chCheckResult;
		private System.Windows.Forms.ColumnHeader m_chCheckDat;
		private System.Windows.Forms.ColumnHeader m_chAge;
		private System.Windows.Forms.ColumnHeader m_chPatientName;
		private System.Windows.Forms.ColumnHeader m_chSampleNO;
		private System.Windows.Forms.ColumnHeader m_chSex;
		private System.Windows.Forms.Label m_lbCheckResult;
		internal System.Windows.Forms.TextBox m_txtResultTo;
		internal PinkieControls.ButtonXP m_btnQuery;
		private System.Windows.Forms.Label m_lbDatTo;
		internal System.Windows.Forms.TextBox m_txtResultFrom;
		internal System.Windows.Forms.ComboBox m_cboLowCompare;
		internal System.Windows.Forms.ComboBox m_cboUpCompare;
		private System.Windows.Forms.Label m_lbSex;
		internal System.Windows.Forms.ComboBox m_cboSex;
		private System.Windows.Forms.Label m_lbAge;
		internal System.Windows.Forms.TextBox m_txtAgeFrom;
		private System.Windows.Forms.Label m_lbAgeTo;
		internal System.Windows.Forms.TextBox m_txtAgeTo;
		internal System.Windows.Forms.ComboBox m_cboCondition;
		internal System.Windows.Forms.ComboBox m_cboFromAgeUnit;
		internal System.Windows.Forms.ComboBox m_cboToAgeUnit;
		internal CrystalDecisions.Windows.Forms.CrystalReportViewer m_ReportViewer;
		internal System.Windows.Forms.ListView m_lsvItemList;
		private System.Windows.Forms.ColumnHeader m_checkItem;
		internal PinkieControls.ButtonXP m_btnRemoveCondition;
		internal PinkieControls.ButtonXP m_btnAddCondition;
		private System.Windows.Forms.ColumnHeader m_chCondition;
        private PinkieControls.ButtonXP btnExit;
		private System.ComponentModel.IContainer components = null;
		#endregion

		#region Inital
		public frmScienceStat()
		{
			// 该调用是 Windows 窗体设计器所必需的。
			InitializeComponent();

			// TODO: 在 InitializeComponent 调用后添加任何初始化
		}

		/// <summary>
		/// 清理所有正在使用的资源。
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
		#endregion

		#region 设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.m_lbCheckCategory = new System.Windows.Forms.Label();
            this.m_cboCheckCategory = new System.Windows.Forms.ComboBox();
            this.m_lbCheckItem = new System.Windows.Forms.Label();
            this.m_cboCheckItem = new System.Windows.Forms.ComboBox();
            this.m_lbDat = new System.Windows.Forms.Label();
            this.m_dtpDatFrom = new System.Windows.Forms.DateTimePicker();
            this.m_lbDatTo = new System.Windows.Forms.Label();
            this.m_dtpDatTo = new System.Windows.Forms.DateTimePicker();
            this.m_gpbQueryCondition = new System.Windows.Forms.GroupBox();
            this.btnExit = new PinkieControls.ButtonXP();
            this.m_btnAddCondition = new PinkieControls.ButtonXP();
            this.m_btnRemoveCondition = new PinkieControls.ButtonXP();
            this.m_lsvItemList = new System.Windows.Forms.ListView();
            this.m_checkItem = new System.Windows.Forms.ColumnHeader();
            this.m_chCondition = new System.Windows.Forms.ColumnHeader();
            this.m_cboToAgeUnit = new System.Windows.Forms.ComboBox();
            this.m_cboFromAgeUnit = new System.Windows.Forms.ComboBox();
            this.m_txtAgeTo = new System.Windows.Forms.TextBox();
            this.m_lbAgeTo = new System.Windows.Forms.Label();
            this.m_txtAgeFrom = new System.Windows.Forms.TextBox();
            this.m_lbAge = new System.Windows.Forms.Label();
            this.m_cboSex = new System.Windows.Forms.ComboBox();
            this.m_lbSex = new System.Windows.Forms.Label();
            this.m_cboCondition = new System.Windows.Forms.ComboBox();
            this.m_cboUpCompare = new System.Windows.Forms.ComboBox();
            this.m_cboLowCompare = new System.Windows.Forms.ComboBox();
            this.m_txtResultTo = new System.Windows.Forms.TextBox();
            this.m_txtResultFrom = new System.Windows.Forms.TextBox();
            this.m_lbCheckResult = new System.Windows.Forms.Label();
            this.m_btnQuery = new PinkieControls.ButtonXP();
            this.m_lsvItemDetail = new System.Windows.Forms.ListView();
            this.m_chCheckResult = new System.Windows.Forms.ColumnHeader();
            this.m_chCheckDat = new System.Windows.Forms.ColumnHeader();
            this.m_chSampleNO = new System.Windows.Forms.ColumnHeader();
            this.m_chPatientName = new System.Windows.Forms.ColumnHeader();
            this.m_chSex = new System.Windows.Forms.ColumnHeader();
            this.m_chAge = new System.Windows.Forms.ColumnHeader();
            this.m_ReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.m_gpbQueryCondition.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_lbCheckCategory
            // 
            this.m_lbCheckCategory.AutoSize = true;
            this.m_lbCheckCategory.Location = new System.Drawing.Point(12, 20);
            this.m_lbCheckCategory.Name = "m_lbCheckCategory";
            this.m_lbCheckCategory.Size = new System.Drawing.Size(63, 14);
            this.m_lbCheckCategory.TabIndex = 0;
            this.m_lbCheckCategory.Text = "检验类别";
            // 
            // m_cboCheckCategory
            // 
            this.m_cboCheckCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboCheckCategory.Location = new System.Drawing.Point(76, 16);
            this.m_cboCheckCategory.Name = "m_cboCheckCategory";
            this.m_cboCheckCategory.Size = new System.Drawing.Size(144, 22);
            this.m_cboCheckCategory.TabIndex = 1;
            this.m_cboCheckCategory.SelectedIndexChanged += new System.EventHandler(this.m_cboCheckCategory_SelectedIndexChanged);
            // 
            // m_lbCheckItem
            // 
            this.m_lbCheckItem.AutoSize = true;
            this.m_lbCheckItem.Location = new System.Drawing.Point(12, 44);
            this.m_lbCheckItem.Name = "m_lbCheckItem";
            this.m_lbCheckItem.Size = new System.Drawing.Size(63, 14);
            this.m_lbCheckItem.TabIndex = 2;
            this.m_lbCheckItem.Text = "检验项目";
            // 
            // m_cboCheckItem
            // 
            this.m_cboCheckItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboCheckItem.Location = new System.Drawing.Point(76, 40);
            this.m_cboCheckItem.Name = "m_cboCheckItem";
            this.m_cboCheckItem.Size = new System.Drawing.Size(144, 22);
            this.m_cboCheckItem.TabIndex = 3;
            // 
            // m_lbDat
            // 
            this.m_lbDat.AutoSize = true;
            this.m_lbDat.Location = new System.Drawing.Point(220, 44);
            this.m_lbDat.Name = "m_lbDat";
            this.m_lbDat.Size = new System.Drawing.Size(63, 14);
            this.m_lbDat.TabIndex = 4;
            this.m_lbDat.Text = "日期范围";
            // 
            // m_dtpDatFrom
            // 
            this.m_dtpDatFrom.Location = new System.Drawing.Point(284, 40);
            this.m_dtpDatFrom.Name = "m_dtpDatFrom";
            this.m_dtpDatFrom.Size = new System.Drawing.Size(120, 23);
            this.m_dtpDatFrom.TabIndex = 5;
            // 
            // m_lbDatTo
            // 
            this.m_lbDatTo.AutoSize = true;
            this.m_lbDatTo.Location = new System.Drawing.Point(408, 44);
            this.m_lbDatTo.Name = "m_lbDatTo";
            this.m_lbDatTo.Size = new System.Drawing.Size(21, 14);
            this.m_lbDatTo.TabIndex = 6;
            this.m_lbDatTo.Text = "至";
            // 
            // m_dtpDatTo
            // 
            this.m_dtpDatTo.Location = new System.Drawing.Point(432, 40);
            this.m_dtpDatTo.Name = "m_dtpDatTo";
            this.m_dtpDatTo.Size = new System.Drawing.Size(120, 23);
            this.m_dtpDatTo.TabIndex = 7;
            // 
            // m_gpbQueryCondition
            // 
            this.m_gpbQueryCondition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_gpbQueryCondition.Controls.Add(this.btnExit);
            this.m_gpbQueryCondition.Controls.Add(this.m_btnAddCondition);
            this.m_gpbQueryCondition.Controls.Add(this.m_btnRemoveCondition);
            this.m_gpbQueryCondition.Controls.Add(this.m_lsvItemList);
            this.m_gpbQueryCondition.Controls.Add(this.m_cboToAgeUnit);
            this.m_gpbQueryCondition.Controls.Add(this.m_cboFromAgeUnit);
            this.m_gpbQueryCondition.Controls.Add(this.m_txtAgeTo);
            this.m_gpbQueryCondition.Controls.Add(this.m_lbAgeTo);
            this.m_gpbQueryCondition.Controls.Add(this.m_txtAgeFrom);
            this.m_gpbQueryCondition.Controls.Add(this.m_lbAge);
            this.m_gpbQueryCondition.Controls.Add(this.m_cboSex);
            this.m_gpbQueryCondition.Controls.Add(this.m_lbSex);
            this.m_gpbQueryCondition.Controls.Add(this.m_cboCondition);
            this.m_gpbQueryCondition.Controls.Add(this.m_cboUpCompare);
            this.m_gpbQueryCondition.Controls.Add(this.m_cboLowCompare);
            this.m_gpbQueryCondition.Controls.Add(this.m_txtResultTo);
            this.m_gpbQueryCondition.Controls.Add(this.m_txtResultFrom);
            this.m_gpbQueryCondition.Controls.Add(this.m_lbCheckResult);
            this.m_gpbQueryCondition.Controls.Add(this.m_cboCheckCategory);
            this.m_gpbQueryCondition.Controls.Add(this.m_lbCheckCategory);
            this.m_gpbQueryCondition.Controls.Add(this.m_lbCheckItem);
            this.m_gpbQueryCondition.Controls.Add(this.m_cboCheckItem);
            this.m_gpbQueryCondition.Controls.Add(this.m_dtpDatFrom);
            this.m_gpbQueryCondition.Controls.Add(this.m_dtpDatTo);
            this.m_gpbQueryCondition.Controls.Add(this.m_lbDatTo);
            this.m_gpbQueryCondition.Controls.Add(this.m_lbDat);
            this.m_gpbQueryCondition.Controls.Add(this.m_btnQuery);
            this.m_gpbQueryCondition.Location = new System.Drawing.Point(0, 0);
            this.m_gpbQueryCondition.Name = "m_gpbQueryCondition";
            this.m_gpbQueryCondition.Size = new System.Drawing.Size(936, 96);
            this.m_gpbQueryCondition.TabIndex = 8;
            this.m_gpbQueryCondition.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnExit.DefaultScheme = true;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExit.Hint = "";
            this.btnExit.Location = new System.Drawing.Point(850, 50);
            this.btnExit.Name = "btnExit";
            this.btnExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnExit.Size = new System.Drawing.Size(80, 32);
            this.btnExit.TabIndex = 26;
            this.btnExit.Text = "关闭";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // m_btnAddCondition
            // 
            this.m_btnAddCondition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnAddCondition.DefaultScheme = true;
            this.m_btnAddCondition.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnAddCondition.Hint = "";
            this.m_btnAddCondition.Location = new System.Drawing.Point(560, 64);
            this.m_btnAddCondition.Name = "m_btnAddCondition";
            this.m_btnAddCondition.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnAddCondition.Size = new System.Drawing.Size(92, 24);
            this.m_btnAddCondition.TabIndex = 25;
            this.m_btnAddCondition.Text = "－>";
            this.m_btnAddCondition.Click += new System.EventHandler(this.m_btnAddCondition_Click);
            // 
            // m_btnRemoveCondition
            // 
            this.m_btnRemoveCondition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnRemoveCondition.DefaultScheme = true;
            this.m_btnRemoveCondition.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnRemoveCondition.Hint = "";
            this.m_btnRemoveCondition.Location = new System.Drawing.Point(560, 40);
            this.m_btnRemoveCondition.Name = "m_btnRemoveCondition";
            this.m_btnRemoveCondition.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnRemoveCondition.Size = new System.Drawing.Size(92, 24);
            this.m_btnRemoveCondition.TabIndex = 24;
            this.m_btnRemoveCondition.Text = "<－";
            this.m_btnRemoveCondition.Click += new System.EventHandler(this.m_btnRemoveCondition_Click);
            // 
            // m_lsvItemList
            // 
            this.m_lsvItemList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lsvItemList.CheckBoxes = true;
            this.m_lsvItemList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_checkItem,
            this.m_chCondition});
            this.m_lsvItemList.FullRowSelect = true;
            this.m_lsvItemList.GridLines = true;
            this.m_lsvItemList.HoverSelection = true;
            this.m_lsvItemList.Location = new System.Drawing.Point(660, 14);
            this.m_lsvItemList.Name = "m_lsvItemList";
            this.m_lsvItemList.Size = new System.Drawing.Size(184, 76);
            this.m_lsvItemList.TabIndex = 23;
            this.m_lsvItemList.UseCompatibleStateImageBehavior = false;
            this.m_lsvItemList.View = System.Windows.Forms.View.Details;
            // 
            // m_checkItem
            // 
            this.m_checkItem.Text = "检验项目";
            this.m_checkItem.Width = 130;
            // 
            // m_chCondition
            // 
            this.m_chCondition.Text = "查询条件";
            this.m_chCondition.Width = 100;
            // 
            // m_cboToAgeUnit
            // 
            this.m_cboToAgeUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboToAgeUnit.Items.AddRange(new object[] {
            "岁",
            "月",
            "天",
            "小时"});
            this.m_cboToAgeUnit.Location = new System.Drawing.Point(496, 16);
            this.m_cboToAgeUnit.Name = "m_cboToAgeUnit";
            this.m_cboToAgeUnit.Size = new System.Drawing.Size(56, 22);
            this.m_cboToAgeUnit.TabIndex = 22;
            // 
            // m_cboFromAgeUnit
            // 
            this.m_cboFromAgeUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboFromAgeUnit.Items.AddRange(new object[] {
            "岁",
            "月",
            "天",
            "小时"});
            this.m_cboFromAgeUnit.Location = new System.Drawing.Point(348, 16);
            this.m_cboFromAgeUnit.Name = "m_cboFromAgeUnit";
            this.m_cboFromAgeUnit.Size = new System.Drawing.Size(56, 22);
            this.m_cboFromAgeUnit.TabIndex = 21;
            // 
            // m_txtAgeTo
            // 
            this.m_txtAgeTo.Location = new System.Drawing.Point(432, 16);
            this.m_txtAgeTo.Name = "m_txtAgeTo";
            this.m_txtAgeTo.Size = new System.Drawing.Size(64, 23);
            this.m_txtAgeTo.TabIndex = 20;
            // 
            // m_lbAgeTo
            // 
            this.m_lbAgeTo.AutoSize = true;
            this.m_lbAgeTo.Location = new System.Drawing.Point(408, 20);
            this.m_lbAgeTo.Name = "m_lbAgeTo";
            this.m_lbAgeTo.Size = new System.Drawing.Size(21, 14);
            this.m_lbAgeTo.TabIndex = 19;
            this.m_lbAgeTo.Text = "至";
            // 
            // m_txtAgeFrom
            // 
            this.m_txtAgeFrom.Location = new System.Drawing.Point(284, 16);
            this.m_txtAgeFrom.Name = "m_txtAgeFrom";
            this.m_txtAgeFrom.Size = new System.Drawing.Size(64, 23);
            this.m_txtAgeFrom.TabIndex = 18;
            // 
            // m_lbAge
            // 
            this.m_lbAge.AutoSize = true;
            this.m_lbAge.Location = new System.Drawing.Point(244, 20);
            this.m_lbAge.Name = "m_lbAge";
            this.m_lbAge.Size = new System.Drawing.Size(35, 14);
            this.m_lbAge.TabIndex = 17;
            this.m_lbAge.Text = "年龄";
            // 
            // m_cboSex
            // 
            this.m_cboSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboSex.Items.AddRange(new object[] {
            "",
            "男",
            "女"});
            this.m_cboSex.Location = new System.Drawing.Point(592, 16);
            this.m_cboSex.Name = "m_cboSex";
            this.m_cboSex.Size = new System.Drawing.Size(64, 22);
            this.m_cboSex.TabIndex = 16;
            // 
            // m_lbSex
            // 
            this.m_lbSex.AutoSize = true;
            this.m_lbSex.Location = new System.Drawing.Point(556, 24);
            this.m_lbSex.Name = "m_lbSex";
            this.m_lbSex.Size = new System.Drawing.Size(35, 14);
            this.m_lbSex.TabIndex = 15;
            this.m_lbSex.Text = "性别";
            // 
            // m_cboCondition
            // 
            this.m_cboCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboCondition.Items.AddRange(new object[] {
            "与",
            "或"});
            this.m_cboCondition.Location = new System.Drawing.Point(284, 64);
            this.m_cboCondition.Name = "m_cboCondition";
            this.m_cboCondition.Size = new System.Drawing.Size(64, 22);
            this.m_cboCondition.TabIndex = 14;
            // 
            // m_cboUpCompare
            // 
            this.m_cboUpCompare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboUpCompare.Items.AddRange(new object[] {
            "<",
            "<="});
            this.m_cboUpCompare.Location = new System.Drawing.Point(348, 64);
            this.m_cboUpCompare.Name = "m_cboUpCompare";
            this.m_cboUpCompare.Size = new System.Drawing.Size(56, 22);
            this.m_cboUpCompare.TabIndex = 13;
            // 
            // m_cboLowCompare
            // 
            this.m_cboLowCompare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboLowCompare.Items.AddRange(new object[] {
            ">",
            ">=",
            "=",
            "<>",
            "在",
            "不在"});
            this.m_cboLowCompare.Location = new System.Drawing.Point(76, 64);
            this.m_cboLowCompare.Name = "m_cboLowCompare";
            this.m_cboLowCompare.Size = new System.Drawing.Size(76, 22);
            this.m_cboLowCompare.TabIndex = 12;
            this.m_cboLowCompare.SelectedIndexChanged += new System.EventHandler(this.m_cboLowCompare_SelectedIndexChanged);
            // 
            // m_txtResultTo
            // 
            this.m_txtResultTo.Location = new System.Drawing.Point(404, 64);
            this.m_txtResultTo.Name = "m_txtResultTo";
            this.m_txtResultTo.Size = new System.Drawing.Size(148, 23);
            this.m_txtResultTo.TabIndex = 11;
            // 
            // m_txtResultFrom
            // 
            this.m_txtResultFrom.Location = new System.Drawing.Point(152, 64);
            this.m_txtResultFrom.Name = "m_txtResultFrom";
            this.m_txtResultFrom.Size = new System.Drawing.Size(132, 23);
            this.m_txtResultFrom.TabIndex = 9;
            // 
            // m_lbCheckResult
            // 
            this.m_lbCheckResult.AutoSize = true;
            this.m_lbCheckResult.Location = new System.Drawing.Point(12, 68);
            this.m_lbCheckResult.Name = "m_lbCheckResult";
            this.m_lbCheckResult.Size = new System.Drawing.Size(63, 14);
            this.m_lbCheckResult.TabIndex = 8;
            this.m_lbCheckResult.Text = "检验结果";
            // 
            // m_btnQuery
            // 
            this.m_btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnQuery.DefaultScheme = true;
            this.m_btnQuery.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnQuery.Hint = "";
            this.m_btnQuery.Location = new System.Drawing.Point(850, 15);
            this.m_btnQuery.Name = "m_btnQuery";
            this.m_btnQuery.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnQuery.Size = new System.Drawing.Size(80, 32);
            this.m_btnQuery.TabIndex = 10;
            this.m_btnQuery.Text = "查询";
            this.m_btnQuery.Click += new System.EventHandler(this.m_btnQuery_Click);
            // 
            // m_lsvItemDetail
            // 
            this.m_lsvItemDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lsvItemDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_chCheckResult,
            this.m_chCheckDat,
            this.m_chSampleNO,
            this.m_chPatientName,
            this.m_chSex,
            this.m_chAge});
            this.m_lsvItemDetail.FullRowSelect = true;
            this.m_lsvItemDetail.GridLines = true;
            this.m_lsvItemDetail.HideSelection = false;
            this.m_lsvItemDetail.Location = new System.Drawing.Point(4, 100);
            this.m_lsvItemDetail.Name = "m_lsvItemDetail";
            this.m_lsvItemDetail.Size = new System.Drawing.Size(928, 44);
            this.m_lsvItemDetail.TabIndex = 9;
            this.m_lsvItemDetail.UseCompatibleStateImageBehavior = false;
            this.m_lsvItemDetail.View = System.Windows.Forms.View.Details;
            // 
            // m_chCheckResult
            // 
            this.m_chCheckResult.Text = "检验结果";
            this.m_chCheckResult.Width = 100;
            // 
            // m_chCheckDat
            // 
            this.m_chCheckDat.Text = "检验日期";
            this.m_chCheckDat.Width = 130;
            // 
            // m_chSampleNO
            // 
            this.m_chSampleNO.Text = "标本号";
            this.m_chSampleNO.Width = 89;
            // 
            // m_chPatientName
            // 
            this.m_chPatientName.Text = "病人姓名";
            this.m_chPatientName.Width = 92;
            // 
            // m_chSex
            // 
            this.m_chSex.Text = "性别";
            this.m_chSex.Width = 63;
            // 
            // m_chAge
            // 
            this.m_chAge.Text = "年龄";
            this.m_chAge.Width = 71;
            // 
            // m_ReportViewer
            // 
            this.m_ReportViewer.ActiveViewIndex = -1;
            this.m_ReportViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_ReportViewer.DisplayGroupTree = false;
            this.m_ReportViewer.Location = new System.Drawing.Point(0, 100);
            this.m_ReportViewer.Name = "m_ReportViewer";
            this.m_ReportViewer.SelectionFormula = "";
            this.m_ReportViewer.ShowGroupTreeButton = false;
            this.m_ReportViewer.ShowRefreshButton = false;
            this.m_ReportViewer.Size = new System.Drawing.Size(936, 436);
            this.m_ReportViewer.TabIndex = 10;
            this.m_ReportViewer.ViewTimeSelectionFormula = "";
            // 
            // frmScienceStat
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(936, 537);
            this.Controls.Add(this.m_ReportViewer);
            this.Controls.Add(this.m_lsvItemDetail);
            this.Controls.Add(this.m_gpbQueryCondition);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmScienceStat";
            this.Text = "学术统计";
            this.Load += new System.EventHandler(this.frmScienceStat_Load);
            this.m_gpbQueryCondition.ResumeLayout(false);
            this.m_gpbQueryCondition.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		#region CreateController
		public override void CreateController()
		{
			m_objController = new clsController_ScienceStat();
			this.objController = m_objController;
			m_objController.Set_GUI_Apperance(this);
		}
		#endregion

		#region ViewerInital
		private void frmScienceStat_Load(object sender, System.EventArgs e)
		{
			m_objController.m_mthInitalViewer();
		}
		#endregion

		#region 根据条件查询学术统计信息
		private void m_btnQuery_Click(object sender, System.EventArgs e)
		{
			m_objController.m_mthQueryScienceStatInfo();
		}
		#endregion

		#region 根据检验类别获取对应的检验项目
		private void m_cboCheckCategory_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_objController.m_mthGetCheckItemByCheckCategory();
		}
		#endregion

		#region Event
		private void m_cboLowCompare_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.m_cboLowCompare.Text == "=" || this.m_cboLowCompare.Text == "<>" ||
				this.m_cboLowCompare.Text == "在" || this.m_cboLowCompare.Text == "不在")
			{
				this.m_cboCondition.Visible = false;
				this.m_cboUpCompare.Visible = false;
				this.m_txtResultTo.Clear();
				this.m_txtResultTo.Visible = false;
			}
			else
			{
				this.m_cboCondition.Visible = true;
				this.m_cboUpCompare.Visible = true;
				this.m_txtResultTo.Visible = true;
			}
		}
		#endregion

		#region 添加查询检验项目的条件
		private void m_btnAddCondition_Click(object sender, System.EventArgs e)
		{
			m_objController.m_mthAddCheckItemCondition();
		}
		#endregion

		#region 移除查询检验项目的条件
		private void m_btnRemoveCondition_Click(object sender, System.EventArgs e)
		{
			m_objController.m_mthRemoveCheckItemCondition();
		}
		#endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
	}
}

