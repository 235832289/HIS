using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.middletier.MedicineStoreService
{
    /// <summary>
    /// 药品请领单
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsAskSVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 新添药品请领单
        /// <summary>
        ///　新添药品请领单
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objAsk">请领单内容</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewAsk(System.Security.Principal.IPrincipal p_objPrincipal, clsMS_Ask_VO p_objAsk)
        {
            if (p_objAsk == null)
            {
                return -1;
            }

            long lngRes = -1;
            try
            {
                string strSQL = @"insert into t_ms_ask
  (seriesid_int,
   askid_vchr,
   formtype_int,
   askdept_chr,
   exportdept_chr,
   status_int,
   medicineid_chr,
   medicinename_vchr,
   medspec_vchr_vchr,
   opunit_chr,
   opamount_int,
   ipunit_chr,
   ipamount_int,
   askdate_dat,
   examdate_dat,
   askerid_chr,
   examerid_chr,
   comment_vchr)
values
  (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                clsMS_PublicSVC objPublic = new clsMS_PublicSVC();
                long lngEff = -1;
                IDataParameter[] objLisAddItemRefArr = null;
                long lngSEQ = 0;
                lngRes = objPublic.m_lngGetSequence(p_objPrincipal, "SEQ_MS_ASK", out lngSEQ);
                if (lngSEQ <= 0)
                {
                    return -1;
                }

                objHRPServ.CreateDatabaseParameter(18, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = lngSEQ;
                objLisAddItemRefArr[1].Value = p_objAsk.m_strASKID_VCHR;
                objLisAddItemRefArr[2].Value = p_objAsk.m_intFORMTYPE_INT;
                objLisAddItemRefArr[3].Value = p_objAsk.m_strASKDEPT_CHR;
                objLisAddItemRefArr[4].Value = p_objAsk.m_strEXPORTDEPT_CHR;
                objLisAddItemRefArr[5].Value = p_objAsk.m_intSTATUS_INT;
                objLisAddItemRefArr[6].Value = p_objAsk.m_strMEDICINEID_CHR;
                objLisAddItemRefArr[7].Value = p_objAsk.m_strMEDICINENAME_VCHR;
                objLisAddItemRefArr[8].Value = p_objAsk.m_strMEDSPEC_VCHR_VCHR;
                objLisAddItemRefArr[9].Value = p_objAsk.m_strOPUNIT_CHR;
                objLisAddItemRefArr[10].Value = p_objAsk.m_dblOPAMOUNT_INT;
                objLisAddItemRefArr[11].Value = p_objAsk.m_strIPUNIT_CHR;
                objLisAddItemRefArr[12].Value = p_objAsk.m_dblIPAMOUNT_INT;
                objLisAddItemRefArr[13].DbType = DbType.DateTime;
                objLisAddItemRefArr[13].Value = p_objAsk.m_dtmASKDATE_DAT;
                objLisAddItemRefArr[14].DbType = DbType.DateTime;
                objLisAddItemRefArr[14].Value = p_objAsk.m_dtmEXAMDATE_DAT;
                objLisAddItemRefArr[15].Value = p_objAsk.m_strASKERID_CHR;
                objLisAddItemRefArr[16].Value = p_objAsk.m_strEXAMERID_CHR;
                objLisAddItemRefArr[17].Value = p_objAsk.m_strCOMMENT_VCHR;
                long lngRecEff = -1;
                //往表增加记录
                lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngRecEff, objLisAddItemRefArr);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        } 
        #endregion
    }
}
