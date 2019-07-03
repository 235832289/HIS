using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 全院病人流动情况统计——界面表示层
	/// 作者： 徐斌辉
	/// 创建时间： 2004-09-23
	/// </summary>
	public class frmStatHospitalPatientFlow : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		internal System.Windows.Forms.DateTimePicker dateTimePicker1;
		internal System.Windows.Forms.DateTimePicker dateTimePicker2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		internal CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
		internal CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer2;
		private PinkieControls.ButtonXP cmdFind;
		private PinkieControls.ButtonXP cmdPrint;
		private PinkieControls.ButtonXP cmdClear;
		private PinkieControls.ButtonXP cmdClose;
		#region 控件-变量申明
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region 构造函数
		public frmStatHospitalPatientFlow()
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
		#endregion

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cmdFind = new PinkieControls.ButtonXP();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
			this.label4 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cmdPrint = new PinkieControls.ButtonXP();
			this.cmdClear = new PinkieControls.ButtonXP();
			this.cmdClose = new PinkieControls.ButtonXP();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.crystalReportViewer2 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cmdFind);
			this.groupBox1.Controls.Add(this.dateTimePicker1);
			this.groupBox1.Controls.Add(this.dateTimePicker2);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.cmdPrint);
			this.groupBox1.Controls.Add(this.cmdClear);
			this.groupBox1.Controls.Add(this.cmdClose);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(1002, 48);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "功能区域：";
			// 
			// cmdFind
			// 
			this.cmdFind.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.cmdFind.DefaultScheme = true;
			this.cmdFind.DialogResult = System.Windows.Forms.DialogResult.None;
			this.cmdFind.Hint = "";
			this.cmdFind.Location = new System.Drawing.Point(616, 16);
			this.cmdFind.Name = "cmdFind";
			this.cmdFind.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.cmdFind.Size = new System.Drawing.Size(80, 23);
			this.cmdFind.TabIndex = 6;
			this.cmdFind.Text = "查  询[F3]";
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(83, 18);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(112, 23);
			this.dateTimePicker1.TabIndex = 3;
			// 
			// dateTimePicker2
			// 
			this.dateTimePicker2.Location = new System.Drawing.Point(213, 18);
			this.dateTimePicker2.Name = "dateTimePicker2";
			this.dateTimePicker2.Size = new System.Drawing.Size(112, 23);
			this.dateTimePicker2.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(194, 22);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(20, 19);
			this.label4.TabIndex = 4;
			this.label4.Text = "--";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 19);
			this.label1.TabIndex = 1;
			this.label1.Text = "统计时间：";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmdPrint
			// 
			this.cmdPrint.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.cmdPrint.DefaultScheme = true;
			this.cmdPrint.DialogResult = System.Windows.Forms.DialogResult.None;
			this.cmdPrint.Hint = "";
			this.cmdPrint.Location = new System.Drawing.Point(712, 16);
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.cmdPrint.Size = new System.Drawing.Size(80, 23);
			this.cmdPrint.TabIndex = 6;
			this.cmdPrint.Text = "打印[F4]";
			// 
			// cmdClear
			// 
			this.cmdClear.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.cmdClear.DefaultScheme = true;
			this.cmdClear.DialogResult = System.Windows.Forms.DialogResult.None;
			this.cmdClear.Hint = "";
			this.cmdClear.Location = new System.Drawing.Point(808, 16);
			this.cmdClear.Name = "cmdClear";
			this.cmdClear.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.cmdClear.Size = new System.Drawing.Size(80, 23);
			this.cmdClear.TabIndex = 6;
			this.cmdClear.Text = "清屏[F5]";
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.cmdClose.DefaultScheme = true;
			this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.None;
			this.cmdClose.Hint = "";
			this.cmdClose.Location = new System.Drawing.Point(904, 16);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.cmdClose.Size = new System.Drawing.Size(80, 23);
			this.cmdClose.TabIndex = 6;
			this.cmdClose.Text = "关闭[F6]";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.tabControl1);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.groupBox2.Location = new System.Drawing.Point(0, 48);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(1002, 615);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "信息区域";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.HotTrack = true;
			this.tabControl1.Location = new System.Drawing.Point(3, 19);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(996, 593);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.crystalReportViewer1);
			this.tabPage1.Location = new System.Drawing.Point(4, 23);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(988, 566);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "按科室|病区统计";
			// 
			// crystalReportViewer1
			// 
			this.crystalReportViewer1.ActiveViewIndex = -1;
			this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
			this.crystalReportViewer1.Name = "crystalReportViewer1";
			this.crystalReportViewer1.ReportSource = null;
			this.crystalReportViewer1.Size = new System.Drawing.Size(988, 566);
			this.crystalReportViewer1.TabIndex = 0;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.crystalReportViewer2);
			this.tabPage2.Location = new System.Drawing.Point(4, 23);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(988, 566);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "按身份统计";
			// 
			// crystalReportViewer2
			// 
			this.crystalReportViewer2.ActiveViewIndex = -1;
			this.crystalReportViewer2.DisplayGroupTree = false;
			this.crystalReportViewer2.DisplayToolbar = false;
			this.crystalReportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.crystalReportViewer2.Location = new System.Drawing.Point(0, 0);
			this.crystalReportViewer2.Name = "crystalReportViewer2";
			this.crystalReportViewer2.ReportSource = null;
			this.crystalReportViewer2.Size = new System.Drawing.Size(988, 566);
			this.crystalReportViewer2.TabIndex = 0;
			// 
			// frmStatHospitalPatientFlow
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(1002, 663);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "frmStatHospitalPatientFlow";
			this.Text = "全院病人流动情况统计";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override void CreateController()
		{
			this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_StatHospitalPatientFlow();
			objController.Set_GUI_Apperance(this);
		}

		#region 事件
		#endregion
	}
}
