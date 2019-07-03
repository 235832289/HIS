using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// ҩƷ�������ϸ
    /// </summary>
    public class clsDcl_QueryMedicineDetail : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region ��ȡҩƷ�������Ϣ
        /// <summary>
        /// ��ȡҩƷ�������Ϣ
        /// </summary>
        /// <param name="p_strAssistCode">��ѯ����</param>
        /// <param name="p_strStorageID">�ֿ�ID</param>
        /// <param name="p_dtbMedicine">���ؽ��</param>
        /// <returns></returns>
        public long m_lngGetBaseMedicine(string p_strAssistCode, string p_strStorageID, out DataTable p_dtbMedicine)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC));
            lngRes = objSvc.m_lngGetBaseMedicine(objPrincipal, p_strAssistCode, p_strStorageID, out p_dtbMedicine);
            return lngRes;
        }
        #endregion

        #region ��ȡҩƷ�������ϸ
        public long m_lngGetQueryMedicineDetail(DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strStorageID, string p_strMedicine, out DataTable p_dtbMedicineDetail, out clsMS_QueryMedicineDetailVO clsQuerVO)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsQueryMedicineDetailSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsQueryMedicineDetailSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsQueryMedicineDetailSVC));
            lngRes = objSvc.m_lngGetQueryMedicineDetail_NoLotno(objPrincipal, p_dtmBegin, p_dtmEnd, p_strStorageID, p_strMedicine, out p_dtbMedicineDetail, out clsQuerVO);
            return lngRes;
        }
        #endregion
    }
}
