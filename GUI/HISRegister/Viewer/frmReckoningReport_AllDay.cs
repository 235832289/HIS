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
	public class frmReckoningReport_AllDay: com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		internal CrystalDecisions.Windows.Forms.CrystalReportViewer cryReportViewer;
		internal PinkieControls.ButtonXP m_btnQulReg;
		internal System.Windows.Forms.DateTimePicker m_daFinDate;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox2;
		internal PinkieControls.ButtonXP m_btnExit;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmReckoningReport_AllDay()
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
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.m_btnExit = new PinkieControls.ButtonXP();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// cryReportViewer
			// 
			this.cryReportViewer.ActiveViewIndex = -1;
			this.cryReportViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.cryReportViewer.DisplayGroupTree = false;
			this.cryReportViewer.DockPadding.Bottom = 5;
			this.cryReportViewer.Location = new System.Drawing.Point(8, 30);
			this.cryReportViewer.Name = "cryReportViewer";
			this.cryReportViewer.ReportSource = null;
			this.cryReportViewer.Size = new System.Drawing.Size(816, 410);
			this.cryReportViewer.TabIndex = 59;
			// 
			// m_btnQulReg
			// 
			this.m_btnQulReg.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnQulReg.DefaultScheme = true;
			this.m_btnQulReg.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnQulReg.Hint = "";
			this.m_btnQulReg.Location = new System.Drawing.Point(264, 24);
			this.m_btnQulReg.Name = "m_btnQulReg";
			this.m_btnQulReg.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnQulReg.Size = new System.Drawing.Size(64, 24);
			this.m_btnQulReg.TabIndex = 2;
			this.m_btnQulReg.Text = "确定";
			this.m_btnQulReg.Click += new System.EventHandler(this.m_btnQulReg_Click);
			// 
			// m_daFinDate
			// 
			this.m_daFinDate.Location = new System.Drawing.Point(120, 25);
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
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.m_btnQulReg);
			this.groupBox1.Controls.Add(this.m_daFinDate);
			this.groupBox1.Location = new System.Drawing.Point(8, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(832, 56);
			this.groupBox1.TabIndex = 61;
			this.groupBox1.TabStop = false;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(40, 27);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(70, 19);
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
			this.groupBox2.Location = new System.Drawing.Point(8, 64);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(832, 448);
			this.groupBox2.TabIndex = 62;
			this.groupBox2.TabStop = false;
			// 
			// m_btnExit
			// 
			this.m_btnExit.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnExit.DefaultScheme = true;
			this.m_btnExit.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnExit.Hint = "";
			this.m_btnExit.Location = new System.Drawing.Point(344, 24);
			this.m_btnExit.Name = "m_btnExit";
			this.m_btnExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnExit.Size = new System.Drawing.Size(88, 24);
			this.m_btnExit.TabIndex = 66;
			this.m_btnExit.Text = "退出(Esc)";
			this.m_btnExit.Click += new System.EventHandler(this.m_btnExit_Click);
			// 
			// frmReckoningReport_AllDay
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(848, 517);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.KeyPreview = true;
			this.Name = "frmReckoningReport_AllDay";
			this.Text = "收费处日结凭证";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmReckoningReport_AllDay_KeyDown);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override void CreateController()
		{
			this.objController=new com.digitalwave.iCare.gui.HIS.clsControlReckoningReport_AllDay();
			objController.Set_GUI_Apperance(this);
		}

		private void m_btnQulReg_Click(object sender, System.EventArgs e)
		{
			((clsControlReckoningReport_AllDay)this.objController).m_mthFindByDateReport();
			m_daFinDate.Focus();
		}

		
		private void m_cboReport_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		}
		
		#region  快捷键
		int keyTime =0;
		private void m_daFinDate_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter && keyTime != 3)
			{
				keyTime++;
				SendKeys.SendWait("{Right}");
			}
			if(e.KeyCode == Keys.Enter && keyTime == 3)
			{
				keyTime=0;
				SendKeys.SendWait("{Tab}");
			}
			if(e.KeyCode == Keys.F5)
			{
				((clsControlReckoningReport_AllDay)this.objController).m_mthFindByDateReport();
				m_daFinDate.Focus();
			}
		}
		#endregion

		private void m_btnExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void frmReckoningReport_AllDay_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Escape)
			{
				if(MessageBox.Show("确认退出吗?","iCare",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
					return;
				this.Close();
			}
		}


	}
}
