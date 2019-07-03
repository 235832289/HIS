using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.Utility.Controls;
using System.Drawing;
using System.Windows.Forms;

namespace iCare
{
	/// <summary>
	/// 手术记录单.
	/// </summary>
	public class clsOperationRecordDoctorCSPrintTool : infPrintRecord
	{
		public clsOperationRecordDoctorCSPrintTool()
		{
            m_mthGetPrintMarkConfig();
		}

        /// <summary>
        /// 是否打印修改痕迹
        /// </summary>
        public static bool m_blnIsPrintMark = true;
        /// <summary>
        /// 获取打印修改痕迹设置
        /// </summary>
        private void m_mthGetPrintMarkConfig()
        {
            int intConfig = com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_intGetEmrSettingValue("3012");
            if (intConfig == 0)
            {
                m_blnIsPrintMark = false;
            }
            else
            {
                m_blnIsPrintMark = true;
            }
        }

		private bool m_blnIsFromDataSource=true;//表明是从数据库读取还是从文件直接提取信息
		private bool m_blnWantInit=true;		
		clsOperationRecordDoctorDomain m_objDomain= new clsOperationRecordDoctorDomain();
		private clsPrintInfo_OperationRecordDoctor m_objPrintInfo;

		//打印用
		//private string[] m_strOperationIDArr = null; 
		//private string[] m_strOperationNameArr = null; 
		
		/// <summary>
		/// 设置打印信息(当从数据库读取时要首先调用.)
		/// </summary>
		/// <param name="p_objPatient">病人</param>
		/// <param name="p_dtmInPatientDate">入院日期</param>
		/// <param name="p_dtmOpenDate">OpenDate，如果是一次打印多次记录表单的类型（如病案记录），忽略OpenDate</param>
		public void m_mthSetPrintInfo(clsPatient p_objPatient,DateTime p_dtmInPatientDate,DateTime p_dtmOpenDate)
		{		
			m_blnIsFromDataSource=true;//表明是从数据库读取
			//clsPatient m_objPatient=p_objPatient;
			m_objPrintInfo=new clsPrintInfo_OperationRecordDoctor();
			m_objPrintInfo.m_strInPatientID=p_objPatient!=null? p_objPatient.m_StrInPatientID:"";					
			m_objPrintInfo.m_strPatientName=p_objPatient!=null? p_objPatient.m_ObjPeopleInfo.m_StrFirstName :"";
			m_objPrintInfo.m_strSex=p_objPatient!=null? p_objPatient.m_ObjPeopleInfo.m_StrSex:"";
			m_objPrintInfo.m_strAge=p_objPatient!=null? p_objPatient.m_ObjPeopleInfo.m_StrAge : "";
			m_objPrintInfo.m_strBedName=p_objPatient!=null? p_objPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName :"";
			m_objPrintInfo.m_strRoomName=p_objPatient!=null? p_objPatient.m_ObjInBedInfo.m_ObjLastRoomInfo.m_ObjRoom.m_StrRoomName : "";
            m_objPrintInfo.m_strDeptName = p_objPatient != null ? p_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjDept.m_StrDeptName : "";
            m_objPrintInfo.m_strAreaName = p_objPatient != null ? p_objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(p_dtmInPatientDate).m_ObjLastDept.m_ObjLastArea.m_ObjArea.m_StrAreaName : "";			
			m_objPrintInfo.m_strOccupation=p_objPatient!=null? p_objPatient.m_ObjPeopleInfo.m_StrOccupation : "";
			m_objPrintInfo.m_strOfficeAddress=p_objPatient!=null ? p_objPatient.m_ObjPeopleInfo.m_StrOffice_name : "";
			m_objPrintInfo.m_dtmInPatientDate=p_dtmInPatientDate;
			m_objPrintInfo.m_dtmOpenDate=p_dtmOpenDate;
            m_objPrintInfo.m_strHISInPatientID = p_objPatient!=null ? p_objPatient.m_StrHISInPatientID : "";
            m_objPrintInfo.m_dtmHISInDate = p_objPatient != null ? p_objPatient.m_DtmSelectedHISInDate : DateTime.MinValue;
		}

		/// <summary>
		/// 从数据库初始化打印内容。如果没有记录，打印空报表。(当从数据库读取时要调用.)
		/// </summary>
		public void m_mthInitPrintContent()
		{			
			if(m_objPrintInfo==null)
			{
				//	MDIParent.ShowInformationMessageBox("调用m_mthInitPrintContent之前请首先调用m_mthSetPrintInfo函数");
				return;
			}
			if(m_objPrintInfo.m_strInPatientID=="")
				return;			
			m_objPrintInfo.m_objSelectOperationRecord = m_objDomain.m_objGetOperationRecord(m_objPrintInfo.m_strInPatientID,m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"),m_objPrintInfo.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"));
			m_objPrintInfo.m_objSelectOperationRecordContent =  m_objDomain.m_objGetOperationRecordContent(m_objPrintInfo.m_strInPatientID,m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"),m_objPrintInfo.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"));
			m_objDomain.m_lngGetLastestOperationIDArr(m_objPrintInfo.m_strInPatientID,m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"),m_objPrintInfo.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"),out m_objPrintInfo.m_strOperationIDArr);
			clsOperationIDInOperation [] objOperationIDInOperationArr = m_objDomain.m_objGetOperationID();
			if(m_objPrintInfo.m_strOperationIDArr !=null)
			{
				m_objPrintInfo.m_strOperationNameArr=new string[m_objPrintInfo.m_strOperationIDArr.Length];
				for(int i0=0;i0< m_objPrintInfo.m_strOperationIDArr.Length;i0++)
				{
					for(int j1=0; j1<objOperationIDInOperationArr.Length;j1++)
					{
						if(objOperationIDInOperationArr[j1].strOperationID == m_objPrintInfo.m_strOperationIDArr[i0])
						{
							
							m_objPrintInfo.m_strOperationNameArr[i0]=objOperationIDInOperationArr[j1].strOperationName;
							break;
						}
					}
				}
			}
			//m_objPrintInfo.m_objNurseArr = m_objDomain.m_lngGetOperation_Nurse(m_objPrintInfo.m_strInPatientID,m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"),m_objPrintInfo.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"),out m_objPrintInfo.m_intNurseCount);			
			m_objDomain.m_lngGetDoctorSign(m_objPrintInfo.m_strInPatientID,m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"),m_objPrintInfo.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"),out m_objPrintInfo.m_objSelectDoctorSign);
			//获取图片信息
			m_objDomain.m_lngGetPics(m_objPrintInfo.m_strInPatientID,m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"),m_objPrintInfo.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"),out m_objPrintInfo.m_objPics);
			if(m_objPrintInfo.m_objSelectOperationRecord==null || m_objPrintInfo.m_objSelectOperationRecordContent==null) return ;   

			#region 打印行初始化
			m_objLine1 = new clsPrintLine1();
			m_objLine2 = new clsPrintLine2();
			m_objLine3 = new clsPrintLine3();
			m_objLine4 = new clsPrintLine4();
			m_objLine5 = new clsPrintLine5();
			m_objLine6 = new clsPrintLine6();
			m_objLine7 = new clsPrintLine7();
			m_objLine8 = new clsPrintLine8();
            //m_objLine9 = new clsPrintLine9();
            //m_objLine10 = new clsPrintLine10();
            //m_objLine11 = new clsPrintLine11();
            //m_objLine12 = new clsPrintLine12();
            //m_objLine13 = new clsPrintLine13();
			m_objLine14 = new clsPrintLine14();
			m_objLine15 = new clsPrintLine15();
			
			
			m_objLine8.m_ObjHandlePartEnd = new d_mthPrintPartEnd(m_mthHandle_8End);
            //m_objLine9.m_ObjHandlePartEnd = new d_mthPrintPartEnd(m_mthHandle_9End);
            //m_objLine10.m_ObjHandlePartEnd = new d_mthPrintPartEnd(m_mthHandle_10End);
            //m_objLine11.m_ObjHandlePartEnd = new d_mthPrintPartEnd(m_mthHandle_11End);
            //m_objLine12.m_ObjHandlePartEnd = new d_mthPrintPartEnd(m_mthHandle_12End);
            //m_objLine13.m_ObjHandlePartEnd = new d_mthPrintPartEnd(m_mthHandle_13End);
		
							
			m_objPrintContext = new clsPrintContext(
				new clsPrintLineBase[]{
										  m_objLine1,
										  m_objLine2,
										  m_objLine3,
										  m_objLine4,
										  m_objLine5,
										  m_objLine6,
										  m_objLine7,
										  m_objLine8,
                                          //m_objLine9,
                                          //m_objLine10,
                                          //m_objLine11,
                                          //m_objLine12,
                                          //m_objLine13,
										  m_objLine14,
										  m_objLine15
								
										 
										 
									  });
			m_objPrintContext.m_ObjPrintSign =  new clsPrintRecordSign();
			#endregion 
			m_mthSetPrintValue();
			//			//按记录时间(CreateDate)排序 
			//			m_mthSortTransData(ref m_objPrintInfo.m_objTransDataArr);
			//			//设置表单内容到打印中
			//			m_mthSetPrintContent(m_objPrintInfo.m_objTransDataArr,m_objPrintInfo.m_dtmFirstPrintDateArr);			
			//			m_objPrintInfo.m_objPrintDataArr=m_objPrintDataArr;
			m_blnWantInit=false;
			m_blnIsFromDataSource=true;
		}

		/// <summary>
		/// 设置打印内容。(当数据已经存在时使用。)
		/// </summary>
		/// <param name="p_objPrintContent">打印内容</param>
		public void m_mthSetPrintContent(object p_objPrintContent)
		{
			if(p_objPrintContent.GetType().Name !="clsPrintInfo_OperationRecordDoctor")
			{
				//MDIParent.ShowInformationMessageBox("参数错误");
				return;
			}
			m_objPrintInfo=(clsPrintInfo_OperationRecordDoctor)p_objPrintContent;

			
			
			#region 打印行初始化
			m_objLine1 = new clsPrintLine1();
			m_objLine2 = new clsPrintLine2();
			m_objLine3 = new clsPrintLine3();
			m_objLine4 = new clsPrintLine4();
			m_objLine5 = new clsPrintLine5();
			m_objLine6 = new clsPrintLine6();
			m_objLine7 = new clsPrintLine7();
			m_objLine8 = new clsPrintLine8();
            //m_objLine9 = new clsPrintLine9();
            //m_objLine10 = new clsPrintLine10();
            //m_objLine11 = new clsPrintLine11();
            //m_objLine12 = new clsPrintLine12();
            //m_objLine13 = new clsPrintLine13();
			m_objLine14 = new clsPrintLine14();
			m_objLine15 = new clsPrintLine15();
			
			
			m_objLine8.m_ObjHandlePartEnd = new d_mthPrintPartEnd(m_mthHandle_8End);
            //m_objLine9.m_ObjHandlePartEnd = new d_mthPrintPartEnd(m_mthHandle_9End);
            //m_objLine10.m_ObjHandlePartEnd = new d_mthPrintPartEnd(m_mthHandle_10End);
            //m_objLine11.m_ObjHandlePartEnd = new d_mthPrintPartEnd(m_mthHandle_11End);
            //m_objLine12.m_ObjHandlePartEnd = new d_mthPrintPartEnd(m_mthHandle_12End);
            //m_objLine13.m_ObjHandlePartEnd = new d_mthPrintPartEnd(m_mthHandle_13End);
		
							
			m_objPrintContext = new clsPrintContext(
				new clsPrintLineBase[]{
										  m_objLine1,
										  m_objLine2,
										  m_objLine3,
										  m_objLine4,
										  m_objLine5,
										  m_objLine6,
										  m_objLine7,
										  m_objLine8,
                                          //m_objLine9,
                                          //m_objLine10,
                                          //m_objLine11,
                                          //m_objLine12,
                                          //m_objLine13,
										  m_objLine14,
										  m_objLine15
								
										 
										 
									  });
			#endregion 
			m_mthSetPrintValue();

			m_blnIsFromDataSource=false;//表明是从文件直接提取信息
			//			m_objPrintInfo=(clsPrintInfo_IntensiveTend)p_objPrintContent;
			//			m_objPrintDataArr= m_objPrintInfo. m_objPrintDataArr ;		
			
			m_blnWantInit=false;
		}

		//		private void m_mthSetPrintContent(clsOperationRecordDoctor p_objRecord, clsOperationRecordContentDoctor p_objRecordContent)
		//		{
		//			m_objPrintInfo.m_objSelectOperationRecord=p_objRecord;
		//			m_objPrintInfo.m_objSelectOperationRecordContent=p_objRecordContent;
		//			m_blnWantInit=false;
		//		}

		/// <summary>
		/// 获取打印内容,(当从数据库读取时,调用本函数之前请首先调用m_mthSetPrintInfo函数)
		/// </summary>
		/// <returns>打印内容</returns>
		public object m_objGetPrintInfo()
		{	
			if(m_blnIsFromDataSource )
			{
				if(m_objPrintInfo==null)
				{
					//MDIParent.ShowInformationMessageBox("当从数据库读取时,调用m_objGetPrintInfo之前请首先调用m_mthSetPrintInfo函数");
					return null;
				}

				if(m_blnWantInit)
					m_mthInitPrintContent();				
			}			
			
			return m_objPrintInfo;
		}		

		/// <summary>
		/// 初始化打印变量,本例传入空对象即可.
		/// </summary>
		public void m_mthInitPrintTool(object p_objArg)
		{				
			
			#region 有关打印初始化

			//pdcOperation =new System.Drawing.Printing.PrintDocument();
			m_objPrintDateInfo=new clsPrintDateInfo();
					
			//this.pdcOperation.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdcOperation_PrintPage);
			m_fotTitleFont = new Font("SimSun", 16);
			m_fotHeaderFont = new Font("SimSun", 18,FontStyle.Bold);
			m_fotSmallFont = new Font("SimSun",12);
			m_GridPen = new Pen(Color.Black,1);
			m_slbBrush = new SolidBrush(Color.Black);
			

			#region 打印行初始化
			m_objLine1 = new clsPrintLine1();
			m_objLine2 = new clsPrintLine2();
			m_objLine3 = new clsPrintLine3();
			m_objLine4 = new clsPrintLine4();
			m_objLine5 = new clsPrintLine5();
			m_objLine6 = new clsPrintLine6();
			m_objLine7 = new clsPrintLine7();
			m_objLine8 = new clsPrintLine8();
            //m_objLine9 = new clsPrintLine9();
            //m_objLine10 = new clsPrintLine10();
            //m_objLine11 = new clsPrintLine11();
            //m_objLine12 = new clsPrintLine12();
            //m_objLine13 = new clsPrintLine13();
			m_objLine14 = new clsPrintLine14();
			m_objLine15 = new clsPrintLine15();
			
			
			m_objLine8.m_ObjHandlePartEnd = new d_mthPrintPartEnd(m_mthHandle_8End);
            //m_objLine9.m_ObjHandlePartEnd = new d_mthPrintPartEnd(m_mthHandle_9End);
            //m_objLine10.m_ObjHandlePartEnd = new d_mthPrintPartEnd(m_mthHandle_10End);
            //m_objLine11.m_ObjHandlePartEnd = new d_mthPrintPartEnd(m_mthHandle_11End);
            //m_objLine12.m_ObjHandlePartEnd = new d_mthPrintPartEnd(m_mthHandle_12End);
            //m_objLine13.m_ObjHandlePartEnd = new d_mthPrintPartEnd(m_mthHandle_13End);
		
							
			m_objPrintContext = new clsPrintContext(
				new clsPrintLineBase[]{
										  m_objLine1,
										  m_objLine2,
										  m_objLine3,
										  m_objLine4,
										  m_objLine5,
										  m_objLine6,
										  m_objLine7,
										  m_objLine8,
                                          //m_objLine9,
                                          //m_objLine10,
                                          //m_objLine11,
                                          //m_objLine12,
                                          //m_objLine13,
										  m_objLine14,
										  m_objLine15
								
										 
										 
									  });
			#endregion 
			#endregion

			

		}

		/// <summary>
		/// 释放打印变量
		/// </summary>
		public void m_mthDisposePrintTools(object p_objArg)
		{
			m_fotTitleFont.Dispose();
			m_fotHeaderFont.Dispose();
			m_fotSmallFont.Dispose();
			//			m_fotTinyFont.Dispose();
			m_GridPen.Dispose();
			m_slbBrush.Dispose();
		}

		/// <summary>
		/// 打印开始
		/// </summary>
		/// <param name="p_objPrintArg">此处p_objPrintArg要求为PrintEventArgs类型的对象</param>
		public void m_mthBeginPrint(object p_objPrintArg)
		{			
			m_mthBeginPrintSub((PrintEventArgs)p_objPrintArg);
		}

		private bool m_blnIsDummy = false;
		public bool m_BlnIsDummy
		{
			set 
			{
				m_blnIsDummy = value;
			}
		}

