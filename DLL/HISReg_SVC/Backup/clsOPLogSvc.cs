using System;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
using System.EnterpriseServices;
using System.Data;
using System.Collections;
using System.Text;
namespace com.digitalwave.iCare.middletier.HIS
{
	
	/// <summary>
	/// 门诊日志报表
	/// </summary>
	[Transaction(TransactionOption.Required)]
	[ObjectPooling(true)]
	public class clsOPLogSvc:com.digitalwave.iCare.middletier.clsMiddleTierBase
	{
		public clsOPLogSvc()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region 查找对应表信息
		[AutoComplete]
		public long m_mthLogData(out DataTable dt,string strEx,string strICDCode)
		{
			dt=new DataTable();
			long lngRes=0;
			string strSubSQL ="";
			string strSubSQL2 ="";
			if(strICDCode!="")
			{
			strSubSQL=",(SELECT DISTINCT CASEHISID_CHR FROM t_opr_opch_icd10 WHERE UpPER(ICDCODE_VCHR) like '%"+strICDCode.ToUpper()+"%')F";
			strSubSQL2 =" AND A.casehisid_chr =F.casehisid_chr";
			}
			string strSQL = @"SELECT recorddate_dat, recorddate_dat AS changdate_dat, lastname_vchr,
        diag_vchr as  patientcardid_chr, woman, man, age, homeaddress_vchr,
       contactpersonfirstname_vchr, occupation_vchr,OUTPATRECIPEID_CHR,ICDCODE,
       CASE
          WHEN type_int != 2 AND minOUTPATRECIPEID =OUTPATRECIPEID_CHR
             THEN '√'
          ELSE ''
       END AS starttype,
        CASE
          WHEN type_int != 2 AND minOUTPATRECIPEID !=OUTPATRECIPEID_CHR
             THEN '√'
          ELSE ''
       END AS secondtype,
       case when type_int=2 then '√' else '' end as exigenceType from(SELECT to_char(ROWNUM) AS rowno, to_char(a.CREATEDATE_DAT,'yyyy-mm-dd') recorddate_dat, b.lastname_vchr,a.outpatrecipeid_chr,
      to_char( FLOOR (MONTHS_BETWEEN (SYSDATE, b.birth_dat) / 12)) AS age, case when trim(b.sex_chr)='男' then '√' else '' end as Man, case when trim(b.sex_chr)='女' then '√' else '' end as woMan,a.type_int,
       c.diag_vchr, d.patientcardid_chr, e.paytypename_vchr, '' AS icdcode,a.casehisid_chr,b.HOMEADDRESS_VCHR,b.CONTACTPERSONFIRSTNAME_VCHR,b.OCCUPATION_VCHR,(SELECT min(OUTPATRECIPEID_CHR)
                  FROM t_opr_outpatientrecipe k
                 WHERE k.pstauts_int = 2
                   AND k.patientid_chr = a.patientid_chr) AS minOUTPATRECIPEID
  FROM t_opr_outpatientrecipe a,
       t_bse_patient b,
       t_opr_outpatientcasehis c,
       t_bse_patientcard d,
       t_bse_patientpaytype e"+
				strSubSQL+
 @" WHERE a.pstauts_int = 2
   AND a.patientid_chr = b.patientid_chr(+)
   AND a.casehisid_chr = c.casehisid_chr(+)
   AND a.patientid_chr = d.patientid_chr(+)
   AND a.paytypeid_chr = e.paytypeid_chr(+)" +strSubSQL2+ strEx+"  order by a.CREATEDATE_DAT)";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dt);
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
