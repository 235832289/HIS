using System;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
using System.EnterpriseServices;
using System.Data;
using System.Collections;

namespace com.digitalwave.iCare.middletier.HIS
{
    /// <summary>
    /// clsinjectInfoSvc 的摘要说明。
    /// </summary>
    [Transaction(TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsinjectInfoSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        public clsinjectInfoSvc()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// 更新护士工作站打印功能
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strRecipeid"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdatePrintFlag(System.Security.Principal.IPrincipal p_objPrincipal, string m_strRecipeid)
        {

            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_lngUpdatePrintFlag");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"update t_opr_outpatientrecipe a set a.printed_int=1 where a.outpatrecipeid_chr=?";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] m_objDataPara = null;
                objHRPSvc.CreateDatabaseParameter(1, out m_objDataPara);
                m_objDataPara[0].Value = m_strRecipeid;
                long lngAffected = -1;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffected, m_objDataPara);
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
        #region 查找用法
        [AutoComplete]
        public long m_mthFindUsage(System.Security.Principal.IPrincipal p_objPrincipal, int p_type, out DataTable dt)
        {
            dt = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthFindUsage");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT a.usageid_chr, b.usagename_vchr
  FROM t_opr_setusage a, t_bse_usagetype b
 WHERE a.usageid_chr = b.usageid_chr(+) AND a.type_int = '" + p_type.ToString() + "'";
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
        #region  查询病人信息
        [AutoComplete]
        public long m_mthGetPatientInfo(System.Security.Principal.IPrincipal p_objPrincipal, string strType, string strValue, out DataTable dt)
        {
            dt = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthGetPatientInfo");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"select A.patientcardid_chr,
                                   a.patientid_chr,
                                   b.NAME_VCHR,
                                   b.sex_chr,
                                   b.birth_dat,
                                   b.homeaddress_vchr
                              from T_BSE_PATIENTCARD A, T_BSE_PATIENT B
                             where A.STATUS_INT > 0
                               and a.patientid_chr = b.patientid_chr(+)
                               and " + strType + " like '" + strValue + "%'";
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
        #region 查找项目信息
        [AutoComplete]
        public long m_mthGetItemInfo(System.Security.Principal.IPrincipal p_objPrincipal, string strPatientID, string strUsageID, DateTime begiontime, DateTime endtime, out DataTable dt)
        {
            dt = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthGetItemInfo");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @" select a.pstauts_int,BB.*,d.ITEMNAME_VCHR  from T_OPR_OUTPATIENTRECIPE A,(select a.outpatrecipeid_chr,a.ITEMID_CHR,b.unitid_chr,b.usageid_chr,b.tolqty_dec,b.unitprice_mny,
b.tolprice_mny,b.days_int,b.qty_dec,b.discount_dec,b.freqid_chr
from T_OPR_OUTPATIENTPWMRECIPEDE a ,T_TMP_OUTPATIENTPWMRECIPEDE b
where a.outpatrecipeid_chr=b.outpatrecipeid_chr(+)
and a.itemid_chr =b.itemid_chr(+)) BB,T_BSE_CHARGEITEM D
where a.outpatrecipeid_chr =bb.outpatrecipeid_chr(+)
and BB.ITEMID_CHR =d.ITEMID_CHR(+)
and a.pstauts_int=2 and bb.usageid_chr ='" + strUsageID + @"'
and a.patientid_chr='" + strPatientID + @"'
and a.RECORDDATE_DAT BETWEEN TO_DATE('" + begiontime.ToString("yyyy-MM-dd 00:00:00") + "','yyyy-mm-dd hh24:mi:ss') " +
                @" AND TO_DATE('" + endtime.ToString("yyyy-MM-dd 23:59:59") + @"','yyyy-mm-dd hh24:mi:ss')
union all
select a.PSTAUTS_INT,b.outpatrecipedeid_chr,b.ITEMID_CHR,b.UNITID_CHR
,b.USAGEID_CHR,b.TOLQTY_DEC,b.UNITPRICE_MNY,b.TOLPRICE_MNY,b.DAYS_INT,b.QTY_DEC,b.DISCOUNT_DEC,b.FREQID_CHR,d.ITEMNAME_VCHR 
from T_OPR_OUTPATIENTRECIPE a, T_TMP_OUTPATIENTPWMRECIPEDE B,T_BSE_CHARGEITEM D
where  a.outpatrecipeid_chr =b.outpatrecipeid_chr(+)
and b.ITEMID_CHR =d.ITEMID_CHR(+)
and a.pstauts_int=0 and b.usageid_chr ='" + strUsageID + @"'
and a.patientid_chr='" + strPatientID + @"'
and a.RECORDDATE_DAT BETWEEN TO_DATE('" + begiontime.ToString("yyyy-MM-dd 00:00:00") + "','yyyy-mm-dd hh24:mi:ss') " +
                @" AND TO_DATE('" + endtime.ToString("yyyy-MM-dd 23:59:59") + @"','yyyy-mm-dd hh24:mi:ss')";
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
        #region 获取病人信息
        /// <summary>
        /// 获取病人信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="begiontime"></param>
        /// <param name="endtime"></param>
        /// <param name="strUsageType"></param>
        /// <param name="dt"></param>
        /// <param name="strFlag"></param>
        /// <param name="strCarNo"></param>
        /// <param name="patenitName"></param>
        /// <param name="stremp"></param>
        /// <param name="m_strUseMode">门诊护士工作站的使用模式，0-默认使用格式；1-茶山使用模式（特殊需求）</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthGetPatinetList(System.Security.Principal.IPrincipal p_objPrincipal, DateTime begiontime, DateTime endtime, string strUsageType, out DataTable dt, string strFlag, string strCarNo, string patenitName, string stremp, string m_strUseMode)
        {
            dt = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthGetPatinetList");
            if (lngRes < 0)
            {
                return -1;
            }
            string strWhere = "";
            if (strFlag == "0")
            {
                strWhere = " and (a.PSTAUTS_INT=2 or a.PSTAUTS_INT=-2) ";
            }
            if (strCarNo != "")
            {
                strWhere += " and c.PATIENTCARDID_CHR='" + strCarNo + "'";
            }
            if (patenitName != "")
            {
                strWhere += " and b.NAME_VCHR like '" + patenitName + "%'";
            }
            if (stremp != "")
            {
                strWhere += " and DEPTID_CHR ='" + stremp + "'";
            }
            string strSQL = @"SELECT distinct outpatrecipeid_chr, patientid_chr, name_vchr, sex_chr, birth_dat,
       patientcardid_chr, recorddate_dat, deptname_vchr, pstauts_int,
       deptid_chr,PRINTED_INT, homeaddress_vchr
  FROM (SELECT a.outpatrecipeid_chr, a.patientid_chr, b.name_vchr, b.sex_chr,
               b.birth_dat, c.patientcardid_chr, a.recorddate_dat,
               g.deptname_vchr, a.pstauts_int, g.deptid_chr,a.PRINTED_INT, b.homeaddress_vchr
          FROM t_opr_outpatientrecipe a,
               t_bse_patient b,
               t_bse_patientcard c,
               t_opr_outpatientpwmrecipede d,
               (SELECT DISTINCT usageid_chr
                           FROM t_opr_setusage
                          WHERE type_int =?) f,
               t_bse_deptdesc g
         WHERE a.recorddate_dat BETWEEN TO_DATE (?,
                                                 'yyyy-mm-dd hh24:mi:ss'
                                                )
                                    AND TO_DATE (?,
                                                 'yyyy-mm-dd hh24:mi:ss'
                                                )
           and a.outpatrecipeid_chr = d.outpatrecipeid_chr
           AND d.usageid_chr = f.usageid_chr
           and a.patientid_chr = b.patientid_chr
           AND a.patientid_chr = c.patientid_chr
           AND a.diagdept_chr = g.deptid_chr " + strWhere + @" 
            
        UNION All
        SELECT a.outpatrecipeid_chr, a.patientid_chr, b.name_vchr, b.sex_chr,
               b.birth_dat, c.patientcardid_chr, a.recorddate_dat,
               g.deptname_vchr, a.pstauts_int, g.deptid_chr,a.PRINTED_INT, b.homeaddress_vchr
          FROM t_opr_outpatientrecipe a,
               t_bse_patient b,
               t_bse_patientcard c,
               t_opr_outpatientcmrecipede h,
               (SELECT DISTINCT usageid_chr
                           FROM t_opr_setusage
                          WHERE type_int =? ) f,
               t_bse_deptdesc g
         WHERE a.patientid_chr = b.patientid_chr
           AND a.patientid_chr = c.patientid_chr
           AND a.diagdept_chr = g.deptid_chr
           AND a.recorddate_dat BETWEEN TO_DATE (?,
                                                 'yyyy-mm-dd hh24:mi:ss'
                                                )
                                    AND TO_DATE (?,
                                                 'yyyy-mm-dd hh24:mi:ss'
                                                )
           AND a.outpatrecipeid_chr = h.outpatrecipeid_chr
           AND h.usageid_chr=f.usageid_chr " + strWhere + @" 
        UNION All
        SELECT a.outpatrecipeid_chr, a.patientid_chr, b.name_vchr, b.sex_chr,
               b.birth_dat, c.patientcardid_chr, a.recorddate_dat,
               h.deptname_vchr, a.pstauts_int, h.deptid_chr,a.PRINTED_INT, b.homeaddress_vchr
          FROM t_opr_outpatientrecipe a,
               t_bse_patient b,
               t_bse_patientcard c,
               t_opr_outpatientchkrecipede d,
               (SELECT DISTINCT usageid_chr
                           FROM t_opr_setusage
                          WHERE type_int =?) f,
               t_bse_chargeitem g,
               t_bse_deptdesc h
         WHERE a.patientid_chr = b.patientid_chr
           AND a.patientid_chr = c.patientid_chr
           AND a.diagdept_chr = h.deptid_chr
           AND a.recorddate_dat BETWEEN TO_DATE (?,
                                                 'yyyy-mm-dd hh24:mi:ss'
                                                )
                                    AND TO_DATE (?,
                                                 'yyyy-mm-dd hh24:mi:ss'
                                                )
           AND a.outpatrecipeid_chr = d.outpatrecipeid_chr
                 AND d.itemid_chr = g.itemid_chr
                 AND g.usageid_chr = f.usageid_chr " + strWhere + @" 
        UNION All
        SELECT a.outpatrecipeid_chr, a.patientid_chr, b.name_vchr, b.sex_chr,
               b.birth_dat, c.patientcardid_chr, a.recorddate_dat,
               h.deptname_vchr, a.pstauts_int, h.deptid_chr,a.PRINTED_INT, b.homeaddress_vchr
          FROM t_opr_outpatientrecipe a,
               t_bse_patient b,
               t_bse_patientcard c,
               t_opr_outpatienttestrecipede d,
               (SELECT DISTINCT usageid_chr
                           FROM t_opr_setusage
                          WHERE type_int =?) f,
               t_bse_chargeitem g,
               t_bse_deptdesc h
         WHERE a.patientid_chr = b.patientid_chr
           AND a.patientid_chr = c.patientid_chr
           AND a.diagdept_chr = h.deptid_chr
           AND a.recorddate_dat BETWEEN TO_DATE (?,
                                                 'yyyy-mm-dd hh24:mi:ss'
                                                )
                                    AND TO_DATE (?,
                                                 'yyyy-mm-dd hh24:mi:ss'
                                                )
           AND   a.outpatrecipeid_chr = d.outpatrecipeid_chr
                 AND d.itemid_chr = g.itemid_chr
                 AND g.usageid_chr = f.usageid_chr " + strWhere + @" 

        UNION All
        SELECT a.outpatrecipeid_chr, a.patientid_chr, b.name_vchr, b.sex_chr,
               b.birth_dat, c.patientcardid_chr, a.recorddate_dat,
               h.deptname_vchr, a.pstauts_int, h.deptid_chr,a.PRINTED_INT, b.homeaddress_vchr
          FROM t_opr_outpatientrecipe a,
               t_bse_patient b,
               t_bse_patientcard c,
               t_opr_outpatientopsrecipede d,
               (SELECT DISTINCT usageid_chr
                           FROM t_opr_setusage
                          WHERE type_int =?) f,
               t_bse_chargeitem g,
               t_bse_deptdesc h
         WHERE a.patientid_chr = b.patientid_chr
           AND a.patientid_chr = c.patientid_chr
           AND a.diagdept_chr = h.deptid_chr
           AND a.recorddate_dat BETWEEN TO_DATE (?,
                                                 'yyyy-mm-dd hh24:mi:ss'
                                                )
                                    AND TO_DATE (?,
                                                 'yyyy-mm-dd hh24:mi:ss'
                                                )
           AND a.outpatrecipeid_chr = d.outpatrecipeid_chr
                 AND d.itemid_chr = g.itemid_chr
                 AND g.usageid_chr = f.usageid_chr " + strWhere + @" 

        UNION All
        SELECT a.outpatrecipeid_chr, a.patientid_chr, b.name_vchr, b.sex_chr,
               b.birth_dat, c.patientcardid_chr, a.recorddate_dat,
               h.deptname_vchr, a.pstauts_int, h.deptid_chr,a.PRINTED_INT, b.homeaddress_vchr
          FROM t_opr_outpatientrecipe a,
               t_bse_patient b,
               t_bse_patientcard c,
               t_opr_outpatientothrecipede d,
               (SELECT DISTINCT usageid_chr
                           FROM t_opr_setusage
                          WHERE type_int = ?) f,
               t_bse_chargeitem g,
               t_bse_deptdesc h
         WHERE a.patientid_chr = b.patientid_chr
           AND a.patientid_chr = c.patientid_chr
           AND a.diagdept_chr = h.deptid_chr
           AND a.recorddate_dat BETWEEN TO_DATE (?,
                                                 'yyyy-mm-dd hh24:mi:ss'
                                                )
                                    AND TO_DATE (?,
                                                 'yyyy-mm-dd hh24:mi:ss'
                                                )
           AND a.outpatrecipeid_chr = d.outpatrecipeid_chr
                 AND d.itemid_chr = g.itemid_chr
                 AND g.usageid_chr = f.usageid_chr " + strWhere + @" 
 ) order by recorddate_dat  desc";
            if (m_strUseMode == "1")
            {
                strSQL = @"SELECT distinct outpatrecipeid_chr, patientid_chr, name_vchr, sex_chr, birth_dat,
       patientcardid_chr, recorddate_dat, deptname_vchr, pstauts_int,
       deptid_chr,PRINTED_INT, homeaddress_vchr
  FROM (SELECT a.outpatrecipeid_chr, a.patientid_chr, b.name_vchr, b.sex_chr,
               b.birth_dat, c.patientcardid_chr, a.recorddate_dat,
               g.deptname_vchr, a.pstauts_int, g.deptid_chr,a.PRINTED_INT, b.homeaddress_vchr
          FROM t_opr_outpatientrecipe a,
               t_bse_patient b,
               t_bse_patientcard c,
               t_tmp_outpatientpwmrecipede d,
               (SELECT DISTINCT usageid_chr
                           FROM t_opr_setusage
                          WHERE type_int =? and usageid_chr not in ('0090','0060','0111','0121')) f,
               t_bse_deptdesc g
         WHERE a.recorddate_dat BETWEEN TO_DATE (?,
                                                 'yyyy-mm-dd hh24:mi:ss'
                                                )
                                    AND TO_DATE (?,
                                                 'yyyy-mm-dd hh24:mi:ss'
                                                )
           and a.outpatrecipeid_chr = d.outpatrecipeid_chr
           AND d.usageid_chr = f.usageid_chr
           and a.patientid_chr = b.patientid_chr
           AND a.patientid_chr = c.patientid_chr
           AND a.diagdept_chr = g.deptid_chr " + strWhere + @" 
            
        UNION All
        SELECT a.outpatrecipeid_chr, a.patientid_chr, b.name_vchr, b.sex_chr,
               b.birth_dat, c.patientcardid_chr, a.recorddate_dat,
               g.deptname_vchr, a.pstauts_int, g.deptid_chr,a.PRINTED_INT, b.homeaddress_vchr
          FROM t_opr_outpatientrecipe a,
               t_bse_patient b,
               t_bse_patientcard c,
               t_tmp_outpatientcmrecipede h,
               (SELECT DISTINCT usageid_chr
                           FROM t_opr_setusage
                          WHERE type_int =? and usageid_chr not in ('0090','0060','0111','0121')) f,
               t_bse_deptdesc g
         WHERE a.patientid_chr = b.patientid_chr
           AND a.patientid_chr = c.patientid_chr
           AND a.diagdept_chr = g.deptid_chr
           AND a.recorddate_dat BETWEEN TO_DATE (?,
                                                 'yyyy-mm-dd hh24:mi:ss'
                                                )
                                    AND TO_DATE (?,
                                                 'yyyy-mm-dd hh24:mi:ss'
                                                )
           AND a.outpatrecipeid_chr = h.outpatrecipeid_chr
           AND h.usageid_chr=f.usageid_chr " + strWhere + @" 
        UNION All
        SELECT a.outpatrecipeid_chr, a.patientid_chr, b.name_vchr, b.sex_chr,
               b.birth_dat, c.patientcardid_chr, a.recorddate_dat,
               h.deptname_vchr, a.pstauts_int, h.deptid_chr,a.PRINTED_INT, b.homeaddress_vchr
          FROM t_opr_outpatientrecipe a,
               t_bse_patient b,
               t_bse_patientcard c,
               t_tmp_outpatientchkrecipede d,
               (SELECT DISTINCT usageid_chr
                           FROM t_opr_setusage
                          WHERE type_int =? and usageid_chr not in ('0090','0060','0111','0121')) f,
               t_bse_chargeitem g,
               t_bse_deptdesc h
         WHERE a.patientid_chr = b.patientid_chr
           AND a.patientid_chr = c.patientid_chr
           AND a.diagdept_chr = h.deptid_chr
           AND a.recorddate_dat BETWEEN TO_DATE (?,
                                                 'yyyy-mm-dd hh24:mi:ss'
                                                )
                                    AND TO_DATE (?,
                                                 'yyyy-mm-dd hh24:mi:ss'
                                                )
           AND a.outpatrecipeid_chr = d.outpatrecipeid_chr
                 AND d.itemid_chr = g.itemid_chr
                 AND g.usageid_chr = f.usageid_chr " + strWhere + @" 
        UNION All
        SELECT a.outpatrecipeid_chr, a.patientid_chr, b.name_vchr, b.sex_chr,
               b.birth_dat, c.patientcardid_chr, a.recorddate_dat,
               h.deptname_vchr, a.pstauts_int, h.deptid_chr,a.PRINTED_INT, b.homeaddress_vchr
          FROM t_opr_outpatientrecipe a,
               t_bse_patient b,
               t_bse_patientcard c,
               t_tmp_outpatienttestrecipede d,
               (SELECT DISTINCT usageid_chr
                           FROM t_opr_setusage
                          WHERE type_int =? and usageid_chr not in ('0090','0060','0111','0121')) f,
               t_bse_chargeitem g,
               t_bse_deptdesc h
         WHERE a.patientid_chr = b.patientid_chr
           AND a.patientid_chr = c.patientid_chr
           AND a.diagdept_chr = h.deptid_chr
           AND a.recorddate_dat BETWEEN TO_DATE (?,
                                                 'yyyy-mm-dd hh24:mi:ss'
                                                )
                                    AND TO_DATE (?,
                                                 'yyyy-mm-dd hh24:mi:ss'
                                                )
           AND   a.outpatrecipeid_chr = d.outpatrecipeid_chr
                 AND d.itemid_chr = g.itemid_chr
                 AND g.usageid_chr = f.usageid_chr " + strWhere + @" 

        UNION All
        SELECT a.outpatrecipeid_chr, a.patientid_chr, b.name_vchr, b.sex_chr,
               b.birth_dat, c.patientcardid_chr, a.recorddate_dat,
               h.deptname_vchr, a.pstauts_int, h.deptid_chr,a.PRINTED_INT, b.homeaddress_vchr
          FROM t_opr_outpatientrecipe a,
               t_bse_patient b,
               t_bse_patientcard c,
               t_tmp_outpatientopsrecipede d,
               (SELECT DISTINCT usageid_chr
                           FROM t_opr_setusage
                          WHERE type_int =? and usageid_chr not in ('0090','0060','0111','0121')) f,
               t_bse_chargeitem g,
               t_bse_deptdesc h
         WHERE a.patientid_chr = b.patientid_chr
           AND a.patientid_chr = c.patientid_chr
           AND a.diagdept_chr = h.deptid_chr
           AND a.recorddate_dat BETWEEN TO_DATE (?,
                                                 'yyyy-mm-dd hh24:mi:ss'
                                                )
                                    AND TO_DATE (?,
                                                 'yyyy-mm-dd hh24:mi:ss'
                                                )
           AND a.outpatrecipeid_chr = d.outpatrecipeid_chr
                 AND d.itemid_chr = g.itemid_chr
                 AND g.usageid_chr = f.usageid_chr " + strWhere + @" 

        UNION All
        SELECT a.outpatrecipeid_chr, a.patientid_chr, b.name_vchr, b.sex_chr,
               b.birth_dat, c.patientcardid_chr, a.recorddate_dat,
               h.deptname_vchr, a.pstauts_int, h.deptid_chr,a.PRINTED_INT, b.homeaddress_vchr
          FROM t_opr_outpatientrecipe a,
               t_bse_patient b,
               t_bse_patientcard c,
               t_tmp_outpatientothrecipede d,
               (SELECT DISTINCT usageid_chr
                           FROM t_opr_setusage
                          WHERE type_int = ? and usageid_chr not in ('0090','0060','0111','0121')) f,
               t_bse_chargeitem g,
               t_bse_deptdesc h
         WHERE a.patientid_chr = b.patientid_chr
           AND a.patientid_chr = c.patientid_chr
           AND a.diagdept_chr = h.deptid_chr
           AND a.recorddate_dat BETWEEN TO_DATE (?,
                                                 'yyyy-mm-dd hh24:mi:ss'
                                                )
                                    AND TO_DATE (?,
                                                 'yyyy-mm-dd hh24:mi:ss'
                                                )
           AND a.outpatrecipeid_chr = d.outpatrecipeid_chr
                 AND d.itemid_chr = g.itemid_chr
                 AND g.usageid_chr = f.usageid_chr " + strWhere + @" 
 ) order by recorddate_dat  desc";
            }
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] m_objDataParas = null;
                objHRPSvc.CreateDatabaseParameter(18, out m_objDataParas);
                m_objDataParas[0].Value = strUsageType;
                m_objDataParas[1].Value = begiontime.ToString("yyyy-MM-dd 00:00:00");
                m_objDataParas[2].Value = endtime.ToString("yyyy-MM-dd 23:59:59");
                m_objDataParas[3].Value = strUsageType;
                m_objDataParas[4].Value = begiontime.ToString("yyyy-MM-dd 00:00:00");
                m_objDataParas[5].Value = endtime.ToString("yyyy-MM-dd 23:59:59");
                m_objDataParas[6].Value = strUsageType;
                m_objDataParas[7].Value = begiontime.ToString("yyyy-MM-dd 00:00:00");
                m_objDataParas[8].Value = endtime.ToString("yyyy-MM-dd 23:59:59");
                m_objDataParas[9].Value = strUsageType;
                m_objDataParas[10].Value = begiontime.ToString("yyyy-MM-dd 00:00:00");
                m_objDataParas[11].Value = endtime.ToString("yyyy-MM-dd 23:59:59");
                m_objDataParas[12].Value = strUsageType;
                m_objDataParas[13].Value = begiontime.ToString("yyyy-MM-dd 00:00:00");
                m_objDataParas[14].Value = endtime.ToString("yyyy-MM-dd 23:59:59");
                m_objDataParas[15].Value = strUsageType;
                m_objDataParas[16].Value = begiontime.ToString("yyyy-MM-dd 00:00:00");
                m_objDataParas[17].Value = endtime.ToString("yyyy-MM-dd 23:59:59");
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, m_objDataParas);
                //lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL.ToLower(),ref dt,m_objDataParas);
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
        #region 获取科室数据
        /// <summary>
        /// 获取科室数据
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtDept"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthGetAllDeptdesc(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable p_dtDept)
        {
            p_dtDept = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthGetAllDeptdesc");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT  CODE_VCHR,DEPTNAME_VCHR,PYCODE_CHR,WBCODE_CHR
    FROM t_bse_deptdesc
   WHERE category_int = 0
     AND (attributeid = '0000002' OR attributeid = '0000001')
     AND deptname_vchr <> '所有'
     AND inpatientoroutpatient_int = 0
ORDER BY shortno_chr";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtDept);
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
        /// 获取用户所属科室数据
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtDept"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthGetAllDeptdescByEmpId(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable p_dtDept, string p_strEmpId)
        {
            p_dtDept = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthGetAllDeptdescByEmpId");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT   b.code_vchr, b.deptname_vchr, b.pycode_chr, b.wbcode_chr,b.DEPTID_CHR
                                         FROM t_bse_deptemp a, t_bse_deptdesc b
                                            WHERE b.category_int = 0
                                                 AND (b.attributeid = '0000002' OR b.attributeid = '0000001')
                                                 AND b.deptname_vchr <> '所有'
                                                 AND b.inpatientoroutpatient_int = 0
                                                 AND a.deptid_chr = b.deptid_chr(+)
                                                 AND a.end_dat IS NULL
                                                 AND a.empid_chr = '" + p_strEmpId + "' ORDER BY b.shortno_chr";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtDept);
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
        #region 获取护士工作站分类病人及行目信息
        /// <summary>
        /// 获取护士工作站分类病人及行目信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="strUsageType">分类ID</param>
        /// <param name="begiontime">开始时间</param>
        /// <param name="endtime">结束时间</param>
        /// <param name="dt">返回病人列表</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthGetAllData(System.Security.Principal.IPrincipal p_objPrincipal, string strUsageType, DateTime begiontime, DateTime endtime, out DataTable PatientDt, string strFlag, string strCarNo, string patenitName, string stremp, string m_strUseMode)
        {
            PatientDt = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthGetPatinetList");
            if (lngRes < 0)
            {
                return -1;
            }
            m_mthGetPatinetList(p_objPrincipal, begiontime, endtime, strUsageType, out PatientDt, strFlag, strCarNo, patenitName, stremp, m_strUseMode);
            return lngRes;

        }
        #endregion

        #region 获取处方类型数据
        /// <summary>
        /// 获取处方类型数据
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="strPatientID">处方ID</param>
        /// <param name="strUsageType">用法类型</param>
        /// <param name="dt">返回的数据</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthGetInputWet(System.Security.Principal.IPrincipal p_objPrincipal, string strRecipedeID, string strUsageType, out DataTable dt)
        {
            dt = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthGetPatinetList");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQLNew = "";
            #region new
            strSQLNew = @"
                       select  distinct a.pstauts_int, b.outpatrecipedeid_chr, b.itemid_chr,
         b.dosageunit_chr as unitid_chr, b.usageid_chr, b.tolqty_dec,
         b.unitprice_mny, b.tolprice_mny,
         case b.rowno_chr
            when '0'
               then ''
            else b.rowno_chr
         end as rowno_chr, b.days_int, b.qty_dec, b.discount_dec,
         b.freqid_chr, b.itemname_vchr, b.dosageunit_chr, b.itemspec_vchr,
         h.usagename_vchr, k.freqname_chr, b.dosage_dec, m.medicineid_chr,
         m.medicinetypeid_chr, 't_tmp_outpatientpwmrecipede' fromtable,
         e.lastname_vchr, h.usageid_chr as usageid,
         b.desc_vchr as itemusagedetail_vchr,b.unitid_chr as itemunit, c.diag_vchr
    from t_opr_outpatientrecipe a,
         t_tmp_outpatientpwmrecipede b,
         t_bse_chargeitem d,
         (select distinct usageid_chr
                     from t_opr_setusage
                    where type_int = ?) f,
         t_bse_usagetype h,
         t_aid_recipefreq k,
         t_bse_medicine m,
         t_bse_employee e,
         t_opr_outpatientcasehis c
   where a.outpatrecipeid_chr = ?
     and a.outpatrecipeid_chr = b.outpatrecipeid_chr
     and b.itemid_chr = d.itemid_chr
     and b.freqid_chr = k.freqid_chr
     and b.usageid_chr = f.usageid_chr
     and b.usageid_chr = h.usageid_chr
     and d.itemsrcid_vchr = m.medicineid_chr(+)
     and a.diagdr_chr = e.empid_chr(+)  and a.casehisid_chr = c.casehisid_chr(+) 
union all
select  distinct a.pstauts_int, b.outpatrecipedeid_chr, b.itemid_chr,
         d.dosageunit_chr as unitid_chr, d.usageid_chr, 0 as tolqty_dec,
         b.unitprice_mny, b.tolprice_mny,
         case b.rowno_chr
            when '0'
               then ''
            else b.rowno_chr
         end as rowno_chr, 0 as days_int, b.qty_dec, b.discount_dec,
         '' as freqid_chr, b.itemname_vchr, d.dosageunit_chr, b.itemspec_vchr,
         h.usagename_vchr, '' as freqname_chr, d.dosage_dec, m.medicineid_chr,
         m.medicinetypeid_chr, 't_tmp_outpatientpwmrecipede' fromtable,
         e.lastname_vchr, h.usageid_chr as usageid,
         '' as itemusagedetail_vchr,b.unitid_chr as itemunit, c.diag_vchr
    from t_opr_outpatientrecipe a,
         t_tmp_outpatientcmrecipede b,
         t_bse_chargeitem d,
         (select distinct usageid_chr
                     from t_opr_setusage
                    where type_int = ?) f,
         t_bse_usagetype h,
         t_bse_medicine m,
         t_bse_employee e,
         t_opr_outpatientcasehis c
   where a.outpatrecipeid_chr =?
     and a.outpatrecipeid_chr = b.outpatrecipeid_chr
     and b.itemid_chr = d.itemid_chr
     and b.usageid_chr = f.usageid_chr
     and b.usageid_chr = h.usageid_chr
     and d.itemsrcid_vchr = m.medicineid_chr(+)
     and a.diagdr_chr = e.empid_chr(+)  and a.casehisid_chr = c.casehisid_chr(+) 
union all
select distinct  a.pstauts_int, b.outpatrecipedeid_chr, b.itemid_chr,
         b.itemunit_vchr as unitid_chr, '' as usageid_chr, 0 as tolqty_dec,
         0 as unitprice_mny, b.tolprice_mny,
         case b.rowno_chr
            when '0'
               then ''
            else b.rowno_chr
         end as rowno_chr, 0 as days_int, b.qty_dec, b.discount_dec,
         '' as freqid_chr, b.itemname_vchr, b.itemunit_vchr as dosageunit_chr,
         b.itemspec_vchr, g.usagename_vchr, '' as freqname_chr, d.dosage_dec,
         m.medicineid_chr, m.medicinetypeid_chr,
         'T_TMP_OUTPATIENTCHKRECIPEDE' fromtable, e.lastname_vchr,
         g.usageid_chr as usageid, b.itemusagedetail_vchr,b.itemunit_vchr as itmeunit, c.diag_vchr
    from t_opr_outpatientrecipe a,
         t_tmp_outpatientchkrecipede b,
         t_bse_chargeitem d,
         (select distinct usageid_chr
                     from t_opr_setusage
                    where type_int = ?) f,
         t_bse_usagetype g,
         t_bse_medicine m,
         t_bse_employee e,
         t_opr_outpatientcasehis c
   where a.outpatrecipeid_chr =?
     and a.outpatrecipeid_chr = b.outpatrecipeid_chr
     and b.itemid_chr = d.itemid_chr
     and d.usageid_chr = f.usageid_chr
     and g.usageid_chr = d.usageid_chr
     and d.itemsrcid_vchr = m.medicineid_chr(+)
     and a.diagdr_chr = e.empid_chr(+)  and a.casehisid_chr = c.casehisid_chr(+) 
union all
select distinct  a.pstauts_int, b.outpatrecipedeid_chr, b.itemid_chr,
         b.itemunit_vchr as unitid_chr, '' as usageid_chr, 0 as tolqty_dec,
         0 as unitprice_mny, b.tolprice_mny,
         case b.rowno_chr
            when '0'
               then ''
            else b.rowno_chr
         end as rowno_chr, 0 as days_int, b.qty_dec, b.discount_dec,
         '' as freqid_chr, b.itemname_vchr, b.itemunit_vchr as dosageunit_chr,
         b.itemspec_vchr, g.usagename_vchr, '' as freqname_chr, d.dosage_dec,
         m.medicineid_chr, m.medicinetypeid_chr,
         'T_TMP_OUTPATIENTTESTRECIPEDE' fromtable, e.lastname_vchr,b.itemunit_vchr as itemunit,
         g.usageid_chr as usageid, b.itemusagedetail_vchr, c.diag_vchr
    from t_opr_outpatientrecipe a,
         t_tmp_outpatienttestrecipede b,
         t_bse_chargeitem d,
         (select distinct usageid_chr
                     from t_opr_setusage
                    where type_int = ?) f,
         t_bse_usagetype g,
         t_bse_medicine m,
         t_bse_employee e,
         t_opr_outpatientcasehis c
   where a.outpatrecipeid_chr =?
     and a.outpatrecipeid_chr = b.outpatrecipeid_chr
     and b.itemid_chr = d.itemid_chr
     and d.usageid_chr = f.usageid_chr
     and g.usageid_chr = d.usageid_chr
     and d.itemsrcid_vchr = m.medicineid_chr(+)
     and a.diagdr_chr = e.empid_chr(+)  and a.casehisid_chr = c.casehisid_chr(+) 
union all
select distinct  a.pstauts_int, b.outpatrecipedeid_chr, b.itemid_chr,
         b.itemunit_vchr as unitid_chr, '' as usageid_chr, 0 as tolqty_dec,
         0 as unitprice_mny, b.tolprice_mny,
         case b.rowno_chr
            when '0'
               then ''
            else b.rowno_chr
         end as rowno_chr, 0 as days_int, b.qty_dec, b.discount_dec,
         '' as freqid_chr, b.itemname_vchr, b.itemunit_vchr as dosageunit_chr,
         b.itemspec_vchr, g.usagename_vchr, '' as freqname_chr, d.dosage_dec,
         m.medicineid_chr, m.medicinetypeid_chr,
         'T_TMP_OUTPATIENTOPSRECIPEDE' fromtable, e.lastname_vchr,
         g.usageid_chr as usageid, b.itemusagedetail_vchr,b.itemunit_vchr as itemunit, c.diag_vchr
    from t_opr_outpatientrecipe a,
         t_tmp_outpatientopsrecipede b,
         t_bse_chargeitem d,
         (select distinct usageid_chr
                     from t_opr_setusage
                    where type_int =?) f,
         t_bse_usagetype g,
         t_bse_medicine m,
         t_bse_employee e,
         t_opr_outpatientcasehis c
   where a.outpatrecipeid_chr =?
     and a.outpatrecipeid_chr = b.outpatrecipeid_chr
     and b.itemid_chr = d.itemid_chr
     and d.usageid_chr = f.usageid_chr
     and g.usageid_chr = d.usageid_chr
     and d.itemsrcid_vchr = m.medicineid_chr(+)
     and a.diagdr_chr = e.empid_chr(+)  and a.casehisid_chr = c.casehisid_chr(+) 
union all
select distinct  a.pstauts_int, b.outpatrecipedeid_chr, b.itemid_chr,
         b.itemunit_vchr as unitid_chr, '' as usageid_chr, 0 as tolqty_dec,
         0 as unitprice_mny, b.tolprice_mny,
         case b.rowno_chr
            when '0'
               then ''
            else b.rowno_chr
         end as rowno_chr, 0 as days_int, b.qty_dec, b.discount_dec,
         '' as freqid_chr, b.itemname_vchr, b.itemunit_vchr as dosageunit_chr,
         b.itemspec_vchr, g.usagename_vchr, '' as freqname_chr, d.dosage_dec,
         m.medicineid_chr, m.medicinetypeid_chr,
         'T_TMP_OUTPATIENTOTHRECIPEDE' fromtable, e.lastname_vchr,
         g.usageid_chr as usageid, '' as itemusagedetail_vchr,b.itemunit_vchr as itemunit , c.diag_vchr
    from t_opr_outpatientrecipe a,
         t_tmp_outpatientothrecipede b,
         t_bse_chargeitem d,
         (select distinct usageid_chr
                     from t_opr_setusage
                    where type_int = ?) f,
         t_bse_usagetype g,
         t_bse_medicine m,
         t_bse_employee e,
         t_opr_outpatientcasehis c
   where a.outpatrecipeid_chr = ?
     and a.outpatrecipeid_chr = b.outpatrecipeid_chr
     and b.itemid_chr = d.itemid_chr
     and d.usageid_chr = f.usageid_chr
     and g.usageid_chr = d.usageid_chr
     and d.itemsrcid_vchr = m.medicineid_chr(+)
     and a.diagdr_chr = e.empid_chr(+)
     and a.casehisid_chr = c.casehisid_chr(+) 
order by rowno_chr ";
            #endregion
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] DataParaArr = null;
                objHRPSvc.CreateDatabaseParameter(12, out DataParaArr);
                DataParaArr[0].Value = strUsageType;
                DataParaArr[1].Value = strRecipedeID;
                DataParaArr[2].Value = strUsageType;
                DataParaArr[3].Value = strRecipedeID;
                DataParaArr[4].Value = strUsageType;
                DataParaArr[5].Value = strRecipedeID;
                DataParaArr[6].Value = strUsageType;
                DataParaArr[7].Value = strRecipedeID;
                DataParaArr[8].Value = strUsageType;
                DataParaArr[9].Value = strRecipedeID;
                DataParaArr[10].Value = strUsageType;
                DataParaArr[11].Value = strRecipedeID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQLNew, ref dt, DataParaArr);
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

        #region 根据病人ID与处方号,取出过敏表信息,当处方号为空的时候,根据病人ID取最后一条信息
        /// <summary>
        /// 根据病人ID与处方号,取出过敏表信息,当处方号为空的时候,根据病人ID取最后一条信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strID"></param>
        /// <param name="p_objResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAllergicByPidOutPid(System.Security.Principal.IPrincipal p_objPrincipal, string p_strPATIENTID, string p_strOUTPATRECIPEID, out clsT_opr_allergic p_objResult, out int p_intRecordCount)
        {
            p_objResult = new clsT_opr_allergic();
            p_intRecordCount = 0;
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsinjectInfoSvc", "m_lngGetAllergicByPidOutPid");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = "";
            if (p_strOUTPATRECIPEID != "")
            {
                strSQL = @"SELECT * FROM t_opr_allergic WHERE OUTPATRECIPEID_CHR = '" + p_strOUTPATRECIPEID + "' AND PATIENTID_CHR = '" + p_strPATIENTID + "' ORDER BY CREATE_DAT DESC";
            }
            else
            {
                strSQL = @"SELECT * FROM t_opr_allergic WHERE  PATIENTID_CHR = '" + p_strPATIENTID + "' ORDER BY CREATE_DAT DESC";
            }
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                p_intRecordCount = dtbResult.Rows.Count;
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResult = new clsT_opr_allergic();
                    p_objResult.m_strPATIENTID_CHR = dtbResult.Rows[0]["PATIENTID_CHR"].ToString().Trim();
                    p_objResult.m_strCREATE_DAT = Convert.ToDateTime(dtbResult.Rows[0]["CREATE_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                    p_objResult.m_strALLERGICMED_VCHR = dtbResult.Rows[0]["ALLERGICMED_VCHR"].ToString().Trim();
                    p_objResult.m_strALLERGICDESC_VCHR = dtbResult.Rows[0]["ALLERGICDESC_VCHR"].ToString().Trim();
                    p_objResult.m_intSTATUS_INT = Convert.ToInt32(dtbResult.Rows[0]["STATUS_INT"].ToString().Trim());
                    p_objResult.m_strCREATEEMPID_CHR = dtbResult.Rows[0]["CREATEEMPID_CHR"].ToString().Trim();
                    p_objResult.m_strOUTPATRECIPEID_CHR = dtbResult.Rows[0]["OUTPATRECIPEID_CHR"].ToString().Trim();
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

        #region 新增过敏表信息
        /// <summary>
        /// 新增过敏表信息
        /// </summary>
        [AutoComplete]
        public long m_lngAddNewAllergic(System.Security.Principal.IPrincipal p_objPrincipal, clsT_opr_allergic p_objRecord)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsinjectInfoSvc", "m_lngAddNewAllergic");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = "INSERT INTO t_opr_allergic (PATIENTID_CHR,CREATE_DAT,ALLERGICMED_VCHR,ALLERGICDESC_VCHR,STATUS_INT,CREATEEMPID_CHR,OUTPATRECIPEID_CHR) VALUES (?,?,?,?,?,?,?)";
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(7, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objRecord.m_strPATIENTID_CHR;
                objLisAddItemRefArr[1].Value = Convert.ToDateTime(strDateTime);
                objLisAddItemRefArr[2].Value = p_objRecord.m_strALLERGICMED_VCHR;
                objLisAddItemRefArr[3].Value = p_objRecord.m_strALLERGICDESC_VCHR;
                objLisAddItemRefArr[4].Value = p_objRecord.m_intSTATUS_INT;
                objLisAddItemRefArr[5].Value = p_objRecord.m_strCREATEEMPID_CHR;
                objLisAddItemRefArr[6].Value = p_objRecord.m_strOUTPATRECIPEID_CHR;
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

        #region 修改过敏表信息(根据PATIENTID_CHR,OUTPATRECIPEID_CHR)
        /// <summary>
        /// 修改过敏表信息(根据PATIENTID_CHR,OUTPATRECIPEID_CHR)
        /// </summary>
        [AutoComplete]
        public long m_lngAlterAllergic(System.Security.Principal.IPrincipal p_objPrincipal, clsT_opr_allergic p_objRecord)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsinjectInfoSvc", "m_lngAlterAllergic");
            if (lngRes < 0)
                return lngRes;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = @"update t_opr_allergic	SET ALLERGICMED_VCHR = ?,
									ALLERGICDESC_VCHR = ?
									WHERE PATIENTID_CHR=? AND OUTPATRECIPEID_CHR=?
									";
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(4, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objRecord.m_strALLERGICMED_VCHR;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strALLERGICDESC_VCHR;
                objLisAddItemRefArr[2].Value = p_objRecord.m_strPATIENTID_CHR;
                objLisAddItemRefArr[3].Value = p_objRecord.m_strOUTPATRECIPEID_CHR;
                long lngRecEff = -1;
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
        #region 删除过敏表信息(根据PATIENTID_CHR,OUTPATRECIPEID_CHR)
        /// <summary>
        /// 删除过敏表信息(根据PATIENTID_CHR,OUTPATRECIPEID_CHR)
        /// </summary>
        [AutoComplete]
        public long m_lngDeleteAllergic(System.Security.Principal.IPrincipal p_objPrincipal, clsT_opr_allergic p_objRecord)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsinjectInfoSvc", "m_lngDeleteAllergic");
            if (lngRes < 0)
                return lngRes;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = @"delete t_opr_allergic	WHERE PATIENTID_CHR=? AND OUTPATRECIPEID_CHR=?
									";
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objRecord.m_strPATIENTID_CHR;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strOUTPATRECIPEID_CHR;
                long lngRecEff = -1;
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

        #region 删除过敏表信息(根据PATIENTID_CHR,CREATE_DAT)
        /// <summary>
        /// 删除过敏表信息(根据PATIENTID_CHR,OUTPATRECIPEID_CHR)
        /// </summary>
        [AutoComplete]
        public long m_lngDeleteAllergic(System.Security.Principal.IPrincipal p_objPrincipal, string p_strPATIENTID_CHR, string p_strCreateDate)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsinjectInfoSvc", "m_lngDeleteAllergic");
            if (lngRes < 0)
                return lngRes;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = @"delete t_opr_allergic	WHERE PATIENTID_CHR=? AND CREATE_DAT=?
									";
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_strPATIENTID_CHR;
                objLisAddItemRefArr[1].Value = Convert.ToDateTime(p_strCreateDate);
                long lngRecEff = -1;
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

        #region 根据病人ID取出t_bse_patient表过敏表信息
        /// <summary>
        /// 根据病人ID取出t_bse_patient表过敏表信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strID"></param>
        /// <param name="p_objResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAllergicByPidFromTBSEPatient(System.Security.Principal.IPrincipal p_objPrincipal, string p_strPATIENTID, out string p_strIFALLERGIC, out string p_strALLERGICDESC)
        {

            p_strIFALLERGIC = "";
            p_strALLERGICDESC = "";

            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsinjectInfoSvc", "m_lngGetAllergicByPidFromTBSEPatient");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT IFALLERGIC_INT, ALLERGICDESC_VCHR
							 FROM t_bse_patient WHERE PATIENTID_CHR = '" + p_strPATIENTID + "' ";
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();

                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_strIFALLERGIC = dtbResult.Rows[0]["IFALLERGIC_INT"].ToString().Trim(); ;
                    p_strALLERGICDESC = dtbResult.Rows[0]["ALLERGICDESC_VCHR"].ToString().Trim();
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
        #region 根据处方ID取出病人注射治疗单据签名信息
        /// <summary>
        /// 根据处方ID取出病人注射治疗单据签名信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strRecipeID"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetSignInfoByRecipeID(System.Security.Principal.IPrincipal p_objPrincipal, string m_strRecipeID, out string m_strHasorNot)
        {

            m_strHasorNot = "0";
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsinjectInfoSvc", "m_lngGetSignInfoByRecipeID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"select a.seq_int, a.operatorid_chr, a.exectime_dat, a.operatortype_int
  from t_opr_nurseexecute a
 where a.business_int = 0
   and a.outpatrecipeid_chr = ?
   and a.status_int = 1
union all
select a.seq_int, a.operatorid_chr, a.exectime_dat, a.operatortype_int
  from t_opr_nurseexecute a
 where a.business_int = 3
   and a.outpatrecipeid_chr = ?
   and a.status_int = 1";
            try
            {
                DataTable dtbResult = new DataTable();
                IDataParameter[] m_objParaArr = null;
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(2, out m_objParaArr);
                m_objParaArr[0].Value = m_strRecipeID;
                m_objParaArr[1].Value = m_strRecipeID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, m_objParaArr);
                objHRPSvc.Dispose();

                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    m_strHasorNot = "1";
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
    }
}
