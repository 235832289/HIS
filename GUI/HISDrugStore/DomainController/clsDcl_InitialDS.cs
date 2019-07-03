using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 药房库存初始化
    /// </summary>
    public class clsDcl_InitialDS : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 获取药品最基本信息
        /// <summary>
        /// 获取药品最基本信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strAssistCode">查询条件</param>
        /// <param name="p_dtbMedicine">返回结果</param>
        /// <returns></returns>
        public long m_lngGetBaseMedicine(string p_strAssistCode,string m_strMedStoreid, out DataTable p_dtbMedicine)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC));
            lngRes = objSvc.m_lngGetBaseMedicine(objPrincipal, p_strAssistCode,m_strMedStoreid, out p_dtbMedicine);
            return lngRes;
        } 
        #endregion

        #region 保存药品
        /// <summary>
        /// 保存药品
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objNew">新添的药品</param>
        /// <param name="p_objModify">修改的药品</param>
        /// <param name="p_lngNewSeqArr">新增记录的序列</param>
        /// <returns></returns>
        public long m_lngSaveMedicineInfo(clsDS_Initial_VO[] p_objNew, clsDS_Initial_VO[] p_objModify, out long[] p_lngNewSeqArr,out string[] p_strIDArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsInitialDS_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsInitialDS_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsInitialDS_SVC));
            lngRes = objSvc.m_lngSaveMedicineInfo(objPrincipal, p_objNew, p_objModify, out p_lngNewSeqArr, out p_strIDArr);
            return lngRes;
        }
        #endregion

        #region 获取药房初始化药品信息
        /// <summary>
        /// 获取药房初始化药品信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strDrugStoreID">药房ID</param>
        /// <param name="p_blnIsHospital">是否住院单位</param>
        /// <param name="p_dtbMedicine">药品信息</param>
        /// <returns></returns>
        public long m_lngGetInitilaMedicine(string p_strDrugStoreID, bool p_blnIsHospital,out DataTable p_dtbMedicine)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsInitialDS_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsInitialDS_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsInitialDS_Supported_SVC));
            lngRes = objSvc.m_lngGetInitilaMedicine(objPrincipal, p_strDrugStoreID, p_blnIsHospital,out p_dtbMedicine);
            return lngRes;
        }
        #endregion

        #region 删除指定初始库存
        /// <summary>
        /// 删除指定初始库存
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_lngSEQ">序列号</param>
        /// <returns></returns>
        public long m_lngDeleteMedicineInitial(long p_lngSEQ)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsInitialDS_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsInitialDS_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsInitialDS_SVC));
            lngRes = objSvc.m_lngDeleteMedicineInitial(objPrincipal, p_lngSEQ);
            return lngRes;
        }
        #endregion

        #region 审核药房库存初始化
        /// <summary>
        /// 审核药房库存初始化
        /// </summary>
        /// <param name="p_strStorageID"></param>
        /// <param name="p_objDetail"></param>
        /// <param name="intType"></param>
        /// <returns></returns>
        public long m_lngCommitInitila(string p_strStorageID, clsDS_StorageDetail_VO[] p_objDetail, Int16 intType)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsInitialDS_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsInitialDS_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsInitialDS_SVC));
            lngRes = objSvc.m_lngCommitInitila(objPrincipal, p_strStorageID, p_objDetail,intType);
            return lngRes;
        }
        #endregion

        /// <summary>
        /// 获取药房信息
        /// </summary>
        /// <param name="p_strDrugStoreID">药房ID</param>
        /// <param name="p_strStoreName">药房名称</param>
        /// <param name="p_strDeptID">对应的部门ID</param>
        /// <returns></returns>
        internal long m_lngGetStoreInfo(string p_strDrugStoreID, out string p_strStoreName, out string p_strDeptID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsInitialDS_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsInitialDS_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsInitialDS_Supported_SVC));
            lngRes = objSvc.m_lngGetStoreInfo(objPrincipal, p_strDrugStoreID, out p_strStoreName, out p_strDeptID);
            return lngRes;
        }

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
        internal long m_lngCommitMedicineInfo(clsDS_StorageDetail_VO[] p_objDetailArr, clsDS_Storage_VO[] p_objStorageArr, long[] p_lngSEQArr, string p_strEmpID, bool p_blnIsImmAccount)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsInitialDS_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsInitialDS_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsInitialDS_SVC));
            lngRes = objSvc.m_lngCommitMedicineInfo(objPrincipal, p_objDetailArr, p_objStorageArr, p_lngSEQArr, p_strEmpID, p_blnIsImmAccount);
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
            com.digitalwave.iCare.middletier.HIS.clsInitialDS_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsInitialDS_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsInitialDS_SVC));
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
        /// <param name="p_strStorageID">药库ID</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strLotNO">批号</param>
        /// <param name="p_dblInAmount">入库数量</param>
        /// <returns></returns>
        internal long m_lngUnCommit(long p_lngSEQ, string p_strInitialID, string p_strStorageID, string p_strMedicineID, string p_strLotNO, double p_dblInAmount)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsInitialDS_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsInitialDS_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsInitialDS_SVC));
            lngRes = objSvc.m_lngUnCommit(objPrincipal, p_lngSEQ, p_strInitialID, p_strStorageID, p_strMedicineID, p_strLotNO, p_dblInAmount);
            return lngRes;
        }
        #endregion

        /// <summary>
        /// 查询是否已有结转记录
        /// </summary>
        /// <param name="p_strStorageID"></param>
        /// <param name="p_blnHasAccountPeriod"></param>
        /// <returns></returns>
        internal long m_lngCheckHasAccount(string p_strStorageID, out bool p_blnHasAccountPeriod)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsInitialDS_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsInitialDS_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsInitialDS_Supported_SVC));
            lngRes = objSvc.m_lngCheckHasAccount(objPrincipal, p_strStorageID, out p_blnHasAccountPeriod);
            return lngRes;
        }
    }
}
