using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Printing;
namespace  com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmDoctorWorkLoadReport 的摘要说明。
	/// </summary>
	public class frmDoctorWorkLoadReport :com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private System.Windows.Forms.GroupBox groupBox1;
		internal System.Drawing.Printing.PrintDocument printDocument1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		internal System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Label label4;
		internal System.Windows.Forms.DateTimePicker dateTimePicker2;
		internal System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label label5;
		internal PinkieControls.ButtonXP btPrint;
		internal PinkieControls.ButtonXP btFind;
		internal PinkieControls.ButtonXP btExit;
		private System.Windows.Forms.Panel panel1;
		internal System.Windows.Forms.ListView listView2;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		internal System.Windows.Forms.RadioButton radioButton1;
		internal System.Windows.Forms.RadioButton radioButton2;
		internal System.Windows.Forms.RadioButton radioButton3;
		internal System.Windows.Forms.RadioButton radioButton4;
		internal System.Windows.Forms.TextBox txtCode;
		internal com.digitalwave.iCare.gui.HIS.exComboBox cmbDep;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		internal System.Windows.Forms.TextBox txtDocType;
        internal com.digitalwave.controls.Control.MyPrintPreViewControl myPrintPreViewControl1;
        internal PinkieControls.ButtonXP m_btnOutExcel;
        private PrintDialog printDialog1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmDoctorWorkLoadReport()
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
			this.objController=new com.digitalwave.iCare.gui.HIS.clsCtl_DoctorWorkLoadReport();
			objController.Set_GUI_Apperance(this);
		}
		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_btnOutExcel = new PinkieControls.ButtonXP();
            this.cmbDep = new com.digitalwave.iCare.gui.HIS.exComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.btExit = new PinkieControls.ButtonXP();
            this.btFind = new PinkieControls.ButtonXP();
            this.btPrint = new PinkieControls.ButtonXP();
            this.txtDocType = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.myPrintPreViewControl1 = new com.digitalwave.controls.Control.MyPrintPreViewControl();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.m_btnOutExcel);
            this.groupBox1.Controls.Add(this.cmbDep);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtCode);
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.btExit);
            this.groupBox1.Controls.Add(this.btFind);
            this.groupBox1.Controls.Add(this.btPrint);
            this.groupBox1.Controls.Add(this.txtDocType);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.groupBox1.Location = new System.Drawing.Point(8, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(964, 124);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // m_btnOutExcel
            // 
            this.m_btnOutExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnOutExcel.DefaultScheme = true;
            this.m_btnOutExcel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnOutExcel.Hint = "";
            this.m_btnOutExcel.Location = new System.Drawing.Point(772, 72);
            this.m_btnOutExcel.Name = "m_btnOutExcel";
            this.m_btnOutExcel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnOutExcel.Size = new System.Drawing.Size(80, 32);
            this.m_btnOutExcel.TabIndex = 55;
            this.m_btnOutExcel.Text = "导出(&E)";
            this.m_btnOutExcel.Click += new System.EventHandler(this.m_btnOutExcel_Click);
            // 
            // cmbDep
            // 
            this.cmbDep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDep.Location = new System.Drawing.Point(568, 77);
            this.cmbDep.Name = "cmbDep";
            this.cmbDep.Size = new System.Drawing.Size(160, 22);
            this.cmbDep.TabIndex = 54;
            this.cmbDep.SelectedIndexChanged += new System.EventHandler(this.cmbDep_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(508, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 14);
            this.label7.TabIndex = 53;
            this.label7.Text = "科 室:";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(196, 28);
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(68, 23);
            this.txtCode.TabIndex = 52;
            // 
            // radioButton4
            // 
            this.radioButton4.Location = new System.Drawing.Point(12, 92);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(100, 24);
            this.radioButton4.TabIndex = 51;
            this.radioButton4.Text = "全部科室";
            // 
            // radioButton3
            // 
            this.radioButton3.Location = new System.Drawing.Point(12, 68);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(100, 24);
            this.radioButton3.TabIndex = 50;
            this.radioButton3.Text = "单一科室";
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(12, 44);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(100, 24);
            this.radioButton2.TabIndex = 49;
            this.radioButton2.Text = "全部员工";
            // 
            // radioButton1
            // 
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(12, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(100, 24);
            this.radioButton1.TabIndex = 48;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "单一员工";
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // btExit
            // 
            this.btExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btExit.DefaultScheme = true;
            this.btExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btExit.Hint = "";
            this.btExit.Location = new System.Drawing.Point(868, 72);
            this.btExit.Name = "btExit";
            this.btExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btExit.Size = new System.Drawing.Size(80, 32);
            this.btExit.TabIndex = 47;
            this.btExit.Text = "退出(ESC)";
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // btFind
            // 
            this.btFind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btFind.DefaultScheme = true;
            this.btFind.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btFind.Hint = "";
            this.btFind.Location = new System.Drawing.Point(772, 24);
            this.btFind.Name = "btFind";
            this.btFind.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btFind.Size = new System.Drawing.Size(80, 32);
            this.btFind.TabIndex = 46;
            this.btFind.Text = "查询(&F)";
            this.btFind.Click += new System.EventHandler(this.btFind_Click);
            // 
            // btPrint
            // 
            this.btPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btPrint.DefaultScheme = true;
            this.btPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btPrint.Hint = "";
            this.btPrint.Location = new System.Drawing.Point(868, 24);
            this.btPrint.Name = "btPrint";
            this.btPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btPrint.Size = new System.Drawing.Size(80, 32);
            this.btPrint.TabIndex = 45;
            this.btPrint.Text = "打印(&P)";
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // txtDocType
            // 
            this.txtDocType.Location = new System.Drawing.Point(568, 28);
            this.txtDocType.Name = "txtDocType";
            this.txtDocType.ReadOnly = true;
            this.txtDocType.Size = new System.Drawing.Size(160, 23);
            this.txtDocType.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(508, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "职 称:";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(364, 76);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(132, 23);
            this.dateTimePicker2.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(332, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "至";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(196, 76);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(132, 23);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(124, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "日    期:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(364, 28);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(132, 23);
            this.txtName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(280, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "医生名称:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(124, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "员工编号:";
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            this.printDocument1.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_EndPrint);
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.listView2);
            this.panel1.Location = new System.Drawing.Point(8, 136);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(964, 376);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.myPrintPreViewControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(215, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(749, 376);
            this.panel2.TabIndex = 11;
            // 
            // myPrintPreViewControl1
            // 
            this.myPrintPreViewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myPrintPreViewControl1.Document = this.printDocument1;
            this.myPrintPreViewControl1.Location = new System.Drawing.Point(0, 0);
            this.myPrintPreViewControl1.Name = "myPrintPreViewControl1";
            this.myPrintPreViewControl1.ReportName = "医生工作量报表";
            this.myPrintPreViewControl1.ShowPannel = true;
            this.myPrintPreViewControl1.ShowPrintButton = true;
            this.myPrintPreViewControl1.Size = new System.Drawing.Size(749, 376);
            this.myPrintPreViewControl1.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(212, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 376);
            this.splitter1.TabIndex = 10;
            this.splitter1.TabStop = false;
            // 
            // listView2
            // 
            this.listView2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader1});
            this.listView2.Dock = System.Windows.Forms.DockStyle.Left;
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(0, 0);
            this.listView2.MultiSelect = false;
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(212, 376);
            this.listView2.TabIndex = 9;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "编号";
            this.columnHeader4.Width = 54;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "名称";
            this.columnHeader5.Width = 84;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "职称";
            this.columnHeader6.Width = 53;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 0;
            // 
            // printDialog1
            // 
            this.printDialog1.AllowCurrentPage = true;
            this.printDialog1.AllowSelection = true;
            this.printDialog1.AllowSomePages = true;
            this.printDialog1.Document = this.printDocument1;
            this.printDialog1.UseEXDialog = true;
            // 
            // frmDoctorWorkLoadReport
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.CancelButton = this.btExit;
            this.ClientSize = new System.Drawing.Size(984, 517);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.KeyPreview = true;
            this.Name = "frmDoctorWorkLoadReport";
            this.Text = "工作量统一查询";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDoctorWorkLoadReport_KeyDown);
            this.Load += new System.EventHandler(this.frmDoctorWorkLoadReport_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void txtCode_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
			
			}
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

//		private void m_cboOPInv_SelectedIndexChanged(object sender, System.EventArgs e)
//		{
//		this.printPreviewControl1.Zoom =double.Parse(this.cmbZoom.SelectItemValue);
//		}

		private void frmDoctorWorkLoadReport_Load(object sender, System.EventArgs e)
		{
//			this.cmbZoom.Item.Add("50%","0.5");
//			this.cmbZoom.Item.Add("75%","0.75");
//			this.cmbZoom.Item.Add("100%","1");
//			this.cmbZoom.Item.Add("150%","1.5");
//			this.cmbZoom.Item.Add("200%","2");
//			this.cmbZoom.Item.Add("300%","3");
//			this.cmbZoom.SelectedIndex=2;
			((clsCtl_DoctorWorkLoadReport)this.objController).m_mthLoadDepartment();

			
		}

		private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.radioButton1.Checked)
			{
				this.listView2.Width =212;
			}
			else
			{
			this.listView2.Width =0;
			}
		}

	

//		private void btPrePage_Click(object sender, System.EventArgs e)
//		{
//		this.printPreviewControl1.StartPage-=1;
//		}
//
//		private void btNextPage_Click(object sender, System.EventArgs e)
//		{
//		this.printPreviewControl1.StartPage+=1;
//		}

		private void cmbDep_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		((clsCtl_DoctorWorkLoadReport)this.objController).m_mthGetDocByDepID();
		}

		private void listView2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.listView2.SelectedItems.Count>0)
			{
				this.txtCode.Text=this.listView2.SelectedItems[0].SubItems[0].Text.Trim();
				this.txtCode.Tag=this.listView2.SelectedItems[0].SubItems[3].Text.Trim();
				this.txtName.Text=this.listView2.SelectedItems[0].SubItems[1].Text.Trim();
				this.txtDocType.Text=this.listView2.SelectedItems[0].SubItems[2].Text.Trim();
			}
		}

		private void btFind_Click(object sender, System.EventArgs e)
		{
         
			this.myPrintPreViewControl1.Document=this.printDocument1;
           
		}

		private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
         
		    ((clsCtl_DoctorWorkLoadReport)this.objController).m_mthPrint(e);
            
		}

		private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
            this.Cursor = Cursors.WaitCursor;
			if(this.radioButton1.Checked||this.radioButton3.Checked)
			{
				//this.printDocument1.DefaultPageSettings.Landscape=false;
				foreach(PaperSize ps in this.printDocument1.PrinterSettings.PaperSizes)
				{
					if(ps.PaperName=="A4")
					{
						this.printDocument1.DefaultPageSettings.PaperSize=ps;
						break;
					}
				}
			}
			else
			{
				//this.printDocument1.DefaultPageSettings.Landscape=true;
				foreach(PaperSize ps in this.printDocument1.PrinterSettings.PaperSizes)
				{
					if(ps.PaperName=="A3")
					{
						this.printDocument1.DefaultPageSettings.PaperSize=ps;
						break;
					}
				}
			}
			((clsCtl_DoctorWorkLoadReport)this.objController).m_mthBeginPrint();
			}

		private void frmDoctorWorkLoadReport_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Escape)
			{
			if(MessageBox.Show("确认退出吗?","iCare",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
					return;
				this.Close();
		}
		}

        private void m_btnOutExcel_Click(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked || this.radioButton3.Checked)
            {
                ((clsCtl_DoctorWorkLoadReport)this.objController).m_mthDataExportToExcel(1);
            }
            else if (this.radioButton2.Checked || this.radioButton4.Checked)
            {
                ((clsCtl_DoctorWorkLoadReport)this.objController).m_mthDataExportToExcel(2);
            }
        }

        private void printDocument1_EndPrint(object sender, PrintEventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
		}

		
	}

