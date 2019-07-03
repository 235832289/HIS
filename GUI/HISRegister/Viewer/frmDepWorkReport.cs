using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmReckoningReport 的摘要说明。
	/// </summary>
	public class frmDepWorkReport: com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		internal CrystalDecisions.Windows.Forms.CrystalReportViewer cryReportViewer;
		internal PinkieControls.ButtonXP m_btnQulReg;
		internal System.Windows.Forms.DateTimePicker m_daFinDate;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label1;
		internal System.Windows.Forms.DateTimePicker m_daFinDateLast;
		internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtDepID;
		internal System.Windows.Forms.CheckBox m_chbPatienName;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmDepWorkReport()
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
			this.cryReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.m_btnQulReg = new PinkieControls.ButtonXP();
			this.m_daFinDate = new System.Windows.Forms.DateTimePicker();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.m_daFinDateLast = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.m_txtDepID = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.m_chbPatienName = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// cryReportViewer
			// 
			this.cryReportViewer.ActiveViewIndex = -1;
			this.cryReportViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.cryReportViewer.DisplayGroupTree = false;
			this.cryReportViewer.DockPadding.Bottom = 5;
			this.cryReportViewer.Location = new System.Drawing.Point(8, 32);
			this.cryReportViewer.Name = "cryReportViewer";
			this.cryReportViewer.ReportSource = null;
			this.cryReportViewer.Size = new System.Drawing.Size(816, 408);
			this.cryReportViewer.TabIndex = 59;
			// 
			// m_btnQulReg
			// 
			this.m_btnQulReg.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnQulReg.DefaultScheme = true;
			this.m_btnQulReg.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnQulReg.Hint = "";
			this.m_btnQulReg.Location = new System.Drawing.Point(728, 24);
			this.m_btnQulReg.Name = "m_btnQulReg";
			this.m_btnQulReg.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnQulReg.Size = new System.Drawing.Size(64, 24);
			this.m_btnQulReg.TabIndex = 58;
			this.m_btnQulReg.Text = "确定";
			this.m_btnQulReg.Click += new System.EventHandler(this.m_btnQulReg_Click);
			// 
			// m_daFinDate
			// 
			this.m_daFinDate.Location = new System.Drawing.Point(368, 24);
			this.m_daFinDate.Name = "m_daFinDate";
			this.m_daFinDate.Size = new System.Drawing.Size(128, 23);
			this.m_daFinDate.TabIndex = 60;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.m_txtDepID);
			this.groupBox1.Controls.Add(this.m_chbPatienName);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.m_daFinDateLast);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.m_btnQulReg);
			this.groupBox1.Controls.Add(this.m_daFinDate);
			this.groupBox1.Location = new System.Drawing.Point(8, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(832, 56);
			this.groupBox1.TabIndex = 61;
			this.groupBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(520, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(20, 19);
			this.label1.TabIndex = 65;
			this.label1.Text = "至";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_daFinDateLast
			// 
			this.m_daFinDateLast.Location = new System.Drawing.Point(560, 24);
			this.m_daFinDateLast.Name = "m_daFinDateLast";
			this.m_daFinDateLast.Size = new System.Drawing.Size(128, 23);
			this.m_daFinDateLast.TabIndex = 64;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(288, 28);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(70, 19);
			this.label2.TabIndex = 63;
			this.label2.Text = "统计日期:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.cryReportViewer);
			this.groupBox2.Location = new System.Drawing.Point(8, 64);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(832, 448);
			this.groupBox2.TabIndex = 62;
			this.groupBox2.TabStop = false;
			// 
			// m_txtDepID
			// 
			this.m_txtDepID.EnableAutoValidation = true;
			this.m_txtDepID.EnableEnterKeyValidate = true;
			this.m_txtDepID.EnableEscapeKeyUndo = true;
			this.m_txtDepID.EnableLastValidValue = true;
			this.m_txtDepID.ErrorProvider = null;
			this.m_txtDepID.ErrorProviderMessage = "Invalid value";
			this.m_txtDepID.ForceFormatText = true;
			this.m_txtDepID.Location = new System.Drawing.Point(112, 24);
			this.m_txtDepID.MaxLength = 20;
			this.m_txtDepID.Name = "m_txtDepID";
			this.m_txtDepID.Size = new System.Drawing.Size(104, 23);
			this.m_txtDepID.TabIndex = 69;
			this.m_txtDepID.Text = "";
			// 
			// m_chbPatienName
			// 
			this.m_chbPatienName.Location = new System.Drawing.Point(16, 24);
			this.m_chbPatienName.Name = "m_chbPatienName";
			this.m_chbPatienName.Size = new System.Drawing.Size(96, 24);
			this.m_chbPatienName.TabIndex = 68;
			this.m_chbPatienName.Text = "科室编号:";
			this.m_chbPatienName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// frmDepWorkReport
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(848, 517);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.Name = "frmDepWorkReport";
			this.Text = "门诊科室工作量报表";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override void CreateController()
		{
			this.objController=new com.digitalwave.iCare.gui.HIS.clsControlDepWorkReport();
			objController.Set_GUI_Apperance(this);
		}

		private void m_btnQulReg_Click(object sender, System.EventArgs e)
		{
			((clsControlDepWorkReport)this.objController).m_mthFindByDateReport();
		}

		
		private void m_cboReport_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		}


	}
}
