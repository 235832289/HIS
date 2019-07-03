
using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;
using System.Windows.Forms;
namespace iCare
{
	/// <summary>
	/// 候产记录打印工具类 
	/// </summary>
	public class clsWaitLayRecord_AcadPrintTool: infPrintRecord
	{
		private bool m_blnIsFromDataSource=true;//表明是从数据库读取还是从文件直接提取信息
		private bool m_blnWantInit=true;		
		private clsPrintInfo_InPatientCaseHistory m_objPrintInfo;
		private clsBaseCaseHistoryDomain m_objRecordsDomain;
		public string m_strLaycount  = ""; //产次
		public string m_strBirthDate  = "";// 产期
        private com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
        //private com.digitalwave.clsRecordsService.clsWaitLayRecord_AcadService m_objInRoomSvc;
		private clsIcuAcad_WaitLayRecord[] m_objResultArr = null;
		private	clsPatient m_objPatient = null;
		DateTime m_dtInHos ;

		public clsWaitLayRecord_AcadPrintTool()
		{
            //m_objInRoomSvc = new com.digitalwave.clsRecordsService.clsWaitLayRecord_AcadService();
			m_strTitle = "候 产 记 录";
		
		}

		#region 设置打印列宽与每列的横坐标变量

		///<summary>
		///变量：第1列宽度
		///</summary>
		float m_fltFirstCol ; //第1列宽度
		///<summary>
		///变量：第2列宽度
		///</summary>
		float m_fltSeconCol ; //第2列宽度
		///<summary>
		///变量：第3列宽度
		///</summary>
		float m_fltthCol ; //第3列宽度
		///<summary>
		///变量：第4列宽度
		///</summary>
		float m_fltthirCol ; //第4列宽度
		///<summary>
		///变量：第5列宽度
		///</summary>
		float m_fltFiveCol ; //第5列宽度
		///<summary>
		///变量：第6列宽度
		///</summary>
		float m_fltSixCol ; //第6列宽度
		///<summary>
		///变量：第7列宽度
		///</summary>
		float m_fltSenCol; //第7列宽度
		///<summary>
		///变量：第8列宽度
		///</summary>
		float m_fltNigCol; //第8列宽度
		///<summary>
		///变量：第9列宽度
		///</summary>
		float m_fltNiNeCol ; 
		///<summary>
		///变量：第10列宽度
		///</summary>
		float m_fltCol10 ; 
		///<summary>
		///变量：第11列宽度
		///</summary>
		float m_fltCol11 ;
		///<summary>
		///变量：第12列宽度
		///</summary>
		float m_fltCol12 ;
		///<summary>
		///变量：第13列宽度
		///</summary>
		float m_fltCol13 ;
		///<summary>
		///变量：第14列宽度
		///</summary>
		float m_fltCol14 ; 


		///<summary>
		///变量：第1列Left坐际
		///</summary>
		float m_fltFirstColLeft  ; //第1列Left坐际
		///<summary>
		///变量：第2列Left坐际
		///</summary>
		float m_fltSeconColLeft; //第2列Left坐际
		///<summary>
		///变量：第3列Left坐际
		///</summary>
		float m_fltthColLeft ; //第3列Left坐际
		///<summary>
		///变量：第4列Left坐际
		///</summary>
		float m_fltthirColLeft; //第4列Left坐际
		///<summary>
		///变量：第5列Left坐际
		///</summary>
		float m_fltFiveColLeft ; //第5列Left坐际
		///<summary>
		///变量：第6列Left坐际
		///</summary>
		float m_fltSixColLeft ; //第6列Left坐际
		///<summary>
		///变量：第7列Left坐际
		///</summary>
		float m_fltSenColLeft ; //第7列Left坐际
		///<summary>
		///变量：第8列Left坐际
		///</summary>
		float m_fltNigColLeft ; //第8列Left坐际
		///<summary>
		///变量：第9列Left坐际
		///</summary>
		float m_fltNiNeColLeft ; //第9列Left坐际
		///<summary>
		///变量：第10列Left坐际
		///</summary>
		float m_fltColLeft10 ; 
		///<summary>
		///变量：第11列Left坐际
		///</summary>
		float m_fltColLeft11 ; 
		///<summary>
		///变量：第12列Left坐际
		///</summary>
		float m_fltColLeft12 ; 
		///<summary>
		///变量：第13列Left坐际
		///</summary>
		float m_fltColLeft13 ; 
		///<summary>
		///变量：第14列Left坐际
		///</summary>
		float m_fltColLeft14 ; 

		///<summary>
		///变量：第14列rigth坐际
		///</summary>
		float m_fltColLeft15 ; 
		#endregion

