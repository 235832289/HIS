using System;
using System.Data;
using System.EnterpriseServices;
using com.digitalwave.Utility; //Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll

namespace com.digitalwave.iCare.middletier.LIS
{
    [Transaction(TransactionOption.Supported)]
    [ObjectPooling(Enabled = true)]
    public class clsQueryInputGroupSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase//MiddleTierBase.dll
    {
        #region 构造函数
        public clsQueryInputGroupSvc()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        #endregion

        #region 获取筛选后的项目列表
        [AutoComplete]
        public long m_lngGetFiltedItems(System.Security.Principal.IPrincipal p_objPrincipal,
            string[] p_strApplyUnitIDArr, string[] p_strInputGroupIDArr, out string[] p_strItemResultArr)
        {
            long lngRes = 0;
            p_strItemResultArr = null;
            if (p_strApplyUnitIDArr == null || p_strInputGroupIDArr == null)
                return -1;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,
                "com.digitalwave.iCare.middletier.LIS.clsInputGroupSvc", "m_lngGetFiltedItems");
            if (lngRes < 0)
            {
                return -1;
            }


            string strSQL1 = @"SELECT a.check_item_id_chr
   FROM t_aid_lis_apply_unit_detail a
  WHERE a.apply_unit_id_chr IN ('3333'*)";
            string strSQL2 = @"SELECT b.check_item_id_chr
   FROM t_bse_lis_input_group_detail b
  WHERE b.input_group_id_chr IN ('333'#)";

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            IDataParameter[] objParamArr1 = null;
            objHRPSvc.CreateDatabaseParameter(p_strApplyUnitIDArr.Length, out objParamArr1);
            IDataParameter[] objParamArr2 = null;
            objHRPSvc.CreateDatabaseParameter(p_strInputGroupIDArr.Length, out objParamArr2);

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < p_strApplyUnitIDArr.Length; i++)
            {
                sb.Append(",?");
                objParamArr1[i].Value = p_strApplyUnitIDArr[i];
            }
            strSQL1 = strSQL1.Replace("*", sb.ToString());

            sb = new System.Text.StringBuilder();
            for (int j = 0; j < p_strInputGroupIDArr.Length; j++)
            {
                sb.Append(",?");
                objParamArr2[j].Value = p_strInputGroupIDArr[j];
            }
            strSQL2 = strSQL2.Replace("#", sb.ToString());

            DataTable dtbUnitItem = new DataTable();
            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL1, ref dtbUnitItem, objParamArr1);
                if (lngRes > 0)
                {
                    DataTable dtbGroupItem = new DataTable();
                    lngRes = 0;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL2, ref dtbGroupItem, objParamArr2);
                    if (lngRes > 0)
                    {
                        System.Collections.ArrayList arlItem = new System.Collections.ArrayList();
                        if (dtbUnitItem != null)
                        {
                            foreach (DataRow dtr in dtbUnitItem.Rows)
                            {
                                arlItem.Add(dtr[0].ToString());
                            }
                        }
                        if (dtbGroupItem != null)
                        {
                            foreach (DataRow dtr in dtbGroupItem.Rows)
                            {
                                arlItem.Add(dtr[0].ToString());
                            }
                        }
                        p_strItemResultArr = (string[])arlItem.ToArray(typeof(string));
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。
                lngRes = 0;
            }
            return lngRes;
        }
        #endregion

        #region 获取指定申请单元及其名称列表
        [AutoComplete]
        public long m_lngGetApplyUnitInfo(System.Security.Principal.IPrincipal p_objPrincipal,
            string[] p_strApplyUnitIDArr, out DataTable p_dtbResult)
        {
            long lngRes = 0;
            p_dtbResult = new DataTable();
            if (p_strApplyUnitIDArr == null)
            {
                return -1;
            }
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,
                "com.digitalwave.iCare.middletier.LIS.clsInputGroupSvc", "m_lngGetApplyUnitInfo");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"SELECT a.apply_unit_id_chr, a.apply_unit_name_vchr,
       'nullvalue' input_group_id_chr
  FROM t_aid_lis_apply_unit a
 WHERE a.apply_unit_id_chr IN ('_'*)
