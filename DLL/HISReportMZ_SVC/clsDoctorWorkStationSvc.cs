using System;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
using System.EnterpriseServices;
using System.Data;
using System.Collections;
using Oracle.DataAccess.Client;
using com.digitalwave.iCare.middletier.HIS;//HISMedStore_SVC.dll

namespace com.digitalwave.iCare.middletier.HIS.Reports
{
    /// <summary>
    /// clsDoctorWorkStationSvc 医生工作站中间件
    /// </summary>
    [Transaction(TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsDoctorWorkStationSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 构造
        public clsDoctorWorkStationSvc()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        #endregion

        #region 查找收费项目
        [AutoComplete]
        private void m_mthGetType(string ID, ref string QueryColname)
        {
            bool blnTmp = true;
            try
            {
                if (ID.StartsWith("%"))
                {
                    ID = ID.Replace("%", "");
                }
                long lng = Convert.ToInt64(ID.Replace("/", ""));
            }
            catch { blnTmp = false; }
            if (blnTmp)
            {
                QueryColname = "itemcode_vchr";
            }
        }

        /// <summary>
        /// 查找西药收费项目
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="QueryColname"></param>
        /// <param name="ID"></param>
        /// <param name="strPatientTypeID"></param>
        /// <param name="dt"></param>
        /// <param name="strEmployID"></param>
        /// <param name="UseAliasTable"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthFindWMedicineByID(System.Security.Principal.IPrincipal p_objPrincipal, string QueryColname, string ID, string strPatientTypeID, out DataTable dt, string strEmployID, bool UseAliasTable)
        {
            dt = new DataTable();
            long lngRes = 0;
            string strSQL = "";
            string tmpColName = QueryColname;

            if (QueryColname != "itemid_chr")
            {
                m_mthGetType(ID, ref QueryColname);
            }

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;

            if (UseAliasTable)
            {
                if (QueryColname.ToLower() == "itempycode_chr")
                {
                    tmpColName = "pycode_vchr";
                }
                else if (QueryColname.ToLower() == "itemwbcode_chr")
                {
                    tmpColName = "wbcode_vchr";
                }
                else if (QueryColname.ToLower() == "itemengname_vchr")
                {
                    tmpColName = "itemname_vchr";
                }

                strSQL = @"select a.itemid_chr, a.itemname_vchr, a.itemspec_vchr, a.itemengname_vchr,
                                 a.itemopunit_chr, a.itemipunit_chr, b.deptprep_int, a.dosageunit_chr,
                                 a.packqty_dec, round (a.itemprice_mny / a.packqty_dec, 4) submoney,
                                 a.itemprice_mny, a." + QueryColname + @" as type, b.noqtyflag_int, b.mindosage_dec,
                                 b.maxdosage_dec, b.adultdosage_dec, b.childdosage_dec,
                                 b.nmldosage_dec, b.hype_int, a.opchargeflg_int, a.usageid_chr,
                                 a.itemcommname_vchr, b.ispoison_chr, b.isanaesthesia_chr,
                                 b.ischlorpromazine_chr, b.ischlorpromazine2_chr, a.itemopinvtype_chr,
                                 c.usagename_vchr, a.dosage_dec, a.itemcode_vchr, f.precent_dec,
                                 g.partname, h.freqid_chr as freqid, h.freqname_chr as freqname,
                                 h.times_int as freqtimes, h.days_int as freqdays,
                                 y.typename_vchr as ybtypename
                            from t_bse_chargeitem a,
                                 t_bse_medicine b,
                                 t_bse_usagetype c,
                                 t_bse_chargecatmap d,
                                 (select itemid_chr, precent_dec
                                    from t_aid_inschargeitem
                                   where copayid_chr = ?) f,
                                 ar_apply_partlist g,
                                 t_aid_recipefreq h,
                                 t_aid_medicaretype y
                           where a.itemsrcid_vchr = b.medicineid_chr(+)                             
                             and a.ifstop_int = 0
                             and a.insurancetype_vchr = y.typeid_chr(+)
                             and a.usageid_chr = c.usageid_chr(+)
                             and a.itemopinvtype_chr = d.catid_chr(+)
                             and d.groupid_chr = '0001'
                             and d.internalflag_int = 0
                             and a.itemid_chr = f.itemid_chr(+)
                             and a.itemchecktype_chr = g.partid(+)
                             and a.freqid_chr = h.freqid_chr(+) 
                             and exists (
                                           select 1
                                             from t_bse_itemalias_drug drug
                                            where a.itemid_chr = drug.itemid_chr
                                              and drug." + tmpColName + @" like ?)
                        order by a." + QueryColname;
            }
            else
            {
                strSQL = @"select a.itemid_chr, a.itemname_vchr, a.itemspec_vchr, a.itemengname_vchr,
                                 a.itemopunit_chr, a.itemipunit_chr, b.deptprep_int, a.dosageunit_chr,
                                 a.packqty_dec, round (a.itemprice_mny / a.packqty_dec, 4) submoney,
                                 a.itemprice_mny, a." + QueryColname + @" as type, b.noqtyflag_int, b.mindosage_dec,
                                 b.maxdosage_dec, b.adultdosage_dec, b.childdosage_dec,
                                 b.nmldosage_dec, b.hype_int, a.opchargeflg_int, a.usageid_chr,
                                 a.itemcommname_vchr, b.ispoison_chr, b.isanaesthesia_chr,
                                 b.ischlorpromazine_chr, b.ischlorpromazine2_chr, a.itemopinvtype_chr,
                                 c.usagename_vchr, a.dosage_dec, a.itemcode_vchr, f.precent_dec,
                                 g.partname, h.freqid_chr as freqid, h.freqname_chr as freqname,
                                 h.times_int as freqtimes, h.days_int as freqdays,
                                 y.typename_vchr as ybtypename
                            from t_bse_chargeitem a,
                                 t_bse_medicine b,
                                 t_bse_usagetype c,
                                 t_bse_chargecatmap d,
                                 (select itemid_chr, precent_dec
                                    from t_aid_inschargeitem
                                   where copayid_chr = ?) f,
                                 ar_apply_partlist g,
                                 t_aid_recipefreq h,
                                 t_aid_medicaretype y
                           where a.itemsrcid_vchr = b.medicineid_chr(+)
                             and (upper (a." + QueryColname + @") like ? or upper (a.itemopcode_chr) like ?)
                             and a.ifstop_int = 0
                             and a.insurancetype_vchr = y.typeid_chr(+)
                             and a.usageid_chr = c.usageid_chr(+)
                             and a.itemopinvtype_chr = d.catid_chr(+)
                             and d.groupid_chr = '0001'
                             and d.internalflag_int = 0
                             and a.itemid_chr = f.itemid_chr(+)
                             and a.itemchecktype_chr = g.partid(+)
                             and a.freqid_chr = h.freqid_chr(+)
                        order by a." + QueryColname;
            }

            //以“/”开头是查询常用药
            if (ID.IndexOf("/") > -1)
            {
                if (UseAliasTable)
                {
                    strSQL = @"select distinct  a.itemid_chr, a.itemname_vchr, a.itemspec_vchr,
                                            a.itemengname_vchr, a.selfdefine_int, a.itemchecktype_chr,
                                            a.itemopunit_chr, a.itemipunit_chr, b.deptprep_int,
                                            a.dosageunit_chr, a.packqty_dec,
                                            round (a.itemprice_mny / a.packqty_dec, 4) submoney,
                                            a.itemprice_mny, a.itemcode_vchr type, b.noqtyflag_int,
                                            b.mindosage_dec, b.maxdosage_dec, b.adultdosage_dec,
                                            b.childdosage_dec, b.nmldosage_dec, b.hype_int,
                                            a.opchargeflg_int, a.usageid_chr, a.itemcommname_vchr,
                                            b.ispoison_chr, b.isanaesthesia_chr, b.ischlorpromazine_chr,
                                            b.ischlorpromazine2_chr, a.itemopinvtype_chr,
                                            c.usagename_vchr, a.dosage_dec, a.itemcode_vchr,
                                            f.precent_dec, g.partname, i.freqid_chr as freqid,
                                            i.freqname_chr as freqname, i.times_int as freqtimes,
                                            i.days_int as freqdays, y.typename_vchr as ybtypename
                                       from t_bse_chargeitem a,
                                            t_bse_medicine b,
                                            t_bse_usagetype c,
                                            (select itemid_chr
                                               from t_aid_comusechargeitem
                                              where createrid_chr = ? and type_int = 0
                                             union all
                                             select a.itemid_chr
                                               from t_aid_comusechargeitem a,
                                                    (select a.deptid_chr
                                                       from t_bse_deptemp a
                                                      where a.end_dat is null and a.empid_chr = ?) b
                                              where a.deptid_chr = b.deptid_chr and type_int = 0) d,
                                            (select itemid_chr, precent_dec
                                               from t_aid_inschargeitem
                                              where copayid_chr = ?) f,
                                            ar_apply_partlist g,
                                            t_bse_chargecatmap h,
                                            t_aid_recipefreq i,
                                            t_aid_medicaretype y
                                      where a.itemsrcid_vchr = b.medicineid_chr(+)
                                        and a.ifstop_int = 0
                                        and a.insurancetype_vchr = y.typeid_chr(+)
                                        and a.usageid_chr = c.usageid_chr(+)
                                        and a.itemid_chr = d.itemid_chr
                                        and a.itemchecktype_chr = g.partid(+)
                                        and a.itemopinvtype_chr = h.catid_chr(+)
                                        and h.groupid_chr = '0001'
                                        and a.freqid_chr = i.freqid_chr(+)
                                        and a.itemid_chr = f.itemid_chr(+)                                        
                                        and exists (
                                                   select 1
                                                     from t_bse_itemalias_drug drug
                                                    where a.itemid_chr = drug.itemid_chr
                                                      and drug." + tmpColName + @" like ?)
                                   order by a.itemcode_vchr";
                }
                else
                {
                    strSQL = @"select distinct  a.itemid_chr, a.itemname_vchr, a.itemspec_vchr,
                                            a.itemengname_vchr, a.selfdefine_int, a.itemchecktype_chr,
                                            a.itemopunit_chr, a.itemipunit_chr, b.deptprep_int,
                                            a.dosageunit_chr, a.packqty_dec,
                                            round (a.itemprice_mny / a.packqty_dec, 4) submoney,
                                            a.itemprice_mny, a.itemcode_vchr type, b.noqtyflag_int,
                                            b.mindosage_dec, b.maxdosage_dec, b.adultdosage_dec,
                                            b.childdosage_dec, b.nmldosage_dec, b.hype_int,
                                            a.opchargeflg_int, a.usageid_chr, a.itemcommname_vchr,
                                            b.ispoison_chr, b.isanaesthesia_chr, b.ischlorpromazine_chr,
                                            b.ischlorpromazine2_chr, a.itemopinvtype_chr,
                                            c.usagename_vchr, a.dosage_dec, a.itemcode_vchr,
                                            f.precent_dec, g.partname, i.freqid_chr as freqid,
                                            i.freqname_chr as freqname, i.times_int as freqtimes,
                                            i.days_int as freqdays, y.typename_vchr as ybtypename
                                       from t_bse_chargeitem a,
                                            t_bse_medicine b,
                                            t_bse_usagetype c,
                                            (select itemid_chr
                                               from t_aid_comusechargeitem
                                              where createrid_chr = ? and type_int = 0
                                             union all
                                             select a.itemid_chr
                                               from t_aid_comusechargeitem a,
                                                    (select a.deptid_chr
                                                       from t_bse_deptemp a
                                                      where a.end_dat is null and a.empid_chr = ?) b
                                              where a.deptid_chr = b.deptid_chr and type_int = 0) d,
                                            (select itemid_chr, precent_dec
                                               from t_aid_inschargeitem
                                              where copayid_chr = ?) f,
                                            ar_apply_partlist g,
                                            t_bse_chargecatmap h,
                                            t_aid_recipefreq i,
                                            t_aid_medicaretype y
                                      where a.itemsrcid_vchr = b.medicineid_chr(+)
                                        and a.ifstop_int = 0
                                        and a.insurancetype_vchr = y.typeid_chr(+)
                                        and a.usageid_chr = c.usageid_chr(+)
                                        and a.itemid_chr = d.itemid_chr
                                        and a.itemchecktype_chr = g.partid(+)
                                        and a.itemopinvtype_chr = h.catid_chr(+)
                                        and h.groupid_chr = '0001'
                                        and a.freqid_chr = i.freqid_chr(+)
                                        and a.itemid_chr = f.itemid_chr(+)
                                        and (upper (a." + QueryColname + @") like ? or upper (a.itemopcode_chr) like ?)
                                   order by a.itemcode_vchr";
                }

                if (UseAliasTable)
                {
                    objHRPSvc.CreateDatabaseParameter(4, out ParamArr);
                    ((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
                    ((OracleParameter)ParamArr[1]).OracleDbType = OracleDbType.Char;
                    ((OracleParameter)ParamArr[2]).OracleDbType = OracleDbType.Char;

                    ParamArr[0].Value = strEmployID;
                    ParamArr[1].Value = strEmployID;
                    ParamArr[2].Value = strPatientTypeID;
                    ParamArr[3].Value = ID.Replace("/", "") + "%";                    
                }
                else
                {
                    objHRPSvc.CreateDatabaseParameter(5, out ParamArr);
                    ((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
                    ((OracleParameter)ParamArr[1]).OracleDbType = OracleDbType.Char;
                    ((OracleParameter)ParamArr[2]).OracleDbType = OracleDbType.Char;

                    ParamArr[0].Value = strEmployID;
                    ParamArr[1].Value = strEmployID;
                    ParamArr[2].Value = strPatientTypeID;
                    ParamArr[3].Value = ID.Replace("/", "") + "%";
                    ParamArr[4].Value = ID.Replace("/", "") + "%";
                }
            }
            else
            {
                if (UseAliasTable)
                {
                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
                    ParamArr[0].Value = strPatientTypeID;
                    ParamArr[1].Value = ID + "%";                    
                }
                else
                {
                    objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                    ((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
                    ParamArr[0].Value = strPatientTypeID;
                    ParamArr[1].Value = ID + "%";
                    ParamArr[2].Value = ID + "%";
                }
            }

            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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
        
        /// <summary>
        /// 查找中药收费项目
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="QueryColname"></param>
        /// <param name="ID"></param>
        /// <param name="strPatientTypeID"></param>
        /// <param name="dt"></param>
        /// <param name="strEmployID"></param>
        /// <param name="UseAliasTable"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthFindCMedicineByID(System.Security.Principal.IPrincipal p_objPrincipal, string QueryColname, string ID, string strPatientTypeID, out DataTable dt, string strEmployID, bool UseAliasTable)
        {
            dt = new DataTable();
            long lngRes = 0;
            string strSQL = "";
            string tmpColName = QueryColname;

            if (QueryColname != "itemid_chr")
            {
                m_mthGetType(ID, ref QueryColname);
            }

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;

            if (UseAliasTable)
            {
                if (QueryColname.ToLower() == "itempycode_chr")
                {
                    tmpColName = "pycode_vchr";
                }
                else if (QueryColname.ToLower() == "itemwbcode_chr")
                {
                    tmpColName = "wbcode_vchr";
                }
                else if (QueryColname.ToLower() == "itemengname_vchr")
                {
                    tmpColName = "itemname_vchr";
                }

                strSQL = @"select    a.itemid_chr, a.itemname_vchr, a.itemspec_vchr, a.itemengname_vchr,
                                     b.deptprep_int, a.usageid_chr, c.usagename_vchr, a.dosageunit_chr,
                                     a.itemprice_mny, a." + QueryColname + @" as type,
                                     round (a.itemprice_mny / a.packqty_dec, 4) submoney, b.noqtyflag_int,
                                     b.mindosage_dec, a.itemopinvtype_chr, b.maxdosage_dec,
                                     b.adultdosage_dec, b.childdosage_dec, a.itemcommname_vchr,
                                     b.ispoison_chr, b.isanaesthesia_chr, b.ischlorpromazine_chr,
                                     b.ischlorpromazine2_chr, b.nmldosage_dec, a.itemipunit_chr,
                                     a.opchargeflg_int, a.packqty_dec, a.dosage_dec, a.itemcode_vchr,
                                     f.precent_dec, y.typename_vchr as ybtypename
                                from t_bse_chargeitem a,
                                     t_bse_medicine b,
                                     t_bse_usagetype c,
                                     t_bse_chargecatmap d,
                                     (select itemid_chr, precent_dec
                                        from t_aid_inschargeitem
                                       where copayid_chr = ?) f,
                                     t_aid_medicaretype y
                               where a.itemsrcid_vchr = b.medicineid_chr(+)
                                 and a.usageid_chr = c.usageid_chr(+)                                 
                                 and a.ifstop_int = 0
                                 and a.itemopinvtype_chr = d.catid_chr(+)
                                 and a.insurancetype_vchr = y.typeid_chr(+)
                                 and d.groupid_chr = '0002'
                                 and d.internalflag_int = 0
                                 and a.itemid_chr = f.itemid_chr(+)
                                 and exists (
                                               select 1
                                                 from t_bse_itemalias_drug drug
                                                where a.itemid_chr = drug.itemid_chr
                                                  and drug." + tmpColName + @" like ?)
                            order by a." + QueryColname;
            }
            else
            {
                strSQL = @"select    a.itemid_chr, a.itemname_vchr, a.itemspec_vchr, a.itemengname_vchr,
                                     b.deptprep_int, a.usageid_chr, c.usagename_vchr, a.dosageunit_chr,
                                     a.itemprice_mny, a." + QueryColname + @" as type,
                                     round (a.itemprice_mny / a.packqty_dec, 4) submoney, b.noqtyflag_int,
                                     b.mindosage_dec, a.itemopinvtype_chr, b.maxdosage_dec,
                                     b.adultdosage_dec, b.childdosage_dec, a.itemcommname_vchr,
                                     b.ispoison_chr, b.isanaesthesia_chr, b.ischlorpromazine_chr,
                                     b.ischlorpromazine2_chr, b.nmldosage_dec, a.itemipunit_chr,
                                     a.opchargeflg_int, a.packqty_dec, a.dosage_dec, a.itemcode_vchr,
                                     f.precent_dec, y.typename_vchr as ybtypename
                                from t_bse_chargeitem a,
                                     t_bse_medicine b,
                                     t_bse_usagetype c,
                                     t_bse_chargecatmap d,
                                     (select itemid_chr, precent_dec
                                        from t_aid_inschargeitem
                                       where copayid_chr = ?) f,
                                     t_aid_medicaretype y
                               where a.itemsrcid_vchr = b.medicineid_chr(+)
                                 and a.usageid_chr = c.usageid_chr(+)
                                 and (upper (a." + QueryColname + @") like ? or upper (a.itemopcode_chr) like ?)
                                 and a.ifstop_int = 0
                                 and a.itemopinvtype_chr = d.catid_chr(+)
                                 and a.insurancetype_vchr = y.typeid_chr(+)
                                 and d.groupid_chr = '0002'
                                 and d.internalflag_int = 0
                                 and a.itemid_chr = f.itemid_chr(+)
                            order by a." + QueryColname;
            }

            //以“/”开头是查询常用中药
            if (ID.IndexOf("/") > -1)
            {
                if (UseAliasTable)
                {
                    strSQL = @"select distinct a.itemid_chr, a.itemname_vchr, a.itemspec_vchr,
                                            a.itemengname_vchr, a.selfdefine_int, a.itemchecktype_chr,
                                            a.itemopunit_chr, a.itemipunit_chr, b.deptprep_int,
                                            a.dosageunit_chr, a.packqty_dec,
                                            round (a.itemprice_mny / a.packqty_dec, 4) submoney,
                                            a.itemprice_mny, a.itemcode_vchr type, b.noqtyflag_int,
                                            b.mindosage_dec, b.maxdosage_dec, b.adultdosage_dec,
                                            b.childdosage_dec, b.nmldosage_dec, b.hype_int,
                                            a.opchargeflg_int, a.usageid_chr, c.usagename_vchr,
                                            a.itemcommname_vchr, b.ispoison_chr, b.isanaesthesia_chr,
                                            b.ischlorpromazine_chr, b.ischlorpromazine2_chr,
                                            a.itemopinvtype_chr, a.dosage_dec, a.itemcode_vchr,
                                            f.precent_dec, y.typename_vchr as ybtypename
                                       from t_bse_chargeitem a,
                                            t_bse_medicine b,
                                            t_bse_usagetype c,
                                            (select itemid_chr
                                               from t_aid_comusechargeitem
                                              where createrid_chr = ? and type_int = 0
                                             union all
                                             select a.itemid_chr
                                               from t_aid_comusechargeitem a,
                                                    (select a.deptid_chr
                                                       from t_bse_deptemp a
                                                      where a.end_dat is null and a.empid_chr = ?) b
                                              where a.deptid_chr = b.deptid_chr and type_int = 0) d,
                                            (select itemid_chr, precent_dec
                                               from t_aid_inschargeitem
                                              where copayid_chr = ?) f,
                                            t_bse_chargecatmap h,
                                            t_aid_medicaretype y
                                      where a.itemsrcid_vchr = b.medicineid_chr(+)
                                        and a.ifstop_int = 0
                                        and a.usageid_chr = c.usageid_chr(+)
                                        and a.insurancetype_vchr = y.typeid_chr(+)
                                        and a.itemid_chr = d.itemid_chr
                                        and a.itemopinvtype_chr = h.catid_chr(+)
                                        and h.groupid_chr = '0002'
                                        and a.itemid_chr = f.itemid_chr(+)
                                        and exists (
                                                   select 1
                                                     from t_bse_itemalias_drug drug
                                                    where a.itemid_chr = drug.itemid_chr
                                                      and drug." + tmpColName + @" like ?)
                                   order by a.itemcode_vchr";
                }
                else
                {
                    strSQL = @"select distinct a.itemid_chr, a.itemname_vchr, a.itemspec_vchr,
                                            a.itemengname_vchr, a.selfdefine_int, a.itemchecktype_chr,
                                            a.itemopunit_chr, a.itemipunit_chr, b.deptprep_int,
                                            a.dosageunit_chr, a.packqty_dec,
                                            round (a.itemprice_mny / a.packqty_dec, 4) submoney,
                                            a.itemprice_mny, a.itemcode_vchr type, b.noqtyflag_int,
                                            b.mindosage_dec, b.maxdosage_dec, b.adultdosage_dec,
                                            b.childdosage_dec, b.nmldosage_dec, b.hype_int,
                                            a.opchargeflg_int, a.usageid_chr, c.usagename_vchr,
                                            a.itemcommname_vchr, b.ispoison_chr, b.isanaesthesia_chr,
                                            b.ischlorpromazine_chr, b.ischlorpromazine2_chr,
                                            a.itemopinvtype_chr, a.dosage_dec, a.itemcode_vchr,
                                            f.precent_dec, y.typename_vchr as ybtypename
                                       from t_bse_chargeitem a,
                                            t_bse_medicine b,
                                            t_bse_usagetype c,
                                            (select itemid_chr
                                               from t_aid_comusechargeitem
                                              where createrid_chr = ? and type_int = 0
                                             union all
                                             select a.itemid_chr
                                               from t_aid_comusechargeitem a,
                                                    (select a.deptid_chr
                                                       from t_bse_deptemp a
                                                      where a.end_dat is null and a.empid_chr = ?) b
                                              where a.deptid_chr = b.deptid_chr and type_int = 0) d,
                                            (select itemid_chr, precent_dec
                                               from t_aid_inschargeitem
                                              where copayid_chr = ?) f,
                                            t_bse_chargecatmap h,
                                            t_aid_medicaretype y
                                      where a.itemsrcid_vchr = b.medicineid_chr(+)
                                        and a.ifstop_int = 0
                                        and a.usageid_chr = c.usageid_chr(+)
                                        and a.insurancetype_vchr = y.typeid_chr(+)
                                        and a.itemid_chr = d.itemid_chr
                                        and a.itemopinvtype_chr = h.catid_chr(+)
                                        and h.groupid_chr = '0002'
                                        and a.itemid_chr = f.itemid_chr(+)
                                        and (upper (a." + QueryColname + @") like ? or upper (a.itemopcode_chr) like ?)
                                   order by a.itemcode_vchr";
                }

                if (UseAliasTable)
                {
                    objHRPSvc.CreateDatabaseParameter(4, out ParamArr);
                    ((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
                    ((OracleParameter)ParamArr[1]).OracleDbType = OracleDbType.Char;
                    ((OracleParameter)ParamArr[2]).OracleDbType = OracleDbType.Char;

                    ParamArr[0].Value = strEmployID;
                    ParamArr[1].Value = strEmployID;
                    ParamArr[2].Value = strPatientTypeID;
                    ParamArr[3].Value = ID.Replace("/", "") + "%";                    
                }
                else
                {
                    objHRPSvc.CreateDatabaseParameter(5, out ParamArr);
                    ((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
                    ((OracleParameter)ParamArr[1]).OracleDbType = OracleDbType.Char;
                    ((OracleParameter)ParamArr[2]).OracleDbType = OracleDbType.Char;

                    ParamArr[0].Value = strEmployID;
                    ParamArr[1].Value = strEmployID;
                    ParamArr[2].Value = strPatientTypeID;
                    ParamArr[3].Value = ID.Replace("/", "") + "%";
                    ParamArr[4].Value = ID.Replace("/", "") + "%";
                }
            }
            else
            {
                if (UseAliasTable)
                {
                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;

                    ParamArr[0].Value = strPatientTypeID;
                    ParamArr[1].Value = ID + "%";                    
                }
                else
                {
                    objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                    ((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;

                    ParamArr[0].Value = strPatientTypeID;
                    ParamArr[1].Value = ID + "%";
                    ParamArr[2].Value = ID + "%";
                }
            }

            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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
        [AutoComplete]
        public long m_mthFindTestChargeByID(System.Security.Principal.IPrincipal p_objPrincipal, string strType, string ID, string strPatientTypeID, out DataTable dt, string strEmployID)
        {
            dt = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthFindTestChargeByID");
            if (lngRes < 0)
            {
                return -1;
            }

            if (strType != "itemid_chr")
            {
                m_mthGetType(ID, ref strType);
            }

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;

            string strSQL = @"select A.ITEMID_CHR,A.ITEMNAME_VCHR,A.ITEMSPEC_VCHR,a.ITEMOPINVTYPE_CHR,
							a.ITEMCODE_VCHR,f.precent_dec ,a.itemcommname_vchr, 
							a.ITEMUNIT_CHR itemopunit_chr,A.ITEMPRICE_MNY,
							A.SELFDEFINE_INT,A." + strType + @" type, A.ITEMENGNAME_VCHR,
							 g.sample_type_id_chr, h.sample_type_desc_vchr, y.typename_vchr as ybtypename   
							from t_bse_chargeitem A , T_BSE_CHARGECATMAP D, 
							(SELECT * FROM t_aid_inschargeitem WHERE copayid_chr = ?) f,
							t_aid_lis_apply_unit g,
							t_aid_lis_sampletype h, 
                            t_aid_medicaretype y 
					where (upper(A." + strType + @") LIKE ? or upper(a.itemopcode_chr) like ?) and a.IFSTOP_INT =0 
					and a.ITEMOPINVTYPE_CHR=d.catid_chr(+) 
					AND a.itemsrcid_vchr = g.APPLY_UNIT_ID_CHR(+)
					AND g.sample_type_id_chr = h.sample_type_id_chr(+) 
                    and a.INSURANCETYPE_VCHR = y.typeid_chr(+) 
					and d.groupid_chr='0003' 
					and d.INTERNALFLAG_INT=0
					and a.itemid_chr =f.itemid_chr(+)  order by A." + strType;

            //以“/”开头是查询常用检验项目
            if (ID.IndexOf("/") > -1)
            {
                strSQL = @"select A.ITEMID_CHR,A.ITEMNAME_VCHR,A.ITEMSPEC_VCHR,a.ITEMOPINVTYPE_CHR,
							a.ITEMCODE_VCHR,f.precent_dec ,a.itemcommname_vchr,
							a.ITEMUNIT_CHR itemopunit_chr,A.ITEMPRICE_MNY,
							A.SELFDEFINE_INT,A." + strType + @" type, A.ITEMENGNAME_VCHR,
							 g.sample_type_id_chr, h.sample_type_desc_vchr, y.typename_vchr as ybtypename   
							from t_bse_chargeitem A , T_BSE_CHARGECATMAP D, 
							(SELECT * FROM t_aid_inschargeitem WHERE copayid_chr = ?) f,
							t_aid_lis_apply_unit g,
							t_aid_lis_sampletype h, 
                            t_aid_medicaretype y,  
							(SELECT *
							FROM t_aid_comusechargeitem
							WHERE createrid_chr = ? AND type_int = 0
							UNION
							SELECT a.*
							FROM t_aid_comusechargeitem a,
								(SELECT a.deptid_chr
									FROM t_bse_deptemp a
									WHERE a.end_dat IS NULL AND a.empid_chr = ?) b
							WHERE a.deptid_chr = b.deptid_chr AND type_int = 0) i
					where (upper(A." + strType + @") LIKE ? or upper(a.itemopcode_chr) like ?) and a.IFSTOP_INT =0 
					and a.ITEMOPINVTYPE_CHR=d.catid_chr(+) 
					AND a.itemsrcid_vchr = g.APPLY_UNIT_ID_CHR(+)
					AND g.sample_type_id_chr = h.sample_type_id_chr(+) 
                    and a.INSURANCETYPE_VCHR = y.typeid_chr(+) 
					and d.groupid_chr='0003' 
					and d.INTERNALFLAG_INT=0 
					and a.ITEMID_CHR = i.ITEMID_CHR 
					and a.itemid_chr =f.itemid_chr(+)  order by A." + strType;

                objHRPSvc.CreateDatabaseParameter(5, out ParamArr);
                ((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
                ((OracleParameter)ParamArr[1]).OracleDbType = OracleDbType.Char;
                ((OracleParameter)ParamArr[2]).OracleDbType = OracleDbType.Char;

                ParamArr[0].Value = strPatientTypeID;
                ParamArr[1].Value = strEmployID;
                ParamArr[2].Value = strEmployID;
                ParamArr[3].Value = ID.Replace("/", "") + "%";
                ParamArr[4].Value = ID.Replace("/", "") + "%";
            }
            else
            {
                objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                ((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;

                ParamArr[0].Value = strPatientTypeID;
                ParamArr[1].Value = ID + "%";
                ParamArr[2].Value = ID + "%";
            }

            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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
        [AutoComplete]
        public long m_mthFindExamineChargeByID(System.Security.Principal.IPrincipal p_objPrincipal, string strType, string ID, string strPatientTypeID, out DataTable dt, string strEmployID)
        {
            dt = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthFindExamineChargeByID");
            if (lngRes < 0)
            {
                return -1;
            }

            if (strType != "itemid_chr")
            {
                m_mthGetType(ID, ref strType);
            }

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;

            string strSQL = @"select A.ITEMID_CHR,A.ITEMNAME_VCHR,A.ITEMSPEC_VCHR,a.ITEMOPINVTYPE_CHR,a.ITEMCODE_VCHR,f.precent_dec, a.itemcommname_vchr, a.usageid_chr, 
a.ITEMUNIT_CHR itemopunit_chr,A.ITEMPRICE_MNY,A.SELFDEFINE_INT,A." + strType + @" type, A.ITEMENGNAME_VCHR , a.itemchecktype_chr, g.partname, y.typename_vchr as ybtypename 
 from t_bse_chargeitem A , T_BSE_CHARGECATMAP D,
 (SELECT * FROM t_aid_inschargeitem WHERE copayid_chr = ?) f,
  ar_apply_partlist g, t_aid_medicaretype y 
where (upper(A." + strType + @") LIKE ? or upper(a.itemopcode_chr) like ?) and a.IFSTOP_INT =0 
and a.ITEMOPINVTYPE_CHR=d.catid_chr(+) 
and a.INSURANCETYPE_VCHR = y.typeid_chr(+) 
and d.groupid_chr='0004'
 and d.INTERNALFLAG_INT=0 
  AND a.itemchecktype_chr = g.partid(+)
and a.itemid_chr =f.itemid_chr(+)  order by A." + strType;

            //以“/”开头是查询常用检查项目
            if (ID.IndexOf("/") > -1)
            {
                strSQL = @"select A.ITEMID_CHR,A.ITEMNAME_VCHR,A.ITEMSPEC_VCHR,a.ITEMOPINVTYPE_CHR,a.ITEMCODE_VCHR,f.precent_dec, a.itemcommname_vchr, a.usageid_chr, 
a.ITEMUNIT_CHR itemopunit_chr,A.ITEMPRICE_MNY,A.SELFDEFINE_INT,A." + strType + @" type, A.ITEMENGNAME_VCHR , a.itemchecktype_chr, g.partname, y.typename_vchr as ybtypename 
 from t_bse_chargeitem A , T_BSE_CHARGECATMAP D,
 (SELECT * FROM t_aid_inschargeitem WHERE copayid_chr = ?) f,
  ar_apply_partlist g, t_aid_medicaretype y, 
	(SELECT *
		FROM t_aid_comusechargeitem
		WHERE createrid_chr = ? AND type_int = 0
		UNION
		SELECT a.*
		FROM t_aid_comusechargeitem a,
			(SELECT a.deptid_chr
				FROM t_bse_deptemp a
				WHERE a.end_dat IS NULL AND a.empid_chr = ?) b
		WHERE a.deptid_chr = b.deptid_chr AND type_int = 0) h
where (upper(A." + strType + @") LIKE ? or upper(a.itemopcode_chr) like ?) and a.IFSTOP_INT =0 
and a.ITEMOPINVTYPE_CHR=d.catid_chr(+) 
and a.INSURANCETYPE_VCHR = y.typeid_chr(+) 
and d.groupid_chr='0004'
and d.INTERNALFLAG_INT=0 
and a.ITEMID_CHR = h.ITEMID_CHR 
and a.itemchecktype_chr = g.partid(+) 
and a.itemid_chr =f.itemid_chr(+) order by A." + strType;

                objHRPSvc.CreateDatabaseParameter(5, out ParamArr);
                ((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
                ((OracleParameter)ParamArr[1]).OracleDbType = OracleDbType.Char;
                ((OracleParameter)ParamArr[2]).OracleDbType = OracleDbType.Char;

                ParamArr[0].Value = strPatientTypeID;
                ParamArr[1].Value = strEmployID;
                ParamArr[2].Value = strEmployID;
                ParamArr[3].Value = ID.Replace("/", "") + "%";
                ParamArr[4].Value = ID.Replace("/", "") + "%";
            }
            else
            {
                objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                ((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;

                ParamArr[0].Value = strPatientTypeID;
                ParamArr[1].Value = ID + "%";
                ParamArr[2].Value = ID + "%";
            }

            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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
        [AutoComplete]
        public long m_mthFindOPSChargeByID(System.Security.Principal.IPrincipal p_objPrincipal, string strType, string ID, string strPatientTypeID, out DataTable dt, string strEmployID)
        {
            dt = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthFindOPSChargeByID");
            if (lngRes < 0)
            {
                return -1;
            }

            if (strType != "itemid_chr")
            {
                m_mthGetType(ID, ref strType);
            }

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;

            string strSQL = @"select A.ITEMID_CHR,A.ITEMNAME_VCHR,A.ITEMSPEC_VCHR,a.ITEMOPINVTYPE_CHR,a.ITEMCODE_VCHR, a.apply_type_int, f.precent_dec, a.itemcommname_vchr, y.typename_vchr as ybtypename, a.usageid_chr, 
a.ITEMUNIT_CHR itemopunit_chr,A.ITEMPRICE_MNY,A.SELFDEFINE_INT,A." + strType + @" type, A.ITEMENGNAME_VCHR  from t_bse_chargeitem A , T_BSE_CHARGECATMAP D, (SELECT * FROM t_aid_inschargeitem WHERE copayid_chr = ?) f, t_aid_medicaretype y 
where (upper(A." + strType + ") LIKE ? or upper(a.itemopcode_chr) like ?) and a.IFSTOP_INT =0 and a.ITEMOPINVTYPE_CHR=d.catid_chr(+) and d.groupid_chr='0006'  and d.INTERNALFLAG_INT=0 and a.itemid_chr =f.itemid_chr(+) and a.INSURANCETYPE_VCHR = y.typeid_chr(+) order by A." + strType;

            //以“/”开头是查询常用手术项目
            if (ID.IndexOf("/") > -1)
            {
                strSQL = @"select A.ITEMID_CHR,A.ITEMNAME_VCHR,A.ITEMSPEC_VCHR,a.ITEMOPINVTYPE_CHR,a.ITEMCODE_VCHR, a.apply_type_int, f.precent_dec, a.itemcommname_vchr, y.typename_vchr as ybtypename, a.usageid_chr, 
a.ITEMUNIT_CHR itemopunit_chr,A.ITEMPRICE_MNY,A.SELFDEFINE_INT,A." + strType + @" type, A.ITEMENGNAME_VCHR  from t_bse_chargeitem A , T_BSE_CHARGECATMAP D, (SELECT * FROM t_aid_inschargeitem WHERE copayid_chr = ?) f, t_aid_medicaretype y, 
(SELECT *
		FROM t_aid_comusechargeitem
		WHERE createrid_chr = ? AND type_int = 0
		UNION
		SELECT a.*
		FROM t_aid_comusechargeitem a,
			(SELECT a.deptid_chr
				FROM t_bse_deptemp a
				WHERE a.end_dat IS NULL AND a.empid_chr = ?) b
		WHERE a.deptid_chr = b.deptid_chr AND type_int = 0) g 
where (upper(A." + strType + ") LIKE ? or upper(a.itemopcode_chr) like ?) and a.IFSTOP_INT =0 and a.ITEMID_CHR = g.ITEMID_CHR and a.ITEMOPINVTYPE_CHR=d.catid_chr(+) and d.groupid_chr='0006' and d.INTERNALFLAG_INT=0 and a.itemid_chr =f.itemid_chr(+) and a.INSURANCETYPE_VCHR = y.typeid_chr(+) order by A." + strType;

                objHRPSvc.CreateDatabaseParameter(5, out ParamArr);
                ((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
                ((OracleParameter)ParamArr[1]).OracleDbType = OracleDbType.Char;
                ((OracleParameter)ParamArr[2]).OracleDbType = OracleDbType.Char;

                ParamArr[0].Value = strPatientTypeID;
                ParamArr[1].Value = strEmployID;
                ParamArr[2].Value = strEmployID;
                ParamArr[3].Value = ID.Replace("/", "") + "%";
                ParamArr[4].Value = ID.Replace("/", "") + "%";
            }
            else
            {
                objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                ((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
                ((OracleParameter)ParamArr[1]).OracleDbType = OracleDbType.Char;

                ParamArr[0].Value = strPatientTypeID;
                ParamArr[1].Value = ID + "%";
                ParamArr[2].Value = ID + "%";
            }

            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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

        /// <summary>
        /// 查询手术收费项目
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="strType"></param>
        /// <param name="ID"></param>
        /// <param name="strPatientTypeID"></param>
        /// <param name="dt"></param>
        /// <param name="strEmployID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthFindOPSChargeByID(string strType, string ID, string strPatientTypeID, string strEmployID, out DataTable dt)
        {
            dt = new DataTable();
            long lngRes = 0;

            if (strType != "itemid_chr")
            {
                m_mthGetType(ID, ref strType);
            }

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;

            string strSQL = @"select A.ITEMID_CHR,A.ITEMNAME_VCHR,A.ITEMSPEC_VCHR,a.ITEMOPINVTYPE_CHR,a.ITEMCODE_VCHR,f.precent_dec, y.typename_vchr as ybtypename, a.usageid_chr, 
a.ITEMUNIT_CHR itemopunit_chr,A.ITEMPRICE_MNY,A.SELFDEFINE_INT,A." + strType + @" type, A.ITEMENGNAME_VCHR  from t_bse_chargeitem A , T_BSE_CHARGECATMAP D, (SELECT * FROM t_aid_inschargeitem WHERE copayid_chr = ?) f, t_aid_medicaretype y 
where  upper(A." + strType + @") LIKE ? and a.IFSTOP_INT = 0 and a.ITEMOPINVTYPE_CHR=d.catid_chr(+) and d.groupid_chr='0006'  and d.INTERNALFLAG_INT=0 and a.itemid_chr =f.itemid_chr(+) and a.INSURANCETYPE_VCHR = y.typeid_chr(+) and 
            and (a.usageid_chr in (select usageid_chr from t_bse_usagetype where trim(usagename_vchr) = '手术'))
            order by A." + strType;

            objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
            ((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;

            ParamArr[0].Value = strPatientTypeID;
            ParamArr[1].Value = ID + "%";

            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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

        /// <summary>
        /// 根据收费项目ID查询手术收费项目
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="strType"></param>
        /// <param name="ID"></param>
        /// <param name="strPatientTypeID"></param>
        /// <param name="dt"></param>
        /// <param name="strEmployID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthFindOPSChargeByID(System.Security.Principal.IPrincipal p_objPrincipal, string ID, string strPatientTypeID, out DataTable dt)
        {
            dt = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthFindOPSChargeByID");
            if (lngRes < 0)
            {
                return -1;
            }

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;

            string strSQL = @"select A.ITEMID_CHR,A.ITEMNAME_VCHR,A.ITEMSPEC_VCHR,a.ITEMOPINVTYPE_CHR,a.ITEMCODE_VCHR,f.precent_dec, y.typename_vchr as ybtypename, a.usageid_chr, 
a.ITEMUNIT_CHR itemopunit_chr,A.ITEMPRICE_MNY,A.SELFDEFINE_INT,A.ITEMCODE_VCHR type, A.ITEMENGNAME_VCHR  from t_bse_chargeitem A , T_BSE_CHARGECATMAP D, (SELECT * FROM t_aid_inschargeitem WHERE copayid_chr = ?) f, t_aid_medicaretype y 
where A.ITEMID_CHR = ? and a.IFSTOP_INT =0 and a.ITEMOPINVTYPE_CHR=d.catid_chr(+) and d.groupid_chr='0006'  and d.INTERNALFLAG_INT=0 and a.itemid_chr =f.itemid_chr(+) and a.INSURANCETYPE_VCHR = y.typeid_chr(+) order by A.ITEMCODE_VCHR";

            objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
            ((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;

            ParamArr[0].Value = strPatientTypeID;
            ParamArr[1].Value = ID;

            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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

        [AutoComplete]
        public long m_mthFindOtherChargeByID(System.Security.Principal.IPrincipal p_objPrincipal, string strType, string ID, string strPatientTypeID, out DataTable dt, string strEmployID)
        {
            dt = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthFindOtherChargeByID");
            if (lngRes < 0)
            {
                return -1;
            }

            if (strType != "itemid_chr")
            {
                m_mthGetType(ID, ref strType);
            }

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;

            string strSQL = @"select A.ITEMID_CHR,A.ITEMNAME_VCHR,A.ITEMSPEC_VCHR,a.ITEMOPINVTYPE_CHR,a.ITEMCODE_VCHR,f.precent_dec, a.itemcommname_vchr, b.DEPTPREP_INT, y.typename_vchr as ybtypename, 
a.ITEMUNIT_CHR itemopunit_chr,A.ITEMPRICE_MNY,A.SELFDEFINE_INT,A." + strType + @" type, A.ITEMENGNAME_VCHR from t_bse_chargeitem A, t_bse_medicine b, T_BSE_CHARGECATMAP D,  (SELECT * FROM t_aid_inschargeitem WHERE copayid_chr = ?) f, t_aid_medicaretype y 
where A.ITEMSRCID_VCHR = B.MEDICINEID_CHR(+) and (upper(A." + strType + ") LIKE ? or upper(a.itemopcode_chr) like ?) and a.IFSTOP_INT =0 and a.ITEMOPINVTYPE_CHR=d.catid_chr(+) and d.groupid_chr='0005' and d.INTERNALFLAG_INT=0 and a.itemid_chr =f.itemid_chr(+) and a.INSURANCETYPE_VCHR = y.typeid_chr(+) order by A." + strType;

            //以“/”开头是查询常用检查项目
            if (ID.IndexOf("/") > -1)
            {
                strSQL = @"select A.ITEMID_CHR,A.ITEMNAME_VCHR,A.ITEMSPEC_VCHR,a.ITEMOPINVTYPE_CHR,a.ITEMCODE_VCHR,f.precent_dec, a.itemcommname_vchr, b.DEPTPREP_INT, y.typename_vchr as ybtypename, 
a.ITEMUNIT_CHR itemopunit_chr,A.ITEMPRICE_MNY,A.SELFDEFINE_INT,A." + strType + @" type, A.ITEMENGNAME_VCHR from t_bse_chargeitem A, t_bse_medicine b, T_BSE_CHARGECATMAP D, (SELECT * FROM t_aid_inschargeitem WHERE copayid_chr = ?) f,
(SELECT *
		FROM t_aid_comusechargeitem
		WHERE createrid_chr = ? AND type_int = 0
		UNION
		SELECT a.*
		FROM t_aid_comusechargeitem a,
			(SELECT a.deptid_chr
				FROM t_bse_deptemp a
				WHERE a.end_dat IS NULL AND a.empid_chr = ?) b
		WHERE a.deptid_chr = b.deptid_chr AND type_int = 0) g, t_aid_medicaretype y  
where A.ITEMSRCID_VCHR = B.MEDICINEID_CHR(+) and (upper(A." + strType + ") LIKE ? or upper(a.itemopcode_chr) like ?) and a.IFSTOP_INT =0 and a.ITEMID_CHR = g.ITEMID_CHR and a.ITEMOPINVTYPE_CHR=d.catid_chr(+) and d.groupid_chr='0005' and d.INTERNALFLAG_INT=0 and a.itemid_chr =f.itemid_chr(+) and a.INSURANCETYPE_VCHR = y.typeid_chr(+) order by A." + strType;

                objHRPSvc.CreateDatabaseParameter(5, out ParamArr);
                ((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
                ((OracleParameter)ParamArr[1]).OracleDbType = OracleDbType.Char;
                ((OracleParameter)ParamArr[2]).OracleDbType = OracleDbType.Char;

                ParamArr[0].Value = strPatientTypeID;
                ParamArr[1].Value = strEmployID;
                ParamArr[2].Value = strEmployID;
                ParamArr[3].Value = ID.Replace("/", "") + "%";
                ParamArr[4].Value = ID.Replace("/", "") + "%";
            }
            else
            {
                objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                ((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
                ParamArr[0].Value = strPatientTypeID;
                ParamArr[1].Value = ID + "%";
                ParamArr[2].Value = ID + "%";
            }

            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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

        #region 查找频率
        [AutoComplete]
        public long m_mthFindFrequency(System.Security.Principal.IPrincipal p_objPrincipal, string ID, out DataTable dt)
        {
            dt = new DataTable();
            long lngRes = 0;

            string strSQL = @"select   freqid_chr, freqname_chr, usercode_chr, times_int, days_int,
                             lexectime_vchr, texectime_vchr, execweekday_chr, printdesc_vchr,
                             opfredesc_vchr
                            from t_aid_recipefreq
                            where upper (usercode_chr) like ? or upper (freqname_chr) like ?
                            order by usercode_chr";

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;

            objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
            ParamArr[0].Value = ID.ToUpper() + "%";
            ParamArr[1].Value = ID.ToUpper() + "%";

            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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
        [AutoComplete]
        public long m_mthFindFrequency2(System.Security.Principal.IPrincipal p_objPrincipal, string ID, out DataTable dt)
        {
            dt = new DataTable();
            long lngRes = 0;
            string strSQL = @"select   freqid_chr, freqname_chr, usercode_chr, times_int, days_int,
                             lexectime_vchr, texectime_vchr, execweekday_chr, printdesc_vchr,
                             opfredesc_vchr
                            from t_aid_recipefreq where freqid_chr = ?";

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;

            objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
            ((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
            ParamArr[0].Value = ID;

            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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

        #region 查找用法
        [AutoComplete]
        public long m_mthFindUsage(System.Security.Principal.IPrincipal p_objPrincipal, string ID, int scope, out DataTable dt)
        {
            dt = new DataTable();
            long lngRes = 0;

            string strScope = "";
            if (scope == 1)
            {
                strScope = " and (scope_int = 0 or scope_int = 1) ";
            }
            else if (scope == 2)
            {
                strScope = " and (scope_int = 0 or scope_int = 2) ";
            }
            else
            {
                strScope = " and (scope_int = 0 or scope_int = 1 or scope_int = 2) ";
            }

            string strSQL = @"select   usageid_chr, usagename_vchr, usercode_chr, pycode_vchr, wbcode_vchr,
                             scope_int, putmed_int, test_int, opusagedesc
                        from t_bse_usagetype
                       where (   upper (usercode_chr) like ?
                              or upper (usagename_vchr) like ?
                              or upper (wbcode_vchr) like ?
                              or upper (pycode_vchr) like ?
                             )" + strScope + "order by scope_int, usercode_chr";


            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;

            objHRPSvc.CreateDatabaseParameter(4, out ParamArr);
            ParamArr[0].Value = ID.ToUpper() + "%";
            ParamArr[1].Value = ID.ToUpper() + "%";
            ParamArr[2].Value = ID.ToUpper() + "%";
            ParamArr[3].Value = ID.ToUpper() + "%";

            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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
        [AutoComplete]
        public long m_mthFindUsage2(System.Security.Principal.IPrincipal p_objPrincipal, string ID, out DataTable dt)
        {
            dt = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthFindUsage2");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"select a.usageid_chr,
                            a.usagename_vchr,
                            a.usercode_chr,
                            a.pycode_vchr,
                            a.wbcode_vchr,
                            a.scope_int,
                            a.putmed_int,
                            a.test_int,
                            a.opusagedesc    
                            from t_bse_usagetype a where usageid_chr = ?";

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;

            objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
            ((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
            ParamArr[0].Value = ID;

            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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

        #region 保存数据
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="OPR_VO">主处方VO</param>
        /// <param name="CH_VO">病历VO</param>
        /// <param name="DR_VO">诊断VO</param>
        /// <param name="PWM_VO">1</param>
        /// <param name="CM_VO">2</param>
        /// <param name="CHK_VO">3</param>
        /// <param name="TR_VO">4</param>
        /// <param name="OP_VO">5</param>
        /// <param name="Other_VO">6</param>
        /// <param name="strRecipeID">处方ID</param>
        /// <param name="strCaseHisID">病历ID</param>
        /// <param name="IsModify">true 新增,false修改</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthSaveAllData(clsOutPatientRecipe_VO OPR_VO, clsOutpatientCaseHis_VO CH_VO, clsOutpatientDiagRec_VO DR_VO, clsOutpatientPWMRecipeDe_VO[] PWM_VO, clsOutpatientCMRecipeDe_VO[] CM_VO,
            clsOutpatientCHKRecipeDe_VO[] CHK_VO, clsOutpatientTestRecipeDe_VO[] TR_VO,
            clsOutpatientOPSRecipeDe_VO[] OP_VO, clsOutpatientOtherRecipeDe_VO[] Other_VO, clsOutpatientOrderRecipeDe_VO[] Order_VO,
            out string strRecipeID, out string strCaseHisID, bool IsModify, bool blnCashStatus, bool blnSaveCash, System.Security.Principal.IPrincipal p_objPrincipal)
        {
            long ret = 0;
            strRecipeID = "";
            strCaseHisID = "";
            ret = this.m_mthSaveRecipeMain(p_objPrincipal, OPR_VO, out strRecipeID, blnSaveCash);
            if (ret > 0)
            {
                if (blnSaveCash)
                {
                    ret = m_mthSaveCaseHistory(p_objPrincipal, CH_VO, blnCashStatus, ref strRecipeID);
                    if (ret > 0)
                    {
                        strCaseHisID = CH_VO.m_strCaseHisID;
                    }
                }
                //				ret =m_mthSaveDiagnoses(p_objPrincipal,DR_VO,IsModify,strRecipeID);
                if (!IsModify)
                {
                    ret = this.m_mthDeleteRecipeDetail(p_objPrincipal, strRecipeID);
                }
                ret = this.m_mthSaveDetail1(p_objPrincipal, PWM_VO, strRecipeID);
                ret = this.m_mthSaveDetail2(p_objPrincipal, CM_VO, strRecipeID);
                ret = this.m_mthSaveDetail3(p_objPrincipal, CHK_VO, strRecipeID);
                ret = this.m_mthSaveDetail4(p_objPrincipal, TR_VO, strRecipeID);
                ret = this.m_mthSaveDetail5(p_objPrincipal, OP_VO, strRecipeID);
                ret = this.m_mthSaveDetail6(p_objPrincipal, Other_VO, strRecipeID);
                ret = this.m_mthSaveDetailOrder(p_objPrincipal, Order_VO, strRecipeID);
            }
            return ret;

        }
        /// <summary>
        /// 保存处方主表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="clsVO"></param>
        /// <param name="p_strID"></param>
        /// <returns></returns>
        public long m_mthSaveRecipeMain(System.Security.Principal.IPrincipal p_objPrincipal, clsOutPatientRecipe_VO clsVO, out string p_strID, bool blnSaveCash)
        {
            p_strID = DateTime.Now.ToString("yyyyMMddHHmmssffff");

            if (blnSaveCash)
            {
                if (clsVO.m_strCaseHistoryID.Trim() == "")
                {
                    if (clsVO.m_strOutpatRecipeID != "" && clsVO.m_strOutpatRecipeID != null)
                    {
                        clsVO.m_strCaseHistoryID = clsVO.m_strOutpatRecipeID;
                    }
                    else
                    {
                        clsVO.m_strCaseHistoryID = p_strID;
                    }
                }
            }
            else
            {
                clsVO.m_strCaseHistoryID = "";
            }

            long lngRes = 0, lngAffects = 0;
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            lngRes = clsSec.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthSaveRecipeMain");
            if (lngRes < 0)
                return lngRes;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            try
            {
                string strSQL = "";
                if (clsVO.m_strOutpatRecipeID == null || clsVO.m_strOutpatRecipeID.Trim() == "")
                {
                    clsVO.m_strOutpatRecipeID = p_strID;
                    clsVO.m_intType = 0;
                    strSQL = @"insert into t_opr_outpatientrecipe
                                        (outpatrecipeid_chr, patientid_chr, createdate_dat,
                                         registerid_chr, diagdr_chr, diagdept_chr, recordemp_chr,
                                         recorddate_dat, pstauts_int, paytypeid_chr, casehisid_chr,
                                         recipeflag_int, type_int, createtype_int
                                        )
                                 values (?, ?, to_date (?, 'yyyy-mm-dd hh24:mi:ss'),
                                         ?, ?, ?, ?,
                                         to_date (?, 'yyyy-mm-dd hh24:mi:ss'), ?, ?, ?,
                                         ?, ?, ?
                                        )";

                    IDataParameter[] ParamArr = null;

                    objHRPSvc.CreateDatabaseParameter(14, out ParamArr);
                    ParamArr[0].Value = clsVO.m_strOutpatRecipeID;
                    ParamArr[1].Value = clsVO.m_strPatientID;
                    ParamArr[2].Value = clsVO.m_strCreateDate;
                    ParamArr[3].Value = clsVO.m_strRegisterID;
                    ParamArr[4].Value = clsVO.m_strDoctorID;
                    ParamArr[5].Value = clsVO.m_strDepID;
                    ParamArr[6].Value = clsVO.m_strOperatorID;
                    ParamArr[7].Value = clsVO.m_strRecordDate;
                    ParamArr[8].Value = clsVO.m_intPStatus;
                    ParamArr[9].Value = clsVO.m_strPatientType;
                    ParamArr[10].Value = clsVO.m_strCaseHistoryID;
                    ParamArr[11].Value = clsVO.m_intType;
                    ParamArr[12].Value = clsVO.m_strRecipeType;
                    ParamArr[13].Value = clsVO.intCreatetype;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
                }
                else
                {
                    p_strID = clsVO.m_strOutpatRecipeID;
                    strSQL = @"UPDATE t_opr_outpatientrecipe
								SET paytypeid_chr = ?,									
									type_int = ?,
									CaseHisID_Chr = ?  
							  WHERE outpatrecipeid_chr = ?";

                    IDataParameter[] ParamArr = null;

                    objHRPSvc.CreateDatabaseParameter(4, out ParamArr);
                    ParamArr[0].Value = clsVO.m_strPatientType;
                    ParamArr[1].Value = clsVO.m_strRecipeType;
                    ParamArr[2].Value = clsVO.m_strCaseHistoryID;
                    ParamArr[3].Value = clsVO.m_strOutpatRecipeID;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
                }

                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                lngRes = -2;
            }
            return lngRes;
        }
        /// <summary>
        /// 诊断
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="clsVO"></param>
        /// <param name="IsNew"></param>
        public long m_mthSaveDiagnoses(System.Security.Principal.IPrincipal p_objPrincipal, clsOutpatientDiagRec_VO clsVO, bool IsNew, string strRecipe)
        {
            long lngRes = 0, lngAffects = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthSaveDiagnoses");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = "";
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            try
            {
                if (IsNew)
                {
                    strSQL = @"insert into t_opr_outpatientdiagrec
            (outpatientdiagrecid_chr, patientid_chr, registerid_chr,
             diagdr_chr, diagdept_chr, recordemp_chr, recorddate_dat,
             diagimport_vchr, diagmemo_vchr, diagstd_vchr, curprinciple_vchr,
             curestd_vchr, defend_vchr
            )
     values (?, ?, ?,
             ?, ?, ?, to_date (?, 'yyyy-mm-dd hh24:mi:ss'),
             ?, ?, ?, ?,
             ?, ?
            )";

                    IDataParameter[] ParamArr = null;

                    objHRPSvc.CreateDatabaseParameter(13, out ParamArr);
                    ParamArr[0].Value = strRecipe;
                    ParamArr[1].Value = clsVO.m_strPatientID;
                    ParamArr[2].Value = clsVO.m_strRegisterID;
                    ParamArr[3].Value = clsVO.m_strDiagDrID;
                    ParamArr[4].Value = clsVO.m_strDiagDeptID;
                    ParamArr[5].Value = clsVO.m_strRecordEmpID;
                    ParamArr[6].Value = clsVO.m_strRecordDate;
                    ParamArr[7].Value = clsVO.m_strDiagImport;
                    ParamArr[8].Value = clsVO.m_strDiagMemo;
                    ParamArr[9].Value = clsVO.m_strDiagStd;
                    ParamArr[10].Value = clsVO.m_strCurePrinciple;
                    ParamArr[11].Value = clsVO.m_strCureStd;
                    ParamArr[12].Value = clsVO.m_strDefend;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
                }
                else
                {
                    strSQL = @"Update T_OPR_OUTPATIENTDIAGREC set PATIENTID_CHR=?, REGISTERID_CHR=?, DIAGDR_CHR =?, DIAGDEPT_CHR=?, RECORDEMP_CHR=?, 
                                    RECORDDATE_DAT=to_date(?, 'yyyy-mm-dd hh24:mi:ss'), DIAGIMPORT_VCHR=?, DIAGMEMO_VCHR=?, DIAGSTD_VCHR=?, CURPRINCIPLE_VCHR=?, CURESTD_VCHR=?, DEFEND_VCHR=? 
                              where OUTPATIENTDIAGRECID_CHR=?";

                    IDataParameter[] ParamArr = null;

                    objHRPSvc.CreateDatabaseParameter(13, out ParamArr);
                    ParamArr[0].Value = clsVO.m_strPatientID;
                    ParamArr[1].Value = clsVO.m_strRegisterID;
                    ParamArr[2].Value = clsVO.m_strDiagDrID;
                    ParamArr[3].Value = clsVO.m_strDiagDeptID;
                    ParamArr[4].Value = clsVO.m_strRecordEmpID;
                    ParamArr[5].Value = clsVO.m_strRecordDate;
                    ParamArr[6].Value = clsVO.m_strDiagImport;
                    ParamArr[7].Value = clsVO.m_strDiagMemo;
                    ParamArr[8].Value = clsVO.m_strDiagStd;
                    ParamArr[9].Value = clsVO.m_strCurePrinciple;
                    ParamArr[10].Value = clsVO.m_strCureStd;
                    ParamArr[11].Value = clsVO.m_strDefend;
                    ParamArr[12].Value = strRecipe;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
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
        /// <summary>
        /// 病历
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="clsVO"></param>
        /// <param name="IsNew"></param>
        [AutoComplete]
        public long m_mthSaveCaseHistory(System.Security.Principal.IPrincipal p_objPrincipal, clsOutpatientCaseHis_VO clsVO, bool IsNew, ref string strCashID)
        {
            long lngRes = 0, lngAffects = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthSaveDiagnoses");

            if (clsVO.m_strCaseHisID.Trim() == "" || clsVO.m_strCaseHisID == null)
            {
                if (strCashID != "" && strCashID != null)
                {
                    clsVO.m_strCaseHisID = strCashID;
                }
                else
                {
                    clsVO.m_strCaseHisID = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                    strCashID = clsVO.m_strCaseHisID;
                }
            }

            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = "";
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            try
            {
                IDataParameter[] ParamArr = null;

                if (IsNew)
                {
                    strSQL = @"insert into t_opr_outpatientcasehis
            (casehisid_chr, modifydate_dat, patientid_chr, registerid_chr,
             diagdr_chr, diagdept_chr, recordemp_chr, recorddate_dat,
             status_int, diagmain_vchr, diagmain_xml_vchr, diagcurr_vchr,
             diagcurr_xml_vhcr, diaghis_vchr, diaghis_xml_vchr,
             aidcheck_vchr, aidcheck_xml_vchr, diag_vchr, diag_xml_vchr,
             treatment_vchr, treatment_xml_vchr, remark_vchr,
             remark_xml_vchr, anaphylaxis_vchr, bodycheck_vchr,
             bodychrck_xml_vchr, prihis_vchr, prihis_xml_vchr,
             parcasehisid_chr, caldept_vchr, caldept_xml_vchr
            )
     values (?, to_date (?, 'yyyy-mm-dd hh24:mi:ss'), ?, ?,
             ?, ?, ?, to_date (?, 'yyyy-mm-dd hh24:mi:ss'),
             ?, ?, ?, ?,
             ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?, ?,
             ?, ?, ?,
             ?, ?, ?,
             ?, ?, ?
            )";

                    objHRPSvc.CreateDatabaseParameter(31, out ParamArr);
                    ParamArr[0].Value = clsVO.m_strCaseHisID;
                    ParamArr[1].Value = clsVO.m_strModifyDate;
                    ParamArr[2].Value = clsVO.m_strPatientID;
                    ParamArr[3].Value = clsVO.m_strRegisterID;
                    ParamArr[4].Value = clsVO.m_strDiagDrID;
                    ParamArr[5].Value = clsVO.m_strDiagDeptID;
                    ParamArr[6].Value = clsVO.m_strRecordEmpID;
                    ParamArr[7].Value = clsVO.m_strRecordDate;
                    ParamArr[8].Value = clsVO.m_intStatus;
                    ParamArr[9].Value = clsVO.strDiagMain;
                    ParamArr[10].Value = clsVO.strDiagMain_XML;
                    ParamArr[11].Value = clsVO.strDiagCurr;
                    ParamArr[12].Value = clsVO.strDiagCurr_XML;
                    ParamArr[13].Value = clsVO.strDiagHis;
                    ParamArr[14].Value = clsVO.strDiagHis_XML;
                    ParamArr[15].Value = clsVO.strAidCheck;
                    ParamArr[16].Value = clsVO.strAidCheck_XML;
                    ParamArr[17].Value = clsVO.strDiag;
                    ParamArr[18].Value = clsVO.strDiag_XML;
                    ParamArr[19].Value = clsVO.strTreatMent;
                    ParamArr[20].Value = clsVO.strTreatMent_XML;
                    ParamArr[21].Value = clsVO.strReMark;
                    ParamArr[22].Value = clsVO.strReMark_XML;
                    ParamArr[23].Value = clsVO.strAnaPhyLaXis;
                    ParamArr[24].Value = clsVO.strExamineResult;
                    ParamArr[25].Value = clsVO.strExamineResult_XML;
                    ParamArr[26].Value = clsVO.m_strPRIHIS_VCHR;
                    ParamArr[27].Value = clsVO.m_strPRIHIS_XML_VCHR;
                    ParamArr[28].Value = clsVO.strParentCaseHistoryID;
                    ParamArr[29].Value = clsVO.strCALDEPT_VCHR;
                    ParamArr[30].Value = clsVO.strCALDEPT_VCHR_XML;
                }
                else
                {
                    strSQL = @"update t_opr_outpatientcasehis
   set modifydate_dat = to_date (?, 'yyyy-mm-dd hh24:mi:ss'),
       patientid_chr = ?,
       registerid_chr = ?,
       diagdr_chr = ?,
       diagdept_chr = ?,
       recordemp_chr = ?,
       recorddate_dat = to_date (?, 'yyyy-mm-dd hh24:mi:ss'),
       diagmain_vchr = ?,
       diagmain_xml_vchr = ?,
       diagcurr_vchr = ?,
       diagcurr_xml_vhcr = ?,
       diaghis_vchr = ?,
       diaghis_xml_vchr = ?,
       aidcheck_vchr = ?,
       aidcheck_xml_vchr = ?,
       diag_vchr = ?,
       parcasehisid_chr = ?,
       diag_xml_vchr = ?,
       treatment_vchr = ?,
       prihis_vchr = ?,
       prihis_xml_vchr = ?,
       treatment_xml_vchr = ?,
       remark_vchr = ?,
       remark_xml_vchr = ?,
       bodycheck_vchr = ?,
       bodychrck_xml_vchr = ?,
       caldept_vchr = ?,
       caldept_xml_vchr = ?,
       anaphylaxis_vchr = ?,
       status_int = ?
 where status_int = 1 and casehisid_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(31, out ParamArr);
                    ParamArr[0].Value = clsVO.m_strModifyDate;
                    ParamArr[1].Value = clsVO.m_strPatientID;
                    ParamArr[2].Value = clsVO.m_strRegisterID;
                    ParamArr[3].Value = clsVO.m_strDiagDrID;
                    ParamArr[4].Value = clsVO.m_strDiagDeptID;
                    ParamArr[5].Value = clsVO.m_strRecordEmpID;
                    ParamArr[6].Value = clsVO.m_strRecordDate;
                    ParamArr[7].Value = clsVO.strDiagMain;
                    ParamArr[8].Value = clsVO.strDiagMain_XML;
                    ParamArr[9].Value = clsVO.strDiagCurr;
                    ParamArr[10].Value = clsVO.strDiagCurr_XML;
                    ParamArr[11].Value = clsVO.strDiagHis;
                    ParamArr[12].Value = clsVO.strDiagHis_XML;
                    ParamArr[13].Value = clsVO.strAidCheck;
                    ParamArr[14].Value = clsVO.strAidCheck_XML;
                    ParamArr[15].Value = clsVO.strDiag;
                    ParamArr[16].Value = clsVO.strParentCaseHistoryID;
                    ParamArr[17].Value = clsVO.strDiag_XML;
                    ParamArr[18].Value = clsVO.strTreatMent;
                    ParamArr[19].Value = clsVO.m_strPRIHIS_VCHR;
                    ParamArr[20].Value = clsVO.m_strPRIHIS_XML_VCHR;
                    ParamArr[21].Value = clsVO.strTreatMent_XML;
                    ParamArr[22].Value = clsVO.strReMark;
                    ParamArr[23].Value = clsVO.strReMark_XML;
                    ParamArr[24].Value = clsVO.strExamineResult;
                    ParamArr[25].Value = clsVO.strExamineResult_XML;
                    ParamArr[26].Value = clsVO.strCALDEPT_VCHR;
                    ParamArr[27].Value = clsVO.strCALDEPT_VCHR_XML;
                    ParamArr[28].Value = clsVO.strAnaPhyLaXis;
                    ParamArr[29].Value = clsVO.m_intStatus;
                    ParamArr[30].Value = clsVO.m_strCaseHisID;
                }
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
                if (lngRes > 0)
                {
                    //是否过敏： 为空则视为无过敏 0 无；1有
                    int isallergic = 0;
                    if (clsVO.strAnaPhyLaXis.Trim() != "")
                    {
                        isallergic = 1;
                    }

                    strSQL = @"update t_bse_patient 
								set allergicdesc_vchr = ?,
									ifallergic_int = ? 
								where patientid_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                    ParamArr[0].Value = clsVO.strAnaPhyLaXis;
                    ParamArr[1].Value = isallergic;
                    ParamArr[2].Value = clsVO.m_strPatientID;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

                    strSQL = @" delete from  t_opr_opch_icd10 where CASEHISID_CHR = ?";

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = clsVO.m_strCaseHisID;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
                    if (lngRes > 0)
                    {
                        if (clsVO.objIllnessArr != null)
                        {
                            for (int i = 0; i < clsVO.objIllnessArr.Count; i++)
                            {
                                clsICD10_VO obj = clsVO.objIllnessArr[i] as clsICD10_VO;
                                strSQL = @" insert into t_opr_opch_icd10(CASEHISID_CHR,ICDCODE_VCHR,ICDNAME_VCHR) values(?,?,?)";

                                objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                                ParamArr[0].Value = clsVO.m_strCaseHisID;
                                ParamArr[1].Value = obj.strICDCODE_VCHR;
                                ParamArr[2].Value = obj.strICDNAME_VCHR;

                                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
                            }
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
        #region 保存处方明细
        public long m_mthSaveDetail1(System.Security.Principal.IPrincipal p_objPrincipal, clsOutpatientPWMRecipeDe_VO[] clsVO, string strRecipe)
        {
            long lngRes = 1, lngAffects = 0;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                string strSQL = "";
                for (int i = 0; i < clsVO.Length; i++)
                {
                    strSQL = @"insert into t_tmp_outpatientpwmrecipede
            (outpatrecipedeid_chr, rowno_chr, rowno_vchr2, itemid_chr,
             unitid_chr, usageid_chr, tolqty_dec, unitprice_mny,
             tolprice_mny, days_int, qty_dec, discount_dec,
             outpatrecipeid_chr, freqid_chr, hypetest_int, desc_vchr,
             usageparentid_vchr, attachparentid_vchr, itemspec_vchr,
             dosage_dec, dosageunit_chr, attachitembasenum_dec,
             itemname_vchr, deptmed_int
            )
     values (seq_recipeid.nextval, ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?, ?,
             ?, ?, ?,
             ?, ?
            )";

                    IDataParameter[] ParamArr = null;
                    objHRPSvc.CreateDatabaseParameter(23, out ParamArr);
                    ParamArr[0].Value = clsVO[i].m_strRowNo;
                    ParamArr[1].Value = clsVO[i].m_strRowNo2;
                    ParamArr[2].Value = clsVO[i].m_strItemID;
                    ParamArr[3].Value = clsVO[i].m_strUnit;
                    ParamArr[4].Value = clsVO[i].m_strUsageID.Trim();
                    ParamArr[5].Value = clsVO[i].m_decTolQty;
                    ParamArr[6].Value = clsVO[i].m_decPrice;
                    ParamArr[7].Value = clsVO[i].m_decTolPrice;
                    ParamArr[8].Value = clsVO[i].m_decDays;
                    ParamArr[9].Value = clsVO[i].m_decQty;
                    ParamArr[10].Value = clsVO[i].m_decDiscount;
                    ParamArr[11].Value = strRecipe;
                    ParamArr[12].Value = clsVO[i].m_strFrequency;
                    ParamArr[13].Value = clsVO[i].m_strHYPETEST_INT;
                    ParamArr[14].Value = clsVO[i].m_strDESC_VCHR;
                    ParamArr[15].Value = clsVO[i].m_strUSAGEPARENTID_VCHR;
                    ParamArr[16].Value = clsVO[i].m_strATTACHPARENTID_VCHR;
                    ParamArr[17].Value = clsVO[i].m_strItemspec;
                    ParamArr[18].Value = clsVO[i].m_decDosage;
                    ParamArr[19].Value = clsVO[i].m_strDosageunit;
                    ParamArr[20].Value = clsVO[i].m_decAttachitembasenum;
                    ParamArr[21].Value = clsVO[i].m_strItemname;
                    ParamArr[22].Value = clsVO[i].m_intDeptmed;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
                    if (lngRes < 1)
                    {
                        return lngRes;
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
        public long m_mthSaveDetail2(System.Security.Principal.IPrincipal p_objPrincipal, clsOutpatientCMRecipeDe_VO[] clsVO, string strRecipe)
        {
            long lngRes = 1, lngAffects = 0;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                string strSQL = "";
                for (int i = 0; i < clsVO.Length; i++)
                {
                    strSQL = @"insert into t_tmp_outpatientcmrecipede
            (outpatrecipedeid_chr, outpatrecipeid_chr, rowno_chr,
             rowno_vchr2, itemid_chr, unitid_chr, usageid_chr, qty_dec,
             unitprice_mny, tolprice_mny, discount_dec, times_int,
             min_qty_dec, sumusage_vchr, itemname_vchr, itemspec_vchr,
             deptmed_int, usagedetail_vchr
            )
     values (seq_recipeid.nextval, ?, ?,
             ?, ?, ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?
            )";

                    IDataParameter[] ParamArr = null;
                    objHRPSvc.CreateDatabaseParameter(17, out ParamArr);
                    ParamArr[0].Value = strRecipe;
                    ParamArr[1].Value = clsVO[i].m_strRowNo.Trim();
                    ParamArr[2].Value = clsVO[i].m_strRowNo2;
                    ParamArr[3].Value = clsVO[i].m_strItemID.Trim();
                    ParamArr[4].Value = clsVO[i].m_strUnit.Trim();
                    ParamArr[5].Value = clsVO[i].m_strUsageID.Trim();
                    ParamArr[6].Value = clsVO[i].m_decQty;
                    ParamArr[7].Value = clsVO[i].m_decPrice;
                    ParamArr[8].Value = clsVO[i].m_decTolPrice;
                    ParamArr[9].Value = clsVO[i].m_decDiscount;
                    ParamArr[10].Value = clsVO[i].m_intTimes;
                    ParamArr[11].Value = clsVO[i].m_decMIN_QTY_DEC;
                    ParamArr[12].Value = clsVO[i].m_strCMedicineUsage;
                    ParamArr[13].Value = clsVO[i].m_strItemname;
                    ParamArr[14].Value = clsVO[i].m_strItemspec;
                    ParamArr[15].Value = clsVO[i].m_intDeptmed;
                    ParamArr[16].Value = clsVO[i].m_strUsageDetail;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
                    if (lngRes < 1)
                    {
                        return lngRes;
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

        public long m_mthSaveDetail3(System.Security.Principal.IPrincipal p_objPrincipal, clsOutpatientCHKRecipeDe_VO[] clsVO, string strRecipe)
        {
            long lngRes = 1, lngAffects = 0;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                string strSQL = "";
                for (int i = 0; i < clsVO.Length; i++)
                {
                    strSQL = @"insert into t_tmp_outpatientchkrecipede
            (outpatrecipedeid_chr, outpatrecipeid_chr, rowno_chr, itemid_chr,
             price_mny, oprdept_chr, discount_dec, tolprice_mny, qty_dec,
             attachid_vchr, sampleid_vchr, usageparentid_vchr,
             attachparentid_vchr, quickflag_int, attachitembasenum_dec,
             usageitembasenum_dec, itemname_vchr, itemspec_vchr,
             itemunit_vchr, itemusagedetail_vchr, deptmed_int, orderid_vchr,
             orderbasenum_dec
            )
     values (seq_recipeid.nextval, ?, ?, ?,
             ?, ?, ?, ?, ?,
             ?, ?, ?,
             ?, ?, ?,
             ?, ?, ?,
             ?, ?, ?, ?,
             ?
            )";

                    IDataParameter[] ParamArr = null;
                    objHRPSvc.CreateDatabaseParameter(22, out ParamArr);
                    ParamArr[0].Value = strRecipe;
                    ParamArr[1].Value = clsVO[i].m_strRowNo;
                    ParamArr[2].Value = clsVO[i].m_strItemID;
                    ParamArr[3].Value = clsVO[i].m_decPrice;
                    ParamArr[4].Value = clsVO[i].m_strOprDeptID;
                    ParamArr[5].Value = clsVO[i].m_decDiscount;
                    ParamArr[6].Value = clsVO[i].m_decTolPrice;
                    ParamArr[7].Value = clsVO[i].m_decQty;
                    ParamArr[8].Value = clsVO[i].strApplyID;
                    ParamArr[9].Value = clsVO[i].strSampletypeID;
                    ParamArr[10].Value = clsVO[i].m_strUSAGEPARENTID_VCHR;
                    ParamArr[11].Value = clsVO[i].m_strATTACHPARENTID_VCHR;
                    ParamArr[12].Value = clsVO[i].m_strQuickflag_CHR;
                    ParamArr[13].Value = clsVO[i].m_decAttachitembasenum;
                    ParamArr[14].Value = clsVO[i].m_decUsageitembasenum;
                    ParamArr[15].Value = clsVO[i].m_strItemname;
                    ParamArr[16].Value = clsVO[i].m_strItemspec;
                    ParamArr[17].Value = clsVO[i].m_strItemunit;
                    ParamArr[18].Value = clsVO[i].m_strUsagedetail;
                    ParamArr[19].Value = clsVO[i].m_intDeptmed;
                    ParamArr[20].Value = clsVO[i].m_strOrderID;
                    ParamArr[21].Value = clsVO[i].m_decOrderBaseNum;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
                    if (lngRes < 1)
                    {
                        return lngRes;
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

        public long m_mthSaveDetail4(System.Security.Principal.IPrincipal p_objPrincipal, clsOutpatientTestRecipeDe_VO[] clsVO, string strRecipe)
        {
            long lngRes = 1, lngAffects = 0;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                string strSQL = "";
                for (int i = 0; i < clsVO.Length; i++)
                {
                    strSQL = @"insert into t_tmp_outpatienttestrecipede
            (outpatrecipedeid_chr, outpatrecipeid_chr, rowno_chr, itemid_chr,
             price_mny, oprdept_chr, discount_dec, tolprice_mny, qty_dec,
             attachid_vchr, checkpartid_vchr, usageparentid_vchr,
             attachparentid_vchr, attachitembasenum_dec,
             usageitembasenum_dec, itemname_vchr, itemspec_vchr,
             itemunit_vchr, itemusagedetail_vchr, deptmed_int, usageid_chr,
             orderid_vchr, orderbasenum_dec
            )
     values (seq_recipeid.nextval, ?, ?, ?,
             ?, ?, ?, ?, ?,
             ?, ?, ?,
             ?, ?,
             ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?
            )";

                    IDataParameter[] ParamArr = null;
                    objHRPSvc.CreateDatabaseParameter(22, out ParamArr);
                    ParamArr[0].Value = strRecipe;
                    ParamArr[1].Value = clsVO[i].m_strRowNo;
                    ParamArr[2].Value = clsVO[i].m_strItemID;
                    ParamArr[3].Value = clsVO[i].m_decPrice;
                    ParamArr[4].Value = clsVO[i].m_strOprDeptID;
                    ParamArr[5].Value = clsVO[i].m_decDiscount;
                    ParamArr[6].Value = clsVO[i].m_decTolPrice;
                    ParamArr[7].Value = clsVO[i].m_decQty;
                    ParamArr[8].Value = clsVO[i].strApplyID;
                    ParamArr[9].Value = clsVO[i].strPartID;
                    ParamArr[10].Value = clsVO[i].m_strUSAGEPARENTID_VCHR;
                    ParamArr[11].Value = clsVO[i].m_strATTACHPARENTID_VCHR;
                    ParamArr[12].Value = clsVO[i].m_decAttachitembasenum;
                    ParamArr[13].Value = clsVO[i].m_decUsageitembasenum;
                    ParamArr[14].Value = clsVO[i].m_strItemname;
                    ParamArr[15].Value = clsVO[i].m_strItemspec;
                    ParamArr[16].Value = clsVO[i].m_strItemunit;
                    ParamArr[17].Value = clsVO[i].m_strUsagedetail;
                    ParamArr[18].Value = clsVO[i].m_intDeptmed;
                    ParamArr[19].Value = clsVO[i].m_strUsageID;
                    ParamArr[20].Value = clsVO[i].m_strOrderID;
                    ParamArr[21].Value = clsVO[i].m_decOrderBaseNum;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
                    if (lngRes < 1)
                    {
                        return lngRes;
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

        public long m_mthSaveDetail5(System.Security.Principal.IPrincipal p_objPrincipal, clsOutpatientOPSRecipeDe_VO[] clsVO, string strRecipe)
        {
            long lngRes = 1, lngAffects = 0;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                string strSQL = "";
                for (int i = 0; i < clsVO.Length; i++)
                {
                    strSQL = @"insert into t_tmp_outpatientopsrecipede
            (outpatrecipedeid_chr, outpatrecipeid_chr, rowno_chr, itemid_chr,
             price_mny, oprdept_chr, discount_dec, tolprice_mny, qty_dec,
             attachid_vchr, usageparentid_vchr, attachparentid_vchr,
             attachitembasenum_dec, usageitembasenum_dec, itemname_vchr,
             itemspec_vchr, itemunit_vchr, itemusagedetail_vchr, deptmed_int,
             usageid_chr, orderid_vchr, orderbasenum_dec
            )
     values (seq_recipeid.nextval, ?, ?, ?,
             ?, ?, ?, ?, ?,
             ?, ?, ?,
             ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?, ?
            )";

                    IDataParameter[] ParamArr = null;
                    objHRPSvc.CreateDatabaseParameter(21, out ParamArr);
                    ParamArr[0].Value = strRecipe;
                    ParamArr[1].Value = clsVO[i].m_strRowNo;
                    ParamArr[2].Value = clsVO[i].m_strItemID;
                    ParamArr[3].Value = clsVO[i].m_decPrice;
                    ParamArr[4].Value = clsVO[i].m_strOprDeptID;
                    ParamArr[5].Value = clsVO[i].m_decDiscount;
                    ParamArr[6].Value = clsVO[i].m_decTolPrice;
                    ParamArr[7].Value = clsVO[i].m_decQty;
                    ParamArr[8].Value = clsVO[i].strApplyID;
                    ParamArr[9].Value = clsVO[i].m_strUSAGEPARENTID_VCHR;
                    ParamArr[10].Value = clsVO[i].m_strATTACHPARENTID_VCHR;
                    ParamArr[11].Value = clsVO[i].m_decAttachitembasenum;
                    ParamArr[12].Value = clsVO[i].m_decUsageitembasenum;
                    ParamArr[13].Value = clsVO[i].m_strItemname;
                    ParamArr[14].Value = clsVO[i].m_strItemspec;
                    ParamArr[15].Value = clsVO[i].m_strItemunit;
                    ParamArr[16].Value = clsVO[i].m_strUsagedetail;
                    ParamArr[17].Value = clsVO[i].m_intDeptmed;
                    ParamArr[18].Value = clsVO[i].m_strUsageID;
                    ParamArr[19].Value = clsVO[i].m_strOrderID;
                    ParamArr[20].Value = clsVO[i].m_decOrderBaseNum;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
                    if (lngRes < 1)
                    {
                        return lngRes;
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

        public long m_mthSaveDetail6(System.Security.Principal.IPrincipal p_objPrincipal, clsOutpatientOtherRecipeDe_VO[] clsVO, string strRecipe)
        {
            long lngRes = 1, lngAffects = 0;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                string strSQL = "";
                for (int i = 0; i < clsVO.Length; i++)
                {
                    strSQL = @"insert into t_tmp_outpatientothrecipede
            (outpatrecipedeid_chr, rowno_chr, itemid_chr, unitid_chr,
             qty_dec, unitprice_mny, tolprice_mny, discount_dec,
             outpatrecipeid_chr, attachid_vchr, usageparentid_vchr,
             attachparentid_vchr, attachitembasenum_dec,
             usageitembasenum_dec, itemname_vchr, itemspec_vchr,
             itemunit_vchr, itemusagedetail_vchr, deptmed_int
            )
     values (seq_recipeid.nextval, ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?, ?,
             ?, ?,
             ?, ?, ?,
             ?, ?, ?
            )";

                    IDataParameter[] ParamArr = null;
                    objHRPSvc.CreateDatabaseParameter(18, out ParamArr);
                    ParamArr[0].Value = clsVO[i].m_strRowNo;
                    ParamArr[1].Value = clsVO[i].m_strItemID;
                    ParamArr[2].Value = clsVO[i].m_strUnit;
                    ParamArr[3].Value = clsVO[i].m_decQty;
                    ParamArr[4].Value = clsVO[i].m_decPrice;
                    ParamArr[5].Value = clsVO[i].m_decTolPrice;
                    ParamArr[6].Value = clsVO[i].m_decDiscount;
                    ParamArr[7].Value = strRecipe;
                    ParamArr[8].Value = clsVO[i].strApplyID;
                    ParamArr[9].Value = clsVO[i].m_strUSAGEPARENTID_VCHR;
                    ParamArr[10].Value = clsVO[i].m_strATTACHPARENTID_VCHR;
                    ParamArr[11].Value = clsVO[i].m_decAttachitembasenum;
                    ParamArr[12].Value = clsVO[i].m_decUsageitembasenum;
                    ParamArr[13].Value = clsVO[i].m_strItemname;
                    ParamArr[14].Value = clsVO[i].m_strItemspec;
                    ParamArr[15].Value = clsVO[i].m_strItemunit;
                    ParamArr[16].Value = clsVO[i].m_strUsagedetail;
                    ParamArr[17].Value = clsVO[i].m_intDeptmed;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
                    if (lngRes < 1)
                    {
                        return lngRes;
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

        public long m_mthSaveDetailOrder(System.Security.Principal.IPrincipal p_objPrincipal, clsOutpatientOrderRecipeDe_VO[] clsVO, string strRecipe)
        {
            long lngRes = 1, lngAffects = 0;

            if (clsVO == null)
            {
                return lngRes;
            }

            try
            {
                string ID = "";
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                string strSQL = "";
                for (int i = 0; i < clsVO.Length; i++)
                {
                    strSQL = @"insert into t_opr_outpatient_orderdic
            (orderid_int, outpatrecipeid_chr, tableindex_int, orderque_int,
             orderdicid_chr, orderdicname_vchr, spec_vchr, qty_dec,
             attachid_vchr, sampleid_vchr, checkpartid_vchr, pricemny_dec,
             totalmny_dec, attachorderid_vchr, attachorderbasenum_dec,
             sbbasemny_dec
            )
     values (seq_recipeorderid.nextval, ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?, ?,
             ?
            )";

                    IDataParameter[] ParamArr = null;
                    objHRPSvc.CreateDatabaseParameter(15, out ParamArr);
                    ParamArr[0].Value = strRecipe;
                    ParamArr[1].Value = clsVO[i].m_strTableIndex;
                    ParamArr[2].Value = clsVO[i].m_strRowNo;
                    ParamArr[3].Value = clsVO[i].m_strOrderID;
                    ParamArr[4].Value = clsVO[i].m_strOrderName;
                    ParamArr[5].Value = clsVO[i].m_strOrderSpec;
                    ParamArr[6].Value = clsVO[i].m_decQty;
                    ParamArr[7].Value = clsVO[i].m_strAttachID;
                    ParamArr[8].Value = clsVO[i].m_strSampleID;
                    ParamArr[9].Value = clsVO[i].m_strCheckPartID;
                    ParamArr[10].Value = clsVO[i].m_decPriceMny;
                    ParamArr[11].Value = clsVO[i].m_decTotalMny;
                    ParamArr[12].Value = clsVO[i].m_strAttachOrderID;
                    ParamArr[13].Value = clsVO[i].m_decAttachOrderBaseNum;
                    ParamArr[14].Value = clsVO[i].m_decSbBaseMny;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
                    if (lngRes < 1)
                    {
                        return lngRes;
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
        #endregion

        #region 删除处方明细
        [AutoComplete]
        public long m_mthDeleteRecipeDetail(System.Security.Principal.IPrincipal p_objPrincipal, string ID)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthDeleteRecipeDetail");
            if (lngRes < 0)
            {
                return -1;
            }

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            try
            {

                string strSQL = "P_DELETERECIPEBYID ";
                com.digitalwave.iCare.ValueObject.clsSQLParamDefinitionVO[] objParams = new clsSQLParamDefinitionVO[1];

                objParams[0] = new clsSQLParamDefinitionVO();
                objParams[0].objParameter_Value = ID;
                objParams[0].strParameter_Type = clsOracleDbType.strChar;
                objParams[0].strParameter_Name = "RecipeID";
                lngRes = objHRPSvc.lngExecuteParameterProc(strSQL, objParams);
                if (lngRes < 1)
                {
                    return lngRes;
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

        #region 根据病人ID查找处方号
        [AutoComplete]
        public long m_mthGetRepiceNo(System.Security.Principal.IPrincipal p_objPrincipal, string type, out DataTable dt, string ID)
        {
            dt = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthFindRecipeNoByPatientID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"select OUTPATRECIPEID_CHR from t_opr_outpatientrecipe where PATIENTID_CHR = ? and PSTAUTS_INT= ?";

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;
            objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
            ((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
            ParamArr[0].Value = ID;
            ParamArr[1].Value = type;

            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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

        #region 根据处方号查找明细
        /// <summary>
        /// 诊断
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthFindDiagnoses(System.Security.Principal.IPrincipal p_objPrincipal, string ID, out DataTable dt)
        {
            dt = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthFindDiagnoses");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"select DIAGIMPORT_VCHR,DIAGMEMO_VCHR,DIAGSTD_VCHR,CURPRINCIPLE_VCHR,CURESTD_VCHR,DEFEND_VCHR  from T_OPR_OUTPATIENTDIAGREC
                               where OUTPATIENTDIAGRECID_CHR=?";

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;
            objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
            ((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
            ParamArr[0].Value = ID;

            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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
        /// <summary>
        /// 病历
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthFindCaseHistory(System.Security.Principal.IPrincipal p_objPrincipal, string ID, out DataTable dt)
        {
            dt = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthFindCaseHistory");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"select A.* from  T_OPR_OUTPATIENTCASEHIS A,T_OPR_OUTPATIENTRECIPE B
                                where A.CASEHISID_CHR=b.CASEHISID_CHR(+)
                                and b.outpatrecipeid_chr = ?";

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;
            objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
            ((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
            ParamArr[0].Value = ID;

            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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
        /// <summary>
        /// 病历
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthFindMaxCaseHistory(System.Security.Principal.IPrincipal p_objPrincipal, string strPatientID, out DataTable dt)
        {
            dt = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthFindMaxCaseHistory");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"select casehisid_chr, modifydate_dat, patientid_chr, registerid_chr,
                           diagdr_chr, diagdept_chr, recordemp_chr, recorddate_dat, status_int,
                           diagmain_vchr, diagmain_xml_vchr, diagcurr_vchr, diagcurr_xml_vhcr,
                           diaghis_vchr, diaghis_xml_vchr, aidcheck_vchr, aidcheck_xml_vchr,
                           diag_vchr, diag_xml_vchr, treatment_vchr, treatment_xml_vchr,
                           remark_vchr, remark_xml_vchr, anaphylaxis_vchr, bodycheck_vchr,
                           bodychrck_xml_vchr, prihis_vchr, prihis_xml_vchr, parcasehisid_chr,
                           anaphylaxis_xml_vchr, caldept_vchr, caldept_xml_vchr
                      from t_opr_outpatientcasehis
                     where modifydate_dat =
                              (select   max (modifydate_dat) as modifydate_dat
                                   from t_opr_outpatientcasehis
                                  where patientid_chr = ?
                                    and modifydate_dat between to_date (?,
                                                                        'yyyy-mm-dd hh24:mi:ss')
                                                           and to_date (?,
                                                                        'yyyy-mm-dd hh24:mi:ss')
                               group by patientid_chr)
                       and patientid_chr = ?";

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;
            objHRPSvc.CreateDatabaseParameter(4, out ParamArr);
            ((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
            ParamArr[0].Value = strPatientID;
            ParamArr[1].Value = DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
            ParamArr[2].Value = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
            ((OracleParameter)ParamArr[3]).OracleDbType = OracleDbType.Char;
            ParamArr[3].Value = strPatientID;

            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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
        [AutoComplete]
        public long m_mthFindRecipeDetail1(System.Security.Principal.IPrincipal p_objPrincipal, string ID, out DataTable dt, bool flag)//西药
        {
            dt = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthFindRecipeDetail1");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"select   a.outpatrecipedeid_chr, a.rowno_chr, a.itemid_chr, a.unitid_chr,
         a.usageid_chr, a.tolqty_dec, a.unitprice_mny, a.tolprice_mny,
         a.days_int, a.qty_dec, a.discount_dec, a.outpatrecipeid_chr,
         a.freqid_chr, a.hypetest_int, a.desc_vchr, a.usageparentid_vchr,
         a.attachparentid_vchr, a.itemspec_vchr, a.dosage_dec,
         a.dosageunit_chr, a.attachitembasenum_dec, a.usageitembasenum_dec,
         a.itemname_vchr, a.deptmed_int, a.rowno_vchr2, b.usagename_vchr,
         c.freqname_chr, c.times_int, c.days_int days, d.itemcode_vchr,
         d.itemengname_vchr, d.ifstop_int, d.packqty_dec, d.opchargeflg_int,
         d.dosage_dec, d.itemipunit_chr, d.itemopunit_chr,
         d.itemopinvtype_chr, e.hype_int, e.noqtyflag_int,
         d.itemspec_vchr as spec, d.opchargeflg_int, d.itemprice_mny,
         d.itemopunit_chr, round (d.itemprice_mny / d.packqty_dec,
                                  4) submoney, d.dosageunit_chr as dosageunit,e.mednormalname_vchr
    from t_tmp_outpatientpwmrecipede a,
         t_bse_usagetype b,
         t_aid_recipefreq c,
         t_bse_chargeitem d,
         t_bse_medicine e
   where a.usageid_chr = b.usageid_chr(+)
     and a.freqid_chr = c.freqid_chr(+)
     and a.itemid_chr = d.itemid_chr(+)
     and d.itemsrcid_vchr = e.medicineid_chr(+)
     and outpatrecipeid_chr = ?
order by rowno_chr";
            if (flag)
            {
                strSQL = @"select   a.outpatrecipedeid_chr, a.rowno_chr, a.itemid_chr, a.unitid_chr,
         a.usageid_chr, a.tolqty_dec, a.unitprice_mny, a.tolprice_mny,
         a.days_int, a.qty_dec, a.discount_dec, a.outpatrecipeid_chr,
         a.freqid_chr, a.hypetest_int, a.desc_vchr, a.usageparentid_vchr,
         a.attachparentid_vchr, a.itemspec_vchr, a.dosage_dec,
         a.dosageunit_chr, a.attachitembasenum_dec, a.usageitembasenum_dec,
         a.itemname_vchr, a.deptmed_int, a.rowno_vchr2, b.usagename_vchr,
         c.freqname_chr, c.times_int, c.days_int days, d.itemcode_vchr,
         d.itemengname_vchr, d.ifstop_int, d.packqty_dec, 1 opchargeflg_int,
         d.dosage_dec, d.itemipunit_chr, d.itemopunit_chr,
         d.itemopinvtype_chr, e.hype_int, e.noqtyflag_int,
         d.itemspec_vchr as spec, d.opchargeflg_int, d.itemprice_mny,
         d.itemopunit_chr, round (d.itemprice_mny / d.packqty_dec,
                                  4) submoney, d.dosageunit_chr as dosageunit,e.mednormalname_vchr
    from t_opr_outpatientpwmrecipede a,
         t_bse_usagetype b,
         t_aid_recipefreq c,
         t_bse_chargeitem d,
         t_bse_medicine e
   where a.usageid_chr = b.usageid_chr(+)
     and a.freqid_chr = c.freqid_chr(+)
     and a.itemid_chr = d.itemid_chr(+)
     and d.itemsrcid_vchr = e.medicineid_chr(+)
     and outpatrecipeid_chr = ?
order by rowno_chr";
            }

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;
            objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
            ParamArr[0].Value = ID;

            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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
        [AutoComplete]
        public long m_mthFindRecipeDetail2(System.Security.Principal.IPrincipal p_objPrincipal, string ID, out DataTable dt, bool flag)//中药
        {
            dt = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthFindRecipeDetail2");
            if (lngRes < 0)
            {
                return -1;
            }
            //string strTableName = "T_TMP_OUTPATIENTCMRECIPEDE";
            //if (flag)
            //{
            //    strTableName = "T_OPR_OUTPATIENTCMRECIPEDE";
            //}
            string strSQL = @"select a.itemid_chr itemid, a.unitid_chr unit, a.qty_dec quantity,
       a.deptmed_int, a.unitprice_mny price, a.tolprice_mny summoney,
       a.usageid_chr, a.rowno_chr, a.sumusage_vchr, b.ifstop_int,
       a.itemname_vchr itemname, a.itemspec_vchr dec, b.itemcode_vchr,
       a.usageparentid_vchr, a.attachparentid_vchr,
       b.itemopinvtype_chr invtype, b.itemcatid_chr catid, a.discount_dec,
       a.usagedetail_vchr, a.times_int times, a.min_qty_dec, b.itemprice_mny,
       b.itemopinvtype_chr, b.itemengname_vchr, b.opchargeflg_int,
       b.packqty_dec, b.dosage_dec, c.mindosage_dec, c.maxdosage_dec,
       d.usagename_vchr, c.noqtyflag_int, b.itemspec_vchr spec,
       round (b.itemprice_mny / b.packqty_dec, 4) submoney,
       b.dosageunit_chr as dosageunit
  from t_tmp_outpatientcmrecipede a,
       t_bse_chargeitem b,
       t_bse_medicine c,
       t_bse_usagetype d
 where a.itemid_chr = b.itemid_chr(+)
   and b.itemsrcid_vchr = c.medicineid_chr(+)
   and a.usageid_chr = d.usageid_chr(+)
   and outpatrecipeid_chr = ?";
            if (flag)
            {
                strSQL = @"select a.itemid_chr itemid, a.unitid_chr unit, a.qty_dec quantity,
       a.deptmed_int, a.unitprice_mny price, a.tolprice_mny summoney,
       a.usageid_chr, a.rowno_chr, a.sumusage_vchr, b.ifstop_int,
       a.itemname_vchr itemname, a.itemspec_vchr dec, b.itemcode_vchr,
       a.usageparentid_vchr, a.attachparentid_vchr,
       b.itemopinvtype_chr invtype, b.itemcatid_chr catid, a.discount_dec,
       a.usagedetail_vchr, a.times_int times, a.min_qty_dec, b.itemprice_mny,
       b.itemopinvtype_chr, b.itemengname_vchr, b.opchargeflg_int,
       b.packqty_dec, b.dosage_dec, c.mindosage_dec, c.maxdosage_dec,
       d.usagename_vchr, c.noqtyflag_int, b.itemspec_vchr spec,
       round (b.itemprice_mny / b.packqty_dec, 4) submoney,
       b.dosageunit_chr as dosageunit
  from t_opr_outpatientcmrecipede a,
       t_bse_chargeitem b,
       t_bse_medicine c,
       t_bse_usagetype d
 where a.itemid_chr = b.itemid_chr(+)
   and b.itemsrcid_vchr = c.medicineid_chr(+)
   and a.usageid_chr = d.usageid_chr(+)
   and outpatrecipeid_chr = ?";
            }
            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;
            objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
            ParamArr[0].Value = ID;

            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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
        [AutoComplete]
        public long m_mthFindRecipeDetail3(System.Security.Principal.IPrincipal p_objPrincipal, string ID, out DataTable dt, bool flag)
        {
            dt = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthFindRecipeDetail3");
            if (lngRes < 0)
            {
                return -1;
            }
            //string strTableName = "T_TMP_OUTPATIENTCHKRECIPEDE";
            //if (flag)
            //{
            //    strTableName = "T_OPR_OUTPATIENTCHKRECIPEDE";
            //}
            string strSQL = @"select   a.itemid_chr itemid, a.itemunit_vchr unit, a.qty_dec quantity,
         a.deptmed_int, a.price_mny price, a.tolprice_mny summoney,
         b.itemengname_vchr, a.itemusagedetail_vchr, b.ifstop_int,
         a.itemname_vchr itemname, a.itemspec_vchr dec, b.itemopinvtype_chr,
         b.itemcode_vchr, b.itemopinvtype_chr invtype, b.itemcatid_chr catid,
         a.discount_dec, a.attachid_vchr, a.attachitembasenum_dec,
         a.usageitembasenum_dec, b.selfdefine_int selfdefine, 1 times,
         a.sampleid_vchr, g.sample_type_desc_vchr, a.usageparentid_vchr,
         a.attachparentid_vchr, a.quickflag_int, a.rowno_chr, a.orderid_vchr,
         a.orderbasenum_dec, b.itemspec_vchr spec, b.itemprice_mny,
         b.itemunit_chr
    from t_tmp_outpatientchkrecipede a,
         t_bse_chargeitem b,
         t_aid_lis_sampletype g
   where a.itemid_chr = b.itemid_chr(+) and a.sampleid_vchr = g.sample_type_id_chr(+)
         and outpatrecipeid_chr = ?
order by a.rowno_chr";
            if (flag)
            {
                strSQL = @"select   a.itemid_chr itemid, a.itemunit_vchr unit, a.qty_dec quantity,
         a.deptmed_int, a.price_mny price, a.tolprice_mny summoney,
         b.itemengname_vchr, a.itemusagedetail_vchr, b.ifstop_int,
         a.itemname_vchr itemname, a.itemspec_vchr dec, b.itemopinvtype_chr,
         b.itemcode_vchr, b.itemopinvtype_chr invtype, b.itemcatid_chr catid,
         a.discount_dec, a.attachid_vchr, a.attachitembasenum_dec,
         a.usageitembasenum_dec, b.selfdefine_int selfdefine, 1 times,
         a.sampleid_vchr, g.sample_type_desc_vchr, a.usageparentid_vchr,
         a.attachparentid_vchr, a.quickflag_int, a.rowno_chr, a.orderid_vchr,
         a.orderbasenum_dec, b.itemspec_vchr spec, b.itemprice_mny,
         b.itemunit_chr
    from t_opr_outpatientchkrecipede a,
         t_bse_chargeitem b,
         t_aid_lis_sampletype g
   where a.itemid_chr = b.itemid_chr(+) and a.sampleid_vchr = g.sample_type_id_chr(+)
         and outpatrecipeid_chr = ?
order by a.rowno_chr";
            }
            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;
            objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
            ParamArr[0].Value = ID;

            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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
        [AutoComplete]
        public long m_mthFindRecipeDetail3ByOrder(System.Security.Principal.IPrincipal p_objPrincipal, string RecID, string ID, out DataTable dt, bool flag)
        {
            dt = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthFindRecipeDetail3");
            if (lngRes < 0)
            {
                return -1;
            }
            string strTableName = "T_TMP_OUTPATIENTCHKRECIPEDE";
            if (flag)
            {
                strTableName = "T_OPR_OUTPATIENTCHKRECIPEDE";
            }
            string strSQL = @"SELECT a.itemid_chr, a.ITEMUNIT_VCHR UNIT, a.qty_dec quantity, a.deptmed_int,
       a.PRICE_MNY price, a.tolprice_mny SumMoney,b.itemengname_vchr, a.itemusagedetail_vchr, b.ifstop_int, 
       a.itemname_vchr itemname, a.itemspec_vchr Dec,b.ITEMOPINVTYPE_CHR,b.ITEMCODE_VCHR,
       b.itemopinvtype_chr InvType, b.itemcatid_chr CatID,a.DISCOUNT_DEC,a.ATTACHID_VCHR, a.attachitembasenum_dec, a.usageitembasenum_dec,
       b.selfdefine_int SELFDEFINE, 1 Times,a.sampleid_vchr, g.sample_type_desc_vchr, a.USAGEPARENTID_VCHR, a.ATTACHPARENTID_VCHR, a.QUICKFLAG_INT, a.rowno_chr, a.orderid_vchr, a.orderbasenum_dec,
       b.itemspec_vchr spec, b.itemprice_mny, b.itemunit_chr, ord.qty_dec as totalqty_dec, a.DISCOUNT_DEC as precent_dec   
  FROM " + strTableName + @" a, t_bse_chargeitem b, t_aid_lis_sampletype g, t_opr_outpatient_orderdic ord 
 WHERE a.itemid_chr = b.itemid_chr(+) AND a.sampleid_vchr = g.sample_type_id_chr(+) and a.OUTPATRECIPEID_CHR = ord.OUTPATRECIPEID_CHR 
   and ('[PK]' || a.orderid_vchr) = ord.attachorderid_vchr and ord.tableindex_int = 3 and ord.outpatrecipeid_chr = ? and ord.attachorderid_vchr = ? order by a.rowno_chr";

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;
            objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
            ParamArr[0].Value = RecID;
            ParamArr[1].Value = ID;

            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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
        [AutoComplete]
        public long m_mthFindRecipeDetail4(System.Security.Principal.IPrincipal p_objPrincipal, string ID, out DataTable dt, bool flag)
        {
            dt = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthFindRecipeDetail4");
            if (lngRes < 0)
            {
                return -1;
            }
            //string strTableName = "T_TMP_OUTPATIENTTESTRECIPEDE";
            //if (flag)
            //{
            //    strTableName = "T_OPR_OUTPATIENTTESTRECIPEDE";
            //}
            string strSQL = @"select   a.itemid_chr itemid, a.itemunit_vchr unit, a.qty_dec quantity,
         a.deptmed_int, a.price_mny price, a.tolprice_mny summoney,
         b.itemengname_vchr, a.itemusagedetail_vchr, b.ifstop_int,
         a.usageid_chr, a.itemname_vchr itemname, a.itemspec_vchr dec,
         b.itemopinvtype_chr, b.itemcode_vchr, b.itemopinvtype_chr invtype,
         b.itemcatid_chr catid, a.discount_dec, a.attachid_vchr,
         a.attachitembasenum_dec, a.usageitembasenum_dec,
         b.selfdefine_int selfdefine, 1 times, a.checkpartid_vchr, d.partname,
         a.usageparentid_vchr, a.attachparentid_vchr, a.rowno_chr,
         a.orderid_vchr, a.orderbasenum_dec, b.itemspec_vchr spec,
         b.itemprice_mny, b.itemunit_chr
    from t_tmp_outpatienttestrecipede a,
         t_bse_chargeitem b,
         ar_apply_partlist d
   where a.itemid_chr = b.itemid_chr(+)
     and a.checkpartid_vchr = d.partid(+)
     and outpatrecipeid_chr = ?
order by a.rowno_chr";
            if (flag)
            {
                strSQL = @"select   a.itemid_chr itemid, a.itemunit_vchr unit, a.qty_dec quantity,
         a.deptmed_int, a.price_mny price, a.tolprice_mny summoney,
         b.itemengname_vchr, a.itemusagedetail_vchr, b.ifstop_int,
         a.usageid_chr, a.itemname_vchr itemname, a.itemspec_vchr dec,
         b.itemopinvtype_chr, b.itemcode_vchr, b.itemopinvtype_chr invtype,
         b.itemcatid_chr catid, a.discount_dec, a.attachid_vchr,
         a.attachitembasenum_dec, a.usageitembasenum_dec,
         b.selfdefine_int selfdefine, 1 times, a.checkpartid_vchr, d.partname,
         a.usageparentid_vchr, a.attachparentid_vchr, a.rowno_chr,
         a.orderid_vchr, a.orderbasenum_dec, b.itemspec_vchr spec,
         b.itemprice_mny, b.itemunit_chr
    from t_opr_outpatienttestrecipede a,
         t_bse_chargeitem b,
         ar_apply_partlist d
   where a.itemid_chr = b.itemid_chr(+)
     and a.checkpartid_vchr = d.partid(+)
     and outpatrecipeid_chr = ?
order by a.rowno_chr";
            }
            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;
            objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
            ParamArr[0].Value = ID;

            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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
        [AutoComplete]
        public long m_mthFindRecipeDetail4ByOrder(System.Security.Principal.IPrincipal p_objPrincipal, string RecID, string ID, out DataTable dt, bool flag)
        {
            dt = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthFindRecipeDetail4");
            if (lngRes < 0)
            {
                return -1;
            }
            string strTableName = "T_TMP_OUTPATIENTTESTRECIPEDE";
            if (flag)
            {
                strTableName = "T_OPR_OUTPATIENTTESTRECIPEDE";
            }
            string strSQL = @"SELECT a.itemid_chr, a.ITEMUNIT_VCHR UNIT, a.qty_dec quantity, a.deptmed_int,
       a.PRICE_MNY price, a.tolprice_mny SumMoney,b.itemengname_vchr, a.itemusagedetail_vchr, b.ifstop_int, a.usageid_chr, 
       a.itemname_vchr itemname, a.itemspec_vchr Dec,b.ITEMOPINVTYPE_CHR,b.ITEMCODE_VCHR,
       b.itemopinvtype_chr InvType, b.itemcatid_chr CatID,a.DISCOUNT_DEC,a.ATTACHID_VCHR, a.attachitembasenum_dec, a.usageitembasenum_dec,
       b.selfdefine_int SELFDEFINE, 1 Times,a.CHECKPARTID_VCHR,d.partname, a.USAGEPARENTID_VCHR, a.ATTACHPARENTID_VCHR, a.rowno_chr, a.orderid_vchr, a.orderbasenum_dec,
       b.itemspec_vchr spec, b.itemprice_mny, b.itemunit_chr, ord.qty_dec as totalqty_dec, a.DISCOUNT_DEC as precent_dec   
  FROM " + strTableName + @" a, t_bse_chargeitem b,ar_apply_partlist D, t_opr_outpatient_orderdic ord  
WHERE a.itemid_chr = b.itemid_chr(+) and a.CHECKPARTID_VCHR = D.partid(+)
  and ('[PK]' || a.orderid_vchr) = ord.attachorderid_vchr and a.OUTPATRECIPEID_CHR = ord.OUTPATRECIPEID_CHR and ord.tableindex_int = 4 and ord.outpatrecipeid_chr = ? and ord.attachorderid_vchr = ? order by a.rowno_chr";

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;
            objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
            ParamArr[0].Value = RecID;
            ParamArr[1].Value = ID;

            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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
        [AutoComplete]
        public long m_mthFindRecipeDetail5(System.Security.Principal.IPrincipal p_objPrincipal, string ID, out DataTable dt, bool flag)
        {
            dt = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthFindRecipeDetail5");
            if (lngRes < 0)
            {
                return -1;
            }
            //string strTableName = "T_TMP_OUTPATIENTOPSRECIPEDE";
            //if (flag)
            //{
            //    strTableName = "T_OPR_OUTPATIENTOPSRECIPEDE";
            //}
            string strSQL = @"select   a.itemid_chr itemid, a.itemunit_vchr unit, a.qty_dec quantity,
         a.deptmed_int, a.price_mny price, a.tolprice_mny summoney,
         b.itemengname_vchr, a.itemusagedetail_vchr, b.ifstop_int,
         a.usageid_chr, a.itemname_vchr itemname, a.itemspec_vchr dec,
         b.itemopinvtype_chr, b.itemcode_vchr, b.itemopinvtype_chr invtype,
         b.itemcatid_chr catid, a.discount_dec, a.attachid_vchr,
         b.selfdefine_int selfdefine, 1 times, a.usageparentid_vchr,
         a.attachparentid_vchr, a.attachitembasenum_dec,
         a.usageitembasenum_dec, a.rowno_chr, a.orderid_vchr,
         a.orderbasenum_dec, b.itemspec_vchr spec, b.itemprice_mny,
         b.itemunit_chr
    from t_tmp_outpatientopsrecipede a, t_bse_chargeitem b
   where a.itemid_chr = b.itemid_chr(+) and outpatrecipeid_chr = ?
order by a.rowno_chr
";
            if (flag)
            {
                strSQL = @"select   a.itemid_chr itemid, a.itemunit_vchr unit, a.qty_dec quantity,
         a.deptmed_int, a.price_mny price, a.tolprice_mny summoney,
         b.itemengname_vchr, a.itemusagedetail_vchr, b.ifstop_int,
         a.usageid_chr, a.itemname_vchr itemname, a.itemspec_vchr dec,
         b.itemopinvtype_chr, b.itemcode_vchr, b.itemopinvtype_chr invtype,
         b.itemcatid_chr catid, a.discount_dec, a.attachid_vchr,
         b.selfdefine_int selfdefine, 1 times, a.usageparentid_vchr,
         a.attachparentid_vchr, a.attachitembasenum_dec,
         a.usageitembasenum_dec, a.rowno_chr, a.orderid_vchr,
         a.orderbasenum_dec, b.itemspec_vchr spec, b.itemprice_mny,
         b.itemunit_chr
    from t_opr_outpatientopsrecipede a, t_bse_chargeitem b
   where a.itemid_chr = b.itemid_chr(+) and outpatrecipeid_chr = ?
order by a.rowno_chr";
            }
            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;
            objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
            ParamArr[0].Value = ID;

            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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
        [AutoComplete]
        public long m_mthFindRecipeDetail5ByOrder(System.Security.Principal.IPrincipal p_objPrincipal, string RecID, string ID, out DataTable dt, bool flag)
        {
            dt = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthFindRecipeDetail5");
            if (lngRes < 0)
            {
                return -1;
            }
            string strTableName = "T_TMP_OUTPATIENTOPSRECIPEDE";
            if (flag)
            {
                strTableName = "T_OPR_OUTPATIENTOPSRECIPEDE";
            }
            string strSQL = @"SELECT a.itemid_chr, a.ITEMUNIT_VCHR UNIT, a.qty_dec quantity, a.deptmed_int,
       a.PRICE_MNY price, a.tolprice_mny SumMoney,b.itemengname_vchr, a.itemusagedetail_vchr, b.ifstop_int, a.usageid_chr, 
       a.itemname_vchr itemname, a.itemspec_vchr Dec,b.ITEMOPINVTYPE_CHR,b.ITEMCODE_VCHR,
       b.itemopinvtype_chr InvType, b.itemcatid_chr CatID,a.DISCOUNT_DEC,a.ATTACHID_VCHR,
       b.selfdefine_int SELFDEFINE, 1 Times, a.USAGEPARENTID_VCHR, a.ATTACHPARENTID_VCHR, a.attachitembasenum_dec, a.usageitembasenum_dec, a.rowno_chr, a.orderid_vchr, a.orderbasenum_dec,
       b.itemspec_vchr spec, b.itemprice_mny, b.itemunit_chr, ord.qty_dec as totalqty_dec, a.DISCOUNT_DEC as precent_dec    
  FROM " + strTableName + @" a, t_bse_chargeitem b, t_opr_outpatient_orderdic ord  
 WHERE a.itemid_chr = b.itemid_chr(+) and a.OUTPATRECIPEID_CHR = ord.OUTPATRECIPEID_CHR 
  and ('[PK]' || a.orderid_vchr) = ord.attachorderid_vchr and ord.tableindex_int = 5 and ord.outpatrecipeid_chr = ? and ord.attachorderid_vchr = ? order by a.rowno_chr";

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;
            objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
            ParamArr[0].Value = RecID;
            ParamArr[1].Value = ID;

            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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
        [AutoComplete]
        public long m_mthFindRecipeDetail6(System.Security.Principal.IPrincipal p_objPrincipal, string ID, out DataTable dt, bool flag)
        {
            dt = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthFindRecipeDetail6");
            if (lngRes < 0)
            {
                return -1;
            }
            //string strTableName = "T_TMP_OUTPATIENTOTHRECIPEDE";
            //if (flag)
            //{
            //    strTableName = "T_OPR_OUTPATIENTOTHRECIPEDE";
            //}
            string strSQL = @"select   a.itemid_chr itemid, a.itemunit_vchr unit, a.qty_dec quantity,
         a.deptmed_int, a.unitprice_mny price, a.tolprice_mny summoney,
         b.itemengname_vchr, a.itemusagedetail_vchr, b.ifstop_int,
         a.itemname_vchr itemname, a.itemspec_vchr dec, b.itemopinvtype_chr,
         b.itemcode_vchr, b.itemopinvtype_chr invtype, b.itemcatid_chr catid,
         a.discount_dec, a.attachid_vchr, b.selfdefine_int selfdefine,
         1 times, a.usageparentid_vchr, a.attachparentid_vchr,
         a.attachitembasenum_dec, a.usageitembasenum_dec, a.rowno_chr,
         b.itemspec_vchr spec, b.itemprice_mny, b.itemunit_chr
    from t_tmp_outpatientothrecipede a, t_bse_chargeitem b
   where a.itemid_chr = b.itemid_chr(+) and outpatrecipeid_chr = ?
order by a.rowno_chr
";
            if (flag)
            {
                strSQL = @"select   a.itemid_chr itemid, a.itemunit_vchr unit, a.qty_dec quantity,
         a.deptmed_int, a.unitprice_mny price, a.tolprice_mny summoney,
         b.itemengname_vchr, a.itemusagedetail_vchr, b.ifstop_int,
         a.itemname_vchr itemname, a.itemspec_vchr dec, b.itemopinvtype_chr,
         b.itemcode_vchr, b.itemopinvtype_chr invtype, b.itemcatid_chr catid,
         a.discount_dec, a.attachid_vchr, b.selfdefine_int selfdefine,
         1 times, a.usageparentid_vchr, a.attachparentid_vchr,
         a.attachitembasenum_dec, a.usageitembasenum_dec, a.rowno_chr,
         b.itemspec_vchr spec, b.itemprice_mny, b.itemunit_chr
    from t_opr_outpatientothrecipede a, t_bse_chargeitem b
   where a.itemid_chr = b.itemid_chr(+) and outpatrecipeid_chr = ?
order by a.rowno_chr
";
            }
            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;
            objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
            ParamArr[0].Value = ID;

            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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

        [AutoComplete]
        public long m_mthFindRecipeDetailOrder(string ID, out DataTable dt)
        {
            dt = new DataTable();
            long lngRes = 0;

            string strSQL = @"select   a.orderid_int, a.outpatrecipeid_chr, a.tableindex_int,
         a.orderque_int, a.orderdicid_chr, a.orderdicname_vchr, a.spec_vchr,
         a.qty_dec, a.attachid_vchr, a.sampleid_vchr, a.checkpartid_vchr,
         a.pricemny_dec, a.totalmny_dec, a.attachorderid_vchr,
         a.attachorderbasenum_dec, b.status_int, d.sample_type_desc_vchr,
         f.partname, b.usercode_chr, b.engname_vchr, a.usageid_chr,
         b.lisapplyunitid_chr, b.applytypeid_chr, a.sbbasemny_dec
    from t_opr_outpatient_orderdic a,
         t_bse_bih_orderdic b,
         t_aid_lis_sampletype d,
         ar_apply_partlist f
   where a.orderdicid_chr = b.orderdicid_chr
     and a.sampleid_vchr = d.sample_type_id_chr(+)
     and a.checkpartid_vchr = f.partid(+)
     and a.outpatrecipeid_chr = ?
order by a.tableindex_int, a.orderque_int ";

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;
            objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
            ParamArr[0].Value = ID;

            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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

        #region 根据用法查找附加的收费项目
        [AutoComplete]
        public long m_mthGetChargeItemByUsageID(System.Security.Principal.IPrincipal p_objPrincipal, string strID, out DataTable dt)
        {
            dt = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthFindRecipeDetail6");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"select a.itemid_chr, a.itemname_vchr, a.itemcode_vchr, a.itempycode_chr,
       a.itemwbcode_chr, a.itemsrcid_vchr, a.itemsrctype_int, a.itemspec_vchr,
       a.itemprice_mny, a.itemprice_mny, a.itemunit_chr, a.itemopunit_chr,
       a.itemopunit_chr, a.itemipunit_chr, a.itemopcalctype_chr,
       a.itemipcalctype_chr, a.itemopinvtype_chr, a.itemipinvtype_chr,
       a.dosage_dec, a.dosageunit_chr, a.isgroupitem_int, a.itemcatid_chr,
       a.usageid_chr, a.itemopcode_chr, a.insuranceid_chr, a.selfdefine_int,
       a.packqty_dec, a.tradeprice_mny, a.poflag_int, a.isrich_int,
       a.opchargeflg_int, a.itemsrcname_vchr, a.itemsrctypename_vchr,
       a.itemengname_vchr, a.ifstop_int, a.pdcarea_vchr, a.ipchargeflg_int,
       a.insurancetype_vchr, a.apply_type_int, a.itembihctype_chr,
       a.defaultpart_vchr, a.itemchecktype_chr, a.itemcommname_vchr,
       a.ordercateid_chr, a.isselfpay_chr, a.itemprice_mny_old,
       a.itemprice_mny_new, a.keepuse_int, b.qty_dec,
       b.continueusetype_int, g.sample_type_id_chr, h.sample_type_desc_vchr,
       d.partname, e.deptprep_int
  from t_bse_chargeitem a,
       t_bse_chargeitemusagegroup b,
       t_aid_lis_apply_unit g,
       t_aid_lis_sampletype h,
       ar_apply_partlist d,
       t_bse_medicine e
 where b.itemid_chr = a.itemid_chr(+)
   and a.itemsrcid_vchr = g.apply_unit_id_chr(+)
   and g.sample_type_id_chr = h.sample_type_id_chr(+)
   and a.itemchecktype_chr = d.partid(+)
   and b.qty_dec > 0
   and trim (a.itemsrcid_vchr) = trim (e.medicineid_chr(+))
   and b.usageid_chr = ?";

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;
            objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
            ((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
            ParamArr[0].Value = strID;

            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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

        #region 查找模板列表
        /// <summary>
        /// 查找模板列表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="ID">查询内容</param>
        /// <param name="strType">查询字段</param>
        /// <param name="strCreatID">创建人ID</param>
        /// <param name="dt">列表</param>
        /// <returns>成功1,失败 0</returns>
        [AutoComplete]
        public long m_mthFindAccordRecipe(System.Security.Principal.IPrincipal p_objPrincipal, string ID, string strType, string strCreatID, out DataTable dt, int flag)
        {
            dt = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthFindAccordRecipe");
            if (lngRes < 0)
            {
                return -1;
            }

            bool blnTmp = true;
            try
            {
                long lng = long.Parse(ID.Replace("%", ""));
            }
            catch { blnTmp = false; }
            if (blnTmp)
            {
                strType = "usercode_chr";
            }

            try
            {
                string strSQL = @"SELECT * FROM (SELECT a.recipeid_chr, a.recipename_chr,a.USERCODE_CHR,a.PYCODE_CHR,a.WBCODE_CHR,a.DISEASENAME_VCHR
  FROM t_aid_concertrecipe a
 WHERE a.FLAG_INT=? and a.privilege_int = 0 AND a.status_int = 1 and (upper (a." + strType + ") like ? or a." + strType + @" is null) 
UNION
SELECT a.recipeid_chr, a.recipename_chr,a.USERCODE_CHR,a.PYCODE_CHR,a.WBCODE_CHR,a.DISEASENAME_VCHR
  FROM t_aid_concertrecipe a
 WHERE a.FLAG_INT=? and a.privilege_int = 1 AND a.createrid_chr = ?
       AND a.status_int = 1 and (upper (a." + strType + ") like ? or a." + strType + @" is null) 
UNION
SELECT aa.recipeid_chr, aa.recipename_chr,aa.USERCODE_CHR,aa.PYCODE_CHR,aa.WBCODE_CHR,aa.DISEASENAME_VCHR
  FROM t_aid_concertrecipe aa,
       (SELECT a.recipeid_chr
          FROM t_aid_concertrecipedept a
         WHERE a.deptid_chr IN (SELECT deptid_chr
                                  FROM t_bse_deptemp
                                 WHERE empid_chr = ?)) bb
 WHERE aa.recipeid_chr = bb.recipeid_chr AND aa.privilege_int = 2
       AND aa.FLAG_INT=? and aa.status_int = 1 and (upper (aa." + strType + ") like ? or aa." + strType + @" is null)  ) order by RECIPENAME_CHR";

                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                string strTempSql = @"select setid_chr, setname_vchr, setdesc_vchr, setstatus_int, moduleid_chr
                                      from t_sys_setting
                                     where setid_chr = '0032'";
                if (flag == 0)//医生用
                {
                    strTempSql = @"select setid_chr, setname_vchr, setdesc_vchr, setstatus_int, moduleid_chr
                                  from t_sys_setting
                                 where setid_chr = '0033'";
                }
                DataTable dtTemp = new DataTable();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strTempSql, ref dtTemp);
                bool tempFlag = false;
                if (dtTemp.Rows.Count > 0)//根据配置，如果是0则不调用，如果是1则调所有协定处方
                {
                    tempFlag = dtTemp.Rows[0]["SETSTATUS_INT"].ToString().Trim() == "1";
                }
                if (tempFlag)//代表不使用标志。
                {
                    strSQL = @"SELECT * FROM (SELECT a.recipeid_chr, a.recipename_chr,a.USERCODE_CHR,a.PYCODE_CHR,a.WBCODE_CHR,a.DISEASENAME_VCHR
  FROM t_aid_concertrecipe a
 WHERE a.privilege_int = 0 AND a.status_int = 1 and (upper (a." + strType + ") like ? or a." + strType + @" is null) 
UNION
SELECT a.recipeid_chr, a.recipename_chr,a.USERCODE_CHR,a.PYCODE_CHR,a.WBCODE_CHR,a.DISEASENAME_VCHR
  FROM t_aid_concertrecipe a
 WHERE  a.privilege_int = 1 AND a.createrid_chr = ?
       AND a.status_int = 1 and (upper (a." + strType + ") like ? or a." + strType + @" is null) 
UNION
SELECT aa.recipeid_chr, aa.recipename_chr,aa.USERCODE_CHR,aa.PYCODE_CHR,aa.WBCODE_CHR,aa.DISEASENAME_VCHR
  FROM t_aid_concertrecipe aa,
       (SELECT a.recipeid_chr
          FROM t_aid_concertrecipedept a
         WHERE a.deptid_chr IN (SELECT deptid_chr
                                  FROM t_bse_deptemp
                                 WHERE empid_chr = ?)) bb
 WHERE aa.recipeid_chr = bb.recipeid_chr AND aa.privilege_int = 2
       AND  aa.status_int = 1 and (upper (aa." + strType + ") like ? or aa." + strType + @" is null) ) order by RECIPENAME_CHR";

                    objHRPSvc.CreateDatabaseParameter(5, out ParamArr);
                    ParamArr[0].Value = ID + "%";
                    ParamArr[1].Value = strCreatID;
                    ParamArr[2].Value = ID + "%";
                    ParamArr[3].Value = strCreatID;
                    ParamArr[4].Value = ID + "%";
                }
                else
                {
                    objHRPSvc.CreateDatabaseParameter(8, out ParamArr);
                    ParamArr[0].Value = flag.ToString();
                    ParamArr[1].Value = ID + "%";
                    ParamArr[2].Value = flag.ToString();
                    ParamArr[3].Value = strCreatID;
                    ParamArr[4].Value = ID + "%";
                    ParamArr[5].Value = strCreatID;
                    ParamArr[6].Value = flag.ToString();
                    ParamArr[7].Value = ID + "%";
                }

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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

        #region 根据申请单的项目源ID查找收费项目
        [AutoComplete]
        public long m_mthFindChargeItemByApplyBillID(System.Security.Principal.IPrincipal p_objPrincipal, string ID, out DataTable dt)
        {
            dt = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthFindChargeItemByApplyBillID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"select A.ITEMID_CHR,A.ITEMNAME_VCHR,A.ITEMSPEC_VCHR,A.ITEMCODE_VCHR,
A.ITEMOPUNIT_CHR,A.ITEMPRICE_MNY,A.SELFDEFINE_INT,A.ITEMCODE_VCHR type from t_bse_chargeitem A , T_BSE_CHARGECATMAP D
where  A.ITEMSRCID_VCHR = ? AND a.ITEMOPINVTYPE_CHR=d.catid_chr(+) and d.groupid_chr='0003' and d.INTERNALFLAG_INT=0";

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;
            objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
            ParamArr[0].Value = ID;

            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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

        #region 根据项目ID查出禁忌药品
        [AutoComplete]
        public long m_mthFindTabuByID(System.Security.Principal.IPrincipal p_objPrincipal, string ID, out DataTable dt)
        {
            dt = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthFindTabuByID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"select AA.itemid_chr,AA.itemname_vchr from  t_bse_chargeitem  AA,
                                T_BSE_MEDICINE BB ,(SELECT C.refmedicinestdid_chr
                                FROM t_bse_chargeitem a, T_BSE_MEDICINE b ,T_BSE_MEDSTDRELATION  C
                                 WHERE a.itemsrcid_vchr = b.MEDICINEID_CHR and 
                                 b.MEDICINESTDID_CHR=C.medicinestdid_chr
                                and a.itemid_chr=?) CC
                                where 
                                 BB.MEDICINESTDID_CHR=CC.refmedicinestdid_chr
                                 and
                                 AA.ITEMSRCID_VCHR=BB.medicineid_chr
                                ";

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;
            objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
            ParamArr[0].Value = ID;

            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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

        #region 根据诊疗项目ID查出禁忌药品(住院用)
        [AutoComplete]
        public long m_mthFindTabuByID2(System.Security.Principal.IPrincipal p_objPrincipal, string ID, out DataTable dt)
        {
            dt = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthFindTabuByID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT dd.orderdicid_chr, ee.name_chr
  FROM t_bse_chargeitem aa,
       t_bse_medicine bb,
       (SELECT c.refmedicinestdid_chr
          FROM t_bse_chargeitem a,
               t_bse_medicine b,
               t_bse_medstdrelation c,
               t_aid_bih_orderdic_charge d
         WHERE a.itemsrcid_vchr = b.medicineid_chr
           AND b.medicinestdid_chr = c.medicinestdid_chr
           AND a.itemid_chr = d.itemid_chr
           AND d.orderdicid_chr = ?) cc,
       t_aid_bih_orderdic_charge dd,
       t_bse_bih_orderdic ee
 WHERE  cc.refmedicinestdid_chr=bb.medicinestdid_chr 
   AND bb.medicineid_chr =aa.itemsrcid_vchr 
   AND aa.itemid_chr = dd.itemid_chr
   AND dd.orderdicid_chr = ee.orderdicid_chr
";
            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;
            objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
            ((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
            ParamArr[0].Value = ID;

            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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

        #region 获取药品详细信息
        [AutoComplete]
        public void m_mthGetMedicineInfo(System.Security.Principal.IPrincipal p_objPrincipal, string ID, out string strText)
        {
            strText = "此药品信息不详!";
            DataTable dt = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthFindAccordRecipe");
            if (lngRes < 0)
            {
                return;
            }
            string strSQL = @" select c.context_vchr
                                 from t_bse_chargeitem a, t_bse_medicine b , t_bse_medicinestddesc c
                                where a.itemsrcid_vchr = trim(b.medicineid_chr(+))  
                                  and b.medicinestdid_chr = c.medicinestdid_chr(+)
                                  and a.itemid_chr = ?";

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;
            objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
            ParamArr[0].Value = ID;

            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
                if (lngRes > 0 && dt.Rows.Count > 0)
                {
                    strText = dt.Rows[0]["context_vchr"].ToString().Trim();
                    if (strText.Trim() == "")
                    {
                        strText = "此药品信息不详!";
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

        }

        [AutoComplete]
        public void m_mthGetMedicineInfo(System.Security.Principal.IPrincipal p_objPrincipal, string ID, out string strText, out string strRemark)
        {
            strText = "此药品信息不详!";
            strRemark = "";
            DataTable dt = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthFindAccordRecipe");
            if (lngRes < 0)
            {
                return;
            }
            string strSQL = @" select c.context_vchr, c.remark_vchr 
                                 from t_bse_chargeitem a, t_bse_medicine b , t_bse_medicinestddesc c
                                where a.itemsrcid_vchr = trim(b.medicineid_chr(+))  
                                  and b.medicinestdid_chr = c.medicinestdid_chr(+)
                                  and a.itemid_chr = ?";

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;
            objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
            ParamArr[0].Value = ID;

            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
                if (lngRes > 0 && dt.Rows.Count > 0)
                {
                    bool b = false;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["remark_vchr"].ToString().Trim() != "")
                        {
                            strText = dt.Rows[i]["context_vchr"].ToString().Trim();
                            if (strText.Trim() == "")
                            {
                                strText = "此药品信息不详!";
                            }

                            strRemark = dt.Rows[i]["remark_vchr"].ToString().Trim();
                            b = true;
                            break;
                        }
                    }

                    if (!b)
                    {
                        strText = dt.Rows[0]["context_vchr"].ToString().Trim();
                        if (strText.Trim() == "")
                        {
                            strText = "此药品信息不详!";
                        }

                        strRemark = dt.Rows[0]["remark_vchr"].ToString().Trim();
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

        }
        #endregion

        #region 作废处方
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="ID"></param>
        /// <param name="p_status"></param>
        /// <returns>失败-4 ,成功原来状态</returns>
        [AutoComplete]
        public long m_mthDelRecipe(System.Security.Principal.IPrincipal p_objPrincipal, string ID, string p_status)
        {
            long lngRes = -4;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthDelRecipe");
            if (lngRes < 0)
            {
                return -1;
            }

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;

            string strSQL = @"select PSTAUTS_INT From T_OPR_OUTPATIENTRECIPE where OUTPATRECIPEID_CHR = ?";

            objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
            ParamArr[0].Value = ID;

            if (p_status.Trim() == "-1")
            {
                DataTable tempdt = new DataTable();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref tempdt, ParamArr);
                if (lngRes > 0 && tempdt.Rows.Count > 0)
                {
                    if (tempdt.Rows[0][0].ToString().Trim() == "2")
                    {
                        return 2;
                    }
                }
            }

            try
            {
                if (p_status.Trim() == "0")//0代表医生新建,这时要删除处方
                {
                    strSQL = @"update T_OPR_OUTPATIENTRECIPE set PSTAUTS_INT = -1 where OUTPATRECIPEID_CHR = '" + ID + "'";
                    lngRes = objHRPSvc.DoExcute(strSQL);
                }
                else
                {
                    strSQL = @"update T_OPR_OUTPATIENTRECIPE set PSTAUTS_INT = " + p_status + " where OUTPATRECIPEID_CHR = '" + ID + "'";
                    lngRes = objHRPSvc.DoExcute(strSQL);

                    if (p_status.Trim() == "-1")
                    {
                        //作废时将通用申请单改写为删除状态
                        strSQL = @"UPDATE ar_common_apply
                                   SET deleted = 1
                                   WHERE applyid IN (SELECT b.attachid_vchr
                                   FROM t_opr_attachrelation b
                                   WHERE b.sourceitemid_vchr = '" + ID + @"')";
                        lngRes = objHRPSvc.DoExcute(strSQL);

                        //将手术申请单改为删除状态
                        strSQL = @"update t_opr_opsapply set status_int = -1 where outpatrecipeid_chr = '" + ID + "'";
                        lngRes = objHRPSvc.DoExcute(strSQL);
                    }

                    if (p_status.Trim() == "-1" || p_status.Trim() == "-2")
                    {
                        DataTable dt = new DataTable();

                        strSQL = @"select recipeflag_int, patientid_chr, diagdr_chr, registerid_chr from t_opr_outpatientrecipe where outpatrecipeid_chr = '" + ID + "'";

                        lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
                        if (lngRes > 0)
                        {
                            //正方
                            if (dt.Rows[0]["recipeflag_int"].ToString() == "1")
                            {
                                string patientid = dt.Rows[0]["patientid_chr"].ToString();
                                string diagdr = dt.Rows[0]["diagdr_chr"].ToString();

                                //if (dt.Rows[0]["registerid_chr"].ToString().Trim() == "")
                                //{
                                    strSQL = @"select a.outpatrecipeid_chr
                                                 from t_opr_outpatientrecipe a
                                                where a.pstauts_int = 4 
                                                  and a.recipeflag_int = 2
                                                  and a.patientid_chr = '" + patientid + @"' 
                                                  and a.diagdr_chr = '" + diagdr + @"' 
                                                  and a.recorddate_dat>= trunc(sysdate)
                                                  and a.recorddate_dat< trunc(sysdate + 1)
                                                order by a.outpatrecipeid_chr asc";
//                                }
//                                else
//                                {
//                                    int DateInterval = 0;
//                                    strSQL = @"select setstatus_int from t_sys_setting where setid_chr = '0058'";
//                                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
//                                    if (lngRes > 0 && dt.Rows.Count == 1)
//                                    {
//                                        string s = dt.Rows[0][0].ToString().Trim();
//                                        if (s != "" && Convert.ToInt32(s) > 0)
//                                        {
//                                            DateInterval = Convert.ToInt32(s) - 1;
//                                        }
//                                    }

//                                    strSQL = @"select a.outpatrecipeid_chr
//                                                 from t_opr_outpatientrecipe a
//                                                where a.pstauts_int = 4 
//                                                  and a.recipeflag_int = 2
//                                                  and a.patientid_chr = '" + patientid + @"' 
//                                                  and a.diagdr_chr = '" + diagdr + @"' 
//                                                  and (to_char (a.recorddate_dat, 'yyyy-mm-dd')
//                                                          between to_char (sysdate - " + DateInterval.ToString() + @", 'yyyy-mm-dd')
//                                                              and to_char (sysdate, 'yyyy-mm-dd')
//                                                       )             
//                                                order by a.outpatrecipeid_chr asc";
//                                }

                                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);

                                if (lngRes > 0 && dt.Rows.Count > 0)
                                {
                                    strSQL = @"update t_opr_outpatientrecipe set recipeflag_int = 1 where outpatrecipeid_chr = '" + dt.Rows[0][0].ToString() + "'";

                                    lngRes = objHRPSvc.DoExcute(strSQL);
                                }
                            }
                        }
                    }
                }

                objHRPSvc.Dispose();
                lngRes = long.Parse(p_status);
            }
            catch (Exception objEx)
            {
                lngRes = -4;//代表失败
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;

        }
        #endregion

        #region 取出候诊挂号单
        /// <summary>
        /// 根据部门ID，医生ID取出当天的挂号
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="strDoctor">医生ID</param>
        /// <param name="strDemp">部门ID</param>
        /// <param name="dt">返回候诊（挂号）表</param>
        [AutoComplete]
        public long m_lngGetGeg(System.Security.Principal.IPrincipal p_objPrincipal, string strDoctor, string strDep, out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();
            if ((strDep + strDoctor) == "")
            {
                return 0;
            }

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;

            string strtemp = "";
            if (strDoctor.Trim() != "")
            {
                strtemp = " AND (   a.waitdiagdr_chr = ? ";
                if (strDep.Trim() != "")
                {
                    strtemp += " OR a.waitdiagdept_chr = ?)";

                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = strDoctor;
                    ParamArr[1].Value = strDep;
                }
                else
                {
                    strtemp += ")";
                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = strDoctor;
                }
            }
            else
            {
                strtemp = " AND a.waitdiagdept_chr = ?";
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = strDep;
            }

            strtemp += " order by a.order_int";

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();

            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_lngGetGeg");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"SELECT a.waitdiaglistid_chr, a.registerid_chr, a.order_int, a.registerop_vchr,
                                   b.patientcardid_chr, c.lastname_vchr, c.sex_chr,
                                   (CASE FLOOR (MONTHS_BETWEEN (SYSDATE, c.birth_dat) / 12) WHEN 0 THEN TO_CHAR(FLOOR (MONTHS_BETWEEN (SYSDATE, c.birth_dat))) || '个月' ELSE  TO_CHAR(FLOOR (MONTHS_BETWEEN (SYSDATE, c.birth_dat) / 12)) || '岁' END) AS birth_dat,
                                   b.registerno_chr, d.lastname_vchr AS docname, e.deptname_vchr,f.paytypename_vchr
                              FROM t_opr_waitdiaglist a,
                                   t_opr_patientregister b,
                                   t_bse_patient c,
                                   t_bse_employee d,
                                   t_bse_deptdesc e,
                                   t_bse_patientpaytype  f
                             WHERE a.registerid_chr = b.registerid_chr(+)
                               AND b.patientid_chr = c.patientid_chr(+)
                               AND b.diagdept_chr = e.deptid_chr(+)
                               AND b.diagdoctor_chr = d.empid_chr(+)
                               and b.paytypeid_chr =f.paytypeid_chr(+)
                               AND a.registerdate_dat = TO_CHAR (SYSDATE)
                               AND a.pstatus_int = 1" + strtemp;

            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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

        #region 获取就诊挂号
        [AutoComplete]
        public long m_lngGetTakeGeg(System.Security.Principal.IPrincipal p_objPrincipal, string strDoctor, string strBeginDate, string strEndDate, out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();

            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_lngGetTakeGeg");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"SELECT a.takediagrecid_chr, a.registerid_chr,
                                   TO_CHAR (a.takediagtime_dat, 'yyyy-mm-dd hh24:mi') takediagtime_dat,
                                   TO_CHAR (a.endtime_dat, 'yyyy-mm-dd hh24:mi') endtime_dat,
                                   a.pstatus_int, c.lastname_vchr, c.sex_chr,
                                   (CASE FLOOR (MONTHS_BETWEEN (SYSDATE, c.birth_dat) / 12) WHEN 0 THEN TO_CHAR(FLOOR (MONTHS_BETWEEN (SYSDATE, c.birth_dat))) || '个月' ELSE TO_CHAR(FLOOR (MONTHS_BETWEEN (SYSDATE, c.birth_dat) / 12)) || '岁'  END) AS birth_dat,
                                   '' state, b.patientcardid_chr,e.paytypename_vchr
                              FROM t_opr_takediagrec a, t_bse_patientcard b, t_bse_patient c,t_opr_patientregister D,t_bse_patientpaytype E
                             WHERE a.patientid_chr = c.patientid_chr(+)
                               AND a.patientid_chr = b.patientid_chr(+)
                               and a.registerid_chr =d.registerid_chr(+)
                               and c.paytypeid_chr=e.paytypeid_chr(+)
                               and a.takediagtime_dat between to_date(?,'yyyy-mm-dd hh24:mi:ss') and to_date(?,'yyyy-mm-dd hh24:mi:ss')
                               and takediagdr_chr = ?";

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;
            objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
            ParamArr[0].Value = strBeginDate + " 00:00:00";
            ParamArr[1].Value = strEndDate + " 23:59:59";
            ParamArr[2].Value = strDoctor;

            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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

        #region 插入就诊表
        /// <summary>
        /// 插入接诊表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRecordID"></param>
        /// <param name="p_objRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewTakeDiagrec(System.Security.Principal.IPrincipal p_objPrincipal, out string p_strRecordID, clsTakeDiagrec p_objRecord)
        {
            long lngRes = 0, lngAffects = 0;
            p_strRecordID = "";
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_lngAddNewTakeDiagrec");
            if (lngRes < 0)
            {
                return -1;
            }

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;
            objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
            ParamArr[0].Value = p_objRecord.m_strREGISTERID_CHR;

            //lngRes = objHRPSvc.m_lngGenerateNewID("T_OPR_TAKEDIAGREC","TAKEDIAGRECID_CHR",out p_strRecordID);
            //if(lngRes < 0)
            //    return lngRes;

            //序列ID
            DataTable dt = new DataTable();
            string SQL = "select lpad(seq_takediagrecid.NEXTVAL, 18, '0') from dual";
            lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dt);
            if (lngRes > 0)
            {
                p_strRecordID = dt.Rows[0][0].ToString();
            }

            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = "update t_opr_patientregister set PSTATUS_INT = 2 where REGISTERID_CHR = ?";
            try
            {
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
            }
            catch
            {
                return -1;
            }
            objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
            ParamArr[0].Value = p_objRecord.m_strREGISTERID_CHR.Trim();
            strSQL = @"update t_opr_waitdiaglist
                           set pstatus_int = 2
                         where trim (registerid_chr) = ?";
            try
            {
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
            }
            catch
            {
                return -1;
            }
            if (lngRes < 0) return lngRes;

            //如果业务层那边用了这个标记为“0”表示不插入下面的表而退出
            if (p_objRecord.m_strTAKEDIAGDEPT_CHR == "0")
            {
                return lngRes;
            }

            strSQL = @"insert into t_opr_takediagrec
                                    (takediagrecid_chr, registerid_chr, takediagdr_chr,
                                     takediagdept_chr, takediagtime_dat, patientid_chr, paytypeid_chr
                                    )
                             values (?, ?, ?,
                                     ?, ?, ?, ?
                                    )";
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(7, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_strRecordID;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strREGISTERID_CHR;
                objLisAddItemRefArr[2].Value = p_objRecord.m_strTAKEDIAGDR_CHR;
                objLisAddItemRefArr[3].Value = p_objRecord.m_strTAKEDIAGDEPT_CHR;
                objLisAddItemRefArr[4].Value = DateTime.Parse(p_objRecord.m_strTAKEDIAGTIME_DAT);
                objLisAddItemRefArr[5].Value = p_objRecord.m_strPatientID;
                objLisAddItemRefArr[6].Value = p_objRecord.m_strPayTypeID;
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

        #region 更改挂号过程状态
        /// <summary>
        /// 更改挂号过程状态
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="strRegID"></param>
        /// <param name="strWaitID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngEndTakeReg(System.Security.Principal.IPrincipal p_objPrincipal, string strRegID, string strWaitID)
        {
            long lngRes = 0, lngAffects = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_lngEndTakeReg");
            if (lngRes < 0)
            {
                return -1;
            }

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;
            objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
            ParamArr[0].Value = strRegID;

            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = @"update t_opr_patientregister set PSTATUS_INT = 4 where REGISTERID_CHR = ?";

            try
            {
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
            }
            catch
            {

            }
            if (lngRes > 0)
            {
                strSQL = @"update T_OPR_TAKEDIAGREC set PSTATUS_INT=2,ENDTIME_DAT =to_date(?,'yyyy-mm-dd hh24:mi:ss')  where TAKEDIAGRECID_CHR = ?";

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = DateTime.Now.ToString();
                ParamArr[1].Value = strWaitID;
                                
                try
                {
                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            objHRPSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 更改挂号过程状态
        [AutoComplete]
        public long m_mthContinue(string strWaitID, int statues, string strType)
        {
            long lngRes = 0, lngAffects = 0;

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;

            string strSQL = @"update T_OPR_TAKEDIAGREC set PSTATUS_INT = ? ";
            if (statues == 2)
            {
                strSQL += ",ENDTIME_DAT =to_date(?,'yyyy-mm-dd hh24:mi:ss')  where " + strType + " = ?";

                objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                ParamArr[0].Value = statues.ToString();
                ParamArr[1].Value = DateTime.Now.ToString();
                ParamArr[2].Value = strWaitID;

                string temp = @"update t_opr_patientregister set PSTATUS_INT = 4  where RECORDDATE_DAT BETWEEN TO_DATE(?,'yyyy-mm-dd hh24:mi:ss') 
	                                 AND TO_DATE(?,'yyyy-mm-dd hh24:mi:ss') and PATIENTID_CHR = ?";

                IDataParameter[] ParamArr1 = null;
                objHRPSvc.CreateDatabaseParameter(3, out ParamArr1);
                ParamArr1[0].Value = DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
                ParamArr1[1].Value = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
                ParamArr1[2].Value = strWaitID;

                lngRes = objHRPSvc.lngExecuteParameterSQL(temp, ref lngAffects, ParamArr1);
            }
            else
            {
                strSQL += ",ENDTIME_DAT =null  where " + strType + " = ?";

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = statues.ToString();
                ParamArr[1].Value = strWaitID;
            }

            lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);

            objHRPSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 更改挂号过程状态
        [AutoComplete]
        public long m_lngReturnWait(System.Security.Principal.IPrincipal p_objPrincipal, string strRegID, string strWaitID)
        {
            long lngRes = 0, lngAffects = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_lngReturnWait");
            if (lngRes < 0)
            {
                return -1;
            }

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;
            objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
            ParamArr[0].Value = strRegID;

            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = @"update t_opr_patientregister set PSTATUS_INT =1 where REGISTERID_CHR = ?";

            try
            {
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            strSQL = @"update t_opr_waitdiaglist
                       set pstatus_int = 1
                       where trim(registerid_chr) = ?";

            try
            {
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = strRegID.Trim();
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
            }
            catch
            {
                return -1;
            }
            if (lngRes > 0)
            {
                strSQL = @"delete T_OPR_TAKEDIAGREC where TAKEDIAGRECID_CHR = ?";

                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = strWaitID;

                try
                {
                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
                }
                catch (Exception objEx2)
                {
                    string strTmp = objEx2.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx2);
                }
            }
            objHRPSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 检查当前挂号状态
        [AutoComplete]
        public long m_lngGetCurRegF(System.Security.Principal.IPrincipal p_objPrincipal, string RegID)
        {
            long lngRes = 0;
            DataTable dt = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();

            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_lngGetCurRegF");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"select count(REGISTERID_CHR) from t_opr_patientregister where FLAG_INT<>3 and PSTATUS_INT=1 and REGISTERID_CHR = ?";

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;
            objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
            ((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
            ParamArr[0].Value = RegID;

            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
                objHRPSvc.Dispose();
            }
            catch
            {
                //System.Windows.Forms.

            }
            if (lngRes > 0)
            {
                lngRes = long.Parse(dt.Rows[0][0].ToString());
            }
            return lngRes;
        }
        #endregion

        #region 获取病人看病次数
        /// <summary>
        /// 获取病人看病次数
        /// </summary>
        /// <param name="strPatientID"></param>
        /// <returns></returns>
        [AutoComplete]
        public int m_mthGetPatientSeeDocTimes(string strPatientID)
        {

            int timesnum = 0;
            string strSQL = @"select count(takediagdr_chr) as nums
								from t_opr_takediagrec
							   where pstatus_int = 2 								
								 and patientid_chr = ?";

            try
            {
                DataTable dt = new DataTable();

                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = strPatientID;

                long lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    timesnum += int.Parse(dt.Rows[i]["nums"].ToString());
                }
                timesnum += 1;
                objHRPSvc.Dispose();

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return timesnum;
        }
        #endregion

        #region 查找用法
        [AutoComplete]
        public long m_mthGetinjectInfo(out DataTable dt)
        {
            dt = new DataTable();
            long lngRes = 0;
            string strSQL = @"select usageid_chr, type_int, orderid_vchr from t_opr_setusage";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
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

        #region 查找对应表信息
        [AutoComplete]
        public long m_mthRelationInfo(out DataTable dt)
        {
            dt = new DataTable();
            long lngRes = 0;

            string strSQL = @"select mapid_chr, groupid_chr, catid_chr, internalflag_int
                              from t_bse_chargecatmap
                             where internalflag_int = 0";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
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

        #region 查出处方类型信息
        [AutoComplete]
        public long m_mthGetRecipeTypeInfo(System.Security.Principal.IPrincipal p_objPrincipal, out clsRecipeType_VO[] objRTVO, string strEx)
        {
            long lngRes = 0;
            objRTVO = null;
            //权限类
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsReportMaintenanceSvc", "m_mthGetRecipeTypeInfo");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = @"select   type_int, typename_vchr, r_int, g_int, b_int, remark_vchr,
                             medproperty_vchr
                            from t_aid_recipetype
                            order by type_int";


            try
            {
                DataTable dtResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtResult.Rows.Count > 0)
                {
                    objRTVO = new clsRecipeType_VO[dtResult.Rows.Count];
                    for (int i1 = 0; i1 < dtResult.Rows.Count; i1++)
                    {
                        objRTVO[i1] = new clsRecipeType_VO();
                        objRTVO[i1].B_INT = int.Parse(dtResult.Rows[i1]["B_INT"].ToString());
                        objRTVO[i1].G_INT = int.Parse(dtResult.Rows[i1]["G_INT"].ToString());
                        objRTVO[i1].R_INT = int.Parse(dtResult.Rows[i1]["R_INT"].ToString());
                        objRTVO[i1].REMARK_VCHR = dtResult.Rows[i1]["REMARK_VCHR"].ToString().Trim();
                        objRTVO[i1].TYPE_INT = dtResult.Rows[i1]["TYPE_INT"].ToString().Trim();
                        objRTVO[i1].TYPENAME_VCHR = dtResult.Rows[i1]["TYPENAME_VCHR"].ToString().Trim();
                        objRTVO[i1].MedProperty = dtResult.Rows[i1]["medproperty_vchr"].ToString().Trim();
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

        #region 查出在病历不显示的项目分类
        [AutoComplete]
        public long m_mthGetUnDisplayCat(out DataTable dt, string strID)
        {
            dt = new DataTable();
            long lngRes = 0;

            string strSQL = @"select seqid_chr, typeid_chr, typename_vchr
                              from t_opr_outpatientcasehischr
                             where seqid_chr = ?";
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = strID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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

        #region 查找检查分类
        [AutoComplete]
        public long m_mthGetApplyTypeByID(string strItemID, out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();
            string strSQL = @"SELECT a.APPLY_TYPE_INT,a.itemchecktype_chr, b.partname
                              FROM t_bse_chargeitem a, AR_APPLY_PARTLIST  b
                             WHERE a.itemchecktype_chr = b.partid(+) and  a.ITEMID_CHR = ?";
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = strItemID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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

        #region 根据项目ID查找源ID.
        [AutoComplete]
        public string m_mthGetResourceIDByItemID(string strItemID)
        {
            string lngRes = "";

            string strSQL = "select ITEMSRCID_VCHR from T_BSE_CHARGEITEM where ITEMID_CHR = ?";
            try
            {
                DataTable dt = new DataTable();

                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = strItemID;

                long l = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
                if (l > 0 && dt.Rows.Count == 1)
                {
                    lngRes = dt.Rows[0][0].ToString().Trim();
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

        #region 根据诊疗项目ID查找源ID.
        /// <summary>
        /// 根据诊疗项目ID查找源ID.
        /// </summary>
        /// <param name="strItemID"></param>
        /// <returns></returns>
        [AutoComplete]
        public string m_mthGetResourceIDByOrderDicID(string strItemID)
        {
            string lngRes = "";

            string strSQL = @"select applytypeid_chr 
                                from t_bse_bih_orderdic
                               where orderdicid_chr = ? 
                                 and status_int = 1";
            try
            {
                DataTable dt = new DataTable();

                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = strItemID;

                long l = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
                if (l > 0 && dt.Rows.Count == 1)
                {
                    lngRes = dt.Rows[0][0].ToString().Trim();
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

        #region 提交同时保存申请单映射表
        [AutoComplete]
        public long m_mthPutIn(string strID, ArrayList objArr, ArrayList objOPSarr, ArrayList objItemIDArr)
        {
            long lngRes = 0, lngAffects = 0;

            string strSQL = @"select pstauts_int, patientid_chr, diagdr_chr, registerid_chr from t_opr_outpatientrecipe where outpatrecipeid_chr = ?";
            DataTable tempdt = new DataTable();

            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] ParamArr = null;
            objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
            ParamArr[0].Value = strID;

            lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref tempdt, ParamArr);
            if (lngRes > 0 && tempdt.Rows.Count > 0)//判断如果已经收费处方就返回
            {
                if (tempdt.Rows[0]["pstauts_int"].ToString().Trim() == "2")
                {
                    return 2;
                }
            }

            //是否挂号标志
            bool blnRegFlag = false;
            if (this.m_blnIsAvailRegister(tempdt.Rows[0]["registerid_chr"].ToString().Trim(), tempdt.Rows[0]["diagdr_chr"].ToString().Trim()))
            {
                blnRegFlag = true;
            }

            int ArchTakeFlag = 0;
            int RecipeType = 0;
            if (blnRegFlag)
            {
                RecipeType = int.Parse(this.m_strGetRecipeType(tempdt.Rows[0]["registerid_chr"].ToString(), tempdt.Rows[0]["diagdr_chr"].ToString(), 1));
                ArchTakeFlag = 1;
            }
            else
            {
                RecipeType = int.Parse(this.m_strGetRecipeType(tempdt.Rows[0]["patientid_chr"].ToString(), tempdt.Rows[0]["diagdr_chr"].ToString(), 0));                
            }

            strSQL = @"update t_opr_outpatientrecipe set pstauts_int = 4, recipeflag_int = ?, archtakeflag_int = ? where outpatrecipeid_chr = ?";

            objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
            ParamArr[0].Value = RecipeType;
            ParamArr[1].Value = ArchTakeFlag;
            ParamArr[2].Value = strID;

            try
            {
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr); //保存申请单信息表
                if (lngRes > 0 && (objArr.Count > 0 || objOPSarr.Count > 0))
                {
                    foreach (clsATTACHRELATION_VO objVo in objArr)
                    {                        
                        strSQL = @"insert into t_opr_attachrelation
                                                (attarelaid_chr, sysfrom_int, attachtype_int, sourceitemid_vchr,
                                                 attachid_vchr, urgency_int, status_int
                                                )
                                         values (seq_attachrelation.nextval, ?, ?, ?,
                                                 ?, ?, 0
                                                )";

                        objHRPSvc.CreateDatabaseParameter(5, out ParamArr);                        
                        ParamArr[0].Value = objVo.strSYSFROM_INT;
                        ParamArr[1].Value = objVo.strATTACHTYPE_INT;
                        ParamArr[2].Value = objVo.strSOURCEITEMID_VCHR;
                        ParamArr[3].Value = objVo.strATTACHID_VCHR;
                        ParamArr[4].Value = objVo.strURGENCY_INT;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
                    }

                    foreach (clsOutops_VO objops in objOPSarr)
                    {
                        if (objops.recipeid.Trim() == "")
                        {
                            objops.recipeid = strID;
                        }
                                                
                        strSQL = @"insert into t_opr_opsapply
                                                (applyid_vchr, outpatrecipeid_chr, itemid_chr, opsdeptid_chr,
                                                 opsbookingdate_dat, status_int, note_vchr
                                                )
                                         values (lpad (seq_applyid.nextval, 10, '0'), ?, ?, ?,
                                                 to_date (?, 'yyyy-mm-dd hh24:mi:ss'), ?, ?
                                                )";

                        objHRPSvc.CreateDatabaseParameter(6, out ParamArr);                        
                        ParamArr[0].Value = objops.recipeid;
                        ParamArr[1].Value = objops.chrgitem;
                        ParamArr[2].Value = objops.deptid;
                        ParamArr[3].Value = objops.bookingdate;
                        ParamArr[4].Value = objops.status;
                        ParamArr[5].Value = objops.note;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
                    }
                }

                if (objItemIDArr != null)
                {
                    string ItemID1 = "";
                    string ItemID2 = "";
                    for (int i = 0; i < objItemIDArr.Count; i++)
                    {
                        if (objItemIDArr[i].ToString().StartsWith("1->"))
                        {
                            ItemID1 += "'" + objItemIDArr[i].ToString().Substring(3) + "',";
                        }
                        else if (objItemIDArr[i].ToString().StartsWith("2->"))
                        {
                            ItemID2 += "'" + objItemIDArr[i].ToString().Substring(3) + "',";
                        }
                    }

                    if (ItemID1 != "")
                    {
                        ItemID1 = ItemID1.Substring(0, ItemID1.Length - 1);

                        strSQL = @"update t_tmp_outpatientpwmrecipede a
                                        set a.discount_dec = 0
                                    where a.outpatrecipeid_chr = ?
                                      and a.itemid_chr in (" + ItemID1 + ")";

                        objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                        ParamArr[0].Value = strID;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
                    }

                    if (ItemID2 != "")
                    {
                        ItemID2 = ItemID2.Substring(0, ItemID2.Length - 1);

                        strSQL = @"update t_tmp_outpatientcmrecipede a
                                        set a.discount_dec = 0
                                    where a.outpatrecipeid_chr = ?
                                      and a.itemid_chr in (" + ItemID2 + ")";

                        objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                        ParamArr[0].Value = strID;

                        lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffects, ParamArr);
                    }
                }
            }
            catch (Exception objEx)
            {
                lngRes = -4;//代表失败
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 根据病历号获取疾病信息
        /// <summary>
        /// 根据病历号获取疾病信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="ID"></param>
        /// <param name="objICD10"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthIllnessInfo(System.Security.Principal.IPrincipal p_objPrincipal, string ID, out clsICD10_VO[] objICD10)
        {
            objICD10 = null;
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthFindCaseHistory");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @" select casehisid_chr, icdcode_vchr, icdname_vchr
                              from t_opr_opch_icd10
                             where casehisid_chr = ?";
            try
            {
                DataTable dt = new DataTable();

                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = ID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
                if (lngRes > 0 && dt.Rows.Count > 0)
                {
                    objICD10 = new clsICD10_VO[dt.Rows.Count];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        objICD10[i] = new clsICD10_VO();
                        objICD10[i].strCASEHISID_CHR = dt.Rows[i]["casehisid_chr"].ToString().Trim();
                        objICD10[i].strICDCODE_VCHR = dt.Rows[i]["icdcode_vchr"].ToString().Trim();
                        objICD10[i].strICDNAME_VCHR = dt.Rows[i]["icdname_vchr"].ToString().Trim();
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

        #region 查找样本类型
        [AutoComplete]
        public long m_lngGetLisSampletyType(System.Security.Principal.IPrincipal p_objPrincipal, string strID, string strType, out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_lngGetGeg");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT *
                              FROM t_aid_lis_sampletype
                             WHERE sample_type_desc_vchr LIKE ?
                                OR pycode_chr LIKE ?
                                OR wbcode_chr LIKE ?";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                ParamArr[0].Value = strID + "%";
                ParamArr[1].Value = strID + "%";
                ParamArr[2].Value = strID + "%";

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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

        #region 加载部位
        [AutoComplete]
        public long m_mthLoadCheckPart(out DataTable dt, string strID, string strEx)
        {
            long lngRes = 0;
            dt = new DataTable();
            string strSQL = @"SELECT a.*
                              FROM ar_apply_partlist a, t_bse_chargeitem b
                             WHERE a.typeid = b.apply_type_int
                               AND b.itemid_chr = ?
                               AND (a.assistcode_chr LIKE ? OR a.PARTNAME LIKE ?)
                               AND a.deleted = 0";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                ParamArr[0].Value = strID;
                ParamArr[1].Value = strEx + "%";
                ParamArr[2].Value = strEx + "%";

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        [AutoComplete]
        public long m_mthLoadCheckPartOrder(out DataTable dt, string strID, string strEx)
        {
            long lngRes = 0;
            dt = new DataTable();
            string strSQL = @"SELECT a.*
                              FROM ar_apply_partlist a
                             WHERE a.typeid = ?                            
                               AND (a.assistcode_chr LIKE ? OR a.PARTNAME LIKE ?)
                               AND a.deleted = 0";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                ParamArr[0].Value = strID;
                ParamArr[1].Value = strEx + "%";
                ParamArr[2].Value = strEx + "%";

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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

        #region 根据病人ID查找用药情况
        [AutoComplete]
        public long m_mthGetUsingMedicineByPatientID(out DataTable dt, string strID, string strEx)
        {
            dt = new DataTable();
            long lngRes = 0;

            string strSQL = @"SELECT   *
                                FROM (SELECT a.*, b.itemname_vchr, b.itemcode_vchr, b.itemspec_vchr,b.ITEMOPUNIT_CHR,
                                             c.typename_vchr
                                        FROM (SELECT   a.itemid_chr, SUM (a.tolqty_dec) AS COUNT
                                                  FROM t_opr_outpatientpwmrecipede a,
                                                       t_opr_outpatientrecipe b
                                                 WHERE a.outpatrecipeid_chr = b.outpatrecipeid_chr
                                                   AND b.pstauts_int = 2
                                                   AND b.patientid_chr = ? 
                                              GROUP BY a.itemid_chr) a,
                                             t_bse_chargeitem b,
                                             t_bse_chargeitemextype c
                                       WHERE a.itemid_chr = b.itemid_chr(+)
                                         AND b.itemopinvtype_chr = c.typeid_chr(+)
                                         AND c.flag_int = 2
                                      UNION
                                      SELECT a.*, b.itemname_vchr, b.itemcode_vchr, b.itemspec_vchr,b.ITEMOPUNIT_CHR,
                                             c.typename_vchr
                                        FROM (SELECT   a.itemid_chr, SUM (a.qty_dec) AS COUNT
                                                  FROM t_opr_outpatientcmrecipede a,
                                                       t_opr_outpatientrecipe b
                                                 WHERE a.outpatrecipeid_chr = b.outpatrecipeid_chr
                                                   AND b.pstauts_int = 2
                                                   AND b.patientid_chr = ? 
                                              GROUP BY a.itemid_chr) a,
                                             t_bse_chargeitem b,
                                             t_bse_chargeitemextype c
                                       WHERE a.itemid_chr = b.itemid_chr(+)
                                         AND b.itemopinvtype_chr = c.typeid_chr(+)
                                         AND c.flag_int = 2)
                                     ORDER BY itemcode_vchr";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = strID;
                ParamArr[1].Value = strID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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

        #region 获取调价信息
        [AutoComplete]
        public long m_mthGetChangePriceInfo(string strID, out DataTable dt, string strEx)
        {
            dt = new DataTable();
            long lngRes = 0;

            string strSQL = @"SELECT a.itemid_chr, a.effect_dat, TO_CHAR (a.preprice_mny) AS preprice_mny,
                                     TO_CHAR (a.curprice_mny) AS curprice_mny, a.unit_vchr,
                                     a.chargeorderid_chr, a.seqid_chr, b.itemcode_vchr, b.itemname_vchr
                                FROM t_opr_chargeitempricehis a, t_bse_chargeitem b
                               WHERE a.itemid_chr = b.itemid_chr(+) AND a.itemid_chr = ? 
                            ORDER BY effect_dat DESC";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = strID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);

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

        #region 获取收费项目子项
        /// <summary>
        /// 获取收费项目子项
        /// </summary>
        /// <param name="p_strChargeItem"></param>
        /// <param name="dtRecord"></param>
        [AutoComplete]
        public long m_lngGetSubChargeItem(string p_strChargeItem, out DataTable dtRecord)
        {
            long lngRes = 0;
            string SQL = @"select a.*, b.qty_int, b.usageid_chr, h.usagename_vchr, b.freqid_chr as subfreqid_chr, g.freqname_chr, g.times_int, g.days_int fdays,   
								  b.days_int, b.totalqty_dec, c.qty_dec, c.continueusetype_int, d.sample_type_id_chr, 
								  e.sample_type_desc_vchr, f.partname, i.noqtyflag_int, i.deptprep_int, b.usescope_int
							 from t_bse_chargeitem a,
								  (select * from t_bse_subchargeitem where (itemid_chr = ?)) b,
								  t_bse_chargeitemusagegroup c,
								  t_aid_lis_apply_unit d,
								  t_aid_lis_sampletype e,
								  ar_apply_partlist f,
								  t_aid_recipefreq g,
								  t_bse_usagetype h,
                                  t_bse_medicine i  									 		
							where a.itemid_chr = b.subitemid_chr
							  and a.itemid_chr = c.itemid_chr(+)
							  and a.usageid_chr = c.usageid_chr(+)
							  and a.itemsrcid_vchr = d.apply_unit_id_chr(+)
							  and d.sample_type_id_chr = e.sample_type_id_chr(+)
							  and a.itemchecktype_chr = f.partid(+)
							  and b.freqid_chr = g.freqid_chr(+)
							  and b.usageid_chr = h.usageid_chr(+)
                              and a.itemsrcid_vchr = i.medicineid_chr(+)";

            dtRecord = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = p_strChargeItem;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtRecord, ParamArr);
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

        #region 判断是否为收费项目的子项目
        /// <summary>
        /// 判断是否为收费项目的子项目
        /// </summary>
        /// <param name="strSubChrgItem"></param>
        /// <param name="strChrgItem"></param>
        /// <returns></returns>
        [AutoComplete]
        public bool m_blnIsSubChrgItem(string strSubChrgItem, string strChrgItem)
        {
            long lngRes = 0;
            bool blnRet = false;
            string SQL = @"select count(itemid_chr) nums from t_bse_subchargeitem where subitemid_chr = ? and itemid_chr = ?";
            DataTable dtRecord = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = strSubChrgItem;
                ParamArr[1].Value = strChrgItem;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtRecord, ParamArr);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (lngRes > 0)
            {
                if (dtRecord.Rows[0][0].ToString() != "0")
                {
                    blnRet = true;
                }
            }
            return blnRet;
        }
        #endregion

        #region 根据病历号查找有效处方号
        /// <summary>
        /// 根据病历号查找有效处方号
        /// </summary>
        /// <param name="strCaseID"></param>
        /// <param name="dtRecord"></param>
        [AutoComplete]
        public long m_lngGetRecipeIDByCaseID(string strCaseID, out DataTable dtRecord)
        {
            long lngRes = 0;
            string SQL = @"select outpatrecipeid_chr, pstauts_int
							 from t_opr_outpatientrecipe
							where pstauts_int >= 0 
							  and casehisid_chr = ?";
            dtRecord = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = strCaseID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtRecord, ParamArr);
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

        #region 根据挂号类型ID判断是否急诊
        /// <summary>
        /// 根据挂号类型ID判断是否急诊
        /// </summary>
        /// <param name="strRegTypeID"></param>
        /// <returns></returns>		
        [AutoComplete]
        public bool m_blnCheckRegiterType(string strRegTypeID)
        {
            long lngRes = 0;
            bool blnRet = false;
            string SQL = @"select count(registertypeid_chr) nums from t_bse_registertype where urgency_int = 1 and registertypeid_chr = ?";
            DataTable dtRecord = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
                ParamArr[0].Value = strRegTypeID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtRecord, ParamArr);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (lngRes > 0)
            {
                if (dtRecord.Rows[0][0].ToString() != "0")
                {
                    blnRet = true;
                }
            }
            return blnRet;
        }
        #endregion

        #region 根据处方号判断该处方是否已收费
        /// <summary>
        /// 根据处方号判断该处方是否已收费
        /// </summary>
        /// <param name="strRecID"></param>
        /// <returns></returns>
        [AutoComplete]
        public bool m_blnCheckRecipeChrg(string strRecID)
        {
            long lngRes = 0;
            bool blnRet = false;
            string SQL = @"select count(outpatrecipeid_chr) nums from t_opr_outpatientrecipe where pstauts_int = 2 and outpatrecipeid_chr = ?";
            DataTable dtRecord = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = strRecID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtRecord, ParamArr);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (lngRes > 0)
            {
                if (dtRecord.Rows[0][0].ToString() != "0")
                {
                    blnRet = true;
                }
            }
            return blnRet;
        }

        #endregion

        #region 获取医生工作站各状态参数
        /// <summary>
        /// 获取医生工作站各状态参数
        /// </summary>
        /// <param name="strType"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetWSParm(string strType, out DataTable dt)
        {
            dt = new DataTable();
            long lngRes = 0;
            string strSQL = @"select setid_chr, setname_vchr, setdesc_vchr, setstatus_int, moduleid_chr
                              from t_sys_setting
                             where setid_chr = ?";
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = strType;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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

        #region 过敏人员列表
        /// <summary>
        /// 过敏人员列表
        /// </summary>
        /// <param name="Status"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAllergiclist(out DataTable dtRecord, string DoctorID, string Status)
        {
            long lngRes = 0;
            string SQL = @"select a.*, d.patientcardid_chr, c.name_vchr, c.sex_chr, c.birth_dat
							 from t_opr_allergic a,
								  t_opr_outpatientrecipe b,
								  t_bse_patient c,
								  t_bse_patientcard d
						    where (a.patientid_chr = c.patientid_chr)
							  and (a.patientid_chr = d.patientid_chr) 
							  and (a.outpatrecipeid_chr = b.outpatrecipeid_chr)
							  and (d.status_int <> 0) 
							  and a.create_dat >= trunc(sysdate)
                              and a.create_dat <trunc(sysdate +1 )
							  and (b.diagdr_chr = ?) 
							  and (a.status_int like ?)
							order by a.create_dat";

            dtRecord = null;

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = DoctorID;
                ParamArr[1].Value = Status;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtRecord, ParamArr);
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

        #region 确认更新过敏信息
        /// <summary>
        /// 确认更新过敏信息 
        /// </summary>
        /// <param name="PatientID"></param>
        /// <param name="RecipeID"></param>
        /// <param name="AllergicMed"></param>
        /// <param name="AllergicDesc"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdateallergic(string PatientID, string RecipeID, string AllergicMed, string AllergicDesc)
        {
            string SQL = "";
            long lngRes = 0, lngAffects = 0;
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();

                IDataParameter[] ParamArr = null;

                SQL = @"update t_opr_allergic
							set	allergicmed_vchr = ?,
								allergicdesc_vchr = ?,
								status_int = 1 
						where patientid_chr = ? 
						  and outpatrecipeid_chr = ?";

                objHRPSvc.CreateDatabaseParameter(4, out ParamArr);
                ParamArr[0].Value = AllergicMed;
                ParamArr[1].Value = AllergicDesc;
                ParamArr[2].Value = PatientID;
                ParamArr[3].Value = RecipeID;

                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                SQL = @"update t_bse_patient 
							set ifallergic_int = 1,
								allergicdesc_vchr = allergicdesc_vchr || ? || ? 
						where patientid_chr = ?";

                objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                ParamArr[0].Value = AllergicMed;
                ParamArr[1].Value = AllergicDesc;
                ParamArr[2].Value = PatientID;

                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                SQL = @"update t_opr_outpatientcasehis
							set anaphylaxis_vchr = anaphylaxis_vchr || ? || ? 
						where casehisid_chr in (select casehisid_chr from t_opr_outpatientrecipe where outpatrecipeid_chr = ?)";

                objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                ParamArr[0].Value = AllergicMed;
                ParamArr[1].Value = AllergicDesc;
                ParamArr[2].Value = RecipeID;

                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 根据科室、预约时间获取门诊手术申请记录
        /// <summary>
        /// 根据科室、预约时间获取门诊手术申请记录
        /// </summary>
        /// <param name="dtRecord"></param>
        /// <param name="bookingdate"></param>
        /// <param name="deptid"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOPSApply(out DataTable dtRecord, string bookingdate, string deptid, int flag, int ischrg)
        {
            dtRecord = new DataTable();
            long lngRes = 0;

            string SQL = @"select to_number(a.applyid_vchr) as applyid_vchr, a.outpatrecipeid_chr, a.itemid_chr, a.opsdeptid_chr, 
                                  a.opsbookingdate_dat, a.confirmemp_chr, a.confirmdate_dat, a.status_int, a.note_vchr,
                                  b.name_vchr, b.sex_chr, b.birth_dat,
                                  d.itemname_vchr, e.deptname_vchr, f.patientcardid_chr,
                                  g.lastname_vchr, c.recorddate_dat, h.applyid_vchr as repflag,c.pstauts_int
                             from t_opr_opsapply a,
                                  t_bse_patient b,
                                  t_opr_outpatientrecipe c,
                                  t_bse_chargeitem d,
                                  t_bse_deptdesc e,
                                  t_bse_patientcard f,
                                  t_bse_employee g,
                                  t_opr_opsrecord h
                            where a.outpatrecipeid_chr = c.outpatrecipeid_chr
                              and c.patientid_chr = b.patientid_chr
                              and a.itemid_chr = d.itemid_chr(+)
                              and a.opsdeptid_chr = e.deptid_chr(+)
                              and c.patientid_chr = f.patientid_chr(+)
                              and c.diagdr_chr = g.empid_chr(+)
                              and (f.status_int = 1 or f.status_int = 3)
                              and a.applyid_vchr = h.applyid_vchr(+)";
            if (flag == 0)
            {
                SQL += " and a.opsdeptid_chr = '" + deptid + "' and a.status_int = 0 and a.opsbookingdate_dat <= to_date('" + bookingdate + " 23:59:59','yyyy-mm-dd hh24:mi:ss')";
            }
            else if (flag == 1)
            {
                if (ischrg == 1)
                {
                    SQL += " and a.status_int = 0 and a.opsbookingdate_dat >=trunc(sysdate) and  a.opsbookingdate_dat < trunc(sysdate + 1) ";
                }
                else
                {
                    //SQL += " and c.pstauts_int = 2 and a.status_int = 0 and to_char(a.opsbookingdate_dat, 'yyyy-mm-dd') = to_char(sysdate, 'yyyy-mm-dd')";
                    SQL += "  and a.status_int = 0 and  a.opsbookingdate_dat >= trunc(sysdate) and a.opsbookingdate_dat < trunc(sysdate + 1) ";
                }
            }
            else if (flag == 2)
            {
                SQL += " and a.status_int = 1 and a.opsbookingdate_dat>=trunc(sysdate) and  a.opsbookingdate_dat < trunc(sysdate + 1) ";
            }
            SQL += " order by a.opsbookingdate_dat ";
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dtRecord);
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
        /// <summary>
        /// 根据科室、预约时间获取门诊手术申请记录
        /// </summary>
        /// <param name="dtRecord"></param>
        /// <param name="bookingdate"></param>
        /// <param name="deptid"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOPSApply(out DataTable dtRecord, string bookingdate, string deptid, int flag, int ischrg, bool p_blnPstauts_int_2)
        {
            dtRecord = new DataTable();
            long lngRes = 0;

            string SQL = @"select to_number(a.applyid_vchr) as applyid_vchr, a.outpatrecipeid_chr, a.itemid_chr, a.opsdeptid_chr, 
                                  a.opsbookingdate_dat, a.confirmemp_chr, a.confirmdate_dat, a.status_int, a.note_vchr,
                                  b.name_vchr, b.sex_chr, b.birth_dat,
                                  d.itemname_vchr, e.deptname_vchr, f.patientcardid_chr,
                                  g.lastname_vchr, c.recorddate_dat, h.applyid_vchr as repflag
                             from t_opr_opsapply a,
                                  t_bse_patient b,
                                  t_opr_outpatientrecipe c,
                                  t_bse_chargeitem d,
                                  t_bse_deptdesc e,
                                  t_bse_patientcard f,
                                  t_bse_employee g,
                                  t_opr_opsrecord h
                            where a.outpatrecipeid_chr = c.outpatrecipeid_chr
                              and c.patientid_chr = b.patientid_chr
                              and a.itemid_chr = d.itemid_chr(+)
                              and a.opsdeptid_chr = e.deptid_chr(+)
                              and c.patientid_chr = f.patientid_chr(+)
                              and c.diagdr_chr = g.empid_chr(+)
                              and (f.status_int = 1 or f.status_int = 3)
                              and a.applyid_vchr = h.applyid_vchr(+)";
            if (p_blnPstauts_int_2)//不显示退票的
            {
                SQL += " and c.pstauts_int != -2";
            }

            if (flag == 0)
            {
                SQL += " and a.opsdeptid_chr = '" + deptid + "' and a.status_int = 0 and a.opsbookingdate_dat <= to_date('" + bookingdate + " 23:59:59','yyyy-mm-dd hh24:mi:ss')";
            }
            else if (flag == 1)
            {
                if (ischrg == 1)
                {
                    SQL += " and a.status_int = 0 and a.opsbookingdate_dat >= trunc(sysdate) and a.opsbookingdate_dat < trunc(sysdate + 1) ";
                }
                else
                {
                    SQL += " and c.pstauts_int = 2 and a.status_int = 0 and a.opsbookingdate_dat >= trunc(sysdate) and a.opsbookingdate_dat < trunc(sysdate + 1) ";
                }
            }
            else if (flag == 2)
            {
                SQL += " and a.status_int = 1 and a.opsbookingdate_dat >= trunc(sysdate) and a.opsbookingdate_dat < trunc(sysdate + 1) ";
            }
            SQL += " order by a.opsbookingdate_dat ";
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dtRecord);
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

        #region 根据申请单号获取门诊手术申请记录
        /// <summary>
        /// 根据申请单号获取门诊手术申请记录
        /// </summary>
        /// <param name="dtRecord"></param>
        /// <param name="applyid"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOPSApply(out DataTable dtRecord, string applyid)
        {
            dtRecord = new DataTable();
            long lngRes = 0;

            string SQL = @"select to_number(a.applyid_vchr) as applyid_vchr, a.outpatrecipeid_chr, a.itemid_chr, a.opsdeptid_chr, 
                                  a.opsbookingdate_dat, a.confirmemp_chr, a.confirmdate_dat, a.status_int, a.note_vchr,
                                  b.name_vchr, b.sex_chr, b.birth_dat,
                                  d.itemname_vchr, e.deptname_vchr, f.patientcardid_chr,
                                  g.lastname_vchr, c.recorddate_dat
                             from t_opr_opsapply a,
                                  t_bse_patient b,
                                  t_opr_outpatientrecipe c,
                                  t_bse_chargeitem d,
                                  t_bse_deptdesc e,
                                  t_bse_patientcard f,
                                  t_bse_employee g
                            where a.outpatrecipeid_chr = c.outpatrecipeid_chr
                              and c.patientid_chr = b.patientid_chr
                              and a.itemid_chr = d.itemid_chr(+)
                              and a.opsdeptid_chr = e.deptid_chr(+)
                              and c.patientid_chr = f.patientid_chr(+)
                              and c.diagdr_chr = g.empid_chr(+)
                              and (f.status_int = 1 or f.status_int = 3)
                              and to_number(a.applyid_vchr) = " + applyid;

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dtRecord);
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

        #region 确认门诊手术申请单
        /// <summary>
        /// 确认门诊手术申请单
        /// </summary>
        /// <param name="applyid"></param>
        /// <param name="empid"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngConfrimOPS(string applyid, string empid)
        {
            string SQL = "";
            long lngRes = 0;
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();

                SQL = @"update t_opr_opsapply
                            set status_int = 1,
                                confirmemp_chr = '" + empid + @"',
                                confirmdate_dat = sysdate
                        where to_number(applyid_vchr) = " + applyid;

                lngRes = objHRPSvc.DoExcute(SQL);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;

        }
        /// <summary>
        /// 确认门诊手术报告单
        /// </summary>
        /// <param name="applyid"></param>
        /// <param name="empid"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngConfrimOPSReport(string applyid, string empid)
        {
            string SQL = "";
            long lngRes = 0;
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();

                SQL = @"update t_opr_opsrecord
                            set status_int = 1,
                                confirmemp_chr = '" + empid + @"',
                                confirmdate_dat = sysdate
                        where to_number(applyid_vchr) = " + applyid;

                lngRes = objHRPSvc.DoExcute(SQL);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;

        }
        #endregion

        #region 返回科室ID和科室名称数组
        /// <summary>
        /// 返回科室ID和科室名称数组
        /// </summary>
        /// <param name="p_strLike"></param>
        /// <param name="p_strDeptArr"></param>
        /// <param name="p_strDeptID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDeptAreaByLike(string p_strLike, out string[,] p_strDeptArr, string p_strDeptID)
        {
            p_strDeptArr = null;
            DataTable dtResult = m_dtbGetDept(p_strLike, p_strDeptID);
            if (dtResult == null || dtResult.Rows.Count == 0)
            {
                return 0;
            }

            p_strDeptArr = new string[dtResult.Rows.Count, 2];

            for (int i = 0; i < dtResult.Rows.Count; i++)
            {
                p_strDeptArr[i, 0] = dtResult.Rows[i]["DEPTID_CHR"].ToString().Trim();
                p_strDeptArr[i, 1] = dtResult.Rows[i]["DEPTNAME_VCHR"].ToString().Trim();
            }

            return 1;
        }
        #endregion

        #region 取得科室
        /// <summary>
        /// 取得科室
        /// </summary>
        /// <param name="p_strLike"></param>
        /// <param name="p_strDeptID"></param>
        /// <returns></returns>
        [AutoComplete]
        private DataTable m_dtbGetDept(string p_strLike, string p_strDeptID)
        {
            DataTable dtResult = new DataTable();
            dtResult = null;
            try
            {
                if (p_strLike == null)
                {
                    return null;
                }

                string strSql = @"select t.deptid_chr, t.modify_dat, t.deptname_vchr, t.category_int,
                                   t.inpatientoroutpatient_int, t.operatorid_chr, t.address_vchr,
                                   t.pycode_chr, t.attributeid, t.parentid, t.createdate_dat,
                                   t.status_int, t.deactivate_dat, t.wbcode_chr, t.code_vchr,
                                   t.extendid_vchr, t.shortno_chr, t.stdbed_count_int, t.putmed_int
                              from t_bse_deptdesc t ";

                clsHRPTableService objHRPServer = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                if (p_strLike.Trim() != "")
                {
                    strSql += @" where (t.deptid_chr like ? or t.deptname_vchr like ?  
								 or (t.pycode_chr like ?) or (t.wbcode_chr like ?)
								 or t.shortno_chr like ?) and t.status_int = '1' and t.category_int = '0'";

                    objHRPServer.CreateDatabaseParameter(5, out ParamArr);
                    ParamArr[0].Value = p_strLike.Trim() + "%";
                    ParamArr[1].Value = "%" + p_strLike.Trim() + "%";
                    ParamArr[2].Value = p_strLike.Trim().ToUpper() + "%";
                    ParamArr[3].Value = p_strLike.Trim().ToUpper() + "%";
                    ParamArr[4].Value = p_strLike.Trim() + "%";
                }
                else
                {
                    strSql += @" where t.status_int = '1' and t.category_int = '0'";
                }

                if (p_strDeptID != null)
                {
                    if (p_strDeptID.Trim() != "")
                    {
                        strSql += @" and t.attributeid = '0000003' and t.parentid = ?";

                        if (ParamArr == null)
                        {
                            objHRPServer.CreateDatabaseParameter(1, out ParamArr);
                            ParamArr[1].Value = p_strDeptID.Trim();
                        }
                        else
                        {
                            objHRPServer.CreateDatabaseParameter(6, out ParamArr);
                            ParamArr[0].Value = p_strLike.Trim() + "%";
                            ParamArr[1].Value = "%" + p_strLike.Trim() + "%";
                            ParamArr[2].Value = p_strLike.Trim().ToUpper() + "%";
                            ParamArr[3].Value = p_strLike.Trim().ToUpper() + "%";
                            ParamArr[4].Value = p_strLike.Trim() + "%";
                            ParamArr[5].Value = p_strDeptID.Trim();
                        }
                    }
                }

                strSql += @"order by deptname_vchr";

                long lngRes = 0;

                if (ParamArr == null)
                {
                    lngRes = objHRPServer.DoGetDataTable(strSql, ref dtResult);
                }
                else
                {
                    lngRes = objHRPServer.lngGetDataTableWithParameters(strSql, ref dtResult, ParamArr);
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return dtResult;
        }
        #endregion

        #region 根据操作员工号获取ID、姓名和密码
        /// <summary>
        /// 根据操作员工号获取ID、姓名和密码
        /// </summary>
        /// <param name="dtRecord"></param>
        /// <param name="empno"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetempinfo(out DataTable dtRecord, string empno)
        {
            long lngRes = 0;
            dtRecord = new DataTable();

            string SQL = @"select empid_chr, lastname_vchr, psw_chr from t_bse_employee where status_int = 1 and empno_chr = ?";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
                ParamArr[0].Value = empno;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtRecord, ParamArr);
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

        #region 保存门诊手术记录信息
        /// <summary>
        /// 保存门诊手术记录信息
        /// </summary>
        /// <param name="applyid"></param>
        /// <param name="Ops"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSaveOPS(string applyid, clsOutops_VO objops)
        {
            string SQL = "";
            long lngRes = 0;
            DataTable dt = new DataTable();
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();

                SQL = "select applyid_vchr from t_opr_opsapply where to_number(applyid_vchr) = " + applyid;

                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dt);
                if (dt.Rows.Count == 1)
                {
                    applyid = dt.Rows[0][0].ToString();
                }

                SQL = "delete from t_opr_opsrecord where applyid_vchr = '" + applyid + "'";

                lngRes = objHRPSvc.DoExcute(SQL);

                SQL = @"insert into t_opr_opsrecord(applyid_vchr, opsname_vchr, opsdate_dat, prediagnoses_vchr, enddiagnoses_vchr,
                                                    opsdoctor_chr, opsassistant1_chr, opsappliance_chr, opsanamode_chr, anaemp1_chr,
                                                    opsresult_vchr, signdoctor_chr, signdate_dat) values('" +
                                                applyid + "', '" +
                                                objops.opsname + "', to_date('" +
                                                objops.opsdate + "', 'yyyy-mm-dd hh24:mi:ss'), '" +
                                                objops.prediagnoses + "', '" +
                                                objops.enddiagnoses + "', '" +
                                                objops.opsdoctor + "', '" +
                                                objops.opsassistant1 + "', '" +
                                                objops.opsappliance + "', '" +
                                                objops.opsanamode + "', '" +
                                                objops.anaempid1 + "', '" +
                                                objops.opsresult + "', '" +
                                                objops.signdoctor + "', to_date('" +
                                                objops.signdate + "', 'yyyy-mm-dd hh24:mi:ss'))";

                lngRes = objHRPSvc.DoExcute(SQL);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 根据申请单号获取手术报告单信息
        /// <summary>
        /// 根据申请单号获取手术报告单信息
        /// </summary>
        /// <param name="applyid"></param>
        /// <param name="dtRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetopsrecord(string applyid, out DataTable dtRecord)
        {
            long lngRes = 0;
            dtRecord = new DataTable();

            string SQL = @"select applyid_vchr, opsname_vchr, opsdate_dat, prediagnoses_vchr,
                           enddiagnoses_vchr, opsdoctor_chr, opsassistant1_chr, opsassistant2_chr,
                           opsassistant3_chr, opsappliance_chr, opsanamode_chr, anaemp1_chr,
                           anaemp2_chr, opsresult_vchr, signdoctor_chr, signdate_dat, note_vchr,
                           confirmemp_chr, confirmdate_dat, status_int
                      from t_opr_opsrecord  where to_number(applyid_vchr) = ?";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPSvc.CreateDatabaseParameter(1,out objDPArr);
                objDPArr[0].Value = applyid;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtRecord,objDPArr);
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

        #region 获取处方审核未通过的记录
        /// <summary>
        /// 获取处方审核未通过的记录
        /// </summary>
        /// <param name="DoctorID"></param>
        /// <param name="dtRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetrecipeconfirmfall(string DoctorID, out DataTable dtRecord)
        {
            long lngRes = 0;
            string SQL = @"select   a.outpatrecipeid_chr, a.patientid_chr, a.createdate_dat,
         a.registerid_chr, a.diagdr_chr, a.diagdept_chr, a.recordemp_chr,
         a.recorddate_dat, a.pstauts_int, a.recipeflag_int,
         a.outpatrecipeno_vchr, a.paytypeid_chr, a.casehisid_chr,
         a.groupid_chr, a.type_int, a.confirm_int, a.confirmdesc_vchr,
         a.createtype_int, a.deptmed_int, c.patientcardid_chr, b.name_vchr,
         b.sex_chr, b.birth_dat
    from t_opr_outpatientrecipe a, t_bse_patient b, t_bse_patientcard c
   where (a.patientid_chr = b.patientid_chr)
     and (a.patientid_chr = c.patientid_chr)
     and (c.status_int <> 0)
     and (a.confirm_int = -1)
     and a.createdate_dat>=trunc(sysdate) and a.createdate_dat < trunc(sysdate +1 ) 
     and (a.diagdr_chr = ?)
order by a.outpatrecipeid_chr
";

            dtRecord = null;

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = DoctorID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtRecord, ParamArr);
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

        #region 获取门诊手术报告单信息
        /// <summary>
        /// 获取门诊手术报告单信息
        /// </summary>
        /// <param name="SQLSelect"></param>
        /// <param name="dtRecord"></param>
        /// <returns></returns>
        public long m_lngGetopsreports(string SQLSelect, out DataTable dtRecord)
        {
            long lngRes = 0;
            dtRecord = null;

            string SQL = @"select to_number(a.applyid_vchr) as applyid_vchr, b.name_vchr, b.sex_chr, b.birth_dat,
                                  e.deptname_vchr, f.patientcardid_chr, h.opsname_vchr,
                                  h.opsdate_dat, h.opsdoctor_chr, h.opsresult_vchr
                             from t_opr_opsapply a,
                                  t_bse_patient b,
                                  t_opr_outpatientrecipe c,
                                  t_bse_chargeitem d,
                                  t_bse_deptdesc e,
                                  t_bse_patientcard f,
                                  t_bse_employee g,
                                  t_opr_opsrecord h
                            where a.outpatrecipeid_chr = c.outpatrecipeid_chr
                              and c.patientid_chr = b.patientid_chr
                              and a.itemid_chr = d.itemid_chr(+)
                              and a.opsdeptid_chr = e.deptid_chr(+)
                              and c.patientid_chr = f.patientid_chr(+)
                              and c.diagdr_chr = g.empid_chr(+)
                              and (f.status_int = 1 or f.status_int = 3)
                              and a.applyid_vchr = h.applyid_vchr";

            SQL += SQLSelect;

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dtRecord);
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

        #region 获取麻醉方式
        /// <summary>
        /// 获取麻醉方式
        /// </summary>
        /// <param name="dtRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetanaesthesiamode(out DataTable dtRecord)
        {
            long lngRes = 0;
            dtRecord = new DataTable();

            string SQL = @"select anaesthesiamodeid, anaesthesiamodename, iftechnology, status,
                           deaactiveddate, operationid
                          from anaesthesiamode";
                   

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dtRecord);
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

        #region 模糊查找员工，返回员工ID和员工名称数组
        /// <summary>
        /// 模糊查找员工，返回员工ID和员工名称数组
        /// </summary>
        /// <param name="p_strLike"></param>
        /// <param name="p_strNameArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetEmployeeNameByLike(string p_strLike, out string[,] p_strNameArr)
        {
            long lngRes = 0;
            p_strNameArr = null;

            try
            {
                if (p_strLike == null)
                {
                    return -1;
                }

                string strSql = @"select distinct t.empno_chr,t.lastname_vchr from t_bse_employee t inner join t_bse_deptemp a
									on t.empid_chr = a.empid_chr inner join t_bse_deptdesc b on a.deptid_chr = b.deptid_chr where (
									t.empno_chr like ? or t.lastname_vchr like ? or t.pycode_chr like ? 
									or t.shortname_chr like ?) and t.status_int = '1' order by t.lastname_vchr";

                DataTable dtResult = new DataTable();

                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(4, out ParamArr);
                ParamArr[0].Value = p_strLike.Trim() + "%";
                ParamArr[1].Value = "%" + p_strLike.Trim() + "%";
                ParamArr[2].Value = p_strLike.Trim().ToUpper() + "%";
                ParamArr[3].Value = p_strLike.Trim() + "%";

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql, ref dtResult, ParamArr);

                if (lngRes <= 0 || dtResult.Rows.Count <= 0)
                {
                    return 0;
                }

                p_strNameArr = new string[dtResult.Rows.Count, 2];
                for (int i = 0; i < dtResult.Rows.Count; i++)
                {
                    p_strNameArr[i, 0] = dtResult.Rows[i]["EMPNO_CHR"].ToString().Trim();
                    p_strNameArr[i, 1] = dtResult.Rows[i]["LASTNAME_VCHR"].ToString().Trim();
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }

        /// <summary>
        /// 模糊查找员工，返回员工ID和员工名称数组
        /// </summary>
        /// <param name="p_strLike"></param>
        /// <param name="p_strNameArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetEmployeeNameByLikeNew(string p_strLike, out string[,] p_strNameArr)
        {
            long lngRes = 0;
            p_strNameArr = null;

            try
            {
                if (p_strLike == null)
                {
                    return -1;
                }

                string strSql = @"select distinct t.EMPID_CHR ,t.empno_chr,t.lastname_vchr from t_bse_employee t inner join t_bse_deptemp a
									on t.empid_chr = a.empid_chr inner join t_bse_deptdesc b on a.deptid_chr = b.deptid_chr where (
									t.empno_chr like ? or t.lastname_vchr like ? or t.pycode_chr like ? 
									or t.shortname_chr like ?) and t.status_int = '1' order by t.empno_chr";

                DataTable dtResult = new DataTable();

                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(4, out ParamArr);
                ParamArr[0].Value = p_strLike.Trim() + "%";
                ParamArr[1].Value = "%" + p_strLike.Trim() + "%";
                ParamArr[2].Value = p_strLike.Trim().ToUpper() + "%";
                ParamArr[3].Value = p_strLike.Trim() + "%";

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql, ref dtResult, ParamArr);

                if (lngRes <= 0 || dtResult.Rows.Count <= 0)
                {
                    return 0;
                }

                p_strNameArr = new string[dtResult.Rows.Count, 3];
                for (int i = 0; i < dtResult.Rows.Count; i++)
                {
                    p_strNameArr[i, 0] = dtResult.Rows[i]["EMPNO_CHR"].ToString().Trim();
                    p_strNameArr[i, 1] = dtResult.Rows[i]["LASTNAME_VCHR"].ToString().Trim();
                    p_strNameArr[i, 2] = dtResult.Rows[i]["EMPID_CHR"].ToString().Trim();
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }
        /// <summary>
        /// 模糊查找员工，返回员工ID和员工名称数组
        /// </summary>
        /// <param name="p_strLike"></param>
        /// <param name="p_strNameArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetEmployeeNameByID(string p_strLike, out string[,] p_strNameArr)
        {
            long lngRes = -1;
            p_strNameArr = null;

            try
            {
                if (p_strLike == null)
                {
                    return -1;
                }

                string strSql = @"SELECT empid_chr ,lastname_vchr
                                            FROM  t_bse_employee  ";
                strSql += " where " + p_strLike;
                DataTable dtResult = new DataTable();
                clsHRPTableService objHRPServer = new clsHRPTableService();
                lngRes = objHRPServer.DoGetDataTable(strSql, ref dtResult);
                if (lngRes <= 0)
                {
                    return -1;
                }
                else
                {
                    lngRes = 1;
                }
                if (dtResult.Rows.Count <= 0)
                {
                    return 0;
                }
                p_strNameArr = new string[dtResult.Rows.Count, 2];
                for (int i = 0; i < dtResult.Rows.Count; i++)
                {
                    p_strNameArr[i, 0] = dtResult.Rows[i]["empid_chr"].ToString().Trim();
                    p_strNameArr[i, 1] = dtResult.Rows[i]["lastname_vchr"].ToString().Trim();
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        #endregion

        #region 根据收费ID判断是否属于手术费用
        /// <summary>
        /// 根据收费ID判断是否属于手术费用
        /// </summary>
        /// <param name="chrgitemcode"></param>
        /// <returns></returns>
        [AutoComplete]
        public bool m_blnChkopsitem(string chrgitemcode)
        {
            long lngRes = 0;
            bool blnRet = false;

            string SQL = @"select count(itemid_chr) as nums 
                             from t_bse_chargeitem 
                            where (usageid_chr in (select usageid_chr from t_bse_usagetype where trim(usagename_vchr) = '手术'))
                              and itemid_chr = ?";
            DataTable dtRecord = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = chrgitemcode;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtRecord, ParamArr);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (lngRes > 0)
            {
                if (dtRecord.Rows[0][0].ToString() != "0")
                {
                    blnRet = true;
                }
            }
            return blnRet;
        }
        #endregion

        #region 根据条件获取手术申请单信息.

        /// <summary>
        /// 根据条件获取手术申请单信息
        /// </summary>
        /// <param name="p_strOr"></param>
        /// <param name="dtRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetApplyOPInfoByOrCondition(string p_strOr, out DataTable dtRecord)
        {//状态 -1 删除；0 新建；1 已确认；2 退回
            long lngRes = 0;
            dtRecord = new DataTable();
            string SQL = @"SELECT   TO_NUMBER (a.applyid_vchr) AS applyid_vchr, b.name_vchr, rtrim(b.sex_chr) as sex_chr,
                                                         b.birth_dat,  f.patientcardid_chr,a.opsbookingdate_dat,d.ITEMNAME_VCHR as OPSNAME_VCHR
                                                        , CASE 
                                                         WHEN a.status_int = -1 then '删除'
                                                         WHEN a.status_int =0   then '新建'
                                                         WHEN a.status_int = 1  then '已确认'
                                                         ELSE '退回' 
                                                        END status_int
                            FROM t_opr_opsapply a,
                                 t_bse_patient b,
                                 t_opr_outpatientrecipe c,
                                 t_bse_chargeitem d,
                                 t_bse_deptdesc e,
                                 t_bse_patientcard f,
                                 t_bse_employee g,
                                 t_opr_opsrecord h
                           WHERE a.outpatrecipeid_chr = c.outpatrecipeid_chr
                             AND c.patientid_chr = b.patientid_chr
                             AND a.itemid_chr = d.itemid_chr(+)
                             AND a.opsdeptid_chr = e.deptid_chr(+)
                             AND c.patientid_chr = f.patientid_chr(+)
                             AND c.diagdr_chr = g.empid_chr(+)
                             AND (f.status_int = 1 OR f.status_int = 3)
                             AND a.applyid_vchr = h.applyid_vchr(+) ";
            if (p_strOr != "")
            {
                SQL += p_strOr;
            }
            SQL += " ORDER BY applyid_vchr ";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dtRecord);
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

        #region 更新手术申请单信息预约时间
        /// <summary>
        /// 更新手术申请单信息预约时间
        /// </summary>
        /// <param name="p_strAPPLYID_VCHR"></param>
        /// <param name="p_strOPSBOOKINGDATE_DAT"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetApplyOPInfoUpdateDate(string p_strAPPLYID_VCHR, string p_strOPSBOOKINGDATE_DAT)
        {
            long lngRes = 0;
            string SQL = "update t_opr_opsapply set OPSBOOKINGDATE_DAT=to_date('" + p_strOPSBOOKINGDATE_DAT + "','yyyy-MM-dd HH24:mi:ss') where APPLYID_VCHR='" + p_strAPPLYID_VCHR + "'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(SQL);
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

        #region 生成患者身份对应号表
        /// <summary>
        /// 生成患者身份对应号表
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="paytypeid"></param>
        /// <param name="idno"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGenpatientidentityno(string pid, string paytypeid, string idno)
        {
            string SQL = "";
            long lngRes = 0, lngAffects = 0;

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                SQL = "delete from t_bse_patientidentityno where patientid_chr = ? and paytypeid_chr = ?";

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = pid;
                ParamArr[1].Value = paytypeid;

                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                SQL = @"insert into t_bse_patientidentityno(patientid_chr, paytypeid_chr, idno_vchr)
                                                    values (?, ?, ?)";

                objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                ParamArr[0].Value = pid;
                ParamArr[1].Value = paytypeid;
                ParamArr[2].Value = idno;

                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 根据患者ID，和身份ID获取身份所对应号
        /// <summary>
        /// 根据患者ID，和身份ID获取身份所对应号
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="paytypeid"></param>
        /// <returns></returns>
        [AutoComplete]
        public string m_strGetpatientidentityno(string pid, string paytypeid)
        {
            long lngRes = 0;
            string idno = "";
            string SQL = "select idno_vchr from t_bse_patientidentityno where patientid_chr = ? and paytypeid_chr = ?";
            DataTable dtRecord = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = pid;
                ParamArr[1].Value = paytypeid;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtRecord, ParamArr);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (lngRes > 0)
            {
                if (dtRecord.Rows.Count == 1)
                {
                    idno = dtRecord.Rows[0][0].ToString().Trim();
                }
            }

            return idno;
        }
        #endregion

        #region 根据发票号获取身份所对应号
        /// <summary>
        /// 根据发票号获取身份所对应号
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="paytypeid"></param>
        /// <returns></returns>
        [AutoComplete]
        public string m_strGetpatientidentityno(string invo)
        {
            long lngRes = 0;
            string idno = "";
            string SQL = @"select a.idno_vchr 
                             from t_bse_patientidentityno a,
                                  t_opr_outpatientrecipeinv b
                            where a.patientid_chr = b.patientid_chr
                              and a.paytypeid_chr = b.paytypeid_chr
                              and b.invoiceno_vchr = ?";

            DataTable dtRecord = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = invo;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtRecord, ParamArr);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (lngRes > 0)
            {
                if (dtRecord.Rows.Count == 1)
                {
                    idno = dtRecord.Rows[0][0].ToString().Trim();
                }
            }

            return idno;
        }
        #endregion

        #region 根据操作员ID获取毒、麻药、处方权限
        /// <summary>
        /// 根据操作员ID获取毒、麻药、处方权限
        /// </summary>
        /// <param name="empid"></param>
        /// <param name="neurpur"></param>
        /// <param name="drugpur"></param>
        /// <returns></returns>
        [AutoComplete]
        public void m_mthGetmedpurview(string empid, out string neurpur, out string drugpur, out string recpur)
        {
            neurpur = "";
            drugpur = "";
            recpur = "";
            string SQL = @"select HASPSYCHOSISPRESCRIPTIONRIGHT_, HASOPIATEPRESCRIPTIONRIGHT_CHR, HASPRESCRIPTIONRIGHT_CHR from t_bse_employee where empid_chr = ?";
            DataTable dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = empid;

                long lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
                if (lngRes > 0 && dt.Rows.Count == 1)
                {
                    neurpur = dt.Rows[0]["HASPSYCHOSISPRESCRIPTIONRIGHT_"].ToString();
                    drugpur = dt.Rows[0]["HASOPIATEPRESCRIPTIONRIGHT_CHR"].ToString();
                    recpur = dt.Rows[0]["HASPRESCRIPTIONRIGHT_CHR"].ToString();
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
        }
        #endregion

        #region 根据收费项目判断是否为片剂
        /// <summary>
        /// 根据收费项目判断是否为片剂
        /// </summary>
        /// <param name="chrgitemid"></param>
        /// <returns></returns>
        [AutoComplete]
        public bool m_blnCheckmedicament(string chrgitemid)
        {
            long lngRes = 0;
            bool blnRet = false;

            string SQL = @"select count(a.itemid_chr) as nums
                             from t_bse_chargeitem a,
                                  t_bse_medicine b,
                                  t_aid_medicinepreptype c
                            where a.itemsrcid_vchr = b.medicineid_chr
                              and b.medicinepreptype_chr = c.medicinepreptype_chr
                              and trim(c.medicinepreptypename_vchr) like '%片剂%'
                              and a.itemid_chr = ?";

            DataTable dtRecord = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = chrgitemid;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtRecord, ParamArr);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (lngRes > 0)
            {
                if (dtRecord.Rows[0][0].ToString() != "0")
                {
                    blnRet = true;
                }
            }
            return blnRet;
        }
        #endregion

        #region 设置初始化模板数据
        /// <summary>
        /// 设置初始化模板数据
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strFormName"></param>
        /// <param name="p_strFormDesc"></param>
        /// <param name="p_strControlName"></param>
        /// <param name="p_strControlDesc"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSetModeByItem(System.Security.Principal.IPrincipal p_objPrincipal, string p_strFormName, string p_strFormDesc, string p_strControlName, string p_strControlDesc)
        {
            long lngRes = 0;
            DataTable dt = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();

            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_lngSetModeByItem");
            if (lngRes < 0)
            {
                return -1;
            }
            #region 一条SQL完成
            //            string strSQL = @"
            //                                DECLARE
            //                                   v_count   NUMBER := 0;
            //                                   v_id      NUMBER := 0;
            //                                BEGIN
            //                                   SELECT COUNT (*)
            //                                     INTO v_count
            //                                     FROM gui_control
            //                                    WHERE form_id = '"+p_strFormName+@"'
            //                                          AND control_id = '"+p_strControlName+@"';
            //
            //                                   IF v_count = 0
            //                                   THEN
            //                                      BEGIN
            //                                         INSERT INTO gui_control
            //                                                     (form_id, control_id,
            //                                                      control_desc, order_no
            //                                                     )
            //                                              VALUES ('"+p_strFormName+@"', '"+p_strControlName+@"',
            //                                                      '"+p_strControlDesc+@"', 0
            //                                                     );
            //                                      END;
            //                                   END IF;
            //
            //                                   SELECT MAX (ID) + 1
            //                                     INTO v_id
            //                                     FROM gui_form;
            //
            //                                   SELECT COUNT (*)
            //                                     INTO v_count
            //                                     FROM gui_form
            //                                    WHERE form_id = '"+p_strFormName+@"';
            //
            //                                   IF v_count = 0
            //                                   THEN
            //                                      BEGIN
            //                                         INSERT INTO gui_form
            //                                                     (ID, form_id, parent_id, form_desc
            //                                                     )
            //                                              VALUES (v_id, '"+p_strFormName+@"', 0, '"+p_strFormDesc+@"'
            //                                                     );
            //                                      END;
            //                                   END IF;
            //                                END;
            //                                ";

            #endregion
            try
            {
                #region 以下是上面"一条SQL完成"的语句的拆分,因为上面不知报乜错
                string strSelectId = @" SELECT MAX (ID) + 1  FROM gui_form";
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSelectId, ref dt);
                string id = dt.Rows[0][0].ToString();
                string strSel = @"SELECT COUNT (*)
                                                     
                                                     FROM gui_control
                                                    WHERE form_id = '" + p_strFormName + @"'
                                                          AND control_id = '" + p_strControlName + @"'";
                lngRes = objHRPSvc.DoGetDataTable(strSel, ref dt);
                string strinsert = "";
                if (lngRes > 0)
                {
                    if (dt.Rows[0][0].ToString() == "0")
                    {
                        strinsert = @" INSERT INTO gui_control
                                                                     (form_id, control_id,
                                                                      control_desc, order_no
                                                                     )
                                                              VALUES ('" + p_strFormName + @"', '" + p_strControlName + @"',
                                                                      '" + p_strControlDesc + @"', 0
                                                                     )";
                        lngRes = objHRPSvc.DoExcute(strinsert);
                        if (lngRes <= 0)
                        {
                            return lngRes;
                        }
                    }
                }
                else
                {
                    return lngRes;
                }
                string sel2 = @"     SELECT COUNT (*)
                                                     
                                                     FROM gui_form
                                                    WHERE form_id = '" + p_strFormName + @"'";
                lngRes = objHRPSvc.DoGetDataTable(sel2, ref dt);
                strinsert = "";
                if (lngRes > 0)
                {
                    if (dt.Rows[0][0].ToString() == "0")
                    {
                        strinsert = @"  INSERT INTO gui_form
                                                                     (ID, form_id, parent_id, form_desc
                                                                     )
                                                              VALUES (" + id + @", '" + p_strFormName + @"', 0, '" + p_strFormDesc + @"'
                                                                     )";
                        lngRes = objHRPSvc.DoExcute(strinsert);
                        if (lngRes <= 0)
                        {
                            return lngRes;
                        }
                    }
                }
                else
                {
                    return lngRes;
                }
                #endregion

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

        #region 获取药品毒性、麻醉、精神一、二类属性
        /// <summary>
        /// 获取药品毒性、麻醉、精神一、二类属性
        /// </summary>
        /// <param name="chrgitemid"></param>
        /// <param name="dtRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetmedproperty(string chrgitemid, out DataTable dtRecord)
        {
            long lngRes = 0;
            dtRecord = new DataTable();

            string SQL = @"select a.isanaesthesia_chr, a.ispoison_chr, a.ischlorpromazine_chr, a.ischlorpromazine2_chr, a.medicinetypeid_chr 
                             from t_bse_medicine a,
                                  t_bse_chargeitem b
                            where a.medicineid_chr = b.itemsrcid_vchr
                              and b.itemid_chr = ?";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = chrgitemid;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtRecord, ParamArr);
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

        #region 获取新系统参数
        /// <summary>
        /// 获取新系统参数
        /// </summary>
        /// <param name="parmcode">参数代码</param>
        /// <returns>值</returns>
        [AutoComplete]
        public string m_strGetSysparm(string parmcode)
        {
            string parmvalue = "";
            try
            {
                string SQL = @"select parmvalue_vchr
                                 from t_bse_sysparm 
                                where status_int = 1 
                                  and parmcode_chr = ?";

                DataTable dt = new DataTable();

                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
                ParamArr[0].Value = parmcode;

                long l = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
                if (l > 0)
                {
                    parmvalue = dt.Rows[0][0].ToString().Trim();
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return parmvalue;
        }
        #endregion

        #region 自动生成当前处方属性(1 正方、2 付方)
        /// <summary>
        /// 自动生成当前处方属性(1 正方、2 付方)
        /// </summary>
        /// <param name="PatientID"></param>
        /// <param name="DoctorID"></param>
        /// <param name="Flag">0 未挂号 1 已挂号</param>
        /// <returns></returns>
        [AutoComplete]
        public string m_strGetRecipeType(string PatientID, string DoctorID, int Flag)
        {
            string RecipeType = "1";
            string SQL = "";
            long l = 0;

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                DataTable dt = new DataTable();

                if (Flag == 0)
                {
                    SQL = @"select count(a.outpatrecipeid_chr) 
                              from t_opr_outpatientrecipe a 
                             where a.patientid_chr = ?  
                               and a.diagdr_chr = ? 
                               and (a.pstauts_int = 2 or a.pstauts_int = 3 or a.pstauts_int = 4) 
                               and a.recorddate_dat >=trunc(sysdate) and a.recorddate_dat <trunc(sysdate + 1) ";

                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = PatientID;
                    ParamArr[1].Value = DoctorID;
                }
                else if (Flag == 1)
                {
                    int TimeInterval = 0;
                    SQL = @"select setstatus_int from t_sys_setting where setid_chr = ?";

                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = "0067";

                    l = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
                    if (l > 0 && dt.Rows.Count == 1)
                    {
                        string s = dt.Rows[0][0].ToString().Trim();
                        if (s != "" && Convert.ToInt32(s) > 0)
                        {
                            TimeInterval = Convert.ToInt32(s);
                        }
                    }

                    SQL = @"select count(a.outpatrecipeid_chr) 
                              from t_opr_outpatientrecipe a 
                             where trim(a.registerid_chr) = ?  
                               and a.diagdr_chr = ? 
                               and (a.pstauts_int = 2 or a.pstauts_int = 3 or a.pstauts_int = 4) 
                               and (sysdate between a.recorddate_dat and (a.recorddate_dat + ?/24))";

                    objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                    ParamArr[0].Value = PatientID.Trim();
                    ParamArr[1].Value = DoctorID;
                    ParamArr[2].Value = TimeInterval;
                }

                l = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
                if (l > 0 && dt.Rows.Count == 1)
                {
                    if (int.Parse(dt.Rows[0][0].ToString()) > 0)
                    {
                        RecipeType = "2";
                    }
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return RecipeType;
        }
        #endregion

        #region (医保)获取特病医保年度起止日期

        #endregion

        #region (医保)获取特种病信息
        /// <summary>
        /// (医保)获取特种病信息
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetYBSpeciaTypeDisease(out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();

            string SQL = @"select a.* 
                             from t_opr_ybspecialtypedisease a                                     
                            where a.status_int = 1 ";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dt);
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

        #region (医保)根据特种病代码获取所对应的ICD10
        /// <summary>
        /// (医保)根据特种病代码获取所对应的ICD10
        /// </summary>
        /// <param name="deacode"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetICD10ByDeacode(string deacode, out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();

            string SQL = @"select a.deacode_chr, a.deadesc_vchr, a.yearmoney_int, a.sort_int,
                                   a.status_int, a.note_vchr, b.icdcode_chr, c.icdname_vchr
                              from t_opr_ybspecialtypedisease a, t_opr_ybdeadeficd10 b, t_aid_icd10 c
                             where a.deacode_chr = b.deacode_chr
                               and b.icdcode_chr = c.icdcode_chr
                               and a.status_int = 1
                               and a.deacode_chr = ?
                            ";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
                ParamArr[0].Value = deacode;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        #region (医保)根据ICD10获取所对应的特种病代码
        /// <summary>
        /// (医保)根据ICD10获取所对应的特种病代码
        /// </summary>
        /// <param name="icd10_id"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetYBSpeciaTypeDiseaseByICD10(string icd10_id, out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();

            string SQL = @"select a.deacode_chr, a.deadesc_vchr, a.yearmoney_int, a.sort_int,
                                   a.status_int, a.note_vchr, b.icdcode_chr
                              from t_opr_ybspecialtypedisease a, t_opr_ybdeadeficd10 b
                             where a.deacode_chr = b.deacode_chr and a.status_int = 1
                                   and b.icdcode_chr = ?";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
                ParamArr[0].Value = icd10_id;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        #region (医保)根据特种病代码获取所对应的收费项目
        /// <summary>
        /// (医保)根据特种病代码获取所对应的收费项目
        /// </summary>
        /// <param name="deacode"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetYBSpecChargeItemByDeacode(string deacode, out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();

            string SQL = @"select a.deacode_chr, a.deadesc_vchr, a.yearmoney_int, a.sort_int,
                                   a.status_int, a.note_vchr, b.itemid_chr
                              from t_opr_ybspecialtypedisease a, t_opr_ybdeadefchargeitem b
                             where a.deacode_chr = b.deacode_chr and a.status_int = 1
                                   and a.deacode_chr = ?";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
                ParamArr[0].Value = deacode;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        #region 根据处方号获取处方打印信息
        /// <summary>
        /// 根据处方号获取处方打印信息
        /// </summary>
        /// <param name="m_objPrintcipal"></param>
        /// <param name="strRecipedeID"></param>
        /// <param name="obj_VO"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOutpatientRecipeDetail(System.Security.Principal.IPrincipal m_objPrintcipal, string strRecipedeID, out clsOutpatientPrintRecipe_VO obj_VO)
        {
            long lngRes = 0;
            DataTable m_objTempTable = new DataTable();
            clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
            IDataParameter[] ParamArr = null;
            obj_VO = null;
            string strSQL = @"select orderid_int, outpatrecipeid_chr, tableindex_int, orderque_int,
                               orderdicid_chr, orderdicname_vchr, spec_vchr, qty_dec, attachid_vchr,
                               sampleid_vchr, checkpartid_vchr, sbbasemny_dec, usageid_chr,
                               pricemny_dec, totalmny_dec, attachorderid_vchr, attachorderbasenum_dec
                          from t_opr_outpatient_orderdic a
                        where a.outpatrecipeid_chr=:1";
            try
            {
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = strRecipedeID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref m_objTempTable, ParamArr);

                if (lngRes > 0)
                {
                    if (m_objTempTable.Rows.Count <= 0)
                    {
                        strSQL = @"SELECT a.outpatrecipeid_chr, a.dosageunit_chr, a.rowno_chr, a.itemid_chr,
                                           a.unitid_chr, a.tolqty_dec AS qty_dec, a.unitprice_mny AS price_mny,
                                           a.tolprice_mny, a.medstoreid_chr, a.usageid_chr, a.days_int,
                                           a.freqid_chr, d.usagename_vchr, a.desc_vchr, b.itemopinvtype_chr,
                                           a.dosage_dec, a.itemspec_vchr, a.qty_dec AS dosageqty, a.itemname_vchr,
                                           b.itemcode_vchr, f.typename_vchr, e.freqname_chr, 0 times_int,
                                           0 min_qty_dec1, '' usagename_vchr, 0 min_qty_dec, '' sumusage_vchr,
                                           't_opr_outpatientpwmrecipede' AS fromtable,
                                           b.itemsrcid_vchr AS medicineid_chr, a.discount_dec,
                                           g.mednormalname_vchr, '' itemunit_vchr,
                                           g.medicinetypeid_chr
                                           FROM t_opr_outpatientpwmrecipede a,
                                           t_bse_chargeitem b,
                                           t_bse_chargeitemextype f,
                                           t_bse_usagetype d,
                                           t_aid_recipefreq e,
                                           t_bse_medicine g
                                           WHERE a.itemid_chr = b.itemid_chr
                                           AND a.deptmed_int = 0
                                           AND a.outpatrecipeid_chr = ?
                                           AND b.itemopinvtype_chr = f.typeid_chr
                                           AND f.flag_int = 2
                                           AND a.usageid_chr = d.usageid_chr(+)
                                           AND a.freqid_chr = e.freqid_chr(+)
                                           AND b.itemsrcid_vchr = g.medicineid_chr(+)
                                           UNION ALL
                                           SELECT a.outpatrecipeid_chr, b.dosageunit_chr, a.rowno_chr, a.itemid_chr,
                                           a.unitid_chr, (a.qty_dec * a.times_int) AS qty_dec,
                                           a.unitprice_mny AS price_mny, a.tolprice_mny, a.medstoreid_chr,
                                           '' usageid_chr, 0 AS days_int, '' freqid_chr, d.usagename_vchr,
                                           '' desc_vchr, b.itemopinvtype_chr, b.dosage_dec, a.itemspec_vchr,
                                           0 AS dosageqty, a.itemname_vchr, b.itemcode_vchr, f.typename_vchr,
                                           e.freqname_chr, a.times_int, a.min_qty_dec AS min_qty_dec1,
                                           '' usagename_vchr, a.min_qty_dec, a.sumusage_vchr,
                                           't_opr_outpatientcmrecipede' AS fromtable,
                                           b.itemsrcid_vchr AS medicineid_chr, a.discount_dec,
                                           g.mednormalname_vchr, '' itemunit_vchr,
                                           g.medicinetypeid_chr
                                           FROM t_opr_outpatientcmrecipede a,
                                           t_bse_chargeitem b,
                                           t_bse_chargeitemextype f,
                                           t_bse_usagetype d,
                                           t_aid_recipefreq e,
                                           t_bse_medicine g
                                           WHERE a.itemid_chr = b.itemid_chr
                                           AND a.deptmed_int = 0
                                           AND a.outpatrecipeid_chr = ? 
                                           AND a.itemid_chr = e.freqid_chr(+)
                                           AND b.itemopinvtype_chr = f.typeid_chr
                                           AND f.flag_int = 2
                                           AND a.usageid_chr = d.usageid_chr(+)
                                           AND b.itemsrcid_vchr = g.medicineid_chr(+)
                                           UNION ALL
                                           SELECT a.outpatrecipeid_chr, b.dosageunit_chr, a.rowno_chr, a.itemid_chr,
                                           a.unitid_chr, a.qty_dec AS qty_dec, a.unitprice_mny AS price_mny,
                                           a.tolprice_mny, a.medstoreid_chr, '' AS usageid_chr, 0 AS days_int,
                                           '' AS freqid_chr, '' AS usagename_vchr, '' AS desc_vchr,
                                           b.itemopinvtype_chr, 0 AS dosage_dec, a.itemspec_vchr,
                                           a.qty_dec AS dosageqty, a.itemname_vchr, b.itemcode_vchr,
                                           f.typename_vchr, '' freqname_chr, 0 times_int, 0 min_qty_dec1,
                                           '' usagename_vchr, 0 min_qty_dec, '' sumusage_vchr,
                                           't_opr_outpatientothrecipede' AS fromtable,
                                           b.itemsrcid_vchr AS medicineid_chr, b.dosage_dec AS discount_dec,
                                           g.mednormalname_vchr,a.itemunit_vchr,
                                           g.medicinetypeid_chr
                                           FROM t_opr_outpatientothrecipede a,
                                           t_bse_chargeitem b,
                                           t_bse_chargeitemextype f,
                                           t_bse_medicine g
                                           WHERE a.itemid_chr = b.itemid_chr
                                           AND a.deptmed_int = 0
                                           AND a.outpatrecipeid_chr = ? 
                                           AND b.itemopinvtype_chr = f.typeid_chr
                                           AND b.itemsrcid_vchr = g.medicineid_chr(+)
                                           UNION ALL
                                           SELECT a.outpatrecipeid_chr, b.dosageunit_chr, a.rowno_chr, a.itemid_chr,
                                           '' unitid_chr, a.qty_dec AS qty_dec, a.price_mny AS price_mny,
                                           a.tolprice_mny, a.medstoreid_chr, '' AS usageid_chr, 0 AS days_int,
                                           '' AS freqid_chr, '' AS usagename_vchr, '' AS desc_vchr,
                                           b.itemopinvtype_chr, 0 AS dosage_dec, a.itemspec_vchr,
                                           a.qty_dec AS dosageqty, a.itemname_vchr, b.itemcode_vchr,
                                           f.typename_vchr, '' freqname_chr, 0 times_int, 0 min_qty_dec1,
                                           '' usagename_vchr, 0 min_qty_dec, '' sumusage_vchr,
                                           'T_OPR_OUTPATIENTCHKRECIPEDE' AS fromtable,
                                           b.itemsrcid_vchr AS medicineid_chr, b.dosage_dec AS discount_dec,
                                           '' AS mednormalname_vchr,a.itemunit_vchr,
                                           '' medicinetypeid_chr
                                           FROM t_opr_outpatientchkrecipede a,
                                           t_bse_chargeitem b,
                                           t_bse_chargeitemextype f
                                           WHERE a.itemid_chr = b.itemid_chr
                                           AND a.outpatrecipeid_chr = ? 
                                           AND b.itemopinvtype_chr = f.typeid_chr
                                           UNION ALL
                                           SELECT a.outpatrecipeid_chr, b.dosageunit_chr, a.rowno_chr, a.itemid_chr,
                                           '' unitid_chr, a.qty_dec AS qty_dec, a.price_mny AS price_mny,
                                           a.tolprice_mny, a.medstoreid_chr, '' AS usageid_chr, 0 AS days_int,
                                           '' AS freqid_chr, '' AS usagename_vchr, '' AS desc_vchr,
                                           b.itemopinvtype_chr, 0 AS dosage_dec, a.itemspec_vchr,
                                           a.qty_dec AS dosageqty, a.itemname_vchr, b.itemcode_vchr,
                                           f.typename_vchr, '' freqname_chr, 0 times_int, 0 min_qty_dec1,
                                           '' usagename_vchr, 0 min_qty_dec, '' sumusage_vchr,
                                           'T_OPR_OUTPATIENTTESTRECIPEDE' AS fromtable,
                                           b.itemsrcid_vchr AS medicineid_chr, b.dosage_dec AS discount_dec,
                                           '' AS mednormalname_vchr, a.itemunit_vchr,
                                           '' medicinetypeid_chr
                                           FROM t_opr_outpatienttestrecipede a,
                                           t_bse_chargeitem b,
                                           t_bse_chargeitemextype f
                                           WHERE a.itemid_chr = b.itemid_chr
                                           AND a.outpatrecipeid_chr = ? 
                                           AND b.itemopinvtype_chr = f.typeid_chr
                                           UNION ALL
                                           SELECT a.outpatrecipeid_chr, b.dosageunit_chr, a.rowno_chr, a.itemid_chr,
                                           '' unitid_chr, a.qty_dec AS qty_dec, a.price_mny AS price_mny,
                                           a.tolprice_mny, a.medstoreid_chr, '' AS usageid_chr, 0 AS days_int,
                                           '' AS freqid_chr, '' AS usagename_vchr, '' AS desc_vchr,
                                           b.itemopinvtype_chr, 0 AS dosage_dec, a.itemspec_vchr,
                                           a.qty_dec AS dosageqty, a.itemname_vchr, b.itemcode_vchr,
                                           f.typename_vchr, '' freqname_chr, 0 times_int, 0 min_qty_dec1,
                                           '' usagename_vchr, 0 min_qty_dec, '' sumusage_vchr,
                                           'T_OPR_OUTPATIENTOPSRECIPEDE' AS fromtable,
                                           b.itemsrcid_vchr AS medicineid_chr, b.dosage_dec AS discount_dec,
                                           '' AS mednormalname_vchr, a.itemunit_vchr,
                                           '' medicinetypeid_chr
                                           FROM t_opr_outpatientopsrecipede a,
                                           t_bse_chargeitem b,
                                           t_bse_chargeitemextype f
                                           WHERE a.itemid_chr = b.itemid_chr
                                           AND a.outpatrecipeid_chr = ? 
                                           AND b.itemopinvtype_chr = f.typeid_chr";
                        try
                        {
                            DataTable dtbResult = new DataTable();
                            // clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                            ParamArr = null;
                            objHRPSvc.CreateDatabaseParameter(6, out ParamArr);
                            ParamArr[0].Value = strRecipedeID;
                            ParamArr[1].Value = strRecipedeID;
                            ParamArr[2].Value = strRecipedeID;
                            ParamArr[3].Value = strRecipedeID;
                            ParamArr[4].Value = strRecipedeID;
                            ParamArr[5].Value = strRecipedeID;

                            lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, ParamArr);

                            if (lngRes > 0 && dtbResult.Rows.Count > 0)
                            {
                                obj_VO = new clsOutpatientPrintRecipe_VO();

                                obj_VO.objinjectArr = new ArrayList();
                                obj_VO.objPRDArr = new ArrayList();
                                obj_VO.objPRDArr2 = new ArrayList();
                                decimal m_decWM = 0;
                                decimal m_decCM = 0;
                                decimal m_decOther = 0;
                                decimal m_decCheck = 0;
                                decimal m_decTest = 0;
                                decimal m_decOperation = 0;
                                for (int i = 0; i < dtbResult.Rows.Count; i++)
                                {
                                    clsOutpatientPrintRecipeDetail_VO objtemp = new clsOutpatientPrintRecipeDetail_VO();

                                    objtemp.m_strChargeName = dtbResult.Rows[i]["ITEMNAME_VCHR"].ToString().Trim();
                                    objtemp.m_strMEDNORMALNAME = dtbResult.Rows[i]["mednormalname_vchr"].ToString().Trim();
                                    objtemp.m_strCount = dtbResult.Rows[i]["QTY_DEC"].ToString().Trim() + dtbResult.Rows[i]["UNITID_CHR"].ToString().Trim();
                                    objtemp.m_strPrice = dtbResult.Rows[i]["PRICE_MNY"].ToString().Trim();
                                    objtemp.m_strSumPrice = dtbResult.Rows[i]["TOLPRICE_MNY"].ToString().Trim();
                                    objtemp.m_strUnit = dtbResult.Rows[i]["UNITID_CHR"].ToString().Trim();
                                    objtemp.m_strFrequency = dtbResult.Rows[i]["FREQNAME_CHR"].ToString().Trim();
                                    objtemp.m_strDosage = dtbResult.Rows[i]["DOSAGE_DEC"].ToString().Trim() + dtbResult.Rows[i]["DOSAGEUNIT_CHR"].ToString().Trim();
                                    objtemp.m_strDays = dtbResult.Rows[i]["DAYS_INT"].ToString().Trim();
                                    objtemp.m_strSpec = dtbResult.Rows[i]["ITEMSPEC_VCHR"].ToString().Trim();
                                    objtemp.m_strUsage = dtbResult.Rows[i]["USAGENAME_VCHR"].ToString().Trim();
                                    objtemp.m_strRowNo = dtbResult.Rows[i]["ROWNO_CHR"].ToString().Trim();
                                    objtemp.m_strUsageDetail = dtbResult.Rows[i]["DESC_VCHR"].ToString().Trim();
                                    objtemp.m_strInvoiceCat = dtbResult.Rows[i]["itemopinvtype_chr"].ToString().Trim();
                                    obj_VO.m_strHerbalmedicineUsage = "";
                                    if (dtbResult.Rows[i]["fromtable"].ToString().Trim() == "t_opr_outpatientpwmrecipede")
                                    {
                                        m_decWM += decimal.Parse(dtbResult.Rows[i]["tolprice_mny"].ToString().Trim());
                                        obj_VO.objPRDArr.Add(objtemp);
                                    }
                                    else if (dtbResult.Rows[i]["fromtable"].ToString().Trim() == "t_opr_outpatientcmrecipede")
                                    {
                                        obj_VO.m_strHerbalmedicineUsage = dtbResult.Rows[i]["SUMUSAGE_VCHR"].ToString().Trim();
                                        obj_VO.m_strTimes = dtbResult.Rows[i]["TIMES_INT"].ToString().Trim();
                                        m_decCM += decimal.Parse(dtbResult.Rows[i]["tolprice_mny"].ToString().Trim());
                                        obj_VO.objPRDArr2.Add(objtemp);
                                    }
                                    else
                                    {
                                        if (dtbResult.Rows[i]["TYPENAME_VCHR"].ToString().Trim() != "其它" && dtbResult.Rows[i]["TYPENAME_VCHR"].ToString().Trim() != "诊金")
                                        {
                                            objtemp.m_strCount = dtbResult.Rows[i]["QTY_DEC"].ToString().Trim() + dtbResult.Rows[i]["DOSAGEUNIT_CHR"].ToString().Trim();
                                            obj_VO.objinjectArr.Add(objtemp);
                                            if (dtbResult.Rows[i]["fromtable"].ToString().Trim() == "T_OPR_OUTPATIENTCHKRECIPEDE")
                                            {
                                                m_decCheck += decimal.Parse(dtbResult.Rows[i]["tolprice_mny"].ToString().Trim());
                                            }
                                            else if (dtbResult.Rows[i]["fromtable"].ToString().Trim() == "T_OPR_OUTPATIENTTESTRECIPEDE")
                                            {
                                                m_decTest += decimal.Parse(dtbResult.Rows[i]["tolprice_mny"].ToString().Trim());
                                            }
                                            else if (dtbResult.Rows[i]["fromtable"].ToString().Trim() == "T_OPR_OUTPATIENTOPSRECIPEDE")
                                            {
                                                m_decOperation += decimal.Parse(dtbResult.Rows[i]["tolprice_mny"].ToString().Trim());
                                            }
                                            else
                                            {
                                                m_decOther += decimal.Parse(dtbResult.Rows[i]["tolprice_mny"].ToString().Trim());
                                            }
                                        }
                                    }

                                }
                                obj_VO.m_strWMedicineCost = m_decWM.ToString("0.00");
                                obj_VO.m_strZCMedicineCost = m_decCM.ToString("0.00");
                                obj_VO.m_strCureCost = ((decimal)(m_decCheck + m_decTest + m_decOperation + m_decOther)).ToString("0.00");


                            }
                        }
                        catch (Exception objEx)
                        {
                            string strTmp = objEx.Message;
                            com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                            bool blnRes = objLogger.LogError(objEx);
                        }

                    }
                    else
                    {
                        strSQL = @"SELECT a.outpatrecipeid_chr, a.dosageunit_chr, a.rowno_chr, a.itemid_chr,
                                           a.unitid_chr, a.tolqty_dec AS qty_dec, a.unitprice_mny AS price_mny,
                                           a.tolprice_mny, a.medstoreid_chr, a.usageid_chr, a.days_int,
                                           a.freqid_chr, d.usagename_vchr, a.desc_vchr, b.itemopinvtype_chr,
                                           a.dosage_dec, a.itemspec_vchr, a.qty_dec AS dosageqty, a.itemname_vchr,
                                           b.itemcode_vchr, f.typename_vchr, e.freqname_chr, 0 times_int,
                                           0 min_qty_dec1, '' usagename_vchr, 0 min_qty_dec, '' sumusage_vchr,
                                           't_opr_outpatientpwmrecipede' AS fromtable,
                                           b.itemsrcid_vchr AS medicineid_chr, a.discount_dec,
                                           g.mednormalname_vchr, '' itemunit_vchr,
                                           g.medicinetypeid_chr
                                           FROM t_opr_outpatientpwmrecipede a,
                                           t_bse_chargeitem b,
                                           t_bse_chargeitemextype f,
                                           t_bse_usagetype d,
                                           t_aid_recipefreq e,
                                           t_bse_medicine g
                                           WHERE a.itemid_chr = b.itemid_chr
                                           AND a.deptmed_int = 0
                                           AND a.outpatrecipeid_chr = ?
                                           AND b.itemopinvtype_chr = f.typeid_chr
                                           AND f.flag_int = 2
                                           AND a.usageid_chr = d.usageid_chr(+)
                                           AND a.freqid_chr = e.freqid_chr(+)
                                           AND b.itemsrcid_vchr = g.medicineid_chr(+)
                                           UNION ALL
                                           SELECT a.outpatrecipeid_chr, b.dosageunit_chr, a.rowno_chr, a.itemid_chr,
                                           a.unitid_chr, (a.qty_dec * a.times_int) AS qty_dec,
                                           a.unitprice_mny AS price_mny, a.tolprice_mny, a.medstoreid_chr,
                                           '' usageid_chr, 0 AS days_int, '' freqid_chr, d.usagename_vchr,
                                           '' desc_vchr, b.itemopinvtype_chr, b.dosage_dec, a.itemspec_vchr,
                                           0 AS dosageqty, a.itemname_vchr, b.itemcode_vchr, f.typename_vchr,
                                           e.freqname_chr, a.times_int, a.min_qty_dec AS min_qty_dec1,
                                           '' usagename_vchr, a.min_qty_dec, a.sumusage_vchr,
                                           't_opr_outpatientcmrecipede' AS fromtable,
                                           b.itemsrcid_vchr AS medicineid_chr, a.discount_dec,
                                           g.mednormalname_vchr, '' itemunit_vchr,
                                           g.medicinetypeid_chr
                                           FROM t_opr_outpatientcmrecipede a,
                                           t_bse_chargeitem b,
                                           t_bse_chargeitemextype f,
                                           t_bse_usagetype d,
                                           t_aid_recipefreq e,
                                           t_bse_medicine g
                                           WHERE a.itemid_chr = b.itemid_chr
                                           AND a.deptmed_int = 0
                                           AND a.outpatrecipeid_chr = ? 
                                           AND a.itemid_chr = e.freqid_chr(+)
                                           AND b.itemopinvtype_chr = f.typeid_chr
                                           AND f.flag_int = 2
                                           AND a.usageid_chr = d.usageid_chr(+)
                                           AND b.itemsrcid_vchr = g.medicineid_chr(+)
                                           UNION ALL
                                           SELECT a.outpatrecipeid_chr, b.dosageunit_chr, a.rowno_chr, a.itemid_chr,
                                           a.unitid_chr, a.qty_dec AS qty_dec, a.unitprice_mny AS price_mny,
                                           a.tolprice_mny, a.medstoreid_chr, '' AS usageid_chr, 0 AS days_int,
                                           '' AS freqid_chr, '' AS usagename_vchr, '' AS desc_vchr,
                                           b.itemopinvtype_chr, 0 AS dosage_dec, a.itemspec_vchr,
                                           a.qty_dec AS dosageqty, a.itemname_vchr, b.itemcode_vchr,
                                           f.typename_vchr, '' freqname_chr, 0 times_int, 0 min_qty_dec1,
                                           '' usagename_vchr, 0 min_qty_dec, '' sumusage_vchr,
                                           't_opr_outpatientothrecipede' AS fromtable,
                                           b.itemsrcid_vchr AS medicineid_chr, b.dosage_dec AS discount_dec,
                                           g.mednormalname_vchr,a.itemunit_vchr,
                                           g.medicinetypeid_chr
                                           FROM t_opr_outpatientothrecipede a,
                                           t_bse_chargeitem b,
                                           t_bse_chargeitemextype f,
                                           t_bse_medicine g
                                           WHERE a.itemid_chr = b.itemid_chr
                                           AND a.deptmed_int = 0
                                           AND a.outpatrecipeid_chr = ? 
                                           AND b.itemopinvtype_chr = f.typeid_chr
                                           AND b.itemsrcid_vchr = g.medicineid_chr(+)";
                        try
                        {
                            DataTable dtbResult = new DataTable();
                            ParamArr = null;
                            objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                            ParamArr[0].Value = strRecipedeID;
                            ParamArr[1].Value = strRecipedeID;
                            ParamArr[2].Value = strRecipedeID;

                            lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, ParamArr);

                            if (lngRes > 0 && dtbResult.Rows.Count > 0)
                            {
                                obj_VO = new clsOutpatientPrintRecipe_VO();

                                obj_VO.objinjectArr = new ArrayList();
                                obj_VO.objPRDArr = new ArrayList();
                                obj_VO.objPRDArr2 = new ArrayList();
                                decimal m_decWM = 0;
                                decimal m_decCM = 0;
                                decimal m_decOther = 0;
                                decimal m_decCheck = 0;
                                decimal m_decTest = 0;
                                decimal m_decOperation = 0;
                                for (int i = 0; i < dtbResult.Rows.Count; i++)
                                {
                                    clsOutpatientPrintRecipeDetail_VO objtemp = new clsOutpatientPrintRecipeDetail_VO();

                                    objtemp.m_strChargeName = dtbResult.Rows[i]["ITEMNAME_VCHR"].ToString().Trim();
                                    objtemp.m_strMEDNORMALNAME = dtbResult.Rows[i]["mednormalname_vchr"].ToString().Trim();
                                    objtemp.m_strCount = dtbResult.Rows[i]["QTY_DEC"].ToString().Trim() + dtbResult.Rows[i]["UNITID_CHR"].ToString().Trim();
                                    objtemp.m_strPrice = dtbResult.Rows[i]["PRICE_MNY"].ToString().Trim();
                                    objtemp.m_strSumPrice = dtbResult.Rows[i]["TOLPRICE_MNY"].ToString().Trim();
                                    objtemp.m_strUnit = dtbResult.Rows[i]["UNITID_CHR"].ToString().Trim();
                                    objtemp.m_strFrequency = dtbResult.Rows[i]["FREQNAME_CHR"].ToString().Trim();
                                    objtemp.m_strDosage = dtbResult.Rows[i]["DOSAGE_DEC"].ToString().Trim() + dtbResult.Rows[i]["DOSAGEUNIT_CHR"].ToString().Trim();
                                    objtemp.m_strDays = dtbResult.Rows[i]["DAYS_INT"].ToString().Trim();
                                    objtemp.m_strSpec = dtbResult.Rows[i]["ITEMSPEC_VCHR"].ToString().Trim();
                                    objtemp.m_strUsage = dtbResult.Rows[i]["USAGENAME_VCHR"].ToString().Trim();
                                    objtemp.m_strRowNo = dtbResult.Rows[i]["ROWNO_CHR"].ToString().Trim();
                                    objtemp.m_strUsageDetail = dtbResult.Rows[i]["DESC_VCHR"].ToString().Trim();
                                    objtemp.m_strInvoiceCat = dtbResult.Rows[i]["itemopinvtype_chr"].ToString().Trim();
                                    obj_VO.m_strHerbalmedicineUsage = "";
                                    if (dtbResult.Rows[i]["fromtable"].ToString().Trim() == "t_opr_outpatientpwmrecipede")
                                    {
                                        m_decWM += decimal.Parse(dtbResult.Rows[i]["tolprice_mny"].ToString().Trim());
                                        obj_VO.objPRDArr.Add(objtemp);
                                    }
                                    else if (dtbResult.Rows[i]["fromtable"].ToString().Trim() == "t_opr_outpatientcmrecipede")
                                    {
                                        obj_VO.m_strHerbalmedicineUsage = dtbResult.Rows[i]["SUMUSAGE_VCHR"].ToString().Trim();
                                        obj_VO.m_strTimes = dtbResult.Rows[i]["TIMES_INT"].ToString().Trim();
                                        m_decCM += decimal.Parse(dtbResult.Rows[i]["tolprice_mny"].ToString().Trim());
                                        obj_VO.objPRDArr2.Add(objtemp);
                                    }
                                    else
                                    {
                                        if (dtbResult.Rows[i]["TYPENAME_VCHR"].ToString().Trim() != "其它" && dtbResult.Rows[i]["TYPENAME_VCHR"].ToString().Trim() != "诊金")
                                        {
                                            objtemp.m_strCount = dtbResult.Rows[i]["QTY_DEC"].ToString().Trim() + dtbResult.Rows[i]["DOSAGEUNIT_CHR"].ToString().Trim();
                                            obj_VO.objinjectArr.Add(objtemp);
                                            m_decOther += decimal.Parse(dtbResult.Rows[i]["tolprice_mny"].ToString().Trim());

                                        }
                                    }

                                }
                                for (int i = 0; i < m_objTempTable.Rows.Count; i++)
                                {
                                    clsOutpatientPrintRecipeDetail_VO objtemp = new clsOutpatientPrintRecipeDetail_VO();
                                    objtemp.m_strCount = m_objTempTable.Rows[i]["QTY_DEC"].ToString().Trim() + "次";
                                    objtemp.m_strPrice = m_objTempTable.Rows[i]["PRICEMNY_DEC"].ToString().Trim();
                                    objtemp.m_strSumPrice = m_objTempTable.Rows[i]["TOTALMNY_DEC"].ToString().Trim();
                                    objtemp.m_strChargeName = m_objTempTable.Rows[i]["ORDERDICNAME_VCHR"].ToString().Trim();
                                    obj_VO.objinjectArr.Add(objtemp);
                                    if (m_objTempTable.Rows[i]["TABLEINDEX_INT"].ToString().Trim() == "3")
                                    {
                                        m_decCheck += decimal.Parse(m_objTempTable.Rows[i]["TOTALMNY_DEC"].ToString().Trim());
                                    }
                                    else if (m_objTempTable.Rows[i]["TABLEINDEX_INT"].ToString().Trim() == "4")
                                    {
                                        m_decTest += decimal.Parse(m_objTempTable.Rows[i]["TOTALMNY_DEC"].ToString().Trim());
                                    }
                                    else if (m_objTempTable.Rows[i]["TABLEINDEX_INT"].ToString().Trim() == "5")
                                    {
                                        m_decOperation += decimal.Parse(m_objTempTable.Rows[i]["TOTALMNY_DEC"].ToString().Trim());
                                    }
                                }
                                obj_VO.m_strWMedicineCost = m_decWM.ToString("0.00");
                                obj_VO.m_strZCMedicineCost = m_decCM.ToString("0.00");
                                obj_VO.m_strCureCost = ((decimal)(m_decCheck + m_decTest + m_decOperation + m_decOther)).ToString("0.00");


                            }
                        }
                        catch (Exception objEx)
                        {
                            string strTmp = objEx.Message;
                            com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                            bool blnRes = objLogger.LogError(objEx);
                        }
                    }


                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            strSQL = @"select a.outpatrecipeid_chr, a.patientid_chr, a.createdate_dat,
                               a.registerid_chr, a.diagdr_chr, a.diagdept_chr, a.recordemp_chr,
                               a.recorddate_dat, a.pstauts_int, a.recipeflag_int,
                               a.outpatrecipeno_vchr, a.paytypeid_chr, a.casehisid_chr, a.groupid_chr,
                               a.type_int, a.confirm_int, a.confirmdesc_vchr, a.createtype_int,
                               a.deptmed_int, b.name_vchr, c.lastname_vchr, d.deptname_vchr,
                               b.birth_dat, e.lastname_vchr as recordemp, h.homeaddress_vchr,
                               h.sex_chr, h.idcard_chr, h.homephone_vchr, h.govcard_chr,
                               h.difficulty_vchr, h.insuranceid_vchr, k.paytypename_vchr, p.diag_vchr,
                               j.patientcardid_chr,
                               (select sum (totalsum_mny)
                                  from t_opr_outpatientrecipeinv
                                 where outpatrecipeid_chr = ? and totalsum_mny > 0) totailmoney
                          from t_opr_outpatientrecipe a,
                               t_bse_patientidx b,
                               t_bse_employee c,
                               t_bse_deptdesc d,
                               t_bse_employee e,
                               t_bse_patient h,
                               t_bse_patientpaytype k,
                               t_bse_patientcard j,
                               t_opr_outpatientcasehis p
                         where a.patientid_chr = b.patientid_chr(+)
                           and a.diagdr_chr = c.empid_chr(+)
                           and a.diagdept_chr = d.deptid_chr(+)
                           and a.recordemp_chr = e.empid_chr(+)
                           and a.patientid_chr = h.patientid_chr(+)
                           and a.paytypeid_chr = k.paytypeid_chr(+)
                           and a.patientid_chr = j.patientid_chr(+)
                           and a.casehisid_chr = p.casehisid_chr(+)
                           and a.outpatrecipeid_chr = ?";

            try
            {
                DataTable dtbResult = new DataTable();
                //clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = strRecipedeID;
                ParamArr[1].Value = strRecipedeID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, ParamArr);
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    DateTime dteBirth = Convert.ToDateTime("1900-1-1");
                    if (dtbResult.Rows[0]["BIRTH_DAT"] != System.DBNull.Value)
                        dteBirth = Convert.ToDateTime(dtbResult.Rows[0]["BIRTH_DAT"].ToString());

                    if (obj_VO == null)
                    {
                        obj_VO = new clsOutpatientPrintRecipe_VO();
                        obj_VO.objinjectArr = new ArrayList();
                        obj_VO.objPRDArr = new ArrayList();
                        obj_VO.objPRDArr2 = new ArrayList();
                    }
                    obj_VO.m_strAge = clsConvertDateTime.CalcAge(dteBirth);                    
                    obj_VO.m_strDiagDrName = dtbResult.Rows[0]["LASTNAME_VCHR"].ToString().Trim();
                    obj_VO.m_strHospitalName = "佛山第二人民医院";
                    obj_VO.m_strPatientName = dtbResult.Rows[0]["NAME_VCHR"].ToString().Trim();
                    obj_VO.m_strPhotoNo = dtbResult.Rows[0]["HOMEPHONE_VCHR"].ToString().Trim();
                    obj_VO.m_strCardID = dtbResult.Rows[0]["PATIENTCARDID_CHR"].ToString().Trim();
                    obj_VO.m_strdiagnose = dtbResult.Rows[0]["diag_vchr"].ToString().Trim();
                    obj_VO.m_strPatientType = dtbResult.Rows[0]["PAYTYPENAME_VCHR"].ToString().Trim();
                    obj_VO.m_strDiagDeptID = dtbResult.Rows[0]["DEPTNAME_VCHR"].ToString().Trim();
                    obj_VO.m_strRecipeID = strRecipedeID;
                    obj_VO.m_strRecordEmpID = dtbResult.Rows[0]["DIAGDR_CHR"].ToString().Trim().Substring(3);//员工ID
                    obj_VO.m_strIDcardno = dtbResult.Rows[0]["IDCARD_CHR"].ToString().Trim();
                    if (dtbResult.Rows[0]["RECORDDATE_DAT"] != System.DBNull.Value)
                        obj_VO.m_strPrintDate = DateTime.Parse(dtbResult.Rows[0]["RECORDDATE_DAT"].ToString()).ToString("yyyy-MM-dd");
                    else
                        obj_VO.m_strPrintDate = DateTime.Now.ToString("yyyy-MM-dd");
                    obj_VO.m_strSex = dtbResult.Rows[0]["SEX_CHR"].ToString().Trim();
                    obj_VO.m_strSelfPay = "";
                    obj_VO.m_strChargeUp = "";
                    obj_VO.m_strRecipePrice = "";

                    obj_VO.m_strHerbalmedicineUsage = "";
                    obj_VO.m_strAddress = dtbResult.Rows[0]["HOMEADDRESS_VCHR"].ToString().Trim();
                    if (dtbResult.Rows[0]["RECIPEFLAG_INT"].ToString().Trim() == "1")
                    {
                        obj_VO.m_strRecipeType = "正方";
                    }
                    else if (dtbResult.Rows[0]["RECIPEFLAG_INT"].ToString().Trim() == "2")
                    {
                        obj_VO.m_strRecipeType = "副方";
                    }
                    else
                    {
                        obj_VO.m_strRecipeType = "";
                    }
                    obj_VO.m_strGOVCARD = dtbResult.Rows[0]["GOVCARD_CHR"].ToString().Trim();
                    obj_VO.m_strINSURANCEID = dtbResult.Rows[0]["INSURANCEID_VCHR"].ToString().Trim();
                    obj_VO.m_strRegisterID = dtbResult.Rows[0]["REGISTERID_CHR"].ToString().Trim();
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 获取处方类型信息
        /// <summary>
        ///  获取处方类型信息
        /// </summary>
        /// <param name="m_Principal"></param>
        /// <param name="m_strRecipeID"></param>
        /// <param name="m_objRTVO"></param>
        /// <returns></returns>
        public long m_lngGetRecipeTypeInfo(System.Security.Principal.IPrincipal m_Principal, string m_strRecipeID, out clsRecipeType_VO m_objRTVO)
        {
            long lngRes = -1;
            DataTable m_objTable = new DataTable();
            m_objRTVO = null;
            string strSQL = @"select a.type_int, a.typename_vchr, a.r_int, a.g_int, a.b_int, a.remark_vchr,
                                     a.medproperty_vchr
                                from t_aid_recipetype a, t_opr_outpatientrecipe b
                               where a.type_int = b.type_int and b.outpatrecipeid_chr = ?";
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService m_objHRP = new clsHRPTableService();
            IDataParameter[] ParamArr = null;
            m_objHRP.CreateDatabaseParameter(1, out ParamArr);
            ParamArr[0].Value = m_strRecipeID;
            lngRes = m_objHRP.lngGetDataTableWithParameters(strSQL, ref m_objTable, ParamArr);
            m_objHRP.Dispose();
            if (lngRes > 0 && m_objTable.Rows.Count > 0)
            {
                m_objRTVO = new clsRecipeType_VO();
                m_objRTVO.B_INT = int.Parse(m_objTable.Rows[0]["b_int"].ToString().Trim());
                m_objRTVO.G_INT = int.Parse(m_objTable.Rows[0]["g_int"].ToString().Trim());
                m_objRTVO.R_INT = int.Parse(m_objTable.Rows[0]["r_int"].ToString().Trim());
                m_objRTVO.REMARK_VCHR = m_objTable.Rows[0]["remark_vchr"].ToString().Trim();
                m_objRTVO.TYPENAME_VCHR = m_objTable.Rows[0]["typename_vchr"].ToString().Trim();
                m_objRTVO.TYPE_INT = m_objTable.Rows[0]["type_int"].ToString().Trim();
            }
            return lngRes;
        }
        #endregion

        #region 获取检验收费项目临床意思
        /// <summary>
        /// 获取检验收费项目临床意思
        /// </summary>
        /// <param name="ItemID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetLisItemClinicMeaning(string ItemID, out DataTable dt)
        {
            long lngRes = 0;
            string SQL = @" select a.check_item_name_vchr, a.clinic_meaning_vchr 
                              from t_bse_lis_check_item a, 
                                   t_aid_lis_apply_unit_detail b, 
                                   t_bse_chargeitem c  
                             where a.check_item_id_chr = b.check_item_id_chr 
                               and b.apply_unit_id_chr = c.itemsrcid_vchr 
                               and c.itemid_chr like ?";
            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = ItemID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        #region 设置处方权
        /// <summary>
        /// 获取门诊开方医生列表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDoctorList(out DataTable dt)
        {
            long lngRes = 0;
            string SQL = @"select d.empno_chr, d.empid_chr, d.lastname_vchr, nvl(e.deptname_vchr, '[未定]') as deptname  
                                from t_sys_module a, 
                                     t_sys_rolemodulemap b, 
                                     t_sys_emprolemap c,
                                     t_bse_employee d,   
                                     (select ta.empid_chr, tb.deptname_vchr 
     	                                from t_bse_deptemp ta,
			                                 t_bse_deptdesc tb
		                                where ta.deptid_chr = tb.deptid_chr
		                                  and ta.default_dept_int = 1	 
	                                 ) e	
                                where a.moduleid_chr = b.moduleid_chr
                                  and b.roleid_chr = c.roleid_chr
                                  and c.empid_chr = d.empid_chr
                                  and d.empid_chr = e.empid_chr(+)  
                                  and lower(a.classname_vchr) = 'com.digitalwave.icare.gui.his.frmdoctorworkstation' 
                             order by e.deptname_vchr asc";
            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dt);
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
        /// 保存医生权限定义表
        /// </summary>
        /// <param name="objArr"></param>
        /// <param name="Flag">1 新加 2 删除</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngSaveDoctorRecipePurview(ArrayList objArr, int Flag)
        {
            string SQL = "";
            long lngRes = 0, lngAffects = 0;

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                for (int i = 0; i < objArr.Count; i++)
                {
                    clsOutRecipePurview_VO RecipePurview_VO = objArr[i] as clsOutRecipePurview_VO;

                    string empid = RecipePurview_VO.EmpID;

                    ArrayList purarr = RecipePurview_VO.PurviewArr;

                    for (int j = 0; j < purarr.Count; j++)
                    {
                        string purviewid = purarr[j].ToString();

                        if (Flag == 1)
                        {
                            SQL = "delete from t_opr_defrecipetabpage where empid_chr = ? and purview_chr = ?";

                            objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                            ParamArr[0].Value = empid;
                            ParamArr[1].Value = purviewid;

                            lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                            SQL = "insert into t_opr_defrecipetabpage (empid_chr, purview_chr) values (?, ?)";

                            objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                            ParamArr[0].Value = empid;
                            ParamArr[1].Value = purviewid;

                            lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                        }
                        else if (Flag == 2)
                        {
                            SQL = "delete from t_opr_defrecipetabpage where empid_chr = ? and purview_chr = ?";

                            objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                            ParamArr[0].Value = empid;
                            ParamArr[1].Value = purviewid;

                            lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                        }
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

        /// <summary>
        /// 获取医生权限定义表
        /// </summary>
        /// <param name="DoctID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDoctorRecipePurview(string DoctID, out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();

            string SQL = @"select a.* 
                             from t_opr_defrecipetabpage a                                     
                            where a.empid_chr = ?";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = DoctID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        #region 查找处方-诊疗项目
        /// <summary>
        /// 查找处方-诊疗项目
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="OrderCatArr"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFindRecipeOrderByID(string ID, ArrayList OrderCatArr, out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();

            string SubStr = "";

            if (OrderCatArr != null && OrderCatArr.Count > 0)
            {
                string str = "";

                for (int i = 0; i < OrderCatArr.Count; i++)
                {
                    str += "b.ordercateid_chr = '" + OrderCatArr[i].ToString() + "' or ";
                }

                str = str.Trim();
                SubStr = " and (" + str.Substring(0, str.Length - 2) + ")";
            }

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                string strSQL = @" select  a.orderdicid_chr, a.name_chr, a.des_vchr, a.usercode_chr, a.wbcode_chr,
                                           a.pycode_chr, a.execdept_chr, a.ordercateid_chr, a.itemid_chr,
                                           a.nullitemdosageunit_chr, a.nullitemuseunit_chr,
                                           a.nullitemdosetypeid_chr, a.status_int, a.sampleid_vchr, a.partid_vchr,
                                           a.engname_vchr, a.commname_vchr, a.nullitemfreqid_vchr,
                                           a.nullitemuse_dec, a.lisapplyunitid_chr, a.applytypeid_chr,
                                           a.newchargetype_int, 
                                           a.sampleid_vchr as sample_type_id_chr, d.sample_type_desc_vchr, e.totalmny, f.partname, g.usageid_chr,
                                           h.itemspec_vchr, h.itemopinvtype_chr, h.ybtypename, h.itemunit         
                                      from t_bse_bih_orderdic a,
                                           t_aid_bih_ordercate b,       
                                           t_aid_lis_apply_unit c,
                                           t_aid_lis_sampletype d,
                                           (
	   	                                    select a.orderdicid_chr, sum(round(b.qty_int * c.itemprice_mny,2)) as totalmny
		   	                                  from t_bse_bih_orderdic a,
       		                                       t_aid_bih_orderdic_charge b,
       		                                       (select itemid_chr, itemprice_mny from t_bse_chargeitem where ifstop_int = 0) c
       	                                     where a.orderdicid_chr = b.orderdicid_chr
		                                       and b.itemid_chr = c.itemid_chr(+)		                                      
	                                        group by a.orderdicid_chr	   
	                                       ) e,
                                           ar_apply_partlist f,
                                           t_bse_chargeitem g,
                                           (
                                            select a.orderdicid_chr, c.itemspec_vchr, c.itemopinvtype_chr, c.typename_vchr as ybtypename, (case c.ipchargeflg_int when 1 then c.itemipunit_chr else c.itemunit_chr end) as itemunit 
                                            from t_bse_bih_orderdic a,
                                                 ( select a.itemid_chr, a.itemspec_vchr, a.itemopinvtype_chr, b.typename_vchr, a.ipchargeflg_int, a.itemipunit_chr, a.itemunit_chr  
                                                     from t_bse_chargeitem a,
                                                          t_aid_medicaretype b    
                                                    where a.inpinsurancetype_vchr = b.typeid_chr(+)  
                                                      and a.ifstop_int = 0      
                                                 ) c 
                                            where a.itemid_chr = c.itemid_chr(+)                                                                                              
                                           ) h   
                                     where a.ordercateid_chr = b.ordercateid_chr                                         
                                       and a.applytypeid_chr = c.apply_unit_id_chr(+) 
                                       and a.sampleid_vchr = d.sample_type_id_chr(+) 
                                       and a.orderdicid_chr = e.orderdicid_chr 
                                       and a.orderdicid_chr = h.orderdicid_chr 
                                       and a.partid_vchr = f.partid(+) 
                                       and a.itemid_chr = g.itemid_chr(+)  
                                       and a.status_int = 1 " + SubStr + @"                                        
                                       and ((lower(a.pycode_chr) like ?) or (lower(a.wbcode_chr) like ?)
                                            or ((lower(a.usercode_chr) like ?)) or (lower(a.name_chr || a.commname_vchr) like ?)) 
                                 order by a.name_chr ";

                objHRPSvc.CreateDatabaseParameter(4, out ParamArr);
                ParamArr[0].Value = ID.ToLower() + "%";
                ParamArr[1].Value = ID.ToLower() + "%";
                ParamArr[2].Value = ID.ToLower() + "%";
                ParamArr[3].Value = "%" + ID.ToLower() + "%";

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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

        /// <summary>
        /// 查找处方-诊疗项目
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFindRecipeOrderByID(string ID, out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                string strSQL = @"select a.orderdicid_chr, a.name_chr, a.des_vchr, a.usercode_chr,
                                         a.wbcode_chr, a.pycode_chr, a.execdept_chr, a.ordercateid_chr,
                                         a.itemid_chr, a.nullitemdosageunit_chr, a.nullitemuseunit_chr,
                                         a.nullitemdosetypeid_chr, a.status_int, a.sampleid_vchr,
                                         a.partid_vchr, a.engname_vchr, a.commname_vchr,
                                         a.nullitemfreqid_vchr, a.nullitemuse_dec, a.lisapplyunitid_chr,
                                         a.applytypeid_chr, a.newchargetype_int,
                                         a.sampleid_vchr as sample_type_id_chr, d.sample_type_desc_vchr,
                                         e.totalmny, f.partname, g.usageid_chr
                                    from t_bse_bih_orderdic a,
                                         t_aid_bih_ordercate b,
                                         t_aid_lis_apply_unit c,
                                         t_aid_lis_sampletype d,
                                         (select   a.orderdicid_chr,
                                                   sum (round (b.qty_int * c.itemprice_mny, 2)) as totalmny
                                              from t_bse_bih_orderdic a,
                                                   t_aid_bih_orderdic_charge b,
                                                   t_bse_chargeitem c
                                             where a.orderdicid_chr = b.orderdicid_chr
                                               and b.itemid_chr = c.itemid_chr
                                               and c.ifstop_int = 0
                                          group by a.orderdicid_chr) e,
                                         ar_apply_partlist f,
                                         t_bse_chargeitem g
                                   where a.ordercateid_chr = b.ordercateid_chr
                                     and a.applytypeid_chr = c.apply_unit_id_chr(+)
                                     and a.sampleid_vchr = d.sample_type_id_chr(+)
                                     and a.orderdicid_chr = e.orderdicid_chr
                                     and a.partid_vchr = f.partid(+)
                                     and a.itemid_chr = g.itemid_chr(+)
                                     and a.status_int = 1
                                     and a.orderdicid_chr = ?
                                order by a.name_chr";

                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = ID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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

        #region 根据诊疗项目获取收费项目
        /// <summary>
        /// 根据诊疗项目获取收费项目
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="PayTypeID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetChargeItemByOrderID(string OrderID, string PayTypeID, out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                string strSQL = @" select c.*, c.itemname_vchr as itemname, b.qty_int as totalqty_dec, b.usescope_int, d.precent_dec
                                      from t_bse_bih_orderdic a,
                                           t_aid_bih_orderdic_charge b,
                                           t_bse_chargeitem c,                                         
                                           (select itemid_chr, precent_dec from t_aid_inschargeitem where copayid_chr = ?) d
                                     where a.orderdicid_chr = b.orderdicid_chr 
                                       and b.itemid_chr = c.itemid_chr                                        
                                       and c.itemid_chr = d.itemid_chr(+) 
                                       and a.status_int = 1      
                                       and c.ifstop_int = 0                                     
                                       and a.orderdicid_chr = ? 
                                  order by c.itemname_vchr ";

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = PayTypeID;
                ParamArr[1].Value = OrderID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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

        #region 获取系统功能配置
        /// <summary>
        /// 获取系统功能配置
        /// </summary>
        /// <param name="objPri"></param>
        /// <param name="strID"></param>
        /// <param name="m_strStatus"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetSystemSetting(System.Security.Principal.IPrincipal objPri, string strID, ref string m_strStatus)
        {
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            long lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc", "m_lngGetSystemSetting");
            if (lngRes < 0)
                return lngRes;
            DataTable m_objTable = new DataTable();
            string strSQL = @"select a.setstatus_int from t_sys_setting  a where a.setid_chr='" + m_strStatus + "'";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();
                lngRes = HRPSvc.lngGetDataTableWithoutParameters(strSQL, ref m_objTable);
                if (lngRes > 0 && m_objTable.Rows.Count > 0)
                {
                    m_strStatus = m_objTable.Rows[0]["setstatus_int"].ToString();
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                lngRes = -2;
            }
            return lngRes;
        }
        #endregion

        #region 判断诊疗项目(组合)是否允许打折
        /// <summary>
        /// 判断诊疗项目(组合)是否允许打折
        /// </summary>
        /// <param name="OrderID">诊疗项目ID</param>
        /// <param name="InvoCatArr">发票类型数组</param>
        /// <param name="SysType">系统 1 门诊 2 住院</param>
        /// <param name="ItemNums">项目个数</param>
        /// <returns></returns>
        [AutoComplete]
        public bool m_blnCheckOrderDiscount(string OrderID, ArrayList InvoCatArr, int SysType, int ItemNums)
        {
            long lngRes = 0;
            bool blnRet = false;
            DataTable dt = new DataTable();

            string SubStr = "";

            if (InvoCatArr != null && InvoCatArr.Count > 0)
            {
                string str = "";

                for (int i = 0; i < InvoCatArr.Count; i++)
                {
                    if (SysType == 1)
                    {
                        str += "c.itemopinvtype_chr = '" + InvoCatArr[i].ToString() + "' or ";
                    }
                    else if (SysType == 2)
                    {
                        str += "c.itemipinvtype_chr = '" + InvoCatArr[i].ToString() + "' or ";
                    }
                }

                str = str.Trim();
                SubStr = " and (" + str.Substring(0, str.Length - 2) + ")";
            }

            if (SysType == 1)
            {
                SubStr += " group by c.itemopinvtype_chr ";
            }
            else if (SysType == 2)
            {
                SubStr += " group by c.itemipinvtype_chr ";
            }

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                string strSQL = @"select count(b.itemid_chr)
                                    from t_bse_bih_orderdic a,
                                         t_aid_bih_orderdic_charge b,
                                         t_bse_chargeitem c
                                    where a.orderdicid_chr = b.orderdicid_chr 
                                      and b.itemid_chr = c.itemid_chr 
                                      and a.status_int = 1    
                                      and a.orderdicid_chr = ? " + SubStr + @"                                     
                                    having count(b.itemid_chr) > ?";

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = OrderID;
                ParamArr[1].Value = ItemNums;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
                objHRPSvc.Dispose();

                if (lngRes > 0 && dt.Rows.Count > 0)
                {
                    int count = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i][0].ToString() != "0")
                        {
                            count += int.Parse(dt.Rows[i][0].ToString());
                        }
                    }
                    if (count > 0)
                    {
                        blnRet = true;
                    }
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return blnRet;
        }
        #endregion

        #region 查找协定处方
        /// <summary>
        /// 查找协定处方
        /// </summary>
        /// <param name="CreateEmpID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFindAccordRecipe(string CreateEmpID, out DataTable dt)
        {
            long lngRes = 0;

            string SQL = @"select  a.recipeid_chr, a.recipename_chr, a.usercode_chr, a.pycode_chr,
                                   a.wbcode_chr, a.diseasename_vchr, a.privilege_int, a.status_int
                              from t_aid_concertrecipe a
                             where a.privilege_int = 0                              
                               and a.flag_int = 0
                            union all
                            select a.recipeid_chr, a.recipename_chr, a.usercode_chr, a.pycode_chr,
                                   a.wbcode_chr, a.diseasename_vchr, a.privilege_int, a.status_int
                              from t_aid_concertrecipe a
                             where a.privilege_int = 1
                               and a.createrid_chr = ?                            
                               and a.flag_int = 0
                            union all
                            select a.recipeid_chr, a.recipename_chr, a.usercode_chr, a.pycode_chr,
                                   a.wbcode_chr, a.diseasename_vchr, a.privilege_int, a.status_int
                              from t_aid_concertrecipe a,
                                   (select a.recipeid_chr
                                      from t_aid_concertrecipedept a
                                     where exists (select 1
                                                     from t_bse_deptemp b
                                                    where a.deptid_chr = b.deptid_chr and b.empid_chr = ?)) b
                             where a.recipeid_chr = b.recipeid_chr
                               and a.privilege_int = 2                              
                               and a.flag_int = 0";

            dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = CreateEmpID;
                ParamArr[1].Value = CreateEmpID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        #region 综合查询收费项目
        /// <summary>
        /// 综合查询收费项目
        /// </summary>
        /// <param name="QueryColname">查询列名</param>
        /// <param name="FindStr"></param>
        /// <param name="Type">1 西药 2 中药 3 检验 4 检查 5 治疗 6 其他</param>
        /// <param name="UseAliasTable">是否使用别名表查询</param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngFindChargeItem(string QueryColname, string FindStr, int Type, bool UseAliasTable, out DataTable dt)
        {
            long lngRes = 0;
            string SQL = "";
            dt = new DataTable();           

            if (Type == 1)
            {
                if (UseAliasTable)
                {
                    SQL = @"select   a.itemid_chr, a.itemname_vchr, a.itemspec_vchr, a.itemengname_vchr,
                                 a.itemopunit_chr, a.itemipunit_chr, b.deptprep_int, a.dosageunit_chr,
                                 a.packqty_dec, round (a.itemprice_mny / a.packqty_dec, 4) as submoney,
                                 a.itemprice_mny, a.itempycode_chr as type, b.noqtyflag_int,
                                 b.mindosage_dec, b.maxdosage_dec, b.adultdosage_dec,
                                 b.childdosage_dec, b.nmldosage_dec, b.hype_int, a.opchargeflg_int,
                                 a.usageid_chr, a.itemcommname_vchr, b.ispoison_chr,
                                 b.isanaesthesia_chr, b.ischlorpromazine_chr, b.ischlorpromazine2_chr,
                                 a.itemopinvtype_chr, c.usagename_vchr, a.dosage_dec, a.itemcode_vchr,
                                 100 as precent_dec, g.partname, h.freqid_chr as freqid,
                                 h.freqname_chr as freqname, h.times_int as freqtimes,
                                 h.days_int as freqdays, y.typename_vchr as ybtypename
                            from t_bse_chargeitem a,
                                 t_bse_medicine b,
                                 t_bse_usagetype c,
                                 t_bse_chargecatmap d,
                                 ar_apply_partlist g,
                                 t_aid_recipefreq h,
                                 t_aid_medicaretype y
                           where a.itemsrcid_vchr = b.medicineid_chr(+)                            
                             and a.ifstop_int = 0
                             and a.insurancetype_vchr = y.typeid_chr(+)
                             and a.usageid_chr = c.usageid_chr(+)
                             and a.itemopinvtype_chr = d.catid_chr(+)
                             and d.groupid_chr = '0001'
                             and d.internalflag_int = 0
                             and a.itemchecktype_chr = g.partid(+)
                             and a.freqid_chr = h.freqid_chr(+)
                             and exists (
                                           select 1
                                             from t_bse_itemalias_drug drug
                                            where a.itemid_chr = drug.itemid_chr
                                              and drug." + QueryColname + @" like ?)
                        order by a.itempycode_chr";
                }
                else
                {
                    SQL = @"select   a.itemid_chr, a.itemname_vchr, a.itemspec_vchr, a.itemengname_vchr,
                                 a.itemopunit_chr, a.itemipunit_chr, b.deptprep_int, a.dosageunit_chr,
                                 a.packqty_dec, round (a.itemprice_mny / a.packqty_dec, 4) as submoney,
                                 a.itemprice_mny, a.itempycode_chr as type, b.noqtyflag_int,
                                 b.mindosage_dec, b.maxdosage_dec, b.adultdosage_dec,
                                 b.childdosage_dec, b.nmldosage_dec, b.hype_int, a.opchargeflg_int,
                                 a.usageid_chr, a.itemcommname_vchr, b.ispoison_chr,
                                 b.isanaesthesia_chr, b.ischlorpromazine_chr, b.ischlorpromazine2_chr,
                                 a.itemopinvtype_chr, c.usagename_vchr, a.dosage_dec, a.itemcode_vchr,
                                 100 as precent_dec, g.partname, h.freqid_chr as freqid,
                                 h.freqname_chr as freqname, h.times_int as freqtimes,
                                 h.days_int as freqdays, y.typename_vchr as ybtypename
                            from t_bse_chargeitem a,
                                 t_bse_medicine b,
                                 t_bse_usagetype c,
                                 t_bse_chargecatmap d,
                                 ar_apply_partlist g,
                                 t_aid_recipefreq h,
                                 t_aid_medicaretype y
                           where a.itemsrcid_vchr = b.medicineid_chr(+)                            
                             and a.ifstop_int = 0
                             and a.insurancetype_vchr = y.typeid_chr(+)
                             and a.usageid_chr = c.usageid_chr(+)
                             and a.itemopinvtype_chr = d.catid_chr(+)
                             and d.groupid_chr = '0001'
                             and d.internalflag_int = 0
                             and a.itemchecktype_chr = g.partid(+)
                             and a.freqid_chr = h.freqid_chr(+)
                             and a." + QueryColname + @" like ?                             
                        order by a.itempycode_chr";
                }
            }
            else if (Type == 2)
            {
                if (UseAliasTable)
                {
                    SQL = @"select   a.itemid_chr, a.itemname_vchr, a.itemspec_vchr, a.itemengname_vchr,
                                 b.deptprep_int, a.usageid_chr, c.usagename_vchr, a.dosageunit_chr,
                                 a.itemprice_mny, a.itempycode_chr as type,
                                 round (a.itemprice_mny / a.packqty_dec, 4) as submoney, b.noqtyflag_int,
                                 b.mindosage_dec, a.itemopinvtype_chr, b.maxdosage_dec,
                                 b.adultdosage_dec, b.childdosage_dec, a.itemcommname_vchr,
                                 b.ispoison_chr, b.isanaesthesia_chr, b.ischlorpromazine_chr,
                                 b.ischlorpromazine2_chr, b.nmldosage_dec, a.itemipunit_chr,
                                 a.opchargeflg_int, a.packqty_dec, a.dosage_dec, a.itemcode_vchr,
                                 100 as precent_dec, y.typename_vchr as ybtypename
                            from t_bse_chargeitem a,
                                 t_bse_medicine b,
                                 t_bse_usagetype c,
                                 t_bse_chargecatmap d,
                                 t_aid_medicaretype y
                           where a.itemsrcid_vchr = b.medicineid_chr(+)
                             and a.usageid_chr = c.usageid_chr(+)
                             and a.ifstop_int = 0
                             and a.itemopinvtype_chr = d.catid_chr(+)
                             and a.insurancetype_vchr = y.typeid_chr(+)
                             and d.groupid_chr = '0002'
                             and d.internalflag_int = 0
                             and exists (
                                           select 1
                                             from t_bse_itemalias_drug drug
                                            where a.itemid_chr = drug.itemid_chr
                                              and drug." + QueryColname + @" like ?)
                        order by a.itempycode_chr";
                }
                else
                {
                    SQL = @"select   a.itemid_chr, a.itemname_vchr, a.itemspec_vchr, a.itemengname_vchr,
                                 b.deptprep_int, a.usageid_chr, c.usagename_vchr, a.dosageunit_chr,
                                 a.itemprice_mny, a.itempycode_chr as type,
                                 round (a.itemprice_mny / a.packqty_dec, 4) as submoney, b.noqtyflag_int,
                                 b.mindosage_dec, a.itemopinvtype_chr, b.maxdosage_dec,
                                 b.adultdosage_dec, b.childdosage_dec, a.itemcommname_vchr,
                                 b.ispoison_chr, b.isanaesthesia_chr, b.ischlorpromazine_chr,
                                 b.ischlorpromazine2_chr, b.nmldosage_dec, a.itemipunit_chr,
                                 a.opchargeflg_int, a.packqty_dec, a.dosage_dec, a.itemcode_vchr,
                                 100 as precent_dec, y.typename_vchr as ybtypename
                            from t_bse_chargeitem a,
                                 t_bse_medicine b,
                                 t_bse_usagetype c,
                                 t_bse_chargecatmap d,
                                 t_aid_medicaretype y
                           where a.itemsrcid_vchr = b.medicineid_chr(+)
                             and a.usageid_chr = c.usageid_chr(+)
                             and a.ifstop_int = 0
                             and a.itemopinvtype_chr = d.catid_chr(+)
                             and a.insurancetype_vchr = y.typeid_chr(+)
                             and d.groupid_chr = '0002'
                             and d.internalflag_int = 0
                             and a." + QueryColname + @" like ?    
                        order by a.itempycode_chr";
                }
            }
            else if (Type == 3)
            {

            }
            else if (Type == 4)
            {

            }
            else if (Type == 5)
            {

            }
            else if (Type == 6)
            {
                SQL = @"select   a.itemid_chr, a.itemname_vchr, a.itemspec_vchr, a.itemopinvtype_chr,
                                 a.itemcode_vchr, 100 as precent_dec, a.itemcommname_vchr,
                                 b.deptprep_int, y.typename_vchr as ybtypename,
                                 a.itemunit_chr as itemopunit_chr, a.itemprice_mny, a.selfdefine_int,
                                 a.itempycode_chr as type, a.itemengname_vchr
                            from t_bse_chargeitem a,
                                 t_bse_medicine b,
                                 t_bse_chargecatmap d,
                                 t_aid_medicaretype y
                           where a.itemsrcid_vchr = b.medicineid_chr(+)
                             and a.ifstop_int = 0
                             and a.itemopinvtype_chr = d.catid_chr(+)
                             and d.groupid_chr = '0005'
                             and d.internalflag_int = 0
                             and a.insurancetype_vchr = y.typeid_chr(+)
                             and a." + QueryColname + @" like ? 
                        order by a.itempycode_chr";
            }

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = FindStr.Trim().ToUpper() + "%";
               
                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        #region 保存协定处方
        /// <summary>
        /// 保存协定处方
        /// </summary>
        /// <param name="AccordRecipe_VO"></param>
        /// <param name="objRecEntryArr"></param>
        /// <param name="RecipeID"></param>
        [AutoComplete]
        public long m_lngSaveAccordRecipe(clsAccordRecipe_VO AccordRecipe_VO, ArrayList objRecEntryArr, out string RecipeID)
        {
            long lngRes = 0, lngAffects = 0;
            string SQL = "";

            RecipeID = AccordRecipe_VO.RecipeID;

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                if (RecipeID.Trim() != "")
                {
                    this.m_lngDelAccordRecipe(RecipeID);
                }
                else
                {
                    DataTable dt = new DataTable();

                    //取序列ID
                    SQL = "select lpad(seq_accordrecipeid.nextval, 10, '0') from dual";
                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dt);
                    if (lngRes > 0)
                    {
                        RecipeID = dt.Rows[0][0].ToString();
                    }
                    else
                    {
                        return 0;
                    }
                }

                SQL = @"insert into t_aid_concertrecipe (recipeid_chr, recipename_chr, privilege_int, usercode_chr, wbcode_chr, 
                                                         pycode_chr, status_int, createrid_chr, flag_int, diseasename_vchr)
                                                 values (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

                objHRPSvc.CreateDatabaseParameter(10, out ParamArr);
                ParamArr[0].Value = RecipeID;
                ParamArr[1].Value = AccordRecipe_VO.RecipeName;
                ParamArr[2].Value = AccordRecipe_VO.Privilege;
                ParamArr[3].Value = AccordRecipe_VO.UserCode;
                ParamArr[4].Value = AccordRecipe_VO.WbCode;
                ParamArr[5].Value = AccordRecipe_VO.PyCode;
                ParamArr[6].Value = AccordRecipe_VO.Status;
                ParamArr[7].Value = AccordRecipe_VO.CreaterID;
                ParamArr[8].Value = AccordRecipe_VO.Flag;
                ParamArr[9].Value = AccordRecipe_VO.DiseaseName;

                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                for (int i = 0; i < objRecEntryArr.Count; i++)
                {

                    SQL = @"insert into t_aid_concertrecipe_plus (recipeid_chr, plusid_chr, itemid_chr, recno_chr, qty_dec, days_int, freqid_chr, 
                                                                  usageid_vchr, sampleid_chr, partid_int, type_int, class_int, rowno_int)
                                                          values (?, lpad(seq_accordrecipeplusid.nextval, 10, '0'), ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

                    clsAccordRecipePlus_VO AccordRecipePlus_VO = objRecEntryArr[i] as clsAccordRecipePlus_VO;

                    objHRPSvc.CreateDatabaseParameter(12, out ParamArr);
                    ParamArr[0].Value = RecipeID;
                    ParamArr[1].Value = AccordRecipePlus_VO.ItemID;
                    ParamArr[2].Value = AccordRecipePlus_VO.RecNO;
                    ParamArr[3].Value = AccordRecipePlus_VO.Qty;
                    ParamArr[4].Value = AccordRecipePlus_VO.Days;
                    ParamArr[5].Value = AccordRecipePlus_VO.FreqID;
                    ParamArr[6].Value = AccordRecipePlus_VO.UsageID;
                    ParamArr[7].Value = AccordRecipePlus_VO.SampleID;
                    ParamArr[8].Value = AccordRecipePlus_VO.PartID;
                    ParamArr[9].Value = AccordRecipePlus_VO.Type;
                    ParamArr[10].Value = AccordRecipePlus_VO.Class;
                    ParamArr[11].Value = AccordRecipePlus_VO.RowNO;

                    lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
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

        #region 查询协定处方
        /// <summary>
        /// 查询协定处方
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <param name="ClassID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAccordRecipe(string RecipeID, int ClassID, out DataTable dt)
        {
            long lngRes = 0;
            string SQL = "";
            dt = new DataTable();

            if (ClassID == 1)
            {
                SQL = @"select   a.itemid_chr, a.itemname_vchr, a.itemspec_vchr, a.itemengname_vchr,
                                 a.itemopunit_chr, a.itemipunit_chr, b.deptprep_int, a.dosageunit_chr,
                                 a.packqty_dec, round (a.itemprice_mny / a.packqty_dec,
                                                       4) as submoney, a.itemprice_mny, a.itemcode_vchr, 
                                 a.itempycode_chr as type, b.noqtyflag_int, b.mindosage_dec,
                                 b.maxdosage_dec, b.adultdosage_dec, b.childdosage_dec,
                                 b.nmldosage_dec, b.hype_int, a.opchargeflg_int, 
                                 a.itemcommname_vchr, b.ispoison_chr, a.ifstop_int, b.isanaesthesia_chr,
                                 b.ischlorpromazine_chr, b.ischlorpromazine2_chr, a.itemopinvtype_chr,
                                 c.usagename_vchr, a.dosage_dec, a.itemcode_vchr, 100 as precent_dec,
                                 h.freqname_chr as freqname, h.times_int as freqtimes, h.days_int as freqdays,
                                 y.typename_vchr as ybtypename, tp.recno_chr as recno, tp.qty_dec as recqty, 
                                 tp.days_int as recdays, tp.usageid_vchr as usageid_chr, tp.freqid_chr as freqid,
                                 tp.class_int as recclass 
                            from t_bse_chargeitem a,
                                 t_bse_medicine b,
                                 t_bse_usagetype c,
                                 t_aid_recipefreq h,
                                 t_aid_medicaretype y,
                                 t_aid_concertrecipe_plus tp
                           where a.itemsrcid_vchr = b.medicineid_chr(+)                            
                             and a.insurancetype_vchr = y.typeid_chr(+)
                             and tp.itemid_chr = a.itemid_chr
                             and tp.usageid_vchr = c.usageid_chr(+)
                             and tp.freqid_chr = h.freqid_chr(+)
                             and tp.type_int = 0
                             and tp.class_int = 1
                             and tp.recipeid_chr = ?
                        order by tp.rowno_int";
            }
            else if (ClassID == 2)
            {
                SQL = @"select   a.itemid_chr, a.itemname_vchr, a.itemspec_vchr, a.itemengname_vchr,
                                 b.deptprep_int,  c.usagename_vchr, a.dosageunit_chr, a.itemcode_vchr, 
                                 a.itemprice_mny, a.itempycode_chr as type, a.ifstop_int,
                                 round (a.itemprice_mny / a.packqty_dec, 4) as submoney,
                                 b.noqtyflag_int, b.mindosage_dec, a.itemopinvtype_chr,
                                 b.maxdosage_dec, b.adultdosage_dec, b.childdosage_dec,
                                 a.itemcommname_vchr, b.ispoison_chr, b.isanaesthesia_chr,
                                 b.ischlorpromazine_chr, b.ischlorpromazine2_chr, b.nmldosage_dec,
                                 a.itemipunit_chr, a.opchargeflg_int, a.packqty_dec, a.dosage_dec,
                                 a.itemcode_vchr, 100 as precent_dec, y.typename_vchr as ybtypename,
                                 tp.qty_dec as recqty, tp.usageid_vchr as usageid_chr, tp.class_int as recclass 
                            from t_bse_chargeitem a,
                                 t_bse_medicine b,
                                 t_bse_usagetype c,
                                 t_aid_medicaretype y,
                                 t_aid_concertrecipe_plus tp
                           where a.itemsrcid_vchr = b.medicineid_chr(+)                            
                             and a.insurancetype_vchr = y.typeid_chr(+)
                             and tp.itemid_chr = a.itemid_chr
                             and tp.usageid_vchr = c.usageid_chr(+)
                             and tp.type_int = 0
                             and tp.class_int = 2
                             and tp.recipeid_chr = ?
                        order by tp.rowno_int";
            }
            else if (ClassID == 3 || ClassID == 4 || ClassID == 5)
            {
                SQL = @"select   a.orderdicid_chr, a.name_chr, a.des_vchr, a.usercode_chr,
                                 a.wbcode_chr, a.pycode_chr, a.execdept_chr, a.ordercateid_chr,
                                 a.itemid_chr, a.nullitemdosageunit_chr, a.nullitemuseunit_chr,
                                 a.nullitemdosetypeid_chr, a.status_int, a.sampleid_vchr,
                                 a.engname_vchr, a.commname_vchr, a.nullitemfreqid_vchr,
                                 a.nullitemuse_dec, a.lisapplyunitid_chr, a.applytypeid_chr,
                                 a.newchargetype_int, d.sample_type_desc_vchr, f.partname,
                                 h.itemspec_vchr, h.itemopinvtype_chr, h.ybtypename, h.itemunit,
                                 h.ifstop_int, h.itemcode_vchr, tp.qty_dec as recqty, 
                                 tp.usageid_vchr as usageid_chr, tp.class_int as recclass,
                                 tp.sampleid_chr as sample_type_id_chr, tp.partid_int as partid_vchr
                            from t_bse_bih_orderdic a,
                                 t_aid_lis_apply_unit c,
                                 t_aid_lis_sampletype d,
                                 ar_apply_partlist f,
                                 (select a.orderdicid_chr, c.itemspec_vchr, c.itemopinvtype_chr,
                                         c.typename_vchr as ybtypename, c.ifstop_int, c.itemcode_vchr, 
                                         (case c.ipchargeflg_int
                                             when 1
                                                then c.itemipunit_chr
                                             else c.itemunit_chr
                                          end
                                         ) as itemunit
                                    from t_bse_bih_orderdic a,
                                         (select a.itemid_chr, a.itemspec_vchr, a.itemopinvtype_chr,
                                                 b.typename_vchr, a.ipchargeflg_int, a.itemipunit_chr,
                                                 a.itemunit_chr, a.ifstop_int, a.itemcode_vchr 
                                            from t_bse_chargeitem a, t_aid_medicaretype b
                                           where a.inpinsurancetype_vchr = b.typeid_chr(+)) c
                                   where a.itemid_chr = c.itemid_chr(+)) h,
                                 t_aid_concertrecipe_plus tp
                           where a.applytypeid_chr = c.apply_unit_id_chr(+)
                             and a.orderdicid_chr = h.orderdicid_chr
                             and a.status_int = 1
                             and tp.itemid_chr = a.orderdicid_chr
                             and tp.sampleid_chr = d.sample_type_id_chr(+)
                             and tp.partid_int = f.partid(+)
                             and tp.type_int = 1
                             and tp.class_int = ?
                             and tp.recipeid_chr = ?
                        order by tp.rowno_int";
            }
            else if (ClassID == 6)
            {
                SQL = @"select   a.itemid_chr, a.itemname_vchr, a.itemspec_vchr, a.itemopinvtype_chr,
                                 a.itemcode_vchr, 100 as precent_dec, a.itemcommname_vchr,
                                 b.deptprep_int, y.typename_vchr as ybtypename, a.ifstop_int, 
                                 a.itemunit_chr as itemopunit_chr, a.itemprice_mny, a.selfdefine_int,
                                 a.itempycode_chr as type, a.itemengname_vchr, tp.qty_dec as recqty,
                                 tp.class_int as recclass     
                            from t_bse_chargeitem a,
                                 t_bse_medicine b,
                                 t_aid_medicaretype y,
                                 t_aid_concertrecipe_plus tp
                           where a.itemsrcid_vchr = b.medicineid_chr(+)                            
                             and a.insurancetype_vchr = y.typeid_chr(+)
                             and tp.itemid_chr = a.itemid_chr
                             and tp.type_int = 0
                             and tp.class_int = 6
                             and tp.recipeid_chr = ?
                        order by tp.rowno_int";
            }

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                if (ClassID == 3 || ClassID == 4 || ClassID == 5)
                {
                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = ClassID;
                    ParamArr[1].Value = RecipeID;
                }
                else
                {
                    objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                    ParamArr[0].Value = RecipeID;
                }

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
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

        #region 删除处方
        /// <summary>
        /// 删除处方
        /// </summary>
        /// <param name="RecipeID"></param>
        [AutoComplete]
        public long m_lngDelAccordRecipe(string RecipeID)
        {
            long lngRes = 0, lngAffects = 0;
            string SQL = "";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                SQL = @"delete from t_aid_concertrecipe a where a.recipeid_chr = ?";

                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = RecipeID;
                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

                SQL = @"delete from t_aid_concertrecipe_plus a where a.recipeid_chr = ?";

                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = RecipeID;
                lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);

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

        #region 判断是否为有效挂号
        /// <summary>
        /// 判断是否为有效挂号
        /// </summary>
        /// <param name="RegID"></param>
        /// <param name="DoctID"></param>
        /// <returns></returns>
        [AutoComplete]
        public bool m_blnIsAvailRegister(string RegID, string DoctID)
        {
            long lngRes = 0;
            string SQL = "";

            bool ret = false;                             
            DataTable dt = new DataTable();

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                int TimeInterval = 0;
                DataTable dt1 = new DataTable();
                SQL = @"select setstatus_int from t_sys_setting where setid_chr = ?";

                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = "0067";

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt1, ParamArr);
                if (lngRes > 0 && dt1.Rows.Count == 1)
                {
                    string s = dt1.Rows[0][0].ToString().Trim();
                    if (s != "" && Convert.ToInt32(s) > 0)
                    {
                        TimeInterval = Convert.ToInt32(s);
                    }
                }

                SQL = @"select  count (a.registerid_chr) as nums
                          from t_opr_patientregister a
                         where a.registerid_chr = ? 
                           and (a.takedoctor_chr = ? or a.takedoctor_chr is null)
                           and (sysdate between recorddate_dat and (recorddate_dat + ?/24))";               

                objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                ParamArr[0].Value = RegID;
                ParamArr[1].Value = DoctID;
                ParamArr[2].Value = TimeInterval;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
                objHRPSvc.Dispose();

                if (lngRes > 0 && dt.Rows.Count > 0)
                {
                    if (int.Parse(dt.Rows[0][0].ToString()) > 0)
                    {
                        ret = true;

                        SQL = @"update t_opr_patientregister a
                                   set a.takedoctor_chr = ? 
                                 where a.registerid_chr = ?";

                        objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                        ParamArr[0].Value = DoctID;
                        ParamArr[1].Value = RegID;

                        long lngAffects = 0;
                        lngRes = objHRPSvc.lngExecuteParameterSQL(SQL, ref lngAffects, ParamArr);
                    }
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return ret;
        }
        #endregion

        #region (顺德)判断合作医疗病人当天是否已看过病
        /// <summary>
        /// (顺德)判断合作医疗病人当天是否已看过病
        /// </summary>
        /// <param name="PatientID"></param>
        /// <param name="PayTypeID"></param>
        /// <returns></returns>
        [AutoComplete]
        public bool m_blnCheckSDHZYLPat(string PatientID, string PayTypeID)
        {
            bool blnRet = false;
            string SQL = "";
            DataTable dt = new DataTable();      

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                SQL = @"select count (takediagdr_chr) as nums
                          from t_opr_takediagrec
                         where pstatus_int = 2
                           and endtime_dat >= trunc (sysdate) 
                           and endtime_dat < trunc (sysdate + 1) 
                           and patientid_chr = ?
                           and paytypeid_chr = ?";

                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = PatientID;
                ParamArr[1].Value = PayTypeID;

                long lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
                if (lngRes > 0)
                {
                    if (dt.Rows[0][0].ToString() != "0")
                    {
                        blnRet = true;
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

            return blnRet;
        }
        #endregion

        #region 验验样本查询 
        /// <summary>
        /// 验验样本查询
        /// </summary>        
        /// <param name="p_strFind"></param>
        /// <param name="p_dtResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetSampleByFindString(string p_strFind, out DataTable p_dtResultArr)
        {
            p_dtResultArr = new DataTable();
            long lngRes = 0;

            string strSQL = @"select a.sample_type_id_chr sample_code,a.sample_type_desc_vchr sample_name
                                from t_aid_lis_sampletype a
                               where lower (trim (a.sample_type_id_chr)) like ?
                                  or lower (trim (a.sample_type_desc_vchr)) like ?
                                  or lower (trim (a.pycode_chr)) like ?
                                  or lower (trim (a.wbcode_chr)) like ?
                            order by a.sample_type_id_chr";

            try
            {
                lngRes = 0;
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] objParamArr = null;
                objHRPSvc.CreateDatabaseParameter(4, out objParamArr);
                objParamArr[0].Value = p_strFind.Trim().ToLower() + "%";
                objParamArr[1].Value = "%" + p_strFind.Trim().ToLower() + "%";
                objParamArr[2].Value = "%" + p_strFind.Trim().ToLower() + "%";
                objParamArr[3].Value = "%" + p_strFind.Trim().ToLower() + "%";
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtResultArr, objParamArr);
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

        #region 批量获取系统参数
        /// <summary>
        /// 批量获取系统参数
        /// </summary>
        /// <param name="p_strParamKeyArr"></param>
        /// <param name="p_hasParamValue"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetSysparm(string[] p_strParamKeyArr, out Hashtable p_hasParamValue)
        {
            long lngRes = 0;
            p_hasParamValue = null;
            System.Text.StringBuilder sbSub = new System.Text.StringBuilder();
            foreach (string strParamKey in p_strParamKeyArr)
            {
                sbSub.Append("'").Append(strParamKey).Append("',");
            }
            sbSub.Length = sbSub.Length - 1;
            string strSub = sbSub.ToString();
            sbSub = null;

            if (strSub == string.Empty)
            {
                return lngRes;
            }

            string SQL = @"select parmcode_chr, parmvalue_vchr
                                 from t_bse_sysparm 
                                where status_int = 1 
                                  and parmcode_chr in( " + strSub + " )";
            sbSub = null;

            clsHRPTableService objHRPSvc = null;
            try
            {
                objHRPSvc = new clsHRPTableService();
                DataTable dt = new DataTable();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dt);
                if (lngRes > 0 && dt.Rows.Count > 0)
                {
                    p_hasParamValue = new Hashtable();
                    foreach (DataRow dtrTemp in dt.Rows)
                    {
                        p_hasParamValue.Add(dtrTemp["parmcode_chr"].ToString().Trim(), dtrTemp["parmvalue_vchr"].ToString().Trim());
                    }
                }
                dt = null;
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                objLogger = null;
            }
            finally
            {
                objHRPSvc.Dispose();
                objHRPSvc = null;
                SQL = null;
            }

            return lngRes;
        }
        #endregion
    }

    #region 时间换算class
    /// <summary>
    /// 时间换算class
    /// </summary>
    public class clsConvertDateTime
    {        
        #region 计算年龄
        /// <summary>
        /// 计算年龄，根据返回的值得到是年，月或日
        /// </summary>
        /// <param name="dteBirth">出生日期</param>
        /// <param name="intAge">计算得到的年龄</param>
        /// <returns></returns>
        public static Age CalcAge(DateTime dteBirth, out int intAge)
        {
            Age age = Age.Year;
            intAge = 0;
            com.digitalwave.iCare.middletier.HIS.Reports.clsOPDoctorPlanSvc objSvc = new clsOPDoctorPlanSvc();

            DateTime dteNow = DateTime.Now;
            int intYear = dteBirth.Year;
            int intMonth = dteBirth.Month;
            int intDay = dteBirth.Day;

            if ((dteNow.Year - intYear) > 0)
            {
                intAge = dteNow.Year - intYear;
                age = Age.Year;
            }
            else if ((dteNow.Month - intMonth) > 0)
            {
                intAge = dteNow.Month - intMonth;
                age = Age.Month;
            }
            else
            {
                intAge = dteNow.Day - intDay;
                age = Age.Day;
            }

            return age;

        }
        #endregion

        #region 计算年龄
        /// <summary>
        /// 计算年龄
        /// </summary>
        /// <param name="dteBirth">出生日期</param>
        /// <returns></returns>
        public static string CalcAge(DateTime dteBirth)
        {
            int intAge = 0;
            string strAge = "";
            Age age = Age.Year;
            age = clsConvertDateTime.CalcAge(dteBirth, out intAge);
            switch (age)
            {
                case Age.Year:
                    strAge = intAge.ToString();
                    break;
                case Age.Month:
                    strAge = intAge.ToString() + "个月";
                    break;
                case Age.Day:
                    strAge = intAge.ToString() + "天";
                    break;
            }
            return strAge;
        }
        #endregion
        /// <summary>
        /// 年龄
        /// </summary>
        public enum Age
        {
            /// <summary>
            /// 年
            /// </summary>
            Year,
            /// <summary>
            /// 月
            /// </summary>
            Month,
            /// <summary>
            /// 日
            /// </summary>
            Day
        }
    }
    #endregion
}
