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


namespace iCare
{
	public class frmWatchItemTrack : iCare.frmRecordsBase
	{
		#region Define
		private System.Windows.Forms.DataGridTextBoxColumn m_dtcDate;
		private System.Windows.Forms.DataGridTextBoxColumn m_dtcTime;
		private cltDataGridDSTRichTextBox m_dtcTemperature;
		private cltDataGridDSTRichTextBox m_dtcHeartRhythm;
		private cltDataGridDSTRichTextBox m_dtcHeartFrequency;
		private cltDataGridDSTRichTextBox m_dtcPulse;
		private cltDataGridDSTRichTextBox m_dtcBreath;
		private cltDataGridDSTRichTextBox m_dtcEchoLeft;
		private cltDataGridDSTRichTextBox m_dtcEchoRight;
		private cltDataGridDSTRichTextBox m_dtcPupilLeft;
		private cltDataGridDSTRichTextBox m_dtcPupilRight;
		private cltDataGridDSTRichTextBox m_dtcBloodOxygenSaturation;
		private cltDataGridDSTRichTextBox m_dtcBedsideBloodSugar;
		private cltDataGridDSTRichTextBox m_dtcBloodPressureS;
		private cltDataGridDSTRichTextBox m_dtcBloodPressureA;
		private cltDataGridDSTRichTextBox m_dtcOutE;
		private cltDataGridDSTRichTextBox m_dtcOutU;
		private cltDataGridDSTRichTextBox m_dtcOutS;
		private cltDataGridDSTRichTextBox m_dtcOutV;
		private System.Windows.Forms.DataGridTextBoxColumn m_dtcSign;
		private cltDataGridDSTRichTextBox m_dtcInI;
		private cltDataGridDSTRichTextBox m_dtcInD;
		private System.Windows.Forms.Panel panel1;

		private System.ComponentModel.IContainer components = null;
		
		private string m_strCurrentOpenDate = "";
		private string m_strCreateUserID = "";

		#endregion
		public frmWatchItemTrack()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			m_dtcOutE.m_BlnUnderLineDST = true;
			m_dtcOutS.m_BlnUnderLineDST = true;
			m_dtcOutU.m_BlnUnderLineDST = true;
			m_dtcOutV.m_BlnUnderLineDST = true;
			m_dtcInD.m_BlnUnderLineDST = true;
			m_dtcInI.m_BlnUnderLineDST = true;
		}

