using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;

namespace com.digitalwave.iCare.gui.HIS
{
    class clsDcl_Report : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region ������Ժ��ͳ�Ʊ���
        /// <summary>
        /// ������Ժ��ͳ�Ʊ���
        /// </summary>
        /// <param name="p_dtFromTime">��ʼʱ��</param>
        /// <param name="p_dtToTime">����ʱ��</param>
        /// <param name="p_dtbResult">��ѯ���</param>
        /// <returns></returns>
        public long m_lngPatientInHospitalReport(DateTime p_dtFromTime, DateTime p_dtToTime, out DataTable p_dtbResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsReportSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsReportSvc)
                     com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReportSvc));
            return objSvc.m_lngPatientInHospitalReport(objPrincipal, p_dtFromTime, p_dtToTime, out p_dtbResult);
        }
        #endregion

        #region ����Ӥ���Ǽ�ͳ�Ʊ���
        /// <summary>
        /// ����Ӥ���Ǽ�ͳ�Ʊ���
        /// </summary>
        /// <param name="p_strAreaID">����ID</param>
        /// <param name="p_dtFromTime">��ʼʱ��</param>
        /// <param name="p_dtToTime">����ʱ��</param>
        /// <param name="p_dtbResult">��ѯ���</param>
        /// <returns></returns>
        public long m_lngBabyRegisterReport( string p_strAreaID, DateTime p_dtFromTime, DateTime p_dtToTime, out DataTable p_dtbResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsReportSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsReportSvc)
                         com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReportSvc));
            return objSvc.m_lngBabyRegisterReport(objPrincipal,p_strAreaID, p_dtFromTime, p_dtToTime, out p_dtbResult);
        }
        #endregion
    }
}
