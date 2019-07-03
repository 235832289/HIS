using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmOPSelectChargeItem : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 选择过滤后的数据
        /// </summary>
        public DataTable m_dtbSelectTable = null;
        /// <summary>
        /// 诊疗项目id
        /// </summary>
        public List<string> m_lstOrderDicItemID = null;
        public frmOPSelectChargeItem()
        {
            InitializeComponent();
        }

        public frmOPSelectChargeItem(DataTable p_dtbChargeItemn, string p_strRecipeNo)
        {
            InitializeComponent();
            ((clsCtl_OPSelectChargeItem)this.objController).m_mthShow(p_dtbChargeItemn, p_strRecipeNo);
        }

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_OPSelectChargeItem();
            this.objController.Set_GUI_Apperance(this);
        }

        private void m_cmdConfirm_Click(object sender, EventArgs e)
        {
            m_dtbSelectTable = ((clsCtl_OPSelectChargeItem)this.objController).m_dtbSelectTable();
            if (m_dtbSelectTable == null || m_dtbSelectTable.Rows.Count == 0)
            {
                MessageBox.Show("请选择须要缴费的项目！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void m_cmdCancel_Click(object sender, EventArgs e)
        {
            if (m_dtbSelectTable != null)
            {
                m_dtbSelectTable.Dispose();
                m_dtbSelectTable = null;
            }
            this.Close();
        }

        private void dtgItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int intIndexRow = e.RowIndex;

            if (e.ColumnIndex != dtgItem.Columns["colChecked"].Index)
            {
                return;
            }

            if (intIndexRow < 0 || intIndexRow > dtgItem.Rows.Count - 1)
            {
                return;
            }

            ((clsCtl_OPSelectChargeItem)this.objController).m_mthSelectMergeItem(intIndexRow);
        }

        private void dtgItem_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dtgItem_CellContentClick(sender, e);
        }
    }
}