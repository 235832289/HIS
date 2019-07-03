using System;
using iCareData;
using com.digitalwave.BaseCaseHistorySevice;
using com.digitalwave.Utility.Controls;
using com.digitalwave.PatientManagerService;

namespace iCare
{
	/// <summary>
	/// Summary description for clsInPatientCaseHistoryDomain.
	/// </summary>
	public class clsBaseCaseHistoryDomain
	{
		
        //private clsBaseCaseHistorySevice m_objBaseServ;
        private enmBaseCaseHistoryTypeInfo m_enmProcessType = new enmBaseCaseHistoryTypeInfo();

		// 构造函数。参数为指定的中间件。
        public clsBaseCaseHistoryDomain(enmBaseCaseHistoryTypeInfo p_enmProcessType)
		{
            //m_objBaseServ =  p_objProcessServ;
            m_enmProcessType = p_enmProcessType;
		}

		// 获取病人该特殊记录的时间列表。
		public long m_lngGetRecordTimeList(string p_strInPatientID,
			out string[] p_strInPatientDateArr,
			out string[] p_strCreateRecordTimeArr,
			out string[] p_strOpenRecordTimeArr)
		{
			//参数判断
			p_strCreateRecordTimeArr=null;
			p_strOpenRecordTimeArr=null;

            clsBaseCaseHistorySevice m_objBaseServ = clsCaseHistoryFactory.s_objGetDomain(m_enmProcessType);
            long m_lngRes = 0;
            try
            {
                m_lngRes = m_objBaseServ.m_lngGetRecordTimeList(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, out p_strInPatientDateArr, out p_strCreateRecordTimeArr, out p_strOpenRecordTimeArr);
            }
            finally
            {
                //m_objBaseServ.Dispose();
            }
            return m_lngRes;
		}

		// 获取指定记录内容。
		public long m_lngGetRecordContent(string p_strInPatientID,
			string p_strInPatientDate,/*string p_strOpenRecordTime,*/
			out clsBaseCaseHistoryInfo  p_objRecordContent,
			out clsPictureBoxValue[] p_objPicValueArr)
		{
			//参数判断
			p_objRecordContent=null;
			clsBaseCaseHistorySevice m_objBaseServ = clsCaseHistoryFactory.s_objGetDomain(m_enmProcessType);
            long m_lngRes = 0;
            try
            {
                m_lngRes = m_objBaseServ.m_lngGetRecordContent(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate,/*p_strOpenRecordTime,*/out p_objRecordContent,out p_objPicValueArr);
            }
            finally
            {
                //m_objBaseServ.Dispose();
            }
            return m_lngRes;
		}

		// 添加新记录。
		public long m_lngAddNewRecord(clsBaseCaseHistoryInfo  p_objRecordContent,clsPictureBoxValue[] p_objPicValueArr,string p_strDiseaseID,out clsPreModifyInfo p_objModifyInfo)
		{
			//参数判断
			p_objModifyInfo=null;
			clsBaseCaseHistorySevice m_objBaseServ = clsCaseHistoryFactory.s_objGetDomain(m_enmProcessType);
            long m_lngRes = 0;
            try
            {
                m_lngRes = m_objBaseServ.m_lngAddNewRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_objRecordContent,p_objPicValueArr,p_strDiseaseID,clsSystemContext.s_ObjCurrentContext.m_ObjDepartment.m_StrDeptID,out p_objModifyInfo);
            }
            finally
            {
                //m_objBaseServ.Dispose();
            }
            return m_lngRes;
		}		

