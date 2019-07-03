using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace iCare
{
	/// <summary>
    /// 佛山市第二人民医院检验报告单(已作废)
	/// </summary>
	public class frmCheckReport : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label2;
		protected System.Windows.Forms.Label lblSex;
		protected System.Windows.Forms.Label lblAge;
		protected System.Windows.Forms.Label lblSexTitle;
		protected System.Windows.Forms.Label lblAgeTitle;
		protected System.Windows.Forms.Label lblNameTitle;
		protected System.Windows.Forms.ListView m_lsvPatientName;
		private System.Windows.Forms.ColumnHeader clmPatientName_BaseForm;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtPatientName;
		protected System.Windows.Forms.Label lblSampleIDTitle;
		protected System.Windows.Forms.Label lblSampleID;
		protected System.Windows.Forms.Label lblDeptName;
		protected System.Windows.Forms.Label lblDeptNameTitle;
		protected System.Windows.Forms.Label lblBedNoTitle;
		protected System.Windows.Forms.Label lblBedNo;
		protected System.Windows.Forms.Label lblInPatientIDTitle;
		protected System.Windows.Forms.Label lblInPatientID;
		protected System.Windows.Forms.Label lblPat_I_nameTitle;
		protected System.Windows.Forms.Label lblPat_I_name;
		protected System.Windows.Forms.Label lblPat_doct;
		protected System.Windows.Forms.Label lblPat_doctTitle;
		protected System.Windows.Forms.Label lblPat_chk;
		protected System.Windows.Forms.Label lblPat_chkTitle;
		protected System.Windows.Forms.Label lblPat_diagTitle;
		protected System.Windows.Forms.Label lblPat_diag;
		protected System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader clmPat_c_name;
		private System.Windows.Forms.ColumnHeader clmResult;
		private System.Windows.Forms.ColumnHeader clmUnit;
		private System.Windows.Forms.ColumnHeader clmRefrenceValue;
		protected System.Windows.Forms.Label lblSendDateTitle;
		protected System.Windows.Forms.Label lblSendDate;
		protected System.Windows.Forms.Label lblReportDate;
		protected System.Windows.Forms.Label lblReportDateTitle;
		protected System.Windows.Forms.Label lblSendDate2;
		protected System.Windows.Forms.Label lblSendDateTitle2;
		protected System.Windows.Forms.Label lblReportDateTitle2;
		protected System.Windows.Forms.Label lblReportDate2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmCheckReport()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmCheckReport));
			this.label2 = new System.Windows.Forms.Label();
			this.lblSex = new System.Windows.Forms.Label();
			this.lblAge = new System.Windows.Forms.Label();
			this.lblSexTitle = new System.Windows.Forms.Label();
			this.lblAgeTitle = new System.Windows.Forms.Label();
			this.lblSampleIDTitle = new System.Windows.Forms.Label();
			this.lblSampleID = new System.Windows.Forms.Label();
			this.lblNameTitle = new System.Windows.Forms.Label();
			this.m_lsvPatientName = new System.Windows.Forms.ListView();
			this.clmPatientName_BaseForm = new System.Windows.Forms.ColumnHeader();
			this.m_txtPatientName = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.lblDeptName = new System.Windows.Forms.Label();
			this.lblDeptNameTitle = new System.Windows.Forms.Label();
			this.lblBedNoTitle = new System.Windows.Forms.Label();
			this.lblBedNo = new System.Windows.Forms.Label();
			this.lblInPatientIDTitle = new System.Windows.Forms.Label();
			this.lblInPatientID = new System.Windows.Forms.Label();
			this.lblPat_I_nameTitle = new System.Windows.Forms.Label();
			this.lblPat_I_name = new System.Windows.Forms.Label();
			this.lblPat_doct = new System.Windows.Forms.Label();
			this.lblPat_doctTitle = new System.Windows.Forms.Label();
			this.lblPat_chk = new System.Windows.Forms.Label();
			this.lblPat_chkTitle = new System.Windows.Forms.Label();
			this.lblPat_diagTitle = new System.Windows.Forms.Label();
			this.lblPat_diag = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.listView1 = new System.Windows.Forms.ListView();
			this.clmPat_c_name = new System.Windows.Forms.ColumnHeader();
			this.clmResult = new System.Windows.Forms.ColumnHeader();
			this.clmUnit = new System.Windows.Forms.ColumnHeader();
			this.clmRefrenceValue = new System.Windows.Forms.ColumnHeader();
			this.lblSendDateTitle = new System.Windows.Forms.Label();
			this.lblSendDate = new System.Windows.Forms.Label();
			this.lblReportDate = new System.Windows.Forms.Label();
			this.lblReportDateTitle = new System.Windows.Forms.Label();
			this.lblSendDate2 = new System.Windows.Forms.Label();
			this.lblSendDateTitle2 = new System.Windows.Forms.Label();
			this.lblReportDateTitle2 = new System.Windows.Forms.Label();
			this.lblReportDate2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("SimSun", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.Location = new System.Drawing.Point(216, 28);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(500, 44);
			this.label2.TabIndex = 204;
			this.label2.Text = "佛山市第二人民医院检验报告单";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblSex
			// 
			this.lblSex.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblSex.Location = new System.Drawing.Point(404, 116);
			this.lblSex.Name = "lblSex";
			this.lblSex.Size = new System.Drawing.Size(48, 19);
			this.lblSex.TabIndex = 502;
			// 
			// lblAge
			// 
			this.lblAge.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblAge.Location = new System.Drawing.Point(516, 116);
			this.lblAge.Name = "lblAge";
			this.lblAge.Size = new System.Drawing.Size(52, 19);
			this.lblAge.TabIndex = 501;
			// 
			// lblSexTitle
			// 
			this.lblSexTitle.AutoSize = true;
			this.lblSexTitle.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblSexTitle.Location = new System.Drawing.Point(352, 116);
			this.lblSexTitle.Name = "lblSexTitle";
			this.lblSexTitle.Size = new System.Drawing.Size(47, 19);
			this.lblSexTitle.TabIndex = 500;
			this.lblSexTitle.Text = "性别:";
			// 
			// lblAgeTitle
			// 
			this.lblAgeTitle.AutoSize = true;
			this.lblAgeTitle.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblAgeTitle.Location = new System.Drawing.Point(460, 116);
			this.lblAgeTitle.Name = "lblAgeTitle";
			this.lblAgeTitle.Size = new System.Drawing.Size(47, 19);
			this.lblAgeTitle.TabIndex = 499;
			this.lblAgeTitle.Text = "年龄:";
			// 
			// lblSampleIDTitle
			// 
			this.lblSampleIDTitle.AutoSize = true;
			this.lblSampleIDTitle.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblSampleIDTitle.Location = new System.Drawing.Point(600, 116);
			this.lblSampleIDTitle.Name = "lblSampleIDTitle";
			this.lblSampleIDTitle.Size = new System.Drawing.Size(63, 19);
			this.lblSampleIDTitle.TabIndex = 499;
			this.lblSampleIDTitle.Text = "样本号:";
			// 
			// lblSampleID
			// 
			this.lblSampleID.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblSampleID.Location = new System.Drawing.Point(672, 116);
			this.lblSampleID.Name = "lblSampleID";
			this.lblSampleID.Size = new System.Drawing.Size(76, 19);
			this.lblSampleID.TabIndex = 501;
			// 
			// lblNameTitle
			// 
			this.lblNameTitle.AutoSize = true;
			this.lblNameTitle.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblNameTitle.Location = new System.Drawing.Point(136, 116);
			this.lblNameTitle.Name = "lblNameTitle";
			this.lblNameTitle.Size = new System.Drawing.Size(47, 19);
			this.lblNameTitle.TabIndex = 503;
			this.lblNameTitle.Text = "姓名:";
			// 
			// m_lsvPatientName
			// 
			this.m_lsvPatientName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_lsvPatientName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_lsvPatientName.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							   this.clmPatientName_BaseForm});
			this.m_lsvPatientName.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lsvPatientName.ForeColor = System.Drawing.Color.White;
			this.m_lsvPatientName.FullRowSelect = true;
			this.m_lsvPatientName.GridLines = true;
			this.m_lsvPatientName.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lsvPatientName.Location = new System.Drawing.Point(188, 140);
			this.m_lsvPatientName.Name = "m_lsvPatientName";
			this.m_lsvPatientName.Size = new System.Drawing.Size(100, 104);
			this.m_lsvPatientName.TabIndex = 505;
			this.m_lsvPatientName.View = System.Windows.Forms.View.Details;
			// 
			// clmPatientName_BaseForm
			// 
			this.clmPatientName_BaseForm.Width = 97;
			// 
			// m_txtPatientName
			// 
			this.m_txtPatientName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtPatientName.BorderColor = System.Drawing.Color.White;
			this.m_txtPatientName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtPatientName.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtPatientName.ForeColor = System.Drawing.Color.White;
			this.m_txtPatientName.Location = new System.Drawing.Point(188, 112);
			this.m_txtPatientName.Name = "m_txtPatientName";
			this.m_txtPatientName.TabIndex = 504;
			this.m_txtPatientName.Text = "";
			// 
			// lblDeptName
			// 
			this.lblDeptName.AutoSize = true;
			this.lblDeptName.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblDeptName.Location = new System.Drawing.Point(188, 152);
			this.lblDeptName.Name = "lblDeptName";
			this.lblDeptName.Size = new System.Drawing.Size(88, 19);
			this.lblDeptName.TabIndex = 502;
			this.lblDeptName.Text = "          ";
			// 
			// lblDeptNameTitle
			// 
			this.lblDeptNameTitle.AutoSize = true;
			this.lblDeptNameTitle.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblDeptNameTitle.Location = new System.Drawing.Point(136, 152);
			this.lblDeptNameTitle.Name = "lblDeptNameTitle";
			this.lblDeptNameTitle.Size = new System.Drawing.Size(47, 19);
			this.lblDeptNameTitle.TabIndex = 500;
			this.lblDeptNameTitle.Text = "科别:";
			// 
			// lblBedNoTitle
			// 
			this.lblBedNoTitle.AutoSize = true;
			this.lblBedNoTitle.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblBedNoTitle.Location = new System.Drawing.Point(352, 152);
			this.lblBedNoTitle.Name = "lblBedNoTitle";
			this.lblBedNoTitle.Size = new System.Drawing.Size(47, 19);
			this.lblBedNoTitle.TabIndex = 506;
			this.lblBedNoTitle.Text = "床号:";
			// 
			// lblBedNo
			// 
			this.lblBedNo.AutoSize = true;
			this.lblBedNo.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblBedNo.Location = new System.Drawing.Point(408, 152);
			this.lblBedNo.Name = "lblBedNo";
			this.lblBedNo.Size = new System.Drawing.Size(39, 19);
			this.lblBedNo.TabIndex = 506;
			this.lblBedNo.Text = "    ";
			// 
			// lblInPatientIDTitle
			// 
			this.lblInPatientIDTitle.AutoSize = true;
			this.lblInPatientIDTitle.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblInPatientIDTitle.Location = new System.Drawing.Point(464, 152);
			this.lblInPatientIDTitle.Name = "lblInPatientIDTitle";
			this.lblInPatientIDTitle.Size = new System.Drawing.Size(63, 19);
			this.lblInPatientIDTitle.TabIndex = 506;
			this.lblInPatientIDTitle.Text = "病历号:";
			// 
			// lblInPatientID
			// 
			this.lblInPatientID.AutoSize = true;
			this.lblInPatientID.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblInPatientID.Location = new System.Drawing.Point(532, 152);
			this.lblInPatientID.Name = "lblInPatientID";
			this.lblInPatientID.Size = new System.Drawing.Size(39, 19);
			this.lblInPatientID.TabIndex = 506;
			this.lblInPatientID.Text = "    ";
			// 
			// lblPat_I_nameTitle
			// 
			this.lblPat_I_nameTitle.AutoSize = true;
			this.lblPat_I_nameTitle.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblPat_I_nameTitle.Location = new System.Drawing.Point(604, 152);
			this.lblPat_I_nameTitle.Name = "lblPat_I_nameTitle";
			this.lblPat_I_nameTitle.Size = new System.Drawing.Size(63, 19);
			this.lblPat_I_nameTitle.TabIndex = 506;
			this.lblPat_I_nameTitle.Text = "检验者:";
			// 
			// lblPat_I_name
			// 
			this.lblPat_I_name.AutoSize = true;
			this.lblPat_I_name.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblPat_I_name.Location = new System.Drawing.Point(672, 152);
			this.lblPat_I_name.Name = "lblPat_I_name";
			this.lblPat_I_name.Size = new System.Drawing.Size(39, 19);
			this.lblPat_I_name.TabIndex = 506;
			this.lblPat_I_name.Text = "    ";
			// 
			// lblPat_doct
			// 
			this.lblPat_doct.AutoSize = true;
			this.lblPat_doct.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblPat_doct.Location = new System.Drawing.Point(536, 188);
			this.lblPat_doct.Name = "lblPat_doct";
			this.lblPat_doct.Size = new System.Drawing.Size(39, 19);
			this.lblPat_doct.TabIndex = 506;
			this.lblPat_doct.Text = "    ";
			// 
			// lblPat_doctTitle
			// 
			this.lblPat_doctTitle.AutoSize = true;
			this.lblPat_doctTitle.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblPat_doctTitle.Location = new System.Drawing.Point(468, 188);
			this.lblPat_doctTitle.Name = "lblPat_doctTitle";
			this.lblPat_doctTitle.Size = new System.Drawing.Size(63, 19);
			this.lblPat_doctTitle.TabIndex = 506;
			this.lblPat_doctTitle.Text = "送检者:";
			// 
			// lblPat_chk
			// 
			this.lblPat_chk.AutoSize = true;
			this.lblPat_chk.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblPat_chk.Location = new System.Drawing.Point(676, 188);
			this.lblPat_chk.Name = "lblPat_chk";
			this.lblPat_chk.Size = new System.Drawing.Size(39, 19);
			this.lblPat_chk.TabIndex = 506;
			this.lblPat_chk.Text = "    ";
			// 
			// lblPat_chkTitle
			// 
			this.lblPat_chkTitle.AutoSize = true;
			this.lblPat_chkTitle.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblPat_chkTitle.Location = new System.Drawing.Point(608, 188);
			this.lblPat_chkTitle.Name = "lblPat_chkTitle";
			this.lblPat_chkTitle.Size = new System.Drawing.Size(63, 19);
			this.lblPat_chkTitle.TabIndex = 506;
			this.lblPat_chkTitle.Text = "审核者:";
			// 
			// lblPat_diagTitle
			// 
			this.lblPat_diagTitle.AutoSize = true;
			this.lblPat_diagTitle.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblPat_diagTitle.Location = new System.Drawing.Point(136, 192);
			this.lblPat_diagTitle.Name = "lblPat_diagTitle";
			this.lblPat_diagTitle.Size = new System.Drawing.Size(47, 19);
			this.lblPat_diagTitle.TabIndex = 500;
			this.lblPat_diagTitle.Text = "诊断:";
			// 
			// lblPat_diag
			// 
			this.lblPat_diag.AutoSize = true;
			this.lblPat_diag.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblPat_diag.Location = new System.Drawing.Point(188, 192);
			this.lblPat_diag.Name = "lblPat_diag";
			this.lblPat_diag.Size = new System.Drawing.Size(88, 19);
			this.lblPat_diag.TabIndex = 502;
			this.lblPat_diag.Text = "          ";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(424, 80);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 19);
			this.label1.TabIndex = 502;
			this.label1.Text = "(组合名称)";
			// 
			// listView1
			// 
			this.listView1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.clmPat_c_name,
																						this.clmResult,
																						this.clmUnit,
																						this.clmRefrenceValue});
			this.listView1.ForeColor = System.Drawing.SystemColors.Window;
			this.listView1.GridLines = true;
			this.listView1.Location = new System.Drawing.Point(48, 224);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(770, 285);
			this.listView1.TabIndex = 507;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// clmPat_c_name
			// 
			this.clmPat_c_name.Text = "组合名称";
			this.clmPat_c_name.Width = 300;
			// 
			// clmResult
			// 
			this.clmResult.Text = "结果";
			this.clmResult.Width = 150;
			// 
			// clmUnit
			// 
			this.clmUnit.Text = "单位";
			this.clmUnit.Width = 70;
			// 
			// clmRefrenceValue
			// 
			this.clmRefrenceValue.Text = "参考值";
			this.clmRefrenceValue.Width = 250;
			// 
			// lblSendDateTitle
			// 
			this.lblSendDateTitle.AutoSize = true;
			this.lblSendDateTitle.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblSendDateTitle.Location = new System.Drawing.Point(48, 524);
			this.lblSendDateTitle.Name = "lblSendDateTitle";
			this.lblSendDateTitle.Size = new System.Drawing.Size(80, 19);
			this.lblSendDateTitle.TabIndex = 506;
			this.lblSendDateTitle.Text = "送检日期:";
			// 
			// lblSendDate
			// 
			this.lblSendDate.AutoSize = true;
			this.lblSendDate.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblSendDate.Location = new System.Drawing.Point(132, 524);
			this.lblSendDate.Name = "lblSendDate";
			this.lblSendDate.Size = new System.Drawing.Size(39, 19);
			this.lblSendDate.TabIndex = 506;
			this.lblSendDate.Text = "    ";
			// 
			// lblReportDate
			// 
			this.lblReportDate.AutoSize = true;
			this.lblReportDate.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblReportDate.Location = new System.Drawing.Point(540, 524);
			this.lblReportDate.Name = "lblReportDate";
			this.lblReportDate.Size = new System.Drawing.Size(39, 19);
			this.lblReportDate.TabIndex = 506;
			this.lblReportDate.Text = "    ";
			// 
			// lblReportDateTitle
			// 
			this.lblReportDateTitle.AutoSize = true;
			this.lblReportDateTitle.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblReportDateTitle.Location = new System.Drawing.Point(456, 524);
			this.lblReportDateTitle.Name = "lblReportDateTitle";
			this.lblReportDateTitle.Size = new System.Drawing.Size(80, 19);
			this.lblReportDateTitle.TabIndex = 506;
			this.lblReportDateTitle.Text = "报告日期:";
			// 
			// lblSendDate2
			// 
			this.lblSendDate2.AutoSize = true;
			this.lblSendDate2.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblSendDate2.Location = new System.Drawing.Point(356, 524);
			this.lblSendDate2.Name = "lblSendDate2";
			this.lblSendDate2.Size = new System.Drawing.Size(39, 19);
			this.lblSendDate2.TabIndex = 506;
			this.lblSendDate2.Text = "    ";
			// 
			// lblSendDateTitle2
			// 
			this.lblSendDateTitle2.AutoSize = true;
			this.lblSendDateTitle2.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblSendDateTitle2.Location = new System.Drawing.Point(272, 524);
			this.lblSendDateTitle2.Name = "lblSendDateTitle2";
			this.lblSendDateTitle2.Size = new System.Drawing.Size(80, 19);
			this.lblSendDateTitle2.TabIndex = 506;
			this.lblSendDateTitle2.Text = "送检时间:";
			// 
			// lblReportDateTitle2
			// 
			this.lblReportDateTitle2.AutoSize = true;
			this.lblReportDateTitle2.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblReportDateTitle2.Location = new System.Drawing.Point(660, 524);
			this.lblReportDateTitle2.Name = "lblReportDateTitle2";
			this.lblReportDateTitle2.Size = new System.Drawing.Size(80, 19);
			this.lblReportDateTitle2.TabIndex = 506;
			this.lblReportDateTitle2.Text = "报告日期:";
			// 
			// lblReportDate2
			// 
			this.lblReportDate2.AutoSize = true;
			this.lblReportDate2.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblReportDate2.Location = new System.Drawing.Point(744, 524);
			this.lblReportDate2.Name = "lblReportDate2";
			this.lblReportDate2.Size = new System.Drawing.Size(39, 19);
			this.lblReportDate2.TabIndex = 506;
			this.lblReportDate2.Text = "    ";
			// 
			// frmCheckReport
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(10, 22);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.ClientSize = new System.Drawing.Size(876, 561);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.listView1,
																		  this.lblBedNoTitle,
																		  this.m_lsvPatientName,
																		  this.m_txtPatientName,
																		  this.lblNameTitle,
																		  this.lblSex,
																		  this.lblAge,
																		  this.lblSexTitle,
																		  this.lblAgeTitle,
																		  this.label2,
																		  this.lblSampleIDTitle,
																		  this.lblSampleID,
																		  this.lblDeptName,
																		  this.lblDeptNameTitle,
																		  this.lblBedNo,
																		  this.lblInPatientIDTitle,
																		  this.lblInPatientID,
																		  this.lblPat_I_nameTitle,
																		  this.lblPat_I_name,
																		  this.lblPat_doct,
																		  this.lblPat_doctTitle,
																		  this.lblPat_chk,
																		  this.lblPat_chkTitle,
																		  this.lblPat_diagTitle,
																		  this.lblPat_diag,
																		  this.label1,
																		  this.lblSendDateTitle,
																		  this.lblSendDate,
																		  this.lblReportDate,
																		  this.lblReportDateTitle,
																		  this.lblSendDate2,
																		  this.lblSendDateTitle2,
																		  this.lblReportDateTitle2,
																		  this.lblReportDate2});
			this.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.ForeColor = System.Drawing.SystemColors.Window;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmCheckReport";
			this.Text = "佛山市第二人民医院检验报告单";
			this.Load += new System.EventHandler(this.frmCheckReport_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmCheckReport_Load(object sender, System.EventArgs e)
		{
			m_txtPatientName.Focus();
		}
	}
}
