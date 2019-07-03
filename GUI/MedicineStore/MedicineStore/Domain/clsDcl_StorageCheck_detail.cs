using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Data;
using com.digitalwave.iCare.middletier.common;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    /// <summary>
    /// 药品盘点明细
    /// </summary>
    class clsDcl_StorageCheck_detail : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 添加盘点明细
        /// <summary>
        /// 添加盘点明细
        /// </summary>
        /// <param name="p_objSCVOArr">盘点明细</param>
        /// <param name="p_lngSEQArr">盘点明细序列</param>
        /// <returns></returns>
        internal long m_lngAddNewStorageCheckDetail(clsMS_StorageCheckDetail_VO[] p_objSCVOArr, out long[] p_lngSEQArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC));
            lngRes = objSvc.m_lngAddNewStorageCheckDetail(objPrincipal, p_objSCVOArr, out p_lngSEQArr);
            return lngRes;
        }
        #endregion

        #region 添加盘点主表
        /// <summary>
        /// 添加盘点主表
        /// </summary>
        /// <param name="p_objSCVO">盘点明细</param>
        /// <returns></returns>
        internal long m_lngAddNewStorageCheckMain(ref clsMS_StorageCheck_VO p_objSCVO)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC));
            lngRes = objSvc.m_lngAddNewStorageCheckMain(objPrincipal, ref p_objSCVO);
            return lngRes;
        }
        #endregion

        #region 修改盘点明细信息
        /// <summary>
        /// 修改盘点明细信息
        /// </summary>
        /// <param name="p_objSCVOArr">盘点明细</param>
        /// <returns></returns>
        internal long m_lngModifyStorageCheckDetail(clsMS_StorageCheckDetail_VO[] p_objSCVOArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC));
            lngRes = objSvc.m_lngModifyStorageCheckDetail(objPrincipal, p_objSCVOArr);
            return lngRes;
        }
        #endregion

        #region 修改盘点主表
        /// <summary>
        /// 修改盘点主表
        /// </summary>
        /// <param name="p_objSCVO">盘点主表信息</param>
        /// <returns></returns>
        internal long m_lngMofifyStorageCheck(clsMS_StorageCheck_VO p_objSCVO)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC));
            lngRes = objSvc.m_lngMofifyStorageCheck(objPrincipal, p_objSCVO);
            return lngRes;
        }
        #endregion

        #region 获取有出库记录的盘盈药品
        /// <summary>
        /// 获取有出库记录的盘盈药品
        /// </summary>
        /// <param name="p_strCheckID">盘点ID</param>
        /// <param name="p_dtbOut">出库药品</param>
        /// <returns></returns>
        internal long m_lngGetHasOutCheckMedicine(string p_strCheckID, out DataTable p_dtbOut)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC));
            lngRes = objSvc.m_lngGetHasOutCheckMedicine(objPrincipal, p_strCheckID, out p_dtbOut);
            return lngRes;
        }
        #endregion

        #region 获取已保存至入库表的盘盈记录
        /// <summary>
        /// 获取已保存至入库表的盘盈记录
        /// </summary>
        /// <param name="p_strCheckID">盘点ID</param>
        /// <param name="p_dtbIn">出库药品</param>
        /// <returns></returns>
        internal long m_lngGetInCheckMedicine(string p_strCheckID, out DataTable p_dtbIn)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC));
            lngRes = objSvc.m_lngGetInCheckMedicine(objPrincipal, p_strCheckID, out p_dtbIn);
            return lngRes;
        }
        #endregion

        #region 获取已保存至出库表的盘亏记录
        /// <summary>
        /// 获取已保存至出库表的盘亏记录
        /// </summary>
        /// <param name="p_strCheckID">盘点ID</param>
        /// <param name="p_dtbIn">出库药品</param>
        /// <returns></returns>
        internal long m_lngGetOutCheckMedicine(string p_strCheckID, out DataTable p_dtbIn)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC));
            lngRes = objSvc.m_lngGetOutCheckMedicine(objPrincipal, p_strCheckID, out p_dtbIn);
            return lngRes;
        }
        #endregion

        #region 修改盘盈数量
        /// <summary>
        /// 修改盘盈数量
        /// </summary>
        /// <param name="p_lngSEQ">入库明细序列</param>
        /// <param name="p_dblAmount">盘盈数量</param>
        /// <returns></returns>
        internal long m_lngModifyInAmount(long p_lngSEQ, double p_dblAmount)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC));
            lngRes = objSvc.m_lngModifyInAmount(objPrincipal, p_lngSEQ, p_dblAmount);
            return lngRes;
        }
        #endregion

        #region 修改盘亏数量
        /// <summary>
        /// 修改盘亏数量
        /// </summary>
        /// <param name="p_lngSEQ">出库明细序列</param>
        /// <param name="p_dblAmount">盘亏数量</param>
        /// <returns></returns>
        internal long m_lngModifyOutAmount(long p_lngSEQ, double p_dblAmount)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC));
            lngRes = objSvc.m_lngModifyOutAmount(objPrincipal, p_lngSEQ, p_dblAmount);
            return lngRes;
        }
        #endregion

        #region 保存盘盈数据至入库表
        /// <summary>
        /// 保存盘盈数据至入库表
        /// </summary>
        /// <param name="p_objInMain">入库主表信息</param>
        /// <param name="p_objInDetail">入库明细信息</param>
        /// <returns></returns>
        internal long m_lngSaveCheckToInStorage(clsMS_InStorage_VO p_objInMain, clsMS_InStorageDetail_VO p_objInDetail)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC));
            lngRes = objSvc.m_lngSaveCheckToInStorage(objPrincipal, p_objInMain, p_objInDetail);
            return lngRes;
        } 
        #endregion

        #region 保存盘亏数据至出库表
        /// <summary>
        /// 保存盘亏数据至出库表
        /// </summary>
        /// <param name="p_objOutMain">出库主表信息</param>
        /// <param name="p_objOutDetail">出库明细信息</param>
        /// <returns></returns>
        internal long m_lngSaveCheckToOutStorage(clsMS_OutStorage_VO p_objOutMain, clsMS_OutStorageDetail_VO p_objOutDetail)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC));
            lngRes = objSvc.m_lngSaveCheckToOutStorage(objPrincipal, p_objOutMain, p_objOutDetail);
            return lngRes;
        }
        #endregion

        #region 将旧有的盘亏记录设为无效
        /// <summary>
        /// 将旧有的盘亏记录设为无效
        /// </summary>
        /// <param name="p_strCheckID">盘点ID</param>
        /// <returns></returns>
        internal long m_lngDeleteOutStorage(string p_strCheckID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC));
            lngRes = objSvc.m_lngDeleteOutStorage(objPrincipal, p_strCheckID);
            return lngRes;
        }

        /// <summary>
        /// 将旧有的盘亏记录设为无效
        /// </summary>
        /// <param name="p_strCheckID">盘点ID</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strLotNO">批号</param>
        /// <param name="p_strInStorageID">入库单据号</param>
        /// <param name="p_dtmValiDate">有效期</param>
        /// <param name="p_dblInPrice">购入价</param>
        /// <returns></returns>
        internal long m_lngDeleteOutStorage(string p_strCheckID, string p_strMedicineID, string p_strLotNO, string p_strInStorageID, DateTime p_dtmValiDate, double p_dblInPrice)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC));
            lngRes = objSvc.m_lngDeleteOutStorage(objPrincipal, p_strCheckID, p_strMedicineID, p_strLotNO, p_strInStorageID, p_dtmValiDate, p_dblInPrice);
            return lngRes;
        }
        #endregion

        #region 将旧有的盘盈记录设为无效
        /// <summary>
        /// 将旧有的盘盈记录设为无效
        /// </summary>
        /// <param name="p_strCheckID">盘点ID</param>
        /// <returns></returns>
        internal long m_lngDeleteInStorage(string p_strCheckID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC));
            lngRes = objSvc.m_lngDeleteInStorage(objPrincipal, p_strCheckID);
            return lngRes;
        }

        /// <summary>
        /// 将旧有的盘盈记录设为无效
        /// </summary>
        /// <param name="p_strCheckID">盘点ID</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strLotNO">批号</param>
        /// <param name="p_strInStorageID">入库单据号</param>
        /// <param name="p_dtmValiDate">有效期</param>
        /// <param name="p_dblInPrice">购入价</param>
        /// <returns></returns>
        internal long m_lngDeleteInStorage(string p_strCheckID, string p_strMedicineID, string p_strLotNO, string p_strInStorageID, DateTime p_dtmValiDate, double p_dblInPrice)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC));
            lngRes = objSvc.m_lngDeleteInStorage(objPrincipal, p_strCheckID, p_strMedicineID, p_strLotNO, p_strInStorageID, p_dtmValiDate, p_dblInPrice);
            return lngRes;
        }
        #endregion

        #region 修改库存明细表库存数量
        /// <summary>
        /// 修改库存明细表库存数量
        /// </summary>
        /// <param name="p_objStDetail">更改库存VO</param>
        /// <returns></returns>
        internal long m_lngAddStorageDetailGross(clsMS_StorageDetail[] p_objStDetail)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC));
            lngRes = objSvc.m_lngAddStorageDetailGross(objPrincipal, p_objStDetail);
            return lngRes;
        }
        #endregion

        #region 删除盘点明细
        /// <summary>
        /// 删除盘点明细
        /// </summary>
        /// <param name="p_lngSEQ">序列</param>
        /// <returns></returns>
        internal long m_lngDeleteStorageCheckDetail(long p_lngSEQ)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC));
            lngRes = objSvc.m_lngDeleteStorageCheckDetail(objPrincipal, p_lngSEQ);
            return lngRes;
        }
        #endregion

        #region 获取盘点数量不为零的数据
        /// <summary>
        /// 获取盘点数量不为零的数据
        /// </summary>
        /// <param name="p_strCheckID">盘点ID</param>
        /// <param name="p_dtbResult">结果数据</param>
        /// <returns></returns>
        internal long m_lngGetCheckResult(string p_strCheckID, out DataTable p_dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC));
            lngRes = objSvc.m_lngGetCheckResult(objPrincipal, p_strCheckID, out p_dtbResult);
            return lngRes;
        }

        /// <summary>
        /// 获取盘点数量
        /// </summary>
        /// <param name="p_lngSEQ">明细表序列</param>
        /// <param name="p_dtbResult">结果数据</param>
        /// <returns></returns>
        internal long m_lngGetCheckResult(long p_lngSEQ, out DataTable p_dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC));
            lngRes = objSvc.m_lngGetCheckResult(objPrincipal, p_lngSEQ, out p_dtbResult);
            return lngRes;
        }
        #endregion

        #region 修改库存主表药品当前数量
        /// <summary>
        /// 修改库存主表药品当前数量
        /// </summary>
        /// <param name="p_strMedicineIDArr">药品ID</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <returns></returns>
        internal long m_lngUpdateStorageGross(string[] p_strMedicineIDArr, string p_strStorageID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC));
            lngRes = objSvc.m_lngUpdateStorageGross(objPrincipal, p_strMedicineIDArr, p_strStorageID);
            return lngRes;
        }
        #endregion

        #region 根据药品ID获取药品
        /// <summary>
        /// 根据药品ID获取药品
        /// </summary>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtbMedicine">药品数据</param>
        /// <returns></returns>
        internal long m_lngGetMedicineByMedicineID(string p_strMedicineID, string p_strStorageID, out DataTable p_dtbMedicine)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC));
            lngRes = objSvc.m_lngGetMedicineByMedicineID(objPrincipal, p_strMedicineID, p_strStorageID, out p_dtbMedicine);
            return lngRes;
        }
        #endregion

        #region 设置审核人及日期
        /// <summary>
        /// 设置审核人及日期
        /// </summary>
        /// <param name="p_strEmpID">审核人ID</param>
        /// <param name="p_lngSeq">审核记录的序列</param>
        /// <returns></returns>
        internal long m_lngSetCommitUser(string p_strEmpID, long p_lngSeq)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC));
            lngRes = objSvc.m_lngSetCommitUser(objPrincipal, p_strEmpID, p_lngSeq);
            return lngRes;
        }
        #endregion

        #region 取仓库名称
        /// <summary>
        /// 取仓库名称
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStoreRoomID"></param>
        /// <param name="p_strStoreRoomName"></param>
        /// <returns></returns>
        public long m_lngGetStoreRoomName(string p_strStoreRoomID, out string p_strStoreRoomName)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetStoreRoomName(objPrincipal, p_strStoreRoomID,out p_strStoreRoomName);
            return lngRes;
        }
        #endregion

        #region 获取打印行数设置
        /// <summary>
        /// 获取打印行数设置
        /// </summary>
        /// <param name="p_intCommitFolw">打印行数设置</param>
        /// <returns></returns>
        internal long m_lngGetPrinRow(out int p_intCommitFolw)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetSysSetting(objPrincipal, "5014", out p_intCommitFolw);
            return lngRes;
        }
        #endregion

        #region 保存盘点
        /// <summary>
        /// 保存盘点
        /// </summary>
        /// <param name="p_objMain">主表记录</param>
        /// <param name="p_objOldStDetial">旧的盘点药品库存信息</param>
        /// <param name="p_objModifyDetaiArr">修改过的盘点记录</param>
        /// <param name="p_objNewDetailArr">新增的盘点记录</param>
        /// <param name="p_objDefCheckDetail">盘亏药品</param>
        /// <param name="p_objSufCheckDetail">盘盈药品</param>
        /// <param name="p_objStDetail">盘点药品相关库存明细</param>
        /// <param name="p_strMedicineIDArr">盈亏药品ID</param>
        /// <param name="p_strEmpID">员工ID</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_blnIsAddNew">是否新增</param>
        /// <param name="p_blnIsCommit">是否保存即审核</param>
        /// <param name="p_lngNewSubSEQArr">新增盘点记录明细序列</param>
        /// <returns></returns>
        internal long m_lngSaveStorageCheck(ref clsMS_StorageCheck_VO p_objMain, clsMS_StorageDetail[] p_objOldStDetial, clsMS_StorageCheckDetail_VO[] p_objModifyDetaiArr, clsMS_StorageCheckDetail_VO[] p_objNewDetailArr, clsMS_StorageCheckDetail_VO[] p_objDefCheckDetail, clsMS_StorageCheckDetail_VO[] p_objSufCheckDetail,
            clsMS_StorageDetail[] p_objStDetail, string[] p_strMedicineIDArr, string p_strEmpID, string p_strStorageID, bool p_blnIsAddNew, bool p_blnIsCommit, out long[] p_lngNewSubSEQArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC));
            lngRes = objSvc.m_lngSaveStorageCheck(objPrincipal, ref p_objMain, p_objOldStDetial, p_objModifyDetaiArr, p_objNewDetailArr, p_objDefCheckDetail, p_objSufCheckDetail, p_objStDetail, p_strMedicineIDArr, p_strEmpID, p_strStorageID, p_blnIsAddNew,p_blnIsCommit, out p_lngNewSubSEQArr);
            return lngRes;
        } 
        #endregion


        #region 删除指定药品
        /// <summary>
        /// 删除指定药品
        /// </summary>
        /// <param name="p_objMedicneSt">药品库存信息</param>
        /// <param name="p_strCheckID">盘点ID</param>
        /// <param name="p_lngSubSEQ">盘点明细序列</param>
        /// <param name="p_blnIsCommit">是否保存即审核</param>
        /// <returns></returns>
        internal long m_lngDeleteStorageCheckMedicine(clsMS_StorageDetail p_objMedicneSt, string p_strCheckID, long p_lngSubSEQ, bool p_blnIsCommit)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC));
            lngRes = objSvc.m_lngDeleteStorageCheckMedicine(objPrincipal, p_objMedicneSt, p_strCheckID, p_lngSubSEQ, p_blnIsCommit);
            return lngRes;
        } 
        #endregion

        #region 获取盘点明细
        /// <summary>
        /// 获取盘点明细
        /// </summary>
        /// <returns></returns>
        internal long m_lngGetStorageCheck_detail(long p_lngMainSEQ, out DataTable p_dtbStorageCheck_detail)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageCheckSVC));
            lngRes = objSvc.m_lngGetStorageCheck_detail(objPrincipal, p_lngMainSEQ, out p_dtbStorageCheck_detail);
            return lngRes;
        } 
        #endregion

        
    }
}
