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
    public class clsCtl_RecipeByMedicineDeptReport : com.digitalwave.GUI_Base.clsController_Base
    {
        private frmRecipeByMedicineDeptReport m_objViewer;
        private clsDcl_RecipeByMedicineDeptReport m_objDomain;
        private ctlQueryMedicintLeastElement m_ctlMedQuery;
        public clsCtl_RecipeByMedicineDeptReport()
        {
            m_objDomain = new clsDcl_RecipeByMedicineDeptReport();
        }

        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmRecipeByMedicineDeptReport)frmMDI_Child_Base_in;
        }

        public void m_mthInit()
        {
            this.m_objViewer.dw.LibraryList = Application.StartupPath + "\\pb_op.pbl";
            this.m_objViewer.dw.DataWindowObject = "d_op_recipebytypedept";
            this.m_objViewer.dw.InsertRow(0);
        }

        public void m_mthSearch()
        {
            try
            {
                this.m_objViewer.Cursor = Cursors.WaitCursor;
                DateTime dtm1 = Convert.ToDateTime(this.m_objViewer.m_dtpSearchBeginDate.Text);
                DateTime dtm2 = Convert.ToDateTime(this.m_objViewer.m_dtpSearchEndDate.Text);
                DataTable dt;
                string strDeptid = "";
                string strMedicineId = "";
                if (this.m_objViewer.m_txtReceiveDept.Text.Trim() != "")
                    strDeptid = this.m_objViewer.m_txtReceiveDept.StrItemId;
                if (string.IsNullOrEmpty(Convert.ToString(m_objViewer.m_txtMedicineCode.Tag)))
                {
                     MessageBox.Show(this.m_objViewer, "请选择药品。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     return;
                }
                else
                {
                    strMedicineId = Convert.ToString(m_objViewer.m_txtMedicineCode.Tag);
                }

                long lngRes = m_objDomain.m_lngGetRecipeByMedicineDeptReport(m_objViewer.m_strStorageid, strDeptid,strMedicineId, dtm1, dtm2, out dt);
                if (lngRes > 0)
                {
                    
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

                    //this.m_objViewer.dw.Modify("t_title.text='" + this.m_objComInfo.m_strGetHospitalTitle() + "'");
                    //this.m_objViewer.dw.Modify("m_strdate.text='" + dtm1.ToString("yyyy-MM-dd HH:mm:ss") + " ---- " + dtm2.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                    //this.m_objViewer.dw.Modify("strstoragename.text='" + m_objViewer.m_cboStorageName.SelectItemText + "'");
                    //this.m_objViewer.dw.Modify("m_strmedicinecode.text='" + this.m_objViewer.m_btnQuery.Tag.ToString() + "'");
                    //this.m_objViewer.dw.Modify("t_strmedicinename.text='" + this.m_objViewer.m_txtMedicineCode.Text + "'");
                    this.m_objViewer.dw.Modify("t_name.text='"+this .m_objViewer.m_txtMedicineCode.Text.Trim()+"'");
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

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.m_objViewer.Cursor = Cursors.Default;
            }
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
                    else if (p_dtbResult.Columns[i1].ColumnName.ToLower() == "ipamount" || p_dtbResult.Columns[i1].ColumnName.ToLower() == "sumprice")
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

        internal void m_mthGetDept(out DataTable m_dtbDept)
        {
            m_objDomain.m_lngGetExportDeptForDrugStore(out m_dtbDept); //药房
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
            m_mthGetMedBaseInfo(m_objViewer.m_strStorageid, out m_objViewer.m_dtMedince);
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

        internal long m_mthGetMedBaseInfo(string m_strDeptId, out DataTable m_dtMedicine)
        {
            return m_objDomain.m_mthGetMedBaseInfo(m_strDeptId, out m_dtMedicine);
        }
    }
}
