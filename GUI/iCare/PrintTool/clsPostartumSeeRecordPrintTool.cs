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
	/// 中期妊娠引产后观察记录  打印的摘要说明。
	/// </summary>
	public class clsPostartumSeeRecordPrintTool: infPrintRecord
	{
		private bool m_blnIsFromDataSource=true;//表明是从数据库读取还是从文件直接提取信息
		private bool m_blnWantInit=true;	
		private clsICUACAD_POSTPARTUMSEERECORDContentDataInfo[] m_objResultArr = null;
		private	clsPatient m_objPatient = null;
		DateTime m_dtInHos ;

		
		public clsPostartumSeeRecordPrintTool()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
            m_strTitle = "中期妊娠引产后观察记录"; 
            if (com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_StrCurrentHospitalNO == "450101001")
                m_strTitle = "中期妊娠引产产程观察记录";
		
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
		private System.Drawing.Font m_fontBody = new System.Drawing.Font("宋体",10.5f);
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
            //double kk=(Convert.ToDouble(e.PageBounds.Width - 250))/10.00;
			m_fltAvgCol  = 60;//转化成两位小数

			float fltCol =m_fltAvgCol;
			m_fltFirstCol = fltCol+20; //第1列宽度日期

			m_fltSeconCol = fltCol-10; //第2列宽度时间

			m_fltthCol = fltCol; //第3列宽度血压

			m_fltthirCol = fltCol; //第4列宽度体温

			m_fltFiveCol = fltCol; //第5列宽度脉搏

			m_fltSixCol = fltCol+20; //第6列宽度宫缩

			m_fltSenCol = fltCol; //第7列宽度出血

			m_fltNigCol = fltCol; //第8列宽度破水

			m_fltNiNeCol = fltCol; //第9列宽度胎心

            this.m_fltCol10 = fltCol + 20;//宫口大小
			this.m_fltCol11 = 130;//签名


			m_fltFirstColLeft = e.PageBounds.Left + 15 ; //第1列Left坐际
			//			m_fltFirstColLeft = e.MarginBounds.Left - 90  ; //第1列Left坐际
			m_fltSeconColLeft = m_fltFirstCol + m_fltFirstColLeft; //第2列Left坐际
			m_fltthColLeft = m_fltSeconColLeft + m_fltSeconCol; //第3列Left坐际
			m_fltthirColLeft = m_fltthColLeft + m_fltthCol; //第4列Left坐际
			m_fltFiveColLeft = m_fltthirColLeft + m_fltthirCol; //第5列Left坐际
			m_fltSixColLeft = m_fltFiveColLeft + m_fltFiveCol; //第6列Left坐际
			m_fltSenColLeft = m_fltSixColLeft + m_fltSixCol; //第7列Left坐际
			m_fltNigColLeft = m_fltSenColLeft + m_fltSenCol; //第8列Left坐际
			m_fltNiNeColLeft = m_fltNigColLeft + m_fltNiNeCol; //第9列Left坐际
			this.m_fltColLeft10 = m_fltNiNeColLeft + m_fltNiNeCol;//宫口大小Left坐际
			this.m_fltColLeft11 = m_fltColLeft10 + m_fltCol10;//签名Left坐际
            this.m_fltColLeft12 = m_fltColLeft11 + m_fltCol11;

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

            com.digitalwave.clsRecordsService.clsPostartumSeeRecordMainService objServ =
                (com.digitalwave.clsRecordsService.clsPostartumSeeRecordMainService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsRecordsService.clsPostartumSeeRecordMainService));

            //从主表中获取所有没删除的数据
            clsTransDataInfo[] objAr = null;
            objServ.m_lngGetTransDataInfoArr(null,p_objPatient.m_StrRegisterId, out objAr);
            m_mthSetPrintContent(objAr);
		}

        public void m_mthSetRegisterIdAndDate(string p_strRegisterId,DateTime p_dtmCreatedDate)
        { 
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
			return null;
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
        private int intSub = 0;
		//		private int intPageSize =3;

		private void m_mthPrintAllPage(System.Drawing.Printing.PrintPageEventArgs e,ref float p_objLocationY)
		{
			string print = "";
			if(m_objResultArr.Length <=0)
				return ;
            int intPrintCount = 0;

			//计算第一页还能打印出多少条记录
			int intRowCount = Convert.ToInt32((float.Parse(e.MarginBounds.Height.ToString()) - p_objLocationY)/m_ftlRowHeight);
			intRowCount--; //因为留出一行位置来打印页脚,打印 附注 ，所以显示总行数为减1
			//intRowCount--; //因为留出一行位置来打印"特殊记录"

			if(m_intCurrentPageIndex == 1)
			{
				
				for(  i = 0; i< m_objResultArr.Length;i++)
				{
                    clsICUACAD_POSTPARTUMSEERECORDContentDataInfo objRecord = m_objResultArr[i];
                    for (intSub = 0 ; intSub < objRecord.m_objRecordArr.Length ; intSub++)
                    {
                        #region draw one row
                        float fltRealHeight = 0f;
                        print = objRecord.m_objRecordArr[intSub].m_dtmRecordDate.ToString("yy-MM-dd");
                        float fltHeight = m_fltDrawStrAtRectangle(false,this.m_fltFirstColLeft, this.m_fltSeconColLeft, print,p_objLocationY, e);
                        fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                        print = objRecord.m_objRecordArr[intSub].m_dtmRecordDate.ToString("HH:mm");
                        fltHeight = m_fltDrawStrAtRectangle(false, this.m_fltSeconColLeft, this.m_fltthColLeft, print, p_objLocationY, e);
                        fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                        print = objRecord.m_objRecordArr[intSub].m_strBLOODPRESSURE_CHR;
                        fltHeight = m_fltDrawStrAtRectangle(true,this.m_fltthColLeft, this.m_fltthirColLeft, print,  p_objLocationY, e);
                        fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                        print = objRecord.m_objRecordArr[intSub].m_strBODYTEMPARTURE_CHR;
                        fltHeight = m_fltDrawStrAtRectangle(true,this.m_fltthirColLeft, this.m_fltFiveColLeft, print,  p_objLocationY, e);
                        fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                        print = objRecord.m_objRecordArr[intSub].m_strPULSE_CHR;
                        fltHeight = m_fltDrawStrAtRectangle(true,this.m_fltFiveColLeft, this.m_fltSixColLeft, print,  p_objLocationY, e);
                        fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                        print = objRecord.m_objRecordArr[intSub].m_strUTERUS_CHR;
                        fltHeight = m_fltDrawStrAtRectangle(true,this.m_fltSixColLeft, this.m_fltSenColLeft, print,  p_objLocationY, e);
                        fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                        print = objRecord.m_objRecordArr[intSub].m_strBLOODED_CHR;
                        fltHeight = m_fltDrawStrAtRectangle(true,this.m_fltSenColLeft, this.m_fltNigColLeft, print,  p_objLocationY, e);
                        fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                        print = objRecord.m_objRecordArr[intSub].m_strBREAKWATER_CHR;
                        fltHeight = m_fltDrawStrAtRectangle(true,this.m_fltNigColLeft, this.m_fltNiNeColLeft, print,  p_objLocationY, e);
                        fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                        print = objRecord.m_objRecordArr[intSub].m_strEMBRYO_CHR;
                        fltHeight = m_fltDrawStrAtRectangle(true,this.m_fltNiNeColLeft, this.m_fltColLeft10, print, p_objLocationY, e);
                        fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                        print = objRecord.m_objRecordArr[intSub].m_strUTERUSSIZE_CHR;
                        fltHeight = m_fltDrawStrAtRectangle(true,this.m_fltColLeft10, this.m_fltColLeft11, print, p_objLocationY, e);
                        fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                        print = "";
                        if(objRecord.m_objRecordArr[intSub].objSignerArr != null && objRecord.m_objRecordArr[intSub].objSignerArr.Length > 0)
                        {
                            print = objRecord.m_objRecordArr[intSub].objSignerArr[0].objEmployee.m_strGetTechnicalRankAndName;
                            for(int w1 = 1;w1<objRecord.m_objRecordArr[intSub].objSignerArr.Length;w1++)
                            {
                                print += ";"+objRecord.m_objRecordArr[intSub].objSignerArr[w1].objEmployee.m_strGetTechnicalRankAndName;
                            }
                        }
                        fltHeight = m_fltDrawStrAtRectangle(true,this.m_fltColLeft11, this.m_fltColLeft12, print, p_objLocationY, e);
                        fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);
                        fltRealHeight = m_fltGetMaxValue(fltRealHeight, m_ftlRowHeight);
                        m_mthPrintHLine(e.Graphics,p_objLocationY, fltRealHeight);
                        m_mthDrawLines(e,fltRealHeight);


                        p_objLocationY += fltRealHeight;
                        intPrintCount++;
                        #endregion
				        //判断是否多页
                        if (intPrintCount >= intRowCount)
                        {
                            intPrintCount = 0;
                            m_intCurrentPageIndex++;
                            e.HasMorePages = true;
				            m_mthPrintFoot(e);
                            return;
                        }			
                    }

                    intSub = 0;	
				}
			}
			else
			{
				int temp = i;

				#region draw one row
                m_mthPrintFormHeader( e, ref  p_objLocationY);//画表头
				for(  ; i< m_objResultArr.Length;i++)
				{
                    clsICUACAD_POSTPARTUMSEERECORDContentDataInfo objRecord = m_objResultArr[i];
                    for (; intSub < objRecord.m_objRecordArr.Length ; intSub++)
                    {
                        #region draw one row
                        float fltRealHeight = 0f;
                        print = objRecord.m_objRecordArr[intSub].m_dtmCreateDate.ToString("yy-MM-dd");
                        float fltHeight = m_fltDrawStrAtRectangle(false, this.m_fltFirstColLeft, this.m_fltSeconColLeft, print, p_objLocationY, e);
                        fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                        print = objRecord.m_objRecordArr[intSub].m_dtmCreateDate.ToString("HH:mm");
                        fltHeight = m_fltDrawStrAtRectangle(false, this.m_fltSeconColLeft, this.m_fltthColLeft, print, p_objLocationY, e);
                        fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                        print = objRecord.m_objRecordArr[intSub].m_strBLOODPRESSURE_CHR;
                        fltHeight = m_fltDrawStrAtRectangle(true,this.m_fltthColLeft, this.m_fltthirColLeft, print, p_objLocationY, e);
                        fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                        print = objRecord.m_objRecordArr[intSub].m_strBODYTEMPARTURE_CHR;
                        fltHeight = m_fltDrawStrAtRectangle(true,this.m_fltthirColLeft, this.m_fltFiveColLeft, print, p_objLocationY, e);
                        fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                        print = objRecord.m_objRecordArr[intSub].m_strPULSE_CHR;
                        fltHeight = m_fltDrawStrAtRectangle(true,this.m_fltFiveColLeft, this.m_fltSixColLeft, print, p_objLocationY, e);
                        fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                        print = objRecord.m_objRecordArr[intSub].m_strUTERUS_CHR;
                        fltHeight = m_fltDrawStrAtRectangle(true,this.m_fltSixColLeft, this.m_fltSenColLeft, print, p_objLocationY, e);
                        fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                        print = objRecord.m_objRecordArr[intSub].m_strBLOODED_CHR;
                        fltHeight = m_fltDrawStrAtRectangle(true,this.m_fltSenColLeft, this.m_fltNigColLeft, print, p_objLocationY, e);
                        fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                        print = objRecord.m_objRecordArr[intSub].m_strBREAKWATER_CHR;
                        fltHeight = m_fltDrawStrAtRectangle(true,this.m_fltNigColLeft, this.m_fltNiNeColLeft, print, p_objLocationY, e);
                        fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                        print = objRecord.m_objRecordArr[intSub].m_strEMBRYO_CHR;
                        fltHeight = m_fltDrawStrAtRectangle(true,this.m_fltNiNeColLeft, this.m_fltColLeft10, print, p_objLocationY, e);
                        fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                        print = objRecord.m_objRecordArr[intSub].m_strUTERUSSIZE_CHR;
                        fltHeight = m_fltDrawStrAtRectangle(true,this.m_fltColLeft10, this.m_fltColLeft11, print, p_objLocationY, e);
                        fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);

                        print = "";
                        if (objRecord.m_objRecordArr[intSub].objSignerArr != null && objRecord.m_objRecordArr[intSub].objSignerArr.Length > 0)
                        {
                            print = objRecord.m_objRecordArr[intSub].objSignerArr[0].objEmployee.m_strGetTechnicalRankAndName;
                            for (int w1 = 1 ; w1 < objRecord.m_objRecordArr[intSub].objSignerArr.Length ; w1++)
                            {
                                print += ";" + objRecord.m_objRecordArr[intSub].objSignerArr[w1].objEmployee.m_strGetTechnicalRankAndName;
                            }
                        }
                        fltHeight = m_fltDrawStrAtRectangle(true,this.m_fltColLeft11, this.m_fltColLeft12, print,p_objLocationY, e);
                        fltRealHeight = m_fltGetMaxValue(fltRealHeight, fltHeight);
                        fltRealHeight = m_fltGetMaxValue(fltRealHeight, m_ftlRowHeight);
                        #endregion

                        m_mthPrintHLine(e.Graphics,p_objLocationY, fltRealHeight);
                        m_mthDrawLines(e, fltRealHeight);

                        p_objLocationY += fltRealHeight;
                        intPrintCount++;
				        //判断是否多页
                        if (intPrintCount >= intRowCount)
				        {
                            intPrintCount = 0;
					        m_intCurrentPageIndex ++;
					        e.HasMorePages = true;
				            m_mthPrintFoot(e);
					        return;
				        }
                    }
                    intSub = 0;			
				}

				#endregion 
					
			}
			m_mthPrintFoot(e);

		}

		#endregion 

		#region 在最后一页中打印 附注：
