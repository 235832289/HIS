using System;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
using com.digitalwave.iCare.middletier.PatientSvc;
//using com.digitalwave.GLS_WS.VO;

namespace com.digitalwave.iCare.middletier.HIS
{
    /// <summary>
    /// clsOrderBookingSvc
    /// 作者： He Guiqiu
    /// 创建时间： 2006-09-19
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsOrderBookingSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 常量
        private const string SQL_SELECT = @"SELECT  a.REGISTERID_CHR,
                                                    a.BOOKID_INT,      
                                                    a.OPERATE_DAT, 
                                                    a.ORDERID_CHR,    
                                                    a.ORDERNAME_VCHR,  
                                                    a.CHARGEITEMNAME_VCHR, 
                                                    a.UNIT_VCHR,
                                                    a.UNITPRICE_DEC,
                                                    a.AMOUNT_DEC,
                                                    a.Remark_Vchr,
                                                    a.BOOK_DAT,
                                                    a.BOOKSTATUS_INT,
                                                    a.CONFIRM_DAT,
                                                    a.APPLY_TYPE_INT,
                                                    a.PRINT_FLAG,
                                                    b.inpatientid_chr,
                                                    c.lastname_vchr,
                                                    c.sex_chr,
                                                    c.BIRTH_DAT,
                                                    d1.deptname_vchr CREATEAREA,
                                                    d2.deptname_vchr CURAREA,
                                                    d2.CODE_VCHR,
                                                    e.code_chr,
                                                    f1.lastname_vchr creator,
                                                    f2.lastname_vchr SENDER,
                                                    f3.lastname_vchr DOCTOR,
                                                    f4.lastname_vchr CONFIRMER,
                                                    k.patientcardid_chr 
                                              FROM T_OPR_BIH_ORDER_BOOKING a,
                                                   T_OPR_BIH_ORDER a1,
                                                   T_OPR_BIH_REGISTER b,
                                                   T_OPR_BIH_REGISTERDETAIL c,
                                                   T_BSE_DEPTDESC d1,
                                                   T_BSE_DEPTDESC d2,
                                                   T_BSE_BED e,
                                                   T_BSE_EMPLOYEE f1,
                                                   T_BSE_EMPLOYEE f2,
                                                   T_BSE_EMPLOYEE f3,
                                                   T_BSE_EMPLOYEE f4,
                                                   t_bse_patientcard k                                                    
                                            WHERE a.Registerid_Chr = b.registerid_chr AND
                                                  a.registerid_chr = c.registerid_chr AND
                                                  a.createarea_chr = d1.deptid_chr  AND
                                                  a.curareaid_chr = d2.deptid_chr AND
                                                  a.curbedid_chr = e.bedid_chr AND
                                                  a.ORDERID_CHR = a1.ORDERID_CHR and
                                                  a.createarea_chr = f1.empid_chr(+) AND
                                                  a.senderid_chr = f2.empid_chr(+) AND
                                                  a.doctorid_chr = f3.empid_chr(+) AND
                                                  a.confirmerid_chr = f4.empid_chr(+) and
                                                  b.patientid_chr = k.patientid_chr and 
                                                  (k.status_int = 1 or k.status_int = 3) ";
        #endregion

