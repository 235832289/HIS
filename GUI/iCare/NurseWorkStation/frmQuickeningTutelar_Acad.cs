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
using com.digitalwave.clsGeneralNurseRecord_GXService;
namespace iCare
{
	/// <summary>
	/// 胎动监护表 的摘要说明。
	/// </summary>
	public class frmQuickeningTutelar_Acad: iCare.frmRecordsBase
	{			 
		private string m_strCurrentOpenDate = "";
		private string m_strCreateUserID = "";
		protected com.digitalwave.Utility.Controls.ctlTimePicker m_dtpCreateDate;
		private System.Windows.Forms.DataGridTextBoxColumn m_dtcRecordDate_chr;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcPREGNANTTEAM_CHR;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcMORNING_CHR;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcMIDDAY_CHR;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcEVENING_CHR;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox m_dtcQUICKENINGNUM_CHR;
		//private System.Windows.Forms.DataGridTextBoxColumn m_strdtcRecord_chr;
	
		private void InitializeComponent()
		{
            this.m_dtcRecordDate_chr = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_dtcPREGNANTTEAM_CHR = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcMORNING_CHR = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcMIDDAY_CHR = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcEVENING_CHR = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcQUICKENINGNUM_CHR = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgRecordDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtbRecords)).BeginInit();
            this.m_pnlNewBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgtsStyles
            // 
            this.dgtsStyles.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																										 this.m_dtcRecordDate_chr,
																										 this.m_dtcPREGNANTTEAM_CHR,
																										 this.m_dtcMORNING_CHR,
																										 this.m_dtcMIDDAY_CHR,
																										 this.m_dtcEVENING_CHR,
																										 this.m_dtcQUICKENINGNUM_CHR});
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
            this.m_dtgRecordDetail.Location = new System.Drawing.Point(8, 88);
            this.m_dtgRecordDetail.Size = new System.Drawing.Size(804, 528);
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
            this.m_trvInPatientDate.Location = new System.Drawing.Point(107, 142);
            this.m_trvInPatientDate.Size = new System.Drawing.Size(176, 60);
            this.m_trvInPatientDate.Visible = false;
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(473, 146);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(598, 130);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(377, 125);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(377, 151);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(479, 125);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(486, 168);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(486, 151);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(329, 129);
            this.lblAreaTitle.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(337, 168);
            this.txtInPatientID.Size = new System.Drawing.Size(96, 23);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(393, 165);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(408, 130);
            this.m_txtBedNO.Size = new System.Drawing.Size(72, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(289, 142);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(308, 142);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(289, 165);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(458, 170);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.m_cmdNext.Location = new System.Drawing.Point(485, 122);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(363, 151);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(425, 120);
            this.m_lblForTitle.Size = new System.Drawing.Size(8, 23);
            this.m_lblForTitle.Visible = false;
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(654, 36);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Size = new System.Drawing.Size(803, 60);
            this.m_pnlNewBase.Visible = true;
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(801, 29);
            // 
            // m_dtcRecordDate_chr
            // 
            this.m_dtcRecordDate_chr.Format = "";
            this.m_dtcRecordDate_chr.FormatInfo = null;
            this.m_dtcRecordDate_chr.MappingName = "RecordDate_chr";
            this.m_dtcRecordDate_chr.Width = 140;
            // 
            // m_dtcPREGNANTTEAM_CHR
            // 
            this.m_dtcPREGNANTTEAM_CHR.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcPREGNANTTEAM_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcPREGNANTTEAM_CHR.m_BlnGobleSet = true;
            this.m_dtcPREGNANTTEAM_CHR.m_BlnUnderLineDST = false;
            this.m_dtcPREGNANTTEAM_CHR.MappingName = "PREGNANTTEAM_CHR";
            this.m_dtcPREGNANTTEAM_CHR.Width = 110;
            // 
            // m_dtcMORNING_CHR
            // 
            this.m_dtcMORNING_CHR.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcMORNING_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcMORNING_CHR.m_BlnGobleSet = true;
            this.m_dtcMORNING_CHR.m_BlnUnderLineDST = false;
            this.m_dtcMORNING_CHR.MappingName = "MORNING_CHR";
            this.m_dtcMORNING_CHR.Width = 110;
            // 
            // m_dtcMIDDAY_CHR
            // 
            this.m_dtcMIDDAY_CHR.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcMIDDAY_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcMIDDAY_CHR.m_BlnGobleSet = true;
            this.m_dtcMIDDAY_CHR.m_BlnUnderLineDST = false;
            this.m_dtcMIDDAY_CHR.MappingName = "MIDDAY_CHR";
            this.m_dtcMIDDAY_CHR.Width = 110;
            // 
            // m_dtcEVENING_CHR
            // 
            this.m_dtcEVENING_CHR.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcEVENING_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcEVENING_CHR.m_BlnGobleSet = true;
            this.m_dtcEVENING_CHR.m_BlnUnderLineDST = false;
            this.m_dtcEVENING_CHR.MappingName = "EVENING_CHR";
            this.m_dtcEVENING_CHR.Width = 110;
            // 
            // m_dtcQUICKENINGNUM_CHR
            // 
            this.m_dtcQUICKENINGNUM_CHR.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_dtcQUICKENINGNUM_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcQUICKENINGNUM_CHR.m_BlnGobleSet = true;
            this.m_dtcQUICKENINGNUM_CHR.m_BlnUnderLineDST = false;
            this.m_dtcQUICKENINGNUM_CHR.MappingName = "QUICKENINGNUM_CHR";
            this.m_dtcQUICKENINGNUM_CHR.Width = 140;
            // 
            // frmQuickeningTutelar_Acad
            // 
            this.ClientSize = new System.Drawing.Size(840, 685);
            this.Name = "frmQuickeningTutelar_Acad";
            this.Text = "胎动监护表";
            this.Load += new System.EventHandler(this.frmQuickeningTutelar_Acad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgRecordDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtbRecords)).EndInit();
            this.m_pnlNewBase.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
	
		public frmQuickeningTutelar_Acad()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
           InitializeComponent();
		}

		private void frmQuickeningTutelar_Acad_Load(object sender, System.EventArgs e)
		{
		
		}
		
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
			//			p_dtbRecordTable.Columns.Add("RecordDate_chr",typeof(clsDSTRichTextBoxValue));//4
			//			p_dtbRecordTable.Columns.Add("Time_chr",typeof(clsDSTRichTextBoxValue));//5
			p_dtbRecordTable.Columns.Add("PREGNANTTEAM_CHR",typeof(clsDSTRichTextBoxValue));//5
					
			p_dtbRecordTable.Columns.Add("MORNING_CHR",typeof(clsDSTRichTextBoxValue));//6

			p_dtbRecordTable.Columns.Add("MIDDAY_CHR",typeof(clsDSTRichTextBoxValue));//7
			p_dtbRecordTable.Columns.Add("EVENING_CHR",typeof(clsDSTRichTextBoxValue));//8
			p_dtbRecordTable.Columns.Add("QUICKENINGNUM_CHR",typeof(clsDSTRichTextBoxValue));//9

			//			m_dtcGenaralInstance.m_RtbBase.m_BlnReadOnly = true;
			m_mthSetControl(m_dtcRecordDate_chr);
			m_mthSetControl(m_dtcPREGNANTTEAM_CHR);
			m_mthSetControl(m_dtcMORNING_CHR);

			m_mthSetControl(m_dtcMIDDAY_CHR);
			m_mthSetControl(m_dtcEVENING_CHR);
			m_mthSetControl(m_dtcQUICKENINGNUM_CHR);
			
			//设置文字栏
			this.m_dtcRecordDate_chr.HeaderText = "\r\n\t    日\r\n\r\n\r\n\t    期";
			this.m_dtcPREGNANTTEAM_CHR.HeaderText = "\r\n\t 孕\r\n\r\n\r\n\t 周";

			this.m_dtcMORNING_CHR.HeaderText = "\t\r\n\r\n\r\n\t  早";


			this.m_dtcMIDDAY_CHR.HeaderText = "    \t\r\n\r\n\r\n\t  中";
			this.m_dtcEVENING_CHR .HeaderText = "\t\r\n\r\n\r\n\t  晚";
			this.m_dtcQUICKENINGNUM_CHR.HeaderText = "\r\n\r\n\r\n12 小 时 胎 动 数";

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
		private DateTime m_dtmPreRecordDate = DateTime.MinValue;
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
            return new clsRecordsDomain(enmRecordsType.QuickeningTutelar_Acad);
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
				case enmDiseaseTrackType.QuickeningTutelar_Acad:
					objContent = new clsQuickeningTutelarValue();//(需要改动)
					break;
			}

			if(objContent == null)
				objContent=new clsQuickeningTutelarValue();	//(需要改动)
		
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
            objContent.m_strCreateUserID = clsEMRLogin.LoginEmployee.m_strEMPNO_CHR;
			return objContent;
		}

