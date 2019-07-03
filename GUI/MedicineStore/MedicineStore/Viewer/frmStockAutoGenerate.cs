using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using System.Text.RegularExpressions;
namespace com.digitalwave.iCare.gui.MedicineStore
{
    public partial class frmStockAutoGenerate: com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        internal DataTable m_dtbMedicineInfo;
        /// <summary>
        /// 仓库ID
        /// </summary>
        internal string m_strStorageID;
        public frmStockAutoGenerate()
        {
            InitializeComponent();
        }
        public override void CreateController()
        {
            this.objController = new clsCtl_StockAutoGenerate();
            objController.Set_GUI_Apperance(this);
        }

        #region 设置DataGridView的列属性
        internal void m_mthInitDataTable()
        {
            m_dgvDrugStorage.Columns.Clear();

            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            column.Name = "IfCheck";
            column.HeaderText = "";
            column.TrueValue = "T";
            column.FalseValue = "F";
            m_dgvDrugStorage.Columns.Add(column);
            m_dgvDrugStorage.Columns[0].Width = 20;
            m_dgvDrugStorage.Columns[0].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            m_dgvDrugStorage.Columns[0].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            m_dgvDrugStorage.Columns[0].Frozen = true;

            m_dgvDrugStorage.Columns.Add("assistcode_chr", "药品代码");
            m_dgvDrugStorage.Columns[1].Width = 100;
            m_dgvDrugStorage.Columns[1].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            m_dgvDrugStorage.Columns[1].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;

            m_dgvDrugStorage.Columns.Add("medicineid_chr", "药品ID");
            m_dgvDrugStorage.Columns[2].Width = 82;
            m_dgvDrugStorage.Columns[2].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            m_dgvDrugStorage.Columns[2].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            m_dgvDrugStorage.Columns[2].Visible = false;

            m_dgvDrugStorage.Columns.Add("medicinename_vchr", "药品名称");
            m_dgvDrugStorage.Columns[3].Width = 254;
            m_dgvDrugStorage.Columns[3].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            m_dgvDrugStorage.Columns[3].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;

            m_dgvDrugStorage.Columns.Add("medspec_vchr", "规格");
            m_dgvDrugStorage.Columns[4].Width = 80;
            m_dgvDrugStorage.Columns[4].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            m_dgvDrugStorage.Columns[4].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;

            m_dgvDrugStorage.Columns.Add("opunit_chr", "基本单位");
            m_dgvDrugStorage.Columns[5].Width = 78;
            m_dgvDrugStorage.Columns[5].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            m_dgvDrugStorage.Columns[5].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
           

            m_dgvDrugStorage.Columns.Add("tiptoplimit_int", "上限");
            m_dgvDrugStorage.Columns[6].Width = 120;
            m_dgvDrugStorage.Columns[6].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            m_dgvDrugStorage.Columns[6].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            m_dgvDrugStorage.Columns[6].DefaultCellStyle.Format = "0.00";

            m_dgvDrugStorage.Columns.Add("neaplimit_int", "下限");
            m_dgvDrugStorage.Columns[7].Width = 130;
            m_dgvDrugStorage.Columns[7].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            m_dgvDrugStorage.Columns[7].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            m_dgvDrugStorage.Columns[7].DefaultCellStyle.Format = "0.00";

            m_dgvDrugStorage.Columns.Add("currentgross_num", "库存量");
            m_dgvDrugStorage.Columns[8].Width = 120;
            m_dgvDrugStorage.Columns[8].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            m_dgvDrugStorage.Columns[8].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            m_dgvDrugStorage.Columns[8].DefaultCellStyle.Format = "0.00";

            m_dgvDrugStorage.Columns.Add("amount", "采购量");
            m_dgvDrugStorage.Columns[9].Width = 110;
            m_dgvDrugStorage.Columns[9].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            m_dgvDrugStorage.Columns[9].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            m_dgvDrugStorage.Columns[9].DefaultCellStyle.Format = "0.00";

            m_dgvDrugStorage.Columns.Add("vendorid_chr", "供应商ID");
            m_dgvDrugStorage.Columns[10].Width = 110;
            m_dgvDrugStorage.Columns[10].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            m_dgvDrugStorage.Columns[10].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            m_dgvDrugStorage.Columns[10].Visible = false;

            m_dgvDrugStorage.Columns.Add("vendorname", "供应商");
            m_dgvDrugStorage.Columns[11].Width = 110;
            m_dgvDrugStorage.Columns[11].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            m_dgvDrugStorage.Columns[11].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            m_dgvDrugStorage.Columns[11].Visible = false;

            m_dgvDrugStorage.Columns.Add("callprice_int", "购入价");
            m_dgvDrugStorage.Columns[12].Width = 110;
            m_dgvDrugStorage.Columns[12].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            m_dgvDrugStorage.Columns[12].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            m_dgvDrugStorage.Columns[12].DefaultCellStyle.Format = "0.00";
            m_dgvDrugStorage.Columns[12].Visible = false;

            m_dgvDrugStorage.Columns.Add("instoragedate_dat", "上次采购日期");
            m_dgvDrugStorage.Columns[13].Width = 110;
            m_dgvDrugStorage.Columns[13].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            m_dgvDrugStorage.Columns[13].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            m_dgvDrugStorage.Columns[13].Visible = false;

            m_dgvDrugStorage.Columns.Add("productorid_chr", "生产厂家");
            m_dgvDrugStorage.Columns[14].Width = 110;
            m_dgvDrugStorage.Columns[14].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            m_dgvDrugStorage.Columns[14].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            m_dgvDrugStorage.Columns[14].Visible = false;

            for (int i1 = 1; i1 < m_dgvDrugStorage.ColumnCount; i1++)
            {
                m_dgvDrugStorage.Columns[i1].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
                if(i1 != 9)
                    m_dgvDrugStorage.Columns[i1].ReadOnly = true;
            }

            m_dgvDrugStorage.Columns[0].DataPropertyName = "IfCheck";
            m_dgvDrugStorage.Columns[1].DataPropertyName = "assistcode_chr";
            m_dgvDrugStorage.Columns[2].DataPropertyName = "medicineid_chr";
            m_dgvDrugStorage.Columns[3].DataPropertyName = "medicinename_vchr";
            m_dgvDrugStorage.Columns[4].DataPropertyName = "medspec_vchr";
            m_dgvDrugStorage.Columns[5].DataPropertyName = "opunit_chr";
            m_dgvDrugStorage.Columns[6].DataPropertyName = "tiptoplimit_int";
            m_dgvDrugStorage.Columns[7].DataPropertyName = "neaplimit_int";
            m_dgvDrugStorage.Columns[8].DataPropertyName = "currentgross_num";
            m_dgvDrugStorage.Columns[9].DataPropertyName = "amount";
            m_dgvDrugStorage.Columns[10].DataPropertyName = "vendorid_chr";
            m_dgvDrugStorage.Columns[11].DataPropertyName = "vendorname";
            m_dgvDrugStorage.Columns[12].DataPropertyName = "callprice_int";
            m_dgvDrugStorage.Columns[13].DataPropertyName = "instoragedate_dat";
            m_dgvDrugStorage.Columns[14].DataPropertyName = "productorid_chr";
        }
        #endregion       

