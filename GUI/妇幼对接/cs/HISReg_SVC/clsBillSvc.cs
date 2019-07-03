using System;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
using System.EnterpriseServices;
using System.Data;
using System.Security.Principal;
namespace com.digitalwave.iCare.middletier.HIS
{
    #region DataAccess class  clsBillSvc
    /// <summary>
    /// Author: wlhuang
    /// Description:  票据管理
    /// This object represents the DataAccess common Fuctions of a t_bse_bill.
    /// Create on 2006年5月22日
    /// inherit clsMiddleTierBase class:use to extend programme
    /// </summary>
    [Transaction(TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsBillSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {

        #region construct
        public clsBillSvc()
        {
        }
        #endregion

        #region Select Record By PrimaryKey
        /// <summary>
        /// Select Record By PrimaryKey
        /// </summary>
        /// <param name="p_billid_int">PrimaryKey 票据ID</param>
        /// <param name="p_objResultTable">Result Table</param>
        [AutoComplete]
        public long lngSelectByPrimaryKey(IPrincipal p_objPrincipal, int p_Id, out DataTable p_objResultTable)
        {
            long lngRes = -1;
            p_objResultTable = null;
            clsHRPTableService HRPSvc = new clsHRPTableService();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBillSvc", "lngSelectByPrimaryKey");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT 
								billid_int,
								billtype_chr,
								billno_vchr,
								status_int,
								inempid_chr,
								indatetime_dat,
								inoprid_chr,
								inoprdatetime_dat,
								outempid_chr,
								outdatetime_dat,
								outoprid_chr,
								outoprdatetime_dat,
								returnempid_chr,
								returndatetime_dat,
								returnoprid_chr,
								returnoprdatetime_dat,
								useempid_chr,
								usedatetime_dat,
								cancelempid_chr,
								canceldatetime_dat,
								refempid_chr,
								refdatetime_dat,
								note_vchr,
								totalsum_mny,
								acctsum_mny,
								sbsum_mny
								FROM  t_bse_bill  
								WHERE  billid_int= '" + p_Id.ToString() + "'";

            try
            {
                lngRes = HRPSvc.DoGetDataTable(strSQL, ref p_objResultTable);
                HRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region Select Record By PrimaryKey
        /// <summary>
        /// Select Record By PrimaryKey
        /// </summary>
        /// <param name="p_billid_int">PrimaryKey 票据ID</param>
        /// <param name="p_objEntity">Result clsBill_VO Entity</param>
        [AutoComplete]
        public long lngSelectByPrimaryKey(IPrincipal p_objPrincipal, int p_Id, out clsBill_VO p_objEntity)
        {
            long lngRes = -1;
            p_objEntity = null;
            clsHRPTableService HRPSvc = new clsHRPTableService();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBillSvc", "lngSelectByPrimaryKey");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT 
								billid_int,
								billtype_chr,
								billno_vchr,
								status_int,
								inempid_chr,
								indatetime_dat,
								inoprid_chr,
								inoprdatetime_dat,
								outempid_chr,
								outdatetime_dat,
								outoprid_chr,
								outoprdatetime_dat,
								returnempid_chr,
								returndatetime_dat,
								returnoprid_chr,
								returnoprdatetime_dat,
								useempid_chr,
								usedatetime_dat,
								cancelempid_chr,
								canceldatetime_dat,
								refempid_chr,
								refdatetime_dat,
								note_vchr,
								totalsum_mny,
								acctsum_mny,
								sbsum_mny
								FROM  t_bse_bill  
								WHERE  billid_int= '" + p_Id.ToString() + "' ";
            try
            {
                DataTable p_objResultTable = null;
                lngRes = HRPSvc.DoGetDataTable(strSQL, ref p_objResultTable);
                if (lngRes > 0)
                {
                    if (p_objResultTable.Rows.Count == 1)
                    {
                        p_objEntity = new clsBill_VO();
                        if (p_objResultTable.Rows[0]["billid_int"] != DBNull.Value)
                            p_objEntity.Billid_int = Convert.ToInt32(p_objResultTable.Rows[0]["billid_int"]);
                        if (p_objResultTable.Rows[0]["billtype_chr"] != DBNull.Value)
                            p_objEntity.Billtype_chr = Convert.ToString(p_objResultTable.Rows[0]["billtype_chr"]);
                        if (p_objResultTable.Rows[0]["billno_vchr"] != DBNull.Value)
                            p_objEntity.Billno_vchr = Convert.ToString(p_objResultTable.Rows[0]["billno_vchr"]);
                        if (p_objResultTable.Rows[0]["status_int"] != DBNull.Value)
                            p_objEntity.Status_int = Convert.ToInt32(p_objResultTable.Rows[0]["status_int"]);
                        if (p_objResultTable.Rows[0]["inempid_chr"] != DBNull.Value)
                            p_objEntity.Inempid_chr = Convert.ToString(p_objResultTable.Rows[0]["inempid_chr"]);
                        if (p_objResultTable.Rows[0]["indatetime_dat"] != DBNull.Value)
                            p_objEntity.Indatetime_dat = Convert.ToDateTime(p_objResultTable.Rows[0]["indatetime_dat"]);
                        if (p_objResultTable.Rows[0]["inoprid_chr"] != DBNull.Value)
                            p_objEntity.Inoprid_chr = Convert.ToString(p_objResultTable.Rows[0]["inoprid_chr"]);
                        if (p_objResultTable.Rows[0]["inoprdatetime_dat"] != DBNull.Value)
                            p_objEntity.Inoprdatetime_dat = Convert.ToDateTime(p_objResultTable.Rows[0]["inoprdatetime_dat"]);
                        if (p_objResultTable.Rows[0]["outempid_chr"] != DBNull.Value)
                            p_objEntity.Outempid_chr = Convert.ToString(p_objResultTable.Rows[0]["outempid_chr"]);
                        if (p_objResultTable.Rows[0]["outdatetime_dat"] != DBNull.Value)
                            p_objEntity.Outdatetime_dat = Convert.ToDateTime(p_objResultTable.Rows[0]["outdatetime_dat"]);
                        if (p_objResultTable.Rows[0]["outoprid_chr"] != DBNull.Value)
                            p_objEntity.Outoprid_chr = Convert.ToString(p_objResultTable.Rows[0]["outoprid_chr"]);
                        if (p_objResultTable.Rows[0]["outoprdatetime_dat"] != DBNull.Value)
                            p_objEntity.Outoprdatetime_dat = Convert.ToDateTime(p_objResultTable.Rows[0]["outoprdatetime_dat"]);
                        if (p_objResultTable.Rows[0]["returnempid_chr"] != DBNull.Value)
                            p_objEntity.Returnempid_chr = Convert.ToString(p_objResultTable.Rows[0]["returnempid_chr"]);
                        if (p_objResultTable.Rows[0]["returndatetime_dat"] != DBNull.Value)
                            p_objEntity.Returndatetime_dat = Convert.ToDateTime(p_objResultTable.Rows[0]["returndatetime_dat"]);
                        if (p_objResultTable.Rows[0]["returnoprid_chr"] != DBNull.Value)
                            p_objEntity.Returnoprid_chr = Convert.ToString(p_objResultTable.Rows[0]["returnoprid_chr"]);
                        if (p_objResultTable.Rows[0]["returnoprdatetime_dat"] != DBNull.Value)
                            p_objEntity.Returnoprdatetime_dat = Convert.ToDateTime(p_objResultTable.Rows[0]["returnoprdatetime_dat"]);
                        if (p_objResultTable.Rows[0]["useempid_chr"] != DBNull.Value)
                            p_objEntity.Useempid_chr = Convert.ToString(p_objResultTable.Rows[0]["useempid_chr"]);
                        if (p_objResultTable.Rows[0]["usedatetime_dat"] != DBNull.Value)
                            p_objEntity.Usedatetime_dat = Convert.ToDateTime(p_objResultTable.Rows[0]["usedatetime_dat"]);
                        if (p_objResultTable.Rows[0]["cancelempid_chr"] != DBNull.Value)
                            p_objEntity.Cancelempid_chr = Convert.ToString(p_objResultTable.Rows[0]["cancelempid_chr"]);
                        if (p_objResultTable.Rows[0]["canceldatetime_dat"] != DBNull.Value)
                            p_objEntity.Canceldatetime_dat = Convert.ToDateTime(p_objResultTable.Rows[0]["canceldatetime_dat"]);
                        if (p_objResultTable.Rows[0]["refempid_chr"] != DBNull.Value)
                            p_objEntity.Refempid_chr = Convert.ToString(p_objResultTable.Rows[0]["refempid_chr"]);
                        if (p_objResultTable.Rows[0]["refdatetime_dat"] != DBNull.Value)
                            p_objEntity.Refdatetime_dat = Convert.ToDateTime(p_objResultTable.Rows[0]["refdatetime_dat"]);
                        if (p_objResultTable.Rows[0]["note_vchr"] != DBNull.Value)
                            p_objEntity.Note_vchr = Convert.ToString(p_objResultTable.Rows[0]["note_vchr"]);
                        if (p_objResultTable.Rows[0]["totalsum_mny"] != DBNull.Value)
                            p_objEntity.Totalsum_mny = Convert.ToInt32(p_objResultTable.Rows[0]["totalsum_mny"]);
                        if (p_objResultTable.Rows[0]["acctsum_mny"] != DBNull.Value)
                            p_objEntity.Acctsum_mny = Convert.ToInt32(p_objResultTable.Rows[0]["acctsum_mny"]);
                        if (p_objResultTable.Rows[0]["sbsum_mny"] != DBNull.Value)
                            p_objEntity.Sbsum_mny = Convert.ToInt32(p_objResultTable.Rows[0]["sbsum_mny"]);
                    }
                }
                HRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region Select Record By Condition
        /// <summary>
        /// Select Record By Condition
        /// </summary>
        /// <param name="p_strWhereCondition">Where Condition,if empty then select all</param>
        /// <param name="p_objResultTable">Result Table</param>
        [AutoComplete]
        public long lngSelectByCondition(IPrincipal p_objPrincipal, string p_strWhereCondition, out DataTable p_objResultTable)
        {
            long lngRes = -1;
            p_objResultTable = null;
            clsHRPTableService HRPSvc = new clsHRPTableService();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBillSvc", "lngSelectByCondition");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT 
								billid_int,
								billtype_chr,
								billno_vchr,
								status_int,
								inempid_chr,
								indatetime_dat,
								inoprid_chr,
								inoprdatetime_dat,
								outempid_chr,
								outdatetime_dat,
								outoprid_chr,
								outoprdatetime_dat,
								returnempid_chr,
								returndatetime_dat,
								returnoprid_chr,
								returnoprdatetime_dat,
								useempid_chr,
								usedatetime_dat,
								cancelempid_chr,
								canceldatetime_dat,
								refempid_chr,
								refdatetime_dat,
								note_vchr,
								totalsum_mny,
								acctsum_mny,
								sbsum_mny
								FROM  t_bse_bill  ";
            if (p_strWhereCondition != "")
                strSQL += " Where " + p_strWhereCondition;
            try
            {
                lngRes = HRPSvc.DoGetDataTable(strSQL, ref p_objResultTable);
                HRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region Select Record Count
        /// <summary>
        /// Select Record Count By Condition
        /// </summary>
        /// <param name="p_strWhereCondition">Where Condition,if empty then select all</param>
        /// <param name="p_intCount">Count</param>
        [AutoComplete]
        public long lngSelectRecordCount(IPrincipal p_objPrincipal, string p_strWhereCondition, out int p_intCount)
        {
            long lngRes = -1;
            p_intCount = -1;
            clsHRPTableService HRPSvc = new clsHRPTableService();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBillSvc", "lngSelectRecordCount");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT COUNT(*) AS ResultCount FROM  t_bse_bill  ";
            if (p_strWhereCondition != "")
                strSQL += " Where " + p_strWhereCondition;

            try
            {
                DataTable objResult = null;
                lngRes = HRPSvc.DoGetDataTable(strSQL, ref objResult);
                if (lngRes > 0)
                    p_intCount = Convert.ToInt32(objResult.Rows[0][0].ToString());
                HRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region Select Record By Condition
        /// <summary>
        /// Select Record By Condition
        /// </summary>
        /// <param name="p_strWhereCondition">Where Condition,if empty then select all</param>
        /// <param name="p_objEntity">Result clsBill_VO Entity Array</param>
        [AutoComplete]
        public long lngSelectByCondition(IPrincipal p_objPrincipal, string p_strWhereCondition, out clsBill_VO[] p_objEntity)
        {
            long lngRes = -1;
            p_objEntity = null;
            clsHRPTableService HRPSvc = new clsHRPTableService();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBillSvc", "lngSelectRecordCount");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"SELECT 
								billid_int,
								billtype_chr,
								billno_vchr,
								status_int,
								inempid_chr,
								indatetime_dat,
								inoprid_chr,
								inoprdatetime_dat,
								outempid_chr,
								outdatetime_dat,
								outoprid_chr,
								outoprdatetime_dat,
								returnempid_chr,
								returndatetime_dat,
								returnoprid_chr,
								returnoprdatetime_dat,
								useempid_chr,
								usedatetime_dat,
								cancelempid_chr,
								canceldatetime_dat,
								refempid_chr,
								refdatetime_dat,
								note_vchr,
								totalsum_mny,
								acctsum_mny,
								sbsum_mny
								FROM  t_bse_bill  ";
            if (p_strWhereCondition != "")
                strSQL += " Where " + p_strWhereCondition;
            try
            {
                DataTable p_objResultTable = null;
                lngRes = HRPSvc.DoGetDataTable(strSQL, ref p_objResultTable);
                if (lngRes > 0)
                {
                    if (p_objResultTable.Rows.Count != 0)
                    {
                        p_objEntity = new clsBill_VO[p_objResultTable.Rows.Count];
                        for (int j = 0; j < p_objResultTable.Rows.Count; j++)
                        {
                            p_objEntity[j] = new clsBill_VO();
                            if (p_objResultTable.Rows[0]["billid_int"] != DBNull.Value)
                                p_objEntity[j].Billid_int = Convert.ToInt32(p_objResultTable.Rows[0]["billid_int"]);
                            if (p_objResultTable.Rows[0]["billtype_chr"] != DBNull.Value)
                                p_objEntity[j].Billtype_chr = Convert.ToString(p_objResultTable.Rows[0]["billtype_chr"]);
                            if (p_objResultTable.Rows[0]["billno_vchr"] != DBNull.Value)
                                p_objEntity[j].Billno_vchr = Convert.ToString(p_objResultTable.Rows[0]["billno_vchr"]);
                            if (p_objResultTable.Rows[0]["status_int"] != DBNull.Value)
                                p_objEntity[j].Status_int = Convert.ToInt32(p_objResultTable.Rows[0]["status_int"]);
                            if (p_objResultTable.Rows[0]["inempid_chr"] != DBNull.Value)
                                p_objEntity[j].Inempid_chr = Convert.ToString(p_objResultTable.Rows[0]["inempid_chr"]);
                            if (p_objResultTable.Rows[0]["indatetime_dat"] != DBNull.Value)
                                p_objEntity[j].Indatetime_dat = Convert.ToDateTime(p_objResultTable.Rows[0]["indatetime_dat"]);
                            if (p_objResultTable.Rows[0]["inoprid_chr"] != DBNull.Value)
                                p_objEntity[j].Inoprid_chr = Convert.ToString(p_objResultTable.Rows[0]["inoprid_chr"]);
                            if (p_objResultTable.Rows[0]["inoprdatetime_dat"] != DBNull.Value)
                                p_objEntity[j].Inoprdatetime_dat = Convert.ToDateTime(p_objResultTable.Rows[0]["inoprdatetime_dat"]);
                            if (p_objResultTable.Rows[0]["outempid_chr"] != DBNull.Value)
                                p_objEntity[j].Outempid_chr = Convert.ToString(p_objResultTable.Rows[0]["outempid_chr"]);
                            if (p_objResultTable.Rows[0]["outdatetime_dat"] != DBNull.Value)
                                p_objEntity[j].Outdatetime_dat = Convert.ToDateTime(p_objResultTable.Rows[0]["outdatetime_dat"]);
                            if (p_objResultTable.Rows[0]["outoprid_chr"] != DBNull.Value)
                                p_objEntity[j].Outoprid_chr = Convert.ToString(p_objResultTable.Rows[0]["outoprid_chr"]);
                            if (p_objResultTable.Rows[0]["outoprdatetime_dat"] != DBNull.Value)
                                p_objEntity[j].Outoprdatetime_dat = Convert.ToDateTime(p_objResultTable.Rows[0]["outoprdatetime_dat"]);
                            if (p_objResultTable.Rows[0]["returnempid_chr"] != DBNull.Value)
                                p_objEntity[j].Returnempid_chr = Convert.ToString(p_objResultTable.Rows[0]["returnempid_chr"]);
                            if (p_objResultTable.Rows[0]["returndatetime_dat"] != DBNull.Value)
                                p_objEntity[j].Returndatetime_dat = Convert.ToDateTime(p_objResultTable.Rows[0]["returndatetime_dat"]);
                            if (p_objResultTable.Rows[0]["returnoprid_chr"] != DBNull.Value)
                                p_objEntity[j].Returnoprid_chr = Convert.ToString(p_objResultTable.Rows[0]["returnoprid_chr"]);
                            if (p_objResultTable.Rows[0]["returnoprdatetime_dat"] != DBNull.Value)
                                p_objEntity[j].Returnoprdatetime_dat = Convert.ToDateTime(p_objResultTable.Rows[0]["returnoprdatetime_dat"]);
                            if (p_objResultTable.Rows[0]["useempid_chr"] != DBNull.Value)
                                p_objEntity[j].Useempid_chr = Convert.ToString(p_objResultTable.Rows[0]["useempid_chr"]);
                            if (p_objResultTable.Rows[0]["usedatetime_dat"] != DBNull.Value)
                                p_objEntity[j].Usedatetime_dat = Convert.ToDateTime(p_objResultTable.Rows[0]["usedatetime_dat"]);
                            if (p_objResultTable.Rows[0]["cancelempid_chr"] != DBNull.Value)
                                p_objEntity[j].Cancelempid_chr = Convert.ToString(p_objResultTable.Rows[0]["cancelempid_chr"]);
                            if (p_objResultTable.Rows[0]["canceldatetime_dat"] != DBNull.Value)
                                p_objEntity[j].Canceldatetime_dat = Convert.ToDateTime(p_objResultTable.Rows[0]["canceldatetime_dat"]);
                            if (p_objResultTable.Rows[0]["refempid_chr"] != DBNull.Value)
                                p_objEntity[j].Refempid_chr = Convert.ToString(p_objResultTable.Rows[0]["refempid_chr"]);
                            if (p_objResultTable.Rows[0]["refdatetime_dat"] != DBNull.Value)
                                p_objEntity[j].Refdatetime_dat = Convert.ToDateTime(p_objResultTable.Rows[0]["refdatetime_dat"]);
                            if (p_objResultTable.Rows[0]["note_vchr"] != DBNull.Value)
                                p_objEntity[j].Note_vchr = Convert.ToString(p_objResultTable.Rows[0]["note_vchr"]);
                            if (p_objResultTable.Rows[0]["totalsum_mny"] != DBNull.Value)
                                p_objEntity[j].Totalsum_mny = Convert.ToInt32(p_objResultTable.Rows[0]["totalsum_mny"]);
                            if (p_objResultTable.Rows[0]["acctsum_mny"] != DBNull.Value)
                                p_objEntity[j].Acctsum_mny = Convert.ToInt32(p_objResultTable.Rows[0]["acctsum_mny"]);
                            if (p_objResultTable.Rows[0]["sbsum_mny"] != DBNull.Value)
                                p_objEntity[j].Sbsum_mny = Convert.ToInt32(p_objResultTable.Rows[0]["sbsum_mny"]);
                        }
                    }
                }
                HRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region Update  some fileds by primaryKey
        /// <summary>
        /// Update  some fileds by primaryKey  
        /// </summary>
        /// <param name="p_strColumns">Columns</param>
        /// <param name="p_strValues">Values</param>
        /// <param name="p_Id">PrimaryKey</param>
        [AutoComplete]
        public long lngUpdateSomeFiledsByPrimaryKey(IPrincipal p_objPrincipal, string[] p_strColumns, string[] p_strValues, int p_Id)
        {
            long lngRes = -1;
            clsHRPTableService HRPSvc = new clsHRPTableService();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBillSvc", "lngUpdateSomeFiledsByPrimaryKey");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = "UPDATE t_bse_bill ";
            strSQL += " SET ";
            for (int i = 0; i < p_strColumns.Length; i++)
            {
                if (i == p_strColumns.Length - 1)
                {
                    strSQL += p_strColumns[i] + "= '" + p_strValues[i] + "'";
                }
                else
                {
                    strSQL += p_strColumns[i] + "= '" + p_strValues[i] + "' , ";
                }
            }
            strSQL += " WHERE  billid_int= '" + p_Id.ToString() + "'";
            try
            {
                lngRes = HRPSvc.DoExcute(strSQL);
                HRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region Update  some fileds by Condition
        /// <summary>
        /// Update  some fileds by Condition  
        /// </summary>
        /// <param name="p_strColumns">Columns</param>
        /// <param name="p_strValues">Values</param>
        /// <param name="p_strWhereCondition">Where Condition,if empty then update all</param>
        [AutoComplete]
        public long lngUpdateSomeFiledsByCondition(IPrincipal p_objPrincipal, string[] p_strColumns, string[] p_strValues, string p_strWhereCondition)
        {
            long lngRes = -1;
            clsHRPTableService HRPSvc = new clsHRPTableService();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBillSvc", "lngUpdateSomeFiledsByCondition");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = "UPDATE t_bse_bill ";
            strSQL += " SET ";
            for (int i = 0; i < p_strColumns.Length; i++)
            {
                if (i == p_strColumns.Length - 1)
                {
                    strSQL += p_strColumns[i] + "= '" + p_strValues[i] + "'";
                }
                else
                {
                    strSQL += p_strColumns[i] + "= '" + p_strValues[i] + "' , ";
                }
            }
            if (p_strWhereCondition != "")
                strSQL += "Where " + p_strWhereCondition;
            try
            {
                lngRes = HRPSvc.DoExcute(strSQL);
                HRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region Update  All fileds by primaryKey
        /// <summary>
        /// Update  All fileds by primaryKey  
        /// </summary>
        /// <param name="p_objEntity">clsBill_VO Entity Object</param>
        /// <param name="p_Id">clsBill_VO PrimaryKey</param>
        [AutoComplete]
        public long lngUpdateALLFiledsByPrimaryKey(IPrincipal p_objPrincipal, clsBill_VO p_objEntity, int p_Id)
        {
            long lngRes = -1;
            clsHRPTableService HRPSvc = new clsHRPTableService();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBillSvc", "lngUpdateALLFiledsByPrimaryKey");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL =
            "UPDATE t_bse_bill "
            + "	SET "
            + "billid_int=?,billtype_chr=?,billno_vchr=?,status_int=?,inempid_chr=?,indatetime_dat=?,inoprid_chr=?,inoprdatetime_dat=?,outempid_chr=?,outdatetime_dat=?,outoprid_chr=?,outoprdatetime_dat=?,returnempid_chr=?,returndatetime_dat=?,returnoprid_chr=?,returnoprdatetime_dat=?,useempid_chr=?,usedatetime_dat=?,cancelempid_chr=?,canceldatetime_dat=?,refempid_chr=?,refdatetime_dat=?,note_vchr=?,totalsum_mny=?,acctsum_mny=?,sbsum_mny=?"
            + " WHERE  billid_int= '" + p_Id.ToString() + "'";
            try
            {
                IDataParameter[] paramArr = null;
                HRPSvc.CreateDatabaseParameter(26, out paramArr);
                paramArr[0].Value = p_objEntity.Billid_int;
                paramArr[1].Value = p_objEntity.Billtype_chr;
                paramArr[2].Value = p_objEntity.Billno_vchr;
                paramArr[3].Value = p_objEntity.Status_int;
                paramArr[4].Value = p_objEntity.Inempid_chr;
                paramArr[5].Value = p_objEntity.Indatetime_dat;
                paramArr[6].Value = p_objEntity.Inoprid_chr;
                paramArr[7].Value = p_objEntity.Inoprdatetime_dat;
                paramArr[8].Value = p_objEntity.Outempid_chr;
                paramArr[9].Value = p_objEntity.Outdatetime_dat;
                paramArr[10].Value = p_objEntity.Outoprid_chr;
                paramArr[11].Value = p_objEntity.Outoprdatetime_dat;
                paramArr[12].Value = p_objEntity.Returnempid_chr;
                paramArr[13].Value = p_objEntity.Returndatetime_dat;
                paramArr[14].Value = p_objEntity.Returnoprid_chr;
                paramArr[15].Value = p_objEntity.Returnoprdatetime_dat;
                paramArr[16].Value = p_objEntity.Useempid_chr;
                paramArr[17].Value = p_objEntity.Usedatetime_dat;
                paramArr[18].Value = p_objEntity.Cancelempid_chr;
                paramArr[19].Value = p_objEntity.Canceldatetime_dat;
                paramArr[20].Value = p_objEntity.Refempid_chr;
                paramArr[21].Value = p_objEntity.Refdatetime_dat;
                paramArr[22].Value = p_objEntity.Note_vchr;
                paramArr[23].Value = p_objEntity.Totalsum_mny;
                paramArr[24].Value = p_objEntity.Acctsum_mny;
                paramArr[25].Value = p_objEntity.Sbsum_mny;
                long lngRecordsAffected = -1; 
                lngRes = HRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecordsAffected, paramArr);
                HRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region Insert
        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="p_objEntity">clsBill_VO Entity Object</param>
        /// <param name="p_intBillid_int">id</param>
        [AutoComplete]
        public long lngInsert(IPrincipal p_objPrincipal, clsBill_VO p_objEntity,out int  p_intBillid_int)
        {
            long lngRes = -1;
            p_intBillid_int = -1;
            clsHRPTableService HRPSvc = new clsHRPTableService();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBillSvc", "lngInsert");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = string.Format(
            "INSERT INTO t_bse_bill( "
            + "billid_int,billtype_chr,billno_vchr,status_int,inempid_chr,indatetime_dat,inoprid_chr,inoprdatetime_dat,outempid_chr,outdatetime_dat,outoprid_chr,outoprdatetime_dat,returnempid_chr,returndatetime_dat,returnoprid_chr,returnoprdatetime_dat,useempid_chr,usedatetime_dat,cancelempid_chr,canceldatetime_dat,refempid_chr,refdatetime_dat,note_vchr,totalsum_mny,acctsum_mny,sbsum_mny"
            + ") VALUES ( "
            + "?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?"
            + ")");
            try
            {
                int strRecordID = -1;
                lngRes = HRPSvc.m_lngGenerateNewID("t_bse_bill", "billid_int", out strRecordID);
                if (lngRes > 0)
                {

                    IDataParameter[] paramArr = null;
                    HRPSvc.CreateDatabaseParameter(26, out paramArr);
                    paramArr[0].Value = strRecordID;
                    paramArr[1].Value = p_objEntity.Billtype_chr;
                    paramArr[2].Value = p_objEntity.Billno_vchr;
                    paramArr[3].Value = p_objEntity.Status_int;
                    paramArr[4].Value = p_objEntity.Inempid_chr;
                    paramArr[5].Value = p_objEntity.Indatetime_dat;
                    paramArr[6].Value = p_objEntity.Inoprid_chr;
                    paramArr[7].Value = p_objEntity.Inoprdatetime_dat;
                    paramArr[8].Value = p_objEntity.Outempid_chr;
                    paramArr[9].Value = p_objEntity.Outdatetime_dat;
                    paramArr[10].Value = p_objEntity.Outoprid_chr;
                    paramArr[11].Value = p_objEntity.Outoprdatetime_dat;
                    paramArr[12].Value = p_objEntity.Returnempid_chr;
                    paramArr[13].Value = p_objEntity.Returndatetime_dat;
                    paramArr[14].Value = p_objEntity.Returnoprid_chr;
                    paramArr[15].Value = p_objEntity.Returnoprdatetime_dat;
                    paramArr[16].Value = p_objEntity.Useempid_chr;
                    paramArr[17].Value = p_objEntity.Usedatetime_dat;
                    paramArr[18].Value = p_objEntity.Cancelempid_chr;
                    paramArr[19].Value = p_objEntity.Canceldatetime_dat;
                    paramArr[20].Value = p_objEntity.Refempid_chr;
                    paramArr[21].Value = p_objEntity.Refdatetime_dat;
                    paramArr[22].Value = p_objEntity.Note_vchr;
                    paramArr[23].Value = p_objEntity.Totalsum_mny;
                    paramArr[24].Value = p_objEntity.Acctsum_mny;
                    paramArr[25].Value = p_objEntity.Sbsum_mny;
                    long lngRecordsAffected = -1;
                    lngRes = HRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecordsAffected, paramArr);
                    HRPSvc.Dispose();
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region Delete Record By PrimaryKey
        /// <summary>
        /// Delete Record By PrimaryKey
        /// </summary>
        /// <param name="p_billid_int">PrimaryKey 票据ID</param>
        [AutoComplete]
        public long lngDeleteByPrimaryKey(IPrincipal p_objPrincipal, int p_Id)
        {
            long lngRes = -1;
            clsHRPTableService HRPSvc = new clsHRPTableService();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsBillSvc", "lngDeleteByPrimaryKey");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = "DELETE  FROM t_bse_bill  WHERE  billid_int= '" + p_Id.ToString() + "'";
            try
            {
                lngRes = HRPSvc.DoExcute(strSQL);
                HRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

    }
    #endregion
}
