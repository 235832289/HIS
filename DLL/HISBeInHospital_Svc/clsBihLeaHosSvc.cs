using System;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
using com.digitalwave.iCare.middletier.PatientSvc;

namespace com.digitalwave.iCare.middletier.HIS
{
    /// <summary>
    /// 出院管理 -- 中间层
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsBihLeaHosSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 预出院
        /// <summary>
        /// 预出院
        /// {1、增加一条出院记录；2、增加调转记录；3、修改入院登记在院状态；}
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="objPatientVO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long PreLeaveHospital(System.Security.Principal.IPrincipal p_objPrincipal, clsT_Opr_Bih_Leave_VO objPatientVO)
        {
            long lngReg = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngReg = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc", "PreLeaveHospital");
            if (lngReg < 0)
            {
                return -1;
            }
            try
            {
                //增加一条出院记录
                lngReg = InsertBihLeave(p_objPrincipal, objPatientVO);
                if (lngReg < 0)
                {
                    return lngReg;
                }

                //增加调转记录
                lngReg = InsertTransfer(p_objPrincipal, objPatientVO.m_strOUTDEPTID_CHR, objPatientVO.m_strOUTAREAID_CHR,
                                        objPatientVO.m_strOUTBEDID_CHR, objPatientVO.m_strOUTDEPTID_CHR, objPatientVO.m_strOUTAREAID_CHR,
                                        objPatientVO.m_strOUTBEDID_CHR, "7", null, objPatientVO.m_strOPERATORID_CHR, objPatientVO.m_strREGISTERID_CHR);
                if (lngReg < 0)
                {
                    return lngReg;
                }

                //床位状态改为 6
                lngReg = ModifyBedStatus(p_objPrincipal, objPatientVO.m_strOUTBEDID_CHR, "6", objPatientVO.m_strREGISTERID_CHR);
                if (lngReg < 0)
                {
                    return lngReg;
                }

                //更新状态
                lngReg = UpdateRegister(p_objPrincipal, objPatientVO.m_strREGISTERID_CHR, "2");

                //更新出院诊断
                lngReg = UpdateRegisterOutDiagnose(p_objPrincipal, objPatientVO.m_strREGISTERID_CHR, objPatientVO.m_strDIAGNOSE_VCHR);

                //停长嘱
                com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface objSvc = new com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface();

                lngReg = objSvc.m_lngStopOrderByRegID(p_objPrincipal, objPatientVO.m_strREGISTERID_CHR, objPatientVO.m_strOPERATORID_CHR, objPatientVO.m_strOperatorName, DateTime.Parse(objPatientVO.m_strOUTHOSPITAL_DAT));

                //在事务结束之前检查出院表的有效记录
                clsT_Opr_Bih_Leave_VO leaveVo;
                lngReg = GetPreLeaveByRegisterID(p_objPrincipal, objPatientVO.m_strREGISTERID_CHR, out leaveVo);

                objSvc.Dispose();


            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngReg;
        }
        #endregion

        #region 直接出院
        /// <summary>
        /// 直接出院
        /// {1、增加一条出院记录；2、增加调转记录；3、修改入院登记在院状态；}
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="objPatientVO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long LeaveHospital(System.Security.Principal.IPrincipal p_objPrincipal, clsT_Opr_Bih_Leave_VO objPatientVO)
        {
            long lngReg = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngReg = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc", "LeaveHospital");
            if (lngReg < 0)
            {
                return -1;
            }
            try
            {
                //增加一条出院记录
                lngReg = InsertBihLeave(p_objPrincipal, objPatientVO);
                if (lngReg < 0)
                {
                    return lngReg;
                }

                //增加调转记录
                lngReg = InsertTransfer(p_objPrincipal, objPatientVO.m_strOUTDEPTID_CHR, objPatientVO.m_strOUTAREAID_CHR,
                                        objPatientVO.m_strOUTBEDID_CHR, objPatientVO.m_strOUTDEPTID_CHR, objPatientVO.m_strOUTAREAID_CHR,
                                        objPatientVO.m_strOUTBEDID_CHR, "6", null, objPatientVO.m_strOPERATORID_CHR, objPatientVO.m_strREGISTERID_CHR);
                if (lngReg < 0)
                {
                    return lngReg;
                }

                //床位状态改为 1
                lngReg = ModifyBedStatus(p_objPrincipal, objPatientVO.m_strOUTBEDID_CHR, "1", objPatientVO.m_strREGISTERID_CHR);
                if (lngReg < 0)
                {
                    return lngReg;
                }

                //更新状态
                lngReg = UpdateRegister(p_objPrincipal, objPatientVO.m_strREGISTERID_CHR, "3");

                //更新出院诊断
                lngReg = UpdateRegisterOutDiagnose(p_objPrincipal, objPatientVO.m_strREGISTERID_CHR, objPatientVO.m_strDIAGNOSE_VCHR);

                //停长嘱
                com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface objSvc = new com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface();

                lngReg = objSvc.m_lngStopOrderByRegID(p_objPrincipal, objPatientVO.m_strREGISTERID_CHR, objPatientVO.m_strOPERATORID_CHR, "", DateTime.Parse(objPatientVO.m_strOUTHOSPITAL_DAT), 1);
                objSvc.Dispose();


            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngReg;
        }
        #endregion

        #region 根据入院登记流水号查询有效的预出院记录
        /// <summary>
        /// 根据入院登记流水号查询有效的预出院记录 {原则上只有一个有效的记录}
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterid_chr">入院登记流水号</param>
        /// <param name="p_objResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetPreLeaveByRegisterID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterid_chr, out clsT_Opr_Bih_Leave_VO p_objResult)
        {

            p_objResult = new clsT_Opr_Bih_Leave_VO();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc", "GetPreLeaveByRegisterID");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = "";
            strSQL = @" SELECT a.LEAVEID_CHR,
                               a.REGISTERID_CHR,
                               a.OUTDEPTID_CHR,
                               a.DES_VCHR,
                               a.OUTAREAID_CHR,
                               a.MODIFY_DAT,
                               a.OUTBEDID_CHR,
                               a.OPERATORID_CHR,
                               a.OUTHOSPITAL_DAT,
                               a.DIAGNOSE_VCHR,
                               a.INS_DIAGNOSE_VCHR,
                               a.DISEASETYPE_INT,
                               a.TYPE_INT,
                               a.STATUS_INT,
                               a.PSTATUS_INT,
                           (select deptname_vchr from t_bse_deptdesc where deptid_chr=a.outdeptid_chr) OutDeptName,
			               (select deptname_vchr from t_bse_deptdesc where deptid_chr=a.outareaid_chr) OutAreaName,
			               (select code_chr from t_bse_bed where bedid_chr=a.outbedid_chr) OutBedNo,
			               (select LastName_vchr FROM T_BSE_EMPLOYEE WHERE trim(empid_chr) =trim(a.operatorid_chr)) OPERATORNAME,
			               a.TYPE_INT TypeName,
			               decode(a.PSTATUS_INT,0,'预出院',1,'实际出院','') PStatusName
			               FROM t_opr_bih_leave a 
                           WHERE a.STATUS_INT = 1 and a.PSTATUS_INT = 0 and a.REGISTERID_CHR = ?";

            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                //lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                System.Data.IDataParameter[] arrParams = null;
                new clsHRPTableService().CreateDatabaseParameter(1, out arrParams);
                arrParams[0].Value = p_strRegisterid_chr;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, arrParams);
                objHRPSvc.Dispose();

                if (dtbResult.Rows.Count > 1)
                {
                    throw (new Exception("该病人有效的预出院记录多于一条!可能是重复办了预出院。"));
                }

                if (lngRes > 0 && dtbResult.Rows.Count == 1)
                {
                    //for(int i1=0;i1<p_objResultArr.Length;i1++)

                    //p_objResult = new clsT_Opr_Bih_Leave_VO();
                    p_objResult.m_strLEAVEID_CHR = dtbResult.Rows[0]["LEAVEID_CHR"].ToString().Trim();
                    p_objResult.m_strREGISTERID_CHR = dtbResult.Rows[0]["REGISTERID_CHR"].ToString().Trim();
                    p_objResult.m_strTYPE_INT = dtbResult.Rows[0]["TYPE_INT"].ToString().Trim();
                    p_objResult.m_strOUTDEPTID_CHR = dtbResult.Rows[0]["OUTDEPTID_CHR"].ToString().Trim();
                    p_objResult.m_strDES_VCHR = dtbResult.Rows[0]["DES_VCHR"].ToString().Trim();
                    p_objResult.m_strOUTAREAID_CHR = dtbResult.Rows[0]["OUTAREAID_CHR"].ToString().Trim();
                    p_objResult.m_strMODIFY_DAT = Convert.ToDateTime(dtbResult.Rows[0]["MODIFY_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                    p_objResult.m_strOUTBEDID_CHR = dtbResult.Rows[0]["OUTBEDID_CHR"].ToString().Trim();
                    p_objResult.m_strOPERATORID_CHR = dtbResult.Rows[0]["OPERATORID_CHR"].ToString().Trim();
                    p_objResult.m_intSTATUS_INT = Int32.Parse(dtbResult.Rows[0]["STATUS_INT"].ToString());
                    p_objResult.m_intPSTATUS_INT = Convert.ToInt32(dtbResult.Rows[0]["PSTATUS_INT"].ToString().Trim());
                    p_objResult.m_strDIAGNOSE_VCHR = dtbResult.Rows[0]["DIAGNOSE_VCHR"].ToString();
                    p_objResult.m_strINS_DIAGNOSE_VCHR = dtbResult.Rows[0]["INS_DIAGNOSE_VCHR"].ToString();
                    p_objResult.m_strOUTHOSPITAL_DAT = dtbResult.Rows[0]["OUTHOSPITAL_DAT"].ToString().Trim();
                    //非字段
                    p_objResult.m_strOutDeptName = dtbResult.Rows[0]["OutDeptName"].ToString().Trim();
                    p_objResult.m_strOutAreaName = dtbResult.Rows[0]["OutAreaName"].ToString().Trim();
                    p_objResult.m_strOutBedNo = dtbResult.Rows[0]["OutBedNo"].ToString().Trim();
                    p_objResult.m_strTypeName = dtbResult.Rows[0]["TypeName"].ToString().Trim();
                    p_objResult.m_strOperatorName = dtbResult.Rows[0]["OperatorName"].ToString().Trim();
                    p_objResult.m_strPStatusName = dtbResult.Rows[0]["PStatusName"].ToString().Trim();

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

        #region 根据入院登记流水号查询有效的出院记录
        /// <summary>
        /// 根据入院登记流水号查询有效的出院记录 {原则上只有一个有效的记录}
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterid_chr">入院登记流水号</param>
        /// <param name="p_pstatus">标志 0 预出院；1 正式出院</param>
        /// <param name="p_objResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetLeaveByRegisterID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterid_chr, string p_pstatus, out clsT_Opr_Bih_Leave_VO p_objResult)
        {

            p_objResult = new clsT_Opr_Bih_Leave_VO();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc", "GetLeaveByRegisterID");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = "";
            strSQL = @" SELECT a.LEAVEID_CHR,
                               a.REGISTERID_CHR,
                               a.OUTDEPTID_CHR,
                               a.DES_VCHR,
                               a.OUTAREAID_CHR,
                               a.MODIFY_DAT,
                               a.OUTBEDID_CHR,
                               a.OPERATORID_CHR,
                               a.OUTHOSPITAL_DAT,
                               a.DIAGNOSE_VCHR,
                               a.INS_DIAGNOSE_VCHR,
                               a.DISEASETYPE_INT,
                               a.TYPE_INT,
                               a.STATUS_INT,
                               a.PSTATUS_INT,
                           (select deptname_vchr from t_bse_deptdesc where deptid_chr=a.outdeptid_chr) OutDeptName,
			               (select deptname_vchr from t_bse_deptdesc where deptid_chr=a.outareaid_chr) OutAreaName,
			               (select code_chr from t_bse_bed where bedid_chr=a.outbedid_chr) OutBedNo,
			               (select LastName_vchr FROM T_BSE_EMPLOYEE WHERE trim(empid_chr) =trim(a.operatorid_chr)) OPERATORNAME,
			               a.TYPE_INT TypeName,
			               decode(a.PSTATUS_INT,0,'预出院',1,'实际出院','') PStatusName
			               FROM t_opr_bih_leave a 
                           WHERE a.STATUS_INT = 1 and a.PSTATUS_INT = ? and 
                                 a.REGISTERID_CHR = ? ";

            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                //lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                System.Data.IDataParameter[] arrParams = null;
                new clsHRPTableService().CreateDatabaseParameter(2, out arrParams);
                arrParams[0].Value = p_pstatus;
                arrParams[1].Value = p_strRegisterid_chr;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, arrParams);
                objHRPSvc.Dispose();

                if (dtbResult.Rows.Count > 1)
                {
                    throw (new Exception("该病人有效的出院记录多于一条!"));
                }

                if (lngRes > 0 && dtbResult.Rows.Count == 1)
                {
                    //for(int i1=0;i1<p_objResultArr.Length;i1++)

                    //p_objResult = new clsT_Opr_Bih_Leave_VO();
                    p_objResult.m_strLEAVEID_CHR = dtbResult.Rows[0]["LEAVEID_CHR"].ToString().Trim();
                    p_objResult.m_strREGISTERID_CHR = dtbResult.Rows[0]["REGISTERID_CHR"].ToString().Trim();
                    p_objResult.m_strTYPE_INT = dtbResult.Rows[0]["TYPE_INT"].ToString().Trim();
                    p_objResult.m_strOUTDEPTID_CHR = dtbResult.Rows[0]["OUTDEPTID_CHR"].ToString().Trim();
                    p_objResult.m_strDES_VCHR = dtbResult.Rows[0]["DES_VCHR"].ToString().Trim();
                    p_objResult.m_strOUTAREAID_CHR = dtbResult.Rows[0]["OUTAREAID_CHR"].ToString().Trim();
                    p_objResult.m_strMODIFY_DAT = Convert.ToDateTime(dtbResult.Rows[0]["MODIFY_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                    p_objResult.m_strOUTBEDID_CHR = dtbResult.Rows[0]["OUTBEDID_CHR"].ToString().Trim();
                    p_objResult.m_strOPERATORID_CHR = dtbResult.Rows[0]["OPERATORID_CHR"].ToString().Trim();
                    p_objResult.m_intSTATUS_INT = Int32.Parse(dtbResult.Rows[0]["STATUS_INT"].ToString());
                    p_objResult.m_intPSTATUS_INT = Convert.ToInt32(dtbResult.Rows[0]["PSTATUS_INT"].ToString().Trim());
                    p_objResult.m_strDIAGNOSE_VCHR = dtbResult.Rows[0]["DIAGNOSE_VCHR"].ToString();
                    p_objResult.m_strINS_DIAGNOSE_VCHR = dtbResult.Rows[0]["INS_DIAGNOSE_VCHR"].ToString();
                    p_objResult.m_strOUTHOSPITAL_DAT = dtbResult.Rows[0]["OUTHOSPITAL_DAT"].ToString().Trim();

                    //非字段
                    p_objResult.m_strOutDeptName = dtbResult.Rows[0]["OutDeptName"].ToString().Trim();
                    p_objResult.m_strOutAreaName = dtbResult.Rows[0]["OutAreaName"].ToString().Trim();
                    p_objResult.m_strOutBedNo = dtbResult.Rows[0]["OutBedNo"].ToString().Trim();
                    p_objResult.m_strTypeName = dtbResult.Rows[0]["TypeName"].ToString().Trim();
                    p_objResult.m_strOperatorName = dtbResult.Rows[0]["OperatorName"].ToString().Trim();
                    p_objResult.m_strPStatusName = dtbResult.Rows[0]["PStatusName"].ToString().Trim();

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

        #region 取消预出院
        /// <summary>
        /// 取消预出院
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_RegisterId">住院登记号</param>
        /// <returns></returns>
        [AutoComplete]
        public long CancelPreLeaved(System.Security.Principal.IPrincipal p_objPrincipal, string p_RegisterId, string p_OperatorId)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc", "UpdateRegister");
            if (lngRes < 0)
            {
                return -1;
            }

            try
            {
                bool isInHld;
                //请假状态 true 请假
                isInHld = IsInHoliday(p_RegisterId);

                //修改入院登记在院状态
                if (isInHld == true)
                {
                    lngRes = UpdateRegister(p_objPrincipal, p_RegisterId, "4");
                }
                else
                {
                    lngRes = UpdateRegister(p_objPrincipal, p_RegisterId, "1");
                }
                //                string strSQLUpdate = @"UPDATE  T_Opr_Bih_Register SET PSTATUS_INT = 1  
                //                                    where PSTATUS_INT = 2 and registerid_chr = '" + p_RegisterId.Trim() + "'";
                //com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                //lngRes = objHRPSvc.DoExcute(strSQLUpdate);


                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                //修改出院记录有效状态
                string strSQLUpdate = @"UPDATE  T_Opr_Bih_Leave SET STATUS_INT = 0,CANCEL_DAT = sysdate, CANCELERID_CHR = '"
                                + p_OperatorId + "' where PSTATUS_INT = 0 and registerid_chr = '" + p_RegisterId.Trim() + "'";
                lngRes = objHRPSvc.DoExcute(strSQLUpdate);

                //更新床位表
                strSQLUpdate = @"UPDATE t_bse_bed 
                                 SET status_int = 2
                                  where status_int = 6 and bihregisterid_chr = '" + p_RegisterId.Trim() + "'";
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

        #region 出院召回
        /// <summary>
        /// 出院召回
        /// {1、(逻辑)删除出院记录；2、恢复床位；3、增加住院调转记录；4、修改入院登记的病床信息；5、新增召回记录 }
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="objPatientVO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long RecallHospital(System.Security.Principal.IPrincipal p_objPrincipal, clsT_Opr_Bih_Leave_VO objPatientVO, string operatorId)
        {
            long lngReg = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngReg = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc", "RecallHospital");
            if (lngReg < 0)
            {
                return -1;
            }



            //1、删除出院记录；
            lngReg = ModifyLeaveStatusByID(p_objPrincipal, objPatientVO.m_strLEAVEID_CHR, 0, operatorId);

            //2、恢复床位(预出院病人)

            //床位标志
            string pstatus = "0";

            if (lngReg > 0 && objPatientVO.m_intPSTATUS_INT == 0)
            {
                bool hasBed;
                hasBed = CheckBedStatus(objPatientVO.m_strOUTBEDID_CHR, objPatientVO.m_strREGISTERID_CHR);
                if (hasBed == true)
                {
                    //重新占床
                    lngReg = ModifyBedStatus(p_objPrincipal, objPatientVO.m_strOUTBEDID_CHR, "2", objPatientVO.m_strREGISTERID_CHR);
                    pstatus = "1";
                }
                //else
                //{
                //    objPatientVO.m_strTARGETBEDID_CHR = "";
                //    objPatientVO.m_strTARGETAREAID_CHR = "";
                //}
            }

            //3、增加调转记录；
            if (lngReg > 0)
            {
                if (pstatus == "1")
                {
                    lngReg = InsertTransfer(p_objPrincipal, objPatientVO.m_strOUTDEPTID_CHR, objPatientVO.m_strOUTAREAID_CHR,
                                            objPatientVO.m_strOUTBEDID_CHR, objPatientVO.m_strOUTDEPTID_CHR, objPatientVO.m_strOUTAREAID_CHR,
                                            objPatientVO.m_strOUTBEDID_CHR, "4", null, operatorId, objPatientVO.m_strREGISTERID_CHR);
                }
                else
                {
                    lngReg = InsertTransfer(p_objPrincipal, objPatientVO.m_strOUTDEPTID_CHR, objPatientVO.m_strOUTAREAID_CHR,
                                            objPatientVO.m_strOUTBEDID_CHR, null, null,
                                            null, "4", null, operatorId, objPatientVO.m_strREGISTERID_CHR);
                }
            }

            //4、修改入院登记的病床信息；
            if (lngReg > 0)
            {
                //pstatus{0=下床;1=在床;2=预出院;3=实际出院}
                //lngReg = UpdateRegister(p_objPrincipal, objPatientVO.m_strREGISTERID_CHR, pstatus);

                bool isInHld;
                //请假状态 true 请假
                isInHld = IsInHoliday(objPatientVO.m_strREGISTERID_CHR);

                //修改入院登记在院状态
                if (isInHld == true)
                {
                    lngReg = UpdateRegister(p_objPrincipal, objPatientVO.m_strREGISTERID_CHR, "4");
                }
                else
                {
                    lngReg = UpdateRegister(p_objPrincipal, objPatientVO.m_strREGISTERID_CHR, pstatus);
                }
            }


            //5、新增召回记录；
            if (lngReg > 0)
            {
                lngReg = InsertReturnRecord(p_objPrincipal, objPatientVO.m_strREGISTERID_CHR, operatorId, objPatientVO.m_strLEAVEID_CHR);
            }

            if (lngReg <= 0)
            {
                throw new Exception("出院召回操作失败！");
            }
            return lngReg;
        }
        #endregion

        #region 新增出院记录
        /// <summary>
        /// 新增出院记录
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        private long InsertBihLeave(System.Security.Principal.IPrincipal p_objPrincipal, clsT_Opr_Bih_Leave_VO p_objRecord)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc", "InsertBihLeave");
            if (lngRes < 0)
            {
                return -1;
            }

            if (lngRes < 0)
                return lngRes;

            string strSQL = @"INSERT INTO T_Opr_Bih_Leave( 
                                  LEAVEID_CHR, REGISTERID_CHR, TYPE_INT, OUTDEPTID_CHR,
                                  DES_VCHR, OUTAREAID_CHR, STATUS_INT, MODIFY_DAT,
                                  OUTBEDID_CHR, OPERATORID_CHR, PSTATUS_INT, OUTHOSPITAL_DAT,
                                  DIAGNOSE_VCHR, INS_DIAGNOSE_VCHR, DISEASETYPE_INT) 
                              VALUES (
                                  ?, ?, ?, ?,
                                  ?, ?, ?, ?,
                                  ?, ?, ?, ?,
                                  ?, ?, ? )";
            try
            {
                string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                //Get new primary key
                string strRecordID = GetNextSeq("SEQ_LEAVE");
                strRecordID = strRecordID.PadLeft(12, '0');

                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(15, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = strRecordID;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strREGISTERID_CHR;
                objLisAddItemRefArr[2].Value = p_objRecord.m_strTYPE_INT;
                objLisAddItemRefArr[3].Value = p_objRecord.m_strOUTDEPTID_CHR;
                objLisAddItemRefArr[4].Value = p_objRecord.m_strDES_VCHR;
                objLisAddItemRefArr[5].Value = p_objRecord.m_strOUTAREAID_CHR;
                objLisAddItemRefArr[6].Value = p_objRecord.m_intSTATUS_INT;
                objLisAddItemRefArr[7].Value = DateTime.Parse(strDateTime);
                objLisAddItemRefArr[8].Value = p_objRecord.m_strOUTBEDID_CHR;
                objLisAddItemRefArr[9].Value = p_objRecord.m_strOPERATORID_CHR;
                objLisAddItemRefArr[10].Value = p_objRecord.m_intPSTATUS_INT;
                objLisAddItemRefArr[11].Value = DateTime.Parse(p_objRecord.m_strOUTHOSPITAL_DAT);
                objLisAddItemRefArr[12].Value = p_objRecord.m_strDIAGNOSE_VCHR;
                objLisAddItemRefArr[13].Value = p_objRecord.m_strINS_DIAGNOSE_VCHR;
                objLisAddItemRefArr[14].Value = p_objRecord.m_intDISEASETYPE_INT;

                long lngRecEff = -1;
                //往表增加记录
                lngRes = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, objLisAddItemRefArr);
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

        #region 新增调转记录
        /// <summary>
        /// 新增调转记录
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_srcDeptId">源科室</param>
        /// <param name="p_srcAreaId">源病区</param>
        /// <param name="p_srcBedId">源床位</param>
        /// <param name="p_tgDeptId">目标科室</param>
        /// <param name="p_tgAreaId">目标病区</param>
        /// <param name="p_tgBedId">目标床位</param>
        /// <param name="p_type"></param>
        /// <param name="p_des"></param>
        /// <param name="p_operatorId">操作员</param>
        /// <param name="p_registerId">入院登记流水号</param>
        /// <returns></returns>
        [AutoComplete]
        public long InsertTransfer(System.Security.Principal.IPrincipal p_objPrincipal,
                                   string p_srcDeptId,
                                   string p_srcAreaId,
                                   string p_srcBedId,
                                   string p_tgDeptId,
                                   string p_tgAreaId,
                                   string p_tgBedId,
                                   string p_type,
                                   string p_des,
                                   string p_operatorId,
                                   string p_registerId)
        {
            long lngRes = 0;
            string p_strRecordID = "";
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc", "InsertTransfer");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            //lngRes = 0;
            //lngRes = objHRPSvc.m_lngGenerateNewID("t_opr_bih_transfer", "transferid_chr", 12, out p_strRecordID);
            p_strRecordID = GetNextSeq("seq_opr_bih_transfer");
            p_strRecordID = p_strRecordID.PadLeft(12, '0');
            if (lngRes < 0)
                return lngRes;

            string strSQL = @"INSERT INTO t_opr_bih_transfer(
                                     transferid_chr, sourcedeptid_chr, sourceareaid_chr,
                                     sourcebedid_chr, targetdeptid_chr, targetareaid_chr,
                                     targetbedid_chr, type_int, des_vchr, operatorid_chr,
                                     registerid_chr, modify_dat, doctorid_chr, doctorgroupid_chr)
                               VALUES(
                                     ?, ?, ?,
                                     ?, ?, ?,
                                     ?, ?, ?, ?,
                                     ?, ?, ?, ? )";

            try
            {
                DataTable dtDoctor;
                string strCaseDrId = "";
                string strGroupId = "";
                lngRes = GetCaseDoctorByRegId(p_registerId, out dtDoctor);
                if (lngRes > 0 && dtDoctor.Rows.Count > 0)
                {
                    strCaseDrId = dtDoctor.Rows[0]["empid_chr"].ToString();
                    strGroupId = dtDoctor.Rows[0]["groupid_chr"].ToString();
                }

                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(14, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_strRecordID;
                objLisAddItemRefArr[1].Value = p_srcDeptId;
                objLisAddItemRefArr[2].Value = p_srcAreaId;
                objLisAddItemRefArr[3].Value = p_srcBedId;
                objLisAddItemRefArr[4].Value = p_tgDeptId;
                objLisAddItemRefArr[5].Value = p_tgAreaId;
                objLisAddItemRefArr[6].Value = p_tgBedId;
                objLisAddItemRefArr[7].Value = int.Parse(p_type);
                objLisAddItemRefArr[8].Value = p_des;
                objLisAddItemRefArr[9].Value = p_operatorId;
                objLisAddItemRefArr[10].Value = p_registerId;
                objLisAddItemRefArr[11].Value = DateTime.Now;
                objLisAddItemRefArr[12].Value = strCaseDrId;
                objLisAddItemRefArr[13].Value = strGroupId;
                //往表增加记录
                objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRes, objLisAddItemRefArr);
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

        #region 新增出院召回记录
        /// <summary>
        /// 新增出院召回记录
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_registerId"></param>
        /// <param name="p_operatorId"></param>
        /// <param name="p_leaveId"></param>
        /// <returns></returns>
        [AutoComplete]
        private long InsertReturnRecord(System.Security.Principal.IPrincipal p_objPrincipal, string p_registerId, string p_operatorId, string p_leaveId)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc", "InsertReturnRecord");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"INSERT INTO T_OPR_BIH_RETURNRECORD (SEQ_INT, REGISTERID_CHR, CREATE_DAT, CREATORID_CHR, RETURN_DAT, LEAVEID_CHR) 
                                                          VALUES (SEQ_RETURNRECORD.nextval, ?, sysdate, ?, sysdate, ?)";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(3, out objLisAddItemRefArr);

                objLisAddItemRefArr[0].Value = p_registerId;
                objLisAddItemRefArr[1].Value = p_operatorId;
                objLisAddItemRefArr[2].Value = p_leaveId;

                long lngRecEff = -1;
                //往表增加记录
                lngRes = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, objLisAddItemRefArr);
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

        #region  修改出院的记录状态｛-1历史、0无效、1有效｝根据出院流水号
        /// <summary>
        /// 修改出院的记录状态｛-1历史、0无效、1有效｝	根据流水号
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strID">出院流水号</param>
        /// <param name="p_status">状态｛-1历史、0无效、1有效｝</param>
        /// <param name="p_operator">操作人ID</param>
        /// <returns></returns>
        [AutoComplete]
        public long ModifyLeaveStatusByID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strID, int p_status, string p_operator)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc", "ModifyLeaveStatusByID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQLUpdate;


            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] objLisAddItemRefArr = null;

                if (p_status == 1)
                {
                    strSQLUpdate = @"UPDATE  T_Opr_Bih_Leave SET 
                                   Status_int = ?, OPERATORID_CHR = ?, MODIFY_DAT = SYSDATE 
                                   WHERE LEAVEID_CHR = ?";

                    objHRPSvc.CreateDatabaseParameter(3, out objLisAddItemRefArr);
                    objLisAddItemRefArr[0].Value = p_status;
                    objLisAddItemRefArr[1].Value = p_operator;
                    objLisAddItemRefArr[2].Value = p_strID;

                }
                else
                {
                    strSQLUpdate = @"UPDATE  T_Opr_Bih_Leave SET 
                                   Status_int = ?, OPERATORID_CHR = ?, MODIFY_DAT = SYSDATE,
                                   CANCELERID_CHR = ?, CANCEL_DAT = SYSDATE 
                                   WHERE LEAVEID_CHR = ?";

                    objHRPSvc.CreateDatabaseParameter(4, out objLisAddItemRefArr);
                    objLisAddItemRefArr[0].Value = p_status;
                    objLisAddItemRefArr[1].Value = p_operator;
                    objLisAddItemRefArr[2].Value = p_operator;
                    objLisAddItemRefArr[3].Value = p_strID;

                }


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

        #region 判断出院病人的原床位是否已占用
        /// <summary>
        /// 判断出院病人的原床位是否已占用
        /// </summary>
        /// <returns>true:未占用；false:已占用 </returns>
        [AutoComplete]
        private bool CheckBedStatus(string p_bedId, string p_registerId)
        {
            string strSQL;
            strSQL = @"SELECT BIHREGISTERID_CHR FROM T_BSE_BED WHERE (STATUS_INT = 1 OR BIHREGISTERID_CHR = ? ) AND BEDID_CHR = ?";

            System.Data.DataTable dtbResult = new System.Data.DataTable();

            bool ret = false;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                //long lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);

                System.Data.IDataParameter[] arrParams = null;
                new clsHRPTableService().CreateDatabaseParameter(2, out arrParams);
                arrParams[0].Value = p_registerId;
                arrParams[1].Value = p_bedId;

                long lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, arrParams);

                objHRPSvc.Dispose();

                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                    ret = true;

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return ret;
        }
        #endregion

        #region 判断出院病人的原是否处于请假状态
        /// <summary>
        /// 判断出院病人的原是否处于请假状态
        /// </summary>
        /// <returns>true:请假；false:非请假 </returns>
        [AutoComplete]
        private bool IsInHoliday(string p_registerId)
        {
            string strSQL;
            strSQL = @"SELECT REGISTERID_CHR FROM T_OPR_BIH_HOLIDAYRECORD WHERE STATUS_INT = 1 AND REGISTERID_CHR = ?";

            System.Data.DataTable dtbResult = new System.Data.DataTable();

            bool ret = false;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                //long lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                System.Data.IDataParameter[] arrParams = null;
                new clsHRPTableService().CreateDatabaseParameter(1, out arrParams);
                arrParams[0].Value = p_registerId;

                long lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, arrParams);

                objHRPSvc.Dispose();

                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                    ret = true;

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return ret;
        }
        #endregion

        #region  修改在院状态{0=下床;1=在床;2=预出院;3=实际出院;4=请假}
        /// <summary>
        /// 修改住院登记的状态{0=下床;1=在床;2=预出院;3=实际出院;4=请假}
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_RegisterId">住院登记号</param>
        /// <param name="p_status">状态</param>
        /// <returns></returns>
        [AutoComplete]
        private long UpdateRegister(System.Security.Principal.IPrincipal p_objPrincipal, string p_RegisterId, string p_status)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc", "UpdateRegister");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQLUpdate = @"UPDATE T_OPR_BIH_REGISTER 
                                       SET PSTATUS_INT = ?
                                    WHERE REGISTERID_CHR = ?";

            //+ p_status + @" where registerid_chr = '" + p_RegisterId.Trim() + "'";

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            //lngRes = 0;
            //lngRes = objHRPSvc.DoExcute(strSQLUpdate);

            System.Data.IDataParameter[] objLisAddItemRefArr = null;
            objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
            //Please change the datetime and reocrdid 
            objLisAddItemRefArr[0].Value = p_status;
            objLisAddItemRefArr[1].Value = p_RegisterId;

            long lngRecEff = -1;
            //
            lngRes = 0;
            lngRes = objHRPSvc.lngExecuteParameterSQL(strSQLUpdate, ref lngRecEff, objLisAddItemRefArr);
            objHRPSvc.Dispose();


            #region NewEMR.Itf
            DataTable dt = null;
            string Sql = @"select t.parmvalue_vchr from t_bse_sysparm t where t.parmcode_chr = '6666' and t.status_int = 1";
            objHRPSvc.lngGetDataTableWithoutParameters(Sql, ref dt);
            if (dt != null && dt.Rows.Count > 0)
            {
                int val = 0;
                int.TryParse(dt.Rows[0][0].ToString(), out val);
                if (val == 1)
                {
                    // 在院状态  -4 转护理单元中 -3 转科中  -2撤销结算 -1 撤销入院 0 无床 1 在床 2 请假 3 出院 4 出院结算 5 召回
                    Sql = @"update t_ip_register
                                   set status_int = ?
                                 where registerid_int = ?";

                    clsHRPTableService emrSvc = new clsHRPTableService();
                    emrSvc.m_mthSetDataBase_Selector(1, 19);
                    System.Data.IDataParameter[] parm = null;
                    emrSvc.CreateDatabaseParameter(2, out parm);
                    // his: {0=下床;1=在床;2=预出院;3=实际出院;4=请假}
                    if (p_status == "2") p_status = "3";
                    else if (p_status == "3") p_status = "4";
                    else if (p_status == "4") p_status = "2";
                    parm[0].Value = Convert.ToDecimal(p_status);
                    parm[1].Value = Convert.ToDecimal(p_RegisterId);
                    emrSvc.lngExecuteParameterSQL(Sql, ref lngRes, parm);
                }
            }
            #endregion

            return lngRes;
        }
        #endregion


        #region 修改病床状态 {1=空床;2=占床;3=预约占床;4=包房占床;5=删除6=预出院占床;}
        /// <summary>
        /// 修改病床状态 {1=空床;2=占床;3=预约占床;4=包房占床;5=删除6=预出院占床;}
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_Bedid">流水号</param>
        /// <param name="p_status">病床状态 {1=空床;2=占床;3=预约占床;4=包房占床;5=删除6=预出院占床;}</param>
        /// <param name="p_registerID">入院登记流水号</param>
        /// <returns></returns>
        [AutoComplete]
        private long ModifyBedStatus(System.Security.Principal.IPrincipal p_objPrincipal,
                                    string p_Bedid,
                                    string p_status,
                                    string p_registerID)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc", "ModifyBedStatus");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQLUpdate = "";
            if (p_status == "1")
            {
                strSQLUpdate = @"UPDATE t_bse_bed
                                   SET status_int = " + p_status + @", BIHREGISTERID_CHR = null
                                 WHERE bedid_chr = '" + p_Bedid.Trim() + "'";
            }
            else
            {
                strSQLUpdate = @"UPDATE t_bse_bed
                                   SET status_int = " + p_status + @", BIHREGISTERID_CHR = '" + p_registerID + "'"
                               + " WHERE bedid_chr = '" + p_Bedid.Trim() + "'";
            }
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
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

        #region 获取序列的下一个值
        /// <summary>
        /// 获取序列的下一个值
        /// </summary>
        /// <returns></returns>
        [AutoComplete]
        private string GetNextSeq(string p_seqName)
        {
            long lngRes = 0;

            string strSQL;
            strSQL = @"SELECT " + p_seqName + ".NEXTVAL FROM dual";

            System.Data.DataTable dtbResult = new System.Data.DataTable();

            string newSeq = "0";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();

                if (lngRes > 0 && dtbResult != null)
                {
                    newSeq = dtbResult.Rows[0][0].ToString().Trim();
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return newSeq;
        }
        #endregion

        #region 判断病人是否有医嘱未处理
        /// <summary>
        /// 判断病人是否有医嘱未处理
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_registerId"></param>
        /// <param name="HasDisExcOrder"></param>
        /// <returns></returns>
        [AutoComplete]
        public long IfHasDisExcOrder(System.Security.Principal.IPrincipal p_objPrincipal, string p_registerId, out bool HasDisExcOrder)
        {
            HasDisExcOrder = false;
            long lngRes = -1;

            System.Data.DataTable dtbResult = new System.Data.DataTable();

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                //long lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                System.Data.IDataParameter[] arrParams = null;
                new clsHRPTableService().CreateDatabaseParameter(2, out arrParams);
                arrParams[0].Value = p_registerId;
                arrParams[1].Value = p_registerId;

                string strSQL;
                strSQL = @"SELECT ORDERID_CHR FROM T_OPR_BIH_ORDER WHERE STATUS_INT in(0,1,5,7) AND REGISTERID_CHR = ?
                           union all
                           SELECT a.ORDERID_CHR FROM T_OPR_BIH_ORDEREXECUTE a, T_OPR_BIH_ORDER b 
                                                WHERE a.ORDERID_CHR = b.ORDERID_CHR AND
                                                      a.STATUS_INT = 1 AND 
                                                      a.NEEDCONFIRM_INT = 1 AND 
                                                      a.CONFIRMERID_CHR is null AND
                                                      b.REGISTERID_CHR = ?";

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, arrParams);

                objHRPSvc.Dispose();

                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                    HasDisExcOrder = true;

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

        #region 医保对应疾病编码表
        /// <summary>
        /// 医保对应疾病编码表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetInsurncedisease(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable p_dtResult)
        {

            p_dtResult = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc", "GetLeaveByRegisterID");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"SELECT a.diseaseid_int,
                                      a.usercode_vchr,
                                      a.diseasename_vchr,
                                      a.createrid_chr,
                                      a.create_dat,
                                      a.special_int
                                FROM T_BSE_INSURANCEDISEASE a where rownum < 100";

            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtResult);

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

        #region 医保对应疾病编码表
        /// <summary>
        /// 医保对应疾病编码表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strCode"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetInsurncedisease(System.Security.Principal.IPrincipal p_objPrincipal, string p_strCode, out DataTable p_dtResult)
        {

            p_dtResult = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc", "GetLeaveByRegisterID");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"SELECT a.diseaseid_int,
                                      a.usercode_vchr,
                                      a.diseasename_vchr,
                                      a.createrid_chr,
                                      a.create_dat,
                                      a.special_int
                                FROM T_BSE_INSURANCEDISEASE a where a.usercode_vchr like '"
                         + p_strCode + "%' or a.DISEASENAME_VCHR like '%" + p_strCode + "%'";

            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtResult);

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

        #region 出院诊断统计
        /// <summary>
        /// 出院诊断统计
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strCondition"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetOutDiagnoses(System.Security.Principal.IPrincipal p_objPrincipal, string p_strCondition, out DataTable p_dtResult)
        {

            p_dtResult = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc", "GetLeaveByRegisterID");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"select c.code_vchr,
                                       c.deptname_vchr,
                                       b.code_chr,
                                       e.inpatientid_chr,
                                       e.inpatient_dat,
                                       d.lastname_vchr,
                                       d.sex_chr,
                                       a.outhospital_dat,
                                       a.diagnose_vchr,
                                       a.diseasetype_int
                                from 
		                                T_OPR_BIH_LEAVE a,
		                                T_BSE_BED b,
		                                T_BSE_DEPTDESC c,
		                                T_OPR_BIH_REGISTERDETAIL d,
		                                T_OPR_BIH_REGISTER e
                                where 
                                     a.registerid_chr = e.registerid_chr and
                                     a.outareaid_chr = c.deptid_chr and
                                     a.outbedid_chr = b.bedid_chr and 
                                     d.registerid_chr = e.registerid_chr and
                                     a.status_int = 1" + p_strCondition;

            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtResult);

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

        #region  更新住院登记表出院诊断(包含特殊病种的更新)
        /// <summary>
        /// 更新住院登记表出院诊断
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_RegisterId">住院登记号</param>
        /// <param name="p_OutDiagnose">出院诊断</param>
        /// <param name="p_blnDiseaseType">是否特殊病种</param>
        /// <returns></returns>
        [AutoComplete]
        public long UpdateRegisterOutDiagnose(System.Security.Principal.IPrincipal p_objPrincipal, string p_RegisterId, string p_OutDiagnose, bool p_blnDiseaseType)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc", "UpdateRegister");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQLUpdate = @"update t_opr_bih_register set outdiagnose_vchr = ?, diseasetype_int = ? where registerid_chr = ? ";

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            System.Data.IDataParameter[] objLisAddItemRefArr = null;
            objHRPSvc.CreateDatabaseParameter(3, out objLisAddItemRefArr);

            objLisAddItemRefArr[0].Value = p_OutDiagnose;
            if (p_blnDiseaseType == true)
            {
                objLisAddItemRefArr[1].Value = 1;
            }
            else
            {
                objLisAddItemRefArr[1].Value = 0;
            }
            objLisAddItemRefArr[2].Value = p_RegisterId;

            long lngRecEff = -1;
            //
            lngRes = 0;
            lngRes = objHRPSvc.lngExecuteParameterSQL(strSQLUpdate, ref lngRecEff, objLisAddItemRefArr);
            objHRPSvc.Dispose();

            return lngRes;
        }
        #endregion

        #region  更新住院登记表出院诊断
        /// <summary>
        /// 更新住院登记表出院诊断
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_RegisterId">住院登记号</param>
        /// <param name="p_OutDiagnose">出院诊断</param>
        /// <returns></returns>
        [AutoComplete]
        public long UpdateRegisterOutDiagnose(System.Security.Principal.IPrincipal p_objPrincipal, string p_RegisterId, string p_OutDiagnose)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc", "UpdateRegister");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQLUpdate = @"UPDATE T_OPR_BIH_REGISTER 
                                       SET   
                                           OUTDIAGNOSE_VCHR = ? 
                                    WHERE REGISTERID_CHR = ?";

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            System.Data.IDataParameter[] objLisAddItemRefArr = null;
            objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);

            objLisAddItemRefArr[0].Value = p_OutDiagnose;
            objLisAddItemRefArr[1].Value = p_RegisterId;

            long lngRecEff = -1;
            //
            lngRes = 0;
            lngRes = objHRPSvc.lngExecuteParameterSQL(strSQLUpdate, ref lngRecEff, objLisAddItemRefArr);
            objHRPSvc.Dispose();

            return lngRes;
        }
        #endregion

        #region 根据住院流水号获取主治医生信息
        /// <summary>
        /// 根据住院流水号获取主治医生信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterId">住院流水号</param>
        /// <param name="p_dtResult">主治医生信息</param>
        /// <returns></returns>
        [AutoComplete]
        private long GetCaseDoctorByRegId(string p_strRegisterId, out DataTable p_dtResult)
        {
            p_dtResult = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc", "GetDeptByEmpID");
            //if (lngRes < 0)
            //{
            //    return -1;
            //}

            string strSQL = @"select t.empid_chr, t.groupid_chr
                                from t_bse_groupemp t, t_opr_bih_register r
                               where t.empid_chr = r.CASEDOCTOR_CHR
                                 and t.begin_dat < sysdate
                                 and (t.end_dat > sysdate or t.end_dat is null)
                                 and r.registerid_chr = ? ";
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr;
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_strRegisterId;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtResult, objLisAddItemRefArr);


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

        #region  修改预出院日期
        /// <summary>
        /// 修改预出院日期
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtNewDate">新日期</param>
        /// <param name="p_objLeave">出院VO</param>
        /// <returns></returns>
        [AutoComplete]
        public long ModifyLeaveDate(System.Security.Principal.IPrincipal p_objPrincipal, DateTime p_dtNewDate, clsT_Opr_Bih_Leave_VO p_objLeave)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc", "ModifyLeaveStatusByID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQLUpdate = @"UPDATE  T_Opr_Bih_Leave SET 
                                   OUTHOSPITAL_DAT = ?, UPDATERID_CHR = ?, PREOUTHOSPITAL_DAT = ?, DES_VCHR = ?, UPDATE_DAT = SYSDATE 
                                   WHERE LEAVEID_CHR = ?";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] objLisAddItemRefArr = null;

                objHRPSvc.CreateDatabaseParameter(5, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = p_dtNewDate;
                objLisAddItemRefArr[1].Value = p_objLeave.m_strOPERATORID_CHR;
                objLisAddItemRefArr[2].Value = Convert.ToDateTime(p_objLeave.m_strOUTHOSPITAL_DAT);
                objLisAddItemRefArr[3].Value = p_objLeave.m_strDES_VCHR;
                objLisAddItemRefArr[4].Value = p_objLeave.m_strLEAVEID_CHR;

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

        #region 判断日期段内是否发生了费用
        /// <summary>
        /// 判断日期段内是否发生了费用
        /// </summary>
        /// <param name="p_strRegisterid_chr">入院登记流水号</param>
        /// <param name="p_strBeginDate">开始时间</param>
        /// <param name="p_strEndDate">结束时间</param>
        /// <param name="p_hasCharge"></param>
        /// <returns></returns>
        [AutoComplete]
        public long IfHasCharge(string p_strRegisterid_chr, string p_strBeginDate, string p_strEndDate, out bool p_hasCharge)
        {

            p_hasCharge = false;
            long lngRes = 0;

            string strSQL = "";
            strSQL = @"select PCHARGEID_CHR from T_OPR_BIH_PATIENTCHARGE 
                        where STATUS_INT = 1
                              and REGISTERID_CHR = ?
                              and CREATE_DAT > ?
                              and CREATE_DAT < ?";

            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                //lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                System.Data.IDataParameter[] arrParams = null;
                new clsHRPTableService().CreateDatabaseParameter(3, out arrParams);
                arrParams[0].Value = p_strRegisterid_chr;
                arrParams[1].Value = Convert.ToDateTime(p_strBeginDate);
                arrParams[2].Value = Convert.ToDateTime(p_strEndDate);

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, arrParams);
                objHRPSvc.Dispose();

                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_hasCharge = true;
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