        public void m_mthShow(string p_strStorageID)
        {
            m_strStorageID = p_strStorageID;
            Show();
        }

        private void frmStockAutoGenerate_Load(object sender, EventArgs e)
        {
            m_mthInitDataTable();
            ((clsCtl_StockAutoGenerate)objController).m_lngGetDetailForGenerate(m_strStorageID);
            m_lblSelected_Click(m_lblSelected, null);
        }

        private void m_btnCancle_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void m_btnRefresh_Click(object sender, EventArgs e)
        {
            ((clsCtl_StockAutoGenerate)objController).m_lngGetDetailForGenerate(m_strStorageID);
        }

        private void m_lblSelected_Click(object sender, EventArgs e)
        {
            if (this.m_dgvDrugStorage.Rows.Count > 0)
            {
                //this.m_dgvDrugStorage.CurrentCell = this.m_dgvDrugStorage.Rows[0].Cells[1];
                if (this.m_lblSelected.Text == "全选")
                {
                    m_lblSelected.Text = "反选";
                    for (int iRow = 0; iRow < m_dgvDrugStorage.Rows.Count; iRow++)
                    {
                        m_dgvDrugStorage.Rows[iRow].Cells[0].Value = "T";
                    }
                }
                else if (m_lblSelected.Text == "反选")
                {
                    m_lblSelected.Text = "全选";
                    for (int iRow = 0; iRow < m_dgvDrugStorage.Rows.Count; iRow++)
                    {
                        m_dgvDrugStorage.Rows[iRow].Cells[0].Value = "F";
                    }
                }
                m_dgvDrugStorage.Refresh();
            }
        }

