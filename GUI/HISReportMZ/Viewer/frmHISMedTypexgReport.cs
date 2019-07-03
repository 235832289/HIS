using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
	/// <summary>
	/// frmHISMedTypexgReport 的摘要说明。
	/// </summary>
	public class frmHISMedTypexgReport : com.digitalwave.GUI_Base.frmMDI_Child_Base	//GUI_Base.dll
	{
		private System.Windows.Forms.Panel panel1;
		internal System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		internal PinkieControls.ButtonXP buttonXP1;
		private PinkieControls.ButtonXP buttonXP2;
		internal System.Windows.Forms.DateTimePicker m_dtpStartDate;
		internal System.Windows.Forms.DateTimePicker m_dtpEndDate;
		internal CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        internal PinkieControls.ButtonXP btnExplore;
        internal PinkieControls.ButtonXP btnPrint;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmHISMedTypexgReport()
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
            this.buttonXP2 = new PinkieControls.ButtonXP();
            this.buttonXP1 = new PinkieControls.ButtonXP();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.m_dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnPrint = new PinkieControls.ButtonXP();
            this.btnExplore = new PinkieControls.ButtonXP();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExplore);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.buttonXP2);
            this.panel1.Controls.Add(this.buttonXP1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.m_dtpEndDate);
            this.panel1.Controls.Add(this.m_dtpStartDate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(960, 56);
            this.panel1.TabIndex = 0;
            // 
            // buttonXP2
            // 
            this.buttonXP2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonXP2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP2.DefaultScheme = true;
            this.buttonXP2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonXP2.Hint = "";
            this.buttonXP2.Location = new System.Drawing.Point(855, 10);
            this.buttonXP2.Name = "buttonXP2";
            this.buttonXP2.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP2.Size = new System.Drawing.Size(78, 34);
            this.buttonXP2.TabIndex = 5;
            this.buttonXP2.Text = "退出";
            this.buttonXP2.Click += new System.EventHandler(this.buttonXP2_Click);
            // 
            // buttonXP1
            // 
            this.buttonXP1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonXP1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP1.DefaultScheme = true;
            this.buttonXP1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonXP1.Hint = "";
            this.buttonXP1.Location = new System.Drawing.Point(591, 10);
            this.buttonXP1.Name = "buttonXP1";
            this.buttonXP1.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP1.Size = new System.Drawing.Size(78, 34);
            this.buttonXP1.TabIndex = 4;
            this.buttonXP1.Text = "统计";
            this.buttonXP1.Click += new System.EventHandler(this.buttonXP1_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(320, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "至";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "统计日期";
            // 
            // m_dtpEndDate
            // 
            this.m_dtpEndDate.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.m_dtpEndDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpEndDate.Location = new System.Drawing.Point(344, 16);
            this.m_dtpEndDate.Name = "m_dtpEndDate";
            this.m_dtpEndDate.Size = new System.Drawing.Size(216, 23);
            this.m_dtpEndDate.TabIndex = 1;
            // 
            // m_dtpStartDate
            // 
            this.m_dtpStartDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpStartDate.Location = new System.Drawing.Point(88, 16);
            this.m_dtpStartDate.Name = "m_dtpStartDate";
            this.m_dtpStartDate.Size = new System.Drawing.Size(216, 23);
            this.m_dtpStartDate.TabIndex = 0;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.DisplayGroupTree = false;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 56);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new System.Drawing.Size(960, 517);
            this.crystalReportViewer1.TabIndex = 1;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnPrint.DefaultScheme = true;
            this.btnPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPrint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrint.Hint = "";
            this.btnPrint.Location = new System.Drawing.Point(679, 10);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnPrint.Size = new System.Drawing.Size(78, 34);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "打印";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnExplore
            // 
            this.btnExplore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExplore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnExplore.DefaultScheme = true;
            this.btnExplore.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExplore.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExplore.Hint = "";
            this.btnExplore.Location = new System.Drawing.Point(767, 10);
            this.btnExplore.Name = "btnExplore";
            this.btnExplore.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnExplore.Size = new System.Drawing.Size(78, 34);
            this.btnExplore.TabIndex = 7;
            this.btnExplore.Text = "导出";
            this.btnExplore.Click += new System.EventHandler(this.btnExplore_Click);
            // 
            // frmHISMedTypexgReport
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(960, 573);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.panel1);
            this.Name = "frmHISMedTypexgReport";
            this.Text = "门诊收费发票分类组成报表";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		#region 重载CreateController
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		public override void CreateController()
		{			
			this.objController = new clsControlHISMedxgReport();
			this.objController.Set_GUI_Apperance(this);
		}
		#endregion

		private void buttonXP1_Click(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.AppStarting; //设置鼠标状态
         
			((clsControlHISMedxgReport)this.objController).Statistic();
			this.Cursor = System.Windows.Forms.Cursors.Default; //还原鼠标状态

		}
		
		private void buttonXP2_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

        private void btnPrint_Click(object sender, EventArgs e)
        {            
            this.crystalReportViewer1.PrintReport();
        }

        private void btnExplore_Click(object sender, EventArgs e)
        {
            this.crystalReportViewer1.ExportReport();
        }		
	}
}
