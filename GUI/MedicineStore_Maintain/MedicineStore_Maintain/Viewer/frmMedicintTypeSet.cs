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
    /// 药品类型设置
    /// </summary>
    public partial class frmMedicintTypeSet : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 药品类型设置
        /// </summary>
        public frmMedicintTypeSet()
        {
            InitializeComponent();
        }

        #region 设置窗体控制器.
        /// <summary>
        /// 重载方法,设置窗体控制器.
        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsCtl_MedicineTypeSet();
            objController.Set_GUI_Apperance(this);
        }
        #endregion

        private void frmMedicintTypeSet_Load(object sender, EventArgs e)
        {
            ((clsCtl_MedicineTypeSet)objController).m_mthGetMedicineType();
            ((clsCtl_MedicineTypeSet)objController).m_mthGetAllMedicineTypeSetInfo();
        }

        private void m_cmdAdd_Click(object sender, EventArgs e)
        {
            ((clsCtl_MedicineTypeSet)objController).m_mthClear();
        }

        private void m_cmdDelete_Click(object sender, EventArgs e)
        {
            ((clsCtl_MedicineTypeSet)objController).m_mthDeleteTypeSet();
        }

        private void m_cmdSave_Click(object sender, EventArgs e)
        {
            if (m_txtMedicineStoreRoom.Tag == null)
            {
                ((clsCtl_MedicineTypeSet)objController).m_mthAddNewTypeSet();
            }
            else
            {
                ((clsCtl_MedicineTypeSet)objController).m_mthModifyTypeSet();
            }
        }

        private void m_cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_lsvMedicineTypeSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((clsCtl_MedicineTypeSet)objController).m_mthGetMedicineTypeSetInfo();
        }
    }
}