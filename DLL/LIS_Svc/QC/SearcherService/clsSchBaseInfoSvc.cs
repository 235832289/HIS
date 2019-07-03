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
    [ObjectPooling(Enabled = true)]
    public class clsSchBaseInfoSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 返回检验项目树

        [AutoComplete]
        public long m_lngGetCheckItemTree(System.Security.Principal.IPrincipal p_objPrincipal, out clsLISUserGroupNode root)
        {
            long lngRes = 0;
            root = null;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege
                (p_objPrincipal, "com.digitalwave.iCare.middletier.clsSchBaseInfoSvc", "m_lngGetCheckItemTree");
            if (lngRes <= 0)
            {
                return -1;
            }

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            #region SQL
            string strSQL1 = @"SELECT t1.check_item_id_chr, t1.check_item_name_vchr FROM t_bse_lis_check_item t1";
            string strSQL2 = @"SELECT t1.apply_unit_id_chr, t1.apply_unit_name_vchr FROM t_aid_lis_apply_unit t1";
            string strSQL3 = @"SELECT t1.user_group_id_chr, t1.user_group_name_vchr FROM t_aid_lis_appuser_group t1";
            string strSQL4 = @"select check_item_id_chr, apply_unit_id_chr, print_seq_int
                                from t_aid_lis_apply_unit_detail";
            string strSQL5 = @"SELECT user_group_id_chr, apply_unit_id_chr FROM t_aid_lis_appuser_group_detail";
            string strSQL6 = @"SELECT user_group_id_chr, child_user_group_id_chr FROM t_aid_lis_appuser_group_relate";
            #endregion

            DataTable dtbResultItem = null;
            DataTable dtbResultUnit = null;
            DataTable dtbResultUnitDetail = null;
            DataTable dtbResultGroup = null;
            DataTable dtbResultGroupDetail = null;
            DataTable dtbResultGroupRelate = null;
            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL1, ref dtbResultItem);
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL2, ref dtbResultUnit);
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL3, ref dtbResultGroup);
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL4, ref dtbResultUnitDetail);
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL5, ref dtbResultGroupDetail);
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL6, ref dtbResultGroupRelate);

                System.Collections.Hashtable hasItem = new Hashtable();
                System.Collections.Hashtable hasUnit = new Hashtable();
                System.Collections.Hashtable hasGroup = new Hashtable();
                System.Collections.Hashtable hasTopGroup = new Hashtable();

                if (dtbResultItem != null)
                {
                    foreach (DataRow dtrItem in dtbResultItem.Rows)
                    {
                        clsLISCheckItemNode node = new clsLISCheckItemNode();
                        node.strID = dtrItem["check_item_id_chr"].ToString();
                        node.strName = dtrItem["check_item_name_vchr"].ToString();
                        hasItem.Add(node.strID, node);
                    }
                }
                if (dtbResultUnit != null)
                {
                    foreach (DataRow dtrUnit in dtbResultUnit.Rows)
                    {
                        clsLISApplyUnitNode node = new clsLISApplyUnitNode();
                        node.strID = dtrUnit["APPLY_UNIT_ID_CHR"].ToString();
                        node.Name = dtrUnit["APPLY_UNIT_NAME_VCHR"].ToString();
                        hasUnit.Add(node.strID, node);
                    }
                }
                if (dtbResultGroup != null)
                {
                    foreach (DataRow dtrGroup in dtbResultGroup.Rows)
                    {
                        clsLISUserGroupNode node = new clsLISUserGroupNode();
                        node.strID = dtrGroup["USER_GROUP_ID_CHR"].ToString();
                        node.strName = dtrGroup["USER_GROUP_NAME_VCHR"].ToString();
                        hasGroup.Add(node.strID, node);
                        hasTopGroup.Add(node.strID, node);
                    }
                }
                if (dtbResultUnitDetail != null)
                {
                    foreach (DataRow dtrUnitDetail in dtbResultUnitDetail.Rows)
                    {
                        string strUnitID = dtrUnitDetail["APPLY_UNIT_ID_CHR"].ToString();
                        string strItemID = dtrUnitDetail["CHECK_ITEM_ID_CHR"].ToString();
                        if (hasUnit.ContainsKey(strUnitID) && hasItem.ContainsKey(strItemID))
                        {
                            if (((clsLISApplyUnitNode)hasUnit[strUnitID]).objItems == null)
                            {
                                ((clsLISApplyUnitNode)hasUnit[strUnitID]).objItems = new System.Collections.Generic.List<clsLISCheckItemNode>();
                            }
                            ((clsLISApplyUnitNode)hasUnit[strUnitID]).objItems.Add((clsLISCheckItemNode)hasItem[strItemID]);
                        }
                    }
                }
                hasItem = null;
                if (dtbResultGroupDetail != null)
                {
                    foreach (DataRow dtrGroupDetail in dtbResultGroupDetail.Rows)
                    {
                        string strGroupID = dtrGroupDetail["USER_GROUP_ID_CHR"].ToString();
                        string strUnitID = dtrGroupDetail["APPLY_UNIT_ID_CHR"].ToString();
                        if (hasGroup.ContainsKey(strGroupID) && hasUnit.ContainsKey(strUnitID))
                        {
                            if (((clsLISUserGroupNode)hasGroup[strGroupID]).objUnitNodes == null)
                            {
                                ((clsLISUserGroupNode)hasGroup[strGroupID]).objUnitNodes = new System.Collections.Generic.List<clsLISApplyUnitNode>();
                            }
                            ((clsLISUserGroupNode)hasGroup[strGroupID]).objUnitNodes.Add((clsLISApplyUnitNode)hasUnit[strUnitID]);
                        }
                    }
                }
                hasUnit = null;
                if (dtbResultGroupRelate != null)
                {
                    foreach (DataRow dtrGroupRelate in dtbResultGroupRelate.Rows)
                    {
                        string strGroupID1 = dtrGroupRelate["USER_GROUP_ID_CHR"].ToString();
                        string strGroupID2 = dtrGroupRelate["CHILD_USER_GROUP_ID_CHR"].ToString();
                        if (hasGroup.ContainsKey(strGroupID1) && hasGroup.ContainsKey(strGroupID2))
                        {
                            if (((clsLISUserGroupNode)hasGroup[strGroupID1]).objChildNodes == null)
                            {
                                ((clsLISUserGroupNode)hasGroup[strGroupID1]).objChildNodes = new System.Collections.Generic.List<clsLISUserGroupNode>();
                            }
                            ((clsLISUserGroupNode)hasGroup[strGroupID1]).objChildNodes.Add((clsLISUserGroupNode)hasGroup[strGroupID2]);
                            hasTopGroup.Remove(strGroupID2);
                        }
                    }
                }
                hasGroup = null;

                root = new clsLISUserGroupNode();
                root.objChildNodes = new System.Collections.Generic.List<clsLISUserGroupNode>();
                foreach (clsLISUserGroupNode groupNode in hasTopGroup.Values)
                {
                    root.objChildNodes.Add(groupNode);
                }
                hasTopGroup = null;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx);
                lngRes = 0;
                root = null;
            }
            return lngRes;
        }

        #endregion 
        #region ref
        //        #region 根据条件查询登记信息 2005.04.08
        //        /// <summary>
        //        /// 根据条件查询登记信息
        //        /// </summary>
        //        /// <param name="p_objPrincipal"></param>
        //        /// <param name="p_strFromDat"></param>
        //        /// <param name="p_strToDat"></param>
        //        /// <param name="p_objRecordArr"></param>
        //        /// <returns></returns>
        //        [AutoComplete]
        //        public long m_lngFindExamineBookVOByCondition(System.Security.Principal.IPrincipal p_objPrincipal,
        //            clsPISBookSchVO p_objCondition,out clsPISBookVO[] p_objRecordArr)
        //        {
        //            long lngRes = 0;
        //            p_objRecordArr = null;
        //            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //            lngRes = objPrivilege.m_lngCheckCallPrivilege
        //                (p_objPrincipal,"com.digitalwave.iCare.middletier.clsSchBookSvc","m_lngFindExamineBookVOByCondition");
        //            if(lngRes <= 0)
        //            {
        //                return -1;
        //            }

        //            #region SQL

        //            string strSQL = @"SELECT * FROM t_pis_opr_book WHERE 1 = 1";
        //            string strSQL_FromDat = " AND BOOK_DAT >= TO_DATE( ?,'yyyy-mm-dd hh24:mi:ss')";
        //            string strSQL_ToDat = " AND BOOK_DAT <= TO_DATE( ?,'yyyy-mm-dd hh24:mi:ss')";
        //            string strSQL_ExamineID = " AND person_examine_id_chr LIKE ?";
        //            string strSQL_PersonName = " AND person_name_vchr LIKE ?";
        //            string strSQL_CompanyName = " AND company_name_vchr LIKE ?";

        //            #endregion

        //            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

        //            #region 构造SQL

        //            ArrayList arlSQL = new ArrayList();
        //            ArrayList arlPara = new ArrayList();

        //            if(p_objCondition.m_strDateFrom != null && p_objCondition.m_strDateFrom != "")
        //            {
        //                arlSQL.Add(strSQL_FromDat);
        //                arlPara.Add(p_objCondition.m_strDateFrom);
        //            }

        //            if(p_objCondition.m_strDateTo != null && p_objCondition.m_strDateTo != "")
        //            {
        //                arlSQL.Add(strSQL_ToDat);
        //                arlPara.Add(p_objCondition.m_strDateTo);
        //            }

        //            if(p_objCondition.m_strExamineID != null && p_objCondition.m_strExamineID != "")
        //            {
        //                arlSQL.Add(strSQL_ExamineID);
        //                arlPara.Add("%"+p_objCondition.m_strExamineID+"%");
        //            }

        //            if(p_objCondition.m_strPersonName != null && p_objCondition.m_strPersonName != "")
        //            {
        //                arlSQL.Add(strSQL_PersonName);
        //                arlPara.Add("%"+p_objCondition.m_strPersonName+"%");
        //            }

        //            if(p_objCondition.m_strCompanyName != null && p_objCondition.m_strCompanyName != "")
        //            {
        //                arlSQL.Add(strSQL_CompanyName);
        //                arlPara.Add("%"+p_objCondition.m_strCompanyName+"%");
        //            }

        //            #endregion

        //            foreach(object obj in arlSQL)
        //            {
        //                strSQL += obj.ToString();
        //            }

        //            System.Data.IDataParameter[] objIDPArr = null;
        //            objHRPSvc.CreateDatabaseParameter(arlPara.Count,out objIDPArr);

        //            for(int i=0;i<arlPara.Count;i++)
        //            {
        //                objIDPArr[i].Value = arlPara[i];
        //            }

        //            try
        //            {
        //                DataTable dtbResult = null;
        //                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL,ref dtbResult,objIDPArr);
        //                if(lngRes > 0 && dtbResult != null && dtbResult.Rows.Count > 0)
        //                {
        //                    clsTmdBookSvc objBookSvc = new clsTmdBookSvc();
        //                    p_objRecordArr = new clsPISBookVO[dtbResult.Rows.Count];
        //                    for(int i=0;i<dtbResult.Rows.Count;i++)
        //                    {
        //                        p_objRecordArr[i] = new clsPISBookVO();
        //                        objBookSvc.ConstructVO(dtbResult.Rows[i],ref p_objRecordArr[i]);
        //                    }
        //                }
        //                objHRPSvc.Dispose();
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
    }
}