using System;
using System.Collections.Generic;
using System.Text;

namespace com.digitalwave.iCare.ValueObject
{
    #region
    ///// <summary>
    ///// 检验申请单信息VO
    ///// </summary>
    //[Serializable]
    //public class clsLISAppl_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    //{
    //    /// <summary>
    //    /// 就诊流水号
    //    /// </summary>
    //    public string m_strVISITNO;
    //    /// <summary>
    //    /// 住院流水号
    //    /// </summary>
    //    public string m_strINHOSSEQNO;
    //    /// <summary>
    //    /// 检验单号
    //    /// </summary>
    //    public string m_strOBSERVATIONID;
    //    /// <summary>
    //    /// 检验日期
    //    /// </summary>
    //    public string m_strOBSERVATIONDATETIM;
    //    /// <summary>
    //    /// 开单时间
    //    /// </summary>
    //    public string m_strCREATEOBSERVATIONDATETIME;
    //    /// <summary>
    //    /// 开单医生代码
    //    /// </summary>
    //    public string m_strCREATECLINICIANCODE;
    //    /// <summary>
    //    /// 开单医生姓名
    //    /// </summary>
    //    public string m_strCREATECLINICIANNAME;
    //    /// <summary>
    //    /// 检验人员代码
    //    /// </summary>
    //    public string m_strOBSERVATIONOPTCODE;
    //    /// <summary>
    //    /// 检验人员姓名
    //    /// </summary>
    //    public string m_strOBSERVATIONOPTNAME;
    //    /// <summary>
    //    /// 检验方法
    //    /// </summary>
    //    public string m_strOBSERVATIONWAY;
    //    /// <summary>
    //    /// 开单科室代码
    //    /// </summary>
    //    public string m_strOBSERVATIONDEPTCODE;
    //    /// <summary>
    //    /// 开单科室名称
    //    /// </summary>
    //    public string m_strOBSERVATIONDEPTNAME;
    //    /// <summary>
    //    /// 执行科室代码
    //    /// </summary>
    //    public string m_strOBSERVATIONOPTDEPTCODE;
    //    /// <summary>
    //    /// 执行科室名称
    //    /// </summary>
    //    public string m_strOBSERVATIONOPTDEPTNAME;
    //}
    #endregion

    #region
    ///// <summary>
    ///// 检验明细信息VO
    ///// </summary>
    //[Serializable]
    //public class clsLISApplItem_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    //{
    //    /// <summary>
    //    /// 检验单号
    //    /// </summary>
    //    public string m_strOBSERVATIONID;
    //    /// <summary>
    //    /// 检验项目代码
    //    /// </summary>
    //    public string m_strOBSERVATIONSUBID;
    //    /// <summary>
    //    /// 检验项目名称
    //    /// </summary>
    //    public string m_strOBSERVATIONSUBNAME;
    //    /// <summary>
    //    /// 检验项目值
    //    /// </summary>
    //    public string m_strOBSERVATIONVALUE;
    //    /// <summary>
    //    /// 单位
    //    /// </summary>
    //    public string m_strUNITS;
    //    /// <summary>
    //    /// 参考范围
    //    /// </summary>
    //    public string m_strREFERENCESRANGE;
    //    /// <summary>
    //    /// 检验指标
    //    /// </summary>
    //    public string m_strOBSERVATIONRESULTSTATUS;
    //    /// <summary>
    //    /// 备注
    //    /// </summary>
    //    public string m_strDEMO;
    //}
    #endregion

    #region
    ///// <summary>
    ///// 检验子明细信息
    ///// </summary>
    //[Serializable]
    //public class clsLISApplDetial_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    //{
    //    /// <summary>
    //    /// 检验单号
    //    /// </summary>
    //    public string m_strOBSERVATIONID;
    //    /// <summary>
    //    /// 检验项目代码
    //    /// </summary>
    //    public string m_strOBSERVATIONSUB_ID;
    //    /// <summary>
    //    /// 检验子项目代码
    //    /// </summary>
    //    public string m_strOBSERVATIONCODE;
    //    /// <summary>
    //    /// 检出子项目名称
    //    /// </summary>
    //    public string m_strOBSERVATIONNAME;
    //    /// <summary>
    //    /// 检出结果
    //    /// </summary>
    //    public string m_strOBSERVATIONVALUE;
    //}
    #endregion

