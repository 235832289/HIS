using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 获取盘点药品
    /// </summary>
    public partial class frmGetStorageCheckMedicine : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 属性
        /// <summary>
        /// 库存药品信息
        /// </summary>
        private DataTable m_dtbStorageMedicine = null;
        /// <summary>
        /// 获取库存药品信息
        /// </summary>
        internal DataTable m_DtbStorageMedicine
        {
            get
            {
                return m_dtbStorageMedicine;
            }
        }
        /// <summary>
        /// 查询条件
        /// </summary>
        private string m_strSearchCondition = string.Empty;
        /// <summary>
        /// 获取查询条件
        /// </summary>
        internal string m_StrSearchCondition
        {
            get
            {
                return m_strSearchCondition;
            }
        }
        /// <summary>
        /// 仓库ID
        /// </summary>
        internal string m_strStorageID = string.Empty;
        /// <summary>
        /// 是否只是获取查询条件，不直接获取数据
        /// </summary>
        internal bool m_blnIsOnlyGetCondition = false;
        #endregion

        /// <summary>
        /// 获取盘点药品
        /// </summary>
        private frmGetStorageCheckMedicine()
        {
            InitializeComponent();
            m_mthSetControlHighLight();
        }

        /// <summary>
        /// 获取盘点药品
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        public frmGetStorageCheckMedicine(string p_strStorageID)
            : this()
        {
            m_strStorageID = p_strStorageID;
        }

        /// <summary>
        /// 获取盘点药品
        /// </summary>
        /// <param name="p_blnIsOnlyGetCondition">是否只是获取查询条件，不直接获取数据</param>
        public frmGetStorageCheckMedicine(bool p_blnIsOnlyGetCondition)
            : this()
        {
            m_blnIsOnlyGetCondition = p_blnIsOnlyGetCondition;
        }

        public override void CreateController()
        {
            this.objController = new clsCtl_GetStorageCheckMedicine();
            objController.Set_GUI_Apperance(this);
        }
        
        /// <summary>
        /// 设置活动控件背景高亮
        /// </summary>
        private void m_mthSetControlHighLight()
        {
            clsCtl_Public objCtl = new clsCtl_Public();
            objCtl.m_mthSetControlHighLight(this, Color.Moccasin);
            objCtl.m_mthSelectAllText(this);
        }

        #region 事件
        private void m_rdbCheckSortNum_CheckedChanged(object sender, EventArgs e)
        {
            if (m_rdbCheckSortNum.Checked)
            {
                m_txtCheckSortNum1.Enabled = true;
                m_txtCheckSortNum2.Enabled = true;
                m_txtCheckSortNum1.Focus();
            }
            else
            {
                m_txtCheckSortNum1.Enabled = false;
                m_txtCheckSortNum2.Enabled = false;
                m_txtCheckSortNum1.Text = string.Empty;
                m_txtCheckSortNum2.Text = string.Empty;
            }
        }

        private void m_rdbMedicineCode_CheckedChanged(object sender, EventArgs e)
        {
            if (m_rdbMedicineCode.Checked)
            {
                m_txtMedicineCode1.Enabled = true;
                m_txtMedicineCode2.Enabled = true;
                m_txtMedicineCode1.Focus();
            }
            else
            {
                m_txtMedicineCode1.Enabled = false;
                m_txtMedicineCode2.Enabled = false;
                m_txtMedicineCode1.Text = string.Empty;
                m_txtMedicineCode2.Text = string.Empty;
            }
        }

        private void m_rdbMedicineType_CheckedChanged(object sender, EventArgs e)
        {
            if (m_rdbMedicinePreptype.Checked)
            {
                m_cboMediciePreptype.Enabled = true;
                m_cboMediciePreptype.Focus();
            }
            else
            {
                m_cboMediciePreptype.Enabled = false;
            }
        }

        private void m_rdbRackNum_CheckedChanged(object sender, EventArgs e)
        {
            if (m_rdbRackNum.Checked)
            {
                m_txtRackNum1.Enabled = true;
                m_txtRackNum2.Enabled = true;
                m_txtRackNum1.Focus();
            }
            else
            {
                m_txtRackNum1.Enabled = false;
                m_txtRackNum2.Enabled = false;
                m_txtRackNum1.Text = string.Empty;
                m_txtRackNum2.Text = string.Empty;
            }
        }

        private void m_cmdOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_blnIsOnlyGetCondition)
                {
                    long lngRes = ((clsCtl_GetStorageCheckMedicine)objController).m_lngGetSearchCondition(out m_strSearchCondition);
                    if (lngRes < 0)
                    {
                        return;
                    }
                }
                else
                {
                    long lngRes = ((clsCtl_GetStorageCheckMedicine)objController).m_dtbGetMedicine(out m_dtbStorageMedicine);
                    if (lngRes < 0)
                    {
                        return;
                    }
                }                
            }
            catch (Exception)
            {
                
                throw;
            }
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void m_cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmGetStorageCheckMedicine_Load(object sender, EventArgs e)
        {
            ((clsCtl_GetStorageCheckMedicine)objController).m_mthGetMedicinePreptype();
        }

        private void m_txtCheckSortNum1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_txtCheckSortNum2.Focus();
            }
        }

        private void m_txtCheckSortNum2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_cmdOK.Focus();
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
                m_cmdOK.Focus();
            }
        }

        private void m_txtRackNum1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_txtRackNum2.Focus();
            }
        }

        private void m_txtRackNum2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_cmdOK.Focus();
            }
        }
        #endregion
    }
}