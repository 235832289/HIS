using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using iCareData;
using com.digitalwave.Emr.Signature_gui;
namespace iCare
{
	/// <summary>
	/// frmMiniBooldSugarChk_GX 的摘要说明。
	/// </summary>
	public class frmMiniBooldSugarChk_GX : iCare.frmHRPBaseForm,PublicFunction
	{
		private System.Windows.Forms.Label label6;
        protected com.digitalwave.Utility.Controls.ctlTimePicker m_dtpCreateDate;
		private System.Windows.Forms.GroupBox m_gpbResult;
		private System.Windows.Forms.ListView m_lsvResult;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.GroupBox m_gpbEdit;
		private PinkieControls.ButtonXP m_cmdModify;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private PinkieControls.ButtonXP m_cmdAddNew;
		private System.Windows.Forms.TextBox m_txtCONTENT_LIMOSIS;
		private System.Windows.Forms.TextBox m_txtCONTENT_BREAKFAST2H;
		private System.Windows.Forms.TextBox m_txtCONTENT_BEFORELUNCH11AM;
		private System.Windows.Forms.TextBox m_txtCONTENT_AFTERLUNCH2H;
		private System.Windows.Forms.TextBox m_txtCONTENT_BEFORESUPPER5PM;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox m_txtCONTENT_WEEHOURS0AM;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox m_txtCONTENT_WEEHOURS3AM;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox m_txtCONTENT_RANDOM;

