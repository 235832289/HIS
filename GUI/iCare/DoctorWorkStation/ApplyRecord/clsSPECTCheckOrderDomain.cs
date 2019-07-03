using System;
using System.IO ;
using System .Xml ;
using com.digitalwave.SPECTCheckOrderServ;
using System.Text;

namespace iCare
{
	/// <summary>
	/// Summary description for clsSPECTCheckOrderDomain.
	/// </summary>
	public class clsSPECTCheckOrderDomain
	{
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
        //private com.digitalwave.SPECTCheckOrderServ.clsSPECTCheckOrderServ  m_objServ;
		
		public clsSPECTCheckOrderDomain()
		{
			//
			// TODO: Add constructor logic here
			//
			m_objXmlMemStream = new MemoryStream(300);

			m_objXmlWriter = new XmlTextWriter(m_objXmlMemStream,System.Text.Encoding.Unicode);
			m_objXmlWriter.Flush();//賠腎圻栖議忖憲

			m_objXmlParser = new XmlParserContext(null,null,null,XmlSpace.None,Encoding.Unicode);
		
            //m_objServ =new com.digitalwave.SPECTCheckOrderServ.clsSPECTCheckOrderServ(); 
		}
		public long m_lngDeactive(string p_strDeactiveUserID,string p_strInPatientID,string p_strInPatientDate,
			string p_strCreateDate)
		{
            long lngRes = 0;

            com.digitalwave.SPECTCheckOrderServ.clsSPECTCheckOrderServ m_objServ =
                (com.digitalwave.SPECTCheckOrderServ.clsSPECTCheckOrderServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.SPECTCheckOrderServ.clsSPECTCheckOrderServ));

            try
            {
                string strDeactiveXML = "<Deactive Status='1' DeActivedOperatorID='" + p_strDeactiveUserID + "' InPatientID='" + p_strInPatientID + "'" + " InPatientDate='" + p_strInPatientDate + "'" + " CreateDate='" + p_strCreateDate + "'" + " />";
                lngRes = m_objServ.m_lngDeActive(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, strDeactiveXML, "SPECTCheckOrder");
            }
            finally
            {
                //m_objServ.Dispose();
            }
			return lngRes;
		}

		/// <summary>
		/// 侭嗤議SPECT賦萩扮寂
		/// </summary>
		/// <param name="p_strInPatientID"></param>
		/// <param name="p_strInPatientDate"></param>
		/// <returns></returns>
		public DateTime [] m_dtmGetTimeInfoOfAPatientArr(string p_strInPatientID,string p_strInPatientDate)
		{
			if(p_strInPatientID ==null||p_strInPatientID =="")
				return null;
			DateTime[] dtmCreateRecordDateArr=null;
			string strXml = "";
			int intRows = 0;

            com.digitalwave.SPECTCheckOrderServ.clsSPECTCheckOrderServ m_objServ =
                (com.digitalwave.SPECTCheckOrderServ.clsSPECTCheckOrderServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.SPECTCheckOrderServ.clsSPECTCheckOrderServ));

