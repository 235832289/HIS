using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using com.digitalwave.Utility;
using com.digitalwave.iCare.common;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.LIS
{
	/// <summary>
	/// 样本信息维护界面
	/// </summary>
	public class frmSampleInfo : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{

        #region 控件申明
		
		private System.Windows.Forms.TabPage tpSampleType;
		private System.Windows.Forms.TabPage tpSampleCharacter;
		private System.Windows.Forms.ListView lsvSampleType;
		private System.Windows.Forms.ColumnHeader chSampleTypeID;
		private System.Windows.Forms.ColumnHeader chSampleType;
		private System.Windows.Forms.ColumnHeader chPyCode;
		private System.Windows.Forms.ColumnHeader chWbCode;
		private System.Windows.Forms.TextBox txtWbCode;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtPyCode;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lbSampleType;
		private System.Windows.Forms.TextBox txtSampleType;
		private System.Windows.Forms.Button btnNewSampleType;
		private System.Windows.Forms.Button btnDelSampleType;
		private System.Windows.Forms.Button btnSaveSampleType;
		private System.Windows.Forms.ListView lsvSampleCharacter;
		private System.Windows.Forms.ColumnHeader chSEQ;
		private System.Windows.Forms.ColumnHeader chCharacter;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtSampleCharacter;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox cboSampleType;
		private System.Windows.Forms.TabControl tbcSampleType;
		private System.Data.DataTable dtbAllSampleType = null;
		private System.Data.DataTable dtbAllSampleCharacter = null;
		private System.Windows.Forms.Button btnDelSampleCharacter;
		private System.Windows.Forms.Button btnSaveSampleCharacter;
		private System.Windows.Forms.Button btnNewSampleCharacter;
		private System.Windows.Forms.TextBox txtSampleCharacterWBCode;
		private System.Windows.Forms.TextBox txtSampleCharacterPYCode;
		private System.Windows.Forms.GroupBox gbSampleTypeInfo;
		private System.Windows.Forms.GroupBox gbSampleCharacter;
        private ColumnHeader columnHeader3;
        private Label label7;
        private ComboBox m_cboHasBarCode;
        private Button btnExit0;
        private Button btnExit1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null; 
	#endregion

        #region 系统生成
		
		public frmSampleInfo()
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
            this.tbcSampleType = new System.Windows.Forms.TabControl();
            this.tpSampleType = new System.Windows.Forms.TabPage();
            this.btnExit0 = new System.Windows.Forms.Button();
            this.btnNewSampleType = new System.Windows.Forms.Button();
            this.btnDelSampleType = new System.Windows.Forms.Button();
            this.btnSaveSampleType = new System.Windows.Forms.Button();
            this.lsvSampleType = new System.Windows.Forms.ListView();
            this.chSampleTypeID = new System.Windows.Forms.ColumnHeader();
            this.chSampleType = new System.Windows.Forms.ColumnHeader();
            this.chPyCode = new System.Windows.Forms.ColumnHeader();
            this.chWbCode = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.gbSampleTypeInfo = new System.Windows.Forms.GroupBox();
            this.m_cboHasBarCode = new System.Windows.Forms.ComboBox();
            this.txtWbCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPyCode = new System.Windows.Forms.TextBox();
            this.txtSampleType = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lbSampleType = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tpSampleCharacter = new System.Windows.Forms.TabPage();
            this.btnExit1 = new System.Windows.Forms.Button();
            this.btnDelSampleCharacter = new System.Windows.Forms.Button();
            this.btnSaveSampleCharacter = new System.Windows.Forms.Button();
            this.btnNewSampleCharacter = new System.Windows.Forms.Button();
            this.lsvSampleCharacter = new System.Windows.Forms.ListView();
            this.chSEQ = new System.Windows.Forms.ColumnHeader();
            this.chCharacter = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.gbSampleCharacter = new System.Windows.Forms.GroupBox();
            this.txtSampleCharacterWBCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSampleCharacterPYCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSampleCharacter = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboSampleType = new System.Windows.Forms.ComboBox();
            this.tbcSampleType.SuspendLayout();
            this.tpSampleType.SuspendLayout();
            this.gbSampleTypeInfo.SuspendLayout();
            this.tpSampleCharacter.SuspendLayout();
            this.gbSampleCharacter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcSampleType
            // 
            this.tbcSampleType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcSampleType.Controls.Add(this.tpSampleType);
            this.tbcSampleType.Controls.Add(this.tpSampleCharacter);
            this.tbcSampleType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbcSampleType.Location = new System.Drawing.Point(16, 16);
            this.tbcSampleType.Name = "tbcSampleType";
            this.tbcSampleType.SelectedIndex = 0;
            this.tbcSampleType.Size = new System.Drawing.Size(839, 432);
            this.tbcSampleType.TabIndex = 0;
            this.tbcSampleType.SelectedIndexChanged += new System.EventHandler(this.tbcSampleType_SelectedIndexChanged);
            // 
            // tpSampleType
            // 
            this.tpSampleType.Controls.Add(this.btnExit0);
            this.tpSampleType.Controls.Add(this.btnNewSampleType);
            this.tpSampleType.Controls.Add(this.btnDelSampleType);
            this.tpSampleType.Controls.Add(this.btnSaveSampleType);
            this.tpSampleType.Controls.Add(this.lsvSampleType);
            this.tpSampleType.Controls.Add(this.gbSampleTypeInfo);
            this.tpSampleType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tpSampleType.Location = new System.Drawing.Point(4, 23);
            this.tpSampleType.Name = "tpSampleType";
            this.tpSampleType.Size = new System.Drawing.Size(831, 405);
            this.tpSampleType.TabIndex = 0;
            this.tpSampleType.Text = "样品类别";
            // 
            // btnExit0
            // 
            this.btnExit0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit0.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit0.Location = new System.Drawing.Point(735, 366);
            this.btnExit0.Name = "btnExit0";
            this.btnExit0.Size = new System.Drawing.Size(75, 24);
            this.btnExit0.TabIndex = 16;
            this.btnExit0.Text = "关闭(&C)";
            this.btnExit0.UseVisualStyleBackColor = true;
            this.btnExit0.Click += new System.EventHandler(this.btnExit0_Click);
            // 
            // btnNewSampleType
            // 
            this.btnNewSampleType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewSampleType.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNewSampleType.Location = new System.Drawing.Point(471, 366);
            this.btnNewSampleType.Name = "btnNewSampleType";
            this.btnNewSampleType.Size = new System.Drawing.Size(75, 24);
            this.btnNewSampleType.TabIndex = 15;
            this.btnNewSampleType.Text = "新增";
            this.btnNewSampleType.Click += new System.EventHandler(this.btnNewSampleType_Click);
            // 
            // btnDelSampleType
            // 
            this.btnDelSampleType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelSampleType.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelSampleType.Location = new System.Drawing.Point(647, 366);
            this.btnDelSampleType.Name = "btnDelSampleType";
            this.btnDelSampleType.Size = new System.Drawing.Size(75, 24);
            this.btnDelSampleType.TabIndex = 14;
            this.btnDelSampleType.Text = "删除";
            this.btnDelSampleType.Click += new System.EventHandler(this.btnDelSampleType_Click);
            // 
            // btnSaveSampleType
            // 
            this.btnSaveSampleType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveSampleType.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSaveSampleType.Location = new System.Drawing.Point(559, 366);
            this.btnSaveSampleType.Name = "btnSaveSampleType";
            this.btnSaveSampleType.Size = new System.Drawing.Size(75, 24);
            this.btnSaveSampleType.TabIndex = 13;
            this.btnSaveSampleType.Text = "保存";
            this.btnSaveSampleType.Click += new System.EventHandler(this.btnSaveSampleType_Click);
            // 
            // lsvSampleType
            // 
            this.lsvSampleType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvSampleType.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chSampleTypeID,
            this.chSampleType,
            this.chPyCode,
            this.chWbCode,
            this.columnHeader3});
            this.lsvSampleType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvSampleType.FullRowSelect = true;
            this.lsvSampleType.HideSelection = false;
            this.lsvSampleType.Location = new System.Drawing.Point(16, 96);
            this.lsvSampleType.MultiSelect = false;
            this.lsvSampleType.Name = "lsvSampleType";
            this.lsvSampleType.Size = new System.Drawing.Size(799, 246);
            this.lsvSampleType.TabIndex = 12;
            this.lsvSampleType.UseCompatibleStateImageBehavior = false;
            this.lsvSampleType.View = System.Windows.Forms.View.Details;
            this.lsvSampleType.SelectedIndexChanged += new System.EventHandler(this.lsvSampleType_SelectedIndexChanged);
            // 
            // chSampleTypeID
            // 
            this.chSampleTypeID.Text = "样本类别编号";
            this.chSampleTypeID.Width = 100;
            // 
            // chSampleType
            // 
            this.chSampleType.Text = "样本类别";
            this.chSampleType.Width = 80;
            // 
            // chPyCode
            // 
            this.chPyCode.Text = "拼音助记符";
            this.chPyCode.Width = 90;
            // 
            // chWbCode
            // 
            this.chWbCode.Text = "五笔助记符";
            this.chWbCode.Width = 90;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "是否有条码";
            this.columnHeader3.Width = 121;
            // 
            // gbSampleTypeInfo
            // 
            this.gbSampleTypeInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSampleTypeInfo.Controls.Add(this.m_cboHasBarCode);
            this.gbSampleTypeInfo.Controls.Add(this.txtWbCode);
            this.gbSampleTypeInfo.Controls.Add(this.label2);
            this.gbSampleTypeInfo.Controls.Add(this.txtPyCode);
            this.gbSampleTypeInfo.Controls.Add(this.txtSampleType);
            this.gbSampleTypeInfo.Controls.Add(this.label7);
            this.gbSampleTypeInfo.Controls.Add(this.lbSampleType);
            this.gbSampleTypeInfo.Controls.Add(this.label1);
            this.gbSampleTypeInfo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbSampleTypeInfo.Location = new System.Drawing.Point(16, 16);
            this.gbSampleTypeInfo.Name = "gbSampleTypeInfo";
            this.gbSampleTypeInfo.Size = new System.Drawing.Size(799, 72);
            this.gbSampleTypeInfo.TabIndex = 11;
            this.gbSampleTypeInfo.TabStop = false;
            this.gbSampleTypeInfo.Text = "样本类别基本信息";
            // 
            // m_cboHasBarCode
            // 
            this.m_cboHasBarCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboHasBarCode.FormattingEnabled = true;
            this.m_cboHasBarCode.Items.AddRange(new object[] {
            "无",
            "有"});
            this.m_cboHasBarCode.Location = new System.Drawing.Point(710, 29);
            this.m_cboHasBarCode.Name = "m_cboHasBarCode";
            this.m_cboHasBarCode.Size = new System.Drawing.Size(67, 22);
            this.m_cboHasBarCode.TabIndex = 7;
            // 
            // txtWbCode
            // 
            this.txtWbCode.Location = new System.Drawing.Point(497, 29);
            this.txtWbCode.Name = "txtWbCode";
            this.txtWbCode.Size = new System.Drawing.Size(112, 23);
            this.txtWbCode.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(420, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "五笔助记符";
            // 
            // txtPyCode
            // 
            this.txtPyCode.Location = new System.Drawing.Point(295, 29);
            this.txtPyCode.Name = "txtPyCode";
            this.txtPyCode.Size = new System.Drawing.Size(112, 23);
            this.txtPyCode.TabIndex = 3;
            // 
            // txtSampleType
            // 
            this.txtSampleType.Location = new System.Drawing.Point(90, 29);
            this.txtSampleType.Name = "txtSampleType";
            this.txtSampleType.Size = new System.Drawing.Size(112, 23);
            this.txtSampleType.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(631, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "是否有条码";
            // 
            // lbSampleType
            // 
            this.lbSampleType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSampleType.Location = new System.Drawing.Point(24, 32);
            this.lbSampleType.Name = "lbSampleType";
            this.lbSampleType.Size = new System.Drawing.Size(64, 16);
            this.lbSampleType.TabIndex = 0;
            this.lbSampleType.Text = "样本类别";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(216, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "拼音助记符";
            // 
            // tpSampleCharacter
            // 
            this.tpSampleCharacter.Controls.Add(this.btnExit1);
            this.tpSampleCharacter.Controls.Add(this.btnDelSampleCharacter);
            this.tpSampleCharacter.Controls.Add(this.btnSaveSampleCharacter);
            this.tpSampleCharacter.Controls.Add(this.btnNewSampleCharacter);
            this.tpSampleCharacter.Controls.Add(this.lsvSampleCharacter);
            this.tpSampleCharacter.Controls.Add(this.gbSampleCharacter);
            this.tpSampleCharacter.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tpSampleCharacter.Location = new System.Drawing.Point(4, 23);
            this.tpSampleCharacter.Name = "tpSampleCharacter";
            this.tpSampleCharacter.Size = new System.Drawing.Size(831, 405);
            this.tpSampleCharacter.TabIndex = 1;
            this.tpSampleCharacter.Text = "样品性状";
            // 
            // btnExit1
            // 
            this.btnExit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit1.Location = new System.Drawing.Point(736, 368);
            this.btnExit1.Name = "btnExit1";
            this.btnExit1.Size = new System.Drawing.Size(75, 24);
            this.btnExit1.TabIndex = 17;
            this.btnExit1.Text = "关闭(&C)";
            this.btnExit1.UseVisualStyleBackColor = true;
            this.btnExit1.Click += new System.EventHandler(this.btnExit1_Click);
            // 
            // btnDelSampleCharacter
            // 
            this.btnDelSampleCharacter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelSampleCharacter.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelSampleCharacter.Location = new System.Drawing.Point(648, 368);
            this.btnDelSampleCharacter.Name = "btnDelSampleCharacter";
            this.btnDelSampleCharacter.Size = new System.Drawing.Size(75, 24);
            this.btnDelSampleCharacter.TabIndex = 9;
            this.btnDelSampleCharacter.Text = "删除";
            this.btnDelSampleCharacter.Click += new System.EventHandler(this.btnDelSampleCharacter_Click);
            // 
            // btnSaveSampleCharacter
            // 
            this.btnSaveSampleCharacter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveSampleCharacter.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSaveSampleCharacter.Location = new System.Drawing.Point(560, 368);
            this.btnSaveSampleCharacter.Name = "btnSaveSampleCharacter";
            this.btnSaveSampleCharacter.Size = new System.Drawing.Size(75, 24);
            this.btnSaveSampleCharacter.TabIndex = 8;
            this.btnSaveSampleCharacter.Text = "保存";
            this.btnSaveSampleCharacter.Click += new System.EventHandler(this.btnSaveSampleCharacter_Click);
            // 
            // btnNewSampleCharacter
            // 
            this.btnNewSampleCharacter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewSampleCharacter.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNewSampleCharacter.Location = new System.Drawing.Point(472, 368);
            this.btnNewSampleCharacter.Name = "btnNewSampleCharacter";
            this.btnNewSampleCharacter.Size = new System.Drawing.Size(75, 24);
            this.btnNewSampleCharacter.TabIndex = 7;
            this.btnNewSampleCharacter.Text = "新增";
            this.btnNewSampleCharacter.Click += new System.EventHandler(this.btnNewSampleCharacter_Click);
            // 
            // lsvSampleCharacter
            // 
            this.lsvSampleCharacter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvSampleCharacter.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chSEQ,
            this.chCharacter,
            this.columnHeader1,
            this.columnHeader2});
            this.lsvSampleCharacter.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvSampleCharacter.FullRowSelect = true;
            this.lsvSampleCharacter.HideSelection = false;
            this.lsvSampleCharacter.Location = new System.Drawing.Point(8, 112);
            this.lsvSampleCharacter.MultiSelect = false;
            this.lsvSampleCharacter.Name = "lsvSampleCharacter";
            this.lsvSampleCharacter.Size = new System.Drawing.Size(807, 232);
            this.lsvSampleCharacter.TabIndex = 6;
            this.lsvSampleCharacter.UseCompatibleStateImageBehavior = false;
            this.lsvSampleCharacter.View = System.Windows.Forms.View.Details;
            this.lsvSampleCharacter.SelectedIndexChanged += new System.EventHandler(this.lsvSampleCharacter_SelectedIndexChanged);
            // 
            // chSEQ
            // 
            this.chSEQ.Text = "序号";
            this.chSEQ.Width = 50;
            // 
            // chCharacter
            // 
            this.chCharacter.Text = "样本性状";
            this.chCharacter.Width = 120;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "拼音助记符";
            this.columnHeader1.Width = 90;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "五笔助记符";
            this.columnHeader2.Width = 90;
            // 
            // gbSampleCharacter
            // 
            this.gbSampleCharacter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSampleCharacter.Controls.Add(this.txtSampleCharacterWBCode);
            this.gbSampleCharacter.Controls.Add(this.label4);
            this.gbSampleCharacter.Controls.Add(this.txtSampleCharacterPYCode);
            this.gbSampleCharacter.Controls.Add(this.label3);
            this.gbSampleCharacter.Controls.Add(this.txtSampleCharacter);
            this.gbSampleCharacter.Controls.Add(this.label5);
            this.gbSampleCharacter.Controls.Add(this.label6);
            this.gbSampleCharacter.Controls.Add(this.cboSampleType);
            this.gbSampleCharacter.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbSampleCharacter.Location = new System.Drawing.Point(8, 16);
            this.gbSampleCharacter.Name = "gbSampleCharacter";
            this.gbSampleCharacter.Size = new System.Drawing.Size(807, 88);
            this.gbSampleCharacter.TabIndex = 5;
            this.gbSampleCharacter.TabStop = false;
            this.gbSampleCharacter.Text = "样本性状基本信息";
            // 
            // txtSampleCharacterWBCode
            // 
            this.txtSampleCharacterWBCode.Location = new System.Drawing.Point(488, 48);
            this.txtSampleCharacterWBCode.Name = "txtSampleCharacterWBCode";
            this.txtSampleCharacterWBCode.Size = new System.Drawing.Size(112, 23);
            this.txtSampleCharacterWBCode.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(416, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "五笔助记符";
            // 
            // txtSampleCharacterPYCode
            // 
            this.txtSampleCharacterPYCode.Location = new System.Drawing.Point(296, 48);
            this.txtSampleCharacterPYCode.Name = "txtSampleCharacterPYCode";
            this.txtSampleCharacterPYCode.Size = new System.Drawing.Size(112, 23);
            this.txtSampleCharacterPYCode.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(216, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "拼音助记符";
            // 
            // txtSampleCharacter
            // 
            this.txtSampleCharacter.Location = new System.Drawing.Point(88, 48);
            this.txtSampleCharacter.Name = "txtSampleCharacter";
            this.txtSampleCharacter.Size = new System.Drawing.Size(120, 23);
            this.txtSampleCharacter.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(8, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "样本性状";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(8, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "样本类别";
            // 
            // cboSampleType
            // 
            this.cboSampleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSampleType.Location = new System.Drawing.Point(88, 24);
            this.cboSampleType.Name = "cboSampleType";
            this.cboSampleType.Size = new System.Drawing.Size(120, 22);
            this.cboSampleType.TabIndex = 0;
            this.cboSampleType.SelectedIndexChanged += new System.EventHandler(this.cboSampleType_SelectedIndexChanged);
            // 
            // frmSampleInfo
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(871, 477);
            this.Controls.Add(this.tbcSampleType);
            this.Name = "frmSampleInfo";
            this.Text = "样本基本信息";
            this.Load += new System.EventHandler(this.frmSampleInfo_Load);
            this.tbcSampleType.ResumeLayout(false);
            this.tpSampleType.ResumeLayout(false);
            this.gbSampleTypeInfo.ResumeLayout(false);
            this.gbSampleTypeInfo.PerformLayout();
            this.tpSampleCharacter.ResumeLayout(false);
            this.gbSampleCharacter.ResumeLayout(false);
            this.gbSampleCharacter.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

	    #endregion	

        #region 公共函数

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.LIS.clsController_SampleTypeInfo();
        }

        private void ResetSampleType()
        {
            txtSampleType.Text = "";
            txtPyCode.Text = "";
            txtWbCode.Text = "";
            this.m_cboHasBarCode.SelectedIndex = 1;
        }

        private void ResetSampleCharacter()
        {
            txtSampleCharacter.Text = "";
            txtPyCode.Text = "";
            txtWbCode.Text = "";
            this.m_cboHasBarCode.SelectedIndex = 1;
        } 
        #endregion

        #region 事件实现

        private void frmSampleInfo_Load(object sender, System.EventArgs e)
        {
            ((clsController_SampleTypeInfo)this.objController).QryAllSampleType(out dtbAllSampleType);
            int count = dtbAllSampleType.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    ListViewItem objLsvItem = new ListViewItem();
                    objLsvItem.Text = dtbAllSampleType.Rows[i]["SAMPLE_TYPE_ID_CHR"].ToString().Trim();
                    objLsvItem.SubItems.Add(dtbAllSampleType.Rows[i]["SAMPLE_TYPE_DESC_VCHR"].ToString().Trim());
                    objLsvItem.SubItems.Add(dtbAllSampleType.Rows[i]["PYCODE_CHR"].ToString().Trim());
                    objLsvItem.SubItems.Add(dtbAllSampleType.Rows[i]["WBCODE_CHR"].ToString().Trim());
                    int hasBarCode = DBAssist.ToInt32(dtbAllSampleType.Rows[i]["HasBarCode_int"].ToString());
                    objLsvItem.SubItems.Add(hasBarCode == 1 ? "有" : "无");
                    lsvSampleType.Items.Add(objLsvItem);
                }
            }
        }

        private void lsvSampleType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (lsvSampleType.SelectedItems.Count > 0)
            {
                ResetSampleType();
                txtSampleType.Text = lsvSampleType.SelectedItems[0].SubItems[1].Text;
                txtPyCode.Text = lsvSampleType.SelectedItems[0].SubItems[2].Text;
                txtWbCode.Text = lsvSampleType.SelectedItems[0].SubItems[3].Text;
                if (lsvSampleType.SelectedItems[0].SubItems[4].Text.IndexOf("有")!=-1)
                {
                    this.m_cboHasBarCode.SelectedIndex = 1;
                }
                else 
                {
                    this.m_cboHasBarCode.SelectedIndex = 0;
                }
                btnSaveSampleType.Text = "修改";
            }
        }

        private void btnSaveSampleType_Click(object sender, System.EventArgs e)
        {
            if (txtSampleType.Text.ToString().Trim() == "")
            {
                MessageBox.Show("样本类别不能为空", "样本类别", MessageBoxButtons.OK);
                txtSampleType.Focus();
                return;
            }
            long flag = 0;
            string strSampleType = txtSampleType.Text.ToString().Trim();
            string strPyCode = txtPyCode.Text.ToString().Trim();
            string strWbCode = txtWbCode.Text.ToString().Trim();
            int intHasBarCode = this.m_cboHasBarCode.SelectedIndex;
            string strSampleTypeID = null;
            if (btnSaveSampleType.Text == "保存")
            {
                flag = ((clsController_SampleTypeInfo)this.objController).AddNewSample(strSampleType, strPyCode, strWbCode, intHasBarCode, out strSampleTypeID);
                if (flag > 0)
                {
                    ListViewItem objlsvItem = new ListViewItem();
                    objlsvItem.Text = strSampleTypeID;
                    objlsvItem.SubItems.Add(strSampleType);
                    objlsvItem.SubItems.Add(strPyCode);
                    objlsvItem.SubItems.Add(strWbCode);
                    if (intHasBarCode==1)
                    {
                        objlsvItem.SubItems.Add("有");
                    }
                    else 
                    {
                        objlsvItem.SubItems.Add("无");
                    }

                    lsvSampleType.Items.Add(objlsvItem);
                }
            }
            if (btnSaveSampleType.Text == "修改")
            {
                if (this.lsvSampleType.SelectedItems.Count > 0)
                {
                    strSampleTypeID = lsvSampleType.SelectedItems[0].SubItems[0].Text.ToString().Trim();
                    flag = ((clsController_SampleTypeInfo)this.objController).SetSampleTypeDetail(strSampleType, strPyCode, strWbCode, strSampleTypeID,intHasBarCode);
                    if (flag > 0)
                    {
                        ListViewItem objlsvItem = lsvSampleType.SelectedItems[0];
                        objlsvItem.SubItems[1].Text = strSampleType;
                        objlsvItem.SubItems[2].Text = strPyCode;
                        objlsvItem.SubItems[3].Text = strWbCode;
                        if (intHasBarCode == 1)
                        {
                            objlsvItem.SubItems[4].Text = "有";
                        }
                        else
                        {
                            objlsvItem.SubItems[4].Text = "无";
                        }
                    }
                }
            }
        }

        private void btnNewSampleType_Click(object sender, System.EventArgs e)
        {
            ResetSampleType();
            btnSaveSampleType.Text = "保存";
        }

        private void btnDelSampleType_Click(object sender, System.EventArgs e)
        {
            if (this.lsvSampleType.SelectedItems.Count > 0)
            {
                string strSampleTypeID = lsvSampleType.SelectedItems[0].SubItems[0].Text.ToString().Trim();
                long flag = 0;
                flag = ((clsController_SampleTypeInfo)this.objController).DelSampleType(strSampleTypeID);
                if (flag > 0)
                {
                    lsvSampleType.SelectedItems[0].Remove();
                }
            }
        }

        private void lsvSampleCharacter_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (lsvSampleCharacter.SelectedItems.Count > 0)
                {
                    ResetSampleCharacter();
                    ListViewItem objlsvItem = lsvSampleCharacter.SelectedItems[0];
                    txtSampleCharacter.Text = objlsvItem.SubItems[1].Text;
                    txtSampleCharacterPYCode.Text = objlsvItem.SubItems[2].Text;
                    txtSampleCharacterWBCode.Text = objlsvItem.SubItems[3].Text;
                    if (objlsvItem.SubItems[4].Text.IndexOf("无") != -1)
                    {
                        this.m_cboHasBarCode.SelectedIndex = 0;
                    }
                    else
                    {
                        this.m_cboHasBarCode.SelectedIndex = 1;
                    }
                    btnSaveSampleCharacter.Text = "修改";
                } 
            }
            catch(Exception e1)
            {
                return;
            }
            
        }

        private void cboSampleType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            string strSampleTypeID = cboSampleType.SelectedValue.ToString().Trim();
            lsvSampleCharacter.Items.Clear();
            ResetSampleCharacter();
            ((clsController_SampleTypeInfo)this.objController).QryAllSampleCharacter(out dtbAllSampleCharacter, strSampleTypeID);
            int count = dtbAllSampleCharacter.Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    ListViewItem objlsvItem = new ListViewItem();
                    objlsvItem.Text = dtbAllSampleCharacter.Rows[i]["CHARACTERORD_INT"].ToString().Trim();
                    objlsvItem.SubItems.Add(dtbAllSampleCharacter.Rows[i]["CHARACTER_DESC_VCHR"].ToString().Trim());
                    objlsvItem.SubItems.Add(dtbAllSampleCharacter.Rows[i]["PYCODE_CHR"].ToString().Trim());
                    objlsvItem.SubItems.Add(dtbAllSampleCharacter.Rows[i]["WBCODE_CHR"].ToString().Trim());
                    int hasBarCode = DBAssist.ToInt32(dtbAllSampleType.Rows[i]["HasBarCode_int"].ToString());
                    objlsvItem.SubItems.Add(hasBarCode == 1 ? "有" : "无");
                    
                    lsvSampleCharacter.Items.Add(objlsvItem);
                }
            }
        }

        private void btnNewSampleCharacter_Click(object sender, System.EventArgs e)
        {
            btnSaveSampleCharacter.Text = "保存";
            ResetSampleCharacter();
        }

        private void btnSaveSampleCharacter_Click(object sender, System.EventArgs e)
        {
            if (txtSampleCharacter.Text.ToString().Trim() == "")
            {
                MessageBox.Show("样本性状不能为空", "样本信息", MessageBoxButtons.OK);
                txtSampleCharacter.Focus();
                return;
            }
            string strSampleCharacter = txtSampleCharacter.Text.ToString().Trim();
            string strSampleTypeID = cboSampleType.SelectedValue.ToString().Trim();
            string strPyCode = txtSampleCharacterPYCode.Text.ToString().Trim();
            string strWbCode = txtSampleCharacterWBCode.Text.ToString().Trim();
            int intHasBarCode = this.m_cboHasBarCode.SelectedIndex;
            string strSEQ = null;
            long flag = 0;
            if (btnSaveSampleCharacter.Text == "保存")
            {
                flag = ((clsController_SampleTypeInfo)this.objController).AddNewSampleCharacter(strSampleCharacter, strPyCode, strWbCode, strSampleTypeID, ref strSEQ);
                if (flag > 0)
                {
                    ListViewItem objlsvItem = new ListViewItem();
                    objlsvItem.Text = strSEQ;
                    objlsvItem.SubItems.Add(strSampleCharacter);
                    objlsvItem.SubItems.Add(strPyCode);
                    objlsvItem.SubItems.Add(strWbCode);
                    lsvSampleCharacter.Items.Add(objlsvItem);
                }
            }
            else if (btnSaveSampleCharacter.Text == "修改")
            {
                if (this.lsvSampleCharacter.SelectedItems.Count > 0)
                {
                    strSEQ = lsvSampleCharacter.SelectedItems[0].SubItems[0].Text.ToString().Trim();
                    flag = ((clsController_SampleTypeInfo)this.objController).SetSampleCharacter(strSampleCharacter,
                        strPyCode, strWbCode, strSampleTypeID, strSEQ);
                    if (flag > 0)
                    {
                        lsvSampleCharacter.SelectedItems[0].SubItems[1].Text = txtSampleCharacter.Text;
                        lsvSampleCharacter.SelectedItems[0].SubItems[2].Text = strPyCode;
                        lsvSampleCharacter.SelectedItems[0].SubItems[3].Text = strWbCode;
                    }
                }
            }
        }

        private void btnDelSampleCharacter_Click(object sender, System.EventArgs e)
        {
            if (this.lsvSampleCharacter.SelectedItems.Count > 0)
            {
                string strSampleTypeID = cboSampleType.SelectedValue.ToString().Trim();
                string strSEQ = lsvSampleCharacter.SelectedItems[0].SubItems[0].Text.ToString().Trim();
                long flag = 0;
                flag = ((clsController_SampleTypeInfo)this.objController).DelSampleCharacter(strSEQ, strSampleTypeID);
                if (flag > 0)
                {
                    lsvSampleCharacter.SelectedItems[0].Remove();
                    ResetSampleCharacter();
                }
            }
        }

        private void tbcSampleType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (tbcSampleType.SelectedIndex == 1)
            {
                ((clsController_SampleTypeInfo)this.objController).QryAllSampleType(out dtbAllSampleType);
                cboSampleType.DataSource = dtbAllSampleType;
                cboSampleType.DisplayMember = "SAMPLE_TYPE_DESC_VCHR";
                cboSampleType.ValueMember = "SAMPLE_TYPE_ID_CHR";
                string strSampleTypeID = cboSampleType.SelectedValue.ToString().Trim();
                ((clsController_SampleTypeInfo)this.objController).QryAllSampleCharacter(out dtbAllSampleCharacter, strSampleTypeID);
                int count = dtbAllSampleCharacter.Rows.Count;
                lsvSampleCharacter.Items.Clear();
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        ListViewItem objlsvItem = new ListViewItem();
                        objlsvItem.Text = dtbAllSampleCharacter.Rows[i]["CHARACTERORD_INT"].ToString().Trim();
                        objlsvItem.SubItems.Add(dtbAllSampleCharacter.Rows[i]["CHARACTER_DESC_VCHR"].ToString().Trim());
                        objlsvItem.SubItems.Add(dtbAllSampleCharacter.Rows[i]["PYCODE_CHR"].ToString().Trim());
                        objlsvItem.SubItems.Add(dtbAllSampleCharacter.Rows[i]["WBCODE_CHR"].ToString().Trim());
                        lsvSampleCharacter.Items.Add(objlsvItem);
                    }
                }
            }
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
