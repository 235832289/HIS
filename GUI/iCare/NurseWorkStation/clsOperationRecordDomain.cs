using System;
using System.IO ;
using System .Xml ;
using com.digitalwave.OperationRecord ;
using iCareData;

namespace iCare
{
	/// <summary>
	/// 匯違擦尖芝Domain蚊
	/// </summary>
	public class clsOperationRecordDomain
	{
		#region 延楚式更夛痕方
		/// <summary>
		/// 伏撹Xml議産喝
		/// </summary>
		private MemoryStream m_objXmlMemStream;

		/// <summary>
		/// 伏撹Xml議垢醤
		/// </summary>
	
		private XmlTextWriter m_objXmlWriter;
		///  <summary>
		/// 響函Xml垢醤補秘歌方		
		/// </summary>
		private XmlParserContext m_objXmlParser;
        //private com.digitalwave.OperationRecord.clsOperationRecordServ   m_objServ;
		public clsOperationRecordDomain()
		{
			//
			// TODO: Add constructor logic here
			//
            //m_objServ=new com.digitalwave.OperationRecord.clsOperationRecordServ ();
			m_objXmlMemStream = new MemoryStream(300);

			m_objXmlWriter = new XmlTextWriter(m_objXmlMemStream,System.Text.Encoding.Unicode);
			m_objXmlWriter.Flush();//賠腎圻栖議忖憲
			m_objXmlParser = new XmlParserContext(null,null,null,XmlSpace.None,System.Text.Encoding.Unicode);
		}
		#endregion
		
		#region 響函匯倖頼屁芝村��Record||Content||OperationID||AnaesthesiaID||Nurse||WoundThing)
		public long  m_lngGetOperationRecord(string p_strInPatientID,string p_strInPatientDate,string p_strCreateDate,out clsOperationRecord objOperationRecordReturn)
		{ 
			objOperationRecordReturn=null;
			if(p_strInPatientID ==null||p_strInPatientID ==""||p_strInPatientDate==null||p_strInPatientDate=="" ||p_strCreateDate==null||p_strCreateDate=="")
				return 0;
			
			string strXml = "";
			int intRows = 0;
            long lngRes = 0;

            com.digitalwave.OperationRecord.clsOperationRecordServ m_objServ =
                (com.digitalwave.OperationRecord.clsOperationRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.OperationRecord.clsOperationRecordServ));

            try
            {
                lngRes = m_objServ.m_lngGetOperationRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_strCreateDate, out strXml, out intRows);

