using System;
using System.Collections.Generic;
using System.Text;

namespace com.digitalwave.iCare.ValueObject
{
    #region סԺ������ϢVO
    /// <summary>
    /// סԺ������ϢVO
    /// </summary>
    [Serializable]
    public class clsBihPatient_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// ��Ժ�Ǽ�ID
        /// </summary>
        public string RegisterID = "";
        /// <summary>
        /// ����ID
        /// </summary>
        public string PatientID = "";
        /// <summary>
        /// ���ƿ���
        /// </summary>
        public string CardNO = "";
        /// <summary>
        /// סԺ��
        /// </summary>
        public string Zyh = "";
        /// <summary>
        /// סԺ����
        /// </summary>
        public int Zycs = 0;
        /// <summary>
        /// �������ID
        /// </summary>
        public string PayTypeID = "";
        /// <summary>
        /// ������ݶ�ӦID����
        /// </summary>
        public string IdNo = "";
        /// <summary>
        /// ����
        /// </summary>
        public string Name = "";
        /// <summary>
        /// �Ա�
        /// </summary>
        public string Sex = "";
        /// <summary>
        /// ���֤��
        /// </summary>
        public string IdCard = "";
        /// <summary>
        /// ����
        /// </summary>
        public string Age = "";
        /// <summary>
        /// �ѱ�
        /// </summary>
        public string Fee = "";
        /// <summary>
        /// ��Ժ���� 1 ��ͨ��Ժ 2 ������Ժ
        /// </summary>
        public string InType = "";
        /// <summary>
        /// ��Ժʱ��
        /// </summary>
        public string InHospitalDate = "";
        /// <summary>
        /// ��ǰ����ID
        /// </summary>
        public string AreaID = "";
        /// <summary>
        /// ��ǰ��������
        /// </summary>
        public string AreaName = "";
        /// <summary>
        /// ����ID
        /// </summary>
        public string BedID = "";
        /// <summary>
        /// ������
        /// </summary>
        public string BedNO = "";
        /// <summary>
        /// ��Ժʱ��
        /// </summary>
        public string OutHospitalDate = "";
        /// <summary>
        /// סԺ����
        /// </summary>
        public int Days = 0;
        /// <summary>
        /// ����Ԥ������
        /// </summary>
        public decimal PrepayMoney = 0;
        /// <summary>
        /// �����
        /// </summary>
        public decimal BalanceMoney = 0;
        /// <summary>
        /// ��Ժ״̬  0 �´� 1 �ڴ� 2 Ԥ��Ժ 3 ʵ�ʳ�Ժ 4 ��� 8 ��Ժ���� 9 Ԥ����
        /// </summary>
        public int Status = 0;
        /// <summary>
        /// ����״̬ 0 �� 1 ���� 2 ��;���� 3 ��Ժ���� 4 ���ʽ��� 5 ��Ժ����
        /// </summary>
        public int FeeStatus = 0;
        /// <summary>
        /// δ������
        /// </summary>
        public int NoChargeDays = 0;
        /// <summary>
        /// �ܷ���
        /// </summary>
        public decimal TotalFee = 0;
        /// <summary>
        /// �������
        /// </summary>
        public decimal WaitChargeFee = 0;
        /// <summary>
        /// ֱ�ӽ��ѷ���
        /// </summary>
        public decimal DirectorFee = 0;
        /// <summary>
        /// �������
        /// </summary>
        public decimal CompleteClearFee = 0;
        /// <summary>
        /// �������
        /// </summary>
        public decimal WaitClearFee = 0;
        /// <summary>
        /// ���
        /// </summary>
        public string Diagnose = "";
        /// <summary>
        /// ��������
        /// </summary>
        public string ClearFeeDate = "";
        /// <summary>
        /// ��ע��Ϣ
        /// </summary>
        public string SpecialInfo = "";
        /// <summary>
        /// ��ע
        /// </summary>
        public string Note = "";
        /// <summary>
        /// ҽ��ͳ�����
        /// </summary>
        public decimal YbTotalFee = 0;
        /// <summary>
        /// ҽ�����ʣ�����
        /// </summary>
        public decimal YbLeaveFee = 0;
        /// <summary>
        /// ҽ���������
        /// </summary>
        public decimal YbWaitClearFee = 0;
        /// <summary>
        /// ҽ���Ը�����
        /// </summary>
        public decimal YbSbScale = 100;
        /// <summary>
        /// ��������
        /// </summary>
        public decimal LimtRate = 0;
        /// <summary>
        /// ��עʱ�Ƿ�ط� 0 ������ 1 ����
        /// </summary>
        public int SpecChargeCtrl = 0;
        /// <summary>
        /// ����ҽ��ID
        /// </summary>
        public string DoctorID = "";
        /// <summary>
        /// ����ҽ������
        /// </summary>
        public string DoctorName = "";
        /// <summary>
        /// ����ҽ������������ID
        /// </summary>
        public string DoctorGroupID = "";
        /// <summary>
        /// (���)ҽ�������ܽ��(ʣ��)
        /// </summary>
        public decimal InsuredTotalMoney = 0;
        /// <summary>
        /// ҽ��סԺ����
        /// </summary>
        public int InsuredZycs = 0;
        /// <summary>
        /// Ԥ������(�Ѵ��ʽ���)
        /// </summary>
        public decimal PrepayMoneyBadCharge = 0;
        /// <summary>
        /// ���Ҫ�������δ��һ���£���ʱ��ҽ����ӡ��ʱ����ı������ֶ�
        /// </summary>
        public DateTime m_dtmBirthDay;
    }
    #endregion

    #region Ԥ����VO
    /// <summary>
    /// Ԥ����VO
    /// </summary>
    [Serializable]
    public class clsBihPrePay_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// ��ˮ��
        /// </summary>
        public string strPrePayID = "";
        /// <summary>
        /// ����ID
        /// </summary>
        public string strPatientID = "";
        /// <summary>
        /// סԺ�Ǽ�id	{=סԺ�Ǽ�.id}
        /// </summary>
        public string strRegisterID = "";
        /// <summary>
        /// ���	{1=�հ�;2=ҹ��}
        /// </summary>
        public int intLiner = 0;
        /// <summary>
        /// ��������{1=һ��;2=�˷�;3=�ָ�}
        /// </summary>
        public int intPayType = 0;
        /// <summary>
        /// ����{1=�ֽ�;2=֧Ʊ;3=���ÿ�;4=���}
        /// </summary>
        public int intCuyCate = 0;
        /// <summary>
        /// ���
        /// </summary>
        public decimal decMoney = 0;
        /// <summary>
        /// Ԥ������ ��Ʊ��
        /// </summary>
        public string strPrePayInv = "";
        /// <summary>
        /// ����id	{=����.id}
        /// </summary>
        public string strAreaID = "";
        /// <summary>
        /// ��ע
        /// </summary>
        public string strDes = "";
        /// <summary>
        /// ¼����id	{=��Ա.id}
        /// </summary>
        public string strCreatorID = "";
        /// <summary>
        /// ¼������
        /// </summary>
        public string strCreateDate = "";
        /// <summary>
        /// �޸���id	{=��Ա.id}
        /// </summary>
        public string strDeactID = "";
        /// <summary>
        /// �޸�����
        /// </summary>
        public string strDeactivateDate = "";
        /// <summary>
        /// ����״̬{1/0}
        /// </summary>
        public int intStatus = 0;
        /// <summary>
        /// �Ƿ�����{1/0}
        /// </summary>
        public int intIsClear = 0;
        /// <summary>
        /// ��Ʊӡˢ��
        /// </summary>
        public string strPressNo = "";
        /// <summary>
        /// Ԥ�շ�ʽ 0 ���� 1 �ֹ���Ԥ��
        /// </summary>
        public int intUpType = 0;
        /// <summary>
        /// ��������
        /// </summary>
        public string strPatientName = "";
        /// <summary>
        /// ��������
        /// </summary>
        public string strAreaName = "";
        /// <summary>
        /// ����״̬ 0-δ���� 1-�ѽ���
        /// </summary>
        public int intBalanceFlag = 0;
        /// <summary>
        /// ������
        /// </summary>
        public string strBalanceEmp = "";
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public string strBalanceDate = "";
        /// <summary>
        /// ������ˮ�ţ�����T_OPR_BIH_PREPAYBALANCE
        /// </summary>
        public string strBalanceID = "";
    }
    #endregion

    #region ����VO
    /// <summary>
    /// ����VO
    /// </summary>
    [Serializable]
    public class clsBihDayAccounts_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// ������ˮ��
        /// </summary>
        public string AccountsID = "";
        /// <summary>
        /// ����ID
        /// </summary>
        public string PatientID = "";
        /// <summary>
        /// ��Ժ�Ǽ���ˮ��
        /// </summary>
        public string RegisterID = "";
        /// <summary>
        /// ����
        /// </summary>
        public int OrderNO = 0;
        /// <summary>
        /// ���ںϼƽ��
        /// </summary>
        public decimal TotalSum = 0;
        /// <summary>
        /// �����Ը����
        /// </summary>
        public decimal SbSum = 0;
        /// <summary>
        /// �����Ը����
        /// </summary>
        public decimal ClearSbSum = 0;
        /// <summary>
        /// ���ڼ��ʽ��
        /// </summary>
        public decimal AcctSum = 0;
        /// <summary>
        /// ���ʼ��ʽ��
        /// </summary>
        public decimal ClearAcctSum = 0;
        /// <summary>
        /// ������ID
        /// </summary>
        public string ChargeEmp = "";
        /// <summary>
        /// ���㲡��(��������)
        /// </summary>
        public string AreaID = "";
        /// <summary>
        /// ��ע��Ϣ
        /// </summary>
        public string Note = "";
        /// <summary>
        /// ��������ʱ�������ڲ���ID
        /// </summary>
        public string CurrAreaID = "";
        /// <summary>
        /// ����ԱID
        /// </summary>
        public string OperID = "";
        /// <summary>
        /// ���� 0 ���� 1 ����
        /// </summary>
        public string Type = "";
    }
    #endregion

    #region סԺ����VO
    /// <summary>
    /// ��סԺ����VO
    /// </summary>
    [Serializable]
    public class clsBihCharge_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// �����(YYYYMMDDHHMMSSFFFFFF)
        /// </summary>
        public string ChargeNo = "";
        /// <summary>
        /// ��Ժ�Ǽ�ID
        /// </summary>
        public string RegisterID = "";
        /// <summary>
        /// �������ID
        /// </summary>
        public string PayTypeID = "";
        /// <summary>
        /// ������Ժ���� 1 סԺ 2 ����
        /// </summary>
        public string PatientType = "";
        /// <summary>
        /// �ϼƽ��
        /// </summary>
        public decimal TotalSum = 0;
        /// <summary>
        /// �Ը����
        /// </summary>
        public decimal SbSum = 0;
        /// <summary>
        /// ���ʽ��
        /// </summary>
        public decimal AcctSum = 0;
        /// <summary>
        /// �շ�ԱID
        /// </summary>
        public string OperEmp = "";
        /// <summary>
        /// �շ�ʱ��
        /// </summary>
        public string OperDate = "";
        /// <summary>
        /// �ս��־ 0 δ�� 1 �ѽ�
        /// </summary>
        public int RecFlag = 0;
        /// <summary>
        /// �ս�ԱID
        /// </summary>
        public string RecEmp = "";
        /// <summary>
        /// �ս�ʱ��
        /// </summary>
        public string RecDate = "";
        /// <summary>
        /// ������� 1 ��;���� 2 ��Ժ���� 3 ���ʽ��� 4 ���ʲ��������
        /// </summary>
        public int Class = 0;
        /// <summary>
        /// �������� 1 �տ� 2 �˿�
        /// </summary>
        public int Type = 0;
        /// <summary>
        /// ����״̬ 1 ��Ч 2 ȡ��
        /// </summary>
        public int Status = 0;
        /// <summary>
        /// ҽ�����ʵ���
        /// </summary>
        public string BillNO = "";
        /// <summary>
        /// ���˱��ID
        /// </summary>
        public string PatientID = "";
        /// <summary>
        /// ���˵�ǰ����ID
        /// </summary>
        public string CurrAreaID = "";
    }
    #endregion

    #region סԺ�������VO
    /// <summary>
    /// סԺ�������VO
    /// </summary>
    [Serializable]
    public class clsBihChargeCat_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// �����
        /// </summary>
        public string ChargeNo = "";
        /// <summary>
        /// �������(ִ�п���)ID
        /// </summary>
        public string DeptID = "";
        /// <summary>
        /// �������ID
        /// </summary>
        public string ItemCatID = "";
        /// <summary>
        /// �ϼƽ��
        /// </summary>
        public decimal TotalSum = 0;
        /// <summary>
        /// ���ʽ��
        /// </summary>
        public decimal AcctSum = 0;
    }
    #endregion

    #region סԺ��ƱVO
    /// <summary>
    /// סԺ��ƱVO
    /// </summary>
    [Serializable]
    public class clsBihInvoice_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// ��Ʊ��
        /// </summary>
        public string InvoiceNo = "";
        /// <summary>
        /// ��Ʊ����
        /// </summary>
        public string InvDate = "";
        /// <summary>
        /// �ϼƽ��
        /// </summary>
        public decimal TotalSum = 0;
        /// <summary>
        /// �Ը����
        /// </summary>
        public decimal SbSum = 0;
        /// <summary>
        /// ���ʽ��
        /// </summary>
        public decimal AcctSum = 0;
        /// <summary>
        /// ״̬ 0-���� 1-��Ч 2-��Ʊ 3-�ָ�
        /// </summary>
        public int Status = -999;
        /// <summary>
        /// �����
        /// </summary>
        public string ConfirmEmp = "";
        /// <summary>
        /// ���ʱ��
        /// </summary>
        public string ConfirmDate = "";
        /// <summary>
        /// �Ƿ�ַ�Ʊ 0 �� 1 ��
        /// </summary>
        public int Split = 0;
    }
    #endregion

    #region סԺ��Ʊ����VO
    /// <summary>
    /// סԺ��Ʊ����VO
    /// </summary>
    [Serializable]
    public class clsBihInvoiceCat_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// ��Ʊ��
        /// </summary>
        public string InvoiceNo = "";
        /// <summary>
        /// ��Ʊ����
        /// </summary>
        public string ItemCatID = "";
        /// <summary>
        /// ��������
        /// </summary>
        public string ItemCatName = "";
        /// <summary>
        /// �ϼƽ��
        /// </summary>
        public decimal TotalSum = 0;
        /// <summary>
        /// ���ʽ��
        /// </summary>
        public decimal AcctSum = 0;
    }
    #endregion

    #region סԺ֧��VO
    /// <summary>
    /// סԺ֧��VO
    /// </summary>
    [Serializable]
    public class clsBihPayment_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// �����
        /// </summary>
        public string ChargeNo = "";
        /// <summary>
        /// ֧����ʽ 0 Ԥ���� 1 �ֽ� 2 ֧Ʊ 3 ���п� 4 ����
        /// </summary>
        public int PayType = -1;
        /// <summary>
        /// ���п����ʹ���
        /// </summary>
        public int PayCardType = -1;
        /// <summary>
        /// ���п�����
        /// </summary>
        public string PayCardNo = "";
        /// <summary>
        /// ֧�����
        /// </summary>
        public decimal PaySum = 0;
        /// <summary>
        /// �Ҷҽ��
        /// </summary>
        public decimal RefuSum = 0;
    }
    #endregion

    #region סԺһ���嵥VO
    /// <summary>
    /// סԺһ���嵥VO
    /// </summary>
    [Serializable]
    public class clsBihEveryDayBill_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// ��Ժ�Ǽ�ID
        /// </summary>
        public string RegisterID = "";
        /// <summary>
        /// סԺ��
        /// </summary>
        public string Zyh = "";
        /// <summary>
        /// ����
        /// </summary>
        public string Name = "";
        /// <summary>
        /// ��ǰ��������
        /// </summary>
        public string AreaName = "";
        /// <summary>
        /// ������
        /// </summary>
        public string BedNO = "";
        /// <summary>
        /// �嵥����
        /// </summary>
        public string BillDate = "";
        /// <summary>
        /// ����ϼƽ��
        /// </summary>
        public string CurrDayTotal = "";
        /// <summary>
        /// סԺ�����ܺϼƽ��
        /// </summary>
        public string AllTotal = "";
        /// <summary>
        /// ����Ԥ����
        /// </summary>
        public string PrePayMoney = "";
        /// <summary>
        /// �������
        /// </summary>
        public string ClearTotal = "";
        /// <summary>
        /// Ƿ�����
        /// </summary>
        public string ArrearageTotal = "";
        /// <summary>
        /// ���ʽ��(һ��Ϊ�籣ͳ���)
        /// </summary>
        public string AcctTotal = "";
    }
    #endregion

    #region ������ϸVO
    /// <summary>
    /// ������ϸVO
    /// </summary>
    [Serializable]
    public class clsBihPatientCharge_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// ���˷�����ϸ��ˮ��
        /// </summary>
        public string PchargeID = "";
        /// <summary>
        /// ����ID
        /// </summary>
        public string PatientID = "";
        /// <summary>
        /// סԺ�Ǽ�id
        /// </summary>
        public string RegisterID = "";
        /// <summary>
        /// ��Ч����
        /// </summary>
        public string ActiveDat = "";
        /// <summary>
        /// ҽ����id
        /// </summary>
        public string OrderID = "";
        /// <summary>
        /// ҽ��ִ������{1=����;2=����;3=�����¿���;4=��Ժ��ҩ}
        /// </summary>
        public int OrderExecType = 0;
        /// <summary>
        /// ҽ��ִ�е�id
        /// </summary>
        public string OrderExecID = "";
        /// <summary>
        /// ���㲡��id
        /// </summary>
        public string ClacArea = "";
        /// <summary>
        /// �����ص�id
        /// </summary>
        public string CreateArea = "";
        /// <summary>
        /// ���ú������id
        /// </summary>
        public string CalcCateID = "";
        /// <summary>
        /// ���÷�Ʊ���id
        /// </summary>
        public string InvCateID = "";
        /// <summary>
        /// �շ���Ŀid
        /// </summary>
        public string ChargeItemID = "";
        /// <summary>
        /// �շ���Ŀ����
        /// </summary>
        public string ChargeItemName = "";
        /// <summary>
        /// סԺ��λ
        /// </summary>
        public string Unit = "";
        /// <summary>
        /// סԺ����
        /// </summary>
        public decimal UnitPrice = 0;
        /// <summary>
        /// ����
        /// </summary>
        public decimal Amount = 0;
        /// <summary>
        /// �ۿ۱���(�Ը�����)
        /// </summary>
        public decimal Discount = 100;
        /// <summary>
        /// �Ƿ��Է���Ŀ
        /// </summary>
        public int Ismepay = 0;
        /// <summary>
        /// ��ע
        /// </summary>
        public string Des = "";
        /// <summary>
        /// ¼������{1=�Զ�(ҽ��);2=�Զ�(�մ���);3=����(ҽ��);4=����(��ҽ��)}
        /// </summary>
        public int CreateType = 0;
        /// <summary>
        /// ¼����	
        /// </summary>
        public string Creator = "";
        /// <summary>
        /// ¼��ʱ��
        /// </summary>
        public string CreateDat = "";
        /// <summary>
        /// �޸���
        /// </summary>
        public string Operator = "";
        /// <summary>
        /// �޸�ʱ��
        /// </summary>
        public string ModifyDat = "";
        /// <summary>
        /// ɾ����
        /// </summary>
        public string Deactivator = "";
        /// <summary>
        /// ɾ��ʱ��
        /// </summary>
        public string DeactivateDat = "";
        /// <summary>
        /// ��Ч״̬{1=��Ч;0=��Ч;-1=��ʷ}
        /// </summary>
        public int Status = 0;
        /// <summary>
        /// ����״̬{0=��ȷ��;1=����;2=����;3=����;4=ֱ��}
        /// </summary>
        public int PStatus = 0;
        /// <summary>
        /// ��������
        /// </summary>
        public string ChearAccountDat = "";
        /// <summary>
        /// ����id
        /// </summary>
        public string DayaccountID = "";
        /// <summary>
        /// ���Ѽ�¼id
        /// </summary>
        public string PayMoneyID = "";
        /// <summary>
        /// ��Ч��
        /// </summary>
        public string Activator = "";
        /// <summary>
        /// ��Ч����{1=����;2=������;3=ȷ�ϼ���;4=ȷ���շ�;5=ֱ���շ�}
        /// </summary>
        public int ActivateType = 0;
        /// <summary>
        /// �Ƿ����{1/0}
        /// </summary>
        public int IsRich = 0;
        /// <summary>
        /// �Ƿ���ȷ��(�˿�){�����˷�ʱ����,1/0}
        /// </summary>
        public int IsConfirmRefundment = 0;
        /// <summary>
        /// �˿�ȷ����{�����˷�ʱ����}
        /// </summary>
        public string RefundmentChecker = "";
        /// <summary>
        /// �˿�ȷ��ʱ��{�����˷�ʱ����}
        /// </summary>
        public string RefundmentDat = "";
        /// <summary>
        /// 
        /// </summary>
        public int BmStatus = 0;
        /// <summary>
        /// �µ�ʱ�������ڲ���ID
        /// </summary>
        public string CurAreaID = "";
        /// <summary>
        /// �µ�ʱ�������ڲ���ID
        /// </summary>
        public string CurBedID = "";
        /// <summary>
        /// ����ҽ��ID
        /// </summary>
        public string DoctorID = "";
        /// <summary>
        /// ����ҽ������
        /// </summary>
        public string Doctor = "";
        /// <summary>
        /// ����ҽ�����ڹ�����ID
        /// </summary>
        public string DoctorGroupID = "";
        /// <summary>
        /// �Ƿ���Ҫ������� 0-�� 1-��
        /// </summary>
        public int NeedConfirm = 0;
        /// <summary>
        /// �����ID
        /// </summary>
        public string ConfirmerID = "";
        /// <summary>
        /// ���������
        /// </summary>
        public string Confirmer = "";
        /// <summary>
        /// ���ʱ��
        /// </summary>
        public string ConfirmDat = "";
        /// <summary>
        /// ҽ����Ϣ
        /// </summary>
        public string INSURACEDESC_VCHR = "";
        /// <summary>
        /// ���{=this.get������Ŀ.get�շ���Ŀ.���}
        /// </summary>
        public string SPEC_VCHR = "";
        /// <summary>
        /// �ϼƽ��
        /// </summary>
        public decimal TotalMoney_dec = 0;
        /// <summary>
        /// ���ʽ��
        /// </summary>
        public decimal AcctMoney_dec = 0;
        /// <summary>
        /// �¼۱����ۿ۱���(����:���鳬��8��)
        /// </summary>
        public decimal NEWDISCOUNT_DEC = 100;
        /// <summary>
        /// �Ƿ��˻�����Ŀ(0-����,1-��)
        /// </summary>
        public int PATIENTNURSE_INT = 0;
        /// <summary>
        /// ����������ĿID
        /// </summary>
        public string AttachOrderID = "";
        /// <summary>
        /// ��������Ŀ����ֵ
        /// </summary>
        public decimal AttachOrderBaseNum = 0;
        /// <summary>
        /// ��ҩ��־ 0 ����ҩ 1 ��ҩ
        /// </summary>
        public int PutMedicineFlag = 0;

        #region ���ӵķǱ��ֶ�����
        /// <summary>
        /// ��һ�ε�����
        /// </summary>
        public decimal m_decSINGLEAMOUNT_DEC = 0;
        /// <summary>
        /// ��ĿԴID����Ŀ��Դ������ҩƷ��������Ŀ�����ϵȣ������¼����Ŀ����Դ���е�Ψһ��־��
        /// </summary>
        public string m_strITEMSRCID_VCHR = "";
        /// <summary>
        /// ��Ŀ��Դ��������������Դ����ȷ��ֵ��Χ���ڲ�ʹ�á�����1��ҩƷ��2�����ϱ�ȡ�
        /// </summary>
        public int m_intITEMSRCTYPE_INT = 0;
        /// <summary>
        /// ��ҩ��ϸ����ˮ��(ҽ��ִ��������;)
        /// </summary>
        public string m_strPUTMEDREQID_CHR = "";
        /// <summary>
        /// ҩ�����ͷ���ID 1-��ҩ 2-��ҩ  3-���� 4-����ҩ
        /// </summary>
        public int m_intMEDICNETYPE_INT = 0;
        /// <summary>
        /// ��ҩ���� 0-��ҩƷ�� 1-����� 2-�ڷ���
        /// </summary>
        public int m_intPUTMEDTYPE_INT = 0;
        /// <summary>
        /// ����
        /// </summary>
        public decimal m_decDOSAGE_DEC = 0;
        /// <summary>
        /// ������λ
        /// </summary>
        public string m_strDOSAGEUNIT_CHR = "";

        #endregion
        /// <summary>
        /// ����ҽ��ID
        /// </summary>
        public string CHARGEDOCTORID_CHR = "";
        /// <summary>
        /// ����ҽ������
        /// </summary>
        public string CHARGEDOCTOR_VCHR = "";
        /// <summary>
        /// ����ҽ������רҵ��
        /// </summary>
        public string CHARGEDOCTORGROUPID_CHR = "";
    }
    #endregion

    #region ȷ�������ϢVO
    /// <summary>
    /// ȷ�������ϢVO
    /// </summary>
    [Serializable]
    public class clsBihConfirm_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// �����ID
        /// </summary>
        public string EmpId = "";
        /// <summary>
        /// ����˹���
        /// </summary>
        public string EmpNo = "";
        /// <summary>
        /// ���������
        /// </summary>
        public string EmpName = "";
        /// <summary>
        /// ����ID
        /// </summary>
        public string DeptId = "";
        /// <summary>
        /// ���Ҵ���
        /// </summary>
        public string DeptNo = "";
        /// <summary>
        /// ��������
        /// </summary>
        public string DeptName = "";
    }
    #endregion

    #region ���÷�������VO
    /// <summary>
    /// ���÷�������VO
    /// </summary>
    [Serializable]
    public class clsBihChargeItemCat_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// ��Χ: 1 ������� 2 ���﷢Ʊ 3 סԺ���� 4 סԺ��Ʊ
        /// </summary>
        public string Scope = "";
        /// <summary>
        /// ����ID
        /// </summary>
        public string CatID = "";
        /// <summary>
        /// ��������
        /// </summary>
        public string CatName = "";
        /// <summary>
        /// ���� 0 ��ͨ�� 1 ������
        /// </summary>
        public string Type = "";
        /// <summary>
        /// ������ʽ
        /// </summary>
        public string CompExp = "";
        /// <summary>
        /// ��ʾ�ؼ���
        /// </summary>
        public string DispCtl = "";
        /// <summary>
        /// ��ӡ�ؼ���
        /// </summary>
        public string PrtClt = "";
        /// <summary>
        /// ״̬ 0 ͣ�� 1 ����
        /// </summary>
        public string Status = "";
    }
    #endregion

    #region �����ʡ�ֱ�շ���(������Ŀ)VO
    /// <summary>
    /// �����ʡ�ֱ�շ���(������Ŀ)VO
    /// </summary>
    [Serializable]
    public class clsBihOrderDic_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// ͬt_opr_bih_patientcharge.orderid_chr
        /// </summary>
        public string OrderID = "";
        /// <summary>
        /// ���� 2 ������ 5 ֱ���շ�
        /// </summary>
        public int Type = 1;
        /// <summary>
        /// �����
        /// </summary>
        public int OrderQue = 0;
        /// <summary>
        /// ������ĿID
        /// </summary>
        public string OrderDicID = "";
        /// <summary>
        /// ������Ŀ����
        /// </summary>
        public string OrderDicName = "";
        /// <summary>
        /// ���
        /// </summary>
        public string Spec = "";
        /// <summary>
        /// ����
        /// </summary>
        public decimal Qty = 0;
        /// <summary>
        /// ����
        /// </summary>
        public decimal PriceMny = 0;
        /// <summary>
        /// ���
        /// </summary>
        public decimal TotalMny = 0;
        /// <summary>
        /// ����������ĿID
        /// </summary>
        public string AttachOrderID = "";
        /// <summary>
        /// ��������Ŀ����ֵ
        /// </summary>
        public decimal AttachOrderBaseNum = 1;
        /// <summary>
        /// �Ը�������
        /// </summary>
        public decimal SbBaseMny = 0;
    }
    #endregion

    #region �˿�VO
    /// <summary>
    /// �˿�VO
    /// </summary>
    [Serializable]
    public class clsBihRefCharge_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// ������ϸID
        /// </summary>
        public string PChargeID = "";
        /// <summary>
        /// �˿�����
        /// </summary>
        public decimal RefAmount = 0;
        /// <summary>
        /// ����
        /// </summary>
        public decimal RefPrice = 0;
    }
    #endregion

    #region ��ʾ������ĿVO
    /// <summary>
    /// ��ʾ������ĿVO
    /// </summary>
    [Serializable]
    public class clsParmDiagItem_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// �շ���ϸID
        /// </summary>
        public string PchargeID = "";
        /// <summary>
        /// ������ĿID
        /// </summary>
        public string DiagID = "";
        /// <summary>
        /// ������Ŀ����
        /// </summary>
        public string DiagName = "";
        /// <summary>
        /// ִ��ID
        /// </summary>
        public string ExecID = "";
    }
    #endregion

    #region ����Ĭ�ϼ�����ĿVO
    /// <summary>
    /// ����Ĭ�ϼ�����ĿVO
    /// </summary>
    [Serializable]
    public class clsOutPatientDefaultAddItem_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// ����ʱ������ID
        /// </summary>
        public string Sid = "";
        /// <summary>
        /// ���(�ѱ�)ID
        /// </summary>
        public string PayTypeID = "";
        /// <summary>
        /// �շ���ĿID
        /// </summary>
        public string ItemID = "";
        /// <summary>
        /// ����
        /// </summary>
        public decimal Qty = 0;
        /// <summary>
        /// �Һű�־�� 0 ȫ�� 1 �ѹҺ� 2 δ�Һ�
        /// </summary>
        public int RegFlag = 0;
        /// <summary>
        /// ������־�� 0 ȫ�� 1 ���� 2 ����
        /// </summary>
        public int RecFlag = 0;
        /// <summary>
        /// ְ��ID:  00 ȫ�� ...
        /// </summary>
        public string DutyID = "";
        /// <summary>
        /// (ÿ��)��ʼʱ��
        /// </summary>
        public string BeginTime = "";
        /// <summary>
        /// (ÿ��)����ʱ��
        /// </summary>
        public string EndTime = "";
    }
    #endregion

    #region ͨ�ò�ѯ����VO��
    /// <summary>
    /// ͨ�ò�ѯ����VO��
    /// </summary>
    [Serializable]
    public class clsCommonQueryDate_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// ʱ���ѯģʽ 0 ����ʱ���ѯ 1 ����Ժ���� 2 ����Ժ���� 3 ����Ժ����+��Ժ����
        /// </summary>
        public int QueryType = 0;
        /// <summary>
        /// ��Ժ��ʼ����
        /// </summary>
        public string BeginDate_In = "";
        /// <summary>
        /// ��Ժ��������
        /// </summary>
        public string EndDate_In = "";
        /// <summary>
        /// ��Ժ��ʼ����
        /// </summary>
        public string BeginDate_Out = "";
        /// <summary>
        /// ��Ժ��������
        /// </summary>
        public string EndDate_Out = "";
    }
    #endregion

    #region ������Ϣ������VO
    /// <summary>
    /// ������Ϣ������VO
    /// </summary>
    [Serializable]
    public class clsHospRecordCS_Vo : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// ����
        /// </summary>
        public string m_strName = string.Empty;
        /// <summary>
        /// �Ա�
        /// </summary>
        public string m_strSex = string.Empty;
        /// <summary>
        /// ��������
        /// </summary>
        public string m_strKind = string.Empty;
        /// <summary>
        /// ����
        /// </summary>
        public string m_strEthnicGroup = string.Empty;
        /// <summary>
        /// סַ
        /// </summary>
        public string m_strAddress = string.Empty;
        /// <summary>
        /// ������λ
        /// </summary>
        public string m_strJobTitle = string.Empty;
        /// <summary>
        /// ��ϵ�绰
        /// </summary>
        public string m_strPhoneNum = string.Empty;
        /// <summary>
        /// ��ϵ��
        /// </summary>
        public string m_strContactPerson = string.Empty;
        /// <summary>
        /// ����
        /// </summary>
        public string m_strNationality = string.Empty;
        /// <summary>
        /// ����
        /// </summary>
        public string m_strMaritalStatus = string.Empty;
        /// <summary>
        /// ��������
        /// </summary>
        public DateTime m_dtmBirthDay = DateTime.Now;
        /// <summary>
        /// ���֤��
        /// </summary>
        public string m_strIDNumber = string.Empty;
        /// <summary>
        /// ���ƿ���
        /// </summary>
        public string m_strSSID = string.Empty;
        /// <summary>
        /// סԺ��
        /// </summary>
        public string m_strInHospNO = string.Empty;
        /// <summary>
        /// סԺ����
        /// </summary>
        public int m_intInHospCount = 1;
        /// <summary>
        /// ��ˮ��
        /// </summary>
        public string m_strRegisterID = string.Empty;
        /// <summary>
        /// �����
        /// </summary>
        public string m_strClinicID = string.Empty;
        /// <summary>
        /// ����
        /// </summary>
        public string m_strBedNO = string.Empty;
        /// <summary>
        /// ��Ժ����Code
        /// </summary>
        public string m_strInDeptCode = string.Empty;
        /// <summary>
        /// ��Ժ����Name
        /// </summary>
        public string m_strInDeptName = string.Empty;
        /// <summary>
        /// ��Ժ����Code
        /// </summary>
        public string m_strOutDeptCode = string.Empty;
        /// <summary>
        /// ��Ժ����Name
        /// </summary>
        public string m_strOutDeptName = string.Empty;
        /// <summary>
        /// ����ҽ��ID
        /// </summary>
        public string m_strMainDoctorID = string.Empty;
        /// <summary>
        /// ����ҽ��Name
        /// </summary>
        public string m_strMainDoctorName = string.Empty;
        /// <summary>
        /// ����ҽ��ID
        /// </summary>
        public string m_strInHospDoctorID = string.Empty;
        /// <summary>
        /// ����ҽ��Name
        /// </summary>
        public string m_strInHospDoctorName = string.Empty;
        /// <summary>
        /// ��Ժ����
        /// </summary>
        public DateTime m_dtmInDate = DateTime.Now;
        /// <summary>
        /// ��Ժ����
        /// </summary>
        public DateTime m_dtmOutDate = DateTime.Now;
        /// <summary>
        /// ȷ������
        /// </summary>
        public DateTime m_dtmConfirmDate = DateTime.Now;
        /// <summary>
        /// סԺ����
        /// </summary>
        public int m_intHospDay = 0;
        /// <summary>
        /// ��Ժ���Code
        /// </summary>
        public string m_strInDiagnosCode = string.Empty;
        /// <summary>
        /// ��Ժ���Name
        /// </summary>
        public string m_strInDiagnosName = string.Empty;
        /// <summary>
        /// ��Ժ���Code
        /// </summary>
        public string m_strOutDiagnosCode = string.Empty;
        /// <summary>
        /// ��Ժ���Name
        /// </summary>
        public string m_strOutDiagnosName = string.Empty;
        /// <summary>
        /// ֢״
        /// </summary>
        public string m_strSymptom = string.Empty;
        /// <summary>
        /// ȡ��
        /// </summary>
        public int m_intCancel = 0;
        /// <summary>
        /// ת�����
        /// </summary>
        public string m_strStatus = string.Empty;
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime m_dtmInAreaTime = DateTime.Now;

        public string m_strBirthPlace = string.Empty;
    }

    /// <summary>
    /// סԺ�շѵ�
    /// </summary>
    [Serializable]
    public class clsHospBillCS_Vo : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// ��ˮ��
        /// </summary>
        public string m_strRegisterID = string.Empty;
        /// <summary>
        /// ��Ʊ��
        /// </summary>
        public string m_strInvoNo = string.Empty;
        /// <summary>
        /// �ܽ��
        /// </summary>
        public decimal m_dclInvoTotolMoney = 0m;
        /// <summary>
        /// �Ը����
        /// </summary>
        public decimal m_dclInvoFSPMoney = 0m;
        /// <summary>
        /// ��ʼʱ��
        /// </summary>
        public DateTime m_dtmBeginDate = DateTime.Now;
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime m_dtmEndDate = DateTime.Now;
        /// <summary>
        /// ��Ʊʱ��
        /// </summary>
        public DateTime m_dtmBillDate = DateTime.Now;
        /// <summary>
        /// �ѱ�
        /// </summary>
        public string m_strKind = string.Empty;
        /// <summary>
        /// �������
        /// </summary>
        public string m_strFareCode = string.Empty;
        /// <summary>
        /// ��������
        /// </summary>
        public string m_strFareName = string.Empty;
        /// <summary>
        /// ����
        /// </summary>
        public decimal m_intAmount = 0;
        /// <summary>
        /// ����
        /// </summary>
        public decimal m_dclPrice = 0m;
        /// <summary>
        /// �ܽ��
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
        /// ��ͳһ����
        /// </summary>
        public string m_strITEMID = string.Empty;
        /// <summary>
        /// ҽ��ִ��ʱ��
        /// </summary>
        public DateTime m_dtEXECUTEDATE= DateTime.Now;
        /// <summary>
        /// �������Ҵ���
        /// </summary>
        public string m_strDEPCODE = string.Empty;
        /// <summary>
        /// ������������
        /// </summary>
        public string m_strDEPNAME = string.Empty;

    }

    /// <summary>
    /// ҽ����Ϣ
    /// </summary>
    [Serializable]
    public class clsHospOrderCS_Vo : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// ҽ�����
        /// </summary>
        public string m_strOrderNo = string.Empty;
        /// <summary>
        /// סԺ���
        /// </summary>
        public string m_strRegisterID = string.Empty;
        /// <summary>
        /// ҽ�������
        /// </summary> 
        public string m_strOrderSubNo = string.Empty;
        /// <summary>
        /// ҽ����ʼ��Чʱ��
        /// </summary>
        public DateTime m_dtmStart = DateTime.Now;
        /// <summary>
        /// ����ҽ����־
        /// </summary>
        public string m_strLongOrder = string.Empty;
        /// <summary>
        /// ҽ�����
        /// </summary>
        public string m_strOrderClass = string.Empty;
        /// <summary>
        /// ҽ��״̬
        /// </summary>
        public int m_intOrderStauts = 0;
        /// <summary>
        /// ҽ������
        /// </summary>
        public string m_strOrderText = string.Empty;
        /// <summary>
        /// ҽ������
        /// </summary>
        public string m_strOrderID = string.Empty;
        /// <summary>
        /// ��ʼ���ڼ�ʱ��
        /// </summary>
        public DateTime m_dtmStartExec = DateTime.Now;
        /// <summary>
        /// ֹͣ���ڼ�ʱ��
        /// </summary>
        public DateTime m_dtmStop = DateTime.Now;
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public string m_strDuration = string.Empty;
        /// <summary>
        /// ����ʱ�䵥λ
        /// </summary>
        public string m_strDuration_Units = string.Empty;
        /// <summary>
        /// ִ��Ƶ������
        /// </summary>
        public string m_strFrequencyName = string.Empty;
        /// <summary>
        /// Ƶ�ʴ���
        /// </summary>
        public int m_strFreq_Counter = 0;
        /// <summary>
        /// Ƶ�ʼ��
        /// </summary>
        public string m_strFreq_Interval = string.Empty;
        /// <summary>
        /// Ƶ�ʼ����λ
        /// </summary>
        public string m_strFreq_Interval_Unit = string.Empty;
        /// <summary>
        /// ִ��ʱ����ϸ����
        /// </summary>
        public string m_strFreq_Detail = string.Empty;
        /// <summary>
        /// ��ʿִ��ʱ��
        /// </summary>
        public string m_strPerform_Schedule = string.Empty;
        /// <summary>
        /// ִ�н��
        /// </summary>
        public string m_strPerform_Resul = string.Empty;
        /// <summary>
        /// ��ҽ��ҽ��
        /// </summary>
        public string m_strCreateDoctor = string.Empty;
        /// <summary>
        /// ��ҽ������
        /// </summary>
        public string m_strCreateDept = string.Empty;
        /// <summary>
        /// ͣҽ��ҽ��
        /// </summary>
        public string m_strStopDoctor = string.Empty;
        /// <summary>
        /// ͣ��ҽ������
        /// </summary>
        public string m_strStopDoctorName = string.Empty;
        /// <summary>
        /// ��ҽ��У�Ի�ʿ
        /// </summary>
        public string m_strConfirmNurser = string.Empty;
        /// <summary>
        /// ͣҽ��У�Ի�ʿ
        /// </summary>
        public string m_strStopConfirmNurser = string.Empty;
        /// <summary>
        /// �´�ҽ�����ڼ�ʱ��
        /// </summary>
        public DateTime m_dtmStartDT = DateTime.Now;
        /// <summary>
        /// ¼��ҽ�����ڼ�ʱ��
        /// </summary>
        public DateTime m_dtmRecordDT = DateTime.Now;
        /// <summary>
        /// ͣҽ��¼�����ڼ�ʱ��
        /// </summary>
        public DateTime m_dtmStopDT = DateTime.Now;
        /// <summary>
        /// �������ڼ�ʱ��
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
        /// ��ͳһ����
        /// </summary>
        public string m_strITEMID = string.Empty;
        /// <summary>
        /// ����
        /// </summary>
        public int m_intDays = 0;
        /// <summary>
        /// ���ͱ�־����:01 �ڷ� 02 ע�� 03 �ֲ���ҩ 99 ���� ����2����Ϊ��
        /// </summary>
        public string m_strJXBZDM = "99";
    }
    #endregion 

    //Start====qinhong====��Ӳ�����ҳ������VO����ƽ��==================
    #region ������ҳ�ӿ�
    /// <summary>
    /// ������ҳ�ӿ�
    /// </summary>
    [Serializable]
    public class clsFirstPageVO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// ��������;
        /// </summary>
        public string m_strjgdm = string.Empty;

        /// <summary>
        /// ��ˮ��;
        /// </summary>
        public string m_strfid = string.Empty;

        /// <summary>
        /// ������;
        /// </summary>
        public string m_strfprn = string.Empty;

        /// <summary>
        /// סԺ����;
        /// </summary>
        public string m_strftimes = string.Empty;

        /// <summary>
        /// ICD�汾;
        /// </summary>
        public string m_strficdversion = string.Empty;

        /// <summary>
        /// סԺ��ˮ��;
        /// </summary>
        public string m_strfzyid = string.Empty;

        /// <summary>
        /// ����;
        /// </summary>
        public string m_strfage = string.Empty;

        /// <summary>
        /// ��������;
        /// </summary>
        public string m_strfname = string.Empty;

        /// <summary>
        /// �Ա���;
        /// </summary>
        public string m_strfsexbh = string.Empty;

        /// <summary>
        /// �Ա�;
        /// </summary>
        public string m_strfsex = string.Empty;

        /// <summary>
        /// ��������;
        /// </summary>
        public DateTime m_strfbirthday = DateTime.MinValue;

        /// <summary>
        /// ������;
        /// </summary>
        public string m_strfbirthplace = string.Empty;

        /// <summary>
        /// ���֤��;
        /// </summary>
        public string m_strfidcard = string.Empty;

        /// <summary>
        /// �������;
        /// </summary>
        public string m_strfcountrybh = string.Empty;

        /// <summary>
        /// ����;
        /// </summary>
        public string m_strfcountry = string.Empty;

        /// <summary>
        /// ������;
        /// </summary>
        public string m_strfnationalitybh = string.Empty;

        /// <summary>
        /// ����;
        /// </summary>
        public string m_strfnationality = string.Empty;

        /// <summary>
        /// ְҵ;
        /// </summary>
        public string m_strfjob = string.Empty;

        /// <summary>
        /// ����״�����;
        /// </summary>
        public string m_strfstatusbh = string.Empty;

        /// <summary>
        /// ����״��;
        /// </summary>
        public string m_strfstatus = string.Empty;

        /// <summary>
        /// ��λ����;
        /// </summary>
        public string m_strfdwname = string.Empty;

        /// <summary>
        /// ��λ��ַ;
        /// </summary>
        public string m_strfdwaddr = string.Empty;

        /// <summary>
        /// ��λ�绰;
        /// </summary>
        public string m_strfdwtele = string.Empty;

        /// <summary>
        /// ��λ�ʱ�;
        /// </summary>
        public string m_strfdwpost = string.Empty;

        /// <summary>
        /// ���ڵ�ַ;
        /// </summary>
        public string m_strfhkaddr = string.Empty;

        /// <summary>
        /// �����ʱ�;
        /// </summary>
        public string m_strfhkpost = string.Empty;

        /// <summary>
        /// ��ϵ��;
        /// </summary>
        public string m_strflxname = string.Empty;

        /// <summary>
        /// �벡�˹�ϵ;
        /// </summary>
        public string m_strfrelate = string.Empty;

        /// <summary>
        /// ��ϵ�˵�ַ;
        /// </summary>
        public string m_strflxaddr = string.Empty;

        /// <summary>
        /// ��ϵ�˵绰;
        /// </summary>
        public string m_strflxtele = string.Empty;

        /// <summary>
        /// ���ʽ���;
        /// </summary>
        public string m_strffbbh = string.Empty;

        /// <summary>
        /// ���ʽ;
        /// </summary>
        public string m_strffb = string.Empty;

        /// <summary>
        /// ����ҽ�Ʊ��տ���;
        /// </summary>
        public string m_strfascard1 = string.Empty;

        /// <summary>
        /// ����ҽ�Ʊ��տ���;
        /// </summary>
        public string m_strfascard2 = string.Empty;

        /// <summary>
        /// ��Ժ����;
        /// </summary>
        public DateTime m_strfrydate = DateTime.MinValue;

        /// <summary>
        /// ��Ժʱ��;
        /// </summary>
        public string m_strfrytime = string.Empty;

        /// <summary>
        /// ��Ժͳһ�ƺ�;
        /// </summary>
        public string m_strfrytykh = string.Empty;

        /// <summary>
        /// ��Ժ�Ʊ�;
        /// </summary>
        public string m_strfrydept = string.Empty;

        /// <summary>
        /// ��Ժ����;
        /// </summary>
        public string m_strfrybs = string.Empty;

        /// <summary>
        /// ��Ժ����;
        /// </summary>
        public DateTime m_strfcydate = DateTime.MinValue;

        /// <summary>
        /// ��Ժʱ��;
        /// </summary>
        public string m_strfcytime = string.Empty;

        /// <summary>
        /// ��Ժͳһ�ƺ�;
        /// </summary>
        public string m_strfcytykh = string.Empty;

        /// <summary>
        /// ��Ժ�Ʊ�;
        /// </summary>
        public string m_strfcydept = string.Empty;

        /// <summary>
        /// ��Ժ����;
        /// </summary>
        public string m_strfcybs = string.Empty;

        /// <summary>
        /// ʵ��סԺ����;
        /// </summary>
        public int m_Intfdays = 0;

        /// <summary>
        /// �ţ����������(ICD10��ICD9)����;
        /// </summary>
        public string m_strfmzzdbh = string.Empty;

        /// <summary>
        /// �ţ����������(ICD10��ICD9)��Ӧ������;
        /// </summary>
        public string m_strfmzzd0 = string.Empty;

        /// <summary>
        /// �š�����ҽ�����;
        /// </summary>
        public string m_strfmzdoctbh = string.Empty;

        /// <summary>
        /// �š�����ҽ��;
        /// </summary>
        public string m_strfmzdoct = string.Empty;

        /// <summary>
        /// ��Ժʱ������;
        /// </summary>
        public string m_strfryinfobh = string.Empty;

        /// <summary>
        /// ��Ժʱ���;
        /// </summary>
        public string m_strfryinfo = string.Empty;

        /// <summary>
        /// ��Ժ���(ICD10��ICD9)����;
        /// </summary>
        public string m_strfryzdbh = string.Empty;

        /// <summary>
        /// ��Ժ���(ICD10��ICD9)��Ӧ������;
        /// </summary>
        public string m_strfryzd0 = string.Empty;

        /// <summary>
        /// ȷ������;
        /// </summary>
        public DateTime m_strfqzdate = DateTime.MinValue;

        /// <summary>
        /// �������;
        /// </summary>
        public string m_strfphzd0 = string.Empty;

        /// <summary>
        /// ����ҩ��;
        /// </summary>
        public string m_strfgmyw0 = string.Empty;

        /// <summary>
        /// HBsAg���;
        /// </summary>
        public string m_strfhbsagbh = string.Empty;

        /// <summary>
        /// HBsAg;
        /// </summary>
        public string m_strfhbsag = string.Empty;

        /// <summary>
        /// HCV-Ab���;
        /// </summary>
        public string m_strfhcvabbh = string.Empty;

        /// <summary>
        /// HCV-Ab;
        /// </summary>
        public string m_strfhcvab = string.Empty;

        /// <summary>
        /// HIV-AB���;
        /// </summary>
        public string m_strfhivabbh = string.Empty;

        /// <summary>
        /// HIV-Ab;
        /// </summary>
        public string m_strfhivab = string.Empty;

        /// <summary>
        /// �������Ժ��Ϸ���������;
        /// </summary>
        public string m_strfmzcyaccobh = string.Empty;

        /// <summary>
        /// �������Ժ��Ϸ���;
        /// </summary>
        public string m_strfmzcyacco = string.Empty;

        /// <summary>
        /// ��Ժ���Ժ��Ϸ���������;
        /// </summary>
        public string m_strfrycyaccobh = string.Empty;

        /// <summary>
        /// ��Ժ���Ժ��Ϸ���;
        /// </summary>
        public string m_strfrycyacco = string.Empty;

        /// <summary>
        /// �ٴ��벡����Ϸ���������;
        /// </summary>
        public string m_strflcblaccobh = string.Empty;

        /// <summary>
        /// �ٴ��벡����Ϸ���;
        /// </summary>
        public string m_strflcblacco = string.Empty;

        /// <summary>
        /// �����벡����Ϸ���������;
        /// </summary>
        public string m_strffsblaccobh = string.Empty;

        /// <summary>
        /// �����벡����Ϸ������;
        /// </summary>
        public string m_strffsblacco = string.Empty;

        /// <summary>
        /// �������ϱ��;
        /// </summary>
        public string m_strfopaccobh = string.Empty;

        /// <summary>
        /// ��������;
        /// </summary>
        public string m_strfopacco = string.Empty;

        /// <summary>
        /// ���ȴ���;
        /// </summary>
        public int m_Intfqjtimes = 0;

        /// <summary>
        /// ���ȳɹ�����;
        /// </summary>
        public int m_Intfqjsuctimes = 0;

        /// <summary>
        /// �����α��;
        /// </summary>
        public string m_strfkzrbh = string.Empty;

        /// <summary>
        /// ������;
        /// </summary>
        public string m_strfkzr = string.Empty;

        /// <summary>
        /// ������������ҽ�����;
        /// </summary>
        public string m_strfzrdoctbh = string.Empty;

        /// <summary>
        /// ������������ҽ��;
        /// </summary>
        public string m_strfzrdoctor = string.Empty;

        /// <summary>
        /// ����ҽ�����;
        /// </summary>
        public string m_strfzzdoctbh = string.Empty;

        /// <summary>
        /// ����ҽ��;
        /// </summary>
        public string m_strfzzdoct = string.Empty;

        /// <summary>
        /// סԺҽ�����;
        /// </summary>
        public string m_strfzydoctbh = string.Empty;

        /// <summary>
        /// סԺҽ��;
        /// </summary>
        public string m_strfzydoct = string.Empty;

        /// <summary>
        /// ����ҽʦ���;
        /// </summary>
        public string m_strfjxdoctbh = string.Empty;

        /// <summary>
        /// ����ҽʦ;
        /// </summary>
        public string m_strfjxdoct = string.Empty;

        /// <summary>
        /// �о���ʵϰҽʦ���;
        /// </summary>
        public string m_strfyjssxdoctbh = string.Empty;

        /// <summary>
        /// �о���ʵϰҽʦ;
        /// </summary>
        public string m_strfyjssxdoct = string.Empty;

        /// <summary>
        /// ʵϰҽ�����;
        /// </summary>
        public string m_strfsxdoctbh = string.Empty;

        /// <summary>
        /// ʵϰҽ��;
        /// </summary>
        public string m_strfsxdoct = string.Empty;

        /// <summary>
        /// ����Ա���;
        /// </summary>
        public string m_strfbmybh = string.Empty;

        /// <summary>
        /// ����Ա;
        /// </summary>
        public string m_strfbmy = string.Empty;

        /// <summary>
        /// ���������߱��;
        /// </summary>
        public string m_strfzlrbh = string.Empty;

        /// <summary>
        /// ����������;
        /// </summary>
        public string m_strfzlr = string.Empty;

        /// <summary>
        /// �����������;
        /// </summary>
        public string m_strfqualitybh = string.Empty;

        /// <summary>
        /// ��������;
        /// </summary>
        public string m_strfquality = string.Empty;

        /// <summary>
        /// �ʿ�ҽʦ���;
        /// </summary>
        public string m_strfzkdoctbh = string.Empty;

        /// <summary>
        /// �ʿ�ҽʦ;
        /// </summary>
        public string m_strfzkdoct = string.Empty;

        /// <summary>
        /// �ʿػ�ʿ���;
        /// </summary>
        public string m_strfzknursebh = string.Empty;

        /// <summary>
        /// �ʿػ�ʿ;
        /// </summary>
        public string m_strfzknurse = string.Empty;

        /// <summary>
        /// �ʿ�����;
        /// </summary>
        public DateTime m_strfzkrq = DateTime.MinValue;

        /// <summary>
        /// �Ƿ��������������;
        /// </summary>
        public string m_strfmzdeadbh = string.Empty;

        /// <summary>
        /// �Ƿ�����������;
        /// </summary>
        public string m_strfmzdead = string.Empty;

        /// <summary>
        /// �ܷ���;
        /// </summary>
        public double m_Dblfsum1 = 0;

        /// <summary>
        /// ��λ��;
        /// </summary>
        public double m_Dblfcwf = 0;

        /// <summary>
        /// �����;
        /// </summary>
        public double m_Dblfhlf = 0;

        /// <summary>
        /// ��ҩ��;
        /// </summary>
        public double m_Dblfxyf = 0;

        /// <summary>
        /// ��ҩ��;
        /// </summary>
        public double m_Dblfzyf = 0;

        /// <summary>
        /// �г�ҩ��;
        /// </summary>
        public double m_Dblfzchyf = 0;

        /// <summary>
        /// �в�ҩ��;
        /// </summary>
        public double m_Dblfzcyf = 0;

        /// <summary>
        /// �����;
        /// </summary>
        public double m_Dblffsf = 0;

        /// <summary>
        /// �����;
        /// </summary>
        public double m_Dblfhyf = 0;

        /// <summary>
        /// ������;
        /// </summary>
        public double m_Dblfsyf = 0;

        /// <summary>
        /// ��Ѫ��;
        /// </summary>
        public double m_Dblfsxf = 0;

        /// <summary>
        /// ���Ʒ�;
        /// </summary>
        public double m_Dblfzlf = 0;

        /// <summary>
        /// ������;
        /// </summary>
        public double m_Dblfssf = 0;

        /// <summary>
        /// ������;
        /// </summary>
        public double m_Dblfjsf = 0;

        /// <summary>
        /// ����;
        /// </summary>
        public double m_Dblfjcf = 0;

        /// <summary>
        /// �����;
        /// </summary>
        public double m_Dblfmzf = 0;

        /// <summary>
        /// Ӥ����;
        /// </summary>
        public double m_Dblfyef = 0;

        /// <summary>
        /// �㴲��;
        /// </summary>
        public double m_Dblfpcf = 0;

        /// <summary>
        /// ������;
        /// </summary>
        public double m_Dblfqtf = 0;

        /// <summary>
        /// �Ƿ�ʬ����;
        /// </summary>
        public string m_strfbodybh = string.Empty;

        /// <summary>
        /// �Ƿ�ʬ��;
        /// </summary>
        public string m_strfbody = string.Empty;

        /// <summary>
        /// �Ƿ������������;
        /// </summary>
        public string m_strfisopfirstbh = string.Empty;

        /// <summary>
        /// �Ƿ���������;
        /// </summary>
        public string m_strfisopfirst = string.Empty;

        /// <summary>
        /// �Ƿ��������Ʊ��;
        /// </summary>
        public string m_strfiszlfirstbh = string.Empty;

        /// <summary>
        /// �Ƿ���������;
        /// </summary>
        public string m_strfiszlfirst = string.Empty;

        /// <summary>
        /// �Ƿ����������;
        /// </summary>
        public string m_strfisjcfirstbh = string.Empty;

        /// <summary>
        /// �Ƿ��������;
        /// </summary>
        public string m_strfisjcfirst = string.Empty;

        /// <summary>
        /// �Ƿ�������ϱ��;
        /// </summary>
        public string m_strfiszdfirstbh = string.Empty;

        /// <summary>
        /// �Ƿ��������;
        /// </summary>
        public string m_strfiszdfirst = string.Empty;

        /// <summary>
        /// �Ƿ�������;
        /// </summary>
        public string m_strfisszbh = string.Empty;

        /// <summary>
        /// �Ƿ�����;
        /// </summary>
        public string m_strfissz = string.Empty;

        /// <summary>
        /// ��������;
        /// </summary>
        public string m_strfszqx = string.Empty;

        /// <summary>
        /// �Ƿ�ʾ�̲������;
        /// </summary>
        public string m_strfsamplebh = string.Empty;

        /// <summary>
        /// �Ƿ�ʾ�̲���;
        /// </summary>
        public string m_strfsample = string.Empty;

        /// <summary>
        /// Ѫ�ͱ��;
        /// </summary>
        public string m_strfbloodbh = string.Empty;

        /// <summary>
        /// Ѫ��;
        /// </summary>
        public string m_strfblood = string.Empty;

        /// <summary>
        /// RH���;
        /// </summary>
        public string m_strfrhbh = string.Empty;

        /// <summary>
        /// RH;
        /// </summary>
        public string m_strfrh = string.Empty;

        /// <summary>
        /// ��Ѫ��Ӧ���;
        /// </summary>
        public string m_strfsxfybh = string.Empty;

        /// <summary>
        /// ��Ѫ��Ӧ;
        /// </summary>
        public string m_strfsxfy = string.Empty;

        /// <summary>
        /// ��Һ��Ӧ���;
        /// </summary>
        public string m_strfsyfybh = string.Empty;

        /// <summary>
        /// ��Һ��Ӧ;
        /// </summary>
        public string m_strfsyfy = string.Empty;

        /// <summary>
        /// ��ѪƷ�ֺ�ϸ������;
        /// </summary>
        public double m_Dblfredcell = 0;

        /// <summary>
        /// ѪС��
        /// </summary>
        public double m_Dblfplaque = 0;

        /// <summary>
        /// Ѫ��;
        /// </summary>
        public double m_Dblfserous = 0;

        /// <summary>
        /// ȫѪ;
        /// </summary>
        public double m_Dblfallblood = 0;

        /// <summary>
        /// ����;
        /// </summary>
        public double m_Dblfotherblood = 0;

        /// <summary>
        /// Ժ�ʻ���Σ�;
        /// </summary>
        public int m_Intfhzyj = 0;

        /// <summary>
        /// Զ�̻���Σ�;
        /// </summary>
        public int m_Intfhzyc = 0;

        /// <summary>
        /// �ؼ�����Сʱ��;
        /// </summary>
        public int m_Intfhltj = 0;

        /// <summary>
        /// I�������գ�;
        /// </summary>
        public int m_Intfhl1 = 0;

        /// <summary>
        /// II�������գ�;
        /// </summary>
        public int m_Intfhl2 = 0;

        /// <summary>
        /// III�������գ�;
        /// </summary>
        public int m_Intfhl3 = 0;

        /// <summary>
        /// ����໤��Сʱ��;
        /// </summary>
        public int m_Intfhlzz = 0;

        /// <summary>
        /// ���⻤���գ�;
        /// </summary>
        public int m_Intfhlts = 0;

        /// <summary>
        /// Ӥ����;
        /// </summary>
        public int m_Intfbabynum = 0;

        /// <summary>
        /// �Ƿ񲿷ֲ���;
        /// </summary>
        public string m_strftwill = string.Empty;

        /// <summary>
        /// �Ƿ����Ȳ���;
        /// </summary>
        public string m_strfqjbr = string.Empty;

        /// <summary>
        /// �Ƿ����ȳɹ�;
        /// </summary>
        public string m_strfqjsuc = string.Empty;

        /// <summary>
        /// �Ƿ�����ȷ��;
        /// </summary>
        public string m_strfthreqz = string.Empty;

        /// <summary>
        /// �Ƿ������ٴ�סԺ;
        /// </summary>
        public string m_strfback = string.Empty;

        /// <summary>
        /// �Ƿ��ж�����;
        /// </summary>
        public string m_strfifzdss = string.Empty;

        /// <summary>
        /// �Ƿ񵥲���;
        /// </summary>
        public string m_strfifdbz = string.Empty;

        /// <summary>
        /// ��ҽԺ���Ʒ�(Ԥ���ֶ�);
        /// </summary>
        public double m_Dblfzlfzy = 0;

        /// <summary>
        /// �״�ת��ͳһ�ƺ�;
        /// </summary>
        public string m_strfzktykh = string.Empty;

        /// <summary>
        /// �״�ת�ƿƱ�;
        /// </summary>
        public string m_strfzkdept = string.Empty;

        /// <summary>
        /// �״�ת������;
        /// </summary>
        public DateTime m_strfzkdate = DateTime.MinValue;

        /// <summary>
        /// �״�ת��ʱ��;
        /// </summary>
        public string m_strfzktime = string.Empty;

        /// <summary>
        /// ����Ա���;
        /// </summary>
        public string m_strfsrybh = string.Empty;

        /// <summary>
        /// ����Ա;
        /// </summary>
        public string m_strfsry = string.Empty;

        /// <summary>
        /// ��������;
        /// </summary>
        public DateTime m_strDateTime = DateTime.MinValue;

        /// <summary>
        /// �������ͱ��;
        /// </summary>
        public string m_strfjbfxbh = string.Empty;

        /// <summary>
        /// ��������;
        /// </summary>
        public string m_strfjbfx = string.Empty;

        /// <summary>
        /// ���Ϲ鵵���;
        /// </summary>
        public string m_strffhgdbh = string.Empty;

        /// <summary>
        /// ���Ϲ鵵;
        /// </summary>
        public string m_strffhgd = string.Empty;

        /// <summary>
        /// ������Դ���;
        /// </summary>
        public string m_strfsourcebh = string.Empty;

        /// <summary>
        /// ������Դ;
        /// </summary>
        public string m_strfsource = string.Empty;

        /// <summary>
        /// �Ƿ�����;
        /// </summary>
        public string m_strfifss = string.Empty;

        /// <summary>
        /// �Ƿ����븾Ӥ��;
        /// </summary>
        public string m_strfiffyk = string.Empty;

        /// <summary>
        /// �Ƿ񲢷�֢;
        /// </summary>
        public string m_strfbfz = string.Empty;

        /// <summary>
        /// ҽԺ��Ⱦ����;
        /// </summary>
        public int m_Intfyngr = 0;

        /// <summary>
        /// ״̬;
        /// </summary>
        public string m_strfflag = string.Empty;

        /// <summary>
        /// ������֤;
        /// </summary>
        public string m_strfdatacheck = string.Empty;

        /// <summary>
        /// ��չ1;
        /// </summary>
        public string m_strfextend1 = string.Empty;

        /// <summary>
        /// ��չ2;
        /// </summary>
        public string m_strfextend2 = string.Empty;

        /// <summary>
        /// ��չ3;
        /// </summary>
        public string m_strfextend3 = string.Empty;

        /// <summary>
        /// ��չ4;
        /// </summary>
        public string m_strfextend4 = string.Empty;

        /// <summary>
        /// ��չ5;
        /// </summary>
        public string m_strfextend5 = string.Empty;

        /// <summary>
        /// ��չ6;
        /// </summary>
        public string m_strfextend6 = string.Empty;

        /// <summary>
        /// ��չ7;
        /// </summary>
        public string m_strfextend7 = string.Empty;

        /// <summary>
        /// ��չ8;
        /// </summary>
        public string m_strfextend8 = string.Empty;

        /// <summary>
        /// ��չ9;
        /// </summary>
        public string m_strfextend9 = string.Empty;

        /// <summary>
        /// ��չ10;
        /// </summary>
        public string m_strfextend10 = string.Empty;

        /// <summary>
        /// ��չ11;
        /// </summary>
        public string m_strfextend11 = string.Empty;

        /// <summary>
        /// ��չ12;
        /// </summary>
        public string m_strfextend12 = string.Empty;

        /// <summary>
        /// ��չ13;
        /// </summary>
        public string m_strfextend13 = string.Empty;

        /// <summary>
        /// ��չ14;
        /// </summary>
        public string m_strfextend14 = string.Empty;

        /// <summary>
        /// ��չ15;
        /// </summary>
        public string m_strfextend15 = string.Empty;

        /// <summary>
        /// ����;
        /// </summary>
        public string m_strfnative = string.Empty;

        /// <summary>
        /// ��סַ;
        /// </summary>
        public string m_strfcurraddr = string.Empty;

        /// <summary>
        /// �ֵ绰;
        /// </summary>
        public string m_strfcurrtele = string.Empty;

        /// <summary>
        /// ���ʱ�;
        /// </summary>
        public string m_strfcurrpost = string.Empty;

        /// <summary>
        /// ְҵ���;
        /// </summary>
        public string m_strfjobbh = string.Empty;

        /// <summary>
        /// ��������������;
        /// </summary>
        public string m_strfcstz = string.Empty;

        /// <summary>
        /// ��������Ժ����;
        /// </summary>
        public string m_strfrytz = string.Empty;

        /// <summary>
        /// ��Ժ;�����;
        /// </summary>
        public string m_strfryresourcebh = string.Empty;

        /// <summary>
        /// ��Ժ;��;
        /// </summary>
        public string m_strfryresource = string.Empty;

        /// <summary>
        /// �ٴ�·���������;
        /// </summary>
        public string m_strfycljbh = string.Empty;

        /// <summary>
        /// �ٴ�·������;
        /// </summary>
        public string m_strfyclj = string.Empty;

        /// <summary>
        /// ����������;
        /// </summary>
        public string m_strfphzdbh = string.Empty;

        /// <summary>
        /// �����;
        /// </summary>
        public string m_strfphzdnum = string.Empty;

        /// <summary>
        /// �Ƿ�ҩ��������;
        /// </summary>
        public string m_strfifgmywbh = string.Empty;

        /// <summary>
        /// �Ƿ�ҩ�����;
        /// </summary>
        public string m_strfifgmyw = string.Empty;

        /// <summary>
        /// ���λ�ʿ���;
        /// </summary>
        public string m_strfnursebh = string.Empty;

        /// <summary>
        /// ���λ�ʿ;
        /// </summary>
        public string m_strfnurse = string.Empty;

        /// <summary>
        /// ��Ժ��ʽ;
        /// </summary>
        public string m_strflyfsbh = string.Empty;

        /// <summary>
        /// ��Ժ��ʽ���;
        /// </summary>
        public string m_strflyfs0 = string.Empty;

        /// <summary>
        /// ��Ժ��ʽΪҽ��תԺ�������ҽ�ƻ�������;
        /// </summary>
        public string m_strfyzouthostital0 = string.Empty;

        /// <summary>
        /// ��Ժ��ʽΪת������������������/��������Ժ�������ҽ�ƻ�������;
        /// </summary>
        public string m_strfsqouthostital0 = string.Empty;

        /// <summary>
        /// �Ƿ��г�Ժ31������סԺ�ƻ����;
        /// </summary>
        public string m_strfisagainrybh = string.Empty;

        /// <summary>
        /// �Ƿ��г�Ժ31������סԺ�ƻ�;
        /// </summary>
        public string m_strfisagainry = string.Empty;

        /// <summary>
        /// ��סԺĿ��;
        /// </summary>
        public string m_strfisagainrymd0 = string.Empty;

        /// <summary>
        /// ­�����˻��߻���ʱ�䣺��Ժǰ��;
        /// </summary>
        public int m_Intfryqhmdays = 0;

        /// <summary>
        /// ­�����˻��߻���ʱ�䣺��ԺǰСʱ;
        /// </summary>
        public int m_Intfryqhmhours = 0;

        /// <summary>
        /// ­�����˻��߻���ʱ�䣺��Ժǰ����;
        /// </summary>
        public int m_Intfryqhmmins = 0;

        /// <summary>
        /// ��Ժǰ�����ܷ���;
        /// </summary>
        public int m_Intfryqhmcounts = 0;

        /// <summary>
        /// ­�����˻��߻���ʱ�䣺��Ժ����;
        /// </summary>
        public int m_Intfryhmdays = 0;

        /// <summary>
        /// ­�����˻��߻���ʱ�䣺��Ժ��Сʱ;
        /// </summary>
        public int m_Intfryhmhours = 0;

        /// <summary>
        /// ­�����˻��߻���ʱ�䣺��Ժ�����;
        /// </summary>
        public int m_Intfryhmmins = 0;

        /// <summary>
        /// ��Ժ������ܷ���;
        /// </summary>
        public int m_Intfryhmcounts = 0;

        /// <summary>
        /// �µĸ��ʽ���;
        /// </summary>
        public string m_strffbbhnew = string.Empty;

        /// <summary>
        /// �µĸ��ʽ;
        /// </summary>
        public string m_strffbnew = string.Empty;

        /// <summary>
        /// סԺ�ܷ��ã��Էѽ��;
        /// </summary>
        public double m_Dblfzfje = 0;

        /// <summary>
        /// �ۺ�ҽ�Ʒ����ࣺ��1��һ��ҽ�Ʒ����;
        /// </summary>
        public double m_Dblfzhfwlylf = 0;

        /// <summary>
        /// �ۺ�ҽ�Ʒ����ࣺ��2��һ�����Ʋ�����;
        /// </summary>
        public double m_Dblfzhfwlczf = 0;

        /// <summary>
        /// �ۺ�ҽ�Ʒ����ࣺ��3�������;
        /// </summary>
        public double m_Dblfzhfwlhlf = 0;

        /// <summary>
        /// �ۺ�ҽ�Ʒ����ࣺ��4����������;
        /// </summary>
        public double m_Dblfzhfwlqtf = 0;

        /// <summary>
        /// ����ࣺ(5)������Ϸ�;
        /// </summary>
        public double m_Dblfzdlblf = 0;

        /// <summary>
        /// ����ࣺ(6)ʵ������Ϸ�;
        /// </summary>
        public double m_Dblfzdlsssf = 0;

        /// <summary>
        /// ����ࣺ(7)Ӱ��ѧ��Ϸ�;
        /// </summary>
        public double m_Dblfzdlyxf = 0;

        /// <summary>
        /// ����ࣺ(8)�ٴ������Ŀ��;
        /// </summary>
        public double m_Dblfzdllcf = 0;

        /// <summary>
        /// �����ࣺ(9)������������Ŀ��;
        /// </summary>
        public double m_Dblfzllffssf = 0;

        /// <summary>
        /// �����ࣺ������������Ŀ�������ٴ��������Ʒ�;
        /// </summary>
        public double m_Dblfzllfwlzwlf = 0;

        /// <summary>
        /// �����ࣺ)�������Ʒ�;
        /// </summary>
        public double m_Dblfzllfssf = 0;

        /// <summary>
        /// �����ࣺ�������Ʒ����������;
        /// </summary>
        public double m_Dblfzllfmzf = 0;

        /// <summary>
        /// �����ࣺ�������Ʒ�����������;
        /// </summary>
        public double m_Dblfzllfsszlf = 0;

        /// <summary>
        /// �����ࣺ(11)������;
        /// </summary>
        public double m_Dblfkflkff = 0;

        /// <summary>
        /// ��ҽ�ࣺ��ҽ������;
        /// </summary>
        public double m_Dblfzylzf = 0;

        /// <summary>
        /// ��ҩ�ࣺ��ҩ�����п���ҩ�����;
        /// </summary>
        public double m_Dblfxylgjf = 0;

        /// <summary>
        /// ѪҺ��ѪҺ��Ʒ�ࣺѪ��;
        /// </summary>
        public double m_Dblfxylxf = 0;

        /// <summary>
        /// ѪҺ��ѪҺ��Ʒ�ࣺ�׵�������Ʒ��;
        /// </summary>
        public double m_Dblfxylbqbf = 0;

        /// <summary>
        /// ѪҺ��ѪҺ��Ʒ�ࣺ�򵰰���Ʒ��;
        /// </summary>
        public double m_Dblfxylqdbf = 0;

        /// <summary>
        /// ѪҺ��ѪҺ��Ʒ�ࣺ��Ѫ��������Ʒ��;
        /// </summary>
        public double m_Dblfxylyxyzf = 0;

        /// <summary>
        /// ѪҺ��ѪҺ��Ʒ�ࣺϸ���������;
        /// </summary>
        public double m_Dblfxylxbyzf = 0;

        /// <summary>
        /// �Ĳ��ࣺ�����һ����ҽ�ò��Ϸ�;
        /// </summary>
        public double m_Dblfhclcjf = 0;

        /// <summary>
        /// �Ĳ��ࣺ������һ����ҽ�ò��Ϸ�;
        /// </summary>
        public double m_Dblfhclzlf = 0;

        /// <summary>
        /// �Ĳ��ࣺ������һ����ҽ�ò��Ϸ�;
        /// </summary>
        public double m_Dblfhclssf = 0;

        /// <summary>
        /// �ۺ�ҽ�Ʒ����ࣺһ��ҽ�Ʒ����������ҽ��֤���ηѣ���ҽ��;
        /// </summary>
        public double m_Dblfzhfwlylf01 = 0;

        /// <summary>
        /// �ۺ�ҽ�Ʒ����ࣺһ��ҽ�Ʒ����������ҽ��֤���λ���ѣ���ҽ��;
        /// </summary>
        public double m_Dblfzhfwlylf02 = 0;

        /// <summary>
        /// ��ҽ�ࣺ��ϣ���ҽ��;
        /// </summary>
        public double m_Dblfzylzdf = 0;

        /// <summary>
        /// ��ҽ�ࣺ���ƣ���ҽ��;
        /// </summary>
        public double m_Dblfzylzlf = 0;

        /// <summary>
        /// ��ҽ�ࣺ�����������Σ���ҽ��;
        /// </summary>
        public double m_Dblfzylzlf01 = 0;

        /// <summary>
        /// ��ҽ�ࣺ�������й��ˣ���ҽ��;
        /// </summary>
        public double m_Dblfzylzlf02 = 0;

        /// <summary>
        /// ��ҽ�ࣺ�������������ķ�����ҽ��;
        /// </summary>
        public double m_Dblfzylzlf03 = 0;

        /// <summary>
        /// ��ҽ�ࣺ�����������ƣ���ҽ��;
        /// </summary>
        public double m_Dblfzylzlf04 = 0;

        /// <summary>
        /// ��ҽ�ࣺ�������иس����ƣ���ҽ��;
        /// </summary>
        public double m_Dblfzylzlf05 = 0;

        /// <summary>
        /// ��ҽ�ࣺ���������������ƣ���ҽ��;
        /// </summary>
        public double m_Dblfzylzlf06 = 0;

        /// <summary>
        /// ��ҽ�ࣺ��������ҽ��;
        /// </summary>
        public double m_Dblfzylqtf = 0;

        /// <summary>
        /// ��ҽ�ࣺ����������ҩ�������ӹ�����ҽ��;
        /// </summary>
        public double m_Dblfzylqtf01 = 0;

        /// <summary>
        /// ��ҽ�ࣺ�������б�֤ʩ�ţ���ҽ��;
        /// </summary>
        public double m_Dblfzylqtf02 = 0;

        /// <summary>
        /// ��ҩ�ࣺ�г�ҩ������ҽ�ƻ�����ҩ�Ƽ��ѣ���ҽ��;
        /// </summary>
        public double m_Dblfzcljgzjf = 0;
    }
    #endregion

    #region ��������
    /// <summary>
    /// ��������
    /// </summary>
    [Serializable]
    public class clsInHospitalMainCharge : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// ����
        /// </summary>
        public double m_dblMoney = 0;
        /// <summary>
        /// ������ˮ��
        /// </summary>
        public string m_strRegisterID = string.Empty;
        /// <summary>
        /// ��������
        /// </summary>
        public string m_strTypeName = string.Empty;
    }

    #endregion

    #region ����������Ϣ
    /// <summary>
    /// ����������Ϣ
    /// </summary>
    [Serializable]
    public class clsOperationVO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// ��������;
        /// </summary>
        public string m_strjgdm = string.Empty;

        /// <summary>
        /// סԺ��ˮ��;
        /// </summary>
        public string m_strfzyid = string.Empty;

        /// <summary>
        /// ����ҽ�����ڿ�������;
        /// </summary>
        public string m_stropksname = string.Empty;

        /// <summary>
        /// ����ҽ�����ڿ��ұ��;
        /// </summary>
        public string m_stroptykh = string.Empty;

        /// <summary>
        /// ��ˮ��;
        /// </summary>
        public string m_strfid = string.Empty;

        /// <summary>
        /// ������;
        /// </summary>
        public string m_strfprn = string.Empty;

        /// <summary>
        /// ����;
        /// </summary>
        public int m_Intftimes = 0;

        /// <summary>
        /// ��������;
        /// </summary>
        public string m_strfname = string.Empty;

        /// <summary>
        /// ��������;
        /// </summary>
        public int m_Intfoptimes = 0;

        /// <summary>
        /// ������;
        /// </summary>
        public string m_strfopcode = string.Empty;

        /// <summary>
        /// �������Ӧ����;
        /// </summary>
        public string m_strfop = string.Empty;

        /// <summary>
        /// ��������;
        /// </summary>
        public DateTime m_strfopdate = DateTime.MinValue;

        /// <summary>
        /// �пڱ��;
        /// </summary>
        public string m_strfqiekoubh = string.Empty;

        /// <summary>
        /// �п�;
        /// </summary>
        public string m_strfqiekou = string.Empty;

        /// <summary>
        /// ���ϱ��;
        /// </summary>
        public string m_strfyuhebh = string.Empty;

        /// <summary>
        /// ����;
        /// </summary>
        public string m_strfyuhe = string.Empty;

        /// <summary>
        /// ����ҽ�����;
        /// </summary>
        public string m_strfdocbh = string.Empty;

        /// <summary>
        /// ����ҽ��;
        /// </summary>
        public string m_strfdocname = string.Empty;

        /// <summary>
        /// ����ʽ���;
        /// </summary>
        public string m_strfmazuibh = string.Empty;

        /// <summary>
        /// ����ʽ;
        /// </summary>
        public string m_strfmazui = string.Empty;

        /// <summary>
        /// �Ƿ񸽼�����;
        /// </summary>
        public string m_strfiffsop = string.Empty;

        /// <summary>
        /// i�����;
        /// </summary>
        public string m_strfopdoct1bh = string.Empty;

        /// <summary>
        /// i������;
        /// </summary>
        public string m_strfopdoct1 = string.Empty;

        /// <summary>
        /// ii�����;
        /// </summary>
        public string m_strfopdoct2bh = string.Empty;

        /// <summary>
        /// ii������;
        /// </summary>
        public string m_strfopdoct2 = string.Empty;

        /// <summary>
        /// ����ҽ�����;
        /// </summary>
        public string m_strfmzdoctbh = string.Empty;

        /// <summary>
        /// ����ҽ��;
        /// </summary>
        public string m_strfmzdoct = string.Empty;

        /// <summary>
        /// ����;
        /// </summary>
        public string m_strfpx = string.Empty;

        /// <summary>
        /// �����������;
        /// </summary>
        public string m_strfzqssbh = string.Empty;

        /// <summary>
        /// ��������;
        /// </summary>
        public string m_strfzqss = string.Empty;

        /// <summary>
        /// ����������;
        /// </summary>
        public string m_strfssjbbh = string.Empty;

        /// <summary>
        /// ��������;
        /// </summary>
        public string m_strfssjb = string.Empty;
    }
    #endregion
    //End====qinhong====��Ӳ�����ҳ������VO����ƽ��==================
}
