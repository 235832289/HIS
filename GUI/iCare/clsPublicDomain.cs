using System;
using System.IO ;
using System .Xml ;
using com.digitalwave.PublicMiddleTier;

namespace iCare
{
	/// <summary>
	/// Summary description for clsPublicDomain.
	/// </summary>
	public class clsPublicDomain
	{
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
        //private com.digitalwave.PublicMiddleTier.clsPublicMiddleTier m_objServ;

		public clsPublicDomain()
		{
			//
			// TODO: Add constructor logic here
			//
            //m_objServ=new com.digitalwave.PublicMiddleTier.clsPublicMiddleTier();
			m_objXmlMemStream = new MemoryStream(300);
			m_objXmlWriter = new XmlTextWriter(m_objXmlMemStream,System.Text.Encoding.Unicode);
			m_objXmlWriter.Flush();//清空原来的字符
			m_objXmlParser = new XmlParserContext(null,null,null,XmlSpace.None,System.Text.Encoding.Unicode);
		}



		/// <summary>
		/// 获得Middle Tier 端的时间
		/// </summary>
		/// <returns></returns>
		public string m_strGetServerTime()
		{
            com.digitalwave.PublicMiddleTier.clsPublicMiddleTier m_objServ =
                (com.digitalwave.PublicMiddleTier.clsPublicMiddleTier)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.PublicMiddleTier.clsPublicMiddleTier));

            string strRes = "";
			try
            {
                strRes = m_objServ.m_strGetServerTime(clsLoginContext.s_ObjLoginContext.m_ObjPrincial);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return strRes;
		}

		/// <summary>
		/// 获得Middle Tier 端的时间
		/// </summary>
		/// <returns></returns>
		public DateTime m_dtmGetServerTime()
		{
            com.digitalwave.PublicMiddleTier.clsPublicMiddleTier m_objServ =
                (com.digitalwave.PublicMiddleTier.clsPublicMiddleTier)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.PublicMiddleTier.clsPublicMiddleTier));

            string strDateTime = "";
			try
            {
			    strDateTime = m_objServ.m_strGetServerTime(clsLoginContext.s_ObjLoginContext.m_ObjPrincial);
            }
            finally
            {
                //m_objServ.Dispose();
            }
			return DateTime.Parse(strDateTime);
        }

        #region 获取入院登记流水号
        /// <summary>
        /// 获取入院登记流水号
        /// </summary>
        /// <param name="p_strPatientID">病人ID</param>
        /// <param name="p_strInPatientDate">HIS住院日期</param>
        /// <param name="p_strRegisterID">入院登记流水号</param>
        /// <returns></returns>
        public long m_lngGetRegisterID(string p_strPatientID, string p_strInPatientDate, out string p_strRegisterID)
        {
            p_strRegisterID = "";
            long lngRes = 0;
            com.digitalwave.PatientManagerService.clsPatientManagerService objServ =
                (com.digitalwave.PatientManagerService.clsPatientManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.PatientManagerService.clsPatientManagerService));

            lngRes = objServ.m_lngGetRegisterIDByPatient(p_strPatientID, p_strInPatientDate, out p_strRegisterID);
            return lngRes;
        } 
        #endregion

        #region 获取指定员工申请查阅指定病人病案的审批情况
        /// <summary>
        /// 获取指定员工申请查阅指定病人病案的审批情况,
        /// 只查询查阅申请结束时间未超过当前时间的记录
        /// </summary>
        /// <param name="p_strSubscriberID">员工ID</param>
        /// <param name="p_strRegisterID">病人入院登记号</param>
        /// <param name="p_intSubscribStatusArr">审批情况</param>
        /// <returns></returns>
        public long m_lngGetSpecifyApproveInfo(string p_strSubscriberID, string p_strRegisterID, out int[] p_intSubscribStatusArr)
        {
            p_intSubscribStatusArr = null;

            com.digitalwave.emr.EMR_CaseArchivingService.clsEMR_ApproveArchivedCaseService objServ =
                (com.digitalwave.emr.EMR_CaseArchivingService.clsEMR_ApproveArchivedCaseService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.emr.EMR_CaseArchivingService.clsEMR_ApproveArchivedCaseService));

            long lngRes = objServ.m_lngGetSpecifyApproveInfo(null, p_strSubscriberID, p_strRegisterID, out p_intSubscribStatusArr);
            return lngRes;
        } 
        #endregion
	}
}
