using System;
using System.Data;
using System.EnterpriseServices;
using System.Collections;
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
using com.digitalwave.Utility;//Utility.dll

namespace com.digitalwave.iCare.middletier.LIS
{
	/// <summary>
	/// 
	/// </summary>
	[Transaction(TransactionOption.Required)]
	[ObjectPooling(true)]
    public class clsBnsQCBatchSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
	{
        #region 为数据模型加载数据       
        //[AutoComplete]
        //public long m_lngLoadData(System.Security.Principal.IPrincipal p_objPrincipal,
        //    int p_intQCBatchSeq, DateTime p_dtpDateStart, DateTime p_DateEnd,
        //    out clsLisConcentrationVO[] p_objConcentrations,
        //    out clsLisQCDataVO[] p_objDatas)
        //{
        //    long lngRes = 0;
        //    clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //    lngRes = objPrivilege.m_lngCheckCallPrivilege
        //        (p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsBnsQCBatchSvc", "m_lngLoadData");
        //    if (lngRes <= 0)
        //    {
        //        return -1;
        //    }

        //    try
        //    {
                
        //    }
        //    catch (Exception objEx)
        //    {
        //        com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //        objLogger.LogError(objEx);
        //    }
        //    return lngRes;
        //}
        #endregion       
	}
}