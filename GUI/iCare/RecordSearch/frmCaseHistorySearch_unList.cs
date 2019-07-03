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
    public partial class frmCaseHistorySearch_unList : frmBaseForm
    {
        #region 全局变量
        /// <summary>
        /// 当前选定科室
        /// </summary>
        private clsDept_Desc m_objCurrentDept = null; 
        #endregion

        #region 构造方法
        /// <summary>
        /// 查询尚未编目的出院病人
        /// </summary>
        public frmCaseHistorySearch_unList()
        {
            InitializeComponent();
        } 
        #endregion

        #region 窗体Load事件
        /// <summary>
        /// 窗体Load事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCaseHistorySearch_unList_Load(object sender, EventArgs e)
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
            m_lsvRecordList.Items.Clear();
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

        #region 查询按钮Click事件
        /// <summary>
        /// 查询按钮Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_cmdQuery_Click(object sender, EventArgs e)
        {
            this.label6.Text = "";
            string strDeptID = null;
            if (m_objCurrentDept != null)
            {
                strDeptID = m_objCurrentDept.m_strDeptNewID;
            }
            string strOutDateBegin = m_dtpOutDate1.Value.ToString("yyyy-MM-dd 00:00:00");
            string strOutDateEnd = m_dtpOutDate2.Value.ToString("yyyy-MM-dd 00:00:00");
            DataTable dtbResutl = null;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                clsCaseHistorySearchDomain m_objDomain = new clsCaseHistorySearchDomain();
                long lngRes = m_objDomain.m_lngGetUnlistOutPatient(strOutDateBegin, strOutDateEnd, strDeptID, out dtbResutl);
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

        #region 清空按钮Click事件
        /// <summary>
        /// 清空按钮Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_cmdClear_Click(object sender, EventArgs e)
        {
            m_cboOutDept.SelectedIndex = -1;
            m_dtpOutDate1.Value = DateTime.Now;
            m_dtpOutDate2.Value = DateTime.Now;
            m_lsvRecordList.Items.Clear();
        } 
        #endregion

        #region 关闭按钮Click事件
        /// <summary>
        /// 关闭按钮Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                m_lsvRecordList.Items.Clear();
                this.label6.Text = "没有查找到相关病人！";
                return;
            }
            try
            {
                m_lsvRecordList.Items.Clear();
                m_lsvRecordList.BeginUpdate();
                this.Cursor = Cursors.WaitCursor;
                for (int i = 0; i < p_dtbResult.Rows.Count; i++)
                {
                    ListViewItem lsi = new ListViewItem(new string[]{p_dtbResult.Rows[i]["PatientID"].ToString(),
                    p_dtbResult.Rows[i]["InPatientID"].ToString(),
                    p_dtbResult.Rows[i]["PatientName"].ToString(),
                    (Convert.ToDateTime(p_dtbResult.Rows[i]["OutHospitalDate"])).ToString("yyyy年MM月dd日"),
                    p_dtbResult.Rows[i]["OutDeptName"].ToString()});
                    TimeSpan ts = DateTime.Now - Convert.ToDateTime(p_dtbResult.Rows[i]["SubmitDate"]);
                    if (ts.TotalDays >= 7)
                    {
                        lsi.ForeColor = Color.Red;
                    }
                    else if (ts.TotalDays >= 3)
                    {
                        lsi.ForeColor = Color.DarkOrange;
                    }
                    lsi.Tag = Convert.ToInt64(p_dtbResult.Rows[i]["Emr_Seq"]);
                    m_lsvRecordList.Items.Add(lsi);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
                m_lsvRecordList.EndUpdate();
            }
        }
        #endregion

        #region 查询结果ListView的DoubleClick事件
        private void m_lsvRecordList_DoubleClick(object sender, EventArgs e)
        {
            if (m_lsvRecordList.Items.Count > 0 && m_lsvRecordList.SelectedItems.Count > 0)
            {
                clsPatient objPa = new clsPatient(m_lsvRecordList.SelectedItems[0].SubItems[1].Text.Trim());

                frmInHospitalMainRecord_GXForCH frmRecord = new frmInHospitalMainRecord_GXForCH();
                frmRecord.MdiParent = this.MdiParent;
                frmRecord.Show();
                frmRecord.m_mthSetSelectedPatient(objPa);
            }
        } 
        #endregion
    }
}