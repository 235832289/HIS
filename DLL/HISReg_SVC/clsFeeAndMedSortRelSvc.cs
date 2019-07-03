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
	/// clsFeeAndMedSortRelSvc 的摘要说明。
	/// </summary>
	[Transaction(TransactionOption.Required)]
	[ObjectPooling(Enabled=true)]
	public class clsFeeAndMedSortRelSvc:com.digitalwave.iCare.middletier.clsMiddleTierBase
	{
		public clsFeeAndMedSortRelSvc()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region 
//		/// <summary>
//		/// 
//		/// </summary>
//		/// <param name="p_objPrincipal"></param>
//		/// <param name="p_outDtResutl"></param>
//		/// <returns></returns>
//		public long m_lngGetMedSort(System.Security.Principal.IPrincipal p_objPrincipal,out DataTable p_outDtResutl)
//		{
//			
//			long lngRes=0;
//			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
//			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS","m_mthFindWMedicineByID");
//			if(lngRes < 0)
//			{
//				return -1;
//			}
//			p_outDtResult = new DataTable();
//			
//			return lngRes;
//		}
		#endregion 
		/// <summary>
		/// 
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_outDtResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngGetFeeSort(System.Security.Principal.IPrincipal p_objPrincipal,out DataTable p_outDtResult,out DataTable p_outMedType,out DataTable p_outmedStorage,out DataTable p_outStorage)
		{
			
			long lngRes=0;
			p_outDtResult = null;
			p_outMedType=null;
			p_outmedStorage=null;
			p_outStorage=null;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS","m_lngGetFeeSort");
			if(lngRes < 0)
			{
				return -1;
			}
			p_outDtResult = new DataTable();
			string strSQL = "select itemcatid_chr ,itemcatname_vchr   from t_bse_chargeitemcat a order by itemcatid_chr";
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService obj = new clsHRPTableService();
			try
			{
				lngRes = obj.lngGetDataTableWithoutParameters(strSQL,ref p_outDtResult);
			}
			catch(Exception ee)
			{
				com.digitalwave.Utility.clsLogText objLogErr = new clsLogText();
				objLogErr.LogError(ee);
			}

            strSQL = "select medicinetypeid_chr,medicinetypename_vchr from t_aid_medicinetype";
			try
			{
				lngRes = obj.lngGetDataTableWithoutParameters(strSQL,ref p_outMedType);
			}
			catch(Exception ee)
			{
				com.digitalwave.Utility.clsLogText objLogErr = new clsLogText();
				objLogErr.LogError(ee);
			}

            strSQL = "select medstoreid_chr, medstorename_vchr, medstoretype_int, medicnetype_int, urgence_int, deptid_chr, shortname_chr  from t_bse_medstore where medstoretype_int=1";
			try
			{
				lngRes = obj.lngGetDataTableWithoutParameters(strSQL,ref p_outmedStorage);
			}
			catch(Exception ee)
			{
				com.digitalwave.Utility.clsLogText objLogErr = new clsLogText();
				objLogErr.LogError(ee);
			}
            strSQL = "select medstoreid_chr, medstorename_vchr, medstoretype_int, medicnetype_int, urgence_int, deptid_chr, shortname_chr   from t_bse_medstore where medstoretype_int=2";
			try
			{
				lngRes = obj.lngGetDataTableWithoutParameters(strSQL,ref p_outStorage);
			}
			catch(Exception ee)
			{
				com.digitalwave.Utility.clsLogText objLogErr = new clsLogText();
				objLogErr.LogError(ee);
			}
			return lngRes;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_outDtResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngGetFeeAndMedSortRel(System.Security.Principal.IPrincipal p_objPrincipal,out DataTable p_outDtResult)
		{
			p_outDtResult = new DataTable();
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS","m_mthFindWMedicineByID");
			if(lngRes < 0)
			{
				return -1;
			}
			p_outDtResult = new DataTable();
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService obj = new clsHRPTableService();
			string strSQL = @"SELECT a.*, k.itemcatid_chr,k.outmedstoreid_chr,k.inmedstoreid_chr,k.itemcatname_vchr,k.medstorename_vchr,k.medstorename_vchr1
  FROM t_aid_medicinetype a LEFT JOIN (SELECT b.ITEMCATID_CHR,b.OUTMEDSTOREID_CHR,b.INMEDSTOREID_CHR, c.itemcatname_vchr,
                                              d.medstorename_vchr,
                                              f.medstorename_vchr
                                                        AS medstorename_vchr1,b.medicinetypeid_chr
                                         FROM t_aid_chargemderla b,
                                              t_bse_chargeitemcat c,
                                              t_bse_medstore d,
                                              t_bse_medstore f
                                        WHERE b.itemcatid_chr =
                                                               c.itemcatid_chr
                                          AND b.outmedstoreid_chr = d.medstoreid_chr(+)
                                          AND b.inmedstoreid_chr = f.medstoreid_chr(+)) k ON a.medicinetypeid_chr =
                                                                                               k.medicinetypeid_chr
";
			try
			{
				lngRes = obj.lngGetDataTableWithoutParameters(strSQL,ref p_outDtResult);
			}
			catch(Exception ee)
			{
				com.digitalwave.Utility.clsLogText objLogErr = new clsLogText();
				objLogErr.LogError(ee);
			}
			return lngRes;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_dtRelation"></param>
		/// <param name="p_dtDel"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngSaveFeeAndMedSortRel(System.Security.Principal.IPrincipal p_objPrincipal,DataTable p_dtRelation,DataTable p_dtDel)
		{
			
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS","m_mthFindWMedicineByID");
			if(lngRes < 0)
			{
				return -1;
			}
			if(p_dtRelation == null)
			{
				return 1;
			}
			string strSQL = "";			
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService obj = new clsHRPTableService();

			strSQL = @"  delete t_aid_chargemderla ";
			try
			{
				lngRes = obj.DoExcute(strSQL);
			}
			catch(Exception ee)
			{
				lngRes = -1;
				com.digitalwave.Utility.clsLogText objLogErr = new clsLogText();
				objLogErr.LogError(ee);
			}

			for(int i = 0; i < p_dtRelation.Rows.Count; i++)
			{
					strSQL = @"insert into t_aid_chargemderla
								(itemcatid_chr, medicinetypeid_chr,OUTMEDSTOREID_CHR,INMEDSTOREID_CHR)
								values
								('"+p_dtRelation.Rows[i]["itemcatid_chr"].ToString()+"', '"+p_dtRelation.Rows[i]["medicinetypeid_chr"].ToString()+"','"+p_dtRelation.Rows[i]["OUTMEDSTOREID_CHR"].ToString()+"','"+p_dtRelation.Rows[i]["INMEDSTOREID_CHR"].ToString()+"')";
					try
					{
						lngRes = obj.DoExcute(strSQL);
					}
					catch(Exception ee)
					{
						lngRes = -1;
						com.digitalwave.Utility.clsLogText objLogErr = new clsLogText();
						objLogErr.LogError(ee);
					}			
			}			
			return lngRes;
		}
	}
}
