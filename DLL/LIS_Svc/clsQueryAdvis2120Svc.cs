using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.EnterpriseServices;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.security;
using com.digitalwave.Utility;
using com.digitalwave.iCare.middletier.LIS;

namespace com.digitalwave.iCare.middletier.LIS
{
    [Transaction(TransactionOption.Supported)]
    [ObjectPooling(Enabled = true)]
    public class clsQueryAdvis2120Svc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        public clsQueryAdvis2120Svc()
        {
 
        }

        #region 查询出所有的检验类别
        /// <summary>
        /// 查询出所有的检验类别
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strID"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetCheckCategory(System.Security.Principal.IPrincipal p_objPrincipal, out clsCheckCategory_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsCheckCategory_VO[0];
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsAdvis2120Svc", "m_lngGetCheckCategory");
            if (lngRes < 0)
            {
                return -1;
            }

            lngRes = 0;
            string strSQL = @"select check_category_id_chr,check_category_desc_vchr from t_bse_lis_check_category";
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsCheckCategory_VO[dtbResult.Rows.Count];
                    for (int i1 = 0; i1 < p_objResultArr.Length; i1++)
                    {
                        p_objResultArr[i1] = new clsCheckCategory_VO();
                        p_objResultArr[i1].m_strCheck_Category_ID = dtbResult.Rows[i1]["check_category_id_chr"].ToString().Trim();
                        p_objResultArr[i1].m_strCheck_Category_Name = dtbResult.Rows[i1]["check_category_desc_vchr"].ToString().Trim();
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

        #region 查询出该类别的检验项目
        /// <summary>
        /// 查询出该类别的检验项目
        /// </summary>
        [AutoComplete]
        public long m_lngGetCheckItemByCategoryID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strCategoryID, out clsCheckItem_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsCheckItem_VO[0];
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsAdvis2120Svc", "m_lngGetCheckItemByCategoryID");
            if (lngRes < 0)
            {
                return -1;
            }

            lngRes = 0;
            string strSQL = @"select rptno_chr, pycode_chr, unit_chr, check_item_name_vchr,
                                     is_sex_related_chr, check_item_english_name_vchr, is_age_related_chr,
                                     is_sample_related_chr, formula_vchr, test_methods_vchr,
                                     clinic_meaning_vchr, check_item_id_chr, shortname_chr,
                                     is_qc_required_chr, resulttype_chr, ref_value_range_vchr, wbcode_chr,
                                     assist_code01_chr, assist_code02_chr, is_no_food_required_chr,
                                     is_physical_exam_required_chr, is_reservation_required_chr,
                                     sample_valid_time_dec, sample_valid_time_unit_chr, modify_dat,
                                     operatorid_chr, check_category_id_chr
                                from t_bse_lis_check_item";
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                if (p_strCategoryID.ToString().Trim() != "")
                {
                    strSQL += " where check_category_id_chr = ?";
                    IDataParameter[] objParamArr = null;
                    objHRPSvc.CreateDatabaseParameter(1, out objParamArr);
                    objParamArr[0].Value = p_strCategoryID;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objParamArr);
                }
                else
                {
                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                }
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsCheckItem_VO[dtbResult.Rows.Count];
                    for (int i1 = 0; i1 < p_objResultArr.Length; i1++)
                    {
                        p_objResultArr[i1] = new clsCheckItem_VO();
                        p_objResultArr[i1].m_strCheck_Item_ID = dtbResult.Rows[i1]["check_item_id_chr"].ToString().Trim();
                        p_objResultArr[i1].m_strRPTNO = dtbResult.Rows[i1]["rptno_chr"].ToString().Trim();
                        p_objResultArr[i1].m_strPycode = dtbResult.Rows[i1]["pycode_chr"].ToString().Trim();
                        p_objResultArr[i1].m_strUnit = dtbResult.Rows[i1]["unit_chr"].ToString().Trim();
                        p_objResultArr[i1].m_strCheck_Item_Name = dtbResult.Rows[i1]["check_item_name_vchr"].ToString().Trim();
                        p_objResultArr[i1].m_strIs_Sex_Related = dtbResult.Rows[i1]["is_sex_related_chr"].ToString().Trim();
                        p_objResultArr[i1].m_strCheck_Item_English_Name = dtbResult.Rows[i1]["check_item_english_name_vchr"].ToString().Trim();
                        p_objResultArr[i1].m_strIs_Age_Related = dtbResult.Rows[i1]["is_age_related_chr"].ToString().Trim();
                        p_objResultArr[i1].m_strIs_Sample_Related = dtbResult.Rows[i1]["is_sample_related_chr"].ToString().Trim();
                        p_objResultArr[i1].m_strFormula = dtbResult.Rows[i1]["formula_vchr"].ToString().Trim();
                        p_objResultArr[i1].m_strTest_Method = dtbResult.Rows[i1]["test_methods_vchr"].ToString().Trim();
                        p_objResultArr[i1].m_strClinic_meaning = dtbResult.Rows[i1]["clinic_meaning_vchr"].ToString().Trim();
                        p_objResultArr[i1].m_strShortName = dtbResult.Rows[i1]["shortname_chr"].ToString().Trim();
                        p_objResultArr[i1].m_strIs_Qc_Required = dtbResult.Rows[i1]["is_qc_required_chr"].ToString().Trim();
                        p_objResultArr[i1].m_strResultType = dtbResult.Rows[i1]["resulttype_chr"].ToString().Trim();
                        p_objResultArr[i1].m_strRef_Value_Range = dtbResult.Rows[i1]["ref_value_range_vchr"].ToString().Trim();
                        p_objResultArr[i1].m_strWbcode = dtbResult.Rows[i1]["wbcode_chr"].ToString().Trim();
                        p_objResultArr[i1].m_strAssist_Code01 = dtbResult.Rows[i1]["assist_code01_chr"].ToString().Trim();
                        p_objResultArr[i1].m_strAssist_Code02 = dtbResult.Rows[i1]["assist_code02_chr"].ToString().Trim();
                        p_objResultArr[i1].m_strIs_No_Food_Required = dtbResult.Rows[i1]["is_no_food_required_chr"].ToString().Trim();
                        p_objResultArr[i1].m_strIs_Physical_Exam_Required = dtbResult.Rows[i1]["is_physical_exam_required_chr"].ToString().Trim();
                        p_objResultArr[i1].m_strIs_Reservation_Required = dtbResult.Rows[i1]["is_reservation_required_chr"].ToString().Trim();
                        p_objResultArr[i1].m_strSample_Valid_Time = dtbResult.Rows[i1]["sample_valid_time_dec"].ToString().Trim();
                        p_objResultArr[i1].m_strSample_Valid_Time_Unit = dtbResult.Rows[i1]["sample_valid_time_unit_chr"].ToString().Trim();
                        p_objResultArr[i1].m_strModify_Dat = dtbResult.Rows[i1]["modify_dat"].ToString().Trim();
                        p_objResultArr[i1].m_strOperator_ID = dtbResult.Rows[i1]["operatorid_chr"].ToString().Trim();
                        p_objResultArr[i1].m_strCheck_Category_ID = dtbResult.Rows[i1]["check_category_id_chr"].ToString().Trim();
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

        #region 查询所有的仪器检验项目与检验项目的对应关系
        /// <summary>
        /// 查询所有的仪器检验项目与检验项目的对应关系
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objCheckItemDeviceCheckItem"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetCheckItemDeviceCheckItem(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDeviceModelID, out clsLisCheckItemDeviceCheckItem_VO[] p_objCheckItemDeviceCheckItem)
        {
            long lngRes = 0;
            p_objCheckItemDeviceCheckItem = null;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsAdvis2120Svc", "m_lngGetCheckItemDeviceCheckItem");
            if (lngRes < 0)
            {
                return -1;
            }
            DataTable dtbItem = null;
            string strSQL = @"select a.check_item_id_chr, a.modify_dat, a.operatorid_chr,
                                     a.device_check_item_id_chr, a.device_model_id_chr, a.groupid_chr,
                                     b.check_item_name_vchr, b.check_item_english_name_vchr,
                                     b.shortname_chr
                                from t_bse_lis_check_item_dev_item a, t_bse_lis_check_item b
                               where a.check_item_id_chr = b.check_item_id_chr";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                if (p_strDeviceModelID != "")
                {
                    strSQL += " and trim(a.device_model_id_chr) = ?";
                    IDataParameter[] objParmaArr = null;
                    objHRPSvc.CreateDatabaseParameter(1, out objParmaArr);
                    objParmaArr[0].Value = p_strDeviceModelID;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbItem, objParmaArr);
                }
                else
                {
                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbItem);
                }
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbItem != null)
                {
                    if (dtbItem.Rows.Count > 0)
                    {
                        p_objCheckItemDeviceCheckItem = new clsLisCheckItemDeviceCheckItem_VO[dtbItem.Rows.Count];
                        for (int i = 0; i < dtbItem.Rows.Count; i++)
                        {
                            p_objCheckItemDeviceCheckItem[i] = new clsLisCheckItemDeviceCheckItem_VO();
                            p_objCheckItemDeviceCheckItem[i].m_strCHECK_ITEM_ID_CHR = dtbItem.Rows[i]["check_item_id_chr"].ToString().Trim();
                            p_objCheckItemDeviceCheckItem[i].m_strDEVICE_CHECK_ITEM_ID_CHR = dtbItem.Rows[i]["device_check_item_id_chr"].ToString().Trim();
                            p_objCheckItemDeviceCheckItem[i].m_strDEVICE_MODEL_ID_CHR = dtbItem.Rows[i]["device_model_id_chr"].ToString().Trim();
                            p_objCheckItemDeviceCheckItem[i].m_strGROUPID_CHR = dtbItem.Rows[i]["groupid_chr"].ToString().Trim();
                            p_objCheckItemDeviceCheckItem[i].m_strMODIFY_DAT = dtbItem.Rows[i]["modify_dat"].ToString().Trim();
                            p_objCheckItemDeviceCheckItem[i].m_strOPERATORID_CHR = dtbItem.Rows[i]["operatorid_chr"].ToString().Trim();
                            p_objCheckItemDeviceCheckItem[i].m_strCHECK_ITEM_NAME_VCHR = dtbItem.Rows[i]["check_item_name_vchr"].ToString().Trim();
                            p_objCheckItemDeviceCheckItem[i].m_strCHECK_ITEM_ENGLISH_NAME_VCHR = dtbItem.Rows[i]["check_item_english_name_vchr"].ToString().Trim();
                            p_objCheckItemDeviceCheckItem[i].m_strSHORTNAME_CHR = dtbItem.Rows[i]["shortname_chr"].ToString().Trim();
                        }
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。 
            }
            return lngRes;
        }
        #endregion

        #region 构造血球仪Advia2120VO
        /// <summary>
        /// 构造血球仪Advia2120VO
        /// </summary>
        /// <param name="p_intNum">报告人数</param>
        /// <param name="p_objResultList"></param>
        /// <param name="p_objCheckResultVO"></param>
        [AutoComplete]
        public void m_mthContructResultVO(int p_intNum, List<clsAdvia2120ResultInf_VO> p_objResultList, out List<clsCheckResult_VO> p_objCheckResultVO, out List<clsT_OPR_LIS_APP_REPORT_VO> p_objRecordVOList, out List<string> p_strSampleIDArr, ref string p_strOriginDate)
        {
            p_objCheckResultVO = new List<clsCheckResult_VO>();
            p_objRecordVOList = new List<clsT_OPR_LIS_APP_REPORT_VO>();
            p_strSampleIDArr = new List<string>();
            p_strOriginDate = DateTime.Now.ToString();
            if (p_objResultList.Count > 0)
            {
                #region 生成检验编号，并根据检验编号查出对应信息


                //根据酶标仪传入的样本号生成检验编号

                string strSQL1 = @"select a.application_id_chr, a.application_dat, a.application_form_no_chr,
                                          a.oringin_dat, b.sample_group_id_chr, a.modify_dat, b.sample_id_chr,
                                          c.check_item_id_chr, d.report_group_id_chr, e.check_item_name_vchr,
                                          e.check_item_name_vchr, e.check_item_english_name_vchr, e.unit_chr,
                                          f_getitemref_low (c.check_item_id_chr,
                                                            trim (a.age_chr),
                                                            trim (a.sex_chr),
                                                            'menses'
                                                           ) ref_min_val_vchr,
                                          f_getitemref_up (c.check_item_id_chr,
                                                           trim (a.age_chr),
                                                           trim (a.sex_chr),
                                                           'menses'
                                                          ) ref_max_val_vchr,
                                          f_getitemref_range (c.check_item_id_chr,
                                                              trim (a.age_chr),
                                                              trim (a.sex_chr),
                                                              'menses'
                                                             ) ref_value_range_vchr,
                                          f.device_check_item_id_chr, f.device_model_id_chr
                                    from t_opr_lis_application a,
                                         t_opr_lis_app_sample b,
                                         t_opr_lis_app_check_item c,
                                         t_opr_lis_app_report d,
                                         t_bse_lis_check_item e,
                                         t_bse_lis_check_item_dev_item f
                                    where a.application_id_chr = b.application_id_chr
                                      and a.application_id_chr = c.application_id_chr
                                      and a.application_id_chr = d.application_id_chr
                                      and a.application_id_chr = d.application_id_chr
                                      and a.application_form_no_chr in (";
                string strSQL2 = @")
                                      and a.pstatus_int > 0
                                      and c.check_item_id_chr = e.check_item_id_chr
                                      and d.status_int > 0
                                      and e.check_item_id_chr = f.check_item_id_chr(+)";


                clsHRPTableService objHRPSvc = new clsHRPTableService();
                DataTable dtResult = new DataTable();
                System.Data.IDataParameter[] objParamArr = null;
                objHRPSvc.CreateDatabaseParameter(p_intNum, out objParamArr);
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                System.Collections.Hashtable has = new System.Collections.Hashtable();
                int n = 0;

                for (int i2 = 0; i2 < p_objResultList.Count; i2++)
                {
                    if (!has.ContainsKey(p_objResultList[i2].strCode))
                    {
                        has.Add(p_objResultList[i2].strCode, p_objResultList[i2].strCode);
                        sb.Append("?,");
                        objParamArr[n++].Value = p_objResultList[i2].strCode;                                  //参数
                    }
                }
                sb.Remove(sb.Length - 1, 1);
                string strSQL3 = sb.ToString();
                string strSQL = strSQL1 + strSQL3 + strSQL2;                             //生成SQL语句
                objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, objParamArr);
                DataView dv = new DataView(dtResult);
                has = new System.Collections.Hashtable();     //保存申请单下报告组的信息
                //<-----------------------------新增一个临时表 add in 11.28
                DataTable dtTmp = new DataTable();
                dtTmp.Columns.Add("application_id_chr");
                dtTmp.Columns.Add("check_item_id_chr");
                DataRow dr = null;
                //------------------------------------------->
                clsT_OPR_LIS_APP_REPORT_VO objReportTmp = null;

                #endregion

                clsCheckResult_VO objTemp = null;

                for (int i1 = 0; i1 < p_objResultList.Count; i1++)
                {
                    string strDeviceItemCode = ((p_objResultList[i1].m_strItemid.Length > 4) ? p_objResultList[i1].m_strItemid.Substring(0, 4) : p_objResultList[i1].m_strItemid);   //字符长度为4
                    dv.RowFilter = "application_form_no_chr = '" + p_objResultList[i1].strCode + "' and device_check_item_id_chr = '" + strDeviceItemCode + "' and device_model_id_chr = '" + p_objResultList[i1].strDeviceID + "'";
                    dv.Sort = "application_dat desc";
                    if (dv.Count == 0)
                    {
                        p_objResultList.RemoveAt(i1);
                        i1--;
                        continue;
                    }

                    objTemp = new clsCheckResult_VO();
                    switch (p_objResultList[i1].intDataFormat)
                    {
                        case 1:
                            objTemp.intIsGraphResult = 0;                                           //*  (-- *为必填)
                            objTemp.strGraphFormatName = null;
                            objTemp.m_byaGraph = null;                                              //存放图像结果
                            objTemp.m_strResult = p_objResultList[i1].num_value.ToString();
                            break;

                        case 0:
                            objTemp.intIsGraphResult = 0;
                            objTemp.strGraphFormatName = null;
                            objTemp.m_byaGraph = null;
                            objTemp.m_strResult = p_objResultList[i1].chr_value;
                            break;
                        default:
                            objTemp.intIsGraphResult = 1;
                            objTemp.strGraphFormatName = "lisb";
                            objTemp.m_byaGraph = p_objResultList[i1].m_byaGraph;
                            objTemp.m_strResult = null;
                            break;
                    }
                    objTemp.m_strModify_Dat = DateTime.Now.ToString();                                 //*
                    objTemp.m_strGroupID = dv[0]["sample_group_id_chr"].ToString();         //检验组合编号(报告组)(*)
                    objTemp.m_strCheck_Item_ID = dv[0]["check_item_id_chr"].ToString();                //检验项目编号(*)
                    objTemp.m_strSample_ID = dv[0]["sample_id_chr"].ToString();             //样本联号：指样本中心的顺序编号(*)
                    objTemp.m_strUnit = dv[0]["unit_chr"].ToString();
                    objTemp.m_strDeviceID = p_objResultList[i1].strDeviceID;
                    objTemp.m_strDevice_Check_Item_Name = p_objResultList[i1].strItemCode;   //检验仪器输出的检验结果的名称，或缩写。

                    objTemp.m_strRefrange = dv[0]["ref_value_range_vchr"].ToString();       //参考值范围

                    objTemp.m_strCheck_Item_Name = dv[0]["check_item_name_vchr"].ToString();//检验项目名称

                    objTemp.m_strCheck_Item_English_Name = dv[0]["check_item_english_name_vchr"].ToString();
                    objTemp.m_strMin_Val = dv[0]["ref_min_val_vchr"].ToString();
                    objTemp.m_strMax_Val = dv[0]["ref_max_val_vchr"].ToString();
                    objTemp.m_strAbnormal_Flag = null;
                    objTemp.m_strCheck_Dat = p_objResultList[i1].strInputDate;
                    objTemp.m_strClinicApp = null;
                    objTemp.m_strMemo = null;
                    objTemp.m_strConfirm_Dat = null;
                    objTemp.m_strPointliststr = null;
                    objTemp.m_strSummary = null;
                    objTemp.m_intStatus = 1;                                                // 1-当前有效记录
                    objTemp.m_strChecker1 = null;
                    objTemp.m_strChecker2 = null;
                    objTemp.m_strConfirm_Person = null;
                    objTemp.m_strOperator_ID = p_objResultList[i1].m_strOperator_ID;           //操作员工ID
                    objTemp.m_strCheck_DeptID = null;
                    dr = dtTmp.NewRow();
                    dr["application_id_chr"] = dv[0]["application_id_chr"].ToString();
                    dr["check_item_id_chr"] = dv[0]["check_item_id_chr"].ToString();
                    if (!has.ContainsKey(dv[0]["application_id_chr"].ToString()))
                    {
                        has.Add(dv[0]["application_id_chr"].ToString(), dv[0]["application_id_chr"].ToString());
                        objReportTmp = new clsT_OPR_LIS_APP_REPORT_VO();
                        objReportTmp.m_strREPORTOR_ID_CHR = p_objResultList[i1].m_strOperator_ID;
                        objReportTmp.m_strSUMMARY_VCHR = "";
                        objReportTmp.m_strXML_SUMMARY_VCHR = "<r><D /><U /><S /></r>";
                        objReportTmp.m_strANNOTATION_VCHR = "";
                        objReportTmp.m_strXML_ANNOTATION_VCHR = "<r><D /><U /><S /></r>";
                        objReportTmp.m_strREPORT_DAT = DateTime.Now.ToString();
                        objReportTmp.m_intSTATUS_INT = 1;
                        objReportTmp.m_strAPPLICATION_ID_CHR = dv[0]["application_id_chr"].ToString();
                        objReportTmp.m_strCONFIRM_DAT = null;
                        objReportTmp.m_strCONFIRMER_ID_CHR = "";
                        objReportTmp.m_strOPERATOR_ID_CHR = p_objResultList[i1].m_strOperator_ID;
                        objReportTmp.m_strREPORT_GROUP_ID_CHR = dv[0]["report_group_id_chr"].ToString();
                        p_strSampleIDArr.Add(dv[0]["sample_id_chr"].ToString());
                        if (DateTime.Parse(dv[0]["oringin_dat"].ToString()) < DateTime.Parse(p_strOriginDate))
                        {
                            p_strOriginDate = dv[0]["oringin_dat"].ToString();
                        }
                        p_objRecordVOList.Add(objReportTmp);
                    }
                    p_objCheckResultVO.Add(objTemp);
                    dtTmp.Rows.Add(dr);
                }
                //<-------------------------------------------------------------------------add in 11.29 插入没有结果的项目
                dtTmp.AcceptChanges();
                DataView dvTmp = new DataView(dtTmp);
                dv.RowFilter = "1=1";
                foreach (DataRowView objdv1 in dv)
                {
                    dvTmp.RowFilter = "application_id_chr = '" + objdv1["application_id_chr"].ToString() + "'";
                    if (dvTmp.Count > 0)
                    {
                        dvTmp.RowFilter = "application_id_chr = '" + objdv1["application_id_chr"].ToString() + "'and check_item_id_chr = '" + objdv1["check_item_id_chr"].ToString() + "'";
                        if (dvTmp.Count > 0)
                        {
                            continue;
                        }
                        else
                        {
                            objTemp = new clsCheckResult_VO();
                            objTemp.intIsGraphResult = 0;
                            objTemp.strGraphFormatName = null;
                            objTemp.m_byaGraph = null;
                            objTemp.m_strResult = null;
                            objTemp.m_strModify_Dat = DateTime.Now.ToString();
                            objTemp.m_strGroupID = objdv1["sample_group_id_chr"].ToString();
                            objTemp.m_strCheck_Item_ID = objdv1["check_item_id_chr"].ToString();
                            objTemp.m_strSample_ID = objdv1["sample_id_chr"].ToString();
                            objTemp.m_strUnit = objdv1["unit_chr"].ToString();
                            objTemp.m_strDeviceID = null;
                            objTemp.m_strDevice_Check_Item_Name = null;
                            objTemp.m_strRefrange = objdv1["ref_value_range_vchr"].ToString();
                            objTemp.m_strCheck_Item_Name = objdv1["check_item_name_vchr"].ToString();
                            objTemp.m_strCheck_Item_English_Name = objdv1["check_item_english_name_vchr"].ToString();
                            objTemp.m_strMin_Val = objdv1["ref_min_val_vchr"].ToString();
                            objTemp.m_strMax_Val = objdv1["ref_max_val_vchr"].ToString();
                            objTemp.m_strAbnormal_Flag = null;
                            objTemp.m_strCheck_Dat = null;
                            objTemp.m_strClinicApp = null;
                            objTemp.m_strMemo = null;
                            objTemp.m_strConfirm_Dat = null;
                            objTemp.m_strPointliststr = null;
                            objTemp.m_strSummary = null;
                            objTemp.m_intStatus = 1;
                            objTemp.m_strChecker1 = null;
                            objTemp.m_strChecker2 = null;
                            objTemp.m_strConfirm_Person = null;
                            objTemp.m_strOperator_ID = p_objResultList[0].m_strOperator_ID;
                            objTemp.m_strCheck_DeptID = null;
                            p_objCheckResultVO.Add(objTemp);
                        }
                    }
                }
                //------------------------------------------------------------------------------------------->
            }
        }
        #endregion
    }
}
