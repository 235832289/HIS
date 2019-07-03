using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 门诊挂号医生收入报表
	/// 张国良	 2004-9-9
	/// </summary>
	public class frmRegisterReport: com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		internal System.Windows.Forms.DateTimePicker m_datLastdate;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label13;
		internal PinkieControls.ButtonXP m_btnQulReg;
		internal CrystalDecisions.Windows.Forms.CrystalReportViewer cryReportViewer;
		
		
		private System.Windows.Forms.Label label1;
		internal System.Windows.Forms.ComboBox m_cboReport;
		internal PinkieControls.ButtonXP buttonXP1;
        internal System.Windows.Forms.DateTimePicker m_datFirstdate;
        private SplitContainer splitContainer1;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        internal ComboBox m_cboRptPic;
        internal Label m_lblRptPic;
        internal PinkieControls.ButtonXP m_cmdOrder;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmRegisterReport()
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
            this.m_datLastdate = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.m_btnQulReg = new PinkieControls.ButtonXP();
            this.cryReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.m_cboReport = new System.Windows.Forms.ComboBox();
            this.buttonXP1 = new PinkieControls.ButtonXP();
            this.m_datFirstdate = new System.Windows.Forms.DateTimePicker();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.m_cboRptPic = new System.Windows.Forms.ComboBox();
            this.m_lblRptPic = new System.Windows.Forms.Label();
            this.m_cmdOrder = new PinkieControls.ButtonXP();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_datLastdate
            // 
            this.m_datLastdate.Location = new System.Drawing.Point(567, 8);
            this.m_datLastdate.Name = "m_datLastdate";
            this.m_datLastdate.Size = new System.Drawing.Size(128, 23);
            this.m_datLastdate.TabIndex = 3;
            this.m_datLastdate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_datLastdate_KeyDown);
            // 
            // label11
            // 
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(341, 8);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 24);
            this.label11.TabIndex = 55;
            this.label11.Text = "统计日期:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(551, 8);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(16, 23);
            this.label13.TabIndex = 56;
            this.label13.Text = "至";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_btnQulReg
            // 
            this.m_btnQulReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnQulReg.DefaultScheme = true;
            this.m_btnQulReg.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnQulReg.Hint = "";
            this.m_btnQulReg.Location = new System.Drawing.Point(832, 7);
            this.m_btnQulReg.Name = "m_btnQulReg";
            this.m_btnQulReg.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnQulReg.Size = new System.Drawing.Size(83, 24);
            this.m_btnQulReg.TabIndex = 4;
            this.m_btnQulReg.Text = "确定(F5)";
            this.m_btnQulReg.Click += new System.EventHandler(this.m_btnQulReg_Click);
            // 
            // cryReportViewer
            // 
            this.cryReportViewer.ActiveViewIndex = -1;
            this.cryReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cryReportViewer.DisplayGroupTree = false;
            this.cryReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cryReportViewer.Location = new System.Drawing.Point(0, 0);
            this.cryReportViewer.Name = "cryReportViewer";
            this.cryReportViewer.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.cryReportViewer.SelectionFormula = "";
            this.cryReportViewer.Size = new System.Drawing.Size(992, 442);
            this.cryReportViewer.TabIndex = 57;
            this.cryReportViewer.ViewTimeSelectionFormula = "";
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(16, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 24);
            this.label1.TabIndex = 59;
            this.label1.Text = "选择报表";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_cboReport
            // 
            this.m_cboReport.Items.AddRange(new object[] {
            "挂号员日报表",
            "医生门诊挂号收入报表",
            "门诊科室挂号收入报表",
            "门诊挂号人数按时段汇总图",
            "门诊挂号人数按星期汇总图",
            "各科门诊人次日报表"});
            this.m_cboReport.Location = new System.Drawing.Point(88, 8);
            this.m_cboReport.Name = "m_cboReport";
            this.m_cboReport.Size = new System.Drawing.Size(232, 22);
            this.m_cboReport.TabIndex = 5;
            this.m_cboReport.Text = "挂号员日报表";
            this.m_cboReport.SelectedValueChanged += new System.EventHandler(this.m_cboReport_SelectedValueChanged);
            this.m_cboReport.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_cboReport_KeyDown);
            // 
            // buttonXP1
            // 
            this.buttonXP1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP1.DefaultScheme = true;
            this.buttonXP1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP1.Hint = "";
            this.buttonXP1.Location = new System.Drawing.Point(932, 7);
            this.buttonXP1.Name = "buttonXP1";
            this.buttonXP1.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP1.Size = new System.Drawing.Size(80, 24);
            this.buttonXP1.TabIndex = 4;
            this.buttonXP1.Text = "退出(Esc)";
            this.buttonXP1.Click += new System.EventHandler(this.buttonXP1_Click);
            // 
            // m_datFirstdate
            // 
            this.m_datFirstdate.Location = new System.Drawing.Point(413, 8);
            this.m_datFirstdate.Name = "m_datFirstdate";
            this.m_datFirstdate.Size = new System.Drawing.Size(128, 23);
            this.m_datFirstdate.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 38);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.comboBox2);
            this.splitContainer1.Panel1.Controls.Add(this.comboBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.cryReportViewer);
            this.splitContainer1.Size = new System.Drawing.Size(992, 479);
            this.splitContainer1.SplitterDistance = 33;
            this.splitContainer1.TabIndex = 60;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(583, 3);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 22);
            this.comboBox2.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(424, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 22);
            this.comboBox1.TabIndex = 0;
            // 
            // m_cboRptPic
            // 
            this.m_cboRptPic.FormattingEnabled = true;
            this.m_cboRptPic.Items.AddRange(new object[] {
            "表",
            "图"});
            this.m_cboRptPic.Location = new System.Drawing.Point(756, 8);
            this.m_cboRptPic.Name = "m_cboRptPic";
            this.m_cboRptPic.Size = new System.Drawing.Size(64, 22);
            this.m_cboRptPic.TabIndex = 61;
            this.m_cboRptPic.Visible = false;
            // 
            // m_lblRptPic
            // 
            this.m_lblRptPic.AutoSize = true;
            this.m_lblRptPic.Location = new System.Drawing.Point(700, 12);
            this.m_lblRptPic.Name = "m_lblRptPic";
            this.m_lblRptPic.Size = new System.Drawing.Size(56, 14);
            this.m_lblRptPic.TabIndex = 62;
            this.m_lblRptPic.Text = "(表/图)";
            this.m_lblRptPic.Visible = false;
            // 
            // m_cmdOrder
            // 
            this.m_cmdOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdOrder.DefaultScheme = true;
            this.m_cmdOrder.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdOrder.Hint = "";
            this.m_cmdOrder.Location = new System.Drawing.Point(737, 8);
            this.m_cmdOrder.Name = "m_cmdOrder";
            this.m_cmdOrder.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdOrder.Size = new System.Drawing.Size(83, 24);
            this.m_cmdOrder.TabIndex = 63;
            this.m_cmdOrder.Text = "排序(&P)";
            this.m_cmdOrder.Visible = false;
            this.m_cmdOrder.Click += new System.EventHandler(this.m_cmdOrder_Click);
            // 
            // frmRegisterReport
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(992, 517);
            this.Controls.Add(this.m_cmdOrder);
            this.Controls.Add(this.m_lblRptPic);
            this.Controls.Add(this.m_cboRptPic);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.m_cboReport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_datLastdate);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.m_btnQulReg);
            this.Controls.Add(this.buttonXP1);
            this.Controls.Add(this.m_datFirstdate);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.KeyPreview = true;
            this.Name = "frmRegisterReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "挂号报表";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRegisterReport_KeyDown);
            this.Load += new System.EventHandler(this.frmRegisterReport_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public override void CreateController()
		{
			this.objController=new com.digitalwave.iCare.gui.HIS.clsControRegisterReport();
			objController.Set_GUI_Apperance(this);
		}

		private void frmRegisterReport_Load(object sender, System.EventArgs e)
		{

            this.splitContainer1.Panel1Collapsed = true;
			((clsControRegisterReport)this.objController).m_mthInitData();
			m_cboReport.Focus();
            this.m_cboRptPic.SelectedIndex = 0;
		}

		private void m_btnQulReg_Click(object sender, System.EventArgs e)
		{
            this.Cursor = Cursors.WaitCursor;
			((clsControRegisterReport)this.objController).m_mthFindByDateReport();
            this.Cursor = Cursors.Default;
			m_cboReport.Focus();
		}

		private void m_cboReport_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				SendKeys.SendWait("{Tab}");
			}

			if(e.KeyCode == Keys.F5)
			{
				((clsControRegisterReport)this.objController).m_mthFindByDateReport();
				m_cboReport.Focus();
			}
			if(e.KeyCode == Keys.Escape)
			{
				if(MessageBox.Show("确认退出吗?","iCare",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
				return;
				this.Close();
				
			}
		}
		
		#region 快捷键
		int keyTime = 0;
		private void m_datFirstdate_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter && keyTime!=3)
			{
				keyTime++;
				SendKeys.SendWait("{Right}");
			}

			if(e.KeyCode == Keys.Enter && keyTime == 3)
			{
				keyTime = 0;
				SendKeys.SendWait("{Tab}");
				
			}

			if(e.KeyCode == Keys.F5)
			{
				((clsControRegisterReport)this.objController).m_mthFindByDateReport();
				m_cboReport.Focus();
			}
		}
		#endregion

		private void m_datLastdate_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter && keyTime!=3)
			{
				keyTime++;
				SendKeys.SendWait("{Right}");
				
			}

			if(e.KeyCode == Keys.Enter && keyTime == 3)
			{
				keyTime = 0;
				this.m_btnQulReg.Focus();
			}

			if(e.KeyCode == Keys.F5)
			{
				((clsControRegisterReport)this.objController).m_mthFindByDateReport();
				m_cboReport.Focus();
			}
		}

		private void buttonXP1_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void frmRegisterReport_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			
			if(e.KeyCode == Keys.Escape)
			{
				if(MessageBox.Show("确认退出吗?","iCare",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
					return;
				buttonXP1_Click(sender,e);

			}
		}

        private void m_cboReport_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.m_cboReport.SelectedIndex == 1 || this.m_cboReport.SelectedIndex == 2)
            {
                this.m_lblRptPic.Visible = true;
                this.m_cboRptPic.Visible = true;
            }
            else
            {
                this.m_lblRptPic.Visible = false;
                this.m_cboRptPic.Visible =false;
            
            }
            if (m_cboReport.SelectedIndex == 5)
            {
                m_cmdOrder.Visible = true;
            }
            else
            {
                m_cmdOrder.Visible = false;
                    
            }

        }

        private void m_cmdOrder_Click(object sender, EventArgs e)
        {
            frmSetOrderDept objfrm = new frmSetOrderDept();
            objfrm.Text = "设置顺序(注:设置顺序方法:使用鼠标进行对部门的拖放操作即可.)";
            objfrm.ShowDialog();
        }
	}
}
