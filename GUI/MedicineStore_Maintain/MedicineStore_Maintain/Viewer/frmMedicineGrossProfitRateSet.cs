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
    /// <summary>
    /// 药品毛利率设置
    /// </summary>
    public partial class frmMedicineGrossProfitRateSet : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 数据源
        /// </summary>
        internal DataTable m_dtbDataSource = null;

        #region 构造函数
        /// <summary>
        /// 药品毛利率设置
        /// </summary>
        public frmMedicineGrossProfitRateSet()
        {
            InitializeComponent();
            ((clsCtl_MedicineGrossProfitRateSet)objController).m_mthInitDataTable(ref m_dtbDataSource);
            m_dgvRateSet.DataSource = m_dtbDataSource;
            m_bgwGetData.RunWorkerAsync();
        } 
        #endregion

        #region 事件
        private void m_cmdSave_Click(object sender, EventArgs e)
        {
            if (((clsCtl_MedicineGrossProfitRateSet)objController).m_blnCheckRate())
            {
                ((clsCtl_MedicineGrossProfitRateSet)objController).m_mthSaveGrossProfitRateSet();
            }
        }

        private void m_cmdReset_Click(object sender, EventArgs e)
        {
            ((clsCtl_MedicineGrossProfitRateSet)objController).m_mthResetGrossProfitRate();
        }

        private void m_cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public override void CreateController()
        {
            this.objController = new clsCtl_MedicineGrossProfitRateSet();
            objController.Set_GUI_Apperance(this);
        }

        private void m_bgwGetData_DoWork(object sender, DoWorkEventArgs e)
        {
            clsMS_GrossProfitRateSet_VO[] objVOArr = null;
            ((clsCtl_MedicineGrossProfitRateSet)objController).m_mthGetGrossProfitRateSet(out objVOArr);
            e.Result = objVOArr;
        }

        private void m_bgwGetData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            clsMS_GrossProfitRateSet_VO[] objVOArr = e.Result as clsMS_GrossProfitRateSet_VO[];
            if (objVOArr != null)
            {
                ((clsCtl_MedicineGrossProfitRateSet)objController).m_mthSetGrossProfitRateDataToUI(objVOArr);
            }

            if (m_dgvRateSet.Rows.Count > 0)
            {
                m_dgvRateSet.Focus();
                m_dgvRateSet.CurrentCell = m_dgvRateSet.Rows[0].Cells[2];
                m_dgvRateSet.CurrentCell.Selected = true;
            }
        }

        private void frmMedicineGrossProfitRateSet_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (((clsCtl_MedicineGrossProfitRateSet)objController).m_intCheckHasUnSaveData() <= 0)
            {
                e.Cancel = true;
                return;
            }
        }  
        #endregion
    }
}