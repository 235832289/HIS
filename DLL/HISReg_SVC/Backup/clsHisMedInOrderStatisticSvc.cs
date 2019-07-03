using System;
using System.Data;
using System.EnterpriseServices;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
namespace com.digitalwave.iCare.middletier.HIS
{
	#region 药库入库单统计业务处理中间件 ：created by weiling.huang  at 2005-9-14
	/// <summary>
	/// 药库入库单统计业务处理中间件
	/// </summary>
	[Transaction(TransactionOption.Required)]
	[ObjectPooling(Enabled=true)]
	public class clsHisMedInOrderStatisticSvc: com.digitalwave.iCare.middletier.clsMiddleTierBase
	{
		#region 构造函数
		/// <summary>
		/// 构造函数
		/// </summary>
		public clsHisMedInOrderStatisticSvc()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#endregion

		#region 中间件方法： 药库入库单统计业务处理

		#region 获得系统时间
		/// <summary>
		/// 获取数据库服务器时间
		/// </summary>
		/// <returns>DateTime</returns>
		[AutoComplete]
		public  DateTime m_dtmGetServerDate()
		{
			long lngRes = 0;
			System.DateTime datResult = System.DateTime.Now;
			
			string strSQL = @"SELECT sysdate
							  FROM dual";
			System.Data.DataTable dtbResult = new System.Data.DataTable();
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL,ref dtbResult);
				

				if(lngRes >0 && dtbResult !=null)
				{
					datResult = System.DateTime.Parse(dtbResult.Rows[0]["sysdate"].ToString());
					
				}
				objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
				bool blnRes = objLogger.LogError(objEx); 
			}
			return datResult;
		}
		#endregion

		#region 按时间统计 
		/// <summary>
		/// 按时间统计
		/// </summary>
		/// <param name="p_objPrincipal">安全标识</param>
		/// <param name="p_strPeriodId">查询账务期ID</param>
		/// <param name="p_dtbResult">查询得到的结果</param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngGetStatiticsData(System.Security.Principal.IPrincipal p_objPrincipal,out DataTable p_dtbResult, string p_strPeriodId)
		{
			p_dtbResult=new DataTable();
			long lngRes=0;
			//权限控制
			com.digitalwave.security.clsPrivilegeHandleService objHandle=new clsPrivilegeHandleService();
			lngRes=objHandle.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsHisMedInOrderStatisticSvc","m_lngGetStatiticsData");  
			if (lngRes<0)
				return -1;
	
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			string strSQL;

			if(p_strPeriodId != "")
			{
				strSQL=@"SELECT Ta.docid_vchr, Ta.tolmny_mny, Tb.vendorname_vchr
									FROM t_opr_storageord Ta, t_bse_vendor Tb, t_bse_period Tc
									WHERE Ta.vendorid_chr = Tb.vendorid_chr(+)
											 AND Ta.periodid_chr = Tc.periodid_chr
											AND Tc.PERIODID_CHR = ";
				strSQL	+=							 "'"+p_strPeriodId+"'";
				strSQL	+=						" AND Ta.pstatus_int = 2 AND Ta.sign_int = 1";
			}
			else//选择所有时期
			{
				strSQL=@"SELECT Ta.docid_vchr, Ta.tolmny_mny, Tb.vendorname_vchr
									FROM t_opr_storageord Ta, t_bse_vendor Tb, t_bse_period Tc
									WHERE Ta.vendorid_chr = Tb.vendorid_chr(+)
											 AND Ta.periodid_chr = Tc.periodid_chr ";										
				
				strSQL	+=						" AND Ta.pstatus_int = 2 AND Ta.sign_int = 1";
			}
			try
			{
					
				lngRes = objHRPSvc.DoGetDataTable(strSQL,ref p_dtbResult);				
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			objHRPSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 获取账务期
		/// <summary>
		/// 获取账务期
		/// </summary>
		/// <param name="p_objResultArr">查询得到的结果</param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngGetPeriodList(System.Security.Principal.IPrincipal p_objPrincipal,out clsPeriod_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsPeriod_VO[0];

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsHisMedInOrderStatisticSvc","m_lngGetPeriodList");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @"Select PERIODID_CHR,STARTDATE_DAT,ENDDATE_DAT From t_bse_period order by PERIODID_CHR";
			
			try
			{
				DataTable dtbResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.DoGetDataTable(strSQL,ref dtbResult);
				if(lngRes > 0 && dtbResult.Rows.Count > 0)
				{
					p_objResultArr = new com.digitalwave.iCare.ValueObject.clsPeriod_VO[dtbResult.Rows.Count];
					for(int i1=0;i1<p_objResultArr.Length;i1++)
					{
						p_objResultArr[i1] = new com.digitalwave.iCare.ValueObject.clsPeriod_VO();
						p_objResultArr[i1].m_strPeriodID = dtbResult.Rows[i1]["PERIODID_CHR"].ToString().Trim();
						p_objResultArr[i1].m_strStartDate = dtbResult.Rows[i1]["STARTDATE_DAT"].ToString().Trim();
						p_objResultArr[i1].m_strEndDate = dtbResult.Rows[i1]["ENDDATE_DAT"].ToString().Trim();
						
					}
				}
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

		#endregion

	}
	#endregion

}
