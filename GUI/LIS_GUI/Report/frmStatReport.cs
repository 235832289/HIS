using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.LIS
{
	public class frmStatReport : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		com.digitalwave.iCare.gui.LIS.clsController_StatReport m_objController;
		internal PinkieControls.ButtonXP m_btnQuery;
		#region Controls

		internal System.Windows.Forms.ComboBox m_cboReport;
		private System.Windows.Forms.Label m_lbReportType;
		private System.Windows.Forms.Label m_lbConfirmDat;
		internal System.Windows.Forms.DateTimePicker m_dtpDatFrom;
		private System.Windows.Forms.Label m_lbDatTo;
		internal System.Windows.Forms.DateTimePicker m_dtpDatTo;
		internal CrystalDecisions.Windows.Forms.CrystalReportViewer m_ReportViewer;
		private System.Windows.Forms.GroupBox m_gbpQueryCondition;
		private System.Windows.Forms.Panel m_palReportViewer;
		private PinkieControls.ButtonXP m_btnMax;
		private PinkieControls.ButtonXP m_btnRecover;
		private System.Windows.Forms.Label m_lbOprate;
		internal com.digitalwave.Utility.ctlEmpTextBox m_txtOprDoct;
        private PinkieControls.ButtonXP btnExit;
		private System.ComponentModel.IContainer components = null;

		public frmStatReport()
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

		#region 设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.m_ReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.m_btnQuery = new PinkieControls.ButtonXP();
            this.m_cboReport = new System.Windows.Forms.ComboBox();
            this.m_lbReportType = new System.Windows.Forms.Label();
            this.m_lbConfirmDat = new System.Windows.Forms.Label();
            this.m_dtpDatFrom = new System.Windows.Forms.DateTimePicker();
            this.m_lbDatTo = new System.Windows.Forms.Label();
            this.m_dtpDatTo = new System.Windows.Forms.DateTimePicker();
            this.m_gbpQueryCondition = new System.Windows.Forms.GroupBox();
            this.m_lbOprate = new System.Windows.Forms.Label();
            this.m_txtOprDoct = new com.digitalwave.Utility.ctlEmpTextBox();
            this.m_btnMax = new PinkieControls.ButtonXP();
            this.m_palReportViewer = new System.Windows.Forms.Panel();
            this.m_btnRecover = new PinkieControls.ButtonXP();
            this.btnExit = new PinkieControls.ButtonXP();
            this.m_gbpQueryCondition.SuspendLayout();
            this.m_palReportViewer.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_ReportViewer
            // 
            this.m_ReportViewer.ActiveViewIndex = -1;
            this.m_ReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_ReportViewer.DisplayGroupTree = false;
            this.m_ReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_ReportViewer.Location = new System.Drawing.Point(0, 0);
            this.m_ReportViewer.Name = "m_ReportViewer";
            this.m_ReportViewer.SelectionFormula = "";
            this.m_ReportViewer.ShowGroupTreeButton = false;
            this.m_ReportViewer.Size = new System.Drawing.Size(992, 493);
            this.m_ReportViewer.TabIndex = 0;
            this.m_ReportViewer.ViewTimeSelectionFormula = "";
            // 
            // m_btnQuery
            // 
            this.m_btnQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnQuery.DefaultScheme = true;
            this.m_btnQuery.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnQuery.Hint = "";
            this.m_btnQuery.Location = new System.Drawing.Point(831, 16);
            this.m_btnQuery.Name = "m_btnQuery";
            this.m_btnQuery.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnQuery.Size = new System.Drawing.Size(76, 30);
            this.m_btnQuery.TabIndex = 1;
            this.m_btnQuery.Text = "查询";
            this.m_btnQuery.Click += new System.EventHandler(this.m_btnQuery_Click);
            // 
            // m_cboReport
            // 
            this.m_cboReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboReport.Items.AddRange(new object[] {
            "工作量汇总",
            "工作量明细",
            "检验费用汇总",
            "检验费用明细"});
            this.m_cboReport.Location = new System.Drawing.Point(80, 20);
            this.m_cboReport.Name = "m_cboReport";
            this.m_cboReport.Size = new System.Drawing.Size(121, 22);
            this.m_cboReport.TabIndex = 2;
            // 
            // m_lbReportType
            // 
            this.m_lbReportType.AutoSize = true;
            this.m_lbReportType.Location = new System.Drawing.Point(12, 24);
            this.m_lbReportType.Name = "m_lbReportType";
            this.m_lbReportType.Size = new System.Drawing.Size(63, 14);
            this.m_lbReportType.TabIndex = 3;
            this.m_lbReportType.Text = "统计报表";
            // 
            // m_lbConfirmDat
            // 
            this.m_lbConfirmDat.AllowDrop = true;
            this.m_lbConfirmDat.AutoSize = true;
            this.m_lbConfirmDat.Location = new System.Drawing.Point(211, 24);
            this.m_lbConfirmDat.Name = "m_lbConfirmDat";
            this.m_lbConfirmDat.Size = new System.Drawing.Size(63, 14);
            this.m_lbConfirmDat.TabIndex = 4;
            this.m_lbConfirmDat.Text = "日期范围";
            // 
            // m_dtpDatFrom
            // 
            this.m_dtpDatFrom.CustomFormat = "yyyy年MM月dd日 HH时";
            this.m_dtpDatFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpDatFrom.Location = new System.Drawing.Point(275, 20);
            this.m_dtpDatFrom.Name = "m_dtpDatFrom";
            this.m_dtpDatFrom.Size = new System.Drawing.Size(157, 23);
            this.m_dtpDatFrom.TabIndex = 5;
            // 
            // m_lbDatTo
            // 
            this.m_lbDatTo.AutoSize = true;
            this.m_lbDatTo.Location = new System.Drawing.Point(432, 24);
            this.m_lbDatTo.Name = "m_lbDatTo";
            this.m_lbDatTo.Size = new System.Drawing.Size(21, 14);
            this.m_lbDatTo.TabIndex = 6;
            this.m_lbDatTo.Text = "至";
            // 
            // m_dtpDatTo
            // 
            this.m_dtpDatTo.CustomFormat = "yyyy年MM月dd日 HH时";
            this.m_dtpDatTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpDatTo.Location = new System.Drawing.Point(456, 20);
            this.m_dtpDatTo.Name = "m_dtpDatTo";
            this.m_dtpDatTo.Size = new System.Drawing.Size(157, 23);
            this.m_dtpDatTo.TabIndex = 7;
            // 
            // m_gbpQueryCondition
            // 
            this.m_gbpQueryCondition.Controls.Add(this.btnExit);
            this.m_gbpQueryCondition.Controls.Add(this.m_lbOprate);
            this.m_gbpQueryCondition.Controls.Add(this.m_cboReport);
            this.m_gbpQueryCondition.Controls.Add(this.m_lbReportType);
            this.m_gbpQueryCondition.Controls.Add(this.m_lbConfirmDat);
            this.m_gbpQueryCondition.Controls.Add(this.m_dtpDatFrom);
            this.m_gbpQueryCondition.Controls.Add(this.m_lbDatTo);
            this.m_gbpQueryCondition.Controls.Add(this.m_dtpDatTo);
            this.m_gbpQueryCondition.Controls.Add(this.m_btnQuery);
            this.m_gbpQueryCondition.Controls.Add(this.m_txtOprDoct);
            this.m_gbpQueryCondition.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_gbpQueryCondition.Location = new System.Drawing.Point(0, 0);
            this.m_gbpQueryCondition.Name = "m_gbpQueryCondition";
            this.m_gbpQueryCondition.Size = new System.Drawing.Size(992, 52);
            this.m_gbpQueryCondition.TabIndex = 8;
            this.m_gbpQueryCondition.TabStop = false;
            // 
            // m_lbOprate
            // 
            this.m_lbOprate.Location = new System.Drawing.Point(622, 24);
            this.m_lbOprate.Name = "m_lbOprate";
            this.m_lbOprate.Size = new System.Drawing.Size(64, 20);
            this.m_lbOprate.TabIndex = 11;
            this.m_lbOprate.Text = "检验医生";
            // 
            // m_txtOprDoct
            // 
            this.m_txtOprDoct.EnableAutoValidation = true;
            this.m_txtOprDoct.EnableEnterKeyValidate = true;
            this.m_txtOprDoct.EnableEscapeKeyUndo = true;
            this.m_txtOprDoct.EnableLastValidValue = true;
            this.m_txtOprDoct.ErrorProvider = null;
            this.m_txtOprDoct.ErrorProviderMessage = "Invalid value";
            this.m_txtOprDoct.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOprDoct.ForceFormatText = true;
            this.m_txtOprDoct.Location = new System.Drawing.Point(686, 20);
            this.m_txtOprDoct.m_intShowOtherEmp = 0;
            this.m_txtOprDoct.m_StrDeptID = "*";
            this.m_txtOprDoct.m_StrEmployeeID = null;
            this.m_txtOprDoct.m_StrEmployeeName = null;
            this.m_txtOprDoct.MaxLength = 20;
            this.m_txtOprDoct.Name = "m_txtOprDoct";
            this.m_txtOprDoct.Size = new System.Drawing.Size(140, 23);
            this.m_txtOprDoct.TabIndex = 10;
            // 
            // m_btnMax
            // 
            this.m_btnMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnMax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnMax.DefaultScheme = true;
            this.m_btnMax.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnMax.Hint = "";
            this.m_btnMax.Location = new System.Drawing.Point(920, 0);
            this.m_btnMax.Name = "m_btnMax";
            this.m_btnMax.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnMax.Size = new System.Drawing.Size(56, 24);
            this.m_btnMax.TabIndex = 8;
            this.m_btnMax.Text = "最大化";
            this.m_btnMax.Click += new System.EventHandler(this.m_btnMax_Click);
            // 
            // m_palReportViewer
            // 
            this.m_palReportViewer.Controls.Add(this.m_btnRecover);
            this.m_palReportViewer.Controls.Add(this.m_btnMax);
            this.m_palReportViewer.Controls.Add(this.m_ReportViewer);
            this.m_palReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_palReportViewer.Location = new System.Drawing.Point(0, 52);
            this.m_palReportViewer.Name = "m_palReportViewer";
            this.m_palReportViewer.Size = new System.Drawing.Size(992, 493);
            this.m_palReportViewer.TabIndex = 9;
            // 
            // m_btnRecover
            // 
            this.m_btnRecover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnRecover.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnRecover.DefaultScheme = true;
            this.m_btnRecover.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnRecover.Hint = "";
            this.m_btnRecover.Location = new System.Drawing.Point(860, 0);
            this.m_btnRecover.Name = "m_btnRecover";
            this.m_btnRecover.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnRecover.Size = new System.Drawing.Size(56, 24);
            this.m_btnRecover.TabIndex = 9;
            this.m_btnRecover.Text = "复原";
            this.m_btnRecover.Click += new System.EventHandler(this.m_btnRecover_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnExit.DefaultScheme = true;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExit.Hint = "";
            this.btnExit.Location = new System.Drawing.Point(910, 16);
            this.btnExit.Name = "btnExit";
            this.btnExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnExit.Size = new System.Drawing.Size(76, 30);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "关闭";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmStatReport
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(992, 545);
            this.Controls.Add(this.m_palReportViewer);
            this.Controls.Add(this.m_gbpQueryCondition);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmStatReport";
            this.Text = "统计";
            this.Load += new System.EventHandler(this.frmStatReport_Load);
            this.m_gbpQueryCondition.ResumeLayout(false);
            this.m_gbpQueryCondition.PerformLayout();
            this.m_palReportViewer.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		#endregion

		#region CreateController
		public override void CreateController()
		{
			m_objController = new clsController_StatReport();
			m_objController.Set_GUI_Apperance(this);
		}
		#endregion

		#region 查询
		private void m_btnQuery_Click(object sender, System.EventArgs e)
		{
			m_objController.m_mthCreateReport();
		}
		#endregion		

		private void m_btnMax_Click(object sender, System.EventArgs e)
		{
			this.m_gbpQueryCondition.Dock = DockStyle.None;
			this.m_palReportViewer.BringToFront();
		}

		private void m_btnRecover_Click(object sender, System.EventArgs e)
		{
			this.m_gbpQueryCondition.Dock = DockStyle.Top;
//			this.m_gbpQueryCondition.BringToFront();
		}

		private void frmStatReport_Load(object sender, System.EventArgs e)
		{
			//xing.chen add for 为统计查询增加时间
			string dateFromTemp = DateTime.Now.ToShortDateString() + " 00:00:00";
			string dateToTemp = DateTime.Now.ToShortDateString() + " 23:59:59";
			this.m_dtpDatFrom.Value = DateTime.Parse(dateFromTemp);
			this.m_dtpDatTo.Value = DateTime.Parse(dateToTemp);
		}

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

	}
}

