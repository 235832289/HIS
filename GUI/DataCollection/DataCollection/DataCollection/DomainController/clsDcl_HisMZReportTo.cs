using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.common;
using com.digitalwave.iCare.middletier.DataCollection;
using System.Data;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.DataCollection
{
    internal class clsDcl_HisMZReportTo
    {
        #region ��ѯ���������Ϣ
        /// <summary>
        /// ��ѯ���������Ϣ
        /// </summary>
        /// <param name="p_strPatientCard"></param>
        /// <param name="p_strDeptId"></param>
        /// <param name="p_strDocId"></param>
        /// <param name="p_dtStart"></param>
        /// <param name="p_dtEnd"></param>
        /// <param name="p_dtbResult"></param>
        /// <returns></returns>
        public long m_lngQueryClinic(string p_strPatientCardId, string p_strDeptId, string p_strDocId, DateTime p_dtStart, DateTime p_dtEnd, out DataTable p_dtbResult)
        {
            long lngRes = 0;
            clsHisMZReportToSvc objServ = (clsHisMZReportToSvc)clsObjectGenerator.objCreatorObjectByType(typeof(clsHisMZReportToSvc));
            lngRes = objServ.m_lngQueryClinic(p_strPatientCardId, p_strDeptId, p_strDocId, p_dtStart, p_dtEnd, out p_dtbResult);
            objServ = null;
            return lngRes;
        }
        #endregion

        #region ��ѯ���������Ϣ
        /// <summary>
        /// ��ѯ���������Ϣ
        /// </summary>
        /// <param name="dtUpload"></param>
        /// <param name="p_arrOpdiagInfo_VO"></param>
        /// <returns></returns>
        public long m_lngGetOpDiagInfo(DateTime dtUpload, out com.digitalwave.iCare.ValueObject.clsOpDiagInfo_VO[] p_arrOpdiagInfo_VO)
        {
            com.digitalwave.iCare.middletier.DataCollection.clsHisMZReportToSvc objServ =
                (com.digitalwave.iCare.middletier.DataCollection.clsHisMZReportToSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.DataCollection.clsHisMZReportToSvc));
            return objServ.m_lngGetOpDiagInfo(dtUpload, out p_arrOpdiagInfo_VO);
        }
        #endregion

        #region ���������Ϣ�ϱ�
        /// <summary>
        /// ���������Ϣ�ϱ�
        /// </summary>
        /// <param name="p_arrOpdiagInfo_VO"></param>
        /// <returns></returns>
        public long m_lngUploadDiagInfo(com.digitalwave.iCare.ValueObject.clsOpDiagInfo_VO p_arrOpdiagInfo_VO)
        {
            com.digitalwave.iCare.middletier.DataCollection.clsDataUpload_Svc objServ =
                (com.digitalwave.iCare.middletier.DataCollection.clsDataUpload_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.DataCollection.clsDataUpload_Svc));
            return objServ.m_lngUploadDiagInfo(p_arrOpdiagInfo_VO);
        }
        #endregion

        #region ��ѯ���������Ϣ
        /// <summary>
        /// ��ѯ���������Ϣ
        /// </summary>
        /// <param name="dtUpload"></param>
        /// <param name="p_arrOpfee_VO"></param>
        /// <returns></returns>
        public long m_lngGetOpfeeInfo(DateTime dtUpload, out com.digitalwave.iCare.ValueObject.clsOpfee_VO[] p_arrOpfee_VO)
        {
            com.digitalwave.iCare.middletier.DataCollection.clsHisMZReportToSvc objServ =
                (com.digitalwave.iCare.middletier.DataCollection.clsHisMZReportToSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.DataCollection.clsHisMZReportToSvc));
            return objServ.m_lngGetOpfeeInfo(dtUpload, out p_arrOpfee_VO);
        }
        #endregion

        #region ���������Ϣ�ϱ�
        /// <summary>
        /// ���������Ϣ�ϱ�
        /// </summary>
        /// <param name="p_arrOpfee_VO"></param>
        /// <returns></returns>
        public long m_lngUploadOpfee(com.digitalwave.iCare.ValueObject.clsOpfee_VO p_arrOpfee_VO)
        {
            com.digitalwave.iCare.middletier.DataCollection.clsDataUpload_Svc objServ =
                (com.digitalwave.iCare.middletier.DataCollection.clsDataUpload_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.DataCollection.clsDataUpload_Svc));
            return objServ.m_lngUploadOpfee(p_arrOpfee_VO);
        }
        #endregion

        #region ��ѯ���ﴦ����Ϣ
        /// <summary>
        /// ��ѯ���ﴦ����Ϣ
        /// </summary>
        /// <param name="dtUpload"></param>
        /// <param name="p_arrRecInfo_VO"></param>
        /// <returns></returns>
        public long m_lngGetRecInfo(DateTime dtUpload, out com.digitalwave.iCare.ValueObject.clsRecInfo_VO[] p_arrRecInfo_VO)
        {
            com.digitalwave.iCare.middletier.DataCollection.clsHisMZReportToSvc objServ =
                (com.digitalwave.iCare.middletier.DataCollection.clsHisMZReportToSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.DataCollection.clsHisMZReportToSvc));
            return objServ.m_lngGetRecInfo(dtUpload, out p_arrRecInfo_VO);
        }
        #endregion

        #region ��ѯ�շѱ�׼��Ϣ
        /// <summary>
        /// ��ѯ�շѱ�׼��Ϣ
        /// </summary>
        /// <param name="datUpload"></param>
        /// <param name="arrChargeitem_VO"></param>
        /// <returns></returns>
        public long m_lngGetChargeItemInfo(DateTime p_dtmStartDate, DateTime p_dtmEndDate, DateTime datUpload, out clsChargeStandard_VO[] arrChargeitem_VO)
        {
            com.digitalwave.iCare.middletier.DataCollection.clsHisMZReportToSvc objServ =
                (com.digitalwave.iCare.middletier.DataCollection.clsHisMZReportToSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.DataCollection.clsHisMZReportToSvc));
            return objServ.m_lngGetChargeItemInfo(p_dtmStartDate, p_dtmEndDate, datUpload, out arrChargeitem_VO);
        }
        #endregion

        #region ��Ŀ������Ϣ�ϴ�
        /// <summary>
        /// ��Ŀ������Ϣ�ϴ�
        /// </summary>
        /// <param name="arrItemControl_VO"></param>
        /// <returns></returns>
        public long m_lngUploadItemControl(clsItemControl_VO arrItemControl_VO)
        {
            com.digitalwave.iCare.middletier.DataCollection.clsDataUpload_Svc objServ =
                                      (com.digitalwave.iCare.middletier.DataCollection.clsDataUpload_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.DataCollection.clsDataUpload_Svc));
            return objServ.m_lngUploadItemControl(arrItemControl_VO);
        }
        #endregion

        #region ��Ŀ������Ϣ
        /// <summary>
        /// ��Ŀ������Ϣ
        /// </summary>
        /// <param name="dtStart"></param>
        /// <param name="dtEnd"></param>
        /// <param name="arrItemControl_VO"></param>
        /// <returns></returns>
        public long m_lngGetItemControlInfo(DateTime dtStart, DateTime dtEnd, out clsItemControl_VO[] arrItemControl_VO)
        {
            com.digitalwave.iCare.middletier.DataCollection.clsHisMZReportToSvc objServ =
                (com.digitalwave.iCare.middletier.DataCollection.clsHisMZReportToSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.DataCollection.clsHisMZReportToSvc));
            return objServ.m_lngGetItemControlInfo(dtStart, dtEnd, out arrItemControl_VO);
        }
        #endregion

        #region ���ﴦ����Ϣ�ϱ�
        /// <summary>
        /// ���ﴦ����Ϣ�ϱ�
        /// </summary>
        /// <param name="p_arrRecInfo_VO"></param>
        /// <returns></returns>
        public long m_lngUploadRecInfo(com.digitalwave.iCare.ValueObject.clsRecInfo_VO p_arrRecInfo_VO)
        {
            com.digitalwave.iCare.middletier.DataCollection.clsDataUpload_Svc objServ =
                (com.digitalwave.iCare.middletier.DataCollection.clsDataUpload_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.DataCollection.clsDataUpload_Svc));
            return objServ.m_lngUploadRecInfo(p_arrRecInfo_VO);
        }
        #endregion

        #region �շѱ�׼��Ϣ�ϱ�
        /// <summary>
        /// �շѱ�׼��Ϣ�ϱ�
        /// </summary>
        /// <returns></returns>
        public long m_lngUploadChargeitemInfo(com.digitalwave.iCare.ValueObject.clsChargeStandard_VO p_arrChargeitem_VO)
        {
            com.digitalwave.iCare.middletier.DataCollection.clsDataUpload_Svc objServ =
                           (com.digitalwave.iCare.middletier.DataCollection.clsDataUpload_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.DataCollection.clsDataUpload_Svc));
            return objServ.m_lngUploadChargeitemInfo(p_arrChargeitem_VO);
        }
        #endregion

        #region ��ѯҩƷ��Ϣ
        /// <summary>
        /// ��ѯҩƷ��Ϣ
        /// </summary>
        /// <param name="datUpload"></param>
        /// <param name="arrRecInfo_VO"></param>
        /// <returns></returns>
        public long m_lngGetDrugInfo(DateTime datUpload, out com.digitalwave.iCare.ValueObject.clsDrugInfo_VO[] arrRecInfo_VO)
        {
            com.digitalwave.iCare.middletier.DataCollection.clsHisMZReportToSvc objServ =
               (com.digitalwave.iCare.middletier.DataCollection.clsHisMZReportToSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.DataCollection.clsHisMZReportToSvc));
            return objServ.m_lngGetDrugInfo(datUpload, out arrRecInfo_VO);
        }
        #endregion

        #region ҩƷ��Ϣ�ϱ�
        /// <summary>
        /// ҩƷ��Ϣ�ϱ�
        /// </summary>
        /// <param name="p_arrDrugInfo_VO"></param>
        /// <returns></returns>
        public long m_lngUploadDrugInfo(com.digitalwave.iCare.ValueObject.clsDrugInfo_VO p_arrDrugInfo_VO)
        {
            com.digitalwave.iCare.middletier.DataCollection.clsDataUpload_Svc objServ =
                (com.digitalwave.iCare.middletier.DataCollection.clsDataUpload_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.DataCollection.clsDataUpload_Svc));
            return objServ.m_lngUploadDrugInfo(p_arrDrugInfo_VO);
        }
        #endregion

        #region �ϱ�������Ϣ

        /// <summary>
        /// ��ѯ�������뵥��Ϣ
        /// </summary>
        /// <param name="p_strStartDate"></param>
        /// <param name="p_strEndDate"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        public long m_lngQueryLISAppByDate(string p_strStartDate, string p_strEndDate, out clsLISAppl_VO[] p_objResultArr)
        {
            com.digitalwave.iCare.middletier.DataCollection.clsLISQuerySvc objServ =
                (com.digitalwave.iCare.middletier.DataCollection.clsLISQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.DataCollection.clsLISQuerySvc));
            return objServ.m_lngQueryLISAppByDate(p_strStartDate, p_strEndDate, out p_objResultArr);
        }

        /// <summary>
        /// ��ѯסԺ���뵥��Ϣ
        /// </summary>
        /// <param name="p_strStartDate"></param>
        /// <param name="p_strEndDate"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        public long m_lngQueryLISAppHISByDate(string p_strStartDate, string p_strEndDate, out clsLISAppl_VO[] p_objResultArr)
        {
            com.digitalwave.iCare.middletier.DataCollection.clsLISQuerySvc objServ =
                (com.digitalwave.iCare.middletier.DataCollection.clsLISQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.DataCollection.clsLISQuerySvc));
            return objServ.m_lngQueryLISAppHISByDate(p_strStartDate, p_strEndDate, out p_objResultArr);
        }
        /// <summary>
        /// ��ѯ ������ϸ��Ϣ
        /// </summary>
        /// <param name="p_strStartDate"></param>
        /// <param name="p_strEndDate"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        public long m_lngQueryLISAppItemByDate(string p_strStartDate, string p_strEndDate, out clsLISApplItem_VO[] p_objResultArr)
        {
            com.digitalwave.iCare.middletier.DataCollection.clsLISQuerySvc objServ =
                (com.digitalwave.iCare.middletier.DataCollection.clsLISQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.DataCollection.clsLISQuerySvc));
            return objServ.m_lngQueryLISAppItemByDate(p_strStartDate, p_strEndDate, out p_objResultArr);
        }
        /// <summary>
        /// ��������ϸ��Ϣ
        /// </summary>
        /// <param name="p_strStartDate"></param>
        /// <param name="p_strEndDate"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        public long m_lngQueryLISAppDetialByDate(string p_strStartDate, string p_strEndDate, out clsLISApplDetial_VO[] p_objResultArr)
        {
            com.digitalwave.iCare.middletier.DataCollection.clsLISQuerySvc objServ =
                (com.digitalwave.iCare.middletier.DataCollection.clsLISQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.DataCollection.clsLISQuerySvc));
            return objServ.m_lngQueryLISAppDetialByDate(p_strStartDate, p_strEndDate, out p_objResultArr);
        }

        /// <summary>
        /// ɾ��ǰ�û�ָ�����ڼ�¼
        /// </summary>
        /// <param name="p_strStardDate"></param>
        /// <param name="p_strEndDate"></param>
        /// <returns></returns>
        public long m_lngDelLISUpdateLoadDataByDate(string p_strStardDate, string p_strEndDate)
        {
            com.digitalwave.iCare.middletier.DataCollection.clsDataUpload_Svc objServ =
                (com.digitalwave.iCare.middletier.DataCollection.clsDataUpload_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.DataCollection.clsDataUpload_Svc));
            return objServ.m_lngDelLISUpdateLoadDataByDate(p_strStardDate, p_strEndDate);
        }
        /// <summary>
        /// �������뵥��¼
        /// </summary>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        public long m_lngInsertLisAppDataByDate(clsLISAppl_VO[] p_objResultArr)
        {
            com.digitalwave.iCare.middletier.DataCollection.clsDataUpload_Svc objServ =
                (com.digitalwave.iCare.middletier.DataCollection.clsDataUpload_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.DataCollection.clsDataUpload_Svc));
            return objServ.m_lngInsertLisAppDataByDate(p_objResultArr);

        }

        /// <summary>
        /// ���������ϸ��Ϣ
        /// </summary>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        public long m_lngInsertLisAppItemDataByDate(clsLISApplItem_VO[] p_objResultArr)
        {
            com.digitalwave.iCare.middletier.DataCollection.clsDataUpload_Svc objServ =
                (com.digitalwave.iCare.middletier.DataCollection.clsDataUpload_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.DataCollection.clsDataUpload_Svc));
            return objServ.m_lngInsertLisAppItemDataByDate(p_objResultArr);
        }

        /// <summary>
        /// �����������ϸ��Ϣ
        /// </summary>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        public long m_lngInsertLisAppItemDetialDataByDate(clsLISApplDetial_VO[] p_objResultArr)
        {
            com.digitalwave.iCare.middletier.DataCollection.clsDataUpload_Svc objServ =
                (com.digitalwave.iCare.middletier.DataCollection.clsDataUpload_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.DataCollection.clsDataUpload_Svc));
            return objServ.m_lngInsertLisAppItemDetialDataByDate(p_objResultArr);

        }


        #endregion

        #region ��ȡ�����Ϣ
        /// <summary>
        /// ��ȡ�����Ϣ
        /// </summary>
        /// <param name="p_datForUpload"></param>
        /// <param name="p_arrInStorageInfo_VO"></param>
        /// <returns></returns>
        internal long m_lngGetInStorageInfo(DateTime p_datForUpload, out clsInStorageInfo_VO[] p_arrInStorageInfo_VO)
        {
            com.digitalwave.iCare.middletier.DataCollection.clsHisMZReportToSvc objServ =
               (com.digitalwave.iCare.middletier.DataCollection.clsHisMZReportToSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.DataCollection.clsHisMZReportToSvc));
            return objServ.m_lngGetInStorageInfo(p_datForUpload, out p_arrInStorageInfo_VO);
        }
        #endregion

        #region �ϴ������Ϣ
        /// <summary>
        /// �ϴ������Ϣ
        /// </summary>
        /// <param name="p_clsInStorageInfo_VO"></param>
        /// <returns></returns>
        internal long m_lngUploadInStorageInfo(clsInStorageInfo_VO p_clsInStorageInfo_VO)
        {
            com.digitalwave.iCare.middletier.DataCollection.clsDataUpload_Svc objServ =
               (com.digitalwave.iCare.middletier.DataCollection.clsDataUpload_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.DataCollection.clsDataUpload_Svc));
            return objServ.m_lngUploadInStorageInfo(p_clsInStorageInfo_VO);
        }
        #endregion

        #region ��ȡ������Ϣ
        /// <summary>
        /// ��ȡ������Ϣ
        /// </summary>
        /// <param name="p_datForUpload"></param>
        /// <param name="p_arrOutStorageInfo_VO"></param>
        /// <returns></returns>
        internal long m_lngGetOutStorageInfo(DateTime p_datForUpload, out clsOutStorageInfo_VO[] p_arrOutStorageInfo_VO)
        {
            com.digitalwave.iCare.middletier.DataCollection.clsHisMZReportToSvc objServ =
               (com.digitalwave.iCare.middletier.DataCollection.clsHisMZReportToSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.DataCollection.clsHisMZReportToSvc));
            return objServ.m_lngGetOutStorageInfo(p_datForUpload, out p_arrOutStorageInfo_VO);
        }
        #endregion 

        #region �ϴγ�����Ϣ
        /// <summary>
        /// �ϴ�������Ϣ
        /// </summary>
        /// <param name="p_clsOutStorageInfo_VO"></param>
        /// <returns></returns>
        internal long m_lngUploadOutStorageInfo(clsOutStorageInfo_VO p_clsOutStorageInfo_VO)
        {
            com.digitalwave.iCare.middletier.DataCollection.clsDataUpload_Svc objServ =
               (com.digitalwave.iCare.middletier.DataCollection.clsDataUpload_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.DataCollection.clsDataUpload_Svc));
            return objServ.m_lngUploadOutStorageInfo(p_clsOutStorageInfo_VO);
        }
        #endregion

        #region ��ȡҩ������Ϣ
        /// <summary>
        /// ��ȡҩ������Ϣ
        /// </summary>
        /// <param name="p_dtmUpLoadDate"></param>
        /// <param name="p_arrStorageInfo_VO"></param>
        /// <returns></returns>
        public long m_lngGetStorageInfo(DateTime p_dtmUpLoadDate, out com.digitalwave.iCare.ValueObject.clsStorageInfo_VO[] p_arrStorageInfo_VO)
        {
            com.digitalwave.iCare.middletier.DataCollection.clsHisMZReportToSvc objServ =
                (com.digitalwave.iCare.middletier.DataCollection.clsHisMZReportToSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.DataCollection.clsHisMZReportToSvc));
            return objServ.m_lngGetStorageInfo(p_dtmUpLoadDate, out p_arrStorageInfo_VO);
        }
        #endregion

        #region ҩ������Ϣ�ϱ�
        /// <summary>
        /// ҩ������Ϣ�ϱ�
        /// </summary>
        /// <param name="p_arrDrugInfo_VO"></param>
        /// <returns></returns>
        public long m_lngUploadStorageInfo(com.digitalwave.iCare.ValueObject.clsStorageInfo_VO p_arrStorageInfo_VO)
        {
            com.digitalwave.iCare.middletier.DataCollection.clsDataUpload_Svc objServ =
                (com.digitalwave.iCare.middletier.DataCollection.clsDataUpload_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.DataCollection.clsDataUpload_Svc));
            return objServ.m_lngUploadStorageInfo(p_arrStorageInfo_VO);
        }
        #endregion

        #region ��ȡ��Ŀ��Ϣ
        /// <summary>
        /// ��ȡ��Ŀ��Ϣ
        /// </summary>
        /// <param name="p_datForUpload"></param>
        /// <param name="p_arrHEALTH_ITEAM_VO"></param>
        /// <returns></returns>
        internal long m_lngGetItemInfo(DateTime p_datForUpload, out clsHEALTH_ITEAM_VO[] p_arrHEALTH_ITEAM_VO)
        {
            com.digitalwave.iCare.middletier.DataCollection.clsHisMZReportToSvc objServ =
               (com.digitalwave.iCare.middletier.DataCollection.clsHisMZReportToSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.DataCollection.clsHisMZReportToSvc));
            return objServ.m_lngGetItemInfo(p_datForUpload, out p_arrHEALTH_ITEAM_VO);
        }
        #endregion

        #region �ϴ���ͳһ��Ŀ����Ϣ
        /// <summary>
        /// �ϴ���ͳһ��Ŀ����Ϣ
        /// </summary>
        /// <param name="p_clsOutStorageInfo_VO"></param>
        /// <returns></returns>
        internal long m_lngUploadItemInfo(clsHEALTH_ITEAM_VO p_clsHEALTH_ITEAM_VO)
        {
            com.digitalwave.iCare.middletier.DataCollection.clsDataUpload_Svc objServ =
               (com.digitalwave.iCare.middletier.DataCollection.clsDataUpload_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.DataCollection.clsDataUpload_Svc));
            //return objServ.m_lngUploadOutStorageInfo(p_clsHEALTH_ITEAM_VO);
            return 1;
        }
        #endregion
    }
}