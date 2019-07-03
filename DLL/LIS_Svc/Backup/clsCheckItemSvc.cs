using System;
using System.Data;
using System.Collections;
using System.EnterpriseServices;
using com.digitalwave.Utility; //Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll


namespace com.digitalwave.iCare.middletier.LIS
{
    /// <summary>
    /// Summary description for clsCheckItemSvc.
    /// </summary>
    [Transaction(TransactionOption.Required)]
    [ObjectPooling(Enabled = true)]
    public class clsCheckItemSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase//MiddleTierBase.dll
    {
        //        #region 获取申请单元数组包含的检验项目列表 

        //        [AutoComplete]
        //        public long m_lngGetApplyUnitArrCheckItem(System.Security.Principal.IPrincipal p_objPrincipal,string[] p_strApplyUnitArr,
        //            out clsPISApplyUnitItem[] p_objRecordArr)
        //        {
        //            long lngRes = 0;

        //            p_objRecordArr = null;

        //            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //            lngRes = objPrivilege.m_lngCheckCallPrivilege
        //                (p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc","m_lngGetApplyUnitArrCheckItem");
        //            if(lngRes < 0)
        //            {
        //                return -1;
        //            }

        //            string strPara = "";

        //            for(int i=0;i<p_strApplyUnitArr.Length;i++)
        //            {
        //                if(i != p_strApplyUnitArr.Length-1)
        //                {
        //                    strPara += " ?,";
        //                }
        //                else
        //                {
        //                    strPara += " ?";
        //                }
        //            }

        //            #region SQL
        //            string strSQL = @"SELECT t1.rptno_chr, t1.pycode_chr, t1.unit_chr, t1.check_item_name_vchr,
        //                                   t1.is_sex_related_chr, t1.check_item_english_name_vchr,
        //                                   t1.is_age_related_chr, t1.is_sample_related_chr, t1.formula_vchr,
        //                                   t1.test_methods_vchr, t1.clinic_meaning_vchr, t1.check_item_id_chr,
        //                                   t1.shortname_chr, t1.is_qc_required_chr, t1.resulttype_chr,
        //                                   t1.ref_value_range_vchr, t1.wbcode_chr, t1.assist_code01_chr,
        //                                   t1.assist_code02_chr, t1.is_no_food_required_chr,
        //                                   t1.is_physical_exam_required_chr, t1.is_reservation_required_chr,
        //                                   t1.sample_valid_time_dec, t1.sample_valid_time_unit_chr, t1.modify_dat,
        //                                   t1.operatorid_chr, t1.check_category_id_chr, t1.ref_max_val_vchr,
        //                                   t1.ref_min_val_vchr, t1.sampletype_vchr, t1.is_menses_related_chr,
        //                                   t1.is_calculated_chr, t1.formula_user_vchr, t1.alarm_low_val_vchr,
        //                                   t1.alarm_up_val_vchr, t1.alert_value_range_vchr,
        //                                     t2.apply_unit_id_chr,t3.apply_unit_name_vchr
        //								FROM t_bse_lis_check_item t1, t_aid_lis_apply_unit_detail t2 ,t_aid_lis_apply_unit t3
        //							   WHERE t2.check_item_id_chr = t1.check_item_id_chr
        //								 AND t2.apply_unit_id_chr = t3.apply_unit_id_chr
        //								 AND t2.apply_unit_id_chr in ( " +strPara+@" )
        //							ORDER BY t2.PRINT_SEQ_INT";
        //            #endregion

        //            ArrayList arlApplyUnit = new ArrayList();

        //            for(int i=0;i<p_strApplyUnitArr.Length;i++)
        //            {
        //                arlApplyUnit.Add(p_strApplyUnitArr[i]);
        //            }

        //            try
        //            {
        //                System.Data.IDataParameter[] objIDPArr = m_objConstructIDataParameterArr(arlApplyUnit.ToArray());
        //                DataTable dtbCheckItem = null;
        //                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL,ref dtbCheckItem,objIDPArr);
        //                objHRPSvc.Dispose();
        //                if(lngRes > 0 && dtbCheckItem != null && dtbCheckItem.Rows.Count > 0)
        //                {
        //                    p_objRecordArr = new clsPISApplyUnitItem[dtbCheckItem.Rows.Count];
        //                    for(int i=0;i<dtbCheckItem.Rows.Count;i++)
        //                    {
        //                        p_objRecordArr[i] = new clsPISApplyUnitItem();
        //                        p_objRecordArr[i].m_strAPPLY_UNIT_ID_CHR = dtbCheckItem.Rows[i]["APPLY_UNIT_ID_CHR"].ToString().Trim();
        //                        p_objRecordArr[i].m_strAPPLY_UNIT_NAME_VCHR = dtbCheckItem.Rows[i]["APPLY_UNIT_NAME_VCHR"].ToString().Trim();
        //                        p_objRecordArr[i].m_strCHECK_ITEM_ID_CHR = dtbCheckItem.Rows[i]["CHECK_ITEM_ID_CHR"].ToString().Trim();
        //                        p_objRecordArr[i].m_strCHECK_ITEM_NAME_VCHR = dtbCheckItem.Rows[i]["CHECK_ITEM_NAME_VCHR"].ToString().Trim();
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

        //        #endregion

        #region 值模板

        //        #region 根据检验类别、样本类别查询模板信息 
        //        [AutoComplete]
        //        public long m_lngGetTemplateInfoByCondition(System.Security.Principal.IPrincipal p_objPrincipal,string p_strCheckCategory,string p_strSampleType,
        //            out clsLisValueTemplate_VO[] p_objResultArr)
        //        {
        //            long lngRes = 0;
        //            p_objResultArr = null;
        //            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc","m_lngGetTemplateInfoByCondition");
        //            if(lngRes < 0)
        //            {
        //                return -1;
        //            }

        //            string strSQL = @"SELECT a.*
        //							    FROM t_aid_lis_valuetemplate a
        //							   WHERE 1=1";

        //            if(p_strCheckCategory != null && p_strCheckCategory != "")
        //            {
        //                strSQL += " AND a.check_category_id_chr = '"+p_strCheckCategory+"'";
        //            }
        //            if(p_strSampleType != null && p_strSampleType != "")
        //            {
        //                strSQL += " AND a.sample_type_id_chr = '"+p_strSampleType+"'";
        //            }
        //            strSQL += " ORDER BY a.template_id_chr";
        //            DataTable dtbResult = null;
        //            try
        //            {
        //                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbResult);
        //                objHRPSvc.Dispose();
        //                if(lngRes > 0 && dtbResult != null && dtbResult.Rows.Count > 0)
        //                {
        //                    p_objResultArr = new clsLisValueTemplate_VO[dtbResult.Rows.Count];
        //                    for(int i1=0;i1<p_objResultArr.Length;i1++)
        //                    {
        //                        p_objResultArr[i1] = new clsLisValueTemplate_VO();
        //                        p_objResultArr[i1].m_strTEMPLATE_ID_CHR = dtbResult.Rows[i1]["TEMPLATE_ID_CHR"].ToString().Trim();
        //                        p_objResultArr[i1].m_strTEMPLATE_NAME_VCHR = dtbResult.Rows[i1]["TEMPLATE_NAME_VCHR"].ToString().Trim();
        //                        p_objResultArr[i1].m_strCHECK_CATEGORY_ID_CHR = dtbResult.Rows[i1]["CHECK_CATEGORY_ID_CHR"].ToString().Trim();
        //                        p_objResultArr[i1].m_strSAMPLE_TYPE_ID_CHR = dtbResult.Rows[i1]["SAMPLE_TYPE_ID_CHR"].ToString().Trim();
        //                        p_objResultArr[i1].m_strSUMMARY_VCHR = dtbResult.Rows[i1]["SUMMARY_VCHR"].ToString().Trim();
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

        //        #region 根据模板ID查询相应的模板明细信息 
        //        [AutoComplete]
        //        public long m_lngGetTemplateDetailByTemplateID(System.Security.Principal.IPrincipal p_objPrincipal,string p_strTemplateID,
        //            out clsLisValueTemplateDetail_VO[] p_objResultArr)
        //        {
        //            long lngRes = 0;
        //            p_objResultArr = null;
        //            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc","m_lngGetTemplateDetailByTemplateID");
        //            if(lngRes < 0)
        //            {
        //                return -1;
        //            }
        //            //change by wjqin(07-4-23)
        ////            string strSQL = @"SELECT *
        ////								FROM t_aid_lis_valuetemplate_detail
        ////							   WHERE template_id_chr = '"+p_strTemplateID+@"'
        ////							   ORDER BY INDEX_INT";
        ////            try
        ////            {
        ////                DataTable dtbResult = new DataTable();
        ////                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        ////                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
        ////                objHRPSvc.Dispose();
        ////                if(lngRes > 0 && dtbResult.Rows.Count > 0)
        ////                {
        ////                    p_objResultArr = new clsLisValueTemplateDetail_VO[dtbResult.Rows.Count];
        ////                    for(int i1=0;i1<p_objResultArr.Length;i1++)
        ////                    {
        ////                        p_objResultArr[i1] = new clsLisValueTemplateDetail_VO();
        ////                        p_objResultArr[i1].m_strTEMPLATE_ID_CHR = dtbResult.Rows[i1]["TEMPLATE_ID_CHR"].ToString().Trim();
        ////                        p_objResultArr[i1].m_intINDEX_INT = Convert.ToInt32(dtbResult.Rows[i1]["INDEX_INT"].ToString().Trim());
        ////                        p_objResultArr[i1].m_intSEQ_INT = Convert.ToInt32(dtbResult.Rows[i1]["SEQ_INT"].ToString().Trim());
        ////                        p_objResultArr[i1].m_strVALUE_VCHR = dtbResult.Rows[i1]["VALUE_VCHR"].ToString().Trim();
        ////                        p_objResultArr[i1].m_intDEFAULT_VALUE_FLAG_INT = Convert.ToInt32(dtbResult.Rows[i1]["DEFAULT_VALUE_FLAG_INT"].ToString().Trim());
        ////                    }
        ////                }
        ////            }
        ////            catch(Exception objEx)
        ////            {
        ////                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        ////                bool blnRes = objLogger.LogError(objEx);
        ////            }



        //            string strSQL = @"select template_id_chr,index_int,seq_int,value_vchr,default_value_flag_int
        //            								from t_aid_lis_valuetemplate_detail
        //            							   where template_id_chr = ?
        //            							   order by index_int";
        //            try
        //            {
        //                DataTable dtbResult = new DataTable();
        //                System.Data.IDataParameter[] objDPArr = null;
        //                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //                objHRPSvc.CreateDatabaseParameter(1, out objDPArr);
        //                objDPArr[0].Value = p_strTemplateID.PadRight(6, ' ');
        //                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);
        //                objHRPSvc.Dispose();
        //                if (lngRes > 0 && dtbResult.Rows.Count > 0)
        //                {
        //                    p_objResultArr = new clsLisValueTemplateDetail_VO[dtbResult.Rows.Count];
        //                    for (int i1 = 0; i1 < p_objResultArr.Length; i1++)
        //                    {
        //                        p_objResultArr[i1] = new clsLisValueTemplateDetail_VO();
        //                        p_objResultArr[i1].m_strTEMPLATE_ID_CHR = dtbResult.Rows[i1]["TEMPLATE_ID_CHR"].ToString().Trim();
        //                        p_objResultArr[i1].m_intINDEX_INT = Convert.ToInt32(dtbResult.Rows[i1]["INDEX_INT"].ToString().Trim());
        //                        p_objResultArr[i1].m_intSEQ_INT = Convert.ToInt32(dtbResult.Rows[i1]["SEQ_INT"].ToString().Trim());
        //                        p_objResultArr[i1].m_strVALUE_VCHR = dtbResult.Rows[i1]["VALUE_VCHR"].ToString().Trim();
        //                        p_objResultArr[i1].m_intDEFAULT_VALUE_FLAG_INT = Convert.ToInt32(dtbResult.Rows[i1]["DEFAULT_VALUE_FLAG_INT"].ToString().Trim());
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

        //        #region 根据检验项目ID查询相应的模板明细信息
        //        [AutoComplete]
        //        public long m_lngGetTemplateDetailByCheckItemID(System.Security.Principal.IPrincipal p_objPrincipal,string p_strCheckItemID,
        //            out clsLisValueTemplateDetail_VO[] p_objResultArr)
        //        {
        //            long lngRes = 0;
        //            p_objResultArr = null;
        //            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc","m_lngGetTemplateDetailByTemplateID");
        //            if(lngRes < 0)
        //            {
        //                return -1;
        //            }

        //            string strSQL = @"SELECT a.*
        //								FROM t_aid_lis_valuetemplate_detail a
        //									 t_aid_lis_valuetemplate_item b
        //							   WHERE b.check_item_id_chr = '"+p_strCheckItemID+@"'
        //							   ORDER BY a.INDEX_INT";
        //            try
        //            {
        //                DataTable dtbResult = new DataTable();
        //                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
        //                objHRPSvc.Dispose();
        //                if(lngRes > 0 && dtbResult.Rows.Count > 0)
        //                {
        //                    p_objResultArr = new clsLisValueTemplateDetail_VO[dtbResult.Rows.Count];
        //                    for(int i1=0;i1<p_objResultArr.Length;i1++)
        //                    {
        //                        p_objResultArr[i1] = new clsLisValueTemplateDetail_VO();
        //                        p_objResultArr[i1].m_strTEMPLATE_ID_CHR = dtbResult.Rows[i1]["TEMPLATE_ID_CHR"].ToString().Trim();
        //                        p_objResultArr[i1].m_intINDEX_INT = Convert.ToInt32(dtbResult.Rows[i1]["INDEX_INT"].ToString().Trim());
        //                        p_objResultArr[i1].m_intSEQ_INT = Convert.ToInt32(dtbResult.Rows[i1]["SEQ_INT"].ToString().Trim());
        //                        p_objResultArr[i1].m_strVALUE_VCHR = dtbResult.Rows[i1]["VALUE_VCHR"].ToString().Trim();
        //                        p_objResultArr[i1].m_intDEFAULT_VALUE_FLAG_INT = Convert.ToInt32(dtbResult.Rows[i1]["DEFAULT_VALUE_FLAG_INT"].ToString().Trim());
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

        #region 新增记录到表T_AID_LIS_VALUETEMPLATE_ITEM
        [AutoComplete]
        public long m_lngAddNewValueTemplateItem(System.Security.Principal.IPrincipal p_objPrincipal, clsLisValueTemplateItem_VO p_objRecord)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc", "m_lngAddNewValueTemplateItem");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = "INSERT INTO T_AID_LIS_VALUETEMPLATE_ITEM (TEMPLATE_ID_CHR,CHECK_ITEM_ID_CHR) VALUES (?,?)";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objRecord.m_strTEMPLATE_ID_CHR;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strCHECK_ITEM_ID_CHR;
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

        #region 删除表T_AID_LIS_VALUETEMPLATE_ITEM的记录
        [AutoComplete]
        public long m_lngDelValueTemplateItem(System.Security.Principal.IPrincipal p_objPrincipal, clsLisValueTemplateItem_VO p_objRecord)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc", "m_lngDelValueTemplateItem");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"DELETE FROM T_AID_LIS_VALUETEMPLATE_ITEM 
							   WHERE CHECK_ITEM_ID_CHR = '" + p_objRecord.m_strCHECK_ITEM_ID_CHR + @"'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                long lngEffRec = -1;
                lngRes = objHRPSvc.DoExcuteForDelete(strSQL, ref lngEffRec);
                if (lngEffRec > -1)
                {
                    lngRes = 1;
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

        #region 复用模板
        /// <summary>
        /// 复用模板
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objOldRecord">原有的记录（没有则为空）</param>
        /// <param name="p_objNewRecord">新的记录</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngReuseTemplate(System.Security.Principal.IPrincipal p_objPrincipal, clsLisValueTemplateItem_VO p_objOldRecord,
            clsLisValueTemplateItem_VO p_objNewRecord)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc", "m_lngReuseTemplate");
            if (lngRes < 0)
            {
                return -1;
            }

