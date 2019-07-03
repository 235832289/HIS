using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmOPLog 的摘要说明。
	/// </summary>
	public class frmOPLog :com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.GroupBox groupBox1;
		internal CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label19;
		internal System.Windows.Forms.CheckBox chkCheckDate;
		internal System.Windows.Forms.DateTimePicker dtpTo;
		internal System.Windows.Forms.DateTimePicker dtpFrom;
		internal System.Windows.Forms.Label lblFrom;
		internal System.Windows.Forms.Label lblTo;
		internal com.digitalwave.Utility.ctlEmpTextBox txtReportDoctor;
		internal com.digitalwave.Utility.ctlDeptTextBox txtDepartment;
		private PinkieControls.ButtonXP btExit;
		private PinkieControls.ButtonXP btPrint;
		internal PinkieControls.ButtonXP btFind;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		internal System.Windows.Forms.TextBox txtDiag;
		internal System.Windows.Forms.TextBox txtICD;
		private clsDcl_OPLog  objSvc =new clsDcl_OPLog();
        internal string strAppPatch = "";
		public frmOPLog()
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
		public override void CreateController()
		{
			this.objController=new com.digitalwave.iCare.gui.HIS.clsCtl_OPLog();
			objController.Set_GUI_Apperance(this);
		}
		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btExit = new PinkieControls.ButtonXP();
			this.btPrint = new PinkieControls.ButtonXP();
			this.btFind = new PinkieControls.ButtonXP();
			this.txtReportDoctor = new com.digitalwave.Utility.ctlEmpTextBox();
			this.txtDepartment = new com.digitalwave.Utility.ctlDeptTextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.chkCheckDate = new System.Windows.Forms.CheckBox();
			this.dtpTo = new System.Windows.Forms.DateTimePicker();
			this.dtpFrom = new System.Windows.Forms.DateTimePicker();
			this.lblFrom = new System.Windows.Forms.Label();
			this.lblTo = new System.Windows.Forms.Label();
			this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtDiag = new System.Windows.Forms.TextBox();
			this.txtICD = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtICD);
			this.groupBox1.Controls.Add(this.txtDiag);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.btExit);
			this.groupBox1.Controls.Add(this.btPrint);
			this.groupBox1.Controls.Add(this.btFind);
			this.groupBox1.Controls.Add(this.txtReportDoctor);
			this.groupBox1.Controls.Add(this.txtDepartment);
			this.groupBox1.Controls.Add(this.label20);
			this.groupBox1.Controls.Add(this.label19);
			this.groupBox1.Controls.Add(this.chkCheckDate);
			this.groupBox1.Controls.Add(this.dtpTo);
			this.groupBox1.Controls.Add(this.dtpFrom);
			this.groupBox1.Controls.Add(this.lblFrom);
			this.groupBox1.Controls.Add(this.lblTo);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(976, 104);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// btExit
			// 
			this.btExit.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btExit.DefaultScheme = true;
			this.btExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btExit.Hint = "";
			this.btExit.Location = new System.Drawing.Point(736, 64);
			this.btExit.Name = "btExit";
			this.btExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btExit.Size = new System.Drawing.Size(200, 32);
			this.btExit.TabIndex = 6;
			this.btExit.Text = "退出(ESC)";
			this.btExit.Click += new System.EventHandler(this.btExit_Click);
			// 
			// btPrint
			// 
			this.btPrint.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btPrint.DefaultScheme = true;
			this.btPrint.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btPrint.Hint = "";
			this.btPrint.Location = new System.Drawing.Point(848, 22);
			this.btPrint.Name = "btPrint";
			this.btPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btPrint.Size = new System.Drawing.Size(88, 32);
			this.btPrint.TabIndex = 5;
			this.btPrint.Text = "打印(&P)";
			this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
			// 
			// btFind
			// 
			this.btFind.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btFind.DefaultScheme = true;
			this.btFind.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btFind.Hint = "";
			this.btFind.Location = new System.Drawing.Point(736, 22);
			this.btFind.Name = "btFind";
			this.btFind.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btFind.Size = new System.Drawing.Size(88, 32);
			this.btFind.TabIndex = 4;
			this.btFind.Text = "查询(&F)";
			this.btFind.Click += new System.EventHandler(this.btFind_Click);
			// 
			// txtReportDoctor
			// 
			this.txtReportDoctor.CausesValidation = false;
			this.txtReportDoctor.EnableAutoValidation = true;
			this.txtReportDoctor.EnableEnterKeyValidate = true;
			this.txtReportDoctor.EnableEscapeKeyUndo = true;
			this.txtReportDoctor.EnableLastValidValue = true;
			this.txtReportDoctor.ErrorProvider = null;
			this.txtReportDoctor.ErrorProviderMessage = "Invalid value";
			this.txtReportDoctor.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtReportDoctor.ForceFormatText = true;
			this.txtReportDoctor.Location = new System.Drawing.Point(104, 64);
			this.txtReportDoctor.m_intShowOtherEmp = 0;
			this.txtReportDoctor.m_StrDeptID = "0";
			this.txtReportDoctor.m_StrEmployeeID = null;
			this.txtReportDoctor.m_StrEmployeeName = null;
			this.txtReportDoctor.Name = "txtReportDoctor";
			this.txtReportDoctor.Size = new System.Drawing.Size(128, 23);
			this.txtReportDoctor.TabIndex = 1;
			this.txtReportDoctor.Text = "";
			// 
			// txtDepartment
			// 
			this.txtDepartment.CausesValidation = false;
			this.txtDepartment.EnableAutoValidation = true;
			this.txtDepartment.EnableEnterKeyValidate = true;
			this.txtDepartment.EnableEscapeKeyUndo = true;
			this.txtDepartment.EnableLastValidValue = true;
			this.txtDepartment.ErrorProvider = null;
			this.txtDepartment.ErrorProviderMessage = "Invalid value";
			this.txtDepartment.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtDepartment.ForceFormatText = true;
			this.txtDepartment.Location = new System.Drawing.Point(104, 24);
			this.txtDepartment.m_StrDeptID = null;
			this.txtDepartment.m_StrDeptName = null;
			this.txtDepartment.Name = "txtDepartment";
			this.txtDepartment.SetDepartment = com.digitalwave.Utility.ctlDeptTextBox.eDeptArea.All;
			this.txtDepartment.Size = new System.Drawing.Size(128, 23);
			this.txtDepartment.TabIndex = 0;
			this.txtDepartment.Text = "";
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(16, 66);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(84, 19);
			this.label20.TabIndex = 310;
			this.label20.Text = "就诊医生 ＝";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(16, 29);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(84, 19);
			this.label19.TabIndex = 309;
			this.label19.Text = "就诊科室 ＝";
			// 
			// chkCheckDate
			// 
			this.chkCheckDate.Checked = true;
			this.chkCheckDate.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkCheckDate.Location = new System.Drawing.Point(472, 64);
			this.chkCheckDate.Name = "chkCheckDate";
			this.chkCheckDate.Size = new System.Drawing.Size(84, 24);
			this.chkCheckDate.TabIndex = 308;
			this.chkCheckDate.Text = "就诊日期";
			// 
			// dtpTo
			// 
			this.dtpTo.CalendarFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.dtpTo.CustomFormat = "yyyy年MM月dd日 ";
			this.dtpTo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpTo.Location = new System.Drawing.Point(592, 64);
			this.dtpTo.Name = "dtpTo";
			this.dtpTo.Size = new System.Drawing.Size(124, 23);
			this.dtpTo.TabIndex = 3;
			this.dtpTo.Value = new System.DateTime(2005, 10, 18, 0, 0, 0, 0);
			// 
			// dtpFrom
			// 
			this.dtpFrom.AllowDrop = true;
			this.dtpFrom.CalendarFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.dtpFrom.CustomFormat = "yyyy年MM月dd日 ";
			this.dtpFrom.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpFrom.Location = new System.Drawing.Point(592, 24);
			this.dtpFrom.Name = "dtpFrom";
			this.dtpFrom.Size = new System.Drawing.Size(124, 23);
			this.dtpFrom.TabIndex = 2;
			this.dtpFrom.Value = new System.DateTime(2005, 10, 18, 0, 0, 0, 0);
			// 
			// lblFrom
			// 
			this.lblFrom.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblFrom.Location = new System.Drawing.Point(560, 24);
			this.lblFrom.Name = "lblFrom";
			this.lblFrom.Size = new System.Drawing.Size(24, 23);
			this.lblFrom.TabIndex = 305;
			this.lblFrom.Text = "从";
			this.lblFrom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblTo
			// 
			this.lblTo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblTo.Location = new System.Drawing.Point(560, 64);
			this.lblTo.Name = "lblTo";
			this.lblTo.Size = new System.Drawing.Size(24, 23);
			this.lblTo.TabIndex = 304;
			this.lblTo.Text = "至";
			this.lblTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// crystalReportViewer1
			// 
			this.crystalReportViewer1.ActiveViewIndex = -1;
			this.crystalReportViewer1.DisplayGroupTree = false;
			this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.crystalReportViewer1.Location = new System.Drawing.Point(0, 104);
			this.crystalReportViewer1.Name = "crystalReportViewer1";
			this.crystalReportViewer1.ReportSource = null;
			this.crystalReportViewer1.Size = new System.Drawing.Size(976, 445);
			this.crystalReportViewer1.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(248, 29);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(70, 19);
			this.label1.TabIndex = 311;
			this.label1.Text = "诊断包含:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(248, 66);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(77, 19);
			this.label2.TabIndex = 312;
			this.label2.Text = "ICD码包含:";
			// 
			// txtDiag
			// 
			this.txtDiag.Location = new System.Drawing.Point(328, 24);
			this.txtDiag.Name = "txtDiag";
			this.txtDiag.Size = new System.Drawing.Size(208, 23);
			this.txtDiag.TabIndex = 313;
			this.txtDiag.Text = "";
			// 
			// txtICD
			// 
			this.txtICD.Location = new System.Drawing.Point(328, 64);
			this.txtICD.Name = "txtICD";
			this.txtICD.Size = new System.Drawing.Size(128, 23);
			this.txtICD.TabIndex = 314;
			this.txtICD.Text = "";
			// 
			// frmOPLog
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.CancelButton = this.btExit;
			this.ClientSize = new System.Drawing.Size(976, 549);
			this.Controls.Add(this.crystalReportViewer1);
			this.Controls.Add(this.groupBox1);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.Name = "frmOPLog";
			this.Text = "门诊工作日志";
			this.Load += new System.EventHandler(this.frmOPLog_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
        internal CrystalDecisions.CrystalReports.Engine.ReportDocument objReportDocument;
		private void frmOPLog_Load(object sender, System.EventArgs e)
        {
            this.strAppPatch = Application.StartupPath + "\\";
            this.txtDepartment.m_lsvList.Width = this.txtDepartment.Width;
            this.txtDepartment.m_lsvList.Columns[0].Width = this.txtDepartment.Width;
            this.txtReportDoctor.m_lsvList.Width = this.txtReportDoctor.Width;


			dtpFrom.Value =DateTime.Now;
			dtpTo.Value =DateTime.Now;
			objReportDocument= new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            objReportDocument.Load(strAppPatch + "Report\\rptOPLog.rpt");
			TextObject txtReportTitle=objReportDocument.ReportDefinition.ReportObjects["Text10"] as TextObject;
			txtReportTitle.Text =((clsCtl_OPLog)this.objController).m_objComInfo.m_strGetHospitalTitle()+"门诊工作日志报表";
            if(this.chkCheckDate.Checked)
            {
                ((TextObject)objReportDocument.ReportDefinition.ReportObjects["TextDate"]).Text = dtpFrom.Value.ToString("yyyy-MM-dd") + " ~ " + dtpTo.Value.ToString("yyyy-MM-dd");
            }
//			this.crystalReportViewer1.ReportSource =objReportDocument;
			if(strDoctorID!="")
			{
			((clsCtl_OPLog)this.objController).m_mthLogData();
			}
			
		
		}
		private string strDoctorID="";

		private void btExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btFind_Click(object sender, System.EventArgs e)
		{
            if (this.chkCheckDate.Checked)
            {
                ((TextObject)objReportDocument.ReportDefinition.ReportObjects["TextDate"]).Text = dtpFrom.Value.ToString("yyyy-MM-dd") + " ~ " + dtpTo.Value.ToString("yyyy-MM-dd");
            }
            else
            {
                ((TextObject)objReportDocument.ReportDefinition.ReportObjects["TextDate"]).Text = "";
            }
			((clsCtl_OPLog)this.objController).m_mthLogData();
		}

		private void btPrint_Click(object sender, System.EventArgs e)
		{
			try
			{
			 this.objReportDocument.PrintToPrinter(0,false,0,1);
			}
			catch
			{
			
			}
		}
	
		public string DoctorID
		{
			set
			{
				strDoctorID =value;
				this.txtReportDoctor.m_StrEmployeeID=value;
				this.txtReportDoctor.Enabled =false;
			}
		}
	}
}
