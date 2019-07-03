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
    /// 特定病种对应ICD10码间维护中间层
    /// 作者：He Guiqiu
    /// 创建时间:2006-06-22
    /// </summary>
    /// 
    
    [Transaction(TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsYbdeadeficdSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
	{
        public clsYbdeadeficdSvc()
		{

        }

        #region 取医保特种病
        /// <summary>
        /// 取医保特种病
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetSpecialDisease(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable p_dtResult)
        {
            long lngRes = 0;
            p_dtResult = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsPrepayQuerySvc", "GetSpecialDisease");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @" select deacode_chr, deadesc_vchr, yearmoney_int, sort_int, status_int, note_vchr from t_opr_ybspecialtypedisease  order by deacode_chr";

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

        #region ICD10
        /// <summary>
        /// ICD10
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetICD(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable p_dtResult)
        {
            long lngRes = 0;
            p_dtResult = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsPrepayQuerySvc", "GetICD");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @" select jxcode_chr, wbcode_chr, pycode_chr, icdname_vchr, icdcode_chr, icdcat_chr from t_aid_icd10 order by icdcode_chr";
                              
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

        #region 根据医保大病取对应的ICD10
        /// <summary>
        /// 根据医保大病取对应的ICD10
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetICDByDeaCode(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDeaCode, out DataTable p_dtResult)
        {
            long lngRes = 0;
            p_dtResult = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsPrepayQuerySvc", "GetICDByDeaCode");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = @"  SELECT T_AID_ICD10.ICDCODE_CHR,   
                                       T_AID_ICD10.ICDNAME_VCHR,   
                                       T_AID_ICD10.PYCODE_CHR,   
                                       T_AID_ICD10.WBCODE_CHR,   
                                       T_AID_ICD10.JXCODE_CHR,   
                                       T_OPR_YBDEADEFICD10.DEACODE_CHR  
                                FROM T_AID_ICD10,   
                                     T_OPR_YBDEADEFICD10  
                                WHERE ( T_AID_ICD10.ICDCODE_CHR = T_OPR_YBDEADEFICD10.ICDCODE_CHR ) AND 
                                        T_OPR_YBDEADEFICD10.DEACODE_CHR = '" 
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

        #region 增加特定病种和ICD10码间对应记录
        /// <summary>
        /// 增加特定病种和ICD10码间对应记录
		/// </summary>
		/// <param name="p_objPrincipal"></param>
        /// <param name="p_strDeaCode"></param>
        /// <param name="p_newArr"></param>
		/// <returns></returns>
		[AutoComplete]
        public long AddYbdeaDefICD(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDeaCode, ArrayList p_newArr)
        {
            long lngRes=0;

            if (p_strDeaCode == "" || p_newArr.Count == 0)
            {
                return -1;
            }

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "AddYbdeaDefICD");
			if(lngRes < 0)
			{
				return -1;
			}
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            for (int i1 = 0; i1 < p_newArr.Count; i1++)
            {
                string strSQL = "INSERT INTO t_opr_ybdeadeficd10 (DEACODE_CHR, ICDCODE_CHR) VALUES (?,?)";
                try
                {
                    System.Data.IDataParameter[] dataParameterArr = null;
                    objHRPSvc.CreateDatabaseParameter(2, out dataParameterArr);

                    dataParameterArr[0].Value = p_strDeaCode;
                    dataParameterArr[1].Value = ((string) p_newArr[i1]).Trim();
                    
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
        
        #region 删除特定病种和ICD10码间对应记录
        /// <summary>
        /// 删除特定病种和ICD10码间对应记录
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strDeaCode"></param>
        /// <param name="p_removeArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long RemoveYbdeaDefICD(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDeaCode, ArrayList p_removeArr)
        {
            long lngRes = 0;

            if (p_strDeaCode == "")
            {
                return -1;
            }

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "RemoveYbdeaDefICD");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            for (int i1 = 0; i1 < p_removeArr.Count; i1++)
            {
                string strSQL = "DELETE FROM t_opr_ybdeadeficd10 WHERE (trim(DEACODE_CHR) = ? AND trim(ICDCODE_CHR) = ?)";
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
        public long SaveDeaDef(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDeaCode, ArrayList p_removeArr, ArrayList p_newArr)
        {
            long lngRes = 0;

            if (p_strDeaCode == "")
            {
                return -1;
            }

            if (p_removeArr.Count > 0)
            {
                lngRes = RemoveYbdeaDefICD(p_objPrincipal, p_strDeaCode, p_removeArr);
                if (lngRes < 0)
                {
                    return lngRes;
                }
            }

            if (p_newArr.Count > 0)
            {
                lngRes = AddYbdeaDefICD(p_objPrincipal, p_strDeaCode, p_newArr);
            }


            return lngRes;
        }
        #endregion 
    }
}