            if (p_objOldRecord != null)
            {
                //1 删除原有的记录
                lngRes = m_lngDelValueTemplateItem(p_objPrincipal, p_objOldRecord);
            }
            else
            {
                lngRes = 1;
            }
            if (lngRes > 0)
            {
                //2 复用模板
                lngRes = m_lngAddNewValueTemplateItem(p_objPrincipal, p_objNewRecord);
            }
            return lngRes;
        }
        #endregion

        //        #region 根据检验项目ID查询表T_AID_LIS_VALUETEMPLATE_ITEM的记录 
        //        [AutoComplete]
        //        public long m_lngGetValueTemplateItemByCheckItemID(System.Security.Principal.IPrincipal p_objPrincipal,string p_strCheckItemID,
        //            out clsLisValueTemplateItem_VO p_objResult)
        //        {
        //            long lngRes=0;
        //            p_objResult = null;
        //            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc","m_lngGetValueTemplateItemByCheckItemID");
        //            if(lngRes < 0)
        //            {
        //                return -1;
        //            }

        //            string strSQL = @"SELECT a.*,b.TEMPLATE_NAME_VCHR
        //								FROM T_AID_LIS_VALUETEMPLATE_ITEM a,
        //									 T_AID_LIS_VALUETEMPLATE b
        //							   WHERE a.TEMPLATE_ID_CHR = b.TEMPLATE_ID_CHR
        //								 AND a.CHECK_ITEM_ID_CHR = '"+p_strCheckItemID+@"'";

        //            try
        //            {
        //                DataTable dtbResult = new DataTable();
        //                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
        //                objHRPSvc.Dispose();
        //                if(lngRes > 0 && dtbResult.Rows.Count > 0)
        //                {
        //                    p_objResult = new clsLisValueTemplateItem_VO();
        //                    p_objResult.m_strCHECK_ITEM_ID_CHR = dtbResult.Rows[0]["CHECK_ITEM_ID_CHR"].ToString().Trim();
        //                    p_objResult.m_strTEMPLATE_ID_CHR = dtbResult.Rows[0]["TEMPLATE_ID_CHR"].ToString().Trim();
        //                    p_objResult.m_strTEMPLATE_NAME_VCHR = dtbResult.Rows[0]["TEMPLATE_NAME_VCHR"].ToString().Trim();
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

        //        #region 根据模板ID查询相应的模板信息
        //        [AutoComplete]
        //        public long m_lngGetValueTemplateByTemplateID(System.Security.Principal.IPrincipal p_objPrincipal,string p_strTemplateID,
        //            out clsLisValueTemplate_VO p_objResult)
        //        {
        //            long lngRes = 0;
        //            p_objResult = null;
        //            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc","m_lngGetValueTemplateByTemplateID");
        //            if(lngRes < 0)
        //            {
        //                return -1;
        //            }

        //            string strSQL = @"SELECT *
        //							    FROM t_aid_lis_valuetemplate
        //							   WHERE template_id_chr = '"+p_strTemplateID+@"'";
        //            DataTable dtbResult = null;
        //            try
        //            {
        //                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbResult);
        //                objHRPSvc.Dispose();
        //                if(lngRes > 0 && dtbResult != null && dtbResult.Rows.Count > 0)
        //                {
        //                    p_objResult = new clsLisValueTemplate_VO();
        //                    p_objResult = new clsLisValueTemplate_VO();
        //                    p_objResult.m_strTEMPLATE_ID_CHR = dtbResult.Rows[0]["TEMPLATE_ID_CHR"].ToString().Trim();
        //                    p_objResult.m_strTEMPLATE_NAME_VCHR = dtbResult.Rows[0]["TEMPLATE_NAME_VCHR"].ToString().Trim();
        //                    p_objResult.m_strCHECK_CATEGORY_ID_CHR = dtbResult.Rows[0]["CHECK_CATEGORY_ID_CHR"].ToString().Trim();
        //                    p_objResult.m_strSAMPLE_TYPE_ID_CHR = dtbResult.Rows[0]["SAMPLE_TYPE_ID_CHR"].ToString().Trim();
        //                    p_objResult.m_strSUMMARY_VCHR = dtbResult.Rows[0]["SUMMARY_VCHR"].ToString().Trim();
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

        #region 新增记录到表T_AID_LIS_VALUETEMPLATE
        [AutoComplete]
        public long m_lngAddNewValueTemplate(System.Security.Principal.IPrincipal p_objPrincipal, clsLisValueTemplate_VO p_objRecord)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc", "m_lngAddNewValueTemplate");
            if (lngRes < 0)
            {
                return -1;
            }

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            lngRes = objHRPSvc.lngGenerateID(6, "TEMPLATE_ID_CHR", "T_AID_LIS_VALUETEMPLATE", out p_objRecord.m_strTEMPLATE_ID_CHR);
            if (lngRes < 0)
                return lngRes;
            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = "INSERT INTO T_AID_LIS_VALUETEMPLATE (TEMPLATE_ID_CHR,TEMPLATE_NAME_VCHR,CHECK_CATEGORY_ID_CHR,SAMPLE_TYPE_ID_CHR,SUMMARY_VCHR) VALUES (?,?,?,?,?)";
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(5, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objRecord.m_strTEMPLATE_ID_CHR;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strTEMPLATE_NAME_VCHR;
                objLisAddItemRefArr[2].Value = p_objRecord.m_strCHECK_CATEGORY_ID_CHR;
                objLisAddItemRefArr[3].Value = p_objRecord.m_strSAMPLE_TYPE_ID_CHR;
                objLisAddItemRefArr[4].Value = p_objRecord.m_strSUMMARY_VCHR;
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

        #region 删除表T_AID_LIS_VALUETEMPLATE的记录
        [AutoComplete]
        public long m_lngDelValueTemplate(System.Security.Principal.IPrincipal p_objPrincipal, string p_strTemplateID)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc", "m_lngDelValueTemplate");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"DELETE FROM T_AID_LIS_VALUETEMPLATE WHERE TEMPLATE_ID_CHR = '" + p_strTemplateID + "'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                long lngEffRec = -1;
                lngRes = objHRPSvc.DoExcuteForDelete(strSQL, ref lngEffRec);
                if (lngEffRec > -1)
                {
                    lngRes = 1;
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

        #region 新增记录到表T_AID_LIS_VALUETEMPLATE_DETAIL
        [AutoComplete]
        public long m_lngAddNewValueTemplateDetail(System.Security.Principal.IPrincipal p_objPrincipal, clsLisValueTemplateDetail_VO p_objRecord)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc", "m_lngAddNewValueTemplateDetail");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"INSERT INTO T_AID_LIS_VALUETEMPLATE_Detail
				(TEMPLATE_ID_CHR,INDEX_INT,SEQ_INT,VALUE_VCHR,DEFAULT_VALUE_FLAG_INT) VALUES (?,?,?,?,?)";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                DataTable dtbIDResult = null;
                string strSQL_GETID = @"SELECT MAX(INDEX_INT) FROM T_AID_LIS_VALUETEMPLATE_Detail WHERE TEMPLATE_ID_CHR = '" + p_objRecord.m_strTEMPLATE_ID_CHR + "'";
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL_GETID, ref dtbIDResult);
                if (lngRes > 0)
                {
                    if (dtbIDResult == null)
                    {
                        p_objRecord.m_intINDEX_INT = 0;
                    }
                    else
                    {
                        if (dtbIDResult.Rows.Count > 0)
                        {
                            if (dtbIDResult.Rows[0][0].ToString().Trim() != "")
                            {
                                p_objRecord.m_intINDEX_INT = int.Parse(dtbIDResult.Rows[0][0].ToString().Trim()) + 1;
                            }
                            else
                            {
                                p_objRecord.m_intINDEX_INT = 0;
                            }
                        }
                        else
                        {
                            p_objRecord.m_intINDEX_INT = 0;
                        }
                    }
                }
                else
                {
                    return 0;
                }
                p_objRecord.m_intSEQ_INT = p_objRecord.m_intINDEX_INT;

                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(5, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objRecord.m_strTEMPLATE_ID_CHR;
                objLisAddItemRefArr[1].Value = p_objRecord.m_intINDEX_INT;
                objLisAddItemRefArr[2].Value = p_objRecord.m_intSEQ_INT;
                objLisAddItemRefArr[3].Value = p_objRecord.m_strVALUE_VCHR;
                objLisAddItemRefArr[4].Value = p_objRecord.m_intDEFAULT_VALUE_FLAG_INT;
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

        #region 删除表T_AID_LIS_VALUETEMPLATE_DETAIL的记录
        [AutoComplete]
        public long m_lngDelVauleTemplateDetail(System.Security.Principal.IPrincipal p_objPrincipal, string p_strTemplateID, int p_strIdx)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc", "m_lngDelVauleTemplateDetail");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"DELETE FROM T_AID_LIS_VALUETEMPLATE_DETAIL WHERE TEMPLATE_ID_CHR = '" + p_strTemplateID + "' AND INDEX_INT = " + p_strIdx + "";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                long lngEffRec = -1;
                lngRes = objHRPSvc.DoExcuteForDelete(strSQL, ref lngEffRec);
                if (lngEffRec > -1)
                {
                    lngRes = 1;
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

        #region 更新表T_AID_LIS_VALUETEMPLATE_DETAIL的记录
        [AutoComplete]
        public long m_lngModifyVauleTemplateDetail(System.Security.Principal.IPrincipal p_objPrincipal, clsLisValueTemplateDetail_VO p_objRecord)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc", "m_lngModifyVauleTemplateDetail");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"UPDATE t_aid_lis_valuetemplate_detail
								 SET value_vchr = '" + p_objRecord.m_strVALUE_VCHR + @"',
									 DEFAULT_VALUE_FLAG_INT = " + p_objRecord.m_intDEFAULT_VALUE_FLAG_INT + @"
							   WHERE template_id_chr = '" + p_objRecord.m_strTEMPLATE_ID_CHR + @"' 
								 AND index_int = '" + p_objRecord.m_intINDEX_INT + @"'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);
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

        #region 根据模板ID更新T_AID_LIS_VALUETEMPLATE_DETAIL的默认标记
        [AutoComplete]
        public long m_lngSetDefaultFlagByTemplateID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strTemplateID,
            int p_intFlag)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc", "m_lngSetDefaultFlagByTemplateID");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"UPDATE t_aid_lis_valuetemplate_detail
								 SET DEFAULT_VALUE_FLAG_INT = " + p_intFlag + @"
							   WHERE template_id_chr = '" + p_strTemplateID + @"'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);
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

