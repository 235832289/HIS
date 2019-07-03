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
	/// 门诊日排班中间层
	/// </summary>
	//	[Transaction(TransactionOption.Required)]
	//	[ObjectPooling(Enabled=true)]
	[Transaction(TransactionOption.Required)]
	[ObjectPooling(true)]
	public class clsOPDoctorPlanSvc:com.digitalwave.iCare.middletier.clsMiddleTierBase
	{
		public clsOPDoctorPlanSvc()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		//日排班
		#region 增加日排班记录 Create by Sam 2004-6-2
		/// <summary>
		/// 增加日排班记录
		/// </summary>
		[AutoComplete]
		public long m_lngDoAddNewDayPlan(System.Security.Principal.IPrincipal p_objPrincipal,clsOPDoctorPlan_VO objPlan,out string p_strRecordID)
		{
			long lngRes = 0;
			p_strRecordID = "";
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc","m_lngDoAddNewDayPlan");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			//返回一最大的计划号
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			lngRes = objHRPSvc.lngGenerateID(18,"opdrplanid_chr","t_opr_opdoctorplan",out p_strRecordID);
			if(lngRes < 0)
				return lngRes;
			//string strDate =clsGetServerDate.s_GetServerDate().ToShortDateString();
			string strOperatorID=objPlan.m_objRecordEmp.strEmpID;
			string strSQL = " Insert Into t_opr_OPDoctorPlan (OPDrplanID_chr,plandate_dat,planperiod_chr, " +
				            "starttime_chr,endtime_chr,opdcotor_chr,opdept_chr,maxdiagtimes_int,registertypeid_chr, " +
				            "recordemp_chr,recorddate_dat,OPADDRESS_VCHR) " +
				            " values ('"+p_strRecordID+"',to_date('"+objPlan.m_strPlanDate+"','yyyy-mm-dd hh24:mi:ss'), " +
				            "'"+objPlan.m_strPlanPeriod+"','"+objPlan.m_strStartTime+"'," +
				            "'"+objPlan.m_strEndTime+"','"+objPlan.m_objOPDoctor.strEmpID+"', " +
				            "'"+objPlan.m_objOPDept.strDeptID+"','"+objPlan.m_intMaxDiagTimes+"'," +
				            "'"+objPlan.m_objRegisterType.m_strRegisterTypeID+"','"+strOperatorID+"',sysdate,'"+objPlan.m_strOPAddress+"')";

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
			return lngRes;
		}
		#endregion

		#region  更新日排班记录 Sam 2004-6-2
		/// <summary>
		///  更新日排班记录
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="objPlan"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDoUpdDayPlanByID(System.Security.Principal.IPrincipal p_objPrincipal,clsOPDoctorPlan_VO objPlan)
		{
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc","m_lngDoUpdDayPlanByID");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL = " UPDate t_opr_OPDoctorPlan Set planperiod_chr='"+objPlan.m_strPlanPeriod+"'," +
				"starttime_chr='"+objPlan.m_strStartTime+"',endtime_chr='"+objPlan.m_strEndTime+"', " +
				"opdept_chr='"+objPlan.m_objOPDept.strDeptID+"', " +
				"maxdiagtimes_int='"+objPlan.m_intMaxDiagTimes+"',registertypeid_chr='"+objPlan.m_objRegisterType.m_strRegisterTypeID+"', " +
				"recorddate_dat=sysdate,OPADDRESS_VCHR='"+objPlan.m_strOPAddress+"' " +
				" Where OPDrplanID_chr='"+objPlan.m_strOPDrPlanID+"'" ;

			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.DoExcute(strSQL);				
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

		#region  删除日排班记录 Sam 2004-6-2
		/// <summary>
		///  删除日排班记录
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="strPlanID"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDeleteDayPlanByID(System.Security.Principal.IPrincipal p_objPrincipal,string strPlanID)
		{
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc","m_lngDeleteDayPlanByID");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL = " Delete t_opr_OPDoctorPlan " +
				            " Where OPDrplanID_chr='"+strPlanID+"'" ;

			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.DoExcute(strSQL);				
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

		#region  通过日期和科室取得排班记录 Sam 2004-6-2
		/// <summary>
		///  通过日期和科室取得排班记录
		/// </summary>
		[AutoComplete]
		public long m_lngGetPlanByDateAndDep(System.Security.Principal.IPrincipal p_objPrincipal,string strDate,string strDepID,out clsOPDoctorPlan_VO[] objPlan)
		{
			objPlan=new clsOPDoctorPlan_VO[0];
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc","m_lngGetPlanByDateAndDep");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
            string strSQL = @"select a.opdrplanid_chr,
       a.plandate_dat,
       a.starttime_chr,
       a.endtime_chr,
       a.opdcotor_chr,
       a.opdept_chr,
       a.maxdiagtimes_int,
       a.registertypeid_chr,
       a.planperiod_chr,
       a.recordemp_chr,
       a.recorddate_dat,
       a.opaddress_vchr,
       a.optimes_int,b.lastname_vchr,b.empno_chr,c.registertypename_vchr,d.deptname_vchr " +
				" from t_opr_opdoctorplan a, t_bse_employee b,t_bse_registertype c,t_bse_deptdesc d " +
				" where a.plandate_dat=? and a.opdept_chr=? " +
				" and a.opdcotor_chr=b.empid_chr and a.registertypeid_chr=c.registertypeid_chr and a.opdept_chr=d.deptid_chr order by planperiod_chr,opdept_chr";

			DateTime sDate=Convert.ToDateTime(strDate);
			System.Data.IDataParameter[] objPar=clsIDataParameterCreator.s_objConstructIDataParameterArr(new object[]{sDate,strDepID});
			//			string strSQL="Select a.*,b.lastname_vchr,c.registertypename_vchr " +
			//                          " From t_opr_OPDoctorPlan a, t_bse_Employee b,t_bse_RegisterType c " +
			//                          " Where a.plandate_dat=to_date('"+strDate+"','yyyy-mm-dd hh24:mi:ss') And a.opdept_chr='"+strDepID+"' " +
			//                          " And a.opdcotor_chr=b.empid_chr And a.registertypeid_chr=c.registertypeid_chr  ";
			try
			{
				DataTable dtbResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL,ref dtbResult,objPar);
				//				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbResult);
				objHRPSvc.Dispose();

				if(lngRes > 0 && dtbResult.Rows.Count > 0)
				{
					objPlan = new clsOPDoctorPlan_VO[dtbResult.Rows.Count];
	
					for(int i1=0;i1<objPlan.Length;i1++)
					{
						objPlan[i1] = new clsOPDoctorPlan_VO();
						if(dtbResult.Rows[i1]["MAXDIAGTIMES_INT"].ToString().Trim()!="")
							objPlan[i1].m_intMaxDiagTimes=int.Parse(dtbResult.Rows[i1]["MAXDIAGTIMES_INT"].ToString().Trim());
						objPlan[i1].m_objOPDept=new clsDepartmentVO();
						objPlan[i1].m_objOPDept.strDeptID=strDepID;
						objPlan[i1].m_objOPDept.strDeptName=dtbResult.Rows[i1]["DEPTNAME_VCHR"].ToString().Trim();
						objPlan[i1].m_objOPDoctor=new clsEmployeeVO();
						objPlan[i1].m_objOPDoctor.strEmpID=dtbResult.Rows[i1]["OPDCOTOR_CHR"].ToString().Trim();
						objPlan[i1].m_objOPDoctor.strName=dtbResult.Rows[i1]["lastname_vchr"].ToString().Trim();
						objPlan[i1].m_objOPDoctor.strEmpNO=dtbResult.Rows[i1]["EMPNO_CHR"].ToString().Trim();
						objPlan[i1].m_strEndTime=dtbResult.Rows[i1]["ENDTIME_CHR"].ToString().Trim();
						objPlan[i1].m_strOPDrPlanID=dtbResult.Rows[i1]["OPDRPLANID_CHR"].ToString().Trim();
						objPlan[i1].m_strPlanDate=strDate;
						objPlan[i1].m_strStartTime=dtbResult.Rows[i1]["STARTTIME_CHR"].ToString().Trim();
						objPlan[i1].m_strPlanPeriod=dtbResult.Rows[i1]["planperiod_chr"].ToString().Trim();
						objPlan[i1].m_objRegisterType=new clsRegisterType_VO();
						objPlan[i1].m_objRegisterType.m_strRegisterTypeID=dtbResult.Rows[i1]["registertypeid_chr"].ToString().Trim();
						objPlan[i1].m_objRegisterType.m_strRegisterTypeName=dtbResult.Rows[i1]["registertypename_vchr"].ToString().Trim();
						objPlan[i1].m_objRecordEmp=new clsEmployeeVO();
						objPlan[i1].m_objRecordEmp.strEmpID=dtbResult.Rows[i1]["recordemp_chr"].ToString().Trim();
						objPlan[i1].m_objRecordDate=dtbResult.Rows[i1]["recorddate_dat"].ToString().Trim();
						objPlan[i1].m_strOPAddress=dtbResult.Rows[i1]["OPADDRESS_VCHR"].ToString().Trim();
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


		#region  通过日期取得所有的排班记录
		/// <summary>
		///  通过日期取得所有的排班记录
		/// </summary>
		[AutoComplete]
		public long m_lngGetPlanByDateAndDepAll(System.Security.Principal.IPrincipal p_objPrincipal,string strDate,out clsOPDoctorPlan_VO[] objPlan)
		{
			objPlan=new clsOPDoctorPlan_VO[0];
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc","m_lngGetPlanByDateAndDepAll");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL=@"select a.opdrplanid_chr,
       a.plandate_dat,
       a.starttime_chr,
       a.endtime_chr,
       a.opdcotor_chr,
       a.opdept_chr,
       a.maxdiagtimes_int,
       a.registertypeid_chr,
       a.planperiod_chr,
       a.recordemp_chr,
       a.recorddate_dat,
       a.opaddress_vchr,
       a.optimes_int,b.lastname_vchr,b.empno_chr,c.registertypename_vchr,d.deptname_vchr " +
				" from t_opr_opdoctorplan a, t_bse_employee b,t_bse_registertype c,t_bse_deptdesc d " +
				" Where a.plandate_dat=To_Date('"+strDate+"','yyyy-mm-dd hh24:mi:ss')" +
				" And a.opdcotor_chr=b.empid_chr And a.registertypeid_chr=c.registertypeid_chr and a.OPDEPT_CHR=d.DEPTID_CHR order by PLANPERIOD_CHR,OPDEPT_CHR";
			//			string strSQL="Select a.*,b.lastname_vchr,c.registertypename_vchr " +
			//                          " From t_opr_OPDoctorPlan a, t_bse_Employee b,t_bse_RegisterType c " +
			//                          " Where a.plandate_dat=to_date('"+strDate+"','yyyy-mm-dd hh24:mi:ss') And a.opdept_chr='"+strDepID+"' " +
			//                          " And a.opdcotor_chr=b.empid_chr And a.registertypeid_chr=c.registertypeid_chr  ";
			try
			{
				DataTable dtbResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbResult);
				//				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbResult);
				objHRPSvc.Dispose();

				if(lngRes > 0 && dtbResult.Rows.Count > 0)
				{
					objPlan = new clsOPDoctorPlan_VO[dtbResult.Rows.Count];
	
					for(int i1=0;i1<objPlan.Length;i1++)
					{
						objPlan[i1] = new clsOPDoctorPlan_VO();
						if(dtbResult.Rows[i1]["MAXDIAGTIMES_INT"].ToString().Trim()!="")
							objPlan[i1].m_intMaxDiagTimes=int.Parse(dtbResult.Rows[i1]["MAXDIAGTIMES_INT"].ToString().Trim());
						objPlan[i1].m_objOPDept=new clsDepartmentVO();
						objPlan[i1].m_objOPDept.strDeptID=dtbResult.Rows[i1]["OPDEPT_CHR"].ToString().Trim();
						objPlan[i1].m_objOPDept.strDeptName=dtbResult.Rows[i1]["DEPTNAME_VCHR"].ToString().Trim();
						
						objPlan[i1].m_objOPDoctor=new clsEmployeeVO();
						objPlan[i1].m_objOPDoctor.strEmpID=dtbResult.Rows[i1]["OPDCOTOR_CHR"].ToString().Trim();
						objPlan[i1].m_objOPDoctor.strName=dtbResult.Rows[i1]["lastname_vchr"].ToString().Trim();
						objPlan[i1].m_objOPDoctor.strEmpNO=dtbResult.Rows[i1]["EMPNO_CHR"].ToString().Trim();
						objPlan[i1].m_strEndTime=dtbResult.Rows[i1]["ENDTIME_CHR"].ToString().Trim();
						objPlan[i1].m_strOPDrPlanID=dtbResult.Rows[i1]["OPDRPLANID_CHR"].ToString().Trim();
						objPlan[i1].m_strPlanDate=strDate;
						objPlan[i1].m_strStartTime=dtbResult.Rows[i1]["STARTTIME_CHR"].ToString().Trim();
						objPlan[i1].m_strPlanPeriod=dtbResult.Rows[i1]["planperiod_chr"].ToString().Trim();
						objPlan[i1].m_objRegisterType=new clsRegisterType_VO();
						objPlan[i1].m_objRegisterType.m_strRegisterTypeID=dtbResult.Rows[i1]["registertypeid_chr"].ToString().Trim();
						objPlan[i1].m_objRegisterType.m_strRegisterTypeName=dtbResult.Rows[i1]["registertypename_vchr"].ToString().Trim();
						objPlan[i1].m_objRecordEmp=new clsEmployeeVO();
						objPlan[i1].m_objRecordEmp.strEmpID=dtbResult.Rows[i1]["recordemp_chr"].ToString().Trim();
						objPlan[i1].m_objRecordDate=dtbResult.Rows[i1]["recorddate_dat"].ToString().Trim();
						objPlan[i1].m_strOPAddress=dtbResult.Rows[i1]["OPADDRESS_VCHR"].ToString().Trim();
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

        //用于门诊和排班
		#region  查找某个医生的日排班记录 Sam 2004-6-2
		/// <summary>
		///  查找某个医生的日排班记录
		/// </summary>
		[AutoComplete]
		public long m_lngGetDocPlan(System.Security.Principal.IPrincipal p_objPrincipal,string strDate,string strPerio,
			string strDocID,out clsOPDoctorPlan_VO objPlan)
		{
			objPlan=new clsOPDoctorPlan_VO();
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc","m_lngGetPlanByDateAndDep");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL=@"select a.opdrplanid_chr,
       a.plandate_dat,
       a.starttime_chr,
       a.endtime_chr,
       a.opdcotor_chr,
       a.opdept_chr,
       a.maxdiagtimes_int,
       a.registertypeid_chr,
       a.planperiod_chr,
       a.recordemp_chr,
       a.recorddate_dat,
       a.opaddress_vchr,
       a.optimes_int,b.lastname_vchr,c.registertypename_vchr,d.deptname_vchr " +
				" from t_opr_opdoctorplan a, t_bse_employee b,t_bse_registertype c,t_bse_deptbaseinfo d " +
				" Where a.plandate_dat=to_date('"+strDate+"','yyyy-mm-dd hh24:mi:ss') And a.planperiod_chr='"+strPerio+"' " +
				" And a.opdcotor_chr='"+strDocID+"' " +
				" And a.opdcotor_chr=b.empid_chr And a.registertypeid_chr=c.registertypeid_chr And a.opdept_chr=d.deptid_chr order by PLANPERIOD_CHR,OPDEPT_CHR";
			try
			{
				DataTable dtbResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes=objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbResult);
				objHRPSvc.Dispose();

				if(lngRes > 0 && dtbResult.Rows.Count > 0)
				{
					if(dtbResult.Rows[0]["MAXDIAGTIMES_INT"].ToString().Trim()!="")
						objPlan.m_intMaxDiagTimes=int.Parse(dtbResult.Rows[0]["MAXDIAGTIMES_INT"].ToString().Trim());
					objPlan.m_objOPDept=new clsDepartmentVO();
					objPlan.m_objOPDept.strDeptID=dtbResult.Rows[0]["opdept_chr"].ToString().Trim();
					objPlan.m_objOPDept.strDeptName=dtbResult.Rows[0]["deptname_vchr"].ToString().Trim();
					objPlan.m_objOPDoctor=new clsEmployeeVO();
					objPlan.m_objOPDoctor.strEmpID=dtbResult.Rows[0]["OPDCOTOR_CHR"].ToString().Trim();
					objPlan.m_objOPDoctor.strName=dtbResult.Rows[0]["lastname_vchr"].ToString().Trim();
					objPlan.m_strEndTime=dtbResult.Rows[0]["ENDTIME_CHR"].ToString().Trim();
					objPlan.m_strOPDrPlanID=dtbResult.Rows[0]["OPDRPLANID_CHR"].ToString().Trim();
					objPlan.m_strPlanDate=strDate;
					objPlan.m_strStartTime=dtbResult.Rows[0]["STARTTIME_CHR"].ToString().Trim();
					objPlan.m_strPlanPeriod=dtbResult.Rows[0]["planperiod_chr"].ToString().Trim();
					objPlan.m_objRegisterType=new clsRegisterType_VO();
					objPlan.m_objRegisterType.m_strRegisterTypeID=dtbResult.Rows[0]["registertypeid_chr"].ToString().Trim();
					objPlan.m_objRegisterType.m_strRegisterTypeName=dtbResult.Rows[0]["registertypename_vchr"].ToString().Trim();
					objPlan.m_objRecordEmp=new clsEmployeeVO();
					objPlan.m_objRecordEmp.strEmpID=dtbResult.Rows[0]["recordemp_chr"].ToString().Trim();
					objPlan.m_objRecordDate=dtbResult.Rows[0]["recorddate_dat"].ToString().Trim();
					objPlan.m_strOPAddress=dtbResult.Rows[0]["OPADDRESS_VCHR"].ToString().Trim();
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

		#region 查询当前的排班
		
		[AutoComplete]
		public long m_lngGetPlanByday(System.Security.Principal.IPrincipal p_objPrincipal,string strdate, out clsOPDoctorPlan_VO[] p_objResult)
		{
			p_objResult = new clsOPDoctorPlan_VO[0];
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngGetPlanByday");
			if(lngRes < 0)
			{
				return -1;
			}
            string strSQL = @"select distinct a.opdrplanid_chr,
       a.plandate_dat,
       a.starttime_chr,
       a.endtime_chr,
       a.opdcotor_chr,
       a.opdept_chr,
       a.maxdiagtimes_int,
       a.registertypeid_chr,
       a.planperiod_chr,
       a.recordemp_chr,
       a.recorddate_dat,
       a.opaddress_vchr,
       a.optimes_int,b.lastname_vchr as doctorname,c.lastname_vchr as recorempname,d.DEPTNAME_VCHR,e.registertypename_vchr,e.isdoctor_num from t_opr_opdoctorplan a ,
T_BSE_EMPLOYEE b 
, T_BSE_EMPLOYEE c 
, T_bse_deptdesc d 
, t_bse_RegisterType e  WHERE  a.opdcotor_chr=b.EMPID_CHR(+) and a.recordemp_chr=c.EMPID_CHR(+) and a.opdept_chr = d.DEPTID_CHR and a.registertypeid_chr=e.registertypeid_chr and a.plandate_dat = to_date('" +strdate+"','yyyy-mm-dd') order by a.PLANPERIOD_CHR,a.OPDEPT_CHR";
			try
			{

				DataTable dtbResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbResult);
				objHRPSvc.Dispose();
				if(lngRes > 0 && dtbResult.Rows.Count > 0)
				{
					p_objResult = new clsOPDoctorPlan_VO[dtbResult.Rows.Count];
					dtbResult.DefaultView.RowFilter = "PLANPERIOD_CHR = '上午'";
					int x=0;
					int i = 0;
					for(i=0;i<dtbResult.DefaultView.Count;i++)
					{
						p_objResult[x] = new clsOPDoctorPlan_VO();
						p_objResult[x].m_objRecordEmp = new clsEmployeeVO();
						p_objResult[x].m_objOPDoctor = new clsEmployeeVO();
						p_objResult[x].m_objRegisterType = new clsRegisterType_VO();
						p_objResult[x].m_objOPDept = new clsDepartmentVO();
						p_objResult[x].m_strOPDrPlanID = dtbResult.DefaultView[i]["OPDRPLANID_CHR"].ToString().Trim();
						p_objResult[x].m_strPlanDate = Convert.ToDateTime(dtbResult.DefaultView[i]["PLANDATE_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
						p_objResult[x].m_strStartTime = dtbResult.DefaultView[i]["STARTTIME_CHR"].ToString().Trim();
						p_objResult[x].m_strEndTime = dtbResult.DefaultView[i]["ENDTIME_CHR"].ToString().Trim();
						p_objResult[x].m_objOPDoctor.strEmpID = dtbResult.DefaultView[i]["OPDCOTOR_CHR"].ToString().Trim();
						p_objResult[x].m_objOPDoctor.strLastName = dtbResult.DefaultView[i]["doctorname"].ToString().Trim();
						p_objResult[x].m_objOPDept.strDeptID = dtbResult.DefaultView[i]["OPDEPT_CHR"].ToString().Trim();
						p_objResult[x].m_objOPDept.strDeptName = dtbResult.DefaultView[i]["DEPTNAME_VCHR"].ToString().Trim();
						p_objResult[x].m_intMaxDiagTimes = Convert.ToInt32(dtbResult.DefaultView[i]["MAXDIAGTIMES_INT"].ToString().Trim());
						p_objResult[x].m_objRegisterType.m_strRegisterTypeID = dtbResult.DefaultView[i]["REGISTERTYPEID_CHR"].ToString().Trim();
						p_objResult[x].m_objRegisterType.m_strRegisterTypeName = dtbResult.DefaultView[i]["registertypename_vchr"].ToString().Trim();
						p_objResult[x].m_strPlanPeriod = dtbResult.DefaultView[i]["PLANPERIOD_CHR"].ToString().Trim();
						p_objResult[x].m_objRecordEmp.strEmpID = dtbResult.DefaultView[i]["RECORDEMP_CHR"].ToString().Trim();
						p_objResult[x].m_objRecordEmp.strLastName = dtbResult.DefaultView[i]["recorempname"].ToString().Trim();
						p_objResult[x].m_objRecordDate = Convert.ToDateTime(dtbResult.DefaultView[i]["RECORDDATE_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
						p_objResult[x].m_strOPAddress = dtbResult.DefaultView[i]["OPADDRESS_VCHR"].ToString().Trim();
						p_objResult[x].m_strOPTIMES = dtbResult.DefaultView[i]["OPTIMES_INT"].ToString().Trim();
						if(dtbResult.DefaultView[i]["isdoctor_num"] != Convert.DBNull)
						{
							p_objResult[x].m_objRegisterType.m_decRegPay = decimal.Parse(dtbResult.DefaultView[i]["isdoctor_num"].ToString().Trim());
						}
						x ++;
					}
					dtbResult.DefaultView.RowFilter = "PLANPERIOD_CHR = '下午'";
					for(i=0;i<dtbResult.DefaultView.Count;i++)
					{
						p_objResult[x] = new clsOPDoctorPlan_VO();
						p_objResult[x].m_objRecordEmp = new clsEmployeeVO();
						p_objResult[x].m_objOPDoctor = new clsEmployeeVO();
						p_objResult[x].m_objRegisterType = new clsRegisterType_VO();
						p_objResult[x].m_objOPDept = new clsDepartmentVO();
						p_objResult[x].m_strOPDrPlanID = dtbResult.DefaultView[i]["OPDRPLANID_CHR"].ToString().Trim();
						p_objResult[x].m_strPlanDate = Convert.ToDateTime(dtbResult.DefaultView[i]["PLANDATE_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
						p_objResult[x].m_strStartTime = dtbResult.DefaultView[i]["STARTTIME_CHR"].ToString().Trim();
						p_objResult[x].m_strEndTime = dtbResult.DefaultView[i]["ENDTIME_CHR"].ToString().Trim();
						p_objResult[x].m_objOPDoctor.strEmpID = dtbResult.DefaultView[i]["OPDCOTOR_CHR"].ToString().Trim();
						p_objResult[x].m_objOPDoctor.strLastName = dtbResult.DefaultView[i]["doctorname"].ToString().Trim();
						p_objResult[x].m_objOPDept.strDeptID = dtbResult.DefaultView[i]["OPDEPT_CHR"].ToString().Trim();
						p_objResult[x].m_objOPDept.strDeptName = dtbResult.DefaultView[i]["DEPTNAME_VCHR"].ToString().Trim();
						p_objResult[x].m_intMaxDiagTimes = Convert.ToInt32(dtbResult.DefaultView[i]["MAXDIAGTIMES_INT"].ToString().Trim());
						p_objResult[x].m_objRegisterType.m_strRegisterTypeID = dtbResult.DefaultView[i]["REGISTERTYPEID_CHR"].ToString().Trim();
						p_objResult[x].m_objRegisterType.m_strRegisterTypeName = dtbResult.DefaultView[i]["registertypename_vchr"].ToString().Trim();
						p_objResult[x].m_strPlanPeriod = dtbResult.DefaultView[i]["PLANPERIOD_CHR"].ToString().Trim();
						p_objResult[x].m_objRecordEmp.strEmpID = dtbResult.DefaultView[i]["RECORDEMP_CHR"].ToString().Trim();
						p_objResult[x].m_objRecordEmp.strLastName = dtbResult.DefaultView[i]["recorempname"].ToString().Trim();
						p_objResult[x].m_objRecordDate = Convert.ToDateTime(dtbResult.DefaultView[i]["RECORDDATE_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
						p_objResult[x].m_strOPAddress = dtbResult.DefaultView[i]["OPADDRESS_VCHR"].ToString().Trim();
						p_objResult[x].m_strOPTIMES = dtbResult.DefaultView[i]["OPTIMES_INT"].ToString().Trim();
						if(dtbResult.DefaultView[i]["isdoctor_num"] != Convert.DBNull)
						{
							p_objResult[x].m_objRegisterType.m_decRegPay = decimal.Parse(dtbResult.DefaultView[i]["isdoctor_num"].ToString().Trim());
						}
						x++;
					}
					dtbResult.DefaultView.RowFilter = "PLANPERIOD_CHR = '晚上'";
					for(i=0;i<dtbResult.DefaultView.Count;i++)
					{
						p_objResult[x] = new clsOPDoctorPlan_VO();
						p_objResult[x].m_objRecordEmp = new clsEmployeeVO();
						p_objResult[x].m_objOPDoctor = new clsEmployeeVO();
						p_objResult[x].m_objRegisterType = new clsRegisterType_VO();
						p_objResult[x].m_objOPDept = new clsDepartmentVO();
						p_objResult[x].m_strOPDrPlanID = dtbResult.DefaultView[i]["OPDRPLANID_CHR"].ToString().Trim();
						p_objResult[x].m_strPlanDate = Convert.ToDateTime(dtbResult.DefaultView[i]["PLANDATE_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
						p_objResult[x].m_strStartTime = dtbResult.DefaultView[i]["STARTTIME_CHR"].ToString().Trim();
						p_objResult[x].m_strEndTime = dtbResult.DefaultView[i]["ENDTIME_CHR"].ToString().Trim();
						p_objResult[x].m_objOPDoctor.strEmpID = dtbResult.DefaultView[i]["OPDCOTOR_CHR"].ToString().Trim();
						p_objResult[x].m_objOPDoctor.strLastName = dtbResult.DefaultView[i]["doctorname"].ToString().Trim();
						p_objResult[x].m_objOPDept.strDeptID = dtbResult.DefaultView[i]["OPDEPT_CHR"].ToString().Trim();
						p_objResult[x].m_objOPDept.strDeptName = dtbResult.DefaultView[i]["DEPTNAME_VCHR"].ToString().Trim();
						p_objResult[x].m_intMaxDiagTimes = Convert.ToInt32(dtbResult.DefaultView[i]["MAXDIAGTIMES_INT"].ToString().Trim());
						p_objResult[x].m_objRegisterType.m_strRegisterTypeID = dtbResult.DefaultView[i]["REGISTERTYPEID_CHR"].ToString().Trim();
						p_objResult[x].m_objRegisterType.m_strRegisterTypeName = dtbResult.DefaultView[i]["registertypename_vchr"].ToString().Trim();
						p_objResult[x].m_strPlanPeriod = dtbResult.DefaultView[i]["PLANPERIOD_CHR"].ToString().Trim();
						p_objResult[x].m_objRecordEmp.strEmpID = dtbResult.DefaultView[i]["RECORDEMP_CHR"].ToString().Trim();
						p_objResult[x].m_objRecordEmp.strLastName = dtbResult.DefaultView[i]["recorempname"].ToString().Trim();
						p_objResult[x].m_objRecordDate = Convert.ToDateTime(dtbResult.DefaultView[i]["RECORDDATE_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
						p_objResult[x].m_strOPAddress = dtbResult.DefaultView[i]["OPADDRESS_VCHR"].ToString().Trim();
						p_objResult[x].m_strOPTIMES = dtbResult.DefaultView[i]["OPTIMES_INT"].ToString().Trim();
						if(dtbResult.DefaultView[i]["isdoctor_num"] != Convert.DBNull)
						{
							p_objResult[x].m_objRegisterType.m_decRegPay = decimal.Parse(dtbResult.DefaultView[i]["isdoctor_num"].ToString().Trim());
						}
						x++;
					}
					dtbResult.DefaultView.RowFilter = "PLANPERIOD_CHR = '全天'";
					for(i=0;i<dtbResult.DefaultView.Count;i++)
					{
						p_objResult[x] = new clsOPDoctorPlan_VO();
						p_objResult[x].m_objRecordEmp = new clsEmployeeVO();
						p_objResult[x].m_objOPDoctor = new clsEmployeeVO();
						p_objResult[x].m_objRegisterType = new clsRegisterType_VO();
						p_objResult[x].m_objOPDept = new clsDepartmentVO();
						p_objResult[x].m_strOPDrPlanID = dtbResult.DefaultView[i]["OPDRPLANID_CHR"].ToString().Trim();
						p_objResult[x].m_strPlanDate = Convert.ToDateTime(dtbResult.DefaultView[i]["PLANDATE_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
						p_objResult[x].m_strStartTime = dtbResult.DefaultView[i]["STARTTIME_CHR"].ToString().Trim();
						p_objResult[x].m_strEndTime = dtbResult.DefaultView[i]["ENDTIME_CHR"].ToString().Trim();
						p_objResult[x].m_objOPDoctor.strEmpID = dtbResult.DefaultView[i]["OPDCOTOR_CHR"].ToString().Trim();
						p_objResult[x].m_objOPDoctor.strLastName = dtbResult.DefaultView[i]["doctorname"].ToString().Trim();
						p_objResult[x].m_objOPDept.strDeptID = dtbResult.DefaultView[i]["OPDEPT_CHR"].ToString().Trim();
						p_objResult[x].m_objOPDept.strDeptName = dtbResult.DefaultView[i]["DEPTNAME_VCHR"].ToString().Trim();
						p_objResult[x].m_intMaxDiagTimes = Convert.ToInt32(dtbResult.DefaultView[i]["MAXDIAGTIMES_INT"].ToString().Trim());
						p_objResult[x].m_objRegisterType.m_strRegisterTypeID = dtbResult.DefaultView[i]["REGISTERTYPEID_CHR"].ToString().Trim();
						p_objResult[x].m_objRegisterType.m_strRegisterTypeName = dtbResult.DefaultView[i]["registertypename_vchr"].ToString().Trim();
						p_objResult[x].m_strPlanPeriod = dtbResult.DefaultView[i]["PLANPERIOD_CHR"].ToString().Trim();
						p_objResult[x].m_objRecordEmp.strEmpID = dtbResult.DefaultView[i]["RECORDEMP_CHR"].ToString().Trim();
						p_objResult[x].m_objRecordEmp.strLastName = dtbResult.DefaultView[i]["recorempname"].ToString().Trim();
						p_objResult[x].m_objRecordDate = Convert.ToDateTime(dtbResult.DefaultView[i]["RECORDDATE_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
						p_objResult[x].m_strOPAddress = dtbResult.DefaultView[i]["OPADDRESS_VCHR"].ToString().Trim();
						p_objResult[x].m_strOPTIMES = dtbResult.DefaultView[i]["OPTIMES_INT"].ToString().Trim();
						if(dtbResult.DefaultView[i]["isdoctor_num"] != Convert.DBNull)
						{
							p_objResult[x].m_objRegisterType.m_decRegPay = decimal.Parse(dtbResult.DefaultView[i]["isdoctor_num"].ToString().Trim());
						}
						x++;
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

        //用于门诊挂号
		#region  通过日期、时间段、科室和挂号类型取门诊 医生 列表 Sam 2004-6-2
		/// <summary>
		///  通过日期、时间段、科室和挂号类型取门诊医生列表
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="objPlan"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngGetOPDoctorList(System.Security.Principal.IPrincipal p_objPrincipal,
			   string strDate, string strPerio,string strDepID,string strRegType,
			   out clsEmployeeVO[] objDoctor)
		{
			objDoctor=new clsEmployeeVO[0];
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc","m_lngGetOPDoctorListByDate");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL;
//			if(strDepID != null & strDepID != "")
//			{
			strSQL = @"select * from
(
select a.empid_chr,
       a.begindate_dat,
       a.firstname_vchr,
       a.lastname_vchr,
       a.empidcard_chr,
       a.pycode_chr,
       a.sex_chr,
       a.educationallevel_chr,
       a.maritalstatus_chr,
       a.technicalrank_chr,
       a.languageability_vchr,
       a.birthdate_dat,
       a.officephone_vchr,
       a.homephone_vchr,
       a.mobile_vchr,
       a.officeaddress_vchr,
       a.officezip_chr,
       a.homeaddress_vchr,
       a.homezip_chr,
       a.email_vchr,
       a.contactname_vchr,
       a.contactphone_vchr,
       a.remark_vchr,
       a.status_int,
       a.deactivate_dat,
       a.shortname_chr,
       a.operatorid_chr,
       a.hasprescriptionright_chr,
       a.haspsychosisprescriptionright_,
       a.hasopiateprescriptionright_chr,
       a.isexpert_chr,
       a.expertfee_mny,
       a.isexternalexpert_chr,
       a.ancestoraddr_vchar,
       a.experience_vchr,
       a.psw_chr,
       a.deptcode_chr,
       a.technicallevel_chr,
       a.digitalsign_dta,
       a.extendid_vchr,
       a.isemployee_int,
       a.empno_chr,
       a.employeeidentity_int,
       a.empduty_int,0 as orderstr from t_bse_employee a,t_bse_deptemp b 
where a.empid_chr=b.empid_chr(+) and b.end_dat is null 
and (A.PYCODE_CHR like '" + strPerio+@"%' or A.LASTNAME_VCHR like '"+strPerio+@"%' or A.EMPNO_CHR like '"+strPerio+@"%') 
and A.STATUS_INT =1 and A.HASPRESCRIPTIONRIGHT_CHR =1 ";
			if(strDepID.Trim()!="")
			{
				strSQL+=" and b.deptid_chr ='"+strDepID+"'";
			}

 strSQL+= @" union 
select a.empid_chr,
       a.begindate_dat,
       a.firstname_vchr,
       a.lastname_vchr,
       a.empidcard_chr,
       a.pycode_chr,
       a.sex_chr,
       a.educationallevel_chr,
       a.maritalstatus_chr,
       a.technicalrank_chr,
       a.languageability_vchr,
       a.birthdate_dat,
       a.officephone_vchr,
       a.homephone_vchr,
       a.mobile_vchr,
       a.officeaddress_vchr,
       a.officezip_chr,
       a.homeaddress_vchr,
       a.homezip_chr,
       a.email_vchr,
       a.contactname_vchr,
       a.contactphone_vchr,
       a.remark_vchr,
       a.status_int,
       a.deactivate_dat,
       a.shortname_chr,
       a.operatorid_chr,
       a.hasprescriptionright_chr,
       a.haspsychosisprescriptionright_,
       a.hasopiateprescriptionright_chr,
       a.isexpert_chr,
       a.expertfee_mny,
       a.isexternalexpert_chr,
       a.ancestoraddr_vchar,
       a.experience_vchr,
       a.psw_chr,
       a.deptcode_chr,
       a.technicallevel_chr,
       a.digitalsign_dta,
       a.extendid_vchr,
       a.isemployee_int,
       a.empno_chr,
       a.employeeidentity_int,
       a.empduty_int,1 as orderstr from t_bse_employee a where a.status_int =1 
and A.HASPRESCRIPTIONRIGHT_CHR =1 and (A.PYCODE_CHR like '" + strPerio+@"%' 
or A.LASTNAME_VCHR like '"+strPerio+@"%' or A.EMPNO_CHR like '"+strPerio+@"%')
)
ORDER BY ORDERSTR";
//			strSQL = @"select A.* from t_bse_employee A,T_BSE_DEPTEMP B where A.empid_chr=b.empid_chr(+) and b.end_dat is null and (A.PYCODE_CHR like '%' or A.LASTNAME_VCHR like '%' or A.EMPNO_CHR like '%') and A.STATUS_INT =1 and A.HASPRESCRIPTIONRIGHT_CHR =1 ";
//			if(strDepID.Trim()!="")
//			{
//			strSQL+="and b.deptid_chr ='"+strDepID+"'";
//			}

//			strSQL+=" order by A.EMPNO_CHR  union select A.* from t_bse_employee A where A.STATUS_INT =1 and A.HASPRESCRIPTIONRIGHT_CHR =1 and (A.PYCODE_CHR like '%' or A.LASTNAME_VCHR like '%' or A.EMPNO_CHR like '%') order by A.EMPNO_CHR";
				//left join  (select * from t_opr_opdoctorplan  where plandate_dat = to_date('"+strDate+"','yyyy-mm-dd') " + ") b on b.opdcotor_chr = c.empid_chr order by c.empid_chr";
//			}EMPID_CHR
//			else
//			{
//			strSQL = @"select a.* from (select a.*,nvl(b.maxdiagtimes_int,-1) as maxdiagtimes_int ,nvl
//(b.OPTIMES_INT,-1) as PlanOPTIMES_INT from t_bse_employee a left join (select * from t_opr_opdoctorplan where plandate_dat = to_date('"+strDate+"','yyyy-mm-dd') " + @") b on b.opdcotor_chr = a.empid_chr) a";
////,(select empid_chr,max(DEPTID_chr) as DEPTID from  T_BSE_DEPTEMP group by empid_chr) b,T_BSE_DEPTDESC c where a.empid_chr=b.empid_chr and b.DEPTID = c.DEPTID_CHR";
//			}

//			string strSQL="SELECT distinct b.empid_chr, b.lastname_vchr,a.maxdiagtimes_int " +
//                          "FROM t_opr_opdoctorplan a, t_bse_employee b " +
//                          " WHERE a.plandate_dat = to_date('"+strDate+"','yyyy-mm-dd') " +
//				          " And a.planperiod_chr='"+strPerio+"' ";
//			if(strDepID!=null)
//				strSQL=strSQL+ "and a.OPDEPT_CHR='"+strDepID+"'  ";
//			if(strRegType!=null)
//                strSQL=strSQL+ "and a.REGISTERTYPEID_CHR='"+strRegType+"' "; 

//            strSQL=strSQL+" AND a.opdcotor_chr = b.empid_chr(+) " ;
//			DateTime sDate=Convert.ToDateTime(strDate);
//			System.Data.IDataParameter[] objPar=clsIDataParameterCreator.s_objConstructIDataParameterArr(new object[]{sDate,strDepID,strPerio});
				try
			{
				DataTable dtbResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbResult);		
				objHRPSvc.Dispose();

				if(lngRes > 0 && dtbResult.Rows.Count > 0)
				{
					objDoctor = new clsEmployeeVO[dtbResult.Rows.Count];
	
					for(int i1=0;i1<objDoctor.Length;i1++)
					{
						objDoctor[i1] = new clsEmployeeVO();
						objDoctor[i1].strEmpID = dtbResult.Rows[i1]["empid_chr"].ToString().Trim();
						objDoctor[i1].strName = dtbResult.Rows[i1]["lastname_vchr"].ToString().Trim();
						objDoctor[i1].strEmpNO = dtbResult.Rows[i1]["EMPNO_CHR"].ToString().Trim();
						objDoctor[i1].strPYCode = dtbResult.Rows[i1]["PYCODE_CHR"].ToString().Trim();
						objDoctor[i1].strIsExpert = dtbResult.Rows[i1]["ISEXPERT_CHR"].ToString().Trim();
						objDoctor[i1].strIsExternalExpert = dtbResult.Rows[i1]["ISEXTERNALEXPERT_CHR"].ToString().Trim();
						objDoctor[i1].strOfficePhone = dtbResult.Rows[i1]["ORDERSTR"].ToString().Trim();//用表示排序号 
                        objDoctor[i1].strTechnicalRank = dtbResult.Rows[i1]["technicalrank_chr"].ToString().Trim();
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
        [AutoComplete]
		public long m_lngGetOPDoctorListForReg(System.Security.Principal.IPrincipal p_objPrincipal,
			string strDepID,out clsEmployeeVO[] objDoctor)
		{
			objDoctor=new clsEmployeeVO[0];
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc","m_lngGetOPDoctorListByDate");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL;
			string strSQL1;
			if(strDepID != "" && strDepID != null)
			{
				strSQL = @"select a.EMPNO_CHR,a.lastname_vchr,a.PYCODE_CHR,a.empid_chr,b.DEPTID_CHR from t_bse_employee a,t_bse_deptemp b,T_BSE_DEPTDESC c where b.DEPTID_CHR = '"+strDepID+"' and a.HASPRESCRIPTIONRIGHT_CHR = 1 and a.EMPID_CHR=b.EMPID_CHR and a.STATUS_INT =1 and c.DEPTID_CHR=b.DEPTID_CHR order by EMPNO_CHR";
				strSQL1=@"select a.EMPNO_CHR,a.lastname_vchr,a.PYCODE_CHR,a.empid_chr,b.DEPTID_CHR  from t_bse_employee a,t_bse_deptemp b,T_BSE_DEPTDESC c  where b.DEPTID_CHR<>'"+strDepID+@"' and a.HASPRESCRIPTIONRIGHT_CHR = 1 and a.STATUS_INT =1 and a.EMPID_CHR=b.EMPID_CHR and c.DEPTID_CHR=b.DEPTID_CHR  order by EMPNO_CHR";
				try
				{
					DataTable dtbResult = new DataTable();
					DataTable dtbResult1 = new DataTable();
					com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
					lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL1,ref dtbResult1);
					lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbResult);	
					objHRPSvc.Dispose();
					bool isRe;
					if(dtbResult1.Rows.Count>0)
					{
						for(int i1=0;i1<dtbResult1.Rows.Count;i1++)
						{
							isRe=false;
							for(int f2=0;f2<dtbResult.Rows.Count;f2++)
							{
								if(dtbResult1.Rows[i1]["empid_chr"].ToString()==dtbResult.Rows[f2]["empid_chr"].ToString())
								{			
									isRe=true;
									break;
								}
							}
					
							if(!isRe)
							{
								DataRow newRow=dtbResult.NewRow();
								newRow["empid_chr"]=dtbResult1.Rows[i1]["empid_chr"];
								newRow["lastname_vchr"]=dtbResult1.Rows[i1]["lastname_vchr"];
								newRow["EMPNO_CHR"]=dtbResult1.Rows[i1]["EMPNO_CHR"];
								newRow["DEPTID_CHR"]=dtbResult1.Rows[i1]["DEPTID_CHR"];
								newRow["PYCODE_CHR"]=dtbResult1.Rows[i1]["PYCODE_CHR"];
								dtbResult.Rows.Add(newRow);
							}
						}
					}

					if(dtbResult.Rows.Count > 0)
					{
						objDoctor = new clsEmployeeVO[dtbResult.Rows.Count];
	
						for(int i1=0;i1<objDoctor.Length;i1++)
						{
						
								objDoctor[i1] = new clsEmployeeVO();
								objDoctor[i1].strEmpID=dtbResult.Rows[i1]["empid_chr"].ToString().Trim();
								objDoctor[i1].strName=dtbResult.Rows[i1]["lastname_vchr"].ToString().Trim();
								objDoctor[i1].strEmpNO=dtbResult.Rows[i1]["EMPNO_CHR"].ToString().Trim();
								objDoctor[i1].strDEPTID_CHR=dtbResult.Rows[i1]["DEPTID_CHR"].ToString().Trim();
								objDoctor[i1].strPYCode=dtbResult.Rows[i1]["PYCODE_CHR"].ToString().Trim();

						}    
					}			
				}
				catch(Exception objEx)
				{
					string strTmp=objEx.Message;
					com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
					bool blnRes = objLogger.LogError(objEx);
				}
			}
			else
			{
                strSQL = @"select a.empid_chr,
       a.begindate_dat,
       a.firstname_vchr,
       a.lastname_vchr,
       a.empidcard_chr,
       a.pycode_chr,
       a.sex_chr,
       a.educationallevel_chr,
       a.maritalstatus_chr,
       a.technicalrank_chr,
       a.languageability_vchr,
       a.birthdate_dat,
       a.officephone_vchr,
       a.homephone_vchr,
       a.mobile_vchr,
       a.officeaddress_vchr,
       a.officezip_chr,
       a.homeaddress_vchr,
       a.homezip_chr,
       a.email_vchr,
       a.contactname_vchr,
       a.contactphone_vchr,
       a.remark_vchr,
       a.status_int,
       a.deactivate_dat,
       a.shortname_chr,
       a.operatorid_chr,
       a.hasprescriptionright_chr,
       a.haspsychosisprescriptionright_,
       a.hasopiateprescriptionright_chr,
       a.isexpert_chr,
       a.expertfee_mny,
       a.isexternalexpert_chr,
       a.ancestoraddr_vchar,
       a.experience_vchr,
       a.psw_chr,
       a.deptcode_chr,
       a.technicallevel_chr,
       a.digitalsign_dta,
       a.extendid_vchr,
       a.isemployee_int,
       a.empno_chr,
       a.employeeidentity_int,
       a.empduty_int from t_bse_employee a where hasprescriptionright_chr = 1 and status_int =1 order by empno_chr";
				try
				{
					DataTable dtbResult = new DataTable();
					com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
					lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbResult);		
					objHRPSvc.Dispose();

					if(lngRes > 0 && dtbResult.Rows.Count > 0)
					{
						objDoctor = new clsEmployeeVO[dtbResult.Rows.Count];
	
						for(int i1=0;i1<objDoctor.Length;i1++)
						{
							objDoctor[i1] = new clsEmployeeVO();
							objDoctor[i1].strEmpID=dtbResult.Rows[i1]["empid_chr"].ToString().Trim();
							objDoctor[i1].strName=dtbResult.Rows[i1]["lastname_vchr"].ToString().Trim();
							objDoctor[i1].strEmpNO=dtbResult.Rows[i1]["EMPNO_CHR"].ToString().Trim();
							objDoctor[i1].strPYCode=dtbResult.Rows[i1]["PYCODE_CHR"].ToString().Trim();
                            objDoctor[i1].strTechnicalRank = dtbResult.Rows[i1]["technicalrank_chr"].ToString().Trim();

						}    
					}			
				}
				catch(Exception objEx)
				{
					string strTmp=objEx.Message;
					com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
					bool blnRes = objLogger.LogError(objEx);
				}
			}
			return lngRes;
		}

        //用于门诊挂号
		#region  通过日期和时间段取门诊 科室 列表 Sam 2004-6-2
		/// <summary>
		///  通过日期和时间段取门诊科室列表
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="objPlan"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngGetOPDeptListByDate(System.Security.Principal.IPrincipal p_objPrincipal,string strDate,string strPerio,out clsDepartmentVO[] objDep)
		{
			objDep=new clsDepartmentVO[0];
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc","m_lngGetOPDeptListByDate");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}

			string strSQL=@"select * from T_BSE_DEPTDESC where CATEGORY_INT=0 and (ATTRIBUTEID = '0000002' or ATTRIBUTEID ='0000001') and DEPTNAME_VCHR <> '所有'  and (DEPTNAME_VCHR like ? OR SHORTNO_CHR like ?
OR PYCODE_CHR like ?) ";
			if(strDate.Trim()!="")
			{
			strSQL+=" and INPATIENTOROUTPATIENT_INT = 0"; 
			}
			strSQL+=" order by SHORTNO_CHR";

			try
			{
				DataTable dtbResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				System.Data.IDataParameter[] objLisAddItemRefArr = null;
				objHRPSvc.CreateDatabaseParameter(3,out objLisAddItemRefArr);
				objLisAddItemRefArr[0].Value = strPerio;
				objLisAddItemRefArr[1].Value = strPerio;
				objLisAddItemRefArr[2].Value = strPerio;
				lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL,ref dtbResult,objLisAddItemRefArr);
				objHRPSvc.Dispose();

				if(lngRes > 0 && dtbResult.Rows.Count > 0)
				{
					objDep = new clsDepartmentVO[dtbResult.Rows.Count];
	
					for(int i1=0;i1<objDep.Length;i1++)
					{
						objDep[i1] = new clsDepartmentVO();
						objDep[i1].strDeptID=dtbResult.Rows[i1]["DEPTID_CHR"].ToString().Trim();
						objDep[i1].strDeptName=dtbResult.Rows[i1]["DEPTNAME_VCHR"].ToString().Trim();
						objDep[i1].strShortNo=dtbResult.Rows[i1]["SHORTNO_CHR"].ToString().Trim();
						objDep[i1].strPYCode=dtbResult.Rows[i1]["PYCODE_CHR"].ToString().Trim();
						objDep[i1].strAddress=dtbResult.Rows[i1]["ADDRESS_VCHR"].ToString().Trim();
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
        //用于门诊挂号
		#region  检查当前时间段是否存在日计划 Sam 2004-6-2
		/// <summary>
		///  检查当前时间段是否存在日计划
		/// </summary>
		[AutoComplete]
		public bool m_bnlCheckPlanByDatePerio(System.Security.Principal.IPrincipal p_objPrincipal,string strDate,string strPerio)
		{
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc","m_bnlCheckPlanByDatePerio");
			if(lngRes < 0) //没有使用的权限
			{
				return false;
			}
			string strSQL="Select * From t_opr_OPDoctorPlan  " +
            			  " Where plandate_dat=to_date('"+strDate+"','yyyy-mm-dd hh')  And planperiod_chr='"+strPerio+"' ";

			try
			{
				DataTable dtbResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbResult);
				objHRPSvc.Dispose();

				if(lngRes > 0 && dtbResult.Rows.Count > 0)
				{
                    return true; //存在排班计划
				}			
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return false;
		}
		#endregion
		 
		//周排班
		#region 增加周排班记录 Create by Sam 2004-6-2
		/// <summary>
		/// 增加日排班记录
		/// </summary>
		[AutoComplete]
		public long m_lngDoAddNewWeekPlan(System.Security.Principal.IPrincipal p_objPrincipal,clsOPDoctorWkPlan_VO objPlan,out string p_strRecordID)
		{
			long lngRes = 0;
			p_strRecordID = "";
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc","m_lngDoAddNewWeekPlan");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			//返回一最大的计划号
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			lngRes = objHRPSvc.lngGenerateID(18,"OPDRWKPLANID_CHR","T_OPR_OPDOCTORWKPLAN",out p_strRecordID);
			if(lngRes < 0)
				return lngRes;
			string strOperatorID=objPlan.m_objRecordEmp.strEmpID;
			string strWeek =objPlan.m_strPlanWeek;
			string strSQL ="INSERT INTO t_opr_opdoctorwkplan (opdrwkplanid_chr,planweek_chr,starttime_chr, " +
                           "endtime_chr,opdoctor_chr,opdept_chr,maxdiagtimes_int,registertypeid_chr,planperiod_chr,recordemp_chr, " +
                           "recorddate_dat,OPADDRESS_VCHR ) VALUES ('"+p_strRecordID+"','"+strWeek+"','"+objPlan.m_strStartTime+"', " +
						   "'"+objPlan.m_strEndTime+"','"+objPlan.m_objOPDoctor.strEmpID+"','"+objPlan.m_objOPDept.strDeptID+"', " +
                           "'"+objPlan.m_intMaxDiagTimes+"','"+objPlan.m_objRegisterType.m_strRegisterTypeID+"','"+objPlan.m_strPlanPeriod+"', " +
                           "'"+strOperatorID+"',sysdate,'"+objPlan.m_strOPAddress+"') ";
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
			return lngRes;
		}
		#endregion

		#region  更新周排班记录 Sam 2004-6-2
		/// <summary>
		///  更新周排班记录
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="objPlan"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDoUpdWeekPlanByID(System.Security.Principal.IPrincipal p_objPrincipal,clsOPDoctorWkPlan_VO objPlan)
		{
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc","m_lngDoUpdWeekPlanByID");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strOperatorID=objPlan.m_objRecordEmp.strEmpID;
			string strSQL = " UPDate t_opr_opdoctorwkplan Set planperiod_chr='"+objPlan.m_strPlanPeriod+"'," +
				"starttime_chr='"+objPlan.m_strStartTime+"',endtime_chr='"+objPlan.m_strEndTime+"',opdept_chr='"+objPlan.m_objOPDept.strDeptID+"', " +
				"maxdiagtimes_int='"+objPlan.m_intMaxDiagTimes+"',registertypeid_chr='"+objPlan.m_objRegisterType.m_strRegisterTypeID+"', " +
				"recordemp_chr='"+strOperatorID+"',recorddate_dat=sysdate,OPADDRESS_VCHR='"+objPlan.m_strOPAddress+"' " +
				" Where opdrwkplanid_chr='"+objPlan.m_strOPDrWkPlanID+"'" ;

			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.DoExcute(strSQL);				
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

		#region  删除周排班记录 Sam 2004-6-2
		/// <summary>
		///  删除周排班记录
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="strPlanID"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDeleteWeekPlanByID(System.Security.Principal.IPrincipal p_objPrincipal,string strPlanID)
		{
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc","m_lngDeleteWeekPlanByID");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL = "Delete t_opr_opdoctorwkplan " +
				" Where opdrwkplanid_chr='"+strPlanID+"'" ;

			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.DoExcute(strSQL);				
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

		#region  通过周取门诊 医生 列表 Sam 2004-6-2
		/// <summary>
		///  通过周取门诊医生列表
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="objPlan"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngGetOPDoctorListByWeekAndDep(System.Security.Principal.IPrincipal p_objPrincipal,string strWeek,string strDepID,out clsEmployeeVO[] objDoctor)
		{
			objDoctor=new clsEmployeeVO[0];
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc","m_lngGetOPDoctorListByWeekAndDep");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL;
            strSQL = @"select a.empid_chr,
       a.begindate_dat,
       a.firstname_vchr,
       a.lastname_vchr,
       a.empidcard_chr,
       a.pycode_chr,
       a.sex_chr,
       a.educationallevel_chr,
       a.maritalstatus_chr,
       a.technicalrank_chr,
       a.languageability_vchr,
       a.birthdate_dat,
       a.officephone_vchr,
       a.homephone_vchr,
       a.mobile_vchr,
       a.officeaddress_vchr,
       a.officezip_chr,
       a.homeaddress_vchr,
       a.homezip_chr,
       a.email_vchr,
       a.contactname_vchr,
       a.contactphone_vchr,
       a.remark_vchr,
       a.status_int,
       a.deactivate_dat,
       a.shortname_chr,
       a.operatorid_chr,
       a.hasprescriptionright_chr,
       a.haspsychosisprescriptionright_,
       a.hasopiateprescriptionright_chr,
       a.isexpert_chr,
       a.expertfee_mny,
       a.isexternalexpert_chr,
       a.ancestoraddr_vchar,
       a.experience_vchr,
       a.psw_chr,
       a.deptcode_chr,
       a.technicallevel_chr,
       a.digitalsign_dta,
       a.extendid_vchr,
       a.isemployee_int,
       a.empno_chr,
       a.employeeidentity_int,
       a.empduty_int from t_bse_employee a";
//			string strSQL="SELECT   b.empid_chr, b.lastname_vchr " +
//				"FROM t_opr_opdoctorwkplan a, t_bse_employee b " +
//				"WHERE a.planweek_chr = ? and a.OPDEPT_CHR=? " +
//				" AND a.opdcotor_chr = b.empid_chr(+) " +
//				" GROUP BY b.empid_chr, b.lastname_vchr " ;
			System.Data.IDataParameter[] objPar=clsIDataParameterCreator.s_objConstructIDataParameterArr(new object[]{strWeek,strDepID});
			try
			{
				DataTable dtbResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL,ref dtbResult,objPar);			
				objHRPSvc.Dispose();

				if(lngRes > 0 && dtbResult.Rows.Count > 0)
				{
					objDoctor = new clsEmployeeVO[dtbResult.Rows.Count];
	
					for(int i1=0;i1<objDoctor.Length;i1++)
					{
						objDoctor[i1] = new clsEmployeeVO();
						objDoctor[i1].strEmpID=dtbResult.Rows[i1]["empid_chr"].ToString().Trim();
						objDoctor[i1].strLastName=dtbResult.Rows[i1]["lastname_vchr"].ToString().Trim();
						objDoctor[i1].strEmpNO=dtbResult.Rows[i1]["EMPNO_CHR"].ToString().Trim();
						objDoctor[i1].strPYCode=dtbResult.Rows[i1]["PYCODE_CHR"].ToString().Trim();
                        objDoctor[i1].strTechnicalRank = dtbResult.Rows[i1]["technicalrank_chr"].ToString().Trim();
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

		#region  通过周取门诊 科室 列表 Sam 2004-6-2
		/// <summary>
		///  通过周取门诊科室列表
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="objPlan"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngGetOPDeptListByWeek(System.Security.Principal.IPrincipal p_objPrincipal,string strWeek,out clsDepartmentVO[] objDep)
		{
			objDep=new clsDepartmentVO[0];
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc","m_lngGetOPDeptListByWeek");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL="Select a.OPDEPT_CHR,b.DEPTNAME_VCHR From t_opr_opdoctorwkplan a,t_bse_DeptBaseInfo b " +
				" Where a.planweek_chr='"+strWeek+"' And  " +
				"a.OPDEPT_CHR=b.DEPTID_CHR(+) Group By a.OPDEPT_CHR,b.DEPTNAME_VCHR ";
			try
			{
				DataTable dtbResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbResult);
				objHRPSvc.Dispose();

				if(lngRes > 0 && dtbResult.Rows.Count > 0)
				{
					objDep = new clsDepartmentVO[dtbResult.Rows.Count];
	
					for(int i1=0;i1<objDep.Length;i1++)
					{
						objDep[i1] = new clsDepartmentVO();
						objDep[i1].strDeptID=dtbResult.Rows[i1]["OPDEPT_CHR"].ToString().Trim();
						objDep[i1].strDeptName=dtbResult.Rows[i1]["DEPTNAME_VCHR"].ToString().Trim();
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

		#region  通过周和科室取得排班记录 Sam 2004-6-2
		/// <summary>
		///  通过周和科室取得排班记录
		/// </summary>
		[AutoComplete]
		public long m_lngGetPlanByWeekAndDep(System.Security.Principal.IPrincipal p_objPrincipal,string strWeek,string strDepID,out clsOPDoctorWkPlan_VO[] objPlan)
		{
			objPlan=new clsOPDoctorWkPlan_VO[0];
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc","m_lngGetPlanByWeekAndDep");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
            string strSQL = "Select a.opdrwkplanid_chr, a.planweek_chr, a.starttime_chr, a.endtime_chr, a.opdoctor_chr, a.opdept_chr, a.maxdiagtimes_int, a.registertypeid_chr, a.planperiod_chr, a.recordemp_chr, a.recorddate_dat, a.opaddress_vchr,b.lastname_vchr,b.empno_chr,c.registertypename_vchr,d.deptname_vchr " +
                          " From t_opr_opdoctorwkplan a, t_bse_Employee b,t_bse_RegisterType c,t_bse_deptdesc d " +
                          " Where a.planweek_chr='"+strWeek+"' And a.opdept_chr='"+strDepID+"'  " +
                          " And a.opdoctor_chr=b.empid_chr And a.registertypeid_chr=c.registertypeid_chr And a.OPDEPT_CHR=d.DEPTID_CHR order by PLANPERIOD_CHR,OPDEPT_CHR";

//			System.Data.IDataParameter[] objPar=clsIDataParameterCreator.s_objConstructIDataParameterArr(new object[]{strWeek,strDepID});
			try
			{
				DataTable dtbResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
//				lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL,ref dtbResult,objPar);
				lngRes=objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbResult);
				objHRPSvc.Dispose();

				if(lngRes > 0 && dtbResult.Rows.Count > 0)
				{
					objPlan = new clsOPDoctorWkPlan_VO[dtbResult.Rows.Count];
	
					for(int i1=0;i1<objPlan.Length;i1++)
					{
						objPlan[i1] = new clsOPDoctorWkPlan_VO();
						if(dtbResult.Rows[i1]["MAXDIAGTIMES_INT"].ToString().Trim()!="")
							objPlan[i1].m_intMaxDiagTimes=int.Parse(dtbResult.Rows[i1]["MAXDIAGTIMES_INT"].ToString().Trim());
						objPlan[i1].m_objOPDept=new clsDepartmentVO();
						objPlan[i1].m_objOPDept.strDeptID=strDepID;
						objPlan[i1].m_objOPDept.strDeptName=dtbResult.Rows[i1]["DEPTNAME_VCHR"].ToString().Trim();
						objPlan[i1].m_objOPDoctor=new clsEmployeeVO();
						objPlan[i1].m_objOPDoctor.strEmpID=dtbResult.Rows[i1]["opdoctor_chr"].ToString().Trim();
						objPlan[i1].m_objOPDoctor.strName=dtbResult.Rows[i1]["lastname_vchr"].ToString().Trim();
						objPlan[i1].m_objOPDoctor.strEmpNO=dtbResult.Rows[i1]["EMPNO_CHR"].ToString().Trim();
						objPlan[i1].m_strEndTime=dtbResult.Rows[i1]["ENDTIME_CHR"].ToString().Trim();
						objPlan[i1].m_strOPDrWkPlanID=dtbResult.Rows[i1]["OPDRWKPLANID_CHR"].ToString().Trim();
						objPlan[i1].m_strPlanWeek=strWeek;
						objPlan[i1].m_strStartTime=dtbResult.Rows[i1]["STARTTIME_CHR"].ToString().Trim();
						objPlan[i1].m_strPlanPeriod=dtbResult.Rows[i1]["planperiod_chr"].ToString().Trim();
						objPlan[i1].m_objRegisterType=new clsRegisterType_VO();
						objPlan[i1].m_objRegisterType.m_strRegisterTypeID=dtbResult.Rows[i1]["registertypeid_chr"].ToString().Trim();
						objPlan[i1].m_objRegisterType.m_strRegisterTypeName=dtbResult.Rows[i1]["registertypename_vchr"].ToString().Trim();
                        objPlan[i1].m_objRecordEmp=new clsEmployeeVO();
						objPlan[i1].m_objRecordEmp.strEmpID=dtbResult.Rows[i1]["recordemp_chr"].ToString().Trim();
						objPlan[i1].m_objRecordDate=dtbResult.Rows[i1]["recorddate_dat"].ToString().Trim();
						objPlan[i1].m_strOPAddress=dtbResult.Rows[i1]["OPADDRESS_VCHR"].ToString().Trim();
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

		#region  通过周和取得排班记录 Sam 2004-6-2
		/// <summary>
		///  通过周取得排班记录
		/// </summary>
		[AutoComplete]
		public long m_lngGetPlanByWeekAndDepAll(System.Security.Principal.IPrincipal p_objPrincipal,string strWeek,out clsOPDoctorWkPlan_VO[] objPlan)
		{
			objPlan=new clsOPDoctorWkPlan_VO[0];
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc","m_lngGetPlanByWeekAndDep");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
            string strSQL = "Select a.opdrwkplanid_chr, a.planweek_chr, a.starttime_chr, a.endtime_chr, a.opdoctor_chr, a.opdept_chr, a.maxdiagtimes_int, a.registertypeid_chr, a.planperiod_chr, a.recordemp_chr, a.recorddate_dat, a.opaddress_vchr,b.lastname_vchr,b.EMPNO_CHR,c.registertypename_vchr,d.DEPTNAME_VCHR " +
				" From t_opr_opdoctorwkplan a, t_bse_Employee b,t_bse_RegisterType c,t_bse_deptdesc d " +
				" Where a.planweek_chr='"+strWeek+"'" +
				" And a.opdoctor_chr=b.empid_chr And a.registertypeid_chr=c.registertypeid_chr And a.OPDEPT_CHR=d.DEPTID_CHR order by PLANPERIOD_CHR,OPDEPT_CHR";

			//			System.Data.IDataParameter[] objPar=clsIDataParameterCreator.s_objConstructIDataParameterArr(new object[]{strWeek,strDepID});
			try
			{
				DataTable dtbResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				//				lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL,ref dtbResult,objPar);
				lngRes=objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbResult);
				objHRPSvc.Dispose();

				if(lngRes > 0 && dtbResult.Rows.Count > 0)
				{
					objPlan = new clsOPDoctorWkPlan_VO[dtbResult.Rows.Count];
	
					for(int i1=0;i1<objPlan.Length;i1++)
					{
						objPlan[i1] = new clsOPDoctorWkPlan_VO();
						if(dtbResult.Rows[i1]["MAXDIAGTIMES_INT"].ToString().Trim()!="")
							objPlan[i1].m_intMaxDiagTimes=int.Parse(dtbResult.Rows[i1]["MAXDIAGTIMES_INT"].ToString().Trim());
						objPlan[i1].m_objOPDept=new clsDepartmentVO();
						objPlan[i1].m_objOPDept.strDeptID=dtbResult.Rows[i1]["OPDEPT_CHR"].ToString().Trim();
						objPlan[i1].m_objOPDept.strDeptName=dtbResult.Rows[i1]["DEPTNAME_VCHR"].ToString().Trim();
						objPlan[i1].m_objOPDoctor=new clsEmployeeVO();
						objPlan[i1].m_objOPDoctor.strEmpID=dtbResult.Rows[i1]["opdoctor_chr"].ToString().Trim();
						objPlan[i1].m_objOPDoctor.strName=dtbResult.Rows[i1]["lastname_vchr"].ToString().Trim();
						objPlan[i1].m_objOPDoctor.strEmpNO=dtbResult.Rows[i1]["EMPNO_CHR"].ToString().Trim();
						objPlan[i1].m_strEndTime=dtbResult.Rows[i1]["ENDTIME_CHR"].ToString().Trim();
						objPlan[i1].m_strOPDrWkPlanID=dtbResult.Rows[i1]["OPDRWKPLANID_CHR"].ToString().Trim();
						objPlan[i1].m_strPlanWeek=strWeek;
						objPlan[i1].m_strStartTime=dtbResult.Rows[i1]["STARTTIME_CHR"].ToString().Trim();
						objPlan[i1].m_strPlanPeriod=dtbResult.Rows[i1]["planperiod_chr"].ToString().Trim();
						objPlan[i1].m_objRegisterType=new clsRegisterType_VO();
						objPlan[i1].m_objRegisterType.m_strRegisterTypeID=dtbResult.Rows[i1]["registertypeid_chr"].ToString().Trim();
						objPlan[i1].m_objRegisterType.m_strRegisterTypeName=dtbResult.Rows[i1]["registertypename_vchr"].ToString().Trim();
						objPlan[i1].m_objRecordEmp=new clsEmployeeVO();
						objPlan[i1].m_objRecordEmp.strEmpID=dtbResult.Rows[i1]["recordemp_chr"].ToString().Trim();
						objPlan[i1].m_objRecordDate=dtbResult.Rows[i1]["recorddate_dat"].ToString().Trim();
						objPlan[i1].m_strOPAddress=dtbResult.Rows[i1]["OPADDRESS_VCHR"].ToString().Trim();
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

		#region  查找某个医生的周排班记录 Sam 2004-6-2
		/// <summary>
		///  查找某个医生的周排班记录
		/// </summary>
		[AutoComplete]
		public long m_lngGetDocWeekPlan(System.Security.Principal.IPrincipal p_objPrincipal,string strWeek,string strPerio,
			string strDocID,out clsOPDoctorWkPlan_VO objPlan)
		{
			objPlan=new clsOPDoctorWkPlan_VO();
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc","m_lngGetDocWeekPlan");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
            string strSQL = "Select a.opdrwkplanid_chr, a.planweek_chr, a.starttime_chr, a.endtime_chr, a.opdoctor_chr, a.opdept_chr, a.maxdiagtimes_int, a.registertypeid_chr, a.planperiod_chr, a.recordemp_chr, a.recorddate_dat, a.opaddress_vchr,b.lastname_vchr,c.registertypename_vchr,d.deptname_vchr " +
                          " From t_opr_opdoctorwkplan a, t_bse_Employee b,t_bse_RegisterType c,T_BSE_DEPTBASEINFO d " +
                          " Where a.planweek_chr='"+strWeek+"' And a.planperiod_chr='"+strPerio+"' And a.opdoctor_chr='"+strDocID+"' " +
                          " and a.opdoctor_chr=b.empid_chr And a.registertypeid_chr=c.registertypeid_chr " +
                          " And a.opdept_chr=d.deptid_chr  ";

			//System.Data.IDataParameter[] objPar=clsIDataParameterCreator.s_objConstructIDataParameterArr(new object[]{strWeek,strPerio,strDocID});
			try
			{
				DataTable dtbResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
//				lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL,ref dtbResult,objPar);
				lngRes=objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbResult);
				objHRPSvc.Dispose();

				if(lngRes > 0 && dtbResult.Rows.Count > 0)
				{
					if(dtbResult.Rows[0]["MAXDIAGTIMES_INT"].ToString().Trim()!="")
						objPlan.m_intMaxDiagTimes=int.Parse(dtbResult.Rows[0]["MAXDIAGTIMES_INT"].ToString().Trim());
					objPlan.m_objOPDept=new clsDepartmentVO();
					objPlan.m_objOPDept.strDeptID=dtbResult.Rows[0]["opdept_chr"].ToString().Trim();
                    objPlan.m_objOPDept.strDeptName=dtbResult.Rows[0]["deptname_vchr"].ToString().Trim();
					objPlan.m_objOPDoctor=new clsEmployeeVO();
					objPlan.m_objOPDoctor.strEmpID=dtbResult.Rows[0]["opdoctor_chr"].ToString().Trim();
					objPlan.m_objOPDoctor.strName=dtbResult.Rows[0]["lastname_vchr"].ToString().Trim();
					objPlan.m_strEndTime=dtbResult.Rows[0]["ENDTIME_CHR"].ToString().Trim();
					objPlan.m_strOPDrWkPlanID=dtbResult.Rows[0]["OPDRWKPLANID_CHR"].ToString().Trim();
					objPlan.m_strPlanWeek=strWeek;
					objPlan.m_strStartTime=dtbResult.Rows[0]["STARTTIME_CHR"].ToString().Trim();
					objPlan.m_strPlanPeriod=dtbResult.Rows[0]["planperiod_chr"].ToString().Trim();
					objPlan.m_objRegisterType=new clsRegisterType_VO();
					objPlan.m_objRegisterType.m_strRegisterTypeID=dtbResult.Rows[0]["registertypeid_chr"].ToString().Trim();
					objPlan.m_objRegisterType.m_strRegisterTypeName=dtbResult.Rows[0]["registertypename_vchr"].ToString().Trim();
					objPlan.m_objRecordEmp=new clsEmployeeVO();
					objPlan.m_objRecordEmp.strEmpID=dtbResult.Rows[0]["recordemp_chr"].ToString().Trim();
					objPlan.m_objRecordDate=dtbResult.Rows[0]["recorddate_dat"].ToString().Trim();
					objPlan.m_strOPAddress=dtbResult.Rows[0]["OPADDRESS_VCHR"].ToString().Trim();
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

		//返回挂号类型
		#region  返回挂号类型 Sam 2004-6-2
		/// <summary>
		///  返回挂号类型
		/// </summary>
		[AutoComplete]
		public long m_lngGetRegType(System.Security.Principal.IPrincipal p_objPrincipal,out clsRegisterType_VO[] objResult)
		{
			objResult=new clsRegisterType_VO[0];
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc","m_lngGetRegType");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
            string strSQL = "select registertypeid_chr, registertypename_vchr, memo_vchr, registertypeno_vchr, isusing_num, isdoctor_num, urgency_int from t_bse_registertype where isusing_num=1 order by registertypeno_vchr";
			try
			{
				DataTable dtbResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbResult);
				objHRPSvc.Dispose();

				if(lngRes > 0 && dtbResult.Rows.Count > 0)
				{
					objResult = new clsRegisterType_VO[dtbResult.Rows.Count];
	
					for(int i1=0;i1<objResult.Length;i1++)
					{
						objResult[i1] = new clsRegisterType_VO();
						objResult[i1].m_strRegisterTypeID=dtbResult.Rows[i1]["REGISTERTYPEID_CHR"].ToString().Trim();
						objResult[i1].m_strRegisterTypeName=dtbResult.Rows[i1]["REGISTERTYPENAME_VCHR"].ToString().Trim();
						objResult[i1].m_strRegisterTypeNo=dtbResult.Rows[i1]["REGISTERTYPENo_VCHR"].ToString().Trim();
						objResult[i1].m_decRegPay = decimal.Parse(dtbResult.Rows[i1]["ISDOCTOR_NUM"].ToString().Trim());
//						if(dtbResult.Rows[i1]["DIAGPAY_MNY"].ToString().Trim()!="")
//						   objResult[i1].m_decDiagPay=decimal.Parse(dtbResult.Rows[i1]["DIAGPAY_MNY"].ToString().Trim());
//						if(dtbResult.Rows[i1]["REGPAY_MNY"].ToString().Trim()!="")
//						objResult[i1].m_decRegPay=decimal.Parse(dtbResult.Rows[i1]["REGPAY_MNY"].ToString().Trim());
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
		
        //导入周计划
		#region 导入周计划
		[AutoComplete]
		public long m_lngCreatePlan(System.Security.Principal.IPrincipal p_objPrincipal,DateTime startDate,DateTime endDate,string strEmp)
		{
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc","m_lngCreatePlan");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string sweek;
			string weekstr="3";
			string strSQL;
			System.DateTime  tmpdate;
			TimeSpan SpanTime=endDate-startDate;
			int sd=SpanTime.Days+1;
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc=new clsHRPTableService();
			com.digitalwave.iCare.middletier.HIS.clsHisBase HisBase=new clsHisBase();
			for(int i=0;i<sd;i++)
			{
				 tmpdate =startDate.AddDays(i);
                 sweek =tmpdate.DayOfWeek.ToString();
				 strSQL=@"DELETE  t_opr_opdoctorplan WHERE plandate_dat =To_Date('"+tmpdate+"','yyyy-mm-dd hh24:mi:ss')";
				try
				{
					lngRes=HRPSvc.DoExcute(strSQL);
				}
				catch(Exception objEx)
				{
					string strTmp=objEx.Message;
					com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
					bool blnRes = objLogger.LogError(objEx);
				}

				if(sweek=="Monday")
					weekstr="1";
				if(sweek=="Tuesday")
					weekstr="2";
				if(sweek=="Wednesday ")
					weekstr="3";
				if(sweek=="Thursday")
					weekstr="4";
				if(sweek=="Friday")
					weekstr="5";
				if(sweek=="Saturday")
					weekstr="6";
				if(sweek=="Sunday")
					weekstr="0";
                strSQL = @"select opdrwkplanid_chr, planweek_chr, starttime_chr, endtime_chr, opdoctor_chr, opdept_chr, maxdiagtimes_int, registertypeid_chr, planperiod_chr, recordemp_chr, recorddate_dat, opaddress_vchr from t_opr_opdoctorwkplan where planweek_chr ='" + weekstr + "'";
				DataTable dtRuest=new DataTable();
				try
				{
					lngRes=HRPSvc.DoGetDataTable(strSQL,ref dtRuest);
				}
				catch(Exception objEx)
				{
					string strTmp=objEx.Message;
					com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
					bool blnRes = objLogger.LogError(objEx);
				}
				DateTime newDate=HisBase.s_GetServerDate();
				for(int f2=0;f2<dtRuest.Rows.Count;f2++)
				{
					string newID=HRPSvc.m_strGetNewID("t_opr_opdoctorplan","opdrplanid_chr",18);
					strSQL=@"INSERT INTO t_opr_opdoctorplan(opdrplanid_chr, plandate_dat, starttime_chr,endtime_chr, opdcotor_chr, opdept_chr,maxdiagtimes_int, registertypeid_chr,planperiod_chr, recordemp_chr, recorddate_dat,opaddress_vchr,OPTIMES_INT)"
						  +" values('"+newID+"',To_Date('"+tmpdate+"','yyyy-mm-dd hh24:mi:ss'),'"+dtRuest.Rows[f2]["starttime_chr"]+"','"+dtRuest.Rows[f2]["endtime_chr"]+"','"+dtRuest.Rows[f2]["opdoctor_chr"]+"','"+dtRuest.Rows[f2]["opdept_chr"]+"',"+dtRuest.Rows[f2]["maxdiagtimes_int"]+
						 ",'"+dtRuest.Rows[f2]["registertypeid_chr"]+"','"+dtRuest.Rows[f2]["planperiod_chr"]+"','"+strEmp+"',To_Date('"+newDate+"','yyyy-mm-dd hh24:mi:ss'),'"+dtRuest.Rows[f2]["opaddress_vchr"]+"',0)";
					try
					{
						lngRes=HRPSvc.DoExcute(strSQL);
					}
					catch(Exception objEx)
					{
						string strTmp=objEx.Message;
						com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
						bool blnRes = objLogger.LogError(objEx);
					}
				}

			}
//			string strSQL="P_CREATEDAYPLAN";
//			clsSQLParamDefinitionVO[] objParameter=new clsSQLParamDefinitionVO[3];
//			for(int i=0;i<objParameter.Length;i++)
//               objParameter[i]=new clsSQLParamDefinitionVO();
//            objParameter[0].objParameter_Value=startDate;
//            objParameter[0].strParameter_Type="Date";
//			objParameter[1].objParameter_Value=endDate;
//			objParameter[1].strParameter_Type="Date";
//			objParameter[2].objParameter_Value=strEmp;
//			objParameter[2].strParameter_Type="Varchar2";
//			try
//			{
//				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc=new clsHRPTableService();
////				lngRes=HRPSvc.lngExecuteParameterProc(strSQL,objParameter);
//			}
//			catch(Exception objEx)
//			{
//				string strTmp=objEx.Message;
//				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
//				bool blnRes = objLogger.LogError(objEx);
//			}
			return lngRes;
		}
		#endregion

		#region 应用到周计划中的每一天
		#region  返回挂号类型 Sam 2004-6-2
		/// <summary>
		///  返回挂号类型
		/// </summary>
		[AutoComplete]
		public long m_lngAppWeek(System.Security.Principal.IPrincipal p_objPrincipal,clsOPDoctorWkPlan_VO objPlan)
		{
			long lngRes = 0;
			string p_strRecordID="";
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc","m_lngAppWeek");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			string strOperatorID=objPlan.m_objRecordEmp.strEmpID;
			try
			{
				//先把原有的排班删除
				string strSQL="Delete t_opr_opdoctorwkplan Where opdoctor_chr='"+objPlan.m_objOPDoctor.strEmpID+"' And " +
					          " planperiod_chr='"+objPlan.m_strPlanPeriod+"' " +
					          " And opdrwkplanid_chr<>'"+objPlan.m_strOPDrWkPlanID+"'";
				lngRes=objHRPSvc.DoExcute(strSQL);
				if(lngRes < 0)
					return lngRes;
				for(int i1=0;i1<7;i1++) //星期天到星期六公别以0-6表示
				{
					if(i1==int.Parse(objPlan.m_strPlanWeek))
						continue;
					lngRes = objHRPSvc.lngGenerateID(18,"OPDRWKPLANID_CHR","T_OPR_OPDOCTORWKPLAN",out p_strRecordID);
					if(lngRes < 0)
						return lngRes;
					strSQL ="INSERT INTO t_opr_opdoctorwkplan (opdrwkplanid_chr,planweek_chr,starttime_chr, " +
						"endtime_chr,opdoctor_chr,opdept_chr,maxdiagtimes_int,registertypeid_chr,planperiod_chr,recordemp_chr, " +
						"recorddate_dat,OPADDRESS_VCHR ) VALUES ('"+p_strRecordID+"','"+i1+"','"+objPlan.m_strStartTime+"', " +
						"'"+objPlan.m_strEndTime+"','"+objPlan.m_objOPDoctor.strEmpID+"','"+objPlan.m_objOPDept.strDeptID+"', " +
						"'"+objPlan.m_intMaxDiagTimes+"','"+objPlan.m_objRegisterType.m_strRegisterTypeID+"','"+objPlan.m_strPlanPeriod+"', " +
						"'"+strOperatorID+"',sysdate,'"+objPlan.m_strOPAddress+"') ";
					lngRes = objHRPSvc.DoExcute(strSQL);				
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
		#endregion
		
		#region  获得所有部门信息
		/// <summary>
		///  获得所有部门信息
		/// </summary>
		[AutoComplete]
		public long m_lngGetDept(System.Security.Principal.IPrincipal p_objPrincipal,out DataTable dtbResult)
		{
			long lngRes = 0;
			dtbResult=null;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc","m_lngGetDept");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			try
			{
                string strSQL = @"select deptid_chr, modify_dat, deptname_vchr, category_int, inpatientoroutpatient_int, operatorid_chr, address_vchr, pycode_chr, attributeid, parentid, createdate_dat, status_int, deactivate_dat, wbcode_chr, code_vchr, extendid_vchr, shortno_chr, stdbed_count_int, putmed_int, usercode_vchr, expertdeptflag_int from t_bse_deptdesc where category_int=0 and (attributeid = '0000002' or attributeid ='0000001') and deptname_vchr <> '所有' and inpatientoroutpatient_int = 0  order by shortno_chr";
				lngRes=objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbResult);
				if(lngRes < 0)
					return lngRes;
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

		#region  获得所有员工(有开处方权的员工）
		/// <summary>
		///  获得所有员工(有开处方权的员工）
		/// </summary>
		[AutoComplete]
		public long m_lngGetEmployee(System.Security.Principal.IPrincipal p_objPrincipal,out DataTable dtbResult)
		{
			long lngRes = 0;
			dtbResult=null;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc","m_lngGetEmployee");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			try
			{
				string strSQL=@"select EMPID_CHR,LASTNAME_VCHR,EMPNO_CHR,PYCODE_CHR from t_bse_employee where HASPRESCRIPTIONRIGHT_CHR='1'";
				lngRes=objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbResult);
				if(lngRes < 0)
					return lngRes;
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

		#region  获得所有员工(没有开处方权的员工）
		/// <summary>
		///  获得所有员工(没有开处方权的员工）
		/// </summary>
		[AutoComplete]
		public long m_lngGetEmployeeNo(System.Security.Principal.IPrincipal p_objPrincipal,out DataTable dtbResult)
		{
			long lngRes = 0;
			dtbResult=null;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc","m_lngGetEmployeeNo");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			try
			{
				string strSQL=@"select EMPID_CHR,LASTNAME_VCHR,EMPNO_CHR,PYCODE_CHR from t_bse_employee where HASPRESCRIPTIONRIGHT_CHR='0'";
				lngRes=objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbResult);
				if(lngRes < 0)
					return lngRes;
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

		//用于门诊挂号
		#region  通过日期和时间段取门诊 科室 列表(门诊挂号专用)
		/// <summary>
		///  通过日期和时间段取门诊科室列表
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="objPlan"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngGetOPDeptList(System.Security.Principal.IPrincipal p_objPrincipal,string date,string strPerio,out clsDepartmentVO[] objDep)
		{
			objDep=new clsDepartmentVO[0];
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc","m_lngGetOPDeptListByDate");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			//			string strSQL="Select a.OPDEPT_CHR,b.DEPTNAME_VCHR From t_opr_OPDoctorPlan a,t_bse_DeptBaseInfo b " +
			//                          " Where a.PLANDATE_DAT=to_date('"+strDate+"','yyyy-mm-dd') And a.planperiod_chr='"+strPerio+"' And " +
			//                          "a.OPDEPT_CHR=b.DEPTID_CHR(+) Group By a.OPDEPT_CHR,b.DEPTNAME_VCHR ";
            string strSQL = @"select deptid_chr, modify_dat, deptname_vchr, category_int, inpatientoroutpatient_int, operatorid_chr, address_vchr, pycode_chr, attributeid, parentid, createdate_dat, status_int, deactivate_dat, wbcode_chr, code_vchr, extendid_vchr, shortno_chr, stdbed_count_int, putmed_int, usercode_vchr, expertdeptflag_int from t_bse_deptdesc where CATEGORY_INT=0 and (ATTRIBUTEID = '0000002' or ATTRIBUTEID ='0000001') and DEPTNAME_VCHR <> '所有' and INPATIENTOROUTPATIENT_INT = 0 and (DEPTNAME_VCHR like '" + strPerio + "%' OR SHORTNO_CHR like '" + strPerio + @"%'
OR PYCODE_CHR like '" +strPerio+"%') order by SHORTNO_CHR";
			//			DateTime sDate=Convert.ToDateTime(strDate);
			//			System.Data.IDataParameter[] objPar=clsIDataParameterCreator.s_objConstructIDataParameterArr(new object[]{sDate,strPerio});


			try
			{
				DataTable dtbResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbResult);





				objHRPSvc.Dispose();

				if(lngRes > 0 && dtbResult.Rows.Count > 0)
				{
					objDep = new clsDepartmentVO[dtbResult.Rows.Count];
	
					for(int i1=0;i1<objDep.Length;i1++)
					{
						objDep[i1] = new clsDepartmentVO();
						objDep[i1].strDeptID=dtbResult.Rows[i1]["DEPTID_CHR"].ToString().Trim();
						objDep[i1].strDeptName=dtbResult.Rows[i1]["DEPTNAME_VCHR"].ToString().Trim();
						objDep[i1].strShortNo=dtbResult.Rows[i1]["SHORTNO_CHR"].ToString().Trim();
						objDep[i1].strPYCode=dtbResult.Rows[i1]["PYCODE_CHR"].ToString().Trim();
						objDep[i1].strAddress=dtbResult.Rows[i1]["ADDRESS_VCHR"].ToString().Trim();
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

		#region 根据员工ID查找所在部门列表
		/// <summary>
		/// 根据员工ID查找所在部门列表
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="strPatientID"></param>
		/// <param name="strEx"></param>
		/// <param name="objDep"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_mthGetDepartment(System.Security.Principal.IPrincipal p_objPrincipal,string strPatientID,string strEx,out clsDepartmentVO[] objDep)
		{
			objDep=null;
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc","m_lngGetOPDeptListByDate");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}

            string strSQL = @"select a.deptid_chr, a.modify_dat, a.deptname_vchr, a.category_int, a.inpatientoroutpatient_int, a.operatorid_chr, a.address_vchr, a.pycode_chr, a.attributeid, a.parentid, a.createdate_dat, a.status_int, a.deactivate_dat, a.wbcode_chr, a.code_vchr, a.extendid_vchr, a.shortno_chr, a.stdbed_count_int, a.putmed_int, a.usercode_vchr, a.expertdeptflag_int
							 from t_bse_deptdesc a, t_bse_deptemp b
							where a.deptid_chr = b.deptid_chr 
							  and b.empid_chr = '" +strPatientID+"'";			
			try
			{
				DataTable dtbResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbResult);
				objHRPSvc.Dispose();

				if(lngRes > 0 && dtbResult.Rows.Count > 0)
				{
					objDep = new clsDepartmentVO[dtbResult.Rows.Count];
	
					for(int i1=0;i1<objDep.Length;i1++)
					{
						objDep[i1] = new clsDepartmentVO();
						objDep[i1].strDeptID=dtbResult.Rows[i1]["DEPTID_CHR"].ToString().Trim();
						objDep[i1].strDeptName=dtbResult.Rows[i1]["DEPTNAME_VCHR"].ToString().Trim();
						objDep[i1].strShortNo=dtbResult.Rows[i1]["SHORTNO_CHR"].ToString().Trim();
						objDep[i1].strPYCode=dtbResult.Rows[i1]["PYCODE_CHR"].ToString().Trim();
						objDep[i1].strAddress=dtbResult.Rows[i1]["ADDRESS_VCHR"].ToString().Trim();
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

		#region 根据员工ID查找默认科室
		/// <summary>
		/// 根据员工ID查找默认科室
		/// </summary>	
		[AutoComplete]	
		public long m_lngGetDefaultDept(string strEmpID, out DataTable dtRecord)
		{
			long lngRes = 0;			
			string SQL = @"select a.deptid_chr, a.deptname_vchr, a.shortno_chr
							 from t_bse_deptdesc a, t_bse_deptemp b
							where a.deptid_chr = b.deptid_chr
							  and b.default_dept_int = 1
							  and b.empid_chr = '" + strEmpID + "'";			
			dtRecord = new DataTable();

			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dtRecord);				
			}
			catch(Exception objEx)
			{
				string strTmp = objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion

        #region 查询病人类型
        [AutoComplete]
        public long m_lngGetPatType(System.Security.Principal.IPrincipal objPri, out clsPatientType_VO[] clsResult)
        {
            clsResult = new clsPatientType_VO[0];
            com.digitalwave.security.clsPrivilegeHandleService clsSec = new clsPrivilegeHandleService();
            long lngRes = clsSec.m_lngCheckCallPrivilege(objPri, "com.digitalwave.iCare.middletier.HIS.clsRegisterSvc", "m_lngGetPatType");
            if (lngRes < 0)
                return lngRes;

            string strSQL = "select paytypeid_chr, paytypename_vchr, memo_vchr, paylimit_mny, payflag_dec, paypercent_dec, paytypeno_vchr, isusing_num, copayid_chr, chargepercent_dec, internalflag_int, coalitionrecipeflag_int, bihlimitrate_dec from t_bse_patientpaytype where isusing_num=1 and PAYFLAG_DEC<>2  order by PAYTYPENO_VCHR";
            try
            {
                DataTable dtResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService HRPSvc = new clsHRPTableService();
                lngRes = HRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtResult);
                HRPSvc.Dispose();
                if (lngRes > 0 && dtResult.Rows.Count > 0)
                {
                    clsResult = new clsPatientType_VO[dtResult.Rows.Count];
                    for (int i1 = 0; i1 < dtResult.Rows.Count; i1++)
                    {
                        clsResult[i1] = new clsPatientType_VO();
                        clsResult[i1].m_strPayTypeID = dtResult.Rows[i1]["PAYTYPEID_CHR"].ToString().Trim();
                        clsResult[i1].m_strPayTypeName = dtResult.Rows[i1]["paytypename_vchr"].ToString().Trim();
                        clsResult[i1].m_strPayTypeNo = dtResult.Rows[i1]["paytypeno_vchr"].ToString().Trim();
                        if (dtResult.Rows[i1]["PAYFLAG_DEC"] != System.DBNull.Value)
                            clsResult[i1].m_decDiscount = decimal.Parse(dtResult.Rows[i1]["PAYFLAG_DEC"].ToString().Trim());
                        else
                            clsResult[i1].m_decDiscount = 0;
                    }
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion
		
	}
}
