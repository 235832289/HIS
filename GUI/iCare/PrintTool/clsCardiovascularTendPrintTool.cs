using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.Utility.Controls;
using System.Drawing;
using com.digitalwave.clsCardiovascularTend_GXService;
using com.digitalwave.clsRecordsService;

namespace iCare
{
	/// <summary>
	/// 心血管外科特护记录打印工具的摘要说明。
	/// </summary>
	public class clsCardiovascularTendPrintTool: infPrintRecord
	{   
		private bool m_blnIsFromDataSource=true;//表明是从数据库读取还是从文件直接提取信息
		private bool m_blnWantInit=true;
        private clsRecordsDomain m_objRecordsDomain;
		private clsPrintInfo_CardiovascularTend m_objPrintInfo;
		private clsCardiovascularTend_GXDataInfo[] m_objPrintDataArr;
        //private clsCardiovascularTend_GXService m_objServ;
        private int m_intFlag = -1;
        private int m_intRecordCount = 0;
        private long lngResult;
        private int[] m_intFrontPosArr = new int[46];
        private int[] m_intBackPosArr = new int[30];
     
		/// <summary>
		/// 设置打印信息(当从数据库读取时要首先调用.)
		/// </summary>
		/// <param name="p_objPatient">病人</param>
		/// <param name="p_dtmInPatientDate">入院日期</param>
		/// <param name="p_dtmOpenDate">OpenDate，如果是一次打印多次记录表单的类型（如病案记录），忽略OpenDate</param>
		public void m_mthSetPrintInfo(clsPatient p_objPatient,DateTime p_dtmInPatientDate,DateTime p_dtmOpenDate)
		{
            if (p_objPatient != null)
            {
                m_blnIsFromDataSource = true;//表明是从数据库读取
                clsPatient m_objPatient = p_objPatient;
                m_objPrintInfo = new clsPrintInfo_CardiovascularTend();
                m_objPrintInfo.m_strInPatientID = m_objPatient != null ? m_objPatient.m_StrInPatientID : "";
                m_objPrintInfo.m_strPatientName = m_objPatient != null ? m_objPatient.m_StrName : "";
                m_objPrintInfo.m_strAge = m_objPatient != null ? m_objPatient.m_ObjPeopleInfo.m_StrAge : "";
                m_objPrintInfo.m_dtmInPatientDate = p_dtmInPatientDate;
                m_objPrintInfo.m_dtmOpenDate = p_dtmOpenDate;
                //m_objServ = new clsCardiovascularTend_GXService();
                clsCardiovascularTend_GXService m_objServ =
                    (clsCardiovascularTend_GXService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsCardiovascularTend_GXService));

                lngResult= m_objServ.m_lngGetBaseInfo(m_objPrintInfo.m_strInPatientID, m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), out m_objPrintInfo.m_objPrintBaseDataArr);
                if (lngResult > 0)
                 {
                     if (m_objPrintInfo.m_objPrintBaseDataArr != null)
                         for (int i0 = 0; i0 < m_objPrintInfo.m_objPrintBaseDataArr.Length; i0++)
                         {
                             if (m_objPrintInfo.m_objPrintBaseDataArr[i0].m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss") == m_objPrintInfo.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"))
                             {
                                 m_intFlag = i0;
                                 break;
                             }
                         }
                 }
                 else
                     return;
                if (m_intFlag == -1)
                    return;
                m_objServ.Dispose();
            }
            else
            {
                clsPublicFunction.ShowInformationMessageBox("打印病人不能为空,请选择一个病人!");
                return;
            }
		
		}
		/// <summary>
		/// 从数据库初始化打印内容。如果没有记录，打印空报表。(当从数据库读取时要调用.)
		/// </summary>
		public void m_mthInitPrintContent()
		{			
			if(m_objPrintInfo==null)
			{
				clsPublicFunction.ShowInformationMessageBox("调用m_mthInitPrintContent之前请首先调用m_mthSetPrintInfo函数");
				return;
			}
            if (m_objPrintInfo.m_strInPatientID == "" || m_intFlag == -1)
            {
                m_blnWantInit = false;
                clsPublicFunction.ShowInformationMessageBox("请先填写手术的基本资料并保存!");
                return;
            }
            try
            {
                m_objRecordsDomain = new clsRecordsDomain(enmRecordsType.CardiovascularTend_GX);
                long lngRes = m_objRecordsDomain.m_lngGetPrintInfo(m_objPrintInfo.m_strInPatientID, m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), out m_objPrintInfo.m_objTransDataArr, out m_objPrintInfo.m_dtmFirstPrintDateArr, out m_objPrintInfo.m_blnIsFirstPrintArr);

                if (lngRes <= 0)
                    return;


                //按记录时间(CreateDate)排序 
                m_mthSortTransData(ref m_objPrintInfo.m_objTransDataArr);

                //设置表单内容到打印中
                m_mthSetPrintContent(m_objPrintInfo.m_objTransDataArr, m_objPrintInfo.m_dtmFirstPrintDateArr);
                m_objPrintInfo.m_objPrintDataArr = m_objPrintDataArr;

                m_blnWantInit = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

		}
		/// <summary>
		/// 按记录顺序(CreateDate)把输入的p_objTansDataInfoArr排序
		/// </summary>
		/// <param name="p_objTansDataInfoArr"></param>
		private void m_mthSortTransData(ref clsTransDataInfo[] p_objTansDataInfoArr)
		{
			ArrayList m_arlSort = new ArrayList(p_objTansDataInfoArr);
			m_arlSort.Sort();
            p_objTansDataInfoArr = (clsTransDataInfo[])m_arlSort.ToArray(typeof(clsTransDataInfo));
		}	
		/// <summary>
		/// 设置打印内容。(当数据已经存在时使用。)
		/// </summary>
		/// <param name="p_objPrintContent">打印内容</param>
		public void m_mthSetPrintContent(object p_objPrintContent)
		{
			if(p_objPrintContent.GetType().Name !="clsPrintInfo_CardiovascularTend")
			{
				clsPublicFunction.ShowInformationMessageBox("参数错误");
			}
			m_blnIsFromDataSource=false;//表明是从文件直接提取信息
			m_objPrintInfo=(clsPrintInfo_CardiovascularTend)p_objPrintContent;
			m_objPrintDataArr= m_objPrintInfo.m_objPrintDataArr ;		
			m_blnWantInit=false;
		}

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
					clsPublicFunction.ShowInformationMessageBox("当从数据库读取时,调用m_objGetPrintInfo之前请首先调用m_mthSetPrintInfo函数");
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
			m_fotTitleFont = new Font("SimSun", 20,FontStyle.Bold );
			m_fotSmallFont = new Font("SimSun",12);	
			m_fotTinyFont=new Font("SimSun",10);
			m_GridPen = new Pen(Color.Black,1);
			m_slbBrush = new SolidBrush(Color.Black);
           
		}

		/// <summary>
		/// 释放打印变量
		/// </summary>
		public void m_mthDisposePrintTools(object p_objArg)
		{
			m_fotTitleFont.Dispose();
			m_fotSmallFont.Dispose();
			m_fotTinyFont.Dispose();
			m_GridPen.Dispose();
			m_slbBrush.Dispose();
   
		}
		/// <summary>
		/// 设置打印内容。
		/// </summary>
		/// <param name="p_objTransDataArr"></param>
		/// <param name="p_dtmFirstPrintDate"></param>
		private void m_mthSetPrintContent(clsTransDataInfo[] p_objTransDataArr,
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
            m_objPrintDataArr = (clsCardiovascularTend_GXDataInfo[])m_arlTemp.ToArray(typeof(clsCardiovascularTend_GXDataInfo));
            try
            {
              
                    for (int i2 = 0; i2 < m_objPrintDataArr.Length; i2++)
                        if(m_objPrintDataArr[i2].m_objRecordArr!=null)
                        for (int j2 = 0; j2 < m_objPrintDataArr[i2].m_objRecordArr.Length; j2++)
                        {
                            if (m_objPrintDataArr[i2].m_objRecordArr[j2].m_dtmRECORDDATE.ToString("yyyy-MM-dd") == m_objPrintInfo.m_objPrintBaseDataArr[m_intFlag].m_dtmRECORDDATE.ToString("yyyy-MM-dd"))
                            {
                                m_intRecordCount++;

                            }
                        }
            }
            catch (Exception ex)
            {
                clsPublicFunction.ShowInformationMessageBox(ex.ToString());
            }
		}

        #region 有关打印的声明
        /// <summary>
        /// 正面当前行的Y坐标
        /// </summary>
        private int m_intFrontPosY = (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowsMark3;
        /// <summary>
        /// 背面当前行的Y坐标
        /// </summary>
        private int m_intBackPosY = (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowsMark3;
		/// <summary>
		/// 标题的字体
		/// </summary>
		private Font m_fotTitleFont;
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
        /// 记录打印总页数
        /// </summary>
        private int m_intTotalPageCount = 2;
		/// <summary>
		/// 当前背面打印的记录的序号
		/// </summary>
		private int m_intBackCurrentRecord=0;
        /// <summary>
        /// 当前正面打印的记录的序号
        /// </summary>
        private int m_intFrontCurrentRecord = 0;  
		/// <summary>
		/// 旧记录打完,准备打印一条新记录
		/// </summary>
		bool m_blnBeginPrintNewRecord=true;		
		/// <summary>
		/// （若要保留历史痕迹）当前记录内容
		/// </summary>
		private string[][] m_strValueArr;
		/// <summary>
		/// 格子的信息
		/// </summary>
		private enum enmRecordRectangleInfo//正面
		{//A3纸张，横向 ：1620*1024 Size
			/// <summary>
			/// 最佳宽度
			/// </summary>
			PerformWith=40,
			/// <summary>
			/// 格子的顶端
			/// </summary>
			TopY = 175,
			/// <summary>
			/// 表头第一条分割线
			/// </summary>
			RowsMark1=30,
			/// <summary>
			/// 表头第二条分割线(呼吸音)
			/// </summary>
			RowsMark2=70,
			/// <summary>
			/// 表头第三条分割线（表中用户数据的起点线）
			/// </summary>
			RowsMark3=180,
			///<summary>
			/// 格子的左端
			/// </summary>
			LeftX = 25,
			/// <summary>
			/// 格子的右端
			/// </summary>
			RightX = 1620-30,
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
			/// 第一条间隔线(X),实入量1（起点线）
			/// </summary>			
			ColumnsMark1=75,

			/// <summary>
			/// 第二条间隔线(X)，实入量2（起点线）
			/// </summary>
			ColumnsMark2=ColumnsMark1+PerformWith-15,//105

			/// <summary>
			/// 第3条间隔线(X)，实入量3（起点线）
			/// </summary>
			ColumnsMark3=ColumnsMark2+PerformWith-15,//135

			/// <summary>
			/// 第4条间隔线(X)，实入量4（起点线）
			/// </summary>
			ColumnsMark4=ColumnsMark3+PerformWith-15,//165

			/// <summary>
			///  第5条间隔线(X)，实入量5（起点线）
			/// </summary>
			ColumnsMark5=ColumnsMark4+ PerformWith-15,//195

			/// <summary>
			/// 全血（起点线）
			/// </summary>
			ColumnsMark6=ColumnsMark5+ PerformWith-15,//225

			/// <summary>
			///     （起点线）
			/// </summary>
			ColumnsMark7=ColumnsMark6+ PerformWith,//270

			/// <summary>
			///每时（起点线）
			/// </summary>
			ColumnsMark8=ColumnsMark7+ PerformWith-15,//300

			/// <summary>
			///(入量) 总量（起点线）
			/// </summary>
			ColumnsMark9=ColumnsMark8+ PerformWith,//345

			/// <summary>
			///(出量)总量 （起点线）
			/// </summary>
			ColumnsMark10=ColumnsMark9+ PerformWith,//390

			/// <summary>
			/// 出量>>每时（起点线）
			/// </summary>
			ColumnsMark11=ColumnsMark10+ PerformWith,//435

			/// <summary>
			/// 累积尿量（起点线）
			/// </summary>
			ColumnsMark12=ColumnsMark11+ PerformWith,//480

			/// <summary>
			/// 尿量（起点线）
			/// </summary>
			ColumnsMark13=ColumnsMark12+ PerformWith,//525

			/// <summary>
			///胸液（起点线）
			/// </summary>
			ColumnsMark14=ColumnsMark13+ PerformWith,//570

			/// <summary>
			///积累胸液（起点线）
			/// </summary>
			ColumnsMark15=ColumnsMark14+ PerformWith,//615

			/// <summary>
			/// 胃液（起点线）
			/// </summary>
			ColumnsMark16=ColumnsMark15+ PerformWith,//660

			/// <summary>
			/// 升压扩张血管药物（起点线）
			/// </summary>
			ColumnsMark17=ColumnsMark16+ PerformWith,//705

			/// <summary>
			///强心利尿（起点线）
			/// </summary>
			ColumnsMark18=ColumnsMark17+ PerformWith*2,//795

			/// <summary>
			///其他药物（起点线）
			/// </summary>
			ColumnsMark19=ColumnsMark18+ PerformWith,//840

			/// <summary>
			/// 神志（起点线）
			/// </summary>
			ColumnsMark20=ColumnsMark19+ PerformWith,//885
	
			/// <summary>
			/// 循环>>体温（起点线）
			/// </summary>
			ColumnsMark21=ColumnsMark20+ PerformWith,//930
			/// <summary>
			///循环>>心率（起点线）
			/// </summary>
			ColumnsMark22=ColumnsMark21+ PerformWith,//975
			/// <summary>
			/// 血压（起点线）
			/// </summary>
			ColumnsMark23=ColumnsMark22+ PerformWith,//1010
			/// <summary>
			/// 循环>>cvp（起点线）
			/// </summary>
			ColumnsMark24=ColumnsMark23+ PerformWith,//1055
			/// <summary>
			///呼吸机型号（起点线）
			/// </summary>
			ColumnsMark25=ColumnsMark24+ PerformWith,//1100
			/// <summary>
			/// 辅助（起点线）
			/// </summary>
			ColumnsMark26=ColumnsMark25+ PerformWith*2,//1190
			/// <summary>
			/// FiO2（起点线）
			/// </summary>
			ColumnsMark27=ColumnsMark26+ PerformWith,//1235
			/// <summary>
			/// 吸气压（起点线）
			/// </summary>
			ColumnsMark28=ColumnsMark27+ PerformWith,//1280
			/// <summary>
			///TV（起点线）
			/// </summary>
			ColumnsMark29=ColumnsMark28+ PerformWith*2,//1370
			ColumnsMark30=ColumnsMark29+ PerformWith,//1415
			/// <summary>
			/// 呼吸音（起点线）
			/// </summary>
			ColumnsMark31=ColumnsMark30+ PerformWith,//1460
			/// <summary>
			///痰色（起点线）
			/// </summary>
			ColumnsMark32=ColumnsMark31+ PerformWith*2,//1550
			/// <summary>
			/// 体位（起点线）
			/// </summary>
			ColumnsMark33=ColumnsMark32+ PerformWith,//1595
			/// <summary>
			/// 备注（起点线）
			/// </summary>
		    ColumnsMark34=ColumnsMark33+ PerformWith,//1640

		}
        private enum enmRecordBackRectangleInfo //背面
        {//A3纸张，横向 ：1620*1024 Size
            /// <summary>
            /// 最佳宽度
            /// </summary>
            PerformWith = 45,
            /// <summary>
            /// 格子的顶端
            /// </summary>
            TopY = 175,
            ///<summary>
            /// 格子的左端
            /// </summary>
            LeftX = 25,
            /// <summary>
            /// 格子的右端
            /// </summary>
            RightX = 1620 - 30,
            /// <summary>
            /// 第一条间隔线(X),WBC（起点线）
            /// </summary>			
            ColumnsMark1 = 75,

            /// <summary>
            /// 第二条间隔线(X)，Hb（起点线）
            /// </summary>
            ColumnsMark2 = ColumnsMark1 + PerformWith,//105

            /// <summary>
            /// 第3条间隔线(X)，RBC（起点线）
            /// </summary>
            ColumnsMark3 = ColumnsMark2 + PerformWith ,//135

            /// <summary>
            /// 第4条间隔线(X)，HCT（起点线）
            /// </summary>
            ColumnsMark4 = ColumnsMark3 + PerformWith,//165

            /// <summary>
            ///  第5条间隔线(X)，PLT（起点线）
            /// </summary>
            ColumnsMark5 = ColumnsMark4 + PerformWith,//195

            /// <summary>
            /// PH（起点线）
            /// </summary>
            ColumnsMark6 = ColumnsMark5 + PerformWith ,//225

            /// <summary>
            ///  PCO3   （起点线）
            /// </summary>
            ColumnsMark7 = ColumnsMark6 + PerformWith,//270

            /// <summary>
            ///PaO2（起点线）
            /// </summary>
            ColumnsMark8 = ColumnsMark7 + PerformWith ,//300

            /// <summary>
            ///HCO3（起点线）
            /// </summary>
            ColumnsMark9 = ColumnsMark8 + PerformWith,//345

            /// <summary>
            ///BE（起点线）
            /// </summary>
            ColumnsMark10 = ColumnsMark9 + PerformWith,//390

            /// <summary>
            ///K+（起点线）
            /// </summary>
            ColumnsMark11 = ColumnsMark10 + PerformWith,//435

            /// <summary>
            /// Na+（起点线）
            /// </summary>
            ColumnsMark12 = ColumnsMark11 + PerformWith,//480

            /// <summary>
            ///CL-（起点线）
            /// </summary>
            ColumnsMark13 = ColumnsMark12 + PerformWith,//525

            /// <summary>
            ///Ca++（起点线）
            /// </summary>
            ColumnsMark14 = ColumnsMark13 + PerformWith,//570

            /// <summary>
            ///GLU（起点线）
            /// </summary>
            ColumnsMark15 = ColumnsMark14 + PerformWith,//615

            /// <summary>
            /// BUN（起点线）
            /// </summary>
            ColumnsMark16 = ColumnsMark15 + PerformWith,//660

            /// <summary>
            /// UA（起点线）
            /// </summary>
            ColumnsMark17 = ColumnsMark16 + PerformWith,//705

            /// <summary>
            ///JI（起点线）
            /// </summary>
            ColumnsMark18 = ColumnsMark17 + PerformWith,//795

            /// <summary>
            ///CO2CP（起点线）
            /// </summary>
            ColumnsMark19 = ColumnsMark18 + PerformWith,//840

            /// <summary>
            ///PT（起点线）
            /// </summary>
            ColumnsMark20 = ColumnsMark19 + PerformWith,//885

            /// <summary>
            ///X线检查（起点线）
            /// </summary>
            ColumnsMark21 = ColumnsMark20 + PerformWith,//930
            /// <summary>
            ///ACT（起点线）
            /// </summary>
            ColumnsMark22 = ColumnsMark21 + PerformWith*3,//975
            /// <summary>
            /// 比重（起点线）
            /// </summary>
            ColumnsMark23 = ColumnsMark22 + (int)PerformWith,//1010
            /// <summary>
            /// 蛋白（起点线）
            /// </summary>
            ColumnsMark24 = ColumnsMark23 + PerformWith,//1055
            /// <summary>
            ///潜血（起点线）
            /// </summary>
            ColumnsMark25 = ColumnsMark24 + PerformWith,//1100
            /// <summary>
            ///  （起点线）
            /// </summary>
            ColumnsMark26 = ColumnsMark25 + PerformWith ,//1190
            ///  <summary>
            ///  皮肤 （起点线）
            /// </summary>
            ColumnsMark27 = ColumnsMark26 + PerformWith,//1235
            /// <summary>
            ///  会阴冲洗 （起点线）
            /// </summary>
            ColumnsMark28 = ColumnsMark27 + PerformWith,//1280
            /// <summary>
            ///擦浴（起点线）
            /// </summary>
            ColumnsMark29 = ColumnsMark28 + PerformWith,//1370
            /// <summary>
            ///口腔护理（起点线）
            /// </summary>
            ColumnsMark30 = ColumnsMark29 + PerformWith,//1415
            /// <summary>
            ///     （起点线）
            /// </summary>
            ColumnsMark31 = ColumnsMark30 + PerformWith//1415
     

        }
		#endregion
		#region 打印实现
		/// <summary>
		/// 打印开始
		/// </summary>
		/// <param name="p_objPrintArg">此处p_objPrintArg要求为PrintEventArgs类型的对象</param>
		public void m_mthBeginPrint(object p_objPrintArg)
		{			
			m_mthBeginPrintSub((PrintEventArgs)p_objPrintArg);
		}
        // 打印开始后，在打印页之前的操作
        private void m_mthBeginPrintSub(PrintEventArgs p_objPrintArg)
        {

        }
		/// <summary>
		/// 打印中
		/// </summary>
		/// <param name="p_objPrintArg">此处p_objPrintArg要求为PrintPageEventArgs类型的对象</param>
		public void m_mthPrintPage(object p_objPrintArg)
		{
			m_mthPrintPageSub((PrintPageEventArgs)p_objPrintArg);
		}

		/// <summary>
		/// 打印结束。一般使用它来更新数据库信息。
		/// </summary>
		/// <param name="p_objPrintArg">此处p_objPrintArg要求为PrintEventArgs类型的对象</param>
		public void m_mthEndPrint(object p_objPrintArg)
		{
            if (m_objPrintInfo==null || m_blnIsFromDataSource == false || m_objPrintInfo.m_strInPatientID == "") return;
			//如果打印成功，查找有无需要更新的时间，如果有，更新时间。 
			if(!((PrintEventArgs)p_objPrintArg).Cancel && m_objPrintInfo.m_blnIsFirstPrintArr != null)
			{
				ArrayList arlRecordType = new ArrayList();
				ArrayList arlOpenDate = new ArrayList();
				int intUpdateIndex = -1;//若没有任何记录
				for(int i=0;i<m_objPrintInfo.m_blnIsFirstPrintArr.Length;i++)
				{
					if(m_objPrintInfo.m_blnIsFirstPrintArr[i])
					{    
						//更新记录，只需使用新的首次打印时间作为有效的输入参数。
						//存放记录类型
						arlRecordType.Add(m_objPrintInfo.m_objTransDataArr[i].m_intFlag);
						//存放记录的OpenDate
						arlOpenDate.Add(m_objPrintInfo.m_objTransDataArr[i].m_objRecordContent.m_dtmOpenDate);			
						intUpdateIndex = i;
					}
				}   

				if(intUpdateIndex >= 0)
				{
					m_objRecordsDomain.m_lngUpdateFirstPrintDate(m_objPrintInfo.m_strInPatientID,m_objPrintInfo.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"),(int[])arlRecordType.ToArray(typeof(int)),(DateTime[])arlOpenDate.ToArray(typeof(DateTime)),m_objPrintInfo.m_dtmFirstPrintDateArr[intUpdateIndex]);
				}
				m_objPrintInfo.m_objTransDataArr = null;		
				m_objPrintInfo.m_blnIsFirstPrintArr = null;
			}                          
			m_mthEndPrintSub((PrintEventArgs)p_objPrintArg);
		}	
	
		// 打印页，每打印一页，调用一次，是打印中最有用的函数。
		private void m_mthPrintPageSub(PrintPageEventArgs p_objPrintPageArg)
		{			
			try
			{

                if (m_objPrintInfo.m_strInPatientID == "" || m_objPrintDataArr == null || m_objPrintDataArr.Length == 0)
                    return;
              
                if (m_intNowPage % 2 != 0)//打印正面
                {
                    m_mthPrintTitleInfo(p_objPrintPageArg);
                    m_mthPrintFrontRectangleInfo(p_objPrintPageArg);
                    m_mthPrintHeaderInfo(p_objPrintPageArg);

                    if(m_intRecordCount>0)
                    while (m_intFrontCurrentRecord < m_intRecordCount)
                    {

                        if (m_intFrontCurrentRecord == 0)
                            m_intSetPrintOneValueRows(p_objPrintPageArg);
                        if (m_blnCheckPageChange(ref m_intFrontPosY, p_objPrintPageArg) == true)
                           break;

                       m_blnBeginPrintNewRecord = m_blnPrintOneValue(p_objPrintPageArg, m_intFrontPosY, ref m_intFrontCurrentRecord);

                        if (m_blnBeginPrintNewRecord)
                        {
                          
                            if (m_blnCheckPageChange(ref m_intFrontPosY, p_objPrintPageArg) == true)
                                break;
                        }

                    }
                }
                else//打印背面
                {

                    m_mthPrintBackRectangleInfo(p_objPrintPageArg);
                    m_mthPrintHeaderInfo(p_objPrintPageArg);
                    if (m_intRecordCount > 0)
                    while (m_intBackCurrentRecord < m_intRecordCount)
                    {

                        if (m_intBackCurrentRecord == 0)
                            m_intSetPrintOneValueRows(p_objPrintPageArg);
                        if (m_blnCheckPageChange(ref m_intBackPosY, p_objPrintPageArg) == true)
                            break;

                        m_blnBeginPrintNewRecord = m_blnPrintOneValue(p_objPrintPageArg, m_intBackPosY,ref m_intBackCurrentRecord);

                        if (m_blnBeginPrintNewRecord)
                        {
                            
                            if (m_blnCheckPageChange(ref m_intBackPosY, p_objPrintPageArg) == true)
                                break;
                        }

                    }

                }

                if (m_intNowPage < m_intTotalPageCount)
                {
                    //if (m_intNowPage % 2 != 0)
                     //  clsPublicFunction.ShowInformationMessageBox("请翻转当前页面继续打印背面！");
                    m_intNowPage++;
                    p_objPrintPageArg.HasMorePages = true;
                }
                else 
                {   
                  
            
                     m_intBackCurrentRecord = 0;
                     m_intNowPage=1;
                     m_intTotalPageCount = 2;
                     m_intFrontCurrentRecord = 0;  
                     m_intFrontPosY = (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowsMark3;
                     m_intBackPosY = (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowsMark3;
                     p_objPrintPageArg.HasMorePages = false;
                }
      			
			}
			catch(Exception err)
			{
				clsPublicFunction.ShowInformationMessageBox(err.Message + "\r\n" + err.StackTrace);
			}
		}
		/// <summary>
		/// 检查是否换页,true:换页，false:不换页
		/// </summary>
		/// <param name="p_intYBottom">要检测的底线Y坐标</param>
		/// <param name="e"></param>
		/// <returns></returns>
		private bool m_blnCheckPageChange(ref int p_intYBottom,System.Drawing.Printing.PrintPageEventArgs e)
		{
			if(p_intYBottom+100 >= 1015)
			{

                p_intYBottom = (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowsMark3;
                this.m_intTotalPageCount += 2;
				return true;	
			}
			else 
                return false;			
		}

		// 打印结束时的操作
		private void m_mthEndPrintSub(PrintEventArgs p_objPrintArg)
		{		
		}
        //画数据的操作
        private void m_mthPrintInBlock(ref int p_intPosY, int p_intLeftX, int p_intRightX, string p_strText, System.Drawing.Printing.PrintPageEventArgs e)
        {
          
            RectangleF rtg = new RectangleF(p_intLeftX+1 , p_intPosY+2,p_intRightX-p_intLeftX, 20);
            SizeF szfText = e.Graphics.MeasureString(p_strText, this.m_fotSmallFont, Convert.ToInt32(rtg.Width));
            rtg.Height = szfText.Height;
            rtg.Y = p_intPosY+4;
            e.Graphics.DrawString(p_strText, this.m_fotSmallFont, Brushes.Black, rtg);
            p_intPosY += Convert.ToInt32(rtg.Height);
        }
		#endregion 
		#region 标题文字部分
		/// <summary>
		/// 标题文字部分
		/// </summary>
		/// <param name="e"></param>
		private void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
		{
            string strPrintText = "";
            int m_objPosY = 60;
           
			e.Graphics.DrawString("心 血 管 外 科 特 护 记 录", this.m_fotTitleFont, this.m_slbBrush, clsPrintPosition.c_intLeftX+ 150, m_objPosY);
            e.Graphics.DrawString("____________________________", this.m_fotTitleFont, this.m_slbBrush, clsPrintPosition.c_intLeftX + 135, m_objPosY+4);
            e.Graphics.DrawString("____________________________", this.m_fotTitleFont, this.m_slbBrush, clsPrintPosition.c_intLeftX + 135, m_objPosY + 5);
            m_objPosY += 50;
           
         
            strPrintText = "姓名:" + m_objPrintInfo.m_strPatientName + "  " + "病案号:" + m_objPrintInfo.m_strInPatientID + "  " + "年龄:" + m_objPrintInfo.m_strAge + "  "+"体重:" ;
            if (m_intFlag >= 0)
            {
                if (m_objPrintInfo.m_objPrintBaseDataArr[m_intFlag].m_dblWEITHT.ToString() != "")
                    strPrintText += m_objPrintInfo.m_objPrintBaseDataArr[m_intFlag].m_dblWEITHT + " kg  手术后";
                else
                    strPrintText += "_______kg  手术后";
                if (m_objPrintInfo.m_objPrintBaseDataArr[m_intFlag].m_strAFTEROPDAYS.Trim() != "")
                    strPrintText += m_objPrintInfo.m_objPrintBaseDataArr[m_intFlag].m_strAFTEROPDAYS + "天   手术名称：";
                else
                    strPrintText += "______天   手术名称：";
                if (m_objPrintInfo.m_objPrintBaseDataArr[m_intFlag].m_strOPNAME.Trim() != "")
                    strPrintText += m_objPrintInfo.m_objPrintBaseDataArr[m_intFlag].m_strOPNAME;
                else
                    strPrintText += "__________________";
                e.Graphics.DrawString(strPrintText, m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX, m_objPosY+3);  
                strPrintText="1.";
                m_objPosY += 40;
                if (m_objPrintInfo.m_objPrintBaseDataArr[m_intFlag].m_strOPMEDICINE1.Trim() != "")
                    strPrintText += m_objPrintInfo.m_objPrintBaseDataArr[m_intFlag].m_strOPMEDICINE1 + " 2.";
                else
                    strPrintText += "_____________ 2.";
                if (m_objPrintInfo.m_objPrintBaseDataArr[m_intFlag].m_strOPMEDICINE2.Trim() != "")
                    strPrintText += m_objPrintInfo.m_objPrintBaseDataArr[m_intFlag].m_strOPMEDICINE2 + " 3.";
                else
                    strPrintText += "_____________ 3.";
                if (m_objPrintInfo.m_objPrintBaseDataArr[m_intFlag].m_strOPMEDICINE3.Trim() != "")
                    strPrintText += m_objPrintInfo.m_objPrintBaseDataArr[m_intFlag].m_strOPMEDICINE3 + " 4.";
                else
                    strPrintText += "_____________ 4.";
                if (m_objPrintInfo.m_objPrintBaseDataArr[m_intFlag].m_strOPMEDICINE4.Trim() != "")
                    strPrintText += m_objPrintInfo.m_objPrintBaseDataArr[m_intFlag].m_strOPMEDICINE1 + " 5.";
                else
                    strPrintText += "_____________ 5.";
                if (m_objPrintInfo.m_objPrintBaseDataArr[m_intFlag].m_strOPMEDICINE5.Trim() != "")
                    strPrintText += m_objPrintInfo.m_objPrintBaseDataArr[m_intFlag].m_strOPMEDICINE1;
                else
                    strPrintText += "_____________";
                e.Graphics.DrawString(strPrintText, m_fotSmallFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX, m_objPosY);

                if (m_objPrintInfo.m_objPrintBaseDataArr[m_intFlag].m_dtmRECORDDATE.ToString() != "")
                    strPrintText = m_objPrintInfo.m_objPrintBaseDataArr[m_intFlag].m_dtmRECORDDATE.ToString("yyyy年MM月dd日") + "  第  " + (m_intNowPage / 2 + 1) + "  页";
                else
                    strPrintText = "________年_______月________日    " + "  第  " + (m_intNowPage / 2 + 1) + "  页";

                e.Graphics.DrawString(strPrintText, m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.RightX-250, m_objPosY);

                strPrintText = "长班签名:";
                if (m_objPrintInfo.m_objPrintBaseDataArr[m_intFlag].m_strLONGCLASSSIGNID.Trim() != "")
                    strPrintText += m_objPrintInfo.m_objPrintBaseDataArr[m_intFlag].m_strLONGCLASSSIGNID + "  办公班签名:";
                else
                    strPrintText += "_____________   办公班签名:";
                if (m_objPrintInfo.m_objPrintBaseDataArr[m_intFlag].m_strOFFICESIGNID.Trim() != "")
                    strPrintText += m_objPrintInfo.m_objPrintBaseDataArr[m_intFlag].m_strOFFICESIGNID+"   夜班签名(小):";
                else
                    strPrintText += "_____________   夜班签名(小):";
                if (m_objPrintInfo.m_objPrintBaseDataArr[m_intFlag].m_strSMALLNIGHTCLASSSIGNID.Trim() != "")
                    strPrintText += m_objPrintInfo.m_objPrintBaseDataArr[m_intFlag].m_strSMALLNIGHTCLASSSIGNID + "(大)";
                else
                    strPrintText += "_____________(大)";
                if (m_objPrintInfo.m_objPrintBaseDataArr[m_intFlag].m_strBIGNIGHTCLASSSIGNID.Trim() != "")
                    strPrintText += m_objPrintInfo.m_objPrintBaseDataArr[m_intFlag].m_strBIGNIGHTCLASSSIGNID;
                else
                    strPrintText += "_____________";

                e.Graphics.DrawString(strPrintText, m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + 100, 1035);
                e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle, m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.RightX - 200, 1035);
            }
            else
            {
                strPrintText += "_____kg 手术后____天     手术名称:_____________________";
                e.Graphics.DrawString(strPrintText, m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX, m_objPosY);
                m_objPosY += 40;
                strPrintText = "1.____________ 2.____________ 3.____________ 4.____________ 5.____________ ";
                e.Graphics.DrawString(strPrintText, m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX, m_objPosY);
                strPrintText = "________年_______月________日    " + "  第 "+( m_intNowPage / 2 + 1) + " 页";
                e.Graphics.DrawString(strPrintText, m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.RightX - 250, m_objPosY);
                strPrintText = "长班签名___________ 办公班签名___________  夜班签名(小)______________________(大)____________________";
                e.Graphics.DrawString(strPrintText, m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + 100, 1035);
                e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle, m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.RightX - 200, 1035);   
            }
           
		}
        #endregion
        #region 画正面表头格子
        /// <summary>
        ///  画正面表头格子
        /// </summary>
        /// <param name="e"></param>
        private void m_mthPrintFrontRectangleInfo(System.Drawing.Printing.PrintPageEventArgs e)
		{			
			
			#region 画格子横线
            int m_intPosY1=(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark3;
			for(int i1=0;i1<5;i1++)//顶部
			{
				if(i1 ==0 )
					e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX ,
						(int)enmRecordRectangleInfo.TopY,
						(int)enmRecordRectangleInfo.RightX,
						(int)enmRecordRectangleInfo.TopY);
				else if(i1 ==4)
					e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX ,
						(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark3,
						(int)enmRecordRectangleInfo.RightX,
						(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark3);
				else if(i1==1)
				{
					e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.ColumnsMark20,
						(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark1,
						(int)enmRecordRectangleInfo.ColumnsMark34,
						(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark1);					
				}
				else if(i1==2)
				{
					e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.ColumnsMark1,
						(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark1,
						(int)enmRecordRectangleInfo.ColumnsMark17,
						(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark1);					
				}
				else if(i1==3)
				{
					e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.ColumnsMark31,
						(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark2,
						(int)enmRecordRectangleInfo.ColumnsMark32,
						(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark2);					
				}
			}
            for (int i2 = 0; i2 < 33; i2++)//33行数据
            {
                m_intPosY1 += 20;
                e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX, m_intPosY1, (int)enmRecordRectangleInfo.RightX, m_intPosY1);
            }


	
			#endregion 画格子横线
			#region 画格子竖线
			int intXPos=(int)enmRecordRectangleInfo.LeftX;
			int intXPos1=(int)enmRecordRectangleInfo.LeftX;
			int intYTop=(int)enmRecordRectangleInfo.TopY;
			int intYBottom=(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark3;
			int intYFirstBottom=(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark1;
			int intYSecBottom=(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowsMark2;

            #region 格子斜线
            intXPos = (int)enmRecordRectangleInfo.ColumnsMark6;
            intXPos1 = (int)enmRecordRectangleInfo.ColumnsMark7;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYBottom, intXPos1, intYFirstBottom);

            intXPos = (int)enmRecordRectangleInfo.ColumnsMark20;
            intXPos1 = (int)enmRecordRectangleInfo.ColumnsMark21;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYBottom, intXPos1, intYFirstBottom);

            intXPos = (int)enmRecordRectangleInfo.ColumnsMark21;
            intXPos1 = (int)enmRecordRectangleInfo.ColumnsMark22;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYBottom, intXPos1, intYFirstBottom);

            intXPos = (int)enmRecordRectangleInfo.ColumnsMark22;
            intXPos1 = (int)enmRecordRectangleInfo.ColumnsMark23;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYBottom, intXPos1, intYFirstBottom);

            intXPos = (int)enmRecordRectangleInfo.ColumnsMark23;
            intXPos1 = (int)enmRecordRectangleInfo.ColumnsMark24;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYBottom, intXPos1, intYFirstBottom);

            intXPos = (int)enmRecordRectangleInfo.ColumnsMark24;
            intXPos1 = (int)enmRecordRectangleInfo.ColumnsMark25;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYBottom, intXPos1, intYFirstBottom);

            intXPos = (int)enmRecordRectangleInfo.ColumnsMark25;
            intXPos1 = (int)enmRecordRectangleInfo.ColumnsMark26;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYBottom, intXPos1, intYFirstBottom);

            intXPos = (int)enmRecordRectangleInfo.ColumnsMark27;
            intXPos1 = (int)enmRecordRectangleInfo.ColumnsMark28;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYBottom, intXPos1, intYFirstBottom);

            intXPos = (int)enmRecordRectangleInfo.ColumnsMark28;
            intXPos1 = (int)enmRecordRectangleInfo.ColumnsMark29;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYBottom, intXPos1, intYFirstBottom);

            intXPos = (int)enmRecordRectangleInfo.ColumnsMark29;
            intXPos1 = (int)enmRecordRectangleInfo.ColumnsMark30;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYBottom, intXPos1, intYFirstBottom);

            intXPos = (int)enmRecordRectangleInfo.ColumnsMark31;
            intXPos1 = (int)enmRecordRectangleInfo.ColumnsMark32;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYBottom, intXPos1, intYSecBottom);

            intXPos = (int)enmRecordRectangleInfo.ColumnsMark32;
            intXPos1 = (int)enmRecordRectangleInfo.ColumnsMark33;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYBottom, intXPos1, intYFirstBottom);

            intXPos = (int)enmRecordRectangleInfo.ColumnsMark33;
            intXPos1 = (int)enmRecordRectangleInfo.ColumnsMark34;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYBottom, intXPos1, intYFirstBottom);
            #endregion

            intYBottom = 1015;
			//画左边沿线
            intXPos = (int)enmRecordRectangleInfo.LeftX;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.ColumnsMark1;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.ColumnsMark2;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYFirstBottom,intXPos,intYBottom);
			
			
			intXPos=(int)enmRecordRectangleInfo.ColumnsMark3;	
			e.Graphics.DrawLine(m_GridPen,intXPos,intYFirstBottom,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.ColumnsMark4;	
			e.Graphics.DrawLine(m_GridPen,intXPos,intYFirstBottom,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.ColumnsMark5;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYFirstBottom,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.ColumnsMark6;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYFirstBottom,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.ColumnsMark7;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYFirstBottom,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.ColumnsMark8;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.ColumnsMark9;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYFirstBottom,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.ColumnsMark10;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.ColumnsMark11;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYFirstBottom,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.ColumnsMark12;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.ColumnsMark13;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYFirstBottom,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.ColumnsMark14;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYFirstBottom,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.ColumnsMark15;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYFirstBottom,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.ColumnsMark16;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYFirstBottom,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.ColumnsMark17;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.ColumnsMark18;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.ColumnsMark19;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.ColumnsMark20;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.ColumnsMark21;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.ColumnsMark22;
		    e.Graphics.DrawLine(m_GridPen,intXPos,intYFirstBottom,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.ColumnsMark23;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYFirstBottom,intXPos,intYBottom);

			intXPos=(int)enmRecordRectangleInfo.ColumnsMark24;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYFirstBottom,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.ColumnsMark25;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.ColumnsMark26;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYFirstBottom,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.ColumnsMark27;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYFirstBottom,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.ColumnsMark28;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYFirstBottom,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.ColumnsMark29;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYFirstBottom,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.ColumnsMark30;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYFirstBottom,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.ColumnsMark31;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYFirstBottom,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.ColumnsMark32;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYFirstBottom,intXPos,intYBottom);

			intXPos=(int)enmRecordRectangleInfo.ColumnsMark33;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYFirstBottom,intXPos,intYBottom);
			
			intXPos=(int)enmRecordRectangleInfo.ColumnsMark34;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);

			intXPos=(int)enmRecordRectangleInfo.RightX;
			e.Graphics.DrawLine(m_GridPen,intXPos,intYTop,intXPos,intYBottom);	
			
			
			#endregion				

		}			
		#endregion	
        #region 画背面表头格子
        /// <summary>
        ///  画背面表头格子
        /// </summary>
        /// <param name="e"></param>
        private void m_mthPrintBackRectangleInfo(System.Drawing.Printing.PrintPageEventArgs e)
        {

            #region 画格子横线
            int m_intPosY1 = (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowsMark3;
            for (int i1 = 0; i1 < 4; i1++)
            {
                if (i1 == 0)
                    e.Graphics.DrawLine(m_GridPen, (int)enmRecordBackRectangleInfo.LeftX,
                        (int)enmRecordBackRectangleInfo.TopY,
                        (int)enmRecordBackRectangleInfo.RightX,
                        (int)enmRecordBackRectangleInfo.TopY);
                else if (i1 == 3)
                    e.Graphics.DrawLine(m_GridPen, (int)enmRecordBackRectangleInfo.LeftX,
                        (int)enmRecordBackRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowsMark3,
                        (int)enmRecordBackRectangleInfo.RightX,
                        (int)enmRecordBackRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowsMark3);
                else if (i1 == 1)
                {
                    e.Graphics.DrawLine(m_GridPen, (int)enmRecordBackRectangleInfo.ColumnsMark1,
                        (int)enmRecordBackRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowsMark1,
                        (int)enmRecordBackRectangleInfo.ColumnsMark20,
                        (int)enmRecordBackRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowsMark1);
                }
                else if (i1 == 2)
                {
                    e.Graphics.DrawLine(m_GridPen, (int)enmRecordBackRectangleInfo.ColumnsMark23,
                        (int)enmRecordBackRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowsMark1,
                        (int)enmRecordBackRectangleInfo.ColumnsMark27,
                        (int)enmRecordBackRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowsMark1);
                }
         
            }
            for (int i2 = 0; i2 < 33; i2++)//33行数据
            {
                m_intPosY1 += 20;
                e.Graphics.DrawLine(m_GridPen, (int)enmRecordRectangleInfo.LeftX, m_intPosY1, (int)enmRecordRectangleInfo.RightX, m_intPosY1);
            }


            #endregion 画格子横线
            #region 画格子竖线
            int intXPos = (int)enmRecordBackRectangleInfo.LeftX;
            int intYTop = (int)enmRecordBackRectangleInfo.TopY;
            int intYBottom = 1015;
            int intYFirstBottom = (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowsMark1;

            //画左边沿线
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordBackRectangleInfo.ColumnsMark1;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos =(int)enmRecordBackRectangleInfo.ColumnsMark2;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYFirstBottom, intXPos, intYBottom);


            intXPos = (int)enmRecordBackRectangleInfo.ColumnsMark3;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYFirstBottom, intXPos, intYBottom);

            intXPos = (int)enmRecordBackRectangleInfo.ColumnsMark4;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYFirstBottom, intXPos, intYBottom);

            intXPos = (int)enmRecordBackRectangleInfo.ColumnsMark5;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYFirstBottom, intXPos, intYBottom);

            intXPos = (int)enmRecordBackRectangleInfo.ColumnsMark6;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordBackRectangleInfo.ColumnsMark7;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYFirstBottom, intXPos, intYBottom);

            intXPos = (int)enmRecordBackRectangleInfo.ColumnsMark8;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYFirstBottom, intXPos, intYBottom);

            intXPos = (int)enmRecordBackRectangleInfo.ColumnsMark9;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYFirstBottom, intXPos, intYBottom);

            intXPos = (int)enmRecordBackRectangleInfo.ColumnsMark10;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYFirstBottom, intXPos, intYBottom);

            intXPos = (int)enmRecordBackRectangleInfo.ColumnsMark11;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordBackRectangleInfo.ColumnsMark12;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYFirstBottom, intXPos, intYBottom);

            intXPos = (int)enmRecordBackRectangleInfo.ColumnsMark13;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYFirstBottom, intXPos, intYBottom);

            intXPos = (int)enmRecordBackRectangleInfo.ColumnsMark14;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYFirstBottom, intXPos, intYBottom);

            intXPos = (int)enmRecordBackRectangleInfo.ColumnsMark15;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYFirstBottom, intXPos, intYBottom);

            intXPos = (int)enmRecordBackRectangleInfo.ColumnsMark16;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordBackRectangleInfo.ColumnsMark17;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYFirstBottom, intXPos, intYBottom);

            intXPos = (int)enmRecordBackRectangleInfo.ColumnsMark18;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYFirstBottom, intXPos, intYBottom);

            intXPos = (int)enmRecordBackRectangleInfo.ColumnsMark19;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYFirstBottom, intXPos, intYBottom);

            intXPos = (int)enmRecordBackRectangleInfo.ColumnsMark20;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordBackRectangleInfo.ColumnsMark21;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordBackRectangleInfo.ColumnsMark22;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordBackRectangleInfo.ColumnsMark23;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordBackRectangleInfo.ColumnsMark24;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYFirstBottom, intXPos, intYBottom);

            intXPos = (int)enmRecordBackRectangleInfo.ColumnsMark25;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYFirstBottom, intXPos, intYBottom);

            intXPos = (int)enmRecordBackRectangleInfo.ColumnsMark26;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYFirstBottom, intXPos, intYBottom);

            intXPos = (int)enmRecordBackRectangleInfo.ColumnsMark27;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordBackRectangleInfo.ColumnsMark28;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordBackRectangleInfo.ColumnsMark29;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordBackRectangleInfo.ColumnsMark30;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordBackRectangleInfo.ColumnsMark31;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);

            intXPos = (int)enmRecordBackRectangleInfo.RightX;
            e.Graphics.DrawLine(m_GridPen, intXPos, intYTop, intXPos, intYBottom);


            #endregion
    
        }


        #endregion	
		#region 画表头格子的标题		
		/// <summary>
		///画表头格子的标题
		/// </summary>
		/// <param name="e"></param>
		private void m_mthPrintHeaderInfo(System.Drawing.Printing.PrintPageEventArgs e)
		{		
			
			int[] intYPosFontArr=new int[9]{ (int)enmRecordRectangleInfo.TopY + 10,//0
											   (int)enmRecordRectangleInfo.TopY + 25,//1
											   (int)enmRecordRectangleInfo.TopY + 50,//2
											   (int)enmRecordRectangleInfo.TopY + 70,//3
											   (int)enmRecordRectangleInfo.TopY + 90,//4
											   (int)enmRecordRectangleInfo.TopY + 110,//5
											   (int)enmRecordRectangleInfo.TopY + 130,//6
											   (int)enmRecordRectangleInfo.TopY + 150,//7
											   (int)enmRecordRectangleInfo.TopY + 170//8		   
										   };
            if (m_intNowPage % 2 != 0)//打印正面标题
            {
                e.Graphics.DrawString("时", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + 12, intYPosFontArr[1]);
                e.Graphics.DrawString("间", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + 12, intYPosFontArr[5] + 15);

                e.Graphics.DrawString("实  入  量", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark3, intYPosFontArr[0]);
                e.Graphics.DrawString("1", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark1 + 5, intYPosFontArr[5] - 10);
                e.Graphics.DrawString("2", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark2 + 5, intYPosFontArr[5] - 10);
                e.Graphics.DrawString("3", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark3 + 5, intYPosFontArr[5] - 10);
                e.Graphics.DrawString("4", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark4 + 5, intYPosFontArr[5] - 10);
                e.Graphics.DrawString("5", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark5 + 5, intYPosFontArr[5] - 10);

                e.Graphics.DrawString("全", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark6, intYPosFontArr[1] + 10);
                e.Graphics.DrawString("血", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark6, intYPosFontArr[1] + 30);

                e.Graphics.DrawString("血", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark7 - 20, intYPosFontArr[7] - 10);
                e.Graphics.DrawString("浆", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark7 - 20, intYPosFontArr[8] - 10);

                e.Graphics.DrawString("入量", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark9 - 20, intYPosFontArr[0]);
                e.Graphics.DrawString("每", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark8 + 10, intYPosFontArr[2]);
                e.Graphics.DrawString("时", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark8 + 10, intYPosFontArr[7]);
                e.Graphics.DrawString("总", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark9 + 10, intYPosFontArr[2]);
                e.Graphics.DrawString("量", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark9 + 10, intYPosFontArr[7]);

                e.Graphics.DrawString("出量", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark11 - 20, intYPosFontArr[0]);
                e.Graphics.DrawString("总", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark10 + 10, intYPosFontArr[2]);
                e.Graphics.DrawString("量", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark10 + 10, intYPosFontArr[7]);
                e.Graphics.DrawString("每", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark11 + 10, intYPosFontArr[2]);
                e.Graphics.DrawString("时", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark11 + 10, intYPosFontArr[7]);

                e.Graphics.DrawString("实  出  量", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark13, intYPosFontArr[0]);
                e.Graphics.DrawString("累", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark12 + 10, intYPosFontArr[2]);
                e.Graphics.DrawString("积", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark12 + 10, intYPosFontArr[3] + 15);
                e.Graphics.DrawString("尿", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark12 + 10, intYPosFontArr[4] + 25);
                e.Graphics.DrawString("量", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark12 + 10, intYPosFontArr[5] + 40);

                e.Graphics.DrawString("尿", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark13 + 10, intYPosFontArr[2]);
                e.Graphics.DrawString("量", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark13 + 10, intYPosFontArr[7]);
                e.Graphics.DrawString("胸", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark14 + 10, intYPosFontArr[2]);
                e.Graphics.DrawString("液", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark14 + 10, intYPosFontArr[7]);

                e.Graphics.DrawString("积", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark15 + 10, intYPosFontArr[2]);
                e.Graphics.DrawString("累", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark15 + 10, intYPosFontArr[3] + 15);
                e.Graphics.DrawString("尿", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark15 + 10, intYPosFontArr[4] + 25);
                e.Graphics.DrawString("量", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark15 + 10, intYPosFontArr[5] + 40);
                e.Graphics.DrawString("胃", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark16 + 10, intYPosFontArr[2]);
                e.Graphics.DrawString("液", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark16 + 10, intYPosFontArr[7]);

                e.Graphics.DrawString("升压扩张", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark17 + 5, intYPosFontArr[1]);
                e.Graphics.DrawString("血管药物", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark17 + 5, intYPosFontArr[4]);
                e.Graphics.DrawString("ug/kg/min", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark17, intYPosFontArr[7]);

                e.Graphics.DrawString("强", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark18 + 10, intYPosFontArr[1]);
                e.Graphics.DrawString("心", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark18 + 10, intYPosFontArr[3]);
                e.Graphics.DrawString("利", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark18 + 10, intYPosFontArr[5]);
                e.Graphics.DrawString("尿", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark18 + 10, intYPosFontArr[7]);

                e.Graphics.DrawString("其", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark19 + 10, intYPosFontArr[1]);
                e.Graphics.DrawString("他", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark19 + 10, intYPosFontArr[3]);
                e.Graphics.DrawString("药", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark19 + 10, intYPosFontArr[5]);
                e.Graphics.DrawString("物", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark19 + 10, intYPosFontArr[7]);

                e.Graphics.DrawString("神志", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark20 + 1, intYPosFontArr[0]);
                e.Graphics.DrawString("意", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark20, intYPosFontArr[1] + 10);
                e.Graphics.DrawString("识", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark20, intYPosFontArr[1] + 30);
                e.Graphics.DrawString("瞳", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark21 - 20, intYPosFontArr[7] - 10);
                e.Graphics.DrawString("孔", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark21 - 20, intYPosFontArr[8] - 10);

                e.Graphics.DrawString("循          环", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark21 + 20, intYPosFontArr[0]);
                e.Graphics.DrawString("体", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark21, intYPosFontArr[1] + 10);
                e.Graphics.DrawString("温", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark21, intYPosFontArr[1] + 30);
                e.Graphics.DrawString("末", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark22 - 20, intYPosFontArr[6] - 10);
                e.Graphics.DrawString("梢 ", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark22 - 20, intYPosFontArr[7] - 10);
                e.Graphics.DrawString("温", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark22 - 20, intYPosFontArr[8] - 10);

                e.Graphics.DrawString("心", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark22, intYPosFontArr[1] + 10);
                e.Graphics.DrawString("率", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark22, intYPosFontArr[1] + 30);
                e.Graphics.DrawString("心", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark23 - 20, intYPosFontArr[7] - 10);
                e.Graphics.DrawString("律", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark23 - 20, intYPosFontArr[8] - 10);

                e.Graphics.DrawString("血", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark23, intYPosFontArr[1] + 10);
                e.Graphics.DrawString("压", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark23, intYPosFontArr[1] + 30);
                e.Graphics.DrawString("平", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark24 - 20, intYPosFontArr[6] - 10);
                e.Graphics.DrawString("均 ", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark24 - 20, intYPosFontArr[7] - 10);
                e.Graphics.DrawString("压", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark24 - 20, intYPosFontArr[8] - 10);

                e.Graphics.DrawString("CVP", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark24, intYPosFontArr[1] + 10);
                e.Graphics.DrawString("LAP", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark25 - 30, intYPosFontArr[8] - 10);

                e.Graphics.DrawString("呼                         吸", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark26 + 40, intYPosFontArr[0]);
                e.Graphics.DrawString("呼", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark25, intYPosFontArr[1] + 10);
                e.Graphics.DrawString("吸", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark25, intYPosFontArr[1] + 30);
                e.Graphics.DrawString("机", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark25, intYPosFontArr[1] + 50);
                e.Graphics.DrawString("型 ", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark25, intYPosFontArr[1] + 70);
                e.Graphics.DrawString("号", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark25, intYPosFontArr[1] + 90);

                e.Graphics.DrawString("插", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark26 - 20, intYPosFontArr[5] - 10);
                e.Graphics.DrawString("管 ", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark26 - 20, intYPosFontArr[6] - 10);
                e.Graphics.DrawString("深", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark26 - 20, intYPosFontArr[7] - 10);
                e.Graphics.DrawString("度", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark26 - 20, intYPosFontArr[8] - 10);

                e.Graphics.DrawString("辅", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark26 + 10, intYPosFontArr[2]);
                e.Graphics.DrawString("助", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark26 + 10, intYPosFontArr[3] + 10);
                e.Graphics.DrawString("方", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark26 + 10, intYPosFontArr[4] + 20);
                e.Graphics.DrawString("式", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark26 + 10, intYPosFontArr[5] + 30);

                e.Graphics.DrawString("F O", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark27, intYPosFontArr[1] + 10);
                e.Graphics.DrawString("i 2", m_fotTinyFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark27 + 8, intYPosFontArr[1] + 15);
                e.Graphics.DrawString("(%)", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark27, intYPosFontArr[1] + 30);
                e.Graphics.DrawString("I:E", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark27 + 10, intYPosFontArr[8] - 10);

                e.Graphics.DrawString("吸", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark28, intYPosFontArr[1] + 10);
                e.Graphics.DrawString("气", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark28, intYPosFontArr[1] + 30);
                e.Graphics.DrawString("压", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark28, intYPosFontArr[1] + 50);
                e.Graphics.DrawString("PEEP", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark28 + 40, intYPosFontArr[7] - 10);
                e.Graphics.DrawString("(CmH O)", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark28 + 18, intYPosFontArr[8] - 10);
                e.Graphics.DrawString("   2", m_fotTinyFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark28 + 30, intYPosFontArr[8] - 2);

                e.Graphics.DrawString("TV", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark29, intYPosFontArr[1] + 10);
                e.Graphics.DrawString("ml", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark29, intYPosFontArr[1] + 30);
                e.Graphics.DrawString("VF", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark29 + 20, intYPosFontArr[8] - 10);

                e.Graphics.DrawString("呼", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark30 + 10, intYPosFontArr[2]);
                e.Graphics.DrawString("吸", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark30 + 10, intYPosFontArr[3] + 15);
                e.Graphics.DrawString("次", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark30 + 10, intYPosFontArr[4] + 25);
                e.Graphics.DrawString("数", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark30 + 10, intYPosFontArr[5] + 35);

                e.Graphics.DrawString("呼吸音", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark31 + 10, intYPosFontArr[2] - 5);
                e.Graphics.DrawString("左", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark31, (int)enmRecordRectangleInfo.TopY + (int)enmRecordRectangleInfo.RowsMark2 + 10);
                e.Graphics.DrawString("右", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark32 - 20, intYPosFontArr[8] - 10);

                e.Graphics.DrawString("痰", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark32, intYPosFontArr[1] + 10);
                e.Graphics.DrawString("色", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark32, intYPosFontArr[1] + 30);
                e.Graphics.DrawString("痰", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark33 - 20, intYPosFontArr[7] - 10);
                e.Graphics.DrawString("量", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark33 - 20, intYPosFontArr[8] - 10);

                e.Graphics.DrawString("体", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark33, intYPosFontArr[1] + 10);
                e.Graphics.DrawString("位", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark33, intYPosFontArr[1] + 30);
                e.Graphics.DrawString("理", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark34 - 20, intYPosFontArr[7] - 10);
                e.Graphics.DrawString("疗", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark34 - 20, intYPosFontArr[8] - 10);

                e.Graphics.DrawString("备  注", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.ColumnsMark34 + 35, intYPosFontArr[4] - 5);
            }
            else//打印背面
            {
                e.Graphics.DrawString("时", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + 12, intYPosFontArr[1]);
                e.Graphics.DrawString("间", m_fotSmallFont, m_slbBrush, (int)enmRecordRectangleInfo.LeftX + 12, intYPosFontArr[5] + 15);

                e.Graphics.DrawString("血  常  规", m_fotSmallFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark3-5, intYPosFontArr[0]);
                e.Graphics.DrawString("WBC", m_fotSmallFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark1 + 10, intYPosFontArr[5] - 10);
                e.Graphics.DrawString("Hb", m_fotSmallFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark2 + 12, intYPosFontArr[5] - 10);
                e.Graphics.DrawString("RBC", m_fotSmallFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark3 + 10, intYPosFontArr[5] - 10);
                e.Graphics.DrawString("HCT", m_fotSmallFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark4 + 10, intYPosFontArr[5] - 10);
                e.Graphics.DrawString("PLT", m_fotSmallFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark5 + 10, intYPosFontArr[5] - 10);

                e.Graphics.DrawString("血  气", m_fotSmallFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark8-5, intYPosFontArr[0]);
                e.Graphics.DrawString("PH", m_fotSmallFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark6 + 10, intYPosFontArr[5] - 10);
                e.Graphics.DrawString("PCO", m_fotSmallFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark7 + 5, intYPosFontArr[5] - 10);
                e.Graphics.DrawString("   2", m_fotTinyFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark7 + 5, intYPosFontArr[5] - 1);
                e.Graphics.DrawString("PaO", m_fotSmallFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark8 + 5, intYPosFontArr[5] - 10);
                e.Graphics.DrawString("   2", m_fotTinyFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark8 + 5, intYPosFontArr[5] - 1);
                e.Graphics.DrawString("HCO", m_fotSmallFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark9 + 5, intYPosFontArr[5] - 10);
                e.Graphics.DrawString("   3", m_fotTinyFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark9 + 5, intYPosFontArr[5] - 1);
                e.Graphics.DrawString("BE", m_fotSmallFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark10 + 10, intYPosFontArr[5] - 10);

                e.Graphics.DrawString("血 电 解 质", m_fotSmallFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark13-10, intYPosFontArr[0]);
                e.Graphics.DrawString("K", m_fotSmallFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark11 + 12, intYPosFontArr[5] - 10);
                e.Graphics.DrawString("  +", m_fotTinyFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark11 + 7, intYPosFontArr[5] - 12);
                e.Graphics.DrawString("Na", m_fotSmallFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark12 + 10, intYPosFontArr[5] - 10);
                e.Graphics.DrawString("  +", m_fotTinyFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark12 + 10, intYPosFontArr[5] - 12);
                e.Graphics.DrawString("Cl", m_fotSmallFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark13 + 7, intYPosFontArr[5] - 10);
                e.Graphics.DrawString("  -", m_fotTinyFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark13 + 7, intYPosFontArr[5] - 12);
                e.Graphics.DrawString("Ca", m_fotSmallFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark14 + 5, intYPosFontArr[5] - 10);
                e.Graphics.DrawString("  ++", m_fotTinyFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark14 +5, intYPosFontArr[5] - 12);
                e.Graphics.DrawString("GLU", m_fotSmallFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark15 + 5, intYPosFontArr[5] - 10);


                e.Graphics.DrawString("血 液 生 化", m_fotSmallFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark17+5, intYPosFontArr[0]);
                e.Graphics.DrawString("BUN", m_fotSmallFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark16 + 5, intYPosFontArr[5] - 10);
                e.Graphics.DrawString("UA", m_fotSmallFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark17 + 10, intYPosFontArr[5] - 10);
                e.Graphics.DrawString("肌", m_fotSmallFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark18 + 12, intYPosFontArr[5] - 30);
                e.Graphics.DrawString("酐", m_fotSmallFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark18 + 12, intYPosFontArr[5] + 10);
                e.Graphics.DrawString("CO CP", m_fotSmallFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark19+1, intYPosFontArr[5] - 10);
                e.Graphics.DrawString("  2", m_fotTinyFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark19 + 2, intYPosFontArr[5] - 1);

                e.Graphics.DrawString("PT", m_fotSmallFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark20 + 12, intYPosFontArr[5] - 30);

                e.Graphics.DrawString("X  线", m_fotSmallFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark21 + 45, intYPosFontArr[5] - 50);
                e.Graphics.DrawString("检 查", m_fotSmallFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark21 + 45, intYPosFontArr[5] - 10);

                e.Graphics.DrawString("ACT", m_fotSmallFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark22 + 5, intYPosFontArr[5] - 30);

                e.Graphics.DrawString("尿 常 规", m_fotSmallFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark24+5, intYPosFontArr[0]);
                e.Graphics.DrawString("比重", m_fotSmallFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark23 + 5, intYPosFontArr[5] - 10);
                e.Graphics.DrawString("蛋白", m_fotSmallFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark24 + 5, intYPosFontArr[5] - 10);
                e.Graphics.DrawString("潜血", m_fotSmallFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark25 + 5, intYPosFontArr[5] - 10);

                e.Graphics.DrawString("皮", m_fotSmallFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark27 + 12, intYPosFontArr[1]);
                e.Graphics.DrawString("肤", m_fotSmallFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark27 + 12, intYPosFontArr[5] + 15);

                e.Graphics.DrawString("会", m_fotSmallFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark28 + 12, intYPosFontArr[1]);
                e.Graphics.DrawString("阴", m_fotSmallFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark28 + 12, intYPosFontArr[2] + 10);
                e.Graphics.DrawString("冲", m_fotSmallFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark28 + 12, intYPosFontArr[3] + 20);
                e.Graphics.DrawString("洗", m_fotSmallFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark28 + 12, intYPosFontArr[5] + 15);

                e.Graphics.DrawString("擦", m_fotSmallFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark29 + 12, intYPosFontArr[1]);
                e.Graphics.DrawString("浴", m_fotSmallFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark29 + 12, intYPosFontArr[5] + 15);

                e.Graphics.DrawString("口", m_fotSmallFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark30 + 12, intYPosFontArr[1]);
                e.Graphics.DrawString("腔", m_fotSmallFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark30 + 12, intYPosFontArr[2] + 10);
                e.Graphics.DrawString("护", m_fotSmallFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark30 + 12, intYPosFontArr[3] + 20);
                e.Graphics.DrawString("理", m_fotSmallFont, m_slbBrush, (int)enmRecordBackRectangleInfo.ColumnsMark30 + 12, intYPosFontArr[5] + 15);
              
            }
		}
		#endregion
        #region 打印一行数值,并判断当前记录是否打印完
        /// <summary>
        /// 打印一行数值,并判断当前记录是否打印完
        /// </summary>
        /// <param name="e"></param>
        /// <param name="p_intBottomY"></param>
        /// <returns></returns>
        private bool m_blnPrintOneValue(System.Drawing.Printing.PrintPageEventArgs e, int p_intBottomY, ref int m_intCurrentRecord)
        {
          
            #region 按修改顺序打印当前记录的某一行
            bool blnIsRecordFinish = m_blnPrintOneRowValue(m_strValueArr,ref m_intCurrentRecord, e, p_intBottomY);
            if (blnIsRecordFinish)
                return false;
            else
                return true;
    
            #endregion
        }
        #endregion 打印一行数值,并判断当前记录是否打印完
        #region 打印一行数值
        /// <summary>
        /// 打印一行数值
        /// </summary>
        /// <param name="p_strValueArr">数值(从“时间”到“口腔护理”)</param>
        /// <param name="p_intNowRowInOneRecord">第几次的结果:等价于NowRowInOneRecord</param>
        /// <param name="e">打印参数</param>
        /// <param name="p_intPosY">Y坐标</param>
        private bool m_blnPrintOneRowValue(string[][] p_strValueArr, ref int p_intNowRowInOneRecord, System.Drawing.Printing.PrintPageEventArgs e,  int p_intPosY)
        {   string strPrintText="";

          
            int intMedicine_PupilRows = 0;//存储药物和瞳孔中最大的行数
            string[] strEXPANDVASMEDICINE = null;//升压扩张血管药物
            string[] strCARDIACDIURESIS = null;//强心利尿
            string[] strOTHERMEDICINE = null;//其他药物
            string[] strConArr = null;
            if (p_intNowRowInOneRecord < m_intRecordCount)
            {
                if (m_intNowPage % 2 != 0)
                {
                    for (int i0 = p_intNowRowInOneRecord; i0 < m_intRecordCount-1; i0++)
                    {
                        if (p_strValueArr[p_intNowRowInOneRecord][0].Trim() == p_strValueArr[i0 + 1][0].Trim())
                            p_intNowRowInOneRecord++;

                    }
                    for (int j0 = 0; j0 < m_intFrontPosArr.Length; j0++)
                        m_intFrontPosArr[j0] = p_intPosY;
                    //时间
                    if (p_strValueArr[p_intNowRowInOneRecord][0].Trim() != "")
                    {   
                       
                        strPrintText = DateTime.Parse(p_strValueArr[p_intNowRowInOneRecord][0].ToString()).ToString("HH:mm");

                        m_mthPrintInBlock(ref m_intFrontPosArr[0], (int)enmRecordRectangleInfo.LeftX, (int)enmRecordRectangleInfo.ColumnsMark1, strPrintText, e);
                    }
                    //实入量1
                    if (p_strValueArr[p_intNowRowInOneRecord][1].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][1];
                        m_mthPrintInBlock(ref m_intFrontPosArr[1], (int)enmRecordRectangleInfo.ColumnsMark1, (int)enmRecordRectangleInfo.ColumnsMark2, strPrintText, e);
                    }
                    //2
                    if (p_strValueArr[p_intNowRowInOneRecord][2].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][2];
                        m_mthPrintInBlock(ref m_intFrontPosArr[2], (int)enmRecordRectangleInfo.ColumnsMark2, (int)enmRecordRectangleInfo.ColumnsMark3, strPrintText, e);
                    }
                    //3
                    if (p_strValueArr[p_intNowRowInOneRecord][3].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][3];
                        m_mthPrintInBlock(ref m_intFrontPosArr[3], (int)enmRecordRectangleInfo.ColumnsMark3, (int)enmRecordRectangleInfo.ColumnsMark4, strPrintText, e);
                    }
                    //4
                    if (p_strValueArr[p_intNowRowInOneRecord][4].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][4];
                        m_mthPrintInBlock(ref m_intFrontPosArr[4], (int)enmRecordRectangleInfo.ColumnsMark4, (int)enmRecordRectangleInfo.ColumnsMark5, strPrintText, e);
                    }
                    //5
                    if (p_strValueArr[p_intNowRowInOneRecord][5].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][5];
                        m_mthPrintInBlock(ref m_intFrontPosArr[5], (int)enmRecordRectangleInfo.ColumnsMark5, (int)enmRecordRectangleInfo.ColumnsMark6, strPrintText, e);
                    }
                    //全血/血浆
                    if (p_strValueArr[p_intNowRowInOneRecord][6].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][6];
                        m_mthPrintInBlock(ref m_intFrontPosArr[6], (int)enmRecordRectangleInfo.ColumnsMark6, (int)enmRecordRectangleInfo.ColumnsMark7, strPrintText, e);
                    }
                    //入量/每时
                    if (p_strValueArr[p_intNowRowInOneRecord][7].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][7];
                        m_mthPrintInBlock(ref m_intFrontPosArr[7], (int)enmRecordRectangleInfo.ColumnsMark8, (int)enmRecordRectangleInfo.ColumnsMark9, strPrintText, e);
                    }
                    //入量/总量
                    if (p_strValueArr[p_intNowRowInOneRecord][8].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][8];
                        m_mthPrintInBlock(ref m_intFrontPosArr[8], (int)enmRecordRectangleInfo.ColumnsMark9, (int)enmRecordRectangleInfo.ColumnsMark10, strPrintText, e);
                    }
                    //出量/总量
                    if (p_strValueArr[p_intNowRowInOneRecord][9].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][9];
                        m_mthPrintInBlock(ref m_intFrontPosArr[9], (int)enmRecordRectangleInfo.ColumnsMark10, (int)enmRecordRectangleInfo.ColumnsMark11, strPrintText, e);
                    }
                    //出量/每时
                    if (p_strValueArr[p_intNowRowInOneRecord][10].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][10];
                        m_mthPrintInBlock(ref m_intFrontPosArr[10], (int)enmRecordRectangleInfo.ColumnsMark11, (int)enmRecordRectangleInfo.ColumnsMark12, strPrintText, e);
                    }
                    //实出量>>累积尿量
                    if (p_strValueArr[p_intNowRowInOneRecord][11].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][11];
                        m_mthPrintInBlock(ref m_intFrontPosArr[11], (int)enmRecordRectangleInfo.ColumnsMark12, (int)enmRecordRectangleInfo.ColumnsMark13, strPrintText, e);
                    }
                    //尿量
                    if (p_strValueArr[p_intNowRowInOneRecord][12].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][12];
                        m_mthPrintInBlock(ref m_intFrontPosArr[12], (int)enmRecordRectangleInfo.ColumnsMark13, (int)enmRecordRectangleInfo.ColumnsMark14, strPrintText, e);
                    }
                    //胸液
                    if (p_strValueArr[p_intNowRowInOneRecord][13].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][13];
                        m_mthPrintInBlock(ref m_intFrontPosArr[13], (int)enmRecordRectangleInfo.ColumnsMark14, (int)enmRecordRectangleInfo.ColumnsMark15, strPrintText, e);
                    }
                    //积累胸液
                    if (p_strValueArr[p_intNowRowInOneRecord][14].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][14];
                        m_mthPrintInBlock(ref m_intFrontPosArr[14], (int)enmRecordRectangleInfo.ColumnsMark15, (int)enmRecordRectangleInfo.ColumnsMark16, strPrintText, e);
                    }
                    //胃液
                    if (p_strValueArr[p_intNowRowInOneRecord][15].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][15];
                        m_mthPrintInBlock(ref m_intFrontPosArr[15], (int)enmRecordRectangleInfo.ColumnsMark16, (int)enmRecordRectangleInfo.ColumnsMark17, strPrintText, e);
                    }
                    //升压扩张
                    if (p_strValueArr[p_intNowRowInOneRecord][16].Trim() != "")
                    {
                        strEXPANDVASMEDICINE = p_strValueArr[p_intNowRowInOneRecord][16].Split('√');
                        intMedicine_PupilRows = strEXPANDVASMEDICINE.Length;
                        strPrintText = "";
                        for (int i0 = 0; i0 < intMedicine_PupilRows; i0++)
                        {
                            strConArr = strEXPANDVASMEDICINE[i0].Split('×');

                            if (strConArr.Length == 2)
                            {
                                strPrintText += strConArr[0] + " " + strConArr[1]+" ";
                            }
                            else
                            {
                                strPrintText += strConArr[0] + " " + strConArr[1] + " " + strConArr[2]+" ";
                            }
                        }
                        m_mthPrintInBlock(ref m_intFrontPosArr[16], (int)enmRecordRectangleInfo.ColumnsMark17, (int)enmRecordRectangleInfo.ColumnsMark18, strPrintText, e);
                    }
                    //强心利尿
                    if (p_strValueArr[p_intNowRowInOneRecord][17].Trim() != "")
                    {

                        strCARDIACDIURESIS = p_strValueArr[p_intNowRowInOneRecord][17].Split('√');
                            intMedicine_PupilRows = strCARDIACDIURESIS.Length;
                        strPrintText = "";
                        for (int i1 = 0; i1 < intMedicine_PupilRows; i1++)
                        {
                            strConArr = strCARDIACDIURESIS[i1].Split('×');

                            if (strConArr.Length == 2)
                            {
                                strPrintText += strConArr[0] + " " + strConArr[1] + " ";
                            }
                            else
                            {
                                strPrintText += strConArr[0] + " " + strConArr[1] + " " + strConArr[2] + " ";
                            }
                        }
                        m_mthPrintInBlock(ref m_intFrontPosArr[17], (int)enmRecordRectangleInfo.ColumnsMark18, (int)enmRecordRectangleInfo.ColumnsMark19, strPrintText, e);
                    }
                    //其他药物
                    if (p_strValueArr[p_intNowRowInOneRecord][18].Trim() != "")
                    {
                        strOTHERMEDICINE = p_strValueArr[p_intNowRowInOneRecord][18].Split('√');
 
                            intMedicine_PupilRows = strOTHERMEDICINE.Length;
                        strPrintText = "";
                        for (int i2 = 0; i2< intMedicine_PupilRows; i2++)
                        {
                            strConArr = strOTHERMEDICINE[i2].Split('×');

                            if (strConArr.Length == 2)
                            {
                                strPrintText += strConArr[0] + " " + strConArr[1] + " ";
                            }
                            else
                            {
                                strPrintText += strConArr[0] + " " + strConArr[1] + " " + strConArr[2] + " ";
                            }
                        }
            
                        m_mthPrintInBlock(ref m_intFrontPosArr[18], (int)enmRecordRectangleInfo.ColumnsMark19, (int)enmRecordRectangleInfo.ColumnsMark20, strPrintText, e);
                    }
                    //神志>>意识/瞳孔
                    if (p_strValueArr[p_intNowRowInOneRecord][19].Trim() != "" || p_strValueArr[p_intNowRowInOneRecord][20].Trim() != "" || p_strValueArr[p_intNowRowInOneRecord][75].Trim() != "" || p_strValueArr[p_intNowRowInOneRecord][76].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][19] + "/" + p_strValueArr[p_intNowRowInOneRecord][20];
                        if (p_strValueArr[p_intNowRowInOneRecord][75].Trim() != "")
                            strPrintText += "左:" + p_strValueArr[p_intNowRowInOneRecord][75];
                        if (p_strValueArr[p_intNowRowInOneRecord][76].Trim() != "")
                            strPrintText += "右:" + p_strValueArr[p_intNowRowInOneRecord][76];
                        m_mthPrintInBlock(ref m_intFrontPosArr[19], (int)enmRecordRectangleInfo.ColumnsMark20, (int)enmRecordRectangleInfo.ColumnsMark21, strPrintText, e);
                    }
                    //循环>>体温/末梢温
                    if (p_strValueArr[p_intNowRowInOneRecord][21].Trim() != "" || p_strValueArr[p_intNowRowInOneRecord][22].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][21] + "/" + p_strValueArr[p_intNowRowInOneRecord][22];
                        m_mthPrintInBlock(ref m_intFrontPosArr[21], (int)enmRecordRectangleInfo.ColumnsMark21, (int)enmRecordRectangleInfo.ColumnsMark22, strPrintText, e);
                    }
                    //心率/心律
                    if (p_strValueArr[p_intNowRowInOneRecord][23].Trim() != "" || p_strValueArr[p_intNowRowInOneRecord][24].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][23] + "/" + p_strValueArr[p_intNowRowInOneRecord][24];
                        m_mthPrintInBlock(ref m_intFrontPosArr[23], (int)enmRecordRectangleInfo.ColumnsMark22, (int)enmRecordRectangleInfo.ColumnsMark23, strPrintText, e);
                    }
                    //血压/平均压
                    if (p_strValueArr[p_intNowRowInOneRecord][25].Trim() != "" || p_strValueArr[p_intNowRowInOneRecord][26].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][25] + "/" + p_strValueArr[p_intNowRowInOneRecord][26];
                        m_mthPrintInBlock(ref m_intFrontPosArr[25], (int)enmRecordRectangleInfo.ColumnsMark23, (int)enmRecordRectangleInfo.ColumnsMark24, strPrintText, e);
                    }
                    //CVP/LAP
                    if (p_strValueArr[p_intNowRowInOneRecord][27].Trim() != "" || p_strValueArr[p_intNowRowInOneRecord][28].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][27] + "/" + p_strValueArr[p_intNowRowInOneRecord][28];
                        m_mthPrintInBlock(ref m_intFrontPosArr[27], (int)enmRecordRectangleInfo.ColumnsMark24, (int)enmRecordRectangleInfo.ColumnsMark25, strPrintText, e);
                    }
                    //呼吸机型号/插管深度
                    if (p_strValueArr[p_intNowRowInOneRecord][29].Trim() != "" || p_strValueArr[p_intNowRowInOneRecord][30].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][29] + "/" + p_strValueArr[p_intNowRowInOneRecord][30];
                        m_mthPrintInBlock(ref m_intFrontPosArr[29], (int)enmRecordRectangleInfo.ColumnsMark25, (int)enmRecordRectangleInfo.ColumnsMark26, strPrintText, e);
                    }
                    //辅助方式
                    if (p_strValueArr[p_intNowRowInOneRecord][31].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][31];
                        m_mthPrintInBlock(ref m_intFrontPosArr[31], (int)enmRecordRectangleInfo.ColumnsMark26, (int)enmRecordRectangleInfo.ColumnsMark27, strPrintText, e);
                    }
                    //FiO2/I:E
                    if (p_strValueArr[p_intNowRowInOneRecord][32].Trim() != "" || p_strValueArr[p_intNowRowInOneRecord][33].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][32] + "/" + p_strValueArr[p_intNowRowInOneRecord][33];
                        m_mthPrintInBlock(ref m_intFrontPosArr[32], (int)enmRecordRectangleInfo.ColumnsMark27, (int)enmRecordRectangleInfo.ColumnsMark28, strPrintText, e);
                    }
                    //吸气压
                    if (p_strValueArr[p_intNowRowInOneRecord][34].Trim() != "" || p_strValueArr[p_intNowRowInOneRecord][35].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][34] + "/" + p_strValueArr[p_intNowRowInOneRecord][35];
                        m_mthPrintInBlock(ref m_intFrontPosArr[34], (int)enmRecordRectangleInfo.ColumnsMark28, (int)enmRecordRectangleInfo.ColumnsMark29, strPrintText, e);
                    }
                    //TV
                    if (p_strValueArr[p_intNowRowInOneRecord][36].Trim() != "" || p_strValueArr[p_intNowRowInOneRecord][37].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][36] + "/" + p_strValueArr[p_intNowRowInOneRecord][37];
                        m_mthPrintInBlock(ref m_intFrontPosArr[36], (int)enmRecordRectangleInfo.ColumnsMark29, (int)enmRecordRectangleInfo.ColumnsMark30, strPrintText, e);
                    }
                    //呼吸次数
                    if (p_strValueArr[p_intNowRowInOneRecord][38].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][38];
                        m_mthPrintInBlock(ref m_intFrontPosArr[38], (int)enmRecordRectangleInfo.ColumnsMark30, (int)enmRecordRectangleInfo.ColumnsMark31, strPrintText, e);
                    }
                    //呼吸音
                    if (p_strValueArr[p_intNowRowInOneRecord][39].Trim() != "" || p_strValueArr[p_intNowRowInOneRecord][40].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][39] + "/" + p_strValueArr[p_intNowRowInOneRecord][40];
                        m_mthPrintInBlock(ref m_intFrontPosArr[39], (int)enmRecordRectangleInfo.ColumnsMark31, (int)enmRecordRectangleInfo.ColumnsMark32, strPrintText, e);
                    }
                    //痰色
                    if (p_strValueArr[p_intNowRowInOneRecord][41].Trim() != "" || p_strValueArr[p_intNowRowInOneRecord][42].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][41] + "/" + p_strValueArr[p_intNowRowInOneRecord][42];
                        m_mthPrintInBlock(ref m_intFrontPosArr[41], (int)enmRecordRectangleInfo.ColumnsMark32, (int)enmRecordRectangleInfo.ColumnsMark33, strPrintText, e);
                    }
                    //体位/理疗
                    if (p_strValueArr[p_intNowRowInOneRecord][43].Trim() != "" || p_strValueArr[p_intNowRowInOneRecord][44].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][43] + "/" + p_strValueArr[p_intNowRowInOneRecord][44];
                        m_mthPrintInBlock(ref m_intFrontPosArr[43], (int)enmRecordRectangleInfo.ColumnsMark33, (int)enmRecordRectangleInfo.ColumnsMark34, strPrintText, e);
                    }
                    //备注
                    if (p_strValueArr[p_intNowRowInOneRecord][45].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][45];
                        m_mthPrintInBlock(ref m_intFrontPosArr[45], (int)enmRecordRectangleInfo.ColumnsMark34, (int)enmRecordRectangleInfo.RightX, strPrintText, e);
                    }
                    int temp0 = 0;
                    for (int k1 = 0; k1 < m_intFrontPosArr.Length ; k1++)
                    {

                        if (m_intFrontPosArr[k1] >temp0)
                            temp0 = m_intFrontPosArr[k1];

                    }
                    m_intFrontPosY = temp0;
                    p_intNowRowInOneRecord++;
                }
                else
                {
                    for (int i1 = p_intNowRowInOneRecord; i1 < m_intRecordCount - 1; i1++)
                    {
                        if (p_strValueArr[p_intNowRowInOneRecord][0].Trim() == p_strValueArr[i1 + 1][0].Trim())
                            p_intNowRowInOneRecord++;

                    }
                    for (int j0 = 0; j0 < m_intBackPosArr.Length; j0++)
                        m_intBackPosArr[j0] = p_intPosY;
                    //时间
                    if (p_strValueArr[p_intNowRowInOneRecord][0].Trim() != "")
                    {
                        strPrintText = DateTime.Parse(p_strValueArr[p_intNowRowInOneRecord][0].ToString()).ToString("HH:mm");

                        m_mthPrintInBlock(ref m_intBackPosArr[0], (int)enmRecordBackRectangleInfo.LeftX, (int)enmRecordBackRectangleInfo.ColumnsMark1, strPrintText, e);
                    }
                    //WBC
                    if (p_strValueArr[p_intNowRowInOneRecord][46].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][46];
                        m_mthPrintInBlock(ref m_intBackPosArr[1], (int)enmRecordBackRectangleInfo.ColumnsMark1, (int)enmRecordBackRectangleInfo.ColumnsMark2, strPrintText, e);
                    }
                    //Hb
                    if (p_strValueArr[p_intNowRowInOneRecord][47].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][47];
                        m_mthPrintInBlock(ref m_intBackPosArr[2], (int)enmRecordBackRectangleInfo.ColumnsMark2, (int)enmRecordBackRectangleInfo.ColumnsMark3, strPrintText, e);
                    }
                    //RBC
                    if (p_strValueArr[p_intNowRowInOneRecord][48].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][48];
                        m_mthPrintInBlock(ref m_intBackPosArr[3], (int)enmRecordBackRectangleInfo.ColumnsMark3, (int)enmRecordBackRectangleInfo.ColumnsMark4, strPrintText, e);
                    }
                    //HCT
                    if (p_strValueArr[p_intNowRowInOneRecord][49].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][49];
                        m_mthPrintInBlock(ref m_intBackPosArr[4], (int)enmRecordBackRectangleInfo.ColumnsMark4, (int)enmRecordBackRectangleInfo.ColumnsMark5, strPrintText, e);
                    }
                    //PLT
                    if (p_strValueArr[p_intNowRowInOneRecord][50].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][50];
                        m_mthPrintInBlock(ref m_intBackPosArr[5], (int)enmRecordBackRectangleInfo.ColumnsMark5, (int)enmRecordBackRectangleInfo.ColumnsMark6, strPrintText, e);
                    }
                    //PH
                    if (p_strValueArr[p_intNowRowInOneRecord][51].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][51];
                        m_mthPrintInBlock(ref m_intBackPosArr[6], (int)enmRecordBackRectangleInfo.ColumnsMark6, (int)enmRecordBackRectangleInfo.ColumnsMark7, strPrintText, e);
                    }
                    //PCO2
                    if (p_strValueArr[p_intNowRowInOneRecord][52].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][52];
                        m_mthPrintInBlock(ref m_intBackPosArr[7], (int)enmRecordBackRectangleInfo.ColumnsMark7, (int)enmRecordBackRectangleInfo.ColumnsMark8, strPrintText, e);
                    }
                    //PaO2
                    if (p_strValueArr[p_intNowRowInOneRecord][53].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][53];
                        m_mthPrintInBlock(ref m_intBackPosArr[8], (int)enmRecordBackRectangleInfo.ColumnsMark8, (int)enmRecordBackRectangleInfo.ColumnsMark9, strPrintText, e);
                    }
                    //HCO3
                    if (p_strValueArr[p_intNowRowInOneRecord][54].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][54];
                        m_mthPrintInBlock(ref m_intBackPosArr[9], (int)enmRecordBackRectangleInfo.ColumnsMark9, (int)enmRecordBackRectangleInfo.ColumnsMark10, strPrintText, e);
                    }
                    //BE
                    if (p_strValueArr[p_intNowRowInOneRecord][55].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][55];
                        m_mthPrintInBlock(ref m_intBackPosArr[10], (int)enmRecordBackRectangleInfo.ColumnsMark10, (int)enmRecordBackRectangleInfo.ColumnsMark11, strPrintText, e);
                    }
                    //K+
                    if (p_strValueArr[p_intNowRowInOneRecord][56].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][56];
                        m_mthPrintInBlock(ref m_intBackPosArr[11], (int)enmRecordBackRectangleInfo.ColumnsMark11, (int)enmRecordBackRectangleInfo.ColumnsMark12, strPrintText, e);
                    }
                    //Na+
                    if (p_strValueArr[p_intNowRowInOneRecord][57].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][57];
                        m_mthPrintInBlock(ref m_intBackPosArr[12], (int)enmRecordBackRectangleInfo.ColumnsMark12, (int)enmRecordBackRectangleInfo.ColumnsMark13, strPrintText, e);
                    }
                    //Cl-
                    if (p_strValueArr[p_intNowRowInOneRecord][58].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][58];
                        m_mthPrintInBlock(ref m_intBackPosArr[13], (int)enmRecordBackRectangleInfo.ColumnsMark13, (int)enmRecordBackRectangleInfo.ColumnsMark14, strPrintText, e);
                    }
                    //CA++
                    if (p_strValueArr[p_intNowRowInOneRecord][59].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][59];
                        m_mthPrintInBlock(ref m_intBackPosArr[14], (int)enmRecordBackRectangleInfo.ColumnsMark14, (int)enmRecordBackRectangleInfo.ColumnsMark15, strPrintText, e);
                    }
                    //GLU
                    if (p_strValueArr[p_intNowRowInOneRecord][60].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][60];
                        m_mthPrintInBlock(ref m_intBackPosArr[15], (int)enmRecordBackRectangleInfo.ColumnsMark15, (int)enmRecordBackRectangleInfo.ColumnsMark16, strPrintText, e);
                    }
                    //BUN
                    if (p_strValueArr[p_intNowRowInOneRecord][61].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][61];
                        m_mthPrintInBlock(ref m_intBackPosArr[16], (int)enmRecordBackRectangleInfo.ColumnsMark16, (int)enmRecordBackRectangleInfo.ColumnsMark17, strPrintText, e);
                    }
                    //UA
                    if (p_strValueArr[p_intNowRowInOneRecord][62].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][62];
                        m_mthPrintInBlock(ref m_intBackPosArr[17], (int)enmRecordBackRectangleInfo.ColumnsMark17, (int)enmRecordBackRectangleInfo.ColumnsMark18, strPrintText, e);
                    }
                    //肌
                    if (p_strValueArr[p_intNowRowInOneRecord][63].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][63];
                        m_mthPrintInBlock(ref m_intBackPosArr[18], (int)enmRecordBackRectangleInfo.ColumnsMark18, (int)enmRecordBackRectangleInfo.ColumnsMark19, strPrintText, e);
                    }
                    //CO2CP
                    if (p_strValueArr[p_intNowRowInOneRecord][64].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][64];
                        m_mthPrintInBlock(ref m_intBackPosArr[19], (int)enmRecordBackRectangleInfo.ColumnsMark19, (int)enmRecordBackRectangleInfo.ColumnsMark20, strPrintText, e);
                    }
                    //PT
                    if (p_strValueArr[p_intNowRowInOneRecord][65].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][65];
                        m_mthPrintInBlock(ref m_intBackPosArr[20], (int)enmRecordBackRectangleInfo.ColumnsMark20, (int)enmRecordBackRectangleInfo.ColumnsMark21, strPrintText, e);
                    }
                    //X线检查
                    if (p_strValueArr[p_intNowRowInOneRecord][66].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][66];
                        m_mthPrintInBlock(ref m_intBackPosArr[21], (int)enmRecordBackRectangleInfo.ColumnsMark21, (int)enmRecordBackRectangleInfo.ColumnsMark22, strPrintText, e);
                    }
                    //ACT
                    if (p_strValueArr[p_intNowRowInOneRecord][67].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][67];
                        m_mthPrintInBlock(ref m_intBackPosArr[22], (int)enmRecordBackRectangleInfo.ColumnsMark22, (int)enmRecordBackRectangleInfo.ColumnsMark23, strPrintText, e);
                    }
                    //尿常规>>比重
                    if (p_strValueArr[p_intNowRowInOneRecord][68].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][68];
                        m_mthPrintInBlock(ref m_intBackPosArr[23], (int)enmRecordBackRectangleInfo.ColumnsMark23, (int)enmRecordBackRectangleInfo.ColumnsMark24, strPrintText, e);
                    }
                    //蛋白
                    if (p_strValueArr[p_intNowRowInOneRecord][69].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][69];
                        m_mthPrintInBlock(ref m_intBackPosArr[24], (int)enmRecordBackRectangleInfo.ColumnsMark24, (int)enmRecordBackRectangleInfo.ColumnsMark25, strPrintText, e);
                    }
                    //潜血
                    if (p_strValueArr[p_intNowRowInOneRecord][70].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][70];
                        m_mthPrintInBlock(ref m_intBackPosArr[25], (int)enmRecordBackRectangleInfo.ColumnsMark25, (int)enmRecordBackRectangleInfo.ColumnsMark26, strPrintText, e);
                    }
                    //皮肤
                    if (p_strValueArr[p_intNowRowInOneRecord][71].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][71];
                        m_mthPrintInBlock(ref m_intBackPosArr[26], (int)enmRecordBackRectangleInfo.ColumnsMark27, (int)enmRecordBackRectangleInfo.ColumnsMark28, strPrintText, e);
                    }
                    //会阴冲洗
                    if (p_strValueArr[p_intNowRowInOneRecord][72].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][72];
                        m_mthPrintInBlock(ref m_intBackPosArr[27], (int)enmRecordBackRectangleInfo.ColumnsMark28, (int)enmRecordBackRectangleInfo.ColumnsMark29, strPrintText, e);
                    }
                    //擦洗
                    if (p_strValueArr[p_intNowRowInOneRecord][73].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][73];
                        m_mthPrintInBlock(ref m_intBackPosArr[28], (int)enmRecordBackRectangleInfo.ColumnsMark29, (int)enmRecordBackRectangleInfo.ColumnsMark30, strPrintText, e);
                    }
                    //口腔护理
                    if (p_strValueArr[p_intNowRowInOneRecord][74].Trim() != "")
                    {
                        strPrintText = p_strValueArr[p_intNowRowInOneRecord][74];
                        m_mthPrintInBlock(ref m_intBackPosArr[29], (int)enmRecordBackRectangleInfo.ColumnsMark30, (int)enmRecordBackRectangleInfo.ColumnsMark31, strPrintText, e);
                    }
                    int temp=0;
                    for (int k0 = 0; k0 < m_intBackPosArr.Length; k0++)
                    {

                        if (m_intBackPosArr[k0] >temp)
                            temp = m_intBackPosArr[k0];
                   
                    }
                    m_intBackPosY = temp;
                    p_intNowRowInOneRecord++;
                }
               

             
            }
            if(p_intNowRowInOneRecord>=m_intRecordCount)
            return true;
            else
            return false;
        
        }

        #endregion 打印一行数值		
		#region 设置当前要打印所有记录数据,返回记录个数
		/// <summary>
        /// 设置当前要打印所有记录数据,返回记录个数
		/// </summary>
		/// <param name="e"></param>
		/// <param name="p_intBottomY"></param>
		/// <returns></returns>
        private int m_intSetPrintOneValueRows(PrintPageEventArgs e)
        {
            if (m_objPrintDataArr == null||m_intFlag==-1 )
                return 0;
            try
            {
                #region 如果是新记录，判断是否保留痕迹
               
                if (m_blnBeginPrintNewRecord == true&&m_intRecordCount>0)
                {
                    #region 当前记录数组赋值
                    m_strValueArr = new string[m_intRecordCount][];
                    int k1 = 0;
                    for (int i2 = 0; i2 < m_objPrintDataArr.Length; i2++)
                        for (int j2 = 0; j2 < m_objPrintDataArr[i2].m_objRecordArr.Length; j2++)
                        {
                            if (m_objPrintDataArr[i2].m_objRecordArr[j2].m_dtmRECORDDATE.ToString("yyyy-MM-dd") == m_objPrintInfo.m_objPrintBaseDataArr[m_intFlag].m_dtmRECORDDATE.ToString("yyyy-MM-dd"))
                            {

                                    m_strValueArr[k1] = new string[77];
                                   //前页记录
                                    m_strValueArr[k1][0] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_dtmRECORDDATE.ToString("HH:mm");
                                    m_strValueArr[k1][1] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strINFACT1_RIGHT;
                                    m_strValueArr[k1][2] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strINFACT2_RIGHT;
                                    m_strValueArr[k1][3] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strINFACT3_RIGHT;
                                    m_strValueArr[k1][4] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strINFACT4_RIGHT;
                                    m_strValueArr[k1][5] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strINFACT5_RIGHT;
                                    m_strValueArr[k1][6] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strINBLOOD_RIGHT;
                                    m_strValueArr[k1][7] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strINPERHOUR_RIGHT;
                                    m_strValueArr[k1][8] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strINSUM_RIGHT;
                                    m_strValueArr[k1][9] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strOUTSUM_RIGHT;
                                    m_strValueArr[k1][10] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strOUTPERHOUR_RIGHT;
                                    m_strValueArr[k1][11] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strOUTFACTPISSSUM_RIGHT;
                                    m_strValueArr[k1][12] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strOUTFACTPISS_RIGHT;
                                    m_strValueArr[k1][13] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strOUTFACTCHESTJUICE_RIGHT;
                                    m_strValueArr[k1][14] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strOUTFACTCHESTJUICESUM_RIGHT;
                                    m_strValueArr[k1][15] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strOUTFACTGASTRICJUICE_RIGHT;
                                    m_strValueArr[k1][16] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strEXPANDVASMEDICINE_RIGHT;
                                    m_strValueArr[k1][17] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strCARDIACDIURESIS_RIGHT;
                                    m_strValueArr[k1][18] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strOTHERMEDICINE_RIGHT;
                                    m_strValueArr[k1][19] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strCONSCIOUSNESS_RIGHT;
                                    m_strValueArr[k1][20] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strPUPIL_RIGHT;
                                    m_strValueArr[k1][75] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strLEFTPUPIL_RIGHT;
                                    m_strValueArr[k1][76] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strRIGHTPUPIL_RIGHT;
                                    m_strValueArr[k1][21] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strTEMPERATURE_RIGHT;
                                    m_strValueArr[k1][22] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strTWIGTEMPERATURE_RIGHT;
                                    m_strValueArr[k1][23] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strHEARTRATE_RIGHT;
                                    m_strValueArr[k1][24] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strHEARTRHYTHM_RIGHT;
                                    m_strValueArr[k1][25] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strBPA_RIGHT;
                                    m_strValueArr[k1][26] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strAVGBP_RIGHT;
                                    m_strValueArr[k1][27] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strCVP_RIGHT;
                                    m_strValueArr[k1][28] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strLAP_RIGHT;
                                    m_strValueArr[k1][29] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strBREATHMACHINE_RIGHT;
                                    m_strValueArr[k1][30] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strINSERTDEPTH_RIGHT;
                                    m_strValueArr[k1][31] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strASSISTANT_RIGHT;
                                    m_strValueArr[k1][32] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strFIO2_RIGHT;
                                    m_strValueArr[k1][33] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strIE_RIGHT;
                                    m_strValueArr[k1][34] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strINSPIRATION_RIGHT;
                                    m_strValueArr[k1][35] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strPEEP_RIGHT;
                                    m_strValueArr[k1][36] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strTV_RIGHT;
                                    m_strValueArr[k1][37] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strVF_RIGHT;
                                    m_strValueArr[k1][38] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strBREATHTIMES_RIGHT;
                                    m_strValueArr[k1][39] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strLEFTBREATHVOICE_RIGHT;
                                    m_strValueArr[k1][40] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strRIGHTBREATHVOICE_RIGHT;
                                    m_strValueArr[k1][41] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strPHLEGMCOLOR_RIGHT;
                                    m_strValueArr[k1][42] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strPHLEGMQUANTITY_RIGHT;
                                    m_strValueArr[k1][43] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strGESTICULATION_RIGHT;
                                    m_strValueArr[k1][44] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strPHYSICALTHERAPY_RIGHT;
                                    m_strValueArr[k1][45] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strREMARK_RIGHT;
                                    //背面记录
                                    m_strValueArr[k1][46] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strWBC_RIGHT;
                                    m_strValueArr[k1][47] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strHB_RIGHT;
                                    m_strValueArr[k1][48] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strRBC_RIGHT;
                                    m_strValueArr[k1][49] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strHCT_RIGHT;
                                    m_strValueArr[k1][50] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strPLT_RIGHT;
                                    m_strValueArr[k1][51] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strPH_RIGHT;
                                    m_strValueArr[k1][52] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strPCO2_RIGHT;
                                    m_strValueArr[k1][53] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strPAO2_RIGHT;
                                    m_strValueArr[k1][54] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strHCO3_RIGHT;
                                    m_strValueArr[k1][55] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strBE_RIGHT;
                                    m_strValueArr[k1][56] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strKPLUS_RIGHT;
                                    m_strValueArr[k1][57] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strNAPLUS_RIGHT;
                                    m_strValueArr[k1][58] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strCISUB_RIGHT;
                                    m_strValueArr[k1][59] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strCAPLUSPLUS_RIGHT;
                                    m_strValueArr[k1][60] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strGLU_RIGHT;
                                    m_strValueArr[k1][61] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strBUN_RIGHT;
                                    m_strValueArr[k1][62] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strUA_RIGHT;
                                    m_strValueArr[k1][63] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strANHYDRIDE_RIGHT;
                                    m_strValueArr[k1][64] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strCO2CP_RIGHT;
                                    m_strValueArr[k1][65] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strPT_RIGHT;
                                    m_strValueArr[k1][66] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strXRAYCHECK_RIGHT;
                                    m_strValueArr[k1][67] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strACT_RIGHT;
                                    m_strValueArr[k1][68] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strPROPORTION_RIGHT;
                                    m_strValueArr[k1][69] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strALBUMEN_RIGHT;
                                    m_strValueArr[k1][70] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strHIDDENBLOOD_RIGHT;
                                    m_strValueArr[k1][71] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strSKIN_RIGHT;
                                    m_strValueArr[k1][72] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strWASHPERINEUM_RIGHT;
                                    m_strValueArr[k1][73] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strBRUSHBATH_RIGHT;
                                    m_strValueArr[k1][74] = m_objPrintDataArr[i2].m_objRecordArr[j2].m_strMOUTHTEND_RIGHT;
                             
                                    k1++;

                            }
                        }
               
                
                    return m_intRecordCount;

                    #endregion

                }
                else
                    return 0;
                #endregion
            }
            catch (Exception ex)
            {
                clsPublicFunction.ShowInformationMessageBox(ex.Message);
                return 1;
            }
        }
		#endregion
		/// <summary>
		/// 打印信息.
		/// </summary>
		[Serializable]			
		private class clsPrintInfo_CardiovascularTend
		{
			public string m_strInPatientID;	
			public string m_strPatientName;
			public string m_strAge;
			public DateTime m_dtmInPatientDate;
			public DateTime m_dtmOpenDate;
			public clsTransDataInfo[] m_objTransDataArr;			
			public DateTime[] m_dtmFirstPrintDateArr;//Length与m_dtmFirstPrintDateArr.Length相同.
			public bool[] m_blnIsFirstPrintArr;//Length与m_dtmFirstPrintDateArr.Length相同.
            public clsCardiovascularTend_GXDataInfo[] m_objPrintDataArr;
            public clsCardiovascularBaseInfo_GX[] m_objPrintBaseDataArr;
      
 
		}

      
	}
}
