using System;
using System.IO ;
using System .Xml ;
using iCareData;
using com.digitalwave.OperationRecordDoctorServ;
//using com.digitalwave.iCare.middletier.HRPService;

namespace iCare
{
	/// <summary>
    /// 手 术 记 录 单
	/// </summary>
	public class clsOperationRecordDoctorDomain
	{
		#region Member
		/// <summary>
		/// 生成Xml的缓冲
		/// </summary>
		private MemoryStream m_objXmlMemStream;
		/// <summary>
		/// 生成Xml的工具
		/// </summary>
		private XmlTextWriter m_objXmlWriter;
		///  <summary>
		/// 读取Xml工具输入参数		
		/// </summary>
		private XmlParserContext m_objXmlParser;
		/// <summary>
		/// 
		/// </summary>
        //private clsOperationRecordDoctorServ m_objServ;
		#endregion

		#region Constructor
		public clsOperationRecordDoctorDomain()
		{
			m_objXmlMemStream = new MemoryStream(300);

			m_objXmlWriter = new XmlTextWriter(m_objXmlMemStream,System.Text.Encoding.Unicode);
			m_objXmlWriter.Flush();//清空原来的字符
			m_objXmlParser = new XmlParserContext(null,null,null,XmlSpace.None,System.Text.Encoding.Unicode);

            //m_objServ = new clsOperationRecordDoctorServ();
		}
		#endregion

		#region 读取初始化信息
		/// <summary>
		/// 获得所有CreateDate
		/// </summary>
		/// <param name="p_strInPatientID"></param>
		/// <param name="p_strInPatientDate"></param>
		/// <returns></returns>
		public DateTime [,] m_dtmGetTimeInfoOfAPatientArr(string p_strInPatientID,string p_strInPatientDate)
		{
			if(p_strInPatientID ==null||p_strInPatientID =="")
				return null;

			DateTime[,] dtmCreateRecordDateArr = null;

			string strXml = "";
			int intRows = 0;

            clsOperationRecordDoctorServ m_objServ =
                (clsOperationRecordDoctorServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOperationRecordDoctorServ));

