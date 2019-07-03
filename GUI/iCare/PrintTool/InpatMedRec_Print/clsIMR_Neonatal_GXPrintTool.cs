using System;
using System.IO;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;
using System.Windows.Forms;
using System.Resources ;
using com.digitalwave.PatientManagerService; 

namespace iCare 
{
	/// <summary>
	/// 按新规范
	/// 新生儿科科住院病历打印工具类.
	/// </summary>
	public class clsIMR_Neonatal_GXPrintTool: clsInpatMedRecPrintBase
	{
		public clsIMR_Neonatal_GXPrintTool(string p_strTypeID) :base(p_strTypeID)
		{
			//
			// TODO: Add constructor logic here
			//
		}
		private clsPrintInPatMedRecItem[] m_objPrintOneItemArr;
		private clsPrintInPatMedRecItem[] m_objPrintMultiItemArr;
		private clsPrintInPatMedRecSign[] m_objPrintSignArr;



		/// <summary>
		/// 标题文字部分
		/// </summary>
		/// <param name="e"></param>
		protected override void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
		{			            
			Font m_fotTitleFont;
			/// <summary>
			/// 表内容的字体(11)
			/// </summary>
			Font m_fotSmallFont;
				/// <summary>
			/// 刷子
			/// </summary>
			SolidBrush m_slbBrush;

			m_fotTitleFont = new Font("SimSun", 16,FontStyle.Bold);
			m_fotSmallFont = new Font("SimSun",12);
			m_slbBrush = new SolidBrush(Color.Black);
			

			e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle,m_fotSmallFont ,m_slbBrush,310,40);		
			e.Graphics.DrawString("新 生 儿 住 院 记 录",m_fotTitleFont,m_slbBrush,280,70);
		     

			e.Graphics.DrawString("科室：",m_fotSmallFont,m_slbBrush,50,110);
			e.Graphics.DrawString( this.m_objPrintInfo.m_strDeptName,m_fotSmallFont,m_slbBrush,100,110);
	
			e.Graphics.DrawString("床号：",m_fotSmallFont,m_slbBrush,350,110);
			e.Graphics.DrawString(m_objPrintInfo.m_strBedName,m_fotSmallFont,m_slbBrush,400,110);

			//			e.Graphics.DrawString("科室：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Dept_Name_Title ));
			//			e.Graphics.DrawString(m_objPrintInfo.m_strDeptName ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Dept_Name ));
			//
			//			e.Graphics.DrawString("床号：",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.BedNo_Title ));
			//			e.Graphics.DrawString(m_objPrintInfo.m_strBedName ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.BedNo ));	
		
