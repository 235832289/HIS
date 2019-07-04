using System;
using System.Collections.Generic;
using System.Text;

namespace com.digitalwave.iCare.ValueObject
{
    #region 门诊就诊信息VO
    /// <summary>
    /// 门诊就诊信息VO
    /// kenny created in 2008.10.14
    /// </summary>
    [Serializable]
    public class clsOpDiagInfo_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public clsOpDiagInfo_VO()
        {
            //
            // TODO: 在此添加构造函数逻辑
            //
        }
        /// <summary>
        /// 机构代码
        /// </summary>
        public string m_strORGANCODE = string.Empty;
        /// <summary>
        /// 挂号类别编号
        /// </summary>
        public string m_strREGTYPECODE = string.Empty;
        /// <summary>
        /// 挂号类别名称
        /// </summary>
        public string m_strREGTYPENAME = string.Empty;
        /// <summary>
        /// 职业
        /// </summary>
        public string m_strJOB = string.Empty;
        /// <summary>
        /// 籍贯
        /// </summary>
        public string m_strNATIVE_PLACE = string.Empty;
        /// <summary>
        /// 医院最终修改时间(系统时间)
        /// </summary>
        public string m_strSYSTEMDATE = string.Empty;
        /// <summary>
        /// 姓名
        /// </summary>
        public string m_strNAME = string.Empty;
        /// <summary>
        /// 性别
        /// </summary>
        public string m_strSEX = string.Empty;
        /// <summary>
        /// 性质
        /// </summary>
        public string m_strKIND = string.Empty;
        /// <summary>
        /// 民族
        /// </summary>
        public string m_strETHNICGROUP = string.Empty;
        /// <summary>
        /// 家庭地址
        /// </summary>
        public string m_strADDRESS = string.Empty;
        /// <summary>
        /// 工作单位
        /// </summary>
        public string m_strJOBTITLE = string.Empty;
        /// <summary>
        /// 联系电话
        /// </summary>
        public string m_strPHONENUMBERHOME = string.Empty;
        /// <summary>
        /// 联系人
        /// </summary>
        public string m_strCONTACTPERSON = string.Empty;
        /// <summary>
        /// 国籍
        /// </summary>
        public string m_strNATIONALITY = string.Empty;
        /// <summary>
        /// 婚姻状况
        /// </summary>
        public int m_intMARITALSTATUS = 0;
        /// <summary>
        /// 出生日期
        /// </summary>
        public string m_strBIRTHDAY = string.Empty;
        /// <summary>
        /// 身份证号
        /// </summary>
        public string m_strIDNUMBERS = string.Empty;
        /// <summary>
        /// 社保卡号
        /// </summary>
        public string m_strSSID = string.Empty;
        /// <summary>
        /// 门诊号
        /// </summary>
        public string m_strCLINICNO = string.Empty;
        /// <summary>
        /// 就诊号
        /// </summary>
        public string m_strVISITNO = string.Empty;
        /// <summary>
        /// 就诊日期
        /// </summary>
        public string m_strCLINICDATETIME = string.Empty;
        /// <summary>
        /// 就诊科室代码
        /// </summary>
        public string m_strDEPTCODE = string.Empty;
        /// <summary>
        /// 就诊科室名称
        /// </summary>
        public string m_strDEPTNAME = string.Empty;
        /// <summary>
        /// 医生代码
        /// </summary>
        public string m_strCLINICIANCODE = string.Empty;
        /// <summary>
        /// 医生姓名
        /// </summary>
        public string m_strCLINICIANNAME = string.Empty;
        /// <summary>
        /// 主诉
        /// </summary>
        public string m_strPV2 = string.Empty;
        /// <summary>
        /// 现病史
        /// </summary>
        public string m_strPV3 = string.Empty;
        /// <summary>
        /// 体征
        /// </summary>
        public string m_strPV1 = string.Empty;
        /// <summary>
        /// 第一诊断名称
        /// </summary>
        public string m_strDIAGNOSISNAME1 = string.Empty;
        /// <summary>
        /// 第一诊断代码
        /// </summary>
        public string m_strDIAGNOSISCODE1 = string.Empty;
        /// <summary>
        /// 第二诊断名称
        /// </summary>
        public string m_strDIAGNOSISNAME2 = string.Empty;
        /// <summary>
        /// 第二诊断代码
        /// </summary>
        public string m_strDIAGNOSISCODE2 = string.Empty;
        /// <summary>
        /// 第三诊断名称
        /// </summary>
        public string m_strDIAGNOSISNAME3 = string.Empty;
        /// <summary>
        /// 第三诊断代码
        /// </summary>
        public string m_strDIAGNOSISCODE3 = string.Empty;
    }
    #endregion

    #region 门诊费用信息VO
    /// <summary>
    /// 门诊费用信息VO
    /// </summary>
    [Serializable]
    public class clsOpfee_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public clsOpfee_VO()
        {
            //
            // TODO: 在此添加构造函数逻辑
            //
        }

        /// <summary>
        /// 机构代码
        /// </summary>
        public string m_strORGANCODE = string.Empty;
        /// <summary>
        /// 门诊费用流水号
        /// </summary>
        public string m_strCLINICBILL_SEQ = string.Empty;
        /// <summary>
        /// 就诊号
        /// </summary>
        public string m_strVISITNO = string.Empty;
        /// <summary>
        /// 费用性质
        /// </summary>
        public string m_strKIND = string.Empty;
        /// <summary>
        /// 发票总金额
        /// </summary>
        public decimal m_decTOTALFARE = 0;
        /// <summary>
        /// 发票号码
        /// </summary>
        public string m_strBILLNO = string.Empty;
        /// <summary>
        /// 开单科室代码
        /// </summary>
        public string m_strDEPTCODE = string.Empty;
        /// <summary>
        /// 开单科室名称
        /// </summary>
        public string m_strDEPTNAME = string.Empty;
        /// <summary>
        /// 开单医生代码
        /// </summary>
        public string m_strDOCTCODE = string.Empty;
        /// <summary>
        /// 开单医生名称
        /// </summary>
        public string m_strDOCTNAME = string.Empty;
        /// <summary>
        /// 市统一代码
        /// </summary>
        public string m_strITEMID = string.Empty;
        /// <summary>
        /// 医院费用编码
        /// </summary>
        public string m_strFARECODE = string.Empty;
        /// <summary>
        /// 医院费用名称
        /// </summary>
        public string m_strFARENAME = string.Empty;
        /// <summary>
        /// 发票自付金额
        /// </summary>
        public decimal m_decFARESELFPAY = 0;
        /// <summary>
        /// 数量
        /// </summary>
        public decimal m_decAMOUNT = 0;
        /// <summary>
        /// 单价
        /// </summary>
        public decimal m_decPRICE = 0;
        /// <summary>
        /// 金额
        /// </summary>
        public decimal m_decSUM = 0;
        /// <summary>
        /// 发票时间
        /// </summary>
        public string m_strBILLDATE = string.Empty;
        /// <summary>
        /// 项目分类代码
        /// </summary>
        public string m_strITEMKIND = string.Empty;
        /// <summary>
        /// 作废标志
        /// </summary>
        public string m_strFLAG = string.Empty;
    }
    #endregion

    #region 门诊处方信息VO
    /// <summary>
    /// 门诊处方信息VO
    /// </summary>
    [Serializable]
    public class clsRecInfo_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public clsRecInfo_VO()
        {
            //
            // TODO: 在此添加构造函数逻辑
            //
        }

        /// <summary>
        /// 机构代码
        /// </summary>
        public string m_strORGANCODE = string.Empty;
        /// <summary>
        /// 处方流水号
        /// </summary>
        public string m_strRECIPE_SEQ = string.Empty;
        /// <summary>
        /// 就诊号
        /// </summary>
        public string m_strVISITNO = string.Empty;
        /// <summary>
        /// 就诊日期
        /// </summary>
        public string m_strCLINICDATETIME = string.Empty;
        /// <summary>
        /// 处方编号
        /// </summary>
        public string m_strRecipeID = string.Empty;
        /// <summary>
        /// 处方组号
        /// </summary>
        public string m_strRECIPEGROUP = string.Empty;
        /// <summary>
        /// 处方类型
        /// </summary>
        public int m_intRecipeType;
        /// <summary>
        /// 病人性质
        /// </summary>
        public string m_strKIND = string.Empty;
        /// <summary>
        /// 姓名
        /// </summary>
        public string m_strNAME = string.Empty;
        /// <summary>
        /// 开方日期
        /// </summary>
        public string m_strRecipeDateTime = string.Empty;
        /// <summary>
        /// 开方医生代码
        /// </summary>
        public string m_strRecipeClinicianCode = string.Empty;
        /// <summary>
        /// 开方医生姓名
        /// </summary>
        public string m_strRecipeClinicianName = string.Empty;
        /// <summary>
        /// 开方科室代码
        /// </summary>
        public string m_strRecipeDeptCode = string.Empty;
        /// <summary>
        /// 开方科室名称
        /// </summary>
        public string m_strRecipeDeptName = string.Empty;
        /// <summary>
        /// 项目分类代码
        /// </summary>
        public string m_strITEMKIND = string.Empty;
        /// <summary>
        /// 市统一代码
        /// </summary>
        public string m_strITEMID = string.Empty;
        /// <summary>
        /// 项目编号
        /// </summary>
        public string m_strMedicineCode = string.Empty;
        /// <summary>
        /// 项目规格
        /// </summary>
        public string m_strMedicineSpec = string.Empty;
        /// <summary>
        /// 项目名称
        /// </summary>
        public string m_strMedicineName = string.Empty;
        /// <summary>
        /// 用法
        /// </summary>
        public int m_intMedicineUsage;
        /// <summary>
        /// 用法备注
        /// </summary>
        public string m_strUSAGEREMARK = string.Empty;
        /// <summary>
        /// 剂数
        /// </summary>
        public decimal m_decDOSAGENUM = 0;
        /// <summary>
        /// 频次
        /// </summary>
        public string m_strMedicineFrequency = string.Empty;
        /// <summary>
        /// 剂量
        /// </summary>
        public string m_strMedicineDosage = string.Empty;
        /// <summary>
        /// 用量单位
        /// </summary>
        public string m_strUseUnit = string.Empty;
        /// <summary>
        /// 服药天数
        /// </summary>
        public string m_strMedicineDays = string.Empty;
        /// <summary>
        /// 自负比例
        /// </summary>
        public decimal m_decMedicineScale = 0;
        /// <summary>
        /// 项目单位
        /// </summary>
        public string m_strMedicineUnit = string.Empty;
        /// <summary>
        /// 项目数量
        /// </summary>
        public decimal m_decUnitNumber = 0;
        /// <summary>
        /// 项目单价
        /// </summary>
        public decimal m_decUnitPrice = 0;
        /// <summary>
        /// 项目合计金额
        /// </summary>
        public decimal m_decITEMSUM = 0;
        /// <summary>
        /// 总价
        /// </summary>
        public decimal m_decTotalPrice = 0;
        /// <summary>
        /// 发票号码
        /// </summary>
        public string m_strBILLNO = string.Empty;
        /// <summary>
        /// 作废标志
        /// </summary>
        public string m_strZfbz = string.Empty;
        /// <summary>
        /// 检验标本类名称
        /// </summary>
        public string m_strCHECKSAMNAME = string.Empty;
        /// <summary>
        /// 检查方法名称
        /// </summary>
        public string m_strCHECKMETHODNAME = string.Empty;
        /// <summary>
        /// 检查部位
        /// </summary>
        public string m_strCHECKPOSITION = string.Empty;
        /// <summary>
        /// 处方说明
        /// </summary>
        public string m_strEXPLANATION = string.Empty;
        /// <summary>
        /// 剂型标志代码:01 口服 02 注射 03 局部用药 99 其他 长度2不能为空
        /// </summary>
        public string m_strJXBZDM = "99";

        #region 个人详细信息
        /// <summary>
        /// 门诊号
        /// </summary>
        public string m_strCLINICNO = string.Empty;
        /// <summary>
        /// 作废标记
        /// </summary>
        public int m_intFlag;

        /// <summary>
        /// 性别
        /// </summary>
        public string m_strSEX = string.Empty;
        /// <summary>
        /// 民族
        /// </summary>
        public string m_strETHNICGROUP = string.Empty;
        /// <summary>
        /// 家庭地址
        /// </summary>
        public string m_strADDRESS = string.Empty;
        /// <summary>
        /// 工作单位
        /// </summary>
        public string m_strJOBTITLE = string.Empty;
        /// <summary>
        /// 联系电话
        /// </summary>
        public string m_strPHONENUMBERHOME = string.Empty;
        /// <summary>
        /// 联系人
        /// </summary>
        public string m_strCONTACTPERSON = string.Empty;
        /// <summary>
        /// 国籍
        /// </summary>
        public string m_strNATIONALITY = string.Empty;
        /// <summary>
        /// 婚姻状况
        /// </summary>
        public int m_intMARITALSTATUS = 0;
        /// <summary>
        /// 出生日期
        /// </summary>
        public string m_strBIRTHDAY = string.Empty;
        /// <summary>
        /// 身份证号
        /// </summary>
        public string m_strIDNUMBERS = string.Empty;
        /// <summary>
        /// 社保卡号
        /// </summary>
        public string m_strSSID = string.Empty;
        #endregion
    }
    #endregion

    #region 收费标准信息VO
    /// <summary>
    /// 收费标准信息VO
    /// </summary>
    [Serializable]
    public class clsChargeStandard_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// 机构代码
        /// </summary>
        public string m_strORGANCODE = string.Empty;
        /// <summary>
        /// 市统一代码
        /// </summary>
        public string m_strITEMID = string.Empty;
        /// <summary>
        /// 收费项目编码
        /// </summary>
        public string m_strBILLCODE = string.Empty;
        /// <summary>
        /// 项目英文名
        /// </summary>
        public string m_strBILLENNAME = string.Empty;
        /// <summary>
        /// 收费项目名称
        /// </summary>
        public string m_strBILLNAME = string.Empty;
        /// <summary>
        /// 助记码（拼音码）
        /// </summary>
        public string m_strMNEMOTECHNICS = string.Empty;
        /// <summary>
        /// 标准价格
        /// </summary>
        public decimal m_decUNITPRICE = 0;
        /// <summary>
        /// 采集日期
        /// </summary>
        public DateTime m_datCOLLECTDATE = DateTime.Now;
        /// <summary>
        /// 规格
        /// </summary>
        public string m_strSPEC = string.Empty;
        /// <summary>
        /// 单位
        /// </summary>
        public string m_strUNIT = string.Empty;
        /// <summary>
        /// 剂型
        /// </summary>
        public string m_strREAGENT = string.Empty;
        /// <summary>
        /// 药性
        /// </summary>
        public string m_strMEDSPEC = string.Empty;
        /// <summary>
        /// 收费项目种类
        /// </summary>
        public string m_strBILLKIND = string.Empty;
        ///// <summary>
        ///// 分类标志
        ///// </summary>
        //public string m_strFLBZ = string.Empty;
        /// <summary>
        /// 剂型标志代码:01 口服 02 注射 03 局部用药 99 其他 长度2不能为空
        /// </summary>
        public string m_strJXBZDM = "99";
        /// <summary>
        /// 是否停用
        /// </summary>
        public string m_strISDISABLE = string.Empty;

    }
    #endregion

    #region 药品信息VO
    /// <summary>
    /// 药品信息VO
    /// </summary>
    [Serializable]
    public class clsDrugInfo_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// 药品编码
        /// </summary>
        public string m_strDrugID = string.Empty;
        /// <summary>
        /// 通用名
        /// </summary>
        public string m_strGENERICNAME = string.Empty;
        /// <summary>
        /// 商品名
        /// </summary>
        public string m_strTRADENAME = string.Empty;
        /// <summary>
        /// 剂型
        /// </summary>
        public string m_strFORMULA = string.Empty;
        /// <summary>
        /// 规格
        /// </summary>
        public string m_strSPEC = string.Empty;
        /// <summary>
        /// 包装规格
        /// </summary>
        public string m_strPACKINGSPEC = string.Empty;
        /// <summary>
        /// 单位
        /// </summary>
        public string m_strUNIT = string.Empty;
        /// <summary>
        /// 批准文号
        /// </summary>
        public string m_strAPPROVEDNO = string.Empty;
        /// <summary>
        /// 批号
        /// </summary>
        public string m_strBATCHNO = string.Empty;
        /// <summary>
        /// 统计日期
        /// </summary>
        public string m_strPURCHASEDATE = string.Empty;
        /// <summary>
        /// 当日使用数量
        /// </summary>
        public int m_intUSEAMOUNT;
        /// <summary>
        /// 当日库存数量
        /// </summary>
        public int m_intSTOREAMOUNT;
        /// <summary>
        /// 药性
        /// </summary>
        public string m_strMEDSPEC = string.Empty;
    }
    #endregion

    #region 入库信息
    /// <summary>
    /// 入库信息
    /// </summary>
    [Serializable]
    public class clsInStorageInfo_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// 医院机构代码
        /// </summary>
        public string m_strORGANCODE = string.Empty;
        /// <summary>
        /// 流水号
        /// </summary>
        public string m_strWAREHOUSING_SEQ = string.Empty;
        /// <summary>
        /// 药库号
        /// </summary>
        public string m_strDRUGSTOREID = string.Empty;
        /// <summary>
        /// 入库单号
        /// </summary>
        public string m_strWAREHOUSING_NUMBER = string.Empty;
        /// <summary>
        /// 全市统一码
        /// </summary>
        public string m_strITEMID = string.Empty;
        /// <summary>
        /// 项目分类
        /// </summary>
        public string m_strITEMKIND = string.Empty;
        /// <summary>
        /// 药品代码
        /// </summary>
        public string m_strH_DRUGID = string.Empty;
        /// <summary>
        /// 药品名称
        /// </summary>
        public string m_strGENERICNAME = string.Empty;
        /// <summary>
        /// 药品规格
        /// </summary>
        public string m_strSPEC = string.Empty;
        /// <summary>
        /// 药品剂型
        /// </summary>
        public string m_strFORMULA = string.Empty;
        /// <summary>
        /// 入库数量
        /// </summary>
        public decimal m_dblINPUT_AMOUNT = 0;
        /// <summary>
        /// 买入单价
        /// </summary>
        public decimal m_dblBUY_PRICE = 0;
        /// <summary>
        /// 零售单价
        /// </summary>
        public decimal m_dblRETAIL_PRICE = 0;
        /// <summary>
        /// 发票号
        /// </summary>
        public string m_strINVOICE_NO = string.Empty;
        /// <summary>
        /// 发票日期
        /// </summary>
        public DateTime m_dtmINVOICE_DATE = DateTime.Now;
        /// <summary>
        /// 生产产家
        /// </summary>
        public string m_strMANUFACTURER = string.Empty;
        /// <summary>
        /// 供应商
        /// </summary>
        public string m_strSUPPLY = string.Empty;
        /// <summary>
        /// 有效期
        /// </summary>
        public DateTime m_dtmEFFECTIVE_DATE = DateTime.Now;
        /// <summary>
        /// 批号
        /// </summary>
        public string m_strBATCHNO = string.Empty;
        /// <summary>
        /// 操作标志 1：正常入库2：退货9：其他
        /// </summary>
        public string m_strFLAG = string.Empty;
        /// <summary>
        /// 批准文号
        /// </summary>
        public string m_strAPPROVEDNO = string.Empty;
        /// <summary>
        /// 入库时间
        /// </summary>
        public DateTime m_dtmINPUT_DATE = DateTime.Now;
        /// <summary>
        /// 上传日期
        /// </summary>
        public DateTime m_dtmUPLOAD_DATE = DateTime.Now;
    }
    #endregion

    #region 出库信息
    /// <summary>
    /// 出库信息
    /// </summary>
    [Serializable]
    public class clsOutStorageInfo_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// 医院机构代码
        /// </summary>
        public string m_strORGANCODE = string.Empty;
        /// <summary>
        /// 流水号
        /// </summary>
        public string m_strOPERATOR_SEQ = string.Empty;
        /// <summary>
        /// 药库编号
        /// </summary>
        public string m_strDRUGSTOREID = string.Empty;
        /// <summary>
        /// 出库单号
        /// </summary>
        public string m_strSHIPPING_NO = string.Empty;
        /// <summary>
        /// 全市统一码
        /// </summary>
        public string m_strITEMID = string.Empty;
        /// <summary>
        /// 项目分类
        /// </summary>
        public string m_strITEMKIND = string.Empty;
        /// <summary>
        /// 药品代码
        /// </summary>
        public string m_strH_DRUGID = string.Empty;
        /// <summary>
        /// 药品名称
        /// </summary>
        public string m_strGENERICNAME = string.Empty;
        /// <summary>
        /// 药品规格
        /// </summary>
        public string m_strSPEC = string.Empty;
        /// <summary>
        /// 药品剂型
        /// </summary>
        public string m_strFORMULA = string.Empty;
        /// <summary>
        /// 出库数量
        /// </summary>
        public decimal m_dblOUTPUT_AMOUNT = 0;
        /// <summary>
        /// 买入单价
        /// </summary>
        public decimal m_dblBUY_PRICE = 0;
        /// <summary>
        /// 零售单价
        /// </summary>
        public decimal m_dblRETAIL_PRICE = 0;
        /// <summary>
        /// 批号
        /// </summary>
        public string m_strBATCHNO = string.Empty;
        /// <summary>
        /// 生产产家
        /// </summary>
        public string m_strMANUFACTURER = string.Empty;
        /// <summary>
        /// 供应商
        /// </summary>
        public string m_strSUPPLY = string.Empty;
        /// <summary>
        /// 有效期
        /// </summary>
        public DateTime m_dtmEFFECTIVE_DATE = DateTime.Now;
        /// <summary>
        /// 入库单号
        /// </summary>
        public string m_strWAREHOUSING_NUMBER = string.Empty;
        /// <summary>
        /// 出库日期
        /// </summary>
        public DateTime m_dtmSHIPPING_DATE = DateTime.Now;
        /// <summary>
        /// 操作标志 1：正常出库2：出库作废9：其他
        /// </summary>
        public string m_strFLAG = string.Empty;
        /// <summary>
        /// 上传日期
        /// </summary>
        public DateTime m_dtmUPLOAD_DATE = DateTime.Now;
    }
    #endregion

    #region 库存信息
    /// <summary>
    /// 库存信息
    /// </summary>
    [Serializable]
    public class clsStorageInfo_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// 医院机构代码
        /// </summary>
        public string m_strORGANCODE = string.Empty;
        /// <summary>
        /// 库存流水号
        /// </summary>
        public string m_strMEDINF_SEQ = string.Empty;
        /// <summary>
        /// 市统一代码
        /// </summary>
        public string m_strITEMID = string.Empty;
        /// <summary>
        /// 药品编码
        /// </summary>
        public string m_strH_DRUGID = string.Empty;
        /// <summary>
        /// 药库编码
        /// </summary>
        public string m_strDRUGSTOREID = string.Empty;
        /// <summary>
        /// 项目分类
        /// </summary>
        public string m_strITEMKIND = string.Empty;
        /// <summary>
        /// 入库单号
        /// </summary>
        public string m_strWAREHOUSING_NUMBER = string.Empty;
        /// <summary>
        /// 药品名称(一般指药品通用名)
        /// </summary>
        public string m_strGENERICNAME = string.Empty;
        /// <summary>
        /// 药品别名(一般指商品名或其它名称）
        /// </summary>
        public string m_strTRADENAME = string.Empty;
        /// <summary>
        /// 药品剂型
        /// </summary>
        public string m_strFORMULA = string.Empty;
        /// <summary>
        /// 药品规格
        /// </summary>
        public string m_strSPEC = string.Empty;
        /// <summary>
        /// 包装单位
        /// </summary>
        public string m_strUNIT = string.Empty;
        /// <summary>
        /// 批准文号
        /// </summary>
        public string m_strAPPROVEDNO = string.Empty;
        /// <summary>
        /// 批号
        /// </summary>
        public string m_strBATCHNO = string.Empty;
        /// <summary>
        /// 药品库存
        /// </summary>
        public decimal m_dblSTOREAMOUNT = 0;
        /// <summary>
        /// 药理分类代码
        /// </summary>
        public string m_strMEDSPECCODE = string.Empty;
        /// <summary>
        /// 药理分类
        /// </summary>
        public string m_strMEDSPEC = string.Empty;
        /// <summary>
        /// 生产厂家
        /// </summary>
        public string m_strMANUFACTURER = string.Empty;
        /// <summary>
        /// 药品供货商
        /// </summary>
        public string m_strSUPPLY = string.Empty;
        /// <summary>
        /// 药品入库单价
        /// </summary>
        public decimal m_dblINPUT_PRICE = 0;
        /// <summary>
        /// 药品零售单价
        /// </summary>
        public decimal m_dblRETAIL_PRICE = 0;
        /// <summary>
        /// 药品入库日期
        /// </summary>
        public DateTime m_dtmINPUT_DATE = DateTime.Now;
        /// <summary>
        /// 药品有效日期
        /// </summary>
        public DateTime m_dtmEFFECTIVE_DATE = DateTime.MinValue;
        /// <summary>
        /// 上传日期
        /// </summary>
        public DateTime m_dtmUPLOAD_DATE = DateTime.Now;
    }
    #endregion

    #region 市统一项目表
    /// <summary>
    /// 市统一项目表
    /// </summary>
    [Serializable]
    public class clsHEALTH_ITEAM_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// 流水号
        /// </summary>
        public string m_strID = string.Empty;
        /// <summary>
        /// 项目代码
        /// </summary>
        public string m_strITEMCODE = string.Empty;
        /// <summary>
        /// 项目名称
        /// </summary>
        public string m_strITEMNAME = string.Empty;
        /// <summary>
        /// 化学名
        /// </summary>
        public string m_strCHEMISTRYNAME = string.Empty;
        /// <summary>
        /// 商品名
        /// </summary>
        public string m_strNAME = string.Empty;
        /// <summary>
        /// 别名
        /// </summary>
        public string m_strUSED_NAME = string.Empty;
        /// <summary>
        /// 项目英文
        /// </summary>
        public string m_strITEMENNAME = string.Empty;
        /// <summary>
        /// 助记码1（拼音）
        /// </summary>
        public string m_strMNEMOTECHNICS1 = string.Empty;
        /// <summary>
        /// 助记码2（五笔）
        /// </summary>
        public string m_strMNEMOTECHNICS2 = string.Empty;
        /// <summary>
        /// 规格
        /// </summary>
        public string m_strITEMSPEC = string.Empty;
        /// <summary>
        /// 包装规格
        /// </summary>
        public string m_strPACKAGSPEC = string.Empty;
        /// <summary>
        /// 计量单位
        /// </summary>
        public string m_strMEASURE_UNIT = string.Empty;
        /// <summary>
        /// 药理分类代码
        /// </summary>
        public string m_strMEDSPEC = string.Empty;
        /// <summary>
        /// 剂型分类代码
        /// </summary>
        public string m_strFORMULA = string.Empty;
        /// <summary>
        /// 项目分类代码
        /// </summary>
        public string m_strITEMKIND = string.Empty;
        /// <summary>
        /// 国家基本用药
        /// </summary>
        public string m_strMEDICINEBASE = string.Empty;
        /// <summary>
        /// 采购价格
        /// </summary>
        public string m_strBUY_PRICE = string.Empty;
        /// <summary>
        /// 零售限价
        /// </summary>
        public string m_strRETAIL_PRICE = string.Empty;
        /// <summary>
        /// 医保项目分类
        /// </summary>
        public string m_strMI_SORT = string.Empty;
        /// <summary>
        /// 医保编号
        /// </summary>
        public string m_strMI_CODE = string.Empty;
        /// <summary>
        /// 药品特殊管理标志代码
        /// </summary>
        public string m_strSM_MARK = string.Empty;
        /// <summary>
        /// 产品ID
        /// </summary>
        public string m_strPRODUCTID = string.Empty;
        /// <summary>
        /// 自费比例
        /// </summary>
        public int m_intESELFPAY = 1;
        /// <summary>
        /// 纯自费标志
        /// </summary>
        public string m_strESELFPAY_FLAG = string.Empty;
        /// <summary>
        /// 国家代码
        /// </summary>
        public string m_strCOUNTRYID = string.Empty;
        /// <summary>
        /// 省代码
        /// </summary>
        public string m_strAREAID = string.Empty;
        /// <summary>
        /// 系统匹配名
        /// </summary>
        public string m_strMACTHNAME = string.Empty;
        /// <summary>
        /// 招标剂型
        /// </summary>
        public string m_strBIDFORMULA = string.Empty;
        /// <summary>
        /// DDD单位
        /// </summary>
        public string m_strDDDUNIT = string.Empty;
        /// <summary>
        /// 单剂量
        /// </summary>
        public decimal m_strSINGLEDOSE = 0;
        /// <summary>
        /// DDD值
        /// </summary>
        public decimal m_strDDDVALUE = 0;
        /// <summary>
        /// 抗菌药分类
        /// </summary>
        public string m_strANTIB_SUBSIDIARY = string.Empty;
    }
    #endregion

    #region 项目对照
    /// <summary>
    /// 项目对照
    /// </summary>
    [Serializable]
    public class clsItemControl_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// 流水号
        /// </summary>
        public string HOSP_ITEMCENTERID = string.Empty;
        /// <summary>
        /// 医院机构编码
        /// </summary>
        public string ORGANCODE = string.Empty;
        /// <summary>
        /// 全市统一编码
        /// </summary>
        public string ITEMID = string.Empty;
        /// <summary>
        /// 全市统一名称
        /// </summary>
        public string ITEMNAME = string.Empty;
        /// <summary>
        /// 全市统一规格
        /// </summary>
        public string ITEMSPEC = string.Empty;
        /// <summary>
        /// 全市统一包装规格
        /// </summary>
        public string PACKAGSPEC = string.Empty;
        /// <summary>
        /// 医院编码
        /// </summary>
        public string H_ITEMCODE = string.Empty;
        /// <summary>
        /// 医院名称
        /// </summary>
        public string H_ITEMNAME = string.Empty;
        /// <summary>
        /// 医院规格
        /// </summary>
        public string H_ITEMSPEC = string.Empty;
    }
    #endregion
}
