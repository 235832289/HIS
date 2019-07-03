using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.middletier.HIS;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 结算DOMIAN类
    /// </summary>
    public class clsDcl_Charge : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public clsDcl_Charge()
        {
        }
        #endregion

        #region 根据员工ID获取隶属组信息
        /// <summary>
        /// 根据员工ID获取隶属组信息
        /// </summary>
        /// <param name="EmpID">员工ID</param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngGetGroupEmp(string EmpID, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.baseInfo.clsEmployeeSvc objSvc =
                                                           (com.digitalwave.iCare.middletier.baseInfo.clsEmployeeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.baseInfo.clsEmployeeSvc));

            long l = objSvc.m_lngGetGroupEmp(EmpID, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 根据分类范围获取费用分类(门诊核算、发票；住院核算、发票)定义信息
        /// <summary>
        /// 根据分类范围获取费用分类(门诊核算、发票；住院核算、发票)定义信息
        /// </summary>
        /// <param name="Scope">范围: 1 门诊核算 2 门诊发票 3 住院核算 4 住院发票</param>
        /// <param name="Status">% 全部 0 停用 1 启用</param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngGetDefChargeCat(string Scope, string Status, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngGetDefChargeCat(Scope, Status, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 获取身份(费别)信息
        /// <summary>
        /// 获取身份(费别)信息
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngGetPayTypeInfo(out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsCommonQuery objSvc =
                                                                (com.digitalwave.iCare.middletier.HIS.clsCommonQuery)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCommonQuery));

            long l = objSvc.m_lngGetPayTypeInfo(out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 获取员工代码表
        /// <summary>
        /// 获取员工代码表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngGetEmployee(out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngGetEmployee(out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 根据员工工号获取ID和姓名
        /// <summary>
        /// 根据员工工号获取ID和姓名
        /// </summary>
        /// <param name="EmpCode"></param>
        /// <param name="EmpID"></param>
        /// <param name="EmpName"></param>
        /// <returns></returns>
        public long m_lngGetEmployee(string EmpCode, out string EmpID, out string EmpName)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngGetEmployee(EmpCode, out EmpID, out EmpName);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 根据用户ID获取所属角色列表
        /// <summary>
        /// 根据用户ID获取所属角色列表
        /// </summary>
        /// <param name="EmpID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngGetEmpRole(string EmpID, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsCommonQuery objSvc =
                                                 (com.digitalwave.iCare.middletier.HIS.clsCommonQuery)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCommonQuery));

            long l = objSvc.m_lngGetEmpRole(EmpID, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 获得病区信息
        /// <summary>
        /// 获得病区信息
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="Flag">1 科室 2 病区</param>
        /// <returns></returns>
        public long m_lngGetDeptArea(out DataTable dt, int Flag)
        {
            com.digitalwave.iCare.middletier.HIS.clsCommonQuery objSvc =
                                                 (com.digitalwave.iCare.middletier.HIS.clsCommonQuery)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCommonQuery));

            long l = objSvc.m_lngGetDeptArea(out dt, Flag);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 根据病区ID和床号ID(或CODE)获取住院号
        /// <summary>
        /// 根据病区ID和床号ID(或CODE)获取住院号
        /// </summary>
        /// <param name="AreaID">病区ID</param>
        /// <param name="BedID">床号ID(或CODE)</param>          
        /// <returns></returns>        
        public string m_strGetZyhByAreaAndBedID(string AreaID, string BedID)
        {
            com.digitalwave.iCare.middletier.HIS.clsCommonQuery objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsCommonQuery)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCommonQuery));

            string s = objSvc.m_strGetZyhByAreaAndBedID(AreaID, BedID);
            objSvc.Dispose();

            return s;
        }
        #endregion

        #region 根据住院号或诊疗卡号获取病人信息
        /// <summary>
        /// 根据住院号或诊疗卡号获取病人信息
        /// </summary>
        /// <param name="no"></param>
        /// <param name="dt"></param>
        /// <param name="flag">0 所有 1 在院 2 出院 3 呆帐</param>
        /// <param name="type">0 诊疗卡号或住院号 1 诊疗卡号  2 住院号 </param>
        /// <returns></returns>
        public long m_lngGetPatientinfoByNO(string no, out DataTable dt, int flag, int type)
        {
            com.digitalwave.iCare.middletier.HIS.clsCommonQuery objSvc =
                                                 (com.digitalwave.iCare.middletier.HIS.clsCommonQuery)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCommonQuery));

            long l = objSvc.m_lngGetPatientinfoByNO(no, out dt, flag, type);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region  查找出院病人床号
        /// <summary>
        /// 查找出院病人床号
        /// </summary>
        /// <param name="no"></param>
        /// <param name="type"></param>
        /// <param name="p_strBedNo"></param>
        /// <returns></returns>
        public long m_lngGetDedNo(string no, ref string p_strBedNo)
        {
            com.digitalwave.iCare.middletier.HIS.clsCommonQuery objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsCommonQuery)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCommonQuery));

            long l = objSvc.m_lngGetDedNo(no, ref p_strBedNo);
            objSvc.Dispose();
            return l;
        }
        #endregion

        #region 根据住院登记流水号查找病人所有期帐信息
        /// <summary>
        /// 根据住院登记流水号查找病人所有期帐信息
        /// </summary>
        /// <param name="RegID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngGetPatientDayaccountsByRegID(string RegID, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                 (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngGetPatientDayaccountsByRegID(RegID, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 获取该期帐有效费用信息
        /// <summary>
        /// 获取该期帐有效费用信息
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="type">1 根据入院登记ID 2 根据期帐ID </param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngGetChargeInfoByID(string ID, int type, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                 (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngGetChargeInfoByID(ID, type, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 母婴合并结算费用一起查询ucpatien控件使用
        /// <summary>
        /// 母婴合并结算费用一起查询ucpatien控件使用
        /// </summary>
        /// <param name="p_strRegisterID">病人registerId</param>
        /// <param name="p_dtbCharge"></param>
        /// <returns></returns>
        public long m_lngGetChargeInfoByIDForBaby(string p_strRegisterID, out DataTable p_dtbCharge)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                 (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long lngRes = objSvc.m_lngGetChargeInfoByIDForBaby(p_strRegisterID, out p_dtbCharge);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion


        #region 获取项目分类信息(核算分类、发票分类)
        /// <summary>
        /// 获取项目分类信息(核算分类、发票分类)
        /// </summary>
        /// <param name="flag">分类类型：1 门诊核算 2 门诊发票 3 住院核算 4 住院发票 5 病案核算</param>
        /// <param name="dt"></param>
        /// <returns></returns>              
        public long m_lngGetChargeItemCat(int flag, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                 (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngGetChargeItemCat(flag, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 根据住院登记流水号检查项目状态
        /// <summary>
        /// 根据住院登记流水号检查项目状态
        /// </summary>
        /// <param name="RegID">住院登记流水号</param>
        /// <param name="status">0=待确认;1=待结;2=待清;3=已清;4=直收</param>
        /// <returns></returns>
        public bool m_blnCheckChargeItemStatus(string RegID, int status)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                 (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            bool b = objSvc.m_blnCheckChargeItemStatus(RegID, status);
            objSvc.Dispose();

            return b;
        }
        #endregion

        #region 根据住院登记流水号生成各状态项目总费用
        /// <summary>
        /// 根据住院登记流水号生成各状态项目总费用
        /// </summary>
        /// <param name="RegID">住院登记流水号</param>
        /// <param name="status">0 待确认 1 待结 2 待清 3 已清 4 直收 9 生成期帐</param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngGetChargeItemFee(string RegID, int status, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                             (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngGetChargeItemFee(RegID, status, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 检查发票号是否重复
        /// <summary>
        /// 检查发票号是否重复
        /// </summary>
        /// <param name="CurrNo"></param>
        /// <returns></returns>
        public bool m_blnCheckInvoiceNo(string CurrNo)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                 (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            bool b = objSvc.m_blnCheckInvoiceNo(CurrNo);
            objSvc.Dispose();

            return b;
        }
        #endregion

        #region 根据入院登记流水ID获取最后诊金、床位费生成时间
        /// <summary>
        /// 根据入院登记流水ID获取最后诊金、床位费生成时间
        /// </summary>
        /// <param name="RegID"></param>
        /// <param name="FinallyDate"></param>
        /// <returns></returns>
        public long m_lngGetFinallyDiagFeeDateByRegID(string RegID, out string FinallyDate)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                             (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngGetFinallyDiagFeeDateByRegID(RegID, out FinallyDate);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 根据入院登记流水号获取预出院时间
        /// <summary>
        /// 根据入院登记流水号获取预出院时间
        /// </summary>
        /// <param name="RegID"></param>
        /// <param name="PrepDate"></param>
        /// <returns></returns>
        public long m_lngGetPrepLHDateByRegID(string RegID, out string PrepDate)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                             (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngGetPrepLHDateByRegID(RegID, out PrepDate);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 结帐
        /// <summary>
        /// 结帐
        /// </summary>
        /// <param name="dtSource"></param>
        /// <param name="DayChrgType">期帐结算类型：1 期帐 2 明细</param>
        /// <param name="DayAccountsArr"></param>
        /// <param name="Charge_VO"></param>
        /// <param name="ChargeCatArr"></param>
        /// <param name="Invoice_VO"></param>
        /// <param name="InvoCatArr"></param>
        /// <param name="PaymentArr"></param>
        /// <param name="PrePayDeal">预交金处理： 0 不处理 1 退回 2 转下期</param> 
        /// <param name="PrePayIDArr"></param>
        /// <param name="ChrgType">结算类型：1 中途结算 2 出院结算 3 呆帐结算</param>
        /// <returns></returns>
        public long m_lngReckoning(DataTable dtSource, int DayChrgType, ArrayList DayAccountsArr, clsBihCharge_VO Charge_VO, ArrayList ChargeCatArr, clsBihInvoice_VO Invoice_VO, ArrayList InvoCatArr, ArrayList PaymentArr, int PrePayDeal, ArrayList PrePayIDArr, int ChargeType, clsBihConfirm_VO Confirm_VO, out string ChargeNo)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                             (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngReckoning(dtSource, DayChrgType, DayAccountsArr, Charge_VO, ChargeCatArr, Invoice_VO, InvoCatArr, PaymentArr, PrePayDeal, PrePayIDArr, ChargeType, Confirm_VO, out ChargeNo);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 退款
        /// <summary>
        /// 退款
        /// </summary>
        /// <param name="ChargeNo"></param>
        /// <param name="Invono"></param>
        /// <param name="EmpID"></param>
        /// <param name="ChargeType">结算类型：1 中途结算 2 出院结算 3 呆帐结算 4 直收 5 确认收费 6 呆帐补交款结算</param>
        /// <returns></returns>
        public long m_lngRefundment(string ChargeNo, string Invono, string EmpID, int ChargeType, int PayMode)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                             (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngRefundment(ChargeNo, Invono, EmpID, ChargeType, PayMode);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 根据结算号获取发票明细信息
        /// <summary>
        /// 根据结算号获取发票明细信息
        /// </summary>
        /// <param name="ChargeNo"></param>
        /// <param name="dtMain"></param>
        /// <param name="dtDet"></param>
        /// <param name="dtPrepay"></param>
        /// <returns></returns>
        public long m_lngGetInvoiceByChargeNo(string ChargeNo, out DataTable dtMain, out DataTable dtDet, out DataTable dtPrepay, out DataTable dtPayMode, out DataTable dtItemDate)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                             (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngGetInvoiceByChargeNo(ChargeNo, out dtMain, out dtDet, out dtPrepay, out dtPayMode, out dtItemDate);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 根据入院登记流水ID获取发票号信息
        /// <summary>
        /// 根据入院登记流水ID获取发票号信息
        /// </summary>
        /// <param name="RegID"></param>
        /// <param name="Type">发票类型范围：1 正常 2 正常+重打</param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngGetInvoiceInfoByRegID(string RegID, int Type, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                             (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngGetInvoiceByRegID(RegID, Type, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 查询收费项目
        /// <summary>
        /// 查询收费项目
        /// </summary>
        /// <param name="FindStr"></param>
        /// <param name="PatType">病人身份</param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngFindChargeItem(string FindStr, string PatType, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngFindChargeItem(FindStr, PatType, out dt);
            objSvc.Dispose();

            return l;
        }

        /// <summary>
        /// 根据项目ID查找收费项目
        /// </summary>
        /// <param name="ItemID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngFindChargeItem(string ItemID, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngFindChargeItem(ItemID, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 直接收费生成费用明细
        /// <summary>
        /// 直接收费生成费用明细
        /// </summary>
        /// <param name="OrderDicArr">主诊疗项目数组</param>
        /// <param name="PatientChargeArr">费用明细数组</param>
        /// <param name="Type">8 直收 9 补记帐</param>
        /// <param name="OrderID">返回的费用ID号(是呀医嘱号字段)</param>
        /// <returns></returns>        
        public long m_lngGenPatientChargeByDir(ArrayList OrderDicArr, ArrayList PatientChargeArr, int Type, ref string OrderID)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngGenPatientChargeByDir(OrderDicArr, PatientChargeArr, Type, ref OrderID);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 根据住院登记流水号获取各生效类型(费用状态)费用信息
        /// <summary>
        /// 根据住院登记流水号获取各生效类型(费用状态)费用信息
        /// </summary>
        /// <param name="RegID">住院登记流水号</param>
        /// <param name="ActiveType">生效类型{1=其它;2=补记帐;3=确认记帐;4=确认收费;5=直接收费;888=费用状态分类;999=全部}</param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngGetFeeItemByActiveType(string RegID, int ActiveType, string Pstatus, string AreaID, string BeginDate, string EndDate, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngGetFeeItemByActiveType(RegID, ActiveType, Pstatus, AreaID, BeginDate, EndDate, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 根据医嘱ID(直收费用ID)获取费用明细
        /// <summary>
        /// 根据医嘱ID(直收费用ID)获取费用明细
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngGetPatientChargeByID(string ID, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngGetPatientChargeByID(ID, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 获取收费项目默认执行地点
        /// <summary>
        /// 获取收费项目默认执行地点
        /// </summary>
        /// <param name="ItemID"></param>
        /// <param name="ApplyAreaID"></param>
        /// <returns></returns>        
        public string m_strGetChargeItemDefaultExecAreaID(string ItemID, string ApplyAreaID, out string ExecAreaName)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            string s = objSvc.m_strGetChargeItemDefaultExecAreaID(ItemID, ApplyAreaID, out ExecAreaName);
            objSvc.Dispose();

            return s;
        }
        #endregion

        #region 提交补记帐费用明细
        /// <summary>
        /// 提交补记帐费用明细
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>        
        public long m_lngCommitPatchCharge(string OrderID, string RegID, string OperID, int Type)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngCommitPatchCharge(OrderID, RegID, OperID, Type);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 按日期滚费
        /// <summary>
        /// 按日期滚费
        /// </summary>
        /// <param name="ExecDate">滚费时间(格式：yyy-mm-dd hh:mm:ss</param>
        /// <param name="FeeDate">费用时间(格式：yyy-mm-dd hh:mm:ss</param>
        /// <param name="OperID">操作员ID</param>   
        /// <param name="RegID">个人滚费时：入院登记ID</param>  
        /// <param name="ExecType">1 正常夜间 2 出院补滚</param>
        public long AutoCharge(string ExecDate, string FeeDate, string OperID, string RegID, int ExecType)
        {
            //com.digitalwave.iCare.middletier.HIS.clsAutoCharge objSvc =
            //                                               (com.digitalwave.iCare.middletier.HIS.clsAutoCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAutoCharge));            

            //long l = objSvc.AutoCharge(ExecDate, OperID);
            //objSvc.Dispose();

            //com.digitalwave.iCare.middletier.HIS.clsAutoCharge_CS objSvc =
            //                                               (com.digitalwave.iCare.middletier.HIS.clsAutoCharge_CS)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAutoCharge_CS));

            com.digitalwave.iCare.middletier.HIS.clsAutoCharge_CS objSvc = new com.digitalwave.iCare.middletier.HIS.clsAutoCharge_CS();
            long l = objSvc.AutoCharge(ExecDate, FeeDate, OperID, clsPublic.m_intGetSysParm("1013"), clsPublic.m_intGetSysParm("1014"), RegID, ExecType);
            objSvc = null;

            return l;
        }
        #endregion

        #region 出院收取连续性费用
        /// <summary>
        /// 出院收取连续性费用
        /// </summary>
        /// <param name="FeeDate">费用时间(格式：yyy-mm-dd hh:mm:ss)</param>
        /// <param name="OperID">操作员ID</param>
        /// <param name="RegID">入院登记ID</param>
        /// <returns></returns>
        public long AutoChargeContinueItem(string FeeDate, string OperID, string RegID)
        {
            //com.digitalwave.iCare.middletier.HIS.clsAutoCharge_CS objSvc =
            //                                               (com.digitalwave.iCare.middletier.HIS.clsAutoCharge_CS)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAutoCharge_CS));

            com.digitalwave.iCare.middletier.HIS.clsAutoCharge objSvc =
                                                               (com.digitalwave.iCare.middletier.HIS.clsAutoCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAutoCharge));

            long l = objSvc.AutoChargeContinueItem(FeeDate, OperID, RegID);

            return l;
        }
        #endregion

        #region 获取期帐日期信息
        /// <summary>
        /// 获取期帐日期信息
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long GetDayAccountsInfo(out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsAutoCharge objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsAutoCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAutoCharge));

            long l = objSvc.GetDayAccountsInfo(out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 获取期帐最后生成时间
        /// <summary>
        /// 获取期帐最后生成时间
        /// </summary>
        /// <param name="RegID">入院登记ID</param>
        /// <returns></returns>        
        public string GetDayAccountsMaxDate(string RegID)
        {
            com.digitalwave.iCare.middletier.HIS.clsAutoCharge objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsAutoCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAutoCharge));

            string s = objSvc.GetDayAccountsMaxDate(RegID);
            objSvc.Dispose();

            return s;
        }
        #endregion

        #region 生成期帐
        /// <summary>
        /// 生成期帐
        /// </summary>
        /// <param name="DayAccounts_VO">期帐VO</param>
        /// <param name="EmpID">操作员ID</param>       
        /// <param name="ChargeType">0 普通结帐 1 出院结帐 2 出院结算</param>     
        /// <returns></returns>        
        public long m_lngBuildDayAccounts(clsBihDayAccounts_VO DayAccounts_VO, string EmpID, int ChargeType)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngBuildDayAccounts(DayAccounts_VO, EmpID, ChargeType);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 补期帐
        /// <summary>
        /// 补期帐
        /// </summary>
        /// <param name="PatientChargeArr">费用明细数组</param>        
        /// <param name="DayAccountID">期帐ID</param>                
        /// <returns></returns>        
        public long m_lngPatchDayAccount(ArrayList PatientChargeArr, string DayAccountID)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngPatchDayAccount(PatientChargeArr, DayAccountID);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 保存发票打印设置
        /// <summary>
        /// 保存发票打印设置
        /// </summary>
        /// <param name="ChargeItemCatArr">费用分类设置VO</param>
        /// <param name="Scope">范围: 1 门诊核算 2 门诊发票 3 住院核算 4 住院发票</param>
        /// <returns></returns>        
        public long m_lngSaveInvoiceSet(ArrayList ChargeItemCatArr, string Scope)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngSaveInvoiceSet(ChargeItemCatArr, Scope);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 收款员日结(发票+按金)
        /// <summary>
        /// 收款员日结(发票+按金)
        /// </summary>
        /// <param name="EmpID"></param>
        /// <param name="RecDate"></param>
        /// <param name="RemarkInfo"></param>
        /// <param name="RecType">0 全部 1 发票 2 按金</param>
        /// <returns></returns>        
        public long m_lngDayReckoningUnion(string EmpID, string RecDate, string RemarkInfo, int RecType)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngDayReckoningUnion(EmpID, RecDate, RemarkInfo, RecType);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 收款员日结(发票)
        /// <summary>
        /// 收款员日结(发票)
        /// </summary>
        /// <param name="EmpID"></param>
        /// <param name="RecDate"></param>
        /// <param name="RemarkInfo"></param>
        /// <returns></returns>        
        public long m_lngDayReckoning(string EmpID, string RecDate, string RemarkInfo)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngDayReckoning(EmpID, RecDate, RemarkInfo);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 收款员日结(按金)
        /// <summary>
        /// 收款员日结(按金)
        /// </summary>
        /// <param name="EmpID">收款员ID</param>
        /// <param name="RecDate"></param>  
        /// <param name="RemarkInfo"></param>
        /// <returns></returns>        
        public long m_lngDayReckoningPre(string EmpID, string RecDate, string RemarkInfo)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngDayReckoningPre(EmpID, RecDate, RemarkInfo);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 获取收款员日结时间列表
        /// <summary>
        /// 获取收款员日结时间列表
        /// </summary>
        /// <param name="EmpID"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngGetDayReckoningTime(string EmpID, string BeginDate, string EndDate, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                   (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngGetDayReckoningTime(EmpID, BeginDate, EndDate, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region (医保)传送住院收费数据到医保前置机
        /// <summary>
        /// (医保)传送住院收费数据到医保前置机
        /// </summary>
        /// <param name="DSN"></param>
        /// <param name="objYBArr"></param>
        /// <returns></returns>
        public long m_lngSendybdata(string DSN, ArrayList objYBArr)
        {
            //com.digitalwave.iCare.middletier.HIS.clsZyYB objSvc =
            //                                                   (com.digitalwave.iCare.middletier.HIS.clsZyYB)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsZyYB));

            clsZyYB objSvc = new clsZyYB();

            long l = objSvc.m_lngSendybdata(DSN, objYBArr);

            return l;
        }

        /// <summary>
        /// (医保)传送住院收费数据到医保前置机
        /// </summary>
        /// <param name="DSN"></param>
        /// <param name="objYBArr"></param>
        /// <returns></returns>
        public long m_lngSendybdata(string DSN, DataTable dt)
        {
            //com.digitalwave.iCare.middletier.HIS.clsZyYB objSvc =
            //                                             (com.digitalwave.iCare.middletier.HIS.clsZyYB)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsZyYB));

            clsZyYB objSvc = new clsZyYB();

            long l = objSvc.m_lngSendybdata(DSN, dt);

            return l;
        }
        #endregion

        #region (医保)查询传送收费项目是否成功
        /// <summary>
        /// (医保)查询传送收费项目是否成功
        /// </summary>
        /// <param name="DSN"></param>
        /// <param name="Hospcode"></param>
        /// <param name="ZYNo"></param>
        /// <param name="ZYSno"></param>
        /// <returns></returns>
        public bool m_blnCheckSendRes(string DSN, string Hospcode, string ZYNo, string ZYSno)
        {
            //com.digitalwave.iCare.middletier.HIS.clsZyYB objSvc =
            //                                                   (com.digitalwave.iCare.middletier.HIS.clsZyYB)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsZyYB));

            clsZyYB objSvc = new clsZyYB();

            bool b = objSvc.m_blnCheckSendRes(DSN, Hospcode, ZYNo, ZYSno);

            return b;
        }
        #endregion

        #region (医保)传送时HIS事务失败，手工删除传送数据
        /// <summary>
        /// (医保)传送时HIS事务失败，手工删除传送数据
        /// </summary>
        /// <param name="billno"></param>
        /// <returns></returns>
        public long m_lngDelybdata(string DSN, string ZYNo, string ZYSno)
        {
            //com.digitalwave.iCare.middletier.HIS.clsZyYB objSvc =
            //                                              (com.digitalwave.iCare.middletier.HIS.clsZyYB)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsZyYB));

            clsZyYB objSvc = new clsZyYB();

            long l = objSvc.m_lngDelybdata(DSN, ZYNo, ZYSno);

            return l;
        }
        #endregion

        #region (医保)获取医保结算明细
        /// <summary>
        /// (医保)获取医保结算明细
        /// </summary>
        /// <param name="DSN"></param>        
        /// <param name="Hospcode"></param>        
        /// <param name="ZYNo"></param>
        /// <param name="ZYSno"></param>
        /// <param name="YbType">1 普通 2 公务员</param>
        /// <returns></returns>      
        public long m_lngGetybjsmx(string DSN, string Hospcode, string ZYNo, string ZYSno, out DataTable dtRecord, out int YbType)
        {
            //com.digitalwave.iCare.middletier.HIS.clsZyYB objSvc =
            //                                              (com.digitalwave.iCare.middletier.HIS.clsZyYB)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsZyYB));

            clsZyYB objSvc = new clsZyYB();

            long l = objSvc.m_lngGetybjsmx(DSN, Hospcode, ZYNo, ZYSno, out dtRecord, out YbType);

            return l;
        }
        #endregion

        #region (医保试算)发送数据
        /// <summary>
        /// (医保试算)发送数据
        /// </summary>
        /// <param name="HospCode"></param>
        /// <param name="RegID"></param>
        /// <param name="Mode">1 模式一：全部未清项目 2 模式二：指定项目</param>
        /// <returns></returns>        
        public long m_lngBudgetSendData(string HospCode, string RegID, int Mode)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngBudgetSendData(HospCode, RegID, Mode);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region (医保试算)接收数据
        /// <summary>
        /// (医保试算)接收数据
        /// </summary>
        /// <param name="RegID"></param>
        /// <param name="dtMain"></param>
        /// <param name="dtDet"></param>
        /// <returns></returns>        
        public long m_lngBudgetGetData(string RegID, out DataTable dtMain, out DataTable dtDet)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngBudgetGetData(RegID, out dtMain, out dtDet);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region (医保)下载医保前置机数据
        /// <summary>
        /// (医保)下载医保前置机数据
        /// </summary>
        /// <param name="DSN"></param>
        /// <param name="Hospcode"></param>
        /// <param name="ZYNo"></param>
        /// <param name="ZYSno"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngDownloadYBData(string DSN, string Hospcode, string ZYNo, string ZYSno, out DataTable dt)
        {
            //com.digitalwave.iCare.middletier.HIS.clsZyYB objSvc =
            //                                             (com.digitalwave.iCare.middletier.HIS.clsZyYB)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsZyYB));

            clsZyYB objSvc = new clsZyYB();

            long l = objSvc.m_lngDownloadYBData(DSN, Hospcode, ZYNo, ZYSno, out dt);

            return l;
        }
        #endregion

        #region (医保)下载医保前置机数据->生成到本地
        /// <summary>
        /// (医保)下载医保前置机数据->生成到本地
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngDownloadYBData(DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngDownloadYBData(dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region (医保)删除已下载医保前置机数据
        /// <summary>
        /// (医保)删除已下载医保前置机数据
        /// </summary>
        /// <param name="Zyh"></param>
        /// <param name="Zycs"></param>
        /// <returns></returns>        
        public long m_lngDelDownloadYBData(string Zyh, int Zycs)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngDelDownloadYBData(Zyh, Zycs);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region (医保)获取已下载医保前置机数据
        /// <summary>
        /// (医保)获取已下载医保前置机数据
        /// </summary>
        /// <param name="Zyh"></param>
        /// <param name="Zycs"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngGetDownloadYBData(string Zyh, int Zycs, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngGetDownloadYBData(Zyh, Zycs, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion
        #region 医保试算
        /// <summary>
        /// 医保试算
        /// </summary>
        /// <param name="HospCode"></param>
        /// <param name="RegID"></param>
        /// <param name="Zyh"></param>
        /// <param name="Zycs"></param>
        /// <param name="TotalMoney"></param>
        /// <param name="InsuredMoney"></param>
        /// <param name="OutErrMsg"></param>
        /// <returns></returns>        
        public long m_lngYBBudget(string HospCode, string RegID, string Zyh, int Zycs, out decimal TotalMoney, out decimal InsuredMoney, out string OutErrMsg)
        {
            //com.digitalwave.iCare.middletier.HIS.clsZyYB objSvc =
            //                                               (com.digitalwave.iCare.middletier.HIS.clsZyYB)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsZyYB));                                            
            com.digitalwave.iCare.middletier.HIS.clsZyYBSS objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsZyYBSS)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsZyYBSS));
            //clsZyYB objSvc = new clsZyYB();
            long lngRes = objSvc.m_lngYBBudget(HospCode, RegID, Zyh, Zycs, out TotalMoney, out InsuredMoney, out OutErrMsg);
            lngRes = objSvc.m_lngZYSS(HospCode, Zyh, Zycs, out TotalMoney, out InsuredMoney, out OutErrMsg);
            objSvc = null;

            return lngRes;
        }
        #endregion

        #region (茶山医保)生成DBF文件
        /// <summary>
        /// (茶山医保)生成DBF文件
        /// </summary>
        /// <param name="DSN"></param>
        /// <param name="DbfName"></param>
        /// <param name="objYBArr"></param>
        /// <returns></returns>  
        public long m_lngCreateDBF(string DSN, string DbfName, ArrayList objYBArr)
        {
            com.digitalwave.iCare.middletier.HIS.clsChaShan objSvc = new clsChaShan();
            //(com.digitalwave.iCare.middletier.HIS.clsChaShan)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsChaShan));

            long l = objSvc.m_lngCreateDbf(DSN, DbfName, objYBArr);

            return l;
        }
        #endregion

        #region (医保)获取结果
        /// <summary>
        /// (医保)获取结果
        /// </summary>
        /// <param name="DSN"></param>
        /// <param name="DbfName"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngGetResult(string DSN, string DbfName, out DataTable dtRecord)
        {
            com.digitalwave.iCare.middletier.HIS.clsChaShan objSvc = new clsChaShan();
            //(com.digitalwave.iCare.middletier.HIS.clsChaShan)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsChaShan));

            long l = objSvc.m_lngGetResult(DSN, DbfName, out dtRecord);

            return l;
        }
        #endregion

        #region 查找诊疗项目
        /// <summary>
        /// 查找诊疗项目
        /// </summary>
        /// <param name="ID"></param>        
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngFindOrderByID(string ID, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsCommonQuery objSvc =
                                                            (com.digitalwave.iCare.middletier.HIS.clsCommonQuery)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCommonQuery));

            long l = objSvc.m_lngFindOrderByID(ID, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 根据诊疗项目获取收费项目
        /// <summary>
        /// 根据诊疗项目获取收费项目
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="PayTypeID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngGetChargeItemByOrderID(string OrderID, string PayTypeID, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsCommonQuery objSvc =
                                                                (com.digitalwave.iCare.middletier.HIS.clsCommonQuery)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCommonQuery));

            long l = objSvc.m_lngGetChargeItemByOrderID(OrderID, PayTypeID, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 判断诊疗项目(组合)是否允许打折
        /// <summary>
        /// 判断诊疗项目(组合)是否允许打折
        /// </summary>
        /// <param name="OrderID">诊疗项目ID</param>
        /// <param name="InvoCatArr">发票类型数组</param>
        /// <param name="SysType">系统 1 门诊 2 住院</param>
        /// <param name="ItemNums">项目个数</param>
        /// <returns></returns>        
        public bool m_blnCheckOrderDiscount(string OrderID, ArrayList InvoCatArr, int SysType, int ItemNums)
        {
            com.digitalwave.iCare.middletier.HIS.clsCommonQuery objSvc =
                                                                (com.digitalwave.iCare.middletier.HIS.clsCommonQuery)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCommonQuery));

            bool b = objSvc.m_blnCheckOrderDiscount(OrderID, InvoCatArr, SysType, ItemNums);
            objSvc.Dispose();

            return b;
        }
        #endregion

        #region 获取补记帐、直收费用(诊疗项目)主表记录
        /// <summary>
        /// 获取补记帐、直收费用(诊疗项目)主表记录
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngGetOrderDic(string OrderID, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngGetOrderDic(OrderID, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region (医保)更新医保统筹费用
        /// <summary>
        /// (医保)更新医保统筹费用
        /// </summary>
        /// <param name="RegID"></param>
        /// <param name="InsuredSum"></param>
        /// <returns></returns>        
        public long m_lngUpdateInsuredSum(string RegID, decimal InsuredSum)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                 (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngUpdateInsuredSum(RegID, InsuredSum);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 出院结帐则立即腾出床位
        /// <summary>
        /// 出院结帐则立即腾出床位
        /// </summary>
        /// <param name="RegID"></param>
        /// <returns></returns>        
        public long m_lngClearBed(string RegID)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                 (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngClearBed(RegID);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 记录当前收费员使用之发票号
        /// <summary>
        /// 记录当前收费员使用之发票号
        /// </summary>
        /// <param name="OperID"></param>
        /// <param name="InvoNo"></param>
        /// <param name="Type">类型： 1 住院发票 2 押金单 3 门诊发票</param>
        /// <returns></returns>        
        public long m_lngRegOperInvoNO(string OperID, string InvoNo, int Type)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngRegOperInvoNO(OperID, InvoNo, Type);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 获取当前收费员使用之发票号
        /// <summary>
        /// 获取当前收费员使用之发票号
        /// </summary>
        /// <param name="OperID"></param>
        /// <param name="Type">类型： 1 住院发票 2 押金单 3 门诊发票</param>
        /// <param name="InvoNo"></param>
        /// <returns></returns>        
        public long m_lngGetOperInvoNO(string OperID, int Type, out string InvoNo)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngGetOperInvoNO(OperID, Type, out InvoNo);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 检查婴儿费
        /// <summary>
        /// 检查婴儿费
        /// </summary>
        /// <param name="Zyh"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngCheckBaby(string Zyh, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsCommonQuery objSvc =
                                                                (com.digitalwave.iCare.middletier.HIS.clsCommonQuery)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCommonQuery));

            long l = objSvc.m_lngCheckBaby(Zyh, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 补记帐退费
        /// <summary>
        /// 补记帐退费
        /// </summary>
        /// <param name="ChargeIDArr"></param>
        /// <param name="EmpID"></param>
        /// <returns></returns>        
        public long m_lngPatchRefundment(ArrayList ChargeIDArr, string EmpID)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngPatchRefundment(ChargeIDArr, EmpID);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 修改备注信息
        /// <summary>
        /// 修改备注信息
        /// </summary>
        /// <param name="EmpID"></param>
        /// <param name="RecDate"></param>
        /// <param name="RemarkInfo"></param>
        /// <returns></returns>        
        public long m_lngUpdateDayRecRemark(string EmpID, string RecDate, string RemarkInfo)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngUpdateDayRecRemark(EmpID, RecDate, RemarkInfo);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 获取不同费别的费用明细
        /// <summary>
        /// 获取不同费别的费用明细
        /// </summary>
        /// <param name="RegID"></param>
        /// <param name="PayTypeID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngGetPatientFeeDetByPayType(string RegID, string PayTypeID, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngGetPatientFeeDetByPayType(RegID, PayTypeID, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 费用明细对应之诊疗项目
        /// <summary>
        /// 费用明细对应之诊疗项目
        /// </summary>
        /// <param name="RegID"></param>
        /// <param name="ActiveType">生效类型{1=其它;2=补记帐;3=确认记帐;4=确认收费;5=直接收费;888=费用状态分类;999=全部}</param>
        /// <param name="Pstatus"></param>
        /// <param name="AreaID"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngGetFeeDiagItem(string RegID, int ActiveType, string Pstatus, string AreaID, string BeginDate, string EndDate, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngGetFeeDiagItem(RegID, ActiveType, Pstatus, AreaID, BeginDate, EndDate, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 根据费用明细ID查找费用信息
        /// <summary>
        /// 根据费用明细ID查找费用信息
        /// </summary>
        /// <param name="DiagArr"></param>
        /// <param name="dtNormal"></param>
        /// <param name="dtRefundment"></param>
        /// <returns></returns>        
        public long m_lngGetFeeItemByActiveType(ArrayList DiagArr, out DataTable dtNormal, out DataTable dtRefundment)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngGetFeeItemByActiveType(DiagArr, out dtNormal, out dtRefundment);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 按科室类型获取病人费用分类
        /// <summary>
        /// 按科室类型获取病人费用分类
        /// </summary>
        /// <param name="RegID"></param>
        /// <param name="DeptClass">1 执行科室 2 开单科室 3 所在病区</param>
        /// <param name="Status">0 未呆帐结算 1 已呆帐结算</param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngGetFeeCatByDeptClass(string RegID, int DeptClass, int Status, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngGetFeeCatByDeptClass(RegID, DeptClass, Status, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 按科室类型获取病人费用分类母婴合并结算使用 by yibing.zheng 09-07-04

        /// <summary>
        /// 按科室类型获取病人费用分类母婴合并结算使用
        /// </summary>
        /// <param name="RegID"></param>
        /// <param name="DeptClass">1 执行科室 2 开单科室 3 所在病区</param>
        /// <param name="Status">0 未呆帐结算 1 已呆帐结算</param>
        /// <param name="dt"></param>
        /// <returns></returns>

        public long m_lngGetFeeCatByDeptClassForMortherBaby(string RegID, int DeptClass, int Status, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                                       (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngGetFeeCatByDeptClassForMortherBaby(RegID, DeptClass, Status, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 呆帐结算
        /// <summary>
        /// 呆帐结算
        /// </summary>
        /// <param name="Charge_VO"></param>
        /// <param name="ChargeCatArr"></param>
        /// <param name="FactTotalMoney">实际未结、未清总金额</param>
        /// <param name="FactPreMoney">实际分摊总金额</param>
        /// <param name="DiffValDeptID">差值项科室ID</param>
        /// <param name="DiffValCatID">差值项核算分类ID</param>
        /// <param name="IsHavePrepayMoney">是否有预交金 (true 有 false 无)</param>
        /// <param name="ChargeNo"></param>
        /// <returns></returns>        
        public long m_lngBadCharge(clsBihCharge_VO Charge_VO, ArrayList ChargeCatArr, clsBihInvoice_VO Invoice_VO, ArrayList InvoCatArr, ArrayList PaymentArr, decimal FactTotalMoney, decimal FactPreMoney, string DiffValDeptID, string DiffValCatID, bool IsHavePrepayMoney, out string ChargeNo)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngBadCharge(Charge_VO, ChargeCatArr, Invoice_VO, InvoCatArr, PaymentArr, FactTotalMoney, FactPreMoney, DiffValDeptID, DiffValCatID, IsHavePrepayMoney, out ChargeNo);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 获取呆帐病人未清费用
        /// <summary>
        /// 获取呆帐病人未清费用
        /// </summary>
        /// <param name="RegID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngGetBadChargeFeeInfo(string RegID, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngGetBadChargeFeeInfo(RegID, out dt);
            objSvc.Dispose();

            return l;
        }

        /// <summary>
        /// 获取呆帐病人未清费用(母婴合并结算合用)
        /// </summary>
        /// <param name="RegID">病人ID</param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngGetBadChargeFeeInfoMotherBaby(string RegID, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                          (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long lngRes = objSvc.m_lngGetBadChargeFeeInfoMotherBaby(RegID, out dt);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion

        #region 结帐
        /// <summary>
        /// 结帐
        /// </summary>
        /// <param name="Charge_VO"></param>
        /// <param name="ChargeNo"></param>
        /// <returns></returns>        
        public long m_lngReckoning(clsBihCharge_VO Charge_VO, out string ChargeNo)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngReckoning(Charge_VO, out ChargeNo);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 获取记帐所有处方ID
        /// <summary>
        /// 获取记帐所有处方ID
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngMzGetAcctRecipeID(string BeginDate, string EndDate, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngMzGetAcctRecipeID(BeginDate, EndDate, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 根据已收费处方ID获取核算分类
        /// <summary>
        /// 根据已收费处方ID获取核算分类
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngMzGetRecipeCat(string RecipeID, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngMzGetRecipeCat(RecipeID, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 根据SEQID获取核算分类
        /// <summary>
        /// 根据SEQID获取核算分类
        /// </summary>
        /// <param name="SeqID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngMzGetChargeCat(string SeqID, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngMzGetChargeCat(SeqID, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 根据SEQID、CatID更新核算分类
        /// <summary>
        /// 根据SEQID、CatID更新核算分类
        /// </summary>
        /// <param name="SeqID"></param>
        /// <param name="CatIDArr"></param>
        /// <param name="CatSumArr"></param>
        /// <returns></returns>        
        public long m_lngMzUpdateChargeCat(string SeqID, ArrayList CatIDArr, ArrayList CatSumArr, string PStatus)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngMzUpdateChargeCat(SeqID, CatIDArr, CatSumArr, PStatus);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 根据处方ID获取SEQID列表
        /// <summary>
        /// 根据处方ID获取SEQID列表
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngMzGetSeqIDList(string RecipeID, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngMzGetSeqIDList(RecipeID, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region <门诊>发票信息
        /// <summary>
        /// (门诊)发票信息 
        /// </summary>
        /// <param name="ChargeNo"></param>
        /// <param name="dtMain"></param>
        /// <param name="dtDet"></param>
        /// <param name="dtPayMode"></param>
        /// <returns></returns>        
        public long m_lngGetOPInvoiceByChargeNo(string ChargeNo, out DataTable dtMain, out DataTable dtDet, out DataTable dtPayMode)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                          (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngGetOPInvoiceByChargeNo(ChargeNo, out dtMain, out dtDet, out dtPayMode);
            objSvc.Dispose();

            return l;
        }

        /// <summary>
        /// 门诊发票信息 
        /// </summary>
        /// <param name="InvoNo"></param>
        /// <param name="dtMain"></param>
        /// <param name="dtDet"></param>
        /// <param name="dtPayMode"></param>
        /// <returns></returns> 
        public long m_lngGetOPInvoiceByInvoNo(string InvoNo, out DataTable dtMain, out DataTable dtDet, out DataTable dtPayMode)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                          (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngGetOPInvoiceByInvoNo(InvoNo, out dtMain, out dtDet, out dtPayMode);
            objSvc.Dispose();

            return l;
        }

        /// <summary>
        /// 门诊发票信息(for 退票)
        /// </summary>
        /// <param name="mode">模式(保留标识符) 0-退票</param>
        /// <param name="InvoNo"></param>
        /// <param name="dtMain"></param>
        /// <param name="dtDet"></param>
        /// <param name="dtPayMode"></param>
        /// <returns></returns>
        public long m_lngGetOPInvoiceByInvoNo(int mode, string InvoNo, out DataTable dtMain, out DataTable dtDet, out DataTable dtPayMode)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                          (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngGetOPInvoiceByInvoNo(mode, InvoNo, out dtMain, out dtDet, out dtPayMode);
            return l;
        }
        #endregion

        #region 江门台山医保结算
        /// <summary>
        /// 插入费用明细
        /// </summary>
        /// <param name="p_strlsh0"></param>
        /// <param name="p_inpatientid"></param>
        /// <returns></returns>
        public long m_lngInsertRegisterCharge(string p_strlsh0, string p_inpatientid)
        {
            clsZyYB objSvc = (clsZyYB)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsZyYB));
            return objSvc.m_lngInsertRegisterCharge(p_strlsh0, p_inpatientid);
        }
        /// <summary>
        /// 插入病人信息
        /// </summary>
        /// <param name="p_strlsh0"></param>
        /// <param name="p_inpatientid"></param>
        /// <returns></returns>
        public long m_lngInsertRegister(string p_strlsh0, string p_inpatientid)
        {
            clsZyYB objSvc = (clsZyYB)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsZyYB));
            return objSvc.m_lngInsertRegister(p_strlsh0, p_inpatientid);
        }
        /// <summary>
        /// 获取医保支付的金额
        /// </summary>
        /// <param name="p_strlsh0"></param>
        /// <param name="p_strYBpay"></param>
        /// <returns></returns>
        public long m_lngGetYBpay(string p_strlsh0, out string p_strMedno, out string p_strYBpay)
        {
            clsZyYB objSvc = (clsZyYB)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsZyYB));
            return objSvc.m_lngGetYBpay(p_strlsh0, out p_strMedno, out p_strYBpay);
        }
        /// <summary>
        /// 删除旧HIS上传信息
        /// </summary>
        /// <param name="p_registerid"></param>
        public long m_lngDelYBInfo(string p_strlsh0)
        {
            clsZyYB objSvc = (clsZyYB)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsZyYB));
            return objSvc.m_lngDelYBInfo(p_strlsh0);
        }
        #endregion

        #region 更改病人费用核对状态
        /// <summary>
        /// 更改病人费用核对状态
        /// </summary>
        /// <param name="RegisterID"></param>
        /// <param name="CheckStatus"></param>
        public long m_lngUpdatePatientChargeCheckStatus(string RegisterID, string CheckStatus)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngUpdatePatientChargeCheckStatus(RegisterID, CheckStatus);
            objSvc.Dispose();

            return l;
        }
        #endregion


        #region 调出婴儿未结费用
        /// <summary>
        /// 调出婴儿未结费用
        /// </summary>
        /// <param name="p_strRegisterId">婴儿ID</param>
        /// <param name="p_dtbResult">返回结果</param>
        /// <returns></returns>
        public long m_lngCheckBabyNoPayCharge(string p_strRegisterId, out DataTable p_dtbResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                                (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long lngRes = objSvc.m_lngCheckBabyNoPayCharge(p_strRegisterId, out p_dtbResult);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion

        #region 根据母亲ID获取婴儿信息

        /// <summary>
        /// 根据母亲ID获取婴儿信息
        /// </summary>
        /// <param name="p_strRegisterId"></param>
        /// <param name="p_dtbBabyInfo"></param>
        /// <returns></returns>
        public long m_lngGetBabyRegisterId(string p_strRegisterId, out DataTable p_dtbBabyInfo)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                                (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long lngRes = objSvc.m_lngGetBabyRegisterId(p_strRegisterId, out p_dtbBabyInfo);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion

        #region 获取科室列表
        /// <summary>
        /// 获取科室列表
        /// </summary>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long m_lngGetDepts(out DataTable dtbResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));
            long l = objSvc.m_lngGetDepts(out dtbResult);
            objSvc.Dispose();
            return l;
        }
        #endregion

        #region 茶山医保上传 适应症
        public long m_lngCheckChangeSFLB(Dictionary<string, int> p_gdicItemIDs, out Dictionary<string, string> p_gdicItemIDResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsCommonQuery objSvc =
                                                 (com.digitalwave.iCare.middletier.HIS.clsCommonQuery)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCommonQuery));

            long l = objSvc.m_lngCheckChangeSFLB(p_gdicItemIDs, out p_gdicItemIDResult);
            objSvc.Dispose();

            return l;
        }


        public long m_lngGetSFLB_ForZjwsy(out DataTable dtResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsCommonQuery objSvc =
                                                 (com.digitalwave.iCare.middletier.HIS.clsCommonQuery)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCommonQuery));

            long l = objSvc.m_lngGetSFLB_ForZjwsy(out dtResult);
            objSvc.Dispose();

            return l;
        }

        public long m_lngGetPatientChargeSFLB(List<string> m_glstPChargeID,
                                              out Dictionary<string, string> p_gdicItemIDResult,
                                              out Dictionary<string, decimal> p_gdicPatchAmount,
                                              out Dictionary<string, List<string>> p_gdicPatchList)
        {
            com.digitalwave.iCare.middletier.HIS.clsCommonQuery objSvc =
                                     (com.digitalwave.iCare.middletier.HIS.clsCommonQuery)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCommonQuery));

            long l = objSvc.m_lngGetPatientChargeSFLB(m_glstPChargeID, out p_gdicItemIDResult, out p_gdicPatchAmount, out p_gdicPatchList);
            objSvc.Dispose();

            return l;
        }



        public long m_lngSetChargeSFLB_Zjwsy(List<clsSFLB_log> m_glstSFLB, string p_strEmpID, string p_strEmpName)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                 (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            long l = objSvc.m_lngSetChargeSFLB_Zjwsy(m_glstSFLB, p_strEmpID, p_strEmpName);
            objSvc.Dispose();

            return l;
        }


        public long m_lngGetPatientPayTypeSFLBBH(string p_strPayType, out string p_strPayNo)
        {
            com.digitalwave.iCare.middletier.HIS.clsCommonQuery objSvc =
                                                 (com.digitalwave.iCare.middletier.HIS.clsCommonQuery)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCommonQuery));

            long l = objSvc.m_lngGetPatientPayTypeSFLBBH(p_strPayType, out p_strPayNo);
            objSvc.Dispose();

            return l;
        }

        #endregion

        #region 项目适应症
        ///// <summary>
        ///// 项目适应症
        ///// </summary>
        ///// <param name="strRegID"></param>
        ///// <param name="dtResult"></param>
        ///// <returns></returns>
        //public long m_lngGetItemShiying(string strRegID, out DataTable dtResult)
        //{
        //    com.digitalwave.iCare.middletier.HIS.clsCommonQuery objSvc =
        //                                                    (com.digitalwave.iCare.middletier.HIS.clsCommonQuery)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCommonQuery));

        //    long l = objSvc.m_lngGetItemShiying(strRegID, out dtResult);
        //    objSvc.Dispose();

        //    return l;
        //}
        #endregion

        #region 通过流水号查询手术或麻醉的补充记账记录
        /// <summary>
        /// 通过流水号查询手术或麻醉的补充记账记录
        /// </summary>
        /// <param name="p_strIpno"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        public long m_lngQueryOpExtraChargeByRgno(string p_strIpno, out DataTable p_dtResult)
        {
            long lngRes = 0;
            p_dtResult = null;

            #region 中间件操作
            clsCommonQuery objServ = null;
            try
            {
                objServ = (clsCommonQuery)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsCommonQuery));
                lngRes = objServ.m_lngQueryOpExtraChargeByRgno(p_strIpno, out p_dtResult);
            }
            catch (Exception exp)
            {
                Utility.clsLogText objLogger = new Utility.clsLogText();
                objLogger.LogError("连接中间件操作异常，" + exp.Message);
            }
            finally
            {
                if (objServ != null)
                {
                    objServ.Dispose();
                    objServ = null;
                }
            }
            #endregion
            return lngRes;
        }
        #endregion

        #region 通过流水号查询手术和麻醉信息
        /// <summary>
        /// 通过流水号查询手术和麻醉信息
        /// </summary>
        /// <param name="p_strIpno"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        public long m_lngQuerySMDetailByRgno(string p_strRgno, out DataTable p_dtResult)
        {
            long lngRes = 0;
            p_dtResult = null;

            #region 中间件操作
            clsCommonQuery objServ = null;
            try
            {
                objServ = (clsCommonQuery)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsCommonQuery));
                lngRes = objServ.m_lngQuerySMDetailByRgno(p_strRgno, out p_dtResult);
            }
            catch (Exception exp)
            {
                Utility.clsLogText objLogger = new Utility.clsLogText();
                objLogger.LogError("连接中间件操作异常，" + exp.Message);
            }
            finally
            {
                if (objServ != null)
                {
                    objServ.Dispose();
                    objServ = null;
                }
            }
            #endregion
            return lngRes;
        }
        #endregion

        #region 更新手术申请单修改表
        /// <summary>
        /// 更新手术申请单修改表
        /// </summary>
        /// <param name="p_strRgno"></param>
        /// <param name="p_strOpreationName"></param>
        /// <param name="p_strANAName"></param>
        /// <param name="p_strANADate"></param>
        /// <param name="p_strEmployID"></param>
        /// <param name="p_strEmployName"></param>
        /// <returns></returns>
        public long m_lngUpdateRequisitionMR(string p_strRgno, string p_strOpreationName, string p_strANAName, string p_strANADate, string p_strEmployID, string p_strEmployName)
        {
            long lngRes = 0;

            #region 中间件操作
            clsCommonQuery objServ = null;
            try
            {
                objServ = (clsCommonQuery)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsCommonQuery));
                lngRes = objServ.m_lngUpdateRequisitionMR( p_strRgno, p_strOpreationName, p_strANAName, p_strANADate, p_strEmployID, p_strEmployName);
            }
            catch (Exception exp)
            {
                Utility.clsLogText objLogger = new Utility.clsLogText();
                objLogger.LogError("连接中间件操作异常，" + exp.Message);
            }
            finally
            {
                if (objServ != null)
                {
                    objServ.Dispose();
                    objServ = null;
                }
            }
            #endregion
            return lngRes;
        }
        #endregion

        #region 检测社保病人社保结算没有成功就不能做HIS结算
        /// <summary>
        /// 检测社保病人社保结算没有成功就不能做HIS结算
        /// </summary>
        /// <param name="p_registerID"></param>
        /// <returns></returns>
        public bool m_blnCheckYBChargeSuccessFull(string p_registerID)
        {
            bool blnSucc = false;

            #region 中间件操作
            clsCharge objServ = null;
            try
            {
                objServ = (clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsCharge));
                blnSucc = objServ.m_blnCheckYBChargeSuccessFull(p_registerID);
            }
            catch (Exception exp)
            {
                Utility.clsLogText objLogger = new Utility.clsLogText();
                objLogger.LogError("连接中间件操作异常，" + exp.Message);
            }
            finally
            {
                if (objServ != null)
                {
                    objServ.Dispose();
                    objServ = null;
                }
            }
            #endregion
            return blnSucc;
        }
        #endregion
    }
}
