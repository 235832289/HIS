using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using iCareData;
using com.digitalwave.Utility.Controls;
using System.Data;
using HRP;
using PrivilegeData;
using com.digitalwave.clsICUNurseRecord_GXService;

namespace iCare
{
	/// <summary>
	/// ICU护理记录(广西)
	/// </summary>
	public class frmICUNurseRecord_GX : iCare.frmRecordsBase
	{
		private System.Windows.Forms.Label label1;		
		private string m_strCurrentOpenDate = "";
		private string m_strCreateUserID = "";
		protected com.digitalwave.Utility.Controls.ctlTimePicker m_dtpCreateDate;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox m_txtDiseaseID;
		private System.Windows.Forms.DataGridTextBoxColumn clmRecordDayOfDate;
		private System.Windows.Forms.DataGridTextBoxColumn clmRecordTimeOfDate;
		private cltDataGridDSTRichTextBox m_dtcInAmountItem;
		private cltDataGridDSTRichTextBox m_dtcInAmountStandby;
		private cltDataGridDSTRichTextBox m_dtcInAmountFact;
		private cltDataGridDSTRichTextBox m_dtcOutEmiction;
		private cltDataGridDSTRichTextBox m_dtcTemperature;
		private cltDataGridDSTRichTextBox m_dtcHR;
		private cltDataGridDSTRichTextBox m_dtcRespiration;
		private cltDataGridDSTRichTextBox m_dtcA;
		private cltDataGridDSTRichTextBox m_dtcSPO2;
		private cltDataGridDSTRichTextBox m_dtcGenaralInstance;
		private cltDataGridDSTRichTextBox m_dtcBP;
		private cltDataGridDSTRichTextBox m_dtcCustom1;
		private cltDataGridDSTRichTextBox m_dtcCustom2;
		private cltDataGridDSTRichTextBox m_dtcSum;
		private string m_strCustomColumn1 = "";
		private string m_strCustomColumn2 = "";
		private string m_strCustomColumn3 = "";
		private string m_strCustomColumn4 = "";
		private string m_strTempColumnName = "";
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmICUNurseRecord_GX()
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
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtDiseaseID = new System.Windows.Forms.TextBox();
            this.m_dtpCreateDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.clmRecordDayOfDate = new System.Windows.Forms.DataGridTextBoxColumn();
            this.clmRecordTimeOfDate = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_dtcInAmountItem = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcInAmountStandby = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcInAmountFact = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcOutEmiction = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcTemperature = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcHR = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcRespiration = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcBP = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcA = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcSPO2 = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcGenaralInstance = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcCustom1 = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcCustom2 = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcSum = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgRecordDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtbRecords)).BeginInit();
            this.m_pnlNewBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgtsStyles
            // 
            this.dgtsStyles.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																										 this.clmRecordDayOfDate,
																										 this.clmRecordTimeOfDate,
																										 this.m_dtcInAmountItem,
																										 this.m_dtcInAmountStandby,
																										 this.m_dtcInAmountFact,
																										 this.m_dtcOutEmiction,
																										 this.m_dtcCustom1,
																										 this.m_dtcCustom2,
																										 this.m_dtcTemperature,
																										 this.m_dtcHR,
																										 this.m_dtcRespiration,
																										 this.m_dtcBP,
																										 this.m_dtcA,
																										 this.m_dtcSPO2,
																										 this.m_dtcGenaralInstance,
																										 this.m_dtcSum});
            this.dgtsStyles.RowHeaderWidth = 15;
            // 
            // m_dtgRecordDetail
            // 
            this.m_dtgRecordDetail.BackgroundColor = System.Drawing.SystemColors.AppWorkspace;
            this.m_dtgRecordDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_dtgRecordDetail.CaptionBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.m_dtgRecordDetail.DataSource = this.m_dtbRecords;
            this.m_dtgRecordDetail.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_dtgRecordDetail.HeaderForeColor = System.Drawing.SystemColors.Window;
            this.m_dtgRecordDetail.Location = new System.Drawing.Point(9, 72);
            this.m_dtgRecordDetail.Size = new System.Drawing.Size(787, 504);
            this.m_dtgRecordDetail.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_dtgRecordDetail_MouseDown);
            // 
            // mniAppend
            // 
            this.mniAppend.Click += new System.EventHandler(this.mniAppend_Click);
            // 
            // m_trvInPatientDate
            // 
            this.m_trvInPatientDate.BackColor = System.Drawing.Color.White;
            this.m_trvInPatientDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_trvInPatientDate.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_trvInPatientDate.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_trvInPatientDate.LineColor = System.Drawing.Color.Black;
            this.m_trvInPatientDate.Location = new System.Drawing.Point(8, 114);
            this.m_trvInPatientDate.Size = new System.Drawing.Size(176, 60);
            this.m_trvInPatientDate.Visible = false;
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(608, 154);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(688, 154);
            this.lblAge.Size = new System.Drawing.Size(72, 19);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(415, 122);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(400, 154);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(568, 122);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(568, 154);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(648, 154);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(200, 154);
            this.lblAreaTitle.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(456, 154);
            this.txtInPatientID.Size = new System.Drawing.Size(96, 23);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(616, 122);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(456, 122);
            this.m_txtBedNO.Size = new System.Drawing.Size(72, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(248, 154);
            this.m_cboArea.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(248, 122);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(200, 122);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(704, 154);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.m_cmdNext.Location = new System.Drawing.Point(528, 122);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(156, 118);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(779, 151);
            this.m_lblForTitle.Size = new System.Drawing.Size(8, 23);
            this.m_lblForTitle.Visible = false;
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(707, 83);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(723, 37);
            this.m_cmdModifyPatientInfo.Size = new System.Drawing.Size(69, 28);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Visible = true;
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(535, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 14);
            this.label1.TabIndex = 10000004;
            this.label1.Text = "病案号:";
            // 
            // m_txtDiseaseID
            // 
            this.m_txtDiseaseID.Location = new System.Drawing.Point(594, 39);
            this.m_txtDiseaseID.Name = "m_txtDiseaseID";
            this.m_txtDiseaseID.Size = new System.Drawing.Size(100, 23);
            this.m_txtDiseaseID.TabIndex = 10000005;
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.BorderColor = System.Drawing.Color.Black;
            this.m_dtpCreateDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpCreateDate.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_dtpCreateDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpCreateDate.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpCreateDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpCreateDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_dtpCreateDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpCreateDate.Location = new System.Drawing.Point(384, 40);
            this.m_dtpCreateDate.m_BlnOnlyTime = false;
            this.m_dtpCreateDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpCreateDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpCreateDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpCreateDate.Name = "m_dtpCreateDate";
            this.m_dtpCreateDate.ReadOnly = false;
            this.m_dtpCreateDate.Size = new System.Drawing.Size(144, 22);
            this.m_dtpCreateDate.TabIndex = 10000039;
            this.m_dtpCreateDate.TextBackColor = System.Drawing.Color.White;
            this.m_dtpCreateDate.TextForeColor = System.Drawing.Color.Black;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(339, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 14);
            this.label2.TabIndex = 10000004;
            this.label2.Text = "日期:";
            // 
            // clmRecordDayOfDate
            // 
            this.clmRecordDayOfDate.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.clmRecordDayOfDate.Format = "";
            this.clmRecordDayOfDate.FormatInfo = null;
            this.clmRecordDayOfDate.MappingName = "RecordDayOfDate";
            this.clmRecordDayOfDate.Width = 80;
            // 
            // clmRecordTimeOfDate
            // 
            this.clmRecordTimeOfDate.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.clmRecordTimeOfDate.Format = "";
            this.clmRecordTimeOfDate.FormatInfo = null;
            this.clmRecordTimeOfDate.MappingName = "RecordTimeOfDate";
            this.clmRecordTimeOfDate.Width = 60;
            // 
            // m_dtcInAmountItem
            // 
            this.m_dtcInAmountItem.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcInAmountItem.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcInAmountItem.m_BlnGobleSet = false;
            this.m_dtcInAmountItem.m_BlnUnderLineDST = false;
            this.m_dtcInAmountItem.MappingName = "InAmountItem";
            this.m_dtcInAmountItem.Width = 150;
            // 
            // m_dtcInAmountStandby
            // 
            this.m_dtcInAmountStandby.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcInAmountStandby.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcInAmountStandby.m_BlnGobleSet = false;
            this.m_dtcInAmountStandby.m_BlnUnderLineDST = false;
            this.m_dtcInAmountStandby.MappingName = "InAmountStandby";
            this.m_dtcInAmountStandby.Width = 50;
            // 
            // m_dtcInAmountFact
            // 
            this.m_dtcInAmountFact.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcInAmountFact.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcInAmountFact.m_BlnGobleSet = true;
            this.m_dtcInAmountFact.m_BlnUnderLineDST = false;
            this.m_dtcInAmountFact.MappingName = "InAmountFact";
            this.m_dtcInAmountFact.Width = 50;
            // 
            // m_dtcOutEmiction
            // 
            this.m_dtcOutEmiction.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcOutEmiction.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcOutEmiction.m_BlnGobleSet = true;
            this.m_dtcOutEmiction.m_BlnUnderLineDST = false;
            this.m_dtcOutEmiction.MappingName = "OutEmiction";
            this.m_dtcOutEmiction.Width = 50;
            // 
            // m_dtcTemperature
            // 
            this.m_dtcTemperature.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcTemperature.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcTemperature.m_BlnGobleSet = true;
            this.m_dtcTemperature.m_BlnUnderLineDST = false;
            this.m_dtcTemperature.MappingName = "Temperature";
            this.m_dtcTemperature.Width = 50;
            // 
            // m_dtcHR
            // 
            this.m_dtcHR.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcHR.m_BlnGobleSet = true;
            this.m_dtcHR.m_BlnUnderLineDST = false;
            this.m_dtcHR.MappingName = "HR";
            this.m_dtcHR.Width = 50;
            // 
            // m_dtcRespiration
            // 
            this.m_dtcRespiration.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcRespiration.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcRespiration.m_BlnGobleSet = true;
            this.m_dtcRespiration.m_BlnUnderLineDST = false;
            this.m_dtcRespiration.MappingName = "Respiration";
            this.m_dtcRespiration.Width = 50;
            // 
            // m_dtcBP
            // 
            this.m_dtcBP.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcBP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcBP.m_BlnGobleSet = true;
            this.m_dtcBP.m_BlnUnderLineDST = false;
            this.m_dtcBP.MappingName = "BP";
            this.m_dtcBP.Width = 80;
            // 
            // m_dtcA
            // 
            this.m_dtcA.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcA.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcA.m_BlnGobleSet = true;
            this.m_dtcA.m_BlnUnderLineDST = false;
            this.m_dtcA.MappingName = "A";
            this.m_dtcA.Width = 50;
            // 
            // m_dtcSPO2
            // 
            this.m_dtcSPO2.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcSPO2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcSPO2.m_BlnGobleSet = true;
            this.m_dtcSPO2.m_BlnUnderLineDST = false;
            this.m_dtcSPO2.MappingName = "SPO2";
            this.m_dtcSPO2.Width = 50;
            // 
            // m_dtcGenaralInstance
            // 
            this.m_dtcGenaralInstance.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcGenaralInstance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcGenaralInstance.m_BlnGobleSet = true;
            this.m_dtcGenaralInstance.m_BlnUnderLineDST = false;
            this.m_dtcGenaralInstance.MappingName = "GenaralInstance";
            this.m_dtcGenaralInstance.Width = 270;
            // 
            // m_dtcCustom1
            // 
            this.m_dtcCustom1.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcCustom1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcCustom1.m_BlnGobleSet = true;
            this.m_dtcCustom1.m_BlnUnderLineDST = false;
            this.m_dtcCustom1.MappingName = "Custom1";
            this.m_dtcCustom1.Width = 50;
            // 
            // m_dtcCustom2
            // 
            this.m_dtcCustom2.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcCustom2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcCustom2.m_BlnGobleSet = true;
            this.m_dtcCustom2.m_BlnUnderLineDST = false;
            this.m_dtcCustom2.MappingName = "Custom2";
            this.m_dtcCustom2.Width = 50;
            // 
            // m_dtcSum
            // 
            this.m_dtcSum.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcSum.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcSum.m_BlnGobleSet = true;
            this.m_dtcSum.m_BlnUnderLineDST = false;
            this.m_dtcSum.MappingName = "Sum";
            this.m_dtcSum.Width = 270;
            // 
            // frmICUNurseRecord_GX
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(838, 657);
            this.Controls.Add(this.m_dtpCreateDate);
            this.Controls.Add(this.m_txtDiseaseID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "frmICUNurseRecord_GX";
            this.Text = "ICU护理记录";
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.m_trvInPatientDate, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.m_txtDiseaseID, 0);
            this.Controls.SetChildIndex(this.m_dtgRecordDetail, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_dtpCreateDate, 0);
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgRecordDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtbRecords)).EndInit();
            this.m_pnlNewBase.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		protected override Font m_FntHeaderFont
		{
			get
			{
				return new System.Drawing.Font("SimSun", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			}
		}

		// 初始化具体表单的DataTable。
		// 注意，DataTable的第一个Column必须是存放记录时间的字符串，第二个Column必须是存放记录类型的int值，第三个Column必须是存放记录的OpenDate
		protected override void m_mthInitDataTable(DataTable p_dtbRecordTable)
		{

			//存放记录时间的字符串
			p_dtbRecordTable.Columns.Add("RecordDate");//0
			//存放记录类型的int值
			DataColumn dcRecordType = new DataColumn("RecordType",typeof(int));
			p_dtbRecordTable.Columns.Add(dcRecordType);//1
			//存放记录的OpenDate字符串
			p_dtbRecordTable.Columns.Add("OpenDate");  //2
			//存放记录的ModifyDate字符串
			p_dtbRecordTable.Columns.Add("ModifyDate"); //3
			DataColumn dc1 = p_dtbRecordTable.Columns.Add("RecordDayOfDate");//4
			dc1.DefaultValue = "";
			DataColumn dc2 = p_dtbRecordTable.Columns.Add("RecordTimeOfDate");//5
			dc2.DefaultValue = "";
			p_dtbRecordTable.Columns.Add("InAmountItem",typeof(clsDSTRichTextBoxValue));//6
			p_dtbRecordTable.Columns.Add("InAmountStandby",typeof(clsDSTRichTextBoxValue));//7
			p_dtbRecordTable.Columns.Add("InAmountFact",typeof(clsDSTRichTextBoxValue));//8
			p_dtbRecordTable.Columns.Add("OutEmiction",typeof(clsDSTRichTextBoxValue));//9
			p_dtbRecordTable.Columns.Add("Custom1",typeof(clsDSTRichTextBoxValue));
			p_dtbRecordTable.Columns.Add("Custom2",typeof(clsDSTRichTextBoxValue));
			p_dtbRecordTable.Columns.Add("Temperature",typeof(clsDSTRichTextBoxValue));//9
			p_dtbRecordTable.Columns.Add("HR",typeof(clsDSTRichTextBoxValue));//10	
			p_dtbRecordTable.Columns.Add("Respiration",typeof(clsDSTRichTextBoxValue));//11
			p_dtbRecordTable.Columns.Add("BP",typeof(clsDSTRichTextBoxValue));
			p_dtbRecordTable.Columns.Add("A",typeof(clsDSTRichTextBoxValue));
			p_dtbRecordTable.Columns.Add("SPO2",typeof(clsDSTRichTextBoxValue));
			p_dtbRecordTable.Columns.Add("GenaralInstance",typeof(clsDSTRichTextBoxValue));
			p_dtbRecordTable.Columns.Add("Sum",typeof(clsDSTRichTextBoxValue));
			p_dtbRecordTable.Columns.Add("RecordSignID");


			m_dtcGenaralInstance.m_RtbBase.m_BlnReadOnly = true;
			m_mthSetControl(clmRecordDayOfDate);
			m_mthSetControl(clmRecordTimeOfDate);
			m_mthSetControl(m_dtcInAmountItem);
			m_mthSetControl(m_dtcInAmountStandby);
			m_mthSetControl(m_dtcInAmountFact);
			m_mthSetControl(m_dtcOutEmiction);
			m_mthSetControl(m_dtcCustom1);
			m_mthSetControl(m_dtcCustom2);
			m_mthSetControl(m_dtcTemperature);
			m_mthSetControl(m_dtcHR);
			m_mthSetControl(m_dtcRespiration);
			m_mthSetControl(m_dtcBP);
			m_mthSetControl(m_dtcA);
			m_mthSetControl(m_dtcSPO2);
			m_mthSetControl(m_dtcGenaralInstance);
			m_mthSetControl(m_dtcSum);
			//设置文字栏
			this.clmRecordDayOfDate.HeaderText = "\r\n\r\n日期";
			this.clmRecordTimeOfDate.HeaderText = "\r\n\r\n时间";
			this.m_dtcInAmountItem.HeaderText = "入量\r\n\r\n项\r\n\r\n目";
			this.m_dtcInAmountStandby.HeaderText = "入量\r\n\r\n备\r\n用\r\n量";
			this.m_dtcInAmountFact.HeaderText = "入量\r\n\r\n实\r\n用\r\n量";
			this.m_dtcOutEmiction.HeaderText = "出量\r\n\r\n尿";
			this.m_dtcCustom1.HeaderText = m_strCustomColumn1;
			this.m_dtcCustom2.HeaderText = m_strCustomColumn2;
			this.m_dtcTemperature.HeaderText = "观察\r\n病情\r\nT";
			this.m_dtcHR.HeaderText = "观察\r\n病情\r\nHR";
			this.m_dtcRespiration.HeaderText = "观察\r\n病情\r\nR";
			this.m_dtcBP.HeaderText = "观察\r\n病情\r\nBP";
			this.m_dtcA.HeaderText = m_strCustomColumn3;
			this.m_dtcSPO2.HeaderText = m_strCustomColumn4;
			this.m_dtcGenaralInstance.HeaderText = "观察病情\r\n一  般  情  况";
			this.m_dtcSum.HeaderText = "\r\n\r\n小结";
		}

		#region 属性
		/// <summary>
		/// 当前入院时间
		/// </summary>
		protected override string m_StrCurrentOpenDate
		{
			get
			{
				if(m_strCurrentOpenDate=="")
				{
					clsPublicFunction.ShowInformationMessageBox("请先选择记录");
					return "";
				}
				return m_strCurrentOpenDate;
			}
		}

		protected override enmApproveType m_EnmAppType
		{
			get{return enmApproveType.Nurses;}
		}
		/// <summary>
		/// 记录者ID?
		/// </summary>
		protected override string m_StrRecorder_ID
		{
			get
			{
				return m_strCreateUserID;
			}
		}
		#endregion 属性

		//设置初始的比较日期
		private DateTime m_dtmPreRecordDate;
		// 清空特殊记录信息，并重置记录控制状态为不控制。
		protected override void m_mthClearRecordInfo()
		{			
			m_dtmPreRecordDate=DateTime.MinValue;
			m_dtgRecordDetail.CurrentRowIndex=0;
			m_dtbRecords.Rows.Clear();
		}

		/// <summary>
		/// 获取痕迹保留
		/// </summary>
		/// <param name="p_strText"></param>
		/// <param name="p_strModifyUserID"></param>
		/// <param name="p_strModifyUserName"></param>
		/// <returns></returns>
		private string m_strGetDSTTextXML(string p_strText,string p_strModifyUserID,string p_strModifyUserName)
		{
			return com.digitalwave.controls.ctlRichTextBox.clsXmlTool.s_strMakeDSTXml(p_strText,p_strModifyUserID,p_strModifyUserName,Color.Black,Color.White);
		}

		// 获取病程记录的领域层实例
		protected override clsRecordsDomain m_objGetRecordsDomain()
		{
            return new clsRecordsDomain(enmRecordsType.ICUNurseRecord_GX);
		}

		// 获取记录的主要信息（必须获取的是CreateDate,OpenDate,LastModifyDate）
		protected override clsTrackRecordContent m_objGetRecordMainContent(int p_intRecordType,
			object[] p_objDataArr)
		{
			//根据 p_intRecordType 获取对应的 clsTrackRecordContent
			clsTrackRecordContent objContent = null;
			switch((enmDiseaseTrackType)p_intRecordType)
			{ 
				case enmDiseaseTrackType.ICUNurseRecord_GX:
					objContent = new clsICUNurseRecordContentGX();
					break;
			}

			if(objContent == null)
				objContent=new clsICUNurseRecordContentGX();	
		
			if(m_objCurrentPatient !=null && m_ObjCurrentEmrPatientSession != null)
				objContent.m_strInPatientID=m_objCurrentPatient.m_StrInPatientID;
			else 
			{
				clsPublicFunction.ShowInformationMessageBox("当前病人为空!");
				return null;
			}
			int intSelectedRecordStartRow =m_dtgRecordDetail.CurrentCell.RowNumber;
			objContent.m_strCreateUserID = (m_dtbRecords.Rows[intSelectedRecordStartRow][20]).ToString();
            objContent.m_dtmInPatientDate = m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate;
			objContent.m_dtmCreateDate = DateTime.Parse((string)p_objDataArr[0]);
			objContent.m_dtmOpenDate = DateTime.Parse((string)p_objDataArr[2]);
			objContent.m_dtmModifyDate = DateTime.Parse((string)p_objDataArr[3]);
            objContent.m_strCreateUserID = (string)p_objDataArr[20];
		
			return objContent;
		}

		private void frmGeneralNurseRecord_GX_Load(object sender, System.EventArgs e)
		{
			m_dtmPreRecordDate = DateTime.MinValue;
			m_dtgRecordDetail.Focus();
			m_mniAddBlank.Visible=false;
			m_mniDeleteBlank.Visible=false;
		}

		// 获取处理（添加和修改）记录的窗体。
		protected override frmDiseaseTrackBase m_frmGetRecordForm(int p_intRecordType)
		{
			switch((enmDiseaseTrackType)p_intRecordType)
			{
				case enmDiseaseTrackType.ICUNurseRecord_GX:
                    string[] strCustomColumnName = { m_strCustomColumn1,m_strCustomColumn2,m_strCustomColumn3,m_strCustomColumn4};
                    return new frmICUNurseRecord_GXCon(strCustomColumnName);
			}  
		
			return null;
		}

		/// <summary>
		/// 处理子窗体
		/// </summary>
		/// <param name="p_frmSubForm"></param>
		protected override void m_mthHandleSubFormClosedWithYes(frmDiseaseTrackBase p_frmSubForm)
		{
            m_mthPerformSessionChanged(m_ObjCurrentEmrPatientSession,0);
		}
		/// <summary>
		/// 从Table删除数据
		/// </summary>
		/// <param name="p_intRecordType"></param>
		/// <param name="p_dtmCreateRecordTime"></param>
		protected override void m_mthRemoveDataFromDataTable(int p_intRecordType,
			DateTime p_dtmCreateRecordTime)
		{
            m_mthPerformSessionChanged(m_ObjCurrentEmrPatientSession, 0);
		}

		/// <summary>
		/// 获取当前病人的作废内容
		/// </summary>
		/// <param name="p_dtmRecordDate">记录日期</param>
		/// <param name="p_intFormID">窗体ID</param>
		protected override void m_mthGetDeactiveContent(DateTime p_dtmRecordDate,int p_intFormID)
		{			
			m_mthGetDeletedRecord(p_intFormID,p_dtmRecordDate);
		}

		protected override void m_mthModifyRecord(int p_intRecordType,
			DateTime p_dtmCreateRecordTime)
		{
			PrivilegeData.enmPrivilegeSF enmSF = (PrivilegeData.enmPrivilegeSF)Enum.Parse(typeof(PrivilegeData.enmPrivilegeSF),this.GetType().Name);
#if FunctionPrivilege
			if(!clsPublicFunction.s_blnCheckCurrentPrivilege(enmSF,PrivilegeData.enmPrivilegeOperation.AddOrModify))
			{
				clsPublicFunction.s_mthShowNotPermitMessage();
				return;
			}			
#endif
			//获取添加记录的窗体
			frmDiseaseTrackBase frmAddNewForm = m_frmGetRecordForm(p_intRecordType); 
			frmAddNewForm.m_mthSetDiseaseTrackInfo(m_objCurrentPatient,p_dtmCreateRecordTime);
		
			m_mthShowSubForm(frmAddNewForm,p_intRecordType,true);
		}

		protected override void m_mthClearPatientRecordInfo()
		{
			m_mthSetDataGridFirstRowFocus();
			m_dtgRecordDetail.CurrentRowIndex = 0;
			m_dtbRecords.Rows.Clear();
			//清空记录内容                       
			m_mthClearRecordInfo();
		}

		private void mniAppend_Click(object sender, System.EventArgs e)
		{
			PrivilegeData.enmPrivilegeSF enmSF = (PrivilegeData.enmPrivilegeSF)Enum.Parse(typeof(PrivilegeData.enmPrivilegeSF),this.GetType().Name);
#if FunctionPrivilege
			if(!clsPublicFunction.s_blnCheckCurrentPrivilege(enmSF,PrivilegeData.enmPrivilegeOperation.AddOrModify))
			{
				clsPublicFunction.s_mthShowNotPermitMessage();
				return;
			}			
#endif
			m_mthAddNewRecord((int)enmDiseaseTrackType.ICUNurseRecord_GX);
		}

		protected override object[][] m_objGetRecordsValueArr(clsTransDataInfo p_objTransDataInfo)
		{
			#region 显示记录到DataGrid
			try
			{
				object[] objData;
				ArrayList objReturnData=new ArrayList();

				clsICUNurseRecordContentGXDataInfo objICUInfo=new clsICUNurseRecordContentGXDataInfo();			
				clsDSTRichTextBoxValue objclsDSTRichTextBoxValue;
				string strText,strXml;

				objICUInfo = (clsICUNurseRecordContentGXDataInfo)p_objTransDataInfo;

				if(objICUInfo.m_objRecordArr == null)
					return null;

				#region 获取修改限定时间
				int intCanModifyTime = 0;
				try
				{
					intCanModifyTime = int.Parse(m_strCanModifyTime);
				}
				catch
				{
					intCanModifyTime = 6;
				}
				#endregion

				int intRecordCount = objICUInfo.m_objRecordArr.Length;
				int intRowOfCurrentDetail = 0;

				for(int i=0; i<intRecordCount; i++)
				{
					objData = new object[21];   
					clsICUNurseRecordContentGX objCurrent = objICUInfo.m_objRecordArr[i];
					clsICUNurseRecordContentGX objNext = new clsICUNurseRecordContentGX();//下一条护理记录
					if(i < intRecordCount-1)
						objNext = objICUInfo.m_objRecordArr[i+1];

					//如果该护理记录是修改前的记录且是在指定时间内修改的，修改者与创建者为同一人，则不显示
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate 
                        && objNext.m_strModifyUserID.Trim()==objCurrent.m_strCreateUserID.Trim()
                        && objNext.m_dtmOpenDate == objCurrent.m_dtmOpenDate)
					{
						TimeSpan tsModify =  objNext.m_dtmModifyDate-objCurrent.m_dtmModifyDate;
						if((int)tsModify.TotalHours < intCanModifyTime)
							continue;
					}

					#region 存放关键字段
					if(objCurrent.m_dtmCreateDate!=DateTime.MinValue)
					{
						objData[0] = objCurrent.m_dtmCreateDate;//存放记录时间的字符串
						objData[1] = (int)enmRecordsType.ICUNurseRecord_GX;//存放记录类型的int值
						objData[2] = objCurrent.m_dtmOpenDate;//存放记录的OpenDate字符串
						objData[3] = objCurrent.m_dtmModifyDate;//存放记录的ModifyDate字符串   
						
						//同一天则只在第一行显示日期
						if(objCurrent.m_dtmCreateDate.Date.ToString() != m_dtmPreRecordDate.Date.ToString())
						{
							objData[4] = objCurrent.m_dtmCreateDate.Date.ToString("yyyy-MM-dd") ;//日期字符串
						}
						//修改后带有痕迹的记录不再显示时间
						if(m_dtmPreRecordDate != objCurrent.m_dtmCreateDate)
							objData[5] = objCurrent.m_dtmCreateDate.ToString("HH:mm");//时间字符串
	
					}
					m_dtmPreRecordDate = objCurrent.m_dtmCreateDate;	
					#endregion ;

					#region 存放单项信息
					//入量项目
					strText = objCurrent.m_strINAMOUNTITEM_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_dtmOpenDate == objCurrent.m_dtmOpenDate 
                        && objNext.m_strINAMOUNTITEM_RIGHT != objCurrent.m_strINAMOUNTITEM_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strINAMOUNTITEM_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[6] = objclsDSTRichTextBoxValue;//T
			
					//备用量
					strText = objCurrent.m_strINAMOUNTSTANDBY_RIGHT ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_dtmOpenDate == objCurrent.m_dtmOpenDate 
                        && objNext.m_strINAMOUNTSTANDBY_RIGHT != objCurrent.m_strINAMOUNTSTANDBY_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strINAMOUNTSTANDBY_RIGHT,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[7] = objclsDSTRichTextBoxValue;//HR

					//实入量
					strText = objCurrent.m_strINAMOUNTFACT_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_dtmOpenDate == objCurrent.m_dtmOpenDate 
                        && objNext.m_strINAMOUNTFACT_RIGHT != objCurrent.m_strINAMOUNTFACT_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strINAMOUNTFACT_RIGHT,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[8] = objclsDSTRichTextBoxValue;//P

			
					//尿
					strText = objCurrent.m_strOUTEMICTION_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_dtmOpenDate == objCurrent.m_dtmOpenDate 
                        && objNext.m_strOUTEMICTION_RIGHT != objCurrent.m_strOUTEMICTION_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strOUTEMICTION_RIGHT,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[9] = objclsDSTRichTextBoxValue;//

					//自定义列1
					strText = objCurrent.m_strCustom1_Right;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_dtmOpenDate == objCurrent.m_dtmOpenDate 
                        && objNext.m_strCustom1_Right != objCurrent.m_strCustom1_Right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strCustom1_Right,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[10] = objclsDSTRichTextBoxValue;

					//自定义列2
					strText = objCurrent.m_strCustom2_Right;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_dtmOpenDate == objCurrent.m_dtmOpenDate 
                        && objNext.m_strCustom2_Right != objCurrent.m_strCustom2_Right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strCustom2_Right,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[11] = objclsDSTRichTextBoxValue;
			
					//T
					strText = objCurrent.m_strTEMPERATURE_RIGHT ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_dtmOpenDate == objCurrent.m_dtmOpenDate 
                        && objNext.m_strTEMPERATURE_RIGHT != objCurrent.m_strTEMPERATURE_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strTEMPERATURE_RIGHT,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[12] = objclsDSTRichTextBoxValue;//

					//HR
					strText = objCurrent.m_strHR_RIGHT ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_dtmOpenDate == objCurrent.m_dtmOpenDate 
                        && objNext.m_strHR_RIGHT != objCurrent.m_strHR_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strHR_RIGHT,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[13] = objclsDSTRichTextBoxValue;//

					//R
					strText = objCurrent.m_strRESPIRATION_RIGHT ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_dtmOpenDate == objCurrent.m_dtmOpenDate 
                        && objNext.m_strRESPIRATION_RIGHT != objCurrent.m_strRESPIRATION_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strRESPIRATION_RIGHT,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[14] = objclsDSTRichTextBoxValue;//

					//BP
					strText = objCurrent.m_strBLOODPRESSUREA_RIGHT + "/" + objCurrent.m_strBLOODPRESSURES_RIGHT ;
					string strNextText = "";
					if(objNext != null)
						strNextText = objNext.m_strBLOODPRESSUREA_RIGHT + "/" + objNext.m_strBLOODPRESSURES_RIGHT ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_dtmOpenDate == objCurrent.m_dtmOpenDate 
                        && strNextText != strText)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(strText,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[15] = objclsDSTRichTextBoxValue;//

					//自定义列3
					strText = objCurrent.m_strA_RIGHT ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_dtmOpenDate == objCurrent.m_dtmOpenDate 
                        && objNext.m_strA_RIGHT != objCurrent.m_strA_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strA_RIGHT,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[16] = objclsDSTRichTextBoxValue;//

					//自定义列4
					strText = objCurrent.m_strSP02_RIGHT ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_dtmOpenDate == objCurrent.m_dtmOpenDate 
                        && objNext.m_strSP02_RIGHT != objCurrent.m_strSP02_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strSP02_RIGHT,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[17] = objclsDSTRichTextBoxValue;//

					//一般情况
					string[] strGeneralInstanceArr = null;
					string[] strGeneralInstanceXMLArr = null;
					if(objCurrent.m_strGENERALINSTANCE_RIGHT != null && objCurrent.m_strGENERALINSTANCE_RIGHT != "")
					{
						string strGeneralInstance = objCurrent.m_strGENERALINSTANCE;
						string strGeneralInstanceXML = objCurrent.m_strGENERALINSTANCEXML;
						string[] strGeneralInstanceArrTemp;
						string[] strGeneralInstanceXMLArrTemp;
						//将病情记录分行。
						com.digitalwave.controls.ctlRichTextBox.m_mthSplitXmlByBytes(strGeneralInstance,strGeneralInstanceXML,34,out strGeneralInstanceArrTemp,out strGeneralInstanceXMLArrTemp);
						
						if(objCurrent.m_strCreateUserName != null && objCurrent.m_strCreateUserName != "" 
                            && (objCurrent.m_strSummary_Right == null ||objCurrent.m_strSummary_Right == ""))
						{
							strGeneralInstanceArr = new string[strGeneralInstanceArrTemp.Length + 1];
							strGeneralInstanceXMLArr = new string[strGeneralInstanceXMLArrTemp.Length + 1];

							for(int j=0; j<strGeneralInstanceArr.Length-1; j++)
							{
								strGeneralInstanceArr[j] = strGeneralInstanceArrTemp[j];
							}
                            strGeneralInstanceArr[strGeneralInstanceArr.Length - 1] = "             " + objCurrent.m_dtmCreateDate.ToString("yyyy-MM-dd") + "    " + objCurrent.m_strCreateUserName;
							
							strGeneralInstanceXMLArr[strGeneralInstanceXMLArr.Length-1] = "";
							for(int j=0; j<strGeneralInstanceXMLArr.Length-1; j++)
							{
								strGeneralInstanceXMLArr[j] = strGeneralInstanceXMLArrTemp[j];
							}
						}
						else
						{
							strGeneralInstanceArr = strGeneralInstanceArrTemp;
							strGeneralInstanceXMLArr = strGeneralInstanceXMLArrTemp;
						}

						strText = strGeneralInstanceArr[0];
						strXml = strGeneralInstanceXMLArr[0];
						objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
						objclsDSTRichTextBoxValue.m_strText=strText;						
						objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
						objData[18] = objclsDSTRichTextBoxValue;
					}

					//小结
					string[] strSumArr = null;
					string[] strSuXMLArr = null;
					if(objCurrent.m_strSummary_Right != null && objCurrent.m_strSummary_Right != "")
					{
						string strSum = objCurrent.m_strSummary;
						string strSumXML = objCurrent.m_strSummaryXML;
                        string[] strSummaryArrTemp;
                        string[] strSummaryXMLArrTemp;
						//将小结分行。
                        com.digitalwave.controls.ctlRichTextBox.m_mthSplitXmlByBytes(strSum, strSumXML, 34, out strSummaryArrTemp, out strSummaryXMLArrTemp);

                        if (objCurrent.m_strCreateUserName != null && objCurrent.m_strCreateUserName != "")
                        {
                            strSumArr = new string[strSummaryArrTemp.Length + 1];
                            strSuXMLArr = new string[strSummaryXMLArrTemp.Length + 1];

                            for (int j = 0; j < strSumArr.Length - 1; j++)
                            {
                                strSumArr[j] = strSummaryArrTemp[j];
                            }
                            strSumArr[strSumArr.Length - 1] = "             " + objCurrent.m_dtmCreateDate.ToString("yyyy-MM-dd") + "    " + objCurrent.m_strCreateUserName;

                            strSuXMLArr[strSuXMLArr.Length - 1] = "";
                            for (int j = 0; j < strSuXMLArr.Length - 1; j++)
                            {
                                strSuXMLArr[j] = strSummaryXMLArrTemp[j];
                            }
                        }
                        else
                        {
                            strSumArr = strSummaryArrTemp;
                            strSuXMLArr = strSummaryXMLArrTemp;
                        }

						strText = strSumArr[0];
						strXml = strSuXMLArr[0];
						objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
						objclsDSTRichTextBoxValue.m_strText=strText;						
						objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
						objData[19] = objclsDSTRichTextBoxValue;
					}
                    if ((objCurrent.m_strSummary_Right == null || objCurrent.m_strSummary_Right == "")
                        && (objCurrent.m_strGENERALINSTANCE_RIGHT == null || objCurrent.m_strGENERALINSTANCE_RIGHT == ""))
                    {
                        if (objCurrent.m_strCreateUserName != null && objCurrent.m_strCreateUserName != "")
                        {
                            strText = "             " + objCurrent.m_dtmCreateDate.ToString("yyyy-MM-dd") + "    " + objCurrent.m_strCreateUserName;
                            strXml = "<root />";
                            objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                            objclsDSTRichTextBoxValue.m_strText = strText;
                            objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                            objData[18] = objclsDSTRichTextBoxValue;
                        }
                    }
					objData[20] = objCurrent.m_strCreateUserID;

					objReturnData.Add(objData);
					
					int intGenerArrLength = 0;
					int intSumLength = 0;
					if(strGeneralInstanceArr != null)
						intGenerArrLength = strGeneralInstanceArr.Length;
					if(strSumArr != null)
						intSumLength = strSumArr.Length;
					int intMaxLength = intGenerArrLength > intSumLength ? intGenerArrLength:intSumLength;
					if(intMaxLength > 0)
					{
						object[] objInstance = null;
						for(int j=0; j<intMaxLength; j++)
						{
							objInstance = new object[21];

							if(j < intGenerArrLength && j > 0)
							{
								strText = strGeneralInstanceArr[j];
								strXml = strGeneralInstanceXMLArr[j];
								objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
								objclsDSTRichTextBoxValue.m_strText=strText;						
								objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
								objInstance[18] = objclsDSTRichTextBoxValue;
							}

							if(j < intSumLength && j > 0)
							{
								strText = strSumArr[j];
								strXml = strSuXMLArr[j];
								objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
								objclsDSTRichTextBoxValue.m_strText=strText;						
								objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
								objInstance[19] = objclsDSTRichTextBoxValue;
							}

							if(objInstance[18] != null || objInstance[19] != null)
							{
								objInstance[20] = objCurrent.m_strCreateUserID;

								objReturnData.Add(objInstance);
							}
						}
					}

					if(objCurrent.m_intISSTAT == 1)
					{
						//如果该记录只记录了统计信息，则将上面已添加的该记录删除
						bool isOnlySum = true;
						String strTemp = "";
						for(int n=6; n<=19; n++)
						{
//							strTemp = ((clsDSTRichTextBoxValue)((object[])objReturnData[objReturnData.Count-1])[n]).m_strText;
//							if(strTemp != ""&& strTemp!=null)
//								isOnlySum = false;
							if(((object[])objReturnData[objReturnData.Count-1])[n] != null)
								isOnlySum = false;
						}
						if(isOnlySum)
						{
							//当该记录只记录了统计信时不再显示该记录的时间
							((object[])objReturnData[objReturnData.Count-1])[5] = null;
							((object[])objReturnData[objReturnData.Count-1])[4] = null;
						}

						object[] objSum = null;
						objSum = new object[21];
						strText = objCurrent.m_intSUMINTIME.ToString()+" h总入量：";
						strXml =  "<root />";
						strXml = m_strGetDSTTextXML(strText,MDIParent.OperatorID,MDIParent.OperatorName);
						objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
						objclsDSTRichTextBoxValue.m_strText=strText;						
						objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
						objclsDSTRichTextBoxValue.m_blnUnderDST = true;
						objSum[6] = objclsDSTRichTextBoxValue;

						strText = objCurrent.m_strSUMIN;
						strXml =  "<root />";
						strXml = m_strGetDSTTextXML(strText,MDIParent.OperatorID,MDIParent.OperatorName);
						objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
						objclsDSTRichTextBoxValue.m_strText=strText;						
						objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
						objclsDSTRichTextBoxValue.m_blnUnderDST = true;
						objSum[7] = objclsDSTRichTextBoxValue;
                        objSum[20] = objCurrent.m_strCreateUserID;
						objReturnData.Add(objSum);

                        objSum = new object[21];
                        strText = "备用量总入量：";
                        strXml = "<root />";
                        strXml = m_strGetDSTTextXML(strText, MDIParent.OperatorID, MDIParent.OperatorName);
                        objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                        objclsDSTRichTextBoxValue.m_strText = strText;
                        objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                        objclsDSTRichTextBoxValue.m_blnUnderDST = true;
                        objSum[6] = objclsDSTRichTextBoxValue;

                        strText = objCurrent.m_strINSTANDBYSUM;
                        strXml = "<root />";
                        strXml = m_strGetDSTTextXML(strText, MDIParent.OperatorID, MDIParent.OperatorName);
                        objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                        objclsDSTRichTextBoxValue.m_strText = strText;
                        objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                        objclsDSTRichTextBoxValue.m_blnUnderDST = true;
                        objSum[7] = objclsDSTRichTextBoxValue;
                        objSum[20] = objCurrent.m_strCreateUserID;
                        objReturnData.Add(objSum);

                        objSum = new object[21];
                        strText = "实入量总入量：";
                        strXml = "<root />";
                        strXml = m_strGetDSTTextXML(strText, MDIParent.OperatorID, MDIParent.OperatorName);
                        objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                        objclsDSTRichTextBoxValue.m_strText = strText;
                        objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                        objclsDSTRichTextBoxValue.m_blnUnderDST = true;
                        objSum[6] = objclsDSTRichTextBoxValue;

                        strText = objCurrent.m_strINFACTSUM;
                        strXml = "<root />";
                        strXml = m_strGetDSTTextXML(strText, MDIParent.OperatorID, MDIParent.OperatorName);
                        objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                        objclsDSTRichTextBoxValue.m_strText = strText;
                        objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                        objclsDSTRichTextBoxValue.m_blnUnderDST = true;
                        objSum[7] = objclsDSTRichTextBoxValue;
                        objSum[20] = objCurrent.m_strCreateUserID;
                        objReturnData.Add(objSum);


						objSum = new object[21];
						strText = objCurrent.m_intSUMOUTTIME.ToString()+" h总出量：";
						strXml =  "<root />";
						strXml = m_strGetDSTTextXML(strText,MDIParent.OperatorID,MDIParent.OperatorName);
						objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
						objclsDSTRichTextBoxValue.m_strText=strText;						
						objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
						objclsDSTRichTextBoxValue.m_blnUnderDST = true;
						objSum[6] = objclsDSTRichTextBoxValue;

						strText = objCurrent.m_strSUMOUT;
						strXml =  "<root />";
						strXml = m_strGetDSTTextXML(strText,MDIParent.OperatorID,MDIParent.OperatorName);
						objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
						objclsDSTRichTextBoxValue.m_strText=strText;						
						objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
						objclsDSTRichTextBoxValue.m_blnUnderDST = true;
						objSum[7] = objclsDSTRichTextBoxValue;
                        objSum[20] = objCurrent.m_strCreateUserID;
                        objReturnData.Add(objSum);

                        objSum = new object[21];
                        strText = "尿量总出量：";
                        strXml = "<root />";
                        strXml = m_strGetDSTTextXML(strText, MDIParent.OperatorID, MDIParent.OperatorName);
                        objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                        objclsDSTRichTextBoxValue.m_strText = strText;
                        objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                        objclsDSTRichTextBoxValue.m_blnUnderDST = true;
                        objSum[6] = objclsDSTRichTextBoxValue;

                        strText = objCurrent.m_strOUTEMICTIONSUM;
                        strXml = "<root />";
                        strXml = m_strGetDSTTextXML(strText, MDIParent.OperatorID, MDIParent.OperatorName);
                        objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                        objclsDSTRichTextBoxValue.m_strText = strText;
                        objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                        objclsDSTRichTextBoxValue.m_blnUnderDST = true;
                        objSum[7] = objclsDSTRichTextBoxValue;
                        objSum[20] = objCurrent.m_strCreateUserID;
                        objReturnData.Add(objSum);

                        objSum = new object[21];
                        string[] strCustomNameArr = null;
                        string strCustomName = "";
                        if (!string.IsNullOrEmpty(m_strCustomColumn1))
                        {
                            strCustomNameArr = m_strCustomColumn1.Split(new char[] { '\r', '\n' });
                            for (int m = 0; m < strCustomNameArr.Length; m++)
                            {
                                strCustomName += strCustomNameArr[m];
                            }
                        }
                        else
                            strCustomName = "自定义列1";
                        strText = strCustomName + "总出量：";
                        strXml = "<root />";
                        strXml = m_strGetDSTTextXML(strText, MDIParent.OperatorID, MDIParent.OperatorName);
                        objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                        objclsDSTRichTextBoxValue.m_strText = strText;
                        objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                        objclsDSTRichTextBoxValue.m_blnUnderDST = true;
                        objSum[6] = objclsDSTRichTextBoxValue;

                        strText = objCurrent.m_strOUTCUSTOM1SUM;
                        strXml = "<root />";
                        strXml = m_strGetDSTTextXML(strText, MDIParent.OperatorID, MDIParent.OperatorName);
                        objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                        objclsDSTRichTextBoxValue.m_strText = strText;
                        objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                        objclsDSTRichTextBoxValue.m_blnUnderDST = true;
                        objSum[7] = objclsDSTRichTextBoxValue;
                        objSum[20] = objCurrent.m_strCreateUserID;
                        objReturnData.Add(objSum);

                        objSum = new object[21];
                        strCustomName = "";
                        if (!string.IsNullOrEmpty(m_strCustomColumn2))
                        {
                            strCustomNameArr = m_strCustomColumn2.Split(new char[] { '\r', '\n' });
                            for (int m = 0; m < strCustomNameArr.Length; m++)
                            {
                                strCustomName += strCustomNameArr[m];
                            }
                        }
                        else
                            strCustomName = "自定义列2";
                        strText = strCustomName + "总出量：";
                        strXml = "<root />";
                        strXml = m_strGetDSTTextXML(strText, MDIParent.OperatorID, MDIParent.OperatorName);
                        objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                        objclsDSTRichTextBoxValue.m_strText = strText;
                        objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                        objclsDSTRichTextBoxValue.m_blnUnderDST = true;
                        objSum[6] = objclsDSTRichTextBoxValue;

                        strText = objCurrent.m_strOUTCUSTOM2SUM;
                        strXml = "<root />";
                        strXml = m_strGetDSTTextXML(strText, MDIParent.OperatorID, MDIParent.OperatorName);
                        objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                        objclsDSTRichTextBoxValue.m_strText = strText;
                        objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                        objclsDSTRichTextBoxValue.m_blnUnderDST = true;
                        objSum[7] = objclsDSTRichTextBoxValue;
                        if (objCurrent.m_strCreateUserName != "" && objCurrent.m_strCreateUserName != null)
                        {
                            strText = objCurrent.m_strCreateUserName;
                            strXml = "<root />";
                            objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                            objclsDSTRichTextBoxValue.m_strText = strText;
                            objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                            objSum[18] = objclsDSTRichTextBoxValue;
                        }
                        objSum[20] = objCurrent.m_strCreateUserID;
                        objReturnData.Add(objSum);
					}
					#endregion
				}
				object[][] m_objRe=new object[objReturnData.Count][];

				for(int m=0;m<objReturnData.Count ;m++)
					m_objRe[m]=(object[])objReturnData[m];
				return m_objRe;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message );
				return null;
			}
			#endregion
		}

		#region 自定义列头操作
		private void m_dtgRecordDetail_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(MDIParent.m_objCurrentPatient == null)
				return;
			if(e.Button == MouseButtons.Left && e.Clicks == 2)
			{
				System.Windows.Forms.DataGrid.HitTestInfo myHitTest = m_dtgRecordDetail.HitTest(e.X, e.Y);
				if(myHitTest.Column==6 || myHitTest.Column==7 || myHitTest.Column==12 || myHitTest.Column==13)
				{
					m_strTempColumnName = "";
					m_mthSetCustomColumn(myHitTest.Column);
				}
			}
		}

		private void m_mthSetCustomColumn(int p_intColumn)
		{
			string strHeaderText = m_dtgRecordDetail.TableStyles[0].GridColumnStyles[p_intColumn].HeaderText.Replace("\r\n","");
			frmSetCustomDataGridColumn frm=new frmSetCustomDataGridColumn(strHeaderText);		
			m_strTempColumnName = "";
			if (frm.ShowDialog() == DialogResult.Yes)
			{
				m_strTempColumnName = frm.m_StrSetName;				
			}
			else
				return;
			switch(p_intColumn)
			{
				case 6:	
					m_mthSaveColumnNameToDB("CUSTOM1name",ref m_strCustomColumn1);
					m_dtcCustom1.HeaderText = m_strCustomColumn1;
					break;
				case 7:
					m_mthSaveColumnNameToDB("CUSTOM2name",ref m_strCustomColumn2);
					m_dtcCustom2.HeaderText = m_strCustomColumn2;
					break;
				case 12:
					m_mthSaveColumnNameToDB("CUSTOM3name",ref m_strCustomColumn3);
					m_dtcA.HeaderText = m_strCustomColumn3;
					break;
				case 13:
					m_mthSaveColumnNameToDB("CUSTOM4name",ref m_strCustomColumn4);
					m_dtcSPO2.HeaderText = m_strCustomColumn4;
					break;
			}
		}

		private void m_mthSaveColumnNameToDB(string p_strColumnIndex,ref string p_strColumnName)
		{
			p_strColumnName = "";
            long lngRes = 0;

            clsICUNurseRecord_GXService objServ =
                (clsICUNurseRecord_GXService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsICUNurseRecord_GXService));

			if(m_strTempColumnName != "")
			{	
				int intColumnNameLength = m_strTempColumnName.Length;
				for(int i=0; i<intColumnNameLength; i++)
				{
					if(intColumnNameLength > 5)//字数大于5个，则直接从最顶部开始显示
					{
						if(i == 0)
							p_strColumnName += m_strTempColumnName[i].ToString();
						else
							p_strColumnName += "\r\n" + m_strTempColumnName[i].ToString();
					}
					else
						p_strColumnName += "\r\n" + m_strTempColumnName[i].ToString();
				}	
                //objServ.Dispose();
            }
            lngRes = objServ.m_lngSetCustomColumnName(m_objCurrentPatient.m_StrInPatientID, m_objCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"), p_strColumnIndex, p_strColumnName);
		}
		#endregion

		#region 重写m_trvInPatientDate_AfterSelect以便选定一个入院时间时Load出自定义列头
		protected override void m_trvInPatientDate_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			try
			{
				//清空病人记录信息				
				m_mthClearPatientRecordInfo();

				if(m_trvInPatientDate.SelectedNode==null || m_trvInPatientDate.SelectedNode==m_trvInPatientDate.Nodes[0] || m_objCurrentPatient==null)
				{						
					return;
				}
                //设置病人当次住院的基本信息
                m_mthOnlySetPatientInfo(m_objCurrentPatient);

                string m_strInPatientID = m_objCurrentPatient.m_ObjInBedInfo.m_objGetSessionByIndex(m_trvInPatientDate.Nodes[0].Nodes.Count - m_trvInPatientDate.SelectedNode.Index - 1).m_StrEMRInPatientID;
                string m_strInPatientDate = m_objCurrentPatient.m_ObjInBedInfo.m_objGetSessionByIndex(m_trvInPatientDate.Nodes[0].Nodes.Count - m_trvInPatientDate.SelectedNode.Index - 1).m_DtmEMRInDate.ToString("yyyy-MM-dd HH:mm:ss");

                txtInPatientID.Text = m_objCurrentPatient.m_ObjInBedInfo.m_objGetSessionByIndex(m_trvInPatientDate.Nodes[0].Nodes.Count - m_trvInPatientDate.SelectedNode.Index - 1).m_StrHISInPatientID;
                m_objCurrentPatient.m_DtmSelectedInDate = DateTime.Parse(m_strInPatientDate);
                m_objCurrentPatient.m_StrHISInPatientID = txtInPatientID.Text;
                m_objCurrentPatient.m_DtmSelectedHISInDate = Convert.ToDateTime(m_trvInPatientDate.SelectedNode.Text);

                #region 获取病人当次入院登记号
                string strRegisterID = "";

                com.digitalwave.PatientManagerService.clsPatientManagerService objServ =
                    (com.digitalwave.PatientManagerService.clsPatientManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.PatientManagerService.clsPatientManagerService));

                long lngRes = objServ.m_lngGetRegisterIDByPatient(m_objCurrentPatient.m_StrPatientID, m_objCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"), out strRegisterID);
                if (!string.IsNullOrEmpty(strRegisterID))
                {
                    com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR = strRegisterID;
                    m_objCurrentPatient.m_StrRegisterId = strRegisterID;
                    m_objBaseCurrentPatient.m_StrRegisterId = strRegisterID;
                }
                #endregion

                m_mthIsReadOnly();
                if (!m_blnCanShowRecordContent())
                {
                    clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                    return;
                }

				//获取病人记录列表
				clsTransDataInfo[] objTansDataInfoArr;
				lngRes = m_objRecordsDomain.m_lngGetTransDataInfoArr(m_strInPatientID,m_strInPatientDate,out objTansDataInfoArr);

				if(lngRes <= 0 || objTansDataInfoArr == null)
				{
					return;
				} 
		
				//按记录时间(CreateDate)排序
				m_mthSortTransData(ref objTansDataInfoArr);

				DataTable dtbAddBlank;
				clsDiseaseTrackAddBlankDomain objAddBlankDomain = new clsDiseaseTrackAddBlankDomain();
				objAddBlankDomain.m_lngGetBlankRecordContent(m_objCurrentPatient.m_StrInPatientID,m_objCurrentPatient.m_DtmSelectedInDate,out dtbAddBlank);

				//添加记录到的DataTable
				object [][] objDataArr;
				for(int i1=0;i1<objTansDataInfoArr.Length;i1++)
				{ 
					if(dtbAddBlank !=null && dtbAddBlank.Rows.Count>0)
					{
						//查找记录之前有否空行记录,有插入空行
						foreach(DataRow drtAdd in dtbAddBlank.Rows) 
						{
							if(objTansDataInfoArr[i1].m_objRecordContent !=null)
							{
								if(objTansDataInfoArr[i1].m_objRecordContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss") == DateTime.Parse(drtAdd["opendate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss"))
								{
									object[] objBlank = new object[5];
									objBlank[1] = 100;
									objBlank[2] = drtAdd[2].ToString();
									m_dtbRecords.Rows.Add(objBlank);
									for(int k3 = 0; k3 < (Int32.Parse( drtAdd[3].ToString())-1); k3++)
									{
										m_dtbRecords.Rows.Add(new object[]{});
									}
									break;
								}
							}
						}
					}
					
					m_dtcCustom1.HeaderText = "";
					m_dtcCustom2.HeaderText = "";
					m_dtcA.HeaderText = "";
					m_dtcSPO2.HeaderText = "";
					if(i1==0)
					{
						clsICUNurseRecordContentGXDataInfo objITRCInfo=(clsICUNurseRecordContentGXDataInfo)(objTansDataInfoArr[0]);
						if(objITRCInfo != null  && objITRCInfo.m_objRecordArr != null)
						{
							clsICUNurseRecordContentGX objCurrent = objITRCInfo.m_objRecordArr[0];
							if(objCurrent != null)
							{
								m_strCustomColumn1 = objCurrent.m_strCustom1Name == null ?"":objCurrent.m_strCustom1Name;
								m_strCustomColumn2 = objCurrent.m_strCustom2Name == null ?"":objCurrent.m_strCustom2Name;
								m_strCustomColumn3 = objCurrent.m_strCustom3Name == null ?"":objCurrent.m_strCustom3Name;
								m_strCustomColumn4 = objCurrent.m_strCustom4Name == null ?"":objCurrent.m_strCustom4Name;
								m_mthSetCustomColumnName();
							}
						}
					}

					objDataArr = m_objGetRecordsValueArr(objTansDataInfoArr[i1]);
					
					if(objDataArr==null)
						continue;
                    m_dtbRecords.BeginLoadData();
					for(int j2=0;j2<objDataArr.Length;j2++)
					{
                        //m_dtbRecords.Rows.Add(objDataArr[j2] );	
                        m_dtbRecords.LoadDataRow(objDataArr[j2],true);
					}
                    m_dtbRecords.EndLoadData();
                    m_dtgRecordDetail.EnsureVisible(m_dtbRecords.Rows.Count - 1);
				}	

				if(m_dtbRecords.Rows.Count == 0 && !m_blnIfNewDeletedRecord)
				{
					m_mthAutoAddNewRecord();
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
			}
		}
		#endregion

		/// <summary>
		/// 设置自定义列头
		/// </summary>
		private void m_mthSetCustomColumnName()
		{
			m_dtcCustom1.HeaderText = m_strCustomColumn1;
			m_dtcCustom2.HeaderText = m_strCustomColumn2;
			m_dtcA.HeaderText = m_strCustomColumn3;
			m_dtcSPO2.HeaderText = m_strCustomColumn4;
		}
		#region 打印要增加的代码
		DateTime m_dtmPrintOpenDate = DateTime.Now;
		protected override infPrintRecord m_objGetPrintTool()
		{
			#region 取相应的数据
			clsICUNurseRecord_GX_PrintTool objPrintTool = new clsICUNurseRecord_GX_PrintTool();
			objPrintTool.m_strDiseaseID = this.m_txtDiseaseID.Text.Trim();
			objPrintTool.m_dtmCreateDate = m_dtpCreateDate.Value;
            objPrintTool.m_strInPatientID = m_objCurrentPatient.m_StrEMRInPatientID;

			objPrintTool.m_strCustomColumn1 = m_strCustomColumn1;
			objPrintTool.m_strCustomColumn2 = m_strCustomColumn2;
			objPrintTool.m_strCustomColumn3 = m_strCustomColumn3;
			objPrintTool.m_strCustomColumn4 = m_strCustomColumn4;

            if (m_objCurrentPatient != null && m_ObjCurrentEmrPatientSession != null)
            {
                objPrintTool.m_strInPatientDate = m_ObjCurrentEmrPatientSession.m_dtmHISInpatientDate.ToString("yyyy-MM-dd HH:mm:ss");
                objPrintTool.m_strName = m_objCurrentPatient.m_ObjPeopleInfo.m_StrLastName;
                objPrintTool.m_strSex = m_objCurrentPatient.m_ObjPeopleInfo.m_StrSex;
                objPrintTool.m_strAge = m_objCurrentPatient.m_ObjPeopleInfo.m_StrAge;
                objPrintTool.m_strBedCode = m_objCurrentPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName;
            }
            else
            {
                objPrintTool.m_strInPatientDate = string.Empty;
                objPrintTool.m_strName = string.Empty;
                objPrintTool.m_strSex = string.Empty;
                objPrintTool.m_strAge = string.Empty;
                objPrintTool.m_strBedCode = string.Empty;
            }				
			
			DataTable dt = this.m_dtbRecords.Clone();
			m_mthGetData(dt);//得到相应数据
			DataTable dtPrint = m_dtbCreateDataTable(dt);//得到要打印的带数据的表
			objPrintTool.m_dtmPrintOpenDate = m_dtmPrintOpenDate;
			objPrintTool.m_mthSetDataSource(dtPrint);
			#endregion
			#region 设置显示每一列的宽度百分比
			float[] fltArrColumnPercent = new float[14];
			fltArrColumnPercent[0] = 0.04761905F; 
			fltArrColumnPercent[1] = 0.04761905F * 3;
			fltArrColumnPercent[2] = 0.04761905F;
			fltArrColumnPercent[3] = 0.04761905F;
			fltArrColumnPercent[4] = 0.04761905F;
			fltArrColumnPercent[5] = 0.04761905F;
			fltArrColumnPercent[6] = 0.04761905F;
			fltArrColumnPercent[7] = 0.04761905F;
			fltArrColumnPercent[8] = 0.04761905F;
			fltArrColumnPercent[9] = 0.04761905F;
			fltArrColumnPercent[10] = 0.04761905F;
			fltArrColumnPercent[11] = 0.04761905F;
			fltArrColumnPercent[12] = 0.04761905F;
			fltArrColumnPercent[13] = 0.04761905F * 3+0.04761905F * 3;
			//	fltArrColumnPercent[14] = 0;//0.04761905F * 3
			objPrintTool.ColumnPercentArr = fltArrColumnPercent;
			#endregion
			return objPrintTool;
		}
		#region  这三个函数的目的是:把一般情况与小结重新分行.减少一行的显示长度,返回一个指定格式的数据表
		private  DataTable m_dtbCreateDataTable(DataTable p_dtb)
		{
			DataTable dtTemp = new DataTable();
            dtTemp.TableName = "ICU护理记录";
			dtTemp.Columns.Add("RecordTimeOfDate");//5
			dtTemp.Columns.Add("InAmountItem");//6
			dtTemp.Columns.Add("InAmountStandby");//7
			dtTemp.Columns.Add("InAmountFact");//8
			dtTemp.Columns.Add("OutEmiction");//9
			dtTemp.Columns.Add("Custom1");
			dtTemp.Columns.Add("Custom2");
			dtTemp.Columns.Add("Temperature");//9
			dtTemp.Columns.Add("HR");//10	
			dtTemp.Columns.Add("Respiration");//11
			dtTemp.Columns.Add("BP");
			dtTemp.Columns.Add("A");
			dtTemp.Columns.Add("SPO2");
			dtTemp.Columns.Add("GenaralInstance");
			//dtTemp.Columns.Add("Sum");
			DataRow dr = null;
			for(int i=0;i<p_dtb.Rows.Count;++i)
			{
				dr = dtTemp.NewRow();
				dr["RecordTimeOfDate"] = p_dtb.Rows[i]["RecordTimeOfDate"].ToString();
				dr["InAmountItem"] = m_strGetFomatDataByObject(p_dtb.Rows[i]["InAmountItem"]);
				dr["InAmountStandby"] = m_strGetFomatDataByObject(p_dtb.Rows[i]["InAmountStandby"]);
				dr["InAmountFact"] = m_strGetFomatDataByObject(p_dtb.Rows[i]["InAmountFact"]);
				dr["OutEmiction"] = m_strGetFomatDataByObject(p_dtb.Rows[i]["OutEmiction"]);
				dr["Custom1"] = m_strGetFomatDataByObject(p_dtb.Rows[i]["Custom1"]);
				dr["Custom2"] = m_strGetFomatDataByObject(p_dtb.Rows[i]["Custom2"]);
				dr["Temperature"] = m_strGetFomatDataByObject(p_dtb.Rows[i]["Temperature"]);
				dr["HR"] = m_strGetFomatDataByObject(p_dtb.Rows[i]["HR"]);
				dr["Respiration"] = m_strGetFomatDataByObject(p_dtb.Rows[i]["Respiration"]);
				dr["BP"] = m_strGetFomatDataByObject(p_dtb.Rows[i]["BP"]);
				dr["A"] = m_strGetFomatDataByObject(p_dtb.Rows[i]["A"]);
				dr["SPO2"] = m_strGetFomatDataByObject(p_dtb.Rows[i]["SPO2"]);
				dr["GenaralInstance"] = m_strGetFomatDataByObject(p_dtb.Rows[i]["GenaralInstance"]);
				//dr["Sum"] = m_strGetFomatDataByObject(p_dtb.Rows[i]["Sum"]);
				dtTemp.Rows.Add(dr);
			}
			return dtTemp;
		}
		/// <summary>
		/// 转换
		/// </summary>
		/// <param name="p_obj"></param>
		/// <returns></returns>
		private string m_strGetFomatDataByObject(object p_obj)
		{
			string strResult = null;
			if(p_obj != System.DBNull.Value)
			{
				com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue clsobj = (com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue)p_obj;
				if(clsobj != null)
					strResult = clsobj.m_strText;
				else
					strResult = "";
			}
			else
			{
				strResult = "";
			}
			return 	strResult ;
		}
		/// <summary>
		/// 转换得时间
		/// </summary>
		/// <param name="p_obj"></param>
		/// <returns></returns>
		private string m_strGetDateTimeStringByObject(object p_obj)
		{
			string strResult = null;
			if(p_obj != System.DBNull.Value)
			{
				try
				{
					strResult = Convert.ToDateTime(p_obj).ToString("HH:mm");//时间字符串
				}
				catch
				{
					strResult = "";
				}
			}
			else
			{
				strResult = "";
			}
			return 	strResult ;
		}
		protected  object[][] m_objGetValueArrNew(clsTransDataInfo p_objTransDataInfo)
		{
			#region 显示记录到DataGrid
			try
			{
				object[] objData;
				ArrayList objReturnData=new ArrayList();

				clsICUNurseRecordContentGXDataInfo objICUInfo=new clsICUNurseRecordContentGXDataInfo();			
				clsDSTRichTextBoxValue objclsDSTRichTextBoxValue;
				string strText,strXml;

				objICUInfo = (clsICUNurseRecordContentGXDataInfo)p_objTransDataInfo;

				if(objICUInfo.m_objRecordArr == null)
					return null;

				#region 获取修改限定时间
				int intCanModifyTime = 0;
				try
				{
					intCanModifyTime = int.Parse(m_strCanModifyTime);
				}
				catch
				{
					intCanModifyTime = 6;
				}
				#endregion

				int intRecordCount = objICUInfo.m_objRecordArr.Length;
				int intRowOfCurrentDetail = 0;
				m_dtmPreRecordDate =DateTime.MinValue;
				for(int i=0; i<intRecordCount; i++)
				{
					objData = new object[21];   
					clsICUNurseRecordContentGX objCurrent = objICUInfo.m_objRecordArr[i];
					clsICUNurseRecordContentGX objNext = new clsICUNurseRecordContentGX();//下一条护理记录
					if(i < intRecordCount-1)
						objNext = objICUInfo.m_objRecordArr[i+1];

					//如果该护理记录是修改前的记录且是在指定时间内修改的，修改者与创建者为同一人，则不显示
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strModifyUserID.Trim()==objCurrent.m_strCreateUserID.Trim())
					{
						TimeSpan tsModify =  objNext.m_dtmModifyDate-objCurrent.m_dtmModifyDate;
						if((int)tsModify.TotalHours < intCanModifyTime)
							continue;
					}

					#region 存放关键字段
					if(objCurrent.m_dtmCreateDate!=DateTime.MinValue)
					{
						objData[0] = objCurrent.m_dtmCreateDate;//存放记录时间的字符串
						objData[1] = (int)enmRecordsType.ICUNurseRecord_GX;//存放记录类型的int值
						objData[2] = objCurrent.m_dtmOpenDate;//存放记录的OpenDate字符串
						m_dtmPrintOpenDate = objCurrent.m_dtmOpenDate;
						objData[3] = objCurrent.m_dtmModifyDate;//存放记录的ModifyDate字符串   
						
						//同一天则只在第一行显示日期
						if(objCurrent.m_dtmCreateDate.Date.ToString() != m_dtmPreRecordDate.Date.ToString())
						{
							objData[4] = objCurrent.m_dtmCreateDate.Date.ToString("yyyy-MM-dd") ;//日期字符串
						}
						//修改后带有痕迹的记录不再显示时间
						if(m_dtmPreRecordDate != objCurrent.m_dtmCreateDate)
							objData[5] = objCurrent.m_dtmCreateDate.ToString("HH:mm");//时间字符串
	
					}
					m_dtmPreRecordDate = objCurrent.m_dtmCreateDate;	
					#endregion ;

					#region 存放单项信息
					//入量项目
					strText = objCurrent.m_strINAMOUNTITEM_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strINAMOUNTITEM_RIGHT != objCurrent.m_strINAMOUNTITEM_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strINAMOUNTITEM_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[6] = objclsDSTRichTextBoxValue;//T
			
					//备用量
					strText = objCurrent.m_strINAMOUNTSTANDBY_RIGHT ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strINAMOUNTSTANDBY_RIGHT != objCurrent.m_strINAMOUNTSTANDBY_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strINAMOUNTSTANDBY_RIGHT,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[7] = objclsDSTRichTextBoxValue;//HR

					//实入量
					strText = objCurrent.m_strINAMOUNTFACT_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strINAMOUNTFACT_RIGHT != objCurrent.m_strINAMOUNTFACT_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strINAMOUNTFACT_RIGHT,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[8] = objclsDSTRichTextBoxValue;//P

			
					//尿
					strText = objCurrent.m_strOUTEMICTION_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strOUTEMICTION_RIGHT != objCurrent.m_strOUTEMICTION_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strOUTEMICTION_RIGHT,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[9] = objclsDSTRichTextBoxValue;//

					//自定义列1
					strText = objCurrent.m_strCustom1_Right;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strCustom1_Right != objCurrent.m_strCustom1_Right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strCustom1_Right,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[10] = objclsDSTRichTextBoxValue;

					//自定义列2
					strText = objCurrent.m_strCustom2_Right;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strCustom2_Right != objCurrent.m_strCustom2_Right)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strCustom2_Right,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[11] = objclsDSTRichTextBoxValue;
			
					//T
					strText = objCurrent.m_strTEMPERATURE_RIGHT ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strTEMPERATURE_RIGHT != objCurrent.m_strTEMPERATURE_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strTEMPERATURE_RIGHT,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[12] = objclsDSTRichTextBoxValue;//

					//HR
					strText = objCurrent.m_strHR_RIGHT ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strHR_RIGHT != objCurrent.m_strHR_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strHR_RIGHT,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[13] = objclsDSTRichTextBoxValue;//

					//R
					strText = objCurrent.m_strRESPIRATION_RIGHT ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strRESPIRATION_RIGHT != objCurrent.m_strRESPIRATION_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strRESPIRATION_RIGHT,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[14] = objclsDSTRichTextBoxValue;//

					//BP
					strText = objCurrent.m_strBLOODPRESSUREA_RIGHT + "/" + objCurrent.m_strBLOODPRESSURES_RIGHT ;
					string strNextText = "";
					if(objNext != null)
						strNextText = objNext.m_strBLOODPRESSUREA_RIGHT + "/" + objNext.m_strBLOODPRESSURES_RIGHT ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && strNextText != strText)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(strText,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[15] = objclsDSTRichTextBoxValue;//

					//自定义列3
					strText = objCurrent.m_strA_RIGHT ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strA_RIGHT != objCurrent.m_strA_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strA_RIGHT,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[16] = objclsDSTRichTextBoxValue;//

					//自定义列4
					strText = objCurrent.m_strSP02_RIGHT ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strSP02_RIGHT != objCurrent.m_strSP02_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strSP02_RIGHT,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[17] = objclsDSTRichTextBoxValue;//

					//一般情况
					string[] strGeneralInstanceArr = null;
					string[] strGeneralInstanceXMLArr = null;
					if(objCurrent.m_strGENERALINSTANCE_RIGHT != null ||objCurrent.m_strGENERALINSTANCE_RIGHT != "")
					{
						string strGeneralInstance = objCurrent.m_strGENERALINSTANCE + "\n"+"小结:"+objCurrent.m_strSummary_Right;
                        if (objCurrent.m_strSummary_Right == null || objCurrent.m_strSummary_Right == string.Empty)
                            strGeneralInstance = objCurrent.m_strGENERALINSTANCE;
						string strGeneralInstanceXML = objCurrent.m_strGENERALINSTANCEXML;
						string[] strGeneralInstanceArrTemp;
						string[] strGeneralInstanceXMLArrTemp;
						//将病情记录分行。
						com.digitalwave.controls.ctlRichTextBox.m_mthSplitXmlByBytes(strGeneralInstance,strGeneralInstanceXML,26,out strGeneralInstanceArrTemp,out strGeneralInstanceXMLArrTemp);
						
						if(objCurrent.m_strCreateUserName != null && objCurrent.m_strCreateUserName != "")
						{
							strGeneralInstanceArr = new string[strGeneralInstanceArrTemp.Length + 1];
							strGeneralInstanceXMLArr = new string[strGeneralInstanceXMLArrTemp.Length + 1];

							for(int j=0; j<strGeneralInstanceArr.Length-1; j++)
							{
								strGeneralInstanceArr[j] = strGeneralInstanceArrTemp[j];
							}
							strGeneralInstanceArr[strGeneralInstanceArr.Length-1] = "           " + objCurrent.m_dtmCreateDate.ToString("yy-MM-dd")+" "+objCurrent.m_strCreateUserName;
							
							strGeneralInstanceXMLArr[strGeneralInstanceXMLArr.Length-1] = "";
							for(int j=0; j<strGeneralInstanceXMLArr.Length-1; j++)
							{
								strGeneralInstanceXMLArr[j] = strGeneralInstanceXMLArrTemp[j];
							}
						}
						else
						{
							strGeneralInstanceArr = strGeneralInstanceArrTemp;
							strGeneralInstanceXMLArr = strGeneralInstanceXMLArrTemp;
						}

						strText = strGeneralInstanceArr[0];
						strXml = strGeneralInstanceXMLArr[0];
						objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
						objclsDSTRichTextBoxValue.m_strText=strText;						
						objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
						objData[18] = objclsDSTRichTextBoxValue;
					}

					//小结
					string[] strSumArr = null;
					string[] strSuXMLArr = null;
					objCurrent.m_strSummary_Right ="";//取消小结打印
					if(objCurrent.m_strSummary_Right != null ||objCurrent.m_strSummary_Right != "")
					{
						string strSum = objCurrent.m_strSummary;
						string strSumXML = objCurrent.m_strSummaryXML;
						//将小结分行。
						com.digitalwave.controls.ctlRichTextBox.m_mthSplitXmlByBytes(strSum,strSumXML,10,out strSumArr,out strSuXMLArr);

						strText = strSumArr[0];
						strXml = strSuXMLArr[0];
						objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
						objclsDSTRichTextBoxValue.m_strText=strText;						
						objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
						objData[19] = objclsDSTRichTextBoxValue;
					}
					objData[20] = objCurrent.m_strCreateUserID;

					objReturnData.Add(objData);
					
					int intGenerArrLength = 0;
					int intSumLength = 0;
					if(strGeneralInstanceArr != null)
						intGenerArrLength = strGeneralInstanceArr.Length;
					if(strSumArr != null)
						intSumLength = strSumArr.Length;
					int intMaxLength = intGenerArrLength > intSumLength ? intGenerArrLength:intSumLength;
					if(intMaxLength > 0)
					{
						object[] objInstance = null;
						for(int j=0; j<intMaxLength; j++)
						{
							objInstance = new object[21];

							if(j < intGenerArrLength && j > 0)
							{
								strText = strGeneralInstanceArr[j];
								strXml = strGeneralInstanceXMLArr[j];
								objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
								objclsDSTRichTextBoxValue.m_strText=strText;						
								objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
								objInstance[18] = objclsDSTRichTextBoxValue;
							}

							if(j < intSumLength && j > 0)
							{
								strText = strSumArr[j];
								strXml = strSuXMLArr[j];
								objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
								objclsDSTRichTextBoxValue.m_strText=strText;						
								objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
								objInstance[19] = objclsDSTRichTextBoxValue;
							}

							if(objInstance[18] != null || objInstance[19] != null)
							{
								objInstance[20] = objCurrent.m_strCreateUserID;

								objReturnData.Add(objInstance);
							}
						}
					}

					if(objCurrent.m_intISSTAT == 1)
					{
						//如果该记录只记录了统计信息，则将上面已添加的该记录删除
						bool isOnlySum = true;
						String strTemp = "";
						for(int n=6; n<=19; n++)
						{
							//							strTemp = ((clsDSTRichTextBoxValue)((object[])objReturnData[objReturnData.Count-1])[n]).m_strText;
							//							if(strTemp != ""&& strTemp!=null)
							//								isOnlySum = false;
							if(((object[])objReturnData[objReturnData.Count-1])[n] != null)
								isOnlySum = false;
						}
						if(isOnlySum)
						{
							//当该记录只记录了统计信时不再显示该记录的时间
							((object[])objReturnData[objReturnData.Count-1])[5] = null;
							((object[])objReturnData[objReturnData.Count-1])[4] = null;
						}

						object[] objSum = null;
						objSum = new object[21];
						strText = objCurrent.m_intSUMINTIME.ToString()+" h总入量：";
						strXml =  "<root />";
						strXml = m_strGetDSTTextXML(strText,MDIParent.OperatorID,MDIParent.OperatorName);
						objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
						objclsDSTRichTextBoxValue.m_strText=strText;						
						objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
						objclsDSTRichTextBoxValue.m_blnUnderDST = true;
						objSum[6] = objclsDSTRichTextBoxValue;

						strText = objCurrent.m_strSUMIN;
						strXml =  "<root />";
						strXml = m_strGetDSTTextXML(strText,MDIParent.OperatorID,MDIParent.OperatorName);
						objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
						objclsDSTRichTextBoxValue.m_strText=strText;						
						objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
						objclsDSTRichTextBoxValue.m_blnUnderDST = true;
						objSum[7] = objclsDSTRichTextBoxValue;
                        objSum[20] = objCurrent.m_strCreateUserID;
						objReturnData.Add(objSum);

                        objSum = new object[21];
                        strText = "备用量总入量：";
                        strXml = "<root />";
                        strXml = m_strGetDSTTextXML(strText, MDIParent.OperatorID, MDIParent.OperatorName);
                        objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                        objclsDSTRichTextBoxValue.m_strText = strText;
                        objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                        objclsDSTRichTextBoxValue.m_blnUnderDST = true;
                        objSum[6] = objclsDSTRichTextBoxValue;

                        strText = objCurrent.m_strINSTANDBYSUM;
                        strXml = "<root />";
                        strXml = m_strGetDSTTextXML(strText, MDIParent.OperatorID, MDIParent.OperatorName);
                        objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                        objclsDSTRichTextBoxValue.m_strText = strText;
                        objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                        objclsDSTRichTextBoxValue.m_blnUnderDST = true;
                        objSum[7] = objclsDSTRichTextBoxValue;
                        objSum[20] = objCurrent.m_strCreateUserID;
                        objReturnData.Add(objSum);

                        objSum = new object[21];
                        strText = "实入量总入量：";
                        strXml = "<root />";
                        strXml = m_strGetDSTTextXML(strText, MDIParent.OperatorID, MDIParent.OperatorName);
                        objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                        objclsDSTRichTextBoxValue.m_strText = strText;
                        objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                        objclsDSTRichTextBoxValue.m_blnUnderDST = true;
                        objSum[6] = objclsDSTRichTextBoxValue;

                        strText = objCurrent.m_strINFACTSUM;
                        strXml = "<root />";
                        strXml = m_strGetDSTTextXML(strText, MDIParent.OperatorID, MDIParent.OperatorName);
                        objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                        objclsDSTRichTextBoxValue.m_strText = strText;
                        objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                        objclsDSTRichTextBoxValue.m_blnUnderDST = true;
                        objSum[7] = objclsDSTRichTextBoxValue;
                        objSum[20] = objCurrent.m_strCreateUserID;
                        objReturnData.Add(objSum);


						objSum = new object[21];
						strText = objCurrent.m_intSUMOUTTIME.ToString()+" h总出量：";
						strXml =  "<root />";
						strXml = m_strGetDSTTextXML(strText,MDIParent.OperatorID,MDIParent.OperatorName);
						objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
						objclsDSTRichTextBoxValue.m_strText=strText;						
						objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
						objclsDSTRichTextBoxValue.m_blnUnderDST = true;
						objSum[6] = objclsDSTRichTextBoxValue;

						strText = objCurrent.m_strSUMOUT;
						strXml =  "<root />";
						strXml = m_strGetDSTTextXML(strText,MDIParent.OperatorID,MDIParent.OperatorName);
						objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
						objclsDSTRichTextBoxValue.m_strText=strText;						
						objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
						objclsDSTRichTextBoxValue.m_blnUnderDST = true;
						objSum[7] = objclsDSTRichTextBoxValue;
                        objSum[20] = objCurrent.m_strCreateUserID;
						objReturnData.Add(objSum);

                        objSum = new object[21];
                        strText = "尿量总出量：";
                        strXml = "<root />";
                        strXml = m_strGetDSTTextXML(strText, MDIParent.OperatorID, MDIParent.OperatorName);
                        objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                        objclsDSTRichTextBoxValue.m_strText = strText;
                        objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                        objclsDSTRichTextBoxValue.m_blnUnderDST = true;
                        objSum[6] = objclsDSTRichTextBoxValue;

                        strText = objCurrent.m_strOUTEMICTIONSUM;
                        strXml = "<root />";
                        strXml = m_strGetDSTTextXML(strText, MDIParent.OperatorID, MDIParent.OperatorName);
                        objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                        objclsDSTRichTextBoxValue.m_strText = strText;
                        objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                        objclsDSTRichTextBoxValue.m_blnUnderDST = true;
                        objSum[7] = objclsDSTRichTextBoxValue;
                        objSum[20] = objCurrent.m_strCreateUserID;
                        objReturnData.Add(objSum);

                        string[] strCustomNameArr = null;
                        objSum = new object[21];
                        string strCustomName = "";
                        if (objCurrent.m_strCustom1Name != null && objCurrent.m_strCustom1Name != string.Empty)
                        {
                            strCustomNameArr = objCurrent.m_strCustom1Name.Split(new char[] { '\r', '\n' });
                            for (int m = 0; m < strCustomNameArr.Length; m++)
                            {
                                strCustomName += strCustomNameArr[m];
                            }
                        }
                        else
                            strCustomName = "自定义列1";
                        strText = strCustomName + "总出量：";
                        strXml = "<root />";
                        strXml = m_strGetDSTTextXML(strText, MDIParent.OperatorID, MDIParent.OperatorName);
                        objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                        objclsDSTRichTextBoxValue.m_strText = strText;
                        objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                        objclsDSTRichTextBoxValue.m_blnUnderDST = true;
                        objSum[6] = objclsDSTRichTextBoxValue;

                        strText = objCurrent.m_strOUTCUSTOM1SUM;
                        strXml = "<root />";
                        strXml = m_strGetDSTTextXML(strText, MDIParent.OperatorID, MDIParent.OperatorName);
                        objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                        objclsDSTRichTextBoxValue.m_strText = strText;
                        objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                        objclsDSTRichTextBoxValue.m_blnUnderDST = true;
                        objSum[7] = objclsDSTRichTextBoxValue;
                        objSum[20] = objCurrent.m_strCreateUserID;
                        objReturnData.Add(objSum);

                        objSum = new object[21];
                        strCustomName = "";
                        if (objCurrent.m_strCustom2Name != null && objCurrent.m_strCustom2Name != string.Empty)
                        {
                            strCustomNameArr = objCurrent.m_strCustom2Name.Split(new char[] { '\r', '\n' });
                            for (int m = 0; m < strCustomNameArr.Length; m++)
                            {
                                strCustomName += strCustomNameArr[m];
                            }
                        }
                        else
                            strCustomName = "自定义列2";
                        strText = strCustomName + "总出量：";
                        strXml = "<root />";
                        strXml = m_strGetDSTTextXML(strText, MDIParent.OperatorID, MDIParent.OperatorName);
                        objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                        objclsDSTRichTextBoxValue.m_strText = strText;
                        objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                        objclsDSTRichTextBoxValue.m_blnUnderDST = true;
                        objSum[6] = objclsDSTRichTextBoxValue;

                        strText = objCurrent.m_strOUTCUSTOM2SUM;
                        strXml = "<root />";
                        strXml = m_strGetDSTTextXML(strText, MDIParent.OperatorID, MDIParent.OperatorName);
                        objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                        objclsDSTRichTextBoxValue.m_strText = strText;
                        objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                        objclsDSTRichTextBoxValue.m_blnUnderDST = true;
                        objSum[7] = objclsDSTRichTextBoxValue;
                        if (objCurrent.m_strCreateUserName != "" && objCurrent.m_strCreateUserName != null)
                        {
                            strText = objCurrent.m_strCreateUserName;
                            strXml = "<root />";
                            objclsDSTRichTextBoxValue = new clsDSTRichTextBoxValue();
                            objclsDSTRichTextBoxValue.m_strText = strText;
                            objclsDSTRichTextBoxValue.m_strDSTXml = strXml;
                            objSum[18] = objclsDSTRichTextBoxValue;
                        }
                        objSum[20] = objCurrent.m_strCreateUserID;
                        objReturnData.Add(objSum);
					}
					#endregion
				}
				object[][] m_objRe=new object[objReturnData.Count][];

				for(int m=0;m<objReturnData.Count ;m++)
					m_objRe[m]=(object[])objReturnData[m];
				return m_objRe;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message );
				return null;
			}
			#endregion
		}
		private void m_mthGetData(DataTable p_dtReturnSource)
		{
			try
			{

				if(m_ObjCurrentEmrPatientSession == null || m_objCurrentPatient==null)
				{						
					return;
				}
				p_dtReturnSource.Rows.Clear();
				//获取病人记录列表
				clsTransDataInfo[] objTansDataInfoArr;
				string m_strInPatientID = m_objCurrentPatient.m_StrInPatientID;
                string m_strInPatientDate = m_objCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"); 
				long lngRes = m_objRecordsDomain.m_lngGetTransDataInfoArr(m_strInPatientID,m_strInPatientDate,out objTansDataInfoArr);

				if(lngRes <= 0 || objTansDataInfoArr == null)
				{
					return;
				} 
				//按记录时间(CreateDate)排序
				m_mthSortTransData(ref objTansDataInfoArr);
				//添加记录到的DataTable
				object [][] objDataArr;
				for(int i1=0;i1<objTansDataInfoArr.Length;i1++)
				{ 
					objDataArr = m_objGetValueArrNew(objTansDataInfoArr[i1]);
					
					if(objDataArr==null)
						continue;

					for(int j2=0;j2<objDataArr.Length;j2++)
					{
						p_dtReturnSource.Rows.Add(objDataArr[j2] );	
					}
				}	
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
			}
		}
		#endregion 
		#endregion 

        protected override void m_mthPerformSessionChanged(clsEmrPatientSessionInfo_VO p_objSelectedSession, int p_intIndex)
        {
            if (p_objSelectedSession == null) return;
            try
            {
                //清空病人记录信息
                if (m_dtgRecordDetail != null)
                {
                    m_mthClearPatientRecordInfo();
                }

                if (p_objSelectedSession == null || m_objCurrentPatient == null)
                {
                    return;
                }

                m_objCurrentPatient.m_DtmSelectedInDate = p_objSelectedSession.m_dtmEMRInpatientDate;
                m_objCurrentPatient.m_StrHISInPatientID = p_objSelectedSession.m_strHISInpatientId;
                m_objCurrentPatient.m_DtmSelectedHISInDate = p_objSelectedSession.m_dtmHISInpatientDate;

                m_objCurrentPatient.m_StrRegisterId = p_objSelectedSession.m_strRegisterId;
                m_objBaseCurrentPatient.m_StrRegisterId = p_objSelectedSession.m_strRegisterId;
                
                //设置病人当次住院的基本信息
                m_mthOnlySetPatientInfo(m_objCurrentPatient);

                m_mthIsReadOnly();
                if (!m_blnCanShowRecordContent())
                {
                    clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                    return;
                }

                //获取病人记录列表
                clsTransDataInfo[] objTansDataInfoArr;
                long lngRes = m_objRecordsDomain.m_lngGetTransDataInfoArr(p_objSelectedSession.m_strEMRInpatientId, p_objSelectedSession.m_dtmEMRInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"), out objTansDataInfoArr);

                if (lngRes <= 0 || objTansDataInfoArr == null)
                {
                    return;
                }

                //按记录时间(CreateDate)排序
                m_mthSortTransData(ref objTansDataInfoArr);

                DataTable dtbAddBlank;
                clsDiseaseTrackAddBlankDomain objAddBlankDomain = new clsDiseaseTrackAddBlankDomain();
                objAddBlankDomain.m_lngGetBlankRecordContent(m_objCurrentPatient.m_StrInPatientID, m_objCurrentPatient.m_DtmSelectedInDate, out dtbAddBlank);

                //添加记录到的DataTable
                object[][] objDataArr;
                for (int i1 = 0; i1 < objTansDataInfoArr.Length; i1++)
                {
                    if (dtbAddBlank != null && dtbAddBlank.Rows.Count > 0)
                    {
                        //查找记录之前有否空行记录,有插入空行
                        foreach (DataRow drtAdd in dtbAddBlank.Rows)
                        {
                            if (objTansDataInfoArr[i1].m_objRecordContent != null)
                            {
                                if (objTansDataInfoArr[i1].m_objRecordContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss") == DateTime.Parse(drtAdd["opendate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss"))
                                {
                                    object[] objBlank = new object[5];
                                    objBlank[1] = 100;
                                    objBlank[2] = drtAdd[2].ToString();
                                    m_dtbRecords.Rows.Add(objBlank);
                                    for (int k3 = 0; k3 < (Int32.Parse(drtAdd[3].ToString()) - 1); k3++)
                                    {
                                        m_dtbRecords.Rows.Add(new object[] { });
                                    }
                                    break;
                                }
                            }
                        }
                    }

                    m_dtcCustom1.HeaderText = "";
                    m_dtcCustom2.HeaderText = "";
                    m_dtcA.HeaderText = "";
                    m_dtcSPO2.HeaderText = "";
                    if (i1 == 0)
                    {
                        clsICUNurseRecordContentGXDataInfo objITRCInfo = (clsICUNurseRecordContentGXDataInfo)(objTansDataInfoArr[0]);
                        if (objITRCInfo != null && objITRCInfo.m_objRecordArr != null)
                        {
                            clsICUNurseRecordContentGX objCurrent = objITRCInfo.m_objRecordArr[0];
                            if (objCurrent != null)
                            {
                                m_strCustomColumn1 = objCurrent.m_strCustom1Name == null ? "" : objCurrent.m_strCustom1Name;
                                m_strCustomColumn2 = objCurrent.m_strCustom2Name == null ? "" : objCurrent.m_strCustom2Name;
                                m_strCustomColumn3 = objCurrent.m_strCustom3Name == null ? "" : objCurrent.m_strCustom3Name;
                                m_strCustomColumn4 = objCurrent.m_strCustom4Name == null ? "" : objCurrent.m_strCustom4Name;
                                m_mthSetCustomColumnName();
                            }
                        }
                    }

                    objDataArr = m_objGetRecordsValueArr(objTansDataInfoArr[i1]);

                    if (objDataArr == null)
                        continue;
                    m_dtbRecords.BeginLoadData();
                    for (int j2 = 0; j2 < objDataArr.Length; j2++)
                    {
                        //m_dtbRecords.Rows.Add(objDataArr[j2] );	
                        m_dtbRecords.LoadDataRow(objDataArr[j2], true);
                    }
                    m_dtbRecords.EndLoadData();
                    m_dtgRecordDetail.EnsureVisible(m_dtbRecords.Rows.Count - 1);
                }

                if (m_dtbRecords.Rows.Count == 0 && !m_blnIfNewDeletedRecord)
                {
                    m_mthAutoAddNewRecord();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }
        protected virtual void m_mthInitPrintData(clsICUNurseRecord_GX_PrintTool p_objPrintTool, clsPatient p_objPatient)
        {
            if (p_objPatient == null) return;
            p_objPrintTool.m_strDiseaseID = p_objPatient.m_StrInPatientID;
            p_objPrintTool.m_dtmCreateDate = m_dtpCreateDate.Value;
            p_objPrintTool.m_strInPatientID = p_objPatient.m_StrEMRInPatientID;

            p_objPrintTool.m_strInPatientDate = p_objPatient.m_DtmSelectedHISInDate.ToString("yyyy-MM-dd HH:mm:ss");
            p_objPrintTool.m_strName = p_objPatient.m_ObjPeopleInfo.m_StrLastName;
            p_objPrintTool.m_strSex = p_objPatient.m_ObjPeopleInfo.m_StrSex;
            p_objPrintTool.m_strAge = p_objPatient.m_ObjPeopleInfo.m_StrAge;
            p_objPrintTool.m_strBedCode = p_objPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName;
           		
            DataTable dt = this.m_dtbRecords.Clone();
            m_mthGetDataForInPatientCaseHistory(dt, p_objPatient);//得到相应数据
			DataTable dtPrint = m_dtbCreateDataTable(dt);//得到要打印的带数据的表

            p_objPrintTool.m_strCustomColumn1 = m_strCustomColumn1;
            p_objPrintTool.m_strCustomColumn2 = m_strCustomColumn2;
            p_objPrintTool.m_strCustomColumn3 = m_strCustomColumn3;
            p_objPrintTool.m_strCustomColumn4 = m_strCustomColumn4;

            p_objPrintTool.m_dtmPrintOpenDate = m_dtmPrintOpenDate;
            p_objPrintTool.m_mthSetDataSource(dtPrint);
			
			#region 设置显示每一列的宽度百分比
			float[] fltArrColumnPercent = new float[14];
			fltArrColumnPercent[0] = 0.04761905F; 
			fltArrColumnPercent[1] = 0.04761905F * 3;
			fltArrColumnPercent[2] = 0.04761905F;
			fltArrColumnPercent[3] = 0.04761905F;
			fltArrColumnPercent[4] = 0.04761905F;
			fltArrColumnPercent[5] = 0.04761905F;
			fltArrColumnPercent[6] = 0.04761905F;
			fltArrColumnPercent[7] = 0.04761905F;
			fltArrColumnPercent[8] = 0.04761905F;
			fltArrColumnPercent[9] = 0.04761905F;
			fltArrColumnPercent[10] = 0.04761905F;
			fltArrColumnPercent[11] = 0.04761905F;
			fltArrColumnPercent[12] = 0.04761905F;
			fltArrColumnPercent[13] = 0.04761905F * 3+0.04761905F * 3;
            #endregion
            p_objPrintTool.ColumnPercentArr = fltArrColumnPercent;
        }
        private void m_mthGetDataForInPatientCaseHistory(DataTable p_dtReturnSource, clsPatient p_objPatient)
        {
            try
            {

                if (p_objPatient == null)
                {
                    return;
                }
                
                //获取病人记录列表
                clsTransDataInfo[] objTansDataInfoArr;
                string m_strInPatientID = p_objPatient.m_StrInPatientID;
                string m_strInPatientDate = p_objPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss");
                long lngRes = m_objRecordsDomain.m_lngGetTransDataInfoArr(m_strInPatientID, m_strInPatientDate, out objTansDataInfoArr);

                if (lngRes <= 0 || objTansDataInfoArr == null)
                {
                    return;
                }
                //按记录时间(CreateDate)排序
                m_mthSortTransData(ref objTansDataInfoArr);

                clsICUNurseRecordContentGXDataInfo objITRCInfo = (clsICUNurseRecordContentGXDataInfo)(objTansDataInfoArr[0]);
                if (objITRCInfo != null && objITRCInfo.m_objRecordArr != null)
                {
                    clsICUNurseRecordContentGX objCurrent = objITRCInfo.m_objRecordArr[0];
                    if (objCurrent != null)
                    {
                        m_strCustomColumn1 = objCurrent.m_strCustom1Name == null ? "" : objCurrent.m_strCustom1Name;
                        m_strCustomColumn2 = objCurrent.m_strCustom2Name == null ? "" : objCurrent.m_strCustom2Name;
                        m_strCustomColumn3 = objCurrent.m_strCustom3Name == null ? "" : objCurrent.m_strCustom3Name;
                        m_strCustomColumn4 = objCurrent.m_strCustom4Name == null ? "" : objCurrent.m_strCustom4Name;
                       
                    }
                }
                m_mthInitDataTable(p_dtReturnSource);
                p_dtReturnSource.Rows.Clear();
                //添加记录到的DataTable
                object[][] objDataArr;
                for (int i1 = 0; i1 < objTansDataInfoArr.Length; i1++)
                {
                    objDataArr = m_objGetValueArrNew(objTansDataInfoArr[i1]);

                    if (objDataArr == null)
                        continue;

                    for (int j2 = 0; j2 < objDataArr.Length; j2++)
                    {
                        p_dtReturnSource.Rows.Add(objDataArr[j2]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }
	}
}
