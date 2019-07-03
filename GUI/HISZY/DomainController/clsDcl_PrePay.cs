using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 预缴金DOMAIN类
    /// </summary>
    public class clsDcl_PrePay : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public clsDcl_PrePay()
        {
        }
        #endregion
        
        #region 检查预交金单据号是否重复
        /// <summary>
        /// 检查预交金单据号是否重复
        /// </summary>
        /// <param name="CurrNo"></param>
        /// <returns></returns>
        public bool m_blnCheckPrepayBillNo(string CurrNo, int Uptype)
        {
            com.digitalwave.iCare.middletier.HIS.clsPrePay objSvc =
                                                 (com.digitalwave.iCare.middletier.HIS.clsPrePay)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsPrePay));

            bool l = objSvc.m_blnCheckPrepayBillNo(CurrNo, Uptype);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 根据住院登记流水号获取押金信息
        /// <summary>
        /// 根据住院登记流水号获取押金信息
        /// </summary>
        /// <param name="RegID"></param>
        /// <param name="Type">类型：1 明细；2 汇总</param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngGetPrepayByRegID(string RegID, int Type, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsPrePay objSvc =
                                                 (com.digitalwave.iCare.middletier.HIS.clsPrePay)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsPrePay));

            long l = objSvc.m_lngGetPrepayByRegID(RegID, Type, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 新增预交金记录
        /// <summary>
        /// 新增预交金记录
        /// </summary>
        /// <param name="PrePay_VO"></param>
        /// <returns></returns>
        public long m_lngAddPrePay(clsBihPrePay_VO PrePay_VO, out string PrePayID)
        {
            com.digitalwave.iCare.middletier.HIS.clsPrePay objSvc =
                                                 (com.digitalwave.iCare.middletier.HIS.clsPrePay)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsPrePay));

            long l = objSvc.m_lngAddPrePay(PrePay_VO, out PrePayID);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 根据预交金ID获取预交金信息
        /// <summary>
        /// 根据预交金ID获取预交金信息
        /// </summary>
        /// <param name="PrePayID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngGetPrepayByPrePayID(string PrePayID, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsPrePay objSvc =
                                                 (com.digitalwave.iCare.middletier.HIS.clsPrePay)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsPrePay));

            long l = objSvc.m_lngGetPrepayByPrePayID(PrePayID, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 根据操作员工号获取ID、姓名和密码
        /// <summary>
        /// 根据操作员工号获取ID、姓名和密码
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="empno"></param>
        /// <returns></returns>
        public long m_lngGetempinfo(out DataTable dt, string empno)
        {
            com.digitalwave.iCare.middletier.HIS.clsPrePay objSvc =
                                                                         (com.digitalwave.iCare.middletier.HIS.clsPrePay)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsPrePay));

            long l = objSvc.m_lngGetempinfo(out dt, empno);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 退、恢复和冲单预交金
        /// <summary>
        /// 退、恢复和冲单预交金
        /// </summary>
        /// <param name="PrePayID">当前预交金流水ID</param>
        /// <param name="EmpID">收款员ID</param>
        /// <param name="ConfirmID">审核人ID</param>
        /// <param name="type">类型 2 退款 3 恢复 4 冲单</param>
        /// <returns></returns>
        public long m_lngRefundAndResumeAndStrikePrePay(string PrePayID, string NewBillNO, string EmpID, string ConfirmID, int type, string CuyCate, out string NewPrePayID)
        {
            com.digitalwave.iCare.middletier.HIS.clsPrePay objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsPrePay)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsPrePay));

            long l = objSvc.m_lngRefundAndResumeAndStrikePrePay(PrePayID, NewBillNO, EmpID, ConfirmID, type, CuyCate, out NewPrePayID);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 保存重打票据信息
        /// <summary>
        /// 保存重打票据信息
        /// </summary>
        /// <param name="BillID"></param>
        /// <param name="OldBillNo"></param>
        /// <param name="NewBillNo"></param>
        /// <param name="Empid"></param>
        /// <param name="BillType">票据类型：1 预交金 2 发票</param>
        /// <returns></returns>
        public long m_lngSaveRepeatPrn(string BillID, string OldBillNo, string NewBillNo, string Empid, string BillType)
        {
            com.digitalwave.iCare.middletier.HIS.clsPrePay objSvc =
                                                             (com.digitalwave.iCare.middletier.HIS.clsPrePay)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsPrePay));

            long l = objSvc.m_lngSaveRepeatPrn(BillID, OldBillNo, NewBillNo, Empid, BillType);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 根据住院登记流水号获取已呆帐结算的预交金信息
        /// <summary>
        /// 根据住院登记流水号获取已呆帐结算的预交金信息
        /// </summary>
        /// <param name="RegID"></param>
        /// <param name="PrepayTotalSum"></param>
        /// <returns></returns>        
        public long m_lngGetBadChargePrepayByRegID(string RegID, out decimal PrepayTotalSum)
        {
            com.digitalwave.iCare.middletier.HIS.clsPrePay objSvc =
                                                 (com.digitalwave.iCare.middletier.HIS.clsPrePay)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsPrePay));

            long l = objSvc.m_lngGetBadChargePrepayByRegID(RegID, out PrepayTotalSum);
            objSvc.Dispose();

            return l;
        }
        #endregion
    }
}
