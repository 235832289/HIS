using System;
using System.IO ;
using System .Xml ;
using iCareData;
using com.digitalwave.OperationEquipmentQtyService;


namespace iCare
{
	/// <summary>
	/// Summary description for clsOperationEqipmentQtyDomain.
	/// </summary>
	public class clsOperationEqipmentQtyDomain
	{
		/// <summary>
		/// 汜傖Xml腔遣喳
		/// </summary>
		private MemoryStream m_objXmlMemStream;

		/// <summary>
		/// 汜傖Xml腔馱撿
		/// </summary>
	
		private XmlTextWriter m_objXmlWriter;
		///  <summary>
		/// 黍�—ml馱撿怀�貒恀�		
		/// </summary>
		private XmlParserContext m_objXmlParser;
        //private com.digitalwave.OperationEquipmentQtyService.clsOperationEquipmentQtyService  m_objServ;
		
		public clsOperationEqipmentQtyDomain()
		{
			//
			// TODO: Add constructor logic here
			//
            //m_objServ=new com.digitalwave.OperationEquipmentQtyService.clsOperationEquipmentQtyService ();
			m_objXmlMemStream = new MemoryStream(300);

			m_objXmlWriter = new XmlTextWriter(m_objXmlMemStream,System.Text.Encoding.Unicode);
			m_objXmlWriter.Flush();//ь諾埻懂腔趼睫
			m_objXmlParser = new XmlParserContext(null,null,null,XmlSpace.None,System.Text.Encoding.Unicode);
		}

		/// <summary>
		/// 氝樓陔暮翹
		/// </summary>
		/// <param name="objOperationEquipmentPackage"></param>
		/// <returns></returns>
		public long lngAddNewRecord(clsOperationEquipmentPackage objOperationEquipmentPackage)
		{
			if(objOperationEquipmentPackage==null ||objOperationEquipmentPackage.m_objOperationEqipmentQtyContent ==null
				 ||objOperationEquipmentPackage.m_objOperationEqipmentQtyXML==null)
				return -1;

			string  strMasterXML ;
			string  strSubXML ;
			string [] strNurseXML;

			//ぐ翋桶XML
			strMasterXML= m_strGetMasterXMLInsert(objOperationEquipmentPackage.m_objOperationEqipmentQtyXML,true);
			
			//ぐ赽桶XML
			strSubXML= m_strGetContentXML( objOperationEquipmentPackage.m_objOperationEqipmentQtyContent);
			
			//ぐ誘尪XML
			if(objOperationEquipmentPackage.m_objOperationNurse!=null)
			{
				strNurseXML=new string[objOperationEquipmentPackage.m_objOperationNurse.Length]; 
				for(int i=0;i<objOperationEquipmentPackage.m_objOperationNurse.Length ;i++ )
				{
					strNurseXML[i]=	m_strGetNurseXML(objOperationEquipmentPackage.m_objOperationNurse[i]);
				}
			}
			else
				strNurseXML=null;
            long lngSucceed = 0;

            com.digitalwave.OperationEquipmentQtyService.clsOperationEquipmentQtyService m_objServ =
                (com.digitalwave.OperationEquipmentQtyService.clsOperationEquipmentQtyService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.OperationEquipmentQtyService.clsOperationEquipmentQtyService));

