using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmReckoningReport 的摘要说明。
	/// </summary>
	public class frmMedicineProtectReport: com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		internal CrystalDecisions.Windows.Forms.CrystalReportViewer cryReportViewer;
		internal PinkieControls.ButtonXP m_btnQulReg;
		internal System.Windows.Forms.DateTimePicker m_daFinDate;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label1;
		internal System.Windows.Forms.DateTimePicker m_daFinDateLast;
		internal PinkieControls.ButtonXP m_btnExit;
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
            this.cryReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.m_btnQulReg = new PinkieControls.ButtonXP();
            this.m_daFinDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_btnExit = new PinkieControls.ButtonXP();
            this.m_daFinDateLast = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cryReportViewer
            // 
            this.cryReportViewer.ActiveViewIndex = -1;
            this.cryReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cryReportViewer.DisplayGroupTree = false;
            this.cryReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cryReportViewer.Location = new System.Drawing.Point(3, 19);
            this.cryReportViewer.Name = "cryReportViewer";
            this.cryReportViewer.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.cryReportViewer.SelectionFormula = "";
            this.cryReportViewer.Size = new System.Drawing.Size(826, 434);
            this.cryReportViewer.TabIndex = 59;
            this.cryReportViewer.ViewTimeSelectionFormula = "";
            // 
            // m_btnQulReg
            // 
            this.m_btnQulReg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnQulReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnQulReg.DefaultScheme = true;
            this.m_btnQulReg.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnQulReg.Hint = "";
            this.m_btnQulReg.Location = new System.Drawing.Point(592, 16);
            this.m_btnQulReg.Name = "m_btnQulReg";
            this.m_btnQulReg.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnQulReg.Size = new System.Drawing.Size(88, 32);
            this.m_btnQulReg.TabIndex = 3;
            this.m_btnQulReg.Text = "确定(F5)";
            this.m_btnQulReg.Click += new System.EventHandler(this.m_btnQulReg_Click);
            // 
            // m_daFinDate
            // 
            this.m_daFinDate.Location = new System.Drawing.Point(256, 23);
            this.m_daFinDate.Name = "m_daFinDate";
            this.m_daFinDate.Size = new System.Drawing.Size(128, 23);
            this.m_daFinDate.TabIndex = 1;
            this.m_daFinDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_daFinDate_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.m_btnExit);
            this.groupBox1.Controls.Add(this.m_daFinDateLast);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.m_btnQulReg);
            this.groupBox1.Controls.Add(this.m_daFinDate);
            this.groupBox1.Location = new System.Drawing.Point(8, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(832, 56);
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
            this.m_btnExit.Location = new System.Drawing.Point(720, 16);
            this.m_btnExit.Name = "m_btnExit";
            this.m_btnExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnExit.Size = new System.Drawing.Size(88, 32);
            this.m_btnExit.TabIndex = 65;
            this.m_btnExit.Text = "退出(Esc)";
            this.m_btnExit.Click += new System.EventHandler(this.m_btnExit_Click);
            // 
            // m_daFinDateLast
            // 
            this.m_daFinDateLast.Location = new System.Drawing.Point(440, 23);
            this.m_daFinDateLast.Name = "m_daFinDateLast";
            this.m_daFinDateLast.Size = new System.Drawing.Size(128, 23);
            this.m_daFinDateLast.TabIndex = 2;
            this.m_daFinDateLast.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_daFinDateLast_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(400, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 14);
            this.label1.TabIndex = 64;
            this.label1.Text = "至";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 63;
            this.label2.Text = "统计日期:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cryReportViewer);
            this.groupBox2.Location = new System.Drawing.Point(8, 56);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(832, 456);
            this.groupBox2.TabIndex = 62;
            this.groupBox2.TabStop = false;
            // 
            // frmMedicineProtectReport
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(848, 517);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.KeyPreview = true;
            this.Name = "frmMedicineProtectReport";
            this.Text = "医保月结算表";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMedicineProtectReport_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		public override void CreateController()
		{
			this.objController=new com.digitalwave.iCare.gui.HIS.clsControlMedicineProtectReport();
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

	}
}
