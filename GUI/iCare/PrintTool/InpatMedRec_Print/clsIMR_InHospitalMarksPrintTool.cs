using System;
using System.IO;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;
using System.Windows.Forms;
using System.Resources ;
namespace iCare
{
	/// <summary>
	/// clsIMR_InHospitalMarksPrintTool 的摘要说明。
	/// </summary>
	public class clsIMR_InHospitalMarksPrintTool: clsInpatMedRecPrintBase
	{
		public clsIMR_InHospitalMarksPrintTool(string p_strTypeID) : base(p_strTypeID)
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			
		}
		private clsPrintInPatMedRecItem[] m_objPrintOneItemArr;
		private clsPrintInPatMedRecItem[] m_objPrintMultiItemArr;
		private clsPrintInPatMedRecSign[] m_objPrintSignArr;
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
																		   m_objPrintMultiItemArr[20],m_objPrintMultiItemArr[21],m_objPrintMultiItemArr[22],m_objPrintMultiItemArr[23],
																		   m_objPrintMultiItemArr[24],m_objPrintMultiItemArr[25],m_objPrintMultiItemArr[26],m_objPrintMultiItemArr[27],
																		   m_objPrintMultiItemArr[28], m_objPrintMultiItemArr[29], m_objPrintMultiItemArr[30],m_objPrintSignArr[0],
                    m_objPrintOneItemArr[6], m_objPrintSignArr[1],  m_objPrintOneItemArr[7],  m_objPrintSignArr[2]
																		  // new clsPrintInHospitalMarks(),	
																		  // new clsSignNameAndDate()													  
																		
																	   });
        }
		private void m_mthInitPrintLineArr()
		{
			m_objPrintOneItemArr = new clsPrintInPatMedRecItem[8];
			for(int i1=0;i1<m_objPrintOneItemArr.Length;i1++)
				m_objPrintOneItemArr[i1] = new clsPrintInPatMedRecItem();

			m_objPrintMultiItemArr = new clsPrintInPatMedRecItem[31];
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
		private class clsPrintPatientFixInfo : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				#region 
				clsInpatMedRec_Item[] m_strOutHospitalDate=new clsInpatMedRec_Item[3];
				
				m_strOutHospitalDate=m_objGetContentFromItemArr(new string[]{"出院时间","出院标记","第几次住院"});
              

								p_objGrp.DrawString("康复医学中心住院志",m_fotItemHead,Brushes.Black,m_intRecBaseX+285,p_intPosY - 10);
						
								p_intPosY += 20;
								p_objGrp.DrawString("姓名："+ m_objPrintInfo.m_strPatientName,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
								p_objGrp.DrawString("记录日期："+(m_objContent==null ? "": m_objContent.m_dtmCreateDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmInPatientCaseHistory"))),p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);
						
								p_intPosY += 20;
								p_objGrp.DrawString("年龄："+(m_objPrintInfo==null ? "": m_objPrintInfo.m_strAge),p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
								p_objGrp.DrawString("供史者和可靠程度："+(m_objContent==null ? "": m_objContent.m_strRepresentor+"," +m_objContent.m_strCredibility),p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);
						
								p_intPosY += 20;
								p_objGrp.DrawString("性别："+ m_objPrintInfo.m_strSex ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);	
								p_objGrp.DrawString("出生地："+ m_objPrintInfo.m_strNativePlace ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);			
				
								p_intPosY += 20;
								p_objGrp.DrawString("床号："+m_objPrintInfo.m_strAreaName+m_objPrintInfo.m_strBedName ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
								p_objGrp.DrawString("住院号："+ m_objPrintInfo.m_strHISInPatientID ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);
						
								p_intPosY += 20;
								p_objGrp.DrawString("职业："+ m_objPrintInfo.m_strOccupation ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
								p_objGrp.DrawString("联系人："+m_objPrintInfo.m_strLinkManFirstName ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);
						
								p_intPosY += 20;
								p_objGrp.DrawString("婚姻："+ m_objPrintInfo.m_strMarried,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
								p_objGrp.DrawString("电话："+ m_objPrintInfo.m_strHomePhone ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);
				
								p_intPosY += 20;
								p_objGrp.DrawString("民族："+ m_objPrintInfo.m_strNationality ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
								p_objGrp.DrawString("工作单位："+ m_objPrintInfo.m_strOfficeName ,p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);	
						
								p_intPosY += 20;
								if(m_objPrintInfo.m_dtmInPatientDate != DateTime.MinValue)
								{
									p_objGrp.DrawString("入院日期："+ m_objPrintInfo.m_dtmHISInDate.ToString("yyyy年MM月dd日 HH时mm分"),p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);			
								}
								else
								{
									p_objGrp.DrawString("入院日期：",p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
								}	
					

//			com.digitalwave.PatientManagerService.clsPatientManagerService objServ=new com.digitalwave.PatientManagerService.clsPatientManagerService();
//               iCare.clsPatient m_objCurrentPatient=null;
//				DateTime m_dtmOutHospitalDate=new DateTime();
//				string strRegisterID;
//				 objServ.m_lngGetRegisterIDByPatient(m_objCurrentPatient.m_StrPatientID, m_objCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"), out strRegisterID);
//				objServ.m_lngGetOutHospitalDate(strRegisterID,out m_dtmOutHospitalDate);
//				if(m_dtmOutHospitalDate == new DateTime(1900,1,1) || m_dtmOutHospitalDate == DateTime.MinValue)
//					p_objGrp.DrawString("出院日期：",p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);			
//				else
//				{
//					p_objGrp.DrawString("出院日期："+ Convert.ToDateTime(m_dtmOutHospitalDate).ToString("yyyy年MM月dd日 HH时"),p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);			
//					
//				}
				if(m_strOutHospitalDate!=null)
				{
					if(m_strOutHospitalDate[2]!=null)
						p_objGrp.DrawString("第"+m_strOutHospitalDate[2].m_strItemContent+"次住院",p_fntNormalText,Brushes.Black,m_intPatientInfoX+350,p_intPosY);			
                     p_intPosY += 20;
					if(m_strOutHospitalDate[0]!=null&&m_strOutHospitalDate[1]!=null)
					{
					
						if(Convert.ToDateTime( m_strOutHospitalDate[0].m_strItemContent) != System.DateTime.MinValue&&(m_strOutHospitalDate[1].m_strItemContent)!="false")
						{
							p_objGrp.DrawString("出院日期："+ Convert.ToDateTime(m_strOutHospitalDate[0].m_strItemContent).ToString("yyyy年MM月dd日 HH时"),p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);			
					
						}
						else
							p_objGrp.DrawString("出院日期：",p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);			

					}
					else
						p_objGrp.DrawString("出院日期：",p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);			
				    
					
				}
				
//				/// <summary>
//				/// 获取病人出院时间，暂时先在各个窗体查询
//				/// </summary>
//				/// <returns></returns>
//				DateTime p_dtmOutHospitalDate;
//					p_dtmOutHospitalDate = new DateTime(1900,1,1);
//					string strRegisterID = "";
//					long lngRes = 0;
//					clsPatientManagerService objServ = new clsPatientManagerService();
//
//					lngRes = objServ.m_lngGetRegisterIDByPatient(m_objCurrentPatient.m_StrPatientID, m_objCurrentPatient.m_DtmSelectedInDate.ToString("yyyy年MM月dd日 HH时mm分"), out strRegisterID);
//			
//					lngRes = objServ.m_lngGetOutHospitalDate(strRegisterID, out p_dtmOutHospitalDate);
//					objServ = null;
//                 
//				if(p_dtmOutHospitalDate != DateTime.MinValue)
//				{
//					p_objGrp.DrawString("出院日期："+ p_dtmOutHospitalDate.ToString("yyyy年MM月dd日 HH时mm分"),p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);			
//				}
//				else
//				{
//					p_objGrp.DrawString("出院日期：",p_fntNormalText,Brushes.Black,m_intPatientInfoX+50,p_intPosY);
//				}	

								m_objPrintContext.m_mthSetContextWithAllCorrect("住址："+ m_objPrintInfo.m_strHomeAddress ,"<root />");
								int intRealHeight;
								Rectangle rtgBlock = new Rectangle(m_intPatientInfoX+350,p_intPosY,(int)enmRectangleInfo.RightX-(m_intPatientInfoX+350),30);
								m_objPrintContext.m_blnPrintAllBySimSun(11,rtgBlock,p_objGrp,out intRealHeight,false);
												
								p_intPosY += 30;
								m_blnHaveMoreLine = false;
				#endregion
	
			//	p_intPosY =+130;
				m_blnHaveMoreLine = false;
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

			#region 基本情况
	
			m_objPrintMultiItemArr[0].m_mthSetPrintValue(new string[]{
																		 "基本情况>>临时诊断",
																		 "基本情况>>最后诊断",
																		 "基本情况>>并发症",
																		 "基本情况>>主诉",
																		 "基本情况>>病历及检查",
					},
				new string[]{	"临时诊断：",
								"\n最后诊断：",
								"\n并发症：",
								"\n入院时主诉：",
								"\n病历及检查："
							
								
			});
			#endregion
			#region 过去病史
			
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(
			new string[]{"","","病史>>平素健康>>良好","病史>>平素健康>>一般","病史>>平素健康>>较差"},																
			
			new string[]{"过去病史(阳性打√，阴性打0,阳性可在空行中详细填写)","\n                平素健康：","#良好","#一般","#较差"});
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(
				new string[]{"","病史>>肝炎","病史>>结核","病史>>伤寒","病史>>痢疾","病史>>血吸虫病"},																
			
				new string[]{"；   传染病史：","肝炎 ","结核 ","伤寒 ","痢疾 ","血吸虫病 "});
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(
				new string[]{"病史>>手术史","病史>>药物过敏","病史>>慢性咳嗽","病史>>咯血","病史>>哮喘","病史>>心悸"},																
			
				new string[]{"\n                手术史 ","药物过敏 ","慢性咳嗽 ","咯血 ","哮喘 ","心悸 "});
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(
				new string[]{"病史>>劳动后急促","病史>>高血压","病史>>胃痛","病史>>呕血","病史>>黑便","病史>>黄疸"},																
			
				new string[]{"\n                劳动后急促 ","高血压 ","胃痛 ","呕血 ","黑便 ","黄疸 "});
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(
				new string[]{"病史>>排尿困难","病史>>血尿","病史>>面部浮肿","病史>>乏力","病史>>皮下出血","病史>>多饮"},																
			
				new string[]{"\n                排尿困难 ","血尿 ","面部浮肿 ","乏力 ","皮下出血 ","多饮 "});
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(
				new string[]{"病史>>多屎","病史>>食欲亢进","病史>>外伤"},																
			
				new string[]{"\n                多屎 ","食欲亢进 ","外伤 "});
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(
				new string[]{"病史>>详细"},																
			
				new string[]{"\n                 "});

			#endregion
			#region 个人史
			m_objPrintMultiItemArr[2].m_mthSetPrintValue(
				new string[]{"病史>>个人史>>出生地","病史>>个人史>>经常居留地","病史>>个人史>>工种","病史>>个人史>>文化程度"},																
			
				new string[]{"个人史：出生地： ","经常居留地：","工种：","文化程度："});
			m_objPrintMultiItemArr[2].m_mthSetPrintValue(
				new string[]{"","病史>>个人史>>毒物接触史>>有","病史>>个人史>>毒物接触史>>无","","病史>>个人史>>吸烟史>>有","病史>>个人史>>吸烟史>>无","","病史>>个人史>>饮酒史>>有","病史>>个人史>>饮酒史>>无"},																
			
				new string[]{"\n                毒物接触史：","#有","#无","吸烟史：","#有","#无","饮酒史：","#有","#无"});

			#endregion

			#region 家庭史
			m_objPrintMultiItemArr[3].m_mthSetPrintValue(
				new string[]{"","病史>>家庭史>>父：健在","病史>>家庭史>>父：患病","病史>>家庭史>>父：已故","病史>>家庭史>>父>>死因"},																
			
				new string[]{"家庭史：","#父：健在","#父：患病","#父：已故","死因："});
			m_objPrintMultiItemArr[3].m_mthSetPrintValue(
				new string[]{"","病史>>家庭史>>母：健在","病史>>家庭史>>母：患病","病史>>家庭史>>母：已故","病史>>家庭史>>母>>死因"},																
			
				new string[]{"； ","#母：健在","#母：患病","#母：已故","死因："});

			#endregion

			#region 一般项目
			m_objPrintMultiItemArr[4].m_mthSetSpecialTitleValue("一般检查");
			m_objPrintMultiItemArr[4].m_mthSetPrintValue(
				new string[]{"一般情况>>T","","一般情况>>P","","一般情况>>R","","一般情况>>BP",""},																
			
				new string[]{"一般项目：T：","℃；$$","P：","次/分；$$","R：","次/分；$$","BP：","/$$"});
			m_objPrintMultiItemArr[4].m_mthSetPrintValue(
				new string[]{"一般情况>>BP>>mmHg",""},																
			
				new string[]{"","mmHg；$$"});

			m_objPrintMultiItemArr[4].m_mthSetPrintValue(
				new string[]{"","一般情况>>发育>>正常","一般情况>>发育>>不良","","一般情况>>营养>>好","一般情况>>营养>>中","一般情况>>营养>>差"},																
			
				new string[]{"\n                发育：","#正常","#不良","营养：","#好","#中","#差"});
			m_objPrintMultiItemArr[4].m_mthSetPrintValue(
				new string[]{"","一般情况>>体态>>高中矮：高","一般情况>>体态>>高中矮：中","一般情况>>体态>>高中矮：矮","一般情况>>体态>>胖中瘦：胖","一般情况>>体态>>胖中瘦：中","一般情况>>体态>>胖中瘦：瘦"},																
			
				new string[]{"；体态：","#高、","#中、","#矮、","#胖","#中","#瘦"});

			#endregion

			#region 皮肤粘膜
			m_objPrintMultiItemArr[5].m_mthSetPrintValue(
				new string[]{"","一般情况>>红润","一般情况>>苍白","一般情况>>温暖","一般情况>>冷厥","一般情况>>皮疹","一般情况>>瘀斑"},																
			
				new string[]{"皮肤粘膜：","#红润、","#苍白、","#温暖、","#冷厥、","#皮疹、","#瘀斑；"});
			m_objPrintMultiItemArr[5].m_mthSetPrintValue(
				new string[]{"一般情况>>皮肤粘膜>>褥疮：有","一般情况>>皮肤粘膜>>褥疮：无"},																
			
				new string[]{"# 褥疮：有","# 褥疮：无"});
			#endregion
			#region 淋巴结
			m_objPrintMultiItemArr[6].m_mthSetPrintValue(
				new string[]{"","一般情况>>淋巴结>>肿大：有","一般情况>>淋巴结>>肿大:无","一般情况>>淋巴结>>肿大>>部位：颈","一般情况>>淋巴结>>肿大>>部位：腋下","一般情况>>淋巴结>>肿大>>部位：腹股沟"},																
			
				new string[]{"淋巴结：","#肿大：有；","#肿大:无；","#部位：颈","#部位：腋下","#部位：腹股沟"});
			
			#endregion
			#region 头部
			m_objPrintMultiItemArr[7].m_mthSetPrintValue(
				new string[]{"","一般情况>>头部>>颅骨缺损：有","一般情况>>头部>>颅骨缺损：无","一般情况>>头部>>颅骨缺损>>部位：左","一般情况>>头部>>颅骨缺损>>部位：右","一般情况>>头部>>颅骨缺损>>部位：正中"
							,"一般情况>>头部>>颅骨缺损>>部位：额","一般情况>>头部>>颅骨缺损>>部位：顶","一般情况>>头部>>颅骨缺损>>部位：颞"},																
			
				new string[]{"头部：","#颅骨缺损：有","#颅骨缺损：无","#；部位：左","#部位：右","#正中","#额","#顶","#颞"});
			m_objPrintMultiItemArr[7].m_mthSetPrintValue(
				new string[]{"","一般情况>>头部>>角膜流脓>>有","一般情况>>头部>>角膜流脓>>无","","一般情况>>头部>>结膜充血>>有","一般情况>>头部>>结膜充血>>无","",
								"一般情况>>头部>>付鼻窦压痛>>有","一般情况>>头部>>付鼻窦压痛>>无"},																
			
				new string[]{"\n            角膜溃疡：","#有","#无","结膜充血：","#有","#无","付鼻窦压痛：","#有","#无"});
			m_objPrintMultiItemArr[7].m_mthSetPrintValue(
				new string[]{"","一般情况>>头部>>耳鼻流脓>>有","一般情况>>头部>>耳鼻流脓>>无","","一般情况>>头部>>口腔溃疡>>有","一般情况>>头部>>口腔溃疡>>无","",
								"一般情况>>头部>>咽部充血>>有","一般情况>>头部>>咽部充血>>无"},																
			
				new string[]{"；耳鼻流脓：","#有","#无","口腔溃疡：","#有","#无","咽部充血：","#有","#无"});
			
			#endregion
			#region 颈部
			m_objPrintMultiItemArr[8].m_mthSetPrintValue(
				new string[]{"","","一般情况>>头部>>气管偏移>>有","一般情况>>头部>>气管偏移>>无","","一般情况>>头部>>甲状腺肿大>>有","一般情况>>头部>>甲状腺肿大>>无","","一般情况>>头部>静脉怒张>>有","一般情况>>头部>静脉怒张>>无"},																
				new string[]{"颈部：","气管偏移：","#有","#无","甲状腺肿大：","#有","#无","静脉怒张：","#有","#无"});

			#endregion
			#region 胸部
			m_objPrintMultiItemArr[9].m_mthSetPrintValue(
				new string[]{"","一般情况>>胸部>>胸部畸形：有","一般情况>>胸部>>胸部畸形：无","一般情况>>胸部>>呼吸音：清晰","一般情况>>胸部>>呼吸音：粗糙","一般情况>>胸部>>呼吸音：干罗音"
								,"一般情况>>胸部>>呼吸音：湿罗音"},																
			
				new string[]{"胸部：","#胸部畸形：有；","#胸部畸形：无；","#呼吸音：清晰","#呼吸音：粗糙","#呼吸音：干罗音","#呼吸音：湿罗音"});
			m_objPrintMultiItemArr[9].m_mthSetPrintValue(
				new string[]{"一般情况>>胸部>>心率","","一般情况>>胸部>>节律：齐","一般情况>>胸部>>节律：不齐","一般情况>>胸部>>心音：强","一般情况>>胸部>>心音：中","一般情况>>胸部>>心音：弱"},																
				new string[]{"\n            心率：","次/分；$$","#节律：齐；","#节律：不齐；","#心音：强","#心音：中","#心音：弱"});
			m_objPrintMultiItemArr[9].m_mthSetPrintValue(
				new string[]{"一般情况>>胸部>>杂音：有","一般情况>>胸部>>杂音：无","一般情况>>胸部>>杂音>>部位：心类","一般情况>>胸部>>杂音>>部位：主动脉区","一般情况>>胸部>>杂音>>时相：收缩期","一般情况>>胸部>>杂音>>时相：舒张期","一般情况>>胸部>>详细"},																
				new string[]{"#；杂音：有；","#杂音：无；","#部位：心类；","#部位：主动脉区；","#时相：收缩期","#时相：舒张期",""});

			#endregion
            #region 腹部
			m_objPrintMultiItemArr[10].m_mthSetPrintValue(
				new string[]{"","","一般情况>>腹部>>肝区压痛:有","一般情况>>腹部>>肝区压痛:无","","一般情况>>腹部>>包快:有","一般情况>>腹部>>包快:无"},	
																							
				new string[]{"腹部：","肝区压痛：","#有","#无","包块：","#有","#无"});
			m_objPrintMultiItemArr[10].m_mthSetPrintValue(
				new string[]{"","一般情况>>腹壁压痛:有","一般情况>>腹壁压痛:无","","一般情况>>腹部>>反射跳:有","一般情况>>腹部>>反射跳:无"},	
																							
				new string[]{"；腹壁压痛：","#有","#无","反射跳：","#有","#无"});
			#endregion

			#region 肛门生殖器
			m_objPrintMultiItemArr[11].m_mthSetPrintValue(
				new string[]{"","一般情况>>肛门生殖器:未查","一般情况>>肛门生殖器:无异常"},	
																							
				new string[]{"肛门生殖器：","#未查","#无异常"});

			#endregion
			#region 脊柱四肢
			m_objPrintMultiItemArr[12].m_mthSetPrintValue(
				new string[]{"","","一般情况>>脊柱四肢>>畸形:有","一般情况>>脊柱四肢>>畸形:无","","一般情况>>脊柱四肢>>关节红肿:有","一般情况>>脊柱四肢>>关节红肿:无","","一般情况>>脊柱四肢>>关节活动:正常","一般情况>>脊柱四肢>>关节活动:受限"},	
																							
				new string[]{"脊柱四肢：","畸形：","#有","#无","关节红肿：","#有","#无","关节活动：","#正常","#受限"});
			m_objPrintMultiItemArr[12].m_mthSetPrintValue(
				new string[]{"","一般情况>>脊柱四肢>>肩关节活动度:左","一般情况>>脊柱四肢>>肩关节活动度:右","一般情况>>脊柱四肢>>前屈","","一般情况>>脊柱四肢>>外展",""},	
																							
				new string[]{"\n            肩关节活动度：","#左","#右","前屈：","度；$$","外展：","度；$$"});
			m_objPrintMultiItemArr[12].m_mthSetPrintValue(
				new string[]{"一般情况>>脊柱四肢>>内收","","一般情况>>脊柱四肢>>后伸","","一般情况>>脊柱四肢>>内旋","","一般情况>>脊柱四肢>>外旋","","一般情况>>脊柱四肢>>肩关节活动度>>详细"},	
																							
				new string[]{"\n            内收：","度；$$","后伸：","度；$$","内旋：","度；$$","外旋：","度；$$",""});

			#endregion

			#region 血管情况
			m_objPrintMultiItemArr[13].m_mthSetPrintValue(
				new string[]{"","","一般情况>>血管情况>>血脉冲:有","一般情况>>血管情况>>血脉冲:无","","一般情况>>血管情况>>奇脉:有","一般情况>>血管情况>>奇脉:无","","一般情况>>血管情况>>枪击音:有","一般情况>>血管情况>>枪击音:无"},	
																							
				new string[]{"血管情况：","血脉冲：","#有","#无","奇脉：","#有","#无","枪击音：","#有","#无"});

			#endregion

			#region 意识状态
            m_objPrintMultiItemArr[14].m_mthSetSpecialTitleValue("神经系统检查");
			m_objPrintMultiItemArr[14].m_mthSetPrintValue(
				new string[]{"","神经系统>>颅神经>>意识状态:清楚","神经系统>>颅神经>>意识状态:模糊","神经系统>>颅神经>>意识状态:嗜睡","神经系统>>颅神经>>意识状态:昏迷","神经系统>>颅神经>>意识(格拉斯哥记分)"},	
																							
				new string[]{"意识状态：","#清楚","#模糊","#嗜睡","#昏迷","意识:(格拉斯哥总分)："});

			#endregion
			#region 语言功能
			m_objPrintMultiItemArr[15].m_mthSetPrintValue(
				new string[]{"","神经系统>>颅神经>>语言功能>>运动性失语：有","神经系统>>颅神经>>语言功能>>运动性失语：无","神经系统>>颅神经>>语言功能>>感觉性失语：有","神经系统>>颅神经>>语言功能>>感觉性失语：无","神经系统>>颅神经>>语言功能>>混合性失语：有","神经系统>>颅神经>>语言功能>>混合性失语：无"},	
																							
				new string[]{"语言功能：","#运动性失语：有；","#运动性失语：无；","#感觉性失语：有；","#感觉性失语：无；","#混合性失语：有","混合性失语：无"});

			#endregion

			#region 颅神经
			m_objPrintMultiItemArr[16].m_mthSetPrintValue(
				new string[]{"","","颅神经>>嗅觉>>左","颅神经>>嗅觉>>右"},	
																							
				new string[]{"颅神经：","Ⅰ.嗅觉：","左：","右："});
			m_objPrintMultiItemArr[16].m_mthSetPrintValue(
				new string[]{"","脑神经>>视力>>左","脑神经>>视力>>右","","脑神经>>视野>>左","脑神经>>视野>>右","脑神经>>眼底"},	
																							
				new string[]{"\n            Ⅱ.视力：","左：","右：","视野：","左：","右：","眼底："});
			m_objPrintMultiItemArr[16].m_mthSetPrintValue(
				new string[]{"","脑神经>>睑下垂","脑神经>>眼裂"},	
																							
				new string[]{"\n            Ⅲ.Ⅳ.Ⅴ. 睑下垂：","","眼裂："});
			m_objPrintMultiItemArr[16].m_mthSetPrintValue(
				new string[]{"","脑神经>>眼球>>位置","脑神经>>眼球>>运动","脑神经>>眼球>>复视","脑神经>>眼球>>震颤"},	
																							
				new string[]{"\n            眼球：","位置：","运动：","复视：","震颤："});
			m_objPrintMultiItemArr[16].m_mthSetPrintValue(
				new string[]{"","脑神经>>瞳孔>>大小","脑神经>>瞳孔>>形状","脑神经>>瞳孔>>直接光反射","脑神经>>瞳孔>>间接光反射"},	
																							
				new string[]{"\n            瞳孔：","大小：","形状：","直接光反射：","间接光反射："});
			m_objPrintMultiItemArr[17].m_mthSetPrintValue(
				new string[]{"","脑神经>>面部感觉","脑神经>>面部感觉>>三叉神经痛"},	
																							
				new string[]{"            Ⅵ.","面部感觉：","三叉神经痛："});
			m_objPrintMultiItemArr[17].m_mthSetPrintValue(
				new string[]{"脑神经>>面部感觉>>角膜反射","脑神经>>面部感觉>>角膜反射>>直接","脑神经>>面部感觉>>角膜反射>>间接"},	
																							
				new string[]{"\n            角膜反射：","直接：左：","间接："});
			m_objPrintMultiItemArr[17].m_mthSetPrintValue(
				new string[]{"脑神经>>面部感觉>>下颚运动","脑神经>>面部感觉>>下颚运动>>嚼肌","脑神经>>面部感觉>>下颚运动>>颞肌"},	
																							
				new string[]{"            下颌运动：","嚼肌：","颞肌："});
			m_objPrintMultiItemArr[18].m_mthSetPrintValue(
				new string[]{"","脑神经>>皱眉","脑神经>>闭目","脑神经>>示齿","脑神经>>鼓腮","脑神经>>噘嘴"},	
																							
				new string[]{"            Ⅶ.","皱额：","闭目：","示齿：","鼓腮：","噘嘴："});
			m_objPrintMultiItemArr[18].m_mthSetPrintValue(
				new string[]{"","脑神经>>听力：正常","脑神经>>听力：减退","脑神经>>晕眩：有","脑神经>>晕眩：无","脑神经>>耳鸣：有","脑神经>>耳鸣：无"},	
																							
				new string[]{"\n            Ⅷ.","#听力：正常；","#听力：减退；","#晕眩：有；","#晕眩：无；","#耳鸣：有","#耳鸣：无"});
			m_objPrintMultiItemArr[18].m_mthSetPrintValue(
				new string[]{"","脑神经>>发音：正常","脑神经>>发音：构音障碍","脑神经>>吞咽：正常","脑神经>>吞咽：咳嗽","脑神经>>吞咽：鼻饲","脑神经>>软腭运动","脑神经>>咽反射"},	
																							
				new string[]{"\n            Ⅸ.Ⅹ.","#发音：正常；","#发音：构音障碍；","#吞咽：正常；","#吞咽：咳嗽；","#吞咽：鼻饲","软腭运动：","咽反射："});
			m_objPrintMultiItemArr[19].m_mthSetPrintValue(
				new string[]{"","脑神经>>胸锁乳突","","脑神经>>肌萎缩:有","脑神经>>肌萎缩:无","脑神经>>斜方肌肌力","","脑神经>>斜方肌>>肌萎缩:有","脑神经>>斜方肌>>肌萎缩:无"},	
																							
				new string[]{"            Ⅺ.","胸锁乳突肌肌力：","肌萎缩：","#有","#无","斜方肌肌力：","肌萎缩：","#有","#无"});
			m_objPrintMultiItemArr[19].m_mthSetPrintValue(
				new string[]{"","脑神经>>斜方肌>>舌运动","","脑神经>>舌>>肌萎缩:有","脑神经>>舌>>肌萎缩:无","","脑神经>>舌肌纤颤:有","脑神经>>舌肌纤颤:无"},	
																							
				new string[]{"\n            Ⅶ.","舌运动：","舌肌萎缩：","#有","#无","舌肌纤颤：","#有","#无"});
			#region 运动功能
			m_objPrintMultiItemArr[20].m_mthSetPrintValue(
				new string[]{"","运动神经>>双侧正常","","运动神经>>侧障碍:左","运动神经>>侧障碍:右","运动神经>>分离运动","","运动神经>>分离运动>>上肢:有","运动神经>>分离运动>>上肢:无","","运动神经>>分离运动>>下肢:有","运动神经>>分离运动>>下肢:无"},	
																							
				new string[]{"运动功能：","双侧正常：","侧障碍：","#左","#右","分离运动：","上肢：","#有","#无","下肢：","#有","#无"});
			m_objPrintMultiItemArr[20].m_mthSetPrintValue(
				new string[]{"运动神经>>共同运动","","运动神经>>共同运动>>上肢:有","运动神经>>共同运动>>上肢:无","","运动神经>>共同运动>>下肢:有","运动神经>>共同运动>>下肢:无"},	
																							
				new string[]{"\n            共同运动：","上肢：","#有","#无","下肢：","#有","#无"});
			
			m_objPrintMultiItemArr[20].m_mthSetPrintValue(
				new string[]{"运动神经>>Brunnstrom分级","运动神经>>Brunnstrom分级>>上臂","","运动神经>>Brunnstrom分级>>手"},	
																							
				new string[]{"\n            Brunnstrom分级：","上臂：","级；$$",""});
			m_objPrintMultiItemArr[20].m_mthSetPrintValue(
				new string[]{"运动神经>>Brunnstrom分级>>手>>级","","运动神经>>Brunnstrom分级>>下肢",""},	
																							
				new string[]{"手：","级；$$","下肢：","级；$$"});
			m_objPrintMultiItemArr[21].m_mthSetPrintValue(
				new string[]{"","运动神经>>上肢近端屈肌","","运动神经>>上肢近端伸肌","","运动神经>>上肢远端屈肌","","运动神经>>上肢远端伸肌",""},	
																							
				new string[]{"肌力：","上肢近端屈肌：","级；$$","近端伸肌：","级；$$","远端屈肌：","级；$$","远端伸肌：","级；$$"});
			m_objPrintMultiItemArr[21].m_mthSetPrintValue(
				new string[]{"运动神经>>下肢近端屈肌","","运动神经>>下肢近端伸肌","","运动神经>>下肢远端屈肌","","运动神经>>下肢远端伸肌",""},	
																							
				new string[]{"\n            下肢近端屈肌：","级；$$","近端伸肌：","级；$$","远端屈肌：","级；$$","远端伸肌：","级；$$"});
			
			m_objPrintMultiItemArr[22].m_mthSetPrintValue(
				new string[]{"","","运动神经>>肌张力>>左上肢:降低","运动神经>>肌张力>>左上肢:正常","运动神经>>肌张力>>左上肢:增高"},	
																							
				new string[]{"肌张力：","左上肢：","#降低","#正常","#增高"});
			m_objPrintMultiItemArr[22].m_mthSetPrintValue(
				new string[]{"","运动神经>>肌张力>>左下肢:降低","运动神经>>肌张力>>左下肢:正常","运动神经>>肌张力>>左下肢:增高"},	
																							
				new string[]{"；左下肢：","#降低","#正常","#增高"});
			m_objPrintMultiItemArr[22].m_mthSetPrintValue(
				new string[]{"","运动神经>>肌张力>>右上肢:降低","运动神经>>肌张力>>右上肢:正常","运动神经>>肌张力>>右上肢:增高"},	
																							
				new string[]{"；右上肢：","#降低","#正常","#增高"});
			m_objPrintMultiItemArr[22].m_mthSetPrintValue(
				new string[]{"","运动神经>>肌张力>>右下肢:降低","运动神经>>肌张力>>右下肢:正常","运动神经>>肌张力>>右下肢:增高"},	
																							
				new string[]{"；右下肢：","#降低","#正常","#增高"});
			m_objPrintMultiItemArr[23].m_mthSetPrintValue(
				new string[]{"","运动神经>>共济运动及轻瘫试验>>分指试验","运动神经>>共济运动及轻瘫试验>>趾背伸试验","运动神经>>共济运动及轻瘫试验>>平举试验"},	
																							
				new string[]{"共济运动及轻瘫试验：","\n            分指试验：","趾背伸试验：","平举试验："});
			m_objPrintMultiItemArr[23].m_mthSetPrintValue(
				new string[]{"运动神经>>共济运动及轻瘫试验>>Barre氏I试验","运动神经>>共济运动及轻瘫试验>>Barre氏II试验","运动神经>>共济运动及轻瘫试验>>Mingazini试验"},	
																							
				new string[]{"\n            Barre氏I试验：","Barre氏II试验：","Mingazini试验："});
			m_objPrintMultiItemArr[23].m_mthSetPrintValue(
				new string[]{"运动神经>>共济运动及轻瘫试验>>指鼻试验","运动神经>>共济运动及轻瘫试验>>跟膝胫试验","运动神经>>共济运动及轻瘫试验>>Romberg氏症"},	
																							
				new string[]{"\n            指鼻试验：","跟膝胫试验：","Romberg氏症："});
			m_objPrintMultiItemArr[24].m_mthSetPrintValue(
				new string[]{"运动神经>>步态","运动神经>>步态>>综合功能","运动神经>>步态>>ADL Barthel指数"},	
																							
				new string[]{"步态：","\n            综合功能：","ADL Barthel指数得分："});
			
			#endregion
			#region 感觉功能
			m_objPrintMultiItemArr[25].m_mthSetPrintValue(
				new string[]{"","感觉功能>>浅感觉","感觉功能>>深感觉","感觉功能>>皮层觉"},	
																							
				new string[]{"感觉功能：","\n            浅感觉：","\n            深感觉：","\n            皮层觉："});
			m_objPrintMultiItemArr[25].m_mthSetPrintValue(
				new string[]{"感觉功能>>神经根牵引痛","感觉功能>>神经干压痛"},	
																							
				new string[]{"\n            神经根牵引痛：","\n            神经干压痛："});
			#endregion
			#region 反射
			m_objPrintMultiItemArr[26].m_mthSetPrintValue(
				new string[]{"","神经系统>>反射>>生理反射>>腹壁反射","神经系统>>反射>>生理反射>>桡骨膜反射"},	
																							
				new string[]{"反射：生理反射（消失＝-、减弱＝+、下常＝++、亢进＝+++、阵挛=++++）","\n            腹壁反射：","桡骨膜反射："});
			m_objPrintMultiItemArr[26].m_mthSetPrintValue(
				new string[]{"神经系统>>反射>>生理反射>>肱二头肌","神经系统>>反射>>生理反射>>肱三头肌"},	
																							
				new string[]{"\n            肱二头肌反射：","肱三头肌反射："});
			m_objPrintMultiItemArr[26].m_mthSetPrintValue(
				new string[]{"神经系统>>反射>>生理反射>>膝反射","神经系统>>反射>>生理反射>>踝反射"},	
																							
				new string[]{"\n            膝反射：","踝反射："});

			m_objPrintMultiItemArr[26].m_mthSetPrintValue(
				new string[]{"","神经系统>>反射>>生理反射>>吸吮反射","神经系统>>反射>>生理反射>>掌心下颌反射"},	
																							
				new string[]{"\n病理反射：","\n            吸吮反射：","掌心下颌反射："});
			m_objPrintMultiItemArr[26].m_mthSetPrintValue(
				new string[]{"神经系统>>反射>>生理反射>>Hoffmann","神经系统>>反射>>生理反射>>Babinaskin"},	
																							
				new string[]{"\n            Hoffmann氏征：","Babinaskin氏征："});
		
			#endregion

			#region 植物神经
			m_objPrintMultiItemArr[27].m_mthSetPrintValue(
				new string[]{"","","神经系统>>植物神经>>异常出汗:有","神经系统>>植物神经>>异常出汗:无"},	
																							
				new string[]{"植物神经：","异常出汗：","#有；","#无；"});
			m_objPrintMultiItemArr[27].m_mthSetPrintValue(
				new string[]{"","神经系统>>植物神经>>大便功能:便秘","神经系统>>植物神经>>大便功能:正常","神经系统>>植物神经>>大便功能:失禁",
							"","神经系统>>植物神经>>小便功能:潴留","神经系统>>植物神经>>小便功能:正常","神经系统>>植物神经>>小便功能:失禁"},	
																							
				new string[]{"大便功能：","#便秘","#正常","#失禁",
                             "小便功能：","#潴留","#正常","#失禁"});
		
			#endregion
			#region 脑膜刺激症
			m_objPrintMultiItemArr[28].m_mthSetPrintValue(
				new string[]{"","","神经系统>>脑膜刺激症>>顶强:有","神经系统>>脑膜刺激症>>顶强:无"},	
																							
				new string[]{"脑膜刺激症：","顶强：","#有","#无"});
			m_objPrintMultiItemArr[28].m_mthSetPrintValue(
				new string[]{"神经系统>>脑膜刺激症>>顶强:下颌距胸骨","神经系统>>脑膜刺激症>>顶强:横指"},	
																							
				new string[]{"；下颌距胸骨：","横指："});
			m_objPrintMultiItemArr[28].m_mthSetPrintValue(
				new string[]{"","神经系统>>脑膜刺激症>>Kerning氏症:阳性","神经系统>>脑膜刺激症>>Kerning氏症:阴性",
			                  "","神经系统>>脑膜刺激症>>Brubzinski:阳性","神经系统>>脑膜刺激症>>Brubzinski:阴性"},	
																							
				new string[]{"；Kerning氏症：","#阳性","#阴性","Brubzinski：","#阳性","#阴性"});
			#endregion
			#region 小结
			m_objPrintMultiItemArr[29].m_mthSetPrintValue(
				new string[]{"诊断>>门诊CT及其它资料","诊断>>小结"},	
																							
				new string[]{"门诊CT及其它资料：","\n小结："});
			#endregion
			
			#region 诊断
			m_objPrintMultiItemArr[30].m_mthSetSpecialTitleValue("诊断");
			m_objPrintMultiItemArr[30].m_mthSetPrintValue(
				new string[]{"诊断>>定位","诊断>>定性"},	
																							
				new string[]{"\n定位：","\n定性："});
			m_objPrintMultiItemArr[30].m_mthSetPrintValue(
				new string[]{"诊断>>初步诊断","诊断>>出院诊断"},	
																							
				new string[]{"\n初步诊断：","\n出院诊断："});
			#endregion

			#region 签名和日期
			m_objPrintSignArr[0].m_mthSetPrintSignValue(new string[]{"医师签名"},new string[]{"医师签名："});
			#endregion

            #endregion
            #region 修正/补充诊断以及签名
            m_objPrintOneItemArr[6].m_mthSetPrintValue("修正诊断", "修正诊断：");
            m_objPrintOneItemArr[7].m_mthSetPrintValue("补充诊断", "补充诊断：");
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
						m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objItemContent==null ? "" : m_objItemContent.m_strItemContent)  ,(m_objItemContent==null ? "<root />" : m_objItemContent.m_strItemContentXml),m_dtmFirstPrintTime,m_objItemContent != null);
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
		#region 出院日期---出院诊断
		/// <summary>
		/// 出院日期---出院诊断
		/// </summary>
		private class clsPrintInHospitalMarks : clsIMR_PrintLineBase
		{
//			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));
//		//	private clsInpatMedRec_Item[] objItemContent1;
//		    bool m_blnIsFirstPrint=true;
//			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
//			{
//				if(m_objContent == null|| m_objContent.m_objItemContents == null)
//				{
//					m_blnHaveMoreLine = false;
//					return;
//				}
//			//	objItemContent1 = m_objGetContentFromItemArr(new string[]{"出院时间"});
//
//				//				if(m_blnHavePrintInfo(m_strKeysArr1) == false )
//				//				{
//				//					m_blnHaveMoreLine = false;
//				//					return;
//				//				}
//				if(m_blnIsFirstPrint)
//				{
//					string strAllText = "";
//					string strXml = "";
//					string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
//				
//					
//						//p_objGrp.DrawString("出院日期："+ (objItemContent1[0] == null ? "" :DateTime.Parse( objItemContent1[0].m_strItemContent).ToString("yyyy年MM月dd日HH时mm分")),p_fntNormalText,Brushes.Black,m_intRecBaseX+15,p_intPosY);
//						//p_intPosY+=20;
//					
//					
//					if(m_objContent!=null)
//					{
//						#region 临时诊断--过去病史
//						m_mthMakeText(new string[]{"\n第","次住院$$"},new string[]{"第几次住院",""},ref strAllText,ref strXml);
//
//						m_mthMakeText(new string[]{"\n临时诊断："},new string[]{"基本情况>>临时诊断"},ref strAllText,ref strXml);
//						m_mthMakeText(new string[]{"\n最后诊断："},new string[]{"基本情况>>最后诊断"},ref strAllText,ref strXml);
//						m_mthMakeText(new string[]{"\n并发症："},new string[]{"基本情况>>并发症"},ref strAllText,ref strXml);
//						
//						m_mthMakeText(new string[]{"\n入院主诉："},new string[]{"基本情况>>主诉"},ref strAllText,ref strXml);
//						m_mthMakeText(new string[]{"\n病历及检查："},new string[]{"基本情况>>病历及检查"},ref strAllText,ref strXml);
//						m_mthMakeText(new string[]{"\n过去病史(阳性打√，阴性打o,阳性可在空行中详细填写)："},new string[]{""},ref strAllText,ref strXml);
//						m_mthMakeCheckText(new string []{"\n                   平素健康：","病史>>平素健康>>良好","病史>>平素健康>>一般","病史>>平素健康>>较差"},ref strAllText,ref strXml);
//						m_mthMakeText(new string[]{"传染病史：肝炎"},new string[]{"病史>>肝炎"},ref strAllText,ref strXml);
//						m_mthMakeText(new string[]{"结核","伤寒","痢疾","血吸虫病"},new string[]{"病史>>结核","病史>>伤寒","病史>>痢疾","病史>>血吸虫病"},ref strAllText,ref strXml);
//						m_mthMakeText(new string[]{"\n                   手术史："},new string[]{""},ref strAllText,ref strXml);
//						m_mthMakeText(new string[]{""},new string[]{"病史>>手术史"},ref strAllText,ref strXml);
//						m_mthMakeText(new string[]{"药物过敏","慢性咳嗽","咯血","哮喘","心悸"},new string[]{"病史>>药物过敏","病史>>慢性咳嗽","病史>>咯血","病史>>哮喘","病史>>心悸"},ref strAllText,ref strXml);
//						m_mthMakeText(new string[]{"\n                   劳动后急促"},new string[]{"病史>>劳动后急促"},ref strAllText,ref strXml);
//						m_mthMakeText(new string[]{"高血压","胃痛","呕血","黑便","黄疸"},new string[]{"病史>>高血压","病史>>胃痛","病史>>呕血","病史>>黑便","病史>>黄疸"},ref strAllText,ref strXml);
//						m_mthMakeText(new string[]{"\n                   排尿困难"},new string[]{"病史>>排尿困难"},ref strAllText,ref strXml);
//						m_mthMakeText(new string[]{"血尿","面部浮肿","乏力","皮下出血","多饮"},new string[]{"病史>>血尿","病史>>面部浮肿","病史>>乏力","病史>>皮下出血","病史>>多饮"},ref strAllText,ref strXml);
//						
//
//						
//					
//						
//						#endregion
//
//
//					}
//					else
//					{
//						m_blnHaveMoreLine = false;
//						return;
//					}
//					m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText,strXml,m_dtmFirstPrintTime,m_objContent.m_objItemContents!= null);
//					//m_mthAddSign2("检查情形：",m_objPrintContext.m_ObjModifyUserArr);
//					m_blnIsFirstPrint = false;					
//				}
//
//				if(m_objPrintContext.m_BlnHaveNextLine())
//				{
//					m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2,m_intRecBaseX+10,p_intPosY,p_objGrp);
//					p_intPosY += 20;
//				}
//				if(m_objPrintContext.m_BlnHaveNextLine())
//				{
//					m_blnHaveMoreLine = true;
//				}
//				else
//				{
//					m_blnHaveMoreLine = false;
//				}
//			}
//
//			public override void m_mthReset()
//			{
//				m_objPrintContext.m_mthRestartPrint();
//				m_blnHaveMoreLine = true;
//				m_blnIsFirstPrint = true;
//			}
		}
		#endregion
	}
}
