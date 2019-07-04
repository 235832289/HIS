using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.DataCollection
{
    public partial class ctlPaddingGridView : UserControl
    {
        #region ����/����
        /// <summary>
        /// ���ݱ�
        /// </summary>
        private DataTable m_dtbSource = null;
        /// <summary>
        /// ��ȡ���������ݱ�
        /// </summary>
        public DataTable m_DtbSource
        {
            set
            {
                m_dtbSource = value;
                m_cboPadding.Items.Clear();
                if (m_dtbSource != null)
                {
                    m_intRowsCount = m_dtbSource.Rows.Count;
                    int intPageCount = m_intRowsCount / m_intPageSize;
                    if(m_intRowsCount % m_intPageSize != 0)
                    {
                        intPageCount += 1;
                    }
                    string[] strItemArr = new string[intPageCount];
                    for(int i1 = 0; i1 < intPageCount; i1++)
                    {
                        strItemArr[i1] = i1.ToString();
                    }
                    m_cboPadding.Items.AddRange(strItemArr);
                    m_lblPadding.Text = "/ �� " + intPageCount.ToString() + " ҳ";
                    m_intPageIndex = 0;
                    m_mthRefresh();
                }
                else
                {
                    m_intRowsCount = 0;
                }
            }
            get
            {
                return m_dtbSource;
            }
        }
        /// <summary>
        /// ��ҳ��GridView
        /// </summary>
        private DataGridView m_dgvGridView = null;
        /// <summary>
        /// ���÷�ҳ��GridView
        /// </summary>
        public DataGridView m_DgvGridView
        {
            set
            {
                m_dgvGridView = value;
            }
        }
        /// <summary>
        /// �ܼ�¼����
        /// </summary>
        private int m_intRowsCount = 0;
        /// <summary>
        /// ��ȡ�ܼ�¼��
        /// </summary>
        public int m_IntRowsCount
        {
            get
            {
                return m_intRowsCount;
            }
        }
        /// <summary>
        /// ҳ��
        /// </summary>
        private int m_intPageIndex = 0;
        /// <summary>
        /// ÿҳ��¼��
        /// </summary>
        private int m_intPageSize = 50;
        /// <summary>
        /// ����ÿҳ��¼��
        /// </summary>
        public int m_IntPageSize
        {
            set
            {
                m_intPageSize = value;
            }
        }
        #endregion

        #region ������
        /// <summary>
        /// ������
        /// </summary>
        public ctlPaddingGridView()
        {
            InitializeComponent();
        }
        #endregion

        #region �������ݱ�GridView
        /// <summary>
        /// �������ݱ�GridView
        /// </summary>
        private void m_mthDataBind()
        {
            if (m_dgvGridView == null || m_dtbSource == null || m_intPageIndex < 0 || m_intPageIndex > m_intRowsCount - 1)
            {
                return;
            }

            DataTable dtbTemp = m_dtbSource.Clone();
            DataRow[] dtrTempArr = new DataRow[m_intPageSize];
            int intCurPos = m_intPageIndex * m_intPageSize;
            //m_dtbSource.Rows.CopyTo(dtrTempArr, intCurPos);
            for(int i1 = intCurPos; i1 < intCurPos + m_intPageSize; i1++)
            {
                dtbTemp.LoadDataRow(m_dtbSource.Rows[i1].ItemArray, LoadOption.Upsert);
            }
            m_dgvGridView.DataSource = dtbTemp;
            m_cboPadding.Text = m_intPageIndex.ToString();
        }
        #endregion

        #region ˢ��GridView����
        /// <summary>
        /// ˢ��GridView����
        /// </summary>
        public void m_mthRefresh()
        {
            m_mthDataBind();
        }
        #endregion

        private void m_btnFirst_Click(object sender, EventArgs e)
        {
            m_intPageIndex = 0;
            m_mthRefresh();
        }

        private void m_btnPrevious_Click(object sender, EventArgs e)
        {
            m_intPageIndex -= 1;
            if (m_intPageIndex < 0)
            {
                m_intPageIndex = 0;
            }
            m_mthRefresh();
        }

        private void m_btnNext_Click(object sender, EventArgs e)
        {
            m_intPageIndex += 1;
            if (m_intPageIndex > m_intRowsCount - 1)
            {
                m_intPageIndex = m_intRowsCount - 1;
            }
            m_mthRefresh();
        }

        private void m_cboPadding_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32.TryParse(m_cboPadding.Text.Trim(), out m_intPageIndex);
            if (m_intPageIndex > m_intRowsCount - 1)
            {
                m_intPageIndex = m_intRowsCount - 1;
            }
            m_mthRefresh();
        }

        private void m_cboPadding_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= (char)Keys.D0 && e.KeyChar <= (char)Keys.D9 || e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void m_btnLast_Click(object sender, EventArgs e)
        {
            m_intPageIndex = m_intRowsCount - 1;
            m_mthRefresh();
        }
    }
}
