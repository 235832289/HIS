using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;
using System.Collections;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    /// <summary>
    /// ҽ���ҺŷѼ������ܱ� ҵ���߼�������
    /// </summary>
    public class clsDcl_Report_DoctorEarningCollect : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        internal long m_lngSelectDoctorEarningCollect(string strBeginDat, string strEndDat, string[] strTypeOfGh, string[] strTypeOfZc, out DataTable m_dtbReport)
        {
            com.digitalwave.iCare.middletier.HIS.Reports.clsReportEarningSvc objSvc = (com.digitalwave.iCare.middletier.HIS.Reports.clsReportEarningSvc)
                 com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsReportEarningSvc));
            return objSvc.m_lngSelectDoctorEarningCollect(strBeginDat, strEndDat, strTypeOfGh, strTypeOfZc, out m_dtbReport);
        }

        #region ҽ���ҺŷѼ������ܱ�(�£�

        /// <summary>
        /// ҽ���ҺŷѼ������ܱ��£�
        /// </summary>
        /// <param name="strBeginDat"></param>
        /// <param name="strEndDat"></param>
        /// <param name="p_strTypeIDArr"></param>
        /// <param name="m_dtbReport"></param>
        /// <returns></returns>
        internal long m_lngGetDoctorEarningCollect(string strBeginDat, string strEndDat, string[] p_strTypeIDArr1,string[] p_strTypeIDArr2, out DataTable m_dtbReport)
        {
            com.digitalwave.iCare.middletier.HIS.Reports.clsReportEarningSvc objSvc = (com.digitalwave.iCare.middletier.HIS.Reports.clsReportEarningSvc)
                 com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsReportEarningSvc));
            return objSvc.m_lngGetDoctorEarningCollect(strBeginDat, strEndDat, p_strTypeIDArr1,p_strTypeIDArr2, out m_dtbReport);
        }

        #endregion

        #region ȡ�������
        /// <summary>
        /// ȡ�������
        /// </summary>
        /// <param name="strBeginDat"></param>
        /// <param name="strEndDat"></param>
        /// <param name="strTypeOfGh"></param>
        /// <param name="strTypeOfZc"></param>
        /// <param name="m_dtbReport"></param>
        /// <returns></returns>
        internal long m_lngGetTypeID(string p_strRptID, string p_strGroupID, out DataTable p_dtbTypeID)
        {
            com.digitalwave.iCare.middletier.HIS.Reports.clsReportEarningSvc objSvc = (com.digitalwave.iCare.middletier.HIS.Reports.clsReportEarningSvc)
                 com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsReportEarningSvc));
            return objSvc.m_lngGetTypeID(p_strRptID, p_strGroupID, out p_dtbTypeID);
        }

        #endregion
        #region
        /// <summary>
        /// ����ҽ����Чͳ�Ʊ���
        /// </summary>
        /// <param name="p_beginDate"></param>
        /// <param name="p_endDate"></param>
        /// <param name="p_strStatType"></param>
        /// <param name="p_strDoctorID"></param>
        /// <param name="DeptIDArr">����ID������</param>
        /// <param name="intFlag">��ʶ��0��ҽ��ͳ�ƣ�1������ͳ��</param>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        public long m_lngGetRptDoctorPerformance(string p_beginDate, string p_endDate, string p_strStatType, string p_strDoctorID,ArrayList DeptIDArr, int intFlag, ref DataTable dtResult)
        {
            com.digitalwave.iCare.middletier.HIS.Reports.clsReportQuerySupportSvc objSvc = (com.digitalwave.iCare.middletier.HIS.Reports.clsReportQuerySupportSvc)
                 com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsReportQuerySupportSvc));
            return objSvc.m_lngGetRptDoctorPerformance(p_beginDate, p_endDate, p_strStatType, p_strDoctorID, DeptIDArr, intFlag, ref dtResult);
        }
        #endregion

        #region ��ò�����Ϣ
        /// <summary>
        /// ��ò�����Ϣ
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="Flag">1 ���� </param>
        /// <returns></returns>
        public long m_lngGetDeptArea(out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.Reports.clsReportEarningSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsReportEarningSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsReportEarningSvc));

            long l = objSvc.m_lngGetDeptArea(out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion
    }


}