		#region 打印设置变量
		/// <summary>
		/// 打印标题的字体
		/// </summary>	
		private System.Drawing.Font m_fontTitle = new System.Drawing.Font("宋体",18,FontStyle.Bold);
		/// <summary>
		/// 打印的标题目
		/// </summary>	
		public  string m_strTitle;
		/// <summary>
		/// Pen对象
		/// </summary>
		private Pen m_objPen = new Pen(Color.Black);
		/// <summary>
		/// brush
		/// </summary>	
		private System.Drawing.Brush m_objBrush = System.Drawing.Brushes.Black;
		/// <summary>
		/// 打印正文的字体
		/// </summary>	
		private System.Drawing.Font m_fontBody = new System.Drawing.Font("宋体",10);
		/// <summary>
		/// 记录打印的高度落点位
		/// </summary>	
		public  float m_fltLocationY =0;
		///<summary>
		///变量：字与线间的位置高 ：间距
		///</summary>
		private float m_fltZijiHeight = 6; //字与线间的位置高 ：间距
		///<summary>
		///变量：打印的当前页数
		///</summary>
		private int m_intCurrentPageIndex = 1;
		///<summary>
		///变量：正本字体的高度
		///</summary>
		private SizeF m_objsize ;
		///<summary>
		///变量：字高
		///</summary>
		private float m_fltZiHeight;
		///<summary>
		///变量：字宽
		///</summary>
		private float m_fltZiWidth;
		///<summary>
		///变量：字与表格的左距离：间距
		///</summary>
		private float m_fltZiJiWide = 0 ;// 字与表格的左距离：间距
		///<summary>
		///变量：行高
		///</summary>
		private float m_ftlRowHeight;
		///<summary>
		///变量：行宽
		///</summary>
		private float m_fltAvgCol;
        /// <summary>
        /// 医院标题(宋体，加粗，小三)
        /// </summary>
        private Font m_fotHospitalFont;

		#endregion 

		#region 方法:初始化每一列的位置
		/// <summary>
		/// 方法:初始化每一列的位置
		/// </summary>		
		private void mthInitColLocation(PrintPageEventArgs e)
		{
			#region 设置打印列宽与每列的横坐标

//			int col  = (e.MarginBounds.Width)/14 ;
			int col  = (e.PageBounds.Width-20)/15 ;
			m_fltAvgCol = col;
//			int col = e.MarginBounds.Width/14;
			float fltCol = float.Parse(col.ToString());
			m_fltFirstCol = fltCol; //第1列宽度

			m_fltSeconCol = fltCol; //第2列宽度

			m_fltthCol = fltCol; //第3列宽度

			m_fltthirCol = fltCol; //第4列宽度

			m_fltFiveCol = fltCol; //第5列宽度

			m_fltSixCol = fltCol; //第6列宽度

			m_fltSenCol = fltCol; //第7列宽度

			m_fltNigCol = fltCol; //第8列宽度

			m_fltNiNeCol = fltCol; //第9列宽度

			this.m_fltCol10 = fltCol;
			this.m_fltCol11 = fltCol;
			this.m_fltCol12 = fltCol;
			this.m_fltCol13 = fltCol;
			this.m_fltCol14 = fltCol;

//			m_fltFirstColLeft = e.MarginBounds.Left - 10 ; //第1列Left坐际
			m_fltFirstColLeft = e.PageBounds.Left +40  ; //第1列Left坐际
			m_fltSeconColLeft = m_fltFirstCol + m_fltFirstColLeft; //第2列Left坐际
			m_fltthColLeft = m_fltSeconColLeft + m_fltSeconCol; //第3列Left坐际
			m_fltthirColLeft = m_fltthColLeft + m_fltthCol; //第4列Left坐际
			m_fltFiveColLeft = m_fltthirColLeft + m_fltthirCol; //第5列Left坐际
			m_fltSixColLeft = m_fltFiveColLeft + m_fltFiveCol; //第6列Left坐际
			m_fltSenColLeft = m_fltSixColLeft + m_fltSixCol; //第7列Left坐际
			m_fltNigColLeft = m_fltSenColLeft + m_fltSenCol; //第8列Left坐际
			m_fltNiNeColLeft = m_fltNigColLeft + m_fltNiNeCol; //第9列Left坐际
			this.m_fltColLeft10 = m_fltNiNeColLeft + m_fltNiNeCol;
			this.m_fltColLeft11 = m_fltColLeft10 + m_fltCol10;
			this.m_fltColLeft12 = m_fltColLeft11 + m_fltCol11;
			this.m_fltColLeft13 = m_fltColLeft12 + m_fltCol12;
			this.m_fltColLeft14 = m_fltColLeft13 + m_fltCol13;
			this.m_fltColLeft15 = m_fltColLeft14 + m_fltCol14 ;
			#endregion

			m_objsize = e.Graphics.MeasureString("测试",this.m_fontBody);
			m_fltZiHeight = m_objsize.Height ;// 字高
			m_ftlRowHeight =  m_fltZijiHeight + m_fltZiHeight;//行高

		}
		#endregion

		#region 设置打印信息(当从数据库读取时要首先调用.
		/// <summary>
		/// 设置打印信息(当从数据库读取时要首先调用.)
		/// </summary>
		/// <param name="p_objPatient">病人</param>
		/// <param name="p_dtmInPatientDate">入院日期</param>
		/// <param name="p_dtmOpenDate">OpenDate，如果是一次打印多次记录表单的类型（如病案记录），忽略OpenDate</param>
		public void m_mthSetPrintInfo(clsPatient p_objPatient,DateTime p_dtmInPatientDate,DateTime p_dtmOpenDate)
		{			
			m_objPatient = p_objPatient;
			m_dtInHos = p_dtmInPatientDate;
			//从主表中获取所有没删除的数据
            com.digitalwave.clsRecordsService.clsWaitLayRecord_AcadService m_objInRoomSvc =
                (com.digitalwave.clsRecordsService.clsWaitLayRecord_AcadService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsRecordsService.clsWaitLayRecord_AcadService));

            m_objInRoomSvc.m_lngGetAllMainRecord(p_objPatient.m_StrInPatientID, p_dtmInPatientDate.ToString(), out m_objResultArr);

            //clsRecordsDomain m_objRecordDomain = new clsRecordsDomain(enmRecordsType.WaitLayRecord_Acad);
            //m_objRecordDomain.m_lngGetTransDataInfoArr(p_objPatient.m_StrInPatientID, p_dtmInPatientDate.ToString(), out m_objResultArr);
		
		}

