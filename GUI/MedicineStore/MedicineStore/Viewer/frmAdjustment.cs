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
    /// 药品调价
    /// </summary>
    public partial class frmAdjustment : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 全局变量
        /// <summary>
        /// 仓库ID
        /// </summary>
        internal string m_strStorageID = string.Empty;
        /// <summary>
        /// 药品字典
        /// </summary>
        internal DataTable m_dtbMedicineDict = null;
        /// <summary>
        /// 主表记录
        /// </summary>
        internal DataTable m_dtbAdjustMain = null;
        /// <summary>
        /// 明细表记录
        /// </summary>
        internal DataTable m_dtbAdjustDetail = null;
        /// <summary>
        /// 当前用户是否有管理员权限
        /// </summary>
        internal bool m_blnIsAdmin = false;
        /// <summary>
        /// 是否审核即入帐
        /// </summary>
        internal bool m_blnIsImmAccount = false;
        /// <summary>
        /// 同一药品是否分批号调价
        /// </summary>
        internal bool m_blnIsDiffLotNO = false;
        /// <summary>
        /// 调价是否同时调整药品基本表价格
        /// </summary>
        internal bool m_blnIsChangeBasePrice = false;
        internal int m_intDiffLotNO = 0;
        #endregion

        #region 构造函数
        /// <summary>
        /// 药品调价
        /// </summary>
        private frmAdjustment()
        {
            InitializeComponent();

            m_dtpSearchBeginDate.Text = clsMedicineStoreFormFactory.CurrentDateTimeNow.ToString("yyyy年MM月dd日");
            m_dtpSearchEndDate.Text = clsMedicineStoreFormFactory.CurrentDateTimeNow.ToString("yyyy年MM月dd日");

            m_dgvMainInfo.AutoGenerateColumns = false;
            m_dgvSubInfo.AutoGenerateColumns = false;
            m_cboDoseType.SelectedIndex = 0;
            ((clsCtl_Adjustment)objController).m_mthGetAdjustPriceSetting();
            if(m_intDiffLotNO == 0)
            {
                m_dgvtxtLotNO.Visible = false;
            }
            if(this.m_intDiffLotNO == 2)
            {
                m_dgvtxtLotNO.Visible = false;
                m_dgvtxtproductorid_chr.Visible = false;
            }
        }

        /// <summary>
        /// 药品调价
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        internal frmAdjustment(string p_strStorageID) : this()
        {
            m_strStorageID = p_strStorageID;

            m_bgwGetData.RunWorkerAsync();
            ((clsCtl_Adjustment)objController).m_mthCheckHasAdminRole(LoginInfo.m_strEmpID, out m_blnIsAdmin);
            //m_blnIsAdmin = true;
            ((clsCtl_Adjustment)objController).m_mthGetIsImmAccount(out m_blnIsImmAccount);
            ((clsCtl_Adjustment)objController).m_mthGetAdjustMain();
        } 
        #endregion

        public override void CreateController()
        {
            this.objController = new clsCtl_Adjustment();
            objController.Set_GUI_Apperance(this);
        } 

        #region 事件
        private void m_cmdNewMake_Click(object sender, EventArgs e)
        {
            frmAdjustmentDetail frmAdj = new frmAdjustmentDetail(m_strStorageID, m_dtbMedicineDict);
            frmAdj.FormClosed += new FormClosedEventHandler(frmAdj_FormClosed);
            frmAdj.Show();
        }

        private void m_cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_cmdModify_Click(object sender, EventArgs e)
        {
            if (m_dgvMainInfo.CurrentCell != null && m_dgvSubInfo.Rows.Count > 0)
            {
                int intRowIndex = m_dgvMainInfo.CurrentCell.RowIndex;
                DataRow drCurrent = ((DataRowView)m_dgvMainInfo.Rows[intRowIndex].DataBoundItem).Row;
                clsMS_Adjustment_VO objMain = ((clsCtl_Adjustment)objController).m_objMain(drCurrent);

                //DataTable dtbSub = m_dgvSubInfo.DataSource as DataTable;
                clsMS_Adjustment_Detail[] objSubArr = ((clsCtl_Adjustment)objController).m_objDetail(objMain.m_lngSERIESID_INT);

                frmAdjustmentDetail frmAdj = new frmAdjustmentDetail(m_strStorageID, m_dtbMedicineDict, objMain,objSubArr);
                //frmAdj.FormClosed += new FormClosedEventHandler(frmAdj_FormClosed);
                frmAdj.Show();//.ShowDialog();
            }
        }

        private void frmAdj_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((clsCtl_Adjustment)objController).m_mthGetAdjustMain();
        }

        private void m_cmdDelete_Click(object sender, EventArgs e)
        {
            ((clsCtl_Adjustment)objController).m_mthDeleteAdjust();
        }

        private void m_cmdAuditing_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                ((clsCtl_Adjustment)objController).m_mthCommit();
            }
            catch (Exception Ex)
            {
                string strEx = Ex.Message;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void m_cmdExitAuditing_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                ((clsCtl_Adjustment)objController).m_mthUnCommit();
            }
            catch (Exception Ex)
            {
                string strEx = Ex.Message;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void m_cmdInAccount_Click(object sender, EventArgs e)
        {
            ((clsCtl_Adjustment)objController).m_mthInAccount();
        }

        private void m_cmdOutAccount_Click(object sender, EventArgs e)
        {

        }

        private void m_cmdSearch_Click(object sender, EventArgs e)
        {
            ((clsCtl_Adjustment)objController).m_mthGetAdjustMain();
        }

        private void m_txtMedicineName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (m_dtbMedicineDict == null || m_dtbMedicineDict.Rows.Count == 0)
                {
                    ((clsCtl_Adjustment)objController).m_mthGetMedicineInfo();
                }
                ((clsCtl_Adjustment)objController).m_mthShowQueryMedicineForm(m_txtMedicineName.Text);
            }
        }

        private void m_dgvMainInfo_CurrentCellChanged(object sender, EventArgs e)
        {
            ((clsCtl_Adjustment)objController).m_mthGetAdjustDetail();
            ((clsCtl_Adjustment)objController).m_mthSetSubMoneyToUI();
        }

        private void m_dgvMainInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            m_cmdModify_Click(null, null);
        }

        private void m_dgvSubInfo_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int iRow = 0; iRow < m_dgvSubInfo.Rows.Count; iRow++)
            {
                m_dgvSubInfo.Rows[iRow].Cells[0].Value = iRow + 1;
            }
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

        private void m_bgwGetData_DoWork(object sender, DoWorkEventArgs e)
        {
            //((clsCtl_Adjustment)objController).m_mthGetMedicineInfo();
        }

        private void m_cboDoseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((clsCtl_Adjustment)objController).m_mthSetDataToUI();
        }

        private void m_txtBillNumber_TextChanged(object sender, EventArgs e)
        {
            ((clsCtl_Adjustment)objController).m_mthSetDataToUI();
        }

        private void m_dgvSubInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            m_cmdModify_Click(null, null);
        }
        #endregion

        private void frmAdjustment_Load(object sender, EventArgs e)
        {  
            int m_intCommitFolow = 0;
            ((clsCtl_Adjustment)objController).m_mthGetCommitFlow(out m_intCommitFolow);
            if (m_intCommitFolow == 1)
                m_cmdAuditing.Enabled = false;
        }

        private void m_lblMainMoney_Click(object sender, EventArgs e)
        {

        }

        private void m_txtMedicineName_TextChanged(object sender, EventArgs e)
        {
            if (m_txtMedicineName.Text.Length == 0)
                m_txtMedicineName.Tag = null;
        }
    }
}