            try
            {
                lngSucceed = m_objServ.m_lngAddNewRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, strMasterXML, strSubXML, strNurseXML);
            }
            finally
            {
                //m_objServ.Dispose();
            }
			return lngSucceed; 
		}

		/// <summary>
		/// 党蜊暮翹
		/// </summary>
		/// <param name="objOperationEquipmentPackage"></param>
		/// <param name="strInPatientID"></param>
		/// <param name="strInPatientDate"></param>
		/// <param name="strOpenDate"></param>
		/// <returns></returns>
		public long lngModify(clsOperationEquipmentPackage objOperationEquipmentPackage,string strInPatientID, string strInPatientDate,string strOpenDate)
		{
			if(objOperationEquipmentPackage==null ||objOperationEquipmentPackage.m_objOperationEqipmentQtyContent ==null
				||objOperationEquipmentPackage.m_objOperationEqipmentQtyXML==null)
				return -1;

			string  strMasterXML ;
			string  strSubXML ;
			string [] strNurseXML;

			//ぐ翋桶XML
			strMasterXML = m_strGetMasterXMLInsert(objOperationEquipmentPackage.m_objOperationEqipmentQtyXML,false);
			
			//ぐ赽桶XML
			strSubXML= m_strGetContentXML( objOperationEquipmentPackage.m_objOperationEqipmentQtyContent);
			
			//ぐ誘尪XML
			if(objOperationEquipmentPackage.m_objOperationNurse!=null)
			{
				strNurseXML=new string[objOperationEquipmentPackage.m_objOperationNurse.Length]; 
				for(int i=0;i<objOperationEquipmentPackage.m_objOperationNurse.Length ;i++ )
				{
					strNurseXML[i]=	m_strGetNurseXML(objOperationEquipmentPackage.m_objOperationNurse[i]);
				}
			}
			else
				strNurseXML=null;
			
			long lngSucceed = 0;

            com.digitalwave.OperationEquipmentQtyService.clsOperationEquipmentQtyService m_objServ =
                (com.digitalwave.OperationEquipmentQtyService.clsOperationEquipmentQtyService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.OperationEquipmentQtyService.clsOperationEquipmentQtyService));

            try
            {
                lngSucceed =m_objServ.lngModify(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,strMasterXML,strSubXML,strNurseXML,strInPatientID,strInPatientDate,strOpenDate);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngSucceed;  
		}
	
		
		
		#region ぐ翋桶XML
		/// <summary>
		/// ぐ翋桶XML
		/// </summary>
		/// <param name="objGeneralTendRecordInfo"></param>
		/// <returns></returns>
		private string m_strGetMasterXMLInsert(clsOperationEqipmentQtyXML objclsOperationEqipmentQtyXMLInsert,bool bolIfSave)
		{
			m_objXmlMemStream.SetLength(0);
			
			m_objXmlWriter.WriteStartDocument();
			m_objXmlWriter.WriteStartElement("RecordMaster");
			
			if(bolIfSave==true)
			{
				m_objXmlWriter.WriteAttributeString("STATUS", objclsOperationEqipmentQtyXMLInsert.strStatus);
				m_objXmlWriter.WriteAttributeString("IFCONFIRM", objclsOperationEqipmentQtyXMLInsert.strIfConfirm);
			}

			m_objXmlWriter.WriteAttributeString("INPATIENTID", objclsOperationEqipmentQtyXMLInsert.strInPatientID);
			m_objXmlWriter.WriteAttributeString("INPATIENTDATE", objclsOperationEqipmentQtyXMLInsert.strInPatientDate);
			m_objXmlWriter.WriteAttributeString("OPENDATE", objclsOperationEqipmentQtyXMLInsert.strOpenDate);
			
			m_objXmlWriter.WriteAttributeString("CREATEDATE", objclsOperationEqipmentQtyXMLInsert.strCreateDate);
			m_objXmlWriter.WriteAttributeString("CREATEUSERID", objclsOperationEqipmentQtyXMLInsert.strCreateUserID);
				
//			m_objXmlWriter.WriteAttributeString("DEACTIVEDDATE", objclsOperationEqipmentQtyXML.strDeActivedDate.Replace('\'','五'));
//			m_objXmlWriter.WriteAttributeString("DEACTIVEDOPERATORID", objclsOperationEqipmentQtyXML.strDeActivedOperatorID.Replace('\'','五'));
//			m_objXmlWriter.WriteAttributeString("CONFIRMREASON", objclsOperationEqipmentQtyXML.strConfirmReason.Replace('\'','五'));
//			m_objXmlWriter.WriteAttributeString("CONFIRMREASONXML", objclsOperationEqipmentQtyXML.strConfirmReasonXML.Replace('\'','五'));
//			m_objXmlWriter.WriteAttributeString("OPERATIONIDXML", objclsOperationEqipmentQtyXML.strOperationIDXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("OPERATIONNAMEXML", objclsOperationEqipmentQtyXMLInsert.strOperationNameXML.Replace('\'','五'));
			
			m_objXmlWriter.WriteAttributeString("WENZHI125XML", objclsOperationEqipmentQtyXMLInsert.strWenZhi125XML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WENZHI125AFTERXML", objclsOperationEqipmentQtyXMLInsert.strWenZhi125AfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WENZHI125BEFOREXML", objclsOperationEqipmentQtyXMLInsert.strWenZhi125BeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("WENWAN125XML", objclsOperationEqipmentQtyXMLInsert.strWenWan125XML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WENWAN125AFTERXML", objclsOperationEqipmentQtyXMLInsert.strWenWan125AfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WENWAN125BEFOREXML", objclsOperationEqipmentQtyXMLInsert.strWenWan125BeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("XIAOZHI14XML", objclsOperationEqipmentQtyXMLInsert.strXiaoZhi14XML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("XIAOZHI14AFTERXML", objclsOperationEqipmentQtyXMLInsert.strXiaoZhi14AfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("XIAOZHI14BEFOREXML", objclsOperationEqipmentQtyXMLInsert.strXiaoZhi14BeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("XIAOWAN14XML", objclsOperationEqipmentQtyXMLInsert.strXiaoWan14XML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("XIAOWAN14AFTERXML", objclsOperationEqipmentQtyXMLInsert.strXiaoWan14AfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("XIAOWAN14BEFOREXML", objclsOperationEqipmentQtyXMLInsert.strXiaoWan14BeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("ZHONGZHI16XML", objclsOperationEqipmentQtyXMLInsert.strZhongZhi16XML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHONGZHI16AFTERXML", objclsOperationEqipmentQtyXMLInsert.strZhongZhi16AfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHONGZHI16BEFOREXML", objclsOperationEqipmentQtyXMLInsert.strZhongZhi16BeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("ZHONGWAN16XML", objclsOperationEqipmentQtyXMLInsert.strZhongWan16XML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHONGWAN16AFTERXML", objclsOperationEqipmentQtyXMLInsert.strZhongWan16AfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHONGWAN16BEFOREXML", objclsOperationEqipmentQtyXMLInsert.strZhongWan16BeforeXML.Replace('\'','五'));
						
			
			m_objXmlWriter.WriteAttributeString("PIQIANXML", objclsOperationEqipmentQtyXMLInsert.strPiQianXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("PIQIANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strPiQianAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("PIQIANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strPiQianBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("ZHIYOUCHIXUEGUANQIANXML", objclsOperationEqipmentQtyXMLInsert.strZhiYouChiXueGuanQianXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHIYOUCHIXUEGUANQIANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strZhiYouChiXueGuanQianAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHIYOUCHIXUEGUANQIANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strZhiYouChiXueGuanQianBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("QUANQIANXML", objclsOperationEqipmentQtyXMLInsert.strQuanQianXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("QUANQIANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strQuanQianAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("QUANQIANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strQuanQianBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("JINQIANXML", objclsOperationEqipmentQtyXMLInsert.strJinQianXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("JINQIANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strJinQianAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("JINQIANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strJinQianBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("CHIZHENQIAN18XML", objclsOperationEqipmentQtyXMLInsert.strChiZhenQian18XML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("CHIZHENQIAN18AFTERXML", objclsOperationEqipmentQtyXMLInsert.strChiZhenQian18AfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("CHIZHENQIAN18BEFOREXML", objclsOperationEqipmentQtyXMLInsert.strChiZhenQian18BeforeXML.Replace('\'','五'));

			
			
			m_objXmlWriter.WriteAttributeString("YOUCHINIEXML", objclsOperationEqipmentQtyXMLInsert.strYouChiNieXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("YOUCHINIEAFTERXML", objclsOperationEqipmentQtyXMLInsert.strYouChiNieAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("YOUCHINIEBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strYouChiNieBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("WUCHINIEXML", objclsOperationEqipmentQtyXMLInsert.strWuChiNieXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WUCHINIEAFTERXML", objclsOperationEqipmentQtyXMLInsert.strWuChiNieAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WUCHINIEBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strWuChiNieBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("CHANGYABANXML", objclsOperationEqipmentQtyXMLInsert.strChangYaBanXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("CHANGYABANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strChangYaBanAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("CHANGYABANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strChangYaBanBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("DAOBING3XML", objclsOperationEqipmentQtyXMLInsert.strDaoBing3XML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DAOBING3AFTERXML", objclsOperationEqipmentQtyXMLInsert.strDaoBing3AfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DAOBING3BEFOREXML", objclsOperationEqipmentQtyXMLInsert.strDaoBing3BeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("DAOBING4XML", objclsOperationEqipmentQtyXMLInsert.strDaoBing4XML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DAOBING4AFTERXML", objclsOperationEqipmentQtyXMLInsert.strDaoBing4AfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DAOBING4BEFOREXML", objclsOperationEqipmentQtyXMLInsert.strDaoBing4BeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("DAOBING7XML", objclsOperationEqipmentQtyXMLInsert.strDaoBing7XML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DAOBING7AFTERXML", objclsOperationEqipmentQtyXMLInsert.strDaoBing7AfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DAOBING7BEFOREXML", objclsOperationEqipmentQtyXMLInsert.strDaoBing7BeforeXML.Replace('\'','五'));

			
			m_objXmlWriter.WriteAttributeString("WANZHUZHIJIANXML", objclsOperationEqipmentQtyXMLInsert.strWanZhuZhiJianXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WANZHUZHIJIANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strWanZhuZhiJianAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WANZHUZHIJIANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strWanZhuZhiJianBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("ZHIZHUZHIJIANXML", objclsOperationEqipmentQtyXMLInsert.strZhiZhuZhiJianXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHIZHUZHIJIANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strZhiZhuZhiJianAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHIZHUZHIJIANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strZhiZhuZhiJianBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("BIANTAOXIANJIANXML", objclsOperationEqipmentQtyXMLInsert.strBianTaoXianJianXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("BIANTAOXIANJIANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strBianTaoXianJianAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("BIANTAOXIANJIANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strBianTaoXianJianBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("XIONGQIANGJIANXML", objclsOperationEqipmentQtyXMLInsert.strXiongQiangJianXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("XIONGQIANGJIANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strXiongQiangJianAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("XIONGQIANGJIANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strXiongQiangJianBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("ZHIJIAOXIAOLAGOUXML", objclsOperationEqipmentQtyXMLInsert.strZhiJiaoXiaoLaGouXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHIJIAOXIAOLAGOUAFTERXML", objclsOperationEqipmentQtyXMLInsert.strZhiJiaoXiaoLaGouAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHIJIAOXIAOLAGOUBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strZhiJiaoXiaoLaGouBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("LANWEILAGOUXML", objclsOperationEqipmentQtyXMLInsert.strLanWeiLaGouXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("LANWEILAGOUAFTERXML", objclsOperationEqipmentQtyXMLInsert.strLanWeiLaGouAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("LANWEILAGOUBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strLanWeiLaGouBeforeXML.Replace('\'','五'));

			
			m_objXmlWriter.WriteAttributeString("ZHONGFUGOUXML", objclsOperationEqipmentQtyXMLInsert.strZhongFuGouXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHONGFUGOUAFTERXML", objclsOperationEqipmentQtyXMLInsert.strZhongFuGouAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHONGFUGOUBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strZhongFuGouBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("CHANGYAGOUXML", objclsOperationEqipmentQtyXMLInsert.strChangYaGouXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("CHANGYAGOUAFTERXML", objclsOperationEqipmentQtyXMLInsert.strChangYaGouAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("CHANGYAGOUBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strChangYaGouBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("ZHIJIAOGOUXML", objclsOperationEqipmentQtyXMLInsert.strZhiJiaoGouXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHIJIAOGOUAFTERXML", objclsOperationEqipmentQtyXMLInsert.strZhiJiaoGouAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHIJIAOGOUBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strZhiJiaoGouBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("XIAFUBUQIANKAIQIXML", objclsOperationEqipmentQtyXMLInsert.strXiaFuBuQianKaiQiXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("XIAFUBUQIANKAIQIAFTERXML", objclsOperationEqipmentQtyXMLInsert.strXiaFuBuQianKaiQiAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("XIAFUBUQIANKAIQIBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strXiaFuBuQianKaiQiBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("TONGQUANXML", objclsOperationEqipmentQtyXMLInsert.strTongQuanXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("TONGQUANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strTongQuanAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("TONGQUANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strTongQuanBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("XIYEGUANXML", objclsOperationEqipmentQtyXMLInsert.strXiYeGuanXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("XIYEGUANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strXiYeGuanAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("XIYEGUANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strXiYeGuanBeforeXML.Replace('\'','五'));

			
			
			m_objXmlWriter.WriteAttributeString("WANXUEGUANQIAN18XML", objclsOperationEqipmentQtyXMLInsert.strWanXueGuanQian18XML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WANXUEGUANQIAN18AFTERXML", objclsOperationEqipmentQtyXMLInsert.strWanXueGuanQian18AfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WANXUEGUANQIAN18BEFOREXML", objclsOperationEqipmentQtyXMLInsert.strWanXueGuanQian18BeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("WANXUEGUANQIAN20XML", objclsOperationEqipmentQtyXMLInsert.strWanXueGuanQian20XML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WANXUEGUANQIAN20AFTERXML", objclsOperationEqipmentQtyXMLInsert.strWanXueGuanQian20AfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WANXUEGUANQIAN20BEFOREXML", objclsOperationEqipmentQtyXMLInsert.strWanXueGuanQian20BeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("WANXUEGUANQIAN22XML", objclsOperationEqipmentQtyXMLInsert.strWanXueGuanQian22XML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WANXUEGUANQIAN22AFTERXML", objclsOperationEqipmentQtyXMLInsert.strWanXueGuanQian22AfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WANXUEGUANQIAN22BEFOREXML", objclsOperationEqipmentQtyXMLInsert.strWanXueGuanQian22BeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("NIANMOQIANXML", objclsOperationEqipmentQtyXMLInsert.strNianMoQianXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("NIANMOQIANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strNianMoQianAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("NIANMOQIANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strNianMoQianBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("SHALIQIANXML", objclsOperationEqipmentQtyXMLInsert.strShaLiQianXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("SHALIQIANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strShaLiQianAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("SHALIQIANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strShaLiQianBeforeXML.Replace('\'','五'));

			
			m_objXmlWriter.WriteAttributeString("FENGZHENXML", objclsOperationEqipmentQtyXMLInsert.strFengZhenXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("FENGZHENAFTERXML", objclsOperationEqipmentQtyXMLInsert.strFengZhenAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("FENGZHENBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strFengZhenBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("DAOPIANXML", objclsOperationEqipmentQtyXMLInsert.strDaoPianXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DAOPIANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strDaoPianAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DAOPIANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strDaoPianBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("CHANGCHIZHENQIAN25XML", objclsOperationEqipmentQtyXMLInsert.strChangChiZhenQian25XML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("CHANGCHIZHENQIAN25AFTERXML", objclsOperationEqipmentQtyXMLInsert.strChangChiZhenQian25AfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("CHANGCHIZHENQIAN25BEFOREXML", objclsOperationEqipmentQtyXMLInsert.strChangChiZhenQian25BeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("ZHIJIAOQIANXML", objclsOperationEqipmentQtyXMLInsert.strZhiJiaoQianXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHIJIAOQIANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strZhiJiaoQianAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHIJIAOQIANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strZhiJiaoQianBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("DAZHIQIANXML", objclsOperationEqipmentQtyXMLInsert.strDaZhiQianXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DAZHIQIANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strDaZhiQianAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DAZHIQIANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strDaZhiQianBeforeXML.Replace('\'','五'));

			
			m_objXmlWriter.WriteAttributeString("WANXUEGUANQIAN25XML", objclsOperationEqipmentQtyXMLInsert.strWanXueGuanQian25XML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WANXUEGUANQIAN25AFTERXML", objclsOperationEqipmentQtyXMLInsert.strWanXueGuanQian25AfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WANXUEGUANQIAN25BEFOREXML", objclsOperationEqipmentQtyXMLInsert.strWanXueGuanQian25BeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("DAWANXUEGUANQIANXML", objclsOperationEqipmentQtyXMLInsert.strDaWanXueGuanQianXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DAWANXUEGUANQIANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strDaWanXueGuanQianAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DAWANXUEGUANQIANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strDaWanXueGuanQianBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("SHENDIQIANXML", objclsOperationEqipmentQtyXMLInsert.strShenDiQianXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("SHENDIQIANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strShenDiQianAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("SHENDIQIANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strShenDiQianBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("CHANGQIANZHIXML", objclsOperationEqipmentQtyXMLInsert.strChangQianZhiXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("CHANGQIANZHIAFTERXML", objclsOperationEqipmentQtyXMLInsert.strChangQianZhiAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("CHANGQIANZHIBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strChangQianZhiBeforeXML.Replace('\'','五'));

			
			m_objXmlWriter.WriteAttributeString("CHANGQIANWANXML", objclsOperationEqipmentQtyXMLInsert.strChangQianWanXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("CHANGQIANWANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strChangQianWanAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("CHANGQIANWANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strChangQianWanBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("SHIQIANXML", objclsOperationEqipmentQtyXMLInsert.strShiQianXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("SHIQIANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strShiQianAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("SHIQIANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strShiQianBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("WEIQIANXML", objclsOperationEqipmentQtyXMLInsert.strWeiQianXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WEIQIANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strWeiQianAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WEIQIANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strWeiQianBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("XINERQIANXML", objclsOperationEqipmentQtyXMLInsert.strXinErQianXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("XINERQIANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strXinErQiaAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("XINERQIANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strXinErQiaBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("ERYANHOUCHONGXIQIXML", objclsOperationEqipmentQtyXMLInsert.strErYanHouChongXiQiXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ERYANHOUCHONGXIQIAFTERXML", objclsOperationEqipmentQtyXMLInsert.strErYanHouChongXiQiAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ERYANHOUCHONGXIQIBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strErYanHouChongXiQiBeforeXML.Replace('\'','五'));

			
			m_objXmlWriter.WriteAttributeString("TANZHENCHUXML", objclsOperationEqipmentQtyXMLInsert.strTanZhenChuXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("TANZHENCHUAFTERXML", objclsOperationEqipmentQtyXMLInsert.strTanZhenChuAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("TANZHENCHUBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strTanZhenChuBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("TANZHENXIXML", objclsOperationEqipmentQtyXMLInsert.strTanZhenXiXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("TANZHENXIAFTERXML", objclsOperationEqipmentQtyXMLInsert.strTanZhenXiAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("TANZHENXIBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strTanZhenXiBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("DANDAOTANTIAOXML", objclsOperationEqipmentQtyXMLInsert.strDanDaoTanTiaoXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DANDAOTANTIAOAFTERXML", objclsOperationEqipmentQtyXMLInsert.strDanDaoTanTiaoAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DANDAOTANTIAOBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strDanDaoTanTiaoBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("LEIGUQIANKAIQIXML", objclsOperationEqipmentQtyXMLInsert.strLeiGuQianKaiQiXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("LEIGUQIANKAIQIAFTERXML", objclsOperationEqipmentQtyXMLInsert.strLeiGuQianKaiQiAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("LEIGUQIANKAIQIBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strLeiGuQianKaiQiBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("HELONGQIXML", objclsOperationEqipmentQtyXMLInsert.strHeLongQiXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("HELONGQIAFTERXML", objclsOperationEqipmentQtyXMLInsert.strHeLongQiAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("HELONGQIBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strHeLongQiBeforeXML.Replace('\'','五'));

			
			m_objXmlWriter.WriteAttributeString("JIANJIAGULAGOUXML", objclsOperationEqipmentQtyXMLInsert.strJianJiaGuLaGouXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("JIANJIAGULAGOUAFTERXML", objclsOperationEqipmentQtyXMLInsert.strJianJiaGuLaGouAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("JIANJIAGULAGOUBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strJianJiaGuLaGouBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("LEIGUQIZIXML", objclsOperationEqipmentQtyXMLInsert.strLeiGuQiZiXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("LEIGUQIZIAFTERXML", objclsOperationEqipmentQtyXMLInsert.strLeiGuQiZiAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("LEIGUQIZIBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strLeiGuQiZiBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("DAGUJIANXML", objclsOperationEqipmentQtyXMLInsert.strDaGuJianXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DAGUJIANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strDaGuJianAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DAGUJIANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strDaGuJianBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("DIERLEIGUJIANXML", objclsOperationEqipmentQtyXMLInsert.strDiErLeiGuJianXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DIERLEIGUJIANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strDiErLeiGuJianAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DIERLEIGUJIANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strDiErLeiGuJianBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("FANGTOUYAOGUQIANXML", objclsOperationEqipmentQtyXMLInsert.strFangTouYaoGuQianXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("FANGTOUYAOGUQIANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strFangTouYaoGuQianAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("FANGTOUYAOGUQIANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strFangTouYaoGuQianBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("YAOGUQIANXML", objclsOperationEqipmentQtyXMLInsert.strYaoGuQianXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("YAOGUQIANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strYaoGuQianAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("YAOGUQIANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strYaoGuQianBeforeXML.Replace('\'','五'));

			
			m_objXmlWriter.WriteAttributeString("GUMOBOLIQIXML", objclsOperationEqipmentQtyXMLInsert.strGuMoBoLiQiXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("GUMOBOLIQIAFTERXML", objclsOperationEqipmentQtyXMLInsert.strGuMoBoLiQiAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("GUMOBOLIQIBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strGuMoBoLiQiBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("GUDAOXML", objclsOperationEqipmentQtyXMLInsert.strGuDaoXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("GUDAOAFTERXML", objclsOperationEqipmentQtyXMLInsert.strGuDaoAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("GUDAOBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strGuDaoBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("GUZAOXML", objclsOperationEqipmentQtyXMLInsert.strGuZaoXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("GUZAOAFTERXML", objclsOperationEqipmentQtyXMLInsert.strGuZaoAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("GUZAOBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strGuZaoBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("KUOSHIXML", objclsOperationEqipmentQtyXMLInsert.strKuoShiXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("KUOSHIAFTERXML", objclsOperationEqipmentQtyXMLInsert.strKuoShiAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("KUOSHIBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strKuoShiBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("GUCHUIXML", objclsOperationEqipmentQtyXMLInsert.strGuChuiXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("GUCHUIAFTERXML", objclsOperationEqipmentQtyXMLInsert.strGuChuiAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("GUCHUIBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strGuChuiBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("CHIGUQIANXML", objclsOperationEqipmentQtyXMLInsert.strChiGuQianXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("CHIGUQIANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strChiGuQianAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("CHIGUQIANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strChiGuQianBeforeXML.Replace('\'','五'));

			
			m_objXmlWriter.WriteAttributeString("JINGGUQIZIXML", objclsOperationEqipmentQtyXMLInsert.strJingGuQiZiXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("JINGGUQIZIAFTERXML", objclsOperationEqipmentQtyXMLInsert.strJingGuQiZiAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("JINGGUQIZIBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strJingGuQiZiBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("DANCHILAGOUXML", objclsOperationEqipmentQtyXMLInsert.strDanChiLaGouXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DANCHILAGOUAFTERXML", objclsOperationEqipmentQtyXMLInsert.strDanChiLaGouAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DANCHILAGOUBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strDanChiLaGouBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("LAOHUQIANXML", objclsOperationEqipmentQtyXMLInsert.strLaoHuQianXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("LAOHUQIANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strLaoHuQianAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("LAOHUQIANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strLaoHuQianBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("PINGHENGFUWEIQIANXML", objclsOperationEqipmentQtyXMLInsert.strPingHengFuWeiQianXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("PINGHENGFUWEIQIANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strPingHengFuWeiQianAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("PINGHENGFUWEIQIANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strPingHengFuWeiQianBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("LUOSIQIZIXML", objclsOperationEqipmentQtyXMLInsert.strLuoSiQiZiXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("LUOSIQIZIAFTERXML", objclsOperationEqipmentQtyXMLInsert.strLuoSiQiZiAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("LUOSIQIZIBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strLuoSiQiZiBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("DAOXIANGQIXML", objclsOperationEqipmentQtyXMLInsert.strDaoXiangQiXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DAOXIANGQIAFTERXML", objclsOperationEqipmentQtyXMLInsert.strDaoXiangQiAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DAOXIANGQIBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strDaoXiangQiBeforeXML.Replace('\'','五'));


			
			m_objXmlWriter.WriteAttributeString("ZHUIBANYAOGUQIANXML", objclsOperationEqipmentQtyXMLInsert.strZhuiBanYaoGuQianXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHUIBANYAOGUQIANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strZhuiBanYaoGuQianAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHUIBANYAOGUQIANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strZhuiBanYaoGuQianBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("SHUIHEQIANXML", objclsOperationEqipmentQtyXMLInsert.strShuiHeQianXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("SHUIHEQIANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strShuiHeQianAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("SHUIHEQIANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strShuiHeQianBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("JINGTUJIANXML", objclsOperationEqipmentQtyXMLInsert.strJingTuJianXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("JINGTUJIANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strJingTuJianAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("JINGTUJIANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strJingTuJianBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("ZHUIBANBOLIQIXML", objclsOperationEqipmentQtyXMLInsert.strZhuiBanBoLiQiXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHUIBANBOLIQIAFTERXML", objclsOperationEqipmentQtyXMLInsert.strZhuiBanBoLiQiAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHUIBANBOLIQIBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strZhuiBanBoLiQiBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("JIANBOLIZIXML", objclsOperationEqipmentQtyXMLInsert.strJianBoLiZiXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("JIANBOLIZIAFTERXML", objclsOperationEqipmentQtyXMLInsert.strJianBoLiZiAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("JIANBOLIZIBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strJianBoLiZiBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("QIANGZHUANGNIEXML", objclsOperationEqipmentQtyXMLInsert.strQiangZhuangNieXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("QIANGZHUANGNIEAFTERXML", objclsOperationEqipmentQtyXMLInsert.strQiangZhuangNieAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("QIANGZHUANGNIEBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strQiangZhuangNieBeforeXML.Replace('\'','五'));


			
			m_objXmlWriter.WriteAttributeString("BAISHIQIANKAIQIXML", objclsOperationEqipmentQtyXMLInsert.strBaiShiQianKaiQiXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("BAISHIQIANKAIQIAFTERXML", objclsOperationEqipmentQtyXMLInsert.strBaiShiQianKaiQiAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("BAISHIQIANKAIQIBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strBaiShiQianKaiQiBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("KAILUZHUANXML", objclsOperationEqipmentQtyXMLInsert.strKaiLuZhuanXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("KAILUZHUANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strKaiLuZhuanAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("KAILUZHUANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strKaiLuZhuanBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("TOUPIJIANQIANXML", objclsOperationEqipmentQtyXMLInsert.strTouPiJianQianXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("TOUPIJIANQIANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strTouPiJianQianAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("TOUPIJIANQIANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strTouPiJianQianBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("XIANJUDAOYINZIXML", objclsOperationEqipmentQtyXMLInsert.strXianJuDaoYinZiXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("XIANJUDAOYINZIAFTERXML", objclsOperationEqipmentQtyXMLInsert.strXianJuDaoYinZiAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("XIANJUDAOYINZIBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strXianJuDaoYinZiBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("XINERLAGOUXML", objclsOperationEqipmentQtyXMLInsert.strXinErLaGouXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("XINERLAGOUAFTERXML", objclsOperationEqipmentQtyXMLInsert.strXinErLaGouAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("XINERLAGOUBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strXinErLaGouBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("CHIBANQIANXML", objclsOperationEqipmentQtyXMLInsert.strChiBanQianXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("CHIBANQIANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strChiBanQianAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("CHIBANQIANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strChiBanQianBeforeXML.Replace('\'','五'));

			
			m_objXmlWriter.WriteAttributeString("XINFANGLAGOUXML", objclsOperationEqipmentQtyXMLInsert.strXinFangLaGouXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("XINFANGLAGOUAFTERXML", objclsOperationEqipmentQtyXMLInsert.strXinFangLaGouAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("XINFANGLAGOUBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strXinFangLaGouBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("NAOMOGOUXML", objclsOperationEqipmentQtyXMLInsert.strNaoMoGouXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("NAOMOGOUAFTERXML", objclsOperationEqipmentQtyXMLInsert.strNaoMoGouAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("NAOMOGOUBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strNaoMoGouBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("CHUANCIZHENXML", objclsOperationEqipmentQtyXMLInsert.strChuanCiZhenXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("CHUANCIZHENAFTERXML", objclsOperationEqipmentQtyXMLInsert.strChuanCiZhenAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("CHUANCIZHENBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strChuanCiZhenBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("YINDINGQIANXML", objclsOperationEqipmentQtyXMLInsert.strYinDingQianXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("YINDINGQIANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strYinDingQianAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("YINDINGQIANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strYinDingQianBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("FEIYEDANGBANXML", objclsOperationEqipmentQtyXMLInsert.strFeiYeDangBanXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("FEIYEDANGBANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strFeiYeDangBanAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("FEIYEDANGBANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strFeiYeDangBanBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("ZHUAZHUDUANQIANXML", objclsOperationEqipmentQtyXMLInsert.strZhuAZhuDuanQianXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHUAZHUDUANQIANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strZhuAZhuDuanQianAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHUAZHUDUANQIANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strZhuAZhuDuanQianBeforeXML.Replace('\'','五'));

			
			
			m_objXmlWriter.WriteAttributeString("ZHUAYOULIQIANXML", objclsOperationEqipmentQtyXMLInsert.strZhuAYouLiQianXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHUAYOULIQIANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strZhuAYouLiQianAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHUAYOULIQIANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strZhuAYouLiQianBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("ZHUACEBIQIANXML", objclsOperationEqipmentQtyXMLInsert.strZhuACeBiQianXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHUACEBIQIANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strZhuAYouLiQianAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHUACEBIQIANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strZhuACeBiQiBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("ERJIANBANKUOZHANGQIXML", objclsOperationEqipmentQtyXMLInsert.strErJianBanKuoZhangQiXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ERJIANBANKUOZHANGQIAFTERXML", objclsOperationEqipmentQtyXMLInsert.strErJianBanKuoZhangQiAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ERJIANBANKUOZHANGQIBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strErJianBanKuoZhangQiBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("CEBANQIXML", objclsOperationEqipmentQtyXMLInsert.strCeBanQiXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("CEBANQIAFTERXML", objclsOperationEqipmentQtyXMLInsert.strCeBanQiAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("CEBANQIBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strCeBanQiBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("XINNEIZHIJIAOLAGOUXML", objclsOperationEqipmentQtyXMLInsert.strXinNeiZhiJiaoLaGouXML .Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("XINNEIZHIJIAOLAGOUAFTERXML", objclsOperationEqipmentQtyXMLInsert.strXinNeiZhiJiaoLaGouAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("XINNEIZHIJIAOLAGOUBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strXinNeiZhiJiaoLaGouBeforeXML.Replace('\'','五'));


			m_objXmlWriter.WriteAttributeString("DAOXIANGOUXML", objclsOperationEqipmentQtyXMLInsert.strDaoXianGouXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DAOXIANGOUAFTERXML", objclsOperationEqipmentQtyXMLInsert.strDaoXianGouAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DAOXIANGOUBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strDaoXianGouBeforeXML.Replace('\'','五'));

			
			m_objXmlWriter.WriteAttributeString("WUCHUANGNIEXML", objclsOperationEqipmentQtyXMLInsert.strWuChuangNieXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WUCHUANGNIEAFTERXML", objclsOperationEqipmentQtyXMLInsert.strWuChuangNieAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WUCHUANGNIEBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strWuChuangNieBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("KACHIXML", objclsOperationEqipmentQtyXMLInsert.strKaChiXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("KACHIAFTERXML", objclsOperationEqipmentQtyXMLInsert.strKaChiAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("KACHIBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strKaChiBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("SHENJINGLAGOUXML", objclsOperationEqipmentQtyXMLInsert.strShenJingLaGouXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("SHENJINGLAGOUAFTERXML", objclsOperationEqipmentQtyXMLInsert.strShenJingLaGouAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("SHENJINGLAGOUBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strShenJingLaGouBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("XUEGUANJIAXML", objclsOperationEqipmentQtyXMLInsert.strXueGuanJiaXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("XUEGUANJIAAFTERXML", objclsOperationEqipmentQtyXMLInsert.strXueGuanJiaAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("XUEGUANJIABEFOREXML", objclsOperationEqipmentQtyXMLInsert.strXueGuanJiaBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("FUKUIXML", objclsOperationEqipmentQtyXMLInsert.strFuKuiXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("FUKUIAFTERXML", objclsOperationEqipmentQtyXMLInsert.strFuKuiAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("FUKUIBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strFuKuiBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("GONGCHIXML", objclsOperationEqipmentQtyXMLInsert.strGongChiXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("GONGCHIAFTERXML", objclsOperationEqipmentQtyXMLInsert.strGongChiAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("GONGCHIBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strGongChiBeforeXML.Replace('\'','五'));

			
			m_objXmlWriter.WriteAttributeString("GONGGUASHIXML", objclsOperationEqipmentQtyXMLInsert.strGongGuaShiXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("GONGGUASHIAFTERXML", objclsOperationEqipmentQtyXMLInsert.strGongGuaShiAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("GONGGUASHIBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strGongGuaShiBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("GONGJINGQIANXML", objclsOperationEqipmentQtyXMLInsert.strGongJingQianXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("GONGJINGQIANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strGongJingQianAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("GONGJINGQIANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strGongJingQianBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("YINDAOLAGOUXML", objclsOperationEqipmentQtyXMLInsert.strYinDaoLaGouXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("YINDAOLAGOUAFTERXML", objclsOperationEqipmentQtyXMLInsert.strYinDaoLaGouAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("YINDAOLAGOUBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strYinDaoLaGouBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("RENDAIQIANXML", objclsOperationEqipmentQtyXMLInsert.strRenDaiQianXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("RENDAIQIANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strRenDaiQianAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("RENDAIQIANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strRenDaiQianBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("JILIUBOLIZIXML", objclsOperationEqipmentQtyXMLInsert.strJiLiuBoLiZiXML .Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("JILIUBOLIZIAFTERXML", objclsOperationEqipmentQtyXMLInsert.strJiLiuBoLiZiAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("JILIUBOLIZIBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strJiLiuBoLiZiBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("KUOGONGQIXML", objclsOperationEqipmentQtyXMLInsert.strKuoGongQiXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("KUOGONGQIAFTERXML", objclsOperationEqipmentQtyXMLInsert.strKuoGongQiAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("KUOGONGQIBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strKuoGongQiBeforeXML.Replace('\'','五'));

			
			m_objXmlWriter.WriteAttributeString("JINSHUNIAOGOUXML", objclsOperationEqipmentQtyXMLInsert.strJinShuNiaoGouXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("JINSHUNIAOGOUAFTERXML", objclsOperationEqipmentQtyXMLInsert.strJinShuNiaoGouAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("JINSHUNIAOGOUBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strJinShuNiaoGouBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("FUGUOQIANXML", objclsOperationEqipmentQtyXMLInsert.strFuGuoQianXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("FUGUOQIANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strFuGuoQianAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("FUGUOQIANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strFuGuoQianBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("YOUDAIFANGDIANXML", objclsOperationEqipmentQtyXMLInsert.strYouDaiFangDianXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("YOUDAIFANGDIANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strYouDaiFangDianAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("YOUDAIFANGDIANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strYouDaiFangDianBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("WUDAIFANGDIANXML", objclsOperationEqipmentQtyXMLInsert.strWuDaiFangDianXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WUDAIFANGDIANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strWuDaiFangDianAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WUDAIFANGDIANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strWuDaiFangDianBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("YOUDAICHANGDIANXML", objclsOperationEqipmentQtyXMLInsert.strYouDaiChangDianXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("YOUDAICHANGDIANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strYouDaiChangDianAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("YOUDAICHANGDIANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strYouDaiChangDianBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("WUDAICHANGDIANXML", objclsOperationEqipmentQtyXMLInsert.strWuDaiChangDianXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WUDAICHANGDIANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strWuDaiChangDianAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WUDAICHANGDIANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strWuDaiChangDianBeforeXML.Replace('\'','五'));

			
			m_objXmlWriter.WriteAttributeString("FUNIEYINLIUXML", objclsOperationEqipmentQtyXMLInsert.strFuNieYinLiuXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("FUNIEYINLIUAFTERXML", objclsOperationEqipmentQtyXMLInsert.strFuNieYinLiuAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("FUNIEYINLIUBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strFuNieYinLiuBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("KAILUMIANXML", objclsOperationEqipmentQtyXMLInsert.strKaiLuMianXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("KAILUMIANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strKaiLuMianAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("KAILUMIANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strKaiLuMianBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("QUANGONGSHAXML", objclsOperationEqipmentQtyXMLInsert.strQuanGongShaXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("QUANGONGSHAAFTERXML", objclsOperationEqipmentQtyXMLInsert.strQuanGongShaAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("QUANGONGSHABEFOREXML", objclsOperationEqipmentQtyXMLInsert.strQuanGongShaBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("WANGSHAXML", objclsOperationEqipmentQtyXMLInsert.strWangShaXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WANGSHAAFTERXML", objclsOperationEqipmentQtyXMLInsert.strWangShaAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WANGSHABEFOREXML", objclsOperationEqipmentQtyXMLInsert.strWangShaBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("SHAKUAIXML", objclsOperationEqipmentQtyXMLInsert.strShaKuaiXML .Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("SHAKUAIAFTERXML", objclsOperationEqipmentQtyXMLInsert.strShaKuaiAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("SHAKUAIBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strShaKuaiBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("SHAQIUXML", objclsOperationEqipmentQtyXMLInsert.strShaQiuXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("SHAQIUAFTERXML", objclsOperationEqipmentQtyXMLInsert.strShaQiuAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("SHAQIUBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strShaQiuBeforeXML.Replace('\'','五'));

			
			m_objXmlWriter.WriteAttributeString("BIANDAIXML", objclsOperationEqipmentQtyXMLInsert.strBianDaiXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("BIANDAIAFTERXML", objclsOperationEqipmentQtyXMLInsert.strBianDaiAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("BIANDAIBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strBianDaiBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("CHANGQIANTAOXML", objclsOperationEqipmentQtyXMLInsert.strChangQianTaoXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("CHANGQIANTAOAFTERXML", objclsOperationEqipmentQtyXMLInsert.strChangQianTaoAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("CHANGQIANTAOBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strChangQianTaoBeforeXML.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("NIAOGUANXML", objclsOperationEqipmentQtyXMLInsert.strNiaoGuanXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("NIAOGUANAFTERXML", objclsOperationEqipmentQtyXMLInsert.strNiaoGuanAfterXML.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("NIAOGUANBEFOREXML", objclsOperationEqipmentQtyXMLInsert.strNiaoGuanBeforeXML.Replace('\'','五'));









			
			m_objXmlWriter.WriteEndElement();          
			m_objXmlWriter.WriteEndDocument();
			m_objXmlWriter.Flush();			

			return System.Text.Encoding.Unicode.GetString(m_objXmlMemStream.ToArray(),39*2,(int)m_objXmlMemStream.Length-39*2);
		
		}
		
		
		#endregion

		#region ぐ赽桶腔XML
		/// <summary>
		/// ぐ赽桶腔XML
		/// </summary>
		/// <param name="objclsOperationEqipmentQtyXML"></param>
		/// <returns></returns>
		private string m_strGetContentXML(clsOperationEqipmentQtyContent objclsOperationEqipmentQtyContent)
		{
			m_objXmlMemStream.SetLength(0);
			
			m_objXmlWriter.WriteStartDocument();
			m_objXmlWriter.WriteStartElement("RecordMaster");
			
			m_objXmlWriter.WriteAttributeString("INPATIENTID", objclsOperationEqipmentQtyContent.strInPatientID.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("INPATIENTDATE", objclsOperationEqipmentQtyContent.strInPatientDate.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("OPENDATE",objclsOperationEqipmentQtyContent.strOpenDate.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("MODIFYUSERID", objclsOperationEqipmentQtyContent.strModifyUserID.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("MODIFYDATE", objclsOperationEqipmentQtyContent.strModifyDate.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("OPERATIONID", objclsOperationEqipmentQtyContent.strOperationID.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("OPERATIONNAME", objclsOperationEqipmentQtyContent.strOperationName.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("WENZHI125", objclsOperationEqipmentQtyContent.strWenZhi125.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WENZHI125AFTER", objclsOperationEqipmentQtyContent.strWenZhi125After.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WENZHI125BEFORE", objclsOperationEqipmentQtyContent.strWenZhi125Before.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("WENWAN125", objclsOperationEqipmentQtyContent.strWenWan125.Replace('\'','五'));
            m_objXmlWriter.WriteAttributeString("WENWAN125AFTER", objclsOperationEqipmentQtyContent.strWenWan125After.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WENWAN125BEFORE", objclsOperationEqipmentQtyContent.strWenWan125Before.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("XIAOZHI14", objclsOperationEqipmentQtyContent.strXiaoZhi14.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("XIAOZHI14AFTER", objclsOperationEqipmentQtyContent.strXiaoZhi14After.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("XIAOZHI14BEFORE", objclsOperationEqipmentQtyContent.strXiaoZhi14Before.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("XIAOWAN14", objclsOperationEqipmentQtyContent.strXiaoWan14.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("XIAOWAN14AFTER", objclsOperationEqipmentQtyContent.strXiaoWan14After.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("XIAOWAN14BEFORE", objclsOperationEqipmentQtyContent.strXiaoWan14Before.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("ZHONGZHI16", objclsOperationEqipmentQtyContent.strZhongZhi16.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHONGZHI16AFTER", objclsOperationEqipmentQtyContent.strZhongZhi16After.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHONGZHI16BEFORE", objclsOperationEqipmentQtyContent.strZhongZhi16Before.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("ZHONGWAN16", objclsOperationEqipmentQtyContent.strZhongWan16.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHONGWAN16AFTER", objclsOperationEqipmentQtyContent.strZhongWan16After.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHONGWAN16BEFORE", objclsOperationEqipmentQtyContent.strZhongWan16Before.Replace('\'','五'));
						
			
			m_objXmlWriter.WriteAttributeString("PIQIAN", objclsOperationEqipmentQtyContent.strPiQian.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("PIQIANAFTER", objclsOperationEqipmentQtyContent.strPiQianAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("PIQIANBEFORE", objclsOperationEqipmentQtyContent.strPiQianBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("ZHIYOUCHIXUEGUANQIAN", objclsOperationEqipmentQtyContent.strZhiYouChiXueGuanQian.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHIYOUCHIXUEGUANQIANAFTER", objclsOperationEqipmentQtyContent.strZhiYouChiXueGuanQianAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHIYOUCHIXUEGUANQIANBEFORE", objclsOperationEqipmentQtyContent.strZhiYouChiXueGuanQianBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("QUANQIAN", objclsOperationEqipmentQtyContent.strQuanQian.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("QUANQIANAFTER", objclsOperationEqipmentQtyContent.strQuanQianAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("QUANQIANBEFORE", objclsOperationEqipmentQtyContent.strQuanQianBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("JINQIAN", objclsOperationEqipmentQtyContent.strJinQian.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("JINQIANAFTER", objclsOperationEqipmentQtyContent.strJinQianAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("JINQIANBEFORE", objclsOperationEqipmentQtyContent.strJinQianBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("CHIZHENQIAN18", objclsOperationEqipmentQtyContent.strChiZhenQian18.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("CHIZHENQIAN18AFTER", objclsOperationEqipmentQtyContent.strChiZhenQian18After.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("CHIZHENQIAN18BEFORE", objclsOperationEqipmentQtyContent.strChiZhenQian18Before.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("YOUCHINIE", objclsOperationEqipmentQtyContent.strYouChiNie.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("YOUCHINIEAFTER", objclsOperationEqipmentQtyContent.strYouChiNieAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("YOUCHINIEBEFORE", objclsOperationEqipmentQtyContent.strYouChiNieBefore.Replace('\'','五'));


			
			m_objXmlWriter.WriteAttributeString("WUCHINIE", objclsOperationEqipmentQtyContent.strWuChiNie.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WUCHINIEAFTER", objclsOperationEqipmentQtyContent.strWuChiNieAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WUCHINIEBEFORE", objclsOperationEqipmentQtyContent.strWuChiNieBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("CHANGYABAN", objclsOperationEqipmentQtyContent.strChangYaBan.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("CHANGYABANAFTER", objclsOperationEqipmentQtyContent.strChangYaBanAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("CHANGYABANBEFORE", objclsOperationEqipmentQtyContent.strChangYaBanBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("DAOBING3", objclsOperationEqipmentQtyContent.strDaoBing3.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DAOBING3AFTER", objclsOperationEqipmentQtyContent.strDaoBing3After.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DAOBING3BEFORE", objclsOperationEqipmentQtyContent.strDaoBing3Before.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("DAOBING4", objclsOperationEqipmentQtyContent.strDaoBing4.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DAOBING4AFTER", objclsOperationEqipmentQtyContent.strDaoBing4After.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DAOBING4BEFORE", objclsOperationEqipmentQtyContent.strDaoBing4Before.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("DAOBING7", objclsOperationEqipmentQtyContent.strDaoBing7.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DAOBING7AFTER", objclsOperationEqipmentQtyContent.strDaoBing7After.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DAOBING7BEFORE", objclsOperationEqipmentQtyContent.strDaoBing7Before.Replace('\'','五'));

			
			m_objXmlWriter.WriteAttributeString("WANZHUZHIJIAN", objclsOperationEqipmentQtyContent.strWanZhuZhiJian.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WANZHUZHIJIANAFTER", objclsOperationEqipmentQtyContent.strWanZhuZhiJianAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WANZHUZHIJIANBEFORE", objclsOperationEqipmentQtyContent.strWanZhuZhiJianBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("ZHIZHUZHIJIAN", objclsOperationEqipmentQtyContent.strZhiZhuZhiJian.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHIZHUZHIJIANAFTER", objclsOperationEqipmentQtyContent.strZhiZhuZhiJianAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHIZHUZHIJIANBEFORE", objclsOperationEqipmentQtyContent.strZhiZhuZhiJianBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("BIANTAOXIANJIAN", objclsOperationEqipmentQtyContent.strBianTaoXianJian.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("BIANTAOXIANJIANAFTER", objclsOperationEqipmentQtyContent.strBianTaoXianJianAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("BIANTAOXIANJIANBEFORE", objclsOperationEqipmentQtyContent.strBianTaoXianJianBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("XIONGQIANGJIAN", objclsOperationEqipmentQtyContent.strXiongQiangJian.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("XIONGQIANGJIANAFTER", objclsOperationEqipmentQtyContent.strXiongQiangJianAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("XIONGQIANGJIANBEFORE", objclsOperationEqipmentQtyContent.strXiongQiangJianBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("ZHIJIAOXIAOLAGOU", objclsOperationEqipmentQtyContent.strZhiJiaoXiaoLaGou.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHIJIAOXIAOLAGOUAFTER", objclsOperationEqipmentQtyContent.strZhiJiaoXiaoLaGouAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHIJIAOXIAOLAGOUBEFORE", objclsOperationEqipmentQtyContent.strZhiJiaoXiaoLaGouBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("LANWEILAGOU", objclsOperationEqipmentQtyContent.strLanWeiLaGou.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("LANWEILAGOUAFTER", objclsOperationEqipmentQtyContent.strLanWeiLaGouAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("LANWEILAGOUBEFORE", objclsOperationEqipmentQtyContent.strLanWeiLaGouBefore.Replace('\'','五'));

			
			m_objXmlWriter.WriteAttributeString("ZHONGFUGOU", objclsOperationEqipmentQtyContent.strZhongFuGou.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHONGFUGOUAFTER", objclsOperationEqipmentQtyContent.strZhongFuGouAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHONGFUGOUBEFORE", objclsOperationEqipmentQtyContent.strZhongFuGouBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("CHANGYAGOU", objclsOperationEqipmentQtyContent.strChangYaGou.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("CHANGYAGOUAFTER", objclsOperationEqipmentQtyContent.strChangYaGouAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("CHANGYAGOUBEFORE", objclsOperationEqipmentQtyContent.strChangYaGouBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("ZHIJIAOGOU", objclsOperationEqipmentQtyContent.strZhiJiaoGou.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHIJIAOGOUAFTER", objclsOperationEqipmentQtyContent.strZhiJiaoGouAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHIJIAOGOUBEFORE", objclsOperationEqipmentQtyContent.strZhiJiaoGouBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("XIAFUBUQIANKAIQI", objclsOperationEqipmentQtyContent.strXiaFuBuQianKaiQi.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("XIAFUBUQIANKAIQIAFTER", objclsOperationEqipmentQtyContent.strXiaFuBuQianKaiQiAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("XIAFUBUQIANKAIQIBEFORE", objclsOperationEqipmentQtyContent.strXiaFuBuQianKaiQiBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("TONGQUAN", objclsOperationEqipmentQtyContent.strTongQuan.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("TONGQUANAFTER", objclsOperationEqipmentQtyContent.strTongQuanAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("TONGQUANBEFORE", objclsOperationEqipmentQtyContent.strTongQuanBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("XIYEGUAN", objclsOperationEqipmentQtyContent.strXiYeGuan.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("XIYEGUANAFTER", objclsOperationEqipmentQtyContent.strXiYeGuanAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("XIYEGUANBEFORE", objclsOperationEqipmentQtyContent.strXiYeGuanBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("ZHIJIAOQIAN", objclsOperationEqipmentQtyContent.strZhiJiaoQian.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHIJIAOQIANAFTER", objclsOperationEqipmentQtyContent.strZhiJiaoQianAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHIJIAOQIANBEFORE", objclsOperationEqipmentQtyContent.strZhiJiaoQianBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("DAZHIQIAN", objclsOperationEqipmentQtyContent.strDaZhiQian.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DAZHIQIANAFTER", objclsOperationEqipmentQtyContent.strDaZhiQianAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DAZHIQIANBEFORE", objclsOperationEqipmentQtyContent.strDaZhiQianBefore.Replace('\'','五'));

			
			m_objXmlWriter.WriteAttributeString("FENGZHEN", objclsOperationEqipmentQtyContent.strFengZhen.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("FENGZHENAFTER", objclsOperationEqipmentQtyContent.strFengZhenAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("FENGZHENBEFORE", objclsOperationEqipmentQtyContent.strFengZhenBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("DAOPIAN", objclsOperationEqipmentQtyContent.strDaoPian.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DAOPIANAFTER", objclsOperationEqipmentQtyContent.strDaoPianAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DAOPIANBEFORE", objclsOperationEqipmentQtyContent.strDaoPianBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("WANXUEGUANQIAN18", objclsOperationEqipmentQtyContent.strWanXueGuanQian18.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WANXUEGUANQIAN18AFTER", objclsOperationEqipmentQtyContent.strWanXueGuanQian18After.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WANXUEGUANQIAN18BEFORE", objclsOperationEqipmentQtyContent.strWanXueGuanQian18Before.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("WANXUEGUANQIAN20", objclsOperationEqipmentQtyContent.strWanXueGuanQian20.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WANXUEGUANQIAN20AFTER", objclsOperationEqipmentQtyContent.strWanXueGuanQian20After.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WANXUEGUANQIAN20BEFORE", objclsOperationEqipmentQtyContent.strWanXueGuanQian20Before.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("WANXUEGUANQIAN22", objclsOperationEqipmentQtyContent.strWanXueGuanQian22.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WANXUEGUANQIAN22AFTER", objclsOperationEqipmentQtyContent.strWanXueGuanQian22After.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WANXUEGUANQIAN22BEFORE", objclsOperationEqipmentQtyContent.strWanXueGuanQian22Before.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("WANXUEGUANQIAN25", objclsOperationEqipmentQtyContent.strWanXueGuanQian25.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WANXUEGUANQIAN25AFTER", objclsOperationEqipmentQtyContent.strWanXueGuanQian25After.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WANXUEGUANQIAN25BEFORE", objclsOperationEqipmentQtyContent.strWanXueGuanQian25Before.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("CHANGCHIZHENQIAN25", objclsOperationEqipmentQtyContent.strChangChiZhenQian25.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("CHANGCHIZHENQIAN25AFTER", objclsOperationEqipmentQtyContent.strChangChiZhenQian25After.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("CHANGCHIZHENQIAN25BEFORE", objclsOperationEqipmentQtyContent.strChangChiZhenQian25Before.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("NIANMOQIAN", objclsOperationEqipmentQtyContent.strNianMoQian.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("NIANMOQIANAFTER", objclsOperationEqipmentQtyContent.strNianMoQianAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("NIANMOQIANBEFORE", objclsOperationEqipmentQtyContent.strNianMoQianBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("SHALIQIAN", objclsOperationEqipmentQtyContent.strShaLiQian.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("SHALIQIANAFTER", objclsOperationEqipmentQtyContent.strShaLiQianAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("SHALIQIANBEFORE", objclsOperationEqipmentQtyContent.strShaLiQianBefore.Replace('\'','五'));

			
			m_objXmlWriter.WriteAttributeString("DAWANXUEGUANQIAN", objclsOperationEqipmentQtyContent.strDaWanXueGuanQian.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DAWANXUEGUANQIANAFTER", objclsOperationEqipmentQtyContent.strDaWanXueGuanQianAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DAWANXUEGUANQIANBEFORE", objclsOperationEqipmentQtyContent.strDaWanXueGuanQianBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("SHENDIQIAN", objclsOperationEqipmentQtyContent.strShenDiQian.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("SHENDIQIANAFTER", objclsOperationEqipmentQtyContent.strShenDiQianAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("SHENDIQIANBEFORE", objclsOperationEqipmentQtyContent.strShenDiQianBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("CHANGQIANZHI", objclsOperationEqipmentQtyContent.strChangQianZhi.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("CHANGQIANZHIAFTER", objclsOperationEqipmentQtyContent.strChangQianZhiAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("CHANGQIANZHIBEFORE", objclsOperationEqipmentQtyContent.strChangQianZhiBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("CHANGQIANWAN", objclsOperationEqipmentQtyContent.strChangQianWan.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("CHANGQIANWANAFTER", objclsOperationEqipmentQtyContent.strChangQianWanAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("CHANGQIANWANBEFORE", objclsOperationEqipmentQtyContent.strChangQianWanBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("SHIQIAN", objclsOperationEqipmentQtyContent.strShiQian.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("SHIQIANAFTER", objclsOperationEqipmentQtyContent.strShiQianAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("SHIQIANBEFORE", objclsOperationEqipmentQtyContent.strShiQianBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("WEIQIAN", objclsOperationEqipmentQtyContent.strWeiQian.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WEIQIANAFTER", objclsOperationEqipmentQtyContent.strWeiQianAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WEIQIANBEFORE", objclsOperationEqipmentQtyContent.strWeiQianBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("XINERQIAN", objclsOperationEqipmentQtyContent.strXinErQian.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("XINERQIANAFTER", objclsOperationEqipmentQtyContent.strXinErQiaAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("XINERQIANBEFORE", objclsOperationEqipmentQtyContent.strXinErQiaBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("ERYANHOUCHONGXIQI", objclsOperationEqipmentQtyContent.strErYanHouChongXiQi.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ERYANHOUCHONGXIQIAFTER", objclsOperationEqipmentQtyContent.strErYanHouChongXiQiAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ERYANHOUCHONGXIQIBEFORE", objclsOperationEqipmentQtyContent.strErYanHouChongXiQiBefore.Replace('\'','五'));

			
			m_objXmlWriter.WriteAttributeString("TANZHENCHU", objclsOperationEqipmentQtyContent.strTanZhenChu.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("TANZHENCHUAFTER", objclsOperationEqipmentQtyContent.strTanZhenChuAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("TANZHENCHUBEFORE", objclsOperationEqipmentQtyContent.strTanZhenChuBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("TANZHENXI", objclsOperationEqipmentQtyContent.strTanZhenXi.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("TANZHENXIAFTER", objclsOperationEqipmentQtyContent.strTanZhenXiAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("TANZHENXIBEFORE", objclsOperationEqipmentQtyContent.strTanZhenXiBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("DANDAOTANTIAO", objclsOperationEqipmentQtyContent.strDanDaoTanTiao.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DANDAOTANTIAOAFTER", objclsOperationEqipmentQtyContent.strDanDaoTanTiaoAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DANDAOTANTIAOBEFORE", objclsOperationEqipmentQtyContent.strDanDaoTanTiaoBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("LEIGUQIANKAIQI", objclsOperationEqipmentQtyContent.strLeiGuQianKaiQi.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("LEIGUQIANKAIQIAFTER", objclsOperationEqipmentQtyContent.strLeiGuQianKaiQiAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("LEIGUQIANKAIQIBEFORE", objclsOperationEqipmentQtyContent.strLeiGuQianKaiQiBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("HELONGQI", objclsOperationEqipmentQtyContent.strHeLongQi.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("HELONGQIAFTER", objclsOperationEqipmentQtyContent.strHeLongQiAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("HELONGQIBEFORE", objclsOperationEqipmentQtyContent.strHeLongQiBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("JIANJIAGULAGOU", objclsOperationEqipmentQtyContent.strJianJiaGuLaGou.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("JIANJIAGULAGOUAFTER", objclsOperationEqipmentQtyContent.strJianJiaGuLaGouAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("JIANJIAGULAGOUBEFORE", objclsOperationEqipmentQtyContent.strJianJiaGuLaGouBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("LEIGUQIZI", objclsOperationEqipmentQtyContent.strLeiGuQiZi.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("LEIGUQIZIAFTER", objclsOperationEqipmentQtyContent.strLeiGuQiZiAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("LEIGUQIZIBEFORE", objclsOperationEqipmentQtyContent.strLeiGuQiZiBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("DAGUJIAN", objclsOperationEqipmentQtyContent.strDaGuJian.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DAGUJIANAFTER", objclsOperationEqipmentQtyContent.strDaGuJianAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DAGUJIANBEFORE", objclsOperationEqipmentQtyContent.strDaGuJianBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("DIERLEIGUJIAN", objclsOperationEqipmentQtyContent.strDiErLeiGuJian.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DIERLEIGUJIANAFTER", objclsOperationEqipmentQtyContent.strDiErLeiGuJianAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DIERLEIGUJIANBEFORE", objclsOperationEqipmentQtyContent.strDiErLeiGuJianBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("FANGTOUYAOGUQIAN", objclsOperationEqipmentQtyContent.strFangTouYaoGuQian.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("FANGTOUYAOGUQIANAFTER", objclsOperationEqipmentQtyContent.strFangTouYaoGuQianAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("FANGTOUYAOGUQIANBEFORE", objclsOperationEqipmentQtyContent.strFangTouYaoGuQianBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("YAOGUQIAN", objclsOperationEqipmentQtyContent.strYaoGuQian.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("YAOGUQIANAFTER", objclsOperationEqipmentQtyContent.strYaoGuQianAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("YAOGUQIANBEFORE", objclsOperationEqipmentQtyContent.strYaoGuQianBefore.Replace('\'','五'));

			
			m_objXmlWriter.WriteAttributeString("GUMOBOLIQI", objclsOperationEqipmentQtyContent.strGuMoBoLiQi.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("GUMOBOLIQIAFTER", objclsOperationEqipmentQtyContent.strGuMoBoLiQiAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("GUMOBOLIQIBEFORE", objclsOperationEqipmentQtyContent.strGuMoBoLiQiBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("GUDAO", objclsOperationEqipmentQtyContent.strGuDao.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("GUDAOAFTER", objclsOperationEqipmentQtyContent.strGuDaoAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("GUDAOBEFORE", objclsOperationEqipmentQtyContent.strGuDaoBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("GUZAO", objclsOperationEqipmentQtyContent.strGuZao.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("GUZAOAFTER", objclsOperationEqipmentQtyContent.strGuZaoAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("GUZAOBEFORE", objclsOperationEqipmentQtyContent.strGuZaoBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("KUOSHI", objclsOperationEqipmentQtyContent.strKuoShi.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("KUOSHIAFTER", objclsOperationEqipmentQtyContent.strKuoShiAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("KUOSHIBEFORE", objclsOperationEqipmentQtyContent.strKuoShiBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("GUCHUI", objclsOperationEqipmentQtyContent.strGuChui.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("GUCHUIAFTER", objclsOperationEqipmentQtyContent.strGuChuiAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("GUCHUIBEFORE", objclsOperationEqipmentQtyContent.strGuChuiBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("CHIGUQIAN", objclsOperationEqipmentQtyContent.strChiGuQian.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("CHIGUQIANAFTER", objclsOperationEqipmentQtyContent.strChiGuQianAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("CHIGUQIANBEFORE", objclsOperationEqipmentQtyContent.strChiGuQianBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("JINGGUQIZI", objclsOperationEqipmentQtyContent.strJingGuQiZi.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("JINGGUQIZIAFTER", objclsOperationEqipmentQtyContent.strJingGuQiZiAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("JINGGUQIZIBEFORE", objclsOperationEqipmentQtyContent.strJingGuQiZiBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("DANCHILAGOU", objclsOperationEqipmentQtyContent.strDanChiLaGou.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DANCHILAGOUAFTER", objclsOperationEqipmentQtyContent.strDanChiLaGouAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DANCHILAGOUBEFORE", objclsOperationEqipmentQtyContent.strDanChiLaGouBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("LAOHUQIAN", objclsOperationEqipmentQtyContent.strLaoHuQian.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("LAOHUQIANAFTER", objclsOperationEqipmentQtyContent.strLaoHuQianAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("LAOHUQIANBEFORE", objclsOperationEqipmentQtyContent.strLaoHuQianBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("PINGHENGFUWEIQIAN", objclsOperationEqipmentQtyContent.strPingHengFuWeiQian.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("PINGHENGFUWEIQIANAFTER", objclsOperationEqipmentQtyContent.strPingHengFuWeiQianAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("PINGHENGFUWEIQIANBEFORE", objclsOperationEqipmentQtyContent.strPingHengFuWeiQianBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("LUOSIQIZI", objclsOperationEqipmentQtyContent.strLuoSiQiZi.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("LUOSIQIZIAFTER", objclsOperationEqipmentQtyContent.strLuoSiQiZiAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("LUOSIQIZIBEFORE", objclsOperationEqipmentQtyContent.strLuoSiQiZiBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("DAOXIANGQI", objclsOperationEqipmentQtyContent.strDaoXiangQi.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DAOXIANGQIAFTER", objclsOperationEqipmentQtyContent.strDaoXiangQiAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DAOXIANGQIBEFORE", objclsOperationEqipmentQtyContent.strDaoXiangQiBefore.Replace('\'','五'));


			
			m_objXmlWriter.WriteAttributeString("ZHUIBANYAOGUQIAN", objclsOperationEqipmentQtyContent.strZhuiBanYaoGuQian.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHUIBANYAOGUQIANAFTER", objclsOperationEqipmentQtyContent.strZhuiBanYaoGuQianAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHUIBANYAOGUQIANBEFORE", objclsOperationEqipmentQtyContent.strZhuiBanYaoGuQianBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("SHUIHEQIAN", objclsOperationEqipmentQtyContent.strShuiHeQian.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("SHUIHEQIANAFTER", objclsOperationEqipmentQtyContent.strShuiHeQianAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("SHUIHEQIANBEFORE", objclsOperationEqipmentQtyContent.strShuiHeQianBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("JINGTUJIAN", objclsOperationEqipmentQtyContent.strJingTuJian.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("JINGTUJIANAFTER", objclsOperationEqipmentQtyContent.strJingTuJianAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("JINGTUJIANBEFORE", objclsOperationEqipmentQtyContent.strJingTuJianBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("ZHUIBANBOLIQI", objclsOperationEqipmentQtyContent.strZhuiBanBoLiQi.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHUIBANBOLIQIAFTER", objclsOperationEqipmentQtyContent.strZhuiBanBoLiQiAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHUIBANBOLIQIBEFORE", objclsOperationEqipmentQtyContent.strZhuiBanBoLiQiBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("JIANBOLIZI", objclsOperationEqipmentQtyContent.strJianBoLiZi.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("JIANBOLIZIAFTER", objclsOperationEqipmentQtyContent.strJianBoLiZiAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("JIANBOLIZIBEFORE", objclsOperationEqipmentQtyContent.strJianBoLiZiBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("QIANGZHUANGNIE", objclsOperationEqipmentQtyContent.strQiangZhuangNie.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("QIANGZHUANGNIEAFTER", objclsOperationEqipmentQtyContent.strQiangZhuangNieAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("QIANGZHUANGNIEBEFORE", objclsOperationEqipmentQtyContent.strQiangZhuangNieBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("BAISHIQIANKAIQI", objclsOperationEqipmentQtyContent.strBaiShiQianKaiQi.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("BAISHIQIANKAIQIAFTER", objclsOperationEqipmentQtyContent.strBaiShiQianKaiQiAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("BAISHIQIANKAIQIBEFORE", objclsOperationEqipmentQtyContent.strBaiShiQianKaiQiBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("KAILUZHUAN", objclsOperationEqipmentQtyContent.strKaiLuZhuan.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("KAILUZHUANAFTER", objclsOperationEqipmentQtyContent.strKaiLuZhuanAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("KAILUZHUANBEFORE", objclsOperationEqipmentQtyContent.strKaiLuZhuanBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("TOUPIJIANQIAN", objclsOperationEqipmentQtyContent.strTouPiJianQian.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("TOUPIJIANQIANAFTER", objclsOperationEqipmentQtyContent.strTouPiJianQianAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("TOUPIJIANQIANBEFORE", objclsOperationEqipmentQtyContent.strTouPiJianQianBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("XIANJUDAOYINZI", objclsOperationEqipmentQtyContent.strXianJuDaoYinZi.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("XIANJUDAOYINZIAFTER", objclsOperationEqipmentQtyContent.strXianJuDaoYinZiAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("XIANJUDAOYINZIBEFORE", objclsOperationEqipmentQtyContent.strXianJuDaoYinZiBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("XINERLAGOU", objclsOperationEqipmentQtyContent.strXinErLaGou.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("XINERLAGOUAFTER", objclsOperationEqipmentQtyContent.strXinErLaGouAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("XINERLAGOUBEFORE", objclsOperationEqipmentQtyContent.strXinErLaGouBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("CHIBANQIAN", objclsOperationEqipmentQtyContent.strChiBanQian.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("CHIBANQIANAFTER", objclsOperationEqipmentQtyContent.strChiBanQianAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("CHIBANQIANBEFORE", objclsOperationEqipmentQtyContent.strChiBanQianBefore.Replace('\'','五'));

			
			m_objXmlWriter.WriteAttributeString("XINFANGLAGOU", objclsOperationEqipmentQtyContent.strXinFangLaGou.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("XINFANGLAGOUAFTER", objclsOperationEqipmentQtyContent.strXinFangLaGouAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("XINFANGLAGOUBEFORE", objclsOperationEqipmentQtyContent.strXinFangLaGouBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("NAOMOGOU", objclsOperationEqipmentQtyContent.strNaoMoGou.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("NAOMOGOUAFTER", objclsOperationEqipmentQtyContent.strNaoMoGouAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("NAOMOGOUBEFORE", objclsOperationEqipmentQtyContent.strNaoMoGouBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("CHUANCIZHEN", objclsOperationEqipmentQtyContent.strChuanCiZhen.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("CHUANCIZHENAFTER", objclsOperationEqipmentQtyContent.strChuanCiZhenAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("CHUANCIZHENBEFORE", objclsOperationEqipmentQtyContent.strChuanCiZhenBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("YINDINGQIAN", objclsOperationEqipmentQtyContent.strYinDingQian.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("YINDINGQIANAFTER", objclsOperationEqipmentQtyContent.strYinDingQianAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("YINDINGQIANBEFORE", objclsOperationEqipmentQtyContent.strYinDingQianBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("FEIYEDANGBAN", objclsOperationEqipmentQtyContent.strFeiYeDangBan.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("FEIYEDANGBANAFTER", objclsOperationEqipmentQtyContent.strFeiYeDangBanAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("FEIYEDANGBANBEFORE", objclsOperationEqipmentQtyContent.strFeiYeDangBanBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("ZHUAZHUDUANQIAN", objclsOperationEqipmentQtyContent.strZhuAZhuDuanQian.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHUAZHUDUANQIANAFTER", objclsOperationEqipmentQtyContent.strZhuAZhuDuanQianAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHUAZHUDUANQIANBEFORE", objclsOperationEqipmentQtyContent.strZhuAZhuDuanQianBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("ZHUAYOULIQIAN", objclsOperationEqipmentQtyContent.strZhuAYouLiQian.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHUAYOULIQIANAFTER", objclsOperationEqipmentQtyContent.strZhuAYouLiQianAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHUAYOULIQIANBEFORE", objclsOperationEqipmentQtyContent.strZhuAYouLiQianBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("ZHUACEBIQIAN", objclsOperationEqipmentQtyContent.strZhuACeBiQian.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHUACEBIQIANAFTER", objclsOperationEqipmentQtyContent.strZhuACeBiQiAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ZHUACEBIQIANBEFORE", objclsOperationEqipmentQtyContent.strZhuACeBiQiBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("ERJIANBANKUOZHANGQI", objclsOperationEqipmentQtyContent.strErJianBanKuoZhangQi.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ERJIANBANKUOZHANGQIAFTER", objclsOperationEqipmentQtyContent.strErJianBanKuoZhangQiAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("ERJIANBANKUOZHANGQIBEFORE", objclsOperationEqipmentQtyContent.strErJianBanKuoZhangQiBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("CEBANQI", objclsOperationEqipmentQtyContent.strCeBanQi.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("CEBANQIAFTER", objclsOperationEqipmentQtyContent.strCeBanQiAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("CEBANQIBEFORE", objclsOperationEqipmentQtyContent.strCeBanQiBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("XINNEIZHIJIAOLAGOU", objclsOperationEqipmentQtyContent.strXinNeiZhiJiaoLaGou .Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("XINNEIZHIJIAOLAGOUAFTER", objclsOperationEqipmentQtyContent.strXinNeiZhiJiaoLaGouAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("XINNEIZHIJIAOLAGOUBEFORE", objclsOperationEqipmentQtyContent.strXinNeiZhiJiaoLaGouBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("DAOXIANGOU", objclsOperationEqipmentQtyContent.strDaoXianGou.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DAOXIANGOUAFTER", objclsOperationEqipmentQtyContent.strDaoXianGouAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("DAOXIANGOUBEFORE", objclsOperationEqipmentQtyContent.strDaoXianGouBefore.Replace('\'','五'));

			
			m_objXmlWriter.WriteAttributeString("WUCHUANGNIE", objclsOperationEqipmentQtyContent.strWuChuangNie.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WUCHUANGNIEAFTER", objclsOperationEqipmentQtyContent.strWuChuangNieAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WUCHUANGNIEBEFORE", objclsOperationEqipmentQtyContent.strWuChuangNieBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("KACHI", objclsOperationEqipmentQtyContent.strKaChi.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("KACHIAFTER", objclsOperationEqipmentQtyContent.strKaChiAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("KACHIBEFORE", objclsOperationEqipmentQtyContent.strKaChiBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("SHENJINGLAGOU", objclsOperationEqipmentQtyContent.strShenJingLaGou.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("SHENJINGLAGOUAFTER", objclsOperationEqipmentQtyContent.strShenJingLaGouAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("SHENJINGLAGOUBEFORE", objclsOperationEqipmentQtyContent.strShenJingLaGouBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("XUEGUANJIA", objclsOperationEqipmentQtyContent.strXueGuanJia.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("XUEGUANJIAAFTER", objclsOperationEqipmentQtyContent.strXueGuanJiaAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("XUEGUANJIABEFORE", objclsOperationEqipmentQtyContent.strXueGuanJiaBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("FUKUI", objclsOperationEqipmentQtyContent.strFuKui.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("FUKUIAFTER", objclsOperationEqipmentQtyContent.strFuKuiAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("FUKUIBEFORE", objclsOperationEqipmentQtyContent.strFuKuiBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("GONGCHI", objclsOperationEqipmentQtyContent.strGongChi.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("GONGCHIAFTER", objclsOperationEqipmentQtyContent.strGongChiAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("GONGCHIBEFORE", objclsOperationEqipmentQtyContent.strGongChiBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("GONGGUASHI", objclsOperationEqipmentQtyContent.strGongGuaShi.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("GONGGUASHIAFTER", objclsOperationEqipmentQtyContent.strGongGuaShiAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("GONGGUASHIBEFORE", objclsOperationEqipmentQtyContent.strGongGuaShiBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("GONGJINGQIAN", objclsOperationEqipmentQtyContent.strGongJingQian.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("GONGJINGQIANAFTER", objclsOperationEqipmentQtyContent.strGongJingQianAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("GONGJINGQIANBEFORE", objclsOperationEqipmentQtyContent.strGongJingQianBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("YINDAOLAGOU", objclsOperationEqipmentQtyContent.strYinDaoLaGou.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("YINDAOLAGOUAFTER", objclsOperationEqipmentQtyContent.strYinDaoLaGouAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("YINDAOLAGOUBEFORE", objclsOperationEqipmentQtyContent.strYinDaoLaGouBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("RENDAIQIAN", objclsOperationEqipmentQtyContent.strRenDaiQian.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("RENDAIQIANAFTER", objclsOperationEqipmentQtyContent.strRenDaiQianAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("RENDAIQIANBEFORE", objclsOperationEqipmentQtyContent.strRenDaiQianBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("JILIUBOLIZI", objclsOperationEqipmentQtyContent.strJiLiuBoLiZi .Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("JILIUBOLIZIAFTER", objclsOperationEqipmentQtyContent.strJiLiuBoLiZiAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("JILIUBOLIZIBEFORE", objclsOperationEqipmentQtyContent.strJiLiuBoLiZiBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("KUOGONGQI", objclsOperationEqipmentQtyContent.strKuoGongQi.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("KUOGONGQIAFTER", objclsOperationEqipmentQtyContent.strKuoGongQiAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("KUOGONGQIBEFORE", objclsOperationEqipmentQtyContent.strKuoGongQiBefore.Replace('\'','五'));

			
			m_objXmlWriter.WriteAttributeString("JINSHUNIAOGOU", objclsOperationEqipmentQtyContent.strJinShuNiaoGou.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("JINSHUNIAOGOUAFTER", objclsOperationEqipmentQtyContent.strJinShuNiaoGouAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("JINSHUNIAOGOUBEFORE", objclsOperationEqipmentQtyContent.strJinShuNiaoGouBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("FUGUOQIAN", objclsOperationEqipmentQtyContent.strFuGuoQian.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("FUGUOQIANAFTER", objclsOperationEqipmentQtyContent.strFuGuoQianAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("FUGUOQIANBEFORE", objclsOperationEqipmentQtyContent.strFuGuoQianBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("YOUDAIFANGDIAN", objclsOperationEqipmentQtyContent.strYouDaiFangDian.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("YOUDAIFANGDIANAFTER", objclsOperationEqipmentQtyContent.strYouDaiFangDianAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("YOUDAIFANGDIANBEFORE", objclsOperationEqipmentQtyContent.strYouDaiFangDianBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("WUDAIFANGDIAN", objclsOperationEqipmentQtyContent.strWuDaiFangDian.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WUDAIFANGDIANAFTER", objclsOperationEqipmentQtyContent.strWuDaiFangDianAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WUDAIFANGDIANBEFORE", objclsOperationEqipmentQtyContent.strWuDaiFangDianBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("YOUDAICHANGDIAN", objclsOperationEqipmentQtyContent.strYouDaiChangDian.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("YOUDAICHANGDIANAFTER", objclsOperationEqipmentQtyContent.strYouDaiChangDianAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("YOUDAICHANGDIANBEFORE", objclsOperationEqipmentQtyContent.strYouDaiChangDianBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("WUDAICHANGDIAN", objclsOperationEqipmentQtyContent.strWuDaiChangDian.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WUDAICHANGDIANAFTER", objclsOperationEqipmentQtyContent.strWuDaiChangDianAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WUDAICHANGDIANBEFORE", objclsOperationEqipmentQtyContent.strWuDaiChangDianBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("FUNIEYINLIU", objclsOperationEqipmentQtyContent.strFuNieYinLiu.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("FUNIEYINLIUAFTER", objclsOperationEqipmentQtyContent.strFuNieYinLiuAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("FUNIEYINLIUBEFORE", objclsOperationEqipmentQtyContent.strFuNieYinLiuBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("KAILUMIAN", objclsOperationEqipmentQtyContent.strKaiLuMian.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("KAILUMIANAFTER", objclsOperationEqipmentQtyContent.strKaiLuMianAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("KAILUMIANBEFORE", objclsOperationEqipmentQtyContent.strKaiLuMianBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("QUANGONGSHA", objclsOperationEqipmentQtyContent.strQuanGongSha.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("QUANGONGSHAAFTER", objclsOperationEqipmentQtyContent.strQuanGongShaAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("QUANGONGSHABEFORE", objclsOperationEqipmentQtyContent.strQuanGongShaBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("WANGSHA", objclsOperationEqipmentQtyContent.strWangSha.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WANGSHAAFTER", objclsOperationEqipmentQtyContent.strWangShaAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("WANGSHABEFORE", objclsOperationEqipmentQtyContent.strWangShaBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("SHAKUAI", objclsOperationEqipmentQtyContent.strShaKuai .Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("SHAKUAIAFTER", objclsOperationEqipmentQtyContent.strShaKuaiAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("SHAKUAIBEFORE", objclsOperationEqipmentQtyContent.strShaKuaiBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("SHAQIU", objclsOperationEqipmentQtyContent.strShaQiu.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("SHAQIUAFTER", objclsOperationEqipmentQtyContent.strShaQiuAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("SHAQIUBEFORE", objclsOperationEqipmentQtyContent.strShaQiuBefore.Replace('\'','五'));

			
			m_objXmlWriter.WriteAttributeString("BIANDAI", objclsOperationEqipmentQtyContent.strBianDai.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("BIANDAIAFTER", objclsOperationEqipmentQtyContent.strBianDaiAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("BIANDAIBEFORE", objclsOperationEqipmentQtyContent.strBianDaiBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("CHANGQIANTAO", objclsOperationEqipmentQtyContent.strChangQianTao.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("CHANGQIANTAOAFTER", objclsOperationEqipmentQtyContent.strChangQianTaoAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("CHANGQIANTAOBEFORE", objclsOperationEqipmentQtyContent.strChangQianTaoBefore.Replace('\'','五'));

			m_objXmlWriter.WriteAttributeString("NIAOGUAN", objclsOperationEqipmentQtyContent.strNiaoGuan.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("NIAOGUANAFTER", objclsOperationEqipmentQtyContent.strNiaoGuanAfter.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("NIAOGUANBEFORE", objclsOperationEqipmentQtyContent.strNiaoGuanBefore.Replace('\'','五'));

			m_objXmlWriter.WriteEndElement();          
			m_objXmlWriter.WriteEndDocument();
			m_objXmlWriter.Flush();			

			return System.Text.Encoding.Unicode.GetString(m_objXmlMemStream.ToArray(),39*2,(int)m_objXmlMemStream.Length-39*2);
		
		}

		#endregion

		/// <summary>
		/// ぐ誘尪
		/// </summary>
		/// <param name="objclsOperationEqipmentQtyContent"></param>
		/// <returns></returns>
		private string m_strGetNurseXML(clsOperationNurse objclsOperationNurse)
		{
			m_objXmlMemStream.SetLength(0);
			
			m_objXmlWriter.WriteStartDocument();
			m_objXmlWriter.WriteStartElement("RecordMaster");
			
			m_objXmlWriter.WriteAttributeString("INPATIENTID", objclsOperationNurse.strInPatientID.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("INPATIENTDATE", objclsOperationNurse.strInPatientDate.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("OPENDATE", objclsOperationNurse.strOpenDate.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("NURSEID", objclsOperationNurse.strNurseID.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("NURSEFLAG", objclsOperationNurse.strNurseFlag.Replace('\'','五'));
			m_objXmlWriter.WriteAttributeString("STATUS", objclsOperationNurse.strStatus.Replace('\'','五'));
			
			m_objXmlWriter.WriteEndElement();          
			m_objXmlWriter.WriteEndDocument();
			m_objXmlWriter.Flush();			
			return System.Text.Encoding.Unicode.GetString(m_objXmlMemStream.ToArray(),39*2,(int)m_objXmlMemStream.Length-39*2);
		}


		/// <summary>
		/// 珆尨
		/// </summary>
		/// <param name="strInPatientID"></param>
		/// <param name="strInPatientDate"></param>
		/// <param name="strOpenDate"></param>
		/// <param name="strReceivedXML"></param>
		/// <param name="intReturnRows"></param>
		/// <returns></returns>
		public long lngSelectDisply(string strInPatientID, string strInPatientDate,string strOpenDate,out clsOperationEquipmentPackage objclsOperationEquipmentPackage)
		{
			objclsOperationEquipmentPackage=null;
			#region 隅砱曹講
			string m_strReceivedXML="";
			int m_intReturnRows=0;
			//隅砱Package
			clsOperationEquipmentPackage m_objPackage = new clsOperationEquipmentPackage();
			
			//隅砱翋桶
			clsOperationEqipmentQtyXML objOperationEqipmentQtyXML=new clsOperationEqipmentQtyXML(); 
			
			//隅砱赽桶
			clsOperationEqipmentQtyContent objOperationEqipmentQtyContent=new clsOperationEqipmentQtyContent(); 
			#endregion

			long lngSucceed = 0;

            com.digitalwave.OperationEquipmentQtyService.clsOperationEquipmentQtyService m_objServ =
                (com.digitalwave.OperationEquipmentQtyService.clsOperationEquipmentQtyService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.OperationEquipmentQtyService.clsOperationEquipmentQtyService));

            try
            {
                lngSucceed = m_objServ.m_lngGetCurrentRecordXMLTable(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, strInPatientID, strInPatientDate, strOpenDate, ref m_strReceivedXML, ref m_intReturnRows);
            }
            finally
            {
                //m_objServ.Dispose();
            }
			if(m_intReturnRows>0)
			{
				XmlTextReader objReader = new XmlTextReader(m_strReceivedXML,XmlNodeType.Element,m_objXmlParser);
				objReader.WhitespaceHandling = WhitespaceHandling.None;
			
				while(objReader.Read())
				{
					switch(objReader.NodeType)
					{
						case XmlNodeType.Element:
							if(objReader.HasAttributes)
							{

								#region 赽桶
								objOperationEqipmentQtyContent.strInPatientID=objReader.GetAttribute("INPATIENTID").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strInPatientDate=objReader.GetAttribute("INPATIENTDATE").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strOpenDate=objReader.GetAttribute("OPENDATE").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strModifyDate=objReader.GetAttribute("MODIFYDATE").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strModifyUserID=objReader.GetAttribute("MODIFYUSERID").ToString().Replace ('五','\'');

								//								objOperationEqipmentQtyContent.strOperationID=objReader.GetAttribute("INPATIENTID").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strOperationName=objReader.GetAttribute("OPERATIONNAME").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strWenWan125=objReader.GetAttribute("WENWAN125").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWenWan125After=objReader.GetAttribute("WENWAN125AFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWenWan125Before=objReader.GetAttribute("WENWAN125BEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strWenZhi125=objReader.GetAttribute("WENZHI125").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWenZhi125After=objReader.GetAttribute("WENZHI125AFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWenZhi125Before=objReader.GetAttribute("WENZHI125BEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strXiaoWan14=objReader.GetAttribute("XIAOWAN14").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strXiaoWan14After=objReader.GetAttribute("XIAOWAN14AFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strXiaoWan14Before=objReader.GetAttribute("XIAOWAN14BEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strXiaoZhi14=objReader.GetAttribute("XIAOZHI14").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strXiaoZhi14After=objReader.GetAttribute("XIAOZHI14AFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strXiaoZhi14Before=objReader.GetAttribute("XIAOZHI14BEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strZhongWan16=objReader.GetAttribute("ZHONGWAN16").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhongWan16After=objReader.GetAttribute("ZHONGWAN16AFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhongWan16Before=objReader.GetAttribute("ZHONGWAN16BEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strZhongZhi16=objReader.GetAttribute("ZHONGZHI16").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhongZhi16After=objReader.GetAttribute("ZHONGZHI16AFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhongZhi16Before=objReader.GetAttribute("ZHONGZHI16BEFORE").ToString().Replace ('五','\'');
								
								
								//************************************************
								objOperationEqipmentQtyContent.strPiQian=objReader.GetAttribute("PIQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strPiQianAfter=objReader.GetAttribute("PIQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strPiQianBefore=objReader.GetAttribute("PIQIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strZhiYouChiXueGuanQian=objReader.GetAttribute("ZHIYOUCHIXUEGUANQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhiYouChiXueGuanQianAfter=objReader.GetAttribute("ZHIYOUCHIXUEGUANQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhiYouChiXueGuanQianBefore=objReader.GetAttribute("ZHIYOUCHIXUEGUANQIANBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strQuanQian=objReader.GetAttribute("QUANQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strQuanQianAfter=objReader.GetAttribute("QUANQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strQuanQianBefore=objReader.GetAttribute("QUANQIANBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strJinQian=objReader.GetAttribute("JINQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strJinQianAfter=objReader.GetAttribute("JINQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strJinQianBefore=objReader.GetAttribute("JINQIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strChiZhenQian18=objReader.GetAttribute("CHIZHENQIAN18").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strChiZhenQian18After=objReader.GetAttribute("CHIZHENQIAN18AFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strChiZhenQian18Before=objReader.GetAttribute("CHIZHENQIAN18BEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strYouChiNie=objReader.GetAttribute("YOUCHINIE").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strYouChiNieAfter=objReader.GetAttribute("YOUCHINIEAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strYouChiNieBefore=objReader.GetAttribute("YOUCHINIEBEFORE").ToString().Replace ('五','\'');
								
							
								//************************************************
								objOperationEqipmentQtyContent.strWuChiNie=objReader.GetAttribute("WUCHINIE").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWuChiNieAfter=objReader.GetAttribute("WUCHINIEAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWuChiNieBefore=objReader.GetAttribute("WUCHINIEBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strChangYaBan=objReader.GetAttribute("CHANGYABAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strChangYaBanAfter=objReader.GetAttribute("CHANGYABANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strChangYaBanBefore=objReader.GetAttribute("CHANGYABANBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strDaoBing3=objReader.GetAttribute("DAOBING3").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDaoBing3After=objReader.GetAttribute("DAOBING3AFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDaoBing3Before=objReader.GetAttribute("DAOBING3BEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strDaoBing4=objReader.GetAttribute("DAOBING4").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDaoBing4After=objReader.GetAttribute("DAOBING4AFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDaoBing4Before=objReader.GetAttribute("DAOBING4BEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strDaoBing7=objReader.GetAttribute("DAOBING7").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDaoBing7After=objReader.GetAttribute("DAOBING7AFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDaoBing7Before=objReader.GetAttribute("DAOBING7BEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strWuChiNie=objReader.GetAttribute("WUCHINIE").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWuChiNieAfter=objReader.GetAttribute("WUCHINIEAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWuChiNieBefore=objReader.GetAttribute("WUCHINIEBEFORE").ToString().Replace ('五','\'');
								
							
								//************************************************
								objOperationEqipmentQtyContent.strZhiZhuZhiJian=objReader.GetAttribute("ZHIZHUZHIJIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhiZhuZhiJianAfter=objReader.GetAttribute("ZHIZHUZHIJIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhiZhuZhiJianBefore=objReader.GetAttribute("ZHIZHUZHIJIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strWanZhuZhiJian=objReader.GetAttribute("WANZHUZHIJIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWanZhuZhiJianAfter=objReader.GetAttribute("WANZHUZHIJIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWanZhuZhiJianBefore=objReader.GetAttribute("WANZHUZHIJIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strBianTaoXianJian=objReader.GetAttribute("BIANTAOXIANJIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strBianTaoXianJianAfter=objReader.GetAttribute("BIANTAOXIANJIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strBianTaoXianJianBefore=objReader.GetAttribute("BIANTAOXIANJIANBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strXiongQiangJian=objReader.GetAttribute("XIONGQIANGJIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strXiongQiangJianAfter=objReader.GetAttribute("XIONGQIANGJIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strXiongQiangJianBefore=objReader.GetAttribute("XIONGQIANGJIANBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strZhiJiaoXiaoLaGou=objReader.GetAttribute("ZHIJIAOXIAOLAGOU").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhiJiaoXiaoLaGouAfter=objReader.GetAttribute("ZHIJIAOXIAOLAGOUAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhiJiaoXiaoLaGouBefore=objReader.GetAttribute("ZHIJIAOXIAOLAGOUBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strLanWeiLaGou=objReader.GetAttribute("LANWEILAGOU").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strLanWeiLaGouAfter=objReader.GetAttribute("LANWEILAGOUAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strLanWeiLaGouBefore=objReader.GetAttribute("LANWEILAGOUBEFORE").ToString().Replace ('五','\'');
								
							
								//************************************************
								objOperationEqipmentQtyContent.strZhongFuGou=objReader.GetAttribute("ZHONGFUGOU").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhongFuGouAfter=objReader.GetAttribute("ZHONGFUGOUAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhongFuGouBefore=objReader.GetAttribute("ZHONGFUGOUBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strChangYaGou=objReader.GetAttribute("CHANGYAGOU").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strChangYaGouAfter=objReader.GetAttribute("CHANGYAGOUAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strChangYaGouBefore=objReader.GetAttribute("CHANGYAGOUBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strZhiJiaoQian=objReader.GetAttribute("ZHIJIAOQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhiJiaoQianAfter=objReader.GetAttribute("ZHIJIAOQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhiJiaoQianBefore=objReader.GetAttribute("ZHIJIAOQIANBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strXiaFuBuQianKaiQi=objReader.GetAttribute("XIAFUBUQIANKAIQI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strXiaFuBuQianKaiQiAfter=objReader.GetAttribute("XIAFUBUQIANKAIQIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strXiaFuBuQianKaiQiBefore=objReader.GetAttribute("XIAFUBUQIANKAIQIBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strTongQuan=objReader.GetAttribute("TONGQUAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strTongQuanAfter=objReader.GetAttribute("TONGQUANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strTongQuanBefore=objReader.GetAttribute("TONGQUANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strXiYeGuan=objReader.GetAttribute("XIYEGUAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strXiYeGuanAfter=objReader.GetAttribute("XIYEGUANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strXiYeGuanBefore=objReader.GetAttribute("XIYEGUANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strDaZhiQian=objReader.GetAttribute("DAZHIQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDaZhiQianAfter=objReader.GetAttribute("DAZHIQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDaZhiQianBefore=objReader.GetAttribute("DAZHIQIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strZhiJiaoGou=objReader.GetAttribute("ZHIJIAOGOU").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhiJiaoGouAfter=objReader.GetAttribute("ZHIJIAOGOUAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhiJiaoGouBefore=objReader.GetAttribute("ZHIJIAOGOUBEFORE").ToString().Replace ('五','\'');
								
							
								//************************************************
								objOperationEqipmentQtyContent.strDaoPian=objReader.GetAttribute("DAOPIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDaoPianAfter=objReader.GetAttribute("DAOPIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDaoPianBefore=objReader.GetAttribute("DAOPIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strWanXueGuanQian18=objReader.GetAttribute("WANXUEGUANQIAN18").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWanXueGuanQian18After=objReader.GetAttribute("WANXUEGUANQIAN18AFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWanXueGuanQian18Before=objReader.GetAttribute("WANXUEGUANQIAN18BEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strWanXueGuanQian22=objReader.GetAttribute("WANXUEGUANQIAN22").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWanXueGuanQian22After=objReader.GetAttribute("WANXUEGUANQIAN22AFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWanXueGuanQian22Before=objReader.GetAttribute("WANXUEGUANQIAN22BEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strChangChiZhenQian25=objReader.GetAttribute("CHANGCHIZHENQIAN25").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strChangChiZhenQian25After=objReader.GetAttribute("CHANGCHIZHENQIAN25AFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strChangChiZhenQian25Before=objReader.GetAttribute("CHANGCHIZHENQIAN25BEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strFengZhen=objReader.GetAttribute("FENGZHEN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strFengZhenAfter=objReader.GetAttribute("FENGZHENAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strFengZhenBefore=objReader.GetAttribute("FENGZHENBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strNianMoQian=objReader.GetAttribute("NIANMOQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strNianMoQianAfter=objReader.GetAttribute("NIANMOQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strNianMoQianBefore=objReader.GetAttribute("NIANMOQIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strShaLiQian=objReader.GetAttribute("SHALIQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strShaLiQianAfter=objReader.GetAttribute("SHALIQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strShaLiQianBefore=objReader.GetAttribute("SHALIQIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strShaLiQian=objReader.GetAttribute("SHALIQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strShaLiQianAfter=objReader.GetAttribute("SHALIQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strShaLiQianBefore=objReader.GetAttribute("SHALIQIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strWanXueGuanQian20=objReader.GetAttribute("WANXUEGUANQIAN20").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWanXueGuanQian20After=objReader.GetAttribute("WANXUEGUANQIAN20AFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWanXueGuanQian20Before=objReader.GetAttribute("WANXUEGUANQIAN20BEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strWanXueGuanQian25=objReader.GetAttribute("WANXUEGUANQIAN25").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWanXueGuanQian25After=objReader.GetAttribute("WANXUEGUANQIAN25AFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWanXueGuanQian25Before=objReader.GetAttribute("WANXUEGUANQIAN25BEFORE").ToString().Replace ('五','\'');
								
							
								//************************************************
								objOperationEqipmentQtyContent.strChangQianWan=objReader.GetAttribute("CHANGQIANWAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strChangQianWanAfter=objReader.GetAttribute("CHANGQIANWANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strChangQianWanBefore=objReader.GetAttribute("CHANGQIANWANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strChangQianZhi=objReader.GetAttribute("CHANGQIANZHI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strChangQianZhiAfter=objReader.GetAttribute("CHANGQIANZHIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strChangQianZhiBefore=objReader.GetAttribute("CHANGQIANZHIBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strDaWanXueGuanQian=objReader.GetAttribute("DAWANXUEGUANQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDaWanXueGuanQianAfter=objReader.GetAttribute("DAWANXUEGUANQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDaWanXueGuanQianBefore=objReader.GetAttribute("DAWANXUEGUANQIANBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strErYanHouChongXiQi=objReader.GetAttribute("ERYANHOUCHONGXIQI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strErYanHouChongXiQiAfter=objReader.GetAttribute("ERYANHOUCHONGXIQIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strErYanHouChongXiQiBefore=objReader.GetAttribute("ERYANHOUCHONGXIQIBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strShenDiQian=objReader.GetAttribute("SHENDIQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strShenDiQianAfter=objReader.GetAttribute("SHENDIQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strShenDiQianBefore=objReader.GetAttribute("SHENDIQIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strShiQian=objReader.GetAttribute("SHIQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strShiQianAfter=objReader.GetAttribute("SHIQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strShiQianBefore=objReader.GetAttribute("SHIQIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strWeiQian=objReader.GetAttribute("WEIQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWeiQianAfter=objReader.GetAttribute("WEIQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWeiQianBefore=objReader.GetAttribute("WEIQIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strXinErQian=objReader.GetAttribute("XINERQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strXinErQiaAfter=objReader.GetAttribute("XINERQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strXinErQiaBefore=objReader.GetAttribute("XINERQIANBEFORE").ToString().Replace ('五','\'');
								
							
								//************************************************
								objOperationEqipmentQtyContent.strDaGuJian=objReader.GetAttribute("DAGUJIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDaGuJianAfter=objReader.GetAttribute("DAGUJIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDaGuJianBefore=objReader.GetAttribute("DAGUJIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strDanDaoTanTiao=objReader.GetAttribute("DANDAOTANTIAO").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDanDaoTanTiaoAfter=objReader.GetAttribute("DANDAOTANTIAOAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDanDaoTanTiaoBefore=objReader.GetAttribute("DANDAOTANTIAOBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strDiErLeiGuJian=objReader.GetAttribute("DIERLEIGUJIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDiErLeiGuJianAfter=objReader.GetAttribute("DIERLEIGUJIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDiErLeiGuJianBefore=objReader.GetAttribute("DIERLEIGUJIANBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strFangTouYaoGuQian=objReader.GetAttribute("FANGTOUYAOGUQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strFangTouYaoGuQianAfter=objReader.GetAttribute("FANGTOUYAOGUQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strFangTouYaoGuQianBefore=objReader.GetAttribute("FANGTOUYAOGUQIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strHeLongQi=objReader.GetAttribute("HELONGQI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strHeLongQiAfter=objReader.GetAttribute("HELONGQIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strHeLongQiBefore=objReader.GetAttribute("HELONGQIBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strJianJiaGuLaGou=objReader.GetAttribute("JIANJIAGULAGOU").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strJianJiaGuLaGouAfter=objReader.GetAttribute("JIANJIAGULAGOUAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strJianJiaGuLaGouBefore=objReader.GetAttribute("JIANJIAGULAGOUBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strLeiGuQianKaiQi=objReader.GetAttribute("LEIGUQIANKAIQI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strLeiGuQianKaiQiAfter=objReader.GetAttribute("LEIGUQIANKAIQIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strLeiGuQianKaiQiBefore=objReader.GetAttribute("LEIGUQIANKAIQIBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strLeiGuQiZi=objReader.GetAttribute("LEIGUQIZI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strLeiGuQiZiAfter=objReader.GetAttribute("LEIGUQIZIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strLeiGuQiZiBefore=objReader.GetAttribute("LEIGUQIZIBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strTanZhenChu=objReader.GetAttribute("TANZHENCHU").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strTanZhenChuAfter=objReader.GetAttribute("TANZHENCHUAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strTanZhenChuBefore=objReader.GetAttribute("TANZHENCHUBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strTanZhenXi=objReader.GetAttribute("TANZHENXI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strTanZhenXiAfter=objReader.GetAttribute("TANZHENXIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strTanZhenXiBefore=objReader.GetAttribute("TANZHENXIBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strYaoGuQian=objReader.GetAttribute("YAOGUQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strYaoGuQianAfter=objReader.GetAttribute("YAOGUQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strYaoGuQianBefore=objReader.GetAttribute("YAOGUQIANBEFORE").ToString().Replace ('五','\'');
								

								//************************************************
								objOperationEqipmentQtyContent.strChiGuQian=objReader.GetAttribute("CHIGUQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strChiGuQianAfter=objReader.GetAttribute("CHIGUQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strChiGuQianBefore=objReader.GetAttribute("CHIGUQIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strDanChiLaGou=objReader.GetAttribute("DANCHILAGOU").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDanChiLaGouAfter=objReader.GetAttribute("DANCHILAGOUAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDanChiLaGouBefore=objReader.GetAttribute("DANCHILAGOUBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strDaoXiangQi=objReader.GetAttribute("DAOXIANGQI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDaoXiangQiAfter=objReader.GetAttribute("DAOXIANGQIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDaoXiangQiBefore=objReader.GetAttribute("DAOXIANGQIBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strGuChui=objReader.GetAttribute("GUCHUI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strGuChuiAfter=objReader.GetAttribute("GUCHUIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strGuChuiBefore=objReader.GetAttribute("GUCHUIBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strGuDao=objReader.GetAttribute("GUDAO").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strGuDaoAfter=objReader.GetAttribute("GUDAOAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strGuDaoBefore=objReader.GetAttribute("GUDAOBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strGuZao=objReader.GetAttribute("GUZAO").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strGuZaoAfter=objReader.GetAttribute("GUZAOAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strGuZaoBefore=objReader.GetAttribute("GUZAOBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strGuMoBoLiQi=objReader.GetAttribute("GUMOBOLIQI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strGuMoBoLiQiAfter=objReader.GetAttribute("GUMOBOLIQIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strGuMoBoLiQiBefore=objReader.GetAttribute("GUMOBOLIQIBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strJingGuQiZi=objReader.GetAttribute("JINGGUQIZI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strJingGuQiZiAfter=objReader.GetAttribute("JINGGUQIZIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strJingGuQiZiBefore=objReader.GetAttribute("JINGGUQIZIBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strKuoShi=objReader.GetAttribute("KUOSHI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strKuoShiAfter=objReader.GetAttribute("KUOSHIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strKuoShiBefore=objReader.GetAttribute("KUOSHIBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strLeiGuQiZi=objReader.GetAttribute("LEIGUQIZI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strLeiGuQiZiAfter=objReader.GetAttribute("LEIGUQIZIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strLeiGuQiZiBefore=objReader.GetAttribute("LEIGUQIZIBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strLaoHuQian=objReader.GetAttribute("LAOHUQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strLaoHuQianAfter=objReader.GetAttribute("LAOHUQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strLaoHuQianBefore=objReader.GetAttribute("LAOHUQIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strLuoSiQiZi=objReader.GetAttribute("LUOSIQIZI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strLuoSiQiZiAfter=objReader.GetAttribute("LUOSIQIZIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strLuoSiQiZiBefore=objReader.GetAttribute("LUOSIQIZIBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strPingHengFuWeiQian=objReader.GetAttribute("PINGHENGFUWEIQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strPingHengFuWeiQianAfter=objReader.GetAttribute("PINGHENGFUWEIQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strPingHengFuWeiQianBefore=objReader.GetAttribute("PINGHENGFUWEIQIANBEFORE").ToString().Replace ('五','\'');
								
							
								//************************************************
								objOperationEqipmentQtyContent.strBaiShiQianKaiQi=objReader.GetAttribute("BAISHIQIANKAIQI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strBaiShiQianKaiQiAfter=objReader.GetAttribute("BAISHIQIANKAIQIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strBaiShiQianKaiQiBefore=objReader.GetAttribute("BAISHIQIANKAIQIBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strChiBanQian=objReader.GetAttribute("CHIBANQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strChiBanQianAfter=objReader.GetAttribute("CHIBANQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strChiBanQianBefore=objReader.GetAttribute("CHIBANQIANBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strJianBoLiZi=objReader.GetAttribute("JIANBOLIZI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strJianBoLiZiAfter=objReader.GetAttribute("JIANBOLIZIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strJianBoLiZiBefore=objReader.GetAttribute("JIANBOLIZIBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strJingTuJian=objReader.GetAttribute("JINGTUJIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strJingTuJianAfter=objReader.GetAttribute("JINGTUJIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strJingTuJianBefore=objReader.GetAttribute("JINGTUJIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strKaiLuZhuan=objReader.GetAttribute("KAILUZHUAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strKaiLuZhuanAfter=objReader.GetAttribute("KAILUZHUANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strKaiLuZhuanBefore=objReader.GetAttribute("KAILUZHUANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strQiangZhuangNie=objReader.GetAttribute("QIANGZHUANGNIE").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strQiangZhuangNieAfter=objReader.GetAttribute("QIANGZHUANGNIEAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strQiangZhuangNieBefore=objReader.GetAttribute("QIANGZHUANGNIEBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strShuiHeQian=objReader.GetAttribute("SHUIHEQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strShuiHeQianAfter=objReader.GetAttribute("SHUIHEQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strShuiHeQianBefore=objReader.GetAttribute("SHUIHEQIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strTouPiJianQian=objReader.GetAttribute("TOUPIJIANQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strTouPiJianQianAfter=objReader.GetAttribute("TOUPIJIANQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strTouPiJianQianBefore=objReader.GetAttribute("TOUPIJIANQIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strXianJuDaoYinZi=objReader.GetAttribute("XIANJUDAOYINZI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strXianJuDaoYinZiAfter=objReader.GetAttribute("XIANJUDAOYINZIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strXianJuDaoYinZiBefore=objReader.GetAttribute("XIANJUDAOYINZIBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strXinErLaGou=objReader.GetAttribute("XINERLAGOU").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strXinErLaGouAfter=objReader.GetAttribute("XINERLAGOUAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strXinErLaGouBefore=objReader.GetAttribute("XINERLAGOUBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strZhuiBanBoLiQi=objReader.GetAttribute("ZHUIBANBOLIQI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhuiBanBoLiQiAfter=objReader.GetAttribute("ZHUIBANBOLIQIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhuiBanBoLiQiBefore=objReader.GetAttribute("ZHUIBANBOLIQIBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strZhuiBanYaoGuQian=objReader.GetAttribute("ZHUIBANYAOGUQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhuiBanYaoGuQianAfter=objReader.GetAttribute("ZHUIBANYAOGUQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhuiBanYaoGuQianBefore=objReader.GetAttribute("ZHUIBANYAOGUQIANBEFORE").ToString().Replace ('五','\'');
								
							
								//************************************************
								objOperationEqipmentQtyContent.strCeBanQi=objReader.GetAttribute("CEBANQI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strCeBanQiAfter=objReader.GetAttribute("CEBANQIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strCeBanQiBefore=objReader.GetAttribute("CEBANQIBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strChuanCiZhen=objReader.GetAttribute("CHUANCIZHEN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strChuanCiZhenAfter=objReader.GetAttribute("CHUANCIZHENAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strChuanCiZhenBefore=objReader.GetAttribute("CHUANCIZHENBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strDaoXianGou=objReader.GetAttribute("DAOXIANGOU").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDaoXianGouAfter=objReader.GetAttribute("DAOXIANGOUAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDaoXianGouBefore=objReader.GetAttribute("DAOXIANGOUBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strErJianBanKuoZhangQi=objReader.GetAttribute("ERJIANBANKUOZHANGQI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strErJianBanKuoZhangQiAfter=objReader.GetAttribute("ERJIANBANKUOZHANGQIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strErJianBanKuoZhangQiBefore=objReader.GetAttribute("ERJIANBANKUOZHANGQIBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strFeiYeDangBan=objReader.GetAttribute("FEIYEDANGBAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strFeiYeDangBanAfter=objReader.GetAttribute("FEIYEDANGBANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strFeiYeDangBanBefore=objReader.GetAttribute("FEIYEDANGBANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strNaoMoGou=objReader.GetAttribute("NAOMOGOU").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strNaoMoGouAfter=objReader.GetAttribute("NAOMOGOUAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strNaoMoGouBefore=objReader.GetAttribute("NAOMOGOUBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strXinFangLaGou=objReader.GetAttribute("XINFANGLAGOU").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strXinFangLaGouAfter=objReader.GetAttribute("XINFANGLAGOUAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strXinFangLaGouBefore=objReader.GetAttribute("XINFANGLAGOUBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strXinNeiZhiJiaoLaGou=objReader.GetAttribute("XINNEIZHIJIAOLAGOU").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strXinNeiZhiJiaoLaGouAfter=objReader.GetAttribute("XINNEIZHIJIAOLAGOUAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strXinNeiZhiJiaoLaGouBefore=objReader.GetAttribute("XINNEIZHIJIAOLAGOUBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strYinDingQian=objReader.GetAttribute("YINDINGQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strYinDingQianAfter=objReader.GetAttribute("YINDINGQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strYinDingQianBefore=objReader.GetAttribute("YINDINGQIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strZhuACeBiQian=objReader.GetAttribute("ZHUACEBIQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhuACeBiQiAfter=objReader.GetAttribute("ZHUACEBIQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhuACeBiQiBefore=objReader.GetAttribute("ZHUACEBIQIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strZhuAYouLiQian=objReader.GetAttribute("ZHUAYOULIQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhuAYouLiQianAfter=objReader.GetAttribute("ZHUAYOULIQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhuAYouLiQianBefore=objReader.GetAttribute("ZHUAYOULIQIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strZhuAZhuDuanQian=objReader.GetAttribute("ZHUAZHUDUANQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhuAZhuDuanQianAfter=objReader.GetAttribute("ZHUAZHUDUANQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhuAZhuDuanQianBefore=objReader.GetAttribute("ZHUAZHUDUANQIANBEFORE").ToString().Replace ('五','\'');
								
							
								//************************************************
								objOperationEqipmentQtyContent.strFuKui=objReader.GetAttribute("FUKUI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strFuKuiAfter=objReader.GetAttribute("FUKUIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strFuKuiBefore=objReader.GetAttribute("FUKUIBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strGongChi=objReader.GetAttribute("GONGCHI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strGongChiAfter=objReader.GetAttribute("GONGCHIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strGongChiBefore=objReader.GetAttribute("GONGCHIBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strGongGuaShi=objReader.GetAttribute("GONGGUASHI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strGongGuaShiAfter=objReader.GetAttribute("GONGGUASHIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strGongGuaShiBefore=objReader.GetAttribute("GONGGUASHIBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strGongJingQian=objReader.GetAttribute("GONGJINGQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strGongJingQianAfter=objReader.GetAttribute("GONGJINGQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strGongJingQianBefore=objReader.GetAttribute("GONGJINGQIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strJiLiuBoLiZi=objReader.GetAttribute("JILIUBOLIZI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strJiLiuBoLiZiAfter=objReader.GetAttribute("JILIUBOLIZIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strJiLiuBoLiZiBefore=objReader.GetAttribute("JILIUBOLIZIBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strKaChi=objReader.GetAttribute("KACHI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strKaChiAfter=objReader.GetAttribute("KACHIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strKaChiBefore=objReader.GetAttribute("KACHIBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strKuoGongQi=objReader.GetAttribute("KUOGONGQI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strKuoGongQiAfter=objReader.GetAttribute("KUOGONGQIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strKuoGongQiBefore=objReader.GetAttribute("KUOGONGQIBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strRenDaiQian=objReader.GetAttribute("RENDAIQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strRenDaiQianAfter=objReader.GetAttribute("RENDAIQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strRenDaiQianBefore=objReader.GetAttribute("RENDAIQIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strShenJingLaGou=objReader.GetAttribute("SHENJINGLAGOU").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strShenJingLaGouAfter=objReader.GetAttribute("SHENJINGLAGOUAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strShenJingLaGouBefore=objReader.GetAttribute("SHENJINGLAGOUBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strWuChuangNie=objReader.GetAttribute("WUCHUANGNIE").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWuChuangNieAfter=objReader.GetAttribute("WUCHUANGNIEAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWuChuangNieBefore=objReader.GetAttribute("WUCHUANGNIEBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strXueGuanJia=objReader.GetAttribute("XUEGUANJIA").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strXueGuanJiaAfter=objReader.GetAttribute("XUEGUANJIAAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strXueGuanJiaBefore=objReader.GetAttribute("XUEGUANJIABEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strYinDaoLaGou=objReader.GetAttribute("YINDAOLAGOU").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strYinDaoLaGouAfter=objReader.GetAttribute("YINDAOLAGOUAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strYinDaoLaGouBefore=objReader.GetAttribute("YINDAOLAGOUBEFORE").ToString().Replace ('五','\'');
								
							
								//************************************************
								objOperationEqipmentQtyContent.strFuGuoQian=objReader.GetAttribute("FUGUOQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strFuGuoQianAfter=objReader.GetAttribute("FUGUOQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strFuGuoQianBefore=objReader.GetAttribute("FUGUOQIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strFuNieYinLiu=objReader.GetAttribute("FUNIEYINLIU").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strFuNieYinLiuAfter=objReader.GetAttribute("FUNIEYINLIUAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strFuNieYinLiuBefore=objReader.GetAttribute("FUNIEYINLIUBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strJinShuNiaoGou=objReader.GetAttribute("JINSHUNIAOGOU").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strJinShuNiaoGouAfter=objReader.GetAttribute("JINSHUNIAOGOUAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strJinShuNiaoGouBefore=objReader.GetAttribute("JINSHUNIAOGOUBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strKaiLuMian=objReader.GetAttribute("KAILUMIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strKaiLuMianAfter=objReader.GetAttribute("KAILUMIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strKaiLuMianBefore=objReader.GetAttribute("KAILUMIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strQuanGongSha=objReader.GetAttribute("QUANGONGSHA").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strQuanGongShaAfter=objReader.GetAttribute("QUANGONGSHAAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strQuanGongShaBefore=objReader.GetAttribute("QUANGONGSHABEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strShaKuai=objReader.GetAttribute("SHAKUAI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strShaKuaiAfter=objReader.GetAttribute("SHAKUAIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strShaKuaiBefore=objReader.GetAttribute("SHAKUAIBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strShaQiu=objReader.GetAttribute("SHAQIU").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strShaQiuAfter=objReader.GetAttribute("SHAQIUAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strShaQiuBefore=objReader.GetAttribute("SHAQIUBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strWangSha=objReader.GetAttribute("WANGSHA").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWangShaAfter=objReader.GetAttribute("WANGSHAAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWangShaBefore=objReader.GetAttribute("WANGSHABEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strWuDaiChangDian=objReader.GetAttribute("WUDAICHANGDIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWuDaiChangDianAfter=objReader.GetAttribute("WUDAICHANGDIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWuDaiChangDianBefore=objReader.GetAttribute("WUDAICHANGDIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strWuDaiFangDian=objReader.GetAttribute("WUDAIFANGDIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWuDaiFangDianAfter=objReader.GetAttribute("WUDAIFANGDIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWuDaiFangDianBefore=objReader.GetAttribute("WUDAIFANGDIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strYouDaiChangDian=objReader.GetAttribute("YOUDAICHANGDIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strYouDaiChangDianAfter=objReader.GetAttribute("YOUDAICHANGDIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strYouDaiChangDianBefore=objReader.GetAttribute("YOUDAICHANGDIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strYouDaiFangDian=objReader.GetAttribute("YOUDAIFANGDIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strYouDaiFangDianAfter=objReader.GetAttribute("YOUDAIFANGDIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strYouDaiFangDianBefore=objReader.GetAttribute("YOUDAIFANGDIANBEFORE").ToString().Replace ('五','\'');
								
								
								//************************************************
								objOperationEqipmentQtyContent.strBianDai=objReader.GetAttribute("BIANDAI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strBianDaiAfter=objReader.GetAttribute("BIANDAIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strBianDaiBefore=objReader.GetAttribute("BIANDAIBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strChangQianTao=objReader.GetAttribute("CHANGQIANTAO").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strChangQianTaoAfter=objReader.GetAttribute("CHANGQIANTAOAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strChangQianTaoBefore=objReader.GetAttribute("CHANGQIANTAOBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strNiaoGuan=objReader.GetAttribute("NIAOGUAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strNiaoGuanAfter=objReader.GetAttribute("NIAOGUANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strNiaoGuanBefore=objReader.GetAttribute("NIAOGUANBEFORE").ToString().Replace ('五','\'');


								m_objPackage.m_objOperationEqipmentQtyContent =objOperationEqipmentQtyContent;
								
								#endregion

								#region 翋桶
								objOperationEqipmentQtyXML.strInPatientID=objReader.GetAttribute("INPATIENTID");
								objOperationEqipmentQtyXML.strInPatientDate=objReader.GetAttribute("INPATIENTDATE");
								objOperationEqipmentQtyXML.strOpenDate=objReader.GetAttribute("OPENDATE");

								objOperationEqipmentQtyXML.strCreateDate=objReader.GetAttribute("CREATEDATE");
								objOperationEqipmentQtyXML.strCreateUserID=objReader.GetAttribute("CREATEUSERID");

								//								objOperationEqipmentQtyContentInsert.strOperationID=objReader.GetAttribute("INPATIENTID").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strOperationNameXML=objReader.GetAttribute("OPERATIONNAMEXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strWenWan125XML=objReader.GetAttribute("WENWAN125XML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWenWan125AfterXML=objReader.GetAttribute("WENWAN125AFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWenWan125BeforeXML=objReader.GetAttribute("WENWAN125BEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strWenZhi125XML=objReader.GetAttribute("WENZHI125XML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWenZhi125AfterXML=objReader.GetAttribute("WENZHI125AFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWenZhi125BeforeXML=objReader.GetAttribute("WENZHI125BEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strXiaoWan14XML=objReader.GetAttribute("XIAOWAN14XML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXiaoWan14AfterXML=objReader.GetAttribute("XIAOWAN14AFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXiaoWan14BeforeXML=objReader.GetAttribute("XIAOWAN14BEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strXiaoZhi14XML=objReader.GetAttribute("XIAOZHI14XML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXiaoZhi14AfterXML=objReader.GetAttribute("XIAOZHI14AFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXiaoZhi14BeforeXML=objReader.GetAttribute("XIAOZHI14BEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strZhongWan16XML=objReader.GetAttribute("ZHONGWAN16XML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhongWan16AfterXML=objReader.GetAttribute("ZHONGWAN16AFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhongWan16BeforeXML=objReader.GetAttribute("ZHONGWAN16BEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strZhongZhi16XML=objReader.GetAttribute("ZHONGZHI16XML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhongZhi16AfterXML=objReader.GetAttribute("ZHONGZHI16AFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhongZhi16BeforeXML=objReader.GetAttribute("ZHONGZHI16BEFOREXML").ToString().Replace ('五','\'');
								
								
								//************************************************
								objOperationEqipmentQtyXML.strChiZhenQian18XML=objReader.GetAttribute("CHIZHENQIAN18XML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strChiZhenQian18AfterXML=objReader.GetAttribute("CHIZHENQIAN18AFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strChiZhenQian18BeforeXML=objReader.GetAttribute("CHIZHENQIAN18BEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strJinQianAfterXML=objReader.GetAttribute("JINQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strJinQianBeforeXML=objReader.GetAttribute("JINQIANBEFOREXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strJinQianXML=objReader.GetAttribute("JINQIANXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strPiQianAfterXML=objReader.GetAttribute("PIQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strPiQianBeforeXML=objReader.GetAttribute("PIQIANBEFOREXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strPiQianXML=objReader.GetAttribute("PIQIANXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strQuanQianAfterXML=objReader.GetAttribute("QUANQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strQuanQianBeforeXML=objReader.GetAttribute("QUANQIANBEFOREXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strQuanQianXML=objReader.GetAttribute("QUANQIANXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strZhiYouChiXueGuanQianAfterXML=objReader.GetAttribute("ZHIYOUCHIXUEGUANQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhiYouChiXueGuanQianBeforeXML=objReader.GetAttribute("ZHIYOUCHIXUEGUANQIANBEFOREXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhiYouChiXueGuanQianXML=objReader.GetAttribute("ZHIYOUCHIXUEGUANQIANXML").ToString().Replace ('五','\'');
								
							

								objOperationEqipmentQtyXML.strYouChiNieXML =objReader.GetAttribute("YOUCHINIEXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strYouChiNieBeforeXML =objReader.GetAttribute("YOUCHINIEBEFOREXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strYouChiNieAfterXML =objReader.GetAttribute("YOUCHINIEAFTERXML").ToString().Replace ('五','\'');

								
								objOperationEqipmentQtyXML.strPingHengFuWeiQianXML =objReader.GetAttribute("PINGHENGFUWEIQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strPingHengFuWeiQianBeforeXML  =objReader.GetAttribute("PINGHENGFUWEIQIANBEFOREXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strPingHengFuWeiQianAfterXML =objReader.GetAttribute("PINGHENGFUWEIQIANAFTERXML").ToString().Replace ('五','\'');

								//************************************************
								objOperationEqipmentQtyXML.strWuChiNieXML=objReader.GetAttribute("WUCHINIEXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWuChiNieAfterXML=objReader.GetAttribute("WUCHINIEAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWuChiNieBeforeXML=objReader.GetAttribute("WUCHINIEBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strChangYaBanXML=objReader.GetAttribute("CHANGYABANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strChangYaBanAfterXML=objReader.GetAttribute("CHANGYABANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strChangYaBanBeforeXML=objReader.GetAttribute("CHANGYABANBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strDaoBing3XML=objReader.GetAttribute("DAOBING3XML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDaoBing3AfterXML=objReader.GetAttribute("DAOBING3AFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDaoBing3BeforeXML=objReader.GetAttribute("DAOBING3BEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strDaoBing4XML=objReader.GetAttribute("DAOBING4XML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDaoBing4AfterXML=objReader.GetAttribute("DAOBING4AFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDaoBing4BeforeXML=objReader.GetAttribute("DAOBING4BEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strDaoBing7XML=objReader.GetAttribute("DAOBING7XML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDaoBing7AfterXML=objReader.GetAttribute("DAOBING7AFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDaoBing7BeforeXML=objReader.GetAttribute("DAOBING7BEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strWuChiNieXML=objReader.GetAttribute("WUCHINIEXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWuChiNieAfterXML=objReader.GetAttribute("WUCHINIEAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWuChiNieBeforeXML=objReader.GetAttribute("WUCHINIEBEFOREXML").ToString().Replace ('五','\'');
								
							
								//************************************************
								objOperationEqipmentQtyXML.strZhiZhuZhiJianXML=objReader.GetAttribute("ZHIZHUZHIJIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhiZhuZhiJianBeforeXML=objReader.GetAttribute("ZHIZHUZHIJIANBEFOREXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhiZhuZhiJianAfterXML=objReader.GetAttribute("ZHIZHUZHIJIANAFTERXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strZhiJiaoXiaoLaGouXML=objReader.GetAttribute("ZHIJIAOXIAOLAGOUXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhiJiaoXiaoLaGouBeforeXML=objReader.GetAttribute("ZHIJIAOXIAOLAGOUBEFOREXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhiJiaoXiaoLaGouAfterXML=objReader.GetAttribute("ZHIJIAOXIAOLAGOUAFTERXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strXiongQiangJianXML=objReader.GetAttribute("XIONGQIANGJIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXiongQiangJianAfterXML=objReader.GetAttribute("XIONGQIANGJIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXiongQiangJianBeforeXML=objReader.GetAttribute("XIONGQIANGJIANBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strWanZhuZhiJianXML=objReader.GetAttribute("WANZHUZHIJIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWanZhuZhiJianBeforeXML=objReader.GetAttribute("WANZHUZHIJIANBEFOREXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWanZhuZhiJianAfterXML=objReader.GetAttribute("WANZHUZHIJIANAFTERXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strLanWeiLaGouXML=objReader.GetAttribute("LANWEILAGOUXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strLanWeiLaGouAfterXML=objReader.GetAttribute("LANWEILAGOUAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strLanWeiLaGouBeforeXML=objReader.GetAttribute("LANWEILAGOUBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strBianTaoXianJianXML=objReader.GetAttribute("BIANTAOXIANJIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strBianTaoXianJianBeforeXML=objReader.GetAttribute("BIANTAOXIANJIANBEFOREXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strBianTaoXianJianAfterXML=objReader.GetAttribute("BIANTAOXIANJIANAFTERXML").ToString().Replace ('五','\'');
								
							
								//************************************************
								objOperationEqipmentQtyXML.strChangYaGouXML=objReader.GetAttribute("CHANGYAGOUXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strChangYaGouAfterXML=objReader.GetAttribute("CHANGYAGOUAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strChangYaGouBeforeXML=objReader.GetAttribute("CHANGYAGOUBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strTongQuanXML=objReader.GetAttribute("TONGQUANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strTongQuanAfterXML=objReader.GetAttribute("TONGQUANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strTongQuanBeforeXML=objReader.GetAttribute("TONGQUANBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strXiaFuBuQianKaiQiXML=objReader.GetAttribute("XIAFUBUQIANKAIQIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXiaFuBuQianKaiQiAfterXML=objReader.GetAttribute("XIAFUBUQIANKAIQIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXiaFuBuQianKaiQiBeforeXML=objReader.GetAttribute("XIAFUBUQIANKAIQIBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strXiaFuBuQianKaiQiXML=objReader.GetAttribute("XIAFUBUQIANKAIQIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXiaFuBuQianKaiQiAfterXML=objReader.GetAttribute("XIAFUBUQIANKAIQIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXiaFuBuQianKaiQiBeforeXML=objReader.GetAttribute("XIAFUBUQIANKAIQIBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strXiYeGuanXML=objReader.GetAttribute("XIYEGUANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXiYeGuanAfterXML=objReader.GetAttribute("XIYEGUANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXiYeGuanBeforeXML=objReader.GetAttribute("XIYEGUANBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strZhiJiaoGouXML=objReader.GetAttribute("ZHIJIAOGOUXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhiJiaoGouAfterXML=objReader.GetAttribute("ZHIJIAOGOUAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhiJiaoGouBeforeXML=objReader.GetAttribute("ZHIJIAOGOUBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strZhongFuGouXML=objReader.GetAttribute("ZHONGFUGOUXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhongFuGouAfterXML=objReader.GetAttribute("ZHONGFUGOUAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhongFuGouBeforeXML=objReader.GetAttribute("ZHONGFUGOUBEFOREXML").ToString().Replace ('五','\'');
								
							
								//************************************************
								objOperationEqipmentQtyXML.strNianMoQianXML=objReader.GetAttribute("NIANMOQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strNianMoQianAfterXML=objReader.GetAttribute("NIANMOQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strNianMoQianBeforeXML=objReader.GetAttribute("NIANMOQIANBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strShaLiQianXML=objReader.GetAttribute("SHALIQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strShaLiQianAfterXML=objReader.GetAttribute("SHALIQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strShaLiQianBeforeXML=objReader.GetAttribute("SHALIQIANBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strWanXueGuanQian18XML=objReader.GetAttribute("WANXUEGUANQIAN18XML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWanXueGuanQian18AfterXML=objReader.GetAttribute("WANXUEGUANQIAN18AFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWanXueGuanQian18BeforeXML=objReader.GetAttribute("WANXUEGUANQIAN18BEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strWanXueGuanQian20XML=objReader.GetAttribute("WANXUEGUANQIAN20XML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWanXueGuanQian20AfterXML=objReader.GetAttribute("WANXUEGUANQIAN20AFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWanXueGuanQian20BeforeXML=objReader.GetAttribute("WANXUEGUANQIAN20BEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strWanXueGuanQian22XML=objReader.GetAttribute("WANXUEGUANQIAN22XML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWanXueGuanQian22AfterXML=objReader.GetAttribute("WANXUEGUANQIAN22AFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWanXueGuanQian22BeforeXML=objReader.GetAttribute("WANXUEGUANQIAN22BEFOREXML").ToString().Replace ('五','\'');
								
							
								//************************************************
								objOperationEqipmentQtyXML.strChangChiZhenQian25XML=objReader.GetAttribute("CHANGCHIZHENQIAN25XML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strChangChiZhenQian25AfterXML=objReader.GetAttribute("CHANGCHIZHENQIAN25AFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strChangChiZhenQian25BeforeXML=objReader.GetAttribute("CHANGCHIZHENQIAN25BEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strDaoPianXML=objReader.GetAttribute("DAOPIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDaoPianAfterXML=objReader.GetAttribute("DAOPIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDaoPianBeforeXML=objReader.GetAttribute("DAOPIANBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strDaZhiQianXML=objReader.GetAttribute("DAZHIQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDaZhiQianAfterXML=objReader.GetAttribute("DAZHIQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDaZhiQianBeforeXML=objReader.GetAttribute("DAZHIQIANBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strFengZhenXML=objReader.GetAttribute("FENGZHENXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strFengZhenAfterXML=objReader.GetAttribute("FENGZHENAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strFengZhenBeforeXML=objReader.GetAttribute("FENGZHENBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strZhiJiaoQianXML=objReader.GetAttribute("ZHIJIAOQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhiJiaoQianAfterXML=objReader.GetAttribute("ZHIJIAOQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhiJiaoQianBeforeXML=objReader.GetAttribute("ZHIJIAOQIANBEFOREXML").ToString().Replace ('五','\'');
								
							
								//************************************************
								objOperationEqipmentQtyXML.strChangQianZhiXML=objReader.GetAttribute("CHANGQIANZHIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strChangQianZhiAfterXML=objReader.GetAttribute("CHANGQIANZHIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strChangQianZhiBeforeXML=objReader.GetAttribute("CHANGQIANZHIBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strDaWanXueGuanQianXML=objReader.GetAttribute("DAWANXUEGUANQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDaWanXueGuanQianAfterXML=objReader.GetAttribute("DAWANXUEGUANQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDaWanXueGuanQianBeforeXML=objReader.GetAttribute("DAWANXUEGUANQIANBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strShenDiQianXML=objReader.GetAttribute("SHENDIQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strShenDiQianAfterXML=objReader.GetAttribute("SHENDIQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strShenDiQianBeforeXML=objReader.GetAttribute("SHENDIQIANBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strWanXueGuanQian25XML=objReader.GetAttribute("WANXUEGUANQIAN25XML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWanXueGuanQian25AfterXML=objReader.GetAttribute("WANXUEGUANQIAN25AFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWanXueGuanQian25BeforeXML=objReader.GetAttribute("WANXUEGUANQIAN25BEFOREXML").ToString().Replace ('五','\'');

								//************************************************
								objOperationEqipmentQtyXML.strChangQianWanXML=objReader.GetAttribute("CHANGQIANWANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strChangQianWanAfterXML=objReader.GetAttribute("CHANGQIANWANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strChangQianWanBeforeXML=objReader.GetAttribute("CHANGQIANWANBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strErYanHouChongXiQiXML=objReader.GetAttribute("ERYANHOUCHONGXIQIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strErYanHouChongXiQiAfterXML=objReader.GetAttribute("ERYANHOUCHONGXIQIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strErYanHouChongXiQiBeforeXML=objReader.GetAttribute("ERYANHOUCHONGXIQIBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strShiQianXML=objReader.GetAttribute("SHIQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strShiQianAfterXML=objReader.GetAttribute("SHIQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strShiQianBeforeXML=objReader.GetAttribute("SHIQIANBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strWeiQianXML=objReader.GetAttribute("WEIQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWeiQianAfterXML=objReader.GetAttribute("WEIQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWeiQianBeforeXML=objReader.GetAttribute("WEIQIANBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strXinErQianXML=objReader.GetAttribute("XINERQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXinErQiaAfterXML=objReader.GetAttribute("XINERQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXinErQiaBeforeXML=objReader.GetAttribute("XINERQIANBEFOREXML").ToString().Replace ('五','\'');
								
							
								//************************************************
								objOperationEqipmentQtyXML.strDanDaoTanTiaoXML=objReader.GetAttribute("DANDAOTANTIAOXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDanDaoTanTiaoAfterXML=objReader.GetAttribute("DANDAOTANTIAOAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDanDaoTanTiaoBeforeXML=objReader.GetAttribute("DANDAOTANTIAOBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strHeLongQiXML=objReader.GetAttribute("HELONGQIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strHeLongQiAfterXML=objReader.GetAttribute("HELONGQIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strHeLongQiBeforeXML=objReader.GetAttribute("HELONGQIBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strLeiGuQianKaiQiXML=objReader.GetAttribute("LEIGUQIANKAIQIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strLeiGuQianKaiQiAfterXML=objReader.GetAttribute("LEIGUQIANKAIQIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strLeiGuQianKaiQiBeforeXML=objReader.GetAttribute("LEIGUQIANKAIQIBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strTanZhenChuXML=objReader.GetAttribute("TANZHENCHUXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strTanZhenChuAfterXML=objReader.GetAttribute("TANZHENCHUAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strTanZhenChuBeforeXML=objReader.GetAttribute("TANZHENCHUBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strTanZhenXiXML=objReader.GetAttribute("TANZHENXIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strTanZhenXiAfterXML=objReader.GetAttribute("TANZHENXIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strTanZhenXiBeforeXML=objReader.GetAttribute("TANZHENXIBEFOREXML").ToString().Replace ('五','\'');
																
							
								//************************************************
								objOperationEqipmentQtyXML.strDaGuJianXML=objReader.GetAttribute("DAGUJIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDaGuJianAfterXML=objReader.GetAttribute("DAGUJIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDaGuJianBeforeXML=objReader.GetAttribute("DAGUJIANBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strDiErLeiGuJianXML=objReader.GetAttribute("DIERLEIGUJIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDiErLeiGuJianAfterXML=objReader.GetAttribute("DIERLEIGUJIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDiErLeiGuJianBeforeXML=objReader.GetAttribute("DIERLEIGUJIANBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strFangTouYaoGuQianXML=objReader.GetAttribute("FANGTOUYAOGUQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strFangTouYaoGuQianAfterXML=objReader.GetAttribute("FANGTOUYAOGUQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strFangTouYaoGuQianBeforeXML=objReader.GetAttribute("FANGTOUYAOGUQIANBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strJianJiaGuLaGouXML=objReader.GetAttribute("JIANJIAGULAGOUXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strJianJiaGuLaGouAfterXML=objReader.GetAttribute("JIANJIAGULAGOUAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strJianJiaGuLaGouBeforeXML=objReader.GetAttribute("JIANJIAGULAGOUBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strLeiGuQiZiXML=objReader.GetAttribute("LEIGUQIZIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strLeiGuQiZiAfterXML=objReader.GetAttribute("LEIGUQIZIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strLeiGuQiZiBeforeXML=objReader.GetAttribute("LEIGUQIZIBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strYaoGuQianXML=objReader.GetAttribute("YAOGUQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strYaoGuQianAfterXML=objReader.GetAttribute("YAOGUQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strYaoGuQianBeforeXML=objReader.GetAttribute("YAOGUQIANBEFOREXML").ToString().Replace ('五','\'');
								
							
								//************************************************
								objOperationEqipmentQtyXML.strChiGuQianXML=objReader.GetAttribute("CHIGUQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strChiGuQianAfterXML=objReader.GetAttribute("CHIGUQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strChiGuQianBeforeXML=objReader.GetAttribute("CHIGUQIANBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strGuChuiXML=objReader.GetAttribute("GUCHUIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strGuChuiAfterXML=objReader.GetAttribute("GUCHUIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strGuChuiBeforeXML=objReader.GetAttribute("GUCHUIBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strGuDaoXML=objReader.GetAttribute("GUDAOXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strGuDaoAfterXML=objReader.GetAttribute("GUDAOAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strGuDaoBeforeXML=objReader.GetAttribute("GUDAOBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strGuMoBoLiQiXML=objReader.GetAttribute("GUMOBOLIQIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strGuMoBoLiQiAfterXML=objReader.GetAttribute("GUMOBOLIQIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strGuMoBoLiQiBeforeXML=objReader.GetAttribute("GUMOBOLIQIBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strGuZaoXML=objReader.GetAttribute("GUZAOXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strGuZaoAfterXML=objReader.GetAttribute("GUZAOAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strGuZaoBeforeXML=objReader.GetAttribute("GUZAOBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strKuoShiXML=objReader.GetAttribute("KUOSHIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strKuoShiAfterXML=objReader.GetAttribute("KUOSHIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strKuoShiBeforeXML=objReader.GetAttribute("KUOSHIBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strLeiGuQiZiXML=objReader.GetAttribute("LEIGUQIZIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strLeiGuQiZiAfterXML=objReader.GetAttribute("LEIGUQIZIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strLeiGuQiZiBeforeXML=objReader.GetAttribute("LEIGUQIZIBEFOREXML").ToString().Replace ('五','\'');
								
							
								//************************************************
								objOperationEqipmentQtyXML.strDanChiLaGouXML=objReader.GetAttribute("DANCHILAGOUXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDanChiLaGouAfterXML=objReader.GetAttribute("DANCHILAGOUAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDanChiLaGouBeforeXML=objReader.GetAttribute("DANCHILAGOUBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strDaoXiangQiXML=objReader.GetAttribute("DAOXIANGQIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDaoXiangQiAfterXML=objReader.GetAttribute("DAOXIANGQIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDaoXiangQiBeforeXML=objReader.GetAttribute("DAOXIANGQIBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strJingGuQiZiXML=objReader.GetAttribute("JINGGUQIZIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strJingGuQiZiAfterXML=objReader.GetAttribute("JINGGUQIZIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strJingGuQiZiBeforeXML=objReader.GetAttribute("JINGGUQIZIBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strLaoHuQianXML=objReader.GetAttribute("LAOHUQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strLaoHuQianAfterXML=objReader.GetAttribute("LAOHUQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strLaoHuQianBeforeXML=objReader.GetAttribute("LAOHUQIANBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strLuoSiQiZiXML=objReader.GetAttribute("LUOSIQIZIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strLuoSiQiZiAfterXML=objReader.GetAttribute("LUOSIQIZIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strLuoSiQiZiBeforeXML=objReader.GetAttribute("LUOSIQIZIBEFOREXML").ToString().Replace ('五','\'');
								
								
								//************************************************
								objOperationEqipmentQtyXML.strJianBoLiZiXML=objReader.GetAttribute("JIANBOLIZIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strJianBoLiZiAfterXML=objReader.GetAttribute("JIANBOLIZIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strJianBoLiZiBeforeXML=objReader.GetAttribute("JIANBOLIZIBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strJingTuJianXML=objReader.GetAttribute("JINGTUJIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strJingTuJianAfterXML=objReader.GetAttribute("JINGTUJIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strJingTuJianBeforeXML=objReader.GetAttribute("JINGTUJIANBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strQiangZhuangNieXML=objReader.GetAttribute("QIANGZHUANGNIEXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strQiangZhuangNieAfterXML=objReader.GetAttribute("QIANGZHUANGNIEAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strQiangZhuangNieBeforeXML=objReader.GetAttribute("QIANGZHUANGNIEBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strShuiHeQianXML=objReader.GetAttribute("SHUIHEQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strShuiHeQianAfterXML=objReader.GetAttribute("SHUIHEQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strShuiHeQianBeforeXML=objReader.GetAttribute("SHUIHEQIANBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strZhuiBanBoLiQiXML=objReader.GetAttribute("ZHUIBANBOLIQIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhuiBanBoLiQiAfterXML=objReader.GetAttribute("ZHUIBANBOLIQIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhuiBanBoLiQiBeforeXML=objReader.GetAttribute("ZHUIBANBOLIQIBEFOREXML").ToString().Replace ('五','\'');
								
								
								//************************************************
								objOperationEqipmentQtyXML.strBaiShiQianKaiQiXML=objReader.GetAttribute("BAISHIQIANKAIQIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strBaiShiQianKaiQiAfterXML=objReader.GetAttribute("BAISHIQIANKAIQIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strBaiShiQianKaiQiBeforeXML=objReader.GetAttribute("BAISHIQIANKAIQIBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strChiBanQianXML=objReader.GetAttribute("CHIBANQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strChiBanQianAfterXML=objReader.GetAttribute("CHIBANQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strChiBanQianBeforeXML=objReader.GetAttribute("CHIBANQIANBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strKaiLuZhuanXML=objReader.GetAttribute("KAILUZHUANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strKaiLuZhuanAfterXML=objReader.GetAttribute("KAILUZHUANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strKaiLuZhuanBeforeXML=objReader.GetAttribute("KAILUZHUANBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strTouPiJianQianXML=objReader.GetAttribute("TOUPIJIANQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strTouPiJianQianAfterXML=objReader.GetAttribute("TOUPIJIANQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strTouPiJianQianBeforeXML=objReader.GetAttribute("TOUPIJIANQIANBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strXianJuDaoYinZiXML=objReader.GetAttribute("XIANJUDAOYINZIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXianJuDaoYinZiAfterXML=objReader.GetAttribute("XIANJUDAOYINZIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXianJuDaoYinZiBeforeXML=objReader.GetAttribute("XIANJUDAOYINZIBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strXinErLaGouXML=objReader.GetAttribute("XINERLAGOUXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXinErLaGouAfterXML=objReader.GetAttribute("XINERLAGOUAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXinErLaGouBeforeXML=objReader.GetAttribute("XINERLAGOUBEFOREXML").ToString().Replace ('五','\'');
								
								
								//************************************************
								objOperationEqipmentQtyXML.strChuanCiZhenXML=objReader.GetAttribute("CHUANCIZHENXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strChuanCiZhenAfterXML=objReader.GetAttribute("CHUANCIZHENAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strChuanCiZhenBeforeXML=objReader.GetAttribute("CHUANCIZHENBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strFeiYeDangBanXML=objReader.GetAttribute("FEIYEDANGBANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strFeiYeDangBanAfterXML=objReader.GetAttribute("FEIYEDANGBANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strFeiYeDangBanBeforeXML=objReader.GetAttribute("FEIYEDANGBANBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strNaoMoGouXML=objReader.GetAttribute("NAOMOGOUXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strNaoMoGouAfterXML=objReader.GetAttribute("NAOMOGOUAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strNaoMoGouBeforeXML=objReader.GetAttribute("NAOMOGOUBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strXinFangLaGouXML=objReader.GetAttribute("XINFANGLAGOUXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXinFangLaGouAfterXML=objReader.GetAttribute("XINFANGLAGOUAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXinFangLaGouBeforeXML=objReader.GetAttribute("XINFANGLAGOUBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strYinDingQianXML=objReader.GetAttribute("YINDINGQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strYinDingQianAfterXML=objReader.GetAttribute("YINDINGQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strYinDingQianBeforeXML=objReader.GetAttribute("YINDINGQIANBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strZhuAZhuDuanQianXML=objReader.GetAttribute("ZHUAZHUDUANQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhuAZhuDuanQianAfterXML=objReader.GetAttribute("ZHUAZHUDUANQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhuAZhuDuanQianBeforeXML=objReader.GetAttribute("ZHUAZHUDUANQIANBEFOREXML").ToString().Replace ('五','\'');
								
								
								//************************************************
								objOperationEqipmentQtyXML.strCeBanQiXML=objReader.GetAttribute("CEBANQIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strCeBanQiAfterXML=objReader.GetAttribute("CEBANQIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strCeBanQiBeforeXML=objReader.GetAttribute("CEBANQIBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strDaoXianGouXML=objReader.GetAttribute("DAOXIANGOUXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDaoXianGouAfterXML=objReader.GetAttribute("DAOXIANGOUAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDaoXianGouBeforeXML=objReader.GetAttribute("DAOXIANGOUBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strErJianBanKuoZhangQiXML=objReader.GetAttribute("ERJIANBANKUOZHANGQIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strErJianBanKuoZhangQiAfterXML=objReader.GetAttribute("ERJIANBANKUOZHANGQIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strErJianBanKuoZhangQiBeforeXML=objReader.GetAttribute("ERJIANBANKUOZHANGQIBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strXinNeiZhiJiaoLaGouXML=objReader.GetAttribute("XINNEIZHIJIAOLAGOUXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXinNeiZhiJiaoLaGouAfterXML=objReader.GetAttribute("XINNEIZHIJIAOLAGOUAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXinNeiZhiJiaoLaGouBeforeXML=objReader.GetAttribute("XINNEIZHIJIAOLAGOUBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strZhuACeBiQianXML=objReader.GetAttribute("ZHUACEBIQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhuACeBiQiAfterXML=objReader.GetAttribute("ZHUACEBIQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhuACeBiQiBeforeXML=objReader.GetAttribute("ZHUACEBIQIANBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strZhuAYouLiQianXML=objReader.GetAttribute("ZHUAYOULIQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhuAYouLiQianAfterXML=objReader.GetAttribute("ZHUAYOULIQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhuAYouLiQianBeforeXML=objReader.GetAttribute("ZHUAYOULIQIANBEFOREXML").ToString().Replace ('五','\'');
								
								
								//************************************************
								objOperationEqipmentQtyXML.strFuKuiXML=objReader.GetAttribute("FUKUIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strFuKuiAfterXML=objReader.GetAttribute("FUKUIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strFuKuiBeforeXML=objReader.GetAttribute("FUKUIBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strGongChiXML=objReader.GetAttribute("GONGCHIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strGongChiAfterXML=objReader.GetAttribute("GONGCHIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strGongChiBeforeXML=objReader.GetAttribute("GONGCHIBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strKaChiXML=objReader.GetAttribute("KACHIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strKaChiAfterXML=objReader.GetAttribute("KACHIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strKaChiBeforeXML=objReader.GetAttribute("KACHIBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strShenJingLaGouXML=objReader.GetAttribute("SHENJINGLAGOUXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strShenJingLaGouAfterXML=objReader.GetAttribute("SHENJINGLAGOUAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strShenJingLaGouBeforeXML=objReader.GetAttribute("SHENJINGLAGOUBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strWuChuangNieXML=objReader.GetAttribute("WUCHUANGNIEXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWuChuangNieAfterXML=objReader.GetAttribute("WUCHUANGNIEAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWuChuangNieBeforeXML=objReader.GetAttribute("WUCHUANGNIEBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strXueGuanJiaXML=objReader.GetAttribute("XUEGUANJIAXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXueGuanJiaAfterXML=objReader.GetAttribute("XUEGUANJIAAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXueGuanJiaBeforeXML=objReader.GetAttribute("XUEGUANJIABEFOREXML").ToString().Replace ('五','\'');
								
								
								//************************************************
								objOperationEqipmentQtyXML.strGongGuaShiXML=objReader.GetAttribute("GONGGUASHIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strGongGuaShiAfterXML=objReader.GetAttribute("GONGGUASHIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strGongGuaShiBeforeXML=objReader.GetAttribute("GONGGUASHIBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strGongJingQianXML=objReader.GetAttribute("GONGJINGQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strGongJingQianAfterXML=objReader.GetAttribute("GONGJINGQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strGongJingQianBeforeXML=objReader.GetAttribute("GONGJINGQIANBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strJiLiuBoLiZiXML=objReader.GetAttribute("JINSHUNIAOGOU").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strJiLiuBoLiZiAfterXML=objReader.GetAttribute("JINSHUNIAOGOUAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strJiLiuBoLiZiBeforeXML=objReader.GetAttribute("JINSHUNIAOGOUBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strKuoGongQiXML=objReader.GetAttribute("KUOGONGQIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strKuoGongQiAfterXML=objReader.GetAttribute("KUOGONGQIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strKuoGongQiBeforeXML=objReader.GetAttribute("KUOGONGQIBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strRenDaiQianXML=objReader.GetAttribute("RENDAIQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strRenDaiQianAfterXML=objReader.GetAttribute("RENDAIQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strRenDaiQianBeforeXML=objReader.GetAttribute("RENDAIQIANBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strYinDaoLaGouXML=objReader.GetAttribute("YINDAOLAGOUXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strYinDaoLaGouAfterXML=objReader.GetAttribute("YINDAOLAGOUAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strYinDaoLaGouBeforeXML=objReader.GetAttribute("YINDAOLAGOUBEFOREXML").ToString().Replace ('五','\'');
								
								
								//************************************************
								objOperationEqipmentQtyXML.strFuGuoQianXML=objReader.GetAttribute("FUGUOQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strFuGuoQianAfterXML=objReader.GetAttribute("FUGUOQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strFuGuoQianBeforeXML=objReader.GetAttribute("FUGUOQIANBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strJinShuNiaoGouXML=objReader.GetAttribute("JINSHUNIAOGOUXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strJinShuNiaoGouAfterXML=objReader.GetAttribute("JINSHUNIAOGOUAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strJinShuNiaoGouBeforeXML=objReader.GetAttribute("JINSHUNIAOGOUBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strWuDaiChangDianXML=objReader.GetAttribute("WUDAICHANGDIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWuDaiChangDianAfterXML=objReader.GetAttribute("WUDAICHANGDIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWuDaiChangDianBeforeXML=objReader.GetAttribute("WUDAICHANGDIANBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strWuDaiFangDianXML=objReader.GetAttribute("WUDAIFANGDIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWuDaiFangDianAfterXML=objReader.GetAttribute("WUDAIFANGDIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWuDaiFangDianBeforeXML=objReader.GetAttribute("WUDAIFANGDIANBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strYouDaiChangDianXML=objReader.GetAttribute("YOUDAICHANGDIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strYouDaiChangDianAfterXML=objReader.GetAttribute("YOUDAICHANGDIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strYouDaiChangDianBeforeXML=objReader.GetAttribute("YOUDAICHANGDIANBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strYouDaiFangDianXML=objReader.GetAttribute("YOUDAIFANGDIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strYouDaiFangDianAfterXML=objReader.GetAttribute("YOUDAIFANGDIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strYouDaiFangDianBeforeXML=objReader.GetAttribute("YOUDAIFANGDIANBEFOREXML").ToString().Replace ('五','\'');
								
								
								//************************************************
								objOperationEqipmentQtyXML.strFuNieYinLiuXML=objReader.GetAttribute("FUNIEYINLIUXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strFuNieYinLiuAfterXML=objReader.GetAttribute("FUNIEYINLIUAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strFuNieYinLiuBeforeXML=objReader.GetAttribute("FUNIEYINLIUBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strKaiLuMianXML=objReader.GetAttribute("KAILUMIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strKaiLuMianAfterXML=objReader.GetAttribute("KAILUMIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strKaiLuMianBeforeXML=objReader.GetAttribute("KAILUMIANBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strQuanGongShaXML=objReader.GetAttribute("QUANGONGSHAXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strQuanGongShaAfterXML=objReader.GetAttribute("QUANGONGSHAAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strQuanGongShaBeforeXML=objReader.GetAttribute("QUANGONGSHABEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strShaKuaiXML=objReader.GetAttribute("SHAKUAIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strShaKuaiAfterXML=objReader.GetAttribute("SHAKUAIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strShaKuaiBeforeXML=objReader.GetAttribute("SHAKUAIBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strShaQiuXML=objReader.GetAttribute("SHAQIUXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strShaQiuAfterXML=objReader.GetAttribute("SHAQIUAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strShaQiuBeforeXML=objReader.GetAttribute("SHAQIUBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strWangShaXML=objReader.GetAttribute("WANGSHAXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWangShaAfterXML=objReader.GetAttribute("WANGSHAAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWangShaBeforeXML=objReader.GetAttribute("WANGSHABEFOREXML").ToString().Replace ('五','\'');
								

								//************************************************
								objOperationEqipmentQtyXML.strBianDaiXML=objReader.GetAttribute("BIANDAIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strBianDaiAfterXML=objReader.GetAttribute("BIANDAIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strBianDaiBeforeXML=objReader.GetAttribute("BIANDAIBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strChangQianTaoXML=objReader.GetAttribute("CHANGQIANTAOXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strChangQianTaoAfterXML=objReader.GetAttribute("CHANGQIANTAOAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strChangQianTaoBeforeXML=objReader.GetAttribute("CHANGQIANTAOBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strNiaoGuanXML=objReader.GetAttribute("NIAOGUANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strNiaoGuanAfterXML=objReader.GetAttribute("NIAOGUANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strNiaoGuanBeforeXML=objReader.GetAttribute("NIAOGUANBEFOREXML").ToString().Replace ('五','\'');

								m_objPackage.m_objOperationEqipmentQtyXML =objOperationEqipmentQtyXML;


								#endregion

							}
							break;
					}
				}
				objclsOperationEquipmentPackage=m_objPackage;
			}			
			return m_intReturnRows;
		}

		public long lngSelectDeletedDisply(string strInPatientID, string strInPatientDate,string strOpenDate,out clsOperationEquipmentPackage objclsOperationEquipmentPackage)
		{
			objclsOperationEquipmentPackage=null;
			#region 隅砱曹講
			string m_strReceivedXML="";
			int m_intReturnRows=0;
			//隅砱Package
			clsOperationEquipmentPackage m_objPackage = new clsOperationEquipmentPackage();
			
			//隅砱翋桶
			clsOperationEqipmentQtyXML objOperationEqipmentQtyXML=new clsOperationEqipmentQtyXML(); 
			
			//隅砱赽桶
			clsOperationEqipmentQtyContent objOperationEqipmentQtyContent=new clsOperationEqipmentQtyContent(); 
			#endregion

			long lngSucceed = 0;
            com.digitalwave.OperationEquipmentQtyService.clsOperationEquipmentQtyService m_objServ =
                (com.digitalwave.OperationEquipmentQtyService.clsOperationEquipmentQtyService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.OperationEquipmentQtyService.clsOperationEquipmentQtyService));

            try
            {
                lngSucceed=m_objServ.m_lngGetDeletedRecordXMLTable(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,strInPatientID,strInPatientDate,strOpenDate,ref m_strReceivedXML,ref m_intReturnRows);
            }
            finally
            {
                //m_objServ.Dispose();
            }
			if(m_intReturnRows>0)
			{
				XmlTextReader objReader = new XmlTextReader(m_strReceivedXML,XmlNodeType.Element,m_objXmlParser);
				objReader.WhitespaceHandling = WhitespaceHandling.None;
			
				while(objReader.Read())
				{
					switch(objReader.NodeType)
					{
						case XmlNodeType.Element:
							if(objReader.HasAttributes)
							{

								#region 赽桶
								objOperationEqipmentQtyContent.strInPatientID=objReader.GetAttribute("INPATIENTID").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strInPatientDate=objReader.GetAttribute("INPATIENTDATE").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strOpenDate=objReader.GetAttribute("OPENDATE").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strModifyDate=objReader.GetAttribute("MODIFYDATE").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strModifyUserID=objReader.GetAttribute("MODIFYUSERID").ToString().Replace ('五','\'');

								//								objOperationEqipmentQtyContent.strOperationID=objReader.GetAttribute("INPATIENTID").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strOperationName=objReader.GetAttribute("OPERATIONNAME").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strWenWan125=objReader.GetAttribute("WENWAN125").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWenWan125After=objReader.GetAttribute("WENWAN125AFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWenWan125Before=objReader.GetAttribute("WENWAN125BEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strWenZhi125=objReader.GetAttribute("WENZHI125").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWenZhi125After=objReader.GetAttribute("WENZHI125AFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWenZhi125Before=objReader.GetAttribute("WENZHI125BEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strXiaoWan14=objReader.GetAttribute("XIAOWAN14").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strXiaoWan14After=objReader.GetAttribute("XIAOWAN14AFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strXiaoWan14Before=objReader.GetAttribute("XIAOWAN14BEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strXiaoZhi14=objReader.GetAttribute("XIAOZHI14").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strXiaoZhi14After=objReader.GetAttribute("XIAOZHI14AFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strXiaoZhi14Before=objReader.GetAttribute("XIAOZHI14BEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strZhongWan16=objReader.GetAttribute("ZHONGWAN16").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhongWan16After=objReader.GetAttribute("ZHONGWAN16AFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhongWan16Before=objReader.GetAttribute("ZHONGWAN16BEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strZhongZhi16=objReader.GetAttribute("ZHONGZHI16").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhongZhi16After=objReader.GetAttribute("ZHONGZHI16AFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhongZhi16Before=objReader.GetAttribute("ZHONGZHI16BEFORE").ToString().Replace ('五','\'');
								
								
								//************************************************
								objOperationEqipmentQtyContent.strPiQian=objReader.GetAttribute("PIQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strPiQianAfter=objReader.GetAttribute("PIQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strPiQianBefore=objReader.GetAttribute("PIQIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strZhiYouChiXueGuanQian=objReader.GetAttribute("ZHIYOUCHIXUEGUANQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhiYouChiXueGuanQianAfter=objReader.GetAttribute("ZHIYOUCHIXUEGUANQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhiYouChiXueGuanQianBefore=objReader.GetAttribute("ZHIYOUCHIXUEGUANQIANBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strQuanQian=objReader.GetAttribute("QUANQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strQuanQianAfter=objReader.GetAttribute("QUANQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strQuanQianBefore=objReader.GetAttribute("QUANQIANBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strJinQian=objReader.GetAttribute("JINQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strJinQianAfter=objReader.GetAttribute("JINQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strJinQianBefore=objReader.GetAttribute("JINQIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strChiZhenQian18=objReader.GetAttribute("CHIZHENQIAN18").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strChiZhenQian18After=objReader.GetAttribute("CHIZHENQIAN18AFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strChiZhenQian18Before=objReader.GetAttribute("CHIZHENQIAN18BEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strYouChiNie=objReader.GetAttribute("YOUCHINIE").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strYouChiNieAfter=objReader.GetAttribute("YOUCHINIEAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strYouChiNieBefore=objReader.GetAttribute("YOUCHINIEBEFORE").ToString().Replace ('五','\'');
								
							
								//************************************************
								objOperationEqipmentQtyContent.strWuChiNie=objReader.GetAttribute("WUCHINIE").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWuChiNieAfter=objReader.GetAttribute("WUCHINIEAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWuChiNieBefore=objReader.GetAttribute("WUCHINIEBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strChangYaBan=objReader.GetAttribute("CHANGYABAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strChangYaBanAfter=objReader.GetAttribute("CHANGYABANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strChangYaBanBefore=objReader.GetAttribute("CHANGYABANBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strDaoBing3=objReader.GetAttribute("DAOBING3").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDaoBing3After=objReader.GetAttribute("DAOBING3AFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDaoBing3Before=objReader.GetAttribute("DAOBING3BEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strDaoBing4=objReader.GetAttribute("DAOBING4").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDaoBing4After=objReader.GetAttribute("DAOBING4AFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDaoBing4Before=objReader.GetAttribute("DAOBING4BEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strDaoBing7=objReader.GetAttribute("DAOBING7").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDaoBing7After=objReader.GetAttribute("DAOBING7AFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDaoBing7Before=objReader.GetAttribute("DAOBING7BEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strWuChiNie=objReader.GetAttribute("WUCHINIE").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWuChiNieAfter=objReader.GetAttribute("WUCHINIEAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWuChiNieBefore=objReader.GetAttribute("WUCHINIEBEFORE").ToString().Replace ('五','\'');
								
							
								//************************************************
								objOperationEqipmentQtyContent.strZhiZhuZhiJian=objReader.GetAttribute("ZHIZHUZHIJIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhiZhuZhiJianAfter=objReader.GetAttribute("ZHIZHUZHIJIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhiZhuZhiJianBefore=objReader.GetAttribute("ZHIZHUZHIJIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strWanZhuZhiJian=objReader.GetAttribute("WANZHUZHIJIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWanZhuZhiJianAfter=objReader.GetAttribute("WANZHUZHIJIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWanZhuZhiJianBefore=objReader.GetAttribute("WANZHUZHIJIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strBianTaoXianJian=objReader.GetAttribute("BIANTAOXIANJIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strBianTaoXianJianAfter=objReader.GetAttribute("BIANTAOXIANJIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strBianTaoXianJianBefore=objReader.GetAttribute("BIANTAOXIANJIANBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strXiongQiangJian=objReader.GetAttribute("XIONGQIANGJIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strXiongQiangJianAfter=objReader.GetAttribute("XIONGQIANGJIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strXiongQiangJianBefore=objReader.GetAttribute("XIONGQIANGJIANBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strZhiJiaoXiaoLaGou=objReader.GetAttribute("ZHIJIAOXIAOLAGOU").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhiJiaoXiaoLaGouAfter=objReader.GetAttribute("ZHIJIAOXIAOLAGOUAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhiJiaoXiaoLaGouBefore=objReader.GetAttribute("ZHIJIAOXIAOLAGOUBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strLanWeiLaGou=objReader.GetAttribute("LANWEILAGOU").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strLanWeiLaGouAfter=objReader.GetAttribute("LANWEILAGOUAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strLanWeiLaGouBefore=objReader.GetAttribute("LANWEILAGOUBEFORE").ToString().Replace ('五','\'');
								
							
								//************************************************
								objOperationEqipmentQtyContent.strZhongFuGou=objReader.GetAttribute("ZHONGFUGOU").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhongFuGouAfter=objReader.GetAttribute("ZHONGFUGOUAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhongFuGouBefore=objReader.GetAttribute("ZHONGFUGOUBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strChangYaGou=objReader.GetAttribute("CHANGYAGOU").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strChangYaGouAfter=objReader.GetAttribute("CHANGYAGOUAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strChangYaGouBefore=objReader.GetAttribute("CHANGYAGOUBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strZhiJiaoQian=objReader.GetAttribute("ZHIJIAOQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhiJiaoQianAfter=objReader.GetAttribute("ZHIJIAOQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhiJiaoQianBefore=objReader.GetAttribute("ZHIJIAOQIANBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strXiaFuBuQianKaiQi=objReader.GetAttribute("XIAFUBUQIANKAIQI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strXiaFuBuQianKaiQiAfter=objReader.GetAttribute("XIAFUBUQIANKAIQIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strXiaFuBuQianKaiQiBefore=objReader.GetAttribute("XIAFUBUQIANKAIQIBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strTongQuan=objReader.GetAttribute("TONGQUAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strTongQuanAfter=objReader.GetAttribute("TONGQUANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strTongQuanBefore=objReader.GetAttribute("TONGQUANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strXiYeGuan=objReader.GetAttribute("XIYEGUAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strXiYeGuanAfter=objReader.GetAttribute("XIYEGUANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strXiYeGuanBefore=objReader.GetAttribute("XIYEGUANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strDaZhiQian=objReader.GetAttribute("DAZHIQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDaZhiQianAfter=objReader.GetAttribute("DAZHIQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDaZhiQianBefore=objReader.GetAttribute("DAZHIQIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strZhiJiaoGou=objReader.GetAttribute("ZHIJIAOGOU").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhiJiaoGouAfter=objReader.GetAttribute("ZHIJIAOGOUAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhiJiaoGouBefore=objReader.GetAttribute("ZHIJIAOGOUBEFORE").ToString().Replace ('五','\'');
								
							
								//************************************************
								objOperationEqipmentQtyContent.strDaoPian=objReader.GetAttribute("DAOPIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDaoPianAfter=objReader.GetAttribute("DAOPIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDaoPianBefore=objReader.GetAttribute("DAOPIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strWanXueGuanQian18=objReader.GetAttribute("WANXUEGUANQIAN18").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWanXueGuanQian18After=objReader.GetAttribute("WANXUEGUANQIAN18AFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWanXueGuanQian18Before=objReader.GetAttribute("WANXUEGUANQIAN18BEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strWanXueGuanQian22=objReader.GetAttribute("WANXUEGUANQIAN22").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWanXueGuanQian22After=objReader.GetAttribute("WANXUEGUANQIAN22AFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWanXueGuanQian22Before=objReader.GetAttribute("WANXUEGUANQIAN22BEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strChangChiZhenQian25=objReader.GetAttribute("CHANGCHIZHENQIAN25").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strChangChiZhenQian25After=objReader.GetAttribute("CHANGCHIZHENQIAN25AFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strChangChiZhenQian25Before=objReader.GetAttribute("CHANGCHIZHENQIAN25BEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strFengZhen=objReader.GetAttribute("FENGZHEN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strFengZhenAfter=objReader.GetAttribute("FENGZHENAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strFengZhenBefore=objReader.GetAttribute("FENGZHENBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strNianMoQian=objReader.GetAttribute("NIANMOQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strNianMoQianAfter=objReader.GetAttribute("NIANMOQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strNianMoQianBefore=objReader.GetAttribute("NIANMOQIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strShaLiQian=objReader.GetAttribute("SHALIQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strShaLiQianAfter=objReader.GetAttribute("SHALIQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strShaLiQianBefore=objReader.GetAttribute("SHALIQIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strShaLiQian=objReader.GetAttribute("SHALIQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strShaLiQianAfter=objReader.GetAttribute("SHALIQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strShaLiQianBefore=objReader.GetAttribute("SHALIQIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strWanXueGuanQian20=objReader.GetAttribute("WANXUEGUANQIAN20").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWanXueGuanQian20After=objReader.GetAttribute("WANXUEGUANQIAN20AFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWanXueGuanQian20Before=objReader.GetAttribute("WANXUEGUANQIAN20BEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strWanXueGuanQian25=objReader.GetAttribute("WANXUEGUANQIAN25").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWanXueGuanQian25After=objReader.GetAttribute("WANXUEGUANQIAN25AFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWanXueGuanQian25Before=objReader.GetAttribute("WANXUEGUANQIAN25BEFORE").ToString().Replace ('五','\'');
								
							
								//************************************************
								objOperationEqipmentQtyContent.strChangQianWan=objReader.GetAttribute("CHANGQIANWAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strChangQianWanAfter=objReader.GetAttribute("CHANGQIANWANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strChangQianWanBefore=objReader.GetAttribute("CHANGQIANWANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strChangQianZhi=objReader.GetAttribute("CHANGQIANZHI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strChangQianZhiAfter=objReader.GetAttribute("CHANGQIANZHIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strChangQianZhiBefore=objReader.GetAttribute("CHANGQIANZHIBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strDaWanXueGuanQian=objReader.GetAttribute("DAWANXUEGUANQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDaWanXueGuanQianAfter=objReader.GetAttribute("DAWANXUEGUANQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDaWanXueGuanQianBefore=objReader.GetAttribute("DAWANXUEGUANQIANBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strErYanHouChongXiQi=objReader.GetAttribute("ERYANHOUCHONGXIQI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strErYanHouChongXiQiAfter=objReader.GetAttribute("ERYANHOUCHONGXIQIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strErYanHouChongXiQiBefore=objReader.GetAttribute("ERYANHOUCHONGXIQIBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strShenDiQian=objReader.GetAttribute("SHENDIQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strShenDiQianAfter=objReader.GetAttribute("SHENDIQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strShenDiQianBefore=objReader.GetAttribute("SHENDIQIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strShiQian=objReader.GetAttribute("SHIQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strShiQianAfter=objReader.GetAttribute("SHIQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strShiQianBefore=objReader.GetAttribute("SHIQIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strWeiQian=objReader.GetAttribute("WEIQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWeiQianAfter=objReader.GetAttribute("WEIQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWeiQianBefore=objReader.GetAttribute("WEIQIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strXinErQian=objReader.GetAttribute("XINERQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strXinErQiaAfter=objReader.GetAttribute("XINERQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strXinErQiaBefore=objReader.GetAttribute("XINERQIANBEFORE").ToString().Replace ('五','\'');
								
							
								//************************************************
								objOperationEqipmentQtyContent.strDaGuJian=objReader.GetAttribute("DAGUJIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDaGuJianAfter=objReader.GetAttribute("DAGUJIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDaGuJianBefore=objReader.GetAttribute("DAGUJIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strDanDaoTanTiao=objReader.GetAttribute("DANDAOTANTIAO").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDanDaoTanTiaoAfter=objReader.GetAttribute("DANDAOTANTIAOAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDanDaoTanTiaoBefore=objReader.GetAttribute("DANDAOTANTIAOBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strDiErLeiGuJian=objReader.GetAttribute("DIERLEIGUJIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDiErLeiGuJianAfter=objReader.GetAttribute("DIERLEIGUJIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDiErLeiGuJianBefore=objReader.GetAttribute("DIERLEIGUJIANBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strFangTouYaoGuQian=objReader.GetAttribute("FANGTOUYAOGUQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strFangTouYaoGuQianAfter=objReader.GetAttribute("FANGTOUYAOGUQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strFangTouYaoGuQianBefore=objReader.GetAttribute("FANGTOUYAOGUQIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strHeLongQi=objReader.GetAttribute("HELONGQI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strHeLongQiAfter=objReader.GetAttribute("HELONGQIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strHeLongQiBefore=objReader.GetAttribute("HELONGQIBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strJianJiaGuLaGou=objReader.GetAttribute("JIANJIAGULAGOU").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strJianJiaGuLaGouAfter=objReader.GetAttribute("JIANJIAGULAGOUAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strJianJiaGuLaGouBefore=objReader.GetAttribute("JIANJIAGULAGOUBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strLeiGuQianKaiQi=objReader.GetAttribute("LEIGUQIANKAIQI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strLeiGuQianKaiQiAfter=objReader.GetAttribute("LEIGUQIANKAIQIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strLeiGuQianKaiQiBefore=objReader.GetAttribute("LEIGUQIANKAIQIBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strLeiGuQiZi=objReader.GetAttribute("LEIGUQIZI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strLeiGuQiZiAfter=objReader.GetAttribute("LEIGUQIZIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strLeiGuQiZiBefore=objReader.GetAttribute("LEIGUQIZIBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strTanZhenChu=objReader.GetAttribute("TANZHENCHU").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strTanZhenChuAfter=objReader.GetAttribute("TANZHENCHUAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strTanZhenChuBefore=objReader.GetAttribute("TANZHENCHUBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strTanZhenXi=objReader.GetAttribute("TANZHENXI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strTanZhenXiAfter=objReader.GetAttribute("TANZHENXIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strTanZhenXiBefore=objReader.GetAttribute("TANZHENXIBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strYaoGuQian=objReader.GetAttribute("YAOGUQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strYaoGuQianAfter=objReader.GetAttribute("YAOGUQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strYaoGuQianBefore=objReader.GetAttribute("YAOGUQIANBEFORE").ToString().Replace ('五','\'');
								

								//************************************************
								objOperationEqipmentQtyContent.strChiGuQian=objReader.GetAttribute("CHIGUQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strChiGuQianAfter=objReader.GetAttribute("CHIGUQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strChiGuQianBefore=objReader.GetAttribute("CHIGUQIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strDanChiLaGou=objReader.GetAttribute("DANCHILAGOU").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDanChiLaGouAfter=objReader.GetAttribute("DANCHILAGOUAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDanChiLaGouBefore=objReader.GetAttribute("DANCHILAGOUBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strDaoXiangQi=objReader.GetAttribute("DAOXIANGQI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDaoXiangQiAfter=objReader.GetAttribute("DAOXIANGQIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDaoXiangQiBefore=objReader.GetAttribute("DAOXIANGQIBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strGuChui=objReader.GetAttribute("GUCHUI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strGuChuiAfter=objReader.GetAttribute("GUCHUIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strGuChuiBefore=objReader.GetAttribute("GUCHUIBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strGuDao=objReader.GetAttribute("GUDAO").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strGuDaoAfter=objReader.GetAttribute("GUDAOAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strGuDaoBefore=objReader.GetAttribute("GUDAOBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strGuZao=objReader.GetAttribute("GUZAO").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strGuZaoAfter=objReader.GetAttribute("GUZAOAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strGuZaoBefore=objReader.GetAttribute("GUZAOBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strGuMoBoLiQi=objReader.GetAttribute("GUMOBOLIQI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strGuMoBoLiQiAfter=objReader.GetAttribute("GUMOBOLIQIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strGuMoBoLiQiBefore=objReader.GetAttribute("GUMOBOLIQIBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strJingGuQiZi=objReader.GetAttribute("JINGGUQIZI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strJingGuQiZiAfter=objReader.GetAttribute("JINGGUQIZIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strJingGuQiZiBefore=objReader.GetAttribute("JINGGUQIZIBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strKuoShi=objReader.GetAttribute("KUOSHI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strKuoShiAfter=objReader.GetAttribute("KUOSHIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strKuoShiBefore=objReader.GetAttribute("KUOSHIBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strLeiGuQiZi=objReader.GetAttribute("LEIGUQIZI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strLeiGuQiZiAfter=objReader.GetAttribute("LEIGUQIZIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strLeiGuQiZiBefore=objReader.GetAttribute("LEIGUQIZIBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strLaoHuQian=objReader.GetAttribute("LAOHUQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strLaoHuQianAfter=objReader.GetAttribute("LAOHUQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strLaoHuQianBefore=objReader.GetAttribute("LAOHUQIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strLuoSiQiZi=objReader.GetAttribute("LUOSIQIZI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strLuoSiQiZiAfter=objReader.GetAttribute("LUOSIQIZIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strLuoSiQiZiBefore=objReader.GetAttribute("LUOSIQIZIBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strPingHengFuWeiQian=objReader.GetAttribute("PINGHENGFUWEIQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strPingHengFuWeiQianAfter=objReader.GetAttribute("PINGHENGFUWEIQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strPingHengFuWeiQianBefore=objReader.GetAttribute("PINGHENGFUWEIQIANBEFORE").ToString().Replace ('五','\'');
								
							
								//************************************************
								objOperationEqipmentQtyContent.strBaiShiQianKaiQi=objReader.GetAttribute("BAISHIQIANKAIQI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strBaiShiQianKaiQiAfter=objReader.GetAttribute("BAISHIQIANKAIQIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strBaiShiQianKaiQiBefore=objReader.GetAttribute("BAISHIQIANKAIQIBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strChiBanQian=objReader.GetAttribute("CHIBANQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strChiBanQianAfter=objReader.GetAttribute("CHIBANQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strChiBanQianBefore=objReader.GetAttribute("CHIBANQIANBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strJianBoLiZi=objReader.GetAttribute("JIANBOLIZI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strJianBoLiZiAfter=objReader.GetAttribute("JIANBOLIZIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strJianBoLiZiBefore=objReader.GetAttribute("JIANBOLIZIBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strJingTuJian=objReader.GetAttribute("JINGTUJIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strJingTuJianAfter=objReader.GetAttribute("JINGTUJIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strJingTuJianBefore=objReader.GetAttribute("JINGTUJIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strKaiLuZhuan=objReader.GetAttribute("KAILUZHUAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strKaiLuZhuanAfter=objReader.GetAttribute("KAILUZHUANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strKaiLuZhuanBefore=objReader.GetAttribute("KAILUZHUANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strQiangZhuangNie=objReader.GetAttribute("QIANGZHUANGNIE").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strQiangZhuangNieAfter=objReader.GetAttribute("QIANGZHUANGNIEAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strQiangZhuangNieBefore=objReader.GetAttribute("QIANGZHUANGNIEBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strShuiHeQian=objReader.GetAttribute("SHUIHEQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strShuiHeQianAfter=objReader.GetAttribute("SHUIHEQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strShuiHeQianBefore=objReader.GetAttribute("SHUIHEQIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strTouPiJianQian=objReader.GetAttribute("TOUPIJIANQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strTouPiJianQianAfter=objReader.GetAttribute("TOUPIJIANQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strTouPiJianQianBefore=objReader.GetAttribute("TOUPIJIANQIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strXianJuDaoYinZi=objReader.GetAttribute("XIANJUDAOYINZI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strXianJuDaoYinZiAfter=objReader.GetAttribute("XIANJUDAOYINZIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strXianJuDaoYinZiBefore=objReader.GetAttribute("XIANJUDAOYINZIBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strXinErLaGou=objReader.GetAttribute("XINERLAGOU").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strXinErLaGouAfter=objReader.GetAttribute("XINERLAGOUAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strXinErLaGouBefore=objReader.GetAttribute("XINERLAGOUBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strZhuiBanBoLiQi=objReader.GetAttribute("ZHUIBANBOLIQI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhuiBanBoLiQiAfter=objReader.GetAttribute("ZHUIBANBOLIQIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhuiBanBoLiQiBefore=objReader.GetAttribute("ZHUIBANBOLIQIBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strZhuiBanYaoGuQian=objReader.GetAttribute("ZHUIBANYAOGUQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhuiBanYaoGuQianAfter=objReader.GetAttribute("ZHUIBANYAOGUQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhuiBanYaoGuQianBefore=objReader.GetAttribute("ZHUIBANYAOGUQIANBEFORE").ToString().Replace ('五','\'');
								
							
								//************************************************
								objOperationEqipmentQtyContent.strCeBanQi=objReader.GetAttribute("CEBANQI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strCeBanQiAfter=objReader.GetAttribute("CEBANQIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strCeBanQiBefore=objReader.GetAttribute("CEBANQIBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strChuanCiZhen=objReader.GetAttribute("CHUANCIZHEN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strChuanCiZhenAfter=objReader.GetAttribute("CHUANCIZHENAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strChuanCiZhenBefore=objReader.GetAttribute("CHUANCIZHENBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strDaoXianGou=objReader.GetAttribute("DAOXIANGOU").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDaoXianGouAfter=objReader.GetAttribute("DAOXIANGOUAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strDaoXianGouBefore=objReader.GetAttribute("DAOXIANGOUBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strErJianBanKuoZhangQi=objReader.GetAttribute("ERJIANBANKUOZHANGQI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strErJianBanKuoZhangQiAfter=objReader.GetAttribute("ERJIANBANKUOZHANGQIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strErJianBanKuoZhangQiBefore=objReader.GetAttribute("ERJIANBANKUOZHANGQIBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strFeiYeDangBan=objReader.GetAttribute("FEIYEDANGBAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strFeiYeDangBanAfter=objReader.GetAttribute("FEIYEDANGBANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strFeiYeDangBanBefore=objReader.GetAttribute("FEIYEDANGBANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strNaoMoGou=objReader.GetAttribute("NAOMOGOU").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strNaoMoGouAfter=objReader.GetAttribute("NAOMOGOUAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strNaoMoGouBefore=objReader.GetAttribute("NAOMOGOUBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strXinFangLaGou=objReader.GetAttribute("XINFANGLAGOU").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strXinFangLaGouAfter=objReader.GetAttribute("XINFANGLAGOUAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strXinFangLaGouBefore=objReader.GetAttribute("XINFANGLAGOUBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strXinNeiZhiJiaoLaGou=objReader.GetAttribute("XINNEIZHIJIAOLAGOU").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strXinNeiZhiJiaoLaGouAfter=objReader.GetAttribute("XINNEIZHIJIAOLAGOUAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strXinNeiZhiJiaoLaGouBefore=objReader.GetAttribute("XINNEIZHIJIAOLAGOUBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strYinDingQian=objReader.GetAttribute("YINDINGQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strYinDingQianAfter=objReader.GetAttribute("YINDINGQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strYinDingQianBefore=objReader.GetAttribute("YINDINGQIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strZhuACeBiQian=objReader.GetAttribute("ZHUACEBIQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhuACeBiQiAfter=objReader.GetAttribute("ZHUACEBIQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhuACeBiQiBefore=objReader.GetAttribute("ZHUACEBIQIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strZhuAYouLiQian=objReader.GetAttribute("ZHUAYOULIQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhuAYouLiQianAfter=objReader.GetAttribute("ZHUAYOULIQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhuAYouLiQianBefore=objReader.GetAttribute("ZHUAYOULIQIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strZhuAZhuDuanQian=objReader.GetAttribute("ZHUAZHUDUANQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhuAZhuDuanQianAfter=objReader.GetAttribute("ZHUAZHUDUANQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strZhuAZhuDuanQianBefore=objReader.GetAttribute("ZHUAZHUDUANQIANBEFORE").ToString().Replace ('五','\'');
								
							
								//************************************************
								objOperationEqipmentQtyContent.strFuKui=objReader.GetAttribute("FUKUI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strFuKuiAfter=objReader.GetAttribute("FUKUIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strFuKuiBefore=objReader.GetAttribute("FUKUIBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strGongChi=objReader.GetAttribute("GONGCHI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strGongChiAfter=objReader.GetAttribute("GONGCHIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strGongChiBefore=objReader.GetAttribute("GONGCHIBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strGongGuaShi=objReader.GetAttribute("GONGGUASHI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strGongGuaShiAfter=objReader.GetAttribute("GONGGUASHIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strGongGuaShiBefore=objReader.GetAttribute("GONGGUASHIBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strGongJingQian=objReader.GetAttribute("GONGJINGQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strGongJingQianAfter=objReader.GetAttribute("GONGJINGQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strGongJingQianBefore=objReader.GetAttribute("GONGJINGQIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strJiLiuBoLiZi=objReader.GetAttribute("JILIUBOLIZI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strJiLiuBoLiZiAfter=objReader.GetAttribute("JILIUBOLIZIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strJiLiuBoLiZiBefore=objReader.GetAttribute("JILIUBOLIZIBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strKaChi=objReader.GetAttribute("KACHI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strKaChiAfter=objReader.GetAttribute("KACHIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strKaChiBefore=objReader.GetAttribute("KACHIBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strKuoGongQi=objReader.GetAttribute("KUOGONGQI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strKuoGongQiAfter=objReader.GetAttribute("KUOGONGQIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strKuoGongQiBefore=objReader.GetAttribute("KUOGONGQIBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strRenDaiQian=objReader.GetAttribute("RENDAIQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strRenDaiQianAfter=objReader.GetAttribute("RENDAIQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strRenDaiQianBefore=objReader.GetAttribute("RENDAIQIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strShenJingLaGou=objReader.GetAttribute("SHENJINGLAGOU").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strShenJingLaGouAfter=objReader.GetAttribute("SHENJINGLAGOUAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strShenJingLaGouBefore=objReader.GetAttribute("SHENJINGLAGOUBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strWuChuangNie=objReader.GetAttribute("WUCHUANGNIE").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWuChuangNieAfter=objReader.GetAttribute("WUCHUANGNIEAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWuChuangNieBefore=objReader.GetAttribute("WUCHUANGNIEBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strXueGuanJia=objReader.GetAttribute("XUEGUANJIA").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strXueGuanJiaAfter=objReader.GetAttribute("XUEGUANJIAAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strXueGuanJiaBefore=objReader.GetAttribute("XUEGUANJIABEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strYinDaoLaGou=objReader.GetAttribute("YINDAOLAGOU").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strYinDaoLaGouAfter=objReader.GetAttribute("YINDAOLAGOUAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strYinDaoLaGouBefore=objReader.GetAttribute("YINDAOLAGOUBEFORE").ToString().Replace ('五','\'');
								
							
								//************************************************
								objOperationEqipmentQtyContent.strFuGuoQian=objReader.GetAttribute("FUGUOQIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strFuGuoQianAfter=objReader.GetAttribute("FUGUOQIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strFuGuoQianBefore=objReader.GetAttribute("FUGUOQIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strFuNieYinLiu=objReader.GetAttribute("FUNIEYINLIU").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strFuNieYinLiuAfter=objReader.GetAttribute("FUNIEYINLIUAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strFuNieYinLiuBefore=objReader.GetAttribute("FUNIEYINLIUBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strJinShuNiaoGou=objReader.GetAttribute("JINSHUNIAOGOU").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strJinShuNiaoGouAfter=objReader.GetAttribute("JINSHUNIAOGOUAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strJinShuNiaoGouBefore=objReader.GetAttribute("JINSHUNIAOGOUBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strKaiLuMian=objReader.GetAttribute("KAILUMIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strKaiLuMianAfter=objReader.GetAttribute("KAILUMIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strKaiLuMianBefore=objReader.GetAttribute("KAILUMIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strQuanGongSha=objReader.GetAttribute("QUANGONGSHA").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strQuanGongShaAfter=objReader.GetAttribute("QUANGONGSHAAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strQuanGongShaBefore=objReader.GetAttribute("QUANGONGSHABEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strShaKuai=objReader.GetAttribute("SHAKUAI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strShaKuaiAfter=objReader.GetAttribute("SHAKUAIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strShaKuaiBefore=objReader.GetAttribute("SHAKUAIBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strShaQiu=objReader.GetAttribute("SHAQIU").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strShaQiuAfter=objReader.GetAttribute("SHAQIUAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strShaQiuBefore=objReader.GetAttribute("SHAQIUBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strWangSha=objReader.GetAttribute("WANGSHA").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWangShaAfter=objReader.GetAttribute("WANGSHAAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWangShaBefore=objReader.GetAttribute("WANGSHABEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strWuDaiChangDian=objReader.GetAttribute("WUDAICHANGDIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWuDaiChangDianAfter=objReader.GetAttribute("WUDAICHANGDIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWuDaiChangDianBefore=objReader.GetAttribute("WUDAICHANGDIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strWuDaiFangDian=objReader.GetAttribute("WUDAIFANGDIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWuDaiFangDianAfter=objReader.GetAttribute("WUDAIFANGDIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strWuDaiFangDianBefore=objReader.GetAttribute("WUDAIFANGDIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strYouDaiChangDian=objReader.GetAttribute("YOUDAICHANGDIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strYouDaiChangDianAfter=objReader.GetAttribute("YOUDAICHANGDIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strYouDaiChangDianBefore=objReader.GetAttribute("YOUDAICHANGDIANBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strYouDaiFangDian=objReader.GetAttribute("YOUDAIFANGDIAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strYouDaiFangDianAfter=objReader.GetAttribute("YOUDAIFANGDIANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strYouDaiFangDianBefore=objReader.GetAttribute("YOUDAIFANGDIANBEFORE").ToString().Replace ('五','\'');
								
								
								//************************************************
								objOperationEqipmentQtyContent.strBianDai=objReader.GetAttribute("BIANDAI").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strBianDaiAfter=objReader.GetAttribute("BIANDAIAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strBianDaiBefore=objReader.GetAttribute("BIANDAIBEFORE").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyContent.strChangQianTao=objReader.GetAttribute("CHANGQIANTAO").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strChangQianTaoAfter=objReader.GetAttribute("CHANGQIANTAOAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strChangQianTaoBefore=objReader.GetAttribute("CHANGQIANTAOBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyContent.strNiaoGuan=objReader.GetAttribute("NIAOGUAN").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strNiaoGuanAfter=objReader.GetAttribute("NIAOGUANAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyContent.strNiaoGuanBefore=objReader.GetAttribute("NIAOGUANBEFORE").ToString().Replace ('五','\'');


								m_objPackage.m_objOperationEqipmentQtyContent =objOperationEqipmentQtyContent;
								
								#endregion

								#region 翋桶
								objOperationEqipmentQtyXML.strInPatientID=objReader.GetAttribute("INPATIENTID");
								objOperationEqipmentQtyXML.strInPatientDate=objReader.GetAttribute("INPATIENTDATE");
								objOperationEqipmentQtyXML.strOpenDate=objReader.GetAttribute("OPENDATE");

								objOperationEqipmentQtyXML.strCreateDate=objReader.GetAttribute("CREATEDATE");
								objOperationEqipmentQtyXML.strCreateUserID=objReader.GetAttribute("CREATEUSERID");

								//								objOperationEqipmentQtyContentInsert.strOperationID=objReader.GetAttribute("INPATIENTID").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strOperationNameXML=objReader.GetAttribute("OPERATIONNAMEXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strWenWan125XML=objReader.GetAttribute("WENWAN125XML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWenWan125AfterXML=objReader.GetAttribute("WENWAN125AFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWenWan125BeforeXML=objReader.GetAttribute("WENWAN125BEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strWenZhi125XML=objReader.GetAttribute("WENZHI125XML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWenZhi125AfterXML=objReader.GetAttribute("WENZHI125AFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWenZhi125BeforeXML=objReader.GetAttribute("WENZHI125BEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strXiaoWan14XML=objReader.GetAttribute("XIAOWAN14XML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXiaoWan14AfterXML=objReader.GetAttribute("XIAOWAN14AFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXiaoWan14BeforeXML=objReader.GetAttribute("XIAOWAN14BEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strXiaoZhi14XML=objReader.GetAttribute("XIAOZHI14XML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXiaoZhi14AfterXML=objReader.GetAttribute("XIAOZHI14AFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXiaoZhi14BeforeXML=objReader.GetAttribute("XIAOZHI14BEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strZhongWan16XML=objReader.GetAttribute("ZHONGWAN16XML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhongWan16AfterXML=objReader.GetAttribute("ZHONGWAN16AFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhongWan16BeforeXML=objReader.GetAttribute("ZHONGWAN16BEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strZhongZhi16XML=objReader.GetAttribute("ZHONGZHI16XML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhongZhi16AfterXML=objReader.GetAttribute("ZHONGZHI16AFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhongZhi16BeforeXML=objReader.GetAttribute("ZHONGZHI16BEFOREXML").ToString().Replace ('五','\'');
								
								
								//************************************************
								objOperationEqipmentQtyXML.strChiZhenQian18XML=objReader.GetAttribute("CHIZHENQIAN18XML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strChiZhenQian18AfterXML=objReader.GetAttribute("CHIZHENQIAN18AFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strChiZhenQian18BeforeXML=objReader.GetAttribute("CHIZHENQIAN18BEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strJinQianAfterXML=objReader.GetAttribute("JINQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strJinQianBeforeXML=objReader.GetAttribute("JINQIANBEFOREXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strJinQianXML=objReader.GetAttribute("JINQIANXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strPiQianAfterXML=objReader.GetAttribute("PIQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strPiQianBeforeXML=objReader.GetAttribute("PIQIANBEFOREXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strPiQianXML=objReader.GetAttribute("PIQIANXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strQuanQianAfterXML=objReader.GetAttribute("QUANQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strQuanQianBeforeXML=objReader.GetAttribute("QUANQIANBEFOREXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strQuanQianXML=objReader.GetAttribute("QUANQIANXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strZhiYouChiXueGuanQianAfterXML=objReader.GetAttribute("ZHIYOUCHIXUEGUANQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhiYouChiXueGuanQianBeforeXML=objReader.GetAttribute("ZHIYOUCHIXUEGUANQIANBEFOREXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhiYouChiXueGuanQianXML=objReader.GetAttribute("ZHIYOUCHIXUEGUANQIANXML").ToString().Replace ('五','\'');
								
							

								objOperationEqipmentQtyXML.strYouChiNieXML =objReader.GetAttribute("YOUCHINIEXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strYouChiNieBeforeXML =objReader.GetAttribute("YOUCHINIEBEFOREXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strYouChiNieAfterXML =objReader.GetAttribute("YOUCHINIEAFTERXML").ToString().Replace ('五','\'');

								
								objOperationEqipmentQtyXML.strPingHengFuWeiQianXML =objReader.GetAttribute("PINGHENGFUWEIQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strPingHengFuWeiQianBeforeXML  =objReader.GetAttribute("PINGHENGFUWEIQIANBEFOREXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strPingHengFuWeiQianAfterXML =objReader.GetAttribute("PINGHENGFUWEIQIANAFTERXML").ToString().Replace ('五','\'');

								//************************************************
								objOperationEqipmentQtyXML.strWuChiNieXML=objReader.GetAttribute("WUCHINIEXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWuChiNieAfterXML=objReader.GetAttribute("WUCHINIEAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWuChiNieBeforeXML=objReader.GetAttribute("WUCHINIEBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strChangYaBanXML=objReader.GetAttribute("CHANGYABANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strChangYaBanAfterXML=objReader.GetAttribute("CHANGYABANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strChangYaBanBeforeXML=objReader.GetAttribute("CHANGYABANBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strDaoBing3XML=objReader.GetAttribute("DAOBING3XML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDaoBing3AfterXML=objReader.GetAttribute("DAOBING3AFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDaoBing3BeforeXML=objReader.GetAttribute("DAOBING3BEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strDaoBing4XML=objReader.GetAttribute("DAOBING4XML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDaoBing4AfterXML=objReader.GetAttribute("DAOBING4AFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDaoBing4BeforeXML=objReader.GetAttribute("DAOBING4BEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strDaoBing7XML=objReader.GetAttribute("DAOBING7XML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDaoBing7AfterXML=objReader.GetAttribute("DAOBING7AFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDaoBing7BeforeXML=objReader.GetAttribute("DAOBING7BEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strWuChiNieXML=objReader.GetAttribute("WUCHINIEXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWuChiNieAfterXML=objReader.GetAttribute("WUCHINIEAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWuChiNieBeforeXML=objReader.GetAttribute("WUCHINIEBEFOREXML").ToString().Replace ('五','\'');
								
							
								//************************************************
								objOperationEqipmentQtyXML.strZhiZhuZhiJianXML=objReader.GetAttribute("ZHIZHUZHIJIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhiZhuZhiJianBeforeXML=objReader.GetAttribute("ZHIZHUZHIJIANBEFOREXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhiZhuZhiJianAfterXML=objReader.GetAttribute("ZHIZHUZHIJIANAFTERXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strZhiJiaoXiaoLaGouXML=objReader.GetAttribute("ZHIJIAOXIAOLAGOUXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhiJiaoXiaoLaGouBeforeXML=objReader.GetAttribute("ZHIJIAOXIAOLAGOUBEFOREXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhiJiaoXiaoLaGouAfterXML=objReader.GetAttribute("ZHIJIAOXIAOLAGOUAFTERXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strXiongQiangJianXML=objReader.GetAttribute("XIONGQIANGJIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXiongQiangJianAfterXML=objReader.GetAttribute("XIONGQIANGJIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXiongQiangJianBeforeXML=objReader.GetAttribute("XIONGQIANGJIANBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strWanZhuZhiJianXML=objReader.GetAttribute("WANZHUZHIJIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWanZhuZhiJianBeforeXML=objReader.GetAttribute("WANZHUZHIJIANBEFOREXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWanZhuZhiJianAfterXML=objReader.GetAttribute("WANZHUZHIJIANAFTERXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strLanWeiLaGouXML=objReader.GetAttribute("LANWEILAGOUXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strLanWeiLaGouAfterXML=objReader.GetAttribute("LANWEILAGOUAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strLanWeiLaGouBeforeXML=objReader.GetAttribute("LANWEILAGOUBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strBianTaoXianJianXML=objReader.GetAttribute("BIANTAOXIANJIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strBianTaoXianJianBeforeXML=objReader.GetAttribute("BIANTAOXIANJIANBEFOREXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strBianTaoXianJianAfterXML=objReader.GetAttribute("BIANTAOXIANJIANAFTERXML").ToString().Replace ('五','\'');
								
							
								//************************************************
								objOperationEqipmentQtyXML.strChangYaGouXML=objReader.GetAttribute("CHANGYAGOUXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strChangYaGouAfterXML=objReader.GetAttribute("CHANGYAGOUAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strChangYaGouBeforeXML=objReader.GetAttribute("CHANGYAGOUBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strTongQuanXML=objReader.GetAttribute("TONGQUANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strTongQuanAfterXML=objReader.GetAttribute("TONGQUANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strTongQuanBeforeXML=objReader.GetAttribute("TONGQUANBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strXiaFuBuQianKaiQiXML=objReader.GetAttribute("XIAFUBUQIANKAIQIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXiaFuBuQianKaiQiAfterXML=objReader.GetAttribute("XIAFUBUQIANKAIQIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXiaFuBuQianKaiQiBeforeXML=objReader.GetAttribute("XIAFUBUQIANKAIQIBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strXiaFuBuQianKaiQiXML=objReader.GetAttribute("XIAFUBUQIANKAIQIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXiaFuBuQianKaiQiAfterXML=objReader.GetAttribute("XIAFUBUQIANKAIQIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXiaFuBuQianKaiQiBeforeXML=objReader.GetAttribute("XIAFUBUQIANKAIQIBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strXiYeGuanXML=objReader.GetAttribute("XIYEGUANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXiYeGuanAfterXML=objReader.GetAttribute("XIYEGUANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXiYeGuanBeforeXML=objReader.GetAttribute("XIYEGUANBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strZhiJiaoGouXML=objReader.GetAttribute("ZHIJIAOGOUXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhiJiaoGouAfterXML=objReader.GetAttribute("ZHIJIAOGOUAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhiJiaoGouBeforeXML=objReader.GetAttribute("ZHIJIAOGOUBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strZhongFuGouXML=objReader.GetAttribute("ZHONGFUGOUXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhongFuGouAfterXML=objReader.GetAttribute("ZHONGFUGOUAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhongFuGouBeforeXML=objReader.GetAttribute("ZHONGFUGOUBEFOREXML").ToString().Replace ('五','\'');
								
							
								//************************************************
								objOperationEqipmentQtyXML.strNianMoQianXML=objReader.GetAttribute("NIANMOQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strNianMoQianAfterXML=objReader.GetAttribute("NIANMOQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strNianMoQianBeforeXML=objReader.GetAttribute("NIANMOQIANBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strShaLiQianXML=objReader.GetAttribute("SHALIQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strShaLiQianAfterXML=objReader.GetAttribute("SHALIQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strShaLiQianBeforeXML=objReader.GetAttribute("SHALIQIANBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strWanXueGuanQian18XML=objReader.GetAttribute("WANXUEGUANQIAN18XML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWanXueGuanQian18AfterXML=objReader.GetAttribute("WANXUEGUANQIAN18AFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWanXueGuanQian18BeforeXML=objReader.GetAttribute("WANXUEGUANQIAN18BEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strWanXueGuanQian20XML=objReader.GetAttribute("WANXUEGUANQIAN20XML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWanXueGuanQian20AfterXML=objReader.GetAttribute("WANXUEGUANQIAN20AFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWanXueGuanQian20BeforeXML=objReader.GetAttribute("WANXUEGUANQIAN20BEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strWanXueGuanQian22XML=objReader.GetAttribute("WANXUEGUANQIAN22XML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWanXueGuanQian22AfterXML=objReader.GetAttribute("WANXUEGUANQIAN22AFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWanXueGuanQian22BeforeXML=objReader.GetAttribute("WANXUEGUANQIAN22BEFOREXML").ToString().Replace ('五','\'');
								
							
								//************************************************
								objOperationEqipmentQtyXML.strChangChiZhenQian25XML=objReader.GetAttribute("CHANGCHIZHENQIAN25XML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strChangChiZhenQian25AfterXML=objReader.GetAttribute("CHANGCHIZHENQIAN25AFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strChangChiZhenQian25BeforeXML=objReader.GetAttribute("CHANGCHIZHENQIAN25BEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strDaoPianXML=objReader.GetAttribute("DAOPIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDaoPianAfterXML=objReader.GetAttribute("DAOPIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDaoPianBeforeXML=objReader.GetAttribute("DAOPIANBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strDaZhiQianXML=objReader.GetAttribute("DAZHIQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDaZhiQianAfterXML=objReader.GetAttribute("DAZHIQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDaZhiQianBeforeXML=objReader.GetAttribute("DAZHIQIANBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strFengZhenXML=objReader.GetAttribute("FENGZHENXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strFengZhenAfterXML=objReader.GetAttribute("FENGZHENAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strFengZhenBeforeXML=objReader.GetAttribute("FENGZHENBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strZhiJiaoQianXML=objReader.GetAttribute("ZHIJIAOQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhiJiaoQianAfterXML=objReader.GetAttribute("ZHIJIAOQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhiJiaoQianBeforeXML=objReader.GetAttribute("ZHIJIAOQIANBEFOREXML").ToString().Replace ('五','\'');
								
							
								//************************************************
								objOperationEqipmentQtyXML.strChangQianZhiXML=objReader.GetAttribute("CHANGQIANZHIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strChangQianZhiAfterXML=objReader.GetAttribute("CHANGQIANZHIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strChangQianZhiBeforeXML=objReader.GetAttribute("CHANGQIANZHIBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strDaWanXueGuanQianXML=objReader.GetAttribute("DAWANXUEGUANQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDaWanXueGuanQianAfterXML=objReader.GetAttribute("DAWANXUEGUANQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDaWanXueGuanQianBeforeXML=objReader.GetAttribute("DAWANXUEGUANQIANBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strShenDiQianXML=objReader.GetAttribute("SHENDIQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strShenDiQianAfterXML=objReader.GetAttribute("SHENDIQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strShenDiQianBeforeXML=objReader.GetAttribute("SHENDIQIANBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strWanXueGuanQian25XML=objReader.GetAttribute("WANXUEGUANQIAN25XML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWanXueGuanQian25AfterXML=objReader.GetAttribute("WANXUEGUANQIAN25AFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWanXueGuanQian25BeforeXML=objReader.GetAttribute("WANXUEGUANQIAN25BEFOREXML").ToString().Replace ('五','\'');

								//************************************************
								objOperationEqipmentQtyXML.strChangQianWanXML=objReader.GetAttribute("CHANGQIANWANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strChangQianWanAfterXML=objReader.GetAttribute("CHANGQIANWANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strChangQianWanBeforeXML=objReader.GetAttribute("CHANGQIANWANBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strErYanHouChongXiQiXML=objReader.GetAttribute("ERYANHOUCHONGXIQIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strErYanHouChongXiQiAfterXML=objReader.GetAttribute("ERYANHOUCHONGXIQIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strErYanHouChongXiQiBeforeXML=objReader.GetAttribute("ERYANHOUCHONGXIQIBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strShiQianXML=objReader.GetAttribute("SHIQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strShiQianAfterXML=objReader.GetAttribute("SHIQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strShiQianBeforeXML=objReader.GetAttribute("SHIQIANBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strWeiQianXML=objReader.GetAttribute("WEIQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWeiQianAfterXML=objReader.GetAttribute("WEIQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWeiQianBeforeXML=objReader.GetAttribute("WEIQIANBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strXinErQianXML=objReader.GetAttribute("XINERQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXinErQiaAfterXML=objReader.GetAttribute("XINERQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXinErQiaBeforeXML=objReader.GetAttribute("XINERQIANBEFOREXML").ToString().Replace ('五','\'');
								
							
								//************************************************
								objOperationEqipmentQtyXML.strDanDaoTanTiaoXML=objReader.GetAttribute("DANDAOTANTIAOXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDanDaoTanTiaoAfterXML=objReader.GetAttribute("DANDAOTANTIAOAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDanDaoTanTiaoBeforeXML=objReader.GetAttribute("DANDAOTANTIAOBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strHeLongQiXML=objReader.GetAttribute("HELONGQIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strHeLongQiAfterXML=objReader.GetAttribute("HELONGQIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strHeLongQiBeforeXML=objReader.GetAttribute("HELONGQIBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strLeiGuQianKaiQiXML=objReader.GetAttribute("LEIGUQIANKAIQIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strLeiGuQianKaiQiAfterXML=objReader.GetAttribute("LEIGUQIANKAIQIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strLeiGuQianKaiQiBeforeXML=objReader.GetAttribute("LEIGUQIANKAIQIBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strTanZhenChuXML=objReader.GetAttribute("TANZHENCHUXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strTanZhenChuAfterXML=objReader.GetAttribute("TANZHENCHUAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strTanZhenChuBeforeXML=objReader.GetAttribute("TANZHENCHUBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strTanZhenXiXML=objReader.GetAttribute("TANZHENXIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strTanZhenXiAfterXML=objReader.GetAttribute("TANZHENXIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strTanZhenXiBeforeXML=objReader.GetAttribute("TANZHENXIBEFOREXML").ToString().Replace ('五','\'');
																
							
								//************************************************
								objOperationEqipmentQtyXML.strDaGuJianXML=objReader.GetAttribute("DAGUJIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDaGuJianAfterXML=objReader.GetAttribute("DAGUJIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDaGuJianBeforeXML=objReader.GetAttribute("DAGUJIANBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strDiErLeiGuJianXML=objReader.GetAttribute("DIERLEIGUJIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDiErLeiGuJianAfterXML=objReader.GetAttribute("DIERLEIGUJIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDiErLeiGuJianBeforeXML=objReader.GetAttribute("DIERLEIGUJIANBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strFangTouYaoGuQianXML=objReader.GetAttribute("FANGTOUYAOGUQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strFangTouYaoGuQianAfterXML=objReader.GetAttribute("FANGTOUYAOGUQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strFangTouYaoGuQianBeforeXML=objReader.GetAttribute("FANGTOUYAOGUQIANBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strJianJiaGuLaGouXML=objReader.GetAttribute("JIANJIAGULAGOUXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strJianJiaGuLaGouAfterXML=objReader.GetAttribute("JIANJIAGULAGOUAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strJianJiaGuLaGouBeforeXML=objReader.GetAttribute("JIANJIAGULAGOUBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strLeiGuQiZiXML=objReader.GetAttribute("LEIGUQIZIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strLeiGuQiZiAfterXML=objReader.GetAttribute("LEIGUQIZIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strLeiGuQiZiBeforeXML=objReader.GetAttribute("LEIGUQIZIBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strYaoGuQianXML=objReader.GetAttribute("YAOGUQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strYaoGuQianAfterXML=objReader.GetAttribute("YAOGUQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strYaoGuQianBeforeXML=objReader.GetAttribute("YAOGUQIANBEFOREXML").ToString().Replace ('五','\'');
								
							
								//************************************************
								objOperationEqipmentQtyXML.strChiGuQianXML=objReader.GetAttribute("CHIGUQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strChiGuQianAfterXML=objReader.GetAttribute("CHIGUQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strChiGuQianBeforeXML=objReader.GetAttribute("CHIGUQIANBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strGuChuiXML=objReader.GetAttribute("GUCHUIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strGuChuiAfterXML=objReader.GetAttribute("GUCHUIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strGuChuiBeforeXML=objReader.GetAttribute("GUCHUIBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strGuDaoXML=objReader.GetAttribute("GUDAOXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strGuDaoAfterXML=objReader.GetAttribute("GUDAOAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strGuDaoBeforeXML=objReader.GetAttribute("GUDAOBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strGuMoBoLiQiXML=objReader.GetAttribute("GUMOBOLIQIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strGuMoBoLiQiAfterXML=objReader.GetAttribute("GUMOBOLIQIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strGuMoBoLiQiBeforeXML=objReader.GetAttribute("GUMOBOLIQIBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strGuZaoXML=objReader.GetAttribute("GUZAOXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strGuZaoAfterXML=objReader.GetAttribute("GUZAOAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strGuZaoBeforeXML=objReader.GetAttribute("GUZAOBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strKuoShiXML=objReader.GetAttribute("KUOSHIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strKuoShiAfterXML=objReader.GetAttribute("KUOSHIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strKuoShiBeforeXML=objReader.GetAttribute("KUOSHIBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strLeiGuQiZiXML=objReader.GetAttribute("LEIGUQIZIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strLeiGuQiZiAfterXML=objReader.GetAttribute("LEIGUQIZIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strLeiGuQiZiBeforeXML=objReader.GetAttribute("LEIGUQIZIBEFOREXML").ToString().Replace ('五','\'');
								
							
								//************************************************
								objOperationEqipmentQtyXML.strDanChiLaGouXML=objReader.GetAttribute("DANCHILAGOUXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDanChiLaGouAfterXML=objReader.GetAttribute("DANCHILAGOUAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDanChiLaGouBeforeXML=objReader.GetAttribute("DANCHILAGOUBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strDaoXiangQiXML=objReader.GetAttribute("DAOXIANGQIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDaoXiangQiAfterXML=objReader.GetAttribute("DAOXIANGQIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDaoXiangQiBeforeXML=objReader.GetAttribute("DAOXIANGQIBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strJingGuQiZiXML=objReader.GetAttribute("JINGGUQIZIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strJingGuQiZiAfterXML=objReader.GetAttribute("JINGGUQIZIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strJingGuQiZiBeforeXML=objReader.GetAttribute("JINGGUQIZIBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strLaoHuQianXML=objReader.GetAttribute("LAOHUQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strLaoHuQianAfterXML=objReader.GetAttribute("LAOHUQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strLaoHuQianBeforeXML=objReader.GetAttribute("LAOHUQIANBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strLuoSiQiZiXML=objReader.GetAttribute("LUOSIQIZIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strLuoSiQiZiAfterXML=objReader.GetAttribute("LUOSIQIZIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strLuoSiQiZiBeforeXML=objReader.GetAttribute("LUOSIQIZIBEFOREXML").ToString().Replace ('五','\'');
								
								
								//************************************************
								objOperationEqipmentQtyXML.strJianBoLiZiXML=objReader.GetAttribute("JIANBOLIZIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strJianBoLiZiAfterXML=objReader.GetAttribute("JIANBOLIZIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strJianBoLiZiBeforeXML=objReader.GetAttribute("JIANBOLIZIBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strJingTuJianXML=objReader.GetAttribute("JINGTUJIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strJingTuJianAfterXML=objReader.GetAttribute("JINGTUJIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strJingTuJianBeforeXML=objReader.GetAttribute("JINGTUJIANBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strQiangZhuangNieXML=objReader.GetAttribute("QIANGZHUANGNIEXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strQiangZhuangNieAfterXML=objReader.GetAttribute("QIANGZHUANGNIEAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strQiangZhuangNieBeforeXML=objReader.GetAttribute("QIANGZHUANGNIEBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strShuiHeQianXML=objReader.GetAttribute("SHUIHEQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strShuiHeQianAfterXML=objReader.GetAttribute("SHUIHEQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strShuiHeQianBeforeXML=objReader.GetAttribute("SHUIHEQIANBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strZhuiBanBoLiQiXML=objReader.GetAttribute("ZHUIBANBOLIQIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhuiBanBoLiQiAfterXML=objReader.GetAttribute("ZHUIBANBOLIQIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhuiBanBoLiQiBeforeXML=objReader.GetAttribute("ZHUIBANBOLIQIBEFOREXML").ToString().Replace ('五','\'');
								
								
								//************************************************
								objOperationEqipmentQtyXML.strBaiShiQianKaiQiXML=objReader.GetAttribute("BAISHIQIANKAIQIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strBaiShiQianKaiQiAfterXML=objReader.GetAttribute("BAISHIQIANKAIQIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strBaiShiQianKaiQiBeforeXML=objReader.GetAttribute("BAISHIQIANKAIQIBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strChiBanQianXML=objReader.GetAttribute("CHIBANQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strChiBanQianAfterXML=objReader.GetAttribute("CHIBANQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strChiBanQianBeforeXML=objReader.GetAttribute("CHIBANQIANBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strKaiLuZhuanXML=objReader.GetAttribute("KAILUZHUANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strKaiLuZhuanAfterXML=objReader.GetAttribute("KAILUZHUANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strKaiLuZhuanBeforeXML=objReader.GetAttribute("KAILUZHUANBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strTouPiJianQianXML=objReader.GetAttribute("TOUPIJIANQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strTouPiJianQianAfterXML=objReader.GetAttribute("TOUPIJIANQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strTouPiJianQianBeforeXML=objReader.GetAttribute("TOUPIJIANQIANBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strXianJuDaoYinZiXML=objReader.GetAttribute("XIANJUDAOYINZIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXianJuDaoYinZiAfterXML=objReader.GetAttribute("XIANJUDAOYINZIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXianJuDaoYinZiBeforeXML=objReader.GetAttribute("XIANJUDAOYINZIBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strXinErLaGouXML=objReader.GetAttribute("XINERLAGOUXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXinErLaGouAfterXML=objReader.GetAttribute("XINERLAGOUAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXinErLaGouBeforeXML=objReader.GetAttribute("XINERLAGOUBEFOREXML").ToString().Replace ('五','\'');
								
								
								//************************************************
								objOperationEqipmentQtyXML.strChuanCiZhenXML=objReader.GetAttribute("CHUANCIZHENXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strChuanCiZhenAfterXML=objReader.GetAttribute("CHUANCIZHENAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strChuanCiZhenBeforeXML=objReader.GetAttribute("CHUANCIZHENBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strFeiYeDangBanXML=objReader.GetAttribute("FEIYEDANGBANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strFeiYeDangBanAfterXML=objReader.GetAttribute("FEIYEDANGBANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strFeiYeDangBanBeforeXML=objReader.GetAttribute("FEIYEDANGBANBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strNaoMoGouXML=objReader.GetAttribute("NAOMOGOUXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strNaoMoGouAfterXML=objReader.GetAttribute("NAOMOGOUAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strNaoMoGouBeforeXML=objReader.GetAttribute("NAOMOGOUBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strXinFangLaGouXML=objReader.GetAttribute("XINFANGLAGOUXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXinFangLaGouAfterXML=objReader.GetAttribute("XINFANGLAGOUAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXinFangLaGouBeforeXML=objReader.GetAttribute("XINFANGLAGOUBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strYinDingQianXML=objReader.GetAttribute("YINDINGQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strYinDingQianAfterXML=objReader.GetAttribute("YINDINGQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strYinDingQianBeforeXML=objReader.GetAttribute("YINDINGQIANBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strZhuAZhuDuanQianXML=objReader.GetAttribute("ZHUAZHUDUANQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhuAZhuDuanQianAfterXML=objReader.GetAttribute("ZHUAZHUDUANQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhuAZhuDuanQianBeforeXML=objReader.GetAttribute("ZHUAZHUDUANQIANBEFOREXML").ToString().Replace ('五','\'');
								
								
								//************************************************
								objOperationEqipmentQtyXML.strCeBanQiXML=objReader.GetAttribute("CEBANQIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strCeBanQiAfterXML=objReader.GetAttribute("CEBANQIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strCeBanQiBeforeXML=objReader.GetAttribute("CEBANQIBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strDaoXianGouXML=objReader.GetAttribute("DAOXIANGOUXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDaoXianGouAfterXML=objReader.GetAttribute("DAOXIANGOUAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strDaoXianGouBeforeXML=objReader.GetAttribute("DAOXIANGOUBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strErJianBanKuoZhangQiXML=objReader.GetAttribute("ERJIANBANKUOZHANGQIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strErJianBanKuoZhangQiAfterXML=objReader.GetAttribute("ERJIANBANKUOZHANGQIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strErJianBanKuoZhangQiBeforeXML=objReader.GetAttribute("ERJIANBANKUOZHANGQIBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strXinNeiZhiJiaoLaGouXML=objReader.GetAttribute("XINNEIZHIJIAOLAGOUXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXinNeiZhiJiaoLaGouAfterXML=objReader.GetAttribute("XINNEIZHIJIAOLAGOUAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXinNeiZhiJiaoLaGouBeforeXML=objReader.GetAttribute("XINNEIZHIJIAOLAGOUBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strZhuACeBiQianXML=objReader.GetAttribute("ZHUACEBIQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhuACeBiQiAfterXML=objReader.GetAttribute("ZHUACEBIQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhuACeBiQiBeforeXML=objReader.GetAttribute("ZHUACEBIQIANBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strZhuAYouLiQianXML=objReader.GetAttribute("ZHUAYOULIQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhuAYouLiQianAfterXML=objReader.GetAttribute("ZHUAYOULIQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strZhuAYouLiQianBeforeXML=objReader.GetAttribute("ZHUAYOULIQIANBEFOREXML").ToString().Replace ('五','\'');
								
								
								//************************************************
								objOperationEqipmentQtyXML.strFuKuiXML=objReader.GetAttribute("FUKUIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strFuKuiAfterXML=objReader.GetAttribute("FUKUIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strFuKuiBeforeXML=objReader.GetAttribute("FUKUIBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strGongChiXML=objReader.GetAttribute("GONGCHIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strGongChiAfterXML=objReader.GetAttribute("GONGCHIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strGongChiBeforeXML=objReader.GetAttribute("GONGCHIBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strKaChiXML=objReader.GetAttribute("KACHIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strKaChiAfterXML=objReader.GetAttribute("KACHIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strKaChiBeforeXML=objReader.GetAttribute("KACHIBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strShenJingLaGouXML=objReader.GetAttribute("SHENJINGLAGOUXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strShenJingLaGouAfterXML=objReader.GetAttribute("SHENJINGLAGOUAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strShenJingLaGouBeforeXML=objReader.GetAttribute("SHENJINGLAGOUBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strWuChuangNieXML=objReader.GetAttribute("WUCHUANGNIEXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWuChuangNieAfterXML=objReader.GetAttribute("WUCHUANGNIEAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWuChuangNieBeforeXML=objReader.GetAttribute("WUCHUANGNIEBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strXueGuanJiaXML=objReader.GetAttribute("XUEGUANJIAXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXueGuanJiaAfterXML=objReader.GetAttribute("XUEGUANJIAAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strXueGuanJiaBeforeXML=objReader.GetAttribute("XUEGUANJIABEFOREXML").ToString().Replace ('五','\'');
								
								
								//************************************************
								objOperationEqipmentQtyXML.strGongGuaShiXML=objReader.GetAttribute("GONGGUASHIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strGongGuaShiAfterXML=objReader.GetAttribute("GONGGUASHIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strGongGuaShiBeforeXML=objReader.GetAttribute("GONGGUASHIBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strGongJingQianXML=objReader.GetAttribute("GONGJINGQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strGongJingQianAfterXML=objReader.GetAttribute("GONGJINGQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strGongJingQianBeforeXML=objReader.GetAttribute("GONGJINGQIANBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strJiLiuBoLiZiXML=objReader.GetAttribute("JINSHUNIAOGOU").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strJiLiuBoLiZiAfterXML=objReader.GetAttribute("JINSHUNIAOGOUAFTER").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strJiLiuBoLiZiBeforeXML=objReader.GetAttribute("JINSHUNIAOGOUBEFORE").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strKuoGongQiXML=objReader.GetAttribute("KUOGONGQIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strKuoGongQiAfterXML=objReader.GetAttribute("KUOGONGQIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strKuoGongQiBeforeXML=objReader.GetAttribute("KUOGONGQIBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strRenDaiQianXML=objReader.GetAttribute("RENDAIQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strRenDaiQianAfterXML=objReader.GetAttribute("RENDAIQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strRenDaiQianBeforeXML=objReader.GetAttribute("RENDAIQIANBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strYinDaoLaGouXML=objReader.GetAttribute("YINDAOLAGOUXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strYinDaoLaGouAfterXML=objReader.GetAttribute("YINDAOLAGOUAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strYinDaoLaGouBeforeXML=objReader.GetAttribute("YINDAOLAGOUBEFOREXML").ToString().Replace ('五','\'');
								
								
								//************************************************
								objOperationEqipmentQtyXML.strFuGuoQianXML=objReader.GetAttribute("FUGUOQIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strFuGuoQianAfterXML=objReader.GetAttribute("FUGUOQIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strFuGuoQianBeforeXML=objReader.GetAttribute("FUGUOQIANBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strJinShuNiaoGouXML=objReader.GetAttribute("JINSHUNIAOGOUXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strJinShuNiaoGouAfterXML=objReader.GetAttribute("JINSHUNIAOGOUAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strJinShuNiaoGouBeforeXML=objReader.GetAttribute("JINSHUNIAOGOUBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strWuDaiChangDianXML=objReader.GetAttribute("WUDAICHANGDIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWuDaiChangDianAfterXML=objReader.GetAttribute("WUDAICHANGDIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWuDaiChangDianBeforeXML=objReader.GetAttribute("WUDAICHANGDIANBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strWuDaiFangDianXML=objReader.GetAttribute("WUDAIFANGDIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWuDaiFangDianAfterXML=objReader.GetAttribute("WUDAIFANGDIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWuDaiFangDianBeforeXML=objReader.GetAttribute("WUDAIFANGDIANBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strYouDaiChangDianXML=objReader.GetAttribute("YOUDAICHANGDIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strYouDaiChangDianAfterXML=objReader.GetAttribute("YOUDAICHANGDIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strYouDaiChangDianBeforeXML=objReader.GetAttribute("YOUDAICHANGDIANBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strYouDaiFangDianXML=objReader.GetAttribute("YOUDAIFANGDIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strYouDaiFangDianAfterXML=objReader.GetAttribute("YOUDAIFANGDIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strYouDaiFangDianBeforeXML=objReader.GetAttribute("YOUDAIFANGDIANBEFOREXML").ToString().Replace ('五','\'');
								
								
								//************************************************
								objOperationEqipmentQtyXML.strFuNieYinLiuXML=objReader.GetAttribute("FUNIEYINLIUXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strFuNieYinLiuAfterXML=objReader.GetAttribute("FUNIEYINLIUAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strFuNieYinLiuBeforeXML=objReader.GetAttribute("FUNIEYINLIUBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strKaiLuMianXML=objReader.GetAttribute("KAILUMIANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strKaiLuMianAfterXML=objReader.GetAttribute("KAILUMIANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strKaiLuMianBeforeXML=objReader.GetAttribute("KAILUMIANBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strQuanGongShaXML=objReader.GetAttribute("QUANGONGSHAXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strQuanGongShaAfterXML=objReader.GetAttribute("QUANGONGSHAAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strQuanGongShaBeforeXML=objReader.GetAttribute("QUANGONGSHABEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strShaKuaiXML=objReader.GetAttribute("SHAKUAIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strShaKuaiAfterXML=objReader.GetAttribute("SHAKUAIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strShaKuaiBeforeXML=objReader.GetAttribute("SHAKUAIBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strShaQiuXML=objReader.GetAttribute("SHAQIUXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strShaQiuAfterXML=objReader.GetAttribute("SHAQIUAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strShaQiuBeforeXML=objReader.GetAttribute("SHAQIUBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strWangShaXML=objReader.GetAttribute("WANGSHAXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWangShaAfterXML=objReader.GetAttribute("WANGSHAAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strWangShaBeforeXML=objReader.GetAttribute("WANGSHABEFOREXML").ToString().Replace ('五','\'');
								

								//************************************************
								objOperationEqipmentQtyXML.strBianDaiXML=objReader.GetAttribute("BIANDAIXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strBianDaiAfterXML=objReader.GetAttribute("BIANDAIAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strBianDaiBeforeXML=objReader.GetAttribute("BIANDAIBEFOREXML").ToString().Replace ('五','\'');
								
								objOperationEqipmentQtyXML.strChangQianTaoXML=objReader.GetAttribute("CHANGQIANTAOXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strChangQianTaoAfterXML=objReader.GetAttribute("CHANGQIANTAOAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strChangQianTaoBeforeXML=objReader.GetAttribute("CHANGQIANTAOBEFOREXML").ToString().Replace ('五','\'');

								objOperationEqipmentQtyXML.strNiaoGuanXML=objReader.GetAttribute("NIAOGUANXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strNiaoGuanAfterXML=objReader.GetAttribute("NIAOGUANAFTERXML").ToString().Replace ('五','\'');
								objOperationEqipmentQtyXML.strNiaoGuanBeforeXML=objReader.GetAttribute("NIAOGUANBEFOREXML").ToString().Replace ('五','\'');

								m_objPackage.m_objOperationEqipmentQtyXML =objOperationEqipmentQtyXML;


								#endregion

							}
							break;
					}
				}
				objclsOperationEquipmentPackage=m_objPackage;
			}			
			return m_intReturnRows;
		}

		/// <summary>
		/// 氝樓ヶ瓚剿蚚誧怀�賮馨糒輮掉韍Й鵖婺�
		/// </summary>
		/// <param name="strInPatientID"></param>
		/// <param name="strInPatientDate"></param>
		/// <param name="strCreateDate">蚚誧怀�賮馨糒輮掉�</param>
		/// <param name="Rows"></param>
		/// <returns></returns>
		public long lngSelectBeforSave(string strInPatientID, string strInPatientDate,string strCreateDate,out int Rows)
		{
			int m_intRows=0;
			long lngSucceed = 0;

            com.digitalwave.OperationEquipmentQtyService.clsOperationEquipmentQtyService m_objServ =
                (com.digitalwave.OperationEquipmentQtyService.clsOperationEquipmentQtyService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.OperationEquipmentQtyService.clsOperationEquipmentQtyService));

            try
            {
                lngSucceed = m_objServ.m_lngSelectBeforeSave(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, strInPatientID, strInPatientDate, strCreateDate, out m_intRows);
                Rows = m_intRows;
            }
            finally
            {
                //m_objServ.Dispose();
            }
			return lngSucceed; 
		
		}
		/// <summary>
		/// 垀衄腔萸杅桶腔奀潔
		/// </summary>		
		public long m_lngGetTimeInfoOfAPatientArr(string p_strInPatientID,string p_strInPatientDate,out DateTime[] dtmOpenDateArr,out DateTime[] dtmCreateDateArr)
		{
			dtmOpenDateArr=null;
			dtmCreateDateArr=null;
			if(p_strInPatientID ==null||p_strInPatientID =="")
				return -1;
			
			string strXml = "";
			int intRows = 0;
            long lngRes=0;

            com.digitalwave.OperationEquipmentQtyService.clsOperationEquipmentQtyService m_objServ =
                (com.digitalwave.OperationEquipmentQtyService.clsOperationEquipmentQtyService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.OperationEquipmentQtyService.clsOperationEquipmentQtyService));

            try
            {
                lngRes = m_objServ.m_lngGetTimeInfoOfAPatient(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, ref strXml, ref intRows);

                if (lngRes > 0 && intRows > 0)
                {
                    dtmOpenDateArr = new DateTime[intRows];
                    dtmCreateDateArr = new DateTime[intRows];

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
                                    dtmOpenDateArr[intIndex] = DateTime.Parse(objReader.GetAttribute("OPENDATE"));
                                    dtmCreateDateArr[intIndex] = DateTime.Parse(objReader.GetAttribute("CREATEDATE"));
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
			return lngRes ;
		}

		/// <summary>
		/// 垀衄腔誘尪
		/// </summary>
		/// <param name="strInPatientID"></param>
		/// <param name="strInPatientDate"></param>
		/// <param name="strOpenDate"></param>
		/// <param name="Rows"></param>
		/// <returns></returns>
		
		public long m_lngGetOperation_Nurse(string strInPatientID, string strInPatientDate,string strOpenDate,out clsOperationNurse[]  objclsOperationNurseArr)
		{
			objclsOperationNurseArr=null;
			string m_strReceivedXML="";
			int m_intReturnRows=0;
			long lngSucceed = 0;

            com.digitalwave.OperationEquipmentQtyService.clsOperationEquipmentQtyService m_objServ =
                (com.digitalwave.OperationEquipmentQtyService.clsOperationEquipmentQtyService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.OperationEquipmentQtyService.clsOperationEquipmentQtyService));

            try
            {
                lngSucceed = m_objServ.m_lngGetOperation_Nurse(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, strInPatientID, strInPatientDate, strOpenDate, ref m_strReceivedXML, ref m_intReturnRows);
                if (m_intReturnRows > 0)
                {
                    XmlTextReader objReader = new XmlTextReader(m_strReceivedXML, XmlNodeType.Element, m_objXmlParser);
                    objReader.WhitespaceHandling = WhitespaceHandling.None;
                    objclsOperationNurseArr = new clsOperationNurse[m_intReturnRows];
                    int intIndex = 0;
                    while (objReader.Read())
                    {
                        switch (objReader.NodeType)
                        {
                            case XmlNodeType.Element:
                                if (objReader.HasAttributes)
                                {
                                    objclsOperationNurseArr[intIndex] = new clsOperationNurse();
                                    objclsOperationNurseArr[intIndex].strNurseID = objReader.GetAttribute("NURSEID");
                                    objclsOperationNurseArr[intIndex].strNurseName = objReader.GetAttribute("NURSENAME").Trim();
                                    objclsOperationNurseArr[intIndex].strNurseFlag = objReader.GetAttribute("NURSEFLAG");
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
			return lngSucceed;

		}
	
        /// <summary>
        /// 耀緇脤梑瓟汜ID瘍
        /// </summary>
        /// <param name="strOperator"></param>
        /// <param name="bolSuccess"></param>
        /// <returns></returns>
		public System.Windows.Forms.ListViewItem[] m_lviGetEmployee(string strOperator,ref bool bolSuccess)
		{
			
			System.Windows.Forms.ListViewItem[] item1=null;
			string strSetXML="";
			int intRows=0;

			long lngSucceed = 0;

            com.digitalwave.OperationEquipmentQtyService.clsOperationEquipmentQtyService m_objServ =
                (com.digitalwave.OperationEquipmentQtyService.clsOperationEquipmentQtyService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.OperationEquipmentQtyService.clsOperationEquipmentQtyService));

            try
            {
                lngSucceed = m_objServ.lngXMLLikeQuery_Doctor(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, strOperator, ref strSetXML, ref intRows);
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
								item1[intIndex] = new System.Windows.Forms.ListViewItem(objReader.GetAttribute("EMPLOYEEID").ToString().Replace ('五','\''));
								item1[intIndex].SubItems.Add(objReader.GetAttribute("FIRSTNAME").Trim().Replace ('五','\''));
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

		public long m_lngGetEmployee(string strOperatorLike,out clsEmployeeIDName[] objclsEmployeeIDNameArr)
		{	
			objclsEmployeeIDNameArr=null;
			string strSetXML="";
			int intRows=0;

            com.digitalwave.OperationEquipmentQtyService.clsOperationEquipmentQtyService m_objServ = 
                (com.digitalwave.OperationEquipmentQtyService.clsOperationEquipmentQtyService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.OperationEquipmentQtyService.clsOperationEquipmentQtyService));

            try
            {
                long lngSucceed = m_objServ.lngXMLLikeQuery_Doctor(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, strOperatorLike, ref strSetXML, ref intRows);
            }
            finally
            {
                //m_objServ.Dispose();
            }
			if(intRows>0)
			{
				objclsEmployeeIDNameArr = new clsEmployeeIDName[intRows];
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
								objclsEmployeeIDNameArr[intIndex] = new clsEmployeeIDName();
								objclsEmployeeIDNameArr[intIndex].strEmployeeID =objReader.GetAttribute("EMPLOYEEID");
								objclsEmployeeIDNameArr[intIndex].strEmployeeName=objReader.GetAttribute("FIRSTNAME").Trim().Replace ('五','\'');
								intIndex ++;
							}
							break;
					}							
				}		
				
			}		
		
			return intRows;			
		}

		
		public long m_lngDelete(string p_strDeActivedOperatorID,string p_strInPatientID,string p_strInPatientDate,string p_strOpenDate)
		{			
			long lngSucceed = 0;

            com.digitalwave.OperationEquipmentQtyService.clsOperationEquipmentQtyService m_objServ =
                (com.digitalwave.OperationEquipmentQtyService.clsOperationEquipmentQtyService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.OperationEquipmentQtyService.clsOperationEquipmentQtyService));

            try
            {
                lngSucceed = m_objServ.m_lngDelete(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strDeActivedOperatorID,p_strInPatientID,p_strInPatientDate,p_strOpenDate);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngSucceed;
		}
	}

//	#region 翋桶腔濬
//	/// <summary>
//	/// 翋桶腔濬
//	/// </summary>	
//	[Serializable]
//	public class clsOperationEqipmentQtyXML
//	{
//		public string strInPatientID;
//		public string strInPatientDate;
//		public string strOpenDate;
//		public string strCreateDate;//蚚誧怀�賮譬晾京掉�
//		public string strCreateUserID;
//		public string strStatus;
//		public string strIfConfirm;
//		public string strDeActivedDate;
//		public string strDeActivedOperatorID;
//		public string strConfirmReason;
//		public string strConfirmReasonXML;
//
//		public string strOperationIDXML;
//		public string strOperationNameXML;
//
//		public string strWenZhi125XML;
//		public string strWenZhi125BeforeXML;
//		public string strWenZhi125AfterXML;
//
//		public string strWenWan125XML;
//		public string strWenWan125BeforeXML;
//		public string strWenWan125AfterXML;
//
//		public string strXiaoZhi14XML;
//		public string strXiaoZhi14BeforeXML;
//		public string strXiaoZhi14AfterXML;
//
//		public string strXiaoWan14XML;
//		public string strXiaoWan14BeforeXML;
//		public string strXiaoWan14AfterXML;
//
//		public string strZhongZhi16XML;
//		public string strZhongZhi16BeforeXML;
//		public string strZhongZhi16AfterXML;
//
//		public string strZhongWan16XML;
//		public string strZhongWan16BeforeXML;
//		public string strZhongWan16AfterXML;
//	
//		public string strChiZhenQian18XML;
//		public string strChiZhenQian18BeforeXML;
//		public string strChiZhenQian18AfterXML;
//
//		public string strJinQianXML;
//		public string strJinQianBeforeXML;
//		public string strJinQianAfterXML;
//
//		public string strQuanQianXML;
//		public string strQuanQianBeforeXML;
//		public string strQuanQianAfterXML;
//
//		public string strZhiYouChiXueGuanQianXML;
//		public string strZhiYouChiXueGuanQianBeforeXML;
//		public string strZhiYouChiXueGuanQianAfterXML;
//
//		public string strPiQianXML;
//		public string strPiQianBeforeXML;
//		public string strPiQianAfterXML;
//	
//
//		public string strYouChiNieXML;
//		public string strYouChiNieBeforeXML;
//		public string strYouChiNieAfterXML;
//
//		public string strDaoBing7XML;
//		public string strDaoBing7BeforeXML;
//		public string strDaoBing7AfterXML;
//
//		public string strDaoBing4XML;
//		public string strDaoBing4BeforeXML;
//		public string strDaoBing4AfterXML;
//
//		public string strDaoBing3XML;
//		public string strDaoBing3BeforeXML;
//		public string strDaoBing3AfterXML;
//
//		public string strChangYaBanXML;
//		public string strChangYaBanBeforeXML;
//		public string strChangYaBanAfterXML;
//
//		public string strWuChiNieXML;
//		public string strWuChiNieBeforeXML;
//		public string strWuChiNieAfterXML;
//
//	
//
//		public string strLanWeiLaGouXML;
//		public string strLanWeiLaGouBeforeXML;
//		public string strLanWeiLaGouAfterXML;
//
//		public string strZhiJiaoXiaoLaGouXML;
//		public string strZhiJiaoXiaoLaGouBeforeXML;
//		public string strZhiJiaoXiaoLaGouAfterXML;
//
//		public string strXiongQiangJianXML;
//		public string strXiongQiangJianBeforeXML;
//		public string strXiongQiangJianAfterXML;
//
//		public string strBianTaoXianJianXML;
//		public string strBianTaoXianJianBeforeXML;
//		public string strBianTaoXianJianAfterXML;
//
//		public string strZhiZhuZhiJianXML;
//		public string strZhiZhuZhiJianBeforeXML;
//		public string strZhiZhuZhiJianAfterXML;
//
//		public string strWanZhuZhiJianXML;
//		public string strWanZhuZhiJianBeforeXML;
//		public string strWanZhuZhiJianAfterXML;
//	
//
//		public string strXiYeGuanXML;
//		public string strXiYeGuanBeforeXML;
//		public string strXiYeGuanAfterXML;
//
//		public string strTongQuanXML;
//		public string strTongQuanBeforeXML;
//		public string strTongQuanAfterXML;
//
//		public string strXiaFuBuQianKaiQiXML;
//		public string strXiaFuBuQianKaiQiBeforeXML;
//		public string strXiaFuBuQianKaiQiAfterXML;
//
//		public string strZhiJiaoGouXML;
//		public string strZhiJiaoGouBeforeXML;
//		public string strZhiJiaoGouAfterXML;
//
//		public string strChangYaGouXML;
//		public string strChangYaGouBeforeXML;
//		public string strChangYaGouAfterXML;
//
//		public string strZhongFuGouXML;
//		public string strZhongFuGouBeforeXML;
//		public string strZhongFuGouAfterXML;
//	
//
//		public string strWanXueGuanQian22XML;
//		public string strWanXueGuanQian22BeforeXML;
//		public string strWanXueGuanQian22AfterXML;
//
//		public string strWanXueGuanQian20XML;
//		public string strWanXueGuanQian20BeforeXML;
//		public string strWanXueGuanQian20AfterXML;
//
//		public string strWanXueGuanQian18XML;
//		public string strWanXueGuanQian18BeforeXML;
//		public string strWanXueGuanQian18AfterXML;
//
//		public string strNianMoQianXML;
//		public string strNianMoQianBeforeXML;
//		public string strNianMoQianAfterXML;
//
//		public string strShaLiQianXML;
//		public string strShaLiQianBeforeXML;
//		public string strShaLiQianAfterXML;
//	
//
//		public string strDaoPianXML;
//		public string strDaoPianBeforeXML;
//		public string strDaoPianAfterXML;
//
//		public string strFengZhenXML;
//		public string strFengZhenBeforeXML;
//		public string strFengZhenAfterXML;
//
//		public string strChangChiZhenQian25XML;
//		public string strChangChiZhenQian25BeforeXML;
//		public string strChangChiZhenQian25AfterXML;
//
//		public string strZhiJiaoQianXML;
//		public string strZhiJiaoQianBeforeXML;
//		public string strZhiJiaoQianAfterXML;
//
//		public string strDaZhiQianXML;
//		public string strDaZhiQianBeforeXML;
//		public string strDaZhiQianAfterXML;
//
//	
//
//		public string strWanXueGuanQian25XML;
//		public string strWanXueGuanQian25BeforeXML;
//		public string strWanXueGuanQian25AfterXML;
//
//		public string strDaWanXueGuanQianXML;
//		public string strDaWanXueGuanQianBeforeXML;
//		public string strDaWanXueGuanQianAfterXML;
//
//		public string strShenDiQianXML;
//		public string strShenDiQianBeforeXML;
//		public string strShenDiQianAfterXML;
//
//		public string strChangQianZhiXML;
//		public string strChangQianZhiBeforeXML;
//		public string strChangQianZhiAfterXML;
//
//	
//
//		public string strChangQianWanXML;
//		public string strChangQianWanBeforeXML;
//		public string strChangQianWanAfterXML;
//
//		public string strShiQianXML;
//		public string strShiQianBeforeXML;
//		public string strShiQianAfterXML;
//
//		public string strWeiQianXML;
//		public string strWeiQianBeforeXML;
//		public string strWeiQianAfterXML;
//
//		public string strXinErQianXML;
//		public string strXinErQiaBeforeXML;
//		public string strXinErQiaAfterXML;
//
//		public string strErYanHouChongXiQiXML;
//		public string strErYanHouChongXiQiBeforeXML;
//		public string strErYanHouChongXiQiAfterXML;
//
//	
//
//		public string strTanZhenChuXML;
//		public string strTanZhenChuBeforeXML;
//		public string strTanZhenChuAfterXML;
//
//		public string strTanZhenXiXML;
//		public string strTanZhenXiBeforeXML;
//		public string strTanZhenXiAfterXML;
//
//		public string strDanDaoTanTiaoXML;
//		public string strDanDaoTanTiaoBeforeXML;
//		public string strDanDaoTanTiaoAfterXML;
//
//		public string strLeiGuQianKaiQiXML;
//		public string strLeiGuQianKaiQiBeforeXML;
//		public string strLeiGuQianKaiQiAfterXML;
//
//		public string strHeLongQiXML;
//		public string strHeLongQiBeforeXML;
//		public string strHeLongQiAfterXML;
//
//	
//
//		public string strJianJiaGuLaGouXML;
//		public string strJianJiaGuLaGouBeforeXML;
//		public string strJianJiaGuLaGouAfterXML;
//
//		public string strLeiGuQiZiXML;
//		public string strLeiGuQiZiBeforeXML;
//		public string strLeiGuQiZiAfterXML;
//
//		public string strDaGuJianXML;
//		public string strDaGuJianBeforeXML;
//		public string strDaGuJianAfterXML;
//
//		public string strDiErLeiGuJianXML;
//		public string strDiErLeiGuJianBeforeXML;
//		public string strDiErLeiGuJianAfterXML;
//
//		public string strFangTouYaoGuQianXML;
//		public string strFangTouYaoGuQianBeforeXML;
//		public string strFangTouYaoGuQianAfterXML;
//
//		public string strYaoGuQianXML;
//		public string strYaoGuQianBeforeXML;
//		public string strYaoGuQianAfterXML;
//	
//
//		public string strGuMoBoLiQiXML;
//		public string strGuMoBoLiQiBeforeXML;
//		public string strGuMoBoLiQiAfterXML;
//
//		public string strGuDaoXML;
//		public string strGuDaoBeforeXML;
//		public string strGuDaoAfterXML;
//
//		public string strGuZaoXML;
//		public string strGuZaoBeforeXML;
//		public string strGuZaoAfterXML;
//
//		public string strKuoShiXML;
//		public string strKuoShiBeforeXML;
//		public string strKuoShiAfterXML;
//
//		public string strGuChuiXML;
//		public string strGuChuiBeforeXML;
//		public string strGuChuiAfterXML;
//
//		public string strChiGuQianXML;
//		public string strChiGuQianBeforeXML;
//		public string strChiGuQianAfterXML;
//
//		
//
//		public string strJingGuQiZiXML;
//		public string strJingGuQiZiBeforeXML;
//		public string strJingGuQiZiAfterXML;
//
//		public string strDanChiLaGouXML;
//		public string strDanChiLaGouBeforeXML;
//		public string strDanChiLaGouAfterXML;
//
//		public string strLaoHuQianXML;
//		public string strLaoHuQianBeforeXML;
//		public string strLaoHuQianAfterXML;
//
//		public string strPingHengFuWeiQianXML;
//		public string strPingHengFuWeiQianBeforeXML;
//		public string strPingHengFuWeiQianAfterXML;
//
//		public string strLuoSiQiZiXML;
//		public string strLuoSiQiZiBeforeXML;
//		public string strLuoSiQiZiAfterXML;
//
//		public string strDaoXiangQiXML;
//		public string strDaoXiangQiBeforeXML;
//		public string strDaoXiangQiAfterXML;
//
//	
//
//		public string strZhuiBanYaoGuQianXML;
//		public string strZhuiBanYaoGuQianBeforeXML;
//		public string strZhuiBanYaoGuQianAfterXML;
//
//		public string strShuiHeQianXML;
//		public string strShuiHeQianBeforeXML;
//		public string strShuiHeQianAfterXML;
//
//		public string strJingTuJianXML;
//		public string strJingTuJianBeforeXML;
//		public string strJingTuJianAfterXML;
//
//		public string strZhuiBanBoLiQiXML;
//		public string strZhuiBanBoLiQiBeforeXML;
//		public string strZhuiBanBoLiQiAfterXML;
//
//		public string strJianBoLiZiXML;
//		public string strJianBoLiZiBeforeXML;
//		public string strJianBoLiZiAfterXML;
//
//		public string strQiangZhuangNieXML;
//		public string strQiangZhuangNieBeforeXML;
//		public string strQiangZhuangNieAfterXML;
//
//	
//
//		public string strBaiShiQianKaiQiXML;
//		public string strBaiShiQianKaiQiBeforeXML;
//		public string strBaiShiQianKaiQiAfterXML;
//
//		public string strKaiLuZhuanXML;
//		public string strKaiLuZhuanBeforeXML;
//		public string strKaiLuZhuanAfterXML;
//
//		public string strTouPiJianQianXML;
//		public string strTouPiJianQianBeforeXML;
//		public string strTouPiJianQianAfterXML;
//
//		public string strXianJuDaoYinZiXML;
//		public string strXianJuDaoYinZiBeforeXML;
//		public string strXianJuDaoYinZiAfterXML;
//
//		public string strXinErLaGouXML;
//		public string strXinErLaGouBeforeXML;
//		public string strXinErLaGouAfterXML;
//
//		public string strChiBanQianXML;
//		public string strChiBanQianBeforeXML;
//		public string strChiBanQianAfterXML;
//
//	
//
//		public string strXinFangLaGouXML;
//		public string strXinFangLaGouBeforeXML;
//		public string strXinFangLaGouAfterXML;
//
//		public string strNaoMoGouXML;
//		public string strNaoMoGouBeforeXML;
//		public string strNaoMoGouAfterXML;
//
//		public string strChuanCiZhenXML;
//		public string strChuanCiZhenBeforeXML;
//		public string strChuanCiZhenAfterXML;
//
//		public string strYinDingQianXML;
//		public string strYinDingQianBeforeXML;
//		public string strYinDingQianAfterXML;
//
//		public string strFeiYeDangBanXML;
//		public string strFeiYeDangBanBeforeXML;
//		public string strFeiYeDangBanAfterXML;
//
//		public string strZhuAZhuDuanQianXML;
//		public string strZhuAZhuDuanQianBeforeXML;
//		public string strZhuAZhuDuanQianAfterXML;
//
//
//	
//
//		public string strZhuAYouLiQianXML;
//		public string strZhuAYouLiQianBeforeXML;
//		public string strZhuAYouLiQianAfterXML;
//
//		public string strZhuACeBiQianXML;
//		public string strZhuACeBiQiBeforeXML;
//		public string strZhuACeBiQiAfterXML;
//
//		public string strErJianBanKuoZhangQiXML;
//		public string strErJianBanKuoZhangQiBeforeXML;
//		public string strErJianBanKuoZhangQiAfterXML;
//
//		public string strCeBanQiXML;
//		public string strCeBanQiBeforeXML;
//		public string strCeBanQiAfterXML;
//
//		public string strXinNeiZhiJiaoLaGouXML;
//		public string strXinNeiZhiJiaoLaGouBeforeXML;
//		public string strXinNeiZhiJiaoLaGouAfterXML;
//
//		public string strDaoXianGouXML;
//		public string strDaoXianGouBeforeXML;
//		public string strDaoXianGouAfterXML;
//	
//		public string strWuChuangNieXML;
//		public string strWuChuangNieAfterXML;
//		public string strWuChuangNieBeforeXML;
//
//		public string strKaChiXML;
//		public string strKaChiAfterXML;
//		public string strKaChiBeforeXML;
//
//		public string strShenJingLaGouXML;
//		public string strShenJingLaGouAfterXML;
//		public string strShenJingLaGouBeforeXML;
//
//		public string strXueGuanJiaXML;
//		public string strXueGuanJiaAfterXML;
//		public string strXueGuanJiaBeforeXML;
//
//		public string strFuKuiXML;
//		public string strFuKuiAfterXML;
//		public string strFuKuiBeforeXML;
//
//		public string strGongChiXML;
//		public string strGongChiAfterXML;
//		public string strGongChiBeforeXML;
//	
//
//		public string strGongGuaShiXML;
//		public string strGongGuaShiAfterXML;
//		public string strGongGuaShiBeforeXML;
//
//		public string strGongJingQianXML;
//		public string strGongJingQianAfterXML;
//		public string strGongJingQianBeforeXML;
//
//		public string strYinDaoLaGouXML;
//		public string strYinDaoLaGouAfterXML;
//		public string strYinDaoLaGouBeforeXML;
//
//		public string strRenDaiQianXML;
//		public string strRenDaiQianAfterXML;
//		public string strRenDaiQianBeforeXML;
//
//		public string strJiLiuBoLiZiXML;
//		public string strJiLiuBoLiZiAfterXML;
//		public string strJiLiuBoLiZiBeforeXML;
//
//		public string strKuoGongQiXML;
//		public string strKuoGongQiAfterXML;
//		public string strKuoGongQiBeforeXML;
//	
//		public string strFuGuoQianXML;
//		public string strFuGuoQianAfterXML;
//		public string strFuGuoQianBeforeXML;
//
//		public string strJinShuNiaoGouXML;
//		public string strJinShuNiaoGouAfterXML;
//		public string strJinShuNiaoGouBeforeXML;
//
//		public string strYouDaiFangDianXML;
//		public string strYouDaiFangDianAfterXML;
//		public string strYouDaiFangDianBeforeXML;
//
//		public string strWuDaiFangDianXML;
//		public string strWuDaiFangDianAfterXML;
//		public string strWuDaiFangDianBeforeXML;
//
//		public string strYouDaiChangDianXML;
//		public string strYouDaiChangDianAfterXML;
//		public string strYouDaiChangDianBeforeXML;
//
//		public string strWuDaiChangDianXML;
//		public string strWuDaiChangDianAfterXML;
//		public string strWuDaiChangDianBeforeXML;
//	
//
//		public string strFuNieYinLiuXML;
//		public string strFuNieYinLiuAfterXML;
//		public string strFuNieYinLiuBeforeXML;
//
//		public string strKaiLuMianXML;
//		public string strKaiLuMianAfterXML;
//		public string strKaiLuMianBeforeXML;
//
//		public string strQuanGongShaXML;
//		public string strQuanGongShaAfterXML;
//		public string strQuanGongShaBeforeXML;
//
//		public string strWangShaXML;
//		public string strWangShaAfterXML;
//		public string strWangShaBeforeXML;
//
//		public string strShaKuaiXML;
//		public string strShaKuaiAfterXML;
//		public string strShaKuaiBeforeXML;
//
//		public string strShaQiuXML;
//		public string strShaQiuAfterXML;
//		public string strShaQiuBeforeXML;
//	
//
//		public string strBianDaiXML;
//		public string strBianDaiAfterXML;
//		public string strBianDaiBeforeXML;
//
//		public string strChangQianTaoXML;
//		public string strChangQianTaoAfterXML;
//		public string strChangQianTaoBeforeXML;
//
//		public string strNiaoGuanXML;
//		public string strNiaoGuanAfterXML;
//		public string strNiaoGuanBeforeXML;
//
//	}
//	
//	
//	#endregion
//
//	#region 赽桶腔濬
//	/// <summary>
//	/// 赽桶腔濬1
//	/// </summary>
//	[Serializable]
//	public class clsOperationEqipmentQtyContent
//	{
//		public string strWenZhi125;
//		public string strWenZhi125Before;
//		public string strWenZhi125After;
//
//		public string strWenWan125;
//		public string strWenWan125Before;
//		public string strWenWan125After;
//
//		public string strXiaoZhi14;
//		public string strXiaoZhi14Before;
//		public string strXiaoZhi14After;
//
//		public string strXiaoWan14;
//		public string strXiaoWan14Before;
//		public string strXiaoWan14After;
//
//		public string strZhongZhi16;
//		public string strZhongZhi16Before;
//		public string strZhongZhi16After;
//
//		public string strZhongWan16;
//		public string strZhongWan16Before;
//		public string strZhongWan16After;
//
//		public string strInPatientID;
//		public string strInPatientDate;
//		public string strOpenDate;
//		public string strModifyDate;
//		public string strModifyUserID;
//		public string strOperationID;
//		public string strOperationName;
//		
//	
//
//		public string strYouChiNie;
//		public string strYouChiNieBefore;
//		public string strYouChiNieAfter;
//
//		public string strChiZhenQian18;
//		public string strChiZhenQian18Before;
//		public string strChiZhenQian18After;
//
//		public string strJinQian;
//		public string strJinQianBefore;
//		public string strJinQianAfter;
//
//		public string strQuanQian;
//		public string strQuanQianBefore;
//		public string strQuanQianAfter;
//
//		public string strZhiYouChiXueGuanQian;
//		public string strZhiYouChiXueGuanQianBefore;
//		public string strZhiYouChiXueGuanQianAfter;
//
//		public string strPiQian;
//		public string strPiQianBefore;
//		public string strPiQianAfter;
//
//		
//	
//
//		public string strDaoBing7;
//		public string strDaoBing7Before;
//		public string strDaoBing7After;
//
//		public string strDaoBing4;
//		public string strDaoBing4Before;
//		public string strDaoBing4After;
//
//		public string strDaoBing3;
//		public string strDaoBing3Before;
//		public string strDaoBing3After;
//
//		public string strChangYaBan;
//		public string strChangYaBanBefore;
//		public string strChangYaBanAfter;
//
//		public string strWuChiNie;
//		public string strWuChiNieBefore;
//		public string strWuChiNieAfter;
//	
//
//		public string strLanWeiLaGou;
//		public string strLanWeiLaGouBefore;
//		public string strLanWeiLaGouAfter;
//
//		public string strZhiJiaoXiaoLaGou;
//		public string strZhiJiaoXiaoLaGouBefore;
//		public string strZhiJiaoXiaoLaGouAfter;
//
//		public string strXiongQiangJian;
//		public string strXiongQiangJianBefore;
//		public string strXiongQiangJianAfter;
//
//		public string strBianTaoXianJian;
//		public string strBianTaoXianJianBefore;
//		public string strBianTaoXianJianAfter;
//
//		public string strZhiZhuZhiJian;
//		public string strZhiZhuZhiJianBefore;
//		public string strZhiZhuZhiJianAfter;
//
//		public string strWanZhuZhiJian;
//		public string strWanZhuZhiJianBefore;
//		public string strWanZhuZhiJianAfter;
//
//	
//
//		public string strXiYeGuan;
//		public string strXiYeGuanBefore;
//		public string strXiYeGuanAfter;
//
//		public string strTongQuan;
//		public string strTongQuanBefore;
//		public string strTongQuanAfter;
//
//		public string strXiaFuBuQianKaiQi;
//		public string strXiaFuBuQianKaiQiBefore;
//		public string strXiaFuBuQianKaiQiAfter;
//
//		public string strZhiJiaoGou;
//		public string strZhiJiaoGouBefore;
//		public string strZhiJiaoGouAfter;
//
//		public string strChangYaGou;
//		public string strChangYaGouBefore;
//		public string strChangYaGouAfter;
//
//		public string strZhongFuGou;
//		public string strZhongFuGouBefore;
//		public string strZhongFuGouAfter;
//
//		public string strZhiJiaoQian;
//		public string strZhiJiaoQianBefore;
//		public string strZhiJiaoQianAfter;
//
//		public string strDaZhiQian;
//		public string strDaZhiQianBefore;
//		public string strDaZhiQianAfter;
//	
//		public string strFengZhen;
//		public string strFengZhenBefore;
//		public string strFengZhenAfter;
//
//		public string strChangChiZhenQian25;
//		public string strChangChiZhenQian25Before;
//		public string strChangChiZhenQian25After;
//
//		public string strWanXueGuanQian25;
//		public string strWanXueGuanQian25Before;
//		public string strWanXueGuanQian25After;
//
//		public string strWanXueGuanQian22;
//		public string strWanXueGuanQian22Before;
//		public string strWanXueGuanQian22After;
//
//		public string strWanXueGuanQian20;
//		public string strWanXueGuanQian20Before;
//		public string strWanXueGuanQian20After;
//
//		public string strWanXueGuanQian18;
//		public string strWanXueGuanQian18Before;
//		public string strWanXueGuanQian18After;
//
//		public string strDaoPian;
//		public string strDaoPianBefore;
//		public string strDaoPianAfter;
//
//		public string strNianMoQian;
//		public string strNianMoQianBefore;
//		public string strNianMoQianAfter;
//
//		public string strShaLiQian;
//		public string strShaLiQianBefore;
//		public string strShaLiQianAfter;
//	
//
//		public string strDaWanXueGuanQian;
//		public string strDaWanXueGuanQianBefore;
//		public string strDaWanXueGuanQianAfter;
//
//		public string strShenDiQian;
//		public string strShenDiQianBefore;
//		public string strShenDiQianAfter;
//
//		public string strChangQianZhi;
//		public string strChangQianZhiBefore;
//		public string strChangQianZhiAfter;
//
//		public string strChangQianWan;
//		public string strChangQianWanBefore;
//		public string strChangQianWanAfter;
//
//		public string strShiQian;
//		public string strShiQianBefore;
//		public string strShiQianAfter;
//
//		public string strWeiQian;
//		public string strWeiQianBefore;
//		public string strWeiQianAfter;
//
//		public string strXinErQian;
//		public string strXinErQiaBefore;
//		public string strXinErQiaAfter;
//
//		public string strErYanHouChongXiQi;
//		public string strErYanHouChongXiQiBefore;
//		public string strErYanHouChongXiQiAfter;
//
//	
//		public string strTanZhenChu;
//		public string strTanZhenChuBefore;
//		public string strTanZhenChuAfter;
//
//		public string strTanZhenXi;
//		public string strTanZhenXiBefore;
//		public string strTanZhenXiAfter;
//
//		public string strDanDaoTanTiao;
//		public string strDanDaoTanTiaoBefore;
//		public string strDanDaoTanTiaoAfter;
//
//		public string strLeiGuQianKaiQi;
//		public string strLeiGuQianKaiQiBefore;
//		public string strLeiGuQianKaiQiAfter;
//
//		public string strHeLongQi;
//		public string strHeLongQiBefore;
//		public string strHeLongQiAfter;
//
//		public string strJianJiaGuLaGou;
//		public string strJianJiaGuLaGouBefore;
//		public string strJianJiaGuLaGouAfter;
//
//		public string strLeiGuQiZi;
//		public string strLeiGuQiZiBefore;
//		public string strLeiGuQiZiAfter;
//
//		public string strDaGuJian;
//		public string strDaGuJianBefore;
//		public string strDaGuJianAfter;
//
//		public string strDiErLeiGuJian;
//		public string strDiErLeiGuJianBefore;
//		public string strDiErLeiGuJianAfter;
//
//		public string strFangTouYaoGuQian;
//		public string strFangTouYaoGuQianBefore;
//		public string strFangTouYaoGuQianAfter;
//
//		public string strYaoGuQian;
//		public string strYaoGuQianBefore;
//		public string strYaoGuQianAfter;
//	
//
//		public string strGuMoBoLiQi;
//		public string strGuMoBoLiQiBefore;
//		public string strGuMoBoLiQiAfter;
//
//		public string strGuDao;
//		public string strGuDaoBefore;
//		public string strGuDaoAfter;
//
//		public string strGuZao;
//		public string strGuZaoBefore;
//		public string strGuZaoAfter;
//
//		public string strKuoShi;
//		public string strKuoShiBefore;
//		public string strKuoShiAfter;
//
//		public string strGuChui;
//		public string strGuChuiBefore;
//		public string strGuChuiAfter;
//
//		public string strChiGuQian;
//		public string strChiGuQianBefore;
//		public string strChiGuQianAfter;
//
//		
//		public string strJingGuQiZi;
//		public string strJingGuQiZiBefore;
//		public string strJingGuQiZiAfter;
//
//		public string strDanChiLaGou;
//		public string strDanChiLaGouBefore;
//		public string strDanChiLaGouAfter;
//
//		public string strLaoHuQian;
//		public string strLaoHuQianBefore;
//		public string strLaoHuQianAfter;
//
//		public string strPingHengFuWeiQian;
//		public string strPingHengFuWeiQianBefore;
//		public string strPingHengFuWeiQianAfter;
//
//		public string strLuoSiQiZi;
//		public string strLuoSiQiZiBefore;
//		public string strLuoSiQiZiAfter;
//
//		public string strDaoXiangQi;
//		public string strDaoXiangQiBefore;
//		public string strDaoXiangQiAfter;
//	
//
//		public string strZhuiBanYaoGuQian;
//		public string strZhuiBanYaoGuQianBefore;
//		public string strZhuiBanYaoGuQianAfter;
//
//		public string strShuiHeQian;
//		public string strShuiHeQianBefore;
//		public string strShuiHeQianAfter;
//
//		public string strJingTuJian;
//		public string strJingTuJianBefore;
//		public string strJingTuJianAfter;
//
//		public string strZhuiBanBoLiQi;
//		public string strZhuiBanBoLiQiBefore;
//		public string strZhuiBanBoLiQiAfter;
//
//		public string strJianBoLiZi;
//		public string strJianBoLiZiBefore;
//		public string strJianBoLiZiAfter;
//
//		public string strQiangZhuangNie;
//		public string strQiangZhuangNieBefore;
//		public string strQiangZhuangNieAfter;
//
//		public string strBaiShiQianKaiQi;
//		public string strBaiShiQianKaiQiBefore;
//		public string strBaiShiQianKaiQiAfter;
//
//		public string strKaiLuZhuan;
//		public string strKaiLuZhuanBefore;
//		public string strKaiLuZhuanAfter;
//
//		public string strTouPiJianQian;
//		public string strTouPiJianQianBefore;
//		public string strTouPiJianQianAfter;
//
//		public string strXianJuDaoYinZi;
//		public string strXianJuDaoYinZiBefore;
//		public string strXianJuDaoYinZiAfter;
//
//		public string strXinErLaGou;
//		public string strXinErLaGouBefore;
//		public string strXinErLaGouAfter;
//
//		public string strChiBanQian;
//		public string strChiBanQianBefore;
//		public string strChiBanQianAfter;
//	
//		public string strXinFangLaGou;
//		public string strXinFangLaGouBefore;
//		public string strXinFangLaGouAfter;
//
//		public string strNaoMoGou;
//		public string strNaoMoGouBefore;
//		public string strNaoMoGouAfter;
//
//		public string strChuanCiZhen;
//		public string strChuanCiZhenBefore;
//		public string strChuanCiZhenAfter;
//
//		public string strYinDingQian;
//		public string strYinDingQianBefore;
//		public string strYinDingQianAfter;
//
//		public string strFeiYeDangBan;
//		public string strFeiYeDangBanBefore;
//		public string strFeiYeDangBanAfter;
//
//		public string strZhuAZhuDuanQian;
//		public string strZhuAZhuDuanQianBefore;
//		public string strZhuAZhuDuanQianAfter;
//
//		public string strZhuAYouLiQian;
//		public string strZhuAYouLiQianBefore;
//		public string strZhuAYouLiQianAfter;
//
//		public string strZhuACeBiQian;
//		public string strZhuACeBiQiBefore;
//		public string strZhuACeBiQiAfter;
//
//		public string strErJianBanKuoZhangQi;
//		public string strErJianBanKuoZhangQiBefore;
//		public string strErJianBanKuoZhangQiAfter;
//
//		public string strCeBanQi;
//		public string strCeBanQiBefore;
//		public string strCeBanQiAfter;
//
//		public string strXinNeiZhiJiaoLaGou;
//		public string strXinNeiZhiJiaoLaGouBefore;
//		public string strXinNeiZhiJiaoLaGouAfter;
//
//		public string strDaoXianGou;
//		public string strDaoXianGouBefore;
//		public string strDaoXianGouAfter;
//
//	
//
//		public string strWuChuangNie;
//		public string strWuChuangNieAfter;
//		public string strWuChuangNieBefore;
//
//		public string strKaChi;
//		public string strKaChiAfter;
//		public string strKaChiBefore;
//
//		public string strShenJingLaGou;
//		public string strShenJingLaGouAfter;
//		public string strShenJingLaGouBefore;
//
//		public string strXueGuanJia;
//		public string strXueGuanJiaAfter;
//		public string strXueGuanJiaBefore;
//
//		public string strFuKui;
//		public string strFuKuiAfter;
//		public string strFuKuiBefore;
//
//		public string strGongChi;
//		public string strGongChiAfter;
//		public string strGongChiBefore;
//
//		public string strGongGuaShi;
//		public string strGongGuaShiAfter;
//		public string strGongGuaShiBefore;
//
//		public string strGongJingQian;
//		public string strGongJingQianAfter;
//		public string strGongJingQianBefore;
//
//		public string strYinDaoLaGou;
//		public string strYinDaoLaGouAfter;
//		public string strYinDaoLaGouBefore;
//
//		public string strRenDaiQian;
//		public string strRenDaiQianAfter;
//		public string strRenDaiQianBefore;
//
//		public string strJiLiuBoLiZi;
//		public string strJiLiuBoLiZiAfter;
//		public string strJiLiuBoLiZiBefore;
//
//		public string strKuoGongQi;
//		public string strKuoGongQiAfter;
//		public string strKuoGongQiBefore;
//
//	
//		public string strFuGuoQian;
//		public string strFuGuoQianAfter;
//		public string strFuGuoQianBefore;
//
//		public string strJinShuNiaoGou;
//		public string strJinShuNiaoGouAfter;
//		public string strJinShuNiaoGouBefore;
//
//		public string strYouDaiFangDian;
//		public string strYouDaiFangDianAfter;
//		public string strYouDaiFangDianBefore;
//
//		public string strWuDaiFangDian;
//		public string strWuDaiFangDianAfter;
//		public string strWuDaiFangDianBefore;
//
//		public string strYouDaiChangDian;
//		public string strYouDaiChangDianAfter;
//		public string strYouDaiChangDianBefore;
//
//		public string strWuDaiChangDian;
//		public string strWuDaiChangDianAfter;
//		public string strWuDaiChangDianBefore;
//
//		public string strFuNieYinLiu;
//		public string strFuNieYinLiuAfter;
//		public string strFuNieYinLiuBefore;
//
//		public string strKaiLuMian;
//		public string strKaiLuMianAfter;
//		public string strKaiLuMianBefore;
//
//		public string strQuanGongSha;
//		public string strQuanGongShaAfter;
//		public string strQuanGongShaBefore;
//
//		public string strWangSha;
//		public string strWangShaAfter;
//		public string strWangShaBefore;
//
//		public string strShaKuai;
//		public string strShaKuaiAfter;
//		public string strShaKuaiBefore;
//
//		public string strShaQiu;
//		public string strShaQiuAfter;
//		public string strShaQiuBefore;
//
//	
//
//		public string strBianDai;
//		public string strBianDaiAfter;
//		public string strBianDaiBefore;
//
//		public string strChangQianTao;
//		public string strChangQianTaoAfter;
//		public string strChangQianTaoBefore;
//
//		public string strNiaoGuan;
//		public string strNiaoGuanAfter;
//		public string strNiaoGuanBefore;
//
//	}
//
//
//
//
//	#endregion
//
//	/// <summary>                                                
//	/// 誘尪ワ靡
//	/// </summary>
//	[Serializable]
//	public class clsOperationNurse
//	{
//		public string strInPatientID;
//		public string strInPatientDate;
//		public string strOpenDate;
//		public string strNurseID;
//		/// <summary>
//		/// 誘尪靡備ㄛ躺婓黍堤奀董硉
//		/// </summary>
//		public string strNurseName;
//		public string strNurseFlag;
//		public string strStatus;
//		public string strDeActivedDate;
//		public string strDeActivedOperatorID;
//	}

	public class clsEmployeeIDName
	{
		public string strEmployeeID;
		public string strEmployeeName;
	}


//	[Serializable]
//	public class clsOperationEquipmentPackage
//	{
//		//翋桶
//		public clsOperationEqipmentQtyXML m_objOperationEqipmentQtyXML;
//		
//		//赽桶
//		public clsOperationEqipmentQtyContent m_objOperationEqipmentQtyContent;
//		
//		//誘尪
//		public clsOperationNurse [] m_objOperationNurse;
//	}
}
