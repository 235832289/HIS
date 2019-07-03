using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 报废原因设置
    /// </summary>
    public class clsCtl_RejectReasonSet : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 全局变量

        /// <summary>
        /// 模块控制类
        /// </summary>
        private clsDcl_RejectReasonSet m_objDomain = null;

        /// <summary>
        /// 窗体
        /// </summary>
        private com.digitalwave.iCare.gui.MedicineStore_Maintain.frmRejectReasonSet m_objViewer;

        #endregion

        #region 构造函数

        /// <summary>
        /// 报废原因设置
        /// </summary>
        public clsCtl_RejectReasonSet()
        {
            m_objDomain = new clsDcl_RejectReasonSet();
        }
        #endregion

        #region 设置窗体对象

        /// <summary>
        /// 设置窗体对象.
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmRejectReasonSet)frmMDI_Child_Base_in;
        }
        #endregion

        #region 移动项目
        /// <summary>
        /// 向上移动项目
        /// </summary>
        internal void m_mthUpItems()
        {
            if (m_objViewer.m_lsvReasonList.SelectedItems.Count <= 0)
                return;

            System.Windows.Forms.ListViewItem[] lsiArr = new System.Windows.Forms.ListViewItem[m_objViewer.m_lsvReasonList.SelectedItems.Count];
            for (int i = 0; i < m_objViewer.m_lsvReasonList.SelectedItems.Count; i++)
            {
                int idx = m_objViewer.m_lsvReasonList.SelectedItems[i].Index;
                lsiArr[i] = m_objViewer.m_lsvReasonList.Items[idx];
            }

            for (int i = 0; i < lsiArr.Length; i++)
            {
                int idx = lsiArr[i].Index;
                if (idx > 0)
                {
                    System.Windows.Forms.ListViewItem itemLast = m_objViewer.m_lsvReasonList.Items[idx - 1];
                    System.Windows.Forms.ListViewItem itemCurrent = lsiArr[i].Clone() as System.Windows.Forms.ListViewItem;
                    m_objViewer.m_lsvReasonList.Items[idx - 1] = itemCurrent;
                    m_objViewer.m_lsvReasonList.Items[idx] = itemLast;
                    m_objViewer.m_lsvReasonList.Focus();
                    m_objViewer.m_lsvReasonList.Items[idx - 1].Selected = true;
                    m_objViewer.m_lsvReasonList.Items[idx - 1].EnsureVisible();
                }
            }

            m_mthReSetAcitveItemOrderID();
        }

        /// <summary>
        /// 向下移动项目
        /// </summary>
        internal void m_mthDownItems()
        {
            if (m_objViewer.m_lsvReasonList.SelectedItems.Count <= 0)
                return;

            System.Windows.Forms.ListViewItem[] lsiArr = new System.Windows.Forms.ListViewItem[m_objViewer.m_lsvReasonList.SelectedItems.Count];
            for (int i = 0; i < m_objViewer.m_lsvReasonList.SelectedItems.Count; i++)
            {
                int idx = m_objViewer.m_lsvReasonList.SelectedItems[i].Index;
                lsiArr[i] = m_objViewer.m_lsvReasonList.Items[idx];
            }

            for (int i = lsiArr.Length - 1; i >= 0; i--)
            {
                int idx = lsiArr[i].Index;
                if (idx < m_objViewer.m_lsvReasonList.Items.Count - 1)
                {
                    System.Windows.Forms.ListViewItem itemNext = m_objViewer.m_lsvReasonList.Items[idx + 1];
                    System.Windows.Forms.ListViewItem itemCurrent = lsiArr[i].Clone() as System.Windows.Forms.ListViewItem;
                    m_objViewer.m_lsvReasonList.Items[idx + 1] = itemCurrent;
                    m_objViewer.m_lsvReasonList.Items[idx] = itemNext;
                    m_objViewer.m_lsvReasonList.Focus();
                    m_objViewer.m_lsvReasonList.Items[idx + 1].Selected = true;
                    m_objViewer.m_lsvReasonList.Items[idx + 1].EnsureVisible();
                }
            }

            m_mthReSetAcitveItemOrderID();
        } 
        #endregion

        #region 重新设定已启用项目顺序
        /// <summary>
        /// 重新设定已启用项目顺序
        /// </summary>
        private void m_mthReSetAcitveItemOrderID()
        {
            for (int i = 0; i < m_objViewer.m_lsvReasonList.Items.Count; i++)
            {
                m_objViewer.m_lsvReasonList.Items[i].SubItems[0].Text = (i + 1).ToString();
                clsMS_RejectReason objReason = m_objViewer.m_lsvReasonList.Items[i].Tag as clsMS_RejectReason;
                if (objReason != null)
                {
                    objReason.m_intSORTNUM_INT = i + 1;
                }
            }
        }
        #endregion

        #region 新增项目并将其添加至列表
        /// <summary>
        /// 新增项目并将其添加至列表
        /// </summary>
        internal void m_mthSaveItemsToList()
        {
            if (string.IsNullOrEmpty(m_objViewer.m_txtReason.Text))
            {
                System.Windows.Forms.MessageBox.Show("请先输入作废原因","作废原因设置",System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return;
            }

            clsMS_RejectReason objReason = new clsMS_RejectReason();
            objReason.m_intSORTNUM_INT = m_objViewer.m_lsvReasonList.Items.Count + 1;
            objReason.m_strREASONDESC_VCHR = m_objViewer.m_txtReason.Text;

            int intReasonID = 0;
            long lngRes = m_objDomain.m_lngAddNewRejectReason(objReason, out intReasonID);

            if (lngRes > 0)
            {
                objReason.m_intREASONID_INT = intReasonID;
                System.Windows.Forms.ListViewItem lsi = new System.Windows.Forms.ListViewItem(objReason.m_intSORTNUM_INT.ToString());
                lsi.SubItems.Add(objReason.m_strREASONDESC_VCHR);
                lsi.Tag = objReason;
                m_objViewer.m_lsvReasonList.Items.Add(lsi);
                m_objViewer.m_txtReason.Clear();
                m_objViewer.m_txtReason.Tag = null;
                System.Windows.Forms.MessageBox.Show("保存成功", "作废原因设置", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("保存失败", "作废原因设置", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        } 
        #endregion

        #region 删除选定项目
        /// <summary>
        /// 删除选定项目
        /// </summary>
        internal void m_mthDeleteSeletedItems()
        {
            if (m_objViewer.m_lsvReasonList.SelectedItems.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("请先选择要删除的作废原因", "作废原因设置", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return;
            }

            List<System.Windows.Forms.ListViewItem> lstReasons = new List<System.Windows.Forms.ListViewItem>();
            List<long> lstIDs = new List<long>();
            for (int iR = 0; iR < m_objViewer.m_lsvReasonList.SelectedItems.Count; iR++)
            {
                clsMS_RejectReason objReason = m_objViewer.m_lsvReasonList.SelectedItems[iR].Tag as clsMS_RejectReason;
                if (objReason != null)
                {
                    lstIDs.Add(objReason.m_intREASONID_INT);
                    lstReasons.Add(m_objViewer.m_lsvReasonList.SelectedItems[iR]);
                }
            }

            long lngRes = m_objDomain.m_lngDeleteRejectReason(lstIDs.ToArray());

            if (lngRes > 0)
            {
                foreach (System.Windows.Forms.ListViewItem lsi in lstReasons)
                {
                    m_objViewer.m_lsvReasonList.Items.Remove(lsi);
                }
                m_mthReSetAcitveItemOrderID();
                m_lngSaveSort();
                System.Windows.Forms.MessageBox.Show("删除成功", "作废原因设置", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("删除失败", "作废原因设置", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        } 
        #endregion

        #region 保存顺序变更
        /// <summary>
        /// 保存顺序变更
        /// </summary>
        internal long m_lngSaveSort()
        {
            if (m_objViewer.m_lsvReasonList.Items.Count == 0)
            {
                return 1;
            }

            List<clsMS_RejectReason> lstReasons = new List<clsMS_RejectReason>();
            for (int iItem = 0; iItem < m_objViewer.m_lsvReasonList.Items.Count; iItem++)
            {
                clsMS_RejectReason objReason = m_objViewer.m_lsvReasonList.Items[iItem].Tag as clsMS_RejectReason;
                if (objReason != null)
                {
                    lstReasons.Add(objReason);
                }
            }

            long lngRes = m_objDomain.m_lngUpdateReasonSort(lstReasons.ToArray());
            return lngRes;
        } 
        #endregion

        #region 修改作废原因
        /// <summary>
        /// 修改作废原因
        /// </summary>
        internal void m_mthModifyReason()
        {
            clsMS_RejectReason objReason = m_objViewer.m_txtReason.Tag as clsMS_RejectReason;
            if (objReason == null)
            {
                System.Windows.Forms.MessageBox.Show("请选双击选择一项作废原因","作废原因设置",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Warning);
                return;
            }

            objReason.m_strREASONDESC_VCHR = m_objViewer.m_txtReason.Text;

            long lngRes = m_objDomain.m_lngModifyRejectReason(objReason);

            if (lngRes > 0)
            {
                m_objViewer.m_lsvReasonList.SelectedItems[0].SubItems[1].Text = objReason.m_strREASONDESC_VCHR;
                m_objViewer.m_txtReason.Clear();
                m_objViewer.m_txtReason.Tag = null;
                System.Windows.Forms.MessageBox.Show("保存成功", "作废原因设置", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("保存失败", "作废原因设置", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        } 
        #endregion

        #region 获取作废原因并设置至界面
        /// <summary>
        /// 获取作废原因并设置至界面
        /// </summary>
        internal void m_mthAddDataToList()
        {
            clsMS_RejectReason[] objReasons = null;
            long lngRes = m_objDomain.m_lngGetAllRejectReason(out objReasons);

            if (objReasons != null && objReasons.Length > 0)
            {
                List<System.Windows.Forms.ListViewItem> lsiReasons = new List<System.Windows.Forms.ListViewItem>();
                for (int iR = 0; iR < objReasons.Length; iR++)
                {
                    System.Windows.Forms.ListViewItem lsi = new System.Windows.Forms.ListViewItem(objReasons[iR].m_intSORTNUM_INT.ToString());
                    lsi.SubItems.Add(objReasons[iR].m_strREASONDESC_VCHR);
                    lsi.Tag = objReasons[iR];
                    lsiReasons.Add(lsi);
                }

                if (lsiReasons.Count > 0)
                {
                    m_objViewer.m_lsvReasonList.Items.AddRange(lsiReasons.ToArray());
                }
            }
        } 
        #endregion
    }
}
