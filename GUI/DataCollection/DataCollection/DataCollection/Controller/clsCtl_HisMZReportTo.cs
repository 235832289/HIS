using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Data;

namespace com.digitalwave.iCare.gui.DataCollection
{
    internal class clsCtl_HisMZReportTo
    {
        #region ����/����
        /// <summary>
        /// �����
        /// </summary>
        public frmHisMZReportTo m_objViewer = null;
        /// <summary>
        /// �����
        /// </summary>
        private clsDcl_HisMZReportTo m_objDomain = null;
        /// <summary>
        /// �߳��ϴ��߳�
        /// </summary>
        private Thread thread = null;
        /// <summary>
        /// Ŀ�����ݿ�����
        /// </summary>
        private string m_strDbType = string.Empty;
        /// <summary>
        /// Ŀ�����ݿ������ַ���
        /// </summary>
        private string m_strConnStr = string.Empty;
        #endregion

        #region ������
        /// <summary>
        /// ������
        /// </summary>
        public clsCtl_HisMZReportTo()
        {
            m_objDomain = new clsDcl_HisMZReportTo();

            m_strDbType = clsIniFileIO.m_strReadIniFile("DbConfig.ini", "DbType");
            m_strConnStr = clsIniFileIO.m_strReadIniFile("DbConfig.ini", "ConnectionString");
        }
        #endregion        

        #region �ϱ�����
        /// <summary>
        /// �ϱ�����
        /// </summary>
        internal void m_mthReport()
        {
            int intTotalSize = m_objViewer.m_padBar.m_IntRowsCount;
            if (intTotalSize <= 0)
            {
                return;
            }
            thread = new Thread(new ThreadStart(m_mthDataReportStart));
            thread.Start();
            frmReportProgress objProgress = new frmReportProgress(intTotalSize);
            objProgress.ShowDialog();
        }

        /// <summary>
        /// �����ϴ���ʼ
        /// </summary>
        private void m_mthDataReportStart()
        {
            int intPosition = 0;
            int intTotalSize = m_objViewer.m_padBar.m_IntRowsCount;
            while (intPosition < intTotalSize)
            {
                intPosition += 10;
                Thread.Sleep(1000);
            }
        }
        #endregion

        #region �����ϴ��߳���ֹ
        /// <summary>
        /// �����ϴ��߳���ֹ
        /// </summary>
        internal void m_mthThreadAbort()
        {
            if (thread != null && thread.IsAlive)
            {
                thread.Abort();
            }
        }
        #endregion

        #region ����Ŀ�����ݿ�����
        /// <summary>
        /// ����Ŀ�����ݿ�����
        /// </summary>
        internal void m_mthSetConnection()
        {
            frmDbConfig dbConfig = new frmDbConfig();
            dbConfig.m_StrDbType = m_strDbType;
            dbConfig.m_StrDbConnStr = m_strConnStr;
            dbConfig.ShowDialog();
            m_strConnStr = dbConfig.m_StrDbConnStr;
            m_strDbType = dbConfig.m_StrDbType;
        }
        #endregion

        #region ��ѯ������Ϣ
        /// <summary>
        /// ��ѯ���������Ϣ
        /// </summary>
        /// <param name="p_strType"></param>
        internal void m_mthQuery(string p_strType)
        {
            switch (p_strType)
            {
                case "clinic":
                    m_mthClinicQuery();
                    break;
                case "charge":
                    m_mthChargeQuery();
                    break;
                case "recipe":
                    m_mthRecipeQuery();
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// ��ѯ������Ϣ
        /// </summary>
        internal void m_mthClinicQuery()
        {
            string strPatientCardId = string.Empty;
            string strDeptId = string.Empty;
            string strDocId = string.Empty;
            DateTime dtStart = m_objViewer.m_dtpStart1.Value;
            DateTime dtEnd = m_objViewer.m_dtpEnd1.Value;
            if (m_objViewer.m_chkDept1.Checked)
            {
                strDeptId = m_objViewer.m_txtDept1.Text.Trim();
                if (string.IsNullOrEmpty(strDeptId))
                {
                    m_mthShowMsg("��ѡ����ң�");
                    return;
                }
            }
            if (m_objViewer.m_chkDocId1.Checked)
            {
                strDocId = m_objViewer.m_txtDocId1.Text.Trim();
                if (string.IsNullOrEmpty(strDocId))
                {
                    m_mthShowMsg("��ѡ��ҽ����");
                    return;
                }
            }
            if (m_objViewer.m_chkPatientCard1.Checked)
            {
                strPatientCardId = m_objViewer.m_txtPatientCard1.Text.Trim();
                if (string.IsNullOrEmpty(strPatientCardId))
                {
                    m_mthShowMsg("�����벡�˿��ţ�");
                    return;
                }
            }

            DataTable dtbResult = null;
            try
            {
                clsPublic.PlayAvi("���ڲ�ѯ���������Ϣ�����Ժ�...");
                m_objDomain.m_lngQueryClinic(strPatientCardId, strDeptId, strDocId, dtStart, dtEnd, out dtbResult);
            }
            catch(Exception objEx)
            {
                m_mthShowMsg(objEx.Message);
            }
            finally
            {
                clsPublic.CloseAvi();
            }
            //m_objViewer.m_dgvClinic.DataSource = dtbResult;
            m_objViewer.m_padBar.m_DtbSource = dtbResult;
        }
        /// <summary>
        /// ��ѯ�շ���Ϣ
        /// </summary>
        internal void m_mthChargeQuery()
        {
        }
        /// <summary>
        /// ��ѯ������Ϣ
        /// </summary>
        internal void m_mthRecipeQuery()
        {
        }
        #endregion

        #region ϵͳ��ʾ��Ϣ
        /// <summary>
        /// ϵͳ��ʾ��Ϣ
        /// </summary>
        /// <param name="p_strMsg"></param>
        private void m_mthShowMsg(string p_strMsg)
        {
            System.Windows.Forms.MessageBox.Show(p_strMsg, "ϵͳ��ʾ", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
        }
        #endregion
    }
}
