using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;


namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmOutPatient 的摘要说明。
	/// </summary>
	public class frmOutPatient : com.digitalwave.GUI_Base.frmMDI_Child_Base	//GUI_Base.dll
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private PinkieControls.ButtonXP buttonXP1;
		private System.Windows.Forms.Panel panel2;
		public System.Windows.Forms.DateTimePicker m_dateTimePickerbegin;
		public System.Windows.Forms.DateTimePicker m_dateTimePickerEnd;
		public CrystalDecisions.Windows.Forms.CrystalReportViewer m_crystalReportViewer1;
		private PinkieControls.ButtonXP m_btnExit;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmOutPatient()
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
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmOutpatientChargeIdetityPrint());
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.m_btnExit = new PinkieControls.ButtonXP();
			this.buttonXP1 = new PinkieControls.ButtonXP();
			this.m_dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.m_dateTimePickerbegin = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.m_crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.m_btnExit);
			this.panel1.Controls.Add(this.buttonXP1);
			this.panel1.Controls.Add(this.m_dateTimePickerEnd);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.m_dateTimePickerbegin);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(680, 48);
			this.panel1.TabIndex = 0;
			// 
			// m_btnExit
			// 
			this.m_btnExit.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnExit.DefaultScheme = true;
			this.m_btnExit.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnExit.Hint = "";
			this.m_btnExit.Location = new System.Drawing.Point(568, 8);
			this.m_btnExit.Name = "m_btnExit";
			this.m_btnExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnExit.Size = new System.Drawing.Size(96, 32);
			this.m_btnExit.TabIndex = 5;
			this.m_btnExit.Text = "退出";
			this.m_btnExit.Click += new System.EventHandler(this.m_btnExit_Click);
			// 
			// buttonXP1
			// 
			this.buttonXP1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.buttonXP1.DefaultScheme = true;
			this.buttonXP1.DialogResult = System.Windows.Forms.DialogResult.None;
			this.buttonXP1.Hint = "";
			this.buttonXP1.Location = new System.Drawing.Point(456, 8);
			this.buttonXP1.Name = "buttonXP1";
			this.buttonXP1.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.buttonXP1.Size = new System.Drawing.Size(96, 32);
			this.buttonXP1.TabIndex = 4;
			this.buttonXP1.Text = "统计";
			this.buttonXP1.Click += new System.EventHandler(this.buttonXP1_Click);
			// 
			// m_dateTimePickerEnd
			// 
			this.m_dateTimePickerEnd.Location = new System.Drawing.Point(312, 13);
			this.m_dateTimePickerEnd.Name = "m_dateTimePickerEnd";
			this.m_dateTimePickerEnd.Size = new System.Drawing.Size(128, 23);
			this.m_dateTimePickerEnd.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(280, 15);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(20, 19);
			this.label2.TabIndex = 2;
			this.label2.Text = "至";
			// 
			// m_dateTimePickerbegin
			// 
			this.m_dateTimePickerbegin.Location = new System.Drawing.Point(144, 13);
			this.m_dateTimePickerbegin.Name = "m_dateTimePickerbegin";
			this.m_dateTimePickerbegin.Size = new System.Drawing.Size(128, 23);
			this.m_dateTimePickerbegin.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(80, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(63, 19);
			this.label1.TabIndex = 0;
			this.label1.Text = "统计日期";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.m_crystalReportViewer1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 48);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(680, 469);
			this.panel2.TabIndex = 1;
			// 
			// m_crystalReportViewer1
			// 
			this.m_crystalReportViewer1.ActiveViewIndex = -1;
			this.m_crystalReportViewer1.DisplayGroupTree = false;
			this.m_crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
			this.m_crystalReportViewer1.Name = "m_crystalReportViewer1";
			this.m_crystalReportViewer1.ReportSource = null;
			this.m_crystalReportViewer1.Size = new System.Drawing.Size(680, 469);
			this.m_crystalReportViewer1.TabIndex = 0;
			// 
			// frmOutPatient
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(680, 517);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.Name = "frmOutPatient";
			this.Text = "门诊收费核算分类组成报表";
			this.Load += new System.EventHandler(this.frmOutPatient_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region 重载CreateController
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		public override void CreateController()
		{			
			this.objController = new clsOutPatient();
			this.objController.Set_GUI_Apperance(this);
		}
		#endregion

		private void frmOutPatient_Load(object sender, System.EventArgs e)
		{
			//初始化时间控件
			((clsOutPatient)objController).m_mthFrmInit();			
		}

		private void buttonXP1_Click(object sender, System.EventArgs e)
		{
			//统计
			((clsOutPatient)objController).m_mthButtonClickToStatistic();					
		}

		private void m_btnExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
