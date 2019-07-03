using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Data;
using com.digitalwave.iCare.middletier.common;
using com.digitalwave.EMR_EmployeeManagerService;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    public class clsDcl_Purchase_DetailReport : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region ��ӡʱ�Ƿ���ʾ������Ϣ
        /// <summary>
        /// ��ӡʱ�Ƿ���ʾ������Ϣ
        /// </summary>
        /// <param name="p_intShowInfo">�Ƿ���ʾ������Ϣ��</param>
        /// <returns></returns>
        internal long m_lngGetIfShowInfo(out int p_intShowInfo)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetSysSetting(objPrincipal, "5029", out p_intShowInfo);
            return lngRes;
        }
        #endregion
    }
}