//		private int m_intPageNeedToPrint = 0;
//		public int m_IntPageNeedToPrint
//		{
//			set
//			{
//				m_intPageNeedToPrint = value;
//			}
//		}

		private bool m_blnPreview = true;
		/// <summary>
		/// 是否预览
		/// </summary>
		public bool m_BlnPreview
		{
			set
			{
				m_blnPreview = value;
			}
		}

		/// <summary>
		/// 打印中
		/// </summary>
		/// <param name="p_objPrintArg">此处p_objPrintArg要求为PrintPageEventArgs类型的对象</param>
		public void m_mthPrintPage(object p_objPrintArg)
		{
			PrintPageEventArgs e = (PrintPageEventArgs)p_objPrintArg;

			if(m_blnPreview)
			{
				m_mthPrintPageSub(e);
			}
			else
			{
				if(m_blnIsDummy)
				{				
					m_mthPrintPageSub(e);
					e.Graphics.Clear(Color.White);
				}			
				m_mthPrintPageSub(e);
				e.HasMorePages = false;
				m_mthReset();
			}

			#region old
//			if(m_intPageNeedToPrint == 1)
//			{
//				m_mthPrintPageSub(e);
//				e.HasMorePages = false;			
//				m_mthReset();
//			}
//			else
//			{
//				m_mthPrintPageSub(e);
//				e.Graphics.Clear(Color.White);
//				m_mthPrintPageSub(e);
//				e.HasMorePages = false;
//			}
			#endregion
		}

		/// <summary>
		/// 打印结束。一般使用它来更新数据库信息。
		/// </summary>
		/// <param name="p_objPrintArg">此处p_objPrintArg要求为PrintEventArgs类型的对象</param>
		public void m_mthEndPrint(object p_objPrintArg)
		{		
			m_mthEndPrintSub((System.Drawing.Printing.PrintEventArgs)p_objPrintArg);
		}	

		private void m_mthBeginPrintSub(PrintEventArgs p_objPrintArg)
		{
		}
		
		private void m_mthPrintPageSub(PrintPageEventArgs e)
		{
			try
			{
				e.HasMorePages =false;

				int intTop = (int)enmRectangleInfo.TopY;

				if(m_intPages==1)
					m_mthPrintTitleInfo(e);
				else
				{
					intTop = (int)enmRectangleInfo.TopY - 100;
					e.Graphics.DrawLine(m_GridPen,(int)enmRectangleInfo.LeftX,intTop,(int)enmRectangleInfo.RightX,intTop);

					m_intYPos -= 100;
				}

				Font fntNormal = new Font("SimSun",11);
//				if(m_intPages!=1)
//					m_intYPos =m_intYPos+5;
//				e.Graphics.DrawString("（第" +m_intPages+ "页）",new Font("SimSun",11) ,Brushes.Black,(int)enmRectangleInfo.LeftX+350,1040);

				while(m_objPrintContext.m_BlnHaveMoreLine)
				{
					m_objPrintContext.m_mthPrintNextLine(ref m_intYPos,e.Graphics,fntNormal);
					
					#region 换页处理
					if(m_intYPos >=(int)enmRectangleInfo.BottomY - 40
						&& m_objPrintContext.m_BlnHaveMoreLine)
					{
						e.HasMorePages = true;
						switch(m_intEndIndex)
						{
											
							case 0:
								m_mthHandle_8End(m_intYPos,e.Graphics,fntNormal);
								m_intEndIndex--;
								break;
							case 1:
							
								m_mthHandle_9End(m_intYPos,e.Graphics,fntNormal);
								m_intEndIndex--;
								break;
							case 2:
							
								m_mthHandle_10End(m_intYPos,e.Graphics,fntNormal);
								m_intEndIndex--;
								break;
							case 3:
							
								m_mthHandle_11End(m_intYPos,e.Graphics,fntNormal);
								m_intEndIndex--;
								break;
							case 4:
								m_mthHandle_12End(m_intYPos,e.Graphics,fntNormal);
								m_intEndIndex--;
								break;
							case 5:
							
								m_mthHandle_13End(m_intYPos,e.Graphics,fntNormal);
								m_intEndIndex--;
								break;
											
						}

						e.Graphics.DrawLine(m_GridPen,(int)enmRectangleInfo.LeftX,m_intYPos-5 ,(int)enmRectangleInfo.RightX,m_intYPos-5);
						e.Graphics.DrawLine(m_GridPen,(int)enmRectangleInfo.LeftX,intTop,(int)enmRectangleInfo.LeftX,m_intYPos-5);
						e.Graphics.DrawLine(m_GridPen,(int)enmRectangleInfo.RightX,intTop,(int)enmRectangleInfo.RightX,m_intYPos-5);
									
						m_intPages++;

						m_intYPos = intTop+5;
						return;
					}
				#endregion 
				
				}
				m_intYPos=m_intYPos-5;
				e.Graphics.DrawLine(m_GridPen,(int)enmRectangleInfo.LeftX,m_intYPos ,(int)enmRectangleInfo.RightX,m_intYPos);
				e.Graphics.DrawLine(m_GridPen,(int)enmRectangleInfo.LeftX,intTop,(int)enmRectangleInfo.LeftX,m_intYPos);
				e.Graphics.DrawLine(m_GridPen,(int)enmRectangleInfo.RightX,intTop,(int)enmRectangleInfo.RightX,m_intYPos);
	
				m_intYPos += (int)enmRectangleInfo.RowStep+15;
				Font fntSign = new Font("",6);
				while(m_objPrintContext.m_BlnHaveMoreSign)
				{
					m_objPrintContext.m_mthPrintNextSign((int)enmRectangleInfo.LeftX,m_intYPos,e.Graphics,fntSign);

					m_intYPos += (int)enmRectangleInfo.RowStep-10;				
				}
				//全部打完
//				m_mthReset();
				
			}
			catch
			{
			}
			
		}

		private void m_mthReset()
		{
			m_objPrintContext.m_mthReset();
			m_intPages=1;
			m_intEndIndex=0;
			m_intYPos = (int)enmRectangleInfo.TopY+5;
		}
		
		

		private void m_mthEndPrintSub(System.Drawing.Printing.PrintEventArgs p_objPrintArg)
		{
			//打印第二页的时候不更新打印时间
			if(m_blnIsFromDataSource && !m_blnIsDummy) 
				m_mthFirstPrintDateSave();

			m_mthResetWhenEndPrint();
		}

		/// <summary>
		/// 每次打印结束之后的复位,无论是打印当前页或者打印全部.
		/// </summary>
		private void m_mthResetWhenEndPrint()
		{
			m_mthReset();
		}


		#region 打印

		
		#region 有关打印的声明

		
		private clsPrintContext m_objPrintContext;
//		private System.Drawing.Printing.PrintDocument pdcOperation;
		private clsPrintDateInfo m_objPrintDateInfo;
	
		/// <summary>
		/// 标题的字体(20 bold)
		/// </summary>
		private Font m_fotTitleFont;
		/// <summary>
		/// 表头的字体(14 )
		/// </summary>
		private Font m_fotHeaderFont;
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
		private SolidBrush m_slbBrush;
		/// <summary>
		/// 当前打印位置（Y）
		/// </summary>
		private int m_intYPos = (int)enmRectangleInfo.TopY+5;
		/// <summary>
		/// 打印的第几个栏目
		/// </summary>
		private int m_intEndIndex = 0;
		private int m_intPages=1;
	
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

			BottomY=1180
		
		}
		
     	#endregion

		#region 打印行定义
		private clsPrintLine1 m_objLine1;
		private clsPrintLine2 m_objLine2;
		private clsPrintLine3 m_objLine3;
		private clsPrintLine4 m_objLine4;
		private clsPrintLine5 m_objLine5;
		private clsPrintLine6 m_objLine6;
		private clsPrintLine7 m_objLine7;
		private clsPrintLine8 m_objLine8;
        //private clsPrintLine9 m_objLine9;
        //private clsPrintLine10 m_objLine10;
        //private clsPrintLine11 m_objLine11;
        //private clsPrintLine12 m_objLine12;
        //private clsPrintLine13 m_objLine13;
		private clsPrintLine14 m_objLine14;
		private clsPrintLine15 m_objLine15;
			
		#endregion 

		#region 每一打印节段的处理
		private void m_mthHandle_8End(int p_intEndY,Graphics p_objGrp,Font p_fntNormalText)
		{/*手术经过*/
			
			p_intEndY=p_intEndY-5;
			int intX1=(int)enmRectangleInfo.LeftX;
			int intX2=(int)enmRectangleInfo.RightX ;
			p_objGrp.DrawLine(Pens.Black,intX1,p_intEndY,intX2,p_intEndY);

			
		
			m_intYPos=p_intEndY+5 ;
			m_intEndIndex++;
		}
		private void m_mthHandle_9End(int p_intEndY,Graphics p_objGrp,Font p_fntNormalText)
		{/*病理所见*/
			
			p_intEndY=p_intEndY-5;
			int intX1=(int)enmRectangleInfo.LeftX;
			int intX2=(int)enmRectangleInfo.RightX ;
			p_objGrp.DrawLine(Pens.Black,intX1,p_intEndY,intX2,p_intEndY);

			
		
			m_intYPos=p_intEndY+5 ;
			m_intEndIndex++;
		}
		private void m_mthHandle_10End(int p_intEndY,Graphics p_objGrp,Font p_fntNormalText)
		{/*手术期间输液（输血）*/
			p_intEndY=p_intEndY-5;
			int intX1=(int)enmRectangleInfo.LeftX;
			int intX2=(int)enmRectangleInfo.RightX ;
			p_objGrp.DrawLine(Pens.Black,intX1,p_intEndY,intX2,p_intEndY);

			
			
			m_intYPos=p_intEndY+5 ;
			m_intEndIndex++;
		}
		private void m_mthHandle_11End(int p_intEndY,Graphics p_objGrp,Font p_fntNormalText)
		{/*引流或填塞*/
			p_intEndY=p_intEndY-5;
			int intX1=(int)enmRectangleInfo.LeftX;
			int intX2=(int)enmRectangleInfo.RightX ;
			p_objGrp.DrawLine(Pens.Black,intX1,p_intEndY,intX2,p_intEndY);

			
			
			m_intYPos=p_intEndY+5 ;
			m_intEndIndex++;
		}
		private void m_mthHandle_12End(int p_intEndY,Graphics p_objGrp,Font p_fntNormalText)
		{/*标本肉眼或特殊记录*/

			p_intEndY=p_intEndY-5;
			int intX1=(int)enmRectangleInfo.LeftX;
			int intX2=(int)enmRectangleInfo.RightX ;
			p_objGrp.DrawLine(Pens.Black,intX1,p_intEndY,intX2,p_intEndY);
				
				
			m_intYPos=p_intEndY+5 ;
			m_intEndIndex++;
			//			}
			
		}
		private void m_mthHandle_13End(int p_intEndY,Graphics p_objGrp,Font p_fntNormalText)
		{/*术后总结与讲评意见*/
	
			m_intYPos=p_intEndY ;
			m_intEndIndex++;
		}
		
		
		#endregion 
		

		#region 打印之前查找该条记录的第一次打印时间，判断是否应该打印痕迹
