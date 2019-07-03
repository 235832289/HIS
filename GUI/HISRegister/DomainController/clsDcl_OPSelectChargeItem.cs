using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.middletier.HIS;
using com.digitalwave.Utility;
using System.Data;

namespace com.digitalwave.iCare.gui.HIS
{
    public class clsDcl_OPSelectChargeItem : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 根据处方查询是否已经发药完成
        /// <summary>
        /// 根据处方查询是否已经发药完成
        /// </summary>
        /// <param name="p_strRecNo">处方号</param>
        /// <param name="p_dtbResult"></param>
        /// <returns></returns>
        public long m_lngQuerySendMed(string p_strRecNo, out DataTable p_dtbResult)
        {
            long lngRes = -1;
            p_dtbResult = null;
            try
            {
                clsOPSelectChargeItemSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsOPSelectChargeItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPSelectChargeItemSvc));
                lngRes = objSvc.m_lngQuerySendMed(p_strRecNo, out p_dtbResult);

                objSvc.Dispose();
                objSvc = null;
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogError("m_lngQuerySendMed连接中间件错误：" + objEx.Message);
                objLogger = null;
            }
            return lngRes;
        }
        #endregion

        #region 查询诊疗项目是否已经做好
        /// <summary>
        /// 查询诊疗项目是否已经做好
        /// </summary>
        /// <param name="p_strRecNo">处方号</param>
        /// <param name="p_strOrderDicId">诊疗项目id</param>
        /// <param name="p_intType">1-检验表 2-检查表</param>
        /// <param name="p_dtbResult"></param>
        /// <returns></returns>
        public long m_lngQueryDiagnosisItemStatus(string p_strRecNo, string p_strOrderDicId, int p_intType, out DataTable p_dtbResult)
        {
            long lngRes = -1;
            p_dtbResult = null;
            try
            {
                clsOPSelectChargeItemSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsOPSelectChargeItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPSelectChargeItemSvc));
                lngRes = objSvc.m_lngQueryDiagnosisItemStatus(p_strRecNo, p_strOrderDicId, p_intType, out p_dtbResult);

                objSvc.Dispose();
                objSvc = null;
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogError("m_lngQueryDiagnosisItemStatus连接中间件错误：" + objEx.Message);
                objLogger = null;
            }
            return lngRes;
        }
        #endregion

        #region 根据收费ID判断是否属于手术费用
        /// <summary>
        /// 根据收费ID判断是否属于手术费用
        /// </summary>
        /// <param name="chrgitemcode"></param>
        /// <returns></returns>
        public bool m_blnChkopsitem(string chrgitemcode)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                                                     (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            bool ret = objSvc.m_blnChkopsitem(chrgitemcode);
            objSvc.Dispose();

            return ret;
        }
        #endregion
    }
}
