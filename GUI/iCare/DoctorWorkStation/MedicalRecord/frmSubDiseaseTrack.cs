//#define FunctionPrivilege
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
using com.digitalwave.controls;
using com.digitalwave.emr.AssistModuleVO;


namespace iCare
{
	/// <summary>
	/// 病程记录主窗体的实现,Jacky-2003-5-12
	/// </summary>
	public class frmSubDiseaseTrack : frmRecordsBase
	{
		private cltDataGridDSTRichTextBox clmContent;
		private System.Windows.Forms.MenuItem mniGeneralDisease;
		private System.Windows.Forms.MenuItem mniHandOver;
		private System.Windows.Forms.MenuItem mniTakeOver;
		private System.Windows.Forms.MenuItem mniConsultation;
		private System.Windows.Forms.MenuItem mniConvey;
		private System.Windows.Forms.MenuItem mniTurnIn;
		private System.Windows.Forms.MenuItem mniDiseaseSummary;
		private System.Windows.Forms.MenuItem mniCheckRoom;
		private System.Windows.Forms.MenuItem mniCaseDiscuss;
		private System.Windows.Forms.MenuItem mniBeforeOperationDiscuss;
		private System.Windows.Forms.MenuItem mniDeadCaseDiscuss;
		private System.Windows.Forms.MenuItem mniDead;
		private System.Windows.Forms.MenuItem mniOutHospital;
		private System.Windows.Forms.MenuItem mniAfterOperation;
		private System.Windows.Forms.MenuItem mniSave;
		private System.Windows.Forms.MenuItem mniFirstIllnessNote;
        private System.Windows.Forms.MenuItem mniSummaryBeforeOP;
		private System.ComponentModel.IContainer components = null;
        private DataGridColumnStyle GridDateColumn;

		public frmSubDiseaseTrack()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
            //指明医生工作站表单
            intFormType = 1;
			// TODO: Add any initialization after the InitializeComponent call
			//m_dtbRecords.Columns.Add("clmContent",typeof(clsDSTRichTextBoxValue));
			clmContent.m_RtbBase.ScrollBars = RichTextBoxScrollBars.None;			
			m_lblForTitle.Text = "病 程 记 录";

