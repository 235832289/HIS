using System;
using System.Data;
using System.EnterpriseServices;
using Microsoft.VisualBasic;
using com.digitalwave.Utility; //Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll

namespace com.digitalwave.iCare.middletier.LIS
{
    /// <summary>
    /// clsAppGroupSvc 的摘要说明。
    ///  
    /// </summary>
    [Transaction(TransactionOption.Required)]
    [ObjectPooling(Enabled = true)]
    public class clsAppGroupSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase//MiddleTierBase.dll
    {
        #region 构造函数
        public clsAppGroupSvc()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        #endregion

        #region 更新表t_aid_lis_appluser_group的has_child_group字段
        [AutoComplete]
        public long m_lngUpdApplUserGroup(System.Security.Principal.IPrincipal p_objPrincipal, string p_strHasChildGroup,
            string p_strApplUserGroupID)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsAppGroupSvc", "m_lngUpdApplUserGroup");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"UPDATE t_aid_lis_appuser_group
								 SET has_child_group = '" + p_strHasChildGroup + @"'
							   WHERE user_group_id_chr = '" + p_strApplUserGroupID + @"'";
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

        #region 查询所有的自定义组的子组信息
        [AutoComplete]
        public long m_lngGetAllApplUserGroupRelation(System.Security.Principal.IPrincipal p_objPrincipal,
            out clsApplUserGroupRelation_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = null;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsAppGroupSvc", "m_lngGetCheckItemInApplGroupDetailByApplUserGroupID");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"SELECT * FROM T_AID_LIS_APPUSER_GROUP_RELATE";
            try
            {
                DataTable dtbResult = null;
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                if (lngRes > 0 && dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsApplUserGroupRelation_VO[dtbResult.Rows.Count];
                    for (int i = 0; i < p_objResultArr.Length; i++)
                    {
                        p_objResultArr[i] = new clsApplUserGroupRelation_VO();
                        p_objResultArr[i].strUserGroupID = dtbResult.Rows[i]["USER_GROUP_ID_CHR"].ToString().Trim();
                        p_objResultArr[i].strChildUserGroupID = dtbResult.Rows[i]["CHILD_USER_GROUP_ID_CHR"].ToString().Trim();
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 查询一个自定义组下(不含自定义组)的所有检验项目明细
        [AutoComplete]
        public long m_lngGetCheckItemInApplGroupDetailByApplUserGroupID(System.Security.Principal.IPrincipal p_objPrincipal, string strApplUserGroupID, out DataTable dtbCheckItem)
        {
            long lngRes = 0;
            dtbCheckItem = null;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsAppGroupSvc", "m_lngGetCheckItemInApplGroupDetailByApplUserGroupID");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"SELECT t4.*
								FROM t_aid_lis_appuser_group t1,
									 t_aid_lis_appuser_group_detail t2,
									 t_aid_lis_apply_unit_detail t3,
									 t_bse_lis_check_item t4
							   WHERE t1.user_group_id_chr = t2.user_group_id_chr
								 AND t2.apply_unit_id_chr = t3.apply_unit_id_chr
								 AND t3.check_item_id_chr = t4.check_item_id_chr
								 AND t1.user_group_id_chr = '" + strApplUserGroupID + "'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbCheckItem);
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

        #region 查询一个自定义组下(含自定义组)的所有检验项目明细
        [AutoComplete]
        public long m_lngGetCheckItemApplGroupRelationByApplUserGroupID(System.Security.Principal.IPrincipal p_objPrincipal, string strApplUserGroupID, out DataTable dtbCheckItem)
        {
            long lngRes = 0;
            dtbCheckItem = null;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsAppGroupSvc", "m_lngGetCheckItemApplGroupRelationByApplUserGroupID");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"SELECT t4.*
								FROM t_aid_lis_appuser_group t1,
									 t_aid_lis_appuser_group_detail t2,
									 t_aid_lis_apply_unit_detail t3,
									 t_bse_lis_check_item t4
							   WHERE t1.user_group_id_chr = t2.user_group_id_chr
								 AND t2.apply_unit_id_chr = t3.apply_unit_id_chr
								 AND t3.check_item_id_chr = t4.check_item_id_chr
								 AND t1.user_group_id_chr IN (
													  SELECT     t2.child_user_group_id_chr
														FROM t_aid_lis_appuser_group_relate t2
													  START WITH user_group_id_chr = '" + strApplUserGroupID + @"'
													  CONNECT BY PRIOR child_user_group_id_chr = user_group_id_chr)";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbCheckItem);
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

        #region 更新表t_aid_lis_appluser_group中的字段
        [AutoComplete]
        public long m_lngSetApplUserGroup(System.Security.Principal.IPrincipal p_objPrincipal, ref clsApplUserGroup_VO objApplUserGroupVO)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsAppGroupSvc", "m_lngSetApplUserGroup");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"UPDATE t_aid_lis_appuser_group
								 SET user_group_name_vchr = '" + objApplUserGroupVO.strUserGroupName + @"',
									 has_child_group = '" + objApplUserGroupVO.strHasChildGroup + @"',
									 py_code_chr = '" + objApplUserGroupVO.strPYCode + @"',
									 assist_code01_chr = '" + objApplUserGroupVO.strAssistCode01 + @"',
									 wb_code_chr = '" + objApplUserGroupVO.strWBCode + @"',
									 assist_code02_chr = '" + objApplUserGroupVO.strAssistCode02 + @"',
									 group_flag_chr = '" + objApplUserGroupVO.strGroupFlag + @"',
									 operator_id_chr = '" + objApplUserGroupVO.strOperatorID + @"',
									 summary_vchr = '" + objApplUserGroupVO.strSummary + @"'
							   WHERE user_group_id_chr = '" + objApplUserGroupVO.strUserGroupID + @"'";

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

        #region 删除自定义组合的明细和关系
        [AutoComplete]
        public long m_lngDelApplUserGroupDetailAndRelation(System.Security.Principal.IPrincipal p_objPrincipal, string strApplUserGroupID)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsAppGroupSvc", "m_lngDelApplUserGroupDetailAndRelation");
            if (lngRes < 0)
            {
                return -1;
            }

            lngRes = m_lngDelApplUserGroupRelation(p_objPrincipal, strApplUserGroupID);
            if (lngRes > 0)
            {
                lngRes = m_lngDelApplUserGroupDetail(p_objPrincipal, strApplUserGroupID);
            }
            return lngRes;
        }
        #endregion

        #region 删除自定义组合相关的所有信息
        [AutoComplete]
        public long m_lngDelApplUserGroupInfo(System.Security.Principal.IPrincipal p_objPrincipal, string strApplUserGroupID, string strParentUserGroupID)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsAppGroupSvc", "m_lngDelApplUserGroupInfo");
            if (lngRes < 0)
            {
                return -1;
            }

            lngRes = m_lngDelApplUserGroupRelation(p_objPrincipal, strApplUserGroupID, strParentUserGroupID);
            if (lngRes > 0)
            {
                lngRes = m_lngDelApplUserGroupDetail(p_objPrincipal, strApplUserGroupID);
                if (lngRes > 0)
                {
                    lngRes = m_lngDelApplUserGroup(p_objPrincipal, strApplUserGroupID);
                }
            }
            return lngRes;
        }
        #endregion

        #region 删除表t_aid_lis_appluser_group_relate的自定义组合关系
        [AutoComplete]
        public long m_lngDelApplUserGroupRelation(System.Security.Principal.IPrincipal p_objPrincipal, string strApplUserGroupID, string strParentUserGroupId)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsAppGroupSvc", "m_lngDelApplUserGroupRelation");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"DELETE FROM t_aid_lis_appuser_group_relate WHERE USER_GROUP_ID_CHR = '" + strApplUserGroupID + "' or CHILD_USER_GROUP_ID_CHR = '" + strApplUserGroupID + "' AND USER_GROUP_ID_CHR = '" + strParentUserGroupId + "'";
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
        [AutoComplete]
        public long m_lngDelApplUserGroupRelation(System.Security.Principal.IPrincipal p_objPrincipal, string strApplUserGroupID)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsAppGroupSvc", "m_lngDelApplUserGroupRelation");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"DELETE FROM t_aid_lis_appuser_group_relate WHERE USER_GROUP_ID_CHR = '" + strApplUserGroupID + "'";
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

        #region 删除表t_aid_lis_appluser_group_detail的自定义组合明细
        [AutoComplete]
        public long m_lngDelApplUserGroupDetail(System.Security.Principal.IPrincipal p_objPrincipal, string strApplUserGroupID)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsAppGroupSvc", "m_lngDelApplUserGroupDetail");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"DELETE FROM t_aid_lis_appuser_group_detail WHERE USER_GROUP_ID_CHR = '" + strApplUserGroupID + "'";
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

        #region 删除表t_aid_lis_appluser_group的自定义组合
        [AutoComplete]
        public long m_lngDelApplUserGroup(System.Security.Principal.IPrincipal p_objPrincipal, string strApplUserGroupID)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsAppGroupSvc", "m_lngDelApplUserGroup");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"DELETE FROM t_aid_lis_appuser_group WHERE USER_GROUP_ID_CHR = '" + strApplUserGroupID + "'";
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

        #region 获取所有的自定义组合下的所有申请单元信息
        [AutoComplete]
        public long m_lngGetAllUserGroupApplUnitID(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable dtbApplUnit)
        {
            long lngRes = 0;
            dtbApplUnit = null;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsAppGroupSvc", "m_lngAddApplUserRelation");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"SELECT DISTINCT apply_unit_id_chr FROM t_aid_lis_appuser_group_detail";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbApplUnit);
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

        #region 保存用户自定义申请组合及其明细、关系
        [AutoComplete]
        public long m_lngAddApplUserGroupAndDetail(System.Security.Principal.IPrincipal p_objPrincipal, ref clsApplUserGroup_VO objApplUserGroupVO,
            ref clsApplUserGroupDetail_VO[] objApplUserGroupDetailList, ref clsApplUserGroupRelation_VO[] objApplUserGroupRelation,
            clsApplUserGroupRelation_VO p_objParentRelation)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsAppGroupSvc", "m_lngAddApplUserRelation");
            if (lngRes < 0)
            {
                return -1;
            }

            if (objApplUserGroupVO.strUserGroupID == null)
            {
                lngRes = m_lngAddAppUserGroup(p_objPrincipal, ref objApplUserGroupVO);
            }
            else
            {
                lngRes = m_lngSetApplUserGroup(p_objPrincipal, ref objApplUserGroupVO);
            }

            if (lngRes > 0)
            {
                if (objApplUserGroupDetailList != null)
                {
                    for (int i = 0; i < objApplUserGroupDetailList.Length; i++)
                    {
                        objApplUserGroupDetailList[i].strUserGroupID = objApplUserGroupVO.strUserGroupID;
                        lngRes = m_lngAddApplUserGroupDetail(p_objPrincipal, ref objApplUserGroupDetailList[i]);
                    }
                }
                if (lngRes > 0)
                {
                    if (objApplUserGroupRelation != null)
                    {
                        for (int i = 0; i < objApplUserGroupRelation.Length; i++)
                        {
                            objApplUserGroupRelation[i].strUserGroupID = objApplUserGroupVO.strUserGroupID;
                            lngRes = m_lngAddApplUserRelation(p_objPrincipal, ref objApplUserGroupRelation[i]);
                        }
                    }
                }
                if (lngRes > 0)
                {
                    if (p_objParentRelation != null)
                    {
                        p_objParentRelation.strChildUserGroupID = objApplUserGroupVO.strUserGroupID;
                        lngRes = m_lngAddApplUserRelation(p_objPrincipal, ref p_objParentRelation);
                        if (lngRes > 0)
                        {
                            lngRes = m_lngUpdApplUserGroup(p_objPrincipal, "1", p_objParentRelation.strUserGroupID);
                        }
                    }
                }
            }
            return lngRes;
        }
        #endregion

        #region 保存记录到t_aid_lis_appuser_relate
        [AutoComplete]
        public long m_lngAddApplUserRelation(System.Security.Principal.IPrincipal p_objPrincipal, ref clsApplUserGroupRelation_VO objApplUserGroupRelationVO)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsAppGroupSvc", "m_lngAddApplUserRelation");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"INSERT INTO t_aid_lis_appuser_group_relate
										  (user_group_id_chr, child_user_group_id_chr
										  )
								   VALUES (?, ?)";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] objApplUserGroupRelationArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out objApplUserGroupRelationArr);

                objApplUserGroupRelationArr[0].Value = objApplUserGroupRelationVO.strUserGroupID;
                objApplUserGroupRelationArr[1].Value = objApplUserGroupRelationVO.strChildUserGroupID;

                long lngRecEff = -1;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, objApplUserGroupRelationArr);
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

        #region 保存一条记录到t_aid_lis_appuser_group_detail
        [AutoComplete]
        public long m_lngAddApplUserGroupDetail(System.Security.Principal.IPrincipal p_objPrincipal, ref clsApplUserGroupDetail_VO objApplUserGroupDetailVO)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsAppGroupSvc", "m_lngAddApplUserGroupDetail");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"INSERT INTO t_aid_lis_appuser_group_detail
										  (user_group_id_chr, apply_unit_id_chr
										  )
								   VALUES (?, ?)";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] objApplUserGroupDetailArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out objApplUserGroupDetailArr);

                objApplUserGroupDetailArr[0].Value = objApplUserGroupDetailVO.strUserGroupID;
                objApplUserGroupDetailArr[1].Value = objApplUserGroupDetailVO.strApplUnitID;

                long lngRecEff = -1;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, objApplUserGroupDetailArr);
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

        #region 保存一条记录到t_aid_lis_appuser_group
        [AutoComplete]
        public long m_lngAddAppUserGroup(System.Security.Principal.IPrincipal p_objPrincipal, ref clsApplUserGroup_VO objApplUserGroup)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsAppGroupSvc", "m_lngAddAppUserGroup");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"INSERT INTO t_aid_lis_appuser_group
										  (user_group_id_chr, user_group_name_vchr, has_child_group,
										   py_code_chr, assist_code01_chr, wb_code_chr, assist_code02_chr,
										   group_flag_chr, operator_id_chr,summary_vchr
										   )
								    VALUES (?, ?, ?, ?, ?, ?, ?,  ?, ?,?)";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] objApplUserGroupArr = null;
                objHRPSvc.CreateDatabaseParameter(10, out objApplUserGroupArr);

                if (objApplUserGroup.strUserGroupID == null)
                {
                    objApplUserGroup.strUserGroupID = objHRPSvc.m_strGetNewID("t_aid_lis_appuser_group", "user_group_id_chr", 6);
                }

                objApplUserGroupArr[0].Value = objApplUserGroup.strUserGroupID;
                objApplUserGroupArr[1].Value = objApplUserGroup.strUserGroupName;
                objApplUserGroupArr[2].Value = objApplUserGroup.strHasChildGroup;
                objApplUserGroupArr[3].Value = objApplUserGroup.strPYCode;
                objApplUserGroupArr[4].Value = objApplUserGroup.strAssistCode01;
                objApplUserGroupArr[5].Value = objApplUserGroup.strWBCode;
                objApplUserGroupArr[6].Value = objApplUserGroup.strAssistCode02;
                objApplUserGroupArr[7].Value = objApplUserGroup.strGroupFlag;
                objApplUserGroupArr[8].Value = objApplUserGroup.strOperatorID;

                objApplUserGroupArr[9].Value = objApplUserGroup.strSummary;

                long lngRecEff = -1;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, objApplUserGroupArr);
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

