using System;
using com.digitalwave.DiseaseTrackService;
using iCareData;
using System.Data ;
using com.digitalwave.emr.HospitalManagerService;
namespace iCare
{
	
	/// <summary>
	/// 病程记录的领域层。作为信息的转发控制器，用来连接界面和中间件。
	/// </summary>
	public class clsDiseaseTrackDomain:com.digitalwave.GUI_Base.clsDomainController_Base
	{

        //private clsDiseaseTrackService m_objTrackServ;
        enmDiseaseTrackType m_enmProcessType = new enmDiseaseTrackType();

		/// <summary>
		/// 构造函数。参数为指定的中间件。
		/// </summary>
		/// <param name="p_objProcessServ"></param>
        public clsDiseaseTrackDomain(enmDiseaseTrackType p_enmProcessType)
		{
            //m_objTrackServ =  p_objProcessServ;
            m_enmProcessType = p_enmProcessType;
		}

		
		/// <summary>
		/// 获取病人的该记录时间列表。
		/// </summary>
		/// <param name="p_strInPatientID">住院号</param>
		/// <param name="p_strInPatientDate">入院日期</param>
		/// <param name="p_strCreateDateArr">用户填写的创建时间数组</param>
		/// <param name="p_strOpenDateArr">系统生成的开始时间数组</param>
		/// <returns></returns>
		public long m_lngGetRecordTimeList(string p_strInPatientID,
			string p_strInPatientDate,
			out string[] p_strCreateDateArr,
			out string[] p_strOpenDateArr)
		{
			p_strCreateDateArr=null;
			p_strOpenDateArr=null;
			//参数判断
			if(p_strInPatientID==null||p_strInPatientID==""||p_strInPatientDate==null||p_strInPatientDate=="")
				return (long)enmOperationResult.Parameter_Error;
            clsDiseaseTrackService m_objTrackServ = clsDiseaseTrackDomainFactory.s_objGetDiseaseTrackDomain(m_enmProcessType);
			long lngRes = 0;
            try
            {
                lngRes = m_objTrackServ.m_lngGetRecordTimeList(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate,out p_strCreateDateArr,out p_strOpenDateArr);
            }
            finally
            {
                //m_objTrackServ.Dispose();
            }
            return lngRes;
		}

        /// <summary>
        /// 获取病人的该记录时间列表。
        /// </summary>
        /// <param name="p_strRegisterID">入院登记号</param>
        /// <param name="p_strCreateDateArr">用户填写的创建时间数组</param>
        /// <param name="p_strOpenDateArr">系统生成的开始时间数组</param>
        /// <returns></returns>
        public long m_lngGetRecordTimeList(string p_strRegisterID,
            out string[] p_strCreateDateArr,
            out string[] p_strOpenDateArr)
        {
            p_strCreateDateArr = null;
            p_strOpenDateArr = null;
            //参数判断
            if (string.IsNullOrEmpty(p_strRegisterID))
                return (long)enmOperationResult.Parameter_Error;
            clsDiseaseTrackService m_objTrackServ = clsDiseaseTrackDomainFactory.s_objGetDiseaseTrackDomain(m_enmProcessType);
            long lngRes = 0;
            try
            {
                lngRes = m_objTrackServ.m_lngGetRecordTimeList(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strRegisterID, out p_strCreateDateArr, out p_strOpenDateArr);
            }
            finally
            {
                //m_objTrackServ.Dispose();
            }
            return lngRes;
        }

