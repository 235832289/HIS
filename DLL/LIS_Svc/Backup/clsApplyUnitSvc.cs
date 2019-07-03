using System;
using System.Data;
using System.Collections;
using System.EnterpriseServices;
using Microsoft.VisualBasic;
using com.digitalwave.Utility; //Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
namespace com.digitalwave.iCare.middletier.LIS
{
    /// <summary>
    /// clsApplyUnitSvc 的摘要说明。
    /// 
    /// </summary>
    [Transaction(TransactionOption.Required)]
    [ObjectPooling(Enabled = true)]
    public class clsApplyUnitSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase//MiddleTierBase.dll
    {
        #region 构造函数
        public clsApplyUnitSvc()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        #endregion

        //        #region 根据一组申请单元ID得到其所包含的样本ID列表  
        //        [AutoComplete]
        //        public long m_lngGetSampleTypeIDList(System.Security.Principal.IPrincipal p_objPrincipal,
        //            string[] p_strApplyUnitIDArr,
        //            out string[] p_strSampleTypeIDArr)
        //        {
        //            long lngRes = 0;
        //            p_strSampleTypeIDArr = null;

        //            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsAppGroupSvc","m_lngGetSampleTypeIDList");
        //            if(lngRes < 0)
        //            {
        //                return -1;
        //            }

        //            string strSQL = @"SELECT DISTINCT sample_type_id_chr FROM t_aid_lis_apply_unit 							     
        //						  	   WHERE apply_unit_id_chr in(#)";
        //            System.Text.StringBuilder sb = new System.Text.StringBuilder();
        //            if(p_strApplyUnitIDArr != null)
        //            {
        //                for(int i=0;i<p_strApplyUnitIDArr.Length;i++)
        //                {
        //                    sb.Append("?,");
        //                }
        //                if(sb.Length >0)
        //                    sb.Remove(sb.Length-1,1);
        //            }
        //            string strRep = sb.ToString();
        //            if(strRep.Trim() == "")
        //                return 1;
        //            strSQL = strSQL.Replace("#",strRep);
        //            try
        //            {
        //                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

        //                DataTable dtbResult = null;
        //                IDataParameter[] objDPArr = null;
        //                objHRPSvc.CreateDatabaseParameter(p_strApplyUnitIDArr.Length,out objDPArr);
        //                for(int i=0;i<p_strApplyUnitIDArr.Length;i++)
        //                {
        //                    objDPArr[i].Value = p_strApplyUnitIDArr[i];
        //                }

        //                lngRes = 0;
        //                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL,ref dtbResult,objDPArr);
        //                objHRPSvc.Dispose();
        //                if(lngRes >0 && dtbResult != null && dtbResult.Rows.Count != 0)
        //                {
        //                    ArrayList arlTemp = new ArrayList();
        //                    foreach(DataRow dr in dtbResult.Rows)
        //                    {
        //                        string strid = dr["SAMPLE_TYPE_ID_CHR"].ToString().Trim();
        //                        if(strid != "")
        //                        {
        //                            arlTemp.Add(strid);
        //                        }
        //                    }
        //                    p_strSampleTypeIDArr = (string[])arlTemp.ToArray(typeof(string));
        //                }
        //            }
        //            catch(Exception objEx)
        //            {
        //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //                bool blnRes = objLogger.LogError(objEx);
        //            }
        //            return lngRes;
        //        }
        //        #endregion


        #region 更新申请单元
        [AutoComplete]
        public long m_lngSetApplyUnit(System.Security.Principal.IPrincipal p_objPrincipal, clsApplUnit_VO p_objApplyUnit, ArrayList p_arlAddDetail,
            ArrayList p_arlRemoveDetail)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplyUnitSvc", "m_lngSetApplyUnit");
            if (lngRes < 0)
            {
                return -1;
            }

