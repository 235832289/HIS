using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.Utility;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{  
   /// <summary>
    /// �����ڽ�ת������Ʋ�
   /// </summary>
    public class clsCtl_Account : com.digitalwave.GUI_Base.clsController_Base
    {
        #region ȫ�ֱ���
        private clsDcl_Account m_objDomain;
        private frmAccount m_objViewer;
        /// <summary>
        /// ��ǰ��ת�ʱ���ϸ����
        /// </summary>
        private long[] m_lngSEQArr = null;
        #endregion
        /// <summary>
        /// ���캯��
        /// </summary>
        public clsCtl_Account()
        {
            m_objDomain = new clsDcl_Account();
        }
        #region ���ô������
        /// <summary>
        /// ���ô������
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmAccount)frmMDI_Child_Base_in;
        }
        #endregion
        #region ��������������

        /// <summary>
        /// ��������������
        /// </summary>
        /// <param name="p_objAccPe">�����ڽ�ת����</param>
        internal void m_mthSetDataToUI(clsDS_AccountPeriodVO p_objAccPe)
        {
            if (p_objAccPe == null)
            {
                return;
            }
            m_objViewer.m_txtBeginTime.Text = p_objAccPe.m_dtmSTARTTIME_DAT.ToString("yyyy��MM��dd�� HH:mm:ss");
            m_objViewer.m_txtEndTime.Text = p_objAccPe.m_dtmENDTIME_DAT.ToString("yyyy��MM��dd�� HH:mm:ss");
            m_objViewer.m_txtRemark.Text = p_objAccPe.m_strCOMMENT_VCHR;
            m_objViewer.m_txtRemark.ReadOnly = true;
            m_objViewer.m_btnGenerate.Enabled = false;
            m_objViewer.m_btnQuery.Enabled = false;

            clsDS_Account objAcc = null;
            long lngRes = m_objDomain.m_lngGetAccout(m_objViewer.m_strDrugStoreid, p_objAccPe.m_strACCOUNTID_CHR, out objAcc);
            if (objAcc == null)
            {
                return;
            }

            m_objViewer.m_objCurrentAccount = objAcc;
            m_mthSetAccountToUI(objAcc);
        }
        #endregion
        #region �����ʱ�����������

        /// <summary>
        /// �����ʱ�����������

        /// </summary>
        /// <param name="p_objAccount"></param>
        internal void m_mthSetAccountToUI(clsDS_Account p_objAccount)
        {
            if (p_objAccount == null)
            {
                return;
            }
            //
            m_objViewer.m_lblADJUSTRETAILFIGURE_INT.Text = p_objAccount.m_dblADJUSTRETAILFIGURE_INT.ToString("0.0000");
            m_objViewer.m_lblBEGINRETAILFIGURE_INT.Text = p_objAccount.m_dblBEGINRETAILFIGURE_INT.ToString("0.0000");
            m_objViewer.m_lblENDRETAILFIGURE_INT.Text = p_objAccount.m_dblENDRETAILFIGURE_INT.ToString("0.0000");
            m_objViewer.m_lblINSTORAGERETAILFIGURE_INT.Text = p_objAccount.m_dblINSTORAGERETAILFIGURE_INT.ToString("0.0000");
            m_objViewer.m_lblOUTSTORAGERETAILFIGURE_INT.Text = p_objAccount.m_dblOUTSTORAGERETAILFIGURE_INT.ToString("0.0000");
            m_objViewer.m_lblRECIPERETAILFIGURE_INT.Text = p_objAccount.m_dblRECIPERETAILFIGURE_INT.ToString("0.0000");
            m_objViewer.m_lblPutMed.Text = p_objAccount.m_dblPutMedRetailFigure_INT.ToString("0.0000");
        }
        #endregion
        #region ��������
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="p_objAccount">�ʱ�����</param>
        internal void m_mthGenerateAccount(out clsDS_Account p_objAccount)
        {
            p_objAccount = null;
            m_lngSEQArr = null;

            DateTime dtmBegin = Convert.ToDateTime(m_objViewer.m_txtBeginTime.Text);
            DateTime dtmEnd = Convert.ToDateTime(m_objViewer.m_txtEndTime.Text);

            long lngRes = m_objDomain.m_lngGenarateAccount(dtmBegin, dtmEnd, m_objViewer.m_strDrugStoreid, out p_objAccount, out m_lngSEQArr,this.m_objViewer.m_intTransferMode,this.m_objViewer.m_lngCheckSeqid);
        }
        #endregion
        #region ����Ƿ���δȷ�����ʵļ�¼
        /// <summary>
        /// ����Ƿ���δȷ�����ʵļ�¼
        /// </summary>
        /// <param name="p_strChittyIDArr">���ݺ�</param>
        internal void m_mthCheckHasUnConfirmAccount(out string[] p_strChittyIDArr)
        {
            p_strChittyIDArr = null;

            DateTime dtmBegin = Convert.ToDateTime(m_objViewer.m_txtBeginTime.Text);
            DateTime dtmEnd = Convert.ToDateTime(m_objViewer.m_txtEndTime.Text);

            long lngRes = m_objDomain.m_lngCheckHasUnConfirmAccount(dtmBegin, dtmEnd, m_objViewer.m_strDrugStoreid, out p_strChittyIDArr);
        }
        #endregion
        #region ��鿪���������Ƿ����δ��˵ļ�¼
        /// <summary>
        /// ��鿪���������Ƿ����δ��˵ļ�¼
        /// </summary>
        /// <param name="p_strHintText">����δ��˼�¼�ĵ�������(����)</param>
        internal void m_mthCheckHasUnCommitRecord(out string p_strHintText)
        {
            DateTime dtmBegin = Convert.ToDateTime(m_objViewer.m_txtBeginTime.Text);
            DateTime dtmEnd = Convert.ToDateTime(m_objViewer.m_txtEndTime.Text);

            long lngRes = m_objDomain.m_lngCheckHasUnCommitRecord(dtmBegin, dtmEnd, m_objViewer.m_strDrugStoreid, out p_strHintText);
        }
        #endregion
        #region ����
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="p_strChittyIDArr">���ݺ�</param>
        internal long m_lngSetAccount(string[] p_strChittyIDArr)
        {
            if (p_strChittyIDArr == null || p_strChittyIDArr.Length == 0)
            {
                return -1;
            }

            long lngRes = 0;

            try
            {
                lngRes = m_objDomain.m_lngSetAccount(m_objViewer.LoginInfo.m_strEmpID, Convert.ToDateTime(clsPub.ServerDateTimeNow.ToString("yyyy-MM-dd HH:mm:ss")), p_strChittyIDArr, m_objViewer.m_strDrugStoreid);
            }
            catch (Exception objEx)
            {
                lngRes = -1;
                System.Windows.Forms.MessageBox.Show(objEx.ToString());
            }
            return lngRes;
        }
        #endregion
        #region �����ʱ�
        /// <summary>
        /// �����ʱ�
        /// </summary>
        internal long m_lngSaveAccount()
        {
            if (m_objViewer.m_objCurrentAccount == null)
            {
                MessageBox.Show("�������������ת����", "�����ڽ�ת", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }

            DateTime dtmBegin = Convert.ToDateTime(m_objViewer.m_txtBeginTime.Text);
            DateTime dtmEnd = Convert.ToDateTime(m_objViewer.m_txtEndTime.Text);

            if (dtmBegin > dtmEnd)
            {
                MessageBox.Show("�����ڿ�ʼ���ڲ��ܴ��������ڽ�������", "�����ڽ�ת", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
            clsDS_AccountPeriodVO objApVO = new clsDS_AccountPeriodVO();
            objApVO.m_dtmENDTIME_DAT = dtmEnd;
            objApVO.m_dtmSTARTTIME_DAT = dtmBegin;
            objApVO.m_dtmTRANSFERTIME_DAT = Convert.ToDateTime(clsPub.ServerDateTimeNow.ToString("yyyy-MM-dd HH:mm:ss"));
            objApVO.m_strCOMMENT_VCHR = m_objViewer.m_txtRemark.Text;
            objApVO.m_strDrugStoreid = m_objViewer.m_strDrugStoreid;

            m_objViewer.m_objCurrentAccount.m_strCOMMENT_VCHR = m_objViewer.m_txtRemark.Text;

            long lngRes = 0;
            try
            {
                string strAccountID = string.Empty;
                long lngMainSEQ = 0;
                long lngSubSEQ = 0;
                lngRes = m_objDomain.m_lngSaveAccount(objApVO, m_objViewer.m_objCurrentAccount, m_lngSEQArr, m_objViewer.LoginInfo.m_strEmpID, out strAccountID, out lngMainSEQ, out lngSubSEQ,this.m_objViewer.m_intTransferMode,this.m_objViewer.m_lngCheckSeqid);

                if (lngRes > 0)
                {
                    objApVO.m_strACCOUNTID_CHR = strAccountID;
                    objApVO.m_lngSERIESID_INT = lngMainSEQ;
                    m_objViewer.m_objAccPe = objApVO;

                    m_objViewer.m_objCurrentAccount.m_strACCOUNTID = strAccountID;
                    m_objViewer.m_objCurrentAccount.m_lngSERIESID_INT = lngSubSEQ;
                }
            }
            catch 
            {
                lngRes = -1;
            }

            return lngRes;
        }
       #endregion
        #region  ��ȡ���һ���̵�ʱ����Ϊ���������ڵĽ���ʱ��

        /// <summary>
        /// ��ȡ���һ���̵�ʱ����Ϊ���������ڵĽ���ʱ��
        /// </summary>
        /// <param name="p_strStorageID"></param>
        /// <param name="m_dtmBeginAccountTime"></param>
        /// <param name="m_dtmEndAccountTime"></param>
        /// <returns></returns>
        public void m_lngGetAccountEndTime(string p_strStorageID, DateTime m_dtmBeginAccountTime, out  DateTime m_dtmEndAccountTime,out long m_lngCheckSeqid)
        {
            this.m_objDomain.m_lngGetAccountEndTime(p_strStorageID, m_dtmBeginAccountTime, out m_dtmEndAccountTime, out m_lngCheckSeqid);
        }
         #endregion
        #region ��֤����
        /// <summary>
        /// ��֤����
        /// </summary>
        internal void m_mthValidateData()
        {
            double dblTemp = 0d;

            string strRetailHint = string.Empty;//���۽���Ƿ���ȷ
            #region ���۽��Ƚ�
            double dblRetailMoney = 0d;
            if (double.TryParse(m_objViewer.m_lblBEGINRETAILFIGURE_INT.Text, out dblTemp))
            {
                dblRetailMoney += dblTemp;
            }
            if (double.TryParse(m_objViewer.m_lblINSTORAGERETAILFIGURE_INT.Text, out dblTemp))
            {
                dblRetailMoney += dblTemp;
            }
            if (double.TryParse(m_objViewer.m_lblADJUSTRETAILFIGURE_INT.Text, out dblTemp))
            {
                dblRetailMoney += dblTemp;
            }
   
   
            if (double.TryParse(m_objViewer.m_lblOUTSTORAGERETAILFIGURE_INT.Text, out dblTemp))
            {
                dblRetailMoney -= dblTemp;
            }
            if (double.TryParse(m_objViewer.m_lblRECIPERETAILFIGURE_INT.Text, out dblTemp))
            {
                dblRetailMoney -= dblTemp;
            }
            if (double.TryParse(m_objViewer.m_lblPutMed.Text, out dblTemp))
            {
                dblRetailMoney -= dblTemp;
            }

            if (double.TryParse(m_objViewer.m_lblENDRETAILFIGURE_INT.Text, out dblTemp))
            {
                dblRetailMoney = Math.Round(dblRetailMoney, 4);
                dblTemp = Math.Round(dblTemp, 4);
                if (dblRetailMoney == dblTemp)
                {
                    strRetailHint = "���";
                }
                else
                {
                    strRetailHint = "���ȣ���ĩ������ʱ���ϸ���" + (dblTemp - dblRetailMoney).ToString("0.0000");
                }
            }
            else
            {
                strRetailHint = "����";
            }
            #endregion

            StringBuilder stbHint = new StringBuilder(50);
            stbHint.Append("���۽�");
            stbHint.Append(strRetailHint);
            MessageBox.Show(stbHint.ToString(), "��������֤", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
#endregion

        #region ��ӡ
        public void m_mthPrint()
        {
            this.m_objViewer.ds.LibraryList = Application.StartupPath + "\\pb_ms.pbl";
            this.m_objViewer.ds.DataWindowObject = "account_gysy_ds";
            string HospitalTitle = this.m_objComInfo.m_strGetHospitalTitle();
            string StorageName = string.Empty;
            com.digitalwave.iCare.gui.MedicineStore.clsCtl_Public objPub = new com.digitalwave.iCare.gui.MedicineStore.clsCtl_Public();
            objPub.m_lngGetStorageName(false, this.m_objViewer.m_strDrugStoreid, out StorageName);
            //

            #region ���۽��Ƚ�
            double dblTemp = 0d;

            string strRetailHint = string.Empty;//���۽���Ƿ���ȷ

            double dblRetailMoney = 0d;
            if (double.TryParse(m_objViewer.m_lblBEGINRETAILFIGURE_INT.Text, out dblTemp))
            {
                dblRetailMoney += dblTemp;
            }
            if (double.TryParse(m_objViewer.m_lblINSTORAGERETAILFIGURE_INT.Text, out dblTemp))
            {
                dblRetailMoney += dblTemp;
            }
            if (double.TryParse(m_objViewer.m_lblADJUSTRETAILFIGURE_INT.Text, out dblTemp))
            {
                dblRetailMoney += dblTemp;
            }


            if (double.TryParse(m_objViewer.m_lblOUTSTORAGERETAILFIGURE_INT.Text, out dblTemp))
            {
                dblRetailMoney -= dblTemp;
            }
            if (double.TryParse(m_objViewer.m_lblRECIPERETAILFIGURE_INT.Text, out dblTemp))
            {
                dblRetailMoney -= dblTemp;
            }
            if (double.TryParse(m_objViewer.m_lblPutMed.Text, out dblTemp))
            {
                dblRetailMoney -= dblTemp;
            }

            if (double.TryParse(m_objViewer.m_lblENDRETAILFIGURE_INT.Text, out dblTemp))
            {
                dblRetailMoney = Math.Round(dblRetailMoney, 4);
                dblTemp = Math.Round(dblTemp, 4);
                if (dblRetailMoney == dblTemp)
                {
                    strRetailHint = "���";
                }
                else
                {
                    strRetailHint =(dblTemp - dblRetailMoney).ToString("0.0000");
                }
            }
            #endregion
            //
            this.m_objViewer.ds.Modify("t_titel.text='" + HospitalTitle + "'");
            this.m_objViewer.ds.Modify("t_begindate.text='" + this.m_objViewer.m_txtBeginTime.Text+ "'");
            this.m_objViewer.ds.Modify("t_enddate.text='" + this.m_objViewer.m_txtEndTime.Text + "'");
            this.m_objViewer.ds.Modify("t_begin.text='" + this.m_objViewer.m_lblBEGINRETAILFIGURE_INT.Text+ "'");
            this.m_objViewer.ds.Modify("t_dept.text='" + StorageName + "'");
            this.m_objViewer.ds.Modify("t_instorage.text='" + this.m_objViewer.m_lblINSTORAGERETAILFIGURE_INT.Text+ "'");
            this.m_objViewer.ds.Modify("t_outstorage.text='" + this.m_objViewer.m_lblOUTSTORAGERETAILFIGURE_INT.Text + "'");
            this.m_objViewer.ds.Modify("t_recipe.text='" + this.m_objViewer.m_lblRECIPERETAILFIGURE_INT.Text + "'");
            this.m_objViewer.ds.Modify("t_putmed.text='" + this.m_objViewer.m_lblPutMed.Text + "'");
            this.m_objViewer.ds.Modify("t_end.text='" + this.m_objViewer.m_lblENDRETAILFIGURE_INT.Text + "'");
            this.m_objViewer.ds.Modify("t_margin.text='" + strRetailHint.ToString() + "'");
            this.m_objViewer.ds.Modify("t_just.text='" + this.m_objViewer.m_lblADJUSTRETAILFIGURE_INT.Text + "'");
            com.digitalwave.iCare.gui.HIS.clsPublic.PrintDialog(this.m_objViewer.ds);

        }
        #endregion
    }
}
