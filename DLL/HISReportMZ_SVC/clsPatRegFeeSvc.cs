using System;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
using System.EnterpriseServices;
using System.Data;

namespace com.digitalwave.iCare.middletier.HIS.Reports
{
    /// <summary>
    /// 挂号费与诊金的维护
    /// </summary>
    [Transaction(TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsPatRegFeeSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        public clsPatRegFeeSvc()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 新增挂号费与诊金
        /// <summary>
        /// 新增挂号费与诊金
        /// </summary>
        [AutoComplete]
        public long m_lngNewFeeList(System.Security.Principal.IPrincipal objPri,
            clsPatRegFee_VO clsVO)
        {
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            long lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc", "m_lngFindWaitDiagList");
            if (lngRes < 0)
                return lngRes;

            string strSQL = @"insert into t_oppatregamount
            (registertypeid_chr, paytypeid_chr, regfee, diagfee
            )
     values (?, ?, ?, ?
            )";
            System.Data.IDataParameter[] objPara = clsIDataParameterCreator.s_objConstructIDataParameterArr
                (new object[] { clsVO.m_strRegisterTypeID, clsVO.m_strPayTypeID, clsVO.m_decRegFee, clsVO.m_decDiagFee });
            try
            {
                long lngRec = 0;
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();
                lngRes = HRPSvc.lngExecuteParameterSQL(strSQL, ref lngRec, objPara);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                lngRes = -2;
            }
            return lngRes;
        }
        #endregion

        #region 修改挂号费与诊金
        /// <summary>
        /// 修改挂号费与诊金
        /// </summary>
        [AutoComplete]
        public long m_lngUPDateFeeList(System.Security.Principal.IPrincipal objPri,
            clsPatRegFee_VO clsVO)
        {
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            long lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc", "m_lngFindWaitDiagList");
            if (lngRes < 0)
                return lngRes;

            string strSQL = @"UPDate t_opPatRegAmount Set regfee=?,diagfee=?
                             Where registertypeid_chr=? And paytypeid_chr=?";
            System.Data.IDataParameter[] objPara = clsIDataParameterCreator.s_objConstructIDataParameterArr
                (new object[] { clsVO.m_decRegFee, clsVO.m_decDiagFee, clsVO.m_strRegisterTypeID, clsVO.m_strPayTypeID });
            try
            {
                long lngRec = 0;
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();
                lngRes = HRPSvc.lngExecuteParameterSQL(strSQL, ref lngRec, objPara);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                lngRes = -2;
            }
            return lngRes;
        }
        #endregion

        #region 删除挂号费与诊金
        /// <summary>
        /// 删除挂号费与诊金
        /// </summary>
        [AutoComplete]
        public long m_lngDelFeeList(System.Security.Principal.IPrincipal objPri,
            clsPatRegFee_VO clsVO)
        {
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            long lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc", "m_lngFindWaitDiagList");
            if (lngRes < 0)
                return lngRes;

            string strSQL = @"Delete t_opPatRegAmount 
                             Where registertypeid_chr=? And paytypeid_chr=?";
            System.Data.IDataParameter[] objPara = clsIDataParameterCreator.s_objConstructIDataParameterArr
                (new object[] { clsVO.m_strRegisterTypeID, clsVO.m_strPayTypeID });
            try
            {
                long lngRec = 0;
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();
                lngRes = HRPSvc.lngExecuteParameterSQL(strSQL, ref lngRec, objPara);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                lngRes = -2;
            }
            return lngRes;
        }
        #endregion

        #region 查找挂号费与诊金
        /// <summary>
        /// 查找挂号费与诊金
        /// </summary>
        [AutoComplete]
        public long m_lngFindFeeList(System.Security.Principal.IPrincipal objPri,
            ref DataTable dtResult)
        {
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            long lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc", "m_lngFindWaitDiagList");
            if (lngRes < 0)
                return lngRes;

            string strSQL = @"Select a.registertypeid_chr,a.paytypeid_chr,a.regfee,a.diagfee,
                            b.registertypename_vchr,c.paytypename_vchr from t_opPatRegAmount a,
                            t_bse_registertype b,t_bse_patientpaytype c  
                            Where a.registertypeid_chr=b.registertypeid_chr 
                            And a.paytypeid_chr=c.paytypeid_chr";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();
                lngRes = HRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtResult);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                lngRes = -2;
            }
            return lngRes;
        }
        #endregion