            //1.更新申请单元的基本资料
            lngRes = m_lngSetApplUnit(p_objPrincipal, ref p_objApplyUnit);
            if (lngRes > 0)
            {
                if (p_arlRemoveDetail != null && p_arlRemoveDetail.Count > 0)
                {
                    //2.删除申请单元明细中的检验项目
                    for (int i = 0; i < p_arlRemoveDetail.Count; i++)
                    {
                        lngRes = m_lngDelApplyUnitDetailByApplyIDAndCheckItemID(p_objPrincipal, ((clsApplUnitDetail_VO)p_arlRemoveDetail[i]));
                    }
                }
                if (p_arlAddDetail != null && p_arlAddDetail.Count > 0)
                {
                    //3.增加申请单元明细中的检验项目
                    for (int i = 0; i < p_arlAddDetail.Count; i++)
                    {
                        clsApplUnitDetail_VO objDetail = (clsApplUnitDetail_VO)p_arlAddDetail[i];
                        lngRes = m_lngAddApplUnitDetail(p_objPrincipal, ref objDetail);
                    }
                }
            }
            return lngRes;
        }
        #endregion

        #region 根据申请单元ID和检验项目ID删除申请单元明细信息
        [AutoComplete]
        public long m_lngDelApplyUnitDetailByApplyIDAndCheckItemID(System.Security.Principal.IPrincipal p_objPrincipal,
            clsApplUnitDetail_VO p_objRecord)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplyUnitSvc", "m_lngDelApplyUnitDetailByApplyIDAndCheckItemID");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"DELETE FROM t_aid_lis_apply_unit_detail
							   WHERE check_item_id_chr = '" + p_objRecord.strCheckItemID + @"'
								 AND apply_unit_id_chr = '" + p_objRecord.strApplUnitID + "'";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                long lngRecEff = -1;
                lngRes = objHRPSvc.DoExcuteForDelete(strSQL, ref lngRecEff);
                if (lngRecEff > -1)
                {
                    lngRes = 1;
                }
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

        //        #region 根据检验类别获取申请单元  
        //        [AutoComplete]
        //        public long m_lngGetApplUnitByCheckCategory(System.Security.Principal.IPrincipal p_objPrincipal,string p_strCheckCategory,
        //            out clsApplUnit_VO[] p_objResultArr)
        //        {
        //            long lngRes = 0;
        //            p_objResultArr = null;

        //            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsApplyUnitSvc","m_lngGetAllApplUnit");
        //            if(lngRes < 0)
        //            {
        //                return -1;
        //            }

        //            string strSQL = @"select apply_unit_id_chr, apply_unit_name_vchr, other_name_vchr, py_code_chr,
        //                                   assist_code01_chr, wb_code_chr, assist_code02_chr,
        //                                   check_category_id_chr, is_no_food_required_chr,
        //                                   is_physical_exam_required_chr, is_reservation_required_chr, price_num,
        //                                   cost_num, sample_type_id_chr, summary_vchr, outer_check_flag_num
        //                              from t_aid_lis_apply_unit
        //                              where CHECK_CATEGORY_ID_CHR = '" + p_strCheckCategory + @"' ORDER BY apply_unit_id_chr";
        //            DataTable dtbApplUnit = null;
        //            try
        //            {
        //                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbApplUnit);
        //                objHRPSvc.Dispose();
        //                if(lngRes > 0 && dtbApplUnit != null)
        //                {
        //                    if(dtbApplUnit.Rows.Count > 0)
        //                    {
        //                        p_objResultArr = new clsApplUnit_VO[dtbApplUnit.Rows.Count];
        //                        for(int i=0;i<dtbApplUnit.Rows.Count;i++)
        //                        {
        //                            p_objResultArr[i] = new clsApplUnit_VO();
        //                            ConstructApplUnitVO(dtbApplUnit.Rows[i],ref p_objResultArr[i]);
        //                        }
        //                    }
        //                }
        //            }
        //            catch(Exception objEx)
        //            {
        //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //                bool blnRes = objLogger.LogError(objEx);
        //            }
        //            return lngRes;
        //        }
        //        #endregion

        //        #region 根据申请单元ID得到申请单元VO 
        //        [AutoComplete]
        //        public long m_lngGetApplyUnitVOByApplyUnitID(System.Security.Principal.IPrincipal p_objPrincipal,
        //            string p_strApplyUnitID,
        //            out clsApplUnit_VO p_objApplUnit)
        //        {
        //            long lngRes = 0;
        //            p_objApplUnit = null;

        //            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsAppGroupSvc","m_lngGetApplyUnitVOByApplyUnitID");
        //            if(lngRes < 0)
        //            {
        //                return -1;
        //            }

