using System;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
using System.EnterpriseServices;
using System.Collections;
using System.Data;
using System.IO;
namespace com.digitalwave.iCare.middletier.HIS
{
    [Transaction(TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsOPInvoiceRptSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 根据操作员Id和日期查找门诊发票信息
        /// <summary>
        /// 根据操作员Id和日期查找门诊发票信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strOperatorId"></param>
        /// <param name="p_strStartDate"></param>
        /// <param name="p_strEndDate"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetInvoiceInfoByDate(System.Security.Principal.IPrincipal p_objPrincipal,
                                                 string p_strOperatorId,
                                                 string p_strStartDate,
                                                 string p_strEndDate,string p_strBalanceDeptID,
                                                 out DataTable p_dtResult)
        {
            long lngRes = 0;
            p_dtResult = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc", "GetCheckoutPrepayReport");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"select a.invoiceno_vchr,
                                   a.recorddate_dat,
                                   a.opremp_chr,
                                   a.status_int,
                                   a.seqid_chr,
                                   a.balanceemp_chr,
                                   a.paytypeid_chr,
                                   a.acctsum_mny,
                                   a.sbsum_mny,
                                   a.totalsum_mny - nvl(a.totaldiffcost_mny,0) totalsum_mny,
                                   a.paytype_int,
                                   a.opremp_chr,
                                   b.empid_chr,
                                   b.empno_chr,
                                   b.lastname_vchr
                              from t_opr_outpatientrecipeinv   a,
                                   t_bse_employee b
                             where a.balanceemp_chr = b.empid_chr
                               and a.balanceflag_int = 1
                               and (a.isvouchers_int < 2 or a.isvouchers_int is null)
                               and a.balanceemp_chr = ?
                               and a.balance_dat >= ?
                               and a.balance_dat <= ?
                               and a.balance_dat between to_date(?,'yyyy-mm-dd hh24:mi:ss')
                               and to_date(?,'yyyy-mm-dd hh24:mi:ss')
                             order by b.empno_chr,a.invoiceno_vchr";

            string strSQL1 = @"select a.invoiceno_vchr,
       a.recorddate_dat,
       a.opremp_chr,
       a.status_int,
       a.seqid_chr,
       a.balanceemp_chr,
       a.paytypeid_chr,
       a.acctsum_mny,
       a.sbsum_mny,
       a.totalsum_mny - nvl(a.totaldiffcost_mny,0) totalsum_mny,
       a.paytype_int,
       a.opremp_chr,
       b.empid_chr,
       b.empno_chr,
       b.lastname_vchr
  from t_opr_outpatientrecipeinv a, t_bse_employee b
 where a.balanceemp_chr = b.empid_chr
   and a.chargedeptid_chr=?
   and a.balanceflag_int = 1
   and (a.isvouchers_int < 2 or a.isvouchers_int is null)
   and a.balanceemp_chr = ?
   AND a.balance_dat >= ?
   AND a.balance_dat <= ?
   and a.balance_dat between to_date(?,'yyyy-mm-dd hh24:mi:ss')
   and to_date(?,'yyyy-mm-dd hh24:mi:ss')
 order by b.empno_chr, a.invoiceno_vchr";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                //lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtResult);
                System.Data.IDataParameter[] arrParams = null;
                if (p_strBalanceDeptID.Trim() == "1000")
                {
                    new clsHRPTableService().CreateDatabaseParameter(5, out arrParams);
                    arrParams[0].Value = p_strOperatorId;
                    arrParams[1].Value = System.DateTime.Parse(p_strStartDate);
                    arrParams[2].Value = System.DateTime.Parse(p_strEndDate);
                    arrParams[3].Value = p_strStartDate;
                    arrParams[4].Value = p_strEndDate;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtResult, arrParams);
                }
                else
                {
                    new clsHRPTableService().CreateDatabaseParameter(6, out arrParams);
                    arrParams[0].Value=p_strBalanceDeptID;
                    arrParams[1].Value = p_strOperatorId;
                    arrParams[2].Value = System.DateTime.Parse(p_strStartDate);
                    arrParams[3].Value = System.DateTime.Parse(p_strEndDate);
                    arrParams[4].Value = p_strStartDate;
                    arrParams[5].Value = p_strEndDate;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL1, ref p_dtResult, arrParams);
                }
                objHRPSvc.Dispose();

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }
        #endregion      

        #region 根据日期查找门诊发票信息
        /// <summary>
        /// 根据日期查找门诊发票信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strOperatorId"></param>
        /// <param name="p_strStartDate"></param>
        /// <param name="p_strEndDate"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetInvoiceInfoByDate(System.Security.Principal.IPrincipal p_objPrincipal,
                                                 string p_strStartDate,
                                                 string p_strEndDate,string p_strBalanceDeptID,
                                                 out DataTable p_dtResult)
        {
            long lngRes = 0;
            p_dtResult = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc", "GetCheckoutPrepayReport");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"select a.invoiceno_vchr,
                                   a.recorddate_dat,
                                   a.opremp_chr,
                                   a.status_int,
                                   a.seqid_chr,
                                   a.balanceemp_chr,
                                   a.paytypeid_chr,
                                   a.acctsum_mny,
                                   a.sbsum_mny,
                                   a.totalsum_mny - nvl(a.totaldiffcost_mny,0) totalsum_mny,
                                   a.paytype_int,
                                   a.opremp_chr,
                                   b.empid_chr,
                                   b.empno_chr,
                                   b.lastname_vchr
                              from t_opr_outpatientrecipeinv   a,
                                   t_bse_employee b
                             where a.balanceemp_chr = b.empid_chr
                               and a.balanceflag_int = 1
                               and (a.isvouchers_int < 2 or a.isvouchers_int is null)
                               and a.balance_dat >= ?
                               and a.balance_dat <= ?
                               and a.balance_dat between to_date(?,'yyyy-mm-dd hh24:mi:ss')
                               and to_date(?,'yyyy-mm-dd hh24:mi:ss')
                             order by b.empno_chr,a.invoiceno_vchr";

            string strSQL1 = @"select a.invoiceno_vchr,
                                   a.recorddate_dat,
                                   a.opremp_chr,
                                   a.status_int,
                                   a.seqid_chr,
                                   a.balanceemp_chr,
                                   a.paytypeid_chr,
                                   a.acctsum_mny,
                                   a.sbsum_mny,
                                   a.totalsum_mny - nvl(a.totaldiffcost_mny,0) totalsum_mny,
                                   a.paytype_int,
                                   a.opremp_chr,
                                   b.empid_chr,
                                   b.empno_chr,
                                   b.lastname_vchr
                              from t_opr_outpatientrecipeinv   a,
                                   t_bse_employee b
                             where a.balanceemp_chr = b.empid_chr
                               and a.chargedeptid_chr=?
                               and a.balanceflag_int = 1
                               and (a.isvouchers_int < 2 or a.isvouchers_int is null)
                               and a.balance_dat >= ?
                               and a.balance_dat <= ?
                               and a.balance_dat between to_date(?,'yyyy-mm-dd hh24:mi:ss')
                               and to_date(?,'yyyy-mm-dd hh24:mi:ss')
                             order by b.empno_chr,a.invoiceno_vchr";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                //lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtResult);
                if (p_strBalanceDeptID == "1000")
                {
                    System.Data.IDataParameter[] arrParams = null;
                    new clsHRPTableService().CreateDatabaseParameter(4, out arrParams);
                    arrParams[0].Value = System.DateTime.Parse(p_strStartDate);
                    arrParams[1].Value = System.DateTime.Parse(p_strEndDate);
                    arrParams[2].Value = p_strStartDate;
                    arrParams[3].Value = p_strEndDate;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtResult, arrParams);
                }
                else
                {
                    System.Data.IDataParameter[] arrParams = null;
                    new clsHRPTableService().CreateDatabaseParameter(5, out arrParams);
                    arrParams[0].Value = p_strBalanceDeptID;
                    arrParams[1].Value = System.DateTime.Parse(p_strStartDate);
                    arrParams[2].Value = System.DateTime.Parse(p_strEndDate);
                    arrParams[3].Value = p_strStartDate;
                    arrParams[4].Value = p_strEndDate;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL1, ref p_dtResult, arrParams);
                }
                objHRPSvc.Dispose();

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }
        #endregion      

        #region 根据操作员Id和日期查找门诊重打发票信息
        /// <summary>
        /// 根据操作员Id和日期查找门诊重打发票信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strOperatorId"></param>
        /// <param name="p_strStartDate"></param>
        /// <param name="p_strEndDate"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetInvoiceReprintByDate(System.Security.Principal.IPrincipal p_objPrincipal,
                                                 string p_strOperatorId,
                                                 string p_strStartDate,
                                                 string p_strEndDate,string p_strBalanceDeptID,
                                                 out DataTable p_dtResult)
        {
            long lngRes = 0;
            p_dtResult = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc", "GetCheckoutPrepayReport");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT a.sourceinvono_vchr,
                                     a.repprninvono_vchr,
                                     a.printemp_chr,
                                     a.printstatus_int,
                                     b.empid_chr,
                                     b.empno_chr,
                                     b.lastname_vchr
                             FROM t_opr_invoicerepeatprint a,
                                  t_bse_employee b
                             WHERE a.printemp_chr = b.empid_chr
                               AND a.type_chr = 1
                               AND a.printemp_chr = ?
                               AND a.printdate_dat >= ?
                               AND a.printdate_dat <= ?";
            string strSQL1 = @"SELECT a.sourceinvono_vchr,
       a.repprninvono_vchr,
       a.printemp_chr,
       a.printstatus_int,
       b.empid_chr,
       b.empno_chr,
       b.lastname_vchr
  FROM t_opr_invoicerepeatprint a,
       t_bse_employee           b,
       t_opr_outpatientrecipeinv f
 WHERE a.printemp_chr = b.empid_chr
   and a.seqid_chr=f.seqid_chr
   and f.chargedeptid_chr=?
   AND a.type_chr = 1
   AND a.printemp_chr = ?
   AND a.printdate_dat >= ?
   AND a.printdate_dat <= ?
";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                //lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtResult);
                System.Data.IDataParameter[] arrParams = null;
                if (p_strBalanceDeptID.Trim() == "1000")
                {
                    new clsHRPTableService().CreateDatabaseParameter(3, out arrParams);
                    arrParams[0].Value = p_strOperatorId;
                    arrParams[1].Value = System.DateTime.Parse(p_strStartDate);
                    arrParams[2].Value = System.DateTime.Parse(p_strEndDate);
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtResult, arrParams);
                }
                else
                {
                    new clsHRPTableService().CreateDatabaseParameter(4, out arrParams);
                    arrParams[0].Value=p_strBalanceDeptID;
                    arrParams[1].Value = p_strOperatorId;
                    arrParams[2].Value = System.DateTime.Parse(p_strStartDate);
                    arrParams[3].Value = System.DateTime.Parse(p_strEndDate);
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL1, ref p_dtResult, arrParams);
                }
                objHRPSvc.Dispose();

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }
        #endregion

        #region 根据日期查找门诊重打发票信息
        /// <summary>
        /// 根据日期查找门诊重打发票信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strOperatorId"></param>
        /// <param name="p_strStartDate"></param>
        /// <param name="p_strEndDate"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetInvoiceReprintByDate(System.Security.Principal.IPrincipal p_objPrincipal,
                                                 string p_strStartDate,
                                                 string p_strEndDate,string p_strBalanceDeptID,
                                                 out DataTable p_dtResult)
        {
            long lngRes = 0;
            p_dtResult = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc", "GetCheckoutPrepayReport");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT a.sourceinvono_vchr,
                                     a.repprninvono_vchr,
                                     a.printemp_chr,
                                     a.printstatus_int,
                                     b.empid_chr,
                                     b.empno_chr,
                                     b.lastname_vchr
                             FROM t_opr_invoicerepeatprint a,
                                  t_bse_employee b
                             WHERE a.printemp_chr = b.empid_chr
                               AND a.type_chr = 1
                               AND a.printdate_dat >= ?
                               AND a.printdate_dat <= ?";
            string strSQL1 = @"SELECT a.sourceinvono_vchr,
       a.repprninvono_vchr,
       a.printemp_chr,
       a.printstatus_int,
       b.empid_chr,
       b.empno_chr,
       b.lastname_vchr
  FROM t_opr_invoicerepeatprint a,
       t_bse_employee           b,
       t_opr_outpatientrecipeinv f
 WHERE a.printemp_chr = b.empid_chr
   and a.seqid_chr=f.seqid_chr
   and f.chargedeptid_chr=?
   AND a.type_chr = 1
   AND a.printdate_dat >= ?
   AND a.printdate_dat <= ?";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                //lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtResult);
                System.Data.IDataParameter[] arrParams = null;
                if (p_strBalanceDeptID.Trim() == "1000")
                {
                    new clsHRPTableService().CreateDatabaseParameter(2, out arrParams);
                    arrParams[0].Value = System.DateTime.Parse(p_strStartDate);
                    arrParams[1].Value = System.DateTime.Parse(p_strEndDate);
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtResult, arrParams);
                }
                else
                {
                    new clsHRPTableService().CreateDatabaseParameter(3, out arrParams);
                    arrParams[0].Value = p_strBalanceDeptID;
                    arrParams[1].Value = System.DateTime.Parse(p_strStartDate);
                    arrParams[2].Value = System.DateTime.Parse(p_strEndDate);
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL1, ref p_dtResult, arrParams);
                }
                objHRPSvc.Dispose();

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }
        #endregion      
    }
}
