using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.gui.MedicineStore;
using com.digitalwave.iCare.ValueObject;
using System.Windows.Forms;
using System.Data;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 供药单位供药明细
    /// </summary>
    class clsCtl_VendorSupplyDetail : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 全局变量
        /// <summary>
        /// 供药单位供药明细中间件访问类
        /// </summary>
        private clsDcl_VendorSupplyDetail m_objDomain = null;
        /// <summary>
        /// 供药单位供药明细窗体
        /// </summary>
        private frmVendorSupplyDetail m_objViewer = null;
        /// <summary>
        /// 查询供应商控件
        /// </summary>
        private ctlQueryVendor m_ctlQueryVendor = null;
        /// <summary>
        /// 供应商
        /// </summary>
        private DataTable m_dtbVendor = null;
        #endregion 

        #region 构造函数
        /// <summary>
        /// 供药单位供药明细窗体逻辑控制
        /// </summary>
        public clsCtl_VendorSupplyDetail()
        {
            m_objDomain = new clsDcl_VendorSupplyDetail();
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
            m_objViewer = (frmVendorSupplyDetail)frmMDI_Child_Base_in;
        }
        #endregion

        #region 统计供药单位供药明细
        /// <summary>
        /// 统计供药单位供药明细
        /// </summary>
        internal void m_mthStatistics()
        {
            DateTime dtmBegin = DateTime.Parse(Convert.ToDateTime(m_objViewer.m_dtpBeginDate.Text).ToString("yyyy-MM-dd 00:00:00"));
            DateTime dtmEnd = DateTime.Parse(Convert.ToDateTime(m_objViewer.m_dtpEndDate.Text).ToString("yyyy-MM-dd 23:59:59"));
            string strVendor = m_objViewer.m_txtVendor.Text;

            this.m_objViewer.m_dwcData.Modify("begindate.text = '" + dtmBegin.ToString("yyyy-MM-dd") + "'");
            this.m_objViewer.m_dwcData.Modify("enddate.text = '" + dtmEnd.ToString("yyyy-MM-dd") + "'");
            this.m_objViewer.m_dwcData.Modify("vendorname.text = '" + strVendor + "'");
            m_mthSetStorageNameToReport();

            string strVendorID = string.Empty;
            if (m_objViewer.m_txtVendor.Tag != null && !string.IsNullOrEmpty(m_objViewer.m_txtVendor.Text))
            {
                strVendorID = m_objViewer.m_txtVendor.Tag.ToString();
            }

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
            long lngRes = m_objDomain.m_lngStatistics(m_objViewer.m_strStorageID, dtmBegin, dtmEnd, strVendorID, intSetID, out dtbData);

            if (dtbData == null || dtbData.Rows.Count == 0)
            {
                m_objViewer.m_dwcData.Reset();
                return;
            }

            DataTable dtbNewdata = null;
            if (dtbData != null)
            {
                this.m_objViewer.m_dwcData.SetRedrawOff();

                //按药品ID排序
                DataView dtv = new DataView();
                dtv = dtbData.DefaultView;
                dtv.Sort = "assistcode_chr";
                dtbNewdata = dtv.ToTable();

                this.m_objViewer.m_dwcData.Retrieve(dtbNewdata);
                this.m_objViewer.m_dwcData.SetRedrawOn();
                this.m_objViewer.m_dwcData.Refresh();
            }
        }
        #endregion

        #region 显示供应商
        /// <summary>
        /// 显示供应商
        /// </summary>
        /// <param name="p_strSearchCon">查询条件</param>
        internal void m_mthShowVendor(string p_strSearchCon)
        {
            if (m_ctlQueryVendor == null)
            {
                m_mthGetVendor(out m_dtbVendor);
                m_ctlQueryVendor = new ctlQueryVendor(m_dtbVendor);
                m_objViewer.Controls.Add(m_ctlQueryVendor);

                int X = m_objViewer.m_txtVendor.Location.X;
                int Y = m_objViewer.m_txtVendor.Location.Y + m_objViewer.m_txtVendor.Size.Height;

                m_ctlQueryVendor.Location = new System.Drawing.Point(X, Y);
                m_ctlQueryVendor.ReturnInfo += new ReturnVendorInfo(QueryVendor_ReturnInfo);
            }
            m_ctlQueryVendor.BringToFront();
            m_ctlQueryVendor.m_mthSetSearchText(p_strSearchCon);
            m_ctlQueryVendor.Visible = true;
            m_ctlQueryVendor.Focus();
        }

        /// <summary>
        /// 获得供应商
        /// </summary>
        /// <param name="p_dtbVendor">供应商数据表</param>
        private void m_mthGetVendor(out DataTable p_dtbVendor)
        {
            long lngRes = m_objDomain.m_lngGetVendor(out p_dtbVendor);
        }

        internal void QueryVendor_ReturnInfo(com.digitalwave.iCare.ValueObject.clsMS_Vendor MS_VO)
        {
            m_objViewer.m_txtVendor.Tag = null;
            if (MS_VO == null)
            {
                return;
            }

            m_objViewer.m_txtVendor.Tag = MS_VO.m_strVendorID;
            m_objViewer.m_txtVendor.Text = MS_VO.m_strVendorName;

            m_objViewer.m_btnSearch.Focus();
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

        #region 初始化报表和窗体标题
        /// <summary>
        /// 把仓库名写到报表
        /// </summary>
        internal void m_mthSetStorageNameToReport()
        {
            if (string.IsNullOrEmpty(m_objViewer.m_strStorageName))
            {
                long lngRes = m_objDomain.m_lngGetStoreRoomName(m_objViewer.m_strStorageID, out m_objViewer.m_strStorageName);
            }
            this.m_objViewer.m_dwcData.Modify("storagename.text = '" + m_objViewer.m_strStorageName + "'");
        }

        /// <summary>
        /// 标题加仓库名
        /// </summary>
        internal void m_mthSetStorageNameToFrm()
        {
            long lngRes = m_objDomain.m_lngGetStoreRoomName(m_objViewer.m_strStorageID, out m_objViewer.m_strStorageName);
            this.m_objViewer.Text += "(" + m_objViewer.m_strStorageName + ")";
        }
        #endregion
    }
}