        #region 根据用户自定义组ID查询其包含的申请单元信息
        [AutoComplete]
        public long m_lngGetApplUnitByUserGroupID(System.Security.Principal.IPrincipal p_objPrincipal, string strUserGroupID, out clsApplUnit_VO[] objApplUnitVOList)
        {
            long lngRes = 0;
            objApplUnitVOList = null;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsCheckGroupSvc", "m_lngGetApplUnitByUserGroupID");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"SELECT t2.*
								FROM t_aid_lis_appuser_group_detail t1, t_aid_lis_apply_unit t2
							   WHERE t1.apply_unit_id_chr = t2.apply_unit_id_chr
								 AND t1.user_group_id_chr = '" + strUserGroupID + "'";
            DataTable dtbApplUnit = null;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbApplUnit);
                if (lngRes > 0 && dtbApplUnit != null)
                {
                    if (dtbApplUnit.Rows.Count > 0)
                    {
                        objApplUnitVOList = new clsApplUnit_VO[dtbApplUnit.Rows.Count];
                        for (int i = 0; i < dtbApplUnit.Rows.Count; i++)
                        {
                            objApplUnitVOList[i] = new clsApplUnit_VO();
                            ConstructApplUnitVO(dtbApplUnit.Rows[i], ref objApplUnitVOList[i]);
                        }
                    }
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

        #region 根据用户自定义组ID查询其子组信息
        [AutoComplete]
        public long m_lngGetChildGroupByUserGroupID(System.Security.Principal.IPrincipal p_objPrincipal, string strUserGroupID, out clsApplUserGroup_VO[] objAppUserGroupVOList)
        {
            long lngRes = 0;
            objAppUserGroupVOList = null;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsCheckGroupSvc", "m_lngGetChildGroupByUserGroupID");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"SELECT t1.*
								FROM t_aid_lis_appuser_group t1, t_aid_lis_appuser_group_relate t2
							   WHERE t1.user_group_id_chr = t2.child_user_group_id_chr
								 AND t2.user_group_id_chr = '" + strUserGroupID + "'";
            DataTable dtbAppUser = null;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbAppUser);
                if (lngRes > 0 && dtbAppUser != null)
                {
                    if (dtbAppUser.Rows.Count > 0)
                    {
                        objAppUserGroupVOList = new clsApplUserGroup_VO[dtbAppUser.Rows.Count];
                        for (int i = 0; i < dtbAppUser.Rows.Count; i++)
                        {
                            objAppUserGroupVOList[i] = new clsApplUserGroup_VO();
                            ConstructApplUserGroupVO(dtbAppUser.Rows[i], ref objAppUserGroupVOList[i]);
                        }
                    }
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

            objApplUnitVO.strSummary = objRow["SUMMARY_VCHR"].ToString().Trim();
            objApplUnitVO.strOutCheckFlag = objRow["OUTER_CHECK_FLAG_NUM"].ToString().Trim();
            objApplUnitVO.ReportHour = objRow["REPORTHOUR"] == DBNull.Value ? 0 : Convert.ToDecimal(objRow["REPORTHOUR"].ToString());
            objApplUnitVO.SamplingInstr = objRow["SamplingInstr"].ToString();
        }
        #endregion

        #region 构造clsApplUserGroup_VO 
        [AutoComplete]
        private void ConstructApplUserGroupVO(System.Data.DataRow objRow, ref clsApplUserGroup_VO objApplUserGroupVO)
        {
            objApplUserGroupVO.strUserGroupID = objRow["USER_GROUP_ID_CHR"].ToString().Trim();
            objApplUserGroupVO.strUserGroupName = objRow["USER_GROUP_NAME_VCHR"].ToString().Trim();
            objApplUserGroupVO.strHasChildGroup = objRow["HAS_CHILD_GROUP"].ToString().Trim();
            objApplUserGroupVO.strPYCode = objRow["PY_CODE_CHR"].ToString().Trim();
            objApplUserGroupVO.strWBCode = objRow["WB_CODE_CHR"].ToString().Trim();
            objApplUserGroupVO.strAssistCode01 = objRow["ASSIST_CODE01_CHR"].ToString().Trim();
            objApplUserGroupVO.strAssistCode02 = objRow["ASSIST_CODE02_CHR"].ToString().Trim();
            objApplUserGroupVO.strGroupFlag = objRow["GROUP_FLAG_CHR"].ToString().Trim();
            objApplUserGroupVO.strOperatorID = objRow["OPERATOR_ID_CHR"].ToString().Trim();

            objApplUserGroupVO.strSummary = objRow["SUMMARY_VCHR"].ToString().Trim();
        }
        #endregion
    }
}
