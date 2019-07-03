using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// ҩ�������ڽ�ת����
    /// </summary>
    public partial class frmAccount : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region ȫ�ֱ���
        /// <summary>
        /// �ֿ�ID
        /// </summary>
        internal string m_strDrugStoreid = string.Empty;
        /// <summary>
        /// �����ڽ�ת����
        /// </summary>
        internal clsDS_AccountPeriodVO m_objAccPe = null;
        /// <summary>
        /// ��ǰ�ʱ�����
        /// </summary>
        internal clsDS_Account m_objCurrentAccount = null;
        /// <summary>
        /// �Ƿ��ѻ�ȡ��ת����
        /// </summary>
        private bool m_blnHasGenerated = false;
        /// <summary>
        /// ��ʾ�����δ��˵�����˺��Ƿ������²�ѯ�����ʱ����
        /// </summary>
        private bool m_blhHasReSearch = false;
        /// <summary>
        /// 0-���ģʽ��1-�̵�ģʽ
        /// </summary>
        public int m_intTransferMode = 0;
        /// <summary>
        /// �����̵㵥�����к�
        /// </summary>
        public long m_lngCheckSeqid = 0;
        #endregion
        #region ���캯��

        /// <summary>
        /// �����ڽ�ת

        /// </summary>
        private frmAccount()
        {
            InitializeComponent();
            DateTime m_dtmNow = clsPub.CurrentDateTimeNow;
            this.m_txtEndTime.Text = m_dtmNow.ToString("yyyy��MM��dd�� HH:mm:ss");
            this.m_txtBeginTime.Text = m_dtmNow.AddMonths(-1).ToString("yyyy��MM��dd�� HH:mm:ss");            
        }

        /// <summary>
        /// �����ڽ�ת
        /// </summary>
        /// <param name="p_strStorageID">�ֿ�ID</param>
        /// <param name="p_dtmBeginDate">�����ڿ�ʼʱ��</param>
        public frmAccount(string p_strStorageID, DateTime p_dtmBeginDate)
            : this()
        {
            DateTime m_dtmAccountEndTime = DateTime.MinValue;
            m_strDrugStoreid = p_strStorageID;
            ((clsCtl_Account)objController).m_lngGetAccountEndTime(m_strDrugStoreid,p_dtmBeginDate,out m_dtmAccountEndTime,out m_lngCheckSeqid);
            this.m_txtBeginTime.Text = p_dtmBeginDate.ToString("yyyy��MM��dd�� HH:mm:ss");
            if (m_dtmAccountEndTime == DateTime.MinValue)
            {
                if (DialogResult.OK == MessageBox.Show("����û�������κ��̵㵥,�Ƿ�������������ڽ�ת��", "ҩ�������ڽ�ת", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1))
                {
                    this.m_txtEndTime.Text = clsPub.ServerDateTimeNow.ToString("yyyy��MM��dd�� HH:mm:ss");
                }
                else
                {
                    return;
                }
            }
            else
            {
                this.m_txtEndTime.Text = m_dtmAccountEndTime.ToString("yyyy��MM��dd�� HH:mm:ss");
                this.m_intTransferMode = 1;
            }
        }

        /// <summary>
        /// �����ڽ�ת

        /// </summary>
        /// <param name="p_strStorageID">�ֿ�ID</param>
        /// <param name="p_objAP">�����ڽ�ת����</param>
        public frmAccount(string p_strStorageID, clsDS_AccountPeriodVO p_objAP)
            : this()
        {
            m_strDrugStoreid = p_strStorageID;
            m_objAccPe = p_objAP;

            ((clsCtl_Account)objController).m_mthSetDataToUI(p_objAP);
            m_blnHasGenerated = true;
        }
        #endregion

        #region ����
        public override void CreateController()
        {
            this.objController = new clsCtl_Account();
            objController.Set_GUI_Apperance(this);
        }
        #endregion
        private void m_btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_bgwGenerateAccount_DoWork_1(object sender, DoWorkEventArgs e)
        {
            clsDS_Account objAccount = null;
            ((clsCtl_Account)objController).m_mthGenerateAccount(out objAccount);
            e.Result = objAccount;
        }

        private void m_bgwGenerateAccount_RunWorkerCompleted_1(object sender, RunWorkerCompletedEventArgs e)
        {

            if (e.Result == null)
            {
                MessageBox.Show("�����תʧ��", "�����ڽ�ת", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsDS_Account objAccount = e.Result as clsDS_Account;
            if (objAccount == null)
            {
                MessageBox.Show("�����תʧ��", "�����ڽ�ת", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            m_objCurrentAccount = objAccount;
            ((clsCtl_Account)objController).m_mthSetAccountToUI(objAccount);
            m_blnHasGenerated = true;
            m_blhHasReSearch = true;
        }

        private void m_btnGenerate_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("�Ƿ�ȷ��Ҫ���������ڽ�ת��", "�����ڽ�ת", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
            {
                long lngRes = 0;
                if (this.m_btnQuery.Enabled)
                {
                    if (!m_blnHasGenerated)
                    {
                        MessageBox.Show("���Ȳ�ѯ��ȡ�ʱ���������", "�����ڽ�ת", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        try
                        {
                            string strHintText = string.Empty;
                            ((clsCtl_Account)objController).m_mthCheckHasUnCommitRecord(out strHintText);
                            if (!string.IsNullOrEmpty(strHintText))
                            {
                                m_blhHasReSearch = false;
                                MessageBox.Show("�������������µ��ݴ���δ��˼�¼�����ܼ��������ת����" + Environment.NewLine + strHintText, "�����ڽ�ת", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }

                            string[] strChittyID = null;
                            ((clsCtl_Account)objController).m_mthCheckHasUnConfirmAccount(out strChittyID);
                            if (strChittyID != null && strChittyID.Length > 0)
                            {
                                DialogResult drResult = MessageBox.Show("�ڴ��������ڴ���δ���ʼ�¼���Ƿ�����?", "�����ڽ�ת", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (drResult == DialogResult.No)
                                {
                                    MessageBox.Show("��תʧ��", "�����ڽ�ת", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                lngRes = ((clsCtl_Account)objController).m_lngSetAccount(strChittyID);
                                if (lngRes <= 0)
                                {
                                    MessageBox.Show("��תʧ��", "�����ڽ�ת", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }

                            if (!m_blhHasReSearch)//��ʾ�����δ��˵�����˺�δ���²�ѯ�����ʱ����
                            {
                                MessageBox.Show("������˵��ݺ��ʱ������ı䣬�����²�ѯ�����ʱ�", "�����ڽ�ת", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            this.Cursor = Cursors.WaitCursor;
                            lngRes = ((clsCtl_Account)objController).m_lngSaveAccount();
                        }
                        catch (Exception Ex)
                        {
                            string strEx = Ex.Message;
                        }
                        finally
                        {
                            this.Cursor = Cursors.Default;
                        }

                        if (lngRes <= 0)
                        {
                            MessageBox.Show("�����ʱ�ʧ��", "�����ڽ�ת", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            this.m_btnGenerate.Enabled = false;
                            DialogResult drResult = MessageBox.Show("�����ʱ�ɹ����Ƿ�رյ�ǰ����?", "�����ڽ�ת", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (drResult == DialogResult.No)
                            {
                                this.m_btnGenerate.Enabled = false;
                                return;
                            }
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                }

                this.Close();
            }
           
        }

        private void m_btnQuery_Click(object sender, EventArgs e)
        {
            DateTime dtmBegin = Convert.ToDateTime(this.m_txtBeginTime.Text);
            DateTime dtmEnd = Convert.ToDateTime(this.m_txtEndTime.Text);

            if (dtmBegin > dtmEnd)
            {
                MessageBox.Show("�����ڿ�ʼ���ڲ��ܴ��������ڽ�������", "�����ڽ�ת", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Application.DoEvents();
            if (!m_bgwGenerateAccount.IsBusy)
            {
                m_bgwGenerateAccount.RunWorkerAsync();
            }
        }

        private void frmAccount_Load(object sender, EventArgs e)
        {

        }

        private void m_btnValid_Click(object sender, EventArgs e)
        {
            if (m_blnHasGenerated)
            {
                ((clsCtl_Account)objController).m_mthValidateData();
            }
            else
            {
                MessageBox.Show("���Ȳ�ѯ��ȡ�ʱ���������", "�����ڽ�ת", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void m_lblINSTORAGERETAILFIGURE_INT_Click(object sender, EventArgs e)
        {

        }

        private void m_cmdPrint_Click(object sender, EventArgs e)
        {
            ((clsCtl_Account)objController).m_mthPrint();
        }
    }
}