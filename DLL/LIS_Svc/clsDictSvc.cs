using System;
using System.Data;
using System.EnterpriseServices;
using com.digitalwave.Utility; //Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
namespace com.digitalwave.iCare.middletier.LIS
{
	/// <summary>
	/// clsDictSvc 的摘要说明。
	/// 
	/// </summary>
	[Transaction(TransactionOption.Supported)]
	[ObjectPooling(Enabled=true)]
	public class clsDictSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase//MiddleTierBase.dll
	{
		#region 构造函数
		public clsDictSvc()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#endregion

		#region 根据字典种类得到内容列表(除去第一条的类型说明) 
		/// <summary>
		/// 根据字典种类得到内容列表(除去第一条的类型说明) 
		/// 
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_strDictKind"></param>
		/// <param name="p_dtbDictList">
		/// table name : t_aid_dict
		/// column:
		/// dictid_chr
		/// dictkind_chr
		/// dictname_vchr
		/// pycode_chr
		/// wbcode_chr
		/// jxcode_chr
		/// </param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngGetDictListFor(System.Security.Principal.IPrincipal p_objPrincipal,string p_strDictKind, out DataTable p_dtbDictList)
		{
			long lngRes = 0;
			p_dtbDictList = null;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsDictSvc","m_lngGetDictListFor");
			if(lngRes < 0)
			{
				return -1;
			}

			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

			string strSQL = @"SELECT jxcode_chr,wbcode_chr, pycode_chr, dictname_vchr, dictid_chr,dictkind_chr 
							 FROM t_aid_dict 
							 WHERE 
							 trim(dictid_chr) <> '0' 
							 AND dictkind_chr = '" + p_strDictKind + "'";

			try
			{
		//		IDataParameter[] objParamArr = clsIDataParameterCreator.m_objConstructIDataParameterArr(p_strDictKind);
		//		lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL,ref p_dtbDictList,objParamArr);		
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref p_dtbDictList);
			objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。
				lngRes = 0;
			}
			return lngRes;
		}
		#endregion

		#region 根据字典种类得到内容列表（除去第一条类型说明） 
		[AutoComplete]
		public long m_lngGetDictListFor(System.Security.Principal.IPrincipal p_objPrincipal,string p_strDictKind,out clsAIDDICT_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = null;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsDictSvc","m_lngGetDictListFor");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @"SELECT * 
								FROM t_aid_dict 
							   WHERE trim(dictid_chr) <> '0' 
								 AND dictkind_chr = '" + p_strDictKind + "'";
			try
			{
				DataTable dtbResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
				objHRPSvc.Dispose();
				if(lngRes > 0 && dtbResult.Rows.Count > 0)
				{
					p_objResultArr = new clsAIDDICT_VO[dtbResult.Rows.Count];
					for(int i1=0;i1<p_objResultArr.Length;i1++)
					{
						p_objResultArr[i1] = new clsAIDDICT_VO();
						p_objResultArr[i1].m_strJXCODE_CHR = dtbResult.Rows[i1]["JXCODE_CHR"].ToString().Trim();
						p_objResultArr[i1].m_strWBCODE_CHR = dtbResult.Rows[i1]["WBCODE_CHR"].ToString().Trim();
						p_objResultArr[i1].m_strPYCODE_CHR = dtbResult.Rows[i1]["PYCODE_CHR"].ToString().Trim();
						p_objResultArr[i1].m_strDICTNAME_VCHR = dtbResult.Rows[i1]["DICTNAME_VCHR"].ToString().Trim();
						p_objResultArr[i1].m_strDICTID_CHR = dtbResult.Rows[i1]["DICTID_CHR"].ToString().Trim();
						p_objResultArr[i1].m_strDICTKIND_CHR = dtbResult.Rows[i1]["DICTKIND_CHR"].ToString().Trim();
						p_objResultArr[i1].m_strDICTSEQID_CHR = dtbResult.Rows[i1]["DICTSEQID_CHR"].ToString().Trim();
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
	}
}
