using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 药品类型设置
    /// </summary>
    public class clsCtl_MedicineTypeSet : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 全局变量

        /// <summary>
        /// 模块控制类        /// </summary>
        private clsDcl_MedicineTypeSet m_objDomain = null;

        /// <summary>
        /// 窗体
        /// </summary>
        private com.digitalwave.iCare.gui.MedicineStore_Maintain.frmMedicintTypeSet m_objViewer;

        #endregion

        #region 构造函数.

        /// <summary>
        /// 药品类型设置
        /// </summary>
        public clsCtl_MedicineTypeSet()
        {
            m_objDomain = new clsDcl_MedicineTypeSet();
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
            m_objViewer = (frmMedicintTypeSet)frmMDI_Child_Base_in;
        }
        #endregion

        #region 获取并添加药品基本类型信息
        /// <summary>
        /// 获取并添加药品基本类型信息
        /// </summary>
        internal void m_mthGetMedicineType()
        {
            clsDcl_MedicineStoreroomSet objMSDomain = new clsDcl_MedicineStoreroomSet();
            clsMS_MedicineType_VO[] objTypeArr = null;
            long lngRes = objMSDomain.m_lngGetMedicineInfo(out objTypeArr);

            if (objTypeArr != null && objTypeArr.Length > 0)
            {
                List<System.Windows.Forms.ListViewItem> lstLSI = new List<System.Windows.Forms.ListViewItem>();
                System.Windows.Forms.ListViewItem lsiTemp = null;
                for (int iL = 0; iL < objTypeArr.Length; iL++)
                {
                    lsiTemp = new System.Windows.Forms.ListViewItem(objTypeArr[iL].m_strMedicineTypeName_VCHR);
                    lsiTemp.Tag = objTypeArr[iL].m_strMedicineTypeID_CHR;
                    lstLSI.Add(lsiTemp);
                }

                if (lstLSI.Count > 0)
                {
                    m_objViewer.m_lsvMedicineName.Items.AddRange(lstLSI.ToArray());
                }
            }
        } 
        #endregion

        #region 获取并添加药品类型设置信息
        /// <summary>
        /// 获取并添加药品类型设置信息
        /// </summary>
        internal void m_mthGetAllMedicineTypeSetInfo()
        {
            clsMS_MedicineTypeSetVO[] objTypeArr = null;
            long lngRes = m_objDomain.m_lngGetAllMedicinTypeSetInfo(out objTypeArr);

            if (objTypeArr != null && objTypeArr.Length > 0)
            {
                List<System.Windows.Forms.ListViewItem> lstLSI = new List<System.Windows.Forms.ListViewItem>();
                System.Windows.Forms.ListViewItem lsiTemp = null;
                for (int iL = 0; iL < objTypeArr.Length; iL++)
                {
                    lsiTemp = new System.Windows.Forms.ListViewItem(objTypeArr[iL].m_intMedicineTypeSetID.ToString());
                    lsiTemp.SubItems.Add(objTypeArr[iL].m_strMedicineTypeSetName);
                    lstLSI.Add(lsiTemp);
                }

                if (lstLSI.Count > 0)
                {
                    m_objViewer.m_lsvMedicineTypeSet.Items.AddRange(lstLSI.ToArray());
                }
            }
        }

        /// <summary>
        /// 获取指定药品类型设置信息
        /// </summary>
        internal void m_mthGetMedicineTypeSetInfo()
        {
            foreach (System.Windows.Forms.ListViewItem lvi in m_objViewer.m_lsvMedicineName.CheckedItems)
            {
                lvi.Checked = false;
            }

            if (m_objViewer.m_lsvMedicineTypeSet.SelectedItems.Count == 0)
            {
                return;
            }

            m_objViewer.m_txtMedicineStoreRoom.Text = m_objViewer.m_lsvMedicineTypeSet.SelectedItems[0].SubItems[1].Text;
            m_objViewer.m_txtMedicineStoreRoom.Tag = m_objViewer.m_lsvMedicineTypeSet.SelectedItems[0].SubItems[0].Text;
            int intSetID = 1;
            if (int.TryParse(m_objViewer.m_lsvMedicineTypeSet.SelectedItems[0].SubItems[0].Text, out intSetID))
            {
                clsMS_MedicineType_VO[] objTypeArr = null;
                long lngRes = m_objDomain.m_lngGetMedicinTypeSetInfo(intSetID,out objTypeArr);

                if (objTypeArr != null && objTypeArr.Length > 0)
                {
                    System.Windows.Forms.ListViewItem lviTemp = null;
                    for (int iType = 0; iType < objTypeArr.Length; iType++)
                    {
                        lviTemp = m_objViewer.m_lsvMedicineName.FindItemWithText(objTypeArr[iType].m_strMedicineTypeName_VCHR);
                        if (lviTemp != null)
                        {
                            lviTemp.Checked = true;
                        }
                    }
                } 
            }            
        } 
        #endregion

        #region 清空编辑界面
        /// <summary>
        /// 清空编辑界面
        /// </summary>
        internal void m_mthClear()
        {
            m_objViewer.m_txtMedicineStoreRoom.Clear();
            m_objViewer.m_txtMedicineStoreRoom.Tag = null;
            if (m_objViewer.m_lsvMedicineName.Items.Count > 0)
            {
                for (int iItem = 0; iItem < m_objViewer.m_lsvMedicineName.Items.Count; iItem++)
                {
                    m_objViewer.m_lsvMedicineName.Items[iItem].Checked = false;
                }
            }
        } 
        #endregion

        #region 添加新的药品类型设置
        /// <summary>
        /// 添加新的药品类型设置
        /// </summary>
        internal void m_mthAddNewTypeSet()
        {
            if (string.IsNullOrEmpty(m_objViewer.m_txtMedicineStoreRoom.Text))
            {
                System.Windows.Forms.MessageBox.Show("请先填写药品类型名称", "药品类型设置", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return;
            }

            if (m_objViewer.m_lsvMedicineName.Items.Count == 0 || m_objViewer.m_lsvMedicineName.CheckedItems.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("请先选择对应的药品基本类型", "药品类型设置", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return;
            }

            long lngRes = 0;
            clsMS_MedicineTypeSetVO objTypeSet = new clsMS_MedicineTypeSetVO();
            objTypeSet.m_strMedicineTypeSetName = m_objViewer.m_txtMedicineStoreRoom.Text;
            objTypeSet.m_strMedicineTypeIDArr = new string[m_objViewer.m_lsvMedicineName.CheckedItems.Count];
            string strSetName = string.Empty;
            for (int iItem = 0; iItem < m_objViewer.m_lsvMedicineName.CheckedItems.Count; iItem++)
            {
                objTypeSet.m_strMedicineTypeIDArr[iItem] = m_objViewer.m_lsvMedicineName.CheckedItems[iItem].Tag.ToString();
                lngRes = m_objDomain.m_lngCheckHasSetOtherType(objTypeSet.m_strMedicineTypeIDArr[iItem], out strSetName);
                if (!string.IsNullOrEmpty(strSetName))
                {
                    System.Windows.Forms.MessageBox.Show(m_objViewer.m_lsvMedicineName.CheckedItems[iItem].Text + "已设置为属于" + strSetName + "，不能重复设置",
                        "药品类型设置", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Stop);
                    return;
                }
            }

            lngRes = m_objDomain.m_lngAddNewMedicneTypeSet(objTypeSet);
            if (lngRes > 0)
            {
                m_mthClear();
                m_objViewer.m_lsvMedicineTypeSet.Items.Clear();
                m_mthGetAllMedicineTypeSetInfo();

                System.Windows.Forms.MessageBox.Show("保存成功", "药品类型设置", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("保存失败", "药品类型设置", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        } 
        #endregion

        #region 添加新的药品类型设置
        /// <summary>
        /// 添加新的药品类型设置
        /// </summary>
        internal void m_mthModifyTypeSet()
        {
            if (string.IsNullOrEmpty(m_objViewer.m_txtMedicineStoreRoom.Text))
            {
                System.Windows.Forms.MessageBox.Show("请先填写药品类型名称", "药品类型设置", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return;
            }

            if (m_objViewer.m_lsvMedicineName.Items.Count == 0 || m_objViewer.m_lsvMedicineName.CheckedItems.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("请先选择对应的药品基本类型", "药品类型设置", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return;
            }

            clsMS_MedicineTypeSetVO objTypeSet = new clsMS_MedicineTypeSetVO();
            int intSetID = 1;
            if (int.TryParse(m_objViewer.m_txtMedicineStoreRoom.Tag.ToString(), out intSetID))
            {
                objTypeSet.m_intMedicineTypeSetID = intSetID;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("保存失败", "药品类型设置", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return;
            }

            long lngRes = 0;
            objTypeSet.m_strMedicineTypeSetName = m_objViewer.m_txtMedicineStoreRoom.Text;
            objTypeSet.m_strMedicineTypeIDArr = new string[m_objViewer.m_lsvMedicineName.CheckedItems.Count];
            string strSetName = string.Empty;
            for (int iItem = 0; iItem < m_objViewer.m_lsvMedicineName.CheckedItems.Count; iItem++)
            {
                objTypeSet.m_strMedicineTypeIDArr[iItem] = m_objViewer.m_lsvMedicineName.CheckedItems[iItem].Tag.ToString();
                lngRes = m_objDomain.m_lngCheckHasSetOtherType(objTypeSet.m_strMedicineTypeIDArr[iItem], out strSetName);
                if (!string.IsNullOrEmpty(strSetName) && strSetName != m_objViewer.m_txtMedicineStoreRoom.Text)
                {
                    System.Windows.Forms.MessageBox.Show(m_objViewer.m_lsvMedicineName.CheckedItems[iItem].Text + "已设置为属于" + strSetName + "，不能重复设置",
                        "药品类型设置", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Stop);
                    return;
                }
            }

            lngRes = m_objDomain.m_lngModifyMedicineTypeSet(objTypeSet);
            if (lngRes > 0)
            {
                m_mthClear();
                m_objViewer.m_lsvMedicineTypeSet.Items.Clear();
                m_mthGetAllMedicineTypeSetInfo();

                System.Windows.Forms.MessageBox.Show("保存成功", "药品类型设置", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("保存失败", "药品类型设置", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 删除选择的药品设置
        /// <summary>
        /// 删除选择的药品设置
        /// </summary>
        internal void m_mthDeleteTypeSet()
        {
            int intSetID = 0;
            if (m_objViewer.m_lsvMedicineTypeSet.SelectedItems.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("请先选择一个药品设置类型", "药品类型设置", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            if (int.TryParse(m_objViewer.m_lsvMedicineTypeSet.SelectedItems[0].SubItems[0].Text, out intSetID))
            {
                long lngRes = m_objDomain.m_lngDeleteMedicineTypeSet(intSetID);

                if (lngRes > 0)
                {
                    m_mthClear();
                    m_objViewer.m_lsvMedicineTypeSet.Items.Clear();
                    m_mthGetAllMedicineTypeSetInfo();

                    System.Windows.Forms.MessageBox.Show("删除成功", "药品类型设置", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("删除失败", "药品类型设置", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
            }
        } 
        #endregion
    }
}
