using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.middletier.LIS;

namespace com.digitalwave.iCare.gui.LIS
{
    /// <summary>
    /// �������������Domain��
    /// </summary>
    class clsDcl_BatchSaveReport:com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region ��ѯ���뵥��Ϣͨ�������
        /// <summary>
        /// ��ѯ���뵥��Ϣͨ�������
        /// </summary>
        /// <param name="p_strBarcode"></param>
        /// <param name="p_objMainVO"></param>
        /// <returns></returns>
        public long m_lngQuerySampleInfo(string p_strBarcode, out clsLisApplMainVO p_objMainVO)
        {
            long lngRes = 0;
            clsBatchSaveReportQuerySvc objSvc =
                (clsBatchSaveReportQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsBatchSaveReportQuerySvc));
            lngRes = objSvc.m_lngQuerySampleInfo(p_strBarcode, out p_objMainVO);
            return lngRes;
        }
        #endregion

        #region �������������
        /// <summary>
        /// �������������
        /// </summary>
        /// <param name="p_objMainArr"></param>
        /// <param name="p_strOperator"></param>
        /// <returns></returns>
        public long m_lngUpdateCheckNUM(clsLisApplMainVO[] p_objMainArr, string p_strOperator)
        {
            long lngRes = 0;
            clsBatchSaveReportSvc objSvc =
                (clsBatchSaveReportSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsBatchSaveReportSvc));
            lngRes = objSvc.m_lngUpdateCheckNUM(p_objMainArr, p_strOperator);
            return lngRes;
        }
        #endregion
    }
}
