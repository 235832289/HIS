using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// ��ȡ�̵�ҩƷ
    /// </summary>
    public class clsDcl_GetStoreCheckMedicine : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region ͨ��˳��Ż�ȡҩƷ

        /// <summary>
        /// ͨ��˳��Ż�ȡҩƷ
        /// </summary>
        /// <param name="p_strSortBegin">˳��Ŷο�ʼ����</param>
        /// <param name="p_strSortEnd">˳��Ŷν�������</param>
        /// <param name="p_strStorageID">�ֿ�ID</param>
        /// <param name="p_dtbMedicine">ҩƷ����</param>
        /// <returns></returns>
        internal long m_lngGetMedicineBySortNum(string p_strSortBegin, string p_strSortEnd, string p_strStorageID,bool p_blnIsHospital, out DataTable p_dtbMedicine)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsGetStoreCheckMedicine_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsGetStoreCheckMedicine_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsGetStoreCheckMedicine_Supported_SVC));
            lngRes = objSvc.m_lngGetMedicineBySortNum(objPrincipal, p_strSortBegin, p_strSortEnd, p_strStorageID,p_blnIsHospital, out p_dtbMedicine);
            return lngRes;
        }
        #endregion

        #region ����ҩƷ�����ȡҩƷ
        /// <summary>
        /// ����ҩƷ�����ȡҩƷ
        /// </summary>
        /// <param name="p_strMedicineCodeBegin">ҩƷ����ο�ʼ����</param>
        /// <param name="p_strMedicineCodeEnd">ҩƷ����ν�������</param>
        /// <param name="p_strStorageID">�ֿ�ID</param>
        /// <param name="p_dtbMedicine">ҩƷ����</param>
        /// <returns></returns>
        internal long m_lngGetMedicineByMedicineCode(string p_strMedicineCodeBegin, string p_strMedicineCodeEnd, string p_strStorageID,bool p_blnIsHospital, out DataTable p_dtbMedicine)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsGetStoreCheckMedicine_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsGetStoreCheckMedicine_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsGetStoreCheckMedicine_Supported_SVC));
            lngRes = objSvc.m_lngGetMedicineByMedicineCode(objPrincipal, p_strMedicineCodeBegin, p_strMedicineCodeEnd, p_strStorageID,p_blnIsHospital, out p_dtbMedicine);
            return lngRes;
        }
        #endregion

        #region ����ҩƷ���ͻ�ȡҩƷ
        /// <summary>
        /// ����ҩƷ���ͻ�ȡҩƷ
        /// </summary>
        /// <param name="p_strMedicinePreptypeID">ҩƷ����ID</param>
        /// <param name="p_strStorageID">�ֿ�ID</param>
        /// <param name="p_dtbMedicine">ҩƷ����</param>
        /// <returns></returns>
        internal long m_lngGetMedicineByMedicinePreptype(string p_strMedicinePreptypeID, string p_strStorageID,bool p_blnIsHospital, out DataTable p_dtbMedicine)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsGetStoreCheckMedicine_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsGetStoreCheckMedicine_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsGetStoreCheckMedicine_Supported_SVC));
            lngRes = objSvc.m_lngGetMedicineByMedicinePreptype(objPrincipal, p_strMedicinePreptypeID, p_strStorageID,p_blnIsHospital, out p_dtbMedicine);
            return lngRes;
        }
        #endregion

        #region ����ҩƷ���ͻ�ȡҩƷ
        /// <summary>
        /// ����ҩƷ���ͻ�ȡҩƷ
        /// </summary>
        /// <param name="p_strMedicineTypeID">ҩƷ����ID</param>
        /// <param name="p_strStorageID">�ֿ�ID</param>
        /// <param name="p_dtbMedicine">ҩƷ����</param>
        /// <returns></returns>
        internal long m_lngGetMedicineByMedicineType(string p_strMedicineTypeID, string p_strStorageID,bool p_blnIsHospital, out DataTable p_dtbMedicine)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsGetStoreCheckMedicine_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsGetStoreCheckMedicine_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsGetStoreCheckMedicine_Supported_SVC));
            lngRes = objSvc.m_lngGetMedicineByMedicineType(objPrincipal, p_strMedicineTypeID, p_strStorageID, p_blnIsHospital,out p_dtbMedicine);
            return lngRes;
        }

        /// <summary>
        /// ����ҩƷ���ͻ�ȡҩƷ
        /// </summary>
        /// <param name="p_strMedicineTypeIDArr">ҩƷ����ID����</param>
        /// <param name="p_strStorageID">�ֿ�ID</param>
        /// <param name="p_dtbMedicine">ҩƷ����</param>
        /// <returns></returns>
        public long m_lngGetMedicineByMedicineType(System.Collections.ArrayList p_strMedicineTypeIDArr, string p_strStorageID,bool p_blnIsHospital, out DataTable p_dtbMedicine)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsGetStoreCheckMedicine_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsGetStoreCheckMedicine_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsGetStoreCheckMedicine_Supported_SVC));
            lngRes = objSvc.m_lngGetMedicineByMedicineTypeList(objPrincipal, p_strMedicineTypeIDArr, p_strStorageID, p_blnIsHospital,out p_dtbMedicine);
            return lngRes;
        }
        #endregion

        #region ���ݻ��ܺŻ�ȡҩƷ��Ϣ

        /// <summary>
        /// ���ݻ��ܺŻ�ȡҩƷ��Ϣ
        /// </summary>
        /// <param name="p_strRackNOBegin">���ܺ���ο�ʼ����</param>
        /// <param name="p_strRackNOEnd">���ܺ���ν�������</param>
        /// <param name="p_strStorageID">�ֿ�ID</param>
        /// <param name="p_dtbMedicine">ҩƷ����</param>
        /// <returns></returns>
        internal long m_lngGetMedicineByMedicineRackNO(string p_strRackNOBegin, string p_strRackNOEnd, string p_strStorageID,bool p_blnIsHospital, out DataTable p_dtbMedicine)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsGetStoreCheckMedicine_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsGetStoreCheckMedicine_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsGetStoreCheckMedicine_Supported_SVC));
            lngRes = objSvc.m_lngGetMedicineByMedicineRackNO(objPrincipal, p_strRackNOBegin, p_strRackNOEnd, p_strStorageID,p_blnIsHospital, out p_dtbMedicine);
            return lngRes;
        }
        #endregion

        #region ��ȡȫ��ҩƷ
        /// <summary>
        /// ��ȡȫ��ҩƷ
        /// </summary>
        /// <param name="p_strStorageID">�ֿ�ID</param>
        /// <param name="p_dtbMedicine">ҩƷ����</param>
        /// <returns></returns>
        internal long m_lngGetAllMedicine(string p_strStorageID,bool p_blnIsHospital, out DataTable p_dtbMedicine)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsGetStoreCheckMedicine_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsGetStoreCheckMedicine_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsGetStoreCheckMedicine_Supported_SVC));
            lngRes = objSvc.m_lngGetAllMedicine(objPrincipal, p_strStorageID, p_blnIsHospital,out p_dtbMedicine);
            return lngRes;
        }
        #endregion

        #region ��ȡҩƷ�Ƽ�����
        /// <summary>
        /// ��ȡҩƷ�Ƽ�����
        /// </summary>
        /// <param name="p_strDrugStoreId">ҩ��ID</param>
        /// <param name="p_objMPVO">ҩƷ�Ƽ�����</param>
        /// <returns></returns>
        public long m_lngGetMedicinePreptype(string p_strDrugStoreId,out clsMEDICINEPREPTYPE_VO[] p_objMPVO)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC));
            lngRes = objSvc.m_lngGetMedicinePreptype(objPrincipal,p_strDrugStoreId, out p_objMPVO);
            return lngRes;
        }
        #endregion
       
        #region ȡ�����е�ҩƷ����
        /// <summary>
        /// ȡ�����е�ҩƷ����
        /// </summary>
        /// <param name="objResultArr"></param>
        /// <returns></returns>
        public long m_lngGetMedType(out clsMedicineType_VO[] objResultArr)
        {
            objResultArr = new clsMedicineType_VO[0];
            long lngRes = 0;
            System.Security.Principal.IPrincipal objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.clsGetStoreCheckMedicine_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsGetStoreCheckMedicine_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsGetStoreCheckMedicine_Supported_SVC));
            lngRes = objSvc.m_lngFindAllMedicineType(objPrincipal, out objResultArr);

            return lngRes;
        }
        #endregion

        public long m_lngGetStorageMedicineType(out clsMS_MedicineType_VO[] objMTVO)
        {
            objMTVO = new clsMS_MedicineType_VO[0];
            long lngRes = 0;
            System.Security.Principal.IPrincipal objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.clsGetStoreCheckMedicine_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsGetStoreCheckMedicine_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsGetStoreCheckMedicine_Supported_SVC));
            lngRes = objSvc.m_lngGetStorageMedicineType(objPrincipal, out objMTVO);

            return lngRes;
        }
    }
}
