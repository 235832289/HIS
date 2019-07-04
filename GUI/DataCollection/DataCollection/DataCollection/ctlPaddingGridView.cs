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
        #region 变量/属性
        /// <summary>
        /// 数据表
        /// </summary>
        private DataTable m_dtbSource = null;
        /// <summary>
        /// 获取或设置数据表
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
                    m_lblPadding.Text = "/ 共 " + intPageCount.ToString() + " 页";
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
        /// 分页的GridView
        /// </summary>
        private DataGridView m_dgvGridView = null;
        /// <summary>
        /// 设置分页的GridView
        /// </summary>
        public DataGridView m_DgvGridView
        {
            set
            {
                m_dgvGridView = value;
            }
        }
        /// <summary>
        /// 总记录条数
        /// </summary>
        private int m_intRowsCount = 0;
        /// <summary>
        /// 获取总记录数
        /// </summary>
        public int m_IntRowsCount
        {
            get
            {
                return m_intRowsCount;
            }
        }
        /// <summary>
        /// 页码
        /// </summary>
        private int m_intPageIndex = 0;
        /// <summary>
        /// 每页记录数
        /// </summary>
        private int m_intPageSize = 50;
        /// <summary>
        /// 设置每页记录数
        /// </summary>
        public int m_IntPageSize
        {
            set
            {
                m_intPageSize = value;
            }
        }
        #endregion

        #region 构造器
        /// <summary>
        /// 构造器
        /// </summary>
        public ctlPaddingGridView()
        {
            InitializeComponent();
        }
        #endregion

        #region 绑定子数据表到GridView
        /// <summary>
        /// 绑定子数据表到GridView
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

        #region 刷新GridView数据
        /// <summary>
        /// 刷新GridView数据
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
