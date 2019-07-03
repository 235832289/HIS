using System;
using System.Collections.Generic;
using com.digitalwave.Utility;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.security;
using System.EnterpriseServices;
using System.Data;
using System.Collections;
//using Oracle.DataAccess.Client;
using com.digitalwave.iCare.middletier.HIS;
//using com.digitalwave.iCare.middletier.CryptographyLib; 

namespace com.digitalwave.iCare.middletier.HIS
{
    /// <summary>
    /// 查询相关中间件
    /// </summary>
    [Transaction(TransactionOption.Supported)]
    [ObjectPooling(true)]
    public class clsDoctorWorkStation_SupportedSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public clsDoctorWorkStation_SupportedSvc()
        {
        }
        #endregion

        #region 根据药房ID、药品读取当前理论库存（茶山暂时用不用理论库存，改为检查实际库存）
        /// <summary>
        /// 根据药房ID、药品读取当前理论库存（茶山暂时用不用理论库存，改为检查实际库存）
        /// </summary>
        /// <param name="strStoreID"></param>
        /// <param name="strItemID"></param>
        /// <param name="strDeductType"></param>
        /// <param name="dtInventory"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetTheoryAmountByMedID(string strStoreID, string strItemID, string strDeductType, out DataTable dtInventory)
        {
            long lngRes = 0;
            string strSub = "";
            string SQL = string.Empty;
            dtInventory = new DataTable();

            SQL = @"select a.drugstoreid_chr,
                           a.seriesid_int,
                           a.medicineid_chr,
                           a.instoragedate_dat,
                           b.itemid_chr,
                           b.itemcode_vchr,
                           a.validperiod_dat,
                           a.lotno_vchr,
                           a.packqty_dec,
                           a.storagerackid_chr,
                           a.oprealgross_int   as jbsl,
                           a.iprealgross_int   as zxsl,
                           m.assistcode_chr    as medcode
                      from t_ds_storage_detail a,
                           t_bse_chargeitem    b,
                           t_ds_storage        c,
                           t_bse_medicine      m
                     where b.itemsrcid_vchr = a.medicineid_chr
                       and a.medicineid_chr = m.medicineid_chr
                       and a.status = 1
                       and a.canprovide_int = 1
                       and a.medicineid_chr = c.medicineid_chr
                       and c.noqtyflag_int = 0
                       and c.ifstop_int = 0
                       and a.drugstoreid_chr = c.drugstoreid_chr
                       and a.drugstoreid_chr in ({0})
                       and b.itemid_chr in ({1}) 
                    ";
            SQL = string.Format(SQL, strStoreID, strItemID);

            if (strDeductType == "1")
            {
                strSub = " order by a.dsinstoragedate_dat, a.instoreid_vchr";
            }
            else if (strDeductType == "2")
            {
                strSub = " order by a.validperiod_dat, a.instoreid_vchr";
            }
            else if (strDeductType == "3")
            {
                strSub = " order by a.dsinstoragedate_dat, a.validperiod_dat, a.instoreid_vchr";
            }
            else if (strDeductType == "4")
            {
                strSub = " order by a.validperiod_dat, a.dsinstoragedate_dat, a.instoreid_vchr";
            }
            SQL = SQL + strSub;

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dtInventory);
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

        #region 根据收费项目ID查询药品ID
        /// <summary>
        /// 根据收费项目ID查询药品ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [AutoComplete]
        public string m_strGetMedicineIDByChargeItemID(string ID)
        {
            long lngRes = 0;
            string strMedID = "";

            string SQL = @"select  a.itemsrcid_vchr
                              from t_bse_chargeitem a, t_bse_medicine b
                             where a.itemsrcid_vchr = b.medicineid_chr 
                               and a.itemid_chr = ?";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                ParamArr[0].Value = ID;

                DataTable dt = new DataTable();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
                if (lngRes > 0 && dt.Rows.Count > 0)
                {
                    strMedID = dt.Rows[0][0].ToString().Trim();
                }

                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return strMedID;
        }
        #endregion

