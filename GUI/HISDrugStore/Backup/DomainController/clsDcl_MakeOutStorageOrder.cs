using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Data;
using System.Collections;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 出库域控制类
    /// </summary>
    public class clsDcl_MakeOutStorageOrder : com.digitalwave.GUI_Base.clsDomainController_Base
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
            lngRes = objSvc.m_lngAddNewStorageDetail(objPrincipal,p_objSDVOArr);
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
            lngRes = objSvc.m_lngModifyStorageFromInitial(objPrincipal, p_objRecord, p_lngSEQ);
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
        internal long m_lngCheckHasStorage(string p_strMedicineID, string p_strStorageID, out bool p_blnHasDetail, out long p_lngSeriesID)
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
            lngRes = objSvc.m_lngDeleteStorageDetail(objPrincipal, p_strInStorageIDArr, storageid_chr);
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
            lngRes = objSvc.m_lngAddStorageDetailAvailaGross(objPrincipal, p_dblAvailaGross, p_strMedicineID, p_strLotNO, p_strInStorageID, p_dtmValidDate, p_dblInPrice, p_strStorageID);
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
            lngRes = objSvc.m_lngSubStorageDetailAvailaGross(objPrincipal, p_dblAvailaGross, p_strMedicineID, p_strLotNO, p_strInStorageID, p_dblInPrice, p_dtmValidDate, p_strStorageID);
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
        #region 添加新的药品出库(主表)
        /// <summary>
        /// 添加新的药品出库(主表)
        /// </summary>
        /// <param name="p_objMain">主表内容</param>
        /// <returns></returns>
        internal long m_lngAddNewOutStorage(ref clsMS_OutStorage_VO p_objMain)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC));
            lngRes = objSvc.m_lngAddNewOutStorage(objPrincipal, ref p_objMain);
            return lngRes;
        }
        #endregion

        #region  添加新的药品出库(明细表)
        /// <summary>
        ///  添加新的药品出库(明细表)
        /// </summary>
        /// <param name="p_objDetailArr">明细表内容</param>
        /// <returns></returns>
        internal long m_lngAddNewOutStorageDetail(ref clsMS_OutStorageDetail_VO[] p_objDetailArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC));
            lngRes = objSvc.m_lngAddNewOutStorageDetail(objPrincipal, ref p_objDetailArr);
            return lngRes;
        }
        #endregion

        #region  修改药品出库信息(主表)
        /// <summary>
        ///  修改药品出库信息(主表)
        /// </summary>
        /// <param name="p_objMain">主表内容</param>
        /// <returns></returns>
        internal long m_lngModifyOutStorage(clsMS_OutStorage_VO p_objMain)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC));
            lngRes = objSvc.m_lngModifyOutStorage(objPrincipal, p_objMain);
            return lngRes;
        }
        #endregion

        #region  修改药品出库(明细表)
        /// <summary>
        ///  修改药品出库(明细表)
        /// </summary>
        /// <param name="p_objDetailArr">明细表内容</param>
        /// <returns></returns>
        internal long m_lngModifyOutStorageDetail(clsMS_OutStorageDetail_VO[] p_objDetailArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC));
            lngRes = objSvc.m_lngModifyOutStorageDetail(objPrincipal, p_objDetailArr);
            return lngRes;
        }
        #endregion

        #region  删除出库明细
        /// <summary>
        ///  删除本次出库单出库明细


        /// </summary>
        /// <param name="p_intStatus">状态</param>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <returns></returns>
        internal long m_lngDeleteOutStorageDetail(int p_intStatus, long p_lngMainSEQ)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC));
            lngRes = objSvc.m_lngUpdateStorageDetailStatusByMainSEQ(objPrincipal, p_intStatus, p_lngMainSEQ);
            return lngRes;
        }

        /// <summary>
        ///  删除指定出库明细
        /// </summary>
        /// <param name="p_intStatus">状态</param>
        /// <param name="p_lngSEQ">序列</param>
        /// <returns></returns>
        internal long m_lngDeleteSpecOutStorageDetail(int p_intStatus, long p_lngSEQ)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC));
            lngRes = objSvc.m_lngUpdateStorageDetailStatus(objPrincipal, p_intStatus, p_lngSEQ);
            return lngRes;
        }
        #endregion

        #region 获取出库子表实发数量
        /// <summary>
        /// 获取出库子表实发数量
        /// </summary>
        /// <param name="p_lngSEQ">序列</param>
        /// <param name="p_dblAmount">实发数量</param>
        /// <returns></returns>
        internal long m_lngGetOutStorageDetailGross(long p_lngSEQ, out double p_dblAmount)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC));
            lngRes = objSvc.m_lngGetOutStorageDetailGross(objPrincipal, p_lngSEQ, out p_dblAmount);
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
        internal long m_lngGetNetAmount(long p_lngMainSEQ, string p_strMedicineID, out Hashtable p_hstNetAmount)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC));
            lngRes = objSvc.m_lngGetNetAmount(objPrincipal, p_lngMainSEQ, p_strMedicineID, out p_hstNetAmount);
            return lngRes;
        }
        #endregion

        #region 获取指定出库单各药品的总库存


        /// <summary>
        /// 获取指定出库单各药品的总库存


        /// </summary>
        /// <param name="p_lngMainSEQ">出库主表序列</param>
        /// <param name="p_objGross">各药品的总库存</param>
        /// <returns></returns>
        internal long m_lngGetMedicineAllGross(long p_lngMainSEQ, out clsMS_MedicineGross[] p_objGross)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC));
            lngRes = objSvc.m_lngGetMedicineAllGross(objPrincipal, p_lngMainSEQ, out p_objGross);
            return lngRes;
        }
        #endregion


        #region 获取子表内容(报表打印)
        /// <summary>
        /// 获取子表内容(报表打印)
        /// </summary>
        /// <param name="p_lngMainSEQ">主表序列号</param>
        /// <param name="p_dtbValue">子表内容</param>
        /// <returns></returns>
        internal long m_lngGetOutStorageDetailReport(long p_lngMainSEQ, int intType, out DataTable p_dtbValue)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC));
            lngRes = objSvc.m_lngGetOutStorageDetailReport(objPrincipal, p_lngMainSEQ, intType, out p_dtbValue,"");
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

        #region 保存出库记录
        /// <summary>
        /// 保存出库记录
        /// </summary>
        /// <param name="p_objMain">出库主表内容</param>
        /// <param name="p_objOldDetailArr">旧出库明细</param>
        /// <param name="p_objNewDetailArr">新出库明细</param>
        /// <param name="p_blnIsCommit">是否保存即审核</param>
        /// <param name="p_lngIsAddNew">是否新添记录</param>
        /// <param name="p_blnIsImmAccount">是否审核即入帐</param>
        /// <returns></returns>
        internal long m_lngSaveOutStorageByStorage(ref clsMS_OutStorage_VO p_objMain, clsMS_OutStorageDetail_VO[] p_objOldDetailArr, ref clsMS_OutStorageDetail_VO[] p_objNewDetailArr,
            bool p_blnIsCommit, bool p_lngIsAddNew, bool p_blnIsImmAccount)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC));
            lngRes = objSvc.m_lngSaveOutStorageByStorage(objPrincipal, ref p_objMain, p_objOldDetailArr, ref p_objNewDetailArr, p_blnIsCommit, p_lngIsAddNew, p_blnIsImmAccount);
            return lngRes;
        }
        #endregion

        #region 获取出库单报表类型



        /// <summary>
        /// 获取出库单报表类型
        /// </summary>
        internal long m_lngGetPrinType(out int p_intCommitFolw)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetSysSetting(objPrincipal, "5015", out p_intCommitFolw);
            return lngRes;
        }
        #endregion

        #region 删除指定出库药品
        /// <summary>
        /// 删除指定出库药品
        /// </summary>
        /// <param name="p_lngSeq">药品序列</param>
        /// <param name="p_strOutStorageID">出库单据号</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strLotNO">批号</param>
        /// <param name="p_strInStroageID">入库单据号</param>
        /// <param name="p_dtmValidDate">有效期</param>
        /// <param name="p_dblInPrice">购入价</param>
        /// <param name="p_blnIsCommit">是否保存即审核</param>
        /// <param name="p_objStMed">库存药品信息</param>
        /// <param name="p_dblOutGross">此药品出库数量</param>
        /// <returns></returns>
        internal long m_lngDeleteSelectedMedicine(long p_lngSeq, string p_strOutStorageID, string p_strStorageID, string p_strMedicineID, string p_strLotNO, string p_strInStroageID, DateTime p_dtmValidDate, double p_dblInPrice, bool p_blnIsCommit, clsMS_Storage p_objStMed, double p_dblOutGross)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC));
            lngRes = objSvc.m_lngDeleteSelectedMedicine(objPrincipal, p_lngSeq, p_strOutStorageID, p_strStorageID, p_strMedicineID, p_strLotNO, p_strInStroageID, p_dtmValidDate, p_dblInPrice, p_blnIsCommit, p_objStMed, p_dblOutGross);
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

        #region  获取最后帐务结转的结束日期
        /// <summary>
        ///  获取最后帐务结转的结束日期
        /// </summary>
        /// <returns></returns>
        public long m_mthGetAccountperiodTime(string p_strStorageID,out DateTime datAccountperiodTime)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_mthGetAccountperiodTime(objPrincipal,p_strStorageID, out datAccountperiodTime);
            return lngRes;
        }
        #endregion

        #region 获取药品是否已调价
        /// <summary>
        /// 获取药品是否已调价
        /// </summary>
        /// <param name="medicineid_chr">药品ID</param>
        /// <param name="lotno_vchr">批号</param>
        /// <param name="instorageid_vchr">入库单号</param>
        /// <param name="p_dtmValiDate">有效期</param>
        /// <param name="p_dblInPrice">购入价</param>
        /// <param name="p_dblAdjustrice">是否已调价</param>
        /// <returns></returns>
        public long m_mthGetAdjustrice(string medicineid_chr, string lotno_vchr, string instorageid_vchr, DateTime p_dtmValiDate, double p_dblInPrice, DateTime datNewdate, out bool p_dblAdjustrice)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_mthGetAdjustrice(objPrincipal, medicineid_chr, lotno_vchr, instorageid_vchr, p_dtmValiDate, p_dblInPrice, datNewdate, out p_dblAdjustrice);
            return lngRes;
        }
        #endregion
        #region 根据药库主表流水号获取明细表信息
        /// <summary>
        /// 根据药库主表流水号获取明细表信息
        /// </summary>
        /// <param name="p_blnIsHospital">是否住院单位</param>
        /// <param name="p_lngSeqid"></param>
        /// <param name="p_dtOutStorageDetail"></param>
        /// <returns></returns>
        public long m_lngGetOutStorageDetailInfoByid(bool p_blnIsHospital,long p_lngSeqid, out DataTable p_dtOutStorageDetail)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC));
            lngRes = objSvc.m_lngGetOutStorageDetailInfoByid(objPrincipal, p_blnIsHospital,p_lngSeqid, out p_dtOutStorageDetail);
            return lngRes;
        }
        #endregion

        /// <summary>
        /// 根据主表流水号获取明细表信息
        /// </summary>
        /// <param name="p_blnIsHospital">是否住院单位</param>
        /// <param name="p_lngSeqid">主表流水号息</param>
        /// <param name="p_dtAskDetail">明细表信息</param>
        /// <returns></returns>
        internal long m_lngGetAskDetailInfoByid(bool p_blnIsHospital, long p_lngSeqid, out DataTable p_dtAskDetail)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC));
            lngRes = objSvc.m_lngGetAskDetailInfoByid(objPrincipal, p_blnIsHospital,p_lngSeqid, out p_dtAskDetail);
            return lngRes;
        }

        /// <summary>
        /// 获取指定药品库存信息
        /// </summary>
        /// <param name="m_strMedicineID">药品ID</param>
        /// <param name="m_strStorageID">ID</param>
        /// <param name="m_strMedSpec">药品规格</param>
        /// <param name="objDetail">库存信息</param>
        /// <returns></returns>
        internal long m_lngGetStorageMedicineDetailInfo(string p_strMedicineID, string p_strStorageID, out clsMS_StorageDetail[] p_objDetailArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC));
            lngRes = objSvc.m_lngGetStorageMedicineDetailInfo(objPrincipal, p_strMedicineID, p_strStorageID, out p_objDetailArr);
            return lngRes;
        }

        /// <summary>
        /// 更新请领单明细表的足量状态
        /// </summary>
        /// <param name="p_lngSeriesID">主表序列</param>
        /// <param name="p_hstUpdateEnough">药品号和“+=”标识</param>
        /// <returns></returns>
        internal long m_lngUpdateEnoughState(long p_lngSeriesID,Hashtable p_hstUpdateEnough)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC));
            lngRes = objSvc.m_lngUpdateEnoughState(objPrincipal, p_lngSeriesID,p_hstUpdateEnough);
            return lngRes;
        }

        #region 根据类型名称获取出入库类型ID
        /// <summary>
        /// 根据类型名称获取出入库类型ID
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_intFlag">0-入库；1-出库</param>
        /// <param name="p_strTypeName">类型名称</param>
        /// <param name="p_intTypeCode">类型ID</param>
        /// <returns></returns>
        internal long m_lngGetTypeCodeByName(int p_intFlag,string p_strTypeName, out int p_intTypeCode)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC));
            lngRes = objSvc.m_lngGetTypeCodeByName(objPrincipal, p_intFlag,p_strTypeName, out p_intTypeCode);
            return lngRes;
        }
        #endregion

        /// <summary>
        /// 获取请领单状态是否“提交”
        /// </summary>
        /// <param name="p_strAskID"></param>
        /// <returns></returns>
        public long m_lngCheckStatus(string p_strAskID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC));
            lngRes = objSvc.m_lngCheckStatus(objPrincipal, p_strAskID);
            return lngRes;
        }

        #region 查询该药库当前该药品总数
        /// <summary>
        /// 查询该药库当前该药品总数
        /// </summary>
        /// <param name="p_strStorageID"></param>
        /// <param name="p_strMedicineID"></param>
        /// <param name="p_dblGross"></param>
        /// <returns></returns>
        internal long m_lngGetAllRealGross(string p_strStorageID, string p_strMedicineID, out double p_dblGross)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngGetAllRealGross(objPrincipal, p_strStorageID, p_strMedicineID, out p_dblGross);
            return lngRes;
        }
        #endregion
    }
}
