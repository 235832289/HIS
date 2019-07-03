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
	/// clsRegChargeTypeSvc 的摘要说明。
	/// </summary>
	[Transaction(TransactionOption.Required)]
	[ObjectPooling(true)]
	public class clsRegChargeTypeSvc:com.digitalwave.iCare.middletier.clsMiddleTierBase
	{
		public clsRegChargeTypeSvc()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}


		///挂号费种
		#region 挂号费种(返回所有的费种)	张国良	2004-8-8
		/// <summary>
		/// 收费项目分类类型(返回所有的类别)
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="objResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngFindRegChargeTypeList(System.Security.Principal.IPrincipal p_objPrincipal, out clsRegchargeType_VO[] p_objResultArr)
		{
			p_objResultArr = new clsRegchargeType_VO[0];
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngFindRegChargeTypeList");
			if(lngRes < 0)
			{
				return -1;
			}
			string strSQL = @"SELECT * FROM t_bse_registerchargetype order by CHARGEID_CHR ";
			try
			{
				DataTable dtbResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
				objHRPSvc.Dispose();
				if(lngRes > 0 && dtbResult.Rows.Count > 0)
				{
					p_objResultArr = new clsRegchargeType_VO[dtbResult.Rows.Count];
					for(int i1=0;i1<p_objResultArr.Length;i1++)
					{
						p_objResultArr[i1] = new clsRegchargeType_VO();
						p_objResultArr[i1].m_strCHARGEID_CHR = dtbResult.Rows[i1]["CHARGEID_CHR"].ToString().Trim();
						p_objResultArr[i1].m_strCHARGENAME_CHR = dtbResult.Rows[i1]["CHARGENAME_CHR"].ToString().Trim();
						p_objResultArr[i1].m_strMEMO_VCHR = dtbResult.Rows[i1]["MEMO_VCHR"].ToString().Trim();
						p_objResultArr[i1].m_strCHARGENO_VCHR = dtbResult.Rows[i1]["CHARGENO_VCHR"].ToString().Trim();
						p_objResultArr[i1].m_strISUSING_NUM = dtbResult.Rows[i1]["ISUSING_NUM"].ToString().Trim();
					}
				}
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

		#region  新增挂号费种	张国良	2004-8-8
		
		[AutoComplete]
		public long m_lngAddNewRegChargeType(System.Security.Principal.IPrincipal p_objPrincipal,clsRegchargeType_VO objResult,out string p_strRecordID)
		{
			long lngRes=0;
			p_strRecordID = "";
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc","m_lngAddNewRegChargeType");
			if(lngRes < 0)//没有使用的权限
			{
				return -1;
			}
			
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			//返回一最大的计划号
			lngRes = objHRPSvc.lngGenerateID(3,"CHARGEID_CHR","t_bse_registerchargetype",out p_strRecordID);
			if(lngRes < 0)
				return lngRes;
			
			string strSQL = "INSERT INTO t_bse_registerchargetype (CHARGEID_CHR,CHARGENAME_CHR,MEMO_VCHR,CHARGENO_VCHR) VALUES ('"+p_strRecordID+"','"+objResult.m_strCHARGENAME_CHR+"','"+objResult.m_strMEMO_VCHR+"','"+objResult.m_strCHARGENO_VCHR+"')";
			try
			{
				lngRes = objHRPSvc.DoExcute(strSQL);	
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

		#region 修改挂号费种	张国良	2004-8-8
		/// <summary>
		/// 修改收费类别
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="objResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDoUpdRegChargeTypeByID(System.Security.Principal.IPrincipal p_objPrincipal,clsRegchargeType_VO objResult)
		{
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc","m_lngDoUpdRegChargeTypeByID");
			
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL="UPDate t_bse_registerchargetype Set  " +
				"CHARGENAME_CHR='"+objResult.m_strCHARGENAME_CHR+"' " +
				", MEMO_VCHR='"+objResult.m_strMEMO_VCHR+"' " +
				", CHARGENO_VCHR='"+objResult.m_strCHARGENO_VCHR+"' " +
				" Where CHARGEID_CHR='"+objResult.m_strCHARGEID_CHR+"' ";

			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.DoExcute(strSQL);
				objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion 

		#region 是否停用挂号费种 张国良	2004-9-22
		/// <summary>
		/// 是否停用挂号费种
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="objResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngIsUseingRgechargeType(System.Security.Principal.IPrincipal p_objPrincipal,string p_strID,string p_strIsUseing)
		{
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsRegTypeSvc","m_lngIsUseingRgechargeType");
			if( lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL="UPDATE t_bse_registerchargetype SET  " +
				"ISUSING_NUM = '" + p_strIsUseing + "' " +
				"WHERE CHARGEID_CHR = '" + p_strID + "' ";

			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.DoExcute(strSQL);	
				objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion

		#region 删除挂号费种	张国良	2004-8-8
		/// <summary>
		/// 删除收费项目分类类型
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="strID"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDeleteRegChargeTypeByID(System.Security.Principal.IPrincipal p_objPrincipal,string strID)
		{
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc","m_lngDeleteRegChargeTypeByID");
			
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL="Delete t_bse_registerchargetype " +
				" Where CHARGEID_CHR='"+strID+"' ";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.DoExcute(strSQL);
				objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion


		///挂号身份
		#region 挂号身份(返回所有的挂号身份)	张国良	2004-8-9
		/// <summary>
		/// 挂号身份(返回所有的挂号身份
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="objResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngFindPatientPayTypeList(System.Security.Principal.IPrincipal p_objPrincipal, out clstPatientPaytype_VO[] p_objResultArr)
		{
			p_objResultArr = new clstPatientPaytype_VO[0];
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngFindPatientPayTypeList");
			if(lngRes < 0)
			{
				return -1;
			}
			string strSQL = @"SELECT p.*,PLANNAME_CHR FROM t_bse_patientPaytype p  left join T_AID_INSPLAN i on p.COPAYID_CHR =i.PLANID_CHR  order by PAYTYPENO_VCHR";
			try
			{
				DataTable dtbResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
				objHRPSvc.Dispose();
				if(lngRes > 0 && dtbResult.Rows.Count > 0)
				{
					p_objResultArr = new clstPatientPaytype_VO[dtbResult.Rows.Count];
					for(int i1=0;i1<p_objResultArr.Length;i1++)
					{
						p_objResultArr[i1] = new clstPatientPaytype_VO();
						p_objResultArr[i1].m_strPAYTYPEID_CHR = dtbResult.Rows[i1]["PAYTYPEID_CHR"].ToString().Trim();
						p_objResultArr[i1].m_strPAYTYPENAME_VCHR = dtbResult.Rows[i1]["PAYTYPENAME_VCHR"].ToString().Trim();
						p_objResultArr[i1].m_strMEMO_VCHR = dtbResult.Rows[i1]["MEMO_VCHR"].ToString().Trim();
						p_objResultArr[i1].m_strPAYLIMIT_MNY = dtbResult.Rows[i1]["PAYLIMIT_MNY"].ToString().Trim();
						p_objResultArr[i1].m_strPAYFLAG_DEC = dtbResult.Rows[i1]["PAYFLAG_DEC"].ToString().Trim();
						p_objResultArr[i1].m_strPAYPERCENT_DEC = dtbResult.Rows[i1]["PAYPERCENT_DEC"].ToString().Trim();
						p_objResultArr[i1].m_strPAYTYPENO_VCHR = dtbResult.Rows[i1]["PAYTYPENO_VCHR"].ToString().Trim();
						p_objResultArr[i1].m_strISUSING_NUM = dtbResult.Rows[i1]["ISUSING_NUM"].ToString().Trim();
						p_objResultArr[i1].m_strCOPAYID_CHR= dtbResult.Rows[i1]["PLANNAME_CHR"].ToString().Trim();
						p_objResultArr[i1].m_strCHARGEPERCENT_DEC = dtbResult.Rows[i1]["CHARGEPERCENT_DEC"].ToString().Trim();
						p_objResultArr[i1].m_intINTERNALFLAG_INT = Convert.ToInt16(dtbResult.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim());
						p_objResultArr[i1].m_strCOALITIONRECIPEFLAG_INT = dtbResult.Rows[i1]["COALITIONRECIPEFLAG_INT"].ToString().Trim();
                        p_objResultArr[i1].m_strBIHLIMITRATE_DEC = dtbResult.Rows[i1]["BIHLIMITRATE_DEC"].ToString().Trim();
					}
				}
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

		#region  新增挂号身份	张国良	2004-8-9
		/// <summary>
		/// 新增挂号身份
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_strRecordName"></param>
		/// <param name="p_strMome"></param>
		/// <param name="p_dulPayLimit"></param>
		/// <param name="p_strRecordID"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngAddNewPatientPayType(System.Security.Principal.IPrincipal p_objPrincipal,clstPatientPaytype_VO objResult ,out string p_strRecordID)
		{
			long lngRes=0;
			p_strRecordID = "";
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc","m_lngAddNewPatientPayType");
			if(lngRes < 0)//没有使用的权限
			{
				return -1;
			}
			
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			//返回一最大的计划号
			lngRes = objHRPSvc.lngGenerateID(4,"PAYTYPEID_CHR","t_bse_patientPaytype",out p_strRecordID);
			if(lngRes < 0)
				return lngRes;

            string strSQL = @"INSERT INTO t_bse_patientPaytype (PAYTYPEID_CHR,PAYTYPENAME_VCHR,MEMO_VCHR,PAYLIMIT_MNY,PAYFLAG_DEC,PAYPERCENT_DEC,PAYTYPENO_VCHR,COPAYID_CHR,CHARGEPERCENT_DEC,INTERNALFLAG_INT,COALITIONRECIPEFLAG_INT,BIHLIMITRATE_DEC) VALUES ('" +
				p_strRecordID+"','"+objResult.m_strPAYTYPENAME_VCHR+"','"+objResult.m_strMEMO_VCHR+"','"+objResult.m_strPAYLIMIT_MNY+"','"+objResult.m_strPAYFLAG_DEC+"','"+objResult.m_strPAYPERCENT_DEC+"','"+
				objResult.m_strPAYTYPENO_VCHR+"','"+objResult.m_strCOPAYID_CHR+"','"+
                objResult.m_strCHARGEPERCENT_DEC + "'," + objResult.m_intINTERNALFLAG_INT + "," + objResult.m_strCOALITIONRECIPEFLAG_INT + "," + objResult.m_strBIHLIMITRATE_DEC + ")";
			string strSQL2 = "insert into t_aid_InsChargeItem (PRECENT_DEC,ITEMID_CHR,COPAYID_CHR) "+
				" select 100 as PRECENT_DEC, ItemID_chr,'"+p_strRecordID+"' as COPAYID_CHR from t_bse_ChargeItem ";
			try
			{
				lngRes = objHRPSvc.DoExcute(strSQL);
				lngRes = objHRPSvc.DoExcute(strSQL2);
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

		#region 修改挂号身份	张国良	2004-8-9
		/// <summary>
		/// 修改收费类别
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="objResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDoUpdPatientPayTypeByID(System.Security.Principal.IPrincipal p_objPrincipal,clstPatientPaytype_VO objResult)
		{
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc","m_lngDoUpdPatientPayTypeByID");
			
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL="UPDate t_bse_patientPaytype Set  " +
				"PAYTYPENAME_VCHR='"+objResult.m_strPAYTYPENAME_VCHR+"' " +
				", MEMO_VCHR='"+objResult.m_strMEMO_VCHR+"' " +
				", PAYLIMIT_MNY='"+objResult.m_strPAYLIMIT_MNY+"' " +
				", PAYFLAG_DEC='"+objResult.m_strPAYFLAG_DEC+"' " +
				", PAYPERCENT_DEC='"+objResult.m_strPAYPERCENT_DEC+"' " +
				", PAYTYPENO_VCHR='"+objResult.m_strPAYTYPENO_VCHR+"' " +
				", COPAYID_CHR='"+objResult.m_strCOPAYID_CHR+"' " +
				", CHARGEPERCENT_DEC='"+objResult.m_strCHARGEPERCENT_DEC+"' " +
				", COALITIONRECIPEFLAG_INT='"+objResult.m_strCOALITIONRECIPEFLAG_INT+"' " +
				",INTERNALFLAG_INT="+objResult.m_intINTERNALFLAG_INT+
                ",BIHLIMITRATE_DEC=" + objResult.m_strBIHLIMITRATE_DEC +
				"  Where PAYTYPEID_CHR='"+objResult.m_strPAYTYPEID_CHR+"' ";

			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.DoExcute(strSQL);
				objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion 

		#region 是否停用挂号身份 张国良	2004-9-22
		/// <summary>
		/// 是否停用挂号身份
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="objResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngIsUseingPAYTYPE(System.Security.Principal.IPrincipal p_objPrincipal,string p_strID,string p_strIsUseing)
		{
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsRegTypeSvc","m_lngIsUseingPAYTYPE");
			if( lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL="UPDATE t_bse_patientPaytype SET  " +
				"ISUSING_NUM = '" + p_strIsUseing + "' " +
				"WHERE PAYTYPEID_CHR = '" + p_strID + "' ";

			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.DoExcute(strSQL);	
				objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion

		#region 删除挂号身份	张国良	2004-8-9
		/// <summary>
		/// 删除收费项目分类类型
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="strID"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDeletePatientPayTypeByID(System.Security.Principal.IPrincipal p_objPrincipal,string strID)
		{
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc","m_lngDeletePatientPayTypeByID");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL="Delete t_bse_patientPaytype " +
				" Where PAYTYPEID_CHR='"+strID+"' ";
			string strSQL2="Delete t_aid_InsChargeItem " +
				" Where COPAYID_CHR='"+strID+"' ";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.DoExcute(strSQL);
				if (lngRes>0)
				{
					lngRes = objHRPSvc.DoExcute(strSQL2);
				}
				objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion


		///用药频率
		#region 用药频率列表	张国良	2004-8-11
		/// <summary>
		/// 挂号身份(返回所有的挂号身份
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="objResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngFindRecipeFrequencyTypeList(System.Security.Principal.IPrincipal p_objPrincipal,
			out clsRecipefreq_VO[] objResult)
		{
			long lngRes = 0;
			objResult=new clsRecipefreq_VO[0];
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc","m_lngFindRecipeFrequencyTypeList");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
            string strSQL = "Select FREQID_CHR ,FREQNAME_CHR ,USERCODE_CHR,TIMES_INT,DAYS_INT ,OPFREDESC_VCHR  From t_aid_recipefreq  ORDER BY FREQID_CHR";
			try
			{
				DataTable dtResult=new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtResult);
				objHRPSvc.Dispose();
				if(lngRes>0 && dtResult.Rows.Count>0)
				{
					objResult=new clsRecipefreq_VO[dtResult.Rows.Count];
					for(int i1=0;i1<objResult.Length;i1++)
					{
						objResult[i1]=new clsRecipefreq_VO();
						objResult[i1].m_strFREQID_CHR=dtResult.Rows[i1]["FREQID_CHR"].ToString().Trim();
						objResult[i1].m_strFREQNAME_CHR=dtResult.Rows[i1]["FREQNAME_CHR"].ToString().Trim();
						objResult[i1].m_strUSERCODE_CHR=dtResult.Rows[i1]["USERCODE_CHR"].ToString().Trim();
						objResult[i1].m_intTIMES_INT=Convert.ToInt32(dtResult.Rows[i1]["TIMES_INT"].ToString().Trim());
						objResult[i1].m_intDAYS_INT=Convert.ToInt32(dtResult.Rows[i1]["DAYS_INT"].ToString().Trim());
                        objResult[i1].m_strOPFreqDesc = dtResult.Rows[i1]["OPFREDESC_VCHR"].ToString();


					}
				}
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion

		#region  新增用药频率	张国良	2004-8-11
		/// <summary>
		///  新增用药频率
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="objResult"></param>
		/// <param name="p_strRecordID"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngAddNewRecipeFrequencyType(System.Security.Principal.IPrincipal p_objPrincipal,clsRecipefreq_VO objResult,out string p_strRecordID)
		{
			long lngRes=0;
			p_strRecordID = "";
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc","m_lngAddNewRecipeFrequencyType");
			
			if(lngRes < 0)//没有使用的权限
			{
				return -1;
			}
			
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			//返回一最大的计划号
            lngRes = objHRPSvc.lngGenerateID(4, "to_number(FREQID_CHR)", "t_aid_recipefreq", out p_strRecordID);
			if(lngRes < 0)
				return lngRes;

            string strSQL = "INSERT INTO t_aid_recipefreq (FREQID_CHR,FREQNAME_CHR ,USERCODE_CHR,TIMES_INT,DAYS_INT,OPFREDESC_VCHR) VALUES ('" + p_strRecordID + "','" + objResult.m_strFREQNAME_CHR + "','" + objResult.m_strUSERCODE_CHR + "','" + objResult.m_intTIMES_INT + "','" + objResult.m_intDAYS_INT + "','"+objResult.m_strOPFreqDesc+"')";
			try
			{
				lngRes = objHRPSvc.DoExcute(strSQL);	
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

		#region 修改用药频率	张国良	2004-8-11
		/// <summary>
		/// 修改收费类别
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="objResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDoUpdRecipeFrequencyByID(System.Security.Principal.IPrincipal p_objPrincipal,clsRecipefreq_VO objResult)
		{
			long lngRes = 0;
            long lngAffected=0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc","m_lngDoUpdRecipeFrequencyByID");
			
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
            string strSQL = @"UPDate t_aid_recipefreq Set FREQNAME_CHR=?, USERCODE_CHR=?, TIMES_INT=?, DAYS_INT=?,OPFREDESC_VCHR=? Where trim(FREQID_CHR)=? ";

			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(6, out objLisAddItemRefArr);
                objLisAddItemRefArr[0].Value = objResult.m_strFREQNAME_CHR;
                objLisAddItemRefArr[1].Value = objResult.m_strUSERCODE_CHR;
                objLisAddItemRefArr[2].Value = objResult.m_intTIMES_INT;
                objLisAddItemRefArr[3].Value = objResult.m_intDAYS_INT;
                objLisAddItemRefArr[4].Value = objResult.m_strOPFreqDesc;
                objLisAddItemRefArr[5].Value = objResult.m_strFREQID_CHR;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffected, objLisAddItemRefArr);
				objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion 
		
		#region 删除用药频率	张国良	2004-8-11
		/// <summary>
		/// 删除收费项目分类类型
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="strID"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDeleteRecipeFrequencyByID(System.Security.Principal.IPrincipal p_objPrincipal,string strID)
		{
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc","m_lngDeleteRecipeFrequencyByID");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL="Delete t_aid_recipefreq " +
				" Where FREQID_CHR='"+strID+"' ";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.DoExcute(strSQL);
				objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion


	}
}
