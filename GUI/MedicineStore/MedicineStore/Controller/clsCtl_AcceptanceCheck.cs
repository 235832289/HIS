using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    /// <summary>
    /// 药品验收情况
    /// </summary>
    public class clsCtl_AcceptanceCheck : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 全局变量
        /// <summary>
        /// 窗体
        /// </summary>
        private com.digitalwave.iCare.gui.MedicineStore.frmAcceptanceCheck m_objViewer;
        /// <summary>
        /// 查询供应商控件
        /// </summary>
        private ctlQueryVendor m_ctlQueryVendor = null;
        /// <summary>
        /// 查询员工控件
        /// </summary>
        private ctlQueryEmployee m_ctlEMP = null;
        /// <summary>
        /// 供应商
        /// </summary>
        private DataTable m_dtbVendor = null; 
        #endregion

        #region 构造函数

        public clsCtl_AcceptanceCheck()
        {
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
            m_objViewer = (frmAcceptanceCheck)frmMDI_Child_Base_in;
        }
        #endregion

        #region 设置员工至列表
        /// <summary>
        /// 设置员工至列表
        /// </summary>
        /// <param name="p_strSearch">搜索字符串</param>
        /// <param name="p_txtEmp">员工控件</param>
        internal void m_mthSetEmpToList(string p_strSearch, TextBox p_txtEmp)
        {
            DataTable dtbEmp = null;
            clsDcl_Purchase_Detail objDomain = new clsDcl_Purchase_Detail();
            long lngRes = objDomain.m_lngGetEMP(p_strSearch, out dtbEmp);

            if (dtbEmp == null || dtbEmp.Rows.Count == 0)
            {
                p_txtEmp.Tag = null;
            }

            if (m_ctlEMP == null)
            {
                m_ctlEMP = new ctlQueryEmployee();
                m_objViewer.Controls.Add(m_ctlEMP);
            }
            m_ctlEMP.m_mthSetTxtBase(p_txtEmp);
            m_ctlEMP.BringToFront();
            int X = p_txtEmp.Location.X;
            int Y = p_txtEmp.Location.Y - m_ctlEMP.Size.Height;

            if (Y < 0)
            {
                Y = 0;
            }

            m_ctlEMP.Location = new System.Drawing.Point(X, Y);

            m_ctlEMP.Size = new System.Drawing.Size(p_txtEmp.Size.Width, m_objViewer.m_txtExamerID.Location.Y - Y);
            m_ctlEMP.ReturnInfo += new ReturnEmpInfo(m_ctlEMP_ReturnInfo);

            try
            {
                int intRowCount = dtbEmp.Rows.Count;
                DataRow drCurrent = null;
                List<ListViewItem> lstItems = new List<ListViewItem>();
                for (int iRow = 0; iRow < intRowCount; iRow++)
                {
                    drCurrent = dtbEmp.Rows[iRow];
                    ListViewItem lsi = new ListViewItem(drCurrent["EMPNO_CHR"].ToString());
                    lsi.SubItems.Add(drCurrent["LASTNAME_VCHR"].ToString());
                    lsi.Tag = drCurrent;
                    lstItems.Add(lsi);
                }
                m_ctlEMP.AddRange(lstItems.ToArray());
                if (lstItems.Count == 0)
                {
                    p_txtEmp.Tag = null;
                }
                m_ctlEMP.Visible = true;
                m_ctlEMP.Focus();
            }
            catch (Exception Ex)
            {
                string strEx = Ex.Message;
            }
        }

        private void m_ctlEMP_ReturnInfo(DataRow DR_EMP, TextBox Sender)
        {
            Sender.Tag = null;
            if (DR_EMP != null)
            {
                Sender.Tag = DR_EMP["EMPID_CHR"].ToString();
                Sender.Text = DR_EMP["LASTNAME_VCHR"].ToString();
            }

            if (Sender.Name == "m_txtExamerID")
            {
                m_objViewer.m_cmdOK.Focus();
            }
        }
        #endregion

        #region 显示供应商查询

        /// <summary>
        /// 获取供应商信息
        /// </summary>
        /// <param name="p_dtbVendor"></param>
        internal void m_mthGetVendor(out DataTable p_dtbVendor)
        {
            clsDcl_InventoryRecord objIRDomain = new clsDcl_InventoryRecord();
            long lngRes = objIRDomain.m_lngGetVendor(out p_dtbVendor);
        }
        /// <summary>
        /// 显示供应商查询
        /// </summary>
        /// <param name="p_strSearchCon">查询条件</param>
        internal void m_mthShowVendor(string p_strSearchCon)
        {
            if (m_ctlQueryVendor == null)
            {
                if (m_objViewer.m_dtbVendor == null)
                {
                    m_mthGetVendor(out m_objViewer.m_dtbVendor);
                }
                m_dtbVendor = m_objViewer.m_dtbVendor;
                m_ctlQueryVendor = new ctlQueryVendor(m_dtbVendor);
                m_objViewer.Controls.Add(m_ctlQueryVendor);
            }

            int X = m_objViewer.m_txtBidCompany.Location.X - (m_objViewer.m_txtBidCompany.Location.X + m_ctlQueryVendor.Size.Width - m_objViewer.Size.Width);
            int Y = m_objViewer.m_txtBidCompany.Location.Y + m_objViewer.m_txtBidCompany.Size.Height;

            m_ctlQueryVendor.Location = new System.Drawing.Point(X, Y);

            m_ctlQueryVendor.Size = new System.Drawing.Size(m_ctlQueryVendor.Size.Width, 
                m_ctlQueryVendor.Size.Height - (Y + m_ctlQueryVendor.Size.Height - m_objViewer.Size.Height));

            m_ctlQueryVendor.ReturnInfo += new ReturnVendorInfo(QueryVendor_ReturnInfo);
            m_ctlQueryVendor.BringToFront();
            m_ctlQueryVendor.m_mthSetSearchText(p_strSearchCon);
            m_ctlQueryVendor.Visible = true;
            m_ctlQueryVendor.Focus();
        }

        internal void QueryVendor_ReturnInfo(com.digitalwave.iCare.ValueObject.clsMS_Vendor MS_VO)
        {
            m_objViewer.m_txtBidCompany.Tag = null;
            if (MS_VO == null)
            {
                return;
            }

            m_objViewer.m_txtBidCompany.Tag = MS_VO.m_strVendorID;
            m_objViewer.m_txtBidCompany.Text = MS_VO.m_strVendorName;

            m_objViewer.m_txtApproveCode.Focus();
        }
        #endregion

        #region 获取验货情况
        /// <summary>
        /// 获取验货情况
        /// </summary>
        /// <returns></returns>
        internal clsMS_AcceptanceCheck_VO m_objGetCurrentVO()
        {
            clsMS_AcceptanceCheck_VO objAC = new clsMS_AcceptanceCheck_VO();
            if (m_objViewer.m_cboApparentQuality.SelectedIndex < 0)
            {
                MessageBox.Show("请选择外观质量情况","药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            objAC.m_intApparentQuality = m_objViewer.m_cboApparentQuality.SelectedIndex;
            if (m_objViewer.m_cboBid.SelectedIndex < 0)
            {
                MessageBox.Show("请选择是否中标", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            objAC.m_intBid = m_objViewer.m_cboBid.SelectedIndex;
            if (m_objViewer.m_cboExamResult.SelectedIndex < 0)
            {
                MessageBox.Show("请选择验收结论", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            objAC.m_intExamResult = m_objViewer.m_cboExamResult.SelectedIndex;
            if (m_objViewer.m_cboPackQuality.SelectedIndex < 0)
            {
                 MessageBox.Show("请选择包装质量", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            objAC.m_intPackQuality = m_objViewer.m_cboPackQuality.SelectedIndex;
            if (m_objViewer.m_txtExamerID.Tag == null)
            {
                MessageBox.Show("验货员不能为空", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            objAC.m_strExamerID = m_objViewer.m_txtExamerID.Tag.ToString();
            objAC.m_strExamerName = m_objViewer.m_txtExamerID.Text;
            if (m_objViewer.m_txtBidCompany.Tag != null)
            {
                objAC.m_strBidCompany = m_objViewer.m_txtBidCompany.Tag.ToString();
            }
            objAC.m_strBidCompanyName = m_objViewer.m_txtBidCompany.Text;
            objAC.m_strApproveCode = m_objViewer.m_txtApproveCode.Text;
            objAC.m_intGMPFlag = m_objViewer.cobGMP.SelectedIndex;
            objAC.m_strTrademark = m_objViewer.txtTrade.Text;
            return objAC;
        } 
        #endregion

        #region 获取最近一次的中标单位及批准文号
        /// <summary>
        /// 获取最近一次的中标单位及批准文号
        /// </summary>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strLotNO">批准文号</param>
        /// <param name="p_strBidCompanyID">中标单位</param>
        /// <returns></returns>
        internal void m_mthGetLatestBidCompany(string p_strMedicineID, out string p_strLotNO, out string p_strBidCompanyID)
        {
            clsDcl_Purchase_Detail objDomain = new clsDcl_Purchase_Detail();
            long lngRes = objDomain.m_lngGetLatestBidCompany(p_strMedicineID, out p_strLotNO, out p_strBidCompanyID);
        }
        #endregion

        #region 设置默认值
        /// <summary>
        /// 设置默认值
        /// </summary>
        /// <param name="p_strLotNO">批准文号</param>
        /// <param name="p_strBidCompanyID">中标单位</param>
        internal void m_mthSetDefault(string p_strLotNO, string p_strBidCompanyID)
        {
            if (p_strLotNO == null || p_strBidCompanyID == null)
            {
                return;
            }

            if (m_objViewer.m_dtbVendor == null)
            {
                m_mthGetVendor(out m_objViewer.m_dtbVendor);
            }

            if (m_objViewer.m_dtbVendor != null)
            {
                DataRow[] drRows = m_objViewer.m_dtbVendor.Select("ID = '" + p_strBidCompanyID + "'");

                if (drRows != null && drRows.Length > 0)
                {
                    m_objViewer.m_txtBidCompany.Tag = p_strBidCompanyID;
                    m_objViewer.m_txtBidCompany.Text = drRows[0]["name"].ToString();
                }
            }
            m_objViewer.m_txtApproveCode.Text = p_strLotNO;
        } 
        #endregion
    }
}
