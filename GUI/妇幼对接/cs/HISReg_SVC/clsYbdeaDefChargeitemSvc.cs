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
    /// 特定病种对应收费项目维护中间层
    /// 作者：He Guiqiu
    /// 创建时间:2006-06-24
    /// </summary>
    /// 
    [Transaction(TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsYbdeaDefChargeitemSvc: com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        public clsYbdeaDefChargeitemSvc()
        {

        }

        #region 取收费项目
        /// <summary>
        /// 取收费项目
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strDeaCode"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetChargeItem(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable p_dtResult)
        {
            long lngRes = 0;
            p_dtResult = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsPrepayQuerySvc", "GetChargeItem");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"  SELECT T_BSE_CHARGEITEM.ITEMID_CHR,   
                                     T_BSE_CHARGEITEM.ITEMNAME_VCHR,   
                                     T_BSE_CHARGEITEM.ITEMCODE_VCHR,   
                                     T_BSE_CHARGEITEM.ITEMPYCODE_CHR,   
                                     T_BSE_CHARGEITEM.ITEMWBCODE_CHR,   
                                     T_BSE_CHARGEITEM.ITEMSPEC_VCHR,   
                                     T_BSE_CHARGEITEM.ITEMPRICE_MNY
                                FROM T_BSE_CHARGEITEM   
                                ORDER BY T_BSE_CHARGEITEM.ITEMCODE_VCHR";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtResult);
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

        #region 根据医保大病取对应的收费项目
        /// <summary>
        /// 根据医保大病取对应的收费项目
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strDeaCode"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetChargeItemByDeaCode(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDeaCode, out DataTable p_dtResult)
        {
            long lngRes = 0;
            p_dtResult = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsPrepayQuerySvc", "GetChargeItemByDeaCode");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"  SELECT T_BSE_CHARGEITEM.ITEMID_CHR,   
                                     T_BSE_CHARGEITEM.ITEMNAME_VCHR,   
                                     T_BSE_CHARGEITEM.ITEMCODE_VCHR,   
                                     T_BSE_CHARGEITEM.ITEMPYCODE_CHR,   
                                     T_BSE_CHARGEITEM.ITEMWBCODE_CHR,   
                                     T_BSE_CHARGEITEM.ITEMSPEC_VCHR,   
                                     T_BSE_CHARGEITEM.ITEMPRICE_MNY,   
                                     T_OPR_YBDEADEFCHARGEITEM.DEACODE_CHR  
                                FROM T_BSE_CHARGEITEM,   
                                     T_OPR_YBDEADEFCHARGEITEM  
                                WHERE ( T_BSE_CHARGEITEM.ITEMID_CHR = T_OPR_YBDEADEFCHARGEITEM.ITEMID_CHR )  AND 
                                            T_OPR_YBDEADEFCHARGEITEM.DEACODE_CHR = '"
                                       + p_strDeaCode + "'";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtResult);
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

        #region 增加特定病种和收费项目间对应记录
        /// <summary>
        /// 增加特定病种和收费项目间对应记录
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strDeaCode"></param>
        /// <param name="p_newArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long AddYbdeaDefChargeItem(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDeaCode, ArrayList p_newArr)
        {
            long lngRes = 0;

            if (p_strDeaCode == "" || p_newArr.Count == 0)
            {
                return -1;
            }

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "AddYbdeaDefChargeItem");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            for (int i1 = 0; i1 < p_newArr.Count; i1++)
            {
                string strSQL = "INSERT INTO T_OPR_YBDEADEFCHARGEITEM (DEACODE_CHR, ITEMID_CHR) VALUES (?,?)";
                try
                {
                    System.Data.IDataParameter[] dataParameterArr = null;
                    objHRPSvc.CreateDatabaseParameter(2, out dataParameterArr);

                    dataParameterArr[0].Value = p_strDeaCode;
                    dataParameterArr[1].Value = ((string)p_newArr[i1]).Trim();

                    long lngRecEff = -1;
                    lngRes = 0;
                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, dataParameterArr);
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

        #region 删除特定病种和收费项目间对应记录
        /// <summary>
        /// 删除特定病种和收费项目间对应记录
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strDeaCode"></param>
        /// <param name="p_removeArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long RemoveYbdeaDefChargeItem(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDeaCode, ArrayList p_removeArr)
        {
            long lngRes = 0;

            if (p_strDeaCode == "")
            {
                return -1;
            }

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "RemoveYbdeaDefChargeItem");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            for (int i1 = 0; i1 < p_removeArr.Count; i1++)
            {
                string strSQL = "DELETE FROM T_OPR_YBDEADEFCHARGEITEM WHERE (trim(DEACODE_CHR) = ? AND trim(ITEMID_CHR) = ?)";
                try
                {
                    System.Data.IDataParameter[] dataParameterArr = null;
                    objHRPSvc.CreateDatabaseParameter(2, out dataParameterArr);

                    dataParameterArr[0].Value = p_strDeaCode;
                    dataParameterArr[1].Value = ((string)p_removeArr[i1]).Trim();

                    long lngRecEff = -1;
                    lngRes = 0;
                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, dataParameterArr);
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

        #region 保存修改
        /// <summary>
        /// 保存修改
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strDeaCode"></param>
        /// <param name="p_removeArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long SaveDeaDefChargeItem(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDeaCode, ArrayList p_removeArr, ArrayList p_newArr)
        {
            long lngRes = 0;

            if (p_strDeaCode == "")
            {
                return -1;
            }

            if (p_removeArr.Count > 0)
            {
                lngRes = RemoveYbdeaDefChargeItem(p_objPrincipal, p_strDeaCode, p_removeArr);
                if (lngRes < 0)
                {
                    return lngRes;
                }
            }

            if (p_newArr.Count > 0)
            {
                lngRes = AddYbdeaDefChargeItem(p_objPrincipal, p_strDeaCode, p_newArr);
            }


            return lngRes;
        }
        #endregion 

    }
}
