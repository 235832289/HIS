using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmPatientDebtReport 的摘要说明。
	/// </summary>
	public class frmPatientDebtReport : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
	{
		internal CrystalDecisions.Windows.Forms.CrystalReportViewer m_ctrvPatientDebtReport;
		private PinkieControls.ButtonXP m_cmdStat;
		internal System.Windows.Forms.DateTimePicker m_StatDate;
		internal System.Windows.Forms.ListView lsvAreaInfo;
		internal System.Windows.Forms.ColumnHeader ColumnNum;
		private System.Windows.Forms.ColumnHeader ColumnName;
		internal System.Windows.Forms.TextBox m_txtAREAID_CHR;
		private System.Windows.Forms.Label label1;
		internal System.Windows.Forms.RadioButton radioButton1;
		internal System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.Label label2;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmPatientDebtReport()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			#region 临时控件
			//			//Dept
			//			lsvDeptInfo = new ListView();
			//			this.lsvDeptInfo.DoubleClick += new System.EventHandler(this.lsvDeptInfo_DoubleClick);
			//			this.lsvDeptInfo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsvDeptInfo_KeyDown);
			//			this.lsvDeptInfo.Leave += new System.EventHandler(this.lsvDeptInfo_Leave);
			//Area
			lsvAreaInfo = new ListView();
			this.lsvAreaInfo.DoubleClick += new System.EventHandler(this.lsvAreaInfo_DoubleClick);
			this.lsvAreaInfo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsvAreaInfo_KeyDown);
			this.lsvAreaInfo.Leave += new System.EventHandler(this.lsvAreaInfo_Leave);
			#endregion
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
			this.m_ctrvPatientDebtReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.m_StatDate = new System.Windows.Forms.DateTimePicker();
			this.m_cmdStat = new PinkieControls.ButtonXP();
			this.m_txtAREAID_CHR = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// m_ctrvPatientDebtReport
			// 
			this.m_ctrvPatientDebtReport.ActiveViewIndex = -1;
			this.m_ctrvPatientDebtReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_ctrvPatientDebtReport.DisplayGroupTree = false;
			this.m_ctrvPatientDebtReport.Location = new System.Drawing.Point(0, 48);
			this.m_ctrvPatientDebtReport.Name = "m_ctrvPatientDebtReport";
			this.m_ctrvPatientDebtReport.ReportSource = null;
			this.m_ctrvPatientDebtReport.Size = new System.Drawing.Size(872, 476);
			this.m_ctrvPatientDebtReport.TabIndex = 0;
			// 
			// m_StatDate
			// 
			this.m_StatDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_StatDate.Location = new System.Drawing.Point(76, 12);
			this.m_StatDate.Name = "m_StatDate";
			this.m_StatDate.Size = new System.Drawing.Size(136, 23);
			this.m_StatDate.TabIndex = 2;
			this.m_StatDate.Visible = false;
			// 
			// m_cmdStat
			// 
			this.m_cmdStat.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdStat.DefaultScheme = true;
			this.m_cmdStat.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdStat.Hint = "";
			this.m_cmdStat.Location = new System.Drawing.Point(520, 4);
			this.m_cmdStat.Name = "m_cmdStat";
			this.m_cmdStat.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdStat.Size = new System.Drawing.Size(104, 32);
			this.m_cmdStat.TabIndex = 3;
			this.m_cmdStat.Text = "统计(&F)";
			this.m_cmdStat.Click += new System.EventHandler(this.m_cmdStat_Click);
			// 
			// m_txtAREAID_CHR
			// 
			this.m_txtAREAID_CHR.Location = new System.Drawing.Point(108, 12);
			this.m_txtAREAID_CHR.Name = "m_txtAREAID_CHR";
			this.m_txtAREAID_CHR.Size = new System.Drawing.Size(140, 23);
			this.m_txtAREAID_CHR.TabIndex = 1;
			this.m_txtAREAID_CHR.Text = "";
			this.m_txtAREAID_CHR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtAREAID_CHR_KeyDown);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(28, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 23);
			this.label1.TabIndex = 4;
			this.label1.Text = "住院病区:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// radioButton1
			// 
			this.radioButton1.Checked = true;
			this.radioButton1.Location = new System.Drawing.Point(264, 12);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(120, 24);
			this.radioButton1.TabIndex = 5;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "在院病人";
			// 
			// radioButton2
			// 
			this.radioButton2.Location = new System.Drawing.Point(384, 12);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(116, 24);
			this.radioButton2.TabIndex = 6;
			this.radioButton2.Text = "出院病人";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(32, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(44, 23);
			this.label2.TabIndex = 7;
			this.label2.Text = "日期:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// frmPatientDebtReport
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(872, 521);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.radioButton2);
			this.Controls.Add(this.radioButton1);
			this.Controls.Add(this.m_txtAREAID_CHR);
			this.Controls.Add(this.m_cmdStat);
			this.Controls.Add(this.m_StatDate);
			this.Controls.Add(this.m_ctrvPatientDebtReport);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.Name = "frmPatientDebtReport";
			this.Text = "病区病人欠费一览表";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtAREAID_CHR_KeyDown);
			this.Load += new System.EventHandler(this.frmPatientDebtReport_Load);
			this.ResumeLayout(false);

		}
		#endregion
		public override void CreateController()
		{
			this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_PatientDebtReport();
			objController.Set_GUI_Apperance(this);
		}

		private void m_cmdStat_Click(object sender, System.EventArgs e)
		{
			((clsCtl_PatientDebtReport)objController).m_mthShowInHospitalDebtLog();
			this.m_txtAREAID_CHR.Focus();
		}
		#region 病区查找
		private void lsvAreaInfo_DoubleClick(object sender, System.EventArgs e)
		{
			if(this.lsvAreaInfo.SelectedItems.Count>0)
			{
				this.m_txtAREAID_CHR.Text = this.lsvAreaInfo.SelectedItems[0].SubItems[1].Text;
				if(this.lsvAreaInfo.SelectedItems[0].Index == 0)
				{
					this.m_txtAREAID_CHR.Tag="";
				}
				else
				{
					this.m_txtAREAID_CHR.Tag = ((com.digitalwave.iCare.ValueObject.clsT_BSE_DEPTDESC_VO)this.lsvAreaInfo.SelectedItems[0].Tag).m_strDEPTID_CHR;
				}
				this.lsvAreaInfo.Visible = false;
			}
		}
		private void lsvAreaInfo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				lsvAreaInfo_DoubleClick(null,null);
			}
		}
		private void lsvAreaInfo_Leave(object sender, System.EventArgs e)
		{
			this.lsvAreaInfo.Visible = false;
		}
		#endregion

		private void m_txtAREAID_CHR_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				#region 控件处理

				#region 病区编号	glzhang	2005.07.29
				this.ColumnNum = new System.Windows.Forms.ColumnHeader();
				this.ColumnNum.Text = "病区编号";
				this.ColumnNum.Width = 80;
				#endregion

				this.ColumnName = new System.Windows.Forms.ColumnHeader();
				this.ColumnName.Text = "病区名称";
				this.ColumnName.Width = 120;
				this.lsvAreaInfo.Size = new System.Drawing.Size(220, 144);
				
				this.lsvAreaInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							  ColumnNum,this.ColumnName});
				this.lsvAreaInfo.View = System.Windows.Forms.View.Details;
				this.lsvAreaInfo.FullRowSelect = true;
				this.lsvAreaInfo.GridLines = true;
				((clsCtl_PatientDebtReport)this.objController).LoadAreaID();
				if(lsvAreaInfo.Items.Count<1)
					return;
				if(lsvAreaInfo.Items.Count==1)
				{
					this.lsvAreaInfo.Items[0].Selected = true;
					this.m_txtAREAID_CHR.Text = this.lsvAreaInfo.Items[0].SubItems[1].Text;
					this.m_txtAREAID_CHR.Tag = ((com.digitalwave.iCare.ValueObject.clsT_BSE_DEPTDESC_VO)this.lsvAreaInfo.Items[0].Tag).m_strDEPTID_CHR;
					return;
				}
				this.Controls.Add(this.lsvAreaInfo);
				this.lsvAreaInfo.Location =new  System.Drawing.Point(110,35);
				#endregion
				this.lsvAreaInfo.Items[0].Selected = true;
				this.lsvAreaInfo.Show();
				this.lsvAreaInfo.BringToFront();
				this.lsvAreaInfo.Focus();
			}
		}

		private void frmPatientDebtReport_Load(object sender, System.EventArgs e)
		{
			this.m_txtAREAID_CHR.Focus();
		}
	}
}
