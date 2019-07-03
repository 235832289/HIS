using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;
using com.digitalwave.Utility .Controls ;
using HRP;


namespace iCare
{
	/// <summary>
	/// 1、如果第一次打印时间不存在，则以当前时间为准，作为是否保留修改痕迹的时间界限
	/// 2、如果第一次打印时间存在，则以第一次打印时间为准，作为是否保留修改痕迹的时间界限（以下记作PrintDateMiddle)（可以推断出，与出院时间或死亡时间无关）
	/// 3、若以[子表中的所有修改记录为数据源再根据下一条记录是否相同作为修改依据的]方法打印，则应以PrintDateMiddle作为查询子表的条件之一，仅当修改时间ModifyDate大于 PrintDateMiddle时，才提取该记录 + 小于PrintDateMiddle的记录中提取最大修改时间的一条记录。
	/// 4、若以[PrintContext.m_mthSetContextWithCorrectBefore()]的方法打印，则以PrintDateMiddle作为其中的时间参数即可。
	/// 结果：若PrintDateMiddle>DateTime.Now,则以3或4查询时，查询结果等价于只打印最新记录。
	/// 方法：若以3的方式打印，（此时一般一张单对应多条不同的CreateDate,有多个FirstPrintDate),但仅需要修改Middle Tier 中的SQL查询条件，界面及Domain层不变。（不需要在界面查询首次打印时间，仅需要打印时若为空，更新首次打印时间）
	////////若以4的方式打印，读取FirstPrintDate数组
	///本实例以3和4两种方式混合打印。
	/// </summary>
	public class frmICUIntensiveTendRecord : iCare.frmHRPBaseForm,PublicFunction,infAutoTest//(自动测试)
	{
		private System.Windows.Forms.TreeView m_trvTime;
		private System.Windows.Forms.GroupBox m_gpbLeft;
		private System.Windows.Forms.GroupBox m_gpbTop;
		private System.Drawing.Printing.PrintDocument m_printDocument1;
		private System.Windows.Forms.GroupBox m_gpbOut;
		private System.Windows.Forms.Label lblOutUTitle;
		private com.digitalwave.controls.ctlRichTextBox m_txtOutS;
		private System.Windows.Forms.Label lblOutSTitle;
		private System.Windows.Forms.Label lblOutVTitle;
		private System.Windows.Forms.Label lblOutETitle;
		private com.digitalwave.controls.ctlRichTextBox m_txtOutV;
		private com.digitalwave.controls.ctlRichTextBox m_txtOutE;
		private com.digitalwave.controls.ctlRichTextBox m_txtOutU;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lblTotalOutUTitle;
		private System.Windows.Forms.Label m_lblTotalOutU;
		private System.Windows.Forms.Label lblTotalOutSTitle;
		private System.Windows.Forms.Label m_lblTotalOutS;
		private System.Windows.Forms.Label m_lblTotalOutV;
		private System.Windows.Forms.Label lblTotalOutVTitle;
		private System.Windows.Forms.Label lblTotalOutETitle;
		private System.Windows.Forms.Label m_lblTotalOutE;
		private System.Windows.Forms.Label lblTotalInITitle;
		private System.Windows.Forms.Label m_lblTotalInI;
		private System.Windows.Forms.Label m_lblTotalInD;
		private System.Windows.Forms.Label lblTotalInDTitle;
		private System.Windows.Forms.Label m_lblTotalOut;
		private System.Windows.Forms.Label lblTotalOutTitle;
		private System.Windows.Forms.Label lblTotalInTitle;
		private System.Windows.Forms.Label m_lblTotalIn;
		private System.Windows.Forms.Label lblImportantTitle0;
		private System.Windows.Forms.Label lblImportantTitle1;
		private System.Windows.Forms.Label lblImportantTitle2;
		private System.Windows.Forms.Label lblImportantTitle3;
		private System.Windows.Forms.Label lblImportantTitle4;
		private System.Windows.Forms.Label lblImportantTitle5;
		private System.Windows.Forms.Label lblImportantTitle6;
		private System.Windows.Forms.Label lblImportantTitle7;
		private com.digitalwave.controls.ctlRichTextBox m_txtRecordContent;
		private System.Windows.Forms.Label lblSignTitle;
		private System.Windows.Forms.Label m_lblSign;
		private System.Windows.Forms.Label lblRecordContentTitle;
		private System.Windows.Forms.Label lblBreathTitle;
		private com.digitalwave.controls.ctlRichTextBox m_txtTemperature;
		private System.Windows.Forms.GroupBox m_gpbIn;
		private com.digitalwave.controls.ctlRichTextBox m_txtInD;
		private System.Windows.Forms.Label lblInDTitle;
		private com.digitalwave.controls.ctlRichTextBox m_txtInI;
		private System.Windows.Forms.Label lblInITitle;
		private com.digitalwave.Utility.Controls.ctlTimePicker m_dtpRecordTime;
		private System.Windows.Forms.GroupBox m_gpbPupil;
		private System.Windows.Forms.GroupBox m_gpbPupil_Echo;
		private com.digitalwave.controls.ctlRichTextBox m_txtEchoLeft;
		private System.Windows.Forms.Label lblLeft1;
		private com.digitalwave.controls.ctlRichTextBox m_txtEchoRight;
		private System.Windows.Forms.Label lblRight1;
		private System.Windows.Forms.GroupBox m_gpbPupil_Size;
		private com.digitalwave.controls.ctlRichTextBox m_txtPupilLeft;
		private System.Windows.Forms.Label lblPupilLeftTitle;
		private com.digitalwave.controls.ctlRichTextBox m_txtPupilRight;
		private System.Windows.Forms.Label lblPupilRightTitle;
		private com.digitalwave.controls.ctlRichTextBox m_txtBloodPressureS;
		private System.Windows.Forms.Label lblRecordTimeTitle;
		private System.Windows.Forms.MenuItem mniDoubleStrikeOutDelete;
		private System.Windows.Forms.Label lblBloodPressureTitle;
		private System.Windows.Forms.Label lblTemperatureTitle;
		private com.digitalwave.controls.ctlRichTextBox m_txtBloodPressureA;
		private System.Windows.Forms.Label lblBloodPressureTitle2;
		private com.digitalwave.controls.ctlRichTextBox m_txtPulse;
		private com.digitalwave.controls.ctlRichTextBox m_txtBreath;
		private System.Windows.Forms.Label lblPulseTitle;
		private System.Windows.Forms.ContextMenu m_cmuRichTextBoxMenu;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ColumnHeader clmStandardParamID;
		private System.Windows.Forms.ColumnHeader clmStandardParamValue;
		private System.Windows.Forms.ColumnHeader clmStandardParamID2;
		private System.Windows.Forms.ColumnHeader clmStandardParamValue2;
		private com.digitalwave.controls.ctlRichTextBox m_txtSenses;
		private System.Windows.Forms.Label lblSensesTitle;
		private System.Windows.Forms.Label lblAbsorbPhlegmDateTitle;
		private System.Windows.Forms.Label lblPhlegmAttributeTitle;
		private com.digitalwave.controls.ctlRichTextBox m_txtPhlegmAttribute;
		private System.Windows.Forms.GroupBox m_gpbPhlegm;
		private com.digitalwave.Utility.Controls.ctlTimePicker m_dtpAbsorbPhlegmDate;
		private System.Windows.Forms.ListView m_lsvWatchMachine;
		private System.Windows.Forms.ListView m_lsvBreathMachine;
		private System.ComponentModel.IContainer components = null;

		public frmICUIntensiveTendRecord()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
            //m_objBorderTool = new clsBorderTool(Color.White);
            //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{	m_lsvWatchMachine,m_lsvBreathMachine });
			
			m_lblSign.Text=MDIParent.strOperatorName;

			m_objPrintCreateDate = new clsPrintPamamDate();
			m_objPrint1 = new clsPrintParamInfo1(m_objPrintCreateDate);
			m_objPrint2 = new clsPrintParamInfo2(m_objPrintCreateDate);
			m_objPrintMonitor= new clsPrintParamInfo3(true,m_objPrintCreateDate);
			m_objPrintVentilator = new clsPrintParamInfo3(false,m_objPrintCreateDate);
			m_objPrint4 = new clsPrintParamInfo4(m_objPrintCreateDate);
			m_objPrint5 = new clsPrintParamInfo5();
			m_objPrint6 = new clsPrintParamInfo6();

			m_objPrintLineContext = new clsPrintContext(
				new clsPrintLineBase[]{
				m_objPrintCreateDate,
					m_objPrint1,
				m_objPrint2,
				m_objPrintMonitor,
				m_objPrintVentilator,
				m_objPrint4,
				m_objPrint5,
				m_objPrint6
									  });
		}
        //private com.digitalwave.Utility.Controls.clsBorderTool  m_objBorderTool;		
		private clsICUIntensiveTendRecordDomain m_objDomain=new clsICUIntensiveTendRecordDomain();
		private bool m_blnCanLikeSeaching=true;

		private clsPatient m_objCurrentPatient=null;
		string strInPatientID="";
		string strInPatientDate="";		

		private clsPrintContext m_objPrintLineContext;

		private clsPrintPamamDate m_objPrintCreateDate;
		private clsPrintParamInfo1 m_objPrint1;
		private clsPrintParamInfo2 m_objPrint2;
		private clsPrintParamInfo3 m_objPrintMonitor;
		private clsPrintParamInfo3 m_objPrintVentilator;		
		private clsPrintParamInfo4 m_objPrint4;		
		private clsPrintParamInfo5 m_objPrint5;
		private clsPrintParamInfo6 m_objPrint6;

		#region 有关打印的声明		

		//		/// <summary>
		//		/// （基于危重护理记录的）打印上下文的类
		//		/// </summary>
		//		private class clsPrintContext_WatchItemRecord
		//		{
		//			public clsPrintRichTextContext m_objPrintContext_RecordContent;
		//			public clsPrintRichTextContext m_objPrintContext_Temperature;
		//			public clsPrintRichTextContext m_objPrintContext_Breath;
		//			public clsPrintRichTextContext m_objPrintContext_HeartRhythm;
		//			public clsPrintRichTextContext m_objPrintContext_HeartFrequency;
		//			public clsPrintRichTextContext m_objPrintContext_BloodOxygenSaturation;
		//			public clsPrintRichTextContext m_objPrintContext_BedsideBloodSugar;
		//
		//			public clsPrintRichTextContext m_objPrintContext_Pulse;
		//			public clsPrintRichTextContext m_objPrintContext_BloodPressureS;
		//			public clsPrintRichTextContext m_objPrintContext_BloodPressureA;
		//			public clsPrintRichTextContext m_objPrintContext_PupilLeft;
		//			public clsPrintRichTextContext m_objPrintContext_PupilRight;
		//			public clsPrintRichTextContext m_objPrintContext_EchoLeft;
		//			public clsPrintRichTextContext m_objPrintContext_EchoRight;
		//			/// <summary>
		//			/// 出入量的内容部分，与出入量其他部分共6个单元并列输出，若内容为空，则不输出
		//			/// </summary>
		//			public clsPrintRichTextContext m_objPrintContext_InD;
		//			/// <summary>
		//			/// 是否需要打印，True:需要（当内容为空或前一页已经打印时，不再需要打印）
		//			/// </summary>
		//			public bool m_blnNeedPrint_InD;
		//			/// <summary>
		//			/// 出入量的内容部分，与出入量其他部分共6个单元并列输出，若内容为空，则不输出
		//			/// </summary>
		//			public clsPrintRichTextContext m_objPrintContext_InI;
		//			public bool m_blnNeedPrint_InI;
		//			/// <summary>
		//			/// 出入量的内容部分，与出入量其他部分共6个单元并列输出，若内容为空，则不输出
		//			/// </summary>
		//			public clsPrintRichTextContext m_objPrintContext_OutU;
		//			public bool m_blnNeedPrint_OutU;
		//			/// <summary>
		//			/// 出入量的内容部分，与出入量其他部分共6个单元并列输出，若内容为空，则不输出
		//			/// </summary>
		//			public clsPrintRichTextContext m_objPrintContext_OutS;
		//			public bool m_blnNeedPrint_OutS;
		//			/// <summary>
		//			/// 出入量的内容部分，与出入量其他部分共6个单元并列输出，若内容为空，则不输出
		//			/// </summary>
		//			public clsPrintRichTextContext m_objPrintContext_OutV;
		//			public bool m_blnNeedPrint_OutV;
		//			/// <summary>
		//			/// 出入量的内容部分，与出入量其他部分共6个单元并列输出，若内容为空，则不输出
		//			/// </summary>
		//			public clsPrintRichTextContext m_objPrintContext_OutE;
		//			public bool m_blnNeedPrint_OutE;
		//
		//			
		//		} 
		//		private clsPrintContext_WatchItemRecord m_objPrintContext;
		//		/// <summary>
		//		/// 每行显示的汉字（病程记录）或字母（其他）的数目
		//		/// </summary>
		//		private class clsPrintLenth_IntensiveTendRecord
		//		{
		//			public int m_intPrintLenth_HeartRhythm;
		//			public int m_intPrintLenth_HeartFrequency;
		//			public int m_intPrintLenth_BloodOxygenSaturation;
		//			public int m_intPrintLenth_BedsideBloodSugar;
		//			public int m_intPrintLenth_Temperature;
		//			public int m_intPrintLenth_Breath;
		//			public int m_intPrintLenth_Pulse;
		//			public int m_intPrintLenth_BloodPressure;			
		//			public int m_intPrintLenth_Pupil;	//瞳孔（大小）		
		//			public int m_intPrintLenth_Echo;	//反射		
		//			public int m_intPrintLenth_In;//摄入
		//			public int m_intPrintLenth_Out;	//排出		
		//		}
		//		private clsPrintLenth_IntensiveTendRecord m_objPrintLenth;		
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
		//private int m_intNowPage=1;
		/// <summary>
		/// 当前打印的记录的序号
		/// </summary>
		private int m_intCurrentRecord=0;  
		/// <summary>
		/// 旧记录打完,准备打印一条新记录
		/// </summary>
		bool m_blnBeginPrintNewRecord=true;		
		/// <summary>
		/// 要打印的所有的护理记录
		/// </summary>
		//private clsIntensiveTendRecord [] objGeneralTendRecordForPrint=null;
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
			LeftX = 40,
			/// <summary>
			/// 格子的右端
			/// </summary>
			RightX = 820-40,
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
			/// 第二条间隔线(X)，体温/机械参数/病程记录（起点线）
			/// </summary>
			ColumnsMark2=135,

			/// <summary>
			/// 第3条间隔线(X)，脉搏（起点线）
			/// </summary>
			ColumnsMark3=180,

			/// <summary>
			/// 呼吸 次/分（起点线）
			/// </summary>
			ColumnsMark4=215,

			/// <summary>
			/// 血压（起点线）
			/// </summary>
			ColumnsMark5=250,			

			/// <summary>
			/// 瞳孔大小 左（起点线）
			/// </summary>
			ColumnsMark6=320,

			/// <summary>
			/// 瞳孔大小 右（起点线）
			/// </summary>
			ColumnsMark7=360,

			/// <summary>
			/// 反射 左（起点线）
			/// </summary>
			ColumnsMark8=400,

			/// <summary>
			/// 反射 右（起点线）
			/// </summary>
			ColumnsMark9=450,

			/// <summary>
			/// 输液量（起点线）
			/// </summary>
			ColumnsMark10=500,

			/// <summary>
			/// 进食量（起点线）
			/// </summary>
			ColumnsMark11=540,

			/// <summary>
			/// 引流量（起点线）
			/// </summary>
			ColumnsMark12=580,

			/// <summary>
			/// 尿 量（起点线）
			/// </summary>
			ColumnsMark13=620,

			/// <summary>
			/// 大 便（起点线）
			/// </summary>
			ColumnsMark14=660,

			/// <summary>
			/// 呕吐物（起点线）
			/// </summary>
			ColumnsMark15=700,