        #region Get by date
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AutoComplete]
        public long GetOrderBookByDate(System.Security.Principal.IPrincipal p_objPrincipal, string p_beginDate, string p_endDate, out DataTable p_dtResult)
        {
            p_dtResult = new DataTable();

            string strSQL;
            strSQL = SQL_SELECT + @" AND a.OPERATE_DAT>to_date('" + p_beginDate + @"','YYYY-MM-DD HH24:MI:SS') 
                      AND a.OPERATE_DAT<to_date('" + p_endDate + @"','YYYY-MM-DD HH24:MI:SS') 
                      ORDER BY d2.CODE_VCHR,e.code_chr";
            long lngRes = -1;

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtResult);
                objHRPSvc.Dispose();

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region Get by operatorId and date
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AutoComplete]
        public long GetOrderBookByDate(System.Security.Principal.IPrincipal p_objPrincipal, string p_beginDate, string p_endDate, string p_strOpratorId, out DataTable p_dtResult)
        {
            p_dtResult = new DataTable();

            string strSQL;
            strSQL = SQL_SELECT + @" AND a.OPERATE_DAT>to_date('" + p_beginDate + @"','YYYY-MM-DD HH24:MI:SS') 
                      AND a.OPERATE_DAT<to_date('" + p_endDate + @"','YYYY-MM-DD HH24:MI:SS') AND 
                      EXISTS (SELECT distinct atl.TYPEID 
                                        FROM ar_apply_typelist atl,
                                             T_OPR_CHECKDEPT_ROLE cdr,
                                             T_Sys_EmpRoleMap erm
                                        WHERE atl.TYPEID = cdr.APPLY_TYPE_INT and
                                              cdr.ROLEID_CHR = erm.ROLEID_CHR and
                                              a.APPLY_TYPE_INT = atl.TYPEID and
                                              atl.DELETED = 0 and 
                                              a.APPLY_TYPE_INT = atl.TYPEID and
                                              erm.EmpID_Chr='" + p_strOpratorId
                                        + @"') 
                      ORDER BY d2.CODE_VCHR,e.code_chr";
            long lngRes = -1;

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtResult);
                objHRPSvc.Dispose();

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region Get by operatorId and date
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AutoComplete]
        public long GetOrderBookByAPPLYID(System.Security.Principal.IPrincipal p_objPrincipal, string APPLYID, out DataTable p_dtResult)
        {
            p_dtResult = new DataTable();

            string strSQL;
            strSQL = SQL_SELECT + @" AND APPLYID=?
                      ORDER BY d2.CODE_VCHR,e.code_chr";
            long lngRes = -1;

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] arrParams = null;
                objHRPSvc.CreateDatabaseParameter(1, out arrParams);
                arrParams[0].Value = APPLYID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtResult, arrParams);
                objHRPSvc.Dispose();

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region Get by area Id
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AutoComplete]
        public long GetOrderBook(System.Security.Principal.IPrincipal p_objPrincipal, string p_arearId, string p_beginDate, string p_endDate, out DataTable p_dtResult)
        {
            p_dtResult = new DataTable();
            
            string strSQL;
            strSQL = @"select    a.registerid_chr, a.bookid_int, a.operate_dat, a.orderid_chr,
                                 a.ordername_vchr, a.chargeitemname_vchr, a.unit_vchr,
                                 a.unitprice_dec, a.amount_dec, a.remark_vchr, a.book_dat,
                                 a.bookstatus_int, a.confirm_dat, a.apply_type_int, a.print_flag,
                                 b.inpatientid_chr, c.lastname_vchr, c.sex_chr, c.birth_dat,
                                 d1.deptname_vchr createarea, d2.deptname_vchr curarea, d2.code_vchr,
                                 e.code_chr, f1.lastname_vchr creator, f2.lastname_vchr sender,
                                 f3.lastname_vchr doctor, f4.lastname_vchr confirmer, '未知' age_chr,
                                 k.patientcardid_chr,
                                 (case
                                     when (   apply_type_int = 3
                                           or apply_type_int = 4
                                           or apply_type_int = 14
                                           or apply_type_int = 23
                                          )
                                        then ta.admissiondiagnosis_vchr
                                     else ''
                                  end
                                 ) as admissiondiagnosis
                            from t_opr_bih_order_booking a,
                                 t_opr_bih_order a1,
                                 t_opr_bih_register b,
                                 t_opr_bih_registerdetail c,
                                 t_bse_deptdesc d1,
                                 t_bse_deptdesc d2,
                                 t_bse_bed e,
                                 t_bse_employee f1,
                                 t_bse_employee f2,
                                 t_bse_employee f3,
                                 t_bse_employee f4,
                                 t_bse_patientcard k,
                                 t_emr_his_checkrequisition ta
                           where a.registerid_chr = b.registerid_chr
                             and a.registerid_chr = c.registerid_chr
                             and a.createarea_chr = d1.deptid_chr
                             and a.curareaid_chr = d2.deptid_chr
                             and a.curbedid_chr = e.bedid_chr
                             and a.orderid_chr = a1.orderid_chr
                             and a.createarea_chr = f1.empid_chr(+)
                             and a.senderid_chr = f2.empid_chr(+)
                             and a.doctorid_chr = f3.empid_chr(+)
                             and a.confirmerid_chr = f4.empid_chr(+)
                             and b.patientid_chr = k.patientid_chr
                             and (k.status_int = 1 or k.status_int = 3)
                             and a1.orderid_chr = ta.orderid_chr(+)
                             and (   (a.curareaid_chr = ? and a1.sourcetype_int = 0)
                                  or (a.createarea_chr = ? and a1.sourcetype_int = 1)
                                 )
                             and a.operate_dat > ?
                             and a.operate_dat < ?
                        order by d2.code_vchr, e.code_chr ";


            long lngRes = -1;
           
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                System.Data.IDataParameter[] arrParams = null;
                objHRPSvc.CreateDatabaseParameter(4, out arrParams);
                arrParams[0].Value = p_arearId;
                arrParams[1].Value = p_arearId;
                arrParams[2].Value = Convert.ToDateTime(p_beginDate);
                arrParams[3].Value = Convert.ToDateTime(p_endDate);

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtResult, arrParams);

                //lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtResult);
                objHRPSvc.Dispose();
                               
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region Get By Id
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AutoComplete]
        public long GetOrderBookById(System.Security.Principal.IPrincipal p_objPrincipal, string p_bookId, out DataTable p_dtResult)
        {
            p_dtResult = new DataTable();

            string strSQL;
            strSQL = SQL_SELECT + @" AND a.BOOKID_INT = " + p_bookId;


            long lngRes = -1;

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtResult);
                objHRPSvc.Dispose();

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region  修改预约单
        /// <summary>
        /// 修改预约单
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_bookID">流水号</param>
        /// <param name="p_bookDate">预约批准时间</param>
        /// <param name="p_bookStatus">预约状态 0-预约未确认 1-预约通过 2-预约不通过/param>
        /// <param name="p_remark">注意事项</param>
        /// <param name="p_confirmer">确认人ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long UpdateOrderBooking(System.Security.Principal.IPrincipal p_objPrincipal, 
                string p_bookID, 
                string p_bookDate, 
                string p_bookStatus,
                string p_remark,
                string p_confirmer)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsOrderBookingSvc", "UpdateOrderBooking");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQLUpdate;


            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] objLisAddItemRefArr = null;

                strSQLUpdate = @"UPDATE  T_OPR_BIH_ORDER_BOOKING SET 
                                   BOOK_DAT = ?, REMARK_VCHR = ?, BOOKSTATUS_INT = ?, CONFIRMERID_CHR = ?, CONFIRM_DAT = SYSDATE 
                                   WHERE BOOKID_INT = ?";

                objHRPSvc.CreateDatabaseParameter(5, out objLisAddItemRefArr);
                if (p_bookDate == null)
                {
                    objLisAddItemRefArr[0].Value = null;
                }
                else
                {
                    objLisAddItemRefArr[0].Value = Convert.ToDateTime(p_bookDate);
                }
                
                objLisAddItemRefArr[1].Value = p_remark;
                objLisAddItemRefArr[2].Value = Convert.ToInt16(p_bookStatus);
                objLisAddItemRefArr[3].Value = p_confirmer;
                objLisAddItemRefArr[4].Value = Convert.ToInt32(p_bookID);

                long lngRecEff = -1;

                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQLUpdate, ref lngRecEff, objLisAddItemRefArr);
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

        #region 通过特定的查询语句查询
        /// <summary>
        /// 通过特定的查询语句查询
        /// </summary>
        /// <returns></returns>
        [AutoComplete]
        public long GetBySearchSentence(System.Security.Principal.IPrincipal p_objPrincipal, string p_strSQL, out DataTable p_dtResult)
        {
            p_dtResult = new DataTable();

            long lngRes = -1;

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(p_strSQL, ref p_dtResult);
                objHRPSvc.Dispose();

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 更新打印标志By Id
        public long UpdataPrintFlagById(string p_bookID)
        {
            long lngRes = 0;
            string strSQLUpdate;

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                //System.Data.IDataParameter[] objLisAddItemRefArr = null;

                strSQLUpdate = @"UPDATE  T_OPR_BIH_ORDER_BOOKING SET 
                                   PRINT_FLAG = '1'
                                   WHERE BOOKID_INT in (" + p_bookID + ")";
                
                lngRes = objHRPSvc.DoExcute(strSQLUpdate);
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

        /// <summary>
        /// 根据医嘱Id取申请单Id
        /// </summary>
        /// <param name="p_strOrderId"></param>
        /// <param name="p_strApplyId"></param>
        /// <returns></returns>
        public long GetApplyIdByOrderId(string p_strOrderId, out string p_strApplyId)
        {
            p_strApplyId = "";

            string strSQL;
            strSQL = @"SELECT   b.ATTACHID_VCHR
                       FROM ar_common_apply a, t_opr_attachrelation b
                             WHERE (a.deleted <> 1)
                             and a.applyid=b.attachid_vchr(+)
                             and b.sourceitemid_vchr = ?
                             ORDER BY a.applydate";
            long lngRes = -1;

            try
            {
                
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                System.Data.IDataParameter[] arrParams = null;
                objHRPSvc.CreateDatabaseParameter(1, out arrParams);
                arrParams[0].Value = p_strOrderId;

                DataTable ds = new DataTable();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref ds, arrParams);
                //lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref ds);
                //objHRPSvc.Dispose();

                if (lngRes > 0 || ds.Rows.Count > 0)
                {
                    p_strApplyId = ds.Rows[0]["ATTACHID_VCHR"].ToString();
                }

                //p_objApplyRecordArr = new clsApplyRecord[ds.Rows.Count];
                //int i = 0;
                //foreach (DataRow dr in ds.Rows)
                //{
                //    p_objApplyRecordArr[i] = new clsApplyRecord();

                //    p_objApplyRecordArr[i].m_strDeposit = dr["DEPOSIT"].ToString();
                //    p_objApplyRecordArr[i].m_strBalance = dr["BALANCE"].ToString();
                //    p_objApplyRecordArr[i].m_strCheckNO = dr["CHECKNO"].ToString();
                //    p_objApplyRecordArr[i].m_strClinicNO = dr["CLINICNO"].ToString();
                //    p_objApplyRecordArr[i].m_strBIHNO = dr["BIHNO"].ToString();
                //    p_objApplyRecordArr[i].m_strName = dr["NAME"].ToString();
                //    p_objApplyRecordArr[i].m_strSex = dr["SEX"].ToString();
                //    p_objApplyRecordArr[i].m_strAge = dr["AGE"].ToString();
                //    p_objApplyRecordArr[i].m_strArea = dr["AREA"].ToString();
                //    p_objApplyRecordArr[i].m_strBedNO = dr["BEDNO"].ToString();
                //    p_objApplyRecordArr[i].m_strTel = dr["TEL"].ToString();
                //    p_objApplyRecordArr[i].m_strAddress = dr["ADDRESS"].ToString();
                //    p_objApplyRecordArr[i].m_strSummary = dr["SUMMARY"].ToString();
                //    p_objApplyRecordArr[i].m_strDiagnose = dr["DIAGNOSE"].ToString();
                //    p_objApplyRecordArr[i].m_strDoctorName = dr["DOCTORNAME"].ToString();
                //    p_objApplyRecordArr[i].m_strDoctorNO = dr["DOCTORNO"].ToString();
                //    p_objApplyRecordArr[i].m_strExtraNO = dr["EXTRANO"].ToString();
                //    p_objApplyRecordArr[i].m_strCardNO = dr["CARDNO"].ToString();
                //    p_objApplyRecordArr[i].m_strDepartment = dr["DEPARTMENT"].ToString();
                //    p_objApplyRecordArr[i].m_strChargeDetail = dr["CHARGEDETAIL"].ToString();
                //    p_objApplyRecordArr[i].m_datFinishDate = DateTime.Parse(dr["FINISHDATE"].ToString());
                //    p_objApplyRecordArr[i].m_datApplyDate = DateTime.Parse(dr["APPLYDATE"].ToString());
                //    p_objApplyRecordArr[i].m_intDeleted = int.Parse("0" + dr["Deleted"].ToString());
                //    p_objApplyRecordArr[i].m_strApplyTitle = dr["ApplyTitle"].ToString();
                //    p_objApplyRecordArr[i].m_strDiagnoseAim = dr["DIAGNOSEAIM"].ToString();
                //    p_objApplyRecordArr[i].m_strDiagnosePart = dr["DIAGNOSEPART"].ToString();
                //    p_objApplyRecordArr[i].m_strApplyID = dr["ApplyID"].ToString();
                //    p_objApplyRecordArr[i].m_strTypeID = dr["TypeID"].ToString();
                //    p_objApplyRecordArr[i].m_intSubmitted = int.Parse("0" + dr["Submitted"].ToString());
                //    p_objApplyRecordArr[i].m_intChargeStatus = int.Parse("0" + dr["CHARGESTATUS_INT"].ToString());
                //    p_objApplyRecordArr[i].m_strSTATUS_INT = dr["STATUS_INT"].ToString();
                //    p_objApplyRecordArr[i].m_strUrgent = dr["URGENCY_INT"].ToString();
                //    p_objApplyRecordArr[i].m_strStatus_int1 = dr["status_int1"].ToString();
                //    i++;
                //}


            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;

        }
    }
}
