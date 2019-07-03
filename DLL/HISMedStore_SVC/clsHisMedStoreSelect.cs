using System;
using System.Data;
using System.EnterpriseServices;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
using System.Collections;
using System.Collections.Generic;
using com.digitalwave.iCare.middletier.CryptographyLib;

namespace com.digitalwave.iCare.middletier.HIS
{
    /// <summary>
    /// 药房查询业务操作专有类
    /// </summary>
    [Transaction(TransactionOption.Supported)]
    [ObjectPooling(Enabled = true)]
    public class clsHisMedStoreSelect : clsMiddleTierBase
    {
        #region 通过窗口取当前病人队列
        /// <summary>
        /// 通过窗口取当前病人队列
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="windStatus">窗体状态信息</param>
        /// <param name="strDate"></param></param>
        /// <param name="p_dtbResult"></param>
        /// <param name="dtDuty"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPatientListByWinID(System.Security.Principal.IPrincipal p_objPrincipal,
            clsStatusWindows_VO windStatus, string strDate, out DataTable p_dtbResult, DataTable dtDuty)
        {
            long lngRes = 0;
            p_dtbResult = null;
            if (windStatus.statusTone == 1)
            {
                string strSQL = @"select a.sid_int,
       a.serno_chr,
       a.sendwindowid_chr as sendwindowid,
       a.medstoreid_chr,
       a.autoprint_int,
       a.windowid_chr,
       b.outpatrecipeid_chr,
       c.type_int as recipetype_int,
       a.pstatus_int,
       a.senddate_dat,
       a.sendemp_chr,
       a.treatdate_dat,
       a.orderno_int,
       a.called_int,
       a.currentcall_int,
       a.treatemp_chr,
       e.name_vchr,
       c.pstauts_int,
       c.pstauts_int as breakpstatus,
       f.patientcardid_chr,
       e.sex_chr,
       e.idcard_chr,
       r.typename_vchr,
       decode(c.createtype_int,0,r.typename_vchr,'') recipetypename,
       e.birth_dat,
       decode(i.internalflag_int, 0, '自费', 1, '公费', 2, '医保') as internalname,
       n.invoiceno_vchr,
       i.paytypename_vchr,
       i.paytypeid_chr,
       n.status_int,
       g.lastname_vchr,
       a.autoprint_int,
       a.returndate_dat,
       e.homephone_vchr,
       e.patientid_chr,
       n.recorddate_dat,
       p.empno_chr as opremp_chr,
       p.lastname_vchr as checkname,
       d.lastname_vchr as sendname,
       n.split_int,
       a.senddate_dat as givedate_dat,
       a.injectprint_int,
       a.sendemp_chr as giveemp_chr,
       a.returnemp_chr,
       v.deptname_vchr,
       c.recorddate_dat as commitdate_dat, a.autoprintyd_int , a.autoprintyd_int 
  from t_opr_recipesend          a,
       t_opr_recipesendentry     b,
       t_opr_outpatientrecipe    c,
       t_bse_patient             e,
       t_bse_patientcard         f,
       t_bse_employee            h,
       t_opr_reciperelation      k,
       t_opr_charge              l,
       t_opr_chargedefinv        m,
       t_opr_outpatientrecipeinv n,
       t_bse_employee            g,
       t_bse_employee            d,
       t_bse_patientpaytype      i,
       t_aid_recipetype          r,
       t_bse_deptdesc            v,
       t_bse_employee            p
 where a.sid_int = b.sid_int
   and b.outpatrecipeid_chr = c.outpatrecipeid_chr
   and c.outpatrecipeid_chr = k.outpatrecipeid_chr
   and k.chargeno_chr = l.chargeno_chr
   and l.chargeno_chr = m.chargeno_chr
   and m.invoiceno_vchr = n.invoiceno_vchr
   and l.status_int = 1
   and n.status_int = 1
   and a.windowid_chr = ?
   and a.patientid_chr = e.patientid_chr(+)
   and a.patientid_chr = f.patientid_chr(+)
   and c.diagdr_chr = h.empid_chr(+)
   and a.treatemp_chr = g.empid_chr(+)
   and a.sendemp_chr = d.empid_chr(+)
   and n.opremp_chr = p.empid_chr(+)
   and a.createdate_chr >= ?
   and a.createdate_chr <= ?
   and l.type_int = 1
   and c.paytypeid_chr = i.paytypeid_chr(+)
   and c.type_int = r.type_int(+)
   and c.diagdept_chr = v.deptid_chr(+)
   and a.pstatus_int in (-1, 1, 2)";
                try
                {
                    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                    System.Data.IDataParameter[] objLisAddItemRefArr = null;
                    objHRPSvc.CreateDatabaseParameter(3, out objLisAddItemRefArr);
                    objLisAddItemRefArr[0].Value = windStatus.strWindowID;
                    objLisAddItemRefArr[1].Value = strDate;
                    objLisAddItemRefArr[2].Value = strDate;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtbResult, objLisAddItemRefArr);
                    DataView dv = p_dtbResult.DefaultView;
                    dv.Sort = "orderno_int desc, sid_int desc";
                    p_dtbResult = dv.ToTable();
                    objHRPSvc.Dispose();
                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            else if (windStatus.statusTone == 2)
            {
                string strSQL = @"select a.sid_int,
       a.serno_chr,
       a.sendwindowid_chr as sendwindowid,
       a.medstoreid_chr,
       a.autoprint_int,
       a.windowid_chr,
       b.outpatrecipeid_chr,
       c.type_int as recipetype_int,
       a.pstatus_int,
       a.senddate_dat,
       a.sendemp_chr,
       a.treatdate_dat,
       a.orderno_int,
       a.called_int,
       a.currentcall_int,
       a.treatemp_chr,
       e.name_vchr,
       c.pstauts_int,
       c.pstauts_int as breakpstatus,
       f.patientcardid_chr,
       e.sex_chr,
       e.idcard_chr,
       r.typename_vchr,
       decode(c.createtype_int,0,r.typename_vchr,'') recipetypename,
       e.birth_dat,
       decode(i.internalflag_int, 0, '自费', 1, '公费', 2, '医保') as internalname,
       n.invoiceno_vchr,
       i.paytypename_vchr,
       i.paytypeid_chr,
       n.status_int,
       g.lastname_vchr,
       a.autoprint_int,
       a.returndate_dat,
       e.homephone_vchr,
       e.patientid_chr,
       n.recorddate_dat,
       p.empno_chr as opremp_chr,
       p.lastname_vchr as checkname,
       d.lastname_vchr as sendname,
       n.split_int,
       a.senddate_dat as givedate_dat,
       a.injectprint_int,
       a.sendemp_chr as giveemp_chr,
       a.returnemp_chr,
       v.deptname_vchr,
       c.recorddate_dat as commitdate_dat, a.autoprintyd_int 
  from t_opr_recipesend          a,
       t_opr_recipesendentry     b,
       t_opr_outpatientrecipe    c,
       t_bse_patient             e,
       t_bse_patientcard         f,
       t_bse_employee            h,
       t_opr_reciperelation      k,
       t_opr_charge              l,
       t_opr_chargedefinv        m,
       t_opr_outpatientrecipeinv n,
       t_bse_employee            g,
       t_bse_employee            d,
       t_bse_patientpaytype      i,
       t_aid_recipetype          r,
       t_bse_deptdesc            v,
       t_bse_employee            p
 where a.sid_int = b.sid_int
   and b.outpatrecipeid_chr = c.outpatrecipeid_chr
   and c.outpatrecipeid_chr = k.outpatrecipeid_chr
   and k.chargeno_chr = l.chargeno_chr
   and l.chargeno_chr = m.chargeno_chr
   and m.invoiceno_vchr = n.invoiceno_vchr
   and l.status_int = 1
   and n.status_int = 1
   and a.sendwindowid_chr = ?
   and a.patientid_chr = e.patientid_chr(+)
   and a.patientid_chr = f.patientid_chr(+)
   and c.diagdr_chr = h.empid_chr(+)
   and a.treatemp_chr = g.empid_chr(+)
   and a.sendemp_chr = d.empid_chr(+)
   and n.opremp_chr = p.empid_chr(+)
   and a.createdate_chr >= ?
   and a.createdate_chr <= ?
   and l.type_int = 1
   and c.paytypeid_chr = i.paytypeid_chr(+)
   and c.type_int = r.type_int(+)
   and c.diagdept_chr = v.deptid_chr(+)
   and a.pstatus_int in (2,3)";
                try
                {
                    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                    System.Data.IDataParameter[] objLisAddItemRefArr = null;
                    objHRPSvc.CreateDatabaseParameter(3, out objLisAddItemRefArr);
                    objLisAddItemRefArr[0].Value = windStatus.strWindowID;
                    objLisAddItemRefArr[1].Value = strDate;
                    objLisAddItemRefArr[2].Value = strDate;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtbResult, objLisAddItemRefArr);
                    DataView dv = p_dtbResult.DefaultView;
                    dv.Sort = "orderno_int desc, sid_int desc";
                    p_dtbResult = dv.ToTable();
                    objHRPSvc.Dispose();
                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }

            return lngRes;
        }
        #endregion
        #region 通过窗口取当前精神或麻醉或急诊处方类型的病人队列
        /// <summary>
        /// 通过窗口取当前精神或麻醉处方类型的病人队列
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="windStatus">窗体状态信息</param>
        /// <param name="strDate"></param></param>
        /// <param name="p_dtbResult"></param>
        /// <param name="dtDuty"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPatientListByWinIDForData(System.Security.Principal.IPrincipal p_objPrincipal,
            clsStatusWindows_VO windStatus, string strDate, out DataTable p_dtbResult, DataTable dtDuty)
        {
            long lngRes = 0;
            p_dtbResult = null;
            strDate = DateTime.Parse(strDate).ToString("yyyy-MM-dd");
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc", "m_lngGetPatientListByWinIDForData");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"select p.name_vchr as patientname, r.typename_vchr
  from t_opr_recipesend a,
       t_opr_recipesendentry i,
       t_opr_outpatientrecipe b,
       t_bse_patient p,
       t_aid_recipetype r
 where a.sid_int = i.sid_int
   and b.deptmed_int = 0
   and b.type_int = r.type_int(+)
   and b.patientid_chr = p.patientid_chr
   and a.createdate_chr = ?
   and i.outpatrecipeid_chr = b.outpatrecipeid_chr
   and (a.pstatus_int = 1 or a.pstatus_int = 2 or a.pstatus_int = -1)
   and a.windowid_chr = ?
   and b.type_int = 2
union all
select p.name_vchr as patientname, r.typename_vchr
  from t_opr_recipesend a,
       t_opr_recipesendentry i,
       t_opr_outpatientrecipe b,
       t_bse_patient p,
       t_aid_recipetype r
 where a.sid_int = i.sid_int
   and b.deptmed_int = 0
   and b.type_int = r.type_int(+)
   and b.patientid_chr = p.patientid_chr
   and a.createdate_chr = ?
   and i.outpatrecipeid_chr = b.outpatrecipeid_chr
   and (a.pstatus_int = 1 or a.pstatus_int = 2 or a.pstatus_int = -1)
   and a.windowid_chr = ?
   and b.type_int = 3
union all
select p.name_vchr as patientname, r.typename_vchr
  from t_opr_recipesend a,
       t_opr_recipesendentry i,
       t_opr_outpatientrecipe b,
       t_bse_patient p,
       t_aid_recipetype r
 where a.sid_int = i.sid_int
   and b.deptmed_int = 0
   and b.type_int = r.type_int(+)
   and b.patientid_chr = p.patientid_chr
   and a.createdate_chr = ?
   and i.outpatrecipeid_chr = b.outpatrecipeid_chr
   and (a.pstatus_int = 1 or a.pstatus_int = 2 or a.pstatus_int = -1)
   and a.windowid_chr = ?
   and b.type_int = 4
union all
select p.name_vchr as patientname, r.typename_vchr
  from t_opr_recipesend a,
       t_opr_recipesendentry i,
       t_opr_outpatientrecipe b,
       t_bse_patient p,
       t_aid_recipetype r
 where a.sid_int = i.sid_int
   and b.deptmed_int = 0
   and b.type_int = r.type_int(+)
   and b.patientid_chr = p.patientid_chr
   and a.createdate_chr = ?
   and i.outpatrecipeid_chr = b.outpatrecipeid_chr
   and (a.pstatus_int = 1 or a.pstatus_int = 2 or a.pstatus_int = -1)
   and a.windowid_chr = ?
   and b.type_int = 5";
            try
            {
                if (windStatus.statusTone == 2)
                {
                    strSQL = @" select p.name_vchr as patientname, r.typename_vchr
  from t_opr_recipesend a,
       t_opr_recipesendentry i,
       t_opr_outpatientrecipe b,
       t_bse_patient p,
       t_aid_recipetype r
 where a.sid_int = i.sid_int
   and b.deptmed_int = 0
   and b.type_int = r.type_int(+)
   and b.patientid_chr = p.patientid_chr
   and a.createdate_chr = ?
   and i.outpatrecipeid_chr = b.outpatrecipeid_chr
   and (a.pstatus_int = 2 or a.pstatus_int = 3)
   and a.sendwindowid_chr = ?
   and b.type_int = 2
union all
select p.name_vchr as patientname, r.typename_vchr
  from t_opr_recipesend a,
       t_opr_recipesendentry i,
       t_opr_outpatientrecipe b,
       t_bse_patient p,
       t_aid_recipetype r
 where a.sid_int = i.sid_int
   and b.deptmed_int = 0
   and b.type_int = r.type_int(+)
   and b.patientid_chr = p.patientid_chr
   and a.createdate_chr = ?
   and i.outpatrecipeid_chr = b.outpatrecipeid_chr
   and (a.pstatus_int = 2 or a.pstatus_int = 3)
   and a.sendwindowid_chr = ?
   and b.type_int = 3
union all
select p.name_vchr as patientname, r.typename_vchr
  from t_opr_recipesend a,
       t_opr_recipesendentry i,
       t_opr_outpatientrecipe b,
       t_bse_patient p,
       t_aid_recipetype r
 where a.sid_int = i.sid_int
   and b.deptmed_int = 0
   and b.type_int = r.type_int(+)
   and b.patientid_chr = p.patientid_chr
   and a.createdate_chr = ?
   and i.outpatrecipeid_chr = b.outpatrecipeid_chr
   and (a.pstatus_int = 2 or a.pstatus_int = 3)
   and a.sendwindowid_chr = ?
   and b.type_int = 4
union all
select p.name_vchr as patientname, r.typename_vchr
  from t_opr_recipesend a,
       t_opr_recipesendentry i,
       t_opr_outpatientrecipe b,
       t_bse_patient p,
       t_aid_recipetype r
 where a.sid_int = i.sid_int
   and b.deptmed_int = 0
   and b.type_int = r.type_int(+)
   and b.patientid_chr = p.patientid_chr
   and a.createdate_chr = ?
   and i.outpatrecipeid_chr = b.outpatrecipeid_chr
   and (a.pstatus_int = 2 or a.pstatus_int = 3)
   and a.sendwindowid_chr = ?
   and b.type_int = 5";

                }
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(8, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = strDate;
                objLisAddItemRefArr[1].Value = windStatus.strWindowID;
                objLisAddItemRefArr[2].Value = strDate;
                objLisAddItemRefArr[3].Value = windStatus.strWindowID;
                objLisAddItemRefArr[4].Value = strDate;
                objLisAddItemRefArr[5].Value = windStatus.strWindowID;
                objLisAddItemRefArr[6].Value = strDate;
                objLisAddItemRefArr[7].Value = windStatus.strWindowID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtbResult, objLisAddItemRefArr);
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
        #region 查找数据
        /// <summary>
        ///  查找数据
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_intStatus"></param>
        /// <param name="p_strStorageID"></param>
        /// <param name="p_strWinID"></param>
        /// <param name="p_strCardID"></param>
        /// <param name="p_strPatient"></param>
        /// <param name="p_strRegNo"></param>
        /// <param name="p_strRegDate"></param>
        /// <param name="p_endDate"></param>
        /// <param name="isShowReturn"></param>
        /// <param name="p_dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetPatientList(System.Security.Principal.IPrincipal p_objPrincipal, int p_intStatus, string p_strStorageID,
            string p_strWinID, string p_strCardID, string p_strPatient, string p_strRegNo,
            string p_strRegDate, string p_endDate, bool isShowReturn, out DataTable p_dtbResult)
        {
            long lngRes = 0;
            p_dtbResult = null;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc", "m_lngGetPatientList");
            if (lngRes < 0)
            {
                return -1;
            }
            string strWhere = "";
            if (p_strCardID.Trim() != "")
                strWhere += " and f.patientcardid_chr = '" + p_strCardID.Trim() + "' ";
            if (p_strPatient.Trim() != "")
                strWhere += " and e.name_vchr like '" + p_strPatient.Trim() + "%'";
            if (p_intStatus == 1)
            {
                strWhere += " and a.pstatus_int in(-1,1,2) ";
            }
            if (p_intStatus == 2)
            {
                strWhere += " and (a.pstatus_int=2 or a.pstatus_int=3)";
            }

            string strSQL = @"select /*+all_rows*/ a.windowid_chr,
       b.outpatrecipeid_chr,
       c.type_int as recipetype_int,
       a.pstatus_int,
       a.senddate_dat,
       a.sendemp_chr,
       a.treatdate_dat,
       a.orderno_int,
       a.called_int,
       a.currentcall_int,
       a.treatemp_chr,
       e.name_vchr,
       c.pstauts_int,
       c.pstauts_int as breakpstatus,
       f.patientcardid_chr,
       e.sex_chr,
       e.idcard_chr,
       r.typename_vchr,
       decode(c.createtype_int,0,r.typename_vchr,'') recipetypename,
       e.birth_dat,
       decode(i.internalflag_int, 0, '自费', 1, '公费', 2, '医保') as internalname,
       n.invoiceno_vchr,
       i.paytypename_vchr,
       i.paytypeid_chr,
       n.status_int,
       g.lastname_vchr,
       a.autoprint_int,
       a.medstoreid_chr,
       a.returndate_dat,
       e.homephone_vchr,
       e.patientid_chr,
       n.recorddate_dat,
       p.empno_chr as opremp_chr,
       p.lastname_vchr as checkname,
       d.lastname_vchr as sendname,
       n.split_int,
       a.sendwindowid_chr as sendwindowid,
       a.senddate_dat as givedate_dat,
       a.sid_int,
       a.serno_chr,
       a.injectprint_int,
       a.sendemp_chr as giveemp_chr,
       a.returnemp_chr,
       v.deptname_vchr,
       c.recorddate_dat as commitdate_dat, a.autoprintyd_int 
  from t_opr_recipesend          a,
       t_opr_recipesendentry     b,
       t_opr_outpatientrecipe    c,
       t_bse_patient             e,
       t_bse_patientcard         f,
       t_bse_employee            h,
       t_opr_reciperelation      k,
       t_opr_charge              l,
       t_opr_chargedefinv        m,
       t_opr_outpatientrecipeinv n,
       t_bse_employee            g,
       t_bse_employee            d,
       t_bse_patientpaytype      i,
       t_aid_recipetype          r,
       t_bse_deptdesc            v,
       t_bse_employee p
 where a.sid_int = b.sid_int
   and b.outpatrecipeid_chr = c.outpatrecipeid_chr
   and c.outpatrecipeid_chr = k.outpatrecipeid_chr
   and k.chargeno_chr = l.chargeno_chr
   and l.chargeno_chr = m.chargeno_chr
   and m.invoiceno_vchr = n.invoiceno_vchr
   and l.status_int = 1
   and n.status_int = 1
   and a.medstoreid_chr = ?
   and a.patientid_chr = e.patientid_chr(+)
   and a.patientid_chr = f.patientid_chr(+)
   and c.diagdr_chr = h.empid_chr(+)
   and a.treatemp_chr = g.empid_chr(+)
   and a.sendemp_chr = d.empid_chr(+)
   and n.opremp_chr = p.empid_chr(+)
   and a.createdate_chr >= ?
   and a.createdate_chr <= ?
   and l.type_int = 1
   and c.paytypeid_chr = i.paytypeid_chr(+)
   and c.type_int = r.type_int(+)
   and c.diagdept_chr = v.deptid_chr(+)" + strWhere;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(3, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = p_strStorageID.Trim();
                objLisAddItemRefArr[1].Value = Convert.ToDateTime(p_strRegDate).ToString("yyyy-MM-dd");
                objLisAddItemRefArr[2].Value = Convert.ToDateTime(p_endDate).ToString("yyyy-MM-dd");
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL.ToString(), ref p_dtbResult, objLisAddItemRefArr);
                DataView dv = p_dtbResult.DefaultView;
                if (isShowReturn == false)
                    dv.RowFilter = "breakpstatus<>-2";
                else
                    dv.RowFilter = "1=1";
                dv.Sort = "orderno_int ,sid_int desc";
                p_dtbResult = dv.ToTable();
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
        #region 根据药房id及创建日期取配发药信息
        /// <summary>
        /// 根据药房id及创建日期取配发药信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="strMedStoreid"></param>
        /// <param name="strBeginDate"></param>
        /// <param name="strEndDate"></param>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetQueryDosageRecipeInfo(System.Security.Principal.IPrincipal p_objPrincipal, byte m_byteDosageFlag, string strMedStoreid, string strBeginDate, string strEndDate, out DataTable m_objTable)
        {
            long lngRes = 0;
            m_objTable = new DataTable();
            //权限类
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc", "m_lngGetQueryDosageRecipeInfo");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            if (m_byteDosageFlag == 1)
            {
                string strSQL = @"select /*+all_rows*/ a.sid_int,
       a.treatdate_dat,
       a.serno_chr,
       a.patientid_chr,
       e.lastname_vchr,
       f.patientcardid_chr,
       a.medstoreid_chr,
       b.outpatrecipeid_chr,
       c.diagdr_chr,
       h.lastname_vchr as doctorname,
       n.invoiceno_vchr,
       n.invdate_dat,
       n.totalsum_mny,
       c.pstauts_int,
       g.lastname_vchr as dosageempname,
       g.empno_chr as dosageempno,
       d.lastname_vchr as sendempname,
       d.empno_chr as sendempno,
       o.windowname_vchr as treatwinname,
       p.windowname_vchr as sendwinname
  from t_opr_recipesend          a,
       t_opr_recipesendentry     b,
       t_opr_outpatientrecipe    c,
       t_bse_patient             e,
       t_bse_patientcard         f,
       t_bse_employee            h,
       t_opr_reciperelation      k,
       t_opr_charge              l,
       t_opr_chargedefinv        m,
       t_opr_outpatientrecipeinv n,
       t_bse_employee            g,
       t_bse_employee            d,
       t_bse_medstorewin         o,
       t_bse_medstorewin         p
 where a.sid_int = b.sid_int
   and b.outpatrecipeid_chr = c.outpatrecipeid_chr
   and c.outpatrecipeid_chr = k.outpatrecipeid_chr
   and k.chargeno_chr = l.chargeno_chr
   and l.chargeno_chr = m.chargeno_chr
   and m.invoiceno_vchr = n.invoiceno_vchr
   and l.status_int = 1
   and n.status_int = 1
   and a.medstoreid_chr = ?
   and a.patientid_chr = e.patientid_chr(+)
   and a.patientid_chr = f.patientid_chr(+)
   and c.diagdr_chr = h.empid_chr(+)
   and a.treatemp_chr = g.empid_chr(+)
   and a.sendemp_chr = d.empid_chr(+)
   and a.treatdate_dat >= ?
   and a.treatdate_dat <= ?
   and a.windowid_chr = o.windowid_chr(+)
   and a.sendwindowid_chr = p.windowid_chr(+)
   and a.partreturnflag_int=0
   and l.type_int=1";

                try
                {
                    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                    System.Data.IDataParameter[] m_objDataParam = null;
                    objHRPSvc.CreateDatabaseParameter(3, out m_objDataParam);
                    m_objDataParam[0].Value = strMedStoreid.Trim();
                    m_objDataParam[1].Value = Convert.ToDateTime(strBeginDate);
                    m_objDataParam[1].DbType = DbType.DateTime;
                    m_objDataParam[2].Value = Convert.ToDateTime(strEndDate);
                    m_objDataParam[2].DbType = DbType.DateTime;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref m_objTable, m_objDataParam);

                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            else
            {
                string strSQL = @"select /*+all_rows*/ a.sid_int,a.senddate_dat,
                a.serno_chr,
                a.patientid_chr,
                e.lastname_vchr,
                f.patientcardid_chr,
                a.medstoreid_chr,
                b.outpatrecipeid_chr,
                c.diagdr_chr,
                h.lastname_vchr as doctorname,
                n.invoiceno_vchr,
                n.invdate_dat,
                n.totalsum_mny,
                c.pstauts_int,
                g.lastname_vchr as dosageempname,
                g.empno_chr as dosageempno,
                d.lastname_vchr as sendempname,
                d.empno_chr as sendempno,
                o.windowname_vchr as treatwinname,
                p.windowname_vchr as sendwinname
  from t_opr_recipesend          a,
       t_opr_recipesendentry     b,
       t_opr_outpatientrecipe    c,
       t_bse_patient             e,
       t_bse_patientcard         f,
       t_bse_employee            h,
       t_opr_reciperelation      k,
       t_opr_charge              l,
       t_opr_chargedefinv        m,
       t_opr_outpatientrecipeinv n,
       t_bse_employee            g,
       t_bse_employee            d,
       t_bse_medstorewin         o,
       t_bse_medstorewin         p
 where a.sid_int = b.sid_int
   and b.outpatrecipeid_chr = c.outpatrecipeid_chr
   and c.outpatrecipeid_chr = k.outpatrecipeid_chr
   and k.chargeno_chr = l.chargeno_chr
   and l.chargeno_chr = m.chargeno_chr
   and m.invoiceno_vchr = n.invoiceno_vchr
   and l.status_int = 1
   and n.status_int = 1 
   and a.medstoreid_chr = ?
   and a.patientid_chr = e.patientid_chr(+)
   and a.patientid_chr = f.patientid_chr(+)
   and c.diagdr_chr = h.empid_chr(+)
   and a.treatemp_chr = g.empid_chr(+)
   and a.sendemp_chr = d.empid_chr(+)
   and a.senddate_dat >= ?
   and a.senddate_dat <= ?
   and a.windowid_chr = o.windowid_chr(+)
   and a.sendwindowid_chr = p.windowid_chr(+)
   and a.partreturnflag_int=0
   and l.type_int=1";

                try
                {
                    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                    System.Data.IDataParameter[] m_objDataParam = null;
                    objHRPSvc.CreateDatabaseParameter(3, out m_objDataParam);
                    m_objDataParam[0].Value = strMedStoreid.Trim();
                    m_objDataParam[1].Value = Convert.ToDateTime(strBeginDate);
                    m_objDataParam[1].DbType = DbType.DateTime;
                    m_objDataParam[2].Value = Convert.ToDateTime(strEndDate);
                    m_objDataParam[2].DbType = DbType.DateTime;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref m_objTable, m_objDataParam);

                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            return lngRes;

        }
        #endregion
        #region 根据药房id及创建日期取未配药信息
        /// <summary>
        /// 根据药房id及创建日期取未配药信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="strMedStoreid"></param>
        /// <param name="strBeginDate"></param>
        /// <param name="strEndDate"></param>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetQueryUnDosageRecipeInfo(System.Security.Principal.IPrincipal p_objPrincipal, string strMedStoreid, string strBeginDate, string strEndDate, out DataTable m_objTable)
        {
            long lngRes = 0;
            m_objTable = new DataTable();
            //权限类
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc", "m_lngGetQueryUnDosageRecipeInfo");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = @"select distinct a.sid_int,
                a.serno_chr,
                a.patientid_chr,
                e.lastname_vchr,
                f.patientcardid_chr,
                a.medstoreid_chr,
                b.outpatrecipeid_chr,
                c.diagdr_chr,
                h.lastname_vchr as doctorname,
                n.invoiceno_vchr,
                n.invdate_dat,
                n.totalsum_mny,
                c.pstauts_int
  from t_opr_recipesend          a,
       t_opr_recipesendentry     b,
       t_opr_outpatientrecipe    c,
       t_bse_patient             e,
       t_bse_patientcard         f,
       t_bse_employee            h,
       t_opr_reciperelation      k,
       t_opr_charge              l,
       t_opr_chargedefinv        m,
       t_opr_outpatientrecipeinv n
 where a.sid_int = b.sid_int
   and b.outpatrecipeid_chr = c.outpatrecipeid_chr
   and c.outpatrecipeid_chr = k.outpatrecipeid_chr
   and k.chargeno_chr = l.chargeno_chr
   and l.chargeno_chr = m.chargeno_chr
   and m.invoiceno_vchr = n.invoiceno_vchr
   and l.status_int = 1
   and n.status_int = 1 
   and a.pstatus_int = 1
   and a.medstoreid_chr = ?
   and a.patientid_chr = e.patientid_chr(+)
   and a.patientid_chr = f.patientid_chr(+)
   and c.diagdr_chr = h.empid_chr(+)
   and a.createdate_chr >= ?
   and a.createdate_chr <= ?";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] m_objDataParam = null;
                objHRPSvc.CreateDatabaseParameter(3, out m_objDataParam);
                m_objDataParam[0].Value = strMedStoreid.Trim();
                m_objDataParam[1].Value = strBeginDate;
                m_objDataParam[2].Value = strEndDate;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref m_objTable, m_objDataParam);

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
        #region 根据处方id和药房id获取为配药处方明细
        /// <summary>
        /// 根据处方id和药房id获取为配药处方明细
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strOPRecipeid"></param>
        /// <param name="m_strMedStoreid"></param>
        /// <param name="p_dtItemDe"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetUnDosageRecipeDetailByid(System.Security.Principal.IPrincipal p_objPrincipal, string m_strOPRecipeid, string m_strMedStoreid, out DataTable p_dtItemDe)
        {
            long lngRes = 0;
            p_dtItemDe = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc", "m_lngGetUnDosageRecipeDetailByid");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = string.Empty;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                DataTable p_dtTemp = new DataTable();
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                strSQL = @"select b.itemcode_vchr,
       a.itemname_vchr,
       a.itemspec_vchr,
       a.tolqty_dec as qty_dec,
       a.unitid_chr,
       a.unitprice_mny as price_mny,
       a.itemid_chr,
       a.tolprice_mny
  from t_opr_recipesend            m,
       t_opr_recipesendentry       n,
       t_opr_outpatientpwmrecipede a,
       t_bse_chargeitem            b
 where m.sid_int = n.sid_int
   and n.outpatrecipeid_chr = a.outpatrecipeid_chr
   and a.itemid_chr = b.itemid_chr
   and a.deptmed_int = 0
   and n.outpatrecipeid_chr = ?
   and a.medstoreid_chr = ?
   and m.medstoreid_chr = ?
 order by a.billrowno_int, a.itemname_vchr";

                objHRPSvc.CreateDatabaseParameter(3, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = m_strOPRecipeid.Trim();
                objLisAddItemRefArr[1].Value = m_strMedStoreid.Trim();
                objLisAddItemRefArr[2].Value = m_strMedStoreid.Trim();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtTemp, objLisAddItemRefArr);
                object[] m_objItemArr;
                p_dtItemDe = p_dtTemp.Clone();
                DataRow m_objTempDr;
                if (lngRes > 0)
                {
                    for (int i = 0; i < p_dtTemp.Rows.Count; i++)
                    {
                        m_objItemArr = p_dtTemp.Rows[i].ItemArray;
                        m_objTempDr = p_dtItemDe.NewRow();
                        m_objTempDr.ItemArray = m_objItemArr;
                        p_dtItemDe.Rows.Add(m_objTempDr);
                    }
                }
                strSQL = @" select b.itemcode_vchr,
       a.itemname_vchr,
       a.itemspec_vchr,
       (a.qty_dec * a.times_int) as qty_dec,
       a.unitid_chr,
       a.unitprice_mny as price_mny,
       a.itemid_chr,
       a.tolprice_mny
  from t_opr_recipesend            m,
       t_opr_recipesendentry       n,
       t_opr_outpatientcmrecipede a,
       t_bse_chargeitem            b
 where m.sid_int = n.sid_int
   and n.outpatrecipeid_chr = a.outpatrecipeid_chr
   and a.itemid_chr = b.itemid_chr
   and a.deptmed_int = 0
   and n.outpatrecipeid_chr = ?
   and a.medstoreid_chr = ?
   and m.medstoreid_chr = ?
 order by a.billrowno_int, a.itemname_vchr";
                p_dtTemp.Rows.Clear();
                objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(3, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = m_strOPRecipeid.Trim();
                objLisAddItemRefArr[1].Value = m_strMedStoreid.Trim();
                objLisAddItemRefArr[2].Value = m_strMedStoreid.Trim();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtTemp, objLisAddItemRefArr);
                if (lngRes > 0)
                {
                    for (int i = 0; i < p_dtTemp.Rows.Count; i++)
                    {
                        m_objItemArr = p_dtTemp.Rows[i].ItemArray;
                        m_objTempDr = p_dtItemDe.NewRow();
                        m_objTempDr.ItemArray = m_objItemArr;
                        p_dtItemDe.Rows.Add(m_objTempDr);
                    }
                }
                strSQL = @"select b.itemcode_vchr,
       a.itemname_vchr,
       a.itemspec_vchr,
       a.qty_dec as qty_dec,
       '' unitid_chr,
       a.unitprice_mny as price_mny,
       a.itemid_chr,
       a.tolprice_mny
  from t_opr_recipesend            m,
       t_opr_recipesendentry       n,
       t_opr_outpatientothrecipede a,
       t_bse_chargeitem            b
 where m.sid_int = n.sid_int
   and n.outpatrecipeid_chr = a.outpatrecipeid_chr
   and a.itemid_chr = b.itemid_chr
   and a.deptmed_int = 0
   and n.outpatrecipeid_chr = ?
   and a.medstoreid_chr = ?
   and m.medstoreid_chr = ?
 order by a.billrowno_int, a.itemname_vchr ";
                p_dtTemp.Rows.Clear();
                objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(3, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = m_strOPRecipeid.Trim();
                objLisAddItemRefArr[1].Value = m_strMedStoreid.Trim();
                objLisAddItemRefArr[2].Value = m_strMedStoreid.Trim();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtTemp, objLisAddItemRefArr);
                if (lngRes > 0)
                {
                    for (int i = 0; i < p_dtTemp.Rows.Count; i++)
                    {
                        m_objItemArr = p_dtTemp.Rows[i].ItemArray;
                        m_objTempDr = p_dtItemDe.NewRow();
                        m_objTempDr.ItemArray = m_objItemArr;
                        p_dtItemDe.Rows.Add(m_objTempDr);
                    }
                }
                strSQL = @"select b.itemcode_vchr,
       a.itemname_vchr,
       a.itemspec_vchr,
       a.qty_dec as qty_dec,
       '' unitid_chr,
       a.price_mny as price_mny,
       a.itemid_chr,
       a.tolprice_mny
  from t_opr_recipesend            m,
       t_opr_recipesendentry       n,
       t_opr_outpatientchkrecipede a,
       t_bse_chargeitem            b
 where m.sid_int = n.sid_int
   and n.outpatrecipeid_chr = a.outpatrecipeid_chr
   and a.itemid_chr = b.itemid_chr
   and a.deptmed_int = 0
   and n.outpatrecipeid_chr = ?
   and a.medstoreid_chr = ?
   and m.medstoreid_chr = ?
 order by a.billrowno_int, a.itemname_vchr";
                p_dtTemp.Rows.Clear();
                objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(3, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = m_strOPRecipeid.Trim();
                objLisAddItemRefArr[1].Value = m_strMedStoreid.Trim();
                objLisAddItemRefArr[2].Value = m_strMedStoreid.Trim();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtTemp, objLisAddItemRefArr);
                if (lngRes > 0)
                {
                    for (int i = 0; i < p_dtTemp.Rows.Count; i++)
                    {
                        m_objItemArr = p_dtTemp.Rows[i].ItemArray;
                        m_objTempDr = p_dtItemDe.NewRow();
                        m_objTempDr.ItemArray = m_objItemArr;
                        p_dtItemDe.Rows.Add(m_objTempDr);
                    }
                }
                strSQL = @" select b.itemcode_vchr,
       a.itemname_vchr,
       a.itemspec_vchr,
       a.qty_dec as qty_dec,
       '' unitid_chr,
       a.price_mny as price_mny,
       a.itemid_chr,
       a.tolprice_mny
  from t_opr_recipesend            m,
       t_opr_recipesendentry       n,
       t_opr_outpatienttestrecipede a,
       t_bse_chargeitem            b
 where m.sid_int = n.sid_int
   and n.outpatrecipeid_chr = a.outpatrecipeid_chr
   and a.itemid_chr = b.itemid_chr
   and a.deptmed_int = 0
   and n.outpatrecipeid_chr = ?
   and a.medstoreid_chr = ?
   and m.medstoreid_chr = ?
 order by a.billrowno_int, a.itemname_vchr
 ";
                p_dtTemp.Rows.Clear();
                objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(3, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = m_strOPRecipeid.Trim();
                objLisAddItemRefArr[1].Value = m_strMedStoreid.Trim();
                objLisAddItemRefArr[2].Value = m_strMedStoreid.Trim();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtTemp, objLisAddItemRefArr);
                if (lngRes > 0)
                {
                    for (int i = 0; i < p_dtTemp.Rows.Count; i++)
                    {
                        m_objItemArr = p_dtTemp.Rows[i].ItemArray;
                        m_objTempDr = p_dtItemDe.NewRow();
                        m_objTempDr.ItemArray = m_objItemArr;
                        p_dtItemDe.Rows.Add(m_objTempDr);
                    }
                }
                strSQL = @"select b.itemcode_vchr,
       a.itemname_vchr,
       a.itemspec_vchr,
       a.qty_dec as qty_dec,
       '' unitid_chr,
       a.price_mny as price_mny,
       a.itemid_chr,
       a.tolprice_mny
  from t_opr_recipesend            m,
       t_opr_recipesendentry       n,
       t_opr_outpatientopsrecipede a,
       t_bse_chargeitem            b
 where m.sid_int = n.sid_int
   and n.outpatrecipeid_chr = a.outpatrecipeid_chr
   and a.itemid_chr = b.itemid_chr
   and a.deptmed_int = 0
   and n.outpatrecipeid_chr = ?
   and a.medstoreid_chr = ?
   and m.medstoreid_chr = ?
 order by a.billrowno_int, a.itemname_vchr";
                p_dtTemp.Rows.Clear();
                objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(3, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = m_strOPRecipeid.Trim();
                objLisAddItemRefArr[1].Value = m_strMedStoreid.Trim();
                objLisAddItemRefArr[2].Value = m_strMedStoreid.Trim();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtTemp, objLisAddItemRefArr);
                if (lngRes > 0)
                {
                    for (int i = 0; i < p_dtTemp.Rows.Count; i++)
                    {
                        m_objItemArr = p_dtTemp.Rows[i].ItemArray;
                        m_objTempDr = p_dtItemDe.NewRow();
                        m_objTempDr.ItemArray = m_objItemArr;
                        p_dtItemDe.Rows.Add(m_objTempDr);
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
        #region 判断是否有足够的库存可以进行扣减
        /// <summary>
        /// 判断是否有足够的库存可以进行扣减
        /// </summary>
        /// <param name="m_strDrugStoreid"></param>
        /// <param name="m_dtPutMedDetail"></param>
        /// <param name="m_strMsg"></param>
        /// <param name="m_htReturn"></param>
        /// <returns></returns>
        [AutoComplete]
        public bool m_lngJudgeHasEnoughStorage(string m_strDrugStoreid, DataTable m_dtPutMedDetail, out string m_strMsg, out Hashtable m_htReturn)
        {
            //1.对摆药明细表按药品id进行分组，统计各个药品实际扣减库存数量；
            //2.判断是否有足够的库存可以进行扣减；
            long lngRes = 0;
            m_strMsg = string.Empty;
            DataTable dtTable = null;
            m_htReturn = new Hashtable();

            clsPutMedicineDetailGroup objVo;
            DataRow dr = null;
            for (int i = 0; i < m_dtPutMedDetail.Rows.Count; i++)
            {
                dr = m_dtPutMedDetail.Rows[i];
                if (m_htReturn.Contains(dr["medicineid_chr"]))
                {
                    objVo = m_htReturn[dr["medicineid_chr"]] as clsPutMedicineDetailGroup;
                    if (dr["opchargeflg_int"].ToString() == "0")
                    {
                        objVo.m_dblOPAmount += Convert.ToDouble(dr["qty_dec"]);
                        objVo.m_dblIPAmount += Convert.ToDouble(dr["qty_dec"]) * Convert.ToDouble(dr["packqty_dec"]);
                    }
                    else
                    {
                        objVo.m_dblOPAmount += Math.Round(Convert.ToDouble(dr["qty_dec"]) / Convert.ToDouble(dr["packqty_dec"]), 4);
                        objVo.m_dblIPAmount += Convert.ToDouble(dr["qty_dec"]);
                    }
                }
                else
                {
                    objVo = new clsPutMedicineDetailGroup();
                    objVo.m_listSubStorageDetail = new List<clsPutMedicineDetailGroup>();
                    objVo.m_strMedicineid_chr = dr["medicineid_chr"].ToString();
                    objVo.m_strMedicineName = dr["itemname_vchr"].ToString();
                    objVo.m_strDrugStoreid = m_strDrugStoreid;
                    objVo.m_dblPackage = Convert.ToDouble(dr["packqty_dec"]);

                    objVo.m_intIPChargeFlag = Convert.ToInt16(dr["opchargeflg_int"]);

                    if (dr["opchargeflg_int"].ToString() == "0")
                    {
                        objVo.m_dblOPAmount = Convert.ToDouble(dr["qty_dec"]);
                        objVo.m_dblIPAmount = Convert.ToDouble(dr["qty_dec"]) * Convert.ToDouble(dr["packqty_dec"]);
                    }
                    else
                    {
                        objVo.m_dblOPAmount = Math.Round(Convert.ToDouble(dr["qty_dec"]) / Convert.ToDouble(dr["packqty_dec"]), 4);
                        objVo.m_dblIPAmount = Convert.ToDouble(dr["qty_dec"]);
                    }
                    m_htReturn.Add(dr["medicineid_chr"], objVo);
                }
            }
            string strSQL = @"select a.seriesid_int, a.iprealgross_int, a.oprealgross_int
  from t_ds_storage_detail a
 where a.drugstoreid_chr = ?
   and a.medicineid_chr = ? and a.status = 1 and a.canprovide_int = 1 and a.ipavailablegross_num > 0 
 order by a.validperiod_dat, a.dsinstoragedate_dat";
            //try
            //{
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            System.Data.IDataParameter[] objLisAddItemRefArr = null;
            foreach (DictionaryEntry de in m_htReturn)
            {
                objVo = de.Value as clsPutMedicineDetailGroup;
                objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = objVo.m_strDrugStoreid;
                objLisAddItemRefArr[1].Value = objVo.m_strMedicineid_chr;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtTable, objLisAddItemRefArr);
                if (lngRes > 0 && dtTable != null && dtTable.Rows.Count > 0)
                {
                    for (int m_intRow = 0; m_intRow < dtTable.Rows.Count; m_intRow++)
                    {
                        if (Convert.ToDouble(dtTable.Rows[m_intRow]["iprealgross_int"]) < objVo.m_dblIPAmount)
                        {
                            if (m_intRow == dtTable.Rows.Count - 1)
                            {
                                m_strMsg = string.Format("药品({0})没有充足库存,不能进行配药！", objVo.m_strMedicineName);
                                return false;
                            }
                            objVo.m_dblIPAmount -= Convert.ToDouble(dtTable.Rows[m_intRow]["iprealgross_int"]);
                            clsPutMedicineDetailGroup objTempVo = new clsPutMedicineDetailGroup();
                            objTempVo.m_lngStorageSerial = Convert.ToInt64(dtTable.Rows[m_intRow]["seriesid_int"]);
                            objTempVo.m_dblIPAmount = Convert.ToDouble(dtTable.Rows[m_intRow]["iprealgross_int"]);
                            objTempVo.m_dblOPAmount = Math.Round(objTempVo.m_dblIPAmount / objVo.m_dblPackage, 4);
                            objTempVo.m_strMedicineid_chr = objVo.m_strMedicineid_chr;
                            objTempVo.m_strDrugStoreid = objVo.m_strDrugStoreid;
                            objTempVo.m_intIPChargeFlag = objVo.m_intIPChargeFlag;
                            objVo.m_listSubStorageDetail.Add(objTempVo);

                        }
                        else
                        {
                            clsPutMedicineDetailGroup objTempVo = new clsPutMedicineDetailGroup();
                            objTempVo.m_lngStorageSerial = Convert.ToInt64(dtTable.Rows[m_intRow]["seriesid_int"]);
                            objTempVo.m_dblIPAmount = Convert.ToDouble(objVo.m_dblIPAmount);
                            objTempVo.m_dblOPAmount = Math.Round(objVo.m_dblIPAmount / objVo.m_dblPackage, 4);
                            objTempVo.m_strMedicineid_chr = objVo.m_strMedicineid_chr;
                            objTempVo.m_strDrugStoreid = objVo.m_strDrugStoreid;
                            objTempVo.m_intIPChargeFlag = objVo.m_intIPChargeFlag;
                            objVo.m_listSubStorageDetail.Add(objTempVo);
                            break;
                        }
                    }
                }
                else
                {
                    if (dtTable == null || dtTable.Rows.Count == 0)
                    {
                        m_strMsg = string.Format("药品({0})不存在任何库存,不能进行配药！", objVo.m_strMedicineName);
                        return false;
                    }
                    else
                    {
                        m_strMsg = "获取药品库存数据错误！";
                        return false;
                    }
                }
            }

            //}
            //catch (Exception objEx)
            //{
            //    string strTmp = objEx.Message;
            //    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
            //    bool blnRes = objLogger.LogError(objEx);
            //}
            return true;

        }
        #endregion
        #region  获取退药信息
        /// <summary>
        /// 获取退药信息
        /// </summary>
        /// <param name="m_strOutPatientRecipe"></param>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        public long m_lngGetReturnDetailInfo(string m_strOutPatientRecipe, ref DataTable dtResult)
        {
            long lngRes = 0;

            string strSQL = @"select a.outpatrecipeid_chr,
       b.itemid_chr,
       b.itemname_vchr,
       b.orgamout_dec,
       b.retamout_dec,
       b.price_dec,
       b.billrowno_int,
       b.unitid_chr as returnmedunit,
       b.unitid_chr as sendmedunit,
       c.itemcode_vchr,
       c.itemspec_vchr,
       b.medseriesid_int,
       b.opamount_dec,
       b.ipamount_dec,
       c.itemsrcid_vchr,
       a.drugstoreid_chr
  from t_opr_returnmed a, t_opr_returnmed_entry b, t_bse_chargeitem c
 where a.outpatrecipeid_chr = b.outpatrecipeid_chr
   and a.outpatrecipeid_chr = ?
   and b.itemid_chr = c.itemid_chr(+)
 order by b.billrowno_int";
            try
            {
                HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = m_strOutPatientRecipe;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, objLisAddItemRefArr);
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
        #region  获取药房信息
        /// <summary>
        /// 获取药房信息
        /// </summary>
        /// <param name="m_strMedStoreid"></param>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        public long m_lngGetMedStoreInfo(string m_strMedStoreid, ref DataTable dtResult)
        {
            long lngRes = 0;

            string strSQL = @"select a.medstoreid_chr,a.medstorename_vchr,a.deptid_chr from t_bse_medstore a where a.medstoreid_chr=?";
            try
            {
                HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = m_strMedStoreid;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, objLisAddItemRefArr);
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
        #region 根据药房id及创建日期获取发药及退药信息
        /// <summary>
        /// 根据药房id及创建日期获取发药及退药信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="strMedStoreid"></param>
        /// <param name="strCreateDate"></param>
        /// <param name="m_intDeductFlow">扣减库存流程</param>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetReturnMedicine(System.Security.Principal.IPrincipal p_objPrincipal, string strMedStoreid, string strCreateDate, int m_intDeductFlow, out DataTable m_objTable)
        {
            long lngRes = 0;
            m_objTable = new DataTable();
            //权限类
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc", "m_lngGetReturnMedicine");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }

            string strFlow = string.Empty;
            if (m_intDeductFlow == 0)
            {
                strFlow = " (a.pstatus_int = 2 or a.pstatus_int = 3) ";
            }
            else
            {
                strFlow = " a.pstatus_int = 3 ";
            }

            string strSQL = @"select distinct a.sid_int,
                a.serno_chr,
                a.patientid_chr,
                e.lastname_vchr,
                f.patientcardid_chr,
                a.medstoreid_chr,
                a.sendemp_chr,
                g.lastname_vchr as sendmedname,
                a.senddate_dat,
                b.outpatrecipeid_chr,
                c.diagdr_chr,
                h.lastname_vchr as doctorname,
                d.outpatrecipeid_chr as returnmedrecipeno,
                d.operemp_chr,
                i.lastname_vchr as operempname,
                d.confirmemp_chr,
                j.lastname_vchr as confirmname,
                d.status_int,
                d.flag_int,
                n.invoiceno_vchr,
                n.invdate_dat,
                p.paytypename_vchr,
                p.internalflag_int,
                n.totalsum_mny,
                c.pstauts_int
  from t_opr_recipesend          a,
       t_opr_recipesendentry     b,
       t_opr_outpatientrecipe    c,
       t_opr_returnmed           d,
       t_bse_patient             e,
       t_bse_patientcard         f,
       t_bse_employee            g,
       t_bse_employee            h,
       t_bse_employee            i,
       t_bse_employee            j,
       t_opr_outpatientrecipeinv n,
       t_bse_patientpaytype      p
 where a.sid_int = b.sid_int
   and b.outpatrecipeid_chr = c.outpatrecipeid_chr
   and c.outpatrecipeid_chr = d.outpatrecipeid_chr(+)
   and c.outpatrecipeid_chr = n.outpatrecipeid_chr
   and (n.status_int = 1 or n.status_int = 3)
   and " + strFlow + @"
   and a.medstoreid_chr = ?
   and a.patientid_chr = e.patientid_chr(+)
   and e.paytypeid_chr = p.paytypeid_chr(+)
   and a.patientid_chr = f.patientid_chr(+)
   and a.sendemp_chr = g.empid_chr(+)
   and c.diagdr_chr = h.empid_chr(+)
   and a.createdate_chr = ?
   and d.operemp_chr = i.empid_chr(+)
   and d.confirmemp_chr = j.empid_chr(+)";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] m_objDataParam = null;
                objHRPSvc.CreateDatabaseParameter(2, out m_objDataParam);
                m_objDataParam[0].Value = strMedStoreid.Trim();
                m_objDataParam[1].Value = strCreateDate.Trim();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref m_objTable, m_objDataParam);

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
        #region 根据药房id及创建日期获取发药及退药信息
        /// <summary>
        /// 根据药房id及创建日期获取发药及退药信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="strMedStoreid"></param>
        /// <param name="strCreateDate"></param>
        /// <param name="m_intDeductFlow">扣减库存流程</param>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetReturnMedicine(System.Security.Principal.IPrincipal p_objPrincipal, string strMedStoreid, string strBeginDate, string strEndDate, int m_intDeductFlow, out DataTable m_objTable)
        {
            long lngRes = 0;
            m_objTable = new DataTable();
            //权限类
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc", "m_lngGetReturnMedicine");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }

            string strFlow = string.Empty;
            if (m_intDeductFlow == 0)
            {
                strFlow = " (a.pstatus_int = 2 or a.pstatus_int = 3) ";
            }
            else
            {
                strFlow = " a.pstatus_int = 3 ";
            }

            string strSQL = @"select distinct a.sid_int,
                a.serno_chr,
                a.patientid_chr,
                e.lastname_vchr,
                f.patientcardid_chr,
                a.medstoreid_chr,
                a.sendemp_chr,
                g.lastname_vchr as sendmedname,
                a.senddate_dat,
                b.outpatrecipeid_chr,
                c.diagdr_chr,
                h.lastname_vchr as doctorname,
                d.outpatrecipeid_chr as returnmedrecipeno,
                d.operemp_chr,
                i.lastname_vchr as operempname,
                d.confirmemp_chr,
                j.lastname_vchr as confirmname,
                d.status_int,
                d.flag_int,
                n.invoiceno_vchr,
                n.invdate_dat,
                p.paytypename_vchr,
                p.internalflag_int,
                n.totalsum_mny,
                c.pstauts_int
  from t_opr_recipesend          a,
       t_opr_recipesendentry     b,
       t_opr_outpatientrecipe    c,
       t_opr_returnmed           d,
       t_bse_patient             e,
       t_bse_patientcard         f,
       t_bse_employee            g,
       t_bse_employee            h,
       t_bse_employee            i,
       t_bse_employee            j,
       t_opr_outpatientrecipeinv n,
       t_bse_patientpaytype      p
 where a.sid_int = b.sid_int
   and b.outpatrecipeid_chr = c.outpatrecipeid_chr
   and c.outpatrecipeid_chr = d.outpatrecipeid_chr(+)
   and c.outpatrecipeid_chr = n.outpatrecipeid_chr
   and (n.status_int = 1 or n.status_int = 3)
   and " + strFlow + @"
   and a.medstoreid_chr = ?
   and a.patientid_chr = e.patientid_chr(+)
   and e.paytypeid_chr = p.paytypeid_chr(+)
   and a.patientid_chr = f.patientid_chr(+)
   and a.sendemp_chr = g.empid_chr(+)
   and c.diagdr_chr = h.empid_chr(+)
   and a.createdate_chr >= ?
   and a.createdate_chr <= ?
   and d.operemp_chr = i.empid_chr(+)
   and d.confirmemp_chr = j.empid_chr(+)";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] m_objDataParam = null;
                objHRPSvc.CreateDatabaseParameter(3, out m_objDataParam);
                m_objDataParam[0].Value = strMedStoreid.Trim();
                m_objDataParam[1].Value = strBeginDate;
                m_objDataParam[2].Value = strEndDate;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref m_objTable, m_objDataParam);

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
        #region 根据处方id和药房id获取已发药处方明细
        /// <summary>
        /// 根据处方id和药房id获取已发药处方明细
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strOPRecipeid"></param>
        /// <param name="m_strMedStoreid"></param>
        /// <param name="p_dtItemDe"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetSendMedRecipeDetailByid(System.Security.Principal.IPrincipal p_objPrincipal, string m_strOPRecipeid, string m_strMedStoreid, out DataTable p_dtItemDe)
        {
            long lngRes = 0;
            p_dtItemDe = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc", "m_lngGetSendMedRecipeDetailByid");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = string.Empty;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                DataTable p_dtTemp = new DataTable();
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                strSQL = @"select 'True' checked,
       b.itemcode_vchr,
       a.itemname_vchr,
       a.itemspec_vchr,
       a.tolqty_dec as qty_dec,
       a.unitid_chr,
       a.tolqty_dec as returnqty_dec,
       a.unitid_chr as returnmedunit,
       a.unitprice_mny as price_mny,
       a.itemid_chr,
       a.tolprice_mny,
       a.rowno_chr as billrowno_int,
       c.drugstoreid_chr,
       c.medseriesid_int,
       c.chargetype_int,
       b.packqty_dec,
       0 unitscale_dec,
       0 times_int,
       m.medstoreid_chr,
       a.outpatrecipeid_chr,
       a.rowno_chr,
       b.itemsrcid_vchr,
       b.itemipunit_chr,c.ipamount_dec,c.opamount_dec
  from t_opr_recipesend            m,
       t_opr_recipesendentry       n,
       t_opr_outpatientpwmrecipede a,
       t_bse_chargeitem            b,
       t_opr_recipededuct          c
 where m.sid_int = n.sid_int
   and n.outpatrecipeid_chr = a.outpatrecipeid_chr
   and a.itemid_chr = b.itemid_chr
   and a.deptmed_int = 0
   and n.outpatrecipeid_chr = ? 
   and m.medstoreid_chr =?
   and n.outpatrecipeid_chr=c.outpatrecipeid_chr
   and b.itemsrcid_vchr=c.medicineid_chr
   --and a.rowno_vchr2=c.rowno_vchr
 order by --a.billrowno_int, 
 a.itemname_vchr,c.medseriesid_int desc";

                objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = m_strOPRecipeid.Trim();
                objLisAddItemRefArr[1].Value = m_strMedStoreid.Trim();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtTemp, objLisAddItemRefArr);
                object[] m_objItemArr;
                p_dtItemDe = p_dtTemp.Clone();
                DataRow m_objTempDr;
                if (lngRes > 0)
                {
                    for (int i = 0; i < p_dtTemp.Rows.Count; i++)
                    {
                        m_objItemArr = p_dtTemp.Rows[i].ItemArray;
                        m_objTempDr = p_dtItemDe.NewRow();
                        m_objTempDr.ItemArray = m_objItemArr;
                        p_dtItemDe.Rows.Add(m_objTempDr);
                    }
                }
                strSQL = @"select 'True' checked,
       b.itemcode_vchr,
       a.itemname_vchr,
       a.itemspec_vchr,
       (a.qty_dec * a.times_int) as qty_dec,
       a.unitid_chr,
       (a.qty_dec * a.times_int) as returnqty_dec,
       a.unitid_chr as returnmedunit,
       a.unitprice_mny as price_mny,
       a.itemid_chr,
       a.tolprice_mny,
       a.rowno_chr as billrowno_int,
       c.drugstoreid_chr,
       c.medseriesid_int,
       c.chargetype_int,
       b.packqty_dec,
       0 unitscale_dec,
       a.times_int,
       m.medstoreid_chr,
       a.outpatrecipeid_chr,
       a.rowno_chr,
       b.itemsrcid_vchr,
       b.itemipunit_chr,c.ipamount_dec,c.opamount_dec
  from t_opr_recipesend            m,
       t_opr_recipesendentry       n,
       t_opr_outpatientcmrecipede a,
       t_bse_chargeitem            b,
       t_opr_recipededuct          c
 where m.sid_int = n.sid_int
   and n.outpatrecipeid_chr = a.outpatrecipeid_chr
   and a.itemid_chr = b.itemid_chr
   and a.deptmed_int = 0
   and n.outpatrecipeid_chr = ? 
   and m.medstoreid_chr =?
   and n.outpatrecipeid_chr=c.outpatrecipeid_chr
   and b.itemsrcid_vchr=c.medicineid_chr
   --and a.rowno_vchr2=c.rowno_vchr
 order by --a.billrowno_int, 
 a.itemname_vchr,c.medseriesid_int desc";
                p_dtTemp.Rows.Clear();
                objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = m_strOPRecipeid.Trim();
                objLisAddItemRefArr[1].Value = m_strMedStoreid.Trim();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtTemp, objLisAddItemRefArr);
                if (lngRes > 0)
                {
                    for (int i = 0; i < p_dtTemp.Rows.Count; i++)
                    {
                        m_objItemArr = p_dtTemp.Rows[i].ItemArray;
                        m_objTempDr = p_dtItemDe.NewRow();
                        m_objTempDr.ItemArray = m_objItemArr;
                        p_dtItemDe.Rows.Add(m_objTempDr);
                    }
                }
                strSQL = @" select 'True' checked,
       b.itemcode_vchr,
       a.itemname_vchr,
       a.itemspec_vchr,
       a.qty_dec as qty_dec,
       '' unitid_chr,
       a.qty_dec as returnqty_dec,
       '' returnmedunit,
       a.unitprice_mny as price_mny,
       a.itemid_chr,
       a.tolprice_mny,
       1 billrowno_int,
       c.drugstoreid_chr,
       c.medseriesid_int,
       c.chargetype_int,
       b.packqty_dec,
       0 unitscale_dec,
       0 times_int,
       m.medstoreid_chr,
       a.outpatrecipeid_chr,
       a.rowno_chr,
       b.itemsrcid_vchr,
       b.itemipunit_chr,c.ipamount_dec,c.opamount_dec
  from t_opr_recipesend            m,
       t_opr_recipesendentry       n,
       t_opr_outpatientothrecipede a,
       t_bse_chargeitem            b,
       t_opr_recipededuct          c
 where m.sid_int = n.sid_int
   and n.outpatrecipeid_chr = a.outpatrecipeid_chr
   and a.itemid_chr = b.itemid_chr
   and a.deptmed_int = 0
   and n.outpatrecipeid_chr = ? 
   and m.medstoreid_chr =?
   and n.outpatrecipeid_chr=c.outpatrecipeid_chr
   and b.itemsrcid_vchr=c.medicineid_chr
   --and a.rowno_chr=c.rowno_vchr
 order by --a.billrowno_int, 
 a.itemname_vchr,c.medseriesid_int desc";
                p_dtTemp.Rows.Clear();
                objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = m_strOPRecipeid.Trim();
                objLisAddItemRefArr[1].Value = m_strMedStoreid.Trim();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtTemp, objLisAddItemRefArr);
                if (lngRes > 0)
                {
                    for (int i = 0; i < p_dtTemp.Rows.Count; i++)
                    {
                        m_objItemArr = p_dtTemp.Rows[i].ItemArray;
                        m_objTempDr = p_dtItemDe.NewRow();
                        m_objTempDr.ItemArray = m_objItemArr;
                        p_dtItemDe.Rows.Add(m_objTempDr);
                    }
                }
                strSQL = @"select 'True' checked,
       b.itemcode_vchr,
       a.itemname_vchr,
       a.itemspec_vchr,
       a.qty_dec as qty_dec,
       '' unitid_chr,
       a.qty_dec as returnqty_dec,
       '' returnmedunit,
       a.price_mny as price_mny,
       a.itemid_chr,
       a.tolprice_mny,
       1 billrowno_int,
       c.drugstoreid_chr,
       c.medseriesid_int,
       c.chargetype_int,
       b.packqty_dec,
       0 unitscale_dec,
       0 times_int,
       m.medstoreid_chr,
       a.outpatrecipeid_chr,
       a.rowno_chr,
       b.itemsrcid_vchr,
       b.itemipunit_chr,c.ipamount_dec,c.opamount_dec
  from t_opr_recipesend            m,
       t_opr_recipesendentry       n,
       t_opr_outpatientchkrecipede a,
       t_bse_chargeitem            b,
       t_opr_recipededuct          c
 where m.sid_int = n.sid_int
   and n.outpatrecipeid_chr = a.outpatrecipeid_chr
   and a.itemid_chr = b.itemid_chr
   and a.deptmed_int = 0
   and n.outpatrecipeid_chr = ? 
   and m.medstoreid_chr =?
   and n.outpatrecipeid_chr=c.outpatrecipeid_chr
   and b.itemsrcid_vchr=c.medicineid_chr
   --and a.rowno_chr=c.rowno_vchr
 order by --a.billrowno_int, 
 a.itemname_vchr,c.medseriesid_int desc";
                p_dtTemp.Rows.Clear();
                objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = m_strOPRecipeid.Trim();
                objLisAddItemRefArr[1].Value = m_strMedStoreid.Trim();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtTemp, objLisAddItemRefArr);
                if (lngRes > 0)
                {
                    for (int i = 0; i < p_dtTemp.Rows.Count; i++)
                    {
                        m_objItemArr = p_dtTemp.Rows[i].ItemArray;
                        m_objTempDr = p_dtItemDe.NewRow();
                        m_objTempDr.ItemArray = m_objItemArr;
                        p_dtItemDe.Rows.Add(m_objTempDr);
                    }
                }
                strSQL = @" select 'True' checked,
       b.itemcode_vchr,
       a.itemname_vchr,
       a.itemspec_vchr,
       a.qty_dec as qty_dec,
       '' unitid_chr,
       a.qty_dec as returnqty_dec,
       '' returnmedunit,
       a.price_mny as price_mny,
       a.itemid_chr,
       a.tolprice_mny,
       1 billrowno_int,
       c.drugstoreid_chr,
       c.medseriesid_int,
       c.chargetype_int,
       b.packqty_dec,
       0 unitscale_dec,
       0 times_int,
       m.medstoreid_chr,
       a.outpatrecipeid_chr,
       a.rowno_chr,
       b.itemsrcid_vchr,
       b.itemipunit_chr,c.ipamount_dec,c.opamount_dec
  from t_opr_recipesend            m,
       t_opr_recipesendentry       n,
       t_opr_outpatienttestrecipede a,
       t_bse_chargeitem            b,
       t_opr_recipededuct          c
 where m.sid_int = n.sid_int
   and n.outpatrecipeid_chr = a.outpatrecipeid_chr
   and a.itemid_chr = b.itemid_chr
   and a.deptmed_int = 0
   and n.outpatrecipeid_chr = ? 
   and m.medstoreid_chr =?
   and n.outpatrecipeid_chr=c.outpatrecipeid_chr
   and b.itemsrcid_vchr=c.medicineid_chr
   --and a.rowno_chr=c.rowno_vchr
 order by --a.billrowno_int, 
 a.itemname_vchr,c.medseriesid_int desc ";
                p_dtTemp.Rows.Clear();
                objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = m_strOPRecipeid.Trim();
                objLisAddItemRefArr[1].Value = m_strMedStoreid.Trim();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtTemp, objLisAddItemRefArr);
                if (lngRes > 0)
                {
                    for (int i = 0; i < p_dtTemp.Rows.Count; i++)
                    {
                        m_objItemArr = p_dtTemp.Rows[i].ItemArray;
                        m_objTempDr = p_dtItemDe.NewRow();
                        m_objTempDr.ItemArray = m_objItemArr;
                        p_dtItemDe.Rows.Add(m_objTempDr);
                    }
                }
                strSQL = @"select 'True' checked,
       b.itemcode_vchr,
       a.itemname_vchr,
       a.itemspec_vchr,
       a.qty_dec as qty_dec,
       '' unitid_chr,
       a.qty_dec as returnqty_dec,
       '' returnmedunit,
       a.price_mny as price_mny,
       a.itemid_chr,
       a.tolprice_mny,
       1 billrowno_int,
       c.drugstoreid_chr,
       c.medseriesid_int,
       c.chargetype_int,
       b.packqty_dec,
       0 unitscale_dec,
       0 times_int,
       m.medstoreid_chr,
       a.outpatrecipeid_chr,
       a.rowno_chr,
       b.itemsrcid_vchr,
       b.itemipunit_chr,c.ipamount_dec,c.opamount_dec
  from t_opr_recipesend            m,
       t_opr_recipesendentry       n,
       t_opr_outpatientopsrecipede a,
       t_bse_chargeitem            b,
       t_opr_recipededuct          c
 where m.sid_int = n.sid_int
   and n.outpatrecipeid_chr = a.outpatrecipeid_chr
   and a.itemid_chr = b.itemid_chr
   and a.deptmed_int = 0
   and n.outpatrecipeid_chr = ? 
   and m.medstoreid_chr =?
   and n.outpatrecipeid_chr=c.outpatrecipeid_chr
   and b.itemsrcid_vchr=c.medicineid_chr
   --and a.rowno_chr=c.rowno_vchr
 order by --a.billrowno_int, 
 a.itemname_vchr,c.medseriesid_int desc";
                p_dtTemp.Rows.Clear();
                objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = m_strOPRecipeid.Trim();
                objLisAddItemRefArr[1].Value = m_strMedStoreid.Trim();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtTemp, objLisAddItemRefArr);
                if (lngRes > 0)
                {
                    for (int i = 0; i < p_dtTemp.Rows.Count; i++)
                    {
                        m_objItemArr = p_dtTemp.Rows[i].ItemArray;
                        m_objTempDr = p_dtItemDe.NewRow();
                        m_objTempDr.ItemArray = m_objItemArr;
                        p_dtItemDe.Rows.Add(m_objTempDr);
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
        #region 判断是否存在该员工
        /// <summary>
        /// 判断是否存在该员工
        /// </summary>
        /// <param name="m_strEmpNO"></param>
        /// <param name="m_strPwd"></param>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        public long m_lngGetEmpInfo(string m_strEmpNO, string m_strPwd, ref DataTable dtResult)
        {
            long lngRes = 0;

            string strSQL = @" select e.empid_chr from t_bse_employee e  where e.empno_chr=? and trim(e.psw_chr)=?";
            if (m_strPwd.Trim() != string.Empty)
            {
                try
                {
                    clsSymmetricAlgorithm objAlgorithm = new clsSymmetricAlgorithm();
                    m_strPwd = objAlgorithm.m_strEncrypt(m_strPwd.Trim(), clsSymmetricAlgorithm.enmSymmetricAlgorithmType.DES).Trim();
                    HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                    System.Data.IDataParameter[] objLisAddItemRefArr = null;
                    objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                    objLisAddItemRefArr[0].Value = m_strEmpNO;
                    objLisAddItemRefArr[1].Value = m_strPwd;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, objLisAddItemRefArr);
                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            else
            {
                strSQL = @" select e.empid_chr from t_bse_employee e  where e.empno_chr=? and e.psw_chr is null ";
                try
                {
                    HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                    System.Data.IDataParameter[] objLisAddItemRefArr = null;
                    objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                    objLisAddItemRefArr[0].Value = m_strEmpNO;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, objLisAddItemRefArr);
                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            return lngRes;
        }
        #endregion
        #region 通过窗口ID、处方ID、处方类型取当前需要发药的处方明细
        /// <summary>
        /// 通过窗口ID、处方ID、处方类型取当前需要发药的处方明细
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_intsid"></param>
        /// <param name="p_strWinID"></param>
        /// <param name="p_dtItemDe"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOPRecipeListByWinAndOpRecAndType(System.Security.Principal.IPrincipal p_objPrincipal,
            int m_intsid, string p_strMedStoreid, out DataTable p_dtItemDe, int flag)
        {
            long lngRes = 0;
            p_dtItemDe = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsOPMedStoreSvc", "m_lngGetOPRecipeListByWinAndOpRecAndType");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = string.Empty;
            if (flag != 3)
            {
                try
                {
                    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                    DataTable p_dtTemp = new DataTable();
                    System.Data.IDataParameter[] objLisAddItemRefArr = null;
                    //a.itemname_vchr --> b.itemname_vchr && g. mednormalname_vchr -->  a.itemname_vchr as mednormalname_vchr
                    strSQL = @"select   a.outpatrecipeid_chr, a.dosageunit_chr, a.rowno_chr, a.itemid_chr,
         a.unitid_chr, a.tolqty_dec as qty_dec, a.unitprice_mny as price_mny,
         a.tolprice_mny, a.medstoreid_chr, a.usageid_chr, a.days_int,
         a.freqid_chr, a.desc_vchr, a.discount_dec, a.dosage_dec,
         a.itemspec_vchr, a.qty_dec as dosageqty, b.itemname_vchr,
         b.itemopinvtype_chr, b.itemcode_vchr, b.itemsrcid_vchr,
         b.itemsrcid_vchr as medicineid_chr, b.dosage_dec as basicdosage,
         b.itemipunit_chr, f.typename_vchr, d.putmed_int, d.opusagedesc,
         d.usagename_vchr, e.times_int as times_int1, e.days_int as days_int1,
         e.opfredesc_vchr as freqdesc, e.freqname_chr, 0 times_int,
         0 min_qty_dec1, 0 min_qty_dec, '' sumusage_vchr,
         't_opr_outpatientpwmrecipede' as fromtable, a.itemname_vchr as mednormalname_vchr,
         '' itemunit_vchr, g.medicinetypeid_chr,b.packqty_dec,b.opchargeflg_int
    from t_opr_recipesend m,
         t_opr_recipesendentry n,
         t_opr_outpatientpwmrecipede a,
         t_bse_chargeitem b,
         t_bse_chargeitemextype f,
         t_bse_usagetype d,
         t_aid_recipefreq e,
         t_bse_medicine g
   where m.sid_int = n.sid_int
     and n.outpatrecipeid_chr = a.outpatrecipeid_chr
     and a.itemid_chr = b.itemid_chr
     and a.deptmed_int = 0
     and m.sid_int = ?
     and a.medstoreid_chr = ?
     and b.itemopinvtype_chr = f.typeid_chr
     and f.flag_int = 2
     and a.usageid_chr = d.usageid_chr(+)
     and a.freqid_chr = e.freqid_chr(+)
     and b.itemsrcid_vchr = g.medicineid_chr(+)
order by a.billrowno_int, b.itemname_vchr";

                    objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                    objLisAddItemRefArr[0].Value = m_intsid;
                    objLisAddItemRefArr[1].Value = p_strMedStoreid;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtTemp, objLisAddItemRefArr);
                    object[] m_objItemArr;
                    p_dtItemDe = p_dtTemp.Clone();
                    DataRow m_objTempDr;
                    if (lngRes > 0)
                    {
                        for (int i = 0; i < p_dtTemp.Rows.Count; i++)
                        {
                            m_objItemArr = p_dtTemp.Rows[i].ItemArray;
                            m_objTempDr = p_dtItemDe.NewRow();
                            m_objTempDr.ItemArray = m_objItemArr;
                            p_dtItemDe.Rows.Add(m_objTempDr);
                        }
                    }
                    strSQL = @"select   a.outpatrecipeid_chr,b.dosageunit_chr,a.rowno_chr,a.itemid_chr,
         a.unitid_chr,(a.qty_dec * a.times_int) as qty_dec, a.unitprice_mny as price_mny,
          a.tolprice_mny,a.medstoreid_chr, '' usageid_chr,  0 as days_int,
          '' freqid_chr, usagedetail_vchr as desc_vchr, a.discount_dec, b.dosage_dec,
         a.itemspec_vchr,  0 as dosageqty, b.itemname_vchr,
         b.itemopinvtype_chr,b.itemcode_vchr,  b.itemsrcid_vchr,
         b.itemsrcid_vchr as medicineid_chr,  b.dosage_dec as basicdosage,
         b.itemipunit_chr,f.typename_vchr,d.putmed_int, d.opusagedesc,
         d.usagename_vchr, e.times_int as times_int1, e.days_int as days_int1,
         e.opfredesc_vchr as freqdesc,e.freqname_chr,a.times_int, 
         a.min_qty_dec as min_qty_dec1, a.min_qty_dec, a.sumusage_vchr,
          't_opr_outpatientcmrecipede' as fromtable, a.itemname_vchr as mednormalname_vchr,
         '' itemunit_vchr,g.medicinetypeid_chr,b.packqty_dec,b.opchargeflg_int
    from t_opr_recipesend m,
         t_opr_recipesendentry n,
         t_opr_outpatientcmrecipede a,
         t_bse_chargeitem b,
         t_bse_chargeitemextype f,
         t_bse_usagetype d,
         t_aid_recipefreq e,
         t_bse_medicine g
   where m.sid_int = n.sid_int
     and n.outpatrecipeid_chr = a.outpatrecipeid_chr
     and a.itemid_chr = b.itemid_chr
     and a.deptmed_int = 0
     and m.sid_int = ?
     and a.medstoreid_chr = ?
     and a.itemid_chr = e.freqid_chr(+)
     and b.itemopinvtype_chr = f.typeid_chr
     and f.flag_int = 2
     and a.usageid_chr = d.usageid_chr(+)
     and b.itemsrcid_vchr = g.medicineid_chr(+)
order by a.billrowno_int, b.itemname_vchr";
                    p_dtTemp.Rows.Clear();
                    objLisAddItemRefArr = null;
                    objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                    objLisAddItemRefArr[0].Value = m_intsid;
                    objLisAddItemRefArr[1].Value = p_strMedStoreid;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtTemp, objLisAddItemRefArr);
                    if (lngRes > 0)
                    {
                        for (int i = 0; i < p_dtTemp.Rows.Count; i++)
                        {
                            m_objItemArr = p_dtTemp.Rows[i].ItemArray;
                            m_objTempDr = p_dtItemDe.NewRow();
                            m_objTempDr.ItemArray = m_objItemArr;
                            p_dtItemDe.Rows.Add(m_objTempDr);
                        }
                    }
                    strSQL = @"select a.outpatrecipeid_chr, b.dosageunit_chr, a.rowno_chr, a.itemid_chr, 
         a.unitid_chr,a.qty_dec as qty_dec, a.unitprice_mny as price_mny, 
         a.tolprice_mny,a.medstoreid_chr, '' as usageid_chr, 0 as days_int, 
         '' as freqid_chr, '' as desc_vchr, b.dosage_dec as discount_dec, 0 as dosage_dec,
         a.itemspec_vchr,a.qty_dec as dosageqty,b.itemname_vchr, 
         b.itemopinvtype_chr,b.itemcode_vchr, b.itemsrcid_vchr,
          b.itemsrcid_vchr as medicineid_chr,b.dosage_dec as basicdosage,
         b.itemipunit_chr,f.typename_vchr, 1 putmed_int,  '' opusagedesc,
         '' as usagename_vchr, 0 times_int1, 0 days_int1,
          '' freqdesc, '' freqname_chr,0 times_int,
         0 min_qty_dec1, 0 min_qty_dec,'' sumusage_vchr,
         't_opr_outpatientothrecipede' as fromtable,  a.itemname_vchr as mednormalname_vchr ,
         a.itemunit_vchr,g.medicinetypeid_chr,b.packqty_dec,b.opchargeflg_int
    from t_opr_recipesend m,
         t_opr_recipesendentry n,
         t_opr_outpatientothrecipede a,
         t_bse_chargeitem b,
         t_bse_chargeitemextype f,
         t_bse_medicine g
   where m.sid_int = n.sid_int
     and n.outpatrecipeid_chr = a.outpatrecipeid_chr
     and a.itemid_chr = b.itemid_chr
     and a.deptmed_int = 0
     and m.sid_int = ?
     and a.medstoreid_chr = ?
     and b.itemopinvtype_chr = f.typeid_chr
     and b.itemsrcid_vchr = g.medicineid_chr(+)
order by a.billrowno_int, b.itemname_vchr";
                    p_dtTemp.Rows.Clear();
                    objLisAddItemRefArr = null;
                    objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                    objLisAddItemRefArr[0].Value = m_intsid;
                    objLisAddItemRefArr[1].Value = p_strMedStoreid;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtTemp, objLisAddItemRefArr);
                    if (lngRes > 0)
                    {
                        for (int i = 0; i < p_dtTemp.Rows.Count; i++)
                        {
                            m_objItemArr = p_dtTemp.Rows[i].ItemArray;
                            m_objTempDr = p_dtItemDe.NewRow();
                            m_objTempDr.ItemArray = m_objItemArr;
                            p_dtItemDe.Rows.Add(m_objTempDr);
                        }
                    }
                    strSQL = @"  select a.outpatrecipeid_chr,b.dosageunit_chr, a.rowno_chr, a.itemid_chr, 
         '' unitid_chr,a.qty_dec as qty_dec, a.price_mny as price_mny,
         a.tolprice_mny,  a.medstoreid_chr, '' as usageid_chr, 0 as days_int,
         '' as freqid_chr,'' as desc_vchr, b.dosage_dec as discount_dec, 0 as dosage_dec,
         a.itemspec_vchr, a.qty_dec as dosageqty, b.itemname_vchr,
         b.itemopinvtype_chr,b.itemcode_vchr,b.itemsrcid_vchr,
         b.itemsrcid_vchr as medicineid_chr,b.dosage_dec as basicdosage,
         b.itemipunit_chr,f.typename_vchr,1 putmed_int,  '' opusagedesc, 
         '' as usagename_vchr,  0 times_int1, 0 days_int1, 
         '' freqdesc, '' freqname_chr, 0 times_int,
         0 min_qty_dec1, 0 min_qty_dec, '' sumusage_vchr,
         't_opr_outpatientchkrecipede' as fromtable, '' as mednormalname_vchr, 
         a.itemunit_vchr, '' medicinetypeid_chr,b.packqty_dec,b.opchargeflg_int
    from t_opr_recipesend m,
         t_opr_recipesendentry n,
         t_opr_outpatientchkrecipede a,
         t_bse_chargeitem b,
         t_bse_chargeitemextype f
   where m.sid_int = n.sid_int
     and n.outpatrecipeid_chr = a.outpatrecipeid_chr
     and a.itemid_chr = b.itemid_chr
     and m.sid_int = ?
     and a.medstoreid_chr = ?
     and b.itemopinvtype_chr = f.typeid_chr
order by a.billrowno_int, b.itemname_vchr";
                    p_dtTemp.Rows.Clear();
                    objLisAddItemRefArr = null;
                    objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                    objLisAddItemRefArr[0].Value = m_intsid;
                    objLisAddItemRefArr[1].Value = p_strMedStoreid;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtTemp, objLisAddItemRefArr);
                    if (lngRes > 0)
                    {
                        for (int i = 0; i < p_dtTemp.Rows.Count; i++)
                        {
                            m_objItemArr = p_dtTemp.Rows[i].ItemArray;
                            m_objTempDr = p_dtItemDe.NewRow();
                            m_objTempDr.ItemArray = m_objItemArr;
                            p_dtItemDe.Rows.Add(m_objTempDr);
                        }
                    }
                    strSQL = @"select   a.outpatrecipeid_chr,b.dosageunit_chr, a.rowno_chr, a.itemid_chr, 
         '' unitid_chr, a.qty_dec as qty_dec, a.price_mny as price_mny,
         a.tolprice_mny, a.medstoreid_chr, '' as usageid_chr, 0 as days_int,
         '' as freqid_chr,'' as desc_vchr, b.dosage_dec as discount_dec,0 as dosage_dec,
         a.itemspec_vchr, a.qty_dec as dosageqty,b.itemname_vchr, 
         b.itemopinvtype_chr,  b.itemcode_vchr, b.itemsrcid_vchr, 
         b.itemsrcid_vchr as medicineid_chr,b.dosage_dec as basicdosage,
         b.itemipunit_chr, f.typename_vchr, 1 putmed_int, '' opusagedesc,
         '' as usagename_vchr,  0 times_int1, 0 days_int1,
         '' freqdesc, '' freqname_chr, 0 times_int, 
         0 min_qty_dec1,0 min_qty_dec, '' sumusage_vchr,
         't_opr_outpatienttestrecipede' as fromtable,'' as mednormalname_vchr,
         a.itemunit_vchr,  '' medicinetypeid_chr,b.packqty_dec,b.opchargeflg_int
    from t_opr_recipesend m,
         t_opr_recipesendentry n,
         t_opr_outpatienttestrecipede a,
         t_bse_chargeitem b,
         t_bse_chargeitemextype f
   where m.sid_int = n.sid_int
     and n.outpatrecipeid_chr = a.outpatrecipeid_chr
     and a.itemid_chr = b.itemid_chr
     and m.sid_int = ?
     and a.medstoreid_chr = ?
     and b.itemopinvtype_chr = f.typeid_chr
order by a.billrowno_int, b.itemname_vchr";
                    p_dtTemp.Rows.Clear();
                    objLisAddItemRefArr = null;
                    objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                    objLisAddItemRefArr[0].Value = m_intsid;
                    objLisAddItemRefArr[1].Value = p_strMedStoreid;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtTemp, objLisAddItemRefArr);
                    if (lngRes > 0)
                    {
                        for (int i = 0; i < p_dtTemp.Rows.Count; i++)
                        {
                            m_objItemArr = p_dtTemp.Rows[i].ItemArray;
                            m_objTempDr = p_dtItemDe.NewRow();
                            m_objTempDr.ItemArray = m_objItemArr;
                            p_dtItemDe.Rows.Add(m_objTempDr);
                        }
                    }
                    strSQL = @" select   a.outpatrecipeid_chr,b.dosageunit_chr, a.rowno_chr, a.itemid_chr,
         '' unitid_chr, a.qty_dec as qty_dec, a.price_mny as price_mny,
         a.tolprice_mny, a.medstoreid_chr, '' as usageid_chr, 0 as days_int,
         '' as freqid_chr,'' as desc_vchr,b.dosage_dec as discount_dec,0 as dosage_dec,
         a.itemspec_vchr, a.qty_dec as dosageqty, b.itemname_vchr,
         b.itemopinvtype_chr,  b.itemcode_vchr,  b.itemsrcid_vchr, 
         b.itemsrcid_vchr as medicineid_chr,b.dosage_dec as basicdosage,
          b.itemipunit_chr, f.typename_vchr,1 putmed_int,'' opusagedesc, 
         '' as usagename_vchr, 0 times_int1, 0 days_int1,
           '' freqdesc,'' freqname_chr, 0 times_int, 
           0 min_qty_dec1, 0 min_qty_dec,'' sumusage_vchr, 
           't_opr_outpatientopsrecipede' as fromtable,'' as mednormalname_vchr,
          a.itemunit_vchr,'' medicinetypeid_chr,b.packqty_dec,b.opchargeflg_int
    from t_opr_recipesend m,
         t_opr_recipesendentry n,
         t_opr_outpatientopsrecipede a,
         t_bse_chargeitem b,
         t_bse_chargeitemextype f
   where m.sid_int = n.sid_int
     and n.outpatrecipeid_chr = a.outpatrecipeid_chr
     and a.itemid_chr = b.itemid_chr
     and m.sid_int = ?
     and a.medstoreid_chr = ?
     and b.itemopinvtype_chr = f.typeid_chr
order by a.billrowno_int, b.itemname_vchr";
                    p_dtTemp.Rows.Clear();
                    objLisAddItemRefArr = null;
                    objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                    objLisAddItemRefArr[0].Value = m_intsid;
                    objLisAddItemRefArr[1].Value = p_strMedStoreid;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtTemp, objLisAddItemRefArr);
                    if (lngRes > 0)
                    {
                        for (int i = 0; i < p_dtTemp.Rows.Count; i++)
                        {
                            m_objItemArr = p_dtTemp.Rows[i].ItemArray;
                            m_objTempDr = p_dtItemDe.NewRow();
                            m_objTempDr.ItemArray = m_objItemArr;
                            p_dtItemDe.Rows.Add(m_objTempDr);
                        }
                    }

                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }

            }
            return lngRes;
        }
        #endregion

        #region 查询口服类用药ID
        /// <summary>
        /// 查询口服类用药ID
        /// </summary>
        /// <param name="p_strParmCode"></param>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedUsageID(string p_strParmCode, ref DataTable dtResult)
        {
            long lngRes = 0;

            string strSQL = @"select t.parmvalue_vchr from t_bse_sysparm t where t.parmcode_chr = ?";
            HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            try
            {
                System.Data.IDataParameter[] objParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objParamArr);
                objParamArr[0].Value = p_strParmCode;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, objParamArr);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            finally
            {
                objHRPSvc.Dispose();
                objHRPSvc = null;
            }

            return lngRes;
        }
        #endregion

        #region 根据药品ID查询出相关的药品信息
        /// <summary>
        /// 根据药品ID查询出相关的药品信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strMedID"></param>
        /// <param name="p_strDosage"></param>
        /// <param name="p_strIpUnit"></param>
        /// <param name="p_strPrepType"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedDetailByMedID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strMedID, out string p_strDosage, out string p_strIpUnit, out string p_strPrepType)
        {
            long lngRes = 0;
            p_strDosage = "";
            p_strIpUnit = "";
            p_strPrepType = "";

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsCenterMedManageSvc", "m_lngGetMedDetailByMedID");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"select t.dosage_dec, t.ipunit_chr, t.medicinepreptype_chr
                                  from t_bse_medicine t
                                 where t.medicineid_chr = ?";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] paramArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out paramArr);
                paramArr[0].Value = p_strMedID;

                DataTable dtResult = new DataTable();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, paramArr);
                if (dtResult.Rows.Count != 0)
                {
                    p_strDosage = dtResult.Rows[0][0].ToString();
                    p_strIpUnit = dtResult.Rows[0][1].ToString();
                    p_strPrepType = dtResult.Rows[0][2].ToString();
                }
                objHRPSvc.Dispose();
                objHRPSvc = null;
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx.Message);
            }
            return lngRes;
        }
        #endregion

        #region 获取系统时间
        /// <summary>
        /// 获取系统时间
        /// </summary>
        /// <returns></returns>
        public DateTime m_datGetServerDate()
        {
            return DateTime.Now;
        }
        #endregion

        #region 根据身份证号或者社保号查询诊疗卡号
        /// <summary>
        /// 根据身份证号或者社保号查询诊疗卡号
        /// </summary>
        /// <param name="p_strPatientID"></param>
        /// <param name="p_strTable"></param>
        /// <returns></returns>
        [AutoComplete]
        public string m_strGetCardID(string p_strPatientID, string p_strTable)
        {
            string strSQL1 = @"select a.patientcardid_chr
                                 from t_bse_patientcardtype t, t_bse_patientcard a
                                where t.patientid_chr = a.patientid_chr
                                  and t.paycardno_vchr = ? ";

            string strSQL2 = @"select a.patientcardid_chr
                                 from t_bse_patient t, t_bse_patientcard a
                                where t.patientid_chr = a.patientid_chr
                                  and t.idcard_chr = ? ";
            clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] objParam = null;
            DataTable dtResult = new DataTable();
            try
            {
                objHRPSvc.CreateDatabaseParameter(1, out objParam);
                objParam[0].Value = p_strPatientID;

                if (p_strTable == "1")
                {
                    objHRPSvc.lngGetDataTableWithParameters(strSQL1, ref dtResult, objParam);
                }
                else
                {
                    objHRPSvc.lngGetDataTableWithParameters(strSQL2, ref dtResult, objParam);
                }
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx.Message);
            }

            if (dtResult != null && dtResult.Rows.Count > 0)
            {
                return dtResult.Rows[0][0].ToString();
            }
            else
            {
                return "";
            }
        }
        #endregion

        #region 查询药品剂型、最小单位、药袋单位
        /// <summary>
        /// 查询药品剂型
        /// </summary>
        /// <param name="lstMedId"></param>
        /// <returns></returns>
        [AutoComplete]
        public void GetMedPrepType(List<string> lstMedId, out Dictionary<string, string> dicPrepType, out Dictionary<string, string> dicIpUnit, out Dictionary<string, string> dicMedBagUnit)
        {
            string Sql = @" select a.medicineid_chr,
                                   a.medicinepreptype_chr,
                                   a.ipunit_chr,
                                   a.medbagunit,
                                   b.medicinepreptypename_vchr
                              from t_bse_medicine a
                             inner join t_aid_medicinepreptype b
                                on a.medicinepreptype_chr = b.medicinepreptype_chr
                             where a.medicineid_chr in ({0})";

            dicPrepType = new Dictionary<string, string>();
            dicIpUnit = new Dictionary<string, string>();
            dicMedBagUnit = new Dictionary<string, string>();
            clsHRPTableService svc = new clsHRPTableService();
            IDataParameter[] parm = null;
            try
            {
                int n = -1;
                string sub = string.Empty;
                DataTable dt = new DataTable();
                svc.CreateDatabaseParameter(lstMedId.Count, out parm);
                foreach (string medId in lstMedId)
                {
                    parm[++n].Value = medId;
                    sub += "?, ";
                }
                Sql = string.Format(Sql, sub.Substring(0, sub.Length - 2));
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                if (dt != null && dt.Rows.Count > 0)
                {
                    string id = string.Empty;
                    string type = string.Empty;
                    string ipUnit = string.Empty;
                    string medBagUnit = string.Empty;
                    foreach (DataRow dr in dt.Rows)
                    {
                        id = dr["medicineid_chr"].ToString();
                        if (dr["medicinepreptypename_vchr"] != DBNull.Value)
                        {
                            type = dr["medicinepreptypename_vchr"].ToString().Trim();
                            if (!dicPrepType.ContainsKey(id))
                            {
                                dicPrepType.Add(id, type);
                            }
                        }
                        if (dr["ipunit_chr"] != DBNull.Value)
                        {
                            ipUnit = dr["ipunit_chr"].ToString().Trim();
                            if (!dicIpUnit.ContainsKey(id))
                            {
                                dicIpUnit.Add(id, ipUnit);
                            }
                        }
                        if (dr["medbagunit"] != DBNull.Value)
                        {
                            medBagUnit = dr["medbagunit"].ToString().Trim();
                            if (medBagUnit != string.Empty)
                            {
                                if (!dicMedBagUnit.ContainsKey(id))
                                {
                                    dicMedBagUnit.Add(id, medBagUnit);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsLogText log = new clsLogText();
                log.LogError(ex.Message);
            }
        }
        #endregion

    }
}
