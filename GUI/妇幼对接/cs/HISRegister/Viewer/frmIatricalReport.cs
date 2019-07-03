using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmIatricalReport 的摘要说明。
	/// </summary>
	public class frmIatricalReport : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private PinkieControls.ButtonXP btnEsc;
		private PinkieControls.ButtonXP btnPrint;
		private PinkieControls.ButtonXP btnFind;
		internal System.Windows.Forms.DateTimePicker endDate;
		internal System.Windows.Forms.DateTimePicker startDate;
		private System.Windows.Forms.PrintPreviewControl printPreviewControl1;
		private System.Drawing.Printing.PrintDocument printDocument1;
		private System.Windows.Forms.Label label2;
		internal com.digitalwave.iCare.gui.HIS.exComboBox m_CboSeleChargeMan;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmIatricalReport()
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
			this.panel2 = new System.Windows.Forms.Panel();
			this.printPreviewControl1 = new System.Windows.Forms.PrintPreviewControl();
			this.printDocument1 = new System.Drawing.Printing.PrintDocument();
			this.panel1 = new System.Windows.Forms.Panel();
			this.m_CboSeleChargeMan = new com.digitalwave.iCare.gui.HIS.exComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnEsc = new PinkieControls.ButtonXP();
			this.btnPrint = new PinkieControls.ButtonXP();
			this.btnFind = new PinkieControls.ButtonXP();
			this.endDate = new System.Windows.Forms.DateTimePicker();
			this.startDate = new System.Windows.Forms.DateTimePicker();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.printPreviewControl1);
			this.panel2.Location = new System.Drawing.Point(0, 48);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1028, 448);
			this.panel2.TabIndex = 4;
			// 
			// printPreviewControl1
			// 
			this.printPreviewControl1.AutoZoom = false;
			this.printPreviewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.printPreviewControl1.Document = this.printDocument1;
			this.printPreviewControl1.Location = new System.Drawing.Point(0, 0);
			this.printPreviewControl1.Name = "printPreviewControl1";
			this.printPreviewControl1.Size = new System.Drawing.Size(1026, 446);
			this.printPreviewControl1.TabIndex = 0;
			this.printPreviewControl1.Zoom = 1;
			// 
			// printDocument1
			// 
			this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
			this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.m_CboSeleChargeMan);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.btnEsc);
			this.panel1.Controls.Add(this.btnPrint);
			this.panel1.Controls.Add(this.btnFind);
			this.panel1.Controls.Add(this.endDate);
			this.panel1.Controls.Add(this.startDate);
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1028, 40);
			this.panel1.TabIndex = 3;
			// 
			// m_CboSeleChargeMan
			// 
			this.m_CboSeleChargeMan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_CboSeleChargeMan.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_CboSeleChargeMan.ItemHeight = 14;
			this.m_CboSeleChargeMan.Location = new System.Drawing.Point(896, 8);
			this.m_CboSeleChargeMan.Name = "m_CboSeleChargeMan";
			this.m_CboSeleChargeMan.Size = new System.Drawing.Size(120, 22);
			this.m_CboSeleChargeMan.TabIndex = 46;
			this.m_CboSeleChargeMan.SelectedIndexChanged += new System.EventHandler(this.m_CboSeleChargeMan_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(832, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 23);
			this.label2.TabIndex = 10;
			this.label2.Text = "缴款人：";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
			this.btnEsc.Location = new System.Drawing.Point(688, 5);
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
			this.btnPrint.Location = new System.Drawing.Point(538, 5);
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
			this.btnFind.Location = new System.Drawing.Point(388, 5);
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
			// frmIatricalReport
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(1028, 501);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel2);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.Name = "frmIatricalReport";
			this.Text = "医保统计表报";
			this.Load += new System.EventHandler(this.frmIatricalReport_Load);
			this.panel2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 设置窗体对象
		/// </summary>
		public override void CreateController()
		{
			this.objController =new clsControlIatricalReport();
			this.objController.Set_GUI_Apperance(this);
		}
		string strType;
		public void m_ShowMe(string type)
		{
			m_getData=type;
			this.Show();
		}
		public string m_getData
		{
			set
			{
				strType=value;
			}
			get
			{
				return strType;
			}
		}
		private void frmIatricalReport_Load(object sender, System.EventArgs e)
		{
			startDate.Value=Convert.ToDateTime(startDate.Value.Year.ToString()+"-"+startDate.Value.Month.ToString()+"-"+"01");
			DataTable dtAll=new DataTable();
			clsDomainControl_Register domain=new clsDomainControl_Register();
			domain.m_lngReturnAllBALANCEEMP(out dtAll);
			m_CboSeleChargeMan.Item.Add("全部","All");
			if(dtAll.Rows.Count>0)
			{
				for(int i1=0;i1<dtAll.Rows.Count;i1++)
				{
					m_CboSeleChargeMan.Item.Add(dtAll.Rows[i1]["LASTNAME_VCHR"].ToString(),dtAll.Rows[i1]["BALANCEEMP_CHR"].ToString());
				}
			}
			m_CboSeleChargeMan.SelectedIndex=0;
		}

		private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			((clsControlIatricalReport)this.objController).m_getData();
		}

		private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			((clsControlIatricalReport)this.objController).printPageFS(e);
		}

		private void btnFind_Click(object sender, System.EventArgs e)
		{
			printPreviewControl1.Document=printDocument1;
		}

		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			printDocument1.Print();
		}

		private void btnEsc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void m_CboSeleChargeMan_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			printPreviewControl1.Document=printDocument1;
		}
	}
}
