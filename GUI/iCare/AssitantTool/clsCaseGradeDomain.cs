using System;
using iCareData;
using System.Collections;
using System.Data;

namespace iCare
{
	/// <summary>
	/// clsCaseGradeDomain 的摘要说明。
	/// </summary>
	public class clsCaseGradeDomain
	{
        //private com.digitalwave.CaseGradeServ.clsCaseGradeServ m_objServ;
		public clsCaseGradeDomain()
		{
            //m_objServ = new com.digitalwave.CaseGradeServ.clsCaseGradeServ();
		}

		/// <summary>
		/// 获取病人曾经在院时间
		/// </summary>
		/// <param name="p_strInPatientID"></param>
		/// <param name="p_strInPatientDateArr"></param>
		/// <returns></returns>
        public long m_lngGetAllInPatientTime(string p_strInPatientID,
            out string[] p_strEMRInPatientDateArr,
            out string[] p_strHISInPatientDateArr,
            out string[] p_strHISInPatientIDArr)
		{
            com.digitalwave.CaseGradeServ.clsCaseGradeServ m_objServ =
                (com.digitalwave.CaseGradeServ.clsCaseGradeServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.CaseGradeServ.clsCaseGradeServ));

            p_strEMRInPatientDateArr = null;
            p_strHISInPatientDateArr = null;
            p_strHISInPatientIDArr = null;
            long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngGetAllInPatientTime(p_strInPatientID, out p_strEMRInPatientDateArr, out p_strHISInPatientDateArr, out p_strHISInPatientIDArr);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}
		/// <summary>
		/// 获取评分结果
		/// </summary>
		/// <param name="p_objContent"></param>
		/// <returns></returns>
		public long m_lngGetGradeInfo(ref clsCaseGradeValue p_objContent)
		{
            com.digitalwave.CaseGradeServ.clsCaseGradeServ m_objServ =
                (com.digitalwave.CaseGradeServ.clsCaseGradeServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.CaseGradeServ.clsCaseGradeServ));

            long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngGetGradeInfo(ref p_objContent);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}
		/// <summary>
		/// 获取科室下所有评过分的住院病历
		/// </summary>
		/// <param name="p_strDeptID"></param>
		/// <param name="p_objContentArr"></param>
		/// <returns></returns>
		public long m_lngGetGradeInfoByDept(string p_strDeptID,DateTime p_dtpFirstDate,DateTime p_dtpLastDate ,out clsCaseGradeValue[] p_objContentArr)
		{
			p_objContentArr = null;
            com.digitalwave.CaseGradeServ.clsCaseGradeServ m_objServ =
                (com.digitalwave.CaseGradeServ.clsCaseGradeServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.CaseGradeServ.clsCaseGradeServ));

            long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngGetGradeInfoByDept(p_strDeptID,p_dtpFirstDate,p_dtpLastDate,out p_objContentArr);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}
		/// <summary>
		/// 获取病区下所有评过分的住院病历
		/// </summary>
		/// <param name="p_strDeptID"></param>
		/// <param name="p_objContentArr"></param>
		/// <returns></returns>
		public long m_lngGetGradeInfoByArea(string p_strAreaID,DateTime p_dtpFirstDate,DateTime p_dtpLastDate,out clsCaseGradeValue[] p_objContentArr)
		{
			p_objContentArr = null;

            com.digitalwave.CaseGradeServ.clsCaseGradeServ m_objServ =
                (com.digitalwave.CaseGradeServ.clsCaseGradeServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.CaseGradeServ.clsCaseGradeServ));

            long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngGetGradeInfoByArea(p_strAreaID,p_dtpFirstDate,p_dtpLastDate,out p_objContentArr);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}
		/// <summary>
		/// 保存评分值
		/// </summary>
		/// <param name="p_objContent"></param>
		/// <returns></returns>
		public long m_lngSaveGradeInfo(clsCaseGradeValue p_objContent)
		{
            com.digitalwave.CaseGradeServ.clsCaseGradeServ m_objServ =
                (com.digitalwave.CaseGradeServ.clsCaseGradeServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.CaseGradeServ.clsCaseGradeServ));

            long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngSaveGradeInfo(p_objContent);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}
		/// <summary>
		/// 修改评分值
		/// </summary>
		/// <param name="p_objContent"></param>
		/// <returns></returns>
		public long m_lngModifyGradeInfo(clsCaseGradeValue p_objContent)
		{
            com.digitalwave.CaseGradeServ.clsCaseGradeServ m_objServ =
                (com.digitalwave.CaseGradeServ.clsCaseGradeServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.CaseGradeServ.clsCaseGradeServ));

            long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngModifyGradeInfo(p_objContent);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}
		/// <summary>
		/// 删除评分值
		/// </summary>
		/// <param name="p_strInPatientID"></param>
		/// <param name="p_strInPatientDate"></param>
		/// <returns></returns>
		public long m_lngDeleteGradeInfo(string p_strInPatientID,string p_strInPatientDate)
		{
            com.digitalwave.CaseGradeServ.clsCaseGradeServ m_objServ =
                (com.digitalwave.CaseGradeServ.clsCaseGradeServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.CaseGradeServ.clsCaseGradeServ));

            long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngDeleteGradeInfo(p_strInPatientID,p_strInPatientDate);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}
		/// <summary>
		/// 查找缺陷
		/// </summary>
		/// <param name="p_strInPatientID"></param>
		/// <param name="p_strInPatientDate"></param>
		/// <param name="p_hasContent"></param>
		/// <returns></returns>
		public long m_lngGetDetailInfo(string p_strInPatientID,string p_strInPatientDate,out Hashtable p_hasContent)
		{
			p_hasContent = null;

            com.digitalwave.CaseGradeServ.clsCaseGradeServ m_objServ =
                (com.digitalwave.CaseGradeServ.clsCaseGradeServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.CaseGradeServ.clsCaseGradeServ));

            long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngGetDetailInfo(p_strInPatientID,p_strInPatientDate,out p_hasContent);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}
        #region 查询病人
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_strDeptId"></param>
        /// <param name="p_strAreaId"></param>
        /// <param name="p_strInpatientIdLike"></param>
        /// <param name="p_strInpatientNameLike"></param>
        /// <param name="p_dtbValues"></param>
        /// <returns></returns>
        public long m_lngGetPatient(string p_strDeptId, string p_strAreaId, string p_strInpatientIdLike, string p_strInpatientNameLike, out DataTable p_dtbValues)
        {
            com.digitalwave.CaseGradeServ.clsCaseGradeServ m_objServ =
                (com.digitalwave.CaseGradeServ.clsCaseGradeServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.CaseGradeServ.clsCaseGradeServ));

            long lngRes = m_objServ.m_lngGetPatient(null, p_strDeptId, p_strAreaId, p_strInpatientIdLike, p_strInpatientNameLike, out  p_dtbValues);
            return lngRes;
        }
        #endregion 查询病人
	}
}
