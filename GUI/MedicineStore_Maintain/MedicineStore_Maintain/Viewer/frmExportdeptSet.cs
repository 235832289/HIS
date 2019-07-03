using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    public partial class frmExportdeptSet : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 修改库房标志的记录
        /// </summary>
        internal Dictionary<string, string> m_dicStorageFlag = new Dictionary<string, string>();

        public frmExportdeptSet()
        {
            InitializeComponent();

            m_dgvExportdeptAll.AutoGenerateColumns = false;

            ((clsCtl_ExportdeptSet)objController).m_mthBindStorage();
        }

        #region 设置窗体控制器.
        /// <summary>
        /// 重载方法,设置窗体控制器.
        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsCtl_ExportdeptSet();
            objController.Set_GUI_Apperance(this);
        }
        #endregion

        private void frmExportdeptSet_Load(object sender, EventArgs e)
        {
            ((clsCtl_ExportdeptSet)objController).m_mthGetExportDept();
        }

        private void m_cmdClose_Click(object sender, EventArgs e)
        {

        }

        private void m_cmdAdd_Click(object sender, EventArgs e)
        {
            ((clsCtl_ExportdeptSet)objController).m_mthAddExportDept();

         
        }

        private void m_cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_cmdSave_Click(object sender, EventArgs e)
        {
            long lngRes = 0;
            lngRes = ((clsCtl_ExportdeptSet)objController).m_mthSaverExportDept();
            if (lngRes > 0)
            {
                MessageBox.Show("保存成功", "领用部门列表设置", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("保存失败", "领用部门列表设置", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void m_dgvExportdeptAll_DoubleClick(object sender, EventArgs e)
        {
            ((clsCtl_ExportdeptSet)objController).m_mthAddExportDept();
        }

        private void m_cmdDel_Click(object sender, EventArgs e)
        {
            ((clsCtl_ExportdeptSet)objController).m_mthDelExportDept();
             
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ((clsCtl_ExportdeptSet)objController).m_mthGetExportDept();
        }

        private void m_cmdUp_Click(object sender, EventArgs e)
        {
            ((clsCtl_ExportdeptSet)objController).m_mthUp();
        }

        private void m_cmdDown_Click(object sender, EventArgs e)
        {
            ((clsCtl_ExportdeptSet)objController).m_mthDown();
            
        }

        private void m_cmdUpToFirst_Click(object sender, EventArgs e)
        {
            ((clsCtl_ExportdeptSet)objController).m_mthTop();
        }

        private void m_cmdDownToLast_Click(object sender, EventArgs e)
        {
            ((clsCtl_ExportdeptSet)objController).m_mthBott();
        }

        private void m_dgvExportdept_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                m_dgvExportdept.RowHeadersWidth - 4,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                m_dgvExportdept.RowHeadersDefaultCellStyle.Font,
                rectangle,
                m_dgvExportdept.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void m_txtQuery_TextChanged(object sender, EventArgs e)
        {
            DataGridViewCell dgvcSelect = ((clsCtl_ExportdeptSet)objController).m_dgvcSelect(m_dgvExportdeptAll, m_txtQuery.Text);
            if (dgvcSelect != null)
            {
                m_dgvExportdeptAll.CurrentCell = m_dgvExportdeptAll.Rows[dgvcSelect.RowIndex].Cells[1];
                m_dgvExportdeptAll.Rows[dgvcSelect.RowIndex].Selected = true;
            }
            else
            {
                m_dgvExportdeptAll.Rows[m_dgvExportdeptAll.CurrentCell.RowIndex].Selected = false;
            }
        }

        private void m_dgvExportdept_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            return;
        }

        private void m_dgvExportdept_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                SendKeys.Send("{F4}");
            }
        }

        //private void m_dgvExportdept_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Control.Name == "cboFlag")
        //        {
        //            ComboBox cb = (ComboBox)e.Control;
        //            cb.DroppedDown = true;
        //        }
        //    }
        //    catch
        //    {
        //        return;
        //    }
        //}
    }
}