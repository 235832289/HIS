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
using com.digitalwave.iCare.gui.HIS;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 药品统计
    /// </summary>
    public class clsCtl_RptRecipeOutSumStat : com.digitalwave.GUI_Base.clsController_Base
    {
        private frmRptRecipeOutSumStat m_objViewer;
        private clsDcl_RptRecipeOutSumStat m_objDomain;
        private DataView dtvMedType;
        private ctlQueryMedicintLeastElement m_ctlMedQuery;
        /// <summary>
        /// 领域层变量
        /// </summary>
        public clsCtl_RptRecipeOutSumStat()
        {
            m_objDomain = new clsDcl_RptRecipeOutSumStat();
        }

        /// <summary>
        /// 窗体重构
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmRptRecipeOutSumStat)frmMDI_Child_Base_in;
        }

        /// <summary>
        /// 窗体初始化
        /// </summary>
        public void m_mthInit()
        {
            this.m_objViewer.dw.LibraryList = clsPublic.PBLPath;
            this.m_objViewer.dw.DataWindowObject = "ms_recipeoutsumstat";
            this.m_objViewer.dw.InsertRow(0);
            //this.m_objViewer.dw.PrintProperties.Preview = true;
            //this.m_objViewer.dw.PrintProperties.ShowPreviewRulers = true;

            DataTable dtMedType;
            long lngRes = m_objDomain.m_lngGetMedicineType(out dtMedType);
            this.dtvMedType = new DataView(dtMedType);
            clsColumns_VO[] column2 = new clsColumns_VO[] { new clsColumns_VO("类别名称", "medicinetypename_vchr", HorizontalAlignment.Left, 145) };
            this.m_objViewer.txtTypecode.m_mthInitListView(column2);
            this.m_objViewer.txtTypecode.m_dtbDataSourse = null;
        }
        /// <summary>
        /// 查询操作
        /// </summary>
        public void m_mthSearch()
        {
            this.m_objViewer.Cursor = Cursors.WaitCursor;
            DateTime dtm1 = Convert.ToDateTime(this.m_objViewer.m_dtpSearchBeginDate.Text);
            DateTime dtm2 = Convert.ToDateTime(this.m_objViewer.m_dtpSearchEndDate.Text);
            DataTable dt = null;
            DataTable dtUnionMedicineSum = null;

            string strMedTypeCode = "";
            string strMedName = this.m_objViewer.m_txtMedicineCode.Text.Trim();
            string strMedicineId = string.Empty;
            bool blnName = false;
            if (!string.IsNullOrEmpty(this.m_objViewer.txtTypecode.Value))
            {
                strMedTypeCode = this.m_objViewer.txtTypecode.Value.ToString();
            }
            if ((!string.IsNullOrEmpty(Convert.ToString(m_objViewer.m_txtMedicineCode.Tag))) && this.m_objViewer.m_txtMedicineCode.Text.Trim() != "")
            {
                for (int i = 0; i < this.m_objViewer.m_dtMedince.Rows.Count; i++)
                {
                    if (m_objViewer.m_dtMedince.Rows[i]["medicinename_vchr"].ToString().Trim() == strMedName)
                    {
                        strMedicineId = Convert.ToString(m_objViewer.m_txtMedicineCode.Tag);
                        blnName = true;
                        break;
                    }
                }
                if (!blnName)
                {
                    this.m_objViewer.m_dgvOutSumStat.DataSource = null;
                    this.m_objViewer.dw.Reset();
                    this.m_objViewer.dw.Refresh();
                    this.m_objViewer.dw.InsertRow(0);
                    MessageBox.Show(this.m_objViewer, "未能找到出库数据。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.m_objViewer.Cursor = Cursors.Default;
                    return;
                }
            }
              long lngRes = -1;
              if (this.m_objViewer.m_strDrugID == "0001" && this.m_objViewer.m_strCenterDeptID != "0003")
              {
                  lngRes = m_objDomain.m_lngGetRecipeOutSumStat(m_objViewer.m_strDeptID, dtm1, dtm2, strMedTypeCode, strMedicineId, out dt);
              }
              if (this.m_objViewer.m_strDrugID == "0001" && this.m_objViewer.m_strCenterDeptID == "0003")
              {
                  this.m_objViewer.m_strDrugStoreName = "门诊(住院)西药房";
                  this.m_objViewer.m_dgvOutSumStat.Columns["m_dgvtxtassistcode_chr"].DataPropertyName = "assistcode_chr";
                  this.m_objViewer.m_dgvOutSumStat.Columns["m_dgvtxtmedicinename"].DataPropertyName = "medicinename_vchr";
                  this.m_objViewer.m_dgvOutSumStat.Columns["m_dgvSpec"].DataPropertyName = "medspec_vchr";
                  this.m_objViewer.m_dgvOutSumStat.Columns["m_dgvtxtipunit_chr"].DataPropertyName = "ipunit_chr";
                  this.m_objViewer.m_dgvOutSumStat.Columns["m_dgvtxtproductorid_chr"].DataPropertyName = "productorid_chr";
                  this.m_objViewer.m_dgvOutSumStat.Columns["m_dgvtxtipamount"].DataPropertyName = "ipamount";
                  this.m_objViewer.m_dgvOutSumStat.Columns["m_dgvtxtsumprice"].DataPropertyName = "sumprice";
                  this.m_objViewer.m_dgvOutSumStat.Columns["unitprice_mny"].DataPropertyName = "unitprice_mny";
                  lngRes = m_objDomain.m_lngGetUnionMedSumStat(dtm1, dtm2, out dt);
              }

            if (this.m_objViewer.m_strCenterDeptID == "0003"&&this.m_objViewer.m_strDrugID!="0001")
            {
                lngRes = m_objDomain.m_lngGetPutMedicineSumStat(m_objViewer.m_strCenterDeptID, dtm1, dtm2, strMedTypeCode, strMedicineId, out dt);
                  if (dt.Rows.Count == 0)
                  {
                      this.m_objViewer.m_dgvOutSumStat.DataSource = null;
                      MessageBox.Show("药品没在摆药记录", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                      this.m_objViewer.m_dgvOutSumStat.Refresh();
                      this.m_objViewer.Cursor = Cursors.Default;
                      return;
                  }
                    this.m_objViewer.m_dgvOutSumStat.Columns["m_dgvtxtassistcode_chr"].DataPropertyName = "assistcode_chr";
                    this.m_objViewer.m_dgvOutSumStat.Columns["m_dgvtxtmedicinename"].DataPropertyName = "medname_vchr";
                    this.m_objViewer.m_dgvOutSumStat.Columns["m_dgvSpec"].DataPropertyName = "medspec_vchr";
                    this.m_objViewer.m_dgvOutSumStat.Columns["m_dgvtxtipunit_chr"].DataPropertyName = "unit_vchr";
                    this.m_objViewer.m_dgvOutSumStat.Columns["m_dgvtxtproductorid_chr"].DataPropertyName = "productorid_chr";
                    this.m_objViewer.m_dgvOutSumStat.Columns["m_dgvtxtipamount"].DataPropertyName = "get_dec";
                    this.m_objViewer.m_dgvOutSumStat.Columns["m_dgvtxtsumprice"].DataPropertyName = "account_mny";
                    this.m_objViewer.m_dgvOutSumStat.Columns["deptName"].DataPropertyName = "deptname_vchr";
                    this.m_objViewer.m_dgvOutSumStat.Columns["unitprice_mny"].DataPropertyName = "unitprice_mny";
                    DataView dv = dt.DefaultView;
                    if (dt.Rows.Count > 0)
                    {
                        double dblTempSum = 0d;
                        DataRow drAdd = dt.NewRow();
                        for (int i1 = 0; i1 < dt.Columns.Count; i1++)
                        {
                            dblTempSum = 0d;
                            if (dt.Columns[i1].ColumnName.ToLower() == "medname_vchr")
                            {
                                drAdd[i1] = "合计";
                            }

                            if (dt.Columns[i1].ColumnName.ToLower() == "get_dec")
                            {
                                for (int i2 = 0; i2 < dt.Rows.Count; i2++)
                                {
                                    dblTempSum += Convert.ToDouble(dt.Rows[i2][i1]);
                                }
                                drAdd[i1] = dblTempSum;
                            }

                            if (dt.Columns[i1].ColumnName.ToLower() == "account_mny")
                            {
                                for (int i2 = 0; i2 < dt.Rows.Count; i2++)
                                {
                                    dblTempSum += Convert.ToDouble(dt.Rows[i2][i1]);
                                }
                                drAdd[i1] = dblTempSum;
                            }
                        }
                        dt.Rows.Add(drAdd);
                        dt.AcceptChanges();
                    }

                    dt = dv.ToTable();
                    this.m_objViewer.m_dgvOutSumStat.DataSource = dt;
                    this.m_objViewer.dw.DataWindowObject = "putmedicineoutsum";
                    this.m_objViewer.dw.Reset();
                    this.m_objViewer.dw.SetRedrawOff();
                    string m_datetime = "时间: "+this.m_objViewer.m_dtpSearchBeginDate.Value.ToShortDateString() +"至"+ this.m_objViewer.m_dtpSearchEndDate.Value.ToShortDateString();
                    this.m_objViewer.dw.Modify("t_date.text='" +m_datetime+ "'");
                    this.m_objViewer.dw.Retrieve(dt);
                    this.m_objViewer.dw.SetRedrawOn();
                    this.m_objViewer.dw.Refresh();
                    this.m_objViewer.Cursor = Cursors.Default;
                    return;
            }
            if (lngRes > 0)
                {
                    //过滤数量金额是0的
                    DataView dvResult;
                    dvResult = dt.DefaultView;
                    dvResult.RowFilter = "ipamount <> 0";
                    dt = dvResult.ToTable();
                    this.m_objViewer.m_dgvOutSumStat.DataSource = dt;

                    double dblRetailPrice = 0d;
                    double dblPriceSum = 0d;
                    int iRowCount = dt.Rows.Count;
                    DataRow drTemp = null;
                    if (this.m_objViewer.m_strDrugID == "0001")
                {
                    for (int i = 0; i < iRowCount; i++)
                    {
                        drTemp = dt.Rows[i];
                        double.TryParse(Convert.ToString(drTemp["sumprice"]), out dblRetailPrice);
                        dblPriceSum += dblRetailPrice;
                    }
                }
                    this.m_objViewer.m_lblPriceSum.Text = dblPriceSum.ToString("#,##0.0000") + "元";
                    drTemp = null;
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        this.m_objViewer.dw.Reset();
                        this.m_objViewer.dw.Refresh();
                        this.m_objViewer.dw.InsertRow(0);
                        MessageBox.Show(this.m_objViewer, "未能找到出库数据。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.m_objViewer.Cursor = Cursors.Default;
                        return;
                    }

                    this.m_objViewer.dw.Reset();
                    this.m_objViewer.dw.SetRedrawOff();

                    this.m_objViewer.dw.Modify("t_title.text='" + this.m_objComInfo.m_strGetHospitalTitle() + "'");
                    this.m_objViewer.dw.Modify("m_strdate.text='" + dtm1.ToString("yyyy-MM-dd HH:mm:ss") + " ---- " + dtm2.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                    this.m_objViewer.dw.Modify("m_strstoragename.text='" + m_objViewer.m_strDrugStoreName + "'");
                    if (strMedTypeCode == "-1" || strMedTypeCode == "")
                    {
                        this.m_objViewer.dw.Modify("t_strmedicinetypename.text='全部'");
                    }
                    else
                    {
                        this.m_objViewer.dw.Modify("t_strmedicinetypename.text='" + m_objViewer.txtTypecode.Text + "'");
                    }
                    this.m_objViewer.dw.Retrieve(dt);
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
                double dbTop10=0;
                double dbTop20 = 0;
                DataRow drAdd = p_dtbResult.NewRow();
                DataRow drAddTop10=p_dtbResult.NewRow();
                DataRow drAddTop20 = p_dtbResult.NewRow();
                for (int i1 = 0; i1 < p_dtbResult.Columns.Count; i1++)
                {
                    dblTempSum = 0d;
                    if (p_dtbResult.Columns[i1].ColumnName.ToLower() == "medicinename_vchr")
                    {
                        drAdd[i1] = "合计";
                        drAddTop10[i1] = "小计[前十]";
                        drAddTop20[i1] = "小计[前二十]";
                    }
                    else if (p_dtbResult.Columns[i1].ColumnName.ToLower() == "sumprice" || (!string.IsNullOrEmpty(Convert.ToString(m_objViewer.m_txtMedicineCode.Tag)) && p_dtbResult.Columns[i1].ColumnName.ToLower() == "ipamount"))
                    {
                        if (p_dtbResult.Rows.Count>10)
                        {
                            for (int intTop10 = 0; intTop10 < 10; intTop10++)
                           {
                            dbTop10 += Convert.ToDouble(p_dtbResult.Rows[intTop10][i1]);
                           }
                           drAddTop10[i1] = dbTop10;
                        }
                        if (p_dtbResult.Rows.Count > 20)
                        {
                            for (int intTop20 = 0; intTop20< 20; intTop20++)
                            {
                                dbTop20 += Convert.ToDouble(p_dtbResult.Rows[intTop20][i1]);
                            }
                            drAddTop20[i1] = dbTop20;
                        }
                        for (int i2 = 0; i2 < p_dtbResult.Rows.Count; i2++)
                        {
                            dblTempSum += Convert.ToDouble(p_dtbResult.Rows[i2][i1]);
                        }
                        drAdd[i1] = dblTempSum;
                    }
                }
                p_dtbResult.Rows.Add(drAddTop10);
                p_dtbResult.Rows.Add(drAddTop20);
                p_dtbResult.Rows.Add(drAdd);
                p_dtbResult.AcceptChanges();
            }
        }

        public void m_mthFillMedType()
        {
            this.m_objViewer.txtTypecode.m_listView.Items.Clear();
            DataTable dtValue = dtvMedType.ToTable();
            DataRow drTmp = dtValue.NewRow();
            drTmp["medicinetypeid_chr"] = "-1";
            drTmp["medicinetypename_vchr"] = "全部";
            dtValue.BeginLoadData();
            dtValue.Rows.Add(drTmp);
            dtValue.EndLoadData();

            this.m_objViewer.txtTypecode.m_dtbDataSourse = dtValue;
            this.m_objViewer.txtTypecode.m_mthFillData();
        }

        internal long m_lngGetStoreNameByID(string p_strId, out string p_strName)
        {
            return m_objDomain.m_lngGetStoreNameByID(p_strId, out p_strName);
        }

        internal long m_lngGetDeptIDByDrugID(string m_strDrugID, out string m_strDeptID)
        {
            return m_objDomain.m_lngGetDeptIDByDrugID(m_strDrugID, out m_strDeptID);
        }

        internal long m_mthGetMedBaseInfo(string m_strDeptId,out DataTable m_dtMedicine)
        {
            return m_objDomain.m_mthGetMedBaseInfo(m_strDeptId, out m_dtMedicine);
        }

        public void m_mthShowMedince(string strMedid)
        {
            if (m_ctlMedQuery == null)
            {
                this.m_ctlMedQuery = new ctlQueryMedicintLeastElement(this.m_objViewer.m_dtMedince);
                this.m_objViewer.Controls.Add(m_ctlMedQuery);

                int X = this.m_objViewer.m_dtpSearchEndDate.Location.X;
                int Y = this.m_objViewer.m_dtpSearchEndDate.Location.Y + this.m_objViewer.m_txtMedicineCode.Size.Height;
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
            m_mthGetMedBaseInfo(m_objViewer.m_strDrugID, out m_objViewer.m_dtMedince);
            m_ctlMedQuery.m_dtbMedicineInfo = m_objViewer.m_dtMedince;
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
        }

    }
}
