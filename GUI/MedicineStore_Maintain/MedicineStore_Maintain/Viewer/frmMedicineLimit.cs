using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    public partial class frmMedicineLimit : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 仓库ID
        /// </summary>
        public string m_strStorageID;
        /// <summary>
        /// 药品字典
        /// </summary>
        internal DataTable m_dtbMedicinDict = null;

        #region 设置窗体控制器.
        /// <summary>
        /// 重载方法,设置窗体控制器.
        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsCtl_MedicineLimit();
            objController.Set_GUI_Apperance(this);
        }
        #endregion
        public frmMedicineLimit()
        {
            InitializeComponent();
        }

        /// 显示窗体
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        public void ShowThis(string p_strStorageID)
        {
            m_strStorageID = p_strStorageID;
            this.Show();
        }
        private void frmMedicineLimit_Load(object sender, EventArgs e)
        {
            ((clsCtl_MedicineLimit)objController).m_mthGetAllMedicine();
            ((clsCtl_MedicineLimit)objController).m_mthGetMedicineInfo();
            
        }

        private void m_txtFindBox_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    ((clsCtl_MedicineLimit)objController).m_mthFindMedicine();
            //}
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_MedicineLimit)objController).m_mthShowQueryMedicineForm(m_txtFindBox.Text);
            }
        }

        private void m_cmdExit_Click(object sender, EventArgs e)
        {
            ((clsCtl_MedicineLimit)objController).m_mthExit();
            //this.Close();
        }

        private void m_cmdAddNew_Click(object sender, EventArgs e)
        {
            ((clsCtl_MedicineLimit)objController).m_mthSaverMedicine();
        }

        private void m_cmdPrint_Click(object sender, EventArgs e)
        {
            ((clsCtl_MedicineLimit)objController).m_mthPrint();
        }

        private void m_dgvDetailInfo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("抱歉！些处只能输入数字，请更正。", "药品限量设置", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //if ((e.Exception) is ConstraintException)
            //{
            //    DataGridView view = (DataGridView)sender;
            //    view.Rows[e.RowIndex].ErrorText = "an error";
            //    view.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "an error";

            //    e.ThrowException = false;
            //}

        }

        private void m_dgvDetailInfo_MouseUp(object sender, MouseEventArgs e)
        {
            m_dgvDetailInfo.BeginEdit(true);
        }

        private void m_txtFindBox_MouseDown(object sender, MouseEventArgs e)
        {
            m_txtFindBox.SelectAll();
        }

        private void m_dgvDetailInfo_EnterKeyPress(DataGridViewCell CurrentCell, out bool CancelJump)
        {
            int intCellIndex = m_dgvDetailInfo.CurrentCell.ColumnIndex;
            int intRowIndex = m_dgvDetailInfo.CurrentCell.RowIndex;
            if (intCellIndex == 6)
            {
                //MessageBox.Show(m_dgvDetailInfo.Rows[2].Cells[2].Visible.ToString());
               
                //if (Convert.ToDouble(m_dgvDetailInfo.Rows[intRowIndex].Cells[6].Visible) < Convert.ToDouble(m_dgvDetailInfo.Rows[intRowIndex].Cells[5].ToString()))
                //{
                //    MessageBox.Show("注意,最高限量不能小于最低限量。", "药品限量设置", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    CancelJump = true;
                //    return;
                //}

                m_dgvDetailInfo.CurrentCell = m_dgvDetailInfo.Rows[intRowIndex + 1].Cells[5];
                CancelJump = true;
                return;

            }
            if (intCellIndex == 5)
            {
                m_dgvDetailInfo.CurrentCell = m_dgvDetailInfo.Rows[intRowIndex].Cells[6];
                CancelJump = true;
                return;
            }
            CancelJump = true;
        }
    }



    
}