			/// <summary>
			/// 签名（起点线）
			/// </summary>
			ColumnsMark_Name=680,	
			
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
						m_fReturnPoint = new PointF(245f,100f);
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
						m_fReturnPoint = new PointF(350f,150f);
						break;
					case (int)enmItemDefination.Dept_Name :
						m_fReturnPoint = new PointF(400f,150f);
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
            this.m_trvTime = new System.Windows.Forms.TreeView();
            this.m_gpbLeft = new System.Windows.Forms.GroupBox();
            this.m_gpbTop = new System.Windows.Forms.GroupBox();
            this.m_printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.m_gpbOut = new System.Windows.Forms.GroupBox();
            this.lblOutUTitle = new System.Windows.Forms.Label();
            this.m_txtOutS = new com.digitalwave.controls.ctlRichTextBox();
            this.lblOutSTitle = new System.Windows.Forms.Label();
            this.lblOutVTitle = new System.Windows.Forms.Label();
            this.lblOutETitle = new System.Windows.Forms.Label();
            this.m_txtOutV = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtOutE = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtOutU = new com.digitalwave.controls.ctlRichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTotalOutUTitle = new System.Windows.Forms.Label();
            this.m_lblTotalOutU = new System.Windows.Forms.Label();
            this.lblTotalOutSTitle = new System.Windows.Forms.Label();
            this.m_lblTotalOutS = new System.Windows.Forms.Label();
            this.m_lblTotalOutV = new System.Windows.Forms.Label();
            this.lblTotalOutVTitle = new System.Windows.Forms.Label();
            this.lblTotalOutETitle = new System.Windows.Forms.Label();
            this.m_lblTotalOutE = new System.Windows.Forms.Label();
            this.lblTotalInITitle = new System.Windows.Forms.Label();
            this.m_lblTotalInI = new System.Windows.Forms.Label();
            this.m_lblTotalInD = new System.Windows.Forms.Label();
            this.lblTotalInDTitle = new System.Windows.Forms.Label();
            this.m_lblTotalOut = new System.Windows.Forms.Label();
            this.lblTotalOutTitle = new System.Windows.Forms.Label();
            this.lblTotalInTitle = new System.Windows.Forms.Label();
            this.m_lblTotalIn = new System.Windows.Forms.Label();
            this.lblImportantTitle0 = new System.Windows.Forms.Label();
            this.lblImportantTitle1 = new System.Windows.Forms.Label();
            this.lblImportantTitle2 = new System.Windows.Forms.Label();
            this.lblImportantTitle3 = new System.Windows.Forms.Label();
            this.lblImportantTitle4 = new System.Windows.Forms.Label();
            this.lblImportantTitle5 = new System.Windows.Forms.Label();
            this.lblImportantTitle6 = new System.Windows.Forms.Label();
            this.lblImportantTitle7 = new System.Windows.Forms.Label();
            this.m_txtRecordContent = new com.digitalwave.controls.ctlRichTextBox();
            this.lblSignTitle = new System.Windows.Forms.Label();
            this.m_lblSign = new System.Windows.Forms.Label();
            this.lblRecordContentTitle = new System.Windows.Forms.Label();
            this.lblBreathTitle = new System.Windows.Forms.Label();
            this.m_txtTemperature = new com.digitalwave.controls.ctlRichTextBox();
            this.m_gpbIn = new System.Windows.Forms.GroupBox();
            this.m_txtInD = new com.digitalwave.controls.ctlRichTextBox();
            this.lblInDTitle = new System.Windows.Forms.Label();
            this.m_txtInI = new com.digitalwave.controls.ctlRichTextBox();
            this.lblInITitle = new System.Windows.Forms.Label();
            this.m_dtpRecordTime = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.m_gpbPupil = new System.Windows.Forms.GroupBox();
            this.m_gpbPupil_Echo = new System.Windows.Forms.GroupBox();
            this.m_txtEchoLeft = new com.digitalwave.controls.ctlRichTextBox();
            this.lblLeft1 = new System.Windows.Forms.Label();
            this.m_txtEchoRight = new com.digitalwave.controls.ctlRichTextBox();
            this.lblRight1 = new System.Windows.Forms.Label();
            this.m_gpbPupil_Size = new System.Windows.Forms.GroupBox();
            this.m_txtPupilLeft = new com.digitalwave.controls.ctlRichTextBox();
            this.lblPupilLeftTitle = new System.Windows.Forms.Label();
            this.m_txtPupilRight = new com.digitalwave.controls.ctlRichTextBox();
            this.lblPupilRightTitle = new System.Windows.Forms.Label();
            this.m_txtBloodPressureS = new com.digitalwave.controls.ctlRichTextBox();
            this.lblRecordTimeTitle = new System.Windows.Forms.Label();
            this.mniDoubleStrikeOutDelete = new System.Windows.Forms.MenuItem();
            this.lblBloodPressureTitle = new System.Windows.Forms.Label();
            this.lblTemperatureTitle = new System.Windows.Forms.Label();
            this.m_txtBloodPressureA = new com.digitalwave.controls.ctlRichTextBox();
            this.lblBloodPressureTitle2 = new System.Windows.Forms.Label();
            this.m_txtPulse = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtBreath = new com.digitalwave.controls.ctlRichTextBox();
            this.lblPulseTitle = new System.Windows.Forms.Label();
            this.m_cmuRichTextBoxMenu = new System.Windows.Forms.ContextMenu();
            this.m_lsvWatchMachine = new System.Windows.Forms.ListView();
            this.clmStandardParamID = new System.Windows.Forms.ColumnHeader();
            this.clmStandardParamValue = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_lsvBreathMachine = new System.Windows.Forms.ListView();
            this.clmStandardParamID2 = new System.Windows.Forms.ColumnHeader();
            this.clmStandardParamValue2 = new System.Windows.Forms.ColumnHeader();
            this.m_txtSenses = new com.digitalwave.controls.ctlRichTextBox();
            this.lblSensesTitle = new System.Windows.Forms.Label();
            this.lblAbsorbPhlegmDateTitle = new System.Windows.Forms.Label();
            this.lblPhlegmAttributeTitle = new System.Windows.Forms.Label();
            this.m_txtPhlegmAttribute = new com.digitalwave.controls.ctlRichTextBox();
            this.m_gpbPhlegm = new System.Windows.Forms.GroupBox();
            this.m_dtpAbsorbPhlegmDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.m_gpbOut.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.m_gpbIn.SuspendLayout();
            this.m_gpbPupil.SuspendLayout();
            this.m_gpbPupil_Echo.SuspendLayout();
            this.m_gpbPupil_Size.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.m_gpbPhlegm.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(588, 60);
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(708, 60);
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(236, 60);
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(772, 60);
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(372, 60);
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(532, 60);
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(644, 60);
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(40, 60);
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(844, 80);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(132, 105);
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(844, 56);
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(424, 56);
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(288, 56);
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(92, 56);
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(424, 84);
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(288, 84);
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(92, 24);
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(40, 32);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Bold);
            this.m_lblForTitle.Location = new System.Drawing.Point(272, 12);
            this.m_lblForTitle.Size = new System.Drawing.Size(520, 40);
            this.m_lblForTitle.Text = "ICU 危 重 患 者 护 理 记 录";
            this.m_lblForTitle.Visible = true;
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(895, 17);
            // 
            // m_trvTime
            // 
            this.m_trvTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_trvTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_trvTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_trvTime.ForeColor = System.Drawing.SystemColors.Window;
            this.m_trvTime.HideSelection = false;
            this.m_trvTime.ItemHeight = 18;
            this.m_trvTime.Location = new System.Drawing.Point(0, 96);
            this.m_trvTime.Name = "m_trvTime";
            this.m_trvTime.Size = new System.Drawing.Size(228, 780);
            this.m_trvTime.TabIndex = 10;
            this.m_trvTime.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_trvTime_AfterSelect);
            // 
            // m_gpbLeft
            // 
            this.m_gpbLeft.BackColor = System.Drawing.SystemColors.Window;
            this.m_gpbLeft.Location = new System.Drawing.Point(228, 96);
            this.m_gpbLeft.Name = "m_gpbLeft";
            this.m_gpbLeft.Size = new System.Drawing.Size(1, 800);
            this.m_gpbLeft.TabIndex = 6073;
            this.m_gpbLeft.TabStop = false;
            // 
            // m_gpbTop
            // 
            this.m_gpbTop.BackColor = System.Drawing.SystemColors.Window;
            this.m_gpbTop.Location = new System.Drawing.Point(0, 96);
            this.m_gpbTop.Name = "m_gpbTop";
            this.m_gpbTop.Size = new System.Drawing.Size(1000, 1);
            this.m_gpbTop.TabIndex = 6074;
            this.m_gpbTop.TabStop = false;
            // 
            // m_printDocument1
            // 
            this.m_printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // m_gpbOut
            // 
            this.m_gpbOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_gpbOut.Controls.Add(this.lblOutUTitle);
            this.m_gpbOut.Controls.Add(this.m_txtOutS);
            this.m_gpbOut.Controls.Add(this.lblOutSTitle);
            this.m_gpbOut.Controls.Add(this.lblOutVTitle);
            this.m_gpbOut.Controls.Add(this.lblOutETitle);
            this.m_gpbOut.Controls.Add(this.m_txtOutV);
            this.m_gpbOut.Controls.Add(this.m_txtOutE);
            this.m_gpbOut.Controls.Add(this.m_txtOutU);
            this.m_gpbOut.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_gpbOut.ForeColor = System.Drawing.SystemColors.Window;
            this.m_gpbOut.Location = new System.Drawing.Point(552, 280);
            this.m_gpbOut.Name = "m_gpbOut";
            this.m_gpbOut.Size = new System.Drawing.Size(428, 100);
            this.m_gpbOut.TabIndex = 40;
            this.m_gpbOut.TabStop = false;
            this.m_gpbOut.Text = "排出量(ml)";
            // 
            // lblOutUTitle
            // 
            this.lblOutUTitle.AutoSize = true;
            this.lblOutUTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblOutUTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOutUTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.lblOutUTitle.Location = new System.Drawing.Point(12, 32);
            this.lblOutUTitle.Name = "lblOutUTitle";
            this.lblOutUTitle.Size = new System.Drawing.Size(32, 16);
            this.lblOutUTitle.TabIndex = 507;
            this.lblOutUTitle.Text = "尿:";
            // 
            // m_txtOutS
            // 
            this.m_txtOutS.AccessibleDescription = "大便";
            this.m_txtOutS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtOutS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtOutS.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOutS.ForeColor = System.Drawing.Color.White;
            this.m_txtOutS.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOutS.Location = new System.Drawing.Point(64, 68);
            this.m_txtOutS.m_BlnIgnoreUserInfo = false;
            this.m_txtOutS.m_BlnPartControl = false;
            this.m_txtOutS.m_BlnReadOnly = false;
            this.m_txtOutS.m_BlnUnderLineDST = false;
            this.m_txtOutS.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOutS.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOutS.m_IntCanModifyTime = 6;
            this.m_txtOutS.m_IntPartControlLength = 0;
            this.m_txtOutS.m_IntPartControlStartIndex = 0;
            this.m_txtOutS.m_StrUserID = "";
            this.m_txtOutS.m_StrUserName = "";
            this.m_txtOutS.Multiline = false;
            this.m_txtOutS.Name = "m_txtOutS";
            this.m_txtOutS.Size = new System.Drawing.Size(136, 24);
            this.m_txtOutS.TabIndex = 42;
            this.m_txtOutS.Text = "";
            this.m_txtOutS.TextChanged += new System.EventHandler(this.m_mthInOutQty_Validated);
            // 
            // lblOutSTitle
            // 
            this.lblOutSTitle.AutoSize = true;
            this.lblOutSTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblOutSTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOutSTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.lblOutSTitle.Location = new System.Drawing.Point(12, 68);
            this.lblOutSTitle.Name = "lblOutSTitle";
            this.lblOutSTitle.Size = new System.Drawing.Size(48, 16);
            this.lblOutSTitle.TabIndex = 507;
            this.lblOutSTitle.Text = "大便:";
            // 
            // lblOutVTitle
            // 
            this.lblOutVTitle.AutoSize = true;
            this.lblOutVTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblOutVTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOutVTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.lblOutVTitle.Location = new System.Drawing.Point(212, 32);
            this.lblOutVTitle.Name = "lblOutVTitle";
            this.lblOutVTitle.Size = new System.Drawing.Size(64, 16);
            this.lblOutVTitle.TabIndex = 507;
            this.lblOutVTitle.Text = "呕吐物:";
            // 
            // lblOutETitle
            // 
            this.lblOutETitle.AutoSize = true;
            this.lblOutETitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblOutETitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOutETitle.ForeColor = System.Drawing.SystemColors.Window;
            this.lblOutETitle.Location = new System.Drawing.Point(212, 68);
            this.lblOutETitle.Name = "lblOutETitle";
            this.lblOutETitle.Size = new System.Drawing.Size(64, 16);
            this.lblOutETitle.TabIndex = 507;
            this.lblOutETitle.Text = "引流液:";
            // 
            // m_txtOutV
            // 
            this.m_txtOutV.AccessibleDescription = "呕吐物";
            this.m_txtOutV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtOutV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtOutV.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOutV.ForeColor = System.Drawing.Color.White;
            this.m_txtOutV.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOutV.Location = new System.Drawing.Point(284, 32);
            this.m_txtOutV.m_BlnIgnoreUserInfo = false;
            this.m_txtOutV.m_BlnPartControl = false;
            this.m_txtOutV.m_BlnReadOnly = false;
            this.m_txtOutV.m_BlnUnderLineDST = false;
            this.m_txtOutV.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOutV.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOutV.m_IntCanModifyTime = 6;
            this.m_txtOutV.m_IntPartControlLength = 0;
            this.m_txtOutV.m_IntPartControlStartIndex = 0;
            this.m_txtOutV.m_StrUserID = "";
            this.m_txtOutV.m_StrUserName = "";
            this.m_txtOutV.Multiline = false;
            this.m_txtOutV.Name = "m_txtOutV";
            this.m_txtOutV.Size = new System.Drawing.Size(136, 24);
            this.m_txtOutV.TabIndex = 43;
            this.m_txtOutV.Text = "";
            this.m_txtOutV.TextChanged += new System.EventHandler(this.m_mthInOutQty_Validated);
            // 
            // m_txtOutE
            // 
            this.m_txtOutE.AccessibleDescription = "引流液";
            this.m_txtOutE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtOutE.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtOutE.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOutE.ForeColor = System.Drawing.Color.White;
            this.m_txtOutE.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOutE.Location = new System.Drawing.Point(284, 68);
            this.m_txtOutE.m_BlnIgnoreUserInfo = false;
            this.m_txtOutE.m_BlnPartControl = false;
            this.m_txtOutE.m_BlnReadOnly = false;
            this.m_txtOutE.m_BlnUnderLineDST = false;
            this.m_txtOutE.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOutE.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOutE.m_IntCanModifyTime = 6;
            this.m_txtOutE.m_IntPartControlLength = 0;
            this.m_txtOutE.m_IntPartControlStartIndex = 0;
            this.m_txtOutE.m_StrUserID = "";
            this.m_txtOutE.m_StrUserName = "";
            this.m_txtOutE.Multiline = false;
            this.m_txtOutE.Name = "m_txtOutE";
            this.m_txtOutE.Size = new System.Drawing.Size(136, 24);
            this.m_txtOutE.TabIndex = 44;
            this.m_txtOutE.Text = "";
            this.m_txtOutE.TextChanged += new System.EventHandler(this.m_mthInOutQty_Validated);
            // 
            // m_txtOutU
            // 
            this.m_txtOutU.AccessibleDescription = "尿";
            this.m_txtOutU.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtOutU.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtOutU.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOutU.ForeColor = System.Drawing.Color.White;
            this.m_txtOutU.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOutU.Location = new System.Drawing.Point(64, 32);
            this.m_txtOutU.m_BlnIgnoreUserInfo = false;
            this.m_txtOutU.m_BlnPartControl = false;
            this.m_txtOutU.m_BlnReadOnly = false;
            this.m_txtOutU.m_BlnUnderLineDST = false;
            this.m_txtOutU.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOutU.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOutU.m_IntCanModifyTime = 6;
            this.m_txtOutU.m_IntPartControlLength = 0;
            this.m_txtOutU.m_IntPartControlStartIndex = 0;
            this.m_txtOutU.m_StrUserID = "";
            this.m_txtOutU.m_StrUserName = "";
            this.m_txtOutU.Multiline = false;
            this.m_txtOutU.Name = "m_txtOutU";
            this.m_txtOutU.Size = new System.Drawing.Size(136, 24);
            this.m_txtOutU.TabIndex = 41;
            this.m_txtOutU.Text = "";
            this.m_txtOutU.TextChanged += new System.EventHandler(this.m_mthInOutQty_Validated);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(596, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 8);
            this.label2.TabIndex = 6058;
            this.label2.Text = "°";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.groupBox1.Controls.Add(this.lblTotalOutUTitle);
            this.groupBox1.Controls.Add(this.m_lblTotalOutU);
            this.groupBox1.Controls.Add(this.lblTotalOutSTitle);
            this.groupBox1.Controls.Add(this.m_lblTotalOutS);
            this.groupBox1.Controls.Add(this.m_lblTotalOutV);
            this.groupBox1.Controls.Add(this.lblTotalOutVTitle);
            this.groupBox1.Controls.Add(this.lblTotalOutETitle);
            this.groupBox1.Controls.Add(this.m_lblTotalOutE);
            this.groupBox1.Controls.Add(this.lblTotalInITitle);
            this.groupBox1.Controls.Add(this.m_lblTotalInI);
            this.groupBox1.Controls.Add(this.m_lblTotalInD);
            this.groupBox1.Controls.Add(this.lblTotalInDTitle);
            this.groupBox1.Controls.Add(this.m_lblTotalOut);
            this.groupBox1.Controls.Add(this.lblTotalOutTitle);
            this.groupBox1.Controls.Add(this.lblTotalInTitle);
            this.groupBox1.Controls.Add(this.m_lblTotalIn);
            this.groupBox1.Controls.Add(this.lblImportantTitle0);
            this.groupBox1.Controls.Add(this.lblImportantTitle1);
            this.groupBox1.Controls.Add(this.lblImportantTitle2);
            this.groupBox1.Controls.Add(this.lblImportantTitle3);
            this.groupBox1.Controls.Add(this.lblImportantTitle4);
            this.groupBox1.Controls.Add(this.lblImportantTitle5);
            this.groupBox1.Controls.Add(this.lblImportantTitle6);
            this.groupBox1.Controls.Add(this.lblImportantTitle7);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.groupBox1.Location = new System.Drawing.Point(240, 392);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(744, 96);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "统计(ml)------出入量代码:U--尿 S--大便 V--呕吐物 E--引流液 D--进食 I--输液";
            // 
            // lblTotalOutUTitle
            // 
            this.lblTotalOutUTitle.AutoSize = true;
            this.lblTotalOutUTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblTotalOutUTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalOutUTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.lblTotalOutUTitle.Location = new System.Drawing.Point(8, 60);
            this.lblTotalOutUTitle.Name = "lblTotalOutUTitle";
            this.lblTotalOutUTitle.Size = new System.Drawing.Size(72, 16);
            this.lblTotalOutUTitle.TabIndex = 520;
            this.lblTotalOutUTitle.Text = "总出量U:";
            // 
            // m_lblTotalOutU
            // 
            this.m_lblTotalOutU.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_lblTotalOutU.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblTotalOutU.ForeColor = System.Drawing.SystemColors.Window;
            this.m_lblTotalOutU.Location = new System.Drawing.Point(84, 60);
            this.m_lblTotalOutU.Name = "m_lblTotalOutU";
            this.m_lblTotalOutU.Size = new System.Drawing.Size(62, 19);
            this.m_lblTotalOutU.TabIndex = 517;
            this.m_lblTotalOutU.Text = "0";
            // 
            // lblTotalOutSTitle
            // 
            this.lblTotalOutSTitle.AutoSize = true;
            this.lblTotalOutSTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblTotalOutSTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalOutSTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.lblTotalOutSTitle.Location = new System.Drawing.Point(156, 60);
            this.lblTotalOutSTitle.Name = "lblTotalOutSTitle";
            this.lblTotalOutSTitle.Size = new System.Drawing.Size(72, 16);
            this.lblTotalOutSTitle.TabIndex = 518;
            this.lblTotalOutSTitle.Text = "总出量S:";
            // 
            // m_lblTotalOutS
            // 
            this.m_lblTotalOutS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_lblTotalOutS.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblTotalOutS.ForeColor = System.Drawing.SystemColors.Window;
            this.m_lblTotalOutS.Location = new System.Drawing.Point(232, 60);
            this.m_lblTotalOutS.Name = "m_lblTotalOutS";
            this.m_lblTotalOutS.Size = new System.Drawing.Size(62, 19);
            this.m_lblTotalOutS.TabIndex = 523;
            this.m_lblTotalOutS.Text = "0";
            // 
            // m_lblTotalOutV
            // 
            this.m_lblTotalOutV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_lblTotalOutV.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblTotalOutV.ForeColor = System.Drawing.SystemColors.Window;
            this.m_lblTotalOutV.Location = new System.Drawing.Point(380, 60);
            this.m_lblTotalOutV.Name = "m_lblTotalOutV";
            this.m_lblTotalOutV.Size = new System.Drawing.Size(62, 19);
            this.m_lblTotalOutV.TabIndex = 524;
            this.m_lblTotalOutV.Text = "0";
            // 
            // lblTotalOutVTitle
            // 
            this.lblTotalOutVTitle.AutoSize = true;
            this.lblTotalOutVTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblTotalOutVTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalOutVTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.lblTotalOutVTitle.Location = new System.Drawing.Point(304, 60);
            this.lblTotalOutVTitle.Name = "lblTotalOutVTitle";
            this.lblTotalOutVTitle.Size = new System.Drawing.Size(72, 16);
            this.lblTotalOutVTitle.TabIndex = 521;
            this.lblTotalOutVTitle.Text = "总出量V:";
            // 
            // lblTotalOutETitle
            // 
            this.lblTotalOutETitle.AutoSize = true;
            this.lblTotalOutETitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblTotalOutETitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalOutETitle.ForeColor = System.Drawing.SystemColors.Window;
            this.lblTotalOutETitle.Location = new System.Drawing.Point(452, 60);
            this.lblTotalOutETitle.Name = "lblTotalOutETitle";
            this.lblTotalOutETitle.Size = new System.Drawing.Size(72, 16);
            this.lblTotalOutETitle.TabIndex = 522;
            this.lblTotalOutETitle.Text = "总出量E:";
            // 
            // m_lblTotalOutE
            // 
            this.m_lblTotalOutE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_lblTotalOutE.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblTotalOutE.ForeColor = System.Drawing.SystemColors.Window;
            this.m_lblTotalOutE.Location = new System.Drawing.Point(528, 60);
            this.m_lblTotalOutE.Name = "m_lblTotalOutE";
            this.m_lblTotalOutE.Size = new System.Drawing.Size(62, 19);
            this.m_lblTotalOutE.TabIndex = 516;
            this.m_lblTotalOutE.Text = "0";
            // 
            // lblTotalInITitle
            // 
            this.lblTotalInITitle.AutoSize = true;
            this.lblTotalInITitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblTotalInITitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalInITitle.ForeColor = System.Drawing.SystemColors.Window;
            this.lblTotalInITitle.Location = new System.Drawing.Point(156, 24);
            this.lblTotalInITitle.Name = "lblTotalInITitle";
            this.lblTotalInITitle.Size = new System.Drawing.Size(72, 16);
            this.lblTotalInITitle.TabIndex = 510;
            this.lblTotalInITitle.Text = "总入量I:";
            // 
            // m_lblTotalInI
            // 
            this.m_lblTotalInI.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_lblTotalInI.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblTotalInI.ForeColor = System.Drawing.SystemColors.Window;
            this.m_lblTotalInI.Location = new System.Drawing.Point(232, 24);
            this.m_lblTotalInI.Name = "m_lblTotalInI";
            this.m_lblTotalInI.Size = new System.Drawing.Size(62, 19);
            this.m_lblTotalInI.TabIndex = 511;
            this.m_lblTotalInI.Text = "0";
            // 
            // m_lblTotalInD
            // 
            this.m_lblTotalInD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_lblTotalInD.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblTotalInD.ForeColor = System.Drawing.SystemColors.Window;
            this.m_lblTotalInD.Location = new System.Drawing.Point(84, 24);
            this.m_lblTotalInD.Name = "m_lblTotalInD";
            this.m_lblTotalInD.Size = new System.Drawing.Size(62, 19);
            this.m_lblTotalInD.TabIndex = 508;
            this.m_lblTotalInD.Text = "0";
            // 
            // lblTotalInDTitle
            // 
            this.lblTotalInDTitle.AutoSize = true;
            this.lblTotalInDTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblTotalInDTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalInDTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.lblTotalInDTitle.Location = new System.Drawing.Point(8, 24);
            this.lblTotalInDTitle.Name = "lblTotalInDTitle";
            this.lblTotalInDTitle.Size = new System.Drawing.Size(72, 16);
            this.lblTotalInDTitle.TabIndex = 509;
            this.lblTotalInDTitle.Text = "总入量D:";
            // 
            // m_lblTotalOut
            // 
            this.m_lblTotalOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_lblTotalOut.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblTotalOut.ForeColor = System.Drawing.SystemColors.Window;
            this.m_lblTotalOut.Location = new System.Drawing.Point(668, 60);
            this.m_lblTotalOut.Name = "m_lblTotalOut";
            this.m_lblTotalOut.Size = new System.Drawing.Size(72, 19);
            this.m_lblTotalOut.TabIndex = 514;
            this.m_lblTotalOut.Text = "0";
            // 
            // lblTotalOutTitle
            // 
            this.lblTotalOutTitle.AutoSize = true;
            this.lblTotalOutTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblTotalOutTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalOutTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.lblTotalOutTitle.Location = new System.Drawing.Point(600, 60);
            this.lblTotalOutTitle.Name = "lblTotalOutTitle";
            this.lblTotalOutTitle.Size = new System.Drawing.Size(64, 16);
            this.lblTotalOutTitle.TabIndex = 515;
            this.lblTotalOutTitle.Text = "总出量:";
            // 
            // lblTotalInTitle
            // 
            this.lblTotalInTitle.AutoSize = true;
            this.lblTotalInTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblTotalInTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalInTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.lblTotalInTitle.Location = new System.Drawing.Point(304, 24);
            this.lblTotalInTitle.Name = "lblTotalInTitle";
            this.lblTotalInTitle.Size = new System.Drawing.Size(64, 16);
            this.lblTotalInTitle.TabIndex = 512;
            this.lblTotalInTitle.Text = "总入量:";
            // 
            // m_lblTotalIn
            // 
            this.m_lblTotalIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_lblTotalIn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblTotalIn.ForeColor = System.Drawing.SystemColors.Window;
            this.m_lblTotalIn.Location = new System.Drawing.Point(372, 24);
            this.m_lblTotalIn.Name = "m_lblTotalIn";
            this.m_lblTotalIn.Size = new System.Drawing.Size(70, 19);
            this.m_lblTotalIn.TabIndex = 513;
            this.m_lblTotalIn.Text = "0";
            // 
            // lblImportantTitle0
            // 
            this.lblImportantTitle0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblImportantTitle0.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblImportantTitle0.ForeColor = System.Drawing.Color.Red;
            this.lblImportantTitle0.Location = new System.Drawing.Point(76, 36);
            this.lblImportantTitle0.Name = "lblImportantTitle0";
            this.lblImportantTitle0.Size = new System.Drawing.Size(72, 20);
            this.lblImportantTitle0.TabIndex = 525;
            this.lblImportantTitle0.Text = "=====";
            // 
            // lblImportantTitle1
            // 
            this.lblImportantTitle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblImportantTitle1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblImportantTitle1.ForeColor = System.Drawing.Color.Red;
            this.lblImportantTitle1.Location = new System.Drawing.Point(224, 36);
            this.lblImportantTitle1.Name = "lblImportantTitle1";
            this.lblImportantTitle1.Size = new System.Drawing.Size(72, 20);
            this.lblImportantTitle1.TabIndex = 525;
            this.lblImportantTitle1.Text = "======";
            // 
            // lblImportantTitle2
            // 
            this.lblImportantTitle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblImportantTitle2.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblImportantTitle2.ForeColor = System.Drawing.Color.Red;
            this.lblImportantTitle2.Location = new System.Drawing.Point(368, 36);
            this.lblImportantTitle2.Name = "lblImportantTitle2";
            this.lblImportantTitle2.Size = new System.Drawing.Size(72, 20);
            this.lblImportantTitle2.TabIndex = 525;
            this.lblImportantTitle2.Text = "======";
            // 
            // lblImportantTitle3
            // 
            this.lblImportantTitle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblImportantTitle3.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblImportantTitle3.ForeColor = System.Drawing.Color.Red;
            this.lblImportantTitle3.Location = new System.Drawing.Point(80, 72);
            this.lblImportantTitle3.Name = "lblImportantTitle3";
            this.lblImportantTitle3.Size = new System.Drawing.Size(72, 20);
            this.lblImportantTitle3.TabIndex = 525;
            this.lblImportantTitle3.Text = "======";
            // 
            // lblImportantTitle4
            // 
            this.lblImportantTitle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblImportantTitle4.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblImportantTitle4.ForeColor = System.Drawing.Color.Red;
            this.lblImportantTitle4.Location = new System.Drawing.Point(224, 72);
            this.lblImportantTitle4.Name = "lblImportantTitle4";
            this.lblImportantTitle4.Size = new System.Drawing.Size(72, 20);
            this.lblImportantTitle4.TabIndex = 525;
            this.lblImportantTitle4.Text = "======";
            // 
            // lblImportantTitle5
            // 
            this.lblImportantTitle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblImportantTitle5.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblImportantTitle5.ForeColor = System.Drawing.Color.Red;
            this.lblImportantTitle5.Location = new System.Drawing.Point(368, 72);
            this.lblImportantTitle5.Name = "lblImportantTitle5";
            this.lblImportantTitle5.Size = new System.Drawing.Size(72, 20);
            this.lblImportantTitle5.TabIndex = 525;
            this.lblImportantTitle5.Text = "======";
            // 
            // lblImportantTitle6
            // 
            this.lblImportantTitle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblImportantTitle6.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblImportantTitle6.ForeColor = System.Drawing.Color.Red;
            this.lblImportantTitle6.Location = new System.Drawing.Point(524, 72);
            this.lblImportantTitle6.Name = "lblImportantTitle6";
            this.lblImportantTitle6.Size = new System.Drawing.Size(72, 20);
            this.lblImportantTitle6.TabIndex = 525;
            this.lblImportantTitle6.Text = "======";
            // 
            // lblImportantTitle7
            // 
            this.lblImportantTitle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblImportantTitle7.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblImportantTitle7.ForeColor = System.Drawing.Color.Red;
            this.lblImportantTitle7.Location = new System.Drawing.Point(664, 72);
            this.lblImportantTitle7.Name = "lblImportantTitle7";
            this.lblImportantTitle7.Size = new System.Drawing.Size(72, 20);
            this.lblImportantTitle7.TabIndex = 525;
            this.lblImportantTitle7.Text = "======";
            // 
            // m_txtRecordContent
            // 
            this.m_txtRecordContent.AccessibleDescription = "病程记录";
            this.m_txtRecordContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtRecordContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtRecordContent.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtRecordContent.ForeColor = System.Drawing.Color.White;
            this.m_txtRecordContent.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtRecordContent.Location = new System.Drawing.Point(236, 716);
            this.m_txtRecordContent.m_BlnIgnoreUserInfo = false;
            this.m_txtRecordContent.m_BlnPartControl = false;
            this.m_txtRecordContent.m_BlnReadOnly = false;
            this.m_txtRecordContent.m_BlnUnderLineDST = false;
            this.m_txtRecordContent.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtRecordContent.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtRecordContent.m_IntCanModifyTime = 6;
            this.m_txtRecordContent.m_IntPartControlLength = 0;
            this.m_txtRecordContent.m_IntPartControlStartIndex = 0;
            this.m_txtRecordContent.m_StrUserID = "";
            this.m_txtRecordContent.m_StrUserName = "";
            this.m_txtRecordContent.Name = "m_txtRecordContent";
            this.m_txtRecordContent.Size = new System.Drawing.Size(744, 136);
            this.m_txtRecordContent.TabIndex = 70;
            this.m_txtRecordContent.Text = "";
            // 
            // lblSignTitle
            // 
            this.lblSignTitle.AutoSize = true;
            this.lblSignTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblSignTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSignTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.lblSignTitle.Location = new System.Drawing.Point(796, 856);
            this.lblSignTitle.Name = "lblSignTitle";
            this.lblSignTitle.Size = new System.Drawing.Size(48, 16);
            this.lblSignTitle.TabIndex = 6053;
            this.lblSignTitle.Text = "签名:";
            // 
            // m_lblSign
            // 
            this.m_lblSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_lblSign.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblSign.ForeColor = System.Drawing.SystemColors.Window;
            this.m_lblSign.Location = new System.Drawing.Point(848, 856);
            this.m_lblSign.Name = "m_lblSign";
            this.m_lblSign.Size = new System.Drawing.Size(132, 19);
            this.m_lblSign.TabIndex = 6052;
            // 
            // lblRecordContentTitle
            // 
            this.lblRecordContentTitle.AutoSize = true;
            this.lblRecordContentTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblRecordContentTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRecordContentTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.lblRecordContentTitle.Location = new System.Drawing.Point(236, 692);
            this.lblRecordContentTitle.Name = "lblRecordContentTitle";
            this.lblRecordContentTitle.Size = new System.Drawing.Size(80, 16);
            this.lblRecordContentTitle.TabIndex = 6059;
            this.lblRecordContentTitle.Text = "病程记录:";
            // 
            // lblBreathTitle
            // 
            this.lblBreathTitle.AutoSize = true;
            this.lblBreathTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblBreathTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBreathTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.lblBreathTitle.Location = new System.Drawing.Point(248, 143);
            this.lblBreathTitle.Name = "lblBreathTitle";
            this.lblBreathTitle.Size = new System.Drawing.Size(104, 16);
            this.lblBreathTitle.TabIndex = 6051;
            this.lblBreathTitle.Text = "呼吸(次/分):";
            // 
            // m_txtTemperature
            // 
            this.m_txtTemperature.AccessibleDescription = "体温";
            this.m_txtTemperature.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtTemperature.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtTemperature.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtTemperature.ForeColor = System.Drawing.Color.White;
            this.m_txtTemperature.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtTemperature.Location = new System.Drawing.Point(640, 108);
            this.m_txtTemperature.m_BlnIgnoreUserInfo = false;
            this.m_txtTemperature.m_BlnPartControl = false;
            this.m_txtTemperature.m_BlnReadOnly = false;
            this.m_txtTemperature.m_BlnUnderLineDST = false;
            this.m_txtTemperature.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtTemperature.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtTemperature.m_IntCanModifyTime = 6;
            this.m_txtTemperature.m_IntPartControlLength = 0;
            this.m_txtTemperature.m_IntPartControlStartIndex = 0;
            this.m_txtTemperature.m_StrUserID = "";
            this.m_txtTemperature.m_StrUserName = "";
            this.m_txtTemperature.Multiline = false;
            this.m_txtTemperature.Name = "m_txtTemperature";
            this.m_txtTemperature.Size = new System.Drawing.Size(104, 24);
            this.m_txtTemperature.TabIndex = 21;
            this.m_txtTemperature.Text = "";
            // 
            // m_gpbIn
            // 
            this.m_gpbIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_gpbIn.Controls.Add(this.m_txtInD);
            this.m_gpbIn.Controls.Add(this.lblInDTitle);
            this.m_gpbIn.Controls.Add(this.m_txtInI);
            this.m_gpbIn.Controls.Add(this.lblInITitle);
            this.m_gpbIn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_gpbIn.ForeColor = System.Drawing.SystemColors.Window;
            this.m_gpbIn.Location = new System.Drawing.Point(244, 280);
            this.m_gpbIn.Name = "m_gpbIn";
            this.m_gpbIn.Size = new System.Drawing.Size(284, 100);
            this.m_gpbIn.TabIndex = 37;
            this.m_gpbIn.TabStop = false;
            this.m_gpbIn.Text = "摄入量(ml)";
            // 
            // m_txtInD
            // 
            this.m_txtInD.AccessibleDescription = "进食";
            this.m_txtInD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtInD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtInD.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtInD.ForeColor = System.Drawing.Color.White;
            this.m_txtInD.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtInD.Location = new System.Drawing.Point(104, 32);
            this.m_txtInD.m_BlnIgnoreUserInfo = false;
            this.m_txtInD.m_BlnPartControl = false;
            this.m_txtInD.m_BlnReadOnly = false;
            this.m_txtInD.m_BlnUnderLineDST = false;
            this.m_txtInD.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtInD.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtInD.m_IntCanModifyTime = 6;
            this.m_txtInD.m_IntPartControlLength = 0;
            this.m_txtInD.m_IntPartControlStartIndex = 0;
            this.m_txtInD.m_StrUserID = "";
            this.m_txtInD.m_StrUserName = "";
            this.m_txtInD.Multiline = false;
            this.m_txtInD.Name = "m_txtInD";
            this.m_txtInD.Size = new System.Drawing.Size(136, 24);
            this.m_txtInD.TabIndex = 38;
            this.m_txtInD.Text = "";
            this.m_txtInD.TextChanged += new System.EventHandler(this.m_mthInOutQty_Validated);
            // 
            // lblInDTitle
            // 
            this.lblInDTitle.AutoSize = true;
            this.lblInDTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblInDTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInDTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.lblInDTitle.Location = new System.Drawing.Point(52, 32);
            this.lblInDTitle.Name = "lblInDTitle";
            this.lblInDTitle.Size = new System.Drawing.Size(48, 16);
            this.lblInDTitle.TabIndex = 507;
            this.lblInDTitle.Text = "进食:";
            // 
            // m_txtInI
            // 
            this.m_txtInI.AccessibleDescription = "输液";
            this.m_txtInI.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtInI.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtInI.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtInI.ForeColor = System.Drawing.Color.White;
            this.m_txtInI.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtInI.Location = new System.Drawing.Point(104, 68);
            this.m_txtInI.m_BlnIgnoreUserInfo = false;
            this.m_txtInI.m_BlnPartControl = false;
            this.m_txtInI.m_BlnReadOnly = false;
            this.m_txtInI.m_BlnUnderLineDST = false;
            this.m_txtInI.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtInI.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtInI.m_IntCanModifyTime = 6;
            this.m_txtInI.m_IntPartControlLength = 0;
            this.m_txtInI.m_IntPartControlStartIndex = 0;
            this.m_txtInI.m_StrUserID = "";
            this.m_txtInI.m_StrUserName = "";
            this.m_txtInI.Multiline = false;
            this.m_txtInI.Name = "m_txtInI";
            this.m_txtInI.Size = new System.Drawing.Size(136, 24);
            this.m_txtInI.TabIndex = 39;
            this.m_txtInI.Text = "";
            this.m_txtInI.TextChanged += new System.EventHandler(this.m_mthInOutQty_Validated);
            // 
            // lblInITitle
            // 
            this.lblInITitle.AutoSize = true;
            this.lblInITitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblInITitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInITitle.ForeColor = System.Drawing.SystemColors.Window;
            this.lblInITitle.Location = new System.Drawing.Point(52, 68);
            this.lblInITitle.Name = "lblInITitle";
            this.lblInITitle.Size = new System.Drawing.Size(48, 16);
            this.lblInITitle.TabIndex = 507;
            this.lblInITitle.Text = "输液:";
            // 
            // m_dtpRecordTime
            // 
            this.m_dtpRecordTime.BorderColor = System.Drawing.Color.White;
            this.m_dtpRecordTime.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpRecordTime.DropButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_dtpRecordTime.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpRecordTime.DropButtonForeColor = System.Drawing.Color.White;
            this.m_dtpRecordTime.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpRecordTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpRecordTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpRecordTime.Location = new System.Drawing.Point(328, 104);
            this.m_dtpRecordTime.m_BlnOnlyTime = false;
            this.m_dtpRecordTime.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpRecordTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpRecordTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpRecordTime.Name = "m_dtpRecordTime";
            this.m_dtpRecordTime.ReadOnly = false;
            this.m_dtpRecordTime.Size = new System.Drawing.Size(212, 22);
            this.m_dtpRecordTime.TabIndex = 20;
            this.m_dtpRecordTime.TextBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_dtpRecordTime.TextForeColor = System.Drawing.Color.White;
            this.m_dtpRecordTime.Validated += new System.EventHandler(this.m_dtpRecordTime_Validated);
            // 
            // m_gpbPupil
            // 
            this.m_gpbPupil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_gpbPupil.Controls.Add(this.m_gpbPupil_Echo);
            this.m_gpbPupil.Controls.Add(this.m_gpbPupil_Size);
            this.m_gpbPupil.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_gpbPupil.ForeColor = System.Drawing.SystemColors.Window;
            this.m_gpbPupil.Location = new System.Drawing.Point(552, 168);
            this.m_gpbPupil.Name = "m_gpbPupil";
            this.m_gpbPupil.Size = new System.Drawing.Size(428, 104);
            this.m_gpbPupil.TabIndex = 30;
            this.m_gpbPupil.TabStop = false;
            this.m_gpbPupil.Text = "瞳孔";
            // 
            // m_gpbPupil_Echo
            // 
            this.m_gpbPupil_Echo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_gpbPupil_Echo.Controls.Add(this.m_txtEchoLeft);
            this.m_gpbPupil_Echo.Controls.Add(this.lblLeft1);
            this.m_gpbPupil_Echo.Controls.Add(this.m_txtEchoRight);
            this.m_gpbPupil_Echo.Controls.Add(this.lblRight1);
            this.m_gpbPupil_Echo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_gpbPupil_Echo.ForeColor = System.Drawing.SystemColors.Window;
            this.m_gpbPupil_Echo.Location = new System.Drawing.Point(232, 21);
            this.m_gpbPupil_Echo.Name = "m_gpbPupil_Echo";
            this.m_gpbPupil_Echo.Size = new System.Drawing.Size(180, 80);
            this.m_gpbPupil_Echo.TabIndex = 34;
            this.m_gpbPupil_Echo.TabStop = false;
            this.m_gpbPupil_Echo.Text = "反射";
            // 
            // m_txtEchoLeft
            // 
            this.m_txtEchoLeft.AccessibleDescription = "左";
            this.m_txtEchoLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtEchoLeft.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtEchoLeft.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtEchoLeft.ForeColor = System.Drawing.Color.White;
            this.m_txtEchoLeft.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtEchoLeft.Location = new System.Drawing.Point(48, 24);
            this.m_txtEchoLeft.m_BlnIgnoreUserInfo = false;
            this.m_txtEchoLeft.m_BlnPartControl = false;
            this.m_txtEchoLeft.m_BlnReadOnly = false;
            this.m_txtEchoLeft.m_BlnUnderLineDST = false;
            this.m_txtEchoLeft.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtEchoLeft.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtEchoLeft.m_IntCanModifyTime = 6;
            this.m_txtEchoLeft.m_IntPartControlLength = 0;
            this.m_txtEchoLeft.m_IntPartControlStartIndex = 0;
            this.m_txtEchoLeft.m_StrUserID = "";
            this.m_txtEchoLeft.m_StrUserName = "";
            this.m_txtEchoLeft.Multiline = false;
            this.m_txtEchoLeft.Name = "m_txtEchoLeft";
            this.m_txtEchoLeft.Size = new System.Drawing.Size(124, 24);
            this.m_txtEchoLeft.TabIndex = 35;
            this.m_txtEchoLeft.Text = "";
            // 
            // lblLeft1
            // 
            this.lblLeft1.AutoSize = true;
            this.lblLeft1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblLeft1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLeft1.ForeColor = System.Drawing.SystemColors.Window;
            this.lblLeft1.Location = new System.Drawing.Point(8, 24);
            this.lblLeft1.Name = "lblLeft1";
            this.lblLeft1.Size = new System.Drawing.Size(32, 16);
            this.lblLeft1.TabIndex = 507;
            this.lblLeft1.Text = "左:";
            // 
            // m_txtEchoRight
            // 
            this.m_txtEchoRight.AccessibleDescription = "右";
            this.m_txtEchoRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtEchoRight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtEchoRight.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtEchoRight.ForeColor = System.Drawing.Color.White;
            this.m_txtEchoRight.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtEchoRight.Location = new System.Drawing.Point(48, 52);
            this.m_txtEchoRight.m_BlnIgnoreUserInfo = false;
            this.m_txtEchoRight.m_BlnPartControl = false;
            this.m_txtEchoRight.m_BlnReadOnly = false;
            this.m_txtEchoRight.m_BlnUnderLineDST = false;
            this.m_txtEchoRight.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtEchoRight.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtEchoRight.m_IntCanModifyTime = 6;
            this.m_txtEchoRight.m_IntPartControlLength = 0;
            this.m_txtEchoRight.m_IntPartControlStartIndex = 0;
            this.m_txtEchoRight.m_StrUserID = "";
            this.m_txtEchoRight.m_StrUserName = "";
            this.m_txtEchoRight.Multiline = false;
            this.m_txtEchoRight.Name = "m_txtEchoRight";
            this.m_txtEchoRight.Size = new System.Drawing.Size(124, 24);
            this.m_txtEchoRight.TabIndex = 36;
            this.m_txtEchoRight.Text = "";
            // 
            // lblRight1
            // 
            this.lblRight1.AutoSize = true;
            this.lblRight1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblRight1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRight1.ForeColor = System.Drawing.SystemColors.Window;
            this.lblRight1.Location = new System.Drawing.Point(8, 52);
            this.lblRight1.Name = "lblRight1";
            this.lblRight1.Size = new System.Drawing.Size(32, 16);
            this.lblRight1.TabIndex = 507;
            this.lblRight1.Text = "右:";
            // 
            // m_gpbPupil_Size
            // 
            this.m_gpbPupil_Size.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_gpbPupil_Size.Controls.Add(this.m_txtPupilLeft);
            this.m_gpbPupil_Size.Controls.Add(this.lblPupilLeftTitle);
            this.m_gpbPupil_Size.Controls.Add(this.m_txtPupilRight);
            this.m_gpbPupil_Size.Controls.Add(this.lblPupilRightTitle);
            this.m_gpbPupil_Size.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_gpbPupil_Size.ForeColor = System.Drawing.SystemColors.Window;
            this.m_gpbPupil_Size.Location = new System.Drawing.Point(16, 21);
            this.m_gpbPupil_Size.Name = "m_gpbPupil_Size";
            this.m_gpbPupil_Size.Size = new System.Drawing.Size(196, 80);
            this.m_gpbPupil_Size.TabIndex = 31;
            this.m_gpbPupil_Size.TabStop = false;
            this.m_gpbPupil_Size.Text = "大小(mm)";
            // 
            // m_txtPupilLeft
            // 
            this.m_txtPupilLeft.AccessibleDescription = "左";
            this.m_txtPupilLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtPupilLeft.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtPupilLeft.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPupilLeft.ForeColor = System.Drawing.Color.White;
            this.m_txtPupilLeft.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPupilLeft.Location = new System.Drawing.Point(48, 24);
            this.m_txtPupilLeft.m_BlnIgnoreUserInfo = false;
            this.m_txtPupilLeft.m_BlnPartControl = false;
            this.m_txtPupilLeft.m_BlnReadOnly = false;
            this.m_txtPupilLeft.m_BlnUnderLineDST = false;
            this.m_txtPupilLeft.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPupilLeft.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPupilLeft.m_IntCanModifyTime = 6;
            this.m_txtPupilLeft.m_IntPartControlLength = 0;
            this.m_txtPupilLeft.m_IntPartControlStartIndex = 0;
            this.m_txtPupilLeft.m_StrUserID = "";
            this.m_txtPupilLeft.m_StrUserName = "";
            this.m_txtPupilLeft.Multiline = false;
            this.m_txtPupilLeft.Name = "m_txtPupilLeft";
            this.m_txtPupilLeft.Size = new System.Drawing.Size(140, 24);
            this.m_txtPupilLeft.TabIndex = 32;
            this.m_txtPupilLeft.Text = "";
            // 
            // lblPupilLeftTitle
            // 
            this.lblPupilLeftTitle.AutoSize = true;
            this.lblPupilLeftTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblPupilLeftTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPupilLeftTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.lblPupilLeftTitle.Location = new System.Drawing.Point(8, 24);
            this.lblPupilLeftTitle.Name = "lblPupilLeftTitle";
            this.lblPupilLeftTitle.Size = new System.Drawing.Size(32, 16);
            this.lblPupilLeftTitle.TabIndex = 507;
            this.lblPupilLeftTitle.Text = "左:";
            // 
            // m_txtPupilRight
            // 
            this.m_txtPupilRight.AccessibleDescription = "右";
            this.m_txtPupilRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtPupilRight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtPupilRight.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPupilRight.ForeColor = System.Drawing.Color.White;
            this.m_txtPupilRight.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPupilRight.Location = new System.Drawing.Point(48, 52);
            this.m_txtPupilRight.m_BlnIgnoreUserInfo = false;
            this.m_txtPupilRight.m_BlnPartControl = false;
            this.m_txtPupilRight.m_BlnReadOnly = false;
            this.m_txtPupilRight.m_BlnUnderLineDST = false;
            this.m_txtPupilRight.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPupilRight.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPupilRight.m_IntCanModifyTime = 6;
            this.m_txtPupilRight.m_IntPartControlLength = 0;
            this.m_txtPupilRight.m_IntPartControlStartIndex = 0;
            this.m_txtPupilRight.m_StrUserID = "";
            this.m_txtPupilRight.m_StrUserName = "";
            this.m_txtPupilRight.Multiline = false;
            this.m_txtPupilRight.Name = "m_txtPupilRight";
            this.m_txtPupilRight.Size = new System.Drawing.Size(140, 24);
            this.m_txtPupilRight.TabIndex = 33;
            this.m_txtPupilRight.Text = "";
            // 
            // lblPupilRightTitle
            // 
            this.lblPupilRightTitle.AutoSize = true;
            this.lblPupilRightTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblPupilRightTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPupilRightTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.lblPupilRightTitle.Location = new System.Drawing.Point(8, 52);
            this.lblPupilRightTitle.Name = "lblPupilRightTitle";
            this.lblPupilRightTitle.Size = new System.Drawing.Size(32, 16);
            this.lblPupilRightTitle.TabIndex = 507;
            this.lblPupilRightTitle.Text = "右:";
            // 
            // m_txtBloodPressureS
            // 
            this.m_txtBloodPressureS.AccessibleDescription = "血压";
            this.m_txtBloodPressureS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtBloodPressureS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtBloodPressureS.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBloodPressureS.ForeColor = System.Drawing.Color.White;
            this.m_txtBloodPressureS.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBloodPressureS.Location = new System.Drawing.Point(580, 140);
            this.m_txtBloodPressureS.m_BlnIgnoreUserInfo = false;
            this.m_txtBloodPressureS.m_BlnPartControl = false;
            this.m_txtBloodPressureS.m_BlnReadOnly = false;
            this.m_txtBloodPressureS.m_BlnUnderLineDST = false;
            this.m_txtBloodPressureS.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBloodPressureS.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBloodPressureS.m_IntCanModifyTime = 6;
            this.m_txtBloodPressureS.m_IntPartControlLength = 0;
            this.m_txtBloodPressureS.m_IntPartControlStartIndex = 0;
            this.m_txtBloodPressureS.m_StrUserID = "";
            this.m_txtBloodPressureS.m_StrUserName = "";
            this.m_txtBloodPressureS.Multiline = false;
            this.m_txtBloodPressureS.Name = "m_txtBloodPressureS";
            this.m_txtBloodPressureS.Size = new System.Drawing.Size(76, 24);
            this.m_txtBloodPressureS.TabIndex = 24;
            this.m_txtBloodPressureS.Text = "";
            // 
            // lblRecordTimeTitle
            // 
            this.lblRecordTimeTitle.AutoSize = true;
            this.lblRecordTimeTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRecordTimeTitle.Location = new System.Drawing.Point(248, 108);
            this.lblRecordTimeTitle.Name = "lblRecordTimeTitle";
            this.lblRecordTimeTitle.Size = new System.Drawing.Size(80, 16);
            this.lblRecordTimeTitle.TabIndex = 6066;
            this.lblRecordTimeTitle.Text = "记录时间:";
            // 
            // mniDoubleStrikeOutDelete
            // 
            this.mniDoubleStrikeOutDelete.Index = 0;
            this.mniDoubleStrikeOutDelete.Text = "双划线删除";
            this.mniDoubleStrikeOutDelete.Click += new System.EventHandler(this.mniDoubleStrikeOutDelete_Click);
            // 
            // lblBloodPressureTitle
            // 
            this.lblBloodPressureTitle.AutoSize = true;
            this.lblBloodPressureTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblBloodPressureTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBloodPressureTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.lblBloodPressureTitle.Location = new System.Drawing.Point(476, 143);
            this.lblBloodPressureTitle.Name = "lblBloodPressureTitle";
            this.lblBloodPressureTitle.Size = new System.Drawing.Size(96, 16);
            this.lblBloodPressureTitle.TabIndex = 6054;
            this.lblBloodPressureTitle.Text = "血压(mmHg):";
            // 
            // lblTemperatureTitle
            // 
            this.lblTemperatureTitle.AutoSize = true;
            this.lblTemperatureTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblTemperatureTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTemperatureTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.lblTemperatureTitle.Location = new System.Drawing.Point(548, 108);
            this.lblTemperatureTitle.Name = "lblTemperatureTitle";
            this.lblTemperatureTitle.Size = new System.Drawing.Size(88, 16);
            this.lblTemperatureTitle.TabIndex = 6057;
            this.lblTemperatureTitle.Text = "体温(  C):";
            // 
            // m_txtBloodPressureA
            // 
            this.m_txtBloodPressureA.AccessibleDescription = "血压";
            this.m_txtBloodPressureA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtBloodPressureA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtBloodPressureA.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBloodPressureA.ForeColor = System.Drawing.Color.White;
            this.m_txtBloodPressureA.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBloodPressureA.Location = new System.Drawing.Point(684, 140);
            this.m_txtBloodPressureA.m_BlnIgnoreUserInfo = false;
            this.m_txtBloodPressureA.m_BlnPartControl = false;
            this.m_txtBloodPressureA.m_BlnReadOnly = false;
            this.m_txtBloodPressureA.m_BlnUnderLineDST = false;
            this.m_txtBloodPressureA.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBloodPressureA.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBloodPressureA.m_IntCanModifyTime = 6;
            this.m_txtBloodPressureA.m_IntPartControlLength = 0;
            this.m_txtBloodPressureA.m_IntPartControlStartIndex = 0;
            this.m_txtBloodPressureA.m_StrUserID = "";
            this.m_txtBloodPressureA.m_StrUserName = "";
            this.m_txtBloodPressureA.Multiline = false;
            this.m_txtBloodPressureA.Name = "m_txtBloodPressureA";
            this.m_txtBloodPressureA.Size = new System.Drawing.Size(76, 24);
            this.m_txtBloodPressureA.TabIndex = 25;
            this.m_txtBloodPressureA.Text = "";
            // 
            // lblBloodPressureTitle2
            // 
            this.lblBloodPressureTitle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblBloodPressureTitle2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBloodPressureTitle2.ForeColor = System.Drawing.SystemColors.Window;
            this.lblBloodPressureTitle2.Location = new System.Drawing.Point(660, 140);
            this.lblBloodPressureTitle2.Name = "lblBloodPressureTitle2";
            this.lblBloodPressureTitle2.Size = new System.Drawing.Size(20, 24);
            this.lblBloodPressureTitle2.TabIndex = 6056;
            this.lblBloodPressureTitle2.Text = "/";
            // 
            // m_txtPulse
            // 
            this.m_txtPulse.AccessibleDescription = "脉搏";
            this.m_txtPulse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtPulse.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtPulse.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPulse.ForeColor = System.Drawing.Color.White;
            this.m_txtPulse.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPulse.Location = new System.Drawing.Point(860, 108);
            this.m_txtPulse.m_BlnIgnoreUserInfo = false;
            this.m_txtPulse.m_BlnPartControl = false;
            this.m_txtPulse.m_BlnReadOnly = false;
            this.m_txtPulse.m_BlnUnderLineDST = false;
            this.m_txtPulse.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPulse.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPulse.m_IntCanModifyTime = 6;
            this.m_txtPulse.m_IntPartControlLength = 0;
            this.m_txtPulse.m_IntPartControlStartIndex = 0;
            this.m_txtPulse.m_StrUserID = "";
            this.m_txtPulse.m_StrUserName = "";
            this.m_txtPulse.Multiline = false;
            this.m_txtPulse.Name = "m_txtPulse";
            this.m_txtPulse.Size = new System.Drawing.Size(112, 24);
            this.m_txtPulse.TabIndex = 22;
            this.m_txtPulse.Text = "";
            // 
            // m_txtBreath
            // 
            this.m_txtBreath.AccessibleDescription = "呼吸";
            this.m_txtBreath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtBreath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtBreath.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBreath.ForeColor = System.Drawing.Color.White;
            this.m_txtBreath.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBreath.Location = new System.Drawing.Point(364, 140);
            this.m_txtBreath.m_BlnIgnoreUserInfo = false;
            this.m_txtBreath.m_BlnPartControl = false;
            this.m_txtBreath.m_BlnReadOnly = false;
            this.m_txtBreath.m_BlnUnderLineDST = false;
            this.m_txtBreath.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBreath.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBreath.m_IntCanModifyTime = 6;
            this.m_txtBreath.m_IntPartControlLength = 0;
            this.m_txtBreath.m_IntPartControlStartIndex = 0;
            this.m_txtBreath.m_StrUserID = "";
            this.m_txtBreath.m_StrUserName = "";
            this.m_txtBreath.Multiline = false;
            this.m_txtBreath.Name = "m_txtBreath";
            this.m_txtBreath.Size = new System.Drawing.Size(92, 24);
            this.m_txtBreath.TabIndex = 23;
            this.m_txtBreath.Text = "";
            // 
            // lblPulseTitle
            // 
            this.lblPulseTitle.AutoSize = true;
            this.lblPulseTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblPulseTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPulseTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.lblPulseTitle.Location = new System.Drawing.Point(748, 108);
            this.lblPulseTitle.Name = "lblPulseTitle";
            this.lblPulseTitle.Size = new System.Drawing.Size(104, 16);
            this.lblPulseTitle.TabIndex = 6055;
            this.lblPulseTitle.Text = "脉搏(次/分):";
            // 
            // m_cmuRichTextBoxMenu
            // 
            this.m_cmuRichTextBoxMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mniDoubleStrikeOutDelete});
            // 
            // m_lsvWatchMachine
            // 
            this.m_lsvWatchMachine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_lsvWatchMachine.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_lsvWatchMachine.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmStandardParamID,
            this.clmStandardParamValue});
            this.m_lsvWatchMachine.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvWatchMachine.ForeColor = System.Drawing.SystemColors.Window;
            this.m_lsvWatchMachine.GridLines = true;
            this.m_lsvWatchMachine.Location = new System.Drawing.Point(20, 44);
            this.m_lsvWatchMachine.Name = "m_lsvWatchMachine";
            this.m_lsvWatchMachine.Size = new System.Drawing.Size(344, 140);
            this.m_lsvWatchMachine.TabIndex = 61;
            this.m_lsvWatchMachine.UseCompatibleStateImageBehavior = false;
            this.m_lsvWatchMachine.View = System.Windows.Forms.View.Details;
            // 
            // clmStandardParamID
            // 
            this.clmStandardParamID.Text = " 参数编号";
            this.clmStandardParamID.Width = 86;
            // 
            // clmStandardParamValue
            // 
            this.clmStandardParamValue.Text = "            参数值";
            this.clmStandardParamValue.Width = 258;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(20, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 6059;
            this.label1.Text = "监护仪:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.Window;
            this.label3.Location = new System.Drawing.Point(388, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 6059;
            this.label3.Text = "呼吸机:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_lsvWatchMachine);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.m_lsvBreathMachine);
            this.groupBox2.Location = new System.Drawing.Point(240, 500);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(744, 188);
            this.groupBox2.TabIndex = 60;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "机械参数";
            // 
            // m_lsvBreathMachine
            // 
            this.m_lsvBreathMachine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_lsvBreathMachine.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_lsvBreathMachine.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmStandardParamID2,
            this.clmStandardParamValue2});
            this.m_lsvBreathMachine.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvBreathMachine.ForeColor = System.Drawing.SystemColors.Window;
            this.m_lsvBreathMachine.GridLines = true;
            this.m_lsvBreathMachine.Location = new System.Drawing.Point(384, 44);
            this.m_lsvBreathMachine.Name = "m_lsvBreathMachine";
            this.m_lsvBreathMachine.Size = new System.Drawing.Size(344, 140);
            this.m_lsvBreathMachine.TabIndex = 62;
            this.m_lsvBreathMachine.UseCompatibleStateImageBehavior = false;
            this.m_lsvBreathMachine.View = System.Windows.Forms.View.Details;
            // 
            // clmStandardParamID2
            // 
            this.clmStandardParamID2.Text = " 参数编号";
            this.clmStandardParamID2.Width = 86;
            // 
            // clmStandardParamValue2
            // 
            this.clmStandardParamValue2.Text = "            参数值";
            this.clmStandardParamValue2.Width = 258;
            // 
            // m_txtSenses
            // 
            this.m_txtSenses.AccessibleDescription = "神志";
            this.m_txtSenses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtSenses.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtSenses.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSenses.ForeColor = System.Drawing.Color.White;
            this.m_txtSenses.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSenses.Location = new System.Drawing.Point(860, 140);
            this.m_txtSenses.m_BlnIgnoreUserInfo = false;
            this.m_txtSenses.m_BlnPartControl = false;
            this.m_txtSenses.m_BlnReadOnly = false;
            this.m_txtSenses.m_BlnUnderLineDST = false;
            this.m_txtSenses.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtSenses.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtSenses.m_IntCanModifyTime = 6;
            this.m_txtSenses.m_IntPartControlLength = 0;
            this.m_txtSenses.m_IntPartControlStartIndex = 0;
            this.m_txtSenses.m_StrUserID = "";
            this.m_txtSenses.m_StrUserName = "";
            this.m_txtSenses.Multiline = false;
            this.m_txtSenses.Name = "m_txtSenses";
            this.m_txtSenses.Size = new System.Drawing.Size(112, 24);
            this.m_txtSenses.TabIndex = 23;
            this.m_txtSenses.Text = "";
            // 
            // lblSensesTitle
            // 
            this.lblSensesTitle.AutoSize = true;
            this.lblSensesTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblSensesTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSensesTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.lblSensesTitle.Location = new System.Drawing.Point(776, 143);
            this.lblSensesTitle.Name = "lblSensesTitle";
            this.lblSensesTitle.Size = new System.Drawing.Size(80, 16);
            this.lblSensesTitle.TabIndex = 6051;
            this.lblSensesTitle.Text = "神    志:";
            // 
            // lblAbsorbPhlegmDateTitle
            // 
            this.lblAbsorbPhlegmDateTitle.AutoSize = true;
            this.lblAbsorbPhlegmDateTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblAbsorbPhlegmDateTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAbsorbPhlegmDateTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.lblAbsorbPhlegmDateTitle.Location = new System.Drawing.Point(16, 28);
            this.lblAbsorbPhlegmDateTitle.Name = "lblAbsorbPhlegmDateTitle";
            this.lblAbsorbPhlegmDateTitle.Size = new System.Drawing.Size(80, 16);
            this.lblAbsorbPhlegmDateTitle.TabIndex = 6051;
            this.lblAbsorbPhlegmDateTitle.Text = "吸痰时间:";
            // 
            // lblPhlegmAttributeTitle
            // 
            this.lblPhlegmAttributeTitle.AutoSize = true;
            this.lblPhlegmAttributeTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblPhlegmAttributeTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPhlegmAttributeTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.lblPhlegmAttributeTitle.Location = new System.Drawing.Point(16, 64);
            this.lblPhlegmAttributeTitle.Name = "lblPhlegmAttributeTitle";
            this.lblPhlegmAttributeTitle.Size = new System.Drawing.Size(80, 16);
            this.lblPhlegmAttributeTitle.TabIndex = 6051;
            this.lblPhlegmAttributeTitle.Text = "痰液性状:";
            // 
            // m_txtPhlegmAttribute
            // 
            this.m_txtPhlegmAttribute.AccessibleDescription = "痰液性状";
            this.m_txtPhlegmAttribute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtPhlegmAttribute.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtPhlegmAttribute.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPhlegmAttribute.ForeColor = System.Drawing.Color.White;
            this.m_txtPhlegmAttribute.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPhlegmAttribute.Location = new System.Drawing.Point(100, 64);
            this.m_txtPhlegmAttribute.m_BlnIgnoreUserInfo = false;
            this.m_txtPhlegmAttribute.m_BlnPartControl = false;
            this.m_txtPhlegmAttribute.m_BlnReadOnly = false;
            this.m_txtPhlegmAttribute.m_BlnUnderLineDST = false;
            this.m_txtPhlegmAttribute.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPhlegmAttribute.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPhlegmAttribute.m_IntCanModifyTime = 6;
            this.m_txtPhlegmAttribute.m_IntPartControlLength = 0;
            this.m_txtPhlegmAttribute.m_IntPartControlStartIndex = 0;
            this.m_txtPhlegmAttribute.m_StrUserID = "";
            this.m_txtPhlegmAttribute.m_StrUserName = "";
            this.m_txtPhlegmAttribute.Multiline = false;
            this.m_txtPhlegmAttribute.Name = "m_txtPhlegmAttribute";
            this.m_txtPhlegmAttribute.Size = new System.Drawing.Size(176, 24);
            this.m_txtPhlegmAttribute.TabIndex = 23;
            this.m_txtPhlegmAttribute.Text = "";
            // 
            // m_gpbPhlegm
            // 
            this.m_gpbPhlegm.Controls.Add(this.lblPhlegmAttributeTitle);
            this.m_gpbPhlegm.Controls.Add(this.m_txtPhlegmAttribute);
            this.m_gpbPhlegm.Controls.Add(this.lblAbsorbPhlegmDateTitle);
            this.m_gpbPhlegm.Controls.Add(this.m_dtpAbsorbPhlegmDate);
            this.m_gpbPhlegm.Location = new System.Drawing.Point(244, 172);
            this.m_gpbPhlegm.Name = "m_gpbPhlegm";
            this.m_gpbPhlegm.Size = new System.Drawing.Size(284, 100);
            this.m_gpbPhlegm.TabIndex = 6075;
            this.m_gpbPhlegm.TabStop = false;
            this.m_gpbPhlegm.Text = "痰液";
            // 
            // m_dtpAbsorbPhlegmDate
            // 
            this.m_dtpAbsorbPhlegmDate.BorderColor = System.Drawing.Color.White;
            this.m_dtpAbsorbPhlegmDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpAbsorbPhlegmDate.DropButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_dtpAbsorbPhlegmDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpAbsorbPhlegmDate.DropButtonForeColor = System.Drawing.Color.White;
            this.m_dtpAbsorbPhlegmDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpAbsorbPhlegmDate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpAbsorbPhlegmDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpAbsorbPhlegmDate.Location = new System.Drawing.Point(100, 28);
            this.m_dtpAbsorbPhlegmDate.m_BlnOnlyTime = false;
            this.m_dtpAbsorbPhlegmDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpAbsorbPhlegmDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpAbsorbPhlegmDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpAbsorbPhlegmDate.Name = "m_dtpAbsorbPhlegmDate";
            this.m_dtpAbsorbPhlegmDate.ReadOnly = false;
            this.m_dtpAbsorbPhlegmDate.Size = new System.Drawing.Size(176, 22);
            this.m_dtpAbsorbPhlegmDate.TabIndex = 20;
            this.m_dtpAbsorbPhlegmDate.TextBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_dtpAbsorbPhlegmDate.TextForeColor = System.Drawing.Color.White;
            // 
            // frmICUIntensiveTendRecord
            // 
            this.AccessibleDescription = "ICU危重患者护理记录";
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(796, 485);
            this.Controls.Add(this.lblSignTitle);
            this.Controls.Add(this.lblRecordContentTitle);
            this.Controls.Add(this.lblBreathTitle);
            this.Controls.Add(this.lblRecordTimeTitle);
            this.Controls.Add(this.lblBloodPressureTitle);
            this.Controls.Add(this.lblTemperatureTitle);
            this.Controls.Add(this.lblPulseTitle);
            this.Controls.Add(this.lblSensesTitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_gpbPhlegm);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.m_gpbTop);
            this.Controls.Add(this.m_gpbOut);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_lblSign);
            this.Controls.Add(this.m_txtTemperature);
            this.Controls.Add(this.m_gpbIn);
            this.Controls.Add(this.m_dtpRecordTime);
            this.Controls.Add(this.m_gpbPupil);
            this.Controls.Add(this.m_txtBloodPressureS);
            this.Controls.Add(this.m_txtBloodPressureA);
            this.Controls.Add(this.lblBloodPressureTitle2);
            this.Controls.Add(this.m_txtPulse);
            this.Controls.Add(this.m_txtBreath);
            this.Controls.Add(this.m_trvTime);
            this.Controls.Add(this.m_gpbLeft);
            this.Controls.Add(this.m_txtRecordContent);
            this.Controls.Add(this.m_txtSenses);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Name = "frmICUIntensiveTendRecord";
            this.Text = "ICU危重患者护理记录";
            this.Load += new System.EventHandler(this.frmIntensiveTendRecord_Load);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_txtSenses, 0);
            this.Controls.SetChildIndex(this.m_txtRecordContent, 0);
            this.Controls.SetChildIndex(this.m_gpbLeft, 0);
            this.Controls.SetChildIndex(this.m_trvTime, 0);
            this.Controls.SetChildIndex(this.m_txtBreath, 0);
            this.Controls.SetChildIndex(this.m_txtPulse, 0);
            this.Controls.SetChildIndex(this.lblBloodPressureTitle2, 0);
            this.Controls.SetChildIndex(this.m_txtBloodPressureA, 0);
            this.Controls.SetChildIndex(this.m_txtBloodPressureS, 0);
            this.Controls.SetChildIndex(this.m_gpbPupil, 0);
            this.Controls.SetChildIndex(this.m_dtpRecordTime, 0);
            this.Controls.SetChildIndex(this.m_gpbIn, 0);
            this.Controls.SetChildIndex(this.m_txtTemperature, 0);
            this.Controls.SetChildIndex(this.m_lblSign, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.m_gpbOut, 0);
            this.Controls.SetChildIndex(this.m_gpbTop, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.m_gpbPhlegm, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.lblSensesTitle, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.lblPulseTitle, 0);
            this.Controls.SetChildIndex(this.lblTemperatureTitle, 0);
            this.Controls.SetChildIndex(this.lblBloodPressureTitle, 0);
            this.Controls.SetChildIndex(this.lblRecordTimeTitle, 0);
            this.Controls.SetChildIndex(this.lblBreathTitle, 0);
            this.Controls.SetChildIndex(this.lblRecordContentTitle, 0);
            this.Controls.SetChildIndex(this.lblSignTitle, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.m_gpbOut.ResumeLayout(false);
            this.m_gpbOut.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.m_gpbIn.ResumeLayout(false);
            this.m_gpbIn.PerformLayout();
            this.m_gpbPupil.ResumeLayout(false);
            this.m_gpbPupil_Echo.ResumeLayout(false);
            this.m_gpbPupil_Echo.PerformLayout();
            this.m_gpbPupil_Size.ResumeLayout(false);
            this.m_gpbPupil_Size.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.m_gpbPhlegm.ResumeLayout(false);
            this.m_gpbPhlegm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region 窗体常用附加函数
		private void m_mthPrintEnd(Object sender,System.Drawing.Printing.PrintEventArgs e)
		{//m_printDocument1.EndPrint +=new System.Drawing.Printing.PrintEventHandler(this.m_mthPrintEnd);
			
			m_objDomain.m_lngUpdateFirstPrintDate(strInPatientID,strInPatientDate);
		}
		#region Override Function 
		private PrintTool.frmPrintPreviewDialog printpreviewdialog = new PrintTool.frmPrintPreviewDialog();
		protected override long m_lngSubPrint()
		{
			try
			{
				#region Old
				#region 有关打印初始化
			
				m_fotTitleFont = new Font("SimSun", 20,FontStyle.Bold );
				m_fotHeaderFont = new Font("SimSun", 15f);
				m_fotSmallFont = new Font("SimSun",12f);
				m_fotTinyFont=new Font("SimSun",10.5f);
			
				m_GridPen = new Pen(Color.Black,1);
				m_slbBrush = new SolidBrush(Color.Black);
		
				m_objPageSetting = new clsPrintPageSettingForRecord();
				m_intCurrentRecord=0;			
				#endregion				
				#endregion

				m_mthGetAllPrintData();//获取所有要打印的数据

				m_printDocument1.EndPrint +=new System.Drawing.Printing.PrintEventHandler(this.m_mthPrintEnd);
				
				printpreviewdialog.Document = m_printDocument1;					
				printpreviewdialog.ShowDialog();
				return 1;
				
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message);
				return 0;
			}
		
		}

		protected override enmFormState m_EnmCurrentFormState
		{
			get
			{
				return enmFormState.NowUser ;
			}
		}


		protected override long m_lngSubAddNew()
		{
			return m_lngSaveWithMessageBox();			
		}
	
		protected override bool m_BlnIsAddNew
		{
			get
			{
				if(m_dtpRecordTime.Enabled==true)
					return true;
				else 
					return false;
			}
		}
		
		protected override long m_lngSubModify()
		{			
			return m_lngSaveWithMessageBox();
		}

		protected override long m_lngSubDelete()
		{
			if(this.txtInPatientID.Text.Trim().Length!=7)	
			{
				clsPublicFunction.ShowInformationMessageBox("请选择住院号再删除！");
			}
			if(m_trvTime.SelectedNode==null || m_trvTime.SelectedNode.Text.Length !=19)
			{
				clsPublicFunction.ShowInformationMessageBox("请选择相应的创建时间再删除");
				return -1;
			}
			long lngRes= 1;//暂没做，new clsWatchItemRecordDomain().m_lngDelete("ICUIntensiveTendRecord",MDIParent.strOperatorID,strInPatientID,strInPatientDate,m_trvTime.SelectedNode.Text);
			if(lngRes <=0)
			{
				clsPublicFunction.ShowInformationMessageBox("删除失败");
			}
			else 
			{
				if(m_trvTime.SelectedNode.Parent.Nodes.Count==1)//树结构分日期、时间显示
					m_trvTime.SelectedNode.Parent.Remove();
				else m_trvTime.SelectedNode.Remove();
				m_trvTime.SelectedNode=m_trvTime.Nodes[0];
			}
			return lngRes;
			
		}

		/// <summary>
		/// 设置病人表单信息
		/// </summary>
		/// <param name="p_objSelectedPatient">病人</param>
		protected override void m_mthSetPatientFormInfo(clsPatient p_objSelectedPatient)
		{
			m_mthClearUpFormInfo();
			m_objCurrentPatient=p_objSelectedPatient;
			strInPatientID=m_objCurrentPatient.m_StrInPatientID;
			strInPatientDate=m_objCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmEMRInDate.ToString("yyyy-MM-dd HH:mm:ss");
			this.m_mthDisplayDates(strInPatientID,strInPatientDate);

            m_mthIsReadOnly();
            m_blnCanShowDiseaseTrack = m_blnCanShowRecordContent();
		}

		/// <summary>
		/// 是否处理病人号内容改变事件
		/// </summary>
		protected override bool m_BlnCanTextChanged
		{
			get
			{
				return this.m_blnCanLikeSeaching;
			}			
		}

		/// <summary>
		/// 清空病人基本住院信息的界面（可覆盖提供新的实现）
		/// </summary>
		protected override void m_mthClearPatientBaseInfo()
		{		
			m_txtPatientName.Text = "";
			lblSex.Text = "";
			lblAge.Text = "";
			m_cboArea.Text = "";
			m_txtBedNO.Text = "";			
		}

		#endregion 		

		#region 添加RichText附加属性(不包含DataGrid的边框设置)
		private com.digitalwave.controls.ctlRichTextBox m_txtFocusedRichTextBox=null;//存放当前获得焦点的RichTextBox
		private void m_mthSetRichTextAttrib()
		{			
			m_mthSetRichTextEvent(this);			
		}
		
		private void m_mthSetRichTextEvent(Control p_ctlControl)
		{
			#region 利用递归调用，读取并设置所有界面ctlRichTextBox控件的附加属性,Jacky-2003-2-25				
			if(p_ctlControl.GetType().Name=="ctlRichTextBox")
			{
                //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{	p_ctlControl });
//				p_ctlControl.ContextMenu=m_cmuRichTextBoxMenu;
				p_ctlControl.GotFocus += new EventHandler(m_txtRichTextBox_GotFocus);

				((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_StrUserID = MDIParent.strOperatorID;
				((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_StrUserName = MDIParent.strOperatorName;
				((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_ClrOldPartInsertText = Color.Black;
				((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_ClrDST = Color.Red;
			}
			
			if(p_ctlControl.HasChildren && p_ctlControl.GetType().Name !="DataGrid" )
			{									
				foreach(Control subcontrol in p_ctlControl.Controls)
				{										
					m_mthSetRichTextEvent(subcontrol);						
				} 	
			}				
					
			#endregion
		}

		private void mniDoubleStrikeOutDelete_Click(object sender, System.EventArgs e)
		{
			if(m_txtFocusedRichTextBox!=null)
				m_txtFocusedRichTextBox.m_mthSelectionDoubleStrikeThough(true);			
		}

		private void m_txtRichTextBox_GotFocus(object sender, System.EventArgs e)
		{
			m_txtFocusedRichTextBox=((com.digitalwave.controls.ctlRichTextBox)(sender));
		}

		/// <summary>
		/// 设置窗体中控件输入文本的颜色
		/// </summary>
		/// <param name="p_ctlControl"></param>
		/// <param name="p_clrColor"></param>
		private void m_mthSetRichTextModifyColor(Control p_ctlControl,System.Drawing.Color p_clrColor )
		{
			#region 设置控件输入文本的颜色,Jacky-2003-3-24	
			string strTypeName = p_ctlControl.GetType().Name;			
			if(strTypeName=="ctlRichTextBox")
				((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_ClrOldPartInsertText = p_clrColor;
			
			if(p_ctlControl.HasChildren && strTypeName !="DataGrid" )
			{									
				foreach(Control subcontrol in p_ctlControl.Controls)
				{										
					m_mthSetRichTextModifyColor(subcontrol,p_clrColor);						
				} 	
			}						
			#endregion
		}

		private void m_mthSetRichTextCanModifyLast(Control p_ctlControl,bool p_blnCanModifyLast )
		{
			#region 设置控件输入文本的是否最后修改,Jacky-2003-3-24	
			string strTypeName = p_ctlControl.GetType().Name;			
			if(strTypeName=="ctlRichTextBox")
			{				
				((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_BlnCanModifyLast = p_blnCanModifyLast;
			}
			
			if(p_ctlControl.HasChildren && strTypeName !="DataGrid" )
			{									
				foreach(Control subcontrol in p_ctlControl.Controls)
				{										
					m_mthSetRichTextCanModifyLast(subcontrol,p_blnCanModifyLast);					
				} 	
			}						
			#endregion			
		}
		
		#endregion

		#region 添加键盘快捷键
		private void m_mthSetQuickKeys()
		{			
			m_mthSetControlEvent(this);			
		}
		
		private void m_mthSetControlEvent(Control p_ctlControl)
		{
			#region 利用递归调用，读取并设置所有界面事件,Jacky-2003-2-21	
			string strTypeName = p_ctlControl.GetType().Name;
			if(strTypeName != "Lable" && strTypeName != "Button")
			{
				p_ctlControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthEvent_KeyDown);
				if(p_ctlControl.HasChildren && strTypeName !="DataGrid" && strTypeName !="DateTimePicker" && strTypeName !="ctlComboBox")				
				{									
					foreach(Control subcontrol in p_ctlControl.Controls)
					{										
						m_mthSetControlEvent(subcontrol);						
					} 	
				}				
			}			
			#endregion
		}
		
		private void m_mthEvent_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch(e.KeyValue)
			{//F1 112  帮助, F2 113 Save，F3  114 Del，F4 115 Print，F5 116 Refresh，F6 117 Search
				case 13:// enter									
					if(((Control)sender).Name!="m_txtRecordContent")
						SendKeys.Send(  "{tab}"); //注意:如果是button控件,则不能send "Tab" 而应该是"Enter",如果是Text控件且允许多行编辑，也不能send "Tab"
					break;

				case 38:
				case 40:					
					if(sender.GetType().Name=="ctlBorderTextBox" && ((ctlBorderTextBox)sender).Name=="txtInPatientID")
					{
						m_lsvInPatientID.Visible=true;						
						if( m_lsvInPatientID.Items.Count>0)
						{
							m_lsvInPatientID.Focus();
							m_lsvInPatientID.Items[0].Selected=true;
							m_lsvInPatientID.Items[0].Focused=true;
						}							
					}					
					break;	

					//				case 46:					
					//					break;
				case 113://save
					this.Save(); 
					break;
				case 114://del
					this.Delete(); 
					break;
				case 115://print
					this.Print();
					break;
				case 116://refresh
					m_mthClearUp();
					break;
				case 117://Search					
					break;
			}	
		}
		#endregion
		#endregion 窗体常用附加函数

		#region DataControl
		public void Save()
		{
			this.m_lngSave();
		}
		private long m_lngSaveWithMessageBox()
		{
			long lngRes=m_lngSaveWithoutMessageBox();
			if(lngRes==-11)
			{
				clsPublicFunction.ShowInformationMessageBox("你所修改的记录已被他人删除或不存在！");				
			}
			else if(lngRes==-21)
			{
				clsPublicFunction.ShowInformationMessageBox("对不起，保存失败！");
			}
			return lngRes;
		}
		private long m_lngSaveWithoutMessageBox()
		{	
			clsICUIntensiveTendRecord objclsICUIntensiveTendRecord=new clsICUIntensiveTendRecord();
			clsICUIntensiveTendRecordContent objclsICUIntensiveTendRecordContent=new clsICUIntensiveTendRecordContent();
			
			objclsICUIntensiveTendRecord.m_strInPatientID=strInPatientID;
			objclsICUIntensiveTendRecord.m_strInPatientDate=strInPatientDate;
			objclsICUIntensiveTendRecord.m_strCreateDate=m_dtpRecordTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
			objclsICUIntensiveTendRecordContent.m_strInPatientID=strInPatientID;
			objclsICUIntensiveTendRecordContent.m_strInPatientDate=strInPatientDate;
			objclsICUIntensiveTendRecordContent.m_strCreateDate=m_dtpRecordTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
			objclsICUIntensiveTendRecordContent.m_strModifyDate=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+((float)(DateTime.Now.Millisecond)/1000f).ToString(".000");
			objclsICUIntensiveTendRecordContent.m_strModifyUserID=MDIParent.strOperatorID;			

			//objclsICUIntensiveTendRecord.m_strCreateUserID=MDIParent.strOperatorID;
			if(m_dtpRecordTime.Enabled==false)
			{
				clsICUIntensiveTendRecord objclsICUIntensiveTendRecordOld=m_objDomain.m_objGetLatestTendRecord(strInPatientID,strInPatientDate,m_dtpRecordTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));
				if(objclsICUIntensiveTendRecordOld!=null)
					objclsICUIntensiveTendRecord.m_strCreateUserID=objclsICUIntensiveTendRecordOld.m_strCreateUserID;
				else 
				{
					//clsPublicFunction.ShowInformationMessageBox("你所修改的记录已被他人删除或不存在！");
					return -11;
				}
			}
			else objclsICUIntensiveTendRecord.m_strCreateUserID=MDIParent.strOperatorID;

			objclsICUIntensiveTendRecord.m_strBloodPressureAXML=m_txtBloodPressureA.m_strGetXmlText();
			objclsICUIntensiveTendRecord.m_strBloodPressureA=m_txtBloodPressureA.Text;
			objclsICUIntensiveTendRecordContent.m_strBloodPressureA_Last=m_txtBloodPressureA.m_strGetRightText();

			objclsICUIntensiveTendRecord.m_strBloodPressureSXML=m_txtBloodPressureS.m_strGetXmlText();
			objclsICUIntensiveTendRecord.m_strBloodPressureS=m_txtBloodPressureS.Text;
			objclsICUIntensiveTendRecordContent.m_strBloodPressureS_Last=m_txtBloodPressureS.m_strGetRightText();

			objclsICUIntensiveTendRecord.m_strBreathXML=m_txtBreath.m_strGetXmlText();
			objclsICUIntensiveTendRecord.m_strBreath=m_txtBreath.Text;
			objclsICUIntensiveTendRecordContent.m_strBreath_Last=m_txtBreath.m_strGetRightText();

			objclsICUIntensiveTendRecord.m_strInDXML=m_txtInD.m_strGetXmlText();
			objclsICUIntensiveTendRecord.m_strInD=m_txtInD.Text;			
			objclsICUIntensiveTendRecordContent.m_strInD_Last=m_txtInD.m_strGetRightText();
			objclsICUIntensiveTendRecord.m_strInIXML=m_txtInI.m_strGetXmlText();
			objclsICUIntensiveTendRecord.m_strInI=m_txtInI.Text;			
			objclsICUIntensiveTendRecordContent.m_strInI_Last=m_txtInI.m_strGetRightText();
			objclsICUIntensiveTendRecord.m_strOutUXML=m_txtOutU.m_strGetXmlText();
			objclsICUIntensiveTendRecord.m_strOutU=m_txtOutU.Text;			
			objclsICUIntensiveTendRecordContent.m_strOutU_Last=m_txtOutU.m_strGetRightText();
			objclsICUIntensiveTendRecord.m_strOutSXML=m_txtOutS.m_strGetXmlText();
			objclsICUIntensiveTendRecord.m_strOutS=m_txtOutS.Text;			
			objclsICUIntensiveTendRecordContent.m_strOutS_Last=m_txtOutS.m_strGetRightText();
			objclsICUIntensiveTendRecord.m_strOutVXML=m_txtOutV.m_strGetXmlText();
			objclsICUIntensiveTendRecord.m_strOutV=m_txtOutV.Text;			
			objclsICUIntensiveTendRecordContent.m_strOutV_Last=m_txtOutV.m_strGetRightText();
			objclsICUIntensiveTendRecord.m_strOutEXML=m_txtOutE.m_strGetXmlText();
			objclsICUIntensiveTendRecord.m_strOutE=m_txtOutE.Text;			
			objclsICUIntensiveTendRecordContent.m_strOutE_Last=m_txtOutE.m_strGetRightText();

			objclsICUIntensiveTendRecord.m_strEchoLeftXML=m_txtEchoLeft.m_strGetXmlText();
			objclsICUIntensiveTendRecord.m_strEchoLeft=m_txtEchoLeft.Text;
			objclsICUIntensiveTendRecordContent.m_strEchoLeft_Last=m_txtEchoLeft.Text;

			objclsICUIntensiveTendRecord.m_strEchoRightXML=m_txtEchoRight.m_strGetXmlText();
			objclsICUIntensiveTendRecord.m_strEchoRight=m_txtEchoRight.Text;
			objclsICUIntensiveTendRecordContent.m_strEchoRight_Last=m_txtEchoRight.Text;

			objclsICUIntensiveTendRecord.m_strPulseXML=m_txtPulse.m_strGetXmlText();
			objclsICUIntensiveTendRecord.m_strPulse=m_txtPulse.Text;
			objclsICUIntensiveTendRecordContent.m_strPulse_Last=m_txtPulse.Text;

			objclsICUIntensiveTendRecord.m_strPupilLeftXML=m_txtPupilLeft.m_strGetXmlText();
			objclsICUIntensiveTendRecord.m_strPupilLeft=m_txtPupilLeft.Text;
			objclsICUIntensiveTendRecordContent.m_strPupilLeft_Last=m_txtPupilLeft.Text;

			objclsICUIntensiveTendRecord.m_strPupilRightXML=m_txtPupilRight.m_strGetXmlText();
			objclsICUIntensiveTendRecord.m_strPupilRight=m_txtPupilRight.Text;
			objclsICUIntensiveTendRecordContent.m_strPupilRight_Last=m_txtPupilRight.Text;

			objclsICUIntensiveTendRecord.m_strRecordContentXML=m_txtRecordContent.m_strGetXmlText();
			objclsICUIntensiveTendRecord.m_strRecordContent=m_txtRecordContent.Text;	
			objclsICUIntensiveTendRecordContent.m_strRecordContent_Last=m_txtRecordContent.Text;	

			objclsICUIntensiveTendRecord.m_strTemperatureXML=m_txtTemperature.m_strGetXmlText();
			objclsICUIntensiveTendRecord.m_strTemperature=m_txtTemperature.Text;	
			objclsICUIntensiveTendRecordContent.m_strTemperature_Last=m_txtTemperature.Text;	
	
			objclsICUIntensiveTendRecord.m_strSensesXML=m_txtSenses.m_strGetXmlText();
			objclsICUIntensiveTendRecord.m_strSenses=m_txtSenses.Text;	
			objclsICUIntensiveTendRecordContent.m_strSenses_Last=m_txtSenses.Text;	

			//objclsICUIntensiveTendRecord.m_strAbsorbPhlegmDateXML=m_txtAbsorbPhlegmDate.m_strGetXmlText();
			objclsICUIntensiveTendRecord.m_strAbsorbPhlegmDate=m_dtpAbsorbPhlegmDate.Value.ToString("yyyy-MM-dd HH:mm:ss");	
			objclsICUIntensiveTendRecordContent.m_strAbsorbPhlegmDate_Last=objclsICUIntensiveTendRecord.m_strAbsorbPhlegmDate;	
			objclsICUIntensiveTendRecord.m_strPhlegmAttributeXML=m_txtPhlegmAttribute.m_strGetXmlText();
			objclsICUIntensiveTendRecord.m_strPhlegmAttribute=m_txtPhlegmAttribute.Text;	
			objclsICUIntensiveTendRecordContent.m_strPhlegmAttribute_Last=m_txtPhlegmAttribute.Text;	
			
			
			objclsICUIntensiveTendRecord.m_objclsICUIntensiveTendRecordParamArr=new clsICUIntensiveTendRecordParam[m_lsvBreathMachine.Items.Count+m_lsvWatchMachine.Items.Count];
			for(int j0=0;j0<objclsICUIntensiveTendRecord.m_objclsICUIntensiveTendRecordParamArr.Length;j0++)
			{
				objclsICUIntensiveTendRecord.m_objclsICUIntensiveTendRecordParamArr[j0]=new clsICUIntensiveTendRecordParam();
				objclsICUIntensiveTendRecord.m_objclsICUIntensiveTendRecordParamArr[j0].m_strInPatientID=strInPatientID;
				objclsICUIntensiveTendRecord.m_objclsICUIntensiveTendRecordParamArr[j0].m_strInPatientDate=strInPatientDate;
				objclsICUIntensiveTendRecord.m_objclsICUIntensiveTendRecordParamArr[j0].m_strCreateDate=objclsICUIntensiveTendRecordContent.m_strCreateDate;
				objclsICUIntensiveTendRecord.m_objclsICUIntensiveTendRecordParamArr[j0].m_strModifyDate=objclsICUIntensiveTendRecordContent.m_strModifyDate;
				objclsICUIntensiveTendRecord.m_objclsICUIntensiveTendRecordParamArr[j0].m_strModifyUserID=objclsICUIntensiveTendRecordContent.m_strModifyUserID;
				if(j0<m_lsvBreathMachine.Items.Count)
				{
					objclsICUIntensiveTendRecord.m_objclsICUIntensiveTendRecordParamArr[j0].m_strStandardParamID=m_lsvBreathMachine.Items[j0].SubItems[0].Text;
					objclsICUIntensiveTendRecord.m_objclsICUIntensiveTendRecordParamArr[j0].m_strStandardParamValue=m_lsvBreathMachine.Items[j0].SubItems[1].Text;
					//objclsICUIntensiveTendRecord.m_objclsICUIntensiveTendRecordParamArr[j0].m_strParamFlag;//存盘时不需要保存此项
				}
				else
				{
					objclsICUIntensiveTendRecord.m_objclsICUIntensiveTendRecordParamArr[j0].m_strStandardParamID=m_lsvWatchMachine.Items[j0-m_lsvBreathMachine.Items.Count].SubItems[0].Text;
					objclsICUIntensiveTendRecord.m_objclsICUIntensiveTendRecordParamArr[j0].m_strStandardParamValue=m_lsvWatchMachine.Items[j0-m_lsvBreathMachine.Items.Count].SubItems[1].Text;					
				}
			}

			long lngRes=m_objDomain.m_lngSave(objclsICUIntensiveTendRecord,objclsICUIntensiveTendRecordContent,m_dtpRecordTime.Enabled);
			if(lngRes<=0)
			{
				//clsPublicFunction.ShowInformationMessageBox("对不起，保存失败！");
				return -21;
			}
			else if(m_dtpRecordTime.Enabled)//添加记录时，刷新界面时间树
			{
				bool blnDayHasExist=false;
				for(int i=m_trvTime.Nodes[0].Nodes.Count-1;i>=0;i--)//先查找当前时间树中的日期，若存在，添加该时间
				{
					if(m_trvTime.Nodes[0].Nodes[i].Text==m_dtpRecordTime.Value.ToString("yyyy-MM-dd 00:00:00"))
					{
						TreeNode trnNew=new TreeNode(m_dtpRecordTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));
						m_trvTime.Nodes[0].Nodes[i].Nodes.Insert(0,trnNew);
						m_trvTime.SelectedNode=m_trvTime.Nodes[0].Nodes[i].FirstNode;
						blnDayHasExist=true;
						m_trvTime.Nodes[0].Nodes[i].Expand();
						break;
					}					
				}
				if(blnDayHasExist==false)//若不存在该日期，在树节点中添加该日期及时间
				{
					m_dtpRecordTime.Enabled=false;
					TreeNode trnNew=new TreeNode(m_dtpRecordTime.Value.ToString("yyyy-MM-dd 00:00:00"));
					m_trvTime.Nodes[0].Nodes.Insert(0,trnNew);
					trnNew=new TreeNode(m_dtpRecordTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));
					m_trvTime.Nodes[0].FirstNode.Nodes.Insert(0,trnNew);
					m_trvTime.SelectedNode=m_trvTime.Nodes[0].FirstNode.FirstNode;
					m_trvTime.Nodes[0].FirstNode.Expand();
				
				}
			}


			return 1;
		}
		public void Delete()
		{
			m_lngDelete();
		}
		public void Display(){}
		public void Display(string strInPatientID,string strInPatientDate)
		{
		}
		public void Print()
		{
            if (txtInPatientID.Text != m_objCurrentPatient.m_StrEMRInPatientID || txtInPatientID.Text == "")
			{
				m_mthShowNoPatient();
				return;
			}
			this.m_lngPrint();			
		}
		public void Copy(){m_lngCopy();}
		public void Cut(){m_lngCut();}
		public void Paste(){m_lngPaste();}
		public void Redo(){}
		public void Undo(){}
		public void Verify()
		{
			//long lngRes=m_lngSignVerify(p_strFormID,p_strRecordID);
		}
		#endregion

		#region 窗体事件及流程控制		
		private void frmIntensiveTendRecord_Load(object sender, System.EventArgs e)
		{
			m_mthSetRichTextAttrib();
			m_mthSetQuickKeys();

			m_trvTime.Nodes.Add("记录日期");			
			//this.m_mthDisplayDates(strInPatientID,strInPatientDate);
			m_lsvInPatientID.Visible=false;
			m_txtTemperature.Focus();
		}		

		private void m_mthDisplayDates(string p_strInPatientID,string p_strInPatientDate)
		{		
			m_trvTime.Nodes[0].Nodes.Clear();
			string[] strDateArr =m_objDomain.m_strGetAllTendRecordCreateDateArr(p_strInPatientID,p_strInPatientDate);
			if(strDateArr!=null)
			{
				ArrayList arlDay=new ArrayList();				
				string strDay="";	
				for(int i0=0;i0<strDateArr.Length;i0++)
				{
					strDay=DateTime.Parse(strDateArr[i0]).ToString("yyyy-MM-dd 00:00:00");
					if( !arlDay.Contains(strDay))
						arlDay.Add(strDay);
				}
				for(int j0=0;j0<arlDay.Count;j0++)
				{
					TreeNode trnNew=new TreeNode(arlDay[j0].ToString());
					m_trvTime.Nodes[0].Nodes.Insert(0,trnNew);
				}
				m_trvTime.Nodes[0].Expand();
				for(int i=0;i<m_trvTime.Nodes[0].Nodes.Count;i++)
				{
					string strDate="";
					TreeNode trnNew=null;
					for(int j2=0;j2<strDateArr.Length;j2++)
					{
						strDate=DateTime.Parse(strDateArr[j2]).ToString("yyyy-MM-dd HH:mm:ss");						
						if(strDate.Substring(0,10)==m_trvTime.Nodes[0].Nodes[i].Text)
						{	
							trnNew=new TreeNode(strDate);
							m_trvTime.Nodes[0].Nodes[i].Nodes.Insert(0,trnNew);				
						}
					}
				}				
			}

		}
        protected bool m_blnCanShowDiseaseTrack = true;
		private void m_trvTime_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			try
			{				
				m_mthClearUp2();//不能放在else句中再执行此句，因为RichTextBox赋新值之前必须清空
				m_mthSetRichTextModifyColor(this,clsHRPColor.s_ClrInputFore);
				m_mthSetRichTextCanModifyLast(this,true);

				if(e.Node.Text.Length==10 || e.Node.Text.Length==19)
				{
                    if (!m_blnCanShowDiseaseTrack)
                    {
                        clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                        return;
                    }

					clsStatisticInfo_TotalInOut objclsStatisticInfo_TotalInOut=m_objDomain.m_objGetStatisticInfo(strInPatientID,strInPatientDate,e.Node.Text);
					if(objclsStatisticInfo_TotalInOut!=null)
					{
						m_lblTotalIn.Text=objclsStatisticInfo_TotalInOut.m_strTotalIn;
						m_lblTotalInD.Text=objclsStatisticInfo_TotalInOut.m_strTotalInD;
						m_lblTotalInI.Text=objclsStatisticInfo_TotalInOut.m_strTotalInI;
						m_lblTotalOut.Text=objclsStatisticInfo_TotalInOut.m_strTotalOut;
						m_lblTotalOutE.Text=objclsStatisticInfo_TotalInOut.m_strTotalOutE;
						m_lblTotalOutS.Text=objclsStatisticInfo_TotalInOut.m_strTotalOutS;
						m_lblTotalOutU.Text=objclsStatisticInfo_TotalInOut.m_strTotalOutU;
						m_lblTotalOutV.Text=objclsStatisticInfo_TotalInOut.m_strTotalOutV;	
					}
					else 
					{
						clsPublicFunction.ShowInformationMessageBox("数据库连接失败！");
						return;
					}					

					if(e.Node.Text.Length==19)
					{
						m_dtpRecordTime.Value=DateTime.Parse(e.Node.Text);
						m_dtpRecordTime.Enabled=false;

						clsICUIntensiveTendRecord objclsICUIntensiveTendRecord=m_objDomain. m_objGetLatestTendRecord(strInPatientID,strInPatientDate,e.Node.Text);
						
						if(objclsICUIntensiveTendRecord==null )
						{
							clsPublicFunction.ShowInformationMessageBox("对不起,该条记录已被他人删除或不存在！");
							return;
						}
						m_txtBloodPressureA.m_mthSetNewText(objclsICUIntensiveTendRecord.m_strBloodPressureA,objclsICUIntensiveTendRecord.m_strBloodPressureAXML);
						m_txtBloodPressureS.m_mthSetNewText(objclsICUIntensiveTendRecord.m_strBloodPressureS,objclsICUIntensiveTendRecord.m_strBloodPressureSXML);
						m_txtBreath.m_mthSetNewText(objclsICUIntensiveTendRecord.m_strBreath,objclsICUIntensiveTendRecord.m_strBreathXML);
						m_txtInD.m_mthSetNewText(objclsICUIntensiveTendRecord.m_strInD,objclsICUIntensiveTendRecord.m_strInDXML);
						m_txtInI.m_mthSetNewText(objclsICUIntensiveTendRecord.m_strInI,objclsICUIntensiveTendRecord.m_strInIXML);
						m_txtOutU.m_mthSetNewText(objclsICUIntensiveTendRecord.m_strOutU,objclsICUIntensiveTendRecord.m_strOutUXML);
						m_txtOutS.m_mthSetNewText(objclsICUIntensiveTendRecord.m_strOutS,objclsICUIntensiveTendRecord.m_strOutSXML);
						m_txtOutV.m_mthSetNewText(objclsICUIntensiveTendRecord.m_strOutV,objclsICUIntensiveTendRecord.m_strOutVXML);
						m_txtOutE.m_mthSetNewText(objclsICUIntensiveTendRecord.m_strOutE,objclsICUIntensiveTendRecord.m_strOutEXML);
						m_txtEchoLeft.m_mthSetNewText(objclsICUIntensiveTendRecord.m_strEchoLeft,objclsICUIntensiveTendRecord.m_strEchoLeftXML);
						m_txtEchoRight.m_mthSetNewText(objclsICUIntensiveTendRecord.m_strEchoRight,objclsICUIntensiveTendRecord.m_strEchoRightXML);
						m_txtPulse.m_mthSetNewText(objclsICUIntensiveTendRecord.m_strPulse,objclsICUIntensiveTendRecord.m_strPulseXML);
						m_txtPupilLeft.m_mthSetNewText(objclsICUIntensiveTendRecord.m_strPupilLeft,objclsICUIntensiveTendRecord.m_strPupilLeftXML);
						m_txtPupilRight.m_mthSetNewText(objclsICUIntensiveTendRecord.m_strPupilRight,objclsICUIntensiveTendRecord.m_strPupilRightXML);
						m_txtRecordContent.m_mthSetNewText(objclsICUIntensiveTendRecord.m_strRecordContent,objclsICUIntensiveTendRecord.m_strRecordContentXML);			
						m_txtTemperature.m_mthSetNewText(objclsICUIntensiveTendRecord.m_strTemperature,objclsICUIntensiveTendRecord.m_strTemperatureXML);

						m_txtSenses.m_mthSetNewText(objclsICUIntensiveTendRecord.m_strSenses,objclsICUIntensiveTendRecord.m_strSensesXML);
						m_dtpAbsorbPhlegmDate.Text=objclsICUIntensiveTendRecord.m_strAbsorbPhlegmDate;
						m_txtPhlegmAttribute.m_mthSetNewText(objclsICUIntensiveTendRecord.m_strPhlegmAttribute,objclsICUIntensiveTendRecord.m_strPhlegmAttributeXML);

						m_mthSetRichTextModifyColor(this,Color.Red);
						m_mthSetRichTextCanModifyLast(this,m_blnGetCanModifyLast());

						//clsICUIntensiveTendRecordParam[] objclsICUIntensiveTendRecordParamArr=m_objDomain. m_objGetLatestTendRecordParam(strInPatientID,strInPatientDate,e.Node.Text);
						if(objclsICUIntensiveTendRecord.m_objclsICUIntensiveTendRecordParamArr !=null)
						{
							for(int i=0;i<objclsICUIntensiveTendRecord.m_objclsICUIntensiveTendRecordParamArr.Length;i++)
							{							
								if(objclsICUIntensiveTendRecord.m_objclsICUIntensiveTendRecordParamArr[i].m_strParamFlag=="0")
								{//0： CMS_Numeric 监护仪  2： Ventilator_Numeric 呼吸机 
									ListViewItem lviTemp=m_lsvWatchMachine.Items.Add(objclsICUIntensiveTendRecord.m_objclsICUIntensiveTendRecordParamArr[i].m_strStandardParamID);
									lviTemp.SubItems.Add(objclsICUIntensiveTendRecord.m_objclsICUIntensiveTendRecordParamArr[i].m_strStandardParamValue);
								}
								else if(objclsICUIntensiveTendRecord.m_objclsICUIntensiveTendRecordParamArr[i].m_strParamFlag=="2")
								{//0： CMS_Numeric 监护仪  2： Ventilator_Numeric 呼吸机 
									ListViewItem lviTemp=m_lsvBreathMachine.Items.Add(objclsICUIntensiveTendRecord.m_objclsICUIntensiveTendRecordParamArr[i].m_strStandardParamID);
									lviTemp.SubItems.Add(objclsICUIntensiveTendRecord.m_objclsICUIntensiveTendRecordParamArr[i].m_strStandardParamValue);
								}
							}
						}
									
					}				
					else if(e.Node.Text.Length==10)
					{
						if(e.Node.Text==DateTime.Now.ToString("yyyy-MM-dd 00:00:00"))
						{
							m_dtpRecordTime.Value=DateTime.Now;
							m_dtpRecordTime.Enabled=true;
						}
						else
						{
							m_dtpRecordTime.Enabled=false;
							m_dtpRecordTime.Text=m_trvTime.SelectedNode.Text;
							m_mthSetControlReadOnly(this,true);
							return;
						}
					}
				}	
				else 
				{
					m_dtpRecordTime.Value=DateTime.Now;
					m_dtpRecordTime.Enabled=true;
				}

				if(m_txtBloodPressureA.m_BlnReadOnly==true)//如果任意一个Text控件只读,则恢复可读写
					m_mthSetControlReadOnly(this,false);
			}
			catch(Exception ex){clsPublicFunction.ShowInformationMessageBox(ex.Message);m_mthSetControlReadOnly(this,false);}
			
		}	

		/// <summary>
		/// 输入框内，内容颜色的设置方法
		/// 如果该记录的最后修改人就是当前的登陆人，可以修改该记录
		/// 否则，不可修改（其中6小时的控制，在liyi的richtextbox中已有控制）
		/// </summary>
		/// <returns></returns>
		private bool m_blnGetCanModifyLast()
		{
            clsICUIntensiveTendRecordContent objContent = m_objDomain.m_objGetLatestTendRecordContent(strInPatientID, strInPatientDate, m_trvTime.SelectedNode.Text);
			//默认为可以修改
			if(objContent==null || objContent.m_strModifyUserID.Trim() == MDIParent.OperatorID.Trim())
				return true;
			else 
				return false;
		}
		
		private void m_mthClearUp2()
		{//删除所有本条记录内容，但不删除统计信息
			m_txtBloodPressureA.m_mthClearText();
			m_txtBloodPressureS.m_mthClearText();
			m_txtBreath.m_mthClearText();
			m_txtInD.m_mthClearText();
			m_txtInI.m_mthClearText();
			m_txtOutU.m_mthClearText();
			m_txtOutS.m_mthClearText();
			m_txtOutV.m_mthClearText();
			m_txtOutE.m_mthClearText();
			
			m_txtEchoLeft.m_mthClearText();
			m_txtEchoRight.m_mthClearText();
			m_txtPulse.m_mthClearText();
			m_txtPupilLeft.m_mthClearText();
			m_txtPupilRight.m_mthClearText();
			m_txtRecordContent.m_mthClearText();
			m_txtTemperature.m_mthClearText();	

			m_txtSenses.m_mthClearText();
			m_dtpAbsorbPhlegmDate.Value=DateTime.Now;
			m_txtPhlegmAttribute.m_mthClearText();	
		
			m_lsvBreathMachine.Items.Clear();
			m_lsvWatchMachine.Items.Clear();
		}
		private void m_mthClearUpFormInfo()
		{			
			m_trvTime.Nodes[0].Nodes.Clear();
			m_mthClearUp2();
			m_lblTotalIn.Text="0";
			m_lblTotalInD.Text="0";
			m_lblTotalInI.Text="0";
			m_lblTotalOut.Text="0";
			m_lblTotalOutE.Text="0";
			m_lblTotalOutS.Text="0";
			m_lblTotalOutU.Text="0";
			m_lblTotalOutV.Text="0";
		}

		private void m_mthClearUp()
		{
			this.m_mthClearPatientBaseInfo();	
			this.m_mthClearUpFormInfo();
			this.m_blnCanLikeSeaching=false;
			txtInPatientID.Text="";
			this.m_blnCanLikeSeaching=true;
		}

		private void m_mthInOutQty_Validated(object sender, System.EventArgs e)
		{	
			try
			{
				long lngNewValue;
				if(((com.digitalwave.controls.ctlRichTextBox)sender).Text.Trim()==""|| ((com.digitalwave.controls.ctlRichTextBox)sender).m_strGetRightText().Trim()=="")
					lngNewValue=0;
				else 
					lngNewValue=long.Parse(((com.digitalwave.controls.ctlRichTextBox)sender).m_strGetRightText().Trim());
			
				string strName=((com.digitalwave.controls.ctlRichTextBox)sender).Name;
				clsStatisticInfo_TotalInOut objclsStatisticInfo_TotalInOut=m_objDomain.m_objGetStatisticInfo(strInPatientID,strInPatientDate,m_dtpRecordTime.Value.ToString("yyyy-MM-dd 00:00:00"));
				if( objclsStatisticInfo_TotalInOut==null)
				{
					clsPublicFunction.ShowInformationMessageBox("数据库连接失败！");
					return;
				}		
				if(m_dtpRecordTime.Enabled==false)
				{
                    clsICUIntensiveTendRecordContent objclsICUIntensiveTendRecordContent = m_objDomain.m_objGetLatestTendRecordContent(strInPatientID, strInPatientDate, m_trvTime.SelectedNode.Text);
								
					if(strName=="m_txtInD")
					{
						m_lblTotalInD.Text = (long.Parse(objclsStatisticInfo_TotalInOut.m_strTotalInD) + lngNewValue -long.Parse(objclsICUIntensiveTendRecordContent.m_strInD_Last)).ToString();						
					}
					else if(strName=="m_txtInI")
					{
						m_lblTotalInI.Text = (long.Parse(objclsStatisticInfo_TotalInOut.m_strTotalInI) + lngNewValue -long.Parse(objclsICUIntensiveTendRecordContent.m_strInI_Last)).ToString();
					}
					else if(strName=="m_txtOutU")
					{
						m_lblTotalOutU.Text = (long.Parse(objclsStatisticInfo_TotalInOut.m_strTotalOutU) + lngNewValue -long.Parse(objclsICUIntensiveTendRecordContent.m_strOutU_Last)).ToString();
					}
					else if(strName=="m_txtOutS")
					{
						m_lblTotalOutS.Text = (long.Parse(objclsStatisticInfo_TotalInOut.m_strTotalOutS) + lngNewValue -long.Parse(objclsICUIntensiveTendRecordContent.m_strOutS_Last)).ToString();
					}
					else if(strName=="m_txtOutV")
					{
						m_lblTotalOutV.Text = (long.Parse(objclsStatisticInfo_TotalInOut.m_strTotalOutV) + lngNewValue -long.Parse(objclsICUIntensiveTendRecordContent.m_strOutV_Last)).ToString();
					}
					else if(strName=="m_txtOutE")
					{
						m_lblTotalOutE.Text = (long.Parse(objclsStatisticInfo_TotalInOut.m_strTotalOutE) + lngNewValue -long.Parse(objclsICUIntensiveTendRecordContent.m_strOutE_Last)).ToString();
					}				

				}	
				else //若为添加新记录状态时，因为不能获得文本改变之前的值，只有最终修改结果
				{
									
					if(strName=="m_txtInD")
					{
						m_lblTotalInD.Text =(long.Parse(objclsStatisticInfo_TotalInOut.m_strTotalInD) + lngNewValue ).ToString();
					}
					else if(strName=="m_txtInI")
					{
						m_lblTotalInI.Text = (long.Parse(objclsStatisticInfo_TotalInOut.m_strTotalInI) + lngNewValue ).ToString();
					}
					else if(strName=="m_txtOutU")
					{
						m_lblTotalOutU.Text = (long.Parse(objclsStatisticInfo_TotalInOut.m_strTotalOutU) + lngNewValue ).ToString();
					}
					else if(strName=="m_txtOutS")
					{
						m_lblTotalOutS.Text = (long.Parse(objclsStatisticInfo_TotalInOut.m_strTotalOutS) + lngNewValue  ).ToString();
					}
					else if(strName=="m_txtOutV")
					{
						m_lblTotalOutV.Text = (long.Parse(objclsStatisticInfo_TotalInOut.m_strTotalOutV) + lngNewValue ).ToString();
					}
					else if(strName=="m_txtOutE")
					{
						m_lblTotalOutE.Text = (long.Parse(objclsStatisticInfo_TotalInOut.m_strTotalOutE) + lngNewValue ).ToString();
					}	
				}
				m_lblTotalIn.Text = (long.Parse(m_lblTotalInD.Text)+long.Parse(m_lblTotalInI.Text)).ToString();
				m_lblTotalOut.Text = (long.Parse(m_lblTotalOutE.Text)+long.Parse(m_lblTotalOutS.Text)+long.Parse(m_lblTotalOutU.Text)+long.Parse(m_lblTotalOutV.Text)).ToString();
			}
			catch
			{
				clsPublicFunction.ShowInformationMessageBox("输入格式不对，只能输入数字！");
				((com.digitalwave.controls.ctlRichTextBox)sender).Focus();
			}
		}
		
		private void m_dtpRecordTime_Validated(object sender, System.EventArgs e)
		{
			if(m_blnCanLikeSeaching==false)return;//本行只作自动测试之用，否则请注释掉，Jacky-2003-2-21
			clsStatisticInfo_TotalInOut objclsStatisticInfo_TotalInOut=m_objDomain.m_objGetStatisticInfo(strInPatientID,strInPatientDate,m_dtpRecordTime.Value.ToString("yyyy-MM-dd 00:00:00"));
			if( objclsStatisticInfo_TotalInOut==null)
			{
				clsPublicFunction.ShowInformationMessageBox("数据库连接失败！");
				return;
			}	
			m_lblTotalInD.Text =objclsStatisticInfo_TotalInOut.m_strTotalInD;
			m_lblTotalInI.Text =objclsStatisticInfo_TotalInOut.m_strTotalInI;
			m_lblTotalIn.Text =objclsStatisticInfo_TotalInOut.m_strTotalIn;
			m_lblTotalOut.Text =objclsStatisticInfo_TotalInOut.m_strTotalOut;
			m_lblTotalOutE.Text =objclsStatisticInfo_TotalInOut.m_strTotalOutE;
			m_lblTotalOutS.Text =objclsStatisticInfo_TotalInOut.m_strTotalOutS;
			m_lblTotalOutU.Text =objclsStatisticInfo_TotalInOut.m_strTotalOutU;
			m_lblTotalOutV.Text =objclsStatisticInfo_TotalInOut.m_strTotalOutV;
		}
		#endregion				

		#region 打印 		
		/// <summary>
		/// （若要保留历史痕迹）当前记录内容
		/// </summary>
		private string[][] m_strValueArr;

		/// <summary>
		/// 当前记录的行序数（修改的次第数）
		/// </summary>
		private int m_intNowRowInOneRecord=0; 	

		/// <summary>
		///  所有的打印数据
		/// </summary>
		private clsICUIntensiveTendRecordContent_All[] m_objclsICUIntensiveTendRecordContent_AllArr=null;
		private clsStatisticInfo_TotalInOut[] m_objclsStatisticInfo_TotalInOutArr = null;
		private void m_mthGetAllPrintData()
		{
            m_objclsICUIntensiveTendRecordContent_AllArr = m_objDomain.m_strGetclsICUIntensiveTendRecordContent_AllArr(m_objCurrentPatient.m_StrEMRInPatientID, this.strInPatientDate, out m_objclsStatisticInfo_TotalInOutArr);
		}		

		private int m_intYPos = 90;

		private int m_intCurrentPage = 1;		

		private int m_intCurrentBlock = 0;

		private int m_intPreBlock = -1;

		private int m_intCurrentStatisic = 0;

		private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			m_mthPrintTitleInfo(e);

			m_intYPos += 80;

			e.Graphics.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX,m_intYPos,
				(int)enmRecordRectangleInfo.RightX,m_intYPos);
			
			Font fntNormal = new Font("",12);

			while(m_intCurrentBlock < m_objclsICUIntensiveTendRecordContent_AllArr.Length)
			{
				if(m_intCurrentBlock != m_intPreBlock)
				{
					m_mthSetNextBlock();
					m_intPreBlock = m_intCurrentBlock;
				}

				while(m_objPrintLineContext.m_BlnHaveMoreLine)
				{
					m_objPrintLineContext.m_mthPrintNextLine(ref m_intYPos,e.Graphics,fntNormal);

					if(m_intYPos > 960
						&& m_objPrintLineContext.m_BlnHaveMoreLine)
					{
						m_mthPrintFoot(e);

						e.HasMorePages = true;

						m_intYPos = 90;

						m_intCurrentPage++;

						return;
					}				
				}

				m_intCurrentBlock++;
			}

			//全部打完
			m_mthPrintFoot(e);

			m_objPrintLineContext.m_mthReset();

			m_intYPos = 90;

			m_intCurrentPage = 1;

			m_intCurrentBlock = 0;
			m_intPreBlock = -1;			

			m_intCurrentStatisic = 0;
		}		

		private void m_mthSetNextBlock()
		{
			clsICUIntensiveTendRecordContent_All objContent = m_objclsICUIntensiveTendRecordContent_AllArr[m_intCurrentBlock];
			m_objPrintLineContext.m_DtmFirstPrintTime=objContent.m_strFirstPrintDate.Trim()==""? DateTime.Now : DateTime.Parse(objContent.m_strFirstPrintDate);//首次打印时间赋值

			DateTime dtmCreateDate = DateTime.Parse(objContent.m_strCreateDate);
			m_objPrintCreateDate.m_DtmCreateDate = dtmCreateDate;

			m_objPrint1.m_ObjPrintLineInfo = objContent;
			m_objPrint2.m_ObjPrintLineInfo = objContent;

			m_objPrintMonitor.m_ObjPrintLineInfo = objContent;
			m_objPrintVentilator.m_ObjPrintLineInfo = objContent;

			m_objPrint4.m_ObjPrintLineInfo = objContent;
			m_objPrint5.m_ObjPrintLineInfo = objContent;

			if(m_intCurrentBlock == m_objclsICUIntensiveTendRecordContent_AllArr.Length-1)
			{
				m_objPrint6.m_ObjPrintLineInfo = m_objclsStatisticInfo_TotalInOutArr[m_intCurrentStatisic];
				m_intCurrentStatisic++;
			}
			else
			{
				if(m_intCurrentBlock >= 0)
				{
					DateTime dtmNextDate = DateTime.Parse(m_objclsICUIntensiveTendRecordContent_AllArr[m_intCurrentBlock+1].m_strCreateDate);

					if(dtmCreateDate.Date != dtmNextDate.Date)
					{
						m_objPrint6.m_ObjPrintLineInfo = m_objclsStatisticInfo_TotalInOutArr[m_intCurrentStatisic];
						m_intCurrentStatisic++;
					}
				}
			}

			m_objPrintLineContext.m_mthReset();
		}

		private void m_mthPrintFoot(System.Drawing.Printing.PrintPageEventArgs e)
		{
			e.Graphics.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX,m_intYPos,(int)enmRecordRectangleInfo.RightX,m_intYPos);

			Font fntHeader = new Font("SimSun", 12);

			e.Graphics.DrawString("第      页",fntHeader,Brushes.Black,355,m_intYPos+10);
			e.Graphics.DrawString(m_intCurrentPage.ToString(),fntHeader,Brushes.Black,395,m_intYPos+10);			

			fntHeader.Dispose();
		}		

		#region Print Line Class
		#region 打印日期和时间
		/// <summary>
		/// 打印第一页的固定内容
		/// </summary>
		private class clsPrintPamamDate : clsPrintLineBase
		{
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				p_objGrp.DrawString("日  期",p_fntNormalText ,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+4,
					p_intPosY+8);

				p_objGrp.DrawString("时间",p_fntNormalText,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark1+1, p_intPosY+8);

				m_blnHaveMoreLine = false;
			}

			public void m_mthPrintDateValue(int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_blnPrinted)
					return;

				m_blnPrinted = true;

				Font fntDate = new Font("",9f);

				p_objGrp.DrawString(m_dtmCreateDate.ToString("yyyy-MM-dd 00:00:00"),fntDate ,Brushes.Black,(int)enmRecordRectangleInfo.LeftX,
					p_intPosY);
		     
				p_objGrp.DrawString(m_dtmCreateDate.ToString("HH:mm:ss"),fntDate,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark1+1, p_intPosY);

				fntDate.Dispose();
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
			}

			private static bool m_blnPrinted = false;
			
			private DateTime m_dtmCreateDate;

			public DateTime m_DtmCreateDate
			{
				set
				{
					m_dtmCreateDate = value;
					m_blnPrinted = false;
				}
			}
		}
		#endregion

		#region 第一部分（体温～呕吐物）
		private class clsPrintParamInfo1 : clsPrintLineBase
		{
			private bool m_blnIsTitle = true;

			private int m_intValueIndex = 0;

			private clsPrintPamamDate m_objPrintDate;

			private clsICUIntensiveTendRecordContent_All m_objValue;

			public clsPrintParamInfo1(clsPrintPamamDate p_objPrintDate)
			{
				m_objPrintDate = p_objPrintDate;
			}

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objValue == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}

				if(m_blnIsTitle)
				{	
					m_mthPrintHeaderInfo(p_objGrp,p_fntNormalText,p_intPosY);
					m_mthPrintRectangleInfo(p_objGrp,p_intPosY);

					m_blnHaveMoreLine = true;

					m_blnIsTitle = false;

					p_intPosY += 80;
				}
				else
				{
					//画数值
					m_objPrintDate.m_mthPrintDateValue(p_intPosY,p_objGrp,p_fntNormalText);

					m_blnHaveMoreLine = !m_blnPrintOneRowValue(m_objValue.m_objclsICUIntensiveTendRecordContentArr,m_intValueIndex,p_objGrp,p_intPosY);

					m_intValueIndex++;					

					m_mthPrintValueVerLine(p_objGrp,p_intPosY,p_intPosY+30);

					p_intPosY += 30;	

					if(!m_blnHaveMoreLine)
					{						
						p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX,p_intPosY,(int)enmRecordRectangleInfo.RightX,p_intPosY);
					}				
				}
			}

			public override void m_mthReset()
			{
				m_blnIsTitle = true;
				m_blnHaveMoreLine = true;

				m_intValueIndex = 0;
			}

			public override object m_ObjPrintLineInfo
			{
				get
				{
					return m_objPrintLineInfo;
				}
				set
				{
					m_objValue = (clsICUIntensiveTendRecordContent_All)value;

					if(m_objValue != null)
					{
						bool blnEmpty = true;
						for(int i=0;i<m_objValue.m_objclsICUIntensiveTendRecordContentArr.Length;i++)
						{
							if(m_objValue.m_objclsICUIntensiveTendRecordContentArr[i].m_strTemperature_Last.Trim() != ""
								|| m_objValue.m_objclsICUIntensiveTendRecordContentArr[i].m_strPulse_Last.Trim() != ""
								|| m_objValue.m_objclsICUIntensiveTendRecordContentArr[i].m_strBreath_Last.Trim() != ""
								|| m_objValue.m_objclsICUIntensiveTendRecordContentArr[i].m_strBloodPressureA_Last.Trim() != ""
								|| m_objValue.m_objclsICUIntensiveTendRecordContentArr[i].m_strBloodPressureS_Last.Trim() != ""
								|| m_objValue.m_objclsICUIntensiveTendRecordContentArr[i].m_strPupilLeft_Last.Trim() != ""
								|| m_objValue.m_objclsICUIntensiveTendRecordContentArr[i].m_strPupilRight_Last.Trim() != ""
								|| m_objValue.m_objclsICUIntensiveTendRecordContentArr[i].m_strEchoLeft_Last.Trim() != ""
								|| m_objValue.m_objclsICUIntensiveTendRecordContentArr[i].m_strEchoRight_Last.Trim() != ""
								|| m_objValue.m_objclsICUIntensiveTendRecordContentArr[i].m_strInI_Last.Trim() != "0"
								|| m_objValue.m_objclsICUIntensiveTendRecordContentArr[i].m_strInD_Last.Trim() != "0"
								|| m_objValue.m_objclsICUIntensiveTendRecordContentArr[i].m_strOutE_Last.Trim() != "0"
								|| m_objValue.m_objclsICUIntensiveTendRecordContentArr[i].m_strOutS_Last.Trim() != "0"
								|| m_objValue.m_objclsICUIntensiveTendRecordContentArr[i].m_strOutU_Last.Trim() != "0"
								|| m_objValue.m_objclsICUIntensiveTendRecordContentArr[i].m_strOutV_Last.Trim() != "0")
							{
								blnEmpty = false;
								break;
							}
						}

						if(blnEmpty)
							m_objValue = null;
					}
				}
			}

			/// <summary>
			/// 打印一次时间记录的一行数值（需完成血压斜线的打印）
			/// </summary>
			/// <param name="p_strValueArr">数值(从“体温”到“呕吐物”，共14个)</param>
			/// <param name="p_intIndex">第几次的结果</param>
			/// <param name="e">打印参数</param>
			/// <param name="p_intPosY">Y坐标</param>
			private bool m_blnPrintOneRowValue(clsICUIntensiveTendRecordContent [] p_objContent,int p_intIndex,System.Drawing.Graphics p_objGrp,int p_intPosY)
			{	
				if(p_intIndex >= p_objContent.Length)
					return false;

				Font m_fotSmallFont = new Font("",12);
		
				clsICUIntensiveTendRecordContent objValue = p_objContent[p_intIndex];

				CharacterRange []rgnDSTArr = new CharacterRange[1];
				rgnDSTArr[0] = new CharacterRange(0,0);			
				
				RectangleF rtfText = new RectangleF(0,0,10000,100);

				StringFormat stfMeasure = new StringFormat(StringFormatFlags.LineLimit);			

				RectangleF rtfBounds;

				Region [] rgnDST;

				int intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2;//当前的X坐标
				//体温
			#region 打印一格，（以下完全相同）
				if(objValue.m_strTemperature_Last.Trim().Length != 0)
				{
					p_objGrp.DrawString(objValue.m_strTemperature_Last,m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intIndex+1 < p_objContent.Length)
					{
						if(objValue.m_strTemperature_Last != p_objContent[p_intIndex+1].m_strTemperature_Last)
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = objValue.m_strTemperature_Last.Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = p_objGrp.MeasureCharacterRanges(objValue.m_strTemperature_Last,m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(p_objGrp);

							p_objGrp.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							p_objGrp.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格

				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3;//当前的X坐标
				//脉搏
			#region 打印一格
				if(objValue.m_strPulse_Last.Trim().Length != 0)
				{
					p_objGrp.DrawString(objValue.m_strPulse_Last,m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intIndex+1 < p_objContent.Length)
					{
						if(objValue.m_strPulse_Last != p_objContent[p_intIndex+1].m_strPulse_Last)
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = objValue.m_strPulse_Last.Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = p_objGrp.MeasureCharacterRanges(objValue.m_strPulse_Last,m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(p_objGrp);

							p_objGrp.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							p_objGrp.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格

				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4;//当前的X坐标
				//呼吸
			#region 打印一格
				if(objValue.m_strBreath_Last.Trim().Length != 0)
				{
					p_objGrp.DrawString(objValue.m_strBreath_Last,m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intIndex+1 < p_objContent.Length)
					{
						if(objValue.m_strBreath_Last != p_objContent[p_intIndex+1].m_strBreath_Last)
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = objValue.m_strBreath_Last.Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = p_objGrp.MeasureCharacterRanges(objValue.m_strBreath_Last,m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(p_objGrp);

							p_objGrp.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							p_objGrp.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格

				bool blnIsLastModify=false;
				if( p_intIndex == p_objContent.Length-1 || (objValue.m_strBloodPressureS_Last == p_objContent[p_intIndex+1].m_strBloodPressureS_Last && objValue.m_strBloodPressureA_Last == p_objContent[p_intIndex+1].m_strBloodPressureA_Last && objValue.m_strBloodPressureS_Last == p_objContent[p_objContent.Length-1].m_strBloodPressureS_Last && objValue.m_strBloodPressureA_Last == p_objContent[p_objContent.Length-1].m_strBloodPressureA_Last))
				{// 当存在下一行，并且当前元素 != 下一行此元素				
					blnIsLastModify=true;					
				}
				//血压(收缩压)
				if(objValue.m_strBloodPressureS_Last.Trim().Length != 0)
				{
					p_objGrp.DrawString(objValue.m_strBloodPressureS_Last+" /",m_fotSmallFont,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5,p_intPosY);
					if( ! blnIsLastModify)
					{					
						rtfText.X = (int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5;
						rtfText.Y = p_intPosY;

						rgnDSTArr[0].First = 0;
						rgnDSTArr[0].Length = objValue.m_strBloodPressureS_Last.Length;

						stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

						rgnDST = p_objGrp.MeasureCharacterRanges(objValue.m_strBloodPressureS_Last,m_fotSmallFont,rtfText,stfMeasure);

						rtfBounds = rgnDST[0].GetBounds(p_objGrp);

						p_objGrp.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
						p_objGrp.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
					
					}
				}		

				//血压(舒张压)
				if(objValue.m_strBloodPressureA_Last.Trim().Length != 0)
				{
					p_objGrp.DrawString(objValue.m_strBloodPressureA_Last,m_fotSmallFont,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5+40,p_intPosY);
					if( ! blnIsLastModify)
					{					
						rtfText.X = (int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5+40;
						rtfText.Y = p_intPosY;

						rgnDSTArr[0].First = 0;
						rgnDSTArr[0].Length = objValue.m_strBloodPressureA_Last.Length;

						stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

						rgnDST = p_objGrp.MeasureCharacterRanges(objValue.m_strBloodPressureA_Last,m_fotSmallFont,rtfText,stfMeasure);

						rtfBounds = rgnDST[0].GetBounds(p_objGrp);

						p_objGrp.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
						p_objGrp.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
					
					}
				}


//				intTempColumn=5;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6;//当前的X坐标
				//瞳孔大小（左）
			#region 打印一格
				if(objValue.m_strPupilLeft_Last.Trim().Length != 0)
				{
					p_objGrp.DrawString(objValue.m_strPupilLeft_Last,m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intIndex+1 < p_objContent.Length)
					{
						if(objValue.m_strPupilLeft_Last != p_objContent[p_intIndex+1].m_strPupilLeft_Last)
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = objValue.m_strPupilLeft_Last.Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = p_objGrp.MeasureCharacterRanges(objValue.m_strPupilLeft_Last,m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(p_objGrp);

							p_objGrp.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							p_objGrp.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格
				

//				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7;//当前的X坐标
				//瞳孔大小（右）
			#region 打印一格
				if(objValue.m_strPupilRight_Last.Trim().Length != 0)
				{
					p_objGrp.DrawString(objValue.m_strPupilRight_Last,m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intIndex+1 < p_objContent.Length)
					{
						if(objValue.m_strPupilRight_Last != p_objContent[p_intIndex+1].m_strPupilRight_Last)
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = objValue.m_strPupilRight_Last.Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = p_objGrp.MeasureCharacterRanges(objValue.m_strPupilRight_Last,m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(p_objGrp);

							p_objGrp.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							p_objGrp.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格

//				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8;//当前的X坐标
				//瞳孔反射（左）
			#region 打印一格
				if(objValue.m_strEchoLeft_Last.Trim().Length != 0)
				{
					p_objGrp.DrawString(objValue.m_strEchoLeft_Last,m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intIndex+1 < p_objContent.Length)
					{
						if(objValue.m_strEchoLeft_Last != p_objContent[p_intIndex+1].m_strEchoLeft_Last)
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = objValue.m_strEchoLeft_Last.Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = p_objGrp.MeasureCharacterRanges(objValue.m_strEchoLeft_Last,m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(p_objGrp);

							p_objGrp.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							p_objGrp.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格			
			
//				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9;//当前的X坐标
				//瞳孔反射（右）
			#region 打印一格
				if(objValue.m_strEchoRight_Last.Trim().Length != 0)
				{
					p_objGrp.DrawString(objValue.m_strEchoRight_Last,m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intIndex+1 < p_objContent.Length)
					{
						if(objValue.m_strEchoRight_Last != p_objContent[p_intIndex+1].m_strEchoRight_Last)
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = objValue.m_strEchoRight_Last.Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = p_objGrp.MeasureCharacterRanges(objValue.m_strEchoRight_Last,m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(p_objGrp);

							p_objGrp.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							p_objGrp.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格			

//				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10;//当前的X坐标
				//输入液量
			#region 打印一格
				if(objValue.m_strInI_Last.Trim().Length != 0)
				{
					p_objGrp.DrawString(objValue.m_strInI_Last,m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intIndex+1 < p_objContent.Length)
					{
						if(objValue.m_strInI_Last != p_objContent[p_intIndex+1].m_strInI_Last)
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = objValue.m_strInI_Last.Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = p_objGrp.MeasureCharacterRanges(objValue.m_strInI_Last,m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(p_objGrp);

							p_objGrp.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							p_objGrp.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格			
			
//				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11;//当前的X坐标
				//进食量
			#region 打印一格
				if(objValue.m_strInD_Last.Trim().Length != 0)
				{
					p_objGrp.DrawString(objValue.m_strInD_Last,m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intIndex+1 < p_objContent.Length)
					{
						if(objValue.m_strInD_Last != p_objContent[p_intIndex+1].m_strInD_Last)
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = objValue.m_strInD_Last.Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = p_objGrp.MeasureCharacterRanges(objValue.m_strInD_Last,m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(p_objGrp);

							p_objGrp.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							p_objGrp.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格			


//				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark12;//当前的X坐标
				//引流量
			#region 打印一格
				if(objValue.m_strOutE_Last.Trim().Length != 0)
				{
					p_objGrp.DrawString(objValue.m_strOutE_Last,m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intIndex+1 < p_objContent.Length)
					{
						if(objValue.m_strOutE_Last != p_objContent[p_intIndex+1].m_strOutE_Last)
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = objValue.m_strOutE_Last.Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = p_objGrp.MeasureCharacterRanges(objValue.m_strOutE_Last,m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(p_objGrp);

							p_objGrp.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							p_objGrp.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格			


//				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark13;//当前的X坐标
				//尿量
			#region 打印一格
				if(objValue.m_strOutU_Last.Trim().Length != 0)
				{
					p_objGrp.DrawString(objValue.m_strOutU_Last,m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intIndex+1 < p_objContent.Length)
					{
						if(objValue.m_strOutU_Last != p_objContent[p_intIndex+1].m_strOutU_Last)
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = objValue.m_strOutU_Last.Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = p_objGrp.MeasureCharacterRanges(objValue.m_strOutU_Last,m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(p_objGrp);

							p_objGrp.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							p_objGrp.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格			


//				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark14;//当前的X坐标
				//大便量
			#region 打印一格
				if(objValue.m_strOutS_Last.Trim().Length != 0)
				{
					p_objGrp.DrawString(objValue.m_strOutS_Last,m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intIndex+1 < p_objContent.Length)
					{
						if(objValue.m_strOutS_Last != p_objContent[p_intIndex+1].m_strOutS_Last)
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = objValue.m_strOutS_Last.Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = p_objGrp.MeasureCharacterRanges(objValue.m_strOutS_Last,m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(p_objGrp);

							p_objGrp.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							p_objGrp.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格			


//				intTempColumn++;
				intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15;//当前的X坐标
				//呕吐物
			#region 打印一格
				if(objValue.m_strOutV_Last.Trim().Length != 0)
				{
					p_objGrp.DrawString(objValue.m_strOutV_Last,m_fotSmallFont,Brushes.Black,intPosX,p_intPosY);
					if(p_intIndex+1 < p_objContent.Length)
					{
						if(objValue.m_strOutV_Last != p_objContent[p_intIndex+1].m_strOutV_Last)
						{
							rtfText.X = intPosX;
							rtfText.Y = p_intPosY;

							rgnDSTArr[0].First = 0;
							rgnDSTArr[0].Length = objValue.m_strOutV_Last.Length;

							stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

							rgnDST = p_objGrp.MeasureCharacterRanges(objValue.m_strOutV_Last,m_fotSmallFont,rtfText,stfMeasure);

							rtfBounds = rgnDST[0].GetBounds(p_objGrp);

							p_objGrp.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
							p_objGrp.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
						}
					}
				}
			#endregion	打印一格			

				m_fotSmallFont.Dispose();

				return p_intIndex==p_objContent.Length-1;
			}

			/// <summary>
			/// 画标题的栏目
			/// </summary>
			/// <param name="e"></param>
			private void m_mthPrintHeaderInfo(System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText,int p_intPosY)
			{				
				Font fntSmallTitle = new Font("",9);
				StringFormat strVer = new StringFormat(StringFormatFlags.DirectionVertical);
				//体温 C	
				p_objGrp.DrawString("体温",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark2+1,p_intPosY+7);
				p_objGrp.DrawString("℃",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark2+1,p_intPosY+27);
				
				//脉搏(次/分)
				p_objGrp.DrawString("脉搏",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark3+1, p_intPosY+7);
				p_objGrp.DrawString("次/分",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark3+1, p_intPosY+27);
				
				//呼吸(次/分)
				p_objGrp.DrawString("呼吸",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark4+1, p_intPosY+7);
				p_objGrp.DrawString("次/分",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark4+1, p_intPosY+27);
				
				//血压(mmHg)
				p_objGrp.DrawString("血压",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark5+8, p_intPosY+7);
				p_objGrp.DrawString("mmHg",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark5+8, p_intPosY+27);
	
				p_objGrp.DrawString(" 瞳  孔",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark7+10, p_intPosY+5);
				p_objGrp.DrawString("大小(mm)",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark6+10, p_intPosY+30);
				p_objGrp.DrawString("左",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark6+10, p_intPosY+60);
				p_objGrp.DrawString("右",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark7+10, p_intPosY+60);

				p_objGrp.DrawString("反射",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark9-20, p_intPosY+30);
				p_objGrp.DrawString("左",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark8+10, p_intPosY+60);
				p_objGrp.DrawString("右",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark9+10, p_intPosY+60);

				p_objGrp.DrawString("摄入(ml)",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark10+10, p_intPosY+5);
				p_objGrp.DrawString("输液量",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark10+10, p_intPosY+30,strVer);

				p_objGrp.DrawString("进食量",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark11+10, p_intPosY+30,strVer);

				p_objGrp.DrawString("排出(ml)",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark13+10, p_intPosY+5);
				p_objGrp.DrawString("引流量",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark12+10, p_intPosY+30,strVer);

				p_objGrp.DrawString("尿量",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark13+10, p_intPosY+30,strVer);
			
				p_objGrp.DrawString("大便",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark14+10, p_intPosY+30,strVer);
			
				p_objGrp.DrawString("呕吐物",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark15+10, p_intPosY+30,strVer);
				strVer.Dispose();
				fntSmallTitle.Dispose();
			}		

			private void m_mthPrintValueVerLine(System.Drawing.Graphics p_objGrp,int p_intPosUpY,int p_intPosDownY)
			{
				#region 画格子竖线
				//画左边沿线
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX,p_intPosUpY,
					(int)enmRecordRectangleInfo.LeftX,p_intPosDownY);
			
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,p_intPosUpY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,p_intPosDownY);
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,p_intPosUpY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,p_intPosDownY);
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3,p_intPosUpY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3,p_intPosDownY);
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4,p_intPosUpY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4,p_intPosDownY);
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5,p_intPosUpY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5,p_intPosDownY);
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6,p_intPosUpY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6,p_intPosDownY);
				//瞳孔大小左右分界线
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7,p_intPosUpY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7,p_intPosDownY);
				//瞳孔大小与反射分界线
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8,p_intPosUpY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8,p_intPosDownY);
				//瞳孔反射左右分界线
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9,p_intPosUpY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9,p_intPosDownY);			
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10,p_intPosUpY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10,p_intPosDownY);
				//摄入中间分界线
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11,p_intPosUpY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11,p_intPosDownY);
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark12,p_intPosUpY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark12,p_intPosDownY);
			
				//排出中间分界线
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark13,p_intPosUpY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark13,p_intPosDownY);			
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark14,p_intPosUpY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark14,p_intPosDownY);			
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15,p_intPosUpY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15,p_intPosDownY);
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.RightX,p_intPosUpY,
					(int)enmRecordRectangleInfo.RightX,p_intPosDownY);		
			
			#endregion				
			}

			/// <summary>
			///  画表头格子
			/// </summary>
			/// <param name="e"></param>
			private void m_mthPrintRectangleInfo(System.Drawing.Graphics p_objGrp,int p_intPosY)
			{			
				//画格子横线
				for(int i1=1;i1<4 /*(int)enmRecordRectangleInfo.RowLinesNum*/ ;i1++)
				{
					if(i1 !=1 && i1 !=2)
						p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX ,
							p_intPosY+80,
							(int)enmRecordRectangleInfo.RightX,
							p_intPosY+80);
					else if(i1==1)
					{
						p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+ (int)enmRecordRectangleInfo.ColumnsMark6,
							p_intPosY+25,
							(int)enmRecordRectangleInfo.RightX,
							p_intPosY+25);					
					}
					else //if(i1==2)
						p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+ (int)enmRecordRectangleInfo.ColumnsMark6,
							p_intPosY+55,
							(int)enmRecordRectangleInfo.LeftX+ (int)enmRecordRectangleInfo.ColumnsMark10,
							p_intPosY+55);
				}
		
			#region 画格子竖线
				int intHeight=80;
				//画左边沿线
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX,p_intPosY,
					(int)enmRecordRectangleInfo.LeftX,p_intPosY+intHeight);
			
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,p_intPosY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,p_intPosY+intHeight);
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,p_intPosY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,p_intPosY+intHeight);
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3,p_intPosY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3,p_intPosY+intHeight);
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4,p_intPosY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4,p_intPosY+intHeight);
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5,p_intPosY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5,p_intPosY+intHeight);
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6,p_intPosY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6,p_intPosY+intHeight);
				//瞳孔大小左右分界线
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7,p_intPosY+55,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7,p_intPosY+intHeight);
				//瞳孔大小与反射分界线
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8,p_intPosY+25,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8,p_intPosY+intHeight);
				//瞳孔反射左右分界线
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9,p_intPosY+55,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9,p_intPosY+intHeight);			
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10,p_intPosY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10,p_intPosY+intHeight);
				//摄入中间分界线
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11,p_intPosY+25,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11,p_intPosY+intHeight);
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark12,p_intPosY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark12,p_intPosY+intHeight);
			
				//排出中间分界线
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark13,p_intPosY+25,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark13,p_intPosY+intHeight);			
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark14,p_intPosY+25,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark14,p_intPosY+intHeight);			
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15,p_intPosY+25,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15,p_intPosY+intHeight);
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.RightX,p_intPosY,
					(int)enmRecordRectangleInfo.RightX,p_intPosY+intHeight);		
			
			#endregion				
			
			}
		}
		#endregion

		#region 第二部分（神志～痰液性状）
		private class clsPrintParamInfo2 : clsPrintLineBase
		{
			private bool m_blnIsTitle = true;

			private com.digitalwave.controls.clsPrintRichTextContext m_objPrintMind = new com.digitalwave.controls.clsPrintRichTextContext(Color.Black,new Font("",12));
			private com.digitalwave.controls.clsPrintRichTextContext m_objPrintPhlegmAttribute = new com.digitalwave.controls.clsPrintRichTextContext(Color.Black,new Font("",12));

			private int m_intTimeValueIndex = 0;

			private clsPrintPamamDate m_objPrintDate;

			private clsICUIntensiveTendRecordContent_All m_objValue;

			private int m_intMindWidth = (int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6 - ((int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2);
			private int m_intPhlegmAttributeWidth = (int)enmRecordRectangleInfo.RightX - ((int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10);

			public clsPrintParamInfo2(clsPrintPamamDate p_objPrintDate)
			{
				m_objPrintDate = p_objPrintDate;
			}

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objValue == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				
				if(m_blnIsTitle)
				{	
					m_mthPrintHeaderInfo(p_objGrp,p_fntNormalText,p_intPosY);
					m_mthPrintRectangleInfo(p_objGrp,p_intPosY);

					m_blnHaveMoreLine = true;

					m_blnIsTitle = false;

					p_intPosY += 30;
				}
				else
				{
					//画数值
					m_objPrintDate.m_mthPrintDateValue(p_intPosY,p_objGrp,p_fntNormalText);

					m_objPrintMind.m_mthPrintLine(m_intMindWidth,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,p_intPosY,p_objGrp);
					m_objPrintPhlegmAttribute.m_mthPrintLine(m_intPhlegmAttributeWidth,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10,p_intPosY,p_objGrp);

					if(m_intTimeValueIndex < m_objValue.m_objclsICUIntensiveTendRecordContentArr.Length)
					{
						int intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6;//当前的X坐标
						//吸痰时间
						if(m_objValue.m_objclsICUIntensiveTendRecordContentArr[m_intTimeValueIndex].m_strAbsorbPhlegmDate_Last.Trim().Length != 0)
						{
							p_objGrp.DrawString(m_objValue.m_objclsICUIntensiveTendRecordContentArr[m_intTimeValueIndex].m_strAbsorbPhlegmDate_Last,p_fntNormalText,Brushes.Black,intPosX,p_intPosY);
							if(m_intTimeValueIndex+1 < m_objValue.m_objclsICUIntensiveTendRecordContentArr.Length)
							{
								if(m_objValue.m_objclsICUIntensiveTendRecordContentArr[m_intTimeValueIndex].m_strAbsorbPhlegmDate_Last != m_objValue.m_objclsICUIntensiveTendRecordContentArr[m_intTimeValueIndex+1].m_strAbsorbPhlegmDate_Last)
								{
									CharacterRange []rgnDSTArr = new CharacterRange[1];
									rgnDSTArr[0] = new CharacterRange(0,0);			
				
									RectangleF rtfText = new RectangleF(0,0,10000,100);

									StringFormat stfMeasure = new StringFormat(StringFormatFlags.LineLimit);			

									RectangleF rtfBounds;

									Region [] rgnDST;

									rtfText.X = intPosX;
									rtfText.Y = p_intPosY;

									rgnDSTArr[0].First = 0;
									rgnDSTArr[0].Length = m_objValue.m_objclsICUIntensiveTendRecordContentArr[m_intTimeValueIndex].m_strAbsorbPhlegmDate_Last.Length;

									stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

									rgnDST = p_objGrp.MeasureCharacterRanges(m_objValue.m_objclsICUIntensiveTendRecordContentArr[m_intTimeValueIndex].m_strAbsorbPhlegmDate_Last,p_fntNormalText,rtfText,stfMeasure);

									rtfBounds = rgnDST[0].GetBounds(p_objGrp);

									p_objGrp.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
									p_objGrp.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
								}
							}
						}
					}
				
					m_intTimeValueIndex++;

					m_mthPrintValueVerLine(p_objGrp,p_intPosY,p_intPosY+30);

					if(m_intTimeValueIndex < m_objValue.m_objclsICUIntensiveTendRecordContentArr.Length 
						|| m_objPrintMind.m_BlnHaveNextLine()
						|| m_objPrintPhlegmAttribute.m_BlnHaveNextLine())
					{
						m_blnHaveMoreLine = true;

						p_intPosY += 30;	
					}
					else
					{
						m_blnHaveMoreLine = false;

						p_intPosY += 30;

						p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX,p_intPosY,(int)enmRecordRectangleInfo.RightX,p_intPosY);
					}				
				}
			}

			public override void m_mthReset()
			{
				m_blnIsTitle = true;
				m_blnHaveMoreLine = true;

				m_intTimeValueIndex = 0;

				m_objPrintMind.m_mthRestartPrint();
				m_objPrintPhlegmAttribute.m_mthRestartPrint();
			}

			/// <summary>
			/// 画标题的栏目
			/// </summary>
			/// <param name="e"></param>
			private void m_mthPrintHeaderInfo(System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText,int p_intPosY)
			{			
				Font fntSmallTitle = new Font("",9f);
				//神志
				p_objGrp.DrawString("神		志",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark3-5, p_intPosY+8);
//				p_objGrp.DrawString("志",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
//					(int)enmRecordRectangleInfo.ColumnsMark5+5, p_intPosY+8);
				
				//吸痰时间
				p_objGrp.DrawString("吸痰时间",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark7+5, p_intPosY+8);
								
				//痰液性状
				p_objGrp.DrawString("痰液性状",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark12+5, p_intPosY+8);
							
				fntSmallTitle.Dispose();
			}		

			private void m_mthPrintValueVerLine(System.Drawing.Graphics p_objGrp,int p_intPosUpY,int p_intPosDownY)
			{
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX,p_intPosUpY,
					(int)enmRecordRectangleInfo.LeftX,p_intPosDownY);
			
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,p_intPosUpY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,p_intPosDownY);
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,p_intPosUpY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,p_intPosDownY);
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6,p_intPosUpY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6,p_intPosDownY);
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10,p_intPosUpY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10,p_intPosDownY);
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.RightX,p_intPosUpY,
					(int)enmRecordRectangleInfo.RightX,p_intPosDownY);				
			}

			/// <summary>
			///  画表头格子
			/// </summary>
			/// <param name="e"></param>
			private void m_mthPrintRectangleInfo(System.Drawing.Graphics p_objGrp,int p_intPosY)
			{								
				int intHeight=30;
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX,p_intPosY+intHeight,
					(int)enmRecordRectangleInfo.RightX,p_intPosY+intHeight);
			
				//画左边沿线
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX,p_intPosY,
					(int)enmRecordRectangleInfo.LeftX,p_intPosY+intHeight);
			
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,p_intPosY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,p_intPosY+intHeight);
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,p_intPosY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,p_intPosY+intHeight);
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6,p_intPosY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6,p_intPosY+intHeight);
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10,p_intPosY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10,p_intPosY+intHeight);
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.RightX,p_intPosY,
					(int)enmRecordRectangleInfo.RightX,p_intPosY+intHeight);		
			
			}

			public override object m_ObjPrintLineInfo
			{
				get
				{
					return m_objPrintLineInfo;
				}
				set
				{
					m_objValue = (clsICUIntensiveTendRecordContent_All)value;

					if(m_objValue != null)
					{
						bool blnEmpty = true;
						for(int i=0;i<m_objValue.m_objclsICUIntensiveTendRecordContentArr.Length;i++)
						{
							if(m_objValue.m_objclsICUIntensiveTendRecordContentArr[i].m_strAbsorbPhlegmDate_Last.Trim() != ""
								)
							{
								blnEmpty = false;
								break;
							}
						}

						if(blnEmpty && m_objValue.m_strPhlegmAttribute != "" && m_objValue.m_strSenses != "")
						{
							m_objValue = null;
						}
						else
						{
							m_objPrintMind.m_mthSetContextWithCorrectBefore(m_objValue.m_strSenses,m_objValue.m_strSensesXML,m_dtmFirstPrintTime);
							m_objPrintPhlegmAttribute.m_mthSetContextWithCorrectBefore(m_objValue.m_strPhlegmAttribute,m_objValue.m_strPhlegmAttributeXML,m_dtmFirstPrintTime);

							com.digitalwave.controls.ctlRichTextBox.clsModifyUserInfo [] objUserInfoArr = m_objPrintMind.m_ObjModifyUserArr;
							for(int i=0;i<objUserInfoArr.Length;i++)
							{
								if(objUserInfoArr[i].m_clrText.ToArgb() == Color.White.ToArgb())
								{
									objUserInfoArr[i].m_clrText = Color.Black;
								}
							}

							objUserInfoArr = m_objPrintPhlegmAttribute.m_ObjModifyUserArr;
							for(int i=0;i<objUserInfoArr.Length;i++)
							{
								if(objUserInfoArr[i].m_clrText.ToArgb() == Color.White.ToArgb())
								{
									objUserInfoArr[i].m_clrText = Color.Black;
								}
							}
						}
					}
				}
			}
		}
		#endregion

		#region 第三部分（机械参数）
		private class clsPrintParamInfo3 : clsPrintLineBase
		{
			private bool m_blnIsTitle = true;

			private bool m_blnIsMonitor;

			string [][] m_strValue = null;

			private int m_intCurrentTypeIndex = 0;

			private int m_intCurrentValueIndex = 0;

			private bool m_blnIsValueName = true;

			private clsPrintPamamDate m_objPrintDate;

			private ArrayList m_arlTimeTemp = new ArrayList();
			private ArrayList m_arlValueTemp = new ArrayList();

			public clsPrintParamInfo3(bool p_blnIsMonitor,clsPrintPamamDate p_objPrintDate)
			{
				m_blnIsMonitor = p_blnIsMonitor;
				
				m_objPrintDate = p_objPrintDate;
			}

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_strValue == null || m_strValue.Length == 0)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				
				if(m_blnIsTitle)
				{	
					m_mthPrintHeaderInfo(p_objGrp,p_fntNormalText,p_intPosY);
					m_mthPrintRectangleInfo(p_objGrp,p_intPosY);

					m_blnHaveMoreLine = true;

					m_blnIsTitle = false;

					p_intPosY += 30;
				}
				else
				{
					m_objPrintDate.m_mthPrintDateValue(p_intPosY,p_objGrp,p_fntNormalText);

					//画数值
					if(m_blnIsValueName)
					{
						if(m_intCurrentTypeIndex >= m_strValue.Length)
						{
							m_blnHaveMoreLine = false;
							return;
						}

						for(int i=m_intCurrentTypeIndex;i<m_strValue[0].Length && i<m_intCurrentTypeIndex+6;i++)
						{
							p_objGrp.DrawString(m_strValue[0][i],p_fntNormalText,Brushes.Black,(i%6)*100.3f+(float)((int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2+1),p_intPosY+3);
						}

						m_mthPrintValueVerLine(p_objGrp,p_intPosY,p_intPosY+30);
						p_intPosY += 30;

						p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX,p_intPosY,(int)enmRecordRectangleInfo.RightX,p_intPosY);

						m_blnIsValueName = false;
						m_intCurrentValueIndex = 0;

						m_blnHaveMoreLine = true;
					}
					else
					{
						if(m_intCurrentValueIndex < m_strValue.Length-1)
						{
							for(int i=m_intCurrentTypeIndex;i<m_strValue[0].Length && i<m_intCurrentTypeIndex+6;i++)
							{
								p_objGrp.DrawString(m_strValue[m_intCurrentValueIndex+1][i],p_fntNormalText,Brushes.Black,(i%6)*100.3f+(float)((int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2+1),p_intPosY+3);
							}							

							m_mthPrintValueVerLine(p_objGrp,p_intPosY,p_intPosY+30);
							
							m_intCurrentValueIndex++;

							p_intPosY += 30;

							if(m_intCurrentValueIndex < m_strValue.Length-1)
							{
								m_blnHaveMoreLine = true;
							}
							else
							{
								p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX,p_intPosY,(int)enmRecordRectangleInfo.RightX,p_intPosY);

								m_intCurrentTypeIndex += 6;

								m_blnIsValueName = true;

								if(m_intCurrentTypeIndex >= m_strValue[0].Length)
								{
									m_blnHaveMoreLine = false;
									return;
								}
								else
								{
									m_blnHaveMoreLine = true;
								}
							}
						}
						else
						{
							p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX,p_intPosY,(int)enmRecordRectangleInfo.RightX,p_intPosY);

							m_blnHaveMoreLine = true;

							m_blnIsValueName = true;

							m_intCurrentTypeIndex += 6;
						}
					}
				}
			}

			public override void m_mthReset()
			{
				m_blnIsTitle = true;
				m_blnHaveMoreLine = true;

				m_intCurrentTypeIndex = 0;
				m_intCurrentValueIndex = 0;

				m_blnIsValueName = true;
			}

			/// <summary>
			/// 画标题的栏目
			/// </summary>
			/// <param name="e"></param>
			private void m_mthPrintHeaderInfo(System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText,int p_intPosY)
			{				
				//机械参数
				if(m_blnIsMonitor)
				{
					p_objGrp.DrawString("监	护	仪	机	械	参	数",p_fntNormalText,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
						(int)enmRecordRectangleInfo.ColumnsMark3-3, p_intPosY+4);
				}
				else
				{
					p_objGrp.DrawString("呼	吸	机	机	械	参	数",p_fntNormalText,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
						(int)enmRecordRectangleInfo.ColumnsMark3-3, p_intPosY+4);
				}							
			}		

			private void m_mthPrintValueVerLine(System.Drawing.Graphics p_objGrp,int p_intPosUpY,int p_intPosDownY)
			{
				//画左边沿线
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX,p_intPosUpY,
					(int)enmRecordRectangleInfo.LeftX,p_intPosDownY);
			
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,p_intPosUpY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,p_intPosDownY);
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,p_intPosUpY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,p_intPosDownY);

				for(int i=1;i<6;i++)
				{
					p_objGrp.DrawLine(Pens.Black,(float)((int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2)+i*100.3f,p_intPosUpY,
						(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2+i*100.3f,p_intPosDownY);
				}

				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.RightX,p_intPosUpY,
					(int)enmRecordRectangleInfo.RightX,p_intPosDownY);		
			}

			/// <summary>
			///  画表头格子
			/// </summary>
			/// <param name="e"></param>
			private void m_mthPrintRectangleInfo(System.Drawing.Graphics p_objGrp,int p_intPosY)
			{								
				int intHeight=30;
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX,p_intPosY+intHeight,
					(int)enmRecordRectangleInfo.RightX,p_intPosY+intHeight);
			
				//画左边沿线
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX,p_intPosY,
					(int)enmRecordRectangleInfo.LeftX,p_intPosY+intHeight);
			
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,p_intPosY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,p_intPosY+intHeight);
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,p_intPosY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,p_intPosY+intHeight);
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.RightX,p_intPosY,
					(int)enmRecordRectangleInfo.RightX,p_intPosY+intHeight);		
			
			}

			public override object m_ObjPrintLineInfo
			{
				get
				{
					return m_objPrintLineInfo;
				}
				set
				{
					clsICUIntensiveTendRecordContent_All objAllValue = (clsICUIntensiveTendRecordContent_All)value;

					if(objAllValue == null || objAllValue.m_objclsICUIntensiveTendRecordParamArr == null || objAllValue.m_objclsICUIntensiveTendRecordParamArr.Length == 0)
					{
						m_strValue = null;
						return;
					}

					string strPreModifyDate = "";					
					bool blnAddedID = false;
					for(int i=0;i<objAllValue.m_objclsICUIntensiveTendRecordParamArr.Length;i++)
					{
						if(m_blnIsMonitor && objAllValue.m_objclsICUIntensiveTendRecordParamArr[i].m_strParamFlag != "0")
							continue;
						else if(!m_blnIsMonitor && objAllValue.m_objclsICUIntensiveTendRecordParamArr[i].m_strParamFlag != "2")
							continue;						
						
						if(strPreModifyDate == "")
						{
							m_arlValueTemp.Add(objAllValue.m_objclsICUIntensiveTendRecordParamArr[i].m_strStandardParamValue);
							m_arlTimeTemp.Add(objAllValue.m_objclsICUIntensiveTendRecordParamArr[i].m_strParamName);

							strPreModifyDate = objAllValue.m_objclsICUIntensiveTendRecordParamArr[i].m_strModifyDate;
						}
						else
						{
							if(strPreModifyDate != objAllValue.m_objclsICUIntensiveTendRecordParamArr[i].m_strModifyDate)
							{
								if(!blnAddedID)
								{
									string[] strIDArr = (string[])m_arlTimeTemp.ToArray(typeof(string));
									m_arlTimeTemp.Clear();
									m_arlTimeTemp.Add(strIDArr);

									blnAddedID = true;
								}

								string [] strValueArr = (string[])m_arlValueTemp.ToArray(typeof(string));
								m_arlValueTemp.Clear();

								m_arlTimeTemp.Add(strValueArr);

								strPreModifyDate = objAllValue.m_objclsICUIntensiveTendRecordParamArr[i].m_strModifyDate;
							}

							if(!blnAddedID)
							{
								m_arlTimeTemp.Add(objAllValue.m_objclsICUIntensiveTendRecordParamArr[i].m_strParamName);
							}

							m_arlValueTemp.Add(objAllValue.m_objclsICUIntensiveTendRecordParamArr[i].m_strStandardParamValue);
						}
					}

					if(strPreModifyDate == "")
					{
						//没有该种数据
						m_arlTimeTemp.Clear();
						m_arlValueTemp.Clear();

						m_strValue = null;
						return;
					}

					if(!blnAddedID)
					{
						string[] strIDArr = (string[])m_arlTimeTemp.ToArray(typeof(string));
						m_arlTimeTemp.Clear();
						m_arlTimeTemp.Add(strIDArr);

						blnAddedID = true;
					}

					if(m_arlValueTemp.Count > 0)
					{
						string [] strValueArr = (string[])m_arlValueTemp.ToArray(typeof(string));
						m_arlTimeTemp.Add(strValueArr);						
					}					

					m_strValue = (string[][])m_arlTimeTemp.ToArray(typeof(string[]));

					m_arlTimeTemp.Clear();
					m_arlValueTemp.Clear();

				}
			}
		}
		#endregion		
		
		#region 第四部分（病程记录）
		private class clsPrintParamInfo4 : clsPrintLineBase
		{
			private bool m_blnIsTitle = true;

			private com.digitalwave.controls.clsPrintRichTextContext m_objPrintHistory = new com.digitalwave.controls.clsPrintRichTextContext(Color.Black,new Font("",12));

			private clsPrintPamamDate m_objPrintDate;

			private bool m_blnIsEmpty = true;

			private int m_intRecordWidth = ((int)enmRecordRectangleInfo.RightX) - ((int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2);
			
			public clsPrintParamInfo4(clsPrintPamamDate p_objPrintDate)
			{
				m_objPrintDate = p_objPrintDate;
			}

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_blnIsEmpty)
				{
					m_blnHaveMoreLine = false;
					return;
				}

				if(m_blnIsTitle)
				{	
					m_mthPrintHeaderInfo(p_objGrp,p_fntNormalText,p_intPosY);
					m_mthPrintRectangleInfo(p_objGrp,p_intPosY);

					m_blnHaveMoreLine = true;

					m_blnIsTitle = false;

					p_intPosY += 30;
				}
				else
				{
					m_objPrintDate.m_mthPrintDateValue(p_intPosY,p_objGrp,p_fntNormalText);

					//画数值
					m_objPrintHistory.m_mthPrintLine(m_intRecordWidth,((int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2),p_intPosY,p_objGrp);

					m_mthPrintValueVerLine(p_objGrp,p_intPosY,p_intPosY+30);

					if(m_objPrintHistory.m_BlnHaveNextLine())
					{
						m_blnHaveMoreLine = true;

						p_intPosY += 30;	
					}
					else
					{
						m_blnHaveMoreLine = false;

						p_intPosY += 30;

						p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX,p_intPosY,(int)enmRecordRectangleInfo.RightX,p_intPosY);
					}				
				}
			}

			public override void m_mthReset()
			{
				m_blnIsTitle = true;
				m_blnHaveMoreLine = true;

				m_objPrintHistory.m_mthRestartPrint();
			}

			/// <summary>
			/// 画标题的栏目
			/// </summary>
			/// <param name="e"></param>
			private void m_mthPrintHeaderInfo(System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText,int p_intPosY)
			{				
				p_objGrp.DrawString("病	程	记	录",p_fntNormalText,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark6-10, p_intPosY+4);
			}		

			private void m_mthPrintValueVerLine(System.Drawing.Graphics p_objGrp,int p_intPosUpY,int p_intPosDownY)
			{
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX,p_intPosUpY,
					(int)enmRecordRectangleInfo.LeftX,p_intPosDownY);
			
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,p_intPosUpY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,p_intPosDownY);
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,p_intPosUpY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,p_intPosDownY);

				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.RightX,p_intPosUpY,
					(int)enmRecordRectangleInfo.RightX,p_intPosDownY);					}

			/// <summary>
			///  画表头格子
			/// </summary>
			/// <param name="e"></param>
			private void m_mthPrintRectangleInfo(System.Drawing.Graphics p_objGrp,int p_intPosY)
			{								
				int intHeight=30;
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX,p_intPosY+intHeight,
					(int)enmRecordRectangleInfo.RightX,p_intPosY+intHeight);
			
				//画左边沿线
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX,p_intPosY,
					(int)enmRecordRectangleInfo.LeftX,p_intPosY+intHeight);
			
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,p_intPosY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,p_intPosY+intHeight);
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,p_intPosY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,p_intPosY+intHeight);

				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.RightX,p_intPosY,
					(int)enmRecordRectangleInfo.RightX,p_intPosY+intHeight);		
			
			}

			public override object m_ObjPrintLineInfo
			{
				get
				{
					return m_objPrintLineInfo;
				}
				set
				{
					clsICUIntensiveTendRecordContent_All objAllValue = (clsICUIntensiveTendRecordContent_All)value;

					if(objAllValue == null || objAllValue.m_strRecordContent == null || objAllValue.m_strRecordContent.Length == 0)
					{
						m_blnIsEmpty = true;
						return;
					}

					m_blnIsEmpty = false;

					m_objPrintHistory.m_mthSetContextWithCorrectBefore(objAllValue.m_strRecordContent,objAllValue.m_strRecordContentXML,m_dtmFirstPrintTime);

					com.digitalwave.controls.ctlRichTextBox.clsModifyUserInfo [] objUserInfoArr = m_objPrintHistory.m_ObjModifyUserArr;
					for(int i=0;i<objUserInfoArr.Length;i++)
					{
						if(objUserInfoArr[i].m_clrText.ToArgb() == Color.White.ToArgb())
						{
							objUserInfoArr[i].m_clrText = Color.Black;
						}
					}
				}
			}
		}
		#endregion

		#region 第五部分（签名）
		private class clsPrintParamInfo5 : clsPrintLineBase
		{
			string m_strSign = null;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				m_mthPrintHeaderInfo(p_objGrp,p_fntNormalText,p_intPosY);
				m_mthPrintRectangleInfo(p_objGrp,p_intPosY);

				p_objGrp.DrawString(m_strSign,p_fntNormalText,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark2+10, p_intPosY+4);

				p_intPosY += 30;

				m_blnHaveMoreLine = false;
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
			}

			/// <summary>
			/// 画标题的栏目
			/// </summary>
			/// <param name="e"></param>
			private void m_mthPrintHeaderInfo(System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText,int p_intPosY)
			{				
				p_objGrp.DrawString("签名",p_fntNormalText,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark1+1, p_intPosY+4);
			}		

			/// <summary>
			///  画表头格子
			/// </summary>
			/// <param name="e"></param>
			private void m_mthPrintRectangleInfo(System.Drawing.Graphics p_objGrp,int p_intPosY)
			{								
				int intHeight=30;
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX,p_intPosY+intHeight,
					(int)enmRecordRectangleInfo.RightX,p_intPosY+intHeight);
			
				//画左边沿线
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX,p_intPosY,
					(int)enmRecordRectangleInfo.LeftX,p_intPosY+intHeight);
			
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,p_intPosY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,p_intPosY+intHeight);
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,p_intPosY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,p_intPosY+intHeight);

				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.RightX,p_intPosY,
					(int)enmRecordRectangleInfo.RightX,p_intPosY+intHeight);		
			
			}

			public override object m_ObjPrintLineInfo
			{
				get
				{
					return m_objPrintLineInfo;
				}
				set
				{
					clsICUIntensiveTendRecordContent_All objAllValue = (clsICUIntensiveTendRecordContent_All)value;

					m_strSign = objAllValue.m_objclsICUIntensiveTendRecordContentArr[0].m_strModifyUserName;

					if(objAllValue.m_objclsICUIntensiveTendRecordContentArr.Length > 1)
					{
						m_strSign = "/"+m_strSign;
						for(int i=1;i<objAllValue.m_objclsICUIntensiveTendRecordContentArr.Length;i++)
						{
							m_strSign = objAllValue.m_objclsICUIntensiveTendRecordContentArr[i].m_strModifyUserName+" "+m_strSign;
						}
					}
				}
			}
		}
		#endregion

		#region 第六部分（汇总）
		private class clsPrintParamInfo6 : clsPrintLineBase
		{
			clsStatisticInfo_TotalInOut m_objValue = null;

//			private int m_intHeaderRowStep=50;

//			private string strInTotalValue = "ab";
//			private string strOutTotalValue = "cd";
//
//			private string strInIValue = "1";
//			private string strInDValue = "2";
//			private string strOutUValue = "3";
//			private string strOutSValue = "4";
//			private string strOutVValue = "5";
//			private string strOutEValue = "6";
			

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objValue != null)
				{
					m_mthPrintHeaderInfo(p_objGrp,p_fntNormalText,p_intPosY);
					m_mthPrintRectangleInfo(p_objGrp,p_intPosY);

					p_intPosY += 80;

					m_mthPrintSingleValue(p_objGrp,p_fntNormalText,p_intPosY);
					m_mthPrintValueVerLine(p_objGrp,p_intPosY,p_intPosY+60);
					m_mthPrintValueVerLine(p_objGrp,p_intPosY,p_intPosY+30,true);
					
					p_intPosY += 30;

					m_mthPrintTotleValue(p_objGrp,p_fntNormalText,p_intPosY);
					m_mthPrintValueVerLine(p_objGrp,p_intPosY,p_intPosY+30,false);
					p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX,p_intPosY,(int)enmRecordRectangleInfo.RightX,p_intPosY);


					p_intPosY += 30;

					p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX,p_intPosY,(int)enmRecordRectangleInfo.RightX,p_intPosY);

					m_objValue = null;
				}
				
				m_blnHaveMoreLine = false;
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
			}

			private void m_mthPrintSingleValue(System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText,int p_intPosY)
			{
				p_objGrp.DrawString("汇总",p_fntNormalText,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,p_intPosY+4);

				p_objGrp.DrawString(m_objValue.m_strTotalInI,p_fntNormalText,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10,p_intPosY);				
				p_objGrp.DrawString(m_objValue.m_strTotalInD,p_fntNormalText,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11,p_intPosY);
				p_objGrp.DrawString(m_objValue.m_strTotalOutE,p_fntNormalText,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark12,p_intPosY);
				p_objGrp.DrawString(m_objValue.m_strTotalOutU,p_fntNormalText,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark13,p_intPosY);
				p_objGrp.DrawString(m_objValue.m_strTotalOutS,p_fntNormalText,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark14,p_intPosY);
				p_objGrp.DrawString(m_objValue.m_strTotalOutV,p_fntNormalText,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15,p_intPosY);

				p_objGrp.DrawString("====",p_fntNormalText,Brushes.Red,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10,p_intPosY+12);				
				p_objGrp.DrawString("====",p_fntNormalText,Brushes.Red,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11,p_intPosY+12);
				p_objGrp.DrawString("====",p_fntNormalText,Brushes.Red,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark12,p_intPosY+12);
				p_objGrp.DrawString("====",p_fntNormalText,Brushes.Red,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark13,p_intPosY+12);
				p_objGrp.DrawString("====",p_fntNormalText,Brushes.Red,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark14,p_intPosY+12);
				p_objGrp.DrawString("====",p_fntNormalText,Brushes.Red,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15,p_intPosY+12);
			}

			private void m_mthPrintTotleValue(System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText,int p_intPosY)
			{
				p_objGrp.DrawString(m_objValue.m_strTotalIn,p_fntNormalText,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10+4,p_intPosY);
				p_objGrp.DrawString(m_objValue.m_strTotalOut,p_fntNormalText,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark12+4,p_intPosY);

				p_objGrp.DrawString("========",p_fntNormalText,Brushes.Red,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10,p_intPosY+12);
				p_objGrp.DrawString("================",p_fntNormalText,Brushes.Red,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark12,p_intPosY+12);
			}

			private void m_mthPrintValueVerLine(System.Drawing.Graphics p_objGrp,int p_intPosUpY,int p_intPosDownY,bool p_blnAll)
			{
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark12,p_intPosUpY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark12,p_intPosDownY);
			
				if(p_blnAll)
				{
					//摄入中间分界线
					p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11,p_intPosUpY,
						(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11,p_intPosDownY);
				
					//排出中间分界线
					p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark13,p_intPosUpY,
						(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark13,p_intPosDownY);			
					p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark14,p_intPosUpY,
						(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark14,p_intPosDownY);			
					p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15,p_intPosUpY,
						(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15,p_intPosDownY);
				}				
			}

			private void m_mthPrintValueVerLine(System.Drawing.Graphics p_objGrp,int p_intPosUpY,int p_intPosDownY)
			{
				#region 画格子竖线
				//画左边沿线
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX,p_intPosUpY,
					(int)enmRecordRectangleInfo.LeftX,p_intPosDownY);
			
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,p_intPosUpY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,p_intPosDownY);
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,p_intPosUpY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,p_intPosDownY);
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3,p_intPosUpY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3,p_intPosDownY);
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4,p_intPosUpY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4,p_intPosDownY);
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5,p_intPosUpY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5,p_intPosDownY);
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6,p_intPosUpY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6,p_intPosDownY);
				//瞳孔大小左右分界线
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7,p_intPosUpY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7,p_intPosDownY);
				//瞳孔大小与反射分界线
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8,p_intPosUpY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8,p_intPosDownY);
				//瞳孔反射左右分界线
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9,p_intPosUpY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9,p_intPosDownY);			
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10,p_intPosUpY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10,p_intPosDownY);

				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.RightX,p_intPosUpY,
					(int)enmRecordRectangleInfo.RightX,p_intPosDownY);		
			
			#endregion				
			}

			/// <summary>
			/// 画标题的栏目
			/// </summary>
			/// <param name="e"></param>
			private void m_mthPrintHeaderInfo(System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText,int p_intPosY)
			{			
				Font fntSmallTitle = new Font("",9);
				StringFormat strVer = new StringFormat(StringFormatFlags.DirectionVertical);
				//体温 C	
				p_objGrp.DrawString("体温",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark2+1,p_intPosY+7);
				p_objGrp.DrawString("℃",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark2+1,p_intPosY+27);
				
				//脉搏(次/分)
				p_objGrp.DrawString("脉搏",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark3+1, p_intPosY+7);
				p_objGrp.DrawString("次/分",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark3+1, p_intPosY+27);
				
				//呼吸(次/分)
				p_objGrp.DrawString("呼吸",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark4+1, p_intPosY+7);
				p_objGrp.DrawString("次/分",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark4+1, p_intPosY+27);
				
				//血压(mmHg)
				p_objGrp.DrawString("血压",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark5+8, p_intPosY+7);
				p_objGrp.DrawString("mmHg",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark5+8, p_intPosY+27);
	
				p_objGrp.DrawString(" 瞳  孔",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark7+10, p_intPosY+5);
				p_objGrp.DrawString("大小(mm)",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark6+10, p_intPosY+30);
				p_objGrp.DrawString("左",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark6+10, p_intPosY+60);
				p_objGrp.DrawString("右",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark7+10, p_intPosY+60);

				p_objGrp.DrawString("反射",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark9-20, p_intPosY+30);
				p_objGrp.DrawString("左",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark8+10, p_intPosY+60);
				p_objGrp.DrawString("右",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark9+10, p_intPosY+60);

				p_objGrp.DrawString("摄入(ml)",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark10+10, p_intPosY+5);
				p_objGrp.DrawString("输液量",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark10+10, p_intPosY+30,strVer);

				p_objGrp.DrawString("进食量",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark11+10, p_intPosY+30,strVer);

				p_objGrp.DrawString("排出(ml)",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark13+10, p_intPosY+5);
				p_objGrp.DrawString("引流量",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark12+10, p_intPosY+30,strVer);

				p_objGrp.DrawString("尿量",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark13+10, p_intPosY+30,strVer);
			
				p_objGrp.DrawString("大便",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark14+10, p_intPosY+30,strVer);
			
				p_objGrp.DrawString("呕吐物",fntSmallTitle,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+
					(int)enmRecordRectangleInfo.ColumnsMark15+10, p_intPosY+30,strVer);
				strVer.Dispose();
				fntSmallTitle.Dispose();
			}		

			/// <summary>
			///  画表头格子
			/// </summary>
			/// <param name="e"></param>
			private void m_mthPrintRectangleInfo(System.Drawing.Graphics p_objGrp,int p_intPosY)
			{								
				//画格子横线
				for(int i1=1;i1<4 /*(int)enmRecordRectangleInfo.RowLinesNum*/ ;i1++)
				{
					if(i1 !=1 && i1 !=2)
						p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX ,
							p_intPosY+80,
							(int)enmRecordRectangleInfo.RightX,
							p_intPosY+80);
					else if(i1==1)
					{
						p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+ (int)enmRecordRectangleInfo.ColumnsMark6,
							p_intPosY+25,
							(int)enmRecordRectangleInfo.RightX,
							p_intPosY+25);					
					}
					else //if(i1==2)
						p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+ (int)enmRecordRectangleInfo.ColumnsMark6,
							p_intPosY+55,
							(int)enmRecordRectangleInfo.LeftX+ (int)enmRecordRectangleInfo.ColumnsMark10,
							p_intPosY+55);
				}
		
			#region 画格子竖线
				int intHeight=80;
				//画左边沿线
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX,p_intPosY,
					(int)enmRecordRectangleInfo.LeftX,p_intPosY+intHeight);
			
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,p_intPosY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,p_intPosY+intHeight);
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,p_intPosY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,p_intPosY+intHeight);
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3,p_intPosY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3,p_intPosY+intHeight);
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4,p_intPosY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4,p_intPosY+intHeight);
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5,p_intPosY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5,p_intPosY+intHeight);
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6,p_intPosY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6,p_intPosY+intHeight);
				//瞳孔大小左右分界线
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7,p_intPosY+55,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7,p_intPosY+intHeight);
				//瞳孔大小与反射分界线
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8,p_intPosY+25,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8,p_intPosY+intHeight);
				//瞳孔反射左右分界线
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9,p_intPosY+55,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9,p_intPosY+intHeight);			
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10,p_intPosY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10,p_intPosY+intHeight);
				//摄入中间分界线
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11,p_intPosY+25,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11,p_intPosY+intHeight);
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark12,p_intPosY,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark12,p_intPosY+intHeight);
			
				//排出中间分界线
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark13,p_intPosY+25,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark13,p_intPosY+intHeight);			
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark14,p_intPosY+25,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark14,p_intPosY+intHeight);			
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15,p_intPosY+25,
					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15,p_intPosY+intHeight);
				p_objGrp.DrawLine(Pens.Black,(int)enmRecordRectangleInfo.RightX,p_intPosY,
					(int)enmRecordRectangleInfo.RightX,p_intPosY+intHeight);		
			
			#endregion				
			
			}

			public override object m_ObjPrintLineInfo
			{
				get
				{
					return m_objPrintLineInfo;
				}
				set
				{
					m_objValue = (clsStatisticInfo_TotalInOut)value;
				}
			}
		}
		#endregion
		#endregion

		#region 标题文字部分
		/// <summary>
		/// 标题文字部分
		/// </summary>
		/// <param name="e"></param>
		private void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
		{
			clsEveryRecordPageInfo objEveryRecordPageInfo=new clsEveryRecordPageInfo ();
			//************************************************
			objEveryRecordPageInfo.strAge =this.lblAge.Text;
			objEveryRecordPageInfo.strPatientName=this.m_txtPatientName.Text;
			objEveryRecordPageInfo.strBedNo =this.m_txtBedNO.Text;
			objEveryRecordPageInfo.strAreaName=this.m_cboArea.Text;
			objEveryRecordPageInfo.strSex=this.lblSex.Text;
            objEveryRecordPageInfo.strInPatientID = m_objCurrentPatient.m_StrEMRInPatientID;
			objEveryRecordPageInfo.strPrintDate=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");			

            
			e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle,m_fotSmallFont ,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_HospitalName  ));
		
			e.Graphics.DrawString("ICU 危 重 护 理 记 录 单",m_fotTitleFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_Name_Title ));
			

			e.Graphics.DrawString("姓名：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name_Title  ));
			e.Graphics.DrawString(objEveryRecordPageInfo.strPatientName  ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name ));
		
			e.Graphics.DrawString("性别：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex_Title ));
			e.Graphics.DrawString(objEveryRecordPageInfo.strSex ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex  ));

			e.Graphics.DrawString("年龄：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Age_Title ));
			e.Graphics.DrawString(objEveryRecordPageInfo.strAge ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Age ));

			e.Graphics.DrawString("病区：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Dept_Name_Title ));
			e.Graphics.DrawString(objEveryRecordPageInfo.strAreaName ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Dept_Name ));

			e.Graphics.DrawString("床号：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.BedNo_Title ));
			e.Graphics.DrawString(objEveryRecordPageInfo.strBedNo ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.BedNo ));	
			
			e.Graphics.DrawString("住院号：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID_Title ));
			e.Graphics.DrawString(objEveryRecordPageInfo.strInPatientID ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID ));	
			
			//			//在最后一行下面打印说明部分
			//			e.Graphics.DrawString("出入量代码:U--尿 S--大便 V--呕吐物 E--引流液 D--进食 I--输液",m_fotSmallFont,m_slbBrush,
			//				(int)enmRecordRectangleInfo.LeftX +(int)enmRecordRectangleInfo.ColumnsMark2,
			//				(int)enmRecordRectangleInfo.TopY+((int)enmRecordRectangleInfo.RowStep)*((int)enmRecordRectangleInfo.RowLinesNum)-20);

		}
		#endregion		
		
		/// <summary>
		/// 设置当前要打印的一条记录数据
		/// </summary>
		/// <param name="e"></param>
		/// <param name="p_intBottomY"></param>
		/// <returns></returns>
		private int m_intSetPrintOneValueRows(System.Drawing.Printing.PrintPageEventArgs e,ref int p_intBottomY)
		{			
			if(m_objclsICUIntensiveTendRecordContent_AllArr==null || m_intCurrentRecord>= m_objclsICUIntensiveTendRecordContent_AllArr.Length)
				return 0;


			if(m_objclsICUIntensiveTendRecordContent_AllArr[m_intCurrentRecord].m_objclsICUIntensiveTendRecordContentArr==null || m_objclsICUIntensiveTendRecordContent_AllArr[m_intCurrentRecord].m_objclsICUIntensiveTendRecordContentArr.Length==0)
				return 0;
			int intRowsOfOneRecord=m_objclsICUIntensiveTendRecordContent_AllArr[m_intCurrentRecord].m_objclsICUIntensiveTendRecordContentArr.Length;
			string strModifyDate=m_objclsICUIntensiveTendRecordContent_AllArr[m_intCurrentRecord].m_objclsICUIntensiveTendRecordContentArr[intRowsOfOneRecord-1].m_strModifyDate ;
		
			try
			{
				
				if(m_blnBeginPrintNewRecord==true) 
				{					
					#region  当前记录数组赋值
					int intLenth=m_objclsICUIntensiveTendRecordContent_AllArr[m_intCurrentRecord].m_objclsICUIntensiveTendRecordContentArr.Length;
					m_strValueArr=new string[intLenth][];
					for(int k1=0;k1<intLenth;k1++)
					{
						m_strValueArr[k1]=new string[15];
						m_strValueArr[k1][0]=m_objclsICUIntensiveTendRecordContent_AllArr[m_intCurrentRecord].m_objclsICUIntensiveTendRecordContentArr[k1].m_strTemperature_Last;
						m_strValueArr[k1][1]=m_objclsICUIntensiveTendRecordContent_AllArr[m_intCurrentRecord].m_objclsICUIntensiveTendRecordContentArr[k1].m_strPulse_Last;
						m_strValueArr[k1][2]=m_objclsICUIntensiveTendRecordContent_AllArr[m_intCurrentRecord].m_objclsICUIntensiveTendRecordContentArr[k1].m_strBreath_Last;
						m_strValueArr[k1][3]=m_objclsICUIntensiveTendRecordContent_AllArr[m_intCurrentRecord].m_objclsICUIntensiveTendRecordContentArr[k1].m_strBloodPressureS_Last;
						m_strValueArr[k1][4]=m_objclsICUIntensiveTendRecordContent_AllArr[m_intCurrentRecord].m_objclsICUIntensiveTendRecordContentArr[k1].m_strBloodPressureA_Last;
						m_strValueArr[k1][5]=m_objclsICUIntensiveTendRecordContent_AllArr[m_intCurrentRecord].m_objclsICUIntensiveTendRecordContentArr[k1].m_strPupilLeft_Last;
						m_strValueArr[k1][6]=m_objclsICUIntensiveTendRecordContent_AllArr[m_intCurrentRecord].m_objclsICUIntensiveTendRecordContentArr[k1].m_strPupilRight_Last;
						m_strValueArr[k1][7]=m_objclsICUIntensiveTendRecordContent_AllArr[m_intCurrentRecord].m_objclsICUIntensiveTendRecordContentArr[k1].m_strEchoLeft_Last;
						m_strValueArr[k1][8]=m_objclsICUIntensiveTendRecordContent_AllArr[m_intCurrentRecord].m_objclsICUIntensiveTendRecordContentArr[k1].m_strEchoRight_Last;
						m_strValueArr[k1][9]=m_objclsICUIntensiveTendRecordContent_AllArr[m_intCurrentRecord].m_objclsICUIntensiveTendRecordContentArr[k1].m_strInI_Last;
						m_strValueArr[k1][10]=m_objclsICUIntensiveTendRecordContent_AllArr[m_intCurrentRecord].m_objclsICUIntensiveTendRecordContentArr[k1].m_strInD_Last;
						m_strValueArr[k1][11]=m_objclsICUIntensiveTendRecordContent_AllArr[m_intCurrentRecord].m_objclsICUIntensiveTendRecordContentArr[k1].m_strOutE_Last;
						m_strValueArr[k1][12]=m_objclsICUIntensiveTendRecordContent_AllArr[m_intCurrentRecord].m_objclsICUIntensiveTendRecordContentArr[k1].m_strOutU_Last;
						m_strValueArr[k1][13]=m_objclsICUIntensiveTendRecordContent_AllArr[m_intCurrentRecord].m_objclsICUIntensiveTendRecordContentArr[k1].m_strOutS_Last;
						m_strValueArr[k1][14]=m_objclsICUIntensiveTendRecordContent_AllArr[m_intCurrentRecord].m_objclsICUIntensiveTendRecordContentArr[k1].m_strOutV_Last;
					}
					
					#endregion

					return intLenth;					
				}
				else return 0;				
			}
			catch(Exception ex)
			{
				clsPublicFunction.ShowInformationMessageBox(ex.Message);
				return 1;
			}	

			
		}		
		
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
				string strCreateDate="";
				string strCreateTime="";
				string strCreateDateTime=m_objclsICUIntensiveTendRecordContent_AllArr[m_intCurrentRecord].m_strCreateDate;
				try
				{
					strCreateDate=DateTime.Parse(strCreateDateTime).ToString("yyyy-M-d");
					strCreateTime=DateTime.Parse(strCreateDateTime).ToString("HH:mm");
				}
				catch{strCreateDate="不详";strCreateTime="不详";}	

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
			
