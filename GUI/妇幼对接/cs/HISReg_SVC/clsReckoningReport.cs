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

	public class clsReckoningReport:com.digitalwave.iCare.middletier.clsMiddleTierBase
	{
		public clsReckoningReport()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 结帐报表 张国良   2004-12-29
		[AutoComplete]
		public long m_lngFindByDateReport(System.Security.Principal.IPrincipal p_objPrincipal,int p_intSelectedIndex,string p_strName,string finddate,out System.Data.DataTable p_tabReport,out System.Data.DataTable p_tabReportdetial)
		{
			string strSQL,strSQL2;
			p_tabReport=new DataTable();
			p_tabReportdetial=new DataTable();
			

			long lngRes = 0;
					
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsReckoningReport","m_lngFindByDateReport");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			
			else if(p_intSelectedIndex==1)
			{
                strSQL = @"select t1.invoiceno_vchr,
       t1.outpatrecipeid_chr,
       t1.invdate_dat,
       t1.acctsum_mny,
       t1.sbsum_mny,
       t1.opremp_chr,
       t1.recordemp_chr,
       t1.recorddate_dat,
       t1.status_int,
       t1.seqid_chr,
       t1.balanceemp_chr,
       t1.balance_dat,
       t1.balanceflag_int,
       t1.totalsum_mny,
       t1.paytype_int,
       t1.patientid_chr,
       t1.patientname_chr,
       t1.deptid_chr,
       t1.deptname_chr,
       t1.doctorid_chr,
       t1.doctorname_chr,
       t1.confirmemp_chr,
       t1.paytypeid_chr,
       t1.internalflag_int,
       t1.baseseqid_chr,
       t1.groupid_chr,
       t1.confirmdeptid_chr,
       t1.split_int,
       t1.regno_chr,
       t1.chargedeptid_chr,t2.LASTNAME_VCHR as strTemp1 " +   
						"FROM t_opr_outpatientrecipeinv t1, t_bse_employee t2 "+
						"WHERE t1.opremp_chr = t2.empid_chr "+
						"and t1.RECORDDATE_DAT like to_date('"+finddate+"','yyyy-MM-dd') order by t1.OPREMP_CHR ";
				
				strSQL2="SELECT t2.ITEMCATID_CHR,t2.TOLFEE_MNY,t2.INVOICENO_VCHR "+
					"FROM T_OPR_OUTPATIENTRECIPEINV t1 ,T_OPR_OUTPATIENTRECIPESUMDE t2 "+
					"where t1.invoiceno_vchr=t2.invoiceno_vchr and t1.status_int<>0 "+
					"and t1.RECORDDATE_DAT like to_date('"+finddate+"','yyyy-MM-dd')";
			}
			
			else
			{
                strSQL = @"select t1.invoiceno_vchr,
       t1.outpatrecipeid_chr,
       t1.invdate_dat,
       t1.acctsum_mny,
       t1.sbsum_mny,
       t1.opremp_chr,
       t1.recordemp_chr,
       t1.recorddate_dat,
       t1.status_int,
       t1.seqid_chr,
       t1.balanceemp_chr,
       t1.balance_dat,
       t1.balanceflag_int,
       t1.totalsum_mny,
       t1.paytype_int,
       t1.patientid_chr,
       t1.patientname_chr,
       t1.deptid_chr,
       t1.deptname_chr,
       t1.doctorid_chr,
       t1.doctorname_chr,
       t1.confirmemp_chr,
       t1.paytypeid_chr,
       t1.internalflag_int,
       t1.baseseqid_chr,
       t1.groupid_chr,
       t1.confirmdeptid_chr,
       t1.split_int,
       t1.regno_chr,
       t1.chargedeptid_chr,t2.LASTNAME_VCHR as strTemp1 " +   
					"FROM t_opr_outpatientrecipeinv t1, t_bse_employee t2 "+
					"WHERE t1.opremp_chr = t2.empid_chr and t1.RECORDDATE_DAT like to_date('"+finddate+"','yyyy-MM-dd') and t1.OPREMP_CHR = '"+p_strName.Trim()+"'and t1.balanceflag_int = 0 order by t1.INVOICENO_VCHR";
				
				strSQL2="SELECT t2.ITEMCATID_CHR,t2.TOLFEE_MNY,t2.INVOICENO_VCHR FROM T_OPR_OUTPATIENTRECIPEINV t1 ,T_OPR_OUTPATIENTRECIPESUMDE t2 "+
					"where t1.invoiceno_vchr=t2.invoiceno_vchr "+
					"and t1.status_int<>0 "+
					"and t1.balanceflag_int = 0 and OPREMP_CHR = '"+p_strName.Trim()+"' "+
					"and t1.RECORDDATE_DAT like to_date('"+finddate+"','yyyy-MM-dd')";
				
			}
			

			try
			{
				
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref p_tabReport);
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL2,ref p_tabReportdetial);
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

		#region 收费处月结算报表 张国良   2005-1-5
		[AutoComplete]
		public long m_lngChargeMnothReport(System.Security.Principal.IPrincipal p_objPrincipal,string finddate,string finddateLast,out System.Data.DataTable p_tabReport)
		{
			string strSQL;
			p_tabReport=new DataTable();
			
			long lngRes = 0;
					
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsReckoningReport","m_lngChargeMnothReport");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
            strSQL = @"select t1.invoiceno_vchr,
       t1.outpatrecipeid_chr,
       t1.invdate_dat,
       t1.acctsum_mny,
       t1.sbsum_mny,
       t1.opremp_chr,
       t1.recordemp_chr,
       t1.recorddate_dat,
       t1.status_int,
       t1.seqid_chr,
       t1.balanceemp_chr,
       t1.balance_dat,
       t1.balanceflag_int,
       t1.totalsum_mny,
       t1.paytype_int,
       t1.patientid_chr,
       t1.patientname_chr,
       t1.deptid_chr,
       t1.deptname_chr,
       t1.doctorid_chr,
       t1.doctorname_chr,
       t1.confirmemp_chr,
       t1.paytypeid_chr,
       t1.internalflag_int,
       t1.baseseqid_chr,
       t1.groupid_chr,
       t1.confirmdeptid_chr,
       t1.split_int,
       t1.regno_chr,
       t1.chargedeptid_chr,t2.LASTNAME_VCHR as strTemp1 " +   
				" FROM t_opr_outpatientrecipeinv t1, t_bse_employee t2 "+
				" WHERE t1.opremp_chr = t2.empid_chr "+
				" AND t1.RECORDDATE_DAT BETWEEN TO_DATE('"+finddate+"','yyyy-mm-dd hh24:mi:ss') "+
				" AND TO_DATE('"+finddateLast+" 23:59:59','yyyy-mm-dd hh24:mi:ss')"+
				" order by t1.OPREMP_CHR ";
			try
			{
				
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref p_tabReport);
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

		#region 修改结帐状态	张国良	2005-1-3
		/// <summary>
		/// 修改收费类别
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="objResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngUpBALANCEFLAG(System.Security.Principal.IPrincipal p_objPrincipal,string p_strName,string finddate)
		{
			long lngRes = 1;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsReckoningReport","m_lngUpBALANCEFLAG");
			
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			
					string strSQL="UPDATE t_opr_outpatientrecipeinv SET balanceflag_int = 1 "+
					"WHERE balanceflag_int = 0 and INVDATE_DAT like to_date('"+finddate+"','yyyy-MM-dd') and OPREMP_CHR = '"+p_strName.Trim()+"' ";

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

		#region 医保月结报表 张国良   2004-12-29
		/// <summary>
		/// 医保报表 张国良   2004-12-29
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="finddate"></param>
		/// <param name="p_tabReport"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngMeditionProtectReport(System.Security.Principal.IPrincipal p_objPrincipal,string finddate,string finddateLast,out System.Data.DataTable p_tabReport)
		{
			string strSQL;
			p_tabReport=new DataTable();
			
			long lngRes = 0;
					
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsReckoningReport","m_lngMeditionProtectReport");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
//            strSQL=@"SELECT t1.invoiceno_vchr, t1.invdate_dat, t1.balance_dat, t1.TOTALSUM_MNY as TOTALSUM_MNY,
//t2.idcard_chr as PATIENTID_CHR, t1.patientname_chr 
// FROM t_opr_outpatientrecipeinv t1, t_bse_patient t2,t_bse_patientPaytype t3
// WHERE t1.patientid_chr = t2.patientid_chr(+)
// and t1.paytypeid_chr=t3.paytypeid_chr(+)
// and t3.internalflag_int = 2
//and t1.BALANCE_DAT is not null
//AND t1.invdate_dat BETWEEN TO_DATE('"+finddate+"','yyyy-mm-dd hh24:mi:ss') "+
//                        " AND TO_DATE('"+finddateLast+" 23:59:59','yyyy-mm-dd hh24:mi:ss')";
            strSQL = @"SELECT t1.invoiceno_vchr, t1.invdate_dat, t1.balance_dat, t1.TOTALSUM_MNY as TOTALSUM_MNY,
t2.idcard_chr as PATIENTID_CHR, t1.patientname_chr 
 FROM t_opr_outpatientrecipeinv t1, t_bse_patient t2
 WHERE t1.patientid_chr = t2.patientid_chr(+)
   AND t1.PAYTYPE_INT=3
   and (t1.status_int = 1 or t1.status_int = 3)
and t1.BALANCE_DAT is not null
AND t1.invdate_dat BETWEEN TO_DATE('" + finddate + "','yyyy-mm-dd hh24:mi:ss') " +
            " AND TO_DATE('" + finddateLast + " 23:59:59','yyyy-mm-dd hh24:mi:ss') order by t1.invdate_dat";
			try
			{
				
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref p_tabReport);
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

		#region 公费医疗报表 张国良   2004-12-31
		/// <summary>
		/// 公费医疗报表 张国良   2004-12-31
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="fromt"></param>
		/// <param name="patienName"></param>
		/// <param name="finddate"></param>
		/// <param name="p_tabReport"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngPublicPayReport(System.Security.Principal.IPrincipal p_objPrincipal,int fromt,string p_patientID,string finddate,string p_toDate,out System.Data.DataTable p_tabReport)
		{
			string strSQL;
			p_tabReport=new DataTable();
			
			long lngRes = 0;
					
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsReckoningReport","m_lngPublicPayReport");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			strSQL="SELECT t1.invoiceno_vchr, t1.invdate_dat,  t1.totalsum_mny,"+
				"PATIENTNAME_CHR,t1.DOCTORID_CHR,t2.EMPNO_CHR  "+
				" FROM t_opr_outpatientrecipeinv t1, t_bse_employee t2 WHERE t1.OPREMP_CHR = t2.EMPID_CHR(+)  AND t1.paytypeid_chr = '0011' AND t1.STATUS_INT=1 ";
			if(fromt==1)
			{
				strSQL=strSQL+
					"AND t1.PATIENTNAME_CHR like  '"+p_patientID+"' "+
					"AND t1.invdate_dat between to_date('"+finddate+"','yyyy-mm-dd') "+
					"AND to_Date('"+p_toDate+" 23:59:59','yyyy-mm-dd hh24:mi:ss')";
			}
			else if(fromt==2)
			{
				strSQL=strSQL+
					"AND t1.PATIENTNAME_CHR like  '"+p_patientID+"' ";
			}
			else if(fromt==3)
			{
				strSQL=strSQL+
					"AND t1.invdate_dat between to_date('"+finddate+"','yyyy-mm-dd') "+
					"AND to_Date('"+p_toDate+" 23:59:59','yyyy-mm-dd hh24:mi:ss')";
			}

			strSQL=strSQL+" ORDER BY t1.invoiceno_vchr ";
					try
			{
				
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref p_tabReport);
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
	[Transaction(TransactionOption.Required)]
	[ObjectPooling(true)]

	public class clsDifficultyReportOfMonthSvc:com.digitalwave.iCare.middletier.clsMiddleTierBase
	{
		public clsDifficultyReportOfMonthSvc()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 获取数据
		[AutoComplete]
		public long m_mthGetAllDataOfMonth(System.Security.Principal.IPrincipal p_objPrincipal,DateTime date,DateTime date2,out System.Data.DataTable dt,out System.Data.DataTable dt1,out System.Data.DataTable dt2)
		{
		
			dt=new DataTable();
			dt1=new DataTable();
			dt2=new DataTable();
			long lngRes = 0;
					
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsReckoningReport","m_lngFindByDateReport");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL=@"SELECT   SUM (c.chargeup) AS chargeup, c.groupid_chr, COUNT
                                                           (*) AS totailcount,
         MONTH
    FROM (SELECT a.outpatrecipeid_chr,SUM(a.chargeup) AS chargeup, b.groupid_chr, a.seqid_chr,
                 a.MONTH
            FROM (SELECT   a.outpatrecipeid_chr,
                           SUM (b.tolprice_mny * (1 - b.discount_dec)
                               ) AS chargeup,
                           c.itemopinvtype_chr, e.seqid_chr,
                           TO_CHAR (TRUNC (a.createdate_dat),
                                    'yyyy-mm'
                                   ) AS MONTH
                      FROM t_opr_outpatientrecipe a,
                           t_opr_oprecipeitemde b,
                           t_bse_chargeitem c,
                           t_bse_patientpaytype f,
                           t_opr_outpatientrecipeinv e
                     WHERE a.pstauts_int = 2
                       AND a.paytypeid_chr = f.paytypeid_chr(+)
                       AND f.internalflag_int = 3
                       AND a.outpatrecipeid_chr = e.outpatrecipeid_chr(+)
                    AND a.createdate_dat BETWEEN TO_DATE ('"+date+@"',
                                                     'yyyy-mm-dd hh24:mi:ss'
                                                    )
                                        AND TO_DATE ('"+date2+ @"',
                                                     'yyyy-mm-dd hh24:mi:ss'
                                                    )
                       AND a.outpatrecipeid_chr = b.outpatrecipeid_chr(+)
                       AND b.itemid_chr = c.itemid_chr(+)
					   AND e.BALANCEFLAG_INT=1
                  GROUP BY a.outpatrecipeid_chr,
                           itemopinvtype_chr,
                           seqid_chr,
                           TRUNC (createdate_dat)) a,
                 (SELECT rptid_chr,groupid_chr,typeid_chr,flag_int
                    FROM t_aid_rpt_gop_rla
                   WHERE rptid_chr = '0067' AND flag_int = 2) b
           WHERE a.itemopinvtype_chr = b.typeid_chr  AND chargeup>0 GROUP BY outpatrecipeid_chr,seqid_chr,MONTH,groupid_chr) c where c.chargeup>0
GROUP BY groupid_chr, MONTH";
			try
			{
				
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dt);
						
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			strSQL=@"select registercost,MONTH,recipeflag_int  from (SELECT CASE
          WHEN a.recipeflag_int = 1
             THEN 5.00
          ELSE 0
       END AS registercost,TO_CHAR (TRUNC (a.createdate_dat),
                                    'yyyy-mm'
                                   ) AS MONTH,a.recipeflag_int
  FROM t_opr_outpatientrecipe a,
       t_opr_outpatientrecipeinv e,
       t_bse_patientpaytype f
 WHERE a.pstauts_int = 2
   AND a.paytypeid_chr = f.paytypeid_chr(+)
   AND f.internalflag_int = 3
  AND a.createdate_dat BETWEEN TO_DATE ('"+date+@"',
                                                     'yyyy-mm-dd hh24:mi:ss'
                                                    )
                                        AND TO_DATE ('"+date2+@"',
                                                     'yyyy-mm-dd hh24:mi:ss'
                                                    )
   AND a.outpatrecipeid_chr = e.outpatrecipeid_chr(+)
   AND e.balanceflag_int = 1) a where a.recipeflag_int=1";
			try
			{
				
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dt2);
						
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			strSQL=@"SELECT Distinct groupid_chr
            FROM t_aid_rpt_gop_rla
           WHERE rptid_chr = '0067' AND flag_int = 2 order by groupid_chr";
			try
			{
				
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dt1);
						
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
	[Transaction(TransactionOption.Required)]
	[ObjectPooling(true)]

	public class clsDifficultyReportSvc:com.digitalwave.iCare.middletier.clsMiddleTierBase
	{
		public clsDifficultyReportSvc()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 获取数据
		[AutoComplete]
		public long m_mthGetManiReportData(System.Security.Principal.IPrincipal p_objPrincipal,DateTime date,DateTime date2,out System.Data.DataTable dt,out System.Data.DataTable dt2)
		{
		
			dt=new DataTable();
			dt2=new DataTable();
			long lngRes = 0;
					
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsReckoningReport","m_lngFindByDateReport");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
            //and a.RECORDEMP_CHR=d.empid_chr(+)   
				string strSQL="select a.OUTPATRECIPEID_CHR,c.lastname_vchr PatientName,a.CREATEDATE_DAT \"" + "date" + "\"" + @",e.invoiceno_vchr invoiceNo,c.difficulty_vchr difficultyNo,case when A.RECIPEFLAG_INT=1 then 5.00 else 0 end as RegisterCost,'' CheckSelfPay,
'' CheckChargeUp,'' CureSelfPay,'' CureChargeUp,'' MedicineSelfPay, '' MedicineChargeUp,d.lastname_vchr Operator,a.RECIPEFLAG_INT,e.STATUS_INT,e.seqid_chr
 from T_OPR_OUTPATIENTRECIPE A,T_BSE_PATIENT c,T_BSE_EMPLOYEE D,T_OPR_OUTPATIENTRECIPEINV E, t_bse_patientPaytype f
where a.PSTAUTS_INT =2
    and a.paytypeid_chr=f.paytypeid_chr(+)
    and f.INTERNALFLAG_INT =3
and a.CREATEDATE_DAT BETWEEN TO_DATE('"+date.ToString("yyyy-MM-dd 00:00:00")+"','yyyy-mm-dd hh24:mi:ss') "+
	@" AND TO_DATE('"+date2.ToString("yyyy-MM-dd 23:59:59")+ @"','yyyy-mm-dd hh24:mi:ss')
and a.patientid_chr =c.patientid_chr(+)
AND e.OPREMP_CHR = d.empid_chr(+)
and a.outpatrecipeid_chr=e.OUTPATRECIPEID_CHR(+)    and e.balanceflag_int=1";
			string strSQL2=@"select A.OUTPATRECIPEID_CHR,a.SELFPAY,a.CHARGEUP,b.GROUPID_CHR,a.SEQID_CHR from (
select a.outpatrecipeid_chr,sum(b.tolprice_mny*b.discount_dec) as SelfPay,sum(b.tolprice_mny*(1-b.discount_dec)) as chargeUp,C.ITEMOPINVTYPE_CHR,e.SEQID_CHR
from T_OPR_OUTPATIENTRECIPE A,T_OPR_OPRECIPEITEMDE B ,T_BSE_CHARGEITEM C,t_bse_patientpaytype f, T_OPR_OUTPATIENTRECIPEINV e
           WHERE a.pstauts_int = 2
             AND a.paytypeid_chr = f.paytypeid_chr(+)
             AND f.internalflag_int = 3
 and a.outpatrecipeid_chr =e.outpatrecipeid_chr(+)
and a.CREATEDATE_DAT BETWEEN TO_DATE('"+date.ToString("yyyy-MM-dd 00:00:00")+"','yyyy-mm-dd hh24:mi:ss') "+
				@" AND TO_DATE('"+date2.ToString("yyyy-MM-dd 23:59:59")+ @"','yyyy-mm-dd hh24:mi:ss')
and a.outpatrecipeid_chr=B.outpatrecipeid_chr(+)
and b.itemid_chr=c.itemid_chr(+)
and e.balanceflag_int=1
group by a.outpatrecipeid_chr,ITEMOPINVTYPE_CHR,SEQID_CHR) A,
(
select rptid_chr,groupid_chr,typeid_chr,flag_int
          from t_aid_rpt_gop_rla
         where rptid_chr = '0044' and flag_int = 2) b
where a.ITEMOPINVTYPE_CHR =b.TYPEID_CHR(+) order by 1,5";
			try
			{
				
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dt);
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL2,ref dt2);
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
