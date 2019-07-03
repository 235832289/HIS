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
    /// <summary>
    /// 药品外退
    /// </summary>
    public partial class frmForeignRetreatOutStorage : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 全局变量
        /// <summary>
        /// 药品出库主表数据
        /// </summary>
        internal DataTable m_dtbMainData = null;
        /// <summary>
        /// 当前药品出库主表显示数据
        /// </summary>
        internal DataView m_dtvCurrentMainView = null;
        /// <summary>
        /// 药品出库子表数据
        /// </summary>
        internal DataTable m_dtbSubData = null;
        /// <summary>
        /// 仓库ID
        /// </summary>
        internal string m_strStorageID = string.Empty;
        /// <summary>
        /// 药品字典
        /// </summary>
        internal DataTable m_dtbMedicinDict = null;
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
        #endregion

        #region 构造函数
        /// <summary>
        /// 药品外退
        /// </summary>
        public frmForeignRetreatOutStorage()
        {
            InitializeComponent();
            m_dgvMain.AutoGenerateColumns = false;
            m_dgvDetail.AutoGenerateColumns = false;

            m_dtpSearchBeginDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            m_dtpSearchEndDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            m_cboBillState.SelectedIndex = 0;
        } 

        /// <summary>
        /// 药品外退
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        public frmForeignRetreatOutStorage(string p_strStorageID)
            : this()
        {
            m_strStorageID = p_strStorageID;
            ((clsCtl_ForeignRetreatOutStorage)objController).m_mthCheckHasAdminRole(LoginInfo.m_strEmpID, out m_blnIsAdmin);
            ((clsCtl_ForeignRetreatOutStorage)objController).m_mthGetIsImmAccount(out m_blnIsImmAccount);

            m_mthGetMainDate();
        } 
        #endregion

        #region 方法
        public override void CreateController()
        {
            this.objController = new clsCtl_ForeignRetreatOutStorage();
            objController.Set_GUI_Apperance(this);
        }

        #region 异步获取主表内容
        /// <summary>
        /// 异步获取主表内容
        /// </summary>
        private void m_mthGetMainDate()
        {
            DateTime dtmBegin = Convert.ToDateTime(Convert.ToDateTime(m_dtpSearchBeginDate.Text).ToString("yyyy-MM-dd 00:00:00"));
            DateTime dtmEnd = Convert.ToDateTime(Convert.ToDateTime(m_dtpSearchEndDate.Text).ToString("yyyy-MM-dd 23:59:59"));
            if (dtmBegin.Date > dtmEnd)
            {
                return;
            }

            System.Collections.ArrayList arrPa = new System.Collections.ArrayList();
            arrPa.Add(dtmBegin);
            arrPa.Add(dtmEnd);
            arrPa.Add(m_strStorageID);
            arrPa.Add(m_txtProviderName.Text);
            arrPa.Add(m_txtMedicineName.Text);

            if (!m_bgwGetData.IsBusy)
            {
                m_bgwGetData.RunWorkerAsync(arrPa);
            }
        }
        #endregion
        #endregion

        #region 事件
        private void m_cmdExitAuditing_Click(object sender, EventArgs e)
        {
            ((clsCtl_ForeignRetreatOutStorage)objController).m_mthUnCommitOutStorage();
        }

        private void m_cmdAuditing_Click(object sender, EventArgs e)
        {
            m_cmdAuditing.Enabled = false;
            m_pnlWaiting.Visible = true;
            Application.DoEvents();

            try
            {
                this.Cursor = Cursors.WaitCursor;
                ((clsCtl_ForeignRetreatOutStorage)objController).m_mthCommitOutStorage();
            }
            catch (Exception Ex)
            {
                string strEx = Ex.Message;
            }
            finally
            {
                this.Cursor = Cursors.Default;
                m_cmdAuditing.Enabled = true;
                m_pnlWaiting.Visible = false;
            }
        }

        private void m_cmdDelete_Click(object sender, EventArgs e)
        {
            ((clsCtl_ForeignRetreatOutStorage)objController).m_mthDeleteOutStorage();
        }

        private void m_cmdModify_Click(object sender, EventArgs e)
        {
            clsMS_OutStorage_VO objMain = null;
            clsMS_OutStorageDetail_VO[] objDetail = null;
            ((clsCtl_ForeignRetreatOutStorage)objController).m_mthModify(out objMain, out objDetail);

            if (objMain == null)
            {
                return;
            }

            int intSelectedSubRow = 0;
            if (m_dgvDetail.SelectedRows != null && m_dgvDetail.SelectedRows.Count > 0)
            {
                intSelectedSubRow = m_dgvDetail.SelectedRows[0].Index;
            }
            frmForeignRetreatOutStorageDetail frmMO = new frmForeignRetreatOutStorageDetail(m_strStorageID, objMain, objDetail, intSelectedSubRow);
            frmMO.FormClosed += new FormClosedEventHandler(frmMO_FormClosed);
            if(objDetail != null)
                frmMO.m_txtVendor.Enabled = false;

            if (objMain.m_intFORMTYPE_INT == 5)
            {
                frmMO.intInitial = 1;
            }
            else
            {
                frmMO.intInitial = 0;
            }

            frmMO.ShowDialog();
        }

        private void m_cmdNewMake_Click(object sender, EventArgs e)
        {
            frmForeignRetreatOutStorageDetail frmMO = new frmForeignRetreatOutStorageDetail(m_strStorageID);
            frmMO.FormClosed += new FormClosedEventHandler(frmMO_FormClosed);
            frmMO.intInitial = 0;
            frmMO.ShowDialog();
        }

        private void frmMO_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_mthGetMainDate();
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

        private void m_lblSelectAll_Click(object sender, EventArgs e)
        {
            if (m_dgvMain.Rows.Count > 0)
            {
                if (m_lblSelectAll.Text == "全选")
                {
                    m_lblSelectAll.Text = "反选";
                    for (int iRow = 0; iRow < m_dgvMain.Rows.Count; iRow++)
                    {
                        m_dgvMain.Rows[iRow].Cells[0].Value = true;
                    }
                }
                else if (m_lblSelectAll.Text == "反选")
                {
                    m_lblSelectAll.Text = "全选";
                    for (int iRow = 0; iRow < m_dgvMain.Rows.Count; iRow++)
                    {
                        m_dgvMain.Rows[iRow].Cells[0].Value = false;
                    }
                }
            }  
        }

        private void m_bgwGetData_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Collections.ArrayList arrPa = e.Argument as System.Collections.ArrayList;
            ((clsCtl_ForeignRetreatOutStorage)objController).m_mthGetMainData(arrPa[2].ToString(), Convert.ToDateTime(arrPa[0]), Convert.ToDateTime(arrPa[1]), 
                arrPa[3].ToString(), arrPa[4].ToString(),out m_dtbMainData);

            if (m_dtbMedicinDict == null)
            {
                ((clsCtl_ForeignRetreatOutStorage)objController).m_mthGetMedicineInfo();
            }
        }

        private void m_bgwGetData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            m_dtvCurrentMainView = new DataView(m_dtbMainData);
            ((clsCtl_ForeignRetreatOutStorage)objController).m_mthFilterMainDataPage1();
        }

        private void m_dgvMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            m_cmdModify_Click(null, null);
        }

        private void m_dgvMain_CurrentCellChanged(object sender, EventArgs e)
        {
            if (m_dgvMain.CurrentCell == null)
            {
                return;
            }

            DataRowView drvSelected = m_dtvCurrentMainView[m_dgvMain.CurrentCell.RowIndex];
            if (drvSelected != null)
            {
                long lngSEQ = Convert.ToInt64(drvSelected["SERIESID_INT"]);
                ((clsCtl_ForeignRetreatOutStorage)objController).m_mthGetOutStorageDetail(lngSEQ, out m_dtbSubData);
                DataView dtvSub = new DataView(m_dtbSubData);
                m_dgvDetail.DataSource = dtvSub;

                ((clsCtl_ForeignRetreatOutStorage)objController).m_mthGetAllSubMoney();
            }
        }

        private void m_dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            m_cmdModify_Click(null, null);
        }

        private void m_cmdInAccount_Click(object sender, EventArgs e)
        {
            ((clsCtl_ForeignRetreatOutStorage)objController).m_mthInAccount();
        }

        private void m_cmdOutAccount_Click(object sender, EventArgs e)
        {

        }

        private void m_txtMedicineName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_ForeignRetreatOutStorage)objController).m_mthShowQueryMedicineForm(m_txtMedicineName.Text);
            }
        }

        private void m_dgvDetail_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int iRow = 0; iRow < m_dgvDetail.Rows.Count; iRow++)
            {
                m_dgvDetail.Rows[iRow].Cells[0].Value = iRow + 1;
            }
            ((clsCtl_ForeignRetreatOutStorage)objController).m_mthGetAllMoney();
            ((clsCtl_ForeignRetreatOutStorage)objController).m_mthGetAllSubMoney();
        }

        private void m_dgvDetail_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            for (int iRow = 0; iRow < m_dgvDetail.Rows.Count; iRow++)
            {
                m_dgvDetail.Rows[iRow].Cells[0].Value = iRow + 1;
            }
            ((clsCtl_ForeignRetreatOutStorage)objController).m_mthGetAllMoney();
            ((clsCtl_ForeignRetreatOutStorage)objController).m_mthGetAllSubMoney();
        }

        private void m_txtProviderName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_ForeignRetreatOutStorage)objController).m_mthShowVendor(m_txtProviderName.Text);
            }
        }

        private void m_cboBillState_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((clsCtl_ForeignRetreatOutStorage)objController).m_mthFilterMainDataPage1();
        }
        #endregion

        private void m_dgvDetail_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataGridViewRow dgr = m_dgvDetail.Rows[e.RowIndex];
            if (dgr.Cells[5].Value.ToString() == "UNKNOWN")
            {
                dgr.Cells[5].Value = "";
            }
        }

        private void frmForeignRetreatOutStorage_Load(object sender, EventArgs e)
        {
            ((clsCtl_ForeignRetreatOutStorage)objController).m_mthGetStoreRoomName();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmForeignRetreatOutStorageDetail frmMO = new frmForeignRetreatOutStorageDetail(m_strStorageID);
            frmMO.FormClosed += new FormClosedEventHandler(frmMO_FormClosed);
            frmMO.intInitial = 1;
            frmMO.ShowDialog();
        }
    }
}