//		private void m_mthPrintFuZhu(System.Drawing.Printing.PrintPageEventArgs e, float p_objLocationY)
//		{
//			string str = "附注：产后24小时总出血量："+this.m_strTOTALBLOODNUM_CHR+"ml,会阴伤口拆线：外缝"+m_strSEWPIN_CHR+"针，愈合级别："+m_strPERIOD_CHR+"期";
//			SizeF s = e.Graphics.MeasureString(str,this.m_fontBody);
//			float with = float.Parse(e.PageBounds.Width.ToString()) - s.Width;
//			e.Graphics.DrawString(str,this.m_fontBody,this.m_objBrush,this.m_fltFirstColLeft,p_objLocationY + m_fltZijiHeight/2);
//			p_objLocationY += this.m_ftlRowHeight;
//			e.Graphics.DrawString("特殊记录：",this.m_fontBody,this.m_objBrush,this.m_fltFirstColLeft,p_objLocationY + m_fltZijiHeight/2);
//
//		}
		#endregion

		#region 画线
		private void m_mthDrawLines(PrintPageEventArgs e,float p_fltHeight)
		{
            e.Graphics.DrawLine(this.m_objPen, this.m_fltFirstColLeft, this.m_fltLocationY + p_fltHeight, this.m_fltColLeft12, this.m_fltLocationY + p_fltHeight);
		}
		#endregion 

		//打印页脚
		private void m_mthPrintFoot(PrintPageEventArgs e)
		{
			string str = "第 "+this.m_intCurrentPageIndex.ToString()+" 页";
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
                com.digitalwave.clsRecordsService.clsPostartumSeeRecordService objServ =
                (com.digitalwave.clsRecordsService.clsPostartumSeeRecordService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsRecordsService.clsPostartumSeeRecordService));

                objServ.m_lngUpdateFirstPrintDate(null,m_objPatient.m_StrRegisterId, "1900-1-1", System.DateTime.Now);
			}					
		}

		#endregion
		// 打印开始后，在打印页之前的操作
		private void m_mthBeginPrintSub(PrintEventArgs p_objPrintArg)
		{
            intSub = 0;
            i = 0;
		}

		// 打印页
		private void m_mthPrintPageSub(PrintPageEventArgs p_objPrintPageArg)
		{
			
		}

		// 设置打印内容。
        private void m_mthSetPrintContent(clsTransDataInfo[] p_objTransDataArr)
        {
            if (p_objTransDataArr == null)
            {
                clsPublicFunction.ShowInformationMessageBox("打印数据有误!");
                return;
            }

            ArrayList arlTemp = new ArrayList();
            arlTemp.AddRange(p_objTransDataArr);
            m_objResultArr = (clsICUACAD_POSTPARTUMSEERECORDContentDataInfo[])arlTemp.ToArray(typeof(clsICUACAD_POSTPARTUMSEERECORDContentDataInfo));
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
			this.m_fltLocationY = e.MarginBounds.Top + objSize.Height+15;

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
			int col = e.MarginBounds.Width/4;
			float fltCol = float.Parse(col.ToString());//打印姓名此列的列宽
			System.Drawing.Graphics g = e.Graphics;			

			strPrint  = "姓名:"+p_objPatient.m_StrName.Trim();
			SizeF objSize = g.MeasureString(strPrint, this.m_fontBody);
			g.DrawString(strPrint, m_fontBody, m_objBrush, e.MarginBounds.Left , p_fltLocationY);

			strPrint  = "年龄:"+p_objPatient.m_ObjPeopleInfo.m_IntAge.ToString().Trim();
			objSize = g.MeasureString(strPrint, this.m_fontBody);
			g.DrawString(strPrint, m_fontBody, m_objBrush, e.MarginBounds.Left + fltCol * 1  -20, p_fltLocationY);

			strPrint  = "住院号:"+p_objPatient.m_StrHISInPatientID.Trim();
			objSize = g.MeasureString(strPrint, this.m_fontBody);
			g.DrawString(strPrint, m_fontBody, m_objBrush, e.MarginBounds.Left + fltCol * 2 + 20 , p_fltLocationY);
			strPrint  = "床号:"+p_objPatient.m_strBedCode.Trim();
			objSize = g.MeasureString(strPrint, this.m_fontBody);
			g.DrawString(strPrint, m_fontBody, m_objBrush, e.MarginBounds.Left + fltCol * 3+25 , p_fltLocationY);

			this.m_fltLocationY = p_fltLocationY + objSize.Height;
       
		}
		#endregion

		#region 打表头
		private void m_mthPrintFormHeader(System.Drawing.Printing.PrintPageEventArgs e, ref float p_objLocationY)
		{
			
			System.Drawing.Graphics g = e.Graphics;


            g.DrawLine(this.m_objPen, m_fltFirstColLeft, p_objLocationY, m_fltColLeft12, p_objLocationY);

            m_mthPrintHLine(e.Graphics, p_objLocationY, m_ftlRowHeight);
            //for (int i1 = 0 ; i1 < 12 ; i1++)
            //{
            //    //g.DrawLine(this.m_objPen, e.MarginBounds.Left + e.MarginBounds.Width/14 * i1,p_objLocationY, e.MarginBounds.Left + e.MarginBounds.Width/14 * i1, p_objLocationY +m_ftlRowHeight);
            //    //g.DrawLine(this.m_objPen, this.m_fltFirstColLeft + m_fltAvgCol * i1  ,p_objLocationY, m_fltFirstColLeft + m_fltAvgCol * i1 , p_objLocationY +m_ftlRowHeight * 2);
            //    g.DrawLine(this.m_objPen, this.m_fltFirstColLeft + m_fltAvgCol * i1, p_objLocationY, m_fltFirstColLeft + m_fltAvgCol * i1, p_objLocationY + m_ftlRowHeight);

            //}
//			SizeF s = g.MeasureString("日期",this.m_fontBody);
//			float y = p_objLocationY + m_ftlRowHeight*2 /2 - s.Height/2;
//			float y1 = p_objLocationY + m_ftlRowHeight /2 - s.Height/2;
//			float y2 = p_objLocationY + m_ftlRowHeight + m_ftlRowHeight /2 - s.Height/2;

            m_fltDrawStrAtRectangle(false,this.m_fltFirstColLeft, this.m_fltSeconColLeft, "日期", p_objLocationY + 2, e);

            m_fltDrawStrAtRectangle(false,this.m_fltSeconColLeft, this.m_fltthColLeft, "时间", p_objLocationY + 2, e);
            
            m_fltDrawStrAtRectangle(false,this.m_fltthColLeft, this.m_fltthirColLeft, "血压", p_objLocationY + 2, e);
            
            m_fltDrawStrAtRectangle(false,this.m_fltthirColLeft, this.m_fltFiveColLeft, "体温", p_objLocationY + 2, e);
           
            m_fltDrawStrAtRectangle(false,this.m_fltFiveColLeft, this.m_fltSixColLeft, "脉搏", p_objLocationY + 2, e);

            m_fltDrawStrAtRectangle(false,this.m_fltSixColLeft, this.m_fltSenColLeft, "宫缩", p_objLocationY + 2, e);

            m_fltDrawStrAtRectangle(false,this.m_fltSenColLeft, this.m_fltNigColLeft, "出血", p_objLocationY + 2, e);
           
            m_fltDrawStrAtRectangle(false,this.m_fltNigColLeft, this.m_fltNiNeColLeft, "破水", p_objLocationY + 2, e);
           
            m_fltDrawStrAtRectangle(false,this.m_fltNiNeColLeft, this.m_fltColLeft10, "胎心", p_objLocationY + 2, e);
           
            m_fltDrawStrAtRectangle(false,this.m_fltColLeft10, this.m_fltColLeft11, "宫口大小", p_objLocationY + 2, e);

            m_fltDrawStrAtRectangle(false,this.m_fltColLeft11, this.m_fltColLeft12, "签名", p_objLocationY + 2, e);

			p_objLocationY += m_ftlRowHeight;
			g.DrawLine(this.m_objPen, m_fltFirstColLeft,p_objLocationY, m_fltColLeft11 + m_fltCol11, p_objLocationY);

			
		}
		#endregion 


        private float m_fltDrawStrAtRectangle(bool p_blnIsMeasureH, float col1, float col2, string strPrint, float LocationY, System.Drawing.Printing.PrintPageEventArgs e)
		{
            RectangleF rect = new RectangleF(col1, LocationY + 2, col2 - col1, m_ftlRowHeight);
			System.Drawing.Font m_font = this.m_fontBody;
            SizeF s = e.Graphics.MeasureString(strPrint, m_font, Convert.ToInt32(rect.Width));//字宽
            if (s.Height > rect.Height && p_blnIsMeasureH)
			{
				m_font = new System.Drawing.Font("宋体",9);
                s = e.Graphics.MeasureString(strPrint, m_font,Convert.ToInt32(rect.Width));
                if(s.Height > rect.Height)
                    rect.Height = s.Height+6;
			}
            else if(s.Height > rect.Height)
                rect.Height = s.Height+6;
            StringFormat sf = new StringFormat(StringFormatFlags.FitBlackBox);
            sf.Alignment = StringAlignment.Center;
            //float ji = col2 - col1;
            //float X =  col1 + ji/2 - s.Width/2;
            //float Y = LocationY + m_ftlRowHeight/2 - s.Height/2;
            e.Graphics.DrawString(strPrint, m_font, this.m_objBrush, rect, sf);
            return rect.Height;
		}

		// 打印结束时的操作
		private void m_mthEndPrintSub(PrintEventArgs p_objPrintArg)
		{
            intSub = 0;
            i = 0;
		}
        private float m_fltGetMaxValue(float a,float b)
        {
            return a > b ? a : b;
        }

        void m_mthPrintHLine(System.Drawing.Graphics g, float p_objLocationY, float fltRealHeight)
        {
            g.DrawLine(this.m_objPen, m_fltFirstColLeft, p_objLocationY, m_fltFirstColLeft, p_objLocationY + fltRealHeight);
            g.DrawLine(this.m_objPen, m_fltSeconColLeft, p_objLocationY, m_fltSeconColLeft, p_objLocationY + fltRealHeight);
            g.DrawLine(this.m_objPen, m_fltthColLeft, p_objLocationY, m_fltthColLeft, p_objLocationY + fltRealHeight);
            g.DrawLine(this.m_objPen, m_fltthirColLeft, p_objLocationY, m_fltthirColLeft, p_objLocationY + fltRealHeight);
            g.DrawLine(this.m_objPen, m_fltFiveColLeft, p_objLocationY, m_fltFiveColLeft, p_objLocationY + fltRealHeight);
            g.DrawLine(this.m_objPen, m_fltSixColLeft, p_objLocationY, m_fltSixColLeft, p_objLocationY + fltRealHeight);
            g.DrawLine(this.m_objPen, m_fltSenColLeft, p_objLocationY, m_fltSenColLeft, p_objLocationY + fltRealHeight);
            g.DrawLine(this.m_objPen, m_fltNigColLeft, p_objLocationY, m_fltNigColLeft, p_objLocationY + fltRealHeight);
            g.DrawLine(this.m_objPen, m_fltNiNeColLeft, p_objLocationY, m_fltNiNeColLeft, p_objLocationY + fltRealHeight);
            g.DrawLine(this.m_objPen, m_fltColLeft10, p_objLocationY, m_fltColLeft10, p_objLocationY + fltRealHeight);
            g.DrawLine(this.m_objPen, m_fltColLeft11, p_objLocationY, m_fltColLeft11, p_objLocationY + fltRealHeight);
            g.DrawLine(this.m_objPen, m_fltColLeft12, p_objLocationY, m_fltColLeft12, p_objLocationY + fltRealHeight);
        }

	}
}
