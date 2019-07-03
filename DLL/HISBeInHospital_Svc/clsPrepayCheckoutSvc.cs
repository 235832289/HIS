using System;
using System.Data;
using System.EnterpriseServices;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
using System.Collections;
using System.Collections.Generic;

namespace com.digitalwave.iCare.middletier.HIS
{
    /// <summary>
    /// 收费员预交金结帐
    /// 作者：He Guiqiu
    /// 创建时间:2006-06-14
    /// </summary>

    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsPrepayCheckoutSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        public clsPrepayCheckoutSvc()
        {
            //
        }

        #region 根据收款员ID查询未结算预收款信息
        /// <summary>
        /// 根据收款员ID查询未结算预收款信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strCreatorId"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetDisCheckoutPrepayInfoById(System.Security.Principal.IPrincipal p_objPrincipal, string p_strCreatorId, out DataTable p_dtResult)
        {
            long lngRes = 0;
            p_dtResult = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc", "GetDisCheckoutPrepayInfoById");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @" SELECT  PREPAYID_CHR,   
                                     PATIENTID_CHR,   
                                     REGISTERID_CHR,   
                                     LINER_INT,   
                                     PAYTYPE_INT,   
                                     CUYCATE_INT,   
                                     MONEY_DEC,   
                                     PREPAYINV_VCHR,   
                                     AREAID_CHR,   
                                     DES_VCHR,   
                                     CREATORID_CHR,   
                                     CREATE_DAT,   
                                     DEACTID_CHR,   
                                     DEACTIVATE_DAT,   
                                     STATUS_INT,   
                                     ISCLEAR_INT,   
                                     PRESSNO_VCHR,   
                                     UPTYPE_INT,   
                                     BALANCEEMP_CHR,   
                                     BALANCE_DAT,   
                                     PATIENTNAME_CHR,   
                                     AREANAME_VCHR,   
                                     BALANCEFLAG_INT,   
                                     BALANCEID_VCHR,   
                                     CONFIRMEMP_CHR,   
                                     CHARGENO_CHR,
                                     originvono_vchr  
                               FROM  T_OPR_BIH_PREPAY
                              WHERE BALANCEFLAG_INT = 0 AND CREATORID_CHR = ? ORDER BY PREPAYINV_VCHR";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;

                System.Data.IDataParameter[] arrParams = null;
                new clsHRPTableService().CreateDatabaseParameter(1, out arrParams);
                arrParams[0].Value = p_strCreatorId;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtResult, arrParams);

                //lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtResult);
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

        #region 根据收款员ID和结算日期查询预收款结算信息
        /// <summary>
        /// 根据收款员ID和结算日期查询预收款结算信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strOperatorId"></param>
        /// <param name="p_strDate"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetCheckoutPrepayInfoById(System.Security.Principal.IPrincipal p_objPrincipal, string p_strOperatorId, string p_strDate, out DataTable p_dtResult)
        {
            long lngRes = 0;
            p_dtResult = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc", "GetCheckoutPrepayInfoById");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT a.PREPAYID_CHR,   
                                     a.PATIENTID_CHR,   
                                     a.REGISTERID_CHR,   
                                     a.LINER_INT,   
                                     a.PAYTYPE_INT,   
                                     a.CUYCATE_INT,   
                                     a.MONEY_DEC,   
                                     a.PREPAYINV_VCHR,   
                                     a.AREAID_CHR,   
                                     a.DES_VCHR,   
                                     a.CREATORID_CHR,   
                                     a.CREATE_DAT,   
                                     a.DEACTID_CHR,   
                                     a.DEACTIVATE_DAT,   
                                     a.STATUS_INT,   
                                     a.ISCLEAR_INT,   
                                     a.PRESSNO_VCHR,   
                                     a.UPTYPE_INT,   
                                     a.BALANCEEMP_CHR,   
                                     a.BALANCE_DAT,   
                                     a.PATIENTNAME_CHR,   
                                     a.AREANAME_VCHR,   
                                     a.BALANCEFLAG_INT,   
                                     a.BALANCEID_VCHR,   
                                     a.CONFIRMEMP_CHR,   
                                     a.CHARGENO_CHR,   
                                     b.BALANCEID_VCHR,   
                                     b.BALANCEEMP_CHR,   
                                     b.BALANCE_DAT,   
                                     b.REMARK_VCHR,
                                     a.originvono_vchr 
                              FROM T_OPR_BIH_PREPAY a,   
                                   T_OPR_BIH_PREPAYBALANCE b
                              WHERE a.BALANCEID_VCHR = b.BALANCEID_VCHR AND
                              a.BALANCEFLAG_INT = 1 AND 
                              a.BALANCEEMP_CHR = ? AND a.BALANCE_DAT = ?
                              ORDER BY a.PREPAYINV_VCHR";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                //lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtResult);
                System.Data.IDataParameter[] arrParams = null;
                new clsHRPTableService().CreateDatabaseParameter(2, out arrParams);
                arrParams[0].Value = p_strOperatorId;
                arrParams[1].Value = System.DateTime.Parse(p_strDate);

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtResult, arrParams);

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

