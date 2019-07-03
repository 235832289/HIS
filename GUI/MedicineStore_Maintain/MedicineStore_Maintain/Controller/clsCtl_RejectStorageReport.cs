using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.gui.MedicineStore;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.GUI_Base;	
using com.digitalwave.Utility;
using com.digitalwave.iCare.common;
using System.IO;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 药库报废统计报表
    /// </summary>
    public class clsCtl_RejectStorageReport : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 全局变量
        /// <summary>
        /// 模块控制类
        /// </summary>
        private clsDcl_RejectStorageReport m_objDomain = null;
        /// <summary>
        /// 窗体
        /// </summary>
        private com.digitalwave.iCare.gui.MedicineStore_Maintain.frmRejectStorageReport m_objViewer;
               
        #endregion

        #region 构造函数
        /// <summary>
        /// 药库报废统计报表
        /// </summary>
        public clsCtl_RejectStorageReport()
        {
            m_objDomain = new clsDcl_RejectStorageReport();
        }
        #endregion

        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmRejectStorageReport)frmMDI_Child_Base_in;
        }
        #endregion
        
        #region 初始化报表和窗体标题
        /// <summary>
        /// 把仓库名写到报表
        /// </summary>
        internal void m_mthSetStorageNameToReport()
        {
            if (string.IsNullOrEmpty(m_objViewer.p_strStorageName))
            {
                long lngRes = m_objDomain.m_lngGetStoreRoomName(m_objViewer.m_strStorageID, out m_objViewer.p_strStorageName);
            }
            this.m_objViewer.dwOutStorageStat.Modify("title_t_1.text='报废统计报表(" + m_objViewer.p_strStorageName + ")'");
           
        }

        /// <summary>
        /// 标题加仓库名
        /// </summary>
        internal void m_mthSetStorageNameToFrm()
        {
            long lngRes = m_objDomain.m_lngGetStoreRoomName(m_objViewer.m_strStorageID, out m_objViewer.p_strStorageName);
            this.m_objViewer.Text += "(" + m_objViewer.p_strStorageName + ")";
        }
        #endregion

        #region 药品报废明细
        /// <summary>
        /// 药品报废明细
        /// </summary>
        internal void m_mthStatistics()
        {
            DateTime dtmBegin = DateTime.Parse(Convert.ToDateTime(m_objViewer.txtOutStorageBeginDate.Text).ToString("yyyy-MM-dd 00:00:00"));
            DateTime dtmEnd = DateTime.Parse(Convert.ToDateTime(m_objViewer.txtOutStorageEndDate.Text).ToString("yyyy-MM-dd 23:59:59"));
            
            this.m_objViewer.dwOutStorageStat.Modify("t_9.text = '" + dtmBegin.ToString("yyyy-MM-dd") + " 至 " + dtmEnd.ToString("yyyy-MM-dd") + "'");
            this.m_objViewer.dwOutStorageStat.Modify("t_type.text='" + this.m_objViewer.m_cboType.Text + "'");
            m_mthSetStorageNameToReport();           

            int intSetID = 0;
            if (m_objViewer.m_cboType.SelectedItem != null)
            {
                clsMS_MedicineTypeSetVO objSet = m_objViewer.m_cboType.SelectedItem as clsMS_MedicineTypeSetVO;
                if (objSet != null)
                {
                    intSetID = objSet.m_intMedicineTypeSetID;
                }
            }

            DataTable dtbData = null;
            long lngRes = m_objDomain.m_lngStatistics(m_objViewer.m_strStorageID, dtmBegin, dtmEnd, intSetID, out dtbData);

            if (dtbData == null || dtbData.Rows.Count == 0)
            {
                m_objViewer.dwOutStorageStat.Reset();
                return;
            }

          
            if (dtbData != null)
            {
                this.m_objViewer.dwOutStorageStat.SetRedrawOff();
                this.m_objViewer.dwOutStorageStat.Retrieve(dtbData);
                this.m_objViewer.dwOutStorageStat.SetRedrawOn();
                this.m_objViewer.dwOutStorageStat.Refresh();
            }
        }
        #endregion

        #region 获取药品类型设置
        /// <summary>
        /// 获取药品类型设置
        /// </summary>
        internal void m_mthGetMedicineTypeSet()
        {
            clsMS_MedicineTypeSetVO[] objMPVO = null;
            clsDcl_MedicineTypeSet objMTDomain = new clsDcl_MedicineTypeSet();
            long lngRes = objMTDomain.m_lngGetAllMedicinTypeSetInfo(out objMPVO);
            objMTDomain = null;

            if (objMPVO == null || m_objViewer.m_cboType.Items.Count > 0)
            {
                return;
            }

            clsMS_MedicineTypeSetVO objAll = new clsMS_MedicineTypeSetVO();
            objAll.m_intMedicineTypeSetID = 0;
            objAll.m_strMedicineTypeSetName = "全部";

            m_objViewer.m_cboType.Items.Add(objAll);
            m_objViewer.m_cboType.Items.AddRange(objMPVO);

            m_objViewer.m_cboType.SelectedIndex = 0;
        }
        #endregion
    }
}