			e.Graphics.DrawString("住院号：",m_fotSmallFont,m_slbBrush,630,110);
			e.Graphics.DrawString(m_objPrintInfo.m_strInPatientID ,m_fotSmallFont,m_slbBrush,700,110);	
		}
		protected override void m_mthSetPrintLineArr()
		{

			m_mthInitPrintLineArr();
			m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
				new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
																		   new clsPrintPatientFixInfo(),
																		   m_objPrintMultiItemArr[0],
																		   m_objPrintMultiItemArr[1],
																		   m_objPrintMultiItemArr[2],m_objPrintMultiItemArr[3],m_objPrintMultiItemArr[4],
																		   m_objPrintMultiItemArr[5],m_objPrintMultiItemArr[6],m_objPrintMultiItemArr[7],
																		   m_objPrintMultiItemArr[8],m_objPrintMultiItemArr[9],m_objPrintMultiItemArr[10],
																		   m_objPrintMultiItemArr[11],m_objPrintMultiItemArr[12],m_objPrintMultiItemArr[13],
																		   m_objPrintMultiItemArr[14],m_objPrintMultiItemArr[15],m_objPrintMultiItemArr[16],
																		   m_objPrintMultiItemArr[17],m_objPrintMultiItemArr[18],m_objPrintMultiItemArr[19],
																		   m_objPrintMultiItemArr[20],m_objPrintMultiItemArr[21],m_objPrintMultiItemArr[22],
																		   m_objPrintMultiItemArr[23],m_objPrintMultiItemArr[24],m_objPrintMultiItemArr[25],new clsPrintSubInf(),
																		   m_objPrintMultiItemArr[26],m_objPrintMultiItemArr[27],
																		  m_objPrintSignArr[0],m_objPrintOneItemArr[5], m_objPrintSignArr[1],  m_objPrintOneItemArr[6],  m_objPrintSignArr[2]
																	   });
		}
	
		private void m_mthInitPrintLineArr()
		{
			m_objPrintOneItemArr = new clsPrintInPatMedRecItem[7];
			for(int i1=0;i1<m_objPrintOneItemArr.Length;i1++)
				m_objPrintOneItemArr[i1] = new clsPrintInPatMedRecItem();

			m_objPrintMultiItemArr = new clsPrintInPatMedRecItem[28];
			for(int j2=0;j2<m_objPrintMultiItemArr.Length;j2++)
				m_objPrintMultiItemArr[j2] = new clsPrintInPatMedRecItem();

			m_objPrintSignArr = new clsPrintInPatMedRecSign[3];
			for(int k3=0;k3<m_objPrintSignArr.Length;k3++)
				m_objPrintSignArr[k3] = new clsPrintInPatMedRecSign();
		}
		#region 打印第一页的固定内容
		/// <summary>
		/// 打印第一页的固定内容
		/// </summary>
		internal class clsPrintPatientFixInfo : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				#region
				com.digitalwave.controls.ctlRichTextBox m_txtTemp=new ctlRichTextBox(); 
             	clsInpatMedRec_Item[] m_strMotherName=new clsInpatMedRec_Item[1];
				
				m_strMotherName=m_objGetContentFromItemArr(new string[]{"父母姓名","出院时间"});
              
				p_objGrp.DrawString("姓名："+ m_objPrintInfo.m_strPatientName,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
				p_objGrp.DrawString("记录日期："+(m_objContent==null ? "": m_objContent.m_dtmCreateDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmInPatientCaseHistory"))),p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);
						
				p_intPosY += 20;
				p_objGrp.DrawString("年龄："+(m_objPrintInfo==null ? "": m_objPrintInfo.m_strAge),p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);
				p_objGrp.DrawString("供史者和可靠程度："+(m_objContent==null ? "": m_objContent.m_strRepresentor+"," +m_objContent.m_strCredibility),p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
						
				p_intPosY += 20;
				p_objGrp.DrawString("性别："+ m_objPrintInfo.m_strSex ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);	
				p_objGrp.DrawString("籍贯："+ m_objPrintInfo.m_strNativePlace ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);			
				
				p_intPosY += 20;
				p_objGrp.DrawString("床号："+m_objPrintInfo.m_strAreaName+m_objPrintInfo.m_strBedName ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
				p_objGrp.DrawString("民族："+ m_objPrintInfo.m_strNationality,p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);
						
				p_intPosY += 20;
				p_objGrp.DrawString("邮政编码："+ m_objPrintInfo.m_StrHomePC,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
				p_objGrp.DrawString("联系电话："+ m_objPrintInfo.m_strHomePhone ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);
				
				p_intPosY += 20;
				if(m_objPrintInfo.m_dtmInPatientDate != System.DateTime.MinValue)
				{
				

					p_objGrp.DrawString("入院日期："+ m_objPrintInfo.m_dtmHISInDate.ToString("yyyy年MM月dd日 HH时"),p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);			
				}
				else
				{
					p_objGrp.DrawString("入院日期：",p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
				}				
							
				m_objPrintContext.m_mthSetContextWithAllCorrect("住址："+ m_objPrintInfo.m_strHomeAddress ,"<root />");
				int intRealHeight;
				Rectangle rtgBlock = new Rectangle(m_intPatientInfoX+350,p_intPosY,(int)enmRectangleInfo.RightX-(m_intPatientInfoX+350),30);
				m_objPrintContext.m_blnPrintAllBySimSun(11,rtgBlock,p_objGrp,out intRealHeight,false);

				p_intPosY += 20;
				if(m_strMotherName!=null)
				{
					if(m_strMotherName[0]!=null)
					{
						m_txtTemp.m_mthSetNewText(m_strMotherName[0].m_strItemContent,m_strMotherName[0].m_strItemContentXml);
						p_objGrp.DrawString("父/母姓名："+(m_strMotherName[0]!=null?m_txtTemp.m_strGetRightText().ToString():""),p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
					}
					else
					{
						p_objGrp.DrawString("父/母姓名：",p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
					}

				}
				else
				{
	                    p_objGrp.DrawString("父/母姓名：",p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
				}
				//设置出院日期
				DateTime m_dtmOutHospitalDate;
				m_lngGetOutDate(m_objPrintInfo.m_strInPatientID,m_objPrintInfo.m_dtmHISInDate,out m_dtmOutHospitalDate);
				if(m_dtmOutHospitalDate == new DateTime(1900,1,1) || m_dtmOutHospitalDate == DateTime.MinValue)
					   p_objGrp.DrawString("出院日期：",p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);
				else
				{
					   p_objGrp.DrawString("出院日期："+m_dtmOutHospitalDate.ToString("yyyy年MM月dd日 HH时"),p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);			
				}  	

				m_blnHaveMoreLine = false;
				#endregion
				//				p_objGrp.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle,m_fotItemHead ,Brushes.Black,340,45);
				//		
				//				p_objGrp.DrawString("药 物 流 产 记 录 表",new Font("SimSun", 16,FontStyle.Bold),Brushes.Black,330,75);
				//				p_intPosY =130;
			}
			/// <summary>
			/// 获取病人出院时间
			/// </summary>
			/// <returns></returns>
			private  void m_lngGetOutDate(string p_StrPatientID,DateTime m_DtmSelectedInDate,out DateTime p_dtmOutHospitalDate)
			{
				p_dtmOutHospitalDate = new DateTime(1900,1,1);
				string strRegisterID = "";
				long lngRes = 0;
                clsPatientManagerService objServ =
                (clsPatientManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPatientManagerService));

				lngRes = objServ.m_lngGetRegisterIDByPatient(p_StrPatientID, m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"), out strRegisterID);
				lngRes = objServ.m_lngGetOutHospitalDate(strRegisterID, out p_dtmOutHospitalDate);
				objServ = null;
				
			}
			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();

				m_blnHaveMoreLine = true;
			}
		}

		#endregion
	
		/// <summary>
		/// 把所有项按描述为键放入Hastable
		/// </summary>
		/// <param name="p_hasItem"></param>
		/// <param name="p_ctlItem"></param>
		/// <param name="p_objItemArr"></param>
		/// <returns></returns>
		protected override Hashtable m_mthSetHashItem(clsInpatMedRec_Item[] p_objItemArr)
		{
			if(p_objItemArr == null)
				return null;
			Hashtable hasItem = new Hashtable(300);
			foreach(clsInpatMedRec_Item objItem in p_objItemArr)
			{
				if(objItem.m_strItemContent == null || objItem.m_strItemContent == "" || objItem.m_strItemContent == "False")
					continue;
				try
				{
					hasItem.Add(objItem.m_strItemName,objItem);
				}
				catch
				{
					continue;
					//					string strEx = ex.ToString();
					//					hasItem = null;
				}
			}
			return hasItem;
		}
		
		protected override void m_mthSetSubPrintInfo()
		{
			#region 抬头信息
			m_objPrintMultiItemArr[0].m_mthSetPrintValue(new string[]{"tt","tt"},
				new string[]{"tt","tt"});
		
			#endregion

			#region 单个项目
			//m_objPrintOneItemArr[0].m_mthSetPrintValue("入院诊断","入院诊断：");
			//m_objPrintOneItemArr[1].m_mthSetPrintValue("出院诊断","出院诊断：");
			//m_objPrintOneItemArr[2].m_mthSetPrintValue("主诉","主诉：");
			//m_objPrintOneItemArr[3].m_mthSetPrintValue("现病史","现病史：");
			
			
		
			#endregion	

			#region 病史记录
	
			m_objPrintMultiItemArr[0].m_mthSetPrintValue(new string[]{
																		 "入院诊断",
																		 "出院诊断",
                                                                         "主诉",
																		 "现病史",
																		 "既往史>>胎儿期情况",
																		 "既往史>>生后患病情况",
				                                                
																		 },
				new string[]{
								"\n 入院诊断：",
								"\n 出院诊断：",
								"\n 主诉：",
								"\n 现病史：",
								"\n既往史：1.胎儿期情况：",
								"\n                  2.生后患病情况：",
								
							});
			#endregion
			#region 出生史
			//m_objPrintMultiItemArr[1].m_mthSetSpecialTitleValue("个人史"); 
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{
																		 "",
																		 "",
																		 "",
																		 "出生史>>胎",
																		 "",
																		 "",
																		 "出生史>>产",
																		 "",
																		 "",
																		 "出生史>>胎龄",
																		 "",
																		 "",
																		 "出生史>>出生体重",
																		 "",
																		 "出生史>>单胎",
																		 "出生史>>双胎",
																		 "出生史>>大",
																		 "出生史>>小",
																		 "出生史>>出生时间",
																		 "",
																		 "出生史>>宫内窘迫>>有",
																		 "出生史>>宫内窘迫>>无",
																		 "",
																		 "出生史>>胎膜早破时间",
																		 ""			 },
				new string[]{
								"个人史：",
								"\n1.出生史：",
								"第(",
								"",
								"）胎；$$",
								"（",
								"",
								"）产；$$",
								"胎龄（",
								"",
								"）周；$$",
								"出生时体重（",
								"",
								"）克；$$",
								"#单胎$$",
								"#双胎$$",
								"#大；$$",
								"#小；$$",
								"\n                  出生时间：",
								"",
				                "#宫内窘迫：有",
				                "#宫内窘迫：无",
				                "胎膜早破（",
				                "",
				                "）小时；$$"
								});

			m_objPrintMultiItemArr[2].m_mthSetPrintValue(new string[]{	"",
																		 "出生史>>分娩方式>>顺产",
																		 "出生史>>分娩方式>>剖宫产",
																		 "出生史>>分娩方式>>吸引产",
																		 "出生史>>分娩方式>>低中位产钳产",
																		 "出生史>>分娩方式>>臀位产",
																		 "出生史>>分娩方式>>其它",
																		 "出生史>>分娩方式>>其它描述",
																		 "",
																		 "出生史>>羊水量",
																		 "",
																		 "出生史>>羊水>>量>>正常",
																		 "出生史>>羊水>>量>>过多",
																		 "出生史>>羊水>>量>>过少",
																		 "出生史>>羊水>>量>>清",
																		 "出生史>>羊水>>量>>浑浊",
																		 "出生史>>羊水>>量>>胎粪样",
																		 "出生史>>羊水>>量>>其它",
																		 "",
																		 "出生史>>胎盘>>无异常",
																		 "钙化",
																		 "出生史>>胎盘>>早剥",
																		 "出生史>>胎盘>>前置",
																		 "",
																		 "出生史>>脐带长",
																		 "",
																		 "",
																		 "出生史>>绕颈周数",
																		 "",
																		 "出生史>>胎盘>.其它"	 },
				new string[]{
								"                  分娩方式：",//另起
								"#顺产",
								"#破宫产",
								"#吸引产",
								"#低/中位产钳产",
								"#臀位产",
								"#其它",
								"",
								"\n                  羊水：量（",
								"",
								"）ML；$$",
								"#正常",
								"#过多",
								"#过少",
								"#清",
								"#浑浊",
								"#胎粪样",
								"其它：",
								"\n                  ",
								"#胎盘：无异常",
								"#胎盘：钙化",
								"#胎盘：早剥",
								"#胎盘：前置",
								"脐带：长（",
				                "",
				                "）cm；$$",
				                "绕颈（",
				                "",
				                "）周；$$",
				                "其它："
                       	});
			m_objPrintMultiItemArr[3].m_mthSetPrintValue(new string[]{	"",
																		 "",
																		 "出生史>>Apgar评分>>1min",
																		 "",
																		 "",
																		 "出生史>>Apgar评分>>5min",
																		 "",
																		 "",
																		 "出生史>>Apgar评分>>10min",
																		 "",
																		 "",
																		 "出生史>>Apgar评分>>15min",
																		 "",
																		 "",
																		 "出生史>>Apgar评分>>复苏时间",
																		 "",
																		 "",
																		 "出生史>>出生时抢救情况>>无",
																		 "出生史>>出生时抢救情况>>有",
																		 "",
																		 "出生史>>出生时抢救情况>>气管插管>>有",
																		 "出生史>>出生时抢救情况>>气管插管>>无",
																		 "",
																		 "出生史>>出生时抢救情况>>吸出粘液数量",
																		 "",
																		 "出生史>>出生时抢救情况>>吸出粘液颜色",
																		 "",
																		 "出生史>>出生时抢救情况>>粘液性质>>血性",
																		 "出生史>>出生时抢救情况>>粘液性质>>粘液",
																		 "出生史>>出生时抢救情况>>粘液性质>>胎粪样",
																		 "出生史>>出生时抢救情况>>抢救用药情况",
																		 "出生史>>目亲分娩时用药情况" },
				new string[]{
								"                  Apgar评分：",
								"1min（",
								"",
								"）分；$$",
								"5min（",
								"",
								"）分；$$",
								"10min（",
								"",
								"）分；$$",
								"15min（",
								"",
								"）分；$$",
								"经（",
								"",
								"）小时后复苏；$$",
								"\n                  出生时抢救情况：",
								"#出生时抢救情况：无",
								"#出生时抢救情况：有",
								"",
								"#气管插管：有",
								"#气管插管：无",
								"吸出粘液（",
								"",
								"）ml；$$",
								"颜色：",
								"",
								"#性质：血性",
								"#性质：粘液",
								"#性质：胎粪样",
								"抢救用药情况：",
								"\n                 分娩时母亲用药情况：镇静剂（产前4小时）或麻醉剂(药名）："
								
							});
			#endregion
			#region 喂养史
			m_objPrintMultiItemArr[4].m_mthSetPrintValue(new string[]{	
																		 "",
																		 "",
																		 "喂养史>>开奶时间",
																		 "",
																		
																		 "喂养史>>喂养方式>>母乳",
																		 "喂养史>>喂养方式>>人工",
																		 "喂养史>>喂养方式>>混合"
																		  },
				new string[]{
								"2.喂养史：",
								"开奶时间：生后（",
								"",
								"）小时；$$",
								
								"#喂养方式：母乳",
								"#喂养方式：人工",
								"#喂养方式：混合"
								
							});

			#endregion
			#region 预防接种史
			m_objPrintMultiItemArr[5].m_mthSetPrintValue(new string[]{	
																		 "",
																		 "预防接种史>>卡介苗>>已种",
																		 "预防接种史>>卡介苗>>未种",
																	     "预防接种史>>乙肝疫苗>>已种",
				                                                         "预防接种史>>乙肝疫苗>>未种"
			},
				new string[]{
								"3.预防接种史：",
								"#卡介苗：已种",
								"#卡介苗：未种",
                                "#乙肝疫苗：已种",
							    "#乙肝疫苗：未种"
							});

			#endregion

			#region 家族史
	
			m_objPrintMultiItemArr[6].m_mthSetPrintValue(new string[]{	
																		 "",
																		 "家族史>>父亲>>年龄",
																		 "",
																		 "家族史>>父亲>>职业",
																		 "家族史>>父亲>>平日健康状况",
																		 "家族史>>父亲>>血型",
																		 "",
																		 "家族史>>母亲>>年龄",
																		 "",
																		 "家族史>>母亲>>职业",
																		 "家族史>>母亲>>平日健康状况",
																		 "家族史>>母亲>>血型",
																		 "",
																		 "家族史>>母亲孕期健康情况>>无异常",
																		 "家族史>>母亲孕期健康情况>>有异常疾病",
																		 "家族史>>母亲孕期健康情况>>妊娠水肿",
																		 "家族史>>母亲孕期健康情况>>妊娠糖尿病",
																		 "家族史>>母亲孕期健康情况>>妊娠高血压",
																		 "家族史>>母亲孕期健康情况>>蛋白尿",
																		 "家族史>>母亲孕期健康情况>>惊厥",
																		 "家族史>>母亲孕期健康情况>>孕期细菌病毒感染",
																		 "家族史>>母亲孕期健康情况>>心脏病",
																		 "家族史>>母亲孕期健康情况>>肾脏病",
																		 "家族史>>母亲孕期健康情况>>糖尿病",
																		 "家族史>>母亲孕期健康情况>>血液病",
																		 "家族史>>母亲孕期健康情况>>贫血",
																		 "家族史>>母亲孕期健康情况>>肝病",
																		 "家族史>>母亲孕期健康情况>>癫痫",
																		 "家族史>>母亲孕期健康情况>>其它",
																		 "家族史>>母亲孕期健康情况>>其它描述",
																		 "家族史>>孕期用药情况",
																		 "",
																		 "",
																		 "家族史>>兄姐情况>>人工流产次数",
																		 "",
																		 "",
																		 "家族史>>兄姐情况>>自然流产次数",
																		 "",
																		 "家族史>>兄姐情况>>死胎",
																		 "家族史>>兄姐情况>>死产",
																		 "家族史>>兄姐情况>>早产",
																		 "",
																		 "家族史>>兄姐情况>>现有兄数",
																		 "",
																		 "家族史>>兄姐情况>>现有姐数",
																		 "",
																		 "",
																		 "家族史>>兄姐情况>>溶血史>>有",
																		 "家族史>>兄姐情况>>溶血史>>无",
																		 "",
																		 "家族史>>兄姐情况>>出血史>>有",
																		 "家族史>>兄姐情况>>出血史>>无",
																		 "",
																		 "家族史>>兄姐情况>>畸胎史>>有",
																		 "家族史>>兄姐情况>>畸胎史>>无",
																		 "",
																		 "家族史>>父母近亲结婚>>有",
																		 "家族史>>父母近亲结婚>>无",
																		 "家族史>>家族遗传病史"		           
																	 },
				new string[]{
								"家族史：父亲：年龄（",
								"",
								"）岁；$$",
								"职业：",
								"平日健康状况：",
								"血型：",
								"\n                  母亲：年龄（",
								"",
								"）岁；$$",
								"职业：",
								"平日健康状况：",
								"血型：",
								"\n                  母亲孕期健康情况：",
								"#无异常",
						    	"#有异常疾病",
				                "\n                  妊娠水肿",
				                "#妊娠糖尿病",
				"#妊娠高血压；",
				"#蛋白尿；",
				"#惊厥；",
				"#孕期细菌病毒感染；",
				"#心脏病；",
				"#肾脏病；",
				"#糖尿病；",
				"#血液病；",
				"#贫血；",
				"#肝病；",
				"#癫痫；",
				"#其它；",
				"描述(其它):",
				"\n                  孕期用药情况：",
				"\n                  兄姐情况：",
				"人工流产（",
				"",
				"）次；$$",
								"自然流产（",
								"",
								"）次；$$",
				"死胎：",
				"死产：",
				"早产：",
				"\n                  现有（",
				"",
				"）兄；（$$",
				"",
                "）姐；$$",
				"",
				"#融血史：有",
				"#融血史：无",
								"",
								"#出血史：有",
								"#出血史：无",
								"",
								"#畸胎史：有",
								"#畸胎史：无",
								"",
								"#\n                  父母近亲结婚：有",
								"#\n                  父母近亲结婚：无",
								"\n                  家族遗传病史："
		        
							});

			#endregion

			#region 测量记录
			m_objPrintMultiItemArr[7].m_mthSetSpecialTitleValue("体格检查"); 
			m_objPrintMultiItemArr[7].m_mthSetPrintValue(new string[]{	
																		 "",
																		 "",
																		 "体格检查>>测量记录>>体温",
																		 "",
																		 "",
																		 "体格检查>>测量记录>>脉搏",
																		 "",
																		 "",
																		 "体格检查>>测量记录>>呼吸",
																		 "",
																		 "",
																		 "体格检查>>测量记录>>血压",
																		 "",
																		 "",
																		 "体格检查>>测量记录>>体重",
																		 "",
																		 "",
																		 "体格检查>>测量记录>>头围",
																		 "",
																		 "",
																		 "体格检查>>测量记录>>胸围",
																		 "",
																		 "",
																		 "体格检查>>测量记录>>腹围",
																		 "",
																		 "",
																		 "体格检查>>测量记录>>身长",
																		 ""

																	 },
				new string[]{
								"测量记录：",
								"体温（",
								"",
								"）℃；$$",
								"脉搏（",
								"",
								"）次/分；$$",

								"呼吸（",
								"",
								"）次/分；$$",

								"血压（",
								"",
								"）mmHg；$$",
								"体重（",
								"",
								"）克；$$",

								"\n                    头围（",
								"",
								"）cm；$$",

								"胸围（",
								"",
								"）cm；$$",
								"腹围（",
								"",
								"）cm；$$",
								"身长（",
								"",
								"）cm；$$"
							});

			#endregion
			#region 体格检查(一般情况)
			m_objPrintMultiItemArr[8].m_mthSetPrintValue(new string[]{	
                                                                         "",
																		 "体格检查>>一般情况>>外貌",
																		 "体格检查>>一般情况>>面色",
																		 "体格检查>>一般情况>>哭声",
																		 "体格检查>>一般情况>>精神反应：",
																		 "体格检查>>一般情况>>神志",
																		 "体格检查>>一般情况>>呻吟",
																		 "体格检查>>一般情况>>三凹征",
																		 "",
																		 "体格检查>>一般情况>>营养状况>>优良",
																		 "体格检查>>一般情况>>营养状况>>中等",
																		 "体格检查>>一般情况>>营养状况>>不良",
																		 "体格检查>>一般情况>>营养状况>>不良1",
																		 "体格检查>>一般情况>>营养状况>>不良2",
																		 "体格检查>>一般情况>>营养状况>>不良3",
																		 ""

																	 },
				new string[]{
								"一般情况：",
								"外貌：",
								"面色：",
							    "哭声：",
								"精神反应：",
							    "神志：",
							    "\n                    呻吟：",
							    "三凹征：",
						        "",
								"#营养状况：优良",
								"#营养状况：中等",
								"#营养状况：不良（",
								"#Ⅰ°)",
								"#Ⅱ°)",
								"#Ⅲ°)",
								""
							});

			#endregion
			#region 皮肤粘膜
			m_objPrintMultiItemArr[9].m_mthSetPrintValue(new string[]{	
																		 "",
																		 "体格检查>>皮肤粘膜>>颜色",
																		 "体格检查>>皮肤粘膜>>皮疹",
																		 "体格检查>>皮肤粘膜>>出血及淤斑",
																		 "体格检查>>皮肤粘膜>>水肿",
																		 "体格检查>>皮肤粘膜>>硬肿",
																		 "体格检查>>皮肤粘膜>>弹性",
																		 "体格检查>>皮肤粘膜>>黄疸情况",
																	
																		 "体格检查>>皮肤粘膜>>肢体皮肤温度>>灼热",
																		 "体格检查>>皮肤粘膜>>肢体皮肤温度>>温暖",
																		 "体格检查>>皮肤粘膜>>肢体皮肤温度>>冰凉",
																		 "体格检查>>皮肤粘膜>>脱皮"
																		 

																	 },
				new string[]{
								"皮肤粘膜：",
								"颜色：",
								"皮疹：",
								"出血及淤斑：",
								"水肿：",
								"\n                    硬肿：",
								"弹性：",
								"黄疸情况：",
								
								"#\n                  肢体皮肤温度：灼热",
								"#\n                  肢体皮肤温度：温暖",
								"#\n                  肢体皮肤温度：冰凉",
								"脱皮："
							});

			#endregion
			#region 淋巴结
			m_objPrintMultiItemArr[10].m_mthSetPrintValue(new string[]{	
																		  "",
																		  "体格检查>>淋巴结>>无浅表淋巴结肿大",
																		  "体格检查>>淋巴结>>有浅表淋巴结肿大",
																		  "体格检查>>淋巴结>>浅表淋巴结肿大部位"
																	 },
				new string[]{ "淋巴结：",
								"#浅表淋巴结肿大：无",
								"#浅表淋巴结肿大：有",
								"部位："
								
							});

			#endregion
			#region 头部
			m_objPrintMultiItemArr[11].m_mthSetPrintValue(new string[]{	
																		  "",
																		  "体格检查>>头部>>形态正常",
																		  "体格检查>>头部>>形态畸形",
																		  "",
																		  "体格检查>>头部>>前囟",
																		  "",
																		  "体格检查>>头部>>前囟隆起",
																		  "体格检查>>头部>>前囟平坦",
																		  "体格检查>>头部>>前囟凹陷",
																		  "",
																		  "体格检查>>头部>>后囟",
																		  "",
																		  "体格检查>>头部>>骨缝",
																		  "体格检查>>头部>>有颅骨软化",
																		  "体格检查>>头部>>无颅骨软化",
																		  "体格检查>>头部>>颅骨软化部位",
																		  "",
																		  "体格检查>>头部>>颅骨软化范围",
																		  "",
																		  "体格检查>>头部>>毛发",
																		  "体格检查>>头部>>有水肿",
																		  "体格检查>>头部>>无水肿",
																		  "体格检查>>头部>>水肿部位",
																		  "",
																		  "体格检查>>头部>>水肿范围",
																		  "",
																		  "体格检查>>头部>>水肿其它"
								

																	  },
				new string[]{ "头部：形态：",
								"#正常",
								"#畸形",
								"前囟（",
								"",
				                "）cm；$$",
								"#隆起",
								"#平坦",
								"#凹陷",
								"后囟（",
								"",
								"）cm；$$",
				     			"\n             骨缝：",
				                "#颅骨软化：有",
								"#颅骨软化：无",
								
				"部位：",
				"范围（",
				"",
				"）cm；$$",
				"毛发：",
				"#\n                  水肿：有",
			    "#\n                  水肿：无",
			
								"部位：",
								"范围（",
								"",
								"）cm；$$",
				"其它："
								

				
							});

			#endregion
			#region 眼
			m_objPrintMultiItemArr[12].m_mthSetPrintValue(new string[]{	
																		  "",
																		  "体格检查>>眼>>结膜正常",
																		  "体格检查>>眼>>充血",
																		  "体格检查>>眼>>出血",
																		 
																		  "体格检查>>眼>>有分泌物",
																		  "体格检查>>眼>>无分泌物",
																		
																		  "体格检查>>眼>>瞳孔正常",
																		  "体格检查>>眼>>瞳孔散大",
																		  "体格检查>>眼>>瞳孔缩小",
																		  "体格检查>>眼>>瞳孔不对称",
																		 
																		  "体格检查>>眼>>对光反射正常",
																		  "体格检查>>眼>>对光反射迟钝",
																		  "体格检查>>眼>>对光反射消失",
																		
																		  "体格检查>>眼>>眼球正常",
																		  "体格检查>>眼>>眼球震颤",
																		  "体格检查>>眼>>眼球突出",
																		  "体格检查>>眼>>眼球凝视",
																		  
																		  "体格检查>>眼>>巩膜正常",
																		  "体格检查>>眼>>黄染",
																		
																		  "体格检查>>眼>>角膜正常",
																		  "体格检查>>眼>>角膜混浊",
																		  "体格检查>>眼>>角膜溃疡",
																		  "体格检查>>眼>>其它"

																	  },
				new string[]{ "    眼：",
								"#结膜：正常",
								"#结膜：充血",
								"#结膜：出血",
								
								"#分泌物：有",
								"#分泌物：无",
								
								"#瞳孔：正常",
								"#瞳孔：散大",
								"#瞳孔：缩小",
								"#瞳孔：不对称",
								
								"#\n             对光反射：正常；",
								"#\n             对光反射：迟钝；",
								"#\n             对光反射：消失；",
								
								"#眼球：正常",
								"#眼球：震颤",
								"#眼球：突出",
								"#眼球：凝视",
								"#\n             巩膜：正常",
								"#\n             巩膜：黄染",
								"#角膜：正常",
								"#角膜：混浊",
								"#角膜：溃疡",
								"其它："
								

				
							});

			#endregion
			#region 耳
			m_objPrintMultiItemArr[13].m_mthSetPrintValue(new string[]{	
																		  "",
																		  "体格检查>>耳>>外耳正常",
																		  "体格检查>>耳>>外耳畸形",
																		  
																		  "体格检查>>耳>>耳廓发育好",
																		  "体格检查>>耳>>耳廓发育一般",
																		  "体格检查>>耳>>耳廓发育差",
																	
																		  "体格检查>>耳>>有耳分泌物",
																		  "体格检查>>耳>>无耳分泌物",
																		  "体格检查>>耳>>低耳位"

																	  },
				new string[]{
								"\n    耳：",
								"#外耳：正常；",
								"#外耳：畸形；",
								
								"#耳廓发育：好；",
								"#耳廓发育：一般；",
								"#耳廓发育：差；",
								
								"#耳分泌物：有；",
								"#耳分泌物：无；",
								"#低耳位；"
								
							});

			#endregion
			#region 鼻
			m_objPrintMultiItemArr[14].m_mthSetPrintValue(new string[]{	
																		  "",
																		  "体格检查>>鼻>>外部正常",
																		  "体格检查>>鼻>>外部畸形",
																		  "",
																		  "体格检查>>鼻>>有鼻扇",
																		  "体格检查>>鼻>>无鼻扇",
																		  "",
																		  "体格检查>>鼻>>有鼻分泌物",
																		  "体格检查>>鼻>>无鼻分泌物"
								
																	  },
				new string[]{
								"    鼻：外部：",
								"#正常",
								"#畸形",
								"鼻扇：",
								"#有",
								"#无",
								"鼻分泌物：",
								"#有",
								"#无"
								
							});

			#endregion
			#region 口
			m_objPrintMultiItemArr[14].m_mthSetPrintValue(new string[]{	
																		  "",
																		  "体格检查>>口>>口周正常",
																		  "体格检查>>口>>口周发绀",
								
																		  "体格检查>>口>>口唇红润",
																		  "体格检查>>口>>口唇青紫",
																		  "体格检查>>口>>口唇苍白：",
																		  "体格检查>>口>>口唇干燥",
																		  "体格检查>>口>>粘膜",
																		  "体格检查>>口>>咽腭部"
																	  },
				new string[]{
								"\n    口：",
								"#口周：正常；",
								"#口周：发绀；",
								
								"#口唇：红润；",
								"#口唇：青紫；",
								"#口唇：苍白；",
								"#口唇：干燥；",
								"粘膜：$$",
								"咽腭部："
								
							});

			#endregion
			#region 颈部
			m_objPrintMultiItemArr[14].m_mthSetPrintValue(new string[]{	
																		  "",
								
																		  "体格检查>>颈部>>有畸形",
																		  "体格检查>>颈部>>无畸形",
																		  
																		  "体格检查>>颈部>>有抵抗",
																		  "体格检查>>颈部>>无抵抗",
																		  
																		  "体格检查>>颈部>>甲状腺肿大>>有",
																		  "体格检查>>颈部>>甲状腺肿大>>无",
																		  "体格检查>>颈部>>其它"								  },
				new string[]{
								"\n颈部：",
								
								"#畸形：有",
								"#畸形：无",
								
								"#抵抗：有",
								"#抵抗：无",
								
								"#甲状腺肿大：有",
								"#甲状腺肿大：无",
								"其它"
								
							});

			#endregion
			#region 胸部
			m_objPrintMultiItemArr[15].m_mthSetPrintValue(new string[]{	
																		  "",
																		  
																		  "体格检查>>颈部>>有畸形",
																		  "体格检查>>颈部>>无畸形",
																		  
																		  "体格检查>>颈部>>有抵抗",
																		  "体格检查>>颈部>>无抵抗",
								
																		  "体格检查>>颈部>>甲状腺肿大>>有",
																		  "体格检查>>颈部>>甲状腺肿大>>无",
                                                                          "体格检查>>颈部>>其它"
																	  },
				new string[]{
								"胸部：",
								
								"#胸廓畸形：有；",
								"#胸廓畸形：无；",
								
								"#双侧呼吸活动：对称；",
								"#双侧呼吸活动：不对称；",
								
								"#锁骨骨折：有",
								"#锁骨骨折：无",
				                "其它："
								
							});

			#endregion
			#region 肺部
			m_objPrintMultiItemArr[16].m_mthSetPrintValue(new string[]{	
																		  "",
																		  "",
																	
																		  "体格检查>>视诊>>双肺呼吸活动>>对称",
																		  "体格检查>>视诊>>双肺呼吸活动>>不对称：",
																		  "",
																		  "体格检查>>视诊>>呼吸方式>>胸式",
																		  "体格检查>>视诊>>呼吸方式>>腹式",
																		  "",
																		  "",
																		  "体格检查>>触诊>>双肺触觉语颤>>对称",
																		  "体格检查>>触诊>>双肺触觉语颤>>不对称",
																		  "",
																		  "体格检查>>叩诊>>清音",
																		  "体格检查>>叩诊>>过清音",
																		  "体格检查>>叩诊>>浊音",
																		  "体格检查>>叩诊>>实音",
																		  "体格检查>>叩诊>>实音",
																		  "",
																		  "",
																		  "体格检查>>听诊>>双肺呼吸音>>对称",
																		  "体格检查>>听诊>>不对称",
																		  "",
																		  "体格检查>>听诊>>强度 >>增强",
																		  "体格检查>>听诊>>强度 >>减弱",
																		  "",
																		  "体格检查>>听诊>>强度 >>有啰音",
																		  "体格检查>>听诊>>强度 >>无啰音",
																		  "体格检查>>听诊>>强度 >>部位及性质"
				
																	  },
				new string[]{
								"    肺：",
								"视诊：",
								
								"#双肺呼吸活动：对称",
								"#双肺呼吸活动：不对称：",
								"",
								"#呼吸方式：胸式",
								"#呼吸方式：腹式",
								"\n             触诊：",
								"双肺触觉语颤：",
								"#对称",
								"#不对称：",
								"\n             扣诊：",
								"#清音",
								"#过清音",
                                "#浊音",
								"#实音",
								"实音描述：",
								"\n             听诊：",
				"",
				"#双肺呼吸音：对称",
				"#双肺呼吸音：不对称",
				"",
				"#强度：增强",
				"#强度：减弱",
				"",
				"#啰音：有",
				"#啰音：无",
				"\n                         部位及性质："
				                 
							});

			#endregion
			#region 心脏--视诊+触诊
			m_objPrintMultiItemArr[17].m_mthSetPrintValue(new string[]{	
                                                                          "",
																		  "",
																		  "",
																		  "体格检查>>心脏>>视诊>>心前区有隆起",
																		  "体格检查>>心脏>>视诊>>心前区无隆起",
																		  "",
																		  "",
																		  "体格检查>>心脏>>视诊>>心尖搏动位置",
																		  "",
																		  "体格检查>>心脏>>视诊>>强度增强",
																		  "体格检查>>心脏>>视诊>>强度减弱",
																		  "",
																		  "",
																		  "体格检查>>心脏>>触诊>>有心前区震颤",
																		  "体格检查>>心脏>>触诊>>无心前区震颤",
																		  "体格检查>>心脏>>触诊>>位置"
								
																	  },
				new string[]{
								"心脏：",
								"视诊：",
								"",
								"#心前区有隆起",
								"#心前区无隆起",
								"",
								"心尖搏动：",
								"位置：",
								"",
								"#强度：增强",
								"#强度：减弱",
								"\n             触诊",
				                "",
			                    "#心前区震颤：有",
			                    "#心前区震颤：无",
						        "位置："
						 		});

			#endregion
			#region 心脏--叩诊
			m_objPrintMultiItemArr[18].m_mthSetPrintValue(new string[]{	
																		  "",
																		  "",
																		  "体格检查>>心脏>>叩诊>>左心界最远处左侧肋间",
																		  "",
																		  "体格检查>>心脏>>叩诊>>左心界最远处左锁骨内",
																		  "体格检查>>心脏>>叩诊>>左心界最远处左锁骨外",
																		  "",
																		  "体格检查>>心脏>>叩诊>>左心界最远处左锁骨距离",
																		  "",
																		  "",
																		  "体格检查>>心脏>>叩诊>>右心界最远处右侧肋间",
																		  "",
																		  "体格检查>>心脏>>叩诊>>右心界最远处右锁骨内",
																		  "体格检查>>心脏>>叩诊>>右心界最远处右锁骨外",
																		  "",
																		  "体格检查>>心脏>>叩诊>>右心界最远处右锁骨距离",
																		  ""
								
																	  },
				new string[]{
								"             叩诊：",
								"左心界最远处左侧第（",
								"",
								"）肋间左锁骨中线（$$",
								"#内$$",
								"#外$$",
								"）（$$",
								"",
								"）cm处；$$",
								"\n                          右心界最远处右侧第（",
								"",  
								"）肋间右锁骨中线（$$",
								"#内$$",
								"#外$$",
								"）（$$",
								"",
								"）cm处；$$"
								
							});

			#endregion
			#region 心脏--听诊
			m_objPrintMultiItemArr[19].m_mthSetPrintValue(new string[]{	
																		  "",
								            							  "",
																		  "体格检查>>心脏>>听诊>>心率",
																		  "",
																		  "",
																		  "体格检查>>心脏>>听诊>>心律齐",
																		  "体格检查>>心脏>>听诊>>心律不齐",
																		  "",
																		  "体格检查>>心脏>>听诊>>心音强",
																		  "体格检查>>心脏>>听诊>>心音弱",
																		  "",
																		  "体格检查>>心脏>>听诊>>有杂音",
																		  "体格检查>>心脏>>听诊>>无杂音",
																		  "体格检查>>心脏>>听诊>>杂音",
																	  },
				new string[]{
								"             听诊：",
								"心率(",
								"",
								"）次/分；$$",
								"",
								"#心律：齐",
								"#心律：不齐",
								"",
								"#心音：强",
								"#心音：弱",
								"",
								"#\n                          杂音：有",
								"#\n                          杂音：无",
								"杂音：",
								
							});

			#endregion
			#region 血管
			m_objPrintMultiItemArr[20].m_mthSetPrintValue(new string[]{	
																		  
																		  "",
																		  "",
																		  "体格检查>>血管>>股动脉搏动>>强",
																		  "体格检查>>血管>>股动脉搏动>>弱",
																		  "",
																		  "体格检查>>血管>>毛细血管充盈时间",
																		  ""
			},
				new string[]{
								"血管：",
								"",
								"#股动脉搏动：强",
								"#股动脉搏动：弱",
								"前臂内侧毛细血管充盈时间（",
								"",
								"）秒；$$"
								
			});

			#endregion
			#region 腹部
			m_objPrintMultiItemArr[21].m_mthSetPrintValue(new string[]{	
																		  
																		  "",
																		  "",
																		  "",
																		  "体格检查>>腹部>>视诊>>外形",
																		  "",
																		  "体格检查>>腹部>>视诊>>有肠形",
																		  "体格检查>>腹部>>视诊>>无肠形",
																		  "",
																		  "体格检查>>腹部>>视诊>>有蠕动波",
																		  "体格检查>>腹部>>视诊>>无蠕动波",
																		  "：",
																		  "体格检查>>腹部>>视诊>>脐带已脱",
																		  "体格检查>>腹部>>视诊>>脐带未脱",
																		  "",
																		  "体格检查>>腹部>>视诊>>脐部无异常",
																		  "体格检查>>腹部>>视诊>>脐轮红肿",
																		  "",
																		  "体格检查>>腹部>>视诊>>有分泌物",
																		  "体格检查>>腹部>>视诊>>无分泌物",
																		  "体格检查>>腹部>>视诊>>分泌物性质",
																		  "",
																		  "体格检查>>腹部>>视诊>>有脐疝",
																		  "体格检查>>腹部>>视诊>>无脐疝",
																		  "",
																		  "",
																		  "体格检查>>腹部>>触诊>>腹壁软",
																		  "体格检查>>腹部>>触诊>>腹壁紧张",
																		  "",
																		  "体格检查>>腹部>>触诊>>肝右肋下距离",
																		  "",
																		  "",
																		  "体格检查>>腹部>>触诊>>剑突下距离",
																		  "",
																		  "",
																		  "体格检查>>腹部>>触诊>>肝质地软",
																		  "体格检查>>腹部>>触诊>>肝质地中",
																		  "体格检查>>腹部>>触诊>>肝质地硬",
																		  "",
																		  "体格检查>>腹部>>触诊>>脾左肋下距离",
																		  "",
																		  "",
																		  "体格检查>>腹部>>触诊>>脾质地软",
																		  "体格检查>>腹部>>触诊>>脾质地中",
																		  "体格检查>>腹部>>触诊>>脾质地硬",
																		  "体格检查>>腹部>>触诊>>包块",
																		  "",
																		  "",
																		  "体格检查>>腹部>>叩诊>>有移动性浊音",
																		  "体格检查>>腹部>>叩诊>>无移动性浊音",
																		  "",
																		  "",
																		  "体格检查>>腹部>>听诊>>肠鸣音频率",
																		  "",
																		  "体格检查>>腹部>>叩诊>>肠鸣音>>正常",
																		  "体格检查>>腹部>>叩诊>>肠鸣音>>亢进",
																		  "体格检查>>腹部>>叩诊>>肠鸣音>>减弱",
																		  "体格检查>>腹部>>叩诊>>肠鸣音>>消失",
																	  },
				new string[]{
								"腹部：",
								"视诊：",
								"外形：",
								"",
								"",
								"#肠形：有蠕动波",
								"#肠形：无蠕动波",
								"",
								"",
								"",
								"",
								"#脐带：已脱",
								"#脐带：未脱",
								"",
								"#\n                          脐部：无异常",
								"#\n                          脐部：脐轮红肿",
								"",
								"#分泌物：有",
								"#分泌物：无",
								"分泌物性质：",
								"",
								"#脐疝：有",
								"#脐疝：无",
								"\n              触诊：",
								"",
								"#腹壁：软",
								"#腹壁：紧张",
								"肝右肋下（",
								"",
								"）cm；$$",
								"剑突下（",
								"",
								"）cm；$$",
								"$$",
								"#质地：软",
								"#质地：中",
								"#质地：硬",
								"脾左肋下（",
								"",
								"）cm；$$",
								"",
								"#质地：软",
								"#质地：中",
								"#质地：硬",
								"包快：",
								"",
								"",
								"#\n             扣诊：移动性浊音：有",
								"#\n             扣诊：移动性浊音：无",
								"\n             听诊：",
								"肠鸣音（",
				                "",
				                "）次/分；$$",
				                "#正常",
				                "#亢进",
				                "#减弱",
				                "#消失"
								
							});

			#endregion
			#region 脊柱四肢
			m_objPrintMultiItemArr[21].m_mthSetPrintValue(new string[]{	
																		  "",
																		  "",
																		  "体格检查>>脊柱四肢>>有畸形",
																		  "体格检查>>脊柱四肢>>无畸形",
																		  "",
																		  "体格检查>>脊柱四肢>>四肢肌张力>>正常",
																		  "体格检查>>脊柱四肢>>四肢肌张力>>增高",
																		  "体格检查>>脊柱四肢>>四肢肌张力>>减弱",
																		  "体格检查>>脊柱四肢>>四肢肌张力>>震颤",
																		  "活动",
																		  "体格检查>>脊柱四肢>>活动>>正常",
																		  "体格检查>>脊柱四肢>>活动>>减弱",
																		  "",
																		  "体格检查>>脊柱四肢>>四肢末梢温度>>暖",
																		  "体格检查>>脊柱四肢>>四肢末梢温度>>凉",
																		  "体格检查>>脊柱四肢>>其它",
																	  },
				new string[]{
								"\n脊柱四肢：",
								"",
								"#畸形：有",
								"#畸形：无",
								"",
								"#四肢肌张力：正常",
								"#四肢肌张力：增高",
								"#四肢肌张力：减弱",
								"#四肢肌张力：震颤",
								"",
								"#活动：正常",
								"#活动：减弱",
								"",
								"#\n                   四肢末梢温度暖",
								"#\n                   四肢末梢温度凉",
				                "其它",


								
							});

			#endregion
			#region 肛门生殖器
			m_objPrintMultiItemArr[23].m_mthSetPrintValue(new string[]{	
																		  "",
																		  "体格检查>>肛门外生殖器会阴>>肛门",
																		  "体格检查>>肛门外生殖器会阴>>外生殖器",
																		  "体格检查>>肛门外生殖器会阴>>会阴"
			},
				new string[]{
								"肛门、外生殖器、会阴：",
								"肛门：",
								"外生殖器：",
								"\n                                             会阴："
								
			});

			#endregion
			#region 神经系统
			m_objPrintMultiItemArr[24].m_mthSetPrintValue(new string[]{	
																		  "",
																		  "体格检查>>神经系统>>拥抱反射",
																		  "体格检查>>神经系统>>吸吮反射",
																		  "体格检查>>神经系统>>握持反射：",
																		  "体格检查>>神经系统>>围巾征",
																		  "体格检查>>神经系统>>踏步反射",
																		  "体格检查>>神经系统>>交叉伸腿反射",
																		  "体格检查>>神经系统>>颈竖征",
																		  "体格检查>>神经系统>>腘角征"
																	  },
				new string[]{
								"神经系统：",
								"拥抱反射：",
								"吸吮反射：",
								"握持反射：",
								"围巾征：",
								"\n                     踏步反射：",
								"交叉伸腿反射：",
								"颈竖征：",
								"腘角征："
								
							});
			#endregion
		    #region 胎龄评分
			m_objPrintMultiItemArr[25].m_mthSetPrintValue(new string[]{	
																		  "",
																		  "胎龄评分",
																		  "",
																		  "胎龄评分部分",
																		  "",
																		  "胎龄评估",
																		  ""
																	  },
				new string[]{
								"胎龄评分（生后24小时内评）27+（",
								"",
								"）＝（$$",
								"",
								"）分，胎年评估为（$$",
								"",
								"）分；$$"
															
								
							});
			#endregion
			#region 辅助检查
			m_objPrintMultiItemArr[26].m_mthSetSpecialTitleValue("辅助检查");
			m_objPrintMultiItemArr[26].m_mthSetPrintValue(new string[]{	"辅助检查"},new string[]{"辅助检查："});
			#endregion
			#region 初步诊断
			m_objPrintMultiItemArr[27].m_mthSetPrintValue(new string[]{
																		  "",
																		  "初步诊断1",
																		  "初步诊断2",
																		  "初步诊断3"
																	  },new string[]{
                                          "初步诊断：",
								          "1：", 
										  "\n                      2：",
				                          "\n                      3："
																					});
			#endregion
			#region 签名和日期
			m_objPrintSignArr[0].m_mthSetPrintSignValue(new string[]{"医师签名","记录日期"},new string[]{"医师签名：","记录日期："});
			#endregion
            #region 修正/补充诊断以及签名
            m_objPrintOneItemArr[5].m_mthSetPrintValue("修正诊断", "修正诊断：");
            m_objPrintOneItemArr[6].m_mthSetPrintValue("补充诊断", "补充诊断：");
            m_objPrintSignArr[1].m_mthSetPrintSignValue(new string[] { "修正诊断医师签名", "修正诊断医师签名日期" }, new string[] { "医师签名：", "签名日期：" });
            m_objPrintSignArr[2].m_mthSetPrintSignValue(new string[] { "补充诊断医师签名", "补充诊断医师签名日期" }, new string[] { "医师签名：", "签名日期：" });
                  #endregion





		}
	
		
		#region Print Class

		/// <summary>
		/// 项目打印
		/// </summary>
		private class clsPrintInPatMedRecItem : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private string m_strSpecialTitle = "";
			private string m_strTitle = "";
			private string m_strText = "";
			private string m_strTextXml = "";
			private bool m_blnNoContent = false;
			private bool m_blnNoPrint = true;
			private clsInpatMedRec_Item m_objItemContent = null;

			public clsPrintInPatMedRecItem()
			{}
			
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_blnNoContent == true && m_blnNoPrint == true)
				{
					m_blnHaveMoreLine = false;

					return;
				}

				if(m_blnIsFirstPrint)
				{
					if(m_strTitle != "")
					{
						p_objGrp.DrawString(m_strTitle,p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
						p_intPosY += 20;
                        //判断是否修正/补充诊断
                        if (m_strTitle == "修正诊断：" || m_strTitle == "补充诊断：")
                            m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objItemContent == null ? "" : m_objItemContent.m_strItemContent), (m_objItemContent == null ? "<root />" : m_objItemContent.m_strItemContentXml), m_dtmFirstPrintTime, m_objItemContent != null, Color.Red);
                        else
						    m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objItemContent == null ? "" : m_objItemContent.m_strItemContent)  ,(m_objItemContent==null ? "<root />" : m_objItemContent.m_strItemContentXml),m_dtmFirstPrintTime,m_objItemContent != null);
						m_mthAddSign2(m_strTitle,m_objPrintContext.m_ObjModifyUserArr);
					}
					else
					{
						if(m_strSpecialTitle != "")
						{
							p_objGrp.DrawString(m_strSpecialTitle,clsIMR_HerbalismPrintTool.m_fotItemHead,Brushes.Black,m_intRecBaseX+300,p_intPosY);
							p_intPosY += 20;
						}
						m_objPrintContext.m_mthSetContextWithCorrectBefore(m_strText ,m_strTextXml,m_dtmFirstPrintTime,m_blnNoPrint == false);
						m_mthAddSign2(m_strSpecialTitle,m_objPrintContext.m_ObjModifyUserArr);
					}

					m_blnIsFirstPrint = false;					
				}
			
				int intLine = 0;
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					if(m_strTitle != "")
						m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+50,p_intPosY,p_objGrp);
					else
						m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+20,p_intPosY,p_objGrp);
					p_intPosY += 20;

					intLine++;
				}			

				if(m_objPrintContext.m_BlnHaveNextLine())
					m_blnHaveMoreLine = true;
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
			/// <summary>
			/// 设置多项打印内容
			/// </summary>
			/// <param name="p_strKeyArr">打印内容的哈希键数组</param>
			/// <param name="p_strTitleArr">小标题数组(即对应于窗体Lable但不存储于数据库的需打印的内容)</param>
			public void m_mthSetPrintValue(string[] p_strKeyArr,string[] p_strTitleArr)
			{
				if(p_strKeyArr == null || p_strTitleArr == null || p_strKeyArr.Length != p_strTitleArr.Length)
				{
					m_blnNoContent = true;
					return;
				}
				m_blnNoPrint = false;
				if(m_blnHavePrintInfo(p_strKeyArr) == true)
					m_mthMakeText(p_strTitleArr,p_strKeyArr,ref m_strText,ref m_strTextXml);
			}
			/// <summary>
			/// 设置单项打印内容
			/// </summary>
			/// <param name="p_strKey">哈希键</param>
			/// <param name="p_strTitle">小标题</param>
			public void m_mthSetPrintValue(string p_strKey,string p_strTitle)
			{
				if(m_hasItems != null && p_strKey != null)
					if(m_hasItems.Contains(p_strKey))
						m_objItemContent = m_hasItems[p_strKey] as clsInpatMedRec_Item;
				m_strTitle = p_strTitle;
			}
			/// <summary>
			/// 设置大标题如“体格检查”
			/// </summary>
			/// <param name="p_strTitle"></param>
			public void m_mthSetSpecialTitleValue(string p_strTitle)
			{
				m_strSpecialTitle = p_strTitle;
			}

		}

		/// <summary>
		/// 签名和日期
		/// </summary>
		private class clsPrintInPatMedRecSign : clsIMR_PrintLineBase
		{
			private clsInpatMedRec_Item[] objSignContent = null;
			private string[] m_strTitleArr = null;
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(objSignContent == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				p_intPosY += 40;
				for(int i=0; i<objSignContent.Length; i++)
				{
					if(m_strTitleArr[i].IndexOf("日期") < 0)
					{
						p_objGrp.DrawString(m_strTitleArr[i]+(objSignContent[i]==null ? "" : objSignContent[i].m_strItemContent) ,p_fntNormalText,Brushes.Black,m_intRecBaseX+500,p_intPosY);
						p_intPosY += 20;
					}
					else
					{
						p_objGrp.DrawString(m_strTitleArr[i]+ (objSignContent[i] == null ? "" :DateTime.Parse( objSignContent[i].m_strItemContent).ToString("yyyy年MM月dd日")),p_fntNormalText,Brushes.Black,m_intRecBaseX+500,p_intPosY);
						p_intPosY += 20;
					}
				}
				m_blnHaveMoreLine = false;
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
			}
			/// <summary>
			/// 设置签名和日期值
			/// </summary>
			/// <param name="p_strkeyArr">值</param>
			/// <param name="p_strTitleArr">标题</param>
			public void m_mthSetPrintSignValue(string[] p_strkeyArr,string[] p_strTitleArr)
			{
				if(p_strkeyArr == null || p_strTitleArr == null || p_strkeyArr.Length != p_strTitleArr.Length)
					return;
				objSignContent = m_objGetContentFromItemArr(p_strkeyArr);
				m_strTitleArr = p_strTitleArr;
			}
			

		}

		#endregion
		#region 表格打印
		/// <summary>
		/// 表格打印
		/// </summary>
		private class clsPrintSubInf : clsIMR_PrintLineBase
		{
			#region Define

			private clsPrintRichTextContext m_objDiagnoseR = new clsPrintRichTextContext(Color.Black,new Font("",10));
			private clsPrintRichTextContext m_objDiagnoseL = new clsPrintRichTextContext(Color.Black,new Font("",10));
			//			private string m_strTitle = "";
			//			private string[] m_strTitleArr = null;
			private string m_strImagePath = Directory.GetParent(Directory.GetParent(Application.StartupPath).ToString()) + "\\picture\\Ophthalmology\\";

			/// <summary>
			/// 格子高度
			/// </summary>
			private const int c_intHeight = 40;
			/// <summary>
			/// 左竖线X轴
			/// </summary>
			private const int c_intShortLeft = 140;
			/// <summary>
			/// 右竖线X轴
			/// </summary>
			private const int c_intShortRight = 663;
			/// <summary>
			/// 打印内容格子宽度
			/// </summary>
			//private const int c_intWidth = 323;
			private const int c_intWidth = 127;
			/// <summary>
			/// 打印小标题宽度
			/// </summary>
			private const int c_intTitleWidth = 80;
			//			private int m_intLongLineTop = 150;
			/// <summary>
			/// 打印横线的X坐标
			/// </summary>
			//			private int m_intLeftX = (int)enmRectangleInfo.LeftX -10;

			//			private int m_intIndex = 0;
			//			int m_intPosY;

			//			private bool m_IsPrintCol0=false;
			private bool m_IsPrintCol1=false;
			private bool m_IsPrintCol0=false;
			private bool m_IsPrintCol2=false;
			private bool m_IsPrintCol3=false;
			private bool m_IsPrintCol4=false;
			private bool m_IsTitlePrint=false;
	
			private Pen PrintPenInf =new Pen(Color.Black ,1);

			//			private bool m_IsPrintCol7=false;

			#endregion

			public clsPrintSubInf()
			{
		
			}

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{

				int ColHeight;
		
                ColHeight=0;
			
				m_IsPrintCol0=false;
				m_IsPrintCol1=false;
				m_IsPrintCol2=false;
				m_IsPrintCol3=false;
				m_IsPrintCol4=false;
				m_IsTitlePrint=false;



				
				if (m_IsTitlePrint==false)
				{
					p_objGrp.DrawString ("新生儿胎龄评分表",p_fntNormalText,Brushes.Black,(float)(enmRectangleInfo.LeftX+250),(float)p_intPosY+20);
					//				p_intPosY+=20;
					
					m_IsTitlePrint=true;
				}
			
				ColHeight=40;
				p_intPosY+=40;
               
				//				#region 最上面得线
				////				p_objGrp.DrawLine (PrintPenInf,(float)(enmRectangleInfo.LeftX+15),(float)p_intPosY-10 ,(float)(enmRectangleInfo.RightX-20) ,(float)p_intPosY-10);
				//				#endregion
				System.Drawing.Font p_TsFont=new Font (p_fntNormalText.Name ,p_fntNormalText.Size -3);
				if (m_IsPrintCol0==false)
				{
					if (m_mthIsPage(p_intPosY,ColHeight)) {return;}
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_TsFont,"     评分           体征",ColHeight,-1,-1,"");
					p_objGrp.DrawLine (PrintPenInf,(float)(enmRectangleInfo.LeftX+15),(float)p_intPosY ,(float)(enmRectangleInfo.LeftX+80) ,(float)p_intPosY+ColHeight);
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"                  0分   ",ColHeight,0,-1,"");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"                  1分   ",ColHeight,1,-1,"");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"                  2分   ",ColHeight,2,-1,"");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"                  3分   ",ColHeight,3,-1,"");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"                  4分   ",ColHeight,4,-1,"");
					m_IsPrintCol0=true;
					ColHeight=40;
					p_intPosY+=40;
				}
				

				if (m_IsPrintCol1==false)
				{
					//换页线
					if (m_mthIsPage(p_intPosY,ColHeight)) {p_objGrp.DrawLine (PrintPenInf,(float)(enmRectangleInfo.LeftX+15),(float)p_intPosY ,(float)(enmRectangleInfo.RightX-20) ,(float)p_intPosY);return;}
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"皮肤组织",ColHeight,-1,-1,"");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"薄、胶冻状",ColHeight,0,-1,"新生儿胎龄简易评分表>>皮肤组织>>薄、胶冻状");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"薄而光滑",ColHeight,1,-1,"新生儿胎龄简易评分表>>皮肤组织>>薄而光滑");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"中等厚、皮疹",ColHeight,2,-1,"新生儿胎龄简易评分表>>皮肤组织>>中等厚、皮疹");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"厚、表皮皲裂",ColHeight,3,-1,"新生儿胎龄简易评分表>>皮肤组织>>厚、表皮皲裂");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"厚、羊皮纸样",ColHeight,4,-1,"新生儿胎龄简易评分表>>皮肤组织>>厚、羊皮纸样");
					
					m_IsPrintCol1=true;
				}

				ColHeight=40;
				p_intPosY+=40;
				if (m_IsPrintCol2==false)
				{
					if (m_mthIsPage(p_intPosY,ColHeight)) {p_objGrp.DrawLine (PrintPenInf,(float)(enmRectangleInfo.LeftX+15),(float)p_intPosY ,(float)(enmRectangleInfo.RightX-20) ,(float)p_intPosY);return;}
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"乳头形成",ColHeight,-1,-1,"");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"难认、无乳晕",ColHeight,0,-1,"新生儿胎龄简易评分表>>乳头形成>>难认、无乳晕");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"乳晕平淡，直径 <0.75cm",ColHeight,1,-1,"新生儿胎龄简易评分表>>乳头形成>>乳晕平淡，直径 <0.75cm");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"乳晕点状，直径<0.75cm",ColHeight,2,-1,"新生儿胎龄简易评分表>>乳头形成>>乳晕点状，直径<0.75cm");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"乳晕点状，直径>0.75cm",ColHeight,3,-1,"新生儿胎龄简易评分表>>乳头形成>>乳晕点状，直径>0.75cm");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"",ColHeight,4,-1,"");
					
					m_IsPrintCol2=true;
				}

				ColHeight=40;
				p_intPosY+=40;
				if (m_IsPrintCol3==false)
				{
					if (m_mthIsPage(p_intPosY,ColHeight)) {p_objGrp.DrawLine (PrintPenInf,(float)(enmRectangleInfo.LeftX+15),(float)p_intPosY ,(float)(enmRectangleInfo.RightX-20) ,(float)p_intPosY);return;}
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"指  甲",ColHeight,-1,-1,"");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"",ColHeight,0,-1,"");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"未达指尖",ColHeight,1,-1,"新生儿胎龄简易评分表>>指甲>>未达指尖");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"已达指尖",ColHeight,2,-1,"新生儿胎龄简易评分表>>指甲>>已达指尖");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"超过指尖",ColHeight,3,-1,"新生儿胎龄简易评分表>>指甲>>超过指尖");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"",ColHeight,4,-1,"");
				
					
					m_IsPrintCol3=true;
				}

				ColHeight=40;
				p_intPosY+=40;
				if (m_IsPrintCol4==false)
				{
					if (m_mthIsPage(p_intPosY,ColHeight)) {p_objGrp.DrawLine (PrintPenInf,(float)(enmRectangleInfo.LeftX+15),(float)p_intPosY ,(float)(enmRectangleInfo.RightX-20) ,(float)p_intPosY);return;}
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"足底纹理",ColHeight,-1,-1,"");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"无",ColHeight,0,-1,"新生儿胎龄简易评分表>>足底纹理>>无");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"前半部红痕不明显",ColHeight,1,-1,"新生儿胎龄简易评分表>>足底纹理>>前半部红痕不明显");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"红痕>前半部褶痕<前1/3",ColHeight,2,-1,"新生儿胎龄简易评分表>>足底纹理>>红痕>前半部  褶痕<前1/3");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"褶痕>前2/3",ColHeight,3,-1,"新生儿胎龄简易评分表>>足底纹理>>褶痕>前2/3");
					m_mthPrintDetail(ref p_intPosY,p_objGrp,p_fntNormalText,"明显深的褶痕>2/3",ColHeight,4,-1,"新生儿胎龄简易评分表>>足底纹理>>难认、无乳晕");
					
					m_IsPrintCol4=true; 
				}

				p_intPosY+=40;
				#region 画底线
				p_objGrp.DrawLine (PrintPenInf,(float)(enmRectangleInfo.LeftX+15),(float)p_intPosY ,(float)(enmRectangleInfo.RightX-20) ,(float)p_intPosY);
				#endregion
				m_blnHaveMoreLine = false;
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				m_objDiagnoseR.m_mthRestartPrint();	
				m_objDiagnoseL.m_mthRestartPrint();	
			}

			private void m_mthPrintDetail(ref int p_intPosY, System.Drawing.Graphics p_objGrp, 
				System.Drawing.Font p_fntNormalText,
				string PrintStr,int CellHeight,int Col,int p_LineX,string p_Key)
			{
				StringFormat p_StrFormat=new StringFormat ();
				p_StrFormat.FormatFlags =StringFormatFlags.FitBlackBox;
				

				Rectangle rtgCellinf = new Rectangle(0,0,0,0);
				//				Pen PrintPenInf =new Pen(Color.Black ,1);
				if (Col==-1) 
				{
					#region 根据最左端得列画横线
					if (p_LineX==-1)
					{
						//画最顶端的线
						p_objGrp.DrawLine (PrintPenInf,(float)(enmRectangleInfo.LeftX+15),(float)p_intPosY ,(float)(enmRectangleInfo.RightX-20) ,(float)p_intPosY);
					}
					else
					{
						p_objGrp.DrawLine (PrintPenInf,p_LineX,(float)p_intPosY ,(float)(enmRectangleInfo.RightX-20) ,(float)p_intPosY);
					}
					#endregion
					

					#region 画最左边的竖线
					p_objGrp.DrawLine (PrintPenInf,(float)(enmRectangleInfo.LeftX+15),(float)(p_intPosY) ,(float)(enmRectangleInfo.LeftX+15) ,(float)(p_intPosY+CellHeight));
					#endregion
					
				}
				
				switch (Col)
				{
					case 0:
					case 1:
					case 2:
					case 3:
					case 4:
					    #region 除去第一列根据每列画竖线
						p_objGrp.DrawLine (PrintPenInf,(float)(enmRectangleInfo.LeftX+80+c_intWidth*Col)+5,(float)(p_intPosY) ,(float)(enmRectangleInfo.LeftX+80+c_intWidth*Col)+5 ,(float)(p_intPosY+CellHeight));
						#endregion
						rtgCellinf=new Rectangle ((int)(enmRectangleInfo.LeftX+80+c_intWidth*Col)+5,p_intPosY,c_intWidth,CellHeight);
						break;
					case -2:
						rtgCellinf=new Rectangle ((int)(enmRectangleInfo.LeftX+20)+5,p_intPosY,20,CellHeight);
						break;
					default:
						rtgCellinf=new Rectangle ((int)(enmRectangleInfo.LeftX+10)+5,p_intPosY,c_intWidth,CellHeight);
						#region 画最右边得竖线
						p_objGrp.DrawLine (PrintPenInf,(float)(enmRectangleInfo.RightX-20),(float)(p_intPosY) ,(float)(enmRectangleInfo.RightX-20) ,(float)(p_intPosY+CellHeight));
						#endregion 
						break;
			
				}
				if(m_hasItems!=null)
				{
					if(m_hasItems.Contains(p_Key)&&p_Key!="")
					{
						p_objGrp.DrawString (" √ "+PrintStr,p_fntNormalText,Brushes.Black  ,rtgCellinf,p_StrFormat);
					}
					else
					{
						p_objGrp.DrawString (PrintStr,p_fntNormalText,Brushes.Black,rtgCellinf,p_StrFormat);
					}
				}
				else
				{
	                  p_objGrp.DrawString (PrintStr,p_fntNormalText,Brushes.Black,rtgCellinf,p_StrFormat);
				}
				if (Col==4 )
				{
					//p_intPosY=p_intPosY+CellHeight+10;
					//					p_objGrp.DrawLine (PrintPenInf,(float)(enmRectangleInfo.LeftX+80+c_intWidth*Col),(float)(p_intPosY-10) ,(float)(enmRectangleInfo.LeftX+80+c_intWidth*Col) ,(float)(p_intPosY+CellHeight+10));
				}
			}

			private bool m_mthIsPage(int p_intPosY,int p_ColHeight)
			{
				if(p_intPosY+40+p_ColHeight > ((int)enmRectangleInfo.BottomY -50))
				{
					m_blnHaveMoreLine = true;
					
					p_intPosY += 500;
					return true;
				}
				else
				{
					return false;
				}

			}

		}

		#endregion 表格打印

	}
}
