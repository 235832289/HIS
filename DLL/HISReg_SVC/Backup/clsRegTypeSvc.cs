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
	/// clsRegTypeSvc 的摘要说明。
	/// </summary>
	[Transaction(TransactionOption.Required)]
	[ObjectPooling(true)]
	public class clsRegTypeSvc:com.digitalwave.iCare.middletier.clsMiddleTierBase
	{
		public clsRegTypeSvc()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		// 挂号种类 
		#region 挂号种类(返回所有的种类) created by Cameron Wong on Aug 9, 2004
		/// <summary>
		/// 挂号种类(返回所有的种类)
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="objResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngFindRegTypeList(System.Security.Principal.IPrincipal p_objPrincipal, out clsRegType_VO[] p_objResultArr)
		{
			p_objResultArr = new clsRegType_VO[0];
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngFindRegTypeList");
			if(lngRes < 0)
			{
				return -1;
			}
			string strSQL = @"SELECT * FROM T_BSE_REGISTERTYPE order by REGISTERTYPEID_CHR";
			try
			{
				DataTable dtbResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
				objHRPSvc.Dispose();
				if(lngRes > 0 && dtbResult.Rows.Count > 0)
				{
					p_objResultArr = new clsRegType_VO[dtbResult.Rows.Count];
					for(int i1=0;i1<p_objResultArr.Length;i1++)
					{
						p_objResultArr[i1] = new clsRegType_VO();
						p_objResultArr[i1].m_strRegTypeID = dtbResult.Rows[i1]["REGISTERTYPEID_CHR"].ToString().Trim();
						p_objResultArr[i1].m_strRegTypeName = dtbResult.Rows[i1]["REGISTERTYPENAME_VCHR"].ToString().Trim();
						p_objResultArr[i1].m_strRegTypeMemo = dtbResult.Rows[i1]["MEMO_VCHR"].ToString().Trim();
						p_objResultArr[i1].m_strRegTypeNo = dtbResult.Rows[i1]["REGISTERTYPENO_VCHR"].ToString().Trim();
						p_objResultArr[i1].m_strIsUsing = dtbResult.Rows[i1]["ISUSING_NUM"].ToString().Trim();
						p_objResultArr[i1].m_strIsDoctor = dtbResult.Rows[i1]["ISDOCTOR_NUM"].ToString().Trim();
						p_objResultArr[i1].m_strIsUrgency = dtbResult.Rows[i1]["URGENCY_INT"].ToString().Trim();//xigui.peng 添加

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

		#region 新增挂号种类 created by Cameron Wong on Aug 9, 2004
		[AutoComplete]
		public long m_lngDoAddNewRegType(System.Security.Principal.IPrincipal p_objPrincipal,clsRegType_VO objResult, out string p_strID)
		{
			long lngRes = 0;
			p_strID = "";
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsRegTypeSvc","m_lngDoAddNewRegType");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			//返回一最大的计划号
			lngRes = objHRPSvc.lngGenerateID(4, "REGISTERTYPEID_CHR", "T_BSE_REGISTERTYPE", out p_strID);
			if (lngRes < 0)
				return -1;
//			string strSQL = "INSERT INTO T_BSE_REGISTERTYPE (REGISTERTYPEID_CHR, REGISTERTYPENAME_VCHR, MEMO_VCHR ,REGISTERTYPENO_VCHR,ISDOCTOR_NUM) VALUES " +
//				" ('" + p_strID + "' , '" + objResult.m_strRegTypeName + "', '" + objResult.m_strRegTypeMemo + "', '" + objResult.m_strRegTypeNo+ "', '" + objResult.m_strIsDoctor + "')";
			//xigui.peng 修改
			string strSQL = "INSERT INTO T_BSE_REGISTERTYPE (REGISTERTYPEID_CHR, REGISTERTYPENAME_VCHR, MEMO_VCHR ,REGISTERTYPENO_VCHR,ISDOCTOR_NUM,URGENCY_INT) VALUES " +
				" ('" + p_strID + "' , '" + objResult.m_strRegTypeName + "', '" + objResult.m_strRegTypeMemo + "', '" + objResult.m_strRegTypeNo+ "', '" + objResult.m_strIsDoctor + "','"+objResult.m_strIsUrgency+"')";
                
			try
			{
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

		#region 修改挂号种类 created by Cameron Wong on Aug 9, 2004
		/// <summary>
		/// 修改收费类别
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="objResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDoUpdRegTypeByID(System.Security.Principal.IPrincipal p_objPrincipal,clsRegType_VO objResult)
		{
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsRegTypeSvc","m_lngDoUpdRegTypeByID");
			if( lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL="UPDATE T_BSE_REGISTERTYPE SET  " +
				"REGISTERTYPENAME_VCHR = '" + objResult.m_strRegTypeName + "', " +
				"MEMO_VCHR = '" + objResult.m_strRegTypeMemo + "', " +
				"REGISTERTYPENO_VCHR = '" + objResult.m_strRegTypeNo + "', " +
				"ISDOCTOR_NUM = '" + objResult.m_strIsDoctor + "' ," +
				"URGENCY_INT = '" + objResult.m_strIsUrgency + "' " +           //xigui.peng 添加
				"WHERE REGISTERTYPEID_CHR = '" + objResult.m_strRegTypeID + "' ";

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

		#region 是否停用挂号种类 created by Cameron Wong on Aug 9, 2004
		/// <summary>
		/// 修改收费类别
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="objResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngIsUseing(System.Security.Principal.IPrincipal p_objPrincipal,string p_strID,string p_strIsUseing)
		{
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsRegTypeSvc","m_lngIsUseing");
			if( lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL="UPDATE T_BSE_REGISTERTYPE SET  " +
				"ISUSING_NUM = '" + p_strIsUseing + "' " +
				"WHERE REGISTERTYPEID_CHR = '" + p_strID + "' ";

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

		#region 删除挂号种类 created by Cameron Wong on Aug 9, 2004
		/// <summary>
		/// 删除收费项目分类类型
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="strID"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDelRegTypeByID(System.Security.Principal.IPrincipal p_objPrincipal,string strID)
		{
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsRegTypeSvc","m_lngDelRegTypeByID");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL = "DELETE T_BSE_REGISTERTYPE " +
				"WHERE REGISTERTYPEID_CHR = '" + strID + " '";
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

		// 煎制方法
		#region 返回所有煎制方法列表 created by Cameron Wong on Aug 9, 2004
		/// <summary>
		/// 返回所有煎制方法列表
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="objResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngFindCookMethodList(System.Security.Principal.IPrincipal p_objPrincipal,
			out clsCookMethod_VO[] objResult)
		{
			long lngRes = 0;
			objResult = new clsCookMethod_VO[0];
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsRegTypeSvc", "m_lngFindCookMethodList");
			if (lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL = "SELECT COOKINGMETHODID_CHR sID, COOKINGMETHODNAME_VCHR sName, MNEMONIC_CHR sMNemonic " + 
							"FROM T_AID_CMCOOKINGMETHOD " +
							"ORDER BY sID";
			try
			{
				DataTable dtResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtResult);
				objHRPSvc.Dispose();
				if (lngRes > 0 && dtResult.Rows.Count > 0)
				{
					objResult = new clsCookMethod_VO[dtResult.Rows.Count];
					for (int i1 = 0; i1 < objResult.Length; i1++)
					{
						objResult[i1] = new clsCookMethod_VO();
						objResult[i1].m_strCookMethodID = dtResult.Rows[i1][0].ToString().Trim();
						objResult[i1].m_strCookMethodName = dtResult.Rows[i1][1].ToString().Trim();
						objResult[i1].m_strMNemonic = dtResult.Rows[i1][2].ToString().Trim();
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

		#region 新增煎制方法 created by Cameron Wong on Aug 11, 2004
		/// <summary>
		/// 新增煎制方法
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_strName"></param>
		/// <param name="p_strMNemonic"></param>
		/// <param name="p_strID"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDoAddNewCookMethod(System.Security.Principal.IPrincipal p_objPrincipal,string p_strName,string p_strMNemonic, out string p_strID)
		{
			long lngRes = 0;
			p_strID = "";
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsRegTypeSvc","m_lngDoAddNewCookMethod");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			//返回一最大的计划号
			lngRes = objHRPSvc.lngGenerateID(4, "COOKINGMETHODID_CHR", "T_AID_CMCOOKINGMETHOD", out p_strID);
			if (lngRes < 0)
				return -1;
			string strSQL = "INSERT INTO T_AID_CMCOOKINGMETHOD (COOKINGMETHODID_CHR, COOKINGMETHODNAME_VCHR, MNEMONIC_CHR) VALUES " +
				" ('" + p_strID + "' , '" + p_strName + "', '" + p_strMNemonic + "')";
         
			try
			{
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

		#region 修改煎制方法 created by Cameron Wong on Aug 11, 2004
		/// <summary>
		/// 修改煎制方法
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="objResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDoUpdMethodByID(System.Security.Principal.IPrincipal p_objPrincipal,clsCookMethod_VO objResult)
		{
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsRegTypeSvc","m_lngDoUpdMethodByID");
			if( lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL="UPDATE T_AID_CMCOOKINGMETHOD SET  " +
				"COOKINGMETHODNAME_VCHR = '" + objResult.m_strCookMethodName + "', " +
				"MNEMONIC_CHR = '" + objResult.m_strMNemonic + "' " +
				"WHERE COOKINGMETHODID_CHR = '" + objResult.m_strCookMethodID + "' ";

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

		#region 删除煎制方法 created by Cameron Wong on Aug 11, 2004
		/// <summary>
		/// 删除煎制方法
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="strID"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDelMethodByID(System.Security.Principal.IPrincipal p_objPrincipal,string strID)
		{
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsRegTypeSvc","m_lngDelMethodByID");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL = "DELETE T_AID_CMCOOKINGMETHOD " +
				"WHERE COOKINGMETHODID_CHR = '" + strID + " '";
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