//		/// <summary>
//		/// 打印之前获得该条记录的第一次打印时间，判断是否应该打印痕迹
//		/// </summary>
//		private string m_strGetFirstPrintDate(string p_strInPatientID,string p_strInPatientDate,string p_strOpenDate)
//		{
//			if(p_strInPatientID == null || p_strInPatientID == "" || p_strInPatientDate == null || p_strInPatientDate == "" || p_strOpenDate == null || p_strOpenDate == "")
//				return null;
//			
//			return m_objDomain.m_lngGetFirstPrintDate(p_strInPatientID,p_strInPatientDate,p_strCreateDate,m_strTableName);
//		}
		#endregion

		#region 保存第一次打印时间
		/// <summary>
		/// 保存第一次打印时间
		/// </summary>
		private void m_mthFirstPrintDateSave()
		{
			if(m_objPrintInfo != null && m_objPrintInfo.m_objSelectOperationRecordContent !=null && m_objPrintInfo.m_objSelectOperationRecord !=null && (m_objPrintInfo.m_objSelectOperationRecord.m_strFirstPrintDate == null || m_objPrintInfo.m_objSelectOperationRecord.m_strFirstPrintDate == ""))
			{
				string strFirstrPrintDate;
				long lngRes = m_objDomain.m_lngGetFirstPrintDate(m_objPrintInfo.m_strInPatientID,
					m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"),
					DateTime.Parse(m_objPrintInfo.m_objSelectOperationRecordContent.m_strOpenDate).ToString("yyyy-MM-dd HH:mm:ss"),
					out strFirstrPrintDate);

				if(lngRes<=0)
				{
					MDIParent.ShowInformationMessageBox("更新打印时间失败");
				
					return;
				}
				
				lngRes=m_objDomain.m_lngUpdateFirstPrintDate(m_objPrintInfo.m_strInPatientID,m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"),m_objPrintInfo.m_objSelectOperationRecordContent.m_strOpenDate,strFirstrPrintDate);

				if(lngRes<=0)
				{
					MDIParent.ShowInformationMessageBox("更新打印时间失败");
				
					return;
				}
			}
//			string[] m_strInPatientIDArr = new String[1]{m_objPrintInfo.m_strInPatientID};
//			string[] m_strInPatientDateArr = new String[1]{m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss")};
//			string[] m_strOpenDateArr = new String[1]{DateTime.Parse(m_objPrintInfo.m_objSelectOperationRecordContent.m_strOpenDate).ToString("yyyy-MM-dd HH:mm:ss")};
//			string m_strTableName = "OperationRecordDoctor";
//			string strFirstPrintDate = m_strGetFirstPrintDate(m_strInPatientIDArr[0],m_strInPatientDateArr[0],m_strOpenDateArr[0]);
//			if(strFirstPrintDate == null || strFirstPrintDate == "")
//			{
//				long m_lngRes =m_objPrintDateInfo.m_lngSetFirstPrintDate(m_strInPatientIDArr,m_strInPatientDateArr,m_strOpenDateArr,m_strTableName);
//			}
//			if(m_objPrintInfo != null && m_objPrintInfo.m_objSelectOperationRecordContent !=null && m_objPrintInfo.m_objSelectOperationRecord !=null)
//			{
//				long lngRes=m_objDomain.m_lngUpdateFirstPrintDate(m_objPrintInfo.m_strInPatientID,m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"),m_objPrintInfo.m_objSelectOperationRecordContent.m_strOpenDate,m_objPrintInfo.m_objSelectOperationRecord.m_strFirstPrintDate);
//				if(lngRes<=0)
//				{
//					switch(lngRes)
//					{
//						case (long)iCareData.enmOperationResult.Not_permission:
//							MDIParent.s_mthShowNotPermitMessage();
//							break;
//						case (long)iCareData.enmOperationResult.DB_Fail://如果不是首次打印则返回值为0，因此此处不能加此判断							
//							break;
//						default : 
//							MDIParent.ShowInformationMessageBox("更新打印时间失败");
//							break;
//					}
//					return;
//				}
//			}
		}
		#endregion

		private  void m_mthSetPrintValue()
		{
			#region 给每一行的元素赋值
			if(m_objPrintInfo !=null)
			{
				m_objLine1.m_ObjPrintLineInfo = m_objPrintInfo;
		
				///////////////2行/////////////////
				Object[] objData2=new object[4];
				objData2[0]=m_objPrintInfo.m_objSelectOperationRecordContent.m_strDiagnoseBeforeOperation;
				objData2[1]=m_objPrintInfo.m_objSelectOperationRecord.m_strDiagnoseBeforeOperationXML;
				objData2[2]=m_objPrintInfo.m_objSelectOperationRecordContent.m_strDiagnoseAfterOperation;
				objData2[3]=m_objPrintInfo.m_objSelectOperationRecord.m_strDiagnoseAfterOperationXML;
			
			
				m_objLine2.m_ObjPrintLineInfo=objData2;
			
				///////////////3行/////////////////
				Object[]  objData3=new object[2];
				#region 通过ID读取手术名称.暂改为直接读存名称				
//				string strOperationName="";
//				if( m_objPrintInfo.m_strOperationIDArr !=null)
//				{
//					if(m_objPrintInfo.m_strOperationNameArr!=null)
//						for(int i1=0; i1<m_objPrintInfo.m_strOperationIDArr.Length;i1++)//lstOperationID.CheckedItems.Count
//						{	
//							if(i1==0)
//								strOperationName +=m_objPrintInfo.m_strOperationNameArr[i1];//((clsOperationIDInOperation)(lstOperationID.CheckedItems[i1])).strOperationName;
//							else
//							{
//								strOperationName +="; "+m_objPrintInfo.m_strOperationNameArr[i1];//((clsOperationIDInOperation)(lstOperationID.CheckedItems[i1])).strOperationName;
//							}
//					
//						}
//					else MDIParent.ShowInformationMessageBox("手术名称数据有误");
//				}
//				objData3=strOperationName;
				#endregion 通过ID读取手术名称.暂改为直接读存名称
				objData3[0]=m_objPrintInfo.m_objSelectOperationRecordContent.m_strOperationName;
				objData3[1]=m_objPrintInfo.m_objSelectOperationRecord.m_strOperationNameXML;
				m_objLine3.m_ObjPrintLineInfo=objData3;
			
				///////////////4行/////////////////
				string strTemp="";
				Object[] objData4=new object[3];
				if(m_objPrintInfo.m_objSelectDoctorSign !=null)
				{
//					if(m_objPrintInfo.m_objSelectDoctorSign.m_strOperationDoctorNameArr!=null)
//						for(int i=0;i<m_objPrintInfo.m_objSelectDoctorSign.m_strOperationDoctorNameArr.Length;i++)
//						{						
//							strTemp=strTemp +m_objPrintInfo.m_objSelectDoctorSign.m_strOperationDoctorNameArr[i];
//							if(i < m_objPrintInfo.m_objSelectDoctorSign.m_strOperationDoctorNameArr.Length-1)
//							{
//								strTemp += ",";
//							}
//						}
//					objData4[0]=strTemp;
//					strTemp="";
//					if(m_objPrintInfo.m_objSelectDoctorSign.m_strAssistantNameArr!=null)
//						for(int i=0;i<m_objPrintInfo.m_objSelectDoctorSign.m_strAssistantNameArr.Length;i++)
//						{
//							strTemp=strTemp +m_objPrintInfo.m_objSelectDoctorSign.m_strAssistantNameArr[i];
//							if(i < m_objPrintInfo.m_objSelectDoctorSign.m_strAssistantNameArr.Length-1)
//							{
//								strTemp += ",";
//							}
//						}
//					objData4[1]=strTemp;
//					strTemp="";
//					if(m_objPrintInfo.m_objSelectDoctorSign.m_strNurseNameArr!=null)
//						for(int i=0;i<m_objPrintInfo.m_objSelectDoctorSign.m_strNurseNameArr.Length;i++)
//						{
//							strTemp=strTemp +m_objPrintInfo.m_objSelectDoctorSign.m_strNurseNameArr[i];
//							if(i < m_objPrintInfo.m_objSelectDoctorSign.m_strNurseNameArr.Length-1)
//							{
//								strTemp += ",";
//							}
//						}
//					objData4[2]=strTemp;
                    #region 签名集合
                     
                    //手术者
                    if (m_objPrintInfo.m_objSelectOperationRecord.objSignerArr != null)
                    {
                        string strTemp1 = "";
                        for (int i = 0; i < m_objPrintInfo.m_objSelectOperationRecord.objSignerArr.Length; i++)
                        {
                            if (m_objPrintInfo.m_objSelectOperationRecord.objSignerArr[i].controlName == "m_lsvOperationDoctor")
                            {
                                strTemp1 += m_objPrintInfo.m_objSelectOperationRecord.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR+" "; 
                            }
                            
                        }
                        //删除最后一个空格
                        if(strTemp1.LastIndexOf(" ")>0)
                        strTemp1.Remove(strTemp1.LastIndexOf(" "));
                        objData4[0] = strTemp1;
                    }
                    //助手
                    if (m_objPrintInfo.m_objSelectOperationRecord.objSignerArr != null)
                    {
                        string strTemp2 = "";
                        for (int i = 0; i < m_objPrintInfo.m_objSelectOperationRecord.objSignerArr.Length; i++)
                        {
                            if (m_objPrintInfo.m_objSelectOperationRecord.objSignerArr[i].controlName == "m_lsvAssistant")
                            {
                                strTemp2 += m_objPrintInfo.m_objSelectOperationRecord.objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName+" ";
                            }
                            
                        }
                        //删除最后一个空格
                        if (strTemp2.LastIndexOf(" ") > 0)
                        strTemp2.Remove(strTemp2.LastIndexOf(" "));
                        objData4[1] = strTemp2;
                    }
                    //护士
                    if (m_objPrintInfo.m_objSelectOperationRecord.objSignerArr != null)
                    {
                        string strTemp3 = "";
                        for (int i = 0; i < m_objPrintInfo.m_objSelectOperationRecord.objSignerArr.Length; i++)
                        {
                            if (m_objPrintInfo.m_objSelectOperationRecord.objSignerArr[i].controlName == "m_lsvNurse")
                            {
                                strTemp3 +=m_objPrintInfo.m_objSelectOperationRecord.objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName+" ";
                            }
                            
                        }
                        //删除最后一个空格
                        if (strTemp3.LastIndexOf(" ") > 0)
                        strTemp3.Remove(strTemp3.LastIndexOf(" "));
                        objData4[2] = strTemp3;
                    }
                   
                  
                    #endregion 签名		
                    //objData4[0]=m_objPrintInfo.m_objSelectOperationRecordContent.m_strOperationDoctor;
                    //objData4[1]=m_objPrintInfo.m_objSelectOperationRecordContent.m_strAssistant;
                    //objData4[2]=m_objPrintInfo.m_objSelectOperationRecordContent.m_strNurse;	//新的护士签名
					m_objLine4.m_ObjPrintLineInfo=objData4;
				}

				///////////////5行/////////////////
				Object objData5=new object();
				TimeSpan tsTimeSpanForPrint = DateTime.Parse( m_objPrintInfo.m_objSelectOperationRecordContent.m_strOperationEndDate)
					- DateTime.Parse( m_objPrintInfo.m_objSelectOperationRecordContent.m_strOperationBeginDate);
				int intHour = (int)tsTimeSpanForPrint.TotalHours;
				int intMinute = (int)(tsTimeSpanForPrint.TotalMinutes - intHour*60);
            
				strTemp=DateTime.Parse( m_objPrintInfo.m_objSelectOperationRecordContent.m_strOperationBeginDate).ToString("yyyy年MM月dd日 HH时mm分") +
					"开始  至  " +DateTime.Parse(m_objPrintInfo.m_objSelectOperationRecordContent.m_strOperationEndDate).ToString("HH时mm分") +
					"完毕， 共" +intHour.ToString()+" 时 "+intMinute.ToString()+" 分钟。";
				objData5=strTemp;		
				m_objLine5.m_ObjPrintLineInfo=objData5;
				///////////////6行/////////////////
				Object[] objData6=new object[6];
				objData6[0]=m_objPrintInfo.m_objSelectOperationRecordContent.m_strAnaesthesiaBeforeOperation;
				objData6[1]=m_objPrintInfo.m_objSelectOperationRecord.m_strAnaesthesiaBeforeOperationXML;
				objData6[2]=m_objPrintInfo.m_objSelectOperationRecordContent.m_strAnaesthesiaInOperation;
				objData6[3]=m_objPrintInfo.m_objSelectOperationRecord.m_strAnaesthesiaInOperationXML;
				objData6[4]=m_objPrintInfo.m_objSelectOperationRecordContent.m_strAnaesthesiaCategoryDosage;
				objData6[5]=m_objPrintInfo.m_objSelectOperationRecord.m_strAnaesthesiaCategoryDosageXML;
				m_objLine6.m_ObjPrintLineInfo=objData6;
				///////////////7行/////////////////
				Object[] objData7=new object[2];
				TimeSpan tsTimeSpanForPrint2 = DateTime.Parse( m_objPrintInfo.m_objSelectOperationRecordContent.m_strAnaesthesiaEndDate)
					- DateTime.Parse( m_objPrintInfo.m_objSelectOperationRecordContent.m_strAnaesthesiaBeginDate);
				int intHour2 = (int)tsTimeSpanForPrint2.TotalHours;
				int intMinute2 = (int)(tsTimeSpanForPrint2.TotalMinutes - intHour2*60);
            
				strTemp=DateTime.Parse( m_objPrintInfo.m_objSelectOperationRecordContent.m_strAnaesthesiaBeginDate).ToString("HH时mm分") +
					"开始至" +DateTime.Parse( m_objPrintInfo.m_objSelectOperationRecordContent.m_strOperationEndDate).ToString("HH时mm分") +
					"完毕，共" +intHour2.ToString()+" 时 "+intMinute2.ToString()+" 分钟。";
				objData7[0]=strTemp;

				strTemp="";
//				if(m_objPrintInfo.m_objNurseArr !=null)
//				{
//					for(int i=0;i<m_objPrintInfo.m_objNurseArr.Length;i++)
//					{
//						if(m_objPrintInfo.m_objNurseArr[i].strNurseFlag=="5")
//							strTemp=strTemp +m_objPrintInfo.m_objNurseArr[i].strNurseName+ " ";
//					}
//				}
                //麻醉
                if (m_objPrintInfo.m_objSelectOperationRecord.objSignerArr != null)
                {
                    string strTemp4 = "";
                    for (int i = 0; i < m_objPrintInfo.m_objSelectOperationRecord.objSignerArr.Length; i++)
                    {
                        if (m_objPrintInfo.m_objSelectOperationRecord.objSignerArr[i].controlName == "m_lsvAnaesther")
                        {
                            strTemp4 += m_objPrintInfo.m_objSelectOperationRecord.objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName+" ";

                         }
                    }
                    //删除最后一个空格
                    if (strTemp4.LastIndexOf(" ") > 0)
                    strTemp4.Remove(strTemp4.LastIndexOf(" "));
                    objData7[1] = strTemp4;
                }
				//objData7[1]=m_objPrintInfo.m_objSelectOperationRecordContent.m_strAnaesther ;
				m_objLine7.m_ObjPrintLineInfo=objData7;
			
				///////////////8行/////////////////
				Object[] objData8=new object[2];
				objData8[0]=m_objPrintInfo.m_objSelectOperationRecordContent.m_strOperationProcess;
				objData8[1]=m_objPrintInfo.m_objSelectOperationRecord.m_strOperationProcessXML;
			
				m_objLine8.m_ObjPrintLineInfo=objData8;
				///////////////9行/////////////////
				Object[] objData9=new object[3];
				objData9[0]=m_objPrintInfo.m_objSelectOperationRecordContent.m_strPathology;
				objData9[1]=m_objPrintInfo.m_objSelectOperationRecord.m_strPathologyXML;
				objData9[2] = m_objPrintInfo.m_objPics;

                //m_objLine9.m_ObjPrintLineInfo=objData9;
				///////////////10行/////////////////
				Object[] objData10=new object[2];
	
				objData10[0]=m_objPrintInfo.m_objSelectOperationRecordContent.m_strInLiquid;
				objData10[1]=m_objPrintInfo.m_objSelectOperationRecord.m_strInLiquidXML;
                //m_objLine10.m_ObjPrintLineInfo=objData10;
				///////////////11行/////////////////
				Object[] objData11=new object[3];
				objData11[0]=m_objPrintInfo.m_objSelectOperationRecordContent.m_strOutFlow;
				objData11[1]=m_objPrintInfo.m_objSelectOperationRecord.m_strOutFlowXML;

		
				strTemp="";
//				if(m_objPrintInfo.m_objNurseArr !=null)
//				{
//					for(int i=0;i<m_objPrintInfo.m_objNurseArr.Length;i++)
//					{
//						if(m_objPrintInfo.m_objNurseArr[i].strNurseFlag=="3")
//							strTemp=strTemp +m_objPrintInfo.m_objNurseArr[i].strNurseName+ " ";
//					}
//				}
                //有效医师
                if (m_objPrintInfo.m_objSelectOperationRecord.objSignerArr != null)
                { 
                    string strTemp5 = "";
                    for (int i = 0; i < m_objPrintInfo.m_objSelectOperationRecord.objSignerArr.Length; i++)
                    {
                        if (m_objPrintInfo.m_objSelectOperationRecord.objSignerArr[i].controlName == "lsvSign")
                        {
                            strTemp5 += m_objPrintInfo.m_objSelectOperationRecord.objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName+" ";

                         }
                    }
                    //删除最后一个空格
                    if (strTemp5.LastIndexOf(" ") > 0)
                    strTemp5.Remove(strTemp5.LastIndexOf(" "));
                    objData11[2] = strTemp5;
                }
				//objData11[2]=m_objPrintInfo.m_objSelectOperationRecordContent.m_strDoctor1; 

                //m_objLine11.m_ObjPrintLineInfo=objData11;
                /////////////////12行/////////////////
                //Object[] objData12=new object[2];
                //objData12[0]=m_objPrintInfo.m_objSelectOperationRecordContent.m_strSampleOrExtraRecord;
                //objData12[1]=m_objPrintInfo.m_objSelectOperationRecord.m_strSampleOrExtraRecordXML;
                //m_objLine12.m_ObjPrintLineInfo=objData12;
                /////////////////13行/////////////////
                //Object[] objData13=new object[2];
                //objData13[0]=m_objPrintInfo.m_objSelectOperationRecordContent.m_strSummaryAfterOperation;
                //objData13[1]=m_objPrintInfo.m_objSelectOperationRecord.m_strSummaryAfterOperationXML;

                //m_objLine13.m_ObjPrintLineInfo=objData13;
				///////////////14行/////////////////
				Object objData14=new object();
		
				strTemp="";
//				if(m_objPrintInfo.m_objNurseArr !=null)
//				{
//					for(int i=0;i<m_objPrintInfo.m_objNurseArr.Length;i++)
//					{
//						if(m_objPrintInfo.m_objNurseArr[i].strNurseFlag=="4")
//							strTemp=strTemp +m_objPrintInfo.m_objNurseArr[i].strNurseName+ " ";
//					}
//				}
				objData14=m_objPrintInfo.m_objSelectOperationRecordContent.m_strDoctor2; 
				m_objLine14.m_ObjPrintLineInfo=objData14;
				///////////////15行/////////////////
				Object objData15=new object();
				objData15=DateTime.Parse( m_objPrintInfo.m_objSelectOperationRecord.m_strCreateDate).ToString("yyyy年M月d日");
				m_objLine15.m_ObjPrintLineInfo=objData15;
			}
			else 
			{
				m_objLine1.m_ObjPrintLineInfo = null;
		
				///////////////2行/////////////////
				string[] objData2=new string[4]{"","","",""};				
			
				m_objLine2.m_ObjPrintLineInfo=objData2;
			
				///////////////3行/////////////////
				string  objData3="";				
				m_objLine3.m_ObjPrintLineInfo=objData3;
			
				///////////////4行/////////////////
				string strTemp="";
				string[] objData4=new string[3]{"","",""};				
				m_objLine4.m_ObjPrintLineInfo=objData4;				

				///////////////5行/////////////////
				Object objData5=new object();
				
				strTemp="    年  月  日   时  分" +
					"开始  至 " +"  时  分" +
					"完毕，共" +  "  时"+"  分钟。";
				objData5=strTemp;		
				m_objLine5.m_ObjPrintLineInfo=objData5;
				///////////////6行/////////////////
				string[] objData6=new string[6]{"","","","","",""};				
				m_objLine6.m_ObjPrintLineInfo=objData6;
				///////////////7行/////////////////
				Object[] objData7=new object[2];				
				strTemp="  时  分" +
					"开始  至 " +"  时  分" +
					"完毕，共" +  "  时"+"  分钟。";
				objData7[0]=strTemp;				
				objData7[1]="" ;
				m_objLine7.m_ObjPrintLineInfo=objData7;
			
				///////////////8行/////////////////
				string[] objData8=new string[2]{"",""};			
				m_objLine8.m_ObjPrintLineInfo=objData8;
				///////////////9行/////////////////
                //string[] objData9=new string[2]{"",""};	
                //m_objLine9.m_ObjPrintLineInfo=objData9;
                /////////////////10行/////////////////
                //string[] objData10=new string[2]{"",""};	
                //m_objLine10.m_ObjPrintLineInfo=objData10;
                /////////////////11行/////////////////
                //string[] objData11=new string[3]{"","",""};	
                //m_objLine11.m_ObjPrintLineInfo=objData11;
                /////////////////12行/////////////////
                //string[] objData12=new string[2]{"",""};	
                //m_objLine12.m_ObjPrintLineInfo=objData12;
                /////////////////13行/////////////////
                //string[] objData13=new string[2]{"",""};	
                //m_objLine13.m_ObjPrintLineInfo=objData13;
				///////////////14行/////////////////				
				m_objLine14.m_ObjPrintLineInfo="";
				///////////////15行/////////////////
				Object objData15=new object();
				objData15="   年  月  日";
				m_objLine15.m_ObjPrintLineInfo=objData15;
			}
			#endregion 
		}
		 
//		private void pdcOperation_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
//		{
//			try
//			{
//				e.HasMorePages =false;
//				m_mthPrintTitleInfo(e);
//				Font fntNormal = new Font("SimSun",11);
//				if(m_intPages!=1)
//					m_intYPos =m_intYPos+5;
//				e.Graphics.DrawString("（第" +m_intPages+ "页）",new Font("SimSun",11) ,Brushes.Black,(int)enmRectangleInfo.LeftX+350,1040);
//
//				while(m_objPrintContext.m_BlnHaveMoreLine)
//				{
//					m_objPrintContext.m_mthPrintNextLine(ref m_intYPos,e.Graphics,fntNormal);
//					
//					#region 换页处理
//					if(m_intYPos >=(int)enmRectangleInfo.BottomY 
//						&& m_objPrintContext.m_BlnHaveMoreLine)
//					{
//						e.HasMorePages = true;
//						switch(m_intEndIndex)
//						{
//											
//							case 0:
//								m_mthHandle_8End(m_intYPos,e.Graphics,fntNormal);
//								m_intEndIndex--;
//								break;
//							case 1:
//							
//								m_mthHandle_9End(m_intYPos,e.Graphics,fntNormal);
//								m_intEndIndex--;
//								break;
//							case 2:
//							
//								m_mthHandle_10End(m_intYPos,e.Graphics,fntNormal);
//								m_intEndIndex--;
//								break;
//							case 3:
//							
//								m_mthHandle_11End(m_intYPos,e.Graphics,fntNormal);
//								m_intEndIndex--;
//								break;
//							case 4:
//								m_mthHandle_12End(m_intYPos,e.Graphics,fntNormal);
//								m_intEndIndex--;
//								break;
//							case 5:
//							
//								m_mthHandle_13End(m_intYPos,e.Graphics,fntNormal);
//								m_intEndIndex--;
//								break;
//											
//						}
//
//						e.Graphics.DrawLine(m_GridPen,(int)enmRectangleInfo.LeftX,m_intYPos-5 ,(int)enmRectangleInfo.RightX,m_intYPos-5);
//						e.Graphics.DrawLine(m_GridPen,(int)enmRectangleInfo.LeftX,(int)enmRectangleInfo.TopY,(int)enmRectangleInfo.LeftX,m_intYPos-5);
//						e.Graphics.DrawLine(m_GridPen,(int)enmRectangleInfo.RightX,(int)enmRectangleInfo.TopY,(int)enmRectangleInfo.RightX,m_intYPos-5);
//									
//						m_intPages++;
//
//						m_intYPos = (int)enmRectangleInfo.TopY+5;
//						return;
//					}
//				#endregion 
//				
//				}
//				m_intYPos=m_intYPos-5;
//				e.Graphics.DrawLine(m_GridPen,(int)enmRectangleInfo.LeftX,m_intYPos ,(int)enmRectangleInfo.RightX,m_intYPos);
//				e.Graphics.DrawLine(m_GridPen,(int)enmRectangleInfo.LeftX,(int)enmRectangleInfo.TopY,(int)enmRectangleInfo.LeftX,m_intYPos);
//				e.Graphics.DrawLine(m_GridPen,(int)enmRectangleInfo.RightX,(int)enmRectangleInfo.TopY,(int)enmRectangleInfo.RightX,m_intYPos);
//	
//				//全部打完
//				m_objPrintContext.m_mthReset();
//				m_intPages=1;
//				m_intEndIndex=0;
//				m_intYPos = (int)enmRectangleInfo.TopY+5;
//			}
//			catch(Exception ex)
//			{
//				MessageBox.Show(ex.Message );
//			}
//			
//		}
//		
		
		#region 标题文字部分
		/// <summary>
		/// 标题文字部分
		/// </summary>
		/// <param name="e"></param>
		private void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
		{
	      
			float fltOffsetX=0;//X的偏移量
			e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle,m_fotTitleFont ,m_slbBrush,295-fltOffsetX,(int)enmRectangleInfo.TopY-90);
		
			e.Graphics.DrawString("手  术  记  录",m_fotHeaderFont,m_slbBrush,300-fltOffsetX,(int)enmRectangleInfo.TopY-60);
			e.Graphics.DrawString("X光号：",m_fotSmallFont,m_slbBrush,(int)enmRectangleInfo.LeftX-fltOffsetX,(int)enmRectangleInfo.TopY-70);
			if(m_objPrintInfo.m_objSelectOperationRecordContent!=null)
                e.Graphics.DrawString(com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(m_objPrintInfo.m_objSelectOperationRecordContent.m_strXRayNumber, m_objPrintInfo.m_objSelectOperationRecord.m_strXRayNumberXML), m_fotSmallFont, m_slbBrush, (int)enmRectangleInfo.LeftX + 60 - fltOffsetX, (int)enmRectangleInfo.TopY - 70);

			//*************x光号
			e.Graphics.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX-fltOffsetX,(int)enmRectangleInfo.TopY-44,(int)enmRectangleInfo.LeftX+200,(int)enmRectangleInfo.TopY-44);
			e.Graphics.DrawString("病 室："+m_objPrintInfo.m_strAreaName+m_objPrintInfo.m_strBedName,m_fotSmallFont,m_slbBrush,(int)enmRectangleInfo.LeftX-fltOffsetX,(int)enmRectangleInfo.TopY-40);
