using System;
using iCareData;
using com.digitalwave.DoctorRecordService;
using com.digitalwave.Utility.Controls;

namespace iCare
{
	/// <summary>
	/// 专科病历领域层
	/// </summary>
	public class clsInpatMedRecDomain
	{
		// 构造函数。参数为指定的中间件。
		public clsInpatMedRecDomain()
		{

		}

		/// <summary>
		/// 添加新记录
		/// </summary>
		public long m_lngAddNewRecord(clsInpatMedRecContent p_objContent)
		{
            clsInpatMedRecServ m_objServ =
                (clsInpatMedRecServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInpatMedRecServ));

			long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngAddNewRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_objContent);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}

		/// <summary>
		/// 获取病人该特殊记录的时间列表
		/// </summary>
		public long m_lngGetRecordTimeList(string p_strTypeID,string p_strInPatientID,
			out string[] p_strInPatientDateArr,
			out string[] p_strCreateRecordTimeArr,
			out string[] p_strOpenRecordTimeArr)
		{
			p_strInPatientDateArr = null;
			p_strCreateRecordTimeArr=null;
			p_strOpenRecordTimeArr=null;

            clsInpatMedRecServ m_objServ =
                (clsInpatMedRecServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInpatMedRecServ));

			long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngGetRecordTimeList(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strTypeID,p_strInPatientID,out p_strInPatientDateArr,out p_strCreateRecordTimeArr,out p_strOpenRecordTimeArr);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}

		/// <summary>
		/// 获取指定记录内容
		/// </summary>
		/// <param name="p_strInPatientID"></param>
		/// <param name="p_strInPatientDate"></param>
		/// <param name="p_objRecordContent"></param>
		/// <param name="p_objPicValueArr"></param>
		/// <returns></returns>
		public long m_lngGetRecordContent(string p_strTypeID,string p_strInPatientID,string p_strInPatientDate,			
			out clsInpatMedRecContent p_objContent)
		{
			//参数判断
			p_objContent=null;

            clsInpatMedRecServ m_objServ =
                (clsInpatMedRecServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInpatMedRecServ));

			long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngGetRecordContent(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strTypeID,p_strInPatientID,p_strInPatientDate,out p_objContent);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}

        /// <summary>
        /// 获取指定记录内容
        /// </summary>
        /// <param name="p_strInPatientID"></param>
        /// <param name="p_strInPatientDate"></param>
        /// <param name="p_objRecordContent"></param>
        /// <param name="p_objPicValueArr"></param>
        /// <returns></returns>
        public long m_lngGetRecordContent(string p_strTypeID, string p_strInPatientID, string p_strInPatientDate,DateTime p_dtmOpenDate,
            out clsInpatMedRecContent p_objContent)
        {
            //参数判断
            p_objContent = null;

            clsInpatMedRecServ m_objServ =
                (clsInpatMedRecServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInpatMedRecServ));

            long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngGetRecordContent(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strTypeID, p_strInPatientID, p_strInPatientDate, p_dtmOpenDate,out p_objContent);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
        }


		/// <summary>
		/// 修改记录
		/// </summary>
		/// <param name="p_objContent"></param>
		/// <returns></returns>
		public long m_lngModifyRecord(clsInpatMedRecContent p_objContent)
		{
            clsInpatMedRecServ m_objServ =
                (clsInpatMedRecServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInpatMedRecServ));

			long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngModifyRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_objContent);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}

		/// <summary>
		/// 获取打印内容
		/// </summary>
		/// <param name="p_strTypeID"></param>
		/// <param name="p_objPrintContent"></param>
		/// <returns></returns>
		public long m_lngGetPrintInfo(string p_strTypeID,ref clsPrintInfo_InpatMedRec p_objPrintContent)
		{
			//参数判断
			p_objPrintContent.m_objContent=null;

            clsInpatMedRecServ m_objServ =
                (clsInpatMedRecServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInpatMedRecServ));

			long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngGetPrintInfo(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strTypeID,ref p_objPrintContent);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}

		/// <summary>
		/// 更新数据库中的首次打印时间。
		/// </summary>
		/// <param name="p_strInPatientID"></param>
		/// <param name="p_strInPatientDate"></param>
		/// <param name="p_strOpenDate"></param>
		/// <param name="p_dtmFirstPrintDate"></param>
		/// <returns></returns>
		public long m_lngUpdateFirstPrintDate(string p_strTypeID,clsPrintInfo_InpatMedRec p_objPrintContent)
		{
            clsInpatMedRecServ m_objServ =
                (clsInpatMedRecServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInpatMedRecServ));

			long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngUpdateFirstPrintDate(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strTypeID, p_objPrintContent);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}
		/// <summary>
		/// 删除记录
		/// </summary>
		/// <param name="p_objContent"></param>
		/// <returns></returns>
		public long m_lngDeleteRecord(clsInpatMedRecContent p_objContent)
		{
            clsInpatMedRecServ m_objServ =
                (clsInpatMedRecServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInpatMedRecServ));

			long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngDeleteRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_objContent);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}

		/// <summary>
		/// 获取控件描述
		/// </summary>
		/// <param name="p_strTypeID"></param>
		/// <param name="p_objContentArr"></param>
		/// <returns></returns>
		public long m_lngGetType_ItemRecord(string p_strTypeID,out clsInpatMedRec_Type_Item[] p_objContentArr)
		{
			p_objContentArr = null;

            clsInpatMedRecServ m_objServ =
                (clsInpatMedRecServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInpatMedRecServ));

			long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngGetType_ItemRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strTypeID,out p_objContentArr);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}

		/// <summary>
		/// 提取一个项目内容
		/// </summary>
		/// <param name="p_strTypeID"></param>
		/// <param name="p_strInPatientID"></param>
		/// <param name="p_strInPatientDate"></param>
		/// <param name="p_strOpenDate"></param>
		/// <param name="p_strItemID"></param>
		/// <param name="p_objContent"></param>
		/// <returns></returns>
		public long m_lngGetOneItemValue(string p_strTypeID,string p_strInPatientID,string p_strInPatientDate,string p_strItemID, out clsInpatMedRec_Item p_objContent)
		{
			p_objContent =null;

            clsInpatMedRecServ m_objServ =
                (clsInpatMedRecServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInpatMedRecServ));

			long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngGetOneItemValue(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strTypeID,p_strInPatientID,p_strInPatientDate,p_strItemID, out p_objContent);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}

		/// <summary>
		/// 获取病人所有可用主表信息
		/// </summary>
		/// <param name="p_strInPatientID"></param>
		/// <param name="p_strInPatientDate"></param>
		/// <param name="p_objContentArr"></param>
		/// <returns></returns>
		public long m_lngGetPatientAllMainRecord(string p_strInPatientID,string p_strInPatientDate, out clsInpatMedRecContent[] p_objContentArr)
		{
			p_objContentArr = null;

            clsInpatMedRecServ m_objServ =
                (clsInpatMedRecServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInpatMedRecServ));

			long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngGetPatientAllMainRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate, out p_objContentArr);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}

		/// <summary>
		/// 获取一个专科病历的项目信息
		/// </summary>
		/// <param name="p_strTypeID"></param>
		/// <param name="p_strInPatientID"></param>
		/// <param name="p_strInPatientDate"></param>
		/// <param name="p_dtmOpenDate"></param>
		/// <param name="p_objItemContentArr"></param>
		/// <returns></returns>
		public long m_lngGetItemRecord(string p_strTypeID,string p_strInPatientID,string p_strInPatientDate,DateTime p_dtmOpenDate,out clsInpatMedRec_Item[] p_objItemContentArr)
		{
			p_objItemContentArr = null;

            clsInpatMedRecServ m_objServ =
                (clsInpatMedRecServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInpatMedRecServ));

			long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngGetItemRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strTypeID,p_strInPatientID,p_strInPatientDate,p_dtmOpenDate,out p_objItemContentArr);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}

		/// <summary>
		/// 获取专科病历窗体名称
		/// </summary>
		/// <param name="p_objContent"></param>
		/// <returns></returns>
		public long m_lngGetTypeName(ref clsInpatMedRec_Type p_objContent)
		{
            clsInpatMedRecServ m_objServ =
                (clsInpatMedRecServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInpatMedRecServ));

			long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngGetTypeName(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,ref p_objContent);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}

		/// <summary>
		/// 获取删除记录
		/// </summary>
		/// <param name="p_strTypeID"></param>
		/// <param name="p_strInPatientID"></param>
		/// <param name="p_strOpenDate"></param>
		/// <param name="p_objContent"></param>
		/// <returns></returns>
		public long  m_lngGetDeactiveRecInfo(string p_strTypeID,string p_strInPatientID,string p_strOpenDate, out clsInpatMedRecContent p_objContent)
		{
			p_objContent = null;

            clsInpatMedRecServ m_objServ =
                (clsInpatMedRecServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInpatMedRecServ));

			long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngGetDeactiveRecInfo(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strTypeID,  p_strInPatientID,  p_strOpenDate, out p_objContent);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}

		/// <summary>
		/// 获取全部专科病历
		/// </summary>
		/// <param name="p_objTypeArr"></param>
		/// <returns></returns>
		public long m_lngGetAllFormID(out clsInpatMedRec_Type[] p_objTypeArr)
		{
			p_objTypeArr = null;

            clsInpatMedRecServ m_objServ =
                (clsInpatMedRecServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInpatMedRecServ));

			long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngGetAllFormID(out p_objTypeArr);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}
		
		/// <summary>
		/// 获取相应科室可使用的电子病历
		/// </summary>
		/// <param name="p_strDeptIDArr"></param>
		/// <param name="p_objTypeArr"></param>
		/// <returns></returns>
		public long m_lngGetFormByChargeDept(string[] p_strDeptIDArr,out clsInpatMedRec_Type[] p_objTypeArr)
		{
            clsInpatMedRecServ m_objServ =
                (clsInpatMedRecServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInpatMedRecServ));

			long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngGetFormByChargeDept(p_strDeptIDArr,out p_objTypeArr);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
        }
        /// <summary>
        /// 获取一次住院全部作废记录
        /// </summary>
        /// <param name="p_strType"></param>
        /// <param name="p_strInpatientId"></param>
        /// <param name="p_dtmInpatientDate"></param>
        /// <param name="p_objInactiveRecordInfoArr"></param>
        /// <returns></returns>
        public long m_lngGetAllInactiveInfo(string p_strType, string p_strInpatientId, DateTime p_dtmInpatientDate, out com.digitalwave.emr.AssistModuleVO.clsInactiveRecordInfo_VO[] p_objInactiveRecordInfoArr)
        {
            clsInpatMedRecServ objServ =
                (clsInpatMedRecServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInpatMedRecServ));

            long lngRes = objServ.m_lngGetAllInactiveInfo(p_strType,p_strInpatientId, p_dtmInpatientDate, out p_objInactiveRecordInfoArr);
            objServ = null;
            return lngRes;
        }

        /// <summary>
        /// 获取病人一次入院的记录时间列表。
        /// </summary>
        /// <param name="p_strInPatientID">住院号</param>
        /// <param name="p_strInPatientDate">入院日期</param>
        /// <param name="p_strCreateDateArr">用户填写的创建时间数组</param>
        /// <param name="p_strOpenDateArr">系统生成的开始时间数组</param>
        /// <returns></returns>
        public long m_lngGetRecordTimeList(string p_strTypeID,string p_strInPatientID,
            string p_strInPatientDate,
            out string[] p_strCreateDateArr,
            out string[] p_strOpenDateArr)
        {
            p_strCreateDateArr = null;
            p_strOpenDateArr = null;
            //参数判断
            if (p_strTypeID == null || p_strTypeID == "" || p_strInPatientID == null || p_strInPatientID == "" || p_strInPatientDate == null || p_strInPatientDate == "")
                return (long)enmOperationResult.Parameter_Error;
            clsInpatMedRecServ m_objServ =
                (clsInpatMedRecServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInpatMedRecServ));

            long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngGetRecordTimeList(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strTypeID, p_strInPatientID, p_strInPatientDate, out p_strCreateDateArr, out p_strOpenDateArr);
            }
            finally
            {
                //m_objTrackServ.Dispose();
            }
            return lngRes;
        }
	}
}