		#endregion 

		#region 从数据库初始化打印内容。如果没有记录，打印空报表。(当从数据库读取时要调用.)
		/// <summary>
		/// 从数据库初始化打印内容。如果没有记录，打印空报表。(当从数据库读取时要调用.)
		/// </summary>
		public void m_mthInitPrintContent()
		{	
		}
		#endregion 

		#region 设置打印内容。(当数据已经存在时使用。)
		/// <summary>
		/// 设置打印内容。(当数据已经存在时使用。)
		/// </summary>
		/// <param name="p_objPrintContent">打印内容</param>
		public void m_mthSetPrintContent(object p_objPrintContent)
		{
		}
		#endregion

		#region 获取打印内容,(当从数据库读取时,调用本函数之前请首先调用m_mthSetPrintInfo函数)
		/// <summary>
		/// 获取打印内容,(当从数据库读取时,调用本函数之前请首先调用m_mthSetPrintInfo函数)
		/// </summary>
		/// <returns>打印内容</returns>
		public object m_objGetPrintInfo()
		{	
			if(m_blnIsFromDataSource )
			{
                if (m_objResultArr == null)
				{
					MDIParent.ShowInformationMessageBox("当从数据库读取时,调用m_objGetPrintInfo之前请首先调用m_mthSetPrintInfo函数");
					return null;
				}				
			}			
		
			//没有记录内容时，返回空
            if (m_objResultArr.Length== 0)
				return null;
			else
                return m_objResultArr;
		}

		#endregion 

		#region 初始化打印变量,本例传入空对象即可.

		/// <summary>
		/// 初始化打印变量,本例传入空对象即可.
		/// </summary>
		public void m_mthInitPrintTool(object p_objArg)
        {
            #region 有关打印初始化
            //				
//			m_fotTitleFont = new Font("SimSun", 16,FontStyle.Bold);
//			m_fotHeaderFont = new Font("SimSun", 18,FontStyle.Bold);
//			m_fotItemHead = new Font("",13,FontStyle.Bold);
//			m_fotSmallFont = new Font("SimSun",12);
//			m_GridPen = new Pen(Color.Black,2);
//			m_slbBrush = new SolidBrush(Color.Black);
//			m_objPageSetting = new clsPrintPageSettingForRecord();
            m_fotHospitalFont = new Font("宋体", 15, FontStyle.Bold);	
            #endregion 有关打印初始化
        }

		#endregion

		#region 释放打印变量
		/// <summary>
		/// 释放打印变量
		/// </summary>
		public void m_mthDisposePrintTools(object p_objArg)
		{
//			m_fotTitleFont.Dispose() ;
//			m_fotHeaderFont.Dispose() ;
//			m_fotSmallFont.Dispose() ;
//			m_GridPen.Dispose() ;
//			m_slbBrush.Dispose() ;
		}
		#endregion
		
		#region 打印

		#region  打印开始
		/// <summary>
		/// 打印开始
		/// </summary>
		/// <param name="p_objPrintArg">此处p_objPrintArg要求为PrintEventArgs类型的对象</param>
		public void m_mthBeginPrint(object p_objPrintArg)
		{	
			reset();
//			m_mthBeginPrintSub((PrintEventArgs)p_objPrintArg);
		}
		#endregion

		#region 打印中
		/// <summary>
		/// 打印中
		/// </summary>
		/// <param name="p_objPrintArg">此处p_objPrintArg要求为PrintPageEventArgs类型的对象</param>
		public void m_mthPrintPage(object p_objPrintArg)
		{
		  PrintPageEventArgs e =  (PrintPageEventArgs)p_objPrintArg;
            //e.PageSettings.Margins.Left = 0;
            //e.PageSettings.Margins.Right = 0;
			m_mthPrintTitleInfo(e);
			m_mthPrintFormTitleInfo(e,this.m_objPatient,ref this.m_fltLocationY);
			mthInitColLocation(e);
			m_mthPrintFormHeader(e,ref this.m_fltLocationY);
			m_mthPrintAllPage(e,ref this.m_fltLocationY);
		}

		#endregion 

		#region 打印每页
		private void reset()
		{
		m_intCurrentPageIndex = 1;
		this.m_fltLocationY = 0;

		}
		private int i =0;
//		private int intPageSize =3;

