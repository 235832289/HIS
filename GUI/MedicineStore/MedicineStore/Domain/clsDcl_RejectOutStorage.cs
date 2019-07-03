using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Data;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    /// <summary>
    /// 报废出库
    /// </summary>
    public class clsDcl_RejectOutStorage : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 获取所有报废原因
        /// <summary>
        /// 获取所有报废原因
        /// </summary>
        /// <param name="p_objReasons">报废原因</param>
        /// <returns></returns>
        internal long m_lngGetAllRejectReason(out clsMS_RejectReason[] p_objReasons)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsRejectOutStorageSVC objSvc = (com.digitalwave.iCare.middletier.MedicineStoreService.clsRejectOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsRejectOutStorageSVC));
            lngRes = objSvc.m_lngGetAllRejectReason(objPrincipal, out p_objReasons);
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

        #region 获取报废药品信息（打印）

        /// <summary>
        /// 获取报废药品信息（打印）
        /// </summary>
        internal long m_lngGetRejectPrint(long lngSeriesid, out DataTable p_dtbReject)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsRejectOutStorageSVC objSvc = (com.digitalwave.iCare.middletier.MedicineStoreService.clsRejectOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsRejectOutStorageSVC));
            lngRes = objSvc.m_lngGetRejectPrint(objPrincipal,lngSeriesid, out p_dtbReject);
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

    }
}