        #region 根据收款员ID和日期查询重打预收单信息
        /// <summary>
        ///根据收款员ID和日期查询重打预收单信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strEmpId"></param>
        /// <param name="p_strStartDate"></param>
        /// <param name="p_strEndDate"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetReprintByPrintEmp(System.Security.Principal.IPrincipal p_objPrincipal, string p_strEmpId, string p_strStartDate, string p_strEndDate, out DataTable p_dtResult)
        {
            long lngRes = 0;
            p_dtResult = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc", "GetReprintByPrintEmp");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT b.BILLTYPE_CHR,   
                                     b.BILLID_CHR,   
                                     b.SOURCEBILLNO_VCHR,   
                                     b.REPPRNBILLNO_VCHR,   
                                     b.PRINTEMP_CHR,   
                                     b.PRINTDATE_DAT,   
                                     b.PRINTSTATUS_INT,
                                     a.MONEY_DEC      
                                FROM T_OPR_BIH_PREPAY A,
                                     T_OPR_BIH_BILLREPEATPRINT B 
                                WHERE A.PREPAYID_CHR = B.BILLID_CHR AND
                                      B.BILLTYPE_CHR = '1' AND
                                      B.PRINTEMP_CHR = ? AND 
                                      (B.PRINTDATE_DAT BETWEEN ? AND ? ) ORDER BY B.BILLID_CHR";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                //lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtResult);
                System.Data.IDataParameter[] arrParams = null;
                new clsHRPTableService().CreateDatabaseParameter(3, out arrParams);
                arrParams[0].Value = p_strEmpId;
                arrParams[1].Value = System.DateTime.Parse(p_strStartDate);
                arrParams[2].Value = System.DateTime.Parse(p_strEndDate);

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtResult, arrParams);
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

        #region 根据结帐流水号查询预收款结算信息
        /// <summary>
        /// 根据结帐流水号查询预收款结算信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_balanceId"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetCheckoutPrepayInfoByBalanceId(System.Security.Principal.IPrincipal p_objPrincipal, string p_balanceId, out DataTable p_dtResult)
        {
            long lngRes = 0;
            p_dtResult = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc", "GetCheckoutPrepayInfoById");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @" SELECT a.PREPAYID_CHR,   
                                     a.PATIENTID_CHR,   
                                     a.REGISTERID_CHR,   
                                     a.LINER_INT,   
                                     a.PAYTYPE_INT,   
                                     a.CUYCATE_INT,   
                                     a.MONEY_DEC,   
                                     a.PREPAYINV_VCHR,   
                                     a.AREAID_CHR,   
                                     a.DES_VCHR,   
                                     a.CREATORID_CHR,   
                                     a.CREATE_DAT,   
                                     a.DEACTID_CHR,   
                                     a.DEACTIVATE_DAT,   
                                     a.STATUS_INT,   
                                     a.ISCLEAR_INT,   
                                     a.PRESSNO_VCHR,   
                                     a.UPTYPE_INT,   
                                     a.BALANCEEMP_CHR,   
                                     a.BALANCE_DAT,   
                                     a.PATIENTNAME_CHR,   
                                     a.AREANAME_VCHR,   
                                     a.BALANCEFLAG_INT,   
                                     a.BALANCEID_VCHR,   
                                     a.CONFIRMEMP_CHR,   
                                     a.CHARGENO_CHR,   
                                     b.BALANCEID_VCHR,   
                                     b.BALANCEEMP_CHR,   
                                     b.BALANCE_DAT,   
                                     b.REMARK_VCHR,
                                     a.originvono_vchr      
                               FROM  T_OPR_BIH_PREPAY a,T_OPR_BIH_PREPAYBALANCE b
                              WHERE a.BALANCEID_VCHR = b.BALANCEID_VCHR AND
                                    b.BALANCEID_VCHR = ? ORDER BY a.PREPAYINV_VCHR";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                //lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtResult);
                System.Data.IDataParameter[] arrParams = null;
                new clsHRPTableService().CreateDatabaseParameter(1, out arrParams);
                arrParams[0].Value = p_balanceId;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtResult, arrParams);

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

