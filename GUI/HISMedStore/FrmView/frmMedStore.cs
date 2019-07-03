using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
//using com.digitalwave.iCare.gui.MedicineStore;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 药房设置窗口
	/// </summary>
	public class frmMedStore : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtMedStoreName;
		internal System.Windows.Forms.ComboBox m_cboMedStoreType;
		internal System.Windows.Forms.ComboBox m_cboMedicineType;
		private System.Windows.Forms.GroupBox groupBox2;
		internal PinkieControls.ButtonXP m_cmdSave;
		internal PinkieControls.ButtonXP m_cmdNew;
		internal PinkieControls.ButtonXP m_cmdDelete;
		internal PinkieControls.ButtonXP m_cmdRefersh;
		internal PinkieControls.ButtonXP m_cmdClose;
		internal System.Windows.Forms.ListView m_lsvDetail;
		private System.Windows.Forms.ColumnHeader clhID;
		private System.Windows.Forms.ColumnHeader clhName;
		private System.Windows.Forms.ColumnHeader clhType;
		private System.Windows.Forms.ColumnHeader clhMedicineType;
		internal System.Windows.Forms.CheckBox m_chkUrgency;
		private System.Windows.Forms.ColumnHeader clhUrgency;
		private System.Windows.Forms.GroupBox groupBox3;
		internal System.Windows.Forms.ListView m_lsv;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Label label6;
		internal System.Windows.Forms.CheckBox m_chkMorning;
		internal System.Windows.Forms.CheckBox m_chkNoon;
		private System.Windows.Forms.GroupBox groupBox7;
		internal System.Windows.Forms.ComboBox m_cboDate;
		private System.Windows.Forms.Label label7;
		internal PinkieControls.ButtonXP m_cmdAdd;
		internal PinkieControls.ButtonXP m_cboSave;
		internal PinkieControls.ButtonXP m_cboDel;
		private System.Windows.Forms.Label label8;
		internal com.digitalwave.controls.ctlTextBoxFind m_txtMedStore;
		internal System.Windows.Forms.DateTimePicker m_dtpMorng1;
		internal System.Windows.Forms.DateTimePicker m_dtpMorng2;
		internal System.Windows.Forms.DateTimePicker m_dtpNoon2;
		internal System.Windows.Forms.DateTimePicker m_dtpNoon1;
		internal System.Windows.Forms.DateTimePicker m_dtpEven2;
		internal System.Windows.Forms.DateTimePicker m_dtpEven1;
		private System.Windows.Forms.Label label9;
		internal System.Windows.Forms.TextBox m_txtRemark;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		internal System.Windows.Forms.CheckBox m_chkEvening;
		internal PinkieControls.ButtonXP m_cmdBrush;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.GroupBox groupBox9;
        internal com.digitalwave.Controls.Domain.EmrControls.ctlDeptSelected_EnterKeyActive m_txtDept;
        private Label label10;
        private ColumnHeader colhDeptName;
        private ColumnHeader colHDeptid_chr;
        private Label lblShortName;
        private ColumnHeader colShortName;
        internal TextBox txtMedStoreShortName;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// 
		/// </summary>
		public frmMedStore()
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

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMedStore));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.m_cboDate = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.m_dtpEven2 = new System.Windows.Forms.DateTimePicker();
            this.m_dtpEven1 = new System.Windows.Forms.DateTimePicker();
            this.m_chkEvening = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.m_dtpNoon2 = new System.Windows.Forms.DateTimePicker();
            this.m_dtpNoon1 = new System.Windows.Forms.DateTimePicker();
            this.m_chkNoon = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_txtRemark = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.m_dtpMorng2 = new System.Windows.Forms.DateTimePicker();
            this.m_dtpMorng1 = new System.Windows.Forms.DateTimePicker();
            this.m_chkMorning = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.m_txtMedStore = new com.digitalwave.controls.ctlTextBoxFind();
            this.m_lsv = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.m_cmdBrush = new PinkieControls.ButtonXP();
            this.m_cboDel = new PinkieControls.ButtonXP();
            this.m_cboSave = new PinkieControls.ButtonXP();
            this.m_cmdAdd = new PinkieControls.ButtonXP();
            this.m_cmdClose = new PinkieControls.ButtonXP();
            this.m_lsvDetail = new System.Windows.Forms.ListView();
            this.clhID = new System.Windows.Forms.ColumnHeader();
            this.clhName = new System.Windows.Forms.ColumnHeader();
            this.clhType = new System.Windows.Forms.ColumnHeader();
            this.clhMedicineType = new System.Windows.Forms.ColumnHeader();
            this.clhUrgency = new System.Windows.Forms.ColumnHeader();
            this.colhDeptName = new System.Windows.Forms.ColumnHeader();
            this.colHDeptid_chr = new System.Windows.Forms.ColumnHeader();
            this.colShortName = new System.Windows.Forms.ColumnHeader();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_cmdRefersh = new PinkieControls.ButtonXP();
            this.m_cmdDelete = new PinkieControls.ButtonXP();
            this.m_cmdNew = new PinkieControls.ButtonXP();
            this.m_cmdSave = new PinkieControls.ButtonXP();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMedStoreShortName = new System.Windows.Forms.TextBox();
            this.lblShortName = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.m_txtDept = new com.digitalwave.Controls.Domain.EmrControls.ctlDeptSelected_EnterKeyActive();
            this.m_chkUrgency = new System.Windows.Forms.CheckBox();
            this.m_cboMedicineType = new System.Windows.Forms.ComboBox();
            this.m_cboMedStoreType = new System.Windows.Forms.ComboBox();
            this.m_txtMedStoreName = new SourceLibrary.Windows.Forms.TextBoxTyped();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.groupBox8);
            this.groupBox3.Controls.Add(this.m_lsv);
            this.groupBox3.Controls.Add(this.groupBox7);
            this.groupBox3.Location = new System.Drawing.Point(0, 280);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1028, 280);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox8.Controls.Add(this.groupBox9);
            this.groupBox8.Controls.Add(this.label8);
            this.groupBox8.Controls.Add(this.groupBox6);
            this.groupBox8.Controls.Add(this.groupBox5);
            this.groupBox8.Controls.Add(this.m_txtRemark);
            this.groupBox8.Controls.Add(this.groupBox4);
            this.groupBox8.Controls.Add(this.label9);
            this.groupBox8.Controls.Add(this.m_txtMedStore);
            this.groupBox8.Location = new System.Drawing.Point(224, 168);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(800, 104);
            this.groupBox8.TabIndex = 16;
            this.groupBox8.TabStop = false;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.label7);
            this.groupBox9.Controls.Add(this.m_cboDate);
            this.groupBox9.Location = new System.Drawing.Point(0, 8);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(160, 48);
            this.groupBox9.TabIndex = 0;
            this.groupBox9.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 9;
            this.label7.Text = "排班日期";
            // 
            // m_cboDate
            // 
            this.m_cboDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboDate.Items.AddRange(new object[] {
            "星期一",
            "星期二",
            "星期三",
            "星期四",
            "星期五",
            "星期六",
            "星期日"});
            this.m_cboDate.Location = new System.Drawing.Point(72, 16);
            this.m_cboDate.Name = "m_cboDate";
            this.m_cboDate.Size = new System.Drawing.Size(80, 22);
            this.m_cboDate.TabIndex = 0;
            this.m_cboDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cboDate_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 14);
            this.label8.TabIndex = 10;
            this.label8.Text = "转发药房";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.m_dtpEven2);
            this.groupBox6.Controls.Add(this.m_dtpEven1);
            this.groupBox6.Controls.Add(this.m_chkEvening);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Location = new System.Drawing.Point(584, 8);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(216, 48);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            // 
            // m_dtpEven2
            // 
            this.m_dtpEven2.CustomFormat = "HH:mm";
            this.m_dtpEven2.Enabled = false;
            this.m_dtpEven2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpEven2.Location = new System.Drawing.Point(144, 16);
            this.m_dtpEven2.Name = "m_dtpEven2";
            this.m_dtpEven2.ShowUpDown = true;
            this.m_dtpEven2.Size = new System.Drawing.Size(64, 23);
            this.m_dtpEven2.TabIndex = 9;
            this.m_dtpEven2.Value = new System.DateTime(2006, 2, 13, 21, 0, 0, 0);
            this.m_dtpEven2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_dtpEven2_KeyDown);
            // 
            // m_dtpEven1
            // 
            this.m_dtpEven1.CustomFormat = "HH:mm";
            this.m_dtpEven1.Enabled = false;
            this.m_dtpEven1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpEven1.Location = new System.Drawing.Point(80, 16);
            this.m_dtpEven1.Name = "m_dtpEven1";
            this.m_dtpEven1.ShowUpDown = true;
            this.m_dtpEven1.Size = new System.Drawing.Size(64, 23);
            this.m_dtpEven1.TabIndex = 8;
            this.m_dtpEven1.Value = new System.DateTime(2006, 2, 13, 19, 0, 0, 0);
            this.m_dtpEven1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_dtpEven1_KeyDown);
            // 
            // m_chkEvening
            // 
            this.m_chkEvening.Location = new System.Drawing.Point(8, 16);
            this.m_chkEvening.Name = "m_chkEvening";
            this.m_chkEvening.Size = new System.Drawing.Size(80, 24);
            this.m_chkEvening.TabIndex = 7;
            this.m_chkEvening.Text = "时间段3";
            this.m_chkEvening.CheckedChanged += new System.EventHandler(this.m_chkEvening_CheckedChanged);
            this.m_chkEvening.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_chkEvening_KeyDown);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(144, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 23);
            this.label6.TabIndex = 4;
            this.label6.Text = "_";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.m_dtpNoon2);
            this.groupBox5.Controls.Add(this.m_dtpNoon1);
            this.groupBox5.Controls.Add(this.m_chkNoon);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Location = new System.Drawing.Point(368, 8);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(224, 48);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            // 
            // m_dtpNoon2
            // 
            this.m_dtpNoon2.CustomFormat = "HH:mm";
            this.m_dtpNoon2.Enabled = false;
            this.m_dtpNoon2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpNoon2.Location = new System.Drawing.Point(152, 16);
            this.m_dtpNoon2.Name = "m_dtpNoon2";
            this.m_dtpNoon2.ShowUpDown = true;
            this.m_dtpNoon2.Size = new System.Drawing.Size(64, 23);
            this.m_dtpNoon2.TabIndex = 6;
            this.m_dtpNoon2.Value = new System.DateTime(2006, 2, 13, 17, 0, 0, 0);
            this.m_dtpNoon2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_dtpNoon2_KeyDown);
            // 
            // m_dtpNoon1
            // 
            this.m_dtpNoon1.CustomFormat = "HH:mm";
            this.m_dtpNoon1.Enabled = false;
            this.m_dtpNoon1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpNoon1.Location = new System.Drawing.Point(80, 16);
            this.m_dtpNoon1.Name = "m_dtpNoon1";
            this.m_dtpNoon1.ShowUpDown = true;
            this.m_dtpNoon1.Size = new System.Drawing.Size(64, 23);
            this.m_dtpNoon1.TabIndex = 5;
            this.m_dtpNoon1.Value = new System.DateTime(2006, 2, 13, 13, 0, 0, 0);
            this.m_dtpNoon1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_dtpNoon1_KeyDown);
            // 
            // m_chkNoon
            // 
            this.m_chkNoon.Location = new System.Drawing.Point(8, 16);
            this.m_chkNoon.Name = "m_chkNoon";
            this.m_chkNoon.Size = new System.Drawing.Size(80, 24);
            this.m_chkNoon.TabIndex = 4;
            this.m_chkNoon.Text = "时间段2";
            this.m_chkNoon.CheckedChanged += new System.EventHandler(this.m_chkNoon_CheckedChanged);
            this.m_chkNoon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_chkNoon_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(144, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "_";
            // 
            // m_txtRemark
            // 
            this.m_txtRemark.Location = new System.Drawing.Point(304, 64);
            this.m_txtRemark.MaxLength = 50;
            this.m_txtRemark.Name = "m_txtRemark";
            this.m_txtRemark.Size = new System.Drawing.Size(488, 23);
            this.m_txtRemark.TabIndex = 13;
            this.m_txtRemark.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtRemark_KeyDown);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.m_dtpMorng2);
            this.groupBox4.Controls.Add(this.m_dtpMorng1);
            this.groupBox4.Controls.Add(this.m_chkMorning);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(152, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(224, 48);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            // 
            // m_dtpMorng2
            // 
            this.m_dtpMorng2.CustomFormat = "HH:mm";
            this.m_dtpMorng2.Enabled = false;
            this.m_dtpMorng2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpMorng2.Location = new System.Drawing.Point(152, 16);
            this.m_dtpMorng2.Name = "m_dtpMorng2";
            this.m_dtpMorng2.ShowUpDown = true;
            this.m_dtpMorng2.Size = new System.Drawing.Size(64, 23);
            this.m_dtpMorng2.TabIndex = 3;
            this.m_dtpMorng2.Value = new System.DateTime(2006, 2, 13, 11, 30, 0, 0);
            this.m_dtpMorng2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_dtpMorng2_KeyDown);
            // 
            // m_dtpMorng1
            // 
            this.m_dtpMorng1.CustomFormat = "HH:mm";
            this.m_dtpMorng1.Enabled = false;
            this.m_dtpMorng1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpMorng1.Location = new System.Drawing.Point(80, 16);
            this.m_dtpMorng1.Name = "m_dtpMorng1";
            this.m_dtpMorng1.ShowUpDown = true;
            this.m_dtpMorng1.Size = new System.Drawing.Size(64, 23);
            this.m_dtpMorng1.TabIndex = 2;
            this.m_dtpMorng1.Value = new System.DateTime(2006, 2, 13, 8, 0, 0, 0);
            this.m_dtpMorng1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_dtpMorng1_KeyDown);
            // 
            // m_chkMorning
            // 
            this.m_chkMorning.Location = new System.Drawing.Point(8, 16);
            this.m_chkMorning.Name = "m_chkMorning";
            this.m_chkMorning.Size = new System.Drawing.Size(80, 24);
            this.m_chkMorning.TabIndex = 1;
            this.m_chkMorning.Text = "时间段1";
            this.m_chkMorning.CheckedChanged += new System.EventHandler(this.m_chkMorning_CheckedChanged);
            this.m_chkMorning.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_chkMorning_KeyDown);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(144, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "_";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(264, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 14);
            this.label9.TabIndex = 12;
            this.label9.Text = "备注";
            // 
            // m_txtMedStore
            // 
            this.m_txtMedStore.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtMedStore.intHeight = 100;
            this.m_txtMedStore.IsEnterShow = true;
            this.m_txtMedStore.isHide = 2;
            this.m_txtMedStore.isTxt = 1;
            this.m_txtMedStore.isUpOrDn = 1;
            this.m_txtMedStore.isValuse = 0;
            this.m_txtMedStore.Location = new System.Drawing.Point(72, 64);
            this.m_txtMedStore.m_IsHaveParent = false;
            this.m_txtMedStore.m_strParentName = "";
            this.m_txtMedStore.Name = "m_txtMedStore";
            this.m_txtMedStore.nextCtl = null;
            this.m_txtMedStore.Size = new System.Drawing.Size(136, 24);
            this.m_txtMedStore.TabIndex = 11;
            this.m_txtMedStore.txtValuse = "";
            this.m_txtMedStore.VsLeftOrRight = 1;
            // 
            // m_lsv
            // 
            this.m_lsv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lsv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.m_lsv.FullRowSelect = true;
            this.m_lsv.GridLines = true;
            this.m_lsv.HideSelection = false;
            this.m_lsv.Location = new System.Drawing.Point(224, 24);
            this.m_lsv.MultiSelect = false;
            this.m_lsv.Name = "m_lsv";
            this.m_lsv.Size = new System.Drawing.Size(796, 144);
            this.m_lsv.TabIndex = 15;
            this.m_lsv.UseCompatibleStateImageBehavior = false;
            this.m_lsv.View = System.Windows.Forms.View.Details;
            this.m_lsv.SelectedIndexChanged += new System.EventHandler(this.m_lsv_SelectedIndexChanged);
            this.m_lsv.DoubleClick += new System.EventHandler(this.m_lsv_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "日期(星期)";
            this.columnHeader1.Width = 113;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "上班时间";
            this.columnHeader2.Width = 344;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "转发药房";
            this.columnHeader3.Width = 123;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "备注";
            this.columnHeader4.Width = 167;
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox7.Controls.Add(this.m_cmdBrush);
            this.groupBox7.Controls.Add(this.m_cboDel);
            this.groupBox7.Controls.Add(this.m_cboSave);
            this.groupBox7.Controls.Add(this.m_cmdAdd);
            this.groupBox7.Controls.Add(this.m_cmdClose);
            this.groupBox7.Location = new System.Drawing.Point(8, 16);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(208, 256);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
            // 
            // m_cmdBrush
            // 
            this.m_cmdBrush.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_cmdBrush.DefaultScheme = true;
            this.m_cmdBrush.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdBrush.Hint = "";
            this.m_cmdBrush.Location = new System.Drawing.Point(48, 176);
            this.m_cmdBrush.Name = "m_cmdBrush";
            this.m_cmdBrush.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdBrush.Size = new System.Drawing.Size(112, 32);
            this.m_cmdBrush.TabIndex = 5;
            this.m_cmdBrush.Text = "刷新(&B)";
            this.m_cmdBrush.Click += new System.EventHandler(this.m_cmdBrush_Click);
            // 
            // m_cboDel
            // 
            this.m_cboDel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_cboDel.DefaultScheme = true;
            this.m_cboDel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cboDel.Hint = "";
            this.m_cboDel.Location = new System.Drawing.Point(48, 128);
            this.m_cboDel.Name = "m_cboDel";
            this.m_cboDel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cboDel.Size = new System.Drawing.Size(112, 32);
            this.m_cboDel.TabIndex = 3;
            this.m_cboDel.Text = "删除(&C)";
            this.m_cboDel.Click += new System.EventHandler(this.m_cboDel_Click);
            // 
            // m_cboSave
            // 
            this.m_cboSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_cboSave.DefaultScheme = true;
            this.m_cboSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cboSave.Hint = "";
            this.m_cboSave.Location = new System.Drawing.Point(48, 80);
            this.m_cboSave.Name = "m_cboSave";
            this.m_cboSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cboSave.Size = new System.Drawing.Size(112, 32);
            this.m_cboSave.TabIndex = 2;
            this.m_cboSave.Text = "保存(&E)";
            this.m_cboSave.Click += new System.EventHandler(this.m_cboSave_Click);
            this.m_cboSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cboSave_KeyDown);
            // 
            // m_cmdAdd
            // 
            this.m_cmdAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_cmdAdd.DefaultScheme = true;
            this.m_cmdAdd.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdAdd.Hint = "";
            this.m_cmdAdd.Location = new System.Drawing.Point(48, 32);
            this.m_cmdAdd.Name = "m_cmdAdd";
            this.m_cmdAdd.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdAdd.Size = new System.Drawing.Size(112, 32);
            this.m_cmdAdd.TabIndex = 1;
            this.m_cmdAdd.Text = "新增(&N)";
            this.m_cmdAdd.Click += new System.EventHandler(this.m_cmdAdd_Click);
            this.m_cmdAdd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cmdAdd_KeyDown);
            // 
            // m_cmdClose
            // 
            this.m_cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_cmdClose.DefaultScheme = true;
            this.m_cmdClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdClose.Hint = "";
            this.m_cmdClose.Location = new System.Drawing.Point(48, 224);
            this.m_cmdClose.Name = "m_cmdClose";
            this.m_cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdClose.Size = new System.Drawing.Size(112, 32);
            this.m_cmdClose.TabIndex = 4;
            this.m_cmdClose.Text = "退出(&E)";
            this.m_cmdClose.Click += new System.EventHandler(this.m_cmdClose_Click);
            // 
            // m_lsvDetail
            // 
            this.m_lsvDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lsvDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clhID,
            this.clhName,
            this.clhType,
            this.clhMedicineType,
            this.clhUrgency,
            this.colhDeptName,
            this.colHDeptid_chr,
            this.colShortName});
            this.m_lsvDetail.FullRowSelect = true;
            this.m_lsvDetail.GridLines = true;
            this.m_lsvDetail.HideSelection = false;
            this.m_lsvDetail.Location = new System.Drawing.Point(223, 11);
            this.m_lsvDetail.MultiSelect = false;
            this.m_lsvDetail.Name = "m_lsvDetail";
            this.m_lsvDetail.Size = new System.Drawing.Size(796, 272);
            this.m_lsvDetail.TabIndex = 2;
            this.m_lsvDetail.UseCompatibleStateImageBehavior = false;
            this.m_lsvDetail.View = System.Windows.Forms.View.Details;
            this.m_lsvDetail.SelectedIndexChanged += new System.EventHandler(this.m_lsvDetail_SelectedIndexChanged);
            this.m_lsvDetail.DoubleClick += new System.EventHandler(this.m_lsvDetail_DoubleClick);
            // 
            // clhID
            // 
            this.clhID.Text = "代码";
            this.clhID.Width = 104;
            // 
            // clhName
            // 
            this.clhName.Text = "名称";
            this.clhName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clhName.Width = 116;
            // 
            // clhType
            // 
            this.clhType.Text = "类别";
            this.clhType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clhType.Width = 125;
            // 
            // clhMedicineType
            // 
            this.clhMedicineType.Text = "药品类型";
            this.clhMedicineType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clhMedicineType.Width = 144;
            // 
            // clhUrgency
            // 
            this.clhUrgency.Text = "是否急诊";
            this.clhUrgency.Width = 84;
            // 
            // colhDeptName
            // 
            this.colhDeptName.Text = "对应部门";
            this.colhDeptName.Width = 106;
            // 
            // colHDeptid_chr
            // 
            this.colHDeptid_chr.Text = "对应部门";
            this.colHDeptid_chr.Width = 0;
            // 
            // colShortName
            // 
            this.colShortName.Text = "药房简码";
            this.colShortName.Width = 112;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_cmdRefersh);
            this.groupBox2.Controls.Add(this.m_cmdDelete);
            this.groupBox2.Controls.Add(this.m_cmdNew);
            this.groupBox2.Controls.Add(this.m_cmdSave);
            this.groupBox2.Location = new System.Drawing.Point(8, 180);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(208, 128);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // m_cmdRefersh
            // 
            this.m_cmdRefersh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_cmdRefersh.DefaultScheme = true;
            this.m_cmdRefersh.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdRefersh.Hint = "";
            this.m_cmdRefersh.Location = new System.Drawing.Point(112, 63);
            this.m_cmdRefersh.Name = "m_cmdRefersh";
            this.m_cmdRefersh.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdRefersh.Size = new System.Drawing.Size(88, 32);
            this.m_cmdRefersh.TabIndex = 3;
            this.m_cmdRefersh.Text = "刷新(&R)";
            this.m_cmdRefersh.Click += new System.EventHandler(this.m_cmdRefersh_Click);
            // 
            // m_cmdDelete
            // 
            this.m_cmdDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_cmdDelete.DefaultScheme = true;
            this.m_cmdDelete.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdDelete.Hint = "";
            this.m_cmdDelete.Location = new System.Drawing.Point(16, 63);
            this.m_cmdDelete.Name = "m_cmdDelete";
            this.m_cmdDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdDelete.Size = new System.Drawing.Size(88, 32);
            this.m_cmdDelete.TabIndex = 2;
            this.m_cmdDelete.Text = "删除(&D)";
            this.m_cmdDelete.Click += new System.EventHandler(this.m_cmdDelete_Click);
            // 
            // m_cmdNew
            // 
            this.m_cmdNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_cmdNew.DefaultScheme = true;
            this.m_cmdNew.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdNew.Hint = "";
            this.m_cmdNew.Location = new System.Drawing.Point(16, 17);
            this.m_cmdNew.Name = "m_cmdNew";
            this.m_cmdNew.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdNew.Size = new System.Drawing.Size(88, 32);
            this.m_cmdNew.TabIndex = 1;
            this.m_cmdNew.Text = "新增(&A)";
            this.m_cmdNew.Click += new System.EventHandler(this.m_cmdNew_Click);
            // 
            // m_cmdSave
            // 
            this.m_cmdSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_cmdSave.DefaultScheme = true;
            this.m_cmdSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSave.Hint = "";
            this.m_cmdSave.Location = new System.Drawing.Point(112, 18);
            this.m_cmdSave.Name = "m_cmdSave";
            this.m_cmdSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSave.Size = new System.Drawing.Size(88, 32);
            this.m_cmdSave.TabIndex = 0;
            this.m_cmdSave.Text = "保存(&S)";
            this.m_cmdSave.Click += new System.EventHandler(this.m_cmdSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMedStoreShortName);
            this.groupBox1.Controls.Add(this.lblShortName);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.m_txtDept);
            this.groupBox1.Controls.Add(this.m_chkUrgency);
            this.groupBox1.Controls.Add(this.m_cboMedicineType);
            this.groupBox1.Controls.Add(this.m_cboMedStoreType);
            this.groupBox1.Controls.Add(this.m_txtMedStoreName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(8, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 184);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtMedStoreShortName
            // 
            this.txtMedStoreShortName.Location = new System.Drawing.Point(80, 102);
            this.txtMedStoreShortName.MaxLength = 3;
            this.txtMedStoreShortName.Name = "txtMedStoreShortName";
            this.txtMedStoreShortName.Size = new System.Drawing.Size(120, 23);
            this.txtMedStoreShortName.TabIndex = 8;
            this.txtMedStoreShortName.TextChanged += new System.EventHandler(this.txtMedStoreShortName_TextChanged);
            this.txtMedStoreShortName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMedStoreShortName_KeyDown_1);
            this.txtMedStoreShortName.Leave += new System.EventHandler(this.txtMedStoreShortName_Leave);
            this.txtMedStoreShortName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMedStoreShortName_KeyPress_1);
            // 
            // lblShortName
            // 
            this.lblShortName.AutoSize = true;
            this.lblShortName.Location = new System.Drawing.Point(16, 106);
            this.lblShortName.Name = "lblShortName";
            this.lblShortName.Size = new System.Drawing.Size(63, 14);
            this.lblShortName.TabIndex = 4;
            this.lblShortName.Text = "药房简码";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 139);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 14);
            this.label10.TabIndex = 10;
            this.label10.Text = "对应部门";
            // 
            // m_txtDept
            // 
            this.m_txtDept.Location = new System.Drawing.Point(80, 134);
            this.m_txtDept.m_objTag = null;
            this.m_txtDept.Name = "m_txtDept";
            this.m_txtDept.Size = new System.Drawing.Size(120, 23);
            this.m_txtDept.TabIndex = 9;
            this.m_txtDept.显示类型 = com.digitalwave.Controls.Domain.EmrControls.enmDeptAttributeType.全部;
            this.m_txtDept.ItemSelectedChanged += new com.digitalwave.Controls.ItemSelectedEventHandler(this.m_txtDept_ItemSelectedChanged);
            // 
            // m_chkUrgency
            // 
            this.m_chkUrgency.Location = new System.Drawing.Point(9, 161);
            this.m_chkUrgency.Name = "m_chkUrgency";
            this.m_chkUrgency.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.m_chkUrgency.Size = new System.Drawing.Size(88, 24);
            this.m_chkUrgency.TabIndex = 10;
            this.m_chkUrgency.Text = "是否急诊";
            this.m_chkUrgency.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.m_chkUrgency.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_chkUrgency_KeyDown);
            // 
            // m_cboMedicineType
            // 
            this.m_cboMedicineType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboMedicineType.Items.AddRange(new object[] {
            "西药",
            "中药",
            "材料"});
            this.m_cboMedicineType.Location = new System.Drawing.Point(80, 72);
            this.m_cboMedicineType.Name = "m_cboMedicineType";
            this.m_cboMedicineType.Size = new System.Drawing.Size(121, 22);
            this.m_cboMedicineType.TabIndex = 7;
            this.m_cboMedicineType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cboMedicineType_KeyDown);
            // 
            // m_cboMedStoreType
            // 
            this.m_cboMedStoreType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboMedStoreType.Items.AddRange(new object[] {
            "门诊药房",
            "住院药房",
            "全院药房"});
            this.m_cboMedStoreType.Location = new System.Drawing.Point(80, 42);
            this.m_cboMedStoreType.Name = "m_cboMedStoreType";
            this.m_cboMedStoreType.Size = new System.Drawing.Size(121, 22);
            this.m_cboMedStoreType.TabIndex = 6;
            this.m_cboMedStoreType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cboMedStoreType_KeyDown);
            // 
            // m_txtMedStoreName
            // 
            this.m_txtMedStoreName.EnableAutoValidation = false;
            this.m_txtMedStoreName.EnableEnterKeyValidate = true;
            this.m_txtMedStoreName.EnableEscapeKeyUndo = true;
            this.m_txtMedStoreName.EnableLastValidValue = true;
            this.m_txtMedStoreName.ErrorProvider = null;
            this.m_txtMedStoreName.ErrorProviderMessage = "Invalid value";
            this.m_txtMedStoreName.ForceFormatText = true;
            this.m_txtMedStoreName.Location = new System.Drawing.Point(80, 13);
            this.m_txtMedStoreName.MaxLength = 50;
            this.m_txtMedStoreName.Name = "m_txtMedStoreName";
            this.m_txtMedStoreName.Size = new System.Drawing.Size(120, 23);
            this.m_txtMedStoreName.TabIndex = 5;
            this.m_txtMedStoreName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtMedStoreName_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "药品类型";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "类别";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "药房名称";
            // 
            // frmMedStore
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(1028, 567);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.m_lsvDetail);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMedStore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "药房设置";
            this.Load += new System.EventHandler(this.frmMedStore_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 
		/// </summary>
		public override void CreateController()
		{
			this.objController = new clsControlMedStore();
			this.objController.Set_GUI_Apperance(this);
          
		}

		private void frmMedStore_Load(object sender, System.EventArgs e)
		{
			base.m_mthSetFormControlCanBeNull(this);
			((clsControlMedStore)this.objController).m_mthInit();
		    ((clsControlMedStore)this.objController).LoadMedStoreInfo1();
            ((clsControlMedStore)this.objController).m_mthInitialDept();
		}

		private void m_lsvDetail_DoubleClick(object sender, System.EventArgs e)
		{
			((clsControlMedStore)this.objController).m_mthDetailSel();

			((clsControlMedStore)this.objController).m_GetDeptDutyInfo();
		}

		private void m_cmdSave_Click(object sender, System.EventArgs e)
		{
			((clsControlMedStore)this.objController).m_mthSave();
		}

		private void m_cmdNew_Click(object sender, System.EventArgs e)
		{
			((clsControlMedStore)this.objController).m_mthSetViewInfo(null);
		}

		private void m_cmdDelete_Click(object sender, System.EventArgs e)
		{
			((clsControlMedStore)this.objController).m_mthDoDelete();
		}

		private void m_cmdRefersh_Click(object sender, System.EventArgs e)
		{
			((clsControlMedStore)this.objController).m_mthGetDetailList();
		}

		private void m_cmdClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void m_chkMorning_CheckedChanged(object sender, System.EventArgs e)
		{
			if(m_chkMorning.Checked==true)
			{
				m_dtpMorng1.Enabled=true;
				m_dtpMorng2.Enabled=true;
			}
			else
			{
				m_dtpMorng1.Enabled=false;
				m_dtpMorng2.Enabled=false;
			}
		}

		private void m_chkNoon_CheckedChanged(object sender, System.EventArgs e)
		{
			
				if(m_chkNoon.Checked==true)
			{
				m_dtpNoon1.Enabled=true;
				m_dtpNoon2.Enabled=true;
			}
			else
			{
				m_dtpNoon1.Enabled=false;
				m_dtpNoon2.Enabled=false;
			}
		}

		private void m_chkEvening_CheckedChanged(object sender, System.EventArgs e)
		{
			if(m_chkEvening.Checked==true)
			{
				m_dtpEven1.Enabled=true;
				m_dtpEven2.Enabled=true;
			}
			else
			{
				m_dtpEven1.Enabled=false;
				m_dtpEven2.Enabled=false;
			}
		}

		private void m_lsvDetail_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            this.m_txtMedStore.Tag = "";
            this.m_txtMedStore.txtValuse = "";
	     ((clsControlMedStore)this.objController).m_mthDetailSel();
          if(this.m_lsvDetail.SelectedItems.Count==0)
			  return;
          ((clsControlMedStore)this.objController).LoadMedStoreInfo1();
		((clsControlMedStore)this.objController).m_GetDeptDutyInfo();
      
		}

		private void m_cmdAdd_Click(object sender, System.EventArgs e)
		{

		    ((clsControlMedStore)this.objController).m_AddDuty();
		}

		private void m_cboSave_Click(object sender, System.EventArgs e)
		{
			((clsControlMedStore)this.objController).m_saveDeptDutyInfo();
		}

		private void m_lsv_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		  ((clsControlMedStore)this.objController).m_thChangeLsvText();
		}

		private void m_cboDel_Click(object sender, System.EventArgs e)
		{
		((clsControlMedStore)this.objController).m_DelDeptDutyInfo();
		}

		private void m_cmdBrush_Click(object sender, System.EventArgs e)
		{
			((clsControlMedStore)this.objController).m_GetDeptDutyInfo();
			((clsControlMedStore)this.objController).flage="Add";
             ((clsControlMedStore)this.objController).m_mthClearDeptDutyInfo();
		}

		private void m_lsv_DoubleClick(object sender, System.EventArgs e)
		{
		((clsControlMedStore)this.objController).m_thChangeLsvText();
		}

		private void m_cmdAdd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{

				this.m_cboDate.Focus();
			}
		}

		private void m_txtRemark_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
			 this.m_cboSave.Focus();
			}
		}

		private void m_cboSave_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				this.m_cboDate.Focus();
			}

		}

		private void m_chkMorning_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
