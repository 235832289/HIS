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
    public partial class frmMedicineTypeVisionmSet : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 类型信息
        /// </summary>
        public DataTable dtbTypeVisionm;

        public frmMedicineTypeVisionmSet()
        {
            InitializeComponent();
        }

        #region 设置窗体控制器.
        /// <summary>
        /// 重载方法,设置窗体控制器.
        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsCtl_MedicineTypeVisionmSet();
            objController.Set_GUI_Apperance(this);
        }
        #endregion

        private void m_cmdCan_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMedicineTypeVisionmSet_Load(object sender, EventArgs e)
        {
           
            ((clsCtl_MedicineTypeVisionmSet)objController).m_mthGetAllMedicineTypeVisionm();
        }

        private void m_cmdSaver_Click(object sender, EventArgs e)
        {

            ((clsCtl_MedicineTypeVisionmSet)objController).m_mthSaverMedicineType();
        }

        private void m_lblSelectAll_Click(object sender, EventArgs e)
        {
            if (m_dgvTypeVisionm.Rows.Count > 0)
            {
                if (m_lblSelectAll.Text == "全选")
                {
                    m_lblSelectAll.Text = "反选";
                    for (int iRow = 0; iRow < m_dgvTypeVisionm.Rows.Count; iRow++)
                    {
                        dtbTypeVisionm.Rows[iRow]["lotno_int"] = 1;

                    }
                }
                else if (m_lblSelectAll.Text == "反选")
                {
                    m_lblSelectAll.Text = "全选";
                    for (int iRow = 0; iRow < m_dgvTypeVisionm.Rows.Count; iRow++)
                    {
                        dtbTypeVisionm.Rows[iRow]["lotno_int"] = 0;
                    }
                }
            }
            m_dgvTypeVisionm.Refresh();
        }

        private void m_lblSelectAll2_Click(object sender, EventArgs e)
        {
            if (m_dgvTypeVisionm.Rows.Count > 0)
            {
                if (m_lblSelectAll2.Text == "全选")
                {
                    m_lblSelectAll2.Text = "反选";
                    for (int iRow = 0; iRow < m_dgvTypeVisionm.Rows.Count; iRow++)
                    {
                        dtbTypeVisionm.Rows[iRow]["validperiod_int"] = 1;

                    }
                }
                else if (m_lblSelectAll2.Text == "反选")
                {
                    m_lblSelectAll2.Text = "全选";
                    for (int iRow = 0; iRow < m_dgvTypeVisionm.Rows.Count; iRow++)
                    {
                        dtbTypeVisionm.Rows[iRow]["validperiod_int"] = 0;
                    }
                }
            }
            m_dgvTypeVisionm.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((clsCtl_MedicineTypeVisionmSet)objController).m_mthGetAllMedicineTypeVisionm();
        }
    }
}