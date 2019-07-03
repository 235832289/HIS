using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.digitalwave.iCare.gui.MedicineStore;
using System.Windows.Forms;
using ControlLibrary;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 出库明细报表
    /// </summary>
    public class clsCtl_OutStorageDetailReport2 : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 全局变量

        /// <summary>
        /// 模块控制类
        /// </summary>
        private clsDcl_OutStorageDetailReport2 m_objDomain = null;

        /// <summary>
        /// 窗体
        /// </summary>
        private com.digitalwave.iCare.gui.MedicineStore_Maintain.frmOutStorageDetailReport2 m_objViewer;
        /// <summary>
        /// 药品查询控件
        /// </summary>
        private ctlQueryMedicintLeastElement m_ctlQueryMedicint = null;

        #endregion

        #region 构造函数

        /// <summary>
        /// 出库明细报表
        /// </summary>
        public clsCtl_OutStorageDetailReport2()
        {
            m_objDomain = new clsDcl_OutStorageDetailReport2();
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
            m_objViewer = (frmOutStorageDetailReport2)frmMDI_Child_Base_in;
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
            long lngRes = m_objDomain.m_lngGetBaseMedicine(m_objViewer.m_blnGY3Y_DS,true,string.Empty, m_objViewer.m_strStorageID, out m_objViewer.m_dtbMedicinDict);
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

                int X = m_objViewer.m_txtMedicineCode.Location.X;// -m_ctlQueryMedicint.Size.Width + m_objViewer.m_txtMedicineCode.Size.Width;
                int Y = m_objViewer.m_txtMedicineCode.Location.Y + m_objViewer.m_txtMedicineCode.Size.Height;

                m_ctlQueryMedicint.Location = new System.Drawing.Point(X, Y);

                m_ctlQueryMedicint.ReturnInfo += new ReturnMedicineInfo(frmQueryForm_ReturnInfo);
                m_ctlQueryMedicint.CancelResult += new MecicineCancelAndReturn(m_ctlQueryMedicint_CancelResult);
                m_ctlQueryMedicint.RefreshMedicine += new RefreshMedicineInfo(m_ctlQueryMedicint_RefreshMedicine);
            }

            m_ctlQueryMedicint.Visible = true;
            m_ctlQueryMedicint.BringToFront();
            m_ctlQueryMedicint.Focus();
            m_ctlQueryMedicint.m_mthSetSearchText(p_strSearchCon);
        }

        private void m_ctlQueryMedicint_RefreshMedicine()
        {
            m_mthGetMedicineInfo();
            m_ctlQueryMedicint.m_dtbMedicineInfo = m_objViewer.m_dtbMedicinDict;
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

            if (m_objViewer.m_rbtSingle.Checked)
            {
                m_objViewer.m_txtMedicineCode.Text = MS_VO.m_strMedicineName;
            }
            else
            {
                m_objViewer.m_txtMedicineCode.Text = MS_VO.m_strMedicineCode;
            }
            m_objViewer.m_txtMedicineCode.Tag = MS_VO.m_strMedicineID;
            
        }
        #endregion

        #region 获取报表
        /// <summary>
        /// 获取报表
        /// </summary>
        internal void m_mthGetReport()
        {
            //DateTime  dtmBegin = DateTime.Parse(Convert.ToDateTime(m_objViewer.m_dtpSearchBeginDate.Text).ToString("yyyy-MM-dd HH:mm:ss"));
            //DateTime dtmEnd = DateTime.Parse(Convert.ToDateTime(m_objViewer.m_dtpSearchEndDate.Text).ToString("yyyy-MM-dd HH:mm:ss"));
            DateTime dtmBegin, dtmEnd;
            if (!DateTime.TryParse(m_objViewer.m_dtpSearchBeginDate.Text, out dtmBegin))
            {
                MessageBox.Show("请输入查询开始时间", "出库明细报表", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!DateTime.TryParse(m_objViewer.m_dtpSearchEndDate.Text, out dtmEnd))
            {
                MessageBox.Show("请输入查询结束时间", "出库明细报表", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dtmBegin > dtmEnd)
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

            DataTable dt = new DataTable();
            dt.Columns.Add("deptname_vchr", typeof(String));
            dt.Columns.Add("assistcode_chr", typeof(String));
            dt.Columns.Add("medicinename_vchr", typeof(String));
            dt.Columns.Add("medspec_vchr", typeof(String));
            dt.Columns.Add("netamount_int", typeof(Double));
            dt.Columns.Add("opunit_chr", typeof(String));
            dt.Columns.Add("retailprice_int", typeof(Double));
            dt.Columns.Add("allretailprice", typeof(Double));

            DataRow drTemp1 = null;
            DataRow drTemp2 = null;
            double dblAmount = 0d;
            double dblRetailprice = 0d;
            int intRowsCount = dtbReport.Rows.Count;
            drTemp1 = dt.NewRow();
            for (int i1 = 0; i1 < intRowsCount; i1++)
            {
                drTemp2 = dtbReport.Rows[i1];
                double.TryParse(Convert.ToString(drTemp2["netamount_int"]), out dblAmount);
                double.TryParse(Convert.ToString(drTemp2["retailprice_int"]), out dblRetailprice);

                drTemp1["deptname_vchr"] = drTemp2["deptname_vchr"];
                drTemp1["assistcode_chr"] = drTemp2["assistcode_chr"];
                drTemp1["medicinename_vchr"] = drTemp2["medicinename_vchr"];
                drTemp1["medspec_vchr"] = drTemp2["medspec_vchr"];
                drTemp1["netamount_int"] = dblAmount;
                drTemp1["opunit_chr"] = drTemp2["opunit_chr"];
                drTemp1["retailprice_int"] = dblRetailprice;
                drTemp1["allretailprice"] = dblAmount * dblRetailprice;
                dt.Rows.Add(drTemp1.ItemArray);
            }
            dt.AcceptChanges();
            drTemp1 = null;
            drTemp2 = null;

            //this.m_objViewer.m_dgvOutStorageDetailRpt.DataSource = dt;

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


        /// <summary>
        /// 药库使用的查询出库药品详细记录
        /// </summary>
        internal void m_mthGetReportNew()
        {
            //DateTime m_dtmBegin = DateTime.Parse(Convert.ToDateTime(m_objViewer.m_dtpSearchBeginDate.Text).ToString("yyyy-MM-dd HH:mm:ss"));
            //DateTime m_dtmEnd = DateTime.Parse(Convert.ToDateTime(m_objViewer.m_dtpSearchEndDate.Text).ToString("yyyy-MM-dd HH:mm:ss"));
            DateTime m_dtmBegin, m_dtmEnd;
            if (!DateTime.TryParse(m_objViewer.m_dtpSearchBeginDate.Text, out m_dtmBegin))
            {
                MessageBox.Show("请输入查询开始时间", "出库明细报表", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!DateTime.TryParse(m_objViewer.m_dtpSearchEndDate.Text, out m_dtmEnd))
            {
                MessageBox.Show("请输入查询结束时间", "出库明细报表", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (m_dtmBegin.Date > m_dtmEnd.Date)
            {
                MessageBox.Show("查询开始时间不能超过结束时间", "出库明细报表", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string p_strMedicineID = string.Empty;
            if (m_objViewer.m_rbtSingle.Checked)
                p_strMedicineID = Convert.ToString(m_objViewer.m_txtMedicineCode.Tag);
            else
                p_strMedicineID = m_objViewer.m_txtMedicineCode.Text;

            string strMedTypeCode = "";
            if (!string.IsNullOrEmpty(this.m_objViewer.txtTypecode.Value))
            {
                strMedTypeCode = this.m_objViewer.txtTypecode.Value.ToString();
            }

            DataTable m_dtbReport = null;
            long lngRes = 0;

            lngRes = m_objDomain.m_lngGetOutstorageDetailReport(m_objViewer.m_rbtCombine.Checked, m_objViewer.m_strStorageID, m_dtmBegin, m_dtmEnd, m_objViewer.m_txtExportDept.StrItemId, p_strMedicineID,
                m_objViewer.m_cboType.SelectedValue.ToString(), strMedTypeCode,out m_dtbReport);
            if (lngRes < 0)
            {
                MessageBox.Show("获取报表内容失败", "出库明细报表", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable m_dtbReport2 = new DataTable();
            m_dtbReport2 = m_dtbReport.Clone();
            m_dtbReport2.Merge(m_dtbReport);
            m_dtbReport2.AcceptChanges();

            DataView dv = new DataView(m_dtbReport);
            dv.Sort = "deptid_chr asc";
            m_dtbReport = dv.ToTable();
            DataRow dr1 = null;
            DataRow dr2 = null;
            int iRowCount = m_dtbReport.Rows.Count;
            for (int i1 = 1; i1 < iRowCount; i1++)
            {
                dr1 = m_dtbReport.Rows[i1];
                dr2 = m_dtbReport.Rows[i1 - 1];
                if (dr1["deptid_chr"].ToString().Trim() == dr2["deptid_chr"].ToString().Trim() && i1 % 27 != 0) //20080730 每一页都要显示领用部门        
                {
                    dr1["deptname_vchr"] = "";
                }
            }

            this.m_objViewer.m_dgvOutstorageDetail.DataSource = m_dtbReport2;

            double dblRetailPrice = 0d;
            double dblPriceSum = 0d;
            int iRCount = m_dtbReport2.Rows.Count;
            DataRow drTemp = null;
            for (int i = 0; i < iRCount; i++)
            {
                drTemp = m_dtbReport2.Rows[i];
                double.TryParse(Convert.ToString(drTemp["retailsum"]), out dblRetailPrice);
                dblPriceSum += dblRetailPrice;
            }
            this.m_objViewer.m_lblPriceSum.Text = dblPriceSum.ToString("#,##0.0000") + "元";
            drTemp = null;
            string strDeptName = "";
            if (this.m_objViewer.m_txtExportDept.Text.Trim() == "")
            {
                strDeptName = "全部";
            }
            else
            {
                strDeptName = this.m_objViewer.m_txtExportDept.Text.Trim();
            }
            
            m_objViewer.datWindow.Modify("storagename.text='" + "(" + m_objViewer.m_strStorageName + ")" + "'");
            m_objViewer.datWindow.Modify("t_outtype.text='" + "(" + this.m_objViewer.m_cboType.Text.Trim() + ")" + "'");
            m_objViewer.datWindow.Modify("t_deptname.text='领用部门：" + strDeptName + "'");
            m_objViewer.datWindow.Modify("begindate.text='" + m_objViewer.m_dtpSearchBeginDate.Text + " --- " + m_objViewer.m_dtpSearchEndDate.Text + "'");
            //m_objViewer.datWindow.Modify("enddate.text='" + m_objViewer.m_dtpSearchEndDate.Text + "'");
            m_dtbReport.Columns.Remove("comment_vchr");
            m_dtbReport.AcceptChanges();
            m_objViewer.datWindow.SetRedrawOff();
            m_objViewer.datWindow.Retrieve(m_dtbReport);
            m_objViewer.datWindow.SetRedrawOn();
            m_objViewer.datWindow.Refresh();

            if (!m_dtbReport2.Columns.Contains("SortRowNo"))
            {
                m_dtbReport2.Columns.Add("SortRowNo", typeof(long));
            }
            m_mthAddTotalSumRow(m_dtbReport2);
        }

        internal void m_mthAddTotalSumRow(DataTable p_dtbResult)
        {
            if (p_dtbResult.Rows.Count > 0)
            {
                double dblTempSum = 0d;
                DataRow drAdd = p_dtbResult.NewRow();
                for (int i1 = 0; i1 < p_dtbResult.Columns.Count; i1++)
                {
                    dblTempSum = 0d;
                    if (p_dtbResult.Columns[i1].ColumnName.ToLower() == "deptname_vchr")
                    {
                        drAdd[i1] = "合计";
                    }
                    else if (p_dtbResult.Columns[i1].ColumnName.ToLower() == "retailsum" || (p_dtbResult.Columns[i1].ColumnName.ToLower() == "netamount_int" && m_objViewer.m_txtMedicineCode.Tag != null && m_objViewer.m_txtMedicineCode.Tag.ToString().Length > 0))
                    {
                        for (int i2 = 0; i2 < p_dtbResult.Rows.Count; i2++)
                        {
                            dblTempSum += Convert.ToDouble(p_dtbResult.Rows[i2][i1]);
                        }
                        drAdd[i1] = dblTempSum;
                    }
                }
                p_dtbResult.Rows.Add(drAdd);
                p_dtbResult.AcceptChanges();
            }
        }

        /// <summary>
        /// 药房使用的查询出库药品详细记录
        /// </summary>
        internal void m_mthGetReportForDrugStore()
        {
            //DateTime m_dtmBegin = DateTime.Parse(Convert.ToDateTime(m_objViewer.m_dtpSearchBeginDate.Text).ToString("yyyy-MM-dd HH:mm:ss"));
            //DateTime m_dtmEnd = DateTime.Parse(Convert.ToDateTime(m_objViewer.m_dtpSearchEndDate.Text).ToString("yyyy-MM-dd HH:mm:ss"));
            DateTime m_dtmBegin, m_dtmEnd;
            if (!DateTime.TryParse(m_objViewer.m_dtpSearchBeginDate.Text, out m_dtmBegin))
            {
                MessageBox.Show("请输入查询开始时间", "出库明细报表", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!DateTime.TryParse(m_objViewer.m_dtpSearchEndDate.Text, out m_dtmEnd))
            {
                MessageBox.Show("请输入查询结束时间", "出库明细报表", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (m_dtmBegin.Date > m_dtmEnd.Date)
            {
                MessageBox.Show("查询开始时间不能超过结束时间", "出库明细报表", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string p_strMedicineID = string.Empty;
            if (m_objViewer.m_rbtSingle.Checked)
                p_strMedicineID = Convert.ToString(m_objViewer.m_txtMedicineCode.Tag);
            else
                p_strMedicineID = m_objViewer.m_txtMedicineCode.Text;

            string strMedTypeCode = "";
            if (!string.IsNullOrEmpty(this.m_objViewer.txtTypecode.Value))
            {
                strMedTypeCode = this.m_objViewer.txtTypecode.Value.ToString();
            }

            DataTable m_dtbReport = null;
            long lngRes = 0;
            lngRes = m_objDomain.m_lngGetOutstorageDetailReportForDrugStore(m_objViewer.m_rbtCombine.Checked,m_objViewer.m_strDeptID, m_dtmBegin, m_dtmEnd, m_objViewer.m_txtExportDept.StrItemId, p_strMedicineID,
                m_objViewer.m_cboType.SelectedValue.ToString(), strMedTypeCode,m_objViewer.m_blnIsHospital,out m_dtbReport);
            if (lngRes < 0)
            {
                MessageBox.Show("获取报表内容失败", "出库明细报表", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable m_dtbReport2 = new DataTable();
            m_dtbReport2 = m_dtbReport.Clone();
            m_dtbReport2.Merge(m_dtbReport);
            m_dtbReport2.AcceptChanges();

            DataView dv2 = new DataView(m_dtbReport2);
            dv2.Sort = "deptid_chr asc";
            m_dtbReport2 = dv2.ToTable();
            dv2 = null;

            DataView dv = new DataView(m_dtbReport);
            dv.Sort = "deptid_chr asc";
            m_dtbReport = dv.ToTable();
            dv = null;
            DataRow dr1 = null;
            DataRow dr2 = null;
            int iRowCount = m_dtbReport.Rows.Count;
            for (int i1 = 1; i1 < iRowCount; i1++)
            {
                dr1 = m_dtbReport.Rows[i1];
                dr2 = m_dtbReport.Rows[i1 - 1];
                if (dr1["deptid_chr"].ToString().Trim() == dr2["deptid_chr"].ToString().Trim() && i1 % 27 != 0)
                {
                    dr1["deptname_vchr"] = "";
                }
            }
            

            this.m_objViewer.m_dgvOutstorageDetail.DataSource = m_dtbReport2;

            double dblRetailPrice = 0d;
            double dblPriceSum = 0d;
            int iCount = m_dtbReport2.Rows.Count;
            DataRow drTemp = null;
            for (int i = 0; i < iCount; i++)
            {
                drTemp = m_dtbReport2.Rows[i];
                double.TryParse(Convert.ToString(drTemp["retailsum"]), out dblRetailPrice);
                dblPriceSum += Convert.ToDouble(dblRetailPrice.ToString("0.0000"));
            }
            this.m_objViewer.m_lblPriceSum.Text = dblPriceSum.ToString("#,##0.0000") + "元";
            drTemp = null;
            string strDeptName = "";
            if (this.m_objViewer.m_txtExportDept.Text.Trim() == "")
            {
                strDeptName = "全部";
            }
            else
            {
                strDeptName = this.m_objViewer.m_txtExportDept.Text.Trim();
            }
            m_objViewer.datWindow.Modify("storagename.text='" + "(" + m_objViewer.m_strStorageName + ")" + "'");
            m_objViewer.datWindow.Modify("t_outtype.text='" + "(" + this.m_objViewer.m_cboType.Text.Trim() + ")" + "'");
            m_objViewer.datWindow.Modify("t_deptname.text='领用部门：" + strDeptName + "'");
            m_objViewer.datWindow.Modify("begindate.text='" + m_objViewer.m_dtpSearchBeginDate.Text + " --- " + m_objViewer.m_dtpSearchEndDate.Text + "'");
            //m_objViewer.datWindow.Modify("enddate.text='" + m_objViewer.m_dtpSearchEndDate.Text + "'");
            m_dtbReport.Columns.Remove("comment_vchr");
            m_dtbReport.AcceptChanges();
            m_objViewer.datWindow.SetRedrawOff();
            m_objViewer.datWindow.Retrieve(m_dtbReport);
            m_objViewer.datWindow.SetRedrawOn();
            m_objViewer.datWindow.Refresh();

            if (!m_dtbReport2.Columns.Contains("SortRowNo"))
            {
                m_dtbReport2.Columns.Add("SortRowNo", typeof(long));
            }
            m_mthAddTotalSumRow(m_dtbReport2);
        }

        //private bool blnIsExits(string p_deptname, ref DataTable m_dtbReport)
        //{
            
        //}


        #region 获取入库类型
        /// <summary>
        /// 获取入库类型
        /// </summary>
        internal void m_mthGetImpExpTypeInfo()
        {
            DataTable m_dtImpExpTypeInfo;
            long lngRes = m_objDomain.m_mthGetImpExpTypeInfo(out m_dtImpExpTypeInfo);
            DataView dvTemp = m_dtImpExpTypeInfo.DefaultView;
            if (m_objViewer.m_blnGY3Y_DS)
            {
                dvTemp.RowFilter = " flag_int = 1 and storgeflag_int<> 0";
            }
            else
            {
                dvTemp.RowFilter = " flag_int = 1 and storgeflag_int <> 1";
            }
            
            DataTable m_dtbType = dvTemp.ToTable();
            DataRow dr = m_dtbType.NewRow();
            dr["typename_vchr"] = "全部";
            dr["typecode_vchr"] = "";
            m_dtbType.Rows.InsertAt(dr, 0);
            this.m_objViewer.m_cboType.DataSource = m_dtbType;
            this.m_objViewer.m_cboType.DisplayMember = "typename_vchr";
            this.m_objViewer.m_cboType.ValueMember = "typecode_vchr";
            this.m_objViewer.m_cboType.SelectedIndex = 0;            
        }
        #endregion

        #region 根据药房Id获取对应的部门ID
        /// <summary>
        /// 根据药房Id获取对应的部门ID
        /// </summary>
        /// <param name="m_strStorageID"></param>
        /// <param name="m_strDeptID"></param>
        internal void m_lngGetDeptIDForStore(string m_strStorageID, out string m_strDeptID)
        {
            m_objDomain.m_lngGetDeptIDForStore(m_strStorageID, out m_strDeptID);
        }
        #endregion

        public void m_mthFillMedType()
        {
            clsDcl_OutStorageDetailReport2 objTmp = new clsDcl_OutStorageDetailReport2();
            DataTable dtRoom;
            DataTable dtVonder;
            DataTable dtMedType;
            long lngRes = objTmp.m_lngGetExptypeAndVendor(m_objViewer.m_blnGY3Y_DS, out dtRoom, out dtVonder, out dtMedType);
            DataView dtvMedType = new DataView(dtMedType);
            clsColumns_VO[] column2 = new clsColumns_VO[] { new clsColumns_VO("类别名称", "medicinetypename_vchr", HorizontalAlignment.Left, 145) };
            this.m_objViewer.txtTypecode.m_mthInitListView(column2);
            if (m_objViewer.m_blnGY3Y_DS)
            {
                dtvMedType.RowFilter = "medicineroomid='" + this.m_objViewer.m_strDeptID + "'";
            }
            else
            {
                dtvMedType.RowFilter = "medicineroomid='" + this.m_objViewer.m_strStorageID + "'";
            }
            DataTable dtValue = dtvMedType.ToTable();
            DataRow drTmp = dtValue.NewRow();
            drTmp["medicinetypeid_chr"] = "";
            drTmp["medicinetypename_vchr"] = "全部";
            drTmp["medicineroomid"] = "-1";
            dtValue.BeginLoadData();
            dtValue.Rows.Add(drTmp);
            dtValue.EndLoadData();

            this.m_objViewer.txtTypecode.m_dtbDataSourse = dtValue;
            this.m_objViewer.txtTypecode.m_mthFillData();
        }

        #region 是否住院药房
        /// <summary>
        /// 是否住院药房
        /// </summary>
        /// <param name="p_strStorageid"></param>
        /// <param name="p_blnIsHospital"></param>
        internal long m_lngCheckIsHospital(string p_strStorageid, out bool p_blnIsHospital)
        {
            clsDcl_InstorageDetailReport objDom = new clsDcl_InstorageDetailReport();
            return objDom.m_lngCheckIsHospital(p_strStorageid, out p_blnIsHospital);
        }
        #endregion
    }
}
