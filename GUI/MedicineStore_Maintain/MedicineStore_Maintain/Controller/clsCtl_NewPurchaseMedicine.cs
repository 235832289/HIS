using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.digitalwave.iCare.gui.MedicineStore;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using System.Collections;
using com.digitalwave.iCare.middletier.MedicineStoreService;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 获取新药明细模块控制类
    /// </summary>
    public class clsCtl_NewPurchaseMedicine : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 全局变量
        /// <summary>
        /// 模块控制类
        /// </summary>
        private clsDcl_NewPurchaseMedicine m_objDomain = null;
        /// <summary>
        /// 窗体
        /// </summary>
        private com.digitalwave.iCare.gui.MedicineStore_Maintain.frmNewPurchaseMedicine m_objViewer;
        /// <summary>
        /// 药品明细数据表
        /// </summary>  
        internal DataTable dtbResult = null;
        /// <summary>
        /// 药品查询控件
        /// </summary>
        private ctlQueryMedicintLeastElement m_ctlQueryMedicint = null;
        /// <summary>
        /// 查询供应商控件
        /// </summary>
        private ctlQueryVendor m_ctlQueryVendor = null;
        /// <summary>
        /// 供应商（经销商）
        /// </summary>
        DataTable m_dtbVendor = null;
        #endregion  
      
        #region 构造函数.

        /// <summary>
        /// 药品类型设置
        /// </summary>
        public clsCtl_NewPurchaseMedicine()
        {
            m_objDomain = new clsDcl_NewPurchaseMedicine();
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
            m_objViewer = (frmNewPurchaseMedicine)frmMDI_Child_Base_in;
        }
        #endregion

        #region 获取药品明细数据
        /// <summary>
        /// 获取新购药品明细数据
        /// 实现统计查询和明细查询功能。
        /// 可按药品的助记码、拼音码、五笔码、药品的ID或药品名称进行模糊查询
        /// </summary>
        internal void m_mthQuery()
        {
            if (m_objViewer.m_strStorageID == string.Empty)
            {
                MessageBox.Show("必须选择药库!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (m_objViewer.m_dtpSearchBeginDate.Text.Trim().Length < 11)
                m_objViewer.m_dtpSearchBeginDate.Text = "";
            if (m_objViewer.m_dtpSearchEndDate.Text.Trim().Length < 11)
                m_objViewer.m_dtpSearchEndDate.Text = "";

            if ((m_objViewer.m_dtpSearchBeginDate.Text.Trim().Length == 11) && (m_objViewer.m_dtpSearchEndDate.Text.Trim().Length == 11))
            {
                if ((Convert.ToDateTime(m_objViewer.m_dtpSearchBeginDate.Text)) > (Convert.ToDateTime(m_objViewer.m_dtpSearchEndDate.Text)))
                {
                    DialogResult tmpResult = MessageBox.Show("开始日期必须小于结束日期！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    m_objViewer.m_dtpSearchBeginDate.Focus();
                    return;
                }
            }

            long lngRes = 0;
            m_objViewer.m_dgvNewMedicine.DataSource = null;

            if (dtbResult != null)
            {
                dtbResult.Clear();
                dtbResult.Dispose();
                dtbResult = null;
            }

            m_objViewer.m_mthInitDataTable();
            ArrayList al = new ArrayList();
            al.Add(m_objViewer.m_strStorageID);
            DateTime m_datBeginTime = Convert.ToDateTime((Convert.ToDateTime(m_objViewer.m_dtpSearchBeginDate.Text)).ToString("yyyy-MM-dd 00:00:00"));
            DateTime m_datEndTime = Convert.ToDateTime((Convert.ToDateTime(m_objViewer.m_dtpSearchEndDate.Text)).ToString("yyyy-MM-dd 23:59:59"));            
            al.Add(m_datBeginTime);
            al.Add(m_datEndTime);            
            al.Add(m_objViewer.m_txtMedicineName.Text.Trim());
            al.Add(m_objViewer.m_txtProviderName.Text);
            al.Add(m_objViewer.m_txtBillNumber.Text);
            if (m_objViewer.m_cboDoseType.SelectedIndex < 0 || m_objViewer.m_cboDoseType.SelectedIndex == 0)
            {
                al.Add(0);
            }
            else
            {
                clsMS_MedicineType_VO objVo = m_objViewer.m_cboDoseType.SelectedItem as clsMS_MedicineType_VO;
                al.Add(objVo.m_strMedicineTypeID_CHR);
            }

            dtbResult = new DataTable();

            lngRes = ((clsDcl_NewPurchaseMedicine)this.m_objDomain).m_lngGetNewPurchaseMedicine(al, out dtbResult);
            if ((lngRes > 0) && (dtbResult != null))
            {
                m_objViewer.m_dgvNewMedicine.DataSource = dtbResult;
            }           
        }
        #endregion

        #region 打印
        internal void m_mthPrint()
        {
            if (dtbResult == null || dtbResult.Rows.Count <= 0)
            {
                MessageBox.Show("没有可打印数据！", "打印新药通知单", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            frmNewPurchaseMedicineReport frmReport = new frmNewPurchaseMedicineReport();
            frmReport.p_dtbVal = dtbResult;
            clsDcl_RejectStorageReport dclTemp = new clsDcl_RejectStorageReport();
            string strStorageName = string.Empty;
            dclTemp.m_lngGetStoreRoomName(m_objViewer.m_strStorageID, out strStorageName);
            frmReport.p_strStorageName = strStorageName;
            string m_strBeginDate = Convert.ToDateTime(m_objViewer.m_dtpSearchBeginDate.Text).ToString("yyyy年MM月dd日");
            string m_strEndDate = Convert.ToDateTime(m_objViewer.m_dtpSearchEndDate.Text).ToString("yyyy年MM月dd日");
            if (m_strBeginDate == m_strEndDate)
            {
                frmReport.p_strDate = "入库日期：" + m_strBeginDate ;
            }
            else
            {
                frmReport.p_strDate = "入库日期从：" + m_strBeginDate + "至" + m_strEndDate;
            }
            frmReport.ShowDialog();
        }
        #endregion 打印

        #region 设置药品类型
        /// <summary>
        /// 设置药品类型
        /// </summary>
        /// <param name="p_objMPVO"></param>
        internal void m_mthSetMedicineType(clsMS_MedicineType_VO[] p_objMPVO)
        {
            if (p_objMPVO == null || m_objViewer.m_cboDoseType.Items.Count > 0)
            {
                return;
            }

            clsMS_MedicineType_VO objAll = new clsMS_MedicineType_VO();
            objAll.m_strMedicineTypeID_CHR = "0";
            objAll.m_strMedicineTypeName_VCHR = "全部";

            m_objViewer.m_cboDoseType.Items.Add(objAll);
            m_objViewer.m_cboDoseType.Items.AddRange(p_objMPVO);

            m_objViewer.m_cboDoseType.SelectedIndex = 0;
        }
        #endregion

        #region 获取指定仓库的药品类型
        /// <summary>
        /// 获取指定仓库的药品类型
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_objMTVO">药品制剂类型</param>
        internal void m_mthGetMedicineType(string p_strStorageID, out clsMS_MedicineType_VO[] p_objMTVO)
        {
            long lngRes = m_objDomain.m_mthGetMedicineType(p_strStorageID, out p_objMTVO);
        }
        #endregion

        #region 获取药品字典最小元素集
        /// <summary>
        /// 获取药品字典最小元素集
        /// </summary>
        internal DataTable m_mthGetMedicineInfo()
        {
            DataTable dtbResult;
            clsInventoryRecordSVC objIRDomain = new clsInventoryRecordSVC();
            long lngRes = objIRDomain.m_lngGetBaseMedicine(null,string.Empty, m_objViewer.m_strStorageID, out dtbResult);
            return dtbResult;
        }
        #endregion

        #region 显示药品字典最小元素信息查询窗体
        /// <summary>
        /// 显示药品字典最小元素信息查询窗体
        /// </summary>
        /// <param name="p_strSearchCon">查询条件</param>
        /// <param name="m_dtMedicineInfo">查询结果</param>
        internal void m_mthShowQueryMedicineForm(string p_strSearchCon, DataTable m_dtMedicineInfo)
        {
            if (m_ctlQueryMedicint == null)
            {
                m_ctlQueryMedicint = new ctlQueryMedicintLeastElement(m_dtMedicineInfo);
                m_objViewer.Controls.Add(m_ctlQueryMedicint);

                int X = 0;
                int Y = 0;
                X = m_objViewer.m_txtMedicineName.Location.X;
                Y = m_objViewer.m_txtMedicineName.Location.Y + m_objViewer.m_txtMedicineName.Size.Height*2;

                m_ctlQueryMedicint.Location = new System.Drawing.Point(X, Y);

                m_ctlQueryMedicint.ReturnInfo += new ReturnMedicineInfo(frmQueryForm_ReturnInfo);
            }

            m_ctlQueryMedicint.Visible = true;
            m_ctlQueryMedicint.BringToFront();
            m_ctlQueryMedicint.Focus();
            m_ctlQueryMedicint.m_mthSetSearchText(p_strSearchCon);
        }

        internal void frmQueryForm_ReturnInfo(com.digitalwave.iCare.ValueObject.clsMS_MedicintLeastElement_VO MS_VO)
        {
            if (MS_VO == null)
            {
                return;
            }
            m_objViewer.m_txtMedicineName.Tag = MS_VO.m_strMedicineID;
            m_objViewer.m_txtMedicineName.Text = MS_VO.m_strMedicineName;
        }
        #endregion

        #region 供应商查询
        /// <summary>
        /// 显示供应商查询
        /// </summary>
        /// <param name="p_strSearchCon">查询条件</param>
        internal void m_mthShowVendor(string p_strSearchCon)
        {
            if (m_ctlQueryVendor == null)
            {
                m_mthGetVendor(out m_dtbVendor);

                m_ctlQueryVendor = new ctlQueryVendor(m_dtbVendor);
                m_objViewer.Controls.Add(m_ctlQueryVendor);

                int X = m_objViewer.m_txtProviderName.Location.X;
                int Y = m_objViewer.m_txtProviderName.Location.Y + m_objViewer.m_txtProviderName.Size.Height*2;

                m_ctlQueryVendor.Location = new System.Drawing.Point(X, Y);
                m_ctlQueryVendor.ReturnInfo += new ReturnVendorInfo(QueryVendor_ReturnInfo);
            }
            m_ctlQueryVendor.BringToFront();
            m_ctlQueryVendor.m_mthSetSearchText(p_strSearchCon);
            m_ctlQueryVendor.Visible = true;
            m_ctlQueryVendor.Focus();
        }

        internal void QueryVendor_ReturnInfo(com.digitalwave.iCare.ValueObject.clsMS_Vendor MS_VO)
        {
            m_objViewer.m_txtProviderName.Tag = null;
            if (MS_VO == null)
            {
                return;
            }

            m_objViewer.m_txtProviderName.Tag = MS_VO.m_strVendorID;
            m_objViewer.m_txtProviderName.Text = MS_VO.m_strVendorName;
            m_objViewer.m_txtMedicineName.Focus();
        }

        /// <summary>
        /// 获取供应商信息
        /// </summary>
        /// <param name="p_dtbVendor"></param>
        internal void m_mthGetVendor(out DataTable p_dtbVendor)
        {
            clsDcl_InStorageStatisticsReport objIRDomain = new clsDcl_InStorageStatisticsReport();
            long lngRes = objIRDomain.m_lngGetVendor(out p_dtbVendor);
        }
        #endregion
    }
}
