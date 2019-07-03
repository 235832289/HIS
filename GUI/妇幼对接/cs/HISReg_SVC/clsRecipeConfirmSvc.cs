using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.Utility;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.middletier.HIS
{
    #region 费用确认----查询类
    /// <summary>
    /// 费用确认----查询类
    /// </summary>
    [Transaction(TransactionOption.Supported)]
    [ObjectPooling(true)]
    public class clsRecipeConfirmQuerySvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 查找处方诊疗项目
        /// <summary>
        /// 查找处方诊疗项目
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthFindRecipeDetailOrder(string ID, out DataTable dt)
        {
            dt = new DataTable();
            long lngRes = 0;

            string strSQL = @"select a.orderid_int, a.outpatrecipeid_chr, a.tableindex_int,
                                     a.orderque_int, a.orderdicid_chr, a.orderdicname_vchr, a.spec_vchr,
                                     a.qty_dec, a.attachid_vchr, a.sampleid_vchr, a.checkpartid_vchr,
                                     a.pricemny_dec, a.totalmny_dec, a.attachorderid_vchr,
                                     a.attachorderbasenum_dec, b.status_int, d.sample_type_desc_vchr,
                                     f.partname, b.usercode_chr, b.engname_vchr, a.usageid_chr,
                                     b.lisapplyunitid_chr, b.applytypeid_chr, a.sbbasemny_dec,b.itemid_chr
                                from t_opr_outpatient_orderdic a,
                                     t_bse_bih_orderdic b,
                                     t_aid_lis_sampletype d,
                                     ar_apply_partlist f
                               where a.orderdicid_chr = b.orderdicid_chr
                                 and a.sampleid_vchr = d.sample_type_id_chr(+)
                                 and a.checkpartid_vchr = f.partid(+)
                                 and a.outpatrecipeid_chr = ?
                            order by a.tableindex_int, a.orderque_int ";

            clsHRPTableService objHRPSvc = null;
            IDataParameter[] ParamArr = null;

            try
            {
                objHRPSvc = new clsHRPTableService();
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
                objLogger = null;
            }
            finally
            {
                objHRPSvc.Dispose();
                objHRPSvc = null;
            }
            return lngRes;
        }
        #endregion

        #region 查询诊疗项目是否已经做好
        /// <summary>
        /// 查询诊疗项目是否已经做好
        /// </summary>
        /// <param name="p_strRecNo">处方号</param>
        /// <param name="p_strOrderDicId">诊疗项目id</param>
        /// <param name="p_intType">1-检验表 2-检查表</param>
        /// <param name="p_dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngQueryDiagnosisItemStatus(string p_strRecNo, string p_strOrderDicId, int p_intType, out DataTable p_dtbResult)
        {
            long lngRes = -1;
            p_dtbResult = null;
            string strSql = string.Empty;

            if (p_intType == 1)     //检验
            {
                strSql = @"select a.outpatrecipeid_chr,
                              a.orderdicid_chr,
                              decode(d.status_int, 3, 1, 4, 1, 5, 1, 6, 1, 0) as isfinish
                         from t_opr_outpatient_orderdic a, t_opr_lis_sample d
                        where a.attachid_vchr = d.application_id_chr
                          and d.status_int > 0
                          and a.tableindex_int = 3
                          and a.orderdicid_chr = ?
                          and a.outpatrecipeid_chr = ?";
            }
            else if (p_intType == 2)//检查
            {
                /*strSql = @"select a.outpatrecipeid_chr,
                               a.orderdicid_chr,
                               decode(d.status_int, 2, 1, 0) as isfinish
                          FROM t_opr_outpatient_orderdic a,
                               t_opr_attachrelation      c,
                               ar_common_apply           d
                         where a.outpatrecipeid_chr = c.sourceitemid_vchr
                           and c.attachid_vchr = d.applyid
                           and a.tableindex_int = 4
                           and a.orderdicid_chr = ?
                           and a.outpatrecipeid_chr = ?";*/
                strSql = @"select a.outpatrecipeid_chr,
                               a.orderdicid_chr,
                               decode(d.status_int, 2, 1, 1, 1, 0) as isfinish
                          FROM t_opr_outpatient_orderdic a, ar_common_apply d
                         where a.attachid_vchr = d.applyid
                           and a.tableindex_int = 4
                           and a.orderdicid_chr = ?
                           and a.outpatrecipeid_chr = ? ";
            }
            else if (p_intType == 3)//手术/治疗表
            {
                strSql = @"select a.outpatrecipeid_chr,
                               a.orderdicid_chr,
                               decode(d.status_int, 2, 1, 1, 1, 0) as isfinish
                          FROM t_opr_outpatient_orderdic a, t_opr_opsapply d
                         where /*a.attachid_vchr = d.applyid_vchr
                           and*/ a.tableindex_int = 5
                           and a.outpatrecipeid_chr = d.outpatrecipeid_chr
                           and d.status_int in (0, 1)
                           and a.orderdicid_chr = ?
                           and a.outpatrecipeid_chr =?";
            }

            if (string.IsNullOrEmpty(strSql))
            {
                return lngRes;
            }

            clsHRPTableService objHRPSvc = null;
            IDataParameter[] objParamArr = null;
            try
            {
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(2, out objParamArr);
                objParamArr[0].Value = p_strOrderDicId;
                objParamArr[1].Value = p_strRecNo;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql, ref p_dtbResult, objParamArr);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            finally
            {
                if (objHRPSvc != null)
                {
                    objHRPSvc.Dispose();
                    objHRPSvc = null;
                }
            }

            return lngRes;
        }
        #endregion

        #region
        [AutoComplete]
        public long m_mthFindRecipeDetail6(System.Security.Principal.IPrincipal p_objPrincipal, string ID, out DataTable dt, bool flag)
        {
            dt = new DataTable();
            long lngRes = 0;
            //clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS", "m_mthFindRecipeDetail6");
            //if (lngRes < 0)
            //{
            //    return -1;
            //}
            string strTableName = "t_tmp_outpatientothrecipede";
            if (flag)
            {
                strTableName = "t_opr_outpatientothrecipede";
            }
            string strSQL = @"select a.itemid_chr itemid,
       a.itemunit_vchr unit,
       a.qty_dec quantity,
       a.deptmed_int,
       a.unitprice_mny price,
       a.tolprice_mny summoney,
       b.itemengname_vchr,
       a.itemusagedetail_vchr,
       b.ifstop_int,
       a.itemname_vchr itemname,
       a.itemspec_vchr dec,
       b.itemopinvtype_chr,
       b.itemcode_vchr,
       b.itemopinvtype_chr invtype,
       b.itemcatid_chr catid,
       a.discount_dec,
       a.attachid_vchr,
       b.selfdefine_int selfdefine,
       1 times,
       a.usageparentid_vchr,
       a.attachparentid_vchr,
       a.attachitembasenum_dec,
       a.usageitembasenum_dec,
       a.rowno_chr,
       b.itemspec_vchr spec,
       b.itemprice_mny,
       b.itemunit_chr
  from " + strTableName + @" a, t_bse_chargeitem b
 where a.itemid_chr = b.itemid_chr(+)
   and outpatrecipeid_chr = ?
 order by a.rowno_chr";

            clsHRPTableService objHRPSvc = null;
            IDataParameter[] ParamArr = null;

            try
            {
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = ID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
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
            }
            return lngRes;
        }
        #endregion

        #region 查询处方明细
        /// <summary>
        /// 查询处方明细
        /// </summary>
        /// <param name="p_strRecipe"></param>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        public long m_mthRecipeDetail(string p_strRecipe, out DataTable dtResult)
        {
            dtResult = new DataTable();
            long lngRes = 0;
//            string strSQL = @" select d.outpatrecipedeid_chr,d.id, d.usageparentid_vchr, d.itemid_chr, d.name, d.dec, d.count, d.price, d.pdcarea_vchr, d.uint,
//                                    e.lastname_vchr,decode(g.status_int, 1, 1, 0) status
//                              from t_opr_outpatientrecipe c,
//                                   (/*select a.usageparentid_vchr, a.itemid_chr, a.outpatrecipedeid_chr, a.outpatrecipeid_chr id, a.itemname_vchr name,
//                                           a.unitid_chr uint, a.itemspec_vchr dec, a.tolqty_dec count,
//                                           b.pdcarea_vchr, a.unitprice_mny price
//                                      from t_tmp_outpatientpwmrecipede a, t_bse_chargeitem b
//                                     where a.itemid_chr = b.itemid_chr(+)
//                                    union all
//                                    select a.usageparentid_vchr, a.itemid_chr, a.outpatrecipedeid_chr, a.outpatrecipeid_chr id, b.itemname_vchr name,
//                                           a.unitid_chr uint, a.itemspec_vchr dec, a.qty_dec*a.times_int count,
//                                           b.pdcarea_vchr, a.unitprice_mny price
//                                      from t_tmp_outpatientcmrecipede a, t_bse_chargeitem b
//                                     where a.itemid_chr = b.itemid_chr(+)
//                                    union all*/
//                                    select a.usageparentid_vchr, a.itemid_chr, a.outpatrecipedeid_chr, a.outpatrecipeid_chr id, a.itemname_vchr name,
//                                           b.itemunit_chr uint, a.itemspec_vchr dec, a.qty_dec count,
//                                           b.pdcarea_vchr, a.price_mny price
//                                      from t_tmp_outpatientchkrecipede a, t_bse_chargeitem b
//                                     where a.itemid_chr = b.itemid_chr(+)
//                                    union all
//                                    select a.usageparentid_vchr, a.itemid_chr, a.outpatrecipedeid_chr, a.outpatrecipeid_chr id, a.itemname_vchr name,
//                                           b.itemunit_chr uint, a.itemspec_vchr dec, a.qty_dec count,
//                                           b.pdcarea_vchr, a.price_mny price
//                                      from t_tmp_outpatienttestrecipede a, t_bse_chargeitem b
//                                     where a.itemid_chr = b.itemid_chr(+)
//                                    union all
//                                    select a.usageparentid_vchr, a.itemid_chr, a.outpatrecipedeid_chr, a.outpatrecipeid_chr id, a.itemname_vchr name,
//                                           b.itemunit_chr uint, a.itemspec_vchr dec, a.qty_dec count,
//                                           b.pdcarea_vchr, a.price_mny price
//                                      from t_tmp_outpatientopsrecipede a, t_bse_chargeitem b
//                                     where a.itemid_chr = b.itemid_chr(+)
//                                    union all
//                                    select a.usageparentid_vchr, a.itemid_chr, a.outpatrecipedeid_chr, a.outpatrecipeid_chr id, a.itemname_vchr name,
//                                           a.unitid_chr uint, a.itemspec_vchr dec, a.qty_dec count,
//                                           b.pdcarea_vchr, a.unitprice_mny price
//                                      from t_tmp_outpatientothrecipede a, t_bse_chargeitem b
//                                     where a.itemid_chr = b.itemid_chr(+)) d,
//                                   t_bse_employee e,
//                                   t_opr_itemconfirm g
//                             where c.recordemp_chr = e.empid_chr(+)
//                               and c.outpatrecipeid_chr = d.id(+)
//                               and d.outpatrecipedeid_chr = g.outpatrecipedeid_chr(+)
//                               and (d.usageparentid_vchr like '[PK]%' or d.usageparentid_vchr is null)
//                               and c.outpatrecipeid_chr = ?";
            string strSQL = @"select c.* ,decode( d.status_int,1,1,0) status from (select a.attachorderid_vchr usageparentid_vchr,
                                       b.itemid_chr,
                                       trim(a.orderid_int) outpatrecipedeid_chr,
                                       a.outpatrecipeid_chr ID,
                                       a.orderdicname_vchr name,
                                       '' uint,
                                       b.DES_VCHR dec,
                                       a.qty_dec count,
                                       a.totalmny_dec price,
                                       a.tableindex_int
                                  from t_opr_outpatient_orderdic a,
                                       t_bse_bih_orderdic        b,
                                       t_aid_lis_sampletype      d,
                                       ar_apply_partlist         f
                                 where a.orderdicid_chr = b.orderdicid_chr
                                   and a.sampleid_vchr = d.sample_type_id_chr(+)
                                   and a.checkpartid_vchr = f.partid(+)
                                   and a.outpatrecipeid_chr = ?
                                union all
                                select a.usageparentid_vchr,
                                       a.itemid_chr,
                                       a.outpatrecipedeid_chr,
                                       a.outpatrecipeid_chr   id,
                                       a.itemname_vchr        name,
                                       a.unitid_chr           uint,
                                       a.itemspec_vchr        dec,
                                       a.qty_dec              count,
                                       a.unitprice_mny        price,
                                       8                      tableindex_int
                                  from t_tmp_outpatientothrecipede a, t_bse_chargeitem b
                                 where a.itemid_chr = b.itemid_chr(+)
                                   and (a.usageparentid_vchr like '[PK]%' or a.usageparentid_vchr is null)
                                   and a.outpatrecipeid_chr = ?) c,
                                   (select *
                                  from t_opr_itemconfirm t
                                 where t.status_int = 1
                                   and t.outpatrecipeid_chr = ?) d 
                                   where c.id = d.outpatrecipeid_chr(+)
                                     and c.outpatrecipedeid_chr = d.outpatrecipedeid_chr(+) order by c.itemid_chr";

            clsHRPTableService objHRPSvc = null;
            IDataParameter[] ParamArr = null;

            try
            {
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                ParamArr[0].Value = p_strRecipe;
                ParamArr[1].Value = p_strRecipe;
                ParamArr[2].Value = p_strRecipe;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, ParamArr);
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
            }
            return lngRes;
        }
        #endregion

        #region 查询项目明细
        /// <summary>
        /// 查询项目明细
        /// </summary>
        /// <param name="p_strRecipeNO"></param>
        /// <param name="p_strPatientID"></param>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetItemDetails(string p_strRecipeNO, string p_strPatientID,string p_strItemID,string p_strType, out DataTable dtResult)
        {
            dtResult = new DataTable();
            long lngRes = 0;
            string p_strChildID = p_strPatientID.Replace("[PK]", "");
//            string strSQL = @" select d.outpatrecipedeid_chr,d.id, d.usageparentid_vchr, d.itemid_chr, d.name, d.dec, d.count, d.price, d.pdcarea_vchr, d.uint,
//                                    e.lastname_vchr
//                              from t_opr_outpatientrecipe c,
//                                   (select a.usageparentid_vchr, a.itemid_chr, a.outpatrecipedeid_chr, a.outpatrecipeid_chr id, a.itemname_vchr name,
//                                           a.unitid_chr uint, a.itemspec_vchr dec, a.tolqty_dec count,
//                                           b.pdcarea_vchr, a.unitprice_mny price
//                                      from t_tmp_outpatientpwmrecipede a, t_bse_chargeitem b
//                                     where a.itemid_chr = b.itemid_chr(+)
//                                    union all
//                                    select a.usageparentid_vchr, a.itemid_chr, a.outpatrecipedeid_chr, a.outpatrecipeid_chr id, b.itemname_vchr name,
//                                           a.unitid_chr uint, a.itemspec_vchr dec, a.qty_dec*a.times_int count,
//                                           b.pdcarea_vchr, a.unitprice_mny price
//                                      from t_tmp_outpatientcmrecipede a, t_bse_chargeitem b
//                                     where a.itemid_chr = b.itemid_chr(+)
//                                    union all
//                                    select a.usageparentid_vchr, a.itemid_chr, a.outpatrecipedeid_chr, a.outpatrecipeid_chr id, a.itemname_vchr name,
//                                           b.itemunit_chr uint, a.itemspec_vchr dec, a.qty_dec count,
//                                           b.pdcarea_vchr, a.price_mny price
//                                      from t_tmp_outpatientchkrecipede a, t_bse_chargeitem b
//                                     where a.itemid_chr = b.itemid_chr(+)
//                                    union all
//                                    select a.usageparentid_vchr, a.itemid_chr, a.outpatrecipedeid_chr, a.outpatrecipeid_chr id, a.itemname_vchr name,
//                                           b.itemunit_chr uint, a.itemspec_vchr dec, a.qty_dec count,
//                                           b.pdcarea_vchr, a.price_mny price
//                                      from t_tmp_outpatienttestrecipede a, t_bse_chargeitem b
//                                     where a.itemid_chr = b.itemid_chr(+)
//                                    union all
//                                    select a.usageparentid_vchr, a.itemid_chr, a.outpatrecipedeid_chr, a.outpatrecipeid_chr id, a.itemname_vchr name,
//                                           b.itemunit_chr uint, a.itemspec_vchr dec, a.qty_dec count,
//                                           b.pdcarea_vchr, a.price_mny price
//                                      from t_tmp_outpatientopsrecipede a, t_bse_chargeitem b
//                                     where a.itemid_chr = b.itemid_chr(+)
//                                    union all
//                                    select a.usageparentid_vchr, a.itemid_chr, a.outpatrecipedeid_chr, a.outpatrecipeid_chr id, a.itemname_vchr name,
//                                           a.unitid_chr uint, a.itemspec_vchr dec, a.qty_dec count,
//                                           b.pdcarea_vchr, a.unitprice_mny price
//                                      from t_tmp_outpatientothrecipede a, t_bse_chargeitem b
//                                     where a.itemid_chr = b.itemid_chr(+)) d,
//                                   t_bse_employee e
//                             where c.recordemp_chr = e.empid_chr(+)
//                               and c.outpatrecipeid_chr = d.id(+)
//                               and c.outpatrecipeid_chr = ?
//                               [PatientID]";
            string strSQL = string.Empty;
            //检验
            if (p_strType == "3")
            {
                strSQL = @" select a.orderid_vchr orderid_vchr, a.attachid_vchr,a.usageparentid_vchr,
                               a.itemid_chr,
                               a.outpatrecipedeid_chr,
                               a.outpatrecipeid_chr   id,
                               a.itemname_vchr        name,
                               ''           uint,
                               a.itemspec_vchr        dec,
                               a.qty_dec              count,
                               b.pdcarea_vchr,
                               a.tolprice_mny        price
                          from t_tmp_outpatientchkrecipede a, t_bse_chargeitem b
                         where a.itemid_chr = b.itemid_chr(+)
                         and a.outpatrecipeid_chr = ?
                         and a.orderid_vchr = ?";
            }
            //检查
            if (p_strType == "4")
            {
                strSQL = @"select a.orderid_vchr orderid_vchr, a.attachid_vchr,a.usageparentid_vchr,
                           a.itemid_chr,
                           a.outpatrecipedeid_chr,
                           a.outpatrecipeid_chr   id,
                           a.itemname_vchr        name,
                           ''           uint,
                           a.itemspec_vchr        dec,
                           a.qty_dec              count,
                           b.pdcarea_vchr,
                           a.tolprice_mny        price
                      from t_tmp_outpatienttestrecipede a, t_bse_chargeitem b
                     where a.itemid_chr = b.itemid_chr(+)
                     and a.outpatrecipeid_chr = ?
                     and a.orderid_vchr = ?";
            }
            //手术
            if (p_strType == "5")
            {
                strSQL = @"select a.orderid_vchr orderid_vchr, a.attachid_vchr,a.usageparentid_vchr,
                               a.itemid_chr,
                               a.outpatrecipedeid_chr,
                               a.outpatrecipeid_chr   id,
                               a.itemname_vchr        name,
                               ''           uint,
                               a.itemspec_vchr        dec,
                               a.qty_dec              count,
                               b.pdcarea_vchr,
                               a.tolprice_mny        price
                          from t_tmp_outpatientopsrecipede a, t_bse_chargeitem b
                         where a.itemid_chr = b.itemid_chr(+)
                         and a.outpatrecipeid_chr = ?
                         and a.orderid_vchr = ?";
            }
            //材料
            if (p_strType == "8")
            {
                strSQL = @"select a.usageparentid_vchr,
       a.itemid_chr,
       a.outpatrecipedeid_chr,
       a.outpatrecipeid_chr   id,
       a.itemname_vchr        name,
       a.unitid_chr           uint,
       a.itemspec_vchr        dec,
       a.qty_dec              count,
       a.tolprice_mny        price,
       8                      tableindex_int
  from t_tmp_outpatientothrecipede a, t_bse_chargeitem b
 where a.itemid_chr = b.itemid_chr(+)
   and (a.usageparentid_vchr like '[PK]%' or a.usageparentid_vchr is null)
   and a.outpatrecipeid_chr = ?
and a.itemid_chr = ?";
            }

            clsHRPTableService objHRPSvc = null;
            IDataParameter[] ParamArr = null;

            try
            {
                objHRPSvc = new clsHRPTableService();
                string strTemp = "";
                if (p_strType == "3" || p_strType == "4" || p_strType == "5")
                {
                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = p_strRecipeNO;
                    ParamArr[1].Value = p_strChildID;
                }
                if (p_strType == "8")
                {
                    objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                    ParamArr[0].Value = p_strRecipeNO;
                    ParamArr[1].Value = p_strItemID;
                }
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, ParamArr);
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
            }
            return lngRes;
        }
        #endregion

        #region 权限判断
        /// <summary>
        /// 权限判断
        /// </summary>
        /// <param name="p_strEmpid"></param>
        /// <returns></returns>
        [AutoComplete]
        public bool m_blnCompetence(string p_strEmpid)
        {
            bool blnRes = false;
            string strSql = @"select *
                              from t_sys_emprolemap a, t_sys_role b
                             where a.roleid_chr = b.roleid_chr
                             and a.empid_chr = ?
                               and b.name_vchr like '%取消确认%'";
            clsHRPTableService objHRPSvc = null;
            DataTable dtResult = new DataTable();
            IDataParameter[] ParamArr = null;
            try
            {
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = p_strEmpid;
                long lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql, ref dtResult, ParamArr);
                if (lngRes > 0 && dtResult.Rows.Count > 0)
                {
                    blnRes = true;
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx);
                objLogger = null;
            }
            finally
            {
                objHRPSvc.Dispose();
                objHRPSvc = null;
            }
            return blnRes;
        }
        #endregion

        #region 查询病人处方
        [AutoComplete]
        public long m_lngGetPatientInfoByCardID(string p_strCardno, out clsRecipeInfo_VO[] objRI_VO)
        {
            long lngRes = -1;
            objRI_VO = null;
            DataTable dtResult = new DataTable();
            string strSql = @"select a.patientname_chr,a.recorddate_dat,
                                   a.invoiceno_vchr,
                                   d.patientcardid_chr,
                                   b.sex_chr,
                                   a.outpatrecipeid_chr,
                                   b.idcard_chr,
                                   a.deptname_chr,
                                   b.mobile_chr,
                                   a.totalsum_mny
                              from t_opr_outpatientrecipeinv a, t_bse_patient b, t_bse_patientcard d
                             where a.patientid_chr = b.patientid_chr
                               and a.patientid_chr = d.patientid_chr
                               and a.isvouchers_int = 2
                               and d.patientcardid_chr = ?
                               and not exists (select t.invoiceno_vchr
                                      from t_opr_outpatientrecipeinv t
                                     where t.isvouchers_int = 2
                                       and t.status_int = 2
                                       and a.invoiceno_vchr = t.invoiceno_vchr)
                             and exists
                             (select t.outpatrecipeid_chr
                                      from t_opr_outpatientrecipe t
                                     where t.pstauts_int <> -1
                                       and a.outpatrecipeid_chr = t.outpatrecipeid_chr)  order by recorddate_dat desc";
            clsHRPTableService objHRPSvc = null;
            dtResult = new DataTable();
            IDataParameter[] ParamArr = null;
            try
            {
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = p_strCardno;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql, ref dtResult, ParamArr);
                if (lngRes > 0 && dtResult.Rows.Count > 0)
                {
                    objRI_VO = new clsRecipeInfo_VO[dtResult.Rows.Count];
                    for (int i = 0; i < dtResult.Rows.Count; i++)
                    {
                        objRI_VO[i] = new clsRecipeInfo_VO();
                        objRI_VO[i].m_intPSTATUS_INT = 5;
                        objRI_VO[i].m_strOUTPATRECIPEID_CHR = dtResult.Rows[i]["OUTPATRECIPEID_CHR"].ToString();
                        objRI_VO[i].m_strCreatTime = dtResult.Rows[i]["recorddate_dat"].ToString();
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx);
                objLogger = null;
            }
            finally
            {
                objHRPSvc.Dispose();
                objHRPSvc = null;
            }
            return lngRes;
        }
        #endregion
    }
    #endregion

    #region 费用确认----操作类
    /// <summary>
    /// 费用确认----操作类
    /// </summary>
    [Transaction(TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsRecipeConfirmOpSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 更改申请单状态
        /// <summary>
        /// 更改申请单状态
        /// </summary>
        /// <param name="p_Recipe"></param>
        /// <param name="p_listApp"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngModiffyAppStatus(com.digitalwave.iCare.ValueObject.clsOutpatientRecipe_VO[] objRecipeVO)
        {
            //foreach (KeyValuePair<string, string> kvp in p_dicApp)
            //{
            //    if (kvp.Value.ToString() == "lis")
            //    {
            //        this.m_lngModiffyLisAppStatus(p_Recipe, kvp.Key.ToString());
            //    }

            //    if (kvp.Value.ToString() == "test")
            //    {
            //        this.m_lngModiffyTestAppStatus(p_Recipe, kvp.Key.ToString());
            //    }

            //    if (kvp.Value.ToString() == "ops")
            //    {
            //        this.m_lngModiffyOpsAppStatus(p_Recipe, kvp.Key.ToString());
            //    }
            //}  
            long lngRes = -1;
            string strSQL = string.Empty;
            long lngEff = -1;
            strSQL = @"insert into t_opr_itemconfirm
                                              (outpatrecipedeid_chr,
                                               outpatrecipeid_chr,
                                               empno_vchr,record_dat,status_int)
                                            values
                                              ( ?, ?, ?, sysdate, 1)";
            clsHRPTableService objHRPSvc = null;
            try
            {
                int intRowsCount = objRecipeVO.Length;
                object[][] objParams = new object[3][];
                for (int i1 = 0; i1 < 3; i1++)
                {
                    objParams[i1] = new object[intRowsCount];
                }
                for (int i1 = 0; i1 < intRowsCount; i1++)
                {
                    objParams[0][i1] = objRecipeVO[i1].m_strOutpatRecipeID.Trim();
                    objParams[1][i1] = objRecipeVO[i1].m_strOutpatRecipeNo.Trim();
                    objParams[2][i1] = objRecipeVO[i1].strDIAG_VCHR.Trim();
                }
                DbType[] objTypes = new DbType[3] {DbType.String, DbType.String, DbType.String};
                objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.m_lngSaveArrayWithParameters(strSQL, objParams, objTypes);
            }
            catch (Exception objEX)
            {
                clsLogText objLog = new clsLogText();
                objLog.LogError(objEX);
            }
            finally
            {
                if (objHRPSvc != null)
                {
                    objHRPSvc.Dispose();
                    objHRPSvc = null;
                }
            }
            return lngRes;
        }

        [AutoComplete]
        public long m_lngModiffyLisAppStatus(string p_Recipe, string strOrderid)
        {
            long lngRes = -1;
            string strSQL = string.Empty;
            long lngEff = -1;
            strSQL = @"update t_opr_lis_sample t
                               set t.status_int = 3
                             where t.application_id_chr = ?";
            clsHRPTableService objHRPSvc = null;
            IDataParameter[] objParamArr = null;
            try
            {
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(1, out objParamArr);
                objParamArr[0].Value = strOrderid;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngEff, objParamArr);
            }
            catch (Exception objEX)
            {
                clsLogText objLog = new clsLogText();
                objLog.LogError(objEX);
            }
            finally
            {
                if (objHRPSvc != null)
                {
                    objHRPSvc.Dispose();
                    objHRPSvc = null;
                }
            }
            return lngRes;
        }

        [AutoComplete]
        public long m_lngModiffyTestAppStatus(string p_Recipe, string strOrderid)
        {
            long lngRes = -1;
            string strSQL = string.Empty;
            long lngEff = -1;
            strSQL = @"update ar_common_apply t
                           set t.status_int = 1
                         where t.applyid = ?";
            clsHRPTableService objHRPSvc = null;
            IDataParameter[] objParamArr = null;
            try
            {
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(1, out objParamArr);
                objParamArr[0].Value = strOrderid;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngEff, objParamArr);
            }
            catch (Exception objEX)
            {
                clsLogText objLog = new clsLogText();
                objLog.LogError(objEX);
            }
            finally
            {
                if (objHRPSvc != null)
                {
                    objHRPSvc.Dispose();
                    objHRPSvc = null;
                }
            }
            return lngRes;
        }

        [AutoComplete]
        public long m_lngModiffyOpsAppStatus(string p_Recipe, string strOrderid)
        {
            long lngRes = -1;
            string strSQL = string.Empty;
            long lngEff = -1;
            strSQL = @"update t_opr_opsapply t
                       set t.status_int = 1
                     where t.outpatrecipeid_chr = ?";
            clsHRPTableService objHRPSvc = null;
            IDataParameter[] objParamArr = null;
            try
            {
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(1, out objParamArr);
                objParamArr[0].Value = p_Recipe;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngEff, objParamArr);
            }
            catch (Exception objEX)
            {
                clsLogText objLog = new clsLogText();
                objLog.LogError(objEX);
            }
            finally
            {
                if (objHRPSvc != null)
                {
                    objHRPSvc.Dispose();
                    objHRPSvc = null;
                }
            }
            return lngRes;
        }
        #endregion

        #region 取消确认
        /// <summary>
        /// 取消确认
        /// </summary>
        /// <param name="p_strItemid"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngItemsCancel(string p_strItemid,string p_strEmpid)
        {
            long lngRes = -1;
            string strSQL = string.Empty;
            long lngEff = -1;
            strSQL = @"  update t_opr_itemconfirm t
                       set t.status_int = 0,t.record_dat = sysdate,
                        t.empno_vchr = ?
                     where t.outpatrecipedeid_chr = ?";
            clsHRPTableService objHRPSvc = null;
            IDataParameter[] objParamArr = null;
            try
            {
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(2, out objParamArr);
                objParamArr[0].Value = p_strEmpid;
                objParamArr[1].Value = p_strItemid;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngEff, objParamArr);
            }
            catch (Exception objEX)
            {
                clsLogText objLog = new clsLogText();
                objLog.LogError(objEX);
            }
            finally
            {
                if (objHRPSvc != null)
                {
                    objHRPSvc.Dispose();
                    objHRPSvc = null;
                }
            }
            return lngRes;
        }
        #endregion
    }
    #endregion
}
