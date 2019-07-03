using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 预交金查询业务控制层
    /// 作者：He Guiqiu
    /// 创建时间:2006-06-17
    /// </summary>
    public class clsDclPrepayCheckout : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        public clsDclPrepayCheckout()
        { 
        
        }


        #region 根据收款员ID查询未结算预收款信息
        /// <summary>
        /// 根据收款员ID查询未结算预收款信息
        /// </summary>
        /// <param name="p_strCreatorId"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        public long GetDisCheckoutPrepayInfoById(string p_strCreatorId, out DataTable p_dtResult)
        {
            long lngRes;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc));
            lngRes = objSvc.GetDisCheckoutPrepayInfoById(p_objPrincipal, p_strCreatorId, out p_dtResult);

            objSvc.Dispose();

            return lngRes;
        }
        #endregion

        #region 根据收款员ID和结算日期查询预收款结算信息
        /// <summary>
        /// 根据收款员ID和结算日期查询预收款结算信息
        /// </summary>
        /// <param name="p_strOperatorId">结帐人</param>
        /// <param name="p_strDate">结算日期</param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        public long GetCheckoutPrepayInfoById(string p_strOperatorId, string p_strDate, out DataTable p_dtResult)
        {
            long lngRes;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc));
            lngRes = objSvc.GetCheckoutPrepayInfoById(p_objPrincipal, p_strOperatorId, p_strDate, out p_dtResult);

            objSvc.Dispose();

            return lngRes;
        }
        #endregion

        #region 根据结帐流水号查询预收款结算信息
        /// <summary>
        /// 根据结帐流水号查询预收款结算信息
        /// </summary>
        /// <param name="p_strOperatorId">结帐流水号</param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        public long GetCheckoutPrepayInfoByBalanceId(string p_balanceId, out DataTable p_dtResult)
        {
            long lngRes;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc));
            lngRes = objSvc.GetCheckoutPrepayInfoByBalanceId(p_objPrincipal, p_balanceId, out p_dtResult);

            objSvc.Dispose();

            return lngRes;
        }
        #endregion

        #region 预收款结算历史信息
        /// <summary>
        /// 预收款结算历史信息
        /// </summary>
        /// <param name="p_strOperatorId"></param>
        /// <param name="p_strStartDate"></param>
        /// <param name="p_strEndDate"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        public long GetCheckoutPrepayHis(string p_strOperatorId, 
                                         string p_strStartDate, 
                                         string p_strEndDate, 
                                         out DataTable p_dtResult)
        {
            long lngRes;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc));
            lngRes = objSvc.GetCheckoutPrepayHis(p_objPrincipal, p_strOperatorId, p_strStartDate, p_strEndDate, out p_dtResult);

            objSvc.Dispose();

            return lngRes;
        }
        #endregion

        #region 重打预收单信息
        /// <summary>
        /// 重打预收单信息
        /// </summary>
        /// <param name="p_strOperatorId"></param>
        /// <param name="p_strStartDate"></param>
        /// <param name="p_strEndDate"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        public long GetReprintByPrintEmp(string p_strOperatorId,
                                         string p_strStartDate,
                                         string p_strEndDate,
                                         out DataTable p_dtResult)
        {
            long lngRes;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc));
            lngRes = objSvc.GetReprintByPrintEmp(p_objPrincipal, p_strOperatorId, p_strStartDate, p_strEndDate, out p_dtResult);

            objSvc.Dispose();

            return lngRes;
        }
        #endregion

        #region 最后一次结帐日期
        /// <summary>
        /// 最后一次结帐日期
        /// </summary>
        /// <param name="p_strOperatorId"></param>
        /// <param name="p_strStartDate"></param>
        /// <returns></returns>
        public long GetLastBalanceDate(string p_strBalanceEemId, out string p_strBalanceDate)
        {
            long lngRes;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc));
            lngRes = objSvc.GetLastBalanceDate(p_objPrincipal, p_strBalanceEemId, out p_strBalanceDate);

            objSvc.Dispose();

            return lngRes;
        }
        #endregion

        #region 上一次结帐日期
        /// <summary>
        /// 上一次结帐日期
        /// </summary>
        /// <param name="p_strOperatorId"></param>
        /// <param name="p_strStartDate"></param>
        /// <returns></returns>
        public long GetFrontBalanceDate(string p_strBalanceEemId, string p_strBalanceDate, out string p_strFrontBalanceDate)
        {
            long lngRes;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc));
            lngRes = objSvc.GetFrontBalanceDate(p_objPrincipal, p_strBalanceEemId, p_strBalanceDate, out p_strFrontBalanceDate);

            objSvc.Dispose();

            return lngRes;
        }
        #endregion

        #region 结帐
        /// <summary>
        /// 结帐
        /// </summary>
        /// <param name="p_dtPrepayData"></param>
        /// <param name="p_strOperatorId"></param>
        /// <returns></returns>
        public long CheckoutPrepayData(DataTable p_dtPrepayData, string p_strOperatorId, string p_strRemark)
        {
            com.digitalwave.iCare.middletier.HIS.clsHisBase hisBase =
                (com.digitalwave.iCare.middletier.HIS.clsHisBase)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsHisBase));
            
            string checkDate = hisBase.s_GetServerDate().ToString();
            
            long lngRes;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc));
            lngRes = objSvc.CheckOutPrepayData(p_objPrincipal, p_dtPrepayData, p_strOperatorId, checkDate, p_strRemark);

            hisBase.Dispose();
            objSvc.Dispose();

            return lngRes;
        }
        #endregion

        #region 修改备注信息
        /// <summary>
        /// 修改备注信息
        /// </summary>
        /// <param name="p_strBalaceId"></param>
        /// <param name="p_strRemark"></param>
        /// <returns></returns>
        public long ModifyBalanceRemark(string p_strBalaceId, string p_strRemark)
        {
                 
            long lngRes;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc));
            lngRes = objSvc.ModifyBalanceRemark(p_objPrincipal, p_strBalaceId, p_strRemark);

             objSvc.Dispose();

            return lngRes;
        }
        #endregion

        #region 根据操作员工号取其ID
        /// <summary>
        /// 根据操作员工号取其ID
        /// </summary>
        /// <param name="p_strEmpCode"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        public long GetEmpIdByCode(string p_strEmpCode, out DataTable p_dtResult)
        {
            long lngRes;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc));
            lngRes = objSvc.GetEmpIdByCode(p_objPrincipal, p_strEmpCode, out p_dtResult);

            objSvc.Dispose();

            return lngRes;
        }
        #endregion

        #region
        /// <summary>
        /// 根据发票号取得预交金信息
        /// </summary>
        /// <param name="p_strInvs"></param>
        /// <returns></returns>
        public long GetEmpIdByPreInvs(string p_strInvs, out DataTable p_dtResult)
        {
            long lngRes;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc));
            lngRes = objSvc.GetEmpIdByPreInvs(p_objPrincipal, p_strInvs, out p_dtResult);

            objSvc.Dispose();

            return lngRes;
        }
        #endregion
    }
}
