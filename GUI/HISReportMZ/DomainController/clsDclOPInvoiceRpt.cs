using System;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.middletier.HIS; //HIS_SVC.DLL
using System.Data;
using System.Collections;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 门诊发票报表
    /// </summary>
    public class clsDclOPInvoiceRpt : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 根据操作员Id和日期查找门诊发票信息
        /// <summary>
        /// 根据操作员Id和日期查找门诊发票信息
        /// </summary>
        /// <param name="p_strOperatorId"></param>
        /// <param name="p_strStartDate"></param>
        /// <param name="p_strEndDate"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        public long GetInvoiceInfoByDate(string p_strOperatorId, string p_strStartDate, string p_strEndDate,string p_strBalanceDeptID, out DataTable p_dtResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsOPInvoiceRptSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOPInvoiceRptSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPInvoiceRptSvc));
            long lngRes = objSvc.GetInvoiceInfoByDate(objPrincipal, p_strOperatorId, p_strStartDate, p_strEndDate,p_strBalanceDeptID, out p_dtResult);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 根据日期查找门诊发票信息
        /// <summary>
        /// 根据日期查找门诊发票信息
        /// </summary>
        /// <param name="p_strStartDate"></param>
        /// <param name="p_strEndDate"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        public long GetInvoiceInfoByDate(string p_strStartDate, string p_strEndDate,string p_strBalanceDeptID, out DataTable p_dtResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsOPInvoiceRptSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOPInvoiceRptSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPInvoiceRptSvc));
            long lngRes = objSvc.GetInvoiceInfoByDate(objPrincipal, p_strStartDate, p_strEndDate,p_strBalanceDeptID, out p_dtResult);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 根据操作员Id和日期查找门诊重打发票信息
        /// <summary>
        /// 根据操作员Id和日期查找门诊重打发票信息
        /// </summary>
        /// <param name="p_strOperatorId"></param>
        /// <param name="p_strStartDate"></param>
        /// <param name="p_strEndDate"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        public long GetInvoiceReprintByDate(string p_strOperatorId, string p_strStartDate, string p_strEndDate,string p_strBalanceDeptID, out DataTable p_dtResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsOPInvoiceRptSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOPInvoiceRptSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPInvoiceRptSvc));
            long lngRes = objSvc.GetInvoiceReprintByDate(objPrincipal, p_strOperatorId, p_strStartDate, p_strEndDate,p_strBalanceDeptID, out p_dtResult);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 根据日期查找门诊重打发票信息
        /// <summary>
        /// 根据日期查找门诊重打发票信息
        /// </summary>
        /// <param name="p_strStartDate"></param>
        /// <param name="p_strEndDate"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        public long GetInvoiceReprintByDate(string p_strStartDate, string p_strEndDate,string p_strBalanceDeptID, out DataTable p_dtResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsOPInvoiceRptSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOPInvoiceRptSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPInvoiceRptSvc));
            long lngRes = objSvc.GetInvoiceReprintByDate(objPrincipal, p_strStartDate, p_strEndDate,p_strBalanceDeptID, out p_dtResult);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion
    }
}
