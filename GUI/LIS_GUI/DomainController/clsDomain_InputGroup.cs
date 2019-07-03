using System;
using System.Data;
using com.digitalwave.iCare.middletier.LIS;//LisSvc.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll


namespace com.digitalwave.iCare.gui.LIS
{
    /// <summary>
    /// 
    /// </summary>
    public class clsDomain_InputGroup : com.digitalwave.GUI_Base.clsDomainController_Base
    {

        #region ���캯��
        public clsDomain_InputGroup()
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //
        }
        #endregion

        #region ��ȡɸѡ�����Ŀ�б�
        public long m_lngGetFiltedItems(string[] p_strApplyUnitIDArr, string[] p_strInputGroupIDArr, out string[] p_strItemResultArr)
        {
            long lngRes = 0;
            p_strItemResultArr = null;

            com.digitalwave.iCare.middletier.LIS.clsQueryInputGroupSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryInputGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryInputGroupSvc));
            try
            {
                lngRes = objSvc.m_lngGetFiltedItems(this.objPrincipal, p_strApplyUnitIDArr, p_strInputGroupIDArr, out p_strItemResultArr);
            }
            catch
            {

            }

            return lngRes;
        }
        #endregion

        #region ��ȡָ�����뵥Ԫ���������б�
        public long m_lngGetApplyUnitInfo(string[] p_strApplyUnitIDArr, out DataTable p_dtbResult)
        {
            long lngRes = 0;
            p_dtbResult = null;

            com.digitalwave.iCare.middletier.LIS.clsQueryInputGroupSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryInputGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryInputGroupSvc));
            try
            {
                lngRes = objSvc.m_lngGetApplyUnitInfo(this.objPrincipal, p_strApplyUnitIDArr, out p_dtbResult);
            }
            catch
            {

            }

            return lngRes;
        }
        #endregion


        #region ��ȡָ�����뵥Ԫ�¿��õ�¼�����
        public long m_lngGetInputGroupsByUnit(string[] p_strApplyUnitIDArr, out DataTable p_dtbResult)
        {
            long lngRes = 0;
            p_dtbResult = null;

            com.digitalwave.iCare.middletier.LIS.clsQueryInputGroupSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryInputGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryInputGroupSvc));
            try
            {
                lngRes = objSvc.m_lngGetInputGroupsByUnit(this.objPrincipal, p_strApplyUnitIDArr, out p_dtbResult);
            }
            catch
            {

            }

            return lngRes;
        }
        #endregion


        #region ��ȡ�������-���뵥Ԫ-¼����ϵĵ�������Ϣ
        public long m_lngGetUnitedInputGroupInfo(out clsInputGroupUnited_VO[] p_objResults)
        {
            long lngRes = 0;
            p_objResults = null;

            com.digitalwave.iCare.middletier.LIS.clsQueryInputGroupSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryInputGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryInputGroupSvc));
            try
            {
                lngRes = objSvc.m_lngGetUnitedInputGroupInfo(this.objPrincipal, out p_objResults);
            }
            catch
            {
                
            }

            return lngRes;
        }
        #endregion

        #region ��ȡ���뵥Ԫ��Ŀ��ϸ
        public long m_lngGetApplyUnitItems(string p_strApplyUnitID,out clsCheckItemSimple_VO[] p_objResults)
        {
            long lngRes = 0;
            p_objResults = null;

            com.digitalwave.iCare.middletier.LIS.clsQueryInputGroupSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryInputGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryInputGroupSvc));
            try
            {
                lngRes = objSvc.m_lngGetApplyUnitItems(this.objPrincipal, p_strApplyUnitID, out p_objResults);
            }
            catch
            {

            }

            return lngRes;
        }
        #endregion

        #region ��ȡ¼����ϼ���ϸ
        public long m_lngGetInputGroupInfo(string p_strInputGroupID,out clsInputGroupBaseInfo_VO p_objBaseInfo, out clsInputGroupDetail_VO[] p_objResults)
        {
            long lngRes = 0;
            p_objResults = null;
            p_objBaseInfo = null;

            com.digitalwave.iCare.middletier.LIS.clsQueryInputGroupSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryInputGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryInputGroupSvc));
            try
            {
                lngRes = objSvc.m_lngGetInputGroupInfo(this.objPrincipal, p_strInputGroupID, out p_objBaseInfo, out p_objResults);
            }
            catch
            {

            }

            return lngRes;
        }
        #endregion

        #region ����¼�����
        public long m_lngAddNewInputGroup(clsInputGroupBaseInfo_VO p_objBaseInfo, clsInputGroupDetail_VO[] p_objResults ,out string strID)
        {
            long lngRes = 0;
            strID = null;

            com.digitalwave.iCare.middletier.LIS.clsInputGroupSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsInputGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsInputGroupSvc));
            try
            {
                lngRes = objSvc.m_lngAddNewInputGroup(this.objPrincipal, p_objBaseInfo, p_objResults,out strID);
            }
            catch
            {

            }

            return lngRes;
        }
        #endregion

        #region ����¼�����
        public long m_lngUpdateInputGroup(clsInputGroupBaseInfo_VO p_objBaseInfo, clsInputGroupDetail_VO[] p_objResults)
        {
            long lngRes = 0;

            com.digitalwave.iCare.middletier.LIS.clsInputGroupSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsInputGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsInputGroupSvc));
            try
            {
                lngRes = objSvc.m_lngUpdateInputGroup(this.objPrincipal, p_objBaseInfo, p_objResults);
            }
            catch
            {

            }

            return lngRes;
        }
        #endregion

        #region ɾ��¼�����
        public long m_lngDeleteInputGroup(string strGroupID)
        {
            long lngRes = 0;

            com.digitalwave.iCare.middletier.LIS.clsInputGroupSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsInputGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsInputGroupSvc));
            try
            {
                lngRes = objSvc.m_lngDeleteInputGroup(this.objPrincipal, strGroupID);
            }
            catch
            {

            }

            return lngRes;
        }
        #endregion

    }

}