        //            string strSQL = @"select apply_unit_id_chr, apply_unit_name_vchr, other_name_vchr, py_code_chr,
        //                                   assist_code01_chr, wb_code_chr, assist_code02_chr,
        //                                   check_category_id_chr, is_no_food_required_chr,
        //                                   is_physical_exam_required_chr, is_reservation_required_chr, price_num,
        //                                   cost_num, sample_type_id_chr, summary_vchr, outer_check_flag_num
        //                              from t_aid_lis_apply_unit
        //                             where apply_unit_id_chr = ?";

        //            try
        //            {
        //                clsHRPTableService objHRPSvc = new clsHRPTableService();
        //                DataTable dtbResult = null;
        //                IDataParameter[] objDPArr = null;
        //                objHRPSvc.CreateDatabaseParameter(1,out objDPArr);
        //                objDPArr[0].Value = p_strApplyUnitID;

        //                lngRes = 0;
        //                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL,ref dtbResult,objDPArr);
        //                objHRPSvc.Dispose();
        //                if(lngRes >0 && dtbResult != null && dtbResult.Rows.Count != 0)
        //                {
        //                    p_objApplUnit = new clsApplUnit_VO();
        //                    ConstructApplUnitVO(dtbResult.Rows[0],ref p_objApplUnit);
        //                }
        //            }
        //            catch(Exception objEx)
        //            {
        //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //                bool blnRes = objLogger.LogError(objEx);
        //            }
        //            return lngRes;
        //        }
        //        #endregion

        #region 更新申请单元的基本资料
        [AutoComplete]
        public long m_lngSetApplUnit(System.Security.Principal.IPrincipal p_objPrincipal, ref clsApplUnit_VO objApplUnit)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsAppGroupSvc", "m_lngSetApplUnit");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"UPDATE t_aid_lis_apply_unit
							     SET apply_unit_name_vchr = ?,
									 other_name_vchr = ?,
									 py_code_chr = ?,
									 assist_code01_chr = ?,
									 wb_code_chr = ?,
									 assist_code02_chr = ?,
									 check_category_id_chr = ?,
									 is_no_food_required_chr = ?,
									 is_physical_exam_required_chr = ?,
									 is_reservation_required_chr = ?,
									 PRICE_NUM = ?,
									 COST_NUM = ?,
									 SAMPLE_TYPE_ID_CHR = ?,
									 SUMMARY_VCHR = ?,
									 OUTER_CHECK_FLAG_NUM = ?,
                                     REPORTHOUR = ?,
                                     SamplingInstr = ? 
						  	   WHERE apply_unit_id_chr = ? ";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] objApplUnitArr = null;
                objHRPSvc.CreateDatabaseParameter(18, out objApplUnitArr);

                objApplUnitArr[0].Value = objApplUnit.strApplUnitName;
                objApplUnitArr[1].Value = objApplUnit.strOtherName;
                objApplUnitArr[2].Value = objApplUnit.strPYCode;
                objApplUnitArr[3].Value = objApplUnit.strAssistCode01;
                objApplUnitArr[4].Value = objApplUnit.strWBCode;
                objApplUnitArr[5].Value = objApplUnit.strAssistCode02;
                objApplUnitArr[6].Value = objApplUnit.strCheckCategoryID;
                objApplUnitArr[7].Value = objApplUnit.strIsNoFoodRequired;
                objApplUnitArr[8].Value = objApplUnit.strIsPhysicsExamRequired;
                objApplUnitArr[9].Value = objApplUnit.strIsReservationRequired;
                objApplUnitArr[10].Value = objApplUnit.strPrice;
                objApplUnitArr[11].Value = objApplUnit.strCost;
                objApplUnitArr[12].Value = objApplUnit.strSampleTypeID;
                objApplUnitArr[13].Value = objApplUnit.strSummary;
                objApplUnitArr[14].Value = objApplUnit.strOutCheckFlag;
                objApplUnitArr[15].Value = objApplUnit.ReportHour;
                objApplUnitArr[16].Value = objApplUnit.SamplingInstr;
                objApplUnitArr[17].Value = objApplUnit.strApplUnitID;

