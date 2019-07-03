using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmPatientChargedetail 的摘要说明。
	/// </summary>
	public class frmPatientChargedetail : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		internal CrystalDecisions.Windows.Forms.CrystalReportViewer m_crvPatientCharheDetail;
		internal System.Windows.Forms.ListView lsvAreaInfo;
		private System.Windows.Forms.ColumnHeader ColumnName;
		private System.Windows.Forms.ColumnHeader ColumnNum;
		internal System.Windows.Forms.PrintDialog printDialog;
		private System.Drawing.Printing.PrintDocument printDocument1;
		private System.Windows.Forms.GroupBox groupBox2;
		internal System.Windows.Forms.TextBox m_txtInhospitalDate;
		private System.Windows.Forms.Label label10;
		internal System.Windows.Forms.TextBox m_txtBirthDay;
		private System.Windows.Forms.Label label9;
		internal System.Windows.Forms.TextBox m_txtInsuranceNo;
		private System.Windows.Forms.Label label8;
		internal System.Windows.Forms.TextBox m_txtPayType;
		private System.Windows.Forms.Label label7;
		internal System.Windows.Forms.TextBox m_txtSex;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		internal System.Windows.Forms.TextBox m_txtPatientName;
		private System.Windows.Forms.GroupBox groupBox3;
		private PinkieControls.ButtonXP m_cmdQuery;
		private PinkieControls.ButtonXP m_txtStat;
		internal System.Windows.Forms.ComboBox m_cboChargeType;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label15;
		internal System.Windows.Forms.DateTimePicker m_dtpStatDate;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label3;
		internal System.Windows.Forms.ComboBox m_cboBedNo;
		internal System.Windows.Forms.TextBox m_txtAREAID_CHR;
		private System.Windows.Forms.Label label4;
		internal System.Windows.Forms.TextBox m_txtInpatientNo;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		internal System.Windows.Forms.TextBox m_txtPatientCard;
		internal System.Windows.Forms.RadioButton radioButton1;
		internal System.Windows.Forms.RadioButton radioButton2;
		internal System.Windows.Forms.RadioButton radioButton3;
		internal System.Windows.Forms.DateTimePicker m_dtpEnd;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmPatientChargedetail()
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
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.label3 = new System.Windows.Forms.Label();
			this.m_cboBedNo = new System.Windows.Forms.ComboBox();
			this.m_txtAREAID_CHR = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.m_txtInpatientNo = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.m_txtPatientCard = new System.Windows.Forms.TextBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.m_dtpEnd = new System.Windows.Forms.DateTimePicker();
			this.m_cmdQuery = new PinkieControls.ButtonXP();
			this.m_txtStat = new PinkieControls.ButtonXP();
			this.m_cboChargeType = new System.Windows.Forms.ComboBox();
			this.label16 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.m_dtpStatDate = new System.Windows.Forms.DateTimePicker();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.m_txtInhospitalDate = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.m_txtBirthDay = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.m_txtInsuranceNo = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.m_txtPayType = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.m_txtSex = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.m_txtPatientName = new System.Windows.Forms.TextBox();
			this.m_crvPatientCharheDetail = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.printDialog = new System.Windows.Forms.PrintDialog();
			this.printDocument1 = new System.Drawing.Printing.PrintDocument();
			this.groupBox4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.radioButton3);
			this.groupBox4.Controls.Add(this.radioButton2);
			this.groupBox4.Controls.Add(this.radioButton1);
			this.groupBox4.Controls.Add(this.label3);
			this.groupBox4.Controls.Add(this.m_cboBedNo);
			this.groupBox4.Controls.Add(this.m_txtAREAID_CHR);
			this.groupBox4.Controls.Add(this.label4);
			this.groupBox4.Controls.Add(this.m_txtInpatientNo);
			this.groupBox4.Controls.Add(this.label2);
			this.groupBox4.Controls.Add(this.label1);
			this.groupBox4.Controls.Add(this.m_txtPatientCard);
			this.groupBox4.Location = new System.Drawing.Point(4, 0);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(628, 76);
			this.groupBox4.TabIndex = 21;
			this.groupBox4.TabStop = false;
			// 
			// radioButton3
			// 
			this.radioButton3.Location = new System.Drawing.Point(204, 44);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(112, 28);
			this.radioButton3.TabIndex = 29;
			this.radioButton3.Text = "床号查询";
			this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
			// 
			// radioButton2
			// 
			this.radioButton2.Location = new System.Drawing.Point(512, 44);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(112, 24);
			this.radioButton2.TabIndex = 28;
			this.radioButton2.Text = "住院号查询";
			this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
			// 
			// radioButton1
			// 
			this.radioButton1.Location = new System.Drawing.Point(512, 19);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(112, 24);
			this.radioButton1.TabIndex = 27;
			this.radioButton1.Text = "卡号查询";
			this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(320, 20);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(68, 23);
			this.label3.TabIndex = 23;
			this.label3.Text = "诊疗卡号";
			// 
			// m_cboBedNo
			// 
			this.m_cboBedNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboBedNo.Location = new System.Drawing.Point(84, 48);
			this.m_cboBedNo.Name = "m_cboBedNo";
			this.m_cboBedNo.Size = new System.Drawing.Size(112, 22);
			this.m_cboBedNo.TabIndex = 21;
			// 
			// m_txtAREAID_CHR
			// 
			this.m_txtAREAID_CHR.AutoSize = false;
			this.m_txtAREAID_CHR.Location = new System.Drawing.Point(84, 20);
			this.m_txtAREAID_CHR.MaxLength = 20;
			this.m_txtAREAID_CHR.Name = "m_txtAREAID_CHR";
			this.m_txtAREAID_CHR.ReadOnly = true;
			this.m_txtAREAID_CHR.Size = new System.Drawing.Size(108, 24);
			this.m_txtAREAID_CHR.TabIndex = 1;
			this.m_txtAREAID_CHR.Text = "";
			this.m_txtAREAID_CHR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtAREAID_CHR_KeyDown);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(320, 48);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(68, 23);
			this.label4.TabIndex = 24;
			this.label4.Text = "住院号";
			// 
			// m_txtInpatientNo
			// 
			this.m_txtInpatientNo.Location = new System.Drawing.Point(400, 44);
			this.m_txtInpatientNo.MaxLength = 12;
			this.m_txtInpatientNo.Name = "m_txtInpatientNo";
			this.m_txtInpatientNo.ReadOnly = true;
			this.m_txtInpatientNo.Size = new System.Drawing.Size(108, 23);
			this.m_txtInpatientNo.TabIndex = 26;
			this.m_txtInpatientNo.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 23);
			this.label2.TabIndex = 22;
			this.label2.Text = "病床";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 23);
			this.label1.TabIndex = 20;
			this.label1.Text = "病区";
			// 
			// m_txtPatientCard
			// 
			this.m_txtPatientCard.Location = new System.Drawing.Point(400, 16);
			this.m_txtPatientCard.MaxLength = 10;
			this.m_txtPatientCard.Name = "m_txtPatientCard";
			this.m_txtPatientCard.ReadOnly = true;
			this.m_txtPatientCard.Size = new System.Drawing.Size(108, 23);
			this.m_txtPatientCard.TabIndex = 25;
			this.m_txtPatientCard.Text = "";
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.m_dtpEnd);
			this.groupBox3.Controls.Add(this.m_cmdQuery);
			this.groupBox3.Controls.Add(this.m_txtStat);
			this.groupBox3.Controls.Add(this.m_cboChargeType);
			this.groupBox3.Controls.Add(this.label16);
			this.groupBox3.Controls.Add(this.label15);
			this.groupBox3.Controls.Add(this.m_dtpStatDate);
			this.groupBox3.Location = new System.Drawing.Point(636, 0);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(284, 144);
			this.groupBox3.TabIndex = 20;
			this.groupBox3.TabStop = false;
			// 
			// m_dtpEnd
			// 
			this.m_dtpEnd.Location = new System.Drawing.Point(94, 48);
			this.m_dtpEnd.Name = "m_dtpEnd";
			this.m_dtpEnd.Size = new System.Drawing.Size(168, 23);
			this.m_dtpEnd.TabIndex = 16;
			// 
			// m_cmdQuery
			// 
			this.m_cmdQuery.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdQuery.DefaultScheme = true;
			this.m_cmdQuery.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdQuery.Hint = "";
			this.m_cmdQuery.Location = new System.Drawing.Point(16, 100);
			this.m_cmdQuery.Name = "m_cmdQuery";
			this.m_cmdQuery.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdQuery.Size = new System.Drawing.Size(114, 28);
			this.m_cmdQuery.TabIndex = 14;
			this.m_cmdQuery.Text = "查询病人(&F)";
			this.m_cmdQuery.Click += new System.EventHandler(this.m_cmdQuery_Click);
			// 
			// m_txtStat
			// 
			this.m_txtStat.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_txtStat.DefaultScheme = true;
			this.m_txtStat.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_txtStat.Hint = "";
			this.m_txtStat.Location = new System.Drawing.Point(152, 100);
			this.m_txtStat.Name = "m_txtStat";
			this.m_txtStat.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_txtStat.Size = new System.Drawing.Size(114, 28);
			this.m_txtStat.TabIndex = 12;
			this.m_txtStat.Text = "生成报表(&D)";
			this.m_txtStat.Click += new System.EventHandler(this.m_txtStat_Click);
			// 
			// m_cboChargeType
			// 
			this.m_cboChargeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboChargeType.Location = new System.Drawing.Point(94, 76);
			this.m_cboChargeType.Name = "m_cboChargeType";
			this.m_cboChargeType.Size = new System.Drawing.Size(168, 22);
			this.m_cboChargeType.TabIndex = 11;
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(18, 76);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(72, 23);
			this.label16.TabIndex = 10;
			this.label16.Text = "费用类别";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(18, 20);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(68, 23);
			this.label15.TabIndex = 9;
			this.label15.Text = "统计日期";
			// 
			// m_dtpStatDate
			// 
			this.m_dtpStatDate.Location = new System.Drawing.Point(94, 20);
			this.m_dtpStatDate.Name = "m_dtpStatDate";
			this.m_dtpStatDate.Size = new System.Drawing.Size(168, 23);
			this.m_dtpStatDate.TabIndex = 8;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.m_txtInhospitalDate);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.m_txtBirthDay);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.m_txtInsuranceNo);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.m_txtPayType);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.m_txtSex);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.m_txtPatientName);
			this.groupBox2.Location = new System.Drawing.Point(4, 72);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(628, 72);
			this.groupBox2.TabIndex = 19;
			this.groupBox2.TabStop = false;
			// 
			// m_txtInhospitalDate
			// 
			this.m_txtInhospitalDate.Location = new System.Drawing.Point(466, 44);
			this.m_txtInhospitalDate.MaxLength = 20;
			this.m_txtInhospitalDate.Name = "m_txtInhospitalDate";
			this.m_txtInhospitalDate.Size = new System.Drawing.Size(152, 23);
			this.m_txtInhospitalDate.TabIndex = 31;
			this.m_txtInhospitalDate.Text = "";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(374, 44);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(88, 23);
			this.label10.TabIndex = 30;
			this.label10.Text = "入院日期";
			// 
			// m_txtBirthDay
			// 
			this.m_txtBirthDay.Location = new System.Drawing.Point(466, 16);
			this.m_txtBirthDay.MaxLength = 20;
			this.m_txtBirthDay.Name = "m_txtBirthDay";
			this.m_txtBirthDay.Size = new System.Drawing.Size(152, 23);
			this.m_txtBirthDay.TabIndex = 29;
			this.m_txtBirthDay.Text = "";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(374, 16);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(88, 23);
			this.label9.TabIndex = 28;
			this.label9.Text = "出生年月";
			// 
			// m_txtInsuranceNo
			// 
			this.m_txtInsuranceNo.Location = new System.Drawing.Point(262, 44);
			this.m_txtInsuranceNo.MaxLength = 20;
			this.m_txtInsuranceNo.Name = "m_txtInsuranceNo";
			this.m_txtInsuranceNo.Size = new System.Drawing.Size(108, 23);
			this.m_txtInsuranceNo.TabIndex = 27;
			this.m_txtInsuranceNo.Text = "";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(194, 44);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(68, 23);
			this.label8.TabIndex = 26;
			this.label8.Text = "社保号";
			// 
			// m_txtPayType
			// 
			this.m_txtPayType.Location = new System.Drawing.Point(90, 44);
			this.m_txtPayType.MaxLength = 25;
			this.m_txtPayType.Name = "m_txtPayType";
			this.m_txtPayType.TabIndex = 25;
			this.m_txtPayType.Text = "";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(14, 44);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(72, 23);
			this.label7.TabIndex = 24;
			this.label7.Text = "病人身份";
			// 
			// m_txtSex
			// 
			this.m_txtSex.Location = new System.Drawing.Point(262, 16);
			this.m_txtSex.MaxLength = 10;
			this.m_txtSex.Name = "m_txtSex";
			this.m_txtSex.Size = new System.Drawing.Size(108, 23);
			this.m_txtSex.TabIndex = 23;
			this.m_txtSex.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(194, 16);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(68, 23);
			this.label6.TabIndex = 22;
			this.label6.Text = "性别";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(14, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 23);
			this.label5.TabIndex = 21;
			this.label5.Text = "病人姓名";
			// 
			// m_txtPatientName
			// 
			this.m_txtPatientName.Location = new System.Drawing.Point(90, 16);
			this.m_txtPatientName.MaxLength = 20;
			this.m_txtPatientName.Name = "m_txtPatientName";
			this.m_txtPatientName.TabIndex = 20;
			this.m_txtPatientName.Text = "";
			// 
			// m_crvPatientCharheDetail
			// 
			this.m_crvPatientCharheDetail.ActiveViewIndex = -1;
			this.m_crvPatientCharheDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_crvPatientCharheDetail.DisplayGroupTree = false;
			this.m_crvPatientCharheDetail.Location = new System.Drawing.Point(0, 144);
			this.m_crvPatientCharheDetail.Name = "m_crvPatientCharheDetail";
			this.m_crvPatientCharheDetail.ReportSource = null;
			this.m_crvPatientCharheDetail.Size = new System.Drawing.Size(928, 400);
			this.m_crvPatientCharheDetail.TabIndex = 9;
			// 
			// frmPatientChargedetail
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(932, 545);
			this.Controls.Add(this.m_crvPatientCharheDetail);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.Name = "frmPatientChargedetail";
			this.Text = "病人收费项目明细";
			this.Load += new System.EventHandler(this.frmPatientChargedetail_Load);
			this.groupBox4.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		public override void CreateController()
		{
			this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_PatientDailyChargeDetail();
			objController.Set_GUI_Apperance(this);
		}
		#region 病区查找
		private void lsvAreaInfo_DoubleClick(object sender, System.EventArgs e)
		{
			if(this.lsvAreaInfo.SelectedItems.Count>0)
			{
				this.m_txtAREAID_CHR.Text = this.lsvAreaInfo.SelectedItems[0].SubItems[1].Text;
				this.m_txtAREAID_CHR.Tag = ((com.digitalwave.iCare.ValueObject.clsT_BSE_DEPTDESC_VO)this.lsvAreaInfo.SelectedItems[0].Tag).m_strDEPTID_CHR;
				this.lsvAreaInfo.Visible = false;
				((clsCtl_PatientDailyChargeDetail)this.objController).Addm_cboBed();
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

				#region		病区编号
				this.ColumnNum = new System.Windows.Forms.ColumnHeader();
				this.ColumnNum.Text = "病区编号";
				this.ColumnNum.Width = 80;
				#endregion

				this.ColumnName = new System.Windows.Forms.ColumnHeader();
				this.ColumnName.Text = "病区名称";
				this.ColumnName.Width = 120;
				this.lsvAreaInfo.Size = new System.Drawing.Size(200, 144);
				
				this.lsvAreaInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							  ColumnNum,this.ColumnName});
				this.lsvAreaInfo.View = System.Windows.Forms.View.Details;
				this.lsvAreaInfo.FullRowSelect = true;
				this.lsvAreaInfo.GridLines = true;
				((clsCtl_PatientDailyChargeDetail)this.objController).LoadAreaID();
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
				this.lsvAreaInfo.Location =new  System.Drawing.Point(88,44);
				#endregion
				this.lsvAreaInfo.Items[0].Selected = true;
				this.lsvAreaInfo.Show();
				this.lsvAreaInfo.BringToFront();
				this.lsvAreaInfo.Items[0].Selected = true;
				this.lsvAreaInfo.Focus();
			}
		}

		private void m_cmdQuery_Click(object sender, System.EventArgs e)
		{
			if(radioButton2.Checked)
			{
				if(m_txtInpatientNo.Text.Length<12 && m_txtInpatientNo.Text.Length!=0)
				{
					m_txtInpatientNo.Text=m_txtInpatientNo.Text.PadLeft(12,'0');
				}
			}
			((clsCtl_PatientDailyChargeDetail)this.objController).GetPatientDebtInfo();
		}

		private void frmPatientChargedetail_Load(object sender, System.EventArgs e)
		{
			((clsCtl_PatientDailyChargeDetail)this.objController).GetGroup();
			this.radioButton3.Checked = true;
		}

		private void m_txtStat_Click(object sender, System.EventArgs e)
		{
			((clsCtl_PatientDailyChargeDetail)this.objController).m_mthShowInHospitalAdviceCharge();
		}

		private void m_cmdPrint_Click(object sender, System.EventArgs e)
		{
			((clsCtl_PatientDailyChargeDetail)this.objController).Print();
		}

		private void m_txtCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void radioButton3_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.radioButton3.Checked==true)
			{
				this.m_txtAREAID_CHR.ReadOnly = false;
				this.m_cboBedNo.Enabled = true;
			}
			else
			{
				this.m_txtAREAID_CHR.ReadOnly = false;
				this.m_cboBedNo.Enabled = false;
			}
		}

		private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.radioButton1.Checked == true)
			{
				this.m_txtPatientCard.ReadOnly = false;
			}
			else
			{
				this.m_txtPatientCard.ReadOnly = true;
			}
		}

		private void radioButton2_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.radioButton2.Checked== true)
			{
				this.m_txtInpatientNo.ReadOnly = false;
			}
			else
			{
				this.m_txtInpatientNo.ReadOnly = true;
			}
		}
	}
}
