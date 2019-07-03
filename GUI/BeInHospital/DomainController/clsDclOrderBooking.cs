using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;
using com.digitalwave.iCare.middletier.PatientSvc;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 
    /// </summary>
    public class clsDclOrderBooking : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region ���캯��
        public clsDclOrderBooking()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		#endregion

        #region Get by Date
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_objResult"></param>
        /// <returns></returns>
        public long GetOrderBookByDate(string p_beginDate, string p_endDate, out DataTable p_dtResult)
        {
            long lngRes = 0;

            try
            {
                com.digitalwave.iCare.middletier.HIS.clsOrderBookingSvc objSvc =
                        (com.digitalwave.iCare.middletier.HIS.clsOrderBookingSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOrderBookingSvc));

                lngRes = objSvc.GetOrderBookByDate(objPrincipal, p_beginDate, p_endDate, out p_dtResult);
                objSvc.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }

            return lngRes;
        }
        #endregion 

        #region Get by operatorId and date
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_objResult"></param>
        /// <returns></returns>
        public long GetOrderBookByDate(string p_beginDate, string p_endDate, string p_strOperatorId, out DataTable p_dtResult)
        {
            long lngRes = 0;

            try
            {
                com.digitalwave.iCare.middletier.HIS.clsOrderBookingSvc objSvc =
                        (com.digitalwave.iCare.middletier.HIS.clsOrderBookingSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOrderBookingSvc));

                lngRes = objSvc.GetOrderBookByDate(objPrincipal, p_beginDate, p_endDate, p_strOperatorId, out p_dtResult);
                objSvc.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }

            return lngRes;
        }
        #endregion 

        #region Get by area ID
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_strRegisterid_chr">��Ժ�Ǽ���ˮ��</param>
        /// <param name="p_objResult"></param>
        /// <returns></returns>
        public long GetOrderBook(string p_arearId, string p_beginDate, string p_endDate, out DataTable p_dtResult)
        {
            long lngRes = 0;

            try
            {
                com.digitalwave.iCare.middletier.HIS.clsOrderBookingSvc objSvc =
                        (com.digitalwave.iCare.middletier.HIS.clsOrderBookingSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOrderBookingSvc));

                lngRes = objSvc.GetOrderBook(objPrincipal, p_arearId, p_beginDate, p_endDate, out p_dtResult);
                objSvc.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }

            return lngRes;
        }
        #endregion 

        #region Get By Id
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_bookId">��ˮ��</param>
        /// <param name="p_objResult"></param>
        /// <returns></returns>
        public long GetOrderBookById(string p_bookId, out DataTable p_dtResult)
        {
            long lngRes = 0;

            try
            {
                com.digitalwave.iCare.middletier.HIS.clsOrderBookingSvc objSvc =
                        (com.digitalwave.iCare.middletier.HIS.clsOrderBookingSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOrderBookingSvc));

                lngRes = objSvc.GetOrderBookById(objPrincipal, p_bookId, out p_dtResult);
                objSvc.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }

            return lngRes;
        }
        #endregion 

        #region �޸�ԤԼ��
        /// <summary>
        /// �޸�ԤԼ��
        /// </summary>
        /// <param name="p_bookID">��ˮ��</param>
        /// <param name="p_bookDate">ԤԼ��׼ʱ��</param>
        /// <param name="p_bookStatus">ԤԼ״̬ 0-ԤԼδȷ�� 1-ԤԼͨ�� 2-ԤԼ��ͨ��/param>
        /// <param name="p_remark">ע������</param>
        /// <param name="p_confirmer">ȷ����ID</param>
        /// <returns></returns>
        public long UpdateOrderBooking(string p_bookID,
                string p_bookDate,
                string p_bookStatus,
                string p_remark,
                string p_confirmer)
        {
            long lngRes = 0;

            try
            {
                com.digitalwave.iCare.middletier.HIS.clsOrderBookingSvc objSvc =
                        (com.digitalwave.iCare.middletier.HIS.clsOrderBookingSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOrderBookingSvc));

                lngRes = objSvc.UpdateOrderBooking(objPrincipal, p_bookID, p_bookDate, p_bookStatus, p_remark, p_confirmer);
                objSvc.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }

            return lngRes;
        }
        #endregion 

        #region ͨ���ض��Ĳ�ѯ����ѯ
        /// <summary>
        /// ͨ���ض��Ĳ�ѯ����ѯ
        /// </summary>
        /// <returns></returns>
        public long GetBySearchSentence(string p_strSQL, out DataTable p_dtResult)
        {
            long lngRes = 0;

            try
            {
                com.digitalwave.iCare.middletier.HIS.clsOrderBookingSvc objSvc =
                        (com.digitalwave.iCare.middletier.HIS.clsOrderBookingSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOrderBookingSvc));

                lngRes = objSvc.GetBySearchSentence(objPrincipal, p_strSQL, out p_dtResult);
                objSvc.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }

            return lngRes;
        }
        #endregion 

        #region ���´�ӡ��־By Id

        public long UpdataPrintFlagById(string p_bookID)
        {
            long lngRes = 0;

            try
            {
                com.digitalwave.iCare.middletier.HIS.clsOrderBookingSvc objSvc =
                        (com.digitalwave.iCare.middletier.HIS.clsOrderBookingSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOrderBookingSvc));

                lngRes = objSvc.UpdataPrintFlagById( p_bookID);
                objSvc.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }

            return lngRes;
        }
        #endregion 

        #region  ����ҽ��Idȡ���뵥Id

        public long GetApplyIdByOrderId(string p_strOrderId, out string p_strApplyId)
        {
            long lngRes = 0;

            try
            {
                com.digitalwave.iCare.middletier.HIS.clsOrderBookingSvc objSvc =
                        (com.digitalwave.iCare.middletier.HIS.clsOrderBookingSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOrderBookingSvc));

                lngRes = objSvc.GetApplyIdByOrderId(p_strOrderId, out p_strApplyId);
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