		// 修改记录。
		public long m_lngModifyRecord(clsInPatientCaseHistoryContent p_objOldRecordContent,
			clsInPatientCaseHistoryContent p_objNewRecordContent,clsPictureBoxValue[] p_objPicValueArr,
			string p_strDiseaseID,
			out clsPreModifyInfo p_objModifyInfo)
		{
			//参数判断
			p_objModifyInfo=null;
			clsBaseCaseHistorySevice m_objBaseServ = clsCaseHistoryFactory.s_objGetDomain(m_enmProcessType);
            long m_lngRes = 0;
            try
            {
                m_lngRes = m_objBaseServ.m_lngModifyRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_objOldRecordContent,p_objNewRecordContent,p_objPicValueArr,p_strDiseaseID,clsSystemContext.s_ObjCurrentContext.m_ObjDepartment.m_StrDeptID,out p_objModifyInfo);
            }
            finally
            {
                //m_objBaseServ.Dispose();
            }
            return m_lngRes;
		}

		// 删除记录。
		public long m_lngDeleteRecord(clsInPatientCaseHistoryContent p_objRecordContent,out clsPreModifyInfo p_objModifyInfo)
		{
			//参数判断
		
			clsBaseCaseHistorySevice m_objBaseServ = clsCaseHistoryFactory.s_objGetDomain(m_enmProcessType);
            long m_lngRes = 0;
            try
            {
                m_lngRes = m_objBaseServ.m_lngDeleteRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_objRecordContent,out p_objModifyInfo);
            }
            finally
            {
                //m_objBaseServ.Dispose();
            }
            return m_lngRes;
		}

		// 作废重做记录。
		public long m_lngReAddNewRecord(clsInPatientCaseHistoryContent m_objDelRecord,
			clsInPatientCaseHistoryContent m_objAddNewRecord,
			out clsPreModifyInfo p_objModifyInfo)
		{
			//参数判断
			p_objModifyInfo=null;

			clsBaseCaseHistorySevice m_objBaseServ = clsCaseHistoryFactory.s_objGetDomain(m_enmProcessType);
            long m_lngRes = 0;
            try
            {
                m_lngRes = m_objBaseServ.m_lngReAddNewRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,m_objDelRecord,m_objAddNewRecord,out p_objModifyInfo);
            }
            finally
            {
                //m_objBaseServ.Dispose();
            }
            return m_lngRes;
		}

		// 获取打印信息。
		// 1.获取打印内容：如果输入参数p_dtmModifyDate不是最新的ModifyDate，输出变量 p_objContent
		//   会存放最新的内容；否则，输出变量为null。
		// 2.获取打印时间：输出变量 p_dtmFirstPrintDate 存放首次打印时间。p_blnIsFirstPrint标记
		//   是否首次打印，如果是为true，客户端在打印后需要保存p_dtmFirstPrintDate到数据库。
		public long m_lngGetPrintInfo(string p_strInPatientID,string p_strInPatientDate,/*string p_strOpenDate,*/DateTime p_dtmModifyDate,
			out clsBaseCaseHistoryInfo  p_objContent,
			out clsPictureBoxValue[] p_objPicValueArr,
			out DateTime p_dtmFirstPrintDate,
			out bool p_blnIsFirstPrint)
		{
			p_dtmFirstPrintDate=DateTime.MinValue ;
			p_blnIsFirstPrint=false;
			p_objContent=null;
			p_objPicValueArr=null;

			if(p_strInPatientID=="" || p_strInPatientID==null || p_strInPatientDate=="" || p_strInPatientDate==null )//|| p_strOpenDate=="" || p_strOpenDate==null )
				return (long)enmOperationResult.Parameter_Error ;

			
			clsBaseCaseHistorySevice m_objBaseServ = clsCaseHistoryFactory.s_objGetDomain(m_enmProcessType);
            long m_lngRes = 0;
            try
            {
                m_lngRes = m_objBaseServ.m_lngGetPrintInfo(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate,p_dtmModifyDate,out p_objContent,out p_objPicValueArr,out p_dtmFirstPrintDate,out p_blnIsFirstPrint);
            }
            finally
            {
                //m_objBaseServ.Dispose();
            }
            return m_lngRes;
		
		}

		// 更新数据库中的首次打印时间。
		public long m_lngUpdateFirstPrintDate(string p_strInPatientID,
			string p_strInPatientDate,
			string p_strOpenDate,
			DateTime p_dtmFirstPrintDate)
		{
//			return (long)enmOperationResult.DB_Succeed;
			clsBaseCaseHistorySevice m_objBaseServ = clsCaseHistoryFactory.s_objGetDomain(m_enmProcessType);
            long m_lngRes = 0;
            try
            {
                m_lngRes = m_objBaseServ.m_lngUpdateFirstPrintDate(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate,p_strOpenDate,p_dtmFirstPrintDate);
            }
            finally
            {
                //m_objBaseServ.Dispose();
            }
            return m_lngRes;
		}

		// 获取病人的已经被删除记录时间列表。
		public long m_lngGetDeleteRecordTimeList(string p_strInPatientID,
			string p_strInPatientDate,
			clsPatient p_strDeleteUserID,
			out string[] p_strCreateRecordTimeArr,
			out string[] p_strOpenRecordTimeArr)
		{
			p_strCreateRecordTimeArr=null;
			p_strOpenRecordTimeArr=null;
			return (long)enmOperationResult.DB_Succeed;
		}

		// 获取病人的已经被删除记录时间列表。
		public long m_lngGetDeleteRecordTimeListAll(string p_strInPatientID,
			string p_strInPatientDate,
			out string[] p_strCreateRecordTimeArr,
			out string[] p_strOpenRecordTimeArr)
		{
			p_strCreateRecordTimeArr=null;
			p_strOpenRecordTimeArr=null;
			return (long)enmOperationResult.DB_Succeed; 
		}

		// 获取指定已经被删除记录的内容。
		public long m_lngGetDeleteRecordContent(string p_strInPatientID,
			string p_strInPatientDate,
			string p_strOpenRecordTime,
			out clsInPatientCaseHistoryContent p_objRecordContent)
		{
			p_objRecordContent=null;
			iCareData.clsBaseCaseHistoryInfo objRecordContent=null;
			clsBaseCaseHistorySevice m_objBaseServ = clsCaseHistoryFactory.s_objGetDomain(m_enmProcessType);
            long m_lngRes = 0;
            try
            {
                m_lngRes = m_objBaseServ.m_lngGetDeleteRecordContent(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate,p_strOpenRecordTime,out objRecordContent);
			    p_objRecordContent= (clsInPatientCaseHistoryContent)objRecordContent;
            }
            finally
            {
                //m_objBaseServ.Dispose();
            }
            return m_lngRes;
		}

        public long m_lngGetEMRInPatientInfo(string p_strRegisterID,
            out string p_strEMRInPatientID,
            out DateTime p_dtmEMRInDate)
        {
            p_strEMRInPatientID = string.Empty;
            p_dtmEMRInDate = new DateTime(1900, 1, 1);

            clsPatientManagerService objServ =
                    (clsPatientManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPatientManagerService));

            long lngRes = objServ.m_lngGetEMRInPatientInfo(p_strRegisterID, out p_strEMRInPatientID, out p_dtmEMRInDate);
            objServ = null;
            return lngRes;
        }

	}

    public class clsInPatientCaseHistoryDomain
    { 
         /// <summary>
        /// 获取一次住院全部作废记录
        /// </summary>
        /// <param name="p_strInpatientId"></param>
        /// <param name="p_dtmInpatientDate"></param>
        /// <param name="p_objInactiveRecordInfoArr"></param>
        /// <returns></returns>
        public long m_lngGetAllInactiveInfo(string p_strInpatientId, DateTime p_dtmInpatientDate, out com.digitalwave.emr.AssistModuleVO.clsInactiveRecordInfo_VO[] p_objInactiveRecordInfoArr)
        {
            com.digitalwave.InPatientCaseHistoryServ.clsInPatientCaseHistoryServ objServ =
                    (com.digitalwave.InPatientCaseHistoryServ.clsInPatientCaseHistoryServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.InPatientCaseHistoryServ.clsInPatientCaseHistoryServ));

            long lngRes = objServ.m_lngGetAllInactiveInfo(p_strInpatientId, p_dtmInpatientDate, out p_objInactiveRecordInfoArr);
            objServ = null;
            return lngRes;
        }
    }
}
