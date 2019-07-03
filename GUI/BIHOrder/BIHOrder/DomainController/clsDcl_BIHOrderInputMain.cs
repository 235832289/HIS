using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security; 
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll

namespace com.digitalwave.iCare.BIHOrder
{
    public class clsDcl_BIHOrderInputMain : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        internal long m_lngGetORDERCHARGEDEPT(string p_strAreaID, string p_strBedIDs, string m_strPTableClassID, DateTime dtExecuteDate, out DataTable objDT)
        {
             
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHReportService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHReportService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHReportService));
            lngRes = objSvc.m_lngGetOrderForPrint(p_strAreaID, p_strBedIDs, m_strPTableClassID, dtExecuteDate, out objDT);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
    }
}
