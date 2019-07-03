using System;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
using System.Collections.Generic;

namespace com.digitalwave.iCare.middletier.LIS
{
    /// <summary>
    /// 酶标仪2010接口 中间件
    /// baojian.mo 2007-10-11
    /// </summary>
    [Transaction(TransactionOption.Required)]
    [ObjectPooling(Enabled = true)]
    public class clsMBY2010Svc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 插入报告单
        /// <summary>
        /// 插入报告单
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="instrumentFlag">0-酶标仪2010 1-Multiskan_Ascent</param>
        /// <param name="objResultArr"></param>
        /// <param name="datReportDate"></param>
        /// <returns></returns>
        [AutoComplete]
        public long lngInsertReport(System.Security.Principal.IPrincipal p_objPrincipal, int instrumentFlag, System.Collections.Generic.List<clsMBY2010VO> objResultArr, DateTime datReportDate)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsMBY2010Svc", "lngInsertReport");
            if (lngRes < 0)
            {
                return -1;
            }
            lngRes = 0;
            clsCheckResult_VO[] objCheckResultVO = null;
            List<string> strSampleIDArr = null;
            string strOriginDate = datReportDate.ToString();    //优化查询用
            //构造VO 
            this.m_mthContructResultVO(instrumentFlag, objResultArr, out objCheckResultVO, out strSampleIDArr, ref strOriginDate);

            if (strSampleIDArr.Count > 0)
            {
                clsAdvis2120Svc obj = new clsAdvis2120Svc();
                obj.m_lngAddCheckResultList(strSampleIDArr, strOriginDate);
            }

            if (objCheckResultVO == null || objCheckResultVO.Length == 0)
            {
                return lngRes;
            }

