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
    /// 调入库单
    /// </summary>
    public partial class frmCallInStorageInfo : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 更改退药出库调入库单的供应商
        /// </summary>
        /// <param name="p_stsrVendorID"></param>
        /// <param name="p_strVendorName"></param>
        public delegate void CallInStorageInfoVendorChange(string p_stsrVendorID, string p_strVendorName);

        #region 全局变量
        /// <summary>
        /// 入库信息
        /// </summary>
        internal DataTable m_dtbInStorageInfo = null;
        /// <summary>
        /// 仓库ID
        /// </summary>
        internal string m_strStorageID = string.Empty;
        /// <summary>
        /// 药品基本字典
        /// </summary>
        internal DataTable m_dtbMedicinDict = null;
        /// <summary>
        /// 返回退药出库的记录
        /// </summary>
        private clsMS_OutStorageDetail_VO[] m_objDetailArr = null;
        /// <summary>
        /// 获取退药出库记录
        /// </summary>
        internal clsMS_OutStorageDetail_VO[] GetDetailArr
        {
            get
            {
                return m_objDetailArr;
            }
        }
        #endregion

        /// <summary>
        /// 更改退药出库调入库单的供应商
        /// </summary>
        public event CallInStorageInfoVendorChange VendorChange;

        #region 构造函数
        /// <summary>
        /// 调入库单
        /// </summary>
        private frmCallInStorageInfo()
        {
            InitializeComponent();

            m_dgvInStorage.AutoGenerateColumns = false;
        }

        /// <summary>
        /// 调入库单
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strVendorID">供应商ID</param>
        /// <param name="p_strVendorName">供应商名称</param>
        /// <param name="p_blnCanChangeVendor">是否能对供应商作修改</param>
        /// <param name="p_dtbMedicinDict">药品基本字典</param>
        public frmCallInStorageInfo(string p_strStorageID,string p_strVendorID,string p_strVendorName,bool p_blnCanChangeVendor, DataTable p_dtbMedicinDict)
            : this()
        {
            m_strStorageID = p_strStorageID;
            m_dtbMedicinDict = p_dtbMedicinDict;

            if (!p_blnCanChangeVendor)
            {
                m_txtVendor.Enabled = false;
            }

            if (!string.IsNullOrEmpty(p_strVendorID))
            {
                m_txtVendor.Tag = p_strVendorID;
                m_txtVendor.Text = p_strVendorName;
            }
        } 
        #endregion

        #region 方法
        public override void CreateController()
        {
            this.objController = new clsCtl_CallInStorageInfo();
            objController.Set_GUI_Apperance(this);
        } 
        #endregion

        private void m_rdbMedicineCode_CheckedChanged(object sender, EventArgs e)
        {
            if (m_rdbMedicineCode.Checked)
            {
                m_txtMedicineCode.Enabled = true;
            }
            else
            {
                m_txtMedicineCode.Clear();
                m_txtMedicineCode.Enabled = false;
            }
        }

        private void m_rdbInStorageID_CheckedChanged(object sender, EventArgs e)
        {
            if (m_rdbInStorageID.Checked)
            {
                m_txtInStorageID.Enabled = true;
            }
            else
            {
                m_txtInStorageID.Clear();
                m_txtInStorageID.Enabled = false;
            }
        }

        private void m_cmdSearch_Click(object sender, EventArgs e)
        {
            ((clsCtl_CallInStorageInfo)objController).m_mthSearchInStorageInfo();
        }

        private void m_dgvInStorage_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int iRow = 0; iRow < m_dgvInStorage.Rows.Count; iRow++)
            {
                m_dgvInStorage.Rows[iRow].Cells[1].Value = iRow + 1;
            }
        }

        private void m_lblAllCheck_Click(object sender, EventArgs e)
        {
            if (m_dgvInStorage.Rows.Count > 0)
            {
                if (m_lblAllCheck.Text == "全选")
                {
                    m_lblAllCheck.Text = "反选";
                    for (int iRow = 0; iRow < m_dgvInStorage.Rows.Count; iRow++)
                    {
                        m_dgvInStorage.Rows[iRow].Cells[0].Value = true;
                    }
                }
                else if (m_lblAllCheck.Text == "反选")
                {
                    m_lblAllCheck.Text = "全选";
                    for (int iRow = 0; iRow < m_dgvInStorage.Rows.Count; iRow++)
                    {
                        m_dgvInStorage.Rows[iRow].Cells[0].Value = false;
                    }
                }
            }
        }

        private void m_txtMedicineCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_CallInStorageInfo)objController).m_mthShowQueryMedicineForm(m_txtMedicineCode.Text);
            }
        }

        private void m_cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void m_cmdOK_Click(object sender, EventArgs e)
        {
            long lngRes = ((clsCtl_CallInStorageInfo)objController).m_mthGetSelectedDetailVO(out m_objDetailArr);
            if (lngRes < 0)
            {
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void m_txtInStorageID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_cmdSearch.Focus();
            }
        }

        private void m_txtVendor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_CallInStorageInfo)objController).m_mthShowVendor(m_txtVendor.Text);                
            }
        }

        /// <summary>
        /// 触发供应商更改事件
        /// </summary>
        internal void m_mthInvokeVendorChange()
        {
            if (VendorChange != null && m_txtVendor.Tag != null)
            {
                VendorChange(m_txtVendor.Tag.ToString(), m_txtVendor.Text);
            }
        }
    }
}