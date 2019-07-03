using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using PinkieControls;//PinkieControls.dll

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmOPInvoiceReturn1 的摘要说明。
	/// </summary>
	public class frmOPInvoiceReturn1 : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		internal System.Windows.Forms.TextBox m_txtSEQID_CHR;
		private System.Windows.Forms.Label label1;
		internal System.Windows.Forms.TextBox m_txtINVOICENO_VCHR;
		private PinkieControls.ButtonXP cmdReturn;
		internal System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		internal CrystalDecisions.Windows.Forms.CrystalReportViewer m_repInvoiceInfo;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		internal System.Windows.Forms.ListView m_lstItemsInfo;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmOPInvoiceReturn1()
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.m_txtSEQID_CHR = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.m_txtINVOICENO_VCHR = new System.Windows.Forms.TextBox();
			this.cmdReturn = new PinkieControls.ButtonXP();
			this.m_repInvoiceInfo = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.m_lstItemsInfo = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.groupBox1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.m_txtSEQID_CHR);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.m_txtINVOICENO_VCHR);
			this.groupBox1.Controls.Add(this.cmdReturn);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.ForeColor = System.Drawing.SystemColors.Highlight;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(680, 64);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "项目信息";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.ForeColor = System.Drawing.Color.Gray;
			this.label3.Location = new System.Drawing.Point(339, 31);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(110, 17);
			this.label3.TabIndex = 11;
			this.label3.Text = "[如: 20040101001]";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(181, 31);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(54, 17);
			this.label2.TabIndex = 3;
			this.label2.Text = "物理号：";
			// 
			// m_txtSEQID_CHR
			// 
			this.m_txtSEQID_CHR.Location = new System.Drawing.Point(239, 27);
			this.m_txtSEQID_CHR.Name = "m_txtSEQID_CHR";
			this.m_txtSEQID_CHR.TabIndex = 2;
			this.m_txtSEQID_CHR.Text = "";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(11, 31);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(54, 17);
			this.label1.TabIndex = 1;
			this.label1.Text = "发票号：";
			// 
			// m_txtINVOICENO_VCHR
			// 
			this.m_txtINVOICENO_VCHR.Location = new System.Drawing.Point(69, 27);
			this.m_txtINVOICENO_VCHR.Name = "m_txtINVOICENO_VCHR";
			this.m_txtINVOICENO_VCHR.TabIndex = 0;
			this.m_txtINVOICENO_VCHR.Text = "";
			// 
			// cmdReturn
			// 
			this.cmdReturn.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(216)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.cmdReturn.DefaultScheme = true;
			this.cmdReturn.DialogResult = System.Windows.Forms.DialogResult.None;
			this.cmdReturn.Hint = "";
			this.cmdReturn.Location = new System.Drawing.Point(509, 20);
			this.cmdReturn.Name = "cmdReturn";
			this.cmdReturn.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.cmdReturn.Size = new System.Drawing.Size(120, 32);
			this.cmdReturn.TabIndex = 10;
			this.cmdReturn.Text = "退 回 发 票[F4]";
			this.cmdReturn.Click += new System.EventHandler(this.cmdReturn_Click);
			// 
			// m_repInvoiceInfo
			// 
			this.m_repInvoiceInfo.ActiveViewIndex = -1;
			this.m_repInvoiceInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_repInvoiceInfo.DisplayGroupTree = false;
			this.m_repInvoiceInfo.DisplayToolbar = false;
			this.m_repInvoiceInfo.Location = new System.Drawing.Point(0, 16);
			this.m_repInvoiceInfo.Name = "m_repInvoiceInfo";
			this.m_repInvoiceInfo.ReportSource = null;
			this.m_repInvoiceInfo.Size = new System.Drawing.Size(672, 328);
			this.m_repInvoiceInfo.TabIndex = 9;
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(0, 80);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(680, 368);
			this.tabControl1.TabIndex = 10;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.m_repInvoiceInfo);
			this.tabPage1.Location = new System.Drawing.Point(4, 21);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(672, 343);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "tabPage1";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.m_lstItemsInfo);
			this.tabPage2.Location = new System.Drawing.Point(4, 21);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(672, 343);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "tabPage2";
			// 
			// m_lstItemsInfo
			// 
			this.m_lstItemsInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							 this.columnHeader1,
																							 this.columnHeader2,
																							 this.columnHeader3,
																							 this.columnHeader4});
			this.m_lstItemsInfo.Dock = System.Windows.Forms.DockStyle.Left;
			this.m_lstItemsInfo.FullRowSelect = true;
			this.m_lstItemsInfo.GridLines = true;
			this.m_lstItemsInfo.HideSelection = false;
			this.m_lstItemsInfo.Location = new System.Drawing.Point(0, 0);
			this.m_lstItemsInfo.MultiSelect = false;
			this.m_lstItemsInfo.Name = "m_lstItemsInfo";
			this.m_lstItemsInfo.Size = new System.Drawing.Size(664, 343);
			this.m_lstItemsInfo.TabIndex = 10;
			this.m_lstItemsInfo.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "";
			this.columnHeader1.Width = 156;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "助记码";
			this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader2.Width = 154;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "用法名称";
			this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader3.Width = 148;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Width = 135;
			// 
			// frmOPInvoiceReturn1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(680, 453);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.groupBox1);
			this.Name = "frmOPInvoiceReturn1";
			this.Text = "frmOPInvoiceReturn1";
			this.groupBox1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override void CreateController()
		{
			this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_OPInvoiceReturn();
			objController.Set_GUI_Apperance(this);
		}

		private void cmdReturn_Click(object sender, System.EventArgs e)
		{
//					com.digitalwave.iCare.middletier.HI.clsCalcPatientCharge obj=new com.digitalwave.iCare.middletier.HI.clsCalcPatientCharge("",1,this.objController.m_objComInfo.m_strGetHospitalTitle(),0,100);
//					obj.m_mthGetChargeItemByInvoiceID( m_txtINVOICENO_VCHR.Text.Trim(),this.m_lstItemsInfo,"1");
//					m_repInvoiceInfo.ReportSource=obj.m_mthPrintChargePreview(m_txtINVOICENO_VCHR.Text.Trim(),"1",out this.objPC);
			
		}
	}
}
