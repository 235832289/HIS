using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;
//新增下面的
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll

namespace com.digitalwave.iCare.BIHOrder
{
    class clsDCl_BihReport : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 查找
        /// <summary>
        /// 获取医嘱附加单据-转区	根据ID
        /// </summary>
        /// <param name="p_strID">流水号</param>
        /// <param name="p_objResult"></param>
        /// <returns></returns>
        public long m_lngGetOrderAttachTransferByID(string p_strID, out clsT_Opr_Bih_OrderAttach_Transfer_Vo p_objResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngGetOrderAttachTransferByID(objPrincipal, p_strID, out p_objResult);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion

        internal long m_lngGetORDERCHARGEDEPT(string p_strAreaID, string p_strBedIDs,string m_strPTableClassID, DateTime dtExecuteDate, out DataTable objDT)
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