//			if(m_objPrintInfo.m_strRoomName!=null)
//				e.Graphics.DrawString(m_objPrintInfo.m_strRoomName,m_fotSmallFont,m_slbBrush,(int)enmRectangleInfo.LeftX+60,(int)enmRectangleInfo.TopY-40);
			
			e.Graphics.DrawString("门诊号：",m_fotSmallFont,m_slbBrush,(int)enmRectangleInfo.RightX-200-fltOffsetX,(int)enmRectangleInfo.TopY-70);
//			if(m_objPrintInfo.m_strInPatientID!=null)
//				e.Graphics.DrawString(m_objPrintInfo.m_strInPatientID,m_fotSmallFont,m_slbBrush,(int)enmRectangleInfo.RightX-120,(int)enmRectangleInfo.TopY-70);			
			e.Graphics.DrawLine(Pens.Black,(int)enmRectangleInfo.RightX-200-fltOffsetX,(int)enmRectangleInfo.TopY-44,(int)enmRectangleInfo.RightX,(int)enmRectangleInfo.TopY-44);
			
			e.Graphics.DrawString("住院号：",m_fotSmallFont,m_slbBrush,(int)enmRectangleInfo.RightX-200-fltOffsetX,(int)enmRectangleInfo.TopY-40);
			if(m_objPrintInfo.m_strInPatientID!=null)
				e.Graphics.DrawString(m_objPrintInfo.m_strHISInPatientID,m_fotSmallFont,m_slbBrush,(int)enmRectangleInfo.RightX-120-fltOffsetX,(int)enmRectangleInfo.TopY-40);
			
			e.Graphics.DrawLine(m_GridPen,(int)enmRectangleInfo.LeftX-fltOffsetX,(int)enmRectangleInfo.TopY,(int)enmRectangleInfo.RightX,(int)enmRectangleInfo.TopY);


			

		}
	
		#endregion		

		#region print class 

		private class clsPrintLine1 : clsPrintLineBase
		{
			private com.digitalwave.controls.clsPrintRichTextContext m_objText1;
			private com.digitalwave.controls.clsPrintRichTextContext m_objText2;
			private clsPrintInfo_OperationRecordDoctor objPatient;
		
			private bool m_blnFirstPrint = true;

			public clsPrintLine1()
			{
				m_objText1 = new com.digitalwave.controls.clsPrintRichTextContext(Color.Black,new Font("SimSun",11));
				m_objText2 = new com.digitalwave.controls.clsPrintRichTextContext(Color.Black,new Font("SimSun",11));
			
			}

//			private int m_intTimes = 0;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				p_intPosY += 2;

				if(m_blnFirstPrint)
				{
					Font fntTitle = new Font("SimSun",11);
					Font fntNormal = new Font("SimSun",9);

					p_objGrp.DrawString("姓名",fntTitle ,Brushes.Black,(int)enmRectangleInfo.LeftX+3,p_intPosY);
					if(objPatient!=null)
						p_objGrp.DrawString(objPatient.m_strPatientName,fntNormal ,Brushes.Black,(int)enmRectangleInfo.LeftX+41,p_intPosY);
					p_objGrp.DrawString("性别",fntTitle ,Brushes.Black,(int)enmRectangleInfo.LeftX+110,p_intPosY);
					if(objPatient!=null)
						p_objGrp.DrawString(objPatient.m_strSex,fntNormal ,Brushes.Black,(int)enmRectangleInfo.LeftX+148,p_intPosY);
					p_objGrp.DrawString("年龄",fntTitle ,Brushes.Black,(int)enmRectangleInfo.LeftX+180,p_intPosY);
					if(objPatient!=null)
						p_objGrp.DrawString(objPatient.m_strAge,fntNormal ,Brushes.Black,(int)enmRectangleInfo.LeftX+218,p_intPosY);

					p_objGrp.DrawString("职业",fntTitle ,Brushes.Black,(int)enmRectangleInfo.LeftX+260,p_intPosY);
					if(objPatient!=null)
						p_objGrp.DrawString(objPatient.m_strOccupation,fntNormal ,Brushes.Black,(int)enmRectangleInfo.LeftX+298,p_intPosY);
					p_objGrp.DrawString("工作单位：",fntTitle ,Brushes.Black,(int)enmRectangleInfo.LeftX+400,p_intPosY);
					
					m_blnFirstPrint = false;

					fntTitle.Dispose();
					fntNormal.Dispose();
				}

//				if(objPatient!=null && m_objText1.m_BlnHaveNextLine())
//				{
//					m_intTimes++;
//				}
//
				if(objPatient!=null)
				{
//					m_objText1.m_mthPrintLine(92,(int)enmRectangleInfo.LeftX+298,p_intPosY,p_objGrp);
//					m_objText2.m_mthPrintLine((int)enmRectangleInfo.RightX-((int)enmRectangleInfo.LeftX+478)-10,(int)enmRectangleInfo.LeftX+478,p_intPosY,p_objGrp);

					Rectangle rtgBlock = new Rectangle((int)enmRectangleInfo.LeftX+478,p_intPosY-10,(int)enmRectangleInfo.RightX-((int)enmRectangleInfo.LeftX+478)-10,30);
					int intRealHeight;
					m_objText2.m_blnPrintAllBySimSun(9,rtgBlock,p_objGrp,out intRealHeight,true);
				}

				m_blnHaveMoreLine = false;
				p_intPosY += (int)enmRectangleInfo.RowStep+10;
				p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX,p_intPosY-10,(int)enmRectangleInfo.RightX,p_intPosY-10);

