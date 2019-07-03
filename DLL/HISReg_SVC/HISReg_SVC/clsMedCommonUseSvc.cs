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
	/// clsMedCommonUseSvc 的摘要说明。
	/// </summary>
	[Transaction(TransactionOption.Required)]
	[ObjectPooling(true)]
	public class clsMedCommonUseSvc:com.digitalwave.iCare.middletier.clsMiddleTierBase
	{
		public clsMedCommonUseSvc()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		[AutoComplete]
		public long m_lngGetMedBseInfo(System.Security.Principal.IPrincipal p_objPrincipal,string p_strMedSort,string p_strMedShape,out System.Data.DataTable p_outdtResult)
		{
			long lngRes=0;
			p_outdtResult = new System.Data.DataTable();
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS","m_lngGetMedBseInfo");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @"select a.itemcode_vchr,a.ITEMSRCTYPE_INT,a.itemname_vchr,a.itemspec_vchr,a.itemid_chr,a.itemsrctypename_vchr,b.NOQTYFLAG_INT,a.ITEMPYCODE_CHR,a.ITEMWBCODE_CHR,a.ITEMENGNAME_VCHR from t_bse_chargeitem A ,T_BSE_MEDICINE B
								where a.ITEMSRCID_VCHR = b.medicineid_chr(+) and a.IFSTOP_INT=0";
			if( p_strMedSort == "%")
			{
				strSQL += " and (a.ITEMCATID_CHR is null or a.ITEMCATID_CHR like '"+p_strMedSort+@"')";
			}
			else
			{
				strSQL += " and a.ITEMCATID_CHR like '"+p_strMedSort+@"'";
			}
			if( p_strMedShape == "%")
			{
				strSQL += " and (a.ITEMCATID_CHR is null or a.ITEMCATID_CHR like  '"+p_strMedShape+@"') ";
			}
			else
			{
				strSQL += " and a.ITEMCATID_CHR like  '"+p_strMedShape+@"'";
			}
			strSQL += " order by a.itemcode_vchr";			
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref p_outdtResult);				
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}


		[AutoComplete]
		public long m_lngGetPrjBseInfo(System.Security.Principal.IPrincipal p_objPrincipal,string p_strMedSort, out System.Data.DataTable p_outdtResult)
		{
			long lngRes=0;
			p_outdtResult = new System.Data.DataTable();
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS","m_lngGetPrjBseInfo");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @"select a.ITEMID_CHR , a.ITEMNAME_VCHR ,a.ITEMPYCODE_CHR, a.ITEMENGNAME_VCHR,a.ITEMWBCODE_CHR,a.ITEMCODE_VCHR ,a.ITEMSPEC_VCHR ,c.NOQTYFLAG_INT
									from t_bse_chargeitem a , t_bse_chargeitemcat b , t_bse_medicine c
									where a.IFSTOP_INT =0
									
									and a.ITEMSRCID_VCHR = c.medicineid_chr(+)
									and a.ITEMCATID_CHR = b.itemcatid_chr(+)";
			if( p_strMedSort != "")
			{
				strSQL += p_strMedSort;
			}
			
			strSQL += " order by a.ITEMCODE_VCHR";			
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref p_outdtResult);				
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}

		[AutoComplete]
		public long m_lngGetMedSort(System.Security.Principal.IPrincipal p_objPrincipal,out System.Data.DataTable p_outdtResult)
		{
			long lngRes=0;
			p_outdtResult = new System.Data.DataTable();
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS","m_lngGetMedSort");
			if(lngRes < 0)
			{
				return -1;
			}
			string strSQL = @"select * from t_bse_chargeitemcat";			
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref p_outdtResult);				
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
			
		}

		
		[AutoComplete]
		public long m_lngGetMedShape(System.Security.Principal.IPrincipal p_objPrincipal,out System.Data.DataTable p_outdtResult)
		{
			long lngRes=0;
			p_outdtResult = new System.Data.DataTable();
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS","m_lngGetMedShape");
			if(lngRes < 0)
			{
				return -1;
			}
			string strSQL = @"select * from t_aid_medicinepreptype";		
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref p_outdtResult);				
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		[AutoComplete]
		public long GetMedCommonUseInfo(System.Security.Principal.IPrincipal p_objPrincipal,com.digitalwave.iCare.ValueObject.clsLoginInfo p_loginInfo,out System.Data.DataTable p_outdtResult)
		{
			long lngRes=0;
			p_outdtResult = new System.Data.DataTable();
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS","GetMedCommonUseInfo");
			if(lngRes < 0)
			{
				return -1;
			}
			string strSQL = @"select f.itemid_chr,F.SEQID_CHR,e.itemcode_vchr,f.deptid_chr,g.deptname_vchr,f.createrid_chr,f.privilege_int,
								decode(f.privilege_int,0,'个人',1,'科室') as privilege_name,e.itemname_vchr,
								e.itemspec_vchr,h.NOQTYFLAG_INT
								from T_AID_COMUSECHARGEITEM f, t_Bse_Chargeitem e,t_bse_deptdesc g ,t_bse_medicine h
								where f.itemid_chr = e.itemid_chr
								and f.deptid_chr = g.deptid_chr(+) 
								and e.ITEMSRCID_VCHR=h.MEDICINEID_CHR(+)
								and f.TYPE_INT=0
								and f.createrid_chr = '"+p_loginInfo.m_strEmpID+@"'
                and f.itemid_chr not in( 
                select f.itemid_chr
								from T_AID_COMUSECHARGEITEM f, t_Bse_Chargeitem e,t_bse_deptdesc g 
								where f.itemid_chr = e.itemid_chr
								and f.deptid_chr = g.deptid_chr(+) 
								and f.TYPE_INT=0
								and (f.deptid_chr in 
                (select a.deptid_chr from t_bse_deptemp a where a.empid_chr = '"+p_loginInfo.m_strEmpID+@"')) 
                )               
                union
                select f.itemid_chr,F.SEQID_CHR,e.itemcode_vchr,f.deptid_chr,g.deptname_vchr,f.createrid_chr,f.privilege_int,
								decode(f.privilege_int,0,'个人',1,'科室') as privilege_name,e.itemname_vchr,
								e.itemspec_vchr,h.NOQTYFLAG_INT
								from T_AID_COMUSECHARGEITEM f, t_Bse_Chargeitem e,t_bse_deptdesc g ,t_bse_medicine h
								where f.itemid_chr = e.itemid_chr
								and f.deptid_chr = g.deptid_chr(+) 
								and e.ITEMSRCID_VCHR=h.MEDICINEID_CHR(+)
								and f.TYPE_INT=0
								and (f.deptid_chr in
                (select a.deptid_chr from t_bse_deptemp a where a.empid_chr = '"+p_loginInfo.m_strEmpID+@"')) order by itemcode_vchr";
			
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref p_outdtResult);				
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}



		[AutoComplete]
		public long GetPrjCommonUseInfo(System.Security.Principal.IPrincipal p_objPrincipal,com.digitalwave.iCare.ValueObject.clsLoginInfo p_loginInfo,out System.Data.DataTable p_outdtResult)
		{
			long lngRes=0;
			p_outdtResult = new System.Data.DataTable();
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS","GetMedCommonUseInfo");
			if(lngRes < 0)
			{
				return -1;
			}
			string strSQL = @"select f.itemid_chr,F.SEQID_CHR,e.itemcode_vchr,f.deptid_chr,g.deptname_vchr,f.createrid_chr,f.privilege_int,
								decode(f.privilege_int,0,'个人',1,'科室') as privilege_name,e.itemname_vchr,
								e.itemspec_vchr,h.NOQTYFLAG_INT
								from T_AID_COMUSECHARGEITEM f, t_Bse_Chargeitem e,t_bse_deptdesc g ,t_bse_medicine h
								where f.itemid_chr = e.itemid_chr(+)
								and f.TYPE_INT=1
								and f.deptid_chr = g.deptid_chr(+) 
								and e.ITEMSRCID_VCHR=h.MEDICINEID_CHR
								and e.ITEMSRCTYPE_INT=1
								and f.createrid_chr = '"+p_loginInfo.m_strEmpID+@"'
                and f.itemid_chr not in( 
                select f.itemid_chr
								from T_AID_COMUSECHARGEITEM f, t_Bse_Chargeitem e,t_bse_deptdesc g 
								where f.itemid_chr = e.itemid_chr(+)

								and f.TYPE_INT=1
								and f.deptid_chr = g.deptid_chr(+) 
								and (f.deptid_chr in 
                (select a.deptid_chr from t_bse_deptemp a where a.empid_chr = '"+p_loginInfo.m_strEmpID+@"')) 
                )               
                union
                select f.itemid_chr,F.SEQID_CHR,e.itemcode_vchr,f.deptid_chr,g.deptname_vchr,f.createrid_chr,f.privilege_int,
								decode(f.privilege_int,0,'个人',1,'科室') as privilege_name,e.itemname_vchr,
								e.itemspec_vchr,h.NOQTYFLAG_INT
								from T_AID_COMUSECHARGEITEM f, t_Bse_Chargeitem e,t_bse_deptdesc g ,t_bse_medicine h
								where f.itemid_chr = e.itemid_chr(+)
								and f.TYPE_INT=1
								and f.deptid_chr = g.deptid_chr(+) 
								and e.ITEMSRCID_VCHR=h.MEDICINEID_CHR
								and e.ITEMSRCTYPE_INT=1
								and (f.deptid_chr in
                (select a.deptid_chr from t_bse_deptemp a where a.empid_chr = '"+p_loginInfo.m_strEmpID+@"')) order by itemcode_vchr";
			
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref p_outdtResult);				
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}


		[AutoComplete]
		public long SaveMedCommonUseInfo(System.Security.Principal.IPrincipal p_objPrincipal,System.Data.DataTable p_SrcDt,System.Data.DataTable p_DelDt)
		{
			long lngRes=0;		
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS","SaveMedCommonUseInfo");
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			if(lngRes < 0)
			{
				return -1;
			}
			string strSQL = "";
			if(p_DelDt != null)
			{
				
				for(int i1 = 0; i1 < p_DelDt.Rows.Count; i1++)
				{
					strSQL = "DELETE T_AID_COMUSECHARGEITEM WHERE SEQID_CHR = '"+p_DelDt.Rows[i1]["SEQID_CHR"].ToString().Trim()+"'";
					try
					{
						
						lngRes = objHRPSvc.DoExcute(strSQL);						
					}
					catch(Exception objEx)
					{
						string strTmp=objEx.Message;
						com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
						bool blnRes = objLogger.LogError(objEx);
					}
				}
			}
			if(p_SrcDt != null)
			{
				string strSeqid = "";
				for(int i1 = 0; i1 < p_SrcDt.Rows.Count; i1++)
				{
					if(p_SrcDt.Rows[i1].RowState == System.Data.DataRowState.Added)
					{
						objHRPSvc.lngGenerateID(10,"seqid_chr","t_aid_comusechargeitem",out strSeqid);
						strSQL = @"insert into t_aid_comusechargeitem(seqid_chr,CREATE_DAT ,deptid_chr, itemid_chr, createrid_chr, privilege_int) values(?,?,?,?,?,?)";
						try
						{

                            System.Data.IDataParameter[] paramArr = null;
                            objHRPSvc.CreateDatabaseParameter(6, out paramArr);
                            paramArr[0].Value = strSeqid;
                            paramArr[1].Value = System.DateTime.Now;
                            paramArr[2].Value = p_SrcDt.Rows[i1]["deptid_chr"].ToString().Trim();
                            paramArr[3].Value = p_SrcDt.Rows[i1]["itemid_chr"].ToString().Trim();
                            paramArr[4].Value = p_SrcDt.Rows[i1]["createrid_chr"].ToString().Trim();
                            paramArr[5].Value = p_SrcDt.Rows[i1]["privilege_int"].ToString().Trim();

                            long lngRecordsAffected = -1;
                            lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecordsAffected, paramArr);
                            objHRPSvc.Dispose();
							
							p_SrcDt.Rows[i1]["seqid_chr"] = strSeqid;
					
						}
						catch(Exception objEx)
						{
							string strTmp=objEx.Message;
							com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
							bool blnRes = objLogger.LogError(objEx);
						}
					}
				}
			}
			return lngRes;
		}

		[AutoComplete]
		public long SavePrjCommonUseInfo(System.Security.Principal.IPrincipal p_objPrincipal,System.Data.DataTable p_SrcDt,System.Data.DataTable p_DelDt,string strType)
		{
			long lngRes=0;		
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS","SavePrjCommonUseInfo");
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			if(lngRes < 0)
			{
				return -1;
			}
			string strSQL = "";
			if(p_DelDt != null)
			{
				
				for(int i1 = 0; i1 < p_DelDt.Rows.Count; i1++)
				{
					strSQL = "DELETE T_AID_COMUSECHARGEITEM WHERE SEQID_CHR = '"+p_DelDt.Rows[i1]["SEQID_CHR"].ToString().Trim()+"' and TYPE_INT="+strType;
					try
					{
						
						lngRes = objHRPSvc.DoExcute(strSQL);						
					}
					catch(Exception objEx)
					{
						string strTmp=objEx.Message;
						com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
						bool blnRes = objLogger.LogError(objEx);
					}
				}
			}
			if(p_SrcDt != null)
			{
				string strSeqid = "";
				for(int i1 = 0; i1 < p_SrcDt.Rows.Count; i1++)
				{
					if(p_SrcDt.Rows[i1].RowState == System.Data.DataRowState.Added)
					{
						objHRPSvc.lngGenerateID(10,"seqid_chr","t_aid_comusechargeitem",out strSeqid);
                        strSQL = @"insert into t_aid_comusechargeitem(seqid_chr,CREATE_DAT ,deptid_chr, itemid_chr, createrid_chr, privilege_int,TYPE_INT) values(?,?,?,?,?,?,?)";
                        try
                        {

                            System.Data.IDataParameter[] paramArr = null;
                            objHRPSvc.CreateDatabaseParameter(7, out paramArr);
                            paramArr[0].Value = strSeqid;
                            paramArr[1].Value = System.DateTime.Now;
                            paramArr[2].Value = p_SrcDt.Rows[i1]["deptid_chr"].ToString().Trim();
                            paramArr[3].Value = p_SrcDt.Rows[i1]["itemid_chr"].ToString().Trim();
                            paramArr[4].Value = p_SrcDt.Rows[i1]["createrid_chr"].ToString().Trim();
                            paramArr[5].Value = p_SrcDt.Rows[i1]["privilege_int"].ToString().Trim();
                            paramArr[6].Value = strType;

                            long lngRecordsAffected = -1;
                            lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecordsAffected, paramArr);
                            objHRPSvc.Dispose();

                            p_SrcDt.Rows[i1]["seqid_chr"] = strSeqid;

                        }
						catch(Exception objEx)
						{
							string strTmp=objEx.Message;
							com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
							bool blnRes = objLogger.LogError(objEx);
						}
					}
				}
			}
			return lngRes;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="p_strEmpID"></param>
		/// <returns></returns>
		[AutoComplete]
		public bool m_bIsHasPrescriptionRight(System.Security.Principal.IPrincipal p_objPrincipal,string p_strEmpID)//HASPRESCRIPTIONRIGHT_CHR
		{
			long lngRes=0;		
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS","m_bIsHasPrescriptionRight");
			if(lngRes < 0)
			{
				return false;
			}
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			string strSQL = "select a.hasprescriptionright_chr from t_bse_employee  a where empid_chr = '"+p_strEmpID.Trim()+"'";
			System.Data.DataTable dt = new DataTable();
			try
			{
				objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dt);
			}
			catch(Exception ee)
			{
				string strTmp=ee.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(ee);
			}
			if(dt == null || dt.Rows.Count < 1)
			{
				return false;
			}
			if(dt.Rows[0]["hasprescriptionright_chr"].ToString().Trim() == "1")
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
