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
	/// clsHISInfoDefineSvc 的摘要说明。
	/// </summary>
	[Transaction(TransactionOption.Required)]
	[ObjectPooling(true)]
	public class clsHISInfoDefineSvc:com.digitalwave.iCare.middletier.clsMiddleTierBase
	{
		public clsHISInfoDefineSvc()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		///医院基本信息
		#region 返回医院基本信息	张国良	2004-8-12
		/// <summary>
		/// 挂号身份(返回所有的挂号身份
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="objResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngFindHospitalInfo(System.Security.Principal.IPrincipal p_objPrincipal,
			out clsHISInfoDefine_VO[] objResult)
		{
			long lngRes = 0;
			objResult=new clsHISInfoDefine_VO[0];
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsHISInfoDefineSvc","m_lngFindHospitalInfo");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL="Select HOSPITAL_NAME_CHR sName,ADDRESS_VCHR sAddress,PHONE_NUMBER_CHR sPhone,PHONE_NUMBER2_CHR sPhone2,ZIP_CHR sZIP,MEMO_VCHR sMemo  From t_bse_hospitalinfo ";
			try
			{
				DataTable dtResult=new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtResult);
				if(lngRes>0 && dtResult.Rows.Count>0)
				{
					objResult=new clsHISInfoDefine_VO[dtResult.Rows.Count];
					for(int i1=0;i1<objResult.Length;i1++)
					{
						objResult[i1]=new clsHISInfoDefine_VO();
						objResult[i1].m_strHOSPITAL_NAME_CHR=dtResult.Rows[i1][0].ToString().Trim();
						objResult[i1].m_strADDRESS_VCHR=dtResult.Rows[i1][1].ToString().Trim();
						objResult[i1].m_strPHONE_NUMBER_CHR=dtResult.Rows[i1][2].ToString().Trim();
						objResult[i1].m_strPHONE_NUMBER2_CHR=dtResult.Rows[i1][3].ToString().Trim();
						objResult[i1].m_strZIP_CHR=dtResult.Rows[i1][4].ToString().Trim();
						objResult[i1].m_strMEMO_VCHR=dtResult.Rows[i1][5].ToString().Trim();
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
		#region 修改医院基本信息	张国良	2004-8-12
		/// <summary>
		/// 修改收费类别
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="objResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDoUpdHospitalInfo(System.Security.Principal.IPrincipal p_objPrincipal,clsHISInfoDefine_VO objResult)
		{
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsHISInfoDefineSvc","m_lngDoUpdHospitalInfo");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL="UPDate t_bse_hospitalinfo Set  " +
				"HOSPITAL_NAME_CHR='"+objResult.m_strHOSPITAL_NAME_CHR+"' " +
				", ADDRESS_VCHR='"+objResult.m_strADDRESS_VCHR+"' " +
				", PHONE_NUMBER_CHR='"+objResult.m_strPHONE_NUMBER_CHR+"' " +
				", PHONE_NUMBER2_CHR='"+objResult.m_strPHONE_NUMBER2_CHR+"' " +
				", ZIP_CHR='"+objResult.m_strZIP_CHR+"' " +
				", MEMO_VCHR='"+objResult.m_strMEMO_VCHR+"' ";

			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.DoExcute(strSQL);				
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion 
		
		// 应用管理系统
		#region 返回所有分应用系统 created by Cameron Wong on Aug 12, 2004
		/// <summary>
		/// 返回所有分应用系统
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="objResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngFindModuleList(System.Security.Principal.IPrincipal p_objPrincipal,
			out clsHISModuleDef_VO[] objResult)
		{
			long lngRes = 0;
			objResult = new clsHISModuleDef_VO[0];
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsHISInfoDefineSvc", "m_lngFindModuleList");
			if (lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL = "SELECT MODULEID_CHR, MODULENAME_CHR, ENGNAME_CHR, PYCODE_CHR, WBCODE_CHR " + 
				"FROM T_SYS_MODULE " +
				"ORDER BY MODULEID_CHR";
			try
			{
				DataTable dtResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtResult);
				if (lngRes > 0 && dtResult.Rows.Count > 0)
				{
					objResult = new clsHISModuleDef_VO[dtResult.Rows.Count];
					for (int i1 = 0; i1 < objResult.Length; i1++)
					{
						objResult[i1] = new clsHISModuleDef_VO();
						objResult[i1].m_strModuleID = dtResult.Rows[i1][0].ToString().Trim();
						objResult[i1].m_strModuleName = dtResult.Rows[i1][1].ToString().Trim();
						objResult[i1].m_strEngName = dtResult.Rows[i1][2].ToString().Trim();
						objResult[i1].m_strPYCode = dtResult.Rows[i1][3].ToString().Trim();
						objResult[i1].m_strWBCode = dtResult.Rows[i1][4].ToString().Trim();
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

		#region 新增分系统 created by Cameron Wong on Aug 12, 2004
		/// <summary>
		/// 新增分系统
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_strModuleName"></param>
		/// <param name="p_strEngName"></param>
		/// <param name="p_strPYCode"></param>
		/// <param name="p_strWBCode"></param>
		/// <param name="p_strID"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDoAddNewModule(System.Security.Principal.IPrincipal p_objPrincipal,string p_strModuleName,string p_strEngName, string p_strPYCode, string p_strWBCode, out string p_strID)
		{
			long lngRes = 0;
			p_strID = "";
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsUsageSvc","m_lngDoAddNewModule");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			//返回一最大的计划号
			lngRes = objHRPSvc.lngGenerateID(4, "MODULEID_CHR", "T_SYS_MODULE", out p_strID);
			if (lngRes < 0)
				return -1;
			string strSQL = "INSERT INTO T_SYS_MODULE (MODULEID_CHR, MODULENAME_CHR, ENGNAME_CHR, PYCODE_CHR, WBCODE_CHR) VALUES " +
				" ('" + p_strID + "' , '" + p_strModuleName + "', '" + p_strEngName + "', '" + p_strPYCode + "', '" + p_strWBCode + "')";
         
			try
			{
				lngRes = objHRPSvc.DoExcute(strSQL);				
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion

		#region 修改分系统信息 created by Cameron Wong on Aug 12, 2004
		/// <summary>
		/// 修改分系统信息
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="objResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDoUpdModuleByID(System.Security.Principal.IPrincipal p_objPrincipal,clsHISModuleDef_VO objResult)
		{
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsHISInfoDefineSvc","m_lngDoUpdModuleByID");
			if( lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL="UPDATE T_SYS_MODULE SET  " +
				"MODULENAME_CHR = '" + objResult.m_strModuleName + "', " +
				"ENGNAME_CHR = '" + objResult.m_strEngName + "', " +
				"PYCODE_CHR = '" + objResult.m_strPYCode + "', " +
				"WBCODE_CHR = '" + objResult.m_strWBCode + "' " +
				"WHERE MODULEID_CHR = '" + objResult.m_strModuleID + "' ";

			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.DoExcute(strSQL);				
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion

		#region 删除分系统 created by Cameron Wong on Aug 11, 2004
		/// <summary>
		/// 删除分系统
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="strID"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDelModuleByID(System.Security.Principal.IPrincipal p_objPrincipal,string strID)
		{
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsHISInfoDefineSvc","m_lngDelModuleByID");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL = "DELETE T_SYS_MODULE " +
				"WHERE MODULEID_CHR = '" + strID + " '";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.DoExcute(strSQL);				
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion

		// 系统错误信息记录
		#region 返回所有错误信息记录 created by Cameron Wong on Aug 12, 2004
		/// <summary>
		/// 返回所有错误信息记录
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="dtbResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngFindErrorLogList(System.Security.Principal.IPrincipal p_objPrincipal,
			out DataTable dtbResult)
		{
			long lngRes = 0;
			dtbResult = new DataTable();
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.baseInfo.clsHISInfoDefineSvc", "m_lngFindErrorLogList");
			if (lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL ="SELECT LOGID_CHR, ERRMODULE_VCHR, ERREVENT_VCHR, ERRLINENO_INT, ERRMESSAGE_VCHR, ERRCLASS_VCHR, FIRSTNAME_VCHR, LASTNAME_VCHR, DEPTNAME_VCHR, ERRTIME_DTM, ERRCOMPUTER_CHR, ERRIP_CHR, T_SYS_MODULE.NAME_VCHR " +
				"FROM ((T_SYS_ERRORLOG " +
				"LEFT JOIN T_BSE_DEPTDESC ON DEPTID_CHR = ERRDEPTID_CHR) " +
				"LEFT JOIN T_BSE_EMPLOYEE ON EMPID_CHR = ERRUSERID_CHR) " +
				"LEFT JOIN T_SYS_MODULE ON T_SYS_MODULE.MODULEID_CHR = T_SYS_ERRORLOG.MODULEID_CHR " +
				"ORDER BY LOGID_CHR";
			try
			{
				//				DataTable dtbResult2 = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
				/*				if (lngRes > 0 && dtbResult2.Rows.Count > 0)
								{
									DataRow dtrResult;
									for (int i = 1; i < dtbResult2.Rows.Count; i++)
									{
										dtrResult = dtbResult2.NewRow();
										dtrResult.Table = dtbResult;
										dtrResult[0] = dtbResult2.Rows[i][0];	// log ID
										dtrResult[1] = dtbResult.Rows[i][1];	// error module
										dtrResult[2] = dtbResult.Rows[i][2];	// error event
										dtrResult[3] = dtbResult.Rows[i][3];	// error line no
										dtrResult[4] = dtbResult.Rows[i][4];	// error message
										dtrResult[5] = dtbResult.Rows[i][5];	// error class
										dtrResult[6] = dtbResult.Rows[i][6].ToString() + dtbResult.Rows[i][7].ToString();	// error user name
										dtrResult[7] = dtbResult.Rows[i][8];	// error department name
										dtrResult[8] = dtbResult.Rows[i][9];	// error time
										dtrResult[9] = dtbResult.Rows[i][10];	// error computer name
										dtrResult[10] = dtbResult.Rows[i][11];	// error IP
										dtrResult[11] = dtbResult.Rows[i][12];	// module ID
										dtbResult.Rows.Add(dtrResult);
									}
								}
				*/			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion

		#region 删除所有系统信息记录 created by Cameron Wong on Aug 12, 2004
		/// <summary>
		/// 删除所有系统信息记录
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDelAllErrorLog(System.Security.Principal.IPrincipal p_objPrincipal)
		{
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.baseInfo.clsHISInfoDefineSvc","m_lngDelAllErrorLog");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL = "DELETE T_SYS_ERRORLOG";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.DoExcute(strSQL);				
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion

		// 用户登陆信息
		#region 返回所有用户登陆信息 created by Cameron Wong on Aug 16, 2004
		/// <summary>
		/// 返回所有用户登陆信息
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="dtbResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngFindLoginInfoList(System.Security.Principal.IPrincipal p_objPrincipal,out DataTable dtbResult)
		{
			long lngRes = 0;
			dtbResult = new DataTable();
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.baseInfo.clsHISInfoDefineSvc", "m_lngFindLoginInfoList");
			if (lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL = "SELECT IDX_INT, MACNAME_VCHR, MAC_VCHR, LOGTIME_DAT, EXITTIME_DAT, T_SYS_ROLE.NAME_VCHR, FIRSTNAME_VCHR, LASTNAME_VCHR 	FROM T_SYS_LOG LEFT JOIN T_SYS_ROLE ON T_SYS_LOG.ROLID_CHR = T_SYS_ROLE.ROLEID_CHR	LEFT JOIN T_BSE_EMPLOYEE ON T_SYS_LOG.EMPID_CHR = T_BSE_EMPLOYEE.EMPID_CHR	ORDER BY IDX_INT";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion

		#region 删除所有用户登陆信息 created by Cameron Wong on Aug 16, 2004
		/// <summary>
		/// 删除所有系统信息记录
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDelAllLoginInfo(System.Security.Principal.IPrincipal p_objPrincipal)
		{
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.baseInfo.clsHISInfoDefineSvc","m_lngDelAllErrorLog");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL = "DELETE T_SYS_LOG";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.DoExcute(strSQL);				
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
