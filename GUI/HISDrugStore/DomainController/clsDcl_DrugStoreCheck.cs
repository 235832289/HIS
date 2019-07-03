using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Data;

namespace com.digitalwave.iCare.gui.HIS
{  
    /// <summary>
    /// 药房盘点域控制层
    /// </summary>
    public class clsDcl_DrugStoreCheck : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 根据制单时间和药房id获取药房盘点数据
        /// <summary>
        /// 根据制单时间和药房id获取药房盘点数据
        /// </summary>
        /// <param name="m_strDrugStoreid"></param>
        /// <param name="m_datBeginTime"></param>
        /// <param name="m_datEndTime"></param>
        /// <param name="m_dtCheckMainInfo"></param>
        /// <returns></returns>
        public long m_lngGetDrugStoreCheckMainInfo(string m_strDrugStoreid, DateTime m_datBeginTime, DateTime m_datEndTime, out DataTable m_dtCheckMainInfo)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC));

            lngRes = objSvc.m_lngGetDrugStoreCheckMainInfo(objPrincipal, m_strDrugStoreid, m_datBeginTime, m_datEndTime, out m_dtCheckMainInfo);          
            return lngRes;
        }
        #endregion
        #region 根据序列号获取药房盘点明细数据
        /// <summary>
        /// 根据序列号获取药房盘点明细数据
        /// </summary>
        /// <param name="m_strSerialID"></param>
        /// <param name="m_dtCheckDetailInfo"></param>
        /// <returns></returns>
        public long m_lngGetDrugStoreCheckDetailInfoById(string m_strSerialID, out DataTable m_dtCheckDetailInfo)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC));

            lngRes = objSvc.m_lngGetDrugStoreCheckDetailInfoById(objPrincipal, m_strSerialID, out m_dtCheckDetailInfo);
            return lngRes;
        }
        #endregion
        #region 根据查询条件获取药房盘点数据
        /// <summary>
        /// 根据查询条件获取药房盘点数据
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strDrugStoreid"></param>
        /// <param name="m_datBeginTime"></param>
        /// <param name="m_datEndTime"></param>
        /// <param name="m_strCheckid"></param>
        /// <param name="m_strMakerid"></param>
        /// <param name="m_intStatus"></param>
        /// <param name="m_dtCheckMainInfo"></param>
        /// <returns></returns>
        public long m_lngGetDrugStoreCheckMainInfo(string m_strDrugStoreid, DateTime m_datBeginTime, DateTime m_datEndTime, string m_strCheckid, string m_strMakerid, Int16 m_intStatus, out DataTable m_dtCheckMainInfo)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC));

            lngRes = objSvc.m_lngGetDrugStoreCheckMainInfo(objPrincipal,  m_strDrugStoreid,  m_datBeginTime,  m_datEndTime,  m_strCheckid,  m_strMakerid,  m_intStatus, out  m_dtCheckMainInfo);
            return lngRes;
        }
        #endregion

        #region 删除盘点信息
        /// <summary>
        /// 删除盘点信息
        /// </summary>
        /// <param name="p_lngSEQ">主表序列</param>
        /// <returns></returns>
        internal long m_lngDeleteStorageCheck(long p_lngSEQ)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_SVC));
            lngRes = objSvc.m_lngDeleteStorageCheck(objPrincipal, p_lngSEQ);
            return lngRes;
        }
        #endregion
        
        #region 获取盘点明细表信息

        /// <summary>
        /// 获取盘点明细表信息
        /// </summary>
        /// <param name="p_lngSeriesId">主表序列号</param>
        /// <param name="p_intCheckMode">盘点模式，0为默认，1为三院</param>
        /// <param name="p_blnIsHospital">是否住院药房</param>
        /// <param name="dtbDetailTrue">未合并的明细表信息</param>
        /// <param name="dtbStorageCheck_detail">已合并的明细表信息</param>
        /// <returns></returns>
        internal long m_lngGetStoreCheck_detail(long p_lngSeriesId,int p_intCheckMode,bool p_blnIsHospital,out DataTable dtbDetailTrue, out DataTable dtbStorageCheck_detail)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_Supported_SVC));
            lngRes = objSvc.m_lngGetStorageCheck_detail(objPrincipal, p_lngSeriesId,p_intCheckMode, p_blnIsHospital,out dtbDetailTrue, out dtbStorageCheck_detail);
            return lngRes;
        }
        #endregion

       
        #region 审核盘点
        /// <summary>
        /// 审核盘点
        /// </summary>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <param name="p_objDefCheckDetail">盘亏明细</param>
        /// <param name="p_objSufCheckDetail">盘盈明细</param>
        /// <param name="p_objStDetail">盘点药品相关库存明细</param>
        /// <param name="p_strMedicineIDArr">盘点药品ID</param>
        /// <param name="p_strEmpID">审核人ID</param>
        /// <param name="p_dtmCommitDate">审核日期</param>
        /// <param name="p_strCheckID">盘点ID</param>
        /// <param name="p_strCreatorID">盘点人ID</param>
        /// <param name="p_dtmCheckDate">盘点日期</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <returns></returns>
        internal long m_lngCommitStoreCheck(long p_lngMainSEQ, clsDS_StorageCheckDetail_VO[] p_objDefCheckDetail, clsDS_StorageCheckDetail_VO[] p_objSufCheckDetail, clsDS_StorageDetail_VO[] p_objStDetail, string[] p_strMedicineIDArr, string p_strEmpID, DateTime p_dtmCommitDate,
            string p_strCheckID, string p_strCreatorID, DateTime p_dtmCheckDate, string p_strStorageID,bool p_blnIsHospital)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_SVC));
            lngRes = objSvc.m_lngCommitStorageCheck(objPrincipal, p_lngMainSEQ, p_objDefCheckDetail, p_objSufCheckDetail, p_objStDetail, p_strMedicineIDArr, p_strEmpID, p_dtmCommitDate, p_strCheckID, p_strCreatorID, p_dtmCheckDate, p_strStorageID, false,"0",p_blnIsHospital);
            return lngRes;
        }
        #endregion

        #region 获取当前员工是否有药房管理角色
        /// <summary>
        /// 获取当前员工是否有药房管理角色
        /// </summary>
        /// <param name="p_strEmpID">员工ID</param>
        /// <param name="p_blnHasRole">是否有药房管理角色</param>
        /// <returns></returns>
        internal long m_lngCheckEmpHasRole(string p_strEmpID, out bool p_blnHasRole)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.common.clsCommonInfoSvc objSvc =
                (com.digitalwave.iCare.middletier.common.clsCommonInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.common.clsCommonInfoSvc));
            lngRes = objSvc.m_lngCheckEmpHasRole(objPrincipal, p_strEmpID, "药房管理角色", out p_blnHasRole);
            return lngRes;
        }
        #endregion

        /// <summary>
        /// 设置入账
        /// </summary>
        /// <param name="p_strEmpID">入账人</param>
        /// <param name="p_dtmAccountDate">入账日期</param>
        /// <param name="p_lngSeq">序列</param>
        /// <param name="p_strChittyid">单据号</param>
        /// <param name="p_strDrugStoreid">药房ID</param>
        /// <returns></returns>
        internal long m_lngInAccount(string p_strEmpID, DateTime p_dtmAccountDate, long p_lngSeq,string  p_strChittyid, string p_strDrugStoreid)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDrugStoreCheck_SVC));
            lngRes = objSvc.m_lngInAccount(objPrincipal, p_lngSeq, p_strChittyid, p_strEmpID, p_dtmAccountDate, p_strDrugStoreid);
            return lngRes;
        }

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


        #region 检查单据状态值
        /// <summary>
        /// 检查单据状态值
        /// </summary>
        /// <param name="p_intType">单据类别：2为药房盘点表</param>
        /// <param name="p_lngSeq">主表seq</param>
        /// <param name="m_intStatus">单据状态值</param>
        /// <returns></returns>
        internal long m_lngCheckStatus(int p_intType, long p_lngSeq, out int m_intStatus)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC));
            lngRes = objSvc.m_lngCheckStatus(objPrincipal, p_intType, p_lngSeq, out m_intStatus);
            return lngRes;
        }
        #endregion
    }
}
