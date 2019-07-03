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
using com.digitalwave.clsGeneralNurseRecord_GXService ;
namespace iCare
{
	/// <summary>
	/// 中期妊娠引产后观察记录 的摘要说明。
	/// </summary>
	public class frmPostartumSeeRecord: iCare.frmRecordsBase
	{
		#region system define
		
		private string m_strCurrentOpenDate = "";
		private string m_strCreateUserID = "";
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcBLOODPRESSURE_CHR;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcPULSE_CHR;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcUTERUS_CHR;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcBLOODED_CHR;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcBREAKWATER_CHR;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcEMBRYO_CHR;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcUTERUSSIZE_CHR;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcSIGNNAME_CHR;
		
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcBODYTEMPARTURE_CHR;

		private System.Windows.Forms.DataGridTextBoxColumn m_dtcRecordDate_chr;
		private System.Windows.Forms.DataGridTextBoxColumn m_dtcTime_chr;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion
         
		public frmPostartumSeeRecord()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			InitializeComponent();
            if (com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_StrCurrentHospitalNO == "450101001")
                this.Text = "中期妊娠引产产程观察记录";
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
            this.m_dtcRecordDate_chr = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_dtcTime_chr = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_dtcBLOODPRESSURE_CHR = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcPULSE_CHR = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcUTERUS_CHR = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcBLOODED_CHR = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcBREAKWATER_CHR = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcEMBRYO_CHR = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcUTERUSSIZE_CHR = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcSIGNNAME_CHR = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcBODYTEMPARTURE_CHR = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgRecordDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtbRecords)).BeginInit();
            this.m_pnlNewBase.SuspendLayout();
            this.SuspendLayout();

            // dgtsStyles
            // 
            this.dgtsStyles.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																										 this.m_dtcRecordDate_chr,
																										 this.m_dtcTime_chr,
																										 this.m_dtcBLOODPRESSURE_CHR,
																										 this.m_dtcBODYTEMPARTURE_CHR,
																										 this.m_dtcPULSE_CHR,
																										 this.m_dtcUTERUS_CHR,
																										 this.m_dtcBLOODED_CHR,
																										 this.m_dtcBREAKWATER_CHR,
																										 this.m_dtcEMBRYO_CHR,
																										 this.m_dtcUTERUSSIZE_CHR,
																										 this.m_dtcSIGNNAME_CHR});
            this.dgtsStyles.RowHeaderWidth = 15;
            // 
            // 
            // m_dtgRecordDetail
            // 
            this.m_dtgRecordDetail.BackgroundColor = System.Drawing.SystemColors.AppWorkspace;
            this.m_dtgRecordDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_dtgRecordDetail.CaptionBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.m_dtgRecordDetail.DataSource = this.m_dtbRecords;
            this.m_dtgRecordDetail.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_dtgRecordDetail.HeaderForeColor = System.Drawing.SystemColors.Window;
            this.m_dtgRecordDetail.Location = new System.Drawing.Point(11, 72);
            this.m_dtgRecordDetail.Size = new System.Drawing.Size(787, 528);
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
            this.m_trvInPatientDate.Location = new System.Drawing.Point(776, 124);
            this.m_trvInPatientDate.Size = new System.Drawing.Size(10, 10);
            this.m_trvInPatientDate.Visible = false;
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(749, 98);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(739, 79);
            this.lblAge.Size = new System.Drawing.Size(78, 19);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(764, 75);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(725, 102);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(749, 88);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(739, 122);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(749, 88);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(743, 99);
            this.lblAreaTitle.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(725, 95);
            this.txtInPatientID.Size = new System.Drawing.Size(10, 23);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(826, 95);
            this.m_txtPatientName.Size = new System.Drawing.Size(10, 23);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(826, 95);
            this.m_txtBedNO.Size = new System.Drawing.Size(10, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(748, 73);
            this.m_cboArea.Size = new System.Drawing.Size(10, 23);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(781, 95);
            this.m_lsvPatientName.Size = new System.Drawing.Size(10, 12);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(803, 73);
            this.m_lsvBedNO.Size = new System.Drawing.Size(10, 10);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(748, 95);
            this.m_cboDept.Size = new System.Drawing.Size(10, 23);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(755, 82);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(752, 86);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.m_cmdNext.Location = new System.Drawing.Point(742, 105);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(761, 90);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(780, 76);
            this.m_lblForTitle.Size = new System.Drawing.Size(8, 23);
            this.m_lblForTitle.Visible = false;
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(542, 43);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(675, 8);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Visible = true;
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowMarriage = true;
            this.m_ctlPatientInfo.m_BlnIsShowOccupy = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            // 
            // m_dtcRecordDate_chr
            // 
            this.m_dtcRecordDate_chr.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcRecordDate_chr.Format = "";
            this.m_dtcRecordDate_chr.FormatInfo = null;
            this.m_dtcRecordDate_chr.MappingName = "RecordDate_chr";
            this.m_dtcRecordDate_chr.Width = 90;
            // 
            // m_dtcTime_chr
            // 
            this.m_dtcTime_chr.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcTime_chr.Format = "";
            this.m_dtcTime_chr.FormatInfo = null;
            this.m_dtcTime_chr.MappingName = "Time_chr";
            this.m_dtcTime_chr.Width = 65;
            // 
            // m_dtcBLOODPRESSURE_CHR
            // 
            this.m_dtcBLOODPRESSURE_CHR.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcBLOODPRESSURE_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcBLOODPRESSURE_CHR.m_BlnGobleSet = true;
            this.m_dtcBLOODPRESSURE_CHR.m_BlnUnderLineDST = false;
            this.m_dtcBLOODPRESSURE_CHR.MappingName = "BLOODPRESSURE_CHR";
            this.m_dtcBLOODPRESSURE_CHR.Width = 80;
            // 
            // m_dtcPULSE_CHR
            // 
            this.m_dtcPULSE_CHR.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcPULSE_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcPULSE_CHR.m_BlnGobleSet = true;
            this.m_dtcPULSE_CHR.m_BlnUnderLineDST = false;
            this.m_dtcPULSE_CHR.MappingName = "PULSE_CHR";
            this.m_dtcPULSE_CHR.Width = 60;
            // 
            // m_dtcUTERUS_CHR
            // 
            this.m_dtcUTERUS_CHR.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcUTERUS_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcUTERUS_CHR.m_BlnGobleSet = true;
            this.m_dtcUTERUS_CHR.m_BlnUnderLineDST = false;
            this.m_dtcUTERUS_CHR.MappingName = "UTERUS_CHR";
            this.m_dtcUTERUS_CHR.Width = 60;
            // 
            // m_dtcBLOODED_CHR
            // 
            this.m_dtcBLOODED_CHR.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcBLOODED_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcBLOODED_CHR.m_BlnGobleSet = true;
            this.m_dtcBLOODED_CHR.m_BlnUnderLineDST = false;
            this.m_dtcBLOODED_CHR.MappingName = "BLOODED_CHR";
            this.m_dtcBLOODED_CHR.Width = 55;
            // 
            // m_dtcBREAKWATER_CHR
            // 
            this.m_dtcBREAKWATER_CHR.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcBREAKWATER_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcBREAKWATER_CHR.m_BlnGobleSet = true;
            this.m_dtcBREAKWATER_CHR.m_BlnUnderLineDST = false;
            this.m_dtcBREAKWATER_CHR.MappingName = "BREAKWATER_CHR";
            this.m_dtcBREAKWATER_CHR.Width = 55;
            // 
            // m_dtcEMBRYO_CHR
            // 
            this.m_dtcEMBRYO_CHR.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcEMBRYO_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcEMBRYO_CHR.m_BlnGobleSet = true;
            this.m_dtcEMBRYO_CHR.m_BlnUnderLineDST = false;
            this.m_dtcEMBRYO_CHR.MappingName = "EMBRYO_CHR";
            this.m_dtcEMBRYO_CHR.Width = 55;
            // 
            // m_dtcUTERUSSIZE_CHR
            // 
            this.m_dtcUTERUSSIZE_CHR.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcUTERUSSIZE_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcUTERUSSIZE_CHR.m_BlnGobleSet = true;
            this.m_dtcUTERUSSIZE_CHR.m_BlnUnderLineDST = false;
            this.m_dtcUTERUSSIZE_CHR.MappingName = "UTERUSSIZE_CHR";
            this.m_dtcUTERUSSIZE_CHR.Width = 55;
            // 
            // m_dtcSIGNNAME_CHR
            // 
            this.m_dtcSIGNNAME_CHR.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcSIGNNAME_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcSIGNNAME_CHR.m_BlnGobleSet = true;
            this.m_dtcSIGNNAME_CHR.m_BlnUnderLineDST = false;
            this.m_dtcSIGNNAME_CHR.MappingName = "SIGNNAME_CHR";
            this.m_dtcSIGNNAME_CHR.Width = 150;
            // 
            // m_dtcBODYTEMPARTURE_CHR
            // 
            this.m_dtcBODYTEMPARTURE_CHR.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcBODYTEMPARTURE_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcBODYTEMPARTURE_CHR.m_BlnGobleSet = true;
            this.m_dtcBODYTEMPARTURE_CHR.m_BlnUnderLineDST = false;
            this.m_dtcBODYTEMPARTURE_CHR.MappingName = "BODYTEMPARTURE_CHR";
            this.m_dtcBODYTEMPARTURE_CHR.Width = 65;
            // 
            // frmPostartumSeeRecord
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(814, 657);
            this.Name = "frmPostartumSeeRecord";
            this.Text = "中期妊娠引产后观察记录";
            this.Load += new System.EventHandler(this.frmPostartumSeeRecord_Load);
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

		// 初始化具体表单的DataTable。(需要改动)
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

			DataColumn dc1 = p_dtbRecordTable.Columns.Add("RecordDate_chr");//4
			dc1.DefaultValue = "";
			DataColumn dc2 = p_dtbRecordTable.Columns.Add("Time_chr");//5
			dc2.DefaultValue = "";


			//			p_dtbRecordTable.Columns.Add("RecordDate_chr",typeof(clsDSTRichTextBoxValue));//4
			//			p_dtbRecordTable.Columns.Add("Time_chr",typeof(clsDSTRichTextBoxValue));//5
			p_dtbRecordTable.Columns.Add("BLOODPRESSURE_CHR",typeof(clsDSTRichTextBoxValue));//6
					
			p_dtbRecordTable.Columns.Add("BODYTEMPARTURE_CHR",typeof(clsDSTRichTextBoxValue));//7

			p_dtbRecordTable.Columns.Add("PULSE_CHR",typeof(clsDSTRichTextBoxValue));//8
			p_dtbRecordTable.Columns.Add("UTERUS_CHR",typeof(clsDSTRichTextBoxValue));//9
			p_dtbRecordTable.Columns.Add("BLOODED_CHR",typeof(clsDSTRichTextBoxValue));//10
			p_dtbRecordTable.Columns.Add("BREAKWATER_CHR",typeof(clsDSTRichTextBoxValue));//11
			p_dtbRecordTable.Columns.Add("EMBRYO_CHR",typeof(clsDSTRichTextBoxValue));//12	
			p_dtbRecordTable.Columns.Add("UTERUSSIZE_CHR",typeof(clsDSTRichTextBoxValue));//13
            p_dtbRecordTable.Columns.Add("SIGNNAME_CHR", typeof(clsDSTRichTextBoxValue));//14

            p_dtbRecordTable.Columns.Add("RecordAndDetailSign");//15
            p_dtbRecordTable.Columns.Add("CreateUserID");//16
			
			

			//			m_dtcGenaralInstance.m_RtbBase.m_BlnReadOnly = true;
			m_mthSetControl(m_dtcRecordDate_chr);
			m_mthSetControl(m_dtcTime_chr);

			m_mthSetControl(m_dtcBLOODPRESSURE_CHR);
			m_mthSetControl(m_dtcBODYTEMPARTURE_CHR);

			m_mthSetControl(m_dtcPULSE_CHR);
			m_mthSetControl(m_dtcUTERUS_CHR);
			m_mthSetControl(m_dtcBLOODED_CHR);
			m_mthSetControl(m_dtcBREAKWATER_CHR);
			m_mthSetControl(m_dtcEMBRYO_CHR);
			m_mthSetControl(m_dtcUTERUSSIZE_CHR);
			m_mthSetControl(m_dtcSIGNNAME_CHR);

			
			//设置文字栏
			this.m_dtcRecordDate_chr.HeaderText = "\r\n日\r\n\r\n\r\n\r\n期";
			this.m_dtcTime_chr.HeaderText = "\r\n时\r\n\r\n\r\n\r\n间";
			this.m_dtcBLOODPRESSURE_CHR.HeaderText = "\r\n血\r\n\r\n\r\n\r\n压";

			this.m_dtcBODYTEMPARTURE_CHR.HeaderText = "\r\n体\r\n\r\n\r\n\r\n温";


			this.m_dtcPULSE_CHR.HeaderText = "\r\n脉\r\n\r\n\r\n\r\n搏";
			this.m_dtcUTERUS_CHR.HeaderText = "\r\n宫\r\n\r\n\r\n\r\n缩";
			this.m_dtcBLOODED_CHR.HeaderText = "\r\n出\r\n\r\n\r\n\r\n血";
			this.m_dtcBREAKWATER_CHR.HeaderText = "\r\n破\r\n\r\n\r\n\r\n水";
			this.m_dtcEMBRYO_CHR.HeaderText = "\r\n胎\r\n\r\n\r\n\r\n心";
			this.m_dtcUTERUSSIZE_CHR.HeaderText = "宫\r\n\r\n口\r\n\r\n大\r\n\r\n小";
			this.m_dtcSIGNNAME_CHR.HeaderText = "\r\n签\r\n\r\n\r\n\r\n名";

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

		//(需要改动)
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

		// 获取病程记录的领域层实例(需要改动)
		protected override clsRecordsDomain m_objGetRecordsDomain()
		{
            return new clsRecordsDomain(enmRecordsType.PostartumSeeRecord);
		}

		// 获取记录的主要信息（必须获取的是CreateDate,OpenDate,LastModifyDate）
		protected override clsTrackRecordContent m_objGetRecordMainContent(int p_intRecordType,
			object[] p_objDataArr)
		{
			//根据 p_intRecordType 获取对应的 clsTrackRecordContent
			clsTrackRecordContent objContent = null;
			//(需要改动)
			switch((enmDiseaseTrackType)p_intRecordType)
			{ 
				case enmDiseaseTrackType.PostartumSeeRecord:
					objContent = new clsIcuACAD_PostPartumseeRecord_VO();//(需要改动)
					break;
			}

			if(objContent == null)
				objContent=new clsIcuACAD_PostPartumseeRecord_VO();	//(需要改动)
		
			if(m_objCurrentPatient !=null)
				objContent.m_strInPatientID=m_objCurrentPatient.m_StrInPatientID;
			else 
			{
				clsPublicFunction.ShowInformationMessageBox("当前病人为空!");
				return null;
			}
			objContent.m_dtmInPatientDate=m_objCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmEMRInDate;
			objContent.m_dtmCreateDate = DateTime.Parse((string)p_objDataArr[0]);
			objContent.m_dtmOpenDate = DateTime.Parse((string)p_objDataArr[2]);
			objContent.m_dtmModifyDate = DateTime.Parse((string)p_objDataArr[3]);

            objContent.m_strCreateUserID = (string)p_objDataArr[16];
		
			return objContent;
		}

		private void frmPostartumSeeRecord_Load(object sender, System.EventArgs e)
		{
			m_dtmPreRecordDate = DateTime.MinValue;
			m_dtgRecordDetail.Focus();
			m_mniAddBlank.Visible=false;
			m_mniDeleteBlank.Visible=false;

//			m_txtDiseaseID.ReadOnly = true;
//			m_dtpCreateDate.ReadOnly = true;
//		
		}

		#region 对产期与产次的处理
//
//		private void m_mthget()
//		{
//			string p_strBEFOREHAND_CHR = "";
//			string p_strLAYCOUNT_CHR = "";
//			if(this.m_trvInPatientDate.SelectedNode != null)
//			{
//				string date = this.m_trvInPatientDate.SelectedNode.Text.ToString().Trim();
//				string InPatientID = this.txtInPatientID.Text.Trim();
//				if(InPatientID != "")
//				{
//					com.digitalwave.clsRecordsService.clsWaitLayRecord_AcadService domin = new com.digitalwave.clsRecordsService.clsWaitLayRecord_AcadService();
//					domin.m_lngGetBEFOREHAND_CHR_LAYCOUNT_CHR(InPatientID,date,out p_strBEFOREHAND_CHR, out p_strLAYCOUNT_CHR );
//					m_txtDiseaseID.Text = p_strLAYCOUNT_CHR;  //产次
//					m_dtpCreateDate.Value = Convert.ToDateTime(p_strBEFOREHAND_CHR);
//				}
//			}
//		}
		#endregion 
		// 获取处理（添加和修改）记录的窗体。
		protected override frmDiseaseTrackBase m_frmGetRecordForm(int p_intRecordType)
		{
			switch((enmDiseaseTrackType)p_intRecordType)
			{
				case enmDiseaseTrackType.PostartumSeeRecord://(需要改动)
					
				{
					frmPostartumSeeRecordCon frmwcon = new frmPostartumSeeRecordCon();
					//frmwcon.m_dtmBEFOREHAND_CHR = m_dtpCreateDate.Value;
					//frmwcon.m_strLAYCOUNT_CHR =  m_txtDiseaseID.Text;//产次
					//frmwcon.m_setLaycout();
					return  frmwcon;//(需要改动)
					break;
				}
			}  
		
			return null;
		}

		/// <summary>
		/// 处理子窗体
		/// </summary>
		/// <param name="p_frmSubForm"></param>
		protected override void m_mthHandleSubFormClosedWithYes(frmDiseaseTrackBase p_frmSubForm)
		{
			//m_mthSetPatientFormInfo(m_objCurrentPatient);

            m_mthPerformSessionChanged(m_ObjCurrentEmrPatientSession, 0);
		}
		/// <summary>
		/// 从Table删除数据
		/// </summary>
		/// <param name="p_intRecordType"></param>
		/// <param name="p_dtmCreateRecordTime"></param>
    		protected override void m_mthRemoveDataFromDataTable(int p_intRecordType,
			DateTime p_dtmCreateRecordTime)
		{
			//m_mthSetPatientFormInfo(m_objCurrentPatient);

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
			m_mthAddNewRecord((int)enmDiseaseTrackType.PostartumSeeRecord);//(需要改动)
		}

		protected override infPrintRecord m_objGetPrintTool()
		{			
			clsPostartumSeeRecordPrintTool pt = new clsPostartumSeeRecordPrintTool();
//			pt.m_strLaycount = m_txtDiseaseID.Text ;//产次
//			pt.m_strBirthDate = m_dtpCreateDate.Value.Date.ToShortDateString();
			return pt;
		}

		protected override object[][] m_objGetRecordsValueArr(clsTransDataInfo p_objTransDataInfo)
		{
			#region 显示记录到DataGrid
			try
			{

//				#region 处理产次
//				m_txtDiseaseID.Text = "";				
//				//m_dtpCreateDate.Value = System.DateTime.Now;
//				#endregion

				if(p_objTransDataInfo == null)
					return null;

				object[] objData;
				ArrayList objReturnData=new ArrayList();

				clsICUACAD_POSTPARTUMSEERECORDContentDataInfo objICUInfo=new clsICUACAD_POSTPARTUMSEERECORDContentDataInfo();	//(需要改动)		
				clsDSTRichTextBoxValue objclsDSTRichTextBoxValue;
				string strText,strXml;

				objICUInfo = (clsICUACAD_POSTPARTUMSEERECORDContentDataInfo)p_objTransDataInfo;//(需要改动)

				if(objICUInfo.m_objRecordArr == null)
					return null;

				int intRecordCount = objICUInfo.m_objRecordArr.Length;
				int intRowOfCurrentDetail = 0;

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

				for(int i=0; i<intRecordCount; i++)
				{
					objData = new object[17];   //(需要改动) DataTable的列数
					clsIcuACAD_PostPartumseeRecord_VO objCurrent = objICUInfo.m_objRecordArr[i];//(需要改动)
                    clsIcuACAD_PostPartumseeRecord_VO objNext = new clsIcuACAD_PostPartumseeRecord_VO();//下一条记录//(需要改动)
					if(i < intRecordCount-1)
						objNext = objICUInfo.m_objRecordArr[i+1];

                    ////如果该护理记录是修改前的记录且是在指定时间内修改的，则不显示
                    //if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate)
                    //{
                    //    TimeSpan tsModify =  objNext.m_dtmModifyDate-objCurrent.m_dtmModifyDate;
                    //    if((int)tsModify.TotalHours < intCanModifyTime)
                    //        continue;
                    //}


                    //如果该护理记录是修改前的记录且是在指定时间内修改的，修改者与创建者为同一人，则不显示
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strModifyUserID.Trim() == objCurrent.m_strCreateUserID.Trim()
                        && objNext.m_dtmOpenDate == objCurrent.m_dtmOpenDate)
                    {
                        TimeSpan tsModify = objNext.m_dtmModifyDate - objCurrent.m_dtmModifyDate;
                        if ((int)tsModify.TotalHours < intCanModifyTime)
                        {
                           // blnPreIsHide = true;
                            continue;
                        }
                    }


					#region 存放关键字段
					if(objCurrent.m_dtmCreateDate!=DateTime.MinValue)
					{
						objData[0] = objCurrent.m_dtmCreateDate;//存放记录时间的字符串
						objData[1] = (int)enmRecordsType.PostartumSeeRecord;//存放记录类型的int值  //(需要改动)
                        objData[2] = objCurrent.m_dtmCreateDate;//存放记录的OpenDate字符串
                        objData[3] = objCurrent.m_dtmModifyDate;//存放记录的ModifyDate字符串,不考虑痕迹时
                        //objData[3] = objICUInfo.m_objRecordArr[objICUInfo.m_objRecordArr.Length-1].m_dtmModifyDate;//存放记录的ModifyDate字符串   
						
						//同一个则只在第一行显示日期
						if(objCurrent.m_dtmCreateDate.Date.ToString() != m_dtmPreRecordDate.Date.ToString())//m_dtmRECORDDATE
						{
                            objData[4] = objCurrent.m_dtmRecordDate.Date.ToString("yyyy-MM-dd"); ;//日期字符串
						}
						//修改后带有痕迹的记录不再显示时间
						if(m_dtmPreRecordDate != objCurrent.m_dtmCreateDate)
                            objData[5] = objCurrent.m_dtmRecordDate.ToString("HH:mm");//时间字符串
					}
                    m_dtmPreRecordDate = objCurrent.m_dtmCreateDate;	
					#endregion ;

					
//					//产次处理
//					m_txtDiseaseID.Text = objCurrent.m_strLayCount_chr;
//					if(objCurrent.m_strBeforehand_chr.Trim() != "")
//						m_dtpCreateDate.Value = Convert.ToDateTime(objCurrent.m_strBeforehand_chr.ToString().Trim());
//					//

					#region 存放单项信息
					//血压
					strText = objCurrent.m_strBLOODPRESSURE_CHR_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strBLOODPRESSURE_CHR_RIGHT != objCurrent.m_strBLOODPRESSURE_CHR_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strBLOODPRESSURE_CHR_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[6] = objclsDSTRichTextBoxValue;//血压

					//体温
					strText = objCurrent.m_strBODYTEMPARTURE_CHR_RIGHT;
					strXml = "<root />";
                    //if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strBODYTEMPARTURE_CHR_RIGHT != objCurrent.m_strBODYTEMPARTURE_CHR_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    //{
                    //    strXml = m_strGetDSTTextXML(objCurrent.m_strBODYTEMPARTURE_CHR_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
                    //}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[7] = objclsDSTRichTextBoxValue;//体温

			
					//脉搏
					strText = objCurrent.m_strPULSE_CHR_RIGHT ;
					strXml = "<root />";
                    //if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strPULSE_CHR_RIGHT != objCurrent.m_strPULSE_CHR_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    //{
                    //    strXml = m_strGetDSTTextXML(objCurrent.m_strPULSE_CHR_RIGHT,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
                    //}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[8] = objclsDSTRichTextBoxValue;//脉搏

					//宫缩
					strText = objCurrent.m_strUTERUS_CHR_RIGHT;
					strXml = "<root />";
                    //if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strUTERUS_CHR_RIGHT != objCurrent.m_strUTERUS_CHR_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    //{
                    //    strXml = m_strGetDSTTextXML(objCurrent.m_strUTERUS_CHR_RIGHT,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
                    //}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[9] = objclsDSTRichTextBoxValue;//宫缩

			
					//出血
					strText = objCurrent.m_strBLOODED_CHR_RIGHT;
					strXml = "<root />";
                    //if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strBLOODED_CHR_RIGHT != objCurrent.m_strBLOODED_CHR_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    //{
                    //    strXml = m_strGetDSTTextXML(objCurrent.m_strBLOODED_CHR_RIGHT,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
                    //}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[10] = objclsDSTRichTextBoxValue;//出血
			
					//破水
					strText = objCurrent.m_strBREAKWATER_CHR_RIGHT ;
					strXml = "<root />";
                    //if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strBREAKWATER_CHR_RIGHT != objCurrent.m_strBREAKWATER_CHR_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    //{
                    //    strXml = m_strGetDSTTextXML(objCurrent.m_strBREAKWATER_CHR_RIGHT,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
                    //}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[11] = objclsDSTRichTextBoxValue;//破水

					//胎心
					strText = objCurrent.m_strEMBRYO_CHR_RIGHT ;
					strXml = "<root />";
                    //if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strEMBRYO_CHR_RIGHT != objCurrent.m_strEMBRYO_CHR_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    //{
                    //    strXml = m_strGetDSTTextXML(objCurrent.m_strEMBRYO_CHR_RIGHT,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
                    //}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[12] = objclsDSTRichTextBoxValue;//胎心

					//宫口大小
					strText = objCurrent.m_strUTERUSSIZE_CHR_RIGHT ;
					strXml = "<root />";
                    //if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strUTERUSSIZE_CHR_RIGHT != objCurrent.m_strUTERUSSIZE_CHR_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
                    //{
                    //    strXml = m_strGetDSTTextXML(objCurrent.m_strUTERUSSIZE_CHR_RIGHT,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
                    //}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[13] = objclsDSTRichTextBoxValue;//宫口大小

                    //签名
                    if (objCurrent.objSignerArr != null || objCurrent.objSignerArr.Length > 0)
                    {
                        string str = string.Empty;
                        if(objCurrent.objSignerArr[0].objEmployee != null)
                            str = objCurrent.objSignerArr[0].objEmployee.m_strGetTechnicalRankAndName;
                        for (int w1 = 1 ; w1 < objCurrent.objSignerArr.Length ; w1++)
                        {
                            if(objCurrent.objSignerArr[w1].objEmployee != null)
                                str += ";"+objCurrent.objSignerArr[w1].objEmployee.m_strGetTechnicalRankAndName;
                        }
					    objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
                        objclsDSTRichTextBoxValue.m_strText = str;						
					    objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
                        objData[14] = objclsDSTRichTextBoxValue;//签名
                    }

                    //
                    objData[15] = objCurrent.m_strRecordUserID;//
                    objData[16] = objCurrent.m_strCreateUserID;//

					objReturnData.Add(objData);
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

        protected override void m_mthGetTransDataInfoArr(out clsTransDataInfo[] p_objTansDataInfoArr)
        {
            m_objRecordsDomain.m_lngGetTransDataInfoArr(m_objCurrentPatient.m_StrRegisterId, out p_objTansDataInfoArr);

        }

	}
}