		private void m_mthPrintAllPage(System.Drawing.Printing.PrintPageEventArgs e,ref float p_objLocationY)
		{
			string print = "";
			if(m_objResultArr.Length <=0)
				return ;

			//计算第一页还能打印出多少条记录
			int intRowCount = Convert.ToInt32((float.Parse(e.MarginBounds.Height.ToString()) - p_objLocationY)/m_ftlRowHeight);
			intRowCount--; //因为留出一行位置来打印页脚 ，所以显示总行数为减1

			if(m_intCurrentPageIndex == 1)
			{
				
				for(  i = 0; i< m_objResultArr.Length && i <= intRowCount;i++)
				{
		
					#region draw one row
					print = m_objResultArr[i].m_dtmRecordDate.Date.ToString("yy/MM/dd");
					m_mthDrawStrAtRectangle(this.m_fltFirstColLeft,this.m_fltSeconColLeft, print,p_objLocationY,e);

					print = m_objResultArr[i].m_dtmRecordDate.ToShortTimeString();
					m_mthDrawStrAtRectangle(this.m_fltSeconColLeft,this.m_fltthColLeft, print ,p_objLocationY,e);

					print = m_objResultArr[i].m_strBloodPressure_chr + "/" + m_objResultArr[i].m_strBloodPressure2_chr;
					m_mthDrawStrAtRectangle(this.m_fltthColLeft,this.m_fltthirColLeft, print,p_objLocationY,e);

					print = m_objResultArr[i].m_strEmbryoLocation_chr;
					m_mthDrawStrAtRectangle(this.m_fltthirColLeft,this.m_fltFiveColLeft, print,p_objLocationY,e);

					print = m_objResultArr[i].m_strEmbryoHeart_chr;
					m_mthDrawStrAtRectangle(this.m_fltFiveColLeft,this.m_fltSixColLeft, print,p_objLocationY,e);
				
					print = m_objResultArr[i].m_strIntermission_chr;
					m_mthDrawStrAtRectangle(this.m_fltSixColLeft,this.m_fltSenColLeft, print,p_objLocationY  ,e);

					print = m_objResultArr[i].m_strPersist_chr;
					m_mthDrawStrAtRectangle(this.m_fltSenColLeft,this.m_fltNigColLeft, print,p_objLocationY ,e);
				
					print = m_objResultArr[i].m_strIntensity_chr;
					m_mthDrawStrAtRectangle(this.m_fltNigColLeft,this.m_fltNiNeColLeft, print,p_objLocationY ,e);

					print = m_objResultArr[i].m_strPalaceMouth_chr;
					m_mthDrawStrAtRectangle(this.m_fltNiNeColLeft,this.m_fltColLeft10, print,p_objLocationY,e);

					print = m_objResultArr[i].m_strShow_chr;				
					m_mthDrawStrAtRectangle(this.m_fltColLeft10,this.m_fltColLeft11, print,p_objLocationY,e);

					print = m_objResultArr[i].m_strCaul_chr;
					m_mthDrawStrAtRectangle(this.m_fltColLeft11,this.m_fltColLeft12, print,p_objLocationY,e);
							
					print = m_objResultArr[i].m_strAnusCheck_chr;
					m_mthDrawStrAtRectangle(this.m_fltColLeft12,this.m_fltColLeft13, print,p_objLocationY,e);

					print = m_objResultArr[i].m_strOther_chr;
					m_mthDrawStrAtRectangle(this.m_fltColLeft13,this.m_fltColLeft14, print,p_objLocationY,e);

                    clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
                    objEmployeeSign.m_lngGetEmpByID(m_objResultArr[i].m_strScrutator_chr, out objEmpVO);
                    if (objEmpVO == null)
                        print = m_objResultArr[i].m_strScrutator_chr;
                    else
                        print = objEmpVO.m_strLASTNAME_VCHR;
					m_mthDrawStrAtRectangle(this.m_fltColLeft14,this.m_fltColLeft15, print,p_objLocationY,e);

					m_mthDrawLines(e);

					p_objLocationY += this.m_ftlRowHeight;
					#endregion 
								
				}
				m_mthPrintFoot(e);
				//判断是否多页
					if( i < this.m_objResultArr.Length-1)
					{
							m_intCurrentPageIndex ++;
						e.HasMorePages = true;
					}			
			}
			else
			{
				int temp = i;

				#region draw one row

				for(  ; i< m_objResultArr.Length && i < intRowCount + temp;i++)
				{
		
					print = m_objResultArr[i].m_dtmCreateDate.Date.ToString("yy/MM/dd");
					m_mthDrawStrAtRectangle(this.m_fltFirstColLeft,this.m_fltSeconColLeft, print,p_objLocationY,e);

					print = m_objResultArr[i].m_dtmCreateDate.ToShortTimeString();
					m_mthDrawStrAtRectangle(this.m_fltSeconColLeft,this.m_fltthColLeft, print ,p_objLocationY,e);

					print = m_objResultArr[i].m_strBloodPressure_chr + "/" + m_objResultArr[i].m_strBloodPressure2_chr;
					m_mthDrawStrAtRectangle(this.m_fltthColLeft,this.m_fltthirColLeft, print,p_objLocationY,e);

					print = m_objResultArr[i].m_strEmbryoLocation_chr;
					m_mthDrawStrAtRectangle(this.m_fltthirColLeft,this.m_fltFiveColLeft, print,p_objLocationY,e);

					print = m_objResultArr[i].m_strEmbryoHeart_chr;
					m_mthDrawStrAtRectangle(this.m_fltFiveColLeft,this.m_fltSixColLeft, print,p_objLocationY,e);
				
					print = m_objResultArr[i].m_strIntermission_chr;
					m_mthDrawStrAtRectangle(this.m_fltSixColLeft,this.m_fltSenColLeft, print,p_objLocationY  ,e);

					print = m_objResultArr[i].m_strPersist_chr;
					m_mthDrawStrAtRectangle(this.m_fltSenColLeft,this.m_fltNigColLeft, print,p_objLocationY ,e);
				
					print = m_objResultArr[i].m_strIntensity_chr;
					m_mthDrawStrAtRectangle(this.m_fltNigColLeft,this.m_fltNiNeColLeft, print,p_objLocationY ,e);

					print = m_objResultArr[i].m_strAnusCheck_chr;
					m_mthDrawStrAtRectangle(this.m_fltNiNeColLeft,this.m_fltColLeft10, print,p_objLocationY,e);

					print = m_objResultArr[i].m_strShow_chr;				
					m_mthDrawStrAtRectangle(this.m_fltColLeft10,this.m_fltColLeft11, print,p_objLocationY,e);

					print = m_objResultArr[i].m_strCaul_chr;
					m_mthDrawStrAtRectangle(this.m_fltColLeft11,this.m_fltColLeft12, print,p_objLocationY,e);
							
					print = m_objResultArr[i].m_strAnusCheck_chr;
					m_mthDrawStrAtRectangle(this.m_fltColLeft12,this.m_fltColLeft13, print,p_objLocationY,e);

					print = m_objResultArr[i].m_strOther_chr;
					m_mthDrawStrAtRectangle(this.m_fltColLeft13,this.m_fltColLeft14, print,p_objLocationY,e);

                    print = m_objResultArr[i].m_strScrutator_chr_RIGHT;
                    clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
                    objEmployeeSign.m_lngGetEmpByID(m_objResultArr[i].m_strScrutator_chr, out objEmpVO);
                    if (objEmpVO == null)
                        print = m_objResultArr[i].m_strScrutator_chr;
                    else
                        print = objEmpVO.m_strLASTNAME_VCHR;
					m_mthDrawStrAtRectangle(this.m_fltColLeft14,this.m_fltColLeft15, print,p_objLocationY,e);

					m_mthDrawLines(e);

					p_objLocationY += this.m_ftlRowHeight;
								
				}

				#endregion 

				m_mthPrintFoot(e);

				//判断是否多页

					if( intRowCount < m_objResultArr.Length-i-1)
					{
						m_intCurrentPageIndex ++;
						e.HasMorePages = true;
						return;
					}
					
			}
		}

