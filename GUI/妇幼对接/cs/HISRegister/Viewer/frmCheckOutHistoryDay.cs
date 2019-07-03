using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using com.digitalwave.iCare.common;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmCheckOutHistoryDay 的摘要说明。
	/// </summary>
	public class frmCheckOutHistoryDay: com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        private System.Drawing.Printing.PrintDocument printDocument1;
		private PinkieControls.ButtonXP btnEsc;
		private PinkieControls.ButtonXP btnPrint;
		private PinkieControls.ButtonXP btnFind;
		internal System.Windows.Forms.DateTimePicker m_CheckOuDate;
		internal com.digitalwave.iCare.gui.HIS.exComboBox m_cboCheckMan;
        private com.digitalwave.controls.Control.ctlprintShow ctlprintShow1;
        private PinkieControls.ButtonXP btExcel;
        private PageSetupDialog pageSetupDialog1;
        private Label label1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmCheckOutHistoryDay()
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
			this.objController =new clsCheckOuthistoryDay();
			this.objController.Set_GUI_Apperance(this);
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCheckOutHistoryDay));
            this.ctlprintShow1 = new com.digitalwave.controls.Control.ctlprintShow();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.btnEsc = new PinkieControls.ButtonXP();
            this.btnPrint = new PinkieControls.ButtonXP();
            this.btnFind = new PinkieControls.ButtonXP();
            this.m_CheckOuDate = new System.Windows.Forms.DateTimePicker();
            this.m_cboCheckMan = new com.digitalwave.iCare.gui.HIS.exComboBox();
            this.btExcel = new PinkieControls.ButtonXP();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ctlprintShow1
            // 
            this.ctlprintShow1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlprintShow1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctlprintShow1.Location = new System.Drawing.Point(2, 39);
            this.ctlprintShow1.Name = "ctlprintShow1";
            this.ctlprintShow1.Size = new System.Drawing.Size(806, 450);
            this.ctlprintShow1.TabIndex = 0;
            this.ctlprintShow1.Zoom = 1;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            // 
            // btnEsc
            // 
            this.btnEsc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnEsc.DefaultScheme = true;
            this.btnEsc.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnEsc.Hint = "";
            this.btnEsc.Location = new System.Drawing.Point(703, 6);
            this.btnEsc.Name = "btnEsc";
            this.btnEsc.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnEsc.Size = new System.Drawing.Size(96, 29);
            this.btnEsc.TabIndex = 5;
            this.btnEsc.Text = "退出（ESC）";
            this.btnEsc.Click += new System.EventHandler(this.btnEsc_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnPrint.DefaultScheme = true;
            this.btnPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPrint.Hint = "";
            this.btnPrint.Location = new System.Drawing.Point(587, 6);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnPrint.Size = new System.Drawing.Size(96, 29);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "打印（&P）";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnFind.DefaultScheme = true;
            this.btnFind.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnFind.Hint = "";
            this.btnFind.Location = new System.Drawing.Point(355, 6);
            this.btnFind.Name = "btnFind";
            this.btnFind.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnFind.Size = new System.Drawing.Size(96, 29);
            this.btnFind.TabIndex = 3;
            this.btnFind.Text = "统计（&F）";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // m_CheckOuDate
            // 
            this.m_CheckOuDate.Location = new System.Drawing.Point(66, 9);
            this.m_CheckOuDate.Name = "m_CheckOuDate";
            this.m_CheckOuDate.Size = new System.Drawing.Size(120, 23);
            this.m_CheckOuDate.TabIndex = 1;
            // 
            // m_cboCheckMan
            // 
            this.m_cboCheckMan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboCheckMan.Location = new System.Drawing.Point(199, 9);
            this.m_cboCheckMan.Name = "m_cboCheckMan";
            this.m_cboCheckMan.Size = new System.Drawing.Size(136, 22);
            this.m_cboCheckMan.TabIndex = 24;
            // 
            // btExcel
            // 
            this.btExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btExcel.DefaultScheme = true;
            this.btExcel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btExcel.Hint = "";
            this.btExcel.Location = new System.Drawing.Point(471, 6);
            this.btExcel.Name = "btExcel";
            this.btExcel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btExcel.Size = new System.Drawing.Size(96, 29);
            this.btExcel.TabIndex = 3;
            this.btExcel.Text = "导出（&O）";
            this.btExcel.Click += new System.EventHandler(this.btExcel_Click);
            // 
            // pageSetupDialog1
            // 
            this.pageSetupDialog1.Document = this.printDocument1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 19);
            this.label1.TabIndex = 25;
            this.label1.Text = "时间:";
            // 
            // frmCheckOutHistoryDay
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.CancelButton = this.btnEsc;
            this.ClientSize = new System.Drawing.Size(808, 485);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctlprintShow1);
            this.Controls.Add(this.btExcel);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.m_cboCheckMan);
            this.Controls.Add(this.m_CheckOuDate);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnEsc);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCheckOutHistoryDay";
            this.Text = "结帐历史记录查询（日）";
            this.Load += new System.EventHandler(this.frmCheckOutHistoryDay_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void frmCheckOutHistoryDay_Load(object sender, System.EventArgs e)
		{
            ctlprintShow1.IsShowClose = false;
			ctlprintShow1.setDocument=printDocument1;
			DataTable dtEmpAll;
			clsDomainControl_Register domain=new clsDomainControl_Register();
			domain.m_lngGetCheckMan(out dtEmpAll,strINTERNALFLAG);
			if(dtEmpAll!=null)
			{
				this.m_cboCheckMan.Items.Clear();
				
				if(dtEmpAll.Rows.Count>0)
				{
					this.m_cboCheckMan.Item.Add("全部","1000");
					for(int i1=0;i1<dtEmpAll.Rows.Count;i1++)
					{
						this.m_cboCheckMan.Item.Add(dtEmpAll.Rows[i1]["LASTNAME_VCHR"].ToString(),dtEmpAll.Rows[i1]["BALANCEEMP_CHR"].ToString());
					}
					this.m_cboCheckMan.SelectedIndex=0;
				}
				
			}
		}

		string strINTERNALFLAG;

		public void m_getInternal(string INTERNALFLAG)
		{
			strINTERNALFLAG=INTERNALFLAG;
			this.Show();
		}
		private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			if(m_cboCheckMan.SelectItemValue==""||m_cboCheckMan.SelectItemValue=="1000")
			   ((clsCheckOuthistoryDay)this.objController).getData(strINTERNALFLAG,null);
			else
				((clsCheckOuthistoryDay)this.objController).getData(strINTERNALFLAG,m_cboCheckMan.SelectItemValue.ToString());
		}

		private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{			
	        ((clsCheckOuthistoryDay)this.objController).printPageFS(e,strINTERNALFLAG);		
		}

		private void btnFind_Click(object sender, System.EventArgs e)
		{
            this.Cursor = Cursors.WaitCursor;
			ctlprintShow1.setDocument=printDocument1;
            this.Cursor = Cursors.Default;
		}

		private void btnPrint_Click(object sender, System.EventArgs e)
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
            //printDocument1.Print();
            if (this.pageSetupDialog1.ShowDialog() == DialogResult.OK)
            {
                this.printDocument1.PrinterSettings.PrinterName = this.pageSetupDialog1.PrinterSettings.PrinterName;
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

		private void btnEsc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

        private void btExcel_Click(object sender, EventArgs e)
        {
            clsControlChargeWorkReport cls = new clsControlChargeWorkReport();
            cls.m_mthOutExcel(((clsCheckOuthistoryDay)this.objController).dtStatistics);
        }
	}
}
