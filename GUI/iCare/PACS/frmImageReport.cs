using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using com.digitalwave.Utility.Controls;
using System.Windows.Forms;
using iCareData;
namespace iCare
{
	/// <summary>
	/// 谢桂军.2003-12-22
	/// </summary>
	public class frmImageReport : iCare.frmHRPBaseForm
	{
		private System.Windows.Forms.Label lblCheckName;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox txtCheckName;
		private System.Windows.Forms.ListView lsvCheckRecord;
		private System.Windows.Forms.Label lblCheckRecord;
		private System.Windows.Forms.Label lblReportDateTime;
		private com.digitalwave.Utility.Controls.ctlTimePicker dtpReportDateTime;
		private System.Windows.Forms.Label lblReportorName;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox txtReportorName;
		private System.Windows.Forms.Label lblApplicationID;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox txtApplicationID;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader clmPatientName_BaseForm;
		protected System.Windows.Forms.ListView lsvApplicationID;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.Label lblReportDesc;
		private System.Windows.Forms.Label lblReportDiagnose;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox txtReportDesc;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox txtReportDiagnose;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox txtReportCheckPart;
		private System.Windows.Forms.Label lblReportCheckPart;
		private System.Windows.Forms.Button m_cmdShowPACS;
		private System.ComponentModel.IContainer components = null;

		public frmImageReport()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

            //m_objBorderTool = new clsBorderTool(Color.White);
            //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{this.lsvCheckRecord});

			this.m_EnmFormEditStatus = MDIParent.enmFormEditStatus.None;
		}

