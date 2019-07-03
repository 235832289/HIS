using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ControlLibrary;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    public partial class frmRptRecipeOutSumStat : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        internal DataTable m_dtMedince;
        internal DataTable m_dtProduct;
        /// <summary>
        /// 药房ID
        /// </summary>
        internal string m_strDrugID;
        internal string m_strDrugStoreName;
        /// <summary>
        /// 对应住院中药房药房ID
        /// </summary>
        internal string m_strCenterStoreName = "";
        /// <summary>
        /// 药房Id对应的部门id，实际查询用此作为参数
        /// </summary>
        internal string m_strDeptID = null;
        /// <summary>
        /// 住院中心药房部门ID
        /// </summary>
        internal string m_strCenterDeptID;
        /// <summary>
        /// 构造函数
        /// </summary>
        public frmRptRecipeOutSumStat()
        {
            InitializeComponent();
        }

        public override void CreateController()
        {
            objController = new clsCtl_RptRecipeOutSumStat();
            objController.Set_GUI_Apperance(this);
        }

        public void m_mthShow(string p_strDrugID,string p_strCenterStoreID)
        {
            if (p_strDrugID== "0001")
            {
                this.m_strDrugID = p_strDrugID.Trim();
                ((clsCtl_RptRecipeOutSumStat)this.objController).m_lngGetDeptIDByDrugID(m_strDrugID, out m_strDeptID);
                ((clsCtl_RptRecipeOutSumStat)this.objController).m_lngGetStoreNameByID(m_strDrugID, out m_strDrugStoreName);
                if (p_strCenterStoreID.Trim() == "0003")
                {
                    ((clsCtl_RptRecipeOutSumStat)this.objController).m_lngGetStoreNameByID(p_strCenterStoreID.Trim(), out m_strCenterStoreName);
                    this.Text = "药品消耗金额统计表" + "(" + m_strCenterStoreName + ")" + "(" + m_strDrugStoreName + ")";
                    m_strCenterDeptID = "0003";
                }
                else
                {
                    this.Text = "处方药品消耗金额统计表" + "(" +m_strDrugStoreName+ ")";
 
                }
            }
           if(p_strCenterStoreID=="0003")
            {
                m_strCenterDeptID = "0003";
               if(p_strDrugID!="0001")
               {
                   m_strDrugID = "0003";
                   ((clsCtl_RptRecipeOutSumStat)this.objController).m_lngGetDeptIDByDrugID(m_strCenterDeptID, out m_strDeptID);
                   ((clsCtl_RptRecipeOutSumStat)this.objController).m_lngGetStoreNameByID(p_strCenterStoreID, out m_strCenterStoreName);
                   this.Text = "中心药房摆药消耗金额统计表(" + m_strCenterStoreName + ")";
                   this.m_dgvOutSumStat.Columns["deptName"].Visible = true;
                   this.m_dgvOutSumStat.Columns["unitprice_mny"].Visible = true;
               }
            }

            this.Show();
        }


        private void frmRptInstorageStat_Load(object sender, EventArgs e)
        {
            this.m_dgvOutSumStat.AutoGenerateColumns = false;
            this.m_dtpSearchBeginDate.Text = clsPublic.SysDateTimeNow.AddMonths(-1).ToString("yyyy年MM月dd日 00时00分00秒");
            this.m_dtpSearchEndDate.Text = clsPublic.SysDateTimeNow.ToString("yyyy年MM月dd日 HH时mm分ss秒");

            ((clsCtl_RptRecipeOutSumStat)this.objController).m_mthInit();
            ((clsCtl_RptRecipeOutSumStat)this.objController).m_mthFillMedType();            
        }

        private void m_cmdSearch_Click(object sender, EventArgs e)
        {
            ((clsCtl_RptRecipeOutSumStat)this.objController).m_mthSearch();
        }

        private void m_cmdPrint_Click(object sender, EventArgs e)
        {
            if (this.dw.RowCount > 0)
            {
                com.digitalwave.iCare.gui.HIS.clsPublic.ChoosePrintDialog(this.dw, true);
            }
        }

        private void m_cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_txtMedicineCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ((clsCtl_RptRecipeOutSumStat)this.objController).m_mthSearch();
        }

        private void txtTypecode_ItemSelectedOK(object s, EventArgs e)
        {
            SendKeys.Send("{TAB}");
        }

        private void m_txtMedicineCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (m_dtMedince == null || m_dtMedince.Rows.Count == 0)
                {
                    ((clsCtl_RptRecipeOutSumStat)this.objController).m_mthGetMedBaseInfo(m_strDrugID, out m_dtMedince);
                }
                ((clsCtl_RptRecipeOutSumStat)this.objController).m_mthShowMedince(this.m_txtMedicineCode.Text.Trim());
            }
        }

        private void m_cmdExport_Click(object sender, EventArgs e)
        {
            //SaveFileDialog frmSFD = new SaveFileDialog();
            //frmSFD.Filter = "Excel文件|*.xls";
            //if (frmSFD.ShowDialog() == DialogResult.OK)
            //{
            //    if (frmSFD.FileName != string.Empty)
            //        dw.SaveAs(frmSFD.FileName, Sybase.DataWindow.FileSaveAsType.Excel);
            //}
            if (this.m_dgvOutSumStat.Rows.Count > 0)
            {
                com.digitalwave.iCare.gui.HIS.clsPub.m_mthExportToExcel(this.m_dgvOutSumStat);
            }
        }

        private void m_cmdPreview_Click(object sender, EventArgs e)
        {
            //dw.PrintProperties.Preview = !dw.PrintProperties.Preview;
            //dw.PrintProperties.ShowPreviewRulers = !dw.PrintProperties.ShowPreviewRulers;
            com.digitalwave.iCare.gui.HIS.clsPublic.PrintDialog(this.dw);
        }

        private void m_txtMedicineCode_TextChanged(object sender, EventArgs e)
        {
            if (m_txtMedicineCode.Text.Trim() == "")
                m_txtMedicineCode.Tag = "";
        }

        private void m_dgvOutSumStat_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.m_dgvOutSumStat.Columns[e.ColumnIndex].DisplayIndex > 0)
            {
                --this.m_dgvOutSumStat.Columns[e.ColumnIndex].DisplayIndex;
            }                                                                                                                                                                          
        }

        private void m_dgvOutSumStat_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.m_strCenterDeptID == "0003" && this.m_strDrugID != "0001")
            {
                return;
            }
            if (this.m_strCenterDeptID == "0003" && this.m_strDrugID == "0001")
            {
                return;
            }

            if (this.m_dgvOutSumStat.DataSource == null) return;
            DataTable dt = this.m_dgvOutSumStat.DataSource as DataTable;
            if (dt.Rows.Count == 0) return;
            dt.Rows.Remove(dt.Rows[dt.Rows.Count - 1]);
            dt.AcceptChanges();
            DataGridViewColumn dgvColumn = this.m_dgvOutSumStat.Columns[e.ColumnIndex];
            dgvColumn.Tag = (dgvColumn.Tag == null || (ListSortDirection)dgvColumn.Tag == ListSortDirection.Ascending) ? ListSortDirection.Descending : ListSortDirection.Ascending;
            this.m_dgvOutSumStat.Sort(dgvColumn, (ListSortDirection)dgvColumn.Tag);

            for (int i = 0; i < this.m_dgvOutSumStat.Rows.Count; i++)
            {
                DataRowView drv = this.m_dgvOutSumStat.Rows[i].DataBoundItem as DataRowView;
                DataRow dr = drv.Row;
                dr.BeginEdit();
                dr["SortRowNo"] = i;
                dr.EndEdit();
            }
            ((clsCtl_RptRecipeOutSumStat)objController).m_mthAddTotalSumRow(dt);
            dt.Rows[dt.Rows.Count - 1]["SortRowNo"] = dt.Rows.Count;
            dt.AcceptChanges();
            this.m_dgvOutSumStat.Sort(m_dgvOutSumStat.Columns["m_dgvSortRowNo"], ListSortDirection.Ascending);
        }
    }
}