        #region 根据病人类型ID和挂号类型ID查找记录
        /// <summary>
        /// 根据病人类型ID和挂号类型ID查找记录
        /// </summary>
        [AutoComplete]
        public long m_lngFindFeeListByID(System.Security.Principal.IPrincipal objPri,
            string RegTypeID, string PatTypeID, out clsPatRegFee_VO clsVO)
        {
            clsVO = new clsPatRegFee_VO();
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            long lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc", "m_lngFindWaitDiagList");
            if (lngRes < 0)
                return lngRes;

            string strSQL = @"Select a.registertypeid_chr,a.paytypeid_chr,a.regfee,a.diagfee,
                            b.registertypename_vchr,c.paytypename_vchr from t_opPatRegAmount a,
                            t_bse_registertype b,t_bse_patientpaytype c  
                            Where a.registertypeid_chr=? And a.paytypeid_chr=? 
                            And a.registertypeid_chr=b.registertypeid_chr 
                            And a.paytypeid_chr=c.paytypeid_chr";
            System.Data.IDataParameter[] objPara = clsIDataParameterCreator.s_objConstructIDataParameterArr(new object[] { RegTypeID, PatTypeID });
            try
            {
                DataTable dtResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();
                lngRes = HRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, objPara);
                if (lngRes < 0)
                    return lngRes;
                if (dtResult.Rows.Count == 0)
                    return 0;
                clsVO.m_strPayTypeID = PatTypeID;
                clsVO.m_strRegisterTypeID = RegTypeID;
                clsVO.m_decRegFee = decimal.Parse(dtResult.Rows[0]["regfee"].ToString().Trim());
                clsVO.m_decDiagFee = decimal.Parse(dtResult.Rows[0]["diagfee"].ToString().Trim());
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                lngRes = -2;
            }
            return lngRes;
        }
        #endregion

        //返回挂号收费
        #region  返回挂号收费标准 zlc 2004-8-3
        /// <summary>
        ///  返回挂号收费
        /// </summary>
        [AutoComplete]
        public long m_lngGetRegCharge(System.Security.Principal.IPrincipal p_objPrincipal, out clsRegisterPay[] objResult)
        {
            objResult = new clsRegisterPay[0];
            long lngRes = 0;
            //权限类
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc", "m_lngGetRegCharge");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = @"select a.registertypeid_chr, a.registertypename_vchr, a.chargeid_chr,
       a.chargename_chr, a.paytypeid_chr, a.paytypename_vchr, a.payment_mny,
       a.discount_dec, a.memo_vchr
  from v_bse_registercharge a ";
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();

                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    objResult = new clsRegisterPay[dtbResult.Rows.Count];

                    for (int i1 = 0; i1 < objResult.Length; i1++)
                    {
                        objResult[i1] = new clsRegisterPay();
                        objResult[i1].m_strREGISTERTYPEID_CHR = dtbResult.Rows[i1]["REGISTERTYPEID_CHR"].ToString().Trim();
                        objResult[i1].m_strREGISTERTYPENAME_VCHR = dtbResult.Rows[i1]["REGISTERTYPENAME_VCHR"].ToString().Trim();
                        objResult[i1].m_strCHARGEID_CHR = dtbResult.Rows[i1]["CHARGEID_CHR"].ToString().Trim();
                        objResult[i1].m_strCHARGENAME_CHR = dtbResult.Rows[i1]["CHARGENAME_CHR"].ToString().Trim();
                        objResult[i1].m_strPAYTYPEID_CHR = dtbResult.Rows[i1]["PAYTYPEID_CHR"].ToString().Trim();
                        objResult[i1].m_strPAYTYPENAME_VCHR = dtbResult.Rows[i1]["PAYTYPENAME_VCHR"].ToString().Trim();
                        objResult[i1].m_strMEMO_VCHR = dtbResult.Rows[i1]["MEMO_VCHR"].ToString().Trim();
                        if (dtbResult.Rows[i1]["PAYMENT_MNY"] != Convert.DBNull)
                            objResult[i1].m_dblPAYMENT_MNY = double.Parse(dtbResult.Rows[i1]["PAYMENT_MNY"].ToString());
                        if (dtbResult.Rows[i1]["DISCOUNT_DEC"] != Convert.DBNull)
                            objResult[i1].m_fltDISCOUNT_DEC = float.Parse(dtbResult.Rows[i1]["DISCOUNT_DEC"].ToString());
                        //						if(dtbResult.Rows[i1]["DIAGPAY_MNY"].ToString().Trim()!="")
                        //						   objResult[i1].m_decDiagPay=decimal.Parse(dtbResult.Rows[i1]["DIAGPAY_MNY"].ToString().Trim());
                        //						if(dtbResult.Rows[i1]["REGPAY_MNY"].ToString().Trim()!="")
                        //						objResult[i1].m_decRegPay=decimal.Parse(dtbResult.Rows[i1]["REGPAY_MNY"].ToString().Trim());
                    }
                }
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
