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
    /// <summary>
    /// 
    /// </summary>
    public partial class frmRptAdjustpricefullloss : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 全局变量
        internal DataTable m_dtMedince;
        private DataTable m_objTable = null;
        /// <summary>
        /// 0001-西药库;0002-中药库
        /// </summary>
        private string[] strStorageArr;
        /// <summary>
        /// 药库名
        /// </summary>
        private DataTable m_dtStorageName;
        #endregion

        #region 窗体显示
        /// <summary>
        /// 窗体显示
        /// </summary>
        /// <param name="p_strStorageid"></param>
        public void m_mthShowid(string p_strStorageid)
        {
            strStorageArr = p_strStorageid.Split('*');
            this.Show();
        }
        #endregion

        #region 窗体控制对象
        /// <summary>
        /// 窗体控制对象
        /// </summary>
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.MedicineStore_Maintain.clsCtl_RptAdjustpricefullloss();
            objController.Set_GUI_Apperance(this);
        }
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public frmRptAdjustpricefullloss()
        {
            InitializeComponent();
        }
        #endregion

        #region 初始化窗体
        /// <summary>
        /// 初始化窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmRptAdjustpricefullloss_Load(object sender, EventArgs e)
        {
            this.m_dgvAdjustFullloss.AutoGenerateColumns = false;
            m_objTable = new DataTable();
            m_dtStorageName = new DataTable();
            this.m_dtpBeginDat.Text = clsPublic.CurrentDateTimeNow.AddMonths(-1).ToString("yyyy年MM月dd日 00:00:00");
            this.m_dtpEndDat.Text = clsPublic.CurrentDateTimeNow.ToString("yyyy年MM月dd日 HH:mm:ss");
            ((clsCtl_RptAdjustpricefullloss)this.objController).m_mthGetStorageName(out m_dtStorageName);
            ((clsCtl_RptAdjustpricefullloss)this.objController).m_mthGetMedicineType(out  m_objTable);
            
            ((clsCtl_RptAdjustpricefullloss)this.objController).m_mthGetInitdw();
            if (m_dtStorageName.Rows.Count > 0)
            {
                if (strStorageArr != null && strStorageArr.Length > 0)
                {
                    this.m_cboStorageName.Items.Clear();

                    for (int i1 = 0; i1 < strStorageArr.Length; i1++)
                    {
                        for (int j2 = 0; j2 < m_dtStorageName.Rows.Count; j2++)
                        {
                            if (m_dtStorageName.Rows[j2]["medstoreid"].ToString() == strStorageArr[i1].ToString())
                            {
                                this.m_cboStorageName.Item.Add(m_dtStorageName.Rows[j2]["storagename"].ToString(), m_dtStorageName.Rows[j2]["medstoreid"].ToString());
                            }
                        }
                    }
                    this.m_cboStorageName.SelectedIndex = 0;
                }
                else
                {
                    this.m_cboStorageName.Items.Clear();

                    this.m_cboStorageName.Item.Add("全部", "0000");

                    for (int k = 0; k < m_dtStorageName.Rows.Count; k++)
                    {
                        this.m_cboStorageName.Item.Add(m_dtStorageName.Rows[k]["storagename"].ToString(), m_dtStorageName.Rows[k]["medstoreid"].ToString());
                    }
                    this.m_cboStorageName.SelectedIndex = 0;
                }
            }

            if (m_objTable != null && m_objTable.Rows.Count > 0)
            {
                this.m_cboMedicineType.Items.Clear();

                this.m_cboMedicineType.Item.Add("全部", "0000");

                for (int i = 0; i < m_objTable.Rows.Count; i++)
                {
                    this.m_cboMedicineType.Item.Add(m_objTable.Rows[i]["medicinetypename_vchr"].ToString(), m_objTable.Rows[i]["medicinetypeid_chr"].ToString());
                }

                this.m_cboMedicineType.SelectedIndex = 0;
            }
        }
        #endregion

        #region 事件
        private void m_cmdQuery_Click(object sender, EventArgs e)
        {
            //if (m_txtMedicineCode.Text == "")
            //{
            //    this.dw.Reset();
            //    this.dw.Refresh();
            //    this.dw.InsertRow(0);
            //    MessageBox.Show("请选择药品名称", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    m_txtMedicineCode.Focus();
            //    return;
            //}
            ((clsCtl_RptAdjustpricefullloss)this.objController).m_mthSelectAdjustprice();
        }

        private void m_cmdExcel_Click(object sender, EventArgs e)
        {
            ((clsCtl_RptAdjustpricefullloss)this.objController).m_mthExploreData();
        }

        private void m_cmdPrint_Click(object sender, EventArgs e)
        {
            ((clsCtl_RptAdjustpricefullloss)this.objController).m_mthPrint();
        }

        private void m_cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_btnPreview_Click(object sender, EventArgs e)
        {
            //dw.PrintProperties.Preview = !dw.PrintProperties.Preview;
            //dw.PrintProperties.ShowPreviewRulers = !dw.PrintProperties.ShowPreviewRulers;
            com.digitalwave.iCare.gui.MedicineStore.clsCtl_Public.PrintDialog(this.dw);
        }
        #endregion

        #region 方法
        private void m_mthEnterToTab(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            { SendKeys.Send("{TAB}"); }
        }
        #endregion

        private void m_txtMedicineCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (m_dtMedince == null)
                {
                    ((clsCtl_RptAdjustpricefullloss)this.objController).m_mthGetMedicine();
                }
                ((clsCtl_RptAdjustpricefullloss)this.objController).m_mthShowMedince(this.m_txtMedicineCode.Text.Trim());
            }
        }

        private void m_cboStorageName_SelectedValueChanged(object sender, EventArgs e)
        {
            //((clsCtl_RptAdjustpricefullloss)this.objController).m_mthGetMedicine();
        }

        private void m_dgvAdjustFullloss_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.m_dgvAdjustFullloss.DataSource == null) return;
            DataTable dt = this.m_dgvAdjustFullloss.DataSource as DataTable;
            if (dt.Rows.Count == 0) return;
            dt.Rows.Remove(dt.Rows[dt.Rows.Count - 1]);
            dt.AcceptChanges();
            DataGridViewColumn dgvColumn = this.m_dgvAdjustFullloss.Columns[e.ColumnIndex];
            dgvColumn.Tag = (dgvColumn.Tag == null || (ListSortDirection)dgvColumn.Tag == ListSortDirection.Ascending) ? ListSortDirection.Descending : ListSortDirection.Ascending;
            this.m_dgvAdjustFullloss.Sort(dgvColumn, (ListSortDirection)dgvColumn.Tag);

            for (int i = 0; i < this.m_dgvAdjustFullloss.Rows.Count; i++)
            {
                DataRowView drv = this.m_dgvAdjustFullloss.Rows[i].DataBoundItem as DataRowView;
                DataRow dr = drv.Row;
                dr.BeginEdit();
                dr["SortRowNo"] = i;
                dr.EndEdit();
            }
            ((clsCtl_RptAdjustpricefullloss)objController).m_mthAddTotalSumRow(dt);
            dt.Rows[dt.Rows.Count - 1]["SortRowNo"] = dt.Rows.Count;
            dt.AcceptChanges();
            this.m_dgvAdjustFullloss.Sort(m_dgvAdjustFullloss.Columns["SortRowNo"], ListSortDirection.Ascending);
        }

        private void m_dgvAdjustFullloss_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.m_dgvAdjustFullloss.Columns[e.ColumnIndex].DisplayIndex > 0)
                --this.m_dgvAdjustFullloss.Columns[e.ColumnIndex].DisplayIndex;
        }

    }
}