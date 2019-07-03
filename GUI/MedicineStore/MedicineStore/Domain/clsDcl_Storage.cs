using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Data;
using com.digitalwave.iCare.middletier.common;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    /// <summary>
    /// 库存
    /// </summary>
    public class clsDcl_Storage : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 添加库存明细
        /// <summary>
        /// 添加库存明细
        /// </summary>
        /// <param name="p_objSDVOArr">库存明细</param>
        /// <returns></returns>
        internal long m_lngAddNewStorageDetail(clsMS_StorageDetail[] p_objSDVOArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngAddNewStorageDetail(objPrincipal, p_objSDVOArr);
            return lngRes;
        }
        #endregion

        #region 添加库存主表
        /// <summary>
        /// 添加库存主表
        /// </summary>
        /// <param name="p_objSDVOArr">库存</param>
        /// <returns></returns>
        internal long m_lngAddNewStorage(clsMS_Storage[] p_objSDVOArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngAddNewStorage(objPrincipal, p_objSDVOArr);
            return lngRes;
        }
        /// <summary>
        /// 添加库存主表
        /// </summary>
        /// <param name="p_objSDVO">库存</param>
        /// <returns></returns>
        internal long m_lngAddNewStorage(ref clsMS_Storage p_objSDVO)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngAddNewStorage(objPrincipal, ref p_objSDVO);
            return lngRes;
        }
        #endregion

        #region 传递数据，修改库存主表信息
        /// <summary>
        /// 传递数据，修改库存主表信息
        /// </summary>
        /// <param name="p_objRecord"></param>
        /// <param name="p_lngSEQ"></param>
        /// <returns></returns>
        internal long m_lngModifyStorageFromInitial(clsMS_Storage p_objRecord, long p_lngSEQ)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngModifyStorageFromInitial(objPrincipal, p_objRecord,p_lngSEQ);
            return lngRes;
        }
        #endregion

        #region 退审后更新库存信息
        /// <summary>
        /// 退审后更新库存信息
        /// </summary>
        /// <param name="p_objRecord"></param>
        /// <param name="p_lngSEQ"></param>
        /// <returns></returns>
        internal long m_lngModifyStorageFromUnCommit(clsMS_Storage p_objRecord, long p_lngSEQ)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngModifyStorageFromUnCommit(objPrincipal, p_objRecord, p_lngSEQ);
            return lngRes;
        }
        #endregion

        #region 传递数据，修改库存主表信息
        /// <summary>
        /// 统计库存
        /// </summary>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <returns></returns>
        internal long m_lngStatisticsStorage(string p_strMedicineID, string p_strStorageID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngStatisticsStorage(objPrincipal, p_strMedicineID, p_strStorageID);
            return lngRes;
        }
        #endregion

        #region 检查库存主表是否已存在该药
        /// <summary>
        /// 检查库存主表是否已存在该药
        /// </summary>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_blnHasDetail">是否存在</param>
        /// <param name="p_lngSeriesID">如存在，返回序列号</param>
        /// <returns></returns>
        internal long m_lngCheckHasStorage(string p_strMedicineID,string p_strStorageID, out bool p_blnHasDetail, out long p_lngSeriesID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngCheckHasStorage(objPrincipal, p_strMedicineID, p_strStorageID, out p_blnHasDetail, out p_lngSeriesID);
            return lngRes;
        }
        #endregion

        #region 删除指定入库单号的库存明细

        /// <summary>
        /// 删除指定入库单号的库存明细

        /// </summary>
        /// <param name="p_strInStorageID">入库单号</param>
        /// <param name="p_dtmInStorageDate">入库日期</param>
        /// <returns></returns>
        internal long m_lngDeleteStorageDetail(string p_strInStorageID, DateTime p_dtmInStorageDate)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngDeleteStorageDetail(objPrincipal, p_strInStorageID, p_dtmInStorageDate);
            return lngRes;
        }

        /// <summary>
        /// 删除指定入库单号的库存明细

        /// </summary>
        /// <param name="p_strInStorageIDArr">入库单号</param>
        /// <returns></returns>
        internal long m_lngDeleteStorageDetail(string[] p_strInStorageIDArr, string storageid_chr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngDeleteStorageDetail(objPrincipal, p_strInStorageIDArr,storageid_chr);
            return lngRes;
        }
        #endregion

        #region 删除指定入库单号的库存明细

        /// <summary>
        /// 删除指定入库单号的库存明细

        /// </summary>
        /// <param name="p_strInStorageID">入库单号</param>
        /// <returns></returns>
        internal long m_lngDeleteStorageDetail(long p_lngSEQ)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngDeleteStorageDetail(objPrincipal, p_lngSEQ);
            return lngRes;
        }

        /// <summary>
        /// 删除指定入库单号的库存明细

        /// </summary>
        /// <param name="p_lngSEQArr">入库单号</param>
        /// <returns></returns>
        internal long m_lngDeleteStorageDetail(long[] p_lngSEQArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngDeleteStorageDetail(objPrincipal, p_lngSEQArr);
            return lngRes;
        }
        #endregion

        #region 根据药品信息获取库存明细序列号

        /// <summary>
        /// 根据药品信息获取库存明细序列号

        /// </summary>
        /// <param name="p_strInStorageID">入库单号</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strLotNO">药品批号</param>
        /// <param name="p_dtmValidDate">有效期</param>
        /// <param name="p_dblInPrice">购入价</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_lngSEQ">库存明细序列号</param>
        /// <param name="p_dblRealgross">实际库存</param>
        /// <param name="p_dblAvailagross">可用库存</param>
        /// <returns></returns>
        internal long m_lngGetDetailSEQByIndex(string p_strInStorageID, string p_strMedicineID, string p_strLotNO, DateTime p_dtmValidDate, double p_dblInPrice, string p_strStorageID, out long p_lngSEQ,
            out double p_dblRealgross, out double p_dblAvailagross)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngGetDetailSEQByIndex(objPrincipal, p_strInStorageID, p_strMedicineID, p_strLotNO, p_dtmValidDate, p_dblInPrice, p_strStorageID, out p_lngSEQ, out p_dblRealgross, out p_dblAvailagross);
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
        internal long m_lngGetStorageMedicineDetail(string p_strMedicineID, string p_strStorageID, out clsMS_StorageDetail[] p_objDetailArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngGetStorageMedicineDetail(objPrincipal, p_strMedicineID, p_strStorageID, out p_objDetailArr);
            return lngRes;
        } 
        #endregion

        #region 添加库存明细表库存数量

        /// <summary>
        /// 添加库存明细表库存数量

        /// </summary>
        /// <param name="p_dblRealGross">实际库存</param>
        /// <param name="p_dblAvailaGross">可用库存</param>
        /// <param name="p_lngSEQ">序列</param>
        /// <returns></returns>
        internal long m_lngAddStorageDetailGross(double p_dblRealGross, double p_dblAvailaGross, long p_lngSEQ)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngAddStorageDetailGross(objPrincipal, p_dblRealGross, p_dblAvailaGross, p_lngSEQ);
            return lngRes;
        }

        /// <summary>
        /// 添加库存明细表库存数量(可用库存)
        /// </summary>
        /// <param name="p_objOutArr">更改库存VO</param>
        /// <returns></returns>
        internal long m_lngAddStorageDetailAvailaGross(clsMS_StorageGrossForOut[] p_objOutArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngAddStorageDetailAvailaGross(objPrincipal, p_objOutArr);
            return lngRes;
        }

        /// <summary>
        /// 添加库存明细表库存数量(实际库存)
        /// </summary>
        /// <param name="p_objOutArr">更改库存VO</param>
        /// <returns></returns>
        internal long m_lngAddStorageDetailRealGross(clsMS_StorageGrossForOut[] p_objOutArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngAddStorageDetailRealGross(objPrincipal, p_objOutArr);
            return lngRes;
        }

        /// <summary>
        ///  添加库存明细表库存数量(出库删除未审核记录时只添加可用库存)
        /// </summary>
        /// <param name="p_dblAvailaGross">可用库存</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strLotNO">药品批号</param>
        /// <param name="p_strInStorageID">入库单据号</param>
        /// <param name="p_dtmValidDate">有效期</param>
        /// <param name="p_dblInPrice">购入价</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <returns></returns>
        internal long m_lngAddStorageDetailAvailaGross(double p_dblAvailaGross, string p_strMedicineID, string p_strLotNO, string p_strInStorageID, DateTime p_dtmValidDate, double p_dblInPrice, string p_strStorageID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngAddStorageDetailAvailaGross(objPrincipal, p_dblAvailaGross, p_strMedicineID, p_strLotNO, p_strInStorageID,p_dtmValidDate,p_dblInPrice, p_strStorageID);
            return lngRes;
        }
        #endregion

        #region 减少库存明细表库存数量

        /// <summary>
        /// 减少库存明细表库存数量

        /// </summary>
        /// <param name="p_dblRealGross">实际库存</param>
        /// <param name="p_dblAvailaGross">可用库存</param>
        /// <param name="p_lngSEQ">序列</param>
        /// <returns></returns>
        internal long m_lngSubStorageDetailGross(double p_dblRealGross, double p_dblAvailaGross, long p_lngSEQ)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngSubStorageDetailGross(objPrincipal, p_dblRealGross, p_dblAvailaGross, p_lngSEQ);
            return lngRes;
        }

        /// <summary>
        /// 减少库存明细表库存数量

        /// </summary>
        /// <param name="p_objDetail">库存明细表内容</param>
        /// <returns></returns>
        internal long m_lngSubStorageDetailGross(clsMS_StorageDetail[] p_objDetail)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngSubStorageDetailGross(objPrincipal, p_objDetail);
            return lngRes;
        }

        /// <summary>
        /// 减少库存明细表库存数量(实际库存)
        /// </summary>
        /// <param name="p_objDetail">库存表内容</param>
        /// <returns></returns>
        internal long m_lngSubStorageDetailRealGross(clsMS_StorageGrossForOut[] p_objDetail)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngSubStorageDetailRealGross(objPrincipal, p_objDetail);
            return lngRes;
        }

        /// <summary>
        /// 减少库存明细表库存数量(保存出库时只对可用库存作修改)
        /// </summary>
        /// <param name="p_objDetail">库存明细表内容</param>
        /// <returns></returns>
        internal long m_lngSubStorageDetailAvailaGross(clsMS_StorageDetail[] p_objDetail)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngSubStorageDetailAvailaGross(objPrincipal, p_objDetail);
            return lngRes;
        }
        
        /// <summary>
        ///  减少库存明细表库存数量

        /// </summary>
        /// <param name="p_dblAvailaGross">可用库存</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strLotNO">药品批号</param>
        /// <param name="p_strInStorageID">入库单据号</param>
        /// <param name="p_dblInPrice">购入单价</param>
        /// <param name="p_dtmValidDate">有效期</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <returns></returns>
        internal long m_lngSubStorageDetailAvailaGross(double p_dblAvailaGross, string p_strMedicineID, string p_strLotNO,
            string p_strInStorageID, double p_dblInPrice, DateTime p_dtmValidDate, string p_strStorageID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngSubStorageDetailAvailaGross(objPrincipal, p_dblAvailaGross, p_strMedicineID, p_strLotNO, p_strInStorageID,p_dblInPrice,p_dtmValidDate, p_strStorageID);
            return lngRes;
        }
        #endregion

        #region 减少库存主表库存数量
        /// <summary>
        /// 减少库存主表库存数量
        /// </summary>
        /// <param name="p_objMain">库存主表内容</param>
        /// <returns></returns>
        internal long m_lngSubStorageGross(clsMS_Storage p_objMain)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngSubStorageGross(objPrincipal, p_objMain);
            return lngRes;
        } 
        #endregion

        #region 获取指定药品可用库存总量
        /// <summary>
        /// 获取指定药品可用库存总量
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_dblGross">可用库存总量</param>
        /// <returns></returns>
        internal long m_lngGetAvailaGross(string p_strStorageID, string p_strMedicineID, out double p_dblGross)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngGetAvailaGross(objPrincipal, p_strStorageID, p_strMedicineID, out p_dblGross);
            return lngRes;
        }
        #endregion

        #region 库存主表添加当前库存
        /// <summary>
        /// 库存主表添加当前库存
        /// </summary>
        /// <param name="p_objRecord">库存</param>
        /// <returns></returns>
        internal long m_lngAddStorageGross(clsMS_StorageGrossForOut p_objRecord)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngAddStorageGross(objPrincipal, p_objRecord);
            return lngRes;
        }
        #endregion

        #region 库存主表减少当前库存
        /// <summary>
        /// 库存主表减少当前库存
        /// </summary>
        /// <param name="p_objRecord">库存</param>
        /// <returns></returns>
        internal long m_lngSubStorageGross(clsMS_StorageGrossForOut p_objRecord)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngSubStorageGross(objPrincipal, p_objRecord);
            return lngRes;
        }
        #endregion
    }
}
