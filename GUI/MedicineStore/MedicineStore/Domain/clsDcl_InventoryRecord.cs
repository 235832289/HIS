using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Data;
using com.digitalwave.iCare.middletier.common;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    /// <summary>
    /// 期初数录入，从中间件获取数据
    /// </summary>
    public class clsDcl_InventoryRecord : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 获取药品最基本信息
        /// <summary>
        /// 获取药品最基本信息
        /// </summary>
        /// <param name="p_strAssistCode">查询条件</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtbMedicine">返回结果</param>
        /// <returns></returns>
        public long m_lngGetBaseMedicine(string p_strAssistCode,string p_strStorageID, out DataTable p_dtbMedicine)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC));
            lngRes = objSvc.m_lngGetBaseMedicine(objPrincipal, p_strAssistCode,p_strStorageID, out p_dtbMedicine);
            return lngRes;
        } 
        /// <summary>
        /// 获取可用数大于0的药品最基本信息
        /// </summary>
        /// <param name="p_strAssistCode">查询条件</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtbMedicine">返回结果</param>
        /// <returns></returns>
        public long m_lngGetBaseMedicineNotZero(string p_strAssistCode, string p_strStorageID, out DataTable p_dtbMedicine)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC));
            lngRes = objSvc.m_lngGetBaseMedicineNotZero(objPrincipal, p_strAssistCode, p_strStorageID, out p_dtbMedicine);
            return lngRes;
        }
        /// <summary>
        /// 获取药品最基本信息(带库存信息)
        /// </summary>
        /// <param name="p_strAssistCode">查询条件</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtbMedicine">返回结果</param>
        /// <returns></returns>
        public long m_lngGetBaseMedicineWithGross(string p_strAssistCode, string p_strStorageID, out DataTable p_dtbMedicine)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC));
            lngRes = objSvc.m_lngGetBaseMedicineWithGross(objPrincipal, p_strAssistCode, p_strStorageID, out p_dtbMedicine);
            return lngRes;
        } 
        
        #endregion

        #region 获取是否默认批号设置
        /// <summary>
        /// 获取是否默认批号设置
        /// </summary>
        /// <param name="p_blnIsSetDefault">是否默认</param>
        /// <returns></returns>
        internal long m_lngGetBatchNumberDefaultSetting(out bool p_blnIsSetDefault)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.common.clsCommonInfoSvc objSvc =
                (com.digitalwave.iCare.middletier.common.clsCommonInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.common.clsCommonInfoSvc));
            lngRes = objSvc.m_lngGetCollocate(objPrincipal, out p_blnIsSetDefault, "5001");
            return lngRes;
        } 
        #endregion

        #region 获取已录入药品信息
        /// <summary>
        /// 获取已录入药品信息
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtbMedicine">药品信息</param>
        /// <returns></returns>
        internal long m_lngGetMedicineDetail(string p_strStorageID, out DataTable p_dtbMedicine)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC));
            lngRes = objSvc.m_lngGetMedicineDetail(objPrincipal, p_strStorageID, out p_dtbMedicine);
            return lngRes;
        } 
        #endregion

        #region 添加原始库存
        /// <summary>
        /// 添加原始库存
        /// </summary>
        /// <param name="p_objMSVOArr">原始库存</param>
        /// <returns></returns>
        internal long m_lngAddNewMedicineInitial(ref clsMS_MedicineInitial_VO[] p_objMSVOArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC));
            lngRes = objSvc.m_lngAddNewMedicineInitial(objPrincipal, ref p_objMSVOArr);
            return lngRes;
        }
        #endregion

        #region 保存药品
        /// <summary>
        /// 保存药品
        /// </summary>
        /// <param name="p_objNew">新添的药品</param>
        /// <param name="p_objModify">修改的药品</param>
        /// <returns></returns>
        internal long m_lngSaveMedicineInfo(ref clsMS_MedicineInitial_VO[] p_objNew, clsMS_MedicineInitial_VO[] p_objModify)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC));
            lngRes = objSvc.m_lngSaveMedicineInfo(objPrincipal,ref p_objNew, p_objModify);
            return lngRes;
        }
        #endregion

        #region 入帐
        /// <summary>
        /// 入帐
        /// </summary>
        /// <param name="p_lngSEQArr">入帐记录序列</param>
        /// <param name="p_strInitialID">入帐ID</param>
        /// <param name="p_strEmpID">员工ID</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <returns></returns>
        internal long m_lngInAccount(long[] p_lngSEQArr, string[] p_strInitialID, string p_strEmpID, string p_strStorageID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC));
            lngRes = objSvc.m_lngInAccount(objPrincipal, p_lngSEQArr, p_strInitialID, p_strEmpID, p_strStorageID);
            return lngRes;
        }
        #endregion

        #region 退审
        /// <summary>
        /// 退审
        /// </summary>
        /// <param name="p_lngSEQ">序列</param>
        /// <param name="p_strInitialID">序列</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strLotNO">批号</param>
        /// <param name="p_dblInAmount">入库数量</param>
        /// <param name="p_strVendorID">供应商</param>
        /// <param name="p_dcmCallPrice">购入价</param>
        /// <returns></returns>
        internal long m_lngUnCommit(long p_lngSEQ, string p_strInitialID, string p_strStorageID, string p_strMedicineID, string p_strLotNO, double p_dblInAmount, string p_strVendorID, decimal p_dcmCallPrice)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC));
            lngRes = objSvc.m_lngUnCommit(objPrincipal, p_lngSEQ, p_strInitialID, p_strStorageID, p_strMedicineID, p_strLotNO, p_dblInAmount, p_strVendorID, p_dcmCallPrice);
            return lngRes;
        }
        #endregion

        #region 审核药品
        /// <summary>
        /// 审核药品
        /// </summary>
        /// <param name="p_objDetailArr">库存明细</param>
        /// <param name="p_objStorageArr">库存主表内容</param>
        /// <param name="p_lngSEQArr">审核行序列</param>
        /// <param name="p_strEmpID">审核人ID</param>
        /// <param name="p_blnIsImmAccount">是否审核即入帐</param>
        /// <returns></returns>
        internal long m_lngCommitMedicineInfo(clsMS_StorageDetail[] p_objDetailArr, clsMS_Storage[] p_objStorageArr, long[] p_lngSEQArr, string p_strEmpID, bool p_blnIsImmAccount)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC));
            lngRes = objSvc.m_lngCommitMedicineInfo(objPrincipal, p_objDetailArr, p_objStorageArr, p_lngSEQArr, p_strEmpID, p_blnIsImmAccount);
            return lngRes;
        }
        #endregion

        #region 修改原始库存
        /// <summary>
        /// 修改原始库存
        /// </summary>
        /// <param name="p_objMSVOArr">原始库存</param>
        /// <returns></returns>
        internal long m_lngModifyMedicineInitial(clsMS_MedicineInitial_VO[] p_objMSVOArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC));
            lngRes = objSvc.m_lngModifyMedicineInitial(objPrincipal, p_objMSVOArr);
            return lngRes;
        }
        #endregion

        #region 删除指定初始库存
        /// <summary>
        /// 删除指定初始库存
        /// </summary>
        /// <param name="p_lngSEQ">序列号</param>
        /// <returns></returns>
        internal long m_lngDeleteMedicineInitial(long p_lngSEQ)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC));
            lngRes = objSvc.m_lngDeleteMedicineInitial(objPrincipal, p_lngSEQ);
            return lngRes;
        }
        #endregion

        #region 设置审核者
        /// <summary>
        /// 设置审核者
        /// </summary>
        /// <param name="p_lngSEQArr">审核药品序列号</param>
        /// <param name="p_strEMPID">审核者ID</param>
        /// <returns></returns>
        internal long m_lngSetCommitUser(long[] p_lngSEQArr, string p_strEMPID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC));
            lngRes = objSvc.m_lngSetCommitUser(objPrincipal, p_lngSEQArr, p_strEMPID);
            return lngRes;
        }
        #endregion

        #region 获取供应商
        /// <summary>
        /// 获取供应商
        /// </summary>
        /// <param name="p_dtbVendor">供应商数据</param>
        /// <returns></returns>
        internal long m_lngGetVendor(out DataTable p_dtbVendor)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetVendor(objPrincipal, out p_dtbVendor);
            return lngRes;
        }
        #endregion


        #region 获取生产厂家

        /// <summary>
        /// 获取生产厂家
        /// </summary>
        /// <param name="p_dtbVendor">供应商数据</param>
        /// <returns></returns>
        internal long m_lngGetManufacturer(out DataTable p_dtbVendor)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetManufacturer(objPrincipal, out p_dtbVendor);
            return lngRes;
        }
        #endregion

        #region 获取领用部门
        /// <summary>
        /// 获取领用部门

        /// </summary>
        /// <param name="p_dtbVendor">领用部门数据</param>
        /// <returns></returns>
        internal long m_lngGetExportDept(out DataTable p_dtbExportDept)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_mthGetExportDept(objPrincipal, out p_dtbExportDept);
            return lngRes;
        }
        #endregion

        #region 获取药品类型批号,有效期控制信息
        /// <summary>
        /// 获取药品类型批号,有效期控制信息
        /// </summary>
        /// <param name="p_strMedicineTypeID">药品类型ID</param>
        /// <param name="p_objTypeVO"></param>
        /// <returns></returns>
        internal long m_lngGetMedicineTypeVisionm(string p_strMedicineTypeID, out clsMS_MedicineTypeVisionmSet p_objTypeVO)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineTypeVisionmSetSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineTypeVisionmSetSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineTypeVisionmSetSVC));
            lngRes = objSvc.m_lngGetMedicineTypeVisionm(objPrincipal, p_strMedicineTypeID, out p_objTypeVO);
            return lngRes;
        }
        #endregion
        
    }
}
