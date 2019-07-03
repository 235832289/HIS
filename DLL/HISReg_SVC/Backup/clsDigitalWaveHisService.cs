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
	/// clsDigitalWaveHisService 的摘要说明。
	/// </summary>
	[Transaction(TransactionOption.Required)]
	[ObjectPooling(true)]
	public class clsDigitalWaveHisService:com.digitalwave.iCare.middletier.clsMiddleTierBase
	{
		public clsDigitalWaveHisService()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		[AutoComplete]
		public long m_mthCancellationRecipe(string strEx)
		{
			long lngRes=0;		
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			string strSQL = @"select SETSTATUS_INT from T_SYS_SETTING where SETID_CHR ='0028'";
			
				DataTable tempdt =new DataTable();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref tempdt);
				bool flag =false;
				if(lngRes>0&&tempdt.Rows.Count>0)
				{
					if(tempdt.Rows[0][0].ToString().Trim() =="1")
					{
						flag =true;
					}
				}
			try
			{
				if(flag)
				{
					DateTime d1 =DateTime.Now.AddHours(-12);
					strSQL = @"update T_OPR_OUTPATIENTRECIPE set PSTAUTS_INT = -1 WHERE recorddate_dat <
                       TO_DATE ('"+d1.ToString("yyyy-MM-dd HH:mm:ss")+"', 'yyyy-mm-dd hh24:mi:ss') and (PSTAUTS_INT =4 or PSTAUTS_INT =1)";
		
					lngRes = objHRPSvc.DoExcute(strSQL);
					objHRPSvc.Dispose();
					
				}
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
	}
}