            #region 批量插入
            string SQL = @"insert into t_opr_lis_check_result(modify_dat, 
													   groupid_chr, 
													   check_item_id_chr, 
												       sample_id_chr, 
													   result_vchr, 
													   unit_vchr, 
													   deviceid_chr, 
													   device_check_item_name_vchr, 
													   refrange_vchr, 
													   check_item_name_vchr, 
													   check_item_english_name_vchr, 
													   min_val_dec, 
													   max_val_dec, 
													   abnormal_flag_chr, 
													   check_dat, 
													   clinicapp_vchr, 
													   memo_vchr, 
													   confirm_dat, 
													   pointliststr_vchr, 
													   summary_vchr, 
													   graph_img, 
													   status_int, 
													   checker1_chr, 
													   checker2_chr, 
													   confirm_person_chr, 
													   operator_id_chr, 
													   check_deptid_chr, 
													   graph_format_name_vchr, 
													   is_graph_result_num)
						                       values (?, ?, ?, ?,
                                                       ?, ?, ?,
                                                       ?, ?,
                                                       ?, ?, ?,
                                                       ?, ?, ?, ?,
                                                       ?, ?, ?, ?,
                                                       ?, ?, ?, ?,
                                                       ?, ?, ?,
                                                       ?, ?
                                                      )";
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();

                DbType[] dbTypes = new DbType[] { DbType.Date, DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, DbType.Decimal, DbType.Decimal, DbType.String, DbType.Date, DbType.String, DbType.String, DbType.Date, DbType.String, DbType.String, DbType.Binary, DbType.Int16, DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, DbType.String, DbType.Int16 };

                object[][] objValues = new object[29][];

                for (int i = 0; i < objValues.Length; i++)
                {
                    objValues[i] = new object[objCheckResultVO.Length];
                }

                for (int i = 0; i < objCheckResultVO.Length; i++)
                {
                    if (objCheckResultVO[i] == null)
                        return 2;
                    int n = 0;

                    objValues[n++][i] = Convert.ToDateTime(objCheckResultVO[i].m_strModify_Dat);
                    objValues[n++][i] = objCheckResultVO[i].m_strGroupID;
                    objValues[n++][i] = objCheckResultVO[i].m_strCheck_Item_ID;
                    objValues[n++][i] = objCheckResultVO[i].m_strSample_ID;
                    objValues[n++][i] = objCheckResultVO[i].m_strResult;
                    objValues[n++][i] = objCheckResultVO[i].m_strUnit;
                    objValues[n++][i] = objCheckResultVO[i].m_strDeviceID;
                    objValues[n++][i] = objCheckResultVO[i].m_strDevice_Check_Item_Name;
                    objValues[n++][i] = objCheckResultVO[i].m_strRefrange;
                    objValues[n++][i] = objCheckResultVO[i].m_strCheck_Item_Name;
                    objValues[n++][i] = objCheckResultVO[i].m_strCheck_Item_English_Name;
                    objValues[n++][i] = objCheckResultVO[i].m_strMin_Val;
                    objValues[n++][i] = objCheckResultVO[i].m_strMax_Val;
                    objValues[n++][i] = objCheckResultVO[i].m_strAbnormal_Flag;
                    if (objCheckResultVO[i].m_strCheck_Dat == null || objCheckResultVO[i].m_strCheck_Dat.Trim() == "")
                    {
                        objValues[n++][i] = System.DBNull.Value;
                    }
                    else
                    {
                        objValues[n++][i] = System.DateTime.Parse(objCheckResultVO[i].m_strCheck_Dat);
                    }
                    objValues[n++][i] = objCheckResultVO[i].m_strClinicApp;
                    objValues[n++][i] = objCheckResultVO[i].m_strMemo;
                    if (objCheckResultVO[i].m_strConfirm_Dat == null || objCheckResultVO[i].m_strConfirm_Dat.Trim() == "")
                    {
                        objValues[n++][i] = System.DBNull.Value;
                    }
                    else
                    {
                        objValues[n++][i] = System.DateTime.Parse(objCheckResultVO[i].m_strConfirm_Dat);
                    }
                    objValues[n++][i] = objCheckResultVO[i].m_strPointliststr;
                    objValues[n++][i] = objCheckResultVO[i].m_strSummary;
                    objValues[n++][i] = objCheckResultVO[i].m_byaGraph;
                    objValues[n++][i] = objCheckResultVO[i].m_intStatus;
                    objValues[n++][i] = objCheckResultVO[i].m_strChecker1;
                    objValues[n++][i] = objCheckResultVO[i].m_strChecker2;
                    objValues[n++][i] = objCheckResultVO[i].m_strConfirm_Person;
                    objValues[n++][i] = objCheckResultVO[i].m_strOperator_ID;
                    objValues[n++][i] = objCheckResultVO[i].m_strCheck_DeptID;
                    objValues[n++][i] = objCheckResultVO[i].strGraphFormatName;
                    objValues[n++][i] = objCheckResultVO[i].intIsGraphResult;
                }

                lngRes = objHRPSvc.m_lngSaveArrayWithParameters(SQL, objValues, dbTypes);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            #endregion

            return lngRes;
        }
        #endregion


        #region 构造插入t_opr_lis_check_result表的VO
        /// <summary>
        /// 构造插入t_opr_lis_check_result表的VO
        /// </summary>
        /// <param name="instrumentFlag">0-酶标仪2010 1-Multiskan_Ascent</param>
        /// <param name="objResultArr"></param>
        /// <param name="p_objCheckResultVO"></param>
        /// <param name="p_strSampleIDArr"></param>
        /// <param name="p_strOriginDate"></param>
        [AutoComplete]
        private void m_mthContructResultVO(int instrumentFlag, System.Collections.Generic.List<clsMBY2010VO> objResultArr, out clsCheckResult_VO[] p_objCheckResultVO, out List<string> p_strSampleIDArr, ref string p_strOriginDate)
        {
            p_objCheckResultVO = null;
            p_strSampleIDArr = new List<string>();
            if (objResultArr.Count > 0)
            {
                #region 生成检验编号，并根据检验编号查出对应信息

                //根据酶标仪传入的样本号生成检验编号
                string strSQL1 = @"select a.application_id_chr, a.application_form_no_chr, a.oringin_dat,
                                          b.sample_group_id_chr, to_char (a.modify_dat, 'yyyymmdd') as sampdate,
                                          b.sample_id_chr, c.check_item_id_chr, d.report_group_id_chr,
                                          e.check_item_name_vchr,
                                          lower (e.check_item_name_vchr) as check_item_name, e.unit_chr,
                                          e.ref_value_range_vchr, e.ref_max_val_vchr, e.ref_min_val_vchr
                                     from t_opr_lis_application a,
                                          t_opr_lis_app_sample b,
                                          t_opr_lis_app_check_item c,
                                          t_opr_lis_app_report d,
                                          t_bse_lis_check_item e
                                    where a.application_id_chr = b.application_id_chr
                                      and a.application_id_chr = c.application_id_chr
                                      and a.application_id_chr = d.application_id_chr
                                      and a.application_id_chr = d.application_id_chr
                                      and a.application_form_no_chr in (";
                string strSQL2 = @")
                               and a.pstatus_int > 0
                               and c.check_item_id_chr = e.check_item_id_chr
                               and d.status_int > 0
                               and trunc (a.modify_dat) = trunc (to_date (?, 'yyyy-mm-dd hh24:mi:ss '))";


                clsHRPTableService objHRPSvc = new clsHRPTableService();
                DataTable dtResult = new DataTable();
                System.Data.IDataParameter[] objParamArr = null;
                string strCheckNO = "";
                System.Collections.Hashtable has = new System.Collections.Hashtable();
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                if (instrumentFlag == 0)
                {
                    for (int i2 = 0; i2 < objResultArr.Count; i2++)
                    {
                        if (!has.ContainsKey(objResultArr[i2].m_strSampleId))
                        {
                            int intLength = objResultArr[i2].m_strSampleId.Length;
                            if (intLength < 11)
                                return;
                            string strTmp = "";
                            strTmp = objResultArr[i2].m_strSampleId.Substring(intLength - 3, 3);
                            strCheckNO = objResultArr[i2].m_strDeviceId + strTmp;

                            objResultArr[i2].m_strApplication_From_NO = strCheckNO;
                            has.Add(objResultArr[i2].m_strSampleId, strCheckNO);
                        }
                    }
                    objHRPSvc.CreateDatabaseParameter(has.Count + 1, out objParamArr);
                    int i3 = 0;
                    foreach (object obj in has.Values)
                    {
                        sb.Append("?,");
                        objParamArr[i3++].Value = obj.ToString();
                    }
                    objParamArr[has.Count].Value = Convert.ToDateTime(objResultArr[0].m_strSampleId.Substring(objResultArr[0].m_strSampleId.Length - 11, 8)).ToShortDateString();
                    sb.Remove(sb.Length - 1, 1);
                    string strSQL3 = sb.ToString();
                    string strSQL = strSQL1 + strSQL3 + strSQL2;                             //生成SQL语句
                    objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, objParamArr);
                    DataView dv = new DataView(dtResult);

                #endregion

                    has = new System.Collections.Hashtable();
                    p_objCheckResultVO = new clsCheckResult_VO[objResultArr.Count];
                    for (int i1 = 0; i1 < objResultArr.Count; i1++)
                    {
                        dv.RowFilter = "application_form_no_chr = '" + objResultArr[i1].m_strApplication_From_NO + "' and check_item_name like '%" + objResultArr[i1].m_strItemName.Substring(0, 5).ToLower() + "%' and sampdate = '" + objResultArr[i1].m_strSampleId.Substring(objResultArr[i1].m_strSampleId.Length - 11, 8) + "'";
                        if (dv.Count == 0)
                        {
                            objResultArr.RemoveAt(i1);
                            i1--;
                            continue;
                        }
                        p_objCheckResultVO[i1] = new clsCheckResult_VO();
                        p_objCheckResultVO[i1].intIsGraphResult = 0;                                           //*  (-- *为必填)
                        p_objCheckResultVO[i1].strGraphFormatName = null;
                        p_objCheckResultVO[i1].m_strModify_Dat = DateTime.Now.ToString();                                 //*
                        p_objCheckResultVO[i1].m_strGroupID = dv[0]["report_group_id_chr"].ToString();         //检验组合编号(报告组)(*)
                        p_objCheckResultVO[i1].m_strCheck_Item_ID = dv[0]["check_item_id_chr"].ToString();                //检验项目编号(*)
                        p_objCheckResultVO[i1].m_strSample_ID = dv[0]["sample_id_chr"].ToString();             //样本联号：指样本中心的顺序编号(*)
                        p_objCheckResultVO[i1].m_strResult = objResultArr[i1].m_strResult;
                        p_objCheckResultVO[i1].m_strUnit = dv[0]["unit_chr"].ToString();
                        p_objCheckResultVO[i1].m_strDeviceID = objResultArr[i1].m_strDeviceId;
                        p_objCheckResultVO[i1].m_strDevice_Check_Item_Name = objResultArr[i1].m_strItemName;   //检验仪器输出的检验结果的名称，或缩写。
                        p_objCheckResultVO[i1].m_strRefrange = dv[0]["ref_value_range_vchr"].ToString();       //参考值范围
                        p_objCheckResultVO[i1].m_strCheck_Item_Name = dv[0]["check_item_name_vchr"].ToString();//检验项目名称
                        p_objCheckResultVO[i1].m_strCheck_Item_English_Name = null;
                        p_objCheckResultVO[i1].m_strMin_Val = dv[0]["ref_min_val_vchr"].ToString();
                        p_objCheckResultVO[i1].m_strMax_Val = dv[0]["ref_max_val_vchr"].ToString();
                        p_objCheckResultVO[i1].m_strAbnormal_Flag = null;
                        p_objCheckResultVO[i1].m_strCheck_Dat = null;
                        p_objCheckResultVO[i1].m_strClinicApp = null;
                        p_objCheckResultVO[i1].m_strMemo = null;
                        p_objCheckResultVO[i1].m_strConfirm_Dat = null;
                        p_objCheckResultVO[i1].m_strPointliststr = null;
                        p_objCheckResultVO[i1].m_strSummary = null;
                        p_objCheckResultVO[i1].m_byaGraph = null;                                              //存放图像结果
                        p_objCheckResultVO[i1].m_intStatus = 1;                                                // 1-当前有效记录
                        p_objCheckResultVO[i1].m_strChecker1 = null;
                        p_objCheckResultVO[i1].m_strChecker2 = null;
                        p_objCheckResultVO[i1].m_strConfirm_Person = null;
                        p_objCheckResultVO[i1].m_strOperator_ID = objResultArr[i1].m_strOperator_ID;           //操作员工ID
                        p_objCheckResultVO[i1].m_strCheck_DeptID = null;
                        if (!has.ContainsKey(dv[0]["application_id_chr"].ToString()))
                        {
                            has.Add(dv[0]["application_id_chr"].ToString(), dv[0]["application_id_chr"].ToString());
                            p_strSampleIDArr.Add(dv[0]["sample_id_chr"].ToString());
                            if (DateTime.Parse(dv[0]["oringin_dat"].ToString()) < DateTime.Parse(p_strOriginDate))
                            {
                                p_strOriginDate = dv[0]["oringin_dat"].ToString();
                            }
                        }
                    }
                }
                else if (instrumentFlag == 1)
                {
                    for (int i2 = 0; i2 < objResultArr.Count; i2++)
                    {
                        if (!has.ContainsKey(objResultArr[i2].m_strSampleId))
                        {
                            string strTmp = "";
                            strTmp = objResultArr[i2].m_strSampleId;
                            strCheckNO = objResultArr[i2].m_strDeviceId + strTmp;
                            objResultArr[i2].m_strApplication_From_NO = strCheckNO;
                            has.Add(objResultArr[i2].m_strSampleId, strCheckNO);
                        }
                        else
                        {
                            objResultArr[i2].m_strApplication_From_NO = strCheckNO;
                        }
                    }
                    objHRPSvc.CreateDatabaseParameter(has.Count + 1, out objParamArr);
                    int i3 = 0;
                    foreach (object obj in has.Values)
                    {
                        sb.Append("?,");
                        objParamArr[i3++].Value = obj.ToString();
                    }
                    objParamArr[has.Count].Value = p_strOriginDate;
                    sb.Remove(sb.Length - 1, 1);
                    string strSQL3 = sb.ToString();
                    string strSQL = strSQL1 + strSQL3 + strSQL2;                             //生成SQL语句
                    objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, objParamArr);
                    DataView dv = new DataView(dtResult);

                    has = new System.Collections.Hashtable();
                    System.Collections.ArrayList arrCheckRes = new System.Collections.ArrayList();
                    clsCheckResult_VO objRes_VO = null;
                    for (int i1 = 0; i1 < objResultArr.Count; i1++)
                    {
                        dv.RowFilter = "application_form_no_chr = '" + objResultArr[i1].m_strApplication_From_NO + "' and check_item_name like '%" + objResultArr[i1].m_strItemCode.ToLower() + "%'";
                        if (dv.Count == 0)
                        {
                            objResultArr.RemoveAt(i1);
                            i1--;
                            continue;
                        }
                        objRes_VO = new clsCheckResult_VO();
                        objRes_VO.intIsGraphResult = 0;                                           //*  (-- *为必填)
                        objRes_VO.strGraphFormatName = null;
                        objRes_VO.m_strModify_Dat = DateTime.Now.ToString();                                 //*
                        objRes_VO.m_strGroupID = dv[0]["sample_group_id_chr"].ToString();         //检验组合编号(报告组)(*)
                        objRes_VO.m_strCheck_Item_ID = dv[0]["check_item_id_chr"].ToString();                //检验项目编号(*)
                        objRes_VO.m_strSample_ID = dv[0]["sample_id_chr"].ToString();             //样本联号：指样本中心的顺序编号(*)
                        objRes_VO.m_strResult = objResultArr[i1].m_strResult;
                        objRes_VO.m_strUnit = dv[0]["unit_chr"].ToString();
                        objRes_VO.m_strDeviceID = objResultArr[i1].m_strDeviceId;
                        objRes_VO.m_strDevice_Check_Item_Name = objResultArr[i1].m_strItemName;   //检验仪器输出的检验结果的名称，或缩写。
                        objRes_VO.m_strRefrange = dv[0]["ref_value_range_vchr"].ToString();       //参考值范围
                        objRes_VO.m_strCheck_Item_Name = dv[0]["check_item_name_vchr"].ToString();//检验项目名称
                        objRes_VO.m_strCheck_Item_English_Name = null;
                        objRes_VO.m_strMin_Val = dv[0]["ref_min_val_vchr"].ToString();
                        objRes_VO.m_strMax_Val = dv[0]["ref_max_val_vchr"].ToString();
                        objRes_VO.m_strAbnormal_Flag = null;
                        objRes_VO.m_strCheck_Dat = null;
                        objRes_VO.m_strClinicApp = null;
                        objRes_VO.m_strMemo = null;
                        objRes_VO.m_strConfirm_Dat = null;
                        objRes_VO.m_strPointliststr = null;
                        objRes_VO.m_strSummary = null;
                        objRes_VO.m_byaGraph = null;                                              //存放图像结果
                        objRes_VO.m_intStatus = 1;                                                // 1-当前有效记录
                        objRes_VO.m_strChecker1 = null;
                        objRes_VO.m_strChecker2 = null;
                        objRes_VO.m_strConfirm_Person = null;
                        objRes_VO.m_strOperator_ID = objResultArr[i1].m_strOperator_ID;           //操作员工ID
                        objRes_VO.m_strCheck_DeptID = null;
                        arrCheckRes.Add(objRes_VO);
                        if (!has.ContainsKey(dv[0]["application_id_chr"].ToString()))
                        {
                            has.Add(dv[0]["application_id_chr"].ToString(), dv[0]["application_id_chr"].ToString());
                            p_strSampleIDArr.Add(dv[0]["sample_id_chr"].ToString());
                            if (DateTime.Parse(dv[0]["oringin_dat"].ToString()) < DateTime.Parse(p_strOriginDate))
                            {
                                p_strOriginDate = dv[0]["oringin_dat"].ToString();
                            }
                        }
                    }
                    p_objCheckResultVO = (clsCheckResult_VO[])arrCheckRes.ToArray(typeof(clsCheckResult_VO));
                }
                else
                { }
            }
        }
        #endregion
    }
}