//			if(m_chkMorning.Checked==false)
//				this.m_txtMedStore.Focus();
			 if(e.KeyCode==Keys.Enter)
				SendKeys.Send("{Tab}");
		}
         int i1=0;
		private void m_dtpMorng1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			
			if(e.KeyCode==Keys.Enter)
			{
				if(i1==0)
				{
					i1++;
					SendKeys.Send("{Right}");
				}
				else
				{
					SendKeys.Send("{Tab}");
					i1=0;
				}

			}
			
		}
        int i2=0;
		private void m_dtpMorng2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			
			if(e.KeyCode==Keys.Enter)
			{
				if(i2==0)
				{
					i2++;
					SendKeys.Send("{Right}");
				}
				else
				{
					SendKeys.Send("{Tab}");
					i2=0;
				}

			}
			
		}

		private void m_cboDate_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
				m_chkMorning.Focus();
		
		}

		private void m_chkNoon_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
//            if(m_chkNoon.Checked==false)
//             this.m_txtMedStore.Focus();
			 if(e.KeyCode==Keys.Enter)
				SendKeys.Send("{Tab}");
		}
        int i3=0;
		private void m_dtpNoon1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
				
			if(e.KeyCode==Keys.Enter)
			{
				if(i3==0)
				{
					i3++;
					SendKeys.Send("{Right}");
				}
				else
				{
					SendKeys.Send("{Tab}");
					i3=0;
				}

			}
			
		}
	    int i4=0;
		private void m_dtpNoon2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
		
			if(e.KeyCode==Keys.Enter)
			{
				if(i4==0)
				{
					i4++;
					SendKeys.Send("{Right}");
				}
				else
				{
					SendKeys.Send("{Tab}");
					i4=0;
				}

			}
			
		}

		private void m_chkEvening_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
