using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;
using System.Collections;

namespace com.digitalwave.iCare.BIHOrder
{
    /// <summary>
    /// ҽ���ύ	�߼����Ʋ�
    /// ���ߣ� ����
    /// ����ʱ�䣺 2005-02-21
    /// </summary>
    public class clsDcl_CommitOrder : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region ���캯��
        public clsDcl_CommitOrder()
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //
        }
        #endregion

        #region ��ѯ���ύ��ҽ��
        /// <summary>
        /// ��ȡδ�ύ��ҽ��	���ݲ�����ʼ�ͽ�������
        /// </summary>
        /// <param name="p_strAreaID">����ID</param>
        /// <param name="p_strBedBeginNO">��ʼ��λ��</param>
        /// <param name="p_strBedEndNO">������λ��</param>
        /// <param name="p_objCommitOrderArr">�ύҽ������</param>
        /// <returns></returns>
        public long m_lngGetOrderCommit(string p_strAreaID, string p_strBedBeginNO, string p_strBedEndNO, out clsCommitOrder[] p_objCommitOrderArr )
        {

            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngGetOrderCommit(objPrincipal, p_strAreaID, p_strBedBeginNO, p_strBedEndNO, out p_objCommitOrderArr );
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        /// <summary>
        /// ��ȡδ�ύ��ҽ��	���ݲ���������
        /// </summary>
        /// <param name="p_strAreaID">����ID</param>
        /// <param name="p_strBedIDs">�ö��ŷָ��Ĳ���ID	{���Ϊ������Ϊ��ѯ����}</param>
        /// <param name="p_objCommitOrderArr">�ύҽ������</param>
        /// <returns></returns>
        public long m_lngGetOrderCommit(string p_strAreaID, string p_strBedIDs, out clsCommitOrder[] p_objCommitOrderArr )
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngGetOrderCommit(objPrincipal, p_strAreaID, p_strBedIDs, out p_objCommitOrderArr );
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        /// <summary>
        /// ��ȡδ�ύ��ҽ��	���ݲ�����������Ա����
        /// </summary>
        /// <param name="CREATORID_CHR"></param>
        /// <param name="p_strAreaID"></param>
        /// <param name="p_strBedIDs"></param>
        /// <param name="p_objCommitOrderArr"></param>
        /// <returns></returns>
        public long m_lngGetOrderCommitByEmpID(string CREATORID_CHR, string p_strAreaID, string p_strBedIDs, out clsCommitOrder[] p_objCommitOrderArr )
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngGetOrderCommitByEmpID(objPrincipal, CREATORID_CHR, p_strAreaID, p_strBedIDs, out p_objCommitOrderArr );
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        public long m_lngGetOrderCommitByEmpIDAndRegisterID(string CREATORID_CHR, string m_strRegisterID, out clsCommitOrder[] p_objCommitOrderArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngGetOrderCommitByEmpIDAndRegisterID(objPrincipal, CREATORID_CHR, m_strRegisterID, out p_objCommitOrderArr);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion

        #region ���˷�����ϸ
        /// <summary>
        /// ��ȡ���˷�����ϸ	����ҽ��ID[����]
        /// </summary>
        /// <param name="p_strOrderIDArr">ҽ��ID	[����]</param>
        /// <param name="p_objResultArr">���˷�����ϸ��Vo����	[����]</param>
        /// <returns></returns>
        public long m_lngGetOrderdicChargeByOrderID(string p_strOrderID, out clsT_aid_bih_orderdic_charge_VO[] p_objResultArr )
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderChangeService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderChangeService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderChangeService));
            lngRes = objSvc.m_lngGetOrderdicChargeByOrderID(objPrincipal, p_strOrderID, out p_objResultArr );
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        #endregion

        #region ���������Ϣ

        public long m_lngGetORDERCHARGEDEPT(string m_strSeq_int, out clsBIHChargeItem objChargeItem, out clsBIHExecOrder order )
        {
            long lngRes = 0;

            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderChangeService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderChangeService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderChangeService));
            lngRes = objSvc.m_GetORDERCHARGEDEPT(objPrincipal, m_strSeq_int, out objChargeItem, out  order );
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        #endregion

        #region �����б�


        public long m_lngGetDEPTList(string strFindCode, out ArrayList[] arrItem)
        {
            long lngRes = 0;

            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderChangeService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderChangeService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderChangeService));
            lngRes = objSvc.m_lngGetDEPTList(objPrincipal, strFindCode, out arrItem);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        public long m_lngGetDEPTList(string strFindCode, string m_strOrdercateid_chr, out ArrayList[] arrItem, bool m_blnewTag)
        {
            long lngRes = 0;

            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderChangeService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderChangeService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderChangeService));
            lngRes = objSvc.m_lngGetDEPTList(objPrincipal, strFindCode, m_strOrdercateid_chr, out arrItem, m_blnewTag);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }


        public long m_lngGetDEPTList(string strFindCode, string p_strSeq_int, out ArrayList[] arrItem)
        {
            long lngRes = 0;

            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderChangeService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderChangeService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderChangeService));
            lngRes = objSvc.m_lngGetDEPTList(objPrincipal, strFindCode, p_strSeq_int, out arrItem);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        #endregion

        internal long SaveTheDeptChange(string p_strSeq_int, string m_strClacarea_chr)
        {
            long lngRes = 0;

            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderChangeService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderChangeService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderChangeService));
            lngRes = objSvc.SaveTheDeptChange(objPrincipal, p_strSeq_int, m_strClacarea_chr);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        internal long m_lngGetDEPTDefault(string m_strCREATEAREA_ID, string m_strItemID, out ArrayList arrItem)
        {
            long lngRes = 0;

            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderChangeService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderChangeService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderChangeService));
            lngRes = objSvc.m_lngGetDEPTDefault(objPrincipal, m_strCREATEAREA_ID, m_strItemID, out arrItem);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        internal long m_lngGetOrderLisSign(string[] m_arrOrders, out DataTable m_dtOrderSign)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface));
            lngRes = objSvc.m_lngGetOrderLisSign(m_arrOrders, out m_dtOrderSign);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        internal long m_lngGetOrderCommitByOrderID(ref string strApp, string strNewDic, ref int intSampleFlag, string strOrderID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngGetOrderCommitByOrderID(ref strApp, strNewDic, ref intSampleFlag, strOrderID);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
    }
}
