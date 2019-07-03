using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmGovReport 的摘要说明。
	/// </summary>
	public class frmGovReport :com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private System.Windows.Forms.Panel panel1;
		internal System.Windows.Forms.DateTimePicker startDate;
		internal System.Windows.Forms.DateTimePicker endDate;
		internal PinkieControls.ButtonXP btnMath;
		internal PinkieControls.ButtonXP btnPrint;
		internal PinkieControls.ButtonXP btnEsc;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.PrintPreviewControl printPreviewControl1;
		private System.Drawing.Printing.PrintDocument printDocument1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmGovReport()
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

		/// <summary>
		/// 设置窗体对象
		/// </summary>
		public override void CreateController()
		{
			this.objController =new clsControlGovReport();
			this.objController.Set_GUI_Apperance(this);
		}


		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.panel1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.btnEsc = new PinkieControls.ButtonXP();
			this.btnPrint = new PinkieControls.ButtonXP();
			this.btnMath = new PinkieControls.ButtonXP();
			this.endDate = new System.Windows.Forms.DateTimePicker();
			this.startDate = new System.Windows.Forms.DateTimePicker();
			this.panel2 = new System.Windows.Forms.Panel();
			this.printPreviewControl1 = new System.Windows.Forms.PrintPreviewControl();
			this.printDocument1 = new System.Drawing.Printing.PrintDocument();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.btnEsc);
			this.panel1.Controls.Add(this.btnPrint);
			this.panel1.Controls.Add(this.btnMath);
			this.panel1.Controls.Add(this.endDate);
			this.panel1.Controls.Add(this.startDate);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(936, 48);
			this.panel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
			this.label1.Location = new System.Drawing.Point(168, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 23);
			this.label1.TabIndex = 6;
			this.label1.Text = "至";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnEsc
			// 
			this.btnEsc.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btnEsc.DefaultScheme = true;
			this.btnEsc.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnEsc.Hint = "";
			this.btnEsc.Location = new System.Drawing.Point(696, 8);
			this.btnEsc.Name = "btnEsc";
			this.btnEsc.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btnEsc.Size = new System.Drawing.Size(112, 32);
			this.btnEsc.TabIndex = 5;
			this.btnEsc.Text = "退出(ESC)";
			this.btnEsc.Click += new System.EventHandler(this.btnEsc_Click);
			// 
			// btnPrint
			// 
			this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btnPrint.DefaultScheme = true;
			this.btnPrint.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btnPrint.Hint = "";
			this.btnPrint.Location = new System.Drawing.Point(536, 8);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btnPrint.Size = new System.Drawing.Size(112, 32);
			this.btnPrint.TabIndex = 4;
			this.btnPrint.Text = "打印(&P)";
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			// 
			// btnMath
			// 
			this.btnMath.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btnMath.DefaultScheme = true;
			this.btnMath.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btnMath.Hint = "";
			this.btnMath.Location = new System.Drawing.Point(376, 8);
			this.btnMath.Name = "btnMath";
			this.btnMath.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btnMath.Size = new System.Drawing.Size(112, 32);
			this.btnMath.TabIndex = 3;
			this.btnMath.Text = "统计(&S)";
			this.btnMath.Click += new System.EventHandler(this.btnMath_Click);
			// 
			// endDate
			// 
			this.endDate.Location = new System.Drawing.Point(232, 13);
			this.endDate.Name = "endDate";
			this.endDate.Size = new System.Drawing.Size(120, 23);
			this.endDate.TabIndex = 1;
			// 
			// startDate
			// 
			this.startDate.Location = new System.Drawing.Point(48, 13);
			this.startDate.Name = "startDate";
			this.startDate.Size = new System.Drawing.Size(120, 23);
			this.startDate.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.printPreviewControl1);
			this.panel2.Location = new System.Drawing.Point(0, 56);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(936, 408);
			this.panel2.TabIndex = 1;
			// 
			// printPreviewControl1
			// 
			this.printPreviewControl1.AutoZoom = false;
			this.printPreviewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.printPreviewControl1.Document = this.printDocument1;
			this.printPreviewControl1.Location = new System.Drawing.Point(0, 0);
			this.printPreviewControl1.Name = "printPreviewControl1";
			this.printPreviewControl1.Size = new System.Drawing.Size(934, 406);
			this.printPreviewControl1.TabIndex = 0;
			this.printPreviewControl1.Zoom = 1;
			// 
			// printDocument1
			// 
			this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
			// 
			// frmGovReport
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.CancelButton = this.btnEsc;
			this.ClientSize = new System.Drawing.Size(936, 469);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.Name = "frmGovReport";
			this.Text = "公费统计";
			this.Load += new System.EventHandler(this.frmGovReport_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmGovReport_Load(object sender, System.EventArgs e)
		{
			startDate.Value=Convert.ToDateTime(startDate.Value.Year.ToString()+"-"+startDate.Value.Month.ToString()+"-"+"01");
			string starDate=startDate.Value.ToShortDateString();
			string EndDate=endDate.Value.ToShortDateString();
			((clsControlGovReport)this.objController).m_getGovData(starDate,EndDate);
		
		}

		private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			((clsControlGovReport)this.objController).m_printRePort(e);
		}

		private void btnEsc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			printDocument1.Print();
		}

		private void btnMath_Click(object sender, System.EventArgs e)
		{
			startDate.Value=Convert.ToDateTime(startDate.Value.Year.ToString()+"-"+startDate.Value.Month.ToString()+"-"+"01");
			string starDate=startDate.Value.ToShortDateString();
			string EndDate=endDate.Value.ToShortDateString();
			((clsControlGovReport)this.objController).m_getGovData(starDate,EndDate);

			printPreviewControl1.Document=printDocument1;
		
		}
	}
}