            //this.dgtsStyles.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[]{																			
            //                                                                                             this.clmContent
            //                                                                                            });
            //                                                                                           // {dataGridTextBoxColumn1,																										
                                                                                                        // this.clmContent,
                                                                                                        // this.dataGridTextBoxColumn2});
            this.dgtsStyles.PreferredColumnWidth = 85;
            this.dgtsStyles.RowHeaderWidth = 15;
		}

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSubDiseaseTrack));
            this.clmContent = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.mniGeneralDisease = new System.Windows.Forms.MenuItem();
            this.mniHandOver = new System.Windows.Forms.MenuItem();
            this.mniTakeOver = new System.Windows.Forms.MenuItem();
            this.mniConsultation = new System.Windows.Forms.MenuItem();
            this.mniConvey = new System.Windows.Forms.MenuItem();
            this.mniTurnIn = new System.Windows.Forms.MenuItem();
            this.mniDiseaseSummary = new System.Windows.Forms.MenuItem();
            this.mniCheckRoom = new System.Windows.Forms.MenuItem();
            this.mniCaseDiscuss = new System.Windows.Forms.MenuItem();
            this.mniBeforeOperationDiscuss = new System.Windows.Forms.MenuItem();
            this.mniDeadCaseDiscuss = new System.Windows.Forms.MenuItem();
            this.mniDead = new System.Windows.Forms.MenuItem();
            this.mniOutHospital = new System.Windows.Forms.MenuItem();
            this.mniAfterOperation = new System.Windows.Forms.MenuItem();
            this.mniSave = new System.Windows.Forms.MenuItem();
            this.mniFirstIllnessNote = new System.Windows.Forms.MenuItem();
            this.mniSummaryBeforeOP = new System.Windows.Forms.MenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgRecordDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtbRecords)).BeginInit();
            this.m_pnlNewBase.SuspendLayout();
            this.SuspendLayout();
            // dgtsStyles
            // 
            this.dgtsStyles.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																										 this.clmContent});
            this.dgtsStyles.RowHeaderWidth = 30;
            // 
            // 
            // m_dtgRecordDetail
            // 
            this.m_dtgRecordDetail.AccessibleName = "DataGrid";
            this.m_dtgRecordDetail.AccessibleRole = System.Windows.Forms.AccessibleRole.Table;
            this.m_dtgRecordDetail.AllowSorting = false;
            this.m_dtgRecordDetail.BackgroundColor = System.Drawing.SystemColors.Control;
            this.m_dtgRecordDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_dtgRecordDetail.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.m_dtgRecordDetail.DataSource = this.m_dtbRecords;
            this.m_dtgRecordDetail.GridLineColor = System.Drawing.Color.Black;
            this.m_dtgRecordDetail.Location = new System.Drawing.Point(5, 70);
            this.m_dtgRecordDetail.Size = new System.Drawing.Size(796, 562);
            // 
            // mniAppend
            // 
            this.mniAppend.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mniFirstIllnessNote,
            this.mniGeneralDisease,
            this.mniHandOver,
            this.mniTakeOver,
            this.mniConsultation,
            this.mniConvey,
            this.mniTurnIn,
            this.mniDiseaseSummary,
            this.mniCheckRoom,
            this.mniCaseDiscuss,
            this.mniBeforeOperationDiscuss,
            this.mniDeadCaseDiscuss,
            this.mniAfterOperation,
            this.mniDead,
            this.mniOutHospital,
            this.mniSave,
            this.mniSummaryBeforeOP});
            // 
            // m_trvInPatientDate
            // 
            this.m_trvInPatientDate.BackColor = System.Drawing.Color.White;
            this.m_trvInPatientDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_trvInPatientDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_trvInPatientDate.ForeColor = System.Drawing.Color.Black;
            this.m_trvInPatientDate.ItemHeight = 18;
            this.m_trvInPatientDate.LineColor = System.Drawing.Color.Black;
            this.m_trvInPatientDate.Location = new System.Drawing.Point(232, 166);
            this.m_trvInPatientDate.Size = new System.Drawing.Size(164, 60);
            this.m_trvInPatientDate.Visible = false;
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(274, 161);
            this.lblSex.Size = new System.Drawing.Size(32, 19);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(309, 166);
            this.lblAge.Size = new System.Drawing.Size(40, 19);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(250, 166);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(250, 180);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(239, 159);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(309, 157);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(309, 195);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(229, 166);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(211, 166);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(92, 104);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(232, 150);
            this.txtInPatientID.Size = new System.Drawing.Size(92, 23);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(221, 154);
            this.m_txtPatientName.Size = new System.Drawing.Size(72, 23);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(203, 152);
            this.m_txtBedNO.Size = new System.Drawing.Size(68, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(221, 157);
            this.m_cboArea.Size = new System.Drawing.Size(116, 23);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(242, 130);
            this.m_lsvPatientName.Size = new System.Drawing.Size(72, 104);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(211, 130);
            this.m_lsvBedNO.Size = new System.Drawing.Size(92, 104);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(253, 186);
            this.m_cboDept.Size = new System.Drawing.Size(116, 23);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(208, 176);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(253, 166);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.m_cmdNext.Location = new System.Drawing.Point(256, 159);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(242, 152);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(253, 183);
            this.m_lblForTitle.Visible = false;
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(548, 41);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(722, 34);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Location = new System.Drawing.Point(4, 5);
            this.m_pnlNewBase.Size = new System.Drawing.Size(798, 60);
            this.m_pnlNewBase.Visible = true;
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(796, 29);
            // 
            // clmContent
            // 
            this.clmContent.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.clmContent.HeaderText = "记录内容";
            this.clmContent.m_BlnGobleSet = true;
            this.clmContent.m_BlnUnderLineDST = false;
            this.clmContent.MappingName = "clmContent";
            this.clmContent.NullText = "";
            this.clmContent.Width = 750;
            // 
            // mniGeneralDisease
            // 
            this.mniGeneralDisease.Index = 1;
            this.mniGeneralDisease.Text = "病程记录";
            this.mniGeneralDisease.Click += new System.EventHandler(this.mniGeneralDisease_Click);
            // 
            // mniHandOver
            // 
            this.mniHandOver.Index = 2;
            this.mniHandOver.Text = "交班记录";
            this.mniHandOver.Click += new System.EventHandler(this.mniHandOver_Click);
            // 
            // mniTakeOver
            // 
            this.mniTakeOver.Index = 3;
            this.mniTakeOver.Text = "接班记录";
            this.mniTakeOver.Click += new System.EventHandler(this.mniTakeOver_Click);
            // 
            // mniConsultation
            // 
            this.mniConsultation.Index = 4;
            this.mniConsultation.Text = "会诊记录";
            this.mniConsultation.Visible = false;
            this.mniConsultation.Click += new System.EventHandler(this.mniConsultation_Click);
            // 
            // mniConvey
            // 
            this.mniConvey.Index = 5;
            this.mniConvey.Text = "转出记录";
            this.mniConvey.Click += new System.EventHandler(this.mniConvey_Click);
            // 
            // mniTurnIn
            // 
            this.mniTurnIn.Index = 6;
            this.mniTurnIn.Text = "转入记录";
            this.mniTurnIn.Click += new System.EventHandler(this.mniTurnIn_Click);
            // 
            // mniDiseaseSummary
            // 
            this.mniDiseaseSummary.Index = 7;
            this.mniDiseaseSummary.Text = "阶段小结";
            this.mniDiseaseSummary.Click += new System.EventHandler(this.mniDiseaseSummary_Click);
            // 
            // mniCheckRoom
            // 
            this.mniCheckRoom.Index = 8;
            this.mniCheckRoom.Text = "查房记录";
            this.mniCheckRoom.Click += new System.EventHandler(this.menuCheckRoom_Click);
            // 
            // mniCaseDiscuss
            // 
            this.mniCaseDiscuss.Index = 9;
            this.mniCaseDiscuss.Text = "疑难病例讨论";
            this.mniCaseDiscuss.Click += new System.EventHandler(this.mniCaseDiscuss_Click);
            // 
            // mniBeforeOperationDiscuss
            // 
            this.mniBeforeOperationDiscuss.Index = 10;
            this.mniBeforeOperationDiscuss.Text = "术前讨论";
            this.mniBeforeOperationDiscuss.Click += new System.EventHandler(this.mniBeforeOperationDiscuss_Click);
            // 
            // mniDeadCaseDiscuss
            // 
            this.mniDeadCaseDiscuss.Index = 11;
            this.mniDeadCaseDiscuss.Text = "死亡病例讨论";
            this.mniDeadCaseDiscuss.Click += new System.EventHandler(this.mniDeadCaseDiscuss_Click);
            // 
            // mniDead
            // 
            this.mniDead.Index = 13;
            this.mniDead.Text = "死亡记录";
            this.mniDead.Click += new System.EventHandler(this.mniDead_Click);
            // 
            // mniOutHospital
            // 
            this.mniOutHospital.Index = 14;
            this.mniOutHospital.Text = "出院记录";
            this.mniOutHospital.Visible = false;
            this.mniOutHospital.Click += new System.EventHandler(this.mniOutHospital_Click);
            // 
            // mniAfterOperation
            // 
            this.mniAfterOperation.Index = 12;
            this.mniAfterOperation.Text = "手术后病程记录";
            this.mniAfterOperation.Click += new System.EventHandler(this.mniAfterOperation_Click);
            // 
            // mniSave
            // 
            this.mniSave.Index = 15;
            this.mniSave.Text = "抢救记录";
            this.mniSave.Click += new System.EventHandler(this.mniSave_Click);
            // 
            // mniFirstIllnessNote
            // 
            this.mniFirstIllnessNote.Index = 0;
            this.mniFirstIllnessNote.Text = "首次病程记录";
            this.mniFirstIllnessNote.Click += new System.EventHandler(this.mniFirstIllnessNote_Click);
            // 
            // mniSummaryBeforeOP
            // 
            this.mniSummaryBeforeOP.Index = 16;
            this.mniSummaryBeforeOP.Text = "术前小结";
            this.mniSummaryBeforeOP.Click += new System.EventHandler(this.mniSummaryBeforeOP_Click);
            // 
            // frmSubDiseaseTrack
            // 
            this.AccessibleDescription = "主病程记录";
            this.AutoScroll = false;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(814, 673);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSubDiseaseTrack";
            this.Text = "病程记录";
            this.Load += new System.EventHandler(this.frmSubDiseaseTrack_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgRecordDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtbRecords)).EndInit();
            this.m_pnlNewBase.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private void CreateDataGridStyle()
        {
            PropertyDescriptorCollection pcol = this.BindingContext[m_dtbRecords].GetItemProperties();

            GridDateColumn = new ColumnStyle(pcol[0]);
            GridDateColumn.NullText = "";
            GridDateColumn.HeaderText = "";
            GridDateColumn.MappingName = "PagiNation";
            GridDateColumn.Width = 10;
            dgtsStyles.GridColumnStyles.Add(GridDateColumn);
            //			dgtsStyles.GridColumnStyles.Add(clmContent);
            //			dgtsStyles.GridColumnStyles.Add(dataGridTextBoxColumn2);
        }

		// 清空特殊记录信息，并重置记录控制状态为不控制。
		protected override void m_mthClearRecordInfo()
		{			
			
		}

		// 初始化具体表单的DataTable。
		// 注意，DataTable的第一个Column必须是存放记录时间的字符串，第二个Column必须是存放记录类型的int值，第三个Column必须是存放记录的OpenDate
		protected override void m_mthInitDataTable(DataTable p_dtbRecordTable)
		{
			//存放记录时间的字符串
			p_dtbRecordTable.Columns.Add("CreateDate");
		
			//存放记录类型的int值
			DataColumn dcRecordType = new DataColumn("RecordType",typeof(int));
			p_dtbRecordTable.Columns.Add(dcRecordType);
		
			//存放记录的OpenDate字符串
			p_dtbRecordTable.Columns.Add("OpenDate");  
		
			//存放记录的ModifyDate字符串
			p_dtbRecordTable.Columns.Add("ModifyDate"); 
		
			//存放显示内容
			p_dtbRecordTable.Columns.Add("clmContent",typeof(clsDSTRichTextBoxValue));

            //存放记录的分页标志
            p_dtbRecordTable.Columns.Add("PagiNation");

            //存放创建者ID
            p_dtbRecordTable.Columns.Add("CreateUserID"); 

			m_mthSetControl(clmContent);
			clmContent.m_RtbBase.m_BlnReadOnly = true;
		}

		// 获取添加到DataTable的数据
		protected override object[][] m_objGetRecordsValueArr(clsTransDataInfo p_objTransDataInfo)
		{
			//根据不同的表单类型，获取对应的clsDiseaseTrackInfo
			clsDiseaseTrackInfo objTrackInfo = null;
            #region
            switch ((enmDiseaseTrackType)p_objTransDataInfo.m_intFlag)
			{
				case enmDiseaseTrackType.FirstIllnessNote:
                    if (com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_StrCurrentHospitalNO == "450101001")//佛二
                    {
                        objTrackInfo = new clsFirstIllnessNoteInfo();
                    }
                    else
                    { 
                        objTrackInfo = new clsFirstIllnessNoteInfo_F2();
                        p_objTransDataInfo.m_intFlag = (int)enmDiseaseTrackType.FirstIllnessNote_F2;
                    }
					break;
				case enmDiseaseTrackType.GeneralDisease:
					objTrackInfo = new clsGeneralDiseaseInfo();
					break;

				case enmDiseaseTrackType.HandOver:
					objTrackInfo = new clsHandOverInfo(m_objCurrentPatient);
					break;
				case enmDiseaseTrackType.TakeOver:
                    objTrackInfo = new clsTakeOverInfo(m_objCurrentPatient);
					break;
				case enmDiseaseTrackType.Consultation:
					objTrackInfo = new clsConsultationInfo();
					break;
				case enmDiseaseTrackType.Convey:
                    objTrackInfo = new clsConveyInfo(m_objCurrentPatient);
					break;
				case enmDiseaseTrackType.TurnIn:
                    objTrackInfo = new clsTurnInInfo(m_objCurrentPatient);
					break;
				case enmDiseaseTrackType.DiseaseSummary:
					objTrackInfo = new clsDiseaseSummaryInfo();
					break;
				case enmDiseaseTrackType.CheckRoom:
					objTrackInfo = new clsCheckRoomInfo();
					break;
				case enmDiseaseTrackType.CaseDiscuss:
					objTrackInfo = new clsCaseDiscussInfo();
					break;
				case enmDiseaseTrackType.BeforeOperationDiscuss:
					objTrackInfo = new clsBeforeOperationDiscussInfo();
					break;
				case enmDiseaseTrackType.DeadCaseDiscuss:
					objTrackInfo = new clsDeadCaseDiscussInfo();
					break;
				case enmDiseaseTrackType.DeathCaseDiscuss:
					objTrackInfo = new clsDeathCaseDiscussInfo();
					break;
				case enmDiseaseTrackType.AfterOperation:
					objTrackInfo = new clsAfterOperationInfo();
					break;
				case enmDiseaseTrackType.Dead:
                    objTrackInfo = new clsDeadRecordInfo(m_objCurrentPatient);
					break;
				case enmDiseaseTrackType.Death:
					objTrackInfo = new clsDeathRecordInfo();
					break;
				case enmDiseaseTrackType.OutHospital:
					objTrackInfo = new clsOutHospitalInfo();
					break;
				case enmDiseaseTrackType.Save:
					objTrackInfo = new clsSaveRecordInfo();
					break;
				case enmDiseaseTrackType.FirstIllnessNote_ZY:
					objTrackInfo=new clsFirstIllnessNote_ZYInfo();
					break;
                case enmDiseaseTrackType.EMR_SummaryBeforeOP:
                    objTrackInfo = new clsEMR_SummaryBeforeOPInfo();
                    break;
                case enmDiseaseTrackType.FirstIllnessNote_F2:
                    objTrackInfo = new clsFirstIllnessNoteInfo_F2();
                    break;
            
            }
		#endregion
			//设置clsDiseaseTrackInfo的内容
			objTrackInfo.m_ObjRecordContent = p_objTransDataInfo.m_objRecordContent;
		
			int intCharPerLine = clmContent.Width/14-4;
			int intBytesPerLine = 100;

			//根据 clsDiseaseTrackInfo 获得的文本和Xml  
			string strText = ""; 
			string strXML = "";

			if((enmDiseaseTrackType)p_objTransDataInfo.m_intFlag == enmDiseaseTrackType.CaseDiscuss)
			{
				((clsCaseDiscussInfo)objTrackInfo).m_mthGetFormatTrackInfo(((int)(clmContent.Width/17.5))-5,out strText,out strXML);
			}
            else if ((enmDiseaseTrackType)p_objTransDataInfo.m_intFlag == enmDiseaseTrackType.DeadCaseDiscuss)
            {
                ((clsDeadCaseDiscussInfo)objTrackInfo).m_mthGetFormatTrackInfo(((int)(clmContent.Width / 17.5)) - 5, out strText, out strXML);
            }
			else
			{
				strText = objTrackInfo.m_strGetTrackText(); 
				strXML = objTrackInfo.m_strGetTrackXml();
			}

			string strSignText = objTrackInfo.m_strGetSignText();
			string strSignXml = objTrackInfo.m_strGetSignXml();

			string strBlanks="";
			for(int j2=0;j2<intCharPerLine-strSignText.Length;j2++)
			{
				strBlanks +="　";	//注意：此处填充的空格是全角占一个汉字的空格			
			}
			strSignText = strBlanks+strSignText;
		
			//结合DataGrid每行的显示数目
			//生成每行内容的文本和Xml数组
			string [] strTextArr,strXmlArr;			

			com.digitalwave.controls.ctlRichTextBox.m_mthSplitXmlByBytes(strText,strXML,intBytesPerLine,out strTextArr,out strXmlArr);
			
			object [][] objData = new object[strTextArr.Length+1][];
		
			for(int i=0;i<objData.Length-1;i++)
			{
				objData[i] = new object[7];
			
				//设置值
				if(i==0)
				{
					//只在第一行记录才由以下信息
					objData[i][0] = objTrackInfo.m_ObjRecordContent.m_dtmCreateDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat(this.Name));//存放记录时间的字符串
					objData[i][1] =(int)objTrackInfo.m_enmGetTrackType() ;//存放记录类型的int值
					objData[i][2] =objTrackInfo.m_ObjRecordContent.m_dtmOpenDate. ToString("yyyy-MM-dd HH:mm:ss");//存放记录的OpenDate字符串
					objData[i][3] =objTrackInfo.m_ObjRecordContent.m_dtmModifyDate. ToString("yyyy-MM-dd HH:mm:ss") ;//存放记录的ModifyDate字符串        
                    objData[i][5] = objTrackInfo.m_ObjRecordContent.m_StrPagination;//存放分页
                    objData[i][6] = objTrackInfo.m_ObjRecordContent.m_strCreateUserID;//存放记录的createuserid字符串        
                }

				clsDSTRichTextBoxValue objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
				objclsDSTRichTextBoxValue.m_strText=strTextArr[i];						
				objclsDSTRichTextBoxValue.m_strDSTXml=strXmlArr[i];
				
				objData[i][4]=objclsDSTRichTextBoxValue;//存放显示内容
			}

            objData[objData.Length - 1] = new object[5];
         //   objData[objData.Length - 1] = new object[6];
			clsDSTRichTextBoxValue objclsDSTRichTextBoxValueSign=new clsDSTRichTextBoxValue();
			objclsDSTRichTextBoxValueSign.m_strText=strSignText;						
			objclsDSTRichTextBoxValueSign.m_strDSTXml=strSignXml;

            objData[objData.Length - 1][4] = objclsDSTRichTextBoxValueSign;//存放显示内容
          //  objData[objData.Length - 1][5] = objclsDSTRichTextBoxValueSign;//存放显示内容
			return objData;
		

		}

		// 获取病程记录的领域层实例
		protected override clsRecordsDomain m_objGetRecordsDomain()
		{	
			//满足市一中医科要求，暂时直接用科室的SHORTNO_CHR进行判断
            if (MDIParent.m_objCurrentDepartment != null && MDIParent.m_objCurrentDepartment.m_strSHORTNO_CHR != null
                && MDIParent.m_objCurrentDepartment.m_strSHORTNO_CHR.Trim() == "1500000" && com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_StrCurrentHospitalNO == "440104001")
                return new clsRecordsDomain(enmRecordsType.FirstIllnessNote_ZY);
            else
            {
                if (com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_StrCurrentHospitalNO == "450101001")//南宁
                    return new clsRecordsDomain(enmRecordsType.FirstIllnessNote);
                else
                    return new clsRecordsDomain(enmRecordsType.FirstIllnessNote_F2);
            }
		}

		protected override infPrintRecord m_objGetPrintTool()
		{
			return new clsSubDiseaseTrackPrintTool();
		}

		// 获取处理（添加和修改）记录的窗体。
		protected override frmDiseaseTrackBase m_frmGetRecordForm(int p_intRecordType)
		{
			switch((enmDiseaseTrackType)p_intRecordType)
			{
					//Add notes by jli in 2004-11-22
				case enmDiseaseTrackType.GeneralDisease://病程记录
					return new frmGeneralDisease();
				case enmDiseaseTrackType.HandOver://交班记录
					return new frmHandOver();
				case enmDiseaseTrackType.TakeOver://接班记录
					return new frmTakeOver();
				case enmDiseaseTrackType.Consultation://会诊记录
					return new frmConsultation();
				case enmDiseaseTrackType.Convey://转出记录
					return new frmConvey();
				case enmDiseaseTrackType.TurnIn://转入记录
					return new frmTurnIn();
				case enmDiseaseTrackType.DiseaseSummary://阶段小结
					return new frmDiseaseSummary();
				case enmDiseaseTrackType.CheckRoom://查房记录
					return new frmCheckRoom();
				case enmDiseaseTrackType.CaseDiscuss://病例讨论
					return new frmCaseDiscuss();
				case enmDiseaseTrackType.BeforeOperationDiscuss://术前讨论
					return new frmBeforeOperationDiscuss();
				case enmDiseaseTrackType.DeadCaseDiscuss://死亡病例讨论
					return new frmDeadCaseDiscuss();
				case enmDiseaseTrackType.DeathCaseDiscuss:
					return new frmDeathCaseDiscuss();
				case enmDiseaseTrackType.AfterOperation://手术后病程记录
					return new frmAfterOperation();
				case enmDiseaseTrackType.Dead://死亡记录
					return new frmDeadRecord();
				case enmDiseaseTrackType.Death://死亡记录(新)
					return new frmDeathRecord();
				case enmDiseaseTrackType.OutHospital://出院记录
					return new frmOutHospital();
                case enmDiseaseTrackType.Save://抢救记录
					return new frmSaveRecord();
				case  enmDiseaseTrackType.FirstIllnessNote:
                    if (com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_StrCurrentHospitalNO == "450101001")
                    {
                        return new frmFirstIllnessNote();
                    }
                    else
                    {
                        return new frmFirstIllnessNote_F2();
                    }					
				case  enmDiseaseTrackType.FirstIllnessNote_ZY:
					return new frmFirstIllnessNote_ZY ();

                case enmDiseaseTrackType.EMR_SummaryBeforeOP:
                    return new frmEMR_SummaryBeforeOP();
                case enmDiseaseTrackType.FirstIllnessNote_F2:
                    return new frmFirstIllnessNote_F2();
                //case enmDiseaseTrackType.SubDiseaseTrack:
                //    return new frmSubDiseaseTrack();
			}  
			return null;
		}

		// 获取记录的主要信息（必须获取的是CreateDate,OpenDate,LastModifyDate）
		protected override clsTrackRecordContent m_objGetRecordMainContent(int p_intRecordType,
			object[] p_objDataArr)
		{
			//根据 p_intRecordType 获取对应的 clsTrackRecordContent
			clsTrackRecordContent objContent = null;
            #region
            switch ((enmDiseaseTrackType)p_intRecordType)
			{ 
				case enmDiseaseTrackType.GeneralDisease:
					objContent = new clsGeneralDiseaseRecordContent();
					break;
				case enmDiseaseTrackType.HandOver:
					objContent = new clsHandOverRecordContent();
					break;
				case enmDiseaseTrackType.TakeOver:
					objContent = new clsTakeOverRecordContent();
					break;
				case enmDiseaseTrackType.Consultation:
					objContent = new clsConsultationRecordContent();
					break;
				case enmDiseaseTrackType.Convey:
					objContent = new clsConveyRecordContent();
					break;
				case enmDiseaseTrackType.TurnIn:
					objContent = new clsTurnInRecordContent();
					break;
				case enmDiseaseTrackType.DiseaseSummary:
					objContent = new clsDiseaseSummaryRecordContent();
					break;
				case enmDiseaseTrackType.CheckRoom:
					objContent = new clsCheckRoomRecordContent();
					break;
				case enmDiseaseTrackType.CaseDiscuss:
					objContent = new clsCaseDiscussRecordContent();
					break;
				case enmDiseaseTrackType.BeforeOperationDiscuss:
					objContent = new clsBeforeOperationDiscussRecordContent();
					break;
				case enmDiseaseTrackType.DeadCaseDiscuss:
					objContent = new clsDeadCaseDiscussRecordContent();
					break;
				case enmDiseaseTrackType.DeathCaseDiscuss:
					objContent = new clsDeadCaseDiscussRecord_VO();
					break;
				case enmDiseaseTrackType.AfterOperation:
					objContent = new clsAfterOperationRecordContent();
					break;
				case enmDiseaseTrackType.Dead:
					objContent = new clsDeadRecordContent();
					break;
				case enmDiseaseTrackType.Death:
					objContent = new clsDeadRecord_VO();
					break;
				case enmDiseaseTrackType.OutHospital:
					objContent = new clsOutHospitalRecordContent();
					break;
				case enmDiseaseTrackType.Save:
					objContent = new clsSaveRecordContent();
					break;
				case enmDiseaseTrackType.FirstIllnessNote:
					objContent = new clsFirstIllnessNoteRecordContent();
					break;
				case enmDiseaseTrackType.FirstIllnessNote_ZY:
					objContent = new clsFirstIllnessNote_ZYRecordContent();
					break;
			    case enmDiseaseTrackType.EMR_SummaryBeforeOP:
                    objContent = new clsEMR_SummaryBeforeOPValue();
                    break;
                case enmDiseaseTrackType.FirstIllnessNote_F2:
                    objContent = new clsFirstIllnessNoteRecordContent();
                    break;
            }
            #endregion
            if (m_objCurrentPatient !=null && m_ObjCurrentEmrPatientSession != null)
				objContent.m_strInPatientID=m_objCurrentPatient.m_StrInPatientID;
			else 
			{
				clsPublicFunction.ShowInformationMessageBox("当前病人为空!");
				return null;
			}
			objContent.m_dtmInPatientDate=m_ObjLastEmrPatientSession.m_dtmEMRInpatientDate;
			objContent.m_dtmCreateDate = DateTime.Parse((string)p_objDataArr[0]);
			objContent.m_dtmOpenDate = DateTime.Parse((string)p_objDataArr[2]);
			objContent.m_dtmModifyDate = DateTime.Parse((string)p_objDataArr[3]);
            objContent.m_strCreateUserID = (string)p_objDataArr[6];     
		
			return objContent;
		}

		#region 添加菜单

		private void mniFirstIllnessNote_Click(object sender, System.EventArgs e)
		{
			PrivilegeData.enmPrivilegeSF enmSF = (PrivilegeData.enmPrivilegeSF)Enum.Parse(typeof(PrivilegeData.enmPrivilegeSF),this.GetType().Name);
#if FunctionPrivilege
			if(!MDIParent.s_blnCheckCurrentPrivilege(enmSF,PrivilegeData.enmPrivilegeOperation.AddOrModify))
			{
				MDIParent.s_mthShowNotPermitMessage();
				return;
			}			
#endif
			this.Cursor=Cursors.WaitCursor;
            if (MDIParent.m_objCurrentDepartment != null )
			{
                if (com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_StrCurrentHospitalNO == "440104001")
                {
                    #region 市一
                    if (MDIParent.m_objCurrentDepartment.m_strSHORTNO_CHR != null)
                    {
                        //满足市一中医科要求，暂时直接用科室的SHORTNO_CHR进行判断
                        if (MDIParent.m_objCurrentDepartment.m_strSHORTNO_CHR.Trim() == "1500000")
                            m_mthAddNewRecord((int)enmDiseaseTrackType.FirstIllnessNote_ZY);
                        else if (MDIParent.m_objCurrentDepartment.m_strSHORTNO_CHR.Trim() == "1030200")
                        {
                            bool blnYes = false;
                            for (int i = 0; i < clsEMRLogin.m_ObjCurDeptOfEmpArr.Length; i++)
                            {
                                if (clsEMRLogin.m_ObjCurDeptOfEmpArr[i].strShortNo == "1500000")
                                {
                                    blnYes = true;
                                    break;
                                }
                            }
                            if (blnYes)
                            {
                                if (MessageBox.Show(this, "使用中医科首程请按\"确定\"！否则按\"取消\"！", "选择首次病程记录", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                                {
                                    m_mthAddNewRecord((int)enmDiseaseTrackType.FirstIllnessNote_ZY);
                                }
                                else
                                    blnYes = false;
                            }
                            if (!blnYes)
                                m_mthAddNewRecord((int)enmDiseaseTrackType.FirstIllnessNote);
                        }
                        else
                            m_mthAddNewRecord((int)enmDiseaseTrackType.FirstIllnessNote);
                    }
                    #endregion 市一
                }
                else if (com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_StrCurrentHospitalNO == "450101001")//佛二
                {
                    m_mthAddNewRecord((int)enmDiseaseTrackType.FirstIllnessNote);
                }
                else//其他
                { 
                    m_mthAddNewRecord((int)enmDiseaseTrackType.FirstIllnessNote_F2);
                }
			}
			this.Cursor=Cursors.Default;
				
		}


        private void mniSummaryBeforeOP_Click(object sender, EventArgs e)
        {
            PrivilegeData.enmPrivilegeSF enmSF = (PrivilegeData.enmPrivilegeSF)Enum.Parse(typeof(PrivilegeData.enmPrivilegeSF), this.GetType().Name);
#if FunctionPrivilege
			if(!clsPublicFunction.s_blnCheckCurrentPrivilege(enmSF,PrivilegeData.enmPrivilegeOperation.AddOrModify))
			{
				clsPublicFunction.s_mthShowNotPermitMessage();
				return;
			}			
#endif
            this.Cursor = Cursors.WaitCursor;
            try
            {
                m_mthAddNewRecord((int)enmDiseaseTrackType.EMR_SummaryBeforeOP);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Cursor = Cursors.Default;
        }

		private void mniGeneralDisease_Click(object sender, System.EventArgs e)
		{
			PrivilegeData.enmPrivilegeSF enmSF = (PrivilegeData.enmPrivilegeSF)Enum.Parse(typeof(PrivilegeData.enmPrivilegeSF),this.GetType().Name);
#if FunctionPrivilege
			if(!clsPublicFunction.s_blnCheckCurrentPrivilege(enmSF,PrivilegeData.enmPrivilegeOperation.AddOrModify))
			{
				clsPublicFunction.s_mthShowNotPermitMessage();
				return;
			}			
#endif
			this.Cursor=Cursors.WaitCursor;
			try
			{
				m_mthAddNewRecord((int)enmDiseaseTrackType.GeneralDisease);		
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			this.Cursor=Cursors.Default;
		}

		private void mniHandOver_Click(object sender, System.EventArgs e)
		{
			PrivilegeData.enmPrivilegeSF enmSF = (PrivilegeData.enmPrivilegeSF)Enum.Parse(typeof(PrivilegeData.enmPrivilegeSF),this.GetType().Name);
#if FunctionPrivilege
			if(!clsPublicFunction.s_blnCheckCurrentPrivilege(enmSF,PrivilegeData.enmPrivilegeOperation.AddOrModify))
			{
				clsPublicFunction.s_mthShowNotPermitMessage();
				return;
			}			
#endif
			this.Cursor=Cursors.WaitCursor;
			m_mthAddNewRecord((int)enmDiseaseTrackType.HandOver);
			this.Cursor=Cursors.Default;
		}

		private void mniTakeOver_Click(object sender, System.EventArgs e)
		{
			PrivilegeData.enmPrivilegeSF enmSF = (PrivilegeData.enmPrivilegeSF)Enum.Parse(typeof(PrivilegeData.enmPrivilegeSF),this.GetType().Name);
#if FunctionPrivilege
			if(!clsPublicFunction.s_blnCheckCurrentPrivilege(enmSF,PrivilegeData.enmPrivilegeOperation.AddOrModify))
			{
				clsPublicFunction.s_mthShowNotPermitMessage();
				return;
			}			
#endif
			this.Cursor=Cursors.WaitCursor;
			m_mthAddNewRecord((int)enmDiseaseTrackType.TakeOver);
			this.Cursor=Cursors.Default;
		}

		private void mniConsultation_Click(object sender, System.EventArgs e)
		{
			PrivilegeData.enmPrivilegeSF enmSF = (PrivilegeData.enmPrivilegeSF)Enum.Parse(typeof(PrivilegeData.enmPrivilegeSF),this.GetType().Name);
#if FunctionPrivilege
			if(!clsPublicFunction.s_blnCheckCurrentPrivilege(enmSF,PrivilegeData.enmPrivilegeOperation.AddOrModify))
			{
				clsPublicFunction.s_mthShowNotPermitMessage();
				return;
			}			
#endif
			this.Cursor=Cursors.WaitCursor;
			m_mthAddNewRecord((int)enmDiseaseTrackType.Consultation);
			this.Cursor=Cursors.Default;
		}

		private void mniConvey_Click(object sender, System.EventArgs e)
		{
			PrivilegeData.enmPrivilegeSF enmSF = (PrivilegeData.enmPrivilegeSF)Enum.Parse(typeof(PrivilegeData.enmPrivilegeSF),this.GetType().Name);
#if FunctionPrivilege
			if(!clsPublicFunction.s_blnCheckCurrentPrivilege(enmSF,PrivilegeData.enmPrivilegeOperation.AddOrModify))
			{
				clsPublicFunction.s_mthShowNotPermitMessage();
				return;
			}			
#endif
			this.Cursor=Cursors.WaitCursor;
			m_mthAddNewRecord((int)enmDiseaseTrackType.Convey);
			this.Cursor=Cursors.Default;
		}

		private void mniTurnIn_Click(object sender, System.EventArgs e)
		{
			PrivilegeData.enmPrivilegeSF enmSF = (PrivilegeData.enmPrivilegeSF)Enum.Parse(typeof(PrivilegeData.enmPrivilegeSF),this.GetType().Name);
#if FunctionPrivilege
			if(!clsPublicFunction.s_blnCheckCurrentPrivilege(enmSF,PrivilegeData.enmPrivilegeOperation.AddOrModify))
			{
				clsPublicFunction.s_mthShowNotPermitMessage();
				return;
			}			
#endif
			this.Cursor=Cursors.WaitCursor;
			m_mthAddNewRecord((int)enmDiseaseTrackType.TurnIn);
			this.Cursor=Cursors.Default;
		}
		private void mniDiseaseSummary_Click(object sender, System.EventArgs e)
		{
			PrivilegeData.enmPrivilegeSF enmSF = (PrivilegeData.enmPrivilegeSF)Enum.Parse(typeof(PrivilegeData.enmPrivilegeSF),this.GetType().Name);
#if FunctionPrivilege
			if(!clsPublicFunction.s_blnCheckCurrentPrivilege(enmSF,PrivilegeData.enmPrivilegeOperation.AddOrModify))
			{
				clsPublicFunction.s_mthShowNotPermitMessage();
				return;
			}			
#endif
			this.Cursor=Cursors.WaitCursor;
			m_mthAddNewRecord((int)enmDiseaseTrackType.DiseaseSummary);
			this.Cursor=Cursors.Default;
		}
		private void menuCheckRoom_Click(object sender, System.EventArgs e)
		{
			PrivilegeData.enmPrivilegeSF enmSF = (PrivilegeData.enmPrivilegeSF)Enum.Parse(typeof(PrivilegeData.enmPrivilegeSF),this.GetType().Name);
#if FunctionPrivilege
			if(!clsPublicFunction.s_blnCheckCurrentPrivilege(enmSF,PrivilegeData.enmPrivilegeOperation.AddOrModify))
			{
				clsPublicFunction.s_mthShowNotPermitMessage();
				return;
			}			
#endif
			this.Cursor=Cursors.WaitCursor;
			m_mthAddNewRecord((int)enmDiseaseTrackType.CheckRoom);
			this.Cursor=Cursors.Default;
		}

		private void mniCaseDiscuss_Click(object sender, System.EventArgs e)
		{
			PrivilegeData.enmPrivilegeSF enmSF = (PrivilegeData.enmPrivilegeSF)Enum.Parse(typeof(PrivilegeData.enmPrivilegeSF),this.GetType().Name);
#if FunctionPrivilege
			if(!clsPublicFunction.s_blnCheckCurrentPrivilege(enmSF,PrivilegeData.enmPrivilegeOperation.AddOrModify))
			{
				clsPublicFunction.s_mthShowNotPermitMessage();
				return;
			}			
#endif
			this.Cursor=Cursors.WaitCursor;
			m_mthAddNewRecord((int)enmDiseaseTrackType.CaseDiscuss);
			this.Cursor=Cursors.Default;
		}

		private void mniBeforeOperationDiscuss_Click(object sender, System.EventArgs e)
		{
			PrivilegeData.enmPrivilegeSF enmSF = (PrivilegeData.enmPrivilegeSF)Enum.Parse(typeof(PrivilegeData.enmPrivilegeSF),this.GetType().Name);
#if FunctionPrivilege
			if(!clsPublicFunction.s_blnCheckCurrentPrivilege(enmSF,PrivilegeData.enmPrivilegeOperation.AddOrModify))
			{
				clsPublicFunction.s_mthShowNotPermitMessage();
				return;
			}			
#endif
			this.Cursor=Cursors.WaitCursor;
			m_mthAddNewRecord((int)enmDiseaseTrackType.BeforeOperationDiscuss);
			this.Cursor=Cursors.Default;
		}

		private void mniDeadCaseDiscuss_Click(object sender, System.EventArgs e)
		{
			PrivilegeData.enmPrivilegeSF enmSF = (PrivilegeData.enmPrivilegeSF)Enum.Parse(typeof(PrivilegeData.enmPrivilegeSF),this.GetType().Name);
#if FunctionPrivilege
			if(!clsPublicFunction.s_blnCheckCurrentPrivilege(enmSF,PrivilegeData.enmPrivilegeOperation.AddOrModify))
			{
				clsPublicFunction.s_mthShowNotPermitMessage();
				return;
			}			
#endif
			this.Cursor=Cursors.WaitCursor;
			m_mthAddNewRecord((int)enmDiseaseTrackType.DeadCaseDiscuss);
			this.Cursor=Cursors.Default;
		}

		private void mniDead_Click(object sender, System.EventArgs e)
		{
			PrivilegeData.enmPrivilegeSF enmSF = (PrivilegeData.enmPrivilegeSF)Enum.Parse(typeof(PrivilegeData.enmPrivilegeSF),this.GetType().Name);
#if FunctionPrivilege
			if(!clsPublicFunction.s_blnCheckCurrentPrivilege(enmSF,PrivilegeData.enmPrivilegeOperation.AddOrModify))
			{
				clsPublicFunction.s_mthShowNotPermitMessage();
				return;
			}			
#endif
			this.Cursor=Cursors.WaitCursor;
			m_mthAddNewRecord((int)enmDiseaseTrackType.Dead);
			this.Cursor=Cursors.Default;
		}

		private void mniOutHospital_Click(object sender, System.EventArgs e)
		{
			PrivilegeData.enmPrivilegeSF enmSF = (PrivilegeData.enmPrivilegeSF)Enum.Parse(typeof(PrivilegeData.enmPrivilegeSF),this.GetType().Name);
#if FunctionPrivilege
			if(!clsPublicFunction.s_blnCheckCurrentPrivilege(enmSF,PrivilegeData.enmPrivilegeOperation.AddOrModify))
			{
				clsPublicFunction.s_mthShowNotPermitMessage();
				return;
			}			
#endif
			this.Cursor=Cursors.WaitCursor;
			m_mthAddNewRecord((int)enmDiseaseTrackType.OutHospital);
			this.Cursor=Cursors.Default;
		}

		private void mniAfterOperation_Click(object sender, System.EventArgs e)
		{
			PrivilegeData.enmPrivilegeSF enmSF = (PrivilegeData.enmPrivilegeSF)Enum.Parse(typeof(PrivilegeData.enmPrivilegeSF),this.GetType().Name);
#if FunctionPrivilege
			if(!clsPublicFunction.s_blnCheckCurrentPrivilege(enmSF,PrivilegeData.enmPrivilegeOperation.AddOrModify))
			{
				clsPublicFunction.s_mthShowNotPermitMessage();
				return;
			}			
#endif
			this.Cursor=Cursors.WaitCursor;
			m_mthAddNewRecord((int)enmDiseaseTrackType.AfterOperation);
			this.Cursor=Cursors.Default;
		}

		private void mniSave_Click(object sender, System.EventArgs e)
		{
			PrivilegeData.enmPrivilegeSF enmSF = (PrivilegeData.enmPrivilegeSF)Enum.Parse(typeof(PrivilegeData.enmPrivilegeSF),this.GetType().Name);
#if FunctionPrivilege
			if(!clsPublicFunction.s_blnCheckCurrentPrivilege(enmSF,PrivilegeData.enmPrivilegeOperation.AddOrModify))
			{
				clsPublicFunction.s_mthShowNotPermitMessage();
				return;
			}			
#endif
			this.Cursor=Cursors.WaitCursor;
			m_mthAddNewRecord((int)enmDiseaseTrackType.Save);
			this.Cursor=Cursors.Default;
		}
		#endregion 添加菜单		

		/// <summary>
		/// 获取当前病人的作废内容
		/// </summary>
		/// <param name="p_dtmRecordDate">记录日期</param>
		/// <param name="p_intFormID">窗体ID</param>
		protected override void m_mthGetDeactiveContent(DateTime p_dtmRecordDate,int p_intFormID)
		{			
			m_mthGetDeletedRecord(p_intFormID,p_dtmRecordDate);
		}

		/// <summary>
		/// 自动打开首次病程记录
		/// </summary>
		protected override void m_mthAutoAddNewRecord()
		{
            if (!mniAppend.Visible)
            {
                return;
            }
			m_blnIfPromtForArchiving = false;
			mniFirstIllnessNote_Click(null, System.EventArgs.Empty);

            if (this.m_FrmCurrentSub != null)
            {
                this.m_FrmCurrentSub.Activate();
                this.m_FrmCurrentSub.WindowState = FormWindowState.Normal;
                this.m_FrmCurrentSub.TopMost = true;
            }
		}

		/// <summary>
		/// 是否弹出归档提示
		/// </summary>
		private bool m_blnIfPromtForArchiving = true;
		/// <summary>
		/// 归档提示
		/// </summary>
		/// <param name="p_blnIfReadOnly"></param>
		/// <param name="p_strTimeRemaing"></param>
		protected override void m_mthPromtForArchiving(bool p_blnIfReadOnly,string p_strTimeRemaing)
		{
			if(m_blnIfPromtForArchiving)
			{
				if(p_blnIfReadOnly)
				{
                    //clsPublicFunction.ShowInformationMessageBox("此病人的所有病历为只读，不能修改。");
				}
				else if(p_strTimeRemaing!=null && p_strTimeRemaing.Trim().Length!=0)
				{
					clsPublicFunction.ShowInformationMessageBox("此病人的所有病历在"+p_strTimeRemaing+"后将变为只读，若要修改请注意时间。");
				}

				m_blnIfPromtForArchiving = true;
			}
		}

        /// <summary>
        /// 处理子窗体
        /// </summary>
        /// <param name="p_frmSubForm"></param>
        protected override void m_mthHandleSubFormClosedWithYes(frmDiseaseTrackBase p_frmSubForm)
        {
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
            m_mthPerformSessionChanged(m_ObjCurrentEmrPatientSession, 0);
        }

        /// <summary>
        ///  开始打印。 
        /// </summary>
        protected override void m_mthStartPrint()
        {
            if (m_blnDirectPrint)
            {
                m_pdcPrintDocument.Print();
            }
            else
            {
                ((clsSubDiseaseTrackPrintTool)objPrintTool).m_mthPrintPage();

            }
        }
        /// <summary>
        /// 右键添加“设置/分页”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSubDiseaseTrack_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.MenuItem mniPageAdd = new System.Windows.Forms.MenuItem();
            mniPageAdd.Index = 0;
            mniPageAdd.Text = "设置";
            mniPageAdd.Click += new System.EventHandler(mniPageAdd_Click);
            System.Windows.Forms.MenuItem mniPageRemove = new System.Windows.Forms.MenuItem();
            mniPageRemove.Index = 1;
            mniPageRemove.Text = "清除";
            mniPageRemove.Click += new System.EventHandler(mniPageRemove_Click);
            System.Windows.Forms.MenuItem menuItem1 = new System.Windows.Forms.MenuItem();
            menuItem1.Index = 5;
            menuItem1.Text = "-";
            System.Windows.Forms.MenuItem menuItem2 = new System.Windows.Forms.MenuItem();
            menuItem2.Index = 6;
            menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] 
			{
				mniPageAdd,
				mniPageRemove
			});
            menuItem2.Text = "设置分页";

            System.Windows.Forms.MenuItem menuItem3 = new System.Windows.Forms.MenuItem();
            menuItem3.Index = 7;
            menuItem3.Text = "-";
            System.Windows.Forms.MenuItem mniAbnormalInfo = new System.Windows.Forms.MenuItem();
            mniAbnormalInfo.Index = 3;
            mniAbnormalInfo.Text = "异常信息";
            mniAbnormalInfo.Click += new System.EventHandler(this.mniAbnormalInfo_Click);
            mniAbnormalInfo.Enabled = true;
            this.ctmRecordControl.MenuItems.Add(menuItem1);
            this.ctmRecordControl.MenuItems.Add(menuItem2);
            this.ctmRecordControl.MenuItems.Add(menuItem3);
            this.ctmRecordControl.MenuItems.Add(mniAbnormalInfo);
            CreateDataGridStyle();
        }
        private clsInPatientEvaluateDomain m_objInPatientEvaluateDomain = new clsInPatientEvaluateDomain();
        private void mniAbnormalInfo_Click(object sender, System.EventArgs e)
        {
            string strAbnormalInfo;
            if (txtInPatientID.Text.Trim() == "" || this.m_trvInPatientDate.SelectedNode == null || this.m_trvInPatientDate.SelectedNode == m_trvInPatientDate.Nodes[0])
                return;
            long lngRes = m_objInPatientEvaluateDomain.m_lngGetAbnormalInfo(m_objCurrentPatient.m_StrInPatientID, m_objCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"), out strAbnormalInfo);
            if (lngRes <= 0)
            {
                if (lngRes == (long)iCareData.enmOperationResult.Not_permission)
                    m_mthShowNotPermitted();
                else m_mthShowDBError();
            }
            else
            {
                frmMessageForm frmmessageform = new frmMessageForm("异常信息:", strAbnormalInfo);
                frmmessageform.ShowDialog();
            }
        }
        /// <summary>
        /// 添加分页标志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mniPageAdd_Click(object sender, System.EventArgs e)
        {
            m_mthSetPaginations("1");
        }
        /// <summary>
        /// 删除分页标志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mniPageRemove_Click(object sender, System.EventArgs e)
        {
            m_mthSetPaginations("0");
        }

        protected override void m_mthAfterLoadData()
        {
            if (m_ObjCurrentEmrPatientSession != null 
                && m_ObjCurrentEmrPatientSession.m_dtmOutDate != DateTime.MinValue && m_ObjCurrentEmrPatientSession.m_dtmOutDate != new DateTime(1900,1,1))
            {
                return;//已出院病人不作判断
            }
            com.digitalwave.emr.AssistModuleSev.clsLockCaseServ objServ =
                (com.digitalwave.emr.AssistModuleSev.clsLockCaseServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.emr.AssistModuleSev.clsLockCaseServ));
            long checkDate = 0;
            objServ.m_lngCheckYoN(out checkDate);
            if (checkDate == 1)
            {
                clsPublicDomain objPD = new clsPublicDomain();
                DateTime dtmNow = objPD.m_dtmGetServerTime();
                mniAppend.Visible = true;

                DateTime dtmLastOpenDate = DateTime.MinValue;
                int intDays = 0;
                if (m_dtbRecords != null && m_dtbRecords.Rows.Count > 2)
                {
                    if (DateTime.TryParse(m_dtbRecords.Rows[m_intGetRecordStartRow(m_dtbRecords.Rows.Count - 2)][2].ToString(), out dtmLastOpenDate))
                    {

                        TimeSpan ts = dtmNow - dtmLastOpenDate;
                        intDays = ts.Days;
                    }

                }
                else
                {
                    dtmLastOpenDate = m_ObjCurrentEmrPatient.m_dtmHISInDate;
                    TimeSpan ts = dtmNow - dtmLastOpenDate;
                    intDays = ts.Days;
                }

                com.digitalwave.emr.AssistModuleSev.clsLockCaseServ_Modify objServ_Modify =
            (com.digitalwave.emr.AssistModuleSev.clsLockCaseServ_Modify)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.emr.AssistModuleSev.clsLockCaseServ_Modify));


                long lngRes = 0;
                bool blnIsUnLock = true;
                bool blnIsAlreadyUnLock = true;
                if (m_ObjCurrentEmrPatient.m_intSTATE_INT == 1 && intDays > 1)
                {
                    lngRes = objServ.m_lngCheckIsUnLock(this.Name, m_ObjCurrentEmrPatient.m_strREGISTERID_CHR, dtmLastOpenDate, out blnIsAlreadyUnLock, out blnIsUnLock);

                    if (!blnIsUnLock)
                    {
                        if (!blnIsAlreadyUnLock)
                        {
                            lngRes = objServ_Modify.m_lngAddLockData(m_ObjCurrentEmrPatient.m_strREGISTERID_CHR, this.Name, this.Text, dtmLastOpenDate.AddDays(1));
                        }
                        clsPublicFunction.ShowInformationMessageBox("病危病人至少一天记录一次病程记录，"
                                                   + Environment.NewLine + "距上次记录病程记录已超过" + intDays.ToString() + "天,"
                                                   + Environment.NewLine + "本记录已锁定，不能添加新的记录。");
                        mniAppend.Visible = false;
                    }

                }
                else if (m_ObjCurrentEmrPatient.m_intSTATE_INT == 2 && intDays > 2)
                {
                    lngRes = objServ.m_lngCheckIsUnLock(this.Name, m_ObjCurrentEmrPatient.m_strREGISTERID_CHR, dtmLastOpenDate, out blnIsAlreadyUnLock, out blnIsUnLock);

                    if (!blnIsUnLock)
                    {
                        if (!blnIsAlreadyUnLock)
                        {
                            lngRes = objServ_Modify.m_lngAddLockData(m_ObjCurrentEmrPatient.m_strREGISTERID_CHR, this.Name, this.Text, dtmLastOpenDate.AddDays(2));
                        }
                        clsPublicFunction.ShowInformationMessageBox("病重病人至少两天记录一次病程记录，"
                             + Environment.NewLine + "距上次记录病程记录已超过" + intDays.ToString() + "天,"
                             + Environment.NewLine + "本记录已锁定，不能添加新的记录。");
                        mniAppend.Visible = false;
                    }
                }
                else if (intDays > 3)
                {
                    lngRes = objServ.m_lngCheckIsUnLock(this.Name, m_ObjCurrentEmrPatient.m_strREGISTERID_CHR, dtmLastOpenDate, out blnIsAlreadyUnLock, out blnIsUnLock);

                    if (!blnIsUnLock)
                    {
                        if (!blnIsAlreadyUnLock)
                        {
                            lngRes = objServ_Modify.m_lngAddLockData(m_ObjCurrentEmrPatient.m_strREGISTERID_CHR, this.Name, this.Text, dtmLastOpenDate.AddDays(3));
                        }
                        clsPublicFunction.ShowInformationMessageBox("普通病人至少三天记录一次病程记录，"
                          + Environment.NewLine + "距上次记录病程记录已超过" + intDays.ToString() + "天,"
                          + Environment.NewLine + "本记录已锁定，不能添加新的记录。");
                        mniAppend.Visible = false;
                    }
                }

                objServ = null;
            }
        }

        #region 作废重做
        protected override bool m_blnSubReuse(clsInactiveRecordInfo_VO p_objSelectedValue)
        {
            bool blnIsOK = false;
            if (m_blnSubIsExists())
            {
                return blnIsOK;
            }
            if (p_objSelectedValue != null)
            {
                m_mthGetDeletedRecord(-1, p_objSelectedValue.m_DtmOpenDate);
                blnIsOK = true;
            }
            return blnIsOK;
        }

        protected override clsInactiveRecordInfo_VO[] m_objSubGetAllInactiveInfo(clsInactiveRecordInfo_VO p_objSelectedValue)
        {
            clsInactiveRecordInfo_VO[] objArr = null;
            m_objGetRecordsDomain().m_lngGetAllInactiveInfo(null, p_objSelectedValue.m_StrInpatientId, p_objSelectedValue.m_DtmInpatientDate, out objArr);
            return objArr;
        }
        public override bool m_blnIsNewSetInactiveForm
        {
            get { return true; }
        }
        #endregion 作废重做
	}
}