		#endregion 


		#region 画线
		private void m_mthDrawLines(PrintPageEventArgs e)
		{
			Graphics g = e.Graphics;
			for(int i1 = 0 ;i1 < 15; i1 ++)
			{
				g.DrawLine(this.m_objPen , this.m_fltFirstColLeft + this.m_fltAvgCol * i1,this.m_fltLocationY, this.m_fltFirstColLeft + this.m_fltAvgCol * i1,this.m_fltLocationY + this.m_ftlRowHeight);
			}
			g.DrawLine(this.m_objPen , this.m_fltFirstColLeft ,this.m_fltLocationY + this.m_ftlRowHeight, this.m_fltColLeft15,this.m_fltLocationY + this.m_ftlRowHeight);


		}
		#endregion 

		//打印页脚
		private void m_mthPrintFoot(PrintPageEventArgs e)
		{
			string str = "第"+this.m_intCurrentPageIndex.ToString()+"页";
			SizeF s = e.Graphics.MeasureString(str,this.m_fontBody);
			float with = float.Parse(e.PageBounds.Width.ToString()) - s.Width;

		e.Graphics.DrawString(str,this.m_fontBody,this.m_objBrush,with/2,float.Parse(e.MarginBounds.Bottom.ToString()));
		}
		/// <summary>
		/// 打印结束。一般使用它来更新数据库信息。
		/// </summary>
		/// <param name="p_objPrintArg">此处p_objPrintArg要求为PrintEventArgs类型的对象</param>
		public void m_mthEndPrint(object p_objPrintArg)
		{
			if(this.m_objPatient != null)
			{
                com.digitalwave.clsRecordsService.clsWaitLayRecord_AcadService m_objInRoomSvc =
                    (com.digitalwave.clsRecordsService.clsWaitLayRecord_AcadService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsRecordsService.clsWaitLayRecord_AcadService));

				m_objInRoomSvc.m_lngUpdateALLFirstPrintDate(m_objPatient.m_StrInPatientID,m_dtInHos.ToString(),System.DateTime.Now);
			}
			
