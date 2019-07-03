using System;
using System.EnterpriseServices;
using com.digitalwave.iCare.middletier.HRPService;	//HRPService.dll

namespace com.digitalwave.iCare.middletier.HIS
{
	/// <summary>
	/// 生成IDataParameter 数组的辅助类
	/// </summary>
	[Transaction(TransactionOption.Required)]
	[ObjectPooling(true)]
	public class clsIDataParameterCreator
	{
		[AutoComplete]
		public static System.Data.IDataParameter[] s_objConstructIDataParameterArr(params object[] p_objParamArr)
		{
			if(p_objParamArr.Length == 0)
				return null;

			int intLength = p_objParamArr.Length;
			System.Data.IDataParameter[] objReqCheckDetailArr= null;
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			objHRPSvc.CreateDatabaseParameter(intLength,out objReqCheckDetailArr);
			objHRPSvc.Dispose();

			for(int i=0;i<intLength;i++)
			{
				objReqCheckDetailArr[i].Value = p_objParamArr[i];
			}

			return objReqCheckDetailArr;
		}
	}
}
