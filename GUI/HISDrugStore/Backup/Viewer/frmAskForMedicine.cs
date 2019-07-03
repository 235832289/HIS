using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.GUI_Base;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 药房请领
    /// </summary>
    public partial class frmAskForMedicine : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {   
        /// <summary>
        /// 构造函数
        /// </summary>
        public frmAskForMedicine()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 重写基类方法
        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsCtl_AskForMedicine();
            objController.Set_GUI_Apperance(this);
        }
        /// <summary>
        /// 初始化控件数据
        /// </summary>
        private void m_mthInitailControls()
        {
            this.m_dgvDetail.AutoGenerateColumns = false;
            this.m_dgvMain.AutoGenerateColumns = false;
            m_dtApplyDept = new DataTable();
            ((clsCtl_AskForMedicine)this.objController).m_mthGetApplyDeptInfo(out m_dtApplyDept);
            this.m_txtApplyDept.m_mthInitDeptData(m_dtApplyDept);
            ((clsCtl_AskForMedicine)this.objController).m_mthGetExportDeptInfo();
            ((clsCtl_AskForMedicine)this.objController).m_mthGetCurrentDayAskInfo(string.Empty,string.Empty);
            this.m_cboStatus.SelectedIndex = 0;
            this.m_cboExportDept.SelectedIndex = 0;
            this.m_datBegin.Focus();
            this.m_cboStatus.SelectedIndex = 0;
            this.m_cboExportDept.SelectedIndex = 0;
            this.m_datBegin.Focus();
        }
        /// <summary>
        /// 请领科室列表
        /// </summary>
        public DataTable m_dtApplyDept;
        private void frmAskForMedicine_Load(object sender, EventArgs e)
        {
            this.m_mthInitailControls();
            this.m_bgwGetMedData.RunWorkerAsync();
        }
        private void m_btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_btnNew_Click(object sender, EventArgs e)
        {
            frmAskForMedDetail frmDetail = new frmAskForMedDetail();
            //frmDetail.frmMain = this;
            frmDetail.ShowDialog();
        }

        private void m_lblSelected_Click(object sender, EventArgs e)
        {
            if (this.m_dgvMain.Rows.Count > 0)
            {
                this.m_dgvMain.CurrentCell = this.m_dgvMain.Rows[0].Cells["m_txtBillNo"];
                if (this.m_lblSelected.Text == "全选")
                {
                    m_lblSelected.Text = "反选";
                    for (int iRow = 0; iRow < m_dgvMain.Rows.Count; iRow++)
                    {
                        m_dgvMain.Rows[iRow].Cells[0].Value = true;
                    }
                }
                else if (m_lblSelected.Text == "反选")
                {
                    m_lblSelected.Text = "全选";
                    for (int iRow = 0; iRow < m_dgvMain.Rows.Count; iRow++)
                    {
                        m_dgvMain.Rows[iRow].Cells[0].Value = false;
                    }
                }
            }  
        }

        private void m_btnFind_Click(object sender, EventArgs e)
        {
            this.m_mthGetMainData();
        }
        #region 异步获取主表内容
        /// <summary>
        /// 异步获取主表内容
        /// </summary>
        private void m_mthGetMainData()
        {
            this.m_dgvMain.DataSource = null;
            this.m_btnFind.Tag =true;
            if (!m_bgwGetData.IsBusy)
            {
                m_bgwGetData.RunWorkerAsync();
            }
        }
        #endregion
        private void m_dgvMain_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.m_dgvMain.CurrentCell == null)
                return;
            ((clsCtl_AskForMedicine)this.objController).m_lngGetAskDetailInfoByid();
         
        }

        private void m_bgwGetData_DoWork(object sender, DoWorkEventArgs e)
        {
            ((clsCtl_AskForMedicine)this.objController).m_mthGetAskInfoByConditions();
        }

        private void m_bgwGetData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ((clsCtl_AskForMedicine)this.objController).m_mthBindData();
        }

        private void m_dgvDetail_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int iRow = 0; iRow < this.m_dgvDetail.Rows.Count; iRow++)
            {
                m_dgvDetail.Rows[iRow].Cells[0].Value = iRow + 1;
            }
        }

        private void m_dgvDetail_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            for (int iRow = 0; iRow < this.m_dgvDetail.Rows.Count; iRow++)
            {
                m_dgvDetail.Rows[iRow].Cells[0].Value = iRow + 1;
            }
        }

        private void m_lblSelected_MouseEnter(object sender, EventArgs e)
        {
            this.m_lblSelected.ForeColor = Color.Maroon;
            this.Cursor = Cursors.Hand;
        }

        private void m_lblSelected_MouseLeave(object sender, EventArgs e)
        {
            this.m_lblSelected.ForeColor = SystemColors.MenuHighlight;
            this.Cursor = Cursors.Default;
        }

        private void m_txtApplyDept_FocusNextControl(object sender, EventArgs e)
        {
            this.m_cboExportDept.Focus();
        }

        private void m_datBegin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }

        private void m_txtMedName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_AskForMedicine)objController).m_mthShowQueryMedicineForm(this.m_txtMedName.Text);
            }
        }

        private void m_dgvMain_DoubleClick(object sender, EventArgs e)
        {
            if (this.m_dgvMain.CurrentCell == null)
                return;
            m_intSeleRowIndex = this.m_dgvMain.CurrentCell.RowIndex;
            frmAskForMedDetail frmDetail = new frmAskForMedDetail();
            frmDetail.m_btnNext.Enabled = false;
          //  frmDetail.frmMain = this;
            frmDetail.IsCanModify = this.m_dgvMain.Rows[this.m_dgvMain.CurrentCell.RowIndex].Cells["m_txtStatus"].Value.ToString() == "新制" ? true : false;

            frmDetail.m_dtApplyMedicine = (DataTable)this.m_dgvDetail.DataSource;
            frmDetail.m_lngMainSEQ = Convert.ToInt64(this.m_dgvMain.Rows[this.m_dgvMain.CurrentCell.RowIndex].Cells["m_txtSeq"].Value);
            frmDetail.m_cboAskDept.Text = this.m_dgvMain.Rows[this.m_dgvMain.CurrentCell.RowIndex].Cells["m_txtAskDeptName"].Value.ToString();
            frmDetail.m_cboAskDept.AccessibleName = this.m_dgvMain.Rows[this.m_dgvMain.CurrentCell.RowIndex].Cells["m_txtDeptid"].Value.ToString();
            frmDetail.m_txtAskBillNo.Text = this.m_dgvMain.Rows[this.m_dgvMain.CurrentCell.RowIndex].Cells["m_txtBillNo"].Value.ToString();
            frmDetail.m_datApplyDate.Value = Convert.ToDateTime(this.m_dgvMain.Rows[this.m_dgvMain.CurrentCell.RowIndex].Cells["m_txtAskDate"].Value.ToString());
            frmDetail.m_txtAsker.Text = this.m_dgvMain.Rows[this.m_dgvMain.CurrentCell.RowIndex].Cells["m_txtAskName"].Value.ToString();
            frmDetail.m_txtAsker.Tag = this.m_dgvMain.Rows[this.m_dgvMain.CurrentCell.RowIndex].Cells["m_txtAskerid"].Value.ToString();
            frmDetail.m_txtComment.Text = this.m_dgvMain.Rows[this.m_dgvMain.CurrentCell.RowIndex].Cells["m_txtComment"].Value.ToString();
            frmDetail.FormClosed+=new FormClosedEventHandler(frmDetail_FormClosed);
            frmDetail.ShowDialog();

        }
        private int m_intSeleRowIndex = 0;
        private void frmDetail_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.m_btnFind.Tag == null)
            {
                ((clsCtl_AskForMedicine)this.objController).m_mthGetCurrentDayAskInfo(string.Empty,string.Empty);
            }
            else
            {
                ((clsCtl_AskForMedicine)this.objController).m_mthGetAskInfoByConditions();
                ((clsCtl_AskForMedicine)this.objController).m_mthBindData();
            }
            this.m_dgvMain.CurrentCell = this.m_dgvMain.Rows[m_intSeleRowIndex].Cells[0];
          
        }
        private void m_btnModify_Click(object sender, EventArgs e)
        {
            if (this.m_dgvMain.SelectedRows.Count <= 0)
            {
                return;
            }
            m_dgvMain_DoubleClick(null, null);
        }
        private void m_btnDelete_Click(object sender, EventArgs e)
        {
            if (this.m_dgvMain.CurrentCell != null && this.m_dgvMain.CurrentCell.ColumnIndex == 0)
            {
                this.m_dgvMain.CurrentCell = this.m_dgvMain.Rows[this.m_dgvMain.CurrentCell.RowIndex].Cells["m_txtBillNo"];
            }
            bool m_blnChecked = false;
            Application.DoEvents();
            int m_intBillNo = 0;
            for (int i = 0; i < this.m_dgvMain.Rows.Count; i++)
            {

                if (this.m_dgvMain.Rows[i].Cells["m_chkSelected"].Value != null && this.m_dgvMain.Rows[i].Cells[0].Value.ToString() == "True")
                {
                    m_blnChecked = true;
                    m_intBillNo++;
                    string m_strStatus = m_dgvMain.Rows[i].Cells["m_txtStatus"].Value.ToString().Trim();
                    if (m_strStatus != "新制")
                    {
                        MessageBox.Show("您所选择的第" + (m_intBillNo) + "张请领单已经" + m_strStatus + ",不能进行删除！", "药房请领", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            if (!m_blnChecked)
            {
                MessageBox.Show("请先选择要删除的请领单！", "药房请领", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ((clsCtl_AskForMedicine)this.objController).m_mthDeleteAskInfo();
        }
        private void m_btnCommit_Click(object sender, EventArgs e)
        {
            if (this.m_dgvMain.CurrentCell != null && this.m_dgvMain.CurrentCell.ColumnIndex == 0)
            {
                this.m_dgvMain.CurrentCell = this.m_dgvMain.Rows[this.m_dgvMain.CurrentCell.RowIndex].Cells["m_txtBillNo"];
            }
            bool m_blnChecked = false;
            Application.DoEvents();
            int m_intBillNo = 0;
            for (int i = 0; i < this.m_dgvMain.Rows.Count; i++)
            {
                if (this.m_dgvMain.Rows[i].Cells["m_chkSelected"].Value != null && this.m_dgvMain.Rows[i].Cells[0].Value.ToString() == "True")
                {
                    m_blnChecked = true;
                    m_intBillNo++;
                    string m_strStatus = m_dgvMain.Rows[i].Cells["m_txtStatus"].Value.ToString().Trim();
                    if (m_strStatus != "新制")
                    {
                        MessageBox.Show("您所选择的第" + (m_intBillNo) + "张请领单已经" + m_strStatus + ",不能进行提交！", "药房请领", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            if (!m_blnChecked)
            {
                MessageBox.Show("请先选择要提交的请领单！", "药房请领", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ((clsCtl_AskForMedicine)this.objController).m_mthCommitAskInfo();
        }
        private void m_cboExportDept_Enter(object sender, EventArgs e)
        {
            System.Windows.Forms.SendKeys.Send("{F4}");
        }
        private void m_cboStatus_Enter(object sender, EventArgs e)
        {
            System.Windows.Forms.SendKeys.Send("{F4}");
        }
        private void m_txtApplyDept_Enter(object sender, EventArgs e)
        {  
          
        }
        private void m_cboStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.m_txtMedName.Focus();
            }
        }
        private void m_bgwGetMedData_DoWork(object sender, DoWorkEventArgs e)
        {
            ((clsCtl_AskForMedicine)this.objController).m_mthIniMedData();
        }
    }
}