using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{  
    /// <summary>
    /// �����ڽ�ת����Ʋ�
    /// </summary>
    public class clsDcl_AccountPeriod : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region ��ȡ�����ڱ�����
        /// <summary>
        /// ��ȡ�����ڱ�����
        /// </summary>
        /// <param name="m_strDrugStoreid">ҩ����Ӧ����ID</param>
        /// <param name="p_dtbAccountData">�����ڱ�����</param>
        /// <returns></returns>
        public long m_lngGetAccountPeriod(string m_strDrugStoreid, out DataTable p_dtbAccountData)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAccountPeriod_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAccountPeriod_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAccountPeriod_Supported_SVC));
            lngRes = objSvc.m_lngGetAccountPeriod(objPrincipal, m_strDrugStoreid, out p_dtbAccountData);
            return lngRes;
        }
        #endregion

        #region ��ȡϵͳ��������
        /// <summary>
        /// ��ȡϵͳ��������
        /// </summary>
        /// <param name="p_strCode">���ô���</param>
        /// <param name="p_strParm">��������</param>
        /// <returns></returns>
        internal long m_lngGetSysParm(string p_strCode, out string p_strParm)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.common.clsCommonInfoSvc objSvc =
                (com.digitalwave.iCare.middletier.common.clsCommonInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.common.clsCommonInfoSvc));
            lngRes = objSvc.m_lngGetSysParm(objPrincipal, p_strCode, out p_strParm);
            return lngRes;
        }
        #endregion

    
    }
}
