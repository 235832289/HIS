using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmShowCaseHistory 的摘要说明。
	/// </summary>
	public class frmShowCaseHistory : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Splitter splitter1;
		private com.digitalwave.controls.Control.MyPrintPreViewControl myPrintPreViewControl1;
		private System.Drawing.Printing.PrintDocument printDocument1;
		internal System.Windows.Forms.Panel panel2;
		internal System.Windows.Forms.Label label1;
		internal PinkieControls.ButtonXP btReConsultation;
		internal PinkieControls.ButtonXP btPrint;
		internal PinkieControls.ButtonXP btExit;
		public System.Windows.Forms.TreeView treeView1;
		internal PinkieControls.ButtonXP btReUse;
		private PinkieControls.ButtonXP btnReUseAll;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmShowCaseHistory()
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
		
		private int m_intStat = 0;
		/// <summary>
		/// //0: 默认 1: 复诊 2: 复用病历 3: 复用病历和处方
		/// </summary>
		public int m_IntStat
		{
			get
			{
				return m_intStat;
			}
			set
			{
				m_intStat = value;
			}
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.panel1 = new System.Windows.Forms.Panel();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnReUseAll = new PinkieControls.ButtonXP();
			this.btReUse = new PinkieControls.ButtonXP();
			this.btExit = new PinkieControls.ButtonXP();
			this.btPrint = new PinkieControls.ButtonXP();
			this.btReConsultation = new PinkieControls.ButtonXP();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.myPrintPreViewControl1 = new com.digitalwave.controls.Control.MyPrintPreViewControl();
			this.printDocument1 = new System.Drawing.Printing.PrintDocument();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.treeView1);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(176, 597);
			this.panel1.TabIndex = 0;
			// 
			// treeView1
			// 
			this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView1.ImageIndex = -1;
			this.treeView1.Location = new System.Drawing.Point(0, 28);
			this.treeView1.Name = "treeView1";
			this.treeView1.SelectedImageIndex = -1;
			this.treeView1.Size = new System.Drawing.Size(172, 565);
			this.treeView1.TabIndex = 2;
			this.treeView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView1_KeyDown);
			this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.label1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(172, 28);
			this.panel2.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(160, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "病 历 列 表";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnReUseAll);
			this.groupBox1.Controls.Add(this.btReUse);
			this.groupBox1.Controls.Add(this.btExit);
			this.groupBox1.Controls.Add(this.btPrint);
			this.groupBox1.Controls.Add(this.btReConsultation);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.groupBox1.Location = new System.Drawing.Point(176, 529);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(732, 68);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			// 
			// btnReUseAll
			// 
			this.btnReUseAll.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btnReUseAll.DefaultScheme = true;
			this.btnReUseAll.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btnReUseAll.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btnReUseAll.Hint = "";
			this.btnReUseAll.Location = new System.Drawing.Point(308, 24);
			this.btnReUseAll.Name = "btnReUseAll";
			this.btnReUseAll.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.btnReUseAll.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btnReUseAll.Size = new System.Drawing.Size(118, 32);
			this.btnReUseAll.TabIndex = 14;
			this.btnReUseAll.Text = "复用病历及处方";
			this.btnReUseAll.Click += new System.EventHandler(this.btnReUseAll_Click);
			// 
			// btReUse
			// 
			this.btReUse.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btReUse.DefaultScheme = true;
			this.btReUse.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btReUse.Hint = "";
			this.btReUse.Location = new System.Drawing.Point(164, 24);
			this.btReUse.Name = "btReUse";
			this.btReUse.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.btReUse.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btReUse.Size = new System.Drawing.Size(104, 32);
			this.btReUse.TabIndex = 13;
			this.btReUse.Text = "复用病历(&U)";
			this.btReUse.Click += new System.EventHandler(this.btReUse_Click);
			// 
			// btExit
			// 
			this.btExit.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btExit.DefaultScheme = true;
			this.btExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btExit.Hint = "";
			this.btExit.Location = new System.Drawing.Point(606, 24);
			this.btExit.Name = "btExit";
			this.btExit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.btExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btExit.Size = new System.Drawing.Size(100, 32);
			this.btExit.TabIndex = 12;
			this.btExit.Text = "退出(ESC)";
			this.btExit.Click += new System.EventHandler(this.btExit_Click);
			// 
			// btPrint
			// 
			this.btPrint.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btPrint.DefaultScheme = true;
			this.btPrint.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btPrint.Hint = "";
			this.btPrint.Location = new System.Drawing.Point(466, 24);
			this.btPrint.Name = "btPrint";
			this.btPrint.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.btPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btPrint.Size = new System.Drawing.Size(100, 32);
			this.btPrint.TabIndex = 11;
			this.btPrint.Text = "打印(&P)";
			this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
			// 
			// btReConsultation
			// 
			this.btReConsultation.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btReConsultation.DefaultScheme = true;
			this.btReConsultation.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btReConsultation.Hint = "";
			this.btReConsultation.Location = new System.Drawing.Point(24, 24);
			this.btReConsultation.Name = "btReConsultation";
			this.btReConsultation.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.btReConsultation.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btReConsultation.Size = new System.Drawing.Size(100, 32);
			this.btReConsultation.TabIndex = 10;
			this.btReConsultation.Text = "复诊(&R)";
			this.btReConsultation.Click += new System.EventHandler(this.btReConsultation_Click);
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(176, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 529);
			this.splitter1.TabIndex = 2;
			this.splitter1.TabStop = false;
			// 
			// myPrintPreViewControl1
			// 
			this.myPrintPreViewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.myPrintPreViewControl1.Document = this.printDocument1;
			this.myPrintPreViewControl1.Location = new System.Drawing.Point(179, 0);
			this.myPrintPreViewControl1.Name = "myPrintPreViewControl1";
			this.myPrintPreViewControl1.ReportName = "";
			this.myPrintPreViewControl1.ShowPannel = false;
			this.myPrintPreViewControl1.ShowPrintButton = true;
			this.myPrintPreViewControl1.Size = new System.Drawing.Size(729, 529);
			this.myPrintPreViewControl1.TabIndex = 3;
			// 
			// printDocument1
			// 
			this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
			this.printDocument1.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_EndPrint);
			this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
			// 
			// frmShowCaseHistory
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.CancelButton = this.btExit;
			this.ClientSize = new System.Drawing.Size(908, 597);
			this.Controls.Add(this.myPrintPreViewControl1);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.Name = "frmShowCaseHistory";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "查看病历";
			this.Load += new System.EventHandler(this.frmShowCaseHistory_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		public override void CreateController()
		{
			this.objController=new com.digitalwave.iCare.gui.HIS.clsCtl_ShowCaseHistory();
			objController.Set_GUI_Apperance(this);
		}
		private void btExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btPrint_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.printDocument1.Print();
			}
			catch
			{
				MessageBox.Show("对不起,打印出错");
			}
		}

		private void btReConsultation_Click(object sender, System.EventArgs e)
		{
			if(this.treeView1.Tag!=null)
			{
				m_intStat = 1;	
				this.DialogResult =DialogResult.OK;
			}			
		}

		private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			((clsCtl_ShowCaseHistory)this.objController).m_mthPrint(e);
		}

		private void frmShowCaseHistory_Load(object sender, System.EventArgs e)
		{
			this.Text+="　─  "+this.PatientName+"\t红色为复诊病历";
			((clsCtl_ShowCaseHistory)this.objController).m_mthLoadCaseHistoryInfo();
            btnReUseAll.Visible = false;
            btExit.Location = btPrint.Location;
            btPrint.Location = btnReUseAll.Location;
		}
		public string PatientID
		{
			set
			{
			this.label1.Tag =value;
			}
			get
			{
			return this.label1.Tag.ToString();
			}
		}
		private string strPatientSex="";
		public string PatientSex
		{
			set
			{
				strPatientSex =value;
			}
			get
			{
				return strPatientSex;
			}
		}
		private string strPatientAge="";
		public string PatientAge
		{
			set
			{
				strPatientAge =value;
			}
			get
			{
				return strPatientAge;
			}
		}
		private string strPatientCardID ="";
		public string PatientCardID
		{
			set
			{
				strPatientCardID =value;
			}
			get
			{
				return strPatientCardID;
			}
		}
		private string strPatientName ="";

		private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
