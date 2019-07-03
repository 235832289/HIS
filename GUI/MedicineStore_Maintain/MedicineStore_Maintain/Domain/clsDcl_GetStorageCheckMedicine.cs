using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 获取盘点药品
    /// </summary> 
    public class clsDcl_GetStorageCheckMedicine : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 通过顺序号获取药品
        /// <summary>
        /// 通过顺序号获取药品
        /// </summary>
        /// <param name="p_strSortBegin">顺序号段开始号码</param>
        /// <param name="p_strSortEnd">顺序号段结束号码</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtbMedicine">药品数据</param>
        /// <returns></returns>
        internal long m_lngGetMedicineBySortNum(string p_strSortBegin, string p_strSortEnd, string p_strStorageID, out DataTable p_dtbMedicine)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsGetOrderCheckMedicineSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsGetOrderCheckMedicineSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsGetOrderCheckMedicineSVC));
            lngRes = objSvc.m_lngGetMedicineBySortNum(objPrincipal, p_strSortBegin, p_strSortEnd, p_strStorageID, out p_dtbMedicine);
            return lngRes;
        }
        #endregion

        #region 根据药品代码获取药品
        /// <summary>
        /// 根据药品代码获取药品
        /// </summary>
        /// <param name="p_strMedicineCodeBegin">药品代码段开始代码</param>
        /// <param name="p_strMedicineCodeEnd">药品代码段结束代码</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtbMedicine">药品数据</param>
        /// <returns></returns>
        internal long m_lngGetMedicineByMedicineCode(string p_strMedicineCodeBegin, string p_strMedicineCodeEnd, string p_strStorageID, out DataTable p_dtbMedicine)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsGetOrderCheckMedicineSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsGetOrderCheckMedicineSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsGetOrderCheckMedicineSVC));
            lngRes = objSvc.m_lngGetMedicineByMedicineCode(objPrincipal, p_strMedicineCodeBegin, p_strMedicineCodeEnd, p_strStorageID, out p_dtbMedicine);
            return lngRes;
        }
        #endregion

        #region 根据药品剂型获取药品
        /// <summary>
        /// 根据药品剂型获取药品
        /// </summary>
        /// <param name="p_strMedicinePreptypeID">药品剂型ID</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtbMedicine">药品数据</param>
        /// <returns></returns>
        internal long m_lngGetMedicineByMedicinePreptype(string p_strMedicinePreptypeID, string p_strStorageID, out DataTable p_dtbMedicine)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsGetOrderCheckMedicineSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsGetOrderCheckMedicineSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsGetOrderCheckMedicineSVC));
            lngRes = objSvc.m_lngGetMedicineByMedicinePreptype(objPrincipal, p_strMedicinePreptypeID.Trim(), p_strStorageID, out p_dtbMedicine);
            return lngRes;
        }
        #endregion

        #region 根据药品类型获取药品
        /// <summary>
        /// 根据药品类型获取药品
        /// </summary>
        /// <param name="p_strMedicineTypeID">药品类型ID</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtbMedicine">药品数据</param>
        /// <returns></returns>
        internal long m_lngGetMedicineByMedicineType(string p_strMedicineTypeID, string p_strStorageID, out DataTable p_dtbMedicine)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsGetOrderCheckMedicineSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsGetOrderCheckMedicineSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsGetOrderCheckMedicineSVC));
            lngRes = objSvc.m_lngGetMedicineByMedicineType(objPrincipal, p_strMedicineTypeID, p_strStorageID, out p_dtbMedicine);
            return lngRes;
        }
        #endregion

        #region 根据货架号获取药品信息
        /// <summary>
        /// 根据货架号获取药品信息
        /// </summary>
        /// <param name="p_strRackNOBegin">货架号码段开始号码</param>
        /// <param name="p_strRackNOEnd">货架号码段结束号码</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtbMedicine">药品数据</param>
        /// <returns></returns>
        internal long m_lngGetMedicineByMedicineRackNO(string p_strRackNOBegin, string p_strRackNOEnd, string p_strStorageID, out DataTable p_dtbMedicine)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsGetOrderCheckMedicineSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsGetOrderCheckMedicineSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsGetOrderCheckMedicineSVC));
            lngRes = objSvc.m_lngGetMedicineByMedicineRackNO(objPrincipal, p_strRackNOBegin, p_strRackNOEnd, p_strStorageID, out p_dtbMedicine);
            return lngRes;
        }
        #endregion

        #region 获取全部药品
        /// <summary>
        /// 获取全部药品
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtbMedicine">药品数据</param>
        /// <returns></returns>
        internal long m_lngGetAllMedicine(string p_strStorageID, out DataTable p_dtbMedicine)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsGetOrderCheckMedicineSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsGetOrderCheckMedicineSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsGetOrderCheckMedicineSVC));
            lngRes = objSvc.m_lngGetAllMedicine(objPrincipal, p_strStorageID, out p_dtbMedicine);
            return lngRes;
        }
        #endregion

        #region 获取药品制剂类型
        /// <summary>
        /// 获取药品制剂类型
        /// </summary>
        /// <param name="p_objMPVO">药品制剂类型</param>
        /// <returns></returns>
        internal long m_lngGetMedicinePreptype(out clsMEDICINEPREPTYPE_VO[] p_objMPVO)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetMedicinePreptype(objPrincipal, out p_objMPVO);
            return lngRes;
        }
        #endregion
    }
}
