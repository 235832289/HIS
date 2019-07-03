using System;
using System.Data;
using Oracle.DataAccess.Client;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.ValueObject;
using System.EnterpriseServices;
using com.digitalwave.security;//PrivilegeSystemService.dll
using com.digitalwave.Utility;//Utility.dll

namespace com.digitalwave.iCare.middletier.BIHOrderServer
{
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsBIHReportService : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region
       /// <summary>
        /// 获取医嘱进行打印（如治疗单等）
       /// </summary>
        /// <param name="p_strAreaID">病区ID</param>
        /// <param name="p_strBedIDs">用逗号分隔的病床ID	{如果为空则不作为查询条件}</param>
       /// <param name="m_strPTableClassID"></param>
        /// <param name="dtExecuteDate">执行时间</param>
        /// <param name="objDT">执行过的符合条件医嘱记录</param>
       /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOrderForPrint(string p_strAreaID, string p_strBedIDs,string m_strPTableClassID, DateTime dtExecuteDate, out DataTable objDT)
        {
            objDT = new DataTable();
           
            string strSql = @"
          SELECT
        
         t4.code_chr bed_no,
          t3.LASTNAME_VCHR LASTNAME_VCHR,
         t1.RECIPENO_INT,
         t1.NAME_VCHR item_name,
         t1.DOSAGE_DEC,
         t1.Dosageunit_Chr,
         t1.EXECFREQNAME_CHR FREQNAME,
         t1.Dosetypename_Chr,
         t1.Entrust_Vchr,
         t1.executedate_dat,
         t2.INPATIENT_DAT
    FROM t_opr_bih_order t1,
         t_opr_bih_register t2,
         t_opr_bih_registerdetail t3,
         t_bse_bed t4,
         T_Opr_Bih_OrderExecute t6,
       (select k1.usageid_chr from T_OPR_SETUSAGE k1, (select a.orderid_int from T_BSE_NURSEORDER a where a.orderid_int='[usageOrderID]' and a.flag_int=1) k2 where k1.orderid_vchr=k2.orderid_int) t5
        
   WHERE t1.registerid_chr = t2.registerid_chr
     AND t2.registerid_chr = t3.registerid_chr
     AND t2.bedid_chr = t4.bedid_chr
     and t1.DOSETYPEID_CHR=t5.usageid_chr
     and t1.ORDERID_CHR=t6.ORDERID_CHR
    -- AND t2.pstatus_int <> 3
    -- AND t1.status_int = 2
     AND t2.areaid_chr='[areaid_chr]' 
     [BEDID_CHR]
     and trunc(t6.CREATEDATE_DAT)=trunc(to_date('[CREATEDATE_DAT]','yyyy-mm-dd hh24:mi:ss'))
            "; 
            if(!p_strBedIDs.Trim().Equals(""))
            {
                p_strBedIDs= " AND t2.BEDID_CHR in ("+ p_strBedIDs+") " ;
   
            }
            long lngRes = -1;
            strSql = strSql.Replace("[usageOrderID]", m_strPTableClassID);
            strSql = strSql.Replace("[areaid_chr]", p_strAreaID);
            strSql = strSql.Replace("[CREATEDATE_DAT]", dtExecuteDate.ToString());
            strSql = strSql.Replace(" [BEDID_CHR]", p_strBedIDs);
            try
            {
                
                lngRes = 0;
                lngRes = new clsHRPTableService().DoGetDataTable(strSql, ref objDT);
                if (lngRes > 0 && (objDT != null) && objDT.Rows.Count > 0)
                {
                    lngRes = 0;
                    //lngRes = m_lngGetCanExeOrderArrFromDataTable(objDT, out arrOrder);
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
