using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.Utility;

namespace com.digitalwave.iCare.middletier.HIS
{
    /// <summary>
    /// 查询类
    /// </summary>
    [Transaction(TransactionOption.Supported)]
    [ObjectPooling(true)]
    public class clsDoctorChargeQuerySvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 获取病人就诊记录
        /// <summary>
        /// 获取病人就诊记录
        /// </summary>
        /// <param name="dtVisitRec"></param>
        /// <param name="dtGetVisitRec"></param>
        /// <returns></returns>
        public long m_lngGetVisitRecList(DataTable dtVisitRec, out DataTable dtGetVisitRec)
        {
            long lngRes = -1;
            string strSQL = string.Empty;
            dtGetVisitRec = new DataTable();
            dtGetVisitRec.Columns.Add("GMSFHM", typeof(string));
            dtGetVisitRec.Columns.Add("JZLB", typeof(string));
            dtGetVisitRec.Columns.Add("JZRQ", typeof(string));
            dtGetVisitRec.Columns.Add("CYZD", typeof(string));
            dtGetVisitRec.Columns.Add("RegID", typeof(string));
            dtGetVisitRec.Columns.Add("CFID", typeof(string));
            dtGetVisitRec.Columns.Add("TreaID", typeof(string));
            dtGetVisitRec.Columns.Add("CYBQDM", typeof(string));
            dtGetVisitRec.Columns.Add("YYRYKS", typeof(string));
            dtGetVisitRec.Columns.Add("FPHM", typeof(string));
            dtGetVisitRec.Columns.Add("YLFYZE", typeof(string));
            dtGetVisitRec.Columns.Add("LXDH", typeof(string));
            dtGetVisitRec.Columns.Add("YYBH", typeof(string));
            dtGetVisitRec.Columns.Add("JZYYBH", typeof(string));
            dtGetVisitRec.Columns.Add("YSGH", typeof(string));
            dtGetVisitRec.Columns.Add("BZ", typeof(string));
            clsHRPTableService objHRPSvc = null;
            DataTable dtTemp = new DataTable();
            try
            {
                //                strSQL = @"select m.idcard_chr GMSFHM,
                //                                   case
                //                                     when b.paytypeid_chr = '0015' then
                //                                      '61'
                //                                     when b.paytypeid_chr = '0018' or b.paytypeid_chr = '0022' or
                //                                          b.paytypeid_chr = '0025' then
                //                                      '53'
                //                                     when b.paytypeid_chr = '0021' then
                //                                      '81'
                //                                     else
                //                                      '00'
                //                                   end JZLB,
                //                                   b.CREATEDATE_DAT JZRQ,
                //                                   n.DIAG_VCHR CYZD,
                //                                   '03' CYBQDM,
                //                                   '' FPHM,
                //                                   c.deptname_vchr YYRYKS,
                //                                   decode(b.registerid_chr,
                //                                          null,
                //                                          substr(b.outpatrecipeid_chr, 9),
                //                                          b.registerid_chr) RegID,
                //                                   decode(b.registerid_chr,
                //                                          null,
                //                                          substr(b.outpatrecipeid_chr, 9),
                //                                          substr(b.registerid_chr,3)) TreaID,
                //                                   to_number('') YLFYZE,
                //                                   b.outpatrecipeid_chr CFID,
                //                                   m.homephone_vchr LXDH,
                //                                   '0001598' YYBH,
                //                                   '0001598' JZYYBH,
                //                                   b.diagdr_chr YSGH,
                //                                   '' BZ
                //                              from t_opr_outpatientrecipe  b,
                //                                   t_bse_deptdesc          c,
                //                                   t_bse_employee          d,
                //                                   t_bse_patient           m,
                //                                   t_opr_outpatientcasehis n
                //                             where b.diagdept_chr = c.deptid_chr(+)
                //                               and b.diagdr_chr = d.empid_chr(+)
                //                               and b.casehisid_chr = n.casehisid_chr
                //                               and c.status_int = 1
                //                               and b.pstauts_int in (4)
                //                               and b.patientid_chr = m.patientid_chr
                //                               and b.patientid_chr = ?
                //                               order by JZRQ DESC";
                strSQL = @"  select syscode_chr,
                                   parmcode_chr,
                                   parmdesc_vchr,
                                   parmvalue_vchr,
                                   status_int,
                                   note_vchr
                              from t_bse_sysparm t 
                              where t.parmcode_chr = '0074'
                              and t.status_int = 1";
                objHRPSvc = new clsHRPTableService();
                DataTable dtt = new DataTable();
                int days = 0;
                long l = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtt);
                if (l > 0 && dtt.Rows.Count > 0)
                {
                    days = Convert.ToInt32("-" + dtt.Rows[0]["parmvalue_vchr"].ToString());
                }
                strSQL = @"select   a.pstauts_int,
                                        a.paytypeid_chr,
                                        a.recipeflag_int,
                                        a.diagdr_chr,
                                        decode(a.registerid_chr,
                                                      null,
                                                      substr(a.outpatrecipeid_chr, 9),
                                                      a.registerid_chr) as registerid_chr,
                                        d.registerid_chr,
                                        c.technicalrank_chr,
                                        a.outpatrecipeid_chr as cfid,
                                        a.patientid_chr as patientid,
                                        a.createdate_dat as arrivedate,
                                        b.code_vchr as deptcode,
                                        b.deptname_vchr as deptname,
                                        (select distinct h.plandate_dat
                                            from t_opr_opdoctorplan h
                                            where h.opdcotor_chr = d.diagdoctor_chr
                                            and h.optimes_int <> 0
                                            and h.plandate_dat =
                                                to_date(to_char(a.createdate_dat, 'yyyy-mm-dd'), 'yyyy-mm-dd')
                                            and rownum = 1) as visitdate,
                                        c.empno_chr as doctorcode,
                                        c.lastname_vchr as doctorname,
                                        e.registertypeid_chr as levelcode,
                                        e.registertypename_vchr as levelname,
                                        (select distinct h.opdrplanid_chr
                                            from t_opr_opdoctorplan h
                                            where h.opdcotor_chr = d.diagdoctor_chr
                                            and h.optimes_int <> 0
                                            and h.plandate_dat =
                                                to_date(to_char(a.createdate_dat, 'yyyy-mm-dd'), 'yyyy-mm-dd')
                                            and rownum = 1) serviceno,
                                        (select distinct h.planperiod_chr
                                            from t_opr_opdoctorplan h
                                            where h.opdcotor_chr = d.diagdoctor_chr
                                            and h.optimes_int <> 0
                                            and h.plandate_dat =
                                                to_date(to_char(a.createdate_dat, 'yyyy-mm-dd'), 'yyyy-mm-dd')
                                            and rownum = 1) servicetime,
                                        f.order_int as visitseqno,
                                        g.patientcardid_chr,
                                        h.diag_vchr,
                                        i.idcard_chr,
                                        decode(i.mobile_chr, null, i.homephone_vchr,i.mobile_chr) as contactphone,
                                        a.paytypeid_chr as typename_vchr
                                    from t_opr_outpatientrecipe a,
                                        t_bse_deptdesc         b,
                                        t_bse_employee         c,
                                        t_opr_patientregister  d,
                                        t_bse_registertype     e,
                                        t_opr_waitdiaglist     f,
                                        t_bse_patientcard      g,
                                        t_opr_outpatientcasehis h,
                                        t_bse_patient           i,
                                        t_aid_recipetype        j
                                    where a.diagdept_chr = b.deptid_chr(+)
                                    and a.diagdr_chr = c.empid_chr(+)
                                    and a.registerid_chr = d.registerid_chr(+)
                                    and d.registertypeid_chr = e.registertypeid_chr(+)
                                    and a.registerid_chr = f.registerid_chr(+)
                                    and a.patientid_chr = g.patientid_chr
                                    and a.outpatrecipeid_chr=h.casehisid_chr(+)
                                    and a.patientid_chr = i.patientid_chr
                                    and a.type_int=j.type_int
                                    and g.status_int = 1
                                    and b.status_int = 1
                                    and c.status_int = 1
                                    and a.pstauts_int = 4
                                    and (a.createdate_dat between to_date(?,'yyyy-MM-dd') and to_date(?,'yyyy-MM-dd'))
                                    and g.patientid_chr = ?
                                    order by a.outpatrecipeid_chr desc";

                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                ParamArr[0].Value = DateTime.Now.AddDays(days).ToShortDateString();
                ParamArr[1].Value = DateTime.Now.ToShortDateString();
                ParamArr[2].Value = dtVisitRec.Rows[0]["PatientID"].ToString().Trim();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtTemp, ParamArr);
                if (lngRes > 0 && dtTemp.Rows.Count > 0)
                {
                    DataTable dtItem = dtTemp.Clone();
                    DataTable dtItemSum = new DataTable();
                    DataRow drOutDataRow = null;
                    decimal TotalSum = 0;
                    for (int i = 0; i < dtTemp.Rows.Count; i++)
                    {
                        //计算处方金额
                        TotalSum = 0;
                        dtItem.Clear();
                        dtItem.Rows.Add(dtTemp.Rows[i].ItemArray);
                        m_lngGetListRpItem(dtItem, out dtItemSum);
                        if (dtItemSum.Rows.Count > 0)
                        {
                            for (int j = 0; j < dtItemSum.Rows.Count; j++)
                            {
                                TotalSum += Convert.ToDecimal(dtItemSum.Rows[j]["JE"]);
                            }
                        }
                        //带出默认项目
                        string strPatientPayTypeId = dtTemp.Rows[i]["paytypeid_chr"].ToString().Trim();//病人身份
                        string strDiagDocId = dtTemp.Rows[i]["diagdr_chr"].ToString().Trim();//就诊医生ID
                        string strRegisterId = dtTemp.Rows[i]["registerid_chr"].ToString().Trim();//挂号ID
                        string strRecipeFlag = dtTemp.Rows[i]["recipeflag_int"].ToString().Trim();//自助挂号机暂时默认为付方 1-正方；2-付方
                        //职称
                        string strTechnicalRank = dtTemp.Rows[i]["technicalrank_chr"].ToString().Trim();
                        string strRecipeId = dtTemp.Rows[i]["cfid"].ToString().Trim();
                        //病人类型
                        string strPatientTypeID = strPatientPayTypeId;
                        DataTable dt;
                        DataTable p_dtbItem = null;
                        long ret = m_mthGetDefaultItem(out dt, strPatientTypeID, strRecipeFlag, strTechnicalRank, strRecipeId, strRegisterId);
                        if (ret > 0 && dt.Rows.Count > 0)
                        {
                            for (int k = 0; k < dt.Rows.Count; k++)
                            {
                                DataTable dtbTemp = null;
                                m_mthGetDefaultItemDetailCX(dt.Rows[k]["itemid_chr"].ToString().Trim(), strPatientTypeID, out dtbTemp);
                                if (dtbTemp != null && dtbTemp.Rows.Count == 1)
                                {
                                    //dtbTemp.Columns.Add("outpatrecipeid_chr", typeof(string));
                                    //DataColumn cc = new DataColumn();
                                    //cc.ColumnName = "ProNO";
                                    //cc.DefaultValue = p_strRecipeId;
                                    //dtbTemp.Columns.Add(cc);
                                    if (p_dtbItem == null)
                                    {
                                        p_dtbItem = dtbTemp;
                                    }
                                    else
                                    {
                                        p_dtbItem.Merge(dtbTemp);
                                    }
                                }
                            }
                        }
                        DataTable dtIrazu = new DataTable();
                        ret = this.m_lngGetIrazuFee(strRecipeId, strPatientTypeID, out dtIrazu);
                        if (ret > 0 && dtIrazu.Rows.Count > 0)
                        {
                            if (p_dtbItem == null)
                            {
                                p_dtbItem = dtIrazu;
                            }
                            else
                            {
                                p_dtbItem.Merge(dtIrazu);
                            }
                        }
                        if (p_dtbItem != null && p_dtbItem.Rows.Count > 0)
                        {
                            TotalSum += m_decConvertObjToDecimal(p_dtbItem.Compute("sum(JE)", ""));
                        }
                        //---------------------------------------------------------------------
                        //dr["GMSFHM"] = dtTemp.Rows[i]["GMSFHM"].ToString();
                        //dr["JZLB"] = dtTemp.Rows[i]["JZLB"].ToString();
                        //dr["JZRQ"] = Convert.ToDateTime(dtTemp.Rows[i]["JZRQ"].ToString()).ToString("yyyyMMdd");
                        //dr["CYZD"] = dtTemp.Rows[i]["CYZD"].ToString();
                        //dr["RegID"] = dtTemp.Rows[i]["RegID"].ToString();
                        //dr["CFID"] = dtTemp.Rows[i]["CFID"].ToString();
                        //dr["TreaID"] = dtTemp.Rows[i]["TreaID"].ToString();
                        //dr["CYBQDM"] = dtTemp.Rows[i]["CYBQDM"].ToString();
                        //dr["YYRYKS"] = dtTemp.Rows[i]["YYRYKS"].ToString();
                        //dr["FPHM"] = dtTemp.Rows[i]["FPHM"].ToString();
                        //dr["YLFYZE"] = dtTemp.Rows[i]["YLFYZE"].ToString();
                        //dr["LXDH"] = dtTemp.Rows[i]["LXDH"].ToString();
                        //dr["YYBH"] = dtTemp.Rows[i]["YYBH"].ToString();
                        //dr["JZYYBH"] = dtTemp.Rows[i]["JZYYBH"].ToString();
                        //dr["YSGH"] = dtTemp.Rows[i]["YSGH"].ToString();
                        //dr["BZ"] = dtTemp.Rows[i]["BZ"].ToString();
                        //dtGetVisitRec.Rows.Add(dr);
                        drOutDataRow = dtGetVisitRec.NewRow();
                        drOutDataRow["GMSFHM"] = dtTemp.Rows[i]["idcard_chr"].ToString().Length == 0 ? "*" : dtTemp.Rows[i]["idcard_chr"].ToString();//公民身份号码
                        //就诊类别 00普通 (社保) 53转诊门诊  (社区) 61特定门诊  (特定门诊)   81公务员体检 ()
                        string strJZLB = dtTemp.Rows[i]["typename_vchr"].ToString().Length == 0 ? "00" : dtTemp.Rows[i]["typename_vchr"].ToString().Trim();//就诊类别
                        switch (strJZLB)
                        {
                            case "0018":
                            case "0022":
                            case "0025"://社区
                                strJZLB = "53";
                                break;
                            case "0015"://特定门诊
                                strJZLB = "61";
                                break;
                            case "0021"://公务员体检
                                strJZLB = "81";
                                break;
                            default:
                                strJZLB = "00";
                                break;
                        }

                        drOutDataRow["JZLB"] = strJZLB;
                        //就诊日期
                        if (string.IsNullOrEmpty(dtTemp.Rows[i]["arrivedate"].ToString()))
                        {
                            drOutDataRow["JZRQ"] = System.DateTime.Now.ToString("yyyyMMdd");//就诊日期
                        }
                        else
                        {
                            drOutDataRow["JZRQ"] = DateTime.Parse(dtTemp.Rows[i]["arrivedate"].ToString()).ToString("yyyyMMdd");//就诊日期
                        }
                        drOutDataRow["CYZD"] = dtTemp.Rows[i]["diag_vchr"].ToString().Length == 0 ? "未知" : dtTemp.Rows[i]["diag_vchr"].ToString();//门诊诊断
                        drOutDataRow["RegID"] = dtTemp.Rows[i]["registerid_chr"].ToString();//号源编码
                        drOutDataRow["CFID"] = dtTemp.Rows[i]["cfid"].ToString().Trim();//费用单号(处方单据号)
                        drOutDataRow["TreaID"] = dtTemp.Rows[i]["patientcardid_chr"].ToString();//就诊编码
                        drOutDataRow["CYBQDM"] = "03";//就诊科室	社保定义的医院科室代码(不能为空，测试用03)
                        drOutDataRow["YYRYKS"] = dtTemp.Rows[i]["deptname"].ToString();//医院内部科室名称
                        drOutDataRow["FPHM"] = m_lngGetInvoice(dtTemp.Rows[i]["cfid"].ToString().Trim());//发票号码
                        drOutDataRow["YLFYZE"] = TotalSum;//处方总金额
                        drOutDataRow["LXDH"] = dtTemp.Rows[i]["contactphone"].ToString();//联系电话
                        drOutDataRow["YYBH"] = "711014";//医院编号
                        drOutDataRow["JZYYBH"] = "711014";//就诊医院编号
                        drOutDataRow["YSGH"] = dtTemp.Rows[i]["doctorcode"].ToString();//医师工号
                        drOutDataRow["BZ"] = "";//备注
                        dtGetVisitRec.Rows.Add(drOutDataRow);
                    }
                }
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx);
                objLogger = null;
                lngRes = -1;
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

        #region 获取发票号
        public string m_lngGetInvoice(string p_strOutpatrecipeId)
        {
            string strInvoiceNo = string.Empty;
            string strSQL = @"select t.invoiceno_vchr
                               from (select a.invoiceno_vchr, sum(a.totalsum_mny) as totalsum
                                       from t_opr_outpatientrecipeinv a
                                      where a.outpatrecipeid_chr = ?
                                      group by a.invoiceno_vchr) t
                              where t.totalsum > 0";
            clsHRPTableService objHRPSvc = null;
            System.Data.IDataParameter[] objLisAddItemRefArr = null;
            DataTable dtTmpTable = null;
            try
            {
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = p_strOutpatrecipeId;
                long lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtTmpTable, objLisAddItemRefArr);
                if (dtTmpTable.Rows.Count > 0)
                {
                    strInvoiceNo = dtTmpTable.Rows[0]["invoiceno_vchr"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return strInvoiceNo;
        }
        #endregion

        #region 将obj转换为数字
        /// <summary>
        /// 将obj转换为数字
        /// </summary>
        /// <param name="p_objValue"></param>
        /// <returns></returns>
        public static decimal m_decConvertObjToDecimal(object p_objValue)
        {
            decimal decValue = 0;
            if (p_objValue != null)
            {
                try
                {
                    decValue = Convert.ToDecimal(p_objValue);
                }
                catch
                {
                    decValue = 0;
                }
            }
            return decValue;
        }
        #endregion

        #region 查询就诊记录中的缴费项目
        /// <summary>
        /// 查询就诊记录中的缴费项目
        /// </summary>
        /// <param name="dtVisitRec"></param>
        /// <param name="dtGetVisitRec"></param>
        /// <returns></returns>
        public long m_lngGetListRpItem(DataTable dtListRecipe, out DataTable p_dtItemDe)
        {
            p_dtItemDe = new DataTable();
            long lngRes = 0;
            string strSQL = string.Empty;
            clsHRPTableService objHRPSvc = null;
            try
            {
                objHRPSvc = new clsHRPTableService();
                DataTable p_dtTemp = new DataTable();
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                //西药
                strSQL = @"select '0001598' YYBH,c.CREATEDATE_DAT FYRQ, (1000 + to_number(nvl(a.rowno_vchr2, 0))) as XMXH,
                                   b.itemcode_vchr as XMBH,
                                   a.itemname_vchr as XMMC,
                                   a.unitprice_mny as JG,
                                   round(a.tolqty_dec,2) as MCYL,
                                   round(a.tolprice_mny,2) as JE,
                                   '0' ZFBL,
                                   '' as BZ
                              from t_tmp_outpatientpwmrecipede a,
                                   t_bse_chargeitem            b,
                                   t_opr_outpatientrecipe      c,
                                   t_aid_inschargeitem         d
                             where a.itemid_chr = b.itemid_chr(+)
                               and a.outpatrecipeid_chr = ?
                               and d.itemid_chr = a.itemid_chr
                               and d.copayid_chr = c.paytypeid_chr
                               and a.outpatrecipeid_chr = c.outpatrecipeid_chr
                             order by XMXH";

                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = dtListRecipe.Rows[0]["CFID"].ToString().Trim();
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
                //草药
                strSQL = @"select '0001598' YYBH,c.CREATEDATE_DAT FYRQ, (2000 + to_number(nvl(a.rowno_vchr2, 0))) as XMXH,
                                   b.itemcode_vchr as XMBH,
                                   a.itemname_vchr as XMMC,
                                   a.unitprice_mny as JG,
                                   round(a.QTY_DEC,2) as MCYL,
                                   round(a.TOLPRICE_MNY,2) as Price,
                                   '0' ZFBL,
                                   '' as BZ
                              from t_tmp_outpatientcmrecipede a,
                                   t_bse_chargeitem           b,
                                   t_opr_outpatientrecipe     c,
                                   t_aid_inschargeitem        d
                             where a.itemid_chr = b.itemid_chr(+)
                               and a.outpatrecipeid_chr = ?
                               and d.itemid_chr = a.itemid_chr
                               and d.copayid_chr = c.paytypeid_chr
                               and a.outpatrecipeid_chr = c.outpatrecipeid_chr
                             order by XMXH";
                p_dtTemp.Rows.Clear();
                objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = dtListRecipe.Rows[0]["CFID"].ToString().Trim();
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
                //检查
                strSQL = @"select '0001598' YYBH,c.CREATEDATE_DAT FYRQ, (3000 + to_number(nvl(a.rowno_chr, 0))) as XMXH,
                                   b.itemcode_vchr as XMBH,
                                   a.itemname_vchr as XMMC,
                                   a.PRICE_MNY as JG,
                                   round(a.QTY_DEC,2) as MCYL,
                                   round(a.TOLPRICE_MNY,2) as Price,
                                   '0' ZFBL,
                                   '' as BZ
                              from t_tmp_outpatientchkrecipede a,
                                   t_bse_chargeitem            b,
                                   t_opr_outpatientrecipe      c,
                                   t_aid_inschargeitem         d,
                                   t_opr_outpatient_orderdic   g,
                                   t_bse_bih_orderdic          e
                             where a.itemid_chr = b.itemid_chr(+)
                               and a.outpatrecipeid_chr = g.outpatrecipeid_chr(+)
                               and g.tableindex_int = 3
                               and g.orderdicid_chr =
                                   substr(a.orderid_vchr, instr(a.orderid_vchr, '->', 1, 1) + 2, 10)
                               and g.orderdicid_chr = e.orderdicid_chr
                            --and a.orderid2_vchr=g.orderque_int || '->' || g.orderdicid_chr
                               and a.outpatrecipeid_chr = ?
                               and d.itemid_chr = a.itemid_chr
                               and d.copayid_chr = c.paytypeid_chr
                               and a.outpatrecipeid_chr = c.outpatrecipeid_chr
                             order by XMXH";
                p_dtTemp.Rows.Clear();
                objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = dtListRecipe.Rows[0]["CFID"].ToString().Trim();

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
                //检验
                strSQL = @"select '0001598' YYBH,c.CREATEDATE_DAT FYRQ, (4000 + to_number(nvl(a.rowno_chr, 0))) as XMXH,
                                   b.itemcode_vchr as XMBH,
                                   a.itemname_vchr as XMMC,
                                   a.PRICE_MNY as JG,
                                   round(a.QTY_DEC,2) as MCYL,
                                   round(a.TOLPRICE_MNY,2) as Price,
                                   '0' ZFBL,
                                   '' as BZ
                              from t_tmp_outpatienttestrecipede a,
                                   t_bse_chargeitem             b,
                                   t_opr_outpatientrecipe       c,
                                   t_aid_inschargeitem          d,
                                   t_opr_outpatient_orderdic    g,
                                   t_bse_bih_orderdic           e
                             where a.itemid_chr = b.itemid_chr(+)
                               and a.outpatrecipeid_chr = g.outpatrecipeid_chr
                               and g.tableindex_int = 4
                               and g.orderdicid_chr =
                                   substr(a.orderid_vchr, instr(a.orderid_vchr, '->', 1, 1) + 2, 10)
                               and g.orderdicid_chr = e.orderdicid_chr
                            --   and a.orderid2_vchr = g.orderque_int || '->' || g.orderdicid_chr
                               and a.outpatrecipeid_chr = ?
                               and d.itemid_chr = a.itemid_chr
                               and d.copayid_chr = c.paytypeid_chr
                               and a.outpatrecipeid_chr = c.outpatrecipeid_chr
                             order by XMXH";
                p_dtTemp.Rows.Clear();
                objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = dtListRecipe.Rows[0]["CFID"].ToString().Trim();

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
                //其它
                strSQL = @"select '0001598' YYBH,c.CREATEDATE_DAT FYRQ, (6000 + to_number(nvl(a.rowno_chr, 0))) as XMXH,
                                   b.itemcode_vchr as XMBH,
                                   a.itemname_vchr as XMMC,
                                   a.UNITPRICE_MNY as JG,
                                   round(a.QTY_DEC,2) as MCYL,
                                   round(a.TOLPRICE_MNY,2) as Price,
                                   '0' ZFBL,
                                   '' as BZ
                       from t_tmp_outpatientothrecipede a,
                            t_bse_chargeitem            b,
                            t_opr_outpatientrecipe      c,
                            t_aid_inschargeitem         d
                      where a.itemid_chr = b.itemid_chr(+)
                        and a.outpatrecipeid_chr = ?
                        and d.itemid_chr = a.itemid_chr
                        and d.copayid_chr = c.paytypeid_chr
                        and a.outpatrecipeid_chr = c.outpatrecipeid_chr
                      order by XMXH";
                p_dtTemp.Rows.Clear();
                objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = dtListRecipe.Rows[0]["CFID"].ToString().Trim();

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
                //治疗/手术
                strSQL = @" select '0001598' YYBH,c.CREATEDATE_DAT FYRQ, (5000 + to_number(nvl(a.rowno_chr, 0))) as XMXH,
                                   b.itemcode_vchr as XMBH,
                                   a.itemname_vchr as XMMC,
                                   a.PRICE_MNY as JG,
                                   round(a.QTY_DEC,2) as MCYL,
                                   round(a.TOLPRICE_MNY,2) as Price,
                                   '0' ZFBL,
                                   '' as BZ
                               from t_tmp_outpatientopsrecipede a,
                                    t_bse_chargeitem            b,
                                    t_opr_outpatientrecipe      c,
                                    t_aid_inschargeitem         d
                              where a.itemid_chr = b.itemid_chr(+)
                                and a.outpatrecipeid_chr = ?
                                and d.itemid_chr = a.itemid_chr
                                and d.copayid_chr = c.paytypeid_chr
                                and a.outpatrecipeid_chr = c.outpatrecipeid_chr
                              order by XMXH";
                p_dtTemp.Rows.Clear();
                objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = dtListRecipe.Rows[0]["CFID"].ToString().Trim();
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
                clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx);
                objLogger = null;
                lngRes = -1;
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

        #region 获取处方基本信息
        /// <summary>
        /// 获取处方基本信息
        /// </summary>
        /// <param name="p_strRecipeId"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngGetRecipeBaseInfo(string p_strRecipeId, out DataTable dt)
        {
            dt = new DataTable();
            long lngRes = 0;

            string strSQL = @"select t.patientid_chr,t.recipeflag_int,e.patientcardid_chr,
                       t.paytypeid_chr,
                       t.diagdept_chr,
                       t.diagdr_chr,
                       t.registerid_chr,
                       t.outpatrecipeid_chr,
                       a.lastname_vchr  as patientname_vchr,
                       a.idcard_chr,
                       a.insuranceid_vchr,
                       b.deptname_vchr,
                       c.lastname_vchr  as empname_vchr,
                       d.recorddate_dat,a.birth_dat
                  from t_opr_outpatientrecipe t,
                       t_bse_patient          a,
                       t_bse_deptdesc         b,
                       t_bse_employee         c,
                       t_opr_patientregister  d,
                       t_bse_patientcard      e
                 where t.patientid_chr = a.patientid_chr
                   and t.diagdept_chr = b.deptid_chr
                   and t.diagdr_chr = c.empid_chr
                   and t.registerid_chr = d.registerid_chr(+)
                   and t.patientid_chr = e.patientid_chr
                   and t.outpatrecipeid_chr = ?";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] objParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objParamArr);
                objParamArr[0].Value = p_strRecipeId;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, objParamArr);
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

        #region 根据医生ID获取其职称
        /// <summary>
        /// 根据医生ID获取其职称
        /// </summary>
        /// <param name="DoctID"></param>
        /// <returns></returns>
        public string m_strGetTechnicalRank(string DoctID)
        {
            string ret = "";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = DoctID;

                string SQL = @"select technicalrank_chr from t_bse_employee where empid_chr = ?";

                DataTable dt = new DataTable();

                long l = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
                if (l > 0 && dt.Rows.Count == 1)
                {
                    ret = dt.Rows[0][0].ToString();
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

        #region 带出默认项目
        /// <summary>
        /// 带出默认项目
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="strPatientTypeID"></param>
        /// <param name="strRecipeflag"></param>
        /// <param name="strDuty"></param>
        /// <param name="strRecipeID"></param>
        /// <returns></returns>     
        public long m_mthGetDefaultItem(out DataTable dt, string strPatientTypeID, string strRecipeflag, string strDuty, string strRecipeID, string strRegID)
        {

            dt = new DataTable();
            long lngRes = 0;
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                string SQL = @"
select a.archtakeflag_int,
       a.diagdr_chr,
       a.diagdept_chr,
       b.technicalrank_chr
  from t_opr_outpatientrecipe a, t_bse_employee b
 where a.diagdr_chr = b.empid_chr
   and a.outpatrecipeid_chr = ?
";

                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = strRecipeID;

                int intArchTakeFlag = 2;
                DataTable dtTmp = new DataTable();
                string strdiagdept = null;
                string strTechnicalrank = null;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtTmp, ParamArr);
                if (lngRes > 0 && dtTmp.Rows.Count > 0)
                {
                    if (dtTmp.Rows[0][0].ToString().Trim() != "")
                    {
                        intArchTakeFlag = (int.Parse(dtTmp.Rows[0]["archtakeflag_int"].ToString()) == 1 ? 1 : 2);
                        strdiagdept = dtTmp.Rows[0]["diagdept_chr"].ToString();
                        //strTechnicalrank = dtTmp.Rows[0]["technicalrank_chr"].ToString().Trim();
                    }
                }

                if (strRecipeID.Trim() == "" && strRegID.Trim() != "")
                {
                    intArchTakeFlag = 1;
                }

                SQL = @"select a.isselfhelp, a.flag_int,a.diagdoctor_chr,a.diagdept_chr from t_opr_patientregister a where a.registerid_chr= ?";
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = strRegID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtTmp, ParamArr);
                string strRegDept = null;
                if (lngRes > 0 && dtTmp.Rows.Count > 0)
                {
                    strRegDept = dtTmp.Rows[0]["diagdept_chr"].ToString();

                    if (dtTmp.Rows[0][0].ToString().Trim() == "3")
                    {
                        intArchTakeFlag = 2;
                    }
                }
                //if (strdiagdept != strRegDept && !string.IsNullOrEmpty(strdiagdept))
                //{
                //    intArchTakeFlag = 2;
                //    //strDuty = strTechnicalrank;
                //}
                SQL = @"select a.paytypeid_chr,
       a.itemid_chr,
       a.qty_dec,
       a.regflag_int,
       a.recflag_int,
       a.dutyname_vchr,
       a.begintime_chr,
       a.endtime_chr
  from t_aid_outpatientdefaultadditem a
 where (a.paytypeid_chr = ? or a.paytypeid_chr = '0000')
   and (a.regflag_int = ? or a.regflag_int = 0)
   and (a.recflag_int = ? or a.recflag_int = 0)
   and (a.dutyname_vchr = ? or a.dutyname_vchr = '全部')
   and (to_char(sysdate, 'hh24:mi:ss') between a.begintime_chr and
       a.endtime_chr)
";

                objHRPSvc.CreateDatabaseParameter(4, out ParamArr);
                ParamArr[0].Value = strPatientTypeID;
                ParamArr[1].Value = intArchTakeFlag;
                ParamArr[2].Value = strRecipeflag;
                ParamArr[3].Value = strDuty;

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

        #region 带出默认项目明细
        /// <summary>
        /// 带出默认项目明细
        /// </summary>
        /// <param name="strItemID"></param>
        /// <param name="strPatType"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_mthGetDefaultItemDetailCX(string strItemID, string strPatType, out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();

            string strSQL = @"select distinct '0001598' YYBH,
                                   to_date(sysdate) FYRQ,
                                   to_number(nvl(a.itemid_chr, 0)) as XMXH,
                                   a.itemcode_vchr as XMBH,
                                   a.itemname_vchr as XMMC,
                                   a.itemprice_mny as JG,
                                   round(a.dosage_dec, 2) as MCYL,
                                   round(a.itemprice_mny, 2) as JE,
                                   '' as BZ
                               from t_bse_chargeitem a,
                                    t_bse_medicine b,
                                    (select precent_dec, itemid_chr, copayid_chr
                                       from t_aid_inschargeitem
                                      where copayid_chr = ?) f,
                                    t_aid_outpatientdefaultadditem c
                              where trim (a.itemsrcid_vchr) = trim (b.medicineid_chr(+))
                                and a.ifstop_int = 0
                                and a.itemid_chr = ?
                                and a.itemid_chr = f.itemid_chr
                                and a.itemid_chr = c.itemid_chr
                                and f.copayid_chr = c.paytypeid_chr 
                           order by a.itemcode_vchr ";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = strPatType;
                ParamArr[1].Value = strItemID;

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

        #region 判断处方状态是否更改
        /// <summary>
        /// 判断处方状态是否更改
        /// </summary>
        /// <param name="p_strRecipeIdArr"></param>
        /// <returns></returns>
        public bool m_blnVerifyRecipeStatus(DataTable p_strRecipeIdArr)
        {
            bool blnStatus = true;
            long lngRes = -1;
            string strSub = string.Empty;
            string strSQL = @"select a.outpatrecipeid_chr, a.pstauts_int
                                          from t_opr_outpatientrecipe a
                                         where a.outpatrecipeid_chr=?";
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                DataTable dtbResult = null;
                objHRPSvc.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strRecipeIdArr.Rows[0]["CFID"].ToString();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);
                objHRPSvc.Dispose();

                if (lngRes > 0 && dtbResult != null)
                {
                    DataRow[] drArray = dtbResult.Select("pstauts_int = 1 or pstauts_int = 4");
                    if (drArray.Length < dtbResult.Rows.Count)
                    {
                        blnStatus = false;
                    }
                }
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx);
            }
            return !blnStatus;
        }
        #endregion

        #region 获取系统参数
        /// <summary>
        /// 获取系统参数
        /// </summary>
        /// <param name="p_strParamCode"></param>
        /// <returns></returns>
        [AutoComplete]
        public string m_strGetSysParam(string p_strParamCode)
        {
            string strParamValue = "";
            long lngRes = 0;
            clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = @" select t.parmvalue_vchr from t_bse_sysparm t where t.parmcode_chr = ?";
            try
            {
                System.Data.IDataParameter[] paramArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out paramArr);
                paramArr[0].Value = p_strParamCode;
                DataTable dtbResult = null;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, paramArr);
                objHRPSvc.Dispose();
                objHRPSvc = null;
                if (dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    strParamValue = dtbResult.Rows[0]["parmvalue_vchr"].ToString().Trim();
                }
            }
            catch
            {
            }
            return strParamValue;
        }
        #endregion

        #region 获取系统功能配置
        /// <summary>
        /// 获取系统功能配置
        /// </summary>
        /// <param name="p_strParamCode"></param>
        /// <returns></returns>
        public string m_strGetSysSeting(string p_strSetId)
        {
            string strSetStatus = "";
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = @" select t.setstatus_int from t_sys_setting t where t.setid_chr = ?";
            try
            {

                System.Data.IDataParameter[] paramArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out paramArr);
                paramArr[0].Value = p_strSetId;
                DataTable dtbResult = null;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, paramArr);
                objHRPSvc.Dispose();
                objHRPSvc = null;
                if (dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    strSetStatus = dtbResult.Rows[0]["setstatus_int"].ToString().Trim();
                }
            }
            catch
            {
            }
            return strSetStatus;
        }
        #endregion

        #region 获取病人ID
        /// <summary>
        /// 获取病人ID
        /// </summary>
        /// <param name="p_strParamCode"></param>
        /// <returns></returns>
        public string m_strGetEmpId(string p_strEmpNo)
        {
            string strEmpId = "";
            long lngRes = 0;
            clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = @" select e.empid_chr from t_bse_employee e where e.status_int=1 and e.empno_chr = ?";
            try
            {

                System.Data.IDataParameter[] paramArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out paramArr);
                paramArr[0].Value = p_strEmpNo;
                DataTable dtbResult = null;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, paramArr);
                objHRPSvc.Dispose();
                objHRPSvc = null;
                if (dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    strEmpId = dtbResult.Rows[0]["empid_chr"].ToString().Trim();
                }
                else
                {
                    strEmpId = p_strEmpNo;
                }
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx);
                objLogger = null;
                lngRes = -1;
            }
            finally
            {
                if (objHRPSvc != null)
                {
                    objHRPSvc.Dispose();
                    objHRPSvc = null;
                }
            }
            return strEmpId;
        }
        #endregion

        #region 根据PID获取患者当天发药信息
        /// <summary>
        /// 根据PID获取患者当天发药信息
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="dtRecord"></param>
        /// <returns></returns>
        public long m_lngGetsendmedinfoBypid(string pid, string medid, out DataTable dtRecord)
        {
            dtRecord = new DataTable();
            long lngRes = 0;

            #region new
            string SQL = @"select a.windowid_chr,
                               c.workstatus_int   as treatwindowworkstatus_int,
                               c.windowname_vchr  as treatwindowname,
                               a.pstatus_int,
                               a.senddate_dat,
                               a.sendemp_chr,
                               a.treatdate_dat,
                               a.treatemp_chr,
                               a.autoprint_int,
                               a.medstoreid_chr,
                               a.sendwindowid_chr,
                               e.workstatus_int   as sendwindowworkstatus_int,
                               e.windowname_vchr  as sendwindowname,
                               0                  as order_int
                          from t_opr_recipesend      a,
                               t_bse_medstorewin     c,
                               t_bse_medstorewin     e,
                               t_opr_recipesendentry f
                         where a.sid_int = f.sid_int
                           and a.pstatus_int <> -1
                           and c.windowtype_int = 1
                           and c.workstatus_int = 1
                           and e.workstatus_int = 1
                           and e.windowtype_int = 0
                           and a.medstoreid_chr = c.medstoreid_chr
                           and a.windowid_chr = c.windowid_chr
                           and a.sendwindowid_chr = e.windowid_chr
                           and a.createdate_chr = ?
                           and a.patientid_chr =  ?
                           and a.medstoreid_chr = ? ";
            #endregion

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                ParamArr[0].Value = DateTime.Now.ToString("yyyy-MM-dd");
                ParamArr[1].Value = pid;
                ParamArr[2].Value = medid;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtRecord, ParamArr);
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

        #region 获取诊疗单费用
        /// <summary>
        /// 获取诊疗单费用
        /// </summary>
        /// <param name="dtRequest">请求的数据</param>
        /// <param name="dtResult">响应的结果</param>
        /// <returns></returns>
        public long m_lngGetCompBillFee(string p_strRecipeId, out DataTable p_dtItemDe)
        {
            p_dtItemDe = new DataTable();
            long lngRes = 0;
            string strSQL = string.Empty;
            clsHRPTableService objHRPSvc = null;
            try
            {
                objHRPSvc = new clsHRPTableService();
                DataTable p_dtTemp = new DataTable();
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                //西药
                strSQL = @"select  a.outpatrecipeid_chr,
                                   a.itemid_chr itemid,
                                   a.unitid_chr unit,
                                   a.tolqty_dec quantity,
                                   a.unitprice_mny price,
                                   a.tolprice_mny summoney,
                                   a.rowno_chr,
                                   a.usageid_chr,
                                   a.freqid_chr,
                                   a.qty_dec,
                                   a.days_int,
                                   a.itemname_vchr itemname,
                                   a.itemspec_vchr dec,
                                   '' as sumusage_vchr,
                                   (1000 + to_number(nvl(a.rowno_vchr2, 0))) as sortno,
                                   b.itemopinvtype_chr invtype,
                                   (select typename_vchr
                                      from t_bse_chargeitemextype
                                     where flag_int = '2'
                                       and typeid_chr = b.itemopinvtype_chr) as typename_vchr,
                                   b.itemcatid_chr catid,
                                   b.dosageunit_chr,
                                   b.insuranceid_chr,
                                   b.selfdefine_int selfdefine,
                                   1 times,
                                   b.itemipunit_chr,
                                   round(b.itemprice_mny / b.packqty_dec, 4) submoney,
                                   b.opchargeflg_int,
                                   b.itemopcalctype_chr,
                                   a.discount_dec,
                                   b.itemcode_vchr,
                                   '' as attachid_vchr,
                                   a.hypetest_int,
                                   a.desc_vchr,
                                   a.attachparentid_vchr,
                                   a.attachitembasenum_dec,
                                   a.usageparentid_vchr,
                                   a.usageitembasenum_dec,
                                   a.deptmed_int,
                                   '' as orderid,
                                   0 as ordernum,
                                   c.outpatrecipeid_chr,
                                   c.patientid_chr,
                                   c.createdate_dat,
                                   c.registerid_chr,
                                   c.diagdr_chr,
                                   c.diagdept_chr,
                                   c.recordemp_chr,
                                   c.recorddate_dat,
                                   c.pstauts_int,
                                   c.recipeflag_int,
                                   c.outpatrecipeno_vchr,
                                   c.paytypeid_chr,
                                   c.casehisid_chr,
                                   c.groupid_chr,
                                   c.type_int,
                                   c.confirm_int,
                                   c.confirmdesc_vchr,
                                   c.createtype_int,
                                   c.deptmed_int,
                                   d.precent_dec,
                                   '' orderdicid_chr,
                                   '' orderdicname_vchr,
                                   '' applytypeid_chr,
                                   (select p.paytypename_vchr
                                      from t_bse_patientpaytype p
                                     where p.paytypeid_chr = d.copayid_chr) as feetype
                              from t_tmp_outpatientpwmrecipede a,
                                   t_bse_chargeitem            b,
                                   t_opr_outpatientrecipe      c,
                                   t_aid_inschargeitem         d
                             where a.itemid_chr = b.itemid_chr(+)
                               and a.outpatrecipeid_chr = ?
                               and d.itemid_chr = a.itemid_chr
                               and d.copayid_chr = c.paytypeid_chr
                               and a.outpatrecipeid_chr = c.outpatrecipeid_chr
                             order by sortno";

                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = p_strRecipeId;
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
                //草药
                strSQL = @"select a.outpatrecipeid_chr,
                                       a.itemid_chr itemid,
                                       a.unitid_chr unit,
                                       a.min_qty_dec quantity,
                                       a.unitprice_mny price,
                                       a.tolprice_mny summoney,
                                       a.rowno_chr,
                                       a.usageid_chr,
                                       '' as freqid_chr,
                                       min_qty_dec as qty_dec,
                                       1 as days_int,
                                       b.itemname_vchr itemname,
                                       b.itemspec_vchr dec,
                                       a.sumusage_vchr,
                                       (2000 + to_number(nvl(a.rowno_vchr2, 0))) as sortno,
                                       b.itemopinvtype_chr invtype,
                                       (select typename_vchr
                                          from t_bse_chargeitemextype
                                         where flag_int = '2'
                                           and typeid_chr = b.itemopinvtype_chr) as typename_vchr,
                                       b.itemcatid_chr catid,
                                       b.dosageunit_chr,
                                       b.insuranceid_chr,
                                       b.selfdefine_int selfdefine,
                                       a.times_int times,
                                       '',
                                       1,
                                       0,
                                       b.itemopcalctype_chr,
                                       a.discount_dec,
                                       b.itemcode_vchr,
                                       '' as attachid_vchr,
                                       0,
                                       a.usagedetail_vchr,
                                       a.attachparentid_vchr,
                                       a.attachitembasenum_dec,
                                       a.usageparentid_vchr,
                                       a.usageitembasenum_dec,
                                       a.deptmed_int,
                                       '' as orderid,
                                       0 as ordernum,
                                       c.outpatrecipeid_chr,
                                       c.patientid_chr,
                                       c.createdate_dat,
                                       c.registerid_chr,
                                       c.diagdr_chr,
                                       c.diagdept_chr,
                                       c.recordemp_chr,
                                       c.recorddate_dat,
                                       c.pstauts_int,
                                       c.recipeflag_int,
                                       c.outpatrecipeno_vchr,
                                       c.paytypeid_chr,
                                       c.casehisid_chr,
                                       c.groupid_chr,
                                       c.type_int,
                                       c.confirm_int,
                                       c.confirmdesc_vchr,
                                       c.createtype_int,
                                       c.deptmed_int,
                                       d.precent_dec,
                                       '' orderdicid_chr,
                                       '' orderdicname_vchr,
                                       '' applytypeid_chr,
                                       (select p.paytypename_vchr
                                          from t_bse_patientpaytype p
                                         where p.paytypeid_chr = d.copayid_chr) as feetype
                                  from t_tmp_outpatientcmrecipede a,
                                       t_bse_chargeitem           b,
                                       t_opr_outpatientrecipe     c,
                                       t_aid_inschargeitem        d
                                 where a.itemid_chr = b.itemid_chr(+)
                                   and a.outpatrecipeid_chr = ?
                                   and d.itemid_chr = a.itemid_chr
                                   and d.copayid_chr = c.paytypeid_chr
                                   and a.outpatrecipeid_chr = c.outpatrecipeid_chr
                                 order by sortno";
                p_dtTemp.Rows.Clear();
                objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = p_strRecipeId;
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
                //检查
                strSQL = @"select  a.outpatrecipeid_chr,
                                   a.itemid_chr itemid,
                                   a.itemunit_vchr unit,
                                   a.qty_dec quantity,
                                   a.price_mny price,
                                   a.tolprice_mny summoney,
                                   a.rowno_chr,
                                   '' as usageid_chr,
                                   '' as freqid_chr,
                                   0 as qty_dec,
                                   1 as days_int,
                                   a.itemname_vchr itemname,
                                   a.itemspec_vchr dec,
                                   '' as sumusage_vchr,
                                   (3000 + to_number(nvl(a.rowno_chr, 0))) as sortno,
                                   b.itemopinvtype_chr invtype,
                                   (select typename_vchr
                                      from t_bse_chargeitemextype
                                     where flag_int = '2'
                                       and typeid_chr = b.itemopinvtype_chr) as typename_vchr,
                                   b.itemcatid_chr catid,
                                   b.dosageunit_chr,
                                   b.insuranceid_chr,
                                   b.selfdefine_int selfdefine,
                                   1 times,
                                   '',
                                   1,
                                   0,
                                   b.itemopcalctype_chr,
                                   a.discount_dec,
                                   b.itemcode_vchr,
                                   a.attachid_vchr,
                                   0,
                                   a.itemusagedetail_vchr as desc_vchr,
                                   a.attachparentid_vchr,
                                   a.attachitembasenum_dec,
                                   a.usageparentid_vchr,
                                   a.usageitembasenum_dec,
                                   a.deptmed_int,
                                   a.orderid_vchr as orderid,
                                   a.orderbasenum_dec as ordernum,
                                   c.outpatrecipeid_chr,
                                   c.patientid_chr,
                                   c.createdate_dat,
                                   c.registerid_chr,
                                   c.diagdr_chr,
                                   c.diagdept_chr,
                                   c.recordemp_chr,
                                   c.recorddate_dat,
                                   c.pstauts_int,
                                   c.recipeflag_int,
                                   c.outpatrecipeno_vchr,
                                   c.paytypeid_chr,
                                   c.casehisid_chr,
                                   c.groupid_chr,
                                   c.type_int,
                                   c.confirm_int,
                                   c.confirmdesc_vchr,
                                   c.createtype_int,
                                   c.deptmed_int,
                                   d.precent_dec,
                                   g.orderdicid_chr,
                                   g.orderdicname_vchr,
                                   e.applytypeid_chr,
                                   (select p.paytypename_vchr
                                      from t_bse_patientpaytype p
                                     where p.paytypeid_chr = d.copayid_chr) as feetype
                              from t_tmp_outpatientchkrecipede a,
                                   t_bse_chargeitem            b,
                                   t_opr_outpatientrecipe      c,
                                   t_aid_inschargeitem         d,
                                   t_opr_outpatient_orderdic   g,
                                   t_bse_bih_orderdic          e
                             where a.itemid_chr = b.itemid_chr(+)
                               and a.outpatrecipeid_chr = g.outpatrecipeid_chr(+)
                               and g.tableindex_int = 3
                               and g.orderdicid_chr =
                                   substr(a.orderid_vchr, instr(a.orderid_vchr, '->', 1, 1) + 2, 10)
                               and g.orderdicid_chr = e.orderdicid_chr
                               and a.outpatrecipeid_chr = ?
                               and d.itemid_chr = a.itemid_chr
                               and d.copayid_chr = c.paytypeid_chr
                               and a.outpatrecipeid_chr = c.outpatrecipeid_chr
                             order by sortno";
                p_dtTemp.Rows.Clear();
                objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = p_strRecipeId;

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
                //检验
                strSQL = @"select a.outpatrecipeid_chr,
                                   a.itemid_chr itemid,
                                   a.itemunit_vchr unit,
                                   a.qty_dec quantity,
                                   a.price_mny price,
                                   a.tolprice_mny summoney,
                                   a.rowno_chr,
                                   a.usageid_chr,
                                   '' as freqid_chr,
                                   0 as qty_dec,
                                   1 as days_int,
                                   a.itemname_vchr itemname,
                                   a.itemspec_vchr dec,
                                   '' as sumusage_vchr,
                                   (4000 + to_number(nvl(a.rowno_chr, 0))) as sortno,
                                   b.itemopinvtype_chr invtype,
                                   (select typename_vchr
                                      from t_bse_chargeitemextype
                                     where flag_int = '2'
                                       and typeid_chr = b.itemopinvtype_chr) as typename_vchr,
                                   b.itemcatid_chr catid,
                                   b.dosageunit_chr,
                                   b.insuranceid_chr,
                                   b.selfdefine_int selfdefine,
                                   1 times,
                                   '',
                                   1,
                                   0,
                                   b.itemopcalctype_chr,
                                   a.discount_dec,
                                   b.itemcode_vchr,
                                   a.attachid_vchr,
                                   0,
                                   a.itemusagedetail_vchr as desc_vchr,
                                   a.attachparentid_vchr,
                                   a.attachitembasenum_dec,
                                   a.usageparentid_vchr,
                                   a.usageitembasenum_dec,
                                   a.deptmed_int,
                                   a.orderid_vchr as orderid,
                                   a.orderbasenum_dec as ordernum,
                                   c.outpatrecipeid_chr,
                                   c.patientid_chr,
                                   c.createdate_dat,
                                   c.registerid_chr,
                                   c.diagdr_chr,
                                   c.diagdept_chr,
                                   c.recordemp_chr,
                                   c.recorddate_dat,
                                   c.pstauts_int,
                                   c.recipeflag_int,
                                   c.outpatrecipeno_vchr,
                                   c.paytypeid_chr,
                                   c.casehisid_chr,
                                   c.groupid_chr,
                                   c.type_int,
                                   c.confirm_int,
                                   c.confirmdesc_vchr,
                                   c.createtype_int,
                                   c.deptmed_int,
                                   d.precent_dec,
                                   g.orderdicid_chr,
                                   g.orderdicname_vchr,
                                   e.applytypeid_chr,
                                   (select p.paytypename_vchr
                                      from t_bse_patientpaytype p
                                     where p.paytypeid_chr = d.copayid_chr) as feetype
                              from t_tmp_outpatienttestrecipede a,
                                   t_bse_chargeitem             b,
                                   t_opr_outpatientrecipe       c,
                                   t_aid_inschargeitem          d,
                                   t_opr_outpatient_orderdic    g,
                                   t_bse_bih_orderdic           e
                             where a.itemid_chr = b.itemid_chr(+)
                               and a.outpatrecipeid_chr = g.outpatrecipeid_chr
                               and g.tableindex_int = 4
                               and g.orderdicid_chr =
                                   substr(a.orderid_vchr, instr(a.orderid_vchr, '->', 1, 1) + 2, 10)
                               and g.orderdicid_chr = e.orderdicid_chr
                               and a.outpatrecipeid_chr = ?
                               and d.itemid_chr = a.itemid_chr
                               and d.copayid_chr = c.paytypeid_chr
                               and a.outpatrecipeid_chr = c.outpatrecipeid_chr
                             order by sortno";
                p_dtTemp.Rows.Clear();
                objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = p_strRecipeId;

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
                //其它
                strSQL = @"select  a.outpatrecipeid_chr,
                                   a.itemid_chr itemid,
                                   a.itemunit_vchr unit,
                                   a.qty_dec quantity,
                                   a.unitprice_mny price,
                                   a.tolprice_mny summoney,
                                   a.rowno_chr,
                                   '' as usageid_chr,
                                   '' as freqid_chr,
                                   0 as qty_dec,
                                   1 as days_int,
                                   a.itemname_vchr itemname,
                                   a.itemspec_vchr dec,
                                   '' as sumusage_vchr,
                                   (6000 + to_number(nvl(a.rowno_chr, 0))) as sortno,
                                   b.itemopinvtype_chr invtype,
                                   (select typename_vchr
                                      from t_bse_chargeitemextype
                                     where flag_int = '2'
                                       and typeid_chr = b.itemopinvtype_chr) as typename_vchr,
                                   b.itemcatid_chr catid,
                                   b.dosageunit_chr,
                                   b.insuranceid_chr,
                                   b.selfdefine_int selfdefine,
                                   1 times,
                                   '',
                                   1,
                                   0,
                                   b.itemopcalctype_chr,
                                   a.discount_dec,
                                   b.itemcode_vchr,
                                   a.attachid_vchr,
                                   0,
                                   a.itemusagedetail_vchr as desc_vchr,
                                   a.attachparentid_vchr,
                                   a.attachitembasenum_dec,
                                   a.usageparentid_vchr,
                                   a.usageitembasenum_dec,
                                   a.deptmed_int,
                                   '' as orderid,
                                   0 as ordernum,
                                   c.outpatrecipeid_chr,
                                   c.patientid_chr,
                                   c.createdate_dat,
                                   c.registerid_chr,
                                   c.diagdr_chr,
                                   c.diagdept_chr,
                                   c.recordemp_chr,
                                   c.recorddate_dat,
                                   c.pstauts_int,
                                   c.recipeflag_int,
                                   c.outpatrecipeno_vchr,
                                   c.paytypeid_chr,
                                   c.casehisid_chr,
                                   c.groupid_chr,
                                   c.type_int,
                                   c.confirm_int,
                                   c.confirmdesc_vchr,
                                   c.createtype_int,
                                   c.deptmed_int,
                                   d.precent_dec,
                                   '' orderdicid_chr,
                                   '' orderdicname_vchr,
                                   '' applytypeid_chr,
                                   (select p.paytypename_vchr
                                      from t_bse_patientpaytype p
                                     where p.paytypeid_chr = d.copayid_chr) as feetype
                              from t_tmp_outpatientothrecipede a,
                                   t_bse_chargeitem            b,
                                   t_opr_outpatientrecipe      c,
                                   t_aid_inschargeitem         d
                             where a.itemid_chr = b.itemid_chr(+)
                               and a.outpatrecipeid_chr = ?
                               and d.itemid_chr = a.itemid_chr
                               and d.copayid_chr = c.paytypeid_chr
                               and a.outpatrecipeid_chr = c.outpatrecipeid_chr
                             order by sortno";
                p_dtTemp.Rows.Clear();
                objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = p_strRecipeId;

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
                //治疗/手术
                strSQL = @" select a.outpatrecipeid_chr,
                                   a.itemid_chr itemid,
                                   a.itemunit_vchr unit,
                                   a.qty_dec quantity,
                                   a.price_mny price,
                                   a.tolprice_mny summoney,
                                   a.rowno_chr,
                                   a.usageid_chr,
                                   '' as freqid_chr,
                                   0 as qty_dec,
                                   1 as days_int,
                                   a.itemname_vchr itemname,
                                   a.itemspec_vchr dec,
                                   '' as sumusage_vchr,
                                   (5000 + to_number(nvl(a.rowno_chr, 0))) as sortno,
                                   b.itemopinvtype_chr invtype,
                                   (select typename_vchr
                                      from t_bse_chargeitemextype
                                     where flag_int = '2'
                                       and typeid_chr = b.itemopinvtype_chr) as typename_vchr,
                                   b.itemcatid_chr catid,
                                   b.dosageunit_chr,
                                   b.insuranceid_chr,
                                   b.selfdefine_int selfdefine,
                                   1 times,
                                   '',
                                   1,
                                   0,
                                   b.itemopcalctype_chr,
                                   a.discount_dec,
                                   b.itemcode_vchr,
                                   a.attachid_vchr,
                                   0,
                                   a.itemusagedetail_vchr as desc_vchr,
                                   a.attachparentid_vchr,
                                   a.attachitembasenum_dec,
                                   a.usageparentid_vchr,
                                   a.usageitembasenum_dec,
                                   a.deptmed_int,
                                   a.orderid_vchr as orderid,
                                   a.orderbasenum_dec as ordernum,
                                   c.outpatrecipeid_chr,
                                   c.patientid_chr,
                                   c.createdate_dat,
                                   c.registerid_chr,
                                   c.diagdr_chr,
                                   c.diagdept_chr,
                                   c.recordemp_chr,
                                   c.recorddate_dat,
                                   c.pstauts_int,
                                   c.recipeflag_int,
                                   c.outpatrecipeno_vchr,
                                   c.paytypeid_chr,
                                   c.casehisid_chr,
                                   c.groupid_chr,
                                   c.type_int,
                                   c.confirm_int,
                                   c.confirmdesc_vchr,
                                   c.createtype_int,
                                   c.deptmed_int,
                                   d.precent_dec,
                                   '' orderdicid_chr,
                                   '' orderdicname_vchr,
                                   '' applytypeid_chr,
                                   (select p.paytypename_vchr
                                      from t_bse_patientpaytype p
                                     where p.paytypeid_chr = d.copayid_chr) as feetype
                              from t_tmp_outpatientopsrecipede a,
                                   t_bse_chargeitem            b,
                                   t_opr_outpatientrecipe      c,
                                   t_aid_inschargeitem         d
                             where a.itemid_chr = b.itemid_chr(+)
                               and a.outpatrecipeid_chr = ?
                               and d.itemid_chr = a.itemid_chr
                               and d.copayid_chr = c.paytypeid_chr
                               and a.outpatrecipeid_chr = c.outpatrecipeid_chr
                             order by sortno";
                p_dtTemp.Rows.Clear();
                objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = p_strRecipeId;
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
                clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx);
                objLogger = null;
                lngRes = -1;
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

        #region 查找对应表信息
        /// <summary>
        /// 查找对应表信息
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_mthRelationInfo(out DataTable dt)
        {
            dt = new DataTable();
            long lngRes = 0;

            string strSQL = @"select a.mapid_chr, a.groupid_chr, a.catid_chr, a.internalflag_int
                              from t_bse_chargecatmap a
                              where a.internalflag_int = 1";
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

        #region 带出默认项目
        /// <summary>
        /// 带出默认项目
        /// </summary>
        /// <param name="strItemID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_mthGetDefaultItem(string strItemID, string strPatType, out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();

            string strSQL = @"select distinct a.itemid_chr itemid, a.itemname_vchr itemname, a.itemspec_vchr,
                                    a.itemengname_vchr, a.itemcode_vchr as tempitemcode,
                                    a.insuranceid_chr, a.itemopunit_chr, a.itemprice_mny price,
                                    a.itemopinvtype_chr invtype, a.itemcatid_chr, a.selfdefine_int,
                                    a.itemcode_vchr, a.itemopcalctype_chr, a.dosage_dec quantity,
                                    a.itemprice_mny summoney,
                                    a.dosageunit_chr, f.precent_dec discount_dec, c.qty_dec as itemnum,f.precent_dec,
                                    b.noqtyflag_int, a.itemipunit_chr,
                                    round (a.itemprice_mny / a.packqty_dec, 4) submoney,
                                    a.opchargeflg_int, a.itemunit_chr as unit
                               from t_bse_chargeitem a,
                                    t_bse_medicine b,
                                    (select precent_dec, itemid_chr, copayid_chr
                                       from t_aid_inschargeitem
                                      where copayid_chr = ?) f,
                                    t_aid_outpatientdefaultadditem c
                              where trim (a.itemsrcid_vchr) = trim (b.medicineid_chr(+))
                                and a.ifstop_int = 0
                                and a.itemid_chr = ?
                                and a.itemid_chr = f.itemid_chr
                                and a.itemid_chr = c.itemid_chr
                                and f.copayid_chr = c.paytypeid_chr 
                           order by a.itemcode_vchr ";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = strPatType;
                ParamArr[1].Value = strItemID;

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

        #region 带出默认项目明细
        /// <summary>
        /// 带出默认项目明细
        /// </summary>
        /// <param name="strItemID"></param>
        /// <param name="strPatType"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_mthGetDefaultItemDetail(string strItemID, string strPatType, out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();

            string strSQL = @"select distinct to_number(nvl(a.itemid_chr,0)) as ProNO,a.itemcode_vchr as ProID, a.itemname_vchr as ProName, a.itemspec_vchr as Specs,
                                    a.itemipunit_chr as Unit,round(a.itemprice_mny,2) as Price, round(a.dosage_dec,2) as Quantity,'' as Remark
                               from t_bse_chargeitem a,
                                    t_bse_medicine b,
                                    (select precent_dec, itemid_chr, copayid_chr
                                       from t_aid_inschargeitem
                                      where copayid_chr = ?) f,
                                    t_aid_outpatientdefaultadditem c
                              where trim (a.itemsrcid_vchr) = trim (b.medicineid_chr(+))
                                and a.ifstop_int = 0
                                and a.itemid_chr = ?
                                and a.itemid_chr = f.itemid_chr
                                and a.itemid_chr = c.itemid_chr
                                and f.copayid_chr = c.paytypeid_chr 
                           order by a.itemcode_vchr ";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out ParamArr);
                ParamArr[0].Value = strPatType;
                ParamArr[1].Value = strItemID;

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
        #endregion

        #region 根据收费项目ID获取该项目药房分类
        /// <summary>
        /// 根据收费项目ID获取该项目药房分类
        /// </summary>
        /// <param name="strChrgItem"></param>
        public string m_strGetOutSendMedStoretype(string strChrgItem)
        {
            long lngRes = 0;
            string strMedStoretype = "";
            DataTable dtRecord = new DataTable();

            //          string SQL = @"select b.OutMedStoreID_CHR from t_bse_chargeitem a, t_aid_chargemderla b, t_bse_medicine c 
            //			    		   where a.itemcatid_chr = b.itemcatid_chr and a.itemsrcid_vchr = c.medicineid_chr and a.itemid_chr = '" + strChrgItem + "'";

            string SQL = @"select a.medicnetype_int 
                             from t_bse_medicine a,
                                  t_bse_chargeitem b
                            where a.medicineid_chr = b.itemsrcid_vchr
                              and b.itemid_chr = ?";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = strChrgItem;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtRecord, ParamArr);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (lngRes > 0 && dtRecord.Rows.Count == 1)
            {
                strMedStoretype = dtRecord.Rows[0][0].ToString().Trim();
                if (strMedStoretype == null)
                {
                    strMedStoretype = "";
                }
            }
            return strMedStoretype;
        }
        #endregion

        #region 获取当日流水号
        /// <summary>
        /// 获取当日流水号
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strSerNo"></param>
        /// <returns></returns>
        public long m_mthGetSerNO(out string m_strSerNo)
        {
            DataTable p_dtResult = new DataTable();
            long lngRes = 0;
            m_strSerNo = string.Empty;

            string strSQL = @"select substr (to_char(seq_recipesendnum.nextval), -4) from dual ";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtResult);
                if (lngRes > 0 && p_dtResult.Rows.Count > 0)
                {
                    m_strSerNo = p_dtResult.Rows[0][0].ToString();
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

        #region 获取当前工作中的药房
        /// <summary>
        ///获取当前工作中的药房 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="strOldStorageID"></param>
        /// <param name="strNewStorageID"></param>
        /// <returns></returns>
        public long m_lngGetWorkStorage(string strOldStorageID, out string strNewStorageID)
        {
            long lngRes = 0;
            strNewStorageID = "";
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            if (lngRes < 0)
                return lngRes;

            DateTime dtNow = DateTime.Now;//???
            string strDateTime = dtNow.ToString("yyyy-MM-dd HH:mm:ss");
            int weekDay_int = 0;//星期几 (1-周一\7-周日)
            switch (dtNow.DayOfWeek.ToString())
            {
                case "Monday":
                    weekDay_int = 1;
                    break;
                case "Tuesday":
                    weekDay_int = 2;
                    break;
                case "Wednesday":
                    weekDay_int = 3;
                    break;
                case "Thursday":
                    weekDay_int = 4;
                    break;
                case "Friday":
                    weekDay_int = 5;
                    break;
                case "Saturday":
                    weekDay_int = 6;
                    break;
                case "Sunday":
                    weekDay_int = 7;
                    break;
            }

            string strSQL = @"select a.seq_int, a.typeid_int, a.deptid_vchr, a.weekday_int, a.worktime_vchr,
       a.objectdeptid_vchr, a.remark_vchr
  from t_bse_deptduty a
 where a.deptid_vchr = ? and a.weekday_int = ?";
            DataTable dtDuty = new DataTable();
            try
            {

                System.Data.IDataParameter[] paramArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out paramArr);
                paramArr[0].Value = strOldStorageID;
                paramArr[1].Value = weekDay_int;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtDuty, paramArr);
            }
            catch
            {
            }
            if (dtDuty.Rows.Count > 0)
            {
                if (dtDuty.Rows[0]["WORKTIME_VCHR"] != System.DBNull.Value && dtDuty.Rows[0]["WORKTIME_VCHR"].ToString() != "")
                {
                    string _split = "|";
                    string[] objstr = dtDuty.Rows[0]["WORKTIME_VCHR"].ToString().Split(_split.ToCharArray());
                    for (int f2 = 0; f2 < objstr.Length; f2++)
                    {
                        _split = "-";
                        string[] objstr1 = objstr[f2].Split(_split.ToCharArray());
                        if (objstr1.Length == 2)
                        {
                            string date1 = dtNow.Date.ToString("yyyy-MM-dd") + " " + objstr1[0];
                            string date2 = dtNow.Date.ToString("yyyy-MM-dd") + " " + objstr1[1];
                            if (dtNow >= DateTime.Parse(date1) && dtNow <= DateTime.Parse(date2))
                            {
                                strNewStorageID = strOldStorageID;
                                return 1;
                            }
                        }
                    }
                }
            }
            else
            {
                strNewStorageID = strOldStorageID;
                return 1;
            }
            strNewStorageID = dtDuty.Rows[0]["OBJECTDEPTID_VCHR"].ToString();
            return lngRes;
        }
        #endregion

        #region 根据接诊科室、药房获取专用窗口信息
        /// <summary>
        /// 根据接诊科室、药房获取专用窗口信息
        /// </summary>
        /// <param name="deptid"></param>
        /// <param name="medin"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        public long m_lngGetespecialwin(string deptid, string medid, out string winid, out int waitno)
        {
            winid = "";
            waitno = 1;
            DataTable dt = new DataTable();
            long lngRes = 0;

            string Recdate = DateTime.Now.ToString("yyyyMMdd");

            string SQL = @"select t1.windowid_chr, nvl(t3.ordermax,0) as ordermax, nvl(t3.ordercount,0) as ordercount
                             from t_bse_medstorewin t1,                                  
                                   (select windowid_chr
                                      from t_bse_medstorewindeptdef 
                                     where deptid_chr = ? and medstoreid_chr = ?) t2,                              
                                   (select a.medstoreid_chr, a.windowid_chr, b.ordercount, a.ordermax      
                                      from (select medstoreid_chr, windowid_chr, max(order_int) as ordermax
                                              from t_opr_medstorewinque
                                             where windowtype_int = 1
                                               and medstoreid_chr = ?
                                               and outpatrecipeid_chr like ? 
                                            group by medstoreid_chr, windowid_chr) a,
                                           (select medstoreid_chr, windowid_chr, count(order_int) as ordercount
                                              from t_opr_medstorewinque
                                             where windowtype_int = 1
                                               and medstoreid_chr = ? 
                                               and outpatrecipeid_chr like ? 
                                            group by medstoreid_chr, windowid_chr) b
                                     where a.medstoreid_chr = b.medstoreid_chr
                                       and a.windowid_chr = b.windowid_chr) t3
                              where t1.winproperty_int = 1
                                and t1.windowtype_int = 1
                                and t1.workstatus_int = 1
                                and t1.windowid_chr = t2.windowid_chr
                                and t1.windowid_chr = t3.windowid_chr(+)
                                and t1.medstoreid_chr = t3.medstoreid_chr(+)
                            order by ordercount";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(6, out ParamArr);
                ParamArr[0].Value = deptid;
                ParamArr[1].Value = medid;
                ParamArr[2].Value = medid;
                ParamArr[3].Value = Recdate + "%";
                ParamArr[4].Value = medid;
                ParamArr[5].Value = Recdate + "%";

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
                objHRPSvc.Dispose();

                if (lngRes > 0 && dt.Rows.Count > 0)
                {
                    winid = dt.Rows[0]["windowid_chr"].ToString();
                    waitno = Convert.ToInt32(dt.Rows[0]["ordermax"]) + 1;
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

        #region 获取当前的配药窗口和发药窗口(也就是检查药房配药窗口中配药队列最小的窗口）
        /// <summary>
        /// 获取当前的配药窗口和发药窗口(也就是检查药房配药窗口中配药队列最小的窗口）
        /// </summary>
        /// <param name="storageID">药房id</param>
        /// <param name="m_objWindowsVo">如果找不到合适的配药窗口和发药窗口，返回null</param>
        /// <param name="CheckScope">药房专用窗口是否可以接收所有科室处方 true 接收 false 禁止 参数：0057</param>
        /// <returns></returns>
        public long lngGetWindowIDByStorage(string storageID, out clsMedStoreWindowsVo m_objWindowsVo, bool CheckScope)
        {
            m_objWindowsVo = null;
            long lngRegs = 0;
            string strSQL = "";
            if (CheckScope)
            {
                strSQL = @"select a.windowid_chr,
                              a.windowname_vchr,
                              a.medstoreid_chr,
                              sum(decode(c.sid_int, null, 0, 1)) as numcount
                         from t_bse_medstorewin a,
                              (select b.sid_int, b.windowid_chr
                                 from t_opr_recipesend b
                                where b.createdate_chr = ?
                                  and b.medstoreid_chr = ?
                                  and b.pstatus_int = 1) c
                        where a.windowid_chr = c.windowid_chr(+)
                          and a.medstoreid_chr = ?
                          and a.windowtype_int = 1
                          and a.workstatus_int = 1
                           and exists (select 1
                                  from t_opr_medstorewinrlt a1, t_bse_medstorewin a2
                                 where a1.treatwinid_chr = a.windowid_chr
                                   and a1.givewinid_chr = a2.windowid_chr
                                   and a2.windowtype_int = 0
                                   and a2.workstatus_int = 1)
                        group by a.windowid_chr,
                                 a.windowname_vchr,
                                 a.medstoreid_chr";
            }
            else
            {
                strSQL = @"select a.windowid_chr,
                              a.windowname_vchr,
                              a.medstoreid_chr,
                              sum(decode(c.sid_int, null, 0, 1)) as numcount
                         from t_bse_medstorewin a,
                              (select b.sid_int, b.windowid_chr
                                 from t_opr_recipesend b
                                where b.createdate_chr = ?
                                  and b.medstoreid_chr =?
                                  and b.pstatus_int = 1) c
                        where a.windowid_chr = c.windowid_chr(+)
                          and a.medstoreid_chr = ?
                          and a.windowtype_int = 1
                          and a.winproperty_int = 0
                          and a.workstatus_int = 1
                           and exists (select 1
                                  from t_opr_medstorewinrlt a1, t_bse_medstorewin a2
                                 where a1.treatwinid_chr = a.windowid_chr
                                   and a1.givewinid_chr = a2.windowid_chr
                                   and a2.windowtype_int = 0
                                   and a2.workstatus_int = 1)
                        group by a.windowid_chr,
                                 a.windowname_vchr,
                                 a.medstoreid_chr";
            }

            DateTime dtNow = DateTime.Now;//???
            string strDateTime = dtNow.ToString("yyyy-MM-dd");
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.DataTable p_dtWindow = new System.Data.DataTable();

                System.Data.IDataParameter[] paramArr = null;
                objHRPSvc.CreateDatabaseParameter(3, out paramArr);
                paramArr[0].Value = strDateTime;
                paramArr[1].Value = storageID;
                paramArr[2].Value = storageID;
                //获取当前药房所有配药窗口的配药队列
                lngRegs = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtWindow, paramArr);


                if (lngRegs > 0 && p_dtWindow.Rows.Count > 0)
                {
                    DataView dv = p_dtWindow.DefaultView;
                    dv.Sort = "numcount ";//将成药窗口而且队列最少的窗口排在前面
                    if (dv.Count > 0)
                    {
                        DataRowView drvtemp = dv[0];
                        m_objWindowsVo = new clsMedStoreWindowsVo();
                        m_objWindowsVo.m_strWindowID = drvtemp["windowid_chr"].ToString();
                        m_objWindowsVo.m_strWindowName = drvtemp["windowname_vchr"].ToString();
                        m_objWindowsVo.m_intWindowOrderNo = int.Parse(drvtemp["numcount"].ToString()) + 1;
                        this.lngGetSendWindowInfoByWindowid(storageID, m_objWindowsVo.m_strWindowID, ref m_objWindowsVo);
                    }
                }
                else
                {
                    m_objWindowsVo = null;//返回null到收费界面，作为取不到任何配药窗口信息的标识，请药房人员配好药房窗口设置；
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRegs;
        }
        #endregion
        #region 根据配药窗口id获取发药窗口信息
        /// <summary>
        /// 根据配药窗口id获取发药窗口信息
        /// </summary>
        /// <param name="m_strWindowid">配药窗口id</param>
        /// <param name="m_objWindowsVo">发药窗口信息vo,获取发药窗口信息时返回null</param>
        /// <returns></returns>
        public long lngGetSendWindowInfoByWindowid(string m_strMedStoreid, string m_strWindowid, ref clsMedStoreWindowsVo m_objWindowsVo)
        {
            long lngRegs = 0;
            string strSQL = "";
            DateTime dtNow = DateTime.Now;//???
            string strDateTime = dtNow.ToString("yyyy-MM-dd");
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.DataTable p_dtWindow = new System.Data.DataTable();
                System.Data.IDataParameter[] paramArr = null;
                strSQL = @"select windowid_chr, windowname_vchr, medstoreid_chr, numcount
                              from (select a.windowid_chr,
                                           a.windowname_vchr,
                                           a.medstoreid_chr,
                                           sum(decode(c.sid_int, null, 0, 1)) as numcount
                                      from t_bse_medstorewin a,
                                           (select b.sid_int, b.sendwindowid_chr
                                              from t_opr_recipesend b
                                             where b.createdate_chr = ?
                                               and b.medstoreid_chr = ?
                                               and (b.pstatus_int = 1 or b.pstatus_int = 2)) c
                                     where a.windowid_chr = c.sendwindowid_chr(+)
                                       and a.medstoreid_chr = ?
                                       and a.windowtype_int = 0
                                       and a.workstatus_int = 1
                                     group by a.windowid_chr, a.windowname_vchr, a.medstoreid_chr
                                     order by numcount) d,
                                   t_opr_medstorewinrlt e
                             where e.treatwinid_chr = ?
                               and e.givewinid_chr = d.windowid_chr
                             order by numcount";

                objHRPSvc.CreateDatabaseParameter(4, out paramArr);
                paramArr[0].Value = strDateTime;
                paramArr[1].Value = m_strMedStoreid;
                paramArr[2].Value = m_strMedStoreid;
                paramArr[3].Value = m_strWindowid;
                lngRegs = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtWindow, paramArr);

                if (lngRegs > 0 && p_dtWindow.Rows.Count > 0)
                {
                    DataRow drTemp = p_dtWindow.Rows[0];
                    if (m_objWindowsVo == null)
                        m_objWindowsVo = new clsMedStoreWindowsVo();
                    m_objWindowsVo.m_strSendWindowID = drTemp["windowid_chr"].ToString();
                    m_objWindowsVo.m_strSendWindowName = drTemp["windowname_vchr"].ToString();
                    m_objWindowsVo.m_intSendWindowOrderNo = int.Parse(drTemp["numcount"].ToString()) + 1;
                }
                else
                {
                    m_objWindowsVo = null;
                }

            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRegs;
        }
        #endregion

        #region 门诊发票分类Datatable
        /// <summary>
        /// 门诊发票分类Datatable
        /// </summary>
        /// <param name="dtResult">响应的结果</param>
        /// <returns></returns>
        public long m_lngInvoType(out DataTable dtInvoType)
        {
            dtInvoType = new DataTable();
            long lngRes = 0;
            string strSQL = string.Empty;
            clsHRPTableService objHRPSvc = null;
            try
            {
                strSQL = @"select typeid_chr, typename_vchr
                              from t_bse_chargeitemextype
                             where flag_int = '2'
                             order by typeid_chr";
                objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtInvoType);
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx);
                objLogger = null;
                lngRes = -1;
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

        #region 查询诊疗单、注射单内容
        /// <summary>
        /// 查询诊疗单、注射单内容
        /// </summary>
        /// <param name="p_outpatrecipeid"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDiagAndInjectionInfo(string p_outpatrecipeid, out DataTable dtResult)
        {
            dtResult = new DataTable();
            long lngRes = -1;
            clsHRPTableService objHRPSvc = null;
            try
            {
                string strSQL = @"select distinct a.pstauts_int,
                                            b.outpatrecipedeid_chr,
                                            b.itemid_chr,
                                            b.dosageunit_chr as unitid_chr,
                                            b.usageid_chr,
                                            b.tolqty_dec,
                                            b.unitprice_mny,
                                            b.tolprice_mny,
                                            case b.rowno_chr
                                              when '0' then
                                               ''
                                              else
                                               b.rowno_chr
                                            end as rowno_chr,
                                            b.days_int,
                                            b.qty_dec,
                                            b.discount_dec,
                                            b.freqid_chr,
                                            b.itemname_vchr,
                                            b.dosageunit_chr,
                                            b.itemspec_vchr,
                                            h.usagename_vchr,
                                            k.freqname_chr,
                                            b.dosage_dec,
                                            m.medicineid_chr,
                                            m.medicinetypeid_chr,
                                            't_tmp_outpatientpwmrecipede' fromtable,
                                            e.lastname_vchr,
                                            h.usageid_chr as usageid,
                                            b.desc_vchr as itemusagedetail_vchr,
                                            b.unitid_chr as itemunit,
                                            c.diag_vchr,f.type_int
                              from t_opr_outpatientrecipe a,
                                   t_tmp_outpatientpwmrecipede b,
                                   t_bse_chargeitem d,
                                   (select distinct usageid_chr,type_int from t_opr_setusage where type_int in ('1','2')) f,
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
                               and a.diagdr_chr = e.empid_chr(+)
                               and a.casehisid_chr = c.casehisid_chr(+)
                            union all
                            select distinct a.pstauts_int,
                                            b.outpatrecipedeid_chr,
                                            b.itemid_chr,
                                            d.dosageunit_chr as unitid_chr,
                                            d.usageid_chr,
                                            0 as tolqty_dec,
                                            b.unitprice_mny,
                                            b.tolprice_mny,
                                            case b.rowno_chr
                                              when '0' then
                                               ''
                                              else
                                               b.rowno_chr
                                            end as rowno_chr,
                                            0 as days_int,
                                            b.qty_dec,
                                            b.discount_dec,
                                            '' as freqid_chr,
                                            b.itemname_vchr,
                                            d.dosageunit_chr,
                                            b.itemspec_vchr,
                                            h.usagename_vchr,
                                            '' as freqname_chr,
                                            d.dosage_dec,
                                            m.medicineid_chr,
                                            m.medicinetypeid_chr,
                                            't_tmp_outpatientpwmrecipede' fromtable,
                                            e.lastname_vchr,
                                            h.usageid_chr as usageid,
                                            '' as itemusagedetail_vchr,
                                            b.unitid_chr as itemunit,
                                            c.diag_vchr,f.type_int
                              from t_opr_outpatientrecipe a,
                                   t_tmp_outpatientcmrecipede b,
                                   t_bse_chargeitem d,
                                   (select distinct usageid_chr,type_int from t_opr_setusage where type_int in ('1','2')) f,
                                   t_bse_usagetype h,
                                   t_bse_medicine m,
                                   t_bse_employee e,
                                   t_opr_outpatientcasehis c
                             where a.outpatrecipeid_chr = ?
                               and a.outpatrecipeid_chr = b.outpatrecipeid_chr
                               and b.itemid_chr = d.itemid_chr
                               and b.usageid_chr = f.usageid_chr
                               and b.usageid_chr = h.usageid_chr
                               and d.itemsrcid_vchr = m.medicineid_chr(+)
                               and a.diagdr_chr = e.empid_chr(+)
                               and a.casehisid_chr = c.casehisid_chr(+)
                            union all
                            select distinct a.pstauts_int,
                                            b.outpatrecipedeid_chr,
                                            b.itemid_chr,
                                            b.itemunit_vchr as unitid_chr,
                                            '' as usageid_chr,
                                            0 as tolqty_dec,
                                            0 as unitprice_mny,
                                            b.tolprice_mny,
                                            case b.rowno_chr
                                              when '0' then
                                               ''
                                              else
                                               b.rowno_chr
                                            end as rowno_chr,
                                            0 as days_int,
                                            b.qty_dec,
                                            b.discount_dec,
                                            '' as freqid_chr,
                                            b.itemname_vchr,
                                            b.itemunit_vchr as dosageunit_chr,
                                            b.itemspec_vchr,
                                            g.usagename_vchr,
                                            '' as freqname_chr,
                                            d.dosage_dec,
                                            m.medicineid_chr,
                                            m.medicinetypeid_chr,
                                            'T_TMP_OUTPATIENTCHKRECIPEDE' fromtable,
                                            e.lastname_vchr,
                                            g.usageid_chr as usageid,
                                            b.itemusagedetail_vchr,
                                            b.itemunit_vchr as itmeunit,
                                            c.diag_vchr,f.type_int
                              from t_opr_outpatientrecipe a,
                                   t_tmp_outpatientchkrecipede b,
                                   t_bse_chargeitem d,
                                   (select distinct usageid_chr,type_int from t_opr_setusage where type_int in ('1','2')) f,
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
                            union all
                            select distinct a.pstauts_int,
                                            b.outpatrecipedeid_chr,
                                            b.itemid_chr,
                                            b.itemunit_vchr as unitid_chr,
                                            '' as usageid_chr,
                                            0 as tolqty_dec,
                                            0 as unitprice_mny,
                                            b.tolprice_mny,
                                            case b.rowno_chr
                                              when '0' then
                                               ''
                                              else
                                               b.rowno_chr
                                            end as rowno_chr,
                                            0 as days_int,
                                            b.qty_dec,
                                            b.discount_dec,
                                            '' as freqid_chr,
                                            b.itemname_vchr,
                                            b.itemunit_vchr as dosageunit_chr,
                                            b.itemspec_vchr,
                                            g.usagename_vchr,
                                            '' as freqname_chr,
                                            d.dosage_dec,
                                            m.medicineid_chr,
                                            m.medicinetypeid_chr,
                                            'T_TMP_OUTPATIENTTESTRECIPEDE' fromtable,
                                            e.lastname_vchr,
                                            b.itemunit_vchr as itemunit,
                                            g.usageid_chr as usageid,
                                            b.itemusagedetail_vchr,
                                            c.diag_vchr,f.type_int
                              from t_opr_outpatientrecipe a,
                                   t_tmp_outpatienttestrecipede b,
                                   t_bse_chargeitem d,
                                   (select distinct usageid_chr,type_int from t_opr_setusage where type_int in ('1','2')) f,
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
                            union all
                            select distinct a.pstauts_int,
                                            b.outpatrecipedeid_chr,
                                            b.itemid_chr,
                                            b.itemunit_vchr as unitid_chr,
                                            '' as usageid_chr,
                                            0 as tolqty_dec,
                                            0 as unitprice_mny,
                                            b.tolprice_mny,
                                            case b.rowno_chr
                                              when '0' then
                                               ''
                                              else
                                               b.rowno_chr
                                            end as rowno_chr,
                                            0 as days_int,
                                            b.qty_dec,
                                            b.discount_dec,
                                            '' as freqid_chr,
                                            b.itemname_vchr,
                                            b.itemunit_vchr as dosageunit_chr,
                                            b.itemspec_vchr,
                                            g.usagename_vchr,
                                            '' as freqname_chr,
                                            d.dosage_dec,
                                            m.medicineid_chr,
                                            m.medicinetypeid_chr,
                                            'T_TMP_OUTPATIENTOPSRECIPEDE' fromtable,
                                            e.lastname_vchr,
                                            g.usageid_chr as usageid,
                                            b.itemusagedetail_vchr,
                                            b.itemunit_vchr as itemunit,
                                            c.diag_vchr,f.type_int
                              from t_opr_outpatientrecipe a,
                                   t_tmp_outpatientopsrecipede b,
                                   t_bse_chargeitem d,
                                   (select distinct usageid_chr ,type_int from t_opr_setusage where type_int in ('1','2')) f,
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
                            union all
                            select distinct a.pstauts_int,
                                            b.outpatrecipedeid_chr,
                                            b.itemid_chr,
                                            b.itemunit_vchr as unitid_chr,
                                            '' as usageid_chr,
                                            0 as tolqty_dec,
                                            0 as unitprice_mny,
                                            b.tolprice_mny,
                                            case b.rowno_chr
                                              when '0' then
                                               ''
                                              else
                                               b.rowno_chr
                                            end as rowno_chr,
                                            0 as days_int,
                                            b.qty_dec,
                                            b.discount_dec,
                                            '' as freqid_chr,
                                            b.itemname_vchr,
                                            b.itemunit_vchr as dosageunit_chr,
                                            b.itemspec_vchr,
                                            g.usagename_vchr,
                                            '' as freqname_chr,
                                            d.dosage_dec,
                                            m.medicineid_chr,
                                            m.medicinetypeid_chr,
                                            'T_TMP_OUTPATIENTOTHRECIPEDE' fromtable,
                                            e.lastname_vchr,
                                            g.usageid_chr as usageid,
                                            '' as itemusagedetail_vchr,
                                            b.itemunit_vchr as itemunit,
                                            c.diag_vchr,f.type_int
                              from t_opr_outpatientrecipe a,
                                   t_tmp_outpatientothrecipede b,
                                   t_bse_chargeitem d,
                                   (select distinct usageid_chr,type_int from t_opr_setusage where type_int in ('1','2')) f,
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
                             order by rowno_chr";
                objHRPSvc = new clsHRPTableService();
                IDataParameter[] objIDParr = null;
                objHRPSvc.CreateDatabaseParameter(6, out objIDParr);
                objIDParr[0].Value = p_outpatrecipeid.Trim();
                objIDParr[1].Value = p_outpatrecipeid.Trim();
                objIDParr[2].Value = p_outpatrecipeid.Trim();
                objIDParr[3].Value = p_outpatrecipeid.Trim();
                objIDParr[4].Value = p_outpatrecipeid.Trim();
                objIDParr[5].Value = p_outpatrecipeid.Trim();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, objIDParr);
            }
            catch (Exception objEx)
            {
                clsLogText objLog = new clsLogText();
                objLog.LogError(objEx);
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

        #region 查询处方内的费用类别
        /// <summary>
        /// 查询处方内的费用类别
        /// </summary>
        /// <param name="Recipe"></param>
        /// <param name="seqid"></param>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetRecipeInvde(string Recipe, string seqid, out DataTable dtResult)
        {
            long lngRes = -1;
            dtResult = new DataTable();
            clsHRPTableService objHRPSvc = null;
            string strSQL = string.Empty;
            try
            {
                strSQL = @"select b.typename_vchr, a.tolfee_mny
                          from t_opr_outpatientrecipeinvde a, t_bse_chargeitemextype b
                         where a.invoiceno_vchr = ?
                           and a.seqid_chr = ?
                           and a.itemcatid_chr = b.typeid_chr
                           and b.flag_int = 2";
                objHRPSvc = new clsHRPTableService();
                IDataParameter[] objIDPar = null;
                objHRPSvc.CreateDatabaseParameter(2, out objIDPar);
                objIDPar[0].Value = Recipe;
                objIDPar[1].Value = seqid;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, objIDPar);
            }
            catch (Exception objEx)
            {
                clsLogText objLog = new clsLogText();
                objLog.LogError(objEx);
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

        #region 自动带出药袋费
        /// <summary>
        /// 自动带出药袋费
        /// </summary>
        /// <param name="Recipe"></param>
        /// <param name="PayType"></param>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetIrazuFee(string Recipe, string PayType, out DataTable dtResult)
        {
            long lngRes = -1;
            dtResult = null;
            clsHRPTableService objHRPSvc = null;
            string strSQL = string.Empty;
            try
            {
                strSQL = @"select count(distinct trim(a.rowno_chr))
                                from t_tmp_outpatientpwmrecipede a,
                                     t_bse_usagetype b,
                                     t_aid_recipefreq c,
                                     t_bse_chargeitem d,
                                     t_bse_medicine e
                               where a.usageid_chr = b.usageid_chr(+)
                                 and a.freqid_chr = c.freqid_chr(+)
                                 and a.itemid_chr = d.itemid_chr(+)
                                 and d.itemsrcid_vchr = e.medicineid_chr(+)
                                 and a.usageid_chr = '0009'
                                 and e.opchargeflg_int = 1
                                 and outpatrecipeid_chr = ?";
                objHRPSvc = new clsHRPTableService();
                IDataParameter[] objIDpar = null;
                objHRPSvc.CreateDatabaseParameter(1, out objIDpar);
                objIDpar[0].Value = Recipe;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, objIDpar);
                if (lngRes > 0 && dtResult != null)
                {
                    if (dtResult.Rows.Count > 0)
                    {
                        decimal decQTY = Convert.ToDecimal(dtResult.Rows[0][0].ToString());
                        if (decQTY > 0)
                        {
                            dtResult = null;
                            strSQL = @"select distinct '0001598' YYBH,
                                   to_date(sysdate) FYRQ,
                                   to_number(nvl(a.itemid_chr, 0)) as XMXH,
                                   a.itemcode_vchr as XMBH,
                                   a.itemname_vchr as XMMC,
                                   a.itemprice_mny as JG,
                                   round(a.dosage_dec, 2) as MCYL,
                                   round(a.itemprice_mny, 2) as JE,
                                   '0' ZFBL,
                                   '' as BZ
                               from t_bse_chargeitem a,
                                    t_bse_medicine b,
                                    (select precent_dec, itemid_chr, copayid_chr
                                       from t_aid_inschargeitem
                                      where copayid_chr = ?) f
                              where trim (a.itemsrcid_vchr) = trim (b.medicineid_chr(+))
                                and a.ifstop_int = 0
                                and a.itemcode_vchr = '752148'
                                and a.itemid_chr = f.itemid_chr
                           order by a.itemcode_vchr";
                            objIDpar = null;
                            objHRPSvc.CreateDatabaseParameter(1, out objIDpar);
                            objIDpar[0].Value = PayType;
                            lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, objIDpar);
                            if (lngRes > 0 && dtResult.Rows.Count > 0)
                            {
                                dtResult.Rows[0]["MCYL"] = Convert.ToDecimal(dtResult.Rows[0]["MCYL"].ToString()) * decQTY;
                                dtResult.Rows[0]["JE"] = m_decRound(Convert.ToDecimal(dtResult.Rows[0]["JG"].ToString()) * decQTY, 2);
                            }
                        }
                        else
                        {
                            dtResult = new DataTable();
                        }
                    }
                }
            }
            catch (Exception objEx)
            {
                clsLogText objLog = new clsLogText();
                objLog.LogError(objEx);
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

        /// <summary>
        /// 缴费专用
        /// </summary>
        /// <param name="Recipe"></param>
        /// <param name="PayType"></param>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetIrazuFeeJFZY(string Recipe, string PayType, out DataTable dtResult)
        {
            long lngRes = -1;
            dtResult = null;
            clsHRPTableService objHRPSvc = null;
            string strSQL = string.Empty;
            try
            {
                strSQL = @"select count(distinct trim(a.rowno_chr))
                                from t_tmp_outpatientpwmrecipede a,
                                     t_bse_usagetype b,
                                     t_aid_recipefreq c,
                                     t_bse_chargeitem d,
                                     t_bse_medicine e
                               where a.usageid_chr = b.usageid_chr(+)
                                 and a.freqid_chr = c.freqid_chr(+)
                                 and a.itemid_chr = d.itemid_chr(+)
                                 and d.itemsrcid_vchr = e.medicineid_chr(+)
                                 and a.usageid_chr = '0009'
                                 and e.opchargeflg_int = 1
                                 and outpatrecipeid_chr = ?";
                objHRPSvc = new clsHRPTableService();
                IDataParameter[] objIDpar = null;
                objHRPSvc.CreateDatabaseParameter(1, out objIDpar);
                objIDpar[0].Value = Recipe;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, objIDpar);
                if (lngRes > 0 && dtResult != null)
                {
                    if (dtResult.Rows.Count > 0)
                    {
                        decimal decQTY = Convert.ToDecimal(dtResult.Rows[0][0].ToString());
                        dtResult = null;
                        strSQL = @"select distinct ? outpatrecipeid_chr,
                a.itemid_chr itemid,
                b.OPUNIT_CHR unit,
                a.dosage_dec quantity,
                a.itemprice_mny as price,
                a.itemprice_mny as summoney,
                  '' rowno_chr,
               a.usageid_chr,
               a.freqid_chr,
               a.dosage_dec qty_dec,
               '1' days,
               a.itemname_vchr itemname,a.itemspec_vchr dec,'' as sumusage_vchr,  (1000 + to_number(nvl('', 0))) as sortno,
               a.itemopinvtype_chr invtype,
               (select typename_vchr
                  from t_bse_chargeitemextype
                 where flag_int = '2'
                   and typeid_chr = a.itemopinvtype_chr) as typename_vchr,
               a.itemcatid_chr catid,
               a.dosageunit_chr,
               a.insuranceid_chr,
               a.selfdefine_int selfdefine,
               1 times,
               a.itemipunit_chr,
               round(a.itemprice_mny / a.packqty_dec, 4) submoney,
               a.opchargeflg_int,
               a.itemopcalctype_chr,
               --0.0000 discount_dec,
               a.itemcode_vchr,
               '' as attachid_vchr,
               --0 hypetest_int,
               '' desc_vchr,
               '' attachparentid_vchr,
              -- '' attachitembasenum_dec,
               '' usageparentid_vchr,
             --  '' usageitembasenum_dec,
              -- '' deptmed_int,
               '' as orderid,
               0 as ordernum,
               '' outpatrecipeid_chr,
               '' patientid_chr,
               --'' createdate_dat,
               '' registerid_chr,
               '' diagdr_chr,
               '' diagdept_chr,
               '' recordemp_chr,
              -- '' recorddate_dat,
             --  '' pstauts_int,
              -- '' recipeflag_int,
               '' outpatrecipeno_vchr,
               '' paytypeid_chr,
               '' casehisid_chr,
               '' groupid_chr,
              -- '' type_int,
              -- '' confirm_int,
               '' confirmdesc_vchr,
              -- '' createtype_int,
             --  '' deptmed_int,
               f.precent_dec,
               '' orderdicid_chr,
               '' orderdicname_vchr,
               '' applytypeid_chr,
               (select p.paytypename_vchr
                  from t_bse_patientpaytype p
                 where p.paytypeid_chr = f.copayid_chr) as feetype
          from t_bse_chargeitem a,
               t_bse_medicine b,
               (select precent_dec, itemid_chr, copayid_chr
                  from t_aid_inschargeitem
                 where copayid_chr = ?) f
         where trim(a.itemsrcid_vchr) = trim(b.medicineid_chr(+))
           and a.ifstop_int = 0
           and a.itemcode_vchr = '752148'
           and a.itemid_chr = f.itemid_chr
         order by a.itemcode_vchr";
                        objIDpar = null;
                        objHRPSvc.CreateDatabaseParameter(2, out objIDpar);
                        objIDpar[0].Value = Recipe;
                        objIDpar[1].Value = PayType;
                        lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, objIDpar);
                        if (lngRes > 0 && dtResult.Rows.Count > 0)
                        {
                            dtResult.Rows[0]["quantity"] = Convert.ToDecimal(dtResult.Rows[0]["quantity"].ToString()) * decQTY;
                            dtResult.Rows[0]["summoney"] = Convert.ToDecimal(dtResult.Rows[0]["summoney"].ToString()) * decQTY;
                        }
                    }
                }
            }
            catch (Exception objEx)
            {
                clsLogText objLog = new clsLogText();
                objLog.LogError(objEx);
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

        #region 将数值四舍五入
        /// <summary>
        /// 将数值四舍五入
        /// </summary>
        /// <param name="d">数值</param>
        /// <param name="decimals">小数位数</param>
        /// <returns></returns>
        public static decimal m_decRound(decimal d, int decimals)
        {
            try
            {
                if (decimals < 1)
                {
                    return Convert.ToDecimal(Convert.ToInt32(d));
                }
                else
                {
                    string s = "0.";
                    for (int i = 0; i < decimals; i++)
                    {
                        s += "0";
                    }
                    return Convert.ToDecimal(d.ToString(s));
                }
            }
            catch
            {
                return d;
            }
        }
        #endregion
    }
}