//	
//				if(objPatient!=null && m_objText1.m_BlnHaveNextLine())
//				{
//					m_blnHaveMoreLine = true;
//					p_intPosY +=(int)enmRectangleInfo.SmallRowStep+5 ;
//					
//				}
//				else
//				{
//					m_blnHaveMoreLine = false;
//					p_intPosY += (int)enmRectangleInfo.RowStep+5;
//					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX,p_intPosY-10,(int)enmRectangleInfo.RightX,p_intPosY-10);
//
//				}

			}

			public override void m_mthReset()
			{
//				m_intTimes = 0;
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
				m_objText1.m_mthRestartPrint();
				m_objText2.m_mthRestartPrint();
											
			}

			public override object m_ObjPrintLineInfo
			{
				get
				{
					return m_objPrintLineInfo;
				}
				set
				{					
					objPatient=(clsPrintInfo_OperationRecordDoctor)value;
					if(objPatient!=null)
					{
						m_objText1.m_mthSetContextWithAllCorrect(objPatient.m_strOccupation,"");
						m_objText2.m_mthSetContextWithAllCorrect(objPatient.m_strOfficeAddress,"");
					}
					else 
					{
						m_objText1.m_mthSetContextWithAllCorrect("","");
						m_objText2.m_mthSetContextWithAllCorrect("","");
					}
					
				}
			}
		}
	

		private class clsPrintLine2 : clsPrintLineBase
		{
			private com.digitalwave.controls.clsPrintRichTextContext m_objText1;
			private com.digitalwave.controls.clsPrintRichTextContext m_objText2;
			
		
			private bool m_blnFirstPrint = true;

			public clsPrintLine2()
			{
				m_objText1 = new com.digitalwave.controls.clsPrintRichTextContext(Color.Black,new Font("SimSun",11));
				m_objText2 = new com.digitalwave.controls.clsPrintRichTextContext(Color.Black,new Font("SimSun",11));
			
			}

//			private int m_intTimes = 0;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_blnFirstPrint)
				{
					p_objGrp.DrawString("术前诊断：",new Font("SimSun",11) ,Brushes.Black,(int)enmRectangleInfo.LeftX+3,p_intPosY);

					p_objGrp.DrawString("术后诊断：",new Font("SimSun",11) ,Brushes.Black,(int)enmRectangleInfo.LeftX+400,p_intPosY);

					m_blnFirstPrint = false;
				}

				int intRealHeight;
				Rectangle rtgBlock = new Rectangle((int)enmRectangleInfo.LeftX+78,p_intPosY-10,312,55);
				m_objText1.m_blnPrintAllBySimSun(9,rtgBlock,p_objGrp,out intRealHeight,true);

				rtgBlock = new Rectangle((int)enmRectangleInfo.LeftX+475,p_intPosY-10,(int)enmRectangleInfo.RightX-((int)enmRectangleInfo.LeftX+475)-10,55);
				m_objText2.m_blnPrintAllBySimSun(9,rtgBlock,p_objGrp,out intRealHeight,true);

				p_intPosY += 60;
				
				m_blnHaveMoreLine = false;
				p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX,p_intPosY-10,(int)enmRectangleInfo.RightX,p_intPosY-10);

//				if(m_objText1.m_BlnHaveNextLine()||m_objText2.m_BlnHaveNextLine())
//				{
//					m_intTimes++;
//				}
//
//				m_objText1.m_mthPrintLine(322-10,(int)enmRectangleInfo.LeftX+3+75,p_intPosY,p_objGrp);
//	
//				m_objText2.m_mthPrintLine((int)enmRectangleInfo.RightX-((int)enmRectangleInfo.LeftX+475)-10,(int)enmRectangleInfo.LeftX+3+472,p_intPosY,p_objGrp);
//
//				if(m_objText1.m_BlnHaveNextLine()||m_objText2.m_BlnHaveNextLine())
//				{
//					m_blnHaveMoreLine = true;
//					p_intPosY +=(int)enmRectangleInfo.SmallRowStep+5 ;
//					
//				}
//				else
//				{
//					m_blnHaveMoreLine = false;
//					p_intPosY += (int)enmRectangleInfo.RowStep+5;
//					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX,p_intPosY-10,(int)enmRectangleInfo.RightX,p_intPosY-10);
//
//				}				
			}

			public override void m_mthReset()
			{
//				m_intTimes = 0;
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
				m_objText1.m_mthRestartPrint();
				m_objText2.m_mthRestartPrint();
				
							
			}

			public override object m_ObjPrintLineInfo
			{
				get
				{
					return m_objPrintLineInfo;
				}
				set
				{
					if(value != null)
					{
						Object[] objData=(Object[])value ;
                        if (clsOperationRecordDoctorCSPrintTool.m_blnIsPrintMark)
                        {
                            m_objText1.m_mthSetContextWithCorrectBefore(objData[0].ToString(), objData[1].ToString(), m_dtmFirstPrintTime, true);
                            m_mthAddSign2("术前诊断：", m_objText1.m_ObjModifyUserArr);
                            m_objText2.m_mthSetContextWithCorrectBefore(objData[2].ToString(), objData[3].ToString(), m_dtmFirstPrintTime, true);
                            m_mthAddSign2("术后诊断：", m_objText2.m_ObjModifyUserArr);

                            com.digitalwave.controls.ctlRichTextBox.clsModifyUserInfo[] objUserInfoArr = m_objText1.m_ObjModifyUserArr;
                            if (objUserInfoArr != null)
                            {
                                for (int i = 0; i < objUserInfoArr.Length; i++)
                                {
                                    if (objUserInfoArr[i].m_clrText.ToArgb() == Color.White.ToArgb())
                                    {
                                        objUserInfoArr[i].m_clrText = Color.Black;
                                    }
                                }
                            }

                            objUserInfoArr = m_objText2.m_ObjModifyUserArr;
                            if (objUserInfoArr != null)
                            {
                                for (int i = 0; i < objUserInfoArr.Length; i++)
                                {
                                    if (objUserInfoArr[i].m_clrText.ToArgb() == Color.White.ToArgb())
                                    {
                                        objUserInfoArr[i].m_clrText = Color.Black;
                                    }
                                }
                            }
                        }
                        else
                        {
                            m_objText1.m_mthSetContextWithAllCorrect(objData[0].ToString(), objData[1].ToString());
                            m_objText2.m_mthSetContextWithAllCorrect(objData[2].ToString(), objData[3].ToString());
                        }					
						
					}
				}
			}
		}
	
	
		private class clsPrintLine3 : clsPrintLineBase
		{
			private com.digitalwave.controls.clsPrintRichTextContext m_objText1;
		
			private bool m_blnFirstPrint = true;

			public clsPrintLine3()
			{
				m_objText1 = new com.digitalwave.controls.clsPrintRichTextContext(Color.Black,new Font("SimSun",11));
			
			}

//			private int m_intTimes = 0;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_blnFirstPrint)
				{
					p_objGrp.DrawString("手术名称：",new Font("SimSun",11) ,Brushes.Black,(int)enmRectangleInfo.LeftX+3,p_intPosY-5);
					
					m_blnFirstPrint = false;
				}

				int intRealHeight;
				Rectangle rtgBlock = new Rectangle((int)enmRectangleInfo.LeftX+80,p_intPosY-10,(int)enmRectangleInfo.RightX-((int)enmRectangleInfo.LeftX+80)-10,(int)enmRectangleInfo.RowStep);
				m_objText1.m_blnPrintAllBySimSun(10,rtgBlock,p_objGrp,out intRealHeight,true);
			
				p_intPosY += (int)enmRectangleInfo.RowStep;
				
				m_blnHaveMoreLine = false;
				p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX,p_intPosY-10,(int)enmRectangleInfo.RightX,p_intPosY-10);


//				if(m_objText1.m_BlnHaveNextLine())
//				{
//					m_intTimes++;
//				}
//				m_objText1.m_mthPrintLine((int)enmRectangleInfo.RightX-((int)enmRectangleInfo.LeftX+80)-10,(int)enmRectangleInfo.LeftX+80,p_intPosY,p_objGrp);
//	
//				if(m_objText1.m_BlnHaveNextLine())
//				{
//					m_blnHaveMoreLine = true;
//					p_intPosY +=(int)enmRectangleInfo.SmallRowStep+5 ;
//					
//				}
//				else
//				{
//					m_blnHaveMoreLine = false;
//					p_intPosY += (int)enmRectangleInfo.RowStep+5;
//					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX,p_intPosY-10,(int)enmRectangleInfo.RightX,p_intPosY-10);
//
//				}

			}

			public override void m_mthReset()
			{
//				m_intTimes = 0;
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
				m_objText1.m_mthRestartPrint();
							
			}

			public override object m_ObjPrintLineInfo
			{
				get
				{
					return m_objPrintLineInfo;
				}
				set
				{
					if(value != null)
					{
						Object[] objData=(object[])value ;
                        if (clsOperationRecordDoctorCSPrintTool.m_blnIsPrintMark)
                        {
                            m_objText1.m_mthSetContextWithCorrectBefore(objData[0].ToString(), objData[1].ToString(), m_dtmFirstPrintTime, true);
                            m_mthAddSign2("手术名称：", m_objText1.m_ObjModifyUserArr);
                            com.digitalwave.controls.ctlRichTextBox.clsModifyUserInfo[] objUserInfoArr = m_objText1.m_ObjModifyUserArr;
                            if (objUserInfoArr != null)
                            {
                                for (int i = 0; i < objUserInfoArr.Length; i++)
                                {
                                    if (objUserInfoArr[i].m_clrText.ToArgb() == Color.White.ToArgb())
                                    {
                                        objUserInfoArr[i].m_clrText = Color.Black;
                                    }
                                }
                            }
                        }
                        else
                        {
                            m_objText1.m_mthSetContextWithAllCorrect(objData[0].ToString(), objData[1].ToString());
                        }
						
					}
				}
			}
		}
	

		private class clsPrintLine4 : clsPrintLineBase
		{
			private com.digitalwave.controls.clsPrintRichTextContext m_objText1;
			private com.digitalwave.controls.clsPrintRichTextContext m_objText2;
			private com.digitalwave.controls.clsPrintRichTextContext m_objText3;
		
			private bool m_blnFirstPrint = true;

			public clsPrintLine4()
			{
				m_objText1 = new com.digitalwave.controls.clsPrintRichTextContext(Color.Black,new Font("SimSun",11));
				m_objText2 = new com.digitalwave.controls.clsPrintRichTextContext(Color.Black,new Font("SimSun",11));
				m_objText3 = new com.digitalwave.controls.clsPrintRichTextContext(Color.Black,new Font("SimSun",11));
			
			}

//			private int m_intTimes = 0;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_blnFirstPrint)
				{
					p_objGrp.DrawString("手术医师：",new Font("SimSun",11) ,Brushes.Black,(int)enmRectangleInfo.LeftX+3,p_intPosY-5);
					p_objGrp.DrawString("助手：",new Font("SimSun",11) ,Brushes.Black,(int)enmRectangleInfo.LeftX+230,p_intPosY-5);

					p_objGrp.DrawString("护士：",new Font("SimSun",11) ,Brushes.Black,(int)enmRectangleInfo.LeftX+520,p_intPosY-5);

					m_blnFirstPrint = false;
				}

				int intRealHeight;
				Rectangle rtgBlock = new Rectangle((int)enmRectangleInfo.LeftX+83,p_intPosY-10,150,(int)enmRectangleInfo.RowStep);
				m_objText1.m_blnPrintAllBySimSun(10,rtgBlock,p_objGrp,out intRealHeight,true);
				
				rtgBlock = new Rectangle((int)enmRectangleInfo.LeftX+3+270,p_intPosY-10,267,(int)enmRectangleInfo.RowStep);
				m_objText2.m_blnPrintAllBySimSun(10,rtgBlock,p_objGrp,out intRealHeight,true);
				
				rtgBlock = new Rectangle((int)enmRectangleInfo.LeftX+3+560,p_intPosY-10,(int)enmRectangleInfo.RightX-((int)enmRectangleInfo.LeftX+3+560)-10,(int)enmRectangleInfo.RowStep);
				m_objText3.m_blnPrintAllBySimSun(10,rtgBlock,p_objGrp,out intRealHeight,true);
			
				p_intPosY += (int)enmRectangleInfo.RowStep;
				
				m_blnHaveMoreLine = false;
				p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX,p_intPosY-10,(int)enmRectangleInfo.RightX,p_intPosY-10);


