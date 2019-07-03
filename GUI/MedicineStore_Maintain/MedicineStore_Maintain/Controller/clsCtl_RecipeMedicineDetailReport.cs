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
    public class clsCtl_RecipeMedicineDetailReport : com.digitalwave.GUI_Base.clsController_Base
    {
        private frmRecipeMedicineDetailReport m_objViewer;
        private clsDcl_RecipeDetailReport m_objDomain;
        private ctlQueryMedicintLeastElement m_ctlMedQuery;
        public clsCtl_RecipeMedicineDetailReport()
        {
            m_objDomain = new clsDcl_RecipeDetailReport();
        }

        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmRecipeMedicineDetailReport)frmMDI_Child_Base_in;
        }

        public void m_mthInit()
        {
            this.m_objViewer.dw.LibraryList = clsPublic.PBLPath;
            this.m_objViewer.dw.DataWindowObject = "ms_recipedetailreport";
            this.m_objViewer.dw.InsertRow(0);
        }

        public void m_mthSearch()
        {
            if (Convert.ToString(m_objViewer.m_txtMedicineCode.Tag) == string.Empty)
            {
                MessageBox.Show("请先选择药品！", "注意...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_objViewer.m_txtMedicineCode.Focus();
                return;
            }
            this.m_objViewer.Cursor = Cursors.WaitCursor;
            DateTime dtm1 = Convert.ToDateTime(this.m_objViewer.m_dtpSearchBeginDate.Text);
            DateTime dtm2 = Convert.ToDateTime(this.m_objViewer.m_dtpSearchEndDate.Text);
            DataTable dt;

            long lngRes = m_objDomain.m_lngGetRecipeDetailReport(m_objViewer.m_cboStorageName.SelectItemValue.ToString(), dtm1, dtm2, Convert.ToString(m_objViewer.m_txtMedicineCode.Tag), out dt);
            if (lngRes > 0)
            {
                this.m_objViewer.m_dgvMedDetail.DataSource = dt;

                double dblRetailPrice = 0d;
                double dblPriceSum = 0d;
                int iRowCount = dt.Rows.Count;
                DataRow drTemp = null;
                for (int i = 0; i < iRowCount; i++)
                {
                    drTemp = dt.Rows[i];
                    double.TryParse(Convert.ToString(drTemp["sumprice"]), out dblRetailPrice);
                    dblPriceSum += dblRetailPrice;
                }
                this.m_objViewer.m_lblPriceSum.Text = dblPriceSum.ToString("#,##0.0000") + "元";
                drTemp = null;

                if (dt == null || dt.Rows.Count == 0)
                {

                    this.m_objViewer.dw.Reset();
                    this.m_objViewer.dw.Refresh();
                    this.m_objViewer.dw.InsertRow(0);
                    MessageBox.Show(this.m_objViewer, "未能找到数据。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.m_objViewer.Cursor = Cursors.Default;
                    return;
                }

                this.m_objViewer.dw.Reset();
                this.m_objViewer.dw.SetRedrawOff();

                this.m_objViewer.dw.Modify("t_title.text='" + this.m_objComInfo.m_strGetHospitalTitle() + "'");
                this.m_objViewer.dw.Modify("m_strdate.text='" + dtm1.ToString("yyyy-MM-dd HH:mm:ss") + " ---- " + dtm2.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                this.m_objViewer.dw.Modify("strstoragename.text='" + m_objViewer.m_cboStorageName.SelectItemText + "'");
                this.m_objViewer.dw.Modify("m_strmedicinecode.text='" + this.m_objViewer.m_btnQuery.Tag.ToString() + "'");
                this.m_objViewer.dw.Modify("t_strmedicinename.text='" + this.m_objViewer.m_txtMedicineCode.Text + "'");
                this.m_objViewer.dw.Retrieve(dt);
                this.m_objViewer.dw.SetRedrawOn();
                this.m_objViewer.dw.Refresh();

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
                    if (p_dtbResult.Columns[i1].ColumnName.ToLower() == "patientcardid_chr")
                    {
                        drAdd[i1] = "合计";
                    }
                    else if (p_dtbResult.Columns[i1].ColumnName.ToLower() == "sumprice" || p_dtbResult.Columns[i1].ColumnName.ToLower() == "amount_int")
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

        internal long m_lngGetStoreNameByID(string p_strId, out string p_strName)
        {
            return m_objDomain.m_lngGetStoreNameByID(p_strId, out p_strName);
        }

        internal long m_lngGetDeptIDByDrugID(string m_strDrugID, out string m_strDeptID)
        {
            return m_objDomain.m_lngGetDeptIDByDrugID(m_strDrugID, out m_strDeptID);
        }

        internal long m_mthGetMedBaseInfo(string m_strDeptId, out DataTable m_dtMedicine)
        {
            return m_objDomain.m_mthGetMedBaseInfo(m_strDeptId, out m_dtMedicine);
        }

        public void m_mthShowMedince(string strMedid)
        {
            if (m_ctlMedQuery == null)
            {
                this.m_ctlMedQuery = new ctlQueryMedicintLeastElement(this.m_objViewer.m_dtMedince);
                this.m_objViewer.Controls.Add(m_ctlMedQuery);

                int X = this.m_objViewer.m_txtMedicineCode.Location.X;
                int Y = this.m_objViewer.m_txtMedicineCode.Location.Y + this.m_objViewer.m_txtMedicineCode.Size.Height*2;
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
            m_mthGetMedBaseInfo(m_objViewer.m_cboStorageName.SelectItemValue, out m_objViewer.m_dtMedince);
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
            this.m_objViewer.m_btnQuery.Tag = objVO.m_strMedicineCode;
        }


        #region 库名
        /// <summary>
        /// 库名
        /// </summary>
        /// <param name="m_dtStorageName"></param>
        internal void m_mthGetStorageName(out DataTable m_dtStorageName)
        {
            clsDcl_RptInstorageBill objDomain = new clsDcl_RptInstorageBill();
            objDomain.m_mthGetStorageName(0,out m_dtStorageName);
        }
        #endregion
    }
}