//			if(m_chkEvening.Checked==false)
//				this.m_txtMedStore.Focus();
			 if(e.KeyCode==Keys.Enter)
			{
			   SendKeys.Send("{Tab}");
			}
		}
        int i5=0;
		private void m_dtpEven1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			
			if(e.KeyCode==Keys.Enter)
			{
				if(i5==0)
				{
					i5++;
					SendKeys.Send("{Right}");
				}
				else		
				{
					SendKeys.Send("{Tab}");
				    i5=0;
				}

			}
			
		}
        int i6=0;
		private void m_dtpEven2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				if(i6==0)
				{
					i6++;
					SendKeys.Send("{Right}");
				}
				else		
				{
					SendKeys.Send("{Tab}");
				    i6=0;
				}
			}
			
		}

        private void m_txtMedStoreName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
             
            }
        }

       

        private void m_cboMedicineType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");

            }
        }

        private void m_chkUrgency_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_cmdSave.Focus();

            }
        }

        private void m_cboMedStoreType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");

            }
        }

        /// <summary>
        /// 检测简码输入
        /// 吴崇坤2008.5.13
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void txtMedStoreShortName_KeyDown_1(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                  SendKeys.Send("{Tab}");
            }
        
        }

        private void txtMedStoreShortName_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8 || e.KeyChar == 13 || (e.KeyChar >= 65 && e.KeyChar <= 90) || (e.KeyChar >= 97 && e.KeyChar <= 122))
            {

            }
            else
            {
                e.Handled = true;
                MessageBox.Show("药房简码必须输入三个大写字符!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtMedStoreShortName_TextChanged(object sender, EventArgs e)
        {
            this.txtMedStoreShortName.Text = this.txtMedStoreShortName.Text.ToUpper();
            this.txtMedStoreShortName.SelectionStart = this.txtMedStoreShortName.Text.Length;
        }

        private void txtMedStoreShortName_Leave(object sender, EventArgs e)
        {
          if (this.txtMedStoreShortName.Text.Trim().Length<3&&this .txtMedStoreShortName.Text!="")
          {
            MessageBox.Show("药房简码必须输入三个大写字符!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.txtMedStoreShortName.Focus();
            return;
          }
      }

        private void m_txtDept_ItemSelectedChanged(object sender, com.digitalwave.Controls.clsItemDataEventArg e)
        {
            m_txtDept.AccessibleName = m_txtDept.StrItemId;
        }

        }
}
