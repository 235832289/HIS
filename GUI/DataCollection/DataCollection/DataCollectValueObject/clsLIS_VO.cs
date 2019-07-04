using System;
using System.Collections.Generic;
using System.Text;

namespace com.digitalwave.iCare.ValueObject
{
    #region
    ///// <summary>
    ///// �������뵥��ϢVO
    ///// </summary>
    //[Serializable]
    //public class clsLISAppl_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    //{
    //    /// <summary>
    //    /// ������ˮ��
    //    /// </summary>
    //    public string m_strVISITNO;
    //    /// <summary>
    //    /// סԺ��ˮ��
    //    /// </summary>
    //    public string m_strINHOSSEQNO;
    //    /// <summary>
    //    /// ���鵥��
    //    /// </summary>
    //    public string m_strOBSERVATIONID;
    //    /// <summary>
    //    /// ��������
    //    /// </summary>
    //    public string m_strOBSERVATIONDATETIM;
    //    /// <summary>
    //    /// ����ʱ��
    //    /// </summary>
    //    public string m_strCREATEOBSERVATIONDATETIME;
    //    /// <summary>
    //    /// ����ҽ������
    //    /// </summary>
    //    public string m_strCREATECLINICIANCODE;
    //    /// <summary>
    //    /// ����ҽ������
    //    /// </summary>
    //    public string m_strCREATECLINICIANNAME;
    //    /// <summary>
    //    /// ������Ա����
    //    /// </summary>
    //    public string m_strOBSERVATIONOPTCODE;
    //    /// <summary>
    //    /// ������Ա����
    //    /// </summary>
    //    public string m_strOBSERVATIONOPTNAME;
    //    /// <summary>
    //    /// ���鷽��
    //    /// </summary>
    //    public string m_strOBSERVATIONWAY;
    //    /// <summary>
    //    /// �������Ҵ���
    //    /// </summary>
    //    public string m_strOBSERVATIONDEPTCODE;
    //    /// <summary>
    //    /// ������������
    //    /// </summary>
    //    public string m_strOBSERVATIONDEPTNAME;
    //    /// <summary>
    //    /// ִ�п��Ҵ���
    //    /// </summary>
    //    public string m_strOBSERVATIONOPTDEPTCODE;
    //    /// <summary>
    //    /// ִ�п�������
    //    /// </summary>
    //    public string m_strOBSERVATIONOPTDEPTNAME;
    //}
    #endregion

    #region
    ///// <summary>
    ///// ������ϸ��ϢVO
    ///// </summary>
    //[Serializable]
    //public class clsLISApplItem_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    //{
    //    /// <summary>
    //    /// ���鵥��
    //    /// </summary>
    //    public string m_strOBSERVATIONID;
    //    /// <summary>
    //    /// ������Ŀ����
    //    /// </summary>
    //    public string m_strOBSERVATIONSUBID;
    //    /// <summary>
    //    /// ������Ŀ����
    //    /// </summary>
    //    public string m_strOBSERVATIONSUBNAME;
    //    /// <summary>
    //    /// ������Ŀֵ
    //    /// </summary>
    //    public string m_strOBSERVATIONVALUE;
    //    /// <summary>
    //    /// ��λ
    //    /// </summary>
    //    public string m_strUNITS;
    //    /// <summary>
    //    /// �ο���Χ
    //    /// </summary>
    //    public string m_strREFERENCESRANGE;
    //    /// <summary>
    //    /// ����ָ��
    //    /// </summary>
    //    public string m_strOBSERVATIONRESULTSTATUS;
    //    /// <summary>
    //    /// ��ע
    //    /// </summary>
    //    public string m_strDEMO;
    //}
    #endregion

    #region
    ///// <summary>
    ///// ��������ϸ��Ϣ
    ///// </summary>
    //[Serializable]
    //public class clsLISApplDetial_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    //{
    //    /// <summary>
    //    /// ���鵥��
    //    /// </summary>
    //    public string m_strOBSERVATIONID;
    //    /// <summary>
    //    /// ������Ŀ����
    //    /// </summary>
    //    public string m_strOBSERVATIONSUB_ID;
    //    /// <summary>
    //    /// ��������Ŀ����
    //    /// </summary>
    //    public string m_strOBSERVATIONCODE;
    //    /// <summary>
    //    /// �������Ŀ����
    //    /// </summary>
    //    public string m_strOBSERVATIONNAME;
    //    /// <summary>
    //    /// ������
    //    /// </summary>
    //    public string m_strOBSERVATIONVALUE;
    //}
    #endregion

