using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.digitalwave.iCare.ValueObject;
namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 帐务期结转域控制层
    /// </summary>
    public class clsDcl_Account : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 获取药房总帐表内容
        /// <summary>
        /// 获取药房总帐表内容
        /// </summary>
        /// <param name="p_strStorageID">药房ID</param>
        /// <param name="p_strAccountID">帐务期ID</param>
        /// <param name="p_objRecord">总帐表内容</param>
        /// <returns></returns>
        public long m_lngGetAccout(string p_strStorageID, string p_strAccountID, out clsDS_Account p_objRecord)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAccount_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAccount_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAccount_Supported_SVC));
            lngRes = objSvc.m_lngGetAccout(objPrincipal, p_strStorageID, p_strAccountID, out p_objRecord);
            return lngRes;
        }
        #endregion
        #region 生成帐表
        /// <summary>
        /// 生成帐表
        /// </summary>
        /// <param name="p_dtmBegin">帐务期开始时间</param>
        /// <param name="p_dtmEnd">帐务期结束时间</param>
        /// <param name="m_strDrugStoreid">药房ID</param>
        /// <param name="p_objAccount">帐务表</param>
        /// <param name="p_lngSEQArr">序列</param>
        /// <returns></returns>
        public long m_lngGenarateAccount(DateTime p_dtmBegin, DateTime p_dtmEnd, string m_strDrugStoreid, out clsDS_Account p_objAccount, out long[] p_lngSEQArr,int m_intTransferMode,long m_lngCheckSeqid)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAccount_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAccount_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAccount_Supported_SVC));
            lngRes = objSvc.m_lngGenarateAccount(objPrincipal, p_dtmBegin, p_dtmEnd, m_strDrugStoreid, out p_objAccount, out p_lngSEQArr, m_intTransferMode, m_lngCheckSeqid);
            return lngRes;
        }
        #endregion
        #region 检查是否有未确定入帐的记录
        /// <summary>
        /// 检查是否有未确定入帐的记录
        /// </summary>
        /// <param name="p_dtmBegin">帐务期开始时间</param>
        /// <param name="p_dtmEnd">帐务期结束时间</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strChittyIDArr">单据号</param>
        /// <returns></returns>
        public long m_lngCheckHasUnConfirmAccount(DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strStorageID, out string[] p_strChittyIDArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAccountPeriod_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAccountPeriod_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAccountPeriod_Supported_SVC));
            lngRes = objSvc.m_lngCheckHasUnConfirmAccount(objPrincipal, p_dtmBegin, p_dtmEnd, p_strStorageID, out p_strChittyIDArr);
            return lngRes;
        }
        #endregion
        #region 检查开帐务期内是否存在未审核的记录
        /// <summary>
        /// 检查开帐务期内是否存在未审核的记录
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtmBeginDate">帐务期开始时间</param>
        /// <param name="p_dtmEndDate">帐务期结束时间</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strHintText">存在未审核记录的单据名称(类型)</param>
        /// <returns></returns>
        public long m_lngCheckHasUnCommitRecord(DateTime p_dtmBeginDate, DateTime p_dtmEndDate, string p_strStorageID, out string p_strHintText)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAccountPeriod_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAccountPeriod_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAccountPeriod_Supported_SVC));
            lngRes = objSvc.m_lngCheckHasUnCommitRecord(objPrincipal, p_dtmBeginDate, p_dtmEndDate, p_strStorageID, out p_strHintText);
            return lngRes;
        }
             #endregion
        #region 入帐
        /// <summary>
        /// 入帐
        /// </summary>
        /// <param name="p_strEmpID">员工ID</param>
        /// <param name="p_dtmAccountDate">入帐日期</param>
        /// <param name="p_strChittyIDArr">单据号</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <returns></returns>
        public long m_lngSetAccount( string p_strEmpID, DateTime p_dtmAccountDate, string[] p_strChittyIDArr, string p_strStorageID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAccount_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAccount_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAccount_SVC));
            lngRes = objSvc.m_lngSetAccount(objPrincipal, p_strEmpID, p_dtmAccountDate, p_strChittyIDArr, p_strStorageID);
            return lngRes;
        }
        #endregion
        #region 保存帐表
        /// <summary>
        /// 保存帐表
        /// </summary>
        /// <param name="p_objAccPe">帐务期结转内容</param>
        /// <param name="p_objAccount">帐表内容</param>
        /// <param name="p_lngMedSEQ">流水帐序列</param>
        /// <param name="p_strEmpID">员工ID</param>
        /// <param name="p_strAccountID">帐务期ID</param>
        /// <param name="p_lngMainSEQ">帐务期序列</param>
        /// <param name="p_lngSubSEQ">帐表序列</param>
        /// <returns></returns>
        public long m_lngSaveAccount(clsDS_AccountPeriodVO p_objAccPe, clsDS_Account p_objAccount, long[] p_lngMedSEQ, string p_strEmpID, out string p_strAccountID, out long p_lngMainSEQ, out long p_lngSubSEQ,int m_intTransfermode,long m_lngCheckSeqid)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAccount_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAccount_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAccount_SVC));
            lngRes = objSvc.m_lngSaveAccount(objPrincipal, p_objAccPe, p_objAccount, p_lngMedSEQ, p_strEmpID, out p_strAccountID, out p_lngMainSEQ, out p_lngSubSEQ,m_intTransfermode,m_lngCheckSeqid);
            return lngRes;
        }
        #endregion
        #region  获取最近一次盘点时间作为本期帐务期的结束时间

        /// <summary>
        /// 获取最近一次盘点时间作为本期帐务期的结束时间
        /// </summary>
        /// <param name="p_strStorageID"></param>
        /// <param name="m_dtmBeginAccountTime"></param>
        /// <param name="m_dtmEndAccountTime"></param>
        /// <returns></returns>
        public long m_lngGetAccountEndTime(string p_strStorageID, DateTime m_dtmBeginAccountTime, out  DateTime m_dtmEndAccountTime,out long m_lngCheckSeqid)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAccount_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAccount_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAccount_Supported_SVC));
            lngRes = objSvc.m_lngGetAccountEndTime(objPrincipal, p_strStorageID, m_dtmBeginAccountTime, out m_dtmEndAccountTime, out m_lngCheckSeqid);
            return lngRes;
        }
        #endregion
    }
}
