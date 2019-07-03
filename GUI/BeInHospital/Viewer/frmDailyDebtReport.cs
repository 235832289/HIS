using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmDailyDebtReport 的摘要说明。
	/// </summary>
	public class frmDailyDebtReport : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private System.Windows.Forms.Label label1;
		private PinkieControls.ButtonXP m_cmdStat;
		internal System.Windows.Forms.TextBox m_txtAREAID_CHR;
		internal System.Windows.Forms.ListView lsvAreaInfo;
		private System.Windows.Forms.ColumnHeader ColumnName;
		private System.Windows.Forms.ColumnHeader ColumnNum;
		internal System.Drawing.Printing.PrintDocument PatientDailyDebt;
		internal System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
		internal System.Windows.Forms.DateTimePicker m_dtpStatTime;
		internal System.Drawing.Printing.PrintDocument rptChargeView;
		private System.Windows.Forms.PageSetupDialog pageSetupDialog;
		internal System.Windows.Forms.PrintDialog printDialog;
		private PinkieControls.ButtonXP m_cmdChargeView;
		private System.Windows.Forms.Label label2;
		internal System.Windows.Forms.ComboBox m_cboBedNo;
		internal PinkieControls.ButtonXP m_cmdPrint;
		private PinkieControls.ButtonXP m_txtExit;
		internal System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
		private System.Windows.Forms.PrintPreviewDialog printPreviewDialog2;
		private System.Windows.Forms.Label label3;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmDailyDebtReport()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			#region 临时控件
			//			//Dept
			//			lsvDeptInfo = new ListView();
			//			this.lsvDeptInfo.DoubleClick += new System.EventHandler(this.lsvDeptInfo_DoubleClick);
			//			this.lsvDeptInfo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsvDeptInfo_KeyDown);
			//			this.lsvDeptInfo.Leave += new System.EventHandler(this.lsvDeptInfo_Leave);
			//Area
			lsvAreaInfo = new ListView();
			this.lsvAreaInfo.DoubleClick += new System.EventHandler(this.lsvAreaInfo_DoubleClick);
			this.lsvAreaInfo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsvAreaInfo_KeyDown);
			this.lsvAreaInfo.Leave += new System.EventHandler(this.lsvAreaInfo_Leave);
			#endregion
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmDailyDebtReport));
			this.label1 = new System.Windows.Forms.Label();
			this.m_txtAREAID_CHR = new System.Windows.Forms.TextBox();
			this.m_cmdStat = new PinkieControls.ButtonXP();
			this.PatientDailyDebt = new System.Drawing.Printing.PrintDocument();
			this.pageSetupDialog = new System.Windows.Forms.PageSetupDialog();
			this.rptChargeView = new System.Drawing.Printing.PrintDocument();
			this.printDialog = new System.Windows.Forms.PrintDialog();
			this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
			this.m_dtpStatTime = new System.Windows.Forms.DateTimePicker();
			this.m_cmdChargeView = new PinkieControls.ButtonXP();
			this.label2 = new System.Windows.Forms.Label();
			this.m_cboBedNo = new System.Windows.Forms.ComboBox();
			this.m_cmdPrint = new PinkieControls.ButtonXP();
			this.m_txtExit = new PinkieControls.ButtonXP();
			this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
			this.printPreviewDialog2 = new System.Windows.Forms.PrintPreviewDialog();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(96, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(71, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "住院病区:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_txtAREAID_CHR
			// 
			this.m_txtAREAID_CHR.Location = new System.Drawing.Point(168, 16);
			this.m_txtAREAID_CHR.MaxLength = 20;
			this.m_txtAREAID_CHR.Name = "m_txtAREAID_CHR";
			this.m_txtAREAID_CHR.Size = new System.Drawing.Size(176, 23);
			this.m_txtAREAID_CHR.TabIndex = 2;
			this.m_txtAREAID_CHR.Text = "";
			this.m_txtAREAID_CHR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtAREAID_CHR_KeyDown);
			// 
			// m_cmdStat
			// 
			this.m_cmdStat.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdStat.DefaultScheme = true;
			this.m_cmdStat.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdStat.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cmdStat.Hint = "";
			this.m_cmdStat.Location = new System.Drawing.Point(604, 12);
			this.m_cmdStat.Name = "m_cmdStat";
			this.m_cmdStat.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdStat.Size = new System.Drawing.Size(148, 32);
			this.m_cmdStat.TabIndex = 3;
			this.m_cmdStat.Text = "住院费用一日清单(&F)";
			this.m_cmdStat.Click += new System.EventHandler(this.m_cmdStat_Click);
			// 
			// PatientDailyDebt
			// 
			this.PatientDailyDebt.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.PatientDailyDebt_BeginPrint);
			this.PatientDailyDebt.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PatientDailyDebt_PrintPage);
			// 
			// pageSetupDialog
			// 
			this.pageSetupDialog.Document = this.rptChargeView;
			// 
			// rptChargeView
			// 
			this.rptChargeView.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.rptChargeView_PrintPage);
			// 
			// printPreviewDialog
			// 
			this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
			this.printPreviewDialog.Document = this.PatientDailyDebt;
			this.printPreviewDialog.Enabled = true;
			this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
			this.printPreviewDialog.Location = new System.Drawing.Point(168, 54);
			this.printPreviewDialog.MinimumSize = new System.Drawing.Size(375, 250);
			this.printPreviewDialog.Name = "printPreviewDialog";
			this.printPreviewDialog.TransparencyKey = System.Drawing.Color.Empty;
			this.printPreviewDialog.Visible = false;
			this.printPreviewDialog.Load += new System.EventHandler(this.printPreviewDialog_Load);
			// 
			// m_dtpStatTime
			// 
			this.m_dtpStatTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
			this.m_dtpStatTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.m_dtpStatTime.Location = new System.Drawing.Point(420, 16);
			this.m_dtpStatTime.Name = "m_dtpStatTime";
			this.m_dtpStatTime.Size = new System.Drawing.Size(160, 23);
			this.m_dtpStatTime.TabIndex = 10;
			// 
			// m_cmdChargeView
			// 
			this.m_cmdChargeView.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdChargeView.DefaultScheme = true;
			this.m_cmdChargeView.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdChargeView.Hint = "";
			this.m_cmdChargeView.Location = new System.Drawing.Point(604, 48);
			this.m_cmdChargeView.Name = "m_cmdChargeView";
			this.m_cmdChargeView.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdChargeView.Size = new System.Drawing.Size(144, 32);
			this.m_cmdChargeView.TabIndex = 11;
			this.m_cmdChargeView.Text = "住院费用一览表(&D)";
			this.m_cmdChargeView.Click += new System.EventHandler(this.m_cmdChargeView_Click);
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.Location = new System.Drawing.Point(96, 49);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(71, 23);
			this.label2.TabIndex = 12;
			this.label2.Text = "病床:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_cboBedNo
			// 
			this.m_cboBedNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboBedNo.Location = new System.Drawing.Point(168, 50);
			this.m_cboBedNo.Name = "m_cboBedNo";
			this.m_cboBedNo.Size = new System.Drawing.Size(176, 22);
			this.m_cboBedNo.TabIndex = 13;
			// 
			// m_cmdPrint
			// 
			this.m_cmdPrint.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdPrint.DefaultScheme = true;
			this.m_cmdPrint.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdPrint.Enabled = false;
			this.m_cmdPrint.Hint = "";
			this.m_cmdPrint.Location = new System.Drawing.Point(532, 52);
			this.m_cmdPrint.Name = "m_cmdPrint";
			this.m_cmdPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdPrint.Size = new System.Drawing.Size(56, 20);
			this.m_cmdPrint.TabIndex = 15;
			this.m_cmdPrint.Text = "打印";
			this.m_cmdPrint.Visible = false;
			this.m_cmdPrint.Click += new System.EventHandler(this.m_cmdPrint_Click);
			// 
			// m_txtExit
			// 
			this.m_txtExit.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_txtExit.DefaultScheme = true;
			this.m_txtExit.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_txtExit.Hint = "";
			this.m_txtExit.Location = new System.Drawing.Point(468, 52);
			this.m_txtExit.Name = "m_txtExit";
			this.m_txtExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_txtExit.Size = new System.Drawing.Size(60, 20);
			this.m_txtExit.TabIndex = 16;
			this.m_txtExit.Text = "退出";
			this.m_txtExit.Visible = false;
			this.m_txtExit.Click += new System.EventHandler(this.m_txtExit_Click);
			// 
			// printPreviewDialog1
			// 
			this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
			this.printPreviewDialog1.Document = this.PatientDailyDebt;
			this.printPreviewDialog1.Enabled = true;
			this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
			this.printPreviewDialog1.Location = new System.Drawing.Point(515, 17);
			this.printPreviewDialog1.MinimumSize = new System.Drawing.Size(375, 250);
			this.printPreviewDialog1.Name = "printPreviewDialog1";
			this.printPreviewDialog1.TransparencyKey = System.Drawing.Color.Empty;
			this.printPreviewDialog1.Visible = false;
			// 
			// printPreviewDialog2
			// 
			this.printPreviewDialog2.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.printPreviewDialog2.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			this.printPreviewDialog2.ClientSize = new System.Drawing.Size(400, 300);
			this.printPreviewDialog2.Enabled = true;
			this.printPreviewDialog2.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog2.Icon")));
			this.printPreviewDialog2.Location = new System.Drawing.Point(541, 54);
			this.printPreviewDialog2.MinimumSize = new System.Drawing.Size(375, 250);
			this.printPreviewDialog2.Name = "printPreviewDialog2";
			this.printPreviewDialog2.TransparencyKey = System.Drawing.Color.Empty;
			this.printPreviewDialog2.Visible = false;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(348, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(71, 23);
			this.label3.TabIndex = 17;
			this.label3.Text = "查询日期:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// frmDailyDebtReport
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(888, 537);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.m_txtExit);
			this.Controls.Add(this.m_cmdPrint);
			this.Controls.Add(this.m_cmdChargeView);
			this.Controls.Add(this.m_cmdStat);
			this.Controls.Add(this.m_txtAREAID_CHR);
			this.Controls.Add(this.m_cboBedNo);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.m_dtpStatTime);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.Name = "frmDailyDebtReport";
			this.Text = "住院费用一日清单";
			this.Load += new System.EventHandler(this.frmDailyDebtReport_Load);
			this.ResumeLayout(false);

		}
		#endregion
		public override void CreateController()
		{
			this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_DailyDebtReport();
			objController.Set_GUI_Apperance(this);
		}
		#region 病区查找
		private void lsvAreaInfo_DoubleClick(object sender, System.EventArgs e)
		{
			if(this.lsvAreaInfo.SelectedItems.Count>0)
			{
				this.m_txtAREAID_CHR.Text = this.lsvAreaInfo.SelectedItems[0].SubItems[1].Text;
				this.m_txtAREAID_CHR.Tag = ((com.digitalwave.iCare.ValueObject.clsT_BSE_DEPTDESC_VO)this.lsvAreaInfo.SelectedItems[0].Tag).m_strDEPTID_CHR;
				this.lsvAreaInfo.Visible = false;
				((clsCtl_DailyDebtReport)this.objController).Addm_cboBed();
			}
		}
		private void lsvAreaInfo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				lsvAreaInfo_DoubleClick(null,null);
			}
		}
		private void lsvAreaInfo_Leave(object sender, System.EventArgs e)
		{
			this.lsvAreaInfo.Visible = false;
		}
		#endregion

		private void m_txtAREAID_CHR_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				#region 控件处理

				#region 病区编号	glzhang	2005.07.29
				this.ColumnNum = new System.Windows.Forms.ColumnHeader();
				this.ColumnNum.Text = "病区编号";
				this.ColumnNum.Width = 80;
				#endregion
				
				this.ColumnName = new System.Windows.Forms.ColumnHeader();
				this.ColumnName.Text = "";
				this.ColumnName.Width = 120;
				this.lsvAreaInfo.Size = new System.Drawing.Size(200, 144);
				
				this.lsvAreaInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							  ColumnNum,this.ColumnName});
				this.lsvAreaInfo.View = System.Windows.Forms.View.Details;
				this.lsvAreaInfo.FullRowSelect = true;
				this.lsvAreaInfo.GridLines = true;
				((clsCtl_DailyDebtReport)this.objController).LoadAreaID();
				if(lsvAreaInfo.Items.Count<1)
					return;
				if(lsvAreaInfo.Items.Count==1)
				{
					this.m_txtAREAID_CHR.Text = this.lsvAreaInfo.Items[0].Text;
					this.m_txtAREAID_CHR.Tag = ((com.digitalwave.iCare.ValueObject.clsT_BSE_DEPTDESC_VO)this.lsvAreaInfo.Items[0].Tag).m_strDEPTID_CHR;
					return;
				}
				this.Controls.Add(this.lsvAreaInfo);
				this.lsvAreaInfo.Location =new  System.Drawing.Point(168,35);
				#endregion
				this.lsvAreaInfo.Items[0].Selected = true;
				this.lsvAreaInfo.Show();
				this.lsvAreaInfo.BringToFront();
				this.lsvAreaInfo.Focus();
			}
		}

		private void m_cmdStat_Click(object sender, System.EventArgs e)
		{
			if(!this.m_cmdStat.ContainsFocus)
				return;
			if(this.m_txtAREAID_CHR.Tag==null||this.m_txtAREAID_CHR.Text.Trim()=="")
				return;
			((clsCtl_DailyDebtReport)this.objController).PatientDailyDebtpreview();
		}

		private void frmDailyDebtReport_Load(object sender, System.EventArgs e)
		{
		}
		private void printPreviewDialog_Load(object sender, System.EventArgs e)
		{
		
		}

		private void m_cmdChargeView_Click(object sender, System.EventArgs e)
		{
			if(this.m_txtAREAID_CHR.Tag==null||this.m_txtAREAID_CHR.Text.Trim()=="")
				return;
			((clsCtl_DailyDebtReport)this.objController).rptChargeViewPreview();
		}

		private void m_cmdPrint_Click(object sender, System.EventArgs e)
		{
			((clsCtl_DailyDebtReport)this.objController).Print();
		}

		private void m_txtExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void PatientDailyDebt_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			((clsCtl_DailyDebtReport)this.objController).PrintPage(e);
		}

		private void PatientDailyDebt_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			((clsCtl_DailyDebtReport)this.objController).RowNum =0;
		}

		private void rptChargeView_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			((clsCtl_DailyDebtReport)this.objController).PrintvChargeView(sender,e);
		}
	}
}
