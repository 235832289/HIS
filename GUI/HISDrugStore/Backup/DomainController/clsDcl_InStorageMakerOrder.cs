using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.digitalwave.iCare.ValueObject;
namespace com.digitalwave.iCare.gui.HIS
{   
    /// <summary>
    /// ҩ������Ƶ�
    /// </summary>
    public class clsDcl_InStorageMakerOrder : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region ��ȡ����ҩ��������Ϣ��
        /// <summary>
        ///  ��ȡ����ҩ��������Ϣ��
        /// </summary>
        /// <param name="m_dtMedStore"></param>
        /// <returns></returns>
        public long m_lngGetMedStoreInfo( out DataTable m_dtMedStore)
        {

            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC));
            lngRes = objSvc.m_lngGetMedStoreInfo(objPrincipal, out m_dtMedStore);
            return lngRes;
            
        }
        #endregion
        #region ����ҩ������������ϸ������
        /// <summary>
        /// ����ҩ������������ϸ������
        /// </summary>
        /// <param name="m_objMainVo"></param>
        /// <param name="m_objDetailArr"></param>
        /// <param name="p_intCommitFolow"></param>
        /// <param name="p_strExamerID"></param>
        /// <returns></returns>
        public long m_lngAddNewInstorage(ref clsDS_Instorage_VO m_objMainVo, ref clsDS_Instorage_Detail[] m_objDetailArr, int p_intCommitFolow, string p_strExamerID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsInstorage_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsInstorage_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsInstorage_SVC));
            lngRes = objSvc.m_lngAddNewInstorage(objPrincipal, ref m_objMainVo, ref m_objDetailArr, p_intCommitFolow, p_strExamerID);
            return lngRes;
        }
        #endregion
        #region ����ҩ������������ϸ������
         /// <summary>
        /// ����ҩ������������ϸ������
         /// </summary>
         /// <param name="m_objMainVo"></param>
         /// <param name="m_objDetailArr"></param>
        /// <param name="p_intCommitFolow"></param>
        /// <param name="p_strExamerID"></param>
         /// <returns></returns>
        public long m_lngUpdateInStorageInfo(clsDS_Instorage_VO m_objMainVo, ref clsDS_Instorage_Detail[] m_objDetailArr, int p_intCommitFolow, string p_strExamerID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsInstorage_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsInstorage_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsInstorage_SVC));
            lngRes = objSvc.m_lngUpdateInStorageInfo(objPrincipal, m_objMainVo, ref m_objDetailArr, p_intCommitFolow, p_strExamerID);
            return lngRes;
        }
        #endregion 
        #region ������ˮ��ɾ��ҩ�������ϸ
        /// <summary>
        /// ������ˮ��ɾ��ҩ�������ϸ
        /// </summary>
        /// <param name="m_lngSeqid"></param>
        /// <returns></returns>
        public long m_lngDelInstorageDetail(long m_lngSeqid)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsInstorage_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsInstorage_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsInstorage_SVC));
            lngRes = objSvc.m_lngDelInstorageDetail(objPrincipal, m_lngSeqid);
            return lngRes;
        }
         #endregion
        #region ���������ж��Ƿ������Ӧ��ҩƷ�����ϸ��Ϊ��⸺�����
        /// <summary>
        /// ���������ж��Ƿ������Ӧ��ҩƷ�����ϸ��Ϊ��⸺�����
        /// </summary>
        /// <param name="m_strDurgStoreid"></param>
        /// <param name="m_strLotNo"></param>
        /// <param name="m_strMedicineid"></param>
        /// <param name="m_dblOPAmount"></param>
        /// <param name="m_blnExisted"></param>
        /// <returns></returns>
        public long m_lngJudgeMedicineExisted(string m_strDurgStoreid, string m_strLotNo, string m_strMedicineid,ref double m_dblOPAmount,ref double m_dblIPAmount, out bool m_blnExisted)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsInstorage_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsInstorage_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsInstorage_Supported_SVC));
            lngRes = objSvc.m_lngJudgeMedicineExisted(m_strDurgStoreid, m_strLotNo, m_strMedicineid,ref  m_dblOPAmount,ref m_dblIPAmount, out  m_blnExisted);
            return lngRes;
        }
        #endregion

        #region ��ȡ�����������
        /// <summary>
        /// ��ȡ�����������
        /// </summary>
        /// <param name="p_intCommitFolw">�����������</param>
        /// <returns></returns>
        internal long m_lngGetCommitFlow(out int p_intCommitFolw)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetSysSetting(objPrincipal, "5005", out p_intCommitFolw);
            return lngRes;
        }
        #endregion

        #region ��ȡҩƷ��Ĭ������
        /// <summary>
        /// ��ȡҩƷ��Ĭ������
        /// </summary>
        /// <param name="p_strDrugStoreID">ҩ��ID</param>
        /// <param name="p_strMedicineId">ҩƷID</param>
        /// <param name="p_dblOpRetailPrice">���ۼ�</param>
        /// <param name="p_strLotno">����</param>
        /// <param name="p_datValidDate">��Ч��</param>
        internal long m_lngGetDefaultLotno(string p_strDrugStoreID, string p_strMedicineId, double p_dblOpRetailPrice,out string p_strLotno,out DateTime p_datValidDate)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsInstorage_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsInstorage_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsInstorage_Supported_SVC));
            lngRes = objSvc.m_lngGetDefaultLotno(objPrincipal, p_strDrugStoreID, p_strMedicineId, p_dblOpRetailPrice,out p_strLotno, out p_datValidDate);
            return lngRes;
        }
        #endregion

        /// <summary>
        /// �޸���ⵥ��FormType��������͡���Դ����
        /// </summary>
        /// <param name="p_intStatus">״̬</param>
        /// <param name="p_strBillNo"></param>
        /// <param name="p_intFormType_int"></param>
        /// <param name="p_strTypeCode"></param>
        /// <param name="p_strDeptCode"></param>
        /// <param name="p_strComment">��ע</param>
        /// <returns></returns>
        internal long m_lngUpdateTypeAndDept(int p_intStatus,string p_strBillNo, int p_intFormType_int, string p_strTypeCode, string p_strDeptCode,string p_strComment)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsInstorage_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsInstorage_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsInstorage_SVC));
            lngRes = objSvc.m_lngUpdateTypeAndDept(objPrincipal,p_intStatus, p_strBillNo, p_intFormType_int, p_strTypeCode, p_strDeptCode,p_strComment);
            return lngRes;
        }

        public long m_lngLoadBill(bool p_blnIsHospital,string p_strBillID, out clsDS_Instorage_VO p_objMain, out DataTable p_dtbSub)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsInstorage_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsInstorage_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsInstorage_Supported_SVC));
            lngRes = objSvc.m_lngLoadBill(objPrincipal, p_blnIsHospital,p_strBillID, out p_objMain, out p_dtbSub);
            return lngRes;
        }

        /// <summary>
        /// ��ȡҩƷ���ۼ�
        /// </summary>
        /// <param name="p_strMedicineID"></param>
        /// <param name="p_dcmPrice"></param>
        public long m_lngGetRetailPrice(string p_strMedicineID, out decimal p_dcmPrice)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetRetailPrice(objPrincipal, p_strMedicineID, out p_dcmPrice);
            return lngRes;
        }

        /// <summary>
        /// ��ѯ��ⵥ��״̬
        /// </summary>
        /// <param name="p_strSeriesid"></param>
        /// <param name="p_strState"></param>
        /// <param name="intQueryStyle">��ѯ����:0-ֱ�Ӳ�ѯ����״̬,1-ͨ���ӱ��ѯ����״̬</param>
        /// <returns></returns>
        public long m_lngQueryInstorageState(string p_strSeriesid, int p_intQueryStyle, out string p_strState)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsInstorage_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsInstorage_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsInstorage_Supported_SVC));
            lngRes = objSvc.m_lngQueryInstorageState(p_strSeriesid, p_intQueryStyle, out p_strState); 
            return lngRes;
        }

        /// <summary>
        /// ����Ƿ����ͬһ�����Ŷ����ͬ���ۼ�
        /// </summary>
        /// <param name="p_strDrugStoreID"></param>
        /// <param name="p_strMedicineID"></param>
        /// <param name="p_strLotno"></param>
        /// <param name="p_dblOpRetailPrice"></param>
        /// <param name="p_blnExist"></param>
        internal void m_lngCheckDiffPrice(string p_strDrugStoreID, string p_strMedicineID, string p_strLotno, double p_dblOpRetailPrice, out bool p_blnExist)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsInstorage_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsInstorage_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsInstorage_Supported_SVC));
            lngRes = objSvc.m_lngCheckDiffPrice(objPrincipal,p_strDrugStoreID, p_strMedicineID, p_strLotno, p_dblOpRetailPrice, out p_blnExist);
        }
    }
}
