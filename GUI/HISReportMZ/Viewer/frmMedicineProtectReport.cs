using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
	/// <summary>
	/// frmReckoningReport 的摘要说明。
	/// </summary>
	public class frmMedicineProtectReport: com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
		internal PinkieControls.ButtonXP m_btnQulReg;
		internal System.Windows.Forms.DateTimePicker m_daFinDate;
		private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		internal System.Windows.Forms.DateTimePicker m_daFinDateLast;
		internal PinkieControls.ButtonXP m_btnExit;
        internal Sybase.DataWindow.DataWindowControl dw;
        internal PinkieControls.ButtonXP btnExport;
        internal PinkieControls.ButtonXP btnPreview;
        internal PinkieControls.ButtonXP btnPrint;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmMedicineProtectReport()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMedicineProtectReport));
            this.m_btnQulReg = new PinkieControls.ButtonXP();
            this.m_daFinDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_btnExit = new PinkieControls.ButtonXP();
            this.m_daFinDateLast = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dw = new Sybase.DataWindow.DataWindowControl();
            this.btnPrint = new PinkieControls.ButtonXP();
            this.btnPreview = new PinkieControls.ButtonXP();
            this.btnExport = new PinkieControls.ButtonXP();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btnQulReg
            // 
            this.m_btnQulReg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnQulReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnQulReg.DefaultScheme = true;
            this.m_btnQulReg.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnQulReg.Hint = "";
            this.m_btnQulReg.Location = new System.Drawing.Point(409, 16);
            this.m_btnQulReg.Name = "m_btnQulReg";
            this.m_btnQulReg.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnQulReg.Size = new System.Drawing.Size(88, 32);
            this.m_btnQulReg.TabIndex = 3;
            this.m_btnQulReg.Text = "查询(F5)";
            this.m_btnQulReg.Click += new System.EventHandler(this.m_btnQulReg_Click);
            // 
            // m_daFinDate
            // 
            this.m_daFinDate.Location = new System.Drawing.Point(100, 20);
            this.m_daFinDate.Name = "m_daFinDate";
            this.m_daFinDate.Size = new System.Drawing.Size(128, 23);
            this.m_daFinDate.TabIndex = 1;
            this.m_daFinDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_daFinDate_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExport);
            this.groupBox1.Controls.Add(this.btnPreview);
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.m_btnExit);
            this.groupBox1.Controls.Add(this.m_daFinDateLast);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.m_btnQulReg);
            this.groupBox1.Controls.Add(this.m_daFinDate);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(885, 56);
            this.groupBox1.TabIndex = 61;
            this.groupBox1.TabStop = false;
            // 
            // m_btnExit
            // 
            this.m_btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnExit.DefaultScheme = true;
            this.m_btnExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnExit.Hint = "";
            this.m_btnExit.Location = new System.Drawing.Point(789, 16);
            this.m_btnExit.Name = "m_btnExit";
            this.m_btnExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnExit.Size = new System.Drawing.Size(88, 32);
            this.m_btnExit.TabIndex = 65;
            this.m_btnExit.Text = "退出(Esc)";
            this.m_btnExit.Click += new System.EventHandler(this.m_btnExit_Click);
            // 
            // m_daFinDateLast
            // 
            this.m_daFinDateLast.Location = new System.Drawing.Point(272, 20);
            this.m_daFinDateLast.Name = "m_daFinDateLast";
            this.m_daFinDateLast.Size = new System.Drawing.Size(128, 23);
            this.m_daFinDateLast.TabIndex = 2;
            this.m_daFinDateLast.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_daFinDateLast_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(240, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 14);
            this.label1.TabIndex = 64;
            this.label1.Text = "至";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 63;
            this.label2.Text = "统计日期:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dw
            // 
            this.dw.DataWindowObject = "";
            this.dw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dw.LibraryList = "";
            this.dw.Location = new System.Drawing.Point(0, 56);
            this.dw.Name = "dw";
            this.dw.Size = new System.Drawing.Size(885, 461);
            this.dw.TabIndex = 60;
            this.dw.Text = "dataWindowControl1";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnPrint.DefaultScheme = true;
            this.btnPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPrint.Hint = "";
            this.btnPrint.Location = new System.Drawing.Point(504, 16);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnPrint.Size = new System.Drawing.Size(88, 32);
            this.btnPrint.TabIndex = 66;
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnPreview.DefaultScheme = true;
            this.btnPreview.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPreview.Hint = "";
            this.btnPreview.Location = new System.Drawing.Point(599, 16);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnPreview.Size = new System.Drawing.Size(88, 32);
            this.btnPreview.TabIndex = 67;
            this.btnPreview.Text = "预览(&V)";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnExport.DefaultScheme = true;
            this.btnExport.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExport.Hint = "";
            this.btnExport.Location = new System.Drawing.Point(694, 16);
            this.btnExport.Name = "btnExport";
            this.btnExport.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnExport.Size = new System.Drawing.Size(88, 32);
            this.btnExport.TabIndex = 68;
            this.btnExport.Text = "导出(&E)";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // frmMedicineProtectReport
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(885, 517);
            this.Controls.Add(this.dw);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmMedicineProtectReport";
            this.Text = "医保月结算表";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMedicineProtectReport_KeyDown);
            this.Load += new System.EventHandler(this.frmMedicineProtectReport_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		public override void CreateController()
		{
            this.objController = new com.digitalwave.iCare.gui.HIS.Reports.clsControlMedicineProtectReport();
			objController.Set_GUI_Apperance(this);
		}

		private void m_btnQulReg_Click(object sender, System.EventArgs e)
		{
			((clsControlMedicineProtectReport)this.objController).m_mthFindByDateReport();
			this.m_daFinDate.Focus();
		}

		#region 快捷键
		private void frmMedicineProtectReport_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.F5)
			{
				((clsControlMedicineProtectReport)this.objController).m_mthFindByDateReport();
				this.m_daFinDate.Focus();
			}
			if(e.KeyCode == Keys.Escape)
			{
				if(MessageBox.Show("确认退出吗?","iCare",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
					return;
				this.Close();
			}
		}

		int keyTime = 0;
		private void m_daFinDate_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && keyTime != 3)
			{
				keyTime++;
				SendKeys.SendWait("{Right}");
			}
			
			if (e.KeyCode == Keys.Enter && keyTime == 3)
			{
				keyTime = 0;
				SendKeys.SendWait("{Tab}");
			}

			if(e.KeyCode == Keys.F5)
			{
				((clsControlMedicineProtectReport)this.objController).m_mthFindByDateReport();
				this.m_daFinDate.Focus();
			}
		}

		private void m_daFinDateLast_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && keyTime != 3)
			{
				keyTime++;
				SendKeys.SendWait("{Right}");
			}
			
			if (e.KeyCode == Keys.Enter && keyTime == 3)
			{
				keyTime = 0;
				SendKeys.SendWait("{Tab}");
			}

			if(e.KeyCode == Keys.F5)
			{
				((clsControlMedicineProtectReport)this.objController).m_mthFindByDateReport();
				this.m_daFinDate.Focus();
			}
		}

		#endregion

		private void m_btnExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

        private void frmMedicineProtectReport_Load(object sender, EventArgs e)
        {
            this.dw.LibraryList = Application.StartupPath + "\\PB_OP.pbl";
            this.dw.DataWindowObject = "medicineprotectreport";
            this.dw.InsertRow(0);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            clsPublic.PrintDialog(this.dw);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            clsPublic.ExportDataWindow(this.dw, null);
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            this.dw.PrintProperties.Preview = !this.dw.PrintProperties.Preview;
        }

	}
}
