using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    /// <summary>
    /// 药品出库
    /// </summary>
    public class clsDcl_OutStorage : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 获取出库主表（多类型）

        /// <summary>
        /// 获取出库主表（多类型）

        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_strAskDeptName">领药单位名</param>
        /// <param name="p_strMedicine">药品代码或名称</param>
        /// <param name="p_strOutID">单据号</param>
        /// <param name="p_intOutStorageType">出库类型</param>
        /// <param name="p_intFormType">单据类型</param>
        /// <param name="p_dtbOutStorage">出库主表内容</param>
        /// <returns></returns>
        internal long m_lngGetOutStorageMain(string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strAskDeptName, string p_strMedicine,
            string p_strOutID,int p_intOutStorageType,int p_intFormType, out DataTable p_dtbOutStorage)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC));
            lngRes = objSvc.m_lngGetOutStorageMain(objPrincipal, p_strStorageID, p_dtmBegin, p_dtmEnd, p_strAskDeptName, p_strMedicine, p_strOutID, p_intOutStorageType,p_intFormType, out p_dtbOutStorage);
            return lngRes;
        } 
        #endregion

        #region 获取出库主表
        /// <summary>
        /// 获取出库主表
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_strAskDeptName">领药单位名</param>
        /// <param name="p_strMedicine">药品代码或名称</param>
        /// <param name="p_strOutID">单据号</param>
        /// <param name="p_intFormType">单据类型</param>
        /// <param name="p_dtbOutStorage">出库主表内容</param>
        /// <returns></returns>
        internal long m_lngGetOutStorageMain(string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strAskDeptName, string p_strMedicine,
            string p_strOutID, int p_intFormType, out DataTable p_dtbOutStorage)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC));
            lngRes = objSvc.m_lngGetOutStorageMain(objPrincipal, p_strStorageID, p_dtmBegin, p_dtmEnd, p_strAskDeptName, p_strMedicine, p_strOutID,  p_intFormType, out p_dtbOutStorage);
            return lngRes;
        }
        #endregion

        #region 获取子表内容
        /// <summary>
        /// 获取子表内容
        /// </summary>
        /// <param name="p_lngMainSEQ">主表序列号</param>
        /// <param name="p_dtbValue">子表内容</param>
        /// <returns></returns>
        internal long m_lngGetOutStorageDetail(long p_lngMainSEQ, out DataTable p_dtbValue)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC));
            lngRes = objSvc.m_lngGetOutStorageDetail(objPrincipal, p_lngMainSEQ, out p_dtbValue);
            return lngRes;
        }
        #endregion

        #region 设置审核者

        /// <summary>
        /// 设置审核者

        /// </summary>
        /// <param name="p_strEmpID">员工ID</param>
        /// <param name="p_lngSeq">序列号</param>
        /// <returns></returns>
        internal long m_lngSetCommitUser(string p_strEmpID, long[] p_lngSeq)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC));
            lngRes = objSvc.m_lngSetCommitUser(objPrincipal, p_strEmpID, p_lngSeq);
            return lngRes;
        }
        #endregion

        #region 退审

        /// <summary>
        /// 退审

        /// </summary>
        /// <param name="p_lngSeq">序列号</param>
        /// <returns></returns>
        internal long m_lngUnCommit(long[] p_lngSeq)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC));
            lngRes = objSvc.m_lngUnCommit(objPrincipal, p_lngSeq);
            return lngRes;
        }
        #endregion

        #region 删除指定出库主表信息
        /// <summary>
        /// 删除指定出库主表信息
        /// </summary>
        /// <param name="p_lngSeq">序列号</param>
        /// <returns></returns>
        internal long m_lngDeleteMainOutStorage(long[] p_lngSeq)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC));
            lngRes = objSvc.m_lngDeleteMainOutStorage(objPrincipal, p_lngSeq);
            return lngRes;
        }
        #endregion

        #region 获取指定日期内的金额
        /// <summary>
        /// 获取指定日期内的金额
        /// </summary>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_intFormID">单据类型</param>
        /// <param name="p_dtbMoney">金额</param>
        /// <returns></returns>
        internal long m_lngGetAllInMoney(DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strStorageID, int p_intFormID, out DataTable p_dtbMoney)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC));
            lngRes = objSvc.m_lngGetAllInMoney(objPrincipal, p_dtmBegin, p_dtmEnd, p_strStorageID,p_intFormID, out p_dtbMoney);
            return lngRes;
        }
        #endregion

        #region 审核出库记录
        /// <summary>
        /// 审核出库记录
        /// </summary>
        /// <param name="p_objDetail">出库药品</param>
        /// <param name="p_objAccDetailArr">帐本明细</param>
        /// <param name="p_strEmpID">审核人ID</param>
        /// <param name="p_lngSeq">出库主表序列</param>
        /// <param name="p_blnIsImmAccount">是否审核即入帐</param>
        /// <returns></returns>
        internal long m_lngCommitOutStorage(clsMS_StorageGrossForOut[] p_objDetail, clsMS_AccountDetail_VO[] p_objAccDetailArr, string p_strEmpID, long p_lngSeq, bool p_blnIsImmAccount)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC));
            lngRes = objSvc.m_lngCommitOutStorage(objPrincipal, p_objDetail, p_objAccDetailArr, p_strEmpID, p_lngSeq, p_blnIsImmAccount);
            return lngRes;
        }
        #endregion

        #region 退审出库记录

        /// <summary>
        /// 退审出库记录

        /// </summary>
        /// <param name="p_objDetail">出库药品</param>
        /// <param name="p_lngSeq">出库主表序列</param>
        /// <param name="p_strOutStorageID">出库单据号</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <returns></returns>
        internal long m_lngUnCommitOutStorage(clsMS_StorageGrossForOut[] p_objDetail, long p_lngSeq, string p_strOutStorageID, string p_strStorageID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC));
            lngRes = objSvc.m_lngUnCommitOutStorage(objPrincipal, p_objDetail, p_lngSeq, p_strOutStorageID, p_strStorageID);
            return lngRes;
        }
        #endregion

        #region 入帐
        /// <summary>
        /// 入帐
        /// </summary>
        /// <param name="p_strChittyIDArr">出库单据号(须与主表序列一一对应)</param>
        /// <param name="p_lngMainSEQ">主表序列(须与出库单据号一一对应)</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strEmpID">员工ID</param>
        /// <param name="p_dtmAccountDate">入账日期</param>
        /// <returns></returns>
        internal long m_lngInAccount(string[] p_strChittyIDArr, long[] p_lngMainSEQ, string p_strStorageID, string p_strEmpID, DateTime p_dtmAccountDate)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC));
            lngRes = objSvc.m_lngInAccount(objPrincipal, p_strChittyIDArr, p_lngMainSEQ, p_strStorageID, p_strEmpID, p_dtmAccountDate);
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

        #region 获取仓库名



        /// <summary>
        /// 获取仓库名



        /// </summary>
        /// <param name="p_strStoreRoomID">仓库ID</param>
        /// <param name="p_strStoreRoomName">仓库名</param>
        /// <returns></returns>
        internal long m_lngGetStoreRoomName(string p_strStoreRoomID, out string p_strStoreRoomName)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetStoreRoomName(objPrincipal, p_strStoreRoomID, out p_strStoreRoomName);
            return lngRes;
        }
        #endregion

        /// <summary>
        /// 获取出库主表
        /// </summary>
        /// <param name="p_lngSeriesID"></param>
        /// <param name="dtbMain"></param>
        internal void m_mthGetOutStorage(long p_lngSeriesID, out DataTable dtbMain)
        {            
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC));
            objSvc.m_mthGetOutStorage(objPrincipal, p_lngSeriesID, out dtbMain);            
        }

        /// <summary>
        /// 审核时新增到药库入库单

        /// </summary>
        /// <param name="objMainTable"></param>
        /// <param name="objSubTable"></param>
        internal void m_mthAddNewDrugStore(clsMS_OutStorage_VO objMainTable, clsMS_OutStorageDetail_VO[] objSubTable)
        {
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC objSvc =
               (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC));
            objSvc.m_lngAddNewDrugStore(objPrincipal, objMainTable, objSubTable);            
        }

        /// <summary>
        /// 是否已生成药库入库单
        /// </summary>
        /// <returns></returns>
        internal bool m_mthHaveAddedIntoDrugStore(long p_lngSE)
        {
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC objSvc =
               (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC));
            return objSvc.m_mthHaveAddedIntoDrugStore(null,p_lngSE);            
        }

        #region 获取出入库类型信息表
        public long m_mthGetImpExpTypeInfo(out DataTable m_dtImpExpType)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_mthGetImpExpTypeInfo(objPrincipal, out m_dtImpExpType);
            return lngRes;
        }
        #endregion

        #region 检查单据状态值
        /// <summary>
        /// 检查单据状态值
        /// </summary>
        /// <param name="p_lngSeq">主表seq</param>
        /// <param name="m_intStatus">单据状态值</param>
        /// <returns></returns>
        internal long m_lngCheckStatus(long p_lngSeq, out int m_intStatus)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC));
            lngRes = objSvc.m_lngCheckStatus(objPrincipal, 1, p_lngSeq, out m_intStatus);//单据类别：1为药库出库单
            return lngRes;
        }
        #endregion
    }
}
