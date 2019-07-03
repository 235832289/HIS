using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 仓库设置业务操作类.
    /// </summary>
    public class clsCtl_MedicineStoreroomSet:com.digitalwave.GUI_Base.clsController_Base
    {
        #region 全局变量

        /// <summary>
        /// 模块控制类
        /// </summary>
        private clsDcl_MedicineStoreroomSet m_objDomain = null;

        /// <summary>
        /// 窗体
        /// </summary>
        private com.digitalwave.iCare.gui.MedicineStore_Maintain.frmMedicineStoreroomSet m_objViewer;

        #endregion

        #region 构造函数.

        /// <summary>
        /// 构造函数.
        /// </summary>
        public clsCtl_MedicineStoreroomSet()
        {
            m_objDomain = new clsDcl_MedicineStoreroomSet();
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
            m_objViewer = (frmMedicineStoreroomSet)frmMDI_Child_Base_in;
        }
        #endregion

        #region 获取药品类型信息.

        /// <summary>
        /// 获取药品类型信息.
        /// </summary>
        /// <param name="m_objMedicineTypeArr">返回结果.</param>
        internal void m_mthGetMedicineTypeInfo(out clsMS_MedicineType_VO[] m_objMedicineTypeArr)
        {
            m_objDomain.m_lngGetMedicineInfo(out m_objMedicineTypeArr);
        }
        #endregion

        #region 获取库房信息.

        /// <summary>
        /// 获取库房信息.
        /// </summary>
        /// <param name="m_lstMedicineRoomArr">返回结果.</param>
        public void m_mthGetMedicineRoomInfo(ref List<clsMS_MedicineStoreroom_VO> m_lstMedicineRoomArr)
        {
            clsMS_MedicineStoreroom_VO[] m_objMedicineRoomArr = null;
            //m_lstMedicineRoomArr = null;

            m_objDomain.m_lngGetMedicineStoreInfo(out m_objMedicineRoomArr);

            if (m_objMedicineRoomArr == null || m_objMedicineRoomArr.Length == 0)
                return;
            foreach (clsMS_MedicineStoreroom_VO obj_VO in m_objMedicineRoomArr)
            {
                m_lstMedicineRoomArr.Add(obj_VO);
            }
        }
        #endregion

        #region 添加库存记录.

        /// <summary>
        ///  添加库存记录.
        /// </summary>
        /// <param name="p_objMedicineStore">新增库房记录.</param>
        public void m_mthInsertMedicineRoomInfo(ref clsMS_MedicineStoreroom_VO p_objMedicineStore)
        {
            m_objDomain.m_lngInsertMedicineStoreInfo(ref p_objMedicineStore);
        }
        #endregion
        #region 添加库存记录.

        /// <summary>
        ///  添加库存记录.
        /// </summary>
        /// <param name="p_objMedicineStore">新增库房记录.</param>
        public void m_mthInsertMedStoreSetInfo(ref clsMS_MedicineStoreroom_VO p_objMedicineStore)
        {
            m_objDomain.m_lngAddNewMedStoreSetInfo(ref p_objMedicineStore);
        }
                #endregion
        #region 删除库房记录.

        /// <summary>
        /// 删除库房记录.
        /// </summary>
        /// <param name="strStoreID">要删除的库房记录的库房ID.</param>
        public void m_mthDeleteMedicineRoomInfo(string strStoreID)
        {
            long lngRes = m_objDomain.m_lngDeleteMedicineStoreInfo(strStoreID);

            if (lngRes > 0)
            {
                m_objViewer.m_blnIsSave = true;
                m_objViewer.m_txtMedicineStoreRoom.Text = "";
                System.Windows.Forms.ListView.CheckedListViewItemCollection lvcCollection = m_objViewer.m_lsvMedicineName.CheckedItems;
                if (lvcCollection.Count == 0)
                {
                    return;
                }
                foreach (System.Windows.Forms.ListViewItem lvi in lvcCollection)
                {
                    lvi.Checked = false;
                }
            }
        }
        #endregion
        #region 删除库房记录.

        /// <summary>
        /// 删除库房记录.
        /// </summary>
        /// <param name="strStoreID">要删除的库房记录的库房ID.</param>
        public void m_mthDeleteMedStoreSetInfo(string strStoreID,bool blnDeleted)
        {
            long lngRes = m_objDomain.m_lngDeleteMedStoreSetInfo(strStoreID);

            if (lngRes > 0)
            {
                m_objViewer.m_blnIsSave = true;
                System.Windows.Forms.ListView.CheckedListViewItemCollection lvcCollection = m_objViewer.m_lsvMedicineName.CheckedItems;
                if (lvcCollection.Count == 0)
                {
                    return;
                }
                if (blnDeleted == true)
                {
                    foreach (System.Windows.Forms.ListViewItem lvi in lvcCollection)
                    {
                        lvi.Checked = false;
                    }
                }
            }
        }
        #endregion
        #region 查询库房药品信息.

        /// <summary>
        /// 查询库房药品信息.
        /// </summary>
        /// <param name="strStoreID">查询条件.</param>
        /// <param name="strMedicineNameArr">返回结果.</param>
        public void m_mthSelectMedicineName(string strStoreID, out string[] strMedicineNameArr)
        {
            m_objDomain.m_lngSelectMedicineName(strStoreID, out strMedicineNameArr);
        }
        #endregion

        #region 获取指定仓库已设置的药品类型
        /// <summary>
        /// 获取指定仓库已设置的药品类型
        /// </summary>
        /// <param name="p_strStoreRoomID"></param>
        internal void m_mthSetMedicineTypeCheck(string p_strStoreRoomID)
        {
            clsMS_MedicineType_VO[] objMedType = null;
              long lngRes=0;
            if(this.m_objViewer.m_strMedStoreArr==null)
             lngRes = m_objDomain.m_lngGetStoreRoomSetCheck(p_strStoreRoomID, out objMedType);
            else
             lngRes = m_objDomain.m_lngGetMedStoreSetCheck(p_strStoreRoomID, out objMedType);

            if (objMedType == null || objMedType.Length == 0)
            {
                return;
            }

            System.Windows.Forms.ListViewItem lviTemp = null;
            for (int iType = 0; iType < objMedType.Length; iType++)
            {
                lviTemp = m_objViewer.m_lsvMedicineName.FindItemWithText(objMedType[iType].m_strMedicineTypeName_VCHR);
                if (lviTemp != null)
                {
                    lviTemp.Checked = true;
                }
            }

            m_objViewer.m_blnIsSave = false;
        }
        #endregion

        internal void m_lngGetMedStoreInfo(out DataTable m_dtMedStore)
        {
            m_objDomain.m_lngGetMedStoreInfo(out m_dtMedStore);
        }

        internal void m_lngGetDeptInfo(out DataTable m_dtDeptDesc)
        {
            m_objDomain.m_lngGetDeptInfo(out m_dtDeptDesc);
        }
    }
}
