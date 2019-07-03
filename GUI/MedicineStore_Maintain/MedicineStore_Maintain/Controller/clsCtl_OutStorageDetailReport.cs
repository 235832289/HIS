using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.digitalwave.iCare.gui.MedicineStore;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 出库明细报表
    /// </summary>
    public class clsCtl_OutStorageDetailReport : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 全局变量

        /// <summary>
        /// 模块控制类
        /// </summary>
        private clsDcl_OutStorageDetailReport m_objDomain = null;

        /// <summary>
        /// 窗体
        /// </summary>
        private com.digitalwave.iCare.gui.MedicineStore_Maintain.frmOutStorageDetailReport m_objViewer;
        /// <summary>
        /// 药品查询控件
        /// </summary>
        private ctlQueryMedicintLeastElement m_ctlQueryMedicint = null;

        #endregion

        #region 构造函数

        /// <summary>
        /// 出库明细报表
        /// </summary>
        public clsCtl_OutStorageDetailReport()
        {
            m_objDomain = new clsDcl_OutStorageDetailReport();
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
            m_objViewer = (frmOutStorageDetailReport)frmMDI_Child_Base_in;
        }
        #endregion

        #region 获取领用部门信息
        /// <summary>
        /// 获取领用部门信息
        /// </summary>
        /// <param name="p_dtbExportDept"></param>
        internal void m_mthGetExportDept(out DataTable p_dtbExportDept)
        {
            long lngRes = m_objDomain.m_lngGetExportDept(out p_dtbExportDept);
        } 
        #endregion

        #region 获取药品字典最小元素集
        /// <summary>
        /// 获取药品字典最小元素集
        /// </summary>
        internal void m_mthGetMedicineInfo()
        {
            long lngRes = m_objDomain.m_lngGetBaseMedicine(string.Empty, m_objViewer.m_strStorageID, out m_objViewer.m_dtbMedicinDict);
        }
        #endregion

        #region 显示药品字典最小元素信息查询窗体


        /// <summary>
        /// 显示药品字典最小元素信息查询窗体
        /// </summary>
        /// <param name="p_strSearchCon">查询条件</param>
        internal void m_mthShowQueryMedicineForm(string p_strSearchCon)
        {
            if (m_ctlQueryMedicint == null)
            {

                m_ctlQueryMedicint = new ctlQueryMedicintLeastElement(m_objViewer.m_dtbMedicinDict);
                m_objViewer.Controls.Add(m_ctlQueryMedicint);

                int X = m_objViewer.m_txtMedicineCode.Location.X - (m_ctlQueryMedicint.Size.Width - m_objViewer.m_txtMedicineCode.Size.Width);
                int Y = m_objViewer.m_txtMedicineCode.Location.Y + m_objViewer.m_txtMedicineCode.Size.Height;

                m_ctlQueryMedicint.Location = new System.Drawing.Point(X, Y);

                m_ctlQueryMedicint.ReturnInfo += new ReturnMedicineInfo(frmQueryForm_ReturnInfo);
                m_ctlQueryMedicint.CancelResult += new MecicineCancelAndReturn(m_ctlQueryMedicint_CancelResult);
            }

            m_ctlQueryMedicint.Visible = true;
            m_ctlQueryMedicint.BringToFront();
            m_ctlQueryMedicint.Focus();
            m_ctlQueryMedicint.m_mthSetSearchText(p_strSearchCon);
        }

        internal void m_ctlQueryMedicint_CancelResult()
        {
            m_objViewer.m_txtMedicineCode.Focus();
        }

        internal void frmQueryForm_ReturnInfo(com.digitalwave.iCare.ValueObject.clsMS_MedicintLeastElement_VO MS_VO)
        {
            if (MS_VO == null)
            {
                return;
            }

            m_objViewer.m_txtMedicineCode.Tag = MS_VO.m_strMedicineID;
            m_objViewer.m_txtMedicineCode.Text = MS_VO.m_strMedicineName;

            m_objViewer.m_cmdSearch.Focus();
        }
        #endregion

        #region 获取报表
        /// <summary>
        /// 获取报表
        /// </summary>
        internal void m_mthGetReport()
        {
            DateTime  dtmBegin = DateTime.Parse(Convert.ToDateTime(m_objViewer.m_dtpSearchBeginDate.Text).ToString("yyyy-MM-dd 00:00:00"));
            DateTime dtmEnd = DateTime.Parse(Convert.ToDateTime(m_objViewer.m_dtpSearchEndDate.Text).ToString("yyyy-MM-dd 23:59:59"));

            if (dtmBegin.Date > dtmEnd.Date)
            {
                MessageBox.Show("查询开始时间不能超过结束时间","出库明细报表",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            bool blnHasDept = true;//是否查询科室
            if (string.IsNullOrEmpty(m_objViewer.m_txtExportDept.Text.Trim()) || string.IsNullOrEmpty(m_objViewer.m_txtExportDept.StrItemId))
            {
                blnHasDept = false;
            }

            bool blnHasMedicine = true;//是否查询药品
            if (string.IsNullOrEmpty(m_objViewer.m_txtMedicineCode.Text.Trim()) || m_objViewer.m_txtMedicineCode.Tag == null)
            {
                blnHasMedicine = false;
            }

            DataTable dtbReport = null;
            long lngRes = 0;
            if (blnHasMedicine && blnHasDept)
            {
                DataTable dtbIn = null;//内退
                lngRes = m_objDomain.m_lngOutStorageDetailReport_Dept_Med(m_objViewer.m_strStorageID, m_objViewer.m_txtExportDept.StrItemId, m_objViewer.m_txtMedicineCode.Tag.ToString(),
                    dtmBegin, dtmEnd, out dtbReport);
                if (lngRes < 0)
                {
                    MessageBox.Show("获取报表内容失败", "出库明细报表", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (m_objViewer.m_chkGetIn.Checked)
                {

                    lngRes = m_objDomain.m_lngOutReportGetWithinWithdrawal_Dept_Med(m_objViewer.m_strStorageID, m_objViewer.m_txtExportDept.StrItemId, m_objViewer.m_txtMedicineCode.Tag.ToString(),
                        dtmBegin, dtmEnd, out dtbIn);
                    if (lngRes < 0)
                    {
                        MessageBox.Show("获取报表内容失败", "出库明细报表", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    dtbReport.Merge(dtbIn, true);
                    DataView dtvResult = new DataView(dtbReport);
                    dtvResult.Sort = "deptid_chr,prodate";
                    dtbReport = dtvResult.ToTable();


                }
            }
            else if (blnHasMedicine)
            {
                DataTable dtbIn = null;//内退
                lngRes = m_objDomain.m_lngOutStorageDetailReport_Med(m_objViewer.m_strStorageID, m_objViewer.m_txtMedicineCode.Tag.ToString(), dtmBegin, dtmEnd, out dtbReport);
                if (lngRes < 0)
                {
                    MessageBox.Show("获取报表内容失败", "出库明细报表", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (m_objViewer.m_chkGetIn.Checked)
                {
                    lngRes = m_objDomain.m_lngOutReportGetWithinWithdrawal_Med(m_objViewer.m_strStorageID, m_objViewer.m_txtMedicineCode.Tag.ToString(), dtmBegin, dtmEnd, out dtbIn);
                    if (lngRes < 0)
                    {
                        MessageBox.Show("获取报表内容失败", "出库明细报表", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    dtbReport.Merge(dtbIn, true);
                    DataView dtvResult = new DataView(dtbReport);
                    dtvResult.Sort = "deptid_chr,prodate";
                    dtbReport = dtvResult.ToTable();
                }
            }
            else if (blnHasDept)
            {
                DataTable dtbIn = null;//内退
                lngRes = m_objDomain.m_lngOutStorageDetailReport_Dept(m_objViewer.m_strStorageID, m_objViewer.m_txtExportDept.StrItemId, dtmBegin, dtmEnd, out dtbReport);
                if (lngRes < 0)
                {
                    MessageBox.Show("获取报表内容失败", "出库明细报表", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (m_objViewer.m_chkGetIn.Checked)
                {
                    lngRes = m_objDomain.m_lngOutReportGetWithinWithdrawal_Dept(m_objViewer.m_strStorageID, m_objViewer.m_txtExportDept.StrItemId, dtmBegin, dtmEnd, out dtbIn);
                    if (lngRes < 0)
                    {
                        MessageBox.Show("获取报表内容失败", "出库明细报表", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    dtbReport.Merge(dtbIn, true);
                    DataView dtvResult = new DataView(dtbReport);
                    dtvResult.Sort = "deptid_chr,prodate";
                    dtbReport = dtvResult.ToTable();
                }
            }
            else
            {
                DataTable dtbIn = null;//内退
                lngRes = m_objDomain.m_lngOutStorageDetailReport(m_objViewer.m_strStorageID, dtmBegin, dtmEnd, out dtbReport);
                if (lngRes < 0)
                {
                    MessageBox.Show("获取报表内容失败", "出库明细报表", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (m_objViewer.m_chkGetIn.Checked)
                {
                    lngRes = m_objDomain.m_lngOutReportGetWithinWithdrawal(m_objViewer.m_strStorageID, dtmBegin, dtmEnd, out dtbIn);
                    if (lngRes < 0)
                    {
                        MessageBox.Show("获取报表内容失败", "出库明细报表", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    dtbReport.Merge(dtbIn, true);
                    DataView dtvResult = new DataView(dtbReport);
                    dtvResult.Sort = "deptid_chr,prodate";
                    dtbReport = dtvResult.ToTable();
                }
            }

            m_objViewer.datWindow.LibraryList = clsPublic.PBLPath;
            string strRoomName;
            m_objDomain.m_lngGetStoreRoomName(m_objViewer.m_strStorageID, out strRoomName);
           // m_objViewer.datWindow.Modify("statedate.text='" + m_objViewer.m_dtpSearchBeginDate.Text + " ~ " + m_objViewer.m_dtpSearchEndDate.Text + "'");
          //  m_objViewer.datWindow.Modify("title_t_1.text='出库统计报表(" + strRoomName + ")'");
            
            m_objViewer.datWindow.SetRedrawOff();
            m_objViewer.datWindow.Retrieve(dtbReport);
            m_objViewer.datWindow.SetRedrawOn();
            m_objViewer.datWindow.Refresh();
        } 
        #endregion

        
    }
}
