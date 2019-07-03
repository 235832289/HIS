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
    /// 精麻查询
    /// </summary>
    public class clsCtl_RecipeBySpecialMedicineReport : com.digitalwave.GUI_Base.clsController_Base
    {
        private frmRecipeBySpecialMedicineReport m_objViewer;
        private clsDcl_RecipeBySpecialMedicineReport m_objDomain;
        private ctlQueryMedicintLeastElement m_ctlMedQuery;

        /// <summary>
        /// 实例化Domain
        /// </summary>
        public clsCtl_RecipeBySpecialMedicineReport()
        {
            m_objDomain = new clsDcl_RecipeBySpecialMedicineReport();
        }

        /// <summary>
        /// 重构窗体
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmRecipeBySpecialMedicineReport)frmMDI_Child_Base_in;
        }

        public void m_mthInit()
        {
            this.m_objViewer.dw.LibraryList = Application.StartupPath + "\\pb_op.pbl";
            this.m_objViewer.dw.DataWindowObject = "d_op_recipebyspecialmedicine";
            this.m_objViewer.dw.InsertRow(0);
        }

        public void m_mthSearch()
        {
            this.m_objViewer.Cursor = Cursors.WaitCursor;
            this.m_objViewer.m_dgvMedDetail.DataSource = null;
            this.m_objViewer.m_dgvMedDetail.Refresh();
            DateTime dtm1 = Convert.ToDateTime(this.m_objViewer.m_dtpSearchBeginDate.Text);
            DateTime dtm2 = Convert.ToDateTime(this.m_objViewer.m_dtpSearchEndDate.Text);
            string m_strMidicineId=string.Empty;
            if(this .m_objViewer.m_txtMedicineCode.Text!="")
            {
             m_strMidicineId=this .m_objViewer.m_txtMedicineCode.Tag.ToString();
            }
            DataTable dt;
            long lngRes = m_objDomain.m_lngGetRecipeBySpecialMedicine(m_objViewer.m_strStorageid, dtm1, dtm2,m_objViewer.m_cbbType.SelectedIndex,m_strMidicineId,out dt);
            if (lngRes > 0&&m_objViewer.m_strStorageid=="0001")
            {
                DataView dvResult = dt.DefaultView;
                DataRow drSum = dt.NewRow();
                dvResult.Sort = "treatdate_dat desc";

                if (dt.Rows.Count > 0)
                {
                    double dblTempSum = 0d;
                    DataRow drAdd = dt.NewRow();
                    for (int i1 = 0; i1 < dt.Columns.Count; i1++)
                    {
                        dblTempSum = 0d;
                        if (dt.Columns[i1].ColumnName.ToLower() == "usagename_vchr")
                        {
                            drAdd[i1] = "合计";
                        }
                        else if (dt.Columns[i1].ColumnName.ToLower() == "tolqty_dec")
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
                dt = dvResult.ToTable();
                this.m_objViewer.m_dgvMedDetail.DataSource = dt;

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
                this.m_objViewer.dw.Retrieve(dt);
                this.m_objViewer.dw.SetRedrawOn();
                this.m_objViewer.dw.Refresh();
            }
            else if (lngRes > 0 && m_objViewer.m_strStorageid == "0003"&&dt.Rows.Count >0)
            {
                this.m_objViewer.m_dgvMedDetail.Columns["medicinename_vchr"].DataPropertyName = "medicinename_vchr";
                this.m_objViewer.m_dgvMedDetail.Columns["medspec_vchr"].DataPropertyName = "medspec_vchr";
                this.m_objViewer.m_dgvMedDetail.Columns["patientcardid_chr"].HeaderText = "住院号";
                this.m_objViewer.m_dgvMedDetail.Columns["patientcardid_chr"].DataPropertyName = "inpatientid_chr";
                this.m_objViewer.m_dgvMedDetail.Columns["lastname_vchr"].DataPropertyName = "lastname_vchr";
                this.m_objViewer.m_dgvMedDetail.Columns["tolqty_dec"].DataPropertyName = "get_dec";
                this.m_objViewer.m_dgvMedDetail.Columns["treatdate_dat"].DataPropertyName = "pubdate_dat";
                this.m_objViewer.m_dgvMedDetail.Columns["unitid_chr"].DataPropertyName = "unit_vchr";
                this.m_objViewer.m_dgvMedDetail.Columns["dosage_dec"].Visible = true;
                this.m_objViewer.m_dgvMedDetail.Columns["lastname"].Visible = false;
                this.m_objViewer.m_dgvMedDetail.Columns["usagename_vchr"].Visible = false;
                this.m_objViewer.m_dgvMedDetail.Columns["dosage_dec"].HeaderText = "金额";
                this.m_objViewer.m_dgvMedDetail.Columns["dosage_dec"].DataPropertyName = "SumMoney";
                this.m_objViewer.m_dgvMedDetail.Columns["days_int"].Visible = true;
                this.m_objViewer.m_dgvMedDetail.Columns["days_int"].HeaderText = "单价";
                this.m_objViewer.m_dgvMedDetail.Columns["days_int"].DataPropertyName = "unitprice_mny";
                this.m_objViewer.m_dgvMedDetail.Columns["tys"].HeaderText = "科室";
                this.m_objViewer.m_dgvMedDetail.Columns["tys"].DataPropertyName = "deptname_vchr";
                DataView dvResult = dt.DefaultView;
                DataRow drSum = dt.NewRow();
                if (dt.Rows.Count > 0)
                {
                    dt.Columns.Add("SumMoney");
                    for (int intRow = 0; intRow < dt.Rows.Count; intRow++)
                    {
                        if (dt.Rows[intRow]["get_dec"] != DBNull.Value && dt.Rows[intRow]["unitprice_mny"]!=DBNull.Value)
                        {
                        dt.Rows[intRow]["SumMoney"] = Convert.ToDouble(dt.Rows[intRow]["get_dec"]) * Convert.ToDouble(dt.Rows[intRow]["unitprice_mny"]);
                        }
                    }
                    double dblTempSum = 0;
                    double dblTempSumMoney = 0;
                    DataRow drAdd = dt.NewRow();
                    for (int i1 = 0; i1 < dt.Columns.Count; i1++)
                    {
                        dblTempSum = 0;
                        dblTempSumMoney = 0;
                        if (dt.Columns[i1].ColumnName.ToLower() == "medicinename_vchr")
                        {
                            drAdd[i1] = "合计";
                        }
                        else if (dt.Columns[i1].ColumnName.ToLower() == "get_dec")
                        {
                            for (int i2 = 0; i2 < dt.Rows.Count; i2++)
                            {
                                dblTempSum += Convert.ToDouble(dt.Rows[i2][i1]);
                            }
                            drAdd[i1] = dblTempSum;
                        }
                        else if (dt.Columns[i1].ColumnName == "SumMoney")
                        {
                            for (int i2 = 0; i2 < dt.Rows.Count; i2++)
                            {
                                dblTempSumMoney += Convert.ToDouble(dt.Rows[i2][i1]);
                            }
                            drAdd[i1] = dblTempSumMoney;
 
                        }

                    }
                    dt.Rows.Add(drAdd);
                    dt.AcceptChanges();
                }
                dt = dvResult.ToTable();
                this.m_objViewer.m_dgvMedDetail.DataSource = dt;
                this.m_objViewer.m_dgvMedDetail.Refresh();
            }

            else if (lngRes <= 0)
            {
                MessageBox.Show(this.m_objViewer, "检索数据出错，请检查。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.m_objViewer.Cursor = Cursors.Default;
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
            m_mthGetMedBaseInfo(m_objViewer.m_strStorageid,out m_objViewer.m_dtMedince);
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
