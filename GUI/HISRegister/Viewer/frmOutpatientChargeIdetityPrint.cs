using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	///  门诊收费按身份分类统计报表：created by weiling.huang  at 2005-9-16
	/// </summary>
	public class frmOutpatientChargeIdetityPrint : com.digitalwave.GUI_Base.frmMDI_Child_Base	//GUI_Base.dll
	{
		private System.Windows.Forms.Panel panelTop;
		private System.Windows.Forms.Panel panelFill;
		public System.Drawing.Printing.PrintDocument m_printDocument1;
		public System.Windows.Forms.PrintPreviewDialog m_printPreviewDialog1;
		public System.Windows.Forms.PrintPreviewControl m_printPreviewControl1;
		private PinkieControls.ButtonXP m_cmdExit;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		public System.Windows.Forms.DateTimePicker m_dateTimePickerBegin;
		public System.Windows.Forms.DateTimePicker m_dateTimePickerEnd;
		public System.Windows.Forms.ComboBox m_cboIdentity;
		public System.Windows.Forms.ComboBox m_cboOperator;
		private PinkieControls.ButtonXP m_cmdQuery;
		private PinkieControls.ButtonXP buttonXP2;
		public System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Label label5;
        private PinkieControls.ButtonXP m_cmdOutExcel;
        private PrintDialog printDialog1;
		/// <summary>
		/// 必需的设计器变量。：created by weiling.huang  at 2005-9-16
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmOutpatientChargeIdetityPrint()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOutpatientChargeIdetityPrint));
            this.panelTop = new System.Windows.Forms.Panel();
            this.m_cmdOutExcel = new PinkieControls.ButtonXP();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.buttonXP2 = new PinkieControls.ButtonXP();
            this.m_cmdQuery = new PinkieControls.ButtonXP();
            this.m_cboOperator = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_cboIdentity = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.m_dateTimePickerBegin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.m_cmdExit = new PinkieControls.ButtonXP();
            this.panelFill = new System.Windows.Forms.Panel();
            this.m_printPreviewControl1 = new System.Windows.Forms.PrintPreviewControl();
            this.m_printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.m_printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panelFill.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTop.Controls.Add(this.m_cmdOutExcel);
            this.panelTop.Controls.Add(this.label5);
            this.panelTop.Controls.Add(this.numericUpDown1);
            this.panelTop.Controls.Add(this.buttonXP2);
            this.panelTop.Controls.Add(this.m_cmdQuery);
            this.panelTop.Controls.Add(this.m_cboOperator);
            this.panelTop.Controls.Add(this.label4);
            this.panelTop.Controls.Add(this.m_cboIdentity);
            this.panelTop.Controls.Add(this.label3);
            this.panelTop.Controls.Add(this.m_dateTimePickerEnd);
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Controls.Add(this.m_dateTimePickerBegin);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Controls.Add(this.m_cmdExit);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1000, 56);
            this.panelTop.TabIndex = 0;
            // 
            // m_cmdOutExcel
            // 
            this.m_cmdOutExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdOutExcel.DefaultScheme = true;
            this.m_cmdOutExcel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdOutExcel.Hint = "";
            this.m_cmdOutExcel.Location = new System.Drawing.Point(784, 11);
            this.m_cmdOutExcel.Name = "m_cmdOutExcel";
            this.m_cmdOutExcel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdOutExcel.Size = new System.Drawing.Size(80, 32);
            this.m_cmdOutExcel.TabIndex = 75;
            this.m_cmdOutExcel.Text = "导出(&O)";
            this.m_cmdOutExcel.Click += new System.EventHandler(this.m_cmdOutExcel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(944, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 14);
            this.label5.TabIndex = 74;
            this.label5.Text = "页码:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(984, 16);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(40, 23);
            this.numericUpDown1.TabIndex = 73;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // buttonXP2
            // 
            this.buttonXP2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP2.DefaultScheme = true;
            this.buttonXP2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP2.Hint = "";
            this.buttonXP2.Location = new System.Drawing.Point(704, 11);
            this.buttonXP2.Name = "buttonXP2";
            this.buttonXP2.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP2.Size = new System.Drawing.Size(80, 32);
            this.buttonXP2.TabIndex = 72;
            this.buttonXP2.Text = "打印(&F4)";
            this.buttonXP2.Click += new System.EventHandler(this.buttonXP2_Click);
            // 
            // m_cmdQuery
            // 
            this.m_cmdQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdQuery.DefaultScheme = true;
            this.m_cmdQuery.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdQuery.Hint = "";
            this.m_cmdQuery.Location = new System.Drawing.Point(624, 11);
            this.m_cmdQuery.Name = "m_cmdQuery";
            this.m_cmdQuery.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdQuery.Size = new System.Drawing.Size(80, 32);
            this.m_cmdQuery.TabIndex = 60;
            this.m_cmdQuery.Text = "查询(&F6)";
            this.m_cmdQuery.Click += new System.EventHandler(this.m_cmdQuery_Click);
            // 
            // m_cboOperator
            // 
            this.m_cboOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboOperator.Location = new System.Drawing.Point(528, 16);
            this.m_cboOperator.Name = "m_cboOperator";
            this.m_cboOperator.Size = new System.Drawing.Size(88, 22);
            this.m_cboOperator.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(472, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "操作员:";
            // 
            // m_cboIdentity
            // 
            this.m_cboIdentity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboIdentity.Location = new System.Drawing.Point(384, 16);
            this.m_cboIdentity.Name = "m_cboIdentity";
            this.m_cboIdentity.Size = new System.Drawing.Size(88, 22);
            this.m_cboIdentity.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(344, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "身份:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // m_dateTimePickerEnd
            // 
            this.m_dateTimePickerEnd.Location = new System.Drawing.Point(216, 16);
            this.m_dateTimePickerEnd.Name = "m_dateTimePickerEnd";
            this.m_dateTimePickerEnd.Size = new System.Drawing.Size(120, 23);
            this.m_dateTimePickerEnd.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(200, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "至";
            // 
            // m_dateTimePickerBegin
            // 
            this.m_dateTimePickerBegin.Location = new System.Drawing.Point(80, 16);
            this.m_dateTimePickerBegin.Name = "m_dateTimePickerBegin";
            this.m_dateTimePickerBegin.Size = new System.Drawing.Size(120, 23);
            this.m_dateTimePickerBegin.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "统计时期:";
            // 
            // m_cmdExit
            // 
            this.m_cmdExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdExit.DefaultScheme = true;
            this.m_cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdExit.Hint = "";
            this.m_cmdExit.Location = new System.Drawing.Point(864, 11);
            this.m_cmdExit.Name = "m_cmdExit";
            this.m_cmdExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdExit.Size = new System.Drawing.Size(80, 32);
            this.m_cmdExit.TabIndex = 70;
            this.m_cmdExit.Text = "退出(&ESC)";
            this.m_cmdExit.Click += new System.EventHandler(this.m_cmdExit_Click);
            // 
            // panelFill
            // 
            this.panelFill.Controls.Add(this.m_printPreviewControl1);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(0, 56);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(1000, 469);
            this.panelFill.TabIndex = 1;
            // 
            // m_printPreviewControl1
            // 
            this.m_printPreviewControl1.AutoZoom = false;
            this.m_printPreviewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_printPreviewControl1.Document = this.m_printDocument1;
            this.m_printPreviewControl1.Location = new System.Drawing.Point(0, 0);
            this.m_printPreviewControl1.Name = "m_printPreviewControl1";
            this.m_printPreviewControl1.Size = new System.Drawing.Size(1000, 469);
            this.m_printPreviewControl1.TabIndex = 2;
            this.m_printPreviewControl1.Zoom = 1;
            // 
            // m_printDocument1
            // 
            this.m_printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.m_printDocument1_PrintPage);
            this.m_printDocument1.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.m_printDocument1_EndPrint);
            this.m_printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.m_printDocument1_BeginPrint);
            // 
            // m_printPreviewDialog1
            // 
            this.m_printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.m_printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.m_printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.m_printPreviewDialog1.Document = this.m_printDocument1;
            this.m_printPreviewDialog1.Enabled = true;
            this.m_printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("m_printPreviewDialog1.Icon")));
            this.m_printPreviewDialog1.Name = "m_printPreviewDialog1";
            this.m_printPreviewDialog1.Visible = false;
            // 
            // printDialog1
            // 
            this.printDialog1.AllowCurrentPage = true;
            this.printDialog1.AllowSelection = true;
            this.printDialog1.AllowSomePages = true;
            this.printDialog1.Document = this.m_printDocument1;
            this.printDialog1.UseEXDialog = true;
            // 
            // frmOutpatientChargeIdetityPrint
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.CancelButton = this.m_cmdExit;
            this.ClientSize = new System.Drawing.Size(1000, 525);
            this.Controls.Add(this.panelFill);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmOutpatientChargeIdetityPrint";
            this.Text = "门诊收费按身份分类统计报表";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmOutpatientChargeIdetityPrint_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panelFill.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region 重载CreateController
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		public override void CreateController()
		{			
			this.objController = new clsOutpatientChargeIdetityPrint();
			this.objController.Set_GUI_Apperance(this);
		}
		#endregion

		private void m_cmdPriview_Click(object sender, System.EventArgs e)
		{
			//显示打印预览
			this.m_printPreviewDialog1.ShowDialog();
		}

		private void m_cmdExit_Click(object sender, System.EventArgs e)
		{
			//关闭窗体
			this.Close();
		}

		private void m_printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			// 打印每一页时触发
			((clsOutpatientChargeIdetityPrint)objController).m_printDoc_PrintPage(sender, e);
		}

		private void m_printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			((clsOutpatientChargeIdetityPrint)objController).m_printDoc_BeginPrint(sender, e);
		
		}

		private void m_printDocument1_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			((clsOutpatientChargeIdetityPrint)objController).m_printDoc_EndPrint(sender, e);			
		}

		private void m_cmdQuery_Click(object sender, System.EventArgs e)
		{
			//方法：触发打印事件
			((clsOutpatientChargeIdetityPrint)objController).m_mthQueryClick();
			

		}

		private void frmOutpatientChargeIdetityPrint_Load(object sender, System.EventArgs e)
		{	//控件初始化
			((clsOutpatientChargeIdetityPrint)objController).m_mthFrmInit();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
	
		}

		private void button1_Click_1(object sender, System.EventArgs e)
		{

		}

		private void button1_Click_2(object sender, System.EventArgs e)
		{
			((clsOutpatientChargeIdetityPrint)objController).m_mthClick();
			
		}

		private void buttonXP1_Click(object sender, System.EventArgs e)
		{
			((clsOutpatientChargeIdetityPrint)objController).m_mthClick();
		
		}

		private void buttonXP2_Click(object sender, System.EventArgs e)
		{
            if (this.printDialog1.ShowDialog() == DialogResult.OK)
            {
                this.m_printDocument1.PrinterSettings.PrinterName = this.printDialog1.PrinterSettings.PrinterName;
            }
            else
            {
                return;
            }
            try
            {
                this.m_printDocument1.Print();
            }
            catch
            {
                MessageBox.Show("没有打印机!");
            }
		}

		private void numericUpDown1_ValueChanged(object sender, System.EventArgs e)
		{
			this.m_printPreviewControl1.StartPage = (int)this.numericUpDown1.Value-1;
		}

		private void label3_Click(object sender, System.EventArgs e)
		{
		
		}

		private void m_cmdOutExcel_Click(object sender, System.EventArgs e)
		{
			((clsOutpatientChargeIdetityPrint)objController).m_mthOutExcel();

		}
	}
}