        private void m_btnGenerate_Click(object sender, EventArgs e)
        {
            clsMS_StockPlan_Detail_VO[] p_objDetailArr = GetSelectedRetail();
            if(p_objDetailArr != null)
                ((clsCtl_StockAutoGenerate)objController).m_mthGenerate(p_objDetailArr);            
        }

        private clsMS_StockPlan_Detail_VO[] GetSelectedRetail()
        {
            if (m_dgvDrugStorage.DataSource == null) return null;
            DataTable dtbResult = m_dgvDrugStorage.DataSource as DataTable;
            if (dtbResult.Rows.Count <= 0) return null;
            DataTable dtbSelected = dtbResult.Clone();
            dtbResult.PrimaryKey = new DataColumn[] { dtbResult.Columns["medicineid_chr"] };
            DataRow drSelect = null;
            for (int i1 = 0; i1 < m_dgvDrugStorage.Rows.Count; i1++)
            {
                if (m_dgvDrugStorage[0, i1].Value == null)
                    continue;
                if (m_dgvDrugStorage[0, i1].Value.ToString() == "T")
                {
                    drSelect = dtbResult.Rows.Find(m_dgvDrugStorage["medicineid_chr", i1].Value);
                    dtbSelected.Rows.Add(drSelect.ItemArray);
                }
            }
            int iRow = dtbSelected.Rows.Count;
            if (iRow > 0)
            {
                clsMS_StockPlan_Detail_VO[] m_objDetailArr = new clsMS_StockPlan_Detail_VO[iRow];
                DateTime datTemp;
                for (int i2 = 0; i2 < m_objDetailArr.Length; i2++)
                {
                    m_objDetailArr[i2] = new clsMS_StockPlan_Detail_VO();
                    m_objDetailArr[i2].m_strASSISTCODE_CHR = dtbSelected.Rows[i2]["assistcode_chr"].ToString();
                    m_objDetailArr[i2].m_strMEDICINEID_CHR = dtbSelected.Rows[i2]["medicineid_chr"].ToString();
                    m_objDetailArr[i2].m_strMEDICINENAME_VCHR = dtbSelected.Rows[i2]["medicinename_vchr"].ToString();
                    m_objDetailArr[i2].m_strMEDSPEC_VCHR = dtbSelected.Rows[i2]["medspec_vchr"].ToString();
                    m_objDetailArr[i2].m_strPRODUCTORID_CHR = dtbSelected.Rows[i2]["productorid_chr"].ToString();
                    m_objDetailArr[i2].m_strUNIT_VCHR = dtbSelected.Rows[i2]["opunit_chr"].ToString();
                    m_objDetailArr[i2].m_dblAMOUNT = Convert.ToDouble(dtbSelected.Rows[i2]["amount"]);
                    m_objDetailArr[i2].m_strVENDORID_CHR = dtbSelected.Rows[i2]["vendorid_chr"].ToString();
                    m_objDetailArr[i2].m_strVENDORNAME_VCHR = dtbSelected.Rows[i2]["vendorname"].ToString();
                    if(DateTime.TryParse(dtbSelected.Rows[i2]["instoragedate_dat"].ToString(),out datTemp))
                        m_objDetailArr[i2].m_datLASTINSTORAGEDATE_DAT = datTemp;
                    m_objDetailArr[i2].m_dblCALLPRICE_INT = Convert.ToDouble(dtbSelected.Rows[i2]["callprice_int"]);
                    m_objDetailArr[i2].m_dblSTOCKSUM = m_objDetailArr[i2].m_dblAMOUNT * m_objDetailArr[i2].m_dblCALLPRICE_INT;
                }
                return m_objDetailArr;
            }
            return null;
        }
    }
}