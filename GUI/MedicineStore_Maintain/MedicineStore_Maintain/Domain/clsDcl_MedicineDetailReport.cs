using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 药品明细帐表
    /// </summary>
    public class clsDcl_MedicineDetailReport : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 获取帐务期表内容
        /// <summary>
        /// 获取帐务期表内容
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_objAccountData">帐务期表内容</param>
        /// <returns></returns>
        internal long m_lngGetAccountPeriod(string p_strStorageID, out clsMS_AccountPeriodVO[] p_objAccountData)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsAccountPeriodSVC));
            lngRes = objSvc.m_lngGetAccountPeriod(objPrincipal, p_strStorageID, out p_objAccountData);
            return lngRes;
        }
        #endregion

        #region 获取药品帐表
        /// <summary>
        /// 获取药品帐表
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_strLastAccountID">上期帐务期ID(如为空则本期为第一期)</param>
        /// <param name="p_strAccountID">帐务期ID</param>
        /// <param name="p_objValue">帐务内容</param>
        /// <returns></returns>
        public long m_lngGetMedicineTotalAccount(string p_strStorageID, string p_strMedicineID, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strLastAccountID, string p_strAccountID, out clsMS_TotalAccountVO p_objValue)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_AccountSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_AccountSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_AccountSVC));
            lngRes = objSvc.m_lngGetMedicineTotalAccount(objPrincipal, p_strStorageID, p_strMedicineID, p_dtmBegin, p_dtmEnd, p_strLastAccountID, p_strAccountID, out p_objValue);
            return lngRes;
        } 
        #endregion

        #region 获取药品帐表(未结转)
        /// <summary>
        /// 获取药品帐表
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_strLastAccountID">上期帐务期ID(如为空则本期为第一期)</param>
        /// <param name="p_strAccountID">帐务期ID</param>
        /// <param name="p_objValue">帐务内容</param>
        /// <returns></returns>
        public long m_lngGetMedicineTotalAccountNoAcc(string p_strStorageID, string p_strMedicineID, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strLastAccountID, string p_strAccountID, out clsMS_TotalAccountVO p_objValue)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_AccountSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_AccountSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_AccountSVC));
            lngRes = objSvc.m_lngGetMedicineTotalAccountNoAcc(objPrincipal, p_strStorageID, p_strMedicineID, p_dtmBegin, p_dtmEnd, p_strLastAccountID, p_strAccountID, out p_objValue);
            return lngRes;
        }
        #endregion

        #region 根据药品类型获取药品帐表
        /// <summary>
        /// 根据药品类型获取药品帐表
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicineTypeSetID">药品类型(大类)</param>
        /// <param name="p_dtmBegin">帐务期开始时间</param>
        /// <param name="p_dtmEnd">帐务期结束时间</param>
        /// <param name="p_strLastAccountID">上一次帐务期ID</param>
        /// <param name="p_strAccountID">本次帐务期ID</param>
        /// <param name="p_objValueArr">帐表内容</param>
        /// <returns></returns>
        public long m_lngGetMedicineTypeAccount(string p_strStorageID, string p_strMedicineTypeSetID, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strLastAccountID, string p_strAccountID, out clsMS_TotalAccountVO[] p_objValueArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_AccountSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_AccountSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_AccountSVC));
            lngRes = objSvc.m_lngGetMedicineTypeAccount(objPrincipal, p_strStorageID, p_strMedicineTypeSetID, p_dtmBegin, p_dtmEnd, p_strLastAccountID, p_strAccountID, out p_objValueArr);
            return lngRes;
        }
        #endregion

        #region 根据药品类型获取药品帐表(未结转)
        /// <summary>
        /// 根据药品类型获取药品帐表(未结转)
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicineTypeSetID">药品类型(大类)</param>
        /// <param name="p_dtmBegin">帐务期开始时间</param>
        /// <param name="p_dtmEnd">帐务期结束时间</param>
        /// <param name="p_strLastAccountID">上一次帐务期ID</param>
        /// <param name="p_strAccountID">本次帐务期ID</param>
        /// <param name="p_objValueArr">帐表内容</param>
        /// <returns></returns>
        public long m_lngGetMedicineTypeAccountNoAcc(string p_strStorageID, string p_strMedicineTypeSetID, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strLastAccountID, string p_strAccountID, out clsMS_TotalAccountVO[] p_objValueArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_AccountSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_AccountSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_AccountSVC));
            lngRes = objSvc.m_lngGetMedicineTypeAccountNoAcc(objPrincipal, p_strStorageID, p_strMedicineTypeSetID, p_dtmBegin, p_dtmEnd, p_strLastAccountID, p_strAccountID, out p_objValueArr);
            return lngRes;
        }
        #endregion

        #region 获取指定帐务期所有药品明细
        /// <summary>
        /// 获取指定帐务期所有药品明细        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">帐务期开始时间</param>
        /// <param name="p_dtmEnd">帐务期结束时间</param>
        /// <param name="p_strLastAccountID">上一次帐务期ID</param>
        /// <param name="p_strAccountID">本次帐务期ID</param>
        /// <param name="p_objValueArr">帐表内容</param>
        /// <returns></returns>
        public long m_lngGetAllMedicineDetailAccount(string p_strStorageID,  DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strLastAccountID, string p_strAccountID, out clsMS_TotalAccountVO[] p_objValueArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_AccountSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_AccountSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_AccountSVC));
            lngRes = objSvc.m_lngGetAllMedicineDetailAccount(objPrincipal, p_strStorageID,  p_dtmBegin, p_dtmEnd, p_strLastAccountID, p_strAccountID, out p_objValueArr);
            return lngRes;
        }
        #endregion

        #region 获取指定帐务期所有药品明细(未结转)

        /// <summary>
        /// 获取指定帐务期所有药品明细(未结转)

        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">帐务期开始时间</param>
        /// <param name="p_dtmEnd">帐务期结束时间</param>
        /// <param name="p_strLastAccountID">上一次帐务期ID</param>
        /// <param name="p_strAccountID">本次帐务期ID</param>
        /// <param name="p_objValueArr">帐表内容</param>
        /// <returns></returns>
        public long m_lngGetAllMedicineDetailAccountNoAcc(string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strLastAccountID, string p_strAccountID, out clsMS_TotalAccountVO[] p_objValueArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_AccountSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_AccountSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_AccountSVC));
            lngRes = objSvc.m_lngGetAllMedicineDetailAccountNoAcc(objPrincipal, p_strStorageID, p_dtmBegin, p_dtmEnd, p_strLastAccountID, p_strAccountID, out p_objValueArr);
            return lngRes;
        }
        #endregion

        #region 获取仓库名称
        /// <summary>
        /// 获取仓库名称
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strStorageName"></param>
        /// <returns></returns>
        internal long m_lngGetStoreRoomName(string p_strStorageID, out string p_strStorageName)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC));

            lngRes = objSvc.m_lngGetStoreRoomName(objPrincipal, p_strStorageID, out p_strStorageName);

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
    }
}
