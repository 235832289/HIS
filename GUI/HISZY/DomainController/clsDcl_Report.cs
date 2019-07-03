using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 报告生成Domain类
    /// </summary>
    public class clsDcl_Report : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public clsDcl_Report()
        {
        }
        #endregion

        #region 根据报表编号获取住院核算分类
        /// <summary>
        /// 根据报表编号获取住院核算分类
        /// </summary>
        /// <param name="RptID">自定义报表ID</param>
        /// <param name="Flag">3 住院核算分类 4 住院发票分类</param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngGetCatIDByRptID(string RptID, int Flag, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                             (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngGetCatIDByRptID(RptID, Flag, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 每日清单
        /// <summary>
        /// 每日清单(主信息)
        /// </summary>
        /// <param name="AreaID">病区ID</param>
        /// <param name="RegID">住院登记流水ID</param>
        /// <param name="BillDate">清单日期</param> 
        /// <param name="objEveryDayBill"></param> 
        /// <returns></returns>
        public long m_lngRptEveryDayBill(string RegID, string BillDate, out clsBihEveryDayBill_VO objEveryDayBill)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                 (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngRptEveryDayBill(RegID, BillDate, out objEveryDayBill);
            objSvc.Dispose();

            return l;
        }

        /// <summary>
        /// 每日清单(分类费用)
        /// </summary> 
        /// <param name="ID">1-病区ID 2-住院登记流水ID 3-住院号</param>        
        /// <param name="BillDate">清单日期</param>
        /// <param name="Type">类型：1 按病区 2 按床位 3 按住院号</param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngRptEveryDayBillFee(string ID, string BillDate, int Type, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                 (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngRptEveryDayBillFee(ID, BillDate, Type, out dt);
            objSvc.Dispose();

            return l;
        }

        /// <summary>
        /// 每日清单 ----按类别
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="BillDate"></param>
        /// <param name="Type"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngRptEveryDayBillCate(string ID, string BillDate, int Type, int ItemCodeType, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                            (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngRptEveryDayBillCate(ID, BillDate, Type, ItemCodeType, out dt);
            objSvc.Dispose();

            return l;
        }

        /// <summary>
        /// 每日清单(费用明细)
        /// </summary>
        /// <param name="ID">1-病区ID 2-住院登记流水ID 3-住院号</param>        
        /// <param name="BillDate">清单日期</param>
        /// <param name="Type">类型：1 按病区 2 按床位 3 按住院号</param>
        /// <param name="dt"></param>
        /// <param name="ItemCodeType">项目代码使用类型 0 门诊收费编码 1 项目代码</param>
        /// <returns></returns>
        public long m_lngRptEveryDayBillEntry(string ID, string BillDate, int Type, int ItemCodeType, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                 (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngRptEveryDayBillEntry(ID, BillDate, Type, ItemCodeType, out dt);
            objSvc.Dispose();

            return l;
        }

        public long m_lngRptGetBednoByAreaid(string p_strAreaid, out DataTable dtResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                     (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngRptGetBednoByAreaid(p_strAreaid, out dtResult);
            objSvc.Dispose();

            return l;
        }

        #endregion

        #region 全院缴款(发票)分类报表
        /// <summary>
        /// 全院缴款(发票)分类报表
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="RepType">0 缴款分类 1 发票分类</param>
        /// <param name="StatType">0 汇总 1 汇总＋分类</param>
        /// <param name="dtMain"></param>
        /// <param name="dtDet"></param>
        /// <returns></returns>        
        public long m_lngRptIncomeClass(string BeginDate, string EndDate, int RepType, int StatType, out DataTable dtMain, out DataTable dtDet)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngRptIncomeClass(BeginDate, EndDate, RepType, StatType, out dtMain, out dtDet);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 收款员缴款报表
        /// <summary>
        /// 收款员缴款报表
        /// </summary>
        /// <param name="EmpID">收费员ID</param>
        /// <param name="IsRec">是否已结帐</param>
        /// <param name="RecTime">结帐时间</param>
        /// <param name="dtCharge"></param>
        /// <param name="dtInvoice"></param>
        /// <param name="dtPayment"></param>
        /// <returns></returns>        
        public long m_lngRptReckoningEmp(string EmpID, bool IsRec, string RecTime, out DataTable dtCharge, out DataTable dtInvoice, out DataTable dtPayment, out DataTable dtPrepayChargeNo, out string RemarkInfo)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                         (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngRptReckoningEmp(EmpID, IsRec, RecTime, out dtCharge, out dtInvoice, out dtPayment, out dtPrepayChargeNo, out RemarkInfo);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 收款员缴款报表(按金)
        /// <summary>
        /// 收款员缴款报表(按金)
        /// </summary>
        /// <param name="EmpID">收费员ID</param>
        /// <param name="IsRec">是否已结帐</param>
        /// <param name="RecTime">结帐时间</param>
        /// <param name="dtPrepay"></param>
        /// <param name="dtPrepayRepNo"></param>
        /// <param name="RemarkInfo"></param>
        /// <returns></returns>        
        public long m_lngRptReckoningEmpPre(string EmpID, bool IsRec, string RecTime, out DataTable dtPrepay, out DataTable dtPrepayRepNo, out string RemarkInfo)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngRptReckoningEmpPre(EmpID, IsRec, RecTime, out dtPrepay, out dtPrepayRepNo, out RemarkInfo);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 收费处缴款报表
        /// <summary>
        /// 收费处缴款报表
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="dtCharge"></param>
        /// <param name="dtPayment"></param>
        /// <param name="dtRemarkInfo"></param>
        /// <returns></returns>        
        public long m_lngRptReckoningDept(string BeginDate, string EndDate, out DataTable dtCharge, out DataTable dtPayment, out DataTable dtRemarkInfo, out DataTable dtChargeno)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                        (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngRptReckoningDept(BeginDate, EndDate, out dtCharge, out dtPayment, out dtRemarkInfo, out dtChargeno);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 发票明细报表
        /// <summary>
        /// 发票明细报表
        /// </summary>
        /// <param name="InvoiceNO">发票号</param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngRptInvoiceEntry(string InvoiceNO, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                        (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngRptInvoiceEntry(InvoiceNO, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 获取住院月发票统计数据
        /// <summary>
        /// 获取住院月发票统计数据
        /// </summary>
        /// <param name="p_dtbResult"></param>
        /// <returns></returns>
        public long m_lngGetBIHInvoiceStatData(string p_opratorId, string p_beginDate, string p_endDate, out DataTable p_dtbStat)
        {
            long lngRes = 0;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));
            lngRes = objSvc.m_lngGetBIHInvoiceStatData(p_objPrincipal, p_opratorId, p_beginDate, p_endDate, out p_dtbStat);
            return lngRes;
        }

        /// <summary>
        /// 获取住院发票重打数据
        /// </summary>
        /// <param name="p_strOperatorId"></param>
        /// <param name="p_strStartDate"></param>
        /// <param name="p_strEndDate"></param>
        /// <param name="p_dtbRePrint"></param>
        /// <returns></returns>
        public long m_lngGetBillRePrintData(string p_strOperatorId,
                                            string p_strStartDate,
                                            string p_strEndDate,
                                            out DataTable p_dtbRePrint)
        {
            long lngRes = 0;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));
            lngRes = objSvc.m_lngGetBIHBillReprintByDate(p_objPrincipal, p_strOperatorId, p_strStartDate, p_strEndDate, out p_dtbRePrint);
            return lngRes;
        }

        #region 获得所有结帐员数据
        public long m_lngGetRecEmp(out DataTable p_dtbRecEmp)
        {
            long lngRes = 0;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));
            lngRes = objSvc.m_lngGetRecEmp(p_objPrincipal, out p_dtbRecEmp);
            return lngRes;
        }
        #endregion

        #endregion //获取挂号发票统计数据

        #region 实收明细日志(发票明细)
        /// <summary>
        /// 实收明细日志(发票明细)
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="OperCode"></param>
        /// <param name="DeptIDArr"></param>
        /// <param name="dtInvoice"></param>
        /// <param name="dtPayment"></param>
        /// <returns></returns>        
        public long m_lngRptInvoiceSum(string BeginDate, string EndDate, string OperCode, ArrayList DeptIDArr, out DataTable dtInvoice, out DataTable dtPayment)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                        (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngRptInvoiceSum(BeginDate, EndDate, OperCode, DeptIDArr, out dtInvoice, out dtPayment);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 实收明细日志(退票)
        /// <summary>
        /// 实收明细日志(退票)
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="OperCode"></param>
        /// <param name="DeptIDArr"></param>
        /// <param name="dtInvoice"></param>
        /// <param name="dtPayment"></param>
        /// <returns></returns>        
        public long m_lngRptInvoiceRefundment(string BeginDate, string EndDate, string OperCode, ArrayList DeptIDArr, out DataTable dtInvoice, out DataTable dtPayment)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                                    (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngRptInvoiceRefundment(BeginDate, EndDate, OperCode, DeptIDArr, out dtInvoice, out dtPayment);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 科室实收报表
        /// <summary>
        /// 科室实收报表
        /// </summary>
        /// <param name="Type">1 开单科室实收 2 执行科室实收</param>
        /// <param name="RptID"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="DeptIDArr"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngRptDeptIncome(int Type, string RptID, string BeginDate, string EndDate, ArrayList DeptIDArr, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                        (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngRptDeptIncome(Type, RptID, BeginDate, EndDate, DeptIDArr, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 医保结算明细报表
        /// <summary>
        /// 医保结算明细报表
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="DeptIDArr"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngRptYBEntry(string BeginDate, string EndDate, ArrayList DeptIDArr, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                        (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngRptYBEntry(BeginDate, EndDate, DeptIDArr, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 已清预交金明细报表
        /// <summary>
        /// 已清预交金明细报表
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngRptPrePayClear(string BeginDate, string EndDate, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                                    (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngRptPrePayClear(BeginDate, EndDate, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 科室实收明细报表
        /// <summary>
        /// 科室实收明细报表
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="DeptIDArr"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngRptDeptIncomeEntry(string BeginDate, string EndDate, ArrayList DeptIDArr, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                        (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngRptDeptIncomeEntry(BeginDate, EndDate, DeptIDArr, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 补记账日志报表
        /// <summary>
        /// 补记账日志报表
        /// </summary>
        /// <param name="rptType"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="DeptIDArr"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngRptLogBuShou(int rptType, string operCode, string BeginDate, string EndDate, ArrayList DeptIDArr, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                        (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngRptLogBuShou(rptType, operCode, BeginDate, EndDate, DeptIDArr, out dt);
            objSvc.Dispose();

            return l;
        }

        #endregion

        #region 出院结账日志报表
        /// <summary>
        /// 出院结账日志报表
        /// </summary>
        /// <param name="OperCode"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="DeptIDArr"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngRptLogSettleAccount(string OperCode, string BeginDate, string EndDate, ArrayList DeptIDArr, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                        (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngRptLogSettleAccount(OperCode, BeginDate, EndDate, DeptIDArr, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 项目统计发生明细报表
        /// <summary>
        /// 项目统计发生明细报表
        /// </summary>
        /// <param name="CodeNo"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="DeptIDArr"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngRptItemDetailStat(string CodeNo, string BeginDate, string EndDate, ArrayList DeptIDArr, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                        (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngRptItemDetailStat(CodeNo, BeginDate, EndDate, DeptIDArr, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 药品消报表(按发生)
        /// <summary>
        /// 药品消报表(按发生)
        /// </summary>
        /// <param name="CodeNo"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="DeptIDArr"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngRptDragUsedStat(string CodeNo, string BeginDate, string EndDate, ArrayList DeptIDArr, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                        (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngRptDragUsedStat(CodeNo, BeginDate, EndDate, DeptIDArr, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 顺德门诊普通医保、住院医保费用明细统计
        /// <summary>
        /// 顺德门诊普通医保、住院医保费用明细统计
        /// </summary>
        /// <param name="Type">1 门诊 2 住院</param>
        /// <param name="NO"></param>     
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngRptSDYBFeeDetail(int Type, string NO, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngSDYBFeeDetail(Type, NO, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 普通门诊医保、住院医保
        /// <summary>
        /// 普通门诊医保、住院医保
        /// </summary>
        /// <param name="DSN"></param>
        /// <param name="NO"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngSDZYYB(string DSN, string NO, DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsLunJiao objSvc =
                                                            (com.digitalwave.iCare.middletier.HIS.clsLunJiao)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsLunJiao));

            return objSvc.m_lngSDZYYB(DSN, NO, dt);
        }
        #endregion

        #region 更新住院号
        /// <summary>
        /// 更新住院号
        /// </summary>
        /// <param name="DSN"></param>
        /// <param name="OldNo"></param>
        /// <param name="NewNo"></param>
        /// <returns></returns>
        public long m_lngSDYBModifyZyh(string DSN, string OldNo, string NewNo)
        {
            com.digitalwave.iCare.middletier.HIS.clsLunJiao objSvc =
                                                            (com.digitalwave.iCare.middletier.HIS.clsLunJiao)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsLunJiao));

            return objSvc.m_lngModifyZyh(DSN, OldNo, NewNo);
        }
        #endregion

        #region 入院登记新增病人记录
        /// <summary>
        /// 入院登记新增病人记录
        /// </summary>
        /// <param name="DSN"></param>
        /// <param name="Patient_VO"></param>
        /// <param name="Register_VO"></param>
        /// <returns></returns>
        public long m_lngSDYBBihRegister(string DSN, clsPatient_VO Patient_VO, clsT_Opr_Bih_Register_VO Register_VO)
        {
            com.digitalwave.iCare.middletier.HIS.clsLunJiao objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsLunJiao)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsLunJiao));

            return objSvc.m_lngBihRegister(DSN, Patient_VO, Register_VO);
        }
        #endregion

        #region 住院医生绩效统计报表
        /// <summary>
        /// 住院医生绩效统计报表
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="DoctIDArr"></param>
        /// <param name="MedCatArr"></param>
        /// <param name="dtDoct"></param>
        /// <param name="dtDept"></param>
        /// <param name="dtPersonNums"></param>
        /// <param name="dtBedDays"></param>
        /// <param name="dtFeeSum"></param>
        /// <param name="dtMedSum"></param>
        /// <param name="dtNonMedSum"></param>
        /// <returns></returns>        
        public long m_lngRptDoctorPerformance(string BeginDate, string EndDate, string DoctIDArr, string MedCatArr, int FeeType, out DataTable dtDoct, out DataTable dtDept,
                                              out DataTable dtPersonNums, out DataTable dtBedDays, out DataTable dtFeeSum, out DataTable dtMedSum, out DataTable dtNonMedSum)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngRptDoctorPerformance(BeginDate, EndDate, DoctIDArr, MedCatArr, FeeType, out dtDoct, out dtDept, out dtPersonNums, out dtBedDays, out dtFeeSum, out dtMedSum, out dtNonMedSum);
            objSvc.Dispose();

            return l;
        }

        /// <summary>
        /// 1、基本资料
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="DoctIDArr"></param>
        /// <param name="dtDoct"></param>
        /// <returns></returns>
        public long m_lngRptDoctorPerformance_Doct(string BeginDate, string EndDate, string DoctIDArr, int FeeType, out DataTable dtDoct)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngRptDoctorPerformance_Doct(BeginDate, EndDate, DoctIDArr, FeeType, out dtDoct);
            objSvc.Dispose();

            return l;
        }

        /// <summary>
        /// 2、默认科室
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="DoctIDArr"></param>
        /// <param name="dtDept"></param>
        /// <returns></returns>
        public long m_lngRptDoctorPerformance_Dept(string BeginDate, string EndDate, string DoctIDArr, out DataTable dtDept)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngRptDoctorPerformance_Dept(BeginDate, EndDate, DoctIDArr, out dtDept);
            objSvc.Dispose();

            return l;
        }

        /// <summary>
        /// 3、收住人次
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="DoctIDArr"></param>
        /// <param name="dtPersonNums"></param>
        /// <returns></returns>
        public long m_lngRptDoctorPerformance_PersonNums(string BeginDate, string EndDate, string DoctIDArr, out DataTable dtPersonNums)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngRptDoctorPerformance_PersonNums(BeginDate, EndDate, DoctIDArr, out dtPersonNums);
            objSvc.Dispose();

            return l;
        }

        /// <summary>
        /// 4、出院人次 占床总日数
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="DoctIDArr"></param>
        /// <param name="dtBedDays"></param>
        /// <returns></returns>
        public long m_lngRptDoctorPerformance_BedDays(string BeginDate, string EndDate, string DoctIDArr, out DataTable dtBedDays)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngRptDoctorPerformance_BedDays(BeginDate, EndDate, DoctIDArr, out dtBedDays);
            objSvc.Dispose();

            return l;
        }

        /// <summary>
        /// 5、出院者(含预出院)总费用
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="DoctIDArr"></param>
        /// <param name="dtFeeSum"></param>
        /// <returns></returns>
        public long m_lngRptDoctorPerformance_FeeSum(string BeginDate, string EndDate, string DoctIDArr, int FeeType, out DataTable dtFeeSum)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngRptDoctorPerformance_FeeSum(BeginDate, EndDate, DoctIDArr, FeeType, out dtFeeSum);
            objSvc.Dispose();

            return l;
        }

        /// <summary>
        /// 6、出院者(含预出院)药费
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="DoctIDArr"></param>
        /// <param name="MedCatArr"></param>
        /// <param name="dtMedSum"></param>
        /// <returns></returns>
        public long m_lngRptDoctorPerformance_MedSum(string BeginDate, string EndDate, string DoctIDArr, string MedCatArr, int FeeType, out DataTable dtMedSum)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngRptDoctorPerformance_MedSum(BeginDate, EndDate, DoctIDArr, MedCatArr, FeeType, out dtMedSum);
            objSvc.Dispose();

            return l;
        }

        /// <summary>
        /// 7、出院者(含预出院)非药费
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="DoctIDArr"></param>
        /// <param name="MedCatArr"></param>
        /// <param name="dtNonMedSum"></param>
        /// <returns></returns>
        public long m_lngRptDoctorPerformance_NonMedSum(string BeginDate, string EndDate, string DoctIDArr, string MedCatArr, int FeeType, out DataTable dtNonMedSum)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngRptDoctorPerformance_NonMedSum(BeginDate, EndDate, DoctIDArr, MedCatArr, FeeType, out dtNonMedSum);
            objSvc.Dispose();

            return l;
        }

        /// <summary>
        /// 绩效
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="DoctIDArr"></param>
        /// <param name="FeeType"></param>
        /// <param name="RptID"></param>
        /// <param name="m_objGroup"></param>
        /// <param name="m_objResult"></param>
        /// <returns></returns>
        public long m_lngRptDoctorPerformance_Effects(string BeginDate, string EndDate, string DoctIDArr, int FeeType,
                                              string RptID, Dictionary<string, decimal> m_objGroup, out Dictionary<string, decimal> m_objResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                               (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));
            long l = objSvc.m_lngRptDoctorPerformance_Effects(BeginDate, EndDate, DoctIDArr, FeeType, RptID, m_objGroup, out m_objResult);
            objSvc.Dispose();

            return l;
        }
        /// <summary>
        /// 抗菌药比例
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="FeeType"></param>
        /// <param name="m_objAntiseptic"></param>
        /// <returns></returns>
        public long m_lngRptDoctorPerformance_Antiseptic(string BeginDate, string EndDate, string DoctIDArr, string KangJunArr, int FeeType, out DataTable dtAntiseptic)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                               (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));
            long l = objSvc.m_lngRptDoctorPerformance_Antiseptic(BeginDate, EndDate, DoctIDArr, KangJunArr, FeeType, out dtAntiseptic);
            objSvc.Dispose();

            return l;
        }

        /// <summary>
        /// 基本比例
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="FeeType"></param>
        /// <param name="m_objAntiseptic"></param>
        /// <returns></returns>
        public long m_lngRptDoctorPerformance_Essential(string BeginDate, string EndDate, string DoctIDArr, string JiBenArr, int FeeType, out DataTable dtEssential)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                               (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));
            long l = objSvc.m_lngRptDoctorPerformance_Essential(BeginDate, EndDate, DoctIDArr, JiBenArr, FeeType, out dtEssential);
            objSvc.Dispose();

            return l;
        }

        #endregion

        #region 全院(门诊、住院)各核算单位实收报表
        /// <summary>
        /// 全院(门诊、住院)各核算单位实收报表
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="Type">1 发票时间 2 日结时间</param>
        /// <param name="dtGroup"></param>
        /// <param name="dtRecNums"></param>
        /// <param name="dtMz"></param>
        /// <param name="dtZy"></param>
        /// <returns></returns>       
        public long m_lngRptAllDeptIncome(string BeginDate, string EndDate, int Type, out DataTable dtGroup, out DataTable dtRecNums, out DataTable dtMz, out DataTable dtZy)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngRptAllDeptIncome(BeginDate, EndDate, Type, out dtGroup, out dtRecNums, out dtMz, out dtZy);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 获取功能科室专业组分类统计数据
        /// <summary>
        /// 获取功能科室专业组分类统计数据
        /// </summary>
        /// <param name="p_objData"></param>
        /// <returns></returns>
        public long m_lngGetGroupInComeByDoctor(ref clsGroupInComeByDoctorOrArea_VO objvalue_Param, ref DataTable dtbResult)
        {
            long lngRes = 0;
            //com.digitalwave.iCare.middletier.HIS.clsDemoMiddleTierSVC objSvc =(com.digitalwave.iCare.middletier.HIS.clsDemoMiddleTierSVC)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDemoMiddleTierSVC));

            //创建中间件COM对象
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            lngRes = objSvc.m_lngGetGroupInComeByDoctor(objPrincipal, ref objvalue_Param, ref dtbResult);
            return lngRes;
        }
        #endregion

        #region 获取功能科室核算实收统计数据-主治医生
        /// <summary>
        /// 获取功能科室核算实收统计数据
        /// </summary>
        /// <param name="p_objData"></param>
        /// <returns></returns>
        public long m_lngGetGroupInComeByArea(ref clsGroupInComeByDoctorOrArea_VO objvalue_Param, ref DataTable dtbResult)
        {
            long lngRes = 0;

            //创建中间件COM对象
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            //lngRes = objSvc.m_lngGetGroupInComeByDoctor(objPrincipal, ref objvalue_Param, ref dtbResult);
            return lngRes;
        }

        /// <summary>
        /// 获取病区数据
        /// </summary>
        /// <param name="strFindCode"></param>
        /// <param name="objItemArr"></param>
        /// <returns></returns>
        internal long m_lngFindArea(string strFindCode, out clsBIHArea[] objItemArr)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));
            return objSvc.m_lngFindArea(strFindCode, out objItemArr);
        }

        #endregion

        #region 预出院未清帐统计-得到人员列表
        /// <summary>
        /// 得到人员列表
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="p_strSections"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngGetOutNoChargePatientList(string BeginDate, string EndDate, string p_strSections, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngGetOutNoChargePatientList(BeginDate, EndDate, p_strSections, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 根据REGID获取病人所有预交金
        /// <summary>
        /// 根据REGID获取病人所有预交金
        /// </summary>
        /// <param name="RegID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngGetPrepayStatusSumByRegID(string RegID, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngGetPrepayStatusSumByRegID(RegID, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 根据REGID获取病人所有各状态费用信息
        /// <summary>
        /// 根据REGID获取病人所有各状态费用信息
        /// </summary>
        /// <param name="RegID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngGetPatientStatusSumByRegID(string RegID, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngGetPatientStatusSumByRegID(RegID, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 病区工作日志
        /// <summary>
        /// 获取病区
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>       
        public long m_lngRptDeptWorkLog_Dept(out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngRptDeptWorkLog_Dept(out dt);
            objSvc.Dispose();

            return l;
        }

        /// <summary>
        /// 当天入院人数
        /// </summary>
        /// <param name="AreaID"></param>
        /// <param name="CurrDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngRptDeptWorkLog_InNums(string AreaID, string CurrDate, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngRptDeptWorkLog_InNums(AreaID, CurrDate, out dt);
            objSvc.Dispose();

            return l;
        }

        /// <summary>
        /// 当天出院人数
        /// </summary>
        /// <param name="AreaID"></param>
        /// <param name="CurrDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngRptDeptWorkLog_OutNums(string AreaID, string CurrDate, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngRptDeptWorkLog_OutNums(AreaID, CurrDate, out dt);
            objSvc.Dispose();

            return l;
        }

        /// <summary>
        /// 出院死亡人数
        /// </summary>
        /// <param name="AreaID"></param>
        /// <param name="CurrDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngRptDeptWorkLog_OutDeadNums(string AreaID, string CurrDate, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngRptDeptWorkLog_OutDeadNums(AreaID, CurrDate, out dt);
            objSvc.Dispose();

            return l;
        }

        /// <summary>
        /// 出院死亡人数(24小时)
        /// </summary>
        /// <param name="AreaID"></param>
        /// <param name="CurrDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngRptDeptWorkLog_OutDead24Nums(string AreaID, string CurrDate, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngRptDeptWorkLog_OutDead24Nums(AreaID, CurrDate, out dt);
            objSvc.Dispose();

            return l;
        }

        /// <summary>
        /// 当天在院人数
        /// </summary>
        /// <param name="AreaID"></param>
        /// <param name="CurrDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>      
        public long m_lngRptDeptWorkLog_OnNums(string AreaID, string CurrDate, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngRptDeptWorkLog_OnNums(AreaID, CurrDate, out dt);
            objSvc.Dispose();

            return l;
        }

        /// <summary>
        /// 当天在院分娩人数
        /// </summary>
        /// <param name="AreaID"></param>
        /// <param name="CurrDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>      
        public long m_lngRptDeptWorkLog_FmNums(string AreaID, string CurrDate, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngRptDeptWorkLog_FMNums(AreaID, CurrDate, out dt);
            objSvc.Dispose();

            return l;
        }

        /// <summary>
        /// 当天转出人数
        /// </summary>
        /// <param name="AreaID"></param>
        /// <param name="CurrDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngRptDeptWorkLog_TransOutNums(string AreaID, string CurrDate, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngRptDeptWorkLog_TransOutNums(AreaID, CurrDate, out dt);
            objSvc.Dispose();

            return l;
        }

        /// <summary>
        /// 当天转入人数
        /// </summary>
        /// <param name="AreaID"></param>
        /// <param name="CurrDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngRptDeptWorkLog_TransInNums(string AreaID, string CurrDate, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngRptDeptWorkLog_TransInNums(AreaID, CurrDate, out dt);
            objSvc.Dispose();

            return l;
        }

        /// <summary>
        /// 入院病人清单
        /// </summary>
        /// <param name="AreaID"></param>
        /// <param name="CurrDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngRptDeptWorkLog_InPatList(string AreaID, string CurrDate, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngRptDeptWorkLog_InPatList(AreaID, CurrDate, out dt);
            objSvc.Dispose();

            return l;
        }

        /// <summary>
        /// 转入病人清单
        /// </summary>
        /// <param name="AreaID"></param>
        /// <param name="CurrDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngRptDeptWorkLog_TransInPatList(string AreaID, string CurrDate, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                          (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngRptDeptWorkLog_TransInPatList(AreaID, CurrDate, out dt);
            objSvc.Dispose();

            return l;
        }

        /// <summary>
        /// 转出病人清单
        /// </summary>
        /// <param name="AreaID"></param>
        /// <param name="CurrDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngRptDeptWorkLog_TransOutPatList(string AreaID, string CurrDate, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                         (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngRptDeptWorkLog_TransOutPatList(AreaID, CurrDate, out dt);
            objSvc.Dispose();

            return l;
        }

        /// <summary>
        /// 出院病人清单
        /// </summary>
        /// <param name="AreaID"></param>
        /// <param name="CurrDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngRptDeptWorkLog_OutPatList(string AreaID, string CurrDate, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                        (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngRptDeptWorkLog_OutPatList(AreaID, CurrDate, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 合作医疗
        #region 基本资料
        /// <summary>
        /// 基本资料
        /// </summary>
        /// <param name="PayTypeID"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngHZYLPatientInfo(string PayTypeID, string BeginDate, string EndDate, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngHZYLPatientInfo(PayTypeID, BeginDate, EndDate, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 处方合计
        #region 处方合计1-西药
        /// <summary>
        /// 处方合计1-西药
        /// </summary>
        /// <param name="PayTypeID"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngHZYLRecipeSum1(string PayTypeID, string BeginDate, string EndDate, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngHZYLRecipeSum1(PayTypeID, BeginDate, EndDate, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 处方合计2-中药
        /// <summary>
        /// 处方合计2-中药
        /// </summary>
        /// <param name="PayTypeID"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngHZYLRecipeSum2(string PayTypeID, string BeginDate, string EndDate, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngHZYLRecipeSum2(PayTypeID, BeginDate, EndDate, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion
        #endregion

        #region 处方明细
        #region 处方明细1-西药
        /// <summary>
        /// 处方明细1-西药
        /// </summary>
        /// <param name="PayTypeID"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngHZYLRecipeEntry1(string PayTypeID, string BeginDate, string EndDate, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngHZYLRecipeEntry1(PayTypeID, BeginDate, EndDate, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 处方明细2-中药
        /// <summary>
        /// 处方明细2-中药
        /// </summary>
        /// <param name="PayTypeID"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngHZYLRecipeEntry2(string PayTypeID, string BeginDate, string EndDate, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngHZYLRecipeEntry2(PayTypeID, BeginDate, EndDate, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 处方明细3-检验
        /// <summary>
        /// 处方明细3-检验
        /// </summary>
        /// <param name="PayTypeID"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngHZYLRecipeEntry3(string PayTypeID, string BeginDate, string EndDate, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngHZYLRecipeEntry3(PayTypeID, BeginDate, EndDate, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 处方明细4-检查
        /// <summary>
        /// 处方明细4-检查
        /// </summary>
        /// <param name="PayTypeID"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngHZYLRecipeEntry4(string PayTypeID, string BeginDate, string EndDate, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngHZYLRecipeEntry4(PayTypeID, BeginDate, EndDate, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 处方明细5-治疗
        /// <summary>
        /// 处方明细5-治疗
        /// </summary>
        /// <param name="PayTypeID"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngHZYLRecipeEntry5(string PayTypeID, string BeginDate, string EndDate, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngHZYLRecipeEntry5(PayTypeID, BeginDate, EndDate, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 处方明细6-材料
        /// <summary>
        /// 处方明细6-材料
        /// </summary>
        /// <param name="PayTypeID"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngHZYLRecipeEntry6(string PayTypeID, string BeginDate, string EndDate, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngHZYLRecipeEntry6(PayTypeID, BeginDate, EndDate, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #endregion

        #region 生成DBF
        #region 个人资料表(grzl)
        /// <summary>
        /// 个人资料表(grzl)
        /// </summary>
        /// <param name="DSN"></param>
        /// <param name="DbfName"></param>
        /// <param name="objYBArr"></param>
        /// <returns></returns>
        public long m_lngCreateHZYLDbf_PatInfo(string DSN, string DbfName, ArrayList objYBArr)
        {
            com.digitalwave.iCare.middletier.HIS.clsLunJiao objSvc =
                                                            (com.digitalwave.iCare.middletier.HIS.clsLunJiao)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsLunJiao));

            long l = objSvc.m_lngCreateHZYLDbf_PatInfo(DSN, DbfName, objYBArr);

            return l;
        }
        #endregion

        #region 处方汇总(zycf)
        /// <summary>
        /// 处方汇总(zycf)
        /// </summary>
        /// <param name="DSN"></param>
        /// <param name="DbfName"></param>
        /// <param name="objYBArr"></param>
        /// <returns></returns>
        public long m_lngCreateHZYLDbf_RecipeSum(string DSN, string DbfName, ArrayList objYBArr)
        {
            com.digitalwave.iCare.middletier.HIS.clsLunJiao objSvc =
                                                            (com.digitalwave.iCare.middletier.HIS.clsLunJiao)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsLunJiao));

            long l = objSvc.m_lngCreateHZYLDbf_RecipeSum(DSN, DbfName, objYBArr);

            return l;
        }
        #endregion

        #region 处方资料表(cfzl)
        /// <summary>
        /// 处方资料表(cfzl)
        /// </summary>
        /// <param name="DSN"></param>
        /// <param name="DbfName"></param>
        /// <param name="objYBArr"></param>
        /// <returns></returns>
        public long m_lngCreateHZYLDbf_RecipeEntry(string DSN, string DbfName, ArrayList objYBArr)
        {
            com.digitalwave.iCare.middletier.HIS.clsLunJiao objSvc =
                                                            (com.digitalwave.iCare.middletier.HIS.clsLunJiao)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsLunJiao));

            long l = objSvc.m_lngCreateHZYLDbf_RecipeEntry(DSN, DbfName, objYBArr);

            return l;
        }
        #endregion
        #endregion
        #endregion

        #region 医保身份
        /// <summary>
        /// 医保身份
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngGetALLYBType(out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                         (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngGetALLYBType(out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 查找医保-HIS对应项目
        /// <summary>
        /// 查找医保-HIS对应项目
        /// </summary>
        /// <param name="strQuery"></param>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        public long m_lngGetShiying(string strQuery, out DataTable dtResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                                    (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngGetShiying(strQuery, out dtResult);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 保存适应症
        /// <summary>
        /// 保存适应症
        /// </summary>
        /// <param name="objVO"></param>
        /// <returns></returns>
        public long m_lngSaveShiying(clsShiyingVO objVO)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                                              (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngSaveShiying(objVO);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 删除适应症
        /// <summary>
        /// 删除适应症
        /// </summary>
        /// <param name="objVO"></param>
        /// <returns></returns>
        public long m_lngDelShiying(clsShiyingVO objVO)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                                              (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngDelShiying(objVO);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 收费处缴款报表统计让利金额
        /// <summary>
        /// 收费处缴款报表统计让利金额
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="dtCharge"></param>
        /// <param name="dtPayment"></param>
        /// <param name="dtRemarkInfo"></param>
        /// <returns></returns>        
        public long m_lngRptTotaldiffcostmoney(string m_strChargeno, string EmpID, out DataTable dttodiffsum)
        {
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                                                        (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            long l = objSvc.m_lngRptTotaldiffcostmoney(m_strChargeno, EmpID, out dttodiffsum);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 社保登记日志
        /// <summary>
        /// 社保登记日志
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <param name="deptIdArr"></param>
        /// <returns></returns>
        public DataTable GetRptSbRegister(string beginDate, string endDate, string deptIdArr)
        {
            using (com.digitalwave.iCare.middletier.HIS.clsReport svc =
                                                        (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport)))
            {
                return svc.GetRptSbRegister(beginDate, endDate, deptIdArr);
            }
        }
        #endregion

        #region 门诊住院退费原因
        /// <summary>
        /// 门诊住院退费原因
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public DataTable GetRptInvoiceRefundReason(int flagId, string beginDate, string endDate)
        {
            using (com.digitalwave.iCare.middletier.HIS.clsReport svc =
                                                       (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport)))
            {
                return svc.GetRptInvoiceRefundReason(flagId, beginDate, endDate);
            }
        }
        #endregion

        #region 获取外送单位
        /// <summary>
        /// 获取外送单位
        /// </summary>
        /// <returns></returns>
        public DataTable GetOutsideUnit()
        {
            using (com.digitalwave.iCare.middletier.HIS.clsReport svc =
                                                      (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport)))
            {
                return svc.GetOutsideUnit();
            }
        }
        #endregion

        #region 获取外送费用明细
        /// <summary>
        /// 获取外送费用明细
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public DataTable GetOutsideChargeItem(string beginDate, string endDate)
        {
            using (com.digitalwave.iCare.middletier.HIS.clsReport svc =
                                                     (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport)))
            {
                return svc.GetOutsideChargeItem(beginDate, endDate);
            }
        }
        #endregion

    }
}