                if (lngRes > 0 && intRows > 0)
                {

                    XmlTextReader objReader = new XmlTextReader(strXml, XmlNodeType.Element, m_objXmlParser);
                    objReader.WhitespaceHandling = WhitespaceHandling.None;

                    while (objReader.Read())
                    {
                        switch (objReader.NodeType)
                        {
                            case XmlNodeType.Element:
                                if (objReader.HasAttributes)
                                {
                                    clsOperationRecord objOperationRecord = new clsOperationRecord();
                                    objOperationRecord.strCreateDate = objReader.GetAttribute("CREATEDATE").Replace('き', '\'');

                                    objOperationRecord.strInPatientID = objReader.GetAttribute("INPATIENTID").Replace('き', '\'');
                                    objOperationRecord.strInPatientDate = objReader.GetAttribute("INPATIENTDATE").Replace('き', '\'');
                                    objOperationRecord.strOpenDate = DateTime.Parse(objReader.GetAttribute("OPENDATE").Replace('き', '\'')).ToString("yyyy-MM-dd HH:mm:ss");

                                    if (objReader.GetAttribute("FIRSTPRINTDATE") == "")
                                        objOperationRecord.strFirstPrintDate = "";
                                    else
                                        objOperationRecord.strFirstPrintDate = DateTime.Parse(objReader.GetAttribute("FIRSTPRINTDATE")).ToString("yyyy-MM-dd HH:mm:ss");
                                    objOperationRecord.strCreateUserID = objReader.GetAttribute("CREATEUSERID").Replace('き', '\'');
                                    objOperationRecord.strIfConfirm = objReader.GetAttribute("IFCONFIRM").Replace('き', '\'');
                                    objOperationRecord.strConfirmReason = objReader.GetAttribute("CONFIRMREASON").Replace('き', '\'');
                                    objOperationRecord.strConfirmReasonXML = objReader.GetAttribute("CONFIRMREASONXML").Replace('き', '\'');
                                    objOperationRecord.strStatus = objReader.GetAttribute("STATUS").Replace('き', '\'');
                                    //								objOperationRecord.strDeActivedDate= objReader.GetAttribute("DEACTIVEDDATE").Replace('き','\'');
                                    //								objOperationRecord.strDeActivedOperatorID= objReader.GetAttribute("DEACTIVEDOPERATORID").Replace('き','\'');
                                    objOperationRecord.strSensesXML = objReader.GetAttribute("SENSESXML").Replace('き', '\'');
                                    objOperationRecord.strAllergicXML = objReader.GetAttribute("ALLERGICXML").Replace('き', '\'');
                                    objOperationRecord.strOperationLocationXML = objReader.GetAttribute("OPERATIONLOCATIONXML").Replace('き', '\'');
                                    objOperationRecord.strElectKnifeXML = objReader.GetAttribute("ELECTKNIFEXML").Replace('き', '\'');
                                    objOperationRecord.strDoublePoleXML = objReader.GetAttribute("DOUBLEPOLEXML").Replace('き', '\'');
                                    objOperationRecord.strCathodeLocationSkinXML = objReader.GetAttribute("CATHODELOCATIONSKINXML").Replace('き', '\'');
                                    objOperationRecord.strCathodeLocationSkinAfterOperationXML = objReader.GetAttribute("CATHODELOCSKINAFOPRXML").Replace('き', '\'');
                                    objOperationRecord.strStypticRubberXML = objReader.GetAttribute("STYPTICRUBBERXML").Replace('き', '\'');
                                    objOperationRecord.strUpXML = objReader.GetAttribute("UPXML").Replace('き', '\'');
                                    objOperationRecord.strDownXML = objReader.GetAttribute("DOWNXML").Replace('き', '\'');
                                    objOperationRecord.strFoleyXML = objReader.GetAttribute("FOLEYXML").Replace('き', '\'');
                                    objOperationRecord.strStomachXML = objReader.GetAttribute("STOMACHXML").Replace('き', '\'');
                                    objOperationRecord.strSkinAntisepsisXML = objReader.GetAttribute("SKINANTISEPSISXML").Replace('き', '\'');
                                    objOperationRecord.strBloodXML = objReader.GetAttribute("BLOODXML").Replace('き', '\'');
                                    objOperationRecord.strInLiquidQtyXML = objReader.GetAttribute("INLIQUIDQTYXML").Replace('き', '\'');
                                    objOperationRecord.strPeeOperatingQtyXML = objReader.GetAttribute("PEEOPERATINGQTYXML").Replace('き', '\'');
                                    objOperationRecord.strOutFlowXML = objReader.GetAttribute("OUTFLOWXML").Replace('き', '\'');
                                    objOperationRecord.strFromHeadToFootSkinXML = objReader.GetAttribute("FROMHEADTOFOOTSKINXML").Replace('き', '\'');
                                    objOperationRecord.strFromHeadToFootSkinAfterOperationXML = objReader.GetAttribute("FROMHEADTOFOOTSKINAFOPRXML").Replace('き', '\''); objOperationRecord.strSampleXML = objReader.GetAttribute("SAMPLEXML").Replace('き', '\'');
                                    objOperationRecord.strAfterOperationSendXML = objReader.GetAttribute("AFTEROPERATIONSENDXML").Replace('き', '\'');

                                    objOperationRecord.strTendRecordXML = objReader.GetAttribute("TENDRECORDXML").Replace('き', '\'');
                                    objOperationRecord.strOperationNameXML = objReader.GetAttribute("OPERATIONNAMEXML").Replace('き', '\'');
                                    objOperationRecord.strAnaesthesiaModeXML = objReader.GetAttribute("ANAESTHESIAMODEXML").Replace('き', '\'');

                                    objOperationRecord.strOperationRoomXML = objReader.GetAttribute("OPERATIONROOMXML").Replace('き', '\'');
                                    objOperationRecord.strOperation_AnaesthesiaXML = objReader.GetAttribute("OPERATION_ANAESTHESIAXML").Replace('き', '\'');


                                    objOperationRecord.strAllergicContentXML = objReader.GetAttribute("ALLERGICCONTENTXML").Replace('き', '\'');
                                    objOperationRecord.strOtherOperationLocationXML = objReader.GetAttribute("OTHEROPERATIONLOCATIONXML").Replace('き', '\'');
                                    objOperationRecord.strElectKnifeModelXML = objReader.GetAttribute("ELECTKNIFEMODELXML").Replace('き', '\'');
                                    objOperationRecord.strDoublePoleContentXML = objReader.GetAttribute("DOUBLEPOLECONTENTXML").Replace('き', '\'');
                                    objOperationRecord.strCathodeLocationXML = objReader.GetAttribute("CATHODELOCATIONXML").Replace('き', '\'');
                                    objOperationRecord.strStypticPressureModeXML = objReader.GetAttribute("STYPTICPRESSUREMODEXML").Replace('き', '\'');
                                    objOperationRecord.strUpPuffDateTimeXML = objReader.GetAttribute("UPPUFFDATETIMEXML").Replace('き', '\'');
                                    objOperationRecord.strUpDeflateDateTimeXML = objReader.GetAttribute("UPDEFLATEDATETIMEXML").Replace('き', '\'');
                                    objOperationRecord.strUpTotalDateTimeXML = objReader.GetAttribute("UPTOTALDATETIMEXML").Replace('き', '\'');
                                    objOperationRecord.strUpPressXML = objReader.GetAttribute("UPPRESSXML").Replace('き', '\'');
                                    objOperationRecord.strDownPuffDateTimeXML = objReader.GetAttribute("DOWNPUFFDATETIMEXML").Replace('き', '\'');
                                    objOperationRecord.strDownDeflateDateTimeXML = objReader.GetAttribute("DOWNDEFLATEDATETIMEXML").Replace('き', '\'');
                                    objOperationRecord.strDownTotalDateTimeXML = objReader.GetAttribute("DOWNTOTALDATETIMEXML").Replace('き', '\'');
                                    objOperationRecord.strDownPressXML = objReader.GetAttribute("DOWNPRESSXML").Replace('き', '\'');
                                    objOperationRecord.strFoleyOtherContentXML = objReader.GetAttribute("FOLEYOTHERCONTENTXML").Replace('き', '\'');
                                    objOperationRecord.strSkinAntisepsisOtherContentXML = objReader.GetAttribute("SKINANTISEPSISOTHERCONTENTXML").Replace('き', '\'');
                                    objOperationRecord.strAllBloodQtyXML = objReader.GetAttribute("ALLBLOODQTYXML").Replace('き', '\'');
                                    objOperationRecord.strRedCellQtyXML = objReader.GetAttribute("REDCELLQTYXML").Replace('き', '\'');
                                    objOperationRecord.strBloodPlasmQtyXML = objReader.GetAttribute("BLOODPLASMQTYXML").Replace('き', '\'');
                                    objOperationRecord.strOwnBloodQtyXML = objReader.GetAttribute("OWNBLOODQTYXML").Replace('き', '\'');
                                    objOperationRecord.strBloodOtherQtyXML = objReader.GetAttribute("BLOODOTHERQTYXML").Replace('き', '\'');
                                    objOperationRecord.strFromHeadToFootSkinBeforeOperationContentXML = objReader.GetAttribute("FROMHEADTOFOOTSKINBFOPRCONTXML").Replace('き', '\'');
                                    objOperationRecord.strFromHeadToFootSkinAfterOperationContentXML = objReader.GetAttribute("FROMHEADTOFOOTSKINAFOPRCONTXML").Replace('き', '\'');
                                    objOperationRecord.strSampleOtherContentXML = objReader.GetAttribute("SAMPLEOTHERCONTENTXML").Replace('き', '\'');

                                    string strSeqSign = objReader.GetAttribute("SEQUENCE_INT").Replace('き', '\'');
                                    long lngS = long.Parse(strSeqSign);
                                    com.digitalwave.PublicMiddleTier.clsPublicMiddleTier objService =
                                        (com.digitalwave.PublicMiddleTier.clsPublicMiddleTier)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.PublicMiddleTier.clsPublicMiddleTier));

                                    long lngTemp = objService.m_lngGetSign(lngS, out objOperationRecord.objSignerArr);

                                    objOperationRecordReturn = objOperationRecord;

                                }
                                break;
                        }
                    }
                }
            }
            finally
            {
                //m_objServ.Dispose();
            }
			return lngRes;

            
		}
		
		public long  m_lngGetDeleteOperationRecord(string p_strInPatientID,string p_strInPatientDate,string p_strCreateDate,out clsOperationRecord objOperationRecordReturn)
		{ 
			objOperationRecordReturn=null;
			if(p_strInPatientID ==null||p_strInPatientID ==""||p_strInPatientDate==null||p_strInPatientDate=="" ||p_strCreateDate==null||p_strCreateDate=="")
				return 0;
			
			string strXml = "";
			int intRows = 0;

			long lngRes = 0;

            com.digitalwave.OperationRecord.clsOperationRecordServ m_objServ =
                (com.digitalwave.OperationRecord.clsOperationRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.OperationRecord.clsOperationRecordServ));

            try
            {
                lngRes = m_objServ.m_lngGetDeleteOperationRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_strCreateDate, out strXml, out intRows);

                if (lngRes > 0 && intRows > 0)
                {

                    XmlTextReader objReader = new XmlTextReader(strXml, XmlNodeType.Element, m_objXmlParser);
                    objReader.WhitespaceHandling = WhitespaceHandling.None;

                    while (objReader.Read())
                    {
                        switch (objReader.NodeType)
                        {
                            case XmlNodeType.Element:
                                if (objReader.HasAttributes)
                                {
                                    clsOperationRecord objOperationRecord = new clsOperationRecord();
                                    objOperationRecord.strCreateDate = objReader.GetAttribute("CREATEDATE").Replace('き', '\'');

                                    objOperationRecord.strInPatientID = objReader.GetAttribute("INPATIENTID").Replace('き', '\'');
                                    objOperationRecord.strInPatientDate = objReader.GetAttribute("INPATIENTDATE").Replace('き', '\'');
                                    objOperationRecord.strOpenDate = DateTime.Parse(objReader.GetAttribute("OPENDATE").Replace('き', '\'')).ToString("yyyy-MM-dd HH:mm:ss");

                                    if (objReader.GetAttribute("FIRSTPRINTDATE") == "")
                                        objOperationRecord.strFirstPrintDate = "";
                                    else
                                        objOperationRecord.strFirstPrintDate = DateTime.Parse(objReader.GetAttribute("FIRSTPRINTDATE")).ToString("yyyy-MM-dd HH:mm:ss");
                                    objOperationRecord.strCreateUserID = objReader.GetAttribute("CREATEUSERID").Replace('き', '\'');
                                    objOperationRecord.strIfConfirm = objReader.GetAttribute("IFCONFIRM").Replace('き', '\'');
                                    objOperationRecord.strConfirmReason = objReader.GetAttribute("CONFIRMREASON").Replace('き', '\'');
                                    objOperationRecord.strConfirmReasonXML = objReader.GetAttribute("CONFIRMREASONXML").Replace('き', '\'');
                                    objOperationRecord.strStatus = objReader.GetAttribute("STATUS").Replace('き', '\'');
                                    //								objOperationRecord.strDeActivedDate= objReader.GetAttribute("DEACTIVEDDATE").Replace('き','\'');
                                    //								objOperationRecord.strDeActivedOperatorID= objReader.GetAttribute("DEACTIVEDOPERATORID").Replace('き','\'');
                                    objOperationRecord.strSensesXML = objReader.GetAttribute("SENSESXML").Replace('き', '\'');
                                    objOperationRecord.strAllergicXML = objReader.GetAttribute("ALLERGICXML").Replace('き', '\'');
                                    objOperationRecord.strOperationLocationXML = objReader.GetAttribute("OPERATIONLOCATIONXML").Replace('き', '\'');
                                    objOperationRecord.strElectKnifeXML = objReader.GetAttribute("ELECTKNIFEXML").Replace('き', '\'');
                                    objOperationRecord.strDoublePoleXML = objReader.GetAttribute("DOUBLEPOLEXML").Replace('き', '\'');
                                    objOperationRecord.strCathodeLocationSkinXML = objReader.GetAttribute("CATHODELOCATIONSKINXML").Replace('き', '\'');
                                    objOperationRecord.strCathodeLocationSkinAfterOperationXML = objReader.GetAttribute("CATHODELOCSKINAFOPRXML").Replace('き', '\'');
                                    objOperationRecord.strStypticRubberXML = objReader.GetAttribute("STYPTICRUBBERXML").Replace('き', '\'');
                                    objOperationRecord.strUpXML = objReader.GetAttribute("UPXML").Replace('き', '\'');
                                    objOperationRecord.strDownXML = objReader.GetAttribute("DOWNXML").Replace('き', '\'');
                                    objOperationRecord.strFoleyXML = objReader.GetAttribute("FOLEYXML").Replace('き', '\'');
                                    objOperationRecord.strStomachXML = objReader.GetAttribute("STOMACHXML").Replace('き', '\'');
                                    objOperationRecord.strSkinAntisepsisXML = objReader.GetAttribute("SKINANTISEPSISXML").Replace('き', '\'');
                                    objOperationRecord.strBloodXML = objReader.GetAttribute("BLOODXML").Replace('き', '\'');
                                    objOperationRecord.strInLiquidQtyXML = objReader.GetAttribute("INLIQUIDQTYXML").Replace('き', '\'');
                                    objOperationRecord.strPeeOperatingQtyXML = objReader.GetAttribute("PEEOPERATINGQTYXML").Replace('き', '\'');
                                    objOperationRecord.strOutFlowXML = objReader.GetAttribute("OUTFLOWXML").Replace('き', '\'');
                                    objOperationRecord.strFromHeadToFootSkinXML = objReader.GetAttribute("FROMHEADTOFOOTSKINXML").Replace('き', '\'');
                                    objOperationRecord.strFromHeadToFootSkinAfterOperationXML = objReader.GetAttribute("FROMHEADTOFOOTSKINAFOPRXML").Replace('き', '\''); objOperationRecord.strSampleXML = objReader.GetAttribute("SAMPLEXML").Replace('き', '\'');
                                    objOperationRecord.strAfterOperationSendXML = objReader.GetAttribute("AFTEROPERATIONSENDXML").Replace('き', '\'');

                                    objOperationRecord.strTendRecordXML = objReader.GetAttribute("TENDRECORDXML").Replace('き', '\'');
                                    objOperationRecord.strOperationNameXML = objReader.GetAttribute("OPERATIONNAMEXML").Replace('き', '\'');
                                    objOperationRecord.strAnaesthesiaModeXML = objReader.GetAttribute("ANAESTHESIAMODEXML").Replace('き', '\'');

                                    objOperationRecord.strOperationRoomXML = objReader.GetAttribute("OPERATIONROOMXML").Replace('き', '\'');
                                    objOperationRecord.strOperation_AnaesthesiaXML = objReader.GetAttribute("OPERATION_ANAESTHESIAXML").Replace('き', '\'');


                                    objOperationRecord.strAllergicContentXML = objReader.GetAttribute("ALLERGICCONTENTXML").Replace('き', '\'');
                                    objOperationRecord.strOtherOperationLocationXML = objReader.GetAttribute("OTHEROPERATIONLOCATIONXML").Replace('き', '\'');
                                    objOperationRecord.strElectKnifeModelXML = objReader.GetAttribute("ELECTKNIFEMODELXML").Replace('き', '\'');
                                    objOperationRecord.strDoublePoleContentXML = objReader.GetAttribute("DOUBLEPOLECONTENTXML").Replace('き', '\'');
                                    objOperationRecord.strCathodeLocationXML = objReader.GetAttribute("CATHODELOCATIONXML").Replace('き', '\'');
                                    objOperationRecord.strStypticPressureModeXML = objReader.GetAttribute("STYPTICPRESSUREMODEXML").Replace('き', '\'');
                                    objOperationRecord.strUpPuffDateTimeXML = objReader.GetAttribute("UPPUFFDATETIMEXML").Replace('き', '\'');
                                    objOperationRecord.strUpDeflateDateTimeXML = objReader.GetAttribute("UPDEFLATEDATETIMEXML").Replace('き', '\'');
                                    objOperationRecord.strUpTotalDateTimeXML = objReader.GetAttribute("UPTOTALDATETIMEXML").Replace('き', '\'');
                                    objOperationRecord.strUpPressXML = objReader.GetAttribute("UPPRESSXML").Replace('き', '\'');
                                    objOperationRecord.strDownPuffDateTimeXML = objReader.GetAttribute("DOWNPUFFDATETIMEXML").Replace('き', '\'');
                                    objOperationRecord.strDownDeflateDateTimeXML = objReader.GetAttribute("DOWNDEFLATEDATETIMEXML").Replace('き', '\'');
                                    objOperationRecord.strDownTotalDateTimeXML = objReader.GetAttribute("DOWNTOTALDATETIMEXML").Replace('き', '\'');
                                    objOperationRecord.strDownPressXML = objReader.GetAttribute("DOWNPRESSXML").Replace('き', '\'');
                                    objOperationRecord.strFoleyOtherContentXML = objReader.GetAttribute("FOLEYOTHERCONTENTXML").Replace('き', '\'');
                                    objOperationRecord.strSkinAntisepsisOtherContentXML = objReader.GetAttribute("SKINANTISEPSISOTHERCONTENTXML").Replace('き', '\'');
                                    objOperationRecord.strAllBloodQtyXML = objReader.GetAttribute("ALLBLOODQTYXML").Replace('き', '\'');
                                    objOperationRecord.strRedCellQtyXML = objReader.GetAttribute("REDCELLQTYXML").Replace('き', '\'');
                                    objOperationRecord.strBloodPlasmQtyXML = objReader.GetAttribute("BLOODPLASMQTYXML").Replace('き', '\'');
                                    objOperationRecord.strOwnBloodQtyXML = objReader.GetAttribute("OWNBLOODQTYXML").Replace('き', '\'');
                                    objOperationRecord.strBloodOtherQtyXML = objReader.GetAttribute("BLOODOTHERQTYXML").Replace('き', '\'');
                                    objOperationRecord.strFromHeadToFootSkinBeforeOperationContentXML = objReader.GetAttribute("FROMHEADTOFOOTSKINBFOPRCONTXML").Replace('き', '\'');
                                    objOperationRecord.strFromHeadToFootSkinAfterOperationContentXML = objReader.GetAttribute("FROMHEADTOFOOTSKINAFOPRCONTXML").Replace('き', '\'');
                                    objOperationRecord.strSampleOtherContentXML = objReader.GetAttribute("SAMPLEOTHERCONTENTXML").Replace('き', '\'');

                                    string strSeqSign = objReader.GetAttribute("SEQUENCE_INT").Replace('き', '\'');
                                    long lngS = long.Parse(strSeqSign);
                                    com.digitalwave.PublicMiddleTier.clsPublicMiddleTier objService =
                                        (com.digitalwave.PublicMiddleTier.clsPublicMiddleTier)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.PublicMiddleTier.clsPublicMiddleTier));
                                    long lngTemp = objService.m_lngGetSign(lngS, out objOperationRecord.objSignerArr);

                                    objOperationRecordReturn = objOperationRecord;

                                }
                                break;
                        }
                    }
                }
            }
            finally
            {
                //m_objServ.Dispose();
            }
			return lngRes;            
		}

		public long  m_lngGetOperationRecordContent(string p_strInPatientID,string p_strInPatientDate,string p_strCreateDate, out clsOperationRecordContent objOperationRecordContent)
		{ 
			objOperationRecordContent=null;
			if(p_strInPatientID ==null||p_strInPatientID ==""||p_strInPatientDate==null||p_strInPatientDate=="" ||p_strCreateDate==null||p_strCreateDate=="")
				return 0;
			string strXml = "";
			int intRows = 0;

			long lngRes = 0;

            com.digitalwave.OperationRecord.clsOperationRecordServ m_objServ =
                (com.digitalwave.OperationRecord.clsOperationRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.OperationRecord.clsOperationRecordServ));

            try
            {
                lngRes = m_objServ.m_lngGetOperationRecordContent(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_strCreateDate, out strXml, out intRows);

                if (lngRes > 0 && intRows > 0)
                {

                    XmlTextReader objReader = new XmlTextReader(strXml, XmlNodeType.Element, m_objXmlParser);
                    objReader.WhitespaceHandling = WhitespaceHandling.None;

                    while (objReader.Read())
                    {
                        switch (objReader.NodeType)
                        {
                            case XmlNodeType.Element:
                                if (objReader.HasAttributes)
                                {

                                    objOperationRecordContent = new clsOperationRecordContent();
                                    objOperationRecordContent.strInPatientID = objReader.GetAttribute("INPATIENTID").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strInPatientDate = objReader.GetAttribute("INPATIENTDATE").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strOpenDate = DateTime.Parse(objReader.GetAttribute("OPENDATE").ToString().Replace('き', '\'')).ToString("yyyy-MM-dd HH:mm:ss");
                                    objOperationRecordContent.strLastModifyDate = DateTime.Parse(objReader.GetAttribute("LASTMODIFYDATE").ToString().Replace('き', '\'')).ToString("yyyy-MM-dd HH:mm:ss");
                                    objOperationRecordContent.strLastModifyUserID = objReader.GetAttribute("LASTMODIFYUSERID").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strStatus = objReader.GetAttribute("STATUS").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strDeActivedDate = objReader.GetAttribute("DEACTIVEDDATE").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strDeActivedOperatorID = objReader.GetAttribute("DEACTIVEDOPERATORID").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strPatientInDate = objReader.GetAttribute("PATIENTINDATE").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strOperationBeginDate = objReader.GetAttribute("OPERATIONBEGINDATE").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strOperationEndDate = objReader.GetAttribute("OPERATIONENDDATE").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strOperationLeaveDate = objReader.GetAttribute("OPERATIONLEAVEDATE").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strSensesClearHeaded = objReader.GetAttribute("SENSESCLEARHEADED").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strSensesSleep = objReader.GetAttribute("SENSESSLEEP").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strSensesComa = objReader.GetAttribute("SENSESCOMA").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strHaveAllergic = objReader.GetAttribute("HAVEALLERGIC").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strHaveNotAllergic = objReader.GetAttribute("HAVENOTALLERGIC").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strAllergicContent = objReader.GetAttribute("ALLERGICCONTENT").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strOperationLocationOnHisBack = objReader.GetAttribute("OPERATIONLOCATIONONHISBACK").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strOperationLocationSide = objReader.GetAttribute("OPERATIONLOCATIONSIDE").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strOperationLocationPA = objReader.GetAttribute("OPERATIONLOCATIONPA").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strOperationLocationParaplegic = objReader.GetAttribute("OPERATIONLOCATIONPARAPLEGIC").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strOperationLocationHypothyroid = objReader.GetAttribute("OPERATIONLOCATIONHYPOTHYROID").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strOperationLocationOther = objReader.GetAttribute("OPERATIONLOCATIONOTHER").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strOtherOperationLocation = objReader.GetAttribute("OTHEROPERATIONLOCATION").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strHaveNotElectKnife = objReader.GetAttribute("HAVENOTELECTKNIFE").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strHaveUsedElectKnife = objReader.GetAttribute("HAVEUSEDELECTKNIFE").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strElectKnifeModel = objReader.GetAttribute("ELECTKNIFEMODEL").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strHaveNotDoublePole = objReader.GetAttribute("HAVENOTDOUBLEPOLE").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strHaveDoublePole = objReader.GetAttribute("HAVEDOUBLEPOLE").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strDoublePoleContent = objReader.GetAttribute("DOUBLEPOLECONTENT").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strCathodeLocation = objReader.GetAttribute("CATHODELOCATION").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strCathodeLocationSkinBeforOperationMar = objReader.GetAttribute("CATHODELOCSKINBFOPRMAR").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strCathodeLocationSkinBeforOperationFull = objReader.GetAttribute("CATHODELOCSKINBFOPRFULL").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strCathodeLocationSkinAfterOperationMar = objReader.GetAttribute("CATHODELOCSKINAFOPRMAR").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strCathodeLocationSkinAfterOperationFull = objReader.GetAttribute("CATHODELOCSKINAFOPRFULL").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strStypticRubber = objReader.GetAttribute("STYPTICRUBBER").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strStypticPressure = objReader.GetAttribute("STYPTICPRESSURE").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strStypticPressureMode = objReader.GetAttribute("STYPTICPRESSUREMODE").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strUpForearm = objReader.GetAttribute("UPFOREARM").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strUpThigh = objReader.GetAttribute("UPTHIGH").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strUpRight = objReader.GetAttribute("UPRIGHT").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strUpLeft = objReader.GetAttribute("UPLEFT").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strUpPuffDateTime = objReader.GetAttribute("UPPUFFDATETIME").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strUpDeflateDateTime = objReader.GetAttribute("UPDEFLATEDATETIME").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strUpTotalDateTime = objReader.GetAttribute("UPTOTALDATETIME").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strUpPress = objReader.GetAttribute("UPPRESS").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strDownForearm = objReader.GetAttribute("DOWNFOREARM").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strDownThigh = objReader.GetAttribute("DOWNTHIGH").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strDownRight = objReader.GetAttribute("DOWNRIGHT").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strDownLeft = objReader.GetAttribute("DOWNLEFT").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strDownPuffDateTime = objReader.GetAttribute("DOWNPUFFDATETIME").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strDownDeflateDateTime = objReader.GetAttribute("DOWNDEFLATEDATETIME").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strDownTotalDateTime = objReader.GetAttribute("DOWNTOTALDATETIME").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strDownPress = objReader.GetAttribute("DOWNPRESS").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strFoleySickroom = objReader.GetAttribute("FOLEYSICKROOM").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strFoleyOperationRoom = objReader.GetAttribute("FOLEYOPERATIONROOM").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strFoleyDoubleAntrum = objReader.GetAttribute("FOLEYDOUBLEANTRUM").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strFoleyThreeAntrum = objReader.GetAttribute("FOLEYTHREEANTRUM").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strFoleyOther = objReader.GetAttribute("FOLEYOTHER").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strFoleyOtherContent = objReader.GetAttribute("FOLEYOTHERCONTENT").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strStomachSickroom = objReader.GetAttribute("STOMACHSICKROOM").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strStomachOprationRoom = objReader.GetAttribute("STOMACHOPRATIONROOM").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strSkinAntisepsis2 = objReader.GetAttribute("SKINANTISEPSIS2").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strSkinAntisepsis75 = objReader.GetAttribute("SKINANTISEPSIS75").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strSkinAntisepsisIodin = objReader.GetAttribute("SKINANTISEPSISIODIN").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strSkinAntisepsisIodinRare = objReader.GetAttribute("SKINANTISEPSISIODINRARE").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strSkinAntisepsisOther = objReader.GetAttribute("SKINANTISEPSISOTHER").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strSkinAntisepsisOtherContent = objReader.GetAttribute("SKINANTISEPSISOTHERCONTENT").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strAllBlood = objReader.GetAttribute("ALLBLOOD").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strAllBloodQty = objReader.GetAttribute("ALLBLOODQTY").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strRedCell = objReader.GetAttribute("REDCELL").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strRedCellQty = objReader.GetAttribute("REDCELLQTY").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strBloodPlasm = objReader.GetAttribute("BLOODPLASM").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strBloodPlasmQty = objReader.GetAttribute("BLOODPLASMQTY").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strOwnBlood = objReader.GetAttribute("OWNBLOOD").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strOwnBloodQty = objReader.GetAttribute("OWNBLOODQTY").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strBloodOther = objReader.GetAttribute("BLOODOTHER").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strBloodOtherQty = objReader.GetAttribute("BLOODOTHERQTY").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strInLiquidQty = objReader.GetAttribute("INLIQUIDQTY").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strPeeOperatingQty = objReader.GetAttribute("PEEOPERATINGQTY").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strHaveOutFlow = objReader.GetAttribute("HAVEOUTFLOW").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strNotHaveOutFlow = objReader.GetAttribute("NOTHAVEOUTFLOW").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strFromHeadToFootSkinBeforeOperationMar = objReader.GetAttribute("FROMHEADTOFOOTSKINBFOPRMAR").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strFromHeadToFootSkinBeforeOperationFull = objReader.GetAttribute("FROMHEADTOFOOTSKINBFOPRFULL").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strFromHeadToFootSkinBeforeOperationContent = objReader.GetAttribute("FROMHEADTOFOOTSKINBFOPRCONT").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strFromHeadToFootSkinAfterOperationMar = objReader.GetAttribute("FROMHEADTOFOOTSKINAFOPRMAR").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strFromHeadToFootSkinAfterOperationFull = objReader.GetAttribute("FROMHEADTOFOOTSKINAFOPRFULL").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strFromHeadToFootSkinAfterOperationContent = objReader.GetAttribute("FROMHEADTOFOOTSKINAFOPRCONT").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strSampleGeneral = objReader.GetAttribute("SAMPLEGENERAL").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strSampleSlice = objReader.GetAttribute("SAMPLESLICE").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strSampleBacilli = objReader.GetAttribute("SAMPLEBACILLI").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strSampleOther = objReader.GetAttribute("SAMPLEOTHER").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strSampleOtherContent = objReader.GetAttribute("SAMPLEOTHERCONTENT").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strAfterOperationSendRenew = objReader.GetAttribute("AFTEROPERATIONSENDRENEW").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strAfterOperationSendICU = objReader.GetAttribute("AFTEROPERATIONSENDICU").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strAfterOperationSendSickRoom = objReader.GetAttribute("AFTEROPERATIONSENDSICKROOM").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strTendRecord = objReader.GetAttribute("TENDRECORD").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strOperationName = objReader.GetAttribute("OPERATIONNAME").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strAnaesthesiaMode = objReader.GetAttribute("ANAESTHESIAMODE").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strOperationRoom = objReader.GetAttribute("OPERATIONROOM").ToString().Replace('き', '\'');


                                }
                                break;
                        }
                    }
                }
            }
            finally
            {
                //m_objServ.Dispose();
            }
			return lngRes;

            
		}
			
		public long  m_lngGetDeleteOperationRecordContent(string p_strInPatientID,string p_strInPatientDate,string p_strCreateDate, out clsOperationRecordContent objOperationRecordContent)
		{ 
			objOperationRecordContent=null;
			if(p_strInPatientID ==null||p_strInPatientID ==""||p_strInPatientDate==null||p_strInPatientDate=="" ||p_strCreateDate==null||p_strCreateDate=="")
				return 0;
			string strXml = "";
			int intRows = 0;

			long lngRes = 0;

            com.digitalwave.OperationRecord.clsOperationRecordServ m_objServ =
                (com.digitalwave.OperationRecord.clsOperationRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.OperationRecord.clsOperationRecordServ));

            try
            {
                lngRes = m_objServ.m_lngGetDeleteOperationRecordContent(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_strCreateDate, out strXml, out intRows);

                if (lngRes > 0 && intRows > 0)
                {

                    XmlTextReader objReader = new XmlTextReader(strXml, XmlNodeType.Element, m_objXmlParser);
                    objReader.WhitespaceHandling = WhitespaceHandling.None;

                    while (objReader.Read())
                    {
                        switch (objReader.NodeType)
                        {
                            case XmlNodeType.Element:
                                if (objReader.HasAttributes)
                                {

                                    objOperationRecordContent = new clsOperationRecordContent();
                                    objOperationRecordContent.strInPatientID = objReader.GetAttribute("INPATIENTID").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strInPatientDate = objReader.GetAttribute("INPATIENTDATE").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strOpenDate = DateTime.Parse(objReader.GetAttribute("OPENDATE").ToString().Replace('き', '\'')).ToString("yyyy-MM-dd HH:mm:ss");
                                    objOperationRecordContent.strLastModifyDate = DateTime.Parse(objReader.GetAttribute("LASTMODIFYDATE").ToString().Replace('き', '\'')).ToString("yyyy-MM-dd HH:mm:ss");
                                    objOperationRecordContent.strLastModifyUserID = objReader.GetAttribute("LASTMODIFYUSERID").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strStatus = objReader.GetAttribute("STATUS").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strDeActivedDate = objReader.GetAttribute("DEACTIVEDDATE").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strDeActivedOperatorID = objReader.GetAttribute("DEACTIVEDOPERATORID").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strPatientInDate = objReader.GetAttribute("PATIENTINDATE").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strOperationBeginDate = objReader.GetAttribute("OPERATIONBEGINDATE").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strOperationEndDate = objReader.GetAttribute("OPERATIONENDDATE").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strOperationLeaveDate = objReader.GetAttribute("OPERATIONLEAVEDATE").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strSensesClearHeaded = objReader.GetAttribute("SENSESCLEARHEADED").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strSensesSleep = objReader.GetAttribute("SENSESSLEEP").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strSensesComa = objReader.GetAttribute("SENSESCOMA").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strHaveAllergic = objReader.GetAttribute("HAVEALLERGIC").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strHaveNotAllergic = objReader.GetAttribute("HAVENOTALLERGIC").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strAllergicContent = objReader.GetAttribute("ALLERGICCONTENT").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strOperationLocationOnHisBack = objReader.GetAttribute("OPERATIONLOCATIONONHISBACK").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strOperationLocationSide = objReader.GetAttribute("OPERATIONLOCATIONSIDE").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strOperationLocationPA = objReader.GetAttribute("OPERATIONLOCATIONPA").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strOperationLocationParaplegic = objReader.GetAttribute("OPERATIONLOCATIONPARAPLEGIC").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strOperationLocationHypothyroid = objReader.GetAttribute("OPERATIONLOCATIONHYPOTHYROID").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strOperationLocationOther = objReader.GetAttribute("OPERATIONLOCATIONOTHER").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strOtherOperationLocation = objReader.GetAttribute("OTHEROPERATIONLOCATION").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strHaveNotElectKnife = objReader.GetAttribute("HAVENOTELECTKNIFE").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strHaveUsedElectKnife = objReader.GetAttribute("HAVEUSEDELECTKNIFE").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strElectKnifeModel = objReader.GetAttribute("ELECTKNIFEMODEL").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strHaveNotDoublePole = objReader.GetAttribute("HAVENOTDOUBLEPOLE").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strHaveDoublePole = objReader.GetAttribute("HAVEDOUBLEPOLE").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strDoublePoleContent = objReader.GetAttribute("DOUBLEPOLECONTENT").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strCathodeLocation = objReader.GetAttribute("CATHODELOCATION").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strCathodeLocationSkinBeforOperationMar = objReader.GetAttribute("CATHODELOCSKINBFOPRMAR").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strCathodeLocationSkinBeforOperationFull = objReader.GetAttribute("CATHODELOCSKINBFOPRFULL").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strCathodeLocationSkinAfterOperationMar = objReader.GetAttribute("CATHODELOCSKINAFOPRMAR").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strCathodeLocationSkinAfterOperationFull = objReader.GetAttribute("CATHODELOCSKINAFOPRFULL").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strStypticRubber = objReader.GetAttribute("STYPTICRUBBER").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strStypticPressure = objReader.GetAttribute("STYPTICPRESSURE").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strStypticPressureMode = objReader.GetAttribute("STYPTICPRESSUREMODE").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strUpForearm = objReader.GetAttribute("UPFOREARM").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strUpThigh = objReader.GetAttribute("UPTHIGH").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strUpRight = objReader.GetAttribute("UPRIGHT").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strUpLeft = objReader.GetAttribute("UPLEFT").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strUpPuffDateTime = objReader.GetAttribute("UPPUFFDATETIME").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strUpDeflateDateTime = objReader.GetAttribute("UPDEFLATEDATETIME").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strUpTotalDateTime = objReader.GetAttribute("UPTOTALDATETIME").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strUpPress = objReader.GetAttribute("UPPRESS").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strDownForearm = objReader.GetAttribute("DOWNFOREARM").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strDownThigh = objReader.GetAttribute("DOWNTHIGH").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strDownRight = objReader.GetAttribute("DOWNRIGHT").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strDownLeft = objReader.GetAttribute("DOWNLEFT").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strDownPuffDateTime = objReader.GetAttribute("DOWNPUFFDATETIME").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strDownDeflateDateTime = objReader.GetAttribute("DOWNDEFLATEDATETIME").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strDownTotalDateTime = objReader.GetAttribute("DOWNTOTALDATETIME").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strDownPress = objReader.GetAttribute("DOWNPRESS").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strFoleySickroom = objReader.GetAttribute("FOLEYSICKROOM").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strFoleyOperationRoom = objReader.GetAttribute("FOLEYOPERATIONROOM").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strFoleyDoubleAntrum = objReader.GetAttribute("FOLEYDOUBLEANTRUM").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strFoleyThreeAntrum = objReader.GetAttribute("FOLEYTHREEANTRUM").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strFoleyOther = objReader.GetAttribute("FOLEYOTHER").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strFoleyOtherContent = objReader.GetAttribute("FOLEYOTHERCONTENT").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strStomachSickroom = objReader.GetAttribute("STOMACHSICKROOM").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strStomachOprationRoom = objReader.GetAttribute("STOMACHOPRATIONROOM").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strSkinAntisepsis2 = objReader.GetAttribute("SKINANTISEPSIS2").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strSkinAntisepsis75 = objReader.GetAttribute("SKINANTISEPSIS75").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strSkinAntisepsisIodin = objReader.GetAttribute("SKINANTISEPSISIODIN").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strSkinAntisepsisIodinRare = objReader.GetAttribute("SKINANTISEPSISIODINRARE").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strSkinAntisepsisOther = objReader.GetAttribute("SKINANTISEPSISOTHER").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strSkinAntisepsisOtherContent = objReader.GetAttribute("SKINANTISEPSISOTHERCONTENT").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strAllBlood = objReader.GetAttribute("ALLBLOOD").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strAllBloodQty = objReader.GetAttribute("ALLBLOODQTY").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strRedCell = objReader.GetAttribute("REDCELL").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strRedCellQty = objReader.GetAttribute("REDCELLQTY").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strBloodPlasm = objReader.GetAttribute("BLOODPLASM").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strBloodPlasmQty = objReader.GetAttribute("BLOODPLASMQTY").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strOwnBlood = objReader.GetAttribute("OWNBLOOD").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strOwnBloodQty = objReader.GetAttribute("OWNBLOODQTY").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strBloodOther = objReader.GetAttribute("BLOODOTHER").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strBloodOtherQty = objReader.GetAttribute("BLOODOTHERQTY").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strInLiquidQty = objReader.GetAttribute("INLIQUIDQTY").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strPeeOperatingQty = objReader.GetAttribute("PEEOPERATINGQTY").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strHaveOutFlow = objReader.GetAttribute("HAVEOUTFLOW").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strNotHaveOutFlow = objReader.GetAttribute("NOTHAVEOUTFLOW").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strFromHeadToFootSkinBeforeOperationMar = objReader.GetAttribute("FROMHEADTOFOOTSKINBFOPRMAR").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strFromHeadToFootSkinBeforeOperationFull = objReader.GetAttribute("FROMHEADTOFOOTSKINBFOPRFULL").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strFromHeadToFootSkinBeforeOperationContent = objReader.GetAttribute("FROMHEADTOFOOTSKINBFOPRCONT").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strFromHeadToFootSkinAfterOperationMar = objReader.GetAttribute("FROMHEADTOFOOTSKINAFOPRMAR").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strFromHeadToFootSkinAfterOperationFull = objReader.GetAttribute("FROMHEADTOFOOTSKINAFOPRFULL").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strFromHeadToFootSkinAfterOperationContent = objReader.GetAttribute("FROMHEADTOFOOTSKINAFOPRCONT").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strSampleGeneral = objReader.GetAttribute("SAMPLEGENERAL").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strSampleSlice = objReader.GetAttribute("SAMPLESLICE").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strSampleBacilli = objReader.GetAttribute("SAMPLEBACILLI").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strSampleOther = objReader.GetAttribute("SAMPLEOTHER").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strSampleOtherContent = objReader.GetAttribute("SAMPLEOTHERCONTENT").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strAfterOperationSendRenew = objReader.GetAttribute("AFTEROPERATIONSENDRENEW").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strAfterOperationSendICU = objReader.GetAttribute("AFTEROPERATIONSENDICU").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strAfterOperationSendSickRoom = objReader.GetAttribute("AFTEROPERATIONSENDSICKROOM").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strTendRecord = objReader.GetAttribute("TENDRECORD").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strOperationName = objReader.GetAttribute("OPERATIONNAME").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strAnaesthesiaMode = objReader.GetAttribute("ANAESTHESIAMODE").ToString().Replace('き', '\'');
                                    objOperationRecordContent.strOperationRoom = objReader.GetAttribute("OPERATIONROOM").ToString().Replace('き', '\'');


                                }
                                break;
                        }
                    }
                }
            }
            finally
            {
                //m_objServ.Dispose();
            }
			return lngRes;            
		}

		public long m_lngGetLastestOperationID(string p_strInPatientID,string p_strInPatientDate,string p_strCreateDate,out string m_strOperationID)
		{
			m_strOperationID = null;
			if(p_strInPatientID == null || p_strInPatientID == "" || p_strInPatientDate == null || p_strInPatientDate == "" || p_strCreateDate == null || p_strCreateDate == "")
				return 0;
			
			
			string strXml = "";
			int intRows = 0;

			long lngRes = 0;

            com.digitalwave.OperationRecord.clsOperationRecordServ m_objServ =
                (com.digitalwave.OperationRecord.clsOperationRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.OperationRecord.clsOperationRecordServ));

            try
            {
                lngRes = m_objServ.m_lngGetLastestOperationID(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_strCreateDate, out strXml, out intRows);

                if (lngRes > 0 && intRows > 0)
                {
                    XmlTextReader objReader = new XmlTextReader(strXml, XmlNodeType.Element, m_objXmlParser);
                    objReader.WhitespaceHandling = WhitespaceHandling.None;

                    while (objReader.Read())
                    {
                        switch (objReader.NodeType)
                        {
                            case XmlNodeType.Element:
                                if (objReader.HasAttributes)
                                {
                                    m_strOperationID = objReader.GetAttribute("OPERATIONID");
                                }
                                break;
                        }
                    }
                }
            }
            finally
            {
                //m_objServ.Dispose();
            }
			return lngRes ;
		}
		/// <summary>
		/// 孔嬬揖m_lngGetLastestOperationID(),徽補竃潤惚嶄淫根返宝兆各.
		/// </summary>		
		public long m_lngGetLastestOperationMode(string p_strInPatientID,string p_strInPatientDate,string p_strCreateDate,out clsOperationIDInOperation p_objOperationID)
		{
			p_objOperationID = null;
			if(p_strInPatientID == null || p_strInPatientID == "" || p_strInPatientDate == null || p_strInPatientDate == "" || p_strCreateDate == null || p_strCreateDate == "")
				return 0;
			
			
			string strXml = "";
			int intRows = 0;

			long lngRes = 0;

            com.digitalwave.OperationRecord.clsOperationRecordServ m_objServ =
                (com.digitalwave.OperationRecord.clsOperationRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.OperationRecord.clsOperationRecordServ));

            try
            {
                lngRes = m_objServ.m_lngGetLastestOperationID(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_strCreateDate, out strXml, out intRows);

                if (lngRes > 0 && intRows > 0)
                {
                    XmlTextReader objReader = new XmlTextReader(strXml, XmlNodeType.Element, m_objXmlParser);
                    objReader.WhitespaceHandling = WhitespaceHandling.None;
                    p_objOperationID = new clsOperationIDInOperation();

                    while (objReader.Read())
                    {
                        switch (objReader.NodeType)
                        {
                            case XmlNodeType.Element:
                                if (objReader.HasAttributes)
                                {
                                    p_objOperationID.strOperationID = objReader.GetAttribute("OPERATIONID");
                                    p_objOperationID.strOperationName = objReader.GetAttribute("OPERATIONNAME");
                                }
                                break;
                        }
                    }
                }
            }
            finally
            {
                //m_objServ.Dispose();
            }
			return lngRes ;
		}
		
		public long m_lngGetLastestAnaesthesiaID(string p_strInPatientID,string p_strInPatientDate,string p_strCreateDate,out string m_strAnaesthesiaModeID)
		{
			m_strAnaesthesiaModeID = null;
			if(p_strInPatientID == null || p_strInPatientID == "" || p_strInPatientDate == null || p_strInPatientDate == "" || p_strCreateDate == null || p_strCreateDate == "")
				return 0;
			
			string strXml = "";
			int intRows = 0;

			long lngRes = 0;

            com.digitalwave.OperationRecord.clsOperationRecordServ m_objServ =
                (com.digitalwave.OperationRecord.clsOperationRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.OperationRecord.clsOperationRecordServ));

            try
            {
                lngRes = m_objServ.m_lngGetLastestAnaesthesiaID(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_strCreateDate, out strXml, out intRows);

                if (lngRes > 0 && intRows > 0)
                {
                    XmlTextReader objReader = new XmlTextReader(strXml, XmlNodeType.Element, m_objXmlParser);
                    objReader.WhitespaceHandling = WhitespaceHandling.None;

                    while (objReader.Read())
                    {
                        switch (objReader.NodeType)
                        {
                            case XmlNodeType.Element:
                                if (objReader.HasAttributes)
                                {
                                    m_strAnaesthesiaModeID = objReader.GetAttribute("ANAESTHESIAMODEID");
                                }
                                break;
                        }
                    }
                }
            }
            finally
            {
                //m_objServ.Dispose();
            }
			return lngRes;
		}
		/// <summary>
		/// 孔嬬揖m_lngGetLastestAnaesthesiaID(),徽補竃潤惚嶄淫根醍恪圭塀兆各.
		/// </summary>		
		public long m_lngGetLastestAnaesthesiaMode(string p_strInPatientID,string p_strInPatientDate,string p_strCreateDate,out clsAnaesthesiaModeInOperation p_objAnaesthesiaModeID)
		{
			p_objAnaesthesiaModeID = null;
			if(p_strInPatientID == null || p_strInPatientID == "" || p_strInPatientDate == null || p_strInPatientDate == "" || p_strCreateDate == null || p_strCreateDate == "")
				return 0;
			
			string strXml = "";
			int intRows = 0;

			long lngRes = 0;

            com.digitalwave.OperationRecord.clsOperationRecordServ m_objServ =
                (com.digitalwave.OperationRecord.clsOperationRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.OperationRecord.clsOperationRecordServ));

            try
            {
                lngRes = m_objServ.m_lngGetLastestAnaesthesiaID(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_strCreateDate, out strXml, out intRows);

                if (lngRes > 0 && intRows > 0)
                {
                    XmlTextReader objReader = new XmlTextReader(strXml, XmlNodeType.Element, m_objXmlParser);
                    objReader.WhitespaceHandling = WhitespaceHandling.None;
                    p_objAnaesthesiaModeID = new clsAnaesthesiaModeInOperation();
                    while (objReader.Read())
                    {
                        switch (objReader.NodeType)
                        {
                            case XmlNodeType.Element:
                                if (objReader.HasAttributes)
                                {
                                    p_objAnaesthesiaModeID.strAnaesthesiaModeID = objReader.GetAttribute("ANAESTHESIAMODEID");
                                    p_objAnaesthesiaModeID.strAnaesthesiaModeName = objReader.GetAttribute("ANAESTHESIAMODENAME");
                                }
                                break;
                        }
                    }
                }
            }
            finally
            {
                //m_objServ.Dispose();
            }
			return lngRes;
		}
		public long m_lngGetOperation_Nurse(string strInPatientID, string strInPatientDate,string p_strCreateDate,out int Rows,out clsOperationDoctorNurse[] objOperationNurse)
		{
			objOperationNurse=null;
			string m_strReceivedXML="";
			int m_intReturnRows=0;
            long lngRes = 0;

            com.digitalwave.OperationRecord.clsOperationRecordServ m_objServ =
                (com.digitalwave.OperationRecord.clsOperationRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.OperationRecord.clsOperationRecordServ));

            try
            {
                lngRes = m_objServ.m_lngGetOperation_Nurse(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, strInPatientID, strInPatientDate, p_strCreateDate, ref m_strReceivedXML, ref m_intReturnRows);
                if (m_intReturnRows > 0)
                {
                    XmlTextReader objReader = new XmlTextReader(m_strReceivedXML, XmlNodeType.Element, m_objXmlParser);
                    objReader.WhitespaceHandling = WhitespaceHandling.None;
                    objOperationNurse = new clsOperationDoctorNurse[m_intReturnRows];
                    int intIndex = 0;
                    while (objReader.Read())
                    {
                        switch (objReader.NodeType)
                        {
                            case XmlNodeType.Element:
                                if (objReader.HasAttributes)
                                {
                                    objOperationNurse[intIndex] = new clsOperationDoctorNurse();
                                    objOperationNurse[intIndex].strNurseID = objReader.GetAttribute("OPERTORID");
                                    objOperationNurse[intIndex].strNurseFlag = objReader.GetAttribute("OPERATORFLAG");
                                    objOperationNurse[intIndex].strNurseName = objReader.GetAttribute("OPERATORNAME");
                                    intIndex++;

                                }
                                break;
                        }
                    }
                }
                Rows = m_intReturnRows;
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;

		}
		
		public long  m_lngGetWoundThing(string strInPatientID, string strInPatientDate,string strCreateDate,out int Rows,out clsOperationWoundThingInfo[] objOperationWoundThingArr)
		{
			objOperationWoundThingArr = null;
			string m_strReceivedXML="";
			int m_intReturnRows=0;
			long lngRes = 0;

            com.digitalwave.OperationRecord.clsOperationRecordServ m_objServ =
                (com.digitalwave.OperationRecord.clsOperationRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.OperationRecord.clsOperationRecordServ));

            try
            {
                lngRes = m_objServ.m_lngGetOperation_WoundThing(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, strInPatientID, strInPatientDate, strCreateDate, ref m_strReceivedXML, ref m_intReturnRows);
                if (m_intReturnRows > 0)
                {
                    XmlTextReader objReader = new XmlTextReader(m_strReceivedXML, XmlNodeType.Element, m_objXmlParser);
                    objReader.WhitespaceHandling = WhitespaceHandling.None;
                    objOperationWoundThingArr = new clsOperationWoundThingInfo[m_intReturnRows];
                    int intIndex = 0;
                    while (objReader.Read())
                    {
                        switch (objReader.NodeType)
                        {
                            case XmlNodeType.Element:
                                if (objReader.HasAttributes)
                                {
                                    objOperationWoundThingArr[intIndex] = new clsOperationWoundThingInfo();
                                    objOperationWoundThingArr[intIndex].strWoundThingID = objReader.GetAttribute("WOUNDTHINGID");
                                    objOperationWoundThingArr[intIndex].strWoundThingName = objReader.GetAttribute("WOUNDTHINGNAME");
                                    objOperationWoundThingArr[intIndex].strQuantity = objReader.GetAttribute("QUANTITY");
                                    intIndex++;
                                }
                                break;
                        }
                    }
                }
                Rows = m_intReturnRows;
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}
	
		public long m_lngGetOperationRecord_All(string p_strInPatientID,string p_strInPatientDate,string p_strCreateDate,out clsOperationRecord_All p_objOperationRecord_All)
		{
			int intRowTemp=0;
			long lngRes=0;
			p_objOperationRecord_All=new clsOperationRecord_All();
			lngRes=m_lngGetOperationRecord(p_strInPatientID,p_strInPatientDate,p_strCreateDate,out p_objOperationRecord_All.m_objOperationRecord);
			if(lngRes<=0)return lngRes;
			lngRes=m_lngGetOperationRecordContent(p_strInPatientID,p_strInPatientDate,p_strCreateDate,out p_objOperationRecord_All.m_objOperationRecordContent);
			if(lngRes<=0)return lngRes;
			lngRes=m_lngGetLastestOperationMode(p_strInPatientID,p_strInPatientDate,p_strCreateDate,out p_objOperationRecord_All.m_objOperationID);
			if(lngRes<=0)return lngRes;
			lngRes=m_lngGetLastestAnaesthesiaMode(p_strInPatientID,p_strInPatientDate,p_strCreateDate,out p_objOperationRecord_All.m_objAnaesthesiaModeID);
			if(lngRes<=0)return lngRes;
			lngRes=m_lngGetOperation_Nurse(p_strInPatientID,p_strInPatientDate,p_strCreateDate,out intRowTemp,out p_objOperationRecord_All.m_objOperatorArr);
			if(lngRes<=0)return lngRes;
			lngRes=m_lngGetWoundThing(p_strInPatientID,p_strInPatientDate,p_strCreateDate,out intRowTemp,out p_objOperationRecord_All.m_objWoundThingArr);
			return lngRes;
		}
		#endregion
	
		#region 兜兵醍恪圭塀||哈送麗||返宝園鷹||匳伏庁冊臥儂双燕
		
		public long m_lngGetAnaesthesiaMode(out clsAnaesthesiaModeInOperation[] objAnaesthesiaModeInOperation)
		{
			string strXML="";
			int intRows=0;
			objAnaesthesiaModeInOperation=null;
			long lngRes = 0;

            com.digitalwave.OperationRecord.clsOperationRecordServ m_objServ =
                (com.digitalwave.OperationRecord.clsOperationRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.OperationRecord.clsOperationRecordServ));

            try
            {
                lngRes = m_objServ.m_lngGetAnaesthesiaModeID(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, ref strXML, ref intRows);
                if (lngRes >= 0 && intRows > 0)
                {
                    objAnaesthesiaModeInOperation = new clsAnaesthesiaModeInOperation[intRows];
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
                                    objAnaesthesiaModeInOperation[intIndex] = new clsAnaesthesiaModeInOperation();
                                    objAnaesthesiaModeInOperation[intIndex].strAnaesthesiaModeID = objReader.GetAttribute("ANAESTHESIAMODEID").ToString().Replace('き', '\'');
                                    objAnaesthesiaModeInOperation[intIndex].strAnaesthesiaModeName = objReader.GetAttribute("ANAESTHESIAMODENAME").ToString().Replace('き', '\'');
                                    intIndex++;
                                }
                                break;
                        }

                    }

                }
            }
            finally
            {
                //m_objServ.Dispose();
            }
			return lngRes;
		}

		
		public long m_lngGetWoundThing(string p_strQuery,out clsPublicIDAndName[] m_objWoundThingArr)
		{
			string strXML="";
			int intRows=0;
			m_objWoundThingArr = null;
			long lngRes = 0;

            com.digitalwave.OperationRecord.clsOperationRecordServ m_objServ =
                (com.digitalwave.OperationRecord.clsOperationRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.OperationRecord.clsOperationRecordServ));

            try
            {
                lngRes = m_objServ.m_lngGetWoundThingIDName(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strQuery, out strXML, out intRows);
                if (lngRes >= 0 && intRows > 0)
                {
                    m_objWoundThingArr = new clsPublicIDAndName[intRows];
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
                                    m_objWoundThingArr[intIndex] = new clsPublicIDAndName();
                                    m_objWoundThingArr[intIndex].m_strID = objReader.GetAttribute("WOUNDTHINGID").ToString().Replace('き', '\'');
                                    m_objWoundThingArr[intIndex].m_strName = objReader.GetAttribute("WOUNDTHINGNAME").ToString().Replace('き', '\'');
                                    intIndex++;
                                }
                                break;
                        }

                    }

                }
            }
            finally
            {
                //m_objServ.Dispose();
            }
			return lngRes;

		}

		
		public long m_lngGetOperationID(out clsOperationIDInOperation[] m_objOperationArr )
		{
			string strXML="";
			int intRows=0;
			m_objOperationArr = null;
			long lngRes = 0;

            com.digitalwave.OperationRecord.clsOperationRecordServ m_objServ = 
                (com.digitalwave.OperationRecord.clsOperationRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.OperationRecord.clsOperationRecordServ));

            try
            {
                lngRes = m_objServ.m_lngGetOperationIDName(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, out strXML, out intRows);
                if (lngRes >= 0 && intRows > 0)
                {
                    m_objOperationArr = new clsOperationIDInOperation[intRows];
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
                                    m_objOperationArr[intIndex] = new clsOperationIDInOperation();
                                    m_objOperationArr[intIndex].strOperationID = objReader.GetAttribute("OPERATIONID").ToString().Replace('き', '\'');
                                    m_objOperationArr[intIndex].strOperationName = objReader.GetAttribute("OPERATIONNAME").ToString().Replace('き', '\'');
                                    intIndex++;
                                }
                                break;
                        }

                    }

                }
            }
            finally
            {
                //m_objServ.Dispose();
            }
			return lngRes;
		}


		public System.Windows.Forms.ListViewItem[] m_lviGetEmployee(string strOperator,ref bool bolSuccess)
		{//庁冊臥儂匳伏催
			
			System.Windows.Forms.ListViewItem[] item1=null;
			string strSetXML="";
			int intRows=0;

			long lngRes = 0;

            com.digitalwave.OperationRecord.clsOperationRecordServ m_objServ = 
                (com.digitalwave.OperationRecord.clsOperationRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.OperationRecord.clsOperationRecordServ));

            try
            {
                lngRes = m_objServ.lngXMLLikeQuery_Doctor(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, strOperator, ref strSetXML, ref intRows);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            if(intRows>0)
			{
				item1 = new System.Windows.Forms.ListViewItem[intRows];
				XmlTextReader objReader = new XmlTextReader(strSetXML,XmlNodeType.Element,m_objXmlParser);
				objReader.WhitespaceHandling = WhitespaceHandling.None;
				int intIndex=0;
				while(objReader.Read())
				{
					switch(objReader.NodeType)
					{
						case XmlNodeType.Element:
							if(objReader.HasAttributes)
							{
								item1[intIndex] = new System.Windows.Forms.ListViewItem(objReader.GetAttribute("EMPLOYEEID").ToString().Replace ('き','\''));
								item1[intIndex].SubItems.Add(objReader.GetAttribute("FIRSTNAME").ToString().Replace ('き','\''));
								intIndex ++;
							}
							break;
					}
							
				}
				bolSuccess=true;
				
			}
			else 
				bolSuccess=false;
		
			return item1;
			
		}
		
		
		#endregion 
		
		#region CheckLastModifyDate
		public long m_lngCheckLastModifyRecord(string p_strInPatientID,string p_strInPatientDate,string p_strOpenDate,out string p_strLastModifyDate,out string strModifyUserID)
		{
			p_strLastModifyDate="";
			strModifyUserID="";
			long lngRes = 0;

            com.digitalwave.OperationRecord.clsOperationRecordServ m_objServ = 
                (com.digitalwave.OperationRecord.clsOperationRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.OperationRecord.clsOperationRecordServ));

            try
            {
                lngRes = m_objServ.m_lngCheckLastModifyDate(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_strOpenDate, out p_strLastModifyDate, out strModifyUserID);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}

		#endregion

		#region CheckIfFirstCreate
		
		public long m_lngCheckNewCreateDate(string p_strInPatientID,string p_strInPatientDate,string p_strCreateDate,out bool p_blnIsAddNew)
		{
			long lngRes = 0;

            com.digitalwave.OperationRecord.clsOperationRecordServ m_objServ = 
                (com.digitalwave.OperationRecord.clsOperationRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.OperationRecord.clsOperationRecordServ));

            try
            {
                lngRes = m_objServ.m_lngCheckNewCreateDate(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate,p_strCreateDate,out p_blnIsAddNew);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}
		#endregion

		#region GetDeleteUser
		public long m_lngGetDeleteUser(string p_strInPatientID,string p_strInPatientDate,string p_strOpenDate,out string p_strDeActiveDate,out string strDeActiveUserID)
		{
			p_strDeActiveDate="";
			strDeActiveUserID="";
			long lngRes = 0;

            com.digitalwave.OperationRecord.clsOperationRecordServ m_objServ = 
                (com.digitalwave.OperationRecord.clsOperationRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.OperationRecord.clsOperationRecordServ));

            try
            {
                lngRes = m_objServ.m_lngCheckLastModifyDate(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate,p_strOpenDate,out p_strDeActiveDate,out strDeActiveUserID);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}


		#endregion

		#region All TreeNode(Time)
		public DateTime [] m_dtmGetTimeInfoOfAPatientArr(string p_strInPatientID,string p_strInPatientDate)
		{
			if(p_strInPatientID ==null||p_strInPatientID =="")
				return null;
			DateTime[] dtmCreateRecordDateArr=null;
			string strXml = "";
			int intRows = 0;

			long lngRes = 0;

            com.digitalwave.OperationRecord.clsOperationRecordServ m_objServ = 
                (com.digitalwave.OperationRecord.clsOperationRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.OperationRecord.clsOperationRecordServ));

            try
            {
                lngRes = m_objServ.m_lngGetTimeInfoOfAPatient(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate,ref strXml,ref intRows);
            }
            finally
            {
                //m_objServ.Dispose();
            }
			if(lngRes > 0 && intRows >0)
			{
				dtmCreateRecordDateArr = new DateTime [intRows];

				XmlTextReader objReader = new XmlTextReader(strXml,XmlNodeType.Element,m_objXmlParser);
				objReader.WhitespaceHandling = WhitespaceHandling.None;
			
				int intIndex = 0;
				while(objReader.Read())
				{
					switch (objReader.NodeType)
					{
						case XmlNodeType.Element:
							if(objReader.HasAttributes)
							{
								dtmCreateRecordDateArr[intIndex]=DateTime.Parse (objReader.GetAttribute("CREATEDATE"));
								intIndex++;
							}
							break;
					}
				}
			}
			return dtmCreateRecordDateArr ;
		}
 
		#endregion
		
		#region 隠贋
		public long m_lngSave(clsOperationRecord p_objOperationRecord,clsOperationRecordContent p_objOperationRecordContent,clsOperationDoctorNurse[] objOperationNurseArr,clsOperationRecord_OperationID  m_objOperationRecordOperation,clsOperationRecord_Anaesthesia m_objOperationRecordAnaesthesia,clsOperationWoundThingInfo[] m_objWoundThingArr,bool p_blnIsAddNew)
		{
			if(p_objOperationRecord == null || p_objOperationRecordContent == null || m_objOperationRecordOperation == null || m_objOperationRecordAnaesthesia == null)
				return -1;
            //string [] m_strNurseXMLArr = m_strGetNurseXML(objOperationNurseArr ,p_blnIsAddNew);
            //string m_strOperationTableXML = m_strGetOperationTableXML(m_objOperationRecordOperation,p_blnIsAddNew);
            //string m_strAnaesthesiaTableXML = m_strGetAnaesthesiaTableXML(m_objOperationRecordAnaesthesia);
            string[] m_strNurseXMLArr = null;
            string m_strOperationTableXML = null;
            string m_strAnaesthesiaTableXML = null;
			string[] m_strWoundThingTableXMLArr = m_strGetWoundThingTableXML(m_objWoundThingArr,p_blnIsAddNew);
            long lngRes = 0;

            com.digitalwave.OperationRecord.clsOperationRecordServ m_objServ = 
                (com.digitalwave.OperationRecord.clsOperationRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.OperationRecord.clsOperationRecordServ));

            try
            {
                if (p_blnIsAddNew == true)
                    lngRes = m_objServ.m_lngAddNew(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, m_strGetMasterXML(p_objOperationRecord, p_blnIsAddNew), m_strGetContentXML(p_objOperationRecordContent, p_blnIsAddNew), m_strNurseXMLArr, m_strOperationTableXML, m_strAnaesthesiaTableXML, m_strWoundThingTableXMLArr);
                else
                    lngRes = m_objServ.m_lngModify(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, m_strGetMasterXML(p_objOperationRecord, p_blnIsAddNew), m_strGetContentXML(p_objOperationRecordContent, p_blnIsAddNew), m_strNurseXMLArr, m_strOperationTableXML, m_strAnaesthesiaTableXML, m_strWoundThingTableXMLArr);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}
		#endregion 

		#region 評茅

		public long m_lngDeleteRecord(string  p_strInPatientID, string p_strInPatientDate,string  p_strOpenDate )
		{
            long lngRes = 0;

            com.digitalwave.OperationRecord.clsOperationRecordServ m_objServ = 
                (com.digitalwave.OperationRecord.clsOperationRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.OperationRecord.clsOperationRecordServ));

            try
            {
                lngRes = m_objServ.m_lngDelete(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_strOpenDate, MDIParent.OperatorID);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}
		#endregion 

		#region FirstPrint
		public long m_lngUpdateFirstPrintDate(string p_strInPatientID,string p_strInPatientDate,string p_strOpenDate,string p_strFirstPrintDate)
		{//厚仟及匯肝嬉咫扮寂		
			long lngRes = 0;

            com.digitalwave.OperationRecord.clsOperationRecordServ m_objServ = 
                (com.digitalwave.OperationRecord.clsOperationRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.OperationRecord.clsOperationRecordServ));

            try
            {
                lngRes = m_objServ.m_lngUpdateFirstPrintDate(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_strOpenDate, p_strFirstPrintDate);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}

		#endregion

		#region Obj->XML For Save
		private string[] m_strGetNurseXML(clsOperationDoctorNurse[] objOperationNurseArr,bool IsAddNew)
		{
			if(objOperationNurseArr == null || objOperationNurseArr.Length <=0)
				return null;
			string[] m_strXMLArr = new string[objOperationNurseArr.Length];
			for(int i1=0;i1<objOperationNurseArr.Length;i1++)
			{
				m_objXmlMemStream.SetLength(0);
			
				m_objXmlWriter.WriteStartDocument();
				m_objXmlWriter.WriteStartElement("RecordMaster");
			
				m_objXmlWriter.WriteAttributeString("INPATIENTID", objOperationNurseArr[i1].strInPatientID.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("INPATIENTDATE", objOperationNurseArr[i1].strInPatientDate.Replace('\'','き'));
				
				m_objXmlWriter.WriteAttributeString("OPENDATE", objOperationNurseArr[i1].strOpenDate.Replace('\'','き'));				
				m_objXmlWriter.WriteAttributeString("LASTMODIFYDATE", objOperationNurseArr[i1].strLastModifyDate.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("OPERTORID", objOperationNurseArr[i1].strNurseID.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("OPERATORFLAG", objOperationNurseArr[i1].strNurseFlag.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("STATUS", objOperationNurseArr[i1].strStatus.Replace('\'','き'));
			
				m_objXmlWriter.WriteEndElement();          
				m_objXmlWriter.WriteEndDocument();
				m_objXmlWriter.Flush();			
				m_strXMLArr[i1] = System.Text.Encoding.Unicode.GetString(m_objXmlMemStream.ToArray(),39*2,(int)m_objXmlMemStream.Length-39*2);
			}
			return m_strXMLArr;
		}

				
		private string m_strGetOperationTableXML(clsOperationRecord_OperationID  m_objOperationRecordOperation,bool IsAddNew)
		{
			try
			{
				if(m_objOperationRecordOperation == null)
					return null;
				m_objXmlMemStream.SetLength(0);
			
				m_objXmlWriter.WriteStartDocument();
				m_objXmlWriter.WriteStartElement("RecordMaster");
			}
			catch(Exception ex)
			{
				clsPublicFunction.ShowInformationMessageBox(ex.Message);
			}
			
				m_objXmlWriter.WriteAttributeString("INPATIENTID", m_objOperationRecordOperation.strInPatientID.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("INPATIENTDATE", m_objOperationRecordOperation.strInPatientDate.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("OPENDATE", m_objOperationRecordOperation.strOpenDate.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("LASTMODIFYDATE", m_objOperationRecordOperation.strModifyDate.Replace('\'','き'));
                //m_objXmlWriter.WriteAttributeString("OPERATIONID", m_objOperationRecordOperation.strOperationID.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("STATUS", m_objOperationRecordOperation.strStatus.Replace('\'','き'));
				m_objXmlWriter.WriteEndElement();          
				m_objXmlWriter.WriteEndDocument();
				m_objXmlWriter.Flush();	
			
			return System.Text.Encoding.Unicode.GetString(m_objXmlMemStream.ToArray(),39*2,(int)m_objXmlMemStream.Length-39*2);
		}

		
		private string m_strGetAnaesthesiaTableXML(clsOperationRecord_Anaesthesia m_objOperationRecordAnaesthesia)
		{
			if(m_objOperationRecordAnaesthesia == null)
				return null;
			m_objXmlMemStream.SetLength(0);
			
			m_objXmlWriter.WriteStartDocument();
			m_objXmlWriter.WriteStartElement("RecordMaster");
			
			m_objXmlWriter.WriteAttributeString("INPATIENTID", m_objOperationRecordAnaesthesia.strInPatientID.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("INPATIENTDATE", m_objOperationRecordAnaesthesia.strInPatientDate.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("OPENDATE", m_objOperationRecordAnaesthesia.strOpenDate.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("ANAESTHESIAMODEID", m_objOperationRecordAnaesthesia.strAnaesthesiaModeID.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("LASTMODIFYDATE", m_objOperationRecordAnaesthesia.strModifyDate.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("STATUS", m_objOperationRecordAnaesthesia.strStatus.Replace('\'','き'));
			m_objXmlWriter.WriteEndElement();          
			m_objXmlWriter.WriteEndDocument();
			m_objXmlWriter.Flush();			
			return System.Text.Encoding.Unicode.GetString(m_objXmlMemStream.ToArray(),39*2,(int)m_objXmlMemStream.Length-39*2);
		}
		
		
		private string[] m_strGetWoundThingTableXML(clsOperationWoundThingInfo[] m_objWoundThingArr,bool IsAddNew)
		{
			if(m_objWoundThingArr == null || m_objWoundThingArr.Length <= 0)
				return null;
			string[] m_strXMLArr = new string[m_objWoundThingArr.Length];
			for(int i1=0;i1<m_objWoundThingArr.Length;i1++)
			{
				m_objXmlMemStream.SetLength(0);
				m_objXmlWriter.WriteStartDocument();
				m_objXmlWriter.WriteStartElement("WoundThing");
				m_objXmlWriter.WriteAttributeString("INPATIENTID", m_objWoundThingArr[i1].strInPatientID.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("INPATIENTDATE", m_objWoundThingArr[i1].strInPatientDate.Replace('\'','き'));
				
				m_objXmlWriter.WriteAttributeString("OPENDATE", m_objWoundThingArr[i1].strOpenDate.Replace('\'','き'));
				
				m_objXmlWriter.WriteAttributeString("LASTMODIFYDATE", m_objWoundThingArr[i1].strLastModifyDate.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("QUANTITY", m_objWoundThingArr[i1].strQuantity.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("WOUNDTHINGID", m_objWoundThingArr[i1].strWoundThingID.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("STATUS", m_objWoundThingArr[i1].strStatus.Replace('\'','き'));
				m_objXmlWriter.WriteEndElement();          
				m_objXmlWriter.WriteEndDocument();
				m_objXmlWriter.Flush();			
				m_strXMLArr[i1] = System.Text.Encoding.Unicode.GetString(m_objXmlMemStream.ToArray(),39*2,(int)m_objXmlMemStream.Length-39*2);
			}
			return m_strXMLArr;
		}
		
		private string m_strGetContentXML(clsOperationRecordContent  p_objOperationRecordContent ,bool IsAddNew)
		{
		
			m_objXmlMemStream.SetLength(0);
			
			m_objXmlWriter.WriteStartDocument();
			m_objXmlWriter.WriteStartElement("RecordContent");
			
			m_objXmlWriter.WriteAttributeString("INPATIENTID", p_objOperationRecordContent.strInPatientID.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("INPATIENTDATE", p_objOperationRecordContent.strInPatientDate.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("OPENDATE", p_objOperationRecordContent.strOpenDate.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("LASTMODIFYDATE", p_objOperationRecordContent.strLastModifyDate.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("LASTMODIFYUSERID", p_objOperationRecordContent.strLastModifyUserID.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("STATUS", p_objOperationRecordContent.strStatus.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("PATIENTINDATE", p_objOperationRecordContent.strPatientInDate.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("OPERATIONBEGINDATE", p_objOperationRecordContent.strOperationBeginDate.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("OPERATIONENDDATE", p_objOperationRecordContent.strOperationEndDate.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("OPERATIONLEAVEDATE", p_objOperationRecordContent.strOperationLeaveDate.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SENSESCLEARHEADED", p_objOperationRecordContent.strSensesClearHeaded.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SENSESSLEEP", p_objOperationRecordContent.strSensesSleep.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SENSESCOMA", p_objOperationRecordContent.strSensesComa.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("HAVEALLERGIC", p_objOperationRecordContent.strHaveAllergic.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("HAVENOTALLERGIC", p_objOperationRecordContent.strHaveNotAllergic.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("ALLERGICCONTENT", p_objOperationRecordContent.strAllergicContent.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("OPERATIONLOCATIONONHISBACK", p_objOperationRecordContent.strOperationLocationOnHisBack.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("OPERATIONLOCATIONSIDE", p_objOperationRecordContent.strOperationLocationSide.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("OPERATIONLOCATIONPA", p_objOperationRecordContent.strOperationLocationPA.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("OPERATIONLOCATIONPARAPLEGIC", p_objOperationRecordContent.strOperationLocationParaplegic.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("OPERATIONLOCATIONHYPOTHYROID", p_objOperationRecordContent.strOperationLocationHypothyroid.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("OPERATIONLOCATIONOTHER", p_objOperationRecordContent.strOperationLocationOther.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("OTHEROPERATIONLOCATION", p_objOperationRecordContent.strOtherOperationLocation.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("HAVENOTELECTKNIFE", p_objOperationRecordContent.strHaveNotElectKnife.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("HAVEUSEDELECTKNIFE", p_objOperationRecordContent.strHaveUsedElectKnife.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("ELECTKNIFEMODEL", p_objOperationRecordContent.strElectKnifeModel.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("HAVENOTDOUBLEPOLE", p_objOperationRecordContent.strHaveNotDoublePole.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("HAVEDOUBLEPOLE", p_objOperationRecordContent.strHaveDoublePole.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("DOUBLEPOLECONTENT", p_objOperationRecordContent.strDoublePoleContent.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("CATHODELOCATION", p_objOperationRecordContent.strCathodeLocation.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("CATHODELOCSKINBFOPRMAR", p_objOperationRecordContent.strCathodeLocationSkinBeforOperationMar.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("CATHODELOCSKINBFOPRFULL", p_objOperationRecordContent.strCathodeLocationSkinBeforOperationFull.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("CATHODELOCSKINAFOPRMAR", p_objOperationRecordContent.strCathodeLocationSkinAfterOperationMar.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("CATHODELOCSKINAFOPRFULL", p_objOperationRecordContent.strCathodeLocationSkinAfterOperationFull.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("STYPTICRUBBER", p_objOperationRecordContent.strStypticRubber.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("STYPTICPRESSURE", p_objOperationRecordContent.strStypticPressure.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("UPFOREARM", p_objOperationRecordContent.strUpForearm.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("UPTHIGH", p_objOperationRecordContent.strUpThigh.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("UPRIGHT", p_objOperationRecordContent.strUpRight.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("UPLEFT", p_objOperationRecordContent.strUpLeft.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("UPPUFFDATETIME", p_objOperationRecordContent.strUpPuffDateTime.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("UPDEFLATEDATETIME", p_objOperationRecordContent.strUpDeflateDateTime.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("UPTOTALDATETIME", p_objOperationRecordContent.strUpTotalDateTime.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("UPPRESS", p_objOperationRecordContent.strUpPress.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("DOWNFOREARM", p_objOperationRecordContent.strDownForearm.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("DOWNTHIGH", p_objOperationRecordContent.strDownThigh.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("DOWNRIGHT", p_objOperationRecordContent.strDownRight.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("DOWNLEFT", p_objOperationRecordContent.strDownLeft.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("DOWNPUFFDATETIME", p_objOperationRecordContent.strDownPuffDateTime.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("DOWNDEFLATEDATETIME", p_objOperationRecordContent.strDownDeflateDateTime.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("DOWNTOTALDATETIME", p_objOperationRecordContent.strDownTotalDateTime.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("DOWNPRESS", p_objOperationRecordContent.strDownPress.Replace('\'','き'));
						
			m_objXmlWriter.WriteAttributeString("FOLEYSICKROOM", p_objOperationRecordContent.strFoleySickroom.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("FOLEYOPERATIONROOM", p_objOperationRecordContent.strFoleyOperationRoom.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("FOLEYDOUBLEANTRUM", p_objOperationRecordContent.strFoleyDoubleAntrum.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("FOLEYTHREEANTRUM", p_objOperationRecordContent.strFoleyThreeAntrum.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("FOLEYOTHER", p_objOperationRecordContent.strFoleyOther.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("STOMACHSICKROOM", p_objOperationRecordContent.strStomachSickroom.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("STOMACHOPRATIONROOM", p_objOperationRecordContent.strStomachOprationRoom.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SKINANTISEPSIS2", p_objOperationRecordContent.strSkinAntisepsis2.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SKINANTISEPSIS75", p_objOperationRecordContent.strSkinAntisepsis75.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SKINANTISEPSISIODIN", p_objOperationRecordContent.strSkinAntisepsisIodin.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SKINANTISEPSISIODINRARE", p_objOperationRecordContent.strSkinAntisepsisIodinRare.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SKINANTISEPSISOTHER", p_objOperationRecordContent.strSkinAntisepsisOther.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("ALLBLOOD", p_objOperationRecordContent.strAllBlood.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("ALLBLOODQTY", p_objOperationRecordContent.strAllBloodQty.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("REDCELL", p_objOperationRecordContent.strRedCell.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("REDCELLQTY", p_objOperationRecordContent.strRedCellQty.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("BLOODPLASM", p_objOperationRecordContent.strBloodPlasm.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("BLOODPLASMQTY", p_objOperationRecordContent.strBloodPlasmQty.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("OWNBLOOD", p_objOperationRecordContent.strOwnBlood.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("OWNBLOODQTY", p_objOperationRecordContent.strOwnBloodQty.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("BLOODOTHER", p_objOperationRecordContent.strBloodOther.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("BLOODOTHERQTY", p_objOperationRecordContent.strBloodOtherQty.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("INLIQUIDQTY", p_objOperationRecordContent.strInLiquidQty.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("PEEOPERATINGQTY", p_objOperationRecordContent.strPeeOperatingQty.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("HAVEOUTFLOW", p_objOperationRecordContent.strHaveOutFlow.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("NOTHAVEOUTFLOW", p_objOperationRecordContent.strNotHaveOutFlow.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("FROMHEADTOFOOTSKINBFOPRMAR", p_objOperationRecordContent.strFromHeadToFootSkinBeforeOperationMar.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("FROMHEADTOFOOTSKINBFOPRFULL", p_objOperationRecordContent.strFromHeadToFootSkinBeforeOperationFull.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("FROMHEADTOFOOTSKINBFOPRCONT", p_objOperationRecordContent.strFromHeadToFootSkinBeforeOperationContent.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("FROMHEADTOFOOTSKINAFOPRMAR", p_objOperationRecordContent.strFromHeadToFootSkinAfterOperationMar.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("FROMHEADTOFOOTSKINAFOPRFULL", p_objOperationRecordContent.strFromHeadToFootSkinAfterOperationFull.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("FROMHEADTOFOOTSKINAFOPRCONT", p_objOperationRecordContent.strFromHeadToFootSkinAfterOperationContent.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SAMPLEGENERAL", p_objOperationRecordContent.strSampleGeneral.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SAMPLESLICE", p_objOperationRecordContent.strSampleSlice.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SAMPLEBACILLI", p_objOperationRecordContent.strSampleBacilli.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SAMPLEOTHER", p_objOperationRecordContent.strSampleOther.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("AFTEROPERATIONSENDRENEW", p_objOperationRecordContent.strAfterOperationSendRenew.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("AFTEROPERATIONSENDICU", p_objOperationRecordContent.strAfterOperationSendICU.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("AFTEROPERATIONSENDSICKROOM", p_objOperationRecordContent.strAfterOperationSendSickRoom.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("TENDRECORD", p_objOperationRecordContent.strTendRecord.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("ANAESTHESIAMODE", p_objOperationRecordContent.strAnaesthesiaMode.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("OPERATIONNAME", p_objOperationRecordContent.strOperationName.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("OPERATIONROOM", p_objOperationRecordContent.strOperationRoom.Replace('\'','き'));
			//
			m_objXmlWriter.WriteAttributeString("STYPTICPRESSUREMODE", p_objOperationRecordContent.strStypticPressureMode.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("FOLEYOTHERCONTENT", p_objOperationRecordContent.strFoleyOtherContent.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SKINANTISEPSISOTHERCONTENT", p_objOperationRecordContent.strSkinAntisepsisOtherContent.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SAMPLEOTHERCONTENT", p_objOperationRecordContent.strSampleOtherContent.Replace('\'','き'));
			//			
					
			m_objXmlWriter.WriteEndElement();          
			m_objXmlWriter.WriteEndDocument();
			m_objXmlWriter.Flush();			

			return System.Text.Encoding.Unicode.GetString(m_objXmlMemStream.ToArray(),39*2,(int)m_objXmlMemStream.Length-39*2);
		}
		
		public string m_strGetMasterXML(clsOperationRecord  objOperationRecord ,bool IsAddNew)
		{
			try
			{
				m_objXmlMemStream.SetLength(0);
				m_objXmlWriter.WriteStartDocument();
				m_objXmlWriter.WriteStartElement("RecordMaster");
				m_objXmlWriter.WriteAttributeString("INPATIENTID", objOperationRecord.strInPatientID.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("INPATIENTDATE", objOperationRecord.strInPatientDate.Replace('\'','き'));
				
				m_objXmlWriter.WriteAttributeString("OPENDATE", objOperationRecord.strOpenDate.Replace('\'','き'));
				
				m_objXmlWriter.WriteAttributeString("CREATEDATE", objOperationRecord.strCreateDate.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("CREATEUSERID", objOperationRecord.strCreateUserID.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("STATUS", objOperationRecord.strStatus.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("IFCONFIRM", objOperationRecord.strIfConfirm.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("SENSESXML", objOperationRecord.strSensesXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("ALLERGICXML", objOperationRecord.strAllergicXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("OPERATIONLOCATIONXML", objOperationRecord.strOperationLocationXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("ELECTKNIFEXML", objOperationRecord.strElectKnifeXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("DOUBLEPOLEXML", objOperationRecord.strDoublePoleXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("CATHODELOCATIONSKINXML", objOperationRecord.strCathodeLocationSkinXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("STYPTICRUBBERXML", objOperationRecord.strStypticRubberXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("UPXML", objOperationRecord.strUpXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("DOWNXML", objOperationRecord.strDownXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("FOLEYXML", objOperationRecord.strFoleyXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("STOMACHXML", objOperationRecord.strStomachXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("SKINANTISEPSISXML", objOperationRecord.strSkinAntisepsisXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("BLOODXML", objOperationRecord.strBloodXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("INLIQUIDQTYXML", objOperationRecord.strInLiquidQtyXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("PEEOPERATINGQTYXML", objOperationRecord.strPeeOperatingQtyXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("OUTFLOWXML", objOperationRecord.strOutFlowXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("FROMHEADTOFOOTSKINXML", objOperationRecord.strFromHeadToFootSkinXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("SAMPLEXML", objOperationRecord.strSampleXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("AFTEROPERATIONSENDXML", objOperationRecord.strAfterOperationSendXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("TENDRECORDXML", objOperationRecord.strTendRecordXML.Replace('\'','き'));
                //m_objXmlWriter.WriteAttributeString("ANAESTHESIAMODEXML", objOperationRecord.strAnaesthesiaModeXML.Replace('\'','き'));
                //m_objXmlWriter.WriteAttributeString("OPERATIONNAMEXML", objOperationRecord.strOperationNameXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("CATHODELOCSKINAFOPRXML", objOperationRecord.strCathodeLocationSkinAfterOperationXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("FROMHEADTOFOOTSKINAFOPRXML", objOperationRecord.strFromHeadToFootSkinAfterOperationXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("OPERATIONROOMXML", objOperationRecord.strOperationRoomXML.Replace('\'','き'));

				m_objXmlWriter.WriteAttributeString("OPERATION_ANAESTHESIAXML", objOperationRecord.strOperation_AnaesthesiaXML.Replace('\'','き'));


				m_objXmlWriter.WriteAttributeString("ALLERGICCONTENTXML", objOperationRecord.strAllergicContentXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("OTHEROPERATIONLOCATIONXML", objOperationRecord.strOtherOperationLocationXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("ELECTKNIFEMODELXML", objOperationRecord.strElectKnifeModelXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("DOUBLEPOLECONTENTXML", objOperationRecord.strDoublePoleContentXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("CATHODELOCATIONXML", objOperationRecord.strCathodeLocationXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("STYPTICPRESSUREMODEXML", objOperationRecord.strStypticPressureModeXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("UPPUFFDATETIMEXML", objOperationRecord.strUpPuffDateTimeXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("UPDEFLATEDATETIMEXML", objOperationRecord.strUpDeflateDateTimeXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("UPTOTALDATETIMEXML", objOperationRecord.strUpTotalDateTimeXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("UPPRESSXML", objOperationRecord.strUpPressXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("DOWNPUFFDATETIMEXML", objOperationRecord.strDownPuffDateTimeXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("DOWNDEFLATEDATETIMEXML", objOperationRecord.strDownDeflateDateTimeXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("DOWNTOTALDATETIMEXML", objOperationRecord.strDownTotalDateTimeXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("DOWNPRESSXML", objOperationRecord.strDownPressXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("FOLEYOTHERCONTENTXML", objOperationRecord.strFoleyOtherContentXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("SKINANTISEPSISOTHERCONTENTXML", objOperationRecord.strSkinAntisepsisOtherContentXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("ALLBLOODQTYXML", objOperationRecord.strAllBloodQtyXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("REDCELLQTYXML", objOperationRecord.strRedCellQtyXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("BLOODPLASMQTYXML", objOperationRecord.strBloodPlasmQtyXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("OWNBLOODQTYXML", objOperationRecord.strOwnBloodQtyXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("BLOODOTHERQTYXML", objOperationRecord.strBloodOtherQtyXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("FROMHEADTOFOOTSKINBFOPRCONTXML", objOperationRecord.strFromHeadToFootSkinBeforeOperationContentXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("FROMHEADTOFOOTSKINAFOPRCONTXML", objOperationRecord.strFromHeadToFootSkinAfterOperationContentXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("SAMPLEOTHERCONTENTXML", objOperationRecord.strSampleOtherContentXML.Replace('\'','き'));

                long lngSignSequence = 0;
                com.digitalwave.PublicMiddleTier.clsPublicMiddleTier objService =
                    (com.digitalwave.PublicMiddleTier.clsPublicMiddleTier)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.PublicMiddleTier.clsPublicMiddleTier));
                long lngRes = objService.m_lngGetSequenceValue("SEQ_EMR_SIGN", out lngSignSequence);
                m_objXmlWriter.WriteAttributeString("SEQUENCE_INT", lngSignSequence.ToString().Replace('\'', 'き'));

				m_objXmlWriter.WriteEndElement();          
				m_objXmlWriter.WriteEndDocument();
                m_objXmlWriter.Flush();

                lngRes = objService.m_lngAddSign(objOperationRecord.objSignerArr, lngSignSequence);

				return System.Text.Encoding.Unicode.GetString(m_objXmlMemStream.ToArray(),39*2,(int)m_objXmlMemStream.Length-39*2);
			}
			catch(Exception e)
			{
				clsPublicFunction.ShowInformationMessageBox(e.Message );
			}
			return null;
		}

		#endregion

        #region Old Code 
		#region 庁冊臥儂

		/// <summary>
		/// 資誼醍恪圭塀
		/// </summary>
		/// <returns></returns>
		public clsAnaesthesiaModeInOperation[] m_objGetAnaesthesiaMode()
		{
			string strXML="";
			int intRows=0;
			clsAnaesthesiaModeInOperation[] objAnaesthesiaModeInOperation=null;
			long lngRes = 0;

            com.digitalwave.OperationRecord.clsOperationRecordServ m_objServ = 
                (com.digitalwave.OperationRecord.clsOperationRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.OperationRecord.clsOperationRecordServ));

            try
            {
                lngRes = m_objServ.m_lngGetAnaesthesiaModeID(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, ref strXML, ref intRows);
            }
            finally
            {
                //m_objServ.Dispose();
            }
			if(lngRes>=0 && intRows>0)
			{
				objAnaesthesiaModeInOperation=new clsAnaesthesiaModeInOperation[intRows];
				XmlTextReader objReader = new XmlTextReader(strXML,XmlNodeType.Element,m_objXmlParser);
				objReader.WhitespaceHandling = WhitespaceHandling.None;
				int intIndex=0;
				while(objReader.Read())
				{
					switch(objReader.NodeType)
					{
						case XmlNodeType.Element:
							if(objReader.HasAttributes)
							{
								objAnaesthesiaModeInOperation[intIndex]=new clsAnaesthesiaModeInOperation ();
								objAnaesthesiaModeInOperation[intIndex].strAnaesthesiaModeID=objReader.GetAttribute("ANAESTHESIAMODEID").ToString().Replace ('き','\'');
								objAnaesthesiaModeInOperation[intIndex].strAnaesthesiaModeName=objReader.GetAttribute("ANAESTHESIAMODENAME").ToString().Replace ('き','\'');
								intIndex ++;
							}
							break;
					}
							
				}

			}
			return objAnaesthesiaModeInOperation;
		}

		/// <summary>
		/// 資誼返宝坪否
		/// </summary>
		/// <returns></returns>
		public clsOperationIDInOperation[] m_objGetOperationID()
		{
			string strXML="";
			int intRows=0;
			clsOperationIDInOperation[] m_objOperationArr = null;
			long lngRes = 0;

            com.digitalwave.OperationRecord.clsOperationRecordServ m_objServ = 
                (com.digitalwave.OperationRecord.clsOperationRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.OperationRecord.clsOperationRecordServ));

            try
            {
                lngRes = m_objServ.m_lngGetOperationIDName(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, out strXML, out intRows);
            }
            finally
            {
                //m_objServ.Dispose();
            }
			if(lngRes>=0 && intRows>0)
			{
				m_objOperationArr=new clsOperationIDInOperation[intRows];
				XmlTextReader objReader = new XmlTextReader(strXML,XmlNodeType.Element,m_objXmlParser);
				objReader.WhitespaceHandling = WhitespaceHandling.None;
				int intIndex=0;
				while(objReader.Read())
				{
					switch(objReader.NodeType)
					{
						case XmlNodeType.Element:
							if(objReader.HasAttributes)
							{
								m_objOperationArr[intIndex]=new clsOperationIDInOperation();
								m_objOperationArr[intIndex].strOperationID=objReader.GetAttribute("OPERATIONID").ToString().Replace ('き','\'');
								m_objOperationArr[intIndex].strOperationName=objReader.GetAttribute("OPERATIONNAME").ToString().Replace ('き','\'');
								intIndex ++;
							}
							break;
					}
							
				}

			}
			return m_objOperationArr;
		}

		/// <summary>
		/// 資誼哈送麗
		/// </summary>
		/// <returns></returns>
		public clsPublicIDAndName[] m_objGetWoundThing(string p_strQuery)
		{
			string strXML="";
			int intRows=0;
			clsPublicIDAndName[] m_objWoundThingArr = null;
			long lngRes = 0;

            com.digitalwave.OperationRecord.clsOperationRecordServ m_objServ = 
                (com.digitalwave.OperationRecord.clsOperationRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.OperationRecord.clsOperationRecordServ));

            try
            {
                lngRes = m_objServ.m_lngGetWoundThingIDName(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strQuery, out strXML, out intRows);
            }
            finally
            {
                //m_objServ.Dispose();
            }
			if(lngRes>=0 && intRows>0)
			{
				m_objWoundThingArr=new clsPublicIDAndName[intRows];
				XmlTextReader objReader = new XmlTextReader(strXML,XmlNodeType.Element,m_objXmlParser);
				objReader.WhitespaceHandling = WhitespaceHandling.None;
				int intIndex=0;
				while(objReader.Read())
				{
					switch(objReader.NodeType)
					{
						case XmlNodeType.Element:
							if(objReader.HasAttributes)
							{
								m_objWoundThingArr[intIndex]=new clsPublicIDAndName();
								m_objWoundThingArr[intIndex].m_strID=objReader.GetAttribute("WOUNDTHINGID").ToString().Replace ('き','\'');
								m_objWoundThingArr[intIndex].m_strName=objReader.GetAttribute("WOUNDTHINGNAME").ToString().Replace ('き','\'');
								intIndex ++;
							}
							break;
					}
							
				}

			}
			return m_objWoundThingArr;

		}
		#endregion
		#endregion

	}
	#region 方象勧補窃
	
//	[Serializable]
//	public class clsOperationRecordContent
//	{
//		public string strInPatientID;
//		public string strInPatientDate;
//		public string strOpenDate;
//		public string strLastModifyDate;
//		
//		public string strLastModifyUserID;
//		public string strStatus;
//		public string strDeActivedDate;
//		public string strDeActivedOperatorID;
//
//
//		public string strOperationName;
//		public string strAnaesthesiaMode;
//		public string strOperationDoctorID;
//		public string strAnaesthesiaDoctorID;
//		public string strPatientInDate;
//		public string strOperationBeginDate;
//		public string strOperationEndDate;
//		public string strOperationLeaveDate;
//		public string strNoBacillusDcotorID;
//		public string strNurseID;
//		public string strCircuitNurseID;
//		public string strWashHandsNurseID;
//
//		
//		public string strSensesClearHeaded;
//		public string strSensesSleep;
//		public string strSensesComa;
//		public string strHaveAllergic;
//		public string strHaveNotAllergic;
//		public string strAllergicContent;
//		public string strOperationLocationOnHisBack;
//		public string strOperationLocationSide;
//		public string strOperationLocationPA;
//		public string strOperationLocationParaplegic;
//		public string strOperationLocationHypothyroid;
//		public string strOperationLocationOther;
//		public string strOtherOperationLocation;
//		public string strHaveNotElectKnife;
//		public string strHaveUsedElectKnife;
//		public string strElectKnifeModel;
//		public string strHaveNotDoublePole;
//		public string strHaveDoublePole;
//		public string strDoublePoleContent;
//		public string strCathodeLocation;
//		public string strCathodeLocationSkinBeforOperationMar;
//		public string strCathodeLocationSkinBeforOperationFull;
//		public string strCathodeLocationSkinAfterOperationMar;
//		public string strCathodeLocationSkinAfterOperationFull;
//		public string strStypticRubber;
//		public string strStypticPressure;
//	    public string strStypticPressureMode;
//		public string strUpForearm;
//		public string strUpThigh;
//		public string strUpRight;
//		public string strUpLeft;
//		public string strUpPuffDateTime;
//		public string strUpDeflateDateTime;
//		public string strUpTotalDateTime;
//		public string strUpPress;
//		public string strDownForearm;
//		public string strDownThigh;
//		public string strDownRight;
//		public string strDownLeft;
//		public string strDownPuffDateTime;
//		public string strDownDeflateDateTime;
//		public string strDownTotalDateTime;
//		public string strDownPress;
//		public string strFoleySickroom;
//		public string strFoleyOperationRoom;
//		public string strFoleyDoubleAntrum;
//        public string strFoleyThreeAntrum;
//	    public string strFoleyOther;
//        public string strFoleyOtherContent;
//	    public string strStomachSickroom;
//		public string strStomachOprationRoom;
//		public string strSkinAntisepsis2;
//		public string strSkinAntisepsis75;
//		public string strSkinAntisepsisIodin;
//		public string strSkinAntisepsisIodinRare;
//		public string strSkinAntisepsisOther;
//        public string strSkinAntisepsisOtherContent;
//		public string strAllBlood;
//		public string strAllBloodQty;
//		public string strRedCell;
//		public string strRedCellQty;
//		public string strBloodPlasm;
//		public string strBloodPlasmQty;
//		public string strOwnBlood;
//		public string strOwnBloodQty;
//		public string strBloodOther;
//		public string strBloodOtherQty;
//		public string strInLiquidQty;
//		public string strPeeOperatingQty;
//		public string strHaveOutFlow;
//		public string strNotHaveOutFlow;
//		public string strFromHeadToFootSkinBeforeOperationMar;
//		public string strFromHeadToFootSkinBeforeOperationFull;
//		public string strFromHeadToFootSkinBeforeOperationContent;
//		public string strFromHeadToFootSkinAfterOperationMar;
//		public string strFromHeadToFootSkinAfterOperationFull;
//		public string strFromHeadToFootSkinAfterOperationContent;
//		public string strSampleGeneral;
//		public string strSampleSlice;
//		public string strSampleBacilli;
//		public string strSampleOther;
//        public string strSampleOtherContent;
//		public string strAfterOperationSendRenew;
//		public string strAfterOperationSendICU;
//		public string strAfterOperationSendSickRoom;
//		public string strTendRecord;
//		public string strOperationRoom;
//		
//
//
//	}
//	
//	[Serializable]
//	public class clsOperationRecord
//	{
//		public string strInPatientID;
//		public string strInPatientDate;
//		public string strOpenDate;
//		public string strFirstPrintDate;
//
//		public string strCreateDate;
//        
//		public string strCreateUserID;
//		public string strStatus;
//		public string strIfConfirm;
//		public string strConfirmReason;
//		public string strConfirmReasonXML;
//
//		public string strDeActivedDate;
//		public string strDeActivedOperatorID;
//	
//
//		public string strOperationNameXML;
//		public string strAnaesthesiaModeXML;
//		public string strSensesXML;
//		public string strAllergicXML;
//		public string strOperationLocationXML;
//    	public string strElectKnifeXML;
//		public string strDoublePoleXML;
//		public string strCathodeLocationSkinXML;
//		public string strStypticRubberXML;
//		public string strUpXML;
//		public string strDownXML;
//		public string strFoleyXML;
//		public string strStomachXML;
//		public string strSkinAntisepsisXML;
//		public string strBloodXML;
//		public string strInLiquidQtyXML;
//		public string strPeeOperatingQtyXML;
//		public string strOutFlowXML;
//		public string strFromHeadToFootSkinXML;
//		public string strSampleXML;
//		public string strAfterOperationSendXML;
//		public string strTendRecordXML;
//		public string strOperationRoomXML;
//		public string strCathodeLocationSkinAfterOperationXML;
//		public string strFromHeadToFootSkinAfterOperationXML;
//
//        			
//		public string strOperation_AnaesthesiaXML;
//		/// <summary>
//		/// 喘噐貫方象垂方象垂臥儂扮聞喘
//		/// 喘噐參朔曳熟朔頁倦葎�猴�坪否議Object
//		/// </summary>
//		public string strXML_TotalRecord;
//
//		public string strPatientInDate;
//		public string strOperationBeginDate;
//		public string strOperationEndDate;
//		public string strOperationLeaveDate;
//
//        
//		public string strAllergicContentXML;
//		public string strOtherOperationLocationXML;
//		public string strElectKnifeModelXML;
//		public string strDoublePoleContentXML;
//		public string strCathodeLocationXML;
//		public string strStypticPressureModeXML;
//		public string strUpPuffDateTimeXML;
//		public string strUpDeflateDateTimeXML;
//		public string strUpTotalDateTimeXML;
//		public string strUpPressXML;
//		public string strDownPuffDateTimeXML;
//		public string strDownDeflateDateTimeXML;
//		public string strDownTotalDateTimeXML;
//		public string strDownPressXML;
//		public string strFoleyOtherContentXML;
//		public string strSkinAntisepsisOtherContentXML;
//		public string strAllBloodQtyXML;
//		public string strRedCellQtyXML;
//		public string strBloodPlasmQtyXML;
//		public string strOwnBloodQtyXML;
//		public string strBloodOtherQtyXML;
//		public string strFromHeadToFootSkinBeforeOperationContentXML;
//		public string strFromHeadToFootSkinAfterOperationContentXML;
//		public string strSampleOtherContentXML;
//	
//	}
//	
//	public class clsOperationRecord_Anaesthesia
//	{
//		public string strInPatientID;
//		public string strInPatientDate;
//		public string strOpenDate;
//
//		public string strAnaesthesiaModeID;
//		public string strModifyDate;
//		public string strStatus;
//
//
//	}
//	
//	public class clsOperationRecord_OperationID
//	{
//		public string strInPatientID;
//		public string strInPatientDate;
//		public string strOpenDate;
//		public string strCreateDate;
//
//		public string strOperationID;
//		public string strModifyDate;
//		public string strStatus;
//	
//	}
//	
//	public class clsOperationRecord_OperatorAGroup
//	{
//		public string strRecordNurse;
//		public string strWashNurse;
//		public string strCircuitNurse;
//
//		public string strOperationDt;
//		public string strAnaesthesiaDt;
//		public string strNoBacillusNurse;
//
//	}

//	[Serializable]
//	public class clsOperationDoctorNurse
//	{
//		public string strInPatientID;
//		public string strInPatientDate;
//		public string strOpenDate;
//		public string strCreateDate;
//		public string strLastModifyDate;
//		public string strNurseID;
//		public string strNurseName;//added ,jacky-2003-6-9
//		public string strNurseFlag;
//		public string strStatus;
//		public string strDeActivedDate;
//		public string strDeActivedOperatorID;
//	}
//
//	[Serializable]
//	public class clsAnaesthesiaModeInOperation
//	{
//		public string strAnaesthesiaModeID;
//		public string strAnaesthesiaModeName;
//		public override string ToString()
//		{
//			return strAnaesthesiaModeName ;
//		}
//
//	}
//
//	[Serializable]
//	public class clsOperationIDInOperation
//	{
//		public string strOperationID;
//		public string strOperationName;
//	
//		public override string ToString()
//		{
//			return strOperationName ;
//		}
//	}
//
//	[Serializable]
//	public class clsOperationWoundThingInfo
//	{
//		public string strInPatientID;
//		public string strInPatientDate;
//		public string strOpenDate;
//		public string strWoundThingID;
//		public string strWoundThingName;
//		public string strLastModifyDate;
//		public string strQuantity;
//		public string strStatus;
//		public string strDeActivedDate;
//		public string strDeActivedOperatorID;
//	}
//
//	[Serializable]
//	public class clsOperationRecord_All
//	{
//		public clsOperationRecord m_objOperationRecord;
//		public clsOperationRecordContent m_objOperationRecordContent;
//		public clsOperationIDInOperation m_objOperationID;
//		public clsAnaesthesiaModeInOperation m_objAnaesthesiaModeID;
//		public clsOperationDoctorNurse[]  m_objOperatorArr;
//		public clsOperationWoundThingInfo[] m_objWoundThingArr;
//	}
	#endregion 	
	
}

