using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    public class clsDcl_StockPlan_Detail : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 获取审核流程设置
        /// <summary>
        /// 获取审核流程设置
        /// </summary>
        /// <param name="p_intCommitFolw">审核流程设置</param>
        /// <returns></returns>
        internal long m_lngGetCommitFlow(out int p_intCommitFolw)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetSysSetting(objPrincipal, "0901", out p_intCommitFolw);
            return lngRes;
        }
        #endregion

        #region 获取药品最基本信息
        /// <summary>
        /// 获取药品最基本信息
        /// </summary>
        /// <param name="p_strAssistCode">查询条件</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtbMedicine">返回结果</param>
        /// <returns></returns>
        internal long m_lngGetBaseMedicine(string p_strAssistCode, string p_strStorageID, out DataTable p_dtbMedicine)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC));
            lngRes = objSvc.m_lngGetBaseMedicineWithGross(objPrincipal, p_strAssistCode, p_strStorageID, out p_dtbMedicine);
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
        /// 插入主表和明细表数据
        /// </summary>
        /// <param name="m_objMainVo"></param>
        /// <param name="m_objDetailArr"></param>
        /// <returns></returns>
        public long m_lngAddNewPlanMedInfo(int m_intCommit, ref clsMS_StockPlan_VO m_objMainVo, ref clsMS_StockPlan_Detail_VO[] m_objDetailArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC));
            lngRes = objSvc.m_lngAddNewPlanMedInfo(objPrincipal, m_intCommit, ref m_objMainVo, ref m_objDetailArr);
            return lngRes;
        }

        /// <summary>
        /// 更新主表和明细表数据
        /// </summary>
        /// <param name="m_objMainVo"></param>
        /// <param name="m_objDetailArr"></param>
        /// <returns></returns>
        public long m_lngUpdatePlanMedInfo(int m_intCommit, clsMS_StockPlan_VO m_objMainVo, ref clsMS_StockPlan_Detail_VO[] m_objDetailArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC));
            lngRes = objSvc.m_lngUpdatePlanMedInfo(objPrincipal, m_intCommit, m_objMainVo, ref m_objDetailArr);
            return lngRes;
        }

        /// <summary>
        /// 根据序列号删除药品id
        /// </summary>
        /// <param name="m_lngSeqid"></param>
        /// <returns></returns>
        public long m_lngDelMedDetail(long m_lngSeqid)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC));
            lngRes = objSvc.m_lngDelPlanMedDetail(objPrincipal, m_lngSeqid);
            return lngRes;
        }

        /// <summary>
        /// 是否已审核
        /// </summary>
        /// <param name="p_strBillNo"></param>
        /// <param name="p_intStatus"></param>
        internal void m_mthGetCommitStatus(string p_strBillNo, out int p_intStatus)
        {
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC));
            objSvc.m_mthGetCommitStatus(objPrincipal, p_strBillNo, out p_intStatus);
        }

        /// <summary>
        /// 自动计算需采购数量        
        /// </summary>
        /// <param name="p_strStorageID">药库号</param>
        /// <param name="p_strMedicineID">药品号</param>
        /// <param name="p_intAmount">数量</param>
        internal void m_mthGetAmount(string p_strStorageID, string p_strMedicineID, out double p_intAmount)
        {
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC));
            objSvc.m_mthGetAmount(objPrincipal, p_strStorageID, p_strMedicineID, out p_intAmount);
        }

        /// <summary>
        /// 自动计算需采购数量
        /// </summary>
        /// <param name="p_strStorageID"></param>
        /// <param name="p_strMedicineID"></param>
        /// <param name="p_intRealAmount"></param>
        /// <param name="p_intTopAmount"></param>
        /// <param name="p_intNeapAmount"></param>
        internal void m_mthGetAmount(string p_strStorageID, string p_strMedicineID, out double p_intRealAmount, out double p_intTopAmount, out double p_intNeapAmount)
        {
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC objSvc =
                 (com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC));
            objSvc.m_mthGetAmount(objPrincipal, p_strStorageID, p_strMedicineID, out p_intRealAmount, out p_intTopAmount, out p_intNeapAmount);
        }

        #region 获取明细表内容(打印)
        /// <summary>
        /// 获取明细表内容(打印)
        /// </summary>
        /// <param name="p_lngSeries2ID">主表序列</param>
        /// <param name="p_intState">单据状态</param>
        /// <param name="p_dtbValue">明细表内容</param>
        /// <returns></returns>
        internal long m_lngGetStockPlanForPrint(long p_lngSeries2ID, int p_intState, out DataTable p_dtbValue)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC));
            lngRes = objSvc.m_lngGetStockPlanForPrint(objPrincipal, p_lngSeries2ID, p_intState, out p_dtbValue);
            return lngRes;
        }
        #endregion

        /// <summary>
        /// 获取打印类型0为默认，1为台山
        /// </summary>
        /// <param name="m_intType">类型</param>
        internal void m_lngGetPrintType(out int m_intType)
        {
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            objSvc.m_lngGetSysSetting(objPrincipal, "5032", out m_intType);
        }

        /// <summary>
        /// 获取明细表内容(打印)台山
        /// </summary>
        /// <param name="p_lngSeries2ID">主表序列</param>
        /// <param name="p_intState">单据状态</param>
        /// <param name="p_dtbValue">明细表内容</param>
        internal void m_lngGetStockPlanForPrintTaiShan(long p_lngSeries2ID, int p_intState, out DataTable p_dtbValue)
        {
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStockPlanSVC));
            objSvc.m_lngGetStockPlanForPrintTaiShan(objPrincipal, p_lngSeries2ID, p_intState, out p_dtbValue);            
        }
    }
}