            long lngRes = 0;
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
				dtmCreateRecordDateArr = new DateTime [intRows,2];

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
								dtmCreateRecordDateArr[intIndex,0]=DateTime.Parse (objReader.GetAttribute("CREATEDATE"));
								dtmCreateRecordDateArr[intIndex,1]=DateTime.Parse (objReader.GetAttribute("OPENDATE"));
								intIndex++;
							}
							break;
					}
				}
			}
			return dtmCreateRecordDateArr ;
		}

		/// <summary>
		/// 获得手术名称和ID
		/// </summary>
		/// <returns></returns>
		public clsOperationIDInOperation[] m_objGetOperationID()
		{
			string strXML="";
			int intRows=0;

			clsOperationIDInOperation[] m_objOperationArr = null;

            clsOperationRecordDoctorServ m_objServ =
                (clsOperationRecordDoctorServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOperationRecordDoctorServ));

            long lngRes = 0;
			try
            {
                lngRes = m_objServ.m_lngGetOperationIDName(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,out strXML,out intRows);
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
								m_objOperationArr[intIndex].strOperationID=objReader.GetAttribute("OPERATIONID").Replace ('き','\'');
								m_objOperationArr[intIndex].strOperationName=objReader.GetAttribute("OPERATIONNAME").Replace ('き','\'');
								intIndex ++;
							}
							break;
					}//end swith
				}//end while
			}//end if
			return m_objOperationArr;
		}
		#endregion

		#region Save
		public long m_lngSave(clsOperationRecordDoctor p_objOperationRecord,clsOperationRecordContentDoctor p_objOperationRecordContent,bool p_blnIsAddNew,clsOperationRecord_OperationID[] p_objOperationRecordOperationArr,clsOperationDoctorNurse[] p_objOperationNurseArr,clsOperationRecordDoctorSign objDoctorSign,clsPictureBoxValue[] p_objPics)
		{ 
            long lngRes = 0;
			if(p_objOperationRecord == null || p_objOperationRecordContent == null||p_objOperationRecord.objSignerArr==null)
				return -1;

            clsOperationRecordDoctorServ m_objServ =
                (clsOperationRecordDoctorServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOperationRecordDoctorServ));

            //获取签名流水号
            long lngSequence = 0;

            com.digitalwave.PublicMiddleTier.clsPublicMiddleTier objSign =
                (com.digitalwave.PublicMiddleTier.clsPublicMiddleTier)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.PublicMiddleTier.clsPublicMiddleTier));

            lngRes = objSign.m_lngGetSequenceValue("SEQ_EMR_SIGN", out lngSequence);

           
            try
            {
                //string[] strOperationXMLArr = m_strGetOperationXMLArr(p_objOperationRecordOperationArr);
                //string[] m_strNurseXMLArr = m_strGetNurseXML(p_objOperationNurseArr);
                p_objOperationRecord.int_Sequence = lngSequence;

                //if (p_blnIsAddNew == true)
                //    lngRes = m_objServ.m_lngAddNew(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, m_strGetMasterXML(p_objOperationRecord), m_strGetContentXML(p_objOperationRecordContent), strOperationXMLArr, m_strNurseXMLArr, objDoctorSign, p_objOperationRecord.m_strInPatientID, p_objOperationRecord.m_strInPatientDate, p_objOperationRecord.m_strOpenDate, p_objPics);
                //else
                //    lngRes = m_objServ.m_lngModify(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, m_strGetMasterXML(p_objOperationRecord), m_strGetContentXML(p_objOperationRecordContent), strOperationXMLArr, m_strNurseXMLArr, objDoctorSign, p_objOperationRecord.m_strInPatientID, p_objOperationRecord.m_strInPatientDate, p_objOperationRecord.m_strOpenDate, p_objPics);
                if (p_blnIsAddNew == true)
                    lngRes = m_objServ.m_lngAddNew(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_objOperationRecord, p_objOperationRecordContent, p_objPics);
                else
                    lngRes = m_objServ.m_lngModify(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_objOperationRecord, p_objOperationRecordContent, p_objPics);

            }
            finally
            {
                m_objServ = null;
            }
            return lngRes;
		}

		/// <summary>
		/// 拼护士及医生
		/// </summary>
		/// <param name="objclsOperationEqipmentQtyContent"></param>
		/// <returns></returns>
		private string[] m_strGetNurseXML(clsOperationDoctorNurse[] objOperationNurseArr)
		{
			if(objOperationNurseArr == null || objOperationNurseArr.Length <=0)
				return null;
			string[] m_strXMLArr = new string[objOperationNurseArr.Length];
            m_objXmlWriter = new XmlTextWriter(m_objXmlMemStream, System.Text.Encoding.Unicode);
            m_objXmlWriter.Flush();//清空原来的字符
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

		private string[] m_strGetOperationXMLArr(clsOperationRecord_OperationID[] p_objOperationRecordOperationArr)
		{
			if(p_objOperationRecordOperationArr == null || p_objOperationRecordOperationArr.Length==0)
				return null;

			string[] strXMLArr=new string[p_objOperationRecordOperationArr.Length];
            m_objXmlWriter = new XmlTextWriter(m_objXmlMemStream, System.Text.Encoding.Unicode);
            m_objXmlWriter.Flush();//清空原来的字符
			for(int i=0;i<p_objOperationRecordOperationArr.Length;i++)
			{
				m_objXmlMemStream.SetLength(0);
			
				m_objXmlWriter.WriteStartDocument();
				m_objXmlWriter.WriteStartElement("RecordMaster");
			
				m_objXmlWriter.WriteAttributeString("INPATIENTID", p_objOperationRecordOperationArr[i].strInPatientID.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("INPATIENTDATE", p_objOperationRecordOperationArr[i].strInPatientDate.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("OPENDATE", p_objOperationRecordOperationArr[i].strOpenDate.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("OPERATIONID", p_objOperationRecordOperationArr[i].strOperationID.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("MODIFYDATE", p_objOperationRecordOperationArr[i].strModifyDate.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("STATUS", p_objOperationRecordOperationArr[i].strStatus.Replace('\'','き'));

				m_objXmlWriter.WriteEndElement();          
				m_objXmlWriter.WriteEndDocument();
				m_objXmlWriter.Flush();			
				strXMLArr[i]= System.Text.Encoding.Unicode.GetString(m_objXmlMemStream.ToArray(),39*2,(int)m_objXmlMemStream.Length-39*2);
			}
			return strXMLArr;

		}

		private string m_strGetMasterXML(clsOperationRecordDoctor  objOperationRecord) 
		{
			try
            {
                m_objXmlWriter = new XmlTextWriter(m_objXmlMemStream, System.Text.Encoding.Unicode);
                m_objXmlWriter.Flush();//清空原来的字符
				m_objXmlMemStream.SetLength(0);
				m_objXmlWriter.WriteStartDocument();
				m_objXmlWriter.WriteStartElement("RecordMaster");

				m_objXmlWriter.WriteAttributeString("INPATIENTID", objOperationRecord.m_strInPatientID.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("INPATIENTDATE", objOperationRecord.m_strInPatientDate.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("CREATEDATE", objOperationRecord.m_strCreateDate.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("OPENDATE", objOperationRecord.m_strOpenDate.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("CREATEUSERID", objOperationRecord.m_strCreateUserID.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("STATUS", objOperationRecord.m_strStatus.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("IFCONFIRM", objOperationRecord.m_strIfConfirm.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("DEACTIVEDDATE", objOperationRecord.m_strDeActivedDate.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("DEACTIVEDOPERATORID", objOperationRecord.m_strDeActivedOperatorID.Replace('\'','き'));

				m_objXmlWriter.WriteAttributeString("ANAESTHESIABEFOREOPERATIONXML", objOperationRecord.m_strAnaesthesiaBeforeOperationXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("ANAESTHESIAINOPERATIONXML", objOperationRecord.m_strAnaesthesiaInOperationXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("ANAESTHESIACATEGORYDOSAGEXML", objOperationRecord.m_strAnaesthesiaCategoryDosageXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("DIAGNOSEBEFOREOPERATIONXML", objOperationRecord.m_strDiagnoseBeforeOperationXML.Replace('\'','き'));


				m_objXmlWriter.WriteAttributeString("OPERATIONNAMEXML", objOperationRecord.m_strOperationNameXML.Replace('\'','き'));

				m_objXmlWriter.WriteAttributeString("DIAGNOSEAFTEROPERATIONXML", objOperationRecord.m_strDiagnoseAfterOperationXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("OPERATIONPROCESSXML", objOperationRecord.m_strOperationProcessXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("PATHOLOGYXML", objOperationRecord.m_strPathologyXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("SAMPLEOREXTRARECORDXML", objOperationRecord.m_strSampleOrExtraRecordXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("SUMMARYAFTEROPERATIONXML", objOperationRecord.m_strSummaryAfterOperationXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("INLIQUIDXML", objOperationRecord.m_strInLiquidXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("OUTFLOWXML", objOperationRecord.m_strOutFlowXML.Replace('\'','き'));
				m_objXmlWriter.WriteAttributeString("XRAYNUMBERXML", objOperationRecord.m_strXRayNumberXML.Replace('\'','き'));

                m_objXmlWriter.WriteAttributeString("SEQUENCE_INT", objOperationRecord.int_Sequence.ToString().Replace('\'', 'き'));


				m_objXmlWriter.WriteEndElement();          
				m_objXmlWriter.WriteEndDocument();
				m_objXmlWriter.Flush();
			
				return System.Text.Encoding.Unicode.GetString(m_objXmlMemStream.ToArray(),39*2,(int)m_objXmlMemStream.Length-39*2);
			}
            catch (Exception)
            {
                throw;
            }
			return null;
		}

		private string m_strGetContentXML(clsOperationRecordContentDoctor  p_objOperationRecordContent)
		{
            try
            {
                m_objXmlWriter = new XmlTextWriter(m_objXmlMemStream, System.Text.Encoding.Unicode);
                m_objXmlWriter.Flush();//清空原来的字符
               
			    m_objXmlMemStream.SetLength(0);
    			
			    m_objXmlWriter.WriteStartDocument();
			    m_objXmlWriter.WriteStartElement("RecordContent");

			    m_objXmlWriter.WriteAttributeString("INPATIENTID", p_objOperationRecordContent.m_strInPatientID.Replace('\'','き'));
			    m_objXmlWriter.WriteAttributeString("INPATIENTDATE", p_objOperationRecordContent.m_strInPatientDate.Replace('\'','き'));
			    m_objXmlWriter.WriteAttributeString("OPENDATE", p_objOperationRecordContent.m_strOpenDate.Replace('\'','き'));
			    m_objXmlWriter.WriteAttributeString("LASTMODIFYUSERID", p_objOperationRecordContent.m_strLastModifyUserID.Replace('\'','き'));
			    m_objXmlWriter.WriteAttributeString("LASTMODIFYDATE", p_objOperationRecordContent.m_strLastModifyDate.Replace('\'','き'));
			    m_objXmlWriter.WriteAttributeString("STATUS", p_objOperationRecordContent.m_strStatus.Replace('\'','き'));
			    m_objXmlWriter.WriteAttributeString("DEACTIVEDDATE", p_objOperationRecordContent.m_strDeActivedDate.Replace('\'','き'));
			    m_objXmlWriter.WriteAttributeString("DEACTIVEDOPERATORID", p_objOperationRecordContent.m_strDeActivedOperatorID.Replace('\'','き'));

			    m_objXmlWriter.WriteAttributeString("DIAGNOSEBEFOREOPERATION", p_objOperationRecordContent.m_strDiagnoseBeforeOperation.Replace('\'','き'));

			    m_objXmlWriter.WriteAttributeString("OPERATIONNAME", p_objOperationRecordContent.m_strOperationName.Replace('\'','き'));
			    m_objXmlWriter.WriteAttributeString("DIAGNOSEAFTEROPERATION", p_objOperationRecordContent.m_strDiagnoseAfterOperation.Replace('\'','き'));
			    m_objXmlWriter.WriteAttributeString("OPERATIONBEGINDATE", p_objOperationRecordContent.m_strOperationBeginDate.Replace('\'','き'));
			    m_objXmlWriter.WriteAttributeString("OPERATIONENDDATE", p_objOperationRecordContent.m_strOperationEndDate.Replace('\'','き'));
			    m_objXmlWriter.WriteAttributeString("ANAESTHESIABEFOREOPERATION", p_objOperationRecordContent.m_strAnaesthesiaBeforeOperation.Replace('\'','き'));
			    m_objXmlWriter.WriteAttributeString("ANAESTHESIAINOPERATION", p_objOperationRecordContent.m_strAnaesthesiaInOperation.Replace('\'','き'));
			    m_objXmlWriter.WriteAttributeString("ANAESTHESIACATEGORYDOSAGE", p_objOperationRecordContent.m_strAnaesthesiaCategoryDosage.Replace('\'','き'));
			    m_objXmlWriter.WriteAttributeString("ANAESTHESIABEGINDATE", p_objOperationRecordContent.m_strAnaesthesiaBeginDate.Replace('\'','き'));
			    m_objXmlWriter.WriteAttributeString("ANAESTHESIAENDDATE", p_objOperationRecordContent.m_strAnaesthesiaEndDate.Replace('\'','き'));
			    m_objXmlWriter.WriteAttributeString("OPERATIONPROCESS", p_objOperationRecordContent.m_strOperationProcess.Replace('\'','き'));
			    m_objXmlWriter.WriteAttributeString("PATHOLOGY", p_objOperationRecordContent.m_strPathology.Replace('\'','き'));
			    m_objXmlWriter.WriteAttributeString("INLIQUID", p_objOperationRecordContent.m_strInLiquid.Replace('\'','き'));
			    m_objXmlWriter.WriteAttributeString("OUTFLOW", p_objOperationRecordContent.m_strOutFlow.Replace('\'','き'));
			    m_objXmlWriter.WriteAttributeString("SAMPLEOREXTRARECORD", p_objOperationRecordContent.m_strSampleOrExtraRecord.Replace('\'','き'));
			    m_objXmlWriter.WriteAttributeString("SUMMARYAFTEROPERATION", p_objOperationRecordContent.m_strSummaryAfterOperation.Replace('\'','き'));
			    m_objXmlWriter.WriteAttributeString("XRAYNUMBER", p_objOperationRecordContent.m_strXRayNumber.Replace('\'','き'));
			    m_objXmlWriter.WriteAttributeString("ANAESTHER", p_objOperationRecordContent.m_strAnaesther.Replace('\'','き'));
                //m_objXmlWriter.WriteAttributeString("DOCTOR1", p_objOperationRecordContent.m_strDoctor1.Replace('\'','き'));
                //m_objXmlWriter.WriteAttributeString("DOCTOR2", p_objOperationRecordContent.m_strDoctor2.Replace('\'','き'));
    //			//手术医师签名
                //m_objXmlWriter.WriteAttributeString("OPERATIONDOCTOR", p_objOperationRecordContent.m_strOperationDoctor.Replace('\'','き'));
    //			//助手签名
                //m_objXmlWriter.WriteAttributeString("ASSISTANT", p_objOperationRecordContent.m_strAssistant.Replace('\'','き'));

			    //护士签名
                //m_objXmlWriter.WriteAttributeString("NURSE", p_objOperationRecordContent.m_strNurse.Replace('\'','き'));

                //m_objXmlWriter.WriteAttributeString("OPERATIONDOCTORID", p_objOperationRecordContent.m_strOperationDoctorID.Replace('\'','き'));
                //m_objXmlWriter.WriteAttributeString("OPERATIONDOCTORNAME", p_objOperationRecordContent.m_strOperationDoctorName.Replace('\'','き'));
			    m_objXmlWriter.WriteAttributeString("FIRSTASSISTANTID", p_objOperationRecordContent.m_strFirstAssistantID.Replace('\'','き'));
			    m_objXmlWriter.WriteAttributeString("FIRSTASSISTANTNAME", p_objOperationRecordContent.m_strFirstAssistantName.Replace('\'','き'));
			    m_objXmlWriter.WriteAttributeString("SECONDASSISTANTID", p_objOperationRecordContent.m_strSecondAssistantID.Replace('\'','き'));
			    m_objXmlWriter.WriteAttributeString("SECONDASSISTANTNAME", p_objOperationRecordContent.m_strSecondAssistantName.Replace('\'','き'));

			    m_objXmlWriter.WriteEndElement();          
			    m_objXmlWriter.WriteEndDocument();
			    m_objXmlWriter.Flush();			

			return System.Text.Encoding.Unicode.GetString(m_objXmlMemStream.ToArray(),39*2,(int)m_objXmlMemStream.Length-39*2);
        }
        catch (Exception)
        {
            throw;
        }
        return null;
       }
		#endregion

		#region 读取显示信息
		/// <summary>
		/// 获取护士医生的信息
		/// </summary>
		/// <param name="strInPatientID"></param>
		/// <param name="strInPatientDate"></param>
		/// <param name="strCreateDate"></param>
		/// <param name="Rows"></param>
		/// <returns></returns>
		public clsOperationDoctorNurse[] m_lngGetOperation_Nurse(string strInPatientID, string strInPatientDate,string strCreateDate,out int Rows)
		{
			clsOperationDoctorNurse[] objOperationNurse=null;
			string m_strReceivedXML="";
			int m_intReturnRows=0;

            clsOperationRecordDoctorServ m_objServ =
                (clsOperationRecordDoctorServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOperationRecordDoctorServ));

            long lngRes = 0;
            try
            {
                long lngSucceed = m_objServ.m_lngGetOperation_Nurse(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, strInPatientID, strInPatientDate, strCreateDate, ref m_strReceivedXML, ref m_intReturnRows);
            }
            finally
            {
                //m_objServ.Dispose();
            }
			if(m_intReturnRows>0)
			{
				XmlTextReader objReader = new XmlTextReader(m_strReceivedXML,XmlNodeType.Element,m_objXmlParser);
				objReader.WhitespaceHandling = WhitespaceHandling.None;
				objOperationNurse=new clsOperationDoctorNurse[m_intReturnRows];
				int intIndex=0;
				while(objReader.Read())
				{
					switch(objReader.NodeType)
					{
						case XmlNodeType.Element:
							if(objReader.HasAttributes)
							{
								objOperationNurse[intIndex]=new clsOperationDoctorNurse();
								objOperationNurse[intIndex].strNurseID=objReader.GetAttribute("OPERTORID");
								objOperationNurse[intIndex].strNurseFlag=objReader.GetAttribute("OPERATORFLAG");
								objOperationNurse[intIndex].strNurseName=objReader.GetAttribute("FIRSTNAME");
								intIndex ++;
																
							}
							break;
					}
				}
			}
			Rows=m_intReturnRows;
			return objOperationNurse;

		}

		/// <summary>
		/// 获得从表的信息
		/// </summary>
		/// <param name="p_strInPatientID"></param>
		/// <param name="p_strInPatientDate"></param>
		/// <param name="p_strCreateDate"></param>
		/// <returns></returns>
		public clsOperationRecordContentDoctor m_objGetOperationRecordContent(string p_strInPatientID,string p_strInPatientDate,string p_strCreateDate)
		{ 
			if(p_strInPatientID ==null||p_strInPatientID ==""||p_strInPatientDate==null||p_strInPatientDate=="" ||p_strCreateDate==null||p_strCreateDate=="")
				return null;

			clsOperationRecordContentDoctor objOperationRecordContent=null;

			string strXml = "";
			int intRows = 0;

            clsOperationRecordDoctorServ m_objServ =
                (clsOperationRecordDoctorServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOperationRecordDoctorServ));

            long lngRes = 0;
			try
            {
                lngRes = m_objServ.m_lngGetOperationRecordContent(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate,p_strCreateDate,ref strXml,ref intRows);
            }
            finally
            {
                //m_objServ.Dispose();
            }
			if(lngRes > 0 && intRows >0)
			{
				
				XmlTextReader objReader = new XmlTextReader(strXml,XmlNodeType.Element,m_objXmlParser);
				objReader.WhitespaceHandling = WhitespaceHandling.None;
			
				while(objReader.Read())
				{
					switch(objReader.NodeType)
					{
						case XmlNodeType.Element:
							if(objReader.HasAttributes)
							{
								
								objOperationRecordContent = new clsOperationRecordContentDoctor();

								objOperationRecordContent.m_strInPatientID=objReader.GetAttribute("INPATIENTID");
								objOperationRecordContent.m_strInPatientDate=objReader.GetAttribute("INPATIENTDATE");
								objOperationRecordContent.m_strOpenDate=objReader.GetAttribute("OPENDATE");
								objOperationRecordContent.m_strLastModifyDate=objReader.GetAttribute("LASTMODIFYDATE");
								objOperationRecordContent.m_strLastModifyUserID=objReader.GetAttribute("LASTMODIFYUSERID");
								objOperationRecordContent.m_strStatus=objReader.GetAttribute("STATUS");
								objOperationRecordContent.m_strDeActivedDate=objReader.GetAttribute("DEACTIVEDDATE");
								objOperationRecordContent.m_strDeActivedOperatorID=objReader.GetAttribute("DEACTIVEDOPERATORID");

								objOperationRecordContent.m_strDiagnoseBeforeOperation = objReader.GetAttribute("DIAGNOSEBEFOREOPERATION").Replace ('き','\'');

								objOperationRecordContent.m_strOperationName = objReader.GetAttribute("OPERATIONNAME").Replace ('き','\'');
								objOperationRecordContent.m_strDiagnoseAfterOperation = objReader.GetAttribute("DIAGNOSEAFTEROPERATION").Replace ('き','\'');
								objOperationRecordContent.m_strOperationBeginDate = objReader.GetAttribute("OPERATIONBEGINDATE").Replace ('き','\'');
								objOperationRecordContent.m_strOperationEndDate = objReader.GetAttribute("OPERATIONENDDATE").Replace ('き','\'');
								objOperationRecordContent.m_strAnaesthesiaBeforeOperation = objReader.GetAttribute("ANAESTHESIABEFOREOPERATION").Replace ('き','\'');
								objOperationRecordContent.m_strAnaesthesiaInOperation = objReader.GetAttribute("ANAESTHESIAINOPERATION").Replace ('き','\'');
								objOperationRecordContent.m_strAnaesthesiaCategoryDosage = objReader.GetAttribute("ANAESTHESIACATEGORYDOSAGE").Replace ('き','\'');
								objOperationRecordContent.m_strAnaesthesiaBeginDate = objReader.GetAttribute("ANAESTHESIABEGINDATE").Replace ('き','\'');
								objOperationRecordContent.m_strAnaesthesiaEndDate = objReader.GetAttribute("ANAESTHESIAENDDATE").Replace ('き','\'');
								objOperationRecordContent.m_strOperationProcess = objReader.GetAttribute("OPERATIONPROCESS").Replace ('き','\'');
								objOperationRecordContent.m_strPathology = objReader.GetAttribute("PATHOLOGY").Replace ('き','\'');
								objOperationRecordContent.m_strInLiquid = objReader.GetAttribute("INLIQUID").Replace ('き','\'');
								objOperationRecordContent.m_strOutFlow = objReader.GetAttribute("OUTFLOW").Replace ('き','\'');
								objOperationRecordContent.m_strSampleOrExtraRecord = objReader.GetAttribute("SAMPLEOREXTRARECORD").Replace ('き','\'');
								objOperationRecordContent.m_strSummaryAfterOperation = objReader.GetAttribute("SUMMARYAFTEROPERATION").Replace ('き','\'');
								objOperationRecordContent.m_strXRayNumber = objReader.GetAttribute("XRAYNUMBER").Replace ('き','\'');
								objOperationRecordContent.m_strAnaesther = objReader.GetAttribute("ANAESTHER").Replace ('き','\'');
								objOperationRecordContent.m_strDoctor1 = objReader.GetAttribute("DOCTOR1").Replace ('き','\'');
								objOperationRecordContent.m_strDoctor2 = objReader.GetAttribute("DOCTOR2").Replace ('き','\'');
								objOperationRecordContent.m_strAssistant=objReader.GetAttribute("ASSISTANT").Replace ('き','\'');//助手签名
								objOperationRecordContent.m_strOperationDoctor=objReader.GetAttribute("OPERATIONDOCTOR").Replace ('き','\'');//手术医师签名
								objOperationRecordContent.m_strNurse = objReader.GetAttribute("NURSE").Replace ('き','\'');//护士签名
							}
							break;
					}
				}
			}
						
			return objOperationRecordContent;

            
		}

		/// <summary>
		/// 获取主表的信息
		/// </summary>
		/// <param name="p_strInPatientID"></param>
		/// <param name="p_strInPatientDate"></param>
		/// <param name="p_strCreateDate"></param>
		/// <returns></returns>
		public clsOperationRecordDoctor  m_objGetOperationRecord(string p_strInPatientID,string p_strInPatientDate,string p_strCreateDate)
		{ 
			if(p_strInPatientID ==null||p_strInPatientID ==""||p_strInPatientDate==null||p_strInPatientDate=="" ||p_strCreateDate==null||p_strCreateDate=="")
				return null;

			clsOperationRecordDoctor  objOperationRecord = null;
			string strXml = "";
			int intRows = 0;

            clsOperationRecordDoctorServ m_objServ =
                (clsOperationRecordDoctorServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOperationRecordDoctorServ));

            long lngRes = 0;
			try
            {
                lngRes = m_objServ.m_lngGetOperationRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate,p_strCreateDate,ref strXml,ref intRows);
            }
            finally
            {
                //m_objServ.Dispose();
            }
			if(lngRes > 0 && intRows >0)
			{
				
				XmlTextReader objReader = new XmlTextReader(strXml,XmlNodeType.Element,m_objXmlParser);
				objReader.WhitespaceHandling = WhitespaceHandling.None;
			
				while(objReader.Read())
				{
					switch(objReader.NodeType)
					{
						case XmlNodeType.Element:
							if(objReader.HasAttributes)
							{
								objOperationRecord  = new clsOperationRecordDoctor ();
								objOperationRecord.m_strInPatientID = objReader.GetAttribute("INPATIENTID").Replace ('き','\'');
								objOperationRecord.m_strInPatientDate = objReader.GetAttribute("INPATIENTDATE").Replace ('き','\'');
								objOperationRecord.m_strOpenDate=objReader.GetAttribute("OPENDATE").Replace ('き','\'');
								objOperationRecord.m_strCreateDate=objReader.GetAttribute("CREATEDATE").Replace ('き','\'');
								objOperationRecord.m_strStatus=objReader.GetAttribute("STATUS").Replace ('き','\'');
								objOperationRecord.m_strFirstPrintDate=objReader.GetAttribute("FIRSTPRINTDATE").Replace ('き','\'');
								objOperationRecord.m_strIfConfirm=objReader.GetAttribute("IFCONFIRM").Replace ('き','\'');
								objOperationRecord.m_strDeActivedDate=objReader.GetAttribute("DEACTIVEDDATE").Replace ('き','\'');
								objOperationRecord.m_strDeActivedOperatorID=objReader.GetAttribute("DEACTIVEDOPERATORID").Replace ('き','\'');
								objOperationRecord.m_strConfirmReason=objReader.GetAttribute("CONFIRMREASON").Replace ('き','\'');;
								objOperationRecord.m_strConfirmReasonXML=objReader.GetAttribute("CONFIRMREASONXML").Replace ('き','\'');
								objOperationRecord.m_strCreateUserID=objReader.GetAttribute("CREATEUSERID").Replace ('き','\'');
		
								objOperationRecord.m_strAnaesthesiaBeforeOperationXML = objReader.GetAttribute("ANAESTHESIABEFOREOPERATIONXML").Replace ('き','\'');
								objOperationRecord.m_strAnaesthesiaInOperationXML = objReader.GetAttribute("ANAESTHESIAINOPERATIONXML").Replace ('き','\'');
								objOperationRecord.m_strAnaesthesiaCategoryDosageXML = objReader.GetAttribute("ANAESTHESIACATEGORYDOSAGEXML").Replace ('き','\'');
								objOperationRecord.m_strDiagnoseBeforeOperationXML = objReader.GetAttribute("DIAGNOSEBEFOREOPERATIONXML").Replace ('き','\'');

								objOperationRecord.m_strOperationNameXML = objReader.GetAttribute("OPERATIONNAMEXML").Replace ('き','\'');
								objOperationRecord.m_strDiagnoseAfterOperationXML = objReader.GetAttribute("DIAGNOSEAFTEROPERATIONXML").Replace ('き','\'');
								objOperationRecord.m_strOperationProcessXML = objReader.GetAttribute("OPERATIONPROCESSXML").Replace ('き','\'');
								objOperationRecord.m_strPathologyXML = objReader.GetAttribute("PATHOLOGYXML").Replace ('き','\'');
								objOperationRecord.m_strSampleOrExtraRecordXML = objReader.GetAttribute("SAMPLEOREXTRARECORDXML").Replace ('き','\'');
								objOperationRecord.m_strSummaryAfterOperationXML = objReader.GetAttribute("SUMMARYAFTEROPERATIONXML").Replace ('き','\'');
								objOperationRecord.m_strInLiquidXML = objReader.GetAttribute("INLIQUIDXML").Replace ('き','\'');
								objOperationRecord.m_strOutFlowXML = objReader.GetAttribute("OUTFLOWXML").Replace ('き','\'');
								objOperationRecord.m_strXRayNumberXML = objReader.GetAttribute("XRAYNUMBERXML").Replace ('き','\'');

                                try
                                {
                                    //获取签名
                                    objOperationRecord.int_Sequence =Convert.ToInt64 ( objReader.GetAttribute("SEQUENCE_INT").Replace('き', '\''));

                                    long lngS = objOperationRecord.int_Sequence;

                                    com.digitalwave.PublicMiddleTier.clsPublicMiddleTier objSign =
                                        (com.digitalwave.PublicMiddleTier.clsPublicMiddleTier)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.PublicMiddleTier.clsPublicMiddleTier));

                                    long lngTemp = objSign.m_lngGetSign(lngS, out objOperationRecord.objSignerArr);

                                    //释放
                                    objSign = null;

                                }
                                catch (Exception)
                                {

                                    objOperationRecord.int_Sequence = 0;
                                }

								objOperationRecord.m_strXML_TotalRecord=strXml;
							}
							break;
					}
				}
			}
						
			return objOperationRecord;
            
		}

		/// <summary>
		/// 获得最后的手术名称ID
		/// </summary>
		/// <param name="p_strInPatientID"></param>
		/// <param name="p_strInPatientDate"></param>
		/// <param name="p_strCreateDate"></param>
		/// <returns></returns>
		public long m_lngGetLastestOperationIDArr(string p_strInPatientID,string p_strInPatientDate,string p_strCreateDate,out string[] strOpertionIDArr)
		{
			strOpertionIDArr = null;
			if(p_strInPatientID == null || p_strInPatientID == "" || p_strInPatientDate == null || p_strInPatientDate == "" || p_strCreateDate == null || p_strCreateDate == "")
				return -1;			
			
			string strXml = "";
			int intRows = 0;

            clsOperationRecordDoctorServ m_objServ =
                (clsOperationRecordDoctorServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOperationRecordDoctorServ));

            long lngRes = 0;
			try
            {
                lngRes = m_objServ.m_lngGetLastestOperationIDArr(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate,p_strCreateDate,out strXml,out intRows);
            }
            finally
            {
                //m_objServ.Dispose();
            }
			if(lngRes > 0 && intRows >0)
			{
				XmlTextReader objReader = new XmlTextReader(strXml,XmlNodeType.Element,m_objXmlParser);
				objReader.WhitespaceHandling = WhitespaceHandling.None;
			
				strOpertionIDArr=new string[intRows];
				int intIndex=0;
				while(objReader.Read())
				{
					switch (objReader.NodeType)
					{
						case XmlNodeType.Element:
							if(objReader.HasAttributes)
							{
								strOpertionIDArr[intIndex++]=objReader.GetAttribute("OPERATIONID");
							}
							break;
					}
				}
			}
			return lngRes;
		}
		#endregion

		#region 读取已经被删除的信息		
		/// <summary>
		/// 获得从表的信息
		/// </summary>
		/// <param name="p_strInPatientID"></param>
		/// <param name="p_strInPatientDate"></param>
		/// <param name="p_strCreateDate"></param>
		/// <returns></returns>
		public clsOperationRecordContentDoctor m_objGetDeletedOperationRecordContent(string p_strInPatientID,string p_strInPatientDate,string p_strOpenDate)
		{ 
			if(p_strInPatientID ==null||p_strInPatientID ==""||p_strInPatientDate==null||p_strInPatientDate=="" ||p_strOpenDate==null||p_strOpenDate=="")
				return null;

			clsOperationRecordContentDoctor objOperationRecordContent=null;

			string strXml = "";
			int intRows = 0;

            clsOperationRecordDoctorServ m_objServ =
                (clsOperationRecordDoctorServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOperationRecordDoctorServ));

            long lngRes = 0;
			try
            {
                lngRes = m_objServ.m_lngGetDeletedOperationRecordContent(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate,p_strOpenDate,ref strXml,ref intRows);
            }
            finally
            {
                //m_objServ.Dispose();
            }
			if(lngRes > 0 && intRows >0)
			{
				
				XmlTextReader objReader = new XmlTextReader(strXml,XmlNodeType.Element,m_objXmlParser);
				objReader.WhitespaceHandling = WhitespaceHandling.None;
			
				while(objReader.Read())
				{
					switch(objReader.NodeType)
					{
						case XmlNodeType.Element:
							if(objReader.HasAttributes)
							{
								
								objOperationRecordContent = new clsOperationRecordContentDoctor();

								objOperationRecordContent.m_strInPatientID=objReader.GetAttribute("INPATIENTID");
								objOperationRecordContent.m_strInPatientDate=objReader.GetAttribute("INPATIENTDATE");
								objOperationRecordContent.m_strOpenDate=objReader.GetAttribute("OPENDATE");
								objOperationRecordContent.m_strLastModifyDate=objReader.GetAttribute("LASTMODIFYDATE");
								objOperationRecordContent.m_strLastModifyUserID=objReader.GetAttribute("LASTMODIFYUSERID");
								objOperationRecordContent.m_strStatus=objReader.GetAttribute("STATUS");
								objOperationRecordContent.m_strDeActivedDate=objReader.GetAttribute("DEACTIVEDDATE");
								objOperationRecordContent.m_strDeActivedOperatorID=objReader.GetAttribute("DEACTIVEDOPERATORID");

								objOperationRecordContent.m_strDiagnoseBeforeOperation = objReader.GetAttribute("DIAGNOSEBEFOREOPERATION").Replace ('き','\'');

								objOperationRecordContent.m_strOperationName = objReader.GetAttribute("OPERATIONNAME").Replace ('き','\'');
								objOperationRecordContent.m_strDiagnoseAfterOperation = objReader.GetAttribute("DIAGNOSEAFTEROPERATION").Replace ('き','\'');
								objOperationRecordContent.m_strOperationBeginDate = objReader.GetAttribute("OPERATIONBEGINDATE").Replace ('き','\'');
								objOperationRecordContent.m_strOperationEndDate = objReader.GetAttribute("OPERATIONENDDATE").Replace ('き','\'');
								objOperationRecordContent.m_strAnaesthesiaBeforeOperation = objReader.GetAttribute("ANAESTHESIABEFOREOPERATION").Replace ('き','\'');
								objOperationRecordContent.m_strAnaesthesiaInOperation = objReader.GetAttribute("ANAESTHESIAINOPERATION").Replace ('き','\'');
								objOperationRecordContent.m_strAnaesthesiaCategoryDosage = objReader.GetAttribute("ANAESTHESIACATEGORYDOSAGE").Replace ('き','\'');
								objOperationRecordContent.m_strAnaesthesiaBeginDate = objReader.GetAttribute("ANAESTHESIABEGINDATE").Replace ('き','\'');
								objOperationRecordContent.m_strAnaesthesiaEndDate = objReader.GetAttribute("ANAESTHESIAENDDATE").Replace ('き','\'');
								objOperationRecordContent.m_strOperationProcess = objReader.GetAttribute("OPERATIONPROCESS").Replace ('き','\'');
								objOperationRecordContent.m_strPathology = objReader.GetAttribute("PATHOLOGY").Replace ('き','\'');
								objOperationRecordContent.m_strInLiquid = objReader.GetAttribute("INLIQUID").Replace ('き','\'');
								objOperationRecordContent.m_strOutFlow = objReader.GetAttribute("OUTFLOW").Replace ('き','\'');
								objOperationRecordContent.m_strSampleOrExtraRecord = objReader.GetAttribute("SAMPLEOREXTRARECORD").Replace ('き','\'');
								objOperationRecordContent.m_strSummaryAfterOperation = objReader.GetAttribute("SUMMARYAFTEROPERATION").Replace ('き','\'');
								objOperationRecordContent.m_strXRayNumber = objReader.GetAttribute("XRAYNUMBER").Replace ('き','\'');
							}
							break;
					}
				}
			}
						
			return objOperationRecordContent;

            
		}

		/// <summary>
		/// 获取主表的信息
		/// </summary>
		/// <param name="p_strInPatientID"></param>
		/// <param name="p_strInPatientDate"></param>
		/// <param name="p_strCreateDate"></param>
		/// <returns></returns>
		public clsOperationRecordDoctor  m_objGetDeletedOperationRecord(string p_strInPatientID,string p_strInPatientDate,string p_strOpenDate)
		{ 
			if(p_strInPatientID ==null||p_strInPatientID ==""||p_strInPatientDate==null||p_strInPatientDate=="" ||p_strOpenDate==null||p_strOpenDate=="")
				return null;

			clsOperationRecordDoctor  objOperationRecord = null;
			string strXml = "";
			int intRows = 0;

            clsOperationRecordDoctorServ m_objServ =
                (clsOperationRecordDoctorServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOperationRecordDoctorServ));

            long lngRes = 0;
			try
            {
                lngRes = m_objServ.m_lngGetDeletedOperationRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate,p_strOpenDate,ref strXml,ref intRows);
            }
            finally
            {
                //m_objServ.Dispose();
            }
			if(lngRes > 0 && intRows >0)
			{
				
				XmlTextReader objReader = new XmlTextReader(strXml,XmlNodeType.Element,m_objXmlParser);
				objReader.WhitespaceHandling = WhitespaceHandling.None;
			
				while(objReader.Read())
				{
					switch(objReader.NodeType)
					{
						case XmlNodeType.Element:
							if(objReader.HasAttributes)
							{
								objOperationRecord  = new clsOperationRecordDoctor ();
								objOperationRecord.m_strInPatientID = objReader.GetAttribute("INPATIENTID").Replace ('き','\'');
								objOperationRecord.m_strInPatientDate = objReader.GetAttribute("INPATIENTDATE").Replace ('き','\'');
								objOperationRecord.m_strOpenDate=objReader.GetAttribute("OPENDATE").Replace ('き','\'');
								objOperationRecord.m_strCreateDate=objReader.GetAttribute("CREATEDATE").Replace ('き','\'');
								objOperationRecord.m_strStatus=objReader.GetAttribute("STATUS").Replace ('き','\'');
								objOperationRecord.m_strFirstPrintDate=objReader.GetAttribute("FIRSTPRINTDATE").Replace ('き','\'');
								objOperationRecord.m_strIfConfirm=objReader.GetAttribute("IFCONFIRM").Replace ('き','\'');
								objOperationRecord.m_strDeActivedDate=objReader.GetAttribute("DEACTIVEDDATE").Replace ('き','\'');
								objOperationRecord.m_strDeActivedOperatorID=objReader.GetAttribute("DEACTIVEDOPERATORID").Replace ('き','\'');
								objOperationRecord.m_strConfirmReason=objReader.GetAttribute("CONFIRMREASON").Replace ('き','\'');;
								objOperationRecord.m_strConfirmReasonXML=objReader.GetAttribute("CONFIRMREASONXML").Replace ('き','\'');
								objOperationRecord.m_strCreateUserID=objReader.GetAttribute("CREATEUSERID").Replace ('き','\'');
		
								objOperationRecord.m_strAnaesthesiaBeforeOperationXML = objReader.GetAttribute("ANAESTHESIABEFOREOPERATIONXML").Replace ('き','\'');
								objOperationRecord.m_strAnaesthesiaInOperationXML = objReader.GetAttribute("ANAESTHESIAINOPERATIONXML").Replace ('き','\'');
								objOperationRecord.m_strAnaesthesiaCategoryDosageXML = objReader.GetAttribute("ANAESTHESIACATEGORYDOSAGEXML").Replace ('き','\'');
								objOperationRecord.m_strDiagnoseBeforeOperationXML = objReader.GetAttribute("DIAGNOSEBEFOREOPERATIONXML").Replace ('き','\'');

								objOperationRecord.m_strOperationNameXML = objReader.GetAttribute("OPERATIONNAMEXML").Replace ('き','\'');
								objOperationRecord.m_strDiagnoseAfterOperationXML = objReader.GetAttribute("DIAGNOSEAFTEROPERATIONXML").Replace ('き','\'');
								objOperationRecord.m_strOperationProcessXML = objReader.GetAttribute("OPERATIONPROCESSXML").Replace ('き','\'');
								objOperationRecord.m_strPathologyXML = objReader.GetAttribute("PATHOLOGYXML").Replace ('き','\'');
								objOperationRecord.m_strSampleOrExtraRecordXML = objReader.GetAttribute("SAMPLEOREXTRARECORDXML").Replace ('き','\'');
								objOperationRecord.m_strSummaryAfterOperationXML = objReader.GetAttribute("SUMMARYAFTEROPERATIONXML").Replace ('き','\'');
								objOperationRecord.m_strInLiquidXML = objReader.GetAttribute("INLIQUIDXML").Replace ('き','\'');
								objOperationRecord.m_strOutFlowXML = objReader.GetAttribute("OUTFLOWXML").Replace ('き','\'');
								objOperationRecord.m_strXRayNumberXML = objReader.GetAttribute("XRAYNUMBERXML").Replace ('き','\'');

								objOperationRecord.m_strXML_TotalRecord=strXml;
							}
							break;
					}
				}
			}
						
			return objOperationRecord;
            
		}

		/// <summary>
		/// 获得最后的手术名称ID
		/// </summary>
		/// <param name="p_strInPatientID"></param>
		/// <param name="p_strInPatientDate"></param>
		/// <param name="p_strCreateDate"></param>
		/// <returns></returns>
		public long m_lngGetDeletedLastestOperationIDArr(string p_strInPatientID,string p_strInPatientDate,string p_strOpenDate,out string[] strOpertionIDArr)
		{
			strOpertionIDArr = null;
			if(p_strInPatientID == null || p_strInPatientID == "" || p_strInPatientDate == null || p_strInPatientDate == "" || p_strOpenDate == null || p_strOpenDate == "")
				return -1;			
			
			string strXml = "";
			int intRows = 0;

            clsOperationRecordDoctorServ m_objServ =
                (clsOperationRecordDoctorServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOperationRecordDoctorServ));

            long lngRes = 0;
			try
            {
                lngRes = m_objServ.m_lngGetDeletedLastestOperationIDArr(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate,p_strOpenDate,out strXml,out intRows);
            }
            finally
            {
                //m_objServ.Dispose();
            }
			if(lngRes > 0 && intRows >0)
			{
				XmlTextReader objReader = new XmlTextReader(strXml,XmlNodeType.Element,m_objXmlParser);
				objReader.WhitespaceHandling = WhitespaceHandling.None;
			
				strOpertionIDArr=new string[intRows];
				int intIndex=0;
				while(objReader.Read())
				{
					switch (objReader.NodeType)
					{
						case XmlNodeType.Element:
							if(objReader.HasAttributes)
							{
								strOpertionIDArr[intIndex++]=objReader.GetAttribute("OPERATIONID");
							}
							break;
					}
				}
			}
			return lngRes;
		}
		#endregion

		#region Delete
		public long m_lngDeleteRecord(string  p_strInPatientID, string p_strInPatientDate,string  p_strOpenDate,string p_strOperatorID )
		{
            clsOperationRecordDoctorServ m_objServ =
                (clsOperationRecordDoctorServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOperationRecordDoctorServ));

            long lngRes = 0;
			try
            {
                lngRes = m_objServ.m_lngDelete( clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID, p_strInPatientDate, p_strOpenDate , p_strOperatorID);
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
		{//更新第一次打印时间		
            clsOperationRecordDoctorServ m_objServ =
                (clsOperationRecordDoctorServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOperationRecordDoctorServ));

            long lngRes = 0;
			try
            {
                lngRes = m_objServ.m_lngUpdateFirstPrintDate(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate,p_strOpenDate,p_strFirstPrintDate);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}

		#endregion

		/// <summary>
		/// 添加记录时查询用户输入的时间有无重复
		/// </summary>		
		public long m_lngRecordExist(string p_strInPatientID,string p_strInPatientDate,string p_strCreateDate,out bool p_blnExist)
		{
            clsOperationRecordDoctorServ m_objServ =
                (clsOperationRecordDoctorServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOperationRecordDoctorServ));

            long lngRes = 0;
			try
            {
                lngRes = m_objServ.m_lngRecordExist(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate,p_strCreateDate,out p_blnExist);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}

		/// <summary>
		/// 查找该条记录的第一次打印时间
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_strInPatientID"></param>
		/// <param name="p_strInPatientDate"></param>
		/// <param name="p_strOpenDate"></param>
		/// <param name="p_strFirstPrintDate"></param>
		/// <returns></returns>
		public long m_lngGetFirstPrintDate(string p_strInPatientID,string p_strInPatientDate,string p_strOpenDate,out string p_strFirstPrintDate)
		{
            clsOperationRecordDoctorServ m_objServ =
                (clsOperationRecordDoctorServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOperationRecordDoctorServ));

            long lngRes = 0;
			try
            {
                lngRes = m_objServ.m_lngGetFirstPrintDate(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate,p_strOpenDate,out p_strFirstPrintDate);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}

		/// <summary>
		/// 获得最后修改时间
		/// </summary>
		/// <param name="p_strPatientID"></param>
		/// <param name="p_strInPatientDate"></param>
		/// <param name="p_strOpenDate"></param>
		/// <param name="p_strLastModifyDate"></param>
		/// <returns></returns>
		public long m_lngGetOperationRecordLastModifyDate(string p_strPatientID,string p_strInPatientDate,string p_strOpenDate,out string  p_strLastModifyDate)
		{
            clsOperationRecordDoctorServ m_objServ =
                (clsOperationRecordDoctorServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOperationRecordDoctorServ));

            long lngRes = 0;
			try
            {
                lngRes = m_objServ.m_lngGetOperationRecordLastModifyDate(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strPatientID,p_strInPatientDate,p_strOpenDate,out p_strLastModifyDate);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}

		public long m_lngGetDoctorSign(string p_strInPatientID,string p_strInPatientDate,
			string p_strOpenDate,out clsOperationRecordDoctorSign p_objRecordContent)
		{
			p_objRecordContent=null;

			//检查参数
			if(p_strInPatientID==null||p_strInPatientID==""|| p_strInPatientDate==null||p_strInPatientDate==""||p_strOpenDate==null||p_strOpenDate=="")
				return (long)enmOperationResult.Parameter_Error;

            clsOperationRecordDoctorServ m_objServ =
                (clsOperationRecordDoctorServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOperationRecordDoctorServ));

            long lngRes = 0;
			try
            {
                lngRes = m_objServ.m_lngGetDoctorSign(p_strInPatientID,p_strInPatientDate,p_strOpenDate,out p_objRecordContent);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}

		/// <summary>
		/// 获取图片信息
		/// </summary>
		/// <returns></returns>
		public long m_lngGetPics(string p_strInPatientID,string p_strInPatientDate,
			string p_strOpenDate,out clsPictureBoxValue[] p_objPics)
		{
			p_objPics = null;
			//检查参数
			if(p_strInPatientID==null||p_strInPatientID==""|| p_strInPatientDate==null||p_strInPatientDate==""||p_strOpenDate==null||p_strOpenDate=="")
				return (long)enmOperationResult.Parameter_Error;

            clsOperationRecordDoctorServ m_objServ =
                (clsOperationRecordDoctorServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOperationRecordDoctorServ));

            long lngRes = 0;
			try
            {
                lngRes = m_objServ.m_lngGetPics(p_strInPatientID,p_strInPatientDate,p_strOpenDate,out p_objPics);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}
	}

//	/// <summary>
//	/// 主表的信息
//	/// </summary>
//	/// 
//	[Serializable]
//	public class clsOperationRecordDoctor
//	{
//		public string m_strInPatientID;
//		public string m_strInPatientDate;
//		public string m_strOpenDate;
//		public string m_strCreateDate;
//		public string m_strCreateUserID;
//		
//		public string m_strIfConfirm;
//		public string m_strConfirmReason;
//		public string m_strConfirmReasonXML;
//		
//		public string m_strStatus;
//
//		public string m_strFirstPrintDate;
//
//		public string m_strDeActivedDate;
//		public string m_strDeActivedOperatorID;
//
//		public string m_strAnaesthesiaBeforeOperationXML;
//		public string m_strAnaesthesiaInOperationXML;
//		public string m_strAnaesthesiaCategoryDosageXML;
//		public string m_strDiagnoseBeforeOperationXML;
//		public string m_strDiagnoseAfterOperationXML;
//		public string m_strOperationProcessXML;
//		public string m_strPathologyXML;
//		public string m_strSampleOrExtraRecordXML;
//		public string m_strSummaryAfterOperationXML;
//		public string m_strInLiquidXML;
//		public string m_strOutFlowXML;
//
//		/// <summary>
//		/// 用于从数据库数据库查询时使用
//		/// 用于以后比较后是否为相同内容的Object
//		/// </summary>
//		public string m_strXML_TotalRecord;
//
//		public string m_strXRayNumberXML;
//
//		public string m_strOperationNameXML;
//	}
//
//	/// <summary>
//	/// 从表的信息
//	/// </summary>
//	/// 
//	[Serializable]
//	public class clsOperationRecordContentDoctor
//	{
//		public string m_strInPatientID;
//		public string m_strInPatientDate;
//		public string m_strOpenDate;
//		public string m_strLastModifyDate;
//
//		public string m_strLastModifyUserID;
//		public string m_strDeActivedDate;
//		public string m_strDeActivedOperatorID;
//		public string m_strStatus;
//
//		public string m_strDiagnoseBeforeOperation;
//		public string m_strDiagnoseAfterOperation;
//		public string m_strOperationBeginDate;
//		public string m_strOperationEndDate;
//		public string m_strAnaesthesiaBeforeOperation;
//		public string m_strAnaesthesiaInOperation;
//		public string m_strAnaesthesiaCategoryDosage;
//		public string m_strAnaesthesiaBeginDate;
//		public string m_strAnaesthesiaEndDate;
//		public string m_strOperationProcess;
//		public string m_strPathology;
//		public string m_strInLiquid;
//		public string m_strOutFlow;
//		public string m_strSampleOrExtraRecord;
//		public string m_strSummaryAfterOperation;
//		public string m_strXRayNumber;
//
//		public string m_strOperationName;//手术名称
//	}
}
