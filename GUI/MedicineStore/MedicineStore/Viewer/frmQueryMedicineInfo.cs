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
    /// 确定返回主界面前，且当前界面有有效信息时触发事件
    /// </summary>
    /// <param name="p_objOutMedicinArr">出库药品信息</param>
    /// <returns></returns>
    public delegate long BeforeCommitQureyMedicineInfo(clsMS_StorageMedicineShow[] p_objOutMedicinArr);

    /// <summary>
    /// 药品出库药品信息浏览
    /// </summary>
    public partial class frmQueryMedicineInfo : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 药品出库数量
        /// </summary>
        internal double m_dblAmount = 0d;
        /// <summary>
        /// 全部选定药品数量
        /// </summary>
        internal double m_dblAllAmount = 0d;
        /// <summary>
        /// 药品信息
        /// </summary>
        internal DataTable m_dtbMedicineInfo = null;
        /// <summary>
        ///  确定返回主界面前，且当前界面有有效信息时触发事件
        /// </summary>
        public event BeforeCommitQureyMedicineInfo BeforeCommit;
        /// <summary>
        /// 出库类型ID
        /// </summary>
        internal string m_strTYPECODE_CHR = string.Empty;

        /// <summary>
        /// 药品出库药品信息浏览
        /// </summary>
        private frmQueryMedicineInfo()
        {
            InitializeComponent();

            m_dgvQueryMedicineInfo.AutoGenerateColumns = false;
        }

        /// <summary>
        /// 药品出库药品信息浏览
        /// </summary>
        /// <param name="p_dblAmount">药品出库数量</param>
        public frmQueryMedicineInfo(double p_dblAmount) 
            : this()
        {
            m_dblAmount = p_dblAmount;

            ((clsCtl_QueryMedicineInfo)objController).m_mthInitDataSouce(ref m_dtbMedicineInfo);
            m_dgvQueryMedicineInfo.DataSource = m_dtbMedicineInfo;
        }

        private void m_cmdOK_Click(object sender, EventArgs e)
        {
            int intStatus = 1;
            m_objOutMedicinArr = ((clsCtl_QueryMedicineInfo)objController).m_objGetVOFromTable(out intStatus);
            if (intStatus == 0)
            {
                return;
            }

            long lngRes = 1;
            if (m_objOutMedicinArr != null && m_objOutMedicinArr.Length > 0 && BeforeCommit != null)
            {
                lngRes = BeforeCommit(m_objOutMedicinArr);
            }

            if (lngRes > 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close(); 
            }            
        }

        private void m_cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// 出库药品信息
        /// </summary>
        private clsMS_StorageMedicineShow[] m_objOutMedicinArr = null;
        /// <summary>
        /// 获取出库药品信息
        /// </summary>
        public clsMS_StorageMedicineShow[] m_ObjOutMedicinArr
        {
            get
            {
                return m_objOutMedicinArr;
            }
        }

        /// <summary>
        /// 设置药品浏览信息
        /// </summary>
        /// <param name="p_objSTDetail"></param>
        public void m_mthSetMedicineVO(clsMS_StorageDetail[] p_objSTDetail,System.Collections.Hashtable hstNoChange)
        {
            if (p_objSTDetail == null)
            {
                return;
            }
            ((clsCtl_QueryMedicineInfo)objController).m_mthSetDataToUI(p_objSTDetail, hstNoChange);
        }

        /// <summary>
        /// 设置药品浏览信息
        /// </summary>
        /// <param name="p_objSTDetail"></param>
        public void m_mthSetMedicineVO(clsMS_StorageDetail[] p_objSTDetail)
        {
            if (p_objSTDetail == null)
            {
                return;
            }
            ((clsCtl_QueryMedicineInfo)objController).m_mthSetDataToUI(p_objSTDetail);
        }

        public override void CreateController()
        {
            this.objController = new clsCtl_QueryMedicineInfo();
            objController.Set_GUI_Apperance(this);
        }

        private void frmQueryMedicineInfo_Load(object sender, EventArgs e)
        {
            if (m_dgvQueryMedicineInfo.Rows.Count > 0)
            {
                m_dgvQueryMedicineInfo.Focus();
                m_dgvQueryMedicineInfo.CurrentCell = m_dgvQueryMedicineInfo.Rows[0].Cells[9];
                m_dgvQueryMedicineInfo.CurrentCell.Selected = true;
            }
            m_ckbShowZero.Checked = false;
        }

        private void m_dgvQueryMedicineInfo_EnterKeyPress(DataGridViewCell CurrentCell, out bool CancelJump)
        {
            CancelJump = true;
            if (CurrentCell != null && CurrentCell.ColumnIndex == 9)
            {
                //if (CurrentCell.RowIndex < m_dgvQueryMedicineInfo.Rows.Count - 1)
                //{
                //    m_dgvQueryMedicineInfo.CurrentCell = m_dgvQueryMedicineInfo.Rows[CurrentCell.RowIndex + 1].Cells[6];
                //    m_dgvQueryMedicineInfo.CurrentCell.Selected = true;
                //}
                m_cmdOK.Focus();
            }
        }

        /// <summary>
        /// 设置数量名称，默认"出库数量"
        /// </summary>
        /// <param name="p_strAmountName">数量名称</param>
        internal void m_mthSetAmountName(string p_strAmountName)
        {
            m_dgvtxtOutNumber.HeaderText = p_strAmountName;
        }

        /// <summary>
        /// 显示入库数量
        /// </summary>
        internal void m_mthShowInStorageAmount()
        {
            m_dgvtxtInStorageAmount.Visible = true;
            this.Size = new Size(this.Size.Width + 91, this.Size.Height);
        }

        private void m_ckbShowZero_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (m_dtbMedicineInfo.Rows.Count == 0) return;
                if (m_ckbShowZero.Checked)
                {
                    foreach (DataGridViewRow dgvRow in m_dgvQueryMedicineInfo.Rows)
                    {
                        dgvRow.Visible = true;
                    }
                }
                else
                {
                    foreach (DataGridViewRow dgvRow in m_dgvQueryMedicineInfo.Rows)
                    {
                        if (Convert.ToDouble(dgvRow.Cells["m_dgvtxtRealStorage"].Value) != 0)
                        {
                            m_dgvQueryMedicineInfo.CurrentCell = dgvRow.Cells["m_dgvtxtOutNumber"];
                            m_dgvQueryMedicineInfo.CurrentCell.Selected = true;
                            break;
                        }
                    }
                    foreach (DataGridViewRow dgvRow in m_dgvQueryMedicineInfo.Rows)
                    {
                        if (Convert.ToDouble(dgvRow.Cells["m_dgvtxtRealStorage"].Value) == 0)
                        {
                            dgvRow.Cells["m_dgvtxtOutNumber"].Value = 0;
                            dgvRow.Visible = false;
                        }
                    }
                }
            }
            catch
            {
            }
        }
    }
}