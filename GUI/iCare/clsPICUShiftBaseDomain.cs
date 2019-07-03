using System;
using System.Xml;
using System.IO;
using System.Text;
using iCareData;

namespace iCare
{
	/// <summary>
	/// Summary description for clsPICUShiftBaseDomain.
	/// PICU转出转入记录基类
	/// </summary>
	public abstract class clsPICUShiftBaseDomain
	{
		/// <summary>
		/// 生成Xml的缓冲
		/// </summary>
		private MemoryStream m_objXmlMemStream;

		/// <summary>
		/// 生成Xml的工具
		/// </summary>
		private XmlTextWriter m_objXmlWriter;

		/// <summary>
		/// 读取Xml工具输入参数
		/// </summary>
		private XmlParserContext m_objXmlParser;

		public clsPICUShiftBaseDomain()
		{
			m_objXmlMemStream = new MemoryStream(300);

			m_objXmlWriter = new XmlTextWriter(m_objXmlMemStream,System.Text.Encoding.Unicode);
			m_objXmlWriter.Flush();//清空原来的字符

			m_objXmlParser = new XmlParserContext(null,null,null,XmlSpace.None,Encoding.Unicode);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="p_objInfo"></param>
		/// <returns>生成的XML</returns>
		private string m_strMakeNewXml(clsPICUShiftInfo p_objInfo)
		{
			m_objXmlMemStream.SetLength(0);

			m_objXmlWriter.WriteStartDocument();
			m_objXmlWriter.WriteStartElement("PICUShiftInfo");

			p_objInfo.m_mthMakeMainXML(m_objXmlWriter);

			m_objXmlWriter.WriteEndElement();
			m_objXmlWriter.WriteEndDocument();

			m_objXmlWriter.Flush();

			return System.Text.Encoding.Unicode.GetString(m_objXmlMemStream.ToArray(),39*2,(int)m_objXmlMemStream.Length-39*2);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="p_objInfo"></param>
		/// <returns>生成的XML</returns>
		private string m_strMakeNewContentXml(clsPICUShiftInfo p_objInfo)
		{
			m_objXmlMemStream.SetLength(0);

			m_objXmlWriter.WriteStartDocument();
			m_objXmlWriter.WriteStartElement("PICUShiftInfo");

			p_objInfo.m_mthMakeContentXML(m_objXmlWriter);

			m_objXmlWriter.WriteEndElement();
			m_objXmlWriter.WriteEndDocument();

			m_objXmlWriter.Flush();

			return System.Text.Encoding.Unicode.GetString(m_objXmlMemStream.ToArray(),39*2,(int)m_objXmlMemStream.Length-39*2);
		}

		public abstract long m_lngCheckNewCreateDate(string p_strInPatientID,string p_strInPatientDate,string p_strCreateDate,out bool p_blnIsAddNew);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="p_objInfo"></param>
		/// <returns>
		/// 操作结果。
		/// 0，失败。
		/// 1，成功。
		/// </returns>
		public long m_lngAddNew(clsPICUShiftInfo p_objInfo)
		{
			string strMainXml = m_strMakeNewXml(p_objInfo);
			string strContentXml = m_strMakeNewContentXml(p_objInfo);

			return m_lngSubAddNew(strMainXml,strContentXml);
		}

		protected abstract long m_lngSubAddNew(string p_strMainXml,string p_strContentXml);

		public abstract long m_lngCheckLastModifyDate(string p_strInPatientID,string p_strInPatientDate,string p_strCreateDate,string p_strLastModifyDate,out bool p_blnIsLast);
			
		/// <summary>
		/// 
		/// </summary>
		/// <param name="p_objInfo"></param>
		/// <returns>
		/// 操作结果。
		/// 0，失败。
		/// 1，成功。
		/// </returns>
		public long m_lngModify(clsPICUShiftInfo p_objInfo)
		{
			string strContentXml = m_strMakeNewContentXml(p_objInfo);

			return m_lngSubModify(null,strContentXml);
		}
		
		protected abstract long m_lngSubModify(string p_strMainXml,string p_strContentXml);

		protected abstract long m_lngSubGetCreateDateArr(string p_strInPatientID,string p_strInPatientDate,ref string p_strResultXml,ref int p_intResultRows);

		public string [] m_strGetCreateDateArr(clsPatient p_objPatient)
		{
			string strXML = "";
			int intRows = 0;

            long lngRes = m_lngSubGetCreateDateArr(p_objPatient.m_StrInPatientID, p_objPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"), ref strXML, ref intRows);

			if(lngRes > 0 && intRows >0)
			{
				string [] strCreateDateArr = new string[intRows];

				XmlTextReader objReader = new XmlTextReader(strXML,XmlNodeType.Element,m_objXmlParser);
				objReader.WhitespaceHandling = WhitespaceHandling.None;
			
				int intIndex = 0;
				while(objReader.Read())
				{
					switch(objReader.NodeType)
					{
						case XmlNodeType.Element:
							if(objReader.HasAttributes)
							{
								strCreateDateArr[intIndex] = objReader.GetAttribute("CREATEDATE");

								intIndex++;
							}
							break;
					}
				}

				return strCreateDateArr;
			}
			else
			{
				return new string[0];
			}
		}

		protected abstract long m_lngSubGetPICUShiftInfo(string p_strInPatientID,string p_strInPatientDate,string p_strCreateDate,ref string p_strResultXml,ref int p_intResultRows);
		protected abstract long m_lngSubGetDeletedPICUShiftInfo(string p_strInPatientID,string p_strInPatientDate,string p_strCreateDate,ref string p_strResultXml,ref int p_intResultRows);

		protected abstract clsPICUShiftTurnInfo m_objGetTurnInfo();
		
		public clsPICUShiftInfo m_objGetPICUShiftInfo(clsPatient p_objPatient,string p_strTurnTime)
		{
			string strXML = "";
			int intRows = 0;

            long lngRes = m_lngSubGetPICUShiftInfo(p_objPatient.m_StrInPatientID, p_objPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"), p_strTurnTime, ref strXML, ref intRows);

			if(lngRes > 0 && intRows >0)
			{
				XmlTextReader objReader = new XmlTextReader(strXML,XmlNodeType.Element,m_objXmlParser);
				objReader.WhitespaceHandling = WhitespaceHandling.None;
			
				while(objReader.Read())
				{
					switch(objReader.NodeType)
					{
						case XmlNodeType.Element:
							if(objReader.HasAttributes)
							{
								clsPICUShiftInfo objShiftInfo = new clsPICUShiftInfo();

								clsPICUShiftTurnInfo objTurnInfo = m_objGetTurnInfo();
								objTurnInfo.m_strInPatientID = p_objPatient.m_StrInPatientID;
                                objTurnInfo.m_strINPATIENTDATE = p_objPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss");
								clsPICUShiftBaseInfo objBaseInfo = new clsPICUShiftBaseInfo();
								clsPICUShiftCheckInfo objCheckInfo = new clsPICUShiftCheckInfo();
								clsPICUShiftLabReportInfo objLabReport = new clsPICUShiftLabReportInfo();

								objShiftInfo.m_objTurnInfo = objTurnInfo;
								objShiftInfo.m_objBaseInfo = objBaseInfo;
								objShiftInfo.m_objPICUCheckInfo = objCheckInfo;
								objShiftInfo.m_objLabReportInfo = objLabReport;

								objShiftInfo.m_mthSetValue(objReader);

								return objShiftInfo;
							}
							break;
					}
				}
			}
			return null;
		}



		public clsPICUShiftInfo m_objGetDeletedPICUShiftInfo(clsPatient p_objPatient,string p_strTurnTime)
		{
			string strXML = "";
			int intRows = 0;

			long lngRes = m_lngSubGetDeletedPICUShiftInfo(p_objPatient.m_StrInPatientID,p_objPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"),p_strTurnTime,ref strXML,ref intRows);

			if(lngRes > 0 && intRows >0)
			{
				XmlTextReader objReader = new XmlTextReader(strXML,XmlNodeType.Element,m_objXmlParser);
				objReader.WhitespaceHandling = WhitespaceHandling.None;
			
				while(objReader.Read())
				{
					switch(objReader.NodeType)
					{
						case XmlNodeType.Element:
							if(objReader.HasAttributes)
							{
								clsPICUShiftInfo objShiftInfo = new clsPICUShiftInfo();

								clsPICUShiftTurnInfo objTurnInfo = m_objGetTurnInfo();
								objTurnInfo.m_strInPatientID = p_objPatient.m_StrInPatientID;
								objTurnInfo.m_strINPATIENTDATE=p_objPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss");
								clsPICUShiftBaseInfo objBaseInfo = new clsPICUShiftBaseInfo();
								clsPICUShiftCheckInfo objCheckInfo = new clsPICUShiftCheckInfo();
								clsPICUShiftLabReportInfo objLabReport = new clsPICUShiftLabReportInfo();

								objShiftInfo.m_objTurnInfo = objTurnInfo;
								objShiftInfo.m_objBaseInfo = objBaseInfo;
								objShiftInfo.m_objPICUCheckInfo = objCheckInfo;
								objShiftInfo.m_objLabReportInfo = objLabReport;

								objShiftInfo.m_mthSetValue(objReader);

								return objShiftInfo;
							}
							break;
					}
				}
			}
			return null;
		}



		/// <summary>
		/// 删除记录。
		/// </summary>
		/// <param name="p_objRecordContent">当前要删除的记录</param>
		/// <param name="p_objModifyInfo">若当前要删除的记录不是最新的记录,返回该最新记录的操作信息,否则为空</param>
		/// <returns></returns>
		public abstract long m_lngDeleteRecord(clsTrackRecordContent p_objRecordContent,		
			out clsPreModifyInfo p_objModifyInfo);		
	}

	#region 数据实体VO
	
	[Serializable]
	public class clsPICUShiftInfo
	{
		/// <summary>
		/// 修改时间
		/// </summary>
		public DateTime m_dtmModifyDate;
		/// <summary>
		/// 操作ID
		/// </summary>
		public string m_StrEmployeeID;
		public string m_StrEmployeeName;
		/// <summary>
		/// 转情况
		/// </summary>
		public clsPICUShiftTurnInfo m_objTurnInfo;
		/// <summary>
		/// 基本情况
		/// </summary>
		public clsPICUShiftBaseInfo m_objBaseInfo;
		/// <summary>
		/// 监护情况
		/// </summary>
		public clsPICUShiftCheckInfo m_objPICUCheckInfo;
		/// <summary>
		/// 实验室报告
		/// </summary>
		public clsPICUShiftLabReportInfo m_objLabReportInfo;

		public void m_mthMakeContentXML(XmlTextWriter p_objXmlWriter)
		{
			p_objXmlWriter.WriteAttributeString("MODIFYDATE",m_dtmModifyDate.ToString("yyyy-MM-dd HH:mm:ss"));
			p_objXmlWriter.WriteAttributeString("MODIFYUSERID",m_StrEmployeeID);			
			
			if(m_objTurnInfo != null)
				m_objTurnInfo.m_mthMakeContentXML(p_objXmlWriter);

			if(m_objBaseInfo != null)
				m_objBaseInfo.m_mthMakeContentXML(p_objXmlWriter);

			if(m_objPICUCheckInfo != null)
				m_objPICUCheckInfo.m_mthMakeXML(p_objXmlWriter);

			if(m_objLabReportInfo != null)
				m_objLabReportInfo.m_mthMakeXML(p_objXmlWriter);
		}

		public void m_mthMakeMainXML(XmlTextWriter p_objXmlWriter)
		{
			if(m_objTurnInfo != null)
				m_objTurnInfo.m_mthMakeMainXML(p_objXmlWriter);
		}

		public void m_mthSetValue(XmlTextReader p_objReader)
		{
			m_dtmModifyDate = DateTime.Parse(p_objReader.GetAttribute("MODIFYDATE"));
			
			if(m_objTurnInfo != null)
				m_objTurnInfo.m_mthSetValue(p_objReader);

			if(m_objBaseInfo != null)
				m_objBaseInfo.m_mthSetValue(p_objReader);

			if(m_objPICUCheckInfo != null)
				m_objPICUCheckInfo.m_mthSetValue(p_objReader);

			if(m_objLabReportInfo != null)
				m_objLabReportInfo.m_mthSetValue(p_objReader);
		}

		public DateTime m_dtmDeActivedDate;
		public string m_strDeActivedOperatorID;
	}
	[Serializable]
	public abstract class clsPICUShiftTurnInfo
	{
		public abstract bool m_BlnIsShiftIn
		{
			get;
		}
		public DateTime m_dtmTurnTime;
		/// <summary>
		/// 住院号
		/// </summary>
		public string m_strInPatientID;
		/// <summary>
		/// 住院日期
		/// </summary>
		public string  m_strINPATIENTDATE;
		/// <summary>
		/// 转出医生ID
		/// </summary>
		public string m_strTurnFromEmployeeID;
		public string m_strTurnFromEmployeeName;
		/// <summary>
		/// 转入医生ID
		/// </summary>
		public string m_strTurnToEmployeeID;
		public string m_strTurnToEmployeeName;
		/// <summary>
		/// 转出科室ID
		/// </summary>
		public string m_strTurnFromDeptID;
		public string m_strTurnFromDeptName;
		/// <summary>
		/// 转入科室ID
		/// </summary>
		public string m_strTurnToDeptID;
		public string m_strTurnToDeptName;
		

		public abstract void m_mthMakeContentXML(XmlTextWriter p_objXmlWriter);
		
		public void m_mthMakeMainXML(XmlTextWriter p_objXmlWriter)
		{
			p_objXmlWriter.WriteAttributeString("INPATIENTID",m_strInPatientID);
			p_objXmlWriter.WriteAttributeString("INPATIENTDATE",m_strINPATIENTDATE);
			p_objXmlWriter.WriteAttributeString("CREATEDATE",m_dtmTurnTime.ToString("yyyy-MM-dd HH:mm:ss"));
			p_objXmlWriter.WriteAttributeString("CREATEID",m_strTurnFromEmployeeID);
			p_objXmlWriter.WriteAttributeString("IFCONFIRM","0");
			p_objXmlWriter.WriteAttributeString("STATUS","0");			
		}

		public abstract void m_mthSetValue(XmlTextReader p_objReader);		
	}

	[Serializable]
	public class clsPICUShiftBaseInfo
	{
		public string m_strInDiagnose;

		public string m_strOperationName;

		public string m_strAnaesthesiaType;

		public string m_strTurnDiagnose;

		public string m_strInDiagnoseCourse;

		public void m_mthMakeContentXML(XmlTextWriter p_objXmlWriter)
		{
			p_objXmlWriter.WriteAttributeString("INDIAGNOSE",m_strInDiagnose.Replace('\'','き'));
			p_objXmlWriter.WriteAttributeString("OPERATIONNAME",m_strOperationName.Replace('\'','き'));
			p_objXmlWriter.WriteAttributeString("ANAESTHESIATYPE",m_strAnaesthesiaType.Replace('\'','き'));
			p_objXmlWriter.WriteAttributeString("TURNDIAGNOSE",m_strTurnDiagnose.Replace('\'','き'));
			p_objXmlWriter.WriteAttributeString("INDIAGNOSECOURSE",m_strInDiagnoseCourse.Replace('\'','き'));
		}		

		public void m_mthSetValue(XmlTextReader p_objReader)
		{
			m_strInDiagnose = p_objReader.GetAttribute("INDIAGNOSE").Replace ('き','\'');
			m_strOperationName = p_objReader.GetAttribute("OPERATIONNAME").Replace ('き','\'');
			m_strAnaesthesiaType = p_objReader.GetAttribute("ANAESTHESIATYPE").Replace ('き','\'');
			m_strTurnDiagnose = p_objReader.GetAttribute("TURNDIAGNOSE").Replace ('き','\'');
			m_strInDiagnoseCourse = p_objReader.GetAttribute("INDIAGNOSECOURSE").Replace ('き','\'');
		}
	}

	[Serializable]
	public class clsPICUShiftCheckInfo
	{
		public float m_fltTemperature;

		public float m_fltHeartRate;

		public float m_fltPulse;

		public float m_fltSystolic;

		public float m_fltDiastolic;

		public string m_strMind;

		public float m_fltPupilDiameterRight;

		public float m_fltPupilDiameterLeft;

		public string m_strPupilReflectionRight;

		public string m_strPupilReflectionLeft;

		public clsPICUShiftGlasgow m_objGlasgow;

		public string m_strOther;

		public void m_mthMakeXML(XmlTextWriter p_objXmlWriter)
		{
			if(!float.IsNaN(m_fltTemperature))
				p_objXmlWriter.WriteAttributeString("TEMPERATURE",m_fltTemperature.ToString("0.00"));
			if(!float.IsNaN(m_fltHeartRate))
				p_objXmlWriter.WriteAttributeString("HEARTRATE",m_fltHeartRate.ToString("0.00"));
			if(!float.IsNaN(m_fltPulse))
				p_objXmlWriter.WriteAttributeString("PULSE",m_fltPulse.ToString("0.00"));
			if(!float.IsNaN(m_fltSystolic))
				p_objXmlWriter.WriteAttributeString("SYSTOLIC",m_fltSystolic.ToString("0.00"));
			if(!float.IsNaN(m_fltDiastolic))
				p_objXmlWriter.WriteAttributeString("DIASTOLIC",m_fltDiastolic.ToString("0.00"));
			p_objXmlWriter.WriteAttributeString("MIND",m_strMind.Replace('\'','き'));
			if(!float.IsNaN(m_fltPupilDiameterRight))
				p_objXmlWriter.WriteAttributeString("PUPILDIAMETERRIGHT",m_fltPupilDiameterRight.ToString("0.00"));
			if(!float.IsNaN(m_fltPupilDiameterLeft))
				p_objXmlWriter.WriteAttributeString("PUPILDIAMETERLEFT",m_fltPupilDiameterLeft.ToString("0.00"));
			p_objXmlWriter.WriteAttributeString("PUPILREFLECTIONRIGHT",m_strPupilReflectionRight.Replace('\'','き'));
			p_objXmlWriter.WriteAttributeString("PUPILREFLECTIONLEFT",m_strPupilReflectionLeft.Replace('\'','き'));
			
			m_objGlasgow.m_mthMakeXML(p_objXmlWriter);

			p_objXmlWriter.WriteAttributeString("OTHER",m_strOther.Replace('\'','き'));
		}

		public void m_mthSetValue(XmlTextReader p_objReader)
		{
			if(p_objReader.GetAttribute("TEMPERATURE") != DBNull.Value.ToString())
				m_fltTemperature = float.Parse(p_objReader.GetAttribute("TEMPERATURE"));
			else
				m_fltTemperature = float.NaN;
			if(p_objReader.GetAttribute("HEARTRATE") != DBNull.Value.ToString())
				m_fltHeartRate = float.Parse(p_objReader.GetAttribute("HEARTRATE"));
			else
				m_fltHeartRate = float.NaN;
			if(p_objReader.GetAttribute("PULSE") != DBNull.Value.ToString())
				m_fltPulse = float.Parse(p_objReader.GetAttribute("PULSE"));
			else
				m_fltPulse = float.NaN;
			if(p_objReader.GetAttribute("SYSTOLIC") != DBNull.Value.ToString())
				m_fltSystolic = float.Parse(p_objReader.GetAttribute("SYSTOLIC"));
			else
				m_fltSystolic = float.NaN;
			if(p_objReader.GetAttribute("DIASTOLIC") != DBNull.Value.ToString())
				m_fltDiastolic = float.Parse(p_objReader.GetAttribute("DIASTOLIC"));
			else
				m_fltDiastolic = float.NaN;
			m_strMind = p_objReader.GetAttribute("MIND").Replace ('き','\'');
			if(p_objReader.GetAttribute("PUPILDIAMETERRIGHT") != DBNull.Value.ToString())
				m_fltPupilDiameterRight = float.Parse(p_objReader.GetAttribute("PUPILDIAMETERRIGHT"));
			else
				m_fltPupilDiameterRight = float.NaN;
			if(p_objReader.GetAttribute("PUPILDIAMETERLEFT") != DBNull.Value.ToString())
				m_fltPupilDiameterLeft = float.Parse(p_objReader.GetAttribute("PUPILDIAMETERLEFT"));
			else
				m_fltPupilDiameterLeft = float.NaN;
			m_strPupilReflectionRight = p_objReader.GetAttribute("PUPILREFLECTIONRIGHT").Replace ('き','\'');
			m_strPupilReflectionLeft = p_objReader.GetAttribute("PUPILREFLECTIONLEFT").Replace ('き','\'');
						
			if(m_objGlasgow == null)
				m_objGlasgow = new clsPICUShiftGlasgow();

			m_objGlasgow.m_mthSetValue(p_objReader);

			m_strOther = p_objReader.GetAttribute("OTHER").Replace ('き','\'');
		}
	}

	[Serializable]
	public class clsPICUShiftGlasgow
	{
		public float m_fltValue;

		public float m_fltOpenEye;

		public float m_fltLanguage;

		public float m_fltSport;

		public void m_mthMakeXML(XmlTextWriter p_objXmlWriter)
		{
			if(!float.IsNaN(m_fltValue))
				p_objXmlWriter.WriteAttributeString("GLASGOWVALUE",m_fltValue.ToString("0.00"));
			if(!float.IsNaN(m_fltOpenEye))
				p_objXmlWriter.WriteAttributeString("GLASGOWOPENEYE",m_fltOpenEye.ToString("0.00"));
			if(!float.IsNaN(m_fltLanguage))
				p_objXmlWriter.WriteAttributeString("GLASGOWLANGUAGE",m_fltLanguage.ToString("0.00"));
			if(!float.IsNaN(m_fltSport))
				p_objXmlWriter.WriteAttributeString("GLASGOWSPORT",m_fltSport.ToString("0.00"));
		}

		public void m_mthSetValue(XmlTextReader p_objReader)
		{
			if(p_objReader.GetAttribute("GLASGOWVALUE") != DBNull.Value.ToString())
				m_fltValue = float.Parse(p_objReader.GetAttribute("GLASGOWVALUE"));
			else
				m_fltValue = float.NaN;
			if(p_objReader.GetAttribute("GLASGOWOPENEYE") != DBNull.Value.ToString())
				m_fltOpenEye = float.Parse(p_objReader.GetAttribute("GLASGOWOPENEYE"));
			else
				m_fltOpenEye = float.NaN;
			if(p_objReader.GetAttribute("GLASGOWLANGUAGE") != DBNull.Value.ToString())
				m_fltLanguage = float.Parse(p_objReader.GetAttribute("GLASGOWLANGUAGE"));
			else
				m_fltLanguage = float.NaN;
			if(p_objReader.GetAttribute("GLASGOWSPORT") != DBNull.Value.ToString())
				m_fltSport = float.Parse(p_objReader.GetAttribute("GLASGOWSPORT"));
			else
				m_fltSport = float.NaN;
		}
	}

	[Serializable]
	public class clsPICUShiftLabReportInfo
	{
		public float m_fltHB;

		public float m_fltRBC;

		public float m_fltWBC;

		public float m_fltPlt;

		public float m_fltLymphocyte;

		public float m_fltBandLeukocyte;

		public float m_fltDispartLeftLeukocyte;

		public float m_fltMonocyte;

		public float m_fltAcidophil;

		public float m_fltBasophil;

		public float m_fltBloodK;

		public float m_fltBloodNa;

		public float m_fltBloodCl;

		public float m_fltBloodSugar;

		public float m_fltBUN;

		public float m_fltBloodCa;

		public float m_fltPH;

		public float m_fltPaO2;

		public float m_fltPaCO2;

		public float m_fltBE;

		public float m_fltHCO3;

		public string m_strWoundInfo;

		public void m_mthMakeXML(XmlTextWriter p_objXmlWriter)
		{
			if(!float.IsNaN(m_fltHB))
				p_objXmlWriter.WriteAttributeString("HB",m_fltHB.ToString("0.00"));
			if(!float.IsNaN(m_fltRBC))
				p_objXmlWriter.WriteAttributeString("RBC",m_fltRBC.ToString("0.00"));
			if(!float.IsNaN(m_fltWBC))
				p_objXmlWriter.WriteAttributeString("WBC",m_fltWBC.ToString("0.00"));
			if(!float.IsNaN(m_fltPlt))
				p_objXmlWriter.WriteAttributeString("PLT",m_fltPlt.ToString("0.00"));
			if(!float.IsNaN(m_fltLymphocyte))
				p_objXmlWriter.WriteAttributeString("LYMPHOCYTE",m_fltLymphocyte.ToString("0.00"));
			if(!float.IsNaN(m_fltBandLeukocyte))
				p_objXmlWriter.WriteAttributeString("BANDLEUKOCYTE",m_fltBandLeukocyte.ToString("0.00"));
			if(!float.IsNaN(m_fltDispartLeftLeukocyte))
				p_objXmlWriter.WriteAttributeString("DISPARTLEFTLEUKOCYTE",m_fltDispartLeftLeukocyte.ToString("0.00"));
			if(!float.IsNaN(m_fltMonocyte))
				p_objXmlWriter.WriteAttributeString("MONOCYTE",m_fltMonocyte.ToString("0.00"));
			if(!float.IsNaN(m_fltAcidophil))
				p_objXmlWriter.WriteAttributeString("ACIDOPHIL",m_fltAcidophil.ToString("0.00"));
			if(!float.IsNaN(m_fltBasophil))
				p_objXmlWriter.WriteAttributeString("BASOPHIL",m_fltBasophil.ToString("0.00"));
			if(!float.IsNaN(m_fltBloodK))
				p_objXmlWriter.WriteAttributeString("BLOODK",m_fltBloodK.ToString("0.00"));
			if(!float.IsNaN(m_fltBloodNa))
				p_objXmlWriter.WriteAttributeString("BLOODNA",m_fltBloodNa.ToString("0.00"));
			if(!float.IsNaN(m_fltBloodCl))
				p_objXmlWriter.WriteAttributeString("BLOODCL",m_fltBloodCl.ToString("0.00"));
			if(!float.IsNaN(m_fltBloodSugar))
				p_objXmlWriter.WriteAttributeString("BLOODSUGAR",m_fltBloodCa.ToString("0.00"));
			if(!float.IsNaN(m_fltBUN))
				p_objXmlWriter.WriteAttributeString("BUN",m_fltBUN.ToString("0.00"));
			if(!float.IsNaN(m_fltBloodCa))
				p_objXmlWriter.WriteAttributeString("BLOODCA",m_fltBloodCa.ToString("0.00"));
			if(!float.IsNaN(m_fltPH))
				p_objXmlWriter.WriteAttributeString("PH",m_fltPH.ToString("0.00"));
			if(!float.IsNaN(m_fltPaO2))
				p_objXmlWriter.WriteAttributeString("PAO2",m_fltPaO2.ToString("0.00"));
			if(!float.IsNaN(m_fltPaCO2))
				p_objXmlWriter.WriteAttributeString("PACO2",m_fltPaCO2.ToString("0.00"));
			if(!float.IsNaN(m_fltBE))
				p_objXmlWriter.WriteAttributeString("BE",m_fltBE.ToString("0.00"));
			if(!float.IsNaN(m_fltHCO3))
				p_objXmlWriter.WriteAttributeString("HCO3",m_fltHCO3.ToString("0.00"));
			p_objXmlWriter.WriteAttributeString("WOUNDINFO",m_strWoundInfo.Replace('\'','き'));
		}

		public void m_mthSetValue(XmlTextReader p_objReader)
		{
			if(p_objReader.GetAttribute("HB") != DBNull.Value.ToString())
				m_fltHB = float.Parse(p_objReader.GetAttribute("HB"));
			else
				m_fltHB = float.NaN;
			if(p_objReader.GetAttribute("RBC") != DBNull.Value.ToString())
				m_fltRBC = float.Parse(p_objReader.GetAttribute("RBC"));
			else
				m_fltRBC = float.NaN;
			if(p_objReader.GetAttribute("WBC") != DBNull.Value.ToString())
				m_fltWBC = float.Parse(p_objReader.GetAttribute("WBC"));
			else
				m_fltWBC = float.NaN;
			if(p_objReader.GetAttribute("PLT") != DBNull.Value.ToString())
				m_fltPlt = float.Parse(p_objReader.GetAttribute("PLT"));
			else
				m_fltPlt = float.NaN;
			if(p_objReader.GetAttribute("LYMPHOCYTE") != DBNull.Value.ToString())
				m_fltLymphocyte = float.Parse(p_objReader.GetAttribute("LYMPHOCYTE"));
			else
				m_fltLymphocyte = float.NaN;
			if(p_objReader.GetAttribute("BANDLEUKOCYTE") != DBNull.Value.ToString())
				m_fltBandLeukocyte = float.Parse(p_objReader.GetAttribute("BANDLEUKOCYTE"));
			else
				m_fltBandLeukocyte = float.NaN;
			if(p_objReader.GetAttribute("DISPARTLEFTLEUKOCYTE") != DBNull.Value.ToString())
				m_fltDispartLeftLeukocyte = float.Parse(p_objReader.GetAttribute("DISPARTLEFTLEUKOCYTE"));
			else
				m_fltDispartLeftLeukocyte = float.NaN;
			if(p_objReader.GetAttribute("MONOCYTE") != DBNull.Value.ToString())
				m_fltMonocyte = float.Parse(p_objReader.GetAttribute("MONOCYTE"));
			else
				m_fltMonocyte = float.NaN;
			if(p_objReader.GetAttribute("ACIDOPHIL") != DBNull.Value.ToString())
				m_fltAcidophil = float.Parse(p_objReader.GetAttribute("ACIDOPHIL"));
			else
				m_fltAcidophil = float.NaN;
			if(p_objReader.GetAttribute("BASOPHIL") != DBNull.Value.ToString())
				m_fltBasophil = float.Parse(p_objReader.GetAttribute("BASOPHIL"));
			else
				m_fltBasophil = float.NaN;
			if(p_objReader.GetAttribute("BLOODK") != DBNull.Value.ToString())
				m_fltBloodK = float.Parse(p_objReader.GetAttribute("BLOODK"));
			else
				m_fltBloodK = float.NaN;
			if(p_objReader.GetAttribute("BLOODNA") != DBNull.Value.ToString())
				m_fltBloodNa = float.Parse(p_objReader.GetAttribute("BLOODNA"));
			else
				m_fltBloodNa = float.NaN;
			if(p_objReader.GetAttribute("BLOODCL") != DBNull.Value.ToString())
				m_fltBloodCl = float.Parse(p_objReader.GetAttribute("BLOODCL"));
			else
				m_fltBloodCl = float.NaN;
			if(p_objReader.GetAttribute("BLOODSUGAR") != DBNull.Value.ToString())
				m_fltBloodSugar = float.Parse(p_objReader.GetAttribute("BLOODSUGAR"));
			else
				m_fltBloodSugar = float.NaN;
			if(p_objReader.GetAttribute("BUN") != DBNull.Value.ToString())
				m_fltBUN = float.Parse(p_objReader.GetAttribute("BUN"));
			else
				m_fltBUN = float.NaN;
			if(p_objReader.GetAttribute("BLOODCA") != DBNull.Value.ToString())
				m_fltBloodCa = float.Parse(p_objReader.GetAttribute("BLOODCA"));
			else
				m_fltBloodCa = float.NaN;
			if(p_objReader.GetAttribute("PH") != DBNull.Value.ToString())
				m_fltPH = float.Parse(p_objReader.GetAttribute("PH"));
			else
				m_fltPH = float.NaN;
			if(p_objReader.GetAttribute("PAO2") != DBNull.Value.ToString())
				m_fltPaO2 = float.Parse(p_objReader.GetAttribute("PAO2"));
			else
				m_fltPaO2 = float.NaN;
			if(p_objReader.GetAttribute("PACO2") != DBNull.Value.ToString())
				m_fltPaCO2 = float.Parse(p_objReader.GetAttribute("PACO2"));
			else
				m_fltPaCO2 = float.NaN;
			if(p_objReader.GetAttribute("BE") != DBNull.Value.ToString())
				m_fltBE = float.Parse(p_objReader.GetAttribute("BE"));
			else
				m_fltBE = float.NaN;
			if(p_objReader.GetAttribute("HCO3") != DBNull.Value.ToString())
				m_fltHCO3 = float.Parse(p_objReader.GetAttribute("HCO3"));
			else
				m_fltHCO3 = float.NaN;
			m_strWoundInfo = p_objReader.GetAttribute("WOUNDINFO").Replace ('き','\'');
		}
	}
	#endregion
}
