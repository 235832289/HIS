using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    /// <summary>
    /// 检查漏盘药品
    /// </summary>
    public partial class frmGetMissStorageCheckMedicine : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 全局变量
        /// <summary>
        /// 已盘点药品
        /// </summary>
        internal DataTable m_dtbHasCheckMedicine = null;
        /// <summary>
        /// 仓库ID
        /// </summary>
        internal string m_strStorageID = string.Empty;
        /// <summary>
        /// 漏盘药品
        /// </summary>
        internal DataTable m_dtbMissMedicine = null;
        /// <summary>
        /// 已选择数据
        /// </summary>
        private DataRow[] m_drGetSelected = null;
        /// <summary>
        /// 获取已选择数据
        /// </summary>
        public DataRow[] m_DrGetSelected
        {
            get
            {
                return m_drGetSelected;
            }
        }
        #endregion

        /// <summary>
        /// 检查漏盘药品
        /// </summary>
        /// <param name="p_dtbHasCheckMedicine">已盘点药品</param>
        /// <param name="p_strStorageID">仓库ID</param>
        public frmGetMissStorageCheckMedicine(DataTable p_dtbHasCheckMedicine, string p_strStorageID)
        {
            InitializeComponent();

            m_dtbHasCheckMedicine = p_dtbHasCheckMedicine;
            m_strStorageID = p_strStorageID;

            m_dgvStorageDetail.AutoGenerateColumns = false;
            ((clsCtl_GetMissStorageCheckMedicine)objController).m_mthInitDataSource();
            m_dgvStorageDetail.DataSource = m_dtbMissMedicine;
        }

        public override void CreateController()
        {
            this.objController = new clsCtl_GetMissStorageCheckMedicine();
            objController.Set_GUI_Apperance(this);
        }

        #region 事件
        private void m_cmdCheck_Click(object sender, EventArgs e)
        {
            ((clsCtl_GetMissStorageCheckMedicine)objController).m_mthCheckMedicine();
        }

        private void m_rdbMedicineCode_CheckedChanged(object sender, EventArgs e)
        {
            if (m_rdbMedicineCode.Checked)
            {
                m_txtMedicineCode1.Enabled = true;
                m_txtMedicineCode2.Enabled = true;
            }
            else
            {
                m_txtMedicineCode1.Text = string.Empty;
                m_txtMedicineCode2.Text = string.Empty;
                m_txtMedicineCode1.Enabled = false;
                m_txtMedicineCode2.Enabled = false;
            }
        }

        private void m_rdbMedicinePreptype_CheckedChanged(object sender, EventArgs e)
        {
            if (m_rdbMedicinePreptype.Checked)
            {
                m_cboMediciePreptype.Enabled = true;
            }
            else
            {
                m_cboMediciePreptype.Enabled = false;
            }
        }

        private void m_rdbMedicineType_CheckedChanged(object sender, EventArgs e)
        {
            if (m_rdbMedicineType.Checked)
            {
                m_cboMedicineType.Enabled = true;
            }
            else
            {
                m_cboMedicineType.Enabled = false;
            }
        }

        private void m_cmdOK_Click(object sender, EventArgs e)
        {
            m_drGetSelected = ((clsCtl_GetMissStorageCheckMedicine)objController).m_drGetSelectedRows();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void m_cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmGetMissStorageCheckMedicine_Load(object sender, EventArgs e)
        {
            ((clsCtl_GetMissStorageCheckMedicine)objController).m_mthGetMedicinePreptype();
            ((clsCtl_GetMissStorageCheckMedicine)objController).m_mthGetMedicineType();
        }

        private void m_lblSelectAll_Click(object sender, EventArgs e)
        {
            if (m_dgvStorageDetail.Rows.Count > 0)
            {
                if (m_lblSelectAll.Text == "全选")
                {
                    m_lblSelectAll.Text = "反选";
                    for (int iRow = 0; iRow < m_dgvStorageDetail.Rows.Count; iRow++)
                    {
                        m_dgvStorageDetail.Rows[iRow].Cells[0].Value = true;
                    }
                }
                else if (m_lblSelectAll.Text == "反选")
                {
                    m_lblSelectAll.Text = "全选";
                    for (int iRow = 0; iRow < m_dgvStorageDetail.Rows.Count; iRow++)
                    {
                        m_dgvStorageDetail.Rows[iRow].Cells[0].Value = false;
                    }
                }
            }
        }

        private void m_txtMedicineCode1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_txtMedicineCode2.Focus();
            }
        }

        private void m_txtMedicineCode2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_cmdCheck.Focus();
            }
        } 
        #endregion
    }
}