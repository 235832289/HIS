using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 床位管理界面表示层
	/// </summary>
	public class frmEditBed : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
	{
		#region 控件声明

		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label40;
        internal bool Isoccupied = false;
		private System.Windows.Forms.Label label56;
		private System.Windows.Forms.Label label54;
		private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label52;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
		private PinkieControls.ButtonXP cmd_colse;
		private PinkieControls.ButtonXP m_cmdSave;
		internal System.Windows.Forms.ListView m_lsvICD;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
        internal System.Windows.Forms.TextBox m_txtICD;
        internal ControlLibrary.txtListView m_txtMaindoctor;
        internal Label m_txtINPatient;
        internal Label m_txtPATIENTCARDID;
        internal Label m_txtInsuranceID;
        internal Label m_txtINPATIENT_DAT;
        internal Label m_txtPaytypeid;
        internal Label m_txtBIRTH_DAT;
        internal Label m_txtTYPE_INT;
        internal Label m_txtHOMEPHONE_VCHR;
        internal Label m_txtSex;
        internal Label m_txtIDCARD_CHR;
        internal Label m_txtPatientName;
        internal ControlLibrary.txtListView m_txtDIAGNOSE;
        internal NullableDateControls.MaskDateEdit m_inAreaDate;
        private Label m_lbInAreaDate;
        internal ControlLibrary.txtListView m_txtNurse;
        internal ControlLibrary.txtListView m_txtEat;
        internal ComboBox m_cboSTATE_INT;
        private Label label2;
        private Label label1;
        private IContainer components;
		#endregion 

		#region 构造函数
		/// <summary>
		/// 显示病人信息
		/// </summary>
		/// <param name="p_bedManageVO">病人信息VO</param>
	
        public frmEditBed(clsBedManageVO p_bedManageVO)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
            ((clsCtl_EditBed)this.objController).m_mthShowPatientInfo(p_bedManageVO);
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_cboSTATE_INT = new System.Windows.Forms.ComboBox();
            this.m_txtNurse = new ControlLibrary.txtListView(this.components);
            this.m_txtEat = new ControlLibrary.txtListView(this.components);
            this.m_inAreaDate = new NullableDateControls.MaskDateEdit();
            this.m_lbInAreaDate = new System.Windows.Forms.Label();
            this.m_txtDIAGNOSE = new ControlLibrary.txtListView(this.components);
            this.m_txtINPATIENT_DAT = new System.Windows.Forms.Label();
            this.m_txtPaytypeid = new System.Windows.Forms.Label();
            this.m_txtBIRTH_DAT = new System.Windows.Forms.Label();
            this.m_txtTYPE_INT = new System.Windows.Forms.Label();
            this.m_txtHOMEPHONE_VCHR = new System.Windows.Forms.Label();
            this.m_txtSex = new System.Windows.Forms.Label();
            this.m_txtIDCARD_CHR = new System.Windows.Forms.Label();
            this.m_txtPatientName = new System.Windows.Forms.Label();
            this.m_txtInsuranceID = new System.Windows.Forms.Label();
            this.m_txtPATIENTCARDID = new System.Windows.Forms.Label();
            this.m_txtINPatient = new System.Windows.Forms.Label();
            this.m_lsvICD = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.m_txtMaindoctor = new ControlLibrary.txtListView(this.components);
            this.m_txtICD = new System.Windows.Forms.TextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.m_cmdSave = new PinkieControls.ButtonXP();
            this.cmd_colse = new PinkieControls.ButtonXP();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(8, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(754, 445);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(746, 418);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "病人信息";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.m_cboSTATE_INT);
            this.groupBox2.Controls.Add(this.m_txtNurse);
            this.groupBox2.Controls.Add(this.m_txtEat);
            this.groupBox2.Controls.Add(this.m_inAreaDate);
            this.groupBox2.Controls.Add(this.m_lbInAreaDate);
            this.groupBox2.Controls.Add(this.m_txtDIAGNOSE);
            this.groupBox2.Controls.Add(this.m_txtINPATIENT_DAT);
            this.groupBox2.Controls.Add(this.m_txtPaytypeid);
            this.groupBox2.Controls.Add(this.m_txtBIRTH_DAT);
            this.groupBox2.Controls.Add(this.m_txtTYPE_INT);
            this.groupBox2.Controls.Add(this.m_txtHOMEPHONE_VCHR);
            this.groupBox2.Controls.Add(this.m_txtSex);
            this.groupBox2.Controls.Add(this.m_txtIDCARD_CHR);
            this.groupBox2.Controls.Add(this.m_txtPatientName);
            this.groupBox2.Controls.Add(this.m_txtInsuranceID);
            this.groupBox2.Controls.Add(this.m_txtPATIENTCARDID);
            this.groupBox2.Controls.Add(this.m_txtINPatient);
            this.groupBox2.Controls.Add(this.m_lsvICD);
            this.groupBox2.Controls.Add(this.m_txtMaindoctor);
            this.groupBox2.Controls.Add(this.m_txtICD);
            this.groupBox2.Controls.Add(this.label52);
            this.groupBox2.Controls.Add(this.label56);
            this.groupBox2.Controls.Add(this.label54);
            this.groupBox2.Controls.Add(this.label57);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label40);
            this.groupBox2.Controls.Add(this.label35);
            this.groupBox2.Controls.Add(this.label41);
            this.groupBox2.Controls.Add(this.label37);
            this.groupBox2.Controls.Add(this.label38);
            this.groupBox2.Controls.Add(this.label34);
            this.groupBox2.Controls.Add(this.label39);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(746, 418);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(461, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 298;
            this.label2.Text = "饮　　食";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(244, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 297;
            this.label1.Text = "护　　理";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_cboSTATE_INT
            // 
            this.m_cboSTATE_INT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboSTATE_INT.Items.AddRange(new object[] {
            "",
            "1-危",
            "2-急",
            "3-普通"});
            this.m_cboSTATE_INT.Location = new System.Drawing.Point(79, 131);
            this.m_cboSTATE_INT.Name = "m_cboSTATE_INT";
            this.m_cboSTATE_INT.Size = new System.Drawing.Size(147, 22);
            this.m_cboSTATE_INT.TabIndex = 0;
            // 
            // m_txtNurse
            // 
            this.m_txtNurse.findDataMode = ControlLibrary.txtListView.findMode.fromListView;
            this.m_txtNurse.Location = new System.Drawing.Point(310, 165);
            this.m_txtNurse.m_blnFocuseShow = true;
            this.m_txtNurse.m_blnPagination = false;
            this.m_txtNurse.m_dtbDataSourse = null;
            this.m_txtNurse.m_intDelayTime = 100;
            this.m_txtNurse.m_intPageRows = 10;
            this.m_txtNurse.m_ListViewAlign = ControlLibrary.txtListView.ListViewAlign.LeftBottom;
            this.m_txtNurse.m_listViewSize = new System.Drawing.Point(200, 100);
            this.m_txtNurse.m_strFieldsArr = new string[] {
        "USERCODE_CHR",
        "NAME_CHR",
        "PYCODE_CHR"};
            this.m_txtNurse.m_strSaveField = "ORDERDICID_CHR";
            this.m_txtNurse.m_strShowField = "NAME_CHR";
            this.m_txtNurse.m_strSQL = null;
            this.m_txtNurse.Name = "m_txtNurse";
            this.m_txtNurse.Size = new System.Drawing.Size(146, 23);
            this.m_txtNurse.TabIndex = 2;
            // 
            // m_txtEat
            // 
            this.m_txtEat.findDataMode = ControlLibrary.txtListView.findMode.fromListView;
            this.m_txtEat.Location = new System.Drawing.Point(526, 165);
            this.m_txtEat.m_blnFocuseShow = true;
            this.m_txtEat.m_blnPagination = false;
            this.m_txtEat.m_dtbDataSourse = null;
            this.m_txtEat.m_intDelayTime = 100;
            this.m_txtEat.m_intPageRows = 10;
            this.m_txtEat.m_ListViewAlign = ControlLibrary.txtListView.ListViewAlign.LeftBottom;
            this.m_txtEat.m_listViewSize = new System.Drawing.Point(200, 100);
            this.m_txtEat.m_strFieldsArr = new string[] {
        "USERCODE_CHR",
        "NAME_CHR",
        "PYCODE_CHR"};
            this.m_txtEat.m_strSaveField = "ORDERDICID_CHR";
            this.m_txtEat.m_strShowField = "NAME_CHR";
            this.m_txtEat.m_strSQL = null;
            this.m_txtEat.Name = "m_txtEat";
            this.m_txtEat.Size = new System.Drawing.Size(146, 23);
            this.m_txtEat.TabIndex = 3;
            // 
            // m_inAreaDate
            // 
            this.m_inAreaDate.Location = new System.Drawing.Point(80, 203);
            this.m_inAreaDate.Mask = "yyyy年MM月dd日HH时mm分";
            this.m_inAreaDate.Name = "m_inAreaDate";
            this.m_inAreaDate.Size = new System.Drawing.Size(172, 23);
            this.m_inAreaDate.TabIndex = 4;

            // 
            // m_lbInAreaDate
            // 
            this.m_lbInAreaDate.AutoSize = true;
            this.m_lbInAreaDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lbInAreaDate.Location = new System.Drawing.Point(16, 208);
            this.m_lbInAreaDate.Name = "m_lbInAreaDate";
            this.m_lbInAreaDate.Size = new System.Drawing.Size(63, 14);
            this.m_lbInAreaDate.TabIndex = 296;
            this.m_lbInAreaDate.Text = "入区时间";
            this.m_lbInAreaDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtDIAGNOSE
            // 
            this.m_txtDIAGNOSE.findDataMode = ControlLibrary.txtListView.findMode.fromListView;
            this.m_txtDIAGNOSE.Location = new System.Drawing.Point(80, 244);
            this.m_txtDIAGNOSE.m_blnFocuseShow = true;
            this.m_txtDIAGNOSE.m_blnPagination = false;
            this.m_txtDIAGNOSE.m_dtbDataSourse = null;
            this.m_txtDIAGNOSE.m_intDelayTime = 100;
            this.m_txtDIAGNOSE.m_intPageRows = 10;
            this.m_txtDIAGNOSE.m_ListViewAlign = ControlLibrary.txtListView.ListViewAlign.LeftBottom;
            this.m_txtDIAGNOSE.m_listViewSize = new System.Drawing.Point(210, 100);
            this.m_txtDIAGNOSE.m_strFieldsArr = new string[] {
        "empno_chr",
        "pycode_chr",
        "doctorname"};
            this.m_txtDIAGNOSE.m_strSaveField = "dmcode";
            this.m_txtDIAGNOSE.m_strShowField = "zhsm";
            this.m_txtDIAGNOSE.m_strSQL = null;
            this.m_txtDIAGNOSE.Name = "m_txtDIAGNOSE";
            this.m_txtDIAGNOSE.Size = new System.Drawing.Size(592, 23);
            this.m_txtDIAGNOSE.TabIndex = 5;
            // 
            // m_txtINPATIENT_DAT
            // 
            this.m_txtINPATIENT_DAT.BackColor = System.Drawing.SystemColors.Control;
            this.m_txtINPATIENT_DAT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_txtINPATIENT_DAT.Location = new System.Drawing.Point(526, 130);
            this.m_txtINPATIENT_DAT.Name = "m_txtINPATIENT_DAT";
            this.m_txtINPATIENT_DAT.Size = new System.Drawing.Size(146, 23);
            this.m_txtINPATIENT_DAT.TabIndex = 293;
            // 
            // m_txtPaytypeid
            // 
            this.m_txtPaytypeid.BackColor = System.Drawing.SystemColors.Control;
            this.m_txtPaytypeid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_txtPaytypeid.Location = new System.Drawing.Point(526, 95);
            this.m_txtPaytypeid.Name = "m_txtPaytypeid";
            this.m_txtPaytypeid.Size = new System.Drawing.Size(146, 23);
            this.m_txtPaytypeid.TabIndex = 292;
            // 
            // m_txtBIRTH_DAT
            // 
            this.m_txtBIRTH_DAT.BackColor = System.Drawing.SystemColors.Control;
            this.m_txtBIRTH_DAT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_txtBIRTH_DAT.Location = new System.Drawing.Point(526, 60);
            this.m_txtBIRTH_DAT.Name = "m_txtBIRTH_DAT";
            this.m_txtBIRTH_DAT.Size = new System.Drawing.Size(146, 23);
            this.m_txtBIRTH_DAT.TabIndex = 291;
            // 
            // m_txtTYPE_INT
            // 
            this.m_txtTYPE_INT.BackColor = System.Drawing.SystemColors.Control;
            this.m_txtTYPE_INT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_txtTYPE_INT.Location = new System.Drawing.Point(310, 130);
            this.m_txtTYPE_INT.Name = "m_txtTYPE_INT";
            this.m_txtTYPE_INT.Size = new System.Drawing.Size(146, 23);
            this.m_txtTYPE_INT.TabIndex = 289;
            // 
            // m_txtHOMEPHONE_VCHR
            // 
            this.m_txtHOMEPHONE_VCHR.BackColor = System.Drawing.SystemColors.Control;
            this.m_txtHOMEPHONE_VCHR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_txtHOMEPHONE_VCHR.Location = new System.Drawing.Point(310, 95);
            this.m_txtHOMEPHONE_VCHR.Name = "m_txtHOMEPHONE_VCHR";
            this.m_txtHOMEPHONE_VCHR.Size = new System.Drawing.Size(146, 23);
            this.m_txtHOMEPHONE_VCHR.TabIndex = 288;
            // 
            // m_txtSex
            // 
            this.m_txtSex.BackColor = System.Drawing.SystemColors.Control;
            this.m_txtSex.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_txtSex.Location = new System.Drawing.Point(310, 60);
            this.m_txtSex.Name = "m_txtSex";
            this.m_txtSex.Size = new System.Drawing.Size(146, 23);
            this.m_txtSex.TabIndex = 287;
            // 
            // m_txtIDCARD_CHR
            // 
            this.m_txtIDCARD_CHR.BackColor = System.Drawing.SystemColors.Control;
            this.m_txtIDCARD_CHR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_txtIDCARD_CHR.Location = new System.Drawing.Point(80, 95);
            this.m_txtIDCARD_CHR.Name = "m_txtIDCARD_CHR";
            this.m_txtIDCARD_CHR.Size = new System.Drawing.Size(146, 23);
            this.m_txtIDCARD_CHR.TabIndex = 285;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.BackColor = System.Drawing.SystemColors.Control;
            this.m_txtPatientName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_txtPatientName.Location = new System.Drawing.Point(80, 60);
            this.m_txtPatientName.Name = "m_txtPatientName";
            this.m_txtPatientName.Size = new System.Drawing.Size(146, 23);
            this.m_txtPatientName.TabIndex = 284;
            // 
            // m_txtInsuranceID
            // 
            this.m_txtInsuranceID.BackColor = System.Drawing.SystemColors.Control;
            this.m_txtInsuranceID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_txtInsuranceID.Location = new System.Drawing.Point(526, 25);
            this.m_txtInsuranceID.Name = "m_txtInsuranceID";
            this.m_txtInsuranceID.Size = new System.Drawing.Size(146, 23);
            this.m_txtInsuranceID.TabIndex = 283;
            // 
            // m_txtPATIENTCARDID
            // 
            this.m_txtPATIENTCARDID.BackColor = System.Drawing.SystemColors.Control;
            this.m_txtPATIENTCARDID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_txtPATIENTCARDID.Location = new System.Drawing.Point(310, 25);
            this.m_txtPATIENTCARDID.Name = "m_txtPATIENTCARDID";
            this.m_txtPATIENTCARDID.Size = new System.Drawing.Size(146, 23);
            this.m_txtPATIENTCARDID.TabIndex = 282;
            // 
            // m_txtINPatient
            // 
            this.m_txtINPatient.BackColor = System.Drawing.SystemColors.Control;
            this.m_txtINPatient.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_txtINPatient.Location = new System.Drawing.Point(80, 25);
            this.m_txtINPatient.Name = "m_txtINPatient";
            this.m_txtINPatient.Size = new System.Drawing.Size(146, 23);
            this.m_txtINPatient.TabIndex = 1;
            // 
            // m_lsvICD
            // 
            this.m_lsvICD.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.m_lsvICD.FullRowSelect = true;
            this.m_lsvICD.GridLines = true;
            this.m_lsvICD.HideSelection = false;
            this.m_lsvICD.Location = new System.Drawing.Point(79, 311);
            this.m_lsvICD.MultiSelect = false;
            this.m_lsvICD.Name = "m_lsvICD";
            this.m_lsvICD.Size = new System.Drawing.Size(592, 103);
            this.m_lsvICD.TabIndex = 17;
            this.m_lsvICD.UseCompatibleStateImageBehavior = false;
            this.m_lsvICD.View = System.Windows.Forms.View.Details;
            this.m_lsvICD.Visible = false;
            this.m_lsvICD.DoubleClick += new System.EventHandler(this.m_lsvICD_DoubleClick);
            this.m_lsvICD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_lsvICD_KeyDown);
            this.m_lsvICD.Leave += new System.EventHandler(this.m_lsvICD_Leave);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "    编号  ";
            this.columnHeader1.Width = 108;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "                 诊断名称(ICD10)  ";
            this.columnHeader2.Width = 345;
            // 
            // m_txtMaindoctor
            // 
            this.m_txtMaindoctor.findDataMode = ControlLibrary.txtListView.findMode.fromListView;
            this.m_txtMaindoctor.Location = new System.Drawing.Point(80, 165);
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
            this.m_txtMaindoctor.Size = new System.Drawing.Size(146, 23);
            this.m_txtMaindoctor.TabIndex = 1;
            // 
            // m_txtICD
            // 
            this.m_txtICD.Location = new System.Drawing.Point(80, 287);
            this.m_txtICD.MaxLength = 25;
            this.m_txtICD.Name = "m_txtICD";
            this.m_txtICD.Size = new System.Drawing.Size(591, 23);
            this.m_txtICD.TabIndex = 6;
            this.m_txtICD.DoubleClick += new System.EventHandler(this.m_txtICD_DoubleClick);
            this.m_txtICD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtICD_KeyDown);
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(14, 169);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(63, 14);
            this.label52.TabIndex = 281;
            this.label52.Text = "主治医生";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Font = new System.Drawing.Font("宋体", 9F);
            this.label56.Location = new System.Drawing.Point(24, 308);
            this.label56.Name = "label56";
            this.label56.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label56.Size = new System.Drawing.Size(47, 12);
            this.label56.TabIndex = 155;
            this.label56.Text = "(ICD10)";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(14, 291);
            this.label54.Name = "label54";
            this.label54.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label54.Size = new System.Drawing.Size(63, 14);
            this.label54.TabIndex = 156;
            this.label54.Text = "入院诊断";
            this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label57.Location = new System.Drawing.Point(26, 262);
            this.label57.Name = "label57";
            this.label57.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label57.Size = new System.Drawing.Size(41, 12);
            this.label57.TabIndex = 157;
            this.label57.Text = "(医保)";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(14, 243);
            this.label15.Name = "label15";
            this.label15.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label15.Size = new System.Drawing.Size(63, 14);
            this.label15.TabIndex = 154;
            this.label15.Text = "入院诊断";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(461, 98);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(63, 14);
            this.label40.TabIndex = 147;
            this.label40.Text = "费用类别";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(244, 98);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(63, 14);
            this.label35.TabIndex = 146;
            this.label35.Text = "联系电话";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(461, 64);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(63, 14);
            this.label41.TabIndex = 144;
            this.label41.Text = "出生年月";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(244, 64);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(63, 14);
            this.label37.TabIndex = 143;
            this.label37.Text = "性　　别";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(17, 64);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(63, 14);
            this.label38.TabIndex = 141;
            this.label38.Text = "病人姓名";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label34.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label34.Location = new System.Drawing.Point(461, 29);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(63, 14);
            this.label34.TabIndex = 139;
            this.label34.Text = "医保编号";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label39.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label39.Location = new System.Drawing.Point(244, 29);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(63, 14);
            this.label39.TabIndex = 136;
            this.label39.Text = "诊疗卡号";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(461, 136);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(63, 14);
            this.label21.TabIndex = 126;
            this.label21.Text = "入院日期";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(14, 136);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(63, 14);
            this.label17.TabIndex = 122;
            this.label17.Text = "病　　情";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(244, 136);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 14);
            this.label10.TabIndex = 111;
            this.label10.Text = "入院方式";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(17, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 14);
            this.label11.TabIndex = 136;
            this.label11.Text = "住 院 号";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 98);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 14);
            this.label12.TabIndex = 146;
            this.label12.Text = "身份证号";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_cmdSave
            // 
            this.m_cmdSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdSave.DefaultScheme = true;
            this.m_cmdSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSave.Font = new System.Drawing.Font("宋体", 10F);
            this.m_cmdSave.Hint = "";
            this.m_cmdSave.Location = new System.Drawing.Point(520, 463);
            this.m_cmdSave.Name = "m_cmdSave";
            this.m_cmdSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.m_cmdSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSave.Size = new System.Drawing.Size(80, 28);
            this.m_cmdSave.TabIndex = 18;
            this.m_cmdSave.Text = "保存(F2)";
            this.m_cmdSave.Click += new System.EventHandler(this.m_cmdSave_Click);
            // 
            // cmd_colse
            // 
            this.cmd_colse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmd_colse.DefaultScheme = true;
            this.cmd_colse.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmd_colse.Font = new System.Drawing.Font("宋体", 10F);
            this.cmd_colse.Hint = "";
            this.cmd_colse.Location = new System.Drawing.Point(621, 464);
            this.cmd_colse.Name = "cmd_colse";
            this.cmd_colse.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmd_colse.Size = new System.Drawing.Size(80, 28);
            this.cmd_colse.TabIndex = 19;
            this.cmd_colse.Text = "关闭(Esc)";
            this.cmd_colse.Click += new System.EventHandler(this.cmd_colse_Click);
            // 
            // frmEditBed
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(764, 499);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.m_cmdSave);
            this.Controls.Add(this.cmd_colse);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(200, 187);
            this.MaximizeBox = false;
            this.Name = "frmEditBed";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "病人详细信息";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmEditBed_KeyDown);
            this.Load += new System.EventHandler(this.frmEditBed_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		#region	设置窗体控制器
		public override void CreateController()
		{
			this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_EditBed();
			objController.Set_GUI_Apperance(this);
		}
		#endregion

		#region 初始化数据
		private void frmEditBed_Load(object sender, System.EventArgs e)
		{
            m_mthSetEnter2Tab(new System.Windows.Forms.Control[] { m_txtICD, m_txtMaindoctor, m_txtDIAGNOSE, m_txtNurse, m_txtEat });
            ((clsCtl_EditBed)this.objController).m_mthInit();
            //this.m_txtMaindoctor.Focus();
		}

		private void frmEditBed_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			m_mthSetKeyTab(e);
			if(e.Modifiers == Keys.Control && e.KeyCode == Keys.D1)
			{
				tabControl1.SelectedIndex = 0;
				return;
			}
			if(e.Modifiers == Keys.Control && e.KeyCode == Keys.D2)
			{
				tabControl1.SelectedIndex = 1;
				return;
			}
			switch (e.KeyCode)
			{
				case Keys.Escape:
					if(MessageBox.Show("确定退出么?","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
					{
						this.Close();
					}
					break;
				case Keys.F2:
					if(tabControl1.SelectedIndex == 0)
					{
						if(this.Isoccupied)
						{
							((clsCtl_EditBed)this.objController).m_thSaveInHospInfo();
						}
					}
					else
					{
						m_cmdSave_Click(sender,e);	
					}
					break;
				default:
					break;
			}
		}
		#endregion
		
		#region 关门窗体
		private void cmd_colse_Click(object sender, System.EventArgs e)
		{
            this.DialogResult = DialogResult.No;
		}
		#endregion

		#region 保存住院信息
		private void m_cmdSave_Click(object sender, System.EventArgs e)
        {
            if (this.m_inAreaDate.Value > DateTime.Now.AddYears(100) || this.m_inAreaDate.Value < DateTime.Now.AddYears(-100))
            {
                MessageBox.Show("请不要输入非法时间!", "iCare系统温馨提示：", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                this.m_inAreaDate.Focus();
                return;
            }
            ((clsCtl_EditBed)this.objController).m_thSaveInHospInfo();
        }
		#endregion
		
		#region 处理入院诊断(ICD10)
		/// <summary>
		/// 查询字符串
		/// </summary>
		string p_strFind;
		
		private void m_txtICD_DoubleClick(object sender, System.EventArgs e)
		{
			p_strFind = m_txtICD.Text.Trim();
			((clsCtl_EditBed)this.objController).m_mthFindICD10Info();
		}

		private void m_txtICD_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Enter:
					if(m_txtICD.Text.Trim().Equals(p_strFind))
					{
						if(m_lsvICD.Visible == true)
						{
							((clsCtl_EditBed)this.objController).m_mthSelectedProtectPatien();
						}
						else
						{
							p_strFind = m_txtICD.Text.Trim();
							((clsCtl_EditBed)this.objController).m_mthFindICD10Info();
						}
					}
					else
					{
						p_strFind = m_txtICD.Text.Trim();
						((clsCtl_EditBed)this.objController).m_mthFindICD10Info();
					}
					break;
				case Keys.Up:
					((clsCtl_EditBed)this.objController).m_mthSelectProtectPactien(1);
					break;
				case Keys.Down:
					((clsCtl_EditBed)this.objController).m_mthSelectProtectPactien(0);
					break;
			}
		}

		private void m_lsvICD_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(m_lsvICD.SelectedItems.Count>0&&e.KeyCode==Keys.Enter)
			{
				m_txtICD.Tag = m_lsvICD.SelectedItems[0].SubItems[0].Text.Trim();
				m_txtICD.Text = m_lsvICD.SelectedItems[0].SubItems[1].Text.Trim();
				m_lsvICD.Visible=false;
			}
		}

		private void m_lsvICD_DoubleClick(object sender, System.EventArgs e)
		{
			if(m_lsvICD.SelectedItems.Count>0)
			{
				m_txtICD.Tag = m_lsvICD.SelectedItems[0].SubItems[0].Text.Trim();
				m_txtICD.Text = m_lsvICD.SelectedItems[0].SubItems[1].Text.Trim();
				m_lsvICD.Visible=false;
			}
		}

		private void m_lsvICD_Leave(object sender, System.EventArgs e)
		{
			m_lsvICD.Visible = false;
		}
		#endregion
	}
}