        #region 根据模板ID和idx更新T_AID_LIS_VALUETEMPLATE_DETAIL的默认标记
        [AutoComplete]
        public long m_lngSetDefaultFlagByTemplateIDAndIdx(System.Security.Principal.IPrincipal p_objPrincipal, string p_strTemplateID, string p_strIdx,
            int p_intFlag)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc", "m_lngSetDefaultFlagByTemplateID");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"UPDATE t_aid_lis_valuetemplate_detail
								 SET DEFAULT_VALUE_FLAG_INT = " + p_intFlag + @"
							   WHERE template_id_chr = '" + p_strTemplateID + @"'
								 AND index_int = '" + p_strIdx + @"'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);
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

        #region 新增检验项目的模板及其明细
        [AutoComplete]
        public long m_lngAddNewCheckItemVauleTemplate(System.Security.Principal.IPrincipal p_objPrincipal, clsLisValueTemplate_VO p_objValueTemplate,
            clsLisValueTemplateItem_VO p_objValueTemplateItem, clsLisValueTemplateDetail_VO[] p_objValueTemplateDetailArr)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc", "m_lngAddNewCheckItemVauleTemplate");
            if (lngRes < 0)
            {
                return -1;
            }

            //1. 新增模板
            lngRes = m_lngAddNewValueTemplate(p_objPrincipal, p_objValueTemplate);
            if (lngRes > 0)
            {
                //2. 新增模板明细
                if (p_objValueTemplateDetailArr != null)
                {
                    for (int i = 0; i < p_objValueTemplateDetailArr.Length; i++)
                    {
                        p_objValueTemplateDetailArr[i].m_strTEMPLATE_ID_CHR = p_objValueTemplate.m_strTEMPLATE_ID_CHR;
                        lngRes = m_lngAddNewValueTemplateDetail(p_objPrincipal, p_objValueTemplateDetailArr[i]);
                    }
                }
                if (lngRes > 0)
                {
                    p_objValueTemplateItem.m_strTEMPLATE_ID_CHR = p_objValueTemplate.m_strTEMPLATE_ID_CHR;
                    lngRes = m_lngAddNewValueTemplateItem(p_objPrincipal, p_objValueTemplateItem);
                }
            }
            return lngRes;
        }
        #endregion

        #region 批量新增、删除和修改模板明细信息
        [AutoComplete]
        public long m_lngValueTemplateDetailArr(System.Security.Principal.IPrincipal p_objPrincipal, ArrayList p_objAddNewArr,
            ArrayList p_objDelArr, ArrayList p_objUpdArr, string p_strTemplateID, string p_strIdx)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc", "m_lngValueTemplateDetailArr");
            if (lngRes < 0)
            {
                return -1;
            }

            //1. 新增
            if (p_objAddNewArr != null)
            {
                for (int i = 0; i < p_objAddNewArr.Count; i++)
                {
                    lngRes = m_lngAddNewValueTemplateDetail(p_objPrincipal, (clsLisValueTemplateDetail_VO)p_objAddNewArr[i]);
                }
            }

            //2. 修改
            if (p_objUpdArr != null)
            {
                for (int i = 0; i < p_objUpdArr.Count; i++)
                {
                    lngRes = m_lngModifyVauleTemplateDetail(p_objPrincipal, (clsLisValueTemplateDetail_VO)p_objUpdArr[i]);
                }
            }

            //3. 删除
            if (p_objDelArr != null)
            {
                for (int i = 0; i < p_objDelArr.Count; i++)
                {
                    lngRes = m_lngDelVauleTemplateDetail(p_objPrincipal, ((clsLisValueTemplateDetail_VO)p_objDelArr[i]).m_strTEMPLATE_ID_CHR,
                        ((clsLisValueTemplateDetail_VO)p_objDelArr[i]).m_intINDEX_INT);
                }
            }

            //4.更新标志位
            if (p_strTemplateID != "" && p_strIdx != "")
            {
                lngRes = m_lngSetDefaultFlagByTemplateID(p_objPrincipal, p_strTemplateID, 0);
                if (lngRes > 0)
                {
                    lngRes = m_lngSetDefaultFlagByTemplateIDAndIdx(p_objPrincipal, p_strTemplateID, p_strIdx, 1);
                }
            }
            return lngRes;
        }
        #endregion

        //#region 根据检验项目ID查询模板的所有信息
        //[AutoComplete]
        //public long m_lngGetAllTemplateInfoByCheckItemID(System.Security.Principal.IPrincipal p_objPrincipal,string p_strCheckItemID,
        //    out clsLisValueTemplateItem_VO p_objTemplateItem,out clsLisValueTemplate_VO p_objTemplate,
        //    out clsLisValueTemplateDetail_VO[] p_objTemplateDetailArr)
        //{
        //    long lngRes=0;
        //    p_objTemplateItem= null;
        //    p_objTemplate = null;
        //    p_objTemplateDetailArr = null;
        //    clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //    lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc","m_lngGetAllTemplateInfoByCheckItemID");
        //    if(lngRes < 0)
        //    {
        //        return -1;
        //    }

        //    lngRes = m_lngGetValueTemplateItemByCheckItemID(p_objPrincipal,p_strCheckItemID,out p_objTemplateItem);
        //    if(lngRes > 0 && p_objTemplateItem != null)
        //    {
        //        lngRes = m_lngGetValueTemplateByTemplateID(p_objPrincipal,p_objTemplateItem.m_strTEMPLATE_ID_CHR,out p_objTemplate);
        //        if(lngRes > 0 && p_objTemplate != null)
        //        {
        //            lngRes = m_lngGetTemplateDetailByTemplateID(p_objPrincipal,p_objTemplateItem.m_strTEMPLATE_ID_CHR,out p_objTemplateDetailArr);
        //        }
        //    }
        //    return lngRes;
        //}
        //#endregion

        #endregion

        //        #region 根据检验类别获取检验项目 
        //        [AutoComplete]
        //        public long m_lngGetCheckItemArrByCheckCategory(System.Security.Principal.IPrincipal p_objPrincipal,string p_strCheckCategory,
        //            out DataTable p_dtbResultArr)
        //        {
        //            long lngRes = 0;
        //            p_dtbResultArr = null;

        //            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc","m_lngGetCheckItemArrByCheckCategory");
        //            if(lngRes < 0)
        //            {
        //                return -1;
        //            }

        //            string strSQL = @"SELECT *
        //								FROM t_bse_lis_check_item
        //							   WHERE check_category_id_chr = '"+p_strCheckCategory+@"'";
        //            try
        //            {
        //                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref p_dtbResultArr);
        //                objHRPSvc.Dispose();
        //            }
        //            catch(Exception objEx)
        //            {
        //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //                bool blnRes = objLogger.LogError(objEx);
        //            }
        //            return lngRes;
        //        }
        //        #endregion

        #region 修改检验项目及参考值范围
        [AutoComplete]
        public long m_lngSetCheckItemAndRef(System.Security.Principal.IPrincipal p_objPrincipal, clsCheckItem_VO p_objCheckItem,
            clsCheckItemRef_VO[] p_objCheckItemRefArr)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc", "m_lngDelCheckItem");
            if (lngRes < 0)
            {
                return -1;
            }

            lngRes = m_lngSetCheckItemDetailByCheckItemID(p_objPrincipal, ref p_objCheckItem);
            if (lngRes > 0 && p_objCheckItemRefArr != null)
            {
                lngRes = m_lngDelCheckItemRef(p_objPrincipal, p_objCheckItem.m_strCheck_Item_ID);
                if (lngRes > 0)
                {
                    string Sql = @"select deptid_chr, modify_dat, deptname_vchr, category_int,
                                           inpatientoroutpatient_int, operatorid_chr, address_vchr, pycode_chr,
                                           attributeid, parentid, createdate_dat, status_int, deactivate_dat,
                                           wbcode_chr, code_vchr, extendid_vchr, shortno_chr, stdbed_count_int,
                                           putmed_int
                                      from t_bse_deptdesc 
                                     where status_int = 1 
                                       and ((inpatientoroutpatient_int = 1 or inpatientoroutpatient_int = 2) or parentid = 0)
                                  order by code_vchr";
                    clsHRPTableService svc = new clsHRPTableService();
                    DataTable dtDept = null;
                    svc.lngGetDataTableWithoutParameters(Sql, ref dtDept);
                    for (int i = 0; i < p_objCheckItemRefArr.Length; i++)
                    {
                        lngRes = m_lngAddNewItemRef(p_objPrincipal, ref p_objCheckItemRefArr[i], dtDept);
                    }
                }
            }
            return lngRes;
        }
        #endregion

        #region 删除检验项目及参考值范围
        [AutoComplete]
        public long m_lngDelCheckItemAndRef(System.Security.Principal.IPrincipal p_objPrincipal, string p_strCheckItemID)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc", "m_lngDelCheckItem");
            if (lngRes < 0)
            {
                return -1;
            }

            lngRes = m_lngDelCheckItemRef(p_objPrincipal, p_strCheckItemID);
            if (lngRes > 0)
            {
                lngRes = m_lngDelCheckItem(p_objPrincipal, p_strCheckItemID);
            }
            return lngRes;
        }
        #endregion

        //        #region 根据检验类别和样品类别,样本组,查询所有的检验项目 
        //        [AutoComplete]
        //        public long m_lngQryCheckItemByCheckCategoryAndSampleType(System.Security.Principal.IPrincipal p_objPrincipal,
        //            string p_strCheckCategory,string p_strSampleType,string p_strSampleGroup,out DataTable p_dtbCheckItem)
        //        {
        //            long lngRes = 0;
        //            p_dtbCheckItem = null;

        //            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc","m_lngQryCheckItemByCheckCategoryAndSampleType");
        //            if(lngRes < 0)
        //            {
        //                return -1;
        //            }

        //            string strSQL = @"SELECT t1.rptno_chr, t1.pycode_chr, t1.unit_chr, t1.check_item_name_vchr,
        //                                   t1.is_sex_related_chr, t1.check_item_english_name_vchr,
        //                                   t1.is_age_related_chr, t1.is_sample_related_chr, t1.formula_vchr,
        //                                   t1.test_methods_vchr, t1.clinic_meaning_vchr, t1.check_item_id_chr,
        //                                   t1.shortname_chr, t1.is_qc_required_chr, t1.resulttype_chr,
        //                                   t1.ref_value_range_vchr, t1.wbcode_chr, t1.assist_code01_chr,
        //                                   t1.assist_code02_chr, t1.is_no_food_required_chr,
        //                                   t1.is_physical_exam_required_chr, t1.is_reservation_required_chr,
        //                                   t1.sample_valid_time_dec, t1.sample_valid_time_unit_chr, t1.modify_dat,
        //                                   t1.operatorid_chr, t1.check_category_id_chr, t1.ref_max_val_vchr,
        //                                   t1.ref_min_val_vchr, t1.sampletype_vchr, t1.is_menses_related_chr,
        //                                   t1.is_calculated_chr, t1.formula_user_vchr, t1.alarm_low_val_vchr,
        //                                   t1.alarm_up_val_vchr, t1.alert_value_range_vchr, 
        //                                     t2.check_category_desc_vchr
        //								FROM t_bse_lis_check_item t1,
        //									 t_bse_lis_check_category t2,
        //									 t_aid_lis_sampletype t3,
        //									 v_lis_bse_sample_group_items t4
        //							   WHERE t1.check_category_id_chr = t2.check_category_id_chr(+)
        //								 AND t1.check_item_id_chr = t4.check_item_id_chr(+)
        //								 AND t1.sampletype_vchr = t3.sample_type_id_chr
        //								 AND t1.sampletype_vchr = '" +p_strSampleType+@"'
        //								 AND t1.check_category_id_chr = '"+p_strCheckCategory+@"'";
        //            if(p_strSampleGroup != null && p_strSampleGroup.Trim() != "")
        //            {
        //                strSQL += " AND t4.sample_group_id_chr = '"+p_strSampleGroup+"'";
        //            }
        //            strSQL += " ORDER BY t1.check_item_id_chr";
        //            p_dtbCheckItem = null;
        //            try
        //            {
        //                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref p_dtbCheckItem);
        //                objHRPSvc.Dispose();
        //            }
        //            catch(Exception objEx)
        //            {
        //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //                bool blnRes = objLogger.LogError(objEx);
        //            }
        //            return lngRes;
        //        }
        //        #endregion

        //#region 根据检验类别和样本类别组合查询相关的检验项目信息
        //[AutoComplete]
        //public long m_lngGetCheckItemArrByCondition(System.Security.Principal.IPrincipal p_objPrincipal,string p_strCheckCategoryID,
        //    string p_strSampleTypeID,out clsCheckItem_VO[] p_objResultArr)
        //{
        //    long lngRes = 0;
        //    p_objResultArr = null;
        //    clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //    lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc","m_lngGetCheckItemArrByCondition");
        //    if(lngRes < 0)
        //    {
        //        return -1;
        //    }

        //    string strSQL = @"SELECT * FROM T_BSE_LIS_CHECK_ITEM WHERE 1=1 ";
        //    if(p_strCheckCategoryID != "")
        //    {
        //        strSQL += " AND CHECK_CATEGORY_ID_CHR = '"+p_strCheckCategoryID+"'";
        //    }
        //    if(p_strSampleTypeID != "")
        //    {
        //        strSQL += " AND SAMPLETYPE_VCHR = '"+p_strSampleTypeID+"'";
        //    }
        //    try
        //    {
        //        DataTable dtbResult = new DataTable();
        //        com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //        lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
        //        objHRPSvc.Dispose();
        //        if(lngRes > 0 && dtbResult.Rows.Count > 0)
        //        {
        //            p_objResultArr = new clsCheckItem_VO[dtbResult.Rows.Count];
        //            for(int i1=0;i1<p_objResultArr.Length;i1++)
        //            {
        //                p_objResultArr[i1] = new clsCheckItem_VO();
        //                p_objResultArr[i1].m_strRPTNO = dtbResult.Rows[i1]["RPTNO_CHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strPycode = dtbResult.Rows[i1]["PYCODE_CHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strUnit = dtbResult.Rows[i1]["UNIT_CHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strCheck_Item_Name = dtbResult.Rows[i1]["CHECK_ITEM_NAME_VCHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strIs_Sex_Related = dtbResult.Rows[i1]["IS_SEX_RELATED_CHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strCheck_Item_English_Name = dtbResult.Rows[i1]["CHECK_ITEM_ENGLISH_NAME_VCHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strIs_Age_Related = dtbResult.Rows[i1]["IS_AGE_RELATED_CHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strIs_Sample_Related = dtbResult.Rows[i1]["IS_SAMPLE_RELATED_CHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strFormula = dtbResult.Rows[i1]["FORMULA_VCHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strTest_Method = dtbResult.Rows[i1]["TEST_METHODS_VCHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strClinic_meaning = dtbResult.Rows[i1]["CLINIC_MEANING_VCHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strCheck_Item_ID = dtbResult.Rows[i1]["CHECK_ITEM_ID_CHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strShortName = dtbResult.Rows[i1]["SHORTNAME_CHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strIs_Qc_Required = dtbResult.Rows[i1]["IS_QC_REQUIRED_CHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strResultType = dtbResult.Rows[i1]["RESULTTYPE_CHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strRef_Value_Range = dtbResult.Rows[i1]["REF_VALUE_RANGE_VCHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strWbcode = dtbResult.Rows[i1]["WBCODE_CHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strAssist_Code01 = dtbResult.Rows[i1]["ASSIST_CODE01_CHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strAssist_Code02 = dtbResult.Rows[i1]["ASSIST_CODE02_CHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strIs_No_Food_Required = dtbResult.Rows[i1]["IS_NO_FOOD_REQUIRED_CHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strIs_Physical_Exam_Required = dtbResult.Rows[i1]["IS_PHYSICAL_EXAM_REQUIRED_CHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strIs_Reservation_Required = dtbResult.Rows[i1]["IS_RESERVATION_REQUIRED_CHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strSample_Valid_Time = dtbResult.Rows[i1]["SAMPLE_VALID_TIME_DEC"].ToString().Trim();
        //                p_objResultArr[i1].m_strSample_Valid_Time_Unit = dtbResult.Rows[i1]["SAMPLE_VALID_TIME_UNIT_CHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strModify_Dat = Convert.ToDateTime(dtbResult.Rows[i1]["MODIFY_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
        //                p_objResultArr[i1].m_strOperator_ID = dtbResult.Rows[i1]["OPERATORID_CHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strCheck_Category_ID = dtbResult.Rows[i1]["CHECK_CATEGORY_ID_CHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strRef_Value_Max = dtbResult.Rows[i1]["REF_MAX_VAL_VCHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strRef_Value_Min = dtbResult.Rows[i1]["REF_MIN_VAL_VCHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strSampleTypeID = dtbResult.Rows[i1]["SAMPLETYPE_VCHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strIs_Menses_Related = dtbResult.Rows[i1]["IS_MENSES_RELATED_CHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strIs_Calculated = dtbResult.Rows[i1]["IS_CALCULATED_CHR"].ToString().Trim();
        //            }
        //        }
        //    }
        //    catch(Exception objEx)
        //    {
        //        string strTmp=objEx.Message;
        //        com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //        bool blnRes = objLogger.LogError(objEx);
        //    }
        //    return lngRes;
        //}
        //#endregion

        //#region 根据check_item_id查询对应的检验项目信息VO 
        ///// <summary>
        ///// 根据check_item_id查询对应的检验项目信息VO
        ///// </summary>
        ///// <param name="p_objPrincipal"></param>
        ///// <param name="p_strCheckItemID"></param>
        ///// <param name="p_objCheckItemVO"></param>
        ///// <returns></returns>
        //[AutoComplete]
        //public long m_lngGetCheckItemVOByCheckItemID(System.Security.Principal.IPrincipal p_objPrincipal,string p_strCheckItemID,out clsCheckItem_VO p_objCheckItemVO)
        //{
        //    long lngRes = 0;
        //    p_objCheckItemVO = null;

        //    clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //    lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc","m_lngGetCheckItemVOByCheckItemID");
        //    if(lngRes < 0)
        //    {
        //        return -1;
        //    }

        //    lngRes = 0;
        //    DataTable dtbItem = null;
        //    lngRes = m_lngGetCheckItemInfoByCheckItemID(p_objPrincipal,p_strCheckItemID,out dtbItem);
        //    if(lngRes > 0 && dtbItem != null && dtbItem.Rows.Count != 0)
        //    {
        //        p_objCheckItemVO = new clsCheckItem_VO();
        //        ConstructCheckItemVO(dtbItem.Rows[0],ref p_objCheckItemVO);
        //    }
        //    return lngRes;
        //}
        //#endregion


        //#region 根据check_item_id、年龄、性别和月经周期查询符合条件的参考值范围 
        //[AutoComplete]
        //public long m_lngGetCheckItemRefByCondition(System.Security.Principal.IPrincipal p_objPrincipal,string p_strAge,string p_strSex,string p_strMenses,
        //    string p_strCheckItemID,out clsCheckItemRef_VO objCheckItemRefVO)
        //{
        //    long lngRes = 0;
        //    objCheckItemRefVO = null;

        //    clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //    lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc","m_lngGetCheckItemRefByCondition");
        //    if(lngRes < 0)
        //    {
        //        return -1;
        //    }

        //    DataTable dtbCheckItem = null;
        //    DataTable dtbCheckItemRef = null;

        //    string strSQL = @"SELECT * FROM T_BSE_LIS_ITEMREF WHERE CHECK_ITEM_ID_CHR = '"+p_strCheckItemID+"'";

        //    try
        //    {
        //        lngRes = m_lngGetCheckItemInfoByCheckItemID(p_objPrincipal,p_strCheckItemID,out dtbCheckItem);
        //        if(lngRes > 0 && dtbCheckItem != null)
        //        {
        //            if(dtbCheckItem.Rows.Count > 0)
        //            {
        //                //判断参考值和月经周期有关
        //                if(dtbCheckItem.Rows[0]["IS_MENSES_RELATED_CHR"].ToString().Trim() == "1")
        //                {
        //                    if(p_strMenses == "" || p_strMenses == null)
        //                    {
        //                        return 0;
        //                    }
        //                    else
        //                    {
        //                        strSQL += " AND MENSES_ID_CHR = '"+p_strMenses+"'";
        //                    }
        //                }
        //                //判断参考值和年龄有关
        //                if(dtbCheckItem.Rows[0]["IS_AGE_RELATED_CHR"].ToString().Trim() == "1")
        //                {
        //                    if(p_strAge == "" || p_strAge == null)
        //                    {
        //                        return 0;
        //                    }
        //                }
        //                //判断参考值和性别有关
        //                if(dtbCheckItem.Rows[0]["IS_SEX_RELATED_CHR"].ToString().Trim() == "1")
        //                {
        //                    if(p_strSex == "" || p_strSex == null)
        //                    {
        //                        return 0;
        //                    }
        //                    else
        //                    {
        //                        strSQL += " AND SEX_VCHR = '"+p_strSex+"'";
        //                    }
        //                }

        //                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbCheckItemRef);
        //                objHRPSvc.Dispose();

        //                if(lngRes>0 && dtbCheckItemRef != null)
        //                {
        //                    if(dtbCheckItemRef.Rows.Count > 0)
        //                    {
        //                        //当参考值和年龄有关
        //                        if(dtbCheckItem.Rows[0]["IS_AGE_RELATED_CHR"].ToString().Trim() == "1")
        //                        {
        //                            string[] strAgeArr = p_strAge.Split(new char[]{' '});
        //                            if(strAgeArr != null && strAgeArr.Length == 2)
        //                            {
        //                                for(int i=0;i<dtbCheckItemRef.Rows.Count;i++)
        //                                {
        //                                    string [] strFromAgeArr = dtbCheckItemRef.Rows[i]["FROM_AGE_DEC"].ToString().Trim().Split(new char[]{' '});
        //                                    int intFromAge = 0;
        //                                    int intToAge = 0;
        //                                    if(strFromAgeArr[1].Trim() == strAgeArr[1].Trim())
        //                                    {
        //                                        if(strFromAgeArr != null && strFromAgeArr.Length == 2)
        //                                        {
        //                                            intFromAge = int.Parse(strFromAgeArr[0]);
        //                                        }
        //                                    }

        //                                    string [] strToAgeArr = dtbCheckItemRef.Rows[i]["TO_AGE_DEC"].ToString().Trim().Split(new char[]{' '});
        //                                    if(strFromAgeArr[1].Trim() == strAgeArr[1].Trim())
        //                                    {
        //                                        if(strToAgeArr != null && strToAgeArr.Length == 2)
        //                                        {
        //                                            intToAge = int.Parse(strToAgeArr[0]);
        //                                        }
        //                                    }

        //                                    if(intFromAge <= int.Parse(strAgeArr[0].Trim()) && int.Parse(strAgeArr[0].Trim()) <= intToAge)
        //                                    {
        //                                        objCheckItemRefVO = new clsCheckItemRef_VO();
        //                                        objCheckItemRefVO.m_strCheck_Item_ID = dtbCheckItemRef.Rows[i]["CHECK_ITEM_ID_CHR"].ToString().Trim();
        //                                        objCheckItemRefVO.m_strClinic_Meaning = dtbCheckItemRef.Rows[i]["CLINIC_MEANING_VCHR"].ToString().Trim();
        //                                        objCheckItemRefVO.m_strFrom_Age = dtbCheckItemRef.Rows[i]["FROM_AGE_DEC"].ToString().Trim();//intFromAge.ToString().Trim();
        //                                        objCheckItemRefVO.m_strTo_Age = dtbCheckItemRef.Rows[i]["TO_AGE_DEC"].ToString().Trim();//intToAge.ToString().Trim();
        //                                        objCheckItemRefVO.m_strSeq_Int = dtbCheckItemRef.Rows[i]["SEQ_INT"].ToString().Trim();
        //                                        objCheckItemRefVO.m_strMenses_ID = dtbCheckItemRef.Rows[i]["MENSES_ID_CHR"].ToString().Trim();
        //                                        objCheckItemRefVO.m_strMin_Val = dtbCheckItemRef.Rows[i]["MIN_VAL_VCHR"].ToString().Trim();
        //                                        objCheckItemRefVO.m_strMax_Val = dtbCheckItemRef.Rows[i]["MAX_VAL_VCHR"].ToString().Trim();
        //                                        objCheckItemRefVO.m_strRef_Val = dtbCheckItemRef.Rows[i]["REF_VALUE_RANGE_VCHR"].ToString().Trim();
        //                                        objCheckItemRefVO.m_strSex = dtbCheckItemRef.Rows[i]["SEX_VCHR"].ToString().Trim();
        //                                        break;
        //                                    }
        //                                }
        //                            }
        //                        }
        //                        else
        //                        {
        //                            objCheckItemRefVO = new clsCheckItemRef_VO();
        //                            objCheckItemRefVO.m_strCheck_Item_ID = dtbCheckItemRef.Rows[0]["CHECK_ITEM_ID_CHR"].ToString().Trim();
        //                            objCheckItemRefVO.m_strClinic_Meaning = dtbCheckItemRef.Rows[0]["CLINIC_MEANING_VCHR"].ToString().Trim();
        //                            objCheckItemRefVO.m_strFrom_Age = dtbCheckItemRef.Rows[0]["FROM_AGE_DEC"].ToString().Trim();
        //                            objCheckItemRefVO.m_strTo_Age = dtbCheckItemRef.Rows[0]["TO_AGE_DEC"].ToString().Trim();
        //                            objCheckItemRefVO.m_strSeq_Int = dtbCheckItemRef.Rows[0]["SEQ_INT"].ToString().Trim();
        //                            objCheckItemRefVO.m_strMenses_ID = dtbCheckItemRef.Rows[0]["MENSES_ID_CHR"].ToString().Trim();
        //                            objCheckItemRefVO.m_strMin_Val = dtbCheckItemRef.Rows[0]["MIN_VAL_VCHR"].ToString().Trim();
        //                            objCheckItemRefVO.m_strMax_Val = dtbCheckItemRef.Rows[0]["MAX_VAL_VCHR"].ToString().Trim();
        //                            objCheckItemRefVO.m_strRef_Val = dtbCheckItemRef.Rows[0]["REF_VALUE_RANGE_VCHR"].ToString().Trim();
        //                            objCheckItemRefVO.m_strSex = dtbCheckItemRef.Rows[0]["SEX_VCHR"].ToString().Trim();
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            return lngRes;
        //        }
        //    }
        //    catch(Exception objEx)
        //    {
        //        com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //        bool blnRes = objLogger.LogError(objEx);
        //    }
        //    return lngRes;
        //}
        //#endregion

        //#region 根据check_item_id查询对应的检验项目信息 
        //[AutoComplete]
        //public long m_lngGetCheckItemInfoByCheckItemID(System.Security.Principal.IPrincipal p_objPrincipal,string p_strCheckItemID,out DataTable dtbCheckItem)
        //{
        //    long lngRes = 0;
        //    dtbCheckItem = null;

        //    clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //    lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc","m_lngGetCheckItemInfoByCheckItemID");
        //    if(lngRes < 0)
        //    {
        //        return -1;
        //    }

        //    string strSQL = @"SELECT * FROM t_bse_lis_check_item WHERE check_item_id_chr = '"+p_strCheckItemID+"'";
        //    try
        //    {
        //        com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //        lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbCheckItem);
        //        objHRPSvc.Dispose();
        //    }
        //    catch(Exception objEx)
        //    {
        //        com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //        bool blnRes = objLogger.LogError(objEx);
        //    }
        //    return lngRes;
        //}
        //#endregion

        #region 在t_bse_lis_check_item新增检验项目
        [AutoComplete]
        public long m_lngAddCheckItem(System.Security.Principal.IPrincipal p_objPrincipal, ref com.digitalwave.iCare.ValueObject.clsCheckItem_VO objCheckItemVO)
        {
            long lngRes = 0;
            string strSQL = @"insert into t_bse_lis_check_item
                (rptno_chr, pycode_chr, unit_chr, check_item_name_vchr,
                is_sex_related_chr, check_item_english_name_vchr,
                is_age_related_chr, is_sample_related_chr, formula_vchr,
                test_methods_vchr, clinic_meaning_vchr, check_item_id_chr,
                shortname_chr, is_qc_required_chr, resulttype_chr,
                ref_value_range_vchr, wbcode_chr, assist_code01_chr,
                assist_code02_chr, is_no_food_required_chr,
                is_physical_exam_required_chr, is_reservation_required_chr,
                sample_valid_time_dec,sample_valid_time_unit_chr, modify_dat,
                operatorid_chr, check_category_id_chr, ref_min_val_vchr, ref_max_val_vchr,sampletype_vchr,
                is_calculated_chr,formula_user_vchr,alarm_low_val_vchr,alarm_up_val_vchr,alert_value_range_vchr,itemprice_mny
                 )
              values (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?)";
            try
            {
                System.Data.IDataParameter[] objLisAddCheckItemArr = null;
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(36, out objLisAddCheckItemArr);

                string strCheckItemID = objHRPSvc.m_strGetNewID("T_BSE_LIS_CHECK_ITEM", "CHECK_ITEM_ID_CHR", 6);
                objCheckItemVO.m_strCheck_Item_ID = strCheckItemID;
                objCheckItemVO.m_strModify_Dat = DateTime.Now.ToString().Trim();

                objLisAddCheckItemArr[0].Value = objCheckItemVO.m_strRPTNO;
                objLisAddCheckItemArr[1].Value = objCheckItemVO.m_strPycode;
                objLisAddCheckItemArr[2].Value = objCheckItemVO.m_strUnit;
                objLisAddCheckItemArr[3].Value = objCheckItemVO.m_strCheck_Item_Name;
                objLisAddCheckItemArr[4].Value = objCheckItemVO.m_strIs_Sex_Related;
                objLisAddCheckItemArr[5].Value = objCheckItemVO.m_strCheck_Item_English_Name;
                objLisAddCheckItemArr[6].Value = objCheckItemVO.m_strIs_Age_Related;
                objLisAddCheckItemArr[7].Value = objCheckItemVO.m_strIs_Sample_Related;
                objLisAddCheckItemArr[8].Value = objCheckItemVO.m_strFormula;
                objLisAddCheckItemArr[9].Value = objCheckItemVO.m_strTest_Method;
                objLisAddCheckItemArr[10].Value = objCheckItemVO.m_strClinic_meaning;
                objLisAddCheckItemArr[11].Value = objCheckItemVO.m_strCheck_Item_ID;
                objLisAddCheckItemArr[12].Value = objCheckItemVO.m_strShortName;
                objLisAddCheckItemArr[13].Value = objCheckItemVO.m_strIs_Qc_Required;
                objLisAddCheckItemArr[14].Value = objCheckItemVO.m_strResultType;
                objLisAddCheckItemArr[15].Value = objCheckItemVO.m_strRef_Value_Range;
                objLisAddCheckItemArr[16].Value = objCheckItemVO.m_strWbcode;
                objLisAddCheckItemArr[17].Value = objCheckItemVO.m_strAssist_Code01;
                objLisAddCheckItemArr[18].Value = objCheckItemVO.m_strAssist_Code02;
                objLisAddCheckItemArr[19].Value = objCheckItemVO.m_strIs_No_Food_Required;
                objLisAddCheckItemArr[20].Value = objCheckItemVO.m_strIs_Physical_Exam_Required;
                objLisAddCheckItemArr[21].Value = objCheckItemVO.m_strIs_Reservation_Required;
                objLisAddCheckItemArr[22].Value = objCheckItemVO.m_strSample_Valid_Time;
                objLisAddCheckItemArr[23].Value = objCheckItemVO.m_strSample_Valid_Time_Unit;
                objLisAddCheckItemArr[24].Value = System.DateTime.Parse(objCheckItemVO.m_strModify_Dat);
                objLisAddCheckItemArr[25].Value = objCheckItemVO.m_strOperator_ID;
                objLisAddCheckItemArr[26].Value = objCheckItemVO.m_strCheck_Category_ID;
                objLisAddCheckItemArr[27].Value = objCheckItemVO.m_strRef_Value_Min;
                objLisAddCheckItemArr[28].Value = objCheckItemVO.m_strRef_Value_Max;
                objLisAddCheckItemArr[29].Value = objCheckItemVO.m_strSampleTypeID;
                objLisAddCheckItemArr[30].Value = objCheckItemVO.m_strIs_Calculated;
                objLisAddCheckItemArr[31].Value = objCheckItemVO.m_strFormula_User_VCHR;
                objLisAddCheckItemArr[32].Value = objCheckItemVO.m_strALARM_LOW_VAL_VCHR;
                objLisAddCheckItemArr[33].Value = objCheckItemVO.m_strALARM_UP_VAL_VCHR;
                objLisAddCheckItemArr[34].Value = objCheckItemVO.m_strALERT_VALUE_RANGE_VCHR;
                if (!string.IsNullOrEmpty(objCheckItemVO.m_strItemprice_mny))
                {
                    objLisAddCheckItemArr[35].Value = Convert.ToDouble(objCheckItemVO.m_strItemprice_mny);
                }

                long lngRecEff = -1;

                //往表t_bse_lis_check_item增加记录
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, objLisAddCheckItemArr);
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

        #region 批量新增检验项目参考值范围
        [AutoComplete]
        public long m_lngAddCheckItemRefList(System.Security.Principal.IPrincipal p_objPrincipal, ref clsCheckItemRef_VO[] objCheckItemRefVOList)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc", "m_lngAddCheckItemRefList");
            if (lngRes < 0)
            {
                return -1;
            }

            for (int i = 0; i < objCheckItemRefVOList.Length; i++)
            {
                lngRes = m_lngAddNewItemRef(p_objPrincipal, ref objCheckItemRefVOList[i], null);
            }
            return lngRes;
        }
        #endregion

        #region 新增检验项目的参考值范围
        [AutoComplete]
        public long m_lngAddNewItemRef(System.Security.Principal.IPrincipal p_objPrincipal, ref com.digitalwave.iCare.ValueObject.clsCheckItemRef_VO objCheckItemRefVO, DataTable dtDepts)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc", "m_lngAddNewItemRef");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"INSERT INTO t_bse_lis_itemref(check_item_id_chr, min_val_vchr, seq_int, from_age_dec,
								ref_value_range_vchr, menses_id_chr, sex_vchr, to_age_dec,
								max_val_vchr, clinic_meaning_vchr, crvalmin, crvalmax )
							  VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(12, out objLisAddItemRefArr);

                objLisAddItemRefArr[0].Value = objCheckItemRefVO.m_strCheck_Item_ID;
                objLisAddItemRefArr[1].Value = objCheckItemRefVO.m_strMin_Val;
                objLisAddItemRefArr[2].Value = objCheckItemRefVO.m_strSeq_Int;
                objLisAddItemRefArr[3].Value = objCheckItemRefVO.m_strFrom_Age;
                objLisAddItemRefArr[4].Value = objCheckItemRefVO.m_strRef_Val;
                objLisAddItemRefArr[5].Value = objCheckItemRefVO.m_strMenses_ID;
                objLisAddItemRefArr[6].Value = objCheckItemRefVO.m_strSex;
                objLisAddItemRefArr[7].Value = objCheckItemRefVO.m_strTo_Age;
                objLisAddItemRefArr[8].Value = objCheckItemRefVO.m_strMax_Val;
                objLisAddItemRefArr[9].Value = objCheckItemRefVO.m_strClinic_Meaning;
                objLisAddItemRefArr[10].Value = objCheckItemRefVO.CrValMin;
                objLisAddItemRefArr[11].Value = objCheckItemRefVO.CrValMax;

                long lngRecEff = -1;
                //往表t_bse_lis_itemref增加记录
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, objLisAddItemRefArr);

                if (dtDepts != null && dtDepts.Rows.Count > 0 && !string.IsNullOrEmpty(objCheckItemRefVO.DeptNameArr))
                {
                    string[] deptNames = objCheckItemRefVO.DeptNameArr.Split(',');
                    strSQL = @"insert into t_criticalvalue_ref_lisdept (check_item_id_chr, seq_int, deptid_chr, deptname_vchr)
                                    values (?, ?, ?, ?)";
                    DataRow[] drr = null;
                    foreach (string deptName in deptNames)
                    {
                        drr = dtDepts.Select("deptname_vchr = '" + deptName + "'");
                        if (drr != null && drr.Length > 0)
                        {
                            objHRPSvc.CreateDatabaseParameter(4, out objLisAddItemRefArr);
                            objLisAddItemRefArr[0].Value = objCheckItemRefVO.m_strCheck_Item_ID;
                            objLisAddItemRefArr[1].Value = objCheckItemRefVO.m_strSeq_Int;
                            objLisAddItemRefArr[2].Value = drr[0]["deptid_chr"].ToString();
                            objLisAddItemRefArr[3].Value = deptName;
                            lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, objLisAddItemRefArr);
                        }
                    }
                }
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

        //        #region 根据申请单元ID查询所有的检验项目
        //        [AutoComplete]
        //        public long m_lngGetCheckItemByApplUnitID(System.Security.Principal.IPrincipal p_objPrincipal,string strApplUnitID,
        //            out DataTable dtbCheckItem)
        //        {
        //            long lngRes = 0;

        //            dtbCheckItem = null;

        //            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc","m_lngGetCheckItemByApplUnitID");
        //            if(lngRes < 0)
        //            {
        //                return -1;
        //            }

        //            string strSQL = @"SELECT t1.rptno_chr, t1.pycode_chr, t1.unit_chr, t1.check_item_name_vchr,
        //                                   t1.is_sex_related_chr, t1.check_item_english_name_vchr,
        //                                   t1.is_age_related_chr, t1.is_sample_related_chr, t1.formula_vchr,
        //                                   t1.test_methods_vchr, t1.clinic_meaning_vchr, t1.check_item_id_chr,
        //                                   t1.shortname_chr, t1.is_qc_required_chr, t1.resulttype_chr,
        //                                   t1.ref_value_range_vchr, t1.wbcode_chr, t1.assist_code01_chr,
        //                                   t1.assist_code02_chr, t1.is_no_food_required_chr,
        //                                   t1.is_physical_exam_required_chr, t1.is_reservation_required_chr,
        //                                   t1.sample_valid_time_dec, t1.sample_valid_time_unit_chr, t1.modify_dat,
        //                                   t1.operatorid_chr, t1.check_category_id_chr, t1.ref_max_val_vchr,
        //                                   t1.ref_min_val_vchr, t1.sampletype_vchr, t1.is_menses_related_chr,
        //                                   t1.is_calculated_chr, t1.formula_user_vchr, t1.alarm_low_val_vchr,
        //                                   t1.alarm_up_val_vchr, t1.alert_value_range_vchr,
        //                                     t2.apply_unit_id_chr,t2.PRINT_SEQ_INT
        //								FROM t_bse_lis_check_item t1, t_aid_lis_apply_unit_detail t2
        //							   WHERE t2.check_item_id_chr = t1.check_item_id_chr
        //								 AND t2.apply_unit_id_chr = '" +strApplUnitID+@"'
        //							ORDER BY t2.PRINT_SEQ_INT";
        //            try
        //            {
        //                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbCheckItem);
        //                objHRPSvc.Dispose();
        //            }
        //            catch(Exception objEx)
        //            {
        //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //                bool blnRes = objLogger.LogError(objEx);
        //            }
        //            return lngRes;
        //        }
        //        #endregion

        //#region 根据申请单元ID查询所有的检验项目 VO 
        //[AutoComplete]
        //public long m_lngGetCheckItemByApplUnitID(System.Security.Principal.IPrincipal p_objPrincipal,string p_strApplUnitID,
        //    out clsCheckItem_VO[] p_objCheckItemVOArr)
        //{
        //    long lngRes = 0;

        //    p_objCheckItemVOArr = null;

        //    DataTable dtbCheckItem = null;

        //    lngRes = this.m_lngGetCheckItemByApplUnitID(p_objPrincipal,p_strApplUnitID,out dtbCheckItem);
        //    if(lngRes > 0 && dtbCheckItem != null)
        //    {
        //        p_objCheckItemVOArr = new clsCheckItem_VO[dtbCheckItem.Rows.Count];

        //        for(int i=0;i<dtbCheckItem.Rows.Count;i++)
        //        {
        //            p_objCheckItemVOArr[i] = new clsCheckItem_VO();
        //            this.ConstructCheckItemVO(dtbCheckItem.Rows[i],ref p_objCheckItemVOArr[i]);
        //        }
        //    }
        //    return lngRes;
        //}
        //#endregion

        //        #region 根据标本组ID查询所有的检验项目 
        //        [AutoComplete]
        //        public long m_lngGetCheckItemBySampleGroupID(System.Security.Principal.IPrincipal p_objPrincipal,string strSampleGroupID,
        //            out clsCheckItem_VO[] objCheckItemVOList)
        //        {
        //            long lngRes = 0;

        //            objCheckItemVOList = null;

        //            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc","m_lngGetCheckItemBySampleGroupID");
        //            if(lngRes < 0)
        //            {
        //                return -1;
        //            }

        //            string strSQL = @"SELECT t1.rptno_chr, t1.pycode_chr, t1.unit_chr, t1.check_item_name_vchr,
        //                                   t1.is_sex_related_chr, t1.check_item_english_name_vchr,
        //                                   t1.is_age_related_chr, t1.is_sample_related_chr, t1.formula_vchr,
        //                                   t1.test_methods_vchr, t1.clinic_meaning_vchr, t1.check_item_id_chr,
        //                                   t1.shortname_chr, t1.is_qc_required_chr, t1.resulttype_chr,
        //                                   t1.ref_value_range_vchr, t1.wbcode_chr, t1.assist_code01_chr,
        //                                   t1.assist_code02_chr, t1.is_no_food_required_chr,
        //                                   t1.is_physical_exam_required_chr, t1.is_reservation_required_chr,
        //                                   t1.sample_valid_time_dec, t1.sample_valid_time_unit_chr, t1.modify_dat,
        //                                   t1.operatorid_chr, t1.check_category_id_chr, t1.ref_max_val_vchr,
        //                                   t1.ref_min_val_vchr, t1.sampletype_vchr, t1.is_menses_related_chr,
        //                                   t1.is_calculated_chr, t1.formula_user_vchr, t1.alarm_low_val_vchr,
        //                                   t1.alarm_up_val_vchr, t1.alert_value_range_vchr
        //							    FROM t_bse_lis_check_item t1, t_aid_lis_sample_group_detail t2
        //							   WHERE t1.check_item_id_chr = t2.check_item_id_chr
        //								 AND t2.sample_group_id_chr = '" +strSampleGroupID+"'";
        //            DataTable dtbCheckItem = null;
        //            try
        //            {
        //                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbCheckItem);
        //                objHRPSvc.Dispose();
        //                if(lngRes>0 && dtbCheckItem != null)
        //                {
        //                    if(dtbCheckItem.Rows.Count > 0)
        //                    {
        //                        objCheckItemVOList = new clsCheckItem_VO[dtbCheckItem.Rows.Count];
        //                        for(int i=0;i<dtbCheckItem.Rows.Count;i++)
        //                        {
        //                            objCheckItemVOList[i] = new clsCheckItem_VO();
        //                            ConstructCheckItemVO(dtbCheckItem.Rows[i],ref objCheckItemVOList[i]);
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

        //        #region 根据标本组ID查询所有的检验项目
        //        [AutoComplete]
        //        public long m_lngGetCheckItemBySampleGroupID(System.Security.Principal.IPrincipal p_objPrincipal,string strSampleGroupID,
        //            out DataTable dtbCheckItem)
        //        {
        //            long lngRes = 0;

        //            dtbCheckItem = null;

        //            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc","m_lngGetCheckItemBySampleGroupID");
        //            if(lngRes < 0)
        //            {
        //                return -1;
        //            }

        //            string strSQL = @"SELECT t1.rptno_chr, t1.pycode_chr, t1.unit_chr, t1.check_item_name_vchr,
        //                                   t1.is_sex_related_chr, t1.check_item_english_name_vchr,
        //                                   t1.is_age_related_chr, t1.is_sample_related_chr, t1.formula_vchr,
        //                                   t1.test_methods_vchr, t1.clinic_meaning_vchr, t1.check_item_id_chr,
        //                                   t1.shortname_chr, t1.is_qc_required_chr, t1.resulttype_chr,
        //                                   t1.ref_value_range_vchr, t1.wbcode_chr, t1.assist_code01_chr,
        //                                   t1.assist_code02_chr, t1.is_no_food_required_chr,
        //                                   t1.is_physical_exam_required_chr, t1.is_reservation_required_chr,
        //                                   t1.sample_valid_time_dec, t1.sample_valid_time_unit_chr, t1.modify_dat,
        //                                   t1.operatorid_chr, t1.check_category_id_chr, t1.ref_max_val_vchr,
        //                                   t1.ref_min_val_vchr, t1.sampletype_vchr, t1.is_menses_related_chr,
        //                                   t1.is_calculated_chr, t1.formula_user_vchr, t1.alarm_low_val_vchr,
        //                                   t1.alarm_up_val_vchr, t1.alert_value_range_vchr,
        //                                     t2.print_seq_int
        //							    FROM t_bse_lis_check_item t1, t_aid_lis_sample_group_detail t2
        //							   WHERE t1.check_item_id_chr = t2.check_item_id_chr
        //								 AND t2.sample_group_id_chr = '" +strSampleGroupID+@"'
        //							ORDER BY t2.print_seq_int";
        //            try
        //            {
        //                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbCheckItem);
        //                objHRPSvc.Dispose();
        //            }
        //            catch(Exception objEx)
        //            {
        //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //                bool blnRes = objLogger.LogError(objEx);
        //            }
        //            return lngRes;
        //        }
        //        #endregion

        //#region 构造CheckItemVO
        //[AutoComplete]
        //public void ConstructCheckItemVO(System.Data.DataRow objRow,ref clsCheckItem_VO objCheckItemVO)
        //{
        //    objCheckItemVO.m_strCheck_Item_ID = objRow["CHECK_ITEM_ID_CHR"].ToString().Trim();
        //    objCheckItemVO.m_strCheck_Item_Name = objRow["CHECK_ITEM_NAME_VCHR"].ToString().Trim();
        //    objCheckItemVO.m_strRPTNO = objRow["RPTNO_CHR"].ToString().Trim();
        //    objCheckItemVO.m_strPycode = objRow["PYCODE_CHR"].ToString().Trim();
        //    objCheckItemVO.m_strUnit = objRow["UNIT_CHR"].ToString().Trim();
        //    objCheckItemVO.m_strIs_Sex_Related = objRow["IS_SEX_RELATED_CHR"].ToString().Trim();
        //    objCheckItemVO.m_strCheck_Item_English_Name = objRow["CHECK_ITEM_ENGLISH_NAME_VCHR"].ToString().Trim();
        //    objCheckItemVO.m_strIs_Age_Related = objRow["IS_AGE_RELATED_CHR"].ToString().Trim();
        //    objCheckItemVO.m_strIs_Sample_Related = objRow["IS_SAMPLE_RELATED_CHR"].ToString().Trim();
        //    objCheckItemVO.m_strFormula = objRow["FORMULA_VCHR"].ToString().Trim();
        //    objCheckItemVO.m_strTest_Method = objRow["TEST_METHODS_VCHR"].ToString().Trim();
        //    objCheckItemVO.m_strClinic_meaning = objRow["CLINIC_MEANING_VCHR"].ToString().Trim();
        //    objCheckItemVO.m_strShortName = objRow["SHORTNAME_CHR"].ToString().Trim();
        //    objCheckItemVO.m_strIs_Qc_Required = objRow["IS_QC_REQUIRED_CHR"].ToString().Trim();
        //    objCheckItemVO.m_strResultType = objRow["RESULTTYPE_CHR"].ToString().Trim();
        //    objCheckItemVO.m_strRef_Value_Range = objRow["REF_VALUE_RANGE_VCHR"].ToString().Trim();
        //    objCheckItemVO.m_strWbcode = objRow["WBCODE_CHR"].ToString().Trim();
        //    objCheckItemVO.m_strAssist_Code01 = objRow["ASSIST_CODE01_CHR"].ToString().Trim();
        //    objCheckItemVO.m_strAssist_Code02 = objRow["ASSIST_CODE02_CHR"].ToString().Trim();
        //    objCheckItemVO.m_strIs_No_Food_Required = objRow["IS_NO_FOOD_REQUIRED_CHR"].ToString().Trim();
        //    objCheckItemVO.m_strIs_Physical_Exam_Required = objRow["IS_PHYSICAL_EXAM_REQUIRED_CHR"].ToString().Trim();
        //    objCheckItemVO.m_strIs_Reservation_Required = objRow["IS_RESERVATION_REQUIRED_CHR"].ToString().Trim();
        //    objCheckItemVO.m_strSample_Valid_Time = objRow["SAMPLE_VALID_TIME_DEC"].ToString().Trim();
        //    objCheckItemVO.m_strSample_Valid_Time_Unit = objRow["SAMPLE_VALID_TIME_UNIT_CHR"].ToString().Trim();
        //    objCheckItemVO.m_strModify_Dat = objRow["MODIFY_DAT"].ToString().Trim();
        //    objCheckItemVO.m_strOperator_ID = objRow["OPERATORID_CHR"].ToString().Trim();
        //    objCheckItemVO.m_strCheck_Category_ID = objRow["CHECK_CATEGORY_ID_CHR"].ToString().Trim();
        //    objCheckItemVO.m_strRef_Value_Max = objRow["REF_MAX_VAL_VCHR"].ToString().Trim();
        //    objCheckItemVO.m_strRef_Value_Min = objRow["REF_MIN_VAL_VCHR"].ToString().Trim();
        //    objCheckItemVO.m_strSampleTypeID = objRow["SAMPLETYPE_VCHR"].ToString().Trim();
        //    objCheckItemVO.m_strFormula_User_VCHR = objRow["FORMULA_USER_VCHR"].ToString().Trim();
        //}
        //#endregion

        //        #region 根据检验类别和样品类别查询所有的检验项目
        //        [AutoComplete]
        //        public long m_lngQryCheckItemByCheckCategoryAndSampleType(System.Security.Principal.IPrincipal p_objPrincipal,string strCheckCategory,string strSampleType,out DataTable dtbCheckItem)
        //        {
        //            long lngRes = 0;
        //            string strSQL = @"SELECT t1.rptno_chr, t1.pycode_chr, t1.unit_chr, t1.check_item_name_vchr,
        //                                   t1.is_sex_related_chr, t1.check_item_english_name_vchr,
        //                                   t1.is_age_related_chr, t1.is_sample_related_chr, t1.formula_vchr,
        //                                   t1.test_methods_vchr, t1.clinic_meaning_vchr, t1.check_item_id_chr,
        //                                   t1.shortname_chr, t1.is_qc_required_chr, t1.resulttype_chr,
        //                                   t1.ref_value_range_vchr, t1.wbcode_chr, t1.assist_code01_chr,
        //                                   t1.assist_code02_chr, t1.is_no_food_required_chr,
        //                                   t1.is_physical_exam_required_chr, t1.is_reservation_required_chr,
        //                                   t1.sample_valid_time_dec, t1.sample_valid_time_unit_chr, t1.modify_dat,
        //                                   t1.operatorid_chr, t1.check_category_id_chr, t1.ref_max_val_vchr,
        //                                   t1.ref_min_val_vchr, t1.sampletype_vchr, t1.is_menses_related_chr,
        //                                   t1.is_calculated_chr, t1.formula_user_vchr, t1.alarm_low_val_vchr,
        //                                   t1.alarm_up_val_vchr, t1.alert_value_range_vchr, 
        //                                     t2.check_category_desc_vchr
        //								FROM t_bse_lis_check_item t1,
        //									 t_bse_lis_check_category t2,
        //									 t_aid_lis_sampletype t3
        //							   WHERE t1.check_category_id_chr = t2.check_category_id_chr(+)
        //								 AND t1.sampletype_vchr = t3.sample_type_id_chr
        //								 AND t1.sampletype_vchr = '" +strSampleType+@"'
        //								 AND t1.check_category_id_chr = '"+strCheckCategory+@"'
        //							ORDER BY t1.check_item_id_chr";
        //            dtbCheckItem = null;
        //            try
        //            {
        //                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbCheckItem);
        //                objHRPSvc.Dispose();
        //            }
        //            catch(Exception objEx)
        //            {
        //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //                bool blnRes = objLogger.LogError(objEx);
        //            }
        //            return lngRes;
        //        }
        //        #endregion

        //#region 查询所有的打印类别信息
        //[AutoComplete]
        //public long m_lngGetAllPrintCategory(System.Security.Principal.IPrincipal p_objPrincipal,out DataTable dtbPrintCategory)
        //{
        //    long lngRes = 0;
        //    string strSQL = @"SELECT print_category_id_chr, print_category_desc_vchr FROM t_bse_lis_print_category";
        //    dtbPrintCategory = null;
        //    try
        //    {
        //        com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //        lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbPrintCategory);
        //        objHRPSvc.Dispose();
        //    }
        //    catch(Exception objEx)
        //    {
        //        com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //        bool blnRes = objLogger.LogError(objEx);
        //        throw objEx;
        //    }
        //    return lngRes;
        //}
        //#endregion

        //#region 查询出所有的检验类别 
        //[AutoComplete]
        //public long m_lngGetAllCheckCategory(System.Security.Principal.IPrincipal p_objPrincipal,out System.Data.DataTable dtbCheckCategory)
        //{
        //    long lngRes = 0;
        //    string strSQL = @"SELECT CHECK_CATEGORY_ID_CHR,CHECK_CATEGORY_DESC_VCHR FROM T_BSE_LIS_CHECK_CATEGORY";
        //    dtbCheckCategory = null;
        //    try
        //    {
        //        com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //        lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbCheckCategory);
        //        objHRPSvc.Dispose();
        //    }
        //    catch(Exception objEx)
        //    {
        //        com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //        bool blnRes = objLogger.LogError(objEx);
        //        throw objEx;
        //    }
        //    return lngRes;
        //}
        //#endregion

        //#region 查询出所有的检验类别 
        ///// <summary>
        ///// 查询出所有的检验类别
        ///// </summary>
        ///// <param name="p_objPrincipal"></param>
        ///// <param name="p_strID"></param>
        ///// <param name="p_objResultArr"></param>
        ///// <returns></returns>
        //[AutoComplete]
        //public long m_lngGetCheckCategory(System.Security.Principal.IPrincipal p_objPrincipal,out clsCheckCategory_VO[] p_objResultArr)
        //{
        //    p_objResultArr = new clsCheckCategory_VO[0];
        //    long lngRes=0;
        //    string strSQL = @"SELECT CHECK_CATEGORY_ID_CHR,CHECK_CATEGORY_DESC_VCHR FROM T_BSE_LIS_CHECK_CATEGORY";
        //    try
        //    {
        //        DataTable dtbResult = new DataTable();
        //        com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //        lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbResult);				
        //        objHRPSvc.Dispose();
        //        if(lngRes > 0 && dtbResult.Rows.Count > 0)
        //        {
        //            p_objResultArr = new clsCheckCategory_VO[dtbResult.Rows.Count];
        //            for(int i1=0;i1<p_objResultArr.Length;i1++)
        //            {
        //                p_objResultArr[i1] = new clsCheckCategory_VO();
        //                p_objResultArr[i1].m_strCheck_Category_ID = dtbResult.Rows[i1]["CHECK_CATEGORY_ID_CHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strCheck_Category_Name = dtbResult.Rows[i1]["CHECK_CATEGORY_DESC_VCHR"].ToString().Trim();

        //            }
        //        }
        //    }
        //    catch(Exception objEx)
        //    {
        //        string strTmp=objEx.Message;
        //        com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //        bool blnRes = objLogger.LogError(objEx);
        //    }
        //    return lngRes;
        //}
        //#endregion

        #region 更新检验类别信息
        [AutoComplete]
        public long m_lngSetCheckCategoryInfo(System.Security.Principal.IPrincipal p_objPrincipal, string strCheckCategory, string strCheckCategoryID)
        {
            long lngRes = 0;
            string strSQL = @"UPDATE T_BSE_LIS_CHECK_CATEGORY SET CHECK_CATEGORY_DESC_VCHR = '" + strCheckCategory + "' WHERE CHECK_CATEGORY_ID_CHR = '" + strCheckCategoryID + "'";
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
                throw objEx;
            }
            return lngRes;
        }
        #endregion

        //        #region 查询出所有属于某一检验类别的检验项目 
        //        [AutoComplete]
        //        public long m_lngGetAllCheckItemByCheckCategory(System.Security.Principal.IPrincipal p_objPrincipal,string strCheckCategoryID,out System.Data.DataTable dtbAllCheckItem)
        //        {
        //            long lngRes = 0;
        //            string strSQL = @"SELECT rptno_chr, pycode_chr, unit_chr, check_item_name_vchr,
        //									is_sex_related_chr, check_item_english_name_vchr, is_age_related_chr,
        //									is_sample_related_chr, formula_vchr, test_methods_vchr,
        //									clinic_meaning_vchr, check_item_id_chr, shortname_chr,
        //									is_qc_required_chr, resulttype_chr, ref_value_range_vchr, wbcode_chr,
        //									assist_code01_chr, assist_code02_chr, is_no_food_required_chr,
        //									is_physical_exam_required_chr, is_reservation_required_chr,
        //									sample_valid_time_dec, sample_valid_time_unit_chr,
        //									check_category_id_chr,FORMULA_USER_VCHR
        //								FROM t_bse_lis_check_item
        //								WHERE check_category_id_chr = '"+strCheckCategoryID+@"'
        //								ORDER BY check_item_id_chr";
        //            dtbAllCheckItem = null;
        //            try
        //            {
        //                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbAllCheckItem);
        //                objHRPSvc.Dispose();
        //            }
        //            catch(Exception objEx)
        //            {
        //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //                bool blnRes = objLogger.LogError(objEx);
        //                throw objEx;
        //            }
        //            return lngRes;
        //        }
        //        #endregion

        //        #region 根据一组 Check_Item_ID 查询出每个Check_Item_ID 的详细资料 
        //        [AutoComplete]
        //        /// <summary>
        //        /// 根据一组 Check_Item_ID 查询出每个Check_Item_ID 的详细资料
        //        /// </summary>
        //        /// <param name="p_objPrincipal"></param>
        //        /// <param name="p_strCheckItemIDArr">
        //        /// 如为空则返回-1且dtbCheckItemsInfo为空
        //        /// 如长度为0则查出所有的CheckItem的资料</param>
        //        /// <param name="dtbCheckItemsInfo"></param>
        //        /// <returns></returns>

        //        public long m_lngGetCheckItemInfoByCheckItemID(System.Security.Principal.IPrincipal p_objPrincipal,string[] p_strCheckItemIDArr,out System.Data.DataTable dtbCheckItemsInfo)
        //        {
        //            long lngRes = 0;
        //            dtbCheckItemsInfo = null;
        //            string strCondition = null;

        //            #region 根据参数 p_strCheckItemIDArr 定查询条件，或返回
        //            if(p_strCheckItemIDArr == null)
        //            {//参数不正确
        //                return -1;
        //            }
        //            else if(p_strCheckItemIDArr.Length == 0)
        //            {//查询所有CheckItem
        //                strCondition = "";
        //            }
        //            else
        //            {//根据 p_strCheckItemIDArr 构造查询条件
        //                System.Text.StringBuilder sb = new  System.Text.StringBuilder();
        //                for(int i=0; i<p_strCheckItemIDArr.Length; i++)
        //                {
        //                    sb.Append("'");
        //                    sb.Append(p_strCheckItemIDArr[i]);
        //                    sb.Append("',");
        //                }
        //                sb.Remove(sb.Length -1,1);
        //                string strCheckItemIDSet = sb.ToString();
        //                strCondition = " WHERE CHECK_ITEM_ID_CHR IN("+strCheckItemIDSet+")";
        //            }
        //            #endregion

        //            string strSQL = @"SELECT *
        //								FROM t_bse_lis_check_item " + strCondition;
        //            try
        //            {
        //                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbCheckItemsInfo);
        //                objHRPSvc.Dispose();
        //            }
        //            catch(Exception objEx)
        //            {
        //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //                bool blnRes = objLogger.LogError(objEx);
        //                throw objEx;
        //            }
        //            return lngRes;
        //        }
        //        #endregion

        //        #region 查询某一检验组(无子组)包含的检验项目 
        //        [AutoComplete]
        //        public long m_lngGetCheckItemByNoSubCheckGroupID(System.Security.Principal.IPrincipal p_objPrincipal,string strCheckGroupID,out DataTable dtbCheckGroupItem)
        //        {
        //            long lngRes = 0;
        //            string strSQL = @"SELECT t1.groupid_chr, t2.check_item_id_chr,t2.check_item_name_vchr,t2.check_item_english_name_vchr
        //								FROM t_aid_lis_check_group_detail t1, t_bse_lis_check_item t2
        //							  WHERE t1.check_item_id_chr = t2.check_item_id_chr AND groupid_chr= '"+strCheckGroupID+"'";
        //            dtbCheckGroupItem = null;
        //            try
        //            {
        //                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbCheckGroupItem);
        //                objHRPSvc.Dispose();
        //            }
        //            catch(Exception objEx)
        //            {
        //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //                bool blnRes = objLogger.LogError(objEx);
        //                throw objEx;
        //            }
        //            return lngRes;
        //        }
        //        #endregion

        //        #region 查询某一检验组(无子组)包含的检验项目 
        //        [AutoComplete]
        //        public long m_lngGetCheckItemByNoSubCheckGroupID(System.Security.Principal.IPrincipal p_objPrincipal,string strCheckGroupID,out com.digitalwave.iCare.ValueObject.clsCheckItem_VO[] p_objResultArr)
        //        {
        //            long lngRes = 0;
        //            string strSQL = @"SELECT t1.groupid_chr, t2.* 
        //								FROM t_aid_lis_check_group_detail t1, t_bse_lis_check_item t2
        //							  WHERE t1.check_item_id_chr = t2.check_item_id_chr AND groupid_chr= '"+strCheckGroupID+"'";
        //            DataTable dtbResult = null;
        //            p_objResultArr=null;
        //            try
        //            {
        //                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbResult);
        //                objHRPSvc.Dispose();

        //                if(lngRes > 0 && dtbResult.Rows.Count > 0)
        //                {
        //                    p_objResultArr = new clsCheckItem_VO[dtbResult.Rows.Count];
        //                    for(int i1=0;i1<dtbResult.Rows.Count;i1++)
        //                    {
        //                        p_objResultArr[i1] = new clsCheckItem_VO();
        //                        p_objResultArr[i1].m_strCheck_Item_ID = dtbResult.Rows[i1]["CHECK_ITEM_ID_CHR"].ToString().Trim();
        //                        p_objResultArr[i1].m_strRPTNO = dtbResult.Rows[i1]["RPTNO_CHR"].ToString().Trim();
        //                        p_objResultArr[i1].m_strPycode = dtbResult.Rows[i1]["PYCODE_CHR"].ToString().Trim();
        //                        p_objResultArr[i1].m_strUnit = dtbResult.Rows[i1]["UNIT_CHR"].ToString().Trim();
        //                        p_objResultArr[i1].m_strCheck_Item_Name = dtbResult.Rows[i1]["CHECK_ITEM_NAME_VCHR"].ToString().Trim();
        //                        p_objResultArr[i1].m_strIs_Sex_Related = dtbResult.Rows[i1]["IS_SEX_RELATED_CHR"].ToString().Trim();
        //                        p_objResultArr[i1].m_strCheck_Item_English_Name = dtbResult.Rows[i1]["CHECK_ITEM_ENGLISH_NAME_VCHR"].ToString().Trim();
        //                        p_objResultArr[i1].m_strIs_Age_Related = dtbResult.Rows[i1]["IS_AGE_RELATED_CHR"].ToString().Trim();
        //                        p_objResultArr[i1].m_strIs_Sample_Related = dtbResult.Rows[i1]["IS_SAMPLE_RELATED_CHR"].ToString().Trim();
        //                        p_objResultArr[i1].m_strFormula = dtbResult.Rows[i1]["FORMULA_VCHR"].ToString().Trim();
        //                        p_objResultArr[i1].m_strTest_Method = dtbResult.Rows[i1]["TEST_METHODS_VCHR"].ToString().Trim();
        //                        p_objResultArr[i1].m_strClinic_meaning = dtbResult.Rows[i1]["CLINIC_MEANING_VCHR"].ToString().Trim();
        //                        p_objResultArr[i1].m_strShortName = dtbResult.Rows[i1]["SHORTNAME_CHR"].ToString().Trim();
        //                        p_objResultArr[i1].m_strIs_Qc_Required = dtbResult.Rows[i1]["IS_QC_REQUIRED_CHR"].ToString().Trim();
        //                        p_objResultArr[i1].m_strResultType = dtbResult.Rows[i1]["RESULTTYPE_CHR"].ToString().Trim();
        //                        p_objResultArr[i1].m_strRef_Value_Range = dtbResult.Rows[i1]["REF_VALUE_RANGE_VCHR"].ToString().Trim();
        //                        p_objResultArr[i1].m_strWbcode = dtbResult.Rows[i1]["WBCODE_CHR"].ToString().Trim();
        //                        p_objResultArr[i1].m_strAssist_Code01 = dtbResult.Rows[i1]["ASSIST_CODE01_CHR"].ToString().Trim();
        //                        p_objResultArr[i1].m_strAssist_Code02 = dtbResult.Rows[i1]["ASSIST_CODE02_CHR"].ToString().Trim();
        //                        p_objResultArr[i1].m_strIs_No_Food_Required = dtbResult.Rows[i1]["IS_NO_FOOD_REQUIRED_CHR"].ToString().Trim();
        //                        p_objResultArr[i1].m_strIs_Physical_Exam_Required = dtbResult.Rows[i1]["IS_PHYSICAL_EXAM_REQUIRED_CHR"].ToString().Trim();
        //                        p_objResultArr[i1].m_strIs_Reservation_Required = dtbResult.Rows[i1]["IS_RESERVATION_REQUIRED_CHR"].ToString().Trim();
        //                        p_objResultArr[i1].m_strSample_Valid_Time = dtbResult.Rows[i1]["SAMPLE_VALID_TIME_DEC"].ToString().Trim();
        //                        p_objResultArr[i1].m_strSample_Valid_Time_Unit = dtbResult.Rows[i1]["SAMPLE_VALID_TIME_UNIT_CHR"].ToString().Trim();
        //                        p_objResultArr[i1].m_strModify_Dat = dtbResult.Rows[i1]["MODIFY_DAT"].ToString().Trim();
        //                        p_objResultArr[i1].m_strOperator_ID = dtbResult.Rows[i1]["OPERATORID_CHR"].ToString().Trim();
        //                        p_objResultArr[i1].m_strCheck_Category_ID = dtbResult.Rows[i1]["CHECK_CATEGORY_ID_CHR"].ToString().Trim();
        //                    }
        //                }
        //            }
        //            catch(Exception objEx)
        //            {
        //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //                bool blnRes = objLogger.LogError(objEx);
        //                throw objEx;
        //            }
        //            return lngRes;
        //        }
        //        #endregion

        //        #region 查询某一检验组(含子组)包含的检验项目 
        //        [AutoComplete]
        //        public long m_lngGetCheckItemByhasSubCheckGroupID(System.Security.Principal.IPrincipal p_objPrincipal,string strCheckGroupID,out DataTable dtbCheckGroupItem)
        //        {
        //            long lngRes = 0;
        //            string strSQL = @"SELECT t3.check_item_name_vchr, t3.check_item_id_chr,
        //									 t3.check_item_english_name_vchr
        //								FROM t_aid_lis_check_group t1,
        //									 t_aid_lis_check_group_detail t2,
        //									 t_bse_lis_check_item t3
        //							WHERE t1.groupid_chr IN (SELECT  child_groupid_chr
        //														FROM t_aid_lis_check_group_relation
        //														START WITH groupid_chr = '"+strCheckGroupID+
        //                                                            @"'CONNECT BY PRIOR child_groupid_chr = groupid_chr)
        //							AND t1.has_subgroup_chr = '0'
        //							AND t1.groupid_chr = t2.groupid_chr
        //							AND t2.check_item_id_chr = t3.check_item_id_chr";
        //            dtbCheckGroupItem = null;
        //            try
        //            {
        //                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbCheckGroupItem);
        //                objHRPSvc.Dispose();
        //            }
        //            catch(Exception objEx)
        //            {
        //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //                bool blnRes = objLogger.LogError(objEx);
        //                throw objEx;
        //            }
        //            return lngRes;
        //        }
        //        #endregion

        #region [U]新增检验项目类别
        [AutoComplete]
        public long m_lngAddCheckCategory(System.Security.Principal.IPrincipal p_objPrincipal, ref com.digitalwave.iCare.ValueObject.clsCheckCategory_VO p_objCheckCategoryVO)
        {
            long lngRes = 0;
            string strSQL = "INSERT INTO t_bse_lis_check_category(CHECK_CATEGORY_ID_CHR,CHECK_CATEGORY_DESC_VCHR) VALUES(?,?)";
            try
            {
                System.Data.IDataParameter[] objLisCheckCategoryArr = null;

                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(2, out objLisCheckCategoryArr);

                string strNewCheckCategoryID = objHRPSvc.m_strGetNewID("T_BSE_LIS_CHECK_CATEGORY", "CHECK_CATEGORY_ID_CHR", 2);
                p_objCheckCategoryVO.m_strCheck_Category_ID = strNewCheckCategoryID;

                objLisCheckCategoryArr[0].Value = p_objCheckCategoryVO.m_strCheck_Category_ID;
                objLisCheckCategoryArr[1].Value = p_objCheckCategoryVO.m_strCheck_Category_Name;

                long lngRecEff = -1;

                //往表t_bse_lis_check_category增加记录
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, objLisCheckCategoryArr);
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

        #region 删除选中的检验类别
        [AutoComplete]
        public long m_lngDelCheckCategory(System.Security.Principal.IPrincipal p_objPrincipal, string strCategory)
        {
            long lngRes = 0;
            string strSQL = @"DELETE FROM T_BSE_LIS_CHECK_CATEGORY WHERE CHECK_CATEGORY_ID_CHR = '" + strCategory + "'";
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
                throw objEx;
            }
            return lngRes;
        }
        #endregion

        //        #region 查询出所有的检验项目
        //        [AutoComplete]
        //        public long m_lngGetAllCheckItem(System.Security.Principal.IPrincipal p_objPrincipal,out System.Data.DataTable dtbAllCheckItem)
        //        {
        //            long lngRes = 0;
        //            string strSQL = @"SELECT t1.rptno_chr, t1.pycode_chr, t1.unit_chr, t1.check_item_name_vchr,
        //                                   t1.is_sex_related_chr, t1.check_item_english_name_vchr,
        //                                   t1.is_age_related_chr, t1.is_sample_related_chr, t1.formula_vchr,
        //                                   t1.test_methods_vchr, t1.clinic_meaning_vchr, t1.check_item_id_chr,
        //                                   t1.shortname_chr, t1.is_qc_required_chr, t1.resulttype_chr,
        //                                   t1.ref_value_range_vchr, t1.wbcode_chr, t1.assist_code01_chr,
        //                                   t1.assist_code02_chr, t1.is_no_food_required_chr,
        //                                   t1.is_physical_exam_required_chr, t1.is_reservation_required_chr,
        //                                   t1.sample_valid_time_dec, t1.sample_valid_time_unit_chr, t1.modify_dat,
        //                                   t1.operatorid_chr, t1.check_category_id_chr, t1.ref_max_val_vchr,
        //                                   t1.ref_min_val_vchr, t1.sampletype_vchr, t1.is_menses_related_chr,
        //                                   t1.is_calculated_chr, t1.formula_user_vchr, t1.alarm_low_val_vchr,
        //                                   t1.alarm_up_val_vchr, t1.alert_value_range_vchr,
        //                                     t2.CHECK_CATEGORY_DESC_VCHR 
        //                                FROM t_bse_lis_check_item t1 LEFT OUTER JOIN t_bse_lis_check_category t2 ON t1.check_category_id_chr = t2.check_category_id_chr order by t1.check_item_id_chr";
        //            dtbAllCheckItem = null;
        //            try
        //            {
        //                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbAllCheckItem);
        //                objHRPSvc.Dispose();
        //            }
        //            catch(Exception objEx)
        //            {
        //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //                bool blnRes = objLogger.LogError(objEx);
        //                throw objEx;
        //            }
        //            return lngRes;
        //        }
        //        #endregion

        //#region 查询出该类别的检验项目 
        ///// <summary>
        ///// 查询出该类别的检验项目
        ///// </summary>
        //[AutoComplete]
        //public long m_lngGetCheckItemByCategoryID(System.Security.Principal.IPrincipal p_objPrincipal,
        //    string p_strCategoryID,
        //    out clsCheckItem_VO [] p_objResultArr)
        //{
        //    p_objResultArr = new clsCheckItem_VO[0];
        //    long lngRes=0;
        //    string strSQL = @"SELECT *  FROM t_bse_lis_check_item";
        //    string strCondition = "";
        //    if(p_strCategoryID.ToString().Trim() != "")
        //    {
        //        strCondition = " WHERE "+" check_category_id_chr = '"+p_strCategoryID+"'";
        //    }
        //    strSQL += strCondition;
        //    try
        //    {
        //        DataTable dtbResult = new DataTable();
        //        com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //        lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);				
        //        objHRPSvc.Dispose();
        //        if(lngRes > 0 && dtbResult.Rows.Count > 0)
        //        {
        //            p_objResultArr = new clsCheckItem_VO[dtbResult.Rows.Count];
        //            for(int i1=0;i1<p_objResultArr.Length;i1++)
        //            {
        //                p_objResultArr[i1] = new clsCheckItem_VO();
        //                p_objResultArr[i1].m_strCheck_Item_ID = dtbResult.Rows[i1]["CHECK_ITEM_ID_CHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strRPTNO = dtbResult.Rows[i1]["RPTNO_CHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strPycode = dtbResult.Rows[i1]["PYCODE_CHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strUnit = dtbResult.Rows[i1]["UNIT_CHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strCheck_Item_Name = dtbResult.Rows[i1]["CHECK_ITEM_NAME_VCHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strIs_Sex_Related = dtbResult.Rows[i1]["IS_SEX_RELATED_CHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strCheck_Item_English_Name = dtbResult.Rows[i1]["CHECK_ITEM_ENGLISH_NAME_VCHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strIs_Age_Related = dtbResult.Rows[i1]["IS_AGE_RELATED_CHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strIs_Sample_Related = dtbResult.Rows[i1]["IS_SAMPLE_RELATED_CHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strFormula = dtbResult.Rows[i1]["FORMULA_VCHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strTest_Method = dtbResult.Rows[i1]["TEST_METHODS_VCHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strClinic_meaning = dtbResult.Rows[i1]["CLINIC_MEANING_VCHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strShortName = dtbResult.Rows[i1]["SHORTNAME_CHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strIs_Qc_Required = dtbResult.Rows[i1]["IS_QC_REQUIRED_CHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strResultType = dtbResult.Rows[i1]["RESULTTYPE_CHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strRef_Value_Range = dtbResult.Rows[i1]["REF_VALUE_RANGE_VCHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strWbcode = dtbResult.Rows[i1]["WBCODE_CHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strAssist_Code01 = dtbResult.Rows[i1]["ASSIST_CODE01_CHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strAssist_Code02 = dtbResult.Rows[i1]["ASSIST_CODE02_CHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strIs_No_Food_Required = dtbResult.Rows[i1]["IS_NO_FOOD_REQUIRED_CHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strIs_Physical_Exam_Required = dtbResult.Rows[i1]["IS_PHYSICAL_EXAM_REQUIRED_CHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strIs_Reservation_Required = dtbResult.Rows[i1]["IS_RESERVATION_REQUIRED_CHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strSample_Valid_Time = dtbResult.Rows[i1]["SAMPLE_VALID_TIME_DEC"].ToString().Trim();
        //                p_objResultArr[i1].m_strSample_Valid_Time_Unit = dtbResult.Rows[i1]["SAMPLE_VALID_TIME_UNIT_CHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strModify_Dat = dtbResult.Rows[i1]["MODIFY_DAT"].ToString().Trim();
        //                p_objResultArr[i1].m_strOperator_ID = dtbResult.Rows[i1]["OPERATORID_CHR"].ToString().Trim();
        //                p_objResultArr[i1].m_strCheck_Category_ID = dtbResult.Rows[i1]["CHECK_CATEGORY_ID_CHR"].ToString().Trim();

        //            }
        //        }
        //    }
        //    catch(Exception objEx)
        //    {
        //        string strTmp=objEx.Message;
        //        com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //        bool blnRes = objLogger.LogError(objEx);
        //    }
        //    return lngRes;
        //}
        //#endregion

        //        #region 查询出所有的样品类别 
        //        [AutoComplete]
        //        public long m_lngGetAllSampleType(System.Security.Principal.IPrincipal p_objPrincipal,out System.Data.DataTable dtbAllSampleType)
        //        {
        //            long lngRes = 0;
        //            string strSQL = @"select sample_type_id_chr, sample_type_desc_vchr, pycode_chr, wbcode_chr,
        //       stdcode1_chr, stdcode2_chr, hasbarcode_int from t_aid_lis_sampletype order by sample_type_id_chr";
        //            dtbAllSampleType = null;
        //            try
        //            {
        //                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbAllSampleType);
        //                objHRPSvc.Dispose();
        //            }
        //            catch(Exception objEx)
        //            {
        //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //                bool blnRes = objLogger.LogError(objEx);
        //                throw objEx;
        //            }
        //            return lngRes;
        //        }
        //        #endregion

        //        #region 根据check_item_id查询所有属于该检验项目的参考值范围(不包含默认参考值) 
        //        [AutoComplete]
        //        public long m_lngGetItemRefByCheckItemID(System.Security.Principal.IPrincipal p_objPrincipal,string checkItemID,out System.Data.DataTable dtbItemRef)
        //        {
        //            long lngRes = 0;
        //            string strSQL = @"SELECT t1.*
        //								FROM t_bse_lis_itemref t1
        //							   WHERE t1.check_item_id_chr = '"+checkItemID+"'";
        //            dtbItemRef = null;

        //            DataTable dtbCheckItem = null;
        //            try
        //            {
        //                lngRes = m_lngGetCheckItemInfoByCheckItemID(p_objPrincipal,checkItemID,out dtbCheckItem);
        //                if(lngRes > 0 && dtbCheckItem != null)
        //                {
        //                    if(dtbCheckItem.Rows.Count > 0)
        //                    {
        //                        if(dtbCheckItem.Rows[0]["IS_MENSES_RELATED_CHR"].ToString().Trim() == "1")
        //                        {
        //                            strSQL = @"SELECT t1.*, t2.dictname_vchr AS menses_name,t2.dictid_chr
        //										FROM t_bse_lis_itemref t1, t_aid_dict t2
        //									   WHERE t1.menses_id_chr = t2.dictid_chr(+)
        //										 AND t2.dictkind_chr = '63'
        //										 AND t1.check_item_id_chr = '"+checkItemID+"'";
        //                        }
        //                    }
        //                }
        //                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbItemRef);
        //                objHRPSvc.Dispose();
        //            }
        //            catch(Exception objEx)
        //            {
        //                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //                bool blnRes = objLogger.LogError(objEx);
        //                throw objEx;
        //            }
        //            return lngRes;
        //        }
        //        #endregion

        //#region 根据check_item_id查询该检验项目的默认参考值范围
        //[AutoComplete]
        //public long m_lngGetDefaultRefByCheckItemID(System.Security.Principal.IPrincipal p_objPrincipal,string checkItemID,out System.Data.DataTable dtbItemDefaultRef)
        //{
        //    long lngRes = 0;
        //    string strSQL = @"SELECT CHECK_ITEM_ID_CHR, REF_MAX_VAL_VCHR, REF_MIN_VAL_VCHR, REF_VALUE_RANGE_VCHR FROM t_bse_lis_check_item WHERE CHECK_ITEM_ID_CHR = '"+checkItemID+"'";
        //    dtbItemDefaultRef = null;
        //    try
        //    {
        //        com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //        lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbItemDefaultRef);
        //        objHRPSvc.Dispose();
        //    }
        //    catch(Exception objEx)
        //    {
        //        com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //        bool blnRes = objLogger.LogError(objEx);
        //        throw objEx;
        //    }
        //    return lngRes;
        //}
        //#endregion


        #region 根据check_item_id更新表t_bse_lis_check_item中属于该检验项目的明细资料
        [AutoComplete]
        public long m_lngSetCheckItemDetailByCheckItemID(System.Security.Principal.IPrincipal p_objPrincipal, ref com.digitalwave.iCare.ValueObject.clsCheckItem_VO objCheckItemVO)
        {
            long lngRes = 0;
            string strRptNO = objCheckItemVO.m_strRPTNO;
            string strPycode = objCheckItemVO.m_strPycode;
            string strUnit = objCheckItemVO.m_strUnit;
            string strCheckItemName = objCheckItemVO.m_strCheck_Item_Name;
            string strCheckItemEnglishName = objCheckItemVO.m_strCheck_Item_English_Name;
            string strFormula = objCheckItemVO.m_strFormula;
            string strTestMethod = objCheckItemVO.m_strTest_Method;
            string strClinicMeaning = objCheckItemVO.m_strClinic_meaning;
            string strCheckItemID = objCheckItemVO.m_strCheck_Item_ID;
            string strShortName = objCheckItemVO.m_strShortName;
            string strIsQC = objCheckItemVO.m_strIs_Qc_Required;
            string strResultType = objCheckItemVO.m_strResultType;
            string strRefValue = objCheckItemVO.m_strRef_Value_Range;
            string strWBCode = objCheckItemVO.m_strWbcode;
            string strIsNoFood = objCheckItemVO.m_strIs_No_Food_Required;
            string strIsPhysicalExam = objCheckItemVO.m_strIs_Physical_Exam_Required;
            string strIsReservation = objCheckItemVO.m_strIs_Reservation_Required;
            string strSampleValidTime = objCheckItemVO.m_strSample_Valid_Time;
            string strSampleValidTimeUnit = objCheckItemVO.m_strSample_Valid_Time_Unit;
            string strModifyDate = DateTime.Now.ToString().Trim();
            string strOperatorID = objCheckItemVO.m_strOperator_ID;
            string strCheckCategoryID = objCheckItemVO.m_strCheck_Category_ID;
            string strRefMin = objCheckItemVO.m_strRef_Value_Min;
            string strRefMax = objCheckItemVO.m_strRef_Value_Max;
            string strAssistCode1 = objCheckItemVO.m_strAssist_Code01;
            string strAssistCode2 = objCheckItemVO.m_strAssist_Code02;
            string strSampleTypeID = objCheckItemVO.m_strSampleTypeID;
            string strIsCalculate = objCheckItemVO.m_strIs_Calculated;
            string strIsMensesRelate = objCheckItemVO.m_strIs_Menses_Related;
            string strIsAgeRelate = objCheckItemVO.m_strIs_Age_Related;
            string strIsSexRelate = objCheckItemVO.m_strIs_Sex_Related;

            //			string strSQL = @"UPDATE t_bse_lis_check_item SET RPTNO_CHR = '"+strRptNO+"',PYCODE_CHR = '"+strPycode+"',UNIT_CHR = '"+strUnit+"',CHECK_ITEM_NAME_VCHR = '"+strCheckItemName+"',";
            //			strSQL += "CHECK_ITEM_ENGLISH_NAME_VCHR = '"+strCheckItemEnglishName+"',FORMULA_VCHR = '"+strFormula+"',TEST_METHODS_VCHR = '"+strTestMethod+"',";
            //			strSQL += "CLINIC_MEANING_VCHR = '"+strClinicMeaning+"',SHORTNAME_CHR = '"+strShortName+"',IS_QC_REQUIRED_CHR = '"+strIsQC+"',RESULTTYPE_CHR = '"+strResultType+"',";
            //			strSQL += "REF_VALUE_RANGE_VCHR = '"+strRefValue+"',WBCODE_CHR = '"+strWBCode+"',IS_NO_FOOD_REQUIRED_CHR = '"+strIsNoFood+"',IS_PHYSICAL_EXAM_REQUIRED_CHR = '"+strIsPhysicalExam+"',";
            //			strSQL += "IS_RESERVATION_REQUIRED_CHR = '"+strIsReservation+"',SAMPLE_VALID_TIME_DEC = '"+strSampleValidTime+"',SAMPLE_VALID_TIME_UNIT_CHR = '"+strSampleValidTimeUnit+"',";
            //			strSQL += "REF_MIN_VAL_VCHR = '" + strRefMin + "', REF_MAX_VAL_VCHR = '" + strRefMax + "', " ;
            //			strSQL += "ASSIST_CODE01_CHR = '" + strAssistCode1 + "', ASSIST_CODE02_CHR = '" + strAssistCode2 + "', ";
            //			strSQL += "MODIFY_DAT = TO_DATE('"+strModifyDate+@"','yyyy-mm-dd hh24:mi:ss'),OPERATORID_CHR = '"+strOperatorID+"',CHECK_CATEGORY_ID_CHR = '"+strCheckCategoryID+"',SAMPLETYPE_VCHR = '"+strSampleTypeID+@"',
            //					   IS_AGE_RELATED_CHR = '"+strIsAgeRelate+"',IS_SEX_RELATED_CHR = '"+strIsSexRelate+"',IS_MENSES_RELATED_CHR = '"+strIsMensesRelate+"',IS_CALCULATED_CHR = '"+strIsCalculate+"' WHERE CHECK_ITEM_ID_CHR = '"+strCheckItemID+"'";
            string strSQL = @"update t_bse_lis_check_item
								 set rptno_chr = '" + strRptNO + @"',
									 pycode_chr = '" + strPycode + @"',
									 unit_chr = '" + strUnit + @"',
									 check_item_name_vchr = '" + strCheckItemName + @"',
									 check_item_english_name_vchr = '" + strCheckItemEnglishName + @"',
									 formula_vchr = '" + strFormula + @"',
									 test_methods_vchr = '" + strTestMethod + @"',
									 clinic_meaning_vchr = '" + strClinicMeaning + @"',
									 shortname_chr = '" + strShortName + @"',
									 is_qc_required_chr = '" + strIsQC + @"',
									 resulttype_chr = '" + strResultType + @"',
									 ref_value_range_vchr = '" + strRefValue + @"',
									 wbcode_chr = '" + strWBCode + @"',
									 is_no_food_required_chr = '" + strIsNoFood + @"',
									 is_physical_exam_required_chr = '" + strIsPhysicalExam + @"',
									 is_reservation_required_chr = '" + strIsReservation + @"',
									 sample_valid_time_dec = '" + strSampleValidTime + @"',
									 sample_valid_time_unit_chr = '" + strSampleValidTimeUnit + @"',
								     ref_min_val_vchr = '" + strRefMin + @"',
									 ref_max_val_vchr = '" + strRefMax + @"',
									 assist_code01_chr = '" + strAssistCode1 + @"',
									 assist_code02_chr = '" + strAssistCode2 + @"',
									 modify_dat = TO_DATE ('" + strModifyDate + @"', 'yyyy-mm-dd hh24:mi:ss'),
									 operatorid_chr = '" + strOperatorID + @"',
									 check_category_id_chr = '" + strCheckCategoryID + @"',
									 sampletype_vchr = '" + strSampleTypeID + @"',
									 is_age_related_chr = '" + strIsAgeRelate + @"',
									 is_sex_related_chr = '" + strIsSexRelate + @"',
									 is_menses_related_chr = '" + strIsMensesRelate + @"',
									 is_calculated_chr = '" + strIsCalculate + @"',
									 formula_user_vchr = '" + objCheckItemVO.m_strFormula_User_VCHR + @"',
									 alarm_low_val_vchr = '" + objCheckItemVO.m_strALARM_LOW_VAL_VCHR + @"',
									 alarm_up_val_vchr = '" + objCheckItemVO.m_strALARM_UP_VAL_VCHR + @"',
									 alert_value_range_vchr = '" + objCheckItemVO.m_strALERT_VALUE_RANGE_VCHR + @"',
                                     itemprice_mny='" + objCheckItemVO.m_strItemprice_mny + @"'
                                  where check_item_id_chr = '" + strCheckItemID + @"'";
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
                throw objEx;
            }
            return lngRes;
        }
        #endregion

        #region 根据check_item_id更新t_bse_lis_itemref中属于该检验项目的参考值明细资料
        [AutoComplete]
        public long m_lngSetCheckItemRefByCheckItemID(System.Security.Principal.IPrincipal p_objPrincipal, ref com.digitalwave.iCare.ValueObject.clsCheckItemRef_VO objCheckItemRef)
        {
            long lngRes = 0;
            string strCheckItemID = objCheckItemRef.m_strCheck_Item_ID;
            string strMinVal = objCheckItemRef.m_strMin_Val;
            string strFromAge = objCheckItemRef.m_strFrom_Age;
            string strToAge = objCheckItemRef.m_strTo_Age;
            string strRefVal = objCheckItemRef.m_strRef_Val;
            string strSampleType = objCheckItemRef.m_strSampleType;
            string strSex = objCheckItemRef.m_strSex;
            string strMaxVal = objCheckItemRef.m_strMax_Val;
            string strSEQ = objCheckItemRef.m_strSeq_Int;
            string strSQL = @"UPDATE t_bse_lis_itemref SET MIN_VAL_VCHR = '" + strMinVal + "',FROM_AGE_DEC = '" + strFromAge + "',TO_AGE_DEC = '" + strToAge + "',";
            strSQL += " REF_VALUE_RANGE_VCHR = '" + strRefVal + "',SAMPLETYPE_VCHR = '" + strSampleType + "',SEX_VCHR = '" + strSex + "',MAX_VAL_VCHR = '" + strMaxVal + "', crvalmin = '" + objCheckItemRef.CrValMin + "', crvalmax = '" + objCheckItemRef.CrValMax + "' ";
            strSQL += " WHERE CHECK_ITEM_ID_CHR = '" + strCheckItemID + "' AND SEQ_INT = '" + strSEQ + "'";
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
                throw objEx;
            }
            return lngRes;
        }
        #endregion

        #region 在已经存在的CheckItem的基础上新增检验参考值范围
        [AutoComplete]
        public long m_lngAddItemRefByCheckItemID(System.Security.Principal.IPrincipal p_objPrincial, ref com.digitalwave.iCare.ValueObject.clsCheckItemRef_VO objCheckItemRefVO)
        {
            long lngRes = 0;
            string strSQL = @"INSERT INTO t_bse_lis_itemref(check_item_id_chr, min_val_vchr, seq_int, from_age_dec,
								ref_value_range_vchr, sampletype_vchr, sex_vchr, to_age_dec,
								max_val_vchr, clinic_meaning_vchr, crvalmin, crvalmax  )
							  VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
            string strCheckItemID = objCheckItemRefVO.m_strCheck_Item_ID;
            string strGetSEQ = @"SELECT MAX(SEQ_INT)+1 as id FROM t_bse_lis_itemref WHERE CHECK_ITEM_ID_CHR = '" + strCheckItemID + "'";
            DataTable dtbGetSEQ = null;
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(12, out objLisAddItemRefArr);

                objHRPSvc.lngGetDataTableWithoutParameters(strGetSEQ, ref dtbGetSEQ);
                string strSEQ = dtbGetSEQ.Rows[0]["id"].ToString().Trim();
                if (strSEQ == "")
                {
                    objCheckItemRefVO.m_strSeq_Int = "1";
                }
                else
                {
                    objCheckItemRefVO.m_strSeq_Int = strSEQ;
                }

                objLisAddItemRefArr[0].Value = objCheckItemRefVO.m_strCheck_Item_ID;
                objLisAddItemRefArr[1].Value = objCheckItemRefVO.m_strMin_Val;
                objLisAddItemRefArr[2].Value = objCheckItemRefVO.m_strSeq_Int;
                objLisAddItemRefArr[3].Value = objCheckItemRefVO.m_strFrom_Age;
                objLisAddItemRefArr[4].Value = objCheckItemRefVO.m_strRef_Val;
                objLisAddItemRefArr[5].Value = objCheckItemRefVO.m_strSampleType;
                objLisAddItemRefArr[6].Value = objCheckItemRefVO.m_strSex;
                objLisAddItemRefArr[7].Value = objCheckItemRefVO.m_strTo_Age;
                objLisAddItemRefArr[8].Value = objCheckItemRefVO.m_strMax_Val;
                objLisAddItemRefArr[9].Value = objCheckItemRefVO.m_strClinic_Meaning;
                objLisAddItemRefArr[10].Value = objCheckItemRefVO.CrValMin;
                objLisAddItemRefArr[11].Value = objCheckItemRefVO.CrValMax;
                long lngRecEff = -1;

                //往表t_bse_lis_itemref增加记录
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, objLisAddItemRefArr);
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

        #region 删除表t_bse_lis_check_item检验项目
        [AutoComplete]
        public long m_lngDelCheckItem(System.Security.Principal.IPrincipal p_objPrincipal, string strCheckItemID)
        {
            long lngRes = 0;
            string strSQL = @"DELETE FROM t_bse_lis_check_item WHERE CHECK_ITEM_ID_CHR = '" + strCheckItemID + "'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                long lngRecEff = -1;
                lngRes = objHRPSvc.DoExcuteForDelete(strSQL, ref lngRecEff);
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

        #region 删除表t_bse_lis_itemref所有与该检验项目相关的参考值
        [AutoComplete]
        public long m_lngDelCheckItemRef(System.Security.Principal.IPrincipal p_objPrincipal, string strCheckItemID)
        {
            long lngRes = 0;
            string strSQL = @"DELETE FROM t_bse_lis_itemref WHERE CHECK_ITEM_ID_CHR = '" + strCheckItemID + "'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                long lngRecEff = -1;
                lngRes = objHRPSvc.DoExcuteForDelete(strSQL, ref lngRecEff);
                if (lngRecEff > -1)
                {
                    lngRes = 1;
                }
                strSQL = @"delete from t_criticalvalue_ref_lisdept where check_item_id_chr = '" + strCheckItemID + "'";
                objHRPSvc.DoExcuteForDelete(strSQL, ref lngRecEff);

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

        #region 删除表t_bse_lis_itemref中某一个序号的检验项目参考值
        [AutoComplete]
        public long m_lngDelCheckItemRefBySEQ(System.Security.Principal.IPrincipal p_objPrincipal, string strCheckItemID, string strSEQ)
        {
            long lngRes = 0;
            string strSQL = @"DELETE FROM t_bse_lis_itemref WHERE CHECK_ITEM_ID_CHR = '" + strCheckItemID + "' AND SEQ_INT = '" + strSEQ + "'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                long lngRecEff = -1;
                lngRes = objHRPSvc.DoExcuteForDelete(strSQL, ref lngRecEff);
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

        #region 新增样品类别到表T_AID_LIS_SAMPLETYPE
        [AutoComplete]
        public long m_lngAddSampleType(System.Security.Principal.IPrincipal p_objPrincipal, ref com.digitalwave.iCare.ValueObject.clsSampleType_VO objSampleTypeVO)
        {
            long lngRes = 0;
            string strSQL = @"INSERT INTO T_AID_LIS_SAMPLETYPE(SAMPLE_TYPE_ID_CHR,SAMPLE_TYPE_DESC_VCHR,PYCODE_CHR,
								WBCODE_CHR,STDCODE1_CHR,STDCODE2_CHR,HasBarCode_int) VALUES(?,?,?,?,?,?,?)";
            try
            {
                System.Data.IDataParameter[] objSampleTypeArr = null;

                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(7, out objSampleTypeArr);

                string strNewSampleTypeID = objHRPSvc.m_strGetNewID("T_AID_LIS_SAMPLETYPE", "SAMPLE_TYPE_ID_CHR", 6);
                objSampleTypeVO.m_strSample_Type_ID = strNewSampleTypeID;

                objSampleTypeArr[0].Value = objSampleTypeVO.m_strSample_Type_ID;
                objSampleTypeArr[1].Value = objSampleTypeVO.m_strSample_Type_Desc;
                objSampleTypeArr[2].Value = objSampleTypeVO.m_strPyCode;
                objSampleTypeArr[3].Value = objSampleTypeVO.m_strWbCode;
                objSampleTypeArr[4].Value = objSampleTypeVO.m_strStdCode1;
                objSampleTypeArr[5].Value = objSampleTypeVO.m_strStdCode2;
                objSampleTypeArr[6].Value = objSampleTypeVO.m_intHasBarCode;

                long lngRecEff = -1;

                //往表T_AID_LIS_SAMPLETYPE增加记录
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, objSampleTypeArr);
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

        #region 删除表T_AID_LIS_SAMPLETYPE中的记录
        [AutoComplete]
        public long m_lngDelSampleTypeBySampleTypeID(System.Security.Principal.IPrincipal p_objPrincipal, string strSampleTypeID)
        {
            long lngRes = 0;
            string strSQL = @"DELETE FROM T_AID_LIS_SAMPLETYPE WHERE SAMPLE_TYPE_ID_CHR = '" + strSampleTypeID + "'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                long lngRecEff = -1;
                lngRes = objHRPSvc.DoExcuteForDelete(strSQL, ref lngRecEff);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                new clsLogText().LogError(objEx);
                throw objEx;
            }
            return lngRes;
        }
        #endregion

        #region 更新表T_AID_LIS_SAMPLETYPE中的记录
        [AutoComplete]
        public long m_lngSetSampleTypeDetailBySampleTypeID(System.Security.Principal.IPrincipal p_objPrincipal, string strSampleType, string strPyCode, string strWbCode, string strSampleTypeID, int intHasFlag)
        {
            long lngRes = 0;
            string strSQL = @"UPDATE T_AID_LIS_SAMPLETYPE SET SAMPLE_TYPE_DESC_VCHR = '" + strSampleType + "',PYCODE_CHR = '" + strPyCode + "',WBCODE_CHR = '" + strWbCode + "',HasBarCode_int = '" + intHasFlag.ToString() + "' WHERE SAMPLE_TYPE_ID_CHR = '" + strSampleTypeID + "'";
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
                throw objEx;
            }
            return lngRes;
        }
        #endregion

        #region 查询出表T_AID_LIS_SAMPLE_CHARACTER所有的样本性状
        [AutoComplete]
        public long m_lngGetAllSampleCharacter(System.Security.Principal.IPrincipal p_objPrincipal, string strSampleTypeID, out System.Data.DataTable dtbAllSampleCharacter)
        {
            long lngRes = 0;
            string strSQL = @"SELECT * FROM T_AID_LIS_SAMPLE_CHARACTER WHERE SAMPLE_TYPE_ID_CHR = '" + strSampleTypeID + "'";
            dtbAllSampleCharacter = null;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbAllSampleCharacter);
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

        #region 更新表T_AID_LIS_SAMPLE_CHARACTER中某一序号的样本状态
        [AutoComplete]
        public long m_lngSetSampleCharacterBySampleTypeIDAndSEQ(System.Security.Principal.IPrincipal p_objPrincipal, string strSampleTypeID, string strSEQ, string strSampleCharacter, string strPyCode, string strWbCode)
        {
            long lngRes = 0;
            string strSQL = @"UPDATE T_AID_LIS_SAMPLE_CHARACTER SET CHARACTER_DESC_VCHR = '" + strSampleCharacter + "',PYCODE_CHR = '" + strPyCode + "',WBCODE_CHR = '" + strWbCode + "' ";
            strSQL += " WHERE CHARACTERORD_INT = '" + strSEQ + "' AND SAMPLE_TYPE_ID_CHR = '" + strSampleTypeID + "'";
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
                throw objEx;
            }
            return lngRes;
        }
        #endregion

        #region 新增样本性状到表T_AID_LIS_SAMPLE_CHARACTER
        [AutoComplete]
        public long m_lngAddSampleCharacterBySampleTypeID(System.Security.Principal.IPrincipal p_objPrincipal, ref com.digitalwave.iCare.ValueObject.clsSampleCharacter_VO objSampleCharacterVO)
        {
            long lngRes = 0;
            string strSQL = @"INSERT INTO t_aid_lis_sample_character
								(characterord_int, character_desc_vchr, pycode_chr, wbcode_chr,sample_type_id_chr)
							  VALUES ( ?, ?, ?, ?, ?)";
            string strSampleTypeID = objSampleCharacterVO.m_strSample_Type_ID;
            string strGetSEQ = @"SELECT MAX(CHARACTERORD_INT)+1 as id FROM T_AID_LIS_SAMPLE_CHARACTER WHERE SAMPLE_TYPE_ID_CHR = '" + strSampleTypeID + "'";
            DataTable dtbGetSEQ = null;
            try
            {
                System.Data.IDataParameter[] objLisSampleCharacterArr = null;
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(5, out objLisSampleCharacterArr);

                objHRPSvc.lngGetDataTableWithoutParameters(strGetSEQ, ref dtbGetSEQ);
                string strSEQ = dtbGetSEQ.Rows[0]["id"].ToString().Trim();
                if (strSEQ == "")
                {
                    objSampleCharacterVO.m_strCharacter_Ord = "1";
                }
                else
                {
                    objSampleCharacterVO.m_strCharacter_Ord = strSEQ;
                }
                objLisSampleCharacterArr[0].Value = objSampleCharacterVO.m_strCharacter_Ord;
                objLisSampleCharacterArr[1].Value = objSampleCharacterVO.m_strCharacter_Desc;
                objLisSampleCharacterArr[2].Value = objSampleCharacterVO.m_strPyCode;
                objLisSampleCharacterArr[3].Value = objSampleCharacterVO.m_strwbCode;
                objLisSampleCharacterArr[4].Value = objSampleCharacterVO.m_strSample_Type_ID;

                long lngRecEff = -1;

                //往表t_bse_lis_itemref增加记录
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, objLisSampleCharacterArr);
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

        #region 删除表T_AID_LIS_SAMPLE_CHARACTER的样本性状
        [AutoComplete]
        public long m_lngDelSampleCharacterBySampleTypeIDAndSEQ(System.Security.Principal.IPrincipal p_objPrincipal, string strSampleTypeID, string strSEQ)
        {
            long lngRes = 0;
            string strSQL = @"DELETE FROM T_AID_LIS_SAMPLE_CHARACTER WHERE SAMPLE_TYPE_ID_CHR = '" + strSampleTypeID + "' AND CHARACTERORD_INT = '" + strSEQ + "'";
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
                throw objEx;
            }
            return lngRes;
        }
        #endregion

    }
}