//		private void frmWaitLayRecord_Acad_Load(object sender, System.EventArgs e)
//		{
//			m_dtmPreRecordDate = DateTime.MinValue;
//			m_dtgRecordDetail.Focus();
//			m_mniAddBlank.Visible=false;
//			m_mniDeleteBlank.Visible=false;
//
//			m_txtDiseaseID.ReadOnly = true;
//			m_dtpCreateDate.ReadOnly = true;
//		
//		}

//		#region 对产期与产次的处理
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
//		#endregion 
		// 获取处理（添加和修改）记录的窗体。
		protected override frmDiseaseTrackBase m_frmGetRecordForm(int p_intRecordType)
		{
			switch((enmDiseaseTrackType)p_intRecordType)
			{
				case enmDiseaseTrackType.QuickeningTutelar_Acad://(需要改动)
					
				{
					frmQuickeningTutelar_AcadCon frmwcon = new frmQuickeningTutelar_AcadCon();
	//				frmwcon.m_dtmBEFOREHAND_CHR = m_dtpCreateDate.Value;
//					frmwcon.m_strLAYCOUNT_CHR =  m_txtDiseaseID.Text;//产次
//					frmwcon.m_setLaycout();
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
			m_mthAddNewRecord((int)enmDiseaseTrackType.QuickeningTutelar_Acad);//(需要改动)
		}

		protected override infPrintRecord m_objGetPrintTool()
		{			
			clsQuickeningTutelar_AcadPrintTool pt = new clsQuickeningTutelar_AcadPrintTool();
//			//pt.m_strLaycount = m_txtDiseaseID.Text ;//产次
//			//pt.m_strBirthDate = m_dtpCreateDate.Value.Date.ToShortDateString();
            return pt;
	}

		
		protected override object[][] m_objGetRecordsValueArr(clsTransDataInfo p_objTransDataInfo)
		{
			#region 显示记录到DataGrid
			try
			{

//				#region 处理产次
//				m_txtDiseaseID.Text = "";				
//			m_dtpCreateDate.Value = System.DateTime.Now;
//				#endregion
				if(p_objTransDataInfo == null)
					return null;

				object[] objData;
				ArrayList objReturnData=new ArrayList();

				clsQuickeningTutelarContentDataInfo objICUInfo=new clsQuickeningTutelarContentDataInfo();	//(需要改动)		
				clsDSTRichTextBoxValue objclsDSTRichTextBoxValue;
				string strText,strXml;

				objICUInfo = (clsQuickeningTutelarContentDataInfo)p_objTransDataInfo;//(需要改动)

				if(objICUInfo.m_objRecordArr == null)
					return null;

				int intRecordCount = objICUInfo.m_objRecordArr.Length;
				int intRowOfCurrentDetail = 0;

				for(int i=0; i<intRecordCount; i++)
				{
					objData = new object[10];   //(需要改动) DataTable的列数
					clsQuickeningTutelarValue objCurrent = objICUInfo.m_objRecordArr[i];//(需要改动)
					clsQuickeningTutelarValue objNext = new clsQuickeningTutelarValue();//下一条记录//(需要改动)
					if(i < intRecordCount-1)
						objNext = objICUInfo.m_objRecordArr[i+1];


					#region 存放关键字段
					if(objCurrent.m_dtmCreateDate!=DateTime.MinValue)
					{
						objData[0] = objCurrent.m_dtmCreateDate;//存放记录时间的字符串
						objData[1] = (int)enmRecordsType.QuickeningTutelar_Acad;//存放记录类型的int值  //(需要改动)
						objData[2] = objCurrent.m_dtmOpenDate;//存放记录的OpenDate字符串
						objData[3] = objICUInfo.m_objRecordArr[objICUInfo.m_objRecordArr.Length-1].m_dtmModifyDate;//存放记录的ModifyDate字符串   
						
						objData[4] = objCurrent.m_dtmCreateDate.ToString("yyyy-MM-dd") ;//日期字符串
						//修改后带有痕迹的记录不再显示时间
//						if(i==0 || (i > 0 && objICUInfo.m_objRecordArr[i-1].m_dtmCreateDate != objCurrent.m_dtmCreateDate))
//							objData[5] = objCurrent.m_dtmCreateDate.ToString("HH:mm");//时间字符串
//	
					}
					m_dtmPreRecordDate = objCurrent.m_dtmCreateDate;	
					#endregion ;

					
//					//产次处理
//					m_txtDiseaseID.Text = objCurrent.m_strLayCount_chr;
//					if(objCurrent.m_strBeforehand_chr.Trim() != "")
//						m_dtpCreateDate.Value = Convert.ToDateTime(objCurrent.m_strBeforehand_chr.ToString().Trim());
//					//

					#region 存放单项信息
					//
					strText = objCurrent.m_strPREGNANTTEAM_CHR_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strPREGNANTTEAM_CHR_RIGHT != objCurrent.m_strPREGNANTTEAM_CHR_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strPREGNANTTEAM_CHR_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[5] = objclsDSTRichTextBoxValue;//孕周

					//早
					strText = objCurrent.m_strMORNING_CHR_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strMORNING_CHR_RIGHT != objCurrent.m_strMORNING_CHR_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strMORNING_CHR_RIGHT ,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[6] = objclsDSTRichTextBoxValue;//早

			
					//中
					strText = objCurrent.m_strMIDDAY_CHR_RIGHT ;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strMIDDAY_CHR_RIGHT != objCurrent.m_strMIDDAY_CHR_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strMIDDAY_CHR_RIGHT,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[7] = objclsDSTRichTextBoxValue;//中

					// 晚
					strText = objCurrent.m_strEVENING_CHR_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strEVENING_CHR_RIGHT != objCurrent.m_strEVENING_CHR_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strEVENING_CHR_RIGHT,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[8] = objclsDSTRichTextBoxValue;// 晚

			
					//12小时胎动数
					strText = objCurrent.m_strQUICKENINGNUM_CHR_RIGHT;
					strXml = "<root />";
					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strQUICKENINGNUM_CHR_RIGHT != objCurrent.m_strQUICKENINGNUM_CHR_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
						strXml = m_strGetDSTTextXML(objCurrent.m_strQUICKENINGNUM_CHR_RIGHT,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					objData[9] = objclsDSTRichTextBoxValue;//12小时胎动数
			
				
//					// 检查着
//					strText = objCurrent.m_strScrutator_chr_RIGHT ;
//					strXml = "<root />";
//					if(objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strScrutator_chr_RIGHT != objCurrent.m_strScrutator_chr_RIGHT)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
//					{
//						strXml = m_strGetDSTTextXML(objCurrent.m_strScrutator_chr_RIGHT,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
//					}
//					objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
//					objclsDSTRichTextBoxValue.m_strText=strText;						
//					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
//					objData[18] = objclsDSTRichTextBoxValue;//

					#region bak
					//一般情况
					//					string[] strGeneralInstanceArr = null;
					//					string[] strGeneralInstanceXMLArr = null;
					//					if(objCurrent.m_strGENERALINSTANCE_RIGHT != null ||objCurrent.m_strGENERALINSTANCE_RIGHT != "")
					//					{
					//						string strGeneralInstance = objCurrent.m_strGENERALINSTANCE_RIGHT;
					//						string strGeneralInstanceXML = objCurrent.m_strGENERALINSTANCEXML;
					//						string[] strGeneralInstanceArrTemp;
					//						string[] strGeneralInstanceXMLArrTemp;
					//						//将病情记录分为20个字符一行。因第一行要空两格，故添加空字符串
					//						com.digitalwave.controls.ctlRichTextBox.m_mthSplitXml("    "+strGeneralInstance,strGeneralInstanceXML,16,out strGeneralInstanceArrTemp,out strGeneralInstanceXMLArrTemp);
					//						
					//						if(objCurrent.m_strCreateUserName != null && objCurrent.m_strCreateUserName != "")
					//						{
					//							strGeneralInstanceArr = new string[strGeneralInstanceArrTemp.Length + 1];
					//							strGeneralInstanceXMLArr = new string[strGeneralInstanceXMLArrTemp.Length + 1];
					//
					//							for(int j=0; j<strGeneralInstanceArr.Length-1; j++)
					//							{
					//								strGeneralInstanceArr[j] = strGeneralInstanceArrTemp[j];
					//							}
					//							strGeneralInstanceArr[strGeneralInstanceArr.Length-1] = objCurrent.m_dtmCreateDate.ToString("yyyy-MM-dd")+"    "+objCurrent.m_strCreateUserName;
					//							
					//							strGeneralInstanceXMLArr[strGeneralInstanceXMLArr.Length-1] = "";
					//							for(int j=0; j<strGeneralInstanceXMLArr.Length-1; j++)
					//							{
					//								strGeneralInstanceXMLArr[j] = strGeneralInstanceXMLArrTemp[j];
					//							}
					//						}
					//						else
					//						{
					//							strGeneralInstanceArr = strGeneralInstanceArrTemp;
					//							strGeneralInstanceXMLArr = strGeneralInstanceXMLArrTemp;
					//						}
					//
					//						strText = strGeneralInstanceArr[0];
					//						strXml = strGeneralInstanceXMLArr[0];
					//						objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					//						objclsDSTRichTextBoxValue.m_strText=strText;						
					//						objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					//						objData[16] = objclsDSTRichTextBoxValue;
					//					}

					//					objReturnData.Add(objData);
					//					
					//					if(strGeneralInstanceArr.Length > 1)
					//					{
					//						object[] objInstance = null;
					//						for(int j=1; j<strGeneralInstanceArr.Length; j++)
					//						{
					//							objInstance = new object[17];
					//							strText = strGeneralInstanceArr[j];
					//							strXml = strGeneralInstanceXMLArr[j];
					//							objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
					//							objclsDSTRichTextBoxValue.m_strText=strText;						
					//							objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
					//							objInstance[16] = objclsDSTRichTextBoxValue;
					//							objReturnData.Add(objInstance);
					//						}
					//					}
					#endregion
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
	}
}
