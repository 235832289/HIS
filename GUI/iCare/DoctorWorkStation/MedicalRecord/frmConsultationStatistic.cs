using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Mid = com.digitalwave.PublicMiddleTier;
using Exp = com.digitalwave.emr.BEDExplorer;

namespace iCare
{
    public partial class frmConsultationStatistic : iCare.iCareBaseForm.frmBaseForm
    {
        #region 全局变量
        /// <summary>
        /// 所有的科室
        /// </summary>
        private DataTable m_dtbDept = null;
        /// <summary>
        /// 当前查询出的数据
        /// </summary>
        private DataTable m_dtbCurrentData = null;
        #endregion

        #region 构造函数
        /// <summary>
        /// 会诊记录查询
        /// </summary>
        public frmConsultationStatistic()
        {
            InitializeComponent();

            m_mthGetAllDept();

            m_lblAllResult.Text = string.Empty;
            m_lblHasReplyResult.Text = string.Empty;
            m_lblUnReplyResult.Text = string.Empty;
            m_dtpSearchStartTime.Value = DateTime.Now.AddMonths(-1);
            m_cboSendOrReceive.SelectedIndex = 0;

            m_mthCheckRole();
        } 
        #endregion

        #region 事件
        private void m_lsvDeptList_DoubleClick(object sender, EventArgs e)
        {
            if (m_lsvDeptList.SelectedItems.Count > 0)
            {
                m_txtApplyConsultationDept.Text = m_lsvDeptList.SelectedItems[0].SubItems[1].Text;
                m_txtApplyConsultationDept.Tag = m_lsvDeptList.SelectedItems[0].Tag;
                m_txtSearchDept.Text = string.Empty;
                m_pnlSearchWindow.Visible = false;
            }
        }

