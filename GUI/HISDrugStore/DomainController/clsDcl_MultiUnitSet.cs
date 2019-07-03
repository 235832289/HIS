using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using com.digitalwave.iCare.ValueObject;


namespace com.digitalwave.iCare.gui.HIS
{
    class clsDcl_MultiUnitSet : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region ���캯��
        /// <summary>
        /// ���캯��
        /// </summary>
        public clsDcl_MultiUnitSet()
        {

        }
        #endregion

        #region ��ȡҩƷ�б�
        /// <summary>
        /// ��ȡҩƷ�б�
        /// </summary>
        /// <param name="p_dtMedicineList"></param>
        /// <returns></returns>
        public long m_lngGetTableMedicineList(ref DataTable p_dtMedicineList)
        {
            com.digitalwave.iCare.middletier.HIS.clsMedicineLimit_Supported_SVC m_objService =
                (com.digitalwave.iCare.middletier.HIS.clsMedicineLimit_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                    (typeof(com.digitalwave.iCare.middletier.HIS.clsMedicineLimit_Supported_SVC));
            return m_objService.m_lngGetTableMedicineList(ref p_dtMedicineList);
        }
        #endregion

        #region ��ȡ��λ�б�
        /// <summary>
        /// ��ȡ��λ�б�
        /// </summary>
        /// <param name="p_strId"></param>
        /// <param name="p_intBy"></param>
        /// <param name="p_dtAliasList"></param>
        /// <returns></returns>
        public long m_lngGetTableMultiUnitList(string p_strId, out DataTable p_dtMultiUnit)
        {
            com.digitalwave.iCare.middletier.HIS.clsMedicineLimit_Supported_SVC m_objService =
                (com.digitalwave.iCare.middletier.HIS.clsMedicineLimit_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                    (typeof(com.digitalwave.iCare.middletier.HIS.clsMedicineLimit_Supported_SVC));
            return m_objService.m_lngGetTableMultiUnitList(p_strId, out p_dtMultiUnit);
        }
        #endregion

        #region ɾ��������Ϣ

        /// <summary>
        /// ɾ��������Ϣ
        /// </summary>
        /// <param name="p_objVO"></param>
        /// <returns></returns>
        public long m_lngDeleteMultiUnit(clsMultiunit_drug_VO p_objVO)
        {
            com.digitalwave.iCare.middletier.HIS.clsMedicineLimitSVC m_objService =
                (com.digitalwave.iCare.middletier.HIS.clsMedicineLimitSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                    (typeof(com.digitalwave.iCare.middletier.HIS.clsMedicineLimitSVC));
            return m_objService.m_lngDeleteMultiUnit(p_objVO);
        }
        #endregion

        #region ����������ѯ��λ
        /// <summary>
        /// ����������ѯ��λ
        /// </summary>
        /// <param name="strSeledMedId">ҩƷID </param>
        /// <param name="p_strUnit">��λ����</param>
        /// <param name="p_intPackage_Dec">��λ����</param>
        /// <param name="p_CurruseFlag_Int">�Ƿ�ǰ��λ���</param>
        /// <returns></returns>
        public bool m_blnQueryByIndex(string strSeledMedId, string p_strUnit, int p_intPackage_Dec, int p_CurruseFlag_Int)
        {
            com.digitalwave.iCare.middletier.HIS.clsMedicineLimit_Supported_SVC m_objService =
                (com.digitalwave.iCare.middletier.HIS.clsMedicineLimit_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                    (typeof(com.digitalwave.iCare.middletier.HIS.clsMedicineLimit_Supported_SVC));
            return m_objService.m_blnQueryByIndex(strSeledMedId, p_strUnit, p_intPackage_Dec, p_CurruseFlag_Int);
        }
        #endregion

        #region ����������ѯ�Ƿ�Ϊ��ǰʹ�õ�λ
        /// <summary>
        /// ����������ѯ�Ƿ�Ϊ��ǰʹ�õ�λ
        /// </summary>
        /// <param name="strSeledMedId">ҩƷID </param>
        /// <param name="p_strUnit">��λ����</param>
        /// <param name="p_intPackage_Dec">��λ����</param>
        /// <returns></returns>
        public bool m_blnQueryByIndex(string strSeledMedId, string p_strUnit, int p_intPackage_Dec)
        {
            com.digitalwave.iCare.middletier.HIS.clsMedicineLimit_Supported_SVC m_objService =
                (com.digitalwave.iCare.middletier.HIS.clsMedicineLimit_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                    (typeof(com.digitalwave.iCare.middletier.HIS.clsMedicineLimit_Supported_SVC));
            return m_objService.m_blnQueryByIndex(strSeledMedId, p_strUnit, p_intPackage_Dec);
        }
        #endregion

        #region ��ӵ�λ��Ϣ
        /// <summary>
        /// ��ӵ�λ��Ϣ
        /// </summary>
        /// <param name="p_objVO"></param>
        /// <returns></returns>
        public long m_lngAddMultiUnit(clsMultiunit_drug_VO p_objVO)
        {
            com.digitalwave.iCare.middletier.HIS.clsMedicineLimitSVC m_objService =
                (com.digitalwave.iCare.middletier.HIS.clsMedicineLimitSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                    (typeof(com.digitalwave.iCare.middletier.HIS.clsMedicineLimitSVC));
            return m_objService.m_lngAddMultiUnit(p_objVO);
        }
        #endregion

        
         #region ���µ�λ��Ϣ
        /// <summary>
        /// ���µ�λ��Ϣ
        /// </summary>
        /// <param name="p_objVO"></param>
        /// <param name="p_strMedicineId"></param>
        /// <param name="p_strUnitName"></param>
        /// <param name="p_intPackAge"></param>
        /// <param name="p_intCurruseFlag"></param>
        /// <returns></returns>
        public long m_lngUpdateMultiUnit(clsMultiunit_drug_VO p_objVO, string p_strMedicineId, string p_strUnitName,int p_intPackAge, int p_intCurruseFlag,int intStatus)
        {
            com.digitalwave.iCare.middletier.HIS.clsMedicineLimitSVC m_objService =
                (com.digitalwave.iCare.middletier.HIS.clsMedicineLimitSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                    (typeof(com.digitalwave.iCare.middletier.HIS.clsMedicineLimitSVC));
            return m_objService.m_lngUpdateMultiUnit(p_objVO, p_strMedicineId, p_strUnitName, p_intPackAge, p_intCurruseFlag, intStatus);
        }
        #endregion

        #region �����е�λ��Ϊ�ǵ�ǰ��λ
        /// <summary>
        /// �����е�λ��Ϊ�ǵ�ǰ��λ
        /// </summary>
        /// <param name="p_strMedicineId"></param>
        /// <returns></returns>
        public long m_lngSetAllCurruseFlag_0ByItemId(string p_strMedicineId)
        {
            com.digitalwave.iCare.middletier.HIS.clsMedicineLimitSVC m_objService =
                (com.digitalwave.iCare.middletier.HIS.clsMedicineLimitSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                    (typeof(com.digitalwave.iCare.middletier.HIS.clsMedicineLimitSVC));
            return m_objService.m_lngSetAllCurruseFlag_0ByItemId(p_strMedicineId);
        }
        #endregion

        #region ����ҩƷId��ȡ��Ӧ���շ���ĿID
        /// <summary>
        /// ����ҩƷId��ȡ��Ӧ���շ���ĿID
        /// </summary>
        /// <param name="p_strMedicineID"></param>
        /// <param name="p_strItemID"></param>
        /// <returns></returns>
        internal long m_lngGetItemID(string p_strMedicineID, out string p_strItemID)
        {
            com.digitalwave.iCare.middletier.HIS.clsMedicineLimit_Supported_SVC m_objService =
                (com.digitalwave.iCare.middletier.HIS.clsMedicineLimit_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                    (typeof(com.digitalwave.iCare.middletier.HIS.clsMedicineLimit_Supported_SVC));
            return m_objService.m_lngGetItemID(p_strMedicineID,out p_strItemID);
        }
        #endregion
    }
}
