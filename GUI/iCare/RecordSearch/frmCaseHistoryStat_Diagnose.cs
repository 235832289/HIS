using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.Utility.Controls;
using iCareData;
using iCare.iCareBaseForm;

namespace iCare
{
    public partial class frmCaseHistoryStat_Diagnose : frmBaseForm
    {
        #region 全局变量
        /// <summary>
        /// 当前选定科室
        /// </summary>
        private clsDept_Desc m_objCurrentDept = null;
        #endregion

        #region 构造方法
        /// <summary>
        /// 疾病谱统计
        /// </summary>
        public frmCaseHistoryStat_Diagnose()
        {
            InitializeComponent();
        } 
        #endregion

        #region 统计按钮Click事件
        private void m_cmdStat_Click(object sender, EventArgs e)
        {
            string strDeptID = null;
            bool blnIsFirst = m_chkIsFirst.Checked;
            if (m_objCurrentDept != null)
            {
                strDeptID = m_objCurrentDept.m_strDeptNewID;
            }

            DateTime dtmOutDateBegin = Convert.ToDateTime(m_dtpOutDate1.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            DateTime dtmOutDateEnd = Convert.ToDateTime(m_dtpOutDate2.Value.ToString("yyyy-MM-dd HH:mm:ss"));

            DataTable dtbResutl = null;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                clsCaseHistorySearchDomain m_objDomain = new clsCaseHistorySearchDomain();
                long lngRes = m_objDomain.m_lngGetStatDiagnose(blnIsFirst, strDeptID, dtmOutDateBegin, dtmOutDateEnd, out dtbResutl);
                m_mthSetTableToListView(dtbResutl);
            }
            catch (Exception ex)
            {
                string strEx = ex.Message;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        } 
        #endregion

        #region 清空界面
        private void m_cmdClear_Click(object sender, EventArgs e)
        {
            m_dtpOutDate1.Value = DateTime.Now;
            m_dtpOutDate2.Value = DateTime.Now;
            m_cboOutDept.SelectedIndex = -1;
            m_lsvResultList.Items.Clear();
            m_lblSearchNums.Text = "共检索出0种疾病，0例诊断";
            m_chkIsFirst.Checked = false;
        } 
        #endregion

        #region 关闭窗体
        private void m_cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion

        #region 窗体Load事件
        private void frmCaseHistoryStat_Diagnose_Load(object sender, EventArgs e)
        {
            m_mthLoadAllDept();
        } 
        #endregion

        #region 获取所有科室
        /// <summary>
        /// 获取所有科室
        /// </summary>
        private void m_mthLoadAllDept()
        {
            clsDept_Desc[] objDeptArr = null;
            try
            {

                clsCaseHistorySearchDomain m_objDomain = new clsCaseHistorySearchDomain();
                long lngRes = m_objDomain.m_lngGetAllDept(out objDeptArr);
                if (lngRes > 0 && objDeptArr != null && objDeptArr.Length > 0)
                {
                    m_cboOutDept.Items.Clear();
                    m_cboOutDept.Items.AddRange(objDeptArr);
                }
            }
            catch (Exception ex)
            {
                string strEx = ex.Message;
            }
        }
        #endregion

        #region 出院科室SelectedIndexChanged事件
        /// <summary>
        /// 出院科室SelectedIndexChanged事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_cboOutDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_objCurrentDept = null;
            m_lsvResultList.Items.Clear();
            m_lblSearchNums.Text = "共检索出0种疾病，0例诊断";
            if (m_cboOutDept.Items.Count > 0 && m_cboOutDept.SelectedIndex >= 0)
            {
                clsDept_Desc objDept = m_cboOutDept.SelectedItem as clsDept_Desc;
                if (objDept != null)
                {
                    m_objCurrentDept = objDept;
                }
            }
        }
        #endregion

        #region 将DataTable的内容填充进ListView
        /// <summary>
        /// 将DataTable的内容填充进ListView
        /// </summary>
        /// <param name="p_dtbResult">DataTable</param>
        private void m_mthSetTableToListView(DataTable p_dtbResult)
        {
            if (p_dtbResult == null || p_dtbResult.Rows.Count <= 0)
            {
                m_lsvResultList.Items.Clear();
                m_lblSearchNums.Text = "共检索出0种疾病，0例诊断";
                return;
            }

            try
            {
                m_lsvResultList.Items.Clear();
                m_lsvResultList.BeginUpdate();
                this.Cursor = Cursors.WaitCursor;
                m_lblSearchNums.Text = "共检索出" + p_dtbResult.Rows.Count.ToString() + "种疾病," 
                    + p_dtbResult.Rows.Count.ToString() + "例诊断";
                for (int i = 0; i < p_dtbResult.Rows.Count; i++)
                {
                    ListViewItem lsi = new ListViewItem(new string[]{p_dtbResult.Rows[i]["DiagName"].ToString(),
                    p_dtbResult.Rows[i]["ICD10"].ToString(),
                    p_dtbResult.Rows[i]["Num"].ToString()});
                    m_lsvResultList.Items.Add(lsi);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
                m_lsvResultList.EndUpdate();
            }
        }
        #endregion
    }
}