		/// <summary>
		/// 获取指定记录内容。
		/// </summary>
		/// <param name="p_strInPatientID">住院号</param>
		/// <param name="p_strInPatientDate">入院日期</param>
		/// <param name="p_strOpenDate">记录时间</param>
		/// <param name="p_objRecordContent">返回的记录内容</param>
		/// <returns></returns>
		public long m_lngGetRecordContent(string p_strInPatientID,
			string p_strInPatientDate,
			string p_strOpenDate,
			out clsTrackRecordContent p_objRecordContent)
		{
			p_objRecordContent=null;
			//参数判断
			if(p_strInPatientID==null||p_strInPatientID==""||p_strInPatientDate==null||p_strInPatientDate==""||p_strOpenDate==null||p_strOpenDate=="")
				return (long)enmOperationResult.Parameter_Error;
		
			clsDiseaseTrackService m_objTrackServ = clsDiseaseTrackDomainFactory.s_objGetDiseaseTrackDomain(m_enmProcessType);
			long lngRes = 0;
            try
            {
                lngRes =  m_objTrackServ.m_lngGetRecordContent(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate,p_strOpenDate,out p_objRecordContent);
            }
            finally
            {
                //m_objTrackServ.Dispose();
            }
            return lngRes;
		}
        /// <summary>
        /// 获取指定记录内容。
        /// </summary>
        /// <param name="p_strRegisterID"></param>
        /// <param name="p_strCreatedDateDate"></param>
        /// <param name="p_objRecordContent"></param>
        /// <returns></returns>
        public long m_lngGetRecordContent(string p_strRegisterID,
            string p_strCreatedDateDate,
            out clsTrackRecordContent p_objRecordContent)
        {
            p_objRecordContent = null;
            //参数判断
            if (string.IsNullOrEmpty(p_strRegisterID) || string.IsNullOrEmpty(p_strCreatedDateDate))
                return (long)enmOperationResult.Parameter_Error;

            clsDiseaseTrackService m_objTrackServ = clsDiseaseTrackDomainFactory.s_objGetDiseaseTrackDomain(m_enmProcessType);
            long lngRes = 0;
            try
            {
                lngRes = m_objTrackServ.m_lngGetRecordContent(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strRegisterID, p_strCreatedDateDate, out p_objRecordContent);
            }
            finally
            {
                //m_objTrackServ.Dispose();
            }
            return lngRes;
        }
        #region 不用
        /// <summary>
        /// 获取指定记录内容(茶山有摄入排出的护理表单用)。
        /// </summary>
        /// <param name="p_strInPatientID">住院号</param>
        /// <param name="p_strInPatientDate">入院日期</param>
        /// <param name="p_strOpenDate">记录时间</param>
        /// <param name="p_strFormID">表单ID</param>
        /// <param name="p_objRecordContent">返回的记录内容</param>
        /// <returns></returns>
        //public long m_lngGetRecordContent(string p_strInPatientID,
        //    string p_strInPatientDate,
        //    string p_strOpenDate,string p_strFormID,
        //    out clsTrackRecordContent p_objRecordContent)
        //{
        //    p_objRecordContent = null;
        //    //参数判断
        //    if (p_strInPatientID == null || p_strInPatientID == "" || p_strInPatientDate == null || p_strInPatientDate == "" || p_strOpenDate == null || p_strOpenDate == "")
        //        return (long)enmOperationResult.Parameter_Error;

        //    clsDiseaseTrackService m_objTrackServ = clsDiseaseTrackDomainFactory.s_objGetDiseaseTrackDomain(m_enmProcessType);
        //    long lngRes = 0;
        //    try
        //    {
        //        lngRes = m_objTrackServ.m_lngGetRecordContent(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_strOpenDate,p_strFormID, out p_objRecordContent);
        //    }
        //    finally
        //    {
        //        //m_objTrackServ.Dispose();
        //    }
        //    return lngRes;
        //}
        #endregion
        /// <summary>
		/// 添加新记录。
		/// </summary>
		/// <param name="p_objRecordContent">记录内容</param>
		/// <param name="p_objModifyInfo">若存在相同的创建时间,返回该记录的操作信息,否则为空</param>
		/// <returns></returns>
		public long m_lngAddNewRecord(clsTrackRecordContent p_objRecordContent,out clsPreModifyInfo p_objModifyInfo)
		{
			p_objModifyInfo=null;
			//参数判断
			if(p_objRecordContent==null)
				return (long)enmOperationResult.Parameter_Error;
		
			clsDiseaseTrackService m_objTrackServ = clsDiseaseTrackDomainFactory.s_objGetDiseaseTrackDomain(m_enmProcessType);
			long lngRes = 0;
            try
            {
                lngRes = m_objTrackServ.m_lngAddNewRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_objRecordContent,out p_objModifyInfo);
            }
            finally
            {
                //m_objTrackServ.Dispose();
            }
            return lngRes;
		}

	 
		/// <summary>
		/// 获取指定科室（病区）下的在院病人
		/// 用于一般护理整体录入
		/// </summary>
		/// <param name="p_strID">科室ID（病区ID）</param>
		/// <param name="p_objdtPatient"></param>
		/// <returns></returns>
		public long m_lngGetBedPatientInfo(string p_strID,out DataTable p_objdtPatient)
		{
			long lngRes=0;
            p_objdtPatient = null;

            clsHospitalManagerService m_objHospitalManager =
                (clsHospitalManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHospitalManagerService));

