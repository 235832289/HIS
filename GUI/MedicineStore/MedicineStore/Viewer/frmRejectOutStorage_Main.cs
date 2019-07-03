using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    public partial class frmRejectOutStorage_Main : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 全局变量
        /// <summary>
        /// 药品出库主表数据
        /// </summary>
        internal DataTable m_dtbMainDataPage1 = null;
        /// <summary>
        /// 当前药品出库主表显示数据
        /// </summary>
        internal DataView m_dtvCurrentMainVienPage1 = null;
        /// <summary>
        /// 药品出库子表数据
        /// </summary>
        internal DataTable m_dtbSubDataPage1 = null;
        /// <summary>
        /// 仓库ID
        /// </summary>
        internal string m_strStorageID = string.Empty;

        /// <summary>
        /// 报表名
        /// </summary>
        internal string m_strReportName = string.Empty;
        
        /// <summary>
        /// 是否有药库管理员权限
        /// </summary>
        internal bool m_blnIsAdmin = false;
        /// <summary>
        /// 查询出来的金额
        /// </summary>
        internal DataTable m_dtbAllMoney = null;
        /// <summary>
        /// 是否审核即入帐
        /// </summary>
        internal bool m_blnIsImmAccount = false;
        /// <summary>
        /// 药品中的批号,有效期录入控制
        /// </summary>
        internal clsMS_MedicineTypeVisionmSet m_clsTypeVisVO;
        #endregion

        /// <summary>
        /// 报废出库
        /// </summary>
        private frmRejectOutStorage_Main()
        {
            InitializeComponent();

            m_dgvMainInfo.AutoGenerateColumns = false;
            m_dgvSubInfo.AutoGenerateColumns = false;

            m_dtpBeginDatePage1.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            m_dtpEndDatePage1.Text = DateTime.Now.ToString("yyyy年MM月dd日");

            m_cboStatusPage1.SelectedIndex = 0;
        }

        /// <summary>
        /// 报废出库
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        public frmRejectOutStorage_Main(string p_strStorageID,string p_strReportName)
            : this()
        {
            m_strStorageID = p_strStorageID;
            m_strReportName = p_strReportName;
            ((clsCtl_RejectOutStorage_Main)objController).m_mthCheckHasAdminRole(LoginInfo.m_strEmpID, out m_blnIsAdmin);
            ((clsCtl_RejectOutStorage_Main)objController).m_mthGetIsImmAccount(out m_blnIsImmAccount);

            m_mthGetMainDate();
        }

        #region 事件
        private void m_bgwGetData_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Collections.ArrayList arrPa = e.Argument as System.Collections.ArrayList;
            ((clsCtl_RejectOutStorage_Main)objController).m_mthGetMainData(arrPa[2].ToString(), Convert.ToDateTime(arrPa[0]), Convert.ToDateTime(arrPa[1]),
                arrPa[3].ToString(), out m_dtbMainDataPage1);
        }

        private void m_bgwGetData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            m_dtvCurrentMainVienPage1 = new DataView(m_dtbMainDataPage1);
            ((clsCtl_RejectOutStorage_Main)objController).m_mthFilterMainDataPage1();
        }        

        private void m_cmdNewMake_Click(object sender, EventArgs e)
        {
            frmRejectOutStorage frmRO = new frmRejectOutStorage(m_strStorageID, m_strReportName);
            frmRO.FormClosed += new FormClosedEventHandler(frmRO_FormClosed);
            frmRO.ShowDialog();
        }

        private void frmRO_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_mthGetMainDate();
        }

        private void m_cmdModify_Click(object sender, EventArgs e)
        {
            clsMS_OutStorage_VO objMain = null;
            clsMS_OutStorageDetail_VO[] objDetail = null;
            ((clsCtl_RejectOutStorage_Main)objController).m_mthModify(out objMain, out objDetail);

            if (objMain == null)
            {
                return;
            }

            int intSelectedSubRow = 0;
            if (m_dgvSubInfo.SelectedRows != null && m_dgvSubInfo.SelectedRows.Count > 0)
            {
                intSelectedSubRow = m_dgvSubInfo.SelectedRows[0].Index;
            }
            frmRejectOutStorage frmRO = new frmRejectOutStorage(m_strStorageID,m_strReportName, objMain, objDetail, intSelectedSubRow);
            frmRO.FormClosed+=new FormClosedEventHandler(frmRO_FormClosed);
            frmRO.ShowDialog();
        }

        private void m_cmdDelete_Click(object sender, EventArgs e)
        {
            ((clsCtl_RejectOutStorage_Main)objController).m_mthDeleteOutStorage();
        }

        private void m_cmdAuditing_Click(object sender, EventArgs e)
        {
            m_cmdAuditing.Enabled = false;
            m_pnlWaiting.Visible = true;
            Application.DoEvents();
            ((clsCtl_RejectOutStorage_Main)objController).m_mthCommitOutStorage();
            m_pnlWaiting.Visible = false;
            m_cmdAuditing.Enabled = true;
        }

        private void m_cmdExitAuditing_Click(object sender, EventArgs e)
        {
            ((clsCtl_RejectOutStorage_Main)objController).m_mthUnCommitOutStorage();
        }

        private void m_cmdInAccount_Click(object sender, EventArgs e)
        {
            ((clsCtl_RejectOutStorage_Main)objController).m_mthInAccount();
        }

        private void m_cmdOutAccount_Click(object sender, EventArgs e)
        {

        }

        private void m_cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_cmdSearch_Click(object sender, EventArgs e)
        {
            m_dtbAllMoney = null;
            m_mthGetMainDate();
        }

        private void m_dgvMainInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            m_cmdModify_Click(null, null);
        }

        private void m_dgvSubInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            m_cmdModify_Click(null, null);
        }

        private void m_dgvMainInfo_CurrentCellChanged(object sender, EventArgs e)
        {
            if (m_dgvMainInfo.CurrentCell == null)
            {
                return;
            }

            DataRowView drvSelected = m_dtvCurrentMainVienPage1[m_dgvMainInfo.CurrentCell.RowIndex];
            if (drvSelected != null)
            {
                long lngSEQ = Convert.ToInt64(drvSelected["SERIESID_INT"]);
                ((clsCtl_RejectOutStorage_Main)objController).m_mthGetOutStorageDetail(lngSEQ, out m_dtbSubDataPage1);
                DataView dtvSub = new DataView(m_dtbSubDataPage1);
                m_dgvSubInfo.DataSource = dtvSub;

                ((clsCtl_RejectOutStorage_Main)objController).m_mthGetAllSubMoney();
            }
        }

        private void m_dgvSubInfo_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int iRow = 0; iRow < m_dgvSubInfo.Rows.Count; iRow++)
            {
                m_dgvSubInfo.Rows[iRow].Cells[0].Value = iRow + 1;
            }
            ((clsCtl_RejectOutStorage_Main)objController).m_mthGetAllMoney();
            ((clsCtl_RejectOutStorage_Main)objController).m_mthGetAllSubMoney();
        }

        private void m_dgvSubInfo_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            for (int iRow = 0; iRow < m_dgvSubInfo.Rows.Count; iRow++)
            {
                m_dgvSubInfo.Rows[iRow].Cells[0].Value = iRow + 1;
            }
            ((clsCtl_RejectOutStorage_Main)objController).m_mthGetAllMoney();
            ((clsCtl_RejectOutStorage_Main)objController).m_mthGetAllSubMoney();
        }

        private void m_lblSelectAllPage1_Click(object sender, EventArgs e)
        {
            if (m_dgvMainInfo.Rows.Count > 0)
            {
                if (m_lblSelectAllPage1.Text == "全选")
                {
                    m_lblSelectAllPage1.Text = "反选";
                    for (int iRow = 0; iRow < m_dgvMainInfo.Rows.Count; iRow++)
                    {
                        m_dgvMainInfo.Rows[iRow].Cells[0].Value = true;
                    }
                }
                else if (m_lblSelectAllPage1.Text == "反选")
                {
                    m_lblSelectAllPage1.Text = "全选";
                    for (int iRow = 0; iRow < m_dgvMainInfo.Rows.Count; iRow++)
                    {
                        m_dgvMainInfo.Rows[iRow].Cells[0].Value = false;
                    }
                }
            }
        }

        private void m_cboStatusPage1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((clsCtl_RejectOutStorage_Main)objController).m_mthFilterMainDataPage1();
        }
        #endregion

        #region 方法
        public override void CreateController()
        {
            this.objController = new clsCtl_RejectOutStorage_Main();
            objController.Set_GUI_Apperance(this);
        }

        #region 异步获取主表内容
        /// <summary>
        /// 异步获取主表内容
        /// </summary>
        private void m_mthGetMainDate()
        {
            DateTime dtmBegin = Convert.ToDateTime(Convert.ToDateTime(m_dtpBeginDatePage1.Text).ToString("yyyy-MM-dd 00:00:00"));
            DateTime dtmEnd = Convert.ToDateTime(Convert.ToDateTime(m_dtpEndDatePage1.Text).ToString("yyyy-MM-dd 23:59:59"));
            if (dtmBegin.Date > dtmEnd)
            {
                return;
            }

            System.Collections.ArrayList arrPa = new System.Collections.ArrayList();
            arrPa.Add(dtmBegin);
            arrPa.Add(dtmEnd);
            arrPa.Add(m_strStorageID);
            arrPa.Add(m_txtAskIDPage1.Text);

            if (!m_bgwGetData.IsBusy)
            {
                m_bgwGetData.RunWorkerAsync(arrPa);
            }
        }
        #endregion

        private void m_dgvSubInfo_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataGridViewRow dgr = m_dgvSubInfo.Rows[e.RowIndex];
            if (dgr.Cells[4].Value.ToString() == "UNKNOWN")
            {
                dgr.Cells[4].Value = "";
            }
        }
        #endregion
    }
}