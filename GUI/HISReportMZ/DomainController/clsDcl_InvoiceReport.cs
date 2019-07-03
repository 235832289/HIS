using System;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.middletier.HIS; //HIS_SVC.DLL
using System.Data;
using System.Collections;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public class clsDcl_InvoiceReport : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        public clsDcl_InvoiceReport()
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //
        }

        #region ����δ�ս���ܱ���
        /// <summary>
        /// ����δ�ս���ܱ���
        /// </summary>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        public long m_lngGetNOCheckOutInvoice(string startDate,string endDate,out DataTable p_dtResult)
        {
            p_dtResult = null;
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.Reports.clsReportEarningSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsReportEarningSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsReportEarningSvc));
            lngRes = objSvc.m_lngGetNOCheckOutInvoice(startDate,endDate,out p_dtResult);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion
    }
}
