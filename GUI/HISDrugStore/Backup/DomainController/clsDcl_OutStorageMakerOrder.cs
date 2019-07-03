using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.common;
using System.Collections;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 出库单域类
    /// </summary>
    public class clsDcl_OutStorageMakerOrder : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 插入药房出库主表和明细表数据
        /// <summary>
        /// 插入药房出库主表和明细表数据
        /// </summary>
        /// <param name="m_objMainVo"></param>
        /// <param name="m_objDetailArr"></param>
        /// <param name="p_intCommitFolow">是否保存即审核</param>
        /// <param name="p_strExamerID">设置审核者名字</param>
        /// <param name="p_strMedicineName">药品名字</param>
        /// <returns></returns>
        public long m_lngAddNewOutstorageInfo(ref clsDS_OutStorage_VO m_objMainVo, ref clsDS_Outstorage_Detail[] m_objDetailArr,int p_intCommitFolow,string p_strExamerID,out string p_strMedicineName)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsOutstorage_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOutstorage_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOutstorage_SVC));
            lngRes = objSvc.m_lngAddNewOutstorageInfo(objPrincipal, ref m_objMainVo, ref m_objDetailArr, p_intCommitFolow, p_strExamerID, out p_strMedicineName);
            return lngRes;
        }
        #endregion

        #region 更新药房出库主表和明细表数据
        /// <summary>
        /// 更新药房出库主表和明细表数据
        /// </summary>
        /// <param name="m_objMainVo"></param>
        /// <param name="m_objDetailArr"></param>
        /// <param name="p_intCommitFolow"></param>
        /// <param name="p_strExamerID"></param>
        /// <returns></returns>
        public long m_lngUpdateOutStorageInfo(clsDS_OutStorage_VO m_objMainVo, clsDS_UpdateStorageBySeriesID_VO[] m_objUpdateArr, ref clsDS_Outstorage_Detail[] m_objDetailArr, int p_intCommitFolow,string p_strExamerID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsOutstorage_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOutstorage_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOutstorage_SVC));
            lngRes = objSvc.m_lngUpdateOutStorageInfo(objPrincipal, m_objMainVo, m_objUpdateArr,ref m_objDetailArr,p_intCommitFolow,p_strExamerID);
            return lngRes;
        }
        #endregion 
    
        #region 获取指定药品库存信息
        /// <summary>
        /// 获取指定药品库存信息
        /// </summary>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_objDetailArr">库存信息</param>
        /// <returns></returns>
        internal long m_lngGetStoreMedicineDetail(string p_strMedicineID, string p_strStorageID, out clsDS_StorageDetail_VO[] p_objDetailArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC));
            lngRes = objSvc.m_lngGetStoreMedicineDetail(objPrincipal, p_strMedicineID, p_strStorageID, out p_objDetailArr);
            return lngRes;
        }
        #endregion

        #region 获取指定药品出库数量
        /// <summary>
        /// 获取指定药品出库数量
        /// </summary>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_hstNetAmount">针对指定药物，以批号为键，出库数量为值的哈希表</param>
        /// <returns></returns>
        internal long m_lngGetIPAmount(long p_lngMainSEQ, string p_strMedicineID, out Hashtable p_hstNetAmount)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC));
            lngRes = objSvc.m_lngGetIPAmount(objPrincipal, p_lngMainSEQ, p_strMedicineID, out p_hstNetAmount);
            return lngRes;
        }
        #endregion

        #region 根据流水号删除药房出库明细
        /// <summary>
        /// 根据流水号删除药房出库明细
        /// </summary>
        /// <param name="m_lngSeqid"></param>
        /// <returns></returns>
        public long m_lngDelOutstorageDetail(long m_lngSeqid)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsOutstorage_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOutstorage_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOutstorage_SVC));
            lngRes = objSvc.m_lngDelOutstorageDetail(objPrincipal, m_lngSeqid,1);
            return lngRes;
        }
        #endregion

        internal long m_lngGetDetailForUpdate(long m_lngSeqID,int p_intMode, out clsDS_UpdateStorageBySeriesID_VO[] m_objForUpdateArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC));
            lngRes = objSvc.m_lngGetDetailForUpdate(objPrincipal, m_lngSeqID, p_intMode, out m_objForUpdateArr);
            return lngRes;
        }

        #region 获取审核流程设置
        /// <summary>
        /// 获取审核流程设置
        /// </summary>
        /// <param name="p_intCommitFolw">审核流程设置</param>
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

        /// <summary>
        /// 修改出库单的FormType、 出库类型、发往部门
        /// </summary>
        /// <param name="p_strBillNo"></param>
        /// <param name="p_intFormType_int"></param>
        /// <param name="p_strTypeCode"></param>
        /// <param name="p_strDeptCode"></param>
        /// <param name="p_blnHasGenerateInBill">是否已生成入库单</param>
        /// <returns></returns>
        internal long m_lngUpdateTypeAndDept(string p_strBillNo, int p_intFormType_int, string p_strTypeCode, string p_strDeptCode,bool p_blnHasGenerateInBill,string p_strComment)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsOutstorage_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOutstorage_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOutstorage_SVC));
            lngRes = objSvc.m_lngUpdateTypeAndDept(objPrincipal,1, p_strBillNo, p_intFormType_int, p_strTypeCode, p_strDeptCode,p_strComment);
            return lngRes;
        }

        internal long m_lngCheckIfHasGenerateInstorage(string p_strOutBillNo, out bool p_blnHasGenerateInstorageBill)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC));
            lngRes = objSvc.m_lngCheckIfHasGenerateInstorage(objPrincipal, p_strOutBillNo, out p_blnHasGenerateInstorageBill);
            return lngRes;
        }

        internal long m_lngCheckStorage(bool p_blnIsHospital,string p_strDrugStoreID, ref DataTable p_dtbTemp, ref DataTable p_dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC));
            lngRes = objSvc.m_lngCheckStorage(objPrincipal,p_blnIsHospital, p_strDrugStoreID, ref p_dtbTemp, ref p_dtbResult);
            return lngRes;
        }

        public long m_lngLoadBill(bool p_blnIsHospital,string p_strBillID, out clsDS_OutStorage_VO p_objMain, out DataTable p_dtbSub)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC));
            lngRes = objSvc.m_lngLoadBill(objPrincipal, p_blnIsHospital,p_strBillID, out p_objMain, out p_dtbSub);
            return lngRes;
        }

        /// <summary>
        /// 获取药品零售价
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

        internal long m_lngCheckIsDrugStoreDept(string p_strDeptID, out bool p_blnSendToDrugStore)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC));
            lngRes = objSvc.m_lngCheckIsDrugStoreDept(objPrincipal, p_strDeptID, out p_blnSendToDrugStore);
            return lngRes;
        }

        /// <summary>
        /// 查询药房出库药品状态
        /// </summary>
        /// <param name="p_strSeq">序列号</param>
        /// <param name="p_intQueryStyle">查询类型是根据主表序列号还是子表序列号0-主表,1-子表</param>
        /// <param name="p_strState">状态</param>
        /// <returns></returns>
        public long m_lngQueryMedOutStoreState(string p_strSeq,int p_intQueryStyle, out string p_strState)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC objSvc = 
                (com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC));
            lngRes = objSvc.m_lngQueryMedOutStoreState(p_strSeq, p_intQueryStyle, out p_strState);
            return lngRes;
        }

        public long m_lngGetDSStorageGross(List<long> m_glstSeriesID, long p_lngMainSeriesID, out Dictionary<long, double> m_gdicDSStorage)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC));
            lngRes = objSvc.m_lngGetDSStorageGross(objPrincipal, m_glstSeriesID, p_lngMainSeriesID, out m_gdicDSStorage);
            return lngRes;
        }

        public long m_lngModifyOutStoreAndStore(string p_strReceipt, ref clsDS_Outstorage_Detail[] m_objDetailArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsOutstorage_SVC objSvc = 
                (com.digitalwave.iCare.middletier.HIS.clsOutstorage_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOutstorage_SVC));
            lngRes = objSvc.m_lngModifyOutStoreAndStore(p_strReceipt, ref m_objDetailArr);
            return lngRes;
        }
    }
}
