using System;
using System.Xml;
using com.digitalwave.InPatientEvaluateServ;
using System.IO;
using System.Text;
using iCareData;

namespace iCare
{
	/// <summary>
	/// Summary description for clsInPatientEvaluateDomain.
	/// </summary>
	public class clsInPatientEvaluateDomain
	{
        //private clsInPatientEvaluateServ m_objServ=new clsInPatientEvaluateServ();
		private XmlParserContext m_objXmlParser = new XmlParserContext(null,null,null,XmlSpace.None,Encoding.Unicode);
		private MemoryStream m_objXmlMemStream;
		private XmlTextWriter m_objXmlWriter;
		public clsInPatientEvaluateDomain()
		{
			//
			// TODO: Add constructor logic here
			//
			m_objXmlMemStream = new MemoryStream(300);
			m_objXmlWriter = new XmlTextWriter(m_objXmlMemStream,System.Text.Encoding.Unicode);
			m_objXmlWriter.Flush();//清空原来的字符
		}
		///只需要查出时间
		public long m_lngGetAllRecordDateArr(string p_strInPatientID /*,string p_strInPatientDate*/,out string[] p_strDateArr)
		{
			p_strDateArr=null;

			string strXML = "";
			int intRows = 0;
            long lngResult = 0;

            clsInPatientEvaluateServ m_objServ =
                (clsInPatientEvaluateServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInPatientEvaluateServ));

            try
            {
                lngResult = m_objServ.m_lngGetAllRecordDateArr(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID,/*p_strInPatientDate*/out  strXML, out intRows);
                if (intRows > 0)
                {
                    string[] strDateArr = new string[intRows];

                    XmlTextReader objReader = new XmlTextReader(strXML, XmlNodeType.Element, m_objXmlParser);
                    objReader.WhitespaceHandling = WhitespaceHandling.None;

                    int intIndex = 0;
                    while (objReader.Read())
                    {
                        switch (objReader.NodeType)
                        {
                            case XmlNodeType.Element:
                                if (objReader.HasAttributes)
                                {
                                    strDateArr[intIndex++] = objReader.GetAttribute("INPATIENTDATE");//此时查找住院时间，而非创建时间								
                                }
                                break;
                        }
                    }
                    p_strDateArr = strDateArr;
                }
            }
            finally
            {
                //m_objServ.Dispose();
            }
			return lngResult;		
		}		

