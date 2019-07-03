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
    public class clsCtl_RecipeByIdentityReport : com.digitalwave.GUI_Base.clsController_Base
    {
        private frmRecipeByIdentityReport m_objViewer;
        private clsDcl_RecipeByIdentityReport m_objDomain;
        public clsCtl_RecipeByIdentityReport()
        {
            m_objDomain = new clsDcl_RecipeByIdentityReport();
        }

        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmRecipeByIdentityReport)frmMDI_Child_Base_in;
        }

        public void m_mthInit()
        {
            this.m_objViewer.dw.LibraryList = Application.StartupPath + "\\pb_op.pbl";
            this.m_objViewer.dw.DataWindowObject = "d_op_recipebyidentity";
            this.m_objViewer.dw.InsertRow(0);
        }

        public void m_mthSearch()
        {            
            this.m_objViewer.Cursor = Cursors.WaitCursor;
            DateTime dtm1 = Convert.ToDateTime(this.m_objViewer.m_dtpSearchBeginDate.Text);
            DateTime dtm2 = Convert.ToDateTime(this.m_objViewer.m_dtpSearchEndDate.Text);
            DataTable dt;

            long lngRes = m_objDomain.m_lngGetRecipeByIdentity(m_objViewer.m_strStorageid, dtm1, dtm2,out dt);
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
                    if (p_dtbResult.Columns[i1].ColumnName.ToLower() == "paytypename_vchr")
                    {
                        drAdd[i1] = "合计";
                    }
                    else if (p_dtbResult.Columns[i1].ColumnName.ToLower() == "je")
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
    }
}