        //private clsBorderTool m_objBorderTool;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
                //m_objBorderTool = null;
				m_objSelectedPatient = null;
				m_ImageReportArr = null;
				mImageReportDomain = null;
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblCheckName = new System.Windows.Forms.Label();
			this.txtCheckName = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.lsvCheckRecord = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.lblCheckRecord = new System.Windows.Forms.Label();
			this.lblReportDesc = new System.Windows.Forms.Label();
			this.lblReportDiagnose = new System.Windows.Forms.Label();
			this.lblReportDateTime = new System.Windows.Forms.Label();
			this.dtpReportDateTime = new com.digitalwave.Utility.Controls.ctlTimePicker();
			this.lblReportorName = new System.Windows.Forms.Label();
			this.txtReportorName = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.lblApplicationID = new System.Windows.Forms.Label();
			this.txtApplicationID = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.txtReportDesc = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.txtReportDiagnose = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.lsvApplicationID = new System.Windows.Forms.ListView();
			this.clmPatientName_BaseForm = new System.Windows.Forms.ColumnHeader();
			this.lblReportCheckPart = new System.Windows.Forms.Label();
			this.txtReportCheckPart = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_cmdShowPACS = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// m_lblForTitle
			// 
			this.m_lblForTitle.Location = new System.Drawing.Point(322, 16);
			this.m_lblForTitle.Text = "影像报告单";
			this.m_lblForTitle.Visible = true;
			// 
			// lblSex
			// 
			this.lblSex.Location = new System.Drawing.Point(704, 154);
			this.lblSex.TabIndex = 4;
			this.lblSex.Visible = true;
			// 
			// lblAge
			// 
			this.lblAge.Location = new System.Drawing.Point(824, 152);
			this.lblAge.Size = new System.Drawing.Size(56, 22);
			this.lblAge.TabIndex = 5;
			this.lblAge.Visible = true;
			// 
			// lblBedNoTitle
			// 
			this.lblBedNoTitle.Location = new System.Drawing.Point(488, 114);
			this.lblBedNoTitle.Visible = true;
			// 
			// lblInHospitalNoTitle
			// 
			this.lblInHospitalNoTitle.Location = new System.Drawing.Point(660, 114);
			this.lblInHospitalNoTitle.Visible = true;
			// 
			// lblNameTitle
			// 
			this.lblNameTitle.Location = new System.Drawing.Point(488, 154);
			this.lblNameTitle.Visible = true;
			// 
			// lblSexTitle
			// 
			this.lblSexTitle.Location = new System.Drawing.Point(660, 154);
			this.lblSexTitle.Visible = true;
			// 
			// lblAgeTitle
			// 
			this.lblAgeTitle.Location = new System.Drawing.Point(768, 154);
			this.lblAgeTitle.Visible = true;
			// 
			// lblAreaTitle
			// 
			this.lblAreaTitle.Location = new System.Drawing.Point(88, 80);
			this.lblAreaTitle.Visible = true;
			// 
			// m_lsvInPatientID
			// 
			this.m_lsvInPatientID.Location = new System.Drawing.Point(728, 134);
			this.m_lsvInPatientID.Size = new System.Drawing.Size(96, 108);
			this.m_lsvInPatientID.Visible = true;
			// 
			// txtInPatientID
			// 
			this.txtInPatientID.Location = new System.Drawing.Point(726, 114);
			this.txtInPatientID.Size = new System.Drawing.Size(102, 19);
			this.txtInPatientID.TabIndex = 2;
			this.txtInPatientID.Visible = true;
			// 
			// m_txtPatientName
			// 
			this.m_txtPatientName.Location = new System.Drawing.Point(536, 154);
			this.m_txtPatientName.Size = new System.Drawing.Size(108, 21);
			this.m_txtPatientName.Visible = true;
			// 
			// m_txtBedNO
			// 
			this.m_txtBedNO.Location = new System.Drawing.Point(536, 114);
			this.m_txtBedNO.Size = new System.Drawing.Size(108, 21);
			this.m_txtBedNO.Visible = true;
			// 
			// m_cboArea
			// 
			this.m_cboArea.Location = new System.Drawing.Point(140, 76);
			this.m_cboArea.Visible = true;
			// 
			// m_lsvPatientName
			// 
			this.m_lsvPatientName.Location = new System.Drawing.Point(536, 176);
			this.m_lsvPatientName.Size = new System.Drawing.Size(92, 114);
			this.m_lsvPatientName.Visible = true;
			// 
			// m_lsvBedNO
			// 
			this.m_lsvBedNO.Location = new System.Drawing.Point(536, 134);
			this.m_lsvBedNO.Size = new System.Drawing.Size(90, 104);
			this.m_lsvBedNO.Visible = true;
			// 
			// m_cboDept
			// 
			this.m_cboDept.Location = new System.Drawing.Point(140, 40);
			this.m_cboDept.Visible = true;
			// 
			// lblDept
			// 
			this.lblDept.Location = new System.Drawing.Point(88, 48);
			this.lblDept.Visible = true;
			// 
			// lblCheckName
			// 
			this.lblCheckName.AllowDrop = true;
			this.lblCheckName.AutoSize = true;
			this.lblCheckName.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblCheckName.ForeColor = System.Drawing.Color.White;
			this.lblCheckName.Location = new System.Drawing.Point(454, 234);
			this.lblCheckName.Name = "lblCheckName";
			this.lblCheckName.Size = new System.Drawing.Size(80, 19);
			this.lblCheckName.TabIndex = 10000004;
			this.lblCheckName.Text = "检查名称:";
			this.lblCheckName.Visible = false;
			// 
			// txtCheckName
			// 
			this.txtCheckName.AccessibleDescription = "检查费";
			this.txtCheckName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.txtCheckName.BorderColor = System.Drawing.Color.White;
			this.txtCheckName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtCheckName.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtCheckName.ForeColor = System.Drawing.Color.White;
			this.txtCheckName.Location = new System.Drawing.Point(536, 232);
			this.txtCheckName.Name = "txtCheckName";
			this.txtCheckName.ReadOnly = true;
			this.txtCheckName.Size = new System.Drawing.Size(212, 26);
			this.txtCheckName.TabIndex = 300;
			this.txtCheckName.Text = "";
			this.txtCheckName.Visible = false;
			// 
			// lsvCheckRecord
			// 
			this.lsvCheckRecord.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.lsvCheckRecord.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lsvCheckRecord.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							 this.columnHeader1,
																							 this.columnHeader2,
																							 this.columnHeader3,
																							 this.columnHeader4});
			this.lsvCheckRecord.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lsvCheckRecord.ForeColor = System.Drawing.Color.White;
			this.lsvCheckRecord.FullRowSelect = true;
			this.lsvCheckRecord.GridLines = true;
			this.lsvCheckRecord.HideSelection = false;
			this.lsvCheckRecord.Location = new System.Drawing.Point(140, 112);
			this.lsvCheckRecord.MultiSelect = false;
			this.lsvCheckRecord.Name = "lsvCheckRecord";
			this.lsvCheckRecord.Size = new System.Drawing.Size(284, 158);
			this.lsvCheckRecord.TabIndex = 200;
			this.lsvCheckRecord.View = System.Windows.Forms.View.Details;
			this.lsvCheckRecord.SelectedIndexChanged += new System.EventHandler(this.lsvCheckRecord_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "申请日期";
			this.columnHeader1.Width = 165;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "类型";
			this.columnHeader2.Width = 50;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "报告";
			this.columnHeader3.Width = 65;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "";
			this.columnHeader4.Width = 0;
			// 
			// lblCheckRecord
			// 
			this.lblCheckRecord.AllowDrop = true;
			this.lblCheckRecord.AutoSize = true;
			this.lblCheckRecord.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblCheckRecord.ForeColor = System.Drawing.Color.White;
			this.lblCheckRecord.Location = new System.Drawing.Point(56, 112);
			this.lblCheckRecord.Name = "lblCheckRecord";
			this.lblCheckRecord.Size = new System.Drawing.Size(80, 19);
			this.lblCheckRecord.TabIndex = 10000006;
			this.lblCheckRecord.Text = "申请记录:";
			// 
			// lblReportDesc
			// 
			this.lblReportDesc.AllowDrop = true;
			this.lblReportDesc.AutoSize = true;
			this.lblReportDesc.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblReportDesc.ForeColor = System.Drawing.Color.White;
			this.lblReportDesc.Location = new System.Drawing.Point(56, 364);
			this.lblReportDesc.Name = "lblReportDesc";
			this.lblReportDesc.Size = new System.Drawing.Size(80, 19);
			this.lblReportDesc.TabIndex = 10000007;
			this.lblReportDesc.Text = "诊断描述:";
			// 
			// lblReportDiagnose
			// 
			this.lblReportDiagnose.AllowDrop = true;
			this.lblReportDiagnose.AutoSize = true;
			this.lblReportDiagnose.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblReportDiagnose.ForeColor = System.Drawing.Color.White;
			this.lblReportDiagnose.Location = new System.Drawing.Point(56, 480);
			this.lblReportDiagnose.Name = "lblReportDiagnose";
			this.lblReportDiagnose.Size = new System.Drawing.Size(80, 19);
			this.lblReportDiagnose.TabIndex = 10000008;
			this.lblReportDiagnose.Text = "诊断提示:";
			// 
			// lblReportDateTime
			// 
			this.lblReportDateTime.AutoSize = true;
			this.lblReportDateTime.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblReportDateTime.Location = new System.Drawing.Point(286, 594);
			this.lblReportDateTime.Name = "lblReportDateTime";
			this.lblReportDateTime.Size = new System.Drawing.Size(80, 19);
			this.lblReportDateTime.TabIndex = 10000012;
			this.lblReportDateTime.Text = "报告日期:";
			this.lblReportDateTime.Visible = false;
			// 
			// dtpReportDateTime
			// 
			this.dtpReportDateTime.BorderColor = System.Drawing.Color.White;
			this.dtpReportDateTime.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
			this.dtpReportDateTime.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.dtpReportDateTime.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.dtpReportDateTime.DropButtonForeColor = System.Drawing.Color.White;
			this.dtpReportDateTime.flatFont = new System.Drawing.Font("SimSun", 12F);
			this.dtpReportDateTime.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.dtpReportDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpReportDateTime.Location = new System.Drawing.Point(368, 592);
			this.dtpReportDateTime.m_BlnOnlyTime = false;
			this.dtpReportDateTime.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
			this.dtpReportDateTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
			this.dtpReportDateTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
			this.dtpReportDateTime.Name = "dtpReportDateTime";
			this.dtpReportDateTime.ReadOnly = true;
			this.dtpReportDateTime.Size = new System.Drawing.Size(212, 22);
			this.dtpReportDateTime.TabIndex = 700;
			this.dtpReportDateTime.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.dtpReportDateTime.TextForeColor = System.Drawing.Color.White;
			this.dtpReportDateTime.Visible = false;
			// 
			// lblReportorName
			// 
			this.lblReportorName.AutoSize = true;
			this.lblReportorName.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblReportorName.Location = new System.Drawing.Point(618, 594);
			this.lblReportorName.Name = "lblReportorName";
			this.lblReportorName.Size = new System.Drawing.Size(80, 19);
			this.lblReportorName.TabIndex = 10000014;
			this.lblReportorName.Text = "报告医生:";
			this.lblReportorName.Visible = false;
			// 
			// txtReportorName
			// 
			this.txtReportorName.AccessibleDescription = "检查费";
			this.txtReportorName.AccessibleName = "NoDefault";
			this.txtReportorName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.txtReportorName.BorderColor = System.Drawing.Color.White;
			this.txtReportorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtReportorName.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtReportorName.ForeColor = System.Drawing.Color.White;
			this.txtReportorName.Location = new System.Drawing.Point(702, 590);
			this.txtReportorName.Name = "txtReportorName";
			this.txtReportorName.ReadOnly = true;
			this.txtReportorName.Size = new System.Drawing.Size(174, 26);
			this.txtReportorName.TabIndex = 800;
			this.txtReportorName.Text = "";
			this.txtReportorName.Visible = false;
			// 
			// lblApplicationID
			// 
			this.lblApplicationID.AllowDrop = true;
			this.lblApplicationID.AutoSize = true;
			this.lblApplicationID.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblApplicationID.ForeColor = System.Drawing.Color.White;
			this.lblApplicationID.Location = new System.Drawing.Point(454, 192);
			this.lblApplicationID.Name = "lblApplicationID";
			this.lblApplicationID.Size = new System.Drawing.Size(80, 19);
			this.lblApplicationID.TabIndex = 10000017;
			this.lblApplicationID.Text = "申请单号:";
			// 
			// txtApplicationID
			// 
			this.txtApplicationID.AccessibleDescription = "检查费";
			this.txtApplicationID.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.txtApplicationID.BorderColor = System.Drawing.Color.White;
			this.txtApplicationID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtApplicationID.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtApplicationID.ForeColor = System.Drawing.Color.White;
			this.txtApplicationID.Location = new System.Drawing.Point(536, 190);
			this.txtApplicationID.Name = "txtApplicationID";
			this.txtApplicationID.Size = new System.Drawing.Size(108, 26);
			this.txtApplicationID.TabIndex = 6;
			this.txtApplicationID.Text = "";
			this.txtApplicationID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtApplicationID_KeyDown);
			this.txtApplicationID.Leave += new System.EventHandler(this.txtApplicationID_Leave);
			// 
			// txtReportDesc
			// 
			this.txtReportDesc.AccessibleDescription = "检查费";
			this.txtReportDesc.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.txtReportDesc.BorderColor = System.Drawing.Color.White;
			this.txtReportDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtReportDesc.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtReportDesc.ForeColor = System.Drawing.Color.White;
			this.txtReportDesc.Location = new System.Drawing.Point(140, 360);
			this.txtReportDesc.Multiline = true;
			this.txtReportDesc.Name = "txtReportDesc";
			this.txtReportDesc.ReadOnly = true;
			this.txtReportDesc.Size = new System.Drawing.Size(736, 102);
			this.txtReportDesc.TabIndex = 500;
			this.txtReportDesc.Text = "";
			// 
			// txtReportDiagnose
			// 
			this.txtReportDiagnose.AccessibleDescription = "检查费";
			this.txtReportDiagnose.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.txtReportDiagnose.BorderColor = System.Drawing.Color.White;
			this.txtReportDiagnose.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtReportDiagnose.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtReportDiagnose.ForeColor = System.Drawing.Color.White;
			this.txtReportDiagnose.Location = new System.Drawing.Point(140, 476);
			this.txtReportDiagnose.Multiline = true;
			this.txtReportDiagnose.Name = "txtReportDiagnose";
			this.txtReportDiagnose.ReadOnly = true;
			this.txtReportDiagnose.Size = new System.Drawing.Size(736, 106);
			this.txtReportDiagnose.TabIndex = 600;
			this.txtReportDiagnose.Text = "";
			// 
			// lsvApplicationID
			// 
			this.lsvApplicationID.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.lsvApplicationID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lsvApplicationID.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							   this.clmPatientName_BaseForm});
			this.lsvApplicationID.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lsvApplicationID.ForeColor = System.Drawing.Color.White;
			this.lsvApplicationID.FullRowSelect = true;
			this.lsvApplicationID.GridLines = true;
			this.lsvApplicationID.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lsvApplicationID.Location = new System.Drawing.Point(538, 218);
			this.lsvApplicationID.Name = "lsvApplicationID";
			this.lsvApplicationID.Size = new System.Drawing.Size(106, 104);
			this.lsvApplicationID.TabIndex = 10000018;
			this.lsvApplicationID.View = System.Windows.Forms.View.Details;
			this.lsvApplicationID.Visible = false;
			this.lsvApplicationID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsvApplicationID_KeyDown);
			this.lsvApplicationID.DoubleClick += new System.EventHandler(this.lsvApplicationID_DoubleClick);
			this.lsvApplicationID.Leave += new System.EventHandler(this.lsvApplicationID_Leave);
			this.lsvApplicationID.SelectedIndexChanged += new System.EventHandler(this.lsvApplicationID_SelectedIndexChanged);
			// 
			// clmPatientName_BaseForm
			// 
			this.clmPatientName_BaseForm.Text = "";
			this.clmPatientName_BaseForm.Width = 100;
			// 
			// lblReportCheckPart
			// 
			this.lblReportCheckPart.AllowDrop = true;
			this.lblReportCheckPart.AutoSize = true;
			this.lblReportCheckPart.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblReportCheckPart.ForeColor = System.Drawing.Color.White;
			this.lblReportCheckPart.Location = new System.Drawing.Point(56, 324);
			this.lblReportCheckPart.Name = "lblReportCheckPart";
			this.lblReportCheckPart.Size = new System.Drawing.Size(80, 19);
			this.lblReportCheckPart.TabIndex = 10000020;
			this.lblReportCheckPart.Text = "检查部位:";
			// 
			// txtReportCheckPart
			// 
			this.txtReportCheckPart.AccessibleDescription = "检查费";
			this.txtReportCheckPart.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.txtReportCheckPart.BorderColor = System.Drawing.Color.White;
			this.txtReportCheckPart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtReportCheckPart.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtReportCheckPart.ForeColor = System.Drawing.Color.White;
			this.txtReportCheckPart.Location = new System.Drawing.Point(140, 322);
			this.txtReportCheckPart.Name = "txtReportCheckPart";
			this.txtReportCheckPart.ReadOnly = true;
			this.txtReportCheckPart.Size = new System.Drawing.Size(736, 26);
			this.txtReportCheckPart.TabIndex = 400;
			this.txtReportCheckPart.Text = "";
			// 
			// m_cmdShowPACS
			// 
			this.m_cmdShowPACS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_cmdShowPACS.Font = new System.Drawing.Font("SimSun", 12F);
			this.m_cmdShowPACS.Location = new System.Drawing.Point(664, 186);
			this.m_cmdShowPACS.Name = "m_cmdShowPACS";
			this.m_cmdShowPACS.Size = new System.Drawing.Size(84, 32);
			this.m_cmdShowPACS.TabIndex = 100;
			this.m_cmdShowPACS.Text = "查看影像";
			this.m_cmdShowPACS.Click += new System.EventHandler(this.m_cmdShowPACS_Click);
			// 
			// frmImageReport
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(1016, 655);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.txtReportCheckPart,
																		  this.m_cmdShowPACS,
																		  this.lblReportCheckPart,
																		  this.lblApplicationID,
																		  this.lblReportorName,
																		  this.lblReportDateTime,
																		  this.lblReportDiagnose,
																		  this.lblReportDesc,
																		  this.lblCheckRecord,
																		  this.lblCheckName,
																		  this.m_lsvBedNO,
																		  this.m_lsvPatientName,
																		  this.m_lsvInPatientID,
																		  this.m_cmdPre,
																		  this.m_cmdNext,
																		  this.m_cmdNewTemplate,
																		  this.m_cboDept,
																		  this.m_cboArea,
																		  this.m_txtBedNO,
																		  this.m_txtPatientName,
																		  this.lblSex,
																		  this.lblAge,
																		  this.lblBedNoTitle,
																		  this.lblInHospitalNoTitle,
																		  this.lblNameTitle,
																		  this.lblSexTitle,
																		  this.lblAgeTitle,
																		  this.lblAreaTitle,
																		  this.lblDept,
																		  this.txtInPatientID,
																		  this.m_lblForTitle,
																		  this.lsvApplicationID,
																		  this.txtReportDiagnose,
																		  this.txtReportDesc,
																		  this.txtApplicationID,
																		  this.txtReportorName,
																		  this.dtpReportDateTime,
																		  this.lsvCheckRecord,
																		  this.txtCheckName});
			this.Name = "frmImageReport";
			this.Text = "影像报告单";
			this.Load += new System.EventHandler(this.frmImageReport_Load);
			this.ResumeLayout(false);

		}
		#endregion

	
		//Member Define
		private clsPatient m_objSelectedPatient=null;
		private string m_strInPatientID;

		private string m_strInPatientDate;

		//		private ImageReport m_ImageReport;
		private ImageReport[] m_ImageReportArr;

		private clsImageReportDomain mImageReportDomain=new clsImageReportDomain();

		protected override void m_mthSetPatientFormInfo(iCare.clsPatient p_objSelectedPatient)
		{

			try
			{
				ListViewItem lviNewItem;

				m_objSelectedPatient=p_objSelectedPatient;

				m_strInPatientID = p_objSelectedPatient.m_StrInPatientID;
				m_strInPatientDate = p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate.ToString("yyyy-MM-dd HH:mm:ss");
				//先清除控件中的现有数据。
				InitControls();
				this.lsvCheckRecord.Items.Clear();
				this.lsvApplicationID.Items.Clear();

				//获取病人的检查记录
				//加载当前病人的申请记录
				mImageReportDomain.m_lngGetImageReportByPatientID(m_strInPatientID,out m_ImageReportArr);

				string[] m_lviItem;
				if (m_ImageReportArr!=null)
				{
					foreach(ImageReport m_ImageReport in m_ImageReportArr)
					{
						if(m_ImageReport == null)
							continue;

						if(m_ImageReport.m_dteRequestDateTime!=DateTime.MinValue )
						{
							m_lviItem=new String[4];
							m_lviItem[0]=m_ImageReport.m_dteRequestDateTime.ToString("yyyy-MM-dd HH:mm:ss");
							switch(m_ImageReport.m_strCheckType)
							{
								case "0":
									m_lviItem[1]="DR";
									break;
								case "1":
									m_lviItem[1]="CT";
									break;
								case "2":
									m_lviItem[1]="B超";
									break;
								default:
									m_lviItem[1]="未知类型";
									break;
							}
							m_lviItem[2]=m_ImageReport.HasReport ;
							m_lviItem[3]=m_ImageReport.m_strApplicationID;

							lviNewItem = new ListViewItem(m_lviItem);
						}
						else
							continue;
						
						
						this.lsvCheckRecord.Items.Add(lviNewItem);
						
						lviNewItem.Tag =m_ImageReport;

						//
						lviNewItem = new ListViewItem(new string[]{m_ImageReport.m_strApplicationID});
						this.lsvApplicationID.Items.Add(lviNewItem);
					
					}
				}

			}

			catch
			{
				
			}
			

		}

		private void lsvCheckRecord_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				ImageReport m_ImageReport;
				if (this.lsvCheckRecord.SelectedItems.Count>0 && this.lsvCheckRecord.SelectedItems[0].Tag!=null)
				{
					
					m_ImageReport=(ImageReport)this.lsvCheckRecord.SelectedItems[0].Tag;
				
					//处理不同的申请类型时，报告界面显示的差别。
					//B超需要显示检查部位，CT，DR需要显示检查名称
					string temp=m_ImageReport.m_strCheckType ;
					if(temp.IndexOf("2")>=0)
					{
						this.lblReportCheckPart.Visible=true;
						this.txtReportCheckPart.Visible=true;

						this.lblCheckName.Visible=false;
						this.txtCheckName.Visible=false;
					}
					else
						if(temp.IndexOf("1")>=0 | temp.IndexOf("0")>=0 )
					{		//|
						this.lblReportCheckPart.Visible=false;
						this.txtReportCheckPart.Visible=false;

						this.lblCheckName.Visible=true;
						this.txtCheckName.Visible=true;

						this.lblCheckName.Location=this.lblReportCheckPart.Location;
						this.txtCheckName.Location=this.txtReportCheckPart.Location;
					}
					else
					{					
						this.lblReportCheckPart.Visible=true;
						this.txtReportCheckPart.Visible=true;

						this.lblCheckName.Visible=true;
						this.txtCheckName.Visible=true;
						this.lblCheckName.Location=new Point(454,234);
						this.txtCheckName.Location=new Point(536,232);
					}

				
					//设置控件的值
					if (m_ImageReport.m_dteReportDateTime==DateTime.MinValue)
					{
						this.dtpReportDateTime.Value =DateTime.Parse("1900-01-01");
						//this.dtpReportDateTime.Text="";
					}
					else
						this.dtpReportDateTime.Value  =m_ImageReport.m_dteReportDateTime;

					this.txtApplicationID.Text =m_ImageReport.m_strApplicationID;
					this.txtCheckName.Text =m_ImageReport.m_strCheckName ;
					this.txtReportDiagnose .Text =m_ImageReport.m_strReportDiagnose;
					this.txtReportDesc.Text  =m_ImageReport.m_strReportDesc ;
					this.txtReportorName.Text =m_ImageReport.m_strReportorName;
					this.txtReportCheckPart.Text =m_ImageReport.m_strReportCheckPart;

	
					//无报告时，隐藏报告日期和报告医生
					if (m_ImageReport.HasReport =="无")
					{
						this.lblReportDateTime.Visible=false;
						this.dtpReportDateTime.Visible=false;

						this.lblReportorName.Visible=false;
						this.txtReportorName.Visible=false;

						this.txtReportDesc.Text="";
						this.txtReportDiagnose.Text="";
					}
					else
					{
						this.lblReportDateTime.Visible=true;
						this.dtpReportDateTime.Visible=true;

						this.lblReportorName.Visible=true;
						this.txtReportorName.Visible=true;
					}

				}
			}
			catch
			{
			}

		}

		private void InitControls()
		{
			this.dtpReportDateTime.Value =DateTime.Parse("1900-01-01");
			this.txtApplicationID.Text ="";
			this.txtCheckName.Text ="";
			this.txtReportDiagnose.Text ="";
			this.txtReportDesc.Text  ="";
			this.txtReportorName.Text ="";
			this.txtReportCheckPart.Text ="";
		
		}

		private void txtApplicationID_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch(e.KeyValue)
			{
				case 13:// enter				
					
					m_mthGetApplicationIDList_Pat_ID(txtApplicationID.Text);
			
					if(this.lsvApplicationID.Items.Count==1 && (txtApplicationID.Text==lsvApplicationID.Items[0].SubItems[0].Text))
					{
						lsvApplicationID.Items[0].Selected=true;
						lsvApplicationID_DoubleClick(null,null);
						break;
					}
					break;
				case 40://Arrow Down
				{
					this.lsvApplicationID.Focus();
					if(lsvApplicationID.Visible==true)
					{
						lsvApplicationID.Items[0].Selected =true;
						lsvApplicationID.Items[0].Focused  =true;
					}
					break;
				}
			}	
		}

		private void txtApplicationID_Leave(object sender, System.EventArgs e)
		{
			if(!lsvApplicationID.Focused)
				lsvApplicationID.Visible = false;
		}