		///提取主表信息
		private clsInPatientEvaluate m_objGetLatestRecord(string p_strXML,int p_intRows,string p_strInPatientID,string p_strInPatientDate)
		{			
			if(p_intRows>0)//p_intRows==1
			{
				clsInPatientEvaluate objclsInPatientEvaluate=new clsInPatientEvaluate();

				XmlTextReader objReader = new XmlTextReader(p_strXML,XmlNodeType.Element,m_objXmlParser);
				objReader.WhitespaceHandling = WhitespaceHandling.None;			
				
				while(objReader.Read())
				{
					switch(objReader.NodeType)
					{
						case XmlNodeType.Element:
							if(objReader.HasAttributes)
							{												
								objclsInPatientEvaluate.m_strInPatientID= p_strInPatientID;								
								objclsInPatientEvaluate.m_strInPatientDate= p_strInPatientDate;
								objclsInPatientEvaluate.m_strOpenDate= objReader.GetAttribute("OPENDATE");//p_strOpenDate;
								objclsInPatientEvaluate.m_strCreateDate= objReader.GetAttribute("CREATEDATE");//
								objclsInPatientEvaluate.m_strCreateUserID= objReader.GetAttribute("CREATEUSERID");

								objclsInPatientEvaluate.m_strEducation= objReader.GetAttribute("EDUCATION");
								objclsInPatientEvaluate.m_strReligion= objReader.GetAttribute("RELIGION");
								objclsInPatientEvaluate.m_strReligionContent= objReader.GetAttribute("RELIGIONCONTENT").Replace('き','\'');
								objclsInPatientEvaluate.m_strDataFrom= objReader.GetAttribute("DATAFROM");
								objclsInPatientEvaluate.m_strDataFromOtherContent= objReader.GetAttribute("DATAFROMOTHERCONTENT").Replace('き','\'');

								objclsInPatientEvaluate.m_strInPatientDiagnoseXML= objReader.GetAttribute("INPATIENTDIAGNOSEXML").Replace('き','\'');	
						
								#region DataTable对应的字段XML
								objclsInPatientEvaluate.m_strInPatientMode_TableXML= objReader.GetAttribute("INPATIENTMODE_TABLEXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strAllergicHistory_TableXML= objReader.GetAttribute("ALLERGICHISTORY_TABLEXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strAppetite_TableXML= objReader.GetAttribute("APPETITE_TABLEXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strWeight_TableXML= objReader.GetAttribute("WEIGHT_TABLEXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strMouth_TableXML= objReader.GetAttribute("MOUTH_TABLEXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strChaw_TableXML= objReader.GetAttribute("CHAW_TABLEXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strDeglutition_TableXML= objReader.GetAttribute("DEGLUTITION_TABLEXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strStomach_TableXML= objReader.GetAttribute("STOMACH_TABLEXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strSkin_TableXML= objReader.GetAttribute("SKIN_TABLEXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strChogh_TableXML= objReader.GetAttribute("CHOGH_TABLEXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strPhlegm_TableXML= objReader.GetAttribute("PHLEGM_TABLEXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strDejecta_TableXML= objReader.GetAttribute("DEJECTA_TABLEXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strPee_TableXML= objReader.GetAttribute("PEE_TABLEXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strCanMyself_TableXML= objReader.GetAttribute("CANMYSELF_TABLEXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strBreathUrge_TableXML= objReader.GetAttribute("BREATHURGE_TABLEXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strLimbActive_TableXML= objReader.GetAttribute("LIMBACTIVE_TABLEXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strSleep_TableXML= objReader.GetAttribute("SLEEP_TABLEXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strAssistantSleep_TableXML= objReader.GetAttribute("ASSISTANTSLEEP_TABLEXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strShout_TableXML= objReader.GetAttribute("SHOUT_TABLEXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strAnswer_TableXML= objReader.GetAttribute("ANSWER_TABLEXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strSeeingBalk_TableXML= objReader.GetAttribute("SEEINGBALK_TABLEXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strListenBalk_TableXML= objReader.GetAttribute("LISTENBALK_TABLEXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strAche_TableXML= objReader.GetAttribute("ACHE_TABLEXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strLanguage_TableXML= objReader.GetAttribute("LANGUAGE_TABLEXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strInHospitalFeel_TableXML= objReader.GetAttribute("INHOSPITALFEEL_TABLEXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strLookIn_TableXML= objReader.GetAttribute("LOOKIN_TABLEXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strEconomic_TableXML= objReader.GetAttribute("ECONOMIC_TABLEXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strIllnessUnderstand_TableXML= objReader.GetAttribute("ILLNESSUNDERSTAND_TABLEXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strDoctorsAdvice_TableXML= objReader.GetAttribute("DOCTORSADVICE_TABLEXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strSmoking_TableXML= objReader.GetAttribute("SMOKING_TABLEXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strDrink_TableXML= objReader.GetAttribute("DRINK_TABLEXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strFreakOut_TableXML= objReader.GetAttribute("FREAKOUT_TABLEXML").Replace('き','\'');
								#endregion							
								
								objclsInPatientEvaluate.m_strAllergicSourceXML= objReader.GetAttribute("ALLERGICSOURCEXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strAllergicSymptomXML= objReader.GetAttribute("ALLERGICSYMPTOMXML").Replace('き','\'');	
								objclsInPatientEvaluate.m_strHowMuchWeightXML= objReader.GetAttribute("HOWMUCHWEIGHTXML").Replace('き','\'');	
								objclsInPatientEvaluate.m_strStomachColorXML= objReader.GetAttribute("STOMACHCOLORXML").Replace('き','\'');	
								objclsInPatientEvaluate.m_strStomachCharacterXML= objReader.GetAttribute("STOMACHCHARACTERXML").Replace('き','\'');	
								objclsInPatientEvaluate.m_strStomachTimesXML= objReader.GetAttribute("STOMACHTIMESXML").Replace('き','\'');									
								objclsInPatientEvaluate.m_strStomachQtyXML= objReader.GetAttribute("STOMACHQTYXML").Replace('き','\'');	
								objclsInPatientEvaluate.m_strBodyXML= objReader.GetAttribute("BODYXML").Replace('き','\'');	
								objclsInPatientEvaluate.m_strSkinOtherContentXML= objReader.GetAttribute("SKINOTHERCONTENTXML").Replace('き','\'');	
								objclsInPatientEvaluate.m_strPhlegmColorXML= objReader.GetAttribute("PHLEGMCOLORXML").Replace('き','\'');	
								objclsInPatientEvaluate.m_strDejectaTimesInOneDayXML= objReader.GetAttribute("DEJECTATIMESINONEDAYXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strDejectaHowManyDaysOnceXML= objReader.GetAttribute("DEJECTAHOWMANYDAYSONCEXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strDejectaCharacterXML= objReader.GetAttribute("DEJECTACHARACTERXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strPeeOtherContentXML= objReader.GetAttribute("PEEOTHERCONTENTXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strParalysisPartXML= objReader.GetAttribute("PARALYSISPARTXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strSleepHoursXML= objReader.GetAttribute("SLEEPHOURSXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strSleepOtherContentXML= objReader.GetAttribute("SLEEPOTHERCONTENTXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strAssistantSleepMedicinesXML= objReader.GetAttribute("ASSISTANTSLEEPMEDICINESXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strAssistantSleepModelXML= objReader.GetAttribute("ASSISTANTSLEEPMODELXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strLeftEyeOtherContentXML= objReader.GetAttribute("LEFTEYEOTHERCONTENTXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strRightEyeOtherContentXML= objReader.GetAttribute("RIGHTEYEOTHERCONTENTXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strBothEyeOtherContentXML= objReader.GetAttribute("BOTHEYEOTHERCONTENTXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strLeftListenOtherContentXML= objReader.GetAttribute("LEFTLISTENOTHERCONTENTXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strRightListenOtherContentXML= objReader.GetAttribute("RIGHTLISTENOTHERCONTENTXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strBothListenOtherContentXML= objReader.GetAttribute("BOTHLISTENOTHERCONTENTXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strAchePartXML= objReader.GetAttribute("ACHEPARTXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strAlwayslanguageXML= objReader.GetAttribute("ALWAYSLANGUAGEXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strDoctorsAdviceContentXML= objReader.GetAttribute("DOCTORSADVICECONTENTXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strSmokingYearsXML= objReader.GetAttribute("SMOKINGYEARSXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strSmokingQtyOneDayXML= objReader.GetAttribute("SMOKINGQTYONEDAYXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strDrinkYearsXML= objReader.GetAttribute("DRINKYEARSXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strDrinkQtyOneDayXML= objReader.GetAttribute("DRINKQTYONEDAYXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strFreakOutMedicinesXML= objReader.GetAttribute("FREAKOUTMEDICINESXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strFreakOutYearsXML= objReader.GetAttribute("FREAKOUTYEARSXML").Replace('き','\'');
								objclsInPatientEvaluate.m_strFreakOutQtyOneDayXML= objReader.GetAttribute("FREAKOUTQTYONEDAYXML").Replace('き','\'');
								
								objclsInPatientEvaluate.m_strIfConfirm= objReader.GetAttribute("IFCONFIRM");	
								objclsInPatientEvaluate.m_strConfirmReason= objReader.GetAttribute("CONFIRMREASON").Replace('き','\'');	
								objclsInPatientEvaluate.m_strConfirmReasonXML= objReader.GetAttribute("CONFIRMREASONXML").Replace('き','\'');									
														
							}
							break;
					}
				}
				
				return objclsInPatientEvaluate;
			}
			return null;		
		}

		///提取从表信息
		private clsInPatientEvaluateContent m_objGetLatestRecordContent(string p_strXML,int p_intRows,string p_strInPatientID,string p_strInPatientDate)
		{			
			if(p_intRows>0)//p_intRows==1
			{
				clsInPatientEvaluateContent objclsInPatientEvaluateContent=new clsInPatientEvaluateContent();

				XmlTextReader objReader = new XmlTextReader(p_strXML,XmlNodeType.Element,m_objXmlParser);
				objReader.WhitespaceHandling = WhitespaceHandling.None;			
				
				while(objReader.Read())
				{
					switch(objReader.NodeType)
					{
						case XmlNodeType.Element:
							if(objReader.HasAttributes)
							{											
								objclsInPatientEvaluateContent.m_strInPatientID= p_strInPatientID;
								objclsInPatientEvaluateContent.m_strInPatientDate= p_strInPatientDate;
								objclsInPatientEvaluateContent.m_strOpenDate= objReader.GetAttribute("OPENDATE");	

								objclsInPatientEvaluateContent.m_strModifyDate= objReader.GetAttribute("MODIFYDATE");	
								objclsInPatientEvaluateContent.m_strModifyUserID= objReader.GetAttribute("MODIFYUSERID");
														
								objclsInPatientEvaluateContent.m_strInPatientDiagnose= objReader.GetAttribute("INPATIENTDIAGNOSE").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strInPatientMode= objReader.GetAttribute("INPATIENTMODE").Replace('き','\'');
								objclsInPatientEvaluateContent.m_strAllergicHistory= objReader.GetAttribute("ALLERGICHISTORY").Replace('き','\'');		
								objclsInPatientEvaluateContent.m_strAllergicSource= objReader.GetAttribute("ALLERGICSOURCE").Replace('き','\'');
								objclsInPatientEvaluateContent.m_strAllergicSymptom= objReader.GetAttribute("ALLERGICSYMPTOM").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strAppetite= objReader.GetAttribute("APPETITE").Replace('き','\'');		
								objclsInPatientEvaluateContent.m_strWeight= objReader.GetAttribute("WEIGHT").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strHowMuchWeight= objReader.GetAttribute("HOWMUCHWEIGHT").Replace('き','\'');		
								objclsInPatientEvaluateContent.m_strMouth= objReader.GetAttribute("MOUTH").Replace('き','\'');		
								objclsInPatientEvaluateContent.m_strChaw= objReader.GetAttribute("CHAW").Replace('き','\'');	

								objclsInPatientEvaluateContent.m_strDeglutition= objReader.GetAttribute("DEGLUTITION").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strStomachNothing= objReader.GetAttribute("STOMACHNOTHING").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strStomachRise= objReader.GetAttribute("STOMACHRISE").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strStomachAche= objReader.GetAttribute("STOMACHACHE").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strStomachNaupathia= objReader.GetAttribute("STOMACHNAUPATHIA").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strStomachSpew= objReader.GetAttribute("STOMACHSPEW").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strStomachColor= objReader.GetAttribute("STOMACHCOLOR").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strStomachCharacter= objReader.GetAttribute("STOMACHCHARACTER").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strStomachTimes= objReader.GetAttribute("STOMACHTIMES").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strStomachQty= objReader.GetAttribute("STOMACHQTY").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strSkinFull= objReader.GetAttribute("SKINFULL").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strSkinPallor= objReader.GetAttribute("SKINPALLOR").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strSkinIcterus= objReader.GetAttribute("SKINICTERUS").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strSkinRed= objReader.GetAttribute("SKINRED").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strSkinCyanopathy= objReader.GetAttribute("SKINCYANOPATHY").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strSkinDehydrate= objReader.GetAttribute("SKINDEHYDRATE").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strSkinAnthema= objReader.GetAttribute("SKINANTHEMA").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strSkinBlood= objReader.GetAttribute("SKINBLOOD").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strSkinSore= objReader.GetAttribute("SKINSORE").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strSkinCut= objReader.GetAttribute("SKINCUT").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strSkinDropsy= objReader.GetAttribute("SKINDROPSY").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strBody= objReader.GetAttribute("BODY").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strUpperLimbs= objReader.GetAttribute("UPPERLIMBS").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strLowerLimbs= objReader.GetAttribute("LOWERLIMBS").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strSkinOther= objReader.GetAttribute("SKINOTHER").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strSkinOtherContent= objReader.GetAttribute("SKINOTHERCONTENT").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strChogh= objReader.GetAttribute("CHOGH").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strHavePhlegm= objReader.GetAttribute("HAVEPHLEGM").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strPhlegmEasy= objReader.GetAttribute("PHLEGMEASY").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strPhlegmChroma= objReader.GetAttribute("PHLEGMCHROMA").Replace('き','\'');	
																
								objclsInPatientEvaluateContent.m_strPhlegmColor= objReader.GetAttribute("PHLEGMCOLOR").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strDejectaTimesInOneDay= objReader.GetAttribute("DEJECTATIMESINONEDAY").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strDejectaHowManyDaysOnce= objReader.GetAttribute("DEJECTAHOWMANYDAYSONCE").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strDejectaIrretention= objReader.GetAttribute("DEJECTAIRRETENTION").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strDejectaFistula= objReader.GetAttribute("DEJECTAFISTULA").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strDejectaCharacter= objReader.GetAttribute("DEJECTACHARACTER").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strPeeIrretention= objReader.GetAttribute("PEEIRRETENTION").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strPeeNatural= objReader.GetAttribute("PEENATURAL").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strPeeUraemia= objReader.GetAttribute("PEEURAEMIA").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strPeeMuch= objReader.GetAttribute("PEEMUCH").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strPeeBlood= objReader.GetAttribute("PEEBLOOD").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strPeeCyst= objReader.GetAttribute("PEECYST").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strPeePipe= objReader.GetAttribute("PEEPIPE").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strPeeOther= objReader.GetAttribute("PEEOTHER").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strPeeOtherContent= objReader.GetAttribute("PEEOTHERCONTENT").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strCanMyself= objReader.GetAttribute("CANMYSELF").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strBreathUrge= objReader.GetAttribute("BREATHURGE").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strLimbActive= objReader.GetAttribute("LIMBACTIVE").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strParalysis= objReader.GetAttribute("PARALYSIS").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strParalysisPart= objReader.GetAttribute("PARALYSISPART").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strSleepHours= objReader.GetAttribute("SLEEPHOURS").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strSleepNothing= objReader.GetAttribute("SLEEPNOTHING").Replace('き','\'');																		
								objclsInPatientEvaluateContent.m_strSleepDifficulty= objReader.GetAttribute("SLEEPDIFFICULTY").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strSleepWakeEasy= objReader.GetAttribute("SLEEPWAKEEASY").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strSleepWakeEarly= objReader.GetAttribute("SLEEPWAKEEARLY").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strSleepDreamMuch= objReader.GetAttribute("SLEEPDREAMMUCH").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strSleepOther= objReader.GetAttribute("SLEEPOTHER").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strSleepOtherContent= objReader.GetAttribute("SLEEPOTHERCONTENT").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strAssistantSleep= objReader.GetAttribute("ASSISTANTSLEEP").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strAssistantSleepMedicines= objReader.GetAttribute("ASSISTANTSLEEPMEDICINES").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strAssistantSleepModel= objReader.GetAttribute("ASSISTANTSLEEPMODEL").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strShout= objReader.GetAttribute("SHOUT").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strAnswer= objReader.GetAttribute("ANSWER").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strSeeingBalk= objReader.GetAttribute("SEEINGBALK").Replace('き','\'');	
//								objclsInPatientEvaluateContent.m_strLeftRightEye= objReader.GetAttribute("LEFTRIGHTEYE").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strLeftEyeDown= objReader.GetAttribute("LEFTEYEDOWN").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strLeftEyeBlur= objReader.GetAttribute("LEFTEYEBLUR").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strLeftEyeAgain= objReader.GetAttribute("LEFTEYEAGAIN").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strLeftEyeOther= objReader.GetAttribute("LEFTEYEOTHER").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strLeftEyeOtherContent= objReader.GetAttribute("LEFTEYEOTHERCONTENT").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strRightEyeDown= objReader.GetAttribute("RIGHTEYEDOWN").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strRightEyeBlur= objReader.GetAttribute("RIGHTEYEBLUR").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strRightEyeAgain= objReader.GetAttribute("RIGHTEYEAGAIN").Replace('き','\'');	
																	
								objclsInPatientEvaluateContent.m_strRightEyeOther= objReader.GetAttribute("RIGHTEYEOTHER").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strRightEyeOtherContent= objReader.GetAttribute("RIGHTEYEOTHERCONTENT").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strBothEyeDown= objReader.GetAttribute("BOTHEYEDOWN").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strBothEyeBlur= objReader.GetAttribute("BOTHEYEBLUR").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strBothEyeAgain= objReader.GetAttribute("BOTHEYEAGAIN").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strBothEyeOther= objReader.GetAttribute("BOTHEYEOTHER").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strBothEyeOtherContent= objReader.GetAttribute("BOTHEYEOTHERCONTENT").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strListenBalk= objReader.GetAttribute("LISTENBALK").Replace('き','\'');	
//								objclsInPatientEvaluateContent.m_strLeftRightListen= objReader.GetAttribute("LEFTRIGHTLISTEN").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strLeftListenDown= objReader.GetAttribute("LEFTLISTENDOWN").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strLeftListenTinnitus= objReader.GetAttribute("LEFTLISTENTINNITUS").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strLeftListenAgain= objReader.GetAttribute("LEFTLISTENAGAIN").Replace('き','\'');	
																
								objclsInPatientEvaluateContent.m_strLeftListenOther= objReader.GetAttribute("LEFTLISTENOTHER").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strLeftListenOtherContent= objReader.GetAttribute("LEFTLISTENOTHERCONTENT").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strRightListenDown= objReader.GetAttribute("RIGHTLISTENDOWN").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strRightListenTinnitus= objReader.GetAttribute("RIGHTLISTENTINNITUS").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strRightListenAgain= objReader.GetAttribute("RIGHTLISTENAGAIN").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strRightListenOther= objReader.GetAttribute("RIGHTLISTENOTHER").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strRightListenOtherContent= objReader.GetAttribute("RIGHTLISTENOTHERCONTENT").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strBothListenDown= objReader.GetAttribute("BOTHLISTENDOWN").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strBothListenTinnitus= objReader.GetAttribute("BOTHLISTENTINNITUS").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strBothListenAgain= objReader.GetAttribute("BOTHLISTENAGAIN").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strBothListenOther= objReader.GetAttribute("BOTHLISTENOTHER").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strBothListenOtherContent= objReader.GetAttribute("BOTHLISTENOTHERCONTENT").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strAche= objReader.GetAttribute("ACHE").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strAchePart= objReader.GetAttribute("ACHEPART").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strAcheTimes= objReader.GetAttribute("ACHETIMES").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strAlwayslanguage= objReader.GetAttribute("ALWAYSLANGUAGE").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strMandarin= objReader.GetAttribute("MANDARIN").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strCantSay= objReader.GetAttribute("CANTSAY").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strInHospitalFeel= objReader.GetAttribute("INHOSPITALFEEL").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strLookIn= objReader.GetAttribute("LOOKIN").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strEconomic= objReader.GetAttribute("ECONOMIC").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strIllnessUnderstand= objReader.GetAttribute("ILLNESSUNDERSTAND").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strDoctorsAdvice= objReader.GetAttribute("DOCTORSADVICE").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strDoctorsAdviceContent= objReader.GetAttribute("DOCTORSADVICECONTENT").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strIfSmoking= objReader.GetAttribute("IFSMOKING").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strSmokingYears= objReader.GetAttribute("SMOKINGYEARS").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strSmokingQtyOneDay= objReader.GetAttribute("SMOKINGQTYONEDAY").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strIfDrink= objReader.GetAttribute("IFDRINK").Replace('き','\'');	
								objclsInPatientEvaluateContent.m_strDrinkYears= objReader.GetAttribute("DRINKYEARS").Replace('き','\'');									
								objclsInPatientEvaluateContent.m_strDrinkQtyOneDay= objReader.GetAttribute("DRINKQTYONEDAY").Replace('き','\'');		
								objclsInPatientEvaluateContent.m_strFreakOut= objReader.GetAttribute("FREAKOUT").Replace('き','\'');
								objclsInPatientEvaluateContent.m_strFreakOutMedicines= objReader.GetAttribute("FREAKOUTMEDICINES").Replace('き','\'');
								objclsInPatientEvaluateContent.m_strFreakOutYears= objReader.GetAttribute("FREAKOUTYEARS").Replace('き','\'');
								objclsInPatientEvaluateContent.m_strFreakOutQtyOneDay= objReader.GetAttribute("FREAKOUTQTYONEDAY").Replace('き','\'');
								objclsInPatientEvaluateContent.m_strAbonrmalDesc= objReader.GetAttribute("ABONRMALDESC").Replace('き','\'');
								objclsInPatientEvaluateContent.m_strChargeNurseID = objReader.GetAttribute("CHARGENURSEID").Replace('き','\'');
								objclsInPatientEvaluateContent.m_strCheckTime = objReader.GetAttribute("CHECKTIME").Replace('き','\'');
								
							}
							break;
					}
				}		
				return objclsInPatientEvaluateContent;
			}
			return null;			
		}
		
		public long m_lngGetLatestRecord_All(string p_strInPatientID,string p_strInPatientDate,out clsInPatientEvaluate_All p_objclsInPatientEvaluate_All)
		{
			p_objclsInPatientEvaluate_All=null; 

			string strXML = "";
			int intRows = 0;
			string strContentXML="";
			int intContentRows=0;
			long lngResult = 0;

            clsInPatientEvaluateServ m_objServ =
                (clsInPatientEvaluateServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInPatientEvaluateServ));

            try
            {
                lngResult = m_objServ.m_lngGetLatestRecord_All(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate/*,p_strOpenDate*/, out  strXML, out intRows, out strContentXML, out intContentRows);
                if (lngResult > 0)
                {
                    p_objclsInPatientEvaluate_All = new clsInPatientEvaluate_All();
                    p_objclsInPatientEvaluate_All.m_objclsInPatientEvaluate = m_objGetLatestRecord(strXML, intRows, p_strInPatientID, p_strInPatientDate);
                    p_objclsInPatientEvaluate_All.m_objclsInPatientEvaluateContent = m_objGetLatestRecordContent(strContentXML, intContentRows, p_strInPatientID, p_strInPatientDate);
                }
            }
            finally
            {
                //m_objServ.Dispose();
            }
			return lngResult;
		}
		
		public long m_lngGetLatestDeleteRecord_All(string p_strInPatientID,string p_strInPatientDate,string p_strOpenDate,out clsInPatientEvaluate_All p_objclsInPatientEvaluate_All)
		{
			p_objclsInPatientEvaluate_All=null; 

			string strXML = "";
			int intRows = 0;
			string strContentXML="";
			int intContentRows=0;
            long lngResult = 0;

            clsInPatientEvaluateServ m_objServ =
                (clsInPatientEvaluateServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInPatientEvaluateServ));

            try
            {
                lngResult = m_objServ.m_lngGetLatestDeleteRecord_All(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_strOpenDate, out  strXML, out intRows, out strContentXML, out intContentRows);
                if (lngResult > 0)
                {
                    p_objclsInPatientEvaluate_All = new clsInPatientEvaluate_All();
                    p_objclsInPatientEvaluate_All.m_objclsInPatientEvaluate = m_objGetLatestRecord(strXML, intRows, p_strInPatientID, p_strInPatientDate);
                    p_objclsInPatientEvaluate_All.m_objclsInPatientEvaluateContent = m_objGetLatestRecordContent(strContentXML, intContentRows, p_strInPatientID, p_strInPatientDate);
                }
            }
            finally
            {
                //m_objServ.Dispose();
            }
			return lngResult;
		}

		public long m_lngGetAbnormalInfo(string p_strInPatientID,string p_strInPatientDate,out string p_strAbnormalInfo)
		{
			long lngResult = 0;

            clsInPatientEvaluateServ m_objServ =
                (clsInPatientEvaluateServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInPatientEvaluateServ));

            try
            {
                lngResult = m_objServ.m_lngGetAbnormalInfo(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate,out p_strAbnormalInfo);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngResult;
		}

		/// 保存信息		
		public long m_lngSave(clsInPatientEvaluate p_objclsInPatientEvaluate,clsInPatientEvaluateContent p_objclsInPatientEvaluateContent,bool p_blnIsAddNew)
		{
//			//把白色变为黑色
//			clsXML_DataGrid objclsXML_DataGrid=new clsXML_DataGrid();
//			p_objclsInPatientEvaluate.m_strAche_TableXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strAche_TableXML);
//			p_objclsInPatientEvaluate.m_strAchePartXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strAchePartXML);
//			p_objclsInPatientEvaluate.m_strAllergicHistory_TableXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strAllergicHistory_TableXML);
//			p_objclsInPatientEvaluate.m_strAllergicSourceXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strAllergicSourceXML);
//			p_objclsInPatientEvaluate.m_strAllergicSymptomXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strAllergicSymptomXML);
//			p_objclsInPatientEvaluate.m_strAlwayslanguageXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strAlwayslanguageXML);
//			p_objclsInPatientEvaluate.m_strAnswer_TableXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strAnswer_TableXML);
//			p_objclsInPatientEvaluate.m_strAppetite_TableXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strAppetite_TableXML);
//			p_objclsInPatientEvaluate.m_strAssistantSleep_TableXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strAssistantSleep_TableXML);
//			p_objclsInPatientEvaluate.m_strAssistantSleepMedicinesXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strAssistantSleepMedicinesXML);
//			p_objclsInPatientEvaluate.m_strAssistantSleepModelXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strAssistantSleepModelXML);
//			p_objclsInPatientEvaluate.m_strBodyXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strBodyXML);
//			p_objclsInPatientEvaluate.m_strBothEyeOtherContentXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strBothEyeOtherContentXML);
//			p_objclsInPatientEvaluate.m_strBothListenOtherContentXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strBothListenOtherContentXML);
//			p_objclsInPatientEvaluate.m_strBreathUrge_TableXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strBreathUrge_TableXML);
//			p_objclsInPatientEvaluate.m_strCanMyself_TableXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strCanMyself_TableXML);
//			p_objclsInPatientEvaluate.m_strChaw_TableXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strChaw_TableXML);
//			p_objclsInPatientEvaluate.m_strChogh_TableXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strChogh_TableXML);
//			p_objclsInPatientEvaluate.m_strConfirmReasonXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strConfirmReasonXML);
//			p_objclsInPatientEvaluate.m_strDeglutition_TableXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strDeglutition_TableXML);
//			p_objclsInPatientEvaluate.m_strDejecta_TableXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strDejecta_TableXML);
//			p_objclsInPatientEvaluate.m_strDejectaCharacterXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strDejectaCharacterXML);
//			p_objclsInPatientEvaluate.m_strDejectaHowManyDaysOnceXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strDejectaHowManyDaysOnceXML);
//			p_objclsInPatientEvaluate.m_strDejectaTimesInOneDayXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strDejectaTimesInOneDayXML);
//			p_objclsInPatientEvaluate.m_strDoctorsAdvice_TableXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strDoctorsAdvice_TableXML);
//			p_objclsInPatientEvaluate.m_strDoctorsAdviceContentXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strDoctorsAdviceContentXML);
//			p_objclsInPatientEvaluate.m_strDrink_TableXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strDrink_TableXML);
//			p_objclsInPatientEvaluate.m_strDrinkQtyOneDayXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strDrinkQtyOneDayXML);
//			p_objclsInPatientEvaluate.m_strDrinkYearsXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strDrinkYearsXML);
//			p_objclsInPatientEvaluate.m_strEconomic_TableXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strEconomic_TableXML);
//			p_objclsInPatientEvaluate.m_strFreakOut_TableXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strFreakOut_TableXML);
//			p_objclsInPatientEvaluate.m_strFreakOutMedicinesXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strFreakOutMedicinesXML);
//			p_objclsInPatientEvaluate.m_strFreakOutQtyOneDayXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strFreakOutQtyOneDayXML);
//			p_objclsInPatientEvaluate.m_strFreakOutYearsXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strFreakOutYearsXML);
//			p_objclsInPatientEvaluate.m_strHowMuchWeightXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strHowMuchWeightXML);
//			p_objclsInPatientEvaluate.m_strIllnessUnderstand_TableXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strIllnessUnderstand_TableXML);
//			p_objclsInPatientEvaluate.m_strInHospitalFeel_TableXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strInHospitalFeel_TableXML);
//			p_objclsInPatientEvaluate.m_strInPatientDiagnoseXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strInPatientDiagnoseXML);
//			p_objclsInPatientEvaluate.m_strInPatientMode_TableXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strInPatientMode_TableXML);
//			p_objclsInPatientEvaluate.m_strLanguage_TableXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strLanguage_TableXML);
//			p_objclsInPatientEvaluate.m_strLeftEyeOtherContentXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strLeftEyeOtherContentXML);
//			p_objclsInPatientEvaluate.m_strLeftListenOtherContentXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strLeftListenOtherContentXML);
//			p_objclsInPatientEvaluate.m_strLimbActive_TableXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strLimbActive_TableXML);
//			p_objclsInPatientEvaluate.m_strListenBalk_TableXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strListenBalk_TableXML);
//			p_objclsInPatientEvaluate.m_strLookIn_TableXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strLookIn_TableXML);
//			p_objclsInPatientEvaluate.m_strMouth_TableXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strMouth_TableXML);
//			p_objclsInPatientEvaluate.m_strParalysisPartXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strParalysisPartXML);
//			p_objclsInPatientEvaluate.m_strPee_TableXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strPee_TableXML);
//			p_objclsInPatientEvaluate.m_strPeeOtherContentXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strPeeOtherContentXML);
//			p_objclsInPatientEvaluate.m_strPhlegm_TableXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strPhlegm_TableXML);
//			p_objclsInPatientEvaluate.m_strPhlegmColorXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strPhlegmColorXML);
//			p_objclsInPatientEvaluate.m_strRightEyeOtherContentXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strRightEyeOtherContentXML);
//			p_objclsInPatientEvaluate.m_strRightListenOtherContentXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strRightListenOtherContentXML);
//			p_objclsInPatientEvaluate.m_strSeeingBalk_TableXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strSeeingBalk_TableXML);
//			p_objclsInPatientEvaluate.m_strShout_TableXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strShout_TableXML);
//			p_objclsInPatientEvaluate.m_strSkin_TableXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strSkin_TableXML);
//			p_objclsInPatientEvaluate.m_strSkinOtherContentXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strSkinOtherContentXML);
//			p_objclsInPatientEvaluate.m_strSleep_TableXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strSleep_TableXML);
//			p_objclsInPatientEvaluate.m_strSleepHoursXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strSleepHoursXML);
//			p_objclsInPatientEvaluate.m_strSleepOtherContentXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strSleepOtherContentXML);
//			p_objclsInPatientEvaluate.m_strSmoking_TableXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strSmoking_TableXML);
//			p_objclsInPatientEvaluate.m_strSmokingQtyOneDayXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strSmokingQtyOneDayXML);
//			p_objclsInPatientEvaluate.m_strSmokingYearsXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strSmokingYearsXML);
//			p_objclsInPatientEvaluate.m_strStomach_TableXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strStomach_TableXML);
//			p_objclsInPatientEvaluate.m_strStomachCharacterXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strStomachCharacterXML);
//			p_objclsInPatientEvaluate.m_strStomachColorXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strStomachColorXML);
//			p_objclsInPatientEvaluate.m_strStomachQtyXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strStomachQtyXML);
//			p_objclsInPatientEvaluate.m_strStomachTimesXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strStomachTimesXML);
//			p_objclsInPatientEvaluate.m_strWeight_TableXML=objclsXML_DataGrid.m_strReplaceWhiteToBlack( p_objclsInPatientEvaluate.m_strWeight_TableXML);
//			
            long lngResult = 0;

            clsInPatientEvaluateServ m_objServ =
                (clsInPatientEvaluateServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInPatientEvaluateServ));

            try
            {
                if (p_blnIsAddNew == true)
                    lngResult = m_objServ.m_lngAddNew(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, m_strGetMainXML(p_objclsInPatientEvaluate), m_strGetSubXML(p_objclsInPatientEvaluateContent));
                else
                    lngResult = m_objServ.m_lngModify(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, m_strGetMainXML(p_objclsInPatientEvaluate), m_strGetSubXML(p_objclsInPatientEvaluateContent));
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngResult;
		}

		private string m_strGetMainXML(clsInPatientEvaluate p_objclsInPatientEvaluate)
		{
			m_objXmlMemStream.SetLength(0);
			
			m_objXmlWriter.WriteStartDocument();
			m_objXmlWriter.WriteStartElement("Model");
			m_objXmlWriter.WriteAttributeString("INPATIENTID", p_objclsInPatientEvaluate.m_strInPatientID);
			m_objXmlWriter.WriteAttributeString("INPATIENTDATE", p_objclsInPatientEvaluate.m_strInPatientDate);
			m_objXmlWriter.WriteAttributeString("OPENDATE", p_objclsInPatientEvaluate.m_strOpenDate);
			m_objXmlWriter.WriteAttributeString("CREATEDATE", p_objclsInPatientEvaluate.m_strCreateDate);
			m_objXmlWriter.WriteAttributeString("CREATEUSERID", p_objclsInPatientEvaluate.m_strCreateUserID);

			#region DataTable对应的字段XML
			m_objXmlWriter.WriteAttributeString("INPATIENTMODE_TABLEXML", p_objclsInPatientEvaluate.m_strInPatientMode_TableXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("ALLERGICHISTORY_TABLEXML", p_objclsInPatientEvaluate.m_strAllergicHistory_TableXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("APPETITE_TABLEXML", p_objclsInPatientEvaluate.m_strAppetite_TableXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("WEIGHT_TABLEXML", p_objclsInPatientEvaluate.m_strWeight_TableXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("MOUTH_TABLEXML", p_objclsInPatientEvaluate.m_strMouth_TableXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("CHAW_TABLEXML", p_objclsInPatientEvaluate.m_strChaw_TableXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("DEGLUTITION_TABLEXML", p_objclsInPatientEvaluate.m_strDeglutition_TableXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("STOMACH_TABLEXML", p_objclsInPatientEvaluate.m_strStomach_TableXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SKIN_TABLEXML", p_objclsInPatientEvaluate.m_strSkin_TableXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("CHOGH_TABLEXML", p_objclsInPatientEvaluate.m_strChogh_TableXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("PHLEGM_TABLEXML", p_objclsInPatientEvaluate.m_strPhlegm_TableXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("DEJECTA_TABLEXML", p_objclsInPatientEvaluate.m_strDejecta_TableXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("PEE_TABLEXML", p_objclsInPatientEvaluate.m_strPee_TableXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("CANMYSELF_TABLEXML", p_objclsInPatientEvaluate.m_strCanMyself_TableXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("BREATHURGE_TABLEXML", p_objclsInPatientEvaluate.m_strBreathUrge_TableXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("LIMBACTIVE_TABLEXML", p_objclsInPatientEvaluate.m_strLimbActive_TableXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SLEEP_TABLEXML", p_objclsInPatientEvaluate.m_strSleep_TableXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("ASSISTANTSLEEP_TABLEXML", p_objclsInPatientEvaluate.m_strAssistantSleep_TableXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SHOUT_TABLEXML", p_objclsInPatientEvaluate.m_strShout_TableXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("ANSWER_TABLEXML", p_objclsInPatientEvaluate.m_strAnswer_TableXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SEEINGBALK_TABLEXML", p_objclsInPatientEvaluate.m_strSeeingBalk_TableXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("LISTENBALK_TABLEXML", p_objclsInPatientEvaluate.m_strListenBalk_TableXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("ACHE_TABLEXML", p_objclsInPatientEvaluate.m_strAche_TableXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("LANGUAGE_TABLEXML", p_objclsInPatientEvaluate.m_strLanguage_TableXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("INHOSPITALFEEL_TABLEXML", p_objclsInPatientEvaluate.m_strInHospitalFeel_TableXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("LOOKIN_TABLEXML", p_objclsInPatientEvaluate.m_strLookIn_TableXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("ECONOMIC_TABLEXML", p_objclsInPatientEvaluate.m_strEconomic_TableXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("ILLNESSUNDERSTAND_TABLEXML", p_objclsInPatientEvaluate.m_strIllnessUnderstand_TableXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("DOCTORSADVICE_TABLEXML", p_objclsInPatientEvaluate.m_strDoctorsAdvice_TableXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SMOKING_TABLEXML", p_objclsInPatientEvaluate.m_strSmoking_TableXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("DRINK_TABLEXML", p_objclsInPatientEvaluate.m_strDrink_TableXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("FREAKOUT_TABLEXML", p_objclsInPatientEvaluate.m_strFreakOut_TableXML.Replace('\'','き'));
			#endregion

			m_objXmlWriter.WriteAttributeString("EDUCATION", p_objclsInPatientEvaluate.m_strEducation);
			m_objXmlWriter.WriteAttributeString("RELIGION", p_objclsInPatientEvaluate.m_strReligion);
			m_objXmlWriter.WriteAttributeString("RELIGIONCONTENT", p_objclsInPatientEvaluate.m_strReligionContent.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("DATAFROM", p_objclsInPatientEvaluate.m_strDataFrom);
			m_objXmlWriter.WriteAttributeString("DATAFROMOTHERCONTENT", p_objclsInPatientEvaluate.m_strDataFromOtherContent.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("INPATIENTDIAGNOSEXML", p_objclsInPatientEvaluate.m_strInPatientDiagnoseXML.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("ALLERGICSOURCEXML", p_objclsInPatientEvaluate.m_strAllergicSourceXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("ALLERGICSYMPTOMXML", p_objclsInPatientEvaluate.m_strAllergicSymptomXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("HOWMUCHWEIGHTXML", p_objclsInPatientEvaluate.m_strHowMuchWeightXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("STOMACHCOLORXML", p_objclsInPatientEvaluate.m_strStomachColorXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("STOMACHCHARACTERXML", p_objclsInPatientEvaluate.m_strStomachCharacterXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("STOMACHTIMESXML", p_objclsInPatientEvaluate.m_strStomachTimesXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("STOMACHQTYXML", p_objclsInPatientEvaluate.m_strStomachQtyXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("BODYXML", p_objclsInPatientEvaluate.m_strBodyXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SKINOTHERCONTENTXML", p_objclsInPatientEvaluate.m_strSkinOtherContentXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("PHLEGMCOLORXML", p_objclsInPatientEvaluate.m_strPhlegmColorXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("DEJECTATIMESINONEDAYXML", p_objclsInPatientEvaluate.m_strDejectaTimesInOneDayXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("DEJECTAHOWMANYDAYSONCEXML", p_objclsInPatientEvaluate.m_strDejectaHowManyDaysOnceXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("DEJECTACHARACTERXML", p_objclsInPatientEvaluate.m_strDejectaCharacterXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("PEEOTHERCONTENTXML", p_objclsInPatientEvaluate.m_strPeeOtherContentXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("PARALYSISPARTXML", p_objclsInPatientEvaluate.m_strParalysisPartXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SLEEPHOURSXML", p_objclsInPatientEvaluate.m_strSleepHoursXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SLEEPOTHERCONTENTXML", p_objclsInPatientEvaluate.m_strSleepOtherContentXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("ASSISTANTSLEEPMEDICINESXML", p_objclsInPatientEvaluate.m_strAssistantSleepMedicinesXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("ASSISTANTSLEEPMODELXML", p_objclsInPatientEvaluate.m_strAssistantSleepModelXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("LEFTEYEOTHERCONTENTXML", p_objclsInPatientEvaluate.m_strLeftEyeOtherContentXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("RIGHTEYEOTHERCONTENTXML", p_objclsInPatientEvaluate.m_strRightEyeOtherContentXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("BOTHEYEOTHERCONTENTXML", p_objclsInPatientEvaluate.m_strBothEyeOtherContentXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("LEFTLISTENOTHERCONTENTXML", p_objclsInPatientEvaluate.m_strLeftListenOtherContentXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("RIGHTLISTENOTHERCONTENTXML", p_objclsInPatientEvaluate.m_strRightListenOtherContentXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("BOTHLISTENOTHERCONTENTXML", p_objclsInPatientEvaluate.m_strBothListenOtherContentXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("ACHEPARTXML", p_objclsInPatientEvaluate.m_strAchePartXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("ALWAYSLANGUAGEXML", p_objclsInPatientEvaluate.m_strAlwayslanguageXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("DOCTORSADVICECONTENTXML", p_objclsInPatientEvaluate.m_strDoctorsAdviceContentXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SMOKINGYEARSXML", p_objclsInPatientEvaluate.m_strSmokingYearsXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SMOKINGQTYONEDAYXML", p_objclsInPatientEvaluate.m_strSmokingQtyOneDayXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("DRINKYEARSXML", p_objclsInPatientEvaluate.m_strDrinkYearsXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("DRINKQTYONEDAYXML", p_objclsInPatientEvaluate.m_strDrinkQtyOneDayXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("FREAKOUTMEDICINESXML", p_objclsInPatientEvaluate.m_strFreakOutMedicinesXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("FREAKOUTYEARSXML", p_objclsInPatientEvaluate.m_strFreakOutYearsXML.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("FREAKOUTQTYONEDAYXML", p_objclsInPatientEvaluate.m_strFreakOutQtyOneDayXML.Replace('\'','き'));
						
			m_objXmlWriter.WriteAttributeString("IFCONFIRM", "0");//p_objclsInPatientEvaluate.m_strIfConfirm);
			//暂无，备用			m_objXmlWriter.WriteAttributeString("CONFIRMREASON", p_objclsInPatientEvaluate.m_strConfirmReason.Replace('\'','き'));
			//暂无，备用			m_objXmlWriter.WriteAttributeString("CONFIRMREASONXML", p_objclsInPatientEvaluate.m_strConfirmReasonXML.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("STATUS", "0");
			m_objXmlWriter.WriteEndElement();
			m_objXmlWriter.WriteEndDocument();
			m_objXmlWriter.Flush();
			
			return System.Text.Encoding.Unicode.GetString(m_objXmlMemStream.ToArray(),39*2,(int)m_objXmlMemStream.Length-39*2);
		}

		private string m_strGetSubXML(clsInPatientEvaluateContent p_objclsInPatientEvaluateContent)
		{
			m_objXmlMemStream.SetLength(0);
			
			m_objXmlWriter.WriteStartDocument();
			m_objXmlWriter.WriteStartElement("Model");
			m_objXmlWriter.WriteAttributeString("INPATIENTID", p_objclsInPatientEvaluateContent.m_strInPatientID);
			m_objXmlWriter.WriteAttributeString("INPATIENTDATE", p_objclsInPatientEvaluateContent.m_strInPatientDate);
			m_objXmlWriter.WriteAttributeString("OPENDATE", p_objclsInPatientEvaluateContent.m_strOpenDate);
			m_objXmlWriter.WriteAttributeString("MODIFYDATE", p_objclsInPatientEvaluateContent.m_strModifyDate);
			m_objXmlWriter.WriteAttributeString("MODIFYUSERID", p_objclsInPatientEvaluateContent.m_strModifyUserID);

			m_objXmlWriter.WriteAttributeString("INPATIENTDIAGNOSE", p_objclsInPatientEvaluateContent.m_strInPatientDiagnose.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("INPATIENTMODE", p_objclsInPatientEvaluateContent.m_strInPatientMode.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("ALLERGICHISTORY", p_objclsInPatientEvaluateContent.m_strAllergicHistory.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("ALLERGICSOURCE", p_objclsInPatientEvaluateContent.m_strAllergicSource.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("ALLERGICSYMPTOM", p_objclsInPatientEvaluateContent.m_strAllergicSymptom.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("APPETITE", p_objclsInPatientEvaluateContent.m_strAppetite.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("WEIGHT", p_objclsInPatientEvaluateContent.m_strWeight.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("HOWMUCHWEIGHT", p_objclsInPatientEvaluateContent.m_strHowMuchWeight.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("MOUTH", p_objclsInPatientEvaluateContent.m_strMouth.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("CHAW", p_objclsInPatientEvaluateContent.m_strChaw.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("DEGLUTITION", p_objclsInPatientEvaluateContent.m_strDeglutition.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("STOMACHNOTHING", p_objclsInPatientEvaluateContent.m_strStomachNothing.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("STOMACHRISE", p_objclsInPatientEvaluateContent.m_strStomachRise.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("STOMACHACHE", p_objclsInPatientEvaluateContent.m_strStomachAche.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("STOMACHNAUPATHIA", p_objclsInPatientEvaluateContent.m_strStomachNaupathia.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("STOMACHSPEW", p_objclsInPatientEvaluateContent.m_strStomachSpew.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("STOMACHCOLOR", p_objclsInPatientEvaluateContent.m_strStomachColor.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("STOMACHCHARACTER", p_objclsInPatientEvaluateContent.m_strStomachCharacter.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("STOMACHTIMES", p_objclsInPatientEvaluateContent.m_strStomachTimes.Replace('\'','き'));												
			m_objXmlWriter.WriteAttributeString("STOMACHQTY", p_objclsInPatientEvaluateContent.m_strStomachQty.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SKINFULL", p_objclsInPatientEvaluateContent.m_strSkinFull.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SKINPALLOR", p_objclsInPatientEvaluateContent.m_strSkinPallor.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SKINICTERUS", p_objclsInPatientEvaluateContent.m_strSkinIcterus.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SKINRED", p_objclsInPatientEvaluateContent.m_strSkinRed.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SKINCYANOPATHY", p_objclsInPatientEvaluateContent.m_strSkinCyanopathy.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SKINDEHYDRATE", p_objclsInPatientEvaluateContent.m_strSkinDehydrate.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SKINANTHEMA", p_objclsInPatientEvaluateContent.m_strSkinAnthema.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SKINBLOOD", p_objclsInPatientEvaluateContent.m_strSkinBlood.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SKINSORE", p_objclsInPatientEvaluateContent.m_strSkinSore.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SKINCUT", p_objclsInPatientEvaluateContent.m_strSkinCut.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SKINDROPSY", p_objclsInPatientEvaluateContent.m_strSkinDropsy.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("BODY", p_objclsInPatientEvaluateContent.m_strBody.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("UPPERLIMBS", p_objclsInPatientEvaluateContent.m_strUpperLimbs.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("LOWERLIMBS", p_objclsInPatientEvaluateContent.m_strLowerLimbs.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SKINOTHER", p_objclsInPatientEvaluateContent.m_strSkinOther.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SKINOTHERCONTENT", p_objclsInPatientEvaluateContent.m_strSkinOtherContent.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("CHOGH", p_objclsInPatientEvaluateContent.m_strChogh.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("HAVEPHLEGM", p_objclsInPatientEvaluateContent.m_strHavePhlegm.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("PHLEGMEASY", p_objclsInPatientEvaluateContent.m_strPhlegmEasy.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("PHLEGMCHROMA", p_objclsInPatientEvaluateContent.m_strPhlegmChroma.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("PHLEGMCOLOR", p_objclsInPatientEvaluateContent.m_strPhlegmColor.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("DEJECTATIMESINONEDAY", p_objclsInPatientEvaluateContent.m_strDejectaTimesInOneDay.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("DEJECTAHOWMANYDAYSONCE", p_objclsInPatientEvaluateContent.m_strDejectaHowManyDaysOnce.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("DEJECTAIRRETENTION", p_objclsInPatientEvaluateContent.m_strDejectaIrretention.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("DEJECTAFISTULA", p_objclsInPatientEvaluateContent.m_strDejectaFistula.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("DEJECTACHARACTER", p_objclsInPatientEvaluateContent.m_strDejectaCharacter.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("PEEIRRETENTION", p_objclsInPatientEvaluateContent.m_strPeeIrretention.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("PEENATURAL", p_objclsInPatientEvaluateContent.m_strPeeNatural.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("PEEURAEMIA", p_objclsInPatientEvaluateContent.m_strPeeUraemia.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("PEEMUCH", p_objclsInPatientEvaluateContent.m_strPeeMuch.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("PEEBLOOD", p_objclsInPatientEvaluateContent.m_strPeeBlood.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("PEECYST", p_objclsInPatientEvaluateContent.m_strPeeCyst.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("PEEPIPE", p_objclsInPatientEvaluateContent.m_strPeePipe.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("PEEOTHER", p_objclsInPatientEvaluateContent.m_strPeeOther.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("PEEOTHERCONTENT", p_objclsInPatientEvaluateContent.m_strPeeOtherContent.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("CANMYSELF", p_objclsInPatientEvaluateContent.m_strCanMyself.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("BREATHURGE", p_objclsInPatientEvaluateContent.m_strBreathUrge.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("LIMBACTIVE", p_objclsInPatientEvaluateContent.m_strLimbActive.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("PARALYSIS", p_objclsInPatientEvaluateContent.m_strParalysis.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("PARALYSISPART", p_objclsInPatientEvaluateContent.m_strParalysisPart.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SLEEPHOURS", p_objclsInPatientEvaluateContent.m_strSleepHours.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SLEEPNOTHING", p_objclsInPatientEvaluateContent.m_strSleepNothing.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SLEEPDIFFICULTY", p_objclsInPatientEvaluateContent.m_strSleepDifficulty.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SLEEPWAKEEASY", p_objclsInPatientEvaluateContent.m_strSleepWakeEasy.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SLEEPWAKEEARLY", p_objclsInPatientEvaluateContent.m_strSleepWakeEarly.Replace('\'','き'));												
			m_objXmlWriter.WriteAttributeString("SLEEPDREAMMUCH", p_objclsInPatientEvaluateContent.m_strSleepDreamMuch.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SLEEPOTHER", p_objclsInPatientEvaluateContent.m_strSleepOther.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SLEEPOTHERCONTENT", p_objclsInPatientEvaluateContent.m_strSleepOtherContent.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("ASSISTANTSLEEP", p_objclsInPatientEvaluateContent.m_strAssistantSleep.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("ASSISTANTSLEEPMEDICINES", p_objclsInPatientEvaluateContent.m_strAssistantSleepMedicines.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("ASSISTANTSLEEPMODEL", p_objclsInPatientEvaluateContent.m_strAssistantSleepModel.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SHOUT", p_objclsInPatientEvaluateContent.m_strShout.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("ANSWER", p_objclsInPatientEvaluateContent.m_strAnswer.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SEEINGBALK", p_objclsInPatientEvaluateContent.m_strSeeingBalk.Replace('\'','き'));
//			m_objXmlWriter.WriteAttributeString("LEFTRIGHTEYE", p_objclsInPatientEvaluateContent.m_strLeftRightEye.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("LEFTEYEDOWN", p_objclsInPatientEvaluateContent.m_strLeftEyeDown.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("LEFTEYEBLUR", p_objclsInPatientEvaluateContent.m_strLeftEyeBlur.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("LEFTEYEAGAIN", p_objclsInPatientEvaluateContent.m_strLeftEyeAgain.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("LEFTEYEOTHER", p_objclsInPatientEvaluateContent.m_strLeftEyeOther.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("LEFTEYEOTHERCONTENT", p_objclsInPatientEvaluateContent.m_strLeftEyeOtherContent.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("RIGHTEYEDOWN", p_objclsInPatientEvaluateContent.m_strRightEyeDown.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("RIGHTEYEBLUR", p_objclsInPatientEvaluateContent.m_strRightEyeBlur.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("RIGHTEYEAGAIN", p_objclsInPatientEvaluateContent.m_strRightEyeAgain.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("RIGHTEYEOTHER", p_objclsInPatientEvaluateContent.m_strRightEyeOther.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("RIGHTEYEOTHERCONTENT", p_objclsInPatientEvaluateContent.m_strRightEyeOtherContent.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("BOTHEYEDOWN", p_objclsInPatientEvaluateContent.m_strBothEyeDown.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("BOTHEYEBLUR", p_objclsInPatientEvaluateContent.m_strBothEyeBlur.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("BOTHEYEAGAIN", p_objclsInPatientEvaluateContent.m_strBothEyeAgain.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("BOTHEYEOTHER", p_objclsInPatientEvaluateContent.m_strBothEyeOther.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("BOTHEYEOTHERCONTENT", p_objclsInPatientEvaluateContent.m_strBothEyeOtherContent.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("LISTENBALK", p_objclsInPatientEvaluateContent.m_strListenBalk.Replace('\'','き'));
//			m_objXmlWriter.WriteAttributeString("LEFTRIGHTLISTEN", p_objclsInPatientEvaluateContent.m_strLeftRightListen.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("LEFTLISTENDOWN", p_objclsInPatientEvaluateContent.m_strLeftListenDown.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("LEFTLISTENTINNITUS", p_objclsInPatientEvaluateContent.m_strLeftListenTinnitus.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("LEFTLISTENAGAIN", p_objclsInPatientEvaluateContent.m_strLeftListenAgain.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("LEFTLISTENOTHER", p_objclsInPatientEvaluateContent.m_strLeftListenOther.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("LEFTLISTENOTHERCONTENT", p_objclsInPatientEvaluateContent.m_strLeftListenOtherContent.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("RIGHTLISTENDOWN", p_objclsInPatientEvaluateContent.m_strRightListenDown.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("RIGHTLISTENTINNITUS", p_objclsInPatientEvaluateContent.m_strRightListenTinnitus.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("RIGHTLISTENAGAIN", p_objclsInPatientEvaluateContent.m_strRightListenAgain.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("RIGHTLISTENOTHER", p_objclsInPatientEvaluateContent.m_strRightListenOther.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("RIGHTLISTENOTHERCONTENT", p_objclsInPatientEvaluateContent.m_strRightListenOtherContent.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("BOTHLISTENDOWN", p_objclsInPatientEvaluateContent.m_strBothListenDown.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("BOTHLISTENTINNITUS", p_objclsInPatientEvaluateContent.m_strBothListenTinnitus.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("BOTHLISTENAGAIN", p_objclsInPatientEvaluateContent.m_strBothListenAgain.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("BOTHLISTENOTHER", p_objclsInPatientEvaluateContent.m_strBothListenOther.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("BOTHLISTENOTHERCONTENT", p_objclsInPatientEvaluateContent.m_strBothListenOtherContent.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("ACHE", p_objclsInPatientEvaluateContent.m_strAche.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("ACHEPART", p_objclsInPatientEvaluateContent.m_strAchePart.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("ACHETIMES", p_objclsInPatientEvaluateContent.m_strAcheTimes.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("ALWAYSLANGUAGE", p_objclsInPatientEvaluateContent.m_strAlwayslanguage.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("MANDARIN", p_objclsInPatientEvaluateContent.m_strMandarin.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("CANTSAY", p_objclsInPatientEvaluateContent.m_strCantSay.Replace('\'','き'));

			m_objXmlWriter.WriteAttributeString("INHOSPITALFEEL", p_objclsInPatientEvaluateContent.m_strInHospitalFeel.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("LOOKIN", p_objclsInPatientEvaluateContent.m_strLookIn.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("ECONOMIC", p_objclsInPatientEvaluateContent.m_strEconomic.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("ILLNESSUNDERSTAND", p_objclsInPatientEvaluateContent.m_strIllnessUnderstand.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("DOCTORSADVICE", p_objclsInPatientEvaluateContent.m_strDoctorsAdvice.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("DOCTORSADVICECONTENT", p_objclsInPatientEvaluateContent.m_strDoctorsAdviceContent.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("IFSMOKING", p_objclsInPatientEvaluateContent.m_strIfSmoking.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SMOKINGYEARS", p_objclsInPatientEvaluateContent.m_strSmokingYears.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SMOKINGQTYONEDAY", p_objclsInPatientEvaluateContent.m_strSmokingQtyOneDay.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("IFDRINK", p_objclsInPatientEvaluateContent.m_strIfDrink.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("DRINKYEARS", p_objclsInPatientEvaluateContent.m_strDrinkYears.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("DRINKQTYONEDAY", p_objclsInPatientEvaluateContent.m_strDrinkQtyOneDay.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("FREAKOUT", p_objclsInPatientEvaluateContent.m_strFreakOut.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("FREAKOUTMEDICINES", p_objclsInPatientEvaluateContent.m_strFreakOutMedicines.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("FREAKOUTYEARS", p_objclsInPatientEvaluateContent.m_strFreakOutYears.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("FREAKOUTQTYONEDAY", p_objclsInPatientEvaluateContent.m_strFreakOutQtyOneDay.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("ABONRMALDESC", p_objclsInPatientEvaluateContent.m_strAbonrmalDesc.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("CHARGENURSEID", p_objclsInPatientEvaluateContent.m_strChargeNurseID);
			m_objXmlWriter.WriteAttributeString("CHECKTIME", p_objclsInPatientEvaluateContent.m_strCheckTime);
												
			////不存在此字段，m_objXmlWriter.WriteAttributeString("STATUS", "0");
			m_objXmlWriter.WriteEndElement();
			m_objXmlWriter.WriteEndDocument();
			m_objXmlWriter.Flush();
			
			return System.Text.Encoding.Unicode.GetString(m_objXmlMemStream.ToArray(),39*2,(int)m_objXmlMemStream.Length-39*2);
		}

		/// <summary>
		/// //查询第一次打印时间
		/// </summary>		
		public long m_strGetFirstPrintDate(string p_strInPatientID,string p_strInPatientDate,/*string p_strOpenDate,*/out string p_strFirstPrintDate)
		{
			long lngResult = 0;

            clsInPatientEvaluateServ m_objServ =
                (clsInPatientEvaluateServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInPatientEvaluateServ));

            try
            {
                lngResult = m_objServ.m_lngGetFirstPrintDate(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate,/*p_strOpenDate,*/out p_strFirstPrintDate);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngResult;
		}

		/// <summary>
		/// 更新当前病人当次住院的首次打印时间（由于此单的一个入院日期仅有一个OpenDate，故不用OpenDate参数，即仅更新一条记录）
		/// </summary>		
		public long m_lngUpdateFirstPrintDate(string p_strInPatientID,string p_strInPatientDate/*,string p_strOpenDate*/)
		{//更新第一次打印时间		
			long lngResult = 0;

            clsInPatientEvaluateServ m_objServ =
                (clsInPatientEvaluateServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInPatientEvaluateServ));

            try
            {
                lngResult = m_objServ.m_lngUpdateFirstPrintDate(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate/*,p_strOpenDate*/);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngResult;
		}

		public long m_lngDelete(string p_strDeActivedOperatorID,string p_strInPatientID,string p_strInPatientDate/*,string p_strOpenDate*/)
		{			
			long lngResult = 0;

            clsInPatientEvaluateServ m_objServ =
                (clsInPatientEvaluateServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInPatientEvaluateServ));

            try
            {
                lngResult = m_objServ.m_lngDelete(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strDeActivedOperatorID,p_strInPatientID,p_strInPatientDate/*,p_strOpenDate*/);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngResult;
		}
	}

//	/// <summary>
//	/// 入院病人评估单主表的类
//	/// </summary>
//	[Serializable]
//	public class clsInPatientEvaluate
//	{
//		public string m_strInPatientID;
//		public string m_strInPatientDate;
//		public string m_strOpenDate;
//
//		public string m_strCreateDate;
//		public string m_strCreateUserID;
//		/// <summary>
//		/// tinyint型
//		/// </summary>
//		public string m_strEducation;
//		/// <summary>
//		/// bit型
//		/// </summary>
//		public string m_strReligion;
//		public string m_strReligionContent;
//		/// <summary>
//		/// tinyint型
//		/// </summary>
//		public string m_strDataFrom;
//		public string m_strDataFromOtherContent;
//
//		public string m_strInPatientDiagnoseXML;	
//		
//		public string m_strInPatientMode_TableXML;//DataGrid和GroupBox对应的表格XML
//		public string m_strAllergicHistory_TableXML;
//		public string m_strAppetite_TableXML;
//		public string m_strWeight_TableXML;
//		public string m_strMouth_TableXML;
//		public string m_strChaw_TableXML;
//		public string m_strDeglutition_TableXML;
//		public string m_strStomach_TableXML;
//		public string m_strSkin_TableXML;
//		public string m_strChogh_TableXML;
//		public string m_strPhlegm_TableXML;
//		public string m_strDejecta_TableXML;
//		public string m_strPee_TableXML;
//		public string m_strCanMyself_TableXML;
//		public string m_strBreathUrge_TableXML;
//		public string m_strLimbActive_TableXML;
//		public string m_strSleep_TableXML;
//		public string m_strAssistantSleep_TableXML;
//		public string m_strShout_TableXML;
//		public string m_strAnswer_TableXML;
//		public string m_strSeeingBalk_TableXML;
//		public string m_strListenBalk_TableXML;
//		public string m_strAche_TableXML;
//		public string m_strLanguage_TableXML;
//		public string m_strInHospitalFeel_TableXML;
//		public string m_strLookIn_TableXML;
//		public string m_strEconomic_TableXML;
//		public string m_strIllnessUnderstand_TableXML;
//		public string m_strDoctorsAdvice_TableXML;
//		public string m_strSmoking_TableXML;
//		public string m_strDrink_TableXML;
//		public string m_strFreakOut_TableXML;		
//
//		public string m_strAllergicSourceXML;		
//		public string m_strAllergicSymptomXML;		
//		public string m_strHowMuchWeightXML;		
//		public string m_strStomachColorXML;		
//		public string m_strStomachCharacterXML;		
//		public string m_strStomachTimesXML;		
//		public string m_strStomachQtyXML;
//		public string m_strBodyXML;
//		public string m_strSkinOtherContentXML;
//		public string m_strPhlegmColorXML;
//		public string m_strDejectaTimesInOneDayXML;
//		public string m_strDejectaHowManyDaysOnceXML;
//		public string m_strDejectaCharacterXML;
//		public string m_strPeeOtherContentXML;
//		public string m_strParalysisPartXML;
//		public string m_strSleepHoursXML;			
//		public string m_strSleepOtherContentXML ;
//		public string m_strAssistantSleepMedicinesXML ;
//		public string m_strAssistantSleepModelXML ;
//		public string m_strLeftEyeOtherContentXML ;
//		public string m_strRightEyeOtherContentXML ;
//		public string m_strBothEyeOtherContentXML ;
//		public string m_strLeftListenOtherContentXML ;
//		public string m_strRightListenOtherContentXML ;
//		public string m_strBothListenOtherContentXML ;
//		public string m_strAchePartXML ;
//		public string m_strAlwayslanguageXML ;
//		public string m_strDoctorsAdviceContentXML ;
//		public string m_strSmokingYearsXML ;
//		public string m_strSmokingQtyOneDayXML ;
//		public string m_strDrinkYearsXML ;
//		public string m_strDrinkQtyOneDayXML ;
//		public string m_strFreakOutMedicinesXML ;
//		public string m_strFreakOutYearsXML ;
//		public string m_strFreakOutQtyOneDayXML ;
//		
//		public string m_strIfConfirm;
//		public string m_strConfirmReason;	
//		public string m_strConfirmReasonXML ;			
//		
//	}
//
//	/// <summary>
//	/// 入院病人评估单从表的类
//	/// </summary>
//	[Serializable]
//	public class clsInPatientEvaluateContent
//	{
//		public string m_strInPatientID;
//		public string m_strInPatientDate;
//		public string m_strOpenDate;
//		public string m_strModifyDate;
//		public string m_strModifyUserID;
//		
//		public string m_strInPatientDiagnose;
//		public string m_strInPatientMode;
//		public string m_strAllergicHistory;
//		public string m_strAllergicSource;
//		public string m_strAllergicSymptom;
//		public string m_strAppetite;
//		public string m_strWeight;
//		public string m_strHowMuchWeight;
//		public string m_strMouth;
//		public string m_strChaw;
//		public string m_strDeglutition;
//		public string m_strStomachNothing;
//		public string m_strStomachRise;
//		public string m_strStomachAche;
//		public string m_strStomachNaupathia;
//		public string m_strStomachSpew;
//		public string m_strStomachColor;
//		public string m_strStomachCharacter;
//		public string m_strStomachTimes;
//		public string m_strStomachQty;
//		public string m_strSkinFull;
//		public string m_strSkinPallor;	
//		public string m_strSkinIcterus ;
//		public string m_strSkinRed ;
//		public string m_strSkinCyanopathy ;
//		public string m_strSkinDehydrate ;
//		public string m_strSkinAnthema ;
//		public string m_strSkinBlood ;
//		public string m_strSkinSore ;
//		public string m_strSkinCut ;
//		public string m_strSkinDropsy ;
//		public string m_strBody ;
//		public string m_strUpperLimbs ;
//		public string m_strLowerLimbs ;
//		public string m_strSkinOther ;
//		public string m_strSkinOtherContent ;
//		public string m_strChogh ;
//		public string m_strHavePhlegm ;
//		public string m_strPhlegmEasy ;
//		public string m_strPhlegmChroma ;
//		public string m_strPhlegmColor ;
//		public string m_strDejectaTimesInOneDay ;
//		public string m_strDejectaHowManyDaysOnce ;
//		public string m_strDejectaIrretention ;
//		public string m_strDejectaFistula ;
//		public string m_strDejectaCharacter ;
//		public string m_strPeeIrretention ;
//		public string m_strPeeNatural ;
//		public string m_strPeeUraemia ;
//		public string m_strPeeMuch ;
//		public string m_strPeeBlood ;
//		public string m_strPeeCyst ;
//		public string m_strPeePipe ;
//		public string m_strPeeOther ;
//		public string m_strPeeOtherContent ;
//		public string m_strCanMyself ;
//		public string m_strBreathUrge ;
//		public string m_strLimbActive ;
//		public string m_strParalysis ;
//		public string m_strParalysisPart ;
//		public string m_strSleepHours ;
//		public string m_strSleepNothing ;
//		public string m_strSleepDifficulty ;
//		public string m_strSleepWakeEasy ;
//		public string m_strSleepWakeEarly ;
//		public string m_strSleepDreamMuch ;
//		public string m_strSleepOther ;
//		public string m_strSleepOtherContent ;
//		public string m_strAssistantSleep ;
//		public string m_strAssistantSleepMedicines ;
//		public string m_strAssistantSleepModel ;
//		public string m_strShout ;
//		public string m_strAnswer ;
//		public string m_strSeeingBalk ;
////		public string m_strLeftRightEye ;
//		public string m_strLeftEyeDown ;
//		public string m_strLeftEyeBlur ;
//		public string m_strLeftEyeAgain ;
//		public string m_strLeftEyeOther ;
//		public string m_strLeftEyeOtherContent ;
//		public string m_strRightEyeDown ;
//		public string m_strRightEyeBlur ;
//		public string m_strRightEyeAgain ;
//		public string m_strRightEyeOther ;
//		public string m_strRightEyeOtherContent ;
//		public string m_strBothEyeDown ;
//		public string m_strBothEyeBlur ;
//		public string m_strBothEyeAgain ;
//		public string m_strBothEyeOther ;
//		public string m_strBothEyeOtherContent ;
//		public string m_strListenBalk ;
////		public string m_strLeftRightListen ;
//		public string m_strLeftListenDown ;
//		public string m_strLeftListenTinnitus ;
//		public string m_strLeftListenAgain ;
//		public string m_strLeftListenOther ;
//		public string m_strLeftListenOtherContent ;
//		public string m_strRightListenDown ;
//		public string m_strRightListenTinnitus ;
//		public string m_strRightListenAgain ;
//		public string m_strRightListenOther ;
//		public string m_strRightListenOtherContent ;
//		public string m_strBothListenDown ;
//		public string m_strBothListenTinnitus ;
//		public string m_strBothListenAgain ;
//		public string m_strBothListenOther ;
//		public string m_strBothListenOtherContent ;
//		public string m_strAche ;
//		public string m_strAchePart ;
//		public string m_strAcheTimes ;
//		public string m_strAlwayslanguage ;
//		public string m_strMandarin ;
//		public string m_strCantSay ;
//		public string m_strInHospitalFeel ;
//		public string m_strLookIn ;
//		public string m_strEconomic ;
//		public string m_strIllnessUnderstand ;
//		public string m_strDoctorsAdvice ;
//		public string m_strDoctorsAdviceContent ;
//		public string m_strIfSmoking ;
//		public string m_strSmokingYears ;
//		public string m_strSmokingQtyOneDay ;
//		public string m_strIfDrink ;
//		public string m_strDrinkYears ;
//		public string m_strDrinkQtyOneDay ;
//		public string m_strFreakOut ;
//		public string m_strFreakOutMedicines ;
//		public string m_strFreakOutYears ;
//		public string m_strFreakOutQtyOneDay ;
//		public string m_strAbonrmalDesc;//异常信息
//		public string m_strChargeNurseID ;		
//	}	
//
//	/// <summary>
//	/// 入院病人评估单所有信息的类
//	/// </summary>
//	[Serializable]
//	public class clsInPatientEvaluate_All
//	{
//		public clsInPatientEvaluate m_objclsInPatientEvaluate;
//		public clsInPatientEvaluateContent m_objclsInPatientEvaluateContent;
//	}
}
