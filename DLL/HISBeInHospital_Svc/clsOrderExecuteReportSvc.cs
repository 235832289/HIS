using System;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
namespace com.digitalwave.iCare.middletier.HIS
{
	/// <summary>
	/// 医嘱执行单报表中间件
	/// </summary>
	[System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
	[ObjectPooling(true)]
	public class clsOrderExecuteReportSvc: com.digitalwave.iCare.middletier.clsMiddleTierBase
	{
		public clsOrderExecuteReportSvc()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region 根据病人卡号获取住院号
		[AutoComplete]
		public long m_mthGetInHospitalIDByCardID(string strCardID,string strEx,out DataTable dt,int Flag)
		{
			
			long lngRes=0;
			dt  =new DataTable();
			string strSQL  ="";
			if(Flag==1)//用卡号查询
			{
				 strSQL = @"
SELECT b.registerid_chr, c.lastname_vchr, c.sex_chr,
       TO_CHAR (SYSDATE, 'yyyy') - TO_CHAR (c.birth_dat, 'yyyy') age
  FROM t_bse_patientcard a, t_opr_bih_register b, t_bse_patient c
 WHERE a.patientid_chr = b.patientid_chr
   AND a.status_int = 1
   AND a.patientid_chr = c.patientid_chr(+)
   AND a.patientcardid_chr = '"+strCardID+"'";
			}
			else//用住院号查询
			{
				strSQL = @"SELECT b.registerid_chr, c.lastname_vchr, c.sex_chr,
       TO_CHAR (SYSDATE, 'yyyy') - TO_CHAR (c.birth_dat, 'yyyy') age
  FROM  t_opr_bih_register b, t_bse_patient c
 WHERE b.patientid_chr = c.patientid_chr(+)
 and b.STATUS_INT =1
   AND b.registerid_chr = '"+strCardID+"'";
			}
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objService = new clsHRPTableService();
				lngRes = objService.DoGetDataTable(strSQL,ref dt);
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
		#region 根据住院号和时间段查找医嘱执行单
		public long m_mthOrderExecuteData(string strInHospitalID,DateTime date1,DateTime date2,out DataTable dt)
		{
				long lngRes=0;
				dt  =new DataTable();
			string strSQL = @"SELECT   Max(to_char(A.createdate_dat,'yyyy-mm-dd')) CreatDate
    FROM t_opr_bih_orderexecute A,T_OPR_BIH_ORDER B
    where a.orderid_chr =b.orderid_chr(+)
    and a.STATUS_INT =1
	AND a.createdate_dat > TO_DATE ('"+date1.ToString("yyyy-MM-dd 00:00:00")+@"', 'YYYY-MM-DD HH24:MI:SS')
    AND a.createdate_dat < TO_DATE ('"+date2.ToString("yyyy-MM-dd 23:59:59")+@"', 'YYYY-MM-DD HH24:MI:SS')
    and b.registerid_chr ='"+strInHospitalID+@"'
GROUP BY TRUNC (A.createdate_dat)";
			
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objService = new clsHRPTableService();
				lngRes = objService.DoGetDataTable(strSQL,ref dt);
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
		#region 查找报表数据
		public long m_mthFindReportData(string strInHospitalID,string p_date,out DataTable dt)
		{
			long lngRes=0;
			DateTime date=DateTime.Now;
			try
			{
			date =DateTime.Parse(p_date);
			}
			catch
			{
			
			}
			dt  =new DataTable();
			string strSQL = @"SELECT d.code_chr AS bed, e.lastname_vchr AS NAME,
       DECODE (b.executetype_int, 1, '长嘱', 2, '临嘱', '') AS exetype,
       b.name_vchr AS itemname, b.dosage_dec AS usecount,
       b.dosetypename_chr AS useway, a.executedate_vchr AS excutetime
  FROM t_opr_bih_orderexecute a,
       t_opr_bih_order b,
       t_opr_bih_register c,
       t_bse_bed d,
       t_bse_patient e
 WHERE a.orderid_chr = b.orderid_chr(+)
   AND b.registerid_chr = c.registerid_chr(+)
   AND c.bedid_chr = d.bedid_chr(+)
   AND b.patientid_chr = e.patientid_chr(+)
   AND a.status_int = 1
	AND a.createdate_dat > TO_DATE ('"+date.ToString("yyyy-MM-dd 00:00:00")+@"', 'YYYY-MM-DD HH24:MI:SS')
    AND a.createdate_dat < TO_DATE ('"+date.ToString("yyyy-MM-dd 23:59:59")+@"', 'YYYY-MM-DD HH24:MI:SS')
    and b.registerid_chr ='"+strInHospitalID+@"'";

			
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objService = new clsHRPTableService();
				lngRes = objService.DoGetDataTable(strSQL,ref dt);
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

        #region	TextList获取数据	glzhang	2005.04.11
        /// <summary>
        /// TextList获取数据	glzhang	2005.04.11
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strSQL"></param>
        /// <param name="p_dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetTextListData(System.Security.Principal.IPrincipal p_objPrincipal, string p_strSQL, out DataTable p_dtbResult)
        {
            p_dtbResult = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngGetTurnInPatienList");
            if (lngRes < 0)
            {
                return -1;
            }
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(p_strSQL, ref p_dtbResult);
                objHRPSvc.Dispose();
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
