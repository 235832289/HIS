using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// ��������Domain��
    /// </summary>
    public class clsDcl_Report : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region ����
        /// <summary>
        /// ����
        /// </summary>
        public clsDcl_Report()
        {
        }
        #endregion

        #region ���ݱ����Ż�ȡסԺ�������
        /// <summary>
        /// ���ݱ����Ż�ȡסԺ�������
        /// </summary>
        /// <param name="RptID">�Զ��屨��ID</param>
        /// <param name="Flag">3 סԺ������� 4 סԺ��Ʊ����</param>
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

        #region ÿ���嵥
        /// <summary>
        /// ÿ���嵥(����Ϣ)
        /// </summary>
        /// <param name="AreaID">����ID</param>
        /// <param name="RegID">סԺ�Ǽ���ˮID</param>
        /// <param name="BillDate">�嵥����</param> 
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
        /// ÿ���嵥(�������)
        /// </summary> 
        /// <param name="ID">1-����ID 2-סԺ�Ǽ���ˮID 3-סԺ��</param>        
        /// <param name="BillDate">�嵥����</param>
        /// <param name="Type">���ͣ�1 ������ 2 ����λ 3 ��סԺ��</param>
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
        /// ÿ���嵥 ----�����
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
        /// ÿ���嵥(������ϸ)
        /// </summary>
        /// <param name="ID">1-����ID 2-סԺ�Ǽ���ˮID 3-סԺ��</param>        
        /// <param name="BillDate">�嵥����</param>
        /// <param name="Type">���ͣ�1 ������ 2 ����λ 3 ��סԺ��</param>
        /// <param name="dt"></param>
        /// <param name="ItemCodeType">��Ŀ����ʹ������ 0 �����շѱ��� 1 ��Ŀ����</param>
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

        #region ȫԺ�ɿ�(��Ʊ)���౨��
        /// <summary>
        /// ȫԺ�ɿ�(��Ʊ)���౨��
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="RepType">0 �ɿ���� 1 ��Ʊ����</param>
        /// <param name="StatType">0 ���� 1 ���ܣ�����</param>
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

        #region �տ�Ա�ɿ��
        /// <summary>
        /// �տ�Ա�ɿ��
        /// </summary>
        /// <param name="EmpID">�շ�ԱID</param>
        /// <param name="IsRec">�Ƿ��ѽ���</param>
        /// <param name="RecTime">����ʱ��</param>
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

        #region �տ�Ա�ɿ��(����)
        /// <summary>
        /// �տ�Ա�ɿ��(����)
        /// </summary>
        /// <param name="EmpID">�շ�ԱID</param>
        /// <param name="IsRec">�Ƿ��ѽ���</param>
        /// <param name="RecTime">����ʱ��</param>
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

        #region �շѴ��ɿ��
        /// <summary>
        /// �շѴ��ɿ��
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

        #region ��Ʊ��ϸ����
        /// <summary>
        /// ��Ʊ��ϸ����
        /// </summary>
        /// <param name="InvoiceNO">��Ʊ��</param>
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

        #region ��ȡסԺ�·�Ʊͳ������
        /// <summary>
        /// ��ȡסԺ�·�Ʊͳ������
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
        /// ��ȡסԺ��Ʊ�ش�����
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

        #region ������н���Ա����
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

        #endregion //��ȡ�Һŷ�Ʊͳ������

        #region ʵ����ϸ��־(��Ʊ��ϸ)
        /// <summary>
        /// ʵ����ϸ��־(��Ʊ��ϸ)
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

        #region ʵ����ϸ��־(��Ʊ)
        /// <summary>
        /// ʵ����ϸ��־(��Ʊ)
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

        #region ����ʵ�ձ���
        /// <summary>
        /// ����ʵ�ձ���
        /// </summary>
        /// <param name="Type">1 ��������ʵ�� 2 ִ�п���ʵ��</param>
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

        #region ҽ��������ϸ����
        /// <summary>
        /// ҽ��������ϸ����
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

        #region ����Ԥ������ϸ����
        /// <summary>
        /// ����Ԥ������ϸ����
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

        #region ����ʵ����ϸ����
        /// <summary>
        /// ����ʵ����ϸ����
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

        #region ��������־����
        /// <summary>
        /// ��������־����
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

        #region ��Ժ������־����
        /// <summary>
        /// ��Ժ������־����
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

        #region ��Ŀͳ�Ʒ�����ϸ����
        /// <summary>
        /// ��Ŀͳ�Ʒ�����ϸ����
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

        #region ҩƷ������(������)
        /// <summary>
        /// ҩƷ������(������)
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

        #region ˳��������ͨҽ����סԺҽ��������ϸͳ��
        /// <summary>
        /// ˳��������ͨҽ����סԺҽ��������ϸͳ��
        /// </summary>
        /// <param name="Type">1 ���� 2 סԺ</param>
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

        #region ��ͨ����ҽ����סԺҽ��
        /// <summary>
        /// ��ͨ����ҽ����סԺҽ��
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

        #region ����סԺ��
        /// <summary>
        /// ����סԺ��
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

        #region ��Ժ�Ǽ��������˼�¼
        /// <summary>
        /// ��Ժ�Ǽ��������˼�¼
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

        #region סԺҽ����Чͳ�Ʊ���
        /// <summary>
        /// סԺҽ����Чͳ�Ʊ���
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
        /// 1����������
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
        /// 2��Ĭ�Ͽ���
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
        /// 3����ס�˴�
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
        /// 4����Ժ�˴� ռ��������
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
        /// 5����Ժ��(��Ԥ��Ժ)�ܷ���
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
        /// 6����Ժ��(��Ԥ��Ժ)ҩ��
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
        /// 7����Ժ��(��Ԥ��Ժ)��ҩ��
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
        /// ��Ч
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
        /// ����ҩ����
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
        /// ��������
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

        #region ȫԺ(���סԺ)�����㵥λʵ�ձ���
        /// <summary>
        /// ȫԺ(���סԺ)�����㵥λʵ�ձ���
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="Type">1 ��Ʊʱ�� 2 �ս�ʱ��</param>
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

        #region ��ȡ���ܿ���רҵ�����ͳ������
        /// <summary>
        /// ��ȡ���ܿ���רҵ�����ͳ������
        /// </summary>
        /// <param name="p_objData"></param>
        /// <returns></returns>
        public long m_lngGetGroupInComeByDoctor(ref clsGroupInComeByDoctorOrArea_VO objvalue_Param, ref DataTable dtbResult)
        {
            long lngRes = 0;
            //com.digitalwave.iCare.middletier.HIS.clsDemoMiddleTierSVC objSvc =(com.digitalwave.iCare.middletier.HIS.clsDemoMiddleTierSVC)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDemoMiddleTierSVC));

            //�����м��COM����
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            lngRes = objSvc.m_lngGetGroupInComeByDoctor(objPrincipal, ref objvalue_Param, ref dtbResult);
            return lngRes;
        }
        #endregion

        #region ��ȡ���ܿ��Һ���ʵ��ͳ������-����ҽ��
        /// <summary>
        /// ��ȡ���ܿ��Һ���ʵ��ͳ������
        /// </summary>
        /// <param name="p_objData"></param>
        /// <returns></returns>
        public long m_lngGetGroupInComeByArea(ref clsGroupInComeByDoctorOrArea_VO objvalue_Param, ref DataTable dtbResult)
        {
            long lngRes = 0;

            //�����м��COM����
            com.digitalwave.iCare.middletier.HIS.clsReport objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsReport)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport));

            //lngRes = objSvc.m_lngGetGroupInComeByDoctor(objPrincipal, ref objvalue_Param, ref dtbResult);
            return lngRes;
        }

        /// <summary>
        /// ��ȡ��������
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

        #region Ԥ��Ժδ����ͳ��-�õ���Ա�б�
        /// <summary>
        /// �õ���Ա�б�
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

        #region ����REGID��ȡ��������Ԥ����
        /// <summary>
        /// ����REGID��ȡ��������Ԥ����
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

        #region ����REGID��ȡ�������и�״̬������Ϣ
        /// <summary>
        /// ����REGID��ȡ�������и�״̬������Ϣ
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

        #region ����������־
        /// <summary>
        /// ��ȡ����
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
        /// ������Ժ����
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
        /// �����Ժ����
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
        /// ��Ժ��������
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
        /// ��Ժ��������(24Сʱ)
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
        /// ������Ժ����
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
        /// ������Ժ��������
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
        /// ����ת������
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
        /// ����ת������
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
        /// ��Ժ�����嵥
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
        /// ת�벡���嵥
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
        /// ת�������嵥
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
        /// ��Ժ�����嵥
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

        #region ����ҽ��
        #region ��������
        /// <summary>
        /// ��������
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

        #region �����ϼ�
        #region �����ϼ�1-��ҩ
        /// <summary>
        /// �����ϼ�1-��ҩ
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

        #region �����ϼ�2-��ҩ
        /// <summary>
        /// �����ϼ�2-��ҩ
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

        #region ������ϸ
        #region ������ϸ1-��ҩ
        /// <summary>
        /// ������ϸ1-��ҩ
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

        #region ������ϸ2-��ҩ
        /// <summary>
        /// ������ϸ2-��ҩ
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

        #region ������ϸ3-����
        /// <summary>
        /// ������ϸ3-����
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

        #region ������ϸ4-���
        /// <summary>
        /// ������ϸ4-���
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

        #region ������ϸ5-����
        /// <summary>
        /// ������ϸ5-����
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

        #region ������ϸ6-����
        /// <summary>
        /// ������ϸ6-����
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

        #region ����DBF
        #region �������ϱ�(grzl)
        /// <summary>
        /// �������ϱ�(grzl)
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

        #region ��������(zycf)
        /// <summary>
        /// ��������(zycf)
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

        #region �������ϱ�(cfzl)
        /// <summary>
        /// �������ϱ�(cfzl)
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

        #region ҽ�����
        /// <summary>
        /// ҽ�����
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

        #region ����ҽ��-HIS��Ӧ��Ŀ
        /// <summary>
        /// ����ҽ��-HIS��Ӧ��Ŀ
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

        #region ������Ӧ֢
        /// <summary>
        /// ������Ӧ֢
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

        #region ɾ����Ӧ֢
        /// <summary>
        /// ɾ����Ӧ֢
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

        #region �շѴ��ɿ��ͳ���������
        /// <summary>
        /// �շѴ��ɿ��ͳ���������
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

        #region �籣�Ǽ���־
        /// <summary>
        /// �籣�Ǽ���־
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

        #region ����סԺ�˷�ԭ��
        /// <summary>
        /// ����סԺ�˷�ԭ��
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

        #region ��ȡ���͵�λ
        /// <summary>
        /// ��ȡ���͵�λ
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

        #region ��ȡ���ͷ�����ϸ
        /// <summary>
        /// ��ȡ���ͷ�����ϸ
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