		protected override Font m_FntHeaderFont
		{
			get
			{
				return new System.Drawing.Font("SimSun", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			}
		}

		#region 有关打印的声明
//		/// <summary>
//		/// （基于危重护理记录的）打印上下文的类
//		/// </summary>		
//		private clsPrintRichTextContext m_objPrintContext;
		/// <summary>
		/// 当前行的Y坐标
		/// </summary>
		private int m_intPosY = (int)enmRecordRectangleInfo.TopY+150;
		/// <summary>
		/// 每行数据行的高度
		/// </summary>
		int intTempDeltaY = 38;	
		/// <summary>
		/// 标题的字体
		/// </summary>
		private Font m_fotTitleFont;
		/// <summary>
		/// 表头的字体
		/// </summary>
		private Font m_fotHeaderFont;
		/// <summary>
		/// 表内容的字体
		/// </summary>
		private Font m_fotSmallFont;
		/// <summary>
		/// 最小的字体
		/// </summary>
		private Font m_fotTinyFont;
		/// <summary>
		/// 边框画笔
		/// </summary>
		private Pen m_GridPen;
		/// <summary>
		/// 刷子
		/// </summary>
		private SolidBrush m_slbBrush;
		/// <summary>
		/// 记录打印到第几页
		/// </summary>
		private int m_intNowPage=1;
		/// <summary>
		/// 当前打印的记录的序号
		/// </summary>
		private int m_intCurrentRecord=0;  
		/// <summary>
		/// 旧记录打完,准备打印一条新记录
		/// </summary>
		bool m_blnBeginPrintNewRecord=true;		

		/// <summary>
		/// （若要保留历史痕迹）当前记录内容
		/// </summary>
		private string[][] m_strValueArr;

		/// <summary>
		/// 当前记录的行序数（修改的次第数）
		/// </summary>
		private int m_intNowRowInOneRecord=0; 	

		/// <summary>
		/// 获取坐标的类
		/// </summary>
		private clsPrintPageSettingForRecord m_objPageSetting;
		/// <summary>
		/// 打印的病人基本信息类
		/// </summary>
		private class clsEveryRecordPageInfo
		{
			public string strPatientName;
			public string strSex;
			public string strAge;
			public string strBedNo;
			public string strAreaName;
			public string strDeptName;
			public string strInPatientID;
			//public int intCurrentPate;
			//public int intTotalPages;
			public string strPrintDate;
		}

		/// <summary>
		/// 格子的信息
		/// </summary>
		private enum enmRecordRectangleInfo
		{
			/// <summary>
			/// 格子的顶端
			/// </summary>
			TopY = 200,
			///<summary>
			/// 格子的左端
			/// </summary>
			LeftX = 20,
			/// <summary>
			/// 格子的右端
			/// </summary>
			RightX = 820-20,
			/// <summary>
			/// 格子每行的步长
			/// </summary>
			RowStep = 38,
			/// <summary>
			/// 格子的行数
			/// </summary>
			RowLinesNum = 17,	
			/// <summary>
			/// 文字在格子中相对格子顶端的垂直偏移
			/// </summary>
			VOffSet = 20,
			/// <summary>
			/// 列的数目
			/// </summary>
			ColumnsNum=19,
			/// <summary>
			/// 第一条间隔线(X),时间（起点线）
			/// </summary>			
			ColumnsMark1=75,

			/// <summary>
			/// 第二条间隔线(X)，体温（起点线）
			/// </summary>
			ColumnsMark2=120,

			/// <summary>
			/// 第3条间隔线(X)，心律（起点线）
			/// </summary>
			ColumnsMark3=154,

			/// <summary>
			/// 心率 次/分（起点线）
			/// </summary>
			ColumnsMark4=194,

			/// <summary>
			/// 脉搏（起点线）
			/// </summary>
			ColumnsMark5=224,

			/// <summary>
			/// 呼吸（起点线）
			/// </summary>
			ColumnsMark6=254,

			/// <summary>
			/// 血压（起点线）
			/// </summary>
			ColumnsMark7=284,

			/// <summary>
			/// 瞳孔大小 左（起点线）
			/// </summary>
			ColumnsMark8=340,

			/// <summary>
			/// 瞳孔大小 右（起点线）
			/// </summary>
			ColumnsMark9=370,

			/// <summary>
			/// 反射 左（起点线）
			/// </summary>
			ColumnsMark10=400,

			/// <summary>
			/// 反射 右（起点线）
			/// </summary>
			ColumnsMark11=440,

			/// <summary>
			/// 血氧饱和度（起点线）
			/// </summary>
			ColumnsMark12=480,

			/// <summary>
			/// 床边血糖（起点线）
			/// </summary>
			ColumnsMark13=510,

			/// <summary>
			/// 输液量（起点线）
			/// </summary>
			ColumnsMark14=550,

			/// <summary>
			/// 进食量（起点线）
			/// </summary>
			ColumnsMark15=580,

			/// <summary>
			/// 引流量（起点线）
			/// </summary>
			ColumnsMark16=610,

			/// <summary>
			/// 尿 量（起点线）
			/// </summary>
			ColumnsMark17=640,

			ColumnsMark18=670,

			ColumnsMark19=700,

			/// <summary>
			/// 签名（起点线）
			/// </summary>
			ColumnsMark20=730	
		}
		
		/// <summary>
		/// 打印元素
		/// </summary>
		private enum enmItemDefination
		{
			//基本元素
			InPatientID_Title,
			InPatientID,
			Name_Title,
			Name,
			Sex_Title,
			Sex,
			Age_Title,
			Age,
			Dept_Name_Title,
			Dept_Name,
			BedNo_Title,
			BedNo,
            
			Page_HospitalName,
			Page_Name_Title,
			Page_Title,
			Page_Num,
			Page_Of,
			Page_Count,
					
			Print_Date_Title,
			Print_Date,
			//填充表格元素
			RecordDate,
			RecordTime,
			RecordContent,
			RecordSign1,
			RecordSign2,			
		}
	  

		#region 定义打印各元素的坐标点
		private class clsPrintPageSettingForRecord
		{	
			public clsPrintPageSettingForRecord(){}
			
			/// <summary>
			/// 获得坐标点
			/// </summary>
			/// <param name="p_intItemName">项目名称</param>
			/// <returns></returns>
			public PointF m_getCoordinatePoint(int p_intItemName)
			{
				PointF m_fReturnPoint;
				switch(p_intItemName)
				{   
                    
					case (int)enmItemDefination.Page_HospitalName:
						m_fReturnPoint = new PointF(300f,60f);
						break;
					case (int)enmItemDefination.Page_Name_Title:
						m_fReturnPoint = new PointF(225f,100f);
						break;
					case (int)enmItemDefination.Name_Title :
						m_fReturnPoint = new PointF(20f,150f);
						break;
					case (int)enmItemDefination.Name:
						m_fReturnPoint = new PointF(70f,150f);
						break;

					case (int)enmItemDefination.Sex_Title :
						m_fReturnPoint = new PointF(150f,150f);
						break;
					case (int)enmItemDefination.Sex :
						m_fReturnPoint = new PointF(200f,150f);
						break;

					case (int)enmItemDefination.Age_Title :
						m_fReturnPoint = new PointF(250f,150f);
						break;
					case (int)enmItemDefination.Age:
						m_fReturnPoint = new PointF(300f,150f);
						break;

					case (int)enmItemDefination.Dept_Name_Title:
						m_fReturnPoint = new PointF(330f,150f);
						break;
					case (int)enmItemDefination.Dept_Name :
						m_fReturnPoint = new PointF(380f,150f);
						break;
					
					case (int)enmItemDefination.BedNo_Title :
						m_fReturnPoint = new PointF(550f,150f);
						break;
					case (int)enmItemDefination.BedNo:
						m_fReturnPoint = new PointF(600f,150f);
						break;

					case (int)enmItemDefination.InPatientID_Title:
						m_fReturnPoint = new PointF(650f,150f);
						break;
					case (int)enmItemDefination.InPatientID :
						m_fReturnPoint = new PointF(720f,150f);
						break;
											
					default:
						m_fReturnPoint = new PointF(400f,400f);
						break;
	
				}
				return m_fReturnPoint;
			}
		}

	    #endregion
	
		#endregion

		/// <summary>
		/// 设定用于比较日期的初始值
		/// </summary>
		private DateTime m_dtmPreRecordDate;
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
            this.m_dtcDate = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_dtcTime = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_dtcTemperature = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcHeartRhythm = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcHeartFrequency = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcPulse = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcBreath = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcEchoLeft = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcEchoRight = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcPupilLeft = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcPupilRight = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcBloodOxygenSaturation = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcBedsideBloodSugar = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcBloodPressureS = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcBloodPressureA = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcInI = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcInD = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcOutE = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcOutU = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcOutS = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcOutV = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcSign = new System.Windows.Forms.DataGridTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgRecordDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtbRecords)).BeginInit();
            this.m_pnlNewBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgtsStyles
            // 
            this.dgtsStyles.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																										 this.m_dtcDate,
																										 this.m_dtcTime,
																										 this.m_dtcTemperature,
																										 this.m_dtcHeartRhythm,
																										 this.m_dtcHeartFrequency,
																										 this.m_dtcPulse,
																										 this.m_dtcBreath,
																										 this.m_dtcBloodPressureS,
																										 this.m_dtcBloodPressureA,
																										 this.m_dtcPupilLeft,
																										 this.m_dtcPupilRight,
																										 this.m_dtcEchoLeft,
																										 this.m_dtcEchoRight,
																										 this.m_dtcBloodOxygenSaturation,
																										 this.m_dtcBedsideBloodSugar,
																										 this.m_dtcInI,
																										 this.m_dtcInD,
																										 this.m_dtcOutE,
																										 this.m_dtcOutU,
																										 this.m_dtcOutS,
																										 this.m_dtcOutV,
																										 this.m_dtcSign});
            this.dgtsStyles.RowHeaderWidth = 15;
            // 
            // m_dtgRecordDetail
            // 
            this.m_dtgRecordDetail.AccessibleName = "DataGrid";
            this.m_dtgRecordDetail.AccessibleRole = System.Windows.Forms.AccessibleRole.Table;
            this.m_dtgRecordDetail.BackgroundColor = System.Drawing.SystemColors.AppWorkspace;
            this.m_dtgRecordDetail.CaptionBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.m_dtgRecordDetail.CaptionFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtgRecordDetail.DataSource = this.m_dtbRecords;
            this.m_dtgRecordDetail.HeaderFont = new System.Drawing.Font("宋体", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtgRecordDetail.Location = new System.Drawing.Point(26, 88);
            this.m_dtgRecordDetail.Size = new System.Drawing.Size(730, 492);
            // 
            // mniAppend
            // 
            this.mniAppend.Click += new System.EventHandler(this.mniAppend_Click);
            // 
            // m_trvInPatientDate
            // 
            this.m_trvInPatientDate.BackColor = System.Drawing.SystemColors.Window;
            this.m_trvInPatientDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_trvInPatientDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_trvInPatientDate.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_trvInPatientDate.ItemHeight = 18;
            this.m_trvInPatientDate.LineColor = System.Drawing.Color.Black;
            this.m_trvInPatientDate.Location = new System.Drawing.Point(20, 86);
            this.m_trvInPatientDate.Size = new System.Drawing.Size(144, 64);
            this.m_trvInPatientDate.Visible = false;
            // 
            // lblSex
            // 
            this.lblSex.BackColor = System.Drawing.SystemColors.Control;
            this.lblSex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSex.Location = new System.Drawing.Point(544, 100);
            this.lblSex.Size = new System.Drawing.Size(28, 19);
            this.lblSex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.BackColor = System.Drawing.SystemColors.Control;
            this.lblAge.Location = new System.Drawing.Point(612, 100);
            this.lblAge.Size = new System.Drawing.Size(36, 19);
            this.lblAge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.AutoSize = false;
            this.lblBedNoTitle.Location = new System.Drawing.Point(360, 93);
            this.lblBedNoTitle.Size = new System.Drawing.Size(48, 19);
            this.lblBedNoTitle.Text = "床 号:";
            this.lblBedNoTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.AutoSize = false;
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(352, 126);
            this.lblInHospitalNoTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(504, 93);
            this.lblNameTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(504, 126);
            this.lblSexTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(572, 100);
            this.lblAgeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(176, 126);
            this.lblAreaTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(412, 150);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(80, 104);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.BorderColor = System.Drawing.Color.White;
            this.txtInPatientID.Location = new System.Drawing.Point(412, 98);
            this.txtInPatientID.Size = new System.Drawing.Size(84, 23);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(548, 91);
            this.m_txtPatientName.Size = new System.Drawing.Size(84, 23);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(412, 91);
            this.m_txtBedNO.Size = new System.Drawing.Size(68, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(224, 124);
            this.m_cboArea.Size = new System.Drawing.Size(120, 23);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(544, 114);
            this.m_lsvPatientName.Size = new System.Drawing.Size(84, 104);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(412, 114);
            this.m_lsvBedNO.Size = new System.Drawing.Size(80, 104);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(224, 91);
            this.m_cboDept.Size = new System.Drawing.Size(120, 23);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(176, 93);
            this.lblDept.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(680, 100);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.m_cmdNext.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdNext.Location = new System.Drawing.Point(480, 91);
            this.m_cmdNext.Size = new System.Drawing.Size(16, 23);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdPre.Location = new System.Drawing.Point(672, 16);
            this.m_cmdPre.Size = new System.Drawing.Size(4, 8);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(676, 97);
            this.m_lblForTitle.Size = new System.Drawing.Size(44, 16);
            this.m_lblForTitle.Text = "观察项目记录单";
            this.m_lblForTitle.Visible = false;
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(580, 96);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(662, 36);
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
            // m_dtcDate
            // 
            this.m_dtcDate.Format = "";
            this.m_dtcDate.FormatInfo = null;
            this.m_dtcDate.HeaderText = "日期";
            this.m_dtcDate.MappingName = "Date";
            this.m_dtcDate.NullText = "";
            this.m_dtcDate.Width = 80;
            // 
            // m_dtcTime
            // 
            this.m_dtcTime.Format = "";
            this.m_dtcTime.FormatInfo = null;
            this.m_dtcTime.HeaderText = "时间";
            this.m_dtcTime.MappingName = "Time";
            this.m_dtcTime.NullText = "";
            this.m_dtcTime.Width = 70;
            // 
            // m_dtcTemperature
            // 
            this.m_dtcTemperature.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcTemperature.HeaderText = "体温℃";
            this.m_dtcTemperature.m_BlnGobleSet = true;
            this.m_dtcTemperature.m_BlnUnderLineDST = false;
            this.m_dtcTemperature.MappingName = "Temperature";
            this.m_dtcTemperature.NullText = "";
            this.m_dtcTemperature.Width = 40;
            // 
            // m_dtcHeartRhythm
            // 
            this.m_dtcHeartRhythm.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcHeartRhythm.HeaderText = "心律";
            this.m_dtcHeartRhythm.m_BlnGobleSet = true;
            this.m_dtcHeartRhythm.m_BlnUnderLineDST = false;
            this.m_dtcHeartRhythm.MappingName = "HeartRhythm";
            this.m_dtcHeartRhythm.NullText = "";
            this.m_dtcHeartRhythm.Width = 40;
            // 
            // m_dtcHeartFrequency
            // 
            this.m_dtcHeartFrequency.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcHeartFrequency.HeaderText = "心律次/分";
            this.m_dtcHeartFrequency.m_BlnGobleSet = true;
            this.m_dtcHeartFrequency.m_BlnUnderLineDST = false;
            this.m_dtcHeartFrequency.MappingName = "HeartFrequency";
            this.m_dtcHeartFrequency.NullText = "";
            this.m_dtcHeartFrequency.Width = 40;
            // 
            // m_dtcPulse
            // 
            this.m_dtcPulse.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcPulse.HeaderText = "脉搏次/分";
            this.m_dtcPulse.m_BlnGobleSet = true;
            this.m_dtcPulse.m_BlnUnderLineDST = false;
            this.m_dtcPulse.MappingName = "Pulse";
            this.m_dtcPulse.NullText = "";
            this.m_dtcPulse.Width = 40;
            // 
            // m_dtcBreath
            // 
            this.m_dtcBreath.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcBreath.HeaderText = "呼吸次/分";
            this.m_dtcBreath.m_BlnGobleSet = true;
            this.m_dtcBreath.m_BlnUnderLineDST = false;
            this.m_dtcBreath.MappingName = "Breath";
            this.m_dtcBreath.NullText = "";
            this.m_dtcBreath.Width = 40;
            // 
            // m_dtcEchoLeft
            // 
            this.m_dtcEchoLeft.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcEchoLeft.HeaderText = "瞳孔反射左";
            this.m_dtcEchoLeft.m_BlnGobleSet = true;
            this.m_dtcEchoLeft.m_BlnUnderLineDST = false;
            this.m_dtcEchoLeft.MappingName = "EchoLeft";
            this.m_dtcEchoLeft.NullText = "";
            this.m_dtcEchoLeft.Width = 40;
            // 
            // m_dtcEchoRight
            // 
            this.m_dtcEchoRight.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcEchoRight.HeaderText = "瞳孔反射右";
            this.m_dtcEchoRight.m_BlnGobleSet = true;
            this.m_dtcEchoRight.m_BlnUnderLineDST = false;
            this.m_dtcEchoRight.MappingName = "EchoRight";
            this.m_dtcEchoRight.NullText = "";
            this.m_dtcEchoRight.Width = 40;
            // 
            // m_dtcPupilLeft
            // 
            this.m_dtcPupilLeft.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcPupilLeft.HeaderText = "瞳孔大小左(mm)";
            this.m_dtcPupilLeft.m_BlnGobleSet = true;
            this.m_dtcPupilLeft.m_BlnUnderLineDST = false;
            this.m_dtcPupilLeft.MappingName = "PupilLeft";
            this.m_dtcPupilLeft.NullText = "";
            this.m_dtcPupilLeft.Width = 40;
            // 
            // m_dtcPupilRight
            // 
            this.m_dtcPupilRight.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcPupilRight.HeaderText = "瞳孔大小右(mm)";
            this.m_dtcPupilRight.m_BlnGobleSet = true;
            this.m_dtcPupilRight.m_BlnUnderLineDST = false;
            this.m_dtcPupilRight.MappingName = "PupilRight";
            this.m_dtcPupilRight.NullText = "";
            this.m_dtcPupilRight.Width = 40;
            // 
            // m_dtcBloodOxygenSaturation
            // 
            this.m_dtcBloodOxygenSaturation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcBloodOxygenSaturation.HeaderText = "血氧饱和度%";
            this.m_dtcBloodOxygenSaturation.m_BlnGobleSet = true;
            this.m_dtcBloodOxygenSaturation.m_BlnUnderLineDST = false;
            this.m_dtcBloodOxygenSaturation.MappingName = "BloodOxygenSaturation";
            this.m_dtcBloodOxygenSaturation.NullText = "";
            this.m_dtcBloodOxygenSaturation.Width = 40;
            // 
            // m_dtcBedsideBloodSugar
            // 
            this.m_dtcBedsideBloodSugar.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcBedsideBloodSugar.HeaderText = "床边血糖含量mmol/L";
            this.m_dtcBedsideBloodSugar.m_BlnGobleSet = true;
            this.m_dtcBedsideBloodSugar.m_BlnUnderLineDST = false;
            this.m_dtcBedsideBloodSugar.MappingName = "BedsideBloodSugar";
            this.m_dtcBedsideBloodSugar.NullText = "";
            this.m_dtcBedsideBloodSugar.Width = 40;
            // 
            // m_dtcBloodPressureS
            // 
            this.m_dtcBloodPressureS.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcBloodPressureS.HeaderText = "收缩压mmHg";
            this.m_dtcBloodPressureS.m_BlnGobleSet = true;
            this.m_dtcBloodPressureS.m_BlnUnderLineDST = false;
            this.m_dtcBloodPressureS.MappingName = "BloodPressureS";
            this.m_dtcBloodPressureS.NullText = "";
            this.m_dtcBloodPressureS.Width = 40;
            // 
            // m_dtcBloodPressureA
            // 
            this.m_dtcBloodPressureA.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcBloodPressureA.HeaderText = "舒张压mmHg";
            this.m_dtcBloodPressureA.m_BlnGobleSet = true;
            this.m_dtcBloodPressureA.m_BlnUnderLineDST = false;
            this.m_dtcBloodPressureA.MappingName = "BloodPressureA";
            this.m_dtcBloodPressureA.NullText = "";
            this.m_dtcBloodPressureA.Width = 40;
            // 
            // m_dtcInI
            // 
            this.m_dtcInI.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcInI.HeaderText = "摄入输液量(ml)";
            this.m_dtcInI.m_BlnGobleSet = true;
            this.m_dtcInI.m_BlnUnderLineDST = false;
            this.m_dtcInI.MappingName = "InI";
            this.m_dtcInI.NullText = "";
            this.m_dtcInI.Width = 40;
            // 
            // m_dtcInD
            // 
            this.m_dtcInD.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcInD.HeaderText = "摄入进食量(ml)";
            this.m_dtcInD.m_BlnGobleSet = true;
            this.m_dtcInD.m_BlnUnderLineDST = false;
            this.m_dtcInD.MappingName = "InD";
            this.m_dtcInD.NullText = "";
            this.m_dtcInD.Width = 40;
            // 
            // m_dtcOutE
            // 
            this.m_dtcOutE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcOutE.HeaderText = "排出引流量(ml)";
            this.m_dtcOutE.m_BlnGobleSet = true;
            this.m_dtcOutE.m_BlnUnderLineDST = false;
            this.m_dtcOutE.MappingName = "OutE";
            this.m_dtcOutE.NullText = "";
            this.m_dtcOutE.Width = 40;
            // 
            // m_dtcOutU
            // 
            this.m_dtcOutU.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcOutU.HeaderText = "排出尿量(ml)";
            this.m_dtcOutU.m_BlnGobleSet = true;
            this.m_dtcOutU.m_BlnUnderLineDST = false;
            this.m_dtcOutU.MappingName = "OutU";
            this.m_dtcOutU.NullText = "";
            this.m_dtcOutU.Width = 40;
            // 
            // m_dtcOutS
            // 
            this.m_dtcOutS.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcOutS.HeaderText = "排出大便量(ml)";
            this.m_dtcOutS.m_BlnGobleSet = true;
            this.m_dtcOutS.m_BlnUnderLineDST = false;
            this.m_dtcOutS.MappingName = "OutS";
            this.m_dtcOutS.NullText = "";
            this.m_dtcOutS.Width = 40;
            // 
            // m_dtcOutV
            // 
            this.m_dtcOutV.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcOutV.HeaderText = "排出呕吐物(ml)";
            this.m_dtcOutV.m_BlnGobleSet = true;
            this.m_dtcOutV.m_BlnUnderLineDST = false;
            this.m_dtcOutV.MappingName = "OutV";
            this.m_dtcOutV.NullText = "";
            this.m_dtcOutV.Width = 40;
            // 
            // m_dtcSign
            // 
            this.m_dtcSign.Format = "";
            this.m_dtcSign.FormatInfo = null;
            this.m_dtcSign.HeaderText = "签名";
            this.m_dtcSign.MappingName = "Sign";
            this.m_dtcSign.NullText = "";
            this.m_dtcSign.Width = 70;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(20, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(740, 508);
            this.panel1.TabIndex = 10000004;
            // 
            // frmWatchItemTrack
            // 
            this.AccessibleDescription = "观察项目记录单";
            this.AutoScroll = false;
            this.ClientSize = new System.Drawing.Size(792, 673);
            this.Controls.Add(this.panel1);
            this.Name = "frmWatchItemTrack";
            this.Text = "观察项目记录单";
            this.Load += new System.EventHandler(this.frmWatchItemTrack_Load);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.m_trvInPatientDate, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_dtgRecordDetail, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgRecordDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtbRecords)).EndInit();
            this.m_pnlNewBase.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region 属性
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

		protected override string m_StrRecorder_ID
		{
			get
			{
				return m_strCreateUserID;
			}
		}
		#endregion 属性

		private void frmWatchItemTrack_Load(object sender, System.EventArgs e)
		{
			m_dtmPreRecordDate = DateTime.MinValue;
			m_dtgRecordDetail.Focus();
		}

		/// <summary>
		/// 初始化具体表单的DataTable。
		/// 注意，DataTable的第一个Column必须是存放记录时间的字符串，第二个Column必须是存放记录类型的int值，第三个Column必须是存放记录的OpenDate
		/// </summary>
		/// <param name="p_dtbRecordTable"></param>
		protected override void m_mthInitDataTable(DataTable p_dtbRecordTable)
		{
			#region Add Column

			//存放记录时间的字符串
			p_dtbRecordTable.Columns.Add("CreateDate");
		
			//存放记录类型的int值
			DataColumn dcRecordType = new DataColumn("RecordType",typeof(int));
			p_dtbRecordTable.Columns.Add(dcRecordType);
		
			//存放记录的OpenDate字符串
			p_dtbRecordTable.Columns.Add("OpenDate");  
		
			//存放记录的ModifyDate字符串
			p_dtbRecordTable.Columns.Add("ModifyDate");        

			//存放日期字符串
			p_dtbRecordTable.Columns.Add("Date");
		
			//存放时间字符串
			p_dtbRecordTable.Columns.Add("Time");
		
			//存放体温字符串
			p_dtbRecordTable.Columns.Add("Temperature",typeof(clsDSTRichTextBoxValue));
		
			//存放心律字符串
			p_dtbRecordTable.Columns.Add("HeartRhythm",typeof(clsDSTRichTextBoxValue));
		
			//存放心率字符串
			p_dtbRecordTable.Columns.Add("HeartFrequency",typeof(clsDSTRichTextBoxValue));
		
			//存放脉搏字符串
			p_dtbRecordTable.Columns.Add("Pulse",typeof(clsDSTRichTextBoxValue));

			//存放呼吸字符串
			p_dtbRecordTable.Columns.Add("Breath",typeof(clsDSTRichTextBoxValue));

			//存放收缩压（）字符串
			p_dtbRecordTable.Columns.Add("BloodPressureS",typeof(clsDSTRichTextBoxValue));

			//存放舒张压（）字符串
			p_dtbRecordTable.Columns.Add("BloodPressureA",typeof(clsDSTRichTextBoxValue));
		
			//存放瞳孔大小左字符串
			p_dtbRecordTable.Columns.Add("PupilLeft",typeof(clsDSTRichTextBoxValue));
		
			//存放瞳孔大小右字符串
			p_dtbRecordTable.Columns.Add("PupilRight",typeof(clsDSTRichTextBoxValue));
		
			//存放瞳孔反射左字符串
			p_dtbRecordTable.Columns.Add("EchoLeft",typeof(clsDSTRichTextBoxValue));
		
			//存放瞳孔反射右字符串
			p_dtbRecordTable.Columns.Add("EchoRight",typeof(clsDSTRichTextBoxValue));
		
			//存放血氧饱和度字符串
			p_dtbRecordTable.Columns.Add("BloodOxygenSaturation",typeof(clsDSTRichTextBoxValue));
		
			//存放床边血糖字符串
			p_dtbRecordTable.Columns.Add("BedsideBloodSugar",typeof(clsDSTRichTextBoxValue));
		
			//存放输入液量字符串
			p_dtbRecordTable.Columns.Add("InI",typeof(clsDSTRichTextBoxValue));
		
			//存放进食量字符串
			p_dtbRecordTable.Columns.Add("InD",typeof(clsDSTRichTextBoxValue));
		
			//存放引流量字符串
			p_dtbRecordTable.Columns.Add("OutE",typeof(clsDSTRichTextBoxValue)); 
		
			//存放尿量字符串
			p_dtbRecordTable.Columns.Add("OutU",typeof(clsDSTRichTextBoxValue));   
		
			//存放大便字符串
			p_dtbRecordTable.Columns.Add("OutS",typeof(clsDSTRichTextBoxValue)); 
		
			//存放呕吐物字符串
			p_dtbRecordTable.Columns.Add("OutV",typeof(clsDSTRichTextBoxValue)); 

			//存放签名
            p_dtbRecordTable.Columns.Add("Sign");

            p_dtbRecordTable.Columns.Add("CreateUserID"); 

			#endregion

			#region Set Header
			this.m_dtcDate.HeaderText = "  日\r\n\r\n\r\n\r\n  期";
			this.m_dtcTime.HeaderText = "  时\r\n\r\n\r\n\r\n  间";
			this.m_dtcTemperature.HeaderText = "体\r\n\r\n温\r\n\r\n℃";
			this.m_dtcHeartRhythm.HeaderText = "心\r\n\r\n\r\n\r\n律";
			this.m_dtcHeartFrequency.HeaderText = "心\r\n律\r\n次\r\n/\r\n分";
			this.m_dtcPulse.HeaderText = "脉\r\n搏\r\n次\r\n/\r\n分";
			this.m_dtcBreath.HeaderText = "呼\r\n吸\r\n次\r\n/\r\n分";
			this.m_dtcEchoLeft.HeaderText = "瞳\r\n孔\r\n反\r\n射\r\n左";
			this.m_dtcEchoRight.HeaderText = "瞳\r\n孔\r\n反\r\n射\r\n右";
			this.m_dtcPupilLeft.HeaderText = "瞳\r\n孔\r\n大\r\n小\r\n左\r\n(mm)";
			this.m_dtcPupilRight.HeaderText = "瞳\r\n孔\r\n大\r\n小\r\n右\r\n(mm)";
			this.m_dtcBloodOxygenSaturation.HeaderText = "血\r\n氧\r\n饱\r\n和\r\n度\r\n%";
			this.m_dtcBedsideBloodSugar.HeaderText = "床\r\n边\r\n血\r\n糖\r\nmmol\r\n/L";
			this.m_dtcBloodPressureS.HeaderText = "收\r\n\r\n缩\r\n\r\n压\r\nmmHg";
			this.m_dtcBloodPressureA.HeaderText = "舒\r\n\r\n张\r\n\r\n压\r\nmmHg";
			this.m_dtcInD.HeaderText = "摄\r\n入\r\n输\r\n液\r\n量\r\n(ml)";
			this.m_dtcInI.HeaderText = "摄\r\n入\r\n进\r\n食\r\n量\r\n(ml)";
			this.m_dtcOutE.HeaderText = "排\r\n出\r\n引\r\n流\r\n量\r\n(ml)";
			this.m_dtcOutU.HeaderText = "排\r\n出\r\n尿\r\n量\r\n(ml)";
			this.m_dtcOutS.HeaderText = "排\r\n出\r\n大\r\n便\r\n量\r\n(ml)";
			this.m_dtcOutV.HeaderText = "排\r\n出\r\n呕\r\n吐\r\n物\r\n(ml)";
			this.m_dtcSign.HeaderText = "  签\r\n\r\n\r\n\r\n  名";

			m_mthSetControl(m_dtcDate);
			m_mthSetControl(m_dtcTime);
			m_mthSetControl(m_dtcTemperature);
			m_mthSetControl(m_dtcHeartRhythm);
			m_mthSetControl(m_dtcHeartFrequency);
			m_mthSetControl(m_dtcPulse);
			m_mthSetControl(m_dtcBreath);
			m_mthSetControl(m_dtcEchoLeft);
			m_mthSetControl(m_dtcEchoRight);
			m_mthSetControl(m_dtcPupilLeft);
			m_mthSetControl(m_dtcPupilRight);
			m_mthSetControl(m_dtcBloodOxygenSaturation);
			m_mthSetControl(m_dtcBedsideBloodSugar);
			m_mthSetControl(m_dtcBloodPressureS);
			m_mthSetControl(m_dtcBloodPressureA);
			m_mthSetControl(m_dtcOutE);
			m_mthSetControl(m_dtcOutU);
			m_mthSetControl(m_dtcOutS);
			m_mthSetControl(m_dtcOutV);
			m_mthSetControl(m_dtcSign);
			m_mthSetControl(m_dtcInI);
			m_mthSetControl(m_dtcInD);



			m_dtcDate.ReadOnly = true;
			m_dtcTime.ReadOnly = true;
			m_dtcTemperature.m_RtbBase.m_BlnReadOnly = true;
			m_dtcHeartRhythm.m_RtbBase.m_BlnReadOnly = true;
			m_dtcHeartFrequency.m_RtbBase.m_BlnReadOnly = true;
			m_dtcPulse.m_RtbBase.m_BlnReadOnly = true;
			m_dtcBreath.m_RtbBase.m_BlnReadOnly = true;
			m_dtcEchoLeft.m_RtbBase.m_BlnReadOnly = true;
			m_dtcEchoRight.m_RtbBase.m_BlnReadOnly = true;
			m_dtcPupilLeft.m_RtbBase.m_BlnReadOnly = true;
			m_dtcPupilRight.m_RtbBase.m_BlnReadOnly = true;
			m_dtcBloodOxygenSaturation.m_RtbBase.m_BlnReadOnly = true;
			m_dtcBedsideBloodSugar.m_RtbBase.m_BlnReadOnly = true;
			m_dtcBloodPressureS.m_RtbBase.m_BlnReadOnly = true;
			m_dtcBloodPressureA.m_RtbBase.m_BlnReadOnly = true;
			m_dtcOutE.m_RtbBase.m_BlnReadOnly = true;
			m_dtcOutU.m_RtbBase.m_BlnReadOnly = true;
			m_dtcOutS.m_RtbBase.m_BlnReadOnly = true;
			m_dtcOutV.m_RtbBase.m_BlnReadOnly = true;
			m_dtcInI.m_RtbBase.m_BlnReadOnly = true;
			m_dtcInD.m_RtbBase.m_BlnReadOnly = true;
			m_dtcSign.ReadOnly = true;

			#endregion
		}


		/// <summary>
		///  清空特殊记录信息，并重置记录控制状态为不控制。
		/// </summary>
		protected override void m_mthClearRecordInfo()
		{			
			m_dtmPreRecordDate = DateTime.MinValue;
		}

		private string m_strGetDSTTextXML(string p_strText,string p_strModifyUserID,string p_strModifyUserName)
		{
			return com.digitalwave.controls.ctlRichTextBox.clsXmlTool.s_strMakeDSTXml(p_strText,p_strModifyUserID,p_strModifyUserName,Color.Black,Color.White);
		}



		/// <summary>
		///  获取添加到DataTable的数据
		/// </summary>
		/// <param name="p_objTransDataInfo"></param>
		/// <returns></returns>
		protected override object[][] m_objGetRecordsValueArr(clsTransDataInfo p_objTransDataInfo)
		{
			clsWatchItemDataInfo objDataInfo;
			object [] objData;
            ArrayList objReturnData = new ArrayList();
			string strText,strXml;
			clsDSTRichTextBoxValue objclsDSTRichTextBoxValue;

			if(p_objTransDataInfo.m_intFlag != (int)enmRecordsType.WatchItem)
			{
				return m_objGetPerDateSummaryRecordsValueArr(p_objTransDataInfo);
			}

			#region 获取添加到DataTable的数据

			if(p_objTransDataInfo.GetType().Name.ToString() == "clsTransDataInfo")
			{
				m_dtmPreRecordDate = DateTime.MinValue;
				string m_strInPatientID = p_objTransDataInfo.m_objRecordContent.m_strInPatientID;
				string m_strInPatientDate = p_objTransDataInfo.m_objRecordContent.m_dtmInPatientDate.ToString("yyy-MM-dd HH:mm:ss");
				string m_strOpenDate = p_objTransDataInfo.m_objRecordContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss");
				long lngRes = ((clsWatchItemRecordsDomain)m_objRecordsDomain).m_lngGetRecordContent(m_strInPatientID,m_strInPatientDate,m_strOpenDate,out objDataInfo);
				if(lngRes <= 0)
				{
					return null;
				}
			}
			else
			{
				objDataInfo = (clsWatchItemDataInfo)p_objTransDataInfo;
				
			}
		
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

            for (int i = 0; i < objDataInfo.m_objTransDataArr.Length; i++)
			{
				objData = new object[27];   
			
				clsSubWatchItemRecordContent objCurrent = objDataInfo.m_objTransDataArr[i];
                clsSubWatchItemRecordContent objNext = (i == objDataInfo.m_objTransDataArr.Length - 1) ? null : objDataInfo.m_objTransDataArr[i + 1];

				//如果该护理记录是修改前的记录且是在指定时间内修改的，则不显示
                if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_strModifyUserID.Trim() == objCurrent.m_strCreateUserID.Trim()
                        && objNext.m_dtmOpenDate == objCurrent.m_dtmOpenDate)
				{
					TimeSpan tsModify =  objNext.m_dtmModifyDate-objCurrent.m_dtmModifyDate;
					if((int)tsModify.TotalHours < intCanModifyTime)
						continue;
				}

				//设置值
                //if(i==0)
                //{
					//只在第一行记录才由以下信息
					objData[0] = objCurrent.m_dtmCreateDate;//存放记录时间的字符串
					objData[1] = (int)enmRecordsType.WatchItem;//存放记录类型的int值
					objData[2] = objCurrent.m_dtmOpenDate;//存放记录的OpenDate字符串
					//						objData[3] = objCurrent.m_dtmModifyDate;//存放记录的ModifyDate字符串
					objData[3] = objDataInfo.m_objTransDataArr[objDataInfo.m_objTransDataArr.Length-1].m_dtmModifyDate;//存放记录的ModifyDate字符串   
                //}   
				if(objCurrent.m_dtmCreateDate.Date.ToString() != m_dtmPreRecordDate.Date.ToString())
				{
					objData[4] = objCurrent.m_dtmCreateDate.Date.ToString("yyyy-MM-dd 00:00:00") ;//日期字符串
				}
				if(objCurrent.m_dtmCreateDate.ToString("HH:mm") != m_dtmPreRecordDate.ToString("HH:mm"))
				{
//					objData[5] = objCurrent.m_dtmCreateDate.ToString("HH:mm:ss");//时间字符串
					objData[5] = objCurrent.m_dtmCreateDate.ToString("HH:mm");//时间字符串
				}
				m_dtmPreRecordDate = objCurrent.m_dtmCreateDate;
				strText = objCurrent.m_strTemperature;
				strXml = "<root />";
				if(objNext != null && objNext.m_strTemperature != objCurrent.m_strTemperature)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
				{
					strXml = m_strGetDSTTextXML(objCurrent.m_strTemperature,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
				}
				objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
				objclsDSTRichTextBoxValue.m_strText=(strText == "0" ? "" : strText);//值为"0"的不需要显示到界面					
				objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
				objData[6] = objclsDSTRichTextBoxValue;//体温内容
			
				strText = objCurrent.m_strHeartRhythm;
				strXml = "<root />";
				if(objNext != null && objNext.m_strHeartRhythm != objCurrent.m_strHeartRhythm)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
				{
					strXml = m_strGetDSTTextXML(objCurrent.m_strHeartRhythm,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
				}
				objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
				objclsDSTRichTextBoxValue.m_strText=(strText == "0" ? "" : strText);						
				objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
				objData[7] = objclsDSTRichTextBoxValue;//心律内容
			
				strText = objCurrent.m_strHeartFrequency;
				strXml = "<root />";
				if(objNext != null && objNext.m_strHeartFrequency != objCurrent.m_strHeartFrequency)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
				{
					strXml = m_strGetDSTTextXML(objCurrent.m_strHeartFrequency,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
				}
				objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
				objclsDSTRichTextBoxValue.m_strText=(strText == "0" ? "" : strText);						
				objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
				
				objData[8] = objclsDSTRichTextBoxValue;//心率内容
			
				strText = objCurrent.m_strPulse;
				strXml = "<root />";
				if(objNext != null && objNext.m_strPulse != objCurrent.m_strPulse)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
				{
					strXml = m_strGetDSTTextXML(objCurrent.m_strPulse,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
				}
				objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
				objclsDSTRichTextBoxValue.m_strText=(strText == "0" ? "" : strText);						
				objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
				objData[9] = objclsDSTRichTextBoxValue;//脉搏内容
			
				strText = objCurrent.m_strBreath;
				strXml = "<root />";
				if(objNext != null && objNext.m_strBreath != objCurrent.m_strBreath)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
				{
					strXml = m_strGetDSTTextXML(objCurrent.m_strBreath,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
				}
				objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
				objclsDSTRichTextBoxValue.m_strText=(strText == "0" ? "" : strText);						
				objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
				objData[10] = objclsDSTRichTextBoxValue;//呼吸内容
			
				strText = objCurrent.m_strBloodPressureS;
				strXml = "<root />";
				if(objNext != null && objNext.m_strBloodPressureS != objCurrent.m_strBloodPressureS)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
				{
					strXml = m_strGetDSTTextXML(objCurrent.m_strBloodPressureS,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
				}
				objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
				objclsDSTRichTextBoxValue.m_strText=(strText == "0" ? "" : strText);						
				objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
				objData[11] = objclsDSTRichTextBoxValue;//血压（S:收缩压）内容
			
				strText = objCurrent.m_strBloodPressureA;
				strXml = "<root />";
				if(objNext != null && objNext.m_strBloodPressureA != objCurrent.m_strBloodPressureA)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
				{
					strXml = m_strGetDSTTextXML(objCurrent.m_strBloodPressureA,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
				}
				objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
				objclsDSTRichTextBoxValue.m_strText=(strText == "0" ? "" : strText);						
				objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
				objData[12] = objclsDSTRichTextBoxValue;//存放血压（A:舒张压）内容
			
				strText = objCurrent.m_strPupilLeft;
				strXml = "<root />";
				if(objNext != null && objNext.m_strPupilLeft != objCurrent.m_strPupilLeft)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
				{
					strXml = m_strGetDSTTextXML(objCurrent.m_strPupilLeft,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
				}
				objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
				objclsDSTRichTextBoxValue.m_strText=(strText == "0" ? "" : strText);						
				objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
				objData[13] = objclsDSTRichTextBoxValue;//瞳孔大小左内容
			
				strText = objCurrent.m_strPupilRight;
				strXml = "<root />";
				if(objNext != null && objNext.m_strPupilRight != objCurrent.m_strPupilRight)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
				{
					strXml = m_strGetDSTTextXML(objCurrent.m_strPupilRight,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
				}
				objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
				objclsDSTRichTextBoxValue.m_strText=(strText == "0" ? "" : strText);						
				objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
				objData[14] = objclsDSTRichTextBoxValue;//瞳孔大小右内容
			
				strText = objCurrent.m_strEchoLeft;
				strXml = "<root />";
				if(objNext != null && objNext.m_strEchoLeft != objCurrent.m_strEchoLeft)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
				{
					strXml = m_strGetDSTTextXML(objCurrent.m_strEchoLeft,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
				}
				objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
				objclsDSTRichTextBoxValue.m_strText=(strText == "0" ? "" : strText);						
				objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
				objData[15] = objclsDSTRichTextBoxValue;//瞳孔反射左内容
			
				strText = objCurrent.m_strEchoRight;
				strXml = "<root />";
				if(objNext != null && objNext.m_strEchoRight != objCurrent.m_strEchoRight)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
				{
					strXml = m_strGetDSTTextXML(objCurrent.m_strEchoRight,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
				}
				objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
				objclsDSTRichTextBoxValue.m_strText=(strText == "0" ? "" : strText);						
				objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
				objData[16] = objclsDSTRichTextBoxValue;//瞳孔反射右内容
			
				strText = objCurrent.m_strBloodOxygenSaturation;
				strXml = "<root />";
				if(objNext != null && objNext.m_strBloodOxygenSaturation != objCurrent.m_strBloodOxygenSaturation)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
				{
					strXml = m_strGetDSTTextXML(objCurrent.m_strBloodOxygenSaturation,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
				}
				objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
				objclsDSTRichTextBoxValue.m_strText=(strText == "0" ? "" : strText);						
				objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
				objData[17] = objclsDSTRichTextBoxValue;//血氧饱和度内容
			
				strText = objCurrent.m_strBedsideBloodSugar;
				strXml = "<root />";
				if(objNext != null && objNext.m_strBedsideBloodSugar != objCurrent.m_strBedsideBloodSugar)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
				{
					strXml = m_strGetDSTTextXML(objCurrent.m_strBedsideBloodSugar,objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
				}
				objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
				objclsDSTRichTextBoxValue.m_strText=(strText == "0" ? "" : strText);						
				objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
				objData[18] = objclsDSTRichTextBoxValue;//床边血糖内容
			
				strText = objCurrent.m_intInD.ToString();
				strXml = "<root />";
				if(objNext != null && objNext.m_intInD.ToString() != objCurrent.m_intInD.ToString())/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
				{
					strXml = m_strGetDSTTextXML(objCurrent.m_intInD.ToString(),objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
				}
				objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
				objclsDSTRichTextBoxValue.m_strText=(strText == "0" ? "" : strText);						
				objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
				objData[19] = objclsDSTRichTextBoxValue;//输入液量内容
			
				strText = objCurrent.m_intInI.ToString();
				strXml = "<root />";
				if(objNext != null && objNext.m_intInI.ToString() != objCurrent.m_intInI.ToString())/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
				{
					strXml = m_strGetDSTTextXML(objCurrent.m_intInI.ToString(),objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
				}
				objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
				objclsDSTRichTextBoxValue.m_strText=(strText == "0" ? "" : strText);						
				objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
				objData[20] = objclsDSTRichTextBoxValue;//进食量内容
			
				strText = objCurrent.m_intOutE.ToString();
				strXml = "<root />";
				if(objNext != null && objNext.m_intOutE.ToString() != objCurrent.m_intOutE.ToString())/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
				{
					strXml = m_strGetDSTTextXML(objCurrent.m_intOutE.ToString(),objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
				}
				objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
				objclsDSTRichTextBoxValue.m_strText=(strText == "0" ? "" : strText);						
				objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
				objData[21] = objclsDSTRichTextBoxValue;//引流量内容
			
				strText = objCurrent.m_intOutU.ToString();
				strXml = "<root />";
				if(objNext != null && objNext.m_intOutU.ToString() != objCurrent.m_intOutU.ToString())/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
				{
					strXml = m_strGetDSTTextXML(objCurrent.m_intOutU.ToString(),objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
				}
				objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
				objclsDSTRichTextBoxValue.m_strText=(strText == "0" ? "" : strText);						
				objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
				objData[22] = objclsDSTRichTextBoxValue;//尿量内容
			
				strText = objCurrent.m_intOutS.ToString();
				strXml = "<root />";
				if(objNext != null && objNext.m_intOutS.ToString() != objCurrent.m_intOutS.ToString())/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
				{
					strXml = m_strGetDSTTextXML(objCurrent.m_intOutS.ToString(),objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
				}
				objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
				objclsDSTRichTextBoxValue.m_strText=(strText == "0" ? "" : strText);						
				objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
				objData[23] = objclsDSTRichTextBoxValue;//大便内容
			
				strText = objCurrent.m_intOutV.ToString();
				strXml = "<root />";
				if(objNext != null && objNext.m_intOutV != objCurrent.m_intOutV)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
				{
					strXml = m_strGetDSTTextXML(objCurrent.m_intOutV.ToString(),objCurrent.m_strModifyUserID,objCurrent.m_strModifyUserName);
				}
				objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
				objclsDSTRichTextBoxValue.m_strText=(strText == "0" ? "" : strText);						
				objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
				objData[24] = objclsDSTRichTextBoxValue;//呕吐物内容    
			
				objData[25] = objCurrent.m_strModifyUserName;//签名
                objData[26] = objCurrent.m_strCreateUserID;
                objReturnData.Add(objData);
				#region DSL添加 
				m_strCurrentOpenDate=objCurrent.m_dtmCreateDate.ToString();
				m_strCreateUserID=objCurrent.m_strModifyUserID;
				#endregion DSL添加
			}
            object[][] m_objRe = new object[objReturnData.Count][];

            for (int m = 0; m < objReturnData.Count; m++)
                m_objRe[m] = (object[])objReturnData[m];
            return m_objRe;

			#endregion
		}

		/// <summary>
		/// 获取添加到DataTable的统计数据
		/// 提供观察项目记录单使用
		/// </summary>
		/// <param name="p_objTransDataInfo"></param>
		/// <returns></returns>
		private object[][] m_objGetPerDateSummaryRecordsValueArr(clsTransDataInfo p_objTransDataInfo)
		{
			#region  获取添加到DataTable的统计数据（按日统计）
			clsWatchItemDataInfo objDataInfo;
			object [][] objData;
			string strText,strXml;
			clsDSTRichTextBoxValue objclsDSTRichTextBoxValue;

			objDataInfo = (clsWatchItemDataInfo)p_objTransDataInfo;
			//没有统计内容时不显示统计的文字
			if(!(objDataInfo.m_objItemSummary.m_intInD_Total != 0 || objDataInfo.m_objItemSummary.m_intInI_Total != 0 || objDataInfo.m_objItemSummary.m_intOutE_Total != 0
				|| objDataInfo.m_objItemSummary.m_intOutS_Total != 0 || objDataInfo.m_objItemSummary.m_intOutU_Total != 0 || objDataInfo.m_objItemSummary.m_intOutV_Total != 0
				|| objDataInfo.m_objItemSummary.m_intTotal_In != 0 || objDataInfo.m_objItemSummary.m_intTotal_Out != 0))
			{
				return null;
			}
			objData = new object[3][];
			objData[2] = new string[26];
			objData[0] = new object[26];   
			bool m_blnIfLastSummary = false;
			
			if(objDataInfo.m_objRecordContent.m_dtmCreateDate == DateTime.MaxValue)//判断是否是最后的统计
			{
				m_blnIfLastSummary = true;
			}

			if(m_blnIfLastSummary)//如果是最后的统计将输出文字改变
				strText = "合共";
			else
				strText = "按日";

			strXml = "<root />";

			objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
			objclsDSTRichTextBoxValue.m_strText=(strText == "0" ? "" : strText);//值为"0"的不需要显示到界面						
			objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
			objData[0][16] = objclsDSTRichTextBoxValue;//瞳孔反射右内容

			strText = "单项";
			strXml = "<root />";

			objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
			objclsDSTRichTextBoxValue.m_strText=(strText == "0" ? "" : strText);						
			objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
			objData[0][17] = objclsDSTRichTextBoxValue;//血氧饱和度内容

			strText = "总计:";
			strXml = "<root />";
			objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
			objclsDSTRichTextBoxValue.m_strText=(strText == "0" ? "" : strText);						
			objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
			objData[0][18] = objclsDSTRichTextBoxValue;//床边血糖内容
		
			strText = objDataInfo.m_objItemSummary.m_intInD_Total.ToString();
			strXml = "<root />";
			strXml = m_strGetDSTTextXML(strText,MDIParent.OperatorID,MDIParent.OperatorName);
			objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
			objclsDSTRichTextBoxValue.m_strText=(strText == "0" ? "" : strText);						
			objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
			objData[0][19] = objclsDSTRichTextBoxValue;//输入液量内容
		
			strText = objDataInfo.m_objItemSummary.m_intInI_Total.ToString();
			strXml = "<root />";
			strXml = m_strGetDSTTextXML(strText,MDIParent.OperatorID,MDIParent.OperatorName);
			objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
			objclsDSTRichTextBoxValue.m_strText = (strText == "0" ? "" : strText);						
			objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
			objData[0][20] = objclsDSTRichTextBoxValue;//进食量内容
		
			strText = objDataInfo.m_objItemSummary.m_intOutE_Total.ToString();
			strXml = "<root />";
			strXml = m_strGetDSTTextXML(strText,MDIParent.OperatorID,MDIParent.OperatorName);
			objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
			objclsDSTRichTextBoxValue.m_strText=(strText == "0" ? "" : strText);						
			objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
			objData[0][21] = objclsDSTRichTextBoxValue;//引流量内容
		
			strText = objDataInfo.m_objItemSummary.m_intOutU_Total.ToString();
			strXml = "<root />";
			strXml = m_strGetDSTTextXML(strText,MDIParent.OperatorID,MDIParent.OperatorName);
			objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
			objclsDSTRichTextBoxValue.m_strText=(strText == "0" ? "" : strText);						
			objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
			objData[0][22] = objclsDSTRichTextBoxValue;//尿量内容
		
			strText = objDataInfo.m_objItemSummary.m_intOutS_Total.ToString();
			strXml = "<root />";
			strXml = m_strGetDSTTextXML(strText,MDIParent.OperatorID,MDIParent.OperatorName);
			objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
			objclsDSTRichTextBoxValue.m_strText=(strText == "0" ? "" : strText);						
			objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
			objData[0][23] = objclsDSTRichTextBoxValue;//大便内容
		
			strText = objDataInfo.m_objItemSummary.m_intOutV_Total.ToString();
			strXml = "<root />";
			strXml = m_strGetDSTTextXML(strText,MDIParent.OperatorID,MDIParent.OperatorName);
			objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
			objclsDSTRichTextBoxValue.m_strText=(strText == "0" ? "" : strText);						
			objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
			objData[0][24] = objclsDSTRichTextBoxValue;//呕吐物内容    

			objData[1] = new object[26];

			if(m_blnIfLastSummary)
				strText = "合共";
			else
				strText = "按日";

			strXml = "<root />";
			objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
			objclsDSTRichTextBoxValue.m_strText=(strText == "0" ? "" : strText);						
			objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
			objData[1][16] = objclsDSTRichTextBoxValue;//瞳孔反射右内容

			strText = "分类";
			strXml = "<root />";
			objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
			objclsDSTRichTextBoxValue.m_strText=(strText == "0" ? "" : strText);						
			objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
			objData[1][17] = objclsDSTRichTextBoxValue;//血氧饱和度内容

			strText = "总计:";
			strXml = "<root />";
			objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
			objclsDSTRichTextBoxValue.m_strText=(strText == "0" ? "" : strText);						
			objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
			objData[1][18] = objclsDSTRichTextBoxValue;//床边血糖内容

			strText = objDataInfo.m_objItemSummary.m_intTotal_In.ToString();
			strXml = "<root />";
			strXml = m_strGetDSTTextXML(strText,MDIParent.OperatorID,MDIParent.OperatorName);
			objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
			objclsDSTRichTextBoxValue.m_strText=(strText == "0" ? "" : strText);						
			objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
			objData[1][19] = objclsDSTRichTextBoxValue;//输入液量内容

			strText = objDataInfo.m_objItemSummary.m_intTotal_Out.ToString();
			strXml = "<root />";
			strXml = m_strGetDSTTextXML(strText,MDIParent.OperatorID,MDIParent.OperatorName);
			objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
			objclsDSTRichTextBoxValue.m_strText=(strText == "0" ? "" : strText);						
			objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
			objData[1][21] = objclsDSTRichTextBoxValue;//引流量内容
			
			if(m_blnIfLastSummary==true)
			{
				object [][] objDataReturn=new object[2][];;
				objDataReturn[0]=objData[0];
				objDataReturn[1]=objData[1];
				return objDataReturn;
			}	
			
			return objData;			

			#endregion
		}

		#region No Use
//		/// <summary>
//		/// 获取添加到DataTable的统计数据（全部统计）
//		/// 提供观察项目记录单使用
//		/// </summary>
//		/// <param name="p_objTransDataInfoArr"></param>
//		/// <returns></returns>
//		protected override object[][] m_objGetSummaryRecordsValueArr(clsTransDataInfo[] objTansDataInfoArr)
//		{
//				//由子窗体重载
//			if(objTansDataInfoArr.Length <=0)
//				return null;
//
//			clsWatchItemSummary m_objSummary = new clsWatchItemSummary();
//			clsWatchItemDataInfo objDataInfo;
//			for(int i1=0;i1<objTansDataInfoArr.Length;i1++)
//			{
//				if(objTansDataInfoArr[i1].m_intFlag != (int)enmRecordsType.WatchItem)
//				{
//					objDataInfo = (clsWatchItemDataInfo)objTansDataInfoArr[i1];
//					m_objSummary.m_intInD_Total+=objDataInfo.m_objItemSummary.m_intInD_Total;
//					m_objSummary.m_intInI_Total+=objDataInfo.m_objItemSummary.m_intInI_Total;
//					m_objSummary.m_intOutE_Total+=objDataInfo.m_objItemSummary.m_intOutE_Total;
//					m_objSummary.m_intOutS_Total+=objDataInfo.m_objItemSummary.m_intOutS_Total;
//					m_objSummary.m_intOutV_Total+=objDataInfo.m_objItemSummary.m_intOutV_Total;
//					m_objSummary.m_intOutU_Total+=objDataInfo.m_objItemSummary.m_intOutU_Total;
//					m_objSummary.m_intTotal_In+=objDataInfo.m_objItemSummary.m_intTotal_In;
//					m_objSummary.m_intTotal_Out+=objDataInfo.m_objItemSummary.m_intTotal_Out;
//				}
//			}
//			#region  获取添加到DataTable的统计数据（按日统计）
//			object [][] objData;
//			string strText,strXml;
//			clsDSTRichTextBoxValue objclsDSTRichTextBoxValue;
//
//			objData = new object[3][];
//			objData[0] = new object[26];   
//		
//			objData[1] = new object[26];  
//			strText = "合共";
//			strXml = "<root />";
//
//			objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
//			objclsDSTRichTextBoxValue.m_strText=strText;						
//			objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
//			objData[1][16] = objclsDSTRichTextBoxValue;//瞳孔反射右内容
//
//			strText = "单项";
//			strXml = "<root />";
//
//			objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
//			objclsDSTRichTextBoxValue.m_strText=strText;						
//			objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
//			objData[1][17] = objclsDSTRichTextBoxValue;//血氧饱和度内容
//
//			strText = "总计:";
//			strXml = "<root />";
//			objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
//			objclsDSTRichTextBoxValue.m_strText=strText;						
//			objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
//			objData[1][18] = objclsDSTRichTextBoxValue;//床边血糖内容
//		
//			strText = m_objSummary.m_intInD_Total.ToString();
//			strXml = "<root />";
//			strXml = m_strGetDSTTextXML(strText,MDIParent.OperatorID,MDIParent.OperatorName);
//			objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
//			objclsDSTRichTextBoxValue.m_strText=strText;						
//			objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
//			objData[1][19] = objclsDSTRichTextBoxValue;//输入液量内容
//		
//			strText = m_objSummary.m_intInI_Total.ToString();
//			strXml = "<root />";
//			strXml = m_strGetDSTTextXML(strText,MDIParent.OperatorID,MDIParent.OperatorName);
//			objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
//			objclsDSTRichTextBoxValue.m_strText=strText;						
//			objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
//			objData[1][20] = objclsDSTRichTextBoxValue;//进食量内容
//		
//			strText = m_objSummary.m_intOutE_Total.ToString();
//			strXml = "<root />";
//			strXml = m_strGetDSTTextXML(strText,MDIParent.OperatorID,MDIParent.OperatorName);
//			objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
//			objclsDSTRichTextBoxValue.m_strText=strText;						
//			objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
//			objData[1][21] = objclsDSTRichTextBoxValue;//引流量内容
//		
//			strText = m_objSummary.m_intOutU_Total.ToString();
//			strXml = "<root />";
//			strXml = m_strGetDSTTextXML(strText,MDIParent.OperatorID,MDIParent.OperatorName);
//			objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
//			objclsDSTRichTextBoxValue.m_strText=strText;						
//			objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
//			objData[1][22] = objclsDSTRichTextBoxValue;//尿量内容
//		
//			strText = m_objSummary.m_intOutS_Total.ToString();
//			strXml = "<root />";
//			strXml = m_strGetDSTTextXML(strText,MDIParent.OperatorID,MDIParent.OperatorName);
//			objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
//			objclsDSTRichTextBoxValue.m_strText=strText;						
//			objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
//			objData[1][23] = objclsDSTRichTextBoxValue;//大便内容
//		
//			strText = m_objSummary.m_intOutV_Total.ToString();
//			strXml = "<root />";
//			strXml = m_strGetDSTTextXML(strText,MDIParent.OperatorID,MDIParent.OperatorName);
//			objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
//			objclsDSTRichTextBoxValue.m_strText=strText;						
//			objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
//			objData[1][24] = objclsDSTRichTextBoxValue;//呕吐物内容    
//
//			objData[2] = new object[26];
//
//			strText = "合共";
//			strXml = "<root />";
//			objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
//			objclsDSTRichTextBoxValue.m_strText=strText;						
//			objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
//			objData[2][16] = objclsDSTRichTextBoxValue;//瞳孔反射右内容
//
//			strText = "分类";
//			strXml = "<root />";
//
//			objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
//			objclsDSTRichTextBoxValue.m_strText=strText;						
//			objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
//			objData[2][17] = objclsDSTRichTextBoxValue;//血氧饱和度内容
//
//			strText = "总计:";
//			strXml = "<root />";
//			objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
//			objclsDSTRichTextBoxValue.m_strText=strText;						
//			objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
//			objData[2][18] = objclsDSTRichTextBoxValue;//床边血糖内容
//
//			strText = m_objSummary.m_intTotal_In.ToString();
//			strXml = "<root />";
//			strXml = m_strGetDSTTextXML(strText,MDIParent.OperatorID,MDIParent.OperatorName);
//			objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
//			objclsDSTRichTextBoxValue.m_strText=strText;						
//			objclsDSTRichTextBoxValue.m_strDSTXml=strXml;
//			objData[2][19] = objclsDSTRichTextBoxValue;//输入液量内容
//
//			strText = m_objSummary.m_intTotal_Out.ToString();
//			strXml = "<root />";
//			strXml = m_strGetDSTTextXML(strText,MDIParent.OperatorID,MDIParent.OperatorName);
//			objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
//			objclsDSTRichTextBoxValue.m_strText=strText;						
//			objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
//			objData[2][21] = objclsDSTRichTextBoxValue;//引流量内容
//			return objData;
//
//			#endregion
//		}

		#endregion

		/// <summary>
		///  获取记录的主要信息（必须获取的是CreateDate,OpenDate,LastModifyDate）
		/// </summary>
		/// <param name="p_intRecordType"></param>
		/// <param name="p_objDataArr"></param>
		/// <returns></returns>
		protected override clsTrackRecordContent m_objGetRecordMainContent(int p_intRecordType,
			object[] p_objDataArr)
		{
			//根据 p_intRecordType 获取对应的 clsSubWatchItemRecordContent
			clsSubWatchItemRecordContent objContent = new clsSubWatchItemRecordContent();
		
			objContent.m_dtmCreateDate = DateTime.Parse((string)p_objDataArr[0]);
			objContent.m_dtmOpenDate = DateTime.Parse((string)p_objDataArr[2]);
            objContent.m_dtmModifyDate = DateTime.Parse((string)p_objDataArr[3]);
            objContent.m_strCreateUserID = p_objDataArr[26].ToString();    
		
			return objContent;
		}

		/// <summary>
		///  获取病程记录的领域层实例
		/// </summary>
		/// <returns></returns>
		protected override clsRecordsDomain m_objGetRecordsDomain()
		{
            return new clsRecordsDomain(enmRecordsType.WatchItem);
		}

		protected override infPrintRecord m_objGetPrintTool()
		{
			return new clsWatchItemTrackPrintTool();
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
			m_mthAddNewRecord((int)enmDiseaseTrackType.WatchItem);
		}
		/// <summary>
		///  获取处理（添加和修改）记录的窗体。
		/// </summary>
		/// <param name="p_intRecordType"></param>
		/// <returns></returns>
		protected override frmDiseaseTrackBase m_frmGetRecordForm(int p_intRecordType)
		{
			///返回观察项目记录单相对应的编辑窗体
			return new frmSubWatchItemRecord();
		}

		/// <summary>
		/// 观察项目记录单等特殊窗体重载本方法，在其子窗体中自行实现。
		/// </summary>
		/// <param name="p_intRecordType"></param>
		protected override void m_mthAddNewRecord(int p_intRecordType)
		{
			//获取添加记录的窗体
			frmDiseaseTrackBase frmAddNewForm = m_frmGetRecordForm(p_intRecordType);    
		
			//添加控制
			frmAddNewForm.m_mthSetDiseaseTrackInfoForAddNew(m_objCurrentPatient);
		
			m_mthShowSubForm(frmAddNewForm,p_intRecordType,false);
		}

		/// <summary>
		/// 观察项目记录单等特殊窗体重载本方法，在其子窗体中自行实现。
		/// </summary>
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

        protected override void m_mthHandleSubFormClosedWithYes(frmDiseaseTrackBase p_frmSubForm)
        {
            m_mthPerformSessionChanged(m_ObjCurrentEmrPatientSession,0);
        }

        /// <summary>
        /// 观察项目记录单等特殊窗体重载本方法，在其子窗体中自行实现。
        /// </summary>
        /// <param name="p_intRecordType"></param>
        /// <param name="p_dtmCreateRecordTime"></param>
        protected override void m_mthRemoveDataFromDataTable(int p_intRecordType,
            DateTime p_dtmCreateRecordTime)
        {
            m_mthPerformSessionChanged(m_ObjCurrentEmrPatientSession, 0);
        }

		#region 打印
		private clsWatchItemDataInfo[] m_objPrintDataArr;
		/// <summary>
		/// 设置打印内容。
		/// </summary>
		/// <param name="p_objTransDataArr"></param>
		/// <param name="p_dtmFirstPrintDate"></param>
		protected override void m_mthSetPrintContent(clsTransDataInfo[] p_objTransDataArr,
			DateTime[] p_dtmFirstPrintDate)
		{
			if(p_objTransDataArr==null || p_dtmFirstPrintDate==null ||p_objTransDataArr.Length !=p_dtmFirstPrintDate.Length)
			{
				clsPublicFunction.ShowInformationMessageBox("打印数据有误!");
				return;
			}
			ArrayList m_arlTemp = new ArrayList();
			for(int i1=0;i1<p_objTransDataArr.Length;i1++)
			{
				m_arlTemp.Add(p_objTransDataArr[i1]);
			}
			m_objPrintDataArr = (clsWatchItemDataInfo[])m_arlTemp.ToArray(typeof(clsWatchItemDataInfo));
		}

		// 初始化打印变量
		protected override void m_mthInitPrintTool()
		{
			#region 有关打印初始化
		
			m_fotTitleFont = new Font("SimSun", 20,FontStyle.Bold );
			m_fotHeaderFont = new Font("SimSun", 12f);
			m_fotSmallFont = new Font("SimSun",10.5f);
			m_fotTinyFont=new Font("SimSun",8f);
		
			m_GridPen = new Pen(Color.Black,1);
			m_slbBrush = new SolidBrush(Color.Black);
	
			m_objPageSetting = new clsPrintPageSettingForRecord();
			//			m_intCurrentRecord=0;
			//			m_intNowPage=1;				
			#endregion	
		}

		// 释放打印变量
		protected override void m_mthDisposePrintTools()
		{
			m_objPageSetting = null;
			m_fotTitleFont.Dispose();
			m_fotHeaderFont.Dispose();
			m_fotSmallFont.Dispose();
			m_fotTinyFont.Dispose();
			m_GridPen.Dispose();
			m_slbBrush.Dispose();
		}

		// 打印开始后，在打印页之前的操作
		protected override void m_mthBeginPrintSub(PrintEventArgs p_objPrintArg)
		{

		}

		// 打印页
		protected override void m_mthPrintPageSub(PrintPageEventArgs p_objPrintPageArg)
		{			
			try
			{
				p_objPrintPageArg.HasMorePages =false;
				m_mthPrintTitleInfo(p_objPrintPageArg);
				m_mthPrintRectangleInfo(p_objPrintPageArg);	
				m_mthPrintHeaderInfo(p_objPrintPageArg);

				if(m_objCurrentPatient==null || m_objPrintDataArr==null || m_objPrintDataArr.Length==0)
					return;
				while(m_intCurrentRecord < m_objPrintDataArr.Length)
				{				
					if(m_intCurrentRecord==0)
						m_intSetPrintOneValueRows(p_objPrintPageArg,ref m_intPosY);
					m_blnBeginPrintNewRecord = m_blnPrintOneValue(p_objPrintPageArg, m_intPosY);	
				
					//斜线
					p_objPrintPageArg.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8 ,
						m_intPosY-intTempDeltaY,
						(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7,
						m_intPosY);			

					if(m_blnBeginPrintNewRecord)
					{
						m_intCurrentRecord++;
					
						m_mthPrintOneHorizontalLine(p_objPrintPageArg,m_intPosY);

						int intMaxRows=m_intSetPrintOneValueRows(p_objPrintPageArg,ref m_intPosY);
						if(m_intPosY + intMaxRows*intTempDeltaY >= 1100	&& m_intCurrentRecord < m_objPrintDataArr.Length)
						{
							p_objPrintPageArg.HasMorePages = true;				

							//Print VLine
							m_mthPrintVLines(p_objPrintPageArg,m_intPosY);
							m_mthPrintOneHorizontalLine(p_objPrintPageArg,m_intPosY);

							//页脚//////////////////////////////////////////////////////////////
							p_objPrintPageArg.Graphics.DrawString("（第"+m_intNowPage.ToString()+"页）",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15-30 ,
								m_intPosY+(int)enmRecordRectangleInfo.VOffSet );
           

							m_intPosY = (int)enmRecordRectangleInfo.TopY+150;
							m_intNowPage++;
							return;
					
						}
					}					
				
				}
				m_mthPrintVLines(p_objPrintPageArg,m_intPosY);
				//页脚//////////////////////////////////////////////////////////////
				p_objPrintPageArg.Graphics.DrawString("（第"+m_intNowPage.ToString()+"页）",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15-30 ,
					m_intPosY+(int)enmRecordRectangleInfo.VOffSet );
			
				#region 打印完毕，ReSet(复位)操作
				if(m_intCurrentRecord==m_objPrintDataArr.Length)
				{	
					m_intPosY = (int)enmRecordRectangleInfo.TopY+3*m_intHeaderRowStep;
					m_intCurrentRecord=0;//当前记录的序号复位，以备下一次打印操作
					m_blnBeginPrintNewRecord=true;//复位
					m_intNowPage=1;//复位						
				}
				#endregion				
			}
			catch(Exception err)
			{
				clsPublicFunction.ShowInformationMessageBox(err.Message + "\r\n" + err.StackTrace);

			}
		}

		// 打印结束时的操作
		protected override void m_mthEndPrintSub(PrintEventArgs p_objPrintArg)
		{
		
		}



		#region 标题文字部分
		/// <summary>
		/// 标题文字部分
		/// </summary>
		/// <param name="e"></param>
		private void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
		{
			clsEveryRecordPageInfo objEveryRecordPageInfo=new clsEveryRecordPageInfo();
			//************************************************
			objEveryRecordPageInfo.strAge =m_objCurrentPatient!=null? m_objCurrentPatient.m_ObjPeopleInfo.m_IntAge.ToString() : "";
			objEveryRecordPageInfo.strPatientName=m_objCurrentPatient!=null? m_objCurrentPatient.m_ObjPeopleInfo.m_StrFirstName :"";
			objEveryRecordPageInfo.strDeptName= m_objCurrentPatient!=null? m_objCurrentPatient.m_ObjInBedInfo.m_ObjLastDeptInfo.m_ObjDept.m_StrDeptName : "";			
			objEveryRecordPageInfo.strBedNo =m_objCurrentPatient!=null? m_objCurrentPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName :"";
			objEveryRecordPageInfo.strAreaName=m_objCurrentPatient!=null? m_objCurrentPatient.m_ObjInBedInfo.m_ObjLastAreaInfo.m_ObjArea.m_StrAreaName:"";
			objEveryRecordPageInfo.strSex=m_objCurrentPatient!=null? m_objCurrentPatient.m_ObjPeopleInfo.m_StrSex:"";
			objEveryRecordPageInfo.strInPatientID=m_objCurrentPatient!=null? m_objCurrentPatient.m_StrInPatientID:"";
			objEveryRecordPageInfo.strPrintDate=m_objCurrentPatient!=null? DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") :"";		
			
			e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle,m_fotSmallFont ,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_HospitalName  ));
            
			e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle,m_fotSmallFont ,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_HospitalName  ));
		
			e.Graphics.DrawString("观 察 项 目 记 录 单",m_fotTitleFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_Name_Title ));
			

			e.Graphics.DrawString("姓名：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name_Title  ));
			e.Graphics.DrawString(objEveryRecordPageInfo.strPatientName  ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name ));
		
			e.Graphics.DrawString("性别：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex_Title ));
			e.Graphics.DrawString(objEveryRecordPageInfo.strSex ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex  ));

			e.Graphics.DrawString("年龄：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Age_Title ));
			e.Graphics.DrawString(objEveryRecordPageInfo.strAge ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Age ));

			e.Graphics.DrawString("科室：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Dept_Name_Title ));
			e.Graphics.DrawString(objEveryRecordPageInfo.strDeptName ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Dept_Name ));

			e.Graphics.DrawString("病区：",m_fotSmallFont,m_slbBrush,new PointF(430f,150f));
			e.Graphics.DrawString(objEveryRecordPageInfo.strAreaName ,m_fotSmallFont,m_slbBrush,new PointF(480f,150f));

			e.Graphics.DrawString("床号：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.BedNo_Title ));
			e.Graphics.DrawString(objEveryRecordPageInfo.strBedNo ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.BedNo ));	
			
			e.Graphics.DrawString("住院号：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID_Title ));
			e.Graphics.DrawString(objEveryRecordPageInfo.strInPatientID ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID ));	
						
		}
		#endregion

		#region 画表头格子
		/// <summary>
		///  画表头格子
		/// </summary>
		/// <param name="e"></param>
		private void m_mthPrintRectangleInfo(System.Drawing.Printing.PrintPageEventArgs e)
		{
			int m_intHeaderRowStep=50;
			
			//画格子横线
			for(int i1=0;i1<4 /*(int)enmRecordRectangleInfo.RowLinesNum*/ ;i1++)
			{
				if(i1 !=1 && i1 !=2)
					e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX ,
						(int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep*i1,
						(int)enmRecordRectangleInfo.RightX,
						(int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep*i1);
				else if(i1==1)
				{
					e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+ (int)enmRecordRectangleInfo.ColumnsMark8,
						(int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep*i1-5,
						(int)enmRecordRectangleInfo.LeftX+ (int)enmRecordRectangleInfo.ColumnsMark12,
						(int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep*i1-5);
					e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+ (int)enmRecordRectangleInfo.ColumnsMark14,
						(int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep*i1-5,
						(int)enmRecordRectangleInfo.LeftX+ (int)enmRecordRectangleInfo.ColumnsMark20,
						(int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep*i1-5);
				}
				else //if(i1==2)
					e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+ (int)enmRecordRectangleInfo.ColumnsMark8,
						(int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep*i1,
						(int)enmRecordRectangleInfo.LeftX+ (int)enmRecordRectangleInfo.ColumnsMark12,
						(int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep*i1);
			}
			
			#region 画格子竖线
			int intHeight=3*m_intHeaderRowStep;
			//画左边沿线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX,(int)enmRecordRectangleInfo.TopY+intHeight);
			
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,(int)enmRecordRectangleInfo.TopY+intHeight);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,(int)enmRecordRectangleInfo.TopY+intHeight);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3,(int)enmRecordRectangleInfo.TopY+intHeight);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4,(int)enmRecordRectangleInfo.TopY+intHeight);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5,(int)enmRecordRectangleInfo.TopY+intHeight);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6,(int)enmRecordRectangleInfo.TopY+intHeight);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7,(int)enmRecordRectangleInfo.TopY+intHeight);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8,(int)enmRecordRectangleInfo.TopY+intHeight);
			//瞳孔大小左右分界线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9,(int)enmRecordRectangleInfo.TopY+2*m_intHeaderRowStep,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9,(int)enmRecordRectangleInfo.TopY+intHeight);
			//瞳孔大小与反射分界线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10,(int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep-5,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10,(int)enmRecordRectangleInfo.TopY+intHeight);
			//瞳孔反射左右分界线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11,(int)enmRecordRectangleInfo.TopY+2*m_intHeaderRowStep,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11,(int)enmRecordRectangleInfo.TopY+intHeight);			
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark12,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark12,(int)enmRecordRectangleInfo.TopY+intHeight);
			
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark13,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark13,(int)enmRecordRectangleInfo.TopY+intHeight);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark14,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark14,(int)enmRecordRectangleInfo.TopY+intHeight);
			
			//摄入中间分界线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15,(int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep-5,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15,(int)enmRecordRectangleInfo.TopY+intHeight);			
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark16,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark16,(int)enmRecordRectangleInfo.TopY+intHeight);
			//排出中间分界线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark17,(int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep-5,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark17,(int)enmRecordRectangleInfo.TopY+intHeight);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark18,(int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep-5,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark18,(int)enmRecordRectangleInfo.TopY+intHeight);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark19,(int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep-5,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark19,(int)enmRecordRectangleInfo.TopY+intHeight);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark20,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark20,(int)enmRecordRectangleInfo.TopY+intHeight);
			
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.RightX ,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.RightX,(int)enmRecordRectangleInfo.TopY+intHeight);
			#endregion				
			
		}

						
		#endregion		

		#region 画标题的栏目
		private int m_intHeaderRowStep=50;
		/// <summary>
		/// 画标题的栏目
		/// </summary>
		/// <param name="e"></param>
		private void m_mthPrintHeaderInfo(System.Drawing.Printing.PrintPageEventArgs e)
		{			
		
			e.Graphics.DrawString("日期",m_fotHeaderFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+15,
				(int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep+5);
		     
			e.Graphics.DrawString("时间",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark1+1, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep+5);

			//体温 C			
			e.Graphics.DrawString("体",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark2+1, (int)enmRecordRectangleInfo.TopY+7);
			e.Graphics.DrawString("温",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark2+1, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep+5);
			e.Graphics.DrawString("。",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark2+1, (int)enmRecordRectangleInfo.TopY-10+2*m_intHeaderRowStep+5);
			e.Graphics.DrawString("C",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark2+9, (int)enmRecordRectangleInfo.TopY+2*m_intHeaderRowStep+1+5);

			// 心律			
			e.Graphics.DrawString("心",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark3+5, (int)enmRecordRectangleInfo.TopY+7);
			e.Graphics.DrawString("律",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark3+5, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep+5);
			
			//心率(次/分)
			e.Graphics.DrawString("心",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark4+1, (int)enmRecordRectangleInfo.TopY+7);
			e.Graphics.DrawString("率",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark4+1, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep-13);
			e.Graphics.DrawString("次",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark4+1, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep+15);
			e.Graphics.DrawString("/",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark4+5, (int)enmRecordRectangleInfo.TopY+2*m_intHeaderRowStep-7);
			e.Graphics.DrawString("分",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark4+1, (int)enmRecordRectangleInfo.TopY+2*m_intHeaderRowStep+13);

			//脉搏(次/分)
			e.Graphics.DrawString("脉",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark5+1, (int)enmRecordRectangleInfo.TopY+7);
			e.Graphics.DrawString("搏",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark5+1, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep-13);
			e.Graphics.DrawString("次",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark5+1, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep+15);
			e.Graphics.DrawString("/",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark5+5, (int)enmRecordRectangleInfo.TopY+2*m_intHeaderRowStep-7);
			e.Graphics.DrawString("分",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark5+1, (int)enmRecordRectangleInfo.TopY+2*m_intHeaderRowStep+13);

			//呼吸(次/分)
			e.Graphics.DrawString("呼",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark6+1, (int)enmRecordRectangleInfo.TopY+7);
			e.Graphics.DrawString("吸",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark6+1, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep-13);
			e.Graphics.DrawString("次",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark6+1, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep+15);
			e.Graphics.DrawString("/",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark6+5, (int)enmRecordRectangleInfo.TopY+2*m_intHeaderRowStep-7);
			e.Graphics.DrawString("分",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark6+1, (int)enmRecordRectangleInfo.TopY+2*m_intHeaderRowStep+13);

			//血压(mmHg)
			e.Graphics.DrawString("血压",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark7+8, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep-15);
			e.Graphics.DrawString("mmHg",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark7+8, (int)enmRecordRectangleInfo.TopY+2*m_intHeaderRowStep-10);
	
			e.Graphics.DrawString(" 瞳 孔",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark8+31, (int)enmRecordRectangleInfo.TopY+7);
			e.Graphics.DrawString("大小",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark8+10, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep+5-5);
			e.Graphics.DrawString("(mm)",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark8+10, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep+5+15);
			e.Graphics.DrawString("左",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark8+1, (int)enmRecordRectangleInfo.TopY+2*m_intHeaderRowStep+5);

			e.Graphics.DrawString("右",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark9+1, (int)enmRecordRectangleInfo.TopY+2*m_intHeaderRowStep+5);


			e.Graphics.DrawString("反射",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark10+18, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep+5);

			e.Graphics.DrawString("左",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark10+1, (int)enmRecordRectangleInfo.TopY+2*m_intHeaderRowStep+5);

			e.Graphics.DrawString("右",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark11+1, (int)enmRecordRectangleInfo.TopY+2*m_intHeaderRowStep+5);

			//血氧饱和度(%)
			e.Graphics.DrawString("血",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark12+2, (int)enmRecordRectangleInfo.TopY+4);
			e.Graphics.DrawString("氧",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark12+2, (int)enmRecordRectangleInfo.TopY+3*m_intHeaderRowStep*1/6);
			e.Graphics.DrawString("饱",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark12+2, (int)enmRecordRectangleInfo.TopY+3*m_intHeaderRowStep*2/6);
			e.Graphics.DrawString("和",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark12+2, (int)enmRecordRectangleInfo.TopY+3*m_intHeaderRowStep*3/6);
			e.Graphics.DrawString("度",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark12+2, (int)enmRecordRectangleInfo.TopY+3*m_intHeaderRowStep*4/6);
			e.Graphics.DrawString("(%)",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark12, (int)enmRecordRectangleInfo.TopY+3*m_intHeaderRowStep*5/6);

			//床边血糖(mmol/L)
			e.Graphics.DrawString("床",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark13+6, (int)enmRecordRectangleInfo.TopY+4);
			e.Graphics.DrawString("边",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark13+6, (int)enmRecordRectangleInfo.TopY+3*m_intHeaderRowStep*1/6);
			e.Graphics.DrawString("血",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark13+6, (int)enmRecordRectangleInfo.TopY+3*m_intHeaderRowStep*2/6);
			e.Graphics.DrawString("糖",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark13+6, (int)enmRecordRectangleInfo.TopY+3*m_intHeaderRowStep*3/6);
			e.Graphics.DrawString("mmol",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark13+2, (int)enmRecordRectangleInfo.TopY+3*m_intHeaderRowStep*4/6);
			e.Graphics.DrawString("/L",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark13+6, (int)enmRecordRectangleInfo.TopY+3*m_intHeaderRowStep*5/6);


			e.Graphics.DrawString("摄入",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark15-20, (int)enmRecordRectangleInfo.TopY+4);
			e.Graphics.DrawString("(ml)",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark15-20, (int)enmRecordRectangleInfo.TopY+25);
			e.Graphics.DrawString("输",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark14+1, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep+5);
			e.Graphics.DrawString("液",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark14+1, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep+38);
			e.Graphics.DrawString("量",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark14+1, (int)enmRecordRectangleInfo.TopY+2*m_intHeaderRowStep+20);

			e.Graphics.DrawString("进",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark15+1, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep+5);
			e.Graphics.DrawString("食",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark15+1, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep+38);
			e.Graphics.DrawString("量",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark15+1, (int)enmRecordRectangleInfo.TopY+2*m_intHeaderRowStep+20);


			e.Graphics.DrawString("排出",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark18-20, (int)enmRecordRectangleInfo.TopY+4);
			e.Graphics.DrawString("(ml)",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark18-20, (int)enmRecordRectangleInfo.TopY+25);
			e.Graphics.DrawString("引",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark16+1, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep+5);
			e.Graphics.DrawString("流",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark16+1, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep+38);
			e.Graphics.DrawString("量",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark16+1, (int)enmRecordRectangleInfo.TopY+2*m_intHeaderRowStep+20);

			e.Graphics.DrawString("尿",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark17+1, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep+5);
			e.Graphics.DrawString("量",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark17+1, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep+38);

			e.Graphics.DrawString("大",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark18+1, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep+5);
			e.Graphics.DrawString("便",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark18+1, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep+38);

			e.Graphics.DrawString("呕",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark19+1, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep+5);
			e.Graphics.DrawString("吐",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark19+1, (int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep+38);
			e.Graphics.DrawString("物",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark19+1, (int)enmRecordRectangleInfo.TopY+2*m_intHeaderRowStep+20);


			e.Graphics.DrawString("签名",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark20+1,(int)enmRecordRectangleInfo.TopY+m_intHeaderRowStep+5);
		
		
		}
		#endregion

		#region 打印所有的垂直线
		/// <summary>
		/// 打印所有的垂直线
		/// </summary>
		/// <param name="e"></param>
		/// <param name="p_intPageBottomY"></param>
		private void m_mthPrintVLines(PrintPageEventArgs e,int p_intPageBottomY)
		{			
			#region 画格子竖线
			int intContentTopY=(int)enmRecordRectangleInfo.TopY+ 150;
			//画左边沿线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX,p_intPageBottomY);
			
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,p_intPageBottomY);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,p_intPageBottomY);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3,p_intPageBottomY);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4,p_intPageBottomY);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5,p_intPageBottomY);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6,p_intPageBottomY);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7,p_intPageBottomY);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8,p_intPageBottomY);
			//瞳孔大小左右分界线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9,p_intPageBottomY);
			//瞳孔大小与反射分界线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10,p_intPageBottomY);
			//瞳孔反射左右分界线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11,p_intPageBottomY);			
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark12,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark12,p_intPageBottomY);
			
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark13,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark13,p_intPageBottomY);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark14,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark14,p_intPageBottomY);
			
			//摄入中间分界线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15,p_intPageBottomY);			
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark16,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark16,p_intPageBottomY);
			//排出中间分界线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark17,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark17,p_intPageBottomY);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark18,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark18,p_intPageBottomY);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark19,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark19,p_intPageBottomY);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark20,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark20,p_intPageBottomY);
			
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.RightX ,intContentTopY,
				(int)enmRecordRectangleInfo.RightX,p_intPageBottomY);
			#endregion		
		}
		#endregion

		#region 打印一条水平线
		/// <summary>
		/// 打印一条水平线
		/// </summary>
		/// <param name="e"></param>
		/// <param name="p_intBottomY"></param>
		private void m_mthPrintOneHorizontalLine(System.Drawing.Printing.PrintPageEventArgs e,int p_intBottomY)
		{			
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX ,
				p_intBottomY,
				(int)enmRecordRectangleInfo.RightX,
				p_intBottomY);			
		}
		#endregion

		#region 只打印一行
		/// <summary>
		/// 只打印一行
		/// </summary>
		/// <param name="e"></param>
		/// <param name="p_intBottomY"></param>
		/// <returns></returns>
		private bool m_blnPrintOneValue(System.Drawing.Printing.PrintPageEventArgs e,int p_intBottomY)
		{			
			p_intBottomY +=(int)enmRecordRectangleInfo.VOffSet;
			#region 如果是新记录，打印日期
			if(m_blnBeginPrintNewRecord==true) 
			{
				m_intNowRowInOneRecord=0;

				//读出日期
				string strCreateDate;
				string strCreateTime;
				string strCreateDateTime;
				
				if(m_objPrintDataArr[m_intCurrentRecord].m_intFlag != (int)enmRecordsType.WatchItem && m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr == null)
				{
					strCreateDate = "";
					strCreateTime = "";
					strCreateDateTime = "";
				}
				else
				{
					strCreateDateTime=m_objPrintDataArr[m_intCurrentRecord].m_objRecordContent.m_dtmCreateDate.ToString("yyyy-MM-dd HH:mm:ss");
					try
					{
						strCreateDate=DateTime.Parse(strCreateDateTime).ToString("yyyy-M-d");
						strCreateTime=DateTime.Parse(strCreateDateTime).ToString("HH:mm");
					}
					catch
					{strCreateDate="不详";strCreateTime="不详";}	
				}
				//开始打印一条新记录/////////////////////////////////////////////////////////////////////
				e.Graphics.DrawString(strCreateDate,m_fotSmallFont ,m_slbBrush,
					(int)enmRecordRectangleInfo.LeftX, 
					p_intBottomY);	
				e.Graphics.DrawString(strCreateTime,m_fotSmallFont ,m_slbBrush,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1+1, 
					p_intBottomY );	
			}
			#endregion			
			
			#region 按修改顺序打印当前记录的某一行	
			bool blnIsRecordFinish=m_blnPrintOneRowValue(m_strValueArr,m_intNowRowInOneRecord,e,p_intBottomY);
			
			#region 签名（作过修改的人签名）
			string strSign;
			if(m_objPrintDataArr[m_intCurrentRecord].m_intFlag != (int)enmRecordsType.WatchItem && m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr == null)
				strSign = "";
			else
				strSign = m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[m_intNowRowInOneRecord].m_strModifyUserName;			
			//			clsEmployee objclsEmployee=new clsEmployee(m_objclsWatchItemRecordContent_AllArr[m_intCurrentRecord].m_objclsWatchItemRecordContentArr[m_intNowRowInOneRecord].m_strModifyUserID);
			//			if(objclsEmployee!=null)
			//				strSign=objclsEmployee.m_StrFirstName;			
			e.Graphics.DrawString(strSign ,m_fotSmallFont ,m_slbBrush,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark20+1, 
				p_intBottomY);
			#endregion

			m_blnBeginPrintNewRecord=blnIsRecordFinish;//当前记录是否打完					
			m_intNowRowInOneRecord++;
			#endregion

			m_intPosY += intTempDeltaY;
			return blnIsRecordFinish;			
		}

		#endregion
	
		#region Liyi
		/// <summary>
		/// 打印一次时间记录的一行数值（需完成血压斜线的打印）
		/// </summary>
		/// <param name="p_strValueArr">数值(从“体温”到“呕吐物”，共19个)</param>
		/// <param name="p_intIndex">第几次的结果</param>
		/// <param name="e">打印参数</param>
		/// <param name="p_intPosY">Y坐标</param>
		private bool m_blnPrintOneRowValue(string [][] p_strValueArr,int p_intIndex,System.Drawing.Printing.PrintPageEventArgs e,int p_intPosY)
		{			
			string [] strValueArr = p_strValueArr[p_intIndex];

			if(p_strValueArr[0][12] == "总计:")
			{
				return m_blnPrintOneRowValueOfSummary(p_strValueArr,p_intIndex,e,p_intPosY);
			}

			CharacterRange []rgnDSTArr = new CharacterRange[1];
			rgnDSTArr[0] = new CharacterRange(0,0);			
				
			RectangleF rtfText = new RectangleF(0,0,10000,100);

			StringFormat stfMeasure = new StringFormat(StringFormatFlags.LineLimit);			

			RectangleF rtfBounds;

			Region [] rgnDST;

			int intTempColumn=0;//当前的列数（相对）
			int intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2;//当前的X坐标
			//体温
			#region 打印一格，（以下完全相同）
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
				if(p_intIndex+1 < p_strValueArr.Length)
				{
					if(strValueArr[intTempColumn] != p_strValueArr[p_intIndex+1][intTempColumn])
					{
						rtfText.X = intPosX;
						rtfText.Y = p_intPosY;

						rgnDSTArr[0].First = 0;
						rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

						stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

						rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

						rtfBounds = rgnDST[0].GetBounds(e.Graphics);

						e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
						e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
					}
				}
			}
			#endregion	打印一格

			intTempColumn=1;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3;//当前的X坐标
			//心律
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
				if(p_intIndex+1 < p_strValueArr.Length)
				{
					if(strValueArr[intTempColumn] != p_strValueArr[p_intIndex+1][intTempColumn])
					{
						rtfText.X = intPosX;
						rtfText.Y = p_intPosY;

						rgnDSTArr[0].First = 0;
						rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

						stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

						rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

						rtfBounds = rgnDST[0].GetBounds(e.Graphics);

						e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
						e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
					}
				}
			}
			#endregion	打印一格

			intTempColumn=2;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4;//当前的X坐标
			//心率
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
				if(p_intIndex+1 < p_strValueArr.Length)
				{
					if(strValueArr[intTempColumn] != p_strValueArr[p_intIndex+1][intTempColumn])
					{
						rtfText.X = intPosX;
						rtfText.Y = p_intPosY;

						rgnDSTArr[0].First = 0;
						rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

						stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

						rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

						rtfBounds = rgnDST[0].GetBounds(e.Graphics);

						e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
						e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
					}
				}
			}
			#endregion	打印一格

			intTempColumn=3;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5;//当前的X坐标
			//脉搏
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
				if(p_intIndex+1 < p_strValueArr.Length)
				{
					if(strValueArr[intTempColumn] != p_strValueArr[p_intIndex+1][intTempColumn])
					{
						rtfText.X = intPosX;
						rtfText.Y = p_intPosY;

						rgnDSTArr[0].First = 0;
						rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

						stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

						rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

						rtfBounds = rgnDST[0].GetBounds(e.Graphics);

						e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
						e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
					}
				}
			}
			#endregion	打印一格

			intTempColumn=4;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6;//当前的X坐标
			//呼吸
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
				if(p_intIndex+1 < p_strValueArr.Length)
				{
					if(strValueArr[intTempColumn] != p_strValueArr[p_intIndex+1][intTempColumn])
					{
						rtfText.X = intPosX;
						rtfText.Y = p_intPosY;

						rgnDSTArr[0].First = 0;
						rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

						stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

						rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

						rtfBounds = rgnDST[0].GetBounds(e.Graphics);

						e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
						e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
					}
				}
			}
			#endregion	打印一格

			
			bool blnIsLastModify=false;
			if( p_intIndex == p_strValueArr.Length-1 || (strValueArr[5] == p_strValueArr[p_intIndex+1][5] && strValueArr[6] == p_strValueArr[p_intIndex+1][6] && strValueArr[5] == p_strValueArr[p_strValueArr.Length-1][5] && strValueArr[6] == p_strValueArr[p_strValueArr.Length-1][6] ))
			{// 当存在下一行，并且当前元素 != 下一行此元素				
				blnIsLastModify=true;					
			}
			//血压(收缩压)
			if(strValueArr[5].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[5],m_fotSmallFont,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7,p_intPosY-15);
				if( ! blnIsLastModify)
				{					
					rtfText.X = (int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7;
					rtfText.Y = p_intPosY-15;

					rgnDSTArr[0].First = 0;
					rgnDSTArr[0].Length = strValueArr[5].Length;

					stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

					rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[5],m_fotSmallFont,rtfText,stfMeasure);

					rtfBounds = rgnDST[0].GetBounds(e.Graphics);

					e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
					e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
					
				}
			}	
			
			//血压(舒张压)
			if(strValueArr[6].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[6],m_fotSmallFont,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7+30,p_intPosY);
				if( ! blnIsLastModify)
				{					
					rtfText.X = (int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7+30;
					rtfText.Y = p_intPosY;

					rgnDSTArr[0].First = 0;
					rgnDSTArr[0].Length = strValueArr[6].Length;

					stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

					rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[6],m_fotSmallFont,rtfText,stfMeasure);

					rtfBounds = rgnDST[0].GetBounds(e.Graphics);

					e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
					e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
					
				}
			}

			intTempColumn=7;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8;//当前的X坐标
			//瞳孔大小（左）
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
				if(p_intIndex+1 < p_strValueArr.Length)
				{
					if(strValueArr[intTempColumn] != p_strValueArr[p_intIndex+1][intTempColumn])
					{
						rtfText.X = intPosX;
						rtfText.Y = p_intPosY;

						rgnDSTArr[0].First = 0;
						rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

						stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

						rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

						rtfBounds = rgnDST[0].GetBounds(e.Graphics);

						e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
						e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
					}
				}
			}
			#endregion	打印一格

			intTempColumn++;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9;//当前的X坐标
			//瞳孔大小（右）
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
				if(p_intIndex+1 < p_strValueArr.Length)
				{
					if(strValueArr[intTempColumn] != p_strValueArr[p_intIndex+1][intTempColumn])
					{
						rtfText.X = intPosX;
						rtfText.Y = p_intPosY;

						rgnDSTArr[0].First = 0;
						rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

						stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

						rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

						rtfBounds = rgnDST[0].GetBounds(e.Graphics);

						e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
						e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
					}
				}
			}
			#endregion	打印一格

			intTempColumn++;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10;//当前的X坐标
			//瞳孔反射（左）
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
				if(p_intIndex+1 < p_strValueArr.Length)
				{
					if(strValueArr[intTempColumn] != p_strValueArr[p_intIndex+1][intTempColumn])
					{
						rtfText.X = intPosX;
						rtfText.Y = p_intPosY;

						rgnDSTArr[0].First = 0;
						rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

						stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

						rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

						rtfBounds = rgnDST[0].GetBounds(e.Graphics);

						e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
						e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
					}
				}
			}
			#endregion	打印一格		

			intTempColumn++;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11;//当前的X坐标
			//瞳孔反射（右）
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
				if(p_intIndex+1 < p_strValueArr.Length)
				{
					if(strValueArr[intTempColumn] != p_strValueArr[p_intIndex+1][intTempColumn])
					{
						rtfText.X = intPosX;
						rtfText.Y = p_intPosY;

						rgnDSTArr[0].First = 0;
						rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

						stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

						rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

						rtfBounds = rgnDST[0].GetBounds(e.Graphics);

						e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
						e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
					}
				}
			}
			#endregion	打印一格		
			
			intTempColumn++;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark12;//当前的X坐标
			//血氧饱和度
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
				if(p_intIndex+1 < p_strValueArr.Length)
				{
					if(strValueArr[intTempColumn] != p_strValueArr[p_intIndex+1][intTempColumn])
					{
						rtfText.X = intPosX;
						rtfText.Y = p_intPosY;

						rgnDSTArr[0].First = 0;
						rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

						stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

						rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

						rtfBounds = rgnDST[0].GetBounds(e.Graphics);

						e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
						e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
					}
				}
			}
			#endregion	打印一格		
			
			intTempColumn++;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark13;//当前的X坐标
			//床边血糖
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
				if(p_intIndex+1 < p_strValueArr.Length)
				{
					if(strValueArr[intTempColumn] != p_strValueArr[p_intIndex+1][intTempColumn])
					{
						rtfText.X = intPosX;
						rtfText.Y = p_intPosY;

						rgnDSTArr[0].First = 0;
						rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

						stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

						rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

						rtfBounds = rgnDST[0].GetBounds(e.Graphics);

						e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
						e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
					}
				}
			}
			#endregion	打印一格		

			intTempColumn++;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark14;//当前的X坐标
			//输入液量
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
				if(p_intIndex+1 < p_strValueArr.Length)
				{
					if(strValueArr[intTempColumn] != p_strValueArr[p_intIndex+1][intTempColumn])
					{
						rtfText.X = intPosX;
						rtfText.Y = p_intPosY;

						rgnDSTArr[0].First = 0;
						rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

						stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

						rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

						rtfBounds = rgnDST[0].GetBounds(e.Graphics);

						e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
						e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
					}
				}
			}
			#endregion	打印一格					

			intTempColumn++;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15;//当前的X坐标
			//进食量
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
				if(p_intIndex+1 < p_strValueArr.Length)
				{
					if(strValueArr[intTempColumn] != p_strValueArr[p_intIndex+1][intTempColumn])
					{
						rtfText.X = intPosX;
						rtfText.Y = p_intPosY;

						rgnDSTArr[0].First = 0;
						rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

						stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

						rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

						rtfBounds = rgnDST[0].GetBounds(e.Graphics);

						e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
						e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
					}
				}
			}
			#endregion	打印一格								

			intTempColumn++;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark16;//当前的X坐标
			//引流量
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
				if(p_intIndex+1 < p_strValueArr.Length)
				{
					if(strValueArr[intTempColumn] != p_strValueArr[p_intIndex+1][intTempColumn])
					{
						rtfText.X = intPosX;
						rtfText.Y = p_intPosY;

						rgnDSTArr[0].First = 0;
						rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

						stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

						rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

						rtfBounds = rgnDST[0].GetBounds(e.Graphics);

						e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
						e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
					}
				}
			}
			#endregion	打印一格								

			intTempColumn++;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark17;//当前的X坐标
			//尿量
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
				if(p_intIndex+1 < p_strValueArr.Length)
				{
					if(strValueArr[intTempColumn] != p_strValueArr[p_intIndex+1][intTempColumn])
					{
						rtfText.X = intPosX;
						rtfText.Y = p_intPosY;

						rgnDSTArr[0].First = 0;
						rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

						stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

						rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

						rtfBounds = rgnDST[0].GetBounds(e.Graphics);

						e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
						e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
					}
				}
			}
			#endregion	打印一格								

			intTempColumn++;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark18;//当前的X坐标
			//大便
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
				if(p_intIndex+1 < p_strValueArr.Length)
				{
					if(strValueArr[intTempColumn] != p_strValueArr[p_intIndex+1][intTempColumn])
					{
						rtfText.X = intPosX;
						rtfText.Y = p_intPosY;

						rgnDSTArr[0].First = 0;
						rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

						stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

						rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

						rtfBounds = rgnDST[0].GetBounds(e.Graphics);

						e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
						e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
					}
				}
			}
			#endregion	打印一格								

			intTempColumn++;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark19;//当前的X坐标
			//呕吐物
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
				if(p_intIndex+1 < p_strValueArr.Length)
				{
					if(strValueArr[intTempColumn] != p_strValueArr[p_intIndex+1][intTempColumn])
					{
						rtfText.X = intPosX;
						rtfText.Y = p_intPosY;

						rgnDSTArr[0].First = 0;
						rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

						stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

						rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

						rtfBounds = rgnDST[0].GetBounds(e.Graphics);

						e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
						e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
					}
				}
			}
			#endregion	打印一格								

			return p_intIndex==p_strValueArr.Length-1;
		}
		#endregion


		#region Alex
		/// <summary>
		/// 打印一次时间记录的一行数值（需完成血压斜线的打印）
		/// </summary>
		/// <param name="p_strValueArr">数值(从“体温”到“呕吐物”，共19个)</param>
		/// <param name="p_intIndex">第几次的结果</param>
		/// <param name="e">打印参数</param>
		/// <param name="p_intPosY">Y坐标</param>
		private bool m_blnPrintOneRowValueOfSummary(string [][] p_strValueArr,int p_intIndex,System.Drawing.Printing.PrintPageEventArgs e,int p_intPosY)
		{			
			string [] strValueArr = p_strValueArr[p_intIndex];

			CharacterRange []rgnDSTArr = new CharacterRange[1];
			rgnDSTArr[0] = new CharacterRange(0,0);			
				
			RectangleF rtfText = new RectangleF(0,0,10000,100);

			StringFormat stfMeasure = new StringFormat(StringFormatFlags.LineLimit);			

			RectangleF rtfBounds;

			Region [] rgnDST;

			int intTempColumn=0;//当前的列数（相对）
			int intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2;//当前的X坐标
			//体温

			intTempColumn=1;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3;//当前的X坐标
			//心律

			intTempColumn=2;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4;//当前的X坐标
			//心率

			intTempColumn=3;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5;//当前的X坐标
			//脉搏
			intTempColumn=4;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6;//当前的X坐标
			//呼吸

			intTempColumn=7;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8;//当前的X坐标
			//瞳孔大小（左）

			intTempColumn++;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9;//当前的X坐标
			//瞳孔大小（右）

			intTempColumn++;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10;//当前的X坐标
			//瞳孔反射（左）

			intTempColumn++;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11;//当前的X坐标
			//瞳孔反射（右）
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
			}
			#endregion	打印一格		
			
			intTempColumn++;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark12;//当前的X坐标
			//血氧饱和度
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
			}
			#endregion	打印一格		
			
			intTempColumn++;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark13;//当前的X坐标
			//床边血糖
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
			}
			#endregion	打印一格		

			intTempColumn++;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark14;//当前的X坐标
			//输入液量
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					rtfText.X = intPosX;
					rtfText.Y = p_intPosY;

					rgnDSTArr[0].First = 0;
					rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

					stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

					rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

					rtfBounds = rgnDST[0].GetBounds(e.Graphics);

					e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+6,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+6);
					e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+9,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+9);

			}
			#endregion	打印一格					

			intTempColumn++;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15;//当前的X坐标
			//进食量
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);

					rtfText.X = intPosX;
					rtfText.Y = p_intPosY;

					rgnDSTArr[0].First = 0;
					rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

					stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

					rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

					rtfBounds = rgnDST[0].GetBounds(e.Graphics);
					e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+6,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+6);
					e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+9,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+9);

			}
			#endregion	打印一格								

			intTempColumn++;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark16;//当前的X坐标
			//引流量
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);

					rtfText.X = intPosX;
					rtfText.Y = p_intPosY;

					rgnDSTArr[0].First = 0;
					rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

					stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

					rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

					rtfBounds = rgnDST[0].GetBounds(e.Graphics);

					e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+6,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+6);
					e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+9,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+9);

			}
			#endregion	打印一格								

			intTempColumn++;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark17;//当前的X坐标
			//尿量
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);

					rtfText.X = intPosX;
					rtfText.Y = p_intPosY;

					rgnDSTArr[0].First = 0;
					rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

					stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

					rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

					rtfBounds = rgnDST[0].GetBounds(e.Graphics);

					e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+6,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+6);
					e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+9,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+9);

			}
			#endregion	打印一格								

			intTempColumn++;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark18;//当前的X坐标
			//大便
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);

					rtfText.X = intPosX;
					rtfText.Y = p_intPosY;

					rgnDSTArr[0].First = 0;
					rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

					stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

					rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

					rtfBounds = rgnDST[0].GetBounds(e.Graphics);

					e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+6,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+6);
					e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+9,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+9);

			}
			#endregion	打印一格								

			intTempColumn++;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark19;//当前的X坐标
			//呕吐物
			#region 打印一格
			if(strValueArr[intTempColumn].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[intTempColumn],m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);

					rtfText.X = intPosX;
					rtfText.Y = p_intPosY;

					rgnDSTArr[0].First = 0;
					rgnDSTArr[0].Length = strValueArr[intTempColumn].Length;

					stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

					rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[intTempColumn],m_fotSmallFont,rtfText,stfMeasure);

					rtfBounds = rgnDST[0].GetBounds(e.Graphics);

					e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+6,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+6);
					e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+9,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+9);

			}
			#endregion	打印一格								

			return p_intIndex==p_strValueArr.Length-1;
		}
		#endregion

		#region 设置当前要打印的一条记录数据
		/// <summary>
		/// 设置当前要打印的一条记录数据
		/// </summary>
		/// <param name="e"></param>
		/// <param name="p_intBottomY"></param>
		/// <returns></returns>
		private int m_intSetPrintOneValueRows(PrintPageEventArgs e,ref int p_intBottomY)
		{			
			if(m_objPrintDataArr==null || m_intCurrentRecord>= m_objPrintDataArr.Length)
				return 0;
//
//			if(m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr==null || m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr.Length==0)
//				return 0;

			if(m_objPrintDataArr[m_intCurrentRecord].m_intFlag == (int)enmRecordsType.WatchItem && m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr==null)
				return 0;
//			int intRowsOfOneRecord=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr.Length;
//			string strModifyDate=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[intRowsOfOneRecord-1].m_dtmModifyDate.ToString("yyyy-MM-dd HH:mm:ss") ;

			int intRowsOfOneRecord;
			string strModifyDate;
		
			try
			{
				#region 如果是新记录，判断是否保留痕迹
				int intLenth;
				if(m_blnBeginPrintNewRecord==true) 
				{									
					#region 当前记录数组赋值
					if(m_objPrintDataArr[m_intCurrentRecord].m_intFlag != (int)enmRecordsType.WatchItem && m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr == null)
					{
						intLenth = 2;
						intRowsOfOneRecord = intLenth;
						strModifyDate = "";
						m_strValueArr=new string[intLenth][];
						m_strValueArr[0]=new string[19];
						m_strValueArr[0][0]="";
						m_strValueArr[0][1]="";
						m_strValueArr[0][2]="";
						m_strValueArr[0][3]="";
						m_strValueArr[0][4]="";
						m_strValueArr[0][5]="";
						m_strValueArr[0][6]="";
						m_strValueArr[0][7]="";
						m_strValueArr[0][8]="";
						m_strValueArr[0][9]="";
						if(m_objPrintDataArr[m_intCurrentRecord].m_objRecordContent.m_dtmCreateDate == DateTime.MaxValue)
							m_strValueArr[0][10]="合共";
						else
							m_strValueArr[0][10]="按日";
						m_strValueArr[0][11]="单项";
						m_strValueArr[0][12]="总计:";
						m_strValueArr[0][13]=m_objPrintDataArr[m_intCurrentRecord].m_objItemSummary.m_intInI_Total.ToString();
						m_strValueArr[0][14]=m_objPrintDataArr[m_intCurrentRecord].m_objItemSummary.m_intInD_Total.ToString();
						m_strValueArr[0][15]=m_objPrintDataArr[m_intCurrentRecord].m_objItemSummary.m_intOutE_Total.ToString();
						m_strValueArr[0][16]=m_objPrintDataArr[m_intCurrentRecord].m_objItemSummary.m_intOutU_Total.ToString();
						m_strValueArr[0][17]=m_objPrintDataArr[m_intCurrentRecord].m_objItemSummary.m_intOutS_Total.ToString();
						m_strValueArr[0][18]=m_objPrintDataArr[m_intCurrentRecord].m_objItemSummary.m_intOutV_Total.ToString();
					
						m_strValueArr[1]=new string[19];
						m_strValueArr[1][0]="";
						m_strValueArr[1][1]="";
						m_strValueArr[1][2]="";
						m_strValueArr[1][3]="";
						m_strValueArr[1][4]="";
						m_strValueArr[1][5]="";
						m_strValueArr[1][6]="";
						m_strValueArr[1][7]="";
						m_strValueArr[1][8]="";
						m_strValueArr[1][9]="";
						if(m_objPrintDataArr[m_intCurrentRecord].m_objRecordContent.m_dtmCreateDate == DateTime.MaxValue)
							m_strValueArr[1][10]="合共";
						else
							m_strValueArr[1][10]="按日";
						m_strValueArr[1][11]="分类";
						m_strValueArr[1][12]="总计:";
						m_strValueArr[1][13]=m_objPrintDataArr[m_intCurrentRecord].m_objItemSummary.m_intTotal_In.ToString();
						m_strValueArr[1][14]="";
						m_strValueArr[1][15]=m_objPrintDataArr[m_intCurrentRecord].m_objItemSummary.m_intTotal_Out.ToString();
						m_strValueArr[1][16]="";
						m_strValueArr[1][17]="";
						m_strValueArr[1][18]="";
						return intLenth;
					}
					else
					{
						intRowsOfOneRecord=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr.Length;
						strModifyDate=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[intRowsOfOneRecord-1].m_dtmModifyDate.ToString("yyyy-MM-dd HH:mm:ss");
						intLenth=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr.Length;
						m_strValueArr=new string[intLenth][];
						for(int k1=0;k1<intLenth;k1++)
						{
							m_strValueArr[k1]=new string[19];
							m_strValueArr[k1][0]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strTemperature;
							m_strValueArr[k1][1]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strHeartRhythm;
							m_strValueArr[k1][2]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strHeartFrequency;
							m_strValueArr[k1][3]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strPulse;
							m_strValueArr[k1][4]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strBreath;
							m_strValueArr[k1][5]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strBloodPressureS;
							m_strValueArr[k1][6]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strBloodPressureA;
							m_strValueArr[k1][7]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strPupilLeft;
							m_strValueArr[k1][8]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strPupilRight;
							m_strValueArr[k1][9]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strEchoLeft;
							m_strValueArr[k1][10]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strEchoRight;
							m_strValueArr[k1][11]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strBloodOxygenSaturation;
							m_strValueArr[k1][12]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_strBedsideBloodSugar;
							m_strValueArr[k1][13]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_intInI.ToString();
							m_strValueArr[k1][14]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_intInD.ToString();
							m_strValueArr[k1][15]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_intOutE.ToString();
							m_strValueArr[k1][16]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_intOutU.ToString();
							m_strValueArr[k1][17]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_intOutS.ToString();
							m_strValueArr[k1][18]=m_objPrintDataArr[m_intCurrentRecord].m_objTransDataArr[k1].m_intOutV.ToString();
						}
						return intLenth;
					}
					#endregion
				}
				else 
					return 0;
				#endregion
			}
			catch(Exception ex)
			{
				clsPublicFunction.ShowInformationMessageBox(ex.Message);
				return 1;
			}			
		}
		#endregion
		#endregion

		/// <summary>
		/// 获取当前病人的作废内容
		/// </summary>
		/// <param name="p_dtmRecordDate">记录日期</param>
		/// <param name="p_intFormID">窗体ID</param>
		protected override void m_mthGetDeactiveContent(DateTime p_dtmRecordDate,int p_intFormID)
		{			
			m_mthGetDeletedRecord(p_intFormID,p_dtmRecordDate);
		}

		protected override void m_mthGetDeletedRecord(int p_intRecordType,
			DateTime p_dtmCreateRecordTime)
		{	
			//获取添加记录的窗体
			frmDiseaseTrackBase frmAddNewForm = m_frmGetRecordForm(p_intRecordType); 
			frmAddNewForm.m_mthSetDeletedDiseaseTrackInfo(m_objCurrentPatient,p_dtmCreateRecordTime);
		
			m_mthShowSubForm(frmAddNewForm,p_intRecordType,false);
		}

		protected override void m_mthStartPrint()
		{
			if(m_blnDirectPrint)
			{
				m_pdcPrintDocument.Print();
			}
			else
			{
				((clsWatchItemTrackPrintTool)objPrintTool).m_mthPrintPage();
				
			}
		}

	}
}

