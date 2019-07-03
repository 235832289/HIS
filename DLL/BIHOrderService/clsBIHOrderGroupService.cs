using System;
using System.Data;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.ValueObject;
using System.EnterpriseServices;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
using System.Collections;

namespace com.digitalwave.iCare.middletier.BIHOrderServer
{
    /// <summary>
    /// 医嘱执行-组套相关
    /// 修改人：徐斌辉	2004-12-16
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsBIHOrderGroupService : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 获取组套VO对象
        /// <summary>
        /// 获取关联组套	根据诊疗项目ID
        /// </summary>
        /// <param name="strOrderDicID">主诊疗项目ID</param>
        /// <param name="arrOrder">医嘱组套Vo类 [out 参数]</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetGroupByDicID(string strMainOrderDicID, out clsBIHOrderGroup[] arrGroup)
        {
            arrGroup = null;
            string strSql = @"
				select a.groupid_chr, a.name_chr, a.des_vchr, a.creatorid_chr, a.createdate_dat, a.sharetype_int, a.wbcode_chr, a.pycode_chr, a.issamerecipeno_int, a.usercode_vchr, a.areaid_vchr 
				from t_aid_bih_ordergroup a,
				(
				select distinct   groupid_chr
				from t_aid_bih_ordergroup_detail
				where orderdicid_chr='[MainOrderDicID]' and ifparentid_int=1
				) b
				where a.groupid_chr=b.groupid_chr
				";

            strSql = strSql.Replace("[MainOrderDicID]", strMainOrderDicID);

            DataTable objDT = new DataTable();
            long ret = 0;
            try
            {
                ret = new clsHRPTableService().DoGetDataTable(strSql, ref objDT);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if ((ret > 0) && (objDT != null))
            {
                arrGroup = new clsBIHOrderGroup[objDT.Rows.Count];
                for (int i = 0; i < arrGroup.Length; i++)
                {
                    clsBIHOrderGroup objGroup = new clsBIHOrderGroup();
                    m_mthGetBihGroupFromDataRow(objDT.Rows[i], ref objGroup);

                    arrGroup[i] = objGroup;

                }
                return 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 获取组套	根据DataTable行
        /// </summary>
        /// <param name="objRow">DataRow对象</param>
        /// <param name="objGroup">医嘱组套Vo类 [ref 参数]</param>
        [AutoComplete]
        private void m_mthGetBihGroupFromDataRow(DataRow objRow, ref clsBIHOrderGroup objGroup)
        {
            if (objRow == null)
            {
                objGroup = null;
                return;
            }
            if (objGroup == null) objGroup = new clsBIHOrderGroup();

            objGroup.m_strGroupID = clsConverter.ToString(objRow["GroupID_Chr"]).Trim();
            objGroup.m_strName = clsConverter.ToString(objRow["Name_Chr"]).Trim();
            objGroup.m_strDes = clsConverter.ToString(objRow["Des_VChr"]).Trim();
            objGroup.m_strCreatorID = clsConverter.ToString(objRow["CreatorID_Chr"]).Trim();
            objGroup.m_dtCreate = clsConverter.ToDateTime(objRow["CreateDate_Dat"]);
            objGroup.m_intShareType = clsConverter.ToInt(objRow["ShareType_Int"]);
            objGroup.m_strWBCode = clsConverter.ToString(objRow["WBCode_Chr"]).Trim();
            objGroup.m_strPYCode = clsConverter.ToString(objRow["PYCode_Chr"]).Trim();
            objGroup.m_intISSAMERECIPENO_INT = clsConverter.ToInt(objRow["ISSAMERECIPENO_INT"].ToString().Trim());
            objGroup.m_strUSERCODE_VCHR = clsConverter.ToString(objRow["USERCODE_VCHR"].ToString().Trim());
            objGroup.m_strAREAID_VCHR = clsConverter.ToString(objRow["AREAID_VCHR"].ToString().Trim());
        }


        /// <summary>
        /// 获取组套	根据DataTable行
        /// </summary>
        /// <param name="objRow">DataRow对象</param>
        /// <param name="objGroup">医嘱组套Vo类 [ref 参数]</param>
        [AutoComplete]
        private void m_mthGetBihGroupFromDataRow(DataRow objRow, ref clsT_aid_bih_ordergroup_VO objGroup)
        {
            if (objRow == null)
            {
                objGroup = null;
                return;
            }
            if (objGroup == null) objGroup = new clsT_aid_bih_ordergroup_VO();

            objGroup.m_strGROUPID_CHR = clsConverter.ToString(objRow["GroupID_Chr"]).Trim();
            objGroup.m_strNAME_CHR = clsConverter.ToString(objRow["Name_Chr"]).Trim();
            objGroup.m_strDES_VCHR = clsConverter.ToString(objRow["Des_VChr"]).Trim();
            objGroup.m_strCREATORID_CHR = clsConverter.ToString(objRow["CreatorID_Chr"]).Trim();
            objGroup.m_strCREATEDATE_DAT = clsConverter.ToString(objRow["CreateDate_Dat"]);
            objGroup.m_intSHARETYPE_INT = clsConverter.ToInt(objRow["ShareType_Int"]);
            objGroup.m_strWBCODE_CHR = clsConverter.ToString(objRow["WBCode_Chr"]).Trim();
            objGroup.m_strPYCODE_CHR = clsConverter.ToString(objRow["PYCode_Chr"]).Trim();
            objGroup.m_intISSAMERECIPENO_INT = clsConverter.ToInt(objRow["ISSAMERECIPENO_INT"].ToString().Trim());
            objGroup.m_strUSERCODE_VCHR = clsConverter.ToString(objRow["USERCODE_VCHR"].ToString().Trim());
            objGroup.m_strAREAID_VCHR = clsConverter.ToString(objRow["AREAID_VCHR"].ToString().Trim());
            objGroup.m_strCreatorName = clsConverter.ToString(objRow["lastname_vchr"].ToString().Trim());
        }

        #endregion
        #region 查询组套
        /// <summary>
        /// 查询组套
        /// </summary>
        /// <param name="strFindString">查询字符串</param>
        /// <param name="strEmpID">用户ID</param>
        /// <param name="strDeptID">科室ID</param>
        /// <param name="arrGroup"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFindGroup(string p_strFindString, string strEmpID, string strDeptID, int m_intClass, out clsBIHOrderGroup[] arrGroup)
        {

            /* @update by xzf (05-11-04) 
             * 将共享类型改为{私有/公用}
             */
            /* @remark--------------------------------------------------------------------------
//			string strSql=@"
//				select * 
//				from T_AID_BIH_OrderGroup
//				where 
//				( ((ShareType_Int=1) and (CreatorID_Chr='[EmpID]')) or ((ShareType_Int=2) and (CreatorID_Chr='[DeptID]')) or (ShareType_Int=3) )
//				[FindCondition]				
//			";
            string strSql=@"SELECT *
  FROM t_aid_bih_ordergroup
 WHERE (   ((sharetype_int = 1) AND (creatorid_chr = '[EmpID]'))
        OR (sharetype_int = 3)
       )
   AND (   (UPPER (TRIM (wbcode_chr)) LIKE '[FindCondition]%')
        OR (UPPER (TRIM (pycode_chr)) LIKE '[FindCondition]%')
        OR (UPPER (TRIM (name_chr)) LIKE '%[FindCondition]%')
       )
UNION
SELECT a.*
  FROM t_aid_bih_ordergroup a,
       t_aid_bih_ordergroupdepartment b,
       t_bse_deptemp c
 WHERE a.groupid_chr = b.groupid_chr
   AND b.deptid_chr = c.deptid_chr
   AND c.empid_chr = '[EmpID]'
   AND a.sharetype_int = 2
   AND (   (UPPER (TRIM (a.wbcode_chr)) LIKE '[FindCondition]%')
        OR (UPPER (TRIM (a.pycode_chr)) LIKE '[FindCondition]%')
        OR (UPPER (TRIM (a.name_chr)) LIKE '%[FindCondition]%')
       )";
//			string strFind =" and (( UPPER(Trim(WBCode_Chr)) like '" + strFindString.Trim().ToUpper() + "%') or ( UPPER(Trim(PYCode_Chr)) like '" + strFindString.Trim().ToUpper() + "%') or ( UPPER(Trim(Name_Chr)) like '%" + strFindString.Trim().ToUpper() + "%')) " ;
            strSql=strSql.Replace("[FindCondition]",strFindString);
            -------------------------------------------------------- */

            /*
            string strSql=@"
                select * 
                from T_AID_BIH_OrderGroup
                where 
                ( ((ShareType_Int=1) and (CreatorID_Chr='[EmpID]')) or (ShareType_Int=2) )
                [FindCondition]				
            ";

            string strFind =" and (( UPPER(Trim(WBCode_Chr)) like '" + strFindString.Trim().ToUpper() + "%') or ( UPPER(Trim(PYCode_Chr)) like '" + strFindString.Trim().ToUpper() + "%') or ( UPPER(Trim(Name_Chr)) like '%" + strFindString.Trim().ToUpper() + "%')) " ;
            strSql=strSql.Replace("[FindCondition]",strFind);
			
            strSql=strSql.Replace("[EmpID]",strEmpID);
            strSql=strSql.Replace("[DeptID]",strDeptID);

            DataTable objDT=new DataTable();
            long ret =0;
            try
            {
                ret=new clsHRPTableService().DoGetDataTable(strSql,ref objDT);
            }
            catch(Exception objEx)
            {
                string strTmp=objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
             */
            string strSql = @"
			   select * from ( 
                select 
                    a.groupid_chr,a.name_chr,a.des_vchr,a.creatorid_chr,a.createdate_dat,
                    a.sharetype_int,a.wbcode_chr,a.pycode_chr,a.issamerecipeno_int,a.usercode_vchr,a.areaid_vchr
				from T_AID_BIH_OrderGroup a
				where 
				( ((ShareType_Int=1) and (CreatorID_Chr=?)) or (ShareType_Int=2) )
				[FindItem]
                union
                select a.groupid_chr,a.name_chr,a.des_vchr,a.creatorid_chr,a.createdate_dat,
                       a.sharetype_int,a.wbcode_chr,a.pycode_chr,a.issamerecipeno_int,a.usercode_vchr,a.areaid_vchr
				from T_AID_BIH_OrderGroup a
				where 
				ShareType_Int=3
                [FindItem]
              ) order by usercode_vchr
				
			";


            string strFind = "";
            string strCode1 = "";
            string strCode2 = "";

            switch (m_intClass)
            {
                case -1:
                    strFind = " and (LOWER(USERCODE_VCHR) like ? or LOWER(PYCode_Chr) like ?) ";
                    strCode1 = p_strFindString.ToLower() + "%";
                    strCode2 = p_strFindString.ToLower() + "%";
                    break;
                case 0:
                    strFind = " and (LOWER(USERCODE_VCHR) like ? or LOWER(PYCode_Chr) like ?) ";
                    strCode1 = p_strFindString.ToLower() + "%";
                    strCode2 = p_strFindString.ToLower() + "%";
                    break;
                case 1:
                    strFind = " and (LOWER(USERCODE_VCHR) like ? or LOWER(WBCode_Chr) like ?) ";
                    strCode1 = p_strFindString.ToLower() + "%";
                    strCode2 = p_strFindString.ToLower() + "%";
                    break;
                case 2:
                    strFind = " and (LOWER(USERCODE_VCHR) like ? or LOWER(Name_Chr) like ?) ";
                    strCode1 = p_strFindString.ToLower() + "%";
                    strCode2 = "%" + p_strFindString.ToLower() + "%";
                    break;
                case 3:
                    strFind = " and (LOWER(USERCODE_VCHR) like ? or LOWER(USERCODE_VCHR) like ?) ";
                    strCode1 = p_strFindString.ToLower() + "%";
                    strCode2 = p_strFindString.ToLower() + "%";
                    break;
                default://混合查
                    strFind = " and (LOWER(USERCODE_VCHR) like ? or LOWER(PYCode_Chr) like ? or LOWER(WBCode_Chr) like ? or LOWER(Name_Chr) like ? ) ";
                    strCode1 = p_strFindString.ToLower() + "%";
                    strCode2 = "%" + p_strFindString.ToLower() + "%";
                    break;
            }

            strSql = strSql.Replace("[FindItem]", strFind);
            // strSql = strSql.Replace("[strEmpid_chr]", strEmpid_chr);


            System.Data.IDataParameter[] arrParams = null;
            if (m_intClass < 4)
            {
                new clsHRPTableService().CreateDatabaseParameter(5, out arrParams);
                arrParams[0].Value = strEmpID;
                arrParams[1].Value = strCode1;
                arrParams[2].Value = strCode2;
                arrParams[3].Value = strCode1;
                arrParams[4].Value = strCode2;
            }
            else
            {
                new clsHRPTableService().CreateDatabaseParameter(9, out arrParams);
                arrParams[0].Value = strEmpID;
                arrParams[1].Value = strCode1;
                arrParams[2].Value = strCode1;
                arrParams[3].Value = strCode1;
                arrParams[4].Value = strCode2;

                arrParams[5].Value = strCode1;
                arrParams[6].Value = strCode1;
                arrParams[7].Value = strCode1;
                arrParams[8].Value = strCode2;
            }
            DataTable objDT = new DataTable();
            long ret = 0;
            try
            {
                ret = 0;
                // ret = new clsHRPTableService().DoGetDataTable(strSql, ref objDT);
                ret = new clsHRPTableService().lngGetDataTableWithParameters(strSql, ref objDT, arrParams);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            /* <<============================================================== */
            if (ret > 0)
            {
                //arrGroup=new clsBIHOrderGroup[objDT.Rows.Count];
                System.Collections.ArrayList m_ArrList = new System.Collections.ArrayList();
                string[] m_arrArea = null;
                for (int i = 0; i < objDT.Rows.Count; i++)
                {
                    clsBIHOrderGroup objGroup = new clsBIHOrderGroup();
                    m_mthGetBihGroupFromDataRow(objDT.Rows[i], ref objGroup);
                    if (objGroup.m_intShareType == 3)
                    {
                        m_arrArea = objGroup.m_strAREAID_VCHR.Split(",".ToCharArray());
                        for (int j = 0; j < m_arrArea.Length; j++)
                        {
                            if (m_arrArea[j].ToString().Trim().Equals(strDeptID.Trim()))
                            {
                                m_ArrList.Add(objGroup);
                                break;
                            }
                        }
                    }
                    else
                    {
                        m_ArrList.Add(objGroup);
                    }
                }
                arrGroup = new clsBIHOrderGroup[m_ArrList.Count];
                for (int i = 0; i < m_ArrList.Count; i++)
                {
                    arrGroup[i] = (clsBIHOrderGroup)m_ArrList[i];
                }
                return 1;
            }
            else
            {
                arrGroup = null;
                return 0;
            }
        }

        #endregion

        #region 查询组套
        /// <summary>
        /// 查询组套
        /// </summary>
        /// <param name="p_strFindString">查询字符串</param>
        /// <param name="strEmpID">用户ID</param>
        /// <param name="strDeptID">科室ID</param>
        /// <param name="m_intClass">查询条件</param>
        /// <param name="arrGroup">组套对象数组</param>
        /// <param name="m_dtGroupDetail">组套明细表 </param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFindGroupAndDetail(string p_strFindString, string strEmpID, string strDeptID, int m_intClass, out clsT_aid_bih_ordergroup_VO[] arrGroup, out DataTable m_dtGroupDetail)
        {
            arrGroup = new clsT_aid_bih_ordergroup_VO[0];
            m_dtGroupDetail = new DataTable();
            string strSql = @"
              select groupid_chr, name_chr, des_vchr, creatorid_chr, createdate_dat, sharetype_int, wbcode_chr,
                     pycode_chr, issamerecipeno_int, usercode_vchr, areaid_vchr, lastname_vchr
                from (  select a.groupid_chr,a.name_chr,a.des_vchr,a.creatorid_chr,a.createdate_dat,
                       a.sharetype_int,a.wbcode_chr,a.pycode_chr,a.issamerecipeno_int,a.usercode_vchr,a.areaid_vchr
                       ,b.lastname_vchr 
				from T_AID_BIH_OrderGroup a,t_bse_employee b
				where 
                  a.creatorid_chr=b.empid_chr(+) and
				 ((ShareType_Int=1) and (CreatorID_Chr=?))
				and (LOWER(USERCODE_VCHR) like ? or [FindItem] )	
              union
                  select a.groupid_chr,a.name_chr,a.des_vchr,a.creatorid_chr,a.createdate_dat,
                       a.sharetype_int,a.wbcode_chr,a.pycode_chr,a.issamerecipeno_int,a.usercode_vchr,a.areaid_vchr
                       ,b.lastname_vchr 
				from T_AID_BIH_OrderGroup a,t_bse_employee b
				where 
                 a.creatorid_chr=b.empid_chr(+) and
				exists (select A.deptid_chr from T_Sys_Role A,t_sys_emprolemap B 
                        where A.roleid_chr=B.roleid_chr(+) AND A.name_vchr=? AND B.empid_chr=?)
                and (LOWER(USERCODE_VCHR) like ? or [FindItem] )
              ) order by USERCODE_VCHR 
                ";

            string strSql2 = @"SELECT b.detailid_chr, b.groupid_chr, b.orderdicid_chr, b.freqid_chr,
       b.dosage_dec, b.dosageunit_chr, b.use_dec, b.useunit_chr, b.get_dec,
       b.getunit_chr, b.dosetype_chr, b.entrust_vchr, b.isrich_int,
       b.parentid_chr, b.ifparentid_int, b.executetype_int,
       b.outgetmeddays_int, b.attachtimes_int, b.sampleid_vchr, b.partid_vchr,
       b.recipeno_int, b.ratetype_int, b.isneedfeel, b.name_vchr,
       b.singleamount_dec, 
       c.freqname_chr, d.usagename_vchr, e.sample_type_desc_vchr,f.partname
       ,j.itemspec_vchr,k.typename_vchr,m.ordercateid_chr,m.viewname_vchr,h.name_chr OrderdicName,
       h.status_int stopstatus, g.ipnoqtyflag_int,ITEMSRCTYPE_INT
  FROM t_aid_bih_ordergroup a,
       t_aid_bih_ordergroup_detail b,
       t_aid_recipefreq c,
       t_bse_usagetype d,
       t_aid_lis_sampletype e,
       ar_apply_partlist f,
       t_bse_medicine g,
       t_bse_bih_orderdic h,
       t_bse_chargeitem j,
       T_AID_MEDICARETYPE k,
       t_aid_bih_ordercate m
 WHERE a.groupid_chr = b.groupid_chr(+)
   AND b.orderdicid_chr = h.orderdicid_chr(+)
   AND h.ordercateid_chr=m.ordercateid_chr(+)
   AND h.itemid_chr = j.itemid_chr(+)
   AND j.insurancetype_vchr=k.typeid_chr(+)
   AND b.freqid_chr = c.freqid_chr(+)
   and j.itemsrcid_vchr = g.medicineid_chr(+)
   AND b.dosetype_chr = d.usageid_chr(+)
   AND b.sampleid_vchr = e.sample_type_id_chr(+)
   AND b.partid_vchr = f.partid(+)
				and
				((ShareType_Int=1) and (CreatorID_Chr= ?)) 
				and (LOWER(a.USERCODE_VCHR) like ? or [FindItem])	
                union
SELECT b.detailid_chr, b.groupid_chr, b.orderdicid_chr, b.freqid_chr,
       b.dosage_dec, b.dosageunit_chr, b.use_dec, b.useunit_chr, b.get_dec,
       b.getunit_chr, b.dosetype_chr, b.entrust_vchr, b.isrich_int,
       b.parentid_chr, b.ifparentid_int, b.executetype_int,
       b.outgetmeddays_int, b.attachtimes_int, b.sampleid_vchr, b.partid_vchr,
       b.recipeno_int, b.ratetype_int, b.isneedfeel, b.name_vchr,
       b.singleamount_dec,
       c.freqname_chr, d.usagename_vchr, e.sample_type_desc_vchr,f.partname
       ,j.itemspec_vchr,k.typename_vchr,m.ordercateid_chr,m.viewname_vchr,h.name_chr OrderdicName,
       h.status_int stopstatus, g.ipnoqtyflag_int,ITEMSRCTYPE_INT
  FROM t_aid_bih_ordergroup a,
       t_aid_bih_ordergroup_detail b,
       t_aid_recipefreq c,
       t_bse_usagetype d,
       t_aid_lis_sampletype e,
       ar_apply_partlist f,
       t_bse_medicine g,
       t_bse_bih_orderdic h,
       t_bse_chargeitem j,
       T_AID_MEDICARETYPE k,
       t_aid_bih_ordercate m
 WHERE a.groupid_chr = b.groupid_chr(+)
   AND b.orderdicid_chr = h.orderdicid_chr(+)
   AND h.ordercateid_chr=m.ordercateid_chr(+)
   AND h.itemid_chr = j.itemid_chr(+)
   AND j.insurancetype_vchr=k.typeid_chr(+)
   AND b.freqid_chr = c.freqid_chr(+)
   AND b.dosetype_chr = d.usageid_chr(+)
   and j.itemsrcid_vchr = g.medicineid_chr(+)
   AND b.sampleid_vchr = e.sample_type_id_chr(+)
   AND b.partid_vchr = f.partid(+)
				and
			 exists (select A.deptid_chr from T_Sys_Role A,t_sys_emprolemap B 
                        where A.roleid_chr=B.roleid_chr(+) AND A.name_vchr=? AND B.empid_chr= ? )
               	and (LOWER(a.USERCODE_VCHR) like ? or [FindItem])";


            string strFind = "";
            switch (m_intClass)
            {
                case -1:
                    strFind = "(LOWER(a.PYCode_Chr) like ? or LOWER(a.WBCode_Chr) like ? or LOWER(a.Name_Chr) like ? )";
                    break;
                case 0:
                    strFind = "LOWER(a.PYCode_Chr) like ?";
                    break;
                case 1:
                    strFind = "LOWER(a.WBCode_Chr) like ?";
                    break;
                case 2:
                    strFind = "LOWER(a.Name_Chr) like ?";
                    break;
                case 3:
                    strFind = "LOWER(a.USERCODE_VCHR) like ?";
                    break;
                case 4:
                    strFind = " 1=1 and a.GROUPID_CHR　like ? ";
                    break;
            }

            strSql = strSql.Replace("[FindItem]", strFind);
            strSql2 = strSql2.Replace("[FindItem]", strFind);
            strFind = p_strFindString.ToLower().Trim() + "%";
            System.Data.IDataParameter[] arrParams = null;
            if (m_intClass != -1)
            {
                new clsHRPTableService().CreateDatabaseParameter(7, out arrParams);
                arrParams[0].Value = strEmpID;
                arrParams[1].Value = strFind;
                arrParams[2].Value = strFind;
                arrParams[3].Value = "编辑公用医嘱组套";
                arrParams[4].Value = strEmpID;
                arrParams[5].Value = strFind;
                arrParams[6].Value = strFind;
            }
            else
            {
                new clsHRPTableService().CreateDatabaseParameter(11, out arrParams);
                arrParams[0].Value = strEmpID;
                arrParams[1].Value = strFind;
                arrParams[2].Value = strFind;
                arrParams[3].Value = strFind;
                arrParams[4].Value = strFind;
                arrParams[5].Value = "编辑公用医嘱组套";
                arrParams[6].Value = strEmpID;
                arrParams[7].Value = strFind;
                arrParams[8].Value = strFind;
                arrParams[9].Value = strFind;
                arrParams[10].Value = strFind;
            }
            DataTable objDT = new DataTable();
            long ret = 0;
            try
            {
                ret = 0;
                // ret = new clsHRPTableService().DoGetDataTable(strSql, ref objDT);
                clsHRPTableService HRPService = new clsHRPTableService();
                ret = HRPService.lngGetDataTableWithParameters(strSql, ref objDT, arrParams);
                System.Data.IDataParameter[] arrParams2 = null;
                if (m_intClass != -1)
                {
                    new clsHRPTableService().CreateDatabaseParameter(7, out arrParams2);
                    arrParams2[0].Value = strEmpID;
                    arrParams2[1].Value = strFind;
                    arrParams2[2].Value = strFind;
                    arrParams2[3].Value = "编辑公用医嘱组套";
                    arrParams2[4].Value = strEmpID;
                    arrParams2[5].Value = strFind;
                    arrParams2[6].Value = strFind;
                }
                else
                {
                    new clsHRPTableService().CreateDatabaseParameter(11, out arrParams2);
                    arrParams2[0].Value = strEmpID;
                    arrParams2[1].Value = strFind;
                    arrParams2[2].Value = strFind;
                    arrParams2[3].Value = strFind;
                    arrParams2[4].Value = strFind;
                    arrParams2[5].Value = "编辑公用医嘱组套";
                    arrParams2[6].Value = strEmpID;
                    arrParams2[7].Value = strFind;
                    arrParams2[8].Value = strFind;
                    arrParams2[9].Value = strFind;
                    arrParams2[10].Value = strFind;
                }
                ret = HRPService.lngGetDataTableWithParameters(strSql2, ref m_dtGroupDetail, arrParams2);

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            /* <<============================================================== */
            if (ret > 0)
            {
                //arrGroup=new clsBIHOrderGroup[objDT.Rows.Count];
                System.Collections.ArrayList m_ArrList = new System.Collections.ArrayList();
                string[] m_arrArea = null;
                for (int i = 0; i < objDT.Rows.Count; i++)
                {
                    clsT_aid_bih_ordergroup_VO objGroup = new clsT_aid_bih_ordergroup_VO();
                    m_mthGetBihGroupFromDataRow(objDT.Rows[i], ref objGroup);
                    //if (objGroup.m_intSHARETYPE_INT == 3)
                    //{
                    //    m_arrArea = objGroup.m_strAREAID_VCHR.Split(",".ToCharArray());
                    //    for (int j = 0; j < m_arrArea.Length; j++)
                    //    {
                    //        if (m_arrArea[j].ToString().Trim().Equals(strDeptID.Trim()))
                    //        {
                    //            m_ArrList.Add(objGroup);
                    //            break;
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    m_ArrList.Add(objGroup);
                    //}
                    m_ArrList.Add(objGroup);
                }
                arrGroup = new clsT_aid_bih_ordergroup_VO[m_ArrList.Count];
                for (int i = 0; i < m_ArrList.Count; i++)
                {
                    arrGroup[i] = (clsT_aid_bih_ordergroup_VO)m_ArrList[i];
                }
                return 1;
            }
            else
            {
                arrGroup = null;
                return 0;
            }
        }

        /// <summary>
        /// 查询组套
        /// </summary>
        /// <param name="p_strFindString">查询字符串</param>
        /// <param name="strEmpID">用户ID</param>
        /// <param name="strDeptID">科室ID</param>
        /// <param name="m_intClass">查询条件</param>
        /// <param name="arrGroup">组套对象数组</param>
        /// <param name="m_dtGroupDetail">组套明细表 </param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFindGroupAndDetail(string p_strFindString, string strEmpID, string strDeptID, int m_intClass, out DataTable m_dtGroupDetail)
        {
            m_dtGroupDetail = new DataTable();

            string strSql2 = @"
				SELECT b.detailid_chr, b.groupid_chr, b.orderdicid_chr, b.freqid_chr,
       b.dosage_dec, b.dosageunit_chr, b.use_dec, b.useunit_chr, b.get_dec,
       b.getunit_chr, b.dosetype_chr, b.entrust_vchr, b.isrich_int,
       b.parentid_chr, b.ifparentid_int, b.executetype_int,
       b.outgetmeddays_int, b.attachtimes_int, b.sampleid_vchr, b.partid_vchr,
       b.recipeno_int, b.ratetype_int, b.isneedfeel, b.name_vchr,
       b.singleamount_dec,
       c.freqname_chr, d.usagename_vchr, e.sample_type_desc_vchr,f.partname
       ,j.itemspec_vchr,k.typename_vchr,m.ordercateid_chr,m.viewname_vchr,h.name_chr OrderdicName
  FROM t_aid_bih_ordergroup a,
       t_aid_bih_ordergroup_detail b,
       t_aid_recipefreq c,
       t_bse_usagetype d,
       t_aid_lis_sampletype e,
       ar_apply_partlist f,
       t_bse_bih_orderdic h,
       t_bse_chargeitem j,
       T_AID_MEDICARETYPE k,
       t_aid_bih_ordercate m
 WHERE a.groupid_chr = b.groupid_chr(+)
   AND b.orderdicid_chr = h.orderdicid_chr(+)
   AND h.ordercateid_chr=m.ordercateid_chr(+)
   AND h.itemid_chr = j.itemid_chr(+)
   AND j.insurancetype_vchr=k.typeid_chr(+)
   AND b.freqid_chr = c.freqid_chr(+)
   AND b.dosetype_chr = d.usageid_chr(+)
   AND b.sampleid_vchr = e.sample_type_id_chr(+)
   AND b.partid_vchr = f.partid(+)
				and
				 ((ShareType_Int=1) and (CreatorID_Chr=?))
				and (LOWER(a.USERCODE_VCHR) like ? or [FindItem] 	)	
                union
              SELECT b.detailid_chr, b.groupid_chr, b.orderdicid_chr, b.freqid_chr,
       b.dosage_dec, b.dosageunit_chr, b.use_dec, b.useunit_chr, b.get_dec,
       b.getunit_chr, b.dosetype_chr, b.entrust_vchr, b.isrich_int,
       b.parentid_chr, b.ifparentid_int, b.executetype_int,
       b.outgetmeddays_int, b.attachtimes_int, b.sampleid_vchr, b.partid_vchr,
       b.recipeno_int, b.ratetype_int, b.isneedfeel, b.name_vchr,
       b.singleamount_dec, 
       c.freqname_chr, d.usagename_vchr, e.sample_type_desc_vchr,f.partname
       ,j.itemspec_vchr,k.typename_vchr,m.ordercateid_chr,m.viewname_vchr,h.name_chr OrderdicName
  FROM t_aid_bih_ordergroup a,
       t_aid_bih_ordergroup_detail b,
       t_aid_recipefreq c,
       t_bse_usagetype d,
       t_aid_lis_sampletype e,
       ar_apply_partlist f,
       t_bse_bih_orderdic h,
       t_bse_chargeitem j,
       T_AID_MEDICARETYPE k,
       t_aid_bih_ordercate m
 WHERE a.groupid_chr = b.groupid_chr(+)
   AND b.orderdicid_chr = h.orderdicid_chr(+)
   AND h.ordercateid_chr=m.ordercateid_chr(+)
   AND h.itemid_chr = j.itemid_chr(+)
   AND j.insurancetype_vchr=k.typeid_chr(+)
   AND b.freqid_chr = c.freqid_chr(+)
   AND b.dosetype_chr = d.usageid_chr(+)
   AND b.sampleid_vchr = e.sample_type_id_chr(+)
   AND b.partid_vchr = f.partid(+)
				and
				exists (select * from t_sys_emprolemap b where b.roleid_chr='0000065' and b.empid_chr=[empid_chr])
               
				and (LOWER(a.USERCODE_VCHR) like ? or [FindItem] )		
			";


            string strFind = "";
            switch (m_intClass)
            {
                case -1:
                    strFind = "(LOWER(a.PYCode_Chr) like ? or LOWER(a.WBCode_Chr) like ? or LOWER(a.Name_Chr) like ? )";
                    break;
                case 0:
                    strFind = "LOWER(a.PYCode_Chr) like ?";
                    break;
                case 1:
                    strFind = "LOWER(a.WBCode_Chr) like ?";
                    break;
                case 2:
                    strFind = "LOWER(a.Name_Chr) like ?";
                    break;
                case 3:
                    strFind = "LOWER(a.USERCODE_VCHR) like ?";
                    break;
                case 4:
                    strFind = " a.GROUPID_CHR=? ";
                    break;
            }

            strSql2 = strSql2.Replace("[FindItem]", strFind);
            strSql2 = strSql2.Replace("[empid_chr]", strEmpID);
            // strSql = strSql.Replace("[strEmpid_chr]", strEmpid_chr);
            strFind = p_strFindString.ToLower().Trim() + "%";
            System.Data.IDataParameter[] arrParams = null;

            long ret = 0;
            try
            {
                System.Data.IDataParameter[] arrParams2 = null;
                if (m_intClass != -1)
                {
                    new clsHRPTableService().CreateDatabaseParameter(5, out arrParams2);
                    arrParams2[0].Value = strEmpID;
                    arrParams2[1].Value = strFind;
                    arrParams2[2].Value = strFind;
                    arrParams2[3].Value = strFind;
                    arrParams2[4].Value = strFind;
                }
                else
                {
                    new clsHRPTableService().CreateDatabaseParameter(7, out arrParams2);
                    arrParams2[0].Value = strEmpID;
                    arrParams2[1].Value = strFind;
                    arrParams2[2].Value = strFind;
                    arrParams2[3].Value = strFind;
                    arrParams2[4].Value = strFind;
                    arrParams2[5].Value = strFind;
                    arrParams2[6].Value = strFind;
                }
                clsHRPTableService HRPService = new clsHRPTableService();

                ret = HRPService.lngGetDataTableWithParameters(strSql2, ref m_dtGroupDetail, arrParams2);

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            /* <<============================================================== */
            return ret;
        }

        #endregion

        #region 获取组套成员
        /// <summary>
        /// 获取组套成员
        /// </summary>
        /// <param name="strGroupID"></param>
        /// <param name="arrOrder"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetGroupItems(string strGroupID, out clsBIHOrder[] arrOrder)
        {

            string strSql = @"
				SELECT   ta.orderdicid_chr, ta.dosage_dec, tb.dosageunit_chr, ta.use_dec,
						tb.useunit_chr, ta.get_dec, ta.getunit_chr, tb.useunit_chr getunit,
						ta.dosetype_chr, ta.freqid_chr, ta.entrust_vchr, ta.parentid_chr,
						ta.ifparentid_int, tb.name_chr, tb.des_vchr, tb.usercode_chr,
						tb.wbcode_chr, tb.pycode_chr, tb.execdept_chr, tb.ordercateid_chr,
						tb.itemid_chr, tb.isrich_int, tb.itemspec_vchr, tb.itemprice,tb.SAMPLEID_VCHR,tb.PARTID_VCHR,
						tb.dosagerate, tc.freqname_chr, td.usagename_vchr
					FROM t_aid_bih_ordergroup_detail ta,
						(SELECT a.orderdicid_chr, a.name_chr, a.des_vchr, a.usercode_chr,
								a.wbcode_chr, a.pycode_chr, a.execdept_chr,a.SAMPLEID_VCHR,a.PARTID_VCHR,
								a.ordercateid_chr, a.itemid_chr, b.isrich_int,
								b.itemspec_vchr,
								DECODE (b.ipchargeflg_int,
										1, ROUND (b.itemprice_mny / b.packqty_dec, 4),
										0, b.itemprice_mny,
										ROUND (b.itemprice_mny / b.packqty_dec, 4)
										) itemprice,
								b.dosage_dec dosagerate, b.dosageunit_chr,
								b.itemipunit_chr useunit_chr
							FROM t_bse_bih_orderdic a, t_bse_chargeitem b
						WHERE a.itemid_chr = b.itemid_chr) tb,
						t_aid_recipefreq tc,
						t_bse_usagetype td
				WHERE ta.orderdicid_chr = tb.orderdicid_chr
					AND ta.freqid_chr = tc.freqid_chr(+)
					AND ta.dosetype_chr = td.usageid_chr(+)
					AND ta.groupid_chr = '[GroupID]'
				ORDER BY ta.ifparentid_int DESC
				";

            strSql = strSql.Replace("[GroupID]", strGroupID);

            DataTable objDT = new DataTable();
            long ret = 0;
            try
            {
                ret = new clsHRPTableService().DoGetDataTable(strSql, ref objDT);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (ret > 0)
            {
                arrOrder = new clsBIHOrder[objDT.Rows.Count];
                for (int i = 0; i < arrOrder.Length; i++)
                {
                    clsBIHOrder objOrder = new clsBIHOrder();
                    DataRow objRow = objDT.Rows[i];


                    objOrder.m_strOrderID = "";			//需设置
                    objOrder.m_strOrderDicID = clsConverter.ToString(objRow["OrderDicID_Chr"]).Trim();
                    objOrder.m_strOrderDicCateID = clsConverter.ToString(objRow["OrderCateID_Chr"]).Trim();
                    objOrder.m_strRegisterID = "";		//需设置
                    objOrder.m_strPatientID = "";			//需设置

                    objOrder.m_intExecuteType = 0;		//需设置
                    objOrder.m_intRecipenNo = 0;			//需设置
                    objOrder.m_strName = clsConverter.ToString(objRow["Name_Chr"]).Trim();
                    objOrder.m_strSpec = clsConverter.ToString(objRow["ItemSpec_VChr"]).Trim();
                    objOrder.m_strExecFreqID = clsConverter.ToString(objRow["FreqID_Chr"]).Trim();
                    objOrder.m_strExecFreqName = clsConverter.ToString(objRow["FreqName_Chr"]).Trim();

                    objOrder.m_dmlDosage = clsConverter.ToDecimal(objRow["Dosage_Dec"]);
                    objOrder.m_strDosageUnit = clsConverter.ToString(objRow["DosageUnit_Chr"]).Trim();

                    objOrder.m_dmlUse = clsConverter.ToDecimal(objRow["Use_Dec"]);
                    objOrder.m_strUseunit = clsConverter.ToString(objRow["UseUnit_Chr"]);

                    objOrder.m_dmlGet = clsConverter.ToDecimal(objRow["Get_Dec"]);
                    objOrder.m_strGetunit = clsConverter.ToString(objRow["GetUnit"]).Trim();

                    objOrder.m_strDosetypeID = clsConverter.ToString(objRow["DoseType_Chr"]).Trim();
                    objOrder.m_strDosetypeName = clsConverter.ToString(objRow["UsageName_Vchr"]).Trim();

                    objOrder.m_dtStartDate = clsBIHOrder.m_dtNullDate;	//需设置
                    objOrder.m_dtFinishDate = clsBIHOrder.m_dtNullDate;	//需设置

                    objOrder.m_strExecDeptID = clsConverter.ToString(objRow["ExecDept_Chr"]).Trim();
                    objOrder.m_strExecDeptName = "";

                    objOrder.m_strEntrust = clsConverter.ToString(objRow["Entrust_VChr"]).Trim();
                    //注意: 这里存储的是: 父诊疗项目id	{=诊疗项目.Id}
                    objOrder.m_strParentID = clsConverter.ToString(objRow["parentid_chr"]).Trim();

                    objOrder.m_intStatus = 0;
                    objOrder.m_intIsRich = clsConverter.ToInt(objRow["IsRich_Int"]);
                    objOrder.RateType = 0;	//Must Set
                    objOrder.m_intIsRepare = 0;	//Must Set

                    objOrder.m_strCreatorID = "";	//Must set
                    objOrder.m_strCreator = "";	//must set
                    objOrder.m_dtCreatedate = clsBIHOrder.m_dtNullDate;
                    /* 检验样本类型ID*/
                    objOrder.m_strSAMPLEID_VCHR = clsConverter.ToString(objRow["SAMPLEID_VCHR"]).Trim();
                    objOrder.m_strPARTID_VCHR = clsConverter.ToString(objRow["PARTID_VCHR"]).Trim();
                    //其它略.......
                    objOrder.m_dmlPrice = clsConverter.ToDecimal(objRow["ItemPrice"]);
                    objOrder.m_dmlDosageRate = clsConverter.ToDecimal(objRow["DosageRate"]);
                    arrOrder[i] = objOrder;
                }
                return 1;
            }
            else
            {
                arrOrder = null;
                return 0;
            }
        }

        #endregion

        #region 判断当前用户是否有费用上限的处理权限
        /// <summary>
        /// 判断当前用户是否有费用上限的处理权限
        /// </summary>
        /// <param name="EMPNO_CHR">员工号</param>
        /// <param name="PSW_CHR">密码</param>
        /// <param name="maxvalue">当前最大值</param>
        /// <param name="dtbResult">返回表</param>
        /// <returns></returns>
        [AutoComplete]
        public long ConfirmMaxValue(string EMPNO_CHR, string PSW_CHR, double maxvalue, out DataTable dtbResult)
        {
            dtbResult = new DataTable();

            long lngRes = -1;
            string strSQL = @"
            select 
            a.lastname_vchr,
            d.name_vchr roleName,
            c.bih_order_flt
            from 
            t_bse_employee a,
            t_sys_emprolemap b,
            T_BSE_ROLECHARGEDEF c,
            t_sys_role d

            where 
            a.empid_chr=b.empid_chr
            and b.roleid_chr=c.roleid_chr
            and b.roleid_chr=d.roleid_chr
            and a.EMPNO_CHR='[EMPNO_CHR]'
            and (trim(a.psw_chr)='[PSW_CHR]' or a.psw_chr is null)
            and
            [maxvalue]<(select max(bih_order_flt) upvalue from (
            select c.bih_order_flt 
            from 
            t_bse_employee a,
            t_sys_emprolemap b,
            T_BSE_ROLECHARGEDEF c,
            t_sys_role d
            where
            a.empid_chr=b.empid_chr
            and b.roleid_chr=c.roleid_chr
            and b.roleid_chr=d.roleid_chr
            and a.EMPNO_CHR='[EMPNO_CHR]'
            and (trim(a.psw_chr)='[PSW_CHR]' or a.psw_chr is null)
          
            ))
            ";
            strSQL = strSQL.Replace("[EMPNO_CHR]", EMPNO_CHR.ToString().Trim());
            strSQL = strSQL.Replace("[PSW_CHR]", PSW_CHR.ToString().Trim());
            strSQL = strSQL.Replace("[maxvalue]", maxvalue.ToString().Trim());

            try
            {

                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                //if (lngRes > 0)
                //{
                //    if (dtbResult.Rows.Count > 0)
                //    {
                //        max = int.Parse(dtbResult.Rows[0]["upvalue"].ToString());
                //    }
                //}
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

        #region 获取当前用户的药品上限值
        /// <summary>
        /// 获取当前用户的药品上限值
        /// </summary>
        /// <returns></returns>
        [AutoComplete]
        public long getMaxValue(string EMPID_CHR, out int max)
        {
            max = 0;
            long lngRes = -1;

            string strSQL = @"
            select max(bih_order_flt) upvalue from (
            select a.empid_chr,c.bih_order_flt,d.name_vchr 
            from 
            t_bse_employee a,
            t_sys_emprolemap b,
            T_BSE_ROLECHARGEDEF c,
            t_sys_role d
            where
            a.empid_chr=b.empid_chr
            and b.roleid_chr=c.roleid_chr
            and b.roleid_chr=d.roleid_chr
            and a.empid_chr='[EMPID_CHR]'
            )
            ";
            strSQL = strSQL.Replace("[EMPID_CHR]", EMPID_CHR.ToString().Trim());

            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                if (lngRes > 0)
                {
                    if (dtbResult.Rows.Count > 0)
                    {
                        if (dtbResult.Rows[0]["upvalue"].ToString().Trim() != "")
                        {
                            max = int.Parse(dtbResult.Rows[0]["upvalue"].ToString());
                        }
                        else
                            max = 0;
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

        #region 根据诊疗ID判断相关诊疗项目的费用大于上限
        /// <summary>
        /// 根据诊疗ID判断相关诊疗项目的费用大于上限
        /// </summary>
        /// <param name="orderdicid_chr"></param>
        /// <param name="m_dblMax"></param>
        /// <param name="get_dec">领量</param>
        /// <param name="m_dtOrder"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckMoneyByorderdicid(string orderdicid_chr, double m_dblMax, double get_dec, out DataTable m_dtOrder)
        {

            long lngRes = -1;
            m_dtOrder = new DataTable();
            string strSQL = @"
              SELECT  b.itemname_vchr NAME_CHR,
                DECODE (b.ipchargeflg_int,
                1, ROUND (b.itemprice_mny / b.packqty_dec, 4),
                0, b.itemprice_mny,
                ROUND (b.itemprice_mny / b.packqty_dec, 4)
                ) itemprice,
                [get_dec] get_dec,
                ROUND (  [get_dec]
                * (DECODE (b.ipchargeflg_int,
                1, ROUND (b.itemprice_mny / b.packqty_dec, 4),
                0, b.itemprice_mny,
                ROUND (b.itemprice_mny / b.packqty_dec, 4)
                )
                ),
                2
                ) pricesum
                FROM 
                t_bse_bih_orderdic c,
                t_bse_chargeitem b,
                t_aid_bih_orderdic_charge d
                
                WHERE 
                 c.orderdicid_chr = d.orderdicid_chr
                AND d.itemid_chr = b.itemid_chr
                AND b.itemcatid_chr in ('1','2','4','8','9')
                AND   [get_dec]
                * (DECODE (b.ipchargeflg_int,
                1, ROUND (b.itemprice_mny / b.packqty_dec, 4),
                0, b.itemprice_mny,
                ROUND (b.itemprice_mny / b.packqty_dec, 4)
                )
                ) > [m_dblMax]
                AND c.orderdicid_chr = '[orderdicid_chr]'
                AND (SELECT COUNT (*)
                FROM (SELECT [get_dec],
                DECODE (b.ipchargeflg_int,
                1, ROUND (b.itemprice_mny / b.packqty_dec, 4),
                0, b.itemprice_mny,
                ROUND (b.itemprice_mny / b.packqty_dec, 4)
                ) itemprice
                FROM 
                t_bse_bih_orderdic c,
                t_bse_chargeitem b,
                t_aid_bih_orderdic_charge d
                
                WHERE 
                c.orderdicid_chr = d.orderdicid_chr
                AND d.itemid_chr = b.itemid_chr
                AND b.itemcatid_chr in ('1','2','4','8','9')
                AND c.orderdicid_chr = '[orderdicid_chr]') d
                WHERE [get_dec] * itemprice > [m_dblMax]) > 0";
            /*<===============================================================================*/
            strSQL = strSQL.Replace("[orderdicid_chr]", orderdicid_chr.ToString().Trim());
            strSQL = strSQL.Replace("[m_dblMax]", m_dblMax.ToString().Trim());
            strSQL = strSQL.Replace("[get_dec]", get_dec.ToString().Trim());
            try
            {
                // DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref m_dtOrder);
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

        #region 根据医嘱组套ID判断相关诊疗项目的费用大于上限
        /// <summary>
        /// 根据医嘱组套ID判断相关诊疗项目的费用大于上限 
        /// </summary>
        /// <param name="p_strGroupID">医嘱组套ID</param>
        /// <param name="m_dblMax">费用上限</param>
        /// <param name="Count">超过上限的项目</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckGroupMoney(string p_strGroupID, double m_dblMax, out DataTable m_dtOrder)
        {

            long lngRes = -1;
            m_dtOrder = new DataTable();
            /*--------------------------------------->
           string  strSQL = @"
            select 
            c.NAME_CHR,
            decode(b.IPCHARGEFLG_INT,1,Round(B.ItemPrice_Mny/B.PackQty_Dec,4),0,B.ItemPrice_Mny,Round(B.ItemPrice_Mny/B.PackQty_Dec,4)) ItemPrice,
            a.get_dec,
            Round(a.get_dec*(decode(b.IPCHARGEFLG_INT,1,Round(B.ItemPrice_Mny/B.PackQty_Dec,4),0,B.ItemPrice_Mny,Round(B.ItemPrice_Mny/B.PackQty_Dec,4))),2) pricesum

            from T_aid_bih_ordergroup_detail a,T_BSE_BIH_OrderDic c,T_BSE_ChargeItem b  
            where b.itemid_chr=c.itemid_chr and a.orderdicid_chr=c.orderdicid_chr 
            and a.get_dec*(decode(b.IPCHARGEFLG_INT,1,Round(B.ItemPrice_Mny/B.PackQty_Dec,4),0,B.ItemPrice_Mny,Round(B.ItemPrice_Mny/B.PackQty_Dec,4)))>[m_dblMax]
            and a.groupid_chr='[groupid_chr]'
            and
            (select count(*)  from
            (
            select
            a.get_dec,
            decode(b.IPCHARGEFLG_INT,1,Round(B.ItemPrice_Mny/B.PackQty_Dec,4),0,B.ItemPrice_Mny,Round(B.ItemPrice_Mny/B.PackQty_Dec,4)) ItemPrice
            from T_aid_bih_ordergroup_detail a,T_BSE_BIH_OrderDic c,T_BSE_ChargeItem b  
            where b.itemid_chr=c.itemid_chr and a.orderdicid_chr=c.orderdicid_chr 
            and a.groupid_chr='[groupid_chr]'
            ) d
            where d.get_dec*ItemPrice>[m_dblMax])>0
            ";
            */
            string strSQL = @"
                SELECT  b.itemname_vchr NAME_CHR,
                DECODE (b.ipchargeflg_int,
                1, ROUND (b.itemprice_mny / b.packqty_dec, 4),
                0, b.itemprice_mny,
                ROUND (b.itemprice_mny / b.packqty_dec, 4)
                ) itemprice,
                a.get_dec,
                ROUND (  a.get_dec
                * (DECODE (b.ipchargeflg_int,
                1, ROUND (b.itemprice_mny / b.packqty_dec, 4),
                0, b.itemprice_mny,
                ROUND (b.itemprice_mny / b.packqty_dec, 4)
                )
                ),
                2
                ) pricesum
                FROM t_aid_bih_ordergroup_detail a,
                t_bse_bih_orderdic c,
                t_bse_chargeitem b,
                t_aid_bih_orderdic_charge d,
                t_aid_bih_ordergroup e
                WHERE e.groupid_chr = a.groupid_chr
                AND a.orderdicid_chr = c.orderdicid_chr
                AND c.orderdicid_chr = d.orderdicid_chr
                AND d.itemid_chr = b.itemid_chr
                AND b.itemcatid_chr in ('1','2','4','8','9')
                AND   a.get_dec
                * (DECODE (b.ipchargeflg_int,
                1, ROUND (b.itemprice_mny / b.packqty_dec, 4),
                0, b.itemprice_mny,
                ROUND (b.itemprice_mny / b.packqty_dec, 4)
                )
                ) > [m_dblMax]
                AND e.groupid_chr = '[groupid_chr]'
                AND (SELECT COUNT (*)
                FROM (SELECT a.get_dec,
                DECODE (b.ipchargeflg_int,
                1, ROUND (b.itemprice_mny / b.packqty_dec, 4),
                0, b.itemprice_mny,
                ROUND (b.itemprice_mny / b.packqty_dec, 4)
                ) itemprice
                FROM t_aid_bih_ordergroup_detail a,
                t_bse_bih_orderdic c,
                t_bse_chargeitem b,
                t_aid_bih_orderdic_charge d,
                t_aid_bih_ordergroup e
                WHERE e.groupid_chr = a.groupid_chr
                AND a.orderdicid_chr = c.orderdicid_chr
                AND c.orderdicid_chr = d.orderdicid_chr
                AND d.itemid_chr = b.itemid_chr
                AND b.itemcatid_chr in ('1','2','4','8','9')
                AND e.groupid_chr = '[groupid_chr]') d
                WHERE d.get_dec * itemprice > [m_dblMax]) > 0";
            /*<===============================================================================*/
            strSQL = strSQL.Replace("[groupid_chr]", p_strGroupID.ToString().Trim());
            strSQL = strSQL.Replace("[m_dblMax]", m_dblMax.ToString().Trim());
            try
            {
                // DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref m_dtOrder);
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

        #region 判断是否相同方号
        /// <summary>
        /// 判断是否相同方号
        /// </summary>
        /// <param name="p_strGroupID">组套ID</param>
        /// <param name="p_blnIsSameNO">是否同方号	[out 参数]</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngCheckIsSameNOByGroupID(string p_strGroupID, out bool p_blnIsSameNO)
        {
            p_blnIsSameNO = false;
            long lngRes = -1;
            string strSQL = "SELECT issamerecipeno_int FROM t_aid_bih_ordergroup WHERE Trim(groupid_chr)='" + p_strGroupID.Trim() + "'";
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0 && dtbResult.Rows[0][0] != System.DBNull.Value)
                {
                    p_blnIsSameNO = (Int32.Parse(dtbResult.Rows[0][0].ToString()) == 1) ? true : false;
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

        #region 查询医嘱组套-按流水号
        /// <summary>
        /// 查询医嘱组套-按流水号
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strID">查询医嘱组套流水号</param>
        /// <param name="p_objResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOrderGroupByID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strID, out clsT_aid_bih_ordergroup_VO p_objResult)
        {
            p_objResult = new clsT_aid_bih_ordergroup_VO();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetOrderGroupByID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT groupid_chr, name_chr, des_vchr, creatorid_chr,createdate_dat, sharetype_int, wbcode_chr, pycode_chr,issamerecipeno_int ";
            strSQL += " ,(SELECT LASTNAME_VCHR FROM t_bse_employee WHERE t_bse_employee.EMPID_CHR=t_aid_bih_ordergroup.CREATORID_CHR) CreatorName";
            /* @update by xzf (05-11-04)
             * 将共享类型改为{私用/公用}
             */
            /* @remark---------------------
            strSQL +=" ,Decode(sharetype_int,1,'本人',2,'科室',3,'完全','') ShareType";
            ------------------------------ */
            strSQL += " ,Decode(sharetype_int,1,'私用',2,'公用','') ShareType";
            /* <<======================================= */
            strSQL += " FROM t_aid_bih_ordergroup ";
            strSQL += " WHERE GROUPID_CHR = '" + p_strID.Trim() + "' ";
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResult = new clsT_aid_bih_ordergroup_VO();
                    p_objResult.m_strGROUPID_CHR = dtbResult.Rows[0]["GROUPID_CHR"].ToString().Trim();
                    p_objResult.m_strNAME_CHR = dtbResult.Rows[0]["NAME_CHR"].ToString().Trim();
                    p_objResult.m_strDES_VCHR = dtbResult.Rows[0]["DES_VCHR"].ToString().Trim();
                    p_objResult.m_strCREATORID_CHR = dtbResult.Rows[0]["CREATORID_CHR"].ToString().Trim();
                    p_objResult.m_strCREATEDATE_DAT = Convert.ToDateTime(dtbResult.Rows[0]["CREATEDATE_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                    p_objResult.m_intSHARETYPE_INT = Convert.ToInt32(dtbResult.Rows[0]["SHARETYPE_INT"].ToString().Trim());
                    p_objResult.m_strWBCODE_CHR = dtbResult.Rows[0]["WBCODE_CHR"].ToString().Trim();
                    p_objResult.m_strPYCODE_CHR = dtbResult.Rows[0]["PYCODE_CHR"].ToString().Trim();
                    /* @add by xzf (05-10-26) */
                    p_objResult.m_strCreatorName = dtbResult.Rows[0]["CreatorName"].ToString().Trim();
                    /* <<========================================== */
                    try { p_objResult.m_intISSAMERECIPENO_INT = Int32.Parse(dtbResult.Rows[0]["issamerecipeno_int"].ToString()); }
                    catch { }
                    //非字段
                    p_objResult.m_strCreatorName = dtbResult.Rows[0]["CreatorName"].ToString().Trim();
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

        #region 查询医嘱组套成员－医嘱组套流水号并转换为医嘱项目
        /// <summary>
        /// 查询医嘱组套成员－医嘱组套流水号并转换为医嘱项目
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strGroupID">医嘱组套流水号</param>
        /// <param name="p_objResultArr">【返回VO数组 out参数】</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOrderGroupDetailByGroupID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strGroupID, out DataTable dtbResult, bool m_bltemp)
        {
            dtbResult = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetOrderGroupDetailByGroupID");
            if (lngRes < 0)
            {
                return -1;
            }
            /*
            string strSQL = @"
            SELECT distinct 
            a.detailid_chr,
            a.groupid_chr, 
            a.orderdicid_chr, 
            a.freqid_chr,
            a.dosetype_chr,  
            a.EXECUTETYPE_INT,
            a.OUTGETMEDDAYS_INT,
            a.ATTACHTIMES_INT,
            a.SAMPLEID_VCHR,
            a.PARTID_VCHR,
            c.sample_type_desc_vchr,
            d.partname,
            (b1.name_chr) groupname,
            
            (b2.name_chr) orderdicname,
            (b3.freqname_chr) freqname,
            (a.dosage_dec)  dosage_dec,
            (a.dosageunit_chr)  dosageunit_chr,
            (a.use_dec)  use_dec,
            (a.useunit_chr)  useunit_chr,
            a.get_dec, 
            a.getunit_chr,
            (b4.usagename_vchr) dosetypename, 
            a.entrust_vchr,
            a.isrich_int, 
            a.parentid_chr, 
            a.ifparentid_int,
            DECODE (a.isrich_int, 1, '√', 0, '×', '') isrich,
            DECODE (a.ifparentid_int, 1, '√', 0, '×', '') ifparentname,
            b5.name_chr parentname,
            b6.dosageviewtype dosageviewtype,
            b6.usageviewtype usageviewtype,
            b2.status_int  status_int,
            b7.itemspec_vchr,
            b4.usageid_chr,
            b5.sampleid_vchr,
            b5.partid_vchr,
            decode(b7.IPCHARGEFLG_INT,1,Round(b7.ItemPrice_Mny/b7.PackQty_Dec,4),0,b7.ItemPrice_Mny,Round(b7.ItemPrice_Mny/b7.PackQty_Dec,4)) ItemPrice
       
            FROM 
            t_aid_bih_ordergroup_detail a ,
            t_aid_bih_ordergroup b1,
            t_bse_bih_orderdic b2,
            t_aid_recipefreq b3,
            t_bse_usagetype b4,
            t_bse_bih_orderdic b5,
            t_aid_bih_ordercate b6,
            t_bse_chargeitem b7,
            t_aid_lis_sampletype c,
            ar_apply_partlist d
            WHERE 
            a.groupid_chr=b1.groupid_chr(+)
            and a.orderdicid_chr=b2.orderdicid_chr(+)
            and a.freqid_chr = b3.freqid_chr(+) 
            and a.dosetype_chr=b4.usageid_chr(+)
            and a.parentid_chr = b5.orderdicid_chr(+)
            and b2.ordercateid_chr=b6.ordercateid_chr(+)
            and b2.itemid_chr=b7.itemid_chr(+)
            and a.SAMPLEID_VCHR=c.sample_type_id_chr(+)
            and a.PARTID_VCHR=d.partid(+)
            and a.groupid_chr = '[groupid_chr]'";
             */
            string strSQL = @"
            SELECT b.detailid_chr, b.groupid_chr, b.orderdicid_chr, b.freqid_chr,
       b.dosage_dec, b.dosageunit_chr, b.use_dec, b.useunit_chr, b.get_dec,
       b.getunit_chr, b.dosetype_chr, b.entrust_vchr, b.isrich_int,
       b.parentid_chr, b.ifparentid_int, b.executetype_int,
       b.outgetmeddays_int, b.attachtimes_int, b.sampleid_vchr, b.partid_vchr,
       b.recipeno_int, b.ratetype_int, b.isneedfeel, b.name_vchr,
       b.singleamount_dec, 
       c.freqname_chr, d.usagename_vchr, e.sample_type_desc_vchr,f.partname
       ,j.itemspec_vchr,j.packqty_dec,j.ipchargeflg_int
       ,decode(j.IPCHARGEFLG_INT,1,Round(j.ItemPrice_Mny/j.PackQty_Dec,4),0,j.ItemPrice_Mny,Round(j.ItemPrice_Mny/j.PackQty_Dec,4)) ItemPrice 
       ,ITEMSRCTYPE_INT
       ,k.typename_vchr,m.ordercateid_chr,m.viewname_vchr,h.name_chr OrderdicName,h.STATUS_INT  stopStatus,g.IPNOQTYFLAG_INT
  FROM t_aid_bih_ordergroup a,
       t_aid_bih_ordergroup_detail b,
       t_aid_recipefreq c,
       t_bse_usagetype d,
       t_aid_lis_sampletype e,
       ar_apply_partlist f,
       T_BSE_MEDICINE g,
       t_bse_bih_orderdic h,
       t_bse_chargeitem j,
       T_AID_MEDICARETYPE k,
       t_aid_bih_ordercate m
 WHERE a.groupid_chr = b.groupid_chr(+)
   AND b.orderdicid_chr = h.orderdicid_chr(+)
   AND h.ordercateid_chr=m.ordercateid_chr(+)
   AND h.itemid_chr = j.itemid_chr(+)
   AND j.ITEMSRCID_VCHR=g.medicineid_chr(+)
   AND j.insurancetype_vchr=k.typeid_chr(+)
   AND b.freqid_chr = c.freqid_chr(+)
   AND b.dosetype_chr = d.usageid_chr(+)
   AND b.sampleid_vchr = e.sample_type_id_chr(+)
   AND b.partid_vchr = f.partid(+)
   and a.groupid_chr = ?
   ORDER BY b.RECIPENO_INT,b.detailid_chr
   ";

            try
            {

                System.Data.IDataParameter[] arrParams = null;
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(1, out arrParams);
                int n = -1;
                n++; arrParams[n].Value = p_strGroupID.Trim();

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, arrParams);
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

        #region 判断当前用户/密码是否一致
        /// <summary>
        /// 判断当前用户/密码是否一致
        /// </summary>
        /// <param name="EMPNO_CHR">员工号</param>
        /// <param name="PSW_CHR">密码</param>
        /// <param name="dtbResult">返回表</param>
        /// <returns></returns>
        [AutoComplete]
        public long ConfirmPassWord(string EMPNO_CHR, string PSW_CHR, out DataTable dtbResult)
        {
            dtbResult = new DataTable();

            long lngRes = -1;
            string strSQL = @"
            select 
            a.empid_chr,
            a.lastname_vchr,
            d.name_vchr roleName,
            c.bih_order_flt
            from 
            t_bse_employee a,
            t_sys_emprolemap b,
            T_BSE_ROLECHARGEDEF c,
            t_sys_role d

            where 
            a.empid_chr=b.empid_chr
            and b.roleid_chr=c.roleid_chr(+)
            and b.roleid_chr=d.roleid_chr(+)
            and a.EMPNO_CHR=?
            and (trim(a.psw_chr)=? or a.psw_chr is null)
           
            ";

            try
            {
                System.Data.IDataParameter[] arrParams = null;
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(2, out arrParams);
                int n = -1;
                n++; arrParams[n].Value = EMPNO_CHR;
                n++; arrParams[n].Value = PSW_CHR;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, arrParams);

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

        #region 查询医嘱组套成员－对应的收费项目

        [AutoComplete]
        public long m_lngGetChargeListByGroupDetail(System.Security.Principal.IPrincipal p_objPrincipal, clsBIHOrder order, out ArrayList m_arrChargeList)
        {
            long lngRes = 0;
            m_arrChargeList = new ArrayList();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderGroupService", "m_lngGetOrderGroupDetailByGroupID");
            if (lngRes < 0)
            {
                return -1;
            }
            clsORDERCHARGEDEPT_VO[] m_arrOrderDic = null;
            GetOrderDicChargeItem(order, out m_arrOrderDic);
            if (m_arrOrderDic != null && m_arrOrderDic.Length > 0)
            {
                for (int i = 0; i < m_arrOrderDic.Length; i++)
                {
                    m_arrChargeList.Add(m_arrOrderDic[i]);
                }
            }
            clsORDERCHARGEDEPT_VO[] m_arrOrderDic2 = null;
            GetOrderDicUsageChargeItem(order, out m_arrOrderDic2);
            if (m_arrOrderDic2 != null && m_arrOrderDic2.Length > 0)
            {
                for (int i = 0; i < m_arrOrderDic2.Length; i++)
                {
                    m_arrChargeList.Add(m_arrOrderDic2[i]);
                }
            }
            return lngRes;
        }



        #region 通过医嘱单记录添加收费项目到住院诊疗项目收费项目执行客户表(T_OPR_BIH_ORDERCHARGEDEPT)
        /// <summary> 
        /// 医嘱VO  收费项目到住院诊疗项目收费项目执行客户表
        /// </summary>
        /// <param name="order"></param>
        [AutoComplete]
        public void GetOrderDicChargeItem(clsBIHOrder order, out clsORDERCHARGEDEPT_VO[] m_arrOrderDic)
        {

            m_arrOrderDic = null;
            long lngRes = 0;
            long lngAff = 0;

            int FLAG_INT = 1;//创建标志:收费项来源于 0-主诊疗项目，1-诊疗项目,2－带出的用法，3－自定义新开
            string strDefaultItemID = "";  //--主收费项目ID
            decimal dmlDefaultAmount = 0;  //-一次领量
            decimal dmlDefaultDOSAGE = 0;  //-一次剂量
            int intIsRich = 0;                  //--收费项目的贵重标志
            decimal dmlAmount = 0;              //领量
            decimal SINGLEAMOUNT_DEC = 0;       //补一次的领量
            int intExecuteType = 0;             //--医嘱执行类型{执行类型{1=长期;2=临时;3=出院带药}}
            string strCalcCateID = "";          //--项目住院核算类别
            string strINvCateID = "";           //--项目住院发票类别
            decimal dmlPrice = 0;          //--住院单价(=项目价格/包装量)
            int intTimes = 0;                   //--单位频率执行的次数
            int intOUTGETMEDDAYS_INT = 1;          //出院带药天数(当执行类型=3出院带药时可用)

            string SPEC_VCHR = "";             //规格

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            System.Data.IDataParameter[] arrParams = null;
            DataTable dtbResult = new DataTable();
            DataTable dtbResultTest = new DataTable();
            string strSQL = "";

            dmlDefaultAmount = decimal.Parse(order.m_dmlGet.ToString());
            // 一次剂量
            dmlDefaultDOSAGE = decimal.Parse(order.m_dmlDosage.ToString());
            intTimes = order.m_intFreqTime;//
            intOUTGETMEDDAYS_INT = order.m_intOUTGETMEDDAYS_INT;
            // 药品来源: 0 药房(全计费,摆药); 1 患者自备(只收费用法加收项目,不摆药); 2 科室基数(全计费，不摆药)
            if (order.RateType != 0 && order.RateType != 2)
            {
                return;
            }
            // --单位频率执行的次数
            if (intTimes == 0)
            {
                intTimes = 1;
            }

            // 加上是否摆药及医保信息
            strSQL = @"select c.ITEMID_CHR DefaultItemID,
                               A.ItemID_Chr,
                               A.QTY_INT,
                               A.type_int,
                               B.ItemName_Vchr,
                               B.ItemIPUnit_Chr,
                               decode(b.IPCHARGEFLG_INT,
                                      1,
                                      Round(B.ItemPrice_Mny / B.PackQty_Dec, 4),
                                      0,
                                      B.ItemPrice_Mny,
                                      Round(B.ItemPrice_Mny / B.PackQty_Dec, 4)) ItemPriceA,
                               B.ItemIPCalcType_Chr,
                               B.ItemIpInvType_Chr,
                               B.IsRich_Int,
                               B.DOSAGE_DEC,
                               B.ITEMSPEC_VCHR,
                               g.POFLAG_INT,
                               h.typename_vchr MedicareTypeName,
                               A.USESCOPE_INT
                          from T_Aid_Bih_OrderDic_Charge A,
                               T_Bse_ChargeItem          B,
                               t_bse_bih_orderdic        c,
                               T_BSE_MEDICINE            g,
                               T_AID_MEDICARETYPE        h
                         where a.OrderDicID_Chr = ?
                           and A.ItemID_Chr = B.ItemID_Chr
                           and a.orderdicid_chr = c.orderdicid_chr
                           and b.itemid_chr = g.medicineid_chr(+)
                           and b.INPINSURANCETYPE_VCHR = h.typeid_chr(+)
                         order by B.ITEMCODE_VCHR ";


            objHRPSvc.CreateDatabaseParameter(1, out arrParams);
            arrParams[0].Value = order.m_strOrderDicID;
            DataTable dtbResult2 = new DataTable();
            lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult2, arrParams);
            if (lngRes > 0 && dtbResult2.Rows.Count > 0)
            {
                m_arrOrderDic = new clsORDERCHARGEDEPT_VO[dtbResult2.Rows.Count];
                for (int i = 0; i < dtbResult2.Rows.Count; i++)
                {
                    int CONTINUEUSETYPE_INT = 0;//续用类型 {0=不续用;1=全部续用;2-长嘱续用}
                    // --获取收费项目的贵重标志
                    intIsRich = clsConverter.ToInt(dtbResult2.Rows[i]["IsRich_Int"].ToString());
                    string ItemID_Chr = clsConverter.ToString(dtbResult2.Rows[i]["ItemID_Chr"].ToString());
                    strDefaultItemID = clsConverter.ToString(dtbResult2.Rows[i]["DefaultItemID"].ToString());

                    string ItemName_Vchr = clsConverter.ToString(dtbResult2.Rows[i]["ItemName_Vchr"].ToString());
                    string ItemIPUnit_Chr = clsConverter.ToString(dtbResult2.Rows[i]["ItemIPUnit_Chr"].ToString());

                    int type_int = clsConverter.ToInt(dtbResult2.Rows[i]["type_int"].ToString());
                    int Qty_Int = clsConverter.ToInt(dtbResult2.Rows[i]["Qty_Int"].ToString());
                    decimal DOSAGE_DEC = clsConverter.ToDecimal(dtbResult2.Rows[i]["DOSAGE_DEC"].ToString());
                    //     --设置项目住院核算类别
                    strCalcCateID = clsConverter.ToString(dtbResult2.Rows[i]["ItemIPCalcType_Chr"].ToString());
                    //     --设置项目住院发票类别
                    strINvCateID = clsConverter.ToString(dtbResult2.Rows[i]["ItemIpInvType_Chr"].ToString());
                    //    --设置住院单价(=项目价格/包装量)
                    dmlPrice = clsConverter.ToDecimal(dtbResult2.Rows[i]["ItemPriceA"].ToString());
                    //规格
                    SPEC_VCHR = clsConverter.ToString(dtbResult2.Rows[i]["ITEMSPEC_VCHR"].ToString());
                    //是否摆药的标志从药品字典表中的“是否进入医嘱”中取出
                    int POFLAG_INT = clsConverter.ToInt(dtbResult2.Rows[i]["POFLAG_INT"].ToString());

                    // 医保信息
                    string INSURACEDESC_VCHR = clsConverter.ToString(dtbResult2.Rows[i]["MedicareTypeName"].ToString().Trim());
                    //--设置领量
                    if (ItemID_Chr.Equals(strDefaultItemID))
                    {
                        FLAG_INT = 0;//创建标志:收费项来源于 0-主诊疗项目，1-诊疗项目,2－带出的用法，3－自定义新开                            
                        dmlAmount = dmlDefaultAmount;//--住收费项目
                        if (intExecuteType == 3)
                        {

                            dmlAmount = dmlAmount * intOUTGETMEDDAYS_INT;//领量＊天数
                        }
                        // 补一次的领量 
                        if (type_int == 1)//{1=领量单位;2=剂量单位}
                        {
                            //SINGLEAMOUNT_DEC = decimal.Ceiling(dmlDefaultDOSAGE);
                            SINGLEAMOUNT_DEC = decimal.Ceiling(Qty_Int);
                        }
                        else
                        {
                            SINGLEAMOUNT_DEC = decimal.Ceiling(dmlDefaultDOSAGE / DOSAGE_DEC);
                        }
                    }
                    else
                    {
                        //--计算非主收费项目的收费
                        /*
                         *业务描述：
                         *    if(TYPE_INT==1[领量单位]) then {=次数*领量}
                         *    if(TYPE_INT==2[剂量单位]) then {=算法如算主收费项目；医生下的剂量是默认的那个}
                         *       领量 = 周期用药次数 * 用量
                         *       用量 = 医生下的剂量/单位剂量
                         */
                        if (type_int == 1)
                        {
                            dmlAmount = intTimes * Qty_Int;
                            // 补一次的领量 
                            SINGLEAMOUNT_DEC = Qty_Int;
                        }
                        else
                        {
                            dmlAmount = intTimes * (Qty_Int / DOSAGE_DEC);
                            // 补一次的领量 
                            SINGLEAMOUNT_DEC = decimal.Ceiling(Qty_Int / DOSAGE_DEC);
                        }
                        FLAG_INT = 1;
                    }

                    m_arrOrderDic[i] = new clsORDERCHARGEDEPT_VO();
                    m_arrOrderDic[i].m_strOrderid_chr = order.m_strOrderID;
                    m_arrOrderDic[i].m_strOrderdicid_chr = order.m_strOrderDicID;
                    m_arrOrderDic[i].m_strChargeitemid_chr = ItemID_Chr;

                    m_arrOrderDic[i].m_strCreatearea_chr = order.m_strCREATEAREA_ID;
                    m_arrOrderDic[i].m_strChargeitemname_chr = ItemName_Vchr;
                    m_arrOrderDic[i].m_strSpec_vchr = SPEC_VCHR;

                    m_arrOrderDic[i].m_strUnit_vchr = ItemIPUnit_Chr.Trim();//Unit_Vchr 住院单位{=收费项目.住院单位}
                    m_arrOrderDic[i].m_decAmount_dec = dmlAmount;//AMount_Dec    领量
                    m_arrOrderDic[i].m_decUnitprice_dec = dmlPrice;//UnitPrice_Dec  住院单价{=收费项目.住院单价}

                    m_arrOrderDic[i].m_intFLAG_INT = FLAG_INT;//FLAG_INT 创建标志:收费项来源于 0-主诊疗项目，1-诊疗项目,2－带出的用法，3－自定义新开
                    m_arrOrderDic[i].m_decSINGLEAMOUNT_DEC = SINGLEAMOUNT_DEC;//补一次的领量

                    m_arrOrderDic[i].m_intRATETYPE_INT = 1;//是否计费 0-不计费 1-计费
                    m_arrOrderDic[i].m_strINSURACEDESC_VCHR = INSURACEDESC_VCHR;//医保信息
                    m_arrOrderDic[i].m_intCONTINUEUSETYPE_INT = CONTINUEUSETYPE_INT;//续用类型 {0=不续用;1=全部续用;2-长嘱续用}
                }
            }
            objHRPSvc.Dispose();
        }
        #endregion

        #region 通过医嘱单记录添加收费项目记录用法到住院诊疗项目收费项目执行客户表(T_OPR_BIH_ORDERCHARGEDEPT)
        /// <summary>
        /// 医嘱VO   用法到住院诊疗项目收费项目执行客户表
        /// </summary>
        /// <param name="order"></param>
        [AutoComplete]
        public void GetOrderDicUsageChargeItem(clsBIHOrder order, out clsORDERCHARGEDEPT_VO[] m_arrOrderDic)
        {
            m_arrOrderDic = null;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            System.Data.IDataParameter[] arrParams = null;
            DataTable dtbResult = new DataTable();
            long lngRes = 0;
            long lngAff = 0;

            int FLAG_INT = 2;//创建标志:收费项来源于 0-主诊疗项目，1-诊疗项目,2－带出的用法，3－自定义新开
            // --补登:{1=计费-摆药;2=计费-不摆药;3=不计费-摆药;4=不计费-不摆药};只用于临时医嘱
            int intIsRich;       //       --收费项目的贵重标志
            string strChargeID;
            decimal dmlAmount;//     --量
            decimal SINGLEAMOUNT_DEC = 0;       //补一次的领量
            string strCalcCateID;//      --项目住院核算类别
            string strInvCateID;//       --项目住院发票类别
            int intTimes;//               --单位频率执行的次数
            int intTimesBak;//            --单位频率执行的次数

            decimal dblBihqty;
            decimal dblDosage;
            string SPEC_VCHR = "";             //规格
            DateTime CREATEDATE_DAT = DateTime.Now; //创建时间

            string strUsageID = "";            //用法ID 
            string strSQL = "";

            intTimes = order.m_intFreqTime;
            strUsageID = order.m_strDosetypeID;
            // 药品来源: 0 药房(全计费,摆药); 1 患者自备(只收费用法加收项目,不摆药); 2 科室基数(全计费，不摆药)
            if (order.RateType == 0 || order.RateType == 1 || order.RateType == 2)
            { }
            else
            {
                return;
            }
            if (intTimes == 0)
            {
                intTimes = 1;
            }
            strSQL = @"select A.ItemID_Chr,
                               A.BIHQTY_DEC,
                               A.BIHTYPE_INT,
                               A.ContinueUseType_Int,
                               B.ItemName_Vchr,
                               B.ItemIPUnit_Chr,
                               B.DOSAGE_DEC,
                               decode(b.IPCHARGEFLG_INT,
                                      0,
                                      Round(B.ItemPrice_Mny / B.PackQty_Dec, 4),
                                      1,
                                      B.ItemPrice_Mny,
                                      Round(B.ItemPrice_Mny / B.PackQty_Dec, 4)) ItemPriceA,
                               B.ItemIPCalcType_Chr,
                               B.ItemIpInvType_Chr,
                               B.IsRich_Int,
                               B.ITEMSPEC_VCHR,
                               g.POFLAG_INT,
                               h.typename_vchr MedicareTypeName
                          from T_BSE_ChargeItemUsageGroup A,
                               T_Bse_ChargeItem           B,
                               T_BSE_MEDICINE             g,
                               T_AID_MEDICARETYPE         h
                         where A.UsageID_Chr = ?
                           and A.ItemID_Chr = B.ItemID_Chr
                           and b.itemid_chr = g.medicineid_chr(+)
                           and b.INPINSURANCETYPE_VCHR = h.typeid_chr(+)
                         order by B.ITEMCODE_VCHR ";
            objHRPSvc.CreateDatabaseParameter(1, out arrParams);
            arrParams[0].Value = strUsageID;
            lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, arrParams);

            if (lngRes > 0 && dtbResult.Rows.Count > 0)
            {
                m_arrOrderDic = new clsORDERCHARGEDEPT_VO[dtbResult.Rows.Count];
                for (int i = 0; i < dtbResult.Rows.Count; i++)
                {

                    int CONTINUEUSETYPE_INT = clsConverter.ToInt(dtbResult.Rows[i]["ContinueUseType_Int"].ToString());
                    string ItemID_Chr = clsConverter.ToString(dtbResult.Rows[i]["ItemID_Chr"].ToString());
                    decimal BIHQTY_DEC = clsConverter.ToDecimal(dtbResult.Rows[i]["BIHQTY_DEC"].ToString());
                    decimal DOSAGE_DEC = clsConverter.ToDecimal(dtbResult.Rows[i]["DOSAGE_DEC"].ToString());
                    int BIHTYPE_INT = clsConverter.ToInt(dtbResult.Rows[i]["BIHTYPE_INT"].ToString());
                    string ItemIpInvType_Chr = clsConverter.ToString(dtbResult.Rows[i]["ItemIpInvType_Chr"].ToString());
                    string ItemName_Vchr = clsConverter.ToString(dtbResult.Rows[i]["ItemName_Vchr"].ToString());
                    string ItemIPUnit_Chr = clsConverter.ToString(dtbResult.Rows[i]["ItemIPUnit_Chr"].ToString());
                    decimal ItemPriceA = clsConverter.ToDecimal(dtbResult.Rows[i]["ItemPriceA"].ToString());
                    //规格
                    SPEC_VCHR = clsConverter.ToString(dtbResult.Rows[i]["ITEMSPEC_VCHR"].ToString());

                    //是否摆药的标志从药品字典表中的“是否进入医嘱”中取出
                    int POFLAG_INT = clsConverter.ToInt(dtbResult.Rows[i]["POFLAG_INT"].ToString());
                    // 医保信息
                    string INSURACEDESC_VCHR = clsConverter.ToString(dtbResult.Rows[i]["MedicareTypeName"].ToString().Trim());


                    intIsRich = clsConverter.ToInt(dtbResult.Rows[i]["IsRich_Int"].ToString());
                    intTimesBak = intTimes;
                    //strSQL = "   select lpad(SEQ_PCHARGEID.Nextval,18,'0') PChargeID_Chr   from dual ";
                    //DataTable dtbResult2 = new DataTable();
                    //objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult2);
                    //strChargeID = clsConverter.ToString(dtbResult2.Rows[0]["PChargeID_Chr"].ToString());

                    // --计算用法领量
                    /*
                    *业务描述：
                    *    if(TYPE_INT==1[领量单位]) then {=次数*领量}
                    *    if(TYPE_INT==2[剂量单位]) then {=算法如算主收费项目；医生下的剂量是默认的那个}
                    *       领量 = 周期用药次数 * 用量
                    *       用量 = 医生下的剂量/单位剂量
                    */
                    /*
                    */
                    if (BIHQTY_DEC == 0)
                    {
                        dblBihqty = 1;
                    }
                    else
                    {
                        dblBihqty = BIHQTY_DEC;
                    }
                    if (DOSAGE_DEC == 0)
                    {
                        dblDosage = 1;
                    }
                    else
                    {
                        dblDosage = DOSAGE_DEC;
                    }
                    if (BIHTYPE_INT == 1)
                    {
                        if (CONTINUEUSETYPE_INT == 0)//续用
                        {
                            dmlAmount = intTimes * dblBihqty;
                        }
                        else
                        {
                            dmlAmount = dblBihqty;
                        }
                        // 补一次的领量 
                        SINGLEAMOUNT_DEC = dblBihqty;
                    }
                    else
                    {
                        if (CONTINUEUSETYPE_INT == 0)//续用
                        {
                            dmlAmount = intTimes * (dblBihqty / dblDosage);
                            // 补一次的领量 
                            SINGLEAMOUNT_DEC = decimal.Ceiling(dblBihqty / dblDosage);
                        }
                        else
                        {
                            dmlAmount = dblBihqty;
                            // 补一次的领量  
                            SINGLEAMOUNT_DEC = dblBihqty;
                        }
                    }
                    m_arrOrderDic[i] = new clsORDERCHARGEDEPT_VO();

                    m_arrOrderDic[i].m_strOrderid_chr = order.m_strOrderID;
                    m_arrOrderDic[i].m_strOrderdicid_chr = order.m_strOrderDicID;
                    m_arrOrderDic[i].m_strChargeitemid_chr = ItemID_Chr;

                    m_arrOrderDic[i].m_strCreatearea_chr = order.m_strCREATEAREA_ID;
                    m_arrOrderDic[i].m_strChargeitemname_chr = ItemName_Vchr;
                    m_arrOrderDic[i].m_strSpec_vchr = SPEC_VCHR;

                    m_arrOrderDic[i].m_strUnit_vchr = ItemIPUnit_Chr.Trim();//Unit_Vchr 住院单位{=收费项目.住院单位}
                    m_arrOrderDic[i].m_decAmount_dec = dmlAmount;//AMount_Dec    领量
                    m_arrOrderDic[i].m_decUnitprice_dec = ItemPriceA;//UnitPrice_Dec  住院单价{=收费项目.住院单价}

                    m_arrOrderDic[i].m_intFLAG_INT = FLAG_INT;//FLAG_INT 创建标志:收费项来源于 0-主诊疗项目，1-诊疗项目,2－带出的用法，3－自定义新开
                    m_arrOrderDic[i].m_decSINGLEAMOUNT_DEC = SINGLEAMOUNT_DEC;//补一次的领量

                    m_arrOrderDic[i].m_intRATETYPE_INT = 1;//是否计费 0-不计费 1-计费
                    m_arrOrderDic[i].m_strINSURACEDESC_VCHR = INSURACEDESC_VCHR;//医保信息
                    m_arrOrderDic[i].m_intCONTINUEUSETYPE_INT = CONTINUEUSETYPE_INT;//续用类型 {0=不续用;1=全部续用;2-长嘱续用}
                }
            }
        }
        #endregion

        #endregion

        #region 查询诊疗项目对应的主收费项目是否需要皮试
        /// <summary>
        /// 查询诊疗项目对应的主收费项目是否需要皮试
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_arrOrderDic">诊疗项目id数组</param>
        /// <param name="m_arrFeelList">皮试诊疗项目id数组</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetFeelListbyOrderDic(System.Security.Principal.IPrincipal p_objPrincipal, ArrayList m_arrOrderDic, out ArrayList m_arrFeelList)
        {
            long lngRes = 0;
            m_arrFeelList = new ArrayList();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderGroupService", "m_lngGetFeelListbyOrderDic");
            if (lngRes < 0)
            {
                return -1;
            }
            if (m_arrOrderDic.Count <= 0)
            {
                return 1;
            }
            string m_strOrderList = "";
            for (int i = 0; i < m_arrOrderDic.Count; i++)
            {
                m_strOrderList += "'" + m_arrOrderDic[i].ToString().Trim() + "'";
                m_strOrderList += ",";
            }
            m_strOrderList = m_strOrderList.TrimEnd(",".ToCharArray());

            string strSQL = @"
                    SELECT distinct a.orderdicid_chr
                    FROM t_bse_bih_orderdic a, t_bse_chargeitem b, t_bse_medicine c
                    WHERE a.itemid_chr = b.itemid_chr
                    AND b.itemsrcid_vchr = c.medicineid_chr
                    AND b.itemsrctype_int = 1
                    AND c.hype_int = 1
                    AND a.orderdicid_chr in ([m_strOrderList])              
                   ";
            strSQL = strSQL.Replace("[m_strOrderList]", m_strOrderList);
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                if (dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    for (int i = 0; i < dtbResult.Rows.Count; i++)
                    {
                        m_arrFeelList.Add(dtbResult.Rows[i]["orderdicid_chr"].ToString().Trim());
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

        [AutoComplete]
        public long GetTheOrderDicWBPy(out DataTable objDT)
        {

            /*<---------------------------------------------------------*/
            string strSql = @"
           select a.orderdicid_chr,a.name_chr from t_bse_bih_orderdic  a where 
((a.wbcode_chr='' or a.wbcode_chr is null) and ( a.pycode_chr is null or a.pycode_chr='')) and rownum<=1000
            ";

            objDT = new DataTable();
            long ret = 0;
            try
            {
                ret = 0;
                ret = new clsHRPTableService().DoGetDataTable(strSql, ref objDT);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return ret;
        }

        [AutoComplete]
        public long SaveTheOrderDicWBPy(ArrayList myarr)
        {
            long lngAff = 0;
            long lngRes = 0;


            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = "";


            try
            {


                //((clsOrderBooking)OrderBookingList[i])
                strSQL = @"
                
                   update t_bse_bih_orderdic a set a.wbcode_chr=? ,a.pycode_chr=? where a.orderdicid_chr=?
                    ";
                //m_lngUpdateOrderBooking(m_arrOrderBooking[i]);
                DbType[] dbTypes = new DbType[] { 
                          DbType.String,DbType.String,DbType.String,
                     
                        };
                object[][] objValues = new object[3][];
                if (myarr.Count > 0)
                {
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[myarr.Count];//初始化
                    }
                    int n = 0;
                    for (int k1 = 0; k1 < myarr.Count; k1++)
                    {
                        clsBIHOrderDic order = (clsBIHOrderDic)myarr[k1];
                        n = -1;
                        objValues[++n][k1] = order.m_strWBCode;
                        objValues[++n][k1] = order.m_strPYCode;
                        objValues[++n][k1] = order.m_strOrderDicID;



                    }
                    lngRes = objHRPSvc.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);

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

        /// <summary>
        /// 检查是否存在相同的医嘱组套名
        /// </summary>
        /// <param name="m_strNAME_CHR"></param>
        /// <param name="m_blSame"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetTheOrderGroupName(string m_strNAME_CHR, out bool m_blSame)
        {
            m_blSame = false;
            /*<---------------------------------------------------------*/
            string strSql = @"
            select count(a.groupid_chr) m_sum from t_aid_bih_ordergroup a
            where  lower( a.name_chr)=? 
            ";

            DataTable dtbResult = new DataTable();
            long ret = 0;
            try
            {
                System.Data.IDataParameter[] arrParams = null;
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(1, out arrParams);
                int n = -1;
                n++; arrParams[n].Value = m_strNAME_CHR.ToLower();
                ret = objHRPSvc.lngGetDataTableWithParameters(strSql, ref dtbResult, arrParams);
                if (ret > 0 && dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    int m_sum = int.Parse(dtbResult.Rows[0]["m_sum"].ToString().Trim());
                    if (m_sum > 0)
                    {
                        m_blSame = true;
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
            return ret;
        }
    }
}
