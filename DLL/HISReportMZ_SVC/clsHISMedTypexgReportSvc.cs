using System;
using System.Data;
using System.EnterpriseServices;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll

namespace com.digitalwave.iCare.middletier.HIS.Reports
{
	/// <summary>
	/// clsHISMedTypeReport ��ժҪ˵����
	/// </summary>
	[Transaction(TransactionOption.Required)]
	[ObjectPooling(Enabled=true)]
	public class clsHISMedTypexgReportSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
	{
		#region ���캯��
		/// <summary>
		/// ���캯��
		/// </summary>
		public clsHISMedTypexgReportSvc()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		#endregion
		#region ��ȡ���ݿ���Ϣ
		/// <summary>
		/// 
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_strStartDate">yyyy-mm-dd</param>
		/// <param name="p_strEndDate">yyyy-mm-dd</param>
		/// <param name="p_outDatatable"></param>
		/// <returns></returns>
		// ע�⣺Ҫ��ʾ�������ֶ������������ݼ�dataset���ֶ�����ͬ
		[AutoComplete]
		public long m_lngGetMedReport(string p_dtpStartDate, string p_dtpEndDate,out  DataTable p_outDatatable)
		{
			long lngRes=0;
			p_outDatatable = null;
			try
			{
				string strSQL=@"SELECT    t2.typename_vchr AS itemname,SUM (b.tolfee_mny) AS TOLFEE_MNY
            FROM t_opr_outpatientrecipeinvde b,
                 t_opr_outpatientrecipeinv a,
                 t_bse_chargeitemextype t2
           WHERE b.invoiceno_vchr = a.invoiceno_vchr and b.itemcatid_chr = t2.typeid_chr  and  t2.flag_int='2'";
				strSQL+=@"  AND a.recorddate_dat BETWEEN TO_DATE ('"+p_dtpStartDate+"', 'yyyy-mm-dd hh24:mi:ss' )";
				strSQL+=@"                     AND TO_DATE ('"+p_dtpEndDate+"', 'yyyy-mm-dd hh24:mi:ss' )";
				strSQL+=@"   AND a.balanceflag_int = 1 and  t2.flag_int='2' 
        GROUP BY t2.typename_vchr";
				//order by TOLFEE_MNY";
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes=objHRPSvc.DoGetDataTable(strSQL,ref p_outDatatable);
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
