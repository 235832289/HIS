using System;
using iCareData;
using com.digitalwave.DiseaseTrackService;

namespace iCare
{
	/// <summary>
	/// Summary description for clsConsultationSearchDomain.
	/// </summary>
	public class clsConsultationSearchDomain
	{
        //private clsConsultationService m_objServ;

		public clsConsultationSearchDomain()
		{
            //m_objServ = new clsConsultationService();
		}

		/// <summary>
		/// 获取还没会诊的记录内容
		/// </summary>
		/// <param name="p_strDeptID">部门ID</param>
		/// <param name="p_objHRPServ"></param>
		/// <param name="p_objRecordContent">会诊类</param>
		/// <returns></returns>
        //public long m_lngGetRecordContentWithServ(string p_strDeptID,
        //    out clsConsultationRecordContent[] p_objRecordContentArr)
        //{
        //    p_objRecordContentArr=null;
			
        //    //检查参数
        //    if(p_strDeptID==null)
        //        return (long)enmOperationResult.Parameter_Error;

        //    clsConsultationService m_objServ =
        //        (clsConsultationService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsConsultationService));

        //    long lngRes = 0;
        //    try
        //    {
        //        lngRes = m_objServ.m_lngGetUnSignContent(p_strDeptID,out p_objRecordContentArr);
        //    }
        //    finally
        //    {
        //        //m_objServ.Dispose();
        //    }
        //    return lngRes;
        //}

        /// <summary>
        /// 获取还没会诊的记录内容
        /// </summary>
        /// <param name="p_strDeptIDArr">部门ID</param>
        /// <param name="p_objHRPServ"></param>
        /// <param name="p_objRecordContent">会诊类</param>
        /// <returns></returns>
        public long m_lngGetRecordContentWithServ(string[] p_strDeptIDArr,
            out clsConsultationRecordContent[] p_objRecordContentArr)
        {
            p_objRecordContentArr = null;

            //检查参数
            if (p_strDeptIDArr == null)
                return (long)enmOperationResult.Parameter_Error;

            clsConsultationService m_objServ =
                (clsConsultationService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsConsultationService));

			long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngGetUnSignContent(p_strDeptIDArr, out p_objRecordContentArr);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
        }

        public long m_lngModifyRecord2DB(clsConsultationRecordContent p_objRecordContent)
        {
            clsConsultationService m_objServ =
                (clsConsultationService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsConsultationService));

			long lngRes = 0;
            try
            {
                lngRes =  m_objServ.m_lngUpdateRecord(p_objRecordContent);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
        }
	}
}
