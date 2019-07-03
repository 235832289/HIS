using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    public partial class frmRptGoWayStorageStat : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 全局变量
        private DataTable m_dtbDept;
        /// <summary>
        /// 药房/药库名称
        /// </summary>
        private DataTable m_dtbMedName;
        /// <summary>
        /// 0-药房 1-药库
        /// </summary>
        private int m_intMsOrDs;
        /// <summary>
        /// 是否药房使用
        /// </summary>
        internal bool m_blnIsDrugStore = false;
        /// <summary>
        /// 药房id/药库id
        /// </summary>
        private string[] m_strMedStorageidArr;
        #endregion

        #region 显示窗体
        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="p_strMsOrDsid">0-药房 1-药库</param>
        /// <param name="p_strMedStorageid">药房id/药库id</param>
        public void m_mthShow(string p_strMsOrDs, string p_strMedStorageid)
        {
            m_intMsOrDs = Convert.ToInt32(p_strMsOrDs);
            if (m_intMsOrDs == 0)
                m_blnIsDrugStore = true;
            m_strMedStorageidArr = p_strMedStorageid.Split('*');
            this.Show();
        }
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public frmRptGoWayStorageStat()
        {
            InitializeComponent();
        }
        #endregion

        #region 窗体控制对象
        /// <summary>
        /// 窗体控制对象
        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsCtl_RptGoWayStorageStat();
            objController.Set_GUI_Apperance(this);
        }
        #endregion

        #region 初始化窗体
        /// <summary>
        /// 初始化窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmRptGoWayStorageStat_Load(object sender, EventArgs e)
        {
            this.m_dgvGoWayMedStorageStat.AutoGenerateColumns = false;
            this.m_dgvGoWayStorageStat.AutoGenerateColumns = false;
            if (m_blnIsDrugStore)
            {
                this.m_dgvGoWayMedStorageStat.Visible = false;
                this.m_lbloutstoragepriceSum.Visible = false;
                this.m_lblretailoutlossSum.Visible = false;
                this.m_lblretailpriceSum.Visible = false;
                this.Label.Visible = false;
                this.label7.Visible = false;
                this.label9.Visible = false;
            }
            this.m_dtpBeginDate.Text = clsPublic.CurrentDateTimeNow.AddMonths(-1).ToString("yyyy年MM月dd日 00:00:00");
            this.m_dtpEndDate.Text = clsPublic.CurrentDateTimeNow.ToString("yyyy年MM月dd日 HH:mm:ss");
            ((clsCtl_RptGoWayStorageStat)objController).m_mthInitdw();
            ((clsCtl_RptGoWayStorageStat)objController).m_mthGetMsOrDsName(m_intMsOrDs, out m_dtbMedName);
            ((clsCtl_RptGoWayStorageStat)objController).m_mthGetMedType();

            ///领用部门
            ((clsCtl_RptGoWayStorageStat)objController).m_mthGetDept(out m_dtbDept);
            this.m_txtReceiveDept.m_mthInitDeptData(m_dtbDept);
            m_txtReceiveDept.BringToFront();

            #region 药房/库名称
            if (m_dtbMedName.Rows.Count > 0)
            {
                if (m_strMedStorageidArr!=null && m_strMedStorageidArr.Length > 0)
                {
                    this.m_cboMedStorage.Items.Clear();

                    for (int iOr = 0; iOr < m_strMedStorageidArr.Length; iOr++)
                    {
                        for (int jOr = 0; jOr < m_dtbMedName.Rows.Count; jOr++)
                        {
                            if (m_strMedStorageidArr[iOr].ToString().Trim() == m_dtbMedName.Rows[jOr]["storageid_chr"].ToString().Trim()) //id
                            {
                                this.m_cboMedStorage.Item.Add(m_dtbMedName.Rows[jOr]["storagename_vchr"].ToString().Trim(), m_dtbMedName.Rows[jOr]["storageid_chr"].ToString().Trim()); //name
                            }
                        }
                    }

                    this.m_cboMedStorage.SelectedIndex = 0;
                }
                else
                {
                    this.m_cboMedStorage.Items.Clear();

                    this.m_cboMedStorage.Item.Add("全部","0000");

                    for (int k = 0; k < m_dtbMedName.Rows.Count; k++)
                    {
                        this.m_cboMedStorage.Item.Add(m_dtbMedName.Rows[k]["storagename_vchr"].ToString().Trim(), m_dtbMedName.Rows[k]["storageid_chr"].ToString().Trim()); //name
                    }

                    this.m_cboMedStorage.SelectedIndex = 0;
                }
            }
            #endregion
        }
        #endregion

        #region 事件
        private void m_btnQuery_Click(object sender, EventArgs e)
        {
            ((clsCtl_RptGoWayStorageStat)this.objController).m_mthSearchData();
        }

        private void m_btnPreview_Click(object sender, EventArgs e)
        {
            com.digitalwave.iCare.gui.MedicineStore.clsCtl_Public.PrintDialog(this.dw);
        }

        private void m_btnPrint_Click(object sender, EventArgs e)
        {
            ((clsCtl_RptGoWayStorageStat)this.objController).m_mthPrint();
        }

        private void m_btnExport_Click(object sender, EventArgs e)
        {
            ((clsCtl_RptGoWayStorageStat)this.objController).m_mthExploreData();
        }

        private void m_btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void m_dgvGoWayMedStorageStat_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.m_dgvGoWayMedStorageStat.Columns[e.ColumnIndex].DisplayIndex > 0)
            {
                --this.m_dgvGoWayMedStorageStat.Columns[e.ColumnIndex].DisplayIndex;
            }
        }

        private void m_cboMedStorage_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Text = "药品去向汇总统计表(" + m_cboMedStorage.Text + ")";
        }

        private void m_dgvGoWayMedStorageStat_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.m_dgvGoWayMedStorageStat.DataSource == null) return;
            DataTable dt = this.m_dgvGoWayMedStorageStat.DataSource as DataTable;
            if (dt.Rows.Count == 0) return;
            dt.Rows.Remove(dt.Rows[dt.Rows.Count - 1]);
            dt.AcceptChanges();
            DataGridViewColumn dgvColumn = this.m_dgvGoWayMedStorageStat.Columns[e.ColumnIndex];
            dgvColumn.Tag = (dgvColumn.Tag == null || (ListSortDirection)dgvColumn.Tag == ListSortDirection.Ascending) ? ListSortDirection.Descending : ListSortDirection.Ascending;
            this.m_dgvGoWayMedStorageStat.Sort(dgvColumn, (ListSortDirection)dgvColumn.Tag);

            for (int i = 0; i < this.m_dgvGoWayMedStorageStat.Rows.Count; i++)
            {
                DataRowView drv = this.m_dgvGoWayMedStorageStat.Rows[i].DataBoundItem as DataRowView;
                DataRow dr = drv.Row;
                dr.BeginEdit();
                dr["SortRowNo"] = i;
                dr.EndEdit();
            }
            ((clsCtl_RptGoWayStorageStat)objController).m_mthAddTotalSumRow(dt);
            dt.Rows[dt.Rows.Count - 1]["SortRowNo"] = dt.Rows.Count;
            dt.AcceptChanges();
            this.m_dgvGoWayMedStorageStat.Sort(m_dgvGoWayMedStorageStat.Columns["m_dgvSortRowNo"], ListSortDirection.Ascending);
        }
    }
}