//				#region 签名（作过修改的人签名）
//				string strSign="";
//				clsEmployee objclsEmployee=new clsEmployee(m_objclsICUIntensiveTendRecordContent_AllArr[m_intCurrentRecord].m_objclsICUIntensiveTendRecordContentArr[m_intNowRowInOneRecord].m_strModifyUserID);
//				if(objclsEmployee!=null)
//					strSign=objclsEmployee.m_StrFirstName;
//				
//				e.Graphics.DrawString(strSign ,m_fotSmallFont ,m_slbBrush,
//					(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark_Name+1, 
//					p_intBottomY);
//				#endregion

			m_blnBeginPrintNewRecord=blnIsRecordFinish;//当前记录是否打完					
			m_intNowRowInOneRecord++;
			#endregion

			return blnIsRecordFinish;				
				
			
		}

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

		/// <summary>
		/// 打印所有的垂直线
		/// </summary>
		/// <param name="e"></param>
		/// <param name="p_intPageOrRecordBottomY"></param>
		private void m_mthPrintVLines(System.Drawing.Printing.PrintPageEventArgs e,int p_intPageOrRecordBottomY,int p_intRecordTopY)
		{			
			#region 画格子竖线
			int intContentTopY=p_intRecordTopY+ 150;
			//画左边沿线
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX,p_intPageOrRecordBottomY);
			
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,p_intPageOrRecordBottomY);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,p_intPageOrRecordBottomY);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3,p_intPageOrRecordBottomY);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4,p_intPageOrRecordBottomY);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5,p_intPageOrRecordBottomY);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6,p_intPageOrRecordBottomY);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7,p_intPageOrRecordBottomY);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8,p_intPageOrRecordBottomY);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9,p_intPageOrRecordBottomY);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10,p_intPageOrRecordBottomY);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11,p_intPageOrRecordBottomY);			
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark12,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark12,p_intPageOrRecordBottomY);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark13,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark13,p_intPageOrRecordBottomY);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark14,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark14,p_intPageOrRecordBottomY);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15,intContentTopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15,p_intPageOrRecordBottomY);			
			
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.RightX ,intContentTopY,
				(int)enmRecordRectangleInfo.RightX,p_intPageOrRecordBottomY);
			#endregion		
		}

		#region 画表头格子
		/// <summary>
		///  画表头格子
		/// </summary>
		/// <param name="e"></param>
		private void m_mthPrintRectangleInfo(System.Drawing.Printing.PrintPageEventArgs e,int p_intPosY)
		{			
			//画格子横线
//			for(int i1=0;i1<4 /*(int)enmRecordRectangleInfo.RowLinesNum*/ ;i1++)
//			{
//				if(i1 !=1 && i1 !=2)
//					e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX ,
//						p_intPosY+m_intHeaderRowStep*i1,
//						(int)enmRecordRectangleInfo.RightX,
//						p_intPosY+m_intHeaderRowStep*i1);
//				else if(i1==1)
//				{
//					e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+ (int)enmRecordRectangleInfo.ColumnsMark6,
//						p_intPosY+m_intHeaderRowStep*i1-5,
//						(int)enmRecordRectangleInfo.RightX,
//						p_intPosY+m_intHeaderRowStep*i1-5);					
//				}
//				else //if(i1==2)
//					e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+ (int)enmRecordRectangleInfo.ColumnsMark6,
//						p_intPosY+m_intHeaderRowStep*i1,
//						(int)enmRecordRectangleInfo.LeftX+ (int)enmRecordRectangleInfo.ColumnsMark10,
//						p_intPosY+m_intHeaderRowStep*i1);
//			}
//			
//			#region 画格子竖线
//			int intHeight=3*m_intHeaderRowStep;
//			//画左边沿线
//			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX,p_intPosY,
//				(int)enmRecordRectangleInfo.LeftX,p_intPosY+intHeight);
//			
//			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,p_intPosY,
//				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,p_intPosY+intHeight);
//			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,p_intPosY,
//				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,p_intPosY+intHeight);
//			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3,p_intPosY,
//				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark3,p_intPosY+intHeight);
//			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4,p_intPosY,
//				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4,p_intPosY+intHeight);
//			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5,p_intPosY,
//				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5,p_intPosY+intHeight);
//			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6,p_intPosY,
//				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6,p_intPosY+intHeight);
//			//瞳孔大小左右分界线
//			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7,p_intPosY+2*m_intHeaderRowStep,
//				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7,p_intPosY+intHeight);
//			//瞳孔大小与反射分界线
//			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8,p_intPosY+m_intHeaderRowStep-5,
//				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8,p_intPosY+intHeight);
//			//瞳孔反射左右分界线
//			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9,p_intPosY+2*m_intHeaderRowStep,
//				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9,p_intPosY+intHeight);			
//			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10,p_intPosY,
//				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10,p_intPosY+intHeight);
//			//摄入中间分界线
//			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11,p_intPosY+m_intHeaderRowStep-5,
//				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11,p_intPosY+intHeight);
//			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark12,p_intPosY,
//				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark12,p_intPosY+intHeight);
//			
//			//排出中间分界线
//			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark13,p_intPosY+m_intHeaderRowStep-5,
//				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark13,p_intPosY+intHeight);			
//			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark14,p_intPosY+m_intHeaderRowStep-5,
//				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark14,p_intPosY+intHeight);			
//			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15,p_intPosY+m_intHeaderRowStep-5,
//				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark15,p_intPosY+intHeight);
//			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.RightX,p_intPosY,
//				(int)enmRecordRectangleInfo.RightX,p_intPosY+intHeight);		
//			
//			#endregion				
			
		}

						
		#endregion		
	   
		#endregion
		
		#region Liyi	
		/// <summary>
		/// 打印一次时间记录的一行数值（需完成血压斜线的打印）
		/// </summary>
		/// <param name="p_strValueArr">数值(从“体温”到“呕吐物”，共14个)</param>
		/// <param name="p_intIndex">第几次的结果</param>
		/// <param name="e">打印参数</param>
		/// <param name="p_intPosY">Y坐标</param>
		private bool m_blnPrintOneRowValue(string [][] p_strValueArr,int p_intIndex,System.Drawing.Printing.PrintPageEventArgs e,int p_intPosY)
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

			intTempColumn=2;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark4;//当前的X坐标
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

