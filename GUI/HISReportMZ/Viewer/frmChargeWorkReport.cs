using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Printing;
using com.digitalwave.iCare.common;
using System.Data;
namespace com.digitalwave.iCare.gui.HIS.Reports
{
	/// <summary>
	/// frmChargeWorkReport 的摘要说明。
	/// </summary>
	public class frmChargeWorkReport :com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		internal System.Windows.Forms.DateTimePicker dateTimePicker2;
		private System.Windows.Forms.Label label4;
		internal System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel panel1;
		internal PinkieControls.ButtonXP btFind;
		internal PinkieControls.ButtonXP btPrint;
		internal PinkieControls.ButtonXP btExit;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		internal com.digitalwave.controls.Control.MyPrintPreViewControl myPrintPreViewControl1;
		private System.Windows.Forms.Splitter splitter1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        internal PinkieControls.ButtonXP btExcel;
        private PrintDialog printDialog1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmChargeWorkReport()
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
		public override void CreateController()
		{
            this.objController = new com.digitalwave.iCare.gui.HIS.Reports.clsControlChargeWorkReport();
			objController.Set_GUI_Apperance(this);
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChargeWorkReport));
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btExit = new PinkieControls.ButtonXP();
            this.btExcel = new PinkieControls.ButtonXP();
            this.btFind = new PinkieControls.ButtonXP();
            this.btPrint = new PinkieControls.ButtonXP();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.myPrintPreViewControl1 = new com.digitalwave.controls.Control.MyPrintPreViewControl();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(309, 12);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(132, 23);
            this.dateTimePicker2.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(276, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 14);
            this.label4.TabIndex = 10;
            this.label4.Text = "至";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(132, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(132, 23);
            this.dateTimePicker1.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "统计时间 从:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btExit);
            this.panel1.Controls.Add(this.btExcel);
            this.panel1.Controls.Add(this.btFind);
            this.panel1.Controls.Add(this.btPrint);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(976, 48);
            this.panel1.TabIndex = 12;
            // 
            // btExit
            // 
            this.btExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btExit.DefaultScheme = true;
            this.btExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btExit.Hint = "";
            this.btExit.Location = new System.Drawing.Point(876, 7);
            this.btExit.Name = "btExit";
            this.btExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btExit.Size = new System.Drawing.Size(96, 32);
            this.btExit.TabIndex = 49;
            this.btExit.Text = "退出(ESC)";
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // btExcel
            // 
            this.btExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btExcel.DefaultScheme = true;
            this.btExcel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btExcel.Hint = "";
            this.btExcel.Location = new System.Drawing.Point(626, 7);
            this.btExcel.Name = "btExcel";
            this.btExcel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btExcel.Size = new System.Drawing.Size(96, 32);
            this.btExcel.TabIndex = 48;
            this.btExcel.Text = "导出(&O)";
            this.btExcel.Click += new System.EventHandler(this.btExcel_Click);
            // 
            // btFind
            // 
            this.btFind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btFind.DefaultScheme = true;
            this.btFind.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btFind.Hint = "";
            this.btFind.Location = new System.Drawing.Point(501, 7);
            this.btFind.Name = "btFind";
            this.btFind.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btFind.Size = new System.Drawing.Size(96, 32);
            this.btFind.TabIndex = 48;
            this.btFind.Text = "查询(&F)";
            this.btFind.Click += new System.EventHandler(this.btFind_Click);
            // 
            // btPrint
            // 
            this.btPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btPrint.DefaultScheme = true;
            this.btPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btPrint.Hint = "";
            this.btPrint.Location = new System.Drawing.Point(751, 7);
            this.btPrint.Name = "btPrint";
            this.btPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btPrint.Size = new System.Drawing.Size(96, 32);
            this.btPrint.TabIndex = 47;
            this.btPrint.Text = "打印(&P)";
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.splitter1);
            this.panel2.Location = new System.Drawing.Point(0, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(976, 434);
            this.panel2.TabIndex = 13;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.myPrintPreViewControl1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(973, 434);
            this.panel3.TabIndex = 11;
            // 
            // myPrintPreViewControl1
            // 
            this.myPrintPreViewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myPrintPreViewControl1.Document = this.printDocument1;
            this.myPrintPreViewControl1.Location = new System.Drawing.Point(0, 0);
            this.myPrintPreViewControl1.Name = "myPrintPreViewControl1";
            this.myPrintPreViewControl1.ReportName = "收费员工作量报表";
            this.myPrintPreViewControl1.ShowPannel = true;
            this.myPrintPreViewControl1.ShowPrintButton = true;
            this.myPrintPreViewControl1.Size = new System.Drawing.Size(973, 434);
            this.myPrintPreViewControl1.TabIndex = 0;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 434);
            this.splitter1.TabIndex = 10;
            this.splitter1.TabStop = false;
            // 
            // printDialog1
            // 
            this.printDialog1.AllowCurrentPage = true;
            this.printDialog1.AllowSelection = true;
            this.printDialog1.AllowSomePages = true;
            this.printDialog1.Document = this.printDocument1;
            this.printDialog1.UseEXDialog = true;
            // 
            // frmChargeWorkReport
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(976, 485);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmChargeWorkReport";
            this.Text = "收费员工作量统计报表";
            this.Load += new System.EventHandler(this.frmChargeWorkReport_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void frmChargeWorkReport_Load(object sender, System.EventArgs e)
		{
            this.myPrintPreViewControl1.txtCount.Text = "0.095";
		}
		public string strType="0";
		public void m_mthShow(string Type)
		{
			strType=Type;
			if(Type=="0")
				this.Text="收费员工作量统计报表";
			else
				this.Text="收费员月结报表";
			this.Show();
		}

		private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			//this.printDocument1.DefaultPageSettings.Landscape=true;
			foreach(PaperSize ps in this.printDocument1.PrinterSettings.PaperSizes)
			{
				if(ps.PaperName=="A4")
				{
					this.printDocument1.DefaultPageSettings.PaperSize=ps;
					break;
				}
			}
			((clsControlChargeWorkReport)this.objController).m_mthBeginPrint();
		}

		private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			((clsControlChargeWorkReport)this.objController).m_mthPrint(e);
		}

		private void btFind_Click(object sender, System.EventArgs e)
		{
			this.myPrintPreViewControl1.Document=this.printDocument1;
		}

		private void btPrint_Click(object sender, System.EventArgs e)
		{
            //frmSelectPrinter selectPrinter=new frmSelectPrinter();
            //if(selectPrinter.ShowDialog()==DialogResult.OK)
            //{
            //    printDocument1.PrinterSettings.PrinterName=selectPrinter.PrinterName;
            //}
            //else
            //{
            //    return;
            //}
            if (this.printDialog1.ShowDialog() == DialogResult.OK)
            {
                this.printDocument1.PrinterSettings.PrinterName = this.printDialog1.PrinterSettings.PrinterName;
            }
            else
            {
                return;
            }
			try
			{
				this.printDocument1.Print();
			}
			catch
			{
				MessageBox.Show("没有打印机!");
			}
		}

		private void btExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

        private void btExcel_Click(object sender, EventArgs e)
        {
            DataTable dtTempMydt = ((clsControlChargeWorkReport)this.objController).dt;
            DataTable dtTemp2 = new DataTable();
            for (int i = 0; i < dtTempMydt.Columns.Count; i++)
            {
                if (dtTempMydt.Columns[i].ColumnName.IndexOf("姓名") >= 0)
                {
                    dtTemp2.Columns.Add(dtTempMydt.Columns[i].ColumnName, System.Type.GetType("System.String"));
                }
                else
                {
                    dtTemp2.Columns.Add(dtTempMydt.Columns[i].ColumnName, System.Type.GetType("System.Double"));
                }
            }
            DataRow drnew = null;
            for (int i = 1; i < dtTempMydt.Rows.Count; i++)
            {
                drnew = dtTemp2.NewRow();
                for (int i2 = 0; i2 < dtTempMydt.Columns.Count; i2++)
                {
                    if (dtTempMydt.Rows[i][i2].ToString() != "")
                    {
                        drnew[i2] = dtTempMydt.Rows[i][i2];
                    }
                    else
                    {
                        drnew[i2] = 0;
                    }
                }
                dtTemp2.Rows.Add(drnew);
            }

            ((clsControlChargeWorkReport)this.objController).m_mthOutExcel2(dtTemp2);
        }

	}
}
