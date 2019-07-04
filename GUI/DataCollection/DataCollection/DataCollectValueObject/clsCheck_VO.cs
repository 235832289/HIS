using System;
using System.Collections.Generic;
using System.Text;

namespace com.digitalwave.iCare.ValueObject
{

    /// <summary>
    /// ��鵥��Ϣ
    /// </summary>
    [Serializable]
    public class clsCheckRecord : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// ������ˮ��
        /// </summary>
        public string m_strVisitNo = string.Empty;
        /// <summary>
        /// סԺ��ˮ��
        /// </summary>
        public string m_strInHossSeqNo = string.Empty;
        /// <summary>
        /// ��鵥��
        /// </summary>
        public string m_strCheckRecordID = string.Empty;
        /// <summary>
        /// �������
        /// </summary>
        public DateTime m_dtmCheckRecordAppDate;
        /// <summary>
        /// ��������
        /// </summary>
        public DateTime m_dtmCheckRecordDate;
        /// <summary>
        /// ����ҽ������
        /// </summary>
        public string m_strClinicianCode = string.Empty;
        /// <summary>
        /// ����ҽ������
        /// </summary>
        public string m_strClinicianName = string.Empty;
        /// <summary>
        /// ���ҽ������
        /// </summary>
        public string m_strClinicianAppName = string.Empty;
        /// <summary>
        /// ���ҽ������
        /// </summary>
        public string m_strClinicianAppCode = string.Empty;
        /// <summary>
        /// �������
        /// </summary>
        public string m_strCheckReocrdApparatus = string.Empty;
        /// <summary>
        /// ������ 1 B��  2 �ĵ�ͼ  3�������  4�Ե�ͼ  5 CT  6����
        /// </summary>
        public string m_strCheckRecordType = string.Empty;
        /// <summary>
        /// �����Ŀ����
        /// </summary>
        public string m_strCheckRecordSubName = string.Empty;
        /// <summary>
        /// ��鲿λ
        /// </summary>
        public string m_strCheckSite = string.Empty;
        /// <summary>
        /// ��鱨������
        /// </summary>
        public string m_strCheckRecordContent = string.Empty;
        /// <summary>
        /// �����  0 δ�� 1 ���� 2 ����
        /// </summary>
        public string m_strCheckRecordResult = string.Empty;
        /// <summary>
        /// �������Ҵ���
        /// </summary>
        public string m_strCheckRecordDeptCode = string.Empty;
        /// <summary>
        /// ������������
        /// </summary>
        public string m_strCheckRecordDeptName = string.Empty;
        /// <summary>
        /// ִ�п��Ҵ���
        /// </summary>
        public string m_strCheckRecordAppDeptCode = string.Empty;
        /// <summary>
        /// ִ�п�������
        /// </summary>
        public string m_strCheckRecordAppDeptName = string.Empty;
        /// <summary>
        /// ҽԺ���� ��ɽҽԺ457226325
        /// </summary>
        public string m_strOrganCode = "457226325";

        public string m_strKind = string.Empty;
        /// <summary>
        /// ���ϱ�ʶ 1��Ч 2��Ч
        /// </summary>
        public string m_strInvalid = string.Empty;
    }

    /// <summary>
    /// ���ͼƬ
    /// </summary>
    [Serializable]
    public class clsCheckPic : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// ��鵥��
        /// </summary>
        public string m_strCheckRecordID;
        /// <summary>
        /// ҽԺ���� ��ɽҽԺ457226325
        /// </summary>
        public string m_strOrganCode = "457226325";
        /// <summary>
        /// ͼƬ��
        /// </summary>
        public string m_strPicID;
        /// <summary>
        /// ͼƬ���� 1 DICOM 2 BMP 3 JPG 4 GIF
        /// </summary>
        public int m_intPicType = 3;
        /// <summary>
        /// ͼƬ
        /// </summary>
        public byte[] m_bytPic;

        /// <summary>
        /// �������
        /// </summary>
        public string m_strCheckRecordAppAratus = string.Empty;

        /// <summary>
        /// ��鲿λ
        /// </summary>
        public string m_strCheckSite = string.Empty;

        /// <summary>
        /// ϵͳʱ��
        /// </summary>
        public DateTime m_strSystemTime = DateTime.MinValue;
    }
}
