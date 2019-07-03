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
    public class clsCtl_RptOutstorageStat:com.digitalwave.GUI_Base.clsController_Base
    {
        private frmRptOutstorageStat m_objViewer;
        private clsDcl_OutStorageDetailReport objSvc;
        private ctlQueryMedicintLeastElement m_ctlMedQuery;
        private DataView dtvMedType;
        private ctlQueryVendor m_ctlQueryManufacturer;
        private DataTable dtMedName;

        public clsCtl_RptOutstorageStat()
        {
            objSvc = new clsDcl_OutStorageDetailReport();
        }

        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmRptOutstorageStat)frmMDI_Child_Base_in;
        }

        public void m_mthInit()
        {
            this.m_objViewer.dw.LibraryList = clsPublic.PBLPath;
            this.m_objViewer.dw.DataWindowObject = "outstorage_detailreport_3yuan";
            //this.m_objViewer.dw.PrintProperties.Preview = true;
            //this.m_objViewer.dw.PrintProperties.ShowPreviewRulers = true;
            this.m_objViewer.dw.InsertRow(0);
            DataTable dtEmp;
            DataTable dtEmpToid = new DataTable();
            DataTable dtVonder;
            DataTable dtMedType;
            long lngRes = objSvc.m_lngGetExptypeAndVendor(m_objViewer.m_blnForDrugStore, out dtEmp, out dtVonder, out dtMedType);

            if (m_objViewer.m_strRoomidArr.Length > 0)
            {
                if (dtEmp.Rows.Count > 0)
                {
                    dtEmpToid = dtEmp.Clone();
                    DataRow dr = null;
                    int iRowCount = dtEmp.Rows.Count;
                    int iLength = m_objViewer.m_strRoomidArr.Length;
                    dtEmpToid.BeginLoadData();

                    for (int i = 0; i < iLength; i++)
                    {
                        for (int j = 0; j < iRowCount; j++)
                        {
                            dr = dtEmp.Rows[j];
                            if (m_objViewer.m_strRoomidArr[i].ToString().Trim() == dr["medicineroomid"].ToString().Trim())
                            {
                                dtEmpToid.LoadDataRow(dr.ItemArray, true);
                            }
                        }
                    }
                    dtEmpToid.EndLoadData();
                    dtEmpToid.AcceptChanges();
                }
            }

            clsColumns_VO[] column2 = new clsColumns_VO[] { new clsColumns_VO("类别名称", "medicinetypename_vchr", HorizontalAlignment.Left, 145) };
            this.m_objViewer.txtTypecode.m_mthInitListView(column2);
            this.m_objViewer.txtTypecode.m_dtbDataSourse = dtMedType;

            clsColumns_VO[] column3 = new clsColumns_VO[] { new clsColumns_VO("库房名称", "medicineroomname", HorizontalAlignment.Left, 145) };
            this.m_objViewer.txtStoreroom.m_mthInitListView(column3);
            if (m_objViewer.m_strRoomidArr.Length > 0)
            {
                this.m_objViewer.txtStoreroom.m_dtbDataSourse = dtEmpToid;
            }
            else
            {
                this.m_objViewer.txtStoreroom.m_dtbDataSourse = dtEmp;
            }
            this.m_objViewer.txtStoreroom.m_mthFillData();

            if (m_objViewer.m_strRoomidArr.Length > 0)
            {
                DataRow drRoom = null;
                int iCount = dtEmp.Rows.Count;
                for (int iRow = 0; iRow < iCount; iRow++)
                {
                    drRoom = dtEmp.Rows[iRow];
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
                this.m_objViewer.txtStoreroom.Text = dtEmp.Rows[0]["medicineroomname"].ToString().Trim();
                this.m_objViewer.txtStoreroom.Value = dtEmp.Rows[0]["medicineroomid"].ToString().Trim();
            }

            this.dtvMedType = new DataView(dtMedType);
            this.m_objViewer.m_dtProduct = dtVonder;

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
                dvTemp.RowFilter = " flag_int = 1 and storgeflag_int <> 0";
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

                int X = this.m_objViewer.m_txtMedicineCode.Location.X+2;
                int Y = this.m_objViewer.m_txtMedicineCode.Location.Y + this.m_objViewer.m_txtMedicineCode.Size.Height+41;
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
        }

        internal void m_ctlRetureInfo(clsMS_MedicintLeastElement_VO objVO)
        {
            this.m_objViewer.m_txtMedicineCode.Text = objVO.m_strMedicineName;
            this.m_objViewer.m_txtMedicineCode.Tag = objVO.m_strMedicineID;
            m_objViewer.m_txtDept.Focus();
        }

        public void m_mthSearch()
        {
            this.m_objViewer.Cursor = Cursors.WaitCursor;
            DateTime dtm1 = Convert.ToDateTime(this.m_objViewer.m_dtpSearchBeginDate.Text);
            DateTime dtm2 = Convert.ToDateTime(this.m_objViewer.m_dtpSearchEndDate.Text);
            DataTable dt;

            string Medid = "";
            string strMedTypeCode = "";
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
            //    Medid = Convert.ToString(m_objViewer.m_txtMedicineCode.Tag);
            //    //}
            //}
            string strMedName = this.m_objViewer.m_txtMedicineCode.Text.Trim();
            bool blnIsExists = false;
            if (this.m_objViewer.m_txtMedicineCode.Tag != null && this.m_objViewer.m_txtMedicineCode.Text.Trim() != "")
            {
                int iRCount = dtMedName.Rows.Count;
                DataRow dr = null;
                for (int i = 0; i < iRCount; i++)
                {
                    dr = dtMedName.Rows[i];
                    if (dr["medicinename_vchr"].ToString().Trim().Equals(strMedName))
                    {
                        Medid = Convert.ToString(this.m_objViewer.m_txtMedicineCode.Tag);
                        blnIsExists = true;
                        break;
                    }
                }
                if (!blnIsExists)
                {
                    this.m_objViewer.m_dgvOutstorage.DataSource = null;

                    this.m_objViewer.dw.Reset();
                    this.m_objViewer.dw.Refresh();
                    this.m_objViewer.dw.InsertRow(0);
                    MessageBox.Show(this.m_objViewer, "未能找到出库数据，请修改查询条件。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.m_objViewer.Cursor = Cursors.Default;
                    return;
                }
            }
            if (!string.IsNullOrEmpty(this.m_objViewer.txtTypecode.Value))
            {
                strMedTypeCode = this.m_objViewer.txtTypecode.Value.ToString();
            }

            string strDept = this.m_objViewer.m_txtDept.Text.Trim() != string.Empty ? this.m_objViewer.m_txtDept.StrItemId.Trim() : string.Empty;
            long lngRes = 0;
            if (m_objViewer.m_blnForDrugStore)
            {
                lngRes = objSvc.m_lngGetDrugStoreOutstorageStat(false,Medid, this.m_objViewer.m_cboType.SelectedValue.ToString(), strMedTypeCode, this.m_objViewer.txtStoreroom.Value.ToString(), strDept, dtm1, dtm2,false, out dt);
            }
            else
            {
                lngRes = objSvc.m_lngOutstorageStat(false,Medid, this.m_objViewer.m_cboType.SelectedValue.ToString(), strMedTypeCode, this.m_objViewer.txtStoreroom.Value.ToString(), strDept, dtm1, dtm2, out dt);
            }
            if (lngRes > 0)
            {
                this.m_objViewer.m_dgvOutstorage.DataSource = dt;

                double dblRetailPrice = 0d;
                double dblPriceSum = 0d;
                double dblAmount = 0d;
                double dblTotalAmount = 0d;
                int iRowCount = dt.Rows.Count;
                DataRow drTemp = null;
                for (int i = 0; i < iRowCount; i++)
                {
                    drTemp = dt.Rows[i];
                    double.TryParse(Convert.ToString(drTemp["retailsum"]), out dblRetailPrice);
                    dblPriceSum += Convert.ToDouble(dblRetailPrice.ToString("0.0000"));
                    double.TryParse(Convert.ToString(drTemp["netamount_int"]), out dblAmount);
                    dblTotalAmount += Convert.ToDouble(dblAmount.ToString("0.0000"));
                }
                if (Convert.ToString(m_objViewer.m_txtMedicineCode.Tag) == string.Empty || Convert.ToString(m_objViewer.m_txtMedicineCode.Text) == string.Empty)
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
                this.m_objViewer.m_lblPriceSum.Text = dblPriceSum.ToString("#,##0.0000")+"元";
                drTemp = null;

                if (dt == null || dt.Rows.Count == 0)
                {
                    this.m_objViewer.dw.Reset();
                    this.m_objViewer.dw.Refresh();
                    this.m_objViewer.dw.InsertRow(0);
                    MessageBox.Show(this.m_objViewer, "未能找到出库数据，请修改查询条件。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.m_objViewer.Cursor = Cursors.Default;
                    return;
                }
                this.m_objViewer.dw.Reset();
                this.m_objViewer.dw.SetRedrawOff();
                string strDeptName = string.Empty;
                if (this.m_objViewer.m_txtDept.Text.Trim() == "")
                {
                    strDept = "全部";
                }
                else
                {
                    strDept = this.m_objViewer.m_txtDept.Text.Trim();
                }
                this.m_objViewer.dw.Modify("t_hospitalname.text='" + this.m_objComInfo.m_strGetHospitalTitle() + "'");
                this.m_objViewer.dw.Modify("t_outdept.text='" + "(" + this.m_objViewer.txtStoreroom.Text.Trim() + ")" + "'");
                this.m_objViewer.dw.Modify("t_deptname.text='领用部门：" + strDept + "'");
                this.m_objViewer.dw.Modify("t_time.text='统计日期：" + dtm1.ToString("yyyy-MM-dd HH:mm:ss") + " 至 " + dtm2.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                string strOutType = dt.Rows[0]["typename_vchr"].ToString();
                if (m_objViewer.m_cboType.SelectedValue.ToString() == "")
                    strOutType = "全部出库";
                string strTypeName = "";
                if (string.IsNullOrEmpty(this.m_objViewer.txtTypecode.Value))
                {
                    strTypeName = "全部";
                }
                else
                {
                    strTypeName = this.m_objViewer.txtTypecode.Text;
                }
                this.m_objViewer.dw.Modify("t_title.text='" + this.m_objViewer.Text.Trim() + "（" + strOutType + "）'");
                this.m_objViewer.dw.Modify("t_type.text='药品分类：" + strTypeName + "'");

                string strTmpMedName = "";
                DataRow dr = null;
                for (int k = 0; dt != null && k < dt.Rows.Count; k++)
                {
                    dr = dt.Rows[k];
                    int row = this.m_objViewer.dw.InsertRow(0);
                    if (strTmpMedName == dr["medicineid_chr"].ToString())
                    {
                        this.m_objViewer.dw.SetItemString(row, "medname", "");
                    }
                    else
                    {
                        this.m_objViewer.dw.SetItemString(row, "medname", dr["medicinename_vch"].ToString());
                        strTmpMedName = dr["medicineid_chr"].ToString();
                    }
                    this.m_objViewer.dw.SetItemString(row, "medspec", dr["medspec_vchr"].ToString());
                    this.m_objViewer.dw.SetItemString(row, "medunit", dr["opunit_chr"].ToString());
                    this.m_objViewer.dw.SetItemString(row, "medpud", dr["productorid_chr"].ToString());
                    this.m_objViewer.dw.SetItemDecimal(row, "medamount", Convert.ToDecimal(Convert.ToDouble(dr["netamount_int"]).ToString("0.00")));
                    this.m_objViewer.dw.SetItemDecimal(row, "retailmoney", Convert.ToDecimal(Convert.ToDouble(dr["retailsum"]).ToString("0.0000")));
                    //this.m_objViewer.dw.SetItemString(row, "retailmoney", dr["retailsum"].ToString());
                    this.m_objViewer.dw.SetItemString(row, "invoicecode", dr["outstorageid_vchr"].ToString());
                    this.m_objViewer.dw.SetItemString(row, "outdate", DateTime.Parse(dr["outstoragedate_dat"].ToString()).ToString("yyyy-MM-dd HH:mm:ss"));
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
                    if (p_dtbResult.Columns[i1].ColumnName.ToLower() == "medicinename_vch")
                    {
                        drAdd[i1] = "合计";
                    }
                    else if (p_dtbResult.Columns[i1].ColumnName.ToLower() == "retailsum" || (p_dtbResult.Columns[i1].ColumnName.ToLower() == "netamount_int" && Convert.ToString(this.m_objViewer.m_txtMedicineCode.Tag).Length > 0))
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

        public void m_mthChooseMedType()
        {
            if (string.IsNullOrEmpty(this.m_objViewer.txtStoreroom.Value))
            {
                this.m_objViewer.txtTypecode.m_listView.Items.Clear();
            }
            else
            {
                this.dtvMedType.RowFilter = "medicineroomid='" + this.m_objViewer.txtStoreroom.Value.ToString() + "'";

                DataTable dtTmp = dtvMedType.ToTable();
                DataRow drAll = dtTmp.NewRow();
                drAll["medicinetypeid_chr"] = "";
                drAll["medicinetypename_vchr"] = "全部";
                drAll["medicineroomid"] = "-1";
                dtTmp.BeginLoadData();
                dtTmp.Rows.Add(drAll);
                dtTmp.EndLoadData();

                this.m_objViewer.txtTypecode.m_dtbDataSourse = dtTmp;
                this.m_objViewer.txtTypecode.m_mthFillData();
            }
        }
        
        internal long m_lngGetTypeNameByID(string p_stroutType, out string m_strTypeName)
        {
            return objSvc.m_lngGetTypeNameByID(1, p_stroutType, out m_strTypeName);
        }

        internal void m_mthGetRoomid(out DataTable dtTemp)
        {
            objSvc.m_lngGetRoomid(out dtTemp);
        }

        internal void m_mthGetMedicine()
        {
            dtMedName = new DataTable();
            string strMedid = string.Empty;
            long lngRes = objSvc.m_lngGetBaseMedicine( strMedid, this.m_objViewer.txtStoreroom.Value.ToString(), out dtMedName);
        }

        #region 获取领用部门信息
        /// <summary>
        /// 获取领用部门信息
        /// </summary>
        /// <param name="p_dtbExportDept"></param>
        internal void m_mthGetExportDept(out DataTable p_dtbExportDept)
        {
            if (m_objViewer.m_blnForDrugStore)
            {
                com.digitalwave.iCare.gui.HIS.clsPub.m_mthBorrowDeptInfo(out p_dtbExportDept);            
            }
            else
            {
                objSvc.m_lngGetExportDept(out p_dtbExportDept);
            }
        }
        #endregion


    }
}
