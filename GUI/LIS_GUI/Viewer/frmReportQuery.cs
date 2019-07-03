using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
namespace com.digitalwave.iCare.gui.LIS
{
	public class frmReportQuery : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
//		private clsUnifyReportPrint printTool = new clsUnifyReportPrint();
//		public clsPrintValuePara m_objPrintInfo = null;
//		internal System.Drawing.Printing.PrintDocument m_objPrintDoc;

		clsPrintReport m_objPrinter = new clsPrintReport();
		clsController_ReportQuery m_objController;
		#region FormControl
		internal System.Windows.Forms.Label label21;
		internal System.Windows.Forms.TextBox m_txtPatientNameQuery;
		private System.Windows.Forms.Label label7;
		internal System.Windows.Forms.Label label3;
		internal System.Windows.Forms.DateTimePicker m_dtpFromDate;
		internal System.Windows.Forms.DateTimePicker m_dtpToDate;
		internal PinkieControls.ButtonXP m_btnQuery;
		internal System.Windows.Forms.ListView m_lsvReportList;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		internal System.Windows.Forms.ColumnHeader columnHeader3;
		internal System.Windows.Forms.ColumnHeader columnHeader1;
		internal System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.Panel m_palHeader;
		private System.Windows.Forms.Panel m_palList;
		internal System.Windows.Forms.TextBox m_txtInhospNO;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		internal System.Windows.Forms.TextBox m_txtBedNO;
		internal com.digitalwave.Utility.ctlDeptTextBox m_txtAppDept;
		internal com.digitalwave.Utility.ctlEmpTextBox m_txtAppDoct;
		private System.Windows.Forms.Label label26;
		internal System.Windows.Forms.ComboBox m_cboConfirmState;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader9;
        private TextBox m_txtPatientCardNO;
        internal Label label29;
        internal PinkieControls.ButtonXP btnPrint;
        private PinkieControls.ButtonXP btnExit;
		private System.ComponentModel.IContainer components = null;
		#endregion
		#region 构造函数
		public frmReportQuery()
		{
			// 该调用是 Windows 窗体设计器所必需的。
			InitializeComponent();

			// TODO: 在 InitializeComponent 调用后添加任何初始化

		}

		#endregion
		#region override
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

