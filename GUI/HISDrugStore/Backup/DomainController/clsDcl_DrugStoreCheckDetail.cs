using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Data;
using com.digitalwave.EMR_EmployeeManagerService;

namespace com.digitalwave.iCare.gui.HIS
{
    public class clsDcl_DrugStoreCheckDetail : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 查找员工
        /// <summary>
        /// 查找员工
        /// </summary>
        /// <param name="p_strSearch">搜索字符</param>
        /// <param name="p_dtbEMP">员工</param>
        /// <returns></returns>
        internal long m_lngGetEMP(string p_strSearch, out DataTable p_dtbEMP)
        {
            long lngRes = 0;
            clsEMR_EmployeeManagerService objSvc =
                (clsEMR_EmployeeManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.EMR_EmployeeManagerService.clsEMR_EmployeeManagerService));
            lngRes = objSvc.m_lngGetEmpArrByIDOrNameLike(p_strSearch, out p_dtbEMP);
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
        internal long m_lngGetMedicineByMedicineID(string p_strMedicineID, string p_strStorageID,bool p_blnIsHospital, out DataTable p_dtbMedicine)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC));
            lngRes = objSvc.m_lngGetMedicineByMedicineID(objPrincipal, p_strMedicineID, p_strStorageID, p_blnIsHospital,out p_dtbMedicine);
            return lngRes;
        }
        #endregion

        #region 保存盘点
        /// <summary>
        /// 保存盘点
        /// </summary>
        /// <param name="p_objMain">主表记录</param>
        /// <param name="p_objModifyDetaiArr">修改过的盘点记录</param>
        /// <param name="p_objNewDetailArr">新增的盘点记录</param>
        /// <param name="p_strEmpID">员工ID</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_blnIsAddNew">是否新增</param>
        /// <param name="p_blnIsHospital">是否住院药房</param>
        /// <param name="p_strCommit">审核流程</param>
        /// <param name="p_lngNewSubSEQArr">新增盘点记录明细序列</param>
        /// <returns></returns>
        internal long m_lngSaveStorageCheck(ref clsDS_Check_VO p_objMain, clsDS_StorageCheckDetail_VO[] p_objModifyDetaiArr, clsDS_StorageCheckDetail_VO[] p_objNewDetailArr,
            string p_strEmpID, string p_strStorageID, bool p_blnIsAddNew, bool p_blnIsHospital,string p_strCommit,out long[] p_lngNewSubSEQArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_SVC));
            lngRes = objSvc.m_lngSaveStorageCheck(objPrincipal, ref p_objMain, p_objModifyDetaiArr, p_objNewDetailArr, p_strEmpID, p_strStorageID, p_blnIsAddNew,p_blnIsHospital,p_strCommit, out p_lngNewSubSEQArr);
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
            com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC));
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
            com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC));
            lngRes = objSvc.m_lngGetCheckResult(objPrincipal, p_lngSEQ, out p_dtbResult);
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
        /// <returns></returns>
        internal long m_lngDeleteStoreCheckMedicine(clsDS_StorageDetail_VO[] p_objMedicneSt, string p_strCheckID, long p_lngSubSEQ)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_SVC));
            lngRes = objSvc.m_lngDeleteStorageCheckMedicine(objPrincipal, p_objMedicneSt, p_strCheckID, p_lngSubSEQ, false);
            return lngRes;
        }
        #endregion

        #region 获取盘点模式，0为默认，1为广医三院
        /// <summary>
        /// 获取盘点模式，0为默认，1为广医三院
        /// </summary>
        /// <param name="p_intCheckMode">盘点模式，0为默认，1为广医三院</param>
        /// <returns></returns>
        internal long m_mthGetCheckMode(out int p_intCheckMode)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC));
            lngRes = objSvc.m_lngGetSysSetting(objPrincipal, "0406", out p_intCheckMode);
            return lngRes;
        }
        #endregion
              
        #region 获取盘点明细打印
        /// <summary>
        /// 获取盘点明细打印
        /// </summary>
        /// <returns></returns>
        internal long m_lngGetStoreCheck_DetailForPrint(long p_lngMainSEQ, bool p_blnIsHospital, out DataTable p_dtbStorageCheck_detail)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC));
            lngRes = objSvc.m_lngGetStoreCheck_DetailForPrint(objPrincipal, p_lngMainSEQ,p_blnIsHospital, out p_dtbStorageCheck_detail);
            return lngRes;
        }
        #endregion

        #region 获取盘点明细打印(常平)
        /// <summary>
        /// 获取盘点明细打印(常平)
        /// </summary>
        /// <returns></returns>
        internal long m_lngGetStoreCheck_DetailForPrintCP(long p_lngMainSEQ, bool p_blnIsHospital, out DataTable p_dtbStorageCheck_detail)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC));
            lngRes = objSvc.m_lngGetStoreCheck_DetailForPrintCP(objPrincipal, p_lngMainSEQ, p_blnIsHospital, out p_dtbStorageCheck_detail);
            return lngRes;
        }
        #endregion

        /// <summary>
        /// 未审核业务单据
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strDrugStoreID"></param>
        /// <param name="p_dtbIn">入库单</param>
        /// <param name="p_dtbOut">出库单</param>
        /// <param name="p_dtbAsk">请领单</param>
        /// <returns></returns>
        public long m_lngCheckUnAuditData(string p_strDrugStoreID,out DataTable p_dtbIn, out DataTable p_dtbOut,out DataTable p_dtbAsk)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC));
            lngRes = objSvc.m_lngCheckUnAuditData(objPrincipal, p_strDrugStoreID, out p_dtbIn, out p_dtbOut,out p_dtbAsk);
            return lngRes;
        }

        /// <summary>
        /// “暂调入库“的金额不为零的药品
        /// </summary>
        /// <param name="p_strDrugStoreID"></param>
        /// <param name="p_dtmStartDate"></param>
        /// <param name="p_dtmEndDate"></param>
        /// <param name="dtbTempIn"></param>
        internal long m_lngCheckExistTempIn(string p_strDrugStoreID, DateTime p_dtmStartDate, DateTime p_dtmEndDate, out bool p_blnExist)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC));
            lngRes = objSvc.m_lngCheckExistTempIn(objPrincipal, p_strDrugStoreID, p_dtmStartDate, p_dtmEndDate, out p_blnExist);
            return lngRes;
        }

        internal long m_lngGetCurrentAccountDate(string p_strDrugStoreID, out DateTime p_dtmStartDate, out DateTime p_dtmEndDate)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC));
            lngRes = objSvc.m_lngGetCurrentAccountDate(objPrincipal, p_strDrugStoreID, out p_dtmStartDate, out p_dtmEndDate);
            return lngRes;
        }

        /// <summary>
        /// 检查当前帐务期是否已开盘点单
        /// </summary>
        ///<param name="p_strDrugStoreID"></param>
        /// <param name="p_dtmStartDate"></param>
        /// <param name="p_dtmEndDate"></param>
        /// <param name="p_strCheckId"></param>        
        /// <param name="p_blnExist"></param>
        /// <returns></returns>
        public long m_lngCheckExistBill(string p_strDrugStoreID, DateTime p_dtmStartDate, DateTime p_dtmEndDate, string p_strCheckId,out bool p_blnExist)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC));
            lngRes = objSvc.m_lngCheckExistBill(objPrincipal, p_strDrugStoreID, p_dtmStartDate, p_dtmEndDate,p_strCheckId, out p_blnExist);
            return lngRes;
        }

        #region  是否允许保存库存数为负数（只限于保存单据）0为不允许、1为允许
        /// <summary>
        /// 是否允许保存库存数为负数（只限于保存单据）0为不允许、1为允许
        /// </summary>
        /// <param name="m_intAllowNegativeStorage">是否允许保存库存数为负数（只限于保存单据）</param>
        /// <returns></returns>
        internal long m_mthGetAllowNegativeStorage(out int m_intAllowNegativeStorage)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC));
            lngRes = objSvc.m_lngGetSysSetting(objPrincipal, "0414", out m_intAllowNegativeStorage);
            return lngRes;
        }
        #endregion


        internal long m_mthChangeValueDate()
        {
            long lngRes = 0;

            return lngRes;
        }

        public long m_lngQueryStoreCheckState(string p_strSeriesid, out string p_strState)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_SVC));
            lngRes = objSvc.m_lngQueryStoreCheckState(p_strSeriesid, out p_strState);
            return lngRes;
        }
    }
}
