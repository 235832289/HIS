using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 药库入库单统计窗体 ：created by weiling.huang  at 2005-9-14
	/// </summary>
	public class frmHisMedInOrderStatistic : com.digitalwave.GUI_Base.frmMDI_Child_Base	//GUI_Base.dll
	{
		private System.Windows.Forms.Panel panel1;
		private PinkieControls.ButtonXP m_btnExit;
		private System.Windows.Forms.Label label1;
		private PinkieControls.ButtonXP m_btnStatistic;
		private System.Windows.Forms.Panel panel2;
		internal CrystalDecisions.Windows.Forms.CrystalReportViewer m_crystalReportViewer1;
		internal System.Windows.Forms.ComboBox m_cboSelPeriod;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmHisMedInOrderStatistic()
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.m_cboSelPeriod = new System.Windows.Forms.ComboBox();
			this.m_btnExit = new PinkieControls.ButtonXP();
			this.m_btnStatistic = new PinkieControls.ButtonXP();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.m_crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.m_cboSelPeriod);
			this.panel1.Controls.Add(this.m_btnExit);
			this.panel1.Controls.Add(this.m_btnStatistic);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(864, 48);
			this.panel1.TabIndex = 0;
			this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			// 
			// m_cboSelPeriod
			// 
			this.m_cboSelPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboSelPeriod.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboSelPeriod.Location = new System.Drawing.Point(72, 14);
			this.m_cboSelPeriod.Name = "m_cboSelPeriod";
			this.m_cboSelPeriod.Size = new System.Drawing.Size(200, 22);
			this.m_cboSelPeriod.TabIndex = 0;
			// 
			// m_btnExit
			// 
			this.m_btnExit.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnExit.DefaultScheme = true;
			this.m_btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btnExit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_btnExit.Hint = "";
			this.m_btnExit.Location = new System.Drawing.Point(392, 8);
			this.m_btnExit.Name = "m_btnExit";
			this.m_btnExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnExit.Size = new System.Drawing.Size(96, 32);
			this.m_btnExit.TabIndex = 30;
			this.m_btnExit.Text = "退出(&ESC)";
			this.m_btnExit.Click += new System.EventHandler(this.m_btnExit_Click);
			// 
			// m_btnStatistic
			// 
			this.m_btnStatistic.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnStatistic.DefaultScheme = true;
			this.m_btnStatistic.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnStatistic.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_btnStatistic.Hint = "";
			this.m_btnStatistic.Location = new System.Drawing.Point(280, 8);
			this.m_btnStatistic.Name = "m_btnStatistic";
			this.m_btnStatistic.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnStatistic.Size = new System.Drawing.Size(96, 32);
			this.m_btnStatistic.TabIndex = 20;
			this.m_btnStatistic.Text = "统计(&S)";
			this.m_btnStatistic.Click += new System.EventHandler(this.m_btnStatistic_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 19);
			this.label1.TabIndex = 50;
			this.label1.Text = "账务日期：";
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.m_crystalReportViewer1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 48);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(864, 509);
			this.panel2.TabIndex = 3;
			// 
			// m_crystalReportViewer1
			// 
			this.m_crystalReportViewer1.ActiveViewIndex = -1;
			this.m_crystalReportViewer1.DisplayGroupTree = false;
			this.m_crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
			this.m_crystalReportViewer1.Name = "m_crystalReportViewer1";
			this.m_crystalReportViewer1.ReportSource = null;
			this.m_crystalReportViewer1.Size = new System.Drawing.Size(862, 507);
			this.m_crystalReportViewer1.TabIndex = 40;
			// 
			// frmHisMedInOrderStatistic
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.CancelButton = this.m_btnExit;
			this.ClientSize = new System.Drawing.Size(864, 557);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.Name = "frmHisMedInOrderStatistic";
			this.Text = "药库入库单统计";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmHisMedInOrderStatistic_Load);
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
			this.objController = new clsHisMedInOrderStatistic();
			this.objController.Set_GUI_Apperance(this);
		}
		#endregion

		private void m_btnExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void m_btnStatistic_Click(object sender, System.EventArgs e)
		{
			//统计
		
			((clsHisMedInOrderStatistic)objController).m_mthButtonClickToStatistic();		
		}

		private void frmHisMedInOrderStatistic_Load(object sender, System.EventArgs e)
		{
			//初始化时间控件
			((clsHisMedInOrderStatistic)objController).m_mthFrmInit();	
		}

		private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}
	}
}
