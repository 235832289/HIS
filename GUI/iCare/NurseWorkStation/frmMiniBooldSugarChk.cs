using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using iCareData;

namespace iCare
{
	/// <summary>
	/// 快速微量血糖检测记录表
	/// </summary>
	public class frmMiniBooldSugarChk : iCare.frmHRPBaseForm,PublicFunction
	{
		#region Define
		private System.Windows.Forms.ListView m_lsvResult;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox m_gpbResult;
		private System.Windows.Forms.GroupBox m_gpbEdit;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox m_txtBreakfast;
		private System.Windows.Forms.TextBox m_txtLunch;
		private System.Windows.Forms.TextBox m_txtSupper;
		private System.Windows.Forms.TextBox m_txtPreRest;
		private PinkieControls.ButtonXP m_cmdModify;
		private System.Windows.Forms.ContextMenu ctmResult;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private PinkieControls.ButtonXP m_cmdAddNew;
		protected com.digitalwave.Utility.Controls.ctlTimePicker m_dtpCreateDate;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TreeView trvTime;
		private System.Windows.Forms.GroupBox groupBox1;


		private ListViewItem m_lsiCurItem;
		private clsMiniBloodSugarChkValue m_objCurValue;
		private clsMiniBooldSugarChkDomin m_objDomain;
		private string m_strDateFormat = "yyyy年MM月dd日 HH:mm:ss";
		private bool m_blnIsAddNew = true;

		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		public frmMiniBooldSugarChk()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			new clsSortTool().m_mthSetListViewSortable(m_lsvResult);
			m_objDomain = new clsMiniBooldSugarChkDomin();
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("入院日期");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMiniBooldSugarChk));
            this.m_lsvResult = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.ctmResult = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.m_gpbResult = new System.Windows.Forms.GroupBox();
            this.m_gpbEdit = new System.Windows.Forms.GroupBox();
            this.m_cmdModify = new PinkieControls.ButtonXP();
            this.m_txtBreakfast = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtLunch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_txtSupper = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_txtPreRest = new System.Windows.Forms.TextBox();
            this.m_cmdAddNew = new PinkieControls.ButtonXP();
            this.trvTime = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_dtpCreateDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.m_pnlNewBase.SuspendLayout();
            this.m_gpbResult.SuspendLayout();
            this.m_gpbEdit.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(604, 12);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(708, 12);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(228, 12);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(388, 12);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(228, 44);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(560, 12);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(664, 12);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(24, 44);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(322, 78);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(104, 104);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(448, 11);
            this.txtInPatientID.Size = new System.Drawing.Size(104, 23);
            this.txtInPatientID.TabIndex = 500;
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(276, 43);
            this.m_txtPatientName.Size = new System.Drawing.Size(104, 23);
            this.m_txtPatientName.TabIndex = 400;
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(276, 11);
            this.m_txtBedNO.Size = new System.Drawing.Size(80, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(72, 42);
            this.m_cboArea.TabIndex = 200;
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(276, 77);
            this.m_lsvPatientName.Size = new System.Drawing.Size(100, 104);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(296, 82);
            this.m_lsvBedNO.Size = new System.Drawing.Size(84, 104);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(72, 10);
            this.m_cboDept.TabIndex = 100;
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(24, 12);
            this.lblDept.Visible = false;
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.m_cmdNext.Location = new System.Drawing.Point(356, 11);
            this.m_cmdNext.TabIndex = 300;
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(4, 20);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(691, 35);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Location = new System.Drawing.Point(19, 6);
            this.m_pnlNewBase.Visible = true;
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            // 
            // m_lsvResult
            // 
            this.m_lsvResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.m_lsvResult.ContextMenu = this.ctmResult;
            this.m_lsvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvResult.FullRowSelect = true;
            this.m_lsvResult.GridLines = true;
            this.m_lsvResult.Location = new System.Drawing.Point(3, 19);
            this.m_lsvResult.Name = "m_lsvResult";
            this.m_lsvResult.Size = new System.Drawing.Size(606, 392);
            this.m_lsvResult.TabIndex = 750;
            this.m_lsvResult.UseCompatibleStateImageBehavior = false;
            this.m_lsvResult.View = System.Windows.Forms.View.Details;
            this.m_lsvResult.DoubleClick += new System.EventHandler(this.m_lsvResult_DoubleClick);
            this.m_lsvResult.SelectedIndexChanged += new System.EventHandler(this.m_lsvResult_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "日      期";
            this.columnHeader1.Width = 168;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "早餐前(mmol/L)";
            this.columnHeader2.Width = 110;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "中餐前(mmol/L)";
            this.columnHeader3.Width = 111;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "晚餐前(mmol/L)";
            this.columnHeader4.Width = 110;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "临睡前(mmol/L)";
            this.columnHeader5.Width = 111;
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
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Desktop;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(8, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(807, 2);
            this.label1.TabIndex = 10000005;
            this.label1.Text = "label1";
            // 
            // m_gpbResult
            // 
            this.m_gpbResult.Controls.Add(this.m_lsvResult);
            this.m_gpbResult.Location = new System.Drawing.Point(8, 82);
            this.m_gpbResult.Name = "m_gpbResult";
            this.m_gpbResult.Size = new System.Drawing.Size(612, 414);
            this.m_gpbResult.TabIndex = 700;
            this.m_gpbResult.TabStop = false;
            this.m_gpbResult.Text = "记录列表";
            // 
            // m_gpbEdit
            // 
            this.m_gpbEdit.Controls.Add(this.m_cmdModify);
            this.m_gpbEdit.Controls.Add(this.m_txtBreakfast);
            this.m_gpbEdit.Controls.Add(this.label2);
            this.m_gpbEdit.Controls.Add(this.label3);
            this.m_gpbEdit.Controls.Add(this.m_txtLunch);
            this.m_gpbEdit.Controls.Add(this.label4);
            this.m_gpbEdit.Controls.Add(this.m_txtSupper);
            this.m_gpbEdit.Controls.Add(this.label5);
            this.m_gpbEdit.Controls.Add(this.m_txtPreRest);
            this.m_gpbEdit.Controls.Add(this.m_cmdAddNew);
            this.m_gpbEdit.Location = new System.Drawing.Point(624, 86);
            this.m_gpbEdit.Name = "m_gpbEdit";
            this.m_gpbEdit.Size = new System.Drawing.Size(192, 410);
            this.m_gpbEdit.TabIndex = 800;
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
            this.m_cmdModify.Location = new System.Drawing.Point(16, 368);
            this.m_cmdModify.Name = "m_cmdModify";
            this.m_cmdModify.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdModify.Size = new System.Drawing.Size(66, 28);
            this.m_cmdModify.TabIndex = 1400;
            this.m_cmdModify.Text = "修 改";
            this.m_cmdModify.Click += new System.EventHandler(this.m_cmdModify_Click);
            // 
            // m_txtBreakfast
            // 
            this.m_txtBreakfast.Location = new System.Drawing.Point(12, 52);
            this.m_txtBreakfast.MaxLength = 20;
            this.m_txtBreakfast.Name = "m_txtBreakfast";
            this.m_txtBreakfast.Size = new System.Drawing.Size(168, 23);
            this.m_txtBreakfast.TabIndex = 900;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "早餐前(mmol/L):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "中餐前(mmol/L):\r\n";
            // 
            // m_txtLunch
            // 
            this.m_txtLunch.Location = new System.Drawing.Point(12, 124);
            this.m_txtLunch.MaxLength = 20;
            this.m_txtLunch.Name = "m_txtLunch";
            this.m_txtLunch.Size = new System.Drawing.Size(168, 23);
            this.m_txtLunch.TabIndex = 1000;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "晚餐前(mmol/L):\r\n";
            // 
            // m_txtSupper
            // 
            this.m_txtSupper.Location = new System.Drawing.Point(12, 196);
            this.m_txtSupper.MaxLength = 20;
            this.m_txtSupper.Name = "m_txtSupper";
            this.m_txtSupper.Size = new System.Drawing.Size(168, 23);
            this.m_txtSupper.TabIndex = 1100;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 14);
            this.label5.TabIndex = 0;
            this.label5.Text = "临睡前(mmol/L):\r\n";
            // 
            // m_txtPreRest
            // 
            this.m_txtPreRest.Location = new System.Drawing.Point(12, 268);
            this.m_txtPreRest.MaxLength = 20;
            this.m_txtPreRest.Name = "m_txtPreRest";
            this.m_txtPreRest.Size = new System.Drawing.Size(168, 23);
            this.m_txtPreRest.TabIndex = 1200;
            // 
            // m_cmdAddNew
            // 
            this.m_cmdAddNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdAddNew.DefaultScheme = true;
            this.m_cmdAddNew.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdAddNew.Hint = "";
            this.m_cmdAddNew.Location = new System.Drawing.Point(112, 368);
            this.m_cmdAddNew.Name = "m_cmdAddNew";
            this.m_cmdAddNew.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdAddNew.Size = new System.Drawing.Size(66, 28);
            this.m_cmdAddNew.TabIndex = 1300;
            this.m_cmdAddNew.Text = "添 加";
            this.m_cmdAddNew.Click += new System.EventHandler(this.m_cmdAddNew_Click);
            // 
            // trvTime
            // 
            this.trvTime.BackColor = System.Drawing.Color.White;
            this.trvTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trvTime.ForeColor = System.Drawing.Color.Black;
            this.trvTime.HideSelection = false;
            this.trvTime.Location = new System.Drawing.Point(3, 19);
            this.trvTime.Name = "trvTime";
            treeNode1.Name = "";
            treeNode1.Text = "入院日期";
            this.trvTime.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.trvTime.ShowRootLines = false;
            this.trvTime.Size = new System.Drawing.Size(0, 0);
            this.trvTime.TabIndex = 10000089;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.trvTime);
            this.groupBox1.Location = new System.Drawing.Point(740, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(4, 12);
            this.groupBox1.TabIndex = 10000090;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "入院日期";
            this.groupBox1.Visible = false;
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
            this.m_dtpCreateDate.Location = new System.Drawing.Point(464, 42);
            this.m_dtpCreateDate.m_BlnOnlyTime = false;
            this.m_dtpCreateDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpCreateDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpCreateDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpCreateDate.Name = "m_dtpCreateDate";
            this.m_dtpCreateDate.ReadOnly = false;
            this.m_dtpCreateDate.Size = new System.Drawing.Size(212, 22);
            this.m_dtpCreateDate.TabIndex = 600;
            this.m_dtpCreateDate.TextBackColor = System.Drawing.Color.White;
            this.m_dtpCreateDate.TextForeColor = System.Drawing.Color.Black;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(392, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 14);
            this.label6.TabIndex = 10000092;
            this.label6.Text = "记录时间:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmMiniBooldSugarChk
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(828, 509);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.m_dtpCreateDate);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_gpbEdit);
            this.Controls.Add(this.m_gpbResult);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMiniBooldSugarChk";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "快速微量血糖检测记录表";
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.m_gpbResult, 0);
            this.Controls.SetChildIndex(this.m_gpbEdit, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.m_dtpCreateDate, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            this.m_gpbResult.ResumeLayout(false);
            this.m_gpbEdit.ResumeLayout(false);
            this.m_gpbEdit.PerformLayout();
            this.groupBox1.ResumeLayout(false);
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
			clsMiniBloodSugarChkValue[] objValues = null;
			long lngRes = m_objDomain.m_lngGetRecoedByInPatient(m_objBaseCurrentPatient.m_StrInPatientID,m_objBaseCurrentPatient.m_DtmSelectedInDate,out objValues);
			if(lngRes <= 0 || objValues == null)
				return;
			for(int i=0;i<objValues.Length;i++)
			{
				ListViewItem item = new ListViewItem(new string[]{objValues[i].m_dtmCreatedDate.ToString(m_strDateFormat),objValues[i].m_strBreakfast,objValues[i].m_strLunch,objValues[i].m_strSupper,objValues[i].m_strPreRest});
				item.Tag = objValues[i];
				m_lsvResult.Items.Add(item);
			}
			m_mthClearText();
		}

		private void m_lsvResult_DoubleClick(object sender, System.EventArgs e)
		{
			if(m_lsvResult.SelectedItems.Count <= 0)
				return;
			m_objCurValue = m_lsvResult.SelectedItems[0].Tag as clsMiniBloodSugarChkValue;
			m_lsiCurItem = m_lsvResult.SelectedItems[0];
			m_dtpCreateDate.Value = m_objCurValue.m_dtmCreatedDate;

			m_txtBreakfast.Text = m_objCurValue.m_strBreakfast;
			m_txtLunch.Text = m_objCurValue.m_strLunch;
			m_txtSupper.Text = m_objCurValue.m_strSupper;
			m_txtPreRest.Text = m_objCurValue.m_strPreRest;
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
				return;
			m_objCurValue = m_lsvResult.SelectedItems[0].Tag as clsMiniBloodSugarChkValue;
			m_lsiCurItem = m_lsvResult.SelectedItems[0];
			m_dtpCreateDate.Value = m_objCurValue.m_dtmCreatedDate;
		}

		private void m_cmdModify_Click(object sender, System.EventArgs e)
		{
			m_blnIsAddNew = false;
			Save();
		}

		private void m_mthClearText()
		{
			m_txtBreakfast.Text = "";
			m_txtLunch.Text = "";
			m_txtSupper.Text = "";
			m_txtPreRest.Text = "";
			m_dtpCreateDate.Value = DateTime.Now;
			m_txtBreakfast.Focus();
		}
		private bool m_blnCheckEmpty()
		{
			return m_txtPreRest.Text == "" && m_txtLunch.Text == "" && m_txtSupper.Text =="" && m_txtPreRest.Text == "";
		}

		private void m_cmdAddNew_Click(object sender, System.EventArgs e)
		{
			m_blnIsAddNew = true;
			Save();
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			Delete();
		}
		protected override void m_mthSetPatientFormInfo(clsPatient p_objSelectedPatient)
		{
			m_lsvResult.Items.Clear();
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			m_lsvResult_DoubleClick(m_lsvResult, System.EventArgs.Empty);
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
			clsMiniBloodSugarChkValue objValue = new clsMiniBloodSugarChkValue();
			objValue.m_strInPatientID = m_objBaseCurrentPatient.m_StrInPatientID;
			objValue.m_dtmInPatientDate = m_objBaseCurrentPatient.m_DtmSelectedInDate;
			objValue.m_strCreateUserID = MDIParent.strOperatorID;
			objValue.m_dtmCreatedDate = m_dtpCreateDate.Value;
			objValue.m_strBreakfast = m_txtBreakfast.Text.Trim();
			objValue.m_strLunch = m_txtLunch.Text.Trim();
			objValue.m_strSupper = m_txtSupper.Text.Trim();
			objValue.m_strPreRest = m_txtPreRest.Text.Trim();
			objValue.m_dtmOpenDate = DateTime.Now;
			long lngRes = m_objDomain.m_lngAddNewRecoed(objValue);
			if(lngRes <= 0)
			{
				clsPublicFunction.ShowInformationMessageBox("保存失败！");
			}
			else
			{
				m_objCurValue = objValue;
				ListViewItem item = new ListViewItem(new string[]{objValue.m_dtmCreatedDate.ToString(m_strDateFormat),objValue.m_strBreakfast,objValue.m_strLunch,objValue.m_strSupper,objValue.m_strPreRest});
				item.Tag = objValue;
				m_lsvResult.Items.Add(item);
				m_lsvResult.Sorting = SortOrder.Ascending;
				item.Selected = true;
				clsPublicFunction.ShowInformationMessageBox("保存成功！");
				m_lsvResult.Invalidate();
				m_mthClearText();
				m_mthSetEnable(true);
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
			m_objCurValue.m_strBreakfast = m_txtBreakfast.Text.Trim();
			m_objCurValue.m_strLunch = m_txtLunch.Text.Trim();
			m_objCurValue.m_strSupper = m_txtSupper.Text.Trim();
			m_objCurValue.m_strPreRest = m_txtPreRest.Text.Trim();
			m_objCurValue.m_dtmOpenDate = DateTime.Now;
			long lngRes = m_objDomain.m_lngModifyRecoed(m_objCurValue);
			if(lngRes <= 0)
			{
				clsPublicFunction.ShowInformationMessageBox("修改失败！");
			}
			else
			{
				m_lsiCurItem.SubItems[1].Text = m_objCurValue.m_strBreakfast;
				m_lsiCurItem.SubItems[2].Text = m_objCurValue.m_strLunch;
				m_lsiCurItem.SubItems[3].Text = m_objCurValue.m_strSupper;
				m_lsiCurItem.SubItems[4].Text = m_objCurValue.m_strPreRest;
				m_lsiCurItem.ForeColor = Color.Red;
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
			m_objCurValue = m_lsvResult.SelectedItems[0].Tag as clsMiniBloodSugarChkValue;
			m_objCurValue.m_strDeActivedUserID = MDIParent.strOperatorID;
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
			clsMiniBooldSugarChkPrintTool objPrintTool = new clsMiniBooldSugarChkPrintTool();
			objPrintTool.m_mthInitPrintTool(null);	
			if(m_objBaseCurrentPatient==null)
				objPrintTool.m_mthSetPrintInfo(null);
			else 
				objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient);
												
			objPrintTool.m_mthInitPrintContent();
			objPrintTool.m_mthPrintPage();
			return 1;
		}
		#endregion

        protected override void m_mthPerformSessionChanged(clsEmrPatientSessionInfo_VO p_objSelectedSession, int p_intIndex)
        {
            if (p_objSelectedSession == null)
            {
                return;
            }
            m_objBaseCurrentPatient.m_StrHISInPatientID = p_objSelectedSession.m_strHISInpatientId;
            m_objBaseCurrentPatient.m_DtmSelectedHISInDate = p_objSelectedSession.m_dtmHISInpatientDate;

            m_objBaseCurrentPatient.m_DtmSelectedInDate = p_objSelectedSession.m_dtmEMRInpatientDate;
            m_objBaseCurrentPatient.m_StrRegisterId = p_objSelectedSession.m_strRegisterId;

            m_mthIsReadOnly();
            if (!m_blnCanShowRecordContent())
            {
                clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                return;
            }

            m_mthInitRecord();
        }
	}
}