//				if(m_objText1.m_BlnHaveNextLine()||m_objText2.m_BlnHaveNextLine()||m_objText3.m_BlnHaveNextLine())
//				{
//					m_intTimes++;
//				}
//
//				m_objText1.m_mthPrintLine(120-10,(int)enmRectangleInfo.LeftX+3+80,p_intPosY,p_objGrp);
//				m_objText2.m_mthPrintLine(237-10,(int)enmRectangleInfo.LeftX+3+240,p_intPosY,p_objGrp);
//				m_objText3.m_mthPrintLine((int)enmRectangleInfo.RightX-((int)enmRectangleInfo.LeftX+3+520)-10, (int)enmRectangleInfo.LeftX+3+520,p_intPosY,p_objGrp);
//
//	
//				if(m_objText1.m_BlnHaveNextLine()||m_objText2.m_BlnHaveNextLine()||m_objText3.m_BlnHaveNextLine())
//				{
//					m_blnHaveMoreLine = true;
//					p_intPosY +=(int)enmRectangleInfo.SmallRowStep+5 ;
//					
//				}
//				else
//				{
//					m_blnHaveMoreLine = false;
//					p_intPosY += (int)enmRectangleInfo.RowStep+5;
//					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX,p_intPosY-10,(int)enmRectangleInfo.RightX,p_intPosY-10);
//
//				}

			}

			public override void m_mthReset()
			{
//				m_intTimes = 0;
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
				m_objText1.m_mthRestartPrint();
				m_objText2.m_mthRestartPrint();
				m_objText3.m_mthRestartPrint();
							
			}

			public override object m_ObjPrintLineInfo
			{
				get
				{
					return m_objPrintLineInfo;
				}
				set
				{
					if(value != null)
					{
						Object[] objData=(Object[])value ;
						m_objText1.m_mthSetContextWithAllCorrect(objData[0].ToString() ,"");
						m_objText2.m_mthSetContextWithAllCorrect(objData[1].ToString(),"");
						m_objText3.m_mthSetContextWithAllCorrect(objData[2].ToString() ,"");

						
					}
				}
			}
		}
	

		private class clsPrintLine5 : clsPrintLineBase
		{
			private com.digitalwave.controls.clsPrintRichTextContext m_objText1;
			
			private bool m_blnPrintFirst=true;

			
			public clsPrintLine5()
			{
				m_objText1 = new com.digitalwave.controls.clsPrintRichTextContext(Color.Black,new Font("SimSun",11));
				
				
			
			}
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_blnPrintFirst==true)
				{
				
					p_objGrp.DrawString("手术时间：",new Font("SimSun",11) ,Brushes.Black,(int)enmRectangleInfo.LeftX+3,p_intPosY-5);

					m_blnPrintFirst=false;


				}


				int intRealHeight;
				Rectangle rtgBlock = new Rectangle((int)enmRectangleInfo.LeftX+80,p_intPosY-10,(int)enmRectangleInfo.RightX-((int)enmRectangleInfo.LeftX+80),(int)enmRectangleInfo.RowStep);
				m_objText1.m_blnPrintAllBySimSun(10,rtgBlock,p_objGrp,out intRealHeight,true);
			
				p_intPosY += (int)enmRectangleInfo.RowStep;
				
				m_blnHaveMoreLine = false;
				p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX,p_intPosY-10,(int)enmRectangleInfo.RightX,p_intPosY-10);


//				if(m_objText1.m_BlnHaveNextLine())
//				{
//					m_intTimes++;
//				}
//				m_objText1.m_mthPrintLine((int)enmRectangleInfo.RightX-((int)enmRectangleInfo.LeftX+80),(int)enmRectangleInfo.LeftX+80,p_intPosY,p_objGrp);
//  
//				if(m_objText1.m_BlnHaveNextLine())
//				{
//					m_blnHaveMoreLine = true;
//					p_intPosY +=(int)enmRectangleInfo.SmallRowStep+5 ;
//					
//				}
//				else
//				{
//					m_blnHaveMoreLine = false;
//					p_intPosY += (int)enmRectangleInfo.RowStep+5;
//					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX,p_intPosY-10,(int)enmRectangleInfo.RightX,p_intPosY-10);
//
//				}		

			}
	
//			private int m_intTimes=0;
			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
//				m_intTimes=0;
				m_blnPrintFirst=true;
				m_objText1.m_mthRestartPrint();
						
			}

			public override object m_ObjPrintLineInfo
			{
				get
				{
					return m_objPrintLineInfo;
				}
				set
				{
					if(value != null)
					{
						Object objData=(object)value ;
						m_objText1.m_mthSetContextWithAllCorrect(objData.ToString() ,"");

					  
                        					
					}
				}
			}
	
		}
	
		/// <summary>
		/// 是否有麻醉
		/// </summary>
		private static bool s_blnIfAna = true;
	
		private class clsPrintLine6 : clsPrintLineBase
		{
			private com.digitalwave.controls.clsPrintRichTextContext m_objText1;
			private com.digitalwave.controls.clsPrintRichTextContext m_objText2;
			private com.digitalwave.controls.clsPrintRichTextContext m_objText3;
			private bool m_blnPrintFirst=true;

	
			
			public clsPrintLine6()
			{
				m_objText1 = new com.digitalwave.controls.clsPrintRichTextContext(Color.Black,new Font("SimSun",11));
				m_objText2 = new com.digitalwave.controls.clsPrintRichTextContext(Color.Black,new Font("SimSun",11));
				m_objText3 = new com.digitalwave.controls.clsPrintRichTextContext(Color.Black,new Font("SimSun",11));
				
				
			
			}
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_blnPrintFirst==true)
				{
					p_objGrp.DrawString("麻醉前用药：前晚",new Font("SimSun",10) ,Brushes.Black,(int)enmRectangleInfo.LeftX+3,p_intPosY+2);

					p_objGrp.DrawString("术日",new Font("SimSun",10) ,Brushes.Black,(int)enmRectangleInfo.LeftX+280,p_intPosY+2);

					p_objGrp.DrawString("麻醉种类及用量",new Font("SimSun",10) ,Brushes.Black,(int)enmRectangleInfo.LeftX+510,p_intPosY+2);



					m_blnPrintFirst=false;


				}


				int intRealHeight;
				Rectangle rtgBlock = new Rectangle((int)enmRectangleInfo.LeftX+3+120,p_intPosY-13,200,40);
				m_objText1.m_blnPrintAllBySimSun(8,rtgBlock,p_objGrp,out intRealHeight,true);
				
				rtgBlock = new Rectangle((int)enmRectangleInfo.LeftX+3+310,p_intPosY-13,200,40);
				m_objText2.m_blnPrintAllBySimSun(8,rtgBlock,p_objGrp,out intRealHeight,true);
				
				rtgBlock = new Rectangle((int)enmRectangleInfo.LeftX+3+610,p_intPosY-13,(int)enmRectangleInfo.RightX-((int)enmRectangleInfo.LeftX+3+610),40);
				m_objText3.m_blnPrintAllBySimSun(8,rtgBlock,p_objGrp,out intRealHeight,true);
			
				p_intPosY += 40;
				
				m_blnHaveMoreLine = false;
				p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX,p_intPosY-10,(int)enmRectangleInfo.RightX,p_intPosY-10);


//				if(m_objText1.m_BlnHaveNextLine()||m_objText2.m_BlnHaveNextLine()||m_objText3.m_BlnHaveNextLine())
//				{
//					m_intTimes++;
//				}
//				m_objText1.m_mthPrintLine(197-10,(int)enmRectangleInfo.LeftX+3+130,p_intPosY,p_objGrp);
//				m_objText2.m_mthPrintLine(140-10,(int)enmRectangleInfo.LeftX+3+360,p_intPosY,p_objGrp);
//				m_objText3.m_mthPrintLine((int)enmRectangleInfo.RightX-((int)enmRectangleInfo.LeftX+3+620),(int)enmRectangleInfo.LeftX+3+620,p_intPosY,p_objGrp);
//
//  
//				if(m_objText1.m_BlnHaveNextLine()||m_objText2.m_BlnHaveNextLine()||m_objText3.m_BlnHaveNextLine())
//				{
//					m_blnHaveMoreLine = true;
//					p_intPosY +=(int)enmRectangleInfo.SmallRowStep+5 ;
//					
//				}
//				else
//				{
//					m_blnHaveMoreLine = false;
//					p_intPosY += (int)enmRectangleInfo.RowStep+5;
//				
//				}		

			}
	
//			private int m_intTimes=0;
			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
//				m_intTimes=0;
				m_blnPrintFirst=true;
				m_objText1.m_mthRestartPrint();
				m_objText2.m_mthRestartPrint();
				m_objText3.m_mthRestartPrint();
						
			}

			public override object m_ObjPrintLineInfo
			{
				get
				{
					return m_objPrintLineInfo;
				}
				set
				{
					if(value != null)
					{
						Object[] objData=(Object[])value ;
                        s_blnIfAna = !objData[4].ToString().Trim().Equals("无麻醉");
                        if (clsOperationRecordDoctorCSPrintTool.m_blnIsPrintMark)
                        {
                            m_objText1.m_mthSetContextWithCorrectBefore(objData[0].ToString(), objData[1].ToString(), m_dtmFirstPrintTime, true);
                            m_mthAddSign2("前晚：", m_objText1.m_ObjModifyUserArr);
                            m_objText2.m_mthSetContextWithCorrectBefore(objData[2].ToString(), objData[3].ToString(), m_dtmFirstPrintTime, true);
                            m_mthAddSign2("术日：", m_objText2.m_ObjModifyUserArr);
                            m_objText3.m_mthSetContextWithCorrectBefore(objData[4].ToString(), objData[5].ToString(), m_dtmFirstPrintTime, true);
                           
                            m_mthAddSign2("麻醉种类及用量：", m_objText3.m_ObjModifyUserArr);

                            com.digitalwave.controls.ctlRichTextBox.clsModifyUserInfo[] objUserInfoArr = m_objText1.m_ObjModifyUserArr;

                            if (objUserInfoArr != null)
                            {
                                for (int i = 0; i < objUserInfoArr.Length; i++)
                                {
                                    if (objUserInfoArr[i].m_clrText.ToArgb() == Color.White.ToArgb())
                                    {
                                        objUserInfoArr[i].m_clrText = Color.Black;
                                    }
                                }
                            }


                            objUserInfoArr = m_objText2.m_ObjModifyUserArr;
                            if (objUserInfoArr != null)
                            {
                                for (int i = 0; i < objUserInfoArr.Length; i++)
                                {
                                    if (objUserInfoArr[i].m_clrText.ToArgb() == Color.White.ToArgb())
                                    {
                                        objUserInfoArr[i].m_clrText = Color.Black;
                                    }
                                }
                            }

                            objUserInfoArr = m_objText3.m_ObjModifyUserArr;
                            if (objUserInfoArr != null)
                            {
                                for (int i = 0; i < objUserInfoArr.Length; i++)
                                {
                                    if (objUserInfoArr[i].m_clrText.ToArgb() == Color.White.ToArgb())
                                    {
                                        objUserInfoArr[i].m_clrText = Color.Black;
                                    }
                                }
                            }
                        }
                        else
                        {
                            m_objText1.m_mthSetContextWithAllCorrect(objData[0].ToString(), objData[1].ToString());
                            m_objText2.m_mthSetContextWithAllCorrect(objData[2].ToString(), objData[3].ToString());
                            m_objText3.m_mthSetContextWithAllCorrect(objData[4].ToString(), objData[5].ToString());
                        }					
                        					
					}
				}
			}
	
		}
	
		
		private class clsPrintLine7 : clsPrintLineBase
		{
			private com.digitalwave.controls.clsPrintRichTextContext m_objText1;
			private com.digitalwave.controls.clsPrintRichTextContext m_objText2;
			private string m_strAnaTime;
			private bool m_blnFirstPrint = true;

			public clsPrintLine7()
			{
				m_objText1 = new com.digitalwave.controls.clsPrintRichTextContext(Color.Black,new Font("SimSun",11));
				m_objText2 = new com.digitalwave.controls.clsPrintRichTextContext(Color.Black,new Font("SimSun",11));
			
			}

//			private int m_intTimes = 0;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_blnFirstPrint)
				{

					p_objGrp.DrawString("麻醉时间：",new Font("SimSun",11) ,Brushes.Black,(int)enmRectangleInfo.LeftX+3,p_intPosY-5);

					p_objGrp.DrawString("麻醉者：",new Font("SimSun",11) ,Brushes.Black,(int)enmRectangleInfo.LeftX+500,p_intPosY-5);

					m_blnFirstPrint = false;
				}


				int intRealHeight;
				Rectangle rtgBlock = new Rectangle((int)enmRectangleInfo.LeftX+3+80,p_intPosY-10,417-10,(int)enmRectangleInfo.RowStep);
				if(s_blnIfAna)
					m_objText1.m_blnPrintAllBySimSun(10,rtgBlock,p_objGrp,out intRealHeight,true);
				else
					p_objGrp.DrawString("无",new Font("SimSun",11) ,Brushes.Black,(int)enmRectangleInfo.LeftX+83,p_intPosY-5);
				
				rtgBlock = new Rectangle((int)enmRectangleInfo.LeftX+3+560,p_intPosY-10,(int)enmRectangleInfo.RightX-((int)enmRectangleInfo.LeftX+3+560),(int)enmRectangleInfo.RowStep);
				m_objText2.m_blnPrintAllBySimSun(10,rtgBlock,p_objGrp,out intRealHeight,true);
			
				m_blnHaveMoreLine = false;
				p_intPosY += (int)enmRectangleInfo.RowStep;
				
				p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX,p_intPosY-10,(int)enmRectangleInfo.RightX,p_intPosY-10);