//			intTempColumn=3;
//			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5;//当前的X坐标
			bool blnIsLastModify=false;
			if( p_intIndex == p_strValueArr.Length-1 || (strValueArr[3] == p_strValueArr[p_intIndex+1][3] && strValueArr[4] == p_strValueArr[p_intIndex+1][4] && strValueArr[3] == p_strValueArr[p_strValueArr.Length-1][3] && strValueArr[4] == p_strValueArr[p_strValueArr.Length-1][4] ))
			{// 当存在下一行，并且当前元素 != 下一行此元素				
				blnIsLastModify=true;					
			}
			//血压(收缩压)
			if(strValueArr[3].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[3],m_fotSmallFont,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5,p_intPosY-15);
				if( ! blnIsLastModify)
				{					
					rtfText.X = (int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5;
					rtfText.Y = p_intPosY-15;

					rgnDSTArr[0].First = 0;
					rgnDSTArr[0].Length = strValueArr[3].Length;

					stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

					rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[3],m_fotSmallFont,rtfText,stfMeasure);

					rtfBounds = rgnDST[0].GetBounds(e.Graphics);

					e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
					e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
					
				}
			}		

			//血压(舒张压)
			if(strValueArr[4].Trim().Length != 0)
			{
				e.Graphics.DrawString(strValueArr[4],m_fotSmallFont,Brushes.Black,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5+30,p_intPosY);
				if( ! blnIsLastModify)
				{					
					rtfText.X = (int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark5+30;
					rtfText.Y = p_intPosY;

					rgnDSTArr[0].First = 0;
					rgnDSTArr[0].Length = strValueArr[4].Length;

					stfMeasure.SetMeasurableCharacterRanges(rgnDSTArr);					

					rgnDST = e.Graphics.MeasureCharacterRanges(strValueArr[4],m_fotSmallFont,rtfText,stfMeasure);

					rtfBounds = rgnDST[0].GetBounds(e.Graphics);

					e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2);
					e.Graphics.DrawLine(Pens.Red,rtfBounds.X,rtfBounds.Y+rtfBounds.Height/2+3,rtfBounds.X+rtfBounds.Width,rtfBounds.Y+rtfBounds.Height/2+3);
					
				}
			}


			intTempColumn=5;
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark6;//当前的X坐标
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
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark7;//当前的X坐标
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
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark8;//当前的X坐标
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
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark9;//当前的X坐标
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
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark10;//当前的X坐标
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
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark11;//当前的X坐标
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
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark12;//当前的X坐标
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
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark13;//当前的X坐标
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
			intPosX=(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark14;//当前的X坐标
			//大便量
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

		#region 自动测试部分
		public enmAutoTestResult i_enmTestDelete(com.digitalwave.Utility.clsTestContentMaker p_objContentMaker, out string p_strInnerMessage)
		{					
			p_strInnerMessage = "";				
			return enmAutoTestResult.Succeed;
		}
		
		public enmAutoTestResult i_enmTestDisplay(com.digitalwave.Utility.clsTestContentMaker p_objContentMaker, out string p_strInnerMessage)
		{			
			p_strInnerMessage = "";				
			return enmAutoTestResult.Succeed;
		}
		
		public enmAutoTestResult i_enmTestModify(com.digitalwave.Utility.clsTestContentMaker p_objContentMaker, out string p_strInnerMessage)
		{
			if(txtInPatientID.Text!="0000002")
			{
				txtInPatientID.Text="0000002";
				if(m_lsvInPatientID.Items.Count>0)
				{
					m_lsvInPatientID.Items[p_objContentMaker.m_intNextSelectIndex(m_lsvInPatientID,m_lsvInPatientID.Items.Count-1)].Selected=true;
					m_mthSetPatientInfo((clsPatient)m_lsvInPatientID.SelectedItems[0].Tag);			
				}					
				else 
				{
					p_strInnerMessage ="";
					return enmAutoTestResult.Succeed;
				}
			}

			m_trvTime.SelectedNode = p_objContentMaker.m_trnNextTreeViewNode(m_trvTime);
			m_mthClearUp2();			

			m_txtBloodPressureA.Text = p_objContentMaker.m_strNextTextValue(m_txtBloodPressureA,p_objContentMaker.m_ObjDigitalValueType);
			m_txtBloodPressureS.Text = p_objContentMaker.m_strNextTextValue(m_txtBloodPressureS,p_objContentMaker.m_ObjDigitalValueType);
			m_txtBreath.Text = p_objContentMaker.m_strNextTextValue(m_txtBreath,p_objContentMaker.m_ObjDigitalValueType);
			string strTemp= p_objContentMaker.m_strNextTextValue(m_txtEchoLeft,p_objContentMaker.m_ObjStringValueType);
			if(strTemp.Length>5000)
				m_txtEchoLeft.Text =strTemp.Substring(0,5000);
			else m_txtEchoLeft.Text =strTemp;
			strTemp= p_objContentMaker.m_strNextTextValue(m_txtEchoRight,p_objContentMaker.m_ObjStringValueType);			
			if(strTemp.Length>5000)
				m_txtEchoRight.Text =strTemp.Substring(0,5000);
			else m_txtEchoRight.Text=strTemp;			
			m_txtInD.Text = p_objContentMaker.m_strNextTextValue(m_txtInD,p_objContentMaker.m_ObjDigitalValueType);			
			m_txtInI.Text = p_objContentMaker.m_strNextTextValue(m_txtInI,p_objContentMaker.m_ObjDigitalValueType);			
			m_txtOutE.Text = p_objContentMaker.m_strNextTextValue(m_txtOutE,p_objContentMaker.m_ObjDigitalValueType);			
			m_txtOutS.Text = p_objContentMaker.m_strNextTextValue(m_txtOutS,p_objContentMaker.m_ObjDigitalValueType);			
			m_txtOutU.Text = p_objContentMaker.m_strNextTextValue(m_txtOutU,p_objContentMaker.m_ObjDigitalValueType);			
			m_txtOutV.Text = p_objContentMaker.m_strNextTextValue(m_txtOutV,p_objContentMaker.m_ObjDigitalValueType);			
			m_txtPulse.Text = p_objContentMaker.m_strNextTextValue(m_txtPulse,p_objContentMaker.m_ObjDigitalValueType);
			m_txtPupilLeft.Text = p_objContentMaker.m_strNextTextValue(m_txtPupilLeft,p_objContentMaker.m_ObjDigitalValueType);
			m_txtPupilRight.Text = p_objContentMaker.m_strNextTextValue(m_txtPupilRight,p_objContentMaker.m_ObjDigitalValueType);			
			strTemp= p_objContentMaker.m_strNextTextValue(m_txtRecordContent,p_objContentMaker.m_ObjStringValueType);
			if(strTemp.Length>90000)
				m_txtRecordContent.Text = strTemp.Substring(0,90000);
			else m_txtRecordContent.Text =strTemp;
			m_txtTemperature.Text = p_objContentMaker.m_strNextTextValue(m_txtTemperature,p_objContentMaker.m_ObjDigitalValueType);
			
			strTemp= p_objContentMaker.m_strNextTextValue(m_txtSenses,p_objContentMaker.m_ObjStringValueType);			
			if(strTemp.Length>5000)
				m_txtSenses.Text =strTemp.Substring(0,5000);
			else m_txtSenses.Text=strTemp;	
			
			strTemp= p_objContentMaker.m_strNextTextValue(m_txtPhlegmAttribute,p_objContentMaker.m_ObjStringValueType);			
			if(strTemp.Length>5000)
				m_txtPhlegmAttribute.Text =strTemp.Substring(0,5000);
			else m_txtPhlegmAttribute.Text=strTemp;	
			
			long lngRes = m_lngSaveWithoutMessageBox();//由Save()函数屏蔽掉MessageBox提示,换成返回一个整数值而成(同时去掉所有相关函数中的MessageBox提示,换成返回一个整数值)
			p_strInnerMessage = " "+lngRes.ToString();
		
			if(lngRes > 0)
				return enmAutoTestResult.Succeed;
			else
				return enmAutoTestResult.Failure;
		}
		
		public enmAutoTestResult i_enmTestAddNew(com.digitalwave.Utility.clsTestContentMaker p_objContentMaker, out string p_strInnerMessage)
		{
			if(txtInPatientID.Text!="0000002")
			{
				txtInPatientID.Text="0000002";//药品收费中0000000455等有数据，检验收费中0000000451等有数据
				if(m_lsvInPatientID.Items.Count>0)
				{
					m_lsvInPatientID.Items[p_objContentMaker.m_intNextSelectIndex(m_lsvInPatientID,m_lsvInPatientID.Items.Count-1)].Selected=true;
					m_mthSetPatientInfo((clsPatient)m_lsvInPatientID.SelectedItems[0].Tag);			
				}					
				else 
				{
					p_strInnerMessage ="";
					return enmAutoTestResult.Succeed;
				}
			}

			//m_trvTime.SelectedNode = p_objContentMaker.m_trnNextTreeViewNode(m_trvTime);
			m_mthClearUp2();
			m_blnCanLikeSeaching=false;
			m_dtpRecordTime.Value=m_dtpRecordTime.Value.AddSeconds(1);
			m_blnCanLikeSeaching=true;
			m_dtpRecordTime.Enabled=true;

			m_txtBloodPressureA.Text = p_objContentMaker.m_strNextTextValue(m_txtBloodPressureA,p_objContentMaker.m_ObjDigitalValueType);
			m_txtBloodPressureS.Text = p_objContentMaker.m_strNextTextValue(m_txtBloodPressureS,p_objContentMaker.m_ObjDigitalValueType);
			m_txtBreath.Text = p_objContentMaker.m_strNextTextValue(m_txtBreath,p_objContentMaker.m_ObjDigitalValueType);
			string strTemp= p_objContentMaker.m_strNextTextValue(m_txtEchoLeft,p_objContentMaker.m_ObjStringValueType);
			if(strTemp.Length>5000)
				m_txtEchoLeft.Text =strTemp.Substring(0,5000);
			else m_txtEchoLeft.Text =strTemp;
			strTemp= p_objContentMaker.m_strNextTextValue(m_txtEchoRight,p_objContentMaker.m_ObjStringValueType);			
			if(strTemp.Length>5000)
				m_txtEchoRight.Text =strTemp.Substring(0,5000);
			else m_txtEchoRight.Text=strTemp;		
			m_txtInD.Text = p_objContentMaker.m_strNextTextValue(m_txtInD,p_objContentMaker.m_ObjDigitalValueType);			
			m_txtInI.Text = p_objContentMaker.m_strNextTextValue(m_txtInI,p_objContentMaker.m_ObjDigitalValueType);			
			m_txtOutE.Text = p_objContentMaker.m_strNextTextValue(m_txtOutE,p_objContentMaker.m_ObjDigitalValueType);			
			m_txtOutS.Text = p_objContentMaker.m_strNextTextValue(m_txtOutS,p_objContentMaker.m_ObjDigitalValueType);			
			m_txtOutU.Text = p_objContentMaker.m_strNextTextValue(m_txtOutU,p_objContentMaker.m_ObjDigitalValueType);			
			m_txtOutV.Text = p_objContentMaker.m_strNextTextValue(m_txtOutV,p_objContentMaker.m_ObjDigitalValueType);			
			m_txtPulse.Text = p_objContentMaker.m_strNextTextValue(m_txtPulse,p_objContentMaker.m_ObjDigitalValueType);
			m_txtPupilLeft.Text = p_objContentMaker.m_strNextTextValue(m_txtPupilLeft,p_objContentMaker.m_ObjDigitalValueType);
			m_txtPupilRight.Text = p_objContentMaker.m_strNextTextValue(m_txtPupilRight,p_objContentMaker.m_ObjDigitalValueType);
			strTemp= p_objContentMaker.m_strNextTextValue(m_txtRecordContent,p_objContentMaker.m_ObjStringValueType);			
			if(strTemp.Length>90000)
				m_txtRecordContent.Text = strTemp.Substring(0,90000);
			else m_txtRecordContent.Text =strTemp;

			m_txtTemperature.Text = p_objContentMaker.m_strNextTextValue(m_txtTemperature,p_objContentMaker.m_ObjDigitalValueType);
			
			long lngRes = m_lngSaveWithoutMessageBox();//由Save()函数屏蔽掉MessageBox提示,换成返回一个整数值而成(同时去掉所有相关函数中的MessageBox提示,换成返回一个整数值)
			p_strInnerMessage = " "+lngRes.ToString();
		
			if(lngRes > 0)
				return enmAutoTestResult.Succeed;
			else
				return enmAutoTestResult.Failure;
		}
		#endregion
	}
}

