using System;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ControlLibrary;
using Sybase.DataWindow;
using System.Windows.Forms;
using com.digitalwave.iCare.gui.MedicineStore;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    public class clsCtl_RptInstorageStat:com.digitalwave.GUI_Base.clsController_Base
    {
        private frmRptInstorageStat m_objViewer;
        private clsDcl_InstorageDetailReport objSvc;
        private ctlQueryMedicintLeastElement m_ctlMedQuery;
        private ctlQueryVendor m_ctlQueryManufacturer;
        private DataView dtvMedType;
        private ctlQueryVendor m_ctlQueryVendor;
        private DataTable m_dtbVendor;
        private DataTable dtMedName;
        
        public clsCtl_RptInstorageStat()
        {
            objSvc = new clsDcl_InstorageDetailReport();
        }

        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmRptInstorageStat)frmMDI_Child_Base_in;
        }

        public void m_mthInit()
        {
            this.m_objViewer.dw.LibraryList = clsPublic.PBLPath;
            this.m_objViewer.dw.DataWindowObject = "instorage_detailreport_3yuan";
            this.m_objViewer.dw.InsertRow(0);
            //this.m_objViewer.dw.PrintProperties.Preview = true;
            //this.m_objViewer.dw.PrintProperties.ShowPreviewRulers = true;

            clsDcl_OutStorageDetailReport2 objTmp = new clsDcl_OutStorageDetailReport2();
            DataTable dtRoom;
            DataTable dtRoomToid = new DataTable();
            DataTable dtVonder;
            DataTable dtMedType;
            long lngRes = objTmp.m_lngGetExptypeAndVendor(m_objViewer.m_blnForDrugStore, out dtRoom, out dtVonder, out dtMedType);
            DataTable dtVendor;//供应商 
            objSvc.m_lngGetVendor(out dtVendor);
            this.dtvMedType = new DataView(dtMedType);
            clsColumns_VO[] column2 = new clsColumns_VO[] { new clsColumns_VO("类别名称", "medicinetypename_vchr", HorizontalAlignment.Left, 145) };
            this.m_objViewer.txtTypecode.m_mthInitListView(column2);
            this.m_objViewer.txtTypecode.m_dtbDataSourse = null;

            if (m_objViewer.m_strRoomidArr.Length > 0)
            {
                if (dtRoom.Rows.Count > 0)
                {
                    dtRoomToid = dtRoom.Clone();
                    DataRow dr = null;
                    int iRowCount = dtRoom.Rows.Count;
                    int iLength = m_objViewer.m_strRoomidArr.Length;
                    dtRoomToid.BeginLoadData();

                    for (int i = 0; i < iLength; i++)
                    {
                        for (int j = 0; j < iRowCount; j++)
                        {
                            dr = dtRoom.Rows[j];
                            if (m_objViewer.m_strRoomidArr[i].ToString().Trim() == dr["medicineroomid"].ToString().Trim())
                            {
                                dtRoomToid.LoadDataRow(dr.ItemArray, true);
                            }
                        }
                    }
                    dtRoomToid.EndLoadData();
                    dtRoomToid.AcceptChanges();
                }
            }

            clsColumns_VO[] column3 = new clsColumns_VO[] { new clsColumns_VO("库房名称", "medicineroomname", HorizontalAlignment.Left, 145) };
            this.m_objViewer.txtStoreroom.m_mthInitListView(column3);
            if (m_objViewer.m_strRoomidArr.Length > 0)
            {
                this.m_objViewer.txtStoreroom.m_dtbDataSourse = dtRoomToid;
            }
            else
            {
                this.m_objViewer.txtStoreroom.m_dtbDataSourse = dtRoom;
            }
            this.m_objViewer.txtStoreroom.m_mthFillData();
            if (m_objViewer.m_strRoomidArr.Length > 0)
            {
                DataRow drRoom = null;
                for (int iRow = 0; iRow < dtRoom.Rows.Count; iRow++)
                {
                    drRoom = dtRoom.Rows[iRow];
                    if (m_objViewer.m_strRoomidArr[0].ToString().Trim() == drRoom["medicineroomid"].ToString().Trim())
                    {
                        this.m_objViewer.txtStoreroom.Text = drRoom["medicineroomname"].ToString().Trim();
                        this.m_objViewer.txtStoreroom.Value = drRoom["medicineroomid"].ToString().Trim();
                        break;
                    }
                }
            }
            else
            {
                this.m_objViewer.txtStoreroom.Text = dtRoom.Rows[0]["medicineroomname"].ToString().Trim();
                this.m_objViewer.txtStoreroom.Value = dtRoom.Rows[0]["medicineroomid"].ToString().Trim();
            }
            this.m_objViewer.m_dtProduct = dtVendor;// dtVonder;

            if (m_objViewer.m_blnForDrugStore)
            {
                DataTable dtbDept = null;
                m_mthGetExportDept(out dtbDept);
                m_objViewer.m_txtReceiveDept.m_mthInitDeptData(dtbDept);
                m_objViewer.m_txtReceiveDept.Visible = true;
                m_objViewer.m_txtReceiveDept.BringToFront();
                m_objViewer.txtProduct.Visible = false;
            }
            else
            {
                m_objViewer.m_txtReceiveDept.Visible = false;
                m_objViewer.txtProduct.BringToFront();
                m_objViewer.txtProduct.Visible = true;
            }
            m_mthGetImpExpTypeInfo();
        }

        #region 获取入库类型
        /// <summary>
        /// 获取入库类型
        /// </summary>
        internal void m_mthGetImpExpTypeInfo()
        {
            DataTable m_dtImpExpTypeInfo;
            long lngRes = objSvc.m_mthGetImpExpTypeInfo(out m_dtImpExpTypeInfo);
            DataView dvTemp = m_dtImpExpTypeInfo.DefaultView;
            if (m_objViewer.m_blnForDrugStore)
            {
                dvTemp.RowFilter = " flag_int = 0 and storgeflag_int <> 0";
            }
            else
            {
                dvTemp.RowFilter = " flag_int = 0 and storgeflag_int <> 1";
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

        #region 获取领用部门信息
        /// <summary>
        /// 获取领用部门信息
        /// </summary>
        /// <param name="p_dtbExportDept"></param>
        internal void m_mthGetExportDept(out DataTable p_dtbExportDept)
        {
            objSvc.m_lngGetExportDept(out p_dtbExportDept);
        }
        #endregion

        public void m_mthSearch()
        {
            this.m_objViewer.Cursor = Cursors.WaitCursor;
            //DateTime dtm1 = Convert.ToDateTime(this.m_objViewer.m_dtpSearchBeginDate.Text);
            //DateTime dtm2 = Convert.ToDateTime(this.m_objViewer.m_dtpSearchEndDate.Text);
            DateTime dtm1, dtm2;
            if (!DateTime.TryParse(m_objViewer.m_dtpSearchBeginDate.Text, out dtm1))
            {
                MessageBox.Show("请输入查询开始时间", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!DateTime.TryParse(m_objViewer.m_dtpSearchEndDate.Text, out dtm2))
            {
                MessageBox.Show("请输入查询结束时间", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataTable dt;

            string Medid = "";
            string strMedTypeCode = "";
            //string strProduct = "";
            //if (this.m_objViewer.m_txtMedicineCode.Tag != null)
            //{
            //    //clsMS_MedicintLeastElement_VO objVO = this.m_objViewer.m_txtMedicineCode.Tag as clsMS_MedicintLeastElement_VO;
            //    //if (this.m_objViewer.m_txtMedicineCode.Text.Trim() != objVO.m_strMedicineName && this.m_objViewer.m_txtMedicineCode.Text.Trim() != "")
            //    //{
            //    //    MessageBox.Show(this.m_objViewer, "所录入的药品与所选择的药品ID不相符，请重新选择药品。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    //    return;
            //    //}
            //    //else if (this.m_objViewer.m_txtMedicineCode.Text.Trim() != "")
            //    //{
            //    //    Medid = objVO.m_strMedicineID;
            //    //}
            //    Medid = Convert.ToString(this.m_objViewer.m_txtMedicineCode.Tag);
            //}
            //string strMedName = this.m_objViewer.m_txtMedicineCode.Text.Trim();
            //bool blnIsExists = false;
            //if (this.m_objViewer.m_txtMedicineCode.Tag != null && this.m_objViewer.m_txtMedicineCode.Text.Trim() != "")
            //{
            //    int iRowCount = dtMedName.Rows.Count;
            //    DataRow dr = null;
            //    for (int i = 0; i < iRowCount; i++)
            //    {
            //        dr = dtMedName.Rows[i];
            //        if (dr["medicinename_vchr"].ToString().Trim() == strMedName)
            //        {
            //            Medid = Convert.ToString(this.m_objViewer.m_txtMedicineCode.Tag);
            //            blnIsExists = true;
            //            break;
            //        }
            //    }
            //    if (!blnIsExists)
            //    {
            //        this.m_objViewer.m_dgvInstorage.DataSource = null;
            //        this.m_objViewer.dw.Reset();
            //        this.m_objViewer.dw.Refresh();
            //        this.m_objViewer.dw.InsertRow(0);
            //        MessageBox.Show(this.m_objViewer, "未能找到入库数据，请修改查询条件。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        this.m_objViewer.Cursor = Cursors.Default;
            //        return;
            //    }
            //}
            if (m_objViewer.m_rbtSingle.Checked)
                Medid = Convert.ToString(this.m_objViewer.m_txtMedicineCode.Tag);
            else
                Medid = m_objViewer.m_txtMedicineCode.Text;
            if (!string.IsNullOrEmpty(this.m_objViewer.txtTypecode.Value))
            {
                strMedTypeCode = this.m_objViewer.txtTypecode.Value.ToString();
            }
            //if (this.m_objViewer.txtProduct!=null && this.m_objViewer.txtProduct.Text.Trim()!="")
            //{
            //strProduct = Convert.ToString(this.m_objViewer.txtProduct.Tag);
            //}

            long lngRes = 0;
            if (m_objViewer.m_blnForDrugStore)
            {
                string m_strDeptID = "";
                if (m_objViewer.m_txtReceiveDept.Text.Trim() != "")
                    m_strDeptID = m_objViewer.m_txtReceiveDept.StrItemId;
                lngRes = objSvc.m_lngGetDrugStoreInstorageStat(m_objViewer.m_rbtCombine.Checked,this.m_objViewer.txtStoreroom.Value.ToString(), m_objViewer.m_cboType.SelectedValue.ToString(), dtm1, dtm2, Medid, strMedTypeCode, m_strDeptID,m_objViewer.m_blnIsHospital, out m_objViewer.m_dtbOriginalResult);
            }
            else
            {
                if (this.m_objViewer.txtProduct.Text.Trim() == "")
                    this.m_objViewer.txtProduct.Tag = "";
                
                lngRes = objSvc.m_lngRptInstorage(m_objViewer.m_rbtCombine.Checked, this.m_objViewer.txtStoreroom.Value.ToString(), m_objViewer.m_cboType.SelectedValue.ToString(), dtm1, dtm2, Medid, strMedTypeCode, Convert.ToString(this.m_objViewer.txtProduct.Tag), m_objViewer.m_txtBidYear.Text.Trim().Replace("'", "''"),m_objViewer.m_txtBidYear2.Text.Trim().Replace("'", "''"), out m_objViewer.m_dtbOriginalResult);
            }
            if (lngRes > 0)
            {
                dt = m_objViewer.m_dtbOriginalResult.Copy();
                this.m_objViewer.m_dgvInstorage.DataSource = dt;

                double dblRetailPrice = 0d;
                double dblPriceSum = 0d;
                double dblAmount = 0d;
                double dblTotalAmount = 0d;
                int iRowCount = dt.Rows.Count;
                DataRow drTemp = null;
                for (int i = 0; i < iRowCount; i++)
                {
                    drTemp = dt.Rows[i];
                    double.TryParse(Convert.ToString(drTemp["UNITPRICE"]), out dblRetailPrice);
                    dblPriceSum += Convert.ToDouble(dblRetailPrice.ToString("0.0000"));
                    double.TryParse(Convert.ToString(drTemp["amount"]), out dblAmount);
                    dblTotalAmount += Convert.ToDouble(dblAmount.ToString("0.0000"));
                }
                //if (Convert.ToString(m_objViewer.m_txtMedicineCode.Tag) == string.Empty || Convert.ToString(m_objViewer.m_txtMedicineCode.Text) == string.Empty)
                //{
                //    m_objViewer.m_lblTotalAmount.Visible = false;
                //    m_objViewer.lblTotalAmout.Visible = false;
                //}
                //else
                //{
                //    m_objViewer.m_lblTotalAmount.Visible = true;
                //    m_objViewer.lblTotalAmout.Visible = true;
                //}
                m_objViewer.m_lblTotalAmount.Text = dblTotalAmount.ToString("#,##0.0000");
                this.m_objViewer.m_lblPriceSum.Text = dblPriceSum.ToString("#,##0.0000") + "元";
                drTemp = null;

                if (dt == null || dt.Rows.Count == 0)
                {
                    this.m_objViewer.dw.Reset();
                    this.m_objViewer.dw.Refresh();
                    this.m_objViewer.dw.InsertRow(0);
                    MessageBox.Show(this.m_objViewer, "未能找到入库数据，请修改查询条件。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.m_objViewer.Cursor = Cursors.Default;
                    return;
                }
                this.m_objViewer.dw.Reset();
                this.m_objViewer.dw.SetRedrawOff();
                string strDept = string.Empty;
                if (this.m_objViewer.m_txtReceiveDept.Text.Trim() == "")
                {
                    strDept = "全部";
                }
                else
                {
                    strDept = this.m_objViewer.m_txtReceiveDept.Text.Trim();
                }
                this.m_objViewer.dw.Modify("t_hospitalname.text='" + this.m_objComInfo.m_strGetHospitalTitle() + "'");
                this.m_objViewer.dw.Modify("t_deptname.text='领用部门：" + strDept + "'");
                this.m_objViewer.dw.Modify("t_time.text='统计日期：" + dtm1.ToString("yyyy-MM-dd HH:mm:ss") + " --- " + dtm2.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                string strOutType = dt.Rows[0]["TYPENAME_VCHR"].ToString();
                string strTypeName = "";
                if (Convert.ToString(m_objViewer.m_cboType.SelectedValue) == "")
                    strOutType = "全部入库";

                if (string.IsNullOrEmpty(this.m_objViewer.txtTypecode.Value))
                {
                    strTypeName = "全部";
                }
                else
                {
                    strTypeName = this.m_objViewer.txtTypecode.Text;
                }
                this.m_objViewer.dw.Modify("t_title.text='(" + this.m_objViewer.txtStoreroom.Text.Trim() + ")入库统计报表(" + strOutType + ")'");
                this.m_objViewer.dw.Modify("t_type.text='药品分类：" + strTypeName + "'");

                string strTmpMedName = "";
                DataRow dr = null;
                for (int k = 0; dt != null && k < dt.Rows.Count; k++)
                {
                    dr = dt.Rows[k];
                    int row = this.m_objViewer.dw.InsertRow(0);
                    if (strTmpMedName == dr["MEDICINEID_CHR"].ToString())
                    {
                        this.m_objViewer.dw.SetItemString(row, "colmedname", "");
                        this.m_objViewer.dw.SetItemString(row, "colmedspec", "");
                        this.m_objViewer.dw.SetItemString(row, "colunit", "");
                        this.m_objViewer.dw.SetItemString(row, "colpuduct", "");
                    }
                    else
                    {
                        this.m_objViewer.dw.SetItemString(row, "colmedname", dr["MEDICINENAME_VCH"].ToString());
                        strTmpMedName = dr["MEDICINEID_CHR"].ToString();

                        this.m_objViewer.dw.SetItemString(row, "colmedspec", dr["MEDSPEC_VCHR"].ToString());
                        this.m_objViewer.dw.SetItemString(row, "colunit", dr["unit"].ToString());
                        this.m_objViewer.dw.SetItemString(row, "colpuduct", dr["PRODUCTORID_CHR"].ToString());
                    }
                    this.m_objViewer.dw.SetItemString(row, "colmedid", dr["MEDICINEID_CHR"].ToString());
                    
                    this.m_objViewer.dw.SetItemDecimal(row, "colretailprice", Convert.ToDecimal(Convert.ToDouble(dr["retailprice"]).ToString("0.0000")));
                    this.m_objViewer.dw.SetItemDecimal(row, "colamount", Convert.ToDecimal(Convert.ToDouble(dr["AMOUNT"]).ToString("0.00")));
                    this.m_objViewer.dw.SetItemDecimal(row, "colmoney", Convert.ToDecimal(Convert.ToDouble(dr["UNITPRICE"]).ToString("0.0000")));                    
                    this.m_objViewer.dw.SetItemString(row, "colno", dr["INSTORAGEID_VCHR"].ToString());
                    this.m_objViewer.dw.SetItemString(row, "colindate", DateTime.Parse(dr["INSTORAGEDATE_DAT"].ToString()).ToString("yyyy-MM-dd"));// HH:mm:ss"));
                }
                this.m_objViewer.dw.SetRedrawOn();
                this.m_objViewer.dw.Refresh();
                //this.m_objViewer.dw.PrintProperties.Preview = true;
                //this.m_objViewer.dw.PrintProperties.ShowPreviewRulers = true;
                if (!dt.Columns.Contains("SortRowNo"))
                {
                    dt.Columns.Add("SortRowNo", typeof(long));
                }
                m_mthAddTotalSumRow(dt);

                DataGridViewRow dgvr = null;
                for (int i2 = 1; i2 < m_objViewer.m_dgvInstorage.Rows.Count - 1; i2++)
                {
                    dgvr = m_objViewer.m_dgvInstorage.Rows[i2];
                    if (dgvr.Cells["m_dgvtxtMedid"].Value.ToString() == m_objViewer.m_dgvInstorage["m_dgvtxtMedid", i2 - 1].Value.ToString())
                    {
                        dgvr.Cells["m_dgvtxtMedName"].Value = "";
                        dgvr.Cells["m_dgvtxtSpec"].Value = "";
                        dgvr.Cells["m_dgvtxtUnit"].Value = "";
                        dgvr.Cells["m_dgvtxtProduct"].Value = "";
                    }
                }
            }
            else
            {
                MessageBox.Show(this.m_objViewer, "检索数据出错，请检查。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.m_objViewer.Cursor = Cursors.Default;
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
                    if (p_dtbResult.Columns[i1].ColumnName == "MEDICINENAME_VCH")
                    {
                        drAdd[i1] = "合计";
                    }
                    else if (p_dtbResult.Columns[i1].ColumnName == "UNITPRICE" || p_dtbResult.Columns[i1].ColumnName == "CALLSUM" || p_dtbResult.Columns[i1].ColumnName == "DIFFSUM" || 
                        (p_dtbResult.Columns[i1].ColumnName == "AMOUNT" && m_objViewer.m_txtMedicineCode.Tag != null && m_objViewer.m_txtMedicineCode.Tag.ToString() != ""))
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

        public void m_mthShowMedince(string strMedid)
        {
            if (string.IsNullOrEmpty(this.m_objViewer.txtStoreroom.Value))
            {
                MessageBox.Show(this.m_objViewer, "请先选择药房。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //DataTable dt;
            //long lngRes = objSvc.m_lngGetBaseMedicine(m_objViewer.m_blnForDrugStore,strMedid, this.m_objViewer.txtStoreroom.Value.ToString(), out dt);

            if (m_ctlMedQuery == null)
            {
                if (dtMedName == null || dtMedName.Rows.Count == 0)
                {
                    m_mthGetMedicine();
                }
                this.m_ctlMedQuery = new ctlQueryMedicintLeastElement(dtMedName);
                this.m_objViewer.Controls.Add(m_ctlMedQuery);

                int X = this.m_objViewer.m_txtMedicineCode.Location.X +5;
                int Y = this.m_objViewer.m_txtMedicineCode.Location.Y + this.m_objViewer.m_txtMedicineCode.Size.Height+103;
                m_ctlMedQuery.Location = new Point(X, Y);

                m_ctlMedQuery.ReturnInfo += new ReturnMedicineInfo(m_ctlRetureInfo);
                m_ctlMedQuery.CancelResult += new MecicineCancelAndReturn(m_ctlQueryMedicint_CancelResult);
                m_ctlMedQuery.RefreshMedicine += new RefreshMedicineInfo(m_ctlMedQuery_RefreshMedicine);
            }
            m_ctlMedQuery.Visible = true;
            m_ctlMedQuery.BringToFront();
            m_ctlMedQuery.Focus();
            m_ctlMedQuery.m_mthSetSearchText(strMedid);
        }

        private void m_ctlMedQuery_RefreshMedicine()
        {
            m_mthGetMedicine();
            m_ctlMedQuery.m_dtbMedicineInfo = dtMedName;
        }

        internal void m_ctlQueryMedicint_CancelResult()
        {
            this.m_objViewer.m_txtMedicineCode.Focus();
            m_ctlMedQuery.Visible = false;
            //this.m_objViewer.m_cmdSearch.Focus();
        }

        internal void m_ctlRetureInfo(clsMS_MedicintLeastElement_VO objVO)
        {
            if (m_objViewer.m_rbtSingle.Checked)
                this.m_objViewer.m_txtMedicineCode.Text = objVO.m_strMedicineName;
            else
                m_objViewer.m_txtMedicineCode.Text = objVO.m_strMedicineCode;
            this.m_objViewer.m_txtMedicineCode.Tag = objVO.m_strMedicineID;
            ///this.m_objViewer.m_cmdSearch.Focus();
        }

        #region 厂家查询
        /// <summary>
        /// 厂家查询
        /// </summary>
        /// <param name="p_strSearchCon"></param>
        internal void m_mthShowManufacturer(string p_strSearchCon)
        {
            if (m_ctlQueryManufacturer == null)
            {
                m_ctlQueryManufacturer = new ctlQueryVendor(this.m_objViewer.m_dtProduct);
                m_objViewer.Controls.Add(m_ctlQueryManufacturer);

                int X = m_objViewer.txtProduct.Location.X;
                int Y = m_objViewer.txtProduct.Location.Y + m_objViewer.txtProduct.Size.Height;

                m_ctlQueryManufacturer.Location = new System.Drawing.Point(X, Y+40);
                m_ctlQueryManufacturer.ReturnInfo += new ReturnVendorInfo(QueryManufacturer_ReturnInfo);
                m_ctlQueryManufacturer.CancelResult += new VendorCancelAndReturn(m_ctlQueryManufacturer_CancelResult);
            }
            m_ctlQueryManufacturer.BringToFront();
            m_ctlQueryManufacturer.m_mthSetSearchText(p_strSearchCon);
            m_ctlQueryManufacturer.Visible = true;
            m_ctlQueryManufacturer.Focus();
        }

        internal void m_ctlQueryManufacturer_CancelResult()
        {
            this.m_objViewer.txtProduct.Tag = null;
        }

        internal void QueryManufacturer_ReturnInfo(com.digitalwave.iCare.ValueObject.clsMS_Vendor MS_VO)
        {
            m_objViewer.txtProduct.Tag = null;
            if (MS_VO == null)
            {
                return;
            }

            m_objViewer.txtProduct.Tag = MS_VO.m_strVendorID;
            m_objViewer.txtProduct.Text = MS_VO.m_strVendorName;
            m_objViewer.m_txtMedicineCode.Focus();
        }
        #endregion

        public void m_mthFillMedType()
        {
            this.m_objViewer.txtTypecode.m_listView.Items.Clear();
            if (string.IsNullOrEmpty(this.m_objViewer.txtStoreroom.Value))
            {
                return;
            }           
            this.dtvMedType.RowFilter = "medicineroomid='" + this.m_objViewer.txtStoreroom.Value.ToString() + "'";          

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

        internal long m_lngGetTypeNameByID(string strInstorageType, out string m_strTypeName)
        {
            return objSvc.m_lngGetTypeNameByID(0, strInstorageType, out m_strTypeName);
        }

        #region 显示供应商查询
        /// <summary>
        /// 获取供应商信息
        /// </summary>
        /// <param name="p_dtbVendor"></param>
        internal void m_mthGetVendor(out DataTable p_dtbVendor)
        {
            long lngRes = objSvc.m_lngGetVendor(out p_dtbVendor);
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

                int X = m_objViewer.m_txtReceiveDept.Location.X;
                int Y = m_objViewer.m_txtReceiveDept.Location.Y + m_objViewer.m_txtReceiveDept.Size.Height;

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
            m_objViewer.m_txtReceiveDept.Tag = null;
            if (MS_VO == null)
            {
                return;
            }

            m_objViewer.m_txtReceiveDept.Tag = MS_VO.m_strVendorID;
            m_objViewer.m_txtReceiveDept.Text = MS_VO.m_strVendorName;
        }
        #endregion

        internal void m_lngGetDeptIDByStoreID(string strInstorageType, out string m_strDeptId)
        {
            objSvc.m_lngGetDeptIDByStoreID(strInstorageType,out m_strDeptId);
        }

        internal void m_mthGetRoomid(out DataTable dtTemp)
        {
            objSvc.m_lngGetRoomid(out dtTemp);
        }

        internal void m_mthGetMedicine()
        {
            string strMedid = string.Empty;
            dtMedName = new DataTable();
            long lngRes = objSvc.m_lngGetBaseMedicine(m_objViewer.m_blnForDrugStore,false, strMedid, this.m_objViewer.txtStoreroom.Value.ToString(), out dtMedName);
        }

        internal long m_lngCheckIsHospital(string p_strDrugStoreID, out bool p_blnIsHospital)
        {
            return objSvc.m_lngCheckIsHospital(p_strDrugStoreID, out p_blnIsHospital);
        }
    }
}