            try
            {
                long lngRes = m_objServ.m_lngGetTimeInfoOfAPatient(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, ref strXml, ref intRows);

                if (lngRes > 0 && intRows > 0)
                {
                    dtmCreateRecordDateArr = new DateTime[intRows];

                    XmlTextReader objReader = new XmlTextReader(strXml, XmlNodeType.Element, m_objXmlParser);
                    objReader.WhitespaceHandling = WhitespaceHandling.None;

                    int intIndex = 0;
                    while (objReader.Read())
                    {
                        switch (objReader.NodeType)
                        {
                            case XmlNodeType.Element:
                                if (objReader.HasAttributes)
                                {
                                    dtmCreateRecordDateArr[intIndex] = DateTime.Parse(objReader.GetAttribute("CREATEDATE"));
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
			return dtmCreateRecordDateArr ;
		}



		public long lngSave(clsSPECTCheckContent m_objSPECTCheckContent)
		{
            long lngSucceed = 0;

            com.digitalwave.SPECTCheckOrderServ.clsSPECTCheckOrderServ m_objServ =
                (com.digitalwave.SPECTCheckOrderServ.clsSPECTCheckOrderServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.SPECTCheckOrderServ.clsSPECTCheckOrderServ));

            try
            {
			    string strXML=this.strSaveXML(m_objSPECTCheckContent); 
			    lngSucceed=m_objServ.m_lngAddNewRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,strXML);
            }
            finally
            {
                //m_objServ.Dispose();
            }
			return lngSucceed;
		}

		private string strSaveXML(clsSPECTCheckContent m_objSPECTCheckContent)
		{
			m_objXmlMemStream.SetLength(0);
			
			m_objXmlWriter.WriteStartDocument();
			m_objXmlWriter.WriteStartElement("RecordMaster");
			
			m_objXmlWriter.WriteAttributeString("INPATIENTID", m_objSPECTCheckContent.strInPatientID.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("INPATIENTDATE", m_objSPECTCheckContent.strInPatientDate.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("CREATEDATE", m_objSPECTCheckContent.strCreateDate.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("IFCONFIRM", m_objSPECTCheckContent.strIfConfirm.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("STATUS", m_objSPECTCheckContent.strStatus.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("CREATEUSERID", m_objSPECTCheckContent.strCreateUserID.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("PAYMENTPULBIC", m_objSPECTCheckContent.strPaymentPulbic.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("PAYMENTCOMPANY", m_objSPECTCheckContent.strPaymentCompany.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("PAYMENTSELF", m_objSPECTCheckContent.strPaymentSelf.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("CHECKNO", m_objSPECTCheckContent.strCheckNO.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("HYPOTHYROIDDISPLY", m_objSPECTCheckContent.strHypothyroidDisply .Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("HYPOTHYROIDKNUBDISPLY", m_objSPECTCheckContent.strHypothyroidKnubDisply.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("KIDNEYDISPLY", m_objSPECTCheckContent.strKidneyDisply.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("HYPOTHYROIDCANCER", m_objSPECTCheckContent.strHypothyroidCancer.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("HYPOTHYROIDSIDE", m_objSPECTCheckContent.strhypothyroidside.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("PNEUMONICDAERATE", m_objSPECTCheckContent.strPneumonicdAerate.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("PNEUMONICDBLOOD", m_objSPECTCheckContent.strPneumonicdBlood.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("PNEUMONICDKNUB", m_objSPECTCheckContent.strPneumonicdknub.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("HEART", m_objSPECTCheckContent.strHeart .Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("HEARTBLOOD", m_objSPECTCheckContent.strHeartBlood.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("DBODY", m_objSPECTCheckContent.strDBody.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("BODY", m_objSPECTCheckContent.strBody.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("BONE", m_objSPECTCheckContent.strBone .Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("BONETR", m_objSPECTCheckContent.strBoneTr.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("COURAGE", m_objSPECTCheckContent.strCourage .Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("COURAGEFAULTAGE", m_objSPECTCheckContent.strCourageFaultage.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("COURAGEPOOL", m_objSPECTCheckContent.strCouragePool.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("PULSE", m_objSPECTCheckContent.strPulse.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("MEIKL", m_objSPECTCheckContent.strMeikl.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("ESOPHAGUS", m_objSPECTCheckContent.strEsophagus.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("ENTERON", m_objSPECTCheckContent.strEnteron.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("OVERBODY", m_objSPECTCheckContent.strOverbody.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("SPLEEN", m_objSPECTCheckContent.strSpleen.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("LYMPH", m_objSPECTCheckContent.strLymph.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("DEPCANCER", m_objSPECTCheckContent.strDepCancer.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("OVERCANCER", m_objSPECTCheckContent.strOverCancer.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("METABOLIZE", m_objSPECTCheckContent.strMetabolize.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("BRAINMETABOLIZE", m_objSPECTCheckContent.strBrainMetabolize.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("KIDNEYDIN", m_objSPECTCheckContent.strKidneyDin .Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("KIDNEYSTR", m_objSPECTCheckContent.strKidneyStr.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("KIDNEYBALL", m_objSPECTCheckContent.strKidneyBall.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("KIDNEYBLOOD", m_objSPECTCheckContent.strKidneyBlood .Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("BLADDER", m_objSPECTCheckContent.strBladder.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("BLOODPOOL", m_objSPECTCheckContent.strBloodPool.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("OVUM", m_objSPECTCheckContent.strOvum.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("BREASTCANCER", m_objSPECTCheckContent.strBreastCancer.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("BRAINCANCER", m_objSPECTCheckContent.strBrainCancer.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("BRAINBLOOD", m_objSPECTCheckContent.strBrainBlood.Replace('\'','き'));
			
			m_objXmlWriter.WriteAttributeString("TEAR", m_objSPECTCheckContent.strTear.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("NOSE", m_objSPECTCheckContent.strNose.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("TELL", m_objSPECTCheckContent.strTell.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("TELLCONTENT", m_objSPECTCheckContent.strTellContent.Replace('\'','き'));

			m_objXmlWriter.WriteAttributeString("HISTORY", m_objSPECTCheckContent.strHistory.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("CHECKLAB", m_objSPECTCheckContent.strCheckLab.Replace('\'','き'));
			m_objXmlWriter.WriteAttributeString("DISGONSE", m_objSPECTCheckContent.strDisgonse.Replace('\'','き'));
			
			m_objXmlWriter.WriteEndElement();          
			m_objXmlWriter.WriteEndDocument();
			m_objXmlWriter.Flush();			

			return System.Text.Encoding.Unicode.GetString(m_objXmlMemStream.ToArray(),39*2,(int)m_objXmlMemStream.Length-39*2);
		
		}


		public clsSPECTCheckContent objDisplay(string strInPatientID,string strInPatientDate,string strCreateDate)
		{
			string strXML="";
			int intRows=0;

			clsSPECTCheckContent m_objDisplay =new clsSPECTCheckContent();

            com.digitalwave.SPECTCheckOrderServ.clsSPECTCheckOrderServ m_objServ =
                (com.digitalwave.SPECTCheckOrderServ.clsSPECTCheckOrderServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.SPECTCheckOrderServ.clsSPECTCheckOrderServ));

             try
             {
                 long lngSucceed = m_objServ.lngSelectNewRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, strInPatientID, strInPatientDate, strCreateDate, ref strXML, ref intRows);
                 if (intRows > 0)
                 {
                     XmlTextReader objReader = new XmlTextReader(strXML, XmlNodeType.Element, m_objXmlParser);
                     objReader.WhitespaceHandling = WhitespaceHandling.None;

                     while (objReader.Read())
                     {
                         switch (objReader.NodeType)
                         {
                             case XmlNodeType.Element:
                                 if (objReader.HasAttributes)
                                 {
                                     #region Display
                                     m_objDisplay.strInPatientID = objReader.GetAttribute("INPATIENTID").ToString().Replace('き', '\'');
                                     m_objDisplay.strInPatientDate = objReader.GetAttribute("INPATIENTDATE").ToString().Replace('き', '\'');
                                     m_objDisplay.strCreateDate = objReader.GetAttribute("CREATEDATE").ToString().Replace('き', '\'');
                                     //								m_objDisplay.strModifyDate=objReader.GetAttribute("MODIFYDATE").ToString().Replace ('き','\'');

                                     m_objDisplay.strBladder = objReader.GetAttribute("BLADDER").ToString().Replace('き', '\'');
                                     m_objDisplay.strBloodPool = objReader.GetAttribute("BLOODPOOL").ToString().Replace('き', '\'');
                                     m_objDisplay.strBody = objReader.GetAttribute("BODY").ToString().Replace('き', '\'');

                                     m_objDisplay.strBone = objReader.GetAttribute("BONE").ToString().Replace('き', '\'');
                                     m_objDisplay.strBoneTr = objReader.GetAttribute("BONETR").ToString().Replace('き', '\'');
                                     m_objDisplay.strBrainBlood = objReader.GetAttribute("BRAINBLOOD").ToString().Replace('き', '\'');

                                     m_objDisplay.strBrainCancer = objReader.GetAttribute("BRAINCANCER").ToString().Replace('き', '\'');
                                     m_objDisplay.strBrainMetabolize = objReader.GetAttribute("BRAINMETABOLIZE").ToString().Replace('き', '\'');
                                     m_objDisplay.strBreastCancer = objReader.GetAttribute("BREASTCANCER").ToString().Replace('き', '\'');

                                     m_objDisplay.strCheckLab = objReader.GetAttribute("CHECKLAB").ToString().Replace('き', '\'');
                                     m_objDisplay.strCheckNO = objReader.GetAttribute("CHECKNO").ToString().Replace('き', '\'');
                                     m_objDisplay.strCourage = objReader.GetAttribute("COURAGE").ToString().Replace('き', '\'');

                                     m_objDisplay.strCourageFaultage = objReader.GetAttribute("COURAGEFAULTAGE").ToString().Replace('き', '\'');
                                     m_objDisplay.strCouragePool = objReader.GetAttribute("COURAGEPOOL").ToString().Replace('き', '\'');
                                     m_objDisplay.strCreateDate = objReader.GetAttribute("CREATEDATE").ToString().Replace('き', '\'');

                                     m_objDisplay.strCreateUserID = objReader.GetAttribute("CREATEUSERID").ToString().Replace('き', '\'');
                                     m_objDisplay.strDBody = objReader.GetAttribute("DBODY").ToString().Replace('き', '\'');
                                     m_objDisplay.strDepCancer = objReader.GetAttribute("DEPCANCER").ToString().Replace('き', '\'');

                                     m_objDisplay.strDisgonse = objReader.GetAttribute("DISGONSE").ToString().Replace('き', '\'');
                                     m_objDisplay.strEnteron = objReader.GetAttribute("ENTERON").ToString().Replace('き', '\'');
                                     m_objDisplay.strEsophagus = objReader.GetAttribute("ESOPHAGUS").ToString().Replace('き', '\'');

                                     m_objDisplay.strHeart = objReader.GetAttribute("HEART").ToString().Replace('き', '\'');
                                     m_objDisplay.strHeartBlood = objReader.GetAttribute("HEARTBLOOD").ToString().Replace('き', '\'');
                                     m_objDisplay.strHistory = objReader.GetAttribute("HISTORY").ToString().Replace('き', '\'');

                                     m_objDisplay.strHypothyroidCancer = objReader.GetAttribute("HYPOTHYROIDCANCER").ToString().Replace('き', '\'');
                                     m_objDisplay.strHypothyroidDisply = objReader.GetAttribute("HYPOTHYROIDDISPLY").ToString().Replace('き', '\'');
                                     m_objDisplay.strHypothyroidKnubDisply = objReader.GetAttribute("HYPOTHYROIDKNUBDISPLY").ToString().Replace('き', '\'');

                                     m_objDisplay.strhypothyroidside = objReader.GetAttribute("HYPOTHYROIDSIDE").ToString().Replace('き', '\'');
                                     m_objDisplay.strInPatientDate = objReader.GetAttribute("INPATIENTDATE").ToString().Replace('き', '\'');
                                     m_objDisplay.strInPatientID = objReader.GetAttribute("INPATIENTID").ToString().Replace('き', '\'');

                                     m_objDisplay.strKidneyBall = objReader.GetAttribute("KIDNEYBALL").ToString().Replace('き', '\'');
                                     m_objDisplay.strKidneyBlood = objReader.GetAttribute("KIDNEYBLOOD").ToString().Replace('き', '\'');
                                     m_objDisplay.strKidneyDin = objReader.GetAttribute("KIDNEYDIN").ToString().Replace('き', '\'');

                                     m_objDisplay.strKidneyDisply = objReader.GetAttribute("KIDNEYDISPLY").ToString().Replace('き', '\'');
                                     m_objDisplay.strKidneyStr = objReader.GetAttribute("KIDNEYSTR").ToString().Replace('き', '\'');
                                     m_objDisplay.strLymph = objReader.GetAttribute("LYMPH").ToString().Replace('き', '\'');

                                     m_objDisplay.strMeikl = objReader.GetAttribute("MEIKL").ToString().Replace('き', '\'');
                                     m_objDisplay.strMetabolize = objReader.GetAttribute("METABOLIZE").ToString().Replace('き', '\'');
                                     m_objDisplay.strNose = objReader.GetAttribute("NOSE").ToString().Replace('き', '\'');

                                     m_objDisplay.strOverbody = objReader.GetAttribute("OVERBODY").ToString().Replace('き', '\'');
                                     m_objDisplay.strOverCancer = objReader.GetAttribute("OVERCANCER").ToString().Replace('き', '\'');
                                     m_objDisplay.strOvum = objReader.GetAttribute("OVUM").ToString().Replace('き', '\'');

                                     m_objDisplay.strPaymentCompany = objReader.GetAttribute("PAYMENTCOMPANY").ToString().Replace('き', '\'');
                                     m_objDisplay.strPaymentPulbic = objReader.GetAttribute("PAYMENTPULBIC").ToString().Replace('き', '\'');
                                     m_objDisplay.strPaymentSelf = objReader.GetAttribute("PAYMENTSELF").ToString().Replace('き', '\'');

                                     m_objDisplay.strPneumonicdAerate = objReader.GetAttribute("PNEUMONICDAERATE").ToString().Replace('き', '\'');
                                     m_objDisplay.strPneumonicdBlood = objReader.GetAttribute("PNEUMONICDBLOOD").ToString().Replace('き', '\'');
                                     m_objDisplay.strPneumonicdknub = objReader.GetAttribute("PNEUMONICDKNUB").ToString().Replace('き', '\'');

                                     m_objDisplay.strPulse = objReader.GetAttribute("PULSE").ToString().Replace('き', '\'');
                                     m_objDisplay.strSpleen = objReader.GetAttribute("SPLEEN").ToString().Replace('き', '\'');
                                     m_objDisplay.strTear = objReader.GetAttribute("TEAR").ToString().Replace('き', '\'');

                                     m_objDisplay.strTell = objReader.GetAttribute("TELL").ToString().Replace('き', '\'');
                                     m_objDisplay.strTellContent = objReader.GetAttribute("TELLCONTENT").ToString().Replace('き', '\'');
                                     #endregion
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
			return m_objDisplay;

		}


	}

	public class clsSPECTCheckContent
	{
		public string strPaymentPulbic = "";	
		public string strPaymentCompany	 = "";
		public string strPaymentSelf = "";	
		public string strCheckNO = "";	
		public string strHypothyroidDisply = "";	
		public string strHypothyroidKnubDisply = "";	
		public string strKidneyDisply = "";	
		public string strHypothyroidCancer = "";	
		public string strhypothyroidside = "";	
		public string strPneumonicdAerate = "";	
		public string strPneumonicdBlood = "";	
		public string strPneumonicdknub	 = "";
		public string strHeart = "";	
		public string strHeartBlood = "";	
		public string strDBody = "";	
		public string strBody = "";	
		public string strBone = "";	
		public string strBoneTr = "";	
		public string strCourage = "";	
		public string strCourageFaultage = "";	
		public string strCouragePool = "";	
		public string strPulse = "";	
		public string strMeikl = "";	
		public string strEsophagus = "";
		public string strEnteron = "";	
		public string strOverbody = "";	
		public string strSpleen = "";	
		public string strLymph = "";	
		public string strDepCancer = "";	
		public string strOverCancer = "";	
		public string strMetabolize = "";	
		public string strBrainMetabolize = "";	
		public string strKidneyDin = "";	
		public string strKidneyStr = "";	
		public string strKidneyBall = ""	;
		public string strKidneyBlood = "";	
		public string strBladder = "";	
		public string strBloodPool = "";	
		public string strOvum = "";	
		public string strBreastCancer = "";	
		public string strBrainCancer = "";	
		public string strBrainBlood = "";	
		public string strTear = "";	
		public string strNose = "";	
		public string strTell = "";	
		public string strHistory = "";	
		public string strCheckLab = "";
		public string strDisgonse = "";	
		public string strInPatientID = "";	
		public string strInPatientDate = "";
		public string strCreateDate = "";	
		public string strCreateUserID = "";	
		public string strIfConfirm = "";
		public string strStatus = "";
		
		public string strModifyDate = "";

		public string strTellContent = "";
	}

}
