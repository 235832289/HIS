using System;
using com.digitalwave.DiseaseTrackService;
using iCareData;
using com.digitalwave.iCare.middletier.BIHOrderServer;

namespace iCare
{

    /// <summary>
    ///  操作多个记录类型的领域层。作为信息的转发控制器，用来连接界面和中间件。
    /// </summary>
    public class clsBeforeOperationSummaryDomain_xj
    {
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
            clsBeforeOperationSummaryService_xj m_objServ =
                (clsBeforeOperationSummaryService_xj)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsBeforeOperationSummaryService_xj));

            long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngGetRecordTimeList(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, out p_strCreateDateArr, out p_strOpenDateArr);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
        }

        /// <summary>
        /// 获取指定记录的内容。
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
            clsBeforeOperationSummaryService_xj m_objServ =
                (clsBeforeOperationSummaryService_xj)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsBeforeOperationSummaryService_xj));

            long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngGetRecordContent(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_strOpenDate, out p_objRecordContent);
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
        /// <param name="p_strInPatientID">住院号</param>
        /// <param name="p_strInPatientDate">入院日期</param>
        /// <param name="p_strOpenDate">记录时间</param>
        /// <param name="p_dtmFirstPrintDate">首次打印时间</param>
        /// <returns></returns>
        public long m_lngUpdateFirstPrintDate(string p_strInPatientID,
            string p_strInPatientDate,
            string p_strOpenDate,
            DateTime p_dtmFirstPrintDate)
        {
            clsBeforeOperationSummaryService_xj m_objServ =
                (clsBeforeOperationSummaryService_xj)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsBeforeOperationSummaryService_xj));

            long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngUpdateFirstPrintDate(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_strOpenDate, p_dtmFirstPrintDate);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
        }

        /// <summary>
        /// 更新出院时间
        /// </summary>
        /// <param name="p_strRegisterID">入院登记号</param>
        /// <param name="p_dtmOutDate">出院时间</param>
        /// <returns></returns>
        public long m_lngUpdateOutDate(string p_strRegisterID, DateTime p_dtmOutDate)
        {
            clsBeforeOperationSummaryService_xj m_objServ =
                (clsBeforeOperationSummaryService_xj)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsBeforeOperationSummaryService_xj));

            long lngRes = 0;

            lngRes = m_objServ.m_lngUpdateOutDate(p_strRegisterID, p_dtmOutDate);
            m_objServ = null;
            return lngRes;
        }

        /// <summary>
        /// 获取病人出院医嘱
        /// </summary>
        /// <param name="p_strRegisterID">入院登记号</param>
        /// <param name="p_dtbOrder">出院医嘱</param>
        /// <returns></returns>
        public long m_lngGetOutOrderByRegID(string p_strRegisterID, out System.Data.DataTable p_dtbOrder)
        {
            p_dtbOrder = null;
            if (com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_StrCurrentHospitalNO == "450101001") return -2;//广西区医院暂不用取医嘱
            clsBIHOrderInterface m_objServ =
                (clsBIHOrderInterface)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsBIHOrderInterface));

            long lngRes = 0;

            lngRes = m_objServ.m_lngGetOutOrderByRegID(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strRegisterID, out p_dtbOrder);
            m_objServ = null;
            return lngRes;
        }
        /// <summary>
        /// 获取全部作废记录clsConsultationService
        /// </summary>
        /// <param name="p_strInpatientId"></param>
        /// <param name="p_dtmInpatientDate"></param>
        /// <param name="p_objInactiveRecordInfoArr"></param>
        /// <returns></returns>
        public long m_lngGetAllInactiveInfo(string p_strInpatientId, DateTime p_dtmInpatientDate, out com.digitalwave.emr.AssistModuleVO.clsInactiveRecordInfo_VO[] p_objInactiveRecordInfoArr)
        {
            com.digitalwave.DiseaseTrackService.clsBeforeOperationSummaryService_xj objServ =
                    (com.digitalwave.DiseaseTrackService.clsBeforeOperationSummaryService_xj)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.DiseaseTrackService.clsBeforeOperationSummaryService_xj));

            long lngRes = objServ.m_lngGetAllInactiveInfo(p_strInpatientId, p_dtmInpatientDate, out p_objInactiveRecordInfoArr);
            objServ = null;
            return lngRes;
        }
    }
}