		private ListViewItem m_lsiCurItem;
		private clsMiniBloodSugarChkValue_GX m_objCurValue;
		private clsMiniBooldSugarChk_GXDomin m_objDomain;
		private string m_strDateFormat = "yyyy-MM-dd";
		private bool m_blnIsAddNew = true;
		private System.Windows.Forms.ContextMenu ctmResult;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
        private Label label12;
        private TextBox m_txtCustom1;
        private Label label13;
        private TextBox m_txtCustom2;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader11;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmMiniBooldSugarChk_GX()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			new clsSortTool().m_mthSetListViewSortable(m_lsvResult);
			m_objDomain = new clsMiniBooldSugarChk_GXDomin();
			m_mthInit();
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
            this.label6 = new System.Windows.Forms.Label();
            this.m_dtpCreateDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.m_gpbResult = new System.Windows.Forms.GroupBox();
            this.m_lsvResult = new System.Windows.Forms.ListView();
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
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.ctmResult = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.m_gpbEdit = new System.Windows.Forms.GroupBox();
            this.m_cmdModify = new PinkieControls.ButtonXP();
            this.m_cmdAddNew = new PinkieControls.ButtonXP();
            this.m_txtCONTENT_BEFORESUPPER5PM = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.m_txtCONTENT_WEEHOURS0AM = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.m_txtCustom1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.m_txtCONTENT_WEEHOURS3AM = new System.Windows.Forms.TextBox();
            this.m_txtCustom2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.m_txtCONTENT_RANDOM = new System.Windows.Forms.TextBox();
            this.m_txtCONTENT_LIMOSIS = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtCONTENT_BREAKFAST2H = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_txtCONTENT_BEFORELUNCH11AM = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_txtCONTENT_AFTERLUNCH2H = new System.Windows.Forms.TextBox();
            this.m_pnlNewBase.SuspendLayout();
            this.m_gpbResult.SuspendLayout();
            this.m_gpbEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(642, 75);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(730, 75);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(236, 75);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(224, 99);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(435, 75);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(602, 75);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(692, 75);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(16, 100);
            this.lblAreaTitle.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(280, 98);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(478, 73);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(280, 73);
            this.m_txtBedNO.Size = new System.Drawing.Size(88, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(64, 98);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(452, 116);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(280, 116);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(64, 73);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(16, 75);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(704, 82);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.m_cmdNext.Location = new System.Drawing.Point(372, 75);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(156, 67);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(424, -2);
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(580, 37);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(713, 37);
            this.m_cmdModifyPatientInfo.Size = new System.Drawing.Size(69, 28);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Visible = true;
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(406, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 14);
            this.label6.TabIndex = 10000094;
            this.label6.Text = "记录时间:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.BorderColor = System.Drawing.Color.Black;
            this.m_dtpCreateDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpCreateDate.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_dtpCreateDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpCreateDate.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpCreateDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpCreateDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_dtpCreateDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpCreateDate.Location = new System.Drawing.Point(478, 40);
            this.m_dtpCreateDate.m_BlnOnlyTime = false;
            this.m_dtpCreateDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpCreateDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpCreateDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpCreateDate.Name = "m_dtpCreateDate";
            this.m_dtpCreateDate.ReadOnly = false;
            this.m_dtpCreateDate.Size = new System.Drawing.Size(212, 22);
            this.m_dtpCreateDate.TabIndex = 10000093;
            this.m_dtpCreateDate.TextBackColor = System.Drawing.Color.White;
            this.m_dtpCreateDate.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_gpbResult
            // 
            this.m_gpbResult.Controls.Add(this.m_lsvResult);
            this.m_gpbResult.Location = new System.Drawing.Point(10, 69);
            this.m_gpbResult.Name = "m_gpbResult";
            this.m_gpbResult.Size = new System.Drawing.Size(810, 432);
            this.m_gpbResult.TabIndex = 10000096;
            this.m_gpbResult.TabStop = false;
            this.m_gpbResult.Text = "记录列表";
            // 
            // m_lsvResult
            // 
            this.m_lsvResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11});
            this.m_lsvResult.ContextMenu = this.ctmResult;
            this.m_lsvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvResult.FullRowSelect = true;
            this.m_lsvResult.GridLines = true;
            this.m_lsvResult.Location = new System.Drawing.Point(3, 19);
            this.m_lsvResult.MultiSelect = false;
            this.m_lsvResult.Name = "m_lsvResult";
            this.m_lsvResult.Size = new System.Drawing.Size(804, 410);
            this.m_lsvResult.TabIndex = 750;
            this.m_lsvResult.UseCompatibleStateImageBehavior = false;
            this.m_lsvResult.View = System.Windows.Forms.View.Details;
            this.m_lsvResult.DoubleClick += new System.EventHandler(this.m_lsvResult_DoubleClick);
            this.m_lsvResult.SelectedIndexChanged += new System.EventHandler(this.m_lsvResult_SelectedIndexChanged);
            this.m_lsvResult.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.m_lsvResult_ColumnClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "日   期";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "空腹(mmol/L)";
            this.columnHeader2.Width = 140;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "早餐2H(mmol/L)";
            this.columnHeader3.Width = 140;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "中餐前11am(mmol/L)";
            this.columnHeader4.Width = 140;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "中餐后2h(mmol/L)";
            this.columnHeader5.Width = 140;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "晚餐前5pm(mmol/L)";
            this.columnHeader6.Width = 140;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "凌晨0am(mmol/L)";
            this.columnHeader7.Width = 140;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "凌晨3am(mmol/L)";
            this.columnHeader8.Width = 140;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "随机血糖(mmol/L)";
            this.columnHeader9.Width = 140;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "";
            this.columnHeader10.Width = 140;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "";
            this.columnHeader11.Width = 140;
            // 
            // ctmResult
            // 
            this.ctmResult.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "修改";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "删除";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // m_gpbEdit
            // 
            this.m_gpbEdit.Controls.Add(this.m_cmdModify);
            this.m_gpbEdit.Controls.Add(this.m_cmdAddNew);
            this.m_gpbEdit.Controls.Add(this.m_txtCONTENT_BEFORESUPPER5PM);
            this.m_gpbEdit.Controls.Add(this.label7);
            this.m_gpbEdit.Controls.Add(this.label8);
            this.m_gpbEdit.Controls.Add(this.m_txtCONTENT_WEEHOURS0AM);
            this.m_gpbEdit.Controls.Add(this.label12);
            this.m_gpbEdit.Controls.Add(this.m_txtCustom1);
            this.m_gpbEdit.Controls.Add(this.label9);
            this.m_gpbEdit.Controls.Add(this.label13);
            this.m_gpbEdit.Controls.Add(this.m_txtCONTENT_WEEHOURS3AM);
            this.m_gpbEdit.Controls.Add(this.m_txtCustom2);
            this.m_gpbEdit.Controls.Add(this.label10);
            this.m_gpbEdit.Controls.Add(this.m_txtCONTENT_RANDOM);
            this.m_gpbEdit.Controls.Add(this.m_txtCONTENT_LIMOSIS);
            this.m_gpbEdit.Controls.Add(this.label2);
            this.m_gpbEdit.Controls.Add(this.label3);
            this.m_gpbEdit.Controls.Add(this.m_txtCONTENT_BREAKFAST2H);
            this.m_gpbEdit.Controls.Add(this.label4);
            this.m_gpbEdit.Controls.Add(this.m_txtCONTENT_BEFORELUNCH11AM);
            this.m_gpbEdit.Controls.Add(this.label5);
            this.m_gpbEdit.Controls.Add(this.m_txtCONTENT_AFTERLUNCH2H);
            this.m_gpbEdit.Location = new System.Drawing.Point(8, 503);
            this.m_gpbEdit.Name = "m_gpbEdit";
            this.m_gpbEdit.Size = new System.Drawing.Size(812, 105);
            this.m_gpbEdit.TabIndex = 10000097;
            this.m_gpbEdit.TabStop = false;
            this.m_gpbEdit.Text = "编辑";
            // 
            // m_cmdModify
            // 
            this.m_cmdModify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdModify.DefaultScheme = true;
            this.m_cmdModify.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdModify.Enabled = false;
            this.m_cmdModify.Hint = "";
            this.m_cmdModify.Location = new System.Drawing.Point(610, 74);
            this.m_cmdModify.Name = "m_cmdModify";
            this.m_cmdModify.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdModify.Size = new System.Drawing.Size(83, 28);
            this.m_cmdModify.TabIndex = 1400;
            this.m_cmdModify.Text = "修改";
            this.m_cmdModify.Click += new System.EventHandler(this.m_cmdModify_Click);
            // 
            // m_cmdAddNew
            // 
            this.m_cmdAddNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdAddNew.DefaultScheme = true;
            this.m_cmdAddNew.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdAddNew.Hint = "";
            this.m_cmdAddNew.Location = new System.Drawing.Point(713, 74);
            this.m_cmdAddNew.Name = "m_cmdAddNew";
            this.m_cmdAddNew.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdAddNew.Size = new System.Drawing.Size(89, 28);
            this.m_cmdAddNew.TabIndex = 1300;
            this.m_cmdAddNew.Text = "添加";
            this.m_cmdAddNew.Click += new System.EventHandler(this.m_cmdAddNew_Click);
            // 
            // m_txtCONTENT_BEFORESUPPER5PM
            // 
            this.m_txtCONTENT_BEFORESUPPER5PM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtCONTENT_BEFORESUPPER5PM.Location = new System.Drawing.Point(322, 51);
            this.m_txtCONTENT_BEFORESUPPER5PM.MaxLength = 20;
            this.m_txtCONTENT_BEFORESUPPER5PM.Name = "m_txtCONTENT_BEFORESUPPER5PM";
            this.m_txtCONTENT_BEFORESUPPER5PM.Size = new System.Drawing.Size(80, 23);
            this.m_txtCONTENT_BEFORESUPPER5PM.TabIndex = 1210;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(322, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 33);
            this.label7.TabIndex = 1404;
            this.label7.Text = "晚餐前5pm  (mmol/L)";
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Location = new System.Drawing.Point(401, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 33);
            this.label8.TabIndex = 1403;
            this.label8.Text = "凌晨0am  (mmol/L)";
            // 
            // m_txtCONTENT_WEEHOURS0AM
            // 
            this.m_txtCONTENT_WEEHOURS0AM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtCONTENT_WEEHOURS0AM.Location = new System.Drawing.Point(401, 51);
            this.m_txtCONTENT_WEEHOURS0AM.MaxLength = 20;
            this.m_txtCONTENT_WEEHOURS0AM.Name = "m_txtCONTENT_WEEHOURS0AM";
            this.m_txtCONTENT_WEEHOURS0AM.Size = new System.Drawing.Size(80, 23);
            this.m_txtCONTENT_WEEHOURS0AM.TabIndex = 1220;
            // 
            // label12
            // 
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Location = new System.Drawing.Point(638, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 33);
            this.label12.TabIndex = 1402;
            this.label12.Text = "自定义列1";
            this.label12.DoubleClick += new System.EventHandler(this.label12_DoubleClick);
            // 
            // m_txtCustom1
            // 
            this.m_txtCustom1.AccessibleDescription = "自定义列1";
            this.m_txtCustom1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtCustom1.Location = new System.Drawing.Point(638, 51);
            this.m_txtCustom1.MaxLength = 20;
            this.m_txtCustom1.Name = "m_txtCustom1";
            this.m_txtCustom1.Size = new System.Drawing.Size(80, 23);
            this.m_txtCustom1.TabIndex = 1250;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Location = new System.Drawing.Point(480, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 33);
            this.label9.TabIndex = 1402;
            this.label9.Text = "凌晨3am  (mmol/L)";
            // 
            // label13
            // 
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Location = new System.Drawing.Point(717, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 33);
            this.label13.TabIndex = 1401;
            this.label13.Text = "自定义列2";
            this.label13.DoubleClick += new System.EventHandler(this.label13_DoubleClick);
            // 
            // m_txtCONTENT_WEEHOURS3AM
            // 
            this.m_txtCONTENT_WEEHOURS3AM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtCONTENT_WEEHOURS3AM.Location = new System.Drawing.Point(480, 51);
            this.m_txtCONTENT_WEEHOURS3AM.MaxLength = 20;
            this.m_txtCONTENT_WEEHOURS3AM.Name = "m_txtCONTENT_WEEHOURS3AM";
            this.m_txtCONTENT_WEEHOURS3AM.Size = new System.Drawing.Size(80, 23);
            this.m_txtCONTENT_WEEHOURS3AM.TabIndex = 1230;
            // 
            // m_txtCustom2
            // 
            this.m_txtCustom2.AccessibleDescription = "自定义列2";
            this.m_txtCustom2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtCustom2.Location = new System.Drawing.Point(717, 51);
            this.m_txtCustom2.MaxLength = 20;
            this.m_txtCustom2.Name = "m_txtCustom2";
            this.m_txtCustom2.Size = new System.Drawing.Size(80, 23);
            this.m_txtCustom2.TabIndex = 1260;
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Location = new System.Drawing.Point(559, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 33);
            this.label10.TabIndex = 1401;
            this.label10.Text = "随机血糖(mmol/L)";
            // 
            // m_txtCONTENT_RANDOM
            // 
            this.m_txtCONTENT_RANDOM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtCONTENT_RANDOM.Location = new System.Drawing.Point(559, 51);
            this.m_txtCONTENT_RANDOM.MaxLength = 20;
            this.m_txtCONTENT_RANDOM.Name = "m_txtCONTENT_RANDOM";
            this.m_txtCONTENT_RANDOM.Size = new System.Drawing.Size(80, 23);
            this.m_txtCONTENT_RANDOM.TabIndex = 1240;
            // 
            // m_txtCONTENT_LIMOSIS
            // 
            this.m_txtCONTENT_LIMOSIS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtCONTENT_LIMOSIS.Location = new System.Drawing.Point(6, 51);
            this.m_txtCONTENT_LIMOSIS.MaxLength = 20;
            this.m_txtCONTENT_LIMOSIS.Name = "m_txtCONTENT_LIMOSIS";
            this.m_txtCONTENT_LIMOSIS.Size = new System.Drawing.Size(80, 23);
            this.m_txtCONTENT_LIMOSIS.TabIndex = 900;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 33);
            this.label2.TabIndex = 0;
            this.label2.Text = "空腹  (mmol/L)";
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(85, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 33);
            this.label3.TabIndex = 0;
            this.label3.Text = "早餐2H  (mmol/L)";
            // 
            // m_txtCONTENT_BREAKFAST2H
            // 
            this.m_txtCONTENT_BREAKFAST2H.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtCONTENT_BREAKFAST2H.Location = new System.Drawing.Point(85, 51);
            this.m_txtCONTENT_BREAKFAST2H.MaxLength = 20;
            this.m_txtCONTENT_BREAKFAST2H.Name = "m_txtCONTENT_BREAKFAST2H";
            this.m_txtCONTENT_BREAKFAST2H.Size = new System.Drawing.Size(80, 23);
            this.m_txtCONTENT_BREAKFAST2H.TabIndex = 1000;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(164, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 33);
            this.label4.TabIndex = 0;
            this.label4.Text = "中餐前11am  (mmol/L)";
            // 
            // m_txtCONTENT_BEFORELUNCH11AM
            // 
            this.m_txtCONTENT_BEFORELUNCH11AM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtCONTENT_BEFORELUNCH11AM.Location = new System.Drawing.Point(164, 51);
            this.m_txtCONTENT_BEFORELUNCH11AM.MaxLength = 20;
            this.m_txtCONTENT_BEFORELUNCH11AM.Name = "m_txtCONTENT_BEFORELUNCH11AM";
            this.m_txtCONTENT_BEFORELUNCH11AM.Size = new System.Drawing.Size(80, 23);
            this.m_txtCONTENT_BEFORELUNCH11AM.TabIndex = 1100;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(243, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 33);
            this.label5.TabIndex = 0;
            this.label5.Text = "中餐后2h  (mmol/L)";
            // 
            // m_txtCONTENT_AFTERLUNCH2H
            // 
            this.m_txtCONTENT_AFTERLUNCH2H.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtCONTENT_AFTERLUNCH2H.Location = new System.Drawing.Point(243, 51);
            this.m_txtCONTENT_AFTERLUNCH2H.MaxLength = 20;
            this.m_txtCONTENT_AFTERLUNCH2H.Name = "m_txtCONTENT_AFTERLUNCH2H";
            this.m_txtCONTENT_AFTERLUNCH2H.Size = new System.Drawing.Size(80, 23);
            this.m_txtCONTENT_AFTERLUNCH2H.TabIndex = 1200;
            // 
            // frmMiniBooldSugarChk_GX
            // 
            this.ClientSize = new System.Drawing.Size(832, 623);
            this.Controls.Add(this.m_gpbEdit);
            this.Controls.Add(this.m_gpbResult);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.m_dtpCreateDate);
            this.Name = "frmMiniBooldSugarChk_GX";
            this.Text = "快速微量血糖检测记录表";
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.m_dtpCreateDate, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.m_gpbResult, 0);
            this.Controls.SetChildIndex(this.m_gpbEdit, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            this.m_gpbResult.ResumeLayout(false);
            this.m_gpbEdit.ResumeLayout(false);
            this.m_gpbEdit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void m_mthInit()
		{
			clsPublicFunction obj = new clsPublicFunction();
			foreach(Control ctl in m_gpbEdit.Controls)
			{
				obj.m_mthSetControlEnter2Tab(ctl);
			}
			m_mthInitRecord();
		}

		private void m_mthInitRecord()
		{
			if(m_objBaseCurrentPatient == null)
				return;
			clsMiniBloodSugarChkValue_GX[] objValues = null;
			long lngRes = m_objDomain.m_lngGetRecoedByInPatient(m_objBaseCurrentPatient.m_StrInPatientID,m_objBaseCurrentPatient.m_DtmSelectedInDate,out objValues);
			if(lngRes <= 0 || objValues == null)
				return;
			m_lsvResult.Items.Clear();
			for(int i=0;i<objValues.Length;i++)
			{
				ListViewItem item = new ListViewItem(new string[]{objValues[i].m_dtmCreateDate.ToString(m_strDateFormat),
																	 objValues[i].m_strCONTENT_LIMOSIS,objValues[i].m_strCONTENT_BREAKFAST2H,
																	 objValues[i].m_strCONTENT_BEFORELUNCH11AM,objValues[i].m_strCONTENT_AFTERLUNCH2H,
																	 objValues[i].m_strCONTENT_BEFORESUPPER5PM,objValues[i].m_strCONTENT_WEEHOURS0AM,
																	 objValues[i].m_strCONTENT_WEEHOURS3AM,objValues[i].m_strCONTENT_RANDOM,
                                                                     objValues[i].m_strCustom1Content,objValues[i].m_strCustom2Content});
				item.Tag = objValues[i];
				m_lsvResult.Items.Add(item);
			}
            m_lsvResult.Columns[9].Text = objValues[0].m_strCustom1Name;
            m_lsvResult.Columns[10].Text = objValues[0].m_strCustom2Name;
            if (objValues[0].m_strCustom1Name != string.Empty)
                label12.Text = objValues[0].m_strCustom1Name;
            if (objValues[0].m_strCustom2Name != string.Empty)
                label13.Text = objValues[0].m_strCustom2Name;
			m_mthClearText();
		}

		private void m_lsvResult_DoubleClick(object sender, System.EventArgs e)
		{
			if(m_lsvResult.SelectedItems.Count <= 0)
				return;
			m_objCurValue = m_lsvResult.SelectedItems[0].Tag as clsMiniBloodSugarChkValue_GX;
			m_lsiCurItem = m_lsvResult.SelectedItems[0];
			m_dtpCreateDate.Value = m_objCurValue.m_dtmCreateDate;

			this.m_txtCONTENT_LIMOSIS.Text = m_objCurValue.m_strCONTENT_LIMOSIS;
			this.m_txtCONTENT_BREAKFAST2H.Text = m_objCurValue.m_strCONTENT_BREAKFAST2H;
			this.m_txtCONTENT_BEFORELUNCH11AM.Text = m_objCurValue.m_strCONTENT_BEFORELUNCH11AM;
			this.m_txtCONTENT_AFTERLUNCH2H.Text = m_objCurValue.m_strCONTENT_AFTERLUNCH2H;
			this.m_txtCONTENT_BEFORESUPPER5PM.Text = m_objCurValue.m_strCONTENT_BEFORESUPPER5PM;
			this.m_txtCONTENT_WEEHOURS0AM.Text = m_objCurValue.m_strCONTENT_WEEHOURS0AM;
			this.m_txtCONTENT_WEEHOURS3AM.Text = m_objCurValue.m_strCONTENT_WEEHOURS3AM;
			this.m_txtCONTENT_RANDOM.Text = m_objCurValue.m_strCONTENT_RANDOM;
            this.m_txtCustom1.Text = m_objCurValue.m_strCustom1Content;
            this.m_txtCustom2.Text = m_objCurValue.m_strCustom2Content;
			m_mthSetEnable(false);
		}

		private void m_mthSetEnable(bool p_blnIsNew)
		{
			m_cmdAddNew.Enabled = p_blnIsNew;
			m_cmdModify.Enabled = !p_blnIsNew;
		}

		private void m_lsvResult_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_lsvResult.SelectedItems.Count <= 0)
			{
				m_dtpCreateDate.Value = DateTime.Now;
				return;
			}
			m_objCurValue = m_lsvResult.SelectedItems[0].Tag as clsMiniBloodSugarChkValue_GX;
			m_lsiCurItem = m_lsvResult.SelectedItems[0];
			m_dtpCreateDate.Value = m_objCurValue.m_dtmCreateDate;
		}

		private void m_cmdModify_Click(object sender, System.EventArgs e)
		{
			m_blnIsAddNew = false;
			Save();
		}

		private void m_cmdAddNew_Click(object sender, System.EventArgs e)
		{
			m_blnIsAddNew = true;
			Save();
		}

		private void m_mthClearText()
		{
			m_txtCONTENT_LIMOSIS.Text = "";
			m_txtCONTENT_BREAKFAST2H.Text = "";
			m_txtCONTENT_BEFORELUNCH11AM.Text = "";
			m_txtCONTENT_AFTERLUNCH2H.Text = "";
			m_txtCONTENT_BEFORESUPPER5PM.Text = "";
			m_txtCONTENT_WEEHOURS0AM.Text = "";
			m_txtCONTENT_WEEHOURS3AM.Text = "";
			m_txtCONTENT_RANDOM.Text = "";
            m_txtCustom1.Text = "";
            m_txtCustom2.Text = "";
			m_dtpCreateDate.Value = DateTime.Now;
			m_txtCONTENT_LIMOSIS.Focus();
			m_mthSetEnable(true);
		}
		private bool m_blnCheckEmpty()
		{
			return m_txtCONTENT_LIMOSIS.Text == ""&&
			m_txtCONTENT_BREAKFAST2H.Text == ""&&
			m_txtCONTENT_BEFORELUNCH11AM.Text == ""&&
			m_txtCONTENT_AFTERLUNCH2H.Text == ""&&
			m_txtCONTENT_BEFORESUPPER5PM.Text == ""&&
			m_txtCONTENT_WEEHOURS0AM.Text == ""&&
			m_txtCONTENT_WEEHOURS3AM.Text == ""&&
			m_txtCONTENT_RANDOM.Text == "" &&
            m_txtCustom1.Text == "" &&
            m_txtCustom2.Text == ""; 
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			m_lsvResult_DoubleClick(m_lsvResult, System.EventArgs.Empty);
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			Delete();
		}

		protected override void m_mthSetPatientFormInfo(clsPatient p_objSelectedPatient)
		{
			m_lsvResult.Items.Clear();
            label12.Text = "自定义列1";
            label13.Text = "自定义列2";
             m_lsvResult.Columns[9].Text = "";
             m_lsvResult.Columns[10].Text = "";
			m_mthClearText();

            m_mthIsReadOnly();
            if (!m_blnCanShowRecordContent())
            {
                clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                return;
            }

			m_mthInitRecord();
		}

		#region  接口
		public void Copy()
		{
			m_lngCopy();
		}

		public void Cut()
		{
			m_lngCut();
		}
		public void Verify()
		{
			//long lngRes=m_lngSignVerify(p_strFormID,p_strRecordID);
		}
		public void Delete()
		{
            //指明表单类型为护理
            intFormType = 2;
			long m_lngRe=m_lngDelete(); 
			if(m_lngRe>0)
			{}

		}

		public void Display()
		{
		
		}

		public void Display(string cardno, string sendcheckdate)
		{
		
		}

		public void Paste()
		{
			m_lngPaste();
		}

		public void Print()
		{
			m_lngPrint(); 
		}

		public void Redo()
		{
		
		}
		public void Undo()
		{
		
		}

		public void Save()
		{
			long m_lngRe=m_lngSave(); 
			if(m_lngRe>0)
			{
			}
		}
		protected override long m_lngSubAddNew()
		{
			if(m_blnCheckEmpty() || m_objBaseCurrentPatient == null)
				return 0;
			for(int i=0; i<m_lsvResult.Items.Count; i++)
			{
				if(((clsMiniBloodSugarChkValue_GX)(m_lsvResult.Items[i].Tag)).m_dtmCreateDate.ToString("yyyy-MM-dd HH:mm:ss")
                    == m_dtpCreateDate.Value.ToString("yyyy-MM-dd HH:mm:ss"))
				{
					MDIParent.ShowInformationMessageBox("在此时间:\r\n"+
						m_dtpCreateDate.Text+
						"\r\n已经记录了一条信息，请重新选择一个时间");
					return 0;
				}
			}

			clsMiniBloodSugarChkValue_GX objValue = new clsMiniBloodSugarChkValue_GX();
			objValue.m_strInPatientID = m_objBaseCurrentPatient.m_StrInPatientID;
			objValue.m_dtmInPatientDate = m_objBaseCurrentPatient.m_DtmSelectedInDate;
			objValue.m_strCreateUserID = MDIParent.strOperatorID;
            objValue.m_dtmCreateDate = Convert.ToDateTime(m_dtpCreateDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
			objValue.m_strCONTENT_LIMOSIS = this.m_txtCONTENT_LIMOSIS.Text.Trim();
			objValue.m_strCONTENT_BREAKFAST2H = this.m_txtCONTENT_BREAKFAST2H.Text.Trim();
			objValue.m_strCONTENT_BEFORELUNCH11AM = this.m_txtCONTENT_BEFORELUNCH11AM.Text.Trim();
			objValue.m_strCONTENT_AFTERLUNCH2H = this.m_txtCONTENT_AFTERLUNCH2H.Text.Trim();
			objValue.m_strCONTENT_BEFORESUPPER5PM = this.m_txtCONTENT_BEFORESUPPER5PM.Text.Trim();
			objValue.m_strCONTENT_WEEHOURS0AM = this.m_txtCONTENT_WEEHOURS0AM.Text.Trim();
			objValue.m_strCONTENT_WEEHOURS3AM = this.m_txtCONTENT_WEEHOURS3AM.Text.Trim();
			objValue.m_strCONTENT_RANDOM = this.m_txtCONTENT_RANDOM.Text.Trim();
            objValue.m_dtmOpenDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            objValue.m_strCustom1Content = this.m_txtCustom1.Text.Trim();
            objValue.m_strCustom2Content = this.m_txtCustom2.Text.Trim();
            if (label12.Text != "自定义列1")
                objValue.m_strCustom1Name = label12.Text.Trim();
            else
                objValue.m_strCustom1Name = "";
            if (label13.Text != "自定义列2")
                objValue.m_strCustom2Name = label13.Text.Trim();
            else
                objValue.m_strCustom2Name = "";
			//电子签名 
			//记录ID通常为 住院号＋住院时间 || 住院号＋记录时间 来识别唯一 格式 00000056-2005-10-10 10:20:20
			clsEmrDigitalSign_VO objSign_VO = new clsEmrDigitalSign_VO();
            objSign_VO.m_strFORMID_VCHR = this.Name;
            objSign_VO.m_strFORMRECORDID_VCHR = objValue.m_strInPatientID.Trim() + "-" + objValue.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"); 
            objSign_VO.m_strSIGNIDID_VCHR = clsEMRLogin.LoginInfo.m_strEmpID;
            objSign_VO.m_strRegisterId = m_objBaseCurrentPatient.m_StrRegisterId;
            clsCheckSignersController objCheck = new clsCheckSignersController();
            if (objCheck.m_lngSign(objValue, objSign_VO) == -1)
                return -1;


			long lngRes = m_objDomain.m_lngAddNewRecoed(objValue);
			if(lngRes <= 0)
			{
				clsPublicFunction.ShowInformationMessageBox("保存失败！");
			}
			else
			{
//				m_objCurValue = objValue;
//				ListViewItem item = new ListViewItem(new string[]{objValue.m_dtmCreatedDate.ToString(m_strDateFormat),
//																	 objValue.m_strCONTENT_LIMOSIS,objValue.m_strCONTENT_BREAKFAST2H,
//																	 objValue.m_strCONTENT_BEFORELUNCH11AM,objValue.m_strCONTENT_AFTERLUNCH2H,
//																	 objValue.m_strCONTENT_BEFORESUPPER5PM,objValue.m_strCONTENT_WEEHOURS0AM,
//																	 objValue.m_strCONTENT_WEEHOURS3AM,objValue.m_strCONTENT_RANDOM});
//				item.Tag = objValue;
//				m_lsvResult.Items.Add(item);
//				m_lsvResult.Sorting = SortOrder.Ascending;
//				item.Selected = true;
//				clsPublicFunction.ShowInformationMessageBox("保存成功！");
//				m_lsvResult.Invalidate();
//				m_mthClearText();
				clsPublicFunction.ShowInformationMessageBox("保存成功！");
				m_mthInitRecord();
			}
			return lngRes;
		}
		/// <summary>
		/// 是否是添加新记录的操作。true，添加新记录；false,修改记录
		/// </summary>
		protected override bool m_BlnIsAddNew
		{
			get
			{
				return m_blnIsAddNew;
			}
		}
		protected override long m_lngSubModify()
		{
			if(m_objCurValue == null || m_blnCheckEmpty())
				return 0;
			m_objCurValue.m_strCONTENT_LIMOSIS = this.m_txtCONTENT_LIMOSIS.Text.Trim();
			m_objCurValue.m_strCONTENT_BREAKFAST2H = this.m_txtCONTENT_BREAKFAST2H.Text.Trim();
			m_objCurValue.m_strCONTENT_BEFORELUNCH11AM = this.m_txtCONTENT_BEFORELUNCH11AM.Text.Trim();
			m_objCurValue.m_strCONTENT_AFTERLUNCH2H = this.m_txtCONTENT_AFTERLUNCH2H.Text.Trim();
			m_objCurValue.m_strCONTENT_BEFORESUPPER5PM = this.m_txtCONTENT_BEFORESUPPER5PM.Text.Trim();
			m_objCurValue.m_strCONTENT_WEEHOURS0AM = this.m_txtCONTENT_WEEHOURS0AM.Text.Trim();
			m_objCurValue.m_strCONTENT_WEEHOURS3AM = this.m_txtCONTENT_WEEHOURS3AM.Text.Trim();
			m_objCurValue.m_strCONTENT_RANDOM = this.m_txtCONTENT_RANDOM.Text.Trim();
			m_objCurValue.m_dtmOpenDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            m_objCurValue.m_strCustom1Content = this.m_txtCustom1.Text.Trim();
            m_objCurValue.m_strCustom2Content = this.m_txtCustom2.Text.Trim();
			//电子签名 
			//记录ID通常为 住院号＋住院时间 || 住院号＋记录时间 来识别唯一 格式 00000056-2005-10-10 10:20:20
			clsEmrDigitalSign_VO objSign_VO = new clsEmrDigitalSign_VO();
            objSign_VO.m_strFORMID_VCHR = this.Name;
            objSign_VO.m_strFORMRECORDID_VCHR = m_objCurValue.m_strInPatientID.Trim() + "-" + m_objCurValue.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"); 
            objSign_VO.m_strSIGNIDID_VCHR = clsEMRLogin.LoginInfo.m_strEmpID;
            objSign_VO.m_strRegisterId = m_objBaseCurrentPatient.m_StrRegisterId;
            clsCheckSignersController objCheck = new clsCheckSignersController();
            if (objCheck.m_lngSign(m_objCurValue, objSign_VO) == -1)
                return -1;

			long lngRes = m_objDomain.m_lngModifyRecoed(m_objCurValue);
			if(lngRes <= 0)
			{
				clsPublicFunction.ShowInformationMessageBox("修改失败！");
			}
			else
			{
				m_lsiCurItem.SubItems[1].Text = m_objCurValue.m_strCONTENT_LIMOSIS;
				m_lsiCurItem.SubItems[2].Text = m_objCurValue.m_strCONTENT_BREAKFAST2H;
				m_lsiCurItem.SubItems[3].Text = m_objCurValue.m_strCONTENT_BEFORELUNCH11AM;
				m_lsiCurItem.SubItems[4].Text = m_objCurValue.m_strCONTENT_AFTERLUNCH2H;
				m_lsiCurItem.SubItems[5].Text = m_objCurValue.m_strCONTENT_BEFORESUPPER5PM;
				m_lsiCurItem.SubItems[6].Text = m_objCurValue.m_strCONTENT_WEEHOURS0AM;
				m_lsiCurItem.SubItems[7].Text = m_objCurValue.m_strCONTENT_WEEHOURS3AM;
				m_lsiCurItem.SubItems[8].Text = m_objCurValue.m_strCONTENT_RANDOM;
                m_lsiCurItem.SubItems[9].Text = m_objCurValue.m_strCustom1Content;
                m_lsiCurItem.SubItems[10].Text = m_objCurValue.m_strCustom2Content;
//				m_lsiCurItem.ForeColor = Color.Red;
				clsPublicFunction.ShowInformationMessageBox("修改成功！");
				m_lsvResult.Invalidate();
				m_mthClearText();
				m_mthSetEnable(true);
			}
			return lngRes;
		}
		protected override long m_lngSubDelete()
		{
			if(m_lsvResult.SelectedItems.Count <= 0)
				return 0;
			m_objCurValue = m_lsvResult.SelectedItems[0].Tag as clsMiniBloodSugarChkValue_GX;
            //屏蔽 by tfzhang 2006-02-24
            //if(m_objCurValue.m_strCreateUserID.Trim() != MDIParent.OperatorID.Trim())
            //{
            //    MDIParent.ShowInformationMessageBox("非记录创建者不能删除该条记录！");
            //    return 0;
            //}


			m_objCurValue.m_strDeActivedOperatorID = MDIParent.strOperatorID;
			m_objCurValue.m_dtmDeActivedDate = DateTime.Now;
			long lngRes = m_objDomain.m_lngDeleteRecoed(m_objCurValue);
			if(lngRes <= 0)
			{
				clsPublicFunction.ShowInformationMessageBox("删除失败！");
			}
			else
			{
				m_objCurValue = null;
				m_lsiCurItem = null;
				m_lsvResult.SelectedItems[0].Remove();
				m_lsvResult.Invalidate();
				m_mthClearText();
				m_mthSetEnable(true);
				clsPublicFunction.ShowInformationMessageBox("删除成功！");
			}
			return lngRes;
		}
		protected override DialogResult m_dlgHandleSaveBeforePrint()
		{
			return DialogResult.None;
		}
		protected override void m_mthAddRichTemplateInContainer(Control p_ctlContainer)
		{}
		/// <summary>
		/// 如果不需要保存提示。
		/// </summary>
		protected override void m_mthAddFormStatusForClosingSave()
		{}

        protected override long m_lngSubPrint()
        {
            clsMiniBooldSugarChk_GXPrintTool objPrintTool = new clsMiniBooldSugarChk_GXPrintTool();
            objPrintTool.m_mthInitPrintTool(null);
            if (m_objBaseCurrentPatient == null)
                objPrintTool.m_mthSetPrintInfo(null);
            else
                objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient);

            objPrintTool.m_mthInitPrintContent();
            objPrintTool.m_mthPrintPage(null);
            return 1;
        }
		#endregion
        /// <summary>
        /// 重写获取记录创建者属性
        /// 返回指定记录创建者ID
        /// </summary>
        protected override string m_StrRecorder_ID
        {
            get
            {
                m_objCurValue = m_lsvResult.SelectedItems[0].Tag as clsMiniBloodSugarChkValue_GX;
                return m_objCurValue.m_strCreateUserID.Trim();
            }
        }

        #region 设置自定义列标头
        private void label12_DoubleClick(object sender, EventArgs e)
        {
            if (m_objBaseCurrentPatient == null)
                return;
            string strHeaderText = "";
            if (label12.Text != "自定义列1")
                strHeaderText = label12.Text;
            frmSetCustomDataGridColumn frm = new frmSetCustomDataGridColumn(strHeaderText);
            frm.m_txtSetName.MaxLength = 15;
            if (frm.ShowDialog() == DialogResult.Yes)
            {
                long lngRes = m_objDomain.m_lngSetCustomName(frm.m_StrSetName, "CUSTOM1NAME",
                    m_objBaseCurrentPatient.m_StrInPatientID, m_objBaseCurrentPatient.m_DtmSelectedInDate);

                if (lngRes > 0)
                {
                    label12.Text = frm.m_StrSetName;
                    m_lsvResult.Columns[9].Text = frm.m_StrSetName;
                }
            }
        }

        private void m_lsvResult_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (m_objBaseCurrentPatient == null)
                return;
            int intCurrentIndex = e.Column;
            if (intCurrentIndex == 9 || intCurrentIndex == 10)
            {
                string strHeaderText = m_lsvResult.Columns[intCurrentIndex].Text;
                frmSetCustomDataGridColumn frm = new frmSetCustomDataGridColumn(strHeaderText);
                frm.m_txtSetName.MaxLength = 15;

                Label lblTemp = null;
                string strColumnName = "";
                if (intCurrentIndex == 9)
                {
                    lblTemp = label12;
                    strColumnName = "CUSTOM1NAME";
                }
                else
                {
                    lblTemp = label13;
                    strColumnName = "CUSTOM2NAME";
                }

                if (frm.ShowDialog() == DialogResult.Yes)
                {
                    long lngRes = m_objDomain.m_lngSetCustomName(frm.m_StrSetName, strColumnName,
                        m_objBaseCurrentPatient.m_StrInPatientID, m_objBaseCurrentPatient.m_DtmSelectedInDate);

                    if (lngRes > 0)
                    {
                        lblTemp.Text = frm.m_StrSetName;
                        m_lsvResult.Columns[intCurrentIndex].Text = frm.m_StrSetName;
                    }
                }
            }
        }

        private void label13_DoubleClick(object sender, EventArgs e)
        {
            if (m_objBaseCurrentPatient == null)
                return;
            string strHeaderText = "";
            if (label13.Text != "自定义列2")
                strHeaderText = label13.Text;
            frmSetCustomDataGridColumn frm = new frmSetCustomDataGridColumn(strHeaderText);
            frm.m_txtSetName.MaxLength = 15;
            if (frm.ShowDialog() == DialogResult.Yes)
            {
                long lngRes = m_objDomain.m_lngSetCustomName(frm.m_StrSetName, "CUSTOM2NAME",
                    m_objBaseCurrentPatient.m_StrInPatientID, m_objBaseCurrentPatient.m_DtmSelectedInDate);

                if (lngRes > 0)
                {
                    label13.Text = frm.m_StrSetName;
                    m_lsvResult.Columns[10].Text = frm.m_StrSetName;
                }
            }
        } 
        #endregion
	}
}
