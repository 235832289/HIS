using System;
using System.Data;
using System.EnterpriseServices;
using System.Collections;
using System.Security.Principal;
using Microsoft.VisualBasic;
using com.digitalwave.Utility; //Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll

namespace com.digitalwave.iCare.middletier.LIS
{
    /// <summary>
    /// 接口服务类
    /// </summary>
    [Transaction(TransactionOption.Required)]
    [ObjectPooling(Enabled = true)]
    public class clsLisInterfaceSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase//MiddleTierBase.dll
    {
        

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AutoComplete]
        public long CreateApplicationArray(clsLisApplyAppliationInfo[] arrApplication)
        {
            foreach (clsLisApplyAppliationInfo applicationInfo in arrApplication)
            {
                
            }

            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AutoComplete]
        public long CreateSendApplicationArray(clsLisApplyAppliationInfo[] arrApplication, bool isSended)
        {
            foreach (clsLisApplyAppliationInfo applicationInfo in arrApplication)
            {

            }

            return 0;
        }
    }
}
