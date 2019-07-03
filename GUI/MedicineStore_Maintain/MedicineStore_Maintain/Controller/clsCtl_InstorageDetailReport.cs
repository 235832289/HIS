using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.digitalwave.iCare.gui.MedicineStore;
using System.Windows.Forms;
using ControlLibrary;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    class clsCtl_InstorageDetailReport : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 全局变量

        /// <summary>
        /// 模块控制类
        /// </summary>
        private clsDcl_InstorageDetailReport m_objDomain = null;

        /// <summary>
        /// 窗体
        /// </summary>
        private com.digitalwave.iCare.gui.MedicineStore_Maintain.frmInstorageDetailReport m_objViewer;
        /// <summary>
        /// 药品查询控件
        /// </summary>
        private ctlQueryMedicintLeastElement m_ctlQueryMedicint = null;
        private ctlQueryVendor m_ctlQueryVendor = null;
        private DataTable m_dtbVendor = null;

        #endregion

        #region 构造函数


        /// <summary>
        /// 出库明细报表
        /// </summary>
        public clsCtl_InstorageDetailReport()
        {
            m_objDomain = new clsDcl_InstorageDetailReport();
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
            m_objViewer = (frmInstorageDetailReport)frmMDI_Child_Base_in;
        }
        #endregion

        #region 查询药品
        internal void m_mthShowQueryMedicineForm(string p_strSearchCon)
        {
            if (m_ctlQueryMedicint == null)
            {

                m_ctlQueryMedicint = new ctlQueryMedicintLeastElement(m_objViewer.m_dtbMedicinDict);
                m_objViewer.Controls.Add(m_ctlQueryMedicint);

                int X = m_objViewer.txtTypecode.Location.X;// - m_objViewer.m_txtMedicine.Size.Width);
                int Y = m_objViewer.txtTypecode.Location.Y + 60;

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

        internal void m_ctlQueryMedicint_RefreshMedicine()
        {
            m_mthGetMedicineInfo();
            m_ctlQueryMedicint.m_dtbMedicineInfo = m_objViewer.m_dtbMedicinDict;
        }

        internal void m_ctlQueryMedicint_CancelResult()
        {
            m_objViewer.m_txtMedicine.Focus();
        }

        internal void frmQueryForm_ReturnInfo(com.digitalwave.iCare.ValueObject.clsMS_MedicintLeastElement_VO MS_VO)
        {
            if (MS_VO == null)
            {
                return;
            }

            if(m_objViewer.m_rbtSingle.Checked)
                m_objViewer.m_txtMedicine.Text = MS_VO.m_strMedicineName;
            else
                m_objViewer.m_txtMedicine.Text = MS_VO.m_strMedicineCode;
            m_objViewer.m_txtMedicine.Tag = MS_VO.m_strMedicineID;
            
        }
        #endregion

        #region 显示供应商查询
        /// <summary>
        /// 获取供应商信息
        /// </summary>
        /// <param name="p_dtbVendor"></param>
        internal void m_mthGetVendor(out DataTable p_dtbVendor)
        {
            long lngRes = m_objDomain.m_lngGetVendor(out p_dtbVendor);
        }
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

        internal void QueryVendor_ReturnInfo(com.digitalwave.iCare.ValueObject.clsMS_Vendor MS_VO)
        {
            m_objViewer.m_txtVendor.Tag = null;
            if (MS_VO == null)
            {
                return;
            }

            m_objViewer.m_txtVendor.Tag = MS_VO.m_strVendorID;
            m_objViewer.m_txtVendor.Text = MS_VO.m_strVendorName;

            m_objViewer.txtTypecode.Focus();
        }
        #endregion

        #region 查询入库明细(药库使用）
        /// <summary>
        /// 查询入库明细(药库使用）
        /// </summary>
        internal void m_mthQuery()
        {
            DateTime m_dtmBegin,m_dtmEnd;
            if(!DateTime.TryParse(m_objViewer.m_dtpBeginDate.Text,out m_dtmBegin))
            {
                MessageBox.Show("请输入查询开始时间", "入库明细报表", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!DateTime.TryParse(m_objViewer.m_dtpEndDate.Text, out m_dtmEnd))
            {
                MessageBox.Show("请输入查询结束时间", "入库明细报表", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            //DateTime.Parse(Convert.ToDateTime(m_objViewer.m_dtpBeginDate.Text).ToString("yyyy-MM-dd HH:mm:ss"));
            //DateTime m_dtmEnd = DateTime.Parse(Convert.ToDateTime(m_objViewer.m_dtpEndDate.Text).ToString("yyyy-MM-dd HH:mm:ss"));

            if (m_dtmBegin.Date > m_dtmEnd.Date)
            {
                MessageBox.Show("查询开始时间不能超过结束时间", "入库明细报表", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable m_dtbReport = null;
            long lngRes = 0;
            
            if (m_objViewer.m_txtVendor.Text.Trim() == string.Empty)
                m_objViewer.m_txtVendor.Tag = "";
            
            string strMedTypeCode = "";
            if (!string.IsNullOrEmpty(this.m_objViewer.txtTypecode.Value))
            {
                strMedTypeCode = this.m_objViewer.txtTypecode.Value.ToString();
            }

            string p_strMedicineID = string.Empty;
            if (m_objViewer.m_rbtSingle.Checked)
                p_strMedicineID = Convert.ToString(m_objViewer.m_txtMedicine.Tag);
            else
                p_strMedicineID = m_objViewer.m_txtMedicine.Text;

            lngRes = m_objDomain.m_lngGetInstorageDetailReport(m_objViewer.m_rbtCombine.Checked,m_objViewer.m_strStorageID, m_dtmBegin, m_dtmEnd, m_objViewer.m_txtVendor.Tag.ToString(), strMedTypeCode,p_strMedicineID,
                m_objViewer.m_cboType.SelectedValue.ToString(),out m_dtbReport);
            if (lngRes < 0)
            {
                MessageBox.Show("获取报表内容失败", "入库明细报表", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.m_objViewer.m_dgvInstorageDetail.DataSource = m_dtbReport;

            //double dblRetailPrice = 0d;
            //double dblPriceSum = 0d;
            //double dblAmount = 0d;
            //double dblTotalAmount = 0d;
            //int iRowCount = m_dtbReport.Rows.Count;
            //DataRow drTemp = null;
            //for (int i = 0; i < iRowCount; i++)
            //{
            //    drTemp = m_dtbReport.Rows[i];
            //    double.TryParse(Convert.ToString(drTemp["retailsum"]), out dblRetailPrice);
            //    dblPriceSum += dblRetailPrice;
            //    double.TryParse(Convert.ToString(drTemp["amount"]), out dblAmount);
            //    dblTotalAmount += dblAmount;
            //}
            //if (Convert.ToString(m_objViewer.m_txtMedicine.Tag) == string.Empty || Convert.ToString(m_objViewer.m_txtMedicine.Text) == string.Empty)
            //{
            //    m_objViewer.m_lblTotalAmount.Visible = false;
            //    m_objViewer.lblTotalAmount.Visible = false;
            //}
            //else
            //{
            //    m_objViewer.m_lblTotalAmount.Visible = true;
            //    m_objViewer.lblTotalAmount.Visible = true;
            //}
            //m_objViewer.m_lblTotalAmount.Text = dblTotalAmount.ToString("#,##0.0000");
            //this.m_objViewer.m_lblPriceSum.Text = dblPriceSum.ToString("#,##0.0000") + "元";
            //drTemp = null;
            string strDeptName = this.m_objViewer.m_txtVendor.Text.Trim();
            if (this.m_objViewer.m_txtVendor.Text.Trim() == "")
            {
                strDeptName = "全部";
            }
            string m_strRoomName;
            m_objDomain.m_lngGetStoreName(m_objViewer.m_strStorageID, out m_strRoomName);
            m_objViewer.m_dwcData.Modify("t_title.text='入库药品详细记录" + "(" + this.m_objViewer.m_cboType.Text.Trim() + ")" + "'");
            m_objViewer.m_dwcData.Modify("t_deptname.text='领用部门：" + strDeptName + "'");
            m_objViewer.m_dwcData.Modify("storagename.text='" + "(" + m_strRoomName + ")" + "'");
            m_objViewer.m_dwcData.Modify("begindate.text='" + m_objViewer.m_dtpBeginDate.Text + " --- "+m_objViewer.m_dtpEndDate.Text + "'");
            //m_objViewer.m_dwcData.Modify("enddate.text='" + m_objViewer.m_dtpEndDate.Text + "'");
            m_objViewer.m_dwcData.SetRedrawOff();
            m_objViewer.m_dwcData.Retrieve(m_dtbReport);
            m_objViewer.m_dwcData.SetRedrawOn();
            m_objViewer.m_dwcData.Refresh();

            if (!m_dtbReport.Columns.Contains("SortRowNo"))
            {
                m_dtbReport.Columns.Add("SortRowNo", typeof(long));
            }
            m_mthAddTotalSumRow(m_dtbReport);
        }
        #endregion 

        #region 获取入库类型
        /// <summary>
        /// 获取入库类型
        /// </summary>
        internal void m_mthGetImpExpTypeInfo()
        {
            DataTable m_dtImpExpTypeInfo;
            long lngRes = m_objDomain.m_mthGetImpExpTypeInfo(out m_dtImpExpTypeInfo);
            DataView dvTemp = m_dtImpExpTypeInfo.DefaultView;
            if (m_objViewer.m_blnForDrugStore)
                dvTemp.RowFilter = " flag_int = 0 and storgeflag_int <> 0";
            else
                dvTemp.RowFilter = " flag_int = 0 and storgeflag_int <> 1";
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

        #region 获取药品字典最小元素集
        /// <summary>
        /// 获取药品字典最小元素集
        /// </summary>
        internal void m_mthGetMedicineInfo()
        {
            long lngRes = m_objDomain.m_lngGetBaseMedicine(m_objViewer.m_blnForDrugStore,true,string.Empty, m_objViewer.m_strStorageID, out m_objViewer.m_dtbMedicinDict);
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

        #region 查询入库明细(药房使用）
        /// <summary>
        /// 查询入库明细(药房使用）
        /// </summary>
        internal void m_mthQueryForDrugStore()
        {
            DateTime m_dtmBegin, m_dtmEnd;
            if (!DateTime.TryParse(m_objViewer.m_dtpBeginDate.Text, out m_dtmBegin))
            {
                MessageBox.Show("请输入查询开始时间", "入库明细报表", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!DateTime.TryParse(m_objViewer.m_dtpEndDate.Text, out m_dtmEnd))
            {
                MessageBox.Show("请输入查询结束时间", "入库明细报表", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //DateTime m_dtmBegin = DateTime.Parse(Convert.ToDateTime(m_objViewer.m_dtpBeginDate.Text).ToString("yyyy-MM-dd HH:mm:ss"));
            //DateTime m_dtmEnd = DateTime.Parse(Convert.ToDateTime(m_objViewer.m_dtpEndDate.Text).ToString("yyyy-MM-dd HH:mm:ss"));

            if (m_dtmBegin.Date > m_dtmEnd.Date)
            {
                MessageBox.Show("查询开始时间不能超过结束时间", "入库明细报表", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable m_dtbReport = null;
            long lngRes = 0;
            string m_strDeptID = "";            
            
            if (m_objViewer.m_txtReceiveDept.Text.Trim() != string.Empty)               
                m_strDeptID = m_objViewer.m_txtReceiveDept.StrItemId;
            
            string strMedTypeCode = "";
            if (!string.IsNullOrEmpty(this.m_objViewer.txtTypecode.Value))
            {
                strMedTypeCode = this.m_objViewer.txtTypecode.Value.ToString();
            }

            string p_strMedicineID = string.Empty;
            if (m_objViewer.m_rbtSingle.Checked)
                p_strMedicineID = Convert.ToString(m_objViewer.m_txtMedicine.Tag);
            else
                p_strMedicineID = m_objViewer.m_txtMedicine.Text;

            lngRes = m_objDomain.m_lngGetInstorageDetailReportForDrugStore(m_objViewer.m_rbtCombine.Checked,m_objViewer.m_strDeptID, m_dtmBegin, m_dtmEnd, m_strDeptID, strMedTypeCode, p_strMedicineID,
                m_objViewer.m_cboType.SelectedValue.ToString(),m_objViewer.m_blnIsHospital, out m_dtbReport);
            if (lngRes < 0)
            {
                MessageBox.Show("获取报表内容失败", "入库明细报表", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.m_objViewer.m_dgvInstorageDetail.DataSource = m_dtbReport;

            double dblRetailPrice = 0d;
            double dblPriceSum = 0d;
            double dblAmount = 0d;
            double dblTotalAmount = 0d;
            int iRowCount = m_dtbReport.Rows.Count;
            DataRow drTemp = null;
            for (int i = 0; i < iRowCount; i++)
            {
                drTemp = m_dtbReport.Rows[i];
                double.TryParse(Convert.ToString(drTemp["retailsum"]), out dblRetailPrice);
                dblPriceSum += dblRetailPrice;
                double.TryParse(Convert.ToString(drTemp["amount"]), out dblAmount);
                dblTotalAmount += dblAmount;
            }
            if (Convert.ToString(m_objViewer.m_txtMedicine.Tag) == string.Empty || Convert.ToString(m_objViewer.m_txtMedicine.Text) == string.Empty)
            {
                m_objViewer.m_lblTotalAmount.Visible = false;
                m_objViewer.lblTotalAmount.Visible = false;
            }
            else
            {
                m_objViewer.m_lblTotalAmount.Visible = true;
                m_objViewer.lblTotalAmount.Visible = true;
            }
            m_objViewer.m_lblTotalAmount.Text = dblTotalAmount.ToString("#,##0.0000");
            this.m_objViewer.m_lblPriceSum.Text = dblPriceSum.ToString("#,##0.0000") + "元";
            drTemp = null;
            string strDeptName = this.m_objViewer.m_txtReceiveDept.Text.Trim();
            if (this.m_objViewer.m_txtReceiveDept.Text.Trim() == "")
            {
                strDeptName = "全部";
            }
            string m_strRoomName;
            m_objDomain.m_lngGetDrugStoreName(m_objViewer.m_strStorageID, out m_strRoomName);
            m_objViewer.m_dwcData.Modify("t_title.text='入库药品详细记录" + "(" + this.m_objViewer.m_cboType.Text.Trim() + ")" + "'");
            m_objViewer.m_dwcData.Modify("t_deptname.text='领用部门：" + strDeptName + "'");
            m_objViewer.m_dwcData.Modify("storagename.text='" + "(" + m_strRoomName + ")" + "'");
            m_objViewer.m_dwcData.Modify("begindate.text='" + m_objViewer.m_dtpBeginDate.Text + " --- " + m_objViewer.m_dtpEndDate.Text + "'");
            //m_objViewer.m_dwcData.Modify("begindate.text='" + m_objViewer.m_dtpBeginDate.Text + "'");
            //m_objViewer.m_dwcData.Modify("enddate.text='" + m_objViewer.m_dtpEndDate.Text + "'");
            m_objViewer.m_dwcData.SetRedrawOff();
            m_objViewer.m_dwcData.Retrieve(m_dtbReport);
            m_objViewer.m_dwcData.SetRedrawOn();
            m_objViewer.m_dwcData.Refresh();

            if (!m_dtbReport.Columns.Contains("SortRowNo"))
            {
                m_dtbReport.Columns.Add("SortRowNo", typeof(long));
            }
            m_mthAddTotalSumRow(m_dtbReport);
        }
        #endregion 
    
        #region 获取领用部门信息
        /// <summary>
        /// 获取领用部门信息
        /// </summary>
        /// <param name="p_dtbExportDept"></param>
        internal void m_mthGetExportDept(out DataTable p_dtbExportDept)
        {
            m_objDomain.m_lngGetExportDept(out p_dtbExportDept);
        }
        #endregion

        public void m_mthFillMedType()
        {
            //this.m_objViewer.txtTypecode.m_listView.Items.Clear();
            clsDcl_OutStorageDetailReport2 objTmp = new clsDcl_OutStorageDetailReport2();
            DataTable dtRoom;
            DataTable dtVonder;
            DataTable dtMedType;
            long lngRes = objTmp.m_lngGetExptypeAndVendor(m_objViewer.m_blnForDrugStore, out dtRoom, out dtVonder, out dtMedType);
            DataView dtvMedType = new DataView(dtMedType);
            clsColumns_VO[] column2 = new clsColumns_VO[] { new clsColumns_VO("类别名称", "medicinetypename_vchr", HorizontalAlignment.Left, 145) };
            this.m_objViewer.txtTypecode.m_mthInitListView(column2);
            if (m_objViewer.m_blnForDrugStore)
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

        internal void m_mthAddTotalSumRow(DataTable p_dtbResult)
        {
            if (p_dtbResult.Rows.Count > 0)
            {
                double dblTempSum = 0d;
                DataRow drAdd = p_dtbResult.NewRow();
                for (int i1 = 0; i1 < p_dtbResult.Columns.Count; i1++)
                {
                    dblTempSum = 0d;
                    if (p_dtbResult.Columns[i1].ColumnName.ToLower() == "medicinename_vch")
                    {
                        drAdd[i1] = "合计";
                    }
                    else if (p_dtbResult.Columns[i1].ColumnName.ToLower() == "callsum" || p_dtbResult.Columns[i1].ColumnName.ToLower() == "retailsum" ||
                        (p_dtbResult.Columns[i1].ColumnName.ToLower() == "amount" && m_objViewer.m_txtMedicine.Tag != null && m_objViewer.m_txtMedicine.Tag.ToString().Length > 0))
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

        #region 是否住院药房
        /// <summary>
        /// 是否住院药房
        /// </summary>
        /// <param name="p_strStorageid"></param>
        /// <param name="p_blnIsHospital"></param>
        internal long m_lngCheckIsHospital(string p_strStorageid, out bool p_blnIsHospital)
        {            
            return m_objDomain.m_lngCheckIsHospital(p_strStorageid, out p_blnIsHospital);
        }
        #endregion
    }
}