                long lngRecEff = -1;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, objApplUnitArr);
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

        #region 删除申请单元及其明细
        [AutoComplete]
        public long m_lngDelApplUnitAndDetail(System.Security.Principal.IPrincipal p_objPrincipal, string strApplUnitID)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsAppGroupSvc", "m_lngDelApplUnitAndDetail");
            if (lngRes < 0)
            {
                return -1;
            }

            lngRes = m_lngDelApplUnitDetail(p_objPrincipal, strApplUnitID);

            if (lngRes > 0)
            {
                lngRes = m_lngDelApplUnit(p_objPrincipal, strApplUnitID);
            }
            return lngRes;
        }
        #endregion

        #region 删除申请单元明细
        [AutoComplete]
        public long m_lngDelApplUnitDetail(System.Security.Principal.IPrincipal p_objPrincipal, string strApplUnitID)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsAppGroupSvc", "m_lngDelApplUnitDetail");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"DELETE FROM t_aid_lis_apply_unit_detail WHERE apply_unit_id_chr = '" + strApplUnitID + "'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                long lngRecEff = -1;
                lngRes = objHRPSvc.DoExcuteForDelete(strSQL, ref lngRecEff);
                if (lngRecEff > -1)
                {
                    lngRes = 1;
                }
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

        #region 删除申请单元
        [AutoComplete]
        public long m_lngDelApplUnit(System.Security.Principal.IPrincipal p_objPrincipal, string strApplUnitID)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsAppGroupSvc", "m_lngDelApplUnit");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"DELETE FROM t_aid_lis_apply_unit WHERE apply_unit_id_chr = '" + strApplUnitID + "'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                long lngRecEff = -1;
                lngRes = objHRPSvc.DoExcuteForDelete(strSQL, ref lngRecEff);
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

        #region 保存申请单元及其明细
        [AutoComplete]
        public long m_lngAddApplUnitAndDetail(System.Security.Principal.IPrincipal p_objPrincipal, ref clsApplUnit_VO objApplUnitVO, ref clsApplUnitDetail_VO[] objApplUnitDetailVOList)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplyUnitSvc", "m_lngAddApplUnitAndDetail");
            if (lngRes < 0)
            {
                return -1;
            }

            if (objApplUnitVO.strApplUnitID == null)
            {
                lngRes = m_lngAddApplUnit(p_objPrincipal, ref objApplUnitVO);
            }
            else
            {
                lngRes = m_lngSetApplUnit(p_objPrincipal, ref objApplUnitVO);
            }
            if (lngRes > 0)
            {
                for (int i = 0; i < objApplUnitDetailVOList.Length; i++)
                {
                    objApplUnitDetailVOList[i].strApplUnitID = objApplUnitVO.strApplUnitID;
                    lngRes = m_lngAddApplUnitDetail(p_objPrincipal, ref objApplUnitDetailVOList[i]);
                }
            }
            return lngRes;
        }
        #endregion

        #region 保存一条记录到t_aid_lis_apply_unit_detail
        [AutoComplete]
        public long m_lngAddApplUnitDetail(System.Security.Principal.IPrincipal p_objPrincipal, ref clsApplUnitDetail_VO objApplUnitDetailVO)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplyUnitSvc", "m_lngAddApplUnitDetail");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"INSERT INTO t_aid_lis_apply_unit_detail
										  (check_item_id_chr, apply_unit_id_chr
										  )
								   VALUES (?, ?)";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] objApplUnitDetailArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out objApplUnitDetailArr);

                objApplUnitDetailArr[0].Value = objApplUnitDetailVO.strCheckItemID;
                objApplUnitDetailArr[1].Value = objApplUnitDetailVO.strApplUnitID;

                long lngRecEff = -1;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, objApplUnitDetailArr);
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

        #region 保存一条记录到条t_aid_lis_apply_unit表
        [AutoComplete]
        public long m_lngAddApplUnit(System.Security.Principal.IPrincipal p_objPrincipal, ref clsApplUnit_VO objApplUnitVO)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsApplyUnitSvc", "m_lngAddApplyUnit");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"INSERT INTO t_aid_lis_apply_unit
										  (apply_unit_id_chr, apply_unit_name_vchr, other_name_vchr,
										   py_code_chr, assist_code01_chr, wb_code_chr, assist_code02_chr,
										   check_category_id_chr, is_no_food_required_chr,
										   is_physical_exam_required_chr,is_reservation_required_chr,
										   PRICE_NUM,COST_NUM,SAMPLE_TYPE_ID_CHR,SUMMARY_VCHR,OUTER_CHECK_FLAG_NUM, REPORTHOUR, SamplingInstr 
										   )
								    VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?,?,?, ?, ?)";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] objApplUnitArr = null;
                objHRPSvc.CreateDatabaseParameter(18, out objApplUnitArr);

                if (objApplUnitVO.strApplUnitID == null)
                {
                    objApplUnitVO.strApplUnitID = objHRPSvc.m_strGetNewID("t_aid_lis_apply_unit", "apply_unit_id_chr", 6);
                }

                objApplUnitArr[0].Value = objApplUnitVO.strApplUnitID;
                objApplUnitArr[1].Value = objApplUnitVO.strApplUnitName;
                objApplUnitArr[2].Value = objApplUnitVO.strOtherName;
                objApplUnitArr[3].Value = objApplUnitVO.strPYCode;
                objApplUnitArr[4].Value = objApplUnitVO.strAssistCode01;
                objApplUnitArr[5].Value = objApplUnitVO.strWBCode;
                objApplUnitArr[6].Value = objApplUnitVO.strAssistCode02;
                objApplUnitArr[7].Value = objApplUnitVO.strCheckCategoryID;
                objApplUnitArr[8].Value = objApplUnitVO.strIsNoFoodRequired;
                objApplUnitArr[9].Value = objApplUnitVO.strIsPhysicsExamRequired;
                objApplUnitArr[10].Value = objApplUnitVO.strIsReservationRequired;
                objApplUnitArr[11].Value = objApplUnitVO.strPrice;
                objApplUnitArr[12].Value = objApplUnitVO.strCost;
                objApplUnitArr[13].Value = objApplUnitVO.strSampleTypeID;
                objApplUnitArr[14].Value = objApplUnitVO.strSummary;
                objApplUnitArr[15].Value = objApplUnitVO.strOutCheckFlag;
                objApplUnitArr[16].Value = objApplUnitVO.ReportHour;
                objApplUnitArr[17].Value = objApplUnitVO.SamplingInstr;

                long lngRecEff = -1;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, objApplUnitArr);
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

        //        #region 获取所有的申请单元组合 
        //        /// <summary>
        //        /// 
        //        /// </summary>
        //        /// <param name="p_objPrincipal"></param>
        //        /// <param name="objApplUnitVOList"></param>
        //        /// <returns></returns>
        //        [AutoComplete]
        //        public long m_lngGetAllApplUnit(System.Security.Principal.IPrincipal p_objPrincipal,out clsApplUnit_VO[] objApplUnitVOList)
        //        {
        //            long lngRes = 0;
        //            objApplUnitVOList = null;

        //            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsApplyUnitSvc","m_lngGetAllApplUnit");
        //            if(lngRes < 0)
        //            {
        //                return -1;
        //            }

        //            string strSQL = @"select apply_unit_id_chr, apply_unit_name_vchr, other_name_vchr, py_code_chr,
        //                                   assist_code01_chr, wb_code_chr, assist_code02_chr,
        //                                   check_category_id_chr, is_no_food_required_chr,
        //                                   is_physical_exam_required_chr, is_reservation_required_chr, price_num,
        //                                   cost_num, sample_type_id_chr, summary_vchr, outer_check_flag_num
        //                              from t_aid_lis_apply_unit";

        //            DataTable dtbApplUnit = null;
        //            try
        //            {
        //                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbApplUnit);
        //                objHRPSvc.Dispose();
        //                if(lngRes > 0 && dtbApplUnit != null)
        //                {
        //                    if(dtbApplUnit.Rows.Count > 0)
        //                    {
        //                        objApplUnitVOList = new clsApplUnit_VO[dtbApplUnit.Rows.Count];
        //                        for(int i=0;i<dtbApplUnit.Rows.Count;i++)
        //                        {
        //                            objApplUnitVOList[i] = new clsApplUnit_VO();
        //                            ConstructApplUnitVO(dtbApplUnit.Rows[i],ref objApplUnitVOList[i]);
        //                        }
        //                    }
        //                }
        //            }
        //            catch(Exception objEx)
        //            {
        //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //                bool blnRes = objLogger.LogError(objEx);
        //            }
        //            return lngRes;
        //        }
        //        #endregion

        //        #region 获取所有的申请单元明细
        //        [AutoComplete]
        //        public long m_lngGetAllApplUnitDetail(System.Security.Principal.IPrincipal p_objPrincipal,out clsApplUnitDetail_VO[] objApplUnitDetailVOList)
        //        {
        //            long lngRes = 0;
        //            objApplUnitDetailVOList = null;

        //            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsCheckGroupSvc","m_lngGetAllApplUnitDetail");
        //            if(lngRes < 0)
        //            {
        //                return -1;
        //            }

        //            string strSQL = @"select check_item_id_chr, apply_unit_id_chr, print_seq_int
        //                                from t_aid_lis_apply_unit_detail";
        //            DataTable dtbApplUnitDetail = null;
        //            try
        //            {
        //                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbApplUnitDetail);
        //                objHRPSvc.Dispose();
        //                if(lngRes > 0 && dtbApplUnitDetail != null)
        //                {
        //                    if(dtbApplUnitDetail.Rows.Count > 0)
        //                    {
        //                        objApplUnitDetailVOList = new clsApplUnitDetail_VO[dtbApplUnitDetail.Rows.Count];
        //                        for(int i=0;i<dtbApplUnitDetail.Rows.Count;i++)
        //                        {
        //                            objApplUnitDetailVOList[i] = new clsApplUnitDetail_VO();
        //                            ConstructApplUnitDetailVO(dtbApplUnitDetail.Rows[i],ref objApplUnitDetailVOList[i]);
        //                        }
        //                    }
        //                }
        //            }
        //            catch(Exception objEx)
        //            {
        //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //                bool blnRes = objLogger.LogError(objEx);
        //            }
        //            return lngRes;
        //        }
        //        #endregion

        #region 构造claApplUnitDetail_VO
        [AutoComplete]
        private void ConstructApplUnitDetailVO(System.Data.DataRow objRow, ref clsApplUnitDetail_VO objApplUnitDetailVOList)
        {
            objApplUnitDetailVOList.strApplUnitID = objRow["APPLY_UNIT_ID_CHR"].ToString().Trim();
            objApplUnitDetailVOList.strCheckItemID = objRow["CHECK_ITEM_ID_CHR"].ToString().Trim();
        }
        #endregion

        #region 构造clsApplUnitVO
        [AutoComplete]
        private void ConstructApplUnitVO(System.Data.DataRow objRow, ref clsApplUnit_VO objApplUnitVO)
        {
            objApplUnitVO.strApplUnitID = objRow["APPLY_UNIT_ID_CHR"].ToString().Trim();
            objApplUnitVO.strApplUnitName = objRow["APPLY_UNIT_NAME_VCHR"].ToString().Trim();
            objApplUnitVO.strOtherName = objRow["OTHER_NAME_VCHR"].ToString().Trim();
            objApplUnitVO.strPYCode = objRow["PY_CODE_CHR"].ToString().Trim();
            objApplUnitVO.strWBCode = objRow["WB_CODE_CHR"].ToString().Trim();
            objApplUnitVO.strAssistCode01 = objRow["ASSIST_CODE01_CHR"].ToString().Trim();
            objApplUnitVO.strAssistCode02 = objRow["ASSIST_CODE02_CHR"].ToString().Trim();
            objApplUnitVO.strCheckCategoryID = objRow["CHECK_CATEGORY_ID_CHR"].ToString().Trim();
            objApplUnitVO.strIsNoFoodRequired = objRow["IS_NO_FOOD_REQUIRED_CHR"].ToString().Trim();
            objApplUnitVO.strIsPhysicsExamRequired = objRow["IS_PHYSICAL_EXAM_REQUIRED_CHR"].ToString().Trim();
            objApplUnitVO.strIsReservationRequired = objRow["IS_RESERVATION_REQUIRED_CHR"].ToString().Trim();
            objApplUnitVO.strPrice = objRow["PRICE_NUM"].ToString().Trim();
            objApplUnitVO.strCost = objRow["COST_NUM"].ToString().Trim();
            objApplUnitVO.strSampleTypeID = objRow["SAMPLE_TYPE_ID_CHR"].ToString().Trim();
            //xing.chen add	（备注字段）
            objApplUnitVO.strSummary = objRow["SUMMARY_VCHR"].ToString().Trim();
            //xing.chen add (是否外院标志字段)
            objApplUnitVO.strOutCheckFlag = objRow["OUTER_CHECK_FLAG_NUM"].ToString().Trim();
        }
        #endregion
    }
}
