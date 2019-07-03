using System;
using System.EnterpriseServices;
using System.Data;
using System.Collections;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.security;//PrivilegeSystemService.dll

namespace com.digitalwave.iCare.middletier.LIS
{
	[Transaction(TransactionOption.Required)]
	[ObjectPooling(Enabled=true)]
    public class clsSchQCBatchSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 根据组合条件查询质控批 2005.04.08
        /// <summary>
        /// 根据组合条件查询质控批
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strFromDat"></param>
        /// <param name="p_strToDat"></param>
        /// <param name="p_objRecordArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFindQCBatchCombinatorial(System.Security.Principal.IPrincipal p_objPrincipal,
            clsLisQCBatchSchVO p_objCondition, out clsLisQCBatchVO[] p_objRecordArr)
        {
            long lngRes = 0;
            p_objRecordArr = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege
                (p_objPrincipal, "com.digitalwave.iCare.middletier.clsSchQCBatchSvc", "m_lngFindQCBatchCombinatorial");
            if (lngRes <= 0)
            {
                return -1;
            }

            #region SQL

//            string strSQL = @"SELECT t1.*, t2.workgroup_name_vchr, t3.devicename_vchr,
//                                   t3.device_model_desc_vchr, t4.check_item_name_vchr,t6.lastname_vchr as operator_name
//                              FROM t_opr_lis_qcbatch t1,
//                                   t_bse_lis_workgroup t2,
//                                   (SELECT *
//                                      FROM t_bse_lis_device t31, t_bse_lis_device_model t32
//                                     WHERE t31.device_model_id_chr = t32.device_model_id_chr) t3,
//                                   t_bse_lis_check_item t4,
//                                   t_bse_employee t6
//                             WHERE t1.status_int = 1 
//                               AND t1.workgroup_seq_int = t2.workgroup_seq_int(+)
//                               AND t1.deviceid_chr = t3.deviceid_chr(+)
//                               AND t1.check_item_id_chr = t4.check_item_id_chr(+)
//                               AND t1.operator_id_chr = t6.empid_chr(+)";

            string strSQL = @"select t1.qcbatch_seq_int,
                                       t1.sort_num_int,
                                       t1.workgroup_seq_int,
                                       t1.deviceid_chr,
                                       t1.check_item_id_chr,
                                       t1.qcsample_lotno_vchr,
                                       t1.qcsample_source_vchr,
                                       t1.qcsample_vendor_vchr,
                                       t1.reagent_vchr,
                                       t1.reagent_batch_vchr,
                                       t1.checkmethod_name_vchr,
                                       t1.wavelength_num,
                                       t1.qcrules_vchr,
                                       t1.resultunit_vchr,
                                       t1.begin_dat,
                                       t1.end_dat,
                                       t1.summary_vchr,
                                       t1.operator_id_chr,
                                       t1.modify_dat,
                                       t1.status_int,
                                       t1.sort_num_int,
                                       t2.workgroup_name_vchr,
                                       t3.devicename_vchr,
                                       t3.device_model_desc_vchr,
                                       t4.device_check_item_name_vchr,
                                       t6.lastname_vchr as operator_name
                                  from t_opr_lis_qcbatch t1,
                                       t_bse_lis_workgroup t2,
                                       (select t31.deviceid_chr,
                                               t31.devicename_vchr,
                                               t32.device_model_desc_vchr,
                                               t31.device_model_id_chr
                                          from t_bse_lis_device t31, t_bse_lis_device_model t32
                                         where t31.device_model_id_chr = t32.device_model_id_chr) t3,
                                       t_bse_lis_device_check_item t4,
                                       t_bse_employee t6
                                 where t1.status_int = 1
                                   and t1.workgroup_seq_int = t2.workgroup_seq_int(+)
                                   and t1.deviceid_chr = t3.deviceid_chr(+)
                                   and t3.device_model_id_chr = t4.device_model_id_chr
                                   and t1.check_item_id_chr = t4.device_check_item_id_chr(+)
                                   and t1.operator_id_chr = t6.empid_chr(+) ";

            string strSQL_BatchSeq = " AND t1.qcbatch_seq_int = ?";
            string strSQL_WorkGroup = " AND t1.workgroup_seq_int = ?";
            string strSQL_Device = " AND t1.deviceid_chr = ?";
            string strSQL_CheckItem = " AND t1.check_item_id_chr = ?";
            string strSQL_QCSampleLot = " AND t1.qcsample_lotno_vchr = ?";
            string strSQL_FromDat = " AND t1.begin_dat < ?";
            string strSQL_ToDat = " AND t1.end_dat > ?";

            #endregion

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            #region 构造SQL

            ArrayList arlSQL = new ArrayList();
            ArrayList arlPara = new ArrayList();

            arlSQL.Add(strSQL_FromDat);
            arlPara.Add(p_objCondition.m_datQueryEnd);

            arlSQL.Add(strSQL_ToDat);
            arlPara.Add(p_objCondition.m_datQueryBegin);

            if (p_objCondition.m_intQCBatchSeq >= 0)
            {
                arlSQL.Add(strSQL_BatchSeq);
                arlPara.Add(p_objCondition.m_intQCBatchSeq);
            }

            if (p_objCondition.m_intWorkGroupSeq >= 0)
            {
                arlSQL.Add(strSQL_WorkGroup);
                arlPara.Add(p_objCondition.m_intWorkGroupSeq);
            }

            if (p_objCondition.m_strQCDevice != null && p_objCondition.m_strQCDevice.Trim() != "")
            {
                arlSQL.Add(strSQL_Device);
                arlPara.Add(p_objCondition.m_strQCDevice);
            }

            if (p_objCondition.m_strQCCheckItem != null && p_objCondition.m_strQCCheckItem.Trim() != "")
            {
                arlSQL.Add(strSQL_CheckItem);
                arlPara.Add(p_objCondition.m_strQCCheckItem);
            }

            if (p_objCondition.m_strQCSampleLotNO != null && p_objCondition.m_strQCSampleLotNO.Trim() != "")
            {
                arlSQL.Add(strSQL_QCSampleLot);
                arlPara.Add(p_objCondition.m_strQCSampleLotNO);
            }

            #endregion

            foreach (object obj in arlSQL)
            {
                strSQL += obj.ToString();
            }

            System.Data.IDataParameter[] objIDPArr = null;
            objHRPSvc.CreateDatabaseParameter(arlPara.Count, out objIDPArr);

            for (int i = 0; i < arlPara.Count; i++)
            {
                objIDPArr[i].Value = arlPara[i];
            }

            try
            {
                DataTable dtbResult = null;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objIDPArr);
                if (lngRes > 0 && dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    clsTmdQCBatchSvc objSvc = new clsTmdQCBatchSvc();
                    p_objRecordArr = new clsLisQCBatchVO[dtbResult.Rows.Count];
                    for (int i = 0; i < dtbResult.Rows.Count; i++)
                    {
                        p_objRecordArr[i] = new clsLisQCBatchVO();
                        this.ConstructVO(dtbResult.Rows[i], ref p_objRecordArr[i]);
                        p_objRecordArr[i].m_strWorkGroupName = dtbResult.Rows[i]["workgroup_name_vchr"].ToString();
                        p_objRecordArr[i].m_strDeviceName = dtbResult.Rows[i]["devicename_vchr"].ToString();
                        p_objRecordArr[i].m_strCheckItemName = dtbResult.Rows[i]["device_check_item_name_vchr"].ToString();
                        p_objRecordArr[i].m_strOperatorName = dtbResult.Rows[i]["operator_name"].ToString();
                        p_objRecordArr[i].m_strSortNum = dtbResult.Rows[i]["sort_num_int"].ToString();
                    }
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

        #region ref

        //        #region 根据体检编号查询登记所有相关信息 2005.04.08
        //        /// <summary>
        //        /// 根据体检编号查询所有登记相关信息
        //        /// </summary>
        //        /// <param name="p_objPrincipal"></param>
        //        /// <param name="p_strExamineID"></param>
        //        /// <param name="p_objRecord"></param>
        //        /// <returns></returns>
        //        [AutoComplete]
        //        public long m_lngFindExamineBookInfoByExamineBookID(System.Security.Principal.IPrincipal p_objPrincipal,string p_strExamineID,
        //            out clsPISExamineBookUniteVO p_objRecord)
        //        {
        //            long lngRes = 0;
        //            p_objRecord = null;
        //            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //            lngRes = objPrivilege.m_lngCheckCallPrivilege
        //                (p_objPrincipal,"com.digitalwave.iCare.middletier.clsSchBookSvc","m_lngFindExamineBookInfoByExamineBookID");
        //            if(lngRes <= 0)
        //            {
        //                return -1;
        //            }

        //            try
        //            {
        //                lngRes = 0;
        //                clsTmdBookSvc objBookSvc = new clsTmdBookSvc();
        //                clsPISBookVO objBookVO = null;
        //                lngRes = objBookSvc.m_lngFindByExamineID(p_objPrincipal,p_strExamineID,out objBookVO);
        //                if(lngRes > 0 && objBookVO != null)
        //                {
        //                    p_objRecord = new clsPISExamineBookUniteVO();
        //                    p_objRecord.m_objBook = objBookVO;
        //                    lngRes = 0;
        //                    clsTmdCheckGroupSvc objCheckGroupSvc = new clsTmdCheckGroupSvc();
        //                    lngRes = objCheckGroupSvc.m_lngFindByExamineID(p_objPrincipal,p_strExamineID,out p_objRecord.m_objCheckGroupArr);
        //                    if(lngRes > 0)
        //                    {
        //                        lngRes = 0;
        //                        p_objRecord.m_objPerson = new clsPISPersonInfo();
        //                        clsTmdPersonSvc objPersonSvc = new clsTmdPersonSvc();
        //                        lngRes = objPersonSvc.m_lngFind(p_objPrincipal,p_objRecord.m_objBook.m_strPERSON_ID_CHR,out p_objRecord.m_objPerson.m_objPerson);
        //                        if(lngRes > 0)
        //                        {
        //                            lngRes = 0;
        //                            clsTmdPersonHealthSvc objPersonHealthSvc = new clsTmdPersonHealthSvc();
        //                            lngRes = objPersonHealthSvc.m_lngFind(p_objPrincipal,p_objRecord.m_objBook.m_strPERSON_ID_CHR,out p_objRecord.m_objPerson.m_objPersonHealth);
        //                        }
        //                    }
        //                }
        //                if(lngRes <= 0)
        //                {
        //                    ContextUtil.SetAbort();
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

        //        #region 验证方法

        //        /// <summary>
        //        /// 根据体检编号判断是否有做过体检
        //        /// </summary>
        //        /// <param name="p_objPrincipal"></param>
        //        /// <param name="p_strExamineID"></param>
        //        /// <param name="p_blnChecked"></param>
        //        /// <returns></returns>
        //        [AutoComplete]
        //        public long m_lngHasChecked(System.Security.Principal.IPrincipal p_objPrincipal,string p_strExamineID,out bool p_blnChecked)
        //        {
        //            long lngRes = 0;
        //            p_blnChecked = false;
        //            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //            lngRes = objPrivilege.m_lngCheckCallPrivilege
        //                (p_objPrincipal,"com.digitalwave.iCare.middletier.clsSchBookSvc","m_lngHasChecked");
        //            if(lngRes <= 0)
        //            {
        //                return -1;
        //            }

        //            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //            #region SQL
        //            string strSQL = @"SELECT *
        //								FROM t_pis_opr_check_result
        //							   WHERE person_examine_id_chr = ?
        //								 AND ROWNUM = 1";
        //            #endregion

        //            try
        //            {
        //                System.Data.IDataParameter[] objIDPArr = m_objConstructIDataParameterArr(p_strExamineID);
        //                DataTable dtbResult = null;
        //                lngRes = 0;
        //                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL,ref dtbResult,objIDPArr);
        //                if(lngRes > 0 && dtbResult != null && dtbResult.Rows.Count > 0)
        //                {
        //                    p_blnChecked = true;
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
        #endregion

        [AutoComplete]
        public void ConstructVO(DataRow p_dtrSource, ref clsLisQCBatchVO p_objQCBatch)
        {
            p_objQCBatch.m_strSortNum = p_dtrSource["sort_num_int"].ToString().Trim();
            p_objQCBatch.m_intSeq = DBAssist.ToInt32(p_dtrSource["QCBATCH_SEQ_INT"]);
            p_objQCBatch.m_intWorkGroupSeq = DBAssist.ToInt32(p_dtrSource["WORKGROUP_SEQ_INT"]);
            p_objQCBatch.m_strDeviceId = p_dtrSource["DEVICEID_CHR"].ToString().Trim();
            p_objQCBatch.m_strCheckItemId = p_dtrSource["CHECK_ITEM_ID_CHR"].ToString().Trim();
            p_objQCBatch.m_strSampleLotNo = p_dtrSource["QCSAMPLE_LOTNO_VCHR"].ToString().Trim();
            p_objQCBatch.m_strSampleSource = p_dtrSource["QCSAMPLE_SOURCE_VCHR"].ToString().Trim();
            p_objQCBatch.m_strSampleVendor = p_dtrSource["QCSAMPLE_VENDOR_VCHR"].ToString().Trim();
            p_objQCBatch.m_strReagent = p_dtrSource["REAGENT_VCHR"].ToString().Trim();
            p_objQCBatch.m_strReagentBatch = p_dtrSource["REAGENT_BATCH_VCHR"].ToString().Trim();
            p_objQCBatch.m_strCheckmethodName = p_dtrSource["CHECKMETHOD_NAME_VCHR"].ToString().Trim();
            p_objQCBatch.m_dblWaveLength = DBAssist.ToDouble(p_dtrSource["WAVELENGTH_NUM"]);
            p_objQCBatch.m_strQCRules = p_dtrSource["QCRULES_VCHR"].ToString().Trim();
            p_objQCBatch.m_strResultUnit = p_dtrSource["RESULTUNIT_VCHR"].ToString().Trim();
            p_objQCBatch.m_dtBegin = DBAssist.ToDateTime(p_dtrSource["BEGIN_DAT"]);
            p_objQCBatch.m_dtEnd = DBAssist.ToDateTime(p_dtrSource["END_DAT"]);
            p_objQCBatch.m_strSummary = p_dtrSource["SUMMARY_VCHR"].ToString().Trim();
            p_objQCBatch.m_strOperatorId = p_dtrSource["OPERATOR_ID_CHR"].ToString().Trim();
            p_objQCBatch.m_dtModify = DBAssist.ToDateTime(p_dtrSource["MODIFY_DAT"]);
            try
            {
                p_objQCBatch.m_enmStatus = (enmQCStatus)DBAssist.ToInt32(p_dtrSource["STATUS_INT"]);
            }
            catch
            {
            }
        }

	}
}