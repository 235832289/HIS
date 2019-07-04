using System;
using System.Collections.Generic;
using System.Text;

namespace com.digitalwave.iCare.ValueObject
{
    #region 住院病人信息VO
    /// <summary>
    /// 住院病人信息VO
    /// </summary>
    [Serializable]
    public class clsBihPatient_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// 入院登记ID
        /// </summary>
        public string RegisterID = "";
        /// <summary>
        /// 病人ID
        /// </summary>
        public string PatientID = "";
        /// <summary>
        /// 诊疗卡号
        /// </summary>
        public string CardNO = "";
        /// <summary>
        /// 住院号
        /// </summary>
        public string Zyh = "";
        /// <summary>
        /// 住院次数
        /// </summary>
        public int Zycs = 0;
        /// <summary>
        /// 结算身份ID
        /// </summary>
        public string PayTypeID = "";
        /// <summary>
        /// 结算身份对应ID号码
        /// </summary>
        public string IdNo = "";
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name = "";
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex = "";
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdCard = "";
        /// <summary>
        /// 年龄
        /// </summary>
        public string Age = "";
        /// <summary>
        /// 费别
        /// </summary>
        public string Fee = "";
        /// <summary>
        /// 入院类型 1 普通入院 2 留观入院
        /// </summary>
        public string InType = "";
        /// <summary>
        /// 入院时间
        /// </summary>
        public string InHospitalDate = "";
        /// <summary>
        /// 当前病区ID
        /// </summary>
        public string AreaID = "";
        /// <summary>
        /// 当前病区名称
        /// </summary>
        public string AreaName = "";
        /// <summary>
        /// 病床ID
        /// </summary>
        public string BedID = "";
        /// <summary>
        /// 病床号
        /// </summary>
        public string BedNO = "";
        /// <summary>
        /// 出院时间
        /// </summary>
        public string OutHospitalDate = "";
        /// <summary>
        /// 住院天数
        /// </summary>
        public int Days = 0;
        /// <summary>
        /// 可用预交金金额
        /// </summary>
        public decimal PrepayMoney = 0;
        /// <summary>
        /// 结余款
        /// </summary>
        public decimal BalanceMoney = 0;
        /// <summary>
        /// 在院状态  0 下床 1 在床 2 预出院 3 实际出院 4 请假 8 出院结算 9 预交款
        /// </summary>
        public int Status = 0;
        /// <summary>
        /// 费用状态 0 新 1 待清 2 中途结算 3 出院结算 4 呆帐结算 5 出院结帐
        /// </summary>
        public int FeeStatus = 0;
        /// <summary>
        /// 未结天数
        /// </summary>
        public int NoChargeDays = 0;
        /// <summary>
        /// 总费用
        /// </summary>
        public decimal TotalFee = 0;
        /// <summary>
        /// 待结费用
        /// </summary>
        public decimal WaitChargeFee = 0;
        /// <summary>
        /// 直接交费费用
        /// </summary>
        public decimal DirectorFee = 0;
        /// <summary>
        /// 已清费用
        /// </summary>
        public decimal CompleteClearFee = 0;
        /// <summary>
        /// 待清费用
        /// </summary>
        public decimal WaitClearFee = 0;
        /// <summary>
        /// 诊断
        /// </summary>
        public string Diagnose = "";
        /// <summary>
        /// 清帐日期
        /// </summary>
        public string ClearFeeDate = "";
        /// <summary>
        /// 特注信息
        /// </summary>
        public string SpecialInfo = "";
        /// <summary>
        /// 备注
        /// </summary>
        public string Note = "";
        /// <summary>
        /// 医保统筹费用
        /// </summary>
        public decimal YbTotalFee = 0;
        /// <summary>
        /// 医保年度剩余费用
        /// </summary>
        public decimal YbLeaveFee = 0;
        /// <summary>
        /// 医保待清费用
        /// </summary>
        public decimal YbWaitClearFee = 0;
        /// <summary>
        /// 医保自付比例
        /// </summary>
        public decimal YbSbScale = 100;
        /// <summary>
        /// 费用下限
        /// </summary>
        public decimal LimtRate = 0;
        /// <summary>
        /// 特注时是否控费 0 不控制 1 控制
        /// </summary>
        public int SpecChargeCtrl = 0;
        /// <summary>
        /// 主治医生ID
        /// </summary>
        public string DoctorID = "";
        /// <summary>
        /// 主治医生姓名
        /// </summary>
        public string DoctorName = "";
        /// <summary>
        /// 主治医生所属工作组ID
        /// </summary>
        public string DoctorGroupID = "";
        /// <summary>
        /// (年度)医保报销总金额(剩余)
        /// </summary>
        public decimal InsuredTotalMoney = 0;
        /// <summary>
        /// 医保住院次数
        /// </summary>
        public int InsuredZycs = 0;
        /// <summary>
        /// 预交金金额(已呆帐结算)
        /// </summary>
        public decimal PrepayMoneyBadCharge = 0;
        /// <summary>
        /// 佛二要求，如果是未满一个月，此时在医嘱打印的时候需改变年龄字段
        /// </summary>
        public DateTime m_dtmBirthDay;
    }
    #endregion

    #region 预交款VO
    /// <summary>
    /// 预交款VO
    /// </summary>
    [Serializable]
    public class clsBihPrePay_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// 流水号
        /// </summary>
        public string strPrePayID = "";
        /// <summary>
        /// 病人ID
        /// </summary>
        public string strPatientID = "";
        /// <summary>
        /// 住院登记id	{=住院登记.id}
        /// </summary>
        public string strRegisterID = "";
        /// <summary>
        /// 班别	{1=日班;2=夜班}
        /// </summary>
        public int intLiner = 0;
        /// <summary>
        /// 交费类型{1=一般;2=退费;3=恢复}
        /// </summary>
        public int intPayType = 0;
        /// <summary>
        /// 币种{1=现金;2=支票;3=信用卡;4=外币}
        /// </summary>
        public int intCuyCate = 0;
        /// <summary>
        /// 金额
        /// </summary>
        public decimal decMoney = 0;
        /// <summary>
        /// 预交单号 发票号
        /// </summary>
        public string strPrePayInv = "";
        /// <summary>
        /// 病区id	{=部门.id}
        /// </summary>
        public string strAreaID = "";
        /// <summary>
        /// 备注
        /// </summary>
        public string strDes = "";
        /// <summary>
        /// 录入人id	{=雇员.id}
        /// </summary>
        public string strCreatorID = "";
        /// <summary>
        /// 录入日期
        /// </summary>
        public string strCreateDate = "";
        /// <summary>
        /// 修改人id	{=雇员.id}
        /// </summary>
        public string strDeactID = "";
        /// <summary>
        /// 修改日期
        /// </summary>
        public string strDeactivateDate = "";
        /// <summary>
        /// 可用状态{1/0}
        /// </summary>
        public int intStatus = 0;
        /// <summary>
        /// 是否已清{1/0}
        /// </summary>
        public int intIsClear = 0;
        /// <summary>
        /// 发票印刷号
        /// </summary>
        public string strPressNo = "";
        /// <summary>
        /// 预收方式 0 正常 1 手工补预交
        /// </summary>
        public int intUpType = 0;
        /// <summary>
        /// 病人姓名
        /// </summary>
        public string strPatientName = "";
        /// <summary>
        /// 病区名称
        /// </summary>
        public string strAreaName = "";
        /// <summary>
        /// 结账状态 0-未结账 1-已结帐
        /// </summary>
        public int intBalanceFlag = 0;
        /// <summary>
        /// 结账人
        /// </summary>
        public string strBalanceEmp = "";
        /// <summary>
        /// 结账时间
        /// </summary>
        public string strBalanceDate = "";
        /// <summary>
        /// 结帐流水号，关联T_OPR_BIH_PREPAYBALANCE
        /// </summary>
        public string strBalanceID = "";
    }
    #endregion

    #region 期帐VO
    /// <summary>
    /// 期帐VO
    /// </summary>
    [Serializable]
    public class clsBihDayAccounts_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// 期帐流水号
        /// </summary>
        public string AccountsID = "";
        /// <summary>
        /// 病人ID
        /// </summary>
        public string PatientID = "";
        /// <summary>
        /// 入院登记流水号
        /// </summary>
        public string RegisterID = "";
        /// <summary>
        /// 期数
        /// </summary>
        public int OrderNO = 0;
        /// <summary>
        /// 本期合计金额
        /// </summary>
        public decimal TotalSum = 0;
        /// <summary>
        /// 本期自付金额
        /// </summary>
        public decimal SbSum = 0;
        /// <summary>
        /// 清账自付金额
        /// </summary>
        public decimal ClearSbSum = 0;
        /// <summary>
        /// 本期记帐金额
        /// </summary>
        public decimal AcctSum = 0;
        /// <summary>
        /// 清帐记帐金额
        /// </summary>
        public decimal ClearAcctSum = 0;
        /// <summary>
        /// 清帐人ID
        /// </summary>
        public string ChargeEmp = "";
        /// <summary>
        /// 核算病区(开单科室)
        /// </summary>
        public string AreaID = "";
        /// <summary>
        /// 备注信息
        /// </summary>
        public string Note = "";
        /// <summary>
        /// 生成期帐时病人所在病区ID
        /// </summary>
        public string CurrAreaID = "";
        /// <summary>
        /// 操作员ID
        /// </summary>
        public string OperID = "";
        /// <summary>
        /// 类型 0 滚费 1 结帐
        /// </summary>
        public string Type = "";
    }
    #endregion

    #region 住院结算VO
    /// <summary>
    /// 新住院结算VO
    /// </summary>
    [Serializable]
    public class clsBihCharge_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// 结算号(YYYYMMDDHHMMSSFFFFFF)
        /// </summary>
        public string ChargeNo = "";
        /// <summary>
        /// 入院登记ID
        /// </summary>
        public string RegisterID = "";
        /// <summary>
        /// 结算身份ID
        /// </summary>
        public string PayTypeID = "";
        /// <summary>
        /// 病人入院类型 1 住院 2 留观
        /// </summary>
        public string PatientType = "";
        /// <summary>
        /// 合计金额
        /// </summary>
        public decimal TotalSum = 0;
        /// <summary>
        /// 自付金额
        /// </summary>
        public decimal SbSum = 0;
        /// <summary>
        /// 记帐金额
        /// </summary>
        public decimal AcctSum = 0;
        /// <summary>
        /// 收费员ID
        /// </summary>
        public string OperEmp = "";
        /// <summary>
        /// 收费时间
        /// </summary>
        public string OperDate = "";
        /// <summary>
        /// 日结标志 0 未结 1 已结
        /// </summary>
        public int RecFlag = 0;
        /// <summary>
        /// 日结员ID
        /// </summary>
        public string RecEmp = "";
        /// <summary>
        /// 日结时间
        /// </summary>
        public string RecDate = "";
        /// <summary>
        /// 结算类别 1 中途结算 2 出院结算 3 呆帐结算 4 呆帐补交款结算
        /// </summary>
        public int Class = 0;
        /// <summary>
        /// 结算类型 1 收款 2 退款
        /// </summary>
        public int Type = 0;
        /// <summary>
        /// 结算状态 1 有效 2 取消
        /// </summary>
        public int Status = 0;
        /// <summary>
        /// 医保记帐单号
        /// </summary>
        public string BillNO = "";
        /// <summary>
        /// 病人编号ID
        /// </summary>
        public string PatientID = "";
        /// <summary>
        /// 病人当前病区ID
        /// </summary>
        public string CurrAreaID = "";
    }
    #endregion

    #region 住院结算分类VO
    /// <summary>
    /// 住院结算分类VO
    /// </summary>
    [Serializable]
    public class clsBihChargeCat_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// 结算号
        /// </summary>
        public string ChargeNo = "";
        /// <summary>
        /// 核算科室(执行科室)ID
        /// </summary>
        public string DeptID = "";
        /// <summary>
        /// 核算分类ID
        /// </summary>
        public string ItemCatID = "";
        /// <summary>
        /// 合计金额
        /// </summary>
        public decimal TotalSum = 0;
        /// <summary>
        /// 记帐金额
        /// </summary>
        public decimal AcctSum = 0;
    }
    #endregion

    #region 住院发票VO
    /// <summary>
    /// 住院发票VO
    /// </summary>
    [Serializable]
    public class clsBihInvoice_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// 发票号
        /// </summary>
        public string InvoiceNo = "";
        /// <summary>
        /// 发票日期
        /// </summary>
        public string InvDate = "";
        /// <summary>
        /// 合计金额
        /// </summary>
        public decimal TotalSum = 0;
        /// <summary>
        /// 自付金额
        /// </summary>
        public decimal SbSum = 0;
        /// <summary>
        /// 记帐金额
        /// </summary>
        public decimal AcctSum = 0;
        /// <summary>
        /// 状态 0-作废 1-有效 2-退票 3-恢复
        /// </summary>
        public int Status = -999;
        /// <summary>
        /// 审核人
        /// </summary>
        public string ConfirmEmp = "";
        /// <summary>
        /// 审核时间
        /// </summary>
        public string ConfirmDate = "";
        /// <summary>
        /// 是否分发票 0 否 1 是
        /// </summary>
        public int Split = 0;
    }
    #endregion

    #region 住院发票分类VO
    /// <summary>
    /// 住院发票分类VO
    /// </summary>
    [Serializable]
    public class clsBihInvoiceCat_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// 发票号
        /// </summary>
        public string InvoiceNo = "";
        /// <summary>
        /// 发票分类
        /// </summary>
        public string ItemCatID = "";
        /// <summary>
        /// 分类名称
        /// </summary>
        public string ItemCatName = "";
        /// <summary>
        /// 合计金额
        /// </summary>
        public decimal TotalSum = 0;
        /// <summary>
        /// 记帐金额
        /// </summary>
        public decimal AcctSum = 0;
    }
    #endregion

    #region 住院支付VO
    /// <summary>
    /// 住院支付VO
    /// </summary>
    [Serializable]
    public class clsBihPayment_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// 结算号
        /// </summary>
        public string ChargeNo = "";
        /// <summary>
        /// 支付方式 0 预交款 1 现金 2 支票 3 银行卡 4 其他
        /// </summary>
        public int PayType = -1;
        /// <summary>
        /// 银行卡类型代码
        /// </summary>
        public int PayCardType = -1;
        /// <summary>
        /// 银行卡卡号
        /// </summary>
        public string PayCardNo = "";
        /// <summary>
        /// 支付金额
        /// </summary>
        public decimal PaySum = 0;
        /// <summary>
        /// 找兑金额
        /// </summary>
        public decimal RefuSum = 0;
    }
    #endregion

    #region 住院一日清单VO
    /// <summary>
    /// 住院一日清单VO
    /// </summary>
    [Serializable]
    public class clsBihEveryDayBill_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// 入院登记ID
        /// </summary>
        public string RegisterID = "";
        /// <summary>
        /// 住院号
        /// </summary>
        public string Zyh = "";
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name = "";
        /// <summary>
        /// 当前病区名称
        /// </summary>
        public string AreaName = "";
        /// <summary>
        /// 病床号
        /// </summary>
        public string BedNO = "";
        /// <summary>
        /// 清单日期
        /// </summary>
        public string BillDate = "";
        /// <summary>
        /// 当天合计金额
        /// </summary>
        public string CurrDayTotal = "";
        /// <summary>
        /// 住院费用总合计金额
        /// </summary>
        public string AllTotal = "";
        /// <summary>
        /// 可用预交金
        /// </summary>
        public string PrePayMoney = "";
        /// <summary>
        /// 已清费用
        /// </summary>
        public string ClearTotal = "";
        /// <summary>
        /// 欠款费用
        /// </summary>
        public string ArrearageTotal = "";
        /// <summary>
        /// 记帐金额(一般为社保统筹金)
        /// </summary>
        public string AcctTotal = "";
    }
    #endregion

    #region 费用明细VO
    /// <summary>
    /// 费用明细VO
    /// </summary>
    [Serializable]
    public class clsBihPatientCharge_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// 病人费用明细流水号
        /// </summary>
        public string PchargeID = "";
        /// <summary>
        /// 病人ID
        /// </summary>
        public string PatientID = "";
        /// <summary>
        /// 住院登记id
        /// </summary>
        public string RegisterID = "";
        /// <summary>
        /// 生效日期
        /// </summary>
        public string ActiveDat = "";
        /// <summary>
        /// 医嘱单id
        /// </summary>
        public string OrderID = "";
        /// <summary>
        /// 医嘱执行类型{1=长嘱;2=临嘱;3=长嘱新开加;4=出院带药}
        /// </summary>
        public int OrderExecType = 0;
        /// <summary>
        /// 医嘱执行单id
        /// </summary>
        public string OrderExecID = "";
        /// <summary>
        /// 核算病区id
        /// </summary>
        public string ClacArea = "";
        /// <summary>
        /// 开单地点id
        /// </summary>
        public string CreateArea = "";
        /// <summary>
        /// 费用核算类别id
        /// </summary>
        public string CalcCateID = "";
        /// <summary>
        /// 费用发票类别id
        /// </summary>
        public string InvCateID = "";
        /// <summary>
        /// 收费项目id
        /// </summary>
        public string ChargeItemID = "";
        /// <summary>
        /// 收费项目名称
        /// </summary>
        public string ChargeItemName = "";
        /// <summary>
        /// 住院单位
        /// </summary>
        public string Unit = "";
        /// <summary>
        /// 住院单价
        /// </summary>
        public decimal UnitPrice = 0;
        /// <summary>
        /// 领量
        /// </summary>
        public decimal Amount = 0;
        /// <summary>
        /// 折扣比例(自付比例)
        /// </summary>
        public decimal Discount = 100;
        /// <summary>
        /// 是否自费项目
        /// </summary>
        public int Ismepay = 0;
        /// <summary>
        /// 备注
        /// </summary>
        public string Des = "";
        /// <summary>
        /// 录入类型{1=自动(医嘱);2=自动(日处理);3=补登(医嘱);4=补登(非医嘱)}
        /// </summary>
        public int CreateType = 0;
        /// <summary>
        /// 录入人	
        /// </summary>
        public string Creator = "";
        /// <summary>
        /// 录入时间
        /// </summary>
        public string CreateDat = "";
        /// <summary>
        /// 修改人
        /// </summary>
        public string Operator = "";
        /// <summary>
        /// 修改时间
        /// </summary>
        public string ModifyDat = "";
        /// <summary>
        /// 删除人
        /// </summary>
        public string Deactivator = "";
        /// <summary>
        /// 删除时间
        /// </summary>
        public string DeactivateDat = "";
        /// <summary>
        /// 有效状态{1=有效;0=无效;-1=历史}
        /// </summary>
        public int Status = 0;
        /// <summary>
        /// 费用状态{0=待确认;1=待结;2=待清;3=已清;4=直收}
        /// </summary>
        public int PStatus = 0;
        /// <summary>
        /// 清帐日期
        /// </summary>
        public string ChearAccountDat = "";
        /// <summary>
        /// 期帐id
        /// </summary>
        public string DayaccountID = "";
        /// <summary>
        /// 交费记录id
        /// </summary>
        public string PayMoneyID = "";
        /// <summary>
        /// 生效人
        /// </summary>
        public string Activator = "";
        /// <summary>
        /// 生效类型{1=其它;2=补记帐;3=确认记帐;4=确认收费;5=直接收费}
        /// </summary>
        public int ActivateType = 0;
        /// <summary>
        /// 是否贵重{1/0}
        /// </summary>
        public int IsRich = 0;
        /// <summary>
        /// 是否已确认(退款){仅当退费时有用,1/0}
        /// </summary>
        public int IsConfirmRefundment = 0;
        /// <summary>
        /// 退款确认人{仅当退费时有用}
        /// </summary>
        public string RefundmentChecker = "";
        /// <summary>
        /// 退款确认时间{仅当退费时有用}
        /// </summary>
        public string RefundmentDat = "";
        /// <summary>
        /// 
        /// </summary>
        public int BmStatus = 0;
        /// <summary>
        /// 下单时病人所在病区ID
        /// </summary>
        public string CurAreaID = "";
        /// <summary>
        /// 下单时病人所在病床ID
        /// </summary>
        public string CurBedID = "";
        /// <summary>
        /// 主管医生ID
        /// </summary>
        public string DoctorID = "";
        /// <summary>
        /// 主管医生名称
        /// </summary>
        public string Doctor = "";
        /// <summary>
        /// 主管医生所在工作组ID
        /// </summary>
        public string DoctorGroupID = "";
        /// <summary>
        /// 是否需要费用审核 0-否 1-是
        /// </summary>
        public int NeedConfirm = 0;
        /// <summary>
        /// 审核人ID
        /// </summary>
        public string ConfirmerID = "";
        /// <summary>
        /// 审核人名称
        /// </summary>
        public string Confirmer = "";
        /// <summary>
        /// 审核时间
        /// </summary>
        public string ConfirmDat = "";
        /// <summary>
        /// 医保信息
        /// </summary>
        public string INSURACEDESC_VCHR = "";
        /// <summary>
        /// 规格{=this.get诊疗项目.get收费项目.规格}
        /// </summary>
        public string SPEC_VCHR = "";
        /// <summary>
        /// 合计金额
        /// </summary>
        public decimal TotalMoney_dec = 0;
        /// <summary>
        /// 记帐金额
        /// </summary>
        public decimal AcctMoney_dec = 0;
        /// <summary>
        /// 新价表单项折扣比例(例如:检验超过8项)
        /// </summary>
        public decimal NEWDISCOUNT_DEC = 100;
        /// <summary>
        /// 是否病人护理项目(0-不是,1-是)
        /// </summary>
        public int PATIENTNURSE_INT = 0;
        /// <summary>
        /// 关联诊疗项目ID
        /// </summary>
        public string AttachOrderID = "";
        /// <summary>
        /// 主诊疗项目基数值
        /// </summary>
        public decimal AttachOrderBaseNum = 0;
        /// <summary>
        /// 摆药标志 0 不摆药 1 摆药
        /// </summary>
        public int PutMedicineFlag = 0;

        #region 附加的非表字段属性
        /// <summary>
        /// 补一次的领量
        /// </summary>
        public decimal m_decSINGLEAMOUNT_DEC = 0;
        /// <summary>
        /// 项目源ID。项目来源可以是药品、治疗项目、材料等，这里记录此项目在来源表中的唯一标志。
        /// </summary>
        public string m_strITEMSRCID_VCHR = "";
        /// <summary>
        /// 项目来源类型这里会根据来源表来确定值范围，内部使用。例如1－药品表，2－材料表等。
        /// </summary>
        public int m_intITEMSRCTYPE_INT = 0;
        /// <summary>
        /// 摆药明细表流水号(医嘱执行特殊用途)
        /// </summary>
        public string m_strPUTMEDREQID_CHR = "";
        /// <summary>
        /// 药房类型分类ID 1-西药 2-中药  3-材料 4-中西药
        /// </summary>
        public int m_intMEDICNETYPE_INT = 0;
        /// <summary>
        /// 摆药分类 0-非药品类 1-针剂类 2-口服类
        /// </summary>
        public int m_intPUTMEDTYPE_INT = 0;
        /// <summary>
        /// 剂量
        /// </summary>
        public decimal m_decDOSAGE_DEC = 0;
        /// <summary>
        /// 剂量单位
        /// </summary>
        public string m_strDOSAGEUNIT_CHR = "";

        #endregion
        /// <summary>
        /// 开单医生ID
        /// </summary>
        public string CHARGEDOCTORID_CHR = "";
        /// <summary>
        /// 开单医生名称
        /// </summary>
        public string CHARGEDOCTOR_VCHR = "";
        /// <summary>
        /// 开单医生所在专业组
        /// </summary>
        public string CHARGEDOCTORGROUPID_CHR = "";
    }
    #endregion

    #region 确认审核信息VO
    /// <summary>
    /// 确认审核信息VO
    /// </summary>
    [Serializable]
    public class clsBihConfirm_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// 审核人ID
        /// </summary>
        public string EmpId = "";
        /// <summary>
        /// 审核人工号
        /// </summary>
        public string EmpNo = "";
        /// <summary>
        /// 审核人姓名
        /// </summary>
        public string EmpName = "";
        /// <summary>
        /// 科室ID
        /// </summary>
        public string DeptId = "";
        /// <summary>
        /// 科室代码
        /// </summary>
        public string DeptNo = "";
        /// <summary>
        /// 科室名称
        /// </summary>
        public string DeptName = "";
    }
    #endregion

    #region 费用分类设置VO
    /// <summary>
    /// 费用分类设置VO
    /// </summary>
    [Serializable]
    public class clsBihChargeItemCat_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// 范围: 1 门诊核算 2 门诊发票 3 住院核算 4 住院发票
        /// </summary>
        public string Scope = "";
        /// <summary>
        /// 分类ID
        /// </summary>
        public string CatID = "";
        /// <summary>
        /// 分类名称
        /// </summary>
        public string CatName = "";
        /// <summary>
        /// 类型 0 普通型 1 计算型
        /// </summary>
        public string Type = "";
        /// <summary>
        /// 计算表达式
        /// </summary>
        public string CompExp = "";
        /// <summary>
        /// 显示控件名
        /// </summary>
        public string DispCtl = "";
        /// <summary>
        /// 打印控件名
        /// </summary>
        public string PrtClt = "";
        /// <summary>
        /// 状态 0 停用 1 启用
        /// </summary>
        public string Status = "";
    }
    #endregion

    #region 补记帐、直收费用(诊疗项目)VO
    /// <summary>
    /// 补记帐、直收费用(诊疗项目)VO
    /// </summary>
    [Serializable]
    public class clsBihOrderDic_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// 同t_opr_bih_patientcharge.orderid_chr
        /// </summary>
        public string OrderID = "";
        /// <summary>
        /// 类型 2 补记帐 5 直接收费
        /// </summary>
        public int Type = 1;
        /// <summary>
        /// 排序号
        /// </summary>
        public int OrderQue = 0;
        /// <summary>
        /// 诊疗项目ID
        /// </summary>
        public string OrderDicID = "";
        /// <summary>
        /// 诊疗项目名称
        /// </summary>
        public string OrderDicName = "";
        /// <summary>
        /// 规格
        /// </summary>
        public string Spec = "";
        /// <summary>
        /// 数量
        /// </summary>
        public decimal Qty = 0;
        /// <summary>
        /// 单价
        /// </summary>
        public decimal PriceMny = 0;
        /// <summary>
        /// 金额
        /// </summary>
        public decimal TotalMny = 0;
        /// <summary>
        /// 关联诊疗项目ID
        /// </summary>
        public string AttachOrderID = "";
        /// <summary>
        /// 主诊疗项目基数值
        /// </summary>
        public decimal AttachOrderBaseNum = 1;
        /// <summary>
        /// 自付金额基数
        /// </summary>
        public decimal SbBaseMny = 0;
    }
    #endregion

    #region 退款VO
    /// <summary>
    /// 退款VO
    /// </summary>
    [Serializable]
    public class clsBihRefCharge_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// 费用明细ID
        /// </summary>
        public string PChargeID = "";
        /// <summary>
        /// 退款数量
        /// </summary>
        public decimal RefAmount = 0;
        /// <summary>
        /// 单价
        /// </summary>
        public decimal RefPrice = 0;
    }
    #endregion

    #region 显示诊疗项目VO
    /// <summary>
    /// 显示诊疗项目VO
    /// </summary>
    [Serializable]
    public class clsParmDiagItem_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// 收费明细ID
        /// </summary>
        public string PchargeID = "";
        /// <summary>
        /// 诊疗项目ID
        /// </summary>
        public string DiagID = "";
        /// <summary>
        /// 诊疗项目名称
        /// </summary>
        public string DiagName = "";
        /// <summary>
        /// 执行ID
        /// </summary>
        public string ExecID = "";
    }
    #endregion

    #region 门诊默认加收项目VO
    /// <summary>
    /// 门诊默认加收项目VO
    /// </summary>
    [Serializable]
    public class clsOutPatientDefaultAddItem_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// 主键时间序列ID
        /// </summary>
        public string Sid = "";
        /// <summary>
        /// 身份(费别)ID
        /// </summary>
        public string PayTypeID = "";
        /// <summary>
        /// 收费项目ID
        /// </summary>
        public string ItemID = "";
        /// <summary>
        /// 数量
        /// </summary>
        public decimal Qty = 0;
        /// <summary>
        /// 挂号标志： 0 全部 1 已挂号 2 未挂号
        /// </summary>
        public int RegFlag = 0;
        /// <summary>
        /// 处方标志： 0 全部 1 正方 2 副方
        /// </summary>
        public int RecFlag = 0;
        /// <summary>
        /// 职称ID:  00 全部 ...
        /// </summary>
        public string DutyID = "";
        /// <summary>
        /// (每日)开始时间
        /// </summary>
        public string BeginTime = "";
        /// <summary>
        /// (每日)结束时间
        /// </summary>
        public string EndTime = "";
    }
    #endregion

    #region 通用查询日期VO类
    /// <summary>
    /// 通用查询日期VO类
    /// </summary>
    [Serializable]
    public class clsCommonQueryDate_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// 时间查询模式 0 不按时间查询 1 按入院日期 2 按出院日期 3 按入院日期+出院日期
        /// </summary>
        public int QueryType = 0;
        /// <summary>
        /// 入院开始日期
        /// </summary>
        public string BeginDate_In = "";
        /// <summary>
        /// 入院结束日期
        /// </summary>
        public string EndDate_In = "";
        /// <summary>
        /// 出院开始日期
        /// </summary>
        public string BeginDate_Out = "";
        /// <summary>
        /// 出院结束日期
        /// </summary>
        public string EndDate_Out = "";
    }
    #endregion

    #region 卫生信息共享主VO
    /// <summary>
    /// 卫生信息共享主VO
    /// </summary>
    [Serializable]
    public class clsHospRecordCS_Vo : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string m_strName = string.Empty;
        /// <summary>
        /// 性别
        /// </summary>
        public string m_strSex = string.Empty;
        /// <summary>
        /// 病人性质
        /// </summary>
        public string m_strKind = string.Empty;
        /// <summary>
        /// 民族
        /// </summary>
        public string m_strEthnicGroup = string.Empty;
        /// <summary>
        /// 住址
        /// </summary>
        public string m_strAddress = string.Empty;
        /// <summary>
        /// 工作单位
        /// </summary>
        public string m_strJobTitle = string.Empty;
        /// <summary>
        /// 联系电话
        /// </summary>
        public string m_strPhoneNum = string.Empty;
        /// <summary>
        /// 联系人
        /// </summary>
        public string m_strContactPerson = string.Empty;
        /// <summary>
        /// 民族
        /// </summary>
        public string m_strNationality = string.Empty;
        /// <summary>
        /// 婚姻
        /// </summary>
        public string m_strMaritalStatus = string.Empty;
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime m_dtmBirthDay = DateTime.Now;
        /// <summary>
        /// 身份证号
        /// </summary>
        public string m_strIDNumber = string.Empty;
        /// <summary>
        /// 诊疗卡号
        /// </summary>
        public string m_strSSID = string.Empty;
        /// <summary>
        /// 住院号
        /// </summary>
        public string m_strInHospNO = string.Empty;
        /// <summary>
        /// 住院次数
        /// </summary>
        public int m_intInHospCount = 1;
        /// <summary>
        /// 流水号
        /// </summary>
        public string m_strRegisterID = string.Empty;
        /// <summary>
        /// 门诊号
        /// </summary>
        public string m_strClinicID = string.Empty;
        /// <summary>
        /// 床号
        /// </summary>
        public string m_strBedNO = string.Empty;
        /// <summary>
        /// 入院科室Code
        /// </summary>
        public string m_strInDeptCode = string.Empty;
        /// <summary>
        /// 入院科室Name
        /// </summary>
        public string m_strInDeptName = string.Empty;
        /// <summary>
        /// 出院科室Code
        /// </summary>
        public string m_strOutDeptCode = string.Empty;
        /// <summary>
        /// 出院科室Name
        /// </summary>
        public string m_strOutDeptName = string.Empty;
        /// <summary>
        /// 主治医生ID
        /// </summary>
        public string m_strMainDoctorID = string.Empty;
        /// <summary>
        /// 主治医生Name
        /// </summary>
        public string m_strMainDoctorName = string.Empty;
        /// <summary>
        /// 主任医生ID
        /// </summary>
        public string m_strInHospDoctorID = string.Empty;
        /// <summary>
        /// 主任医生Name
        /// </summary>
        public string m_strInHospDoctorName = string.Empty;
        /// <summary>
        /// 入院日期
        /// </summary>
        public DateTime m_dtmInDate = DateTime.Now;
        /// <summary>
        /// 出院日期
        /// </summary>
        public DateTime m_dtmOutDate = DateTime.Now;
        /// <summary>
        /// 确诊日期
        /// </summary>
        public DateTime m_dtmConfirmDate = DateTime.Now;
        /// <summary>
        /// 住院天数
        /// </summary>
        public int m_intHospDay = 0;
        /// <summary>
        /// 入院诊断Code
        /// </summary>
        public string m_strInDiagnosCode = string.Empty;
        /// <summary>
        /// 入院诊断Name
        /// </summary>
        public string m_strInDiagnosName = string.Empty;
        /// <summary>
        /// 出院诊断Code
        /// </summary>
        public string m_strOutDiagnosCode = string.Empty;
        /// <summary>
        /// 出院诊断Name
        /// </summary>
        public string m_strOutDiagnosName = string.Empty;
        /// <summary>
        /// 症状
        /// </summary>
        public string m_strSymptom = string.Empty;
        /// <summary>
        /// 取消
        /// </summary>
        public int m_intCancel = 0;
        /// <summary>
        /// 转归情况
        /// </summary>
        public string m_strStatus = string.Empty;
        /// <summary>
        /// 入区时间
        /// </summary>
        public DateTime m_dtmInAreaTime = DateTime.Now;

        public string m_strBirthPlace = string.Empty;
    }

    /// <summary>
    /// 住院收费单
    /// </summary>
    [Serializable]
    public class clsHospBillCS_Vo : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// 流水号
        /// </summary>
        public string m_strRegisterID = string.Empty;
        /// <summary>
        /// 发票号
        /// </summary>
        public string m_strInvoNo = string.Empty;
        /// <summary>
        /// 总金额
        /// </summary>
        public decimal m_dclInvoTotolMoney = 0m;
        /// <summary>
        /// 自付金额
        /// </summary>
        public decimal m_dclInvoFSPMoney = 0m;
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime m_dtmBeginDate = DateTime.Now;
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime m_dtmEndDate = DateTime.Now;
        /// <summary>
        /// 发票时间
        /// </summary>
        public DateTime m_dtmBillDate = DateTime.Now;
        /// <summary>
        /// 费别
        /// </summary>
        public string m_strKind = string.Empty;
        /// <summary>
        /// 分类编码
        /// </summary>
        public string m_strFareCode = string.Empty;
        /// <summary>
        /// 分类名称
        /// </summary>
        public string m_strFareName = string.Empty;
        /// <summary>
        /// 数量
        /// </summary>
        public decimal m_intAmount = 0;
        /// <summary>
        /// 单价
        /// </summary>
        public decimal m_dclPrice = 0m;
        /// <summary>
        /// 总金额
        /// </summary>
        public decimal m_dclSubMoney = 0m;

        public string m_strSEQID = string.Empty;

        public string m_strInDeptID = string.Empty;
        public string m_strInDeptName = string.Empty;
        public string m_strDoctorName = string.Empty;
        public string m_strDoctorID = string.Empty;
        public string m_strFareKind = string.Empty;

        public string m_strOrderID = string.Empty;
        /// <summary>
        /// 市统一编码
        /// </summary>
        public string m_strITEMID = string.Empty;
        /// <summary>
        /// 医嘱执行时间
        /// </summary>
        public DateTime m_dtEXECUTEDATE= DateTime.Now;
        /// <summary>
        /// 开单科室代码
        /// </summary>
        public string m_strDEPCODE = string.Empty;
        /// <summary>
        /// 开单科室名称
        /// </summary>
        public string m_strDEPNAME = string.Empty;

    }

    /// <summary>
    /// 医嘱信息
    /// </summary>
    [Serializable]
    public class clsHospOrderCS_Vo : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// 医嘱序号
        /// </summary>
        public string m_strOrderNo = string.Empty;
        /// <summary>
        /// 住院序号
        /// </summary>
        public string m_strRegisterID = string.Empty;
        /// <summary>
        /// 医嘱子序号
        /// </summary> 
        public string m_strOrderSubNo = string.Empty;
        /// <summary>
        /// 医嘱开始生效时间
        /// </summary>
        public DateTime m_dtmStart = DateTime.Now;
        /// <summary>
        /// 长期医嘱标志
        /// </summary>
        public string m_strLongOrder = string.Empty;
        /// <summary>
        /// 医嘱类别
        /// </summary>
        public string m_strOrderClass = string.Empty;
        /// <summary>
        /// 医嘱状态
        /// </summary>
        public int m_intOrderStauts = 0;
        /// <summary>
        /// 医嘱正文
        /// </summary>
        public string m_strOrderText = string.Empty;
        /// <summary>
        /// 医嘱代码
        /// </summary>
        public string m_strOrderID = string.Empty;
        /// <summary>
        /// 起始日期及时间
        /// </summary>
        public DateTime m_dtmStartExec = DateTime.Now;
        /// <summary>
        /// 停止日期及时间
        /// </summary>
        public DateTime m_dtmStop = DateTime.Now;
        /// <summary>
        /// 持续时间
        /// </summary>
        public string m_strDuration = string.Empty;
        /// <summary>
        /// 持续时间单位
        /// </summary>
        public string m_strDuration_Units = string.Empty;
        /// <summary>
        /// 执行频率描述
        /// </summary>
        public string m_strFrequencyName = string.Empty;
        /// <summary>
        /// 频率次数
        /// </summary>
        public int m_strFreq_Counter = 0;
        /// <summary>
        /// 频率间隔
        /// </summary>
        public string m_strFreq_Interval = string.Empty;
        /// <summary>
        /// 频率间隔单位
        /// </summary>
        public string m_strFreq_Interval_Unit = string.Empty;
        /// <summary>
        /// 执行时间详细描述
        /// </summary>
        public string m_strFreq_Detail = string.Empty;
        /// <summary>
        /// 护士执行时间
        /// </summary>
        public string m_strPerform_Schedule = string.Empty;
        /// <summary>
        /// 执行结果
        /// </summary>
        public string m_strPerform_Resul = string.Empty;
        /// <summary>
        /// 开医嘱医生
        /// </summary>
        public string m_strCreateDoctor = string.Empty;
        /// <summary>
        /// 开医嘱科室
        /// </summary>
        public string m_strCreateDept = string.Empty;
        /// <summary>
        /// 停医嘱医生
        /// </summary>
        public string m_strStopDoctor = string.Empty;
        /// <summary>
        /// 停嘱医生名称
        /// </summary>
        public string m_strStopDoctorName = string.Empty;
        /// <summary>
        /// 开医嘱校对护士
        /// </summary>
        public string m_strConfirmNurser = string.Empty;
        /// <summary>
        /// 停医嘱校对护士
        /// </summary>
        public string m_strStopConfirmNurser = string.Empty;
        /// <summary>
        /// 下达医嘱日期及时间
        /// </summary>
        public DateTime m_dtmStartDT = DateTime.Now;
        /// <summary>
        /// 录入医嘱日期及时间
        /// </summary>
        public DateTime m_dtmRecordDT = DateTime.Now;
        /// <summary>
        /// 停医嘱录入日期及时间
        /// </summary>
        public DateTime m_dtmStopDT = DateTime.Now;
        /// <summary>
        /// 处理日期及时间
        /// </summary>
        public DateTime m_dtmProcessingDT = DateTime.Now;

        public string m_strCreatorID = "";
        public string m_strCreateDeptID = "";

        public string m_strChargeItemID = "";
        public string m_strChargeItemName = "";
        public string m_strSpec = "";
        public decimal m_dclAmount = 0;

        public decimal m_dclPrice = 0;
        public string m_strUnit = "";

        public DateTime m_dtmCreateDate = DateTime.MinValue;

        public int m_intGroupNo = 0;

        public string m_strINDeptID = "";
        public string m_strINDeptName = "";

        public string m_strType = "";
        public string m_strKind = "";
        public decimal m_dclDosageUse = 0m;
        public string m_strUseUnit = string.Empty;
        public string m_strUsageType = string.Empty;
        public string m_strFarekind = string.Empty;

        public string m_strCheckName = string.Empty;
        public string m_strCheckMethod = string.Empty;

        public string m_strCheckPark = string.Empty;
        public string m_strRemark = string.Empty;
        /// <summary>
        /// 市统一编码
        /// </summary>
        public string m_strITEMID = string.Empty;
        /// <summary>
        /// 天数
        /// </summary>
        public int m_intDays = 0;
        /// <summary>
        /// 剂型标志代码:01 口服 02 注射 03 局部用药 99 其他 长度2不能为空
        /// </summary>
        public string m_strJXBZDM = "99";
    }
    #endregion 

    //Start====qinhong====添加病案首页和手术VO（常平）==================
    #region 病案首页接口
    /// <summary>
    /// 病案首页接口
    /// </summary>
    [Serializable]
    public class clsFirstPageVO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// 机构代码;
        /// </summary>
        public string m_strjgdm = string.Empty;

        /// <summary>
        /// 流水号;
        /// </summary>
        public string m_strfid = string.Empty;

        /// <summary>
        /// 病案号;
        /// </summary>
        public string m_strfprn = string.Empty;

        /// <summary>
        /// 住院次数;
        /// </summary>
        public string m_strftimes = string.Empty;

        /// <summary>
        /// ICD版本;
        /// </summary>
        public string m_strficdversion = string.Empty;

        /// <summary>
        /// 住院流水号;
        /// </summary>
        public string m_strfzyid = string.Empty;

        /// <summary>
        /// 年龄;
        /// </summary>
        public string m_strfage = string.Empty;

        /// <summary>
        /// 病人姓名;
        /// </summary>
        public string m_strfname = string.Empty;

        /// <summary>
        /// 性别编号;
        /// </summary>
        public string m_strfsexbh = string.Empty;

        /// <summary>
        /// 性别;
        /// </summary>
        public string m_strfsex = string.Empty;

        /// <summary>
        /// 出生日期;
        /// </summary>
        public DateTime m_strfbirthday = DateTime.MinValue;

        /// <summary>
        /// 出生地;
        /// </summary>
        public string m_strfbirthplace = string.Empty;

        /// <summary>
        /// 身份证号;
        /// </summary>
        public string m_strfidcard = string.Empty;

        /// <summary>
        /// 国籍编号;
        /// </summary>
        public string m_strfcountrybh = string.Empty;

        /// <summary>
        /// 国籍;
        /// </summary>
        public string m_strfcountry = string.Empty;

        /// <summary>
        /// 民族编号;
        /// </summary>
        public string m_strfnationalitybh = string.Empty;

        /// <summary>
        /// 民族;
        /// </summary>
        public string m_strfnationality = string.Empty;

        /// <summary>
        /// 职业;
        /// </summary>
        public string m_strfjob = string.Empty;

        /// <summary>
        /// 婚姻状况编号;
        /// </summary>
        public string m_strfstatusbh = string.Empty;

        /// <summary>
        /// 婚姻状况;
        /// </summary>
        public string m_strfstatus = string.Empty;

        /// <summary>
        /// 单位名称;
        /// </summary>
        public string m_strfdwname = string.Empty;

        /// <summary>
        /// 单位地址;
        /// </summary>
        public string m_strfdwaddr = string.Empty;

        /// <summary>
        /// 单位电话;
        /// </summary>
        public string m_strfdwtele = string.Empty;

        /// <summary>
        /// 单位邮编;
        /// </summary>
        public string m_strfdwpost = string.Empty;

        /// <summary>
        /// 户口地址;
        /// </summary>
        public string m_strfhkaddr = string.Empty;

        /// <summary>
        /// 户口邮编;
        /// </summary>
        public string m_strfhkpost = string.Empty;

        /// <summary>
        /// 联系人;
        /// </summary>
        public string m_strflxname = string.Empty;

        /// <summary>
        /// 与病人关系;
        /// </summary>
        public string m_strfrelate = string.Empty;

        /// <summary>
        /// 联系人地址;
        /// </summary>
        public string m_strflxaddr = string.Empty;

        /// <summary>
        /// 联系人电话;
        /// </summary>
        public string m_strflxtele = string.Empty;

        /// <summary>
        /// 付款方式编号;
        /// </summary>
        public string m_strffbbh = string.Empty;

        /// <summary>
        /// 付款方式;
        /// </summary>
        public string m_strffb = string.Empty;

        /// <summary>
        /// 基本医疗保险卡号;
        /// </summary>
        public string m_strfascard1 = string.Empty;

        /// <summary>
        /// 其他医疗保险卡号;
        /// </summary>
        public string m_strfascard2 = string.Empty;

        /// <summary>
        /// 入院日期;
        /// </summary>
        public DateTime m_strfrydate = DateTime.MinValue;

        /// <summary>
        /// 入院时间;
        /// </summary>
        public string m_strfrytime = string.Empty;

        /// <summary>
        /// 入院统一科号;
        /// </summary>
        public string m_strfrytykh = string.Empty;

        /// <summary>
        /// 入院科别;
        /// </summary>
        public string m_strfrydept = string.Empty;

        /// <summary>
        /// 入院病室;
        /// </summary>
        public string m_strfrybs = string.Empty;

        /// <summary>
        /// 出院日期;
        /// </summary>
        public DateTime m_strfcydate = DateTime.MinValue;

        /// <summary>
        /// 出院时间;
        /// </summary>
        public string m_strfcytime = string.Empty;

        /// <summary>
        /// 出院统一科号;
        /// </summary>
        public string m_strfcytykh = string.Empty;

        /// <summary>
        /// 出院科别;
        /// </summary>
        public string m_strfcydept = string.Empty;

        /// <summary>
        /// 出院病室;
        /// </summary>
        public string m_strfcybs = string.Empty;

        /// <summary>
        /// 实际住院天数;
        /// </summary>
        public int m_Intfdays = 0;

        /// <summary>
        /// 门（急）诊诊断(ICD10或ICD9)编码;
        /// </summary>
        public string m_strfmzzdbh = string.Empty;

        /// <summary>
        /// 门（急）诊诊断(ICD10或ICD9)对应疾病名;
        /// </summary>
        public string m_strfmzzd0 = string.Empty;

        /// <summary>
        /// 门、急诊医生编号;
        /// </summary>
        public string m_strfmzdoctbh = string.Empty;

        /// <summary>
        /// 门、急诊医生;
        /// </summary>
        public string m_strfmzdoct = string.Empty;

        /// <summary>
        /// 入院时情况编号;
        /// </summary>
        public string m_strfryinfobh = string.Empty;

        /// <summary>
        /// 入院时情况;
        /// </summary>
        public string m_strfryinfo = string.Empty;

        /// <summary>
        /// 入院诊断(ICD10或ICD9)编码;
        /// </summary>
        public string m_strfryzdbh = string.Empty;

        /// <summary>
        /// 入院诊断(ICD10或ICD9)对应疾病名;
        /// </summary>
        public string m_strfryzd0 = string.Empty;

        /// <summary>
        /// 确诊日期;
        /// </summary>
        public DateTime m_strfqzdate = DateTime.MinValue;

        /// <summary>
        /// 病理诊断;
        /// </summary>
        public string m_strfphzd0 = string.Empty;

        /// <summary>
        /// 过敏药物;
        /// </summary>
        public string m_strfgmyw0 = string.Empty;

        /// <summary>
        /// HBsAg编号;
        /// </summary>
        public string m_strfhbsagbh = string.Empty;

        /// <summary>
        /// HBsAg;
        /// </summary>
        public string m_strfhbsag = string.Empty;

        /// <summary>
        /// HCV-Ab编号;
        /// </summary>
        public string m_strfhcvabbh = string.Empty;

        /// <summary>
        /// HCV-Ab;
        /// </summary>
        public string m_strfhcvab = string.Empty;

        /// <summary>
        /// HIV-AB编号;
        /// </summary>
        public string m_strfhivabbh = string.Empty;

        /// <summary>
        /// HIV-Ab;
        /// </summary>
        public string m_strfhivab = string.Empty;

        /// <summary>
        /// 门诊与出院诊断符合情况编号;
        /// </summary>
        public string m_strfmzcyaccobh = string.Empty;

        /// <summary>
        /// 门诊与出院诊断符合;
        /// </summary>
        public string m_strfmzcyacco = string.Empty;

        /// <summary>
        /// 入院与出院诊断符合情况编号;
        /// </summary>
        public string m_strfrycyaccobh = string.Empty;

        /// <summary>
        /// 入院与出院诊断符合;
        /// </summary>
        public string m_strfrycyacco = string.Empty;

        /// <summary>
        /// 临床与病理诊断符合情况编号;
        /// </summary>
        public string m_strflcblaccobh = string.Empty;

        /// <summary>
        /// 临床与病理诊断符合;
        /// </summary>
        public string m_strflcblacco = string.Empty;

        /// <summary>
        /// 放射与病理诊断符合情况编号;
        /// </summary>
        public string m_strffsblaccobh = string.Empty;

        /// <summary>
        /// 放射与病理诊断符合情况;
        /// </summary>
        public string m_strffsblacco = string.Empty;

        /// <summary>
        /// 手术符合编号;
        /// </summary>
        public string m_strfopaccobh = string.Empty;

        /// <summary>
        /// 手术符合;
        /// </summary>
        public string m_strfopacco = string.Empty;

        /// <summary>
        /// 抢救次数;
        /// </summary>
        public int m_Intfqjtimes = 0;

        /// <summary>
        /// 抢救成功次数;
        /// </summary>
        public int m_Intfqjsuctimes = 0;

        /// <summary>
        /// 科主任编号;
        /// </summary>
        public string m_strfkzrbh = string.Empty;

        /// <summary>
        /// 科主任;
        /// </summary>
        public string m_strfkzr = string.Empty;

        /// <summary>
        /// 主（副主）任医生编号;
        /// </summary>
        public string m_strfzrdoctbh = string.Empty;

        /// <summary>
        /// 主（副主）任医生;
        /// </summary>
        public string m_strfzrdoctor = string.Empty;

        /// <summary>
        /// 主治医生编号;
        /// </summary>
        public string m_strfzzdoctbh = string.Empty;

        /// <summary>
        /// 主治医生;
        /// </summary>
        public string m_strfzzdoct = string.Empty;

        /// <summary>
        /// 住院医生编号;
        /// </summary>
        public string m_strfzydoctbh = string.Empty;

        /// <summary>
        /// 住院医生;
        /// </summary>
        public string m_strfzydoct = string.Empty;

        /// <summary>
        /// 进修医师编号;
        /// </summary>
        public string m_strfjxdoctbh = string.Empty;

        /// <summary>
        /// 进修医师;
        /// </summary>
        public string m_strfjxdoct = string.Empty;

        /// <summary>
        /// 研究生实习医师编号;
        /// </summary>
        public string m_strfyjssxdoctbh = string.Empty;

        /// <summary>
        /// 研究生实习医师;
        /// </summary>
        public string m_strfyjssxdoct = string.Empty;

        /// <summary>
        /// 实习医生编号;
        /// </summary>
        public string m_strfsxdoctbh = string.Empty;

        /// <summary>
        /// 实习医生;
        /// </summary>
        public string m_strfsxdoct = string.Empty;

        /// <summary>
        /// 编码员编号;
        /// </summary>
        public string m_strfbmybh = string.Empty;

        /// <summary>
        /// 编码员;
        /// </summary>
        public string m_strfbmy = string.Empty;

        /// <summary>
        /// 病案整理者编号;
        /// </summary>
        public string m_strfzlrbh = string.Empty;

        /// <summary>
        /// 病案整理者;
        /// </summary>
        public string m_strfzlr = string.Empty;

        /// <summary>
        /// 病案质量编号;
        /// </summary>
        public string m_strfqualitybh = string.Empty;

        /// <summary>
        /// 病案质量;
        /// </summary>
        public string m_strfquality = string.Empty;

        /// <summary>
        /// 质控医师编号;
        /// </summary>
        public string m_strfzkdoctbh = string.Empty;

        /// <summary>
        /// 质控医师;
        /// </summary>
        public string m_strfzkdoct = string.Empty;

        /// <summary>
        /// 质控护士编号;
        /// </summary>
        public string m_strfzknursebh = string.Empty;

        /// <summary>
        /// 质控护士;
        /// </summary>
        public string m_strfzknurse = string.Empty;

        /// <summary>
        /// 质控日期;
        /// </summary>
        public DateTime m_strfzkrq = DateTime.MinValue;

        /// <summary>
        /// 是否因麻醉死亡编号;
        /// </summary>
        public string m_strfmzdeadbh = string.Empty;

        /// <summary>
        /// 是否因麻醉死亡;
        /// </summary>
        public string m_strfmzdead = string.Empty;

        /// <summary>
        /// 总费用;
        /// </summary>
        public double m_Dblfsum1 = 0;

        /// <summary>
        /// 床位费;
        /// </summary>
        public double m_Dblfcwf = 0;

        /// <summary>
        /// 护理费;
        /// </summary>
        public double m_Dblfhlf = 0;

        /// <summary>
        /// 西药费;
        /// </summary>
        public double m_Dblfxyf = 0;

        /// <summary>
        /// 中药费;
        /// </summary>
        public double m_Dblfzyf = 0;

        /// <summary>
        /// 中成药费;
        /// </summary>
        public double m_Dblfzchyf = 0;

        /// <summary>
        /// 中草药费;
        /// </summary>
        public double m_Dblfzcyf = 0;

        /// <summary>
        /// 放射费;
        /// </summary>
        public double m_Dblffsf = 0;

        /// <summary>
        /// 化验费;
        /// </summary>
        public double m_Dblfhyf = 0;

        /// <summary>
        /// 输氧费;
        /// </summary>
        public double m_Dblfsyf = 0;

        /// <summary>
        /// 输血费;
        /// </summary>
        public double m_Dblfsxf = 0;

        /// <summary>
        /// 诊疗费;
        /// </summary>
        public double m_Dblfzlf = 0;

        /// <summary>
        /// 手术费;
        /// </summary>
        public double m_Dblfssf = 0;

        /// <summary>
        /// 接生费;
        /// </summary>
        public double m_Dblfjsf = 0;

        /// <summary>
        /// 检查费;
        /// </summary>
        public double m_Dblfjcf = 0;

        /// <summary>
        /// 麻醉费;
        /// </summary>
        public double m_Dblfmzf = 0;

        /// <summary>
        /// 婴儿费;
        /// </summary>
        public double m_Dblfyef = 0;

        /// <summary>
        /// 陪床费;
        /// </summary>
        public double m_Dblfpcf = 0;

        /// <summary>
        /// 其他费;
        /// </summary>
        public double m_Dblfqtf = 0;

        /// <summary>
        /// 是否尸检编号;
        /// </summary>
        public string m_strfbodybh = string.Empty;

        /// <summary>
        /// 是否尸检;
        /// </summary>
        public string m_strfbody = string.Empty;

        /// <summary>
        /// 是否首例手术编号;
        /// </summary>
        public string m_strfisopfirstbh = string.Empty;

        /// <summary>
        /// 是否首例手术;
        /// </summary>
        public string m_strfisopfirst = string.Empty;

        /// <summary>
        /// 是否首例治疗编号;
        /// </summary>
        public string m_strfiszlfirstbh = string.Empty;

        /// <summary>
        /// 是否首例治疗;
        /// </summary>
        public string m_strfiszlfirst = string.Empty;

        /// <summary>
        /// 是否首例检查编号;
        /// </summary>
        public string m_strfisjcfirstbh = string.Empty;

        /// <summary>
        /// 是否首例检查;
        /// </summary>
        public string m_strfisjcfirst = string.Empty;

        /// <summary>
        /// 是否首例诊断编号;
        /// </summary>
        public string m_strfiszdfirstbh = string.Empty;

        /// <summary>
        /// 是否首例诊断;
        /// </summary>
        public string m_strfiszdfirst = string.Empty;

        /// <summary>
        /// 是否随诊编号;
        /// </summary>
        public string m_strfisszbh = string.Empty;

        /// <summary>
        /// 是否随诊;
        /// </summary>
        public string m_strfissz = string.Empty;

        /// <summary>
        /// 随诊期限;
        /// </summary>
        public string m_strfszqx = string.Empty;

        /// <summary>
        /// 是否示教病案编号;
        /// </summary>
        public string m_strfsamplebh = string.Empty;

        /// <summary>
        /// 是否示教病案;
        /// </summary>
        public string m_strfsample = string.Empty;

        /// <summary>
        /// 血型编号;
        /// </summary>
        public string m_strfbloodbh = string.Empty;

        /// <summary>
        /// 血型;
        /// </summary>
        public string m_strfblood = string.Empty;

        /// <summary>
        /// RH编号;
        /// </summary>
        public string m_strfrhbh = string.Empty;

        /// <summary>
        /// RH;
        /// </summary>
        public string m_strfrh = string.Empty;

        /// <summary>
        /// 输血反应编号;
        /// </summary>
        public string m_strfsxfybh = string.Empty;

        /// <summary>
        /// 输血反应;
        /// </summary>
        public string m_strfsxfy = string.Empty;

        /// <summary>
        /// 输液反应编号;
        /// </summary>
        public string m_strfsyfybh = string.Empty;

        /// <summary>
        /// 输液反应;
        /// </summary>
        public string m_strfsyfy = string.Empty;

        /// <summary>
        /// 输血品种红细胞数量;
        /// </summary>
        public double m_Dblfredcell = 0;

        /// <summary>
        /// 血小板
        /// </summary>
        public double m_Dblfplaque = 0;

        /// <summary>
        /// 血浆;
        /// </summary>
        public double m_Dblfserous = 0;

        /// <summary>
        /// 全血;
        /// </summary>
        public double m_Dblfallblood = 0;

        /// <summary>
        /// 其他;
        /// </summary>
        public double m_Dblfotherblood = 0;

        /// <summary>
        /// 院际会诊（次）;
        /// </summary>
        public int m_Intfhzyj = 0;

        /// <summary>
        /// 远程会诊（次）;
        /// </summary>
        public int m_Intfhzyc = 0;

        /// <summary>
        /// 特级护理（小时）;
        /// </summary>
        public int m_Intfhltj = 0;

        /// <summary>
        /// I级护理（日）;
        /// </summary>
        public int m_Intfhl1 = 0;

        /// <summary>
        /// II级护理（日）;
        /// </summary>
        public int m_Intfhl2 = 0;

        /// <summary>
        /// III级护理（日）;
        /// </summary>
        public int m_Intfhl3 = 0;

        /// <summary>
        /// 重诊监护（小时）;
        /// </summary>
        public int m_Intfhlzz = 0;

        /// <summary>
        /// 特殊护理（日）;
        /// </summary>
        public int m_Intfhlts = 0;

        /// <summary>
        /// 婴儿数;
        /// </summary>
        public int m_Intfbabynum = 0;

        /// <summary>
        /// 是否部分病种;
        /// </summary>
        public string m_strftwill = string.Empty;

        /// <summary>
        /// 是否抢救病人;
        /// </summary>
        public string m_strfqjbr = string.Empty;

        /// <summary>
        /// 是否抢救成功;
        /// </summary>
        public string m_strfqjsuc = string.Empty;

        /// <summary>
        /// 是否三日确诊;
        /// </summary>
        public string m_strfthreqz = string.Empty;

        /// <summary>
        /// 是否月内再次住院;
        /// </summary>
        public string m_strfback = string.Empty;

        /// <summary>
        /// 是否中度烧伤;
        /// </summary>
        public string m_strfifzdss = string.Empty;

        /// <summary>
        /// 是否单病种;
        /// </summary>
        public string m_strfifdbz = string.Empty;

        /// <summary>
        /// 中医院治疗费(预留字段);
        /// </summary>
        public double m_Dblfzlfzy = 0;

        /// <summary>
        /// 首次转科统一科号;
        /// </summary>
        public string m_strfzktykh = string.Empty;

        /// <summary>
        /// 首次转科科别;
        /// </summary>
        public string m_strfzkdept = string.Empty;

        /// <summary>
        /// 首次转科日期;
        /// </summary>
        public DateTime m_strfzkdate = DateTime.MinValue;

        /// <summary>
        /// 首次转科时间;
        /// </summary>
        public string m_strfzktime = string.Empty;

        /// <summary>
        /// 输入员编号;
        /// </summary>
        public string m_strfsrybh = string.Empty;

        /// <summary>
        /// 输入员;
        /// </summary>
        public string m_strfsry = string.Empty;

        /// <summary>
        /// 输入日期;
        /// </summary>
        public DateTime m_strDateTime = DateTime.MinValue;

        /// <summary>
        /// 疾病分型编号;
        /// </summary>
        public string m_strfjbfxbh = string.Empty;

        /// <summary>
        /// 疾病分型;
        /// </summary>
        public string m_strfjbfx = string.Empty;

        /// <summary>
        /// 复合归档编号;
        /// </summary>
        public string m_strffhgdbh = string.Empty;

        /// <summary>
        /// 复合归档;
        /// </summary>
        public string m_strffhgd = string.Empty;

        /// <summary>
        /// 病人来源编号;
        /// </summary>
        public string m_strfsourcebh = string.Empty;

        /// <summary>
        /// 病人来源;
        /// </summary>
        public string m_strfsource = string.Empty;

        /// <summary>
        /// 是否手术;
        /// </summary>
        public string m_strfifss = string.Empty;

        /// <summary>
        /// 是否输入妇婴卡;
        /// </summary>
        public string m_strfiffyk = string.Empty;

        /// <summary>
        /// 是否并发症;
        /// </summary>
        public string m_strfbfz = string.Empty;

        /// <summary>
        /// 医院感染次数;
        /// </summary>
        public int m_Intfyngr = 0;

        /// <summary>
        /// 状态;
        /// </summary>
        public string m_strfflag = string.Empty;

        /// <summary>
        /// 数字验证;
        /// </summary>
        public string m_strfdatacheck = string.Empty;

        /// <summary>
        /// 扩展1;
        /// </summary>
        public string m_strfextend1 = string.Empty;

        /// <summary>
        /// 扩展2;
        /// </summary>
        public string m_strfextend2 = string.Empty;

        /// <summary>
        /// 扩展3;
        /// </summary>
        public string m_strfextend3 = string.Empty;

        /// <summary>
        /// 扩展4;
        /// </summary>
        public string m_strfextend4 = string.Empty;

        /// <summary>
        /// 扩展5;
        /// </summary>
        public string m_strfextend5 = string.Empty;

        /// <summary>
        /// 扩展6;
        /// </summary>
        public string m_strfextend6 = string.Empty;

        /// <summary>
        /// 扩展7;
        /// </summary>
        public string m_strfextend7 = string.Empty;

        /// <summary>
        /// 扩展8;
        /// </summary>
        public string m_strfextend8 = string.Empty;

        /// <summary>
        /// 扩展9;
        /// </summary>
        public string m_strfextend9 = string.Empty;

        /// <summary>
        /// 扩展10;
        /// </summary>
        public string m_strfextend10 = string.Empty;

        /// <summary>
        /// 扩展11;
        /// </summary>
        public string m_strfextend11 = string.Empty;

        /// <summary>
        /// 扩展12;
        /// </summary>
        public string m_strfextend12 = string.Empty;

        /// <summary>
        /// 扩展13;
        /// </summary>
        public string m_strfextend13 = string.Empty;

        /// <summary>
        /// 扩展14;
        /// </summary>
        public string m_strfextend14 = string.Empty;

        /// <summary>
        /// 扩展15;
        /// </summary>
        public string m_strfextend15 = string.Empty;

        /// <summary>
        /// 籍贯;
        /// </summary>
        public string m_strfnative = string.Empty;

        /// <summary>
        /// 现住址;
        /// </summary>
        public string m_strfcurraddr = string.Empty;

        /// <summary>
        /// 现电话;
        /// </summary>
        public string m_strfcurrtele = string.Empty;

        /// <summary>
        /// 现邮编;
        /// </summary>
        public string m_strfcurrpost = string.Empty;

        /// <summary>
        /// 职业编号;
        /// </summary>
        public string m_strfjobbh = string.Empty;

        /// <summary>
        /// 新生儿出生体重;
        /// </summary>
        public string m_strfcstz = string.Empty;

        /// <summary>
        /// 新生儿入院体重;
        /// </summary>
        public string m_strfrytz = string.Empty;

        /// <summary>
        /// 入院途径编号;
        /// </summary>
        public string m_strfryresourcebh = string.Empty;

        /// <summary>
        /// 入院途径;
        /// </summary>
        public string m_strfryresource = string.Empty;

        /// <summary>
        /// 临床路径病例编号;
        /// </summary>
        public string m_strfycljbh = string.Empty;

        /// <summary>
        /// 临床路径病例;
        /// </summary>
        public string m_strfyclj = string.Empty;

        /// <summary>
        /// 病理疾病编码;
        /// </summary>
        public string m_strfphzdbh = string.Empty;

        /// <summary>
        /// 病理号;
        /// </summary>
        public string m_strfphzdnum = string.Empty;

        /// <summary>
        /// 是否药物过敏编号;
        /// </summary>
        public string m_strfifgmywbh = string.Empty;

        /// <summary>
        /// 是否药物过敏;
        /// </summary>
        public string m_strfifgmyw = string.Empty;

        /// <summary>
        /// 责任护士编号;
        /// </summary>
        public string m_strfnursebh = string.Empty;

        /// <summary>
        /// 责任护士;
        /// </summary>
        public string m_strfnurse = string.Empty;

        /// <summary>
        /// 离院方式;
        /// </summary>
        public string m_strflyfsbh = string.Empty;

        /// <summary>
        /// 离院方式编号;
        /// </summary>
        public string m_strflyfs0 = string.Empty;

        /// <summary>
        /// 离院方式为医嘱转院，拟接收医疗机构名称;
        /// </summary>
        public string m_strfyzouthostital0 = string.Empty;

        /// <summary>
        /// 离院方式为转社区卫生服务器机构/乡镇卫生院，拟接收医疗机构名称;
        /// </summary>
        public string m_strfsqouthostital0 = string.Empty;

        /// <summary>
        /// 是否有出院31天内再住院计划编号;
        /// </summary>
        public string m_strfisagainrybh = string.Empty;

        /// <summary>
        /// 是否有出院31天内再住院计划;
        /// </summary>
        public string m_strfisagainry = string.Empty;

        /// <summary>
        /// 再住院目的;
        /// </summary>
        public string m_strfisagainrymd0 = string.Empty;

        /// <summary>
        /// 颅脑损伤患者昏迷时间：入院前天;
        /// </summary>
        public int m_Intfryqhmdays = 0;

        /// <summary>
        /// 颅脑损伤患者昏迷时间：入院前小时;
        /// </summary>
        public int m_Intfryqhmhours = 0;

        /// <summary>
        /// 颅脑损伤患者昏迷时间：入院前分钟;
        /// </summary>
        public int m_Intfryqhmmins = 0;

        /// <summary>
        /// 入院前昏迷总分钟;
        /// </summary>
        public int m_Intfryqhmcounts = 0;

        /// <summary>
        /// 颅脑损伤患者昏迷时间：入院后天;
        /// </summary>
        public int m_Intfryhmdays = 0;

        /// <summary>
        /// 颅脑损伤患者昏迷时间：入院后小时;
        /// </summary>
        public int m_Intfryhmhours = 0;

        /// <summary>
        /// 颅脑损伤患者昏迷时间：入院后分钟;
        /// </summary>
        public int m_Intfryhmmins = 0;

        /// <summary>
        /// 入院后昏迷总分钟;
        /// </summary>
        public int m_Intfryhmcounts = 0;

        /// <summary>
        /// 新的付款方式编号;
        /// </summary>
        public string m_strffbbhnew = string.Empty;

        /// <summary>
        /// 新的付款方式;
        /// </summary>
        public string m_strffbnew = string.Empty;

        /// <summary>
        /// 住院总费用：自费金额;
        /// </summary>
        public double m_Dblfzfje = 0;

        /// <summary>
        /// 综合医疗服务类：（1）一般医疗服务费;
        /// </summary>
        public double m_Dblfzhfwlylf = 0;

        /// <summary>
        /// 综合医疗服务类：（2）一般治疗操作费;
        /// </summary>
        public double m_Dblfzhfwlczf = 0;

        /// <summary>
        /// 综合医疗服务类：（3）护理费;
        /// </summary>
        public double m_Dblfzhfwlhlf = 0;

        /// <summary>
        /// 综合医疗服务类：（4）其他费用;
        /// </summary>
        public double m_Dblfzhfwlqtf = 0;

        /// <summary>
        /// 诊断类：(5)病理诊断费;
        /// </summary>
        public double m_Dblfzdlblf = 0;

        /// <summary>
        /// 诊断类：(6)实验室诊断费;
        /// </summary>
        public double m_Dblfzdlsssf = 0;

        /// <summary>
        /// 诊断类：(7)影像学诊断费;
        /// </summary>
        public double m_Dblfzdlyxf = 0;

        /// <summary>
        /// 诊断类：(8)临床诊断项目费;
        /// </summary>
        public double m_Dblfzdllcf = 0;

        /// <summary>
        /// 治疗类：(9)非手术治疗项目费;
        /// </summary>
        public double m_Dblfzllffssf = 0;

        /// <summary>
        /// 治疗类：非手术治疗项目费其中临床物理治疗费;
        /// </summary>
        public double m_Dblfzllfwlzwlf = 0;

        /// <summary>
        /// 治疗类：)手术治疗费;
        /// </summary>
        public double m_Dblfzllfssf = 0;

        /// <summary>
        /// 治疗类：手术治疗费其中麻醉费;
        /// </summary>
        public double m_Dblfzllfmzf = 0;

        /// <summary>
        /// 治疗类：手术治疗费其中手术费;
        /// </summary>
        public double m_Dblfzllfsszlf = 0;

        /// <summary>
        /// 康复类：(11)康复费;
        /// </summary>
        public double m_Dblfkflkff = 0;

        /// <summary>
        /// 中医类：中医治疗类;
        /// </summary>
        public double m_Dblfzylzf = 0;

        /// <summary>
        /// 西药类：西药费其中抗菌药物费用;
        /// </summary>
        public double m_Dblfxylgjf = 0;

        /// <summary>
        /// 血液和血液制品类：血费;
        /// </summary>
        public double m_Dblfxylxf = 0;

        /// <summary>
        /// 血液和血液制品类：白蛋白类制品费;
        /// </summary>
        public double m_Dblfxylbqbf = 0;

        /// <summary>
        /// 血液和血液制品类：球蛋白制品费;
        /// </summary>
        public double m_Dblfxylqdbf = 0;

        /// <summary>
        /// 血液和血液制品类：凝血因子类制品费;
        /// </summary>
        public double m_Dblfxylyxyzf = 0;

        /// <summary>
        /// 血液和血液制品类：细胞因子类费;
        /// </summary>
        public double m_Dblfxylxbyzf = 0;

        /// <summary>
        /// 耗材类：检查用一次性医用材料费;
        /// </summary>
        public double m_Dblfhclcjf = 0;

        /// <summary>
        /// 耗材类：治疗用一次性医用材料费;
        /// </summary>
        public double m_Dblfhclzlf = 0;

        /// <summary>
        /// 耗材类：手术用一次性医用材料费;
        /// </summary>
        public double m_Dblfhclssf = 0;

        /// <summary>
        /// 综合医疗服务类：一般医疗服务费其中中医辨证论治费（中医）;
        /// </summary>
        public double m_Dblfzhfwlylf01 = 0;

        /// <summary>
        /// 综合医疗服务类：一般医疗服务费其中中医辨证论治会诊费（中医）;
        /// </summary>
        public double m_Dblfzhfwlylf02 = 0;

        /// <summary>
        /// 中医类：诊断（中医）;
        /// </summary>
        public double m_Dblfzylzdf = 0;

        /// <summary>
        /// 中医类：治疗（中医）;
        /// </summary>
        public double m_Dblfzylzlf = 0;

        /// <summary>
        /// 中医类：治疗其中外治（中医）;
        /// </summary>
        public double m_Dblfzylzlf01 = 0;

        /// <summary>
        /// 中医类：治疗其中骨伤（中医）;
        /// </summary>
        public double m_Dblfzylzlf02 = 0;

        /// <summary>
        /// 中医类：治疗其中针刺与灸法（中医）;
        /// </summary>
        public double m_Dblfzylzlf03 = 0;

        /// <summary>
        /// 中医类：治疗推拿治疗（中医）;
        /// </summary>
        public double m_Dblfzylzlf04 = 0;

        /// <summary>
        /// 中医类：治疗其中肛肠治疗（中医）;
        /// </summary>
        public double m_Dblfzylzlf05 = 0;

        /// <summary>
        /// 中医类：治疗其中特殊治疗（中医）;
        /// </summary>
        public double m_Dblfzylzlf06 = 0;

        /// <summary>
        /// 中医类：其他（中医）;
        /// </summary>
        public double m_Dblfzylqtf = 0;

        /// <summary>
        /// 中医类：其他其中中药特殊调配加工（中医）;
        /// </summary>
        public double m_Dblfzylqtf01 = 0;

        /// <summary>
        /// 中医类：其他其中辨证施膳（中医）;
        /// </summary>
        public double m_Dblfzylqtf02 = 0;

        /// <summary>
        /// 中药类：中成药费其中医疗机构中药制剂费（中医）;
        /// </summary>
        public double m_Dblfzcljgzjf = 0;
    }
    #endregion

    #region 病案费用
    /// <summary>
    /// 病案费用
    /// </summary>
    [Serializable]
    public class clsInHospitalMainCharge : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// 费用
        /// </summary>
        public double m_dblMoney = 0;
        /// <summary>
        /// 病人流水号
        /// </summary>
        public string m_strRegisterID = string.Empty;
        /// <summary>
        /// 费用名称
        /// </summary>
        public string m_strTypeName = string.Empty;
    }

    #endregion

    #region 病人手术信息
    /// <summary>
    /// 病人手术信息
    /// </summary>
    [Serializable]
    public class clsOperationVO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// 机构代码;
        /// </summary>
        public string m_strjgdm = string.Empty;

        /// <summary>
        /// 住院流水号;
        /// </summary>
        public string m_strfzyid = string.Empty;

        /// <summary>
        /// 手术医生所在科室名称;
        /// </summary>
        public string m_stropksname = string.Empty;

        /// <summary>
        /// 手术医生所在科室编号;
        /// </summary>
        public string m_stroptykh = string.Empty;

        /// <summary>
        /// 流水号;
        /// </summary>
        public string m_strfid = string.Empty;

        /// <summary>
        /// 病案号;
        /// </summary>
        public string m_strfprn = string.Empty;

        /// <summary>
        /// 次数;
        /// </summary>
        public int m_Intftimes = 0;

        /// <summary>
        /// 病人姓名;
        /// </summary>
        public string m_strfname = string.Empty;

        /// <summary>
        /// 手术次数;
        /// </summary>
        public int m_Intfoptimes = 0;

        /// <summary>
        /// 手术码;
        /// </summary>
        public string m_strfopcode = string.Empty;

        /// <summary>
        /// 手术码对应名称;
        /// </summary>
        public string m_strfop = string.Empty;

        /// <summary>
        /// 手术日期;
        /// </summary>
        public DateTime m_strfopdate = DateTime.MinValue;

        /// <summary>
        /// 切口编号;
        /// </summary>
        public string m_strfqiekoubh = string.Empty;

        /// <summary>
        /// 切口;
        /// </summary>
        public string m_strfqiekou = string.Empty;

        /// <summary>
        /// 愈合编号;
        /// </summary>
        public string m_strfyuhebh = string.Empty;

        /// <summary>
        /// 愈合;
        /// </summary>
        public string m_strfyuhe = string.Empty;

        /// <summary>
        /// 手术医生编号;
        /// </summary>
        public string m_strfdocbh = string.Empty;

        /// <summary>
        /// 手术医生;
        /// </summary>
        public string m_strfdocname = string.Empty;

        /// <summary>
        /// 麻醉方式编号;
        /// </summary>
        public string m_strfmazuibh = string.Empty;

        /// <summary>
        /// 麻醉方式;
        /// </summary>
        public string m_strfmazui = string.Empty;

        /// <summary>
        /// 是否附加手术;
        /// </summary>
        public string m_strfiffsop = string.Empty;

        /// <summary>
        /// i助编号;
        /// </summary>
        public string m_strfopdoct1bh = string.Empty;

        /// <summary>
        /// i助姓名;
        /// </summary>
        public string m_strfopdoct1 = string.Empty;

        /// <summary>
        /// ii助编号;
        /// </summary>
        public string m_strfopdoct2bh = string.Empty;

        /// <summary>
        /// ii助姓名;
        /// </summary>
        public string m_strfopdoct2 = string.Empty;

        /// <summary>
        /// 麻醉医生编号;
        /// </summary>
        public string m_strfmzdoctbh = string.Empty;

        /// <summary>
        /// 麻醉医生;
        /// </summary>
        public string m_strfmzdoct = string.Empty;

        /// <summary>
        /// 排序;
        /// </summary>
        public string m_strfpx = string.Empty;

        /// <summary>
        /// 择期手术编号;
        /// </summary>
        public string m_strfzqssbh = string.Empty;

        /// <summary>
        /// 择期手术;
        /// </summary>
        public string m_strfzqss = string.Empty;

        /// <summary>
        /// 手术级别编号;
        /// </summary>
        public string m_strfssjbbh = string.Empty;

        /// <summary>
        /// 手术级别;
        /// </summary>
        public string m_strfssjb = string.Empty;
    }
    #endregion
    //End====qinhong====添加病案首页和手术VO（常平）==================
}
