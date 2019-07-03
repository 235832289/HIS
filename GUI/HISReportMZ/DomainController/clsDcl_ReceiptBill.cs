using System;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.middletier.HIS; //HIS_SVC.DLL
using System.Data;
using com.digitalwave.iCare.middletier.HIS.Reports;
using com.digitalwave.iCare.common;
using com.digitalwave.Utility;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public class clsDcl_ReceiptBill : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 获取发票分类明细
        /// <summary>
        /// 获取发票分类明细
        /// </summary>
        /// <param name="strINVOICENO"></param>
        /// <param name="strSEQID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngGetRecipeDataByChargeNo(string ChargeNo, ref DataTable dtRecipeSumde)
        {
            com.digitalwave.iCare.middletier.HIS.Reports.clsReceiptBillSvc objSvc =
                                                                   (com.digitalwave.iCare.middletier.HIS.Reports.clsReceiptBillSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsReceiptBillSvc));
            long lngRes = objSvc.m_lngGetRecipeDataByChargeNo(ChargeNo, ref dtRecipeSumde);
            objSvc.Dispose();

            return lngRes;
        }
        #endregion

        #region 根据处方号获取病人信息
        /// <summary>
        /// 根据处方号获取病人信息
        /// </summary>
        /// <param name="p_recipeNO"></param>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        public long m_lngGetPatientInfo(string ChargeNO, ref DataTable dtResult)
        {
            com.digitalwave.iCare.middletier.HIS.Reports.clsReceiptBillSvc objSvc =
                                                                   (com.digitalwave.iCare.middletier.HIS.Reports.clsReceiptBillSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsReceiptBillSvc));
            long l = objSvc.m_lngGetPatientInfo(ChargeNO, ref  dtResult);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 通过日期查询欠费病人
        /// <summary>
        /// 通过日期查询欠费病人
        /// </summary>
        /// <param name="p_strStartDate"></param>
        /// <param name="p_strEndDate"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        internal long m_lngQueryArrearsPatientByDate(string p_strStartDate, string p_strEndDate, out DataTable p_dtResult, bool p_blnALL)
        {
            long lngRes = 0;
            p_dtResult = null;

            #region 中间件操作
            clsOPChargeSvc objServ = null;
            try
            {
                objServ = (clsOPChargeSvc)clsObjectGenerator.objCreatorObjectByType(typeof(clsOPChargeSvc));
                lngRes = objServ.m_lngQueryArrearsPatientByDate(objPrincipal, p_strStartDate, p_strEndDate, out p_dtResult, p_blnALL);
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogError("连接中间件操作异常，" + objEx.Message);
            }
            finally
            {
                if (objServ != null)
                {
                    objServ.Dispose();
                    objServ = null;
                }
            }
            #endregion
            return lngRes;
        }
        #endregion

        #region 通过日期查询缴费病人
        /// <summary>
        /// 通过日期查询缴费病人
        /// </summary>
        /// <param name="p_strStartDate"></param>
        /// <param name="p_strEndDate"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        internal long m_lngQueryPayedPatientByDate(string p_strStartDate, string p_strEndDate, out DataTable p_dtResult)
        {
            long lngRes = 0;
            p_dtResult = null;

            #region 中间件操作
            clsOPChargeSvc objServ = null;
            try
            {
                objServ = (clsOPChargeSvc)clsObjectGenerator.objCreatorObjectByType(typeof(clsOPChargeSvc));
                lngRes = objServ.m_lngQueryPayedPatientByDate(objPrincipal, p_strStartDate, p_strEndDate, out p_dtResult);
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogError("连接中间件操作异常，" + objEx.Message);
            }
            finally
            {
                if (objServ != null)
                {
                    objServ.Dispose();
                    objServ = null;
                }
            }
            #endregion
            return lngRes;
        }
        #endregion

        #region 获取系统时间
        /// <summary>
        /// 获取系统时间
        /// </summary>
        /// <returns></returns>
        public DateTime m_datGetServerDate()
        {
            DateTime datNow = DateTime.Now;
            clsOPChargeSvc objServ = null;
            try
            {
                objServ = (clsOPChargeSvc)clsObjectGenerator.objCreatorObjectByType(typeof(clsOPChargeSvc));
                datNow = objServ.m_datGetSeverDate();
                return datNow;
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogError("连接中间件操作异常，" + objEx.Message);
            }
            finally
            {
                if (objServ != null)
                {
                    objServ.Dispose();
                    objServ = null;
                }
            }
            return datNow;
        }
        #endregion  
    }
}
