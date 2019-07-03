using System;
using System.Data;
using System.EnterpriseServices;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll

namespace com.digitalwave.iCare.middletier.HIS
{
	#region 门诊收费核算分类组成报表业务操作
	/// <summary>	
	/// 门诊收费核算分类组成报表业务操作
	/// Create 黄伟灵 by 2005-09-13
	/// </summary>
	[Transaction(TransactionOption.Required)]
	[ObjectPooling(Enabled=true)]
	public class clsOutPatientSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
	{
		#region 构造函数
		/// <summary>
		/// 构造函数
		/// </summary>
		public clsOutPatientSvc()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#endregion

		#region 中间件方法：门诊收费核算分类组成报表业务操作

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

		#region 按时间统计收费 
		/// <summary>
		/// 按时间统计收费
		/// </summary>
		/// <param name="p_objPrincipal">安全标识</param>
		/// <param name="p_dtm1">开始时间</param>
		/// <param name="p_dtm2">结束时间</param>
		/// <param name="p_dtb">查询得到的结果</param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngGetStatiticsData(System.Security.Principal.IPrincipal p_objPrincipal,string p_dtm1,string p_dtm2,out DataTable p_dtb)
		{
			p_dtb=new DataTable();
			long lngRes=0;
			//权限控制
			com.digitalwave.security.clsPrivilegeHandleService objHandle=new clsPrivilegeHandleService();
			lngRes=objHandle.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOutPatientSvc","m_lngGetStatiticsData");  
			if (lngRes<0)
				return -1;
	
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			string strSQL=@"SELECT t1.*, t2.typename_vchr
									FROM (SELECT   b.itemcatid_chr, SUM (b.tolfee_mny) AS totalmoney
											 FROM t_opr_outpatientrecipesumde b, t_opr_outpatientrecipeinv a
											 WHERE b.seqid_chr = a.seqid_chr
													 AND a.recorddate_dat BETWEEN to_date('"+p_dtm1+" 00:00:00"+"','yyyy-mm-dd hh24:mi:ss')";
					strSQL	+=						 "	AND to_date('"+p_dtm2+" 00:00:00"+"','yyyy-mm-dd hh24:mi:ss')";
					strSQL	+=						" AND a.balanceflag_int = 1";
					strSQL	+=						" GROUP BY b.itemcatid_chr) t1,";
					strSQL	+=						" t_bse_chargeitemextype t2";
					strSQL	+=						" WHERE t1.itemcatid_chr = t2.typeid_chr";
			try
			{
					
				lngRes = objHRPSvc.DoGetDataTable(strSQL,ref p_dtb);				
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

		#endregion

	}
		#endregion
	
}