			try
			{
 				//参数判断
				//long lngRes=0;
				if(p_strID==null)
					return (long)enmOperationResult.Parameter_Error;
				lngRes= m_objHospitalManager.m_lngGetPatientInfo(objPrincipal,p_strID,true,out p_objdtPatient);

			}
			catch (Exception exp)
			{
				string strError=exp.Message;
//				com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
//				bool blnRes =objLogger.objLogger(exp);
			}
            finally
            {
                //m_objHospitalManager.Dispose();
            }
			return lngRes;
 			
		}


		/// <summary>
		/// 修改记录。
		/// </summary>
		/// <param name="p_objOldRecordContent">修改之前的原记录内容</param>
		/// <param name="p_objNewRecordContent">修改后的记录内容</param>
		/// <param name="p_objModifyInfo">若当前记录不是最新的记录,返回该最新记录的操作信息,否则为空</param>
		/// <returns></returns>
		public long m_lngModifyRecord(clsTrackRecordContent p_objOldRecordContent,
			clsTrackRecordContent p_objNewRecordContent,
			out clsPreModifyInfo p_objModifyInfo)
		{
			p_objModifyInfo=null;
			//参数判断
			if(p_objOldRecordContent==null||p_objNewRecordContent==null)
				return (long)enmOperationResult.Parameter_Error;
		
			clsDiseaseTrackService m_objTrackServ = clsDiseaseTrackDomainFactory.s_objGetDiseaseTrackDomain(m_enmProcessType);
			long lngRes = 0;
            try
            {
                lngRes = m_objTrackServ.m_lngModifyRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_objOldRecordContent,p_objNewRecordContent,out p_objModifyInfo);
            }
            finally
            {
                //m_objTrackServ.Dispose();
            }
            return lngRes;
		}

		/// <summary>
		/// 删除记录。
		/// </summary>
		/// <param name="p_objRecordContent">当前要删除的记录</param>
		/// <param name="p_objModifyInfo">若当前要删除的记录不是最新的记录,返回该最新记录的操作信息,否则为空</param>
		/// <returns></returns>
		public long m_lngDeleteRecord(clsTrackRecordContent p_objRecordContent,			
			out clsPreModifyInfo p_objModifyInfo)
		{
			p_objModifyInfo=null;
			//参数判断
			if(p_objRecordContent==null)
				return (long)enmOperationResult.Parameter_Error;
		
			clsDiseaseTrackService m_objTrackServ = clsDiseaseTrackDomainFactory.s_objGetDiseaseTrackDomain(m_enmProcessType);
			long lngRes = 0;
            try
            {
                lngRes = m_objTrackServ.m_lngDeleteRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_objRecordContent,out p_objModifyInfo);
            }
            finally
            {
                //m_objTrackServ.Dispose();
            }
            return lngRes;
		}

		/// <summary>
		/// 作废重做记录。
		/// </summary>
		/// <param name="p_objDelRecord">要作废的记录</param>
		/// <param name="p_objAddNewRecord">新的记录</param>
		/// <param name="p_objPreModifyInfo">若当前要作废的记录不是最新的记录,返回该最新记录的操作信息,否则为空</param>
		/// <returns></returns>
		public long m_lngReAddNewRecord(clsTrackRecordContent p_objDelRecord,
			clsTrackRecordContent p_objAddNewRecord,			
			out clsPreModifyInfo p_objModifyInfo)
		{
			p_objModifyInfo=null;
			//参数判断
			if(p_objDelRecord==null||p_objAddNewRecord==null)
				return (long)enmOperationResult.Parameter_Error;
		
			clsDiseaseTrackService m_objTrackServ = clsDiseaseTrackDomainFactory.s_objGetDiseaseTrackDomain(m_enmProcessType);
			long lngRes = 0;
            try
            {
                lngRes = m_objTrackServ.m_lngReAddNewRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_objDelRecord,p_objAddNewRecord,out p_objModifyInfo);
            }
            finally
            {
                //m_objTrackServ.Dispose();
            }
            return lngRes;
		}

		// 获取打印信息。
		// 1.获取打印内容：如果输入参数p_dtmModifyDate不是最新的ModifyDate，输出变量 p_objContent
		//   会存放最新的内容；否则，输出变量为null。
		// 2.获取打印时间：输出变量 p_dtmFirstPrintDate 存放首次打印时间。p_blnIsFirstPrint标记
		//   是否首次打印，如果是为true，客户端在打印后需要保存p_dtmFirstPrintDate到数据库。
		public long m_lngGetPrintInfo(string p_strInPatientID,
			string p_strInPatientDate,
			string p_strOpenDate,
			DateTime p_dtmModifyDate,
			out clsTrackRecordContent p_objContent,
			out DateTime p_dtmFirstPrintDate,
			out bool p_blnIsFirstPrint)
		{
			clsDiseaseTrackService m_objTrackServ = clsDiseaseTrackDomainFactory.s_objGetDiseaseTrackDomain(m_enmProcessType);
			long lngRes = 0;
            try
            {
                lngRes = m_objTrackServ.m_lngGetPrintInfo(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate,p_strOpenDate,
				p_dtmModifyDate,out p_objContent,out p_dtmFirstPrintDate,out p_blnIsFirstPrint);
            }
            finally
            {
                //m_objTrackServ.Dispose();
            }
            return lngRes;
		}

		// 更新数据库中的首次打印时间。
		public long m_lngUpdateFirstPrintDate(string p_strInPatientID,
			string p_strInPatientDate,
			string p_strOpenDate,
			DateTime p_dtmFirstPrintDate)
		{
			clsDiseaseTrackService m_objTrackServ = clsDiseaseTrackDomainFactory.s_objGetDiseaseTrackDomain(m_enmProcessType);
			long lngRes = 0;
            try
            {
                lngRes = m_objTrackServ.m_lngUpdateFirstPrintDate(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate,p_strOpenDate,p_dtmFirstPrintDate);
            }
            finally
            {
                //m_objTrackServ.Dispose();
            }
            return lngRes;
		}

		// 获取病人的已经被删除记录时间列表。
		public long m_lngGetDeleteRecordTimeList(string p_strInPatientID,
			string p_strInPatientDate,
			string p_strDeleteUserID,
			out string[] p_strCreateRecordTimeArr,
			out string[] p_strOpenRecordTimeArr)
		{
			clsDiseaseTrackService m_objTrackServ = clsDiseaseTrackDomainFactory.s_objGetDiseaseTrackDomain(m_enmProcessType);
			long lngRes = 0;
            try
            {
                lngRes = m_objTrackServ.m_lngGetDeleteRecordTimeList(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate,p_strDeleteUserID,
				out p_strCreateRecordTimeArr,out p_strOpenRecordTimeArr);
            }
            finally
            {
                //m_objTrackServ.Dispose();
            }
            return lngRes;
		}

		// 获取病人的已经被删除记录时间列表。
		public long m_lngGetDeleteRecordTimeListAll(string p_strInPatientID,
			string p_strInPatientDate,
			out string[] p_strCreateRecordTimeArr,
			out string[] p_strOpenRecordTimeArr)
		{
			clsDiseaseTrackService m_objTrackServ = clsDiseaseTrackDomainFactory.s_objGetDiseaseTrackDomain(m_enmProcessType);
			long lngRes = 0;
            try
            {
                lngRes = m_objTrackServ.m_lngGetDeleteRecordTimeListAll(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate,
				out p_strCreateRecordTimeArr,out p_strOpenRecordTimeArr);
            }
            finally
            {
                //m_objTrackServ.Dispose();
            }
            return lngRes;
		}

		// 获取指定已经被删除记录的内容。
		public long m_lngGetDeleteRecordContent(string p_strInPatientID,
			string p_strInPatientDate,
			string p_strOpenRecordTime,
			out clsTrackRecordContent p_objRecordContent)
		{
			p_objRecordContent=null;
			//参数判断
			if(p_strInPatientID==null||p_strInPatientID==""||p_strInPatientDate==null||p_strInPatientDate==""||p_strOpenRecordTime==null||p_strOpenRecordTime=="")
				return (long)enmOperationResult.Parameter_Error;

			clsDiseaseTrackService m_objTrackServ = clsDiseaseTrackDomainFactory.s_objGetDiseaseTrackDomain(m_enmProcessType);
			long lngRes = 0;
            try
            {
                lngRes = m_objTrackServ.m_lngGetDeleteRecordContent(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate,p_strOpenRecordTime,out p_objRecordContent);
            }
            finally
            {
                //m_objTrackServ.Dispose();
            }
            return lngRes;
		}

	}// END CLASS DEFINITION clsDiseaseTrackDomain

}