//				if(m_objText1.m_BlnHaveNextLine()||m_objText2.m_BlnHaveNextLine())
//				{
//					m_intTimes++;
//				}
//
//				m_objText1.m_mthPrintLine(417-10,(int)enmRectangleInfo.LeftX+3+80,p_intPosY,p_objGrp);
//	
//				m_objText2.m_mthPrintLine((int)enmRectangleInfo.RightX-((int)enmRectangleInfo.LeftX+3+560),(int)enmRectangleInfo.LeftX+3+560,p_intPosY,p_objGrp); 
//
//				if(m_objText1.m_BlnHaveNextLine()||m_objText2.m_BlnHaveNextLine())
//				{
//					m_blnHaveMoreLine = true;
//					p_intPosY +=(int)enmRectangleInfo.SmallRowStep+5 ;					
//				}
//				else
//				{
//
//					m_blnHaveMoreLine = false;
//					p_intPosY += (int)enmRectangleInfo.RowStep+5;
//					p_objGrp.DrawLine(Pens.Black,(int)enmRectangleInfo.LeftX,p_intPosY-10,(int)enmRectangleInfo.RightX,p_intPosY-10);
//
//				
//				}

			}

			public override void m_mthReset()
			{
//				m_intTimes = 0;
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
				m_objText1.m_mthRestartPrint();
				m_objText2.m_mthRestartPrint();
							
			}

			public override object m_ObjPrintLineInfo
			{
				get
				{
					return m_objPrintLineInfo;
				}
				set
				{
					if(value != null)
					{
						Object[] objData=(Object[])value ;
						m_objText1.m_mthSetContextWithAllCorrect(objData[0].ToString() ,"");
						m_objText2.m_mthSetContextWithAllCorrect(objData[1].ToString(),"");
						m_strAnaTime = objData[0].ToString().Trim();
						
					}
				}
			}
		}
	
		
		private class clsPrintLine8 : clsPrintLineBase
		{
			private com.digitalwave.controls.clsPrintRichTextContext m_objText1;
		
			private bool m_blnFirstPrint = true;

			public clsPrintLine8()
			{
				m_objText1 = new com.digitalwave.controls.clsPrintRichTextContext(Color.Black,new Font("SimSun",11));
			
			}

            private int m_intTimes = 0;

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_blnFirstPrint)
				{

					p_objGrp.DrawString("手术经过（包括术中出现的情况及处理）：",new Font("SimSun",14) ,Brushes.Black,(int)enmRectangleInfo.LeftX+3,p_intPosY);
					p_intPosY += (int)enmRectangleInfo.RowStep+5;
					m_blnFirstPrint = false;
				}

                //int intRealHeight;
                //Rectangle rtgBlock = new Rectangle((int)enmRectangleInfo.LeftX+10,p_intPosY,(int)enmRectangleInfo.RightX-((int)enmRectangleInfo.LeftX+10),11*(int)enmRectangleInfo.RowStep);
                //bool blnOutOfBlock = m_objText1.m_blnPrintAllBySimSun(11,rtgBlock,p_objGrp,out intRealHeight,false);

                //if(blnOutOfBlock)
                //{
                //    p_intPosY += intRealHeight+10;
                //}
                //else
                //{
                //    p_intPosY += 11*(int)enmRectangleInfo.RowStep+10;
                //}
                //m_blnHaveMoreLine = false;
                //m_objHandlePartEnd(p_intPosY,p_objGrp,p_fntNormalText);

                if (m_objText1.m_BlnHaveNextLine())
                {
                    m_intTimes++;
                }

                m_objText1.m_mthPrintLine((int)enmRectangleInfo.RightX - ((int)enmRectangleInfo.LeftX + 3), (int)enmRectangleInfo.LeftX + 3, p_intPosY, p_objGrp);

                if (m_objText1.m_BlnHaveNextLine())
                {
                    m_blnHaveMoreLine = true;
                    p_intPosY += (int)enmRectangleInfo.SmallRowStep + 5;
                    if (p_intPosY < 55)
                    {
                        p_intPosY = 55;
                    }
                }
                else
                {
                    m_blnHaveMoreLine = false;
                    p_intPosY += (int)enmRectangleInfo.RowStep + 5;
                    if (m_intTimes < 11 && m_intTimes != 0)
                    {
                        p_intPosY += (11 - m_intTimes) * (int)enmRectangleInfo.RowStep;

                    }

                    else if (m_intTimes == 0)
                    {
                        p_intPosY += 11 * (int)enmRectangleInfo.RowStep;
                    }
                    if (p_intPosY >= (int)enmRectangleInfo.BottomY)
                    {
                        p_intPosY = (int)enmRectangleInfo.BottomY;
                    }
                    else
                    {
                        m_objHandlePartEnd(p_intPosY, p_objGrp, p_fntNormalText);

                    }
                }

			}

			public override void m_mthReset()
			{
                m_intTimes = 0;
				m_blnHaveMoreLine = true;
				m_blnFirstPrint = true;
				m_objText1.m_mthRestartPrint();
							
			}

			public override object m_ObjPrintLineInfo
			{
				get
				{
					return m_objPrintLineInfo;
				}
				set
				{
					if(value != null)
					{
						Object[] objData=(Object[])value ;
                        if (clsOperationRecordDoctorCSPrintTool.m_blnIsPrintMark)
                        {
                            m_objText1.m_mthSetContextWithCorrectBefore(objData[0].ToString(), objData[1].ToString(), m_dtmFirstPrintTime, true);
                            m_mthAddSign2("手术经过：", m_objText1.m_ObjModifyUserArr);

                            com.digitalwave.controls.ctlRichTextBox.clsModifyUserInfo[] objUserInfoArr = m_objText1.m_ObjModifyUserArr;

                            if (objUserInfoArr != null)
                            {
                                for (int i = 0; i < objUserInfoArr.Length; i++)
                                {
                                    if (objUserInfoArr[i].m_clrText.ToArgb() == Color.White.ToArgb())
                                    {
                                        objUserInfoArr[i].m_clrText = Color.Black;
                                    }
                                }
                            }
                        }
                        else
                        {
                            m_objText1.m_mthSetContextWithAllCorrect(objData[0].ToString(), objData[1].ToString());
                        }
					}
				}
			}
        }

        #region
        //        private class clsPrintLine9 : clsPrintLineBase
//        {
//            private com.digitalwave.controls.clsPrintRichTextContext m_objText1;
//            private bool m_blnPrintFirst=true;			
//            private clsPictureBoxValue[] m_objPics;
			
//            public clsPrintLine9()
//            {
//                m_objText1 = new com.digitalwave.controls.clsPrintRichTextContext(Color.Black,new Font("SimSun",11));				
//            }
//            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
//            {
//                if(m_blnPrintFirst==true)
//                {
//                    p_objGrp.DrawString("病理所见：",new Font("SimSun",14) ,Brushes.Black,(int)enmRectangleInfo.LeftX+3,p_intPosY);

//                    p_intPosY += (int)enmRectangleInfo.RowStep+5;
//                    m_blnPrintFirst =false;
//                }
				
//                int intRealHeight;
//                Rectangle rtgBlock = new Rectangle((int)enmRectangleInfo.LeftX+10,p_intPosY,(int)enmRectangleInfo.RightX-((int)enmRectangleInfo.LeftX+10),910-p_intPosY);
//                m_objText1.m_blnPrintAllBySimSun(11,rtgBlock,p_objGrp,out intRealHeight,false);						

//                #region 打印图片信息
//                if(m_objPics != null && m_objPics.Length > 0)
//                {
//                    int intTextHeight = m_objText1.m_intMeasureBlockHeightBySimSun(11,rtgBlock.Width,p_objGrp);
//                    p_intPosY += intTextHeight;
					
//                    int intLeft = (int)enmRectangleInfo.LeftX+10;
//                    for(int i = 0; i < m_objPics.Length; i++)
//                    {
//                        System.IO.MemoryStream objStream = new System.IO.MemoryStream(m_objPics[i].m_bytImage);
//                        Image img = new Bitmap(objStream);
//                        p_objGrp.DrawImage(img,intLeft,p_intPosY);
//                        intLeft += m_objPics[i].intWidth+10;
//                    }
//                }
//                #endregion

//                m_blnHaveMoreLine = false;

//                p_intPosY = 922;

//                int intX1=(int)enmRectangleInfo.LeftX;
//                int intX2=(int)enmRectangleInfo.RightX ;
//                p_objGrp.DrawLine(Pens.Black,intX1,p_intPosY,intX2,p_intPosY);

//                p_intPosY += 10;

////				if(m_objText1.m_BlnHaveNextLine())
////				{
////					m_intTimes++;
////				}
////
////				m_objText1.m_mthPrintLine((int)enmRectangleInfo.RightX-((int)enmRectangleInfo.LeftX+3),(int)enmRectangleInfo.LeftX+3,p_intPosY,p_objGrp);
////
////				if(m_objText1.m_BlnHaveNextLine())
////				{
////					m_blnHaveMoreLine = true;
////					p_intPosY +=(int)enmRectangleInfo.SmallRowStep+5 ;
////
////					//若病理所见超出本页的最后两行，则剩余部分截取不打（因为套打）
////					if(p_intPosY>=(int)enmRectangleInfo.BottomY-2*(int)enmRectangleInfo.RowStep)
////					{
////						p_intPosY=(int)enmRectangleInfo.BottomY-2*(int)enmRectangleInfo.RowStep;
////						m_blnHaveMoreLine = false;
////						m_objHandlePartEnd(p_intPosY,p_objGrp,p_fntNormalText);
////					}
////					
////				}
////				else
////				{
////					m_blnHaveMoreLine = false;
////					p_intPosY += (int)enmRectangleInfo.RowStep+5;
////					if(m_intTimes < 8 && m_intTimes!=0)
////					{
////						p_intPosY += (8-m_intTimes)*(int)enmRectangleInfo.RowStep;
////
////					}
////					
////					else if(m_intTimes == 0)
////					{
////						p_intPosY +=8*(int)enmRectangleInfo.RowStep;
////					}
////					if(p_intPosY>=(int)enmRectangleInfo.BottomY)
////					{
////						p_intPosY=(int)enmRectangleInfo.BottomY;
////					}
////					else 
////					{
////						m_objHandlePartEnd(p_intPosY,p_objGrp,p_fntNormalText);
////
////					}
////					
////				}
				
//            }
////			private int m_intTimes=0;
//            public override void m_mthReset()
//            {
//                m_blnHaveMoreLine = true;
////				m_intTimes =0;
//                m_blnPrintFirst=true;
//                m_objText1.m_mthRestartPrint();
		
			
//            }

//            public override object m_ObjPrintLineInfo
//            {
//                get
//                {
//                    return m_objPrintLineInfo;
//                }
//                set
//                {
//                    if(value != null)
//                    {
//                        Object[] objData=(Object[])value ;
//                        m_objText1.m_mthSetContextWithCorrectBefore(objData[0].ToString() ,objData[1].ToString(),m_dtmFirstPrintTime,true);
//                        m_mthAddSign2("病理所见：",m_objText1.m_ObjModifyUserArr);

//                        com.digitalwave.controls.ctlRichTextBox.clsModifyUserInfo [] objUserInfoArr = m_objText1.m_ObjModifyUserArr;

//                        if(objUserInfoArr != null)
//                        {
//                            for(int i=0;i<objUserInfoArr.Length;i++)
//                            {
//                                if(objUserInfoArr[i].m_clrText.ToArgb() == Color.White.ToArgb())
//                                {
//                                    objUserInfoArr[i].m_clrText = Color.Black;
//                                }
//                            }
//                        }
//                        m_objPics = (clsPictureBoxValue[])objData[2];
//                    }
//                }
//            }
//        }
	

//        private class clsPrintLine10 : clsPrintLineBase
//        {
//            private com.digitalwave.controls.clsPrintRichTextContext m_objText1;
//            private bool m_blnPrintFirst=true;
////			private int m_intTimes = 0;		
//            public clsPrintLine10()
//            {
//                m_objText1 = new com.digitalwave.controls.clsPrintRichTextContext(Color.Black,new Font("SimSun",11));				
		
//            }

//            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
//            {
				
//                if(m_blnPrintFirst==true)
//                {
//                    p_objGrp.DrawString("手术期间输液（输血）",new Font("SimSun",11) ,Brushes.Black,(int)enmRectangleInfo.LeftX+3,p_intPosY);
//                    m_blnPrintFirst =false;
//                }

//                int intRealHeight;
//                Rectangle rtgBlock = new Rectangle((int)enmRectangleInfo.LeftX+163,p_intPosY,(int)enmRectangleInfo.RightX-((int)enmRectangleInfo.LeftX+163),(int)enmRectangleInfo.RowStep+32);
//                m_objText1.m_blnPrintAllBySimSun(10,rtgBlock,p_objGrp,out intRealHeight,false);
			
//                p_intPosY += (int)enmRectangleInfo.RowStep+32;
				
//                m_blnHaveMoreLine = false;
//                m_objHandlePartEnd(p_intPosY,p_objGrp,p_fntNormalText);

////				if(m_objText1.m_BlnHaveNextLine())
////				{
////					m_intTimes++;
////				}
////				m_objText1.m_mthPrintLine((int)enmRectangleInfo.RightX-((int)enmRectangleInfo.LeftX+3+160),(int)enmRectangleInfo.LeftX+3+160,p_intPosY,p_objGrp);
////
////				if(m_objText1.m_BlnHaveNextLine())
////				{
////					m_blnHaveMoreLine = true;
////					p_intPosY +=(int)enmRectangleInfo.SmallRowStep+5 ;
////					
////				}
////				else
////				{
////					m_blnHaveMoreLine = false;
////					p_intPosY += (int)enmRectangleInfo.RowStep+5;
////					m_objHandlePartEnd(p_intPosY,p_objGrp,p_fntNormalText);
////					
////				}

//            }

//            public override void m_mthReset()
//            {
//                m_blnHaveMoreLine = true;
////				m_intTimes =0;
//                m_blnPrintFirst=true;
//                m_objText1.m_mthRestartPrint();
				
//            }

//            public override object m_ObjPrintLineInfo
//            {
//                get
//                {
//                    return m_objPrintLineInfo;
//                }
//                set
//                {
//                    Object[] objData=(Object[])value ;
//                    m_objText1.m_mthSetContextWithCorrectBefore(objData[0].ToString() ,objData[1].ToString(),m_dtmFirstPrintTime,true);
//                    m_mthAddSign2("手术期间输液（输血）：",m_objText1.m_ObjModifyUserArr);

//                    com.digitalwave.controls.ctlRichTextBox.clsModifyUserInfo [] objUserInfoArr = m_objText1.m_ObjModifyUserArr;
//                    if(objUserInfoArr != null)
//                    {
//                        for(int i=0;i<objUserInfoArr.Length;i++)
//                        {
//                            if(objUserInfoArr[i].m_clrText.ToArgb() == Color.White.ToArgb())
//                            {
//                                objUserInfoArr[i].m_clrText = Color.Black;
//                            }
//                        }
//                    }
//                }
//            }
//        }
	

//        private class clsPrintLine11 : clsPrintLineBase
//        {
//            private com.digitalwave.controls.clsPrintRichTextContext m_objText1;
//            private com.digitalwave.controls.clsPrintRichTextContext m_objText2;
		
//            private bool m_blnFirstPrint = true;
			

//            public clsPrintLine11()
//            {
//                m_objText1 = new com.digitalwave.controls.clsPrintRichTextContext(Color.Black,new Font("SimSun",11));
//                m_objText2 = new com.digitalwave.controls.clsPrintRichTextContext(Color.Black,new Font("SimSun",11));
				
			
//            }

////			private int m_intTimes = 0;

//            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
//            {
//                if(m_blnFirstPrint)
//                {
//                    p_objGrp.DrawString("引流或填塞物",new Font("SimSun",11) ,Brushes.Black,(int)enmRectangleInfo.LeftX+3,p_intPosY);

//                    p_objGrp.DrawString("医师签名",new Font("SimSun",11) ,Brushes.Black,(int)enmRectangleInfo.LeftX+480,p_intPosY);


					
//                    m_blnFirstPrint = false;
//                }

//                int intRealHeight;
//                Rectangle rtgBlock = new Rectangle((int)enmRectangleInfo.LeftX+103,p_intPosY,367,(int)enmRectangleInfo.RowStep+32);
//                m_objText1.m_blnPrintAllBySimSun(10,rtgBlock,p_objGrp,out intRealHeight,false);
				
//                rtgBlock = new Rectangle((int)enmRectangleInfo.LeftX+560,p_intPosY,(int)enmRectangleInfo.RightX-((int)enmRectangleInfo.LeftX+560),(int)enmRectangleInfo.RowStep+32);
//                m_objText2.m_blnPrintAllBySimSun(10,rtgBlock,p_objGrp,out intRealHeight,false);
			