    #region 检验申请单信息VO
    /// <summary>
    /// 检验申请单信息VO
    /// </summary>
    [Serializable]
    public class clsLISAppl_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// 医院机构代码
        /// </summary>
        public string m_strORGANCODE;
        /// <summary>
        /// 就诊流水号
        /// </summary>
        public string m_strVISITNO;
        /// <summary>
        /// 住院流水号
        /// </summary>
        public string m_strINHOSSEQNO;
        /// <summary>
        /// 检验单号
        /// </summary>
        public string m_strOBSERVATIONID;
        /// <summary>
        /// 检验日期
        /// </summary>
        public string m_strOBSERVATIONDATETIM;
        /// <summary>
        /// 开单时间
        /// </summary>
        public string m_strCREATEOBSERVATIONDATETIME;
        /// <summary>
        /// 开单医生代码
        /// </summary>
        public string m_strCREATECLINICIANCODE;
        /// <summary>
        /// 开单医生姓名
        /// </summary>
        public string m_strCREATECLINICIANNAME;
        /// <summary>
        /// 检验人员代码
        /// </summary>
        public string m_strOBSERVATIONOPTCODE;
        /// <summary>
        /// 检验人员姓名
        /// </summary>
        public string m_strOBSERVATIONOPTNAME;
        /// <summary>
        /// 检验方法
        /// </summary>
        public string m_strOBSERVATIONWAY;
        /// <summary>
        /// 开单科室代码
        /// </summary>
        public string m_strOBSERVATIONDEPTCODE;
        /// <summary>
        /// 开单科室名称
        /// </summary>
        public string m_strOBSERVATIONDEPTNAME;
        /// <summary>
        /// 执行科室代码
        /// </summary>
        public string m_strOBSERVATIONOPTDEPTCODE;
        /// <summary>
        /// 执行科室名称
        /// </summary>
        public string m_strOBSERVATIONOPTDEPTNAME;
        /// <summary>
        /// 审核人员代码
        /// </summary>
        public string m_strOBSERVATIONCHECKCODE;
        /// <summary>
        /// 审核人员姓名
        /// </summary>
        public string m_strOBSERVATIONCHECKNAME;
        /// <summary>
        /// 作废标志代码 0 有效  1 无效
        /// </summary>
        public string m_strFLAG;
        /// <summary>
        /// 病人性质代码 1 社会基本医疗保险  2 商业保险  3 自费医疗  4 公费医疗  5 大病统筹  6 其它
        /// </summary>
        public string m_strKIND = string.Empty;
        /// <summary>
        /// 检验样本编号
        /// </summary>
        public string m_strPROVESWATCHCODE;
        /// <summary>
        /// 检验样本名称
        /// </summary>
        public string m_strPROVESWATCHNAME;
        /// <summary>
        /// 检验类别代码
        /// </summary>
        public string m_strPROVETYPE;
    }
    #endregion

    #region 检验明细信息VO
    /// <summary>
    /// 检验明细信息VO
    /// </summary>
    [Serializable]
    public class clsLISApplItem_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// 医院机构代码
        /// </summary>
        public string m_strORGANCODE;
        /// <summary>
        /// 明细信息流水号
        /// </summary>
        public string m_strLIST_SEQ;
        /// <summary>
        /// 检验类别
        /// </summary>
        public string m_strRECORDTYPE;
        /// <summary>
        /// 检验单号
        /// </summary>
        public string m_strOBSERVATIONID;
        /// <summary>
        /// 检验项目代码
        /// </summary>
        public string m_strOBSERVATIONSUBID;
        /// <summary>
        /// 检验英文名称
        /// </summary>
        public string m_strPROVENAME;
        /// <summary>
        /// 检验项目名称
        /// </summary>
        public string m_strOBSERVATIONSUBNAME;
        /// <summary>
        /// 结果类型 1　定量、2　 定性、99 未知
        /// </summary>
        public string m_strRESULTTYPE;
        /// <summary>
        /// 检验项目值
        /// </summary>
        public string m_strOBSERVATIONVALUE;
        /// <summary>
        /// 单位
        /// </summary>
        public string m_strUNITS;
        /// <summary>
        /// 参考范围
        /// </summary>
        public string m_strREFERENCESRANGE;
        /// <summary>
        /// 检验指标
        /// </summary>
        public string m_strOBSERVATIONRESULTSTATUS;
        /// <summary>
        /// 备注
        /// </summary>
        public string m_strDEMO;
        /// <summary>
        /// 仪器名称
        /// </summary>
        public string m_strAPPARATUS;
        /// <summary>
        /// 异常提示
        /// </summary>
        public string m_strSINGULARITY;
    }
    #endregion

    #region 检验子明细信息
    /// <summary>
    /// 检验子明细信息
    /// </summary>
    [Serializable]
    public class clsLISApplDetial_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// 子明细信息流水号
        /// </summary>
        public string m_strSUBLIST_SEQ;
        /// <summary>
        /// 检验单号
        /// </summary>
        public string m_strOBSERVATIONID;
        /// <summary>
        /// 检验项目代码
        /// </summary>
        public string m_strOBSERVATIONSUB_ID;
        /// <summary>
        /// 检验子项目代码
        /// </summary>
        public string m_strOBSERVATIONCODE;
        /// <summary>
        /// 检出子项目名称
        /// </summary>
        public string m_strOBSERVATIONNAME;
        /// <summary>
        /// 检出子项目名称(英文)
        /// </summary>
        public string m_strOBSERVATIONENNAME;
        /// <summary>
        /// 检出结果
        /// </summary>
        public string m_strOBSERVATIONVALUE;
    }
    #endregion

}
