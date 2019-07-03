using System;
using System.Data;
using System.Collections;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;
using com.digitalwave.iCare.middletier.PatientSvc;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// ��Ժ�����߼����Ʋ�
	/// ���ߣ� He Guiqiu
	/// ����ʱ�䣺 2006-07-12
	/// </summary>
    public class clsDclBihLeaHos : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region ���캯��
        public clsDclBihLeaHos()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		#endregion

        #region Ԥ��Ժ
        /// <summary>
        /// Ԥ��Ժ
        /// </summary>
        /// <param name="objPatientVO">[clsT_Opr_Bih_Leave_VO]</param>
        /// <returns></returns>
        public long PreLeaveHospital(clsT_Opr_Bih_Leave_VO objPatientVO)
        {
            long lngRes = 0;
           
            try
            {
                com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc objSvc =
                        (com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc));
           
                lngRes = objSvc.PreLeaveHospital(objPrincipal, objPatientVO);
                objSvc.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            } 
            
            return lngRes;
        }
        #endregion 

        #region ֱ�ӳ�Ժ
        /// <summary>
        /// ֱ�ӳ�Ժ
        /// </summary>
        /// <param name="objPatientVO">[clsT_Opr_Bih_Leave_VO]</param>
        /// <returns></returns>
        public long LeaveHospital(clsT_Opr_Bih_Leave_VO objPatientVO)
        {
            long lngRes = 0;

            try
            {
                com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc objSvc =
                        (com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc));

                lngRes = objSvc.LeaveHospital(objPrincipal, objPatientVO);
                objSvc.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }

            return lngRes;
        }
        #endregion

        #region ����Ԥ��Ժ
        /// <summary>
        /// ����Ԥ��Ժ
        /// </summary>
        /// <param name="p_RegisterId"></param>
        /// <param name="p_OperatorId"></param>
        /// <returns></returns>
        public long CancelPreLeaved(string p_RegisterId, string p_OperatorId)
        {
            long lngRes = 0;

            try
            {
                com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc objSvc =
                        (com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc));

                lngRes = objSvc.CancelPreLeaved(objPrincipal, p_RegisterId, p_OperatorId);
                objSvc.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }

            return lngRes;
        }
        #endregion

        #region ��Ժ�ٻ�
        /// <summary>
        /// ��Ժ�ٻ�
        /// </summary>
        /// <param name="objPatientVO"></param>
        /// <param name="operatorId"></param>
        /// <returns></returns>
        public long RecallHospital(clsT_Opr_Bih_Leave_VO objPatientVO, string operatorId)
        {
            long lngRes = 0;

            try
            {
                com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc objSvc =
                        (com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc));

                lngRes = objSvc.RecallHospital(objPrincipal, objPatientVO, operatorId);
                objSvc.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }

            return lngRes;
        }
        #endregion

        #region ������Ժ�Ǽ���ˮ�Ų�ѯ��Ч��Ԥ��Ժ��¼
        /// <summary>
        /// ������Ժ�Ǽ���ˮ�Ų�ѯ��Ч��Ԥ��Ժ��¼
        /// </summary>
        /// <param name="p_strRegisterid_chr">��Ժ�Ǽ���ˮ��</param>
        /// <param name="p_objResult"></param>
        /// <returns></returns>
        public long GetPreLeaveByRegisterID(string p_strRegisterid, out clsT_Opr_Bih_Leave_VO p_objResult)
        {
            long lngRes = 0;

            try
            {
                com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc objSvc =
                        (com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc));

                lngRes = objSvc.GetPreLeaveByRegisterID(objPrincipal, p_strRegisterid, out p_objResult);
                objSvc.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }

            return lngRes;
        }
        #endregion 

        #region ������Ժ�Ǽ���ˮ�Ų�ѯ��Ч�ĳ�Ժ��¼
        /// <summary>
        /// ������Ժ�Ǽ���ˮ�Ų�ѯ��Ч�ĳ�Ժ��¼
        /// </summary>
        /// <param name="p_strRegisterid_chr">��Ժ�Ǽ���ˮ��</param>
        /// <param name="p_pstatus">��־ 0 Ԥ��Ժ��1 ��ʽ��Ժ</param>
        /// <param name="p_objResult"></param>
        /// <returns></returns>
        public long GetLeaveByRegisterID(string p_strRegisterid, string p_pstatus, out clsT_Opr_Bih_Leave_VO p_objResult)
        {
            long lngRes = 0;

            try
            {
                com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc objSvc =
                        (com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc));

                lngRes = objSvc.GetLeaveByRegisterID(objPrincipal, p_strRegisterid, p_pstatus, out p_objResult);
                objSvc.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }

            return lngRes;
        }
        #endregion 

        #region  ��ѯ��ǰ�Ƿ����¿�,�ύ,ת��,ִ�е�(δͣ)��ҽ��
        /// <summary>
        /// ��ѯ��ǰ�Ƿ����¿�,�ύ,ת��,ִ�е�(δͣ)��ҽ��
        /// </summary>
        /// <param name="p_strRegisterID"></param>
        /// <param name="m_intCount"></param>
        /// <returns></returns>
        public long m_lngGetNotStopOrderByRegID(string p_strRegisterID, out int m_intCount)
        {
            m_intCount = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface objSvc =
                        (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface));
            long l = objSvc.m_lngGetNotExecuteOrderByRegID(objPrincipal, p_strRegisterID, out m_intCount);
            objSvc.Dispose();
            return l;
        }
        #endregion 

        #region �ж��Ƿ����������δִ��
        /// <summary>
        /// �ж��Ƿ����������δִ��
        /// </summary>
        /// <param name="p_RegisterId"></param>
        /// <param name="p_status"></param>
        /// <param name="p_has"></param>
        /// <returns></returns>
        public long GetOrderNotExc(string p_RegisterId, out int p_count, out ArrayList p_arrCreator)
        {
            long lngRes = 0;
            //p_ifHas=false;
            p_count = 0;
            try
            {
                com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface objSvc =
                        (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface));

                //lngRes = objSvc.m_lngGetNotExecuteOrderByRegID(objPrincipal, p_RegisterId, out count);
                //ArrayList m_arrCreator;
                lngRes = objSvc.m_lngGetNotStopOrderByRegID(objPrincipal, p_RegisterId, out p_count, out p_arrCreator);
                //if (p_arrCreator.Count > 0)
                //{
                //    MessageBox.Show(p_arrCreator[0].ToString());
                //}
                //if (count > 0)
                //{
                //    p_ifHas = true;
                //}
                objSvc.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }

            return lngRes;
        }
        #endregion

        #region �ж��Ƿ����������δִ��
        /// <summary>
        /// �ж��Ƿ����������δִ��
        /// </summary>
        /// <param name="p_RegisterId"></param>
        /// <param name="p_status"></param>
        /// <param name="p_has"></param>
        /// <returns></returns>
        public long IfHasDisExcOrder(string p_registerId, out bool HasDisExcOrder)
        {
            long lngRes = 0;

            try
            {
                com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc objSvc =
                        (com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc));

                lngRes = objSvc.IfHasDisExcOrder(objPrincipal, p_registerId, out HasDisExcOrder);
                objSvc.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }

            return lngRes;
        }
        #endregion

        #region ��ѯ�����ֵ�
        /// <summary>
        /// ��ѯ�����ֵ�
        /// </summary>
        /// <param name="p_objResult"></param>
        /// <returns></returns>
        public long GetDisease(out DataTable p_dtResult)
        {
            long lngRes = 0;

            try
            {
                com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc objSvc =
                        (com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc));

                lngRes = objSvc.GetInsurncedisease(objPrincipal, out p_dtResult);
                objSvc.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }

            return lngRes;
        }
        #endregion 

        #region ��ѯ�����ֵ�
        /// <summary>
        /// ��ѯ�����ֵ�
        /// </summary>
        /// <param name="p_objResult"></param>
        /// <returns></returns>
        public long GetDisease(string p_strCode, out DataTable p_dtResult)
        {
            long lngRes = 0;

            try
            {
                com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc objSvc =
                        (com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc));

                lngRes = objSvc.GetInsurncedisease(objPrincipal, p_strCode, out p_dtResult);
                objSvc.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }

            return lngRes;
        }
        #endregion 

        #region ��Ժ���ͳ��
        /// <summary>
        /// ��Ժ���ͳ��
        /// </summary>
        /// <param name="p_objResult"></param>
        /// <returns></returns>
        public long GetOutDiagnoses(string p_strCondition, out DataTable p_dtResult)
        {
            long lngRes = 0;

            try
            {
                com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc objSvc =
                        (com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc));

                lngRes = objSvc.GetOutDiagnoses(objPrincipal, p_strCondition, out p_dtResult);
                objSvc.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }

            return lngRes;
        }
        #endregion 

        #region ����סԺ�ǼǱ��Ժ���
        /// <summary>
        /// ����סԺ�ǼǱ��Ժ���
        /// </summary>
        /// <param name="p_RegisterId">סԺ�ǼǺ�</param>
        /// <param name="p_OutDiagnose">��Ժ���</param>
        /// <returns></returns>
        public long UpdateRegisterOutDiagnose(string p_RegisterId, string p_OutDiagnose,bool p_blnDiseaseType)
        {
            long lngRes = 0;

            try
            {
                com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc objSvc =
                        (com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc));

                lngRes = objSvc.UpdateRegisterOutDiagnose(objPrincipal, p_RegisterId, p_OutDiagnose, p_blnDiseaseType);
                objSvc.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }

            return lngRes;
        }
        #endregion 

        #region ����סԺ�ǼǱ��Ժ���
        /// <summary>
        /// ����סԺ�ǼǱ��Ժ���
        /// </summary>
        /// <param name="p_RegisterId">סԺ�ǼǺ�</param>
        /// <param name="p_OutDiagnose">��Ժ���</param>
        /// <returns></returns>
        public long UpdateRegisterOutDiagnose(string p_RegisterId, string p_OutDiagnose)
        {
            long lngRes = 0;

            try
            {
                com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc objSvc =
                        (com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc));

                lngRes = objSvc.UpdateRegisterOutDiagnose(objPrincipal, p_RegisterId, p_OutDiagnose);
                objSvc.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }

            return lngRes;
        }
        #endregion 

        #region �޸�Ԥ��Ժ����
        /// <summary>
        /// �޸�Ԥ��Ժ����
        /// </summary>
        /// <param name="p_RegisterId">סԺ�ǼǺ�</param>
        /// <param name="p_OutDiagnose">��Ժ���</param>
        /// <returns></returns>
        public long ModifyLeaveDate(DateTime p_dtNewDate, clsT_Opr_Bih_Leave_VO p_objLeave)
        {
            long lngRes = 0;

            try
            {
                com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc objSvc =
                        (com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc));

                lngRes = objSvc.ModifyLeaveDate(objPrincipal, p_dtNewDate, p_objLeave);
                objSvc.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }

            return lngRes;
        }
        #endregion 

        #region �ж����ڶ����Ƿ����˷���
        /// <summary>
        /// �ж����ڶ����Ƿ����˷���
        /// </summary>
        /// <param name="p_strRegisterid_chr">��Ժ�Ǽ���ˮ��</param>
        /// <param name="p_strBeginDate">��ʼʱ��</param>
        /// <param name="p_strEndDate">����ʱ��</param>
        /// <param name="p_hasCharge"></param>
        /// <returns></returns>
        public long IfHasCharge(string p_strRegisterid_chr, string p_strBeginDate, string p_strEndDate, out bool p_hasCharge)
        {
            long lngRes = 0;

            try
            {
                com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc objSvc =
                        (com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc));

                lngRes = objSvc.IfHasCharge(p_strRegisterid_chr, p_strBeginDate, p_strEndDate, out p_hasCharge);
                objSvc.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }

            return lngRes;
        }
        #endregion 
    }
}