    #region �������뵥��ϢVO
    /// <summary>
    /// �������뵥��ϢVO
    /// </summary>
    [Serializable]
    public class clsLISAppl_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// ҽԺ��������
        /// </summary>
        public string m_strORGANCODE;
        /// <summary>
        /// ������ˮ��
        /// </summary>
        public string m_strVISITNO;
        /// <summary>
        /// סԺ��ˮ��
        /// </summary>
        public string m_strINHOSSEQNO;
        /// <summary>
        /// ���鵥��
        /// </summary>
        public string m_strOBSERVATIONID;
        /// <summary>
        /// ��������
        /// </summary>
        public string m_strOBSERVATIONDATETIM;
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public string m_strCREATEOBSERVATIONDATETIME;
        /// <summary>
        /// ����ҽ������
        /// </summary>
        public string m_strCREATECLINICIANCODE;
        /// <summary>
        /// ����ҽ������
        /// </summary>
        public string m_strCREATECLINICIANNAME;
        /// <summary>
        /// ������Ա����
        /// </summary>
        public string m_strOBSERVATIONOPTCODE;
        /// <summary>
        /// ������Ա����
        /// </summary>
        public string m_strOBSERVATIONOPTNAME;
        /// <summary>
        /// ���鷽��
        /// </summary>
        public string m_strOBSERVATIONWAY;
        /// <summary>
        /// �������Ҵ���
        /// </summary>
        public string m_strOBSERVATIONDEPTCODE;
        /// <summary>
        /// ������������
        /// </summary>
        public string m_strOBSERVATIONDEPTNAME;
        /// <summary>
        /// ִ�п��Ҵ���
        /// </summary>
        public string m_strOBSERVATIONOPTDEPTCODE;
        /// <summary>
        /// ִ�п�������
        /// </summary>
        public string m_strOBSERVATIONOPTDEPTNAME;
        /// <summary>
        /// �����Ա����
        /// </summary>
        public string m_strOBSERVATIONCHECKCODE;
        /// <summary>
        /// �����Ա����
        /// </summary>
        public string m_strOBSERVATIONCHECKNAME;
        /// <summary>
        /// ���ϱ�־���� 0 ��Ч  1 ��Ч
        /// </summary>
        public string m_strFLAG;
        /// <summary>
        /// �������ʴ��� 1 ������ҽ�Ʊ���  2 ��ҵ����  3 �Է�ҽ��  4 ����ҽ��  5 ��ͳ��  6 ����
        /// </summary>
        public string m_strKIND = string.Empty;
        /// <summary>
        /// �����������
        /// </summary>
        public string m_strPROVESWATCHCODE;
        /// <summary>
        /// ������������
        /// </summary>
        public string m_strPROVESWATCHNAME;
        /// <summary>
        /// ����������
        /// </summary>
        public string m_strPROVETYPE;
    }
    #endregion

    #region ������ϸ��ϢVO
    /// <summary>
    /// ������ϸ��ϢVO
    /// </summary>
    [Serializable]
    public class clsLISApplItem_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// ҽԺ��������
        /// </summary>
        public string m_strORGANCODE;
        /// <summary>
        /// ��ϸ��Ϣ��ˮ��
        /// </summary>
        public string m_strLIST_SEQ;
        /// <summary>
        /// �������
        /// </summary>
        public string m_strRECORDTYPE;
        /// <summary>
        /// ���鵥��
        /// </summary>
        public string m_strOBSERVATIONID;
        /// <summary>
        /// ������Ŀ����
        /// </summary>
        public string m_strOBSERVATIONSUBID;
        /// <summary>
        /// ����Ӣ������
        /// </summary>
        public string m_strPROVENAME;
        /// <summary>
        /// ������Ŀ����
        /// </summary>
        public string m_strOBSERVATIONSUBNAME;
        /// <summary>
        /// ������� 1��������2�� ���ԡ�99 δ֪
        /// </summary>
        public string m_strRESULTTYPE;
        /// <summary>
        /// ������Ŀֵ
        /// </summary>
        public string m_strOBSERVATIONVALUE;
        /// <summary>
        /// ��λ
        /// </summary>
        public string m_strUNITS;
        /// <summary>
        /// �ο���Χ
        /// </summary>
        public string m_strREFERENCESRANGE;
        /// <summary>
        /// ����ָ��
        /// </summary>
        public string m_strOBSERVATIONRESULTSTATUS;
        /// <summary>
        /// ��ע
        /// </summary>
        public string m_strDEMO;
        /// <summary>
        /// ��������
        /// </summary>
        public string m_strAPPARATUS;
        /// <summary>
        /// �쳣��ʾ
        /// </summary>
        public string m_strSINGULARITY;
    }
    #endregion

    #region ��������ϸ��Ϣ
    /// <summary>
    /// ��������ϸ��Ϣ
    /// </summary>
    [Serializable]
    public class clsLISApplDetial_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// ����ϸ��Ϣ��ˮ��
        /// </summary>
        public string m_strSUBLIST_SEQ;
        /// <summary>
        /// ���鵥��
        /// </summary>
        public string m_strOBSERVATIONID;
        /// <summary>
        /// ������Ŀ����
        /// </summary>
        public string m_strOBSERVATIONSUB_ID;
        /// <summary>
        /// ��������Ŀ����
        /// </summary>
        public string m_strOBSERVATIONCODE;
        /// <summary>
        /// �������Ŀ����
        /// </summary>
        public string m_strOBSERVATIONNAME;
        /// <summary>
        /// �������Ŀ����(Ӣ��)
        /// </summary>
        public string m_strOBSERVATIONENNAME;
        /// <summary>
        /// ������
        /// </summary>
        public string m_strOBSERVATIONVALUE;
    }
    #endregion

}