";


            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            IDataParameter[] objParamArr = null;
            objHRPSvc.CreateDatabaseParameter(p_strApplyUnitIDArr.Length, out objParamArr);

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < p_strApplyUnitIDArr.Length; i++)
            {
                sb.Append(",?");
                objParamArr[i].Value = p_strApplyUnitIDArr[i];
            }
            strSQL = strSQL.Replace("*", sb.ToString());

            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtbResult, objParamArr);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。
                lngRes = 0;
            }
            return lngRes;
        }
        #endregion

        #region 获取指定申请单元下可用的录入组合
        [AutoComplete]
        public long m_lngGetInputGroupsByUnit(System.Security.Principal.IPrincipal p_objPrincipal,
            string[] p_strApplyUnitIDArr, out DataTable p_dtbResult)
        {
            long lngRes = 0;
            p_dtbResult = new DataTable();
            if (p_strApplyUnitIDArr == null || p_strApplyUnitIDArr.Length == 0)
            {
                return -1;
            }

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,
                "com.digitalwave.iCare.middletier.LIS.clsInputGroupSvc", "m_lngGetInputGroupsByUnit");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"SELECT a.apply_unit_id_chr, a.input_group_id_chr, a.input_group_name_vchr
  FROM t_bse_lis_input_group a
 WHERE a.inuseflag_num = 1 AND a.apply_unit_id_chr IN ('___'*)";


            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            IDataParameter[] objParamArr = null;
            objHRPSvc.CreateDatabaseParameter(p_strApplyUnitIDArr.Length, out objParamArr);

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < p_strApplyUnitIDArr.Length; i++)
            {
                sb.Append(",?");
                objParamArr[i].Value = p_strApplyUnitIDArr[i];
            }
            strSQL = strSQL.Replace("*", sb.ToString());

            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtbResult, objParamArr);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。
                lngRes = 0;
            }
            return lngRes;
        }
        #endregion

        #region 获取检验分类-申请单元-录入组合的的联合信息
        [AutoComplete]
        public long m_lngGetUnitedInputGroupInfo(System.Security.Principal.IPrincipal p_objPrincipal, out clsInputGroupUnited_VO[] p_objResults)
        {
            long lngRes = 0;
            p_objResults = null;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsInputGroupSvc", "m_lngGetUnitedInputGroupInfo");
            if (lngRes < 0)
            {
                return -1;
            }

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            string strSQL = @"SELECT c.check_category_id_chr, c.check_category_desc_vchr,
                                   b.apply_unit_id_chr, b.apply_unit_name_vchr, a.input_group_id_chr,
                                   a.input_group_name_vchr, a.inuseflag_num
                              FROM t_bse_lis_input_group a,
                                   t_aid_lis_apply_unit b,
                                   t_bse_lis_check_category c
                             WHERE a.apply_unit_id_chr(+) = b.apply_unit_id_chr
                               AND b.check_category_id_chr = c.check_category_id_chr";
            DataTable tableResult = new DataTable();
            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref tableResult);
                if (lngRes > 0 && tableResult != null)
                {
                    p_objResults = new clsInputGroupUnited_VO[tableResult.Rows.Count];
                    for (int i = 0; i < p_objResults.Length; i++)
                    {
                        p_objResults[i] = new clsInputGroupUnited_VO();
                        ConstructUnitVO(tableResult.Rows[i], p_objResults[i]);
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。
                lngRes = 0;
            }
            return lngRes;
        }
        #endregion

        #region 获取申请单元项目明细
        [AutoComplete]
        public long m_lngGetApplyUnitItems(System.Security.Principal.IPrincipal p_objPrincipal, string p_strApplyUnitID, out clsCheckItemSimple_VO[] p_objResults)
        {
            long lngRes = 0;
            p_objResults = null;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsInputGroupSvc", "m_lngGetApplyUnitItems");
            if (lngRes < 0)
            {
                return -1;
            }

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            string strSQL = @"SELECT a.apply_unit_id_chr, b.check_item_id_chr, b.check_item_name_vchr
  FROM t_aid_lis_apply_unit_detail a, t_bse_lis_check_item b
 WHERE a.check_item_id_chr = b.check_item_id_chr AND a.apply_unit_id_chr = ?";
            DataTable tableResult = new DataTable();
            try
            {
                IDataParameter[] objParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objParamArr);
                objParamArr[0].Value = p_strApplyUnitID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref tableResult, objParamArr);
                if (lngRes > 0 && tableResult != null)
                {
                    p_objResults = new clsCheckItemSimple_VO[tableResult.Rows.Count];
                    for (int i = 0; i < p_objResults.Length; i++)
                    {
                        p_objResults[i] = new clsCheckItemSimple_VO();
                        ConstructCheckItemSimpleVO(tableResult.Rows[i], p_objResults[i]);
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。
                lngRes = 0;
            }
            return lngRes;
        }
        #endregion

        #region 获取录入组合及明细
        [AutoComplete]
        public long m_lngGetInputGroupInfo(System.Security.Principal.IPrincipal p_objPrincipal,
            string p_strInputGroupID, out clsInputGroupBaseInfo_VO p_objBaseInfo, out clsInputGroupDetail_VO[] p_objResults)
        {
            long lngRes = 0;
            p_objResults = null;
            p_objBaseInfo = null;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsInputGroupSvc", "m_lngGetInputGroupInfo");
            if (lngRes < 0)
            {
                return -1;
            }

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            string strSQL1 = @"SELECT *
  FROM t_bse_lis_input_group a
 WHERE a.input_group_id_chr = ?";
            string strSQL2 = @"SELECT   a.*, b.check_item_name_vchr
    FROM t_bse_lis_input_group_detail a, t_bse_lis_check_item b
   WHERE a.check_item_id_chr = b.check_item_id_chr
     AND a.input_group_id_chr = ? 
ORDER BY a.sequence_num";
            DataTable tableResult = new DataTable();
            try
            {
                IDataParameter[] objParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objParamArr);
                objParamArr[0].Value = p_strInputGroupID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL1, ref tableResult, objParamArr);
                if (lngRes > 0 && tableResult != null && tableResult.Rows.Count > 0)
                {
                    p_objBaseInfo = new clsInputGroupBaseInfo_VO();
                    ConstructInputGroupBaseInfoVO(tableResult.Rows[0], p_objBaseInfo);

                    objHRPSvc.CreateDatabaseParameter(1, out objParamArr);
                    objParamArr[0].Value = p_strInputGroupID;

                    lngRes = 0;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL2, ref tableResult, objParamArr);
                    if (lngRes > 0 && tableResult != null)
                    {
                        p_objResults = new clsInputGroupDetail_VO[tableResult.Rows.Count];
                        for (int i = 0; i < p_objResults.Length; i++)
                        {
                            p_objResults[i] = new clsInputGroupDetail_VO();
                            ConstructInputGroupDetailVO(tableResult.Rows[i], p_objResults[i]);
                        }
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。
                lngRes = 0;
            }
            return lngRes;
        }
        #endregion

        [AutoComplete]
        private void ConstructUnitVO(DataRow dtr, clsInputGroupUnited_VO vo)
        {
            if (dtr != null && vo != null)
            {
                try
                {
                    vo.m_intINUSEFLAG_NUM = int.Parse(dtr["inuseflag_num"].ToString());
                }
                catch { }
                vo.m_strAPPLY_UNIT_ID_CHR = dtr["apply_unit_id_chr"].ToString();
                vo.m_strAPPLY_UNIT_NAME_VCHR = dtr["apply_unit_name_vchr"].ToString();
                vo.m_strCHECK_CATEGORY_ID_CHR = dtr["check_category_id_chr"].ToString();
                vo.m_strCHECK_CATEGORY_NAME_CHR = dtr["check_category_desc_vchr"].ToString();
                vo.m_strINPUT_GROUP_ID_CHR = dtr["input_group_id_chr"].ToString();
                vo.m_strINPUT_GROUP_NAME_VCHR = dtr["input_group_name_vchr"].ToString();
            }
        }
        [AutoComplete]
        private void ConstructCheckItemSimpleVO(DataRow dtr, clsCheckItemSimple_VO vo)
        {
            if (dtr != null && vo != null)
            {
                vo.m_strAPPLY_UNIT_ID_CHR = dtr["apply_unit_id_chr"].ToString();
                vo.m_strCHECK_ITEM_ID_CHR = dtr["check_item_id_chr"].ToString();
                vo.m_strCHECK_ITEM_NAME_CHR = dtr["check_item_name_vchr"].ToString();
            }
        }
        [AutoComplete]
        private void ConstructInputGroupBaseInfoVO(DataRow dtr, clsInputGroupBaseInfo_VO vo)
        {
            if (dtr != null && vo != null)
            {
                try
                {
                    vo.m_intINUSEFLAG_NUM = int.Parse(dtr["INUSEFLAG_NUM"].ToString());
                }
                catch { }
                try
                {
                    vo.m_intSEQUENCE_NUM = int.Parse(dtr["SEQUENCE_NUM"].ToString());
                }
                catch { }

                vo.m_strAPPLY_UNIT_ID_CHR = dtr["APPLY_UNIT_ID_CHR"].ToString();
                vo.m_strASCODE_VCHR = dtr["ASCODE_VCHR"].ToString();
                vo.m_strINPUT_GROUP_ID_CHR = dtr["INPUT_GROUP_ID_CHR"].ToString();
                vo.m_strINPUT_GROUP_NAME_VCHR = dtr["INPUT_GROUP_NAME_VCHR"].ToString();
                vo.m_strPYCODE_VCHR = dtr["PYCODE_VCHR"].ToString();
                vo.m_strSUMMARY_VCHR = dtr["SUMMARY_VCHR"].ToString();
                vo.m_strWBCODE_VCHR = dtr["WBCODE_VCHR"].ToString();
            }
        }
        [AutoComplete]
        private void ConstructInputGroupDetailVO(DataRow dtr, clsInputGroupDetail_VO vo)
        {
            if (dtr != null && vo != null)
            {
                try
                {
                    vo.m_intSEQUENCE_NUM = int.Parse(dtr["SEQUENCE_NUM"].ToString());
                }
                catch { }
                vo.m_strCHECK_ITEM_ID_CHR = dtr["CHECK_ITEM_ID_CHR"].ToString();
                vo.m_strCHECK_ITEM_NAME_CHR = dtr["CHECK_ITEM_NAME_VCHR"].ToString();
                vo.m_strINPUT_GROUP_ID_CHR = dtr["INPUT_GROUP_ID_CHR"].ToString();
            }
        }

    }
}
