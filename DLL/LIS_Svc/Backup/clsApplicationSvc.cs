using System;
using System.Data;
using System.EnterpriseServices;
using System.Collections;
using System.Security.Principal;
using Microsoft.VisualBasic;
using com.digitalwave.Utility; //Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll

namespace com.digitalwave.iCare.middletier.LIS
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    [Transaction(TransactionOption.Required)]
    [ObjectPooling(Enabled = true)]
    public class clsApplicationSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase//MiddleTierBase.dll
    {
        #region 更新申请单到发状态
        [AutoComplete]
        public long m_lngSendApplictions(System.Security.Principal.IPrincipal p_objPrincipal,
            string[] p_strApplicationIDArr)
        {
            long lngRes = 0;
            if (p_strApplicationIDArr == null)
                return -1;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngGetCollocate");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = @"update t_opr_lis_application set pstatus_int = 2 
where  pstatus_int = 1 
and application_id_chr in(?)";

            IDataParameter[] objIDPArr = null;
            objHRPSvc.CreateDatabaseParameter(p_strApplicationIDArr.Length, out objIDPArr);

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < p_strApplicationIDArr.Length; i++)
            {
                sb.Append(",?");
                objIDPArr[i].Value = p_strApplicationIDArr[i];
            }
            string str = sb.ToString();
            if (str != null)
                str = str.Remove(0, 1);
            strSQL = strSQL.Replace("?", str);

            try
            {
                long lngEff = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngEff, objIDPArr);
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

        #region  作废申请单的样本
        [AutoComplete]
        public long m_lngAddBlankOutInfo(System.Security.Principal.IPrincipal obj_Principal, clsLisApplMainVO p_objApplMainVO, clsBlankOutApplicationVO p_objBlankOutInfo)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(obj_Principal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngAddBlankOutInfo");
            if (lngRes < 0)
            {
                return -1;
            }

            //删除申请及样本
            lngRes = 0;
            lngRes = this.m_lngDeleteApp(obj_Principal, p_objBlankOutInfo.m_strBLANKOUTAPPID, p_objBlankOutInfo.m_strBLANKOUTOPRID);
            if (lngRes < 0)
            {
                return -1;
            }

            //重新建立申请
            lngRes = 0;
            clsT_OPR_LIS_APP_REPORT_VO[] p_objReportResultArr = null;
            lngRes = this.m_lngGetAppReportVOArrByApplicationID(obj_Principal, p_objApplMainVO.m_strAPPLICATION_ID, out p_objReportResultArr);
            if (lngRes < 0)
            {
                return -1;
            }
            for (int i = 0; i < p_objReportResultArr.Length; i++)
            {
                p_objReportResultArr[i].m_intSTATUS_INT = 1;
                p_objReportResultArr[i].m_strREPORT_DAT = "";
            }
            lngRes = 0;
            clsT_OPR_LIS_APP_SAMPLE_VO[] p_objSampleResultArr = null;
            lngRes = this.m_lngGetAppSampleGroupVOArr(obj_Principal, p_objApplMainVO.m_strAPPLICATION_ID, out p_objSampleResultArr);
            if (lngRes < 0)
            {
                return -1;
            }
            p_objBlankOutInfo.m_strBLANKOUTSAMPLEID = p_objSampleResultArr[0].m_strSAMPLE_ID_CHR;
            lngRes = 0;
            clsT_OPR_LIS_APP_CHECK_ITEM_VO[] p_objCheckItemResultArr = null;
            lngRes = this.m_lngGetAppCheckItemVOArr(obj_Principal, p_objApplMainVO.m_strAPPLICATION_ID, out p_objCheckItemResultArr);
            if (lngRes < 0)
            {
                return -1;
            }
            lngRes = 0;
            clsT_OPR_LIS_APP_APPLY_UNIT_VO[] p_objAppUnitResultArr = null;
            lngRes = this.m_lngGetAppApplyUnitVOByApplicationID(obj_Principal, p_objApplMainVO.m_strAPPLICATION_ID, out p_objAppUnitResultArr);
            if (lngRes < 0)
            {
                return -1;
            }
            clsLisApplMainVO p_objLisApplMainOutVO = null;
            lngRes = 0;
            lngRes = this.m_lngAddNewApplForBlankOut(obj_Principal, p_objApplMainVO, out p_objLisApplMainOutVO, p_objReportResultArr, p_objSampleResultArr, p_objCheckItemResultArr, p_objAppUnitResultArr);
            if (lngRes < 0)
            {
                return -1;
            }

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = @"Insert into t_opr_lis_blankoutapplication values('" + p_objBlankOutInfo.m_strBLANKOUTAPPID + "','" + p_objBlankOutInfo.m_strBLANKOUTSAMPLEID + "','" + p_objBlankOutInfo.m_strBLANKOUTOPRID + "','" + p_objBlankOutInfo.m_strBLANKOUTREASON + "',to_date('" + p_objBlankOutInfo.m_strBLANKOUTDATE + "','yyyy-mm-dd hh24:mi:ss'))";
            lngRes = 0;
            lngRes = objHRPSvc.DoExcute(strSQL);
            if (lngRes < 0)
            {
                return -1;
            }

            return lngRes;
        }
        #endregion

        #region 作废样本子方法
        [AutoComplete]
        public long m_lngAddNewApplForBlankOut(System.Security.Principal.IPrincipal p_objPrincipal,
            com.digitalwave.iCare.ValueObject.clsLisApplMainVO p_objLisApplMainVO,
            out com.digitalwave.iCare.ValueObject.clsLisApplMainVO p_objLisApplMainOutVO,
            com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_APP_REPORT_VO[] p_objReportArr,
            com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_APP_SAMPLE_VO[] p_objAppSampleArr,
            com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_APP_CHECK_ITEM_VO[] p_objAppItemArr,
            com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_APP_APPLY_UNIT_VO[] p_objAppUnitArr)
        {
            string strAppIDTemp = p_objLisApplMainVO.m_strAPPLICATION_ID;
            p_objLisApplMainVO.m_strAPPLICATION_ID = "";
            p_objLisApplMainVO.m_strMODIFY_DAT = DateTime.Now.ToString();
            p_objLisApplMainVO.m_intPStatus_int = 2;
            p_objLisApplMainVO.m_intReportStatus = 1;
            p_objLisApplMainVO.m_intSampleStatus = 1;
            p_objLisApplMainVO.m_strReportGroupID = "";
            p_objLisApplMainVO.m_strSampleID = "";
            p_objLisApplMainVO.m_strReportDate = "";
            p_objLisApplMainOutVO = p_objLisApplMainVO;
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngAddNewApplForBlankOut");
            if (lngRes < 0)
            {
                return -1;
            }
            if (p_objLisApplMainVO == null)
            {
                return -2;
            }

            try
            {
                lngRes = 0;
                lngRes = m_lngAddNewAppl(p_objPrincipal, p_objLisApplMainVO, out p_objLisApplMainOutVO);
                p_objLisApplMainVO = p_objLisApplMainOutVO;
                if (lngRes > 0)
                {
                    #region 赋申请单ID
                    for (int i = 0; i < p_objReportArr.Length; i++)
                    {
                        p_objReportArr[i].m_strAPPLICATION_ID_CHR = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    }
                    for (int i = 0; i < p_objAppSampleArr.Length; i++)
                    {
                        p_objAppSampleArr[i].m_strAPPLICATION_ID_CHR = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    }
                    for (int i = 0; i < p_objAppItemArr.Length; i++)
                    {
                        p_objAppItemArr[i].m_strAPPLICATION_ID_CHR = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    }
                    for (int i = 0; i < p_objAppUnitArr.Length; i++)
                    {
                        p_objAppUnitArr[i].m_strAPPLICATION_ID_CHR = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    }
                    #endregion
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngInsertAppReportRecord(p_objPrincipal, p_objReportArr);
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngAddNewAppSampleGroup(p_objPrincipal, p_objAppSampleArr);
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngAddNewAppCheckItem(p_objPrincipal, p_objAppItemArr);
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngAddNewAppApplyUint(p_objPrincipal, p_objAppUnitArr);
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    string strSQL = @"update T_OPR_LIS_APP_UNIT_ITEM t set t.APPLICATION_ID_CHR = '" + p_objLisApplMainVO.m_strAPPLICATION_ID + "' where t.APPLICATION_ID_CHR = '" + strAppIDTemp + "'";
                    clsHRPTableService objHRPSvc = new clsHRPTableService();
                    lngRes = objHRPSvc.DoExcute(strSQL);
                }
                if (lngRes <= 0)
                {
                    throw new Exception(null);
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                throw objEx;
            }

            return lngRes;
        }
        #endregion

        #region  根据申请单号查询对应的收费项目名称
        //[AutoComplete]
        //public long m_lngFindItemNameByApplicationID(System.Security.Principal.IPrincipal p_objPrincipal,string p_strAppID,out string strItemName)
        //        {
        //            strItemName = "";
        //            long lngRes = 0;
        //            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsApplicationSvc","m_lngFindItemNameByApplicationID");
        //            if(lngRes < 0)
        //            {
        //                return -1;
        //            }

        //            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

        //            string strSQL = @"select a.itemname_vchr
        //                              from  t_bse_chargeitem a,
        //                                    t_opr_lis_app_apply_unit b
        //                              where b.apply_unit_id_chr = a.itemsrcid_vchr
        //                                and b.application_id_chr = '" + p_strAppID + "'";

        //            try
        //            {
        //                lngRes = 0;
        //                DataTable dtResult = new DataTable();
        //                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtResult);
        //                if( lngRes < 0 )
        //                {
        //                    return -1;
        //                }

        //                if( dtResult != null && dtResult.Rows.Count > 0 )
        //                {
        //                    for( int i=0; i< dtResult.Rows.Count; i++ )
        //                    {
        //                        if( i == dtResult.Rows.Count -1 )
        //                        {
        //                            strItemName += dtResult.Rows[i][0].ToString();
        //                        }
        //                        else
        //                        {
        //                            strItemName += dtResult.Rows[i][0].ToString() + ";";
        //                        }
        //                    }
        //                }
        //            }
        //            catch(Exception objEx)
        //            {
        //                string strTmp=objEx.Message;
        //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //                bool blnRes = objLogger.LogError(objEx);
        //            }

        //            return lngRes;
        //        }
        #endregion

        //#region  根据员工工号查询员工信息		
        //[AutoComplete]
        //public long m_lngFindEmpMsgByEmpNO(System.Security.Principal.IPrincipal p_objPrincipal, string p_strEmpNO, out string strEmpID, out string strEmpPwd)
        //{
        //    strEmpID = "";
        //    strEmpPwd = "";
        //    long lngRes = 0;
        //    clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //    lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngFindEmpMsgByEmpNO");
        //    if (lngRes < 0)
        //    {
        //        return -1;
        //    }
        //    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //    string strSQL = @"select t1.empid_chr,t1.psw_chr from t_bse_Employee t1 where t1.empno_chr = '" + p_strEmpNO + "'";
        //    DataTable dtResult = new DataTable();
        //    try
        //    {
        //        lngRes = 0;
        //        lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtResult);
        //        if (dtResult != null)
        //        {
        //            strEmpID = dtResult.Rows[0]["empid_chr"].ToString();
        //            strEmpPwd = dtResult.Rows[0]["psw_chr"].ToString();
        //        }
        //    }
        //    catch (Exception objEx)
        //    {
        //        string strTmp = objEx.Message;
        //        com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //        bool blnRes = objLogger.LogError(objEx);
        //    }
        //    return lngRes;
        //}
        //#endregion

        //        #region 联合查询（包括病人住院号）申请单信息 
        //        /// <summary>
        //        /// 联合查询（包括病人住院号）申请单信息
        //        /// </summary>
        //        /// <param name="p_objPrincipal"></param>
        //        /// <param name="p_objSchVO"></param>
        //        /// <param name="p_strInHospitalNO">承载联合查询条件的VO,其中值为NULL的成员会被必忽略</param>
        //        /// <param name="p_objAppVOArr">返回的承载申请单信息的数组</param>
        //        /// <returns>0:失败;1:成功</returns>
        //        [AutoComplete]
        //        public long m_lngGetAppInfoByConditionAndInHospitalNO(System.Security.Principal.IPrincipal p_objPrincipal,
        //            clsLISApplicationSchVO p_objSchVO, string p_strInHospitalNO,
        //            out clsLisApplMainVO[] p_objAppVOArr)
        //        {
        //            long lngRes = 0;
        //            p_objAppVOArr = null;
        //            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngGetAppInfoByCondition");
        //            if (lngRes < 0)
        //            {
        //                return -1;
        //            }

        //            #region SQL
        //            string strSQL = @"select * from (SELECT  DISTINCT t2.*,
        //											t1.REPORT_GROUP_ID_CHR REPORT_GROUP_ID_CHR_Report,
        //											t1.MODIFY_DAT MODIFY_DAT_Report,											
        //											t1.OPERATOR_ID_CHR OPERATOR_ID_CHR_Report,
        //											t1.STATUS_INT STATUS_INT_Report,
        //											t1.REPORT_DAT REPORT_DAT_Report,
        //											t1.REPORTOR_ID_CHR REPORTOR_ID_CHR_Report,
        //											t1.CONFIRM_DAT CONFIRM_DAT_Report,
        //											t1.CONFIRMER_ID_CHR CONFIRMER_ID_CHR_Report
        //								FROM t_opr_lis_app_report t1,
        //									t_opr_lis_application t2,
        //									t_opr_lis_app_sample t3,
        //									t_opr_lis_sample t4       
        //								WHERE t1.application_id_chr = t2.application_id_chr
        //								AND t2.pstatus_int + 0 = 2
        //								AND t3.application_id_chr = t1.application_id_chr
        //								AND t3.report_group_id_chr = t1.report_group_id_chr 
        //								AND t3.sample_id_chr = t4.sample_id_chr
        //								AND t4.status_int = 3";

        //            string strSQL_ConfirmState = " AND t1.status_int = ? ";
        //            string strSQL_ConfirmStateAll = " AND t1.status_int > ?";
        //            string strSQL_FromDate = " AND t4.accept_dat >= ? ";
        //            string strSQL_ToDate = " AND t4.accept_dat <= ? ";
        //            string strSQL_PatientName = " AND Trim(t2.patient_name_vchr) LIKE ? ";
        //            string strSQL_BarCode = " AND t4.barcode_vchr = ? ";
        //            string strSQL_SampleGroupID = @" AND t2.application_id_chr IN (
        //													SELECT DISTINCT tt1.application_id_chr
        //																FROM t_opr_lis_app_sample tt1
        //																WHERE tt1.sample_group_id_chr IN
        //																					(*))";

        //            string strSQL_FromDateApp = " AND t4.appl_dat >= ? ";
        //            string strSQL_ToDateApp = " AND t4.appl_dat <= ? ";
        //            string strSQL_InhospNO = " AND Trim(t2.patient_inhospitalno_chr) = ? ";
        //            string strSQL_BedNO = " AND Trim(t2.bedno_chr) = ? ";
        //            string strSQL_AppDept = " AND Trim(t2.appl_deptid_chr) = ? ";
        //            string strSQL_AppDoct = " AND Trim(t2.appl_empid_chr) = ? ";
        //            string strSQL_AppID = " AND t2.application_id_chr = ?";
        //            string strSQL_PatientID = " AND t2.patientid_chr = ?";
        //            string strSQL_InHospitalNO = " AND trim(t2.patient_inhospitalno_chr) = ?";
        //            #endregion

        //            ArrayList arlSQL = new ArrayList();
        //            ArrayList arlParm = new ArrayList();

        //            #region 构造
        //            if (p_objSchVO.m_strApplicationID != null)
        //            {
        //                arlSQL.Add(strSQL_AppID);
        //                arlParm.Add(p_objSchVO.m_strApplicationID);
        //            }
        //            if (p_objSchVO.m_strPatientID != null)
        //            {
        //                arlSQL.Add(strSQL_PatientID);
        //                arlParm.Add(p_objSchVO.m_strPatientID);
        //            }
        //            if (p_objSchVO.m_strConfirmState == "1")
        //            {
        //                arlSQL.Add(strSQL_ConfirmState);
        //                arlParm.Add(1);
        //            }
        //            else if (p_objSchVO.m_strConfirmState == "2")
        //            {
        //                arlSQL.Add(strSQL_ConfirmState);
        //                arlParm.Add(2);
        //            }
        //            else if (p_objSchVO.m_strConfirmState == "0")
        //            {
        //                arlSQL.Add(strSQL_ConfirmState);
        //                arlParm.Add(0);
        //            }
        //            else
        //            {
        //                arlSQL.Add(strSQL_ConfirmStateAll);
        //                arlParm.Add(0);
        //            }
        //            if (p_objSchVO.m_strConfirmedDateBegin != null && Microsoft.VisualBasic.Information.IsDate(p_objSchVO.m_strConfirmedDateBegin.Trim()))
        //            {
        //                arlSQL.Add(strSQL_FromDate);
        //                arlParm.Add(DateTime.Parse(p_objSchVO.m_strConfirmedDateBegin.Trim()));
        //            }
        //            if (p_objSchVO.m_strConfirmedDateEnd != null && Microsoft.VisualBasic.Information.IsDate(p_objSchVO.m_strConfirmedDateEnd.Trim()))
        //            {
        //                arlSQL.Add(strSQL_ToDate);
        //                arlParm.Add(DateTime.Parse(p_objSchVO.m_strConfirmedDateEnd.Trim()));
        //            }
        //            if (p_objSchVO.m_strSampleGroupIDArr != null && p_objSchVO.m_strSampleGroupIDArr.Length > 0)
        //            {
        //                System.Text.StringBuilder sb = new System.Text.StringBuilder();
        //                for (int i = 0; i < p_objSchVO.m_strSampleGroupIDArr.Length; i++)
        //                {
        //                    sb.Append("?,");
        //                }
        //                sb.Remove(sb.Length - 1, 1);
        //                string strReplace = sb.ToString();
        //                strSQL_SampleGroupID = strSQL_SampleGroupID.Replace("*", strReplace);
        //                arlSQL.Add(strSQL_SampleGroupID);
        //                arlParm.AddRange(p_objSchVO.m_strSampleGroupIDArr);
        //            }
        //            if (p_objSchVO.m_strPatientName != null && p_objSchVO.m_strPatientName.ToString().Trim() != "")
        //            {
        //                arlSQL.Add(strSQL_PatientName);
        //                arlParm.Add("%" + p_objSchVO.m_strPatientName.Trim() + "%");
        //            }
        //            if (p_objSchVO.m_strBarCode != null && p_objSchVO.m_strBarCode.ToString().Trim() != "")
        //            {
        //                arlSQL.Add(strSQL_BarCode);
        //                arlParm.Add(p_objSchVO.m_strBarCode.Trim());
        //            }


        //            if (p_objSchVO.m_strFromDatApp != null && Microsoft.VisualBasic.Information.IsDate(p_objSchVO.m_strFromDatApp.Trim()))
        //            {
        //                arlSQL.Add(strSQL_FromDateApp);
        //                arlParm.Add(DateTime.Parse(p_objSchVO.m_strFromDatApp.Trim()));
        //            }
        //            if (p_objSchVO.m_strToDatApp != null && Microsoft.VisualBasic.Information.IsDate(p_objSchVO.m_strToDatApp.Trim()))
        //            {
        //                arlSQL.Add(strSQL_ToDateApp);
        //                arlParm.Add(DateTime.Parse(p_objSchVO.m_strToDatApp.Trim()));
        //            }
        //            if (p_objSchVO.m_strInhospNO != null && p_objSchVO.m_strInhospNO.ToString().Trim() != "")
        //            {
        //                arlSQL.Add(strSQL_InhospNO);
        //                arlParm.Add(p_objSchVO.m_strInhospNO.Trim());
        //            }
        //            if (p_objSchVO.m_strBedNO != null && p_objSchVO.m_strBedNO.ToString().Trim() != "")
        //            {
        //                arlSQL.Add(strSQL_BedNO);
        //                arlParm.Add(p_objSchVO.m_strBedNO.Trim());
        //            }
        //            if (p_objSchVO.m_strAppDept != null && p_objSchVO.m_strAppDept.ToString().Trim() != "")
        //            {
        //                arlSQL.Add(strSQL_AppDept);
        //                arlParm.Add(p_objSchVO.m_strAppDept.Trim());
        //            }
        //            if (p_objSchVO.m_strAppDoct != null && p_objSchVO.m_strAppDoct.ToString().Trim() != "")
        //            {
        //                arlSQL.Add(strSQL_AppDoct);
        //                arlParm.Add(p_objSchVO.m_strAppDoct.Trim());
        //            }
        //            if (p_strInHospitalNO != null && p_strInHospitalNO.ToString().Trim() != "")
        //            {
        //                arlSQL.Add(strSQL_InHospitalNO);
        //                arlParm.Add(p_strInHospitalNO.Trim());
        //            }
        //            #endregion

        //            foreach (object obj in arlSQL)
        //            {
        //                strSQL += obj.ToString();
        //            }
        //            strSQL += ") order by accept_dat";

        //            int intParmCount = arlParm.Count;

        //            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

        //            IDataParameter[] objDPArr = null;
        //            objHRPSvc.CreateDatabaseParameter(intParmCount, out objDPArr);

        //            for (int i = 0; i < intParmCount; i++)
        //            {
        //                objDPArr[i].Value = arlParm[i];
        //            }

        //            try
        //            {
        //                DataTable dtbResult = null;
        //                lngRes = 0;
        //                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);
        //                objHRPSvc.Dispose();
        //                if (lngRes > 0 && dtbResult != null && dtbResult.Rows.Count > 0)
        //                {
        //                    System.Collections.ArrayList arlApp = new ArrayList();
        //                    //					System.Data.DataRow[] dtrResultArr = dtbResult.Select("","application_id_chr");
        //                    for (int i = 0; i < dtbResult.Rows.Count; i++)
        //                    {
        //                        clsLisApplMainVO objMainVO = new clsVOConstructor().m_objConstructAppMainVO(dtbResult.Rows[i]);
        //                        objMainVO.m_strReportGroupID = dtbResult.Rows[i]["REPORT_GROUP_ID_CHR_Report"].ToString().Trim();
        //                        objMainVO.m_strReportDate = dtbResult.Rows[i]["CONFIRM_DAT_Report"].ToString().Trim();
        //                        objMainVO.m_intReportStatus = int.Parse(dtbResult.Rows[i]["status_int_Report"].ToString().Trim());
        //                        objMainVO.m_strOriginDate = dtbResult.Rows[i]["oringin_dat"].ToString().Trim();
        //                        arlApp.Add(objMainVO);
        //                    }
        //                    p_objAppVOArr = (clsLisApplMainVO[])arlApp.ToArray(typeof(clsLisApplMainVO));
        //                }
        //            }
        //            catch (Exception objEx)
        //            {
        //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //                bool blnRes = objLogger.LogError(objEx);
        //                p_objAppVOArr = null;
        //            }
        //            return lngRes;
        //        }
        //        #endregion

        #region 增加-组新的检验申请信息(包含报告组,申请单元,样本组,检验项目,和样本在内(barcode为seq中取得)的全部信息)
        /// <summary>
        /// 增加-组新的检验申请信息(包含报告组,申请单元,样本组,检验项目,和样本在内(barcode为seq中取得)的全部信息)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objLisApplMainVO"></param>
        /// <param name="p_objReportArr"></param>
        /// <param name="p_objAppSampleArr"></param>
        /// <param name="p_objAppItemArr"></param>
        /// <param name="p_objAppUnitArr"></param>
        /// <param name="p_objAppUnitItemArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewAppAndSampleInfoWithBarcode(System.Security.Principal.IPrincipal p_objPrincipal,
            com.digitalwave.iCare.ValueObject.clsLisApplMainVO p_objLisApplMainVO,
            out com.digitalwave.iCare.ValueObject.clsLisApplMainVO p_objLisApplMainOutVO,
            com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_APP_REPORT_VO[] p_objReportArr,
            com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_APP_SAMPLE_VO[] p_objAppSampleArr,
            com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_APP_CHECK_ITEM_VO[] p_objAppItemArr,
            com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_APP_APPLY_UNIT_VO[] p_objAppUnitArr,
            com.digitalwave.iCare.ValueObject.clsLisAppUnitItemVO[] p_objAppUnitItemArr)
        {
            p_objLisApplMainOutVO = p_objLisApplMainVO;
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngAddNewAppAndSampleInfo");
            if (lngRes < 0)
            {
                return -1;
            }
            if (p_objLisApplMainVO == null)
            {
                return -2;
            }

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService svc = new clsHRPTableService();

                #region 暂停分单，存在一条医嘱对应多条申请单的情况 2018.03.06  --> 采样次数大于0的申请单元可以 2018.04.18
                string Sql = @"select 1
                                  from t_opr_attachrelation a
                                 inner join t_opr_bih_order b
                                    on a.sourceitemid_vchr = b.orderid_chr
                                 inner join t_bse_bih_orderdic c
                                    on b.orderdicid_chr = c.orderdicid_chr
                                 where b.orderid_chr = ?
                                   and (c.samplingtimes is null or c.samplingtimes = 0)";
                IDataParameter[] parm = null;
                DataTable dtCheck = null;
                if (p_objLisApplMainOutVO.m_strPatientType == "1")
                {
                    for (int i = 0; i < p_objLisApplMainOutVO.m_strOrderArr.Length; i++)
                    {
                        svc.CreateDatabaseParameter(1, out parm);
                        parm[0].Value = p_objLisApplMainOutVO.m_strOrderArr[i];
                        svc.lngGetDataTableWithParameters(Sql, ref dtCheck, parm);
                        if (dtCheck != null && dtCheck.Rows.Count > 0)
                        {
                            return 0;
                        }
                    }
                }
                #endregion

                lngRes = 0;
                lngRes = m_lngAddNewAppl(p_objPrincipal, p_objLisApplMainVO, out p_objLisApplMainOutVO);
                p_objLisApplMainVO = p_objLisApplMainOutVO;
                if (lngRes > 0)
                {
                    #region 赋申请单ID
                    for (int i = 0; i < p_objReportArr.Length; i++)
                    {
                        p_objReportArr[i].m_strAPPLICATION_ID_CHR = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    }
                    for (int i = 0; i < p_objAppSampleArr.Length; i++)
                    {
                        p_objAppSampleArr[i].m_strAPPLICATION_ID_CHR = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    }
                    for (int i = 0; i < p_objAppItemArr.Length; i++)
                    {
                        p_objAppItemArr[i].m_strAPPLICATION_ID_CHR = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    }
                    for (int i = 0; i < p_objAppUnitArr.Length; i++)
                    {
                        p_objAppUnitArr[i].m_strAPPLICATION_ID_CHR = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    }
                    for (int i = 0; i < p_objAppUnitItemArr.Length; i++)
                    {
                        p_objAppUnitItemArr[i].m_strAPPLICATION_ID_CHR = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    }
                    #endregion
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngInsertAppReportRecord(p_objPrincipal, p_objReportArr);
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngAddNewAppSampleGroup(p_objPrincipal, p_objAppSampleArr);
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngAddNewAppCheckItem(p_objPrincipal, p_objAppItemArr);
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngAddNewAppApplyUint(p_objPrincipal, p_objAppUnitArr);
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngAddNewAppUintItemArr(p_objPrincipal, p_objAppUnitItemArr);
                }
                if (lngRes > 0)
                {
                    //自动生成barcode号                   
                    string strSQL = @"select seq_lis_barcode.NEXTVAL from dual";
                    DataTable dtResult = new DataTable();
                    string strBarcode = "";
                    lngRes = 0;
                    lngRes = svc.lngGetDataTableWithoutParameters(strSQL, ref dtResult);
                    if (lngRes > 0)
                    {
                        if (dtResult.Rows[0][0] == System.DBNull.Value)
                        {
                            strBarcode = "";
                        }
                        else
                        {
                            strBarcode = dtResult.Rows[0][0].ToString();
                        }
                    }
                    dtResult = null;
                    svc = null;

                    com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_SAMPLE_VO objSampleVO = new clsT_OPR_LIS_SAMPLE_VO();

                    #region 构造SampleVO
                    objSampleVO.m_strAPPL_DAT = p_objLisApplMainVO.m_strAppl_Dat;
                    objSampleVO.m_strSEX_CHR = p_objLisApplMainVO.m_strSex;
                    objSampleVO.m_strPATIENT_NAME_VCHR = p_objLisApplMainVO.m_strPatient_Name;
                    objSampleVO.m_strPATIENT_SUBNO_CHR = p_objLisApplMainVO.m_strPatient_SubNO;
                    objSampleVO.m_strAGE_CHR = p_objLisApplMainVO.m_strAge;
                    objSampleVO.m_strPATIENT_TYPE_CHR = p_objLisApplMainVO.m_strPatientType;
                    objSampleVO.m_strDIAGNOSE_VCHR = p_objLisApplMainVO.m_strDiagnose;
                    objSampleVO.m_strBEDNO_CHR = p_objLisApplMainVO.m_strBedNO;
                    objSampleVO.m_strICD_VCHR = p_objLisApplMainVO.m_strICD;
                    objSampleVO.m_strPATIENTCARDID_CHR = p_objLisApplMainVO.m_strPatientcardID;
                    objSampleVO.m_strPATIENTID_CHR = p_objLisApplMainVO.m_strPatientID;
                    objSampleVO.m_strAPPL_EMPID_CHR = p_objLisApplMainVO.m_strAppl_EmpID;
                    objSampleVO.m_strAPPL_DEPTID_CHR = p_objLisApplMainVO.m_strAppl_DeptID;
                    objSampleVO.m_strAPPLICATION_ID_CHR = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    objSampleVO.m_strPATIENT_INHOSPITALNO_CHR = p_objLisApplMainVO.m_strPatient_inhospitalno_chr;
                    objSampleVO.m_strSAMPLE_TYPE_ID_CHR = p_objLisApplMainVO.m_strSampleTypeID;
                    objSampleVO.m_strSAMPLETYPE_VCHR = p_objLisApplMainVO.m_strSampleType;
                    objSampleVO.m_intSTATUS_INT = 3;
                    objSampleVO.m_strQCSAMPLEID_CHR = "-1";

                    objSampleVO.m_strSAMPLEKIND_CHR = "1";
                    objSampleVO.m_strSAMPLE_ID_CHR = null;

                    objSampleVO.m_strSAMPLESTATE_VCHR = "";

                    objSampleVO.m_strBARCODE_VCHR = strBarcode;

                    objSampleVO.m_strOPERATOR_ID_CHR = p_objLisApplMainVO.m_strOperator_ID;

                    objSampleVO.m_strSAMPLING_DATE_DAT = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    objSampleVO.m_strCOLLECTOR_ID_CHR = null;

                    objSampleVO.m_strACCEPTOR_ID_CHR = p_objLisApplMainVO.m_strOperator_ID;

                    objSampleVO.m_strACCEPT_DAT = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    #endregion

                    lngRes = 0;
                    lngRes = new clsSampleSvc().m_lngAddNewSampleAndModifyAppSampleGroup(p_objPrincipal,
                        objSampleVO.m_strAPPLICATION_ID_CHR, objSampleVO);
                    for (int i = 0; i < p_objAppSampleArr.Length; i++)
                    {
                        p_objAppSampleArr[i].m_strSAMPLE_ID_CHR = objSampleVO.m_strSAMPLE_ID_CHR;
                    }
                }
                if (lngRes <= 0)
                {
                    throw new Exception(null);
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                throw objEx;
            }

            return lngRes;
        }
        #endregion

        #region  增加-组新的检验申请信息(包含报告组,申请单元,样本组,检验项目,和样本在内(样本没核收)的全部信息)
        /// <summary>
        /// 增加-组新的检验申请信息(包含报告组,申请单元,样本组,检验项目,和样本在内(样本没核收)的全部信息)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objLisApplMainVO"></param>
        /// <param name="p_objReportArr"></param>
        /// <param name="p_objAppSampleArr"></param>
        /// <param name="p_objAppItemArr"></param>
        /// <param name="p_objAppUnitArr"></param>
        /// <param name="p_objAppUnitItemArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewAppAndSampleInfoWithoutReceive(System.Security.Principal.IPrincipal p_objPrincipal,
            com.digitalwave.iCare.ValueObject.clsLisApplMainVO p_objLisApplMainVO,
            out com.digitalwave.iCare.ValueObject.clsLisApplMainVO p_objLisApplMainOutVO,
            com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_APP_REPORT_VO[] p_objReportArr,
            com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_APP_SAMPLE_VO[] p_objAppSampleArr,
            com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_APP_CHECK_ITEM_VO[] p_objAppItemArr,
            com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_APP_APPLY_UNIT_VO[] p_objAppUnitArr,
            com.digitalwave.iCare.ValueObject.clsLisAppUnitItemVO[] p_objAppUnitItemArr)
        {
            p_objLisApplMainOutVO = p_objLisApplMainVO;
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngAddNewAppAndSampleInfo");
            if (lngRes < 0)
            {
                return -1;
            }
            if (p_objLisApplMainVO == null)
            {
                return -2;
            }

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService svc = new clsHRPTableService();

                #region 暂停分单，存在一条医嘱对应多条申请单的情况 2018.03.06  --> 采样次数大于0的申请单元可以 2018.04.18
                string Sql = @"select 1
                                  from t_opr_attachrelation a
                                 inner join t_opr_bih_order b
                                    on a.sourceitemid_vchr = b.orderid_chr
                                 inner join t_bse_bih_orderdic c
                                    on b.orderdicid_chr = c.orderdicid_chr
                                 where b.orderid_chr = ?
                                   and (c.samplingtimes is null or c.samplingtimes = 0)";
                IDataParameter[] parm = null;
                DataTable dtCheck = null;
                if (p_objLisApplMainOutVO.m_strPatientType == "1")
                {
                    for (int i = 0; i < p_objLisApplMainOutVO.m_strOrderArr.Length; i++)
                    {
                        svc.CreateDatabaseParameter(1, out parm);
                        parm[0].Value = p_objLisApplMainOutVO.m_strOrderArr[i];
                        svc.lngGetDataTableWithParameters(Sql, ref dtCheck, parm);
                        if (dtCheck != null && dtCheck.Rows.Count > 0)
                        {
                            return 0;
                        }
                    }
                }
                #endregion

                lngRes = 0;
                lngRes = m_lngAddNewAppl(p_objPrincipal, p_objLisApplMainVO, out p_objLisApplMainOutVO);
                p_objLisApplMainVO = p_objLisApplMainOutVO;
                if (lngRes > 0)
                {
                    #region 赋申请单ID
                    for (int i = 0; i < p_objReportArr.Length; i++)
                    {
                        p_objReportArr[i].m_strAPPLICATION_ID_CHR = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    }
                    for (int i = 0; i < p_objAppSampleArr.Length; i++)
                    {
                        p_objAppSampleArr[i].m_strAPPLICATION_ID_CHR = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    }
                    for (int i = 0; i < p_objAppItemArr.Length; i++)
                    {
                        p_objAppItemArr[i].m_strAPPLICATION_ID_CHR = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    }
                    for (int i = 0; i < p_objAppUnitArr.Length; i++)
                    {
                        p_objAppUnitArr[i].m_strAPPLICATION_ID_CHR = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    }
                    for (int i = 0; i < p_objAppUnitItemArr.Length; i++)
                    {
                        p_objAppUnitItemArr[i].m_strAPPLICATION_ID_CHR = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    }
                    #endregion
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngInsertAppReportRecord(p_objPrincipal, p_objReportArr);
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngAddNewAppSampleGroup(p_objPrincipal, p_objAppSampleArr);
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngAddNewAppCheckItem(p_objPrincipal, p_objAppItemArr);
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngAddNewAppApplyUint(p_objPrincipal, p_objAppUnitArr);
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngAddNewAppUintItemArr(p_objPrincipal, p_objAppUnitItemArr);
                }
                if (lngRes > 0)
                {
                    //自动生成barcode号                    
                    string strSQL = @"select seq_lis_barcode.NEXTVAL from dual";
                    DataTable dtResult = new DataTable();
                    string strBarcode = "";
                    lngRes = 0;
                    lngRes = svc.lngGetDataTableWithoutParameters(strSQL, ref dtResult);
                    if (lngRes > 0)
                    {
                        if (dtResult.Rows[0][0] == System.DBNull.Value)
                        {
                            strBarcode = "";
                        }
                        else
                        {
                            strBarcode = dtResult.Rows[0][0].ToString();
                        }
                    }
                    dtResult = null;
                    svc = null;

                    com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_SAMPLE_VO objSampleVO = new clsT_OPR_LIS_SAMPLE_VO();

                    #region 构造SampleVO
                    objSampleVO.m_strAPPL_DAT = p_objLisApplMainVO.m_strAppl_Dat;
                    objSampleVO.m_strSEX_CHR = p_objLisApplMainVO.m_strSex;
                    objSampleVO.m_strPATIENT_NAME_VCHR = p_objLisApplMainVO.m_strPatient_Name;
                    objSampleVO.m_strPATIENT_SUBNO_CHR = p_objLisApplMainVO.m_strPatient_SubNO;
                    objSampleVO.m_strAGE_CHR = p_objLisApplMainVO.m_strAge;
                    objSampleVO.m_strPATIENT_TYPE_CHR = p_objLisApplMainVO.m_strPatientType;
                    objSampleVO.m_strDIAGNOSE_VCHR = p_objLisApplMainVO.m_strDiagnose;
                    objSampleVO.m_strBEDNO_CHR = p_objLisApplMainVO.m_strBedNO;
                    objSampleVO.m_strICD_VCHR = p_objLisApplMainVO.m_strICD;
                    objSampleVO.m_strPATIENTCARDID_CHR = p_objLisApplMainVO.m_strPatientcardID;
                    objSampleVO.m_strPATIENTID_CHR = p_objLisApplMainVO.m_strPatientID;
                    objSampleVO.m_strAPPL_EMPID_CHR = p_objLisApplMainVO.m_strAppl_EmpID;
                    objSampleVO.m_strAPPL_DEPTID_CHR = p_objLisApplMainVO.m_strAppl_DeptID;
                    objSampleVO.m_strAPPLICATION_ID_CHR = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    objSampleVO.m_strPATIENT_INHOSPITALNO_CHR = p_objLisApplMainVO.m_strPatient_inhospitalno_chr;
                    objSampleVO.m_strSAMPLE_TYPE_ID_CHR = p_objLisApplMainVO.m_strSampleTypeID;
                    objSampleVO.m_strSAMPLETYPE_VCHR = p_objLisApplMainVO.m_strSampleType;
                    objSampleVO.m_intSTATUS_INT = 2;   //修改该状态
                    objSampleVO.m_strQCSAMPLEID_CHR = "-1";

                    objSampleVO.m_strSAMPLEKIND_CHR = "1";
                    objSampleVO.m_strSAMPLE_ID_CHR = null;

                    objSampleVO.m_strSAMPLESTATE_VCHR = "";

                    objSampleVO.m_strBARCODE_VCHR = strBarcode;

                    objSampleVO.m_strOPERATOR_ID_CHR = p_objLisApplMainVO.m_strOperator_ID;

                    objSampleVO.m_strSAMPLING_DATE_DAT = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    objSampleVO.m_strCOLLECTOR_ID_CHR = null;

                    objSampleVO.m_strACCEPTOR_ID_CHR = null;   //无核收人

                    objSampleVO.m_strACCEPT_DAT = null;   //无核收时间
                    #endregion

                    lngRes = 0;
                    lngRes = new clsSampleSvc().m_lngAddNewSampleAndModifyAppSampleGroup(p_objPrincipal,
                        objSampleVO.m_strAPPLICATION_ID_CHR, objSampleVO);
                    for (int i = 0; i < p_objAppSampleArr.Length; i++)
                    {
                        p_objAppSampleArr[i].m_strSAMPLE_ID_CHR = objSampleVO.m_strSAMPLE_ID_CHR;
                    }
                }
                if (lngRes <= 0)
                {
                    throw new Exception(null);
                }
                if (lngRes > 0)
                {
                    //先前: 门诊在收费后写入; 住院在这里写入
                    //现在: 门诊、住院都这里写入
                    //if (p_objLisApplMainOutVO.m_strPatientType == "1") 
                    //{
                        lngRes = m_lngInsertAttachrelation(p_objLisApplMainOutVO);
                    //}
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                throw objEx;
            }

            return lngRes;
        }
        #endregion

        #region 插入中间关系表
        /// <summary>
        /// 插入中间关系表
        /// </summary>
        /// <param name="p_objMainVO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngInsertAttachrelation(clsLisApplMainVO p_objMainVO)
        {
            long lngRes = 0;
            if (p_objMainVO.m_strOrderArr == null || p_objMainVO.m_strOrderArr.Length <= 0)
            {
                return 1;
            }
            object[][] objValue = new object[5][];
            DbType[] m_dbTyp = new DbType[] { DbType.Int32, DbType.String, DbType.String, DbType.Int32, DbType.String };
            for (int i = 0; i < objValue.Length; i++)
            {
                objValue[i] = new object[p_objMainVO.m_strOrderArr.Length];
            }
            string strSQL = null;
            clsHRPTableService objHRPSvc = null;
            try
            {
                strSQL = @"insert into t_opr_attachrelation
                              (attarelaid_chr,
                               sysfrom_int,
                               attachtype_int,
                               sourceitemid_vchr,
                               attachid_vchr,
                               urgency_int,
                               status_int,
                               chargedetail_vchr)
                            values
                              (seq_attachrelation.nextval, ?, 3, ?, ?, ?, 0, ?)
                            ";

                for (int i = 0; i < p_objMainVO.m_strOrderArr.Length; i++)
                {
                    objValue[0][i] = Convert.ToInt32(p_objMainVO.m_strPatientType);
                    objValue[1][i] = p_objMainVO.m_strOrderArr[i];
                    objValue[2][i] = p_objMainVO.m_strAPPLICATION_ID;
                    objValue[3][i] = p_objMainVO.m_intEmergency;
                    objValue[4][i] = p_objMainVO.m_strChargeInfo;
                }
                objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.m_lngSaveArrayWithParameters(strSQL, objValue, m_dbTyp);
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objValue = null;
                m_dbTyp = null;
                objHRPSvc.Dispose();
                strSQL = null;
            }
            return lngRes;

        }
        #endregion

        //        #region	根据申请单取得对应样本的采样说明	
        //        /// <summary>
        //        /// 根据申请单取得对应样本的采样说明
        //        /// </summary>
        //        /// <param name="p_Principal"></param>
        //        /// <param name="p_ApplicationID"></param>
        //        /// <param name="p_objSampleGroupVOArr"></param>
        //        /// <returns></returns>
        //        [AutoComplete]
        //        public long m_lngGetSampleRemark(System.Security.Principal.IPrincipal p_Principal, string p_ApplicationID, out clsSampleGroup_VO[] p_objSampleGroupVOArr)
        //        {
        //            p_objSampleGroupVOArr = null;
        //            long lngRes = 0;
        //            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //            objPrivilege.m_lngCheckCallPrivilege(p_Principal, "clsApplicationSvc", "m_lngGetSampleRemark");
        //            if (lngRes < 0)
        //            {
        //                return -1;
        //            }

        //            string strSQL = @"SELECT a.sample_group_id_chr, a.py_code_chr, a.wb_code_chr,
        //                                   a.assist_code01_chr, a.assist_code02_chr, a.is_hand_work_int,
        //                                   a.device_model_id_chr, a.remark_vchr, a.check_category_id_chr,
        //                                   a.sample_type_id_chr, a.sample_group_name_chr, a.print_title_vchr,
        //                                   a.print_seq_int
        //								FROM t_aid_lis_sample_group a, t_opr_lis_app_sample b
        //								WHERE a.sample_group_id_chr = b.sample_group_id_chr
        //								AND b.application_id_chr = '" + p_ApplicationID + "'";

        //            clsHRPTableService objHRPSvc = new clsHRPTableService();

        //            try
        //            {
        //                DataTable dtbResult = new DataTable();
        //                lngRes = 0;
        //                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
        //                if (lngRes <= 0)
        //                {
        //                    return -1;
        //                }

        //                p_objSampleGroupVOArr = new clsSampleGroup_VO[dtbResult.Rows.Count];
        //                for (int i = 0; i < dtbResult.Rows.Count; i++)
        //                {
        //                    p_objSampleGroupVOArr[i] = new clsSampleGroup_VO();
        //                    p_objSampleGroupVOArr[i].strSampleGroupID = dtbResult.Rows[i]["SAMPLE_GROUP_ID_CHR"].ToString();
        //                    p_objSampleGroupVOArr[i].strPYCode = dtbResult.Rows[i]["PY_CODE_CHR"].ToString();
        //                    p_objSampleGroupVOArr[i].strWBCode = dtbResult.Rows[i]["WB_CODE_CHR"].ToString();
        //                    p_objSampleGroupVOArr[i].strAssistCode01 = dtbResult.Rows[i]["ASSIST_CODE01_CHR"].ToString();
        //                    p_objSampleGroupVOArr[i].strAssistCode02 = dtbResult.Rows[i]["ASSIST_CODE02_CHR"].ToString();
        //                    p_objSampleGroupVOArr[i].strIsHandWork = dtbResult.Rows[i]["IS_HAND_WORK_INT"].ToString();
        //                    p_objSampleGroupVOArr[i].strDeviceModelName = dtbResult.Rows[i]["DEVICE_MODEL_ID_CHR"].ToString();
        //                    p_objSampleGroupVOArr[i].strRemark = dtbResult.Rows[i]["REMARK_VCHR"].ToString();
        //                    p_objSampleGroupVOArr[i].strCheckCategoryID = dtbResult.Rows[i]["CHECK_CATEGORY_ID_CHR"].ToString();
        //                    p_objSampleGroupVOArr[i].strSampleTypeID = dtbResult.Rows[i]["SAMPLE_TYPE_ID_CHR"].ToString();
        //                    p_objSampleGroupVOArr[i].strSampleGroupName = dtbResult.Rows[i]["SAMPLE_GROUP_NAME_CHR"].ToString();
        //                    p_objSampleGroupVOArr[i].strPRINT_TITLE_VCHR = dtbResult.Rows[i]["PRINT_TITLE_VCHR"].ToString();
        //                    if (dtbResult.Rows[i]["PRINT_SEQ_INT"] != null && dtbResult.Rows[i]["PRINT_SEQ_INT"].ToString() != "")
        //                    {
        //                        p_objSampleGroupVOArr[i].intPRINT_SEQ_INT = int.Parse(dtbResult.Rows[i]["PRINT_SEQ_INT"].ToString());
        //                    }
        //                }
        //            }
        //            catch (Exception objEx)
        //            {
        //                lngRes = 0;
        //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //                bool blnRes = objLogger.LogError(objEx);
        //            }

        //            return lngRes;
        //        }
        //        #endregion

        //#region 获取配置信息	
        ///// <summary>
        ///// 获取配置信息
        ///// </summary>
        ///// <param name="p_objPrincipal"></param>
        ///// <param name="blIS"></param>
        ///// <param name="strsetid"></param>
        ///// <returns></returns>
        //[AutoComplete]
        //public long m_lngGetCollocate(System.Security.Principal.IPrincipal p_objPrincipal, out bool blIS, string strsetid)
        //{
        //    long lngRes = 0;
        //    blIS = false;
        //    clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //    lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngGetCollocate");
        //    if (lngRes < 0)
        //    {
        //        return -1;
        //    }
        //    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //    string strSQL = @"select SETSTATUS_INT from t_sys_setting where  setid_chr='" + strsetid + "'";
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dt);
        //    }
        //    catch (Exception objEx)
        //    {
        //        string strTmp = objEx.Message;
        //        com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //        bool blnRes = objLogger.LogError(objEx);
        //    }
        //    if (dt.Rows.Count > 0 && int.Parse(dt.Rows[0]["SETSTATUS_INT"].ToString()) == 1)
        //    {
        //        blIS = true;
        //    }
        //    return lngRes;
        //}
        //#endregion

        //#region 获取配置信息(重载)	
        ///// <summary>
        ///// 获取配置信息
        ///// </summary>
        ///// <param name="p_objPrincipal"></param>
        ///// <param name="blIS"></param>
        ///// <param name="strsetid"></param>
        ///// <returns></returns>
        //[AutoComplete]
        //public long m_lngGetCollocate(System.Security.Principal.IPrincipal p_objPrincipal, out string strFlag, string strsetid)
        //{
        //    long lngRes = 0;
        //    strFlag = "";
        //    clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //    lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngGetCollocate");
        //    if (lngRes < 0)
        //    {
        //        return -1;
        //    }
        //    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //    string strSQL = @"select SETSTATUS_INT from t_sys_setting where  setid_chr='" + strsetid + "'";
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        lngRes = 0;
        //        lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dt);
        //    }
        //    catch (Exception objEx)
        //    {
        //        string strTmp = objEx.Message;
        //        com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //        bool blnRes = objLogger.LogError(objEx);
        //    }
        //    if (dt.Rows.Count > 0 && dt.Rows[0]["SETSTATUS_INT"].ToString().Trim() != "")
        //    {
        //        strFlag = dt.Rows[0]["SETSTATUS_INT"].ToString().Trim();
        //    }
        //    return lngRes;
        //}
        //#endregion


        #region PIS接口系统

        #region PIS申请

        /// <summary>
        /// PIS申请
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRecord"></param>
        /// <param name="p_strApplicationIDArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngPISApplication(System.Security.Principal.IPrincipal p_objPrincipal, clsPISApplicationInfoToLIS p_objRecord,
            out string[] p_strApplicationIDArr)
        {
            long lngRes = 0;
            p_strApplicationIDArr = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngPISApplication");
            if (lngRes < 0)
            {
                return -1;
            }

            if (p_objRecord == null)
                return -1;

            string strPara = "";

            for (int i = 0; i < p_objRecord.m_strApplyUnitArr.Length; i++)
            {
                if (i != p_objRecord.m_strApplyUnitArr.Length - 1)
                {
                    strPara += " ?,";
                }
                else
                {
                    strPara += " ?";
                }
            }

            #region SQL

            string strApplySQL = @"SELECT a.sample_group_id_chr, c.sample_group_name_chr, a.apply_unit_id_chr,
										  b.report_group_id_chr, g.sample_type_desc_vchr, g.sample_type_id_chr
									FROM t_aid_lis_sample_group_unit a,
										 t_aid_lis_report_group_detail b,
										 t_aid_lis_sample_group c,
										 (SELECT f.sample_group_id_chr, d.sample_type_desc_vchr,
												 e.sample_type_id_chr
											FROM t_aid_lis_sampletype d,
												 t_aid_lis_group_sample_type e,
												 t_aid_lis_sample_group f
										   WHERE f.sample_group_id_chr = e.sample_group_id_chr
											 AND e.sample_type_id_chr = d.sample_type_id_chr) g
									WHERE a.sample_group_id_chr = b.sample_group_id_chr
									  AND a.sample_group_id_chr = c.sample_group_id_chr
									  AND c.sample_group_id_chr = g.sample_group_id_chr(+)
									  AND a.apply_unit_id_chr IN ( " + strPara + " )";
            string strUnitItemSQL = @"SELECT a.*,b.sample_group_id_chr
										FROM t_aid_lis_apply_unit_detail a,
											 t_aid_lis_sample_group_unit b
									   WHERE a.apply_unit_id_chr IN ( " + strPara + @" )
										 AND a.apply_unit_id_chr = b.apply_unit_id_chr";

            #endregion

            ArrayList arlApplyUnit = new ArrayList();
            if (p_objRecord != null && p_objRecord.m_strApplyUnitArr != null && p_objRecord.m_strApplyUnitArr.Length > 0)
            {
                for (int i = 0; i < p_objRecord.m_strApplyUnitArr.Length; i++)
                {
                    arlApplyUnit.Add(p_objRecord.m_strApplyUnitArr[i]);
                }
            }

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            try
            {
                DataTable dtbSampleGroup = null;
                DataTable dtbApplyUnit = null;
                System.Data.IDataParameter[] objIDPApply = clsPublicSvc.m_objConstructIDataParameterArr(arlApplyUnit.ToArray());
                System.Data.IDataParameter[] objIDPItem = clsPublicSvc.m_objConstructIDataParameterArr(arlApplyUnit.ToArray());
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strApplySQL, ref dtbSampleGroup, objIDPApply);
                if (lngRes > 0 && dtbSampleGroup != null && dtbSampleGroup.Rows.Count > 0)
                {
                    lngRes = 0;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strUnitItemSQL, ref dtbApplyUnit, objIDPItem);
                }
                if (lngRes <= 0)
                {
                    ContextUtil.SetAbort();
                }

                ArrayList arlApplication = new ArrayList();

                #region 拆分申请单构造VO
                if (dtbSampleGroup != null && dtbSampleGroup.Rows.Count > 0)
                {
                    bool blnContained = false;
                    for (int i = 0; i < dtbSampleGroup.Rows.Count; i++)
                    {
                        blnContained = false;
                        if (arlApplication.Count > 0)
                        {
                            for (int j = 0; j < arlApplication.Count; j++)
                            {
                                if (dtbSampleGroup.Rows[i]["sample_group_id_chr"].ToString().Trim()
                                    == ((clsLISApplicationUnite)arlApplication[j]).m_objAppSampleArr[0].m_strSAMPLE_GROUP_ID_CHR)
                                {
                                    blnContained = true;
                                    break;
                                }
                            }
                        }

                        if (!blnContained)
                        {
                            clsLISApplicationUnite objApply = new clsLISApplicationUnite();
                            //Construct Application
                            objApply.m_objLisApplMainVO = new clsLisApplMainVO();
                            objApply.m_objLisApplMainVO.m_intEmergency = 0;
                            objApply.m_objLisApplMainVO.m_intForm_int = 0;
                            objApply.m_objLisApplMainVO.m_intPStatus_int = 2;
                            objApply.m_objLisApplMainVO.m_intSpecial = 0;
                            objApply.m_objLisApplMainVO.m_strAge = p_objRecord.m_strPERSON_AGE_VCHR;
                            objApply.m_objLisApplMainVO.m_strAppl_Dat = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            //							objApply.m_objLisApplMainVO.m_strAppl_DeptID
                            objApply.m_objLisApplMainVO.m_strAppl_EmpID = p_objRecord.m_strAPPLY_OPR_ID_CHR;
                            objApply.m_objLisApplMainVO.m_strCheckContent = dtbSampleGroup.Rows[i]["SAMPLE_GROUP_NAME_CHR"].ToString().Trim();
                            objApply.m_objLisApplMainVO.m_strMODIFY_DAT = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            objApply.m_objLisApplMainVO.m_strOperator_ID = p_objRecord.m_strAPPLY_OPR_ID_CHR;
                            objApply.m_objLisApplMainVO.m_strOriginDate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            objApply.m_objLisApplMainVO.m_strPatient_Name = p_objRecord.m_strPERSON_NAME_VCHR;
                            objApply.m_objLisApplMainVO.m_strPatientType = "3";
                            objApply.m_objLisApplMainVO.m_strSampleType = dtbSampleGroup.Rows[i]["SAMPLE_TYPE_DESC_VCHR"].ToString().Trim();
                            objApply.m_objLisApplMainVO.m_strSampleTypeID = dtbSampleGroup.Rows[i]["SAMPLE_TYPE_ID_CHR"].ToString().Trim();
                            objApply.m_objLisApplMainVO.m_strSex = p_objRecord.m_strPERSON_SEX_VCHR;
                            //Construct Appliation Report
                            objApply.m_objReportArr = new clsT_OPR_LIS_APP_REPORT_VO[1];
                            objApply.m_objReportArr[0] = new clsT_OPR_LIS_APP_REPORT_VO();
                            objApply.m_objReportArr[0].m_intSTATUS_INT = 1;
                            objApply.m_objReportArr[0].m_strMODIFY_DAT = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            objApply.m_objReportArr[0].m_strOPERATOR_ID_CHR = p_objRecord.m_strAPPLY_OPR_ID_CHR;
                            objApply.m_objReportArr[0].m_strREPORT_GROUP_ID_CHR = dtbSampleGroup.Rows[i]["report_group_id_chr"].ToString().Trim();
                            //Construct Application Sample
                            objApply.m_objAppSampleArr = new clsT_OPR_LIS_APP_SAMPLE_VO[1];
                            objApply.m_objAppSampleArr[0] = new clsT_OPR_LIS_APP_SAMPLE_VO();
                            objApply.m_objAppSampleArr[0].m_strREPORT_GROUP_ID_CHR = objApply.m_objReportArr[0].m_strREPORT_GROUP_ID_CHR;
                            objApply.m_objAppSampleArr[0].m_strSAMPLE_GROUP_ID_CHR = dtbSampleGroup.Rows[i]["sample_group_id_chr"].ToString().Trim();
                            //Construct Application Unit
                            DataRow[] dtrApplyUnitArr =
                                dtbSampleGroup.Select("sample_group_id_chr = " + dtbSampleGroup.Rows[i]["sample_group_id_chr"].ToString().Trim());
                            objApply.m_objAppUnitArr = new clsT_OPR_LIS_APP_APPLY_UNIT_VO[dtrApplyUnitArr.Length];
                            for (int j = 0; j < dtrApplyUnitArr.Length; j++)
                            {
                                objApply.m_objAppUnitArr[j] = new clsT_OPR_LIS_APP_APPLY_UNIT_VO();
                                objApply.m_objAppUnitArr[j].m_strAPPLY_UNIT_ID_CHR = dtrApplyUnitArr[j]["apply_unit_id_chr"].ToString().Trim();
                                objApply.m_objAppUnitArr[j].m_strUSER_GROUP_STRING = dtrApplyUnitArr[j]["apply_unit_id_chr"].ToString().Trim();
                            }
                            //Construct Application Unit Item
                            DataRow[] dtrUnitItemArr =
                                dtbApplyUnit.Select("sample_group_id_chr = " + dtbSampleGroup.Rows[i]["sample_group_id_chr"].ToString().Trim());
                            objApply.m_objAppUnitItemArr = new clsLisAppUnitItemVO[dtrUnitItemArr.Length];
                            objApply.m_objAppItemArr = new clsT_OPR_LIS_APP_CHECK_ITEM_VO[dtrUnitItemArr.Length];
                            for (int j = 0; j < dtrUnitItemArr.Length; j++)
                            {
                                objApply.m_objAppUnitItemArr[j] = new clsLisAppUnitItemVO();
                                objApply.m_objAppUnitItemArr[j].m_strAPPLY_UNIT_ID_CHR = dtrUnitItemArr[j]["apply_unit_id_chr"].ToString().Trim();
                                objApply.m_objAppUnitItemArr[j].m_strCHECK_ITEM_ID_CHR = dtrUnitItemArr[j]["CHECK_ITEM_ID_CHR"].ToString().Trim();
                                objApply.m_objAppItemArr[j] = new clsT_OPR_LIS_APP_CHECK_ITEM_VO();
                                objApply.m_objAppItemArr[j].m_strSAMPLE_GROUP_ID_CHR = dtrUnitItemArr[j]["sample_group_id_chr"].ToString().Trim();
                                objApply.m_objAppItemArr[j].m_strREPORT_GROUP_ID_CHR = dtbSampleGroup.Rows[i]["report_group_id_chr"].ToString().Trim();
                                objApply.m_objAppItemArr[j].m_strCHECK_ITEM_ID_CHR = dtrUnitItemArr[j]["CHECK_ITEM_ID_CHR"].ToString().Trim();
                            }
                            arlApplication.Add(objApply);
                        }
                    }
                }
                #endregion

                #region 新增申请

                if (arlApplication.Count > 0)
                {
                    ArrayList arlApplicationID = new ArrayList();
                    for (int i = 0; i < arlApplication.Count; i++)
                    {
                        clsLISApplicationUnite objApply = (clsLISApplicationUnite)arlApplication[i];
                        lngRes = 0;
                        lngRes = m_lngAddNewAppAndSampleInfo(p_objPrincipal, objApply.m_objLisApplMainVO, out objApply.m_objLisApplMainVO, objApply.m_objReportArr, objApply.m_objAppSampleArr,
                            objApply.m_objAppItemArr, objApply.m_objAppUnitArr, objApply.m_objAppUnitItemArr);
                        if (lngRes <= 0)
                        {
                            break;
                        }
                        else
                        {
                            arlApplicationID.Add(objApply.m_objLisApplMainVO.m_strAPPLICATION_ID);
                        }
                    }

                    if (lngRes <= 0)
                    {
                        ContextUtil.SetAbort();
                    }
                    if (arlApplicationID.Count > 0)
                    {
                        p_strApplicationIDArr = (string[])arlApplicationID.ToArray(typeof(string));
                    }
                }

                #endregion
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }

        #endregion

        //        #region 根据体检号和体检组合项目ID查询PIS申请报告单 

        //        /// <summary>
        //        /// 根据体检号和体检组合项目ID查询PIS申请报告单
        //        /// </summary>
        //        /// <param name="p_objPrincipal"></param>
        //        /// <param name="p_strExamineID"></param>
        //        /// <param name="p_strItemGroupID"></param>
        //        /// <param name="p_objApplyReportArr"></param>
        //        /// <returns></returns>
        //        [AutoComplete]
        //        public long m_lngFindApplyReportArrByExamineIDItemGroupID(System.Security.Principal.IPrincipal p_objPrincipal,
        //            string p_strExamineID, string p_strItemGroupID, out clsLisApplyReportInfo_VO[] p_objApplyReportArr)
        //        {
        //            long lngRes = 0;
        //            p_objApplyReportArr = null;
        //            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc"
        //                , "m_lngFindApplyReportArrByExamineIDItemGroupID");
        //            if (lngRes <= 0)
        //            {
        //                return -1;
        //            }

        //            #region SQL

        //            string strSQL = @"SELECT a.*, f.collector, f.sampling_date_dat, d.lastname_vchr AS applyer,
        //									 e.deptname_vchr
        //								FROM t_opr_lis_application a,
        //									 t_bse_employee d,
        //									 t_bse_deptdesc e,
        //									 (SELECT c.lastname_vchr AS collector, b.*
        //										FROM t_opr_lis_sample b, t_bse_employee c
        //									   WHERE b.application_id_chr IN (
        //												SELECT DISTINCT a.application_id_chr
        //															FROM t_pis_opr_application_to_lis a,
        //																 t_pis_aid_item_to_lis b,
        //																 t_opr_lis_app_apply_unit c
        //															WHERE a.person_examine_id_chr = ?
        //															 AND b.group_id_chr = ?
        //															 AND b.apply_unit_id_chr = c.apply_unit_id_chr
        //															 AND a.application_id_chr = c.application_id_chr)
        //										AND b.status_int > 0
        //										AND b.collector_id_chr = c.empid_chr(+)) f
        //								WHERE a.application_id_chr = f.application_id_chr(+)
        //								AND a.appl_empid_chr = d.empid_chr(+)
        //								AND a.appl_deptid_chr = e.deptid_chr(+)
        //								AND a.pstatus_int > 0
        //								AND a.application_id_chr IN (
        //										SELECT DISTINCT a.application_id_chr
        //													FROM t_pis_opr_application_to_lis a,
        //														t_pis_aid_item_to_lis b,
        //														t_opr_lis_app_apply_unit c
        //													WHERE a.person_examine_id_chr = ?
        //													AND b.group_id_chr = ?
        //													AND b.apply_unit_id_chr = c.apply_unit_id_chr
        //													AND a.application_id_chr = c.application_id_chr)";

        //            #endregion

        //            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

        //            try
        //            {
        //                System.Data.IDataParameter[] objIDPArr = this.m_objConstructIDataParameterArr(p_strExamineID, p_strItemGroupID,
        //                    p_strExamineID, p_strItemGroupID);
        //                DataTable dtbResult = null;
        //                lngRes = 0;
        //                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objIDPArr);
        //                if (lngRes > 0 && dtbResult != null && dtbResult.Rows.Count > 0)
        //                {
        //                    p_objApplyReportArr = new clsLisApplyReportInfo_VO[dtbResult.Rows.Count];
        //                    clsVOConstructor objConstructor = new clsVOConstructor();
        //                    for (int i = 0; i < p_objApplyReportArr.Length; i++)
        //                    {
        //                        p_objApplyReportArr[i] = objConstructor.m_mthContructApplyReportInfoVO(dtbResult.Rows[i]);
        //                    }
        //                }
        //            }
        //            catch (Exception objEx)
        //            {
        //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //                bool blnRes = objLogger.LogError(objEx);
        //            }
        //            return lngRes;
        //        }

        //        #endregion

        //        #region 查询根据体检号PIS申请报告单

        //        /// <summary>
        //        /// 查询根据体检号PIS申请报告单
        //        /// </summary>
        //        /// <param name="p_objPrincipal"></param>
        //        /// <param name="p_strExamineID"></param>
        //        /// <param name="p_objApplyReportArr"></param>
        //        /// <returns></returns>
        //        [AutoComplete]
        //        public long m_lngFindApplyReportArrByExamineID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strExamineID,
        //            out clsLisApplyReportInfo_VO[] p_objApplyReportArr)
        //        {
        //            long lngRes = 0;
        //            p_objApplyReportArr = null;
        //            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc"
        //                , "m_lngFindApplyReportArrByExamineID");
        //            if (lngRes <= 0)
        //            {
        //                return -1;
        //            }

        //            #region SQL

        //            string strSQL = @"SELECT a.*, f.collector, f.sampling_date_dat, d.lastname_vchr AS applyer,
        //									 e.deptname_vchr
        //								FROM t_opr_lis_application a,
        //									 t_bse_employee d,
        //									 t_bse_deptdesc e,
        //									 (SELECT c.lastname_vchr AS collector, b.*
        //										FROM t_opr_lis_sample b, t_bse_employee c
        //									   WHERE b.application_id_chr IN (
        //																SELECT a.application_id_chr
        //																  FROM t_pis_opr_application_to_lis a
        //																 WHERE a.person_examine_id_chr = ? )
        //										AND b.status_int > 0
        //										AND b.collector_id_chr = c.empid_chr(+)) f
        //								WHERE a.application_id_chr = f.application_id_chr(+)
        //								  AND a.appl_empid_chr = d.empid_chr(+)
        //								  AND a.appl_deptid_chr = e.deptid_chr(+)
        //								  AND a.pstatus_int > 0
        //								  AND a.application_id_chr IN (SELECT a.application_id_chr
        //																 FROM t_pis_opr_application_to_lis a
        //																WHERE a.person_examine_id_chr = ? )";

        //            #endregion

        //            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

        //            try
        //            {
        //                System.Data.IDataParameter[] objIDPArr = this.m_objConstructIDataParameterArr(p_strExamineID, p_strExamineID);
        //                DataTable dtbResult = null;
        //                lngRes = 0;
        //                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objIDPArr);
        //                if (lngRes > 0 && dtbResult != null && dtbResult.Rows.Count > 0)
        //                {
        //                    p_objApplyReportArr = new clsLisApplyReportInfo_VO[dtbResult.Rows.Count];
        //                    clsVOConstructor objConstructor = new clsVOConstructor();
        //                    for (int i = 0; i < p_objApplyReportArr.Length; i++)
        //                    {
        //                        p_objApplyReportArr[i] = objConstructor.m_mthContructApplyReportInfoVO(dtbResult.Rows[i]);
        //                    }
        //                }
        //            }
        //            catch (Exception objEx)
        //            {
        //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //                bool blnRes = objLogger.LogError(objEx);
        //            }
        //            return lngRes;
        //        }

        //        #endregion

        #endregion

        #region 根据申请单ID作废相应的仪器关联
        /// <summary>
        /// 根据申请单ID作废相应的仪器关联
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strApplicationID"></param>
        /// <param name="p_strOringinDate"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteDeviceRelationByApplicationID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strApplicationID, string p_strOringinDate)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngDeleteDeviceRelationByApplicationID");
            if (lngRes < 0)
            {
                return -1;
            }

            if (p_strApplicationID == null)
            {
                return 1;
            }

            try
            {
                DateTime.Parse(p_strOringinDate);
            }
            catch
            {
                p_strOringinDate = "1900-01-01 00:00:00";
            }
            #region SQL
            string strSQL = @"UPDATE t_opr_lis_device_relation 
								SET status_int = 0 
								WHERE sample_id_chr IN ( 
										SELECT sample_id_chr 
											FROM t_opr_lis_sample 
										WHERE status_int > 0 
											AND application_id_chr = ? 
											AND modify_dat >= TO_DATE(?,'yyyy-mm-dd hh24:mi:ss')) 
								AND status_int > 0
								";
            #endregion

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            IDataParameter[] objDPArr = null;
            objHRPSvc.CreateDatabaseParameter(2, out objDPArr);
            objDPArr[0].Value = p_strApplicationID;
            objDPArr[1].Value = p_strOringinDate;

            DataTable dtbResult = null;
            try
            {
                long lngEff = 0;
                lngRes = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        #endregion

        #region 修改申请单病人信息并相应修改样本信息
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objApplVO">clsLisApplMainVO</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSetApplicationAndSamplePatientInfo(System.Security.Principal.IPrincipal p_objPrincipal, clsLisApplMainVO p_objApplVO)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngSetApplicationAndSamplePatientInfo");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSampleSQL = @"select appl_dat, sex_chr, patient_name_vchr, patient_subno_chr, age_chr,
                                           patient_type_chr, diagnose_vchr, sampletype_vchr, samplestate_vchr,
                                           bedno_chr, icd_vchr, patientcardid_chr, barcode_vchr, sample_id_chr,
                                           patientid_chr, sampling_date_dat, operator_id_chr, modify_dat,
                                           appl_empid_chr, appl_deptid_chr, status_int, sample_type_id_chr,
                                           qcsampleid_chr, samplekind_chr, check_date_dat, accept_dat,
                                           acceptor_id_chr, application_id_chr, patient_inhospitalno_chr,
                                           confirm_dat, confirmer_id_chr, collector_id_chr, checker_id_chr,sendsample_empid_chr
                                      from t_opr_lis_sample t
                                    where application_id_chr = '" + p_objApplVO.m_strAPPLICATION_ID + @"' and status_int > 0";
            clsT_OPR_LIS_SAMPLE_VO[] objSampleArr = null;
            clsSampleSvc objSampleSvc = new clsSampleSvc();

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            clsVOConstructor objConstructor = new clsVOConstructor();

            try
            {
                clsLisApplMainVO objApplVO = null;
                lngRes = m_lngAddNewAppl(p_objPrincipal, p_objApplVO, out objApplVO);
                if (lngRes > 0)
                {
                    DataTable dtbSample = null;
                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSampleSQL, ref dtbSample);
                    objHRPSvc.Dispose();
                    if (lngRes > 0 && dtbSample != null && dtbSample.Rows.Count > 0)
                    {
                        objSampleArr = new clsT_OPR_LIS_SAMPLE_VO[dtbSample.Rows.Count];
                        for (int i = 0; i < dtbSample.Rows.Count; i++)
                        {
                            objSampleArr[i] = objConstructor.m_objConstructSampleVO(dtbSample.Rows[i]);
                            objSampleArr[i].m_strPATIENT_NAME_VCHR = p_objApplVO.m_strPatient_Name;
                            objSampleArr[i].m_strSEX_CHR = p_objApplVO.m_strSex;
                            objSampleArr[i].m_strAGE_CHR = p_objApplVO.m_strAge;
                            objSampleArr[i].m_strPATIENT_INHOSPITALNO_CHR = p_objApplVO.m_strPatient_inhospitalno_chr;
                            objSampleArr[i].m_strBEDNO_CHR = p_objApplVO.m_strBedNO;
                            objSampleArr[i].m_strAPPL_DEPTID_CHR = p_objApplVO.m_strAppl_DeptID;
                            objSampleArr[i].m_strAPPL_EMPID_CHR = p_objApplVO.m_strAppl_EmpID;
                            objSampleArr[i].m_strPATIENT_TYPE_CHR = p_objApplVO.m_strPatientType;
                            objSampleArr[i].m_strDIAGNOSE_VCHR = p_objApplVO.m_strDiagnose;
                            objSampleArr[i].m_strSAMPLE_TYPE_ID_CHR = p_objApplVO.m_strSampleTypeID;
                            objSampleArr[i].m_strSAMPLETYPE_VCHR = p_objApplVO.m_strSampleType;
                            objSampleArr[i].m_strAPPL_DAT = p_objApplVO.m_strAppl_Dat;
                            objSampleArr[i].m_strICD_VCHR = p_objApplVO.m_strICD;
                            objSampleArr[i].m_strPATIENT_SUBNO_CHR = p_objApplVO.m_strPatient_SubNO;
                            objSampleArr[i].m_strPATIENTCARDID_CHR = p_objApplVO.m_strPatientcardID;
                            objSampleArr[i].m_strPATIENTID_CHR = p_objApplVO.m_strPatientID;

                            if (!string.IsNullOrEmpty(p_objApplVO.m_strAcceptDate))
                            {
                                objSampleArr[i].m_strACCEPT_DAT = p_objApplVO.m_strAcceptDate;
                            }
                        }
                        lngRes = objSampleSvc.m_lngInsertSampleRecord(p_objPrincipal, objSampleArr);
                    }
                }
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                objHRPSvc.Dispose();
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        //        #region 根据病人住院号和住院日期查询,出院日期 查询得到 检验结果信息
        //        /// <summary>
        //        /// 根据病人住院号和住院日期查询,出院日期 查询得到 检验结果信息
        //        /// </summary>
        //        /// <param name="p_objPrincipal"></param>
        //        /// <param name="p_strInPatientNO"></param>
        //        /// <param name="p_strInHospitalDate"></param>
        //        /// <param name="p_strOutHospitalDate"></param>
        //        /// <param name="p_objResultArr"></param>
        //        /// <returns></returns>
        //        [AutoComplete]
        //        public long m_lngGetResultInfo(System.Security.Principal.IPrincipal p_objPrincipal,
        //            string p_strInPatientNO, string p_strInHospitalDate, string p_strOutHospitalDate,
        //            out clsLISPatientCheckResultInfoVO[] p_objResultArr)
        //        {
        //            long lngRes = 0;
        //            p_objResultArr = null;

        //            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngGetResultInfo");
        //            if (lngRes < 0)
        //            {
        //                return -1;
        //            }

        //            string strSQL = @"SELECT t1.application_id_chr, t1.patientid_chr, t1.application_dat,
        //                                   t1.sex_chr, t1.patient_name_vchr, t1.patient_subno_chr, t1.age_chr,
        //                                   t1.patient_type_id_chr, t1.diagnose_vchr, t1.bedno_chr, t1.icdcode_chr,
        //                                   t1.patientcardid_chr, t1.application_form_no_chr, t1.modify_dat,
        //                                   t1.operator_id_chr, t1.appl_empid_chr, t1.appl_deptid_chr,
        //                                   t1.summary_vchr, t1.pstatus_int, t1.emergency_int, t1.special_int,
        //                                   t1.form_int, t1.patient_inhospitalno_chr, t1.sample_type_id_chr,
        //                                   t1.check_content_vchr, t1.sample_type_vchr, t1.oringin_dat,
        //                                   t1.charge_info_vchr, t1.printed_num, t1.orderunitrelation_vchr,
        //                                   t1.printed_date, 
        //                                   t2.summary_vchr AS report_summary_vchr, t2.confirm_dat AS report_confirm_dat
        //								FROM t_opr_lis_application t1, t_opr_lis_app_report t2
        //								WHERE t1.application_id_chr = t2.application_id_chr
        //								AND t1.pstatus_int + 0 = 2
        //								AND t2.status_int = 2
        //								AND TRIM(patient_inhospitalno_chr) = TRIM(?)
        //								AND application_dat >= TO_DATE (?, 'yyyy-mm-dd hh24:mi:ss')
        //								AND application_dat <= TO_DATE (?, 'yyyy-mm-dd hh24:mi:ss')";
        //            string strSQL_ItemResult = @"SELECT *
        //											FROM t_opr_lis_check_result t1
        //											WHERE t1.status_int = 1
        //											AND t1.modify_dat >= TO_DATE(?, 'yyyy-mm-dd hh24:mi:ss') 
        //											AND t1.sample_id_chr IN (SELECT t2.sample_id_chr
        //																		FROM t_opr_lis_app_sample t2
        //																		WHERE t2.application_id_chr = ?)";

        //            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //            clsVOConstructor objConstructor = new clsVOConstructor();

        //            try
        //            {
        //                try
        //                {
        //                    DateTime.Parse(p_strInHospitalDate);
        //                }
        //                catch
        //                {
        //                    p_strInHospitalDate = "1900-01-01 00:00:00";
        //                }
        //                try
        //                {
        //                    DateTime.Parse(p_strOutHospitalDate);
        //                }
        //                catch
        //                {
        //                    p_strOutHospitalDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //                }


        //                IDataParameter[] objDPArr = null;
        //                objHRPSvc.CreateDatabaseParameter(3, out objDPArr);

        //                objDPArr[0].Value = p_strInPatientNO;
        //                objDPArr[1].Value = p_strInHospitalDate;
        //                objDPArr[2].Value = p_strOutHospitalDate;

        //                DataTable dtbResult = new DataTable();
        //                lngRes = 0;
        //                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);
        //                if (lngRes > 0 && dtbResult.Rows.Count > 0)
        //                {
        //                    p_objResultArr = new clsLISPatientCheckResultInfoVO[dtbResult.Rows.Count];
        //                    for (int i = 0; i < dtbResult.Rows.Count; i++)
        //                    {
        //                        p_objResultArr[i] = new clsLISPatientCheckResultInfoVO();
        //                        p_objResultArr[i].m_objApp = objConstructor.m_objConstructAppMainVO(dtbResult.Rows[i]);
        //                        p_objResultArr[i].m_objAppReport = new clsT_OPR_LIS_APP_REPORT_VO();
        //                        p_objResultArr[i].m_objAppReport.m_strSUMMARY_VCHR = dtbResult.Rows[i]["report_summary_vchr"].ToString();
        //                        p_objResultArr[i].m_objAppReport.m_strCONFIRM_DAT = dtbResult.Rows[i]["report_confirm_dat"].ToString();

        //                        IDataParameter[] objDPArr1 = null;
        //                        objHRPSvc.CreateDatabaseParameter(2, out objDPArr1);

        //                        objDPArr1[0].Value = p_objResultArr[i].m_objApp.m_strOriginDate;
        //                        objDPArr1[1].Value = p_objResultArr[i].m_objApp.m_strAPPLICATION_ID;

        //                        DataTable dtbResult1 = new DataTable();
        //                        lngRes = 0;
        //                        lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL_ItemResult, ref dtbResult1, objDPArr1);
        //                        if (lngRes > 0 && dtbResult1.Rows.Count > 0)
        //                        {
        //                            p_objResultArr[i].m_objResults = new clsCheckResult_VO[dtbResult1.Rows.Count];
        //                            for (int j = 0; j < dtbResult1.Rows.Count; j++)
        //                            {
        //                                p_objResultArr[i].m_objResults[j] = objConstructor.m_objConstructCheckResultVO(dtbResult1.Rows[j]);
        //                            }
        //                        }
        //                    }
        //                }
        //                objHRPSvc.Dispose();
        //            }
        //            catch (Exception objEx)
        //            {
        //                lngRes = 0;
        //                p_objResultArr = null;
        //                objHRPSvc.Dispose();
        //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //                bool blnRes = objLogger.LogError(objEx);
        //            }
        //            return lngRes;
        //        }

        //        #endregion

        //        #region 根据申请单ID查询打印申请单信息 
        //        /// <summary>
        //        /// 根据申请单ID查询打印申请单信息
        //        /// </summary>
        //        /// <param name="p_objPrincipal"></param>
        //        /// <param name="p_strApplicationID"></param>
        //        /// <param name="p_objResult"></param>
        //        /// <returns></returns>
        //        [AutoComplete]
        //        public long m_lngGetApplicationReportInfo(System.Security.Principal.IPrincipal p_objPrincipal, string p_strApplicationID,
        //            out clsLisApplyReportInfo_VO p_objResult)
        //        {
        //            long lngRes = 0;
        //            p_objResult = null;
        //            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngGetApplicationReportInfo");
        //            if (lngRes < 0)
        //            {
        //                return -1;
        //            }

        //            string strSQL = @"select a.application_id_chr,
        //       a.patientid_chr,
        //       a.application_dat,
        //       a.sex_chr,
        //       a.patient_name_vchr,
        //       a.patient_subno_chr,
        //       a.age_chr,
        //       a.patient_type_id_chr,
        //       a.diagnose_vchr,
        //       a.bedno_chr,
        //       a.icdcode_chr,
        //       a.patientcardid_chr,
        //       a.application_form_no_chr,
        //       a.modify_dat,
        //       a.operator_id_chr,
        //       a.appl_empid_chr,
        //       a.appl_deptid_chr,
        //       a.summary_vchr,
        //       a.pstatus_int,
        //       a.emergency_int,
        //       a.special_int,
        //       a.form_int,
        //       a.patient_inhospitalno_chr,
        //       a.sample_type_id_chr,
        //       a.check_content_vchr,
        //       a.sample_type_vchr,
        //       a.oringin_dat,
        //       a.charge_info_vchr,
        //       a.printed_num,
        //       a.orderunitrelation_vchr,
        //       a.printed_date,
        //       d.lastname_vchr as applyer,
        //       e.deptname_vchr,
        //       f.collector,
        //       f.sampling_date_dat,
        //       f.barcode_vchr
        //  from t_opr_lis_application a,
        //       t_bse_employee d,
        //       t_bse_deptdesc e,
        //       (select c.lastname_vchr as collector,
        //               b.barcode_vchr,
        //               b.sample_id_chr,
        //               b.sampling_date_dat,
        //               b.application_id_chr
        //          from t_opr_lis_sample b, t_bse_employee c
        //         where b.application_id_chr = ?
        //           and b.status_int > 0
        //           and b.collector_id_chr = c.empid_chr(+)) f
        // where a.application_id_chr = f.application_id_chr(+)
        //   and a.appl_empid_chr = d.empid_chr(+)
        //   and a.appl_deptid_chr = e.deptid_chr(+)
        //   and a.pstatus_int > 0
        //   and a.application_id_chr = ?";
        //            try
        //            {
        //                DataTable dtbResult = new DataTable();
        //                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //                IDataParameter[] objParamArr = null;
        //                objHRPSvc.CreateDatabaseParameter(2, out objParamArr);
        //                objParamArr[0].Value = p_strApplicationID;
        //                objParamArr[1].Value = p_strApplicationID;
        //                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objParamArr);
        //                objHRPSvc.Dispose();
        //                if (lngRes > 0 && dtbResult.Rows.Count > 0)
        //                {
        //                    clsVOConstructor objConstructor = new clsVOConstructor();
        //                    p_objResult = objConstructor.m_mthContructApplyReportInfoVO(dtbResult.Rows[0]);
        //                    if (p_objResult != null)
        //                        p_objResult.m_strBarCode = dtbResult.Rows[0]["barcode_vchr"].ToString().Trim();
        //                }
        //            }
        //            catch (Exception objEx)
        //            {
        //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //                bool blnRes = objLogger.LogDetailError(objEx, true);
        //            }
        //            return lngRes;
        //        }
        //        #endregion

        //        #region 根据申请单ID查询得到申请单详细信息 
        //        /// <summary>
        //        /// 根据申请单ID查询得到申请单详细信息
        //        /// </summary>
        //        /// <param name="p_objPrincipal"></param>
        //        /// <param name="p_strApplicationID"></param>
        //        /// <param name="p_strOringinDate"></param>
        //        /// <param name="p_objLISInfoVO"></param>
        //        /// <returns></returns>
        //        [AutoComplete]
        //        public long m_lngGetLISInfoByApplicationID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strApplicationID, string p_strOringinDate, out clsLISInfoVO p_objLISInfoVO)
        //        {
        //            long lngRes = 0;
        //            p_objLISInfoVO = null;
        //            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngGetLISInfoByApplicationID");
        //            if (lngRes < 0)
        //            {
        //                return -1;
        //            }

        //            if (p_strApplicationID == null)
        //            {
        //                return 1;
        //            }

        //            try
        //            {
        //                DateTime.Parse(p_strOringinDate);
        //            }
        //            catch
        //            {
        //                p_strOringinDate = "1900-01-01 00:00:00";
        //            }
        //            #region SQL
        //            string strSQL = @"SELECT t1.application_id_chr, t1.patientid_chr, t1.application_dat,
        //                                   t1.sex_chr, t1.patient_name_vchr, t1.patient_subno_chr, t1.age_chr,
        //                                   t1.patient_type_id_chr, t1.diagnose_vchr, t1.bedno_chr, t1.icdcode_chr,
        //                                   t1.patientcardid_chr, t1.application_form_no_chr, t1.modify_dat,
        //                                   t1.operator_id_chr, t1.appl_empid_chr, t1.appl_deptid_chr,
        //                                   t1.summary_vchr, t1.pstatus_int, t1.emergency_int, t1.special_int,
        //                                   t1.form_int, t1.patient_inhospitalno_chr, t1.sample_type_id_chr,
        //                                   t1.check_content_vchr, t1.sample_type_vchr, t1.oringin_dat,
        //                                   t1.charge_info_vchr, t1.printed_num, t1.orderunitrelation_vchr,
        //                                   t1.printed_date, 
        //                                   t2.application_id_chr, t2.report_group_id_chr, t2.modify_dat,
        //                                   t2.summary_vchr, t2.operator_id_chr, t2.status_int, t2.report_dat,
        //                                   t2.reportor_id_chr, t2.confirm_dat, t2.confirmer_id_chr,
        //                                   t2.xml_summary_vchr, t2.annotation_vchr, t2.xml_annotation_vchr, 
        //                                   t2.summary_vchr AS report_summary_vchr, 
        //                                   t3.appl_dat, t3.sex_chr, t3.patient_name_vchr, t3.patient_subno_chr,
        //                                   t3.age_chr, t3.patient_type_chr, t3.diagnose_vchr, t3.sampletype_vchr,
        //                                   t3.samplestate_vchr, t3.bedno_chr, t3.icd_vchr, t3.patientcardid_chr,
        //                                   t3.barcode_vchr, t3.sample_id_chr, t3.patientid_chr,
        //                                   t3.sampling_date_dat, t3.operator_id_chr, t3.modify_dat,
        //                                   t3.appl_empid_chr, t3.appl_deptid_chr, t3.status_int,
        //                                   t3.sample_type_id_chr, t3.qcsampleid_chr, t3.samplekind_chr,
        //                                   t3.check_date_dat, t3.accept_dat, t3.acceptor_id_chr,
        //                                   t3.application_id_chr, t3.patient_inhospitalno_chr, t3.confirm_dat,
        //                                   t3.confirmer_id_chr, t3.collector_id_chr, t3.checker_id_chr,
        //								   t3.status_int AS sample_status_int
        //								FROM t_opr_lis_application t1, t_opr_lis_app_report t2, t_opr_lis_sample t3
        //								WHERE t1.pstatus_int + 0 = 2
        //								AND t2.status_int > 0
        //								AND (t3.status_int = 3 OR t3.status_int = 5 OR t3.status_int = 6)
        //								AND t1.application_id_chr = t2.application_id_chr
        //								AND t1.application_id_chr = t3.application_id_chr
        //								AND t1.application_id_chr = ?
        //								AND t1.oringin_dat >= ?
        //								";
        //            string strSQL1 = @"SELECT a.apply_unit_id_chr
        //  FROM t_opr_lis_app_apply_unit a
        // WHERE a.application_id_chr = ?";
        //            #endregion

        //            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

        //            IDataParameter[] objDPArr = null;
        //            objHRPSvc.CreateDatabaseParameter(2, out objDPArr);
        //            objDPArr[0].Value = p_strApplicationID;
        //            objDPArr[1].Value = DateTime.Parse(p_strOringinDate);

        //            DataTable dtbResult = null;
        //            try
        //            {
        //                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);
        //                objHRPSvc.Dispose();
        //                if (lngRes == 1 && dtbResult != null && dtbResult.Rows.Count > 0)
        //                {

        //                    IDataParameter[] objDPArr1 = null;
        //                    objHRPSvc.CreateDatabaseParameter(1, out objDPArr1);
        //                    objDPArr1[0].Value = p_strApplicationID;

        //                    DataTable dtbUnits = new DataTable();
        //                    lngRes = 0;
        //                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL1, ref dtbUnits, objDPArr1);
        //                    if (lngRes == 1 && dtbUnits != null && dtbUnits.Rows.Count > 0)
        //                    {
        //                        clsLisApplMainVO objApp = new clsVOConstructor().m_objConstructAppMainVO(dtbResult.Rows[0]);
        //                        clsT_OPR_LIS_APP_REPORT_VO objReport = new clsVOConstructor().m_objConstructAppReportVO(dtbResult.Rows[0]);
        //                        objReport.m_strSUMMARY_VCHR = dtbResult.Rows[0]["report_summary_vchr"].ToString().Trim();
        //                        clsT_OPR_LIS_SAMPLE_VO objSample = new clsVOConstructor().m_objConstructSampleVO(dtbResult.Rows[0]);
        //                        objSample.m_intSTATUS_INT = int.Parse(dtbResult.Rows[0]["sample_status_int"].ToString().Trim());
        //                        objApp.m_strReportGroupID = objReport.m_strREPORT_GROUP_ID_CHR;
        //                        objApp.m_strReportDate = objReport.m_strCONFIRM_DAT;
        //                        objApp.m_intReportStatus = objReport.m_intSTATUS_INT;
        //                        objApp.m_intSampleStatus = objSample.m_intSTATUS_INT;

        //                        p_objLISInfoVO = new clsLISInfoVO();
        //                        p_objLISInfoVO.m_objAppMainVO = objApp;
        //                        p_objLISInfoVO.m_objReportVO = objReport;
        //                        p_objLISInfoVO.m_objSampleVO = objSample;

        //                        p_objLISInfoVO.m_strApplyUnitArr = new string[dtbUnits.Rows.Count];
        //                        for (int i = 0; i < dtbUnits.Rows.Count; i++)
        //                        {
        //                            p_objLISInfoVO.m_strApplyUnitArr[i] = dtbUnits.Rows[i]["apply_unit_id_chr"].ToString().Trim();
        //                        }
        //                    }
        //                }
        //            }
        //            catch (Exception objEx)
        //            {
        //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //                bool blnRes = objLogger.LogError(objEx);
        //            }
        //            return lngRes;
        //        }

        //        #endregion

        #region 添加一条记录到申请单申请单元项目表
        /// <summary>
        /// 添加一条记录到申请单申请单元项目表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        private long m_lngAddNewAppUnitItem(System.Security.Principal.IPrincipal p_objPrincipal, clsLisAppUnitItemVO p_objRecord)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.m_lngAddNewAppUnitItem", "m_lngAddNewAppUnitItem");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            string strSQL = "INSERT INTO T_OPR_LIS_APP_UNIT_ITEM (APPLICATION_ID_CHR,CHECK_ITEM_ID_CHR,APPLY_UNIT_ID_CHR) VALUES (?,?,?)";
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(3, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objRecord.m_strAPPLICATION_ID_CHR;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strCHECK_ITEM_ID_CHR;
                objLisAddItemRefArr[2].Value = p_objRecord.m_strAPPLY_UNIT_ID_CHR;
                long lngRecEff = -1;
                //往表增加记录
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

        #region 添加一批记录到申请单申请单元项目表
        /// <summary>
        /// 为表 添加一批记录到申请单申请单元项目表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRecordVOArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewAppUintItemArr(System.Security.Principal.IPrincipal p_objPrincipal, clsLisAppUnitItemVO[] p_objRecordVOArr)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngAddNewAppUintItemArr");
            if (lngRes < 0)
            {
                return -1;
            }
            try
            {
                if (p_objRecordVOArr != null)
                {
                    for (int i = 0; i < p_objRecordVOArr.Length; i++)
                    {
                        if (p_objRecordVOArr[i] != null)
                        {
                            lngRes = 0;
                            lngRes = m_lngAddNewAppUnitItem(p_objPrincipal, p_objRecordVOArr[i]);
                            if (lngRes <= 0)
                            {
                                throw new Exception("Add new record err for table t_opr_lis_app_unit_item.");
                            }
                        }
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

        //        #region 根据条件查询病人信息
        //        [AutoComplete]
        //        public long m_lngGetPatientInfoByCondition(System.Security.Principal.IPrincipal p_objPrincipal, string p_strPatientInHospitalNO, out DataTable p_dtbResult)
        //        {
        //            long lngRes = 0;
        //            p_dtbResult = new DataTable();

        //            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngGetPatientInfoByCondition");
        //            if (lngRes < 0)
        //            {
        //                return -1;
        //            }

        //            #region SQL
        //            string strSQL = @"select * from(
        //								SELECT DISTINCT a.patient_inhospitalno_chr, a.patient_name_vchr, a.sex_chr,
        //											a.age_chr, a.patient_subno_chr, a.patient_type_id_chr,
        //											a.diagnose_vchr, a.bedno_chr, a.appl_empid_chr,
        //											c.lastname_vchr AS employeename, a.appl_deptid_chr, b.deptname_vchr,
        //											a.emergency_int, a.special_int,a.application_dat
        //									FROM t_opr_lis_application a,
        //											t_bse_deptdesc b,
        //											t_bse_employee c
        //									WHERE a.appl_deptid_chr = b.deptid_chr(+)
        //										AND a.appl_empid_chr = c.empid_chr(+)";
        //            string strSQL_PatientSubNO = " AND a.patient_inhospitalno_chr = RPAD(?,12,' ') ";
        //            string strOrder = " order by a.application_dat desc)  where rownum = 1";
        //            #endregion

        //            ArrayList arlSQL = new ArrayList();
        //            ArrayList arlParm = new ArrayList();

        //            #region 构造
        //            if (p_strPatientInHospitalNO != null && p_strPatientInHospitalNO.ToString().Trim() != "")
        //            {
        //                arlSQL.Add(strSQL_PatientSubNO);
        //                arlParm.Add(p_strPatientInHospitalNO);
        //            }
        //            #endregion

        //            foreach (object obj in arlSQL)
        //            {
        //                strSQL += obj.ToString();
        //            }
        //            strSQL += strOrder;
        //            int intParmCount = arlSQL.Count;

        //            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

        //            IDataParameter[] objDPArr = null;
        //            objHRPSvc.CreateDatabaseParameter(intParmCount, out objDPArr);

        //            for (int i = 0; i < intParmCount; i++)
        //            {
        //                objDPArr[i].Value = arlParm[i];
        //            }
        //            try
        //            {
        //                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtbResult, objDPArr);
        //                objHRPSvc.Dispose();
        //            }
        //            catch (Exception objEx)
        //            {
        //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //                bool blnRes = objLogger.LogError(objEx);
        //            }
        //            return lngRes;
        //        }
        //        #endregion

        #region 删除申请
        /// <summary>
        /// 删除申请
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strAppID"></param>
        /// <param name="p_strOpID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteApp(System.Security.Principal.IPrincipal p_objPrincipal, string p_strAppID, string p_strOpID)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngDeleteApp");
            if (lngRes < 0)
            {
                return -1;
            }

            lngRes = m_lngDeleteApp(p_strAppID, p_strOpID);

            return lngRes;

            //            long lngRes = 0;
            //            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngDeleteApp");
            //            if (lngRes < 0)
            //            {
            //                return -1;
            //            }

            //            string strSQL = @"select appl_dat, sex_chr, patient_name_vchr, patient_subno_chr, age_chr,
            //                                   patient_type_chr, diagnose_vchr, sampletype_vchr, samplestate_vchr,
            //                                   bedno_chr, icd_vchr, patientcardid_chr, barcode_vchr, sample_id_chr,
            //                                   patientid_chr, sampling_date_dat, operator_id_chr, modify_dat,
            //                                   appl_empid_chr, appl_deptid_chr, status_int, sample_type_id_chr,
            //                                   qcsampleid_chr, samplekind_chr, check_date_dat, accept_dat,
            //                                   acceptor_id_chr, application_id_chr, patient_inhospitalno_chr,
            //                                   confirm_dat, confirmer_id_chr, collector_id_chr, checker_id_chr
            //                              from t_opr_lis_sample
            //                             where application_id_chr = '" + p_strAppID + "' and status_int > 0";



            //            try
            //            {
            //                DataTable dtbResult = new DataTable();
            //                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            //                lngRes = 0;
            //                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
            //                if (lngRes <= 0)
            //                    return lngRes;

            //                if (dtbResult != null && dtbResult.Rows.Count > 0)
            //                {
            //                    for (int i = 0; i < dtbResult.Rows.Count; i++)
            //                    {
            //                        string strSQL2 = @"update t_opr_lis_device_relation set status_int = 0 where sample_id_chr = '" + dtbResult.Rows[i]["sample_id_chr"].ToString().Trim() + "' and status_int = 1";
            //                        lngRes = 0;
            //                        lngRes = objHRPSvc.DoExcute(strSQL2);
            //                        if (lngRes < 0)
            //                            throw new Exception();

            //                        string strSQL3 = @"update t_opr_lis_sample set status_int = 0 where sample_id_chr = '" + dtbResult.Rows[i]["sample_id_chr"].ToString().Trim() + "' and status_int > 0";
            //                        lngRes = 0;
            //                        lngRes = objHRPSvc.DoExcute(strSQL3);
            //                        if (lngRes < 0)
            //                            throw new Exception();
            //                    }
            //                }
            //                string strSQL4 = @"update t_opr_lis_Application set pstatus_int = 0 where APPLICATION_ID_CHR = '" + p_strAppID + "' and PSTATUS_INT > 0";
            //                lngRes = 0;
            //                lngRes = objHRPSvc.DoExcute(strSQL4);
            //                if (lngRes < 0)
            //                    throw new Exception();
            //                objHRPSvc.Dispose();
            //            }
            //            catch (Exception objEx)
            //            {
            //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
            //                bool blnRes = objLogger.LogError(objEx);
            //            }
            //            return lngRes;
        }

        /// <summary>
        /// 删除申请
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strAppID"></param>
        /// <param name="p_strOpID"></param>
        /// <returns></returns>
        [AutoComplete]
        internal long m_lngDeleteApp(string p_strAppID, string p_strOpID)
        {
            long lngRes = 0;

            string strSQL = @"select appl_dat,
       sex_chr,
       patient_name_vchr,
       patient_subno_chr,
       age_chr,
       patient_type_chr,
       diagnose_vchr,
       sampletype_vchr,
       samplestate_vchr,
       bedno_chr,
       icd_vchr,
       patientcardid_chr,
       barcode_vchr,
       sample_id_chr,
       patientid_chr,
       sampling_date_dat,
       operator_id_chr,
       modify_dat,
       appl_empid_chr,
       appl_deptid_chr,
       status_int,
       sample_type_id_chr,
       qcsampleid_chr,
       samplekind_chr,
       check_date_dat,
       accept_dat,
       acceptor_id_chr,
       application_id_chr,
       patient_inhospitalno_chr,
       confirm_dat,
       confirmer_id_chr,
       collector_id_chr,
       checker_id_chr
  from t_opr_lis_sample
 where application_id_chr = ?
   and status_int > 0";



            try
            {
                DataTable dtbResult = null;
                IDataParameter[] objDPArr = null;
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strAppID;

                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);
                if (lngRes <= 0)
                    return lngRes;

                long lngAffect = 0;

                if (dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    string[] strSampleIDArr = new string[dtbResult.Rows.Count];


                    for (int i = 0; i < dtbResult.Rows.Count; i++)
                    {
                        strSampleIDArr[i] = dtbResult.Rows[i]["sample_id_chr"].ToString().Trim();
                    }


                    string strSQL2 = @"update t_opr_lis_device_relation
   set status_int = 0
 where status_int = 1
   and (sample_id_chr = ?";

                    string strSQL3 = @"update t_opr_lis_sample
   set status_int = 0
 where status_int > 0
   and (sample_id_chr = ?
";
                    for (int index = 1; index < strSampleIDArr.Length; index++)
                    {
                        strSQL2 += " or sample_id_chr = ?";
                        strSQL3 += " or sample_id_chr = ?";
                    }
                    strSQL2 += ")";
                    strSQL3 += ")";

                    lngRes = 0;

                    objHRPSvc.CreateDatabaseParameter(strSampleIDArr.Length, out objDPArr);
                    for (int index = 0; index < objDPArr.Length; index++)
                    {
                        objDPArr[0].Value = strSampleIDArr[index];
                    }

                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL2, ref lngAffect, objDPArr);
                    if (lngRes < 0)
                        throw new Exception();


                    lngRes = 0;

                    objHRPSvc.CreateDatabaseParameter(strSampleIDArr.Length, out objDPArr);
                    for (int index = 0; index < objDPArr.Length; index++)
                    {
                        objDPArr[0].Value = strSampleIDArr[index];
                    }
                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL3, ref lngAffect, objDPArr);
                    if (lngRes < 0)
                        throw new Exception();

                }
                string strSQL4 = @"update t_opr_lis_Application set pstatus_int = 0 where application_id_chr = ? and pstatus_int > 0";
                lngRes = 0;
                objHRPSvc.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strAppID;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL4, ref lngAffect, objDPArr);
                if (lngRes < 0)
                    throw new Exception();
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        #endregion

        #region 联合查询申请单信息

        /// <summary>
        /// 联合查询申请单信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objSchVO">承载联合查询条件的VO,其中值为NULL的成员会被必忽略</param>
        /// <param name="p_objAppVOArr">返回的承载申请单信息的数组</param>
        /// <returns>0:失败;1:成功</returns>
        [AutoComplete]
        public long m_lngGetAppInfoByCondition(System.Security.Principal.IPrincipal p_objPrincipal, clsLISApplicationSchVO p_objSchVO, out clsLisApplMainVO[] p_objAppVOArr)
        {
            long lngRes = 0;
            p_objAppVOArr = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngGetAppInfoByCondition");
            if (lngRes < 0)
            {
                return -1;
            }

            #region SQL
            //----------------------------------------
            string strSQL = @"select parmvalue_vchr from t_bse_sysparm 
                               where status_int = 1 and parmcode_chr = ?";
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
            DataTable dtbResult = new DataTable();
            System.Collections.ArrayList arrCat = new System.Collections.ArrayList();
            lngRes = 0;
            IDataParameter[] objDPArr = null;
            objHRPSvc.CreateDatabaseParameter(1, out objDPArr);
            objDPArr[0].Value = "7013";
            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);

                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    string strParm = dtbResult.Rows[0][0].ToString();
                    if (!string.IsNullOrEmpty(strParm))
                    {
                        System.Collections.ArrayList arrRes = new System.Collections.ArrayList();
                        arrRes = m_ArrGettoken(strParm, ";");
                        strSQL = @"select check_category_id_chr from t_bse_lis_check_category";
                        lngRes = 0;
                        dtbResult = null;
                        lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                        if (lngRes > 0 && dtbResult.Rows.Count > 0)
                        {
                            DataRow dr = null;
                            for (int i = 0; i < arrRes.Count; i++)
                            {
                                for (int j = 0; j < dtbResult.Rows.Count; j++)
                                {
                                    dr = dtbResult.Rows[j];
                                    if (arrRes[i].ToString().Trim() == dr["check_category_id_chr"].ToString().Trim())
                                    { arrCat.Add(arrRes[i].ToString().Trim()); break; }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception objEx)
            {
                throw (objEx);
            }
            //----------------------------------------

            strSQL = @"select   application_id_chr, patientid_chr, application_dat, sex_chr,
         patient_name_vchr, patient_subno_chr, age_chr, patient_type_id_chr,
         diagnose_vchr, bedno_chr, icdcode_chr, patientcardid_chr,
         application_form_no_chr, modify_dat, operator_id_chr, appl_empid_chr,
         appl_deptid_chr, summary_vchr, pstatus_int, emergency_int,
         special_int, form_int, patient_inhospitalno_chr, sample_type_id_chr,
         check_content_vchr, sample_type_vchr, oringin_dat, charge_info_vchr,
         printed_num, orderunitrelation_vchr, printed_date,
         report_group_id_chr_report, modify_dat_report,
         operator_id_chr_report, status_int_report, report_dat_report,
         reportor_id_chr_report, confirm_dat_report, confirmer_id_chr_report,
         sampling_date_dat, accept_dat
    from (select distinct t2.application_id_chr, t2.patientid_chr,
                          t2.application_dat, t2.sex_chr,
                          t2.patient_name_vchr, t2.patient_subno_chr,
                          t2.age_chr, t2.patient_type_id_chr,
                          t2.diagnose_vchr, t2.bedno_chr, t2.icdcode_chr,
                          t2.patientcardid_chr, t2.application_form_no_chr,
                          t2.modify_dat, t2.operator_id_chr,
                          t2.appl_empid_chr, t2.appl_deptid_chr,
                          t2.summary_vchr, t2.pstatus_int, t2.emergency_int,
                          t2.special_int, t2.form_int,
                          t2.patient_inhospitalno_chr, t2.sample_type_id_chr,
                          t2.check_content_vchr, t2.sample_type_vchr,
                          t2.oringin_dat, t2.charge_info_vchr, t2.printed_num,
                          t2.orderunitrelation_vchr, t2.printed_date,
                          t1.report_group_id_chr report_group_id_chr_report,
                          t1.modify_dat modify_dat_report,
                          t1.operator_id_chr operator_id_chr_report,
                          t1.status_int status_int_report,
                          t1.report_dat report_dat_report,
                          t1.reportor_id_chr reportor_id_chr_report,
                          t1.confirm_dat confirm_dat_report,
                          t1.confirmer_id_chr confirmer_id_chr_report,
                          t4.sample_id_chr, t4.sampling_date_dat, t4.modify_dat as modify_dat_sample, t4.accept_dat
                     from t_opr_lis_app_report t1,
                          t_opr_lis_application t2,
                          t_opr_lis_sample t4
                    where t1.application_id_chr = t2.application_id_chr
                      and t2.pstatus_int + 0 = 2
                      and t2.application_id_chr = t4.application_id_chr
                      and t4.status_int >= 3
                      and t4.status_int <= 6 ";
            //            string strSQL = @"SELECT   
            //											t2.application_form_no_chr, t2.patient_name_vchr,
            //                                          t2.check_content_vchr, t2.patientcardid_chr,
            //                                          1 status_int_report, t4.accept_dat
            //								FROM 
            //									t_opr_lis_application t2,
            //									t_opr_lis_sample t4       
            //								WHERE t2.pstatus_int  = 2
            //								AND t2.application_id_chr = t4.application_id_chr
            //								AND t4.status_int >= 3 AND t4.status_int <= 6 ";

            string strSQL_ConfirmState = " and t1.status_int = ? ";
            string strSQL_ConfirmStateAll = " and t1.status_int > ?";
            string strSQL_FromDate = " and t4.accept_dat >=to_date(?,'yyyy-mm-dd hh24:mi:ss') ";
            string strSQL_ToDate = " and t4.accept_dat <= to_date(?,'yyyy-mm-dd hh24:mi:ss') ";
            string strSQL_PatientName = " and trim(t2.patient_name_vchr) like ? ";
            string strSQL_BarCode = " and t4.barcode_vchr = ? ";
            string strSQL_SampleGroupID = @" and t2.application_id_chr in (
													select distinct tt1.application_id_chr
																from t_opr_lis_app_sample tt1
																where tt1.sample_group_id_chr in
																					(*))";
            string strSQL_UnitID = @" and t2.application_id_chr in (
													select distinct tt2.application_id_chr
																from t_opr_lis_app_apply_unit tt2
																where tt2.apply_unit_id_chr in
																					(*))";

            string strSQL_FromDateApp = " and t4.appl_dat >=to_date(?,'yyyy-mm-dd hh24:mi:ss')";
            string strSQL_ToDateApp = " and t4.appl_dat <=to_date(?,'yyyy-mm-dd hh24:mi:ss')";
            string strSQL_InhospNO = " and trim(t2.patient_inhospitalno_chr) = ? ";
            string strSQL_BedNO = " and trim(t2.bedno_chr) = ? ";
            string strSQL_AppDept = " and trim(t2.appl_deptid_chr) = ? ";
            string strSQL_AppDoct = " and trim(t2.appl_empid_chr) = ? ";
            string strSQL_AppID = " and t2.application_id_chr = ?";
            string strSQL_PatientID = " and t2.patientid_chr = ?";
            string strSQL_PatinetCardNO = "and t2.patientcardid_chr = ?";
            string strSQL_PatientCheckNO = " and t2.application_form_no_chr like ? ";
            #endregion

            ArrayList arlSQL = new ArrayList();
            ArrayList arlParm = new ArrayList();

            #region 构造

            if (p_objSchVO.m_strPatientCheckNO != null && p_objSchVO.m_strPatientCheckNO.ToString().Replace('%', ' ').Trim() != "")
            {
                arlSQL.Add(strSQL_PatientCheckNO);
                arlParm.Add(p_objSchVO.m_strPatientCheckNO);
            }
            if (p_objSchVO.m_strApplicationID != null)
            {
                arlSQL.Add(strSQL_AppID);
                arlParm.Add(p_objSchVO.m_strApplicationID);
            }
            if (p_objSchVO.m_strPatientID != null)
            {
                arlSQL.Add(strSQL_PatientID);
                arlParm.Add(p_objSchVO.m_strPatientID);
            }
            if (p_objSchVO.m_strPatientCardNO != null && p_objSchVO.m_strPatientCardNO.Trim() != "")
            {
                arlSQL.Add(strSQL_PatinetCardNO);
                arlParm.Add(p_objSchVO.m_strPatientCardNO);
            }
            if (p_objSchVO.m_strConfirmState == "1")
            {
                arlSQL.Add(strSQL_ConfirmState);
                arlParm.Add(1);
            }
            else if (p_objSchVO.m_strConfirmState == "2")
            {
                arlSQL.Add(strSQL_ConfirmState);
                arlParm.Add(2);
            }
            else if (p_objSchVO.m_strConfirmState == "0")
            {
                arlSQL.Add(strSQL_ConfirmState);
                arlParm.Add(0);
            }
            else
            {
                arlSQL.Add(strSQL_ConfirmStateAll);
                arlParm.Add(0);
            }
            if (p_objSchVO.m_strConfirmedDateBegin != null && Microsoft.VisualBasic.Information.IsDate(p_objSchVO.m_strConfirmedDateBegin.Trim()))
            {
                arlSQL.Add(strSQL_FromDate);
                arlParm.Add(p_objSchVO.m_strConfirmedDateBegin.Trim());
            }
            if (p_objSchVO.m_strConfirmedDateEnd != null && Microsoft.VisualBasic.Information.IsDate(p_objSchVO.m_strConfirmedDateEnd.Trim()))
            {
                arlSQL.Add(strSQL_ToDate);
                arlParm.Add(p_objSchVO.m_strConfirmedDateEnd.Trim());
            }
            if (p_objSchVO.m_strSampleGroupIDArr != null && p_objSchVO.m_strSampleGroupIDArr.Length > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < p_objSchVO.m_strSampleGroupIDArr.Length; i++)
                {
                    sb.Append("?,");
                }
                sb.Remove(sb.Length - 1, 1);
                string strReplace = sb.ToString();
                strSQL_SampleGroupID = strSQL_SampleGroupID.Replace("*", strReplace);
                arlSQL.Add(strSQL_SampleGroupID);
                arlParm.AddRange(p_objSchVO.m_strSampleGroupIDArr);
            }
            if (p_objSchVO.m_strApplyUnitIDArr != null && p_objSchVO.m_strApplyUnitIDArr.Length > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < p_objSchVO.m_strApplyUnitIDArr.Length; i++)
                {
                    sb.Append("?,");
                }
                sb.Remove(sb.Length - 1, 1);
                string strReplace = sb.ToString();
                strSQL_UnitID = strSQL_UnitID.Replace("*", strReplace);
                arlSQL.Add(strSQL_UnitID);
                arlParm.AddRange(p_objSchVO.m_strApplyUnitIDArr);
            }
            if (p_objSchVO.m_strPatientName != null && p_objSchVO.m_strPatientName.ToString().Trim() != "")
            {
                arlSQL.Add(strSQL_PatientName);
                arlParm.Add("%" + p_objSchVO.m_strPatientName.Trim() + "%");
            }
            if (p_objSchVO.m_strBarCode != null && p_objSchVO.m_strBarCode.ToString().Trim() != "")
            {
                arlSQL.Add(strSQL_BarCode);
                arlParm.Add(p_objSchVO.m_strBarCode.Trim());
            }


            if (p_objSchVO.m_strFromDatApp != null && Microsoft.VisualBasic.Information.IsDate(p_objSchVO.m_strFromDatApp.Trim()))
            {
                arlSQL.Add(strSQL_FromDateApp);
                arlParm.Add(p_objSchVO.m_strFromDatApp.Trim());
            }
            if (p_objSchVO.m_strToDatApp != null && Microsoft.VisualBasic.Information.IsDate(p_objSchVO.m_strToDatApp.Trim()))
            {
                arlSQL.Add(strSQL_ToDateApp);
                arlParm.Add(p_objSchVO.m_strToDatApp.Trim());
            }
            if (p_objSchVO.m_strInhospNO != null && p_objSchVO.m_strInhospNO.ToString().Trim() != "")
            {
                arlSQL.Add(strSQL_InhospNO);
                arlParm.Add(p_objSchVO.m_strInhospNO.Trim());
            }
            if (p_objSchVO.m_strBedNO != null && p_objSchVO.m_strBedNO.ToString().Trim() != "")
            {
                arlSQL.Add(strSQL_BedNO);
                arlParm.Add(p_objSchVO.m_strBedNO.Trim());
            }
            if (p_objSchVO.m_strAppDept != null && p_objSchVO.m_strAppDept.ToString().Trim() != "")
            {
                arlSQL.Add(strSQL_AppDept);
                arlParm.Add(p_objSchVO.m_strAppDept.Trim());
            }
            if (p_objSchVO.m_strAppDoct != null && p_objSchVO.m_strAppDoct.ToString().Trim() != "")
            {
                arlSQL.Add(strSQL_AppDoct);
                arlParm.Add(p_objSchVO.m_strAppDoct.Trim());
            }
            #endregion

            foreach (object obj in arlSQL)
            {
                strSQL += obj.ToString();
            }
            string strConfirmDate = DateTime.Now.ToString();
            if (arrCat.Count > 0) //伦教7013参数，跳过核收状态查询
            {
                string sql_sub1 = "";
                string sql_sub2 = "";
                strSQL += @"
          union
          ";
                sql_sub1 = @"select distinct t2.application_id_chr, t2.patientid_chr,
                          t2.application_dat, t2.sex_chr,
                          t2.patient_name_vchr, t2.patient_subno_chr,
                          t2.age_chr, t2.patient_type_id_chr,
                          t2.diagnose_vchr, t2.bedno_chr, t2.icdcode_chr,
                          t2.patientcardid_chr, t2.application_form_no_chr,
                          t2.modify_dat, t2.operator_id_chr,
                          t2.appl_empid_chr, t2.appl_deptid_chr,
                          t2.summary_vchr, t2.pstatus_int, t2.emergency_int,
                          t2.special_int, t2.form_int,
                          t2.patient_inhospitalno_chr, t2.sample_type_id_chr,
                          t2.check_content_vchr, t2.sample_type_vchr,
                          t2.oringin_dat, t2.charge_info_vchr, t2.printed_num,
                          t2.orderunitrelation_vchr, t2.printed_date,
                          t1.report_group_id_chr report_group_id_chr_report,
                          t1.modify_dat modify_dat_report,
                          t1.operator_id_chr operator_id_chr_report,
                          t1.status_int status_int_report,
                          t1.report_dat report_dat_report,
                          t1.reportor_id_chr reportor_id_chr_report,
                          t1.confirm_dat confirm_dat_report,
                          t1.confirmer_id_chr confirmer_id_chr_report,
                          t4.sample_id_chr, t4.modify_dat as modify_dat_sample, t4.accept_dat
                     from t_opr_lis_app_report t1,
                          t_opr_lis_application t2,
                          t_opr_lis_app_sample t3,
                          t_opr_lis_sample t4,
                          t_aid_lis_sample_group e,
                          t_bse_lis_check_category f
                    where t1.application_id_chr = t2.application_id_chr
                      and t1.application_id_chr = t3.application_id_chr
                      and t2.pstatus_int + 0 = 2
                      and t2.application_id_chr = t4.application_id_chr
                      and t3.sample_group_id_chr = e.sample_group_id_chr
                      and e.check_category_id_chr = f.check_category_id_chr
                      and t4.status_int = 2 ";
                foreach (object obj in arlSQL)
                { sql_sub2 += obj.ToString(); }
                sql_sub1 += sql_sub2.Replace("t4.accept_dat", "t4.sampling_date_dat");
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@" and f.check_category_id_chr in (");
                foreach (string s in arrCat)
                {
                    sb.Append("? ,");
                }
                sql_sub1 += sb.Remove(sb.Length - 2, 2).ToString() + ")";
                strSQL += sql_sub1;

                int intParmCount = arlParm.Count + arrCat.Count;
                #region 自动核收7013设定样本组标本

                objDPArr = null;
                objHRPSvc.CreateDatabaseParameter(intParmCount, out objDPArr);
                int i2 = 0;
                for (int i = 0; i < intParmCount; i++) //传参数
                {
                    if (i < arlParm.Count)
                    { objDPArr[i].Value = arlParm[i]; }
                    else
                    { objDPArr[i].Value = arrCat[i2]; i2++; }
                }
                dtbResult = null;
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(sql_sub1, ref dtbResult, objDPArr);
                DataRow dr = null;
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {//批量核收标本
                    try
                    {
                        sql_sub1 = @"update t_opr_lis_sample
                                        set status_int = 3,
                                            accept_dat = ?,
                                            acceptor_id_chr = ?
                                      where sample_id_chr = ? and modify_dat = ?";
                        lngRes = 0;
                        System.Collections.ArrayList arrValues = new System.Collections.ArrayList();
                        com.digitalwave.iCare.ValueObject.clsAcceptSampleBatch_VO[] objSamCondiction = new clsAcceptSampleBatch_VO[dtbResult.Rows.Count];
                        for (int j1 = 0; j1 < dtbResult.Rows.Count; j1++)
                        {
                            dr = dtbResult.Rows[j1];
                            objSamCondiction[j1] = new clsAcceptSampleBatch_VO();
                            objSamCondiction[j1].strReceiveEmp = p_objSchVO.m_strLoginEmpNo;
                            objSamCondiction[j1].strSampleID = dr["sample_id_chr"].ToString();
                            DateTime.TryParse(dr["modify_dat_sample"].ToString(), out objSamCondiction[j1].datModifyDat);
                        }
                        DbType[] dbTypes = new DbType[] { DbType.DateTime, DbType.String, DbType.String, DbType.DateTime };
                        object[][] objValues = new object[4][];
                        for (int i = 0; i < objValues.Length; i++)
                        { objValues[i] = new object[objSamCondiction.Length]; }
                        for (int i5 = 0; i5 < objSamCondiction.Length; i5++)
                        {
                            int n = 0;
                            objValues[n++][i5] = Convert.ToDateTime(strConfirmDate);
                            objValues[n++][i5] = objSamCondiction[i5].strReceiveEmp;
                            objValues[n++][i5] = objSamCondiction[i5].strSampleID;
                            objValues[n++][i5] = objSamCondiction[i5].datModifyDat;
                        }
                        lngRes = objHRPSvc.m_lngSaveArrayWithParameters(sql_sub1, objValues, dbTypes);
                    }
                    catch (Exception objEx)
                    {

                        throw (objEx);
                    }
                }

                #endregion

                intParmCount = arlParm.Count * 2 + arrCat.Count;

                objDPArr = null;
                objHRPSvc.CreateDatabaseParameter(intParmCount, out objDPArr);

                int j = 0;
                for (int i = 0; i < intParmCount; i++)
                {
                    if (i < (intParmCount - arrCat.Count) / 2)
                    {
                        objDPArr[i].Value = objDPArr[i + arlParm.Count].Value = arlParm[i];
                    }
                    if (i > arlParm.Count * 2 - 1)
                    {
                        objDPArr[i].Value = arrCat[j];
                        j++;
                    }
                }
            }
            else
            {
                //strSQL += ") order by to_char(accept_dat,'yyyy-mm-dd') asc, lpad(application_form_no_chr,12,'0') asc";
                int intParmCount = arlParm.Count;

                objDPArr = null;
                objHRPSvc.CreateDatabaseParameter(intParmCount, out objDPArr);

                for (int i = 0; i < intParmCount; i++)
                {
                    objDPArr[i].Value = arlParm[i];
                }
            }
            strSQL += ") order by to_char(accept_dat,'yyyy-mm-dd') asc, lpad(application_form_no_chr,12,'0') asc";

            try
            {
                dtbResult = null;
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    System.Collections.ArrayList arlApp = new ArrayList();
                    //					System.Data.DataRow[] dtrResultArr = dtbResult.Select("","application_id_chr");
                    for (int i = 0; i < dtbResult.Rows.Count; i++)
                    {
                        clsLisApplMainVO objMainVO = new clsVOConstructor().m_objConstructAppMainVO(dtbResult.Rows[i]);
                        //clsLisApplMainVO objMainVO = new clsLisApplMainVO();
                        objMainVO.m_strReportGroupID = dtbResult.Rows[i]["REPORT_GROUP_ID_CHR_Report"].ToString().Trim();
                        objMainVO.m_strReportDate = dtbResult.Rows[i]["CONFIRM_DAT_Report"].ToString().Trim();
                        objMainVO.m_intReportStatus = int.Parse(dtbResult.Rows[i]["status_int_Report"].ToString().Trim());
                        objMainVO.m_strOriginDate = dtbResult.Rows[i]["oringin_dat"].ToString().Trim();
                        objMainVO.m_strSamplingDate = dtbResult.Rows[i]["sampling_date_dat"].ToString().Trim();
                        //objMainVO.m_strCheckContent = dtbResult.Rows[i]["check_content_vchr"].ToString();
                        //objMainVO.m_strPatient_Name = dtbResult.Rows[i]["patient_name_vchr"].ToString();
                        //objMainVO.m_strApplication_Form_NO = dtbResult.Rows[i]["application_form_no_chr"].ToString();
                        //objMainVO.m_strPatientcardID = dtbResult.Rows[i]["patientcardid_chr"].ToString();
                        if (dtbResult.Rows[i]["accept_dat"] != DBNull.Value)
                        {
                            objMainVO.m_strAcceptDate = ((DateTime)dtbResult.Rows[i]["accept_dat"]).ToString("yyyy-MM-dd HH:mm:ss");
                        }
                        objMainVO.m_strPrintDate = dtbResult.Rows[i]["printed_date"].ToString().Trim();
                        if (dtbResult.Rows[i]["printed_num"] != System.DBNull.Value)
                        {
                            if (dtbResult.Rows[i]["printed_num"].ToString().Trim() == "0")
                            {
                                objMainVO.m_isPrinted = false;
                            }
                            else if (dtbResult.Rows[i]["printed_num"].ToString().Trim() == "1")
                            {
                                objMainVO.m_isPrinted = true;
                            }
                        }
                        arlApp.Add(objMainVO);
                    }
                    p_objAppVOArr = (clsLisApplMainVO[])arlApp.ToArray(typeof(clsLisApplMainVO));
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                p_objAppVOArr = null;
            }
            return lngRes;
        }

        /// <summary>
        /// 获取分隔字符串数值
        /// </summary>
        /// <param name="str"></param>
        /// <param name="sign"></param>
        /// <returns></returns>
        public static ArrayList m_ArrGettoken(string str, string sign)
        {
            ArrayList val = new ArrayList();

            if (str.Trim() == "")
            {
                return val;
            }

            int pos = 0;

            do
            {
                pos = str.IndexOf(sign);
                if (pos > 0)
                {
                    val.Add(str.Substring(0, pos));
                    str = str.Substring(pos + 1);
                }
                else
                {
                    val.Add(str);
                }
            } while (pos > 0);

            return val;
        }
        #endregion

        //        #region 组合查询查询已发送申请单及样本信息 
        //        /// <summary>
        //        /// 组合查询查询已发送申请单及样本信息
        //        /// </summary>
        //        /// <param name="p_objPrincipal"></param>
        //        /// <param name="p_intSampleStatus">1为未采集,2为已采集,0为所有</param>
        //        /// <param name="p_strAppDept"></param>
        //        /// <param name="p_strFromDatApp"></param>
        //        /// <param name="p_strToDatApp"></param>
        //        /// <param name="p_objAppVOArr"></param>
        //        /// <returns></returns>
        //        [AutoComplete]
        //        public long m_lngGetAppAndSampleInfo(IPrincipal p_objPrincipal, int p_intSampleStatus, string p_strAppDept,
        //                                             string p_strFromDatApp, string p_strToDatApp, string p_strPatientName,
        //                                             string p_strPatiendCardID, out clsLisApplMainVO[] p_objAppVOArr)
        //        {
        //            long lngRes = 0;
        //            p_objAppVOArr = null;
        //            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngGetAppAndSampleInfo");
        //            if (lngRes < 0)
        //            {
        //                return -1;
        //            }

        //            #region SQL

        //            string strSQL = @" select a.*,
        //                                   b.status_int as paystatus
        //                              from v_lis_app_report_sample_info a,
        //                                   t_opr_attachrelation b
        //                             where a.application_id_chr = b.attachid_vchr(+)
        //                               and a.patient_type_id_chr=2
        //                               and a.pstatus_int = 2
        //                               and a.form_int    = 1  ";

        //            lngRes = 0;
        //            bool blnResult;
        //            //【系统开关 -> 是否显示没交费病人信息:4001 0:不显示】
        //            lngRes = this.m_lngGetCollocate(p_objPrincipal, out blnResult, "4001");
        //            if (!blnResult)
        //            {
        //                strSQL += " and b.status_int = 1 ";
        //            }

        //            string strSQL_FromDateApp = " and application_dat >= ? ";
        //            string strSQL_ToDateApp = " and application_dat <= ? ";
        //            string strSQL_AppDept = " and trim(appl_deptid_chr) = ? ";

        //            string strSQL_SampleSatus_NoSample = " and sample_status_int = 1 ";
        //            string strSQL_SampleSatus_Sampled = " and sample_status_int > 1 ";
        //            string strSQL_SampleSatus_All = " and sample_status_int > 0 ";

        //            string strSQL_PatientName = " and patient_name_vchr like ? ";
        //            string strSQL_PatientCardID = " and patientcardid_chr = ? ";

        //            #endregion

        //            ArrayList arlSQL = new ArrayList();
        //            ArrayList arlParm = new ArrayList();

        //            #region 构造

        //            if (p_intSampleStatus == 1)
        //            {
        //                arlSQL.Add(strSQL_SampleSatus_NoSample);
        //            }
        //            else if (p_intSampleStatus == 2)
        //            {
        //                arlSQL.Add(strSQL_SampleSatus_Sampled);
        //            }
        //            else if (p_intSampleStatus == 0)
        //            {
        //                arlSQL.Add(strSQL_SampleSatus_All);
        //            }

        //            if (p_strFromDatApp != null && Microsoft.VisualBasic.Information.IsDate(p_strFromDatApp.Trim()))
        //            {
        //                arlSQL.Add(strSQL_FromDateApp);
        //                arlParm.Add(DateTime.Parse(p_strFromDatApp.Trim()));
        //            }
        //            if (p_strToDatApp != null && Microsoft.VisualBasic.Information.IsDate(p_strToDatApp.Trim()))
        //            {
        //                arlSQL.Add(strSQL_ToDateApp);
        //                arlParm.Add(DateTime.Parse(p_strToDatApp.Trim()));
        //            }

        //            if (p_strAppDept != null && p_strAppDept.ToString().Trim() != "")
        //            {
        //                arlSQL.Add(strSQL_AppDept);
        //                arlParm.Add(p_strAppDept.Trim());
        //            }

        //            if (p_strPatientName != null && p_strPatientName.ToString().Replace('%', ' ').Trim() != "")
        //            {
        //                arlSQL.Add(strSQL_PatientName);
        //                arlParm.Add(p_strPatientName.Trim());
        //            }

        //            if (p_strPatiendCardID != null && p_strPatiendCardID.ToString().Trim() != "")
        //            {
        //                arlSQL.Add(strSQL_PatientCardID);
        //                arlParm.Add(p_strPatiendCardID.Trim());
        //            }

        //            #endregion

        //            foreach (object obj in arlSQL)
        //            {
        //                strSQL += obj.ToString();
        //            }

        //            int intParmCount = 0;

        //            intParmCount = arlParm.Count;

        //            clsHRPTableService objHRPSvc = new clsHRPTableService();

        //            IDataParameter[] objDPArr = null;
        //            objHRPSvc.CreateDatabaseParameter(intParmCount, out objDPArr);

        //            for (int i = 0; i < intParmCount; i++)
        //            {
        //                objDPArr[i].Value = arlParm[i];
        //            }

        //            try
        //            {
        //                DataTable dtbResult = null;
        //                lngRes = 0;
        //                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);

        //                objHRPSvc.Dispose();
        //                if (lngRes > 0 && dtbResult != null && dtbResult.Rows.Count > 0)
        //                {
        //                    System.Collections.ArrayList arlApp = new ArrayList();
        //                    for (int i = 0; i < dtbResult.Rows.Count; i++)
        //                    {
        //                        clsLisApplMainVO objMainVO = new clsVOConstructor().m_objConstructAppMainVO(dtbResult.Rows[i]);
        //                        objMainVO.m_strSampleID = dtbResult.Rows[i]["sample_id_chr"].ToString().Trim();
        //                        objMainVO.m_intSampleStatus = int.Parse(dtbResult.Rows[i]["sample_status_int"].ToString().Trim());
        //                        if (dtbResult.Columns.Contains("paystatus"))
        //                        {
        //                            objMainVO.m_intChargeState = DBAssist.ToInt32(dtbResult.Rows[i]["paystatus"]);
        //                        }

        //                        arlApp.Add(objMainVO);
        //                    }
        //                    p_objAppVOArr = (clsLisApplMainVO[])arlApp.ToArray(typeof(clsLisApplMainVO));
        //                }
        //                else
        //                {
        //                    p_objAppVOArr = new clsLisApplMainVO[0];
        //                }
        //            }
        //            catch (Exception objEx)
        //            {
        //                new clsLogText().LogError(objEx);
        //                p_objAppVOArr = new clsLisApplMainVO[0];
        //            }

        //            return lngRes;
        //        }
        //        #endregion

        //        #region［住院采集样本］组合查询查询已发送申请单及样本信息 
        //        /// <summary>
        //        /// [住院采集样本］组合查询查询已发送申请单及样本信息
        //        /// </summary>
        //        /// <remarks>住院部分不关联收费信息</remarks>
        //        /// <param name="p_objPrincipal"></param>
        //        /// <param name="p_intSampleStatus"></param>
        //        /// <param name="p_strAppDept"></param>
        //        /// <param name="p_strFromDatApp"></param>
        //        /// <param name="p_strToDatApp"></param>
        //        /// <param name="p_strPatientName"></param>
        //        /// <param name="p_strPatiendCardID"></param>
        //        /// <param name="p_strHosipitalNO"></param>
        //        /// <param name="bedNo"></param>
        //        /// <param name="p_objAppVOArr"></param>
        //        /// <returns></returns>
        //        [AutoComplete]
        //        public long m_lngGetAppAndSampleInfo(IPrincipal principal, int sampleStatus, string areaId,
        //                                             string beginDate, string endDate, string patientName,
        //                                             string patientCardId, string hosipitalNo, string bedNo, out clsLisApplMainVO[] p_objAppVOArr)
        //        {

        //            long lngRes = 0;
        //            p_objAppVOArr = null;
        //            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //            lngRes = objPrivilege.m_lngCheckCallPrivilege(principal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngGetAppAndSampleInfo");
        //            if (lngRes < 0)
        //            {
        //                return -1;
        //            }

        //            #region SQL

        //            lngRes = 0;

        //            string strSQL = @"select *
        //						        from v_lis_app_report_sample_info 
        //						       where patient_type_id_chr = 1 
        //                                 and pstatus_int = 2 
        //                                 and form_int = 1 ";

        //            string strSQL_FromDateApp = " and application_dat >= ? ";
        //            string strSQL_ToDateApp = " and application_dat <= ? ";
        //            string strSQL_AppDept = " and trim(appl_deptid_chr) = ? ";
        //            string strSQL_SampleSatus_NoSample = " and sample_status_int = 1 ";
        //            string strSQL_SampleSatus_Sampled = " and sample_status_int > 1 ";
        //            string strSQL_SampleSatus_All = " and sample_status_int > 0 ";
        //            string strSQL_PatientName = " and patient_name_vchr like ? ";
        //            string strSQL_PatientCardID = " and patientcardid_chr = ? ";
        //            string strSQL_PatientHosipitalNO = " and trim(patient_inhospitalno_chr) = ?";
        //            string strSQL_PatientBedNo = " and trim(bedno_chr) = ? ";

        //            #endregion

        //            ArrayList arlSQL = new ArrayList();
        //            ArrayList arlParm = new ArrayList();

        //            #region 构造

        //            if (sampleStatus == 1)
        //            {
        //                arlSQL.Add(strSQL_SampleSatus_NoSample);
        //            }
        //            else if (sampleStatus == 2)
        //            {
        //                arlSQL.Add(strSQL_SampleSatus_Sampled);
        //            }
        //            else if (sampleStatus == 0)
        //            {
        //                arlSQL.Add(strSQL_SampleSatus_All);
        //            }

        //            if (beginDate != null && Microsoft.VisualBasic.Information.IsDate(beginDate.Trim()))
        //            {
        //                arlSQL.Add(strSQL_FromDateApp);
        //                arlParm.Add(DateTime.Parse(beginDate.Trim()));
        //            }
        //            if (endDate != null && Microsoft.VisualBasic.Information.IsDate(endDate.Trim()))
        //            {
        //                arlSQL.Add(strSQL_ToDateApp);
        //                arlParm.Add(DateTime.Parse(endDate.Trim()));
        //            }

        //            if (areaId != null && areaId.ToString().Trim() != "")
        //            {
        //                arlSQL.Add(strSQL_AppDept);
        //                arlParm.Add(areaId.Trim());
        //            }

        //            if (patientName != null && patientName.ToString().Replace('%', ' ').Trim() != "")
        //            {
        //                arlSQL.Add(strSQL_PatientName);
        //                arlParm.Add(patientName.Trim());
        //            }

        //            if (patientCardId != null && patientCardId.ToString().Trim() != "")
        //            {
        //                arlSQL.Add(strSQL_PatientCardID);
        //                arlParm.Add(patientCardId.Trim());
        //            }

        //            if (areaId != null && areaId.ToString().Trim() != "" && hosipitalNo.Trim() != string.Empty)
        //            {
        //                arlSQL.Add(strSQL_PatientHosipitalNO);
        //                arlParm.Add(hosipitalNo.Trim());
        //            }
        //            if (areaId != null && areaId.ToString().Trim() != "" && bedNo.Trim() != string.Empty)
        //            {
        //                arlSQL.Add(strSQL_PatientBedNo);
        //                arlParm.Add(bedNo.Trim());
        //            }

        //            #endregion

        //            foreach (object obj in arlSQL)
        //            {
        //                strSQL += obj.ToString();
        //            }

        //            int intParmCount = 0;
        //            intParmCount = arlParm.Count;

        //            clsHRPTableService objHRPSvc = new clsHRPTableService();

        //            IDataParameter[] objDPArr = null;
        //            objHRPSvc.CreateDatabaseParameter(intParmCount, out objDPArr);

        //            for (int i = 0; i < intParmCount; i++)
        //            {
        //                objDPArr[i].Value = arlParm[i];
        //            }
        //            try
        //            {
        //                DataTable dtbResult = null;
        //                lngRes = 0;
        //                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);
        //                objHRPSvc.Dispose();
        //                if (lngRes > 0 && dtbResult != null && dtbResult.Rows.Count > 0)
        //                {
        //                    System.Collections.ArrayList arlApp = new ArrayList();
        //                    for (int i = 0; i < dtbResult.Rows.Count; i++)
        //                    {
        //                        clsLisApplMainVO objMainVO = new clsVOConstructor().m_objConstructAppMainVO(dtbResult.Rows[i]);
        //                        objMainVO.m_strSampleID = dtbResult.Rows[i]["SAMPLE_ID_CHR"].ToString().Trim();
        //                        objMainVO.m_intSampleStatus = int.Parse(dtbResult.Rows[i]["SAMPLE_STATUS_INT"].ToString().Trim());
        //                        arlApp.Add(objMainVO);
        //                    }
        //                    p_objAppVOArr = (clsLisApplMainVO[])arlApp.ToArray(typeof(clsLisApplMainVO));
        //                }
        //                else
        //                {
        //                    p_objAppVOArr = new clsLisApplMainVO[0];
        //                }
        //            }
        //            catch (Exception objEx)
        //            {
        //                new clsLogText().LogError(objEx);
        //                p_objAppVOArr = new clsLisApplMainVO[0];
        //            }

        //            return lngRes;
        //        }

        //        #endregion


        //#region 根据申请日期、发送状态组合查询申请单信息 
        ///// <summary>
        ///// 根据申请日期、发送状态组合查询申请单信息
        ///// </summary>
        ///// <param name="p_objPrincipal"></param>
        ///// <param name="p_strFromDat"></param>
        ///// <param name="p_strToDat"></param>
        ///// <param name="p_blnSend"></param>
        ///// <param name="p_blnUnSend"></param>
        ///// <param name="p_objResultArr"></param>
        ///// <returns></returns>
        //[AutoComplete]
        //public long m_lngGetApplicationVOArrByCondition(System.Security.Principal.IPrincipal p_objPrincipal,
        //    string p_strFromDat, string p_strToDat, bool p_blnSend, bool p_blnUnSend, out clsLisApplMainVO[] p_objResultArr)
        //{
        //    long lngRes = 0;
        //    p_objResultArr = null;
        //    clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //    lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngGetApplicationVOArrByCondition");
        //    if (lngRes < 0)
        //    {
        //        return -1;
        //    }

        //    string strSQL = @"SELECT * FROM t_opr_lis_application ";

        //    #region Condition
        //    if (p_blnSend && !p_blnUnSend)
        //    {
        //        strSQL += " WHERE pstatus_int = 2 ";
        //    }
        //    else if (!p_blnSend && p_blnUnSend)
        //    {
        //        strSQL += " WHERE pstatus_int = 1 ";
        //    }
        //    else if (p_blnSend && p_blnUnSend)
        //    {
        //        strSQL += " WHERE pstatus_int >0 ";
        //    }
        //    else
        //    {
        //        strSQL += " WHERE pstatus_int = 0 ";
        //    }

        //    if (p_strFromDat != null && p_strToDat == null)
        //    {
        //        strSQL += " AND application_dat >= TO_DATE('" + p_strFromDat + "','yyyy-mm-dd hh24:mi:ss') ";
        //    }
        //    else if (p_strFromDat == null && p_strToDat != null)
        //    {
        //        strSQL += " AND application_dat <= TO_DATE('" + p_strToDat + "','yyyy-mm-dd hh24:mi:ss') ";
        //    }
        //    else if (p_strFromDat != null && p_strToDat != null)
        //    {
        //        strSQL += " AND application_dat BETWEEN TO_DATE('" + p_strFromDat + "','yyyy-mm-dd hh24:mi:ss') AND TO_DATE('" + p_strToDat + "','yyyy-mm-dd hh24:mi:ss')";
        //    }
        //    #endregion

        //    try
        //    {
        //        DataTable dtbResult = new DataTable();
        //        com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

        //        lngRes = 0;
        //        lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
        //        objHRPSvc.Dispose();

        //        if (lngRes > 0 && dtbResult != null && dtbResult.Rows.Count > 0)
        //        {
        //            p_objResultArr = new clsLisApplMainVO[dtbResult.Rows.Count];
        //            for (int i1 = 0; i1 < p_objResultArr.Length; i1++)
        //            {
        //                p_objResultArr[i1] = new clsVOConstructor().m_objConstructAppMainVO(dtbResult.Rows[i1]);
        //            }
        //        }
        //    }
        //    catch (Exception objEx)
        //    {
        //        com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //        bool blnRes = objLogger.LogError(objEx);
        //    }
        //    return lngRes;
        //}
        //#endregion

        //        #region 根据检验日期、标本号、仪器和病人姓名组合查询查询申请单信息
        //        [AutoComplete]
        //        public long m_lngGetApplicationVOArrByCondition(System.Security.Principal.IPrincipal p_objPrincipal, string p_strFromDat, string p_strToDat,
        //            string p_strDeviceID, string p_strPatientName, string p_strSampleID, out clsLisApplMainVO[] p_objResultArr)
        //        {
        //            long lngRes = 0;
        //            p_objResultArr = null;
        //            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngGetApplicationVOArrByCondition");
        //            if (lngRes < 0)
        //            {
        //                return -1;
        //            }

        //            string strSQL = @"SELECT DISTINCT t1.application_id_chr, t1.patientid_chr, t1.application_dat,
        //                                       t1.sex_chr, t1.patient_name_vchr, t1.patient_subno_chr, t1.age_chr,
        //                                       t1.patient_type_id_chr, t1.diagnose_vchr, t1.bedno_chr, t1.icdcode_chr,
        //                                       t1.patientcardid_chr, t1.application_form_no_chr, t1.modify_dat,
        //                                       t1.operator_id_chr, t1.appl_empid_chr, t1.appl_deptid_chr,
        //                                       t1.summary_vchr, t1.pstatus_int, t1.emergency_int, t1.special_int,
        //                                       t1.form_int, t1.patient_inhospitalno_chr, t1.sample_type_id_chr,
        //                                       t1.check_content_vchr, t1.sample_type_vchr, t1.oringin_dat,
        //                                       t1.charge_info_vchr, t1.printed_num, t1.orderunitrelation_vchr,
        //                                       t1.printed_date
        //								FROM t_opr_lis_application t1,
        //									 t_opr_lis_sample t2,
        //									 t_opr_lis_device_relation t3
        //							   WHERE t1.application_id_chr = t2.application_id_chr
        //								 AND t2.sample_id_chr = t3.sample_id_chr
        //								 AND t2.status_int > 0
        //								 AND t1.pstatus_int > 0
        //								 AND t3.status_int > 0";
        //            if (p_strFromDat.ToString().Trim() != "" && p_strToDat.ToString().Trim() != "")
        //            {
        //                strSQL += " AND t2.CHECK_DATE_DAT BETWEEN TO_DATE('" + p_strFromDat + "','yyyy-mm-dd hh24:mi:ss') AND TO_DATE('" + p_strToDat + "','yyyy-mm-dd hh24:mi:ss')";
        //            }
        //            if (p_strDeviceID.ToString().Trim() != "")
        //            {
        //                strSQL += " AND t3.deviceid_chr = '" + p_strDeviceID + "'";
        //            }
        //            if (p_strPatientName.ToString().Trim() != "")
        //            {
        //                strSQL += " AND t1.PATIENT_NAME_VCHR = '" + p_strPatientName + "'";
        //            }
        //            if (p_strSampleID.ToString().Trim() != "")
        //            {
        //                strSQL += " AND t2.sample_id_chr = '" + p_strSampleID + "'";
        //            }
        //            try
        //            {
        //                DataTable dtbResult = new DataTable();
        //                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
        //                objHRPSvc.Dispose();
        //                if (lngRes > 0 && dtbResult.Rows.Count > 0)
        //                {
        //                    p_objResultArr = new clsLisApplMainVO[dtbResult.Rows.Count];
        //                    for (int i1 = 0; i1 < p_objResultArr.Length; i1++)
        //                    {
        //                        p_objResultArr[i1] = new clsVOConstructor().m_objConstructAppMainVO(dtbResult.Rows[i1]);
        //                        //						p_objResultArr[i1] = new clsLisApplMainVO();
        //                        //						p_objResultArr[i1].m_strAPPLICATION_ID = dtbResult.Rows[i1]["APPLICATION_ID_CHR"].ToString().Trim();
        //                        //						p_objResultArr[i1].m_strPatientID = dtbResult.Rows[i1]["PATIENTID_CHR"].ToString().Trim();
        //                        //						p_objResultArr[i1].m_strAppl_Dat = dtbResult.Rows[i1]["APPLICATION_DAT"].ToString().Trim();
        //                        //						p_objResultArr[i1].m_strSex = dtbResult.Rows[i1]["SEX_CHR"].ToString().Trim();
        //                        //						p_objResultArr[i1].m_strPatient_Name = dtbResult.Rows[i1]["PATIENT_NAME_VCHR"].ToString().Trim();
        //                        //						p_objResultArr[i1].m_strPatient_SubNO = dtbResult.Rows[i1]["PATIENT_SUBNO_CHR"].ToString().Trim();
        //                        //						p_objResultArr[i1].m_strAge = dtbResult.Rows[i1]["AGE_CHR"].ToString().Trim();
        //                        //						p_objResultArr[i1].m_strPatientType = dtbResult.Rows[i1]["PATIENT_TYPE_ID_CHR"].ToString().Trim();
        //                        //						p_objResultArr[i1].m_strDiagnose = dtbResult.Rows[i1]["DIAGNOSE_VCHR"].ToString().Trim();
        //                        //						p_objResultArr[i1].m_strBedNO = dtbResult.Rows[i1]["BEDNO_CHR"].ToString().Trim();
        //                        //						p_objResultArr[i1].m_strICD = dtbResult.Rows[i1]["ICDCODE_CHR"].ToString().Trim();
        //                        //						p_objResultArr[i1].m_strPatientcardID = dtbResult.Rows[i1]["PATIENTCARDID_CHR"].ToString().Trim();
        //                        //						p_objResultArr[i1].m_strApplication_Form_NO = dtbResult.Rows[i1]["APPLICATION_FORM_NO_CHR"].ToString().Trim();
        //                        //						p_objResultArr[i1].m_strMODIFY_DAT = Convert.ToDateTime(dtbResult.Rows[i1]["MODIFY_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
        //                        //						p_objResultArr[i1].m_strOperator_ID = dtbResult.Rows[i1]["OPERATOR_ID_CHR"].ToString().Trim();
        //                        //						p_objResultArr[i1].m_strAppl_EmpID = dtbResult.Rows[i1]["APPL_EMPID_CHR"].ToString().Trim();
        //                        //						p_objResultArr[i1].m_strAppl_DeptID = dtbResult.Rows[i1]["APPL_DEPTID_CHR"].ToString().Trim();
        //                        //						p_objResultArr[i1].m_strSummary = dtbResult.Rows[i1]["SUMMARY_VCHR"].ToString().Trim();
        //                        //						p_objResultArr[i1].m_intPStatus_int = Convert.ToInt32(dtbResult.Rows[i1]["PSTATUS_INT"].ToString().Trim());
        //                        //						p_objResultArr[i1].m_intEmergency = Convert.ToInt32(dtbResult.Rows[i1]["EMERGENCY_INT"].ToString().Trim());
        //                        //						p_objResultArr[i1].m_intSpecial = Convert.ToInt32(dtbResult.Rows[i1]["SPECIAL_INT"].ToString().Trim());
        //                        //						p_objResultArr[i1].m_intForm_int = Convert.ToInt32(dtbResult.Rows[i1]["FORM_INT"].ToString().Trim());
        //                        //						p_objResultArr[i1].m_strPatient_inhospitalno_chr = dtbResult.Rows[i1]["PATIENT_INHOSPITALNO_CHR"].ToString().Trim();
        //                    }
        //                }
        //            }
        //            catch (Exception objEx)
        //            {
        //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //                bool blnRes = objLogger.LogError(objEx);
        //            }
        //            return lngRes;
        //        }
        //        #endregion

        //#region 根据申请单ID查询申请单信息 
        //[AutoComplete]
        //public long m_lngGetApplicationInfoByApplicationID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strApplicationID,
        //    out clsLisApplMainVO[] p_objResultArr)
        //{
        //    long lngRes = 0;
        //    p_objResultArr = null;
        //    clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //    lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngGetApplicationInfoByApplicationID");
        //    if (lngRes < 0)
        //    {
        //        return -1;
        //    }
        //    string strSQL = @"SELECT * FROM T_OPR_LIS_APPLICATION WHERE application_id_chr = '" + p_strApplicationID + @"' AND PSTATUS_INT > 0";
        //    try
        //    {
        //        DataTable dtbResult = new DataTable();
        //        com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //        lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
        //        objHRPSvc.Dispose();
        //        if (lngRes > 0 && dtbResult.Rows.Count > 0)
        //        {
        //            p_objResultArr = new clsLisApplMainVO[dtbResult.Rows.Count];
        //            for (int i1 = 0; i1 < p_objResultArr.Length; i1++)
        //            {
        //                p_objResultArr[i1] = new clsVOConstructor().m_objConstructAppMainVO(dtbResult.Rows[i1]);
        //                //						p_objResultArr[i1] = new clsLisApplMainVO();
        //                //						p_objResultArr[i1].m_strAPPLICATION_ID = dtbResult.Rows[i1]["APPLICATION_ID_CHR"].ToString().Trim();
        //                //						p_objResultArr[i1].m_strPatientID = dtbResult.Rows[i1]["PATIENTID_CHR"].ToString().Trim();
        //                //						p_objResultArr[i1].m_strAppl_Dat = dtbResult.Rows[i1]["APPLICATION_DAT"].ToString().Trim();
        //                //						p_objResultArr[i1].m_strSex = dtbResult.Rows[i1]["SEX_CHR"].ToString().Trim();
        //                //						p_objResultArr[i1].m_strPatient_Name = dtbResult.Rows[i1]["PATIENT_NAME_VCHR"].ToString().Trim();
        //                //						p_objResultArr[i1].m_strPatient_SubNO = dtbResult.Rows[i1]["PATIENT_SUBNO_CHR"].ToString().Trim();
        //                //						p_objResultArr[i1].m_strAge = dtbResult.Rows[i1]["AGE_CHR"].ToString().Trim();
        //                //						p_objResultArr[i1].m_strPatientType = dtbResult.Rows[i1]["PATIENT_TYPE_ID_CHR"].ToString().Trim();
        //                //						p_objResultArr[i1].m_strDiagnose = dtbResult.Rows[i1]["DIAGNOSE_VCHR"].ToString().Trim();
        //                //						p_objResultArr[i1].m_strBedNO = dtbResult.Rows[i1]["BEDNO_CHR"].ToString().Trim();
        //                //						p_objResultArr[i1].m_strICD = dtbResult.Rows[i1]["ICDCODE_CHR"].ToString().Trim();
        //                //						p_objResultArr[i1].m_strPatientcardID = dtbResult.Rows[i1]["PATIENTCARDID_CHR"].ToString().Trim();
        //                //						p_objResultArr[i1].m_strApplication_Form_NO = dtbResult.Rows[i1]["APPLICATION_FORM_NO_CHR"].ToString().Trim();
        //                //						p_objResultArr[i1].m_strMODIFY_DAT = Convert.ToDateTime(dtbResult.Rows[i1]["MODIFY_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
        //                //						p_objResultArr[i1].m_strOperator_ID = dtbResult.Rows[i1]["OPERATOR_ID_CHR"].ToString().Trim();
        //                //						p_objResultArr[i1].m_strAppl_EmpID = dtbResult.Rows[i1]["APPL_EMPID_CHR"].ToString().Trim();
        //                //						p_objResultArr[i1].m_strAppl_DeptID = dtbResult.Rows[i1]["APPL_DEPTID_CHR"].ToString().Trim();
        //                //						p_objResultArr[i1].m_strSummary = dtbResult.Rows[i1]["SUMMARY_VCHR"].ToString().Trim();
        //                //						p_objResultArr[i1].m_intPStatus_int = Convert.ToInt32(dtbResult.Rows[i1]["PSTATUS_INT"].ToString().Trim());
        //                //						p_objResultArr[i1].m_intEmergency = Convert.ToInt32(dtbResult.Rows[i1]["EMERGENCY_INT"].ToString().Trim());
        //                //						p_objResultArr[i1].m_intSpecial = Convert.ToInt32(dtbResult.Rows[i1]["SPECIAL_INT"].ToString().Trim());
        //                //						p_objResultArr[i1].m_intForm_int = Convert.ToInt32(dtbResult.Rows[i1]["FORM_INT"].ToString().Trim());
        //                //						p_objResultArr[i1].m_strPatient_inhospitalno_chr = dtbResult.Rows[i1]["PATIENT_INHOSPITALNO_CHR"].ToString().Trim();
        //                //						p_objResultArr[i1].m_strCheckContent = dtbResult.Rows[i1]["CHECK_CONTENT_VCHR"].ToString().Trim();
        //                //						p_objResultArr[i1].m_strSampleTypeID = dtbResult.Rows[i1]["SAMPLE_TYPE_ID_CHR"].ToString().Trim();
        //                //						p_objResultArr[i1].m_strSampleType = dtbResult.Rows[i1]["SAMPLE_TYPE_VCHR"].ToString().Trim();
        //            }
        //        }
        //    }
        //    catch (Exception objEx)
        //    {
        //        com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //        bool blnRes = objLogger.LogError(objEx);
        //    }
        //    return lngRes;
        //}
        //#endregion

        #region 根据申请单ID查询申请单下的报告组
        /// <summary>
        /// 根据申请单ID查询申请单下的报告组
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strApplicationID"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAppReportVOArrByApplicationID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strApplicationID, out clsT_OPR_LIS_APP_REPORT_VO[] p_objResultArr)
        {
            p_objResultArr = null;
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngGetAppReportVOArrByApplicationID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strCondition = "APPLICATION_ID_CHR = '" + p_strApplicationID + "' AND STATUS_INT > 0";
            lngRes = m_lngGetAppReportVOArrByCondition(p_objPrincipal, strCondition, out p_objResultArr);
            return lngRes;
        }
        #endregion

        #region 根据申请单ID和报告组ID查询申请申请单下的标本组
        /// <summary>
        /// 根据申请单ID和报告组ID查询申请申请单下的标本组
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strApplicationID"></param>
        /// <param name="p_strReportGroupID"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAppSampleGroupVOArr(System.Security.Principal.IPrincipal p_objPrincipal, string p_strApplicationID,
            string p_strReportGroupID, out clsT_OPR_LIS_APP_SAMPLE_VO[] p_objResultArr)
        {
            p_objResultArr = null;
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngGetAppSampleGroupVOArr");
            if (lngRes < 0)
            {
                return -1;
            }

            string strCondition = "APPLICATION_ID_CHR = '" + p_strApplicationID + "' AND REPORT_GROUP_ID_CHR = '" + p_strReportGroupID + "'";
            lngRes = m_lngGetAppSampleGroupVOArrByCondition(p_objPrincipal, strCondition, out p_objResultArr);

            return lngRes;
        }
        #endregion

        #region 根据申请单ID查询申请单下的标本组
        /// <summary>
        /// 根据申请单ID查询申请单下的标本组
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strApplicationID"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAppSampleGroupVOArr(System.Security.Principal.IPrincipal p_objPrincipal, string p_strApplicationID, out clsT_OPR_LIS_APP_SAMPLE_VO[] p_objResultArr)
        {
            p_objResultArr = null;
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngGetAppSampleGroupVOArr");
            if (lngRes < 0)
            {
                return -1;
            }

            string strCondition = "APPLICATION_ID_CHR = '" + p_strApplicationID + "'";
            lngRes = m_lngGetAppSampleGroupVOArrByCondition(p_objPrincipal, strCondition, out p_objResultArr);

            return lngRes;
        }
        #endregion

        #region 根据申请单ID、样本组ID和报告组ID查询申请单下的检验项目
        /// <summary>
        /// 根据申请单ID、样本组ID和报告组ID查询申请单下的检验项目
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strApplicationID">申请单ID</param>
        /// <param name="p_strSampleGroupID">样本组ID</param>
        /// <param name="p_strReportGroupID">报告组ID</param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAppCheckItemVOArr(System.Security.Principal.IPrincipal p_objPrincipal, string p_strApplicationID,
            string p_strSampleGroupID, string p_strReportGroupID, out clsT_OPR_LIS_APP_CHECK_ITEM_VO[] p_objResultArr)
        {
            p_objResultArr = null;
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngGetAppCheckItemVOArr");
            if (lngRes < 0)
            {
                return -1;
            }

            string strCondition = "APPLICATION_ID_CHR = '" + p_strApplicationID + "' AND SAMPLE_GROUP_ID_CHR = '" + p_strSampleGroupID + "' AND REPORT_GROUP_ID_CHR = '" + p_strReportGroupID + "'";
            lngRes = m_lngGetAppCheckItemVOArrByCondition(p_objPrincipal, strCondition, out p_objResultArr);
            return lngRes;
        }
        #endregion

        #region 根据申请单ID查询申请单下的检验项目
        /// <summary>
        /// 根据申请单查询申请单下的检验项目
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strApplicationID">申请单ID</param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAppCheckItemVOArr(System.Security.Principal.IPrincipal p_objPrincipal, string p_strApplicationID, out clsT_OPR_LIS_APP_CHECK_ITEM_VO[] p_objResultArr)
        {
            p_objResultArr = null;
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngGetAppCheckItemVOArr");
            if (lngRes < 0)
            {
                return -1;
            }

            string strCondition = "APPLICATION_ID_CHR = '" + p_strApplicationID + "'";
            lngRes = m_lngGetAppCheckItemVOArrByCondition(p_objPrincipal, strCondition, out p_objResultArr);
            return lngRes;
        }
        #endregion

        #region 根据申请单ID查询申请单下的申请单元
        /// <summary>
        /// 根据申请单ID查询申请单下的申请单元
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strApplicationID">申请单ID</param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAppApplyUnitVOByApplicationID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strApplicationID, out clsT_OPR_LIS_APP_APPLY_UNIT_VO[] p_objResultArr)
        {
            p_objResultArr = null;
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngGetAppApplyUnitVOByApplicationID");
            if (lngRes < 0)
            {
                return -1;
            }

            string strCondition = "APPLICATION_ID_CHR = '" + p_strApplicationID + "'";

            lngRes = m_lngGetAppApplyUintVOArrByCondition(p_objPrincipal, strCondition, out p_objResultArr);

            return lngRes;
        }
        #endregion

        #region *PROTECTED* m_lngGetAppReportVOArrByCondition 组合查询,得到申请单下的报告组VOArr
        /// <summary>
        /// 组合查询,得到申请单下的报告组VOArr 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strQueryCondition"></param>
        /// <param name="p_objResultArr">clsT_OPR_LIS_APP_REPORT_VO 的数组</param>
        /// <returns></returns>
        [AutoComplete]
        protected long m_lngGetAppReportVOArrByCondition(System.Security.Principal.IPrincipal p_objPrincipal, string p_strQueryCondition, out clsT_OPR_LIS_APP_REPORT_VO[] p_objResultArr)
        {
            p_objResultArr = new clsT_OPR_LIS_APP_REPORT_VO[0];
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngGetAppReportVOArrByCondition");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"SELECT * FROM T_OPR_LIS_APP_REPORT ";

            if (p_strQueryCondition != null && p_strQueryCondition.Trim() != "")
            {
                strSQL = strSQL + " WHERE " + p_strQueryCondition;
            }


            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsT_OPR_LIS_APP_REPORT_VO[dtbResult.Rows.Count];
                    for (int i1 = 0; i1 < p_objResultArr.Length; i1++)
                    {
                        p_objResultArr[i1] = new clsT_OPR_LIS_APP_REPORT_VO();
                        p_objResultArr[i1].m_strAPPLICATION_ID_CHR = dtbResult.Rows[i1]["APPLICATION_ID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strREPORT_GROUP_ID_CHR = dtbResult.Rows[i1]["REPORT_GROUP_ID_CHR"].ToString().Trim();
                        if (Microsoft.VisualBasic.Information.IsDate(dtbResult.Rows[i1]["MODIFY_DAT"]))
                        {
                            p_objResultArr[i1].m_strMODIFY_DAT = Convert.ToDateTime(dtbResult.Rows[i1]["MODIFY_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                        }
                        p_objResultArr[i1].m_strSUMMARY_VCHR = dtbResult.Rows[i1]["SUMMARY_VCHR"].ToString().Trim();
                        p_objResultArr[i1].m_strANNOTATION_VCHR = dtbResult.Rows[i1]["ANNOTATION_VCHR"].ToString().Trim();
                        p_objResultArr[i1].m_strOPERATOR_ID_CHR = dtbResult.Rows[i1]["OPERATOR_ID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_intSTATUS_INT = int.Parse(dtbResult.Rows[i1]["STATUS_INT"].ToString().Trim());
                        p_objResultArr[i1].m_strXML_SUMMARY_VCHR = dtbResult.Rows[i1]["XML_SUMMARY_VCHR"].ToString().Trim();
                        p_objResultArr[i1].m_strXML_ANNOTATION_VCHR = dtbResult.Rows[i1]["XML_ANNOTATION_VCHR"].ToString().Trim();
                        if (Microsoft.VisualBasic.Information.IsDate(dtbResult.Rows[i1]["REPORT_DAT"]))
                        {
                            p_objResultArr[i1].m_strREPORT_DAT = Convert.ToDateTime(dtbResult.Rows[i1]["REPORT_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                        }
                        p_objResultArr[i1].m_strREPORTOR_ID_CHR = dtbResult.Rows[i1]["REPORTOR_ID_CHR"].ToString().Trim();
                        if (Microsoft.VisualBasic.Information.IsDate(dtbResult.Rows[i1]["CONFIRM_DAT"]))
                        {
                            p_objResultArr[i1].m_strCONFIRM_DAT = Convert.ToDateTime(dtbResult.Rows[i1]["CONFIRM_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                        }
                        p_objResultArr[i1].m_strCONFIRMER_ID_CHR = dtbResult.Rows[i1]["CONFIRMER_ID_CHR"].ToString().Trim();
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

        #region *PROTECTED* m_lngGetAppSampleGroupVOArr 组合查询,得到申请单下的标本组VOArr
        /// <summary>
        /// 组合查询,得到申请单下的标本组VOArr 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strQueryCondition"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        protected long m_lngGetAppSampleGroupVOArrByCondition(System.Security.Principal.IPrincipal p_objPrincipal, string p_strQueryCondition, out clsT_OPR_LIS_APP_SAMPLE_VO[] p_objResultArr)
        {
            p_objResultArr = new clsT_OPR_LIS_APP_SAMPLE_VO[0];
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngGetAppSampleGroupVOArrByCondition");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT * FROM T_OPR_LIS_APP_SAMPLE ";

            if (p_strQueryCondition != null && p_strQueryCondition.Trim() != "")
            {
                strSQL = strSQL + " WHERE " + p_strQueryCondition;
            }

            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsT_OPR_LIS_APP_SAMPLE_VO[dtbResult.Rows.Count];
                    for (int i1 = 0; i1 < p_objResultArr.Length; i1++)
                    {
                        p_objResultArr[i1] = new clsT_OPR_LIS_APP_SAMPLE_VO();
                        p_objResultArr[i1].m_strAPPLICATION_ID_CHR = dtbResult.Rows[i1]["APPLICATION_ID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strSAMPLE_GROUP_ID_CHR = dtbResult.Rows[i1]["SAMPLE_GROUP_ID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strREPORT_GROUP_ID_CHR = dtbResult.Rows[i1]["REPORT_GROUP_ID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strSAMPLE_ID_CHR = dtbResult.Rows[i1]["SAMPLE_ID_CHR"].ToString().Trim();
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

        #region *PROTECTED* m_lngGetAppCheckItemVOArrByCondition 组合查询,得到申请单下的检验项目VOArr
        /// <summary>
        /// 组合查询,得到申请单下的检验项目VOArr 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strQueryCondition"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        protected long m_lngGetAppCheckItemVOArrByCondition(System.Security.Principal.IPrincipal p_objPrincipal, string p_strQueryCondition, out clsT_OPR_LIS_APP_CHECK_ITEM_VO[] p_objResultArr)
        {
            p_objResultArr = new clsT_OPR_LIS_APP_CHECK_ITEM_VO[0];
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngGetAppCheckItemVOArrByCondition");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT * FROM T_OPR_LIS_APP_CHECK_ITEM  ";
            if (p_strQueryCondition != null && p_strQueryCondition.Trim() != "")
            {
                strSQL = strSQL + " WHERE " + p_strQueryCondition;
            }
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsT_OPR_LIS_APP_CHECK_ITEM_VO[dtbResult.Rows.Count];
                    for (int i1 = 0; i1 < p_objResultArr.Length; i1++)
                    {
                        p_objResultArr[i1] = new clsT_OPR_LIS_APP_CHECK_ITEM_VO();
                        p_objResultArr[i1].m_strCHECK_ITEM_ID_CHR = dtbResult.Rows[i1]["CHECK_ITEM_ID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strSAMPLE_GROUP_ID_CHR = dtbResult.Rows[i1]["SAMPLE_GROUP_ID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strREPORT_GROUP_ID_CHR = dtbResult.Rows[i1]["REPORT_GROUP_ID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strAPPLICATION_ID_CHR = dtbResult.Rows[i1]["APPLICATION_ID_CHR"].ToString().Trim();
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

        #region *PROTECTED* m_lngGetAppApplyUintVOArr 组合查询,得到申请单下的申请单元VOArr
        /// <summary>
        /// 组合查询,得到申请单下的申请单元VOArr 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strQueryCondition"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        protected long m_lngGetAppApplyUintVOArrByCondition(System.Security.Principal.IPrincipal p_objPrincipal, string p_strQueryCondition, out clsT_OPR_LIS_APP_APPLY_UNIT_VO[] p_objResultArr)
        {
            p_objResultArr = new clsT_OPR_LIS_APP_APPLY_UNIT_VO[0];
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngGetAppApplyUintVOArrByCondition");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT * FROM T_OPR_LIS_APP_APPLY_UNIT ";
            if (p_strQueryCondition != null && p_strQueryCondition.Trim() != "")
            {
                strSQL = strSQL + " WHERE " + p_strQueryCondition;
            }

            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsT_OPR_LIS_APP_APPLY_UNIT_VO[dtbResult.Rows.Count];
                    for (int i1 = 0; i1 < p_objResultArr.Length; i1++)
                    {
                        p_objResultArr[i1] = new clsT_OPR_LIS_APP_APPLY_UNIT_VO();
                        p_objResultArr[i1].m_strAPPLICATION_ID_CHR = dtbResult.Rows[i1]["APPLICATION_ID_CHR"].ToString().Trim();
                        p_objResultArr[i1].m_strUSER_GROUP_STRING = dtbResult.Rows[i1]["USER_GROUP_STRING"].ToString().Trim();
                        p_objResultArr[i1].m_strAPPLY_UNIT_ID_CHR = dtbResult.Rows[i1]["APPLY_UNIT_ID_CHR"].ToString().Trim();
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

        #region m_lngAddNewAppApplyUint 为表 T_OPR_LIS_APP_APPLY_UNIT 新增记录时用
        /// <summary>
        /// 为表 T_OPR_LIS_APP_APPLY_UNIT 新增记录时用 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRecordVOArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewAppApplyUint(System.Security.Principal.IPrincipal p_objPrincipal, clsT_OPR_LIS_APP_APPLY_UNIT_VO[] p_objRecordVOArr)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngAddNewAppApplyUint");
            if (lngRes < 0)
            {
                return -1;
            }
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                if (p_objRecordVOArr != null)
                {
                    for (int i = 0; i < p_objRecordVOArr.Length; i++)
                    {
                        if (p_objRecordVOArr[i] != null)
                        {
                            lngRes = 0;
                            string strSQL = "INSERT INTO T_OPR_LIS_APP_APPLY_UNIT (APPLICATION_ID_CHR,USER_GROUP_STRING,APPLY_UNIT_ID_CHR) VALUES ('" + p_objRecordVOArr[i].m_strAPPLICATION_ID_CHR + "','" + p_objRecordVOArr[i].m_strUSER_GROUP_STRING + "','" + p_objRecordVOArr[i].m_strAPPLY_UNIT_ID_CHR + "')";
                            lngRes = objHRPSvc.DoExcute(strSQL);
                        }
                    }
                    objHRPSvc.Dispose();
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

        #region SQL c_strAddNewAppl_SQL
        private const string c_strAddNewAppl_SQL = @"insert into t_opr_lis_application(application_id_chr, 
                          modify_dat, 
                          patientid_chr, 
                          application_dat, 
                          sex_chr, 
                          patient_name_vchr, 
                          patient_subno_chr, 
                          age_chr, 
                          patient_type_id_chr, 
                          diagnose_vchr, 
                          bedno_chr, 
                          icdcode_chr, 
                          patientcardid_chr, 
                          application_form_no_chr, 
                          operator_id_chr, 
                          appl_empid_chr, 
                          appl_deptid_chr, 
                          summary_vchr, 
                          pstatus_int,
                          emergency_int,
                          special_int,
                          form_int,
                          patient_inhospitalno_chr,
                          sample_type_id_chr,
                          sample_type_vchr,
                          check_content_vchr,
                          oringin_dat,
                          charge_info_vchr,
                          orderunitrelation_vchr, printed_num,printed_date)
                          values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?, ?,?,?)";
        #endregion

        #region m_lngAddNewAppCheckItem 为表 T_OPR_LIS_APP_CHECK_ITEM 新增记录时用
        /// <summary>
        /// 为表 T_OPR_LIS_APP_CHECK_ITEM 新增记录时用
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRecordVOArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewAppCheckItem(System.Security.Principal.IPrincipal p_objPrincipal, clsT_OPR_LIS_APP_CHECK_ITEM_VO[] p_objRecordVOArr)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngAddNewAppCheckItem");
            if (lngRes < 0)
            {
                return -1;
            }
            DbType[] m_dbType = new DbType[] { DbType.String, DbType.String, DbType.String, DbType.String, DbType.String };
            object[][] objValues = new object[5][];
            for (int i = 0; i < objValues.Length; i++)
            {
                objValues[i] = new object[p_objRecordVOArr.Length];
            }
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                if (p_objRecordVOArr != null)
                {
                    string strSQL = @"insert into t_opr_lis_app_check_item
  (check_item_id_chr,
   sample_group_id_chr,
   report_group_id_chr,
   application_id_chr,
   itemprice_mny)
values
  (?, ?, ?, ?, ?)
";
                    for (int i = 0; i < p_objRecordVOArr.Length; i++)
                    {

                        if (p_objRecordVOArr[i] != null)
                        {
                            objValues[0][i] = p_objRecordVOArr[i].m_strCHECK_ITEM_ID_CHR;
                            objValues[1][i] = p_objRecordVOArr[i].m_strSAMPLE_GROUP_ID_CHR;
                            objValues[2][i] = p_objRecordVOArr[i].m_strREPORT_GROUP_ID_CHR;
                            objValues[3][i] = p_objRecordVOArr[i].m_strAPPLICATION_ID_CHR;
                            if (!string.IsNullOrEmpty(p_objRecordVOArr[i].m_strItemprice_mny))
                            {
                                objValues[4][i] = Convert.ToDouble(p_objRecordVOArr[i].m_strItemprice_mny);
                            }
                        }
                    }
                    lngRes = 0;
                    lngRes = objHRPSvc.m_lngSaveArrayWithParameters(strSQL, objValues, m_dbType);
                    objHRPSvc.Dispose();
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

        #region m_lngAddNewAppSampleGroup 为表 T_OPR_LIS_APP_SAMPLE 新增 记录时用
        /// <summary>
        /// 为表 T_OPR_LIS_APP_SAMPLE 新增记录时用 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRecordVOArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewAppSampleGroup(System.Security.Principal.IPrincipal p_objPrincipal, clsT_OPR_LIS_APP_SAMPLE_VO[] p_objRecordVOArr)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngAddNewAppSampleGroup");
            if (lngRes < 0)
            {
                return -1;
            }

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                if (p_objRecordVOArr != null)
                {
                    for (int i = 0; i < p_objRecordVOArr.Length; i++)
                    {
                        if (p_objRecordVOArr[i] != null)
                        {
                            lngRes = 0;
                            string strSQL = "INSERT INTO T_OPR_LIS_APP_SAMPLE (APPLICATION_ID_CHR,SAMPLE_GROUP_ID_CHR,REPORT_GROUP_ID_CHR,SAMPLE_ID_CHR) VALUES ('" + p_objRecordVOArr[i].m_strAPPLICATION_ID_CHR + "','" + p_objRecordVOArr[i].m_strSAMPLE_GROUP_ID_CHR + "','" + p_objRecordVOArr[i].m_strREPORT_GROUP_ID_CHR + "','" + p_objRecordVOArr[i].m_strSAMPLE_ID_CHR + "')";
                            lngRes = objHRPSvc.DoExcute(strSQL);

                        }
                    }
                    objHRPSvc.Dispose();
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

        #region [U]m_lngInsertAppReportRecord  为表 t_opr_lis_app_report 新增,修改,删除 记录时用

        /// <summary>
        /// 为表 t_opr_lis_app_report 新增,修改,删除 记录时用 
        /// 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRecordVOArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngInsertAppReportRecord(System.Security.Principal.IPrincipal p_objPrincipal, clsT_OPR_LIS_APP_REPORT_VO[] p_objRecordVOArr)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngInsertAppReportRecord");
            if (lngRes < 0)
            {
                return -1;
            }

            string strNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            string strSQL = @"INSERT INTO t_opr_lis_app_report (APPLICATION_ID_CHR,REPORT_GROUP_ID_CHR,MODIFY_DAT,SUMMARY_VCHR,
																			OPERATOR_ID_CHR,STATUS_INT,REPORT_DAT,REPORTOR_ID_CHR,
																			CONFIRM_DAT,CONFIRMER_ID_CHR,XML_SUMMARY_VCHR,ANNOTATION_VCHR,XML_ANNOTATION_VCHR) 
							  VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?)";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                if (p_objRecordVOArr != null)
                {
                    for (int i = 0; i < p_objRecordVOArr.Length; i++)
                    {
                        if (p_objRecordVOArr[i] != null)
                        {
                            IDataParameter[] objDPArr = null;
                            objHRPSvc.CreateDatabaseParameter(13, out objDPArr);

                            objDPArr[0].Value = p_objRecordVOArr[i].m_strAPPLICATION_ID_CHR;
                            objDPArr[1].Value = p_objRecordVOArr[i].m_strREPORT_GROUP_ID_CHR;
                            p_objRecordVOArr[i].m_strMODIFY_DAT = strNow;
                            objDPArr[2].Value = DateTime.Parse(p_objRecordVOArr[i].m_strMODIFY_DAT);
                            objDPArr[3].Value = p_objRecordVOArr[i].m_strSUMMARY_VCHR;
                            objDPArr[4].Value = p_objRecordVOArr[i].m_strOPERATOR_ID_CHR;
                            objDPArr[5].Value = p_objRecordVOArr[i].m_intSTATUS_INT;
                            if (Microsoft.VisualBasic.Information.IsDate(p_objRecordVOArr[i].m_strREPORT_DAT))
                            {
                                objDPArr[6].Value = DateTime.Parse(p_objRecordVOArr[i].m_strREPORT_DAT);
                            }
                            else
                            {
                                p_objRecordVOArr[i].m_strREPORT_DAT = null;
                            }
                            objDPArr[7].Value = p_objRecordVOArr[i].m_strREPORTOR_ID_CHR;
                            if (Microsoft.VisualBasic.Information.IsDate(p_objRecordVOArr[i].m_strCONFIRM_DAT))
                            {
                                objDPArr[8].Value = DateTime.Parse(p_objRecordVOArr[i].m_strCONFIRM_DAT);
                            }
                            else
                            {
                                p_objRecordVOArr[i].m_strCONFIRM_DAT = null;
                            }
                            objDPArr[9].Value = p_objRecordVOArr[i].m_strCONFIRMER_ID_CHR;
                            objDPArr[10].Value = p_objRecordVOArr[i].m_strXML_SUMMARY_VCHR;
                            objDPArr[11].Value = p_objRecordVOArr[i].m_strANNOTATION_VCHR;
                            objDPArr[12].Value = p_objRecordVOArr[i].m_strXML_ANNOTATION_VCHR;


                            lngRes = 0;
                            long lngEff = 0;
                            lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                            if (lngRes < 0)
                            {
                                throw new Exception("保存报告单失败.");
                            }
                            objHRPSvc.Dispose();
                        }
                    }
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                throw objEx;
            }
            return lngRes;
        }
        #endregion

        #region m_lngAddNewAppl 增加新的检验申请记录(修改,删除时都为新增记录)
        /// <summary>
        /// 增加新的检验申请记录(修改,删除时都为新增记录) 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objLisApplMainVO"></param>
        /// <param name="p_objLisApplMainOutVO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewAppl(System.Security.Principal.IPrincipal p_objPrincipal,
            com.digitalwave.iCare.ValueObject.clsLisApplMainVO p_objLisApplMainVO,
            out com.digitalwave.iCare.ValueObject.clsLisApplMainVO p_objLisApplMainOutVO)
        {
            p_objLisApplMainOutVO = p_objLisApplMainVO;
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngAddNewAppl");
            if (lngRes < 0)
            {
                return -1;
            }
            try
            {
                System.Data.IDataParameter[] objLisApplArr = null;

                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(31, out objLisApplArr);

                DateTime CurTime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                if (p_objLisApplMainVO.m_strMODIFY_DAT != null && p_objLisApplMainVO.m_strMODIFY_DAT.Trim() != "")
                {
                    try
                    {
                        DateTime dtmPreModify = DateTime.Parse(p_objLisApplMainVO.m_strMODIFY_DAT);
                        TimeSpan ts = CurTime - dtmPreModify;
                        if (ts.TotalMilliseconds < 1000)
                            CurTime = CurTime.AddSeconds(1f);
                    }
                    catch { }
                }
                // 处理年龄，门诊、住院、体检等接口传入出生日期
                if (!string.IsNullOrEmpty(p_objLisApplMainVO.m_strBirthDay))
                {
                    string strAge = "";
                    try
                    {
                        DateTime dtBirthDay = DateTime.Parse(p_objLisApplMainVO.m_strBirthDay);
                        TimeSpan tspAge = CurTime - dtBirthDay;
                        if (tspAge.Days < 30)
                        {
                            if (tspAge.Days == 0)
                            {
                                strAge = "1 天";
                            }
                            else
                            {
                                strAge = tspAge.Days.ToString() + " 天";
                            }
                        }
                        else if (tspAge.Days <= 366)
                        {
                            strAge = ((int)(tspAge.Days / 30)).ToString() + " 月";
                        }
                        else
                        {
                            strAge = ((int)(CurTime.Year - dtBirthDay.Year)).ToString() + " 岁";
                        }

                        if (!string.IsNullOrEmpty(strAge))
                        {
                            p_objLisApplMainVO.m_strAge = strAge;
                        }
                    }
                    catch { }
                }

                if (p_objLisApplMainVO.m_strAPPLICATION_ID == null ||
                    p_objLisApplMainVO.m_strAPPLICATION_ID.Trim() == "")
                {
                    string strNewApplID = null;
                    objHRPSvc.m_lngGenerateNewID("t_opr_lis_application", "APPLICATION_ID_CHR", out strNewApplID);
                    if (strNewApplID == null || strNewApplID == "")
                    {
                        throw new Exception("不能分配申请单ID");
                    }
                    p_objLisApplMainVO.m_strAPPLICATION_ID = strNewApplID;

                }


                objLisApplArr[0].Value = p_objLisApplMainVO.m_strAPPLICATION_ID;
                p_objLisApplMainVO.m_strMODIFY_DAT = CurTime.ToString("yyyy-MM-dd HH:mm:ss");
                objLisApplArr[1].Value = CurTime;
                //				objLisApplArr[1].DbType = DbType.DateTime;
                if (p_objLisApplMainVO.m_strPatientID == null || p_objLisApplMainVO.m_strPatientID.Trim() == "")
                {
                    p_objLisApplMainVO.m_strPatientID = "-1";
                }
                objLisApplArr[2].Value = p_objLisApplMainVO.m_strPatientID;
                objLisApplArr[2].DbType = DbType.String;

                if (Microsoft.VisualBasic.Information.IsDate(p_objLisApplMainVO.m_strAppl_Dat))
                {
                    objLisApplArr[3].Value = System.DateTime.Parse(p_objLisApplMainVO.m_strAppl_Dat);
                }
                else
                {
                    p_objLisApplMainVO.m_strAppl_Dat = null;
                }
                objLisApplArr[4].Value = p_objLisApplMainVO.m_strSex;
                objLisApplArr[5].Value = p_objLisApplMainVO.m_strPatient_Name;
                objLisApplArr[6].Value = p_objLisApplMainVO.m_strPatient_SubNO;
                objLisApplArr[7].Value = p_objLisApplMainVO.m_strAge;
                objLisApplArr[8].Value = p_objLisApplMainVO.m_strPatientType;
                objLisApplArr[9].Value = p_objLisApplMainVO.m_strDiagnose;
                objLisApplArr[10].Value = p_objLisApplMainVO.m_strBedNO;
                objLisApplArr[11].Value = p_objLisApplMainVO.m_strICD;
                if (p_objLisApplMainVO.m_strPatientcardID == null || p_objLisApplMainVO.m_strPatientcardID.Trim() == "")
                {
                    objLisApplArr[12].Value = System.DBNull.Value;
                }
                else
                {
                    objLisApplArr[12].Value = p_objLisApplMainVO.m_strPatientcardID;
                }

                objLisApplArr[13].Value = p_objLisApplMainVO.m_strApplication_Form_NO;

                objLisApplArr[14].Value = p_objLisApplMainVO.m_strOperator_ID;
                objLisApplArr[15].Value = p_objLisApplMainVO.m_strAppl_EmpID;
                objLisApplArr[16].Value = p_objLisApplMainVO.m_strAppl_DeptID;
                objLisApplArr[17].Value = p_objLisApplMainVO.m_strSummary;
                objLisApplArr[18].Value = p_objLisApplMainVO.m_intPStatus_int;
                objLisApplArr[19].Value = p_objLisApplMainVO.m_intEmergency;
                objLisApplArr[20].Value = p_objLisApplMainVO.m_intSpecial;
                objLisApplArr[21].Value = p_objLisApplMainVO.m_intForm_int;
                objLisApplArr[22].Value = p_objLisApplMainVO.m_strPatient_inhospitalno_chr;
                objLisApplArr[23].Value = p_objLisApplMainVO.m_strSampleTypeID;
                objLisApplArr[24].Value = p_objLisApplMainVO.m_strSampleType;
                objLisApplArr[25].Value = p_objLisApplMainVO.m_strCheckContent;
                try
                {
                    DateTime.Parse(p_objLisApplMainVO.m_strOriginDate);
                }
                catch
                {
                    p_objLisApplMainVO.m_strOriginDate = CurTime.ToString("yyyy-MM-dd HH:mm:ss");
                }
                objLisApplArr[26].Value = DateTime.Parse(p_objLisApplMainVO.m_strOriginDate);
                objLisApplArr[27].Value = p_objLisApplMainVO.m_strChargeInfo;
                objLisApplArr[28].Value = p_objLisApplMainVO.m_strOrderunitrelation;
                if (p_objLisApplMainOutVO.m_isPrinted)
                {
                    objLisApplArr[29].Value = 1;
                }
                else
                {
                    objLisApplArr[29].Value = 0;
                }
                if (!string.IsNullOrEmpty(p_objLisApplMainOutVO.m_strPrintDate))
                {
                    objLisApplArr[30].Value = DateTime.Parse(p_objLisApplMainOutVO.m_strPrintDate);

                }
                else
                {
                    objLisApplArr[30].Value = System.DBNull.Value;
                }


                long lngRecEff = -1;

                //往表t_opr_lis_application增加记录
                lngRes = objHRPSvc.lngExecuteParameterSQL(c_strAddNewAppl_SQL, ref lngRecEff, objLisApplArr);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                throw objEx;
            }
            return lngRes;
        }
        #endregion

        #region 增加-组新的检验申请信息(包含报告组,申请单元,样本组,检验项目在内的全部信息)
        /// <summary>
        /// 增加-组新的检验申请信息(包含报告组,申请单元,样本组,检验项目在内的全部信息)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objLisApplMainVO"></param>
        /// <param name="p_objReportArr"></param>
        /// <param name="p_objAppSampleArr"></param>
        /// <param name="p_objAppItemArr"></param>
        /// <param name="p_objAppUnitArr"></param>
        /// <param name="p_objAppUnitItemArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewAppInfo(System.Security.Principal.IPrincipal p_objPrincipal,
            com.digitalwave.iCare.ValueObject.clsLisApplMainVO p_objLisApplMainVO,
            out com.digitalwave.iCare.ValueObject.clsLisApplMainVO p_objLisApplMainOutVO,
            com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_APP_REPORT_VO[] p_objReportArr,
            com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_APP_SAMPLE_VO[] p_objAppSampleArr,
            com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_APP_CHECK_ITEM_VO[] p_objAppItemArr,
            com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_APP_APPLY_UNIT_VO[] p_objAppUnitArr,
            com.digitalwave.iCare.ValueObject.clsLisAppUnitItemVO[] p_objAppUnitItemArr)
        {
            p_objLisApplMainOutVO = p_objLisApplMainVO;
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngAddNewAppInfo");
            if (lngRes < 0)
            {
                return -1;
            }
            if (p_objLisApplMainVO == null)
            {
                return -2;
            }

            try
            {
                lngRes = 0;
                lngRes = m_lngAddNewAppl(p_objPrincipal, p_objLisApplMainVO, out p_objLisApplMainOutVO);
                p_objLisApplMainVO = p_objLisApplMainOutVO;
                if (lngRes > 0)
                {
                    #region 赋申请单ID
                    for (int i = 0; i < p_objReportArr.Length; i++)
                    {
                        p_objReportArr[i].m_strAPPLICATION_ID_CHR = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    }
                    for (int i = 0; i < p_objAppSampleArr.Length; i++)
                    {
                        p_objAppSampleArr[i].m_strAPPLICATION_ID_CHR = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    }
                    for (int i = 0; i < p_objAppItemArr.Length; i++)
                    {
                        p_objAppItemArr[i].m_strAPPLICATION_ID_CHR = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    }
                    for (int i = 0; i < p_objAppUnitArr.Length; i++)
                    {
                        p_objAppUnitArr[i].m_strAPPLICATION_ID_CHR = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    }
                    for (int i = 0; i < p_objAppUnitItemArr.Length; i++)
                    {
                        p_objAppUnitItemArr[i].m_strAPPLICATION_ID_CHR = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    }
                    #endregion
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngInsertAppReportRecord(p_objPrincipal, p_objReportArr);
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngAddNewAppSampleGroup(p_objPrincipal, p_objAppSampleArr);
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngAddNewAppCheckItem(p_objPrincipal, p_objAppItemArr);
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngAddNewAppApplyUint(p_objPrincipal, p_objAppUnitArr);
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngAddNewAppUintItemArr(p_objPrincipal, p_objAppUnitItemArr);
                }
                if (lngRes <= 0)
                {
                    throw new Exception(null);
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                throw objEx;
            }

            return lngRes;
        }
        #endregion

        #region 增加-组新的检验申请信息(包含报告组,申请单元,样本组,检验项目,和样本在内的全部信息)
        /// <summary>
        /// 增加-组新的检验申请信息(包含报告组,申请单元,样本组,检验项目,和样本在内的全部信息)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objLisApplMainVO"></param>
        /// <param name="p_objReportArr"></param>
        /// <param name="p_objAppSampleArr"></param>
        /// <param name="p_objAppItemArr"></param>
        /// <param name="p_objAppUnitArr"></param>
        /// <param name="p_objAppUnitItemArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewAppAndSampleInfo(System.Security.Principal.IPrincipal p_objPrincipal,
            com.digitalwave.iCare.ValueObject.clsLisApplMainVO p_objLisApplMainVO,
            out com.digitalwave.iCare.ValueObject.clsLisApplMainVO p_objLisApplMainOutVO,
            com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_APP_REPORT_VO[] p_objReportArr,
            com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_APP_SAMPLE_VO[] p_objAppSampleArr,
            com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_APP_CHECK_ITEM_VO[] p_objAppItemArr,
            com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_APP_APPLY_UNIT_VO[] p_objAppUnitArr,
            com.digitalwave.iCare.ValueObject.clsLisAppUnitItemVO[] p_objAppUnitItemArr)
        {
            p_objLisApplMainOutVO = p_objLisApplMainVO;
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngAddNewAppAndSampleInfo");
            if (lngRes < 0)
            {
                return -1;
            }
            if (p_objLisApplMainVO == null)
            {
                return -2;
            }

            try
            {
                lngRes = 0;
                lngRes = m_lngAddNewAppl(p_objPrincipal, p_objLisApplMainVO, out p_objLisApplMainOutVO);
                p_objLisApplMainVO = p_objLisApplMainOutVO;
                if (lngRes > 0)
                {
                    #region 赋申请单ID
                    for (int i = 0; i < p_objReportArr.Length; i++)
                    {
                        p_objReportArr[i].m_strAPPLICATION_ID_CHR = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    }
                    for (int i = 0; i < p_objAppSampleArr.Length; i++)
                    {
                        p_objAppSampleArr[i].m_strAPPLICATION_ID_CHR = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    }
                    for (int i = 0; i < p_objAppItemArr.Length; i++)
                    {
                        p_objAppItemArr[i].m_strAPPLICATION_ID_CHR = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    }
                    for (int i = 0; i < p_objAppUnitArr.Length; i++)
                    {
                        p_objAppUnitArr[i].m_strAPPLICATION_ID_CHR = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    }
                    for (int i = 0; i < p_objAppUnitItemArr.Length; i++)
                    {
                        p_objAppUnitItemArr[i].m_strAPPLICATION_ID_CHR = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    }
                    #endregion
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngInsertAppReportRecord(p_objPrincipal, p_objReportArr);
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngAddNewAppSampleGroup(p_objPrincipal, p_objAppSampleArr);
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngAddNewAppCheckItem(p_objPrincipal, p_objAppItemArr);
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngAddNewAppApplyUint(p_objPrincipal, p_objAppUnitArr);
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngAddNewAppUintItemArr(p_objPrincipal, p_objAppUnitItemArr);
                }
                if (lngRes > 0)
                {

                    com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_SAMPLE_VO objSampleVO = new clsT_OPR_LIS_SAMPLE_VO();

                    #region 构造SampleVO
                    objSampleVO.m_strAPPL_DAT = p_objLisApplMainVO.m_strAppl_Dat;
                    objSampleVO.m_strSEX_CHR = p_objLisApplMainVO.m_strSex;
                    objSampleVO.m_strPATIENT_NAME_VCHR = p_objLisApplMainVO.m_strPatient_Name;
                    objSampleVO.m_strPATIENT_SUBNO_CHR = p_objLisApplMainVO.m_strPatient_SubNO;
                    objSampleVO.m_strAGE_CHR = p_objLisApplMainVO.m_strAge;
                    objSampleVO.m_strPATIENT_TYPE_CHR = p_objLisApplMainVO.m_strPatientType;
                    objSampleVO.m_strDIAGNOSE_VCHR = p_objLisApplMainVO.m_strDiagnose;
                    objSampleVO.m_strBEDNO_CHR = p_objLisApplMainVO.m_strBedNO;
                    objSampleVO.m_strICD_VCHR = p_objLisApplMainVO.m_strICD;
                    objSampleVO.m_strPATIENTCARDID_CHR = p_objLisApplMainVO.m_strPatientcardID;
                    objSampleVO.m_strPATIENTID_CHR = p_objLisApplMainVO.m_strPatientID;
                    objSampleVO.m_strAPPL_EMPID_CHR = p_objLisApplMainVO.m_strAppl_EmpID;
                    objSampleVO.m_strAPPL_DEPTID_CHR = p_objLisApplMainVO.m_strAppl_DeptID;
                    objSampleVO.m_strAPPLICATION_ID_CHR = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    objSampleVO.m_strPATIENT_INHOSPITALNO_CHR = p_objLisApplMainVO.m_strPatient_inhospitalno_chr;
                    objSampleVO.m_strSAMPLE_TYPE_ID_CHR = p_objLisApplMainVO.m_strSampleTypeID;
                    objSampleVO.m_strSAMPLETYPE_VCHR = p_objLisApplMainVO.m_strSampleType;
                    objSampleVO.m_intSTATUS_INT = 3;
                    objSampleVO.m_strQCSAMPLEID_CHR = "-1";

                    objSampleVO.m_strSAMPLEKIND_CHR = "1";
                    objSampleVO.m_strSAMPLE_ID_CHR = null;

                    objSampleVO.m_strSAMPLESTATE_VCHR = "";

                    objSampleVO.m_strBARCODE_VCHR = null;

                    objSampleVO.m_strOPERATOR_ID_CHR = p_objLisApplMainVO.m_strOperator_ID;

                    objSampleVO.m_strSAMPLING_DATE_DAT = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    objSampleVO.m_strCOLLECTOR_ID_CHR = null;

                    objSampleVO.m_strACCEPTOR_ID_CHR = p_objLisApplMainVO.m_strOperator_ID;

                    objSampleVO.m_strACCEPT_DAT = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    #endregion

                    lngRes = 0;
                    lngRes = new clsSampleSvc().m_lngAddNewSampleAndModifyAppSampleGroup(p_objPrincipal,
                        objSampleVO.m_strAPPLICATION_ID_CHR, objSampleVO);
                    for (int i = 0; i < p_objAppSampleArr.Length; i++)
                    {
                        p_objAppSampleArr[i].m_strSAMPLE_ID_CHR = objSampleVO.m_strSAMPLE_ID_CHR;
                    }
                }
                if (lngRes <= 0)
                {
                    throw new Exception(null);
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                throw objEx;
            }

            return lngRes;
        }
        #endregion
        #region 增加-组新的检验申请信息(包含报告组,申请单元,样本组,检验项目,和样本在内的全部信息) 解决三层爆错的问题 加上了一个ref
        /// <summary>
        /// 增加-组新的检验申请信息(包含报告组,申请单元,样本组,检验项目,和样本在内的全部信息)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objLisApplMainVO"></param>
        /// <param name="p_objReportArr"></param>
        /// <param name="p_objAppSampleArr"></param>
        /// <param name="p_objAppItemArr"></param>
        /// <param name="p_objAppUnitArr"></param>
        /// <param name="p_objAppUnitItemArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewAppAndSampleInfoNew(System.Security.Principal.IPrincipal p_objPrincipal,
             com.digitalwave.iCare.ValueObject.clsLisApplMainVO p_objLisApplMainVO,
            out com.digitalwave.iCare.ValueObject.clsLisApplMainVO p_objLisApplMainOutVO,
            ref com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_APP_REPORT_VO[] p_objReportArr,
            ref com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_APP_SAMPLE_VO[] p_objAppSampleArr,
            ref com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_APP_CHECK_ITEM_VO[] p_objAppItemArr,
            ref com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_APP_APPLY_UNIT_VO[] p_objAppUnitArr,
            ref com.digitalwave.iCare.ValueObject.clsLisAppUnitItemVO[] p_objAppUnitItemArr)
        {
            p_objLisApplMainOutVO = p_objLisApplMainVO;
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngAddNewAppAndSampleInfo");
            if (lngRes < 0)
            {
                return -1;
            }
            if (p_objLisApplMainVO == null)
            {
                return -2;
            }

            try
            {
                lngRes = 0;
                lngRes = m_lngAddNewAppl(p_objPrincipal, p_objLisApplMainVO, out p_objLisApplMainOutVO);
                p_objLisApplMainVO = p_objLisApplMainOutVO;
                if (lngRes > 0)
                {
                    #region 赋申请单ID
                    for (int i = 0; i < p_objReportArr.Length; i++)
                    {
                        p_objReportArr[i].m_strAPPLICATION_ID_CHR = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    }
                    for (int i = 0; i < p_objAppSampleArr.Length; i++)
                    {
                        p_objAppSampleArr[i].m_strAPPLICATION_ID_CHR = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    }
                    for (int i = 0; i < p_objAppItemArr.Length; i++)
                    {
                        p_objAppItemArr[i].m_strAPPLICATION_ID_CHR = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    }
                    for (int i = 0; i < p_objAppUnitArr.Length; i++)
                    {
                        p_objAppUnitArr[i].m_strAPPLICATION_ID_CHR = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    }
                    for (int i = 0; i < p_objAppUnitItemArr.Length; i++)
                    {
                        p_objAppUnitItemArr[i].m_strAPPLICATION_ID_CHR = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    }
                    #endregion
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngInsertAppReportRecord(p_objPrincipal, p_objReportArr);
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngAddNewAppSampleGroup(p_objPrincipal, p_objAppSampleArr);
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngAddNewAppCheckItem(p_objPrincipal, p_objAppItemArr);
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngAddNewAppApplyUint(p_objPrincipal, p_objAppUnitArr);
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    lngRes = m_lngAddNewAppUintItemArr(p_objPrincipal, p_objAppUnitItemArr);
                }
                if (lngRes > 0)
                {

                    com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_SAMPLE_VO objSampleVO = new clsT_OPR_LIS_SAMPLE_VO();

                    #region 构造SampleVO
                    objSampleVO.m_strAPPL_DAT = p_objLisApplMainVO.m_strAppl_Dat;
                    objSampleVO.m_strSEX_CHR = p_objLisApplMainVO.m_strSex;
                    objSampleVO.m_strPATIENT_NAME_VCHR = p_objLisApplMainVO.m_strPatient_Name;
                    objSampleVO.m_strPATIENT_SUBNO_CHR = p_objLisApplMainVO.m_strPatient_SubNO;
                    objSampleVO.m_strAGE_CHR = p_objLisApplMainVO.m_strAge;
                    objSampleVO.m_strPATIENT_TYPE_CHR = p_objLisApplMainVO.m_strPatientType;
                    objSampleVO.m_strDIAGNOSE_VCHR = p_objLisApplMainVO.m_strDiagnose;
                    objSampleVO.m_strBEDNO_CHR = p_objLisApplMainVO.m_strBedNO;
                    objSampleVO.m_strICD_VCHR = p_objLisApplMainVO.m_strICD;
                    objSampleVO.m_strPATIENTCARDID_CHR = p_objLisApplMainVO.m_strPatientcardID;
                    objSampleVO.m_strPATIENTID_CHR = p_objLisApplMainVO.m_strPatientID;
                    objSampleVO.m_strAPPL_EMPID_CHR = p_objLisApplMainVO.m_strAppl_EmpID;
                    objSampleVO.m_strAPPL_DEPTID_CHR = p_objLisApplMainVO.m_strAppl_DeptID;
                    objSampleVO.m_strAPPLICATION_ID_CHR = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    objSampleVO.m_strPATIENT_INHOSPITALNO_CHR = p_objLisApplMainVO.m_strPatient_inhospitalno_chr;
                    objSampleVO.m_strSAMPLE_TYPE_ID_CHR = p_objLisApplMainVO.m_strSampleTypeID;
                    objSampleVO.m_strSAMPLETYPE_VCHR = p_objLisApplMainVO.m_strSampleType;
                    objSampleVO.m_intSTATUS_INT = 3;
                    objSampleVO.m_strQCSAMPLEID_CHR = "-1";

                    objSampleVO.m_strSAMPLEKIND_CHR = "1";
                    objSampleVO.m_strSAMPLE_ID_CHR = null;

                    objSampleVO.m_strSAMPLESTATE_VCHR = "";

                    objSampleVO.m_strBARCODE_VCHR = null;

                    objSampleVO.m_strOPERATOR_ID_CHR = p_objLisApplMainVO.m_strOperator_ID;

                    objSampleVO.m_strSAMPLING_DATE_DAT = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    objSampleVO.m_strCOLLECTOR_ID_CHR = null;

                    objSampleVO.m_strACCEPTOR_ID_CHR = p_objLisApplMainVO.m_strOperator_ID;

                    objSampleVO.m_strACCEPT_DAT = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    #endregion

                    lngRes = 0;
                    lngRes = new clsSampleSvc().m_lngAddNewSampleAndModifyAppSampleGroup(p_objPrincipal,
                        objSampleVO.m_strAPPLICATION_ID_CHR, objSampleVO);
                    for (int i = 0; i < p_objAppSampleArr.Length; i++)
                    {
                        p_objAppSampleArr[i].m_strSAMPLE_ID_CHR = objSampleVO.m_strSAMPLE_ID_CHR;
                    }
                    ////add by wjqin(07-4-28)
                    //p_objLisApplMainVO.m_strSampleID = objSampleVO.m_strSAMPLE_ID_CHR;
                    ///*<==================*/
                }
                if (lngRes <= 0)
                {
                    throw new Exception(null);
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                throw objEx;
            }

            return lngRes;
        }
        #endregion

        #region 修改-组检验申请信息(包含报告组,申请单元,样本组,检验项目在内的全部信息)
        /// <summary>
        /// 增加-组新的检验申请信息(包含报告组,申请单元,样本组,检验项目在内的全部信息)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objLisApplMainVO"></param>
        /// <param name="p_objReportArr"></param>
        /// <param name="p_objAppSampleArr"></param>
        /// <param name="p_objAppItemArr"></param>
        /// <param name="p_objAppUnitArr"></param>
        /// <param name="p_objAppUnitItemArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModifyAppInfo(System.Security.Principal.IPrincipal p_objPrincipal,
            com.digitalwave.iCare.ValueObject.clsLisApplMainVO p_objLisApplMainVO,
            com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_APP_REPORT_VO[] p_objReportArr,
            com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_APP_SAMPLE_VO[] p_objAppSampleArr,
            com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_APP_CHECK_ITEM_VO[] p_objAppItemArr,
            com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_APP_APPLY_UNIT_VO[] p_objAppUnitArr,
            com.digitalwave.iCare.ValueObject.clsLisAppUnitItemVO[] p_objAppUnitItemArr)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngModifyAppInfo");
            if (lngRes < 0)
            {
                return -1;
            }
            if (p_objLisApplMainVO == null)
                return -2;
            string strSQL = null;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                IDataParameter[] objDPArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_objLisApplMainVO.m_strAPPLICATION_ID;

                strSQL = "DELETE FROM t_opr_lis_app_unit_item  WHERE application_id_chr = ?";

                lngRes = 0;
                long lngEff = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                if (lngRes > 0)
                {
                    IDataParameter[] objDPArr1 = null;
                    objHRPSvc.CreateDatabaseParameter(1, out objDPArr1);
                    objDPArr1[0].Value = p_objLisApplMainVO.m_strAPPLICATION_ID;

                    strSQL = "DELETE FROM t_opr_lis_app_check_item  WHERE application_id_chr = ?";

                    lngRes = 0;
                    lngEff = 0;
                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr1);

                }
                if (lngRes > 0)
                {
                    IDataParameter[] objDPArr2 = null;
                    objHRPSvc.CreateDatabaseParameter(1, out objDPArr2);
                    objDPArr2[0].Value = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    strSQL = "DELETE FROM t_opr_lis_app_sample  WHERE application_id_chr = ?";

                    lngRes = 0;
                    lngEff = 0;
                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr2);

                }
                if (lngRes > 0)
                {
                    IDataParameter[] objDPArr3 = null;
                    objHRPSvc.CreateDatabaseParameter(1, out objDPArr3);
                    objDPArr3[0].Value = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    strSQL = "DELETE FROM t_opr_lis_app_report  WHERE application_id_chr = ?";

                    lngRes = 0;
                    lngEff = 0;
                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr3);
                    objHRPSvc.Dispose();
                }
                if (lngRes > 0)
                {
                    IDataParameter[] objDPArr4 = null;
                    objHRPSvc.CreateDatabaseParameter(1, out objDPArr4);
                    objDPArr4[0].Value = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    strSQL = "DELETE FROM t_opr_lis_app_apply_unit WHERE application_id_chr = ?";

                    lngRes = 0;
                    lngEff = 0;
                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr4);
                    objHRPSvc.Dispose();
                }
                if (lngRes > 0)
                {
                    lngRes = 0;
                    com.digitalwave.iCare.ValueObject.clsLisApplMainVO objLisApplMainVO;
                    lngRes = m_lngAddNewAppInfo(p_objPrincipal, p_objLisApplMainVO, out objLisApplMainVO, p_objReportArr, p_objAppSampleArr, p_objAppItemArr, p_objAppUnitArr, p_objAppUnitItemArr);
                }

                if (lngRes <= 0)
                {
                    throw new Exception("修改申请信息失败.");
                }

            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                throw objEx;
            }
            return lngRes;
        }
        #endregion

        #region 确认报告

        /// <summary>
        /// 确认报告,同时确定样本
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strAppID"></param>
        /// <param name="p_strReportID"></param>
        /// <param name="p_strConfirmerID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngConfirmAppReport(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strAppID, string p_strReportID, string p_strConfirmerID, string p_strConfirmDate)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngInsertAppReportRecord");
            if (lngRes < 0)
            {
                return -1;
            }

            DateTime dtmConfirmDate;
            string strDateTimeNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime dtmNow = DateTime.Parse(strDateTimeNow);
            if (Microsoft.VisualBasic.Information.IsDate(p_strConfirmDate))
            {
                dtmConfirmDate = DateTime.Parse(p_strConfirmDate);
            }
            else
            {
                dtmConfirmDate = dtmNow;
            }
            string strSQL = @"UPDATE t_opr_lis_app_report
								SET status_int = 2, 
									confirm_dat = ?,
									confirmer_id_chr = ?
								WHERE application_id_chr = ? 
								AND report_group_id_chr = ? 
								AND status_int = 1";
            string strSQL1 = @"UPDATE t_opr_lis_sample
								SET status_int = 6, 
									confirm_dat = ?,
									confirmer_id_chr = ?
								WHERE sample_id_chr = ? 
								AND status_int > 0 
								AND status_int < 6";
            string strSQL2 = @"UPDATE t_opr_lis_device_relation
								SET status_int = 0
								WHERE sample_id_chr IN (SELECT DISTINCT sample_id_chr
																	FROM t_opr_lis_app_sample
																WHERE application_id_chr = ?)
									AND status_int = 1";

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            try
            {
                IDataParameter[] objDPArr = null;
                objHRPSvc.CreateDatabaseParameter(4, out objDPArr);
                objDPArr[0].Value = dtmNow;
                objDPArr[1].Value = p_strConfirmerID;
                objDPArr[2].Value = p_strAppID;
                objDPArr[3].Value = p_strReportID;

                lngRes = 0;
                long lngEff = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);

                if (lngRes > 0 && lngEff > 0)
                {
                    clsT_OPR_LIS_APP_SAMPLE_VO[] objAppSampleArr = null;
                    lngRes = 0;
                    lngRes = m_lngGetAppSampleGroupVOArr(p_objPrincipal, p_strAppID, p_strReportID, out objAppSampleArr);
                    if (lngRes > 0 && objAppSampleArr != null)
                    {
                        for (int i = 0; i < objAppSampleArr.Length; i++)
                        {
                            IDataParameter[] objDPArr1 = null;
                            objHRPSvc.CreateDatabaseParameter(3, out objDPArr1);
                            objDPArr1[0].Value = dtmNow;
                            objDPArr1[1].Value = p_strConfirmerID;
                            objDPArr1[2].Value = objAppSampleArr[i].m_strSAMPLE_ID_CHR == null ? null : objAppSampleArr[i].m_strSAMPLE_ID_CHR.Trim();
                            lngRes = 0;
                            lngEff = 0;
                            lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL1, ref lngEff, objDPArr1);
                            if (lngRes <= 0)
                            {
                                break;
                            }
                        }
                    }
                }
                if (lngRes == 1)
                {
                    IDataParameter[] objDPArr2 = null;
                    objHRPSvc.CreateDatabaseParameter(1, out objDPArr2);
                    objDPArr2[0].Value = p_strAppID;

                    lngRes = 0;
                    lngEff = 0;
                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL2, ref lngEff, objDPArr2);
                }

                objHRPSvc.Dispose();
                if (lngRes <= 0)
                {
                    throw new Exception("确认报告失败!");
                }
            }
            catch (Exception objEx)
            {
                objHRPSvc.Dispose();
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 更新SampleID 到 AppSampleGroup

        /// <summary>
        /// 更新SampleID 到 AppSampleGroup 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strAppID"></param>
        /// <param name="p_strSampleID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdateAppSampleGroupSampleID(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strAppID, string p_strSampleID)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngUpdateAppSampleGroupSampleID");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"UPDATE t_opr_lis_app_sample 
								SET sample_id_chr = ? 
								WHERE application_id_chr = ? 
								";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strSampleID;
                objDPArr[1].Value = p_strAppID;

                lngRes = 0;
                long lngEff = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
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



        //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx






        //        #region 根据申请日期查询所有已发送的检验申请单信息 
        //        [AutoComplete]
        //        public long m_lngGetAllSendApplInfoByApplDat(System.Security.Principal.IPrincipal p_objPrincipal, string strFromDat, string strToDat, out DataTable dtbAppInfo)
        //        {
        //            long lngRes = 0;
        //            string strSQL = @"SELECT t1.application_id_chr, t1.patientid_chr, t1.application_dat,
        //                                   t1.sex_chr, t1.patient_name_vchr, t1.patient_subno_chr, t1.age_chr,
        //                                   t1.patient_type_id_chr, t1.diagnose_vchr, t1.bedno_chr, t1.icdcode_chr,
        //                                   t1.patientcardid_chr, t1.application_form_no_chr, t1.modify_dat,
        //                                   t1.operator_id_chr, t1.appl_empid_chr, t1.appl_deptid_chr,
        //                                   t1.summary_vchr, t1.pstatus_int, t1.emergency_int, t1.special_int,
        //                                   t1.form_int, t1.patient_inhospitalno_chr, t1.sample_type_id_chr,
        //                                   t1.check_content_vchr, t1.sample_type_vchr, t1.oringin_dat,
        //                                   t1.charge_info_vchr, t1.printed_num, t1.orderunitrelation_vchr,
        //                                   t1.printed_date, 
        //                                     t3.lastname_vchr operatorname,
        //									 t4.deptname_vchr, t5.lastname_vchr empname, t6.icdname_vchr,
        //									 t7.dictname_vchr pattype
        //								FROM t_opr_lis_application t1,
        //									 t_bse_employee t3,
        //									 t_bse_deptbaseinfo t4,
        //									 t_bse_employee t5,
        //									 t_aid_icd10 t6,
        //									 t_aid_dict t7
        //							   WHERE t1.operator_id_chr = t3.empid_chr(+)
        //								 AND t1.appl_deptid_chr = t4.deptid_chr(+)
        //								 AND t1.appl_empid_chr = t5.empid_chr(+)
        //								 AND t1.icdcode_chr = t6.icdcode_chr(+)
        //								 AND t1.patient_type_id_chr = t7.dictid_chr(+)
        //								 AND t7.dictkind_chr(+) = '61'
        //								 AND t1.pstatus_int = 2
        //								 AND t1.application_dat BETWEEN TO_DATE ('" + strFromDat + @"', 'yyyy-mm-dd hh24:mi:ss') AND TO_DATE ('" + strToDat + @"', 'yyyy-mm-dd hh24:mi:ss')";
        //            dtbAppInfo = null;
        //            try
        //            {
        //                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
        //                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbAppInfo);
        //                objHRPSvc.Dispose();
        //            }
        //            catch (Exception objEx)
        //            {
        //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //                bool blnRes = objLogger.LogError(objEx);
        //            }
        //            return lngRes;
        //        }
        //        #endregion

        //        #region 根据申请日期查询所有具有未采集的标本的检验申请信息 
        //        [AutoComplete]
        //        public long m_lngGetAllNoCollectSampleByApplDat(System.Security.Principal.IPrincipal p_objPrincipal, string strFromDat, string strToDat, out DataTable dtbAppInfo)
        //        {
        //            long lngRes = 0;
        //            string strSQL = @"SELECT t1.application_id_chr, t1.patientid_chr, t1.application_dat,
        //                                   t1.sex_chr, t1.patient_name_vchr, t1.patient_subno_chr, t1.age_chr,
        //                                   t1.patient_type_id_chr, t1.diagnose_vchr, t1.bedno_chr, t1.icdcode_chr,
        //                                   t1.patientcardid_chr, t1.application_form_no_chr, t1.modify_dat,
        //                                   t1.operator_id_chr, t1.appl_empid_chr, t1.appl_deptid_chr,
        //                                   t1.summary_vchr, t1.pstatus_int, t1.emergency_int, t1.special_int,
        //                                   t1.form_int, t1.patient_inhospitalno_chr, t1.sample_type_id_chr,
        //                                   t1.check_content_vchr, t1.sample_type_vchr, t1.oringin_dat,
        //                                   t1.charge_info_vchr, t1.printed_num, t1.orderunitrelation_vchr,
        //                                   t1.printed_date, 
        //                                     t3.lastname_vchr operatorname,
        //									 t4.deptname_vchr, t5.lastname_vchr empname, t6.icdname_vchr,
        //									 t7.dictname_vchr pattype,0 collected_int
        //								FROM t_opr_lis_application t1,
        //									 t_bse_employee t3,
        //									 t_bse_deptbaseinfo t4,
        //									 t_bse_employee t5,
        //									 t_aid_icd10 t6,
        //									 t_aid_dict t7
        //							   WHERE t1.operator_id_chr = t3.empid_chr(+)
        //								 AND t1.appl_deptid_chr = t4.deptid_chr(+)
        //								 AND t1.appl_empid_chr = t5.empid_chr(+)
        //								 AND t1.icdcode_chr = t6.icdcode_chr(+)
        //								 AND t1.patient_type_id_chr = t7.dictid_chr(+)
        //								 AND t7.dictkind_chr(+) = '61'
        //								 AND t1.pstatus_int = 2
        //								 AND t1.application_dat BETWEEN TO_DATE ('" + strFromDat + @"', 'yyyy-mm-dd hh24:mi:ss') AND TO_DATE ('" + strToDat + @"', 'yyyy-mm-dd hh24:mi:ss')
        //								 AND t1.application_id_chr IN (SELECT application_id_chr
        //																FROM t_opr_lis_app_sample
        //																WHERE sample_id_chr IS NULL)";
        //            dtbAppInfo = null;
        //            try
        //            {
        //                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
        //                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbAppInfo);
        //                objHRPSvc.Dispose();
        //            }
        //            catch (Exception objEx)
        //            {
        //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //                bool blnRes = objLogger.LogError(objEx);
        //            }
        //            return lngRes;
        //        }
        //        #endregion

        //        #region 根据申请日期查询所有已采集的检验申请信息 
        //        [AutoComplete]
        //        public long m_lngGetAllCollectedApplInfoByApplDat(System.Security.Principal.IPrincipal p_objPrincipal, string strFromDat, string strToDat, out DataTable dtbAppInfo)
        //        {
        //            long lngRes = 0;
        //            string strSQL = @"SELECT t1.application_id_chr, t1.patientid_chr, t1.application_dat,
        //                                   t1.sex_chr, t1.patient_name_vchr, t1.patient_subno_chr, t1.age_chr,
        //                                   t1.patient_type_id_chr, t1.diagnose_vchr, t1.bedno_chr, t1.icdcode_chr,
        //                                   t1.patientcardid_chr, t1.application_form_no_chr, t1.modify_dat,
        //                                   t1.operator_id_chr, t1.appl_empid_chr, t1.appl_deptid_chr,
        //                                   t1.summary_vchr, t1.pstatus_int, t1.emergency_int, t1.special_int,
        //                                   t1.form_int, t1.patient_inhospitalno_chr, t1.sample_type_id_chr,
        //                                   t1.check_content_vchr, t1.sample_type_vchr, t1.oringin_dat,
        //                                   t1.charge_info_vchr, t1.printed_num, t1.orderunitrelation_vchr,
        //                                   t1.printed_date, 
        //                                     t3.lastname_vchr operatorname,
        //									 t4.deptname_vchr, t5.lastname_vchr empname, t6.icdname_vchr,
        //									 t7.dictname_vchr pattype,1 collected_int
        //								FROM t_opr_lis_application t1,
        //									 t_bse_employee t3,
        //									 t_bse_deptbaseinfo t4,
        //									 t_bse_employee t5,
        //									 t_aid_icd10 t6,
        //									 t_aid_dict t7
        //							   WHERE t1.operator_id_chr = t3.empid_chr(+)
        //								 AND t1.appl_deptid_chr = t4.deptid_chr(+)
        //								 AND t1.appl_empid_chr = t5.empid_chr(+)
        //								 AND t1.icdcode_chr = t6.icdcode_chr(+)
        //								 AND t1.patient_type_id_chr = t7.dictid_chr(+)
        //								 AND t7.dictkind_chr(+) = '61'
        //								 AND t1.pstatus_int = 2
        //								 AND t1.application_dat BETWEEN TO_DATE ('" + strFromDat + @"', 'yyyy-mm-dd hh24:mi:ss') AND TO_DATE ('" + strToDat + @"', 'yyyy-mm-dd hh24:mi:ss')
        //								 AND t1.application_id_chr NOT IN (SELECT application_id_chr
        //																	FROM t_opr_lis_app_sample
        //																	WHERE sample_id_chr IS NULL)";
        //            dtbAppInfo = null;
        //            try
        //            {
        //                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
        //                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbAppInfo);
        //                objHRPSvc.Dispose();
        //            }
        //            catch (Exception objEx)
        //            {
        //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //                bool blnRes = objLogger.LogError(objEx);
        //            }
        //            return lngRes;
        //        }
        //        #endregion


        #region SQL语句



        private const string c_strAddNewApplDetail_SQL = @"INSERT INTO t_opr_lis_application_detail(APPLICATION_ID_CHR, 
                                         SEQ_INT, 
                                         MODIFY_DAT, 
                                         groupid_chr, 
                                         Summary_Vchr,STATUS_INT)
										VALUES(?,?,?,?,?,?)		
										";

        private const string c_strQueryAppl_SQL = @"SELECT a.application_id_chr, a.patientid_chr, a.application_dat, a.sex_chr,
												a.patient_name_vchr, a.patient_subno_chr, a.age_chr,
												a.patient_type_id_chr, a.diagnose_vchr, a.bedno_chr, a.icdcode_chr,
												a.patientcardid_chr, a.application_form_no_chr, a.modify_dat,
												a.operator_id_chr, a.appl_empid_chr, a.appl_deptid_chr, a.summary_vchr,
												a.pstatus_int, b.lastname_vchr operatorname, c.deptname_vchr,
												d.lastname_vchr empname, e.icdname_vchr, f.dictname_vchr patType
												FROM t_opr_lis_application a,
													t_bse_employee b,
													t_bse_deptbaseinfo c,
													t_bse_employee d,
													t_aid_icd10 e,
													t_aid_dict f
												WHERE a.operator_id_chr = b.empid_chr(+)
												AND a.appl_deptid_chr = c.deptid_chr(+)
												AND a.appl_empid_chr = d.empid_chr(+)
												AND a.icdcode_chr = e.icdcode_chr(+)
												AND a.patient_type_id_chr = f.dictid_chr(+)
												AND f.dictkind_chr(+) = '61'";//61代表病人类型

        private const string c_strQueryApplDetail_SQL = @"SELECT application_id_chr, seq_int, modify_dat, groupid_chr, summary_vchr,
														status_int
													FROM t_opr_lis_application_detail";

        #endregion

        //        #region 根据申请单号查询(已审核=3、未审核<3和全部>0)申请单信息 
        //        [AutoComplete]
        //        public long m_lngQryApplInfoByFormNo(System.Security.Principal.IPrincipal p_objPrincipal, string p_strApplFormNo, string strPstatus, out System.Data.DataTable p_dtbAppl)
        //        {
        //            long lngRes = 0;
        //            p_dtbAppl = null;
        //            string strSQL = @"SELECT application_id_chr, modify_dat, patientid_chr, application_dat,
        //									 sex_chr, patient_name_vchr, patient_subno_chr, age_chr,
        //								   	 patient_type_id_chr, diagnose_vchr, bedno_chr, icdcode_chr,
        //									 patientcardid_chr, application_form_no_chr, operator_id_chr,
        //									 appl_empid_chr, appl_deptid_chr, summary_vchr, pstatus_int, 
        //									 EMERGENCY_INT, SPECIAL_INT
        //								FROM t_opr_lis_application
        //							   WHERE pstatus_int > 0
        //								 AND application_form_no_chr = '" + p_strApplFormNo + @"'
        //								 AND pstatus_int " + strPstatus;
        //            try
        //            {
        //                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
        //                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbAppl);
        //                objHRPSvc.Dispose();
        //            }
        //            catch (Exception objEx)
        //            {
        //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。
        //            }
        //            return lngRes;
        //        }
        //        #endregion

        //        #region 根据诊疗卡号查询检验申请信息
        //        [AutoComplete]
        //        public long m_lngApplInfoByPatientCardID(System.Security.Principal.IPrincipal p_objPrincipal, string strPatientCardID, out DataTable dtbAppInfo)
        //        {
        //            long lngRes = 0;
        //            string strSQL = @"SELECT t1.application_id_chr, t1.patientid_chr, t1.application_dat,
        //									 t1.sex_chr, t1.patient_name_vchr, t1.patient_subno_chr, t1.age_chr,
        //									 t1.patient_type_id_chr, t1.diagnose_vchr, t1.bedno_chr, t1.icdcode_chr,
        //									 t1.patientcardid_chr, t1.application_form_no_chr, t1.modify_dat,
        //									 t1.operator_id_chr, t1.appl_empid_chr, t1.appl_deptid_chr,
        //									 t1.summary_vchr, t1.pstatus_int, t3.lastname_vchr operatorname,
        //									 t4.deptname_vchr, t5.lastname_vchr empname, t6.icdname_vchr,
        //									 t7.dictname_vchr pattype
        //								FROM t_opr_lis_application t1,
        //									 t_opr_lis_application_detail t2,
        //									 t_bse_employee t3,
        //									 t_bse_deptbaseinfo t4,
        //									 t_bse_employee t5,
        //									 t_aid_icd10 t6,
        //									 t_aid_dict t7
        //							   WHERE t1.operator_id_chr = t3.empid_chr(+)
        //								 AND t1.appl_deptid_chr = t4.deptid_chr(+)
        //								 AND t1.appl_empid_chr = t5.empid_chr(+)
        //								 AND t1.icdcode_chr = t6.icdcode_chr(+)
        //								 AND t1.patient_type_id_chr = t7.dictid_chr(+)
        //								 AND t7.dictkind_chr(+) = '61'
        //								 AND t1.application_id_chr = t2.application_id_chr
        //								 AND t1.pstatus_int > 0
        //								 AND t1.patientid_chr=(select patientid_chr from t_bse_patientcard where patientcardid_chr='" + strPatientCardID + "')";
        //            dtbAppInfo = null;
        //            try
        //            {
        //                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
        //                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbAppInfo);
        //                objHRPSvc.Dispose();
        //            }
        //            catch (Exception objEx)
        //            {
        //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //                bool blnRes = objLogger.LogError(objEx);
        //            }
        //            return lngRes;
        //        }
        //        #endregion



        #region 根据Application_ID_CHR更新t_opr_lis_application_detail的状态字为
        [AutoComplete]
        public long m_lngSetStatusToConfirmByApplicationIDAndGroupID(System.Security.Principal.IPrincipal p_objPrincipal, string strGroupID, string strApplID, string strStatus)
        {
            long lngRes = 0;
            string strSQL = @"UPDATE t_opr_lis_application_detail SET STATUS_INT = '" + strStatus + "' WHERE GROUPID_CHR = '" + strGroupID + "' AND APPLICATION_ID_CHR = '" + strApplID + "' AND STATUS_INT > 0";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        //        #region 根据Application_Form_No查询表t_opr_lis_application_detail所有属于该申请单的大组
        //        [AutoComplete]
        //        public long m_lngGetCheckGroupByApplicationFormNo(System.Security.Principal.IPrincipal p_objPrincipal, string strApplFormNo, out DataTable dtbCheckGroup)
        //        {
        //            long lngRes = 0;
        //            string strSQL = @"SELECT t1.groupid_chr, t2.groupname_vchr, t1.application_id_chr,
        //									 t1.status_int, t1.summary_vchr, t2.PRINT_CATEGORY_ID_CHR
        //								FROM t_opr_lis_application_detail t1,
        //									 t_aid_lis_check_group t2,
        //									 t_opr_lis_application t3
        //							   WHERE t1.groupid_chr = t2.groupid_chr
        //								 AND t1.status_int > 0
        //								 AND t1.modify_dat = t3.modify_dat
        //								 AND t1.application_id_chr = t3.application_id_chr
        //								 AND t3.application_form_no_chr = '" + strApplFormNo + @"'
        //								 AND t3.pstatus_int > 0";
        //            dtbCheckGroup = null;
        //            try
        //            {
        //                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
        //                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbCheckGroup);
        //                objHRPSvc.Dispose();
        //            }
        //            catch (Exception objEx)
        //            {
        //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //                bool blnRes = objLogger.LogError(objEx);
        //            }
        //            return lngRes;
        //        }
        //        #endregion

        #region 新增记录组合与样本的关系的记录
        [AutoComplete]
        public long m_lngAddGroupSampleRelation(System.Security.Principal.IPrincipal p_objPrincipal, string strApplForm, string strSampleID, string strGroupID)
        {
            long lngRes = 0;
            string strSQL = @"INSERT INTO T_OPR_LIS_APPLGRPSMP(APPLICATION_FORM_NO_CHR,SAMPLE_ID_CHR,GROUPID_CHR) VALUES('" + strApplForm + "','" + strSampleID + "','" + strGroupID + "')";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 根据application_id和group_id更新t_opr_lis_application_detail表的检验师意见
        [AutoComplete]
        public long m_lngSetSummaryByApplicationIDAndGroupID(System.Security.Principal.IPrincipal p_objPrincipal, string strSummary, string strApplID, string strGroupID)
        {
            long lngRes = 0;
            string strSQL = @"UPDATE t_opr_lis_application_detail SET SUMMARY_VCHR = '" + strSummary + "' WHERE APPLICATION_ID_CHR = '" + strApplID + "' AND GROUPID_CHR = '" + strGroupID + "'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        //        #region 根据申请单号查询检验组信息(含子组) 
        //        [AutoComplete]
        //        public long m_lngGetCheckGroupByApplFormNo(System.Security.Principal.IPrincipal p_objPrincipal, string strApplFormNo, out DataTable dtbCheckGroup)
        //        {
        //            long lngRes = 0;
        //            string strSQL = @"SELECT t1.sample_id_chr, t2.groupname_vchr, t1.groupid_chr
        //								FROM t_opr_lis_req_check t1, t_aid_lis_check_group t2
        //								WHERE t1.groupid_chr = t2.groupid_chr
        //								AND sample_id_chr IN (SELECT sample_id_chr
        //															 FROM t_opr_lis_sample WHERE application_form_no_chr = '" + strApplFormNo + "')";
        //            dtbCheckGroup = null;
        //            try
        //            {
        //                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbCheckGroup);
        //                objHRPSvc.Dispose();
        //            }
        //            catch (Exception objEx)
        //            {
        //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //                bool blnRes = objLogger.LogError(objEx);
        //            }
        //            return lngRes;
        //        }
        //        #endregion


        #region 更新申请单信息，需要insert两个表，一个为t_opr_lis_application,一个为t_opr_lis_application_detail
        [AutoComplete]
        public long m_lngUpdateAppl(System.Security.Principal.IPrincipal p_objPrincipal, clsLisApplMainVO p_objLisApplMainVO)
        {
            long lngRes = 0;
            try
            {
                System.Data.IDataParameter[] objLisApplArr = null;
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(21, out objLisApplArr);

                DateTime CurTime = DateTime.Now;

                objLisApplArr[0].Value = p_objLisApplMainVO.m_strAPPLICATION_ID;
                objLisApplArr[1].Value = CurTime;
                objLisApplArr[2].Value = p_objLisApplMainVO.m_strPatientID;
                objLisApplArr[3].Value = System.DateTime.Parse(p_objLisApplMainVO.m_strAppl_Dat);
                objLisApplArr[4].Value = p_objLisApplMainVO.m_strSex;
                objLisApplArr[5].Value = p_objLisApplMainVO.m_strPatient_Name;
                objLisApplArr[6].Value = p_objLisApplMainVO.m_strPatient_SubNO;
                objLisApplArr[7].Value = p_objLisApplMainVO.m_strAge;
                objLisApplArr[8].Value = p_objLisApplMainVO.m_strPatientType;
                objLisApplArr[9].Value = p_objLisApplMainVO.m_strDiagnose;
                objLisApplArr[10].Value = p_objLisApplMainVO.m_strBedNO;
                objLisApplArr[11].Value = p_objLisApplMainVO.m_strICD;
                objLisApplArr[12].Value = p_objLisApplMainVO.m_strPatientcardID;

                //如果没有输入检验编号,检验编号等于Appplication_ID		
                if (p_objLisApplMainVO.m_strApplication_Form_NO == "" || p_objLisApplMainVO.m_strApplication_Form_NO == null)
                {
                    p_objLisApplMainVO.m_strApplication_Form_NO = p_objLisApplMainVO.m_strAPPLICATION_ID;
                    objLisApplArr[13].Value = p_objLisApplMainVO.m_strAPPLICATION_ID;
                }
                else
                    objLisApplArr[13].Value = p_objLisApplMainVO.m_strApplication_Form_NO;

                objLisApplArr[14].Value = p_objLisApplMainVO.m_strOperator_ID;
                objLisApplArr[15].Value = p_objLisApplMainVO.m_strAppl_EmpID;
                objLisApplArr[16].Value = p_objLisApplMainVO.m_strAppl_DeptID;
                objLisApplArr[17].Value = p_objLisApplMainVO.m_strSummary = null;
                objLisApplArr[18].Value = p_objLisApplMainVO.m_intPStatus_int;
                objLisApplArr[19].Value = p_objLisApplMainVO.m_intEmergency;
                objLisApplArr[20].Value = p_objLisApplMainVO.m_intSpecial;


                long lngRecEff = -1;

                //往表t_opr_lis_application增加记录
                lngRes = objHRPSvc.lngExecuteParameterSQL(c_strAddNewAppl_SQL, ref lngRecEff, objLisApplArr);
                objHRPSvc.Dispose();

                if (lngRes > 0)
                {
                    //					if(p_objLisApplMainVO.m_arlLisApplDetail!=null && p_objLisApplMainVO.m_arlLisApplDetail.Count>0)
                    //					{
                    //						for(int i=0;i<p_objLisApplMainVO.m_arlLisApplDetail.Count;i++)
                    //						{
                    //							System.Data.IDataParameter[] objLisAppDetailArr=null;		
                    //							objHRPSvc.CreateDatabaseParameter(6,out objLisAppDetailArr);
                    //
                    //							objLisAppDetailArr[0].Value=p_objLisApplMainVO.m_strAPPLICATION_ID;
                    //							clsLisApplDetailVO objAppDetailVO=(clsLisApplDetailVO)p_objLisApplMainVO.m_arlLisApplDetail[i];
                    //							objAppDetailVO.m_intSeq_Int=objHRPSvc.intGetNewNumericID("SEQ_INT","t_opr_lis_application_detail");
                    //							objLisAppDetailArr[1].Value=objAppDetailVO.m_intSeq_Int;
                    //							objLisAppDetailArr[2].Value=CurTime;
                    //							objLisAppDetailArr[3].Value=objAppDetailVO.m_strGroupID;
                    //							objLisAppDetailArr[4].Value=objAppDetailVO.m_strSummary;					
                    //							objLisAppDetailArr[5].Value=p_objLisApplMainVO.m_intPStatus_int;
                    //
                    //							//往表t_opr_lis_application_detail增加记录
                    //							lngRes=objHRPSvc.lngExecuteParameterSQL(c_strAddNewApplDetail_SQL,ref lngRecEff,objLisAppDetailArr);
                    //
                    //						}
                    //					}
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                throw objEx;
            }
            return lngRes;

        }
        #endregion

        #region 在增加新的申请单时，判断t_opr_lis_application中的application_form_no_chr在所有PStatus_int>0的记录中是否唯一
        [AutoComplete]
        public long m_lngQueryApplFormNo(System.Security.Principal.IPrincipal p_objPrincipal, string p_strApplFormNo)
        {
            long lngRes = 0;
            string strSQL = @"select application_form_no_chr from t_opr_lis_application where PStatus_int>0 and application_form_no_chr='" + p_strApplFormNo + @"'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);
                objHRPSvc.Dispose();

            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        //#region 按照某一字段，模糊查询表t_opr_lis_application，也可比较查询,可自定义按那个字段排序，是倒序还是顺序  
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="p_objPrincipal"></param>
        ///// <param name="p_intQueryType">查询方法:0-模糊查询 1-比较查询,查询字段为字符型 2-比较查询,查询字段为时间型</param>
        ///// <param name="p_strFussField">查询字段</param>
        ///// <param name="p_strCompare">比较测试条件</param>
        ///// <param name="p_strFussValue">查询字段的值</param>
        ///// <param name="p_strOrderByField">排序字段</param>
        ///// <param name="p_blnDesc">true-DESC;false-ASC</param></param>
        ///// <param name="p_objLisApplVOList"></param>
        ///// <returns></returns>
        //[AutoComplete]
        //public long m_lngGetApplByQuery(System.Security.Principal.IPrincipal p_objPrincipal, int p_intQueryType, string p_strField, string p_strCompare, string p_strFieldValue, string p_strOrderByField, bool p_blnDesc, out System.Data.DataTable p_dtbAppl)
        //{
        //    string strSQL = "";
        //    p_dtbAppl = null;
        //    if (p_intQueryType == 0)
        //        strSQL = c_strQueryAppl_SQL + " and a." + p_strField + " LIKE '" + p_strFieldValue + "%' ORDER BY a." + p_strOrderByField;
        //    else if (p_intQueryType == 1)
        //        strSQL = c_strQueryAppl_SQL + " and a." + p_strField + p_strCompare + p_strFieldValue + " ORDER BY a." + p_strOrderByField;
        //    else if (p_intQueryType == 2)
        //        strSQL = c_strQueryAppl_SQL + " and a." + p_strField + p_strCompare + "to_date('" + p_strFieldValue + "','yyyy-mm-dd')" + " ORDER BY a." + p_strOrderByField;

        //    if (p_blnDesc)
        //    { strSQL = strSQL + " DESC"; }

        //    long lngRes = 0;
        //    try
        //    {
        //        com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //        lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbAppl);
        //        objHRPSvc.Dispose();
        //    }
        //    catch (Exception objEx)
        //    {
        //        string strTmp = objEx.Message;
        //        com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //        bool blnRes = objLogger.LogError(objEx);
        //    }
        //    return lngRes;
        //}
        //#endregion

        //#region 根据ApplicationID查询t_opr_lis_application_detail 
        //[AutoComplete]
        //public long m_lngGetApplDetailByApplID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strApplID, out System.Data.DataTable p_dtbApplDetail)
        //{
        //    p_dtbApplDetail = null;
        //    string strSQL = c_strQueryApplDetail_SQL + " where application_id_chr='" + p_strApplID + "' and status_int>0";
        //    long lngRes = 0;
        //    try
        //    {
        //        com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //        lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbApplDetail);

        //        objHRPSvc.Dispose();
        //    }
        //    catch (Exception objEx)
        //    {
        //        com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //        bool blnRes = objLogger.LogError(objEx);
        //    }
        //    return lngRes;
        //}
        //#endregion

        //        #region 根据病人的诊疗卡号，查询出所有的未完成的检验申请。这里有一个样本采集的过滤条件。
        //        [AutoComplete]
        //        //这里，过滤条件strFilter表示PStatus_int字段的条件。如"=1"，或者">1"，"in (1,2,3)"等。
        //        public long m_lngGetApplicationInfoByPtCard(System.Security.Principal.IPrincipal p_objPrincipal, string strFromDate, string strToDate,
        //            string strPtCardId, string strFilter, out System.Data.DataTable dtbAppInfo)
        //        {
        //            long lngRes = 0;
        //            string strPtCond = (strPtCardId == "") ? "1=1" : @"a.patientid_chr=(select patientid_chr from t_bse_patientcard where patientcardid_chr='" + strPtCardId + "')";
        //            string strSQL = @"SELECT a.application_id_chr, a.patientid_chr, a.application_dat, a.sex_chr,
        //												a.patient_name_vchr, a.patient_subno_chr, a.age_chr,
        //												a.patient_type_id_chr, a.diagnose_vchr, a.bedno_chr, a.icdcode_chr,
        //												a.patientcardid_chr, a.application_form_no_chr, a.modify_dat,
        //												a.operator_id_chr, a.appl_empid_chr, a.appl_deptid_chr, a.summary_vchr,
        //												a.pstatus_int, b.lastname_vchr operatorname, c.deptname_vchr,
        //												d.lastname_vchr empname, e.icdname_vchr, f.dictname_vchr patType
        //												FROM t_opr_lis_application a,
        //													t_bse_employee b,
        //													t_bse_deptbaseinfo c,
        //													t_bse_employee d,
        //													t_aid_icd10 e,
        //													t_aid_dict f
        //												WHERE a.operator_id_chr = b.empid_chr(+)
        //												AND a.appl_deptid_chr = c.deptid_chr(+)
        //												AND a.appl_empid_chr = d.empid_chr(+)
        //												AND a.icdcode_chr = e.icdcode_chr(+)
        //												AND a.patient_type_id_chr = f.dictid_chr(+)
        //												AND f.dictkind_chr(+) = '61'
        //												AND a.application_dat BETWEEN TO_DATE('" + strFromDate + "','yyyy-mm-dd hh24:mi:ss') AND TO_DATE('" + strToDate
        //                + "','yyyy-mm-dd hh24:mi:ss') AND " + strPtCond
        //                + " AND a.pstatus_int" + strFilter;
        //            dtbAppInfo = null;
        //            try
        //            {
        //                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbAppInfo);
        //                objHRPSvc.Dispose();
        //            }
        //            catch (System.Exception objEx)
        //            {
        //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。
        //            }
        //            return lngRes;
        //        }
        //        #endregion

        //#region 根据申请号，获得所有的检查组。
        //[AutoComplete]
        //public long m_lngGetApplicationContent(System.Security.Principal.IPrincipal p_objPrincipal,
        //    string strAppId, out string[] strGroupIdArr)
        //{
        //    long lngRes = 0;
        //    strGroupIdArr = null;
        //    string strSQL = @"select groupid_chr from t_opr_lis_application_detail where APPLICATION_ID_CHR='"
        //        + strAppId + @"' and MODIFY_DAT=(select MODIFY_DAT from t_opr_lis_application where APPLICATION_ID_CHR='"
        //        + strAppId + @"' and PStatus_int>0)"; //要保证申请表上一个申请号只有一条状态不等于0的记录。
        //    System.Data.DataTable dtbTmp = new System.Data.DataTable();
        //    try
        //    {
        //        com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //        lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbTmp);
        //        objHRPSvc.Dispose();
        //        strGroupIdArr = new string[dtbTmp.Rows.Count];
        //        for (int i = 0; i < dtbTmp.Rows.Count; i++)
        //        {
        //            strGroupIdArr[i] = dtbTmp.Rows[i][0].ToString();
        //        }
        //    }
        //    catch (System.Exception objEx)
        //    {
        //        com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //        bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。
        //    }
        //    return lngRes;
        //}
        //#endregion

        //        #region 根据申请号，获得所有需要的样本列表。
        //        //这里假定所有的组都可以在t_lis_aid_group_sample表中找到样本要求。如果在t_lis_aid_group_sample表中
        //        //只有没有子组的检验项目的样本要求，则要先进行组的分析。相关方法见clsCheckGroupSvc类。
        //        [AutoComplete]
        //        public long m_lngGetApplicationSample(System.Security.Principal.IPrincipal p_objPrincipal,
        //            string strAppId, out System.Data.DataTable dtbAppSample)
        //        {
        //            long lngRes = 0;
        //            string strSQL = @"select c.GROUPNAME_VCHR,a.SAMPLE_TYPE_ID_CHR,b.SAMPLE_TYPE_DESC_VCHR,a.SAMPLE_ORD_INT,a.SAMPLE_QTY_CHR,
        //                       a.SAMPLE_VALID_TIME from t_aid_lis_group_sample a, t_aid_lis_sampletype b,t_aid_lis_check_group c
        //                       where a.GROUPID_CHR = c.GROUPID_CHR and b.SAMPLE_TYPE_ID_CHR=a.SAMPLE_TYPE_ID_CHR and a.GROUPID_CHR in (select 
        //                       GROUPID_CHR from t_opr_lis_application_detail where APPLICATION_ID_CHR='" + strAppId + @"' and
        //				       MODIFY_DAT = (select MODIFY_DAT from t_opr_lis_application where APPLICATION_ID_CHR='" + strAppId + @"' and
        //					   PStatus_int>0))";
        //            dtbAppSample = null;
        //            try
        //            {
        //                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbAppSample);
        //                objHRPSvc.Dispose();
        //            }
        //            catch (System.Exception objEx)
        //            {
        //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。
        //            }
        //            return lngRes;
        //        }
        //        #endregion

        #region 根据申请号，设置其处理状态（PStatus_int)
        [AutoComplete]
        public long m_lngSetApplicationStatus(System.Security.Principal.IPrincipal p_objPrincipal,
            string strAppId, int intStatus)
        {
            long lngRes = 0;
            string strSQL = @"update t_opr_lis_application set PStatus_int=" + intStatus.ToString()
                + " where PStatus_int>0 and APPLICATION_ID_CHR='" + strAppId + "'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);
                objHRPSvc.Dispose();
            }
            catch (System.Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。
            }
            return lngRes;
        }
        #endregion

        //        #region 根据标本上的条码号，查询该标本所对应的检验申请的所有检验项目
        //        [AutoComplete]
        //        public long m_lngGetApplCheckGroupBySampleBarCode(System.Security.Principal.IPrincipal p_objPrincipal, string p_strSampleBarCode, out DataTable p_dtbCheckGroupList)
        //        {
        //            long lngRes = 0;
        //            string strSQL = @"SELECT distinct t1.application_id_chr, t1.groupid_chr,t4.GROUPNAME_VCHR
        //							FROM t_opr_lis_application_item t1,
        //								t_opr_lis_application t2,
        //								t_opr_lis_sample t3,
        //								t_aid_lis_check_group t4
        //							WHERE t3.application_form_no_chr = t2.application_form_no_chr
        //							AND t1.application_id_chr = t2.application_id_chr
        //							AND t1.modify_dat = t2.modify_dat
        //							AND t2.pstatus_int > 0
        //							AND t4.groupid_chr = t1.groupid_chr
        //							AND t3.barcode_vchr='" + p_strSampleBarCode + @"'";


        //            p_dtbCheckGroupList = null;
        //            try
        //            {
        //                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbCheckGroupList);
        //                objHRPSvc.Dispose();
        //            }
        //            catch (Exception objEx)
        //            {
        //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。

        //            }
        //            return lngRes;
        //        }
        //        #endregion

        //        #region 根据申请单号（指申请单上贴得条码号或者印刷的号码，不是系统内部为每个申请指定的号码）查出对应的检验申请的资料 
        //        [AutoComplete]
        //        public long m_lngGetApplicationInfoByFormNo(System.Security.Principal.IPrincipal p_objPrincipal, string p_strApplFormNo, out com.digitalwave.iCare.ValueObject.clsLisApplMainVO p_objApplMainVO)
        //        {
        //            long lngRes = 0;
        //            p_objApplMainVO = null;
        //            string strSQL = @"select APPLICATION_ID_CHR,MODIFY_DAT,patientid_chr,application_dat
        //							sex_chr,patient_name_vchr,patient_subno_chr,age_chr,patient_type_chr,diagnose_vchr
        //							bedno_chr,icd_vchr,patientcardid_chr,application_form_no_chr,operator_id_chr,
        //							appl_empid_chr,appl_deptid_chr,Summary_Vchr,PStatus_int
        //							from t_opr_lis_application where and PStatus_int>0 application_form_no_chr='" + p_strApplFormNo + "'";

        //            try
        //            {
        //                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
        //                System.Data.DataTable objDT_AppList = null;
        //                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref objDT_AppList);
        //                if (lngRes > 0)
        //                {
        //                    if (objDT_AppList.Rows.Count == 1)
        //                    {
        //                        p_objApplMainVO = new clsVOConstructor().m_objConstructAppMainVO(objDT_AppList.Rows[0]);
        //                    }
        //                }
        //                objHRPSvc.Dispose();

        //            }
        //            catch (Exception objEx)
        //            {
        //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。
        //            }
        //            return lngRes;
        //        }
        //        #endregion

        //#region 根据申请单号（指申请单上贴得条码号或者印刷的号码，不是系统内部为每个申请指定的号码）查出对应的检验申请的资料 
        //[AutoComplete]
        //public long m_lngGetApplicationInfoByFormNo(System.Security.Principal.IPrincipal p_objPrincipal, string p_strApplFormNo, out System.Data.DataTable p_dtbAppl)
        //{
        //    long lngRes = 0;
        //    p_dtbAppl = null;
        //    string strSQL = c_strQueryAppl_SQL + @" and a.pstatus_int > 0 AND a.application_form_no_chr = '" + p_strApplFormNo + "'";

        //    try
        //    {
        //        com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
        //        lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbAppl);
        //        objHRPSvc.Dispose();
        //    }
        //    catch (Exception objEx)
        //    {
        //        com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //        bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。
        //    }
        //    return lngRes;
        //}
        //#endregion

        //        #region 根据日期范围，查询指定日期范围(按申请日期、采样日期、检验日期、审核日期)之内的全部申请资料 
        //        /// <summary>
        //        /// 
        //        /// </summary>
        //        /// <param name="p_objPrincipal"></param>
        //        /// <param name="p_intDateQueryType">0-申请日期;1-采样日期; 2-检验日期、审核日期</param>
        //        /// <param name="p_strDateFieldName"></param>
        //        /// <param name="p_dtBegin"></param>
        //        /// <param name="p_dtEnd"></param>
        //        /// <param name="p_dtbAppl"></param>
        //        /// <returns></returns>
        //        [AutoComplete]
        //        public long m_lngGetApplInfoByDateRange(System.Security.Principal.IPrincipal p_objPrincipal, int p_intDateQueryType, string p_strDateFieldName, System.DateTime p_dtBegin, System.DateTime p_dtEnd, string strPstatus, out System.Data.DataTable p_dtbAppl)
        //        {
        //            long lngRes = 0;
        //            p_dtbAppl = null;
        //            string strSQL = null;
        //            if (p_intDateQueryType == 0)//按申请日期查询
        //            {
        //                strSQL = @"SELECT application_id_chr, modify_dat, patientid_chr, application_dat,
        //						sex_chr, patient_name_vchr, patient_subno_chr, age_chr,
        //						patient_type_id_chr, diagnose_vchr, bedno_chr, icdcode_chr,
        //						patientcardid_chr, application_form_no_chr, operator_id_chr,
        //						appl_empid_chr, appl_deptid_chr, summary_vchr, pstatus_int, EMERGENCY_INT, SPECIAL_INT
        //						FROM t_opr_lis_application
        //						WHERE pstatus_int > 0
        //						AND pstatus_int " + strPstatus + @"
        //						AND " + p_strDateFieldName + " BETWEEN ? AND ?";

        //            }
        //            else if (p_intDateQueryType == 1)//按采样日期查询
        //            {
        //                strSQL = @"SELECT DISTINCT t1.application_id_chr, t1.modify_dat, t1.patientid_chr,
        //						t1.application_dat, t1.sex_chr, t1.patient_name_vchr,
        //						t1.patient_subno_chr, t1.age_chr, t1.patient_type_chr,
        //						t1.diagnose_vchr, t1.bedno_chr, t1.icd_vchr,
        //						t1.patientcardid_chr, t1.application_form_no_chr,
        //						t1.operator_id_chr, t1.appl_empid_chr, t1.appl_deptid_chr,
        //						t1.summary_vchr
        //						FROM t_opr_lis_application t1,
        //								t_opr_lis_sample t2,
        //								t_opr_lis_req_check_detail t3
        //						WHERE t1.pstatus_int > 0
        //							AND t2.status_int > 0
        //							AND pstatus_int " + strPstatus + @"
        //							AND t2.application_form_no_chr = t1.application_form_no_chr
        //							AND t3.sample_id_chr = t2.sample_id_chr							
        //							AND t2.sampling_date_dat BETWEEN ? AND ?
        //						ORDER BY application_id_chr";

        //            }
        //            else if (p_intDateQueryType > 1)//按检验日期或审核日期查询
        //            {
        //                strSQL = @"SELECT DISTINCT t1.application_id_chr, t1.modify_dat, t1.patientid_chr,
        //						t1.application_dat, t1.sex_chr, t1.patient_name_vchr,
        //						t1.patient_subno_chr, t1.age_chr, t1.patient_type_chr,
        //						t1.diagnose_vchr, t1.bedno_chr, t1.icd_vchr,
        //						t1.patientcardid_chr, t1.application_form_no_chr,
        //						t1.operator_id_chr, t1.appl_empid_chr, t1.appl_deptid_chr,
        //						t1.summary_vchr
        //						FROM t_opr_lis_application t1,
        //								t_opr_lis_sample t2,
        //								t_opr_lis_check_result t3
        //						WHERE  t1.pstatus_int > 0
        //							AND t2.status_int > 0			
        //							AND t3.status_int > 0
        //							AND t2.application_form_no_chr = t1.application_form_no_chr
        //							AND t3.sample_id_chr = t2.sample_id_chr								
        //							AND t3." + p_strDateFieldName + @" BETWEEN ? AND ?
        //						ORDER BY t1.application_id_chr";
        //            }
        //            try
        //            {
        //                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
        //                System.Data.IDataParameter[] objAppArr = null;
        //                objHRPSvc.CreateDatabaseParameter(2, out objAppArr);
        //                objAppArr[0].Value = p_dtBegin;
        //                objAppArr[1].Value = p_dtEnd;

        //                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtbAppl, objAppArr);
        //                objHRPSvc.Dispose();
        //            }
        //            catch (Exception objEx)
        //            {
        //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。
        //            }
        //            return lngRes;
        //        }
        //        #endregion


        //        #region 按申请日期范围、PStatus_int状态查询申请单信息 
        //        [AutoComplete]
        //        public long m_lngGetApplByApplDateRange(System.Security.Principal.IPrincipal p_objPrincipal, System.DateTime p_dtBegin, System.DateTime p_dtEnd, string p_strStatusFilter, out System.Data.DataTable p_dtbAppl)
        //        {
        //            long lngRes = 0;
        //            p_dtbAppl = null;

        //            p_dtBegin = Convert.ToDateTime(p_dtBegin.ToString("yyyy-MM-dd 00:00:00"));
        //            p_dtEnd = Convert.ToDateTime(p_dtEnd.AddDays(1).ToString("yyyy-MM-dd 00:00:00"));
        //            string strSQL = @"SELECT a.application_id_chr, a.patientid_chr, a.application_dat, a.sex_chr,
        //							a.patient_name_vchr, a.patient_subno_chr, a.age_chr,
        //							a.patient_type_id_chr, a.diagnose_vchr, a.bedno_chr, a.icdcode_chr,
        //							a.patientcardid_chr, a.application_form_no_chr, a.modify_dat,
        //							a.operator_id_chr, a.appl_empid_chr, a.appl_deptid_chr, a.summary_vchr,
        //							a.pstatus_int, b.lastname_vchr operatorname, c.deptname_vchr,
        //							d.lastname_vchr empname, e.icdname_vchr, f.dictname_vchr pattype,a.EMERGENCY_INT,
        //							a.SPECIAL_INT
        //							FROM t_opr_lis_application a,
        //								t_bse_employee b,
        //								t_bse_deptbaseinfo c,
        //								t_bse_employee d,
        //								t_aid_icd10 e,
        //								t_aid_dict f
        //							WHERE a.operator_id_chr = b.empid_chr(+)
        //							AND a.appl_deptid_chr = c.deptid_chr(+)
        //							AND a.appl_empid_chr = d.empid_chr(+)
        //							AND a.icdcode_chr = e.icdcode_chr(+)
        //							AND a.patient_type_id_chr = f.dictid_chr(+)
        //							AND f.dictkind_chr(+) = '61'
        //							AND a.application_dat BETWEEN ? AND ?
        //							AND a.pstatus_int " + p_strStatusFilter + " order by a.application_id_chr";

        //            try
        //            {
        //                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
        //                System.Data.IDataParameter[] objAppArr = null;
        //                objHRPSvc.CreateDatabaseParameter(2, out objAppArr);
        //                objAppArr[0].Value = p_dtBegin;
        //                objAppArr[1].Value = p_dtEnd;

        //                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtbAppl, objAppArr);
        //                objHRPSvc.Dispose();
        //            }
        //            catch (Exception objEx)
        //            {
        //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。
        //            }
        //            return lngRes;
        //        }
        //        #endregion

        //        #region 根据申请号（系统内部给定的申请唯一号）查询该申请所有检验项目（不含有子组）资料(含SampleID) 
        //        [AutoComplete]
        //        public long m_lngGetApplicationCheckInfo(System.Security.Principal.IPrincipal p_objPrincipal, string p_strApplFormID, out System.Data.DataTable p_dtbAppCheckInfo)
        //        {
        //            long lngRes = 0;
        //            p_dtbAppCheckInfo = null;

        //            string strSQL = @"SELECT distinct t2.sample_id_chr , t1.groupid_chr , t3.groupname_vchr,t3.print_category_id_chr
        //								FROM t_opr_lis_req_check_detail t1,
        //									t_opr_lis_sample t2,
        //									t_aid_lis_check_group t3
        //								WHERE t1.sample_id_chr = t2.sample_id_chr
        //								AND t1.groupid_chr = t3.groupid_chr
        //								AND t2.status_int > 0
        //								AND t2.application_form_no_chr ='" + p_strApplFormID + "'";


        //            try
        //            {
        //                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
        //                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbAppCheckInfo);
        //                objHRPSvc.Dispose();
        //            }
        //            catch (Exception objEx)
        //            {
        //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异
        //            }
        //            return lngRes;
        //        }
        //        #endregion

        //        #region 根据t_opr_lis_application某一字段和各种日期范围(申请日期、采样日期、检验日期、审核日期)查询所有申请资料 
        //        /// <summary>
        //        /// 
        //        /// </summary>
        //        /// <param name="p_objPrincipal"></param>
        //        /// <param name="p_strFieldName"></param>
        //        /// <param name="p_strFieldValue"></param>
        //        /// <param name="p_intDateQueryType">0-申请日期;1-采样日期 2-检验日期、审核日期</param>
        //        /// <param name="p_strDateFieldName"></param>
        //        /// <param name="p_dtBegin"></param>
        //        /// <param name="p_dtEnd"></param>
        //        /// <param name="p_dtbAppl"></param>
        //        /// <returns></returns>
        //        [AutoComplete]
        //        public long m_lngGetApplInfoByFieldValue(System.Security.Principal.IPrincipal p_objPrincipal, string p_strFieldName, string p_strFieldValue, int p_intDateQueryType, string p_strDateFieldName, DateTime p_dtBegin, DateTime p_dtEnd, out System.Data.DataTable p_dtbAppl)
        //        {
        //            long lngRes = 0;
        //            p_dtbAppl = null;
        //            string strSQL = null;

        //            if (p_intDateQueryType == 0)//按申请日期查询
        //            {
        //                strSQL = @"SELECT application_id_chr, modify_dat, patientid_chr, application_dat,
        //						sex_chr, patient_name_vchr, patient_subno_chr, age_chr,
        //						patient_type_id_chr, diagnose_vchr, bedno_chr, icdcode_chr,
        //						patientcardid_chr, application_form_no_chr, operator_id_chr,
        //						appl_empid_chr, appl_deptid_chr, summary_vchr, pstatus_int
        //						FROM t_opr_lis_application
        //						WHERE pstatus_int > 0
        //						AND " + p_strFieldName + " = '" + p_strFieldValue + @"'
        //						AND " + p_strDateFieldName + @" BETWEEN ? AND ?
        //						ORDER BY application_id_chr";

        //            }
        //            else if (p_intDateQueryType == 1)//按采样日期查询
        //            {
        //                strSQL = @"SELECT DISTINCT t1.application_id_chr, t1.modify_dat, t1.patientid_chr,
        //						t1.application_dat, t1.sex_chr, t1.patient_name_vchr,
        //						t1.patient_subno_chr, t1.age_chr, t1.patient_type_chr,
        //						t1.diagnose_vchr, t1.bedno_chr, t1.icd_vchr,
        //						t1.patientcardid_chr, t1.application_form_no_chr,
        //						t1.operator_id_chr, t1.appl_empid_chr, t1.appl_deptid_chr,
        //						t1.summary_vchr
        //						FROM t_opr_lis_application t1,
        //								t_opr_lis_sample t2,
        //								t_opr_lis_req_check_detail t3
        //						WHERE t1.pstatus_int > 0
        //							and t1." + p_strFieldName + " = '" + p_strFieldValue + @"'
        //							AND t2.status_int > 0
        //							AND t2.application_form_no_chr = t1.application_form_no_chr
        //							AND t3.sample_id_chr = t2.sample_id_chr							
        //							AND t2.sampling_date_dat BETWEEN '' AND ''
        //						ORDER BY application_id_chr";
        //            }
        //            else if (p_intDateQueryType > 1)//按检验日期或审核日期查询
        //            {
        //                strSQL = @"SELECT DISTINCT t1.application_id_chr, t1.modify_dat, t1.patientid_chr,
        //                t1.application_dat, t1.sex_chr, t1.patient_name_vchr,
        //                t1.patient_subno_chr, t1.age_chr, t1.patient_type_chr,
        //                t1.diagnose_vchr, t1.bedno_chr, t1.icd_vchr,
        //                t1.patientcardid_chr, t1.application_form_no_chr,
        //                t1.operator_id_chr, t1.appl_empid_chr, t1.appl_deptid_chr,
        //                t1.summary_vchr
        //				FROM t_opr_lis_application t1,
        //						t_opr_lis_sample t2,
        //						t_opr_lis_check_result t3
        //				WHERE t1." + p_strFieldName + " = '" + p_strFieldValue + @"'
        //					AND t1.pstatus_int > 0
        //					AND t2.application_form_no_chr = t1.application_form_no_chr
        //					AND t3.sample_id_chr = t2.sample_id_chr						
        //					AND t2.status_int > 0			
        //					AND t3.status_int > 0					
        //					AND t3." + p_strDateFieldName + @" BETWEEN ? AND ?
        //				ORDER BY t1.application_id_chr";
        //            }

        //            try
        //            {
        //                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
        //                System.Data.IDataParameter[] objApplArr = null;
        //                objHRPSvc.CreateDatabaseParameter(2, out objApplArr);

        //                objApplArr[0].Value = p_dtBegin;
        //                objApplArr[1].Value = p_dtEnd;
        //                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtbAppl, objApplArr);
        //                objHRPSvc.Dispose();
        //            }
        //            catch (Exception objEx)
        //            {
        //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异             
        //            }
        //            return lngRes;
        //        }
        //        #endregion

        //        #region  根据GroupID(无子组)和各种日期范围(申请日期、采样日期、检验日期、审核日期)查询所有申请资料 
        //        /// <summary>
        //        /// 
        //        /// </summary>
        //        /// <param name="p_objPrincipal"></param>
        //        /// <param name="p_strGroupID"></param>
        //        /// <param name="p_intDateQueryType">0-申请日期;1-采样日期 2-检验日期、审核日期</param>
        //        /// <param name="p_strDateFieldName"></param>
        //        /// <param name="p_dtBegin"></param>
        //        /// <param name="p_dtEnd"></param>
        //        /// <param name="p_dtbAppl"></param>
        //        /// <returns></returns>
        //        [AutoComplete]
        //        public long m_lngGetApplInfoByFieldValue(System.Security.Principal.IPrincipal p_objPrincipal, string p_strGroupID, int p_intDateQueryType, string p_strDateFieldName, System.DateTime p_dtBegin, System.DateTime p_dtEnd, out System.Data.DataTable p_dtbAppl)
        //        {
        //            long lngRes = 0;
        //            p_dtbAppl = null;
        //            string strSQL = null;

        //            if (p_intDateQueryType == 0)//按申请日期查询
        //            {
        //                strSQL = @"SELECT distinct t1.application_id_chr, t1.modify_dat, t1.patientid_chr,
        //						t1.application_dat, t1.sex_chr, t1.patient_name_vchr,
        //						t1.patient_subno_chr, t1.age_chr, t1.patient_type_chr,
        //						t1.diagnose_vchr, t1.bedno_chr, t1.icd_vchr, t1.patientcardid_chr,
        //						t1.application_form_no_chr, t1.operator_id_chr, t1.appl_empid_chr,
        //						t1.appl_deptid_chr, t1.summary_vchr
        //						FROM t_opr_lis_application t1,
        //							t_opr_lis_sample t2,
        //							t_opr_lis_req_check_detail t3
        //						WHERE t2.application_form_no_chr = t1.application_form_no_chr
        //						AND t1.pstatus_int > 0
        //						AND t2.status_int > 0
        //						AND t3.sample_id_chr = t2.sample_id_chr
        //						AND t3.groupid_chr = '" + p_strGroupID + @"'						
        //						AND t1.application_dat BETWEEN ? AND ? 
        //						ORDER BY application_id_chr";

        //            }
        //            else if (p_intDateQueryType == 1)//按采样日期查询
        //            {
        //                strSQL = @"SELECT distinct t1.application_id_chr, t1.modify_dat, t1.patientid_chr,
        //						t1.application_dat, t1.sex_chr, t1.patient_name_vchr,
        //						t1.patient_subno_chr, t1.age_chr, t1.patient_type_chr,
        //						t1.diagnose_vchr, t1.bedno_chr, t1.icd_vchr, t1.patientcardid_chr,
        //						t1.application_form_no_chr, t1.operator_id_chr, t1.appl_empid_chr,
        //						t1.appl_deptid_chr, t1.summary_vchr
        //						FROM t_opr_lis_application t1,
        //							t_opr_lis_sample t2,
        //							t_opr_lis_req_check_detail t3
        //						WHERE t2.application_form_no_chr = t1.application_form_no_chr
        //						AND t1.pstatus_int > 0
        //						AND t2.status_int > 0						
        //						AND t3.sample_id_chr = t2.sample_id_chr
        //						AND t3.groupid_chr = '" + p_strGroupID + @"'
        //						AND t2.sampling_date_dat BETWEEN ? AND ? 
        //						ORDER BY application_id_chr";
        //            }
        //            else if (p_intDateQueryType > 1)//按检验日期或审核日期查询
        //            {
        //                strSQL = @"SELECT DISTINCT t1.application_id_chr, t1.modify_dat, t1.patientid_chr,
        //						t1.application_dat, t1.sex_chr, t1.patient_name_vchr,
        //						t1.patient_subno_chr, t1.age_chr, t1.patient_type_chr,
        //						t1.diagnose_vchr, t1.bedno_chr, t1.icd_vchr,
        //						t1.patientcardid_chr, t1.application_form_no_chr,
        //						t1.operator_id_chr, t1.appl_empid_chr, t1.appl_deptid_chr,
        //						t1.summary_vchr
        //						FROM t_opr_lis_application t1,
        //								t_opr_lis_sample t2,
        //								t_opr_lis_check_result t3
        //						WHERE t2.application_form_no_chr = t1.application_form_no_chr
        //							AND t1.pstatus_int > 0
        //							AND t2.status_int > 0	
        //							AND t3.sample_id_chr = t2.sample_id_chr
        //							AND t3.groupid_chr = '" + p_strGroupID + @"'				
        //							AND t3.status_int > 0							
        //							AND t3." + p_strDateFieldName + @" BETWEEN ? AND ?
        //						ORDER BY t1.application_id_chr";
        //            }
        //            try
        //            {
        //                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
        //                System.Data.IDataParameter[] objApplArr = null;
        //                objHRPSvc.CreateDatabaseParameter(2, out objApplArr);
        //                objApplArr[0].Value = p_dtBegin;
        //                objApplArr[1].Value = p_dtEnd;
        //                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtbAppl, objApplArr);
        //                objHRPSvc.Dispose();
        //            }
        //            catch (Exception objEx)
        //            {
        //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异

        //            }
        //            return lngRes;
        //        }
        //        #endregion


        #region 构造clsLisApplDetailVO
        [AutoComplete]
        private void m_mthConstructAppDetailVO(System.Data.DataRow objRow, ref com.digitalwave.iCare.ValueObject.clsLisApplDetailVO p_objApplDetailVO)
        {
            p_objApplDetailVO.m_strApplication_ID = objRow["APPLICATION_ID_CHR"].ToString().Trim();

            p_objApplDetailVO.m_intSeq_Int = Convert.ToInt32(objRow["SEQ_INT"].ToString().Trim());

            p_objApplDetailVO.m_strModifyDat = objRow["MODIFY_DAT"].ToString().Trim();

            p_objApplDetailVO.m_strGroupID = objRow["groupid_chr"].ToString().Trim();

            if (objRow["Summary_Vchr"] != System.DBNull.Value)
            { p_objApplDetailVO.m_strSummary = objRow["Summary_Vchr"].ToString().Trim(); }

            p_objApplDetailVO.m_intPStatus_int = Convert.ToInt32(objRow["STATUS_INT"].ToString().Trim());

        }
        #endregion

        #region 作废申请单
        /// <summary>
        /// 作废申请单
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strAppID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdateVoidApply(System.Security.Principal.IPrincipal p_objPrincipal, string p_strAppID, string p_strOperatorID)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngUpdataLisResult");
            if (lngRes < 0)
            {
                return lngRes;
            }
            clsHRPTableService objHRPSvc = null;
            string strAPPSQL = null;
            string strSampleSQL = null;
            try
            {
                strSampleSQL = @"update t_opr_lis_app_report t
   set t.status_int = -8, t.modify_dat = ?
 where t.status_int > 0
   and t.application_id_chr = ?
";
                strAPPSQL = @"update t_opr_lis_application t
   set t.pstatus_int = -8, t.operator_id_chr = ?, t.modify_dat = ?
 where t.pstatus_int > 0
   and t.application_id_chr = ?
";
                IDataParameter[] objDPArr = null;
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(3, out objDPArr);
                objDPArr[0].Value = p_strOperatorID;
                objDPArr[1].Value = DateTime.Now;
                objDPArr[2].Value = p_strAppID;
                long lngEff = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strAPPSQL, ref lngEff, objDPArr);
                if (lngRes > 0)
                {
                    objHRPSvc.CreateDatabaseParameter(2, out objDPArr);
                    objDPArr[0].Value = DateTime.Now;
                    objDPArr[1].Value = p_strAppID;
                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSampleSQL, ref lngEff, objDPArr);
                }
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objPrivilege = null;
                objHRPSvc = null;
                strSampleSQL = null;
                strAPPSQL = null;
            }
            return lngRes;
        }
        #endregion

        #region 通过申请单号判断是否审核
        /// <summary>
        /// 通过申请单号判断是否审核
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strApplicationID"></param>
        /// <param name="p_strStatus"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lnqQueryConfirmReport(System.Security.Principal.IPrincipal p_objPrincipal, string p_strApplicationID, out DataTable p_dtResult, out DataTable p_dtUnitResult)
        {
            p_dtResult = null;
            p_dtUnitResult = null;
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lnqQueryConfirmReport");
            if (lngRes < 0)
            {
                return lngRes;
            }
            string strSQL = null;
            clsHRPTableService objHRPSvc = null;
            string strSQL1 = null;
            try
            {
                strSQL = @"select t.status_int, t.confirmer_id_chr, t.operator_id_chr, t.checker_id_chr 
                              from t_opr_lis_sample t
                             where t.application_id_chr = ?
                               and t.status_int > 0
                            ";
                IDataParameter[] objDPArr = null;
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strApplicationID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtResult, objDPArr);
                strSQL1 = @"select a.apply_unit_id_chr,
                                   b.apply_unit_name_vchr
                              from t_opr_lis_app_apply_unit a, t_aid_lis_apply_unit b
                             where a.apply_unit_id_chr = b.apply_unit_id_chr
                               and a.application_id_chr = ?";
                if (lngRes > 0 & p_dtResult != null & p_dtResult.Rows.Count > 0)
                {
                    objHRPSvc.CreateDatabaseParameter(1, out objDPArr);
                    objDPArr[0].Value = p_strApplicationID;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL1, ref p_dtUnitResult, objDPArr);
                }

            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objPrivilege = null;
                objHRPSvc = null;
                strSQL1 = null;
                strSQL = null;
            }
            return lngRes;
        }
        #endregion

        #region 获取系统参数
        /// <summary>
        /// 获取系统参数
        /// </summary>
        /// <param name="p_strParmCode"></param>
        /// <param name="p_strParmValue"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetSysParm(string p_strParmCode, out string p_strParmValue)
        {
            p_strParmValue = "";
            long lngRes = 0;
            if (string.IsNullOrEmpty(p_strParmCode))
                return lngRes;
            clsHRPTableService objHRPServ = null;
            try
            {
                string strSQL = @"select parmvalue_vchr
  from t_bse_sysparm
 where status_int = 1
   and parmcode_chr = ?";
                IDataParameter[] objDPArr = null;
                objHRPServ = new clsHRPTableService();
                objHRPServ.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strParmCode;
                DataTable dtResult = null;
                lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtResult, objDPArr);
                if (lngRes > 0 && dtResult != null && dtResult.Rows.Count > 0)
                {
                    p_strParmValue = dtResult.Rows[0]["parmvalue_vchr"].ToString().Trim();
                }
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPServ = null;
                p_strParmCode = null;
            }
            return lngRes;
        }
        #endregion

        #region 修改t_opr_lis_app_report 表的打印次数
        /// <summary>
        /// 修改t_opr_lis_app_report 表的打印次数
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strApplicaionID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdatePrinctTime(System.Security.Principal.IPrincipal p_objPrincipal, string p_strApplicaionID)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngUpdatePrinctTime");
            if (lngRes <= 0)
            {
                return lngRes;
            }
            string strSQL = null;
            clsHRPTableService objHRPSvc = null;
            try
            {
                strSQL = @"update t_opr_lis_app_report t
   set t.report_print_chr = report_print_chr + 1,
       t.report_print_dat = decode(report_print_chr,
                                   0,
                                   sysdate,
                                   report_print_dat)
 where t.application_id_chr = ?
   and status_int = 2";
                IDataParameter[] objDPArr = null;
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strApplicaionID;
                long lngEff = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                //                if (lngEff > 0)
                //                {
                //                    strSQL = @"update t_opr_lis_report_object t
                //   set t.report_print_chr = t.report_print_chr + 1
                // where t.application_id_chr = ?";
                //                    objHRPSvc.CreateDatabaseParameter(1, out objDPArr);
                //                    objDPArr[0].Value = p_strApplicaionID;
                //                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
                //                }
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPSvc = null;
                objPrivilege = null;
                strSQL = null;
            }
            return lngRes;
        }
        #endregion

        #region 取消审核
        /// <summary>
        /// 取消审核
        /// </summary>
        /// <param name="p_strAppID">申请单ID</param>
        /// <param name="p_strOperatorID">操作员工ID</param>
        /// <returns>大于0成功，否则失败</returns>
        [AutoComplete]
        public long m_lngCancelConfimReport(string p_strAppID, string p_strOperatorID)
        {
            long lngRes = 0;

            clsHRPTableService objHRPSvc = null;
            string strAPPSQL = null;
            string strReportSQL = null;
            string strSampleSQL = null;
            try
            {
                strReportSQL = @"update t_opr_lis_app_report t
   set t.status_int = 1, t.modify_dat = sysdate, t.operator_id_chr = ?
 where t.status_int > 0
   and t.application_id_chr = ?
";
                strAPPSQL = @"update t_opr_lis_application t
   set t.pstatus_int = 2, t.operator_id_chr = ?, t.modify_dat = sysdate
 where t.pstatus_int > 0
   and t.application_id_chr = ?
";
                strSampleSQL = @"update t_opr_lis_sample t
   set t.status_int            = 5,
       t.operator_id_chr       = ?,
       t.cancelconfimer_id_chr = ?,
       t.cancelconfimer_dat    = sysdate,
       t.modify_dat            = sysdate
 where t.application_id_chr = ?
   and t.status_int > 0";

                IDataParameter[] objDPArr = null;
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(2, out objDPArr);
                objDPArr[0].Value = p_strOperatorID;
                objDPArr[1].Value = p_strAppID;
                long lngEff = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strAPPSQL, ref lngEff, objDPArr);
                if (lngRes > 0)
                {
                    objHRPSvc.CreateDatabaseParameter(3, out objDPArr);
                    objDPArr[0].Value = p_strOperatorID;
                    objDPArr[1].Value = p_strOperatorID;
                    objDPArr[2].Value = p_strAppID;
                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSampleSQL, ref lngEff, objDPArr);
                    if (lngRes > 0)
                    {
                        objHRPSvc.CreateDatabaseParameter(2, out objDPArr);
                        objDPArr[0].Value = p_strOperatorID;
                        objDPArr[1].Value = p_strAppID;
                        lngRes = objHRPSvc.lngExecuteParameterSQL(strReportSQL, ref lngEff, objDPArr);
                    }
                }
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPSvc = null;
                strSampleSQL = null;
                strAPPSQL = null;
                strReportSQL = null;
            }
            return lngRes;
        }
        #endregion

        #region 获取检验类别
        /// <summary>
        /// 获取检验类别
        /// </summary>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngQueryCheckCategory(out DataTable p_dtResult)
        {
            long lngRes = 0;
            p_dtResult = null;
            string strSQL = null;
            clsHRPTableService objHRPSvc = null;
            try
            {
                strSQL = @"select a.check_category_id_chr, a.check_category_desc_vchr
  from t_bse_lis_check_category a";
                objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtResult);
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, false);
            }
            finally
            {
                objHRPSvc.Dispose();
                objHRPSvc = null;
            }
            return lngRes;
        }
        #endregion

        #region 查询申请信息
        /// <summary>
        /// 联合查询申请单信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objSchVO">承载联合查询条件的VO,其中值为NULL的成员会被必忽略</param>
        /// <param name="p_objAppVOArr">返回的承载申请单信息的数组</param>
        /// <returns>0:失败;1:成功</returns>
        [AutoComplete]
        public long m_lngGetAppInfoByModifDate(System.Security.Principal.IPrincipal p_objPrincipal, clsLISApplicationSchVO p_objSchVO, string p_strCheckCategory, out clsLisApplMainVO[] p_objAppVOArr)
        {
            long lngRes = 0;
            p_objAppVOArr = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplicationSvc", "m_lngGetAppInfoByModifDate");
            if (lngRes < 0)
            {
                return -1;
            }

            #region SQL
            
            string strSQL = @"select parmvalue_vchr from t_bse_sysparm 
                               where status_int = 1 and parmcode_chr = ?";
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
            DataTable dtbResult = new DataTable();
            System.Collections.ArrayList arrCat = new System.Collections.ArrayList();
            lngRes = 0;
            IDataParameter[] objDPArr = null;
            objHRPSvc.CreateDatabaseParameter(1, out objDPArr);
            objDPArr[0].Value = "7013";
            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);

                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    string strParm = dtbResult.Rows[0][0].ToString();
                    if (!string.IsNullOrEmpty(strParm))
                    {
                        System.Collections.ArrayList arrRes = new System.Collections.ArrayList();
                        arrRes = m_ArrGettoken(strParm, ";");
                        strSQL = @"select check_category_id_chr from t_bse_lis_check_category";
                        lngRes = 0;
                        dtbResult = null;
                        lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                        if (lngRes > 0 && dtbResult.Rows.Count > 0)
                        {
                            DataRow dr = null;
                            for (int i = 0; i < arrRes.Count; i++)
                            {
                                for (int j = 0; j < dtbResult.Rows.Count; j++)
                                {
                                    dr = dtbResult.Rows[j];
                                    if (arrRes[i].ToString().Trim() == dr["check_category_id_chr"].ToString().Trim())
                                    { arrCat.Add(arrRes[i].ToString().Trim()); break; }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception objEx)
            {
                throw (objEx);
            }

            strSQL = @"select   application_id_chr, patientid_chr, application_dat, sex_chr,
         patient_name_vchr, patient_subno_chr, age_chr, patient_type_id_chr,
         diagnose_vchr, bedno_chr, icdcode_chr, patientcardid_chr,
         application_form_no_chr, modify_dat, operator_id_chr, appl_empid_chr,
         appl_deptid_chr, summary_vchr, pstatus_int, emergency_int,
         special_int, form_int, patient_inhospitalno_chr, sample_type_id_chr,
         check_content_vchr, sample_type_vchr, oringin_dat, charge_info_vchr,
         printed_num, orderunitrelation_vchr, printed_date,
         report_group_id_chr_report, modify_dat_report, barcode_vchr, 
         operator_id_chr_report, status_int_report, report_dat_report,
         reportor_id_chr_report, confirm_dat_report, confirmer_id_chr_report,
         sampling_date_dat, accept_dat,isgreen_int
    from (select distinct t2.application_id_chr, t2.patientid_chr,
                          t2.application_dat, t2.sex_chr,
                          t2.patient_name_vchr, t2.patient_subno_chr,
                          t2.age_chr, t2.patient_type_id_chr,
                          t2.diagnose_vchr, t2.bedno_chr, t2.icdcode_chr,
                          t2.patientcardid_chr, t2.application_form_no_chr,
                          t2.modify_dat, t2.operator_id_chr,
                          t2.appl_empid_chr, t2.appl_deptid_chr,
                          t2.summary_vchr, t2.pstatus_int, t2.emergency_int,
                          t2.special_int, t2.form_int,
                          t2.patient_inhospitalno_chr, t2.sample_type_id_chr,
                          t2.check_content_vchr, t2.sample_type_vchr,
                          t2.oringin_dat, t2.charge_info_vchr, t2.printed_num,
                          t2.orderunitrelation_vchr, t2.printed_date,
                          t1.report_group_id_chr report_group_id_chr_report,
                          t1.modify_dat modify_dat_report,
                          t1.operator_id_chr operator_id_chr_report,
                          t1.status_int status_int_report,
                          t1.report_dat report_dat_report,
                          t1.reportor_id_chr reportor_id_chr_report,
                          t1.confirm_dat confirm_dat_report,
                          t1.confirmer_id_chr confirmer_id_chr_report,
                          t4.sample_id_chr, t4.sampling_date_dat, t4.modify_dat as modify_dat_sample, t4.accept_dat, t4.barcode_vchr, 
                          t5.isgreen_int
                     from t_opr_lis_app_report t1,
                          t_opr_lis_application t2,
                          t_opr_lis_sample t4,
                          t_opr_attachrelation t5
                    where t1.application_id_chr = t2.application_id_chr
                      and t1.application_id_chr = t5.attachid_vchr(+)
                      and t2.pstatus_int + 0 = 2
                      and t2.application_id_chr = t4.application_id_chr
                      and t4.status_int >= 3
                      and t4.status_int <= 6 ";
            //            string strSQL = @"SELECT   
            //											t2.application_form_no_chr, t2.patient_name_vchr,
            //                                          t2.check_content_vchr, t2.patientcardid_chr,
            //                                          1 status_int_report, t4.accept_dat
            //								FROM 
            //									t_opr_lis_application t2,
            //									t_opr_lis_sample t4       
            //								WHERE t2.pstatus_int  = 2
            //								AND t2.application_id_chr = t4.application_id_chr
            //								AND t4.status_int >= 3 AND t4.status_int <= 6 ";

            string strSQL_ConfirmState = " and t1.status_int = ? ";
            string strSQL_ConfirmStateAll = " and t1.status_int > ?";
            string strSQL_FromDate = " and t4.accept_dat >=to_date(?,'yyyy-mm-dd hh24:mi:ss') ";
            string strSQL_ToDate = " and t4.accept_dat <= to_date(?,'yyyy-mm-dd hh24:mi:ss') ";
            string strSQL_PatientName = " and trim(t2.patient_name_vchr) like ? ";
            string strSQL_BarCode = " and t4.barcode_vchr = ? ";
            string strSQL_SampleGroupID = @" and t2.application_id_chr in (
													select distinct tt1.application_id_chr
																from t_opr_lis_app_sample tt1
																where tt1.sample_group_id_chr in
																					(*))";
            string strSQL_UnitID = @" and t2.application_id_chr in (
													select distinct tt2.application_id_chr
																from t_opr_lis_app_apply_unit tt2
																where tt2.apply_unit_id_chr in
																					(*))";

            string strSQL_FromDateApp = " and t4.appl_dat >=to_date(?,'yyyy-mm-dd hh24:mi:ss')";
            string strSQL_ToDateApp = " and t4.appl_dat <=to_date(?,'yyyy-mm-dd hh24:mi:ss')";
            string strSQL_InhospNO = " and trim(t2.patient_inhospitalno_chr) = ? ";
            string strSQL_BedNO = " and trim(t2.bedno_chr) = ? ";
            string strSQL_AppDept = " and trim(t2.appl_deptid_chr) = ? ";
            string strSQL_AppDoct = " and trim(t2.appl_empid_chr) = ? ";
            string strSQL_AppID = " and t2.application_id_chr = ?";
            string strSQL_PatientID = " and t2.patientid_chr = ?";
            string strSQL_PatinetCardNO = "and t2.patientcardid_chr = ?";
            string strSQL_PatientCheckNO = " and t2.application_form_no_chr like ? ";
            string strSQL_CheckCategory = @" and exists
         (select 1
                  from t_opr_lis_app_apply_unit a
                 inner join t_aid_lis_apply_unit b on a.apply_unit_id_chr =
                                                      b.apply_unit_id_chr
                 where a.application_id_chr = t1.application_id_chr
                   and b.check_category_id_chr = ?)";
            string strSQL_FromModifyDate = " and t4.modify_dat >=to_date(?,'yyyy-mm-dd hh24:mi:ss') ";
            string strSQL_ToModifyDate = " and t4.modify_dat <= to_date(?,'yyyy-mm-dd hh24:mi:ss') ";
            #endregion

            ArrayList arlSQL = new ArrayList();
            ArrayList arlParm = new ArrayList();

            #region 构造

            if (p_objSchVO.m_strPatientCheckNO != null && p_objSchVO.m_strPatientCheckNO.ToString().Replace('%', ' ').Trim() != "")
            {
                arlSQL.Add(strSQL_PatientCheckNO);
                arlParm.Add(p_objSchVO.m_strPatientCheckNO);
            }
            if (p_objSchVO.m_strApplicationID != null)
            {
                arlSQL.Add(strSQL_AppID);
                arlParm.Add(p_objSchVO.m_strApplicationID);
            }
            if (p_objSchVO.m_strPatientID != null)
            {
                arlSQL.Add(strSQL_PatientID);
                arlParm.Add(p_objSchVO.m_strPatientID);
            }
            if (p_objSchVO.m_strPatientCardNO != null && p_objSchVO.m_strPatientCardNO.Trim() != "")
            {
                arlSQL.Add(strSQL_PatinetCardNO);
                arlParm.Add(p_objSchVO.m_strPatientCardNO);
            }
            if (p_objSchVO.m_strConfirmState == "1")
            {
                arlSQL.Add(strSQL_ConfirmState);
                arlParm.Add(1);
            }
            else if (p_objSchVO.m_strConfirmState == "2")
            {
                arlSQL.Add(strSQL_ConfirmState);
                arlParm.Add(2);
            }
            else if (p_objSchVO.m_strConfirmState == "0")
            {
                arlSQL.Add(strSQL_ConfirmState);
                arlParm.Add(0);
            }
            else
            {
                arlSQL.Add(strSQL_ConfirmStateAll);
                arlParm.Add(0);
            }
            if (p_objSchVO.m_strConfirmedDateBegin != null && Microsoft.VisualBasic.Information.IsDate(p_objSchVO.m_strConfirmedDateBegin.Trim()))
            {
                //arlSQL.Add(strSQL_FromDate);
                arlSQL.Add(strSQL_FromModifyDate);
                arlParm.Add(p_objSchVO.m_strConfirmedDateBegin.Trim());
            }
            if (p_objSchVO.m_strConfirmedDateEnd != null && Microsoft.VisualBasic.Information.IsDate(p_objSchVO.m_strConfirmedDateEnd.Trim()))
            {
                //arlSQL.Add(strSQL_ToDate);
                arlSQL.Add(strSQL_ToModifyDate);
                arlParm.Add(p_objSchVO.m_strConfirmedDateEnd.Trim());
            }
            if (p_objSchVO.m_strSampleGroupIDArr != null && p_objSchVO.m_strSampleGroupIDArr.Length > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < p_objSchVO.m_strSampleGroupIDArr.Length; i++)
                {
                    sb.Append("?,");
                }
                sb.Remove(sb.Length - 1, 1);
                string strReplace = sb.ToString();
                strSQL_SampleGroupID = strSQL_SampleGroupID.Replace("*", strReplace);
                arlSQL.Add(strSQL_SampleGroupID);
                arlParm.AddRange(p_objSchVO.m_strSampleGroupIDArr);
            }
            if (p_objSchVO.m_strApplyUnitIDArr != null && p_objSchVO.m_strApplyUnitIDArr.Length > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < p_objSchVO.m_strApplyUnitIDArr.Length; i++)
                {
                    sb.Append("?,");
                }
                sb.Remove(sb.Length - 1, 1);
                string strReplace = sb.ToString();
                strSQL_UnitID = strSQL_UnitID.Replace("*", strReplace);
                arlSQL.Add(strSQL_UnitID);
                arlParm.AddRange(p_objSchVO.m_strApplyUnitIDArr);
            }
            if (p_objSchVO.m_strPatientName != null && p_objSchVO.m_strPatientName.ToString().Trim() != "")
            {
                arlSQL.Add(strSQL_PatientName);
                arlParm.Add("%" + p_objSchVO.m_strPatientName.Trim() + "%");
            }
            if (p_objSchVO.m_strBarCode != null && p_objSchVO.m_strBarCode.ToString().Trim() != "")
            {
                arlSQL.Add(strSQL_BarCode);
                arlParm.Add(p_objSchVO.m_strBarCode.Trim());
            }


            if (p_objSchVO.m_strFromDatApp != null && Microsoft.VisualBasic.Information.IsDate(p_objSchVO.m_strFromDatApp.Trim()))
            {
                arlSQL.Add(strSQL_FromDateApp);
                arlParm.Add(p_objSchVO.m_strFromDatApp.Trim());
            }
            if (p_objSchVO.m_strToDatApp != null && Microsoft.VisualBasic.Information.IsDate(p_objSchVO.m_strToDatApp.Trim()))
            {
                arlSQL.Add(strSQL_ToDateApp);
                arlParm.Add(p_objSchVO.m_strToDatApp.Trim());
            }
            if (p_objSchVO.m_strInhospNO != null && p_objSchVO.m_strInhospNO.ToString().Trim() != "")
            {
                arlSQL.Add(strSQL_InhospNO);
                arlParm.Add(p_objSchVO.m_strInhospNO.Trim());
            }
            if (p_objSchVO.m_strBedNO != null && p_objSchVO.m_strBedNO.ToString().Trim() != "")
            {
                arlSQL.Add(strSQL_BedNO);
                arlParm.Add(p_objSchVO.m_strBedNO.Trim());
            }
            if (p_objSchVO.m_strAppDept != null && p_objSchVO.m_strAppDept.ToString().Trim() != "")
            {
                arlSQL.Add(strSQL_AppDept);
                arlParm.Add(p_objSchVO.m_strAppDept.Trim());
            }
            if (p_objSchVO.m_strAppDoct != null && p_objSchVO.m_strAppDoct.ToString().Trim() != "")
            {
                arlSQL.Add(strSQL_AppDoct);
                arlParm.Add(p_objSchVO.m_strAppDoct.Trim());
            }
            if (!string.IsNullOrEmpty(p_strCheckCategory))
            {
                arlSQL.Add(strSQL_CheckCategory);
                arlParm.Add(p_strCheckCategory);
            }
            #endregion

            foreach (object obj in arlSQL)
            {
                strSQL += obj.ToString();
            }
            string strConfirmDate = DateTime.Now.ToString();
            if (arrCat.Count > 0) //伦教7013参数，跳过核收状态查询
            {
                string sql_sub1 = "";
                string sql_sub2 = "";
                strSQL += @"
          union
          ";
                sql_sub1 = @"select distinct t2.application_id_chr, t2.patientid_chr,
                          t2.application_dat, t2.sex_chr,
                          t2.patient_name_vchr, t2.patient_subno_chr,
                          t2.age_chr, t2.patient_type_id_chr,
                          t2.diagnose_vchr, t2.bedno_chr, t2.icdcode_chr,
                          t2.patientcardid_chr, t2.application_form_no_chr,
                          t2.modify_dat, t2.operator_id_chr,
                          t2.appl_empid_chr, t2.appl_deptid_chr,
                          t2.summary_vchr, t2.pstatus_int, t2.emergency_int,
                          t2.special_int, t2.form_int,
                          t2.patient_inhospitalno_chr, t2.sample_type_id_chr,
                          t2.check_content_vchr, t2.sample_type_vchr,
                          t2.oringin_dat, t2.charge_info_vchr, t2.printed_num,
                          t2.orderunitrelation_vchr, t2.printed_date,
                          t1.report_group_id_chr report_group_id_chr_report,
                          t1.modify_dat modify_dat_report,
                          t1.operator_id_chr operator_id_chr_report,
                          t1.status_int status_int_report,
                          t1.report_dat report_dat_report,
                          t1.reportor_id_chr reportor_id_chr_report,
                          t1.confirm_dat confirm_dat_report,
                          t1.confirmer_id_chr confirmer_id_chr_report,
                          t4.sample_id_chr, t4.modify_dat as modify_dat_sample, t4.accept_dat, , t4.barcode_vchr, 
                          t5.isgreen_int
                     from t_opr_lis_app_report t1,
                          t_opr_lis_application t2,
                          t_opr_lis_app_sample t3,
                          t_opr_lis_sample t4,
                          t_opr_attachrelation t5,
                          t_aid_lis_sample_group e,
                          t_bse_lis_check_category f
                    where t1.application_id_chr = t2.application_id_chr
                      and t1.application_id_chr = t3.application_id_chr
                      and t1.application_id_chr = t5.attachid_vchr(+)
                      and t2.pstatus_int + 0 = 2
                      and t2.application_id_chr = t4.application_id_chr
                      and t3.sample_group_id_chr = e.sample_group_id_chr
                      and e.check_category_id_chr = f.check_category_id_chr
                      and t4.status_int = 2 ";
                foreach (object obj in arlSQL)
                { sql_sub2 += obj.ToString(); }
                sql_sub1 += sql_sub2.Replace("t4.accept_dat", "t4.sampling_date_dat");
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@" and f.check_category_id_chr in (");
                foreach (string s in arrCat)
                {
                    sb.Append("? ,");
                }
                sql_sub1 += sb.Remove(sb.Length - 2, 2).ToString() + ")";
                strSQL += sql_sub1;

                int intParmCount = arlParm.Count + arrCat.Count;
                #region 自动核收7013设定样本组标本

                objDPArr = null;
                objHRPSvc.CreateDatabaseParameter(intParmCount, out objDPArr);
                int i2 = 0;
                for (int i = 0; i < intParmCount; i++) //传参数
                {
                    if (i < arlParm.Count)
                    { objDPArr[i].Value = arlParm[i]; }
                    else
                    { objDPArr[i].Value = arrCat[i2]; i2++; }
                }
                dtbResult = null;
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(sql_sub1, ref dtbResult, objDPArr);
                DataRow dr = null;
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {//批量核收标本
                    try
                    {
                        sql_sub1 = @"update t_opr_lis_sample
                                        set status_int = 3,
                                            accept_dat = ?,
                                            acceptor_id_chr = ?
                                      where sample_id_chr = ? and modify_dat = ?";
                        lngRes = 0;
                        System.Collections.ArrayList arrValues = new System.Collections.ArrayList();
                        com.digitalwave.iCare.ValueObject.clsAcceptSampleBatch_VO[] objSamCondiction = new clsAcceptSampleBatch_VO[dtbResult.Rows.Count];
                        for (int j1 = 0; j1 < dtbResult.Rows.Count; j1++)
                        {
                            dr = dtbResult.Rows[j1];
                            objSamCondiction[j1] = new clsAcceptSampleBatch_VO();
                            objSamCondiction[j1].strReceiveEmp = p_objSchVO.m_strLoginEmpNo;
                            objSamCondiction[j1].strSampleID = dr["sample_id_chr"].ToString();
                            DateTime.TryParse(dr["modify_dat_sample"].ToString(), out objSamCondiction[j1].datModifyDat);
                        }
                        DbType[] dbTypes = new DbType[] { DbType.DateTime, DbType.String, DbType.String, DbType.DateTime };
                        object[][] objValues = new object[4][];
                        for (int i = 0; i < objValues.Length; i++)
                        { objValues[i] = new object[objSamCondiction.Length]; }
                        for (int i5 = 0; i5 < objSamCondiction.Length; i5++)
                        {
                            int n = 0;
                            objValues[n++][i5] = Convert.ToDateTime(strConfirmDate);
                            objValues[n++][i5] = objSamCondiction[i5].strReceiveEmp;
                            objValues[n++][i5] = objSamCondiction[i5].strSampleID;
                            objValues[n++][i5] = objSamCondiction[i5].datModifyDat;
                        }
                        lngRes = objHRPSvc.m_lngSaveArrayWithParameters(sql_sub1, objValues, dbTypes);
                    }
                    catch (Exception objEx)
                    {

                        throw (objEx);
                    }
                }

                #endregion

                intParmCount = arlParm.Count * 2 + arrCat.Count;

                objDPArr = null;
                objHRPSvc.CreateDatabaseParameter(intParmCount, out objDPArr);

                int j = 0;
                for (int i = 0; i < intParmCount; i++)
                {
                    if (i < (intParmCount - arrCat.Count) / 2)
                    {
                        objDPArr[i].Value = objDPArr[i + arlParm.Count].Value = arlParm[i];
                    }
                    if (i > arlParm.Count * 2 - 1)
                    {
                        objDPArr[i].Value = arrCat[j];
                        j++;
                    }
                }
            }
            else
            {
                //strSQL += ") order by to_char(accept_dat,'yyyy-mm-dd') asc, lpad(application_form_no_chr,12,'0') asc";
                int intParmCount = arlParm.Count;

                objDPArr = null;
                objHRPSvc.CreateDatabaseParameter(intParmCount, out objDPArr);

                for (int i = 0; i < intParmCount; i++)
                {
                    objDPArr[i].Value = arlParm[i];
                }
            }
            strSQL += ") order by to_char(accept_dat,'yyyy-mm-dd') asc, lpad(application_form_no_chr,12,'0') asc";

            try
            {
                dtbResult = null;
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    System.Collections.ArrayList arlApp = new ArrayList();
                    //					System.Data.DataRow[] dtrResultArr = dtbResult.Select("","application_id_chr");
                    for (int i = 0; i < dtbResult.Rows.Count; i++)
                    {
                        clsLisApplMainVO objMainVO = new clsVOConstructor().m_objConstructAppMainVO(dtbResult.Rows[i]);
                        //clsLisApplMainVO objMainVO = new clsLisApplMainVO();
                        objMainVO.m_strReportGroupID = dtbResult.Rows[i]["REPORT_GROUP_ID_CHR_Report"].ToString().Trim();
                        objMainVO.m_strReportDate = dtbResult.Rows[i]["CONFIRM_DAT_Report"].ToString();             //.Trim();
                        objMainVO.m_intReportStatus = int.Parse(dtbResult.Rows[i]["status_int_Report"].ToString());  //.Trim());
                        objMainVO.m_strOriginDate = dtbResult.Rows[i]["oringin_dat"].ToString();                    //.Trim();
                        objMainVO.m_strSamplingDate = dtbResult.Rows[i]["sampling_date_dat"].ToString();            //.Trim();
                        //objMainVO.m_strCheckContent = dtbResult.Rows[i]["check_content_vchr"].ToString();
                        //objMainVO.m_strPatient_Name = dtbResult.Rows[i]["patient_name_vchr"].ToString();
                        //objMainVO.m_strApplication_Form_NO = dtbResult.Rows[i]["application_form_no_chr"].ToString();
                        //objMainVO.m_strPatientcardID = dtbResult.Rows[i]["patientcardid_chr"].ToString();
                        if (dtbResult.Rows[i]["accept_dat"] != DBNull.Value)
                        {
                            objMainVO.m_strAcceptDate = ((DateTime)dtbResult.Rows[i]["accept_dat"]).ToString("yyyy-MM-dd HH:mm:ss");
                        }
                        objMainVO.m_strPrintDate = dtbResult.Rows[i]["printed_date"].ToString();//.Trim();
                        if (dtbResult.Rows[i]["printed_num"] != System.DBNull.Value)
                        {
                            if (dtbResult.Rows[i]["printed_num"].ToString().Trim() == "0")
                            {
                                objMainVO.m_isPrinted = false;
                            }
                            else if (dtbResult.Rows[i]["printed_num"].ToString().Trim() == "1")
                            {
                                objMainVO.m_isPrinted = true;
                            }
                        }
                        arlApp.Add(objMainVO);
                    }
                    p_objAppVOArr = (clsLisApplMainVO[])arlApp.ToArray(typeof(clsLisApplMainVO));
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                p_objAppVOArr = null;
            }
            return lngRes;
        }

        #endregion
    }
}
