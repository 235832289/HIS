using System;
using System.Data;
using System.EnterpriseServices;
using System.Security.Principal;
using System.Collections;
using System.Text;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.security;//PrivilegeSystemService.dll

namespace com.digitalwave.iCare.middletier.LIS
{
    [Transaction(TransactionOption.Supported)]
    [ObjectPooling(Enabled = true)]
    public class clsMicReportSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        public clsMicReportSvc()
        {
        }

       
    }
 }
