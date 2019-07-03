using System;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
using System.EnterpriseServices;
using System.Data;

namespace com.digitalwave.iCare.middletier.HIS
{
    /// <summary>
    /// clsCmCookingMethodItemGroupSvc 的摘要说明。
    /// </summary>
    [Transaction(TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsCmCookingMethodItemGroupSvc:com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        public clsCmCookingMethodItemGroupSvc()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
        }
        #region 获取整剂用法信息
        /// <summary>
        /// 获取整剂用法信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetCMUsageInformation(System.Security.Principal.IPrincipal p_objPrincipal,out DataTable m_objTable)
        {
            long lngRes = 0;
            m_objTable = null;
            //权限类
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsCmCookingMethodItemGroupSvc", "m_lngGetCMUsageInformation");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = @"select * from t_aid_cmcookingmethod";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref m_objTable);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion
        #region 根据用法ID获取带出项目的信息
        /// <summary>
        /// 根据用法ID获取带出项目的信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strUsageID"></param>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetRelationItemInformationByUsageID(System.Security.Principal.IPrincipal p_objPrincipal,string m_strUsageID, out DataTable m_objTable)
        {
            long lngRes = 0;
            m_objTable = null;
            //权限类
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsCmCookingMethodItemGroupSvc", "m_lngGetRelationItemInformationByUsageID");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = @"SELECT a.*,decode (b.opchargeflg_int,
               0, b.itemprice_mny,
               1, round (b.itemprice_mny / b.packqty_dec, 4)
              ) as itemprice_mny, b.*, c.noqtyflag_int,d.USAGEID_CHR as USAGEID_CHR1,d.USAGENAME_VCHR as USAGENAME_VCHR1,e.USAGENAME_VCHR
                              FROM t_bse_chargeitemusagegroup a, t_bse_chargeitem b, t_bse_medicine c,t_bse_usagetype d,t_bse_usagetype e
                              WHERE a.usageid_chr = '" +m_strUsageID+@"'
                              AND a.itemid_chr = b.itemid_chr
                              and a.USAGEID_CHR=e.USAGEID_CHR(+)
	                          and b.USAGEID_CHR=d.USAGEID_CHR(+)
                              AND b.itemsrcid_vchr = c.medicineid_chr(+)";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref m_objTable);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
            #endregion
        #region 根据行号ID,用法ID和项目ID删除关联表信息
        /// <summary>
        /// 根据行号ID,用法ID和项目ID删除关联表信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strRowNo"></param>
        /// <param name="m_strUsageID"></param>
        /// <param name="m_strItemID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDelRelationItemInformationByID(System.Security.Principal.IPrincipal p_objPrincipal,string m_strRowNo, string m_strUsageID, string m_strItemID)
        {
            long lngRes = 0;
            //权限类
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsCmCookingMethodItemGroupSvc", "m_lngDelRelationItemInformationByID");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = @"delete T_AID_CMCOOKINGMETHODITEMGROUP A where A.rowno_chr='"+m_strRowNo+"'and  A.usageid_chr='" + m_strUsageID + "' and  A.itemid_chr='"+m_strItemID+"'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion
        #region 新增一条关联表信息
	    /// <summary>
	    /// 新增一条关联表信息  
	    /// </summary>
	    /// <param name="p_objPrincipal"></param>
	    /// <param name="p_strRecordID"></param>
	    /// <param name="p_objRecord"></param>
	     /// <returns></returns>
		[AutoComplete]
		public long m_lngDoAddNewChargeItemUsageGroup(System.Security.Principal.IPrincipal p_objPrincipal,out string p_strRecordID,clsChargeItemUsageGroup_VO p_objRecord)
		{
			long lngRes=0;
			p_strRecordID = "";
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsCmCookingMethodItemGroupSvc","m_lngDoAddNewChargeItemUsageGroup");
			if(lngRes < 0)
			{
				return -1;
			}
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			lngRes = objHRPSvc.lngGenerateID(4,"ROWNO_CHR","t_aid_cmcookingmethoditemgroup",out p_strRecordID);
			if(lngRes < 0)
				return lngRes;
			string strSQL = "INSERT INTO t_aid_cmcookingmethoditemgroup (ROWNO_CHR,USAGEID_CHR,ITEMID_CHR,QTY_DEC,CLINICTYPE_INT,BIHQTY_DEC,BIHTYPE_INT,CONTINUEUSETYPE_INT) VALUES (?,?,?,?,?,?,?,?)";
			try
			{
				System.Data.IDataParameter[] objLisAddItemRefArr = null;
				objHRPSvc.CreateDatabaseParameter(8,out objLisAddItemRefArr);
				objLisAddItemRefArr[0].Value = p_strRecordID;//p_objRecord.m_strROWNO_CHR;
				objLisAddItemRefArr[1].Value = p_objRecord.m_strUsageID;
				objLisAddItemRefArr[2].Value = p_objRecord.m_strItemID;
				objLisAddItemRefArr[3].Value = p_objRecord.m_strUNITPRICE;
				objLisAddItemRefArr[4].Value = p_objRecord.m_intCLINICTYPE_INT;
				objLisAddItemRefArr[5].Value = p_objRecord.m_dblBIHQTY_DEC;
				objLisAddItemRefArr[6].Value = p_objRecord.m_intBIHTYPE_INT;
				objLisAddItemRefArr[7].Value = p_objRecord.m_intCONTINUEUSETYPE_INT;
				long lngRecEff = -1;
				//往表增加记录
				lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL,ref lngRecEff,objLisAddItemRefArr);
				objHRPSvc.Dispose();				
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion
		#region 修改关联表信息
		/// <summary>
        ///  修改关联表信息
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="objResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDoModifyChargeItemUsageGroup(System.Security.Principal.IPrincipal p_objPrincipal,clsChargeItemUsageGroup_VO objResult)
		{
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsCmCookingMethodItemGroupSvc", "m_lngDoModifyChargeItemUsageGroup");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			if(lngRes<0)
				return -1;
            string strSQL = "UPDate t_aid_cmcookingmethoditemgroup set " 
				+ "QTY_DEC="+objResult.m_strUNITPRICE
				+ ",CLINICTYPE_INT="+objResult.m_intCLINICTYPE_INT.ToString()
				+ ",BIHQTY_DEC="+objResult.m_dblBIHQTY_DEC.ToString()
				+ ",BIHTYPE_INT="+objResult.m_intBIHTYPE_INT.ToString()
				+ ",itemid_chr='"+objResult.m_strItemID
				+ "',CONTINUEUSETYPE_INT="+objResult.m_intCONTINUEUSETYPE_INT.ToString()
				+ " Where TRIM(usageid_chr)='" + objResult.m_strUsageID.Trim() + "' and TRIM(itemid_chr)='"+objResult.m_strTOTALPRICE.Trim()+"' ";

			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objSvc = new clsHRPTableService();
				lngRes = objSvc.DoExcute(strSQL);
				if(lngRes>0)
				{
					if(objResult.m_intFlag==1)
					{
                        strSQL = "UPDate t_aid_cmcookingmethoditemgroup set " 
							+ "itemid_chr='"+objResult.m_strItemID
							+ "'  Where TRIM(usageid_chr) <>'" + objResult.m_strUsageID.Trim() + "' and TRIM(itemid_chr)='"+objResult.m_strTOTALPRICE.Trim()+"' ";
						lngRes = objSvc.DoExcute(strSQL);
					}
				}
				objSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		
		}
		#endregion
        #region 删除关联表信息
        /// <summary>
        /// 删除关联表信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="objResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDelUsageGroupByID(System.Security.Principal.IPrincipal p_objPrincipal, clsChargeItemUsageGroup_VO objResult)
        {
            long lngRes = 0;
            //权限类
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsCmCookingMethodItemGroupSvc", "m_lngDelUsageGroupByID");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = "";
            if (objResult.m_strItemID == null || objResult.m_strItemID == "")
            {
                strSQL = "Delete t_bse_chargeitemusagegroup " +
                    " Where usageid_chr='" + objResult.m_strUsageID + "' ";
            }
            else
            {
                strSQL = "Delete t_bse_chargeitemusagegroup " +
                    " Where usageid_chr='" + objResult.m_strUsageID + "' And " +
                    " itemid_chr='" + objResult.m_strItemID + "' ";
                if (objResult.m_intFlag == 1)
                {
                    strSQL = "Delete t_bse_chargeitemusagegroup " +
                        " Where itemid_chr='" + objResult.m_strItemID + "'";
                }
            }
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;

        }
        #endregion
    }
}