//			if(this.listBox1.SelectedItems.Count>0)
//			{
		
//			}
		}

		private void treeView1_DoubleClick(object sender, System.EventArgs e)
		{
			if(this.treeView1.SelectedNode.Tag!=null)
			{
				this.treeView1.Tag =this.treeView1.SelectedNode.Tag;
				this.myPrintPreViewControl1.Document =this.printDocument1;
				
			}
		
			
		}

		

		private void treeView1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				if(this.treeView1.SelectedNode.Tag!=null)
				{
					this.treeView1.Tag =this.treeView1.SelectedNode.Tag;
					this.myPrintPreViewControl1.Document =this.printDocument1;				
				}
			}
		}

		private void btReUse_Click(object sender, System.EventArgs e)
		{
			if(this.treeView1.Tag!=null)
			{
				m_intStat = 2;
				this.DialogResult =DialogResult.OK;
			}
		}

		private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			((clsCtl_ShowCaseHistory)this.objController).m_mthBeginPrint();
		}

		private void printDocument1_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
		((clsCtl_ShowCaseHistory)this.objController).m_mthEndPrint();
		}

		private void btnReUseAll_Click(object sender, System.EventArgs e)
		{
			if(this.treeView1.Tag != null)
			{
				m_intStat = 3;
				this.DialogResult =DialogResult.OK;
			}
		}
	
		public string PatientName
		{
			set
			{
				strPatientName =value;
			}
			get
			{
				return strPatientName;
			}
		}
		public 	clsOutpatientPrintCaseHis_VO CaseHistoryInfo
		{
			get
			{
				if(this.treeView1.Tag==null)
				{
					return null;
				}
				else
				{
				return (clsOutpatientPrintCaseHis_VO)this.treeView1.Tag;
				}
			}
		}
	}
}