			//			m_mthEndPrintSub((PrintEventArgs)p_objPrintArg);
			//			if(m_blnIsFromDataSource==false || m_objPrintInfo.m_strInPatentID=="") 
			//				return; 
			//			//如果打印成功，查找有无需要更新的时间，如果有，更新时间。 
			//			if(!((PrintEventArgs)p_objPrintArg).Cancel && m_objPrintInfo.m_blnIsFirstPrint)
			//			{
			//				m_objRecordsDomain.m_lngUpdateFirstPrintDate(m_objPrintInfo.m_strInPatentID,m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"),m_objPrintInfo.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss")  ,m_objPrintInfo.m_dtmFirstPrintDate);
			//			}
		}

					#region 有关打印的声明

					/// <summary>
					/// 打印一行的内容
					/// </summary>
					private com.digitalwave.Utility.Controls.clsPrintContext m_objPrintLineContext;	

		/// <summary>
		/// 打印边框的左边距
		/// </summary>
		private const int m_intRecBaseX = clsPrintPosition.c_intLeftX;
		private int m_intCurrentPage = 1;
		/// <summary>
		/// 标题的字体(20 bold)
		/// </summary>
		private Font m_fotTitleFont = new Font("SimSun", 16,FontStyle.Bold);
		/// <summary>
		/// 表头的字体(14 )
		/// </summary>
		private Font m_fotHeaderFont;
		/// <summary>
		/// 大项目的标题，如体格检查
		/// </summary>
		public static Font m_fotItemHead;
		/// <summary>
		/// 表内容的字体(11)
		/// </summary>
		private Font m_fotSmallFont;
		/// <summary>
		/// 边框画笔
		/// </summary>
		private Pen m_GridPen;
		/// <summary>
		/// 刷子
		/// </summary>
		private SolidBrush m_slbBrush= new SolidBrush(Color.Black);
		/// <summary>
		/// 当前打印位置（Y）
		/// </summary>
		private int m_intYPos=155 ;//= (int)enmRectangleInfo.TopY+5;
	
		/// <summary>
		/// 格子的信息
		/// </summary>
		public enum enmRectangleInfo
		{

			/// <summary>
			/// 格子的顶端
			/// </summary>
			TopY = 150,
			///<summary>
			/// 格子的左端
			/// </summary>
			LeftX = clsPrintPosition.c_intLeftX,
			/// <summary>
			/// 格子的右端
			/// </summary>
			RightX = clsPrintPosition.c_intRightX,
			/// <summary>
			/// 格子每行的步长
			/// </summary>
			RowStep = 25,
			SmallRowStep=25,
			/// <summary>
			/// 格子的行数
			/// </summary>
			RowLinesNum = 32,

			ColumnsMark1=35,

			/// <summary>
			/// CheckBox偏移右边文本的距离
			/// </summary>
			CheckShift=15,

			/// <summary>
			/// 底划线偏移文本顶点的距离
			/// </summary>
			BottomLineShift=15,

			BottomY=1025

		}

		#endregion
		// 打印开始后，在打印页之前的操作
		private void m_mthBeginPrintSub(PrintEventArgs p_objPrintArg)
		{
			
		}

		// 打印页
		private void m_mthPrintPageSub(PrintPageEventArgs p_objPrintPageArg)
		{
//			m_mthPrintTitleInfo(p_objPrintPageArg);
//
//			Font fntNormal = new Font("",10);
//
//			while(m_objPrintLineContext.m_BlnHaveMoreLine)
//			{
//				//还有数据打印
//				m_objPrintLineContext.m_mthPrintNextLine(ref m_intYPos,p_objPrintPageArg.Graphics,fntNormal);
//
//				if(m_intYPos > p_objPrintPageArg.PageBounds.Height-270
//					&& m_objPrintLineContext.m_BlnHaveMoreLine)
//				{
//					//还有数据打印，但需要换页
//
//					m_mthPrintFoot(p_objPrintPageArg);
//
//					p_objPrintPageArg.HasMorePages = true;
//
//					m_intYPos = 155;
//
//					m_intCurrentPage++;
//
//					return;
//				}				
//			}
//
//			m_intYPos += 30;
//			Font fntSign = new Font("",6);
//			while(m_objPrintLineContext.m_BlnHaveMoreSign)
//			{
//				m_objPrintLineContext.m_mthPrintNextSign(30+10,m_intYPos,p_objPrintPageArg.Graphics,fntSign);
//
//				m_intYPos += (int)enmRectangleInfo.RowStep-10;				
//			}
//
//			//全部打完			
//
//			m_mthPrintFoot(p_objPrintPageArg);
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
			BabySex_Title,
			BabySex,
			BirthTime_Title,
			Birth,
    
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
			RecordSign2

		}

		/// <summary>
		/// 获取坐标的类
		/// </summary>
		private clsPrintPageSettingForRecord m_objPageSetting;

		#region 定义打印各元素的坐标点
		protected class clsPrintPageSettingForRecord
		{	
			public clsPrintPageSettingForRecord(){}
	
			/// <summary>
			/// 获得坐标点
			/// </summary>
			/// <param name="p_intItemName">项目名称</param>
			/// <returns></returns>
			public PointF m_getCoordinatePoint(int p_intItemName)
			{
				float fltOffsetX=20;//X的偏移量
				PointF m_fReturnPoint;
				switch(p_intItemName)
				{   
            
					case (int)enmItemDefination.Page_HospitalName:
						m_fReturnPoint = new PointF(340f-fltOffsetX,40f);
						break;
					case (int)enmItemDefination.Page_Name_Title:
						m_fReturnPoint = new PointF(280f-fltOffsetX,70f);
						break;
					case (int)enmItemDefination.Name_Title :
						m_fReturnPoint = new PointF(50f-fltOffsetX,110f);
						break;
					case (int)enmItemDefination.Name:
						m_fReturnPoint = new PointF(130f-fltOffsetX,110f);
						break;

					case (int)enmItemDefination.BabySex_Title :
						m_fReturnPoint = new PointF(250f-fltOffsetX,110f);
						break;
					case (int)enmItemDefination.BabySex :
						m_fReturnPoint = new PointF(330f-fltOffsetX,110f);
						break;

					case (int)enmItemDefination.BirthTime_Title :
						m_fReturnPoint = new PointF(400f-fltOffsetX,110f);
						break;
					case (int)enmItemDefination.Birth:
						m_fReturnPoint = new PointF(500f-fltOffsetX,110f);
						break;
					case (int)enmItemDefination.InPatientID_Title:
						m_fReturnPoint = new PointF(610f-fltOffsetX,75f);
						break;
					case (int)enmItemDefination.InPatientID :
						m_fReturnPoint = new PointF(680f-fltOffsetX,80f);
						break;
									
					default:
						m_fReturnPoint = new PointF(400f,400f);
						break;

				}
				return m_fReturnPoint;
			}
		}

		/// <summary>
		/// 格子的信息
		/// </summary>
		private enum enmRectangleInfoInPatientCaseInfo 
		{
			/// <summary>
			/// 格子的顶端
			/// </summary>
			TopY = 140,

			///<summary>
			/// 格子的左端
			/// </summary>
			LeftX = 16,

			/// <summary>
			/// 格子的右端
			/// </summary>
			RightX = 180+17,
			/// <summary>
			/// 格子每行的步长
			/// </summary>
			RowStep = 7,
			SmallRowStep=20,
			/// <summary>
			/// 格子的行数
			/// </summary>
			RowLinesNum = 32,

			ColumnsMark1=35,

			/// <summary>
			/// CheckBox偏移右边文本的距离
			/// </summary>
			CheckShift=15,

			/// <summary>
			/// 底划线偏移文本顶点的距离
			/// </summary>
			BottomLineShift=15,

			BottomY=1024,

			PrintWidth = 630,
			PrintWidth2 = 710,

		}

		#endregion
	 
		 
	 

		#region 打印页脚
		/// <summary>
		/// 打印页脚
		/// </summary>
		/// <param name="e"></param>
		private void m_mthPrintPageAtFoot(System.Drawing.Printing.PrintPageEventArgs e)
		{
			float fltOffsetX=20;//X的偏移量
			Font fntHeader = new Font("SimSun", 12);

			e.Graphics.DrawString("第      页",fntHeader,Brushes.Black,385-fltOffsetX,e.PageBounds.Height-225);
			e.Graphics.DrawString(m_intCurrentPage.ToString(),fntHeader,Brushes.Black,425-fltOffsetX,e.PageBounds.Height-225);			
		}
		#endregion 

		#region  标题文字部分
		/// <summary>
		/// 标题文字部分
		/// </summary>
		/// <param name="e"></param>
		private void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
		{	
			System.Drawing.Graphics g = e.Graphics;
			SizeF objFormNameSize = g.MeasureString(this.m_strTitle, this.m_fontTitle);
            SizeF objHospitalTitalSize = g.MeasureString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle.Trim(), this.m_fontTitle);
            g.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle.Trim(), m_fotHospitalFont, m_slbBrush, e.MarginBounds.Left + (e.MarginBounds.Width - objHospitalTitalSize.Width) / 2 + 25, e.MarginBounds.Top - 33);
            g.DrawString(this.m_strTitle, this.m_fontTitle, m_objBrush, e.MarginBounds.Left + (e.MarginBounds.Width - objFormNameSize.Width) / 2, e.MarginBounds.Top);
            this.m_fltLocationY = e.MarginBounds.Top + objFormNameSize.Height;

		}
		#endregion

		#region  表格上面文字部分
		/// <summary>
		/// 表格上面文字部分
		/// </summary>
		/// <param name="e"></param>
		private void m_mthPrintFormTitleInfo(System.Drawing.Printing.PrintPageEventArgs e, clsPatient p_objPatient,ref float p_fltLocationY)
		{	
			string strPrint = "";
			int col = e.MarginBounds.Width/6;
			float fltCol = float.Parse(col.ToString());//打印姓名此列的列宽
			System.Drawing.Graphics g = e.Graphics;			

			strPrint  = "姓名:"+p_objPatient.m_StrName.Trim();
			SizeF objSize = g.MeasureString(strPrint, this.m_fontBody);
			g.DrawString(strPrint, m_fontBody, m_objBrush, e.MarginBounds.Left - 40, p_fltLocationY);

			strPrint  = "年龄:"+p_objPatient.m_ObjPeopleInfo.m_IntAge.ToString().Trim();
			 objSize = g.MeasureString(strPrint, this.m_fontBody);
			g.DrawString(strPrint, m_fontBody, m_objBrush, e.MarginBounds.Left + fltCol - 40, p_fltLocationY);

            strPrint = "孕/产次:" + ((m_objResultArr != null && m_objResultArr.Length > 0) ? m_objResultArr[0].m_strLayCount_chr : "");
			 objSize = g.MeasureString(strPrint, this.m_fontBody);
			g.DrawString(strPrint, m_fontBody, m_objBrush, e.MarginBounds.Left + fltCol * 2 -50, p_fltLocationY);

            strPrint = "预产期:" + ((m_objResultArr != null && m_objResultArr.Length > 0) ? m_objResultArr[0].m_strBeforehand_chr : "");
			 objSize = g.MeasureString(strPrint, this.m_fontBody);
			g.DrawString(strPrint, m_fontBody, m_objBrush, e.MarginBounds.Left + fltCol * 3 - 55, p_fltLocationY);

			strPrint  = "床号:"+p_objPatient.m_strBedCode.Trim();
			 objSize = g.MeasureString(strPrint, this.m_fontBody);
			g.DrawString(strPrint, m_fontBody, m_objBrush, e.MarginBounds.Left + fltCol * 4 + 35 , p_fltLocationY);

			strPrint  = "住院号:"+p_objPatient.m_StrHISInPatientID.Trim();
			 objSize = g.MeasureString(strPrint, this.m_fontBody);
			g.DrawString(strPrint, m_fontBody, m_objBrush, e.MarginBounds.Left + fltCol * 5 + 20, p_fltLocationY);

			this.m_fltLocationY = p_fltLocationY + objSize.Height;
        
			//			if(m_objResultArr.Length <=0)
			//			      return ;
			//			for(int i1 = 0; i1 < m_objResultArr.Length; i1 =i1+1)
			//			{
			//				e.Graphics.DrawString(m_objResultArr[i1].m_strLayCount_chr,m_fotTitleFont,m_slbBrush,300,i1+350);
			//
			//			}
		}
		#endregion

		#region 打表头
		private void m_mthPrintFormHeader(System.Drawing.Printing.PrintPageEventArgs e, ref float p_objLocationY)
		{
			
			System.Drawing.Graphics g = e.Graphics;	
			

			g.DrawLine(this.m_objPen, m_fltFirstColLeft,p_objLocationY, m_fltColLeft14 + m_fltCol14, p_objLocationY);

	 
			for(int i1=0;i1<15;i1++)
			{
				//g.DrawLine(this.m_objPen, e.MarginBounds.Left + e.MarginBounds.Width/14 * i1,p_objLocationY, e.MarginBounds.Left + e.MarginBounds.Width/14 * i1, p_objLocationY +m_ftlRowHeight);
				g.DrawLine(this.m_objPen, this.m_fltFirstColLeft + m_fltAvgCol * i1  ,p_objLocationY, m_fltFirstColLeft + m_fltAvgCol * i1 , p_objLocationY +m_ftlRowHeight * 2);

			}
			SizeF s = g.MeasureString("日期",this.m_fontBody);
			float y = p_objLocationY + m_ftlRowHeight*2 /2 - s.Height/2;
			float y1 = p_objLocationY + m_ftlRowHeight /2 - s.Height/2;
			float y2 = p_objLocationY + m_ftlRowHeight + m_ftlRowHeight /2 - s.Height/2;

			m_mthDrawStrAtRectangle(this.m_fltFirstColLeft,this.m_fltSeconColLeft, "日期",p_objLocationY,e);
			m_mthDrawStrAtRectangle(this.m_fltSeconColLeft,this.m_fltthColLeft, "时间",p_objLocationY,e);
			m_mthDrawStrAtRectangle(this.m_fltthColLeft,this.m_fltthirColLeft, "血压",p_objLocationY,e);
			m_mthDrawStrAtRectangle(this.m_fltthColLeft,this.m_fltthirColLeft, "mmHg",p_objLocationY + m_ftlRowHeight,e);
			m_mthDrawStrAtRectangle(this.m_fltthirColLeft,this.m_fltFiveColLeft, "胎位",p_objLocationY,e);
			m_mthDrawStrAtRectangle(this.m_fltFiveColLeft,this.m_fltSixColLeft, "胎心",p_objLocationY,e);
			m_mthDrawStrAtRectangle(this.m_fltFiveColLeft,this.m_fltSixColLeft, "次/分",p_objLocationY + m_ftlRowHeight,e);
			m_mthDrawStrAtRectangle(this.m_fltSixColLeft,this.m_fltSenColLeft, "宫缩",p_objLocationY ,e);
			m_mthDrawStrAtRectangle(this.m_fltSixColLeft,this.m_fltSenColLeft, "间歇",p_objLocationY  + m_ftlRowHeight,e);
			m_mthDrawStrAtRectangle(this.m_fltSenColLeft,this.m_fltNigColLeft, "宫缩",p_objLocationY ,e);
			m_mthDrawStrAtRectangle(this.m_fltSenColLeft,this.m_fltNigColLeft, "持续",p_objLocationY + m_ftlRowHeight,e);
			m_mthDrawStrAtRectangle(this.m_fltNigColLeft,this.m_fltNiNeColLeft, "宫缩",p_objLocationY ,e);
			m_mthDrawStrAtRectangle(this.m_fltNigColLeft,this.m_fltNiNeColLeft, "强度",p_objLocationY + m_ftlRowHeight,e);
			m_mthDrawStrAtRectangle(this.m_fltNiNeColLeft,this.m_fltColLeft10, "宫口",p_objLocationY,e);
			m_mthDrawStrAtRectangle(this.m_fltNiNeColLeft,this.m_fltColLeft10, "cm",p_objLocationY+ m_ftlRowHeight,e);
			m_mthDrawStrAtRectangle(this.m_fltColLeft10,this.m_fltColLeft11, "先露",p_objLocationY,e);
			m_mthDrawStrAtRectangle(this.m_fltColLeft10,this.m_fltColLeft11, "S",p_objLocationY+ m_ftlRowHeight,e);
			m_mthDrawStrAtRectangle(this.m_fltColLeft11,this.m_fltColLeft12, "胎膜",p_objLocationY,e);
			m_mthDrawStrAtRectangle(this.m_fltColLeft12,this.m_fltColLeft13, "肛(阴)查",p_objLocationY,e);
			m_mthDrawStrAtRectangle(this.m_fltColLeft13,this.m_fltColLeft14, "其它",p_objLocationY,e);
			m_mthDrawStrAtRectangle(this.m_fltColLeft14,this.m_fltColLeft15, "检查者",p_objLocationY,e);

			p_objLocationY += m_ftlRowHeight* 2;
			g.DrawLine(this.m_objPen, m_fltFirstColLeft,p_objLocationY, m_fltColLeft14 + m_fltCol14, p_objLocationY);

			
		}
		#endregion 


		private void  m_mthDrawStrAtRectangle(float col1, float col2 ,string strPrint,float LocationY,System.Drawing.Printing.PrintPageEventArgs e)
		{
			System.Drawing.Graphics g = e.Graphics;	
			System.Drawing.Font m_font = this.m_fontBody;
			SizeF s = g.MeasureString(strPrint,m_font);
			if(s.Width > this.m_fltAvgCol)
			{
				m_font = new System.Drawing.Font("宋体",8);
				s = g.MeasureString(strPrint,m_font);               
			}			
			
			float ji = col2 - col1;
			float X =  col1 + ji/2 - s.Width/2;
			float Y = LocationY + m_ftlRowHeight/2 - s.Height/2;				
			g.DrawString(strPrint,m_font,this.m_objBrush,X,Y);

		}

		// 打印结束时的操作
		private void m_mthEndPrintSub(PrintEventArgs p_objPrintArg)
		{		
			m_mthResetWhenEndPrint();
		}

		/// <summary>
		/// 每次打印结束之后的复位,无论是打印当前页或者打印全部.
		/// </summary>
		private void m_mthResetWhenEndPrint()
		{
			m_objPrintLineContext.m_mthReset();

			m_intYPos = 155;

			m_intCurrentPage = 1;
		}
		
		#endregion
	}
}