        #region 获取药房设置信息
        /// <summary>
        /// 获取药房设置信息
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetMedStore(out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();

            string SQL = @"select  a.medstoreid_chr, a.medstorename_vchr, a.medstoretype_int,
                                   a.medicnetype_int, a.urgence_int, a.deptid_chr
                              from t_bse_medstore a";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dt);
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

        #region 微信检查是否绑卡
        /// <summary>
        /// 微信检查是否绑卡
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        [AutoComplete]
        public bool IsWechatBanding(string cardNo)
        {
            string Sql = @"select t.cardno from opRegWeChatBinding t where t.cardno = ? and t.status = 1";
            try
            {
                clsHRPTableService svc = new clsHRPTableService();
                IDataParameter[] parm = null;
                svc.CreateDatabaseParameter(1, out parm);
                parm[0].Value = cardNo;

                DataTable dt = null;
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                svc.Dispose();

                if (dt != null && dt.Rows.Count > 0)
                {
                    return true;    // 存在绑定
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return false;
        }
        #endregion

        #region 药品库存判断
        /// <summary>
        /// 药品库存判断
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="storeId"></param>
        /// <returns></returns>
        [AutoComplete]
        public bool IsHaveDrugStock(string itemId, string storeId)
        {
            string Sql = @"select 1
                              from t_bse_chargeitem a
                             inner join t_bse_medicine b
                                on a.itemsrcid_vchr = b.medicineid_chr
                             where a.ifstop_int = 0
                               and b.ifstop_int = 0
                               and a.itemid_chr = ?
                               and exists (select 1
                                      from t_ds_storage t1, t_ds_storage_detail t2
                                     where t1.medicineid_chr = t2.medicineid_chr
                                       and t1.medicineid_chr = b.medicineid_chr
                                       and t1.drugstoreid_chr = t2.drugstoreid_chr
                                       and t1.drugstoreid_chr = ?
                                       and t1.noqtyflag_int = 0         --药房缺药标志 0-有药 1－缺药
                                       and t1.ifstop_int = 0            --停用标志 0-正常 1-停用
                                       and t2.canprovide_Int = 1
                                       and t2.iprealgross_Int > 0)";
            try
            {
                clsHRPTableService svc = new clsHRPTableService();
                IDataParameter[] parm = null;
                svc.CreateDatabaseParameter(2, out parm);
                parm[0].Value = itemId;
                parm[1].Value = storeId;
                DataTable dt = null;
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                svc.Dispose();

                if (dt != null && dt.Rows.Count > 0)
                {
                    return true;    // 存在药品、库存
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return false;
        }
        #endregion

        #region 科室编码
        /// <summary>
        /// 科室编码
        /// </summary>
        /// <param name="deptId"></param>
        /// <returns></returns>
        [AutoComplete]
        public string GetDeptCode(string deptId)
        {
            string deptCode = string.Empty;
            string Sql = @"select t.code_vchr from t_bse_deptdesc t where t.deptid_chr = ?";
            try
            {
                clsHRPTableService svc = new clsHRPTableService();
                IDataParameter[] parm = null;
                svc.CreateDatabaseParameter(1, out parm);
                parm[0].Value = deptId;
                DataTable dt = null;
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                svc.Dispose();
                if (dt != null && dt.Rows.Count > 0)
                {
                    deptCode = dt.Rows[0]["code_vchr"].ToString();
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return deptCode;
        }
        #endregion

        #region 获取现场号使用处方信息
        /// <summary>
        /// 获取现场号使用处方信息
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetTodayRegInfo(string recipeId)
        {
            string Sql = string.Empty;
            DataTable dt = new DataTable();
            try
            {
                Sql = @"select a.serno,
                               a.deptcode,
                               a.doctcode,
                               a.subscribeno,
                               c.lastname_vchr     as patName,
                               c.idcard_chr        as idNo,
                               c.sex_chr           as sex,
                               c.homephone_vchr    as contactTel,
                               d.patientcardid_chr as cardNo
                          from opRegPlatformLog a
                         inner join t_opr_outpatientrecipe b
                            on a.recipeid = b.outpatrecipeid_chr
                         inner join t_bse_patient c
                            on b.patientid_chr = c.patientid_chr
                         inner join t_bse_patientcard d
                            on b.patientid_chr = d.patientid_chr
                         where a.recipeid = ?";

                clsHRPTableService svc = new clsHRPTableService();
                IDataParameter[] parm = null;
                svc.CreateDatabaseParameter(1, out parm);
                parm[0].Value = recipeId;
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                svc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return dt;
        }
        #endregion

        #region 判断处方里是否只包含饮片,否则不允许代煎
        /// <summary>
        /// 判断处方里是否只包含饮片,否则不允许代煎
        /// </summary>
        /// <param name="lstChargeItemId"></param>
        /// <returns></returns>
        [AutoComplete]
        public bool CheckRecipeSlices(List<string> lstChargeItemId)
        {
            string Sql = string.Empty;
            bool ret = false;
            DataTable dt = new DataTable();
            try
            {
                Sql = @"select distinct b.medicinepreptype_chr
                          from t_bse_chargeitem a
                         inner join t_bse_medicine b
                            on a.itemsrcid_vchr = b.medicineid_chr
                         where a.itemid_chr in ({0})";

                string itemIdArr = string.Empty;
                foreach (string id in lstChargeItemId)
                {
                    itemIdArr += "'" + id + "',";
                }
                clsHRPTableService svc = new clsHRPTableService();
                svc.lngGetDataTableWithoutParameters(string.Format(Sql, itemIdArr.TrimEnd(',')), ref dt);
                svc.Dispose();
                if (dt != null && dt.Rows.Count == 1 && dt.Rows[0]["medicinepreptype_chr"].ToString() == "12")   // 饮片
                {
                    ret = true;
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

        #region 患者代煎药收件信息
        /// <summary>
        /// 患者代煎药收件信息
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        [AutoComplete]
        public DataTable GetPatientContactInfo(string patientId)
        {
            string Sql = string.Empty;
            DataTable dt = new DataTable();
            try
            {
                Sql = @"select t.contactpersonfirstname_vchr,
                               t.contactpersonlastname_vchr,
                               t.mobile_chr,
                               t.consigneeaddr
                          from t_bse_patient t
                         where t.patientid_chr = ?";

                clsHRPTableService svc = new clsHRPTableService();
                IDataParameter[] parm = null;
                svc.CreateDatabaseParameter(1, out parm);
                parm[0].Value = patientId;
                svc.lngGetDataTableWithParameters(Sql, ref dt, parm);
                svc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return dt;
        }
        #endregion

        #region MyRegion

        #endregion

    }
}
