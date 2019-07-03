using System;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
using System.EnterpriseServices;
using System.Data;
using System.Collections;

using System.Drawing;
namespace com.digitalwave.iCare.middletier.HIS.Reports
{
	/// <summary>
	/// clsShowReportsSvc 的摘要说明。
	/// </summary>
	[Transaction(TransactionOption.Required)]
	[ObjectPooling(true)]
	public class clsShowReportsSvc:com.digitalwave.iCare.middletier.clsMiddleTierBase
	{
		public clsShowReportsSvc()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region 查找节点
		[AutoComplete]
		public long m_mthLoadNodes(System.Security.Principal.IPrincipal p_objPrincipal,string strPatientID,out clsReports_VO[] objArr )
		{
			objArr=null;
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS","m_mthLoadNodes");
			if(lngRes < 0)
			{
				return -1;
			}
            string strSQL = @"SELECT REPORT_ID_CHR,CHECK_DAT as MODIFY_DAT,1 flag,'' GroupID FROM T_OPR_RIS_CARDIOGRAM_REPORT where
PATIENT_ID_CHR ='" +strPatientID+ @"'   AND STATUS_INT >-1
union all
SELECT REPORT_ID_CHR,MODIFY_DAT,2 flag,'' GroupID FROM T_OPR_RIS_DCARDIOGRAM_REPORT where
PATIENT_ID_CHR ='" + strPatientID+@"'  AND STATUS_INT >-1
union all
SELECT REPORT_ID_CHR,MODIFY_DAT,3 flag,'' GroupID FROM T_OPR_RIS_EEG_REPORT where
PATIENT_ID_CHR ='"+strPatientID+@"'  AND STATUS_INT >-1
union all
SELECT REPORT_ID_CHR,MODIFY_DAT,4 flag,'' GroupID FROM T_OPR_RIS_TCD_REPORT where
PATIENT_ID_CHR ='"+strPatientID+@"' AND STATUS_INT >-1
union all
SELECT REPORTID,MODIFYDATE,5 flag,'' GroupID FROM IMAGEREPORT where
PATIENTID ='"+strPatientID+@"'
union all
SELECT A.APPLICATION_ID_CHR,B.MODIFY_DAT,6 flag,B.REPORT_GROUP_ID_CHR GroupID from T_OPR_LIS_APPLICATION A,T_OPR_LIS_APP_REPORT B
where A.application_id_chr=B.application_id_chr(+) and b.STATUS_INT=2 and a.PSTATUS_INT=2 and A.PATIENTID_CHR='"+strPatientID+@"'
union all
 select OUTPATRECIPEID_CHR,RECORDDATE_DAT,7 flag,'' GroupID  from T_OPR_OUTPATIENTRECIPE
 where PSTAUTS_INT =2 and 
 PATIENTID_CHR ='" + strPatientID + @"' order by RECORDDATE_DAT
  union all
 select CASEHISID_CHR,MODIFYDATE_DAT,8 flag ,'' GroupID from T_OPR_OUTPATIENTCASEHIS
 where PATIENTID_CHR ='" +strPatientID+"'";

			try
			{
				DataTable dt =new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dt);
				objHRPSvc.Dispose();
				if(lngRes>0&&dt.Rows.Count>0)
				{
					objArr=new clsReports_VO[dt.Rows.Count];
					for(int i =0;i<dt.Rows.Count;i++)
					{
					objArr[i]=new clsReports_VO();
					objArr[i].m_strReportID=dt.Rows[i]["REPORT_ID_CHR"].ToString();
					objArr[i].m_strdate=dt.Rows[i]["MODIFY_DAT"].ToString();
					objArr[i].m_intCatType=int.Parse(dt.Rows[i]["FLAG"].ToString());
					objArr[i].m_strGroupID=dt.Rows[i]["GroupID"].ToString();
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
		

		
		#region byte转换为image
		private System.Drawing.Image m_mthConvertByte2Image(byte[] p_bytImage)
		{
			Image objImg = null;

			if(p_bytImage != null)
			{
				System.IO.MemoryStream objStream = new System.IO.MemoryStream((byte[])p_bytImage);

				objImg = new Bitmap(objStream);
			}
			return objImg;
		}
		#endregion	
		#region 查找病人信息
		[AutoComplete]
		public long m_mthFindPatientInfo(System.Security.Principal.IPrincipal p_objPrincipal,int flag,string strID,out DataTable dt)
		{
			dt=new DataTable();
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS","m_mthFindPatientInfo");
			if(lngRes < 0)
			{
				return -1;
			}
			string strCardID="";
			string strName="";
			if(flag==1)
			{
				strCardID=strID;
			}
			else
			{
				strName=strID;
			}
         
            if (strCardID.Trim() == string.Empty)
            {
                string strSQL = @"select a.patientid_chr, a.birth_dat, a.firstname_vchr, a.sex_chr,
       a.homephone_vchr, a.idcard_chr, a.homeaddress_vchr, a.govcard_chr,
       a.difficulty_vchr, b.patientcardid_chr
  from t_bse_patient a, t_bse_patientcard b
 where a.patientid_chr = b.patientid_chr
   and a.firstname_vchr like ?
   and b.status_int <> 0";
                try
                {

                    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                    System.Data.IDataParameter[] paramArr = null;
                    objHRPSvc.CreateDatabaseParameter(1, out paramArr);
                    paramArr[0].Value = strName + "%";
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, paramArr);
                    objHRPSvc.Dispose();

                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            else
            {
                string strSQL = @"select a.patientid_chr, a.birth_dat, a.firstname_vchr, a.sex_chr,
       a.homephone_vchr, a.idcard_chr, a.homeaddress_vchr, a.govcard_chr,
       a.difficulty_vchr, b.patientcardid_chr
  from t_bse_patient a, t_bse_patientcard b
 where a.patientid_chr = b.patientid_chr
   and b.patientcardid_chr = ?
   and b.status_int <> 0";
                try
                {

                    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                    System.Data.IDataParameter[] paramArr = null;
                    objHRPSvc.CreateDatabaseParameter(1, out paramArr);
                    paramArr[0].Value = strCardID;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, paramArr);

                    objHRPSvc.Dispose();

                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
			return lngRes;
		}
		#endregion
		#region 根据住院号查找病人ID
		[AutoComplete]
		public string m_mthFindPatientIDByInHospitalNo(System.Security.Principal.IPrincipal p_objPrincipal,string ID)
		{
			
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS","m_mthFindPatientIDByInHospitalNo");
			if(lngRes < 0)
			{
				return "";
			}
			string strPatientID="";
		
			string strSQL = @"SELECT patientid_chr  FROM T_BSE_PATIENT WHERE trim(inpatientid_chr) = '"+ID+"'";
			try
			{
			DataTable dt =new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dt);
				objHRPSvc.Dispose();
				if(lngRes>0&&dt.Rows.Count>0)
				{
				strPatientID=dt.Rows[0][0].ToString().Trim();
				}
				
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return strPatientID;
		}
		#endregion
		#region 获取病历信息
		[AutoComplete]
		public long m_mthGetCaseHistoryInfo(string ID,out DataTable dt)
		{
			dt=new DataTable();
			long lngRes=0;
			
			string strSQL = @"SELECT a.*, b.deptname_vchr, c.lastname_vchr
  FROM t_opr_outpatientcasehis a, t_bse_deptdesc b, t_bse_employee c
 WHERE a.diagdept_chr = b.deptid_chr(+) AND a.diagdr_chr = c.empid_chr(+) and (a.status_int <> 0 or a.status_int is null)
       AND a.casehisid_chr = '"+ID+"'";
			try
			{
				
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
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
		#region 获取病历信息
		[AutoComplete]
		public long m_mthGetCaseHistoryInfo2(string strCaseID,out DataTable dt)
		{
			dt=new DataTable();
			long lngRes=0;

            string strSQL = @"SELECT   a.*, b.deptname_vchr, c.lastname_vchr, f.patientcardid_chr,
         TO_CHAR (modifydate_dat, 'yyyy-mm-dd') creatdate, d.sign_grp,e.lastname_vchr patientName,e.sex_chr,e.birth_dat,e.homeaddress_vchr,e.homephone_vchr
    FROM t_opr_outpatientcasehis a,
         t_bse_deptdesc b,
         t_bse_employee c,
         t_bse_empsign d,
		t_bse_patient e,
        t_bse_patientcard f
   WHERE a.diagdept_chr = b.deptid_chr(+)
     AND a.diagdr_chr = c.empid_chr(+)
     AND a.diagdr_chr = d.empid_chr(+)
     and a.patientid_chr = e.patientid_chr(+)
      and a.patientid_chr=f.patientid_chr(+)
	 AND (a.status_int <> 0 or a.status_int is null)
     AND a.CASEHISID_CHR = '" + strCaseID+"' order by creatdate desc";

			try
			{
				
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
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
		#region 获取病历信息
		[AutoComplete]
		public long m_mthGetCaseHistoryInfo3(string strCaseID,out DataTable dt)
		{
			dt=new DataTable();
			long lngRes=0;
			
			string strSQL = @"SELECT   a.*, b.deptname_vchr, c.lastname_vchr,
         TO_CHAR (modifydate_dat, 'yyyy-mm-dd') creatdate, d.sign_grp,e.lastname_vchr patientName,e.sex_chr,e.birth_dat,e.homeaddress_vchr,e.homephone_vchr
    FROM t_opr_outpatientcasehis a,
         t_bse_deptdesc b,
         t_bse_employee c,
         t_bse_empsign d,
		t_bse_patient e
   WHERE a.diagdept_chr = b.deptid_chr(+)
     AND a.diagdr_chr = c.empid_chr(+)
     AND a.diagdr_chr = d.empid_chr(+)
     and a.patientid_chr =e.patientid_chr(+)
	 AND (a.status_int <> 0 or a.status_int is null)
     AND a.patientid_chr = '"+strCaseID+"' order by creatdate desc";
			
			try
			{
				
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
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
		#region 获取处方信息
		[AutoComplete]
		public long m_mthGetRecipeInfo(string ID,out DataTable dt)
		{
			dt=new DataTable();
			long lngRes=0;
			
			string strSQL = @"SELECT a.*, b.*, c.patientcardid_chr,
       CASE
          WHEN d.recipeflag_int = 1
             THEN '正方'
          ELSE '副方'
       END recipeflag_int, e.typename_vchr, f.paytypename_vchr, g.diag_vchr
  FROM t_opr_outpatientrecipeinv a,
       t_bse_patient b,
       t_bse_patientcard c,
       t_opr_outpatientrecipe d,
       t_aid_recipetype e,
       t_bse_patientpaytype f,
       t_opr_outpatientcasehis g
 WHERE a.patientid_chr = b.patientid_chr(+)
   AND a.patientid_chr = c.patientid_chr(+)
   AND a.outpatrecipeid_chr = d.outpatrecipeid_chr(+)
   AND d.type_int = e.type_int(+)
   AND a.paytypeid_chr = f.paytypeid_chr(+)
   AND d.casehisid_chr = g.casehisid_chr(+)
and a.OUTPATRECIPEID_CHR ='"+ID+"'";
			try
			{
				
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
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
		#region 获取处方信息
		[AutoComplete]
		public long m_mthGetRecipeInfo2(string ID,out DataTable dt)
		{
			dt=new DataTable();
			long lngRes=0;
			
			string strSQL = @"SELECT a.*, b.*, c.patientcardid_chr,
       CASE
          WHEN a.recipeflag_int = 1
             THEN '正方'
          ELSE '副方'
       END recipeflag_int, e.typename_vchr, f.paytypename_vchr,
       h.deptname_vchr, g.diag_vchr, i.lastname_vchr AS doctorname_chr, i.empno_chr as doctorno, e.r_int, e.g_int, e.b_int
  FROM t_opr_outpatientrecipe a,
       t_bse_patient b,
       t_bse_patientcard c,
       t_aid_recipetype e,
       t_bse_patientpaytype f, 
       t_opr_outpatientcasehis g,
       t_bse_deptdesc h,
       t_bse_employee i
 WHERE a.patientid_chr = b.patientid_chr(+)
   AND a.patientid_chr = c.patientid_chr(+)
   AND a.type_int = e.type_int(+)
   AND a.diagdept_chr = h.deptid_chr(+)
   AND a.paytypeid_chr = f.paytypeid_chr(+)
   AND a.casehisid_chr = g.casehisid_chr(+)
   AND a.diagdr_chr = i.empid_chr(+)
and a.OUTPATRECIPEID_CHR ='" + ID+"'";
			try
			{
				
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
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
	
		#region 从中间表获取处方号数组
		[AutoComplete]
		public long m_mthGetRecipeGroup(string strRecipeIndex,out string[] IDArr)
		{
			IDArr =new string[0];
			long lngRes=0;
			
			string strSQL = @"  select * from  t_opr_reciperelation where SEQID ='"+strRecipeIndex+"'";
			try
			{
				DataTable dt =new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
				if(dt.Rows.Count>0)
				{
					IDArr =new string[dt.Rows.Count];
					for(int i =0;i<dt.Rows.Count;i++)
					{
					IDArr[i] =dt.Rows[i]["OUTPATRECIPEID_CHR"].ToString().Trim();
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
		#region 获取病人看病次数
		[AutoComplete]
		public long m_mthGetPatientSeeDocTimes(string strPatientID,out DataTable dt)
		{
				dt=new DataTable();
				long lngRes=0;
				
			string strSQL = @"SELECT   *
    FROM (SELECT registerid_chr, recorddate_dat,1 AS flag
            FROM t_opr_patientregister
           WHERE patientid_chr = '"+strPatientID+@"'
          UNION
          SELECT registerid_chr, INPATIENT_DAT recorddate_dat, 2 AS flag
            FROM t_opr_bih_register
           WHERE patientid_chr = '"+strPatientID+@"')
ORDER BY flag, recorddate_dat desc";
			try
			{
				
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
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
	
		#region 获取病人挂号信息
		[AutoComplete]
		public long m_mthGetRegisterInfo(string strPatientID,out DataTable dt)
		{
			dt=new DataTable();
			long lngRes=0;
				
			string strSQL = @"SELECT  a.registerid_chr, a.patientcardid_chr, a.invno_chr,
                a.registerno_chr, a.order_int, a.registertypename_vchr,
                a.name_vchr, a.sex_chr,
                CASE
                   WHEN a.paytype_int = 0
                      THEN '现金'
                   WHEN a.paytype_int = 1
                      THEN '记帐'
                   WHEN a.paytype_int = 2
                      THEN '支票'
                END AS paytype,
                a.registerdate_dat, a.deptname_vchr, a.lastname_vchr,
                CASE
                   WHEN a.balance_dat IS NULL
                      THEN '未结账'
                   WHEN a.balance_dat IS NOT NULL
                      THEN '结帐'
                END AS pstatus,
                CASE
                   WHEN a.flag_int = 1
                      THEN '正常'
                   WHEN a.flag_int = 2
                      THEN '预约'
                   WHEN a.flag_int = 3
                      THEN '退号'
                   WHEN a.flag_int = 4
                      THEN '还原'
                END AS flag,
                a.reempno, a.returndate_dat, a.recorddate_dat,
                a.paytypename_vchr, a.address_vchr, a.empno_chr, a.ghmoney,
                a.kbmoney, a.gbmoney, a.ghdiscount, a.kbdiscount,
                a.gbdiscount
           FROM v_opregister a
          WHERE a.registerid_chr = '"+strPatientID+"'";
			try
			{
				
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
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
		#region 获取收费信息信息
		[AutoComplete]
		public long m_mthGetChargeInfo(string strPatientID,string date1,string date2,out DataTable dt)
		{
			dt=new DataTable();
			long lngRes=0;
				
			string strSQL = @"SELECT a.*, b.lastname_vchr
  FROM t_opr_outpatientrecipeinv a, t_bse_employee b,
       t_opr_outpatientrecipe c
 WHERE a.recordemp_chr = b.empid_chr(+)
   AND a.outpatrecipeid_chr = c.outpatrecipeid_chr
  and a.RECORDDATE_DAT  BETWEEN TO_DATE('"+date1+"','yyyy-mm-dd hh24:mi:ss') "+
				@" AND TO_DATE('"+date2+@" ','yyyy-mm-dd hh24:mi:ss')  and 
					 a.patientid_chr = '" + strPatientID + "'   AND c.PSTAUTS_INT <>-1  order by a.RECORDDATE_DAT ";
			try
			{
				
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
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
		#region 获取住院登记信息
		[AutoComplete]
		public long m_mthInHospitalInfo(string strPatientID,string date1,string date2,out DataTable dt)
		{
			dt=new DataTable();
			long lngRes=0;
				
			string strSQL = @"SELECT a.*, (SELECT deptname_vchr
               FROM t_bse_deptdesc
              WHERE deptid_chr = a.deptid_chr) deptname,
       (SELECT deptname_vchr
          FROM t_bse_deptdesc
         WHERE deptid_chr = a.areaid_chr) areaname,
       (SELECT code_chr
          FROM t_bse_bed
         WHERE bedid_chr = a.bedid_chr) bedno,
       (SELECT lastname_vchr
          FROM t_bse_employee
         WHERE TRIM (empid_chr) = TRIM (a.operatorid_chr)) operatorname,
       (SELECT lastname_vchr
          FROM t_bse_employee
         WHERE TRIM (empid_chr) = TRIM (a.casedoctor_chr)) doctorname,
       (SELECT lastname_vchr
          FROM t_bse_employee
         WHERE TRIM (empid_chr) = TRIM (a.mzdoctor_chr)) outdoctorname,
       DECODE (type_int, 1, '门诊', 2, '急诊', 3, '他院转入', '') typename,
       DECODE (pstatus_int,
               0, '未上床',
               1, '已上床',
               2, '预出院',
               3, '实际出院',
               ''
              ) pstatusname
  FROM t_opr_bih_register a
 WHERE status_int = '1' AND a.patientid_chr ='"+strPatientID+"'  and a.INPATIENT_DAT  BETWEEN TO_DATE('"+date1+"','yyyy-mm-dd hh24:mi:ss') "+
				@" AND TO_DATE('"+date2+@" ','yyyy-mm-dd hh24:mi:ss')";
			try
			{
				
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
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
		#region 获取检验信息
		[AutoComplete]
		public long m_mthGetTestInfo(string strPatientID,string date1,string date2,out DataTable dt)
		{
			dt =null;
			return 0;
		}
		#endregion
		#region 获取主要数据
		#region 获取病人处方
		[AutoComplete]
		public long m_mthGetRecipeByPatientID(string strPatientID,string date1,string date2,out DataTable dt)
		{
			dt=new DataTable();
			long lngRes=0;
				
			string strSQL = @"SELECT a.*, b.lastname_vchr  FROM t_opr_outpatientrecipe a, t_bse_employee b
 where    a.recordemp_chr = b.empid_chr(+)  and RECORDDATE_DAT  BETWEEN TO_DATE('"+date1+"','yyyy-mm-dd hh24:mi:ss') "+
				" AND TO_DATE('"+date2+@" ','yyyy-mm-dd hh24:mi:ss')  and 
  patientid_chr = '" + strPatientID + "' order by a.RECORDDATE_DAT";
			try
			{
				
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
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
		#region 获取申请单
		/// <summary>
		/// 获取申请单
		/// </summary>
		/// <param name="strRecipeID">病人IDID</param>
		///<param name="date1"></param>
		///<param name="date2"></param>
		/// <param name="dt"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_mthGetTestApplyBill(string strRecipeID,string date1,string date2,out DataTable dt)
		{
			dt=new DataTable();
			long lngRes=0;
				
			string strSQL = @"SELECT a.application_id_chr AS reportid, a.APPLICATION_DAT as modify_dat,
       b.report_group_id_chr groupid, c.sourceitemid_vchr, e.lastname_vchr,b.status_int
  FROM t_opr_lis_application a,
       t_opr_lis_app_report b,
       t_opr_attachrelation c,
       t_opr_outpatientrecipe d,
       t_bse_employee e
 WHERE a.application_id_chr = b.application_id_chr
   AND a.pstatus_int = 2
	 and b.status_int>0
   AND a.application_id_chr = c.attachid_vchr
   AND d.diagdr_chr = e.empid_chr(+)
   AND c.sourceitemid_vchr = d.outpatrecipeid_chr
   and c.attachtype_int=3
   AND  D.RECORDDATE_DAT  BETWEEN TO_DATE('"+date1+"','yyyy-mm-dd hh24:mi:ss') "+
				" AND TO_DATE('"+date2+@" ','yyyy-mm-dd hh24:mi:ss')  and 
  D.patientid_chr = '"+strRecipeID+"'";
strSQL+=@" union SELECT a.application_id_chr AS reportid, b.REPORT_DAT,
       b.report_group_id_chr groupid, c.sourceitemid_vchr, e.lastname_vchr,3 as status_int
  FROM t_opr_lis_application a,
       t_opr_lis_app_report b,
       t_opr_attachrelation c,
       t_opr_outpatientrecipe d,
       t_bse_employee e
 WHERE a.application_id_chr = b.application_id_chr
   AND b.status_int = 2
	and a.pstatus_int=2
   AND a.application_id_chr = c.attachid_vchr
   AND d.diagdr_chr = e.empid_chr(+)
   AND c.sourceitemid_vchr = d.outpatrecipeid_chr
   and c.attachtype_int=3
   AND  D.RECORDDATE_DAT  BETWEEN TO_DATE('"+date1+"','yyyy-mm-dd hh24:mi:ss') "+
				" AND TO_DATE('"+date2+@" ','yyyy-mm-dd hh24:mi:ss')  and 
  D.patientid_chr = '"+strRecipeID+"'";
			try
			{
				
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
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
		#region 医嘱执行单
		/// <summary>
		/// 医嘱执行单
		/// </summary>
		/// <param name="strID">住院流水号</param>
		/// <param name="dt"></param>
			[AutoComplete]
		public long m_mthGetOrderInfo(string strID,out DataTable dt)
		{
			dt=new DataTable();
			long lngRes=0;
			string strSQL = @"SELECT aa.*, TRUNC (createdate_dat) creatdate
  FROM t_opr_bih_orderexecute aa,
       (SELECT   MAX (a.orderexecid_chr) ID
            FROM t_opr_bih_orderexecute a, t_opr_bih_order b
           WHERE a.orderid_chr = b.orderid_chr AND b.registerid_chr = '"+strID+@"'
        GROUP BY TRUNC (a.createdate_dat)) bb
 WHERE aa.orderexecid_chr = bb.ID";
			try
			{
				
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
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
		#region 查找节点二
		/// <summary>
		/// 查找节点二
		/// </summary>
		/// <param name="strPatientID">病人ID</param>
		/// <param name="dt"></param>
		/// <param name="flag"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_mthLoadNodes2(string strPatientID,out DataTable dt,int flag )
		{
			long lngRes=0;
			string strSQL ="";
			dt =new DataTable();
			switch(flag)
			{
				case 1://Ris心电脑
                    strSQL = @"select   report_id_chr as reportid, check_dat as modify_dat, 1 flag,
         '' groupid
    from t_opr_ris_cardiogram_report
   where patient_id_chr = ? and status_int > -1
order by modify_dat desc";
					break;
				case 2://
                    strSQL = @"select   report_id_chr as reportid, modify_dat, 2 flag, '' groupid
    from t_opr_ris_dcardiogram_report
   where patient_id_chr = ? and status_int > -1
order by modify_dat desc
";
					break;
				case 3://脑电图
                    strSQL = @"select   report_id_chr as reportid, modify_dat, 3 flag, '' groupid
    from t_opr_ris_eeg_report
   where patient_id_chr = ? and status_int > -1
order by modify_dat desc";
					break;
				case 4:
                    strSQL = @"select   report_id_chr as reportid, modify_dat, 4 flag, '' groupid
    from t_opr_ris_tcd_report
   where patient_id_chr = ? and status_int > -1
order by modify_dat desc";
					break;
				case 5://PACSS
                    strSQL = @"select   reportid, modifydate as modify_dat, 5 flag, '' groupid
    from imagereport
   where patientid = ?
order by modifydate desc";
					break;
				case 6://检验
                    strSQL = @"select   a.application_id_chr as reportid, b.modify_dat, 6 flag,
         b.report_group_id_chr groupid
    from t_opr_lis_application a, t_opr_lis_app_report b
   where a.application_id_chr = b.application_id_chr(+)
     and b.status_int = 2
     and a.pstatus_int = 2
     and a.patientid_chr = ?
order by b.modify_dat desc";
					break;
				case 7://处方
                    strSQL = @"select   outpatrecipeid_chr as reportid, recorddate_dat as modify_dat, 7 flag,
         '' groupid, pstauts_int
    from t_opr_outpatientrecipe
   where (pstauts_int = 2 or pstauts_int = 4) and patientid_chr = ?
order by modify_dat desc";
					break;
				case 8://病历
                    strSQL = @"select   casehisid_chr as reportid, modifydate_dat as modify_dat, 8 flag,
         '' groupid
    from t_opr_outpatientcasehis
   where patientid_chr = ?
order by modifydate_dat desc";
					break;
			
			}
		
			try
			{
				
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] paramArr = null;
                objHRPSvc.CreateDatabaseParameter(1, out paramArr);
                paramArr[0].Value = strPatientID;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, paramArr);

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
		#region 获取明细数据
		
		#region 获取心电图信息
		[AutoComplete]
		public long m_mthGetCARDIOGRAMInfo(System.Security.Principal.IPrincipal p_objPrincipal,string ID,out clsRIS_CardiogramReport_VO m_objItem)
		{
			m_objItem=null;
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS","m_mthGetCARDIOGRAMInfo");
			if(lngRes < 0)
			{
				return -1;
			}
			string strSQL = @"SELECT * FROM T_OPR_RIS_CARDIOGRAM_REPORT WHERE REPORT_ID_CHR ='"+ID+"' ";
			try
			{
				DataTable dtbResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
				objHRPSvc.Dispose();
				if(lngRes > 0 && dtbResult.Rows.Count > 0)
				{
					m_objItem=new clsRIS_CardiogramReport_VO();
					m_objItem.m_strREPORT_ID_CHR = dtbResult.Rows[0]["REPORT_ID_CHR"].ToString().Trim();
					m_objItem.m_strMODIFY_DAT = Convert.ToDateTime(dtbResult.Rows[0]["MODIFY_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
					m_objItem.m_strREPORT_NO_CHR = dtbResult.Rows[0]["REPORT_NO_CHR"].ToString().Trim();
					m_objItem.m_strPATIENT_ID_CHR = dtbResult.Rows[0]["PATIENT_ID_CHR"].ToString().Trim();
					m_objItem.m_strPATIENT_NO_CHR = dtbResult.Rows[0]["PATIENT_NO_CHR"].ToString().Trim();
					m_objItem.m_strINPATIENT_NO_CHR = dtbResult.Rows[0]["INPATIENT_NO_CHR"].ToString().Trim();
					m_objItem.m_strPATIENT_NAME_VCHR = dtbResult.Rows[0]["PATIENT_NAME_VCHR"].ToString().Trim();
					m_objItem.m_strSEX_CHR = dtbResult.Rows[0]["SEX_CHR"].ToString().Trim();
					m_objItem.m_strAGE_FLT = dtbResult.Rows[0]["AGE_FLT"].ToString().Trim();
					m_objItem.m_strCHECK_DAT = Convert.ToDateTime(dtbResult.Rows[0]["CHECK_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
					m_objItem.m_strREPORT_DAT = Convert.ToDateTime(dtbResult.Rows[0]["REPORT_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
					m_objItem.m_strDEPT_ID_CHR = dtbResult.Rows[0]["DEPT_ID_CHR"].ToString().Trim();
					m_objItem.m_strDEPT_NAME_VCHR = dtbResult.Rows[0]["DEPT_NAME_VCHR"].ToString().Trim();
					m_objItem.m_intIS_INPATIENT_INT = Convert.ToInt32(dtbResult.Rows[0]["IS_INPATIENT_INT"].ToString().Trim());
					m_objItem.m_strBED_ID_CHR = dtbResult.Rows[0]["BED_ID_CHR"].ToString().Trim();
					m_objItem.m_strBED_NO_CHR = dtbResult.Rows[0]["BED_NO_CHR"].ToString().Trim();
					m_objItem.m_strCLINICAL_DIAGNOSE_VCHR = dtbResult.Rows[0]["CLINICAL_DIAGNOSE_VCHR"].ToString().Trim();
					m_objItem.m_strRHYTHM_VCHR = dtbResult.Rows[0]["RHYTHM_VCHR"].ToString().Trim();
					m_objItem.m_strHEART_RATE_VCHR = dtbResult.Rows[0]["HEART_RATE_VCHR"].ToString().Trim();
					m_objItem.m_strP_R_VCHR = dtbResult.Rows[0]["P_R_VCHR"].ToString().Trim();
					m_objItem.m_strQRS_VCHR = dtbResult.Rows[0]["QRS_VCHR"].ToString().Trim();
					m_objItem.m_strQ_T_VCHR = dtbResult.Rows[0]["Q_T_VCHR"].ToString().Trim();
					m_objItem.m_strSUMMARY1_VCHR = dtbResult.Rows[0]["SUMMARY1_VCHR"].ToString();//.ToString().Trim();
					m_objItem.m_strSUMMARY2_VCHR = dtbResult.Rows[0]["SUMMARY2_VCHR"].ToString();//.ToString().Trim();
					m_objItem.m_strREPORTOR_ID_CHR = dtbResult.Rows[0]["REPORTOR_ID_CHR"].ToString().Trim();
					m_objItem.m_strREPORTOR_NAME_VCHR = dtbResult.Rows[0]["REPORTOR_NAME_VCHR"].ToString().Trim();
					m_objItem.m_strCONFIRMER_ID_CHR = dtbResult.Rows[0]["CONFIRMER_ID_CHR"].ToString().Trim();
					m_objItem.m_strCONFIRMER_NAME_VCHR = dtbResult.Rows[0]["CONFIRMER_NAME_VCHR"].ToString().Trim();
					m_objItem.m_strHEART_ROOM_VCHR = dtbResult.Rows[0]["HEART_ROOM_VCHR"].ToString().Trim();
					m_objItem.m_intSTATUS_INT = Convert.ToInt32(dtbResult.Rows[0]["STATUS_INT"].ToString().Trim());
					m_objItem.m_strOPERATOR_ID_CHR = dtbResult.Rows[0]["OPERATOR_ID_CHR"].ToString().Trim();
					m_objItem.m_strSUMMARY1_XML_VCHR =dtbResult.Rows[0]["SUMMARY1_XML_VCHR"].ToString().Trim();
					m_objItem.m_strSUMMARY2_XML_VCHR =dtbResult.Rows[0]["SUMMARY2_XML_VCHR"].ToString().Trim();
					try
					{
						m_objItem.m_intIsSpicalPatient =int.Parse(dtbResult.Rows[0]["SPECIALFLAG_INT"].ToString().Trim());
					
					}
					catch
					{
						m_objItem.m_intIsSpicalPatient =0;
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
		#region 获取动态心电图信息
		[AutoComplete]
		public long m_mthGetDCARDIOGRAMInfo(System.Security.Principal.IPrincipal p_objPrincipal,string ID,out clsRIS_DCardiogramReport_VO m_objItem)
		{
			m_objItem=null;
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS","m_mthGetDCARDIOGRAMInfo");
			if(lngRes < 0)
			{
				return -1;
			}
			string strSQL = @"SELECT * FROM T_OPR_RIS_DCARDIOGRAM_REPORT WHERE REPORT_ID_CHR ='"+ID+"'";
			try
			{
				DataTable dtbResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
				objHRPSvc.Dispose();
				if(lngRes > 0 && dtbResult.Rows.Count > 0)
				{
					m_objItem=new clsRIS_DCardiogramReport_VO();
					m_objItem.m_strREPORT_ID_CHR = dtbResult.Rows[0]["REPORT_ID_CHR"].ToString().Trim();
					m_objItem.m_strMODIFY_DAT = Convert.ToDateTime(dtbResult.Rows[0]["MODIFY_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
					m_objItem.m_strREPORT_NO_CHR = dtbResult.Rows[0]["REPORT_NO_CHR"].ToString().Trim();
					m_objItem.m_strPATIENT_ID_CHR = dtbResult.Rows[0]["PATIENT_ID_CHR"].ToString().Trim();
					m_objItem.m_strPATIENT_NO_CHR = dtbResult.Rows[0]["PATIENT_NO_CHR"].ToString().Trim();
					m_objItem.m_strINPATIENT_NO_CHR = dtbResult.Rows[0]["INPATIENT_NO_CHR"].ToString().Trim();
					m_objItem.m_strPATIENT_NAME_VCHR = dtbResult.Rows[0]["PATIENT_NAME_VCHR"].ToString().Trim();
					m_objItem.m_strSEX_CHR = dtbResult.Rows[0]["SEX_CHR"].ToString().Trim();
					m_objItem.m_strAGE_FLT = dtbResult.Rows[0]["AGE_FLT"].ToString().Trim();
					m_objItem.m_strREPORT_DAT = Convert.ToDateTime(dtbResult.Rows[0]["REPORT_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
					m_objItem.m_strDEPT_ID_CHR = dtbResult.Rows[0]["DEPT_ID_CHR"].ToString().Trim();
					m_objItem.m_strDEPT_NAME_VCHR = dtbResult.Rows[0]["DEPT_NAME_VCHR"].ToString().Trim();
					m_objItem.m_intIS_INPATIENT_INT = Convert.ToInt32(dtbResult.Rows[0]["IS_INPATIENT_INT"].ToString().Trim());
					m_objItem.m_strBED_ID_CHR = dtbResult.Rows[0]["BED_ID_CHR"].ToString().Trim();
					m_objItem.m_strBED_NO_CHR = dtbResult.Rows[0]["BED_NO_CHR"].ToString().Trim();
					m_objItem.m_strCLINICAL_DIAGNOSE_VCHR = dtbResult.Rows[0]["CLINICAL_DIAGNOSE_VCHR"].ToString().Trim();
					m_objItem.m_strSUMMARY1_VCHR = dtbResult.Rows[0]["SUMMARY1_VCHR"].ToString();//.Trim();
					m_objItem.m_strSUMMARY2_VCHR = dtbResult.Rows[0]["SUMMARY2_VCHR"].ToString();//.Trim();
					m_objItem.m_strREPORTOR_ID_CHR = dtbResult.Rows[0]["REPORTOR_ID_CHR"].ToString().Trim();
					m_objItem.m_strREPORTOR_NAME_VCHR = dtbResult.Rows[0]["REPORTOR_NAME_VCHR"].ToString().Trim();
					m_objItem.m_strCONFIRMER_ID_CHR = dtbResult.Rows[0]["CONFIRMER_ID_CHR"].ToString().Trim();
					m_objItem.m_strCONFIRMER_NAME_VCHR = dtbResult.Rows[0]["CONFIRMER_NAME_VCHR"].ToString().Trim();
					m_objItem.m_strHEART_ROOM_VCHR = dtbResult.Rows[0]["HEART_ROOM_VCHR"].ToString().Trim();
					m_objItem.m_intSTATUS_INT = Convert.ToInt32(dtbResult.Rows[0]["STATUS_INT"].ToString().Trim());
					m_objItem.m_strOPERATOR_ID_CHR = dtbResult.Rows[0]["OPERATOR_ID_CHR"].ToString().Trim();
					m_objItem.m_strCHECKFROM_DAT = Convert.ToDateTime(dtbResult.Rows[0]["CHECKFROM_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
					m_objItem.m_strCHECKTO_DAT = Convert.ToDateTime(dtbResult.Rows[0]["CHECKTO_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
					m_objItem.m_strCHECK_CHANNELS_VCHR = dtbResult.Rows[0]["CHECK_CHANNELS_VCHR"].ToString().Trim();
					m_objItem.m_intGRAPH_TYPE_INT = Convert.ToInt32(dtbResult.Rows[0]["GRAPH_TYPE_INT"].ToString().Trim());
					m_objItem.m_strQRS_TOTAL_CHR = dtbResult.Rows[0]["QRS_TOTAL_CHR"].ToString().Trim();
					m_objItem.m_intHEARTRATE_AVERAGE_INT = Convert.ToInt32(dtbResult.Rows[0]["HEARTRATE_AVERAGE_INT"].ToString().Trim());
					m_objItem.m_intHEARTRATE_MAX_INT = Convert.ToInt32(dtbResult.Rows[0]["HEARTRATE_MAX_INT"].ToString().Trim());
					m_objItem.m_intHEARTRATE_MIN_INT = Convert.ToInt32(dtbResult.Rows[0]["HEARTRATE_MIN_INT"].ToString().Trim());
					m_objItem.m_strHEARTRATE_MAX_DAT = Convert.ToDateTime(dtbResult.Rows[0]["HEARTRATE_MAX_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
					m_objItem.m_strHEARTRATE_MIN_DAT = Convert.ToDateTime(dtbResult.Rows[0]["HEARTRATE_MIN_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
					m_objItem.m_intHEARTRATE_BASE_INT = Convert.ToInt32(dtbResult.Rows[0]["HEARTRATE_BASE_INT"].ToString().Trim());
					
					m_objItem.m_strCHECK_CHANNELS_XML_VCHR=dtbResult.Rows[0]["CHECK_CHANNELS_XML_VCHR"].ToString().Trim();
					m_objItem.m_strCLINICAL_DIAGNOSE_XML_VCHR=dtbResult.Rows[0]["CLINICAL_DIAGNOSE_XML_VCHR"].ToString().Trim();
					m_objItem.m_strSUMMARY1_XML_VCHR=dtbResult.Rows[0]["SUMMARY1_XML_VCHR"].ToString().Trim();
					m_objItem.m_strSUMMARY2_XML_VCHR=dtbResult.Rows[0]["SUMMARY2_XML_VCHR"].ToString().Trim();
					try
					{
						m_objItem.m_intIsSpicalPatient =int.Parse(dtbResult.Rows[0]["SPECIALFLAG_INT"].ToString().Trim());
					
					}
					catch
					{
						m_objItem.m_intIsSpicalPatient =0;
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
		#region 获取TCD脑电图信息
		[AutoComplete]
		public long m_mthGetTCDInfo(System.Security.Principal.IPrincipal p_objPrincipal,string ID,out clsRIS_TCD_REPORT_VO m_objItem)
		{
			m_objItem=null;
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS","m_mthGetTCDInfo");
			if(lngRes < 0)
			{
				return -1;
			}
			string strSQL = @"SELECT * FROM T_OPR_RIS_TCD_REPORT WHERE REPORT_ID_CHR ='"+ID+"'";
			try
			{
				DataTable dtbResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
				objHRPSvc.Dispose();
				if(lngRes > 0 && dtbResult.Rows.Count > 0)
				{
					m_objItem = new clsRIS_TCD_REPORT_VO();
					m_objItem.m_strREPORT_ID_CHR = dtbResult.Rows[0]["REPORT_ID_CHR"].ToString().Trim();
					m_objItem.m_strMODIFY_DAT = Convert.ToDateTime(dtbResult.Rows[0]["MODIFY_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
					m_objItem.m_strREPORT_NO_CHR = dtbResult.Rows[0]["REPORT_NO_CHR"].ToString().Trim();
					m_objItem.m_strPATIENT_ID_CHR = dtbResult.Rows[0]["PATIENT_ID_CHR"].ToString().Trim();
					m_objItem.m_strPATIENT_NO_CHR = dtbResult.Rows[0]["PATIENT_NO_CHR"].ToString().Trim();
					m_objItem.m_strINPATIENT_NO_CHR = dtbResult.Rows[0]["INPATIENT_NO_CHR"].ToString().Trim();
					m_objItem.m_strPATIENT_NAME_VCHR = dtbResult.Rows[0]["PATIENT_NAME_VCHR"].ToString().Trim();
					m_objItem.m_strSEX_CHR = dtbResult.Rows[0]["SEX_CHR"].ToString().Trim();
					m_objItem.m_strAGE_FLT = dtbResult.Rows[0]["AGE_FLT"].ToString().Trim();
					m_objItem.m_strCHECK_DAT = Convert.ToDateTime(dtbResult.Rows[0]["CHECK_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
					m_objItem.m_strREPORT_DAT = Convert.ToDateTime(dtbResult.Rows[0]["REPORT_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
					m_objItem.m_strDEPT_ID_CHR = dtbResult.Rows[0]["DEPT_ID_CHR"].ToString().Trim();
					m_objItem.m_strDEPT_NAME_VCHR = dtbResult.Rows[0]["DEPT_NAME_VCHR"].ToString().Trim();
					m_objItem.m_intIS_INPATIENT_INT = Convert.ToInt32(dtbResult.Rows[0]["IS_INPATIENT_INT"].ToString().Trim());
					m_objItem.m_strBED_ID_CHR = dtbResult.Rows[0]["BED_ID_CHR"].ToString().Trim();
					m_objItem.m_strBED_NO_CHR = dtbResult.Rows[0]["BED_NO_CHR"].ToString().Trim();
					m_objItem.m_strSUMMARY1_VCHR = dtbResult.Rows[0]["SUMMARY1_VCHR"].ToString().Trim();
					m_objItem.m_strSUMMARY2_VCHR = dtbResult.Rows[0]["SUMMARY2_VCHR"].ToString().Trim();
					m_objItem.m_strREPORTOR_ID_CHR = dtbResult.Rows[0]["REPORTOR_ID_CHR"].ToString().Trim();
					m_objItem.m_strREPORTOR_NAME_VCHR = dtbResult.Rows[0]["REPORTOR_NAME_VCHR"].ToString().Trim();
					m_objItem.m_strCONFIRMER_ID_CHR = dtbResult.Rows[0]["CONFIRMER_ID_CHR"].ToString().Trim();
					m_objItem.m_strCONFIRMER_NAME_VCHR = dtbResult.Rows[0]["CONFIRMER_NAME_VCHR"].ToString().Trim();
					m_objItem.m_intSTATUS_INT = Convert.ToInt32(dtbResult.Rows[0]["STATUS_INT"].ToString().Trim());
					m_objItem.m_strOPERATOR_ID_CHR = dtbResult.Rows[0]["OPERATOR_ID_CHR"].ToString().Trim();
					m_objItem.m_strSUMMARY1_XML_VCHR =dtbResult.Rows[0]["SUMMARY1_XML_VCHR"].ToString().Trim();
					m_objItem.m_strSUMMARY2_XML_VCHR =dtbResult.Rows[0]["SUMMARY2_XML_VCHR"].ToString().Trim();
					m_objItem.m_strDIAGNOSE_VCHR = dtbResult.Rows[0]["DIAGNOSE_VCHR"].ToString().Trim();
					m_objItem.m_strDIAGNOSE_XML_VCHR = dtbResult.Rows[0]["DIAGNOSE_XML_VCHR"].ToString().Trim();
					m_objItem.m_strCURE_CIRCS_VCHR = dtbResult.Rows[0]["CURE_CIRCS_VCHR"].ToString().Trim();
					m_objItem.m_strCURE_CIRCS_XML_VCHR =dtbResult.Rows[0]["CURE_CIRCS_XML_VCHR"].ToString().Trim();
					m_objItem.m_strCT_RESULT_VCHR = dtbResult.Rows[0]["CT_RESULT_VCHR"].ToString().Trim();
					m_objItem.m_strCT_RESULT_XML_VCHR = dtbResult.Rows[0]["CT_RESULT_XML_VCHR"].ToString().Trim();
					m_objItem.m_strMRI_RESULT_VCHR = dtbResult.Rows[0]["MRI_RESULT_VCHR"].ToString().Trim();
					m_objItem.m_strMRI_RESULT_XML_VCHR =dtbResult.Rows[0]["MRI_RESULT_XML_VCHR"].ToString().Trim();
					m_objItem.m_strX_RAY_RESULT_VCHR =dtbResult.Rows[0]["X_RAY_RESULT_VCHR"].ToString().Trim();
					m_objItem.m_strX_RAY_RESULT_XML_VCHR = dtbResult.Rows[0]["X_RAY_RESULT_XML_VCHR"].ToString().Trim();
					m_objItem.m_strEKG_RESULT_VCHR = dtbResult.Rows[0]["EKG_RESULT_VCHR"].ToString().Trim();
					m_objItem.m_strEKG_RESULT_XML_VCHR = dtbResult.Rows[0]["EKG_RESULT_XML_VCHR"].ToString().Trim();
					m_objItem.m_strBUS_RESULT_VCHR =dtbResult.Rows[0]["BUS_RESULT_VCHR"].ToString().Trim();
					m_objItem.m_strBUS_RESULT_XML_VCHR =dtbResult.Rows[0]["BUS_RESULT_XML_VCHR"].ToString().Trim();


					
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
		#region 获取EEG脑电图信息
		[AutoComplete]
		public long m_mthGetEEGInfo(System.Security.Principal.IPrincipal p_objPrincipal,string ID,out clsRIS_EEG_REPORT_VO m_objItem)
		{
			m_objItem=null;
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS","m_mthGetEEGInfo");
			if(lngRes < 0)
			{
				return -1;
			}
			string strSQL = @"SELECT * FROM T_OPR_RIS_EEG_REPORT WHERE REPORT_ID_CHR ='"+ID+"'";
			try
			{
				DataTable dtbResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
				objHRPSvc.Dispose();
				if(lngRes > 0 && dtbResult.Rows.Count > 0)
				{
					m_objItem = new clsRIS_EEG_REPORT_VO();
					m_objItem.m_strREPORT_ID_CHR = dtbResult.Rows[0]["REPORT_ID_CHR"].ToString().Trim();
					m_objItem.m_strMODIFY_DAT = Convert.ToDateTime(dtbResult.Rows[0]["MODIFY_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
					m_objItem.m_strREPORT_NO_CHR = dtbResult.Rows[0]["REPORT_NO_CHR"].ToString().Trim();
					m_objItem.m_strPATIENT_ID_CHR = dtbResult.Rows[0]["PATIENT_ID_CHR"].ToString().Trim();
					m_objItem.m_strPATIENT_NO_CHR = dtbResult.Rows[0]["PATIENT_NO_CHR"].ToString().Trim();
					m_objItem.m_strINPATIENT_NO_CHR = dtbResult.Rows[0]["INPATIENT_NO_CHR"].ToString().Trim();
					m_objItem.m_strPATIENT_NAME_VCHR = dtbResult.Rows[0]["PATIENT_NAME_VCHR"].ToString().Trim();
					m_objItem.m_strSEX_CHR = dtbResult.Rows[0]["SEX_CHR"].ToString().Trim();
					m_objItem.m_strAGE_FLT = dtbResult.Rows[0]["AGE_FLT"].ToString().Trim();
					m_objItem.m_strCHECK_DAT = Convert.ToDateTime(dtbResult.Rows[0]["CHECK_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
					m_objItem.m_strREPORT_DAT = Convert.ToDateTime(dtbResult.Rows[0]["REPORT_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
					m_objItem.m_strDEPT_ID_CHR = dtbResult.Rows[0]["DEPT_ID_CHR"].ToString().Trim();
					m_objItem.m_strDEPT_NAME_VCHR = dtbResult.Rows[0]["DEPT_NAME_VCHR"].ToString().Trim();
					m_objItem.m_intIS_INPATIENT_INT = Convert.ToInt32(dtbResult.Rows[0]["IS_INPATIENT_INT"].ToString().Trim());
					m_objItem.m_strBED_ID_CHR = dtbResult.Rows[0]["BED_ID_CHR"].ToString().Trim();
					m_objItem.m_strBED_NO_CHR = dtbResult.Rows[0]["BED_NO_CHR"].ToString().Trim();
					m_objItem.m_strSUMMARY1_VCHR = dtbResult.Rows[0]["SUMMARY1_VCHR"].ToString().Trim();
					m_objItem.m_strSUMMARY2_VCHR = dtbResult.Rows[0]["SUMMARY2_VCHR"].ToString().Trim();
					m_objItem.m_strREPORTOR_ID_CHR = dtbResult.Rows[0]["REPORTOR_ID_CHR"].ToString().Trim();
					m_objItem.m_strREPORTOR_NAME_VCHR = dtbResult.Rows[0]["REPORTOR_NAME_VCHR"].ToString().Trim();
					m_objItem.m_strCONFIRMER_ID_CHR = dtbResult.Rows[0]["CONFIRMER_ID_CHR"].ToString().Trim();
					m_objItem.m_strCONFIRMER_NAME_VCHR = dtbResult.Rows[0]["CONFIRMER_NAME_VCHR"].ToString().Trim();
					m_objItem.m_intSTATUS_INT = Convert.ToInt32(dtbResult.Rows[0]["STATUS_INT"].ToString().Trim());
					m_objItem.m_strOPERATOR_ID_CHR = dtbResult.Rows[0]["OPERATOR_ID_CHR"].ToString().Trim();
					m_objItem.m_strSUMMARY1_XML_VCHR = dtbResult.Rows[0]["SUMMARY1_XML_VCHR"].ToString().Trim();
					m_objItem.m_strSUMMARY2_XML_VCHR = dtbResult.Rows[0]["SUMMARY2_XML_VCHR"].ToString().Trim();
					m_objItem.m_strDIAGNOSE_VCHR = dtbResult.Rows[0]["DIAGNOSE_VCHR"].ToString().Trim();
					m_objItem.m_strDIAGNOSE_XML_VCHR = dtbResult.Rows[0]["DIAGNOSE_XML_VCHR"].ToString().Trim();
					m_objItem.m_strLEFT_RIGHT = dtbResult.Rows[0]["LEFT_RIGHT"].ToString().Trim();
					m_objItem.m_strBEFORE_CHECK = dtbResult.Rows[0]["BEFORE_CHECK"].ToString().Trim();
					m_objItem.m_strBODY_STAT = dtbResult.Rows[0]["BODY_STAT"].ToString().Trim();
					m_objItem.m_strSENSE_STAT = dtbResult.Rows[0]["SENSE_STAT"].ToString().Trim();
					m_objItem.m_strDRUG_STAT = dtbResult.Rows[0]["DRUG_STAT"].ToString().Trim();

					
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
		#region 获取Pacs脑电图信息
		[AutoComplete]
		public long m_mthGetPacsInfo(System.Security.Principal.IPrincipal p_objPrincipal,string ID,out clsImageReportPrintValue m_objItem)
		{
			m_objItem=null;
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS","m_mthGetPacsInfo");
			if(lngRes < 0)
			{
				return -1;
			}
			string strSQL = @"SELECT * FROM IMAGEREPORT WHERE REPORTID ='"+ID+"'";
			try
			{
				DataTable dtbResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
				//				objHRPSvc.Dispose();
				if(lngRes > 0 && dtbResult.Rows.Count > 0)
				{
					m_objItem = new clsImageReportPrintValue();
					m_objItem.m_strHospitalName="佛山市第二人民医院";

					m_objItem.m_strReportTitle="诊断报告书";

					m_objItem.m_strOrderNO=dtbResult.Rows[0]["ORDER_NO_CHR"].ToString();
					m_objItem.m_strReportID=ID;
					m_objItem.m_strPatientName=dtbResult.Rows[0]["PATIENTNAME"].ToString();
					m_objItem.m_strPatientSex=dtbResult.Rows[0]["PATIENTSEX"].ToString();
					m_objItem.m_strPatientAge=dtbResult.Rows[0]["PATIENTAGE"].ToString();
					m_objItem.m_strOffice=dtbResult.Rows[0]["REQUESTOFFICENAME"].ToString();
					m_objItem.m_strBedNO=dtbResult.Rows[0]["BEDNO"].ToString();
					m_objItem.m_strExamineDate=dtbResult.Rows[0]["EXAMINEDATE"].ToString();
					m_objItem.m_strExamineName=dtbResult.Rows[0]["EXAMINENAME"].ToString();			
					m_objItem.m_strLayerThickness=dtbResult.Rows[0]["LAYERTHICKNESS"].ToString()+"mm";	
					m_objItem.m_strLayerDistance=dtbResult.Rows[0]["LAYERDISTANCE"].ToString()+"mm";
					m_objItem.m_strClinicDiagnose=dtbResult.Rows[0]["CLINICEXAMINE"].ToString();
					m_objItem.m_strExamineDesc=dtbResult.Rows[0]["EXAMINEDESC"].ToString();
					m_objItem.m_strExamineDescXML=dtbResult.Rows[0]["EXAMINEDESCXML"].ToString();
					m_objItem.m_strExaminePrompt=dtbResult.Rows[0]["EXAMINEPROMPT"].ToString();
					m_objItem.m_strExaminePromptXML=dtbResult.Rows[0]["EXAMINEPROMPTXML"].ToString();
					m_objItem.m_strReportDoctor=dtbResult.Rows[0]["REPORTDOCTORNAME"].ToString();
					m_objItem.m_strReportDate=dtbResult.Rows[0]["REPORTDATE"].ToString();
					m_objItem.m_strCTNO="";
					m_objItem.m_strXRayNO="";
					m_objItem.m_strMRINO="";
					m_objItem.m_strPatientNO=dtbResult.Rows[0]["PATIENTID"].ToString();
					m_objItem.m_strInHospitalNO=dtbResult.Rows[0]["INHOSPITALNO"].ToString();

					m_objItem.m_strConfirmDoctor=dtbResult.Rows[0]["ADUITDOCTORNAME"].ToString();
					m_objItem.m_strConfirmDate=dtbResult.Rows[0]["ADUITDATE"].ToString();

					m_objItem.m_strCTNO=dtbResult.Rows[0]["CTNO"].ToString();
					m_objItem.m_strXRayNO=dtbResult.Rows[0]["XRAYNO"].ToString();		
					m_objItem.m_strMRINO=dtbResult.Rows[0]["MRINO"].ToString();
					m_objItem.m_strImageSeq="";
					//					m_objItem.m_imageBadges = "";
					
				}
				strSQL = @"SELECT * FROM IMAGEREPORT_PICTURE WHERE REPORTID ='"+ID+"'";
				dtbResult = new DataTable();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
				objHRPSvc.Dispose();
				if(lngRes>0&&dtbResult.Rows.Count>0)
				{
					clsImageReportPicture[] p_objPicArr=new clsImageReportPicture[dtbResult.Rows.Count];
					for(int i=0; i<dtbResult.Rows.Count; i++)
					{
						p_objPicArr[i] = new clsImageReportPicture();
						p_objPicArr[i].m_intIndexNO = com.digitalwave.Utility.clsMiscTools.ToInt(dtbResult.Rows[i]["IndexNO"]);
						p_objPicArr[i].m_strPictureID = dtbResult.Rows[i]["PictureID"].ToString().Trim();
						p_objPicArr[i].m_strReportID = dtbResult.Rows[i]["ReportID"].ToString().Trim();
						p_objPicArr[i].m_objImage = m_mthConvertByte2Image((byte[])dtbResult.Rows[i]["PicData"]);
						p_objPicArr[i].m_intPictureFlag=Convert.ToInt32(dtbResult.Rows[i]["PICTUREFLAG"]);
					}
					m_objItem.m_objImages=p_objPicArr;
					m_objItem.m_szImage=clsImageReportPicture.m_szGetLargestSize(m_objItem.m_objImages);
				}
				else
				{
					m_objItem.m_objImages=null;
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
		#region 根据病历号取得处方信息
		[AutoComplete]
		public long m_mthGetRecipeInfoByCaseHistoryID(string strCaseHistoryID,out DataTable dt)
		{
			dt=new DataTable();
			long lngRes=0;
			
			string strSQL = @"SELECT aa.*,cc.SEQID_CHR
  FROM (SELECT a.outpatrecipeid_chr, a.itemid_chr itemid, a.unitid_chr unit,
               a.tolqty_dec quantity, a.unitprice_mny price,
               a.tolprice_mny summoney, a.rowno_chr, a.usageid_chr,
               a.freqid_chr, a.qty_dec, a.days_int, a.itemname_vchr itemname,
               a.itemspec_vchr DEC, '' AS sumusage_vchr,
               b.itemopinvtype_chr invtype, b.itemcatid_chr catid,
               a.dosageunit_chr, b.selfdefine_int selfdefine, 1 times,
               b.itemipunit_chr,
               ROUND (b.itemprice_mny / b.packqty_dec, 4) submoney,
               b.opchargeflg_int, b.itemopcalctype_chr, a.discount_dec,
               b.itemcode_vchr, c.usagename_vchr, d.freqname_chr
          FROM t_tmp_outpatientpwmrecipede a,
               t_bse_chargeitem b,
               t_bse_usagetype c,
               t_aid_recipefreq d
         WHERE a.itemid_chr = b.itemid_chr(+) AND a.usageid_chr = c.usageid_chr(+)
               AND a.freqid_chr = d.freqid_chr(+)
        UNION ALL
        SELECT a.outpatrecipeid_chr, a.itemid_chr itemid, a.unitid_chr unit,
               a.min_qty_dec quantity, a.unitprice_mny price,
               a.tolprice_mny summoney, a.rowno_chr as rowno_chr, a.usageid_chr,
               '' AS freqid_chr, min_qty_dec AS qty_dec, 1 AS days_int,
               a.itemname_vchr itemname, a.itemspec_vchr DEC, a.sumusage_vchr,
               b.itemopinvtype_chr invtype, b.itemcatid_chr catid,
               b.dosageunit_chr, b.selfdefine_int selfdefine,
               a.times_int times, '', 1, 0, b.itemopcalctype_chr,
               a.discount_dec, b.itemcode_vchr, c.usagename_vchr, ''
          FROM t_tmp_outpatientcmrecipede a,
               t_bse_chargeitem b,
               t_bse_usagetype c
         WHERE a.itemid_chr = b.itemid_chr(+) AND a.usageid_chr = c.usageid_chr(+)
        UNION ALL
        SELECT a.outpatrecipeid_chr, a.itemid_chr itemid, a.itemunit_vchr unit,
               a.qty_dec quantity, a.price_mny price, a.tolprice_mny summoney,
               a.rowno_chr as rowno_chr, '' AS usageid_chr, '' AS freqid_chr, 0 AS qty_dec,
               1 AS days_int, a.itemname_vchr itemname, a.itemspec_vchr DEC,
               '' AS sumusage_vchr, b.itemopinvtype_chr invtype,
               b.itemcatid_chr catid, b.dosageunit_chr,
               b.selfdefine_int selfdefine, 1 times, '', 1, 0,
               b.itemopcalctype_chr, a.discount_dec, b.itemcode_vchr, '', ''
          FROM t_tmp_outpatientchkrecipede a, t_bse_chargeitem b
         WHERE a.itemid_chr = b.itemid_chr(+)
        UNION ALL
        SELECT a.outpatrecipeid_chr, a.itemid_chr itemid, a.itemunit_vchr unit,
               a.qty_dec quantity, a.price_mny price, a.tolprice_mny summoney,
               a.rowno_chr as rowno_chr, '' AS usageid_chr, '' AS freqid_chr, 0 AS qty_dec,
               1 AS days_int, a.itemname_vchr itemname, a.itemspec_vchr DEC,
               '' AS sumusage_vchr, b.itemopinvtype_chr invtype,
               b.itemcatid_chr catid, b.dosageunit_chr,
               b.selfdefine_int selfdefine, 1 times, '', 1, 0,
               b.itemopcalctype_chr, a.discount_dec, b.itemcode_vchr, '', ''
          FROM t_tmp_outpatienttestrecipede a, t_bse_chargeitem b
         WHERE a.itemid_chr = b.itemid_chr(+)
        UNION ALL
        SELECT a.outpatrecipeid_chr, a.itemid_chr itemid, a.itemunit_vchr unit,
               a.qty_dec quantity, a.unitprice_mny price,
               a.tolprice_mny summoney, a.rowno_chr as rowno_chr, '' AS usageid_chr,
               '' AS freqid_chr, 0 AS qty_dec, 1 AS days_int,
               a.itemname_vchr itemname, a.itemspec_vchr DEC,
               '' AS sumusage_vchr, b.itemopinvtype_chr invtype,
               b.itemcatid_chr catid, b.dosageunit_chr,
               b.selfdefine_int selfdefine, 1 times, '', 1, 0,
               b.itemopcalctype_chr, a.discount_dec, b.itemcode_vchr, '', ''
          FROM t_tmp_outpatientothrecipede a, t_bse_chargeitem b
         WHERE a.itemid_chr = b.itemid_chr(+)
        UNION ALL
        SELECT a.outpatrecipeid_chr, a.itemid_chr itemid, a.itemunit_vchr unit,
               a.qty_dec quantity, a.price_mny price, a.tolprice_mny summoney,
               a.rowno_chr as rowno_chr, '' AS usageid_chr, '' AS freqid_chr, 0 AS qty_dec,
               1 AS days_int, a.itemname_vchr itemname, a.itemspec_vchr DEC,
               '' AS sumusage_vchr, b.itemopinvtype_chr invtype,
               b.itemcatid_chr catid, b.dosageunit_chr,
               b.selfdefine_int selfdefine, 1 times, '', 1, 0,
               b.itemopcalctype_chr, a.discount_dec, b.itemcode_vchr, '', ''
          FROM t_tmp_outpatientopsrecipede a, t_bse_chargeitem b
         WHERE a.itemid_chr = b.itemid_chr(+)) aa,
       (SELECT *
          FROM t_opr_outpatientrecipe
         WHERE pstauts_int <> '-1' and casehisid_chr = '" + strCaseHistoryID+@"') bb,
       T_OPR_OUTPATIENTCASEHISCHR cc
 WHERE aa.outpatrecipeid_chr = bb.outpatrecipeid_chr
   AND aa.invtype = cc.TYPEID_CHR(+) order by aa.outpatrecipeid_chr
  
"; //AND cc.SEQID_CHR = '1'
			try
			{
				
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
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
}
