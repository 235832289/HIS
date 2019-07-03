using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;
namespace iCare
{
	/// <summary>
	/// 白内障手术患者知情同意书  打印 的摘要说明。
	/// </summary>
	public class clsIMR_CataractSuffererApprovePrintTool: clsInpatMedRecPrintBase
	{
		public clsIMR_CataractSuffererApprovePrintTool(string p_strTypeID) : base(p_strTypeID)
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		protected override void m_mthSetPrintLineArr()
		{
			m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
				new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
																		   new clsPrintPatientFixInfo("白内障手术患者知情同意书",250),
																		   new clsPrintInPatCataractSuffererMain(),																	  
																		    new  clsPrintInPatMedDoctorAndDate(),
                                                                            new  clsPrintInPatMedDoctorAndDate1()
																		 //  new clsPrintInPatMedRecDiagnostic()
																	   });			
		}
        //protected override void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
        //{}
        //protected override void m_mthPrintHeader(System.Drawing.Printing.PrintPageEventArgs e)
        //{
        //}
		#region 打印第一页的固定内容
		/// <summary>
		/// 打印第一页的固定内容
		/// </summary>
        //internal class clsPrintPatientFixInfo : clsIMR_PrintLineBase
        //{
        //    private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

        //    public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
        //    {
        //        p_objGrp.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle,m_fotItemHead ,Brushes.Black,340,40);
		
        //        p_objGrp.DrawString("白内障手术患者知情同意书",new Font("SimSun", 16,FontStyle.Bold),Brushes.Black,280,70);
			
        //        //				p_objGrp.DrawString("床号："+m_objPrintInfo.m_strAreaName+m_objPrintInfo.m_strBedName ,p_fntNormalText,Brushes.Black,350,110);
        //        //				p_objGrp.DrawString("母亲住院号：",p_fntNormalText,Brushes.Black,550,110);
        //        //p_objGrp.DrawString(m_objPrintInfo.m_strInPatientID ,p_fntNormalText,Brushes.Black,680,110);	
        //        p_intPosY =120;
        //        m_blnHaveMoreLine = false;
        //    }

        //    public override void m_mthReset()
        //    {
        //        m_objPrintContext.m_mthRestartPrint();

        //        m_blnHaveMoreLine = true;
        //    }
        //}

		#endregion
		#region 术前诊断---老年患者
		/// <summary>
		/// 术前诊断---老年患者
		/// </summary>
		private class clsPrintInPatCataractSuffererMain : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private Font m_fontItemMidHead = new Font("",12,FontStyle.Bold);
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			
		//	private string[] m_strKeysArr1 = {"手术日期","手术日期>>至"};
			private string[] m_strKeysArr2 = {"√","拟施手术名称>>超声乳化白内障摘除术"};
			private string[] m_strKeysArr02 = {" 超声乳化白内障摘除术"};

			private string[] m_strKeysArr3 = {"\n                                       √","拟施手术名称>>人工晶体植入术"};
			private string[] m_strKeysArr03 = {"\n                                         人工晶体植入术"};
			
			private string[] m_strKeysArr4 = {"\n                                       √","拟施手术名称>>现代囊外白内障摘除术"};
			private string[] m_strKeysArr04 = {"\n                                         现代囊外白内障摘除术"};
			
			private string[] m_strKeysArr5 = {"\n                                       √","拟施手术名称>>白内障抽吸术"};
			private string[] m_strKeysArr05 = {"\n                                         白内障抽吸术"};
			
			private string[] m_strKeysArr6 = {"\n                                       √","拟施手术名称>>囊内白内障摘除术"};
			private string[] m_strKeysArr06 = {"\n                                         囊内白内障摘除术"};
			
			private string[] m_strKeysArr7 = {"\n                                       √","拟施手术名称>>膜性白内障切除术"};
			private string[] m_strKeysArr07 = {"\n                                         膜性白内障切除术"};

			private string[] m_strKeysArr8 = {"\n    1、√ ","术中可能发生的并发症及其处理>>麻醉意外，需进行抢救，或暂停手术"};
			private string[] m_strKeysArr08 = {"\n    1、   麻醉意外，需进行抢救，或暂停手术"};
			private string[] m_strKeysArr9 = {"\n    2、√ ","术中可能发生的并发症及其处理>>球后或脉络膜出血，需止血、推迟或暂停手术"};
			private string[] m_strKeysArr09 = {"\n    2、   球后或脉络膜出血，需止血、推迟或暂停手术"};
			private string[] m_strKeysArr10 = {"\n    3、√ ","术中可能发生的并发症及其处理>>不能植入人工晶体"};
			private string[] m_strKeysArr010 = {"\n    3、   不能植入人工晶体"};
			private string[] m_strKeysArr11 = {"\n    4、√ ","术中可能发生的并发症及其处理>>其他并发症"};
			private string[] m_strKeysArr011 = {"\n    4、   其他并发症"};
			private string[] m_strKeysArr12 = {"\n    1、√ ","术后可能发生的下述等并发症>>后发性白内障"};
			private string[] m_strKeysArr012 = {"\n    1、   后发性白内障"};
			private string[] m_strKeysArr13 = {"\n    2、√ ","术后可能发生的下述等并发症>>人工晶体脱位"};
			private string[] m_strKeysArr013 = {"\n    2、   人工晶体脱位"};
			private string[] m_strKeysArr14 = {"\n    3、√ ","术后可能发生的下述等并发症>>视网膜脱离眼内炎"};
			private string[] m_strKeysArr014 = {"\n    3、   视网膜脱离眼内炎"};
			private string[] m_strKeysArr15 = {"\n    4、√ ","术后可能发生的下述等并发症>>术后出血角膜内皮失代偿"};
			private string[] m_strKeysArr015 = {"\n    4、   术后出血角膜内皮失代偿"};
			private string[] m_strKeysArr16 = {"\n    5、√ ","术后可能发生的下述等并发症>>伤口裂开"};
			private string[] m_strKeysArr016 = {"\n    5、   伤口裂开"};
			private string[] m_strKeysArr17 = {"\n    6、√ ","术后可能发生的下述等并发症>>其他并发症"};
			private string[] m_strKeysArr017 = {"\n    6、   其他并发症"};
			private string[] m_strKeysArr18 = {"\n    1、√ ","出现下列情况之一者>>眼内驱逐性出血"};
			private string[] m_strKeysArr018 = {"\n    1、   眼内驱逐性出血"};
			private string[] m_strKeysArr19 = {"\n    2、√ ","出现下列情况之一者>>眼内化脓性感染"};
			private string[] m_strKeysArr019 = {"\n    2、   眼内化脓性感染"};
			private string[] m_strKeysArr20 = {"\n    3、√ ","出现下列情况之一者>>大泡性角膜炎"};
			private string[] m_strKeysArr020 = {"\n    3、   大泡性角膜炎"};
			private string[] m_strKeysArr21 = {"\n    4、√ ","出现下列情况之一者>>继发性青光眼"};
			private string[] m_strKeysArr021 = {"\n    4、   继发性青光眼"};
			private string[] m_strKeysArr22 = {"\n    5、√ ","出现下列情况之一者>>视网膜脱离"};
			private string[] m_strKeysArr022 = {"\n    5、   视网膜脱离"};
		

						
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null|| m_objContent.m_objItemContents == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
//				if(m_blnHavePrintInfo(m_strKeysArr1) == false )
//				{
//					m_blnHaveMoreLine = false;
//					return;
//				}
				if(m_blnIsFirstPrint)
				{
					
					string strAllText = "";
					string strXml = "";
					string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
					if(m_objContent!=null)
					{
                        //m_mthMakeText(new string[]{"患者姓名："+(m_objPrintInfo==null ? "": m_objPrintInfo.m_strPatientName)+"；","  性别："+ m_objPrintInfo.m_strSex.Trim()+"；" ,"  年龄："+(m_objPrintInfo==null ? "": m_objPrintInfo.m_strAge)+"；","   病区："+m_objPrintInfo.m_strAreaName+"；"},
                        //    new string [] {"","","",""},ref strAllText,ref strXml);
						
                        ////m_mthMakeText(new string[]{"   年龄："},new string []{"(m_objPrintInfo==null ? : m_objPrintInfo.m_strAge)"},ref strAllText,ref strXml);
                        //m_mthMakeText(new string[]{"   床号："+m_objPrintInfo.m_strBedName+"；"},new string []{""},ref strAllText,ref strXml);
                        //m_mthMakeText(new string[]{"   住院号："+m_objPrintInfo.m_strInPatientID+""},new string []{""},ref strAllText,ref strXml);
						//						m_mthMakeText(new string[]{"姓名："},new string []{"m_objPrintInfo.m_strPatientName"},ref strAllText,ref strXml);
						//						m_mthMakeText(new string[]{"   年龄："},new string []{"(m_objPrintInfo==null ? : m_objPrintInfo.m_strAge)"},ref strAllText,ref strXml);
						//						m_mthMakeText(new string[]{"   床号："},new string []{"m_objPrintInfo.m_strAreaName+m_objPrintInfo.m_strBedName"},ref strAllText,ref strXml);
						//						m_mthMakeText(new string[]{"   住院号："},new string []{"m_objPrintInfo.m_strInPatientID"},ref strAllText,ref strXml);
						//m_mthMakeText(new string[]{"\n手术日期:","    至   $$"},m_strKeysArr1,ref strAllText,ref strXml);
						
						m_mthMakeText(new string[]{"\n        本专科医生将本着对患者及家属负责的精神，严肃认真地进行手术治疗。医生将有关情况、可能出现并发症及注意事项向患者说明如下："},new string[]{""},ref strAllText,ref strXml);
						#region 术前诊断 
						m_mthMakeText(new string[]{"\n一、  术前诊断： 白内障"},new string[]{""},ref strAllText,ref strXml);
						m_mthMakeText(new string[]{"\n                   类型："},new string[]{""},ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(new string[]{"","术前诊断>>白内障>>类型>>老年性"}) != false)
						m_mthMakeCheckText(new string []{"√","术前诊断>>白内障>>类型>>老年性"},ref strAllText,ref strXml);
						else
							m_mthMakeText(new string[]{"老年性；"},new string []{""},ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(new string[]{"","术前诊断>>白内障>>类型>>先天性"}) != false)
							m_mthMakeCheckText(new string []{" √","术前诊断>>白内障>>类型>>先天性"},ref strAllText,ref strXml);
						else
							m_mthMakeText(new string []{"   先天性；"},new string[]{""},ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(new string[]{"","术前诊断>>白内障>>类型>>并发性"}) != false)
							m_mthMakeCheckText(new string []{" √","术前诊断>>白内障>>类型>>并发性"},ref strAllText,ref strXml);
						else
							m_mthMakeText(new string []{"   并发性；"},new string[]{""},ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(new string[]{"","术前诊断>>白内障>>类型>>外伤性"}) != false)
							m_mthMakeCheckText(new string []{" √","术前诊断>>白内障>>类型>>外伤性"},ref strAllText,ref strXml);
						else
							m_mthMakeText(new string []{"   外伤性；"},new string[]{""},ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(new string[]{"","术前诊断>>白内障>>类型>>其他"}) != false)
							m_mthMakeCheckText(new string []{" √","术前诊断>>白内障>>类型>>其他"},ref strAllText,ref strXml);
						else
							m_mthMakeText(new string []{"  其他："},new string[]{""},ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(new string[]{"术前诊断>>白内障>>类型>>其他1"}) != false)
							m_mthMakeText(new string[]{""},new string[]{"术前诊断>>白内障>>类型>>其他1"},ref strAllText,ref strXml);
						else
							m_mthMakeText(new string[]{"_________"},new string[]{""},ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(new string[]{"","术前诊断>>白内障>>类型>>无晶体眼"}) != false)
							m_mthMakeCheckText(new string []{"；√","术前诊断>>白内障>>类型>>无晶体眼"},ref strAllText,ref strXml);
						else
							m_mthMakeText(new string []{"； 无晶体眼"},new string[]{""},ref strAllText,ref strXml);
						#region 眼别
						m_mthMakeText(new string[]{"\n                   眼别："},new string[]{""},ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(new string[]{"","术前诊断>>白内障>>眼别>>右眼"}) != false)
							m_mthMakeCheckText(new string []{"√","术前诊断>>白内障>>眼别>>右眼"},ref strAllText,ref strXml);
						else
							m_mthMakeText(new string []{"右眼；"},new string[]{""},ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(new string[]{"","术前诊断>>白内障>>眼别>>左眼"}) != false)
							m_mthMakeCheckText(new string []{" √","术前诊断>>白内障>>眼别>>左眼"},ref strAllText,ref strXml);
						else
							m_mthMakeText(new string []{"   左眼；"},new string[]{""},ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(new string[]{"","术前诊断>>白内障>>眼别>>双眼(指本次手术眼)"}) != false)
							m_mthMakeCheckText(new string []{" √","术前诊断>>白内障>>眼别>>双眼(指本次手术眼)"},ref strAllText,ref strXml);
						else
							m_mthMakeText(new string []{"   双眼(指本次手术眼)"},new string[]{""},ref strAllText,ref strXml);
						#endregion
						#endregion 术前诊断
						
						#region 麻醉选择
						m_mthMakeText(new string[]{"\n二、  麻醉选择："},new string[]{""},ref strAllText,ref strXml);

						if(m_blnHavePrintInfo(new string[]{"","麻醉选择>>局麻"}) != false)
							m_mthMakeCheckText(new string []{"√","麻醉选择>>局麻"},ref strAllText,ref strXml);
						else
							m_mthMakeText(new string []{" 局麻；"},new string[]{""},ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(new string[]{"","麻醉选择>>基+局麻"}) != false)
							m_mthMakeCheckText(new string []{" √","麻醉选择>>基+局麻"},ref strAllText,ref strXml);
						else
							m_mthMakeText(new string []{"   基+局麻；"},new string[]{""},ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(new string[]{"","麻醉选择>>其他"}) != false)
							m_mthMakeCheckText(new string []{" √","麻醉选择>>其他"},ref strAllText,ref strXml);
						else
							m_mthMakeText(new string []{"   其他："},new string[]{""},ref strAllText,ref strXml);

						if(m_blnHavePrintInfo(new string[]{"","麻醉选择>>其他1"}) != false)
							m_mthMakeText(new string[]{""},new string[]{"麻醉选择>>其他1"},ref strAllText,ref strXml);
                        else
							m_mthMakeText(new string[]{"_________"},new string[]{""},ref strAllText,ref strXml);

						#endregion
						//						m_mthMakeCheckText(new string []{"\n三、  拟施手术名称：",m_strKeysArr2,m_strKeysArr3,m_strKeysArr4,m_strKeysArr5,m_strKeysArr6,m_strKeysArr7},ref strAllText,ref strXml);
//						m_mthMakeCheckText(new string []{"\n四、  术中可能发生的并发症及其处理：",m_strKeysArr8},ref strAllText,ref strXml);
						#region 三、  拟施手术名称
						m_mthMakeText(new string []{"\n三、  拟施手术名称："},new string[]{""},ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr2) != false)
						    m_mthMakeCheckText(m_strKeysArr2,ref strAllText,ref strXml);
						else
							m_mthMakeCheckText(m_strKeysArr02,ref strAllText,ref strXml);

						if(m_blnHavePrintInfo(m_strKeysArr3) != false)
						    m_mthMakeCheckText(m_strKeysArr3,ref strAllText,ref strXml);
						else
							m_mthMakeCheckText(m_strKeysArr03,ref strAllText,ref strXml);

						if(m_blnHavePrintInfo(m_strKeysArr4) != false)
							m_mthMakeCheckText(m_strKeysArr4,ref strAllText,ref strXml);
						else
							m_mthMakeText(m_strKeysArr04,new string[]{""},ref strAllText,ref strXml);

						if(m_blnHavePrintInfo(m_strKeysArr5) != false)
						    m_mthMakeCheckText(m_strKeysArr5,ref strAllText,ref strXml);
						else
							m_mthMakeCheckText(m_strKeysArr05,ref strAllText,ref strXml);

						if(m_blnHavePrintInfo(m_strKeysArr6) != false)
							m_mthMakeCheckText(m_strKeysArr6,ref strAllText,ref strXml);
						else
							m_mthMakeCheckText(m_strKeysArr06,ref strAllText,ref strXml);

						if(m_blnHavePrintInfo(m_strKeysArr7) != false)
							m_mthMakeCheckText(m_strKeysArr7,ref strAllText,ref strXml);
						else
							m_mthMakeCheckText(m_strKeysArr07,ref strAllText,ref strXml);
                        #endregion 三、  拟施手术名称
						#region 四、  术中可能发生的并发症及其处理
						m_mthMakeText(new string []{"\n四、  术中可能发生的并发症及其处理："},new string[]{""},ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr8) != false)
						    m_mthMakeCheckText(m_strKeysArr8,ref strAllText,ref strXml);
                        else
							m_mthMakeCheckText(m_strKeysArr08,ref strAllText,ref strXml);


						if(m_blnHavePrintInfo(m_strKeysArr9) != false)
						    m_mthMakeCheckText(m_strKeysArr9,ref strAllText,ref strXml);
						else
							m_mthMakeCheckText(m_strKeysArr09,ref strAllText,ref strXml);

						if(m_blnHavePrintInfo(m_strKeysArr10) != false)
						    m_mthMakeCheckText(m_strKeysArr10,ref strAllText,ref strXml);
						else
							m_mthMakeCheckText(m_strKeysArr010,ref strAllText,ref strXml);

						if(m_blnHavePrintInfo(m_strKeysArr11) != false)
						   m_mthMakeCheckText(m_strKeysArr11,ref strAllText,ref strXml);
						else
							m_mthMakeCheckText(m_strKeysArr011,ref strAllText,ref strXml);
						#endregion 四、  术中可能发生的并发症及其处理
						
						m_mthMakeText(new string[]{"\n五、  术后视力预后：决定与眼内情况，若眼底条件太差或出现并发症，则术后视力可能恢复不良。"},new string[]{""},ref strAllText,ref strXml);
						#region 六、  术后可能发生的下述等并发症
						m_mthMakeText(new string[]{"\n六、  术后可能发生的下述等并发症："},new string[]{""},ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr12) != false)
							m_mthMakeCheckText(m_strKeysArr12,ref strAllText,ref strXml);
						else
							m_mthMakeCheckText(m_strKeysArr012,ref strAllText,ref strXml);

						if(m_blnHavePrintInfo(m_strKeysArr13) != false)
							m_mthMakeCheckText(m_strKeysArr13,ref strAllText,ref strXml);
						else
						    m_mthMakeCheckText(m_strKeysArr013,ref strAllText,ref strXml);

						if(m_blnHavePrintInfo(m_strKeysArr14) != false)
							m_mthMakeCheckText(m_strKeysArr14,ref strAllText,ref strXml);
						else
							m_mthMakeCheckText(m_strKeysArr014,ref strAllText,ref strXml);

						if(m_blnHavePrintInfo(m_strKeysArr15) != false)
							m_mthMakeCheckText(m_strKeysArr15,ref strAllText,ref strXml);
						else
							m_mthMakeCheckText(m_strKeysArr015,ref strAllText,ref strXml);

						if(m_blnHavePrintInfo(m_strKeysArr16) != false)
							m_mthMakeCheckText(m_strKeysArr16,ref strAllText,ref strXml);
						else
							m_mthMakeCheckText(m_strKeysArr016,ref strAllText,ref strXml);

						if(m_blnHavePrintInfo(m_strKeysArr17) != false)
							m_mthMakeCheckText(m_strKeysArr17,ref strAllText,ref strXml);
						else
							m_mthMakeCheckText(m_strKeysArr017,ref strAllText,ref strXml);

						#endregion 六、  术后可能发生的下述等并发症
						#region 七、  出现下列情况之一者，可能会引起失明，甚至行眼球摘除术
						m_mthMakeText(new string[]{"\n七、  出现下列情况之一者，可能会引起失明，甚至行眼球摘除术："},new string[]{""},ref strAllText,ref strXml);
						if(m_blnHavePrintInfo(m_strKeysArr18) != false)
							m_mthMakeCheckText(m_strKeysArr18,ref strAllText,ref strXml);
						else
							m_mthMakeCheckText(m_strKeysArr018,ref strAllText,ref strXml);

						if(m_blnHavePrintInfo(m_strKeysArr19) != false)
							m_mthMakeCheckText(m_strKeysArr19,ref strAllText,ref strXml);
						else
							m_mthMakeCheckText(m_strKeysArr019,ref strAllText,ref strXml);

						if(m_blnHavePrintInfo(m_strKeysArr20) != false)
							m_mthMakeCheckText(m_strKeysArr20,ref strAllText,ref strXml);
						else
							m_mthMakeCheckText(m_strKeysArr020,ref strAllText,ref strXml);

						if(m_blnHavePrintInfo(m_strKeysArr21) != false)
							m_mthMakeCheckText(m_strKeysArr21,ref strAllText,ref strXml);
						else
							m_mthMakeCheckText(m_strKeysArr021,ref strAllText,ref strXml);

						if(m_blnHavePrintInfo(m_strKeysArr22) != false)
							m_mthMakeCheckText(m_strKeysArr22,ref strAllText,ref strXml);
						else
							m_mthMakeCheckText(m_strKeysArr022,ref strAllText,ref strXml);
						#endregion 七、  出现下列情况之一者，可能会引起失明，甚至行眼球摘除术
						m_mthMakeText(new string[]{"\n八、  老年患者，可能诱发心、脑、肺、肾功能衰竭，引起意外。"},new string[]{""},ref strAllText,ref strXml);
					}
					else
					{
						m_blnHaveMoreLine = false;
						return;
					}
					m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText,strXml,m_dtmFirstPrintTime,m_objContent.m_objItemContents!= null);
					//m_mthAddSign2("检查情形：",m_objPrintContext.m_ObjModifyUserArr);
					m_blnIsFirstPrint = false;					
				}

				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2,m_intRecBaseX+10,p_intPosY,p_objGrp);
					p_intPosY += 20;
				}
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_blnHaveMoreLine = true;
				}
				else
				{
					m_blnHaveMoreLine = false;
				}
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();
				m_blnHaveMoreLine = true;
				m_blnIsFirstPrint = true;
			}
		}
		#endregion
		#region 谈话医生签名
		/// <summary>
		///  谈话医生签名
		/// </summary>
		private class clsPrintInPatMedDoctorAndDate : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private Font m_fontItemMidHead = new Font("",12,FontStyle.Bold);
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private bool blnNextPage = true;
			private string[] m_strKeysArr01 = {"谈话医生签名"};
			private string[] m_strKeysArr101 = {"                                                                                                         谈话医生签名："};
	
			private string[] m_strKeysArr02 = {"日期"};
			private string[] m_strKeysArr102 = {"\n                                                                                                         日 期："};
	


 
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null|| m_objContent.m_objItemContents == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				
				//				if(blnNextPage)
				//				{
				//					//另起一页打印，利用打印时检测p_intPosY是否大于最底边的值的判断来实现
				//					m_blnHaveMoreLine = true;
				//					blnNextPage = false;
				//					p_intPosY += 1500;
				//					return;
				//				}
				if(m_blnIsFirstPrint)
				{
					//					p_objGrp.DrawString("神经系统检查",m_fotItemHead,Brushes.Black,m_intRecBaseX+310,p_intPosY);
					//					p_intPosY += 20;
					//					p_objGrp.DrawString("一般情况",m_fontItemMidHead,Brushes.Black,m_intRecBaseX,p_intPosY);
					//					p_intPosY += 20;
					string strAllText = "";
					string strXml = "";
					string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
					if(m_objContent!=null)
					{
						if(m_blnHavePrintInfo(m_strKeysArr01) != false)
							m_mthMakeText(m_strKeysArr101,m_strKeysArr01,ref strAllText,ref strXml);
						else
							m_mthMakeText(m_strKeysArr101,new string[]{""},ref strAllText,ref strXml);

						if(m_blnHavePrintInfo(m_strKeysArr02) != false)
							m_mthMakeText(m_strKeysArr102,m_strKeysArr02,ref strAllText,ref strXml);
			
			
								
					}
					else
					{
						m_blnHaveMoreLine = false;
						return;
					}
					m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText,strXml,m_dtmFirstPrintTime,m_objContent.m_objItemContents!= null);
					m_mthAddSign2("检查者签字",m_objPrintContext.m_ObjModifyUserArr);
					m_blnIsFirstPrint = false;					
				}

				int intLine = 0;
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2,m_intRecBaseX+10,p_intPosY,p_objGrp);
					p_intPosY += 20;
				}
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_blnHaveMoreLine = true;
				}
				else
				{
					m_blnHaveMoreLine = false;
				}
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();
				m_blnHaveMoreLine = true;
				m_blnIsFirstPrint = true;
			}
		}
		#endregion
		#region 患者(家属)签名
		/// <summary>
		///  患者(家属)签名
		/// </summary>
		private class clsPrintInPatMedDoctorAndDate1 : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			private Font m_fontItemMidHead = new Font("",12,FontStyle.Bold);
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private bool blnNextPage = true;
            private string[] m_strKeysArr01 = { "患者(家属)签名" };
			private string[] m_strKeysArr101 = {"\n                                                                                                         患者(家属)签名："};

            private string[] m_strKeysArr02 = { "日期1" };
			private string[] m_strKeysArr102 = {"\n                                                                                                         日 期："};
	


 
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_objContent == null|| m_objContent.m_objItemContents == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				
				//				if(blnNextPage)
				//				{
				//					//另起一页打印，利用打印时检测p_intPosY是否大于最底边的值的判断来实现
				//					m_blnHaveMoreLine = true;
				//					blnNextPage = false;
				//					p_intPosY += 1500;
				//					return;
				//				}
				if(m_blnIsFirstPrint)
				{
					//					p_objGrp.DrawString("神经系统检查",m_fotItemHead,Brushes.Black,m_intRecBaseX+310,p_intPosY);
					//					p_intPosY += 20;
					//					p_objGrp.DrawString("一般情况",m_fontItemMidHead,Brushes.Black,m_intRecBaseX,p_intPosY);
					//					p_intPosY += 20;
					string strAllText = "";
					string strXml = "";
					string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
					if(m_objContent!=null)
					{
						m_mthMakeText(new string[]{"     术前患者(或家属、单位领导)意见及签名如下：我(或家属、单位领导)已认真看过以上告知内容，医生已作过详细解释，我完全理解，经慎重考虑，我(或家属、单位领导)决定：自愿接受手术治疗。"},new string[]{""},ref strAllText,ref strXml);


						if(m_blnHavePrintInfo(m_strKeysArr01) != false)
							m_mthMakeText(m_strKeysArr101,m_strKeysArr01,ref strAllText,ref strXml);
						else
							m_mthMakeText(m_strKeysArr101,new string[]{""},ref strAllText,ref strXml);

						if(m_blnHavePrintInfo(m_strKeysArr02) != false)
							m_mthMakeText(m_strKeysArr102,m_strKeysArr02,ref strAllText,ref strXml);
			
			
								
					}
					else
					{
						m_blnHaveMoreLine = false;
						return;
					}
					m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText,strXml,m_dtmFirstPrintTime,m_objContent.m_objItemContents!= null);
					m_mthAddSign2("检查者签字",m_objPrintContext.m_ObjModifyUserArr);
					m_blnIsFirstPrint = false;					
				}

				int intLine = 0;
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2,m_intRecBaseX+10,p_intPosY,p_objGrp);
					p_intPosY += 20;
				}
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					m_blnHaveMoreLine = true;
				}
				else
				{
					m_blnHaveMoreLine = false;
				}
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();
				m_blnHaveMoreLine = true;
				m_blnIsFirstPrint = true;
			}
		}
		#endregion
	}
}
