using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;
using System.Collections;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 
    /// </summary>
    public class clsDclDemandPayment : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region ���ݸ��ݲ���Id��ȡ�������в��˷���
        /// <summary>
        /// ���ݸ��ݲ���Id��ȡ�������в��˷���
        /// </summary>
        /// <param name="areaId">����Id��</param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        public long GetFeeByAreaId(string areaId, out DataTable p_dtResult)
        {
            long lngRes;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.clsDemandPayment objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDemandPayment)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDemandPayment));
            lngRes = objSvc.GetFeeByAreaId(p_objPrincipal, areaId,out p_dtResult);

            objSvc.Dispose();

            return lngRes;
        }
        #endregion

        #region ���ݸ��ݲ���Id��ȡ�������в��˵Ǽ���Ϣ
        /// <summary>
        /// ���ݸ��ݲ���Id��ȡ�������в��˵Ǽ���Ϣ
        /// </summary>
        /// <param name="areaId">����Id��</param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        public long GetPatientByAreaId(string areaId, out DataTable p_dtResult)
        {
            long lngRes;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.clsDemandPayment objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDemandPayment)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDemandPayment));
            lngRes = objSvc.GetPatientByAreaId(p_objPrincipal, areaId, out p_dtResult);

            objSvc.Dispose();

            return lngRes;
        }

        /// <summary>
        /// ���ݸ��ݲ���Id��ȡ�������в��˵Ǽ���Ϣ
        /// </summary>
        /// <param name="areaId"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="InHospitalFlag"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long GetPatientByAreaId(string areaId, string BeginDate, string EndDate, bool InHospitalFlag, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsDemandPayment objSvc =
                                                                  (com.digitalwave.iCare.middletier.HIS.clsDemandPayment)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDemandPayment));
            long lngRes = objSvc.GetPatientByAreaId(areaId, BeginDate, EndDate, InHospitalFlag, out dt);

            objSvc.Dispose();

            return lngRes;
        }
        #endregion

        #region ���ݸ��ݲ���Id��Ԥ������Ϣ
        /// <summary>
        /// ���ݸ��ݲ���Id��Ԥ������Ϣ
        /// </summary>
        /// <param name="areaId">����Id��</param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        public long GetPrepayByAreaId(string areaId, out DataTable p_dtResult)
        {
            long lngRes;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.clsDemandPayment objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDemandPayment)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDemandPayment));
            lngRes = objSvc.GetPrepayByAreaId(p_objPrincipal, areaId, out p_dtResult);

            objSvc.Dispose();

            return lngRes;
        }

        /// <summary>
        /// ���ݸ��ݲ���Id��ȡ�������в���Ԥ����Ϣ
        /// </summary>
        /// <param name="areaId"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="InHospitalFlag"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long GetPrepayByAreaId(string areaId, string BeginDate, string EndDate, bool InHospitalFlag, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsDemandPayment objSvc =
                                                                  (com.digitalwave.iCare.middletier.HIS.clsDemandPayment)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDemandPayment));
            long lngRes = objSvc.GetPrepayByAreaId(areaId, BeginDate, EndDate, InHospitalFlag, out dt);

            objSvc.Dispose();

            return lngRes;
        }
        #endregion

        #region ���ݸ��ݲ���Id��ȡ�������в��˷���-�ѺϼƵ�
        /// <summary>
        /// ���ݸ��ݲ���Id��ȡ�������в��˷���
        /// </summary>
        /// <param name="areaId">����Id��</param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        public long GetFeeByAreaIdSum(ArrayList m_arrRegisterid_chr, out DataTable p_dtResult)
        {
            long lngRes;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.clsDemandPayment objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDemandPayment)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDemandPayment));
            lngRes = objSvc.GetFeeByAreaIdSum(p_objPrincipal, m_arrRegisterid_chr, out p_dtResult);

            objSvc.Dispose();

            return lngRes;
        }
        #endregion

         #region ���ݸ��ݲ���Id��ȡ�������в��˷���-�ѺϼƵ�
        /// <summary>
        /// ���ݸ��ݲ���Id��ȡ�������в��˷���
        /// </summary>
        /// <param name="areaId">����Id��</param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        public long GetFeeByAreaIdSum(string areaId, out DataTable p_dtResult)
        {
            long lngRes;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.clsDemandPayment objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDemandPayment)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDemandPayment));
            lngRes = objSvc.GetFeeByAreaIdSum(p_objPrincipal, areaId, out p_dtResult);

            objSvc.Dispose();

            return lngRes;
        }

        /// <summary>
        /// ���ݸ��ݲ���Id��ȡ�������в��˷����ѺϼƵ�
        /// </summary>
        /// <param name="areaId"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="InHospitalFlag"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long GetFeeByAreaIdSum(string areaId, string BeginDate, string EndDate, bool InHospitalFlag, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsDemandPayment objSvc =
                                                                  (com.digitalwave.iCare.middletier.HIS.clsDemandPayment)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDemandPayment));
            long lngRes = objSvc.GetFeeByAreaIdSum(areaId, BeginDate, EndDate, InHospitalFlag, out dt);

            objSvc.Dispose();

            return lngRes;
        }
        #endregion
        
    }
}
