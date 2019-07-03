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
    /// 报废原因设置
    /// </summary>
    public partial class frmRejectReasonSet : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 报废原因设置
        /// </summary>
        public frmRejectReasonSet()
        {
            InitializeComponent();
        }

        #region 设置窗体控制器.
        /// <summary>
        /// 重载方法,设置窗体控制器.
        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsCtl_RejectReasonSet();
            objController.Set_GUI_Apperance(this);
        }
        #endregion

        private void m_cmdUp_Click(object sender, EventArgs e)
        {
            ((clsCtl_RejectReasonSet)objController).m_mthUpItems();
        }

        private void m_cmdDown_Click(object sender, EventArgs e)
        {
            ((clsCtl_RejectReasonSet)objController).m_mthDownItems();
        }

        private void m_cmdSaveToList_Click(object sender, EventArgs e)
        {
            if (m_txtReason.Tag == null)
            {
                ((clsCtl_RejectReasonSet)objController).m_mthSaveItemsToList();
            }
            else
            {
                ((clsCtl_RejectReasonSet)objController).m_mthModifyReason();
            }
        }

        private void m_cmdDeleteItems_Click(object sender, EventArgs e)
        {
            DialogResult drResult = MessageBox.Show("确定删除选定项目？", "作废原因设置",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (drResult == DialogResult.No)
            {
                return;
            }
            ((clsCtl_RejectReasonSet)objController).m_mthDeleteSeletedItems();
        }

        private void m_cmdSaveSort_Click(object sender, EventArgs e)
        {
            long lngRes = ((clsCtl_RejectReasonSet)objController).m_lngSaveSort();
            if (lngRes > 0)
            {
                MessageBox.Show("保存成功", "作废原因设置", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("保存失败", "作废原因设置", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void m_cmdClear_Click(object sender, EventArgs e)
        {
            m_txtReason.Clear();
            m_txtReason.Tag = null;
        }

        private void frmRejectReasonSet_Load(object sender, EventArgs e)
        {
            ((clsCtl_RejectReasonSet)objController).m_mthAddDataToList();
        }

        private void m_lsvReasonList_DoubleClick(object sender, EventArgs e)
        {
            if (m_lsvReasonList.SelectedItems.Count == 1)
            {
                clsMS_RejectReason objReason = m_lsvReasonList.SelectedItems[0].Tag as clsMS_RejectReason;
                if (objReason != null)
                {
                    m_txtReason.Text = objReason.m_strREASONDESC_VCHR;
                    m_txtReason.Tag = objReason;
                }
            }
        }
    }
}