using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.Utility.SQLConvert;

namespace com.digitalwave.iCare.middletier.MedicineStoreService
{
    /// <summary>
    /// 处方出库统计
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsRecipeReportSVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 处方出库按身份统计
        /// <summary>
        /// 处方出库按身份统计
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strDrugID">药房</param>
        /// <param name="p_dtmStartDate">开始日期</param>
        /// <param name="p_dtmEndDate">结束日期</param>
        /// <param name="p_dtbResult">查询结果</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetRecipeByIdentity(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDrugID, DateTime p_dtmStartDate, DateTime p_dtmEndDate,
            out DataTable p_dtbResult)
        {
            long lngRes = -1;
            p_dtbResult = new DataTable();
            string m_strCondition = string.Empty;
            int m_intParamCount = 3;

            string m_strSql = @"select c.paytypename_vchr,
       sum(round(b.opretailprice_int * b.ipamount_int / e.packqty_dec, 2) *
           decode(b.type_int, 2, 1, -1)) as je
  from t_opr_outpatientrecipe    a,
       t_ds_recipeaccount_detail b,
       t_bse_patientpaytype      c,
       t_bse_medstore            d,
       t_bse_medicine            e
 where a.outpatrecipeid_chr = b.outpatrecipeid_chr
   and a.paytypeid_chr = c.paytypeid_chr
   and d.deptid_chr = b.drugstoreid_int
   and b.medicineid_chr = e.medicineid_chr
     and d.medstoreid_chr = ?
	 and b.operatedate_dat between ? and ? 	 
	 and b.type_int > 0
	 and b.type_int < 3
 group by c.paytypename_vchr order by c.paytypename_vchr";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] objParamArr = null;

                objHRPSvc.CreateDatabaseParameter(m_intParamCount, out objParamArr);
                objParamArr[0].Value = p_strDrugID;
                objParamArr[1].DbType = DbType.DateTime;
                objParamArr[1].Value = p_dtmStartDate;
                objParamArr[2].DbType = DbType.DateTime;
                objParamArr[2].Value = p_dtmEndDate;                

                lngRes = objHRPSvc.lngGetDataTableWithParameters(m_strSql, ref p_dtbResult, objParamArr);
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

        #region 处方出库按开单科室统计
        /// <summary>
        /// 处方出库按开单科室统计
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strDrugID">药房</param>
        /// <param name="p_dtmStartDate">开始日期</param>
        /// <param name="p_dtmEndDate">结束日期</param>
        /// <param name="p_dtbResult">查询结果</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetRecipeByDept(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDrugID, DateTime p_dtmStartDate, DateTime p_dtmEndDate,
            out DataTable p_dtbResult)
        {
            long lngRes = -1;
            p_dtbResult = new DataTable();
            string m_strCondition = string.Empty;
            int m_intParamCount = 3;

            string m_strSql = @"select nvl(t2.deptname_vchr, '<充公>') as deptname_vchr,
       sum(t1.je) as je,
       sum(decode(t1.je, 0, 0, 1)) as cfs
  from (select a.diagdept_chr,
               a.outpatrecipeid_chr,
               sum(round(b.opretailprice_int * b.ipamount_int /
                         c.packqty_dec,
                         2) * decode(b.type_int, 2, 1, -1)) as je
          from t_opr_outpatientrecipe    a,
               t_ds_recipeaccount_detail b,
               t_bse_medstore            d,
               t_bse_medicine            c
         where a.outpatrecipeid_chr = b.outpatrecipeid_chr
           and d.deptid_chr = b.drugstoreid_int
           and b.medicineid_chr = c.medicineid_chr
                     and d.medstoreid_chr = ?
					 and b.operatedate_dat between ? and ?					 
					 and b.type_int > 0
					 and b.type_int < 3
				 group by a.diagdept_chr, a.outpatrecipeid_chr) t1,
			 t_bse_deptdesc t2
 where t1.diagdept_chr = t2.deptid_chr(+)
 group by t2.deptname_vchr
 order by t2.deptname_vchr";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] objParamArr = null;

                objHRPSvc.CreateDatabaseParameter(m_intParamCount, out objParamArr);
                objParamArr[0].Value = p_strDrugID;
                objParamArr[1].DbType = DbType.DateTime;
                objParamArr[1].Value = p_dtmStartDate;
                objParamArr[2].DbType = DbType.DateTime;
                objParamArr[2].Value = p_dtmEndDate;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(m_strSql, ref p_dtbResult, objParamArr);
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

        #region 处方出库按单位品种统计
        /// <summary>
        /// 处方出库按单位品种统计
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strDrugID">药房</param>
        /// <param name="p_strDeptID">单位ID</param>
        /// <param name="p_dtmStartDate">开始日期</param>
        /// <param name="p_dtmEndDate">结束日期</param>
        /// <param name="p_dtbResult">查询结果</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRecipeByEachDeptReport(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDrugID, string p_strDeptID, DateTime p_dtmStartDate, DateTime p_dtmEndDate,
            out DataTable p_dtbResult)
        {
            long lngRes = -1;
            p_dtbResult = new DataTable();
            string m_strCondition = string.Empty;
            int m_intParamCount =4;

            string m_strSql = @"select c.assistcode_chr,
       b.medicinename_vchr,
       b.medspec_vchr,
       b.opunit_chr ipunit_chr,
       c.productorid_chr,
       decode(c.opchargeflg_int,
              0,
              sum(decode(b.type_int, 2, b.opamount_int, 1, -b.opamount_int)),
              sum(decode(b.type_int, 2, b.opamount_int, 1, -b.opamount_int))) ipamount,
       sum(decode(b.type_int,
                  2,
                  round(b.ipamount_int * b.opretailprice_int / c.packqty_dec,
                        2),
                  1,
                  round(-b.ipamount_int * b.opretailprice_int /
                        c.packqty_dec,
                        2))) sumprice,
                        e.deptname_vchr
  from t_opr_outpatientrecipe    a,
       t_ds_recipeaccount_detail b,
       t_bse_medicine            c,
       t_bse_medstore            d,
       t_bse_deptdesc            e
 where a.outpatrecipeid_chr = b.outpatrecipeid_chr
   and b.medicineid_chr = c.medicineid_chr
   and b.drugstoreid_int = d.deptid_chr
   and a.diagdept_chr=e.deptid_chr
   and b.type_int > 0
   and b.type_int < 3
   and d.medstoreid_chr = ?";
            if (!string.IsNullOrEmpty(p_strDeptID))
            {
                m_strSql += @"and a.diagdept_chr = ?
                       and b.operatedate_dat between ? and ?
 group by c.assistcode_chr,
					b.medicinename_vchr,
					b.medspec_vchr,
					b.opunit_chr,
					b.ipunit_chr,
					c.productorid_chr,
					c.opchargeflg_int,
          e.deptname_vchr
 order by c.assistcode_chr, b.medicinename_vchr";
            }
            else
            {
                m_strSql += @"and b.operatedate_dat between ? and ?
 group by c.assistcode_chr,
					b.medicinename_vchr,
					b.medspec_vchr,
					b.opunit_chr,
					b.ipunit_chr,
					c.productorid_chr,
					c.opchargeflg_int,
          e.deptname_vchr
 order by c.assistcode_chr, b.medicinename_vchr";
            }

            //	 and a.diagdept_chr = ?
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] objParamArr = null;
                if (!string.IsNullOrEmpty(p_strDeptID))
                {
                    objHRPSvc.CreateDatabaseParameter(m_intParamCount, out objParamArr);
                    objParamArr[0].Value = p_strDrugID;
                    objParamArr[1].Value = p_strDeptID;
                    objParamArr[2].DbType = DbType.DateTime;
                    objParamArr[2].Value = p_dtmStartDate;
                    objParamArr[3].DbType = DbType.DateTime;
                    objParamArr[3].Value = p_dtmEndDate;
                }
                else
                {
                    m_intParamCount = 3;
                    objHRPSvc.CreateDatabaseParameter(m_intParamCount, out objParamArr);
                    objParamArr[0].Value = p_strDrugID;
                    objParamArr[1].DbType = DbType.DateTime;
                    objParamArr[1].Value = p_dtmStartDate;
                    objParamArr[2].DbType = DbType.DateTime;
                    objParamArr[2].Value = p_dtmEndDate;
 
                }

                lngRes = objHRPSvc.lngGetDataTableWithParameters(m_strSql, ref p_dtbResult, objParamArr);
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

        #region 处方出库按品种科室分布
        /// <summary>
        /// 处方出库按品种科室分布
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strDrugID">药房</param>
        /// <param name="p_strDeptID">科室ID</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_dtmStartDate">开始日期</param>
        /// <param name="p_dtmEndDate">结束日期</param>
        /// <param name="p_dtbResult">查询结果</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngRecipeByMedicineDeptReport(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDrugID, string p_strDeptID, string p_strMedicineID,DateTime p_dtmStartDate, DateTime p_dtmEndDate,
            out DataTable p_dtbResult)
        {
            long lngRes = -1;
            p_dtbResult = new DataTable();
            string m_strCondition = string.Empty;
            int m_intParamCount = 0;
            if (p_strDeptID == "")
            {
                m_intParamCount = 4;
            }
            else
            {
                m_intParamCount = 5;
            }

            string m_strSql = @"select distinct deptname_vchr,
       b.medspec_vchr,
       decode(c.opchargeflg_int, 0, b.opunit_chr, b.opunit_chr) ipunit_chr,
       c.productorid_chr,
      sum(decode(c.opchargeflg_int, 0, b.opamount_int, b.opamount_int) *
       decode(b.type_int, 2, 1, -1)) as ipamount,
       sum(round(b.ipamount_int * b.opretailprice_int / c.packqty_dec, 2) *
       decode(b.type_int, 2, 1, -1)) as sumprice
  from t_opr_outpatientrecipe    a,
       t_ds_recipeaccount_detail b,
       t_bse_medicine            c,
       t_bse_medstore            d,
       t_bse_deptdesc            e
 where a.outpatrecipeid_chr = b.outpatrecipeid_chr
   and b.medicineid_chr = c.medicineid_chr
   and d.deptid_chr = b.drugstoreid_int
   and a.diagdept_chr = e.deptid_chr(+)
	 and d.medstoreid_chr = ?";
            if(m_intParamCount == 5)
            {
                m_strSql += @" and a.diagdept_chr = ?";
            }
            m_strSql += @" and c.medicineid_chr = ? and b.operatedate_dat between ? and ?
	 and b.type_int > 0
	 and b.type_int < 3  group by deptname_vchr,b.medspec_vchr,b.opunit_chr,c.productorid_chr,c.opchargeflg_int";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] objParamArr = null;

                objHRPSvc.CreateDatabaseParameter(m_intParamCount, out objParamArr);
                if (m_intParamCount == 4)
                {
                    objParamArr[0].Value = p_strDrugID;
                    objParamArr[1].Value = p_strMedicineID;
                    objParamArr[2].DbType = DbType.DateTime;
                    objParamArr[2].Value = p_dtmStartDate;
                    objParamArr[3].DbType = DbType.DateTime;
                    objParamArr[3].Value = p_dtmEndDate;
                }
                else
                {
                    objParamArr[0].Value = p_strDrugID;
                    objParamArr[1].Value = p_strDeptID;
                    objParamArr[2].Value = p_strMedicineID;
                    objParamArr[3].DbType = DbType.DateTime;
                    objParamArr[3].Value = p_dtmStartDate;
                    objParamArr[4].DbType = DbType.DateTime;
                    objParamArr[4].Value = p_dtmEndDate;
                }

                lngRes = objHRPSvc.lngGetDataTableWithParameters(m_strSql, ref p_dtbResult, objParamArr);
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

        #region 麻、精药品处方出库明细表
        /// <summary>
        /// 麻、精药品处方出库明细表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strDrugID">药房</param>
        /// <param name="p_dtmStartDate">开始日期</param>
        /// <param name="p_dtmEndDate">结束日期</param>
        /// <param name="p_intType">特殊药品的类型</param>
        /// <param name="p_dtbResult">查询结果</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetRecipeBySpecialMedicine(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDrugID, DateTime p_dtmStartDate, DateTime p_dtmEndDate,
            int p_intType,string p_strMedicineId,out DataTable p_dtbResult)
        {
            long lngRes = -1;
            p_dtbResult = new DataTable();
            string m_strCondition = string.Empty;
            int m_intParamCount = 3;
            string m_strPutAll = string.Empty;
            string m_strPutRetreate = string.Empty;
            string m_strSql = @"select t5.medicinename_vchr,
			 t5.medspec_vchr,
			 t1.treatdate_dat,
			 t9.patientcardid_chr,
			 t10.lastname_vchr,
			 t6.usagename_vchr,
			 t7.freqname_chr,
			 t3.dosage_dec,
			 t3.dosageunit_chr,
			 t3.tolqty_dec,
			 t3.days_int,
			 t3.unitid_chr,
			 t8.lastname_vchr lastname,
			 (select sum(b.retamout_dec)
					from t_opr_returnmed_entry b
				 where b.outpatrecipeid_chr = t3.outpatrecipeid_chr
					 and b.itemid_chr = t3.itemid_chr
				 group by b.outpatrecipeid_chr, b.itemid_chr) as tys
	from t_opr_recipesend            t1,
			 t_opr_recipesendentry       t2,
			 t_opr_outpatientpwmrecipede t3,
			 t_bse_chargeitem            t4,
			 t_bse_medicine              t5,
			 t_bse_usagetype             t6,
			 t_aid_recipefreq            t7,
			 t_bse_employee              t8,
			 t_bse_patientcard           t9,
			 t_bse_patient               t10
 where t1.sid_int = t2.sid_int
	 and t2.outpatrecipeid_chr = t3.outpatrecipeid_chr
	 and t3.itemid_chr = t4.itemid_chr
	 and t4.itemsrcid_vchr = t5.medicineid_chr
	 and t3.usageid_chr = t6.usageid_chr(+)
	 and t3.freqid_chr = t7.freqid_chr(+)
     and t1.medstoreid_chr = ?
	 and t1.treatdate_dat between ? and ?	 
	 and t1.patientid_chr = t9.patientid_chr
	 and t1.patientid_chr = t10.patientid_chr
	 and t1.treatemp_chr = t8.empid_chr";
            if(p_strDrugID=="0003")
            {
                //获取住院已摆药信息
                m_strPutAll = @"select a.pubdate_dat,
       a.unit_vchr,
       a.unitprice_mny,
       a.get_dec,
       a.orderexectype_int,
       b.medicineid_chr,
       b.assistcode_chr,
       b.medicinename_vchr,
       b.medspec_vchr,
       c.code_vchr,
       c.deptname_vchr,
       d.inpatientid_chr,
       e.lastname_vchr,
       e.sex_chr,
       f.code_chr,
       g.putmed_int
  from t_bih_opr_putmeddetail   a,
       t_bse_medicine           b,
       t_bse_deptdesc           c,
       t_opr_bih_register       d,
       t_opr_bih_registerdetail e,
       t_bse_bed                f,
       t_bse_usagetype          g
 where (a.areaid_chr = c.deptid_chr)
   and (a.medid_chr = b.medicineid_chr)
   and (a.registerid_chr = d.registerid_chr)
   and (d.registerid_chr = e.registerid_chr)
   and (g.usageid_chr = b.usageid_chr)
   and (a.bedid_chr = f.bedid_chr(+))
   and a.ISPUT_INT = 1
   and a.status_int = 1
   and a.MEDSTOREID_CHR = ?
   and a.PUBDATE_DAT >= ?
   and a.PUBDATE_DAT <= ? ";

                //获取住院退药信息
                m_strPutRetreate = @"select h.examreturnmed_dat,
       a.unit_vchr,
       a.unitprice_dec,
       a.amount_dec,
       a.orderexectype_int,
       b.medicineid_chr,
       b.assistcode_chr,
       b.medicinename_vchr,
       b.medspec_vchr,
              e.deptid_chr,
       e.deptname_vchr,
       c.inpatientid_chr,
       d.lastname_vchr,
       d.sex_chr,
              f.code_chr,
       j.putmed_int
  from t_opr_bih_patientcharge  a,
       t_bse_chargeitem         g,
       t_bse_medicine           b,
       t_opr_bih_register       c,
       t_opr_bih_registerdetail d,
       t_bse_bed                f,
       t_bse_deptdesc           e,
       t_bih_opr_putmeddetail   h,
       t_bse_usagetype          j
 where a.chargeitemid_chr = g.itemid_chr
   and b.medicineid_chr = g.itemsrcid_vchr
   and a.registerid_chr = c.registerid_chr
   and a.registerid_chr = d.registerid_chr
   and a.curareaid_chr = e.deptid_chr
   and b.usageid_chr = j.usageid_chr
   and h.pchargeid_chr = a.pchargeidorg_chr
   and a.status_int = 1
   and c.status_int = 1
   and e.status_int = 1
   and h.examreturnmed_int = 1
   and a.amount_dec < 0
   and h.status_int = 1
   and a.putmedicineflag_int <> -1
   and d.registerid_chr = f.bihregisterid_chr(+)
   and b.putmedtype_int = 1
   and h.examreturnmed_dat >= ?
   and h.examreturnmed_dat <= ?
   and b.medicnetype_int in (1,4)
";
            }
            switch (p_intType)
            {
                case 0:
                    if (p_strDrugID == "0003")
                    {
                        m_strPutAll += " and b.isanaesthesia_chr='T'";
                        m_strPutRetreate += " and b.isanaesthesia_chr='T'";
                        break;
                    }
                    m_strSql += " and t5.isanaesthesia_chr='T'";
                    break;

                case 1:
                    if (p_strDrugID == "0003")
                    {
                        m_strPutAll += " and b.ispoison_chr='T'";
                        m_strPutRetreate += " and b.ispoison_chr='T'";
                        break;
                    }
                    m_strSql += " and t5.ispoison_chr='T'";
                    break;

                case 2:
                    if (p_strDrugID == "0003")
                    {
                        m_strPutAll += " and b.ischlorpromazine_chr='T'";
                        m_strPutRetreate += " and b.ischlorpromazine_chr='T'";
                        break;
                    }
                    
                    m_strSql += " and t5.ischlorpromazine_chr='T'";
                    break;

                case 3:
                    if (p_strDrugID == "0003")
                    {
                        m_strPutAll += " and b.ischlorpromazine2_chr='T'";
                        m_strPutRetreate += " and b.ischlorpromazine2_chr='T'";
                        break;
                    }
                    m_strSql += " and t5.ischlorpromazine2_chr='T'";
                    break;

                default:
                    break;
            }


//--     t5.isanaesthesia_chr='t' --麻醉
//--     t5.ispoison_chr ='t'--毒性
//--     t5.ischlorpromazine_chr ='t' --精神1
//--     t5.ischlorpromazine2_chr='t'  --精神2)";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] objParamArr = null;
                if (string.IsNullOrEmpty(p_strMedicineId))
                {
                    if(p_strDrugID=="0001")
                    {
                    objHRPSvc.CreateDatabaseParameter(m_intParamCount, out objParamArr);
                    objParamArr[0].Value = p_strDrugID;
                    objParamArr[1].DbType = DbType.DateTime;
                    objParamArr[1].Value = p_dtmStartDate;
                    objParamArr[2].DbType = DbType.DateTime;
                    objParamArr[2].Value = p_dtmEndDate;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(m_strSql, ref p_dtbResult, objParamArr);
                    }
                    if(p_strDrugID=="0003")
                    {
                        m_intParamCount = 5;
                        objHRPSvc.CreateDatabaseParameter(m_intParamCount, out objParamArr);
                        objParamArr[0].Value = p_strDrugID;
                        objParamArr[1].DbType = DbType.DateTime;
                        objParamArr[1].Value = p_dtmStartDate;
                        objParamArr[2].DbType = DbType.DateTime;
                        objParamArr[2].Value = p_dtmEndDate;
                        objParamArr[3].DbType = DbType.DateTime;
                        objParamArr[3].Value = p_dtmStartDate;
                        objParamArr[4].DbType = DbType.DateTime;
                        objParamArr[4].Value = p_dtmEndDate;
                        m_strSql = m_strPutAll + "  union all  " + m_strPutRetreate;
                        lngRes = objHRPSvc.lngGetDataTableWithParameters(m_strSql, ref p_dtbResult, objParamArr);

                    }

                }
                else
                {
                    if(p_strDrugID=="0001")
                    {
                    m_intParamCount = 4;
                    objHRPSvc.CreateDatabaseParameter(m_intParamCount, out objParamArr);
                    objParamArr[0].Value = p_strDrugID;
                    objParamArr[1].DbType = DbType.DateTime;
                    objParamArr[1].Value = p_dtmStartDate;
                    objParamArr[2].DbType = DbType.DateTime;
                    objParamArr[2].Value = p_dtmEndDate;
                    objParamArr[3].DbType = DbType.String;
                    objParamArr[3].Value = p_strMedicineId.Trim();
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(m_strSql, ref p_dtbResult, objParamArr);
                    }
                    if(p_strDrugID=="0003")
                    {
                        m_intParamCount = 7;
                        m_strPutAll += "and b.medicineid_chr= ?";
                        m_strPutRetreate += "and b.medicineid_chr= ?";
                        objHRPSvc.CreateDatabaseParameter(m_intParamCount, out objParamArr);
                        objParamArr[0].Value = p_strDrugID;
                        objParamArr[1].DbType = DbType.DateTime;
                        objParamArr[1].Value = p_dtmStartDate;
                        objParamArr[2].DbType = DbType.DateTime;
                        objParamArr[2].Value = p_dtmEndDate;
                        objParamArr[3].Value = p_strMedicineId;
                        objParamArr[4].DbType = DbType.DateTime;
                        objParamArr[4].Value = p_dtmStartDate;
                        objParamArr[5].DbType = DbType.DateTime;
                        objParamArr[5].Value = p_dtmEndDate;
                        objParamArr[6].Value = p_strMedicineId;
                        m_strSql = m_strPutAll + "  union all  " + m_strPutRetreate;
                        lngRes = objHRPSvc.lngGetDataTableWithParameters(m_strSql, ref p_dtbResult, objParamArr);

                    }
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
    }
}
