using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
    /// 安排床位——界面表示层
	/// </summary>
	public class frmTurnIn : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
	{
		#region 控件申明
		/// <summary>
		/// 部门科室ID号
		/// </summary>
		internal string m_strDeptID ="";
		/// <summary>
		/// 病区-流水号
		/// </summary>		
		internal string m_strAreaID ="";
		/// <summary>
		/// 床位ID
		/// </summary>
		internal string m_strBedID = "";
		/// <summary>
		/// 入院登记ID
		/// </summary>
		internal string m_strRegisterID ="";
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		internal System.Windows.Forms.CheckBox m_chkView;
		internal System.Windows.Forms.ListView m_lsvPatientInfo;
		private System.Windows.Forms.Label label5;
		internal System.Windows.Forms.Label m_lblDEPTNAME_VCHR;
		internal System.Windows.Forms.Label m_lblAREAName;
		private System.ComponentModel.IContainer components;
		private PinkieControls.ButtonXP cmdCancel;
		private PinkieControls.ButtonXP cmdTurnIn;
        private System.Windows.Forms.Label label2;
		internal System.Windows.Forms.ImageList imlSmall;
		internal System.Windows.Forms.ImageList imlLarge;
        private System.Windows.Forms.GroupBox groupBox1;
        internal ComboBox m_cmbBed;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader8;
        internal CheckBox m_chbAll;
        internal ControlLibrary.txtListView m_txtMaindoctor;
        private Label m_lbInAreaDate;
        internal NullableDateControls.MaskDateEdit m_inAreaDate;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private Label label4;
        internal ControlLibrary.txtListView m_txtEat;
        private Label label6;
        internal ComboBox m_cboSTATE_INT;
        internal ControlLibrary.txtListView m_txtNurse;
        private Label label7;
        private ColumnHeader columnHeader7;

		#endregion 

		#region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="p_strDeptID">部门ID</param>
        /// <param name="p_strAreaID">病区ID</param>
        /// <param name="p_strBedID">床位ID</param>
        /// <param name="p_strRegisterID">入院登记ID</param>
        public frmTurnIn(string p_strDeptID, string p_strAreaID, string p_strBedID, string p_strRegisterID)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
            m_strDeptID = p_strDeptID;
            m_strAreaID = p_strAreaID;
            m_strBedID = p_strBedID;
            m_strRegisterID = p_strRegisterID;
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
		#endregion 

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTurnIn));
            this.m_lblDEPTNAME_VCHR = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_lblAREAName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_lsvPatientInfo = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.imlLarge = new System.Windows.Forms.ImageList(this.components);
            this.imlSmall = new System.Windows.Forms.ImageList(this.components);
            this.m_chkView = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdTurnIn = new PinkieControls.ButtonXP();
            this.cmdCancel = new PinkieControls.ButtonXP();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_txtNurse = new ControlLibrary.txtListView(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.m_txtEat = new ControlLibrary.txtListView(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.m_cboSTATE_INT = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_inAreaDate = new NullableDateControls.MaskDateEdit();
            this.m_lbInAreaDate = new System.Windows.Forms.Label();
            this.m_txtMaindoctor = new ControlLibrary.txtListView(this.components);
            this.m_cmbBed = new System.Windows.Forms.ComboBox();
            this.m_chbAll = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_lblDEPTNAME_VCHR
            // 
            this.m_lblDEPTNAME_VCHR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lblDEPTNAME_VCHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblDEPTNAME_VCHR.Location = new System.Drawing.Point(85, 24);
            this.m_lblDEPTNAME_VCHR.Name = "m_lblDEPTNAME_VCHR";
            this.m_lblDEPTNAME_VCHR.Size = new System.Drawing.Size(158, 21);
            this.m_lblDEPTNAME_VCHR.TabIndex = 3;
            this.m_lblDEPTNAME_VCHR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(19, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 15;
            this.label1.Text = "科室名称：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_lblAREAName
            // 
            this.m_lblAREAName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lblAREAName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblAREAName.Location = new System.Drawing.Point(334, 24);
            this.m_lblAREAName.Name = "m_lblAREAName";
            this.m_lblAREAName.Size = new System.Drawing.Size(172, 21);
            this.m_lblAREAName.TabIndex = 4;
            this.m_lblAREAName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(266, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 17;
            this.label3.Text = "病区名称：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_lsvPatientInfo
            // 
            this.m_lsvPatientInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.m_lsvPatientInfo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvPatientInfo.FullRowSelect = true;
            this.m_lsvPatientInfo.GridLines = true;
            this.m_lsvPatientInfo.HideSelection = false;
            this.m_lsvPatientInfo.LargeImageList = this.imlLarge;
            this.m_lsvPatientInfo.Location = new System.Drawing.Point(14, 178);
            this.m_lsvPatientInfo.MultiSelect = false;
            this.m_lsvPatientInfo.Name = "m_lsvPatientInfo";
            this.m_lsvPatientInfo.Size = new System.Drawing.Size(768, 347);
            this.m_lsvPatientInfo.SmallImageList = this.imlSmall;
            this.m_lsvPatientInfo.TabIndex = 1;
            this.m_lsvPatientInfo.UseCompatibleStateImageBehavior = false;
            this.m_lsvPatientInfo.View = System.Windows.Forms.View.Details;
            this.m_lsvPatientInfo.SelectedIndexChanged += new System.EventHandler(this.m_lsvPatientInfo_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 32;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "住院号";
            this.columnHeader2.Width = 106;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "病人姓名";
            this.columnHeader3.Width = 88;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "性别";
            this.columnHeader4.Width = 56;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "年龄";
            this.columnHeader5.Width = 52;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "病情";
            this.columnHeader6.Width = 53;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "转入时间";
            this.columnHeader7.Width = 175;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "所在病区";
            this.columnHeader8.Width = 105;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "";
            this.columnHeader9.Width = 0;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "入病区时间";
            this.columnHeader10.Width = 175;
            // 
            // imlLarge
            // 
            this.imlLarge.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlLarge.ImageStream")));
            this.imlLarge.TransparentColor = System.Drawing.Color.Transparent;
            this.imlLarge.Images.SetKeyName(0, "床位_空.bmp");
            this.imlLarge.Images.SetKeyName(1, "男二级-急.bmp");
            this.imlLarge.Images.SetKeyName(2, "男二级-危.bmp");
            this.imlLarge.Images.SetKeyName(3, "男二级-一般.bmp");
            this.imlLarge.Images.SetKeyName(4, "男三级-急.bmp");
            this.imlLarge.Images.SetKeyName(5, "男三级-危.bmp");
            this.imlLarge.Images.SetKeyName(6, "男三级-一般.bmp");
            this.imlLarge.Images.SetKeyName(7, "男特级-急.bmp");
            this.imlLarge.Images.SetKeyName(8, "男特级-危.bmp");
            this.imlLarge.Images.SetKeyName(9, "男特级-一般.bmp");
            this.imlLarge.Images.SetKeyName(10, "男无护理-急.bmp");
            this.imlLarge.Images.SetKeyName(11, "男无护理-危.bmp");
            this.imlLarge.Images.SetKeyName(12, "男无护理-一般.bmp");
            this.imlLarge.Images.SetKeyName(13, "男一级-急.bmp");
            this.imlLarge.Images.SetKeyName(14, "男一级-危.bmp");
            this.imlLarge.Images.SetKeyName(15, "男一级-一般.bmp");
            this.imlLarge.Images.SetKeyName(16, "女二级-急.bmp");
            this.imlLarge.Images.SetKeyName(17, "女二级-危.bmp");
            this.imlLarge.Images.SetKeyName(18, "女二级-一般.bmp");
            this.imlLarge.Images.SetKeyName(19, "女三级-急.bmp");
            this.imlLarge.Images.SetKeyName(20, "女三级-危.bmp");
            this.imlLarge.Images.SetKeyName(21, "女三级-一般.bmp");
            this.imlLarge.Images.SetKeyName(22, "女特级-急.bmp");
            this.imlLarge.Images.SetKeyName(23, "女特级-危.bmp");
            this.imlLarge.Images.SetKeyName(24, "女特级-一般.bmp");
            this.imlLarge.Images.SetKeyName(25, "女无护理-急.bmp");
            this.imlLarge.Images.SetKeyName(26, "女无护理-危.bmp");
            this.imlLarge.Images.SetKeyName(27, "女无护理-一般.bmp");
            this.imlLarge.Images.SetKeyName(28, "女一级-急.bmp");
            this.imlLarge.Images.SetKeyName(29, "女一级-危.bmp");
            this.imlLarge.Images.SetKeyName(30, "女一级-一般.bmp");
            // 
            // imlSmall
            // 
            this.imlSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlSmall.ImageStream")));
            this.imlSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imlSmall.Images.SetKeyName(0, "床位_空.bmp");
            this.imlSmall.Images.SetKeyName(1, "男二级-急.bmp");
            this.imlSmall.Images.SetKeyName(2, "男二级-危.bmp");
            this.imlSmall.Images.SetKeyName(3, "男二级-一般.bmp");
            this.imlSmall.Images.SetKeyName(4, "男三级-急.bmp");
            this.imlSmall.Images.SetKeyName(5, "男三级-危.bmp");
            this.imlSmall.Images.SetKeyName(6, "男三级-一般.bmp");
            this.imlSmall.Images.SetKeyName(7, "男特级-急.bmp");
            this.imlSmall.Images.SetKeyName(8, "男特级-危.bmp");
            this.imlSmall.Images.SetKeyName(9, "男特级-一般.bmp");
            this.imlSmall.Images.SetKeyName(10, "男无护理-急.bmp");
            this.imlSmall.Images.SetKeyName(11, "男无护理-危.bmp");
            this.imlSmall.Images.SetKeyName(12, "男无护理-一般.bmp");
            this.imlSmall.Images.SetKeyName(13, "男一级-急.bmp");
            this.imlSmall.Images.SetKeyName(14, "男一级-危.bmp");
            this.imlSmall.Images.SetKeyName(15, "男一级-一般.bmp");
            this.imlSmall.Images.SetKeyName(16, "女二级-急.bmp");
            this.imlSmall.Images.SetKeyName(17, "女二级-危.bmp");
            this.imlSmall.Images.SetKeyName(18, "女二级-一般.bmp");
            this.imlSmall.Images.SetKeyName(19, "女三级-急.bmp");
            this.imlSmall.Images.SetKeyName(20, "女三级-危.bmp");
            this.imlSmall.Images.SetKeyName(21, "女三级-一般.bmp");
            this.imlSmall.Images.SetKeyName(22, "女特级-急.bmp");
            this.imlSmall.Images.SetKeyName(23, "女特级-危.bmp");
            this.imlSmall.Images.SetKeyName(24, "女特级-一般.bmp");
            this.imlSmall.Images.SetKeyName(25, "女无护理-急.bmp");
            this.imlSmall.Images.SetKeyName(26, "女无护理-危.bmp");
            this.imlSmall.Images.SetKeyName(27, "女无护理-一般.bmp");
            this.imlSmall.Images.SetKeyName(28, "女一级-急.bmp");
            this.imlSmall.Images.SetKeyName(29, "女一级-危.bmp");
            this.imlSmall.Images.SetKeyName(30, "女一级-一般.bmp");
            // 
            // m_chkView
            // 
            this.m_chkView.Checked = true;
            this.m_chkView.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkView.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkView.Location = new System.Drawing.Point(34, 146);
            this.m_chkView.Name = "m_chkView";
            this.m_chkView.Size = new System.Drawing.Size(88, 24);
            this.m_chkView.TabIndex = 6;
            this.m_chkView.Text = "列表模式";
            this.m_chkView.CheckedChanged += new System.EventHandler(this.m_chkView_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(525, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 14);
            this.label5.TabIndex = 23;
            this.label5.Text = "床　　号：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmdTurnIn
            // 
            this.cmdTurnIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdTurnIn.DefaultScheme = true;
            this.cmdTurnIn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdTurnIn.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdTurnIn.Hint = "";
            this.cmdTurnIn.Location = new System.Drawing.Point(569, 140);
            this.cmdTurnIn.Name = "cmdTurnIn";
            this.cmdTurnIn.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdTurnIn.Size = new System.Drawing.Size(96, 28);
            this.cmdTurnIn.TabIndex = 3;
            this.cmdTurnIn.Text = "入区(F2)";
            this.cmdTurnIn.Click += new System.EventHandler(this.cmdTurnIn_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdCancel.DefaultScheme = true;
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdCancel.Hint = "";
            this.cmdCancel.Location = new System.Drawing.Point(675, 141);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdCancel.Size = new System.Drawing.Size(96, 28);
            this.cmdCancel.TabIndex = 4;
            this.cmdCancel.Text = "关闭(Esc)";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(19, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 27;
            this.label2.Text = "主治医师：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_txtNurse);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.m_txtEat);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.m_cboSTATE_INT);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.m_inAreaDate);
            this.groupBox1.Controls.Add(this.m_lbInAreaDate);
            this.groupBox1.Controls.Add(this.m_txtMaindoctor);
            this.groupBox1.Controls.Add(this.m_cmbBed);
            this.groupBox1.Controls.Add(this.m_lblAREAName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.m_lblDEPTNAME_VCHR);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(768, 135);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // m_txtNurse
            // 
            this.m_txtNurse.findDataMode = ControlLibrary.txtListView.findMode.fromListView;
            this.m_txtNurse.Location = new System.Drawing.Point(337, 96);
            this.m_txtNurse.m_blnFocuseShow = true;
            this.m_txtNurse.m_blnPagination = false;
            this.m_txtNurse.m_dtbDataSourse = null;
            this.m_txtNurse.m_intDelayTime = 100;
            this.m_txtNurse.m_intPageRows = 10;
            this.m_txtNurse.m_ListViewAlign = ControlLibrary.txtListView.ListViewAlign.LeftBottom;
            this.m_txtNurse.m_listViewSize = new System.Drawing.Point(250, 100);
            this.m_txtNurse.m_strFieldsArr = new string[] {
        "USERCODE_CHR",
        "NAME_CHR",
        "PYCODE_CHR"};
            this.m_txtNurse.m_strSaveField = "ORDERDICID_CHR";
            this.m_txtNurse.m_strShowField = "NAME_CHR";
            this.m_txtNurse.m_strSQL = null;
            this.m_txtNurse.Name = "m_txtNurse";
            this.m_txtNurse.Size = new System.Drawing.Size(169, 23);
            this.m_txtNurse.TabIndex = 33;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(266, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 14);
            this.label7.TabIndex = 34;
            this.label7.Text = "护    理：";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtEat
            // 
            this.m_txtEat.findDataMode = ControlLibrary.txtListView.findMode.fromListView;
            this.m_txtEat.Location = new System.Drawing.Point(85, 95);
            this.m_txtEat.m_blnFocuseShow = true;
            this.m_txtEat.m_blnPagination = false;
            this.m_txtEat.m_dtbDataSourse = null;
            this.m_txtEat.m_intDelayTime = 100;
            this.m_txtEat.m_intPageRows = 10;
            this.m_txtEat.m_ListViewAlign = ControlLibrary.txtListView.ListViewAlign.LeftBottom;
            this.m_txtEat.m_listViewSize = new System.Drawing.Point(290, 100);
            this.m_txtEat.m_strFieldsArr = new string[] {
        "USERCODE_CHR",
        "NAME_CHR",
        "PYCODE_CHR"};
            this.m_txtEat.m_strSaveField = "ORDERDICID_CHR";
            this.m_txtEat.m_strShowField = "NAME_CHR";
            this.m_txtEat.m_strSQL = null;
            this.m_txtEat.Name = "m_txtEat";
            this.m_txtEat.Size = new System.Drawing.Size(158, 23);
            this.m_txtEat.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(19, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 14);
            this.label6.TabIndex = 32;
            this.label6.Text = "饮    食：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_cboSTATE_INT
            // 
            this.m_cboSTATE_INT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboSTATE_INT.Items.AddRange(new object[] {
            "",
            "1-危",
            "2-急",
            "3-普通"});
            this.m_cboSTATE_INT.Location = new System.Drawing.Point(605, 57);
            this.m_cboSTATE_INT.Name = "m_cboSTATE_INT";
            this.m_cboSTATE_INT.Size = new System.Drawing.Size(121, 22);
            this.m_cboSTATE_INT.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(525, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 29;
            this.label4.Text = "病　　情：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_inAreaDate
            // 
            this.m_inAreaDate.Location = new System.Drawing.Point(335, 60);
            this.m_inAreaDate.Mask = "yyyy年MM月dd日HH时mm分";
            this.m_inAreaDate.Name = "m_inAreaDate";
            this.m_inAreaDate.Size = new System.Drawing.Size(171, 23);
            this.m_inAreaDate.TabIndex = 2;
            // 
            // m_lbInAreaDate
            // 
            this.m_lbInAreaDate.AutoSize = true;
            this.m_lbInAreaDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lbInAreaDate.Location = new System.Drawing.Point(266, 66);
            this.m_lbInAreaDate.Name = "m_lbInAreaDate";
            this.m_lbInAreaDate.Size = new System.Drawing.Size(77, 14);
            this.m_lbInAreaDate.TabIndex = 28;
            this.m_lbInAreaDate.Text = "入区时间：";
            this.m_lbInAreaDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtMaindoctor
            // 
            this.m_txtMaindoctor.findDataMode = ControlLibrary.txtListView.findMode.fromListView;
            this.m_txtMaindoctor.Location = new System.Drawing.Point(85, 57);
            this.m_txtMaindoctor.m_blnFocuseShow = true;
            this.m_txtMaindoctor.m_blnPagination = false;
            this.m_txtMaindoctor.m_dtbDataSourse = null;
            this.m_txtMaindoctor.m_intDelayTime = 100;
            this.m_txtMaindoctor.m_intPageRows = 10;
            this.m_txtMaindoctor.m_ListViewAlign = ControlLibrary.txtListView.ListViewAlign.LeftBottom;
            this.m_txtMaindoctor.m_listViewSize = new System.Drawing.Point(210, 100);
            this.m_txtMaindoctor.m_strFieldsArr = new string[] {
        "empno_chr",
        "pycode_chr",
        "doctorname"};
            this.m_txtMaindoctor.m_strSaveField = "empid_chr";
            this.m_txtMaindoctor.m_strShowField = "doctorname";
            this.m_txtMaindoctor.m_strSQL = null;
            this.m_txtMaindoctor.Name = "m_txtMaindoctor";
            this.m_txtMaindoctor.Size = new System.Drawing.Size(158, 23);
            this.m_txtMaindoctor.TabIndex = 1;
            // 
            // m_cmbBed
            // 
            this.m_cmbBed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbBed.FormattingEnabled = true;
            this.m_cmbBed.Location = new System.Drawing.Point(605, 23);
            this.m_cmbBed.Name = "m_cmbBed";
            this.m_cmbBed.Size = new System.Drawing.Size(121, 22);
            this.m_cmbBed.TabIndex = 0;
            // 
            // m_chbAll
            // 
            this.m_chbAll.AutoSize = true;
            this.m_chbAll.Location = new System.Drawing.Point(149, 148);
            this.m_chbAll.Name = "m_chbAll";
            this.m_chbAll.Size = new System.Drawing.Size(82, 18);
            this.m_chbAll.TabIndex = 28;
            this.m_chbAll.Text = "全院病人";
            this.m_chbAll.UseVisualStyleBackColor = true;
            this.m_chbAll.CheckedChanged += new System.EventHandler(this.m_chbAll_CheckedChanged);
            // 
            // frmTurnIn
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(794, 525);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_chbAll);
            this.Controls.Add(this.m_lsvPatientInfo);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdTurnIn);
            this.Controls.Add(this.m_chkView);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(200, 187);
            this.MaximizeBox = false;
            this.Name = "frmTurnIn";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "安排床位";
            this.Closed += new System.EventHandler(this.frmTurnIn_Closed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTurnIn_KeyDown);
            this.Load += new System.EventHandler(this.frmTurnIn_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region 设置窗体控制器
		public override void CreateController()
		{
			this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_TurnIn();
			objController.Set_GUI_Apperance(this);
		}
		#endregion

        #region 初始化数据
        private void frmTurnIn_Load(object sender, System.EventArgs e)
		{
            m_mthSetEnter2Tab(new System.Windows.Forms.Control[] { m_txtMaindoctor, m_txtEat, m_txtNurse });
            ((clsCtl_TurnIn)this.objController).m_mthInit();
        }
        #endregion

        #region 安排床位
        private void cmdTurnIn_Click(object sender, System.EventArgs e)
		{
            ((clsCtl_TurnIn)this.objController).m_mthArrangeBed();
        }
        #endregion

        #region 退出
        private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
        }
        #endregion

        #region 设置示图
        private void m_chkView_CheckedChanged(object sender, System.EventArgs e)
		{
			
			if(m_chkView.Checked)
			{
				m_lsvPatientInfo.View =View.Details;
			}
			else
			{
				m_lsvPatientInfo.View =View.LargeIcon;
			}
        }
        #endregion

        #region 快捷键
        private void frmTurnIn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			m_mthSetKeyTab(e);
			switch (e.KeyCode)
			{
				case Keys.Escape:
					if(MessageBox.Show("确认退出么?","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
					{
						this.Close();
					}
					break;
				case Keys.F2:
					cmdTurnIn_Click(sender,e);	
					break;
			}
        }
        #endregion

        #region 关闭窗体时设置返回结果
        /// <summary>
		/// 改动标志着:0=没有改动;1=有改动
		/// </summary>
		internal int m_intFlag=0;
		private void frmTurnIn_Closed(object sender, System.EventArgs e)
		{
			if(m_intFlag==1)
			{
				this.DialogResult = DialogResult.OK;
			}		
		}
		#endregion

        private void m_chbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chbAll.Checked)
            {
                ((clsCtl_TurnIn)this.objController).m_mthGetAllUmArrangeBedPatient();
            }
            else
            {
                ((clsCtl_TurnIn)this.objController).m_mthGetTurnInNotAccept();
            }
        }

        private void m_lsvPatientInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.m_lsvPatientInfo.SelectedItems.Count > 0)
            {
                string trType = this.m_lsvPatientInfo.SelectedItems[0].SubItems[8].Text.Trim();
                if (trType == "3" || trType == "4")
                {
                    this.m_inAreaDate.Text = this.m_lsvPatientInfo.SelectedItems[0].SubItems[9].Text;
                    this.m_inAreaDate.Enabled = false;
         
                }
                else
                {
                    //入病区时间默认为当前时间
                    this.m_inAreaDate.Text = DateTime.Now.ToString("yyyy年MM月dd日HH时mm分");
                    this.m_inAreaDate.Enabled = true;

                }

                ((clsCtl_TurnIn)this.objController).PatientChanged();
                
            }
        }

        
	}
}
