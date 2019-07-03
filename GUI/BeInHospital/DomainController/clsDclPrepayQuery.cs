using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 预交金查询
    /// 作者：He Guiqiu
    /// 创建时间:2006-06-14
    /// </summary>
    class clsDclPrepayQuery : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        public clsDclPrepayQuery()
        {

        }

        #region 根据传入条件查询
        /// <summary>
        /// 根据传入条件查询
        /// </summary>
        /// <param name="p_strCondition"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        public long GetPrepayInfoBy(string p_strCondition, out DataTable p_dtResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsPrepayQuerySvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsPrepayQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsPrepayQuerySvc));

            long lngRes = 0;
            lngRes = objSvc.GetPrepayInfoBy(objPrincipal, p_strCondition, out p_dtResult);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 根据传入条件查询
        /// <summary>
        /// 根据传入条件查询
        /// </summary>
        /// <param name="p_strCondition"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        public long MondifyCuycate(string p_strCuycate, string p_strPrepayId)
        {
            com.digitalwave.iCare.middletier.HIS.clsPrepayQuerySvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsPrepayQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsPrepayQuerySvc));

            long lngRes = 0;
            lngRes = objSvc.MondifyCuycate(objPrincipal, p_strCuycate, p_strPrepayId);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 获取sys_setting配置信息
        /// <summary>
        /// 获取sys_setting配置信息
        /// </summary>
        /// <returns></returns>
        public long GetSysSetting(string p_setId, out string p_setStatus)
        {
            com.digitalwave.iCare.middletier.HIS.clsPrepayQuerySvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsPrepayQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsPrepayQuerySvc));

            long lngRes = 0;
            lngRes = objSvc.GetSysSetting(objPrincipal, p_setId, out p_setStatus);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion
		

    }
}