		public override void CreateController()
		{
			this.objController= new com.digitalwave.iCare.gui.LIS.clsController_ReportQuery();
			this.objController.Set_GUI_Apperance(this);
			m_objController = (clsController_ReportQuery)objController;
		}
		#endregion
		#region 设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportQuery));
            this.m_palList = new System.Windows.Forms.Panel();
            this.m_lsvReportList = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.m_palHeader = new System.Windows.Forms.Panel();
            this.btnExit = new PinkieControls.ButtonXP();
            this.btnPrint = new PinkieControls.ButtonXP();
            this.m_txtPatientCardNO = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.m_cboConfirmState = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_txtBedNO = new System.Windows.Forms.TextBox();
            this.m_txtAppDept = new com.digitalwave.Utility.ctlDeptTextBox();
            this.m_txtAppDoct = new com.digitalwave.Utility.ctlEmpTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_txtInhospNO = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtPatientNameQuery = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.m_dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.m_btnQuery = new PinkieControls.ButtonXP();
            this.m_palList.SuspendLayout();
            this.m_palHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_palList
            // 
            this.m_palList.Controls.Add(this.m_lsvReportList);
            this.m_palList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_palList.Location = new System.Drawing.Point(0, 98);
            this.m_palList.Name = "m_palList";
            this.m_palList.Size = new System.Drawing.Size(892, 299);
            this.m_palList.TabIndex = 134;
            // 
            // m_lsvReportList
            // 
            this.m_lsvReportList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader1,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader4,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.m_lsvReportList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvReportList.FullRowSelect = true;
            this.m_lsvReportList.GridLines = true;
            this.m_lsvReportList.HideSelection = false;
            this.m_lsvReportList.Location = new System.Drawing.Point(0, 0);
            this.m_lsvReportList.MultiSelect = false;
            this.m_lsvReportList.Name = "m_lsvReportList";
            this.m_lsvReportList.Size = new System.Drawing.Size(892, 299);
            this.m_lsvReportList.TabIndex = 132;
            this.m_lsvReportList.UseCompatibleStateImageBehavior = false;
            this.m_lsvReportList.View = System.Windows.Forms.View.Details;
            this.m_lsvReportList.DoubleClick += new System.EventHandler(this.m_lsvReportList_DoubleClick);
            this.m_lsvReportList.SelectedIndexChanged += new System.EventHandler(this.m_lsvReportList_SelectedIndexChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "患者姓名";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "检验项目";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "住院号";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "床号";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "申请科室";
            this.columnHeader6.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "申请医生";
            this.columnHeader4.Width = 80;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "申请时间";
            this.columnHeader7.Width = 151;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "检验报告时间";
            this.columnHeader8.Width = 152;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "状态";
            this.columnHeader9.Width = 40;
            // 
            // m_palHeader
            // 
            this.m_palHeader.Controls.Add(this.btnExit);
            this.m_palHeader.Controls.Add(this.btnPrint);
            this.m_palHeader.Controls.Add(this.m_txtPatientCardNO);
            this.m_palHeader.Controls.Add(this.label29);
            this.m_palHeader.Controls.Add(this.label26);
            this.m_palHeader.Controls.Add(this.m_cboConfirmState);
            this.m_palHeader.Controls.Add(this.label6);
            this.m_palHeader.Controls.Add(this.m_txtBedNO);
            this.m_palHeader.Controls.Add(this.m_txtAppDept);
            this.m_palHeader.Controls.Add(this.m_txtAppDoct);
            this.m_palHeader.Controls.Add(this.label5);
            this.m_palHeader.Controls.Add(this.label4);
            this.m_palHeader.Controls.Add(this.m_txtInhospNO);
            this.m_palHeader.Controls.Add(this.label2);
            this.m_palHeader.Controls.Add(this.m_txtPatientNameQuery);
            this.m_palHeader.Controls.Add(this.label21);
            this.m_palHeader.Controls.Add(this.label7);
            this.m_palHeader.Controls.Add(this.label3);
            this.m_palHeader.Controls.Add(this.m_dtpFromDate);
            this.m_palHeader.Controls.Add(this.m_dtpToDate);
            this.m_palHeader.Controls.Add(this.m_btnQuery);
            this.m_palHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_palHeader.Location = new System.Drawing.Point(0, 0);
            this.m_palHeader.Name = "m_palHeader";
            this.m_palHeader.Size = new System.Drawing.Size(892, 98);
            this.m_palHeader.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnExit.DefaultScheme = true;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExit.Hint = "";
            this.btnExit.Location = new System.Drawing.Point(871, 10);
            this.btnExit.Name = "btnExit";
            this.btnExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnExit.Size = new System.Drawing.Size(92, 31);
            this.btnExit.TabIndex = 146;
            this.btnExit.Text = "关闭(&C)";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnPrint.DefaultScheme = true;
            this.btnPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPrint.Hint = "";
            this.btnPrint.Location = new System.Drawing.Point(771, 46);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnPrint.Size = new System.Drawing.Size(92, 31);
            this.btnPrint.TabIndex = 145;
            this.btnPrint.Text = "打印(F8)";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // m_txtPatientCardNO
            // 
            this.m_txtPatientCardNO.Location = new System.Drawing.Point(72, 60);
            this.m_txtPatientCardNO.Name = "m_txtPatientCardNO";
            this.m_txtPatientCardNO.Size = new System.Drawing.Size(104, 23);
            this.m_txtPatientCardNO.TabIndex = 8;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(8, 64);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(63, 14);
            this.label29.TabIndex = 144;
            this.label29.Text = "诊疗卡号";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(180, 40);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(63, 14);
            this.label26.TabIndex = 142;
            this.label26.Text = "审核状态";
            this.label26.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // m_cboConfirmState
            // 
            this.m_cboConfirmState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboConfirmState.Items.AddRange(new object[] {
            "未审核",
            "已审核",
            "全  部"});
            this.m_cboConfirmState.Location = new System.Drawing.Point(248, 36);
            this.m_cboConfirmState.Name = "m_cboConfirmState";
            this.m_cboConfirmState.Size = new System.Drawing.Size(96, 22);
            this.m_cboConfirmState.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(208, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 14);
            this.label6.TabIndex = 140;
            this.label6.Text = "床号";
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(248, 12);
            this.m_txtBedNO.MaxLength = 4;
            this.m_txtBedNO.Name = "m_txtBedNO";
            this.m_txtBedNO.Size = new System.Drawing.Size(96, 23);
            this.m_txtBedNO.TabIndex = 2;
            // 
            // m_txtAppDept
            // 
            this.m_txtAppDept.EnableAutoValidation = true;
            this.m_txtAppDept.EnableEnterKeyValidate = true;
            this.m_txtAppDept.EnableEscapeKeyUndo = true;
            this.m_txtAppDept.EnableLastValidValue = true;
            this.m_txtAppDept.ErrorProvider = null;
            this.m_txtAppDept.ErrorProviderMessage = "Invalid value";
            this.m_txtAppDept.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtAppDept.ForceFormatText = true;
            this.m_txtAppDept.Location = new System.Drawing.Point(428, 12);
            this.m_txtAppDept.m_StrDeptID = null;
            this.m_txtAppDept.m_StrDeptName = null;
            this.m_txtAppDept.MaxLength = 20;
            this.m_txtAppDept.Name = "m_txtAppDept";
            this.m_txtAppDept.SetDepartment = com.digitalwave.Utility.ctlDeptTextBox.eDeptArea.All;
            this.m_txtAppDept.Size = new System.Drawing.Size(104, 23);
            this.m_txtAppDept.TabIndex = 4;
            // 
            // m_txtAppDoct
            // 
            this.m_txtAppDoct.EnableAutoValidation = true;
            this.m_txtAppDoct.EnableEnterKeyValidate = true;
            this.m_txtAppDoct.EnableEscapeKeyUndo = true;
            this.m_txtAppDoct.EnableLastValidValue = true;
            this.m_txtAppDoct.ErrorProvider = null;
            this.m_txtAppDoct.ErrorProviderMessage = "Invalid value";
            this.m_txtAppDoct.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtAppDoct.ForceFormatText = true;
            this.m_txtAppDoct.Location = new System.Drawing.Point(428, 36);
            this.m_txtAppDoct.m_intShowOtherEmp = 0;
            this.m_txtAppDoct.m_StrDeptID = "*";
            this.m_txtAppDoct.m_StrEmployeeID = null;
            this.m_txtAppDoct.m_StrEmployeeName = null;
            this.m_txtAppDoct.MaxLength = 20;
            this.m_txtAppDoct.Name = "m_txtAppDoct";
            this.m_txtAppDoct.Size = new System.Drawing.Size(104, 23);
            this.m_txtAppDoct.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(360, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 136;
            this.label5.Text = "申请医生";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(360, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 134;
            this.label4.Text = "申请科室";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // m_txtInhospNO
            // 
            this.m_txtInhospNO.Location = new System.Drawing.Point(72, 36);
            this.m_txtInhospNO.MaxLength = 50;
            this.m_txtInhospNO.Name = "m_txtInhospNO";
            this.m_txtInhospNO.Size = new System.Drawing.Size(104, 23);
            this.m_txtInhospNO.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 132;
            this.label2.Text = "住院号";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // m_txtPatientNameQuery
            // 
            this.m_txtPatientNameQuery.Location = new System.Drawing.Point(72, 12);
            this.m_txtPatientNameQuery.MaxLength = 50;
            this.m_txtPatientNameQuery.Name = "m_txtPatientNameQuery";
            this.m_txtPatientNameQuery.Size = new System.Drawing.Size(104, 23);
            this.m_txtPatientNameQuery.TabIndex = 0;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(556, 16);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(63, 14);
            this.label21.TabIndex = 130;
            this.label21.Text = "申请日期";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 128;
            this.label7.Text = "病人姓名";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(584, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 14);
            this.label3.TabIndex = 122;
            this.label3.Text = "至";
            // 
            // m_dtpFromDate
            // 
            this.m_dtpFromDate.CustomFormat = "yyyy-MM-dd";
            this.m_dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpFromDate.Location = new System.Drawing.Point(624, 12);
            this.m_dtpFromDate.Name = "m_dtpFromDate";
            this.m_dtpFromDate.Size = new System.Drawing.Size(96, 23);
            this.m_dtpFromDate.TabIndex = 6;
            // 
            // m_dtpToDate
            // 
            this.m_dtpToDate.CustomFormat = "yyyy-MM-dd";
            this.m_dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpToDate.Location = new System.Drawing.Point(624, 36);
            this.m_dtpToDate.Name = "m_dtpToDate";
            this.m_dtpToDate.Size = new System.Drawing.Size(96, 23);
            this.m_dtpToDate.TabIndex = 7;
            // 
            // m_btnQuery
            // 
            this.m_btnQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnQuery.DefaultScheme = true;
            this.m_btnQuery.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnQuery.Hint = "";
            this.m_btnQuery.Location = new System.Drawing.Point(771, 10);
            this.m_btnQuery.Name = "m_btnQuery";
            this.m_btnQuery.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnQuery.Size = new System.Drawing.Size(92, 31);
            this.m_btnQuery.TabIndex = 100;
            this.m_btnQuery.Text = "查询(F4)";
            this.m_btnQuery.Click += new System.EventHandler(this.m_btnQuery_Click);
            // 
            // frmReportQuery
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(892, 397);
            this.Controls.Add(this.m_palList);
            this.Controls.Add(this.m_palHeader);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmReportQuery";
            this.Text = "检验报告查询";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmReportQuery_KeyDown);
            this.Load += new System.EventHandler(this.frmReportQuery_Load);
            this.m_palList.ResumeLayout(false);
            this.m_palHeader.ResumeLayout(false);
            this.m_palHeader.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

        #region 一般设置

        #region 快捷键设置

        private void m_mthShortCutKey(Keys p_eumKeyCode)
        {
            if (p_eumKeyCode == Keys.F4)
            {
                if (this.m_btnQuery.Enabled == true
                    && this.m_btnQuery.Visible == true)
                {
                    this.m_btnQuery_Click(this.m_btnQuery, null);
                }
            }
            else if (p_eumKeyCode == Keys.F8)
            {
                if (this.btnPrint.Enabled == true
                    && this.btnPrint.Visible == true)
                {
                    this.btnPrint_Click(this.btnPrint, null);
                }
            }
            //else if (p_eumKeyCode == Keys.F3 && this.m_btnPreference.Enabled && m_btnPreference.Visible)//保存
            //{
            //    this.m_btnPreference_Click(null, null);
            //}
            //else if (p_eumKeyCode == Keys.F5 && this.m_btnPrintReport.Enabled && m_btnPrintReport.Visible)//读卡
            //{
            //    this.m_btnPrintReport_Click(null, null);
            //}
            //else if (p_eumKeyCode == Keys.F6 && this.m_btnPreviewReport.Enabled && m_btnPreviewReport.Visible)		//退出
            //{
            //    this.m_btnPreviewReport_Click(null, null);
            //}
            //else if (p_eumKeyCode == Keys.F9 && this.m_btnConfirmReport.Enabled && m_btnConfirmReport.Visible)		//清除
            //{
            //    this.m_btnConfirmReport_Click(null, null);
            //}
            //else if (p_eumKeyCode == Keys.F10 && this.m_btnSaveReport.Enabled && m_btnSaveReport.Visible)//手输和读卡机切换
            //{
            //    this.m_btnSaveReport_Click(null, null);
            //}
            //else if (p_eumKeyCode == Keys.F12 && this.m_btnDelete.Enabled && m_btnDelete.Visible)//手输和读卡机切换
            //{
            //    this.m_btnDelete_Click(null, null);
            //}
            //else if (p_eumKeyCode == Keys.F8 && this.m_btnNewApp.Enabled && m_btnNewApp.Visible)//手输和读卡机切换
            //{
            //    this.m_btnNewApp_Click(null, null);
            //}
            //			else if(p_eumKeyCode==Keys.F12 && this.m_btnInputSwitch.Enabled && m_btnInputSwitch.Visible)//手输和读卡机切换
            //			{
            //				this.m_btnInputSwitch_Click(null,null);
            //			}
        }

        #endregion

        private void frmReportQuery_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            m_mthShortCutKey(e.KeyCode);
			base.m_mthSetKeyTab(e);
		}

        #endregion

		private void m_btnQuery_Click(object sender, System.EventArgs e)
		{
            this.m_btnQuery.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;

			string strPatientName = this.m_txtPatientNameQuery.Text.Trim();
			string[] strSampleGroupIDArr = null;
			
			string strInhospNO = this.m_txtInhospNO.Text.Trim();
			string strBedNO = this.m_txtBedNO.Text.Trim();
			string strAppDept = this.m_txtAppDept.m_StrDeptID;
			string strAppDoct = this.m_txtAppDoct.m_StrEmployeeID;
            string strPatientCardNO = this.m_txtPatientCardNO.Text.Trim();

			string strConfirmed = "3";
			if(this.m_cboConfirmState.Text == "未审核")
			{
				strConfirmed = "1";
			}
			else if(this.m_cboConfirmState.Text == "已审核")
			{
				strConfirmed = "2";
			}
			string strFromDateApp = this.m_dtpFromDate.Value.ToString("yyyy-MM-dd 00:00:00");
			string strToDateApp = this.m_dtpToDate.Value.ToString("yyyy-MM-dd 23:59:59");
			clsLISApplicationSchVO objSchVO = new clsLISApplicationSchVO();
			objSchVO.m_strConfirmState = strConfirmed;
			objSchVO.m_strPatientName = strPatientName;
			objSchVO.m_strInhospNO = strInhospNO;
			objSchVO.m_strAppDept = strAppDept;
			objSchVO.m_strAppDoct = strAppDoct;
			objSchVO.m_strBedNO = strBedNO;
			objSchVO.m_strFromDatApp = strFromDateApp;
			objSchVO.m_strToDatApp = strToDateApp;
			objSchVO.m_strSampleGroupIDArr = strSampleGroupIDArr;
            objSchVO.m_strPatientCardNO = strPatientCardNO;

			this.m_objController.m_mthQueryReports(objSchVO);

            this.m_btnQuery.Enabled = true;
            Cursor.Current = Cursors.Default;

			
		}

		private void frmReportQuery_Load(object sender, System.EventArgs e)
		{
			this.m_mthSetEnter2Tab(new Control[]{this.m_txtAppDept,this.m_txtAppDoct});
			this.m_objController.m_mthInit();
		}

		#region 打印
		private void m_mthPreView()
		{
			if(this.m_lsvReportList.SelectedItems.Count != 0)
			{
				if(this.m_lsvReportList.SelectedItems[0].Tag != null)
				{
					clsLisApplMainVO objReport = ((clsLisApplMainVO)this.m_lsvReportList.SelectedItems[0].Tag);
					this.m_objPrinter.m_mthGetPrintContentFromDB(objReport.m_strReportGroupID,objReport.m_strAPPLICATION_ID,true);
					this.m_objPrinter.m_mthPrintPreview();
				}
			}

		}
		internal void m_mthPrint()
		{
			if(this.m_lsvReportList.SelectedItems.Count != 0)
			{
				if(this.m_lsvReportList.SelectedItems[0].Tag != null)
				{
					clsLisApplMainVO objReport = ((clsLisApplMainVO)this.m_lsvReportList.SelectedItems[0].Tag);
					this.m_objPrinter.m_mthGetPrintContentFromDB(objReport.m_strReportGroupID,objReport.m_strAPPLICATION_ID,true);
					this.m_objPrinter.m_mthPrint();
				}
			}

		}
		#endregion

		private void m_lsvReportList_DoubleClick(object sender, System.EventArgs e)
		{
			if(this.m_lsvReportList.FocusedItem.SubItems[8].Text.Trim() == "")
				return;
			this.m_mthPreView();
		}

		private void m_lsvReportList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}


		public void m_mthQueryReports(string p_strComfirmState,
			string p_strPatientName,string p_strInhospNO,string p_strAppDept,string p_strAppDoct,
			string p_strBedNO,string p_strFromDatApp,string p_strToDatApp)

		{

			clsLISApplicationSchVO objSchVO = new clsLISApplicationSchVO();
			objSchVO.m_strConfirmState = p_strComfirmState;
			objSchVO.m_strPatientName = p_strPatientName;
			objSchVO.m_strInhospNO = p_strInhospNO;
			objSchVO.m_strAppDept = p_strAppDept;
			objSchVO.m_strAppDoct = p_strAppDoct;
			objSchVO.m_strBedNO = p_strBedNO;
			objSchVO.m_strFromDatApp = p_strFromDatApp;
			objSchVO.m_strToDatApp = p_strToDatApp;
			this.m_objController.m_mthQueryReports(objSchVO);

		}

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (this.m_lsvReportList.FocusedItem == null || this.m_lsvReportList.FocusedItem.SubItems[8].Text.Trim() == "")
                return;

            this.btnPrint.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;

            this.m_mthPrint();

            this.btnPrint.Enabled = true;
            Cursor.Current = Cursors.Default;            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
	}
}

