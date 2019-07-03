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
	/// 打印 胎动监护表 的摘要说明。
	/// </summary>
	public class clsQuickeningTutelar_AcadPrintTool : infPrintRecord
	{
		private bool m_blnIsFromDataSource=true;//表明是从数据库读取还是从文件直接提取信息
		private bool m_blnWantInit=true;		
		private clsPrintInfo_InPatientCaseHistory m_objPrintInfo;
		private clsBaseCaseHistoryDomain m_objRecordsDomain;
		public string m_strLaycount  = ""; //产次
		public string m_strBirthDate  = "";// 产期

		private clsQuickeningTutelarValue[] m_objResultArr = null;
		private	clsPatient m_objPatient = null;
		DateTime m_dtInHos ;

		#region 分娩日期传值等变量 。
		public string m_strTOTALBLOODNUM_CHR;  
		public string m_strSEWPIN_CHR;
		public string m_strESPECIALRECORD_CHR;
		public string m_strPERIOD_CHR;
		public string m_strCHILDBIRTHINGDATE;  
		public string m_strRECORDPERSON_CHR;
		#endregion 
		public clsQuickeningTutelar_AcadPrintTool()
		{
            m_strTitle = "胎 动 监 护 表";
		}
		///<summary>
		///变量：控制打印记录人，只能打印一次。
		///</summary>
		bool  m_blnOnlyPrintOnceHadPrintedPerson ; 
		///<summary>
		///变量：控制打印附注，只能打印一次。
		///</summary>
		bool  m_blnOnlyPrintOnceHadPrinted ; 

		///<summary>
		///变量：特殊记录数组下际
		///</summary>
		int m_intRecordIndex =0; 

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
		///变量：第15列宽度
		///</summary>
		float m_fltCol15 ; 

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
		///变量：第14列rigth坐际,第15列的左坐标
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

		#endregion 

		#region 方法:初始化每一列的位置
		/// <summary>
		/// 方法:初始化每一列的位置
		/// </summary>		
		private void mthInitColLocation(PrintPageEventArgs e)
		{
			#region 设置打印列宽与每列的横坐标

			//			double kk=(e.PageBounds.Width - 30)/15;
			double kk=(Convert.ToDouble(e.PageBounds.Width - 50))/12.00;
			m_fltAvgCol  = float.Parse(kk.ToString("0.00"));

			float fltCol =m_fltAvgCol;
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
			this.m_fltCol15 = fltCol;


			m_fltFirstColLeft = e.PageBounds.Left + 20 ; //第1列Left坐际
			//			m_fltFirstColLeft = e.MarginBounds.Left - 90  ; //第1列Left坐际
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
            com.digitalwave.clsRecordsService.clsQuickeningTutelar_AcadService objServ =
                (com.digitalwave.clsRecordsService.clsQuickeningTutelar_AcadService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsRecordsService.clsQuickeningTutelar_AcadService));

			objServ.m_lngGetAllMainRecord(p_objPatient.m_StrInPatientID, p_dtmInPatientDate.ToString(), out m_objResultArr);
		
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
            if (m_blnIsFromDataSource)
            {
                if (m_objResultArr == null)
                {
                    MDIParent.ShowInformationMessageBox("当从数据库读取时,调用m_objGetPrintInfo之前请首先调用m_mthSetPrintInfo函数");
                    return null;
                }
            }

            //没有记录内容时，返回空
            if (m_objResultArr.Length == 0)
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

		}

		#endregion

		#region 释放打印变量
		/// <summary>
		/// 释放打印变量
		/// </summary>
		public void m_mthDisposePrintTools(object p_objArg)
		{

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
			//			e.PageSettings.Landscape = true;
			//			e.PageSettings.Margins.Left = 0;
			//			e.PageSettings.Margins.Right = 0;
			//测试
			//	e.Graphics.DrawRectangle(this.m_objPen,m_fltFirstColLeft,e.MarginBounds.Top,15*this.m_fltAvgCol,e.MarginBounds.Height);
			//

			
			m_mthPrintTitleInfo(e);
			m_mthPrintFormTitleInfo(e,this.m_objPatient,ref this.m_fltLocationY);
			mthInitColLocation(e);
			if(m_intCurrentPageIndex == 1)
			{
				m_mthPrintFormHeader(e,ref this.m_fltLocationY);
			}
			m_mthPrintAllPage(e,ref this.m_fltLocationY);
		}

		#endregion 

		#region 打印每页
		private void reset()
		{
			m_intRecordIndex = 0;
			m_blnOnlyPrintOnceHadPrintedPerson= false;
			m_blnOnlyPrintOnceHadPrinted = false;
			m_intCurrentPageIndex = 1;
			this.m_fltLocationY = 0;

		}
		private int i =0;
		//		private int intPageSize =3;

		private void m_mthPrintAllPage(System.Drawing.Printing.PrintPageEventArgs e,ref float p_objLocationY)
		{
			string print = "";
			float PosY=p_objLocationY;
			if(m_objResultArr.Length <=0)
				return ;

			//计算第一页还能打印出多少条记录
			int intRowCount = Convert.ToInt32((float.Parse(e.MarginBounds.Height.ToString()) - p_objLocationY)/m_ftlRowHeight);
			intRowCount--; //因为留出一行位置来打印页脚,打印 附注 ，所以显示总行数为减1
			intRowCount--; //因为留出一行位置来打印"特殊记录"

			if(m_intCurrentPageIndex == 1)
			{
				int temp1;
				
				for(  i = 0; i< m_objResultArr.Length && i < intRowCount-1;i++)
				{
		
					#region draw one row
					print = m_objResultArr[i].m_dtmCreateDate.ToString("yy-MM-dd");
					m_mthDrawStrAtRectangle(this.m_fltFirstColLeft,this.m_fltSeconColLeft, print,p_objLocationY,e);

					print = m_objResultArr[i].m_strPREGNANTTEAM_CHR;
					m_mthDrawStrAtRectangle(this.m_fltSeconColLeft,this.m_fltthColLeft, print ,p_objLocationY,e);

					print = m_objResultArr[i].m_strMORNING_CHR;
					m_mthDrawStrAtRectangle(this.m_fltthColLeft,this.m_fltthirColLeft, print,p_objLocationY,e);

					print = m_objResultArr[i].m_strMIDDAY_CHR;
					m_mthDrawStrAtRectangle(this.m_fltthirColLeft,this.m_fltFiveColLeft, print,p_objLocationY,e);

					print = m_objResultArr[i].m_strEVENING_CHR;
					m_mthDrawStrAtRectangle(this.m_fltFiveColLeft,this.m_fltSixColLeft, print,p_objLocationY,e);
				
					print = m_objResultArr[i].m_strQUICKENINGNUM_CHR;
					m_mthDrawStrAtRectangle(this.m_fltSixColLeft,this.m_fltSenColLeft, print,p_objLocationY  ,e);

					m_mthDrawLines(e);

					p_objLocationY += this.m_ftlRowHeight;
					#endregion 
								
				}
                temp1=i;
				
				for(  ; i< m_objResultArr.Length && i < intRowCount+temp1-1;i++)
				{
					                    print = m_objResultArr[i].m_dtmCreateDate.ToString("yy-MM-dd");
										m_mthDrawStrAtRectangle(this.m_fltSenColLeft,this.m_fltNigColLeft, print,PosY ,e);
									
										print = m_objResultArr[i].m_strPREGNANTTEAM_CHR;
										m_mthDrawStrAtRectangle(this.m_fltNigColLeft,this.m_fltNiNeColLeft, print,PosY ,e);
					
										print = m_objResultArr[i].m_strMORNING_CHR;
										m_mthDrawStrAtRectangle(this.m_fltNiNeColLeft,this.m_fltColLeft10, print,PosY,e);
					
										print = m_objResultArr[i].m_strMIDDAY_CHR;				
										m_mthDrawStrAtRectangle(this.m_fltColLeft10,this.m_fltColLeft11, print,PosY,e);
					
										print = m_objResultArr[i].m_strEVENING_CHR;
										m_mthDrawStrAtRectangle(this.m_fltColLeft11,this.m_fltColLeft12, print,PosY,e);
												
										print = m_objResultArr[i].m_strQUICKENINGNUM_CHR;
										m_mthDrawStrAtRectangle(this.m_fltColLeft12,this.m_fltColLeft13, print,PosY,e);
					
//										print = m_objResultArr[i].m_strURINE_CHR;
//										m_mthDrawStrAtRectangle(this.m_fltColLeft13,this.m_fltColLeft14, print,p_objLocationY,e);
//					
//										print = m_objResultArr[i].m_strANNOTATIONS_CHR;
//										m_mthDrawStrAtRectangle(this.m_fltColLeft14,this.m_fltColLeft15, print,p_objLocationY,e);
//					
//										print = m_objResultArr[i].m_strSCRTATOR_CHR;
//										m_mthDrawStrAtRectangle(this.m_fltColLeft15,this.m_fltColLeft15 + this.m_fltCol15, print,p_objLocationY,e);
                                     PosY+=this.m_ftlRowHeight;

				}
				m_mthPrintFoot(e);
				//判断是否多页
				if( i < this.m_objResultArr.Length-1)
				{
					m_intCurrentPageIndex ++;
					e.HasMorePages = true;	
					return;
				}			
			}
			else//画第二、第三....页
			{
				int temp = i;

				#region draw one row
				// e.Graphics.DrawLine(this.m_objPen, m_fltFirstColLeft,p_objLocationY, m_fltColLeft12 + m_fltCol12, p_objLocationY);
                  m_mthPrintFormHeader( e, ref  p_objLocationY);
				for(  ; i< m_objResultArr.Length && i < intRowCount + temp-1;i++)
				{
					#region draw one row 
					print = m_objResultArr[i].m_dtmCreateDate.Date.ToString("yy-MM-dd");
					m_mthDrawStrAtRectangle(this.m_fltFirstColLeft,this.m_fltSeconColLeft, print,p_objLocationY,e);

					print = m_objResultArr[i].m_strPREGNANTTEAM_CHR;
					m_mthDrawStrAtRectangle(this.m_fltSeconColLeft,this.m_fltthColLeft, print ,p_objLocationY,e);

					print = m_objResultArr[i].m_strMORNING_CHR;
					m_mthDrawStrAtRectangle(this.m_fltthColLeft,this.m_fltthirColLeft, print,p_objLocationY,e);

					print = m_objResultArr[i].m_strMIDDAY_CHR;
					m_mthDrawStrAtRectangle(this.m_fltthirColLeft,this.m_fltFiveColLeft, print,p_objLocationY,e);

					print = m_objResultArr[i].m_strEVENING_CHR;
					m_mthDrawStrAtRectangle(this.m_fltFiveColLeft,this.m_fltSixColLeft, print,p_objLocationY,e);
				
					print = m_objResultArr[i].m_strQUICKENINGNUM_CHR;
					m_mthDrawStrAtRectangle(this.m_fltSixColLeft,this.m_fltSenColLeft, print,p_objLocationY  ,e);

//					print = m_objResultArr[i].m_strNIPPLE_CHR;
//					m_mthDrawStrAtRectangle(this.m_fltSenColLeft,this.m_fltNigColLeft, print,p_objLocationY ,e);
//				
//					print = m_objResultArr[i].m_strDEWNUM_CHR;
//					m_mthDrawStrAtRectangle(this.m_fltNigColLeft,this.m_fltNiNeColLeft, print,p_objLocationY ,e);
//
//					print = m_objResultArr[i].m_strDEWCOLOR_CHR;
//					m_mthDrawStrAtRectangle(this.m_fltNiNeColLeft,this.m_fltColLeft10, print,p_objLocationY,e);
//
//					print = m_objResultArr[i].m_strDEWFUCK_CHR;				
//					m_mthDrawStrAtRectangle(this.m_fltColLeft10,this.m_fltColLeft11, print,p_objLocationY,e);
//
//					print = m_objResultArr[i].m_strPERINEUM_CHR;
//					m_mthDrawStrAtRectangle(this.m_fltColLeft11,this.m_fltColLeft12, print,p_objLocationY,e);
//							
//					print = m_objResultArr[i].m_strBP_CHR;
//					m_mthDrawStrAtRectangle(this.m_fltColLeft12,this.m_fltColLeft13, print,p_objLocationY,e);
//
//					print = m_objResultArr[i].m_strURINE_CHR;
//					m_mthDrawStrAtRectangle(this.m_fltColLeft13,this.m_fltColLeft14, print,p_objLocationY,e);
//
//					print = m_objResultArr[i].m_strANNOTATIONS_CHR;
//					m_mthDrawStrAtRectangle(this.m_fltColLeft14,this.m_fltColLeft15, print,p_objLocationY,e);
//
//					print = m_objResultArr[i].m_strSCRTATOR_CHR;
//					m_mthDrawStrAtRectangle(this.m_fltColLeft15,this.m_fltColLeft15 + this.m_fltCol15, print,p_objLocationY,e);

					#endregion

					m_mthDrawLines(e);



					p_objLocationY += this.m_ftlRowHeight;
								
				}

				#endregion
				temp=i;
				for(  ; i< m_objResultArr.Length && i < intRowCount+temp-1;i++)
				{
					print = m_objResultArr[i].m_dtmCreateDate.ToString("yy-MM-dd");
					m_mthDrawStrAtRectangle(this.m_fltSenColLeft,this.m_fltNigColLeft, print,PosY ,e);
									
					print = m_objResultArr[i].m_strPREGNANTTEAM_CHR;
					m_mthDrawStrAtRectangle(this.m_fltNigColLeft,this.m_fltNiNeColLeft, print,PosY ,e);
					
					print = m_objResultArr[i].m_strMORNING_CHR;
					m_mthDrawStrAtRectangle(this.m_fltNiNeColLeft,this.m_fltColLeft10, print,PosY,e);
					
					print = m_objResultArr[i].m_strMIDDAY_CHR;				
					m_mthDrawStrAtRectangle(this.m_fltColLeft10,this.m_fltColLeft11, print,PosY,e);
					
					print = m_objResultArr[i].m_strEVENING_CHR;
					m_mthDrawStrAtRectangle(this.m_fltColLeft11,this.m_fltColLeft12, print,PosY,e);
												
					print = m_objResultArr[i].m_strQUICKENINGNUM_CHR;
					m_mthDrawStrAtRectangle(this.m_fltColLeft12,this.m_fltColLeft13, print,PosY,e);
					
					//										print = m_objResultArr[i].m_strURINE_CHR;
					//										m_mthDrawStrAtRectangle(this.m_fltColLeft13,this.m_fltColLeft14, print,p_objLocationY,e);
					//					
					//										print = m_objResultArr[i].m_strANNOTATIONS_CHR;
					//										m_mthDrawStrAtRectangle(this.m_fltColLeft14,this.m_fltColLeft15, print,p_objLocationY,e);
					//					
					//										print = m_objResultArr[i].m_strSCRTATOR_CHR;
					//										m_mthDrawStrAtRectangle(this.m_fltColLeft15,this.m_fltColLeft15 + this.m_fltCol15, print,p_objLocationY,e);
					PosY+=this.m_ftlRowHeight;

				}

				m_mthPrintFoot(e);

				//判断是否多页

				if( intRowCount < m_objResultArr.Length-i-1)
				{
					m_intCurrentPageIndex ++;
					e.HasMorePages = true;
					return;
				}
					
			}
			//在最后一页中打印 附注：
			if(!m_blnOnlyPrintOnceHadPrinted)
			{
				m_mthPrintFuZhu(e,p_objLocationY);
				m_blnOnlyPrintOnceHadPrinted = true;
				p_objLocationY += this.m_ftlRowHeight;
				p_objLocationY += this.m_ftlRowHeight;
			}

			#region 打印特殊记录
//			Char[] ch = m_strESPECIALRECORD_CHR.ToCharArray();
//			string str = "";
//			float tempX = this.m_fltFirstColLeft;
//				
//			for(; m_intRecordIndex < ch.Length ; m_intRecordIndex ++)
//			{
//				if(m_intRecordIndex==0)
//				{
//					str = "     "+ch[m_intRecordIndex].ToString();
//				}
//				else
//				{
//					str = ch[m_intRecordIndex].ToString();
//				}
//				SizeF sf = e.Graphics.MeasureString(str,this.m_fontBody);
//				if( p_objLocationY >= e.MarginBounds.Height )
//				{					
//					m_intCurrentPageIndex ++;
//					e.HasMorePages = true;
//					return;
//				}
//				if(tempX  < this.m_fltColLeft15 + this.m_fltCol15 - this.m_fltFirstColLeft)
//				{
//							
//					e.Graphics.DrawString(str, this.m_fontBody,this.m_objBrush,tempX ,p_objLocationY);
//					tempX  = tempX + sf.Width;
//				}
//				else
//				{
//					tempX = this.m_fltFirstColLeft;
//					p_objLocationY += this.m_ftlRowHeight;
//					e.Graphics.DrawString(str, this.m_fontBody,this.m_objBrush,tempX ,p_objLocationY);
//					tempX  = tempX + sf.Width;
//				}
//			}					
			#endregion

//			#region 打印记录人 
//			p_objLocationY += this.m_ftlRowHeight;
//			if( p_objLocationY < e.MarginBounds.Height && !m_blnOnlyPrintOnceHadPrintedPerson)
//			{
//				string strP = "记录人："+ m_strRECORDPERSON_CHR;
//				e.Graphics.DrawString(strP, this.m_fontBody,this.m_objBrush,e.MarginBounds.Right - e.Graphics.MeasureString(strP,this.m_fontBody).Width,p_objLocationY);
//				m_blnOnlyPrintOnceHadPrintedPerson =  true;
//			}
//			else
//			{
//				m_intCurrentPageIndex ++;
//				e.HasMorePages = true;
//				return;
//			}
//			#endregion

		}

		#endregion 

		#region 在最后一页中打印 附注：产后24小时总出血量：___ml ,会阴伤口拆线：外缝__针，愈合级别：__期
		private void m_mthPrintFuZhu(System.Drawing.Printing.PrintPageEventArgs e, float p_objLocationY)
		{
			p_objLocationY += this.m_ftlRowHeight;
			string str = "注： 1.方法：孕妇早、中、晚各静卧、自数胎动1小时，三次胎动相加乘以4，即为12小时胎动数。";
			SizeF s = e.Graphics.MeasureString(str,this.m_fontBody);
			float with = float.Parse(e.PageBounds.Width.ToString()) - s.Width;
			e.Graphics.DrawString(str,this.m_fontBody,this.m_objBrush,this.m_fltFirstColLeft,p_objLocationY + m_fltZijiHeight/2);
			p_objLocationY += this.m_ftlRowHeight;
			string str1 = "       2.12小时胎动>30次为胎儿情况良好，少于20次表示胎儿缺氧，少于10次为预后不良，应即时就诊。";

			e.Graphics.DrawString(str1,this.m_fontBody,this.m_objBrush,this.m_fltFirstColLeft,p_objLocationY + m_fltZijiHeight/2);
            p_objLocationY += this.m_ftlRowHeight;
			string str2 = "       3.服镇静剂，安眠药对胎动有抑制作用。";

			e.Graphics.DrawString(str2,this.m_fontBody,this.m_objBrush,this.m_fltFirstColLeft,p_objLocationY + m_fltZijiHeight/2);
			p_objLocationY += this.m_ftlRowHeight;


		}
		#endregion

		#region 画线
		private void m_mthDrawLines(PrintPageEventArgs e)
		{
			Graphics g = e.Graphics;
			for(int i1 = 0 ;i1 < 13; i1 ++)//16列
			{
				g.DrawLine(this.m_objPen , this.m_fltFirstColLeft + this.m_fltAvgCol * i1,this.m_fltLocationY, this.m_fltFirstColLeft + this.m_fltAvgCol * i1,this.m_fltLocationY + this.m_ftlRowHeight);
			}
			g.DrawLine(this.m_objPen , this.m_fltFirstColLeft ,this.m_fltLocationY + this.m_ftlRowHeight, this.m_fltColLeft12 + this.m_fltCol12,this.m_fltLocationY + this.m_ftlRowHeight);


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
                com.digitalwave.clsRecordsService.clsQuickeningTutelar_AcadService objServ =
                    (com.digitalwave.clsRecordsService.clsQuickeningTutelar_AcadService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsRecordsService.clsQuickeningTutelar_AcadService));

				objServ.m_lngUpdateALLFirstPrintDate(m_objPatient.m_StrInPatientID,m_dtInHos.ToString(),System.DateTime.Now);
			}					
		}

		#endregion
		// 打印开始后，在打印页之前的操作
		private void m_mthBeginPrintSub(PrintEventArgs p_objPrintArg)
		{
			
		}

		// 打印页
		private void m_mthPrintPageSub(PrintPageEventArgs p_objPrintPageArg)
		{
			
		}

		// 设置打印内容。
		private  void m_mthSetPrintContent(clsNewBabyInRoomRecord p_objContent,clsNewBabyCircsRecord[] p_objCircsContentArr, DateTime p_dtmFirstPrintDate)
		{
			
		}

		private clsNewBabyInRoomRecord m_objChangePrintTextColor(clsNewBabyInRoomRecord p_objclsInPatientCase)
		{
			if(p_objclsInPatientCase==null)
				return null;
			
			return p_objclsInPatientCase;
		}

		#region  标题文字部分
		/// <summary>
		/// 标题文字部分
		/// </summary>
		/// <param name="e"></param>
		private void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
		{	
			System.Drawing.Graphics g = e.Graphics;
			SizeF objSize = g.MeasureString(this.m_strTitle, this.m_fontTitle);
			g.DrawString(this.m_strTitle,this.m_fontTitle, m_objBrush,e.MarginBounds.Left +( e.MarginBounds.Width - objSize.Width)/2,e.MarginBounds.Top);
			this.m_fltLocationY = e.MarginBounds.Top + objSize.Height;

		}
		#endregion

		#region  表格上面文字部分
		/// <summary>
		/// 表格上面文字部分
		/// </summary>
		/// <param name="e"></param>
		private void m_mthPrintFormTitleInfo(System.Drawing.Printing.PrintPageEventArgs e, clsPatient p_objPatient,ref float p_fltLocationY)
		{	
//			string strPrint = "";
//			int col = e.MarginBounds.Width/4;
//			float fltCol = float.Parse(col.ToString());//打印姓名此列的列宽
//			System.Drawing.Graphics g = e.Graphics;			
//
//			strPrint  = "姓名:"+p_objPatient.m_StrName.Trim();
//			SizeF objSize = g.MeasureString(strPrint, this.m_fontBody);
//			g.DrawString(strPrint, m_fontBody, m_objBrush, e.MarginBounds.Left , p_fltLocationY);
//
//			strPrint  = "分娩日期:"+m_strCHILDBIRTHINGDATE;
//			objSize = g.MeasureString(strPrint, this.m_fontBody);
//			g.DrawString(strPrint, m_fontBody, m_objBrush, e.MarginBounds.Left + fltCol * 1  -20, p_fltLocationY);
//
//			strPrint  = "床号:"+p_objPatient.m_strBedCode.Trim();
//			objSize = g.MeasureString(strPrint, this.m_fontBody);
//			g.DrawString(strPrint, m_fontBody, m_objBrush, e.MarginBounds.Left + fltCol * 2 + 50 , p_fltLocationY);
//
//			strPrint  = "住院号:"+p_objPatient.m_StrInPatientID.Trim();
//			objSize = g.MeasureString(strPrint, this.m_fontBody);
//			g.DrawString(strPrint, m_fontBody, m_objBrush, e.MarginBounds.Left + fltCol * 3 , p_fltLocationY);
//
//			this.m_fltLocationY = p_fltLocationY + objSize.Height;
       
		}
		#endregion

		#region 打表头
		private void m_mthPrintFormHeader(System.Drawing.Printing.PrintPageEventArgs e, ref float p_objLocationY)
		{
			
			System.Drawing.Graphics g = e.Graphics;	
			

			g.DrawLine(this.m_objPen, m_fltFirstColLeft,p_objLocationY, m_fltColLeft12 + m_fltCol12, p_objLocationY);

	 
			for(int i1=0;i1<13;i1++)
			{
				//g.DrawLine(this.m_objPen, e.MarginBounds.Left + e.MarginBounds.Width/14 * i1,p_objLocationY, e.MarginBounds.Left + e.MarginBounds.Width/14 * i1, p_objLocationY +m_ftlRowHeight);
				g.DrawLine(this.m_objPen, this.m_fltFirstColLeft + m_fltAvgCol * i1  ,p_objLocationY, m_fltFirstColLeft + m_fltAvgCol * i1 , p_objLocationY +m_ftlRowHeight * 2);

			}
//			SizeF s = g.MeasureString("日期",this.m_fontBody);
//			float y = p_objLocationY + m_ftlRowHeight*2 /2 - s.Height/2;
//			float y1 = p_objLocationY + m_ftlRowHeight /2 - s.Height/2;
//			float y2 = p_objLocationY + m_ftlRowHeight + m_ftlRowHeight /2 - s.Height/2;

			m_mthDrawStrAtRectangle(this.m_fltFirstColLeft,this.m_fltSeconColLeft, "日期",p_objLocationY+5,e);
			m_mthDrawStrAtRectangle(this.m_fltSeconColLeft,this.m_fltthColLeft, "孕周",p_objLocationY+5,e);
			m_mthDrawStrAtRectangle(this.m_fltthColLeft,this.m_fltthirColLeft, "早",p_objLocationY+5,e);
			m_mthDrawStrAtRectangle(this.m_fltthirColLeft,this.m_fltFiveColLeft, "中",p_objLocationY+5,e);
			m_mthDrawStrAtRectangle(this.m_fltFiveColLeft,this.m_fltSixColLeft, "晚",p_objLocationY+5 ,e);
			//			m_mthDrawStrAtRectangle(this.m_fltthColLeft,this.m_fltthirColLeft, "cm",p_objLocationY + m_ftlRowHeight+ m_ftlRowHeight,e);
			m_mthDrawStrAtRectangle(this.m_fltSixColLeft,this.m_fltSenColLeft, "12小时",p_objLocationY,e);
			m_mthDrawStrAtRectangle(this.m_fltSixColLeft,this.m_fltSenColLeft, "胎动数",p_objLocationY+ m_ftlRowHeight,e);
			//			m_mthDrawStrAtRectangle(this.m_fltthirColLeft,this.m_fltFiveColLeft, "情况",p_objLocationY+ m_ftlRowHeight+ m_ftlRowHeight,e);
			
			m_mthDrawStrAtRectangle(this.m_fltSenColLeft,this.m_fltNigColLeft, "日期",p_objLocationY+5 ,e);
			m_mthDrawStrAtRectangle(this.m_fltNigColLeft,this.m_fltNiNeColLeft, "孕周",p_objLocationY+5 ,e);
			m_mthDrawStrAtRectangle(this.m_fltNiNeColLeft,this.m_fltColLeft10, "早",p_objLocationY+5,e);
			m_mthDrawStrAtRectangle(this.m_fltColLeft10,this.m_fltColLeft11, "中",p_objLocationY+5,e);
			
			m_mthDrawStrAtRectangle(this.m_fltColLeft11,this.m_fltColLeft12, "晚",p_objLocationY+5,e);
			m_mthDrawStrAtRectangle(this.m_fltColLeft12,this.m_fltColLeft13, "12小时",p_objLocationY,e);
			m_mthDrawStrAtRectangle(this.m_fltColLeft12,this.m_fltColLeft13, "胎动数",p_objLocationY+ m_ftlRowHeight,e);
//			m_mthDrawStrAtRectangle(this.m_fltColLeft13,this.m_fltColLeft14, "尿",p_objLocationY,e);
//			m_mthDrawStrAtRectangle(this.m_fltColLeft14,this.m_fltColLeft15, "附注",p_objLocationY,e);
//			m_mthDrawStrAtRectangle(this.m_fltColLeft15,this.m_fltColLeft15 + this.m_fltCol15, "检查者",p_objLocationY,e);

			p_objLocationY += m_ftlRowHeight* 2;
			g.DrawLine(this.m_objPen, m_fltFirstColLeft,p_objLocationY, m_fltColLeft12 + m_fltCol12, p_objLocationY);

			
		}
		#endregion 


		private void  m_mthDrawStrAtRectangle(float col1, float col2 ,string strPrint,float LocationY,System.Drawing.Printing.PrintPageEventArgs e)
		{
			System.Drawing.Graphics g = e.Graphics;	
			System.Drawing.Font m_font = this.m_fontBody;
			SizeF s = g.MeasureString(strPrint,m_font);
			if(s.Width >= this.m_fltAvgCol)
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

		}
	}
}
