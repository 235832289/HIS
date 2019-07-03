using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.middletier.HIS;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// ��������DOMAIN��
    /// </summary>
    public class clsDcl_AidDictionary : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region ����
        /// <summary>
        /// ����
        /// </summary>
        public clsDcl_AidDictionary()
        {
        }
        #endregion               

        #region ����ҽ��ְ��
        /// <summary>
        /// ����ҽ��ְ��
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngGetDoctorDuty(out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsAidDictionary objSvc =
                                                                  (com.digitalwave.iCare.middletier.HIS.clsAidDictionary)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAidDictionary));

            long l = objSvc.m_lngGetDoctorDuty(out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region ��������Ĭ�ϼ�����Ŀ��
        /// <summary>
        /// ��������Ĭ�ϼ�����Ŀ��
        /// </summary>
        /// <param name="RecordsArr"></param>
        /// <param name="Flag">-1 ֻɾ��</param>
        /// <param name="PayTypeID"></param>
        /// <returns></returns>        
        public long m_lngSaveOutPatientDefaultAddItem(ArrayList RecordsArr, int Flag, string PayTypeID)
        {
            com.digitalwave.iCare.middletier.HIS.clsAidDictionary objSvc =
                                                                  (com.digitalwave.iCare.middletier.HIS.clsAidDictionary)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAidDictionary));

            long l = objSvc.m_lngSaveOutPatientDefaultAddItem(RecordsArr, Flag, PayTypeID);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region ��ȡ����Ĭ�ϼ�����Ŀ��
        /// <summary>
        /// ��ȡ����Ĭ�ϼ�����Ŀ��
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="PayTypeID"></param>
        /// <returns></returns>
        public long m_lngGetOutPatientDefaultAddItem(out DataTable dt, string PayTypeID )
        {
            com.digitalwave.iCare.middletier.HIS.clsAidDictionary objSvc =
                                                                 (com.digitalwave.iCare.middletier.HIS.clsAidDictionary)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAidDictionary));

            long l = objSvc.m_lngGetOutPatientDefaultAddItem(out dt, PayTypeID );
            objSvc.Dispose();

            return l;
        }
        #endregion
    }
}