        private void m_lsvDeptList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_lsvDeptList_DoubleClick(null, null);
            }
        }

        private void m_txtSearchDept_TextChanged(object sender, EventArgs e)
        {
            m_mthSearchDept(m_txtSearchDept.Text.Trim());
        }

        private void m_lsvDeptList_Leave(object sender, EventArgs e)
        {
            if (!m_txtSearchDept.Focused && !m_txtApplyConsultationDept.Focused)
            {
                m_pnlSearchWindow.Visible = false;
            }
        }

        private void m_txtSearchDept_Leave(object sender, EventArgs e)
        {
            if (!m_lsvDeptList.Focused && !m_txtApplyConsultationDept.Focused)
            {
                m_pnlSearchWindow.Visible = false;
            }
        }

        private void m_txtApplyConsultationDept_Leave(object sender, EventArgs e)
        {
            m_pnlSearchWindow.Visible = false;
        }

        private void m_chkSelectOneDept_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkSelectOneDept.Checked)
            {
                m_chkSelectAllDept.Checked = false;
                m_cmdShowAllDept.Enabled = true;

                if (m_cboSendOrReceive.SelectedIndex == 0)
                {
                    label2.Text = "会诊申请发送日期范围:";
                    label5.Text = "共发送会诊申请";
                }
                else if (m_cboSendOrReceive.SelectedIndex == 1)
                {
                    label2.Text = "会诊申请接收日期范围:";
                    label5.Text = "共接收会诊申请";
                }
            }
        }

        private void m_chkSelectAllDept_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkSelectAllDept.Checked)
            {
                m_chkSelectOneDept.Checked = false;
                m_txtApplyConsultationDept.Text = string.Empty;
                m_txtApplyConsultationDept.Tag = null;
                m_cmdShowAllDept.Enabled = false;

                label5.Text = "共有会诊申请";
            }
        }

        private void m_cmdShowAllDept_Click(object sender, EventArgs e)
        {
            m_mthShowAllDeptToList();
        }

        private void m_txtSearchDept_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && m_lsvDeptList.Items.Count > 0)
            {
                m_lsvDeptList.Focus();
                m_lsvDeptList.Items[0].Selected = true;
            }
        }

        private void m_cmdSearch_Click(object sender, EventArgs e)
        {
            m_mthSearchConsultation();
        }

        private void m_lsvResult_DoubleClick(object sender, EventArgs e)
        {
            m_mthOpenConsultationRecord();
        }

        private void m_chkAllResult_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkAllResult.Checked)
            {
                m_lsvResult.Items.Clear();
                m_chkHasReply.Checked = false;
                m_chkUnReply.Checked = false;

                if (m_dtbCurrentData != null && m_dtbCurrentData.Rows.Count > 0)
                {
                    m_mthSetDataTableToListView(m_dtbCurrentData);
                }                
            }
            else if (!m_chkHasReply.Checked && !m_chkUnReply.Checked)
            {
                m_lsvResult.Items.Clear();
            }
        }

        private void m_chkHasReply_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkHasReply.Checked)
            {
                m_lsvResult.Items.Clear();
                m_chkAllResult.Checked = false;
                m_chkUnReply.Checked = false;

                if (m_dtbCurrentData != null && m_dtbCurrentData.Rows.Count > 0)
                {
                    m_mthSetHasReplyResult(m_dtbCurrentData);
                }
            }
            else if (!m_chkAllResult.Checked && !m_chkUnReply.Checked)
            {
                m_lsvResult.Items.Clear();
            }
        }

        private void m_chkUnReply_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkUnReply.Checked)
            {
                m_lsvResult.Items.Clear();
                m_chkHasReply.Checked = false;
                m_chkAllResult.Checked = false;

                if (m_dtbCurrentData != null && m_dtbCurrentData.Rows.Count > 0)
                {
                    m_mthSetUnReplyResult(m_dtbCurrentData);
                }
            }
            else if (!m_chkAllResult.Checked && !m_chkHasReply.Checked)
            {
                m_lsvResult.Items.Clear();
            }
        }

        private void m_cboSendOrReceive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_cboSendOrReceive.SelectedIndex == 0)
            {
                label2.Text = "会诊申请发送日期范围:";
                label5.Text = "共发送会诊申请";
            }
            else if (m_cboSendOrReceive.SelectedIndex == 1)
            {
                label2.Text = "会诊申请接收日期范围:";
                label5.Text = "共接收会诊申请";
            }
        }
        #endregion

        #region 方法
        #region 模糊查询科室
        /// <summary>
        /// 模糊查询科室
        /// </summary>
        /// <param name="p_strCondition">查询条件</param>
        private void m_mthSearchDept(string p_strCondition)
        {
            if (m_dtbDept != null)
            {
                DataView dtvDept = new DataView(m_dtbDept);
                string strF = "EXTENDID_VCHR like '" + p_strCondition
                    + "%' or DeptName like '" + p_strCondition + "%' or PYCODE_CHR like '" + p_strCondition + "%'";
                dtvDept.RowFilter = strF;
                try
                {
                    m_lsvDeptList.BeginUpdate();
                    m_lsvDeptList.Items.Clear();
                    for (int i = 0; i < dtvDept.Count; i++)
                    {
                        ListViewItem lsi = new ListViewItem(new string[] { dtvDept[i]["EXTENDID_VCHR"].ToString(),
                        dtvDept[i]["DeptName"].ToString()});
                        lsi.Tag = dtvDept[i]["DEPTID"].ToString();
                        m_lsvDeptList.Items.Add(lsi);
                    }
                }
                finally
                {
                    m_lsvDeptList.EndUpdate();
                }
                m_txtSearchDept.Focus();
            }
        }
        #endregion 

        #region 获取所有科室
        /// <summary>
        /// 获取所有科室(包括住院及门诊)
        /// </summary>
        private void m_mthGetAllDept()
        {
            clsConsultationDomain m_objDomain = new clsConsultationDomain();
            long lngRes = m_objDomain.m_lngGetAllDept(out m_dtbDept);
        } 
        #endregion

        #region 显示科室列表
        /// <summary>
        /// 显示科室列表
        /// </summary>
        private void m_mthShowAllDeptToList()
        {
            if (m_dtbDept != null)
            {
                try
                {
                    m_lsvDeptList.BeginUpdate();
                    m_lsvDeptList.Items.Clear();

                    int intDeptRow = m_dtbDept.Rows.Count;
                    DataRow objSelectedRow = null;
                    for (int i = 0; i < intDeptRow; i++)
                    {
                        objSelectedRow = m_dtbDept.Rows[i];
                        ListViewItem lsi = new ListViewItem(new string[] { objSelectedRow["EXTENDID_VCHR"].ToString(),
                        objSelectedRow["DeptName"].ToString()});
                        lsi.Tag = objSelectedRow["DEPTID"].ToString();
                        m_lsvDeptList.Items.Add(lsi);
                    }
                }
                finally
                {
                    m_lsvDeptList.EndUpdate();
                }
                m_pnlSearchWindow.Location = new System.Drawing.Point(m_txtApplyConsultationDept.Location.X + groupBox1.Location.X,
                    m_txtApplyConsultationDept.Location.Y + m_txtApplyConsultationDept.Size.Height + groupBox1.Location.Y);
                m_pnlSearchWindow.Visible = true;
                m_txtSearchDept.Focus();
            }
        } 
        #endregion

        #region 查询会诊记录
        /// <summary>
        /// 查询会诊记录
        /// </summary>
        private void m_mthSearchConsultation()
        {
            m_mthClearSearchResult();

            clsConsultationDomain objDomain = new clsConsultationDomain();
            DataTable dtbResult = new DataTable();
            long lngRes = 0;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (m_chkSelectAllDept.Checked)//查询全部科室
                {
                    lngRes = objDomain.m_lngSearchAllDeptConsultationSituation(Convert.ToDateTime(m_dtpSearchStartTime.Value.ToString("yyyy-MM-dd 00:00:00")),
                        Convert.ToDateTime(m_dtpSearchEndTime.Value.ToString("yyyy-MM-dd 23:59:59")), out dtbResult);
                }
                else if (m_chkSelectOneDept.Checked)//查询选定科室
                {
                    if (m_txtApplyConsultationDept.Tag == null)
                        return;
                    int intSendOrReceive = m_cboSendOrReceive.SelectedIndex;
                    if (intSendOrReceive < 0)
                    {
                        clsPublicFunction.ShowInformationMessageBox("请先确定查询发送或接收科室！");
                        return;
                    }

                    lngRes = objDomain.m_lngSearchSpesifyDeptConsultationSituation(m_txtApplyConsultationDept.Tag.ToString(),
                        Convert.ToDateTime(m_dtpSearchStartTime.Value.ToString("yyyy-MM-dd 00:00:00")),
                        Convert.ToDateTime(m_dtpSearchEndTime.Value.ToString("yyyy-MM-dd 23:59:59")),intSendOrReceive, out dtbResult);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            m_dtbCurrentData = dtbResult;
            m_mthSetDataTableToListView(dtbResult);
        } 
        #endregion

        #region 清空查询结果
        /// <summary>
        /// 清空查询结果
        /// </summary>
        private void m_mthClearSearchResult()
        {
            m_lblAllResult.Text = string.Empty;
            m_lblHasReplyResult.Text = string.Empty;
            m_lblUnReplyResult.Text = string.Empty;
            m_chkAllResult.Checked = true;
            m_dtbCurrentData = null;
            m_lsvResult.Items.Clear();
        } 
        #endregion

        #region 设置数据至列表
        /// <summary>
        /// 设置数据至列表
        /// </summary>
        /// <param name="p_dtbResult"></param>
        private void m_mthSetDataTableToListView(DataTable p_dtbResult)
        {
            m_lblAllResult.Text = "0";
            m_lblUnReplyResult.Text = "0";
            m_lblHasReplyResult.Text = "0";

            if (p_dtbResult == null || p_dtbResult.Rows.Count <= 0)
                return;

            m_lblAllResult.Text = p_dtbResult.Rows.Count.ToString();

            m_mthSetHasReplyResult(p_dtbResult);

            m_mthSetUnReplyResult(p_dtbResult);
        }

        /// <summary>
        /// 筛选已回复记录
        /// </summary>
        /// <param name="p_dtbResult"></param>
        private void m_mthSetHasReplyResult(DataTable p_dtbResult)
        {
            DataView dtView = new DataView(p_dtbResult);
            dtView.RowFilter = @"CONSULTATIONIDEA_RIGHT is not null";//已回复
            m_lblHasReplyResult.Text = dtView.Count.ToString();

            m_mthSetDataViewToList(dtView, "已回复");
        }

        /// <summary>
        /// 筛选未回复记录
        /// </summary>
        /// <param name="p_dtbResult"></param>
        private void m_mthSetUnReplyResult(DataTable p_dtbResult)
        {
            DataView dtView = new DataView(p_dtbResult);
            dtView.RowFilter = @"CONSULTATIONIDEA_RIGHT is null";//未回复
            m_lblUnReplyResult.Text = dtView.Count.ToString();

            m_mthSetDataViewToList(dtView, "未回复");
        }

        /// <summary>
        /// 设置DataView至ListView(此方法内不会清空ListView，如有需要需在外部清空)
        /// </summary>
        /// <param name="p_dtvResult">DataView</param>
        /// <param name="p_strStatus">回复状态</param>
        private void m_mthSetDataViewToList(DataView p_dtvResult, string p_strStatus)
        {
            if (p_dtvResult == null)
                return;

            Color clrFore = Color.Black;
            if (p_strStatus == "未回复")
            {
                clrFore = Color.Red;
            }

            try
            {
                m_lsvResult.BeginUpdate();
                for (int i = 0; i < p_dtvResult.Count; i++)
                {
                    ListViewItem lsi = new ListViewItem(new string[]{p_dtvResult[i]["HISINPATIENTID_CHR"].ToString(),
                        p_dtvResult[i]["lastname_vchr"].ToString(),
                        p_dtvResult[i]["sex_chr"].ToString().TrimEnd(),
                        Convert.ToDateTime(p_dtvResult[i]["HISINPATIENTDATE"]).ToString("yyyy-MM-dd HH:mm"),
                        p_dtvResult[i]["AskDeptname_vchr"].ToString(), 
                        p_dtvResult[i]["MainDocName"].ToString(), 
                        Convert.ToDateTime(p_dtvResult[i]["CONSULTATIONDATE"]).ToString("yyyy-MM-dd HH:mm"),
                        p_dtvResult[i]["ApplyDeptname_vchr"].ToString(), p_strStatus});
                    lsi.Tag = p_dtvResult[i];
                    lsi.ForeColor = clrFore;
                    m_lsvResult.Items.Add(lsi);
                }
            }
            finally
            {
                m_lsvResult.EndUpdate();
            }
        }
        #endregion

        #region 检查当前登录用户是否有会诊查询权限
        /// <summary>
        /// 检查当前登录用户是否有会诊查询权限
        /// </summary>
        private void m_mthCheckRole()
        {
            Mid::clsPublicMiddleTier objServ =
                (Mid::clsPublicMiddleTier)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(Mid::clsPublicMiddleTier));

            string strRoleID = null;
            long lngRes = objServ.m_lngCheckRoleByEmpIDAndRoleName(clsEMRLogin.LoginInfo.m_strEmpID, "会诊查询", out strRoleID);

            if (string.IsNullOrEmpty(strRoleID))
            {
                groupBox1.Enabled = false;
                m_lblWarning.Visible = true;
            }
            else
            {
                groupBox1.Enabled = true;
                m_lblWarning.Visible = false;
            }
        } 
        #endregion

        #region 打开选中的会诊记录
        /// <summary>
        /// 打开选中的会诊记录
        /// </summary>
        private void m_mthOpenConsultationRecord()
        {
            if (m_lsvResult.SelectedItems == null || m_lsvResult.SelectedItems.Count != 1)
                return;

            DataRowView objRow = m_lsvResult.SelectedItems[0].Tag as DataRowView;
            if (objRow == null)
                return;

            #region 设置当前病人
            //设置当前病人
            clsPatient objPatient = new clsPatient(objRow["inpatientid"].ToString(), objRow["HISINPATIENTID_CHR"].ToString(), null);
            objPatient.m_DtmSelectedHISInDate = Convert.ToDateTime(objRow["HISINPATIENTDATE"]);
            objPatient.m_DtmSelectedInDate = Convert.ToDateTime(objRow["inpatientdate"]);

            //将选中病人设置为全局可见
            MDIParent.s_ObjCurrentPatient = objPatient;
            Exp::clsHospitalManagerDomain objDomain = new Exp::clsHospitalManagerDomain();
            iCareData.clsEmrDept_VO objDeptNew;
            objDomain.m_lngGetSpecialDeptInfo(objRow["ASKCONSULTATIONDEPTID"].ToString(), out objDeptNew);
            if (objDeptNew != null)
            {
                MDIParent.m_objCurrentDepartment = objDeptNew;
                com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentDepartment = objDeptNew;
                objPatient.m_strDeptNewID = objDeptNew.m_strDEPTID_CHR;
            }
            clsPatientInBedInfo objNewBed = new clsPatientInBedInfo(objPatient);
            if (objNewBed != null && objNewBed.m_ObjLastSessionInfo != null)
            {
                if (objNewBed.m_ObjLastRoomInfo.m_intGetBedCount() > 0)
                    objPatient.m_strBedCode = objNewBed.m_ObjLastRoomInfo.m_objGetBedByIndex(0).m_ObjBed.m_StrBedName;
            } 
            #endregion

            //打开会诊记录
            frmConsultation frmRecord = new frmConsultation();
            frmRecord.MdiParent = clsEMRLogin.s_FrmMDI;
            frmRecord.WindowState = FormWindowState.Maximized;
            frmRecord.Show();
            objPatient.m_IntCharacter = 1;
            frmRecord.m_mthSetPatient(objPatient);
            MDIParent.s_ObjSaveCue.m_mthRemoveForm(frmRecord); 
        } 
        #endregion
        #endregion
    }
}