//                p_intPosY += (int)enmRectangleInfo.RowStep+32;
				
//                m_blnHaveMoreLine = false;
//                m_objHandlePartEnd(p_intPosY,p_objGrp,p_fntNormalText);

////				if(m_objText1.m_BlnHaveNextLine()||m_objText2.m_BlnHaveNextLine())
////				{
////					m_intTimes++;
////				}
////
////				m_objText1.m_mthPrintLine(457-10,(int)enmRectangleInfo.LeftX+3+100,p_intPosY,p_objGrp);
////				m_objText2.m_mthPrintLine((int)enmRectangleInfo.RightX-((int)enmRectangleInfo.LeftX+3+640),(int)enmRectangleInfo.LeftX+3+640,p_intPosY,p_objGrp);
////	
////				if(m_objText1.m_BlnHaveNextLine()||m_objText2.m_BlnHaveNextLine())
////				{
////					m_blnHaveMoreLine = true;
////					p_intPosY +=(int)enmRectangleInfo.SmallRowStep+5 ;
////					
////				}
////				else
////				{
////					m_blnHaveMoreLine = false;
////					p_intPosY += (int)enmRectangleInfo.RowStep+5;
////					m_objHandlePartEnd(p_intPosY,p_objGrp,p_fntNormalText);
////				}

//            }

//            public override void m_mthReset()
//            {
////				m_intTimes = 0;
//                m_blnHaveMoreLine = true;
//                m_blnFirstPrint = true;
//                m_objText1.m_mthRestartPrint();
//                m_objText2.m_mthRestartPrint();
							
//            }

//            public override object m_ObjPrintLineInfo
//            {
//                get
//                {
//                    return m_objPrintLineInfo;
//                }
//                set
//                {
//                    if(value != null)
//                    {
//                        Object[] objData=(Object[])value ;
//                        m_objText1.m_mthSetContextWithCorrectBefore(objData[0].ToString() ,objData[1].ToString(),m_dtmFirstPrintTime,true);
//                        m_mthAddSign2("引流或填塞物：",m_objText1.m_ObjModifyUserArr);
//                        m_objText2.m_mthSetContextWithAllCorrect(objData[2].ToString() ,"<root />");
						
//                        com.digitalwave.controls.ctlRichTextBox.clsModifyUserInfo [] objUserInfoArr = m_objText1.m_ObjModifyUserArr;

//                        if(objUserInfoArr != null)
//                        {
//                            for(int i=0;i<objUserInfoArr.Length;i++)
//                            {
//                                if(objUserInfoArr[i].m_clrText.ToArgb() == Color.White.ToArgb())
//                                {
//                                    objUserInfoArr[i].m_clrText = Color.Black;
//                                }
//                            }
//                        }

//                    }
//                }
//            }
//        }
	

//        private class clsPrintLine12 : clsPrintLineBase
//        {
				
//            private com.digitalwave.controls.clsPrintRichTextContext m_objText1;
//            private bool m_blnFirstPrint = true;
			

			
//            public clsPrintLine12()
//            {
				
//                m_objText1=new com.digitalwave.controls.clsPrintRichTextContext (Color.Black,new Font("SimSun",11));
					
//            }

//            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
//            {
				
//                if(m_blnFirstPrint==true)
//                {
	
//                    p_objGrp.DrawString("标本肉眼所见或特殊记录：",new Font("SimSun",14) ,Brushes.Black,(int)enmRectangleInfo.LeftX+3,p_intPosY);
//                    p_intPosY += (int)enmRectangleInfo.RowStep;
//                    m_blnFirstPrint =false;
//                }

//                int intRealHeight;
//                Rectangle rtgBlock = new Rectangle((int)enmRectangleInfo.LeftX+10,p_intPosY,(int)enmRectangleInfo.RightX-((int)enmRectangleInfo.LeftX+3),14*(int)enmRectangleInfo.RowStep);
//                bool blnOutOfBlock = m_objText1.m_blnPrintAllBySimSun(11,rtgBlock,p_objGrp,out intRealHeight,false);

//                if(blnOutOfBlock)
//                {
//                    p_intPosY += intRealHeight;
//                }
//                else
//                {
//                    p_intPosY += 16*(int)enmRectangleInfo.RowStep;
//                }
//                m_blnHaveMoreLine = false;
//                m_objHandlePartEnd(p_intPosY,p_objGrp,p_fntNormalText);

////				if(m_objText1.m_BlnHaveNextLine())
////				{
////					m_intTimes++;
////				}
////
////				m_objText1.m_mthPrintLine((int)enmRectangleInfo.RightX-((int)enmRectangleInfo.LeftX+3),(int)enmRectangleInfo.LeftX+3,p_intPosY,p_objGrp);
////			
////				if(m_objText1.m_BlnHaveNextLine())
////				{
////					m_blnHaveMoreLine = true;
////					p_intPosY +=(int)enmRectangleInfo.SmallRowStep+5 ;
////					
////				}
////				else
////				{
////					m_blnHaveMoreLine = false;
////					p_intPosY += (int)enmRectangleInfo.RowStep+5;
////					if(m_intTimes < 14 && m_intTimes!=0)
////					{
////						p_intPosY += (14-m_intTimes)*(int)enmRectangleInfo.RowStep;
////
////					}
////					
////					else if(m_intTimes == 0)
////					{
////						p_intPosY +=14*(int)enmRectangleInfo.RowStep;
////					}
////					if(p_intPosY>=(int)enmRectangleInfo.BottomY)
////					{
////						p_intPosY=(int)enmRectangleInfo.BottomY;
////					}
////					else 
////					{
////						m_objHandlePartEnd(p_intPosY,p_objGrp,p_fntNormalText);
////
////					}
////      
////				}

//            }
////			private int m_intTimes=0;
//            public override void m_mthReset()
//            {
//                m_blnHaveMoreLine = true;
////				m_intTimes=0;
//                m_blnFirstPrint = true;
//                m_objText1.m_mthRestartPrint();
//            }

//            public override object m_ObjPrintLineInfo
//            {
//                get
//                {
//                    return m_objPrintLineInfo;
//                }
//                set
//                {
//                    Object[] objData=(Object[])value ;
//                    m_objText1.m_mthSetContextWithCorrectBefore(objData[0].ToString() ,objData[1].ToString(),m_dtmFirstPrintTime,true);
//                    m_mthAddSign2("标本肉眼所见或特殊记录：",m_objText1.m_ObjModifyUserArr);

//                    com.digitalwave.controls.ctlRichTextBox.clsModifyUserInfo [] objUserInfoArr = m_objText1.m_ObjModifyUserArr;

//                    if(objUserInfoArr != null)
//                    {
//                        for(int i=0;i<objUserInfoArr.Length;i++)
//                        {
//                            if(objUserInfoArr[i].m_clrText.ToArgb() == Color.White.ToArgb())
//                            {
//                                objUserInfoArr[i].m_clrText = Color.Black;
//                            }
//                        }			
//                    }
//                }
//            }
//        }


        //private class clsPrintLine13 : clsPrintLineBase
        //{

        //    private com.digitalwave.controls.clsPrintRichTextContext m_objText1;

        //    private bool m_blnFirstPrint = true;


        //    public clsPrintLine13()
        //    {

        //        m_objText1 = new com.digitalwave.controls.clsPrintRichTextContext(Color.Black, new Font("SimSun", 11));

        //    }

        //    public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
        //    {
        //        if (m_blnFirstPrint == true)
        //        {

        //            p_objGrp.DrawString("术后总结与讲评意见：", new Font("SimSun", 14), Brushes.Black, (int)enmRectangleInfo.LeftX + 3, p_intPosY);

        //            p_intPosY += (int)enmRectangleInfo.RowStep;
        //            m_blnFirstPrint = false;
        //        }

        //        int intRealHeight;
        //        Rectangle rtgBlock = new Rectangle((int)enmRectangleInfo.LeftX + 10, p_intPosY, (int)enmRectangleInfo.RightX - ((int)enmRectangleInfo.LeftX + 10), 14 * (int)enmRectangleInfo.RowStep);
        //        m_objText1.m_blnPrintAllBySimSun(11, rtgBlock, p_objGrp, out intRealHeight, false);

        //        p_intPosY = 910;

        //        m_blnHaveMoreLine = false;
        //        m_objHandlePartEnd(p_intPosY, p_objGrp, p_fntNormalText);


        //        if (m_objText1.m_BlnHaveNextLine())
        //        {
        //            m_intTimes++;
        //        }

        //        m_objText1.m_mthPrintLine((int)enmRectangleInfo.RightX - ((int)enmRectangleInfo.LeftX + 3), (int)enmRectangleInfo.LeftX + 3, p_intPosY, p_objGrp);

        //        if (m_objText1.m_BlnHaveNextLine())
        //        {
        //            m_blnHaveMoreLine = true;
        //            p_intPosY += (int)enmRectangleInfo.SmallRowStep + 5;

        //            //若病理所见超出本页的最后两行，则剩余部分截取不打（因为套打）
        //            if (p_intPosY >= (int)enmRectangleInfo.BottomY - 4 * (int)enmRectangleInfo.RowStep)
        //            {
        //                p_intPosY = (int)enmRectangleInfo.BottomY;
        //                m_blnHaveMoreLine = false;
        //                m_objHandlePartEnd(p_intPosY, p_objGrp, p_fntNormalText);
        //            }

        //        }
        //        else
        //        {
        //            m_blnHaveMoreLine = false;
        //            p_intPosY += (int)enmRectangleInfo.RowStep + 5;
        //            if (m_intTimes < 14 && m_intTimes != 0)
        //            {
        //                p_intPosY += (14 - m_intTimes) * (int)enmRectangleInfo.RowStep;

        //            }

        //            else if (m_intTimes == 0)
        //            {
        //                p_intPosY += 14 * (int)enmRectangleInfo.RowStep;
        //            }
        //            if (p_intPosY >= (int)enmRectangleInfo.BottomY)
        //            {
        //                p_intPosY = (int)enmRectangleInfo.BottomY;
        //            }
        //            else
        //            {
        //                m_objHandlePartEnd(p_intPosY, p_objGrp, p_fntNormalText);

        //            }

        //        }

        //    }
        //    private int m_intTimes = 0;
        //    public override void m_mthReset()
        //    {
        //        m_blnHaveMoreLine = true;
        //        m_intTimes = 0;
        //        m_blnFirstPrint = true;
        //        m_objText1.m_mthRestartPrint();

        //    }

        //    public override object m_ObjPrintLineInfo
        //    {
        //        get
        //        {
        //            return m_objPrintLineInfo;
        //        }
        //        set
        //        {
        //            Object[] objData = (Object[])value;
        //            m_objText1.m_mthSetContextWithCorrectBefore(objData[0].ToString(), objData[1].ToString(), m_dtmFirstPrintTime, true);
        //            m_mthAddSign2("术后总结与讲评意见：", m_objText1.m_ObjModifyUserArr);

        //            com.digitalwave.controls.ctlRichTextBox.clsModifyUserInfo[] objUserInfoArr = m_objText1.m_ObjModifyUserArr;

        //            if (objUserInfoArr != null)
        //            {
        //                for (int i = 0; i < objUserInfoArr.Length; i++)
        //                {
        //                    if (objUserInfoArr[i].m_clrText.ToArgb() == Color.White.ToArgb())
        //                    {
        //                        objUserInfoArr[i].m_clrText = Color.Black;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}
        #endregion

        private class clsPrintLine14 : clsPrintLineBase
		{
			private com.digitalwave.controls.clsPrintRichTextContext m_objText1;
			
			private bool m_blnPrintFirst=true;
			public clsPrintLine14()
			{
				m_objText1 = new com.digitalwave.controls.clsPrintRichTextContext(Color.Black,new Font("SimSun",9));
				
			}
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_blnPrintFirst==true)
				{
					p_objGrp.DrawString("医师",new Font("SimSun",11) ,Brushes.Black,(int)enmRectangleInfo.LeftX+520,p_intPosY);

					m_blnPrintFirst=false;


			}
				if(m_objText1.m_BlnHaveNextLine())
				{
					m_intTimes++;
				}
				m_objText1.m_mthPrintLine((int)enmRectangleInfo.RightX-((int)enmRectangleInfo.LeftX+580),(int)enmRectangleInfo.LeftX+580,p_intPosY,p_objGrp);
  
				if(m_objText1.m_BlnHaveNextLine())
				{
					m_blnHaveMoreLine = true;
					p_intPosY +=(int)enmRectangleInfo.SmallRowStep+5 ;
					
				}
				else
				{
					m_blnHaveMoreLine = false;
					p_intPosY += (int)enmRectangleInfo.RowStep+5;
		
				}
		

			}
	
			private int m_intTimes=0;
			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_intTimes=0;
				m_blnPrintFirst=true;
				m_objText1.m_mthRestartPrint();
						
			}

			public override object m_ObjPrintLineInfo
			{
				get
				{
					return m_objPrintLineInfo;
				}
				set
				{
					if(value != null)
					{
						Object objData=(object)value ;
						m_objText1.m_mthSetContextWithAllCorrect(objData.ToString() ,"");
                        					
					}
				}
			}
	
		}
	

		private class clsPrintLine15 : clsPrintLineBase
		{
			
			private string strDate;

			public clsPrintLine15()
			{
					
			}
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				
				p_objGrp.DrawString(strDate,new Font("SimSun",11) ,Brushes.Black,(int)enmRectangleInfo.LeftX+590,p_intPosY);
	
				m_blnHaveMoreLine = false;
				p_intPosY += (int)enmRectangleInfo.RowStep+5;
	
			}
			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
			
			}

			public override object m_ObjPrintLineInfo
			{
				get
				{
					return m_objPrintLineInfo;
				}
				set
				{
					if(value != null)
					{
						Object objData=(object)value ;
						strDate=objData.ToString();
                        					
					}
				}
			}
	
		}
	

		#endregion 


		#endregion 



//		[Serializable]
//		private class clsPrintInfo_OperationRecordDoctor
//		{
//			public string m_strInPatientID;
//			public string m_strPatientName;
//			public string m_strSex;
//			public string m_strAge;
//			public string m_strBedName;
//			public string m_strRoomName;
//			public string m_strDeptName;
//			public string m_strAreaName;	
//			public string m_strOccupation;
//			public string m_strOfficeAddress;
//			public DateTime m_dtmInPatientDate;
//			public DateTime m_dtmOpenDate;
//			public clsOperationRecordDoctor m_objSelectOperationRecord;//保存选择的纪录的XML  
//			public clsOperationRecordContentDoctor m_objSelectOperationRecordContent; //保存选择的纪录的内容
//			public clsOperationDoctorNurse[] m_objNurseArr;
//			public int m_intNurseCount;
//			public string[] m_strOperationIDArr;
//			public string[] m_strOperationNameArr;
//
//		}
//	
	}
}
