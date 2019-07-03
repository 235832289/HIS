using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Data;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 药房库存域控制类
    /// </summary>
    public class clsDcl_DrugStorageQuery : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 查询仓库信息
        /// <summary>
        /// 查询仓库信息
        /// </summary>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        public long m_lngGetResultByConditionStorageBse(out clsValue_StorageBse_VO[] p_objResultArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC));

            lngRes = objSvc.m_lngGetStorageBseData(objPrincipal, out p_objResultArr);
            return lngRes;
        }
        #endregion

        #region 获取药品类型
        /// <summary>
        /// 获取药品类型
        /// </summary>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        public long m_lngGetResultByConditionMedicineType(out clsValue_MedicineType_VO[] p_objResultArr)
        {
            long lngRes = 0;

            com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC));

            lngRes = objSvc.m_lngGetMedicineTypeData(objPrincipal, out p_objResultArr);
            return lngRes;
        }
        #endregion

        #region 查询库存明细信息
        /// <summary>
        /// 查询库存明细信息
        /// </summary>
        /// <param name="objvalue_Param"></param>
        /// <param name="lstMedicineType"></param>
        /// <param name="dtbResult"></param>
        /// <param name="p_strProductor"></param>
        /// <param name="p_objPrepTypeArr"></param>
        /// <returns></returns>
        public long m_lngGetResultByConditionStorageDetail(ref clsStorageDetail_SqlConditionQueryParam_VO objvalue_Param, List<string> lstMedicineType, ref DataTable dtbResult, string p_strProductor, clsMEDICINEPREPTYPE_VO[] p_objPrepTypeArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC));

            lngRes = objSvc.m_lngGetStorageDetailData(objPrincipal, ref objvalue_Param, lstMedicineType, ref dtbResult, p_strProductor, p_objPrepTypeArr);
            return lngRes;
        }
        #endregion

        #region 根据药房名称获取货架信息
        /// <summary>
        /// 根据药房名称获取货架信息
        /// </summary>
        /// <param name="p_strStoreName">药房名称</param>
        /// <param name="m_dtbStorageRack">货架信息</param>
        /// <returns></returns>
        internal long m_lngGetStorageRack(string p_strStoreName, out DataTable m_dtbStorageRack)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC));

            lngRes = objSvc.m_lngGetStorageRack(objPrincipal, p_strStoreName, out m_dtbStorageRack);
            return lngRes;
        }
        #endregion

        #region 保存货架设置
        /// <summary>
        /// 保存货架设置
        /// </summary>
        /// <param name="p_dicStorageRack">需要保存货架信息的记录</param>
        /// <returns></returns>
        internal long m_lngSaveStorageRack(Dictionary<string, string> p_dicStorageRack)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_SVC));

            lngRes = objSvc.m_lngSaveStorageRack(objPrincipal, p_dicStorageRack);
            return lngRes;
        }
        #endregion

        internal long m_lngSaveProvide(DataTable m_dtbModify)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_SVC));

            lngRes = objSvc.m_lngSaveProvide(objPrincipal, m_dtbModify);
            return lngRes;
        }

        /// <summary>
        /// 检查是否住院药房使用
        /// </summary>
        /// <param name="p_strDrugStoreID"></param>
        /// <param name="p_blnIsHospital"></param>
        /// <returns></returns>
        internal long m_lngCheckIsHospital(string p_strDrugStoreID, out bool p_blnIsHospital)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC));

            lngRes = objSvc.m_lngCheckIsHospital(objPrincipal, p_strDrugStoreID, out p_blnIsHospital);
            return lngRes;
        }

        /// <summary>
        /// 根据ID获取库存明细表的资料
        /// </summary>
        /// <param name="p_intSeriesID"></param>
        /// <param name="objHistory"></param>
        /// <returns></returns>
        internal long m_lngGetAmountBySeriesID(long p_intSeriesID, out clsDS_StorageHistory_VO p_objHistory)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_Supported_SVC));

            lngRes = objSvc.m_lngGetAmountBySeriesID(objPrincipal, p_intSeriesID, out p_objHistory);
            return lngRes;
        }

        /// <summary>
        /// 保存库存明细和修改记录
        /// </summary>
        /// <param name="objHistory"></param>
        /// <returns></returns>
        internal long m_lngSaveAmount(clsDS_StorageHistory_VO objHistory)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStorageQuery_SVC));

            lngRes = objSvc.m_lngSaveAmount(objPrincipal, objHistory);
            return lngRes;
        }

        /// <summary>
        /// 根据药房ID取得剂型
        /// </summary>
        /// <param name="p_strDrugStoreID"></param>
        /// <param name="objMPVO"></param>
        internal void m_mthShowMedicinePreptype(string p_strDrugStoreID,out clsMEDICINEPREPTYPE_VO[] objMPVO)
        {
            clsDcl_GetStoreCheckMedicine objDom = new clsDcl_GetStoreCheckMedicine();
            objDom.m_lngGetMedicinePreptype(p_strDrugStoreID, out objMPVO);
        }
    }
}