        #region 预收款结算历史信息
        /// <summary>
        /// 预收款结算历史信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strOperatorId"></param>
        /// <param name="p_strStartDate"></param>
        /// <param name="p_strEndDate"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetCheckoutPrepayHis(System.Security.Principal.IPrincipal p_objPrincipal,
                                         string p_strOperatorId,
                                         string p_strStartDate,
                                         string p_strEndDate,
                                         out DataTable p_dtResult)
        {
            long lngRes = 0;
            p_dtResult = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsPrepayQuerySvc", "GetCheckoutPrepayHis");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @" select BALANCEID_VCHR,   
                                     BALANCEEMP_CHR,   
                                     BALANCE_DAT,   
                                     REMARK_VCHR  
                               from T_OPR_BIH_PREPAYBALANCE 
                               where BALANCEEMP_CHR = ?
                               and (BALANCE_DAT between ? and ? ) ORDER BY BALANCE_DAT";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                //lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtResult);
                System.Data.IDataParameter[] arrParams = null;
                new clsHRPTableService().CreateDatabaseParameter(3, out arrParams);
                arrParams[0].Value = p_strOperatorId;
                arrParams[1].Value = System.DateTime.Parse(p_strStartDate);
                arrParams[2].Value = System.DateTime.Parse(p_strEndDate);

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtResult, arrParams);

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

        #region 结帐
        [AutoComplete]
        public long CheckOutPrepayData(System.Security.Principal.IPrincipal p_objPrincipal,
                                       DataTable p_dtPrepayData,
                                       string p_strOperatorId,
                                       string p_strDate,
                                       string p_strRemark)
        {
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            long lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "CheckOutPrepayData");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = "";
            if (p_dtPrepayData.Rows.Count > 0)
            {
                long lngRecEff = -1;
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] parm = null;
                string date = string.Empty;
                List<string> lstDate = new List<string>();
                // 微信特殊处理
                if (p_strOperatorId == "0000000")
                {
                    DataView dv = new DataView(p_dtPrepayData);
                    dv.Sort = "create_dat asc";
                    DataTable dt = dv.ToTable();
                    foreach (DataRow dr in dt.Rows)
                    {
                        date = Convert.ToDateTime(dr["create_dat"].ToString()).ToString("yyyy-MM-dd");
                        if (lstDate.IndexOf(date) < 0)
                        {
                            lstDate.Add(date);
                        }
                    }
                }

                //结帐流水号
                string balanceId = string.Empty;
                try
                {
                    if (lstDate.Count > 1)
                    {
                        for (int i = 0; i < lstDate.Count; i++)
                        {
                            DateTime dtmBalance = (i == lstDate.Count - 1) ? System.DateTime.Parse(p_strDate) : Convert.ToDateTime(lstDate[i] + " 23:59:59");
                            balanceId = GetNextNewId();
                            //插结帐备注表
                            strSQL = @"INSERT INTO T_OPR_BIH_PREPAYBALANCE (BALANCEID_VCHR, BALANCEEMP_CHR, BALANCE_DAT, REMARK_VCHR) VALUES (?, ?, ?, ?)";
                            objHRPSvc.CreateDatabaseParameter(4, out parm);
                            parm[0].Value = balanceId;
                            parm[1].Value = p_strOperatorId;
                            parm[2].Value = (i == lstDate.Count - 1) ? System.DateTime.Parse(p_strDate) : Convert.ToDateTime(lstDate[i] + " 23:59:59");
                            parm[3].Value = p_strRemark;
                            lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, parm);

                            if (i == lstDate.Count - 1)
                            {
                                strSQL = @"update T_OPR_BIH_PREPAY 
                                              set BALANCEEMP_CHR = ?, BALANCE_DAT = ?, BALANCEID_VCHR =?, BALANCEFLAG_INT = 1
                                            where BALANCEFLAG_INT = 0 AND CREATORID_CHR = ? and create_dat > to_date(?, 'yyyy-mm-dd hh24:mi:ss') ";
                                objHRPSvc.CreateDatabaseParameter(5, out parm);
                                parm[0].Value = p_strOperatorId;
                                parm[1].Value = dtmBalance;
                                parm[2].Value = balanceId;
                                parm[3].Value = p_strOperatorId;
                                parm[4].Value = lstDate[i - 1] + " 23:59:59";
                            }
                            else
                            {
                                strSQL = @"update T_OPR_BIH_PREPAY 
                                              set BALANCEEMP_CHR = ?, BALANCE_DAT = ?, BALANCEID_VCHR =?, BALANCEFLAG_INT = 1
                                            where BALANCEFLAG_INT = 0 AND CREATORID_CHR = ? and create_dat <= to_date(?, 'yyyy-mm-dd hh24:mi:ss') ";
                                objHRPSvc.CreateDatabaseParameter(5, out parm);
                                parm[0].Value = p_strOperatorId;
                                parm[1].Value = dtmBalance;
                                parm[2].Value = balanceId;
                                parm[3].Value = p_strOperatorId;
                                parm[4].Value = lstDate[i] + " 23:59:59";
                            }
                            lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, parm);
                        }
                    }
                    else
                    {
                        balanceId = GetNextNewId();
                        //插结帐备注表
                        strSQL = @"INSERT INTO T_OPR_BIH_PREPAYBALANCE (BALANCEID_VCHR, BALANCEEMP_CHR, BALANCE_DAT, REMARK_VCHR) VALUES (?, ?, ?, ?)";
                        objHRPSvc.CreateDatabaseParameter(4, out parm);
                        parm[0].Value = balanceId;
                        parm[1].Value = p_strOperatorId;
                        parm[2].Value = System.DateTime.Parse(p_strDate);
                        parm[3].Value = p_strRemark;
                        lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, parm);

                        strSQL = @"update T_OPR_BIH_PREPAY 
                                      set BALANCEEMP_CHR = ?, BALANCE_DAT = ?, BALANCEID_VCHR =?, BALANCEFLAG_INT = 1
                                    where BALANCEFLAG_INT = 0 AND CREATORID_CHR = ? ";
                        objHRPSvc.CreateDatabaseParameter(4, out parm);
                        parm[0].Value = p_strOperatorId;
                        parm[1].Value = System.DateTime.Parse(p_strDate);
                        parm[2].Value = balanceId;
                        parm[3].Value = p_strOperatorId;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, parm);
                    }
                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
                objHRPSvc.Dispose();
            }
            return lngRes;
        }
        #endregion

        #region 根据日期查找预收款结算备注信息
        /// <summary>
        /// 根据日期查找预收款结算备注信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStartDate"></param>
        /// <param name="p_strEndDate"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetPrepayBalanceRemarkByDate(System.Security.Principal.IPrincipal p_objPrincipal,
                                                 string p_strStartDate,
                                                 string p_strEndDate,
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
            string strSQL = @"SELECT BALANCEID_VCHR,   
                                     BALANCEEMP_CHR,   
                                     BALANCE_DAT,   
                                     REMARK_VCHR  
                                FROM T_OPR_BIH_PREPAYBALANCE 
                                WHERE T_OPR_BIH_PREPAYBALANCE.BALANCE_DAT BETWEEN ? AND ?
                                 ORDER BY T_OPR_BIH_PREPAYBALANCE.BALANCEEMP_CHR";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                //lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtResult);
                System.Data.IDataParameter[] arrParams = null;
                new clsHRPTableService().CreateDatabaseParameter(2, out arrParams);
                arrParams[0].Value = System.DateTime.Parse(p_strStartDate);
                arrParams[1].Value = System.DateTime.Parse(p_strEndDate);
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtResult, arrParams);

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

        #region 修改结算备注信息
        /// <summary>
        ///修改结算备注信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strBalanceId">流水号</param>
        /// <returns></returns>
        [AutoComplete]
        public long ModifyBalanceRemark(System.Security.Principal.IPrincipal p_objPrincipal, string p_strBalanceId, string p_strRemark)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc", "ModifyBalanceRemark");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @" UPDATE T_OPR_BIH_PREPAYBALANCE 
                              SET REMARK_VCHR = ? WHERE BALANCEID_VCHR = ?";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] parameterArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out parameterArr);
                parameterArr[0].Value = p_strRemark;
                parameterArr[1].Value = p_strBalanceId;

                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRes, parameterArr);
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

        #region 根据日期查找预收款结算信息
        /// <summary>
        /// 根据日期查找预收款结算信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStartDate"></param>
        /// <param name="p_strEndDate"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetPrepayBalanceInfoByDate(System.Security.Principal.IPrincipal p_objPrincipal,
                                                 string p_strStartDate,
                                                 string p_strEndDate,
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
            string strSQL = @"SELECT T_BSE_EMPLOYEE.EMPNO_CHR,   
                                     T_BSE_EMPLOYEE.FIRSTNAME_VCHR,
                                     T_BSE_EMPLOYEE.LASTNAME_VCHR,   
                                     T_OPR_BIH_PREPAY.PREPAYID_CHR,   
                                     T_OPR_BIH_PREPAY.PATIENTID_CHR,   
                                     T_OPR_BIH_PREPAY.REGISTERID_CHR,   
                                     T_OPR_BIH_PREPAY.LINER_INT,   
                                     T_OPR_BIH_PREPAY.PAYTYPE_INT,   
                                     T_OPR_BIH_PREPAY.CUYCATE_INT,   
                                     T_OPR_BIH_PREPAY.MONEY_DEC,   
                                     T_OPR_BIH_PREPAY.PREPAYINV_VCHR,   
                                     T_OPR_BIH_PREPAY.AREAID_CHR,   
                                     T_OPR_BIH_PREPAY.DES_VCHR,   
                                     T_OPR_BIH_PREPAY.CREATORID_CHR,   
                                     T_OPR_BIH_PREPAY.CREATE_DAT,   
                                     T_OPR_BIH_PREPAY.DEACTID_CHR,   
                                     T_OPR_BIH_PREPAY.DEACTIVATE_DAT,   
                                     T_OPR_BIH_PREPAY.STATUS_INT,   
                                     T_OPR_BIH_PREPAY.ISCLEAR_INT,   
                                     T_OPR_BIH_PREPAY.PRESSNO_VCHR,   
                                     T_OPR_BIH_PREPAY.UPTYPE_INT,   
                                     T_OPR_BIH_PREPAY.PATIENTNAME_CHR,   
                                     T_OPR_BIH_PREPAY.AREANAME_VCHR,   
                                     T_OPR_BIH_PREPAY.BALANCEFLAG_INT,   
                                     T_OPR_BIH_PREPAY.BALANCEEMP_CHR,   
                                     T_OPR_BIH_PREPAY.BALANCE_DAT,
                                     T_OPR_BIH_PREPAY.BALANCEID_VCHR,
                                     t_opr_bih_prepay.originvono_vchr     
                                FROM T_OPR_BIH_PREPAY,   
                                     T_BSE_EMPLOYEE  
                                WHERE ( T_OPR_BIH_PREPAY.BALANCEEMP_CHR = T_BSE_EMPLOYEE.EMPID_CHR ) AND 
                                      (T_OPR_BIH_PREPAY.BALANCE_DAT BETWEEN ? AND ? ) ORDER BY T_BSE_EMPLOYEE.EMPNO_CHR";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                //lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtResult);
                System.Data.IDataParameter[] arrParams = null;
                new clsHRPTableService().CreateDatabaseParameter(2, out arrParams);
                arrParams[0].Value = System.DateTime.Parse(p_strStartDate);
                arrParams[1].Value = System.DateTime.Parse(p_strEndDate);
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtResult, arrParams);

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

        #region 取上一次日结时间
        /// <summary>
        ///取上一次日结时间
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strBalanceEemId"></param>
        /// <param name="p_strBalanceDate"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetFrontBalanceDate(System.Security.Principal.IPrincipal p_objPrincipal, string p_strBalanceEemId, string p_strBalanceDate, out string p_strFrontBalanceDate)
        {
            p_strFrontBalanceDate = "";

            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc", "GetFrontBalanceDate");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @" SELECT MAX(BALANCE_DAT) BALANCE_DAT FROM  T_OPR_BIH_PREPAYBALANCE 
                               WHERE balanceemp_chr = ? and BALANCE_DAT < ?";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                DataTable dt = new DataTable();
                //lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
                System.Data.IDataParameter[] arrParams = null;
                new clsHRPTableService().CreateDatabaseParameter(2, out arrParams);
                arrParams[0].Value = p_strBalanceEemId;
                arrParams[1].Value = System.DateTime.Parse(p_strBalanceDate);
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, arrParams);

                if (lngRes > 0 && dt.Rows.Count > 0)
                {
                    p_strFrontBalanceDate = dt.Rows[0]["BALANCE_DAT"].ToString();
                }
                else
                {
                    p_strFrontBalanceDate = "";
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

        #region 取最一次日结时间
        /// <summary>
        ///取最后一次日结时间
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strBalanceEemId"></param>
        /// <param name="p_strBalanceDate"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetLastBalanceDate(System.Security.Principal.IPrincipal p_objPrincipal, string p_strBalanceEemId, out string p_strBalanceDate)
        {
            p_strBalanceDate = "";

            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsPrepayCheckoutSvc", "GetLastBalanceDate");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @" SELECT MAX(BALANCE_DAT) BALANCE_DAT FROM  T_OPR_BIH_PREPAYBALANCE 
                               WHERE balanceemp_chr = ?";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                DataTable dt = new DataTable();
                //lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
                System.Data.IDataParameter[] arrParams = null;
                new clsHRPTableService().CreateDatabaseParameter(1, out arrParams);
                arrParams[0].Value = p_strBalanceEemId;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, arrParams);

                if (lngRes > 0 && dt.Rows.Count > 0)
                {
                    p_strBalanceDate = dt.Rows[0]["BALANCE_DAT"].ToString();
                }
                else
                {
                    p_strBalanceDate = "";
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

        #region 获取序列SEQ_PREPAYBALANCE的下一个值
        /// <summary>
        /// 获取序列SEQ_PREPAYBALANCE的下一个值
        /// </summary>
        /// <returns></returns>
        [AutoComplete]
        private string GetNextNewId()
        {
            long lngRes = 0;

            string strSQL;
            strSQL = @"SELECT SEQ_PREPAYBALANCE.NEXTVAL FROM dual";

            System.Data.DataTable dtbResult = new System.Data.DataTable();

            string newId = "0";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();

                if (lngRes > 0 && dtbResult != null)
                {
                    newId = dtbResult.Rows[0][0].ToString().Trim();
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return newId;
        }
        #endregion

        #region 根据操作员工号取其ID
        /// <summary>
        /// 根据操作员工号取其ID
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strEmpCode"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetEmpIdByCode(System.Security.Principal.IPrincipal p_objPrincipal, string p_strEmpCode, out DataTable p_dtResult)
        {
            long lngRes = 0;
            p_dtResult = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsPrepayQuerySvc", "GetCheckoutPrepayHis");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @" select EMPID_CHR,   
                                     LASTNAME_VCHR  
                                     
                               from T_BSE_EMPLOYEE 
                               where EMPNO_CHR = ? ";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                //lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtResult);
                System.Data.IDataParameter[] arrParams = null;
                new clsHRPTableService().CreateDatabaseParameter(1, out arrParams);
                arrParams[0].Value = p_strEmpCode;


                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtResult, arrParams);

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

        #region
        /// <summary>
        /// 根据发票号取得预交金信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strEmpCode"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetEmpIdByPreInvs(System.Security.Principal.IPrincipal p_objPrincipal, string p_strEmpCode, out DataTable p_dtResult)
        {
            long lngRes = 0;
            p_dtResult = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsPrepayQuerySvc", "GetCheckoutPrepayHis");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"select t.CREATORID_CHR,
                                     t.DEACTID_CHR,
                                     t.PAYTYPE_INT,
                                     t.prepayinv_vchr,
                                     t.areaname_vchr,
                                     t.money_dec,t.BAlaNCEfLAG_INT,t.CREATE_DAT,t.BALANCE_DAT
                                from T_OPR_BIH_PREPAY t
                               where t.prepayinv_vchr = ?";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                //lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtResult);
                System.Data.IDataParameter[] arrParams = null;
                new clsHRPTableService().CreateDatabaseParameter(1, out arrParams);
                arrParams[0].Value = p_strEmpCode;


                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtResult, arrParams);

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
