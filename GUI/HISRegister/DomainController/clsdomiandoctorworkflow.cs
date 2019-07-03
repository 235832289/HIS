using System;
using System.Data;
using com.digitalwave.iCare.middletier.HIS;//HISMedStore_SVC.dll
using com.digitalwave.GUI_Base;//GUI_Base.dll
using com.digitalwave.iCare.ValueObject;//iCareDate.dll

namespace com.digitalwave.iCare.gui.HIS
{
    public class clsdomiandoctorworkflow : clsDomainController_Base
    {
        #region 获取科室信息
        /// <summary>
        /// 获取科室信息
        /// </summary>
        /// <param name="objDep"></param>
        /// <returns></returns>
        public long m_lngGetOPDeptInfo(out DataTable objDep)
        {
            long lngRes = 0;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngGetOPDeptInfo(objPrincipal, out objDep);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion
        #region 获取医生工作量信息
        /// <summary>
        /// 获取医生工作量信息
        /// </summary>
        /// <param name="objDep"></param>
        /// <returns></returns>
        public long m_lngGetOPDoctorWorkLoadInfo(string m_strBeignTime, string m_strEndTime, string m_strDoctorID, out DataTable m_objTable)
        {
            long lngRes = 0;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngGetOPDoctorWorkLoadInfo(objPrincipal, m_strBeignTime, m_strEndTime, m_strDoctorID, out m_objTable);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion

        #region 专家组处方信息
        /// <summary>
        /// 专家组处方信息
        /// </summary>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        public long m_lngGetGroupInfo(ref DataTable dtResult)
        {

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            long lngRes = objSvc.m_lngGetGroupInfo(ref dtResult);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion


    }
}
