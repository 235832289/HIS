using System;
using com.digitalwave.iCare.middletier.HRPService;
using System.Data;
using Oracle.DataAccess.Client;
using com.digitalwave.iCare.ValueObject;
using System.EnterpriseServices;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
using System.Collections;
using com.digitalwave.iCare.middletier.HIS;

namespace com.digitalwave.iCare.middletier.BIHOrderServer
{
    /// <summary>
    /// Ò½ÖöÖ´ÐÐÂß¼­
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsExecuteOrderService : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {

    }
}
