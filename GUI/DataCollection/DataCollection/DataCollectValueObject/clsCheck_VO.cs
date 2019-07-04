using System;
using System.Collections.Generic;
using System.Text;

namespace com.digitalwave.iCare.ValueObject
{

    /// <summary>
    /// 检查单信息
    /// </summary>
    [Serializable]
    public class clsCheckRecord : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// 就诊流水号
        /// </summary>
        public string m_strVisitNo = string.Empty;
        /// <summary>
        /// 住院流水号
        /// </summary>
        public string m_strInHossSeqNo = string.Empty;
        /// <summary>
        /// 检查单号
        /// </summary>
        public string m_strCheckRecordID = string.Empty;
        /// <summary>
        /// 检查日期
        /// </summary>
        public DateTime m_dtmCheckRecordAppDate;
        /// <summary>
        /// 开单日期
        /// </summary>
        public DateTime m_dtmCheckRecordDate;
        /// <summary>
        /// 开单医生代码
        /// </summary>
        public string m_strClinicianCode = string.Empty;
        /// <summary>
        /// 开单医生姓名
        /// </summary>
        public string m_strClinicianName = string.Empty;
        /// <summary>
        /// 检查医生姓名
        /// </summary>
        public string m_strClinicianAppName = string.Empty;
        /// <summary>
        /// 检查医生代码
        /// </summary>
        public string m_strClinicianAppCode = string.Empty;
        /// <summary>
        /// 检查仪器
        /// </summary>
        public string m_strCheckReocrdApparatus = string.Empty;
        /// <summary>
        /// 检查类别 1 B超  2 心电图  3放射科类  4脑电图  5 CT  6其他
        /// </summary>
        public string m_strCheckRecordType = string.Empty;
        /// <summary>
        /// 检查项目名称
        /// </summary>
        public string m_strCheckRecordSubName = string.Empty;
        /// <summary>
        /// 检查部位
        /// </summary>
        public string m_strCheckSite = string.Empty;
        /// <summary>
        /// 检查报告内容
        /// </summary>
        public string m_strCheckRecordContent = string.Empty;
        /// <summary>
        /// 检查结果  0 未查 1 阴性 2 阳性
        /// </summary>
        public string m_strCheckRecordResult = string.Empty;
        /// <summary>
        /// 开单科室代码
        /// </summary>
        public string m_strCheckRecordDeptCode = string.Empty;
        /// <summary>
        /// 开单科室名称
        /// </summary>
        public string m_strCheckRecordDeptName = string.Empty;
        /// <summary>
        /// 执行科室代码
        /// </summary>
        public string m_strCheckRecordAppDeptCode = string.Empty;
        /// <summary>
        /// 执行科室名称
        /// </summary>
        public string m_strCheckRecordAppDeptName = string.Empty;
        /// <summary>
        /// 医院代码 茶山医院457226325
        /// </summary>
        public string m_strOrganCode = "457226325";

        public string m_strKind = string.Empty;
        /// <summary>
        /// 作废标识 1有效 2无效
        /// </summary>
        public string m_strInvalid = string.Empty;
    }

    /// <summary>
    /// 检查图片
    /// </summary>
    [Serializable]
    public class clsCheckPic : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// 检查单号
        /// </summary>
        public string m_strCheckRecordID;
        /// <summary>
        /// 医院代码 茶山医院457226325
        /// </summary>
        public string m_strOrganCode = "457226325";
        /// <summary>
        /// 图片号
        /// </summary>
        public string m_strPicID;
        /// <summary>
        /// 图片类型 1 DICOM 2 BMP 3 JPG 4 GIF
        /// </summary>
        public int m_intPicType = 3;
        /// <summary>
        /// 图片
        /// </summary>
        public byte[] m_bytPic;

        /// <summary>
        /// 检查仪器
        /// </summary>
        public string m_strCheckRecordAppAratus = string.Empty;

        /// <summary>
        /// 检查部位
        /// </summary>
        public string m_strCheckSite = string.Empty;

        /// <summary>
        /// 系统时间
        /// </summary>
        public DateTime m_strSystemTime = DateTime.MinValue;
    }
}
