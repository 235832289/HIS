using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    /// <summary>
    /// 退药出库
    /// </summary>
    public class clsDcl_ForeignRetreatOutStorageDetail : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 获取当前退货次数
        /// <summary>
        /// 获取当前退货次数        /// </summary>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strLotNO">批号</param>
        /// <param name="p_strInStorageID">入库单据号</param>
        /// <param name="p_intReturnTimes">退货次数</param>
        /// <returns></returns>
        internal long m_lngGetCurrentReturnTimes(string p_strMedicineID, string p_strLotNO, string p_strInStorageID, out int p_intReturnTimes)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsForeignRetreatOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsForeignRetreatOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsForeignRetreatOutStorageSVC));
            lngRes = objSvc.m_lngGetCurrentReturnTimes(objPrincipal, p_strMedicineID, p_strLotNO, p_strInStorageID, out p_intReturnTimes);
            return lngRes;
        }
        #endregion

        #region 获取指定药品库存信息
        /// <summary>
        /// 获取指定药品库存信息
        /// </summary>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strVendorID">供应商ID</param>
        /// <param name="p_objDetailArr">库存信息</param>
        /// <returns></returns>
        internal long m_lngGetStorageMedicineDetail(string p_strMedicineID, string p_strStorageID,string p_strVendorID, out clsMS_StorageDetail[] p_objDetailArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsForeignRetreatOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsForeignRetreatOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsForeignRetreatOutStorageSVC));
            lngRes = objSvc.m_lngGetStorageMedicineDetail(objPrincipal, p_strMedicineID, p_strStorageID,p_strVendorID, out p_objDetailArr);
            return lngRes;
        }
        #endregion

        #region 获取指定药品可用库存总量
        /// <summary>
        /// 获取指定药品可用库存总量
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strVendorID">供应商ID</param>
        /// <param name="p_dblGross">可用库存总量</param>
        /// <returns></returns>
        internal long m_lngGetAvailaGross(string p_strStorageID, string p_strMedicineID,string p_strVendorID, out double p_dblGross)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsForeignRetreatOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsForeignRetreatOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsForeignRetreatOutStorageSVC));
            lngRes = objSvc.m_lngGetAvailaGross(objPrincipal, p_strStorageID, p_strMedicineID, p_strVendorID,out p_dblGross);
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
        internal long m_lngGetOutStorageDetailReport(long p_lngMainSEQ,int intType, out DataTable p_dtbValue)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC));
            lngRes = objSvc.m_lngGetOutStorageDetailReport(objPrincipal, p_lngMainSEQ,intType, out p_dtbValue,"");
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
        public long m_mthGetAccountperiodTime(out DateTime datAccountperiodTime)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_mthGetAccountperiodTime(objPrincipal, out datAccountperiodTime);
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

        #region 获取内退单报表类型

        /// <summary>
        /// 获取内退单报表类型

        /// </summary>
        internal long m_lngGetPrinType(out int p_intCommitFolw)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetSysSetting(objPrincipal, "5021", out p_intCommitFolw);
            return lngRes;
        }
        #endregion
    }
}
