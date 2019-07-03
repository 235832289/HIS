using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    /// <summary>
    /// 帐务期结转    /// </summary>
    public class clsDcl_AccountPeriod : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 获取帐务期结转数据
        /// <summary>
        /// 获取帐务期结转数据        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtbAccountData">帐务期结转数据</param>
        /// <returns></returns>
        internal long m_lngGetAccountPeriod(string p_strStorageID, out DataTable p_dtbAccountData)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC));
            lngRes = objSvc.m_lngGetAccountPeriod(objPrincipal, p_strStorageID, out p_dtbAccountData);
            return lngRes;
        } 
        #endregion        

        #region 获取系统参数配置
        /// <summary>
        /// 获取系统参数配置
        /// </summary>
        /// <param name="p_strCode">配置代码</param>
        /// <param name="p_strParm">参数配置</param>
        /// <returns></returns>
        internal long m_lngGetSysParm(string p_strCode, out string p_strParm)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.common.clsCommonInfoSvc objSvc =
                (com.digitalwave.iCare.middletier.common.clsCommonInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.common.clsCommonInfoSvc));
            lngRes = objSvc.m_lngGetSysParm(objPrincipal, p_strCode, out p_strParm);
            return lngRes;
        }
        #endregion

        #region 取消结转
        /// <summary>
        /// 取消结转
        /// </summary>
        /// <param name="p_lngMainSEQ">帐务期表序列</param>
        /// <param name="p_strAccountID">帐务期ID</param>
        /// <param name="p_strStorageID">仓库</param>
        /// <returns></returns>
        internal long m_lngCancelAccount(long p_lngMainSEQ, string p_strAccountID, string p_strStorageID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC));
            lngRes = objSvc.m_lngCancelAccount(objPrincipal, p_lngMainSEQ, p_strAccountID, p_strStorageID);
            return lngRes;
        }
        #endregion

        #region 判断是否可以取消选中的帐务结转
        /// <summary>
        /// 判断是否可以取消选中的帐务结转(如果已经有下一期的业务单据则不允许)
        /// </summary>
        /// <param name="p_dtmEndDate">选中帐务结转的帐务结束时间</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_blnCanCancel">是否可以取消</param>
        /// <returns></returns>
        internal long m_lngCheckCanCancelAccount(DateTime p_dtmEndDate, string p_strStorageID, out bool p_blnCanCancel)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC));
            lngRes = objSvc.m_lngCheckCanCancelAccount(objPrincipal, p_dtmEndDate, p_strStorageID, out p_blnCanCancel);
            return lngRes;
        }
        #endregion


        #region 生成帐表
        /// <summary>
        /// 生成帐表
        /// </summary>
        /// <param name="p_dtmBegin">帐务期开始时间</param>
        /// <param name="p_dtmEnd">帐务期结束时间</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_objAccount">帐务表</param>
        /// <param name="p_lngSEQArr">序列</param>
        /// <returns></returns>
        internal long m_lngGenarateAccount(DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strStorageID, out clsMS_Account p_objAccount, out long[] p_lngSEQArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC));
            lngRes = objSvc.m_lngGenarateAccount(objPrincipal, p_dtmBegin, p_dtmEnd, p_strStorageID, out p_objAccount, out p_lngSEQArr);
            return lngRes;
        }
        #endregion

        #region 获取总帐表内容

        /// <summary>
        /// 获取总帐表内容

        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strAccountID">帐务期ID</param>
        /// <param name="p_objRecord">总帐表内容</param>
        /// <returns></returns>
        internal long m_lngGetAccout(string p_strStorageID, string p_strAccountID, out DataTable p_objRecord)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC));
            lngRes = objSvc.m_lngGetAccout(objPrincipal, p_strStorageID, p_strAccountID, out p_objRecord);
            return lngRes;
        }
        #endregion

        #region 取仓库名称

        /// <summary>
        /// 取仓库名称

        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStoreRoomID"></param>
        /// <param name="p_strStoreRoomName"></param>
        /// <returns></returns>
        public long m_lngGetStoreRoomName(string p_strStoreRoomID, out string p_strStoreRoomName)
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
