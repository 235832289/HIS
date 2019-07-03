using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
namespace  com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmGroupWorkLoad 的摘要说明。
	/// </summary>
	public class frmGroupWorkLoadReport: com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		internal System.Windows.Forms.DateTimePicker m_daFinDateLast;
		private System.Windows.Forms.Label label2;
		internal PinkieControls.ButtonXP btOK;
		internal System.Windows.Forms.DateTimePicker m_daFinDate;
		internal PinkieControls.ButtonXP btPrint;
		internal PinkieControls.ButtonXP btExit;
		internal com.digitalwave.controls.Control.MyPrintPreViewControl myPrintPreViewControl1;
		private System.Drawing.Printing.PrintDocument printDocument1;
        internal PinkieControls.ButtonXP btExcel;
        private PrintDialog printDialog1;
        private Label label5;
        public ComboBox comboBox1;
        public ComboBox comboBox2;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmGroupWorkLoadReport()
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
			this.objController=new com.digitalwave.iCare.gui.HIS.clsCtl_GroupWorkLoadReport();
			objController.Set_GUI_Apperance(this);
		}
		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGroupWorkLoadReport));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btExit = new PinkieControls.ButtonXP();
            this.btPrint = new PinkieControls.ButtonXP();
            this.label1 = new System.Windows.Forms.Label();
            this.m_daFinDateLast = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btExcel = new PinkieControls.ButtonXP();
            this.btOK = new PinkieControls.ButtonXP();
            this.m_daFinDate = new System.Windows.Forms.DateTimePicker();
            this.myPrintPreViewControl1 = new com.digitalwave.controls.Control.MyPrintPreViewControl();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.btExit);
            this.groupBox1.Controls.Add(this.btPrint);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.m_daFinDateLast);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btExcel);
            this.groupBox1.Controls.Add(this.btOK);
            this.groupBox1.Controls.Add(this.m_daFinDate);
            this.groupBox1.Location = new System.Drawing.Point(4, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(964, 64);
            this.groupBox1.TabIndex = 62;
            this.groupBox1.TabStop = false;
            // 
            // btExit
            // 
            this.btExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btExit.DefaultScheme = true;
            this.btExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btExit.Hint = "";
            this.btExit.Location = new System.Drawing.Point(860, 20);
            this.btExit.Name = "btExit";
            this.btExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btExit.Size = new System.Drawing.Size(96, 32);
            this.btExit.TabIndex = 67;
            this.btExit.Text = "退出(ESC)";
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // btPrint
            // 
            this.btPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btPrint.DefaultScheme = true;
            this.btPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btPrint.Hint = "";
            this.btPrint.Location = new System.Drawing.Point(753, 20);
            this.btPrint.Name = "btPrint";
            this.btPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btPrint.Size = new System.Drawing.Size(96, 32);
            this.btPrint.TabIndex = 66;
            this.btPrint.Text = "打印(&P)";
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(256, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 14);
            this.label1.TabIndex = 65;
            this.label1.Text = "至";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_daFinDateLast
            // 
            this.m_daFinDateLast.CustomFormat = "yyyy年MM月dd日";
            this.m_daFinDateLast.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_daFinDateLast.Location = new System.Drawing.Point(292, 25);
            this.m_daFinDateLast.Name = "m_daFinDateLast";
            this.m_daFinDateLast.Size = new System.Drawing.Size(128, 23);
            this.m_daFinDateLast.TabIndex = 64;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 14);
            this.label2.TabIndex = 63;
            this.label2.Text = "统计日期 从:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btExcel
            // 
            this.btExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btExcel.DefaultScheme = true;
            this.btExcel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btExcel.Hint = "";
            this.btExcel.Location = new System.Drawing.Point(638, 20);
            this.btExcel.Name = "btExcel";
            this.btExcel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btExcel.Size = new System.Drawing.Size(96, 32);
            this.btExcel.TabIndex = 58;
            this.btExcel.Text = "导出(&O)";
            this.btExcel.Click += new System.EventHandler(this.btExcel_Click);
            // 
            // btOK
            // 
            this.btOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btOK.DefaultScheme = true;
            this.btOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btOK.Hint = "";
            this.btOK.Location = new System.Drawing.Point(529, 20);
            this.btOK.Name = "btOK";
            this.btOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btOK.Size = new System.Drawing.Size(96, 32);
            this.btOK.TabIndex = 58;
            this.btOK.Text = "生成报表(&C)";
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // m_daFinDate
            // 
            this.m_daFinDate.CustomFormat = "yyyy年MM月dd日";
            this.m_daFinDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_daFinDate.Location = new System.Drawing.Point(112, 25);
            this.m_daFinDate.Name = "m_daFinDate";
            this.m_daFinDate.Size = new System.Drawing.Size(128, 23);
            this.m_daFinDate.TabIndex = 60;
            // 
            // myPrintPreViewControl1
            // 
            this.myPrintPreViewControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            //this.myPrintPreViewControl1.BlnCustomFlag = false;
            this.myPrintPreViewControl1.Document = this.printDocument1;
            this.myPrintPreViewControl1.Location = new System.Drawing.Point(8, 68);
            this.myPrintPreViewControl1.Name = "myPrintPreViewControl1";
            this.myPrintPreViewControl1.ReportName = "";
            this.myPrintPreViewControl1.ShowPannel = true;
            this.myPrintPreViewControl1.ShowPrintButton = true;
            this.myPrintPreViewControl1.Size = new System.Drawing.Size(960, 440);
            //this.myPrintPreViewControl1.strCheckName = "";
            //this.myPrintPreViewControl1.strDeptName = "";
            this.myPrintPreViewControl1.TabIndex = 63;
            this.myPrintPreViewControl1.Zoom = 1;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            this.printDocument1.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_EndPrint);
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            // 
            // printDialog1
            // 
            this.printDialog1.AllowCurrentPage = true;
            this.printDialog1.AllowSelection = true;
            this.printDialog1.AllowSomePages = true;
            this.printDialog1.Document = this.printDocument1;
            this.printDialog1.UseEXDialog = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(222, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 14);
            this.label5.TabIndex = 67;
            this.label5.Text = "页面列数:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "9",
            "10",
            "11",
            "12",
            "13"});
            this.comboBox1.Location = new System.Drawing.Point(297, 68);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(89, 22);
            this.comboBox1.TabIndex = 66;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "全院",
            "大院"});
            this.comboBox2.Location = new System.Drawing.Point(435, 26);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(84, 22);
            this.comboBox2.TabIndex = 68;
            this.comboBox2.Text = "全院";
            // 
            // frmGroupWorkLoadReport
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.CancelButton = this.btExit;
            this.ClientSize = new System.Drawing.Size(972, 509);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.myPrintPreViewControl1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGroupWorkLoadReport";
            this.Text = "工作组工作量统计报表";
            this.Load += new System.EventHandler(this.frmGroupWorkLoadReport_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void btOK_Click(object sender, System.EventArgs e)
		{
            CreateRpt();
            
		}

        private void CreateRpt()
        {
            ((clsCtl_GroupWorkLoadReport)this.objController).m_mthCreatTable();
            ((clsCtl_GroupWorkLoadReport)this.objController).m_mthGetMultWorkLoadData(0);
            this.myPrintPreViewControl1.Document = this.printDocument1;
        }
        
		private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
		((clsCtl_GroupWorkLoadReport)this.objController).m_mthBeginPrint(e);
		}

		private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			((clsCtl_GroupWorkLoadReport)this.objController).m_mthPrint(e);
		}

		private void frmGroupWorkLoadReport_Load(object sender, System.EventArgs e)
		{
          this.comboBox1.SelectedIndex = 4;
		  ((clsCtl_GroupWorkLoadReport)this.objController).m_mthFromLoad();
           //CreateRpt();
		}

		private void printDocument1_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			((clsCtl_GroupWorkLoadReport)this.objController).m_mthEndPrint(e);
		}

		private void btExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btPrint_Click(object sender, System.EventArgs e)
		{
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

        private void btExcel_Click(object sender, EventArgs e)
        {
            clsControlChargeWorkReport cls = new clsControlChargeWorkReport();
            DataRow dr = ((clsCtl_GroupWorkLoadReport)this.objController).Mydt.Rows[0];

            ((clsCtl_GroupWorkLoadReport)this.objController).Mydt.Rows[0].Delete();
            ((clsCtl_GroupWorkLoadReport)this.objController).Mydt.AcceptChanges();
            DataTable dtTempMydt = ((clsCtl_GroupWorkLoadReport)this.objController).Mydt;
            DataTable dtTemp2 = new DataTable();
            for (int i = 0; i < dtTempMydt.Columns.Count; i++)
            {
                //if (dtTempMydt.Columns[i].ColumnName.IndexOf("名称") >= 0)
                //{
                    dtTemp2.Columns.Add(dtTempMydt.Columns[i].ColumnName, System.Type.GetType("System.String"));
                //}
                //else
                //{
                //    dtTemp2.Columns.Add(dtTempMydt.Columns[i].ColumnName, System.Type.GetType("System.Decimal"));
                //}
            }
            DataRow drnew = null;
            for (int i = 0; i < dtTempMydt.Rows.Count ; i++)
            {
                drnew = dtTemp2.NewRow();
                for (int i2 = 0; i2 < dtTempMydt.Columns.Count ; i2++)
                {
                    if (dtTempMydt.Rows[i][i2].ToString().Trim() == "")
                    {
                        //if (dtTempMydt.Columns[i2].DataType.FullName.ToString() == "System.Decimal")
                        //{
                        //    drnew[i2] = 0;
                        //}
                        //else
                        //{
                        //    drnew[i2] = "0";
                        //}
                        drnew[i2] = "0";
                    }
                    else
                    {

                        //if (dtTempMydt.Rows[i][i2].ToString().IndexOf("合计") < 0)
                        //{
                        //    if (dtTemp2.Columns[i2].DataType.FullName.ToString() == "System.Decimal")
                        //    {
                        //        try
                        //        {
                        //            drnew[i2] = Convert.ToDecimal(dtTempMydt.Rows[i][i2]);
                        //        }
                        //        catch
                        //        {
                        //            drnew[i2] = dtTempMydt.Rows[i][i2];
                        //        }
                        //    }
                        //    else
                        //    {
                        //        drnew[i2] = dtTempMydt.Rows[i][i2].ToString();
                        //    }
                        //}
                        drnew[i2] = dtTempMydt.Rows[i][i2];
                    }
                }
                dtTemp2.Rows.Add(drnew);
            }

            cls.m_mthOutExcel(dtTemp2);
            ((clsCtl_GroupWorkLoadReport)this.objController).Mydt.Rows.InsertAt(dr, 0);
            ((clsCtl_GroupWorkLoadReport)this.objController).Mydt.AcceptChanges();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0: this.myPrintPreViewControl1.txtCount.Text = "0.095"; break;
                case 1: this.myPrintPreViewControl1.txtCount.Text = "0.085"; break;
                case 2: this.myPrintPreViewControl1.txtCount.Text = "0.078"; break;
                case 3: this.myPrintPreViewControl1.txtCount.Text = "0.071"; break;
                case 4: this.myPrintPreViewControl1.txtCount.Text = "0.065"; break;
            }
        }

	}
}
