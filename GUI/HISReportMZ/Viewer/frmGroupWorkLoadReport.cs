using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
namespace com.digitalwave.iCare.gui.HIS.Reports
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
		internal com.digitalwave.controls.Control.MyPrintPreViewControl myPrintPreViewControl1;
		private System.Drawing.Printing.PrintDocument printDocument1;
        internal PinkieControls.ButtonXP btExcel;
        private PrintDialog printDialog1;
        internal exComboBox m_cboDept;
        internal exComboBox m_cboCheckMan;
        private Label label4;
        private Label label3;
        public ComboBox comboBox1;
        private Label label5;
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
            this.objController = new com.digitalwave.iCare.gui.HIS.Reports.clsCtl_GroupWorkLoadReport();
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
            this.label4 = new System.Windows.Forms.Label();
            this.btPrint = new PinkieControls.ButtonXP();
            this.m_daFinDateLast = new System.Windows.Forms.DateTimePicker();
            this.btExcel = new PinkieControls.ButtonXP();
            this.btOK = new PinkieControls.ButtonXP();
            this.m_daFinDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.myPrintPreViewControl1 = new com.digitalwave.controls.Control.MyPrintPreViewControl();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_cboDept = new com.digitalwave.iCare.gui.HIS.exComboBox();
            this.m_cboCheckMan = new com.digitalwave.iCare.gui.HIS.exComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.m_cboDept);
            this.groupBox1.Controls.Add(this.btPrint);
            this.groupBox1.Controls.Add(this.m_cboCheckMan);
            this.groupBox1.Controls.Add(this.m_daFinDateLast);
            this.groupBox1.Controls.Add(this.btExcel);
            this.groupBox1.Controls.Add(this.btOK);
            this.groupBox1.Controls.Add(this.m_daFinDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(4, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1020, 64);
            this.groupBox1.TabIndex = 62;
            this.groupBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(545, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 14);
            this.label4.TabIndex = 71;
            this.label4.Text = "科室:";
            // 
            // btPrint
            // 
            this.btPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btPrint.DefaultScheme = true;
            this.btPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btPrint.Hint = "";
            this.btPrint.Location = new System.Drawing.Point(940, 19);
            this.btPrint.Name = "btPrint";
            this.btPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btPrint.Size = new System.Drawing.Size(77, 32);
            this.btPrint.TabIndex = 66;
            this.btPrint.Text = "打印(&P)";
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // m_daFinDateLast
            // 
            this.m_daFinDateLast.CustomFormat = "yyyy年MM月dd日";
            this.m_daFinDateLast.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_daFinDateLast.Location = new System.Drawing.Point(247, 24);
            this.m_daFinDateLast.Name = "m_daFinDateLast";
            this.m_daFinDateLast.Size = new System.Drawing.Size(125, 23);
            this.m_daFinDateLast.TabIndex = 64;
            // 
            // btExcel
            // 
            this.btExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btExcel.DefaultScheme = true;
            this.btExcel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btExcel.Hint = "";
            this.btExcel.Location = new System.Drawing.Point(862, 19);
            this.btExcel.Name = "btExcel";
            this.btExcel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btExcel.Size = new System.Drawing.Size(75, 32);
            this.btExcel.TabIndex = 58;
            this.btExcel.Text = "导出(&O)";
            this.btExcel.Click += new System.EventHandler(this.btExcel_Click);
            // 
            // btOK
            // 
            this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btOK.DefaultScheme = true;
            this.btOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btOK.Hint = "";
            this.btOK.Location = new System.Drawing.Point(758, 19);
            this.btOK.Name = "btOK";
            this.btOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btOK.Size = new System.Drawing.Size(102, 32);
            this.btOK.TabIndex = 58;
            this.btOK.Text = "生成报表(&C)";
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // m_daFinDate
            // 
            this.m_daFinDate.CustomFormat = "yyyy年MM月dd日";
            this.m_daFinDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_daFinDate.Location = new System.Drawing.Point(92, 23);
            this.m_daFinDate.Name = "m_daFinDate";
            this.m_daFinDate.Size = new System.Drawing.Size(128, 23);
            this.m_daFinDate.TabIndex = 60;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 14);
            this.label2.TabIndex = 63;
            this.label2.Text = "统计日期 从";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(223, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 14);
            this.label1.TabIndex = 65;
            this.label1.Text = "至";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(381, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 14);
            this.label3.TabIndex = 70;
            this.label3.Text = "收费员:";
            // 
            // myPrintPreViewControl1
            // 
            this.myPrintPreViewControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.myPrintPreViewControl1.Document = this.printDocument1;
            this.myPrintPreViewControl1.Location = new System.Drawing.Point(8, 68);
            this.myPrintPreViewControl1.Name = "myPrintPreViewControl1";
            this.myPrintPreViewControl1.ReportName = "";
            this.myPrintPreViewControl1.ShowPannel = true;
            this.myPrintPreViewControl1.ShowPrintButton = true;
            this.myPrintPreViewControl1.Size = new System.Drawing.Size(1016, 440);
            this.myPrintPreViewControl1.TabIndex = 63;
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
            this.comboBox1.Location = new System.Drawing.Point(302, 69);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(74, 22);
            this.comboBox1.TabIndex = 64;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(227, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 14);
            this.label5.TabIndex = 65;
            this.label5.Text = "页面列数:";
            // 
            // m_cboDept
            // 
            this.m_cboDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboDept.Location = new System.Drawing.Point(591, 25);
            this.m_cboDept.Margin = new System.Windows.Forms.Padding(0);
            this.m_cboDept.Name = "m_cboDept";
            this.m_cboDept.Size = new System.Drawing.Size(149, 22);
            this.m_cboDept.TabIndex = 68;
            // 
            // m_cboCheckMan
            // 
            this.m_cboCheckMan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboCheckMan.Location = new System.Drawing.Point(436, 25);
            this.m_cboCheckMan.Margin = new System.Windows.Forms.Padding(0);
            this.m_cboCheckMan.Name = "m_cboCheckMan";
            this.m_cboCheckMan.Size = new System.Drawing.Size(103, 22);
            this.m_cboCheckMan.TabIndex = 69;
            // 
            // frmGroupWorkLoadReport
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(1028, 509);
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
            this.printDialog1.PrinterSettings.FromPage = 0;
            this.printDialog1.PrinterSettings.ToPage = 0;
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
            DataTable m_objTable;
            string strINTERNALFLAG = "-1";
            clsDomainControl_Register domain = new clsDomainControl_Register();
            domain.m_lngGetDeptInfo(out m_objTable, strINTERNALFLAG);
            if (m_objTable != null)
            {
                this.m_cboDept.Items.Clear();
                this.m_cboDept.Item.Add("全部", "1000");
                if (m_objTable.Rows.Count > 0)
                {

                    for (int i1 = 0; i1 < m_objTable.Rows.Count; i1++)
                    {
                        this.m_cboDept.Item.Add(m_objTable.Rows[i1]["deptname_vchr"].ToString(), m_objTable.Rows[i1]["deptid_chr"].ToString());
                    }
                    this.m_cboDept.SelectedIndex = 0;
                }

            }
            m_objTable=null;
            domain.m_lngGetCheckMan(out m_objTable, strINTERNALFLAG);
            if (m_objTable != null)
            {
                this.m_cboCheckMan.Items.Clear();

                if (m_objTable.Rows.Count > 0)
                {
                    this.m_cboCheckMan.Item.Add("全部", "1000");
                    for (int i1 = 0; i1 < m_objTable.Rows.Count; i1++)
                    {
                        this.m_cboCheckMan.Item.Add(m_objTable.Rows[i1]["LASTNAME_VCHR"].ToString(), m_objTable.Rows[i1]["BALANCEEMP_CHR"].ToString());
                    }
                    this.m_cboCheckMan.SelectedIndex = 0;
                }

            }
            ((clsCtl_GroupWorkLoadReport)this.objController).m_mthFromLoad();
            CreateRpt();
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
                if (dtTempMydt.Columns[i].ColumnName.IndexOf("名称") >= 0)
                {
                    dtTemp2.Columns.Add(dtTempMydt.Columns[i].ColumnName, System.Type.GetType("System.String"));
                }
                else
                {
                    dtTemp2.Columns.Add(dtTempMydt.Columns[i].ColumnName, System.Type.GetType("System.Decimal"));
                }
                //dtTemp2.Columns.Add(dtTempMydt.Columns[i].ColumnName, System.Type.GetType("System.String"));
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
                        //        drnew[i2] = Convert.ToDecimal(dtTempMydt.Rows[i][i2]);
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
