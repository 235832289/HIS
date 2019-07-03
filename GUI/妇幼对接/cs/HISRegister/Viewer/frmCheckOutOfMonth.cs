using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using  com.digitalwave.iCare.common;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmCheckOutOfMonth 的摘要说明。
	/// </summary>
	public class frmCheckOutOfMonth : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private System.Windows.Forms.Panel panel1;
		internal System.Windows.Forms.DateTimePicker startDate;
		internal System.Windows.Forms.DateTimePicker endDate;
		private PinkieControls.ButtonXP btnFind;
		private PinkieControls.ButtonXP btnPrint;
		private PinkieControls.ButtonXP btnEsc;
		private System.Windows.Forms.Panel panel2;
		private System.Drawing.Printing.PrintDocument printDocument1;
		private System.Windows.Forms.Label label1;
		internal com.digitalwave.iCare.gui.HIS.exComboBox m_cboCheckMan;
		private com.digitalwave.controls.Control.ctlprintShow ctlprintShow1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmCheckOutOfMonth()
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.m_cboCheckMan = new com.digitalwave.iCare.gui.HIS.exComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnEsc = new PinkieControls.ButtonXP();
			this.btnPrint = new PinkieControls.ButtonXP();
			this.btnFind = new PinkieControls.ButtonXP();
			this.endDate = new System.Windows.Forms.DateTimePicker();
			this.startDate = new System.Windows.Forms.DateTimePicker();
			this.printDocument1 = new System.Drawing.Printing.PrintDocument();
			this.panel2 = new System.Windows.Forms.Panel();
			this.ctlprintShow1 = new com.digitalwave.controls.Control.ctlprintShow();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.m_cboCheckMan);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.btnEsc);
			this.panel1.Controls.Add(this.btnPrint);
			this.panel1.Controls.Add(this.btnFind);
			this.panel1.Controls.Add(this.endDate);
			this.panel1.Controls.Add(this.startDate);
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1028, 48);
			this.panel1.TabIndex = 0;
			// 
			// m_cboCheckMan
			// 
			this.m_cboCheckMan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboCheckMan.Location = new System.Drawing.Point(352, 8);
			this.m_cboCheckMan.Name = "m_cboCheckMan";
			this.m_cboCheckMan.Size = new System.Drawing.Size(136, 22);
			this.m_cboCheckMan.TabIndex = 25;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
			this.label1.Location = new System.Drawing.Point(168, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 23);
			this.label1.TabIndex = 6;
			this.label1.Text = "到";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnEsc
			// 
			this.btnEsc.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btnEsc.DefaultScheme = true;
			this.btnEsc.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnEsc.Hint = "";
			this.btnEsc.Location = new System.Drawing.Point(824, 5);
			this.btnEsc.Name = "btnEsc";
			this.btnEsc.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btnEsc.Size = new System.Drawing.Size(96, 29);
			this.btnEsc.TabIndex = 5;
			this.btnEsc.Text = "退出（ESC）";
			this.btnEsc.Click += new System.EventHandler(this.btnEsc_Click);
			// 
			// btnPrint
			// 
			this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btnPrint.DefaultScheme = true;
			this.btnPrint.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btnPrint.Hint = "";
			this.btnPrint.Location = new System.Drawing.Point(672, 5);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btnPrint.Size = new System.Drawing.Size(96, 29);
			this.btnPrint.TabIndex = 4;
			this.btnPrint.Text = "打印（&P）";
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			// 
			// btnFind
			// 
			this.btnFind.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btnFind.DefaultScheme = true;
			this.btnFind.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btnFind.Hint = "";
			this.btnFind.Location = new System.Drawing.Point(520, 5);
			this.btnFind.Name = "btnFind";
			this.btnFind.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btnFind.Size = new System.Drawing.Size(96, 29);
			this.btnFind.TabIndex = 3;
			this.btnFind.Text = "统计（&F）";
			this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
			// 
			// endDate
			// 
			this.endDate.Location = new System.Drawing.Point(214, 8);
			this.endDate.Name = "endDate";
			this.endDate.Size = new System.Drawing.Size(120, 23);
			this.endDate.TabIndex = 1;
			// 
			// startDate
			// 
			this.startDate.Location = new System.Drawing.Point(40, 8);
			this.startDate.Name = "startDate";
			this.startDate.Size = new System.Drawing.Size(120, 23);
			this.startDate.TabIndex = 0;
			// 
			// printDocument1
			// 
			this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
			this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.ctlprintShow1);
			this.panel2.Location = new System.Drawing.Point(0, 56);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1028, 376);
			this.panel2.TabIndex = 2;
			// 
			// ctlprintShow1
			// 
			this.ctlprintShow1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ctlprintShow1.Location = new System.Drawing.Point(0, 0);
			this.ctlprintShow1.Name = "ctlprintShow1";
			this.ctlprintShow1.Size = new System.Drawing.Size(1026, 374);
			this.ctlprintShow1.TabIndex = 3;
			// 
			// frmCheckOutOfMonth
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.CancelButton = this.btnEsc;
			this.ClientSize = new System.Drawing.Size(1028, 437);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.Name = "frmCheckOutOfMonth";
			this.Text = "收费处月结报表";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCheckOutOfMonth_KeyDown);
			this.Load += new System.EventHandler(this.frmCheckOutOfMonth_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 设置窗体对象
		/// </summary>
		public override void CreateController()
		{
			this.objController =new clsControlCheckOutofMonth();
			this.objController.Set_GUI_Apperance(this);
		}

		private void frmCheckOutOfMonth_Load(object sender, System.EventArgs e)
		{
			ctlprintShow1.setDocument=printDocument1;
			startDate.Value=Convert.ToDateTime(startDate.Value.Year.ToString()+"-"+startDate.Value.Month.ToString()+"-"+"01");
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
				((clsControlCheckOutofMonth)this.objController).getData(strINTERNALFLAG,null);
			else
				((clsControlCheckOutofMonth)this.objController).getData(strINTERNALFLAG,m_cboCheckMan.SelectItemValue.ToString());

		}
		
		private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{		
		    ((clsControlCheckOutofMonth)this.objController).printPageFS(e,strINTERNALFLAG);			
		}

		private void btnEsc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			frmSelectPrinter selectPrinter=new frmSelectPrinter();
			if(selectPrinter.ShowDialog()==DialogResult.OK)
			{
				printDocument1.PrinterSettings.PrinterName=selectPrinter.PrinterName;
			}
			else
			{
				return;
			}
			printDocument1.Print();
		}

		private void btnFind_Click(object sender, System.EventArgs e)
		{
			ctlprintShow1.setDocument=printDocument1;
		}

		private void frmCheckOutOfMonth_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Escape)
				this.Close();
		}
	}
}
