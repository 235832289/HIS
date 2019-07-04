using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.DataCollection
{
    public partial class frmReportProgress : Form
    {
        /// <summary>
        /// ָʾ�Ƿ�ȡ���ϱ�����
        /// </summary>
        private bool m_blnIsCancel = false;
        /// <summary>
        /// ��ȡһ������ֵ��ָʾ�Ƿ�ȡ���ϱ�����
        /// </summary>
        public bool m_BlnIsCancel
        {
            get
            {
                return m_blnIsCancel;
            }
        }
        /// <summary>
        /// ��������Ϣ
        /// </summary>
        private string m_strProgressInfo = "�����ϱ��� {0} ����¼���� {1} ����¼������� {2}%{3}";
        /// <summary>
        /// ����������Ϣ
        /// </summary>
        private string m_strDotInfo = string.Empty;

        public frmReportProgress(int p_intTotalSize)
        {
            InitializeComponent();
            m_pgbProgress.Maximum = p_intTotalSize;
        }

        private void m_tmrProgress_Tick(object sender, EventArgs e)
        {
            if (m_pgbProgress.Value == m_pgbProgress.Maximum)
            {
                m_pgbProgress.Value = m_pgbProgress.Minimum;
            }
            else
            {
                m_pgbProgress.PerformStep();
            }

            decimal decValue = Convert.ToDecimal(m_pgbProgress.Value);
            decimal decMax = Convert.ToDecimal(m_pgbProgress.Maximum);
            decimal decMin = Convert.ToDecimal(m_pgbProgress.Minimum);
            decimal decPercent = 0.00M;
            decPercent = 100 * (decValue - decMin) / (decMax - decMin);
            if (decPercent < 100)
            {
                m_strDotInfo += ".";
                if (m_strDotInfo.Length > 4)
                {
                    m_strDotInfo = ".";
                }
                m_txtProgressInfo.Text = string.Format(m_strProgressInfo, decValue.ToString(), decMax.ToString(), decPercent.ToString("0.00"), m_strDotInfo);
            }
            else
            {
                m_txtProgressInfo.Text = "�����ϱ���ϣ�";
            }
        }

        /// <summary>
        /// ���ý�������ǰֵ
        /// </summary>
        /// <param name="p_intValue"></param>
        public void m_mthSetProgressValue(int p_intValue)
        {
            m_pgbProgress.Value = p_intValue;
        }

        private void m_btnCancel_Click(object sender, EventArgs e)
        {
            m_blnIsCancel = true;
            Close();
        }
    }
}