//		private bool m_blnCanApplicationIDTextChanged = true;

		/// <summary>
		/// 显示检验号列表，这里的BarCode相当于检验号Pat_ID
		/// </summary>
		/// <param name="p_strDoctorNameLike">检验号</param>
		private void m_mthGetApplicationIDList_Pat_ID(string p_strApplicationIDLike)
		{
//			if(!m_blnCanApplicationIDTextChanged)
//				return;

			if(p_strApplicationIDLike.Length == 0)
			{
				lsvApplicationID.Visible = false;
				return;
			}

			string[] strApplicationIDArr; 
			mImageReportDomain.m_lngGetImageReportList(txtApplicationID.Text ,m_ImageReportArr,out strApplicationIDArr);

			if(strApplicationIDArr == null)
			{
				lsvApplicationID.Visible = false;
				return;
			}

			lsvApplicationID.Items.Clear();

			for(int i=0;i<strApplicationIDArr.Length;i++)
			{
//				if(strDeptNameArr[i]==clsSystemContext.s_ObjCurrentContext.m_ObjDepartment.m_StrDeptName.Trim())
//				{
					ListViewItem lviApplicationID = new ListViewItem(
						new string[]{
										strApplicationIDArr[i]
									});
					lviApplicationID.Tag = strApplicationIDArr[i];

					lsvApplicationID.Items.Add(lviApplicationID);
//				}
			}

			lsvApplicationID.BringToFront();
			lsvApplicationID.Visible = true;
		}

		private void lsvApplicationID_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{		
				ImageReport mTempImageReport;
				bool m_bnlSearched=false;

				////////////////////////////

				if(lsvApplicationID.SelectedItems.Count <= 0)
					return;

				txtApplicationID.Text = lsvApplicationID.SelectedItems[0].SubItems[0].Text;

				lsvApplicationID.Visible = false;

				foreach(ListViewItem lviCheckRecord in lsvCheckRecord.Items)
				{
					mTempImageReport=(ImageReport)lviCheckRecord.Tag;

					if (mTempImageReport!=null && mTempImageReport.m_strApplicationID==txtApplicationID.Text)
					{
						this.lsvCheckRecord.Focus();
						lviCheckRecord.Selected=true;
						this.lsvCheckRecord_SelectedIndexChanged(lsvCheckRecord,new System.EventArgs());
						m_bnlSearched=true;
						break;
					}

				}

				if (m_bnlSearched==false)
				{
					clsPublicFunction.ShowInformationMessageBox("对不起，没有找到与这个申请单号相关的数据。");
				}
			}
			catch
			{
				
			}
			
		}

		private void lsvApplicationID_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch(e.KeyValue)
			{
				case 13:// enter				
				{			
					//					m_mthGetBarCodeList_Pat_ID(txtApplicationID.Text);
					lsvApplicationID_DoubleClick(null,null);						
					break;
				}
				
			}	
		}

		private void lsvApplicationID_Leave(object sender, System.EventArgs e)
		{
			this.lsvApplicationID.Visible=false;
		}

		private void lsvApplicationID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void m_cmdShowPACS_Click(object sender, System.EventArgs e)
		{
			PACS.clsPACSTool.s_mthShowPACS(m_objBaseCurrentPatient,this);
		}	
		public void m_mthShowPACS()
		{
			PACS.clsPACSTool.s_mthShowPACS(m_objBaseCurrentPatient,this);
		}

		private void frmImageReport_Load(object sender, System.EventArgs e)
		{
			lsvCheckRecord.Focus();
		}

		/// <summary>
		/// 不需要保存提示
		/// </summary>
		protected override void m_mthAddFormStatusForClosingSave()
		{
		}
		/// <summary>
		/// 提供子窗体的手动资源释放
		/// </summary>
//		protected override void m_mthReleaseSub()
//		{
//			if(m_objBorderTool != null)
//				m_objBorderTool.m_mthClear();
//			base.m_mthReleaseSub();